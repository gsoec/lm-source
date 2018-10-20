using System;
using System.Collections.Generic;

// Token: 0x02000180 RID: 384
public class TalkDataComparer : IComparer<TalkDataType>
{
	// Token: 0x06000592 RID: 1426 RVA: 0x000787D8 File Offset: 0x000769D8
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
