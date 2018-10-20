using System;
using UnityEngine.UI;

// Token: 0x0200020B RID: 523
internal struct SimulationAtkObj
{
	// Token: 0x0600098B RID: 2443 RVA: 0x000C4540 File Offset: 0x000C2740
	public void Init()
	{
		this.SelectArmy = null;
		this.BtnText = new UIText[6];
		this.Btn = new UIButton[6];
		this.SelectImage = new Image[6];
		this.CStr = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x04001FF7 RID: 8183
	public UIText SelectArmy;

	// Token: 0x04001FF8 RID: 8184
	public UIText[] BtnText;

	// Token: 0x04001FF9 RID: 8185
	public UIButton[] Btn;

	// Token: 0x04001FFA RID: 8186
	public Image[] SelectImage;

	// Token: 0x04001FFB RID: 8187
	public CString CStr;
}
