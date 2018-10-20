using System;
using System.Runtime.InteropServices;

// Token: 0x020000A8 RID: 168
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct GiftBox
{
	// Token: 0x0400085C RID: 2140
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x0400085D RID: 2141
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
	public GiftBoxItem[] ItemData;
}
