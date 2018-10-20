using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000887 RID: 2183
public class UITextBoundCheck : BaseVertexEffect
{
	// Token: 0x06002D5B RID: 11611 RVA: 0x0049086C File Offset: 0x0048EA6C
	protected override void Start()
	{
		this.textComponent = base.transform.GetComponent<Text>();
	}

	// Token: 0x06002D5C RID: 11612 RVA: 0x00490880 File Offset: 0x0048EA80
	public override void ModifyVertices(List<UIVertex> verts)
	{
		if (!this.IsActive())
		{
			return;
		}
		if (this.textComponent == null || this.textComponent.alignment == TextAnchor.LowerLeft || this.textComponent.alignment == TextAnchor.MiddleLeft || this.textComponent.alignment == TextAnchor.UpperLeft)
		{
			return;
		}
		Rect rect = this.textComponent.rectTransform.rect;
		IList<UILineInfo> lines = this.textComponent.cachedTextGenerator.lines;
		for (int i = 0; i < lines.Count; i++)
		{
			int num = lines[i].startCharIdx * 4;
			if (verts.Count <= num)
			{
				break;
			}
			if (!rect.Contains(verts[num].position))
			{
				int num2;
				if (i + 1 < lines.Count)
				{
					num2 = lines[i + 1].startCharIdx - 1;
					if (num2 * 4 >= verts.Count)
					{
						num2 = (verts.Count >> 2) - 1;
					}
				}
				else
				{
					num2 = (verts.Count >> 2) - 1;
				}
				if (num2 != lines[i].startCharIdx)
				{
					float num3 = rect.xMin - verts[num].position.x;
					float num4;
					if (this.textComponent.alignment == TextAnchor.LowerCenter || this.textComponent.alignment == TextAnchor.MiddleCenter || this.textComponent.alignment == TextAnchor.UpperCenter)
					{
						num4 = (rect.width - (verts[num2 * 4 + 1].position.x - verts[num].position.x)) * 0.5f;
					}
					else
					{
						num4 = rect.width - (verts[num2 * 4 + 1].position.x - verts[num].position.x);
					}
					num3 += num4;
					for (int j = lines[i].startCharIdx; j < num2; j++)
					{
						num = j * 4;
						if (num >= verts.Count)
						{
							break;
						}
						for (int k = 0; k < 4; k++)
						{
							UIVertex value = verts[num + k];
							value.position.Set(value.position.x + num3, value.position.y, value.position.z);
							verts[num + k] = value;
						}
					}
					Debug.Log("OutSide..");
				}
			}
		}
	}

	// Token: 0x040079F8 RID: 31224
	private Text textComponent;
}
