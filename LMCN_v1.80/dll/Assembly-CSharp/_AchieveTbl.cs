using System;
using System.Runtime.InteropServices;

// Token: 0x020003D9 RID: 985
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct _AchieveTbl
{
	// Token: 0x04003D22 RID: 15650
	[MarshalAs(UnmanagedType.U2)]
	public ushort AchievementID;

	// Token: 0x04003D23 RID: 15651
	[MarshalAs(UnmanagedType.U2)]
	public ushort MissionID;

	// Token: 0x04003D24 RID: 15652
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
	public char[] AchievementName;
}
