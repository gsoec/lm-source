using System;

// Token: 0x02000842 RID: 2114
public class MissionVIPSpeedup : SpeedupBase
{
	// Token: 0x06002BC8 RID: 11208 RVA: 0x004827F4 File Offset: 0x004809F4
	public MissionVIPSpeedup(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(294u);
		this.CompleteImmContStr = mStringTable.GetStringByID(207u);
		this.CompleteImmBntStr = mStringTable.GetStringByID(218u);
		this.bFreeSpeedup = false;
		this.bImmediate = true;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = _UseItemTarget.VIPMission;
		this.FilterType = 1;
	}

	// Token: 0x06002BC9 RID: 11209 RVA: 0x0048286C File Offset: 0x00480A6C
	public override void SendImmediate()
	{
		DataManager.MissionDataManager.sendVipMissionImmed();
	}

	// Token: 0x06002BCA RID: 11210 RVA: 0x00482878 File Offset: 0x00480A78
	public override void SendImmediateFree()
	{
	}
}
