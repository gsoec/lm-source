using System;
using System.Collections.Generic;

// Token: 0x02000183 RID: 387
public class WatchTowerComparer : IComparer<WatchTowerSortData>
{
	// Token: 0x06000598 RID: 1432 RVA: 0x000788FC File Offset: 0x00076AFC
	public int Compare(WatchTowerSortData x, WatchTowerSortData y)
	{
		WatchTowerData watchTowerData;
		if (x.LineType != 0)
		{
			watchTowerData = DataManager.Instance.tmp_WatchTowerData[(int)x.ListIdx];
		}
		else
		{
			watchTowerData = DataManager.Instance.mtmpIdx[(int)((UIntPtr)(x.ListIdx - 1u))];
		}
		WatchTowerData watchTowerData2;
		if (y.LineType != 0)
		{
			watchTowerData2 = DataManager.Instance.tmp_WatchTowerData[(int)y.ListIdx];
		}
		else
		{
			watchTowerData2 = DataManager.Instance.mtmpIdx[(int)((UIntPtr)(y.ListIdx - 1u))];
		}
		if (watchTowerData.MarchTimeData.BeginTime < watchTowerData2.MarchTimeData.BeginTime)
		{
			return -1;
		}
		return 1;
	}
}
