using System;

// Token: 0x0200032B RID: 811
internal struct sScrollItemData
{
	// Token: 0x0600107B RID: 4219 RVA: 0x001D5A7C File Offset: 0x001D3C7C
	public sScrollItemData(int len = 0)
	{
		this.Height = 0f;
		this.Type = eItem.TitleType;
		this.StrID = 0;
		this.StrID_Value = 0;
		this.StrNum = 0u;
		this.ArmyIdx = 0;
		this.ArmyNum = 0u;
	}

	// Token: 0x04003606 RID: 13830
	public float Height;

	// Token: 0x04003607 RID: 13831
	public eItem Type;

	// Token: 0x04003608 RID: 13832
	public ushort StrID;

	// Token: 0x04003609 RID: 13833
	public ushort StrID_Value;

	// Token: 0x0400360A RID: 13834
	public uint StrNum;

	// Token: 0x0400360B RID: 13835
	public int ArmyIdx;

	// Token: 0x0400360C RID: 13836
	public uint ArmyNum;
}
