using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200087F RID: 2175
public class UIRunningText : MonoBehaviour
{
	// Token: 0x06002D34 RID: 11572 RVA: 0x0048F31C File Offset: 0x0048D51C
	private void Start()
	{
		if (this.m_RunningText1 != null)
		{
			this.m_RunRT1 = this.m_RunningText1.GetComponent<RectTransform>();
		}
		if (this.m_RunningText2 != null)
		{
			this.m_RunRT2 = this.m_RunningText2.GetComponent<RectTransform>();
		}
	}

	// Token: 0x06002D35 RID: 11573 RVA: 0x0048F370 File Offset: 0x0048D570
	private void Update()
	{
		if (this.m_RunningText1 != null && this.m_RunRT1 != null && this.m_RunningText2 != null && this.m_RunRT2 != null)
		{
			this.tmpTime += Time.smoothDeltaTime * this.tmpLength / 10f;
			if (this.tmpTime >= this.tmpLength)
			{
				this.tmpTime = 0f;
			}
			this.Pos.Set(-this.tmpTime, this.m_RunRT1.anchoredPosition.y);
			this.m_RunRT1.anchoredPosition = this.Pos;
			this.Pos.Set(this.tmpLength - this.tmpTime, this.m_RunRT2.anchoredPosition.y);
			this.m_RunRT2.anchoredPosition = this.Pos;
		}
	}

	// Token: 0x040079D6 RID: 31190
	public UIText m_RunningText1;

	// Token: 0x040079D7 RID: 31191
	public RectTransform m_RunRT1;

	// Token: 0x040079D8 RID: 31192
	public UIText m_RunningText2;

	// Token: 0x040079D9 RID: 31193
	public RectTransform m_RunRT2;

	// Token: 0x040079DA RID: 31194
	public float tmpTime;

	// Token: 0x040079DB RID: 31195
	public float tmpLength;

	// Token: 0x040079DC RID: 31196
	private Vector2 Pos = new Vector2(0f, 0f);
}
