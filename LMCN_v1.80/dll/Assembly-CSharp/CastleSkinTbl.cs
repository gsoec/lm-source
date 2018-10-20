using System;
using System.Runtime.InteropServices;

// Token: 0x02000342 RID: 834
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CastleSkinTbl
{
	// Token: 0x0400374B RID: 14155
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x0400374C RID: 14156
	[MarshalAs(UnmanagedType.U2)]
	public ushort Name;

	// Token: 0x0400374D RID: 14157
	[MarshalAs(UnmanagedType.U1)]
	public byte Graphic;

	// Token: 0x0400374E RID: 14158
	[MarshalAs(UnmanagedType.U1)]
	public byte Priority;

	// Token: 0x0400374F RID: 14159
	[MarshalAs(UnmanagedType.U1)]
	public byte PreViewPercentage;

	// Token: 0x04003750 RID: 14160
	[MarshalAs(UnmanagedType.U1)]
	public byte UnlockPercentage;

	// Token: 0x04003751 RID: 14161
	[MarshalAs(UnmanagedType.U1)]
	public byte EnhancePercentage;

	// Token: 0x04003752 RID: 14162
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public ushort[] Effect;

	// Token: 0x04003753 RID: 14163
	[MarshalAs(UnmanagedType.U4)]
	public uint ItemID;

	// Token: 0x04003754 RID: 14164
	[MarshalAs(UnmanagedType.U2)]
	public ushort GiftID;

	// Token: 0x04003755 RID: 14165
	[MarshalAs(UnmanagedType.U1)]
	public byte GiftNum;

	// Token: 0x04003756 RID: 14166
	[MarshalAs(UnmanagedType.U1)]
	public byte DefaultExclamation;

	// Token: 0x04003757 RID: 14167
	[MarshalAs(UnmanagedType.U1)]
	public byte byteReserve;

	// Token: 0x04003758 RID: 14168
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public ushort[] Reserve;
}
