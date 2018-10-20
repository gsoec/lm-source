using System;

namespace SevenZip.Compression.RangeCoder
{
	// Token: 0x020006FB RID: 1787
	internal struct BitEncoder
	{
		// Token: 0x06002234 RID: 8756 RVA: 0x004052D4 File Offset: 0x004034D4
		static BitEncoder()
		{
			for (int i = 8; i >= 0; i--)
			{
				uint num = 1u << 9 - i - 1;
				uint num2 = 1u << 9 - i;
				for (uint num3 = num; num3 < num2; num3 += 1u)
				{
					BitEncoder.ProbPrices[(int)((UIntPtr)num3)] = (uint)((i << 6) + (int)(num2 - num3 << 6 >> 9 - i - 1));
				}
			}
		}

		// Token: 0x06002235 RID: 8757 RVA: 0x0040534C File Offset: 0x0040354C
		public void Init()
		{
			this.Prob = 1024u;
		}

		// Token: 0x06002236 RID: 8758 RVA: 0x0040535C File Offset: 0x0040355C
		public void UpdateModel(uint symbol)
		{
			if (symbol == 0u)
			{
				this.Prob += 2048u - this.Prob >> 5;
			}
			else
			{
				this.Prob -= this.Prob >> 5;
			}
		}

		// Token: 0x06002237 RID: 8759 RVA: 0x0040539C File Offset: 0x0040359C
		public void Encode(Encoder encoder, uint symbol)
		{
			uint num = (encoder.Range >> 11) * this.Prob;
			if (symbol == 0u)
			{
				encoder.Range = num;
				this.Prob += 2048u - this.Prob >> 5;
			}
			else
			{
				encoder.Low += (ulong)num;
				encoder.Range -= num;
				this.Prob -= this.Prob >> 5;
			}
			if (encoder.Range < 16777216u)
			{
				encoder.Range <<= 8;
				encoder.ShiftLow();
			}
		}

		// Token: 0x06002238 RID: 8760 RVA: 0x00405440 File Offset: 0x00403640
		public uint GetPrice(uint symbol)
		{
			return BitEncoder.ProbPrices[(int)(checked((IntPtr)((unchecked((ulong)(this.Prob - symbol) ^ (ulong)((long)(-(long)symbol))) & 2047UL) >> 2)))];
		}

		// Token: 0x06002239 RID: 8761 RVA: 0x00405460 File Offset: 0x00403660
		public uint GetPrice0()
		{
			return BitEncoder.ProbPrices[(int)((UIntPtr)(this.Prob >> 2))];
		}

		// Token: 0x0600223A RID: 8762 RVA: 0x00405474 File Offset: 0x00403674
		public uint GetPrice1()
		{
			return BitEncoder.ProbPrices[(int)((UIntPtr)(2048u - this.Prob >> 2))];
		}

		// Token: 0x04006AF9 RID: 27385
		public const int kNumBitModelTotalBits = 11;

		// Token: 0x04006AFA RID: 27386
		public const uint kBitModelTotal = 2048u;

		// Token: 0x04006AFB RID: 27387
		private const int kNumMoveBits = 5;

		// Token: 0x04006AFC RID: 27388
		private const int kNumMoveReducingBits = 2;

		// Token: 0x04006AFD RID: 27389
		public const int kNumBitPriceShiftBits = 6;

		// Token: 0x04006AFE RID: 27390
		private uint Prob;

		// Token: 0x04006AFF RID: 27391
		private static uint[] ProbPrices = new uint[512];
	}
}
