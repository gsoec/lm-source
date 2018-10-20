using System;
using System.Runtime.InteropServices;

// Token: 0x020003C8 RID: 968
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct FBMissionTbl
{
	// Token: 0x04003CC4 RID: 15556
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04003CC5 RID: 15557
	[MarshalAs(UnmanagedType.U2)]
	public ushort Name;

	// Token: 0x04003CC6 RID: 15558
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public _FBMissionCont[] MissionItems;

	// Token: 0x04003CC7 RID: 15559
	[MarshalAs(UnmanagedType.U2)]
	public ushort OwnPrice;

	// Token: 0x04003CC8 RID: 15560
	[MarshalAs(UnmanagedType.U2)]
	public ushort FriendPrice;

	// Token: 0x04003CC9 RID: 15561
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public ushort[] OwnProcressDescribe;

	// Token: 0x04003CCA RID: 15562
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public ushort[] Preserve;
}
