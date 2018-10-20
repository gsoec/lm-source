using System;
using System.Collections.Generic;

// Token: 0x0200083E RID: 2110
public class FixwallSpeedup : SpeedupBase
{
	// Token: 0x06002BBA RID: 11194 RVA: 0x004822B4 File Offset: 0x004804B4
	public FixwallSpeedup(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(290u);
		this.CompleteImmContStr = mStringTable.GetStringByID(203u);
		this.CompleteImmBntStr = mStringTable.GetStringByID(216u);
		this.bFreeSpeedup = false;
		this.bImmediate = true;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = _UseItemTarget.ReqaireWall;
		this.FilterType = 1;
		this.FilterType2 = 17;
	}

	// Token: 0x06002BBB RID: 11195 RVA: 0x00482334 File Offset: 0x00480534
	public override void SendImmediate()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_INSTANTWALLREPAIR;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06002BBC RID: 11196 RVA: 0x00482368 File Offset: 0x00480568
	public override void SendImmediateFree()
	{
	}

	// Token: 0x06002BBD RID: 11197 RVA: 0x0048236C File Offset: 0x0048056C
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
			else if ((byte)instance.EquipTable.GetRecordByKey(this.CustomList[i]).PropertiesInfo[0].Propertieskey == 17)
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
