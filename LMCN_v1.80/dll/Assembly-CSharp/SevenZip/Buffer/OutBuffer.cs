using System;
using System.IO;

namespace SevenZip.Buffer
{
	// Token: 0x020006F8 RID: 1784
	public class OutBuffer
	{
		// Token: 0x06002215 RID: 8725 RVA: 0x00404D14 File Offset: 0x00402F14
		public OutBuffer(uint bufferSize)
		{
			this.m_Buffer = new byte[bufferSize];
			this.m_BufferSize = bufferSize;
		}

		// Token: 0x06002216 RID: 8726 RVA: 0x00404D30 File Offset: 0x00402F30
		public void SetStream(Stream stream)
		{
			this.m_Stream = stream;
		}

		// Token: 0x06002217 RID: 8727 RVA: 0x00404D3C File Offset: 0x00402F3C
		public void FlushStream()
		{
			this.m_Stream.Flush();
		}

		// Token: 0x06002218 RID: 8728 RVA: 0x00404D4C File Offset: 0x00402F4C
		public void CloseStream()
		{
			this.m_Stream.Close();
		}

		// Token: 0x06002219 RID: 8729 RVA: 0x00404D5C File Offset: 0x00402F5C
		public void ReleaseStream()
		{
			this.m_Stream = null;
		}

		// Token: 0x0600221A RID: 8730 RVA: 0x00404D68 File Offset: 0x00402F68
		public void Init()
		{
			this.m_ProcessedSize = 0UL;
			this.m_Pos = 0u;
		}

		// Token: 0x0600221B RID: 8731 RVA: 0x00404D7C File Offset: 0x00402F7C
		public void WriteByte(byte b)
		{
			this.m_Buffer[(int)((UIntPtr)(this.m_Pos++))] = b;
			if (this.m_Pos >= this.m_BufferSize)
			{
				this.FlushData();
			}
		}

		// Token: 0x0600221C RID: 8732 RVA: 0x00404DBC File Offset: 0x00402FBC
		public void FlushData()
		{
			if (this.m_Pos == 0u)
			{
				return;
			}
			this.m_Stream.Write(this.m_Buffer, 0, (int)this.m_Pos);
			this.m_Pos = 0u;
		}

		// Token: 0x0600221D RID: 8733 RVA: 0x00404DEC File Offset: 0x00402FEC
		public ulong GetProcessedSize()
		{
			return this.m_ProcessedSize + (ulong)this.m_Pos;
		}

		// Token: 0x04006AE9 RID: 27369
		private byte[] m_Buffer;

		// Token: 0x04006AEA RID: 27370
		private uint m_Pos;

		// Token: 0x04006AEB RID: 27371
		private uint m_BufferSize;

		// Token: 0x04006AEC RID: 27372
		private Stream m_Stream;

		// Token: 0x04006AED RID: 27373
		private ulong m_ProcessedSize;
	}
}
