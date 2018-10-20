using System;

// Token: 0x020002B8 RID: 696
public struct BattleStation
{
	// Token: 0x06000E0C RID: 3596 RVA: 0x0016481C File Offset: 0x00162A1C
	public void Clear()
	{
		StringManager.Instance.DeSpawnString(this.DecepticonTag);
		StringManager.Instance.DeSpawnString(this.AutobotTag);
		this.AutobotTag = (this.DecepticonTag = null);
		this.Autobot = (this.Decepticon = null);
		this.BattleMatch = null;
		this.BattlePosition = 0;
		this.CampDecepticon = 0;
		this.CampAutobot = 0;
		this.BattleSide = 0;
		this.BeginTime = 0L;
		this.Received = 0;
	}

	// Token: 0x06000E0D RID: 3597 RVA: 0x001648A0 File Offset: 0x00162AA0
	public void SetData(AllianceWarManager._RegisterData[] wins = null, AllianceWarManager._RegisterData[] loss = null)
	{
		this.Autobot = wins;
		this.Decepticon = loss;
	}

	// Token: 0x04002D4D RID: 11597
	public AllianceWarManager._RegisterData[] Autobot;

	// Token: 0x04002D4E RID: 11598
	public AllianceWarManager._RegisterData[] Decepticon;

	// Token: 0x04002D4F RID: 11599
	public AlliWarWarDetail[] BattleMatch;

	// Token: 0x04002D50 RID: 11600
	public CString DecepticonTag;

	// Token: 0x04002D51 RID: 11601
	public ushort DecepticonIcon;

	// Token: 0x04002D52 RID: 11602
	public CString AutobotTag;

	// Token: 0x04002D53 RID: 11603
	public ushort AutobotIcon;

	// Token: 0x04002D54 RID: 11604
	public byte DecepticonPos;

	// Token: 0x04002D55 RID: 11605
	public byte Decepticons;

	// Token: 0x04002D56 RID: 11606
	public byte AutobotPos;

	// Token: 0x04002D57 RID: 11607
	public byte Autobots;

	// Token: 0x04002D58 RID: 11608
	public byte Received;

	// Token: 0x04002D59 RID: 11609
	public byte OnLive;

	// Token: 0x04002D5A RID: 11610
	public byte MatchID;

	// Token: 0x04002D5B RID: 11611
	public byte GameRound;

	// Token: 0x04002D5C RID: 11612
	public long BeginTime;

	// Token: 0x04002D5D RID: 11613
	public byte BattleSide;

	// Token: 0x04002D5E RID: 11614
	public byte BattleRound;

	// Token: 0x04002D5F RID: 11615
	public byte BattleWinner;

	// Token: 0x04002D60 RID: 11616
	public byte BattleMatchs;

	// Token: 0x04002D61 RID: 11617
	public byte BattlePosition;

	// Token: 0x04002D62 RID: 11618
	public byte CampDecepticon;

	// Token: 0x04002D63 RID: 11619
	public byte CampAutobot;
}
