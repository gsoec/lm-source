using System;

// Token: 0x0200083C RID: 2108
public class BuildSpeedup : SpeedupBase
{
	// Token: 0x06002BB3 RID: 11187 RVA: 0x0048200C File Offset: 0x0048020C
	public BuildSpeedup(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(288u);
		if (GUIManager.Instance.BuildingData.QueueBuildType == 1)
		{
			this.CompleteImmBntStr = mStringTable.GetStringByID(214u);
			this.bFreeSpeedup = true;
		}
		else
		{
			this.CompleteImmBntStr = mStringTable.GetStringByID(218u);
			this.bFreeSpeedup = false;
		}
		this.CompleteImmContStr = mStringTable.GetStringByID(201u);
		this.bImmediate = true;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = _UseItemTarget.Building;
		this.FilterType = 1;
		this.FilterType2 = byte.MaxValue;
	}

	// Token: 0x06002BB4 RID: 11188 RVA: 0x004820C0 File Offset: 0x004802C0
	public override void SendImmediate()
	{
		if (GUIManager.Instance.BuildingData.QueueBuildType == 1)
		{
			GUIManager.Instance.BuildingData.sendBuildFinish();
		}
		else
		{
			GUIManager.Instance.BuildingData.sendBuildDismantleFinish();
		}
	}

	// Token: 0x06002BB5 RID: 11189 RVA: 0x00482108 File Offset: 0x00480308
	public override void SendImmediateFree()
	{
		GUIManager.Instance.BuildingData.sendBuildCompleteFree();
	}
}
