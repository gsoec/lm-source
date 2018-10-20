using System;

// Token: 0x0200038C RID: 908
public class AllianceWarBroudUnit
{
	// Token: 0x060012C9 RID: 4809 RVA: 0x0020D2A0 File Offset: 0x0020B4A0
	public AllianceWarBroudUnit()
	{
		this.AllianceTag = StringManager.Instance.SpawnString(30);
		this.Name = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x04003A8F RID: 14991
	public uint AlliacneID;

	// Token: 0x04003A90 RID: 14992
	public CString AllianceTag;

	// Token: 0x04003A91 RID: 14993
	public CString Name;

	// Token: 0x04003A92 RID: 14994
	public ulong Power;

	// Token: 0x04003A93 RID: 14995
	public int Score;
}
