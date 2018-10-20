using System;
using System.Runtime.InteropServices;

// Token: 0x02000077 RID: 119
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HeroAttribute
{
	// Token: 0x040006B7 RID: 1719
	[MarshalAs(UnmanagedType.U2)]
	public ushort Strength;

	// Token: 0x040006B8 RID: 1720
	[MarshalAs(UnmanagedType.U2)]
	public ushort Dexterity;

	// Token: 0x040006B9 RID: 1721
	[MarshalAs(UnmanagedType.U2)]
	public ushort Intelligence;
}
