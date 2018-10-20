using System;
using System.Collections.Generic;

// Token: 0x020004A4 RID: 1188
public class TargetTimeComparer : IComparer<ItemBuffData>
{
	// Token: 0x06001833 RID: 6195 RVA: 0x0028C5F0 File Offset: 0x0028A7F0
	public int Compare(ItemBuffData x, ItemBuffData y)
	{
		if (x.TargetTime >= y.TargetTime)
		{
			return 1;
		}
		return -1;
	}
}
