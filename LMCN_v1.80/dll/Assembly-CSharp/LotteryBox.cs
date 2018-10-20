using System;
using System.Runtime.InteropServices;

// Token: 0x020000A6 RID: 166
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LotteryBox
{
	// Token: 0x04000856 RID: 2134
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000857 RID: 2135
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	public LotteryBoxItem[] ItemData;

	// Token: 0x04000858 RID: 2136
	[MarshalAs(UnmanagedType.U2)]
	public ushort SetIndex;
}
