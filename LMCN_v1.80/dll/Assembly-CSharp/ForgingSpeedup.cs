using System;

// Token: 0x02000843 RID: 2115
public class ForgingSpeedup : SpeedupBase
{
	// Token: 0x06002BCB RID: 11211 RVA: 0x0048287C File Offset: 0x00480A7C
	public ForgingSpeedup(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(7501u);
		this.CompleteImmContStr = mStringTable.GetStringByID(7503u);
		this.CompleteImmBntStr = mStringTable.GetStringByID(7502u);
		this.bFreeSpeedup = false;
		this.bImmediate = true;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = _UseItemTarget.SunLordequip;
		this.FilterType = 1;
	}

	// Token: 0x06002BCC RID: 11212 RVA: 0x004828F4 File Offset: 0x00480AF4
	public override void SendImmediate()
	{
		LordEquipData.QuickCombineinForge();
	}

	// Token: 0x06002BCD RID: 11213 RVA: 0x004828FC File Offset: 0x00480AFC
	public override void SendImmediateFree()
	{
	}
}
