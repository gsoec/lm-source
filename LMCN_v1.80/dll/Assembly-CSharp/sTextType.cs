using System;
using UnityEngine.UI;

// Token: 0x02000328 RID: 808
public struct sTextType
{
	// Token: 0x06001078 RID: 4216 RVA: 0x001D5968 File Offset: 0x001D3B68
	public void Init()
	{
		this.Text1 = null;
		this.Text2 = null;
		this.Hint = null;
		this.IconImage = null;
		this.iconText = null;
		this.BackgroundImage = null;
	}

	// Token: 0x040035F3 RID: 13811
	public UIText Text1;

	// Token: 0x040035F4 RID: 13812
	public UIText Text2;

	// Token: 0x040035F5 RID: 13813
	public UIButtonHint Hint;

	// Token: 0x040035F6 RID: 13814
	public Image IconImage;

	// Token: 0x040035F7 RID: 13815
	public Image BackgroundImage;

	// Token: 0x040035F8 RID: 13816
	public UIText iconText;
}
