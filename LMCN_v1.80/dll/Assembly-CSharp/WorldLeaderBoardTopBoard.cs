using System;

// Token: 0x02000389 RID: 905
public class WorldLeaderBoardTopBoard
{
	// Token: 0x060012C6 RID: 4806 RVA: 0x0020D138 File Offset: 0x0020B338
	public WorldLeaderBoardTopBoard()
	{
		this.PowerTop = new WorldRankingBoardUnit();
		this.KillsTop = new WorldRankingBoardUnit();
		this.AlliPowerTop = new WorldRankingBoardUnitAlliance();
		this.AlliKillsTop = new WorldRankingBoardUnitAlliance();
	}

	// Token: 0x04003A56 RID: 14934
	public long SortTime;

	// Token: 0x04003A57 RID: 14935
	public WorldRankingBoardUnit PowerTop;

	// Token: 0x04003A58 RID: 14936
	public ushort PowerTopHead;

	// Token: 0x04003A59 RID: 14937
	public WorldRankingBoardUnit KillsTop;

	// Token: 0x04003A5A RID: 14938
	public ushort KillsTopHead;

	// Token: 0x04003A5B RID: 14939
	public WorldRankingBoardUnitAlliance AlliPowerTop;

	// Token: 0x04003A5C RID: 14940
	public ushort PowerTopEmblem;

	// Token: 0x04003A5D RID: 14941
	public WorldRankingBoardUnitAlliance AlliKillsTop;

	// Token: 0x04003A5E RID: 14942
	public ushort KillsTopEmblem;
}
