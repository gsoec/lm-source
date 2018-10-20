using System;
using System.Runtime.InteropServices;

// Token: 0x02000086 RID: 134
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CurHeroData
{
	// Token: 0x04000758 RID: 1880
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000759 RID: 1881
	[MarshalAs(UnmanagedType.U1)]
	public byte Level;

	// Token: 0x0400075A RID: 1882
	[MarshalAs(UnmanagedType.U4)]
	public uint Exp;

	// Token: 0x0400075B RID: 1883
	[MarshalAs(UnmanagedType.U1)]
	public byte Enhance;

	// Token: 0x0400075C RID: 1884
	[MarshalAs(UnmanagedType.U1)]
	public byte Star;

	// Token: 0x0400075D RID: 1885
	[MarshalAs(UnmanagedType.U1)]
	public byte Equip;

	// Token: 0x0400075E RID: 1886
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public byte[] EquipEnchant;

	// Token: 0x0400075F RID: 1887
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] SkillLV;
}
