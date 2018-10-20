using System;

// Token: 0x02000391 RID: 913
public class FootBallTopBoard
{
	// Token: 0x060012CE RID: 4814 RVA: 0x0020D39C File Offset: 0x0020B59C
	public FootBallTopBoard()
	{
		this.KingdomAlliance = new WorldRankingBoardUnitAlliance();
		this.KingdomPlayer = new WorldRankingBoardUnit();
		this.AlliancePlayer = new WorldRankingBoardUnit();
		this.WorldKingdomAlliance = new WorldRankingBoardUnitAlliance();
		this.WorldKingdomPlayer = new WorldRankingBoardUnit();
	}

	// Token: 0x04003AA9 RID: 15017
	public long SortTime;

	// Token: 0x04003AAA RID: 15018
	public byte BoardType;

	// Token: 0x04003AAB RID: 15019
	public WorldRankingBoardUnitAlliance KingdomAlliance;

	// Token: 0x04003AAC RID: 15020
	public ushort KingdomAllianceTopEmblem;

	// Token: 0x04003AAD RID: 15021
	public WorldRankingBoardUnit KingdomPlayer;

	// Token: 0x04003AAE RID: 15022
	public ushort KingdomPlayerTopHead;

	// Token: 0x04003AAF RID: 15023
	public WorldRankingBoardUnit AlliancePlayer;

	// Token: 0x04003AB0 RID: 15024
	public ushort AlliancePlayerTopHead;

	// Token: 0x04003AB1 RID: 15025
	public ushort TopKingdom;

	// Token: 0x04003AB2 RID: 15026
	public ushort TopWorldKingdom;

	// Token: 0x04003AB3 RID: 15027
	public WorldRankingBoardUnitAlliance WorldKingdomAlliance;

	// Token: 0x04003AB4 RID: 15028
	public ushort WorldKingdomAllianceEmblem;

	// Token: 0x04003AB5 RID: 15029
	public WorldRankingBoardUnit WorldKingdomPlayer;

	// Token: 0x04003AB6 RID: 15030
	public ushort WorldKingdomPlayerHead;

	// Token: 0x04003AB7 RID: 15031
	public uint EventRequireTime;

	// Token: 0x04003AB8 RID: 15032
	public ulong AllianceID;
}
