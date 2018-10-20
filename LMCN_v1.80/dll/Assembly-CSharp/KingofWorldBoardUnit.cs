using System;

// Token: 0x02000390 RID: 912
public class KingofWorldBoardUnit
{
	// Token: 0x060012CD RID: 4813 RVA: 0x0020D364 File Offset: 0x0020B564
	public KingofWorldBoardUnit()
	{
		this.AllianceTag = StringManager.Instance.SpawnString(30);
		this.Name = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x04003AA5 RID: 15013
	public ushort HomeKingdomID;

	// Token: 0x04003AA6 RID: 15014
	public CString AllianceTag;

	// Token: 0x04003AA7 RID: 15015
	public CString Name;

	// Token: 0x04003AA8 RID: 15016
	public uint OccupyTime;
}
