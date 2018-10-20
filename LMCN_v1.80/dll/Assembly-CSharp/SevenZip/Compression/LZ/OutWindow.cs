using System;
using System.IO;

namespace SevenZip.Compression.LZ
{
	// Token: 0x020006F1 RID: 1777
	public class OutWindow
	{
		// Token: 0x060021EE RID: 8686 RVA: 0x00404164 File Offset: 0x00402364
		public void Create(uint windowSize)
		{
			if (this._windowSize != windowSize)
			{
				this._buffer = new byte[windowSize];
			}
			this._windowSize = windowSize;
			this._pos = 0u;
			this._streamPos = 0u;
		}

		// Token: 0x060021EF RID: 8687 RVA: 0x004041A0 File Offset: 0x004023A0
		public void Init(Stream stream, bool solid)
		{
			this.ReleaseStream();
			this._stream = stream;
			if (!solid)
			{
				this._streamPos = 0u;
				this._pos = 0u;
				this.TrainSize = 0u;
			}
		}

		// Token: 0x060021F0 RID: 8688 RVA: 0x004041D8 File Offset: 0x004023D8
		public bool Train(Stream stream)
		{
			long length = stream.Length;
			uint num = (length >= (long)((ulong)this._windowSize)) ? this._windowSize : ((uint)length);
			this.TrainSize = num;
			stream.Position = length - (long)((ulong)num);
			this._streamPos = (this._pos = 0u);
			while (num > 0u)
			{
				uint num2 = this._windowSize - this._pos;
				if (num < num2)
				{
					num2 = num;
				}
				int num3 = stream.Read(this._buffer, (int)this._pos, (int)num2);
				if (num3 == 0)
				{
					return false;
				}
				num -= (uint)num3;
				this._pos += (uint)num3;
				this._streamPos += (uint)num3;
				if (this._pos == this._windowSize)
				{
					this._streamPos = (this._pos = 0u);
				}
			}
			return true;
		}

		// Token: 0x060021F1 RID: 8689 RVA: 0x004042B0 File Offset: 0x004024B0
		public void ReleaseStream()
		{
			this.Flush();
			this._stream = null;
		}

		// Token: 0x060021F2 RID: 8690 RVA: 0x004042C0 File Offset: 0x004024C0
		public void Flush()
		{
			uint num = this._pos - this._streamPos;
			if (num == 0u)
			{
				return;
			}
			try
			{
				this._stream.Write(this._buffer, (int)this._streamPos, (int)num);
				if (this._pos >= this._windowSize)
				{
					this._pos = 0u;
				}
				this._streamPos = this._pos;
			}
			catch
			{
				UpdateController.OnFail(true);
			}
		}

		// Token: 0x060021F3 RID: 8691 RVA: 0x0040434C File Offset: 0x0040254C
		public void CopyBlock(uint distance, uint len)
		{
			uint num = this._pos - distance - 1u;
			if (num >= this._windowSize)
			{
				num += this._windowSize;
			}
			while (len > 0u)
			{
				if (num >= this._windowSize)
				{
					num = 0u;
				}
				this._buffer[(int)((UIntPtr)(this._pos++))] = this._buffer[(int)((UIntPtr)(num++))];
				if (this._pos >= this._windowSize)
				{
					this.Flush();
				}
				len -= 1u;
			}
		}

		// Token: 0x060021F4 RID: 8692 RVA: 0x004043D8 File Offset: 0x004025D8
		public void PutByte(byte b)
		{
			this._buffer[(int)((UIntPtr)(this._pos++))] = b;
			if (this._pos >= this._windowSize)
			{
				this.Flush();
			}
		}

		// Token: 0x060021F5 RID: 8693 RVA: 0x00404418 File Offset: 0x00402618
		public byte GetByte(uint distance)
		{
			uint num = this._pos - distance - 1u;
			if (num >= this._windowSize)
			{
				num += this._windowSize;
			}
			return this._buffer[(int)((UIntPtr)num)];
		}

		// Token: 0x04006AAA RID: 27306
		private byte[] _buffer;

		// Token: 0x04006AAB RID: 27307
		private uint _pos;

		// Token: 0x04006AAC RID: 27308
		private uint _windowSize;

		// Token: 0x04006AAD RID: 27309
		private uint _streamPos;

		// Token: 0x04006AAE RID: 27310
		private Stream _stream;

		// Token: 0x04006AAF RID: 27311
		public uint TrainSize;
	}
}
