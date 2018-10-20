using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020006B6 RID: 1718
public class UIWallRepair : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUTimeBarOnTimer
{
	// Token: 0x060020BF RID: 8383 RVA: 0x003E5010 File Offset: 0x003E3210
	public override void OnOpen(int arg1, int arg2)
	{
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.DM = DataManager.Instance;
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.m_SliderTickTime = 1f;
		this.m_Str = new CString[2];
		for (int i = 0; i < 2; i++)
		{
			this.m_Str[i] = StringManager.Instance.SpawnString(50);
		}
		Transform child = base.transform.GetChild(0);
		this.m_tmptext[this.mTextCount] = child.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(3746u);
		this.mTextCount++;
		this.m_tmptext[this.mTextCount] = child.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(3761u);
		this.mTextCount++;
		child = base.transform.GetChild(1);
		this.m_WallIcon = child.GetChild(0).GetChild(0).GetComponent<Image>();
		this.m_IconText = child.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_IconText.font = ttffont;
		this.m_IconText.text = this.DM.mStringTable.GetStringByID(3756u);
		this.m_SliderRect = child.GetChild(2).GetChild(0).GetComponent<RectTransform>();
		this.m_Slider = child.GetChild(2).GetChild(0).GetComponent<Image>();
		this.m_sliderText = child.GetChild(2).GetChild(1).GetComponent<UIText>();
		this.m_sliderText.font = ttffont;
		this.m_WallImageIcon = child.GetChild(2).GetChild(2).GetComponent<Image>();
		UIButtonHint uibuttonHint = this.m_WallImageIcon.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		this.m_WallImageIcon.gameObject.SetActive(true);
		child = base.transform.GetChild(2);
		this.m_WallImage = child.GetChild(0).GetChild(0).GetComponent<Image>();
		this.m_WallImage_red = child.GetChild(0).GetChild(1).GetComponent<Image>();
		this.m_WallTypeTextBg = child.GetChild(0).GetChild(0).GetComponent<Image>();
		this.m_WallTypeTextBgRt = child.GetChild(1).GetChild(0).GetComponent<RectTransform>();
		this.m_WallTypeText = child.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_WallTypeText.font = ttffont;
		this.m_TimeBar = child.GetChild(2).GetComponent<UITimeBar>();
		if (this.m_TimeBar)
		{
			this.m_TimeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(260f, 30f);
			GUIManager.Instance.CreateTimerBar(this.m_TimeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
			GUIManager.Instance.SetTimerSpriteType(this.m_TimeBar, eTimerSpriteType.Speed);
			child.GetChild(2).GetChild(5).gameObject.SetActive(false);
			this.m_TimeBar.m_Handler = this;
		}
		this.m_TimeBar_red = child.GetChild(3);
		this.m_Slider_red = this.m_TimeBar_red.GetChild(1).GetComponent<Image>();
		this.m_TimeText_red = this.m_TimeBar_red.GetChild(3).GetComponent<UIText>();
		this.m_TimeText_red.font = ttffont;
		this.m_TimeInfoText_red = this.m_TimeBar_red.GetChild(2).GetComponent<UIText>();
		this.m_TimeInfoText_red.font = ttffont;
		this.m_TimeInfoText_red.text = this.DM.mStringTable.GetStringByID(1577u);
		this.btn = this.m_TimeBar_red.GetChild(4).GetComponent<UIButton>();
		this.btn.m_Handler = this;
		this.btn.m_BtnID1 = 1;
		this.m_tmptext[this.mTextCount] = this.m_TimeBar_red.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(1578u);
		this.mTextCount++;
		child = base.transform.GetChild(3);
		this.image = child.GetComponent<Image>();
		this.image.sprite = this.door.LoadSprite("UI_main_close_base");
		this.image.material = this.door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX && this.image)
		{
			this.image.enabled = false;
		}
		this.btn = child.GetChild(0).GetComponent<UIButton>();
		this.btn.m_BtnID1 = 0;
		this.btn.m_Handler = this;
		this.btn.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn.image.material = this.door.LoadMaterial();
		this.CheckWallType();
		if (this.m_WallType == eWallType.eWallComplete)
		{
			this.m_WallImage.enabled = false;
		}
		else
		{
			this.m_WallImage.enabled = true;
		}
		this.m_NowValue = this.DM.m_WallRepairNowValue;
		this.m_MaxValue = this.DM.m_WallRepairMaxValue;
		this.SetIcon();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x060020C0 RID: 8384 RVA: 0x003E55F4 File Offset: 0x003E37F4
	public override void OnClose()
	{
		if (this.m_TimeBar != null)
		{
			GUIManager.Instance.RemoverTimeBaarToList(this.m_TimeBar);
		}
	}

	// Token: 0x060020C1 RID: 8385 RVA: 0x003E5618 File Offset: 0x003E3818
	public override void UpdateUI(int arg1, int arg2)
	{
		this.SetSlider();
	}

	// Token: 0x060020C2 RID: 8386 RVA: 0x003E5620 File Offset: 0x003E3820
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Refresh_AttribEffectVal)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
		}
		else
		{
			this.SetSlider();
		}
	}

	// Token: 0x060020C3 RID: 8387 RVA: 0x003E565C File Offset: 0x003E385C
	public void Refresh_FontTexture()
	{
		if (this.m_IconText != null && this.m_IconText.enabled)
		{
			this.m_IconText.enabled = false;
			this.m_IconText.enabled = true;
		}
		if (this.m_sliderText != null && this.m_sliderText.enabled)
		{
			this.m_sliderText.enabled = false;
			this.m_sliderText.enabled = true;
		}
		if (this.m_WallTypeText != null && this.m_WallTypeText.enabled)
		{
			this.m_WallTypeText.enabled = false;
			this.m_WallTypeText.enabled = true;
		}
		if (this.m_TimeText_red != null && this.m_TimeText_red.enabled)
		{
			this.m_TimeText_red.enabled = false;
			this.m_TimeText_red.enabled = true;
		}
		if (this.m_TimeInfoText_red != null && this.m_TimeInfoText_red.enabled)
		{
			this.m_TimeInfoText_red.enabled = false;
			this.m_TimeInfoText_red.enabled = true;
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.m_tmptext[i] != null && this.m_tmptext[i].enabled)
			{
				this.m_tmptext[i].enabled = false;
				this.m_tmptext[i].enabled = true;
			}
		}
		if (this.m_TimeBar != null && this.m_TimeBar.enabled)
		{
			this.m_TimeBar.Refresh_FontTexture();
		}
	}

	// Token: 0x060020C4 RID: 8388 RVA: 0x003E5808 File Offset: 0x003E3A08
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
	}

	// Token: 0x060020C5 RID: 8389 RVA: 0x003E580C File Offset: 0x003E3A0C
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x060020C6 RID: 8390 RVA: 0x003E5810 File Offset: 0x003E3A10
	private void Update()
	{
		this.SetSlider();
		if (this.m_WallType == eWallType.eWallOnFire)
		{
			this.SetFireTimeBar();
		}
	}

	// Token: 0x060020C7 RID: 8391 RVA: 0x003E582C File Offset: 0x003E3A2C
	private void SetWallType(eWallType type)
	{
		this.m_WallType = type;
		if (this.m_WallType == eWallType.eWallComplete)
		{
			this.m_WallTypeTextBgRt.sizeDelta = new Vector2(421f, 76f);
			this.m_WallTypeText.text = DataManager.Instance.mStringTable.GetStringByID(3758u);
			this.m_TimeBar.gameObject.SetActive(false);
			this.m_TimeBar_red.gameObject.SetActive(false);
			this.m_WallImage.enabled = false;
			this.m_WallImage_red.enabled = false;
		}
		else if (this.m_WallType == eWallType.eWallRepair)
		{
			this.m_WallTypeTextBgRt.sizeDelta = new Vector2(421f, 46f);
			this.m_WallTypeText.text = DataManager.Instance.mStringTable.GetStringByID(3759u);
			this.m_TimeBar.gameObject.SetActive(true);
			this.m_TimeBar_red.gameObject.SetActive(false);
			this.m_WallImage.enabled = true;
			this.m_WallImage_red.enabled = false;
			if (this.m_WallBeginTime != this.DM.m_WallBeginTime)
			{
				this.m_WallBeginTime = this.DM.m_WallBeginTime;
				DataManager.Instance.GetQueueBarTitle(EQueueBarIndex.WallRepair, GUIManager.Instance.tmpString, ref this.str1, ref this.str2);
				GUIManager.Instance.SetTimerBar(this.m_TimeBar, this.DM.m_WallBeginTime, this.DM.m_WallTargetTime, 0L, eTimeBarType.CancelType, this.str1, this.str2);
			}
		}
		else if (this.m_WallType == eWallType.eWallOnFire)
		{
			this.m_WallTypeTextBgRt.sizeDelta = new Vector2(421f, 46f);
			this.m_WallTypeText.text = DataManager.Instance.mStringTable.GetStringByID(1576u);
			this.m_TimeBar.gameObject.SetActive(false);
			this.m_TimeBar_red.gameObject.SetActive(true);
			this.m_WallImage.enabled = false;
			this.m_WallImage_red.enabled = true;
		}
	}

	// Token: 0x060020C8 RID: 8392 RVA: 0x003E5A48 File Offset: 0x003E3C48
	private void SetIcon()
	{
		RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(12, 0);
		this.m_WallIcon.sprite = GUIManager.Instance.BuildingData.GetBuildSprite(12, buildData.Level);
		this.m_WallIcon.material = GUIManager.Instance.BuildingData.mapspriteManager.SpriteUIMaterial;
		this.m_WallIcon.SetNativeSize();
	}

	// Token: 0x060020C9 RID: 8393 RVA: 0x003E5AB8 File Offset: 0x003E3CB8
	private void SetSlider()
	{
		this.m_SliderTickTime += Time.deltaTime;
		if (this.m_SliderTickTime >= 1f)
		{
			if (this.m_Str[0] != null)
			{
				this.m_NowValue = this.DM.m_WallRepairNowValue;
				this.m_MaxValue = this.DM.m_WallRepairMaxValue;
				this.m_Str[0].ClearString();
				StringManager.Instance.IntToFormat((long)((ulong)this.m_NowValue), 1, true);
				StringManager.Instance.IntToFormat((long)((ulong)this.m_MaxValue), 1, true);
				if (GUIManager.Instance.IsArabic)
				{
					this.m_Str[0].AppendFormat("{1}/{0}");
				}
				else
				{
					this.m_Str[0].AppendFormat("{0}/{1}");
				}
				this.m_sliderText.text = this.m_Str[0].ToString();
				this.m_sliderText.SetAllDirty();
				this.m_sliderText.cachedTextGenerator.Invalidate();
			}
			this.m_SliderTickTime = 0f;
		}
		float num = this.m_NowValue / this.m_MaxValue;
		this.m_SliderRect.sizeDelta = new Vector2(152.5f * num, 20f);
		this.CheckWallType();
	}

	// Token: 0x060020CA RID: 8394 RVA: 0x003E5BFC File Offset: 0x003E3DFC
	private void CheckWallType()
	{
		if (this.DM.m_WallRepairMaxValue != 0u && this.DM.m_WallRepairNowValue == this.DM.m_WallRepairMaxValue)
		{
			this.SetWallType(eWallType.eWallComplete);
		}
		else if (LandWalkerManager.IsBattleFire())
		{
			this.SetWallType(eWallType.eWallOnFire);
		}
		else
		{
			this.SetWallType(eWallType.eWallRepair);
		}
	}

	// Token: 0x060020CB RID: 8395 RVA: 0x003E5C60 File Offset: 0x003E3E60
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID != 0)
		{
			if (btnID == 1)
			{
				GUIManager.Instance.UseOrSpend(1234, this.DM.mStringTable.GetStringByID(1505u), 0, 0, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
			}
		}
		else
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x060020CC RID: 8396 RVA: 0x003E5CCC File Offset: 0x003E3ECC
	public void OnTimer(UITimeBar sender)
	{
	}

	// Token: 0x060020CD RID: 8397 RVA: 0x003E5CD0 File Offset: 0x003E3ED0
	public void OnNotify(UITimeBar sender)
	{
	}

	// Token: 0x060020CE RID: 8398 RVA: 0x003E5CD4 File Offset: 0x003E3ED4
	public void Onfunc(UITimeBar sender)
	{
		eTimerSpriteType timerSpriteType = sender.m_TimerSpriteType;
		if (timerSpriteType == eTimerSpriteType.Speed)
		{
			GUIManager.Instance.OpenMenu(EGUIWindow.UI_BagFilter, 2, 16, false, false, false);
		}
		else if (timerSpriteType == eTimerSpriteType.Free)
		{
			DataManager.Instance.SendHeroStarUp_Free();
		}
	}

	// Token: 0x060020CF RID: 8399 RVA: 0x003E5D18 File Offset: 0x003E3F18
	public void OnCancel(UITimeBar sender)
	{
	}

	// Token: 0x060020D0 RID: 8400 RVA: 0x003E5D1C File Offset: 0x003E3F1C
	public void SetFireTimeBar()
	{
		if (DataManager.Instance.ServerTime > LandWalkerManager.LastBattleTime)
		{
			this.m_Str[1].ClearString();
			ushort num = (!LandWalkerManager.isWinning) ? 1200 : 1200;
			uint sec = (uint)(LandWalkerManager.LastBattleTime + (long)num - DataManager.Instance.ServerTime);
			GameConstants.GetTimeString(this.m_Str[1], sec, false, false, true, false, true);
			this.m_TimeText_red.text = this.m_Str[1].ToString();
			this.m_TimeText_red.SetAllDirty();
			this.m_TimeText_red.cachedTextGenerator.Invalidate();
			float num2 = (float)(DataManager.Instance.ServerTime - LandWalkerManager.LastBattleTime) / (float)num;
			num2 = Mathf.Clamp(num2, 0f, 1f);
			this.m_Slider_red.rectTransform.sizeDelta = new Vector2(211.5f * num2, 18.4f);
		}
	}

	// Token: 0x060020D1 RID: 8401 RVA: 0x003E5E08 File Offset: 0x003E4008
	public void OnButtonDown(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, 11167, 0, Vector2.zero, UIButtonHint.ePosition.Original);
	}

	// Token: 0x060020D2 RID: 8402 RVA: 0x003E5E3C File Offset: 0x003E403C
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(sender);
	}

	// Token: 0x04006775 RID: 26485
	private const int MaxStrCount = 2;

	// Token: 0x04006776 RID: 26486
	private const int TextMax = 3;

	// Token: 0x04006777 RID: 26487
	private eWallType m_WallType;

	// Token: 0x04006778 RID: 26488
	private Image m_WallIcon;

	// Token: 0x04006779 RID: 26489
	private Image m_Slider;

	// Token: 0x0400677A RID: 26490
	private Image m_Slider_red;

	// Token: 0x0400677B RID: 26491
	private Image m_WallImage;

	// Token: 0x0400677C RID: 26492
	private Image m_WallTypeTextBg;

	// Token: 0x0400677D RID: 26493
	private Image m_WallImage_red;

	// Token: 0x0400677E RID: 26494
	private RectTransform m_SliderRect;

	// Token: 0x0400677F RID: 26495
	private RectTransform m_WallTypeTextBgRt;

	// Token: 0x04006780 RID: 26496
	private UIText m_IconText;

	// Token: 0x04006781 RID: 26497
	private UIText m_sliderText;

	// Token: 0x04006782 RID: 26498
	private UIText m_WallTypeText;

	// Token: 0x04006783 RID: 26499
	private UITimeBar m_TimeBar;

	// Token: 0x04006784 RID: 26500
	private Transform m_TimeBar_red;

	// Token: 0x04006785 RID: 26501
	private UIText m_TimeText_red;

	// Token: 0x04006786 RID: 26502
	private UIText m_TimeInfoText_red;

	// Token: 0x04006787 RID: 26503
	private UIButton btn;

	// Token: 0x04006788 RID: 26504
	private Image image;

	// Token: 0x04006789 RID: 26505
	private Image m_WallImageIcon;

	// Token: 0x0400678A RID: 26506
	private CString[] m_Str;

	// Token: 0x0400678B RID: 26507
	private string str1;

	// Token: 0x0400678C RID: 26508
	private string str2;

	// Token: 0x0400678D RID: 26509
	private uint m_NowValue;

	// Token: 0x0400678E RID: 26510
	private uint m_MaxValue;

	// Token: 0x0400678F RID: 26511
	private float m_SliderTickTime;

	// Token: 0x04006790 RID: 26512
	private DataManager DM;

	// Token: 0x04006791 RID: 26513
	private Door door;

	// Token: 0x04006792 RID: 26514
	private long m_WallBeginTime;

	// Token: 0x04006793 RID: 26515
	private int mTextCount;

	// Token: 0x04006794 RID: 26516
	private UIText[] m_tmptext = new UIText[3];
}
