using System;
using System.Runtime.InteropServices;

// Token: 0x0200022D RID: 557
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MapMonsterPrice
{
	// Token: 0x0400223D RID: 8765
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x0400223E RID: 8766
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public ushort[] ItemID;

	// Token: 0x0400223F RID: 8767
	[MarshalAs(UnmanagedType.U2)]
	public ushort SpecItemID;
}
