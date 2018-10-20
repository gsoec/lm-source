using System;
using System.Collections.Generic;

// Token: 0x02000179 RID: 377
public class ItemBuffComparer : IComparer<byte>
{
	// Token: 0x0600057D RID: 1405 RVA: 0x00076EB0 File Offset: 0x000750B0
	public int Compare(byte x, byte y)
	{
		ItemBuff recordByIndex = DataManager.Instance.ItemBuffTable.GetRecordByIndex((int)x);
		ItemBuff recordByIndex2 = DataManager.Instance.ItemBuffTable.GetRecordByIndex((int)y);
		if (recordByIndex2.BuffKind == recordByIndex.BuffKind)
		{
			return -1;
		}
		if (recordByIndex2.BuffKind == 1)
		{
			return 1;
		}
		if (recordByIndex2.BuffKind == 3 && recordByIndex.BuffKind != 1)
		{
			return 1;
		}
		if (recordByIndex2.BuffKind == 4 && recordByIndex.BuffKind != 1 && recordByIndex.BuffKind != 3)
		{
			return 1;
		}
		return -1;
	}
}
