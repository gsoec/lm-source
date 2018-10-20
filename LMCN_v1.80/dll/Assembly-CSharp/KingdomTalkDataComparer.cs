using System;
using System.Collections.Generic;

// Token: 0x02000181 RID: 385
public class KingdomTalkDataComparer : IComparer<TalkDataType>
{
	// Token: 0x06000594 RID: 1428 RVA: 0x0007882C File Offset: 0x00076A2C
	public int Compare(TalkDataType x, TalkDataType y)
	{
		if (x == null)
		{
			if (y == null)
			{
				return 0;
			}
			return -1;
		}
		else
		{
			if (y == null)
			{
				return 1;
			}
			if (x.TalkTime > y.TalkTime)
			{
				return 1;
			}
			if (x.TalkTime < y.TalkTime)
			{
				return -1;
			}
			if (x.TalkID > y.TalkID)
			{
				return 1;
			}
			if (x.TalkID < y.TalkID)
			{
				return -1;
			}
			return 0;
		}
	}
}
