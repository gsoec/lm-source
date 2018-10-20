using System;
using System.Collections.Generic;

// Token: 0x02000558 RID: 1368
public class ActItemComparer : IComparer<ushort>
{
	// Token: 0x06001B56 RID: 6998 RVA: 0x00306BBC File Offset: 0x00304DBC
	public int Compare(ushort x, ushort y)
	{
		DataManager instance = DataManager.Instance;
		if (instance.MallEquipmantTable.GetRecordByKey(x).SortValue == instance.MallEquipmantTable.GetRecordByKey(y).SortValue)
		{
			return 0;
		}
		if (instance.MallEquipmantTable.GetRecordByKey(x).SortValue < instance.MallEquipmantTable.GetRecordByKey(y).SortValue)
		{
			return 1;
		}
		return -1;
	}
}
