using System;

// Token: 0x02000330 RID: 816
public struct ArenaReportDataType
{
	// Token: 0x04003638 RID: 13880
	public uint SimulatorVersion;

	// Token: 0x04003639 RID: 13881
	public uint SimulatorPatchNo;

	// Token: 0x0400363A RID: 13882
	public byte Flag;

	// Token: 0x0400363B RID: 13883
	public byte[] TopicID;

	// Token: 0x0400363C RID: 13884
	public ArenaTopicEffectDataType[] TopicEffect;

	// Token: 0x0400363D RID: 13885
	public uint ChangePlace;

	// Token: 0x0400363E RID: 13886
	public ArenaHeroDataType[] MyHeroData;

	// Token: 0x0400363F RID: 13887
	public ushort EnemyHead;

	// Token: 0x04003640 RID: 13888
	public string EnemyName;

	// Token: 0x04003641 RID: 13889
	public string EnemyAllianceTag;

	// Token: 0x04003642 RID: 13890
	public ArenaHeroDataType[] EnemyHeroData;

	// Token: 0x04003643 RID: 13891
	public ushort RandomSeed;

	// Token: 0x04003644 RID: 13892
	public byte RandomGap;

	// Token: 0x04003645 RID: 13893
	public byte PrimarySide;

	// Token: 0x04003646 RID: 13894
	public long Time;
}
