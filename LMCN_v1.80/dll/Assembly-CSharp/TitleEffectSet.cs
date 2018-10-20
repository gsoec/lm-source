using System;
using System.Runtime.InteropServices;

// Token: 0x020000B7 RID: 183
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TitleEffectSet
{
	// Token: 0x040008CD RID: 2253
	[MarshalAs(UnmanagedType.U2)]
	public ushort EffectID;

	// Token: 0x040008CE RID: 2254
	[MarshalAs(UnmanagedType.U2)]
	public ushort Value;
}
