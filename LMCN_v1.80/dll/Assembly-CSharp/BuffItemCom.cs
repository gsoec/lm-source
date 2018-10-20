using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000501 RID: 1281
internal struct BuffItemCom
{
	// Token: 0x0600199B RID: 6555 RVA: 0x002B76CC File Offset: 0x002B58CC
	public void Init()
	{
		this.m_Outline = new Outline[2];
		this.m_Shadow = new Shadow[2];
		this.m_Colum = new GameObject[2];
		this.m_ColumRect = new RectTransform[2];
		this.m_Text = new UIText[2];
		this.m_Image = new Image[2];
	}

	// Token: 0x04004C34 RID: 19508
	public GameObject[] m_Colum;

	// Token: 0x04004C35 RID: 19509
	public RectTransform[] m_ColumRect;

	// Token: 0x04004C36 RID: 19510
	public UIText[] m_Text;

	// Token: 0x04004C37 RID: 19511
	public Image[] m_Image;

	// Token: 0x04004C38 RID: 19512
	public Outline[] m_Outline;

	// Token: 0x04004C39 RID: 19513
	public Shadow[] m_Shadow;
}
