using System;
using System.Runtime.InteropServices;

// Token: 0x0200015E RID: 350
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LordEquipEffectFilterData
{
	// Token: 0x04000DEE RID: 3566
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000DEF RID: 3567
	[MarshalAs(UnmanagedType.U1)]
	public byte effectType;

	// Token: 0x04000DF0 RID: 3568
	[MarshalAs(UnmanagedType.U2)]
	public ushort effectID;
}
