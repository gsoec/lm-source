using System;

// Token: 0x020004FF RID: 1279
internal struct BuffInfoItem
{
	// Token: 0x0600199A RID: 6554 RVA: 0x002B766C File Offset: 0x002B586C
	public void Init()
	{
		this.m_Type = 0;
		this.m_ColumNum = 2;
		this.m_Height = 0f;
		this.m_Width = 0f;
		this.m_DataIdx = 0;
		this.m_EffectType = GATTR_ENUM.EGE_DESHIELD_ATK;
		this.m_EffectValue = 0u;
		this.m_StrIdx = 0;
		this.m_Column = new BuffInfoItemColumn[2];
	}

	// Token: 0x04004C24 RID: 19492
	public byte m_Type;

	// Token: 0x04004C25 RID: 19493
	public int m_ColumNum;

	// Token: 0x04004C26 RID: 19494
	public float m_Height;

	// Token: 0x04004C27 RID: 19495
	public float m_Width;

	// Token: 0x04004C28 RID: 19496
	public int m_DataIdx;

	// Token: 0x04004C29 RID: 19497
	public BuffInfoItemColumn[] m_Column;

	// Token: 0x04004C2A RID: 19498
	public GATTR_ENUM m_EffectType;

	// Token: 0x04004C2B RID: 19499
	public uint m_EffectValue;

	// Token: 0x04004C2C RID: 19500
	public int m_StrIdx;
}
