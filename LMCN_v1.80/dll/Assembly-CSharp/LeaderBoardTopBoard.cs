using System;

// Token: 0x02000388 RID: 904
public class LeaderBoardTopBoard
{
	// Token: 0x060012C5 RID: 4805 RVA: 0x0020D0F8 File Offset: 0x0020B2F8
	public LeaderBoardTopBoard()
	{
		this.PowerTop = new BoardUnit();
		this.KillsTop = new BoardUnit();
		this.AlliPowerTop = new BoardUnit();
		this.AlliKillsTop = new BoardUnit();
		this.ArenaTop = new BoardUnit();
	}

	// Token: 0x04003A4B RID: 14923
	public long SortTime;

	// Token: 0x04003A4C RID: 14924
	public BoardUnit PowerTop;

	// Token: 0x04003A4D RID: 14925
	public ushort PowerTopHead;

	// Token: 0x04003A4E RID: 14926
	public BoardUnit KillsTop;

	// Token: 0x04003A4F RID: 14927
	public ushort KillTopHead;

	// Token: 0x04003A50 RID: 14928
	public BoardUnit AlliPowerTop;

	// Token: 0x04003A51 RID: 14929
	public ushort PowerTopEmblem;

	// Token: 0x04003A52 RID: 14930
	public BoardUnit AlliKillsTop;

	// Token: 0x04003A53 RID: 14931
	public ushort KillsTopEmblem;

	// Token: 0x04003A54 RID: 14932
	public BoardUnit ArenaTop;

	// Token: 0x04003A55 RID: 14933
	public ushort ArenaTopHead;
}
