using System;

namespace SevenZip
{
	// Token: 0x020006E3 RID: 1763
	internal class CRC
	{
		// Token: 0x060021B3 RID: 8627 RVA: 0x004030E8 File Offset: 0x004012E8
		static CRC()
		{
			for (uint num = 0u; num < 256u; num += 1u)
			{
				uint num2 = num;
				for (int i = 0; i < 8; i++)
				{
					if ((num2 & 1u) != 0u)
					{
						num2 = (num2 >> 1 ^ 3988292384u);
					}
					else
					{
						num2 >>= 1;
					}
				}
				CRC.Table[(int)((UIntPtr)num)] = num2;
			}
		}

		// Token: 0x060021B4 RID: 8628 RVA: 0x00403154 File Offset: 0x00401354
		public void Init()
		{
			this._value = uint.MaxValue;
		}

		// Token: 0x060021B5 RID: 8629 RVA: 0x00403160 File Offset: 0x00401360
		public void UpdateByte(byte b)
		{
			this._value = (CRC.Table[(int)((byte)this._value ^ b)] ^ this._value >> 8);
		}

		// Token: 0x060021B6 RID: 8630 RVA: 0x00403180 File Offset: 0x00401380
		public void Update(byte[] data, uint offset, uint size)
		{
			for (uint num = 0u; num < size; num += 1u)
			{
				this._value = (CRC.Table[(int)((byte)this._value ^ data[(int)((UIntPtr)(offset + num))])] ^ this._value >> 8);
			}
		}

		// Token: 0x060021B7 RID: 8631 RVA: 0x004031C4 File Offset: 0x004013C4
		public uint GetDigest()
		{
			return this._value ^ uint.MaxValue;
		}

		// Token: 0x060021B8 RID: 8632 RVA: 0x004031D0 File Offset: 0x004013D0
		private static uint CalculateDigest(byte[] data, uint offset, uint size)
		{
			CRC crc = new CRC();
			crc.Update(data, offset, size);
			return crc.GetDigest();
		}

		// Token: 0x060021B9 RID: 8633 RVA: 0x004031F4 File Offset: 0x004013F4
		private static bool VerifyDigest(uint digest, byte[] data, uint offset, uint size)
		{
			return CRC.CalculateDigest(data, offset, size) == digest;
		}

		// Token: 0x04006A73 RID: 27251
		public static readonly uint[] Table = new uint[256];

		// Token: 0x04006A74 RID: 27252
		private uint _value = uint.MaxValue;
	}
}
