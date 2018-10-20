using System;
using System.Collections.Generic;

// Token: 0x0200083F RID: 2111
public class TreatmentingSpeedup : SpeedupBase
{
	// Token: 0x06002BBE RID: 11198 RVA: 0x00482468 File Offset: 0x00480668
	public TreatmentingSpeedup(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(291u);
		this.CompleteImmContStr = mStringTable.GetStringByID(204u);
		this.CompleteImmBntStr = mStringTable.GetStringByID(217u);
		this.bFreeSpeedup = false;
		this.bImmediate = true;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = _UseItemTarget.Healing;
		this.FilterType = 1;
		this.FilterType2 = 18;
	}

	// Token: 0x06002BBF RID: 11199 RVA: 0x004824E8 File Offset: 0x004806E8
	public override void SendImmediate()
	{
		DataManager.Instance.SendFinishhealing();
	}

	// Token: 0x06002BC0 RID: 11200 RVA: 0x004824F4 File Offset: 0x004806F4
	public override void SendImmediateFree()
	{
		DataManager.Instance.SendFinishhealing();
	}

	// Token: 0x06002BC1 RID: 11201 RVA: 0x00482500 File Offset: 0x00480700
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
			else if ((byte)instance.EquipTable.GetRecordByKey(this.CustomList[i]).PropertiesInfo[0].Propertieskey == 18)
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
