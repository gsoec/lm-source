using System;
using System.Runtime.InteropServices;

// Token: 0x02000156 RID: 342
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LordEnhanceTbl
{
	// Token: 0x04000DA4 RID: 3492
	[MarshalAs(UnmanagedType.U2)]
	public ushort Index;

	// Token: 0x04000DA5 RID: 3493
	[MarshalAs(UnmanagedType.U1)]
	public byte Type;

	// Token: 0x04000DA6 RID: 3494
	[MarshalAs(UnmanagedType.U2)]
	public ushort Effect1;

	// Token: 0x04000DA7 RID: 3495
	[MarshalAs(UnmanagedType.U2)]
	public ushort Effect2;

	// Token: 0x04000DA8 RID: 3496
	[MarshalAs(UnmanagedType.U1)]
	public byte ValueKind;

	// Token: 0x04000DA9 RID: 3497
	[MarshalAs(UnmanagedType.U1)]
	public byte LordEffect;
}
