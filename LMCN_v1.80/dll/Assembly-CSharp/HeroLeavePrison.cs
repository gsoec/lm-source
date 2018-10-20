using System;

// Token: 0x0200084B RID: 2123
public class HeroLeavePrison : SpeedupBase
{
	// Token: 0x06002BE4 RID: 11236 RVA: 0x004831D8 File Offset: 0x004813D8
	public HeroLeavePrison(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(298u);
		this.CompleteImmContStr = mStringTable.GetStringByID(212u);
		this.CompleteImmBntStr = mStringTable.GetStringByID(222u);
		this.bFreeSpeedup = false;
		this.bImmediate = false;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = (_UseItemTarget)DataManager.Instance.MarchEventData.Length;
		this.FilterType = 11;
	}

	// Token: 0x06002BE5 RID: 11237 RVA: 0x0048325C File Offset: 0x0048145C
	public override void SendImmediate()
	{
	}

	// Token: 0x06002BE6 RID: 11238 RVA: 0x00483260 File Offset: 0x00481460
	public override void SendImmediateFree()
	{
	}
}
