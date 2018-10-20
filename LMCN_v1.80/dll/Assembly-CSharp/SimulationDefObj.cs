using System;
using UnityEngine.UI;

// Token: 0x0200020C RID: 524
internal struct SimulationDefObj
{
	// Token: 0x0600098C RID: 2444 RVA: 0x000C4580 File Offset: 0x000C2780
	public void Init()
	{
		this.SelectArmy = null;
		this.BtnText = new UIText[3];
		this.Btn = new UIButton[3];
		this.SelectImage = new Image[3];
		this.CStr = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x04001FFC RID: 8188
	public UIText SelectArmy;

	// Token: 0x04001FFD RID: 8189
	public UIText[] BtnText;

	// Token: 0x04001FFE RID: 8190
	public UIButton[] Btn;

	// Token: 0x04001FFF RID: 8191
	public Image[] SelectImage;

	// Token: 0x04002000 RID: 8192
	public CString CStr;
}
