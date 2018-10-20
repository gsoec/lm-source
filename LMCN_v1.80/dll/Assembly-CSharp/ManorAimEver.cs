using System;

// Token: 0x020003E9 RID: 1001
public class ManorAimEver : ManorAimChecked
{
	// Token: 0x0600147C RID: 5244 RVA: 0x0023AD3C File Offset: 0x00238F3C
	public ManorAimEver(ushort[] RecordMark)
	{
		this.RecordMark = RecordMark;
	}

	// Token: 0x0600147D RID: 5245 RVA: 0x0023AD4C File Offset: 0x00238F4C
	public override bool CheckValueChanged(ushort Key, ushort Val)
	{
		Key -= this.KeyBegin;
		if (this.ManorBuildData.Length <= (int)Key || this.ManorBuildData[(int)Key].CondiVal >= (int)Val || this.ManorBuildData[(int)Key].CheckIndex >= this.ManorBuildData[(int)Key].LvCondi.Count)
		{
			return false;
		}
		MissionManager missionDataManager = DataManager.MissionDataManager;
		int i;
		for (i = this.ManorBuildData[(int)Key].CheckIndex; i < this.ManorBuildData[(int)Key].LvCondi.Count; i++)
		{
			if (this.ManorBuildData[(int)Key].LvCondi[i] > Val)
			{
				break;
			}
			missionDataManager.AddRewardMission(this.ManorBuildData[(int)Key].Priority[i]);
		}
		if (this.ManorBuildData[(int)Key].CheckIndex < i)
		{
			if (missionDataManager.bFirst == 0)
			{
				CString cstring = StringManager.Instance.StaticString1024();
				CString cstring2 = StringManager.Instance.StaticString1024();
				StringTable mStringTable = DataManager.Instance.mStringTable;
				for (int j = this.ManorBuildData[(int)Key].CheckIndex; j < i; j++)
				{
					cstring.ClearString();
					cstring2.ClearString();
					ushort missionID = missionDataManager.GetMissionID(this.ManorBuildData[(int)Key].Priority[j]);
					if (!missionDataManager.CheckBoolMark(missionID))
					{
						ManorAimTbl recordByKey = missionDataManager.ManorAimTable.GetRecordByKey(missionID);
						missionDataManager.GetNarrative(cstring, ref recordByKey);
						cstring2.StringToFormat(cstring);
						cstring2.AppendFormat(mStringTable.GetStringByID(7941u));
						GUIManager.Instance.AddHUDQueue(cstring2.ToString(), 25, true);
					}
				}
			}
			else
			{
				missionDataManager.bFirst = byte.MaxValue;
			}
		}
		this.ManorBuildData[(int)Key].CondiVal = (int)Val;
		this.ManorBuildData[(int)Key].CheckIndex = i;
		return true;
	}

	// Token: 0x0600147E RID: 5246 RVA: 0x0023AF58 File Offset: 0x00239158
	public override void UpdateCheckIndex(ushort Key, ushort Val)
	{
		this.CheckValueChanged(Key, Val);
	}

	// Token: 0x04003D89 RID: 15753
	protected ushort[] RecordMark;
}
