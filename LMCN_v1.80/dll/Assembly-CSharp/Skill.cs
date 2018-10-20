using System;
using System.Runtime.InteropServices;

// Token: 0x0200007A RID: 122
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Skill
{
	// Token: 0x040006EE RID: 1774
	[MarshalAs(UnmanagedType.U2)]
	public ushort SkillKey;

	// Token: 0x040006EF RID: 1775
	[MarshalAs(UnmanagedType.U2)]
	public ushort SkillName;

	// Token: 0x040006F0 RID: 1776
	[MarshalAs(UnmanagedType.U2)]
	public ushort SkillIcon;

	// Token: 0x040006F1 RID: 1777
	[MarshalAs(UnmanagedType.U2)]
	public ushort Describe;

	// Token: 0x040006F2 RID: 1778
	[MarshalAs(UnmanagedType.U2)]
	public ushort ValueInfo;

	// Token: 0x040006F3 RID: 1779
	[MarshalAs(UnmanagedType.U1)]
	public byte SkillType;

	// Token: 0x040006F4 RID: 1780
	[MarshalAs(UnmanagedType.U1)]
	public byte SkillKind;

	// Token: 0x040006F5 RID: 1781
	[MarshalAs(UnmanagedType.U2)]
	public ushort CoolDown;

	// Token: 0x040006F6 RID: 1782
	[MarshalAs(UnmanagedType.U1)]
	public byte InFightingCD;

	// Token: 0x040006F7 RID: 1783
	[MarshalAs(UnmanagedType.U2)]
	public ushort SkillDistance;

	// Token: 0x040006F8 RID: 1784
	[MarshalAs(UnmanagedType.U1)]
	public byte HurtKind;

	// Token: 0x040006F9 RID: 1785
	[MarshalAs(UnmanagedType.U2)]
	public ushort HurtAddition;

	// Token: 0x040006FA RID: 1786
	[MarshalAs(UnmanagedType.U2)]
	public ushort HurtValue;

	// Token: 0x040006FB RID: 1787
	[MarshalAs(UnmanagedType.U2)]
	public ushort HurtIncreaseValue;

	// Token: 0x040006FC RID: 1788
	[MarshalAs(UnmanagedType.U2)]
	public ushort Rangeparameter1;

	// Token: 0x040006FD RID: 1789
	[MarshalAs(UnmanagedType.U2)]
	public ushort Rangeparameter2;

	// Token: 0x040006FE RID: 1790
	[MarshalAs(UnmanagedType.U2)]
	public ushort TargetState;

	// Token: 0x040006FF RID: 1791
	[MarshalAs(UnmanagedType.U2)]
	public ushort SelfState;

	// Token: 0x04000700 RID: 1792
	[MarshalAs(UnmanagedType.U2)]
	public ushort StateAddition;

	// Token: 0x04000701 RID: 1793
	[MarshalAs(UnmanagedType.U2)]
	public ushort StateValue;

	// Token: 0x04000702 RID: 1794
	[MarshalAs(UnmanagedType.U2)]
	public ushort StateIncreaseValue;

	// Token: 0x04000703 RID: 1795
	[MarshalAs(UnmanagedType.U2)]
	public ushort PreFireParticle;

	// Token: 0x04000704 RID: 1796
	[MarshalAs(UnmanagedType.U1)]
	public byte PreFireParticlePos;

	// Token: 0x04000705 RID: 1797
	[MarshalAs(UnmanagedType.U2)]
	public ushort FireParticle;

	// Token: 0x04000706 RID: 1798
	[MarshalAs(UnmanagedType.U1)]
	public byte FireParticlePos;

	// Token: 0x04000707 RID: 1799
	[MarshalAs(UnmanagedType.U2)]
	public ushort FireVocalDelay;

	// Token: 0x04000708 RID: 1800
	[MarshalAs(UnmanagedType.U2)]
	public ushort FireVocal;

	// Token: 0x04000709 RID: 1801
	[MarshalAs(UnmanagedType.U2)]
	public ushort FireSoundDelay;

	// Token: 0x0400070A RID: 1802
	[MarshalAs(UnmanagedType.U2)]
	public ushort FireSound;

	// Token: 0x0400070B RID: 1803
	[MarshalAs(UnmanagedType.U2)]
	public ushort UltraHitSound;

	// Token: 0x0400070C RID: 1804
	[MarshalAs(UnmanagedType.U2)]
	public ushort HitParticle;

	// Token: 0x0400070D RID: 1805
	[MarshalAs(UnmanagedType.U1)]
	public byte HitParticlePos;

	// Token: 0x0400070E RID: 1806
	[MarshalAs(UnmanagedType.U2)]
	public ushort RangeHitParticle;

	// Token: 0x0400070F RID: 1807
	[MarshalAs(UnmanagedType.U2)]
	public ushort HitSound;

	// Token: 0x04000710 RID: 1808
	[MarshalAs(UnmanagedType.U2)]
	public ushort UltraParticle;

	// Token: 0x04000711 RID: 1809
	[MarshalAs(UnmanagedType.U1)]
	public byte UltraParticlePos;

	// Token: 0x04000712 RID: 1810
	[MarshalAs(UnmanagedType.U2)]
	public ushort UltraSound;

	// Token: 0x04000713 RID: 1811
	[MarshalAs(UnmanagedType.U1)]
	public byte FlyTarget;

	// Token: 0x04000714 RID: 1812
	[MarshalAs(UnmanagedType.U1)]
	public byte FlyType;

	// Token: 0x04000715 RID: 1813
	[MarshalAs(UnmanagedType.U2)]
	public ushort FlyParticle;

	// Token: 0x04000716 RID: 1814
	[MarshalAs(UnmanagedType.U2)]
	public ushort FlySound;

	// Token: 0x04000717 RID: 1815
	[MarshalAs(UnmanagedType.U2)]
	public ushort FlyRate;

	// Token: 0x04000718 RID: 1816
	[MarshalAs(UnmanagedType.U1)]
	public byte IsShake;

	// Token: 0x04000719 RID: 1817
	[MarshalAs(UnmanagedType.U1)]
	public byte WorkingAI;

	// Token: 0x0400071A RID: 1818
	[MarshalAs(UnmanagedType.U2)]
	public ushort RecvEnergy;
}
