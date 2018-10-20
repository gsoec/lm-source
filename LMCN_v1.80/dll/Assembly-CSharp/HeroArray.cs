using System;
using System.Runtime.InteropServices;

// Token: 0x02000082 RID: 130
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HeroArray
{
	// Token: 0x04000749 RID: 1865
	[MarshalAs(UnmanagedType.U2)]
	public ushort ArrayKey;

	// Token: 0x0400074A RID: 1866
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public HeroArrayAttribute[] HeroArrayInfo;
}
