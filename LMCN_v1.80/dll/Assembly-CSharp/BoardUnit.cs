using System;

// Token: 0x02000382 RID: 898
public class BoardUnit
{
	// Token: 0x060012BF RID: 4799 RVA: 0x0020D098 File Offset: 0x0020B298
	public BoardUnit()
	{
		this.AlliaceTag = StringManager.Instance.SpawnString(30);
		this.Name = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x04003A42 RID: 14914
	public CString AlliaceTag;

	// Token: 0x04003A43 RID: 14915
	public CString Name;

	// Token: 0x04003A44 RID: 14916
	public ulong Value;
}
