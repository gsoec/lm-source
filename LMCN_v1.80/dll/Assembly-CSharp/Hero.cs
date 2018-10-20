using System;
using System.Runtime.InteropServices;

// Token: 0x02000079 RID: 121
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Hero
{
	// Token: 0x040006BD RID: 1725
	[MarshalAs(UnmanagedType.U2)]
	public ushort HeroKey;

	// Token: 0x040006BE RID: 1726
	[MarshalAs(UnmanagedType.U2)]
	public ushort HeroTitle;

	// Token: 0x040006BF RID: 1727
	[MarshalAs(UnmanagedType.U2)]
	public ushort HeroName;

	// Token: 0x040006C0 RID: 1728
	[MarshalAs(UnmanagedType.U1)]
	public byte defaultStar;

	// Token: 0x040006C1 RID: 1729
	[MarshalAs(UnmanagedType.U1)]
	public byte HeroType;

	// Token: 0x040006C2 RID: 1730
	[MarshalAs(UnmanagedType.U2)]
	public ushort Description;

	// Token: 0x040006C3 RID: 1731
	[MarshalAs(UnmanagedType.U2)]
	public ushort Summary;

	// Token: 0x040006C4 RID: 1732
	[MarshalAs(UnmanagedType.U2)]
	public ushort Graph;

	// Token: 0x040006C5 RID: 1733
	[MarshalAs(UnmanagedType.U2)]
	public ushort Modle;

	// Token: 0x040006C6 RID: 1734
	[MarshalAs(UnmanagedType.U2)]
	public ushort Pos;

	// Token: 0x040006C7 RID: 1735
	[MarshalAs(UnmanagedType.U2)]
	public ushort Radius;

	// Token: 0x040006C8 RID: 1736
	[MarshalAs(UnmanagedType.U2)]
	public ushort Height;

	// Token: 0x040006C9 RID: 1737
	[MarshalAs(UnmanagedType.U2)]
	public ushort AI;

	// Token: 0x040006CA RID: 1738
	[MarshalAs(UnmanagedType.Struct)]
	public HeroAttribute DefaultAtt;

	// Token: 0x040006CB RID: 1739
	[MarshalAs(UnmanagedType.U2)]
	public ushort MaxHealth;

	// Token: 0x040006CC RID: 1740
	[MarshalAs(UnmanagedType.U2)]
	public ushort AttackDamage;

	// Token: 0x040006CD RID: 1741
	[MarshalAs(UnmanagedType.U2)]
	public ushort AbilityPower;

	// Token: 0x040006CE RID: 1742
	[MarshalAs(UnmanagedType.U2)]
	public ushort Armor;

	// Token: 0x040006CF RID: 1743
	[MarshalAs(UnmanagedType.U2)]
	public ushort MagicResist;

	// Token: 0x040006D0 RID: 1744
	[MarshalAs(UnmanagedType.U2)]
	public ushort PhysiclaCrit;

	// Token: 0x040006D1 RID: 1745
	[MarshalAs(UnmanagedType.U2)]
	public ushort SpellCrit;

	// Token: 0x040006D2 RID: 1746
	[MarshalAs(UnmanagedType.Struct)]
	public HeroAttribute StarUp;

	// Token: 0x040006D3 RID: 1747
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public ushort[] AttackPower;

	// Token: 0x040006D4 RID: 1748
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public HeroAttack[] HeroAttackInfo;

	// Token: 0x040006D5 RID: 1749
	[MarshalAs(UnmanagedType.U2)]
	public ushort SoulStone;

	// Token: 0x040006D6 RID: 1750
	[MarshalAs(UnmanagedType.U1)]
	public byte SoldierKind;

	// Token: 0x040006D7 RID: 1751
	[MarshalAs(UnmanagedType.U2)]
	public ushort GroupSkill1;

	// Token: 0x040006D8 RID: 1752
	[MarshalAs(UnmanagedType.U2)]
	public ushort GroupSkill2;

	// Token: 0x040006D9 RID: 1753
	[MarshalAs(UnmanagedType.U2)]
	public ushort GroupSkill3;

	// Token: 0x040006DA RID: 1754
	[MarshalAs(UnmanagedType.U2)]
	public ushort GroupSkill4;

	// Token: 0x040006DB RID: 1755
	[MarshalAs(UnmanagedType.U1)]
	public byte TextureNo;

	// Token: 0x040006DC RID: 1756
	[MarshalAs(UnmanagedType.U2)]
	public ushort Scale;

	// Token: 0x040006DD RID: 1757
	[MarshalAs(UnmanagedType.U2)]
	public ushort HurtSound;

	// Token: 0x040006DE RID: 1758
	[MarshalAs(UnmanagedType.U2)]
	public ushort DyingSound;

	// Token: 0x040006DF RID: 1759
	[MarshalAs(UnmanagedType.U1)]
	public byte bShowHeroStone;

	// Token: 0x040006E0 RID: 1760
	[MarshalAs(UnmanagedType.U2)]
	public ushort CameraDistance;

	// Token: 0x040006E1 RID: 1761
	[MarshalAs(UnmanagedType.U2)]
	public ushort CameraScaleRate;

	// Token: 0x040006E2 RID: 1762
	[MarshalAs(UnmanagedType.U2)]
	public ushort EnergyAfterKill;

	// Token: 0x040006E3 RID: 1763
	[MarshalAs(UnmanagedType.U2)]
	public ushort CameraScaleRate_C;

	// Token: 0x040006E4 RID: 1764
	[MarshalAs(UnmanagedType.U2)]
	public ushort Camera_Horizontal;

	// Token: 0x040006E5 RID: 1765
	[MarshalAs(UnmanagedType.U2)]
	public ushort Camera_Angle_Prison;

	// Token: 0x040006E6 RID: 1766
	[MarshalAs(UnmanagedType.U2)]
	public ushort EquipEX;

	// Token: 0x040006E7 RID: 1767
	[MarshalAs(UnmanagedType.U1)]
	public byte SupportShowType;

	// Token: 0x040006E8 RID: 1768
	[MarshalAs(UnmanagedType.U2)]
	public ushort CameraYAxis_Prison;

	// Token: 0x040006E9 RID: 1769
	[MarshalAs(UnmanagedType.U2)]
	public ushort CameraXAxis_Prison;

	// Token: 0x040006EA RID: 1770
	[MarshalAs(UnmanagedType.U2)]
	public ushort HitParticleScaleRate;

	// Token: 0x040006EB RID: 1771
	[MarshalAs(UnmanagedType.U2)]
	public ushort ResidentEffect;

	// Token: 0x040006EC RID: 1772
	[MarshalAs(UnmanagedType.U2)]
	public ushort ParticlePackNo;

	// Token: 0x040006ED RID: 1773
	[MarshalAs(UnmanagedType.U2)]
	public ushort AudioPackNo;
}
