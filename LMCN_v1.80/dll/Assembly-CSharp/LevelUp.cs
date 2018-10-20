using System;
using System.Runtime.InteropServices;

// Token: 0x02000088 RID: 136
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LevelUp
{
	// Token: 0x04000762 RID: 1890
	[MarshalAs(UnmanagedType.U2)]
	public ushort LevelUpKey;

	// Token: 0x04000763 RID: 1891
	[MarshalAs(UnmanagedType.U4)]
	public uint KingdomExp;

	// Token: 0x04000764 RID: 1892
	[MarshalAs(UnmanagedType.U4)]
	public uint HeroExp;

	// Token: 0x04000765 RID: 1893
	[MarshalAs(UnmanagedType.U1)]
	public byte Morale;

	// Token: 0x04000766 RID: 1894
	[MarshalAs(UnmanagedType.U4)]
	public uint AddForce;

	// Token: 0x04000767 RID: 1895
	[MarshalAs(UnmanagedType.U1)]
	public byte AddCoin;

	// Token: 0x04000768 RID: 1896
	[MarshalAs(UnmanagedType.U2)]
	public ushort BattleHeroExp;

	// Token: 0x04000769 RID: 1897
	[MarshalAs(UnmanagedType.U2)]
	public ushort BattleHeroLeadExp;

	// Token: 0x0400076A RID: 1898
	[MarshalAs(UnmanagedType.U2)]
	public ushort PrisonEffect;
}
