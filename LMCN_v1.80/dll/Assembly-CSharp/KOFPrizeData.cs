using System;
using System.Runtime.InteropServices;

// Token: 0x020000BE RID: 190
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct KOFPrizeData
{
	// Token: 0x040008E8 RID: 2280
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040008E9 RID: 2281
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public KOFPrizeItem[] PrizeItem;
}
