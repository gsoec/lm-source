using System;
using System.Runtime.InteropServices;

// Token: 0x020003D3 RID: 979
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AffairCardinalTbl
{
	// Token: 0x04003D07 RID: 15623
	[MarshalAs(UnmanagedType.U2)]
	public ushort RewardID;

	// Token: 0x04003D08 RID: 15624
	[MarshalAs(UnmanagedType.U4)]
	public uint Exp;

	// Token: 0x04003D09 RID: 15625
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public uint[] ResourceCardinal;
}
