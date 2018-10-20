using System;
using System.Runtime.InteropServices;

// Token: 0x020004AD RID: 1197
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct WordVector3
{
	// Token: 0x0400476C RID: 18284
	[MarshalAs(UnmanagedType.U2)]
	public ushort X;

	// Token: 0x0400476D RID: 18285
	[MarshalAs(UnmanagedType.U2)]
	public ushort Y;

	// Token: 0x0400476E RID: 18286
	[MarshalAs(UnmanagedType.U2)]
	public ushort Z;
}
