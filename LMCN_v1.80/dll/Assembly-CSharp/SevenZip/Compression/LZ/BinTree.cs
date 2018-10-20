using System;
using System.IO;

namespace SevenZip.Compression.LZ
{
	// Token: 0x020006EF RID: 1775
	public class BinTree : InWindow, IInWindowStream, IMatchFinder
	{
		// Token: 0x060021D2 RID: 8658 RVA: 0x004033C0 File Offset: 0x004015C0
		public void SetType(int numHashBytes)
		{
			this.HASH_ARRAY = (numHashBytes > 2);
			if (this.HASH_ARRAY)
			{
				this.kNumHashDirectBytes = 0u;
				this.kMinMatchCheck = 4u;
				this.kFixHashSize = 66560u;
			}
			else
			{
				this.kNumHashDirectBytes = 2u;
				this.kMinMatchCheck = 3u;
				this.kFixHashSize = 0u;
			}
		}

		// Token: 0x060021D3 RID: 8659 RVA: 0x00403418 File Offset: 0x00401618
		public new void SetStream(Stream stream)
		{
			base.SetStream(stream);
		}

		// Token: 0x060021D4 RID: 8660 RVA: 0x00403424 File Offset: 0x00401624
		public new void ReleaseStream()
		{
			base.ReleaseStream();
		}

		// Token: 0x060021D5 RID: 8661 RVA: 0x0040342C File Offset: 0x0040162C
		public new void Init()
		{
			base.Init();
			for (uint num = 0u; num < this._hashSizeSum; num += 1u)
			{
				this._hash[(int)((UIntPtr)num)] = 0u;
			}
			this._cyclicBufferPos = 0u;
			base.ReduceOffsets(-1);
		}

		// Token: 0x060021D6 RID: 8662 RVA: 0x00403470 File Offset: 0x00401670
		public new void MovePos()
		{
			if ((this._cyclicBufferPos += 1u) >= this._cyclicBufferSize)
			{
				this._cyclicBufferPos = 0u;
			}
			base.MovePos();
			if (this._pos == 2147483647u)
			{
				this.Normalize();
			}
		}

		// Token: 0x060021D7 RID: 8663 RVA: 0x004034BC File Offset: 0x004016BC
		public new byte GetIndexByte(int index)
		{
			return base.GetIndexByte(index);
		}

		// Token: 0x060021D8 RID: 8664 RVA: 0x004034C8 File Offset: 0x004016C8
		public new uint GetMatchLen(int index, uint distance, uint limit)
		{
			return base.GetMatchLen(index, distance, limit);
		}

		// Token: 0x060021D9 RID: 8665 RVA: 0x004034D4 File Offset: 0x004016D4
		public new uint GetNumAvailableBytes()
		{
			return base.GetNumAvailableBytes();
		}

		// Token: 0x060021DA RID: 8666 RVA: 0x004034DC File Offset: 0x004016DC
		public void Create(uint historySize, uint keepAddBufferBefore, uint matchMaxLen, uint keepAddBufferAfter)
		{
			if (historySize > 2147483391u)
			{
				throw new Exception();
			}
			this._cutValue = 16u + (matchMaxLen >> 1);
			uint keepSizeReserv = (historySize + keepAddBufferBefore + matchMaxLen + keepAddBufferAfter) / 2u + 256u;
			base.Create(historySize + keepAddBufferBefore, matchMaxLen + keepAddBufferAfter, keepSizeReserv);
			this._matchMaxLen = matchMaxLen;
			uint num = historySize + 1u;
			if (this._cyclicBufferSize != num)
			{
				this._son = new uint[(this._cyclicBufferSize = num) * 2u];
			}
			uint num2 = 65536u;
			if (this.HASH_ARRAY)
			{
				num2 = historySize - 1u;
				num2 |= num2 >> 1;
				num2 |= num2 >> 2;
				num2 |= num2 >> 4;
				num2 |= num2 >> 8;
				num2 >>= 1;
				num2 |= 65535u;
				if (num2 > 16777216u)
				{
					num2 >>= 1;
				}
				this._hashMask = num2;
				num2 += 1u;
				num2 += this.kFixHashSize;
			}
			if (num2 != this._hashSizeSum)
			{
				this._hash = new uint[this._hashSizeSum = num2];
			}
		}

