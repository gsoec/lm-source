using System;

// Token: 0x0200032F RID: 815
public struct ArenaHeroDataType
{
	// Token: 0x06001096 RID: 4246 RVA: 0x001D7538 File Offset: 0x001D5738
	public static implicit operator HeroBattleData(ArenaHeroDataType ah)
	{
		return new HeroBattleData(ah);
	}

	// Token: 0x04003632 RID: 13874
	public ushort ID;

	// Token: 0x04003633 RID: 13875
	public byte Level;

	// Token: 0x04003634 RID: 13876
	public byte Rank;

	// Token: 0x04003635 RID: 13877
	public byte Star;

	// Token: 0x04003636 RID: 13878
	public byte Equip;

	// Token: 0x04003637 RID: 13879
	public byte[] SkillLV;
}
