using System;
using System.Runtime.InteropServices;

// Token: 0x020000AD RID: 173
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SummonInfo
{
	// Token: 0x04000871 RID: 2161
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000872 RID: 2162
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public SummonPoint[] PointData;

	// Token: 0x04000873 RID: 2163
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public byte[] FactorKey;
}
