using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x02000621 RID: 1569
public class UIMall : GUIWindow, UILoadImageHander, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x06001E24 RID: 7716 RVA: 0x00397F68 File Offset: 0x00396168
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Mall);
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.MM = MallManager.Instance;
		this.m_transform = base.transform;
		this.tmpFont = this.GM.GetTTFFont();
		this.m_transform.GetChild(4).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(4).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(4).GetChild(0).GetComponent<CustomImage>().hander = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(4).GetComponent<CustomImage>().enabled = false;
		}
		this.m_transform.GetChild(5).GetComponent<UIButton>().m_Handler = this;
		this.LiveChatText = this.m_transform.GetChild(5).GetChild(0).GetComponent<UIText>();
		this.LiveChatText.font = this.tmpFont;
		this.m_transform.GetChild(5).gameObject.AddComponent<ArabicItemTextureRot>();
		this.LightT = this.m_transform.GetChild(9);
		this.m_transform.GetChild(10).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.FGGO = this.m_transform.GetChild(10).gameObject;
		this.FGGO.AddComponent<ArabicItemTextureRot>();
		this.FGRC = this.m_transform.GetChild(10).GetComponent<RectTransform>();
		this.FGImage1 = this.m_transform.GetChild(10).GetChild(0).GetComponent<Image>();
		this.FGImage2 = this.m_transform.GetChild(10).GetChild(0).GetChild(0).GetComponent<Image>();
		this.FGText = this.m_transform.GetChild(10).GetChild(0).GetChild(1).GetComponent<UIText>();
		this.FGText.font = this.tmpFont;
		this.FGStr = StringManager.Instance.SpawnString(30);
		this.FGEffImage1 = this.m_transform.GetChild(10).GetChild(0).GetChild(2).GetComponent<Image>();
		this.FGEffImage2 = this.m_transform.GetChild(10).GetChild(0).GetChild(3).GetComponent<Image>();
		this.FGEffText = this.m_transform.GetChild(10).GetChild(0).GetChild(4).GetComponent<UIText>();
		this.FGEffText.font = this.tmpFont;
		this.FGEffStr = StringManager.Instance.SpawnString(30);
		this.FB_LightT = this.m_transform.GetChild(11);
		this.m_transform.GetChild(12).GetComponent<UIButton>().m_Handler = this;
		this.FB_Object = this.m_transform.GetChild(12).gameObject;
		this.FB_Text = this.m_transform.GetChild(12).GetChild(0).GetComponent<UIText>();
		this.FB_Text.rectTransform.anchoredPosition = new Vector2(-16f, -40.5f);
		this.FB_Text.font = this.tmpFont;
		this.FB_Text.text = this.DM.mStringTable.GetStringByID(10184u);
		this.tmpSA = this.m_transform.GetChild(13).GetComponent<UISpritesArray>();
		UISpritesArray component = this.m_transform.GetChild(5).GetComponent<UISpritesArray>();
		component.SetSpriteIndex(1);
		this.LiveChatText.text = this.DM.mStringTable.GetStringByID(7098u);
		this.HintObj = this.m_transform.GetChild(6).gameObject;
		this.HintText = this.HintObj.transform.GetChild(0).GetComponent<UIText>();
		this.HintText.font = this.tmpFont;
		this.HintText.text = this.DM.mStringTable.GetStringByID(907u);
		Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			Image component2 = this.HintObj.transform.GetComponent<Image>();
			component2.sprite = door.LoadSprite("UI_main_display");
			component2.material = door.LoadMaterial();
		}
		this.ArrowObj = this.m_transform.GetChild(7).gameObject;
		this.ArrowPos = this.m_transform.GetChild(7).GetComponent<uTweenPosition>();
		Transform child;
		if (this.IsJapan)
		{
			child = this.m_transform.GetChild(8);
			this.JPHintObject = child.gameObject;
			this.JPText[0] = child.GetChild(0).GetComponent<UIText>();
			this.JPText[0].font = this.tmpFont;
			this.JPText[0].text = this.DM.mStringTable.GetStringByID(913u);
			this.JPText[1] = child.GetChild(1).GetComponent<UIText>();
			this.JPText[1].font = this.tmpFont;
			this.JPText[1].text = this.DM.mStringTable.GetStringByID(914u);
			this.JPText[2] = child.GetChild(2).GetComponent<UIText>();
			this.JPText[2].font = this.tmpFont;
			this.JHintStr[0] = StringManager.Instance.SpawnString(100);
			this.JHintStr[0].IntToFormat((long)((ulong)this.DM.RoleAttr.PaidCrystal), 1, true);
			this.JHintStr[0].AppendFormat(this.DM.mStringTable.GetStringByID(915u));
			this.JPText[2].text = this.JHintStr[0].ToString();
			this.JPText[2].SetAllDirty();
			this.JPText[2].cachedTextGenerator.Invalidate();
			this.JPText[3] = child.GetChild(3).GetComponent<UIText>();
			this.JPText[3].font = this.tmpFont;
			this.JHintStr[1] = StringManager.Instance.SpawnString(100);
			this.JHintStr[1].IntToFormat((long)((ulong)(this.DM.RoleAttr.Diamond - this.DM.RoleAttr.PaidCrystal)), 1, true);
			this.JHintStr[1].AppendFormat(this.DM.mStringTable.GetStringByID(916u));
			this.JPText[3].text = this.JHintStr[1].ToString();
			this.JPText[3].SetAllDirty();
			this.JPText[3].cachedTextGenerator.Invalidate();
			this.JPText[4] = child.GetChild(4).GetComponent<UIText>();
			this.JPText[4].font = this.tmpFont;
			this.JPText[4].text = this.DM.mStringTable.GetStringByID(917u);
		}
		this.UnitObjectT = this.m_transform.GetChild(3);
		child = this.UnitObjectT.GetChild(1);
		UIText component3 = child.GetChild(0).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3 = child.GetChild(2).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3 = child.GetChild(3).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3.enabled = false;
		component3.gameObject.SetActive(true);
		component3 = child.GetChild(5).GetChild(0).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3 = child.GetChild(10).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3 = child.GetChild(12).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3 = child.GetChild(13).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3.text = this.DM.mStringTable.GetStringByID(876u);
		component3 = child.GetChild(8).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3.text = this.DM.mStringTable.GetStringByID(838u);
		component3 = child.GetChild(15).GetChild(0).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3.text = this.DM.mStringTable.GetStringByID(877u);
		Text component4 = child.GetChild(16).GetChild(0).GetComponent<Text>();
		component4.font = this.tmpFont;
		if (this.GM.IsArabic)
		{
			component4.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		component3 = child.GetChild(16).GetChild(1).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3.text = this.DM.mStringTable.GetStringByID(866u);
		component4 = child.GetChild(16).GetChild(3).GetComponent<Text>();
		component4.font = this.tmpFont;
		if (this.GM.IsArabic)
		{
			component4.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		component3 = child.GetChild(16).GetChild(4).GetChild(0).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component4 = child.GetChild(16).GetChild(4).GetChild(1).GetComponent<Text>();
		component4.font = this.tmpFont;
		if (this.GM.IsArabic)
		{
			component4.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		component4 = child.GetChild(16).GetChild(4).GetChild(2).GetComponent<Text>();
		component4.font = this.tmpFont;
		if (this.GM.IsArabic)
		{
			component4.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		child = this.UnitObjectT.GetChild(1).GetChild(14);
		this.GM.InitianHeroItemImg(child.GetChild(0), eHeroOrItem.Item, 1, 0, 0, 0, false, true, true, false);
		this.GM.InitianHeroItemImg(child.GetChild(2), eHeroOrItem.Item, 1, 0, 0, 0, false, true, true, false);
		this.GM.InitianHeroItemImg(child.GetChild(4), eHeroOrItem.Item, 1, 0, 0, 0, false, true, true, false);
		this.GM.InitLordEquipImg(child.GetChild(1), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		this.GM.InitLordEquipImg(child.GetChild(3), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		this.GM.InitLordEquipImg(child.GetChild(5), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		child.GetChild(12).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
		child.GetChild(13).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
		child.GetChild(14).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
		component3 = child.GetChild(6).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3 = child.GetChild(9).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3 = child.GetChild(7).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3 = child.GetChild(10).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3 = child.GetChild(8).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3 = child.GetChild(11).GetComponent<UIText>();
		component3.font = this.tmpFont;
		child = this.UnitObjectT.GetChild(2);
		component3 = child.GetChild(0).GetComponent<UIText>();
		component3.font = this.tmpFont;
		float x = this.GM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x;
		this.UnitObjectT.GetChild(3).GetComponent<RectTransform>().sizeDelta = new Vector2(x, 358f);
		child = this.UnitObjectT.GetChild(4);
		GUIManager.Instance.InitianHeroItemImg(child.GetChild(7), eHeroOrItem.Item, 1, 0, 0, 0, false, true, true, false);
		child.GetChild(10).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
		component3 = child.GetChild(1).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3 = child.GetChild(4).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3 = child.GetChild(8).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3 = child.GetChild(9).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component4 = child.GetChild(11).GetChild(0).GetComponent<Text>();
		component4.font = this.tmpFont;
		if (this.GM.IsArabic)
		{
			component4.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		component3 = child.GetChild(11).GetChild(1).GetComponent<UIText>();
		component3.font = this.tmpFont;
		component3.text = this.DM.mStringTable.GetStringByID(866u);
		component4 = child.GetChild(11).GetChild(2).GetComponent<Text>();
		component4.font = this.tmpFont;
		if (this.GM.IsArabic)
		{
			component4.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		if (this.IsJapan)
		{
			child = this.UnitObjectT.GetChild(5);
			child.GetChild(5).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
		}
		for (int i = 0; i < 5; i++)
		{
			this.ScrollComp[i].DataIndex = -1;
		}
		this.Scroll = this.m_transform.GetChild(0).GetComponent<ScrollPanel>();
		if (this.GM.bOpenOnIPhoneX)
		{
			((RectTransform)this.Scroll.transform).offsetMin = new Vector2(-53f, -640f);
		}
		this.Scroll.IntiScrollPanel(640f, 0f, 0f, this.NowHeightList, 5, this);
		this.cScrollRect = this.Scroll.GetComponent<CScrollRect>();
		UIButtonHint.scrollRect = this.cScrollRect;
		if (arg1 == 1)
		{
			this.bMain = true;
		}
		if (NewbieManager.CheckTeach(ETeachKind.TREASBOX_UPGRADE, null, false))
		{
			this.MM.MallUIIndex = 0;
			this.MM.MallUIPos = 0f;
		}
		this.UpDateList();
		if (this.MM.ForgeIndex != -1)
		{
			this.Scroll.GoTo(this.MM.ForgeIndex + 1);
			this.MM.ForgeIndex = -1;
			door.ClearWindowStack(EGUIWindow.UI_Forge_ActivityItem, EGUIWindow.UI_Anvil);
		}
		if (!this.bMain && this.MM.bFirstArrow)
		{
			this.SetArrow(true);
			this.BeginPos = this.cScrollRect.content.anchoredPosition.y;
		}
		this.GM.UpdateUI(EGUIWindow.Door, 1, 1);
		if (!this.MM.bAskListData)
		{
			this.MM.bSendMallInfo = true;
			GUIManager.Instance.ShowUILock(EUILock.Mall);
		}
		for (int j = 0; j < this.MM.MallDataList.Count; j++)
		{
			if (!this.MM.MallDataList[j].bAskListData)
			{
				this.MM.Send_Mall_Info();
				break;
			}
		}
		if (this.MM.FullGift_bShowEffect)
		{
			this.bOpenShowEffect = true;
		}
		if (this.MM.FirstGift_bShowEffect)
		{
			this.bOpenShowFBEffect = true;
		}
		this.SetFGBtn();
		this.SetFBBtn();
	}

	// Token: 0x06001E25 RID: 7717 RVA: 0x00398F90 File Offset: 0x00397190
	public override void OnClose()
	{
		if (this.IsJapan)
		{
			for (int i = 0; i < this.JHintStr.Length; i++)
			{
				if (this.JHintStr[i] != null)
				{
					StringManager.Instance.DeSpawnString(this.JHintStr[i]);
				}
			}
		}
		for (int j = 0; j < 5; j++)
		{
			if (this.TimeStr[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.TimeStr[j]);
			}
			if (this.CrystalStr[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.CrystalStr[j]);
			}
			if (this.CrystalStr2[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.CrystalStr2[j]);
			}
			if (this.PriceStr[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.PriceStr[j]);
			}
			if (this.DisStr[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.DisStr[j]);
			}
			if (this.PriceStr2[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.PriceStr2[j]);
			}
			for (int k = 0; k < 3; k++)
			{
				if (this.ItemCountStr[j] != null && this.ItemCountStr[j][k] != null)
				{
					StringManager.Instance.DeSpawnString(this.ItemCountStr[j][k]);
				}
			}
		}
		if (this.NowCrystalStr != null)
		{
			StringManager.Instance.DeSpawnString(this.NowCrystalStr);
		}
		StringManager.Instance.DeSpawnString(this.FGStr);
		StringManager.Instance.DeSpawnString(this.FGEffStr);
		for (int l = 0; l < this.MM.MallDataList.Count; l++)
		{
			if (this.MM.MallDataList[l].Type != ETreasureType.ETST_Crystal)
			{
				this.MM.MallDataList[l].UnloadAB(true);
			}
		}
		this.SavePos();
		if (this.MM.MallUIIndex == -1 && this.MM.MallDataList.Count > 0)
		{
			this.MM.MallUIIndex = 0;
			this.MM.MallUIPos = 0f;
		}
		if (this.EffectParticle != null)
		{
			if (this.EffectParticle.activeSelf && ParticleManager.Instance.AllEffectObject != null)
			{
				this.EffectParticle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
			}
			this.EffectParticle = null;
		}
		GUIManager.Instance.pDVMgr.EndMoveBossText();
	}

	// Token: 0x06001E26 RID: 7718 RVA: 0x00399240 File Offset: 0x00397440
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Refresh)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				if (this.IsJapan)
				{
					for (int i = 0; i < this.JPText.Length; i++)
					{
						if (this.JPText[i] != null && this.JPText[i].enabled)
						{
							this.JPText[i].enabled = false;
							this.JPText[i].enabled = true;
						}
					}
				}
				if (this.LiveChatText != null && this.LiveChatText.enabled)
				{
					this.LiveChatText.enabled = false;
					this.LiveChatText.enabled = true;
				}
				if (this.HintText != null && this.HintText.enabled)
				{
					this.HintText.enabled = false;
					this.HintText.enabled = true;
				}
				if (this.FGText != null && this.FGText.enabled)
				{
					this.FGText.enabled = false;
					this.FGText.enabled = true;
				}
				if (this.FGEffText != null && this.FGEffText.enabled)
				{
					this.FGEffText.enabled = false;
					this.FGEffText.enabled = true;
				}
				for (int j = 0; j < 5; j++)
				{
					if (this.bFindScrollComp[j])
					{
						if (this.ScrollComp[j].InfoText != null && this.ScrollComp[j].InfoText.enabled)
						{
							this.ScrollComp[j].InfoText.enabled = false;
							this.ScrollComp[j].InfoText.enabled = true;
						}
						if (this.ScrollComp[j].TitleText != null && this.ScrollComp[j].TitleText.enabled)
						{
							this.ScrollComp[j].TitleText.enabled = false;
							this.ScrollComp[j].TitleText.enabled = true;
						}
						if (this.ScrollComp[j].TimeText != null && this.ScrollComp[j].TimeText.enabled)
						{
							this.ScrollComp[j].TimeText.enabled = false;
							this.ScrollComp[j].TimeText.enabled = true;
						}
						if (this.ScrollComp[j].Image1Text != null && this.ScrollComp[j].Image1Text.enabled)
						{
							this.ScrollComp[j].Image1Text.enabled = false;
							this.ScrollComp[j].Image1Text.enabled = true;
						}
						if (this.ScrollComp[j].CrystalText != null && this.ScrollComp[j].CrystalText.enabled)
						{
							this.ScrollComp[j].CrystalText.enabled = false;
							this.ScrollComp[j].CrystalText.enabled = true;
						}
						if (this.ScrollComp[j].CrystalText2 != null && this.ScrollComp[j].CrystalText2.enabled)
						{
							this.ScrollComp[j].CrystalText2.enabled = false;
							this.ScrollComp[j].CrystalText2.enabled = true;
						}
						if (this.ScrollComp[j].CrystalText22 != null && this.ScrollComp[j].CrystalText22.enabled)
						{
							this.ScrollComp[j].CrystalText22.enabled = false;
							this.ScrollComp[j].CrystalText22.enabled = true;
						}
						if (this.ScrollComp[j].BuyText != null && this.ScrollComp[j].BuyText.enabled)
						{
							this.ScrollComp[j].BuyText.enabled = false;
							this.ScrollComp[j].BuyText.enabled = true;
						}
						if (this.ScrollComp[j].GetAllText != null && this.ScrollComp[j].GetAllText.enabled)
						{
							this.ScrollComp[j].GetAllText.enabled = false;
							this.ScrollComp[j].GetAllText.enabled = true;
						}
						if (this.ScrollComp[j].TitleText_2 != null && this.ScrollComp[j].TitleText_2.enabled)
						{
							this.ScrollComp[j].TitleText_2.enabled = false;
							this.ScrollComp[j].TitleText_2.enabled = true;
						}
						if (this.ScrollComp[j].CrystalText_2 != null && this.ScrollComp[j].CrystalText_2.enabled)
						{
							this.ScrollComp[j].CrystalText_2.enabled = false;
							this.ScrollComp[j].CrystalText_2.enabled = true;
						}
						if (this.ScrollComp[j].ItemText_2 != null && this.ScrollComp[j].ItemText_2.enabled)
						{
							this.ScrollComp[j].ItemText_2.enabled = false;
							this.ScrollComp[j].ItemText_2.enabled = true;
						}
						if (this.ScrollComp[j].ItemCountText_2 != null && this.ScrollComp[j].ItemCountText_2.enabled)
						{
							this.ScrollComp[j].ItemCountText_2.enabled = false;
							this.ScrollComp[j].ItemCountText_2.enabled = true;
						}
						if (this.ScrollComp[j].BuyText_2 != null && this.ScrollComp[j].BuyText_2.enabled)
						{
							this.ScrollComp[j].BuyText_2.enabled = false;
							this.ScrollComp[j].BuyText_2.enabled = true;
						}
						if (this.ScrollComp[j].CrystalText3 != null && this.ScrollComp[j].CrystalText3.enabled)
						{
							this.ScrollComp[j].CrystalText3.enabled = false;
							this.ScrollComp[j].CrystalText3.enabled = true;
						}
						if (this.ScrollComp[j].HIBtn2 != null)
						{
							this.ScrollComp[j].HIBtn2.Refresh_FontTexture();
						}
						for (int k = 0; k < 3; k++)
						{
							if (this.ScrollComp[j].ItemText[k] != null && this.ScrollComp[j].ItemText[k].enabled)
							{
								this.ScrollComp[j].ItemText[k].enabled = false;
								this.ScrollComp[j].ItemText[k].enabled = true;
							}
							if (this.ScrollComp[j].ItemCountText[k] != null && this.ScrollComp[j].ItemCountText[k].enabled)
							{
								this.ScrollComp[j].ItemCountText[k].enabled = false;
								this.ScrollComp[j].ItemCountText[k].enabled = true;
							}
							if (this.ScrollComp[j].HIBtn1[k] != null)
							{
								this.ScrollComp[j].HIBtn1[k].Refresh_FontTexture();
							}
						}
					}
				}
			}
		}
		else if (!this.bMain)
		{
			this.UpDateMyCrystal();
			this.UpDateJPPoint();
		}
	}

	// Token: 0x06001E27 RID: 7719 RVA: 0x00399B30 File Offset: 0x00397D30
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 0)
		{
			this.UpdateTime();
			if (this.MM.bNeedUpDateItemPtice)
			{
				this.UpDatePriceAndCrystal();
				this.MM.bNeedUpDateItemPtice = false;
			}
		}
		else if (arg1 == 1)
		{
			this.SavePos();
			this.UpDateList();
		}
		else if (arg1 == 2)
		{
			this.SavePos();
			this.MM.Send_Mall_Info();
		}
		else if (arg1 == 4)
		{
			this.SavePos();
			this.MM.AutoMall = true;
		}
		else if (arg1 == 5)
		{
			this.UpDateScrollItem();
		}
		else if (arg1 == 7)
		{
			if (!this.bMain)
			{
				this.UpDateJPPoint();
			}
		}
		else if (arg1 == 8)
		{
			this.SetFGBtn();
		}
		else if (arg1 == 9)
		{
			this.BeginEffect(false);
		}
		else if (arg1 == 10)
		{
			this.BeginGetCrystal(arg2);
		}
		else if (arg1 == 11)
		{
			this.BeginEffect(true);
		}
		else if (arg1 == 12)
		{
			this.Begin_FT_Effect(true);
		}
	}

	// Token: 0x06001E28 RID: 7720 RVA: 0x00399C50 File Offset: 0x00397E50
	private void Update()
	{
		if (this.bOpenShowEffect)
		{
			this.OpenShowTime -= Time.deltaTime;
			if (this.OpenShowTime < 0f)
			{
				this.bOpenShowEffect = false;
				this.BeginEffect(false);
			}
			return;
		}
		if (this.bOpenShowFBEffect)
		{
			this.OpenShowTime -= Time.deltaTime;
			if (this.OpenShowTime < 0f)
			{
				this.bOpenShowFBEffect = false;
				this.Begin_FT_Effect(true);
			}
			return;
		}
		if (this.bShowArrow)
		{
			this.CheckTimer -= Time.deltaTime;
			if (this.CheckTimer <= 0f)
			{
				this.CheckTimer = 0.5f;
				if (Mathf.Abs(this.BeginPos - this.cScrollRect.content.anchoredPosition.y) > 200f)
				{
					this.SetArrow(false);
				}
			}
		}
		if (this.NeedUpDate && IGGGameSDK.Instance.bPaymentReady)
		{
			this.NeedUpDate = false;
			this.UpDatePriceAndCrystal();
		}
		this.ResourceRedTime += Time.deltaTime;
		if (this.ResourceRedTime >= 0.5f)
		{
			this.ResourceRedTime = 0f;
			this.bResourceRed = !this.bResourceRed;
			for (int i = 0; i < 5; i++)
			{
				if (this.bFindScrollComp[i] && this.ScrollComp[i].DataIndex != -1)
				{
					int dataIndex = this.ScrollComp[i].DataIndex;
					if (dataIndex >= 0 && dataIndex < this.MM.MallDataList.Count && this.MM.MallDataList[dataIndex].Type == ETreasureType.ETST_SHLevelUp && this.MM.MallDataList[dataIndex].EndTime > 0L)
					{
						if (this.bResourceRed)
						{
							this.ScrollComp[i].TimeText2.color = Color.red;
						}
						else
						{
							this.ScrollComp[i].TimeText2.color = Color.white;
						}
					}
				}
			}
		}
		if (this.LightT != null)
		{
			this.LightT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
		if (this.FB_LightT != null && this.FB_LightT.gameObject.activeSelf)
		{
			this.FB_LightT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
		if (this.bPlayGetCrystal)
		{
			this.GetCrystalNowTime += Time.deltaTime;
			if (this.GetCrystalNowTime > this.GetCrystalTime)
			{
				this.EndGetCrystal();
			}
			else
			{
				float t = this.GetCrystalNowTime / this.GetCrystalTime;
				float num = Mathf.Lerp(0.2f, 1.8f, t);
				if (num > 1f)
				{
					num = 2f - num;
				}
				this.FGEffImage1.color = new Color(1f, 1f, 1f, num);
				this.FGEffImage2.color = new Color(1f, 1f, 1f, num);
				this.FGEffText.color = new Color(this.FGEffText.color.r, this.FGEffText.color.g, this.FGEffText.color.b, num);
				float y = Mathf.Lerp(10f, 85f, t);
				this.FGEffText.rectTransform.anchoredPosition = new Vector2(0f, y);
				y = Mathf.Lerp(15f, 96f, t);
				this.FGEffImage2.rectTransform.anchoredPosition = new Vector2(0f, y);
			}
		}
		if (this.EffectRC)
		{
			if (!this.EffectReverse)
			{
				this.EffectTimer += Time.smoothDeltaTime;
				this.FGTimer += Time.smoothDeltaTime;
				if (this.EffectTimer < 0.26f)
				{
					this.EffectScale = Mathf.Lerp(0f, 2.1f, this.EffectTimer / 0.26f);
					this.Effectalpha = Mathf.Lerp(0f, 0.57f, this.EffectTimer / 0.26f);
					this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
				}
				else if (this.EffectTimer < 0.46f)
				{
					this.EffectScale = Mathf.Lerp(2.1f, 1f, (this.EffectTimer - 0.26f) / 0.2f);
					this.Effectalpha = Mathf.Lerp(0.57f, 1f, (this.EffectTimer - 0.26f) / 0.2f);
					this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
				}
				else if (this.EffectTimer < 0.82f)
				{
					this.EffectScale = 1f;
					this.Effectalpha = 1f;
					this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
				}
				else if (this.EffectTimer < 1f)
				{
					this.EffectScale = Mathf.Lerp(1f, 0.92f, (this.EffectTimer - 0.82f) / 0.18f);
					this.Effectalpha = Mathf.Lerp(1f, 0.83f, (this.EffectTimer - 0.82f) / 0.18f);
					this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
				}
				else if (this.EffectTimer < 1.13f)
				{
					this.EffectScale = Mathf.Lerp(0.92f, 0.86f, (this.EffectTimer - 1f) / 0.13f);
					this.Effectalpha = Mathf.Lerp(0.83f, 0.7f, (this.EffectTimer - 1f) / 0.13f);
					this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.bezierEnd = Vector2.zero + new Vector2(6f, -5f);
					this.EffectRC.anchoredPosition = Vector2.Lerp(Vector2.zero, this.bezierEnd, (this.EffectTimer - 1f) / 0.13f);
				}
				else if (this.EffectTimer < 1.82f)
				{
					this.EffectScale = Mathf.Lerp(0.86f, 0.6f, (this.EffectTimer - 1.13f) / 0.69f);
					this.Effectalpha = Mathf.Lerp(0.7f, 0.17f, (this.EffectTimer - 1.13f) / 0.69f);
					this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.bezierEnd = Vector2.zero - new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f - 38f, -(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - 49f));
					this.EffectRC.anchoredPosition = Vector2.Lerp(Vector2.zero + new Vector2(6f, -5f), this.bezierEnd, (this.EffectTimer - 1.13f) / 0.69f);
				}
				else if (this.EffectTimer >= 1.82f)
				{
					this.EffectRC.gameObject.SetActive(false);
					this.EffectPos.gameObject.SetActive(false);
				}
				if (this.FGTimer > 1.46f && !this.FGGO.activeSelf)
				{
					this.FGGO.SetActive(true);
					AudioManager.Instance.PlayUISFX(UIKind.Crystal_Arrivals);
				}
				else if (this.FGGO.activeSelf && this.FGTimer < 1.66f)
				{
					this.EffectScale = Mathf.Lerp(0f, 1.5f, (this.FGTimer - 1.46f) / 0.2f);
					this.FGRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.Effectalpha = Mathf.Lerp(0f, 0.6f, (this.FGTimer - 1.46f) / 0.2f);
					this.FGImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.FGImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
				}
				else if (this.FGGO.activeSelf && this.FGTimer < 1.79f)
				{
					this.EffectScale = Mathf.Lerp(1.5f, 1f, (this.FGTimer - 1.66f) / 0.13f);
					this.FGRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.Effectalpha = Mathf.Lerp(0.6f, 1f, (this.FGTimer - 1.66f) / 0.13f);
					this.FGImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.FGImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
				}
				else if (this.FGGO.activeSelf && this.FGTimer < 1.89f)
				{
					this.EffectScale = Mathf.Lerp(1f, 1.2f, (this.FGTimer - 1.79f) / 0.1f);
					this.FGRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.Effectalpha = Mathf.Lerp(1f, 1.2f, (this.FGTimer - 1.79f) / 0.1f);
					this.FGImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.FGImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
				}
				else if (this.FGGO.activeSelf && this.FGTimer < 1.92f)
				{
					this.EffectScale = Mathf.Lerp(1.2f, 1f, (this.FGTimer - 1.89f) / 0.03f);
					this.FGRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.Effectalpha = Mathf.Lerp(1.2f, 1f, (this.FGTimer - 1.89f) / 0.03f);
					this.FGImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.FGImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
				}
				else if (this.FGGO.activeSelf && this.FGTimer > 1.92f)
				{
					this.EndEffect();
				}
			}
			else
			{
				this.EffectTimer += Time.smoothDeltaTime;
				this.FGTimer += Time.smoothDeltaTime;
				if (this.FBEffectScale == 1f)
				{
					if (this.EffectTimer < 0.69f)
					{
						this.EffectScale = Mathf.Lerp(0.6f, 0.86f, this.EffectTimer / 0.69f);
						this.Effectalpha = Mathf.Lerp(0.17f, 0.7f, this.EffectTimer / 0.69f);
						this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
						this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
						this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
						this.bezierEnd = Vector2.zero + new Vector2(6f, -5f) - new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f - 38f, -(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - 49f));
						this.EffectRC.anchoredPosition = Vector2.Lerp(this.bezierEnd, Vector2.zero + new Vector2(6f, -5f), this.EffectTimer / 0.69f);
					}
					else if (this.EffectTimer < 0.82f)
					{
						this.EffectScale = Mathf.Lerp(0.86f, 0.92f, (this.EffectTimer - 0.69f) / 0.13f);
						this.Effectalpha = Mathf.Lerp(0.7f, 0.83f, (this.EffectTimer - 0.69f) / 0.13f);
						this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
						this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
						this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
						this.bezierEnd = Vector2.zero + new Vector2(6f, -5f);
						this.EffectRC.anchoredPosition = Vector2.Lerp(this.bezierEnd, Vector2.zero, (this.EffectTimer - 0.69f) / 0.13f);
					}
					else if (this.EffectTimer < 1f)
					{
						this.EffectScale = Mathf.Lerp(0.92f, 1f, (this.EffectTimer - 0.82f) / 0.18f);
						this.Effectalpha = Mathf.Lerp(0.83f, 1f, (this.EffectTimer - 0.82f) / 0.18f);
						this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
						this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
						this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
						if (this.EffectParticle == null)
						{
							this.EffectParticle = ParticleManager.Instance.Spawn(433, this.EffectPos.transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
							this.EffectParticle.transform.localPosition = new Vector3(0f, 0f, 0f);
							this.EffectParticle.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
							GUIManager.Instance.SetLayer(this.EffectParticle, 5);
							AudioManager.Instance.PlayUISFX(UIKind.DominanceLevelup);
						}
					}
					else if (this.EffectTimer < 1.36f)
					{
						this.EffectScale = 1f;
						this.Effectalpha = 1f;
						this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
						this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
						this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
					}
					else if (this.EffectTimer < 1.56f)
					{
						this.EffectScale = Mathf.Lerp(1f, 2.1f, (this.EffectTimer - 1.36f) / 0.2f);
						this.Effectalpha = Mathf.Lerp(1f, 0.57f, (this.EffectTimer - 1.36f) / 0.2f);
						this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
						this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
						this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
					}
					else if (this.EffectTimer < 1.82f)
					{
						this.EffectScale = Mathf.Lerp(2.1f, 0f, (this.EffectTimer - 1.56f) / 0.26f);
						this.Effectalpha = Mathf.Lerp(0.57f, 0f, (this.EffectTimer - 1.56f) / 0.26f);
						this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
						this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
						this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
					}
					else if (this.EffectTimer > 1.82f)
					{
						this.EffectRC.gameObject.SetActive(false);
						this.EffectPos.gameObject.SetActive(false);
						this.EndEffect();
					}
				}
				else if (this.EffectTimer < 0.69f)
				{
					this.EffectScale = Mathf.Lerp(0.7f, 0.5f, this.EffectTimer / 0.69f);
					this.Effectalpha = Mathf.Lerp(1f, 0.5f, this.EffectTimer / 0.69f);
					this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.bezierEnd = Vector2.zero + new Vector2(29f, -24f) - new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f - 38f, -(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - 49f));
					this.EffectRC.anchoredPosition = this.bezierEnd;
				}
				else if (this.EffectTimer < 0.82f)
				{
					this.EffectScale = Mathf.Lerp(0.5f, 0.3f, (this.EffectTimer - 0.69f) / 0.13f);
					this.Effectalpha = Mathf.Lerp(0.5f, 0.1f, (this.EffectTimer - 0.69f) / 0.13f);
					this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
				}
				else if (this.EffectTimer < 1f)
				{
					this.Effectalpha = Mathf.Lerp(0.1f, 0f, (this.EffectTimer - 0.82f) / 0.18f);
					this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
					if (this.bPlayAudio)
					{
						AudioManager.Instance.PlayUISFX(UIKind.DominanceLevelup);
						this.bPlayAudio = false;
					}
				}
				else if (this.EffectTimer < 1.36f)
				{
					this.EffectScale = Mathf.Lerp(0f, this.FBEffectScale, (this.EffectTimer - 0.82f) / 0.36f);
					this.Effectalpha = Mathf.Lerp(0f, 1f, (this.EffectTimer - 0.82f) / 0.36f);
					this.EffectRC.anchoredPosition = Vector2.zero;
					this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
				}
				else if (this.EffectTimer >= 1.86f)
				{
					if (this.EffectTimer < 2.06f)
					{
						this.EffectScale = Mathf.Lerp(1f * this.FBEffectScale, 2.1f * this.FBEffectScale, (this.EffectTimer - 1.86f) / 0.2f);
						this.Effectalpha = Mathf.Lerp(1f, 0.57f, (this.EffectTimer - 1.86f) / 0.2f);
						this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
						this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
						this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
					}
					else if (this.EffectTimer < 2.32f)
					{
						this.EffectScale = Mathf.Lerp(2.1f * this.FBEffectScale, 0f, (this.EffectTimer - 2.06f) / 0.26f);
						this.Effectalpha = Mathf.Lerp(0.57f, 0f, (this.EffectTimer - 2.06f) / 0.26f);
						this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
						this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
						this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
					}
					else if (this.EffectTimer > 2.32f)
					{
						this.EffectRC.gameObject.SetActive(false);
						this.EffectPos.gameObject.SetActive(false);
						this.EndEffect();
					}
				}
				if (this.FGTimer < 0.03f)
				{
					this.EffectScale = Mathf.Lerp(1f, 1.2f, this.FGTimer / 0.03f);
					this.Effectalpha = Mathf.Lerp(1f, 1.2f, this.FGTimer / 0.03f);
					this.FGRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.FGImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.FGImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
				}
				else if (this.FGTimer < 0.13f)
				{
					this.EffectScale = Mathf.Lerp(1.2f, 1f, (this.FGTimer - 0.03f) / 0.1f);
					this.Effectalpha = Mathf.Lerp(1.2f, 1f, (this.FGTimer - 0.03f) / 0.1f);
					this.FGRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.FGImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.FGImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
				}
				else if (this.FGTimer < 0.26f)
				{
					this.EffectScale = Mathf.Lerp(1f, 1.5f, (this.FGTimer - 0.13f) / 0.13f);
					this.Effectalpha = Mathf.Lerp(1f, 0.6f, (this.FGTimer - 0.13f) / 0.13f);
					this.FGRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.FGImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.FGImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
				}
				else if (this.FGTimer < 0.46f)
				{
					this.EffectScale = Mathf.Lerp(1.5f, 0f, (this.FGTimer - 0.26f) / 0.2f);
					this.Effectalpha = Mathf.Lerp(0.6f, 0f, (this.FGTimer - 0.26f) / 0.2f);
					this.FGRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
					this.FGImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
					this.FGImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
				}
				else if (this.FGTimer > 0.46f)
				{
					this.FGGO.SetActive(false);
				}
			}
		}
	}

	// Token: 0x06001E29 RID: 7721 RVA: 0x0039BA1C File Offset: 0x00399C1C
	private void UpDateMyCrystal()
	{
		for (int i = 0; i < 5; i++)
		{
			if (this.bFindScrollComp[i] && this.ScrollComp[i].bTitleCrystal)
			{
				this.NowCrystalStr.Length = 0;
				StringManager.IntToStr(this.NowCrystalStr, (long)((ulong)this.DM.RoleAttr.Diamond), 1, true);
				this.ScrollComp[i].CrystalText3.text = this.NowCrystalStr.ToString();
				this.ScrollComp[i].CrystalText3.SetAllDirty();
				this.ScrollComp[i].CrystalText3.cachedTextGenerator.Invalidate();
				return;
			}
		}
	}

	// Token: 0x06001E2A RID: 7722 RVA: 0x0039BADC File Offset: 0x00399CDC
	private void UpDateJPPoint()
	{
		if (this.IsJapan)
		{
			if (this.JPText[2] != null)
			{
				this.JHintStr[0].Length = 0;
				this.JHintStr[0].IntToFormat((long)((ulong)this.DM.RoleAttr.PaidCrystal), 1, true);
				this.JHintStr[0].AppendFormat(this.DM.mStringTable.GetStringByID(915u));
				this.JPText[2].text = this.JHintStr[0].ToString();
				this.JPText[2].SetAllDirty();
				this.JPText[2].cachedTextGenerator.Invalidate();
			}
			if (this.JPText[3] != null)
			{
				this.JHintStr[1].Length = 0;
				this.JHintStr[1].IntToFormat((long)((ulong)(this.DM.RoleAttr.Diamond - this.DM.RoleAttr.PaidCrystal)), 1, true);
				this.JHintStr[1].AppendFormat(this.DM.mStringTable.GetStringByID(916u));
				this.JPText[3].text = this.JHintStr[1].ToString();
				this.JPText[3].SetAllDirty();
				this.JPText[3].cachedTextGenerator.Invalidate();
			}
		}
	}

	// Token: 0x06001E2B RID: 7723 RVA: 0x0039BC40 File Offset: 0x00399E40
	private void UpDatePriceAndCrystal()
	{
		for (int i = 0; i < 5; i++)
		{
			if (this.bFindScrollComp[i] && this.ScrollComp[i].DataIndex != -1)
			{
				int dataIndex = this.ScrollComp[i].DataIndex;
				if (dataIndex >= 0 && dataIndex < this.MM.MallDataList.Count)
				{
					int treasureID = (int)this.MM.MallDataList[dataIndex].TreasureID;
					int num = 0;
					this.MM.GetProductPointByID(treasureID, out num);
					this.CrystalStr[i].Length = 0;
					this.CrystalStr[i].IntToFormat((long)num, 1, true);
					this.CrystalStr[i].AppendFormat("{0}");
					this.ScrollComp[i].CrystalText.text = this.CrystalStr[i].ToString();
					this.ScrollComp[i].CrystalText.SetAllDirty();
					this.ScrollComp[i].CrystalText.cachedTextGenerator.Invalidate();
					this.MM.SetPriceStr(this.PriceStr[i], treasureID, false, 0);
					if (this.MM.MallDataList[dataIndex].Discount > 0)
					{
						this.MM.SetPriceStr(this.PriceStr2[i], treasureID, true, this.MM.MallDataList[dataIndex].Discount);
						this.ScrollComp[i].Lable_PriceText1.text = this.PriceStr2[i].ToString();
						this.ScrollComp[i].Lable_PriceText1.SetAllDirty();
						this.ScrollComp[i].Lable_PriceText1.cachedTextGenerator.Invalidate();
						this.ScrollComp[i].Lable_PriceText2.text = this.PriceStr[i].ToString();
						this.ScrollComp[i].Lable_PriceText2.SetAllDirty();
						this.ScrollComp[i].Lable_PriceText2.cachedTextGenerator.Invalidate();
					}
					else
					{
						this.ScrollComp[i].BuyText.text = this.PriceStr[i].ToString();
						this.ScrollComp[i].BuyText.SetAllDirty();
						this.ScrollComp[i].BuyText.cachedTextGenerator.Invalidate();
					}
				}
			}
		}
	}

	// Token: 0x06001E2C RID: 7724 RVA: 0x0039BEC0 File Offset: 0x0039A0C0
	private void UpdateTime()
	{
		for (int i = 0; i < 5; i++)
		{
			if (this.bFindScrollComp[i] && this.ScrollComp[i].DataIndex != -1)
			{
				int dataIndex = this.ScrollComp[i].DataIndex;
				if (dataIndex >= 0 && dataIndex < this.MM.MallDataList.Count && this.MM.MallDataList[dataIndex].Type != ETreasureType.ETST_Crystal && this.MM.MallDataList[dataIndex].EndTime > 0L)
				{
					this.TimeStr[i].Length = 0;
					if (this.MM.MallDataList[dataIndex].Type == ETreasureType.ETST_SHLevelUp)
					{
						GameConstants.GetTimeString(this.TimeStr[i], this.MM.MallDataList[dataIndex].uTime, false, false, true, false, false);
						this.ScrollComp[i].TimeText2.text = this.TimeStr[i].ToString();
						this.ScrollComp[i].TimeText2.SetAllDirty();
						this.ScrollComp[i].TimeText2.cachedTextGenerator.Invalidate();
					}
					else
					{
						GameConstants.GetTimeString(this.TimeStr[i], this.MM.MallDataList[dataIndex].uTime, false, false, true, false, true);
						this.ScrollComp[i].TimeText.text = this.TimeStr[i].ToString();
						this.ScrollComp[i].TimeText.SetAllDirty();
						this.ScrollComp[i].TimeText.cachedTextGenerator.Invalidate();
					}
				}
			}
		}
		this.SetFGTime();
	}

	// Token: 0x06001E2D RID: 7725 RVA: 0x0039C098 File Offset: 0x0039A298
	private void UpDateList()
	{
		this.NowHeightList.Clear();
		if (this.bMain)
		{
			this.NowHeightList.Add(640f);
			this.Scroll.transform.GetComponent<CScrollRect>().vertical = false;
		}
		else
		{
			this.NowHeightList.Add(46f);
			this.Scroll.transform.GetComponent<CScrollRect>().vertical = true;
			for (int i = 0; i < this.MM.MallDataList.Count; i++)
			{
				if (this.MM.MallDataList[i].Type != ETreasureType.ETST_Crystal)
				{
					this.NowHeightList.Add(640f);
				}
				else
				{
					this.NowHeightList.Add(358f);
				}
			}
		}
		this.Scroll.AddNewDataHeight(this.NowHeightList, true, true);
		this.Scroll.transform.GetComponent<CScrollRect>().movementType = CScrollRect.MovementType.Clamped;
		this.Scroll.transform.GetComponent<Mask>().enabled = false;
		RectTransform component;
		for (int j = 0; j < 5; j++)
		{
			component = this.Scroll.transform.GetChild(0).GetChild(j).GetComponent<RectTransform>();
			component.anchorMax = new Vector2(0.5f, 1f);
			component.anchorMin = new Vector2(0.5f, 1f);
			component.pivot = new Vector2(0.5f, 1f);
			component.anchoredPosition = new Vector2(0f, component.anchoredPosition.y);
		}
		component = this.Scroll.transform.GetChild(0).GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(((RectTransform)this.GM.m_UICanvas.transform).sizeDelta.x, component.sizeDelta.y);
		if (this.MM.MallUIIndex != -1)
		{
			this.Scroll.GoTo(this.MM.MallUIIndex, this.MM.MallUIPos);
		}
		this.UpdateTime();
	}

	// Token: 0x06001E2E RID: 7726 RVA: 0x0039C2C8 File Offset: 0x0039A4C8
	private void SetBackNameInfo(int ScrollIndex, int DataIndex)
	{
		MallDataType mallDataType = this.MM.MallDataList[DataIndex];
		if (mallDataType.Type == ETreasureType.ETST_Crystal)
		{
			return;
		}
		if (mallDataType.bDownLoadPic)
		{
			if (mallDataType.bUpDatePic)
			{
				mallDataType.UnloadAB(true);
				mallDataType.bUpDatePic = false;
			}
			if (mallDataType.m_AssetBundleKey == 0)
			{
				mallDataType.InitialAB();
			}
			this.ScrollComp[ScrollIndex].BackImage1.sprite = mallDataType.m_BackImage1;
			this.ScrollComp[ScrollIndex].BackImage1.material = mallDataType.m_Material;
			this.ScrollComp[ScrollIndex].BackImage1.enabled = true;
		}
		else
		{
			this.ScrollComp[ScrollIndex].BackImage1.enabled = false;
		}
		if (mallDataType.bDownLoadStr)
		{
			if (mallDataType.bUpDateStr)
			{
				mallDataType.UnloadStrAB();
				mallDataType.bUpDateStr = false;
			}
			if (mallDataType.m_StrAssetBundleKey == 0)
			{
				mallDataType.InitialABString();
			}
			if (mallDataType.DownLoadStr != null)
			{
				byte b = this.DM.UserLanguage - GameLanguage.GL_Eng;
				if ((int)b >= mallDataType.DownLoadStr.Content.Length || mallDataType.DownLoadStr.Content[(int)b] == string.Empty)
				{
					b = 0;
				}
				this.ScrollComp[ScrollIndex].InfoText.text = mallDataType.DownLoadStr.Content[(int)b].Replace("\\n", "\n");
				this.ScrollComp[ScrollIndex].TitleText.text = mallDataType.DownLoadStr.Header[(int)b];
			}
		}
		else
		{
			this.ScrollComp[ScrollIndex].InfoText.text = string.Empty;
			this.ScrollComp[ScrollIndex].TitleText.text = string.Empty;
		}
	}

	// Token: 0x06001E2F RID: 7727 RVA: 0x0039C4AC File Offset: 0x0039A6AC
	private void SetArrow(bool bShow)
	{
		if (bShow)
		{
			Vector3 vector = this.ArrowObj.transform.localPosition;
			Vector3 vector2 = this.HintObj.transform.localPosition;
			if (this.MM.MallDataList.Count > 0)
			{
				MallDataType mallDataType = this.MM.MallDataList[0];
				if (mallDataType.PosType == 1)
				{
					vector += new Vector3(351f, 0f, 0f);
					vector2 += new Vector3(351f, 0f, 0f);
					this.HintObj.transform.localPosition = vector2;
				}
			}
			this.ArrowPos.from = vector;
			this.ArrowPos.to = vector + new Vector3(0f, 200f, 0f);
			this.ArrowObj.SetActive(true);
			this.HintObj.SetActive(true);
			this.bShowArrow = true;
		}
		else
		{
			this.HintObj.SetActive(false);
			this.ArrowObj.SetActive(false);
			this.bShowArrow = false;
			this.MM.bFirstArrow = false;
		}
	}

	// Token: 0x06001E30 RID: 7728 RVA: 0x0039C5DC File Offset: 0x0039A7DC
	private void SetFGBtn()
	{
		if (this.FGGO == null || this.LightT == null)
		{
			return;
		}
		if (this.bOpenShowEffect || this.EffectRC || this.MM.FullGift_Deadline == 0L)
		{
			this.FGGO.SetActive(false);
			this.LightT.gameObject.SetActive(false);
		}
		else
		{
			this.FGGO.SetActive(true);
			this.LightT.gameObject.SetActive(true);
			this.SetFGTime();
		}
	}

	// Token: 0x06001E31 RID: 7729 RVA: 0x0039C67C File Offset: 0x0039A87C
	private void SetFGTime()
	{
		if (this.FGText == null || this.MM.FullGift_Deadline == 0L)
		{
			return;
		}
		this.FGStr.Length = 0;
		GameConstants.GetTimeString(this.FGStr, (uint)(this.MM.FullGift_Deadline - this.DM.ServerTime), false, true, true, false, true);
		this.FGText.text = this.FGStr.ToString();
		this.FGText.SetAllDirty();
		this.FGText.cachedTextGenerator.Invalidate();
		this.FGImage2.fillAmount = ((this.MM.FullGift_MaxCrystal != 0u) ? ((float)(this.MM.FullGift_NowCrystal / this.MM.FullGift_MaxCrystal)) : 0f);
	}

	// Token: 0x06001E32 RID: 7730 RVA: 0x0039C754 File Offset: 0x0039A954
	private void SetFBBtn()
	{
		if (this.FB_Object == null || this.FB_LightT == null)
		{
			return;
		}
		if (this.MM.PaidDollar == 0L)
		{
			this.FB_Object.SetActive(true);
			this.FB_LightT.gameObject.SetActive(true);
		}
		else
		{
			this.FB_Object.SetActive(false);
			this.FB_LightT.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001E33 RID: 7731 RVA: 0x0039C7D4 File Offset: 0x0039A9D4
	private void UpDateScrollItem()
	{
		for (int i = 0; i < 5; i++)
		{
			if (this.bFindScrollComp[i] && this.ScrollComp[i].DataIndex >= 0 && this.ScrollComp[i].DataIndex < this.MM.MallDataList.Count)
			{
				this.SetBackNameInfo(i, this.ScrollComp[i].DataIndex);
			}
		}
	}

	// Token: 0x06001E34 RID: 7732 RVA: 0x0039C858 File Offset: 0x0039AA58
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			if (sender.m_BtnID2 == 1)
			{
				if (sender.m_BtnID3 >= 0 && sender.m_BtnID3 < this.MM.MallDataList.Count)
				{
					this.MM.Send_Mall_Combobox(this.MM.MallDataList[sender.m_BtnID3].SN);
				}
			}
			else if (sender.m_BtnID2 == 2)
			{
				if (this.MM.CheckbWaitBuy(true))
				{
					return;
				}
				if (this.NeedUpDate)
				{
					this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(614u), this.DM.mStringTable.GetStringByID(10177u), this.DM.mStringTable.GetStringByID(3u), null, 0, 0, false, false, false, false, false);
					return;
				}
				if (sender.m_BtnID3 >= 0 && sender.m_BtnID3 < this.MM.MallDataList.Count)
				{
					this.MM.Send_Mall_Check(this.MM.MallDataList[sender.m_BtnID3].SN, true);
				}
			}
		}
		else if (sender.m_BtnID1 == 2)
		{
			if (sender.m_BtnID2 == 1)
			{
				if (this.MM.CheckbWaitBuy(true))
				{
					return;
				}
				if (this.NeedUpDate)
				{
					this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(614u), this.DM.mStringTable.GetStringByID(10177u), this.DM.mStringTable.GetStringByID(3u), null, 0, 0, false, false, false, false, false);
					return;
				}
				if (sender.m_BtnID3 >= 0 && sender.m_BtnID3 < this.MM.MallDataList.Count)
				{
					this.MM.Send_Mall_Check(this.MM.MallDataList[sender.m_BtnID3].SN, true);
				}
			}
		}
		else if (sender.m_BtnID1 == 3)
		{
			if (sender.m_BtnID2 == 1)
			{
				this.CloseSelf();
			}
		}
		else if (sender.m_BtnID1 == 4)
		{
			if (this.MM.OpenDetail((ushort)sender.m_BtnID2))
			{
				AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
			}
		}
		else if (sender.m_BtnID1 == 5)
		{
			IGGSDKPlugin.SubmitQuestion();
		}
		else if (sender.m_BtnID1 == 6 || sender.m_BtnID1 == 9)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door)
			{
				door.ClearWindowStack(EGUIWindow.UI_Mall, EGUIWindow.MAX);
				door.OpenMenu(EGUIWindow.UI_BagFilter, 0, 2, false);
			}
		}
		else if (sender.m_BtnID1 == 11)
		{
			Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door2)
			{
				door2.OpenMenu(EGUIWindow.UI_Mall_FG, 0, 0, true);
			}
		}
		else if (sender.m_BtnID1 == 12)
		{
			string str = "http://lordsmobile.igg.com/project/probability/?game_id=";
			int num = Mathf.Clamp((int)this.DM.UserLanguage, 1, GameConstants.GlobalEditionGameID.Length - 1);
			string cngameID = GameConstants.CNGameID;
			Application.OpenURL(str + cngameID);
		}
		else if (sender.m_BtnID1 == 13)
		{
			Door door3 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door3)
			{
				door3.OpenMenu(EGUIWindow.UI_Mall_FT, 0, 0, true);
			}
		}
	}

	// Token: 0x06001E35 RID: 7733 RVA: 0x0039CBF0 File Offset: 0x0039ADF0
	public void OnHIButtonClick(UIHIBtn sender)
	{
		if (this.MM.OpenDetail(sender.HIID))
		{
			AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		}
	}

	// Token: 0x06001E36 RID: 7734 RVA: 0x0039CC14 File Offset: 0x0039AE14
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
	}

	// Token: 0x06001E37 RID: 7735 RVA: 0x0039CC58 File Offset: 0x0039AE58
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelObjectIdx < 5)
		{
			if (!this.bFindScrollComp[panelObjectIdx])
			{
				int num = 3;
				this.bFindScrollComp[panelObjectIdx] = true;
				Transform transform = item.transform;
				this.ScrollComp[panelObjectIdx].MyGO = item;
				this.ScrollComp[panelObjectIdx].BackImage1 = transform.GetChild(0).GetComponent<Image>();
				if (this.GM.IsArabic)
				{
					this.ScrollComp[panelObjectIdx].BackImage1.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
				}
				this.ScrollComp[panelObjectIdx].BackImage2 = transform.GetChild(3).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].InfoImage = transform.GetChild(2).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].InfoText = transform.GetChild(2).GetChild(0).GetComponent<UIText>();
				Transform child = transform.GetChild(1);
				this.ScrollComp[panelObjectIdx].Panel1RC = child.GetComponent<RectTransform>();
				this.ScrollComp[panelObjectIdx].TitleText = child.GetChild(0).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].TimeImage = child.GetChild(1).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].TimeText = child.GetChild(2).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].TimeText2 = child.GetChild(3).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].StampImage = child.GetChild(4).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].StampHintBtn = child.GetChild(4).GetComponent<UIButton>();
				this.ScrollComp[panelObjectIdx].StampHintBtn.m_Handler = this;
				this.ScrollComp[panelObjectIdx].StampHintBtn.m_BtnID1 = 100;
				this.ScrollComp[panelObjectIdx].StampHint = this.ScrollComp[panelObjectIdx].StampImage.gameObject.AddComponent<UIButtonHint>();
				this.ScrollComp[panelObjectIdx].StampHint.m_eHint = EUIButtonHint.CountDown;
				this.ScrollComp[panelObjectIdx].StampHint.m_DownUpHandler = this;
				this.ScrollComp[panelObjectIdx].StampHint.Parm2 = 100;
				this.ScrollComp[panelObjectIdx].StampHint.DelayTime = 0.2f;
				if (this.GM.IsArabic)
				{
					this.ScrollComp[panelObjectIdx].StampSA = child.GetComponent<UISpritesArray>();
				}
				else
				{
					this.ScrollComp[panelObjectIdx].StampSA = child.GetChild(4).GetComponent<UISpritesArray>();
				}
				this.ScrollComp[panelObjectIdx].Image1 = child.GetChild(5).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].ScaleImage1 = child.GetChild(5).GetComponent<uTweenScale>();
				this.ScrollComp[panelObjectIdx].ScaleImage1.duration = 0.4f;
				this.ScrollComp[panelObjectIdx].BuyOnceSA = child.GetChild(5).GetComponent<UISpritesArray>();
				this.ScrollComp[panelObjectIdx].Image1Text = child.GetChild(5).GetChild(0).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].Image2L = child.GetChild(6).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].RateSA = child.GetChild(6).GetComponent<UISpritesArray>();
				this.ScrollComp[panelObjectIdx].Image2R = child.GetChild(7).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].CrystalText = child.GetChild(10).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].CrystalImg2 = child.GetChild(11).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].CrystalText2 = child.GetChild(12).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].CrystalText22 = child.GetChild(13).GetComponent<UIText>();
				child.GetChild(15).GetComponent<UIButton>().m_Handler = this;
				child.GetChild(16).GetComponent<UIButton>().m_Handler = this;
				this.ScrollComp[panelObjectIdx].MoreBtn = child.GetChild(15).GetComponent<UIButton>();
				this.ScrollComp[panelObjectIdx].BuyBtn = child.GetChild(16).GetComponent<UIButton>();
				this.ScrollComp[panelObjectIdx].BuyText = child.GetChild(16).GetChild(0).GetComponent<Text>();
				this.ScrollComp[panelObjectIdx].GetAllText = child.GetChild(8).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].BuyGO1 = child.GetChild(16).GetChild(0).gameObject;
				this.ScrollComp[panelObjectIdx].BuyGO2 = child.GetChild(16).GetChild(1).gameObject;
				this.ScrollComp[panelObjectIdx].LableGO = child.GetChild(16).GetChild(4).gameObject;
				this.ScrollComp[panelObjectIdx].LableGO = child.GetChild(16).GetChild(4).gameObject;
				this.ScrollComp[panelObjectIdx].Lable_DisText = child.GetChild(16).GetChild(4).GetChild(0).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].Lable_PriceText1 = child.GetChild(16).GetChild(4).GetChild(1).GetComponent<Text>();
				this.ScrollComp[panelObjectIdx].Lable_PriceText2 = child.GetChild(16).GetChild(4).GetChild(2).GetComponent<Text>();
				child = transform.GetChild(1).GetChild(14);
				this.ScrollComp[panelObjectIdx].AllItemRC = child.GetComponent<RectTransform>();
				this.ScrollComp[panelObjectIdx].AllItemOriginPos = this.ScrollComp[panelObjectIdx].AllItemRC.anchoredPosition;
				this.ScrollComp[panelObjectIdx].ItemT = new Transform[num];
				this.ScrollComp[panelObjectIdx].ItemT2 = new Transform[num];
				this.ScrollComp[panelObjectIdx].ItemText = new UIText[num];
				this.ScrollComp[panelObjectIdx].ItemCountText = new UIText[num];
				this.ScrollComp[panelObjectIdx].Btn1 = new UIButton[num];
				this.ScrollComp[panelObjectIdx].Hint1 = new UIButtonHint[num];
				this.ScrollComp[panelObjectIdx].HIBtn1 = new UIHIBtn[num];
				for (int i = 0; i < num; i++)
				{
					this.ScrollComp[panelObjectIdx].ItemT[i] = child.GetChild(0 + i * 2);
					this.ScrollComp[panelObjectIdx].ItemT2[i] = child.GetChild(1 + i * 2);
					this.ScrollComp[panelObjectIdx].ItemText[i] = child.GetChild(6 + i).GetComponent<UIText>();
					this.ScrollComp[panelObjectIdx].ItemCountText[i] = child.GetChild(9 + i).GetComponent<UIText>();
					this.ScrollComp[panelObjectIdx].ItemT[i].GetComponent<UIHIBtn>().m_Handler = this;
					this.ScrollComp[panelObjectIdx].HIBtn1[i] = this.ScrollComp[panelObjectIdx].ItemT[i].GetComponent<UIHIBtn>();
					this.ScrollComp[panelObjectIdx].Btn1[i] = child.GetChild(12 + i).GetComponent<UIButton>();
					this.ScrollComp[panelObjectIdx].Btn1[i].m_Handler = this;
					this.ScrollComp[panelObjectIdx].Btn1[i].m_BtnID1 = 4;
					this.ScrollComp[panelObjectIdx].Hint1[i] = child.GetChild(12 + i).GetComponent<UIButtonHint>();
					this.ScrollComp[panelObjectIdx].Hint1[i].m_Handler = this;
					this.ScrollComp[panelObjectIdx].Hint1[i].DelayTime = 0.2f;
				}
				child = transform.GetChild(4);
				this.ScrollComp[panelObjectIdx].Panel2RC = child.GetComponent<RectTransform>();
				this.ScrollComp[panelObjectIdx].TitleText_2 = child.GetChild(1).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].CrystalText_2 = child.GetChild(4).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].ItemT_2 = child.GetChild(7);
				this.ScrollComp[panelObjectIdx].ItemText_2 = child.GetChild(8).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].ItemCountText_2 = child.GetChild(9).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].BuyBtn_2 = child.GetChild(11).GetComponent<UIButton>();
				this.ScrollComp[panelObjectIdx].BuyText_2 = child.GetChild(11).GetChild(0).GetComponent<Text>();
				child.GetChild(11).GetComponent<UIButton>().m_Handler = this;
				this.ScrollComp[panelObjectIdx].ItemT_2.GetComponent<UIHIBtn>().m_Handler = this;
				this.ScrollComp[panelObjectIdx].HIBtn2 = this.ScrollComp[panelObjectIdx].ItemT_2.GetComponent<UIHIBtn>();
				this.ScrollComp[panelObjectIdx].Btn2 = child.GetChild(10).GetComponent<UIButton>();
				this.ScrollComp[panelObjectIdx].Btn2.m_Handler = this;
				this.ScrollComp[panelObjectIdx].Btn2.m_BtnID1 = 4;
				this.ScrollComp[panelObjectIdx].Hint2 = child.GetChild(10).GetComponent<UIButtonHint>();
				this.ScrollComp[panelObjectIdx].Hint2.m_Handler = this;
				this.ScrollComp[panelObjectIdx].Hint2.DelayTime = 0.2f;
				child = transform.GetChild(5);
				this.ScrollComp[panelObjectIdx].Panel3RC = child.GetComponent<RectTransform>();
				this.ScrollComp[panelObjectIdx].CrystalText3 = child.GetChild(3).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].CrystalText3.font = this.tmpFont;
				this.ScrollComp[panelObjectIdx].Btn3 = child.GetChild(4).GetComponent<UIButton>();
				this.ScrollComp[panelObjectIdx].Btn3.m_Handler = this;
				this.ScrollComp[panelObjectIdx].Btn3.m_BtnID1 = 6;
				this.NowCrystalStr = StringManager.Instance.SpawnString(30);
				UIButton component;
				if (this.IsJapan)
				{
					child.GetChild(5).gameObject.SetActive(true);
					component = child.GetChild(5).GetComponent<UIButton>();
					component.m_Handler = this;
					UIButtonHint component2 = child.GetChild(5).GetComponent<UIButtonHint>();
					component2.m_Handler = this;
					component2.DelayTime = 0.2f;
					component2.Parm1 = 0;
					component2.Parm2 = byte.MaxValue;
				}
				component = child.GetChild(6).GetComponent<UIButton>();
				component.m_Handler = this;
				this.TimeStr[panelObjectIdx] = StringManager.Instance.SpawnString(30);
				this.CrystalStr[panelObjectIdx] = StringManager.Instance.SpawnString(30);
				this.CrystalStr2[panelObjectIdx] = StringManager.Instance.SpawnString(30);
				this.PriceStr[panelObjectIdx] = StringManager.Instance.SpawnString(30);
				this.DisStr[panelObjectIdx] = StringManager.Instance.SpawnString(30);
				this.PriceStr2[panelObjectIdx] = StringManager.Instance.SpawnString(30);
				this.ItemCountStr[panelObjectIdx] = new CString[3];
				for (int j = 0; j < 3; j++)
				{
					this.ItemCountStr[panelObjectIdx][j] = StringManager.Instance.SpawnString(30);
				}
			}
			if (this.bMain)
			{
				if (dataIdx != 0)
				{
					return;
				}
				dataIdx = this.MM.FindIndexBySN(this.MM.MainData.SN);
			}
			else
			{
				if (dataIdx == 0)
				{
					this.ScrollComp[panelObjectIdx].Panel1RC.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].BackImage1.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].InfoImage.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].Panel2RC.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].BackImage2.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].Panel3RC.gameObject.SetActive(true);
					this.NowCrystalStr.Length = 0;
					StringManager.IntToStr(this.NowCrystalStr, (long)((ulong)this.DM.RoleAttr.Diamond), 1, true);
					this.ScrollComp[panelObjectIdx].CrystalText3.text = this.NowCrystalStr.ToString();
					this.ScrollComp[panelObjectIdx].CrystalText3.SetAllDirty();
					this.ScrollComp[panelObjectIdx].CrystalText3.cachedTextGenerator.Invalidate();
					this.ScrollComp[panelObjectIdx].bTitleCrystal = true;
					return;
				}
				this.ScrollComp[panelObjectIdx].Panel3RC.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].bTitleCrystal = false;
				dataIdx--;
			}
			List<MallDataType> mallDataList = this.MM.MallDataList;
			if (dataIdx < 0 || dataIdx >= mallDataList.Count)
			{
				return;
			}
			MallDataType mallDataType = this.MM.MallDataList[dataIdx];
			this.MM.CalculateTime(dataIdx);
			this.ScrollComp[panelObjectIdx].DataIndex = dataIdx;
			this.ScrollComp[panelObjectIdx].MoreBtn.m_BtnID3 = dataIdx;
			this.ScrollComp[panelObjectIdx].BuyBtn.m_BtnID3 = dataIdx;
			this.ScrollComp[panelObjectIdx].BuyBtn_2.m_BtnID3 = dataIdx;
			ETreasureType type = mallDataType.Type;
			if (type != ETreasureType.ETST_Crystal)
			{
				this.ScrollComp[panelObjectIdx].Panel1RC.gameObject.SetActive(true);
				this.ScrollComp[panelObjectIdx].BackImage1.gameObject.SetActive(true);
				this.ScrollComp[panelObjectIdx].InfoImage.gameObject.SetActive(true);
				this.ScrollComp[panelObjectIdx].Panel2RC.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].BackImage2.gameObject.SetActive(false);
				if (this.GM.IsArabic)
				{
					if (mallDataType.PosType == 2)
					{
						this.ScrollComp[panelObjectIdx].Panel1RC.anchoredPosition = new Vector2(-130f, 0f);
						this.ScrollComp[panelObjectIdx].InfoImage.rectTransform.anchoredPosition = new Vector2(252f, -134f);
						this.ScrollComp[panelObjectIdx].StampImage.rectTransform.anchoredPosition = new Vector2(254f, 44f);
					}
					else if (mallDataType.PosType == 1)
					{
						this.ScrollComp[panelObjectIdx].Panel1RC.anchoredPosition = new Vector2(128f, 0f);
						this.ScrollComp[panelObjectIdx].InfoImage.rectTransform.anchoredPosition = new Vector2(-266f, -134f);
						this.ScrollComp[panelObjectIdx].StampImage.rectTransform.anchoredPosition = new Vector2(-257.2f, 22f);
					}
				}
				else if (mallDataType.PosType == 1)
				{
					this.ScrollComp[panelObjectIdx].Panel1RC.anchoredPosition = new Vector2(-120f, 0f);
					this.ScrollComp[panelObjectIdx].InfoImage.rectTransform.anchoredPosition = new Vector2(262f, -134f);
					this.ScrollComp[panelObjectIdx].StampImage.rectTransform.anchoredPosition = new Vector2(254f, 44f);
				}
				else if (mallDataType.PosType == 2)
				{
					this.ScrollComp[panelObjectIdx].Panel1RC.anchoredPosition = new Vector2(138f, 0f);
					this.ScrollComp[panelObjectIdx].InfoImage.rectTransform.anchoredPosition = new Vector2(-256f, -134f);
					this.ScrollComp[panelObjectIdx].StampImage.rectTransform.anchoredPosition = new Vector2(-257.2f, 22f);
				}
				if (mallDataType.StampPic != 0 && (int)(mallDataType.StampPic - 1) < this.ScrollComp[panelObjectIdx].StampSA.m_Sprites.Length)
				{
					this.ScrollComp[panelObjectIdx].StampImage.gameObject.SetActive(true);
					this.ScrollComp[panelObjectIdx].StampSA.SetSpriteIndex((int)(mallDataType.StampPic - 1));
					this.ScrollComp[panelObjectIdx].StampHint.Parm1 = mallDataType.StampHint;
				}
				else
				{
					this.ScrollComp[panelObjectIdx].StampImage.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].StampHint.Parm1 = 0;
				}
				this.SetBackNameInfo(panelObjectIdx, dataIdx);
				if (mallDataType.Type == ETreasureType.ETST_SHLevelUp)
				{
					this.ScrollComp[panelObjectIdx].TimeText.enabled = false;
					this.ScrollComp[panelObjectIdx].TimeImage.enabled = false;
					if (mallDataType.EndTime > 0L)
					{
						this.ScrollComp[panelObjectIdx].TimeText2.enabled = true;
						this.TimeStr[panelObjectIdx].Length = 0;
						GameConstants.GetTimeString(this.TimeStr[panelObjectIdx], mallDataType.uTime, false, false, true, false, false);
						this.ScrollComp[panelObjectIdx].TimeText2.text = this.TimeStr[panelObjectIdx].ToString();
						this.ScrollComp[panelObjectIdx].TimeText2.SetAllDirty();
						this.ScrollComp[panelObjectIdx].TimeText2.cachedTextGenerator.Invalidate();
					}
					else
					{
						this.ScrollComp[panelObjectIdx].TimeText2.enabled = false;
					}
				}
				else
				{
					this.ScrollComp[panelObjectIdx].TimeText2.enabled = false;
					if (mallDataType.EndTime > 0L)
					{
						this.ScrollComp[panelObjectIdx].TimeText.enabled = true;
						this.ScrollComp[panelObjectIdx].TimeImage.enabled = true;
						this.TimeStr[panelObjectIdx].Length = 0;
						GameConstants.GetTimeString(this.TimeStr[panelObjectIdx], mallDataType.uTime, false, false, true, false, true);
						this.ScrollComp[panelObjectIdx].TimeText.text = this.TimeStr[panelObjectIdx].ToString();
						this.ScrollComp[panelObjectIdx].TimeText.SetAllDirty();
						this.ScrollComp[panelObjectIdx].TimeText.cachedTextGenerator.Invalidate();
					}
					else
					{
						this.ScrollComp[panelObjectIdx].TimeText.enabled = false;
						this.ScrollComp[panelObjectIdx].TimeImage.enabled = false;
					}
				}
				if (type == ETreasureType.ETST_Month)
				{
					this.ScrollComp[panelObjectIdx].GetAllText.text = this.DM.mStringTable.GetStringByID(919u);
				}
				else
				{
					this.ScrollComp[panelObjectIdx].GetAllText.text = this.DM.mStringTable.GetStringByID(838u);
				}
				this.ScrollComp[panelObjectIdx].ScaleImage1.enabled = false;
				this.ScrollComp[panelObjectIdx].Image1.rectTransform.localScale = Vector3.one;
				if (type == ETreasureType.ETST_Month)
				{
					this.ScrollComp[panelObjectIdx].Image1.enabled = true;
					this.ScrollComp[panelObjectIdx].Image1Text.enabled = true;
					this.ScrollComp[panelObjectIdx].Image1Text.text = this.DM.mStringTable.GetStringByID(918u);
					this.ScrollComp[panelObjectIdx].BuyOnceSA.SetSpriteIndex((int)mallDataType.BuyOncePic);
					if (this.ScrollComp[panelObjectIdx].Image1.sprite == null)
					{
						this.ScrollComp[panelObjectIdx].BuyOnceSA.SetSpriteIndex(0);
					}
				}
				else if (type == ETreasureType.ETST_SHLevelUp)
				{
					this.ScrollComp[panelObjectIdx].ScaleImage1.enabled = true;
					this.ScrollComp[panelObjectIdx].Image1.enabled = true;
					this.ScrollComp[panelObjectIdx].Image1Text.enabled = true;
					this.ScrollComp[panelObjectIdx].Image1Text.text = this.DM.mStringTable.GetStringByID(10075u);
					this.ScrollComp[panelObjectIdx].BuyOnceSA.SetSpriteIndex((int)mallDataType.BuyOncePic);
					if (this.ScrollComp[panelObjectIdx].Image1.sprite == null)
					{
						this.ScrollComp[panelObjectIdx].BuyOnceSA.SetSpriteIndex(0);
					}
				}
				else if (mallDataType.bBuyOnce == 1)
				{
					this.ScrollComp[panelObjectIdx].Image1.enabled = true;
					this.ScrollComp[panelObjectIdx].Image1Text.enabled = true;
					this.ScrollComp[panelObjectIdx].Image1Text.text = this.DM.mStringTable.GetStringByID(865u);
					this.ScrollComp[panelObjectIdx].BuyOnceSA.SetSpriteIndex((int)mallDataType.BuyOncePic);
					if (this.ScrollComp[panelObjectIdx].Image1.sprite == null)
					{
						this.ScrollComp[panelObjectIdx].BuyOnceSA.SetSpriteIndex(0);
					}
				}
				else
				{
					this.ScrollComp[panelObjectIdx].Image1.enabled = false;
					this.ScrollComp[panelObjectIdx].Image1Text.enabled = false;
				}
				if (mallDataType.BonusRate > 0)
				{
					this.ScrollComp[panelObjectIdx].Image2L.enabled = true;
					this.ScrollComp[panelObjectIdx].Image2R.enabled = true;
					this.ScrollComp[panelObjectIdx].RateSA.SetSpriteIndex((int)(mallDataType.BonusRate - 1));
				}
				else
				{
					this.ScrollComp[panelObjectIdx].Image2L.enabled = false;
					this.ScrollComp[panelObjectIdx].Image2R.enabled = false;
				}
				int num2 = 0;
				if (!this.MM.GetProductPointByID((int)mallDataType.TreasureID, out num2))
				{
					this.NeedUpDate = true;
				}
				this.CrystalStr[panelObjectIdx].Length = 0;
				if (type == ETreasureType.ETST_Month)
				{
					this.CrystalStr[panelObjectIdx].IntToFormat((long)((ulong)(mallDataType.BonusCrystal * 30u)), 1, true);
				}
				else if (this.NeedUpDate)
				{
					this.CrystalStr[panelObjectIdx].StringToFormat("-");
				}
				else
				{
					this.CrystalStr[panelObjectIdx].IntToFormat((long)num2, 1, true);
				}
				this.CrystalStr[panelObjectIdx].AppendFormat("{0}");
				this.ScrollComp[panelObjectIdx].CrystalText.text = this.CrystalStr[panelObjectIdx].ToString();
				this.ScrollComp[panelObjectIdx].CrystalText.SetAllDirty();
				this.ScrollComp[panelObjectIdx].CrystalText.cachedTextGenerator.Invalidate();
				this.CrystalStr2[panelObjectIdx].Length = 0;
				this.CrystalStr2[panelObjectIdx].IntToFormat((long)((ulong)mallDataType.BonusCrystal), 1, true);
				this.CrystalStr2[panelObjectIdx].AppendFormat("{0}");
				this.ScrollComp[panelObjectIdx].CrystalText2.text = this.CrystalStr2[panelObjectIdx].ToString();
				this.ScrollComp[panelObjectIdx].CrystalText2.SetAllDirty();
				this.ScrollComp[panelObjectIdx].CrystalText2.cachedTextGenerator.Invalidate();
				this.NeedUpDate = (this.MM.SetPriceStr(this.PriceStr[panelObjectIdx], (int)mallDataType.TreasureID, false, 0) || this.NeedUpDate);
				if (mallDataType.Discount > 0)
				{
					this.ScrollComp[panelObjectIdx].LableGO.SetActive(true);
					this.ScrollComp[panelObjectIdx].BuyGO1.SetActive(false);
					this.ScrollComp[panelObjectIdx].BuyGO2.SetActive(false);
					this.DisStr[panelObjectIdx].Length = 0;
					this.DisStr[panelObjectIdx].IntToFormat((long)mallDataType.Discount, 1, false);
					this.DisStr[panelObjectIdx].AppendFormat("-{0}%");
					this.ScrollComp[panelObjectIdx].Lable_DisText.text = this.DisStr[panelObjectIdx].ToString();
					this.ScrollComp[panelObjectIdx].Lable_DisText.SetAllDirty();
					this.ScrollComp[panelObjectIdx].Lable_DisText.cachedTextGenerator.Invalidate();
					this.MM.SetPriceStr(this.PriceStr2[panelObjectIdx], (int)mallDataType.TreasureID, true, mallDataType.Discount);
					this.ScrollComp[panelObjectIdx].Lable_PriceText1.text = this.PriceStr2[panelObjectIdx].ToString();
					this.ScrollComp[panelObjectIdx].Lable_PriceText1.SetAllDirty();
					this.ScrollComp[panelObjectIdx].Lable_PriceText1.cachedTextGenerator.Invalidate();
					this.ScrollComp[panelObjectIdx].Lable_PriceText2.text = this.PriceStr[panelObjectIdx].ToString();
					this.ScrollComp[panelObjectIdx].Lable_PriceText2.SetAllDirty();
					this.ScrollComp[panelObjectIdx].Lable_PriceText2.cachedTextGenerator.Invalidate();
				}
				else
				{
					this.ScrollComp[panelObjectIdx].LableGO.SetActive(false);
					this.ScrollComp[panelObjectIdx].BuyGO1.SetActive(true);
					this.ScrollComp[panelObjectIdx].BuyGO2.SetActive(true);
					this.ScrollComp[panelObjectIdx].BuyText.text = this.PriceStr[panelObjectIdx].ToString();
					this.ScrollComp[panelObjectIdx].BuyText.SetAllDirty();
					this.ScrollComp[panelObjectIdx].BuyText.cachedTextGenerator.Invalidate();
				}
				int k = 0;
				while (k < 3)
				{
					if (k != 2)
					{
						goto IL_1C77;
					}
					if (mallDataType.BonusCrystal == 0u || mallDataType.Type == ETreasureType.ETST_Month)
					{
						this.ScrollComp[panelObjectIdx].ItemText[k].gameObject.SetActive(true);
						this.ScrollComp[panelObjectIdx].ItemCountText[k].gameObject.SetActive(true);
						goto IL_1C77;
					}
					this.ScrollComp[panelObjectIdx].ItemText[k].gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].ItemCountText[k].gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].ItemT[k].gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].ItemT2[k].gameObject.SetActive(false);
					IL_1F9E:
					k++;
					continue;
					IL_1C77:
					Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(mallDataType.BriefItem[k].ItemID);
					byte equipKind = recordByKey.EquipKind;
					this.ScrollComp[panelObjectIdx].Btn1[k].m_BtnID2 = (int)mallDataType.BriefItem[k].ItemID;
					this.ScrollComp[panelObjectIdx].Hint1[k].Parm1 = mallDataType.BriefItem[k].ItemID;
					this.ScrollComp[panelObjectIdx].Hint1[k].Parm2 = mallDataType.BriefItem[k].ItemRank;
					bool flag = this.GM.IsLeadItem(equipKind);
					if (flag)
					{
						GUIManager.Instance.ChangeLordEquipImg(this.ScrollComp[panelObjectIdx].ItemT2[k], mallDataType.BriefItem[k].ItemID, mallDataType.BriefItem[k].ItemRank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
					}
					else
					{
						GUIManager.Instance.ChangeHeroItemImg(this.ScrollComp[panelObjectIdx].ItemT[k], eHeroOrItem.Item, mallDataType.BriefItem[k].ItemID, 0, 0, 0);
					}
					if (flag || !this.MM.CheckCanOpenDetail(mallDataType.BriefItem[k].ItemID))
					{
						this.ScrollComp[panelObjectIdx].Hint1[k].enabled = true;
					}
					else
					{
						this.ScrollComp[panelObjectIdx].Hint1[k].enabled = false;
					}
					this.ScrollComp[panelObjectIdx].ItemT[k].gameObject.SetActive(!flag);
					this.ScrollComp[panelObjectIdx].ItemT2[k].gameObject.SetActive(flag);
					this.ScrollComp[panelObjectIdx].ItemText[k].text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.EquipName);
					this.ScrollComp[panelObjectIdx].ItemText[k].color = this.MM.GetItemRankColor(mallDataType.BriefItem[k].ItemRank);
					this.ItemCountStr[panelObjectIdx][k].Length = 0;
					if (type == ETreasureType.ETST_Month)
					{
						StringManager.IntToStr(this.ItemCountStr[panelObjectIdx][k], (long)(mallDataType.BriefItem[k].Num * 30), 1, true);
					}
					else
					{
						StringManager.IntToStr(this.ItemCountStr[panelObjectIdx][k], (long)mallDataType.BriefItem[k].Num, 1, true);
					}
					this.ScrollComp[panelObjectIdx].ItemCountText[k].text = this.ItemCountStr[panelObjectIdx][k].ToString();
					this.ScrollComp[panelObjectIdx].ItemCountText[k].SetAllDirty();
					this.ScrollComp[panelObjectIdx].ItemCountText[k].cachedTextGenerator.Invalidate();
					goto IL_1F9E;
				}
				if (mallDataType.BonusCrystal == 0u || type == ETreasureType.ETST_Month)
				{
					this.ScrollComp[panelObjectIdx].CrystalImg2.enabled = false;
					this.ScrollComp[panelObjectIdx].CrystalText2.enabled = false;
					this.ScrollComp[panelObjectIdx].CrystalText22.enabled = false;
					this.ScrollComp[panelObjectIdx].AllItemRC.anchoredPosition = this.ScrollComp[panelObjectIdx].AllItemOriginPos + new Vector2(0f, 62f);
				}
				else
				{
					this.ScrollComp[panelObjectIdx].CrystalImg2.enabled = true;
					this.ScrollComp[panelObjectIdx].CrystalText2.enabled = true;
					this.ScrollComp[panelObjectIdx].CrystalText22.enabled = true;
					this.ScrollComp[panelObjectIdx].AllItemRC.anchoredPosition = this.ScrollComp[panelObjectIdx].AllItemOriginPos;
				}
			}
			else
			{
				this.ScrollComp[panelObjectIdx].Panel1RC.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].BackImage1.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].InfoImage.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].Panel2RC.gameObject.SetActive(true);
				this.ScrollComp[panelObjectIdx].BackImage2.gameObject.SetActive(true);
				this.ScrollComp[panelObjectIdx].TitleText_2.text = this.DM.mStringTable.GetStringByID((uint)mallDataType.StrPackageID);
				int num3 = 0;
				if (!this.MM.GetProductPointByID((int)mallDataType.TreasureID, out num3))
				{
					this.NeedUpDate = true;
				}
				this.CrystalStr[panelObjectIdx].Length = 0;
				this.CrystalStr[panelObjectIdx].IntToFormat((long)num3 + (long)((ulong)mallDataType.BonusCrystal), 1, true);
				this.CrystalStr[panelObjectIdx].AppendFormat("{0}");
				this.ScrollComp[panelObjectIdx].CrystalText_2.text = this.CrystalStr[panelObjectIdx].ToString();
				this.ScrollComp[panelObjectIdx].CrystalText_2.SetAllDirty();
				this.ScrollComp[panelObjectIdx].CrystalText_2.cachedTextGenerator.Invalidate();
				this.NeedUpDate = (this.MM.SetPriceStr(this.PriceStr[panelObjectIdx], (int)mallDataType.TreasureID, false, 0) || this.NeedUpDate);
				this.ScrollComp[panelObjectIdx].BuyText_2.text = this.PriceStr[panelObjectIdx].ToString();
				this.ScrollComp[panelObjectIdx].BuyText_2.SetAllDirty();
				this.ScrollComp[panelObjectIdx].BuyText_2.cachedTextGenerator.Invalidate();
				Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(mallDataType.BriefItem[0].ItemID);
				this.ScrollComp[panelObjectIdx].Btn2.m_BtnID2 = (int)mallDataType.BriefItem[0].ItemID;
				this.ScrollComp[panelObjectIdx].Hint2.Parm1 = mallDataType.BriefItem[0].ItemID;
				this.ScrollComp[panelObjectIdx].Hint2.Parm2 = mallDataType.BriefItem[0].ItemRank;
				GUIManager.Instance.ChangeHeroItemImg(this.ScrollComp[panelObjectIdx].ItemT_2, eHeroOrItem.Item, mallDataType.BriefItem[0].ItemID, 0, 0, 0);
				if (!this.MM.CheckCanOpenDetail(mallDataType.BriefItem[0].ItemID))
				{
					this.ScrollComp[panelObjectIdx].Hint2.enabled = true;
				}
				else
				{
					this.ScrollComp[panelObjectIdx].Hint2.enabled = false;
				}
				this.ScrollComp[panelObjectIdx].ItemText_2.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey2.EquipName);
				this.ItemCountStr[panelObjectIdx][0].Length = 0;
				StringManager.IntToStr(this.ItemCountStr[panelObjectIdx][0], (long)mallDataType.BriefItem[0].Num, 1, true);
				this.ScrollComp[panelObjectIdx].ItemCountText_2.text = this.ItemCountStr[panelObjectIdx][0].ToString();
				this.ScrollComp[panelObjectIdx].ItemCountText_2.SetAllDirty();
				this.ScrollComp[panelObjectIdx].ItemCountText_2.cachedTextGenerator.Invalidate();
			}
		}
	}

	// Token: 0x06001E38 RID: 7736 RVA: 0x0039F0E4 File Offset: 0x0039D2E4
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001E39 RID: 7737 RVA: 0x0039F0E8 File Offset: 0x0039D2E8
	public void OnButtonDown(UIButtonHint sender)
	{
		if (sender.Parm2 == 100 && sender.Parm1 != 0)
		{
			this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 277f, 20, (int)sender.Parm1, 0, Vector2.zero, UIButtonHint.ePosition.Original);
			return;
		}
		if (this.IsJapan && sender.Parm1 == 0 && sender.Parm2 == 255)
		{
			this.JPHintObject.gameObject.SetActive(true);
		}
		else
		{
			byte equipKind = DataManager.Instance.EquipTable.GetRecordByKey(sender.Parm1).EquipKind;
			bool flag = this.GM.IsLeadItem(equipKind);
			if (flag)
			{
				sender.SetFadeOutObject(EUIButtonHint.UILeBtn);
				this.GM.m_LordInfo.Show(sender, sender.Parm1, sender.Parm2, -1);
			}
			else
			{
				sender.SetFadeOutObject(EUIButtonHint.UIHIBtn);
				this.GM.m_SimpleItemInfo.Show(sender, sender.Parm1, -1, UIButtonHint.ePosition.Original, null);
			}
			AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		}
	}

	// Token: 0x06001E3A RID: 7738 RVA: 0x0039F200 File Offset: 0x0039D400
	public void OnButtonUp(UIButtonHint sender)
	{
		if (sender.Parm2 == 100)
		{
			this.GM.m_Hint.Hide(false);
			return;
		}
		if (this.IsJapan && sender.Parm1 == 0 && sender.Parm2 == 255)
		{
			this.JPHintObject.gameObject.SetActive(false);
		}
		else
		{
			byte equipKind = DataManager.Instance.EquipTable.GetRecordByKey(sender.Parm1).EquipKind;
			bool flag = this.GM.IsLeadItem(equipKind);
			if (flag)
			{
				this.GM.m_LordInfo.Hide(sender);
			}
			else
			{
				GUIManager.Instance.m_SimpleItemInfo.Hide(sender);
			}
		}
	}

	// Token: 0x06001E3B RID: 7739 RVA: 0x0039F2C0 File Offset: 0x0039D4C0
	private void CloseSelf()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			door.CloseMenu(false);
		}
		this.GM.UIQueueLockRelease(EGUIQueueLock.UIQL_Mall);
	}

	// Token: 0x06001E3C RID: 7740 RVA: 0x0039F300 File Offset: 0x0039D500
	public override bool OnBackButtonClick()
	{
		this.CloseSelf();
		return true;
	}

	// Token: 0x06001E3D RID: 7741 RVA: 0x0039F30C File Offset: 0x0039D50C
	private void SavePos()
	{
		this.MM.MallUIIndex = this.Scroll.GetTopIdx();
		this.MM.MallUIPos = this.cScrollRect.content.anchoredPosition.y;
	}

	// Token: 0x06001E3E RID: 7742 RVA: 0x0039F354 File Offset: 0x0039D554
	private void BeginEffect(bool bReverse = false)
	{
		this.FBEffectScale = 1f;
		if (this.EffectRC)
		{
			this.EffectRC = null;
			this.EffectTimer = 0f;
			this.FGTimer = 0f;
			if (this.EffectParticle != null)
			{
				if (this.EffectParticle.activeSelf && ParticleManager.Instance.AllEffectObject != null)
				{
					this.EffectParticle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
				}
				this.EffectParticle = null;
			}
		}
		this.EffectReverse = bReverse;
		if (!this.EffectReverse)
		{
			this.MM.SetShowEffect(false);
			this.EffectRC = this.m_transform.GetChild(13).GetComponent<RectTransform>();
			this.EffectImage1 = this.m_transform.GetChild(13).GetComponent<Image>();
			this.EffectImage2 = this.m_transform.GetChild(13).GetChild(0).GetComponent<Image>();
			this.EffectImage2.gameObject.SetActive(true);
			this.EffectRC.anchoredPosition = Vector2.zero;
			this.EffectScale = 0f;
			this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
			this.Effectalpha = 0f;
			this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
			this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
			this.FGRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
			this.FGImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
			this.FGImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
			this.tmpSA.SetSpriteIndex(0);
			this.EffectImage1.SetNativeSize();
			this.EffectPos = this.m_transform.GetChild(14).GetComponent<RectTransform>();
			this.EffectPos.gameObject.SetActive(true);
			this.EffectPos.localPosition = new Vector3(0f, 0f, -700f);
			this.EffectRC.gameObject.SetActive(true);
			this.EffectParticle = ParticleManager.Instance.Spawn(433, this.EffectPos.transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
			this.EffectParticle.transform.localPosition = new Vector3(0f, 0f, 0f);
			this.EffectParticle.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			GUIManager.Instance.SetLayer(this.EffectParticle, 5);
			AudioManager.Instance.PlayUISFX(UIKind.Crystal_Show);
			this.SetFGBtn();
		}
		else
		{
			this.EffectRC = this.m_transform.GetChild(13).GetComponent<RectTransform>();
			this.EffectImage1 = this.m_transform.GetChild(13).GetComponent<Image>();
			this.EffectImage2 = this.m_transform.GetChild(13).GetChild(0).GetComponent<Image>();
			this.EffectImage2.gameObject.SetActive(true);
			this.EffectRC.anchoredPosition = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f - 38f, -(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - 49f));
			this.EffectScale = 0.6f;
			this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
			this.Effectalpha = 0.17f;
			this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
			this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
			this.EffectScale = 1f;
			this.FGRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
			this.Effectalpha = 1f;
			this.FGImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
			this.FGImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
			this.tmpSA.SetSpriteIndex(0);
			this.EffectImage1.SetNativeSize();
			this.EffectPos = this.m_transform.GetChild(14).GetComponent<RectTransform>();
			this.EffectPos.gameObject.SetActive(true);
			this.EffectPos.localPosition = new Vector3(0f, 0f, -700f);
			this.EffectRC.gameObject.SetActive(true);
			this.FGGO.SetActive(true);
			GUIManager.Instance.pDVMgr.ShowMallGetItemText(false);
		}
	}

	// Token: 0x06001E3F RID: 7743 RVA: 0x0039F8E8 File Offset: 0x0039DAE8
	private void EndEffect()
	{
		this.EffectRC = null;
		this.EffectTimer = 0f;
		this.FGTimer = 0f;
		this.EffectParticle = null;
		this.FGRC.localScale = new Vector3(1f, 1f, 1f);
		this.FGImage1.color = new Color(1f, 1f, 1f, 1f);
		this.FGImage2.color = new Color(1f, 1f, 1f, 1f);
		this.SetFGBtn();
		this.SetFBBtn();
		GUIManager.Instance.pDVMgr.BeginMoveBossText();
	}

	// Token: 0x06001E40 RID: 7744 RVA: 0x0039F99C File Offset: 0x0039DB9C
	private void BeginGetCrystal(int getCrystal)
	{
		if (this.bPlayGetCrystal)
		{
			this.EndGetCrystal();
		}
		this.bPlayGetCrystal = true;
		this.FGEffImage1.color = new Color(1f, 1f, 1f, 0.2f);
		this.FGEffImage2.color = new Color(1f, 1f, 1f, 0.2f);
		this.FGEffImage2.rectTransform.anchoredPosition = new Vector2(0f, 15f);
		this.FGEffText.color = new Color(this.FGEffText.color.r, this.FGEffText.color.g, this.FGEffText.color.b, 0.2f);
		this.FGEffText.rectTransform.anchoredPosition = new Vector2(0f, 10f);
		this.FGEffStr.Length = 0;
		this.FGEffStr.IntToFormat((long)getCrystal, 1, false);
		this.FGEffStr.AppendFormat("+{0}");
		this.FGEffText.text = this.FGEffStr.ToString();
		this.FGEffText.SetAllDirty();
		this.FGEffText.cachedTextGenerator.Invalidate();
		this.FGEffText.gameObject.SetActive(true);
		this.FGEffImage1.gameObject.SetActive(true);
		this.FGEffImage2.gameObject.SetActive(true);
		AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
	}

	// Token: 0x06001E41 RID: 7745 RVA: 0x0039FB38 File Offset: 0x0039DD38
	private void EndGetCrystal()
	{
		this.bPlayGetCrystal = false;
		this.GetCrystalNowTime = 0f;
		this.FGEffText.gameObject.SetActive(false);
		this.FGEffImage1.gameObject.SetActive(false);
		this.FGEffImage2.gameObject.SetActive(false);
	}

	// Token: 0x06001E42 RID: 7746 RVA: 0x0039FB8C File Offset: 0x0039DD8C
	private bool CheckLiveChatLanguage()
	{
		return this.DM.UserLanguage == GameLanguage.GL_Eng || this.DM.UserLanguage == GameLanguage.GL_Idn || this.DM.UserLanguage == GameLanguage.GL_Rus || this.DM.UserLanguage == GameLanguage.GL_Tha || this.DM.UserLanguage == GameLanguage.GL_Vet;
	}

	// Token: 0x06001E43 RID: 7747 RVA: 0x0039FBF0 File Offset: 0x0039DDF0
	private void Begin_FT_Effect(bool bReverse = true)
	{
		this.bPlayAudio = true;
		this.FBEffectScale = 1.3f;
		this.MM.FirstGift_bShowEffect = false;
		if (this.EffectRC)
		{
			this.EffectRC = null;
			this.EffectTimer = 0f;
			this.FGTimer = 0f;
		}
		this.EffectReverse = bReverse;
		this.EffectRC = this.m_transform.GetChild(13).GetComponent<RectTransform>();
		this.EffectImage1 = this.m_transform.GetChild(13).GetComponent<Image>();
		this.tmpSA.SetSpriteIndex(1);
		this.EffectImage1.SetNativeSize();
		this.EffectImage2 = this.m_transform.GetChild(13).GetChild(0).GetComponent<Image>();
		this.EffectImage2.gameObject.SetActive(false);
		this.EffectRC.anchoredPosition = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f - 38f, -(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - 49f));
		this.EffectScale = 0.6f;
		this.EffectRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
		this.Effectalpha = 0.17f;
		this.EffectImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
		this.EffectImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
		this.EffectScale = 1f;
		this.FGRC.localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
		this.Effectalpha = 1f;
		this.FGImage1.color = new Color(1f, 1f, 1f, this.Effectalpha);
		this.FGImage2.color = new Color(1f, 1f, 1f, this.Effectalpha);
		this.EffectPos = this.m_transform.GetChild(14).GetComponent<RectTransform>();
		this.EffectPos.gameObject.SetActive(true);
		this.EffectPos.localPosition = new Vector3(0f, 0f, -700f);
		this.EffectRC.gameObject.SetActive(true);
		GUIManager.Instance.pDVMgr.ShowMallGetItem_FT_Text(false);
		GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(10186u), 255, true);
		this.SetFBBtn();
	}

	// Token: 0x04005F5D RID: 24413
	private const int UnitCount = 5;

	// Token: 0x04005F5E RID: 24414
	private Transform m_transform;

	// Token: 0x04005F5F RID: 24415
	private Transform UnitObjectT;

	// Token: 0x04005F60 RID: 24416
	private Transform LightT;

	// Token: 0x04005F61 RID: 24417
	private Transform FB_LightT;

	// Token: 0x04005F62 RID: 24418
	private DataManager DM;

	// Token: 0x04005F63 RID: 24419
	private GUIManager GM;

	// Token: 0x04005F64 RID: 24420
	private MallManager MM;

	// Token: 0x04005F65 RID: 24421
	private Font tmpFont;

	// Token: 0x04005F66 RID: 24422
	private CScrollRect cScrollRect;

	// Token: 0x04005F67 RID: 24423
	private ScrollPanel Scroll;

	// Token: 0x04005F68 RID: 24424
	private List<float> NowHeightList = new List<float>();

	// Token: 0x04005F69 RID: 24425
	private bool[] bFindScrollComp = new bool[5];

	// Token: 0x04005F6A RID: 24426
	private UnitComp_Mall[] ScrollComp = new UnitComp_Mall[5];

	// Token: 0x04005F6B RID: 24427
	private CString[] TimeStr = new CString[5];

	// Token: 0x04005F6C RID: 24428
	private CString[] CrystalStr = new CString[5];

	// Token: 0x04005F6D RID: 24429
	private CString[] CrystalStr2 = new CString[5];

	// Token: 0x04005F6E RID: 24430
	private CString[] PriceStr = new CString[5];

	// Token: 0x04005F6F RID: 24431
	private CString[][] ItemCountStr = new CString[5][];

	// Token: 0x04005F70 RID: 24432
	private CString NowCrystalStr;

	// Token: 0x04005F71 RID: 24433
	private CString FGStr;

	// Token: 0x04005F72 RID: 24434
	private CString[] DisStr = new CString[5];

	// Token: 0x04005F73 RID: 24435
	private CString[] PriceStr2 = new CString[5];

	// Token: 0x04005F74 RID: 24436
	private UIText LiveChatText;

	// Token: 0x04005F75 RID: 24437
	private UIText HintText;

	// Token: 0x04005F76 RID: 24438
	private UIText FGText;

	// Token: 0x04005F77 RID: 24439
	private bool bMain;

	// Token: 0x04005F78 RID: 24440
	private GameObject ArrowObj;

	// Token: 0x04005F79 RID: 24441
	private GameObject HintObj;

	// Token: 0x04005F7A RID: 24442
	private GameObject FGGO;

	// Token: 0x04005F7B RID: 24443
	private uTweenPosition ArrowPos;

	// Token: 0x04005F7C RID: 24444
	private bool bShowArrow;

	// Token: 0x04005F7D RID: 24445
	private float CheckTimer;

	// Token: 0x04005F7E RID: 24446
	private float BeginPos;

	// Token: 0x04005F7F RID: 24447
	private bool NeedUpDate;

	// Token: 0x04005F80 RID: 24448
	private bool IsJapan = DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn;

	// Token: 0x04005F81 RID: 24449
	private CString[] JHintStr = new CString[2];

	// Token: 0x04005F82 RID: 24450
	private GameObject JPHintObject;

	// Token: 0x04005F83 RID: 24451
	private UIText[] JPText = new UIText[5];

	// Token: 0x04005F84 RID: 24452
	private Color TimeTextColor = new Color(1f, 0.9411f, 0.5568f);

	// Token: 0x04005F85 RID: 24453
	private bool bResourceRed;

	// Token: 0x04005F86 RID: 24454
	private float ResourceRedTime;

	// Token: 0x04005F87 RID: 24455
	private Image FGImage1;

	// Token: 0x04005F88 RID: 24456
	private Image FGImage2;

	// Token: 0x04005F89 RID: 24457
	private RectTransform FGRC;

	// Token: 0x04005F8A RID: 24458
	private Image EffectImage1;

	// Token: 0x04005F8B RID: 24459
	private Image EffectImage2;

	// Token: 0x04005F8C RID: 24460
	private RectTransform EffectRC;

	// Token: 0x04005F8D RID: 24461
	private Transform EffectPos;

	// Token: 0x04005F8E RID: 24462
	private Image FGEffImage1;

	// Token: 0x04005F8F RID: 24463
	private Image FGEffImage2;

	// Token: 0x04005F90 RID: 24464
	private UIText FGEffText;

	// Token: 0x04005F91 RID: 24465
	private CString FGEffStr;

	// Token: 0x04005F92 RID: 24466
	private bool bPlayGetCrystal;

	// Token: 0x04005F93 RID: 24467
	private float GetCrystalTime = 1.3f;

	// Token: 0x04005F94 RID: 24468
	private float GetCrystalNowTime;

	// Token: 0x04005F95 RID: 24469
	private float EffectTimer;

	// Token: 0x04005F96 RID: 24470
	private float FGTimer;

	// Token: 0x04005F97 RID: 24471
	private float EffectScale;

	// Token: 0x04005F98 RID: 24472
	private float Effectalpha;

	// Token: 0x04005F99 RID: 24473
	private Vector2 bezierEnd = Vector2.zero;

	// Token: 0x04005F9A RID: 24474
	private GameObject EffectParticle;

	// Token: 0x04005F9B RID: 24475
	private bool EffectReverse;

	// Token: 0x04005F9C RID: 24476
	private bool bOpenShowEffect;

	// Token: 0x04005F9D RID: 24477
	private float OpenShowTime = 0.5f;

	// Token: 0x04005F9E RID: 24478
	private bool bOpenShowFBEffect;

	// Token: 0x04005F9F RID: 24479
	private GameObject FB_Object;

	// Token: 0x04005FA0 RID: 24480
	private UIText FB_Text;

	// Token: 0x04005FA1 RID: 24481
	private UISpritesArray tmpSA;

	// Token: 0x04005FA2 RID: 24482
	private float FBEffectScale = 1f;

	// Token: 0x04005FA3 RID: 24483
	private bool bPlayAudio = true;
}
