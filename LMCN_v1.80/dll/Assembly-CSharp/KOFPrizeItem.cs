using System;
using System.Runtime.InteropServices;

// Token: 0x020000BD RID: 189
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct KOFPrizeItem
{
	// Token: 0x040008E5 RID: 2277
	[MarshalAs(UnmanagedType.U1)]
	public byte ItemRank;

	// Token: 0x040008E6 RID: 2278
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemID;

	// Token: 0x040008E7 RID: 2279
	[MarshalAs(UnmanagedType.U1)]
	public byte ItemNum;
}
