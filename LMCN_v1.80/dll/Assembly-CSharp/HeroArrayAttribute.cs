using System;
using System.Runtime.InteropServices;

// Token: 0x02000081 RID: 129
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HeroArrayAttribute
{
	// Token: 0x04000747 RID: 1863
	[MarshalAs(UnmanagedType.U2)]
	public ushort posX;

	// Token: 0x04000748 RID: 1864
	[MarshalAs(UnmanagedType.U2)]
	public ushort posY;
}
