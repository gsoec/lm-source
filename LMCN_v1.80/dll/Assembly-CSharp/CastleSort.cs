using System;
using System.Collections.Generic;

// Token: 0x02000346 RID: 838
public class CastleSort : IComparer<ushort>
{
	// Token: 0x0600114C RID: 4428 RVA: 0x001E7EC0 File Offset: 0x001E60C0
	public int Compare(ushort x, ushort y)
	{
		if (this.type == CastleSkin._SortType.All)
		{
			return this.CompareAll(x, y);
		}
		return this.CompareOwn(x, y);
	}

	// Token: 0x0600114D RID: 4429 RVA: 0x001E7EE0 File Offset: 0x001E60E0
	private int CompareAll(ushort x, ushort y)
	{
		CastleSkin castleSkin = GUIManager.Instance.BuildingData.castleSkin;
		CastleSkinTbl recordByKey = castleSkin.CastleSkinTable.GetRecordByKey(x);
		CastleSkinTbl recordByKey2 = castleSkin.CastleSkinTable.GetRecordByKey(y);
		bool flag = castleSkin.CheckUnlock((byte)x);
		bool flag2 = castleSkin.CheckUnlock((byte)y);
		bool flag3 = castleSkin.CheckSelect((byte)x);
		bool flag4 = castleSkin.CheckSelect((byte)y);
		if (flag && !flag2)
		{
			return -1;
		}
		if (!flag && flag2)
		{
			return 1;
		}
		if (flag3 && !flag4)
		{
			return 1;
		}
		if (!flag3 && flag4)
		{
			return -1;
		}
		if (recordByKey.Priority > recordByKey2.Priority)
		{
			return -1;
		}
		if (recordByKey.Priority < recordByKey2.Priority)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x0600114E RID: 4430 RVA: 0x001E7FA8 File Offset: 0x001E61A8
	private int CompareOwn(ushort x, ushort y)
	{
		CastleSkin castleSkin = GUIManager.Instance.BuildingData.castleSkin;
		CastleSkinTbl recordByKey = castleSkin.CastleSkinTable.GetRecordByKey(x);
		CastleSkinTbl recordByKey2 = castleSkin.CastleSkinTable.GetRecordByKey(y);
		if (recordByKey.Priority > recordByKey2.Priority)
		{
			return -1;
		}
		if (recordByKey.Priority < recordByKey2.Priority)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x04003784 RID: 14212
	public CastleSkin._SortType type = CastleSkin._SortType.All;
}
