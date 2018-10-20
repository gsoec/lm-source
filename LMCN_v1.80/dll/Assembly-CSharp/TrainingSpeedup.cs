using System;
using System.Collections.Generic;

// Token: 0x02000846 RID: 2118
public class TrainingSpeedup : SpeedupBase
{
	// Token: 0x06002BD4 RID: 11220 RVA: 0x00482E1C File Offset: 0x0048101C
	public TrainingSpeedup(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(296u);
		this.CompleteImmContStr = mStringTable.GetStringByID(209u);
		this.CompleteImmBntStr = mStringTable.GetStringByID(220u);
		this.bFreeSpeedup = false;
		this.bImmediate = true;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = _UseItemTarget.Trainging;
		this.FilterType = 1;
		this.FilterType2 = 21;
	}

	// Token: 0x06002BD5 RID: 11221 RVA: 0x00482E9C File Offset: 0x0048109C
	public override void SendImmediate()
	{
		DataManager.Instance.SendFinishtraining();
	}

	// Token: 0x06002BD6 RID: 11222 RVA: 0x00482EA8 File Offset: 0x004810A8
	public override void SendImmediateFree()
	{
	}

	// Token: 0x06002BD7 RID: 11223 RVA: 0x00482EAC File Offset: 0x004810AC
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
			else if ((byte)instance.EquipTable.GetRecordByKey(this.CustomList[i]).PropertiesInfo[0].Propertieskey == 21)
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
