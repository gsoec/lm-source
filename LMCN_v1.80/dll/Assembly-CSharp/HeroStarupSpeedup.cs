using System;

// Token: 0x0200084A RID: 2122
public class HeroStarupSpeedup : SpeedupBase
{
	// Token: 0x06002BE1 RID: 11233 RVA: 0x00483148 File Offset: 0x00481348
	public HeroStarupSpeedup(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(226u);
		this.CompleteImmContStr = mStringTable.GetStringByID(213u);
		this.CompleteImmBntStr = mStringTable.GetStringByID(223u);
		this.bFreeSpeedup = true;
		this.bImmediate = true;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = _UseItemTarget.HeroStarup;
		this.FilterType = 1;
	}

	// Token: 0x06002BE2 RID: 11234 RVA: 0x004831C0 File Offset: 0x004813C0
	public override void SendImmediate()
	{
		DataManager.Instance.SendHeroStarUp_Instant();
	}

	// Token: 0x06002BE3 RID: 11235 RVA: 0x004831CC File Offset: 0x004813CC
	public override void SendImmediateFree()
	{
		DataManager.Instance.SendHeroStarUp_Free();
	}
}
