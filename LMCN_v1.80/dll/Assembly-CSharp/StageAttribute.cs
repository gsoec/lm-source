using System;
using System.Runtime.InteropServices;

// Token: 0x020004AE RID: 1198
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct StageAttribute
{
	// Token: 0x0400476F RID: 18287
	[MarshalAs(UnmanagedType.U1)]
	public byte Scene;

	// Token: 0x04004770 RID: 18288
	[MarshalAs(UnmanagedType.U1)]
	public byte Face;

	// Token: 0x04004771 RID: 18289
	[MarshalAs(UnmanagedType.U1)]
	public byte Theme;
}
