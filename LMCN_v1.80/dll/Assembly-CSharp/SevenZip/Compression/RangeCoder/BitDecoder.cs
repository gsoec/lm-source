using System;

namespace SevenZip.Compression.RangeCoder
{
	// Token: 0x020006FC RID: 1788
	internal struct BitDecoder
	{
		// Token: 0x0600223B RID: 8763 RVA: 0x0040548C File Offset: 0x0040368C
		public void UpdateModel(int numMoveBits, uint symbol)
		{
			if (symbol == 0u)
			{
				this.Prob += 2048u - this.Prob >> numMoveBits;
			}
			else
			{
				this.Prob -= this.Prob >> numMoveBits;
			}
		}

		// Token: 0x0600223C RID: 8764 RVA: 0x004054E0 File Offset: 0x004036E0
		public void Init()
		{
			this.Prob = 1024u;
		}

		// Token: 0x0600223D RID: 8765 RVA: 0x004054F0 File Offset: 0x004036F0
		public uint Decode(Decoder rangeDecoder)
		{
			uint num = (rangeDecoder.Range >> 11) * this.Prob;
			if (rangeDecoder.Code < num)
			{
				rangeDecoder.Range = num;
				this.Prob += 2048u - this.Prob >> 5;
				if (rangeDecoder.Range < 16777216u)
				{
					rangeDecoder.Code = (rangeDecoder.Code << 8 | (uint)((byte)rangeDecoder.Stream.ReadByte()));
					rangeDecoder.Range <<= 8;
				}
				return 0u;
			}
			rangeDecoder.Range -= num;
			rangeDecoder.Code -= num;
			this.Prob -= this.Prob >> 5;
			if (rangeDecoder.Range < 16777216u)
			{
				rangeDecoder.Code = (rangeDecoder.Code << 8 | (uint)((byte)rangeDecoder.Stream.ReadByte()));
				rangeDecoder.Range <<= 8;
			}
			return 1u;
		}

		// Token: 0x04006B00 RID: 27392
		public const int kNumBitModelTotalBits = 11;

		// Token: 0x04006B01 RID: 27393
		public const uint kBitModelTotal = 2048u;

		// Token: 0x04006B02 RID: 27394
		private const int kNumMoveBits = 5;

		// Token: 0x04006B03 RID: 27395
		private uint Prob;
	}
}