		// Token: 0x060021DB RID: 8667 RVA: 0x004035D4 File Offset: 0x004017D4
		public uint GetMatches(uint[] distances)
		{
			uint num;
			if (this._pos + this._matchMaxLen <= this._streamPos)
			{
				num = this._matchMaxLen;
			}
			else
			{
				num = this._streamPos - this._pos;
				if (num < this.kMinMatchCheck)
				{
					this.MovePos();
					return 0u;
				}
			}
			uint num2 = 0u;
			uint num3 = (this._pos <= this._cyclicBufferSize) ? 0u : (this._pos - this._cyclicBufferSize);
			uint num4 = this._bufferOffset + this._pos;
			uint num5 = 1u;
			uint num6 = 0u;
			uint num7 = 0u;
			uint num9;
			if (this.HASH_ARRAY)
			{
				uint num8 = CRC.Table[(int)this._bufferBase[(int)((UIntPtr)num4)]] ^ (uint)this._bufferBase[(int)((UIntPtr)(num4 + 1u))];
				num6 = (num8 & 1023u);
				num8 ^= (uint)((uint)this._bufferBase[(int)((UIntPtr)(num4 + 2u))] << 8);
				num7 = (num8 & 65535u);
				num9 = ((num8 ^ CRC.Table[(int)this._bufferBase[(int)((UIntPtr)(num4 + 3u))]] << 5) & this._hashMask);
			}
			else
			{
				num9 = (uint)((int)this._bufferBase[(int)((UIntPtr)num4)] ^ (int)this._bufferBase[(int)((UIntPtr)(num4 + 1u))] << 8);
			}
			uint num10 = this._hash[(int)((UIntPtr)(this.kFixHashSize + num9))];
			if (this.HASH_ARRAY)
			{
				uint num11 = this._hash[(int)((UIntPtr)num6)];
				uint num12 = this._hash[(int)((UIntPtr)(1024u + num7))];
				this._hash[(int)((UIntPtr)num6)] = this._pos;
				this._hash[(int)((UIntPtr)(1024u + num7))] = this._pos;
				if (num11 > num3 && this._bufferBase[(int)((UIntPtr)(this._bufferOffset + num11))] == this._bufferBase[(int)((UIntPtr)num4)])
				{
					num5 = (distances[(int)((UIntPtr)(num2++))] = 2u);
					distances[(int)((UIntPtr)(num2++))] = this._pos - num11 - 1u;
				}
				if (num12 > num3 && this._bufferBase[(int)((UIntPtr)(this._bufferOffset + num12))] == this._bufferBase[(int)((UIntPtr)num4)])
				{
					if (num12 == num11)
					{
						num2 -= 2u;
					}
					num5 = (distances[(int)((UIntPtr)(num2++))] = 3u);
					distances[(int)((UIntPtr)(num2++))] = this._pos - num12 - 1u;
					num11 = num12;
				}
				if (num2 != 0u && num11 == num10)
				{
					num2 -= 2u;
					num5 = 1u;
				}
			}
			this._hash[(int)((UIntPtr)(this.kFixHashSize + num9))] = this._pos;
			uint num13 = (this._cyclicBufferPos << 1) + 1u;
			uint num14 = this._cyclicBufferPos << 1;
			uint val2;
			uint val = val2 = this.kNumHashDirectBytes;
			if (this.kNumHashDirectBytes != 0u && num10 > num3 && this._bufferBase[(int)((UIntPtr)(this._bufferOffset + num10 + this.kNumHashDirectBytes))] != this._bufferBase[(int)((UIntPtr)(num4 + this.kNumHashDirectBytes))])
			{
				num5 = (distances[(int)((UIntPtr)(num2++))] = this.kNumHashDirectBytes);
				distances[(int)((UIntPtr)(num2++))] = this._pos - num10 - 1u;
			}
			uint cutValue = this._cutValue;
			while (num10 > num3 && cutValue-- != 0u)
			{
				uint num15 = this._pos - num10;
				uint num16 = ((num15 > this._cyclicBufferPos) ? (this._cyclicBufferPos - num15 + this._cyclicBufferSize) : (this._cyclicBufferPos - num15)) << 1;
				uint num17 = this._bufferOffset + num10;
				uint num18 = Math.Min(val2, val);
				if (this._bufferBase[(int)((UIntPtr)(num17 + num18))] == this._bufferBase[(int)((UIntPtr)(num4 + num18))])
				{
					while ((num18 += 1u) != num)
					{
						if (this._bufferBase[(int)((UIntPtr)(num17 + num18))] != this._bufferBase[(int)((UIntPtr)(num4 + num18))])
						{
							break;
						}
					}
					if (num5 < num18)
					{
						num5 = (distances[(int)((UIntPtr)(num2++))] = num18);
						distances[(int)((UIntPtr)(num2++))] = num15 - 1u;
						if (num18 == num)
						{
							this._son[(int)((UIntPtr)num14)] = this._son[(int)((UIntPtr)num16)];
							this._son[(int)((UIntPtr)num13)] = this._son[(int)((UIntPtr)(num16 + 1u))];
							IL_461:
							this.MovePos();
							return num2;
						}
					}
				}
				if (this._bufferBase[(int)((UIntPtr)(num17 + num18))] < this._bufferBase[(int)((UIntPtr)(num4 + num18))])
				{
					this._son[(int)((UIntPtr)num14)] = num10;
					num14 = num16 + 1u;
					num10 = this._son[(int)((UIntPtr)num14)];
					val = num18;
				}
				else
				{
					this._son[(int)((UIntPtr)num13)] = num10;
					num13 = num16;
					num10 = this._son[(int)((UIntPtr)num13)];
					val2 = num18;
				}
			}
			this._son[(int)((UIntPtr)num13)] = (this._son[(int)((UIntPtr)num14)] = 0u);
			goto IL_461;
		}

