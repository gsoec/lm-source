using System;
using System.Collections.Generic;

// Token: 0x0200017A RID: 378
public class HeroDAtaComparer : IComparer<uint>
{
	// Token: 0x0600057F RID: 1407 RVA: 0x00076F54 File Offset: 0x00075154
	public int MyCompare(int state, CurHeroData data1, CurHeroData data2)
	{
		int num = 0;
		int num2 = 0;
		if (state == 1)
		{
			num = (int)data1.Star;
			num2 = (int)data2.Star;
		}
		else if (state == 2)
		{
			num = (int)data1.Enhance;
			num2 = (int)data2.Enhance;
		}
		else if (state == 3)
		{
			num = (int)data1.Level;
			num2 = (int)data2.Level;
		}
		else if (state == 4)
		{
			num = (int)data1.ID;
			num2 = (int)data2.ID;
		}
		if (num > num2)
		{
			return -1;
		}
		return 1;
	}

	// Token: 0x06000580 RID: 1408 RVA: 0x00076FDC File Offset: 0x000751DC
	public int Compare(uint x, uint y)
	{
		CurHeroData data = DataManager.Instance.curHeroData[x];
		CurHeroData data2 = DataManager.Instance.curHeroData[y];
		int result;
		if (data.Star == data2.Star)
		{
			if (data.Enhance == data2.Enhance)
			{
				if (data.Level == data2.Level)
				{
					result = this.MyCompare(4, data, data2);
				}
				else
				{
					result = this.MyCompare(3, data, data2);
				}
			}
			else
			{
				result = this.MyCompare(2, data, data2);
			}
		}
		else
		{
			result = this.MyCompare(1, data, data2);
		}
		return result;
	}
}
