using System;

// Token: 0x0200038D RID: 909
public class MobilizationGroupBroudUnit
{
	// Token: 0x060012CA RID: 4810 RVA: 0x0020D2D8 File Offset: 0x0020B4D8
	public MobilizationGroupBroudUnit()
	{
		this.AllianceTag = StringManager.Instance.SpawnString(30);
		this.Name = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x04003A94 RID: 14996
	public uint AlliacneID;

	// Token: 0x04003A95 RID: 14997
	public CString AllianceTag;

	// Token: 0x04003A96 RID: 14998
	public CString Name;

	// Token: 0x04003A97 RID: 14999
	public uint Score;

	// Token: 0x04003A98 RID: 15000
	public int ChangeRank;

	// Token: 0x04003A99 RID: 15001
	public int Rank;
}
