using System;

// Token: 0x020007D1 RID: 2001
public interface IPagemove
{
	// Token: 0x06002952 RID: 10578
	void BeginPageMove();

	// Token: 0x06002953 RID: 10579
	void EndPageMove();

	// Token: 0x06002954 RID: 10580
	void PageIndexChange(byte PageIndex);
}
