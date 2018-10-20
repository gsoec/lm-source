using System;
using System.Runtime.InteropServices;

// Token: 0x02000265 RID: 613
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ShowVector3
{
	// Token: 0x04002668 RID: 9832
	[MarshalAs(UnmanagedType.U2)]
	public ushort ShowVector3ID;

	// Token: 0x04002669 RID: 9833
	[MarshalAs(UnmanagedType.U2)]
	public ushort X;

	// Token: 0x0400266A RID: 9834
	[MarshalAs(UnmanagedType.U2)]
	public ushort Y;

	// Token: 0x0400266B RID: 9835
	[MarshalAs(UnmanagedType.U2)]
	public ushort Z;
}
