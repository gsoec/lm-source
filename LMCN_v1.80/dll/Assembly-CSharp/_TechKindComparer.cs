using System;
using System.Collections.Generic;

// Token: 0x02000188 RID: 392
public class _TechKindComparer : IComparer<byte>
{
	// Token: 0x060005A3 RID: 1443 RVA: 0x00078BD0 File Offset: 0x00076DD0
	public int Compare(byte x, byte y)
	{
		DataManager instance = DataManager.Instance;
		TechKindTbl recordByIndex = instance.TechKindData.GetRecordByIndex((int)x);
		TechKindTbl recordByIndex2 = instance.TechKindData.GetRecordByIndex((int)y);
		if (recordByIndex.Priority < recordByIndex2.Priority)
		{
			return -1;
		}
		if (recordByIndex.Priority > recordByIndex2.Priority)
		{
			return 1;
		}
		return 0;
	}
}
