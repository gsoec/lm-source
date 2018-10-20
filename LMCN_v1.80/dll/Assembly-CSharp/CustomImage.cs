using System;
using UnityEngine.UI;

// Token: 0x020007DA RID: 2010
public class CustomImage : Image
{
	// Token: 0x060029C8 RID: 10696 RVA: 0x0045BCC4 File Offset: 0x00459EC4
	protected override void Start()
	{
		base.Start();
		if (this.hander == null || this.ImageName == null || this.TextureName == null)
		{
			return;
		}
		this.hander.LoadCustomImage(this, this.ImageName, this.TextureName);
	}

	// Token: 0x060029C9 RID: 10697 RVA: 0x0045BD14 File Offset: 0x00459F14
	protected override void OnEnable()
	{
		base.OnEnable();
		if (this.hander == null || this.ImageName == null || this.TextureName == null)
		{
			return;
		}
		if (base.sprite == null)
		{
			this.hander.LoadCustomImage(this, this.ImageName, this.TextureName);
		}
	}

	// Token: 0x040074B4 RID: 29876
	public string ImageName;

	// Token: 0x040074B5 RID: 29877
	public string TextureName;

	// Token: 0x040074B6 RID: 29878
	public UILoadImageHander hander;
}
