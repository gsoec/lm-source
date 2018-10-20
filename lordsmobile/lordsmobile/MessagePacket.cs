using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Token: 0x0200077A RID: 1914
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class MessagePacket
{
	// Token: 0x06002553 RID: 9555 RVA: 0x0042AE74 File Offset: 0x00429074
	public MessagePacket(ushort Max = 1024)
	{
		this.Data = NetworkManager.RetrieveSize((int)Max);
		this.Delimiter = this.Data.GetIndex(0);
		this.MaxSize = (int)Max;
		this.length = 4;
	}

	// Token: 0x06002554 RID: 9556 RVA: 0x0042AEB4 File Offset: 0x004290B4
	public MessagePacket(ref byte[] Read, int off, int len)
	{
		this.Data = new Buffer<byte>(Read, off, len);
		this.Delimiter = off;
		this.length = len;
	}

	// Token: 0x06002555 RID: 9557 RVA: 0x0042AEDC File Offset: 0x004290DC
	public MessagePacket(Buffer<byte> Buff)
	{
		this.Data = Buff;
	}

	// Token: 0x170000F9 RID: 249
	// (get) Token: 0x06002556 RID: 9558 RVA: 0x0042AEEC File Offset: 0x004290EC
	public int Length
	{
		get
		{
			return this.length;
		}
	}

	// Token: 0x06002557 RID: 9559 RVA: 0x0042AEF4 File Offset: 0x004290F4
	public static void Clear()
	{
		MessagePacket.Sequence = 0;
	}

	// Token: 0x06002558 RID: 9560 RVA: 0x0042AEFC File Offset: 0x004290FC
	public virtual void AddSeqId()
	{
		if (NetworkManager.Connected())
		{
			this.Add(++MessagePacket.Sequence);
		}
	}

	// Token: 0x06002559 RID: 9561 RVA: 0x0042AF1C File Offset: 0x0042911C
	public void Add(byte data)
	{
		this.Data[this.length] = data;
		this.length++;
	}

	// Token: 0x0600255A RID: 9562 RVA: 0x0042AF4C File Offset: 0x0042914C
	public void Add(ushort data)
	{
		this.Add((short)data);
	}

	// Token: 0x0600255B RID: 9563 RVA: 0x0042AF58 File Offset: 0x00429158
	public unsafe void Add(short data)
	{
		fixed (byte* ptr = &this.Data.GetBuffer()[this.Delimiter + this.length])
		{
			*(short*)ptr = data;
		}
		this.length += 2;
	}

	// Token: 0x0600255C RID: 9564 RVA: 0x0042AF98 File Offset: 0x00429198
	public void Add(uint data)
	{
		this.Add((int)data);
	}

	// Token: 0x0600255D RID: 9565 RVA: 0x0042AFA4 File Offset: 0x004291A4
	public unsafe void Add(int data)
	{
		fixed (byte* ptr = &this.Data.GetBuffer()[this.Delimiter + this.length])
		{
			*(int*)ptr = data;
		}
		this.length += 4;
	}

	// Token: 0x0600255E RID: 9566 RVA: 0x0042AFE4 File Offset: 0x004291E4
	public void Add(ulong data)
	{
		this.Add((long)data);
	}

	// Token: 0x0600255F RID: 9567 RVA: 0x0042AFF0 File Offset: 0x004291F0
	public unsafe void Add(long data)
	{
		if (this.length + 8 > this.MaxSize)
		{
			return;
		}
		fixed (byte* ptr = &this.Data.GetBuffer()[this.Delimiter + this.length])
		{
			*(long*)ptr = data;
		}
		this.length += 8;
	}

	// Token: 0x06002560 RID: 9568 RVA: 0x0042B044 File Offset: 0x00429244
	public void Add(float data)
	{
		this.Add((int)data);
	}

	// Token: 0x06002561 RID: 9569 RVA: 0x0042B050 File Offset: 0x00429250
	public unsafe void Add(string data, int size)
	{
		if (data != null && this.Length + size <= this.MaxSize)
		{
			int num = data.IndexOf('\0');
			fixed (string text = data)
			{
				fixed (char* chars = text + RuntimeHelpers.OffsetToStringData / 2)
				{
					fixed (byte* bytes = &this.Data.GetBuffer()[this.Delimiter + this.length])
					{
						int num2;
						bool flag;
						Encoding.UTF8.GetEncoder().Convert(chars, (num < 0) ? data.Length : num, bytes, size, true, out num2, out num, out flag);
					}
					text = null;
					Array.Clear(this.Data.GetBuffer(), this.Data.GetIndex(this.length + num), size - num);
				}
			}
		}
		this.length += size;
	}

	// Token: 0x06002562 RID: 9570 RVA: 0x0042B114 File Offset: 0x00429314
	public void Add(byte[] data, int startIdx = 0, int len = 0)
	{
		if (data.Length < len && this.Length + len <= this.MaxSize)
		{
			Array.Clear(this.Data.GetBuffer(), this.Data.GetIndex(this.length + data.Length), len - data.Length);
		}
		if (((len > 0 && startIdx <= data.Length - Math.Min(len, data.Length)) || ((len = Buffer.ByteLength(data)) > 0 && startIdx == 0)) && startIdx >= 0 && this.Length + len <= this.MaxSize)
		{
			Buffer.BlockCopy(data, startIdx, this.Data.GetBuffer(), this.Data.GetIndex(this.length), Math.Min(len, data.Length));
		}
		this.length += len;
	}

	// Token: 0x06002563 RID: 9571 RVA: 0x0042B1EC File Offset: 0x004293EC
	public byte ReadByte(int iCount = -1)
	{
		byte result = this.Data[(iCount >= 0) ? iCount : this.Offset];
		if (iCount < 0)
		{
			this.Offset++;
		}
		return result;
	}

	// Token: 0x06002564 RID: 9572 RVA: 0x0042B230 File Offset: 0x00429430
	public ushort ReadUShort(int iCount = -1)
	{
		ushort result = (((iCount >= 0) ? iCount : this.Offset) + this.Delimiter > this.Data.EOB - 2) ? 0 : GameConstants.ConvertBytesToUShort(this.Data.GetBuffer(), this.Data.GetIndex((iCount >= 0) ? iCount : this.Offset));
		if (iCount < 0)
		{
			this.Offset += 2;
		}
		return result;
	}

	// Token: 0x06002565 RID: 9573 RVA: 0x0042B2B4 File Offset: 0x004294B4
	public short ReadShort(int iCount = -1)
	{
		return (short)this.ReadUShort(iCount);
	}

	// Token: 0x06002566 RID: 9574 RVA: 0x0042B2C0 File Offset: 0x004294C0
	public int ReadInt(int iCount = -1)
	{
		int result = 0;
		int num = 4;
		if (iCount < 0)
		{
			if (this.length - this.Offset >= num)
			{
				result = GameConstants.ConvertBytesToInt(this.Data.GetBuffer(), this.Delimiter + this.Offset);
			}
			this.Offset += num;
		}
		else if (this.length - iCount >= num)
		{
			result = GameConstants.ConvertBytesToInt(this.Data.GetBuffer(), this.Delimiter + iCount);
		}
		return result;
	}

	// Token: 0x06002567 RID: 9575 RVA: 0x0042B344 File Offset: 0x00429544
	public uint ReadUInt(int iCount = -1)
	{
		uint result = 0u;
		int num = 4;
		if (iCount < 0)
		{
			if (this.length - this.Offset >= num)
			{
				result = GameConstants.ConvertBytesToUInt(this.Data.GetBuffer(), this.Delimiter + this.Offset);
			}
			this.Offset += num;
		}
		else if (this.length - iCount >= num)
		{
			result = GameConstants.ConvertBytesToUInt(this.Data.GetBuffer(), this.Delimiter + iCount);
		}
		return result;
	}

	// Token: 0x06002568 RID: 9576 RVA: 0x0042B3C8 File Offset: 0x004295C8
	public long ReadLong(int iCount = -1)
	{
		return (long)this.ReadULong(iCount);
	}

	// Token: 0x06002569 RID: 9577 RVA: 0x0042B3D4 File Offset: 0x004295D4
	public ulong ReadULong(int iCount = -1)
	{
		ulong result = 0UL;
		int num = 8;
		if (iCount < 0)
		{
			if (this.length - this.Offset >= num)
			{
				result = BitConverter.ToUInt64(this.Data.GetBuffer(), this.Delimiter + this.Offset);
			}
			this.Offset += num;
		}
		else if (this.length - iCount >= num)
		{
			result = BitConverter.ToUInt64(this.Data.GetBuffer(), this.Delimiter + iCount);
		}
		return result;
	}

	// Token: 0x0600256A RID: 9578 RVA: 0x0042B45C File Offset: 0x0042965C
	public float ReadFloat(int iCount = -1)
	{
		return (float)this.ReadInt(iCount);
	}

	// Token: 0x0600256B RID: 9579 RVA: 0x0042B474 File Offset: 0x00429674
	public double ReadDouble(int iCount = -1)
	{
		return (double)this.ReadLong(iCount);
	}

	// Token: 0x0600256C RID: 9580 RVA: 0x0042B48C File Offset: 0x0042968C
	public DateTime ReadTime(int iCount = -1)
	{
		return DateTime.FromBinary(this.ReadLong(iCount) * 10000000L + 621355968000000000L).ToLocalTime();
	}

	// Token: 0x0600256D RID: 9581 RVA: 0x0042B4C0 File Offset: 0x004296C0
	public unsafe string ReadString(int VSize, int iCount = -1)
	{
		string result = string.Empty;
		int num = 0;
		if (VSize <= 0 || this.length <= ((iCount >= 0) ? iCount : this.Offset))
		{
			return result;
		}
		fixed (byte* ptr = &this.Data.GetBuffer()[this.Delimiter + ((iCount >= 0) ? iCount : this.Offset)])
		{
			while (num < VSize && ptr[num] != 0)
			{
				num++;
			}
		}
		if ((iCount < 0 && this.length - this.Offset >= num) || (iCount >= 0 && this.length - iCount >= num))
		{
			result = Encoding.UTF8.GetString(this.Data.GetBuffer(), this.Delimiter + ((iCount >= 0) ? iCount : this.Offset), num);
		}
		if (iCount < 0)
		{
			this.Offset += VSize;
		}
		return result;
	}

	// Token: 0x0600256E RID: 9582 RVA: 0x0042B5BC File Offset: 0x004297BC
	public unsafe void ReadStringPlus(int VSize, CString outString, int iCount = -1)
	{
		if (VSize <= 0 || this.length <= ((iCount >= 0) ? iCount : this.Offset))
		{
			return;
		}
		int num = 0;
		int num2 = this.Delimiter + ((iCount >= 0) ? iCount : this.Offset);
		fixed (byte* ptr = &this.Data.GetBuffer()[num2])
		{
			while (num < VSize && ptr[num] != 0)
			{
				num++;
			}
		}
		if ((iCount < 0 && this.length - this.Offset >= num) || this.length - iCount >= num)
		{
			fixed (string text = outString.ToString(), ptr2 = text + RuntimeHelpers.OffsetToStringData / 2)
			{
				fixed (byte* bytes = &this.Data.GetBuffer()[num2])
				{
					int charCount = Encoding.UTF8.GetCharCount(this.Data.GetBuffer(), num2, num);
					if (charCount < outString.MaxLength)
					{
						Encoding.UTF8.GetChars(bytes, num, ptr2, charCount);
						outString.Length = charCount;
						ptr2[charCount] = '\0';
					}
				}
			}
		}
		if (iCount < 0)
		{
			this.Offset += VSize;
		}
	}

	// Token: 0x0600256F RID: 9583 RVA: 0x0042B6EC File Offset: 0x004298EC
	public void ReadBlock(byte[] Out, int startIdx, int size, int iCount = -1)
	{
		if (Out != null && Out.Length - startIdx >= size)
		{
			Buffer.BlockCopy(this.Data.GetBuffer(), this.Data.GetIndex((iCount >= 0) ? iCount : this.Offset), Out, startIdx, Math.Min(size, Math.Max(this.Length - ((iCount >= 0) ? iCount : this.Offset), 0)));
		}
		if (iCount < 0)
		{
			this.Offset += size;
		}
	}

	// Token: 0x06002570 RID: 9584 RVA: 0x0042B77C File Offset: 0x0042997C
	public bool Send(bool Force = false)
	{
		if (this.Channel > 0)
		{
			if (NetworkManager.GuestController.Connected() || Force)
			{
				GameConstants.GetBytes((ushort)this.length, this.Data.GetBuffer(), this.Data.GetIndex(0));
				GameConstants.GetBytes((ushort)this.Protocol, this.Data.GetBuffer(), this.Data.GetIndex(2));
				NetworkPeeper.Cipher(this.Data.GetBuffer(), this.Data.GetIndex(4), this.Length - 4, this.MaxSize);
				NetworkPeeper.SendBuff.Enqueue(this);
				return true;
			}
			if (!this.Data.outlaw && this.Data.EOB == NetworkManager.write_pos)
			{
				NetworkManager.write_pos -= this.MaxSize;
			}
			return false;
		}
		else
		{
			if (NetworkManager.Connected() || Force)
			{
				GameConstants.GetBytes((ushort)this.length, this.Data.GetBuffer(), this.Data.GetIndex(0));
				GameConstants.GetBytes((ushort)this.Protocol, this.Data.GetBuffer(), this.Data.GetIndex(2));
				NetworkManager.Cipher(this.Data.GetBuffer(), this.Data.GetIndex(4), this.Length - 4, this.MaxSize);
				NetworkManager.Send(this);
				return true;
			}
			if (!this.Data.outlaw && this.Data.EOB == NetworkManager.write_pos)
			{
				NetworkManager.write_pos -= this.MaxSize;
			}
			return false;
		}
	}

	// Token: 0x06002571 RID: 9585 RVA: 0x0042B91C File Offset: 0x00429B1C
	public static MessagePacket GetGuestMessagePack()
	{
		return new GuestMessagePacket(1);
	}

	// Token: 0x04006FFE RID: 28670
	public int Offset;

	// Token: 0x04006FFF RID: 28671
	private int length;

	// Token: 0x04007000 RID: 28672
	protected byte Channel;

	// Token: 0x04007001 RID: 28673
	private readonly int Delimiter;

	// Token: 0x04007002 RID: 28674
	private readonly int MaxSize;

	// Token: 0x04007003 RID: 28675
	private static int Sequence;

	// Token: 0x04007004 RID: 28676
	public Buffer<byte> Data;

	// Token: 0x04007005 RID: 28677
	public Protocol Protocol;
}
