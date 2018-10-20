using System;

// Token: 0x02000019 RID: 25
public struct NobilityGroupDataType
{
	// Token: 0x040000F1 RID: 241
	public ushort KingdomID;

	// Token: 0x040000F2 RID: 242
	public byte WonderID;

	// Token: 0x040000F3 RID: 243
	public EActivityState EventState;

	// Token: 0x040000F4 RID: 244
	public long EventBeginTime;

	// Token: 0x040000F5 RID: 245
	public uint EventRequireTime;

	// Token: 0x040000F6 RID: 246
	public long EventCountTime;

	// Token: 0x040000F7 RID: 247
	public bool bAskPrizeData;

	// Token: 0x040000F8 RID: 248
	public ActPrizeDataType[][] PreparePrize;

	// Token: 0x040000F9 RID: 249
	public bool bAskKingdomData;

	// Token: 0x040000FA RID: 250
	public byte FightKingdomCount;

	// Token: 0x040000FB RID: 251
	public ushort[] FightKingdomID;

	// Token: 0x040000FC RID: 252
	public bool bAskNobilityData;

	// Token: 0x040000FD RID: 253
	public ushort NobilityKingdomID;

	// Token: 0x040000FE RID: 254
	public ushort NobilityHeroID;

	// Token: 0x040000FF RID: 255
	public CString NobilityName;

	// Token: 0x04000100 RID: 256
	public CString EventTimeStr;
}
