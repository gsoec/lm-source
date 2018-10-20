using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200005B RID: 91
public class DamageValue
{
	// Token: 0x04000475 RID: 1141
	public HERO_EFFECTTYPE_ENUM Type;

	// Token: 0x04000476 RID: 1142
	public float fShowTime;

	// Token: 0x04000477 RID: 1143
	public float fTime;

	// Token: 0x04000478 RID: 1144
	public int iOffset;

	// Token: 0x04000479 RID: 1145
	public byte side;

	// Token: 0x0400047A RID: 1146
	public bool bNumber;

	// Token: 0x0400047B RID: 1147
	public bool bCritical;

	// Token: 0x0400047C RID: 1148
	public GameObject m_GameObject;

	// Token: 0x0400047D RID: 1149
	public Transform m_transform;

	// Token: 0x0400047E RID: 1150
	public UIText m_Text;

	// Token: 0x0400047F RID: 1151
	public RectTransform m_RT;
}
