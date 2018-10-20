using System;
using System.IO;

namespace SevenZip.Compression.RangeCoder
{
	// Token: 0x020006F9 RID: 1785
	internal class Encoder
	{
		// Token: 0x0600221F RID: 8735 RVA: 0x00404E04 File Offset: 0x00403004
		public void SetStream(Stream stream)
		{
			this.Stream = stream;
		}

		// Token: 0x06002220 RID: 8736 RVA: 0x00404E10 File Offset: 0x00403010
		public void ReleaseStream()
		{
			this.Stream = null;
		}

		// Token: 0x06002221 RID: 8737 RVA: 0x00404E1C File Offset: 0x0040301C
		public void Init()
		{
			this.StartPosition = this.Stream.Position;
			this.Low = 0UL;
			this.Range = uint.MaxValue;
			this._cacheSize = 1u;
			this._cache = 0;
		}

		// Token: 0x06002222 RID: 8738 RVA: 0x00404E58 File Offset: 0x00403058
		public void FlushData()
		{
			for (int i = 0; i < 5; i++)
			{
				this.ShiftLow();
			}
		}

		// Token: 0x06002223 RID: 8739 RVA: 0x00404E80 File Offset: 0x00403080
		public void FlushStream()
		{
			this.Stream.Flush();
		}

		// Token: 0x06002224 RID: 8740 RVA: 0x00404E90 File Offset: 0x00403090
		public void CloseStream()
		{
			this.Stream.Close();
		}

		// Token: 0x06002225 RID: 8741 RVA: 0x00404EA0 File Offset: 0x004030A0
		public void Encode(uint start, uint size, uint total)
		{
			this.Low += (ulong)(start * (this.Range /= total));
			this.Range *= size;
			while (this.Range < 16777216u)
			{
				this.Range <<= 8;
				this.ShiftLow();
			}
		}

		// Token: 0x06002226 RID: 8742 RVA: 0x00404F08 File Offset: 0x00403108
		public void ShiftLow()
		{
			if ((uint)this.Low < 4278190080u || (uint)(this.Low >> 32) == 1u)
			{
				byte b = this._cache;
				do
				{
					this.Stream.WriteByte((byte)((ulong)b + (this.Low >> 32)));
					b = byte.MaxValue;
				}
				while ((this._cacheSize -= 1u) != 0u);
				this._cache = (byte)((uint)this.Low >> 24);
			}
			this._cacheSize += 1u;
			this.Low = (ulong)((ulong)((uint)this.Low) << 8);
		}

		// Token: 0x06002227 RID: 8743 RVA: 0x00404FA0 File Offset: 0x004031A0
		public void EncodeDirectBits(uint v, int numTotalBits)
		{
			for (int i = numTotalBits - 1; i >= 0; i--)
			{
				this.Range >>= 1;
				if ((v >> i & 1u) == 1u)
				{
					this.Low += (ulong)this.Range;
				}
				if (this.Range < 16777216u)
				{
					this.Range <<= 8;
					this.ShiftLow();
				}
			}
		}

		// Token: 0x06002228 RID: 8744 RVA: 0x00405018 File Offset: 0x00403218
		public void EncodeBit(uint size0, int numTotalBits, uint symbol)
		{
			uint num = (this.Range >> numTotalBits) * size0;
			if (symbol == 0u)
			{
				this.Range = num;
			}
			else
			{
				this.Low += (ulong)num;
				this.Range -= num;
			}
			while (this.Range < 16777216u)
			{
				this.Range <<= 8;
				this.ShiftLow();
			}
		}

		// Token: 0x06002229 RID: 8745 RVA: 0x0040508C File Offset: 0x0040328C
		public long GetProcessedSizeAdd()
		{
			return (long)((ulong)this._cacheSize + (ulong)this.Stream.Position - (ulong)this.StartPosition + 4UL);
		}

		// Token: 0x04006AEE RID: 27374
		public const uint kTopValue = 16777216u;

		// Token: 0x04006AEF RID: 27375
		private Stream Stream;

		// Token: 0x04006AF0 RID: 27376
		public ulong Low;

		// Token: 0x04006AF1 RID: 27377
		public uint Range;

		// Token: 0x04006AF2 RID: 27378
		private uint _cacheSize;

		// Token: 0x04006AF3 RID: 27379
		private byte _cache;

		// Token: 0x04006AF4 RID: 27380
		private long StartPosition;
	}
}
