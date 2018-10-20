using System;
using System.Runtime.InteropServices;

// Token: 0x020000C3 RID: 195
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct DegreeRange
{
	// Token: 0x04000907 RID: 2311
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000908 RID: 2312
	[MarshalAs(UnmanagedType.U1)]
	public byte Range;
}
