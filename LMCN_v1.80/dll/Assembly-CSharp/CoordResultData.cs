using System;
using System.Runtime.InteropServices;

// Token: 0x020000B6 RID: 182
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CoordResultData
{
	// Token: 0x040008CA RID: 2250
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040008CB RID: 2251
	[MarshalAs(UnmanagedType.U4)]
	public uint Left_TotalLose;

	// Token: 0x040008CC RID: 2252
	[MarshalAs(UnmanagedType.U4)]
	public uint Right_TotalLose;
}
