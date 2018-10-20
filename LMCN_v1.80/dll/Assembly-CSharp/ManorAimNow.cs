using System;

// Token: 0x020003E8 RID: 1000
public class ManorAimNow : ManorAimChecked
{
	// Token: 0x0600147A RID: 5242 RVA: 0x0023AA10 File Offset: 0x00238C10
	public override bool CheckValueChanged(ushort Key, ushort Val)
	{
		Key -= this.KeyBegin;
		if (this.ManorBuildData.Length <= (int)Key || this.ManorBuildData[(int)Key].CondiVal == (int)Val)
		{
			return false;
		}
		MissionManager missionDataManager = DataManager.MissionDataManager;
		int i = this.ManorBuildData[(int)Key].CheckIndex;
		if (this.ManorBuildData[(int)Key].CondiVal < (int)Val)
		{
			while (i < this.ManorBuildData[(int)Key].LvCondi.Count)
			{
				if (this.ManorBuildData[(int)Key].LvCondi[i] > Val)
				{
					break;
				}
				missionDataManager.AddRewardMission(this.ManorBuildData[(int)Key].Priority[i]);
				this.ManorBuildData[(int)Key].CondPriority = (int)this.ManorBuildData[(int)Key].Priority[i];
				i++;
			}
		}
		else if (this.ManorBuildData[(int)Key].CondiVal > (int)Val)
		{
			if (i >= this.ManorBuildData[(int)Key].LvCondi.Count)
			{
				i = this.ManorBuildData[(int)Key].LvCondi.Count - 1;
			}
			while (i > 0)
			{
				if (this.ManorBuildData[(int)Key].LvCondi[i] < Val)
				{
					if (this.ManorBuildData[(int)Key].LvCondi.Count > i + 1)
					{
						i++;
					}
					break;
				}
				i--;
			}
			if (i < 0)
			{
				i = 0;
			}
			if (this.ManorBuildData[(int)Key].Priority.Count > 0)
			{
				missionDataManager.UpdateReCommandSaveIndex(this.ManorBuildData[(int)Key].Priority[i]);
			}
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

	// Token: 0x0600147B RID: 5243 RVA: 0x0023AD18 File Offset: 0x00238F18
	public override void UpdateCheckIndex(ushort Key, ushort Val)
	{
		this.ManorBuildData[(int)(Key - this.KeyBegin)].Reset();
		this.CheckValueChanged(Key, Val);
	}
}
