using System;

namespace SevenZip.Compression.RangeCoder
{
	// Token: 0x020006FE RID: 1790
	internal struct BitTreeDecoder
	{
		// Token: 0x06002246 RID: 8774 RVA: 0x00405804 File Offset: 0x00403A04
		public BitTreeDecoder(int numBitLevels)
		{
			this.NumBitLevels = numBitLevels;
			this.Models = new BitDecoder[1 << numBitLevels];
		}

		// Token: 0x06002247 RID: 8775 RVA: 0x00405820 File Offset: 0x00403A20
		public void Init()
		{
			uint num = 1u;
			while ((ulong)num < (ulong)(1L << (this.NumBitLevels & 31)))
			{
				this.Models[(int)((UIntPtr)num)].Init();
				num += 1u;
			}
		}

		// Token: 0x06002248 RID: 8776 RVA: 0x00405860 File Offset: 0x00403A60
		public uint Decode(Decoder rangeDecoder)
		{
			uint num = 1u;
			for (int i = this.NumBitLevels; i > 0; i--)
			{
				num = (num << 1) + this.Models[(int)((UIntPtr)num)].Decode(rangeDecoder);
			}
			return num - (1u << this.NumBitLevels);
		}

		// Token: 0x06002249 RID: 8777 RVA: 0x004058AC File Offset: 0x00403AAC
		public uint ReverseDecode(Decoder rangeDecoder)
		{
			uint num = 1u;
			uint num2 = 0u;
			for (int i = 0; i < this.NumBitLevels; i++)
			{
				uint num3 = this.Models[(int)((UIntPtr)num)].Decode(rangeDecoder);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}

		// Token: 0x0600224A RID: 8778 RVA: 0x00405900 File Offset: 0x00403B00
		public static uint ReverseDecode(BitDecoder[] Models, uint startIndex, Decoder rangeDecoder, int NumBitLevels)
		{
			uint num = 1u;
			uint num2 = 0u;
			for (int i = 0; i < NumBitLevels; i++)
			{
				uint num3 = Models[(int)((UIntPtr)(startIndex + num))].Decode(rangeDecoder);
				num <<= 1;
				num += num3;
				num2 |= num3 << i;
			}
			return num2;
		}

		// Token: 0x04006B06 RID: 27398
		private BitDecoder[] Models;

		// Token: 0x04006B07 RID: 27399
		private int NumBitLevels;
	}
}
