using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000400 RID: 1024
public struct _TextUnderLine
{
	// Token: 0x17000098 RID: 152
	// (get) Token: 0x06001503 RID: 5379 RVA: 0x002404E8 File Offset: 0x0023E6E8
	// (set) Token: 0x06001502 RID: 5378 RVA: 0x00240484 File Offset: 0x0023E684
	public float Top
	{
		get
		{
			return this.recttransform.anchoredPosition.y;
		}
		set
		{
			if (this.oriTop > 10000f)
			{
				this.oriTop = this.recttransform.anchoredPosition.y;
			}
			this.recttransform.anchoredPosition = new Vector2(this.recttransform.anchoredPosition.x, this.oriTop + value);
		}
	}

	// Token: 0x06001504 RID: 5380 RVA: 0x00240508 File Offset: 0x0023E708
	public void Init(RectTransform TextRect, Font font)
	{
		this.gameobject = TextRect.gameObject;
		this.LineRect = TextRect.GetChild(0).GetComponent<RectTransform>();
		this.mText = TextRect.GetComponent<UIText>();
		this.mText.font = font;
		this.OriFontSize = this.mText.fontSize;
		this.Button = TextRect.GetChild(1).GetComponent<UIButton>();
		this.BtnRect = TextRect.GetChild(1).GetComponent<RectTransform>();
		this.Button.SoundIndex = byte.MaxValue;
		this.Str = StringManager.Instance.SpawnString(64);
		this.recttransform = TextRect;
		this.oriTop = 100001f;
		this.BtnRect.sizeDelta = new Vector2(185f, 38f);
		this.BtnRect.anchoredPosition = new Vector2(-50f, 15f);
	}

	// Token: 0x06001505 RID: 5381 RVA: 0x002405E8 File Offset: 0x0023E7E8
	public void SetText(string str)
	{
		this.mText.fontSize = this.OriFontSize;
		this.mText.text = str;
		this.mText.SetAllDirty();
		this.mText.cachedTextGenerator.Invalidate();
		this.mText.cachedTextGeneratorForLayout.Invalidate();
		float num = 0f;
		if (this.TextHandle != null)
		{
			this.Str.ClearString();
			this.Str.Append(str);
			num = this.TextHandle.TextLenCheck(this.mText, this.Str);
		}
		this.LineRect.sizeDelta = new Vector2(num, this.LineRect.sizeDelta.y);
		this.BtnRect.gameObject.SetActive(num > 0f);
		if (GUIManager.Instance.IsArabic)
		{
			this.LineRect.anchoredPosition = new Vector2(this.mText.rectTransform.sizeDelta.x - num, this.LineRect.anchoredPosition.y);
		}
	}

	// Token: 0x06001506 RID: 5382 RVA: 0x00240710 File Offset: 0x0023E910
	public void TextRefresh()
	{
		this.mText.enabled = false;
		this.mText.enabled = true;
	}

	// Token: 0x06001507 RID: 5383 RVA: 0x0024072C File Offset: 0x0023E92C
	public void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.Str);
	}

	// Token: 0x04003DEF RID: 15855
	public GameObject gameobject;

	// Token: 0x04003DF0 RID: 15856
	private RectTransform LineRect;

	// Token: 0x04003DF1 RID: 15857
	private RectTransform BtnRect;

	// Token: 0x04003DF2 RID: 15858
	private RectTransform recttransform;

	// Token: 0x04003DF3 RID: 15859
	private CString Str;

	// Token: 0x04003DF4 RID: 15860
	private UIText mText;

	// Token: 0x04003DF5 RID: 15861
	public UIButton Button;

	// Token: 0x04003DF6 RID: 15862
	private int OriFontSize;

	// Token: 0x04003DF7 RID: 15863
	public _CheckTextHandle TextHandle;

	// Token: 0x04003DF8 RID: 15864
	private float oriTop;
}
