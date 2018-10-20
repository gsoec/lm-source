using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000401 RID: 1025
public struct _UIFBSelf
{
	// Token: 0x06001508 RID: 5384 RVA: 0x00240740 File Offset: 0x0023E940
	public _UIFBSelf(Transform transform, Font font)
	{
		this.recttransform = transform.GetComponent<RectTransform>();
		this.gameobject = transform.gameObject;
		this.Title = this.recttransform.GetChild(0).GetChild(1).GetComponent<UIText>();
		this.Title.font = font;
		this.Title.text = DataManager.Instance.mStringTable.GetStringByID(12165u);
		this.LordsTrans = transform.GetChild(0).GetChild(0);
		GUIManager.Instance.InitianHeroItemImg(this.LordsTrans, eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, 11, 0, 0, false, false, true, false);
		this.SelfRect = transform.GetChild(0).GetComponent<RectTransform>();
		this.bInitSize = 0;
		this.Style = _UIFBSelf._Style.Narrow;
	}

	// Token: 0x17000099 RID: 153
	// (set) Token: 0x06001509 RID: 5385 RVA: 0x0024080C File Offset: 0x0023EA0C
	public float Top
	{
		set
		{
			this.recttransform.anchoredPosition = new Vector2(this.recttransform.anchoredPosition.x, value);
		}
	}

	// Token: 0x1700009A RID: 154
	// (get) Token: 0x0600150A RID: 5386 RVA: 0x00240840 File Offset: 0x0023EA40
	public float Width
	{
		get
		{
			return this.recttransform.sizeDelta.x;
		}
	}

	// Token: 0x1700009B RID: 155
	// (get) Token: 0x0600150B RID: 5387 RVA: 0x00240860 File Offset: 0x0023EA60
	// (set) Token: 0x0600150C RID: 5388 RVA: 0x00240880 File Offset: 0x0023EA80
	public float Height
	{
		get
		{
			return this.recttransform.sizeDelta.y;
		}
		set
		{
			this.recttransform.sizeDelta = new Vector2(this.recttransform.sizeDelta.x, value);
		}
	}

	// Token: 0x0600150D RID: 5389 RVA: 0x002408B4 File Offset: 0x0023EAB4
	public void Show(_UIFBSelf._Style style)
	{
		this.gameobject.SetActive(true);
		if (this.Style != style)
		{
			this.Style = style;
			this.bInitSize = 0;
			if (this.Style == _UIFBSelf._Style.Narrow)
			{
				this.recttransform.sizeDelta = new Vector2(330f, this.recttransform.sizeDelta.y);
			}
			else
			{
				this.recttransform.sizeDelta = new Vector2(624f, this.recttransform.sizeDelta.y);
			}
		}
		if (this.bInitSize == 0)
		{
			this.bInitSize = 1;
			float num = this.Title.preferredWidth;
			float num2 = this.recttransform.sizeDelta.x - 110f;
			if (num > num2)
			{
				this.Title.resizeTextForBestFit = true;
				num = num2;
			}
			this.Title.rectTransform.sizeDelta = new Vector2(num, this.Title.rectTransform.sizeDelta.y);
			float x = (this.recttransform.sizeDelta.x - this.Title.rectTransform.anchoredPosition.x - num) * 0.5f;
			this.SelfRect.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, this.recttransform.anchoredPosition.y);
		}
	}

	// Token: 0x0600150E RID: 5390 RVA: 0x00240A28 File Offset: 0x0023EC28
	public void Hide()
	{
		this.gameobject.SetActive(false);
	}

	// Token: 0x0600150F RID: 5391 RVA: 0x00240A38 File Offset: 0x0023EC38
	public void TextRefresh()
	{
		this.Title.enabled = false;
		this.Title.enabled = true;
	}

	// Token: 0x04003DF9 RID: 15865
	private GameObject gameobject;

	// Token: 0x04003DFA RID: 15866
	private RectTransform recttransform;

	// Token: 0x04003DFB RID: 15867
	private RectTransform SelfRect;

	// Token: 0x04003DFC RID: 15868
	private Transform LordsTrans;

	// Token: 0x04003DFD RID: 15869
	private UIText Title;

	// Token: 0x04003DFE RID: 15870
	private byte bInitSize;

	// Token: 0x04003DFF RID: 15871
	private _UIFBSelf._Style Style;

	// Token: 0x02000402 RID: 1026
	public enum _Style
	{
		// Token: 0x04003E01 RID: 15873
		Narrow,
		// Token: 0x04003E02 RID: 15874
		Wide
	}
}
