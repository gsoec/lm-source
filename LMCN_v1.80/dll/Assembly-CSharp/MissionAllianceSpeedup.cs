using System;

// Token: 0x02000841 RID: 2113
public class MissionAllianceSpeedup : SpeedupBase
{
	// Token: 0x06002BC5 RID: 11205 RVA: 0x004826F8 File Offset: 0x004808F8
	public MissionAllianceSpeedup(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(293u);
		this.CompleteImmContStr = mStringTable.GetStringByID(206u);
		this.CompleteImmBntStr = mStringTable.GetStringByID(218u);
		this.bFreeSpeedup = false;
		this.bImmediate = true;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = _UseItemTarget.AllianceMission;
		this.FilterType = 1;
	}

	// Token: 0x06002BC6 RID: 11206 RVA: 0x00482770 File Offset: 0x00480970
	public override void SendImmediate()
	{
		if (DataManager.MissionDataManager.TimerMissionData[1].ProcessIdx == 255)
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
		messagePacket.Add(2);
		messagePacket.Add(DataManager.MissionDataManager.TimerMissionData[1].ProcessIdx + 1);
		messagePacket.Send(false);
	}

	// Token: 0x06002BC7 RID: 11207 RVA: 0x004827F0 File Offset: 0x004809F0
	public override void SendImmediateFree()
	{
	}
}
