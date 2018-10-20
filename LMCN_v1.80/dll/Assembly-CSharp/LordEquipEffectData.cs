using System;
using System.Runtime.InteropServices;

// Token: 0x020000A2 RID: 162
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LordEquipEffectData
{
	// Token: 0x0400084B RID: 2123
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x0400084C RID: 2124
	[MarshalAs(UnmanagedType.U2)]
	public ushort EffectID;

	// Token: 0x0400084D RID: 2125
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public ushort[] RarePercent;
}
