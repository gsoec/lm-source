using System;
using System.IO;

namespace SevenZip.Compression.RangeCoder
{
	// Token: 0x020006FA RID: 1786
	internal class Decoder
	{
		// Token: 0x0600222B RID: 8747 RVA: 0x004050B4 File Offset: 0x004032B4
		public void Init(Stream stream)
		{
			this.Stream = stream;
			this.Code = 0u;
			this.Range = uint.MaxValue;
			for (int i = 0; i < 5; i++)
			{
				this.Code = (this.Code << 8 | (uint)((byte)this.Stream.ReadByte()));
			}
		}

		// Token: 0x0600222C RID: 8748 RVA: 0x00405104 File Offset: 0x00403304
		public void ReleaseStream()
		{
			this.Stream = null;
		}

		// Token: 0x0600222D RID: 8749 RVA: 0x00405110 File Offset: 0x00403310
		public void CloseStream()
		{
			this.Stream.Close();
		}

		// Token: 0x0600222E RID: 8750 RVA: 0x00405120 File Offset: 0x00403320
		public void Normalize()
		{
			while (this.Range < 16777216u)
			{
				this.Code = (this.Code << 8 | (uint)((byte)this.Stream.ReadByte()));
				this.Range <<= 8;
			}
		}

		// Token: 0x0600222F RID: 8751 RVA: 0x0040516C File Offset: 0x0040336C
		public void Normalize2()
		{
			if (this.Range < 16777216u)
			{
				this.Code = (this.Code << 8 | (uint)((byte)this.Stream.ReadByte()));
				this.Range <<= 8;
			}
		}

		// Token: 0x06002230 RID: 8752 RVA: 0x004051A8 File Offset: 0x004033A8
		public uint GetThreshold(uint total)
		{
			return this.Code / (this.Range /= total);
		}

		// Token: 0x06002231 RID: 8753 RVA: 0x004051D0 File Offset: 0x004033D0
		public void Decode(uint start, uint size, uint total)
		{
			this.Code -= start * this.Range;
			this.Range *= size;
			this.Normalize();
		}

		// Token: 0x06002232 RID: 8754 RVA: 0x004051FC File Offset: 0x004033FC
		public uint DecodeDirectBits(int numTotalBits)
		{
			uint num = this.Range;
			uint num2 = this.Code;
			uint num3 = 0u;
			for (int i = numTotalBits; i > 0; i--)
			{
				num >>= 1;
				uint num4 = num2 - num >> 31;
				num2 -= (num & num4 - 1u);
				num3 = (num3 << 1 | 1u - num4);
				if (num < 16777216u)
				{
					num2 = (num2 << 8 | (uint)((byte)this.Stream.ReadByte()));
					num <<= 8;
				}
			}
			this.Range = num;
			this.Code = num2;
			return num3;
		}

		// Token: 0x06002233 RID: 8755 RVA: 0x00405278 File Offset: 0x00403478
		public uint DecodeBit(uint size0, int numTotalBits)
		{
			uint num = (this.Range >> numTotalBits) * size0;
			uint result;
			if (this.Code < num)
			{
				result = 0u;
				this.Range = num;
			}
			else
			{
				result = 1u;
				this.Code -= num;
				this.Range -= num;
			}
			this.Normalize();
			return result;
		}

		// Token: 0x04006AF5 RID: 27381
		public const uint kTopValue = 16777216u;

		// Token: 0x04006AF6 RID: 27382
		public uint Range;

		// Token: 0x04006AF7 RID: 27383
		public uint Code;

		// Token: 0x04006AF8 RID: 27384
		public Stream Stream;
	}
}
