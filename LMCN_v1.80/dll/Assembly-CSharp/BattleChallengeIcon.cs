using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001F0 RID: 496
internal struct BattleChallengeIcon
{
	// Token: 0x06000906 RID: 2310 RVA: 0x000B7EE0 File Offset: 0x000B60E0
	public void Init()
	{
		this.Btn = null;
		this.Background = null;
		this.Frame = null;
		this.Item = null;
	}

	// Token: 0x04001DE1 RID: 7649
	public GameObject gameObj;

	// Token: 0x04001DE2 RID: 7650
	public UIButton Btn;

	// Token: 0x04001DE3 RID: 7651
	public Image Background;

	// Token: 0x04001DE4 RID: 7652
	public Image Frame;

	// Token: 0x04001DE5 RID: 7653
	public Image Item;
}
