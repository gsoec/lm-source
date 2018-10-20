using System;

namespace SevenZip.Compression.RangeCoder
{
	// Token: 0x020006FD RID: 1789
	internal struct BitTreeEncoder
	{
		// Token: 0x0600223E RID: 8766 RVA: 0x004055E4 File Offset: 0x004037E4
		public BitTreeEncoder(int numBitLevels)
		{
			this.NumBitLevels = numBitLevels;
			this.Models = new BitEncoder[1 << numBitLevels];
		}

		// Token: 0x0600223F RID: 8767 RVA: 0x00405600 File Offset: 0x00403800
		public void Init()
		{
			uint num = 1u;
			while ((ulong)num < (ulong)(1L << (this.NumBitLevels & 31)))
			{
				this.Models[(int)((UIntPtr)num)].Init();
				num += 1u;
			}
		}

		// Token: 0x06002240 RID: 8768 RVA: 0x00405640 File Offset: 0x00403840
		public void Encode(Encoder rangeEncoder, uint symbol)
		{
			uint num = 1u;
			int i = this.NumBitLevels;
			while (i > 0)
			{
				i--;
				uint num2 = symbol >> i & 1u;
				this.Models[(int)((UIntPtr)num)].Encode(rangeEncoder, num2);
				num = (num << 1 | num2);
			}
		}

		// Token: 0x06002241 RID: 8769 RVA: 0x0040568C File Offset: 0x0040388C
		public void ReverseEncode(Encoder rangeEncoder, uint symbol)
		{
			uint num = 1u;
			uint num2 = 0u;
			while ((ulong)num2 < (ulong)((long)this.NumBitLevels))
			{
				uint num3 = symbol & 1u;
				this.Models[(int)((UIntPtr)num)].Encode(rangeEncoder, num3);
				num = (num << 1 | num3);
				symbol >>= 1;
				num2 += 1u;
			}
		}

		// Token: 0x06002242 RID: 8770 RVA: 0x004056D8 File Offset: 0x004038D8
		public uint GetPrice(uint symbol)
		{
			uint num = 0u;
			uint num2 = 1u;
			int i = this.NumBitLevels;
			while (i > 0)
			{
				i--;
				uint num3 = symbol >> i & 1u;
				num += this.Models[(int)((UIntPtr)num2)].GetPrice(num3);
				num2 = (num2 << 1) + num3;
			}
			return num;
		}

		// Token: 0x06002243 RID: 8771 RVA: 0x00405728 File Offset: 0x00403928
		public uint ReverseGetPrice(uint symbol)
		{
			uint num = 0u;
			uint num2 = 1u;
			for (int i = this.NumBitLevels; i > 0; i--)
			{
				uint num3 = symbol & 1u;
				symbol >>= 1;
				num += this.Models[(int)((UIntPtr)num2)].GetPrice(num3);
				num2 = (num2 << 1 | num3);
			}
			return num;
		}

		// Token: 0x06002244 RID: 8772 RVA: 0x00405778 File Offset: 0x00403978
		public static uint ReverseGetPrice(BitEncoder[] Models, uint startIndex, int NumBitLevels, uint symbol)
		{
			uint num = 0u;
			uint num2 = 1u;
			for (int i = NumBitLevels; i > 0; i--)
			{
				uint num3 = symbol & 1u;
				symbol >>= 1;
				num += Models[(int)((UIntPtr)(startIndex + num2))].GetPrice(num3);
				num2 = (num2 << 1 | num3);
			}
			return num;
		}

		// Token: 0x06002245 RID: 8773 RVA: 0x004057C0 File Offset: 0x004039C0
		public static void ReverseEncode(BitEncoder[] Models, uint startIndex, Encoder rangeEncoder, int NumBitLevels, uint symbol)
		{
			uint num = 1u;
			for (int i = 0; i < NumBitLevels; i++)
			{
				uint num2 = symbol & 1u;
				Models[(int)((UIntPtr)(startIndex + num))].Encode(rangeEncoder, num2);
				num = (num << 1 | num2);
				symbol >>= 1;
			}
		}

		// Token: 0x04006B04 RID: 27396
		private BitEncoder[] Models;

		// Token: 0x04006B05 RID: 27397
		private int NumBitLevels;
	}
}
