using System;
using System.Collections.Generic;

// Token: 0x02000187 RID: 391
public class WonderDataComparer : IComparer<WonderData>
{
	// Token: 0x060005A0 RID: 1440 RVA: 0x00078AA4 File Offset: 0x00076CA4
	public int MyCompare(int state, WonderData data1, WonderData data2)
	{
		int num = 0;
		int num2 = 0;
		if (state == 1)
		{
			if (DataManager.MapDataController.kingdomData.kingdomID == data1.KingdomID)
			{
				num = 0;
			}
			else
			{
				num = (int)data1.KingdomID;
			}
			if (DataManager.MapDataController.kingdomData.kingdomID == data2.KingdomID)
			{
				num2 = 0;
			}
			else
			{
				num2 = (int)data2.KingdomID;
			}
		}
		else if (state == 2)
		{
			num = (int)data1.WonderID;
			num2 = (int)data2.WonderID;
		}
		if (num == num2)
		{
			return 0;
		}
		if (num < num2)
		{
			return -1;
		}
		return 1;
	}

	// Token: 0x060005A1 RID: 1441 RVA: 0x00078B40 File Offset: 0x00076D40
	public int Compare(WonderData x, WonderData y)
	{
		if (x.KingdomID == y.KingdomID && x.WonderID == y.WonderID)
		{
			return 0;
		}
		if (x.OpenState == y.OpenState)
		{
			if (x.KingdomID == y.KingdomID)
			{
				return this.MyCompare(2, x, y);
			}
			return this.MyCompare(1, x, y);
		}
		else
		{
			if (x.OpenState > y.OpenState)
			{
				return -1;
			}
			return 1;
		}
	}
}
