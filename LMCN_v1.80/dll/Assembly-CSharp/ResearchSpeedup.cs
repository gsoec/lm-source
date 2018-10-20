using System;
using System.Collections.Generic;

// Token: 0x0200083D RID: 2109
public class ResearchSpeedup : SpeedupBase
{
	// Token: 0x06002BB6 RID: 11190 RVA: 0x0048211C File Offset: 0x0048031C
	public ResearchSpeedup(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(289u);
		this.CompleteImmContStr = mStringTable.GetStringByID(202u);
		this.CompleteImmBntStr = mStringTable.GetStringByID(215u);
		this.bFreeSpeedup = true;
		this.bImmediate = true;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = _UseItemTarget.Research;
		this.FilterType = 1;
		this.FilterType2 = 12;
	}

	// Token: 0x06002BB7 RID: 11191 RVA: 0x0048219C File Offset: 0x0048039C
	public override void SendImmediate()
	{
		DataManager.Instance.sendTechnologyResearchCompleteImmediate(0);
	}

	// Token: 0x06002BB8 RID: 11192 RVA: 0x004821AC File Offset: 0x004803AC
	public override void SendImmediateFree()
	{
		DataManager.Instance.sendTechnologyCompleteFree();
	}

	// Token: 0x06002BB9 RID: 11193 RVA: 0x004821B8 File Offset: 0x004803B8
	public override void CustomSort(List<ushort> Data, int BagCount)
	{
		if (this.CustomList == null)
		{
			this.CustomList = new List<ushort>();
		}
		this.CustomList.Clear();
		this.CustomList.AddRange(Data);
		Data.Clear();
		DataManager instance = DataManager.Instance;
		for (int i = 0; i < BagCount; i++)
		{
			if (this.CustomList[i] == 0)
			{
				Data.Add(this.CustomList[i]);
				this.CustomList.RemoveAt(i);
				BagCount--;
				i--;
			}
			else if ((byte)instance.EquipTable.GetRecordByKey(this.CustomList[i]).PropertiesInfo[0].Propertieskey == 12)
			{
				Data.Add(this.CustomList[i]);
				this.CustomList.RemoveAt(i);
				BagCount--;
				i--;
			}
		}
		Data.AddRange(this.CustomList);
	}
}
