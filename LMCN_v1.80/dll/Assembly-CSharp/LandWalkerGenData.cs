using System;
using System.Runtime.InteropServices;

// Token: 0x02000160 RID: 352
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LandWalkerGenData
{
	// Token: 0x04000DF5 RID: 3573
	[MarshalAs(UnmanagedType.U1)]
	public byte castleLevel;

	// Token: 0x04000DF6 RID: 3574
	[MarshalAs(UnmanagedType.U1)]
	public byte modelID;

	// Token: 0x04000DF7 RID: 3575
	[MarshalAs(UnmanagedType.U1)]
	public byte isEmemy;

	// Token: 0x04000DF8 RID: 3576
	[MarshalAs(UnmanagedType.U1)]
	public byte GenGap;

	// Token: 0x04000DF9 RID: 3577
	[MarshalAs(UnmanagedType.U1)]
	public byte GenRandom;

	// Token: 0x04000DFA RID: 3578
	[MarshalAs(UnmanagedType.U1)]
	public byte GenLimit;
}
