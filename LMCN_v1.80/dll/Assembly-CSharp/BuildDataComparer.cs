using System;
using System.Collections.Generic;

// Token: 0x02000341 RID: 833
public class BuildDataComparer : IComparer<ushort>
{
	// Token: 0x06001124 RID: 4388 RVA: 0x001E6870 File Offset: 0x001E4A70
	public int Compare(ushort x, ushort y)
	{
		RoleBuildingData[] allBuildsData = GUIManager.Instance.BuildingData.AllBuildsData;
		if (allBuildsData[(int)x].Level > 0 && allBuildsData[(int)y].Level == 0)
		{
			return -1;
		}
		if (allBuildsData[(int)x].Level == 0 && allBuildsData[(int)y].Level > 0)
		{
			return 1;
		}
		if (allBuildsData[(int)x].Level == 0 && allBuildsData[(int)y].Level == 0)
		{
			return 0;
		}
		if (allBuildsData[(int)x].BuildID > allBuildsData[(int)y].BuildID)
		{
			return -1;
		}
		if (allBuildsData[(int)x].BuildID < allBuildsData[(int)y].BuildID)
		{
			return 1;
		}
		if (allBuildsData[(int)x].Level > allBuildsData[(int)y].Level)
		{
			return -1;
		}
		if (allBuildsData[(int)x].Level < allBuildsData[(int)y].Level)
		{
			return 1;
		}
		return 0;
	}
}