		// Token: 0x060021DC RID: 8668 RVA: 0x00403A4C File Offset: 0x00401C4C
		public void Skip(uint num)
		{
			for (;;)
			{
				uint num2;
				if (this._pos + this._matchMaxLen <= this._streamPos)
				{
					num2 = this._matchMaxLen;
					goto IL_49;
				}
				num2 = this._streamPos - this._pos;
				if (num2 >= this.kMinMatchCheck)
				{
					goto IL_49;
				}
				this.MovePos();
				IL_2F9:
				if ((num -= 1u) == 0u)
				{
					break;
				}
				continue;
				IL_49:
				uint num3 = (this._pos <= this._cyclicBufferSize) ? 0u : (this._pos - this._cyclicBufferSize);
				uint num4 = this._bufferOffset + this._pos;
				uint num8;
				if (this.HASH_ARRAY)
				{
					uint num5 = CRC.Table[(int)this._bufferBase[(int)((UIntPtr)num4)]] ^ (uint)this._bufferBase[(int)((UIntPtr)(num4 + 1u))];
					uint num6 = num5 & 1023u;
					this._hash[(int)((UIntPtr)num6)] = this._pos;
					num5 ^= (uint)((uint)this._bufferBase[(int)((UIntPtr)(num4 + 2u))] << 8);
					uint num7 = num5 & 65535u;
					this._hash[(int)((UIntPtr)(1024u + num7))] = this._pos;
					num8 = ((num5 ^ CRC.Table[(int)this._bufferBase[(int)((UIntPtr)(num4 + 3u))]] << 5) & this._hashMask);
				}
				else
				{
					num8 = (uint)((int)this._bufferBase[(int)((UIntPtr)num4)] ^ (int)this._bufferBase[(int)((UIntPtr)(num4 + 1u))] << 8);
				}
				uint num9 = this._hash[(int)((UIntPtr)(this.kFixHashSize + num8))];
				this._hash[(int)((UIntPtr)(this.kFixHashSize + num8))] = this._pos;
				uint num10 = (this._cyclicBufferPos << 1) + 1u;
				uint num11 = this._cyclicBufferPos << 1;
				uint val2;
				uint val = val2 = this.kNumHashDirectBytes;
				uint cutValue = this._cutValue;
				while (num9 > num3 && cutValue-- != 0u)
				{
					uint num12 = this._pos - num9;
					uint num13 = ((num12 > this._cyclicBufferPos) ? (this._cyclicBufferPos - num12 + this._cyclicBufferSize) : (this._cyclicBufferPos - num12)) << 1;
					uint num14 = this._bufferOffset + num9;
					uint num15 = Math.Min(val2, val);
					if (this._bufferBase[(int)((UIntPtr)(num14 + num15))] == this._bufferBase[(int)((UIntPtr)(num4 + num15))])
					{
						while ((num15 += 1u) != num2)
						{
							if (this._bufferBase[(int)((UIntPtr)(num14 + num15))] != this._bufferBase[(int)((UIntPtr)(num4 + num15))])
							{
								break;
							}
						}
						if (num15 == num2)
						{
							this._son[(int)((UIntPtr)num11)] = this._son[(int)((UIntPtr)num13)];
							this._son[(int)((UIntPtr)num10)] = this._son[(int)((UIntPtr)(num13 + 1u))];
							IL_2F3:
							this.MovePos();
							goto IL_2F9;
						}
					}
					if (this._bufferBase[(int)((UIntPtr)(num14 + num15))] < this._bufferBase[(int)((UIntPtr)(num4 + num15))])
					{
						this._son[(int)((UIntPtr)num11)] = num9;
						num11 = num13 + 1u;
						num9 = this._son[(int)((UIntPtr)num11)];
						val = num15;
					}
					else
					{
						this._son[(int)((UIntPtr)num10)] = num9;
						num10 = num13;
						num9 = this._son[(int)((UIntPtr)num10)];
						val2 = num15;
					}
				}
				this._son[(int)((UIntPtr)num10)] = (this._son[(int)((UIntPtr)num11)] = 0u);
				goto IL_2F3;
			}
		}

