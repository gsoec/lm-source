using System;
using System.IO;

namespace SevenZip.Compression.LZ
{
	// Token: 0x020006F0 RID: 1776
	public class InWindow
	{
		// Token: 0x060021E1 RID: 8673 RVA: 0x00403DFC File Offset: 0x00401FFC
		public void MoveBlock()
		{
			uint num = this._bufferOffset + this._pos - this._keepSizeBefore;
			if (num > 0u)
			{
				num -= 1u;
			}
			uint num2 = this._bufferOffset + this._streamPos - num;
			for (uint num3 = 0u; num3 < num2; num3 += 1u)
			{
				this._bufferBase[(int)((UIntPtr)num3)] = this._bufferBase[(int)((UIntPtr)(num + num3))];
			}
			this._bufferOffset -= num;
		}

		// Token: 0x060021E2 RID: 8674 RVA: 0x00403E70 File Offset: 0x00402070
		public virtual void ReadBlock()
		{
			if (this._streamEndWasReached)
			{
				return;
			}
			for (;;)
			{
				int num = (int)(0u - this._bufferOffset + this._blockSize - this._streamPos);
				if (num == 0)
				{
					break;
				}
				int num2 = this._stream.Read(this._bufferBase, (int)(this._bufferOffset + this._streamPos), num);
				if (num2 == 0)
				{
					goto Block_3;
				}
				this._streamPos += (uint)num2;
				if (this._streamPos >= this._pos + this._keepSizeAfter)
				{
					this._posLimit = this._streamPos - this._keepSizeAfter;
				}
			}
			return;
			Block_3:
			this._posLimit = this._streamPos;
			uint num3 = this._bufferOffset + this._posLimit;
			if (num3 > this._pointerToLastSafePosition)
			{
				this._posLimit = this._pointerToLastSafePosition - this._bufferOffset;
			}
			this._streamEndWasReached = true;
		}

		// Token: 0x060021E3 RID: 8675 RVA: 0x00403F4C File Offset: 0x0040214C
		private void Free()
		{
			this._bufferBase = null;
		}

		// Token: 0x060021E4 RID: 8676 RVA: 0x00403F58 File Offset: 0x00402158
		public void Create(uint keepSizeBefore, uint keepSizeAfter, uint keepSizeReserv)
		{
			this._keepSizeBefore = keepSizeBefore;
			this._keepSizeAfter = keepSizeAfter;
			uint num = keepSizeBefore + keepSizeAfter + keepSizeReserv;
			if (this._bufferBase == null || this._blockSize != num)
			{
				this.Free();
				this._blockSize = num;
				this._bufferBase = new byte[this._blockSize];
			}
			this._pointerToLastSafePosition = this._blockSize - keepSizeAfter;
		}

		// Token: 0x060021E5 RID: 8677 RVA: 0x00403FC0 File Offset: 0x004021C0
		public void SetStream(Stream stream)
		{
			this._stream = stream;
		}

		// Token: 0x060021E6 RID: 8678 RVA: 0x00403FCC File Offset: 0x004021CC
		public void ReleaseStream()
		{
			this._stream = null;
		}

		// Token: 0x060021E7 RID: 8679 RVA: 0x00403FD8 File Offset: 0x004021D8
		public void Init()
		{
			this._bufferOffset = 0u;
			this._pos = 0u;
			this._streamPos = 0u;
			this._streamEndWasReached = false;
			this.ReadBlock();
		}

		// Token: 0x060021E8 RID: 8680 RVA: 0x00404008 File Offset: 0x00402208
		public void MovePos()
		{
			this._pos += 1u;
			if (this._pos > this._posLimit)
			{
				uint num = this._bufferOffset + this._pos;
				if (num > this._pointerToLastSafePosition)
				{
					this.MoveBlock();
				}
				this.ReadBlock();
			}
		}

		// Token: 0x060021E9 RID: 8681 RVA: 0x0040405C File Offset: 0x0040225C
		public byte GetIndexByte(int index)
		{
			return this._bufferBase[(int)(checked((IntPtr)(unchecked((ulong)(this._bufferOffset + this._pos) + (ulong)((long)index)))))];
		}

		// Token: 0x060021EA RID: 8682 RVA: 0x00404078 File Offset: 0x00402278
		public uint GetMatchLen(int index, uint distance, uint limit)
		{
			if (this._streamEndWasReached && (ulong)this._pos + (ulong)((long)index) + (ulong)limit > (ulong)this._streamPos)
			{
				limit = this._streamPos - (uint)((ulong)this._pos + (ulong)((long)index));
			}
			distance += 1u;
			uint num = this._bufferOffset + this._pos + (uint)index;
			uint num2 = 0u;
			while (num2 < limit && this._bufferBase[(int)((UIntPtr)(num + num2))] == this._bufferBase[(int)((UIntPtr)(num + num2 - distance))])
			{
				num2 += 1u;
			}
			return num2;
		}

		// Token: 0x060021EB RID: 8683 RVA: 0x00404104 File Offset: 0x00402304
		public uint GetNumAvailableBytes()
		{
			return this._streamPos - this._pos;
		}

		// Token: 0x060021EC RID: 8684 RVA: 0x00404114 File Offset: 0x00402314
		public void ReduceOffsets(int subValue)
		{
			this._bufferOffset += (uint)subValue;
			this._posLimit -= (uint)subValue;
			this._pos -= (uint)subValue;
			this._streamPos -= (uint)subValue;
		}

		// Token: 0x04006A9F RID: 27295
		public byte[] _bufferBase;

		// Token: 0x04006AA0 RID: 27296
		private Stream _stream;

		// Token: 0x04006AA1 RID: 27297
		private uint _posLimit;

		// Token: 0x04006AA2 RID: 27298
		private bool _streamEndWasReached;

		// Token: 0x04006AA3 RID: 27299
		private uint _pointerToLastSafePosition;

		// Token: 0x04006AA4 RID: 27300
		public uint _bufferOffset;

		// Token: 0x04006AA5 RID: 27301
		public uint _blockSize;

		// Token: 0x04006AA6 RID: 27302
		public uint _pos;

		// Token: 0x04006AA7 RID: 27303
		private uint _keepSizeBefore;

		// Token: 0x04006AA8 RID: 27304
		private uint _keepSizeAfter;

		// Token: 0x04006AA9 RID: 27305
		public uint _streamPos;
	}
}
