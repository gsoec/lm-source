using System;
using System.Runtime.InteropServices;

// Token: 0x020004B6 RID: 1206
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct StageCondition
{
	// Token: 0x040047A4 RID: 18340
	[MarshalAs(UnmanagedType.U1)]
	public byte ConditionID;

	// Token: 0x040047A5 RID: 18341
	[MarshalAs(UnmanagedType.U2)]
	public ushort FactorA;

	// Token: 0x040047A6 RID: 18342
	[MarshalAs(UnmanagedType.U2)]
	public ushort FactorB;
}
