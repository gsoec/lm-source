using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000752 RID: 1874
public class HUDItem
{
	// Token: 0x06002406 RID: 9222 RVA: 0x0041D34C File Offset: 0x0041B54C
	public void Init(int index, Transform transform)
	{
		this.Index = index;
		this.ThisTransform = transform;
		this.Alpha = this.ThisTransform.GetComponent<CanvasGroup>();
		this.IconTransform = this.ThisTransform.GetChild(0).GetComponent<RectTransform>();
		this.Icon = this.ThisTransform.GetChild(0).GetComponent<Image>();
		this.TextureRot = this.IconTransform.GetComponent<ArabicItemTextureRot>();
		this.MsgText = this.ThisTransform.GetChild(1).GetComponent<UIText>();
		this.MsgText.font = GUIManager.Instance.GetTTFFont();
		this.MsgStr = StringManager.Instance.SpawnString(160);
		this.IconStr = StringManager.Instance.SpawnString(30);
		this.bColseItem = false;
	}

	// Token: 0x06002407 RID: 9223 RVA: 0x0041D414 File Offset: 0x0041B614
	public void CloneText(string text)
	{
		this.MsgStr.ClearString();
		this.MsgStr.Append(text);
		this.MsgText.text = this.MsgStr.ToString();
		this.MsgText.SetAllDirty();
		this.MsgText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06002408 RID: 9224 RVA: 0x0041D46C File Offset: 0x0041B66C
	public void AddMessage(string Msg, ushort ID)
	{
		HUDTypeTbl recordByKey = DataManager.Instance.HUDTypeData.GetRecordByKey(ID);
		this.ThisTransform.gameObject.SetActive(true);
		this.Alpha.alpha = 0f;
		this.FadeTime = -0.5f;
		this.ShowIconTime = 0f;
		this.MsgStr.ClearString();
		this.MsgStr.Append(Msg);
		this.MsgText.text = this.MsgStr.ToString();
		this.MsgText.SetAllDirty();
		this.MsgText.cachedTextGenerator.Invalidate();
		if (recordByKey.TextColor > 0 && HUDMessageMgr.HUDColor.Length >= (int)recordByKey.TextColor)
		{
			this.MsgText.color = HUDMessageMgr.HUDColor[(int)(recordByKey.TextColor - 1)];
		}
		else
		{
			this.MsgText.color = Color.white;
		}
		this.IconStr.ClearString();
		this.IconStr.IntToFormat((long)recordByKey.Graphic, 3, false);
		this.IconStr.AppendFormat("icon{0}");
		if (recordByKey.Graphic == 33 || recordByKey.Graphic == 55)
		{
			if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
			{
				this.IconStr.Append("_cn");
			}
			else if (GUIManager.Instance.IsArabic)
			{
				this.TextureRot.enabled = true;
			}
		}
		else if (recordByKey.Graphic == 39)
		{
			if (GUIManager.Instance.IsArabic)
			{
				this.TextureRot.enabled = true;
			}
		}
		else
		{
			this.TextureRot.enabled = false;
		}
		this.Icon.sprite = GUIManager.Instance.LoadFrameSprite(this.IconStr);
		this.Icon.material = GUIManager.Instance.GetFrameMaterial();
		if (this.Icon.sprite == null)
		{
			this.Icon.sprite = GUIManager.Instance.LoadFrameSprite("icon021");
		}
		this.DelayTime = (float)(recordByKey.DelayTime / 10);
		if (recordByKey.Sound == 0u)
		{
			this.SFXKind = UIKind.None;
		}
		else
		{
			this.SFXKind = (UIKind)recordByKey.Sound;
		}
		this.MP3Sound = recordByKey.Mp3Sound;
		this.bColseItem = true;
	}

	// Token: 0x06002409 RID: 9225 RVA: 0x0041D6DC File Offset: 0x0041B8DC
	public void Destroy()
	{
		StringManager.Instance.DeSpawnString(this.MsgStr);
		StringManager.Instance.DeSpawnString(this.IconStr);
	}

	// Token: 0x0600240A RID: 9226 RVA: 0x0041D70C File Offset: 0x0041B90C
	public void Update()
	{
		if (!this.bColseItem)
		{
			return;
		}
		float unscaledDeltaTime = Time.unscaledDeltaTime;
		if (this.SFXKind != UIKind.None)
		{
			if (this.MP3Sound == 1)
			{
				AudioManager.Instance.PlayMP3SFX((ushort)this.SFXKind, 0f);
			}
			else
			{
				AudioManager.Instance.PlayUISFX(this.SFXKind);
			}
			this.SFXKind = UIKind.None;
		}
		if (this.ShowIconTime < 0.25f)
		{
			Vector3 localScale = this.IconTransform.localScale;
			localScale = Vector3.one * HUDMessageMgr.Quintic(this.ShowIconTime, 0f, 1f, 0.25f);
			this.IconTransform.localScale = localScale;
			this.ShowIconTime += unscaledDeltaTime;
		}
		else
		{
			this.IconTransform.localScale = Vector3.one;
		}
		if (this.DelayTime >= 0f)
		{
			this.Alpha.alpha = 1f;
		}
		else
		{
			this.Alpha.alpha = 1f - this.DelayTime / this.FadeTime;
			if (this.Alpha.alpha <= 0.01f)
			{
				this.ThisTransform.gameObject.SetActive(false);
				if (this.Handle != null)
				{
					this.Handle.OnDestroyMessage(this.Index);
					this.bColseItem = false;
				}
			}
		}
		this.DelayTime -= unscaledDeltaTime;
	}

	// Token: 0x04006DE4 RID: 28132
	public Transform ThisTransform;

	// Token: 0x04006DE5 RID: 28133
	public ArabicItemTextureRot TextureRot;

	// Token: 0x04006DE6 RID: 28134
	public RectTransform IconTransform;

	// Token: 0x04006DE7 RID: 28135
	public CanvasGroup Alpha;

	// Token: 0x04006DE8 RID: 28136
	public Image Icon;

	// Token: 0x04006DE9 RID: 28137
	public UIText MsgText;

	// Token: 0x04006DEA RID: 28138
	public float DelayTime;

	// Token: 0x04006DEB RID: 28139
	public float FadeTime;

	// Token: 0x04006DEC RID: 28140
	public float ShowIconTime;

	// Token: 0x04006DED RID: 28141
	private int Index;

	// Token: 0x04006DEE RID: 28142
	public Hudhandle Handle;

	// Token: 0x04006DEF RID: 28143
	public UIKind SFXKind;

	// Token: 0x04006DF0 RID: 28144
	public CString MsgStr;

	// Token: 0x04006DF1 RID: 28145
	public CString IconStr;

	// Token: 0x04006DF2 RID: 28146
	public bool bColseItem;

	// Token: 0x04006DF3 RID: 28147
	public byte MP3Sound;
}
