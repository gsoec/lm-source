using System;

// Token: 0x0200084D RID: 2125
public class PetEvolutionSpeed : SpeedupBase
{
	// Token: 0x06002BEA RID: 11242 RVA: 0x00483328 File Offset: 0x00481528
	public PetEvolutionSpeed(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(16059u);
		this.CompleteImmContStr = mStringTable.GetStringByID(16081u);
		this.CompleteImmBntStr = mStringTable.GetStringByID(223u);
		this.bFreeSpeedup = true;
		this.bImmediate = true;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = _UseItemTarget.PET_STARUP;
		this.FilterType = 1;
	}

	// Token: 0x06002BEB RID: 11243 RVA: 0x004833A0 File Offset: 0x004815A0
	public override void SendImmediate()
	{
		PetManager.Instance.Send_PET_STARUP_INSTANT(0);
	}

	// Token: 0x06002BEC RID: 11244 RVA: 0x004833B0 File Offset: 0x004815B0
	public override void SendImmediateFree()
	{
		PetManager.Instance.Send_PET_STARUP_FREECOMPLETE();
	}
}
