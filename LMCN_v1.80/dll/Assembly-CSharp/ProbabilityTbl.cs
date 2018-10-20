using System;
using System.Runtime.InteropServices;

// Token: 0x020003D6 RID: 982
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ProbabilityTbl
{
	// Token: 0x04003D12 RID: 15634
	[MarshalAs(UnmanagedType.U2)]
	public ushort QualityID;

	// Token: 0x04003D13 RID: 15635
	[MarshalAs(UnmanagedType.U1)]
	public byte Multiple;
}
