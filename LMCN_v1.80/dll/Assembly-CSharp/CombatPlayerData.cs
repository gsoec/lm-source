using System;

// Token: 0x02000024 RID: 36
public struct CombatPlayerData
{
	// Token: 0x0400021A RID: 538
	public bool bMain;

	// Token: 0x0400021B RID: 539
	public string Name;

	// Token: 0x0400021C RID: 540
	public string AllianceTag;

	// Token: 0x0400021D RID: 541
	public byte AllianceRank;

	// Token: 0x0400021E RID: 542
	public ushort KingdomID;

	// Token: 0x0400021F RID: 543
	public byte StrongholdLevel;

	// Token: 0x04000220 RID: 544
	public byte Level;

	// Token: 0x04000221 RID: 545
	public ushort Head;

	// Token: 0x04000222 RID: 546
	public byte VIPLevel;

	// Token: 0x04000223 RID: 547
	public HeroDataType[] HeroInfo;

	// Token: 0x04000224 RID: 548
	public ulong LosePower;

	// Token: 0x04000225 RID: 549
	public uint[] SurviveTroop;

	// Token: 0x04000226 RID: 550
	public uint[] DeadTroop;

	// Token: 0x04000227 RID: 551
	public uint[] AttackAttr;

	// Token: 0x04000228 RID: 552
	public uint[] DefenceAttr;

	// Token: 0x04000229 RID: 553
	public uint[] HealthAttr;

	// Token: 0x0400022A RID: 554
	public byte ArmyCoordIndex;
}
