using System;
using System.Runtime.InteropServices;

// Token: 0x02000091 RID: 145
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct StoreTbl
{
	// Token: 0x040007C1 RID: 1985
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040007C2 RID: 1986
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemID;

	// Token: 0x040007C3 RID: 1987
	[MarshalAs(UnmanagedType.U2)]
	public ushort Num;

	// Token: 0x040007C4 RID: 1988
	[MarshalAs(UnmanagedType.U1)]
	public byte Filter;

	// Token: 0x040007C5 RID: 1989
	[MarshalAs(UnmanagedType.U4)]
	public uint Price;

	// Token: 0x040007C6 RID: 1990
	[MarshalAs(UnmanagedType.U4)]
	public uint AlliancePoint;

	// Token: 0x040007C7 RID: 1991
	[MarshalAs(UnmanagedType.U1)]
	public byte AddDiamondBuy;

	// Token: 0x040007C8 RID: 1992
	[MarshalAs(UnmanagedType.U1)]
	public byte AddAllianceBuy;
}
