using System;

// Token: 0x02000847 RID: 2119
public class TrapSpeedup : SpeedupBase
{
	// Token: 0x06002BD8 RID: 11224 RVA: 0x00482FA8 File Offset: 0x004811A8
	public TrapSpeedup(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(297u);
		this.CompleteImmContStr = mStringTable.GetStringByID(210u);
		this.CompleteImmBntStr = mStringTable.GetStringByID(221u);
		this.bFreeSpeedup = false;
		this.bImmediate = true;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = _UseItemTarget.ConstructTrap;
		this.FilterType = 1;
	}

	// Token: 0x06002BD9 RID: 11225 RVA: 0x00483020 File Offset: 0x00481220
	public override void SendImmediate()
	{
		DataManager.Instance.SendFinishTrapConstrct();
	}

	// Token: 0x06002BDA RID: 11226 RVA: 0x0048302C File Offset: 0x0048122C
	public override void SendImmediateFree()
	{
	}
}
