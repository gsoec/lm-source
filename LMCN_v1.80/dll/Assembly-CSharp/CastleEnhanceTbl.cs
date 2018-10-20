using System;
using System.Runtime.InteropServices;

// Token: 0x02000343 RID: 835
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CastleEnhanceTbl
{
	// Token: 0x04003759 RID: 14169
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x0400375A RID: 14170
	[MarshalAs(UnmanagedType.U2)]
	public ushort CastleID;

	// Token: 0x0400375B RID: 14171
	[MarshalAs(UnmanagedType.U1)]
	public byte Rank;

	// Token: 0x0400375C RID: 14172
	[MarshalAs(UnmanagedType.U2)]
	public ushort EnhanceTotalNum;

	// Token: 0x0400375D RID: 14173
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public ushort[] Value;

	// Token: 0x0400375E RID: 14174
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
	public ushort[] Reserve;
}
