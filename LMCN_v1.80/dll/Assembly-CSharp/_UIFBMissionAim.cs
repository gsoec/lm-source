using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020003F9 RID: 1017
public struct _UIFBMissionAim
{
	// Token: 0x060014E5 RID: 5349 RVA: 0x0023F768 File Offset: 0x0023D968
	public _UIFBMissionAim(Transform transform, Font Font)
	{
		this.rectTransform = (transform as RectTransform);
		this.ContText = transform.GetChild(0).GetComponent<UIText>();
		this.ContText.font = Font;
		this.ContStr = StringManager.Instance.SpawnString(128);
		this._Top = this.rectTransform.anchoredPosition.y;
		this._Height = this.rectTransform.sizeDelta.y;
		this.oriFontSize = this.ContText.fontSize;
		this.ID = 0;
		this.Index = 0;
	}

	// Token: 0x17000095 RID: 149
	// (get) Token: 0x060014E7 RID: 5351 RVA: 0x0023F814 File Offset: 0x0023DA14
	// (set) Token: 0x060014E6 RID: 5350 RVA: 0x0023F808 File Offset: 0x0023DA08
	public float Height
	{
		get
		{
			return this._Height;
		}
		set
		{
			this._Height = value;
		}
	}

	// Token: 0x17000096 RID: 150
	// (get) Token: 0x060014E9 RID: 5353 RVA: 0x0023F85C File Offset: 0x0023DA5C
	// (set) Token: 0x060014E8 RID: 5352 RVA: 0x0023F81C File Offset: 0x0023DA1C
	public float Top
	{
		get
		{
			return this._Top;
		}
		set
		{
			this._Top = value;
			this.rectTransform.anchoredPosition = new Vector2(this.rectTransform.anchoredPosition.x, this._Top);
		}
	}

	// Token: 0x060014EA RID: 5354 RVA: 0x0023F864 File Offset: 0x0023DA64
	public void UpdateData()
	{
	}

	// Token: 0x060014EB RID: 5355 RVA: 0x0023F868 File Offset: 0x0023DA68
	public void TextRefresh()
	{
		this.ContText.enabled = false;
		this.ContText.enabled = true;
	}

	// Token: 0x060014EC RID: 5356 RVA: 0x0023F884 File Offset: 0x0023DA84
	public void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.ContStr);
	}

	// Token: 0x060014ED RID: 5357 RVA: 0x0023F898 File Offset: 0x0023DA98
	public void Set(ref FBMissionTbl Data, byte index)
	{
		if (Data.ID == this.ID && index == this.Index)
		{
			return;
		}
		this.ID = Data.ID;
		this.Index = index;
		this.ContText.fontSize = this.oriFontSize;
		DataManager.FBMissionDataManager.GetNarrative(this.ContStr, ref Data, this.Index, false);
		this.ContText.text = this.ContStr.ToString();
		this.ContText.SetAllDirty();
		this.ContText.cachedTextGenerator.Invalidate();
		this.ContText.cachedTextGeneratorForLayout.Invalidate();
		if (this.ContStr.Length > 0)
		{
			this.Height = this.ContText.preferredHeight;
		}
		else
		{
			this.Height = 0f;
		}
		this.ContText.rectTransform.sizeDelta = new Vector2(this.ContText.rectTransform.sizeDelta.x, this.Height);
		this.ContText.UpdateArabicPos();
		this.UpdateData();
	}

	// Token: 0x04003DC5 RID: 15813
	private RectTransform rectTransform;

	// Token: 0x04003DC6 RID: 15814
	private float _Top;

	// Token: 0x04003DC7 RID: 15815
	private float _Height;

	// Token: 0x04003DC8 RID: 15816
	private UIText ContText;

	// Token: 0x04003DC9 RID: 15817
	private CString ContStr;

	// Token: 0x04003DCA RID: 15818
	private int oriFontSize;

	// Token: 0x04003DCB RID: 15819
	private ushort ID;

	// Token: 0x04003DCC RID: 15820
	private byte Index;
}
