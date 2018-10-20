using System;
using System.Runtime.InteropServices;

// Token: 0x0200009C RID: 156
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TalentLevelTbl
{
	// Token: 0x04000826 RID: 2086
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000827 RID: 2087
	[MarshalAs(UnmanagedType.U2)]
	public ushort TalentID;

	// Token: 0x04000828 RID: 2088
	[MarshalAs(UnmanagedType.U1)]
	public byte Level;

	// Token: 0x04000829 RID: 2089
	[MarshalAs(UnmanagedType.U1)]
	public byte NeedPoint;

	// Token: 0x0400082A RID: 2090
	[MarshalAs(UnmanagedType.U2)]
	public ushort Effect;

	// Token: 0x0400082B RID: 2091
	[MarshalAs(UnmanagedType.U2)]
	public ushort EffectVal;
}
