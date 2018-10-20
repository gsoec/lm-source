using System;
using System.Runtime.InteropServices;

// Token: 0x020000C6 RID: 198
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AllianceMobilizationGoldMission
{
	// Token: 0x04000917 RID: 2327
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000918 RID: 2328
	[MarshalAs(UnmanagedType.U2)]
	public ushort missionKind;

	// Token: 0x04000919 RID: 2329
	[MarshalAs(UnmanagedType.U2)]
	public ushort info;

	// Token: 0x0400091A RID: 2330
	[MarshalAs(UnmanagedType.U4)]
	public uint par1;

	// Token: 0x0400091B RID: 2331
	[MarshalAs(UnmanagedType.U4)]
	public uint par2;

	// Token: 0x0400091C RID: 2332
	[MarshalAs(UnmanagedType.U4)]
	public uint par3;

	// Token: 0x0400091D RID: 2333
	[MarshalAs(UnmanagedType.U2)]
	public ushort rewardPoint;

	// Token: 0x0400091E RID: 2334
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public ushort[] parKind;

	// Token: 0x0400091F RID: 2335
	[MarshalAs(UnmanagedType.U1)]
	public byte pic_Main;

	// Token: 0x04000920 RID: 2336
	[MarshalAs(UnmanagedType.U1)]
	public byte pic_Index;

	// Token: 0x04000921 RID: 2337
	[MarshalAs(UnmanagedType.U2)]
	public ushort res1;

	// Token: 0x04000922 RID: 2338
	[MarshalAs(UnmanagedType.U2)]
	public ushort res2;

	// Token: 0x04000923 RID: 2339
	[MarshalAs(UnmanagedType.U2)]
	public ushort res3;
}
