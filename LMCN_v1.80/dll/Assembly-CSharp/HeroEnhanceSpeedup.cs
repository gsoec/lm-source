using System;

// Token: 0x02000849 RID: 2121
public class HeroEnhanceSpeedup : SpeedupBase
{
	// Token: 0x06002BDE RID: 11230 RVA: 0x004830B8 File Offset: 0x004812B8
	public HeroEnhanceSpeedup(EQueueBarIndex QueueBar)
	{
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.MainTitleStr = mStringTable.GetStringByID(225u);
		this.CompleteImmContStr = mStringTable.GetStringByID(212u);
		this.CompleteImmBntStr = mStringTable.GetStringByID(222u);
		this.bFreeSpeedup = true;
		this.bImmediate = true;
		this.QueueBar = (byte)QueueBar;
		this.UseTarget = _UseItemTarget.HeroEnhance;
		this.FilterType = 1;
	}

	// Token: 0x06002BDF RID: 11231 RVA: 0x00483130 File Offset: 0x00481330
	public override void SendImmediate()
	{
		DataManager.Instance.SendHeroEnhance_Instant();
	}

	// Token: 0x06002BE0 RID: 11232 RVA: 0x0048313C File Offset: 0x0048133C
	public override void SendImmediateFree()
	{
		DataManager.Instance.SendHeroEnhance_Free();
	}
}
