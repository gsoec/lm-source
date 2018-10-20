using System;

// Token: 0x020003F3 RID: 1011
public class RecordAimMission : ManorAimNow
{
	// Token: 0x06001494 RID: 5268 RVA: 0x0023B310 File Offset: 0x00239510
	public RecordAimMission()
	{
		this.ManorBuildData = new ManorCheck[30];
		base.Init();
		this.HeroEnhanceNum = new byte[11];
	}

	// Token: 0x06001495 RID: 5269 RVA: 0x0023B344 File Offset: 0x00239544
	public override void AddData(ushort Priority, ushort Key, ushort Val)
	{
		if (Key == 29)
		{
			Val = ushort.MaxValue - Val;
		}
		base.AddData(Priority, Key, Val);
	}

	// Token: 0x06001496 RID: 5270 RVA: 0x0023B364 File Offset: 0x00239564
	public override void AddDataFail(ushort Priority)
	{
		DataManager.MissionDataManager.RecommandTable.RecommandID[(int)Priority] = 0;
	}

	// Token: 0x06001497 RID: 5271 RVA: 0x0023B378 File Offset: 0x00239578
	public override void SetCompleteWhileLogin()
	{
		this.UpdateHeroEnhance();
		for (ushort num = 8; num <= 18; num += 1)
		{
			this.CheckValueChanged(num, (ushort)this.HeroEnhanceNum[(int)(num - 8)]);
		}
	}

	// Token: 0x06001498 RID: 5272 RVA: 0x0023B3B4 File Offset: 0x002395B4
	public override bool CheckValueChanged(ushort Key, ushort Val)
	{
		if (Key == 19)
		{
			ushort[] defendersID = DataManager.Instance.m_DefendersID;
			this.DefenderNum = 1;
			byte b = 1;
			while ((int)b < defendersID.Length)
			{
				if (defendersID[(int)b] > 0)
				{
					this.DefenderNum += 1;
				}
				b += 1;
			}
			Val = (ushort)this.DefenderNum;
		}
		return base.CheckValueChanged(Key, Val);
	}

	// Token: 0x06001499 RID: 5273 RVA: 0x0023B418 File Offset: 0x00239618
	public void UpdateHeroEnhance()
	{
		DataManager instance = DataManager.Instance;
		this.MaxEnhanceID = 0;
		Array.Clear(this.HeroEnhanceNum, 0, this.HeroEnhanceNum.Length);
		for (uint num = 0u; num < instance.CurHeroDataCount; num += 1u)
		{
			CurHeroData curHeroData = instance.curHeroData.Find(instance.sortHeroData[(int)((UIntPtr)num)]);
			if (curHeroData.Enhance >= 2 && curHeroData.Enhance <= 12)
			{
				byte[] heroEnhanceNum = this.HeroEnhanceNum;
				byte b = curHeroData.Enhance - 2;
				heroEnhanceNum[(int)b] = heroEnhanceNum[(int)b] + 1;
			}
		}
		for (int i = this.HeroEnhanceNum.Length - 2; i >= 0; i--)
		{
			this.HeroEnhanceNum[i] = this.HeroEnhanceNum[i] + this.HeroEnhanceNum[i + 1];
		}
	}

	// Token: 0x04003D8B RID: 15755
	public byte MaxEnhanceID;

	// Token: 0x04003D8C RID: 15756
	public byte DefenderNum;

	// Token: 0x04003D8D RID: 15757
	public byte[] HeroEnhanceNum;
}
