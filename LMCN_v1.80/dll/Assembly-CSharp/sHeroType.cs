using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000329 RID: 809
internal struct sHeroType
{
	// Token: 0x06001079 RID: 4217 RVA: 0x001D59A0 File Offset: 0x001D3BA0
	public void Init()
	{
		this.Tf = new Transform[5];
		this.FrameImage = new Image[5];
		this.HeroImage = new Image[5];
		this.RankImage = new Image[5];
		this.LordsIcon1 = null;
		this.LordsIcon2 = null;
	}

	// Token: 0x040035F9 RID: 13817
	public Transform[] Tf;

	// Token: 0x040035FA RID: 13818
	public Image[] FrameImage;

	// Token: 0x040035FB RID: 13819
	public Image[] HeroImage;

	// Token: 0x040035FC RID: 13820
	public Image[] RankImage;

	// Token: 0x040035FD RID: 13821
	public Image LordsIcon1;

	// Token: 0x040035FE RID: 13822
	public Image LordsIcon2;
}
