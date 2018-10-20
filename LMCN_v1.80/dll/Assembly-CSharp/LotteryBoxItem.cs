using System;
using System.Runtime.InteropServices;

// Token: 0x020000A5 RID: 165
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LotteryBoxItem
{
	// Token: 0x04000854 RID: 2132
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemID;

	// Token: 0x04000855 RID: 2133
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemCount;
}
