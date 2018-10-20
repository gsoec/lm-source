using System;

// Token: 0x02000155 RID: 341
public struct SearchPlayerDataType
{
	// Token: 0x06000349 RID: 841 RVA: 0x00028B84 File Offset: 0x00026D84
	public SearchPlayerDataType(int len = 0)
	{
		this.Head = 1;
		this.Name = StringManager.Instance.SpawnString(13);
		this.AllianceTag = StringManager.Instance.SpawnString(3);
		this.Power = 0UL;
		this.TroopKillNum = 0UL;
	}

	// Token: 0x04000D9F RID: 3487
	public ushort Head;

	// Token: 0x04000DA0 RID: 3488
	public CString Name;

	// Token: 0x04000DA1 RID: 3489
	public CString AllianceTag;

	// Token: 0x04000DA2 RID: 3490
	public ulong Power;

	// Token: 0x04000DA3 RID: 3491
	public ulong TroopKillNum;
}
