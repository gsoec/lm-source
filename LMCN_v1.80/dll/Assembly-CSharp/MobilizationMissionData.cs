using System;
using System.Runtime.InteropServices;

// Token: 0x020000BA RID: 186
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MobilizationMissionData
{
	// Token: 0x040008D7 RID: 2263
	[MarshalAs(UnmanagedType.U2)]
	public ushort MissionKey;

	// Token: 0x040008D8 RID: 2264
	[MarshalAs(UnmanagedType.U2)]
	public ushort MissionType;

	// Token: 0x040008D9 RID: 2265
	[MarshalAs(UnmanagedType.U2)]
	public ushort MissionInfo;

	// Token: 0x040008DA RID: 2266
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public uint[] MissionMaxValue;

	// Token: 0x040008DB RID: 2267
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public ushort[] MissionScore;

	// Token: 0x040008DC RID: 2268
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public ushort[] MissionTime;

	// Token: 0x040008DD RID: 2269
	[MarshalAs(UnmanagedType.U1)]
	public byte MissionIcon;

	// Token: 0x040008DE RID: 2270
	[MarshalAs(UnmanagedType.U1)]
	public byte MissionIcon2;
}
