using System;

// Token: 0x020005B1 RID: 1457
internal struct Column
{
	// Token: 0x06001CF6 RID: 7414 RVA: 0x0033D8B0 File Offset: 0x0033BAB0
	public Column(int i)
	{
		this.m_Value = 0L;
		this.m_StrID = 0u;
		this.m_EffID = 0u;
		this.ColumnWidth = 0f;
		this.bFisetColumn = false;
		this.bLastColumn = false;
		this.m_Str = StringManager.Instance.SpawnString(200);
	}

	// Token: 0x04005895 RID: 22677
	public uint m_StrID;

	// Token: 0x04005896 RID: 22678
	public uint m_EffID;

	// Token: 0x04005897 RID: 22679
	public long m_Value;

	// Token: 0x04005898 RID: 22680
	public bool bFisetColumn;

	// Token: 0x04005899 RID: 22681
	public bool bLastColumn;

	// Token: 0x0400589A RID: 22682
	public float ColumnWidth;

	// Token: 0x0400589B RID: 22683
	public CString m_Str;
}
