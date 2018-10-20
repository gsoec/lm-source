using System;
using System.Collections.Generic;

// Token: 0x02000184 RID: 388
public class WatchTowerComparer_LindID : IComparer<WatchTowerData>
{
	// Token: 0x0600059A RID: 1434 RVA: 0x000789C0 File Offset: 0x00076BC0
	public int Compare(WatchTowerData x, WatchTowerData y)
	{
		if (x.LineID < y.LineID)
		{
			return -1;
		}
		if (x.LineID == y.LineID)
		{
			return 0;
		}
		return 1;
	}
}
