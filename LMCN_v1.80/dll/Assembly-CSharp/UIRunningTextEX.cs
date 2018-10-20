using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000880 RID: 2176
public class UIRunningTextEX : MonoBehaviour
{
	// Token: 0x1700016F RID: 367
	// (get) Token: 0x06002D37 RID: 11575 RVA: 0x0048F498 File Offset: 0x0048D698
	private RectTransform m_RC
	{
		get
		{
			if (this.RC == null)
			{
				this.RC = base.transform.GetComponent<RectTransform>();
			}
			return this.RC;
		}
	}

	// Token: 0x06002D38 RID: 11576 RVA: 0x0048F4D0 File Offset: 0x0048D6D0
	private void Update()
	{
		if (this.m_RunningText1 != null && this.m_RunningText2 != null)
		{
			this.Delta = Time.smoothDeltaTime * (float)this.Speed * 1.5f;
			this.Pos.Set(this.Delta, 0f);
			if (this.m_RunningText1.enabled)
			{
				RectTransform rectTransform = this.m_RunningText1.rectTransform;
				rectTransform.anchoredPosition -= this.Pos;
				if (rectTransform.anchoredPosition.x + rectTransform.sizeDelta.x <= this.m_RC.anchoredPosition.x)
				{
					this.SetStr(1);
				}
			}
			if (this.m_RunningText2.enabled)
			{
				RectTransform rectTransform2 = this.m_RunningText2.rectTransform;
				rectTransform2.anchoredPosition -= this.Pos;
				if (rectTransform2.anchoredPosition.x + rectTransform2.sizeDelta.x <= this.m_RC.anchoredPosition.x)
				{
					this.SetStr(2);
				}
			}
			if (!this.m_RunningText1.enabled && !this.m_RunningText2.enabled)
			{
				base.gameObject.SetActive(false);
				GUIManager.Instance.ClearWonderStr();
				GUIManager.Instance.ClearKOWStr();
				GamblingManager.Instance.ClearGambleStr();
			}
		}
	}

	// Token: 0x06002D39 RID: 11577 RVA: 0x0048F65C File Offset: 0x0048D85C
	public void SetStr(byte Indedx)
	{
		UIText uitext;
		RectTransform rectTransform;
		RectTransform rectTransform2;
		if (Indedx == 1)
		{
			uitext = this.m_RunningText1;
			rectTransform = this.m_RunningText1.rectTransform;
			rectTransform2 = this.m_RunningText2.rectTransform;
		}
		else
		{
			uitext = this.m_RunningText2;
			rectTransform = this.m_RunningText2.rectTransform;
			rectTransform2 = this.m_RunningText1.rectTransform;
		}
		GUIManager instance = GUIManager.Instance;
		if (instance.m_RunningTextList.Count > 0)
		{
			uitext.enabled = true;
			uitext.text = instance.m_RunningTextList[0].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			uitext.cachedTextGeneratorForLayout.Invalidate();
			instance.m_RunningTextList.RemoveAt(0);
			rectTransform.sizeDelta = new Vector2(uitext.preferredWidth + 5f, rectTransform.sizeDelta.y);
			rectTransform.anchoredPosition = new Vector2(rectTransform2.anchoredPosition.x + rectTransform2.sizeDelta.x + this.m_RC.sizeDelta.x, rectTransform.anchoredPosition.y);
		}
		else
		{
			uitext.enabled = false;
		}
	}

	// Token: 0x06002D3A RID: 11578 RVA: 0x0048F790 File Offset: 0x0048D990
	public void CheckAddStr()
	{
		if (!base.gameObject.activeInHierarchy)
		{
			GUIManager instance = GUIManager.Instance;
			if (instance.m_RunningTextList.Count > 0)
			{
				base.gameObject.SetActive(true);
				this.m_RunningText1.enabled = true;
				this.m_RunningText1.text = instance.m_RunningTextList[0].ToString();
				this.m_RunningText1.SetAllDirty();
				this.m_RunningText1.cachedTextGenerator.Invalidate();
				this.m_RunningText1.cachedTextGeneratorForLayout.Invalidate();
				this.m_RunningText1.rectTransform.sizeDelta = new Vector2(this.m_RunningText1.preferredWidth + 5f, this.m_RunningText1.rectTransform.sizeDelta.y);
				this.m_RunningText1.rectTransform.anchoredPosition = new Vector2(this.m_RC.sizeDelta.x, this.m_RunningText1.rectTransform.anchoredPosition.y);
				instance.m_RunningTextList.RemoveAt(0);
			}
			if (instance.m_RunningTextList.Count > 0)
			{
				this.m_RunningText2.enabled = true;
				this.m_RunningText2.text = instance.m_RunningTextList[0].ToString();
				this.m_RunningText2.SetAllDirty();
				this.m_RunningText2.cachedTextGenerator.Invalidate();
				this.m_RunningText2.cachedTextGeneratorForLayout.Invalidate();
				instance.m_RunningTextList.RemoveAt(0);
				this.m_RunningText2.rectTransform.sizeDelta = new Vector2(this.m_RunningText2.preferredWidth + 5f, this.m_RunningText2.rectTransform.sizeDelta.y);
				this.m_RunningText2.rectTransform.anchoredPosition = new Vector2(this.m_RC.sizeDelta.x + this.m_RunningText1.preferredWidth + 5f + this.m_RC.sizeDelta.x, this.m_RunningText2.rectTransform.anchoredPosition.y);
			}
			else
			{
				this.m_RunningText2.enabled = false;
			}
		}
		else
		{
			if (this.m_RunningText1.enabled && !this.m_RunningText2.enabled)
			{
				this.SetStr(2);
			}
			if (!this.m_RunningText1.enabled && this.m_RunningText2.enabled)
			{
				this.SetStr(1);
			}
		}
	}

	// Token: 0x040079DD RID: 31197
	private RectTransform RC;

	// Token: 0x040079DE RID: 31198
	public UIText m_RunningText1;

	// Token: 0x040079DF RID: 31199
	public UIText m_RunningText2;

	// Token: 0x040079E0 RID: 31200
	public float Delta;

	// Token: 0x040079E1 RID: 31201
	public float UnitWidth;

	// Token: 0x040079E2 RID: 31202
	public int Speed = 25;

	// Token: 0x040079E3 RID: 31203
	private Vector2 Pos = new Vector2(0f, 0f);
}
