using System;

// Token: 0x02000840 RID: 2112
public class MissionAffairSpeedup : SpeedupBase
{
	// Token: 0x06002BC2 RID: 11202 RVA: 0x004825FC File Offset: 0x004807FC
	public MissionAffairSpeedup(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(292u);
		this.CompleteImmContStr = mStringTable.GetStringByID(205u);
		this.CompleteImmBntStr = mStringTable.GetStringByID(218u);
		this.bFreeSpeedup = false;
		this.bImmediate = true;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = _UseItemTarget.AffairMission;
		this.FilterType = 1;
	}

	// Token: 0x06002BC3 RID: 11203 RVA: 0x00482674 File Offset: 0x00480874
	public override void SendImmediate()
	{
		if (DataManager.MissionDataManager.TimerMissionData[0].ProcessIdx == 255)
		{
			return;
		}
		if (!GUIManager.Instance.ShowUILock(EUILock.Mission))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_MISSION_BOOST;
		messagePacket.AddSeqId();
		messagePacket.Add(1);
		messagePacket.Add(DataManager.MissionDataManager.TimerMissionData[0].ProcessIdx + 1);
		messagePacket.Send(false);
	}

	// Token: 0x06002BC4 RID: 11204 RVA: 0x004826F4 File Offset: 0x004808F4
	public override void SendImmediateFree()
	{
	}
}
