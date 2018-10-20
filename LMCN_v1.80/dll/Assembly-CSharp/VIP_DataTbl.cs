using System;
using System.Runtime.InteropServices;

// Token: 0x0200015A RID: 346
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct VIP_DataTbl
{
	// Token: 0x04000DB1 RID: 3505
	[MarshalAs(UnmanagedType.U2)]
	public ushort VIPLevel;

	// Token: 0x04000DB2 RID: 3506
	[MarshalAs(UnmanagedType.U4)]
	public uint VIPPoint;

	// Token: 0x04000DB3 RID: 3507
	[MarshalAs(UnmanagedType.U2)]
	public ushort loginPoint;

	// Token: 0x04000DB4 RID: 3508
	[MarshalAs(UnmanagedType.U2)]
	public ushort dailyAdd;

	// Token: 0x04000DB5 RID: 3509
	[MarshalAs(UnmanagedType.U1)]
	public byte QuickCompleteMin;

	// Token: 0x04000DB6 RID: 3510
	[MarshalAs(UnmanagedType.U1)]
	public byte moraleBanner;

	// Token: 0x04000DB7 RID: 3511
	[MarshalAs(UnmanagedType.U1)]
	public byte DailyResetElite;

	// Token: 0x04000DB8 RID: 3512
	[MarshalAs(UnmanagedType.U1)]
	public byte SkillPointMax;

	// Token: 0x04000DB9 RID: 3513
	[MarshalAs(UnmanagedType.U1)]
	public byte UnlockBuySkill;

	// Token: 0x04000DBA RID: 3514
	[MarshalAs(UnmanagedType.U1)]
	public byte AutoDailyMission;

	// Token: 0x04000DBB RID: 3515
	[MarshalAs(UnmanagedType.U1)]
	public byte AutoDailyAlliMission;

	// Token: 0x04000DBC RID: 3516
	[MarshalAs(UnmanagedType.U1)]
	public byte AutoFightMission;

	// Token: 0x04000DBD RID: 3517
	[MarshalAs(UnmanagedType.U1)]
	public byte VipMission;

	// Token: 0x04000DBE RID: 3518
	[MarshalAs(UnmanagedType.U1)]
	public byte DailyMission;

	// Token: 0x04000DBF RID: 3519
	[MarshalAs(UnmanagedType.U1)]
	public byte AlliMission;

	// Token: 0x04000DC0 RID: 3520
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
	public ushort[] Effects;
}
