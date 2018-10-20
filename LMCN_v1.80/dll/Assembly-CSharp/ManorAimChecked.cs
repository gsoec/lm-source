using System;
using System.Collections.Generic;

// Token: 0x020003E7 RID: 999
public class ManorAimChecked : _ManorAimTypeMission
{
	// Token: 0x06001471 RID: 5233 RVA: 0x0023A680 File Offset: 0x00238880
	protected void Init()
	{
		for (int i = 0; i < this.ManorBuildData.Length; i++)
		{
			this.ManorBuildData[i].LvCondi = new List<ushort>();
			this.ManorBuildData[i].Priority = new List<ushort>();
		}
	}

	// Token: 0x06001472 RID: 5234 RVA: 0x0023A6D4 File Offset: 0x002388D4
	public override void AddData(ushort Priority, ushort Key, ushort Val)
	{
		if (Key < this.KeyBegin || this.ManorBuildData.Length <= (int)(Key - this.KeyBegin))
		{
			this.AddDataFail(Priority);
			return;
		}
		Key -= this.KeyBegin;
		if (this.ManorBuildData[(int)Key].LvCondi.Count == 0)
		{
			this.ManorBuildData[(int)Key].LvCondi.Add(Val);
			this.ManorBuildData[(int)Key].Priority.Add(Priority);
		}
		else
		{
			List<ushort> lvCondi = this.ManorBuildData[(int)Key].LvCondi;
			List<ushort> priority = this.ManorBuildData[(int)Key].Priority;
			int num = lvCondi.BinarySearch(Val);
			lvCondi.Insert(~num, Val);
			num = priority.BinarySearch(Priority);
			priority.Insert(~num, Priority);
		}
	}

	// Token: 0x06001473 RID: 5235 RVA: 0x0023A7AC File Offset: 0x002389AC
	public override void AddDataFail(ushort Priority)
	{
	}

	// Token: 0x06001474 RID: 5236 RVA: 0x0023A7B0 File Offset: 0x002389B0
	public override void SetCompleteWhileLogin()
	{
	}

	// Token: 0x06001475 RID: 5237 RVA: 0x0023A7B4 File Offset: 0x002389B4
	public override bool CheckValueChanged(ushort Key, ushort Val)
	{
		Key -= this.KeyBegin;
		if (this.ManorBuildData[(int)Key].CondiVal == (int)Val)
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
				i++;
			}
		}
		else if (this.ManorBuildData[(int)Key].CondiVal > (int)Val)
		{
			if (i <= this.ManorBuildData[(int)Key].LvCondi.Count)
			{
				i = this.ManorBuildData[(int)Key].LvCondi.Count - 1;
			}
			while (i > 0)
			{
				if (this.ManorBuildData[(int)Key].LvCondi[i] < Val)
				{
					break;
				}
				i--;
			}
			if (i < 0)
			{
				i = 0;
			}
		}
		this.ManorBuildData[(int)Key].CondiVal = (int)Val;
		this.ManorBuildData[(int)Key].CheckIndex = i;
		return true;
	}

	// Token: 0x06001476 RID: 5238 RVA: 0x0023A92C File Offset: 0x00238B2C
	public override void UpdateCheckIndex(ushort Key, ushort Val)
	{
		this.ManorBuildData[(int)(Key - this.KeyBegin)].CondiVal = 0;
		this.ManorBuildData[(int)(Key - this.KeyBegin)].CheckIndex = 0;
		this.CheckValueChanged(Key, Val);
	}

	// Token: 0x06001477 RID: 5239 RVA: 0x0023A96C File Offset: 0x00238B6C
	public override void Reset()
	{
		for (int i = 0; i < this.ManorBuildData.Length; i++)
		{
			this.ManorBuildData[i].Reset();
		}
	}

	// Token: 0x06001478 RID: 5240 RVA: 0x0023A9A4 File Offset: 0x00238BA4
	public override void ClearAll()
	{
		for (int i = 0; i < this.ManorBuildData.Length; i++)
		{
			this.ManorBuildData[i].Reset();
			this.ManorBuildData[i].LvCondi.Clear();
			this.ManorBuildData[i].Priority.Clear();
		}
	}

	// Token: 0x04003D87 RID: 15751
	protected ManorCheck[] ManorBuildData;

	// Token: 0x04003D88 RID: 15752
	protected ushort KeyBegin = 1;
}
