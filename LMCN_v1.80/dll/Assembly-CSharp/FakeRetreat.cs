using System;

// Token: 0x02000251 RID: 593
public struct FakeRetreat
{
	// Token: 0x06000A54 RID: 2644 RVA: 0x000DE868 File Offset: 0x000DCA68
	public FakeRetreat(int i)
	{
		this.unitSide = EUnitSide.BLUE;
		this.lineColor = ELineColor.BLUE;
		this.point = default(PointCode);
		this.point2 = default(PointCode);
		this.lineFlag = EMarchEventType.EMET_Standby;
		this.flag = 0;
		this.playerName = new CString(13);
		this.allianceTag = new CString(4);
		this.emoji = 0;
	}

	// Token: 0x040023CA RID: 9162
	public EUnitSide unitSide;

	// Token: 0x040023CB RID: 9163
	public ELineColor lineColor;

	// Token: 0x040023CC RID: 9164
	public PointCode point;

	// Token: 0x040023CD RID: 9165
	public PointCode point2;

	// Token: 0x040023CE RID: 9166
	public EMarchEventType lineFlag;

	// Token: 0x040023CF RID: 9167
	public CString playerName;

	// Token: 0x040023D0 RID: 9168
	public CString allianceTag;

	// Token: 0x040023D1 RID: 9169
	public byte flag;

	// Token: 0x040023D2 RID: 9170
	public ushort emoji;
}
