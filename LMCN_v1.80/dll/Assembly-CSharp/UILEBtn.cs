using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using uTools;

// Token: 0x0200087E RID: 2174
public class UILEBtn : Selectable, IPointerClickHandler, IEventSystemHandler, IUIButtonScaleHandler2
{
	// Token: 0x06002D29 RID: 11561 RVA: 0x0048E9B0 File Offset: 0x0048CBB0
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this.m_EffectType != e_EffectType.e_Normal)
		{
			return;
		}
		this.ClickFunc();
	}

	// Token: 0x06002D2A RID: 11562 RVA: 0x0048E9C4 File Offset: 0x0048CBC4
	private void ClickFunc()
	{
		if (this.IsActive() && this.IsInteractable() && this.m_Handler != null)
		{
			if ((this.SoundIndex & 64) == 0)
			{
				AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex)this.SoundIndex);
			}
			else if ((this.SoundIndex & 64) > 0)
			{
				int enumSoundIndex = (int)this.SoundIndex & -65;
				AudioManager.Instance.PlayUISFXIndex((UIClickSoundIndex)enumSoundIndex);
			}
			this.m_Handler.OnLEButtonClick(this);
		}
	}

	// Token: 0x06002D2B RID: 11563 RVA: 0x0048EA48 File Offset: 0x0048CC48
	public void SetEffectType(e_EffectType EffectType)
	{
		this.m_EffectType = EffectType;
	}

	// Token: 0x06002D2C RID: 11564 RVA: 0x0048EA54 File Offset: 0x0048CC54
	public void OnFinish()
	{
		this.ClickFunc();
	}

	// Token: 0x06002D2D RID: 11565 RVA: 0x0048EA5C File Offset: 0x0048CC5C
	public void ReLinkScale()
	{
		uButtonScale component = base.gameObject.GetComponent<uButtonScale>();
		if (component != null)
		{
			component.m_Handler = this;
			this.m_EffectType = e_EffectType.e_Scale;
		}
	}

	// Token: 0x06002D2E RID: 11566 RVA: 0x0048EA90 File Offset: 0x0048CC90
	public void SetTimedItem(long totalTime, eLordEquipDisplayKind DisplayKind = eLordEquipDisplayKind.OnlyItem)
	{
		if (totalTime != 0L)
		{
			this.innerTime = totalTime;
			if (this.TimeBg == null)
			{
				GUIManager instance = GUIManager.Instance;
				this.TimeString = StringManager.Instance.SpawnString(30);
				GameObject gameObject = new GameObject("TimeBg");
				gameObject.layer = 5;
				RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(0f, 0f);
				rectTransform.anchorMax = new Vector2(1f, 0.23f);
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				gameObject.AddComponent<IgnoreRaycast>();
				this.TimeBg = gameObject.AddComponent<Image>();
				gameObject.transform.SetParent(base.transform, false);
				gameObject = new GameObject("TimeText");
				gameObject.layer = 5;
				rectTransform = gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(0f, 0f);
				rectTransform.anchorMax = new Vector2(1f, 0.23f);
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				gameObject.AddComponent<IgnoreRaycast>();
				this.TimeText = gameObject.AddComponent<UIText>();
				this.TimeText.supportRichText = true;
				this.TimeText.resizeTextForBestFit = true;
				this.TimeText.font = GUIManager.Instance.GetTTFFont();
				this.TimeText.alignment = TextAnchor.MiddleCenter;
				gameObject.AddComponent<Outline>().effectColor = new Color32(36, 16, 0, byte.MaxValue);
				gameObject.AddComponent<Shadow>().effectColor = new Color(0f, 0f, 0f, 0.5f);
				this.TimeText.resizeTextMinSize = 2;
				this.TimeText.resizeTextMaxSize = 18;
				gameObject.transform.SetParent(base.transform, false);
				gameObject = new GameObject("Clock");
				gameObject.layer = 5;
				rectTransform = gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(-0.11f, -0.075f);
				rectTransform.anchorMax = new Vector2(0.365f, 0.395f);
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				gameObject.AddComponent<IgnoreRaycast>();
				this.Clock = gameObject.AddComponent<Image>();
				gameObject.transform.SetParent(base.transform, false);
				gameObject = new GameObject("ClockLight");
				gameObject.layer = 5;
				rectTransform = gameObject.AddComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(-0.11f, -0.075f);
				rectTransform.anchorMax = new Vector2(0.365f, 0.395f);
				rectTransform.offsetMin = Vector2.zero;
				rectTransform.offsetMax = Vector2.zero;
				gameObject.AddComponent<IgnoreRaycast>();
				this.ClockLight = gameObject.AddComponent<Image>();
				gameObject.transform.SetParent(base.transform, false);
				this.TimeBg.sprite = instance.m_LeadItemIconSpriteAsset.LoadSprite(65527);
				this.TimeBg.material = instance.m_LeadItemIconSpriteAsset.GetMaterial();
				this.Clock.sprite = instance.m_LeadItemIconSpriteAsset.LoadSprite(65525);
				this.Clock.material = instance.m_LeadItemIconSpriteAsset.GetMaterial();
				this.ClockLight.sprite = instance.m_LeadItemIconSpriteAsset.LoadSprite(65526);
				this.ClockLight.material = instance.m_LeadItemIconSpriteAsset.GetMaterial();
				this.OnEquip.transform.SetAsLastSibling();
			}
			if (DisplayKind == eLordEquipDisplayKind.Item_Gems)
			{
				RectTransform rectTransform = this.TimeBg.gameObject.GetComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(0f, 0.25f);
				rectTransform.anchorMax = new Vector2(1f, 0.48f);
				rectTransform = this.TimeText.gameObject.GetComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(0f, 0.25f);
				rectTransform.anchorMax = new Vector2(1f, 0.48f);
				rectTransform = this.Clock.gameObject.GetComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(-0.11f, 0.175f);
				rectTransform.anchorMax = new Vector2(0.365f, 0.645f);
				rectTransform = this.ClockLight.gameObject.GetComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(-0.11f, 0.175f);
				rectTransform.anchorMax = new Vector2(0.365f, 0.645f);
			}
			else
			{
				RectTransform rectTransform = this.TimeBg.gameObject.GetComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(0f, 0f);
				rectTransform.anchorMax = new Vector2(1f, 0.23f);
				rectTransform = this.TimeText.gameObject.GetComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(0f, 0f);
				rectTransform.anchorMax = new Vector2(1f, 0.23f);
				rectTransform = this.Clock.gameObject.GetComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(-0.11f, -0.075f);
				rectTransform.anchorMax = new Vector2(0.365f, 0.395f);
				rectTransform = this.ClockLight.gameObject.GetComponent<RectTransform>();
				rectTransform.anchorMin = new Vector2(-0.11f, -0.075f);
				rectTransform.anchorMax = new Vector2(0.365f, 0.395f);
			}
			this.TimeBg.gameObject.SetActive(true);
			this.TimeText.gameObject.SetActive(true);
			this.Clock.gameObject.SetActive(true);
			this.isCounting = false;
			this.ClockLight.gameObject.SetActive(false);
			this.TimeText.color = new Color32(53, 247, 108, byte.MaxValue);
			this.ClockLight.gameObject.SetActive(false);
			this.UpdateTimeText();
			return;
		}
		this.isCounting = false;
		if (this.TimeBg == null)
		{
			return;
		}
		this.TimeBg.gameObject.SetActive(false);
		this.TimeText.gameObject.SetActive(false);
		this.Clock.gameObject.SetActive(false);
		this.ClockLight.gameObject.SetActive(false);
	}

	// Token: 0x06002D2F RID: 11567 RVA: 0x0048F0CC File Offset: 0x0048D2CC
	public void SetCountdown(long endTime, bool hideifZero = false)
	{
		if (hideifZero && endTime == 0L)
		{
			this.TimeBg.gameObject.SetActive(false);
			this.TimeText.gameObject.SetActive(false);
			this.Clock.gameObject.SetActive(false);
			this.ClockLight.gameObject.SetActive(false);
		}
		if (endTime == 0L)
		{
			return;
		}
		if (this.TimeBg == null)
		{
			return;
		}
		this.isCounting = true;
		this.TimeText.color = new Color32(byte.MaxValue, 101, 110, byte.MaxValue);
		this.innerTime = endTime;
		this.TimeBg.gameObject.SetActive(true);
		this.TimeText.gameObject.SetActive(true);
		this.Clock.gameObject.SetActive(true);
		this.ClockLight.gameObject.SetActive(true);
		if (!GUIManager.Instance.m_LEBTN_updateList.Contains(this))
		{
			GUIManager.Instance.m_LEBTN_updateList.Add(this);
		}
		this.BtnUpdateTime(true);
	}

	// Token: 0x06002D30 RID: 11568 RVA: 0x0048F1E4 File Offset: 0x0048D3E4
	public void BtnUpdateTime(bool onSec)
	{
		if (!this.isCounting)
		{
			return;
		}
		this.ClockLight.color = new Color(1f, 1f, 1f, GUIManager.Instance.m_LEBtn_SharedAlpha);
		if (onSec)
		{
			this.UpdateTimeText();
		}
	}

	// Token: 0x06002D31 RID: 11569 RVA: 0x0048F234 File Offset: 0x0048D434
	public void UpdateTimeText()
	{
		this.TimeString.ClearString();
		if (this.isCounting)
		{
			GameConstants.GetTimeStringShort(this.TimeString, (uint)Math.Max(0L, this.innerTime - DataManager.Instance.ServerTime));
		}
		else
		{
			GameConstants.GetTimeStringShort(this.TimeString, (uint)this.innerTime);
		}
		this.TimeText.text = this.TimeString.ToString();
		this.TimeText.cachedTextGenerator.Invalidate();
		this.TimeText.SetAllDirty();
	}

	// Token: 0x06002D32 RID: 11570 RVA: 0x0048F2C4 File Offset: 0x0048D4C4
	protected override void OnDestroy()
	{
		GUIManager.Instance.m_LEBTN_updateList.Remove(this);
		StringManager.Instance.DeSpawnString(this.TimeString);
		base.OnDestroy();
	}

	// Token: 0x040079B6 RID: 31158
	public IUILEBtnClickHandler m_Handler;

	// Token: 0x040079B7 RID: 31159
	public int m_BtnID1;

	// Token: 0x040079B8 RID: 31160
	public int m_BtnID2;

	// Token: 0x040079B9 RID: 31161
	public int m_BtnID3;

	// Token: 0x040079BA RID: 31162
	public int m_BtnID4;

	// Token: 0x040079BB RID: 31163
	public ushort LEID;

	// Token: 0x040079BC RID: 31164
	public Image BackPanel;

	// Token: 0x040079BD RID: 31165
	public Image LEImage;

	// Token: 0x040079BE RID: 31166
	public Image Gem1Panel;

	// Token: 0x040079BF RID: 31167
	public Image Gem2Panel;

	// Token: 0x040079C0 RID: 31168
	public Image Gem3Panel;

	// Token: 0x040079C1 RID: 31169
	public Image Gem4Panel;

	// Token: 0x040079C2 RID: 31170
	public Image Gem1;

	// Token: 0x040079C3 RID: 31171
	public Image Gem2;

	// Token: 0x040079C4 RID: 31172
	public Image Gem3;

	// Token: 0x040079C5 RID: 31173
	public Image Gem4;

	// Token: 0x040079C6 RID: 31174
	public Image LevelImage;

	// Token: 0x040079C7 RID: 31175
	public Image OnEquip;

	// Token: 0x040079C8 RID: 31176
	public Image QuantityBg;

	// Token: 0x040079C9 RID: 31177
	public Image NameBg;

	// Token: 0x040079CA RID: 31178
	public UIText Name;

	// Token: 0x040079CB RID: 31179
	public UIText Quantity;

	// Token: 0x040079CC RID: 31180
	public UIText Level;

	// Token: 0x040079CD RID: 31181
	public byte SoundIndex;

	// Token: 0x040079CE RID: 31182
	private e_EffectType m_EffectType;

	// Token: 0x040079CF RID: 31183
	private Image TimeBg;

	// Token: 0x040079D0 RID: 31184
	private UIText TimeText;

	// Token: 0x040079D1 RID: 31185
	private Image Clock;

	// Token: 0x040079D2 RID: 31186
	private Image ClockLight;

	// Token: 0x040079D3 RID: 31187
	private bool isCounting;

	// Token: 0x040079D4 RID: 31188
	private long innerTime;

	// Token: 0x040079D5 RID: 31189
	private CString TimeString;
}
