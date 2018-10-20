using System;

// Token: 0x020004A0 RID: 1184
internal struct ShieldLogModel
{
	// Token: 0x06001821 RID: 6177 RVA: 0x0028BF44 File Offset: 0x0028A144
	public void CheckActive()
	{
		DataManager instance = DataManager.Instance;
		this.IsActive = ((!this.IsActive) ? (this.ItemID != 0 && this.EndTime == 0L) : (this.ItemID != 0));
		int recvBuffDataIdxByID = instance.GetRecvBuffDataIdxByID(this.ItemID);
		if (this.IsActive && instance.m_ShieldIdx >= 0 && instance.m_ShieldIdx < instance.m_RecvItemBuffData.Length)
		{
			ItemBuffData itemBuffData = instance.m_RecvItemBuffData[instance.m_ShieldIdx];
			this.EndTime = itemBuffData.TargetTime;
		}
	}

	// Token: 0x06001822 RID: 6178 RVA: 0x0028BFEC File Offset: 0x0028A1EC
	public void SetEmpty(bool bEmpty)
	{
		this.IsEmpty = bEmpty;
	}

	// Token: 0x06001823 RID: 6179 RVA: 0x0028BFF8 File Offset: 0x0028A1F8
	public void Clear()
	{
		this.ItemID = 0;
		this.BeginTime = 0L;
		this.EndTime = 0L;
		this.IsActive = false;
		this.IsEmpty = false;
	}

	// Token: 0x0400471B RID: 18203
	public ushort ItemID;

	// Token: 0x0400471C RID: 18204
	public long BeginTime;

	// Token: 0x0400471D RID: 18205
	public long EndTime;

	// Token: 0x0400471E RID: 18206
	public bool IsActive;

	// Token: 0x0400471F RID: 18207
	public bool IsEmpty;
}
