using System;

// Token: 0x02000851 RID: 2129
public abstract class _WhoReward
{
	// Token: 0x06002C0A RID: 11274
	public abstract bool CheckReward();

	// Token: 0x06002C0B RID: 11275
	public abstract bool CheckAndOpenList(int ID);

	// Token: 0x0400788A RID: 30858
	public string TitleStr;

	// Token: 0x0400788B RID: 30859
	public string MainStr;

	// Token: 0x0400788C RID: 30860
	public bool IsKing;
}
