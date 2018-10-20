using System;
using System.Runtime.InteropServices;

// Token: 0x020003D5 RID: 981
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AllianceCardinalTbl
{
	// Token: 0x04003D0E RID: 15630
	[MarshalAs(UnmanagedType.U2)]
	public ushort RewardID;

	// Token: 0x04003D0F RID: 15631
	[MarshalAs(UnmanagedType.U4)]
	public uint Exp;

	// Token: 0x04003D10 RID: 15632
	[MarshalAs(UnmanagedType.U2)]
	public ushort AllianceMoney;

	// Token: 0x04003D11 RID: 15633
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public uint[] ResourceCardinal;
}
