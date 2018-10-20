using System;
using System.Runtime.InteropServices;

// Token: 0x020003D7 RID: 983
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ManorAimTbl
{
	// Token: 0x04003D14 RID: 15636
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04003D15 RID: 15637
	[MarshalAs(UnmanagedType.U1)]
	public byte UIKind;

	// Token: 0x04003D16 RID: 15638
	[MarshalAs(UnmanagedType.U2)]
	public ushort UIPriority;

	// Token: 0x04003D17 RID: 15639
	[MarshalAs(UnmanagedType.U2)]
	public ushort Narrative;

	// Token: 0x04003D18 RID: 15640
	[MarshalAs(UnmanagedType.U1)]
	public byte MissionKind;

	// Token: 0x04003D19 RID: 15641
	[MarshalAs(UnmanagedType.U2)]
	public ushort Parm1;

	// Token: 0x04003D1A RID: 15642
	[MarshalAs(UnmanagedType.U4)]
	public uint Parm2;

	// Token: 0x04003D1B RID: 15643
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public _RewardItem[] RewardItems;

	// Token: 0x04003D1C RID: 15644
	[MarshalAs(UnmanagedType.U4)]
	public uint Exp;

	// Token: 0x04003D1D RID: 15645
	[MarshalAs(UnmanagedType.U4)]
	public uint Force;

	// Token: 0x04003D1E RID: 15646
	[MarshalAs(UnmanagedType.U1)]
	public byte RewardMorale;

	// Token: 0x04003D1F RID: 15647
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public uint[] RewardResource;
}
