using System;
using System.IO;

namespace SevenZip.Buffer
{
	// Token: 0x020006EC RID: 1772
	public class InBuffer
	{
		// Token: 0x060021C1 RID: 8641 RVA: 0x00403224 File Offset: 0x00401424
		public InBuffer(uint bufferSize)
		{
			this.m_Buffer = new byte[bufferSize];
			this.m_BufferSize = bufferSize;
		}

		// Token: 0x060021C2 RID: 8642 RVA: 0x00403240 File Offset: 0x00401440
		public void Init(Stream stream)
		{
			this.m_Stream = stream;
			this.m_ProcessedSize = 0UL;
			this.m_Limit = 0u;
			this.m_Pos = 0u;
			this.m_StreamWasExhausted = false;
		}

		// Token: 0x060021C3 RID: 8643 RVA: 0x00403274 File Offset: 0x00401474
		public bool ReadBlock()
		{
			if (this.m_StreamWasExhausted)
			{
				return false;
			}
			this.m_ProcessedSize += (ulong)this.m_Pos;
			int num = this.m_Stream.Read(this.m_Buffer, 0, (int)this.m_BufferSize);
			this.m_Pos = 0u;
			this.m_Limit = (uint)num;
			this.m_StreamWasExhausted = (num == 0);
			return !this.m_StreamWasExhausted;
		}

		// Token: 0x060021C4 RID: 8644 RVA: 0x004032DC File Offset: 0x004014DC
		public void ReleaseStream()
		{
			this.m_Stream = null;
		}

		// Token: 0x060021C5 RID: 8645 RVA: 0x004032E8 File Offset: 0x004014E8
		public bool ReadByte(byte b)
		{
			if (this.m_Pos >= this.m_Limit && !this.ReadBlock())
			{
				return false;
			}
			b = this.m_Buffer[(int)((UIntPtr)(this.m_Pos++))];
			return true;
		}

		// Token: 0x060021C6 RID: 8646 RVA: 0x00403330 File Offset: 0x00401530
		public byte ReadByte()
		{
			if (this.m_Pos >= this.m_Limit && !this.ReadBlock())
			{
				return byte.MaxValue;
			}
			return this.m_Buffer[(int)((UIntPtr)(this.m_Pos++))];
		}

		// Token: 0x060021C7 RID: 8647 RVA: 0x00403378 File Offset: 0x00401578
		public ulong GetProcessedSize()
		{
			return this.m_ProcessedSize + (ulong)this.m_Pos;
		}

		// Token: 0x04006A85 RID: 27269
		private byte[] m_Buffer;

		// Token: 0x04006A86 RID: 27270
		private uint m_Pos;

		// Token: 0x04006A87 RID: 27271
		private uint m_Limit;

		// Token: 0x04006A88 RID: 27272
		private uint m_BufferSize;

		// Token: 0x04006A89 RID: 27273
		private Stream m_Stream;

		// Token: 0x04006A8A RID: 27274
		private bool m_StreamWasExhausted;

		// Token: 0x04006A8B RID: 27275
		private ulong m_ProcessedSize;
	}
}
