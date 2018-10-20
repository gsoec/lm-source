using System;
using System.Runtime.InteropServices;

// Token: 0x020000A0 RID: 160
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CastleUpgradeRewardTbl
{
	// Token: 0x04000836 RID: 2102
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000837 RID: 2103
	[MarshalAs(UnmanagedType.U2)]
	public ushort UnlockBuilding;

	// Token: 0x04000838 RID: 2104
	[MarshalAs(UnmanagedType.U4)]
	public uint Grain;

	// Token: 0x04000839 RID: 2105
	[MarshalAs(UnmanagedType.U4)]
	public uint Rock;

	// Token: 0x0400083A RID: 2106
	[MarshalAs(UnmanagedType.U4)]
	public uint Wood;

	// Token: 0x0400083B RID: 2107
	[MarshalAs(UnmanagedType.U4)]
	public uint Iron;

	// Token: 0x0400083C RID: 2108
	[MarshalAs(UnmanagedType.U4)]
	public uint Gold;

	// Token: 0x0400083D RID: 2109
	[MarshalAs(UnmanagedType.U2)]
	public ushort Item1;

	// Token: 0x0400083E RID: 2110
	[MarshalAs(UnmanagedType.U1)]
	public byte Item1Count;

	// Token: 0x0400083F RID: 2111
	[MarshalAs(UnmanagedType.U2)]
	public ushort Item2;

	// Token: 0x04000840 RID: 2112
	[MarshalAs(UnmanagedType.U1)]
	public byte Item2Count;

	// Token: 0x04000841 RID: 2113
	[MarshalAs(UnmanagedType.U2)]
	public ushort Item3;

	// Token: 0x04000842 RID: 2114
	[MarshalAs(UnmanagedType.U1)]
	public byte Item3Count;

	// Token: 0x04000843 RID: 2115
	[MarshalAs(UnmanagedType.U2)]
	public ushort Item4;

	// Token: 0x04000844 RID: 2116
	[MarshalAs(UnmanagedType.U1)]
	public byte Item4Count;
}
