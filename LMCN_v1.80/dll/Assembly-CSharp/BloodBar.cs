using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200005C RID: 92
public class BloodBar
{
	// Token: 0x04000480 RID: 1152
	public bool bShow;

	// Token: 0x04000481 RID: 1153
	public bool bForceShowBlood;

	// Token: 0x04000482 RID: 1154
	public float fTime;

	// Token: 0x04000483 RID: 1155
	public float DeltaX;

	// Token: 0x04000484 RID: 1156
	public float TargetWidth;

	// Token: 0x04000485 RID: 1157
	public bool bShowState;

	// Token: 0x04000486 RID: 1158
	public GameObject m_GameObject;

	// Token: 0x04000487 RID: 1159
	public Transform m_transform;

	// Token: 0x04000488 RID: 1160
	public RectTransform m_RT;

	// Token: 0x04000489 RID: 1161
	public Transform m_BarTransform;

	// Token: 0x0400048A RID: 1162
	public RectTransform[] m_BarRT = new RectTransform[3];

	// Token: 0x0400048B RID: 1163
	public Image[] m_BarImg = new Image[3];

	// Token: 0x0400048C RID: 1164
	public Transform m_IconTransform;

	// Token: 0x0400048D RID: 1165
	public RectTransform[] m_IconRT = new RectTransform[3];

	// Token: 0x0400048E RID: 1166
	public Image[] m_IconImg = new Image[3];

	// Token: 0x0400048F RID: 1167
	public int[] FadeNum = new int[3];

	// Token: 0x04000490 RID: 1168
	public byte[] StateID = new byte[3];
}
