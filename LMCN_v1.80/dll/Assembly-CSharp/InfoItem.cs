using System;

// Token: 0x020005B2 RID: 1458
internal class InfoItem
{
	// Token: 0x06001CF7 RID: 7415 RVA: 0x0033D904 File Offset: 0x0033BB04
	public InfoItem()
	{
		this.m_Column = new Column[6];
		for (int i = 0; i < this.m_Column.Length; i++)
		{
			this.m_Column[i] = new Column(0);
		}
	}

	// Token: 0x0400589C RID: 22684
	public byte m_Type;

	// Token: 0x0400589D RID: 22685
	public bool bHaveLvColumn;

	// Token: 0x0400589E RID: 22686
	public int m_ColumNum;

	// Token: 0x0400589F RID: 22687
	public float m_Height;

	// Token: 0x040058A0 RID: 22688
	public float m_Width;

	// Token: 0x040058A1 RID: 22689
	public int m_DataIdx;

	// Token: 0x040058A2 RID: 22690
	public Column[] m_Column;
}
