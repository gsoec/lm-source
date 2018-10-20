using System;
using System.Runtime.InteropServices;

// Token: 0x020000BB RID: 187
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MissionItem
{
	// Token: 0x040008DF RID: 2271
	[MarshalAs(UnmanagedType.U1)]
	public byte ItemRank;

	// Token: 0x040008E0 RID: 2272
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemID;

	// Token: 0x040008E1 RID: 2273
	[MarshalAs(UnmanagedType.U1)]
	public byte ItemNum;
}
