using System;
using System.Runtime.InteropServices;

// Token: 0x0200023A RID: 570
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct WondersEffect
{
	// Token: 0x0400229F RID: 8863
	[MarshalAs(UnmanagedType.U2)]
	public ushort Effect;

	// Token: 0x040022A0 RID: 8864
	[MarshalAs(UnmanagedType.U2)]
	public ushort Value;

	// Token: 0x040022A1 RID: 8865
	[MarshalAs(UnmanagedType.U1)]
	public byte Icon;
}
