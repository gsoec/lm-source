using System;
using System.Collections.Generic;

// Token: 0x0200017B RID: 379
public class HeroConditionComparer : IComparer<uint>
{
	// Token: 0x06000582 RID: 1410 RVA: 0x00077088 File Offset: 0x00075288
	public int Compare(uint x, uint y)
	{
		bool flag = false;
		bool flag2 = false;
		LevelEX levelEXBycurrentPointID = DataManager.StageDataController.GetLevelEXBycurrentPointID(0);
		StageConditionData recordByKey;
		if (DataManager.StageDataController.StageDareMode(DataManager.StageDataController.currentPointID) == StageMode.Lean)
		{
			recordByKey = DataManager.StageDataController.StageConditionDataTable.GetRecordByKey(levelEXBycurrentPointID.NodusOneID + (ushort)DataManager.StageDataController.currentNodus - 1);
		}
		else
		{
			recordByKey = DataManager.StageDataController.StageConditionDataTable.GetRecordByKey(levelEXBycurrentPointID.NodusTwoID);
		}
		for (int i = 0; i < recordByKey.ConditionArray.Length; i++)
		{
			if (recordByKey.ConditionArray[i].ConditionID == 3)
			{
				if ((uint)recordByKey.ConditionArray[i].FactorA == x)
				{
					flag = true;
				}
				if ((uint)recordByKey.ConditionArray[i].FactorA == y)
				{
					flag2 = true;
				}
			}
		}
		int result;
		if (flag)
		{
			if (flag2)
			{
				if (x > y)
				{
					result = -1;
				}
				else
				{
					result = 1;
				}
			}
			else
			{
				result = -1;
			}
		}
		else if (flag2)
		{
			result = 1;
		}
		else
		{
			byte b = 0;
			byte b2 = 0;
			byte b3 = 0;
			for (int j = 0; j < recordByKey.ConditionArray.Length; j++)
			{
				if (recordByKey.ConditionArray[j].ConditionID == 1)
				{
					if ((recordByKey.ConditionArray[j].FactorA == 0 && !ArenaManager.Instance.CheckHeroAstrology((ushort)x, recordByKey.ConditionArray[j].FactorB)) || (recordByKey.ConditionArray[j].FactorA == 1 && ArenaManager.Instance.CheckHeroAstrology((ushort)x, recordByKey.ConditionArray[j].FactorB)))
					{
						b += 1;
					}
					if ((recordByKey.ConditionArray[j].FactorA == 0 && !ArenaManager.Instance.CheckHeroAstrology((ushort)y, recordByKey.ConditionArray[j].FactorB)) || (recordByKey.ConditionArray[j].FactorA == 1 && ArenaManager.Instance.CheckHeroAstrology((ushort)y, recordByKey.ConditionArray[j].FactorB)))
					{
						b2 += 1;
					}
					b3 += 1;
				}
			}
			if (b3 != 0)
			{
				if (b3 == b)
				{
					if (b3 == b2)
					{
						if (x > y)
						{
							result = -1;
						}
						else
						{
							result = 1;
						}
					}
					else
					{
						result = -1;
					}
				}
				else if (b3 == b2)
				{
					result = 1;
				}
				else if (x > y)
				{
					result = -1;
				}
				else
				{
					result = 1;
				}
			}
			else if (x > y)
			{
				result = -1;
			}
			else
			{
				result = 1;
			}
		}
		return result;
	}
}
