using System;
using System.Runtime.InteropServices;

// Token: 0x020004B2 RID: 1202
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CorpsHeroAttribute
{
	// Token: 0x04004787 RID: 18311
	[MarshalAs(UnmanagedType.U2)]
	public ushort HeroID;

	// Token: 0x04004788 RID: 18312
	[MarshalAs(UnmanagedType.U1)]
	public byte Rank;

	// Token: 0x04004789 RID: 18313
	[MarshalAs(UnmanagedType.U1)]
	public byte Star;
}
