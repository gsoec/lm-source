using System;
using System.Runtime.InteropServices;

// Token: 0x020000A7 RID: 167
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct GiftBoxItem
{
	// Token: 0x04000859 RID: 2137
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemID;

	// Token: 0x0400085A RID: 2138
	[MarshalAs(UnmanagedType.U1)]
	public byte Rank;

	// Token: 0x0400085B RID: 2139
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemCount;
}
