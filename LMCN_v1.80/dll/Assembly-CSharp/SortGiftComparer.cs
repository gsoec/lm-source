using System;
using System.Collections.Generic;

// Token: 0x02000185 RID: 389
public class SortGiftComparer : IComparer<uint>
{
	// Token: 0x0600059C RID: 1436 RVA: 0x000789F8 File Offset: 0x00076BF8
	public int Compare(uint x, uint y)
	{
		DataManager instance = DataManager.Instance;
		AllianceBoxDataType allianceBoxDataType = instance.mListGift[x];
		AllianceBoxDataType allianceBoxDataType2 = instance.mListGift[y];
		bool flag;
		if (allianceBoxDataType.Status == 0)
		{
			if (allianceBoxDataType2.Status != 0)
			{
				return -1;
			}
			flag = true;
		}
		else
		{
			if (allianceBoxDataType2.Status == 0)
			{
				return 1;
			}
			flag = true;
		}
		if (!flag)
		{
			return -1;
		}
		if (allianceBoxDataType.RcvTime < allianceBoxDataType2.RcvTime)
		{
			return -1;
		}
		return 1;
	}
}
