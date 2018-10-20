using System;

// Token: 0x02000848 RID: 2120
public class FixTrapSpeedup : SpeedupBase
{
	// Token: 0x06002BDB RID: 11227 RVA: 0x00483030 File Offset: 0x00481230
	public FixTrapSpeedup(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(224u);
		this.CompleteImmContStr = mStringTable.GetStringByID(211u);
		this.CompleteImmBntStr = mStringTable.GetStringByID(216u);
		this.bFreeSpeedup = false;
		this.bImmediate = true;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = _UseItemTarget.RepaireTrap;
		this.FilterType = 1;
	}

	// Token: 0x06002BDC RID: 11228 RVA: 0x004830A8 File Offset: 0x004812A8
	public override void SendImmediate()
	{
		DataManager.Instance.SendFinishPairTrap();
	}

	// Token: 0x06002BDD RID: 11229 RVA: 0x004830B4 File Offset: 0x004812B4
	public override void SendImmediateFree()
	{
	}
}
