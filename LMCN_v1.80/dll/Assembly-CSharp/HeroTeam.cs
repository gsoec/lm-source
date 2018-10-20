using System;
using System.Runtime.InteropServices;

// Token: 0x02000084 RID: 132
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HeroTeam
{
	// Token: 0x0400074D RID: 1869
	[MarshalAs(UnmanagedType.U2)]
	public ushort TeamKey;

	// Token: 0x0400074E RID: 1870
	[MarshalAs(UnmanagedType.U2)]
	public ushort ArrayID;

	// Token: 0x0400074F RID: 1871
	[MarshalAs(UnmanagedType.U1)]
	public byte HeroLevel;

	// Token: 0x04000750 RID: 1872
	[MarshalAs(UnmanagedType.U1)]
	public byte HeroClass;

	// Token: 0x04000751 RID: 1873
	[MarshalAs(UnmanagedType.U1)]
	public byte HeroStar;

	// Token: 0x04000752 RID: 1874
	[MarshalAs(UnmanagedType.U2)]
	public ushort ShiftX;

	// Token: 0x04000753 RID: 1875
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public HeroTeamAttribute[] Arrays;

	// Token: 0x04000754 RID: 1876
	[MarshalAs(UnmanagedType.U1)]
	public byte SupportType;

	// Token: 0x04000755 RID: 1877
	[MarshalAs(UnmanagedType.U1)]
	public byte SupportValue;
}
