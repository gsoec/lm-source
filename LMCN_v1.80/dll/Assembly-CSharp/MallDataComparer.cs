using System;
using System.Collections.Generic;

// Token: 0x02000773 RID: 1907
public class MallDataComparer : IComparer<MallDataType>
{
	// Token: 0x06002538 RID: 9528 RVA: 0x0042A26C File Offset: 0x0042846C
	public int Compare(MallDataType x, MallDataType y)
	{
		if (x.Type != ETreasureType.ETST_SHLevelUp && y.Type == ETreasureType.ETST_SHLevelUp)
		{
			return 1;
		}
		if (x.Type == ETreasureType.ETST_SHLevelUp && y.Type != ETreasureType.ETST_SHLevelUp)
		{
			return -1;
		}
		if (MallManager.Instance.bNewbie)
		{
			if (x.Type != ETreasureType.ETST_Newbie && y.Type == ETreasureType.ETST_Newbie)
			{
				return 1;
			}
			if (x.Type == ETreasureType.ETST_Newbie && y.Type != ETreasureType.ETST_Newbie)
			{
				return -1;
			}
		}
		if (x.RenderWeight < y.RenderWeight)
		{
			return 1;
		}
		if (x.RenderWeight > y.RenderWeight)
		{
			return -1;
		}
		return 0;
	}
}