		// Token: 0x060021DD RID: 8669 RVA: 0x00403D60 File Offset: 0x00401F60
		private void NormalizeLinks(uint[] items, uint numItems, uint subValue)
		{
			for (uint num = 0u; num < numItems; num += 1u)
			{
				uint num2 = items[(int)((UIntPtr)num)];
				if (num2 <= subValue)
				{
					num2 = 0u;
				}
				else
				{
					num2 -= subValue;
				}
				items[(int)((UIntPtr)num)] = num2;
			}
		}

		// Token: 0x060021DE RID: 8670 RVA: 0x00403D9C File Offset: 0x00401F9C
		private void Normalize()
		{
			uint subValue = this._pos - this._cyclicBufferSize;
			this.NormalizeLinks(this._son, this._cyclicBufferSize * 2u, subValue);
			this.NormalizeLinks(this._hash, this._hashSizeSum, subValue);
			base.ReduceOffsets((int)subValue);
		}

		// Token: 0x060021DF RID: 8671 RVA: 0x00403DE8 File Offset: 0x00401FE8
		public void SetCutValue(uint cutValue)
		{
			this._cutValue = cutValue;
		}

		// Token: 0x04006A8C RID: 27276
		private const uint kHash2Size = 1024u;

		// Token: 0x04006A8D RID: 27277
		private const uint kHash3Size = 65536u;

		// Token: 0x04006A8E RID: 27278
		private const uint kBT2HashSize = 65536u;

		// Token: 0x04006A8F RID: 27279
		private const uint kStartMaxLen = 1u;

		// Token: 0x04006A90 RID: 27280
		private const uint kHash3Offset = 1024u;

		// Token: 0x04006A91 RID: 27281
		private const uint kEmptyHashValue = 0u;

		// Token: 0x04006A92 RID: 27282
		private const uint kMaxValForNormalize = 2147483647u;

		// Token: 0x04006A93 RID: 27283
		private uint _cyclicBufferPos;

		// Token: 0x04006A94 RID: 27284
		private uint _cyclicBufferSize;

		// Token: 0x04006A95 RID: 27285
		private uint _matchMaxLen;

		// Token: 0x04006A96 RID: 27286
		private uint[] _son;

		// Token: 0x04006A97 RID: 27287
		private uint[] _hash;

		// Token: 0x04006A98 RID: 27288
		private uint _cutValue = 255u;

		// Token: 0x04006A99 RID: 27289
		private uint _hashMask;

		// Token: 0x04006A9A RID: 27290
		private uint _hashSizeSum;

		// Token: 0x04006A9B RID: 27291
		private bool HASH_ARRAY = true;

		// Token: 0x04006A9C RID: 27292
		private uint kNumHashDirectBytes;

		// Token: 0x04006A9D RID: 27293
		private uint kMinMatchCheck = 4u;

		// Token: 0x04006A9E RID: 27294
		private uint kFixHashSize = 66560u;
	}
}
