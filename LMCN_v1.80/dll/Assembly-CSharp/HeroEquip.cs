using System;

// Token: 0x02000567 RID: 1383
internal struct HeroEquip
{
	// Token: 0x06001B8C RID: 7052 RVA: 0x0030D1DC File Offset: 0x0030B3DC
	public HeroEquip(int len = 6)
	{
		this.IsEquip = new bool[6];
		this.IsFindItemComposite = new bool[6];
		this.EquipItemID = new ushort[6];
		this.EquipNeedLv = new ushort[6];
	}

	// Token: 0x04005379 RID: 21369
	public bool[] IsEquip;

	// Token: 0x0400537A RID: 21370
	public bool[] IsFindItemComposite;

	// Token: 0x0400537B RID: 21371
	public ushort[] EquipItemID;

	// Token: 0x0400537C RID: 21372
	public ushort[] EquipNeedLv;
}
