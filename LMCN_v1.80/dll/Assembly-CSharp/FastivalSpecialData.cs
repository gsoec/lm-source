using System;
using System.Runtime.InteropServices;

// Token: 0x020000C0 RID: 192
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct FastivalSpecialData
{
	// Token: 0x040008EE RID: 2286
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040008EF RID: 2287
	[MarshalAs(UnmanagedType.U1)]
	public byte GroupID;

	// Token: 0x040008F0 RID: 2288
	[MarshalAs(UnmanagedType.U4)]
	public uint StoreID;

	// Token: 0x040008F1 RID: 2289
	[MarshalAs(UnmanagedType.U1)]
	public byte PickupCount;

	// Token: 0x040008F2 RID: 2290
	[MarshalAs(UnmanagedType.U1)]
	public byte PackNo;

	// Token: 0x040008F3 RID: 2291
	[MarshalAs(UnmanagedType.U2)]
	public ushort FrameColor;

	// Token: 0x040008F4 RID: 2292
	[MarshalAs(UnmanagedType.U2)]
	public ushort PicNo;

	// Token: 0x040008F5 RID: 2293
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemName;

	// Token: 0x040008F6 RID: 2294
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemHint;

	// Token: 0x040008F7 RID: 2295
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemID;

	// Token: 0x040008F8 RID: 2296
	[MarshalAs(UnmanagedType.U2)]
	public ushort AlliGiveBoardCast;

	// Token: 0x040008F9 RID: 2297
	[MarshalAs(UnmanagedType.U2)]
	public ushort AlliGetBoardCast;

	// Token: 0x040008FA RID: 2298
	[MarshalAs(UnmanagedType.U4)]
	public uint UB1;

	// Token: 0x040008FB RID: 2299
	[MarshalAs(UnmanagedType.U4)]
	public uint UB2;
}
