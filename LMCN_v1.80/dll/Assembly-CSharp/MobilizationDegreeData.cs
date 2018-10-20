using System;
using System.Runtime.InteropServices;

// Token: 0x020000BC RID: 188
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MobilizationDegreeData
{
	// Token: 0x040008E2 RID: 2274
	[MarshalAs(UnmanagedType.U2)]
	public ushort MissionDegreeKey;

	// Token: 0x040008E3 RID: 2275
	[MarshalAs(UnmanagedType.U4)]
	public uint MissionDegreeScore;

	// Token: 0x040008E4 RID: 2276
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public MissionItem[] MissionItemData;
}
