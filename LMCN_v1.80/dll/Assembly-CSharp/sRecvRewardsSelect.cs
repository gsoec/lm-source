using System;

// Token: 0x020002B5 RID: 693
public struct sRecvRewardsSelect
{
	// Token: 0x06000DE9 RID: 3561 RVA: 0x0016367C File Offset: 0x0016187C
	public void Init()
	{
		this.ItemIndex = new int[3];
		this.SelectIndex = 0;
	}

	// Token: 0x04002D1E RID: 11550
	public int[] ItemIndex;

	// Token: 0x04002D1F RID: 11551
	public byte SelectIndex;
}
