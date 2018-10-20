using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020007C6 RID: 1990
public class ArabicItemTextureRot : BaseVertexEffect
{
	// Token: 0x06002923 RID: 10531 RVA: 0x0044E4F0 File Offset: 0x0044C6F0
	public override void ModifyVertices(List<UIVertex> verts)
	{
		if (!GUIManager.Instance.IsArabic)
		{
			return;
		}
		int num = verts.Count >> 2;
		for (int i = 0; i < num; i++)
		{
			int num2 = i << 2;
			UIVertex value = verts[num2];
			UIVertex value2 = verts[num2 + 3];
			Vector2 uv = value.uv0;
			value.uv0 = value2.uv0;
			value2.uv0 = uv;
			verts[num2] = value;
			verts[num2 + 3] = value2;
			value = verts[num2 + 1];
			value2 = verts[num2 + 2];
			uv = value.uv0;
			value.uv0 = value2.uv0;
			value2.uv0 = uv;
			verts[num2 + 1] = value;
			verts[num2 + 2] = value2;
		}
	}
}
