using System;

// Token: 0x0200032A RID: 810
internal struct sScrollItem
{
	// Token: 0x0600107A RID: 4218 RVA: 0x001D59EC File Offset: 0x001D3BEC
	public void Init()
	{
		this.bInit = false;
		this.Type = eItem.TitleType;
		this.TitleType = default(sTitleType);
		this.TitleType.Init();
		this.TextType = default(sTextType);
		this.TextType.Init();
		this.HeroType = default(sHeroType);
		this.HeroType.Init();
		this.CStr = StringManager.Instance.SpawnString(100);
		this.ArmyIconStr = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x040035FF RID: 13823
	public bool bInit;

	// Token: 0x04003600 RID: 13824
	public eItem Type;

	// Token: 0x04003601 RID: 13825
	public sTitleType TitleType;

	// Token: 0x04003602 RID: 13826
	public sTextType TextType;

	// Token: 0x04003603 RID: 13827
	public sHeroType HeroType;

	// Token: 0x04003604 RID: 13828
	public CString CStr;

	// Token: 0x04003605 RID: 13829
	public CString ArmyIconStr;
}
