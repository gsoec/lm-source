using System;
using System.Runtime.InteropServices;

// Token: 0x020000C7 RID: 199
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SyntheticExtend
{
	// Token: 0x04000924 RID: 2340
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemId;

	// Token: 0x04000925 RID: 2341
	[MarshalAs(UnmanagedType.U1)]
	public byte Num;

	// Token: 0x04000926 RID: 2342
	[MarshalAs(UnmanagedType.U1)]
	public byte Color;
}
