using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000624 RID: 1572
public class UIMall_Detail : GUIWindow, UILoadImageHander, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUILEBtnClickHandler
{
	// Token: 0x170000B8 RID: 184
	// (get) Token: 0x06001E45 RID: 7749 RVA: 0x0039FFB8 File Offset: 0x0039E1B8
	public Door door
	{
		get
		{
			if (this.m_door == null)
			{
				this.m_door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
			}
			return this.m_door;
		}
	}

	// Token: 0x06001E46 RID: 7750 RVA: 0x0039FFE8 File Offset: 0x0039E1E8
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.MM = MallManager.Instance;
		this.m_transform = base.transform;
		this.tmpFont = this.GM.GetTTFFont();
		this.DataIndex = arg1;
		this.tmpData = this.MM.MallDataList[arg1];
		this.SN = this.tmpData.SN;
		this.bLastItem = this.CheckShowLastItem();
		this.Back = this.m_transform.GetChild(2).GetComponent<Image>();
		this.m_transform.GetChild(4).GetComponent<Image>().color = this.tmpData.FrameColor;
		this.m_transform.GetChild(21).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(21).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 3;
		this.m_transform.GetChild(21).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(21).GetComponent<CustomImage>().hander = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(21).GetComponent<CustomImage>().enabled = false;
		}
		this.m_transform.GetChild(19).GetComponent<UIButton>().m_Handler = this;
		if (this.tmpData.SetNo == 0 || this.tmpData.SetNo == 65535)
		{
			this.m_transform.GetChild(19).gameObject.SetActive(false);
		}
		Transform child = this.m_transform.GetChild(20);
		child.GetComponent<UIButton>().m_Handler = this;
		this.BuyText = child.GetChild(1).GetComponent<UIText>();
		this.BuyText.font = this.tmpFont;
		this.BuyText.text = this.DM.mStringTable.GetStringByID(866u);
		this.PriceStr = StringManager.Instance.SpawnString(30);
		this.NeedUpDate = this.MM.SetPriceStr(this.PriceStr, (int)this.tmpData.TreasureID, false, 0);
		this.PriceText = child.GetChild(0).GetComponent<Text>();
		this.PriceText.font = this.tmpFont;
		if (this.GM.IsArabic)
		{
			this.PriceText.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		if (this.tmpData.Discount > 0)
		{
			child.GetChild(0).gameObject.SetActive(false);
			child.GetChild(1).gameObject.SetActive(false);
			child.GetChild(4).gameObject.SetActive(true);
			this.Lable_DisText = child.GetChild(4).GetChild(0).GetComponent<UIText>();
			this.Lable_DisText.font = this.tmpFont;
			this.DisStr = StringManager.Instance.SpawnString(30);
			this.DisStr.Length = 0;
			this.DisStr.IntToFormat((long)this.tmpData.Discount, 1, false);
			this.DisStr.AppendFormat("-{0}%");
			this.Lable_DisText.text = this.DisStr.ToString();
			this.Lable_DisText.SetAllDirty();
			this.Lable_DisText.cachedTextGenerator.Invalidate();
			this.Lable_PriceText1 = child.GetChild(4).GetChild(1).GetComponent<Text>();
			this.Lable_PriceText1.font = this.tmpFont;
			if (this.GM.IsArabic)
			{
				this.Lable_PriceText1.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
			}
			this.PriceStr2 = StringManager.Instance.SpawnString(30);
			this.MM.SetPriceStr(this.PriceStr2, (int)this.tmpData.TreasureID, true, this.tmpData.Discount);
			this.Lable_PriceText1.text = this.PriceStr2.ToString();
			this.Lable_PriceText1.SetAllDirty();
			this.Lable_PriceText1.cachedTextGenerator.Invalidate();
			this.Lable_PriceText2 = child.GetChild(4).GetChild(2).GetComponent<Text>();
			this.Lable_PriceText2.font = this.tmpFont;
			if (this.GM.IsArabic)
			{
				this.Lable_PriceText2.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
			}
			this.Lable_PriceText2.text = this.PriceStr.ToString();
			this.Lable_PriceText2.SetAllDirty();
			this.Lable_PriceText2.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.PriceText.text = this.PriceStr.ToString();
			this.PriceText.SetAllDirty();
			this.PriceText.cachedTextGenerator.Invalidate();
		}
		if (this.tmpData.BonusRate > 0)
		{
			this.m_transform.GetChild(14).GetComponent<UISpritesArray>().SetSpriteIndex((int)(this.tmpData.BonusRate - 1));
		}
		else
		{
			this.m_transform.GetChild(14).GetComponent<Image>().enabled = false;
			this.m_transform.GetChild(15).GetComponent<Image>().enabled = false;
		}
		this.PackageName = this.m_transform.GetChild(7).GetComponent<UIText>();
		this.PackageName.font = this.tmpFont;
		this.GatAllText = this.m_transform.GetChild(16).GetComponent<UIText>();
		this.GatAllText.font = this.tmpFont;
		if (this.tmpData.Type == ETreasureType.ETST_Month)
		{
			this.GatAllText.text = this.DM.mStringTable.GetStringByID(919u);
		}
		else
		{
			this.GatAllText.text = this.DM.mStringTable.GetStringByID(838u);
		}
		if (this.tmpData.Type == ETreasureType.ETST_Month)
		{
			this.OnceText = this.m_transform.GetChild(13).GetComponent<UIText>();
			this.OnceText.font = this.tmpFont;
			this.OnceText.text = this.DM.mStringTable.GetStringByID(918u);
		}
		else if (this.tmpData.Type == ETreasureType.ETST_SHLevelUp)
		{
			this.OnceText = this.m_transform.GetChild(13).GetComponent<UIText>();
			this.OnceText.font = this.tmpFont;
			this.OnceText.text = this.DM.mStringTable.GetStringByID(10075u);
		}
		else if (this.tmpData.bBuyOnce == 1)
		{
			this.OnceText = this.m_transform.GetChild(13).GetComponent<UIText>();
			this.OnceText.font = this.tmpFont;
			this.OnceText.text = this.DM.mStringTable.GetStringByID(865u);
		}
		else
		{
			this.m_transform.GetChild(13).gameObject.SetActive(false);
			this.m_transform.GetChild(12).gameObject.SetActive(false);
		}
		this.TimeStr = StringManager.Instance.SpawnString(30);
		this.SetTimeTextAndPic();
		Transform child2 = this.m_transform.GetChild(18);
		this.GM.InitianHeroItemImg(child2.GetChild(2), eHeroOrItem.Item, 1, 0, 0, 0, false, false, true, false);
		child2.GetChild(2).gameObject.AddComponent<IgnoreRaycast>();
		this.GM.InitLordEquipImg(child2.GetChild(3), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		child2.GetChild(3).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
		UIText component = child2.GetChild(4).GetComponent<UIText>();
		component.font = this.tmpFont;
		component = child2.GetChild(5).GetComponent<UIText>();
		component.font = this.tmpFont;
		child2.GetChild(6).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
		this.SetBackName();
		this.Scroll = this.m_transform.GetChild(17).GetComponent<ScrollPanel>();
		this.Scroll.IntiScrollPanel(358f, 0f, 0f, this.NowHeightList, 9, this);
		this.cScrollRect = this.Scroll.GetComponent<CScrollRect>();
		UIButtonHint.scrollRect = this.cScrollRect;
		this.UpDateList();
		this.GM.UpdateUI(EGUIWindow.Door, 1, 1);
		if (!this.tmpData.bAskDetailData)
		{
			if (this.MM.FindIndexBySN(this.tmpData.SN) != -1)
			{
				this.MM.bSendMallInfo = true;
				this.MM.AutoDetailSN = this.tmpData.SN;
				GUIManager.Instance.ShowUILock(EUILock.Mall);
			}
			else if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
		}
		this.OpenEnd = true;
	}

	// Token: 0x06001E47 RID: 7751 RVA: 0x003A091C File Offset: 0x0039EB1C
	public override void OnClose()
	{
		if (this.TimeStr != null)
		{
			StringManager.Instance.DeSpawnString(this.TimeStr);
		}
		for (int i = 0; i < 9; i++)
		{
			if (this.CountStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.CountStr[i]);
			}
			if (this.NameStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.NameStr[i]);
			}
		}
		StringManager.Instance.DeSpawnString(this.PriceStr);
		StringManager.Instance.DeSpawnString(this.DisStr);
		StringManager.Instance.DeSpawnString(this.PriceStr2);
		this.tmpData.UnloadAB(true);
	}

	// Token: 0x06001E48 RID: 7752 RVA: 0x003A09D8 File Offset: 0x0039EBD8
	private void UpDatePriceAndCrystal()
	{
		if (!this.OpenEnd)
		{
			return;
		}
		this.MM.SetPriceStr(this.PriceStr, (int)this.tmpData.TreasureID, false, 0);
		if (this.tmpData.Discount > 0)
		{
			this.MM.SetPriceStr(this.PriceStr2, (int)this.tmpData.TreasureID, true, this.tmpData.Discount);
			this.Lable_PriceText1.text = this.PriceStr2.ToString();
			this.Lable_PriceText1.SetAllDirty();
			this.Lable_PriceText1.cachedTextGenerator.Invalidate();
			this.Lable_PriceText2.text = this.PriceStr.ToString();
			this.Lable_PriceText2.SetAllDirty();
			this.Lable_PriceText2.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.PriceText.text = this.PriceStr.ToString();
			this.PriceText.SetAllDirty();
			this.PriceText.cachedTextGenerator.Invalidate();
		}
		for (int i = 0; i < 9; i++)
		{
			if (this.bFindScrollComp[i] && this.ScrollComp[i].DataIndex == 0)
			{
				int num = 0;
				this.MM.GetProductPointByID((int)this.tmpData.TreasureID, out num);
				this.CountStr[i].Length = 0;
				StringManager.IntToStr(this.CountStr[i], (long)((ulong)num), 1, true);
				this.ScrollComp[i].ItemCountText.text = this.CountStr[i].ToString();
				this.ScrollComp[i].ItemCountText.SetAllDirty();
				this.ScrollComp[i].ItemCountText.cachedTextGenerator.Invalidate();
			}
		}
	}

	// Token: 0x06001E49 RID: 7753 RVA: 0x003A0BA8 File Offset: 0x0039EDA8
	private void Update()
	{
		if (this.NeedUpDate && IGGGameSDK.Instance.bPaymentReady)
		{
			this.NeedUpDate = false;
			this.UpDatePriceAndCrystal();
		}
		if (this.bLVUPPack && this.TimeText != null)
		{
			this.ResourceRedTime += Time.deltaTime;
			if (this.ResourceRedTime >= 0.5f)
			{
				this.ResourceRedTime = 0f;
				this.bResourceRed = !this.bResourceRed;
				if (this.bResourceRed)
				{
					this.TimeText.color = Color.red;
				}
				else
				{
					this.TimeText.color = Color.white;
				}
			}
		}
	}

	// Token: 0x06001E4A RID: 7754 RVA: 0x003A0C64 File Offset: 0x0039EE64
	private void UpdateTime()
	{
		if (this.TimeText == null)
		{
			return;
		}
		this.TimeStr.Length = 0;
		if (this.bLVUPPack)
		{
			GameConstants.GetTimeString(this.TimeStr, this.tmpData.uTime, false, false, true, false, false);
		}
		else
		{
			GameConstants.GetTimeString(this.TimeStr, this.tmpData.uTime, false, false, true, false, true);
		}
		this.TimeText.text = this.TimeStr.ToString();
		this.TimeText.SetAllDirty();
		this.TimeText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001E4B RID: 7755 RVA: 0x003A0D08 File Offset: 0x0039EF08
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				for (int i = 0; i < 9; i++)
				{
					if (this.bFindScrollComp[i])
					{
						if (this.ScrollComp[i].ItemName != null && this.ScrollComp[i].ItemName.enabled)
						{
							this.ScrollComp[i].ItemName.enabled = false;
							this.ScrollComp[i].ItemName.enabled = true;
						}
						if (this.ScrollComp[i].ItemCountText != null && this.ScrollComp[i].ItemCountText.enabled)
						{
							this.ScrollComp[i].ItemCountText.enabled = false;
							this.ScrollComp[i].ItemCountText.enabled = true;
						}
						if (this.ScrollComp[i].HIBtn != null)
						{
							this.ScrollComp[i].HIBtn.Refresh_FontTexture();
						}
					}
				}
				if (this.PriceText != null && this.PriceText.enabled)
				{
					this.PriceText.enabled = false;
					this.PriceText.enabled = true;
				}
				if (this.BuyText != null && this.BuyText.enabled)
				{
					this.BuyText.enabled = false;
					this.BuyText.enabled = true;
				}
				if (this.GatAllText != null && this.GatAllText.enabled)
				{
					this.GatAllText.enabled = false;
					this.GatAllText.enabled = true;
				}
				if (this.OnceText != null && this.OnceText.enabled)
				{
					this.OnceText.enabled = false;
					this.OnceText.enabled = true;
				}
				if (this.PackageName != null && this.PackageName.enabled)
				{
					this.PackageName.enabled = false;
					this.PackageName.enabled = true;
				}
				if (this.TimeText != null && this.TimeText.enabled)
				{
					this.TimeText.enabled = false;
					this.TimeText.enabled = true;
				}
				if (this.Lable_DisText != null && this.Lable_DisText.enabled)
				{
					this.Lable_DisText.enabled = false;
					this.Lable_DisText.enabled = true;
				}
				if (this.Lable_PriceText1 != null && this.Lable_PriceText1.enabled)
				{
					this.Lable_PriceText1.enabled = false;
					this.Lable_PriceText1.enabled = true;
				}
				if (this.Lable_PriceText2 != null && this.Lable_PriceText2.enabled)
				{
					this.Lable_PriceText2.enabled = false;
					this.Lable_PriceText2.enabled = true;
				}
			}
			break;
		}
	}

	// Token: 0x06001E4C RID: 7756 RVA: 0x003A1060 File Offset: 0x0039F260
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
			if (this.DataIndex == arg2 && this.door)
			{
				this.door.CloseMenu(false);
			}
		}
		else if (arg1 != 2)
		{
			if (arg1 == 4)
			{
				this.MM.AutoDetailSN = this.SN;
			}
			else if (arg1 == 5)
			{
				this.SetBackName();
			}
			else if (arg1 == 6)
			{
				this.bLastItem = this.CheckShowLastItem();
				if (this.m_transform != null && this.tmpData != null)
				{
					this.DataIndex = this.MM.FindIndexBySN(this.SN);
					this.tmpData = this.MM.MallDataList[this.DataIndex];
					this.SetTimeTextAndPic();
					this.m_transform.GetChild(4).GetComponent<Image>().color = this.tmpData.FrameColor;
				}
				this.SavePos();
				this.UpDateList();
				this.SetBackName();
			}
		}
	}

	// Token: 0x06001E4D RID: 7757 RVA: 0x003A11AC File Offset: 0x0039F3AC
	private void UpDateList()
	{
		this.ItemCount = 0;
		this.NowHeightList.Clear();
		this.NowHeightList.Add(55f);
		this.ItemCount += 1;
		if (this.tmpData.BonusCrystal > 0u && this.tmpData.Type != ETreasureType.ETST_Month)
		{
			this.NowHeightList.Add(55f);
			this.ItemCount += 1;
		}
		for (int i = 0; i < (int)this.tmpData.DataLen; i++)
		{
			if (this.tmpData.Item[i].ItemID != 0)
			{
				this.NowHeightList.Add(55f);
				this.ItemCount += 1;
			}
		}
		this.AllianceGiftCount = 0;
		for (int j = 0; j < this.tmpData.AllianceGift.Length; j++)
		{
			if (this.tmpData.AllianceGift[j].ItemID != 0)
			{
				this.NowHeightList.Add(55f);
				this.ItemCount += 1;
				this.AllianceGiftCount += 1;
			}
		}
		if (this.bLastItem)
		{
			this.NowHeightList.Add(55f);
			this.NowHeightList.Add(55f);
			this.ItemCount += 1;
			this.ItemCount += 1;
		}
		this.Scroll.AddNewDataHeight(this.NowHeightList, true, true);
		if (this.UIIndex != -1)
		{
			this.Scroll.GoTo(this.UIIndex, this.UIPos);
		}
		this.UpdateTime();
	}

	// Token: 0x06001E4E RID: 7758 RVA: 0x003A1374 File Offset: 0x0039F574
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelObjectIdx < 9)
		{
			Vector2 anchoredPosition = Vector2.zero;
			if (!this.bFindScrollComp[panelObjectIdx])
			{
				this.bFindScrollComp[panelObjectIdx] = true;
				this.ScrollComp[panelObjectIdx].CrystalImg = item.transform.GetChild(1).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].HIBtn = item.transform.GetChild(2).GetComponent<UIHIBtn>();
				this.ScrollComp[panelObjectIdx].HIBtn.m_Handler = this;
				this.ScrollComp[panelObjectIdx].Hint = item.transform.GetChild(2).GetComponent<UIButtonHint>();
				this.ScrollComp[panelObjectIdx].LEBtn = item.transform.GetChild(3).GetComponent<UILEBtn>();
				this.ScrollComp[panelObjectIdx].LEBtn.m_Handler = this;
				this.ScrollComp[panelObjectIdx].ItemName = item.transform.GetChild(4).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].ItemCountRC = item.transform.GetChild(5).GetComponent<RectTransform>();
				this.ScrollComp[panelObjectIdx].ItemCountText = item.transform.GetChild(5).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].ItemCountOutline = item.transform.GetChild(5).GetComponent<Outline>();
				this.ScrollComp[panelObjectIdx].LineImage = item.transform.GetChild(0).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].Btn3 = item.transform.GetChild(6).GetComponent<UIButton>();
				this.ScrollComp[panelObjectIdx].Hint3 = item.transform.GetChild(6).GetComponent<UIButtonHint>();
				this.ScrollComp[panelObjectIdx].Hint3.m_Handler = this;
				this.ScrollComp[panelObjectIdx].Hint3.DelayTime = 0.2f;
				this.OriginImagePos = this.ScrollComp[panelObjectIdx].CrystalImg.rectTransform.anchoredPosition;
				this.OriginCountPos = this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition;
				this.CountStr[panelObjectIdx] = StringManager.Instance.SpawnString(30);
				this.NameStr[panelObjectIdx] = StringManager.Instance.SpawnString(150);
				if (this.GM.IsArabic)
				{
					this.ScrollComp[panelObjectIdx].ItemCountText.AdjuestUI();
				}
			}
			if (dataIdx < 0 || dataIdx > (int)this.ItemCount)
			{
				return;
			}
			int num = (this.tmpData.BonusCrystal <= 0u || this.tmpData.Type == ETreasureType.ETST_Month) ? 0 : 1;
			ushort num2 = 1;
			byte b = 0;
			this.ScrollComp[panelObjectIdx].DataIndex = -1;
			uint num4;
			if (this.tmpData.AllianceGiftShowTop == 1)
			{
				if (dataIdx == 0)
				{
					int num3 = 0;
					if (!this.MM.GetProductPointByID((int)this.tmpData.TreasureID, out num3))
					{
						this.NeedUpDate = true;
					}
					if (this.tmpData.Type == ETreasureType.ETST_Month)
					{
						num4 = this.tmpData.BonusCrystal * 30u;
					}
					else
					{
						num4 = (uint)num3;
					}
					this.ScrollComp[panelObjectIdx].DataIndex = dataIdx;
					this.ScrollComp[panelObjectIdx].ItemName.text = string.Empty;
					this.ScrollComp[panelObjectIdx].CrystalImg.enabled = true;
					this.ScrollComp[panelObjectIdx].LEBtn.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].HIBtn.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].Btn3.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].CrystalImg.rectTransform.anchoredPosition = this.OriginImagePos + new Vector2(218f, 0f);
					this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleCenter;
					this.ScrollComp[panelObjectIdx].ItemCountText.color = this.ItemNameCrystalColor;
					anchoredPosition = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos + new Vector2(-15f, 0f));
					this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = anchoredPosition;
				}
				else if (num == 1 && dataIdx == 1)
				{
					num4 = this.tmpData.BonusCrystal;
					this.ScrollComp[panelObjectIdx].CrystalImg.enabled = true;
					this.ScrollComp[panelObjectIdx].LEBtn.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].HIBtn.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].Btn3.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].CrystalImg.rectTransform.anchoredPosition = this.OriginImagePos;
					this.ScrollComp[panelObjectIdx].ItemName.fontSize = 28;
					this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 28;
					this.ScrollComp[panelObjectIdx].ItemCountText.color = this.ItemCountCrystalColor;
					this.ScrollComp[panelObjectIdx].ItemCountOutline.effectColor = this.ItemCountCrystalOutLineColor;
					anchoredPosition = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos);
					this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = anchoredPosition;
					this.ScrollComp[panelObjectIdx].ItemCountText.alignment = ((!this.GM.IsArabic) ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft);
					this.ScrollComp[panelObjectIdx].ItemName.color = this.ItemNameCrystalColor;
				}
				else if (dataIdx > num && dataIdx < (int)this.AllianceGiftCount + (num + 1))
				{
					int num5 = dataIdx - (num + 1);
					num2 = this.tmpData.AllianceGift[num5].ItemID;
					num4 = (uint)this.tmpData.AllianceGift[num5].Num;
					this.ScrollComp[panelObjectIdx].CrystalImg.enabled = false;
					this.ScrollComp[panelObjectIdx].CrystalImg.rectTransform.anchoredPosition = this.OriginImagePos;
					this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
					this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
					this.ScrollComp[panelObjectIdx].ItemCountText.color = this.ItemCountOriginColor;
					this.ScrollComp[panelObjectIdx].ItemCountOutline.effectColor = this.ItemCountOutLineOriginColor;
					anchoredPosition = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos);
					this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = anchoredPosition;
					this.ScrollComp[panelObjectIdx].ItemCountText.alignment = ((!this.GM.IsArabic) ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft);
					this.ScrollComp[panelObjectIdx].ItemName.color = this.ItemCountOriginColor;
				}
				else
				{
					if (this.bLastItem && dataIdx == (int)(this.ItemCount - 1))
					{
						num2 = 1255;
						num4 = 1u;
					}
					else if (this.bLastItem && dataIdx == (int)(this.ItemCount - 2))
					{
						num2 = 1309;
						num4 = 1u;
					}
					else
					{
						int num6 = dataIdx - (num + 1) - (int)this.AllianceGiftCount;
						num2 = this.tmpData.Item[num6].ItemID;
						if (this.tmpData.Type == ETreasureType.ETST_Month)
						{
							num4 = (uint)(this.tmpData.Item[num6].Num * 30);
						}
						else
						{
							num4 = (uint)this.tmpData.Item[num6].Num;
						}
						b = this.tmpData.Item[num6].ItemRank;
					}
					this.ScrollComp[panelObjectIdx].CrystalImg.enabled = false;
					this.ScrollComp[panelObjectIdx].CrystalImg.rectTransform.anchoredPosition = this.OriginImagePos;
					this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
					this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
					this.ScrollComp[panelObjectIdx].ItemCountText.color = this.ItemCountOriginColor;
					this.ScrollComp[panelObjectIdx].ItemCountOutline.effectColor = this.ItemCountOutLineOriginColor;
					anchoredPosition = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos);
					this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = anchoredPosition;
					this.ScrollComp[panelObjectIdx].ItemCountText.alignment = ((!this.GM.IsArabic) ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft);
					this.ScrollComp[panelObjectIdx].ItemName.color = this.ItemCountOriginColor;
				}
			}
			else if (dataIdx == 0)
			{
				int num7 = 0;
				if (!this.MM.GetProductPointByID((int)this.tmpData.TreasureID, out num7))
				{
					this.NeedUpDate = true;
				}
				if (this.tmpData.Type == ETreasureType.ETST_Month)
				{
					num4 = this.tmpData.BonusCrystal * 30u;
				}
				else
				{
					num4 = (uint)num7;
				}
				this.ScrollComp[panelObjectIdx].DataIndex = dataIdx;
				this.ScrollComp[panelObjectIdx].ItemName.text = string.Empty;
				this.ScrollComp[panelObjectIdx].CrystalImg.enabled = true;
				this.ScrollComp[panelObjectIdx].LEBtn.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].HIBtn.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].Btn3.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].CrystalImg.rectTransform.anchoredPosition = this.OriginImagePos + new Vector2(218f, 0f);
				this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleCenter;
				this.ScrollComp[panelObjectIdx].ItemCountText.color = this.ItemNameCrystalColor;
				anchoredPosition = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos + new Vector2(-15f, 0f));
				this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = anchoredPosition;
			}
			else if (num == 1 && dataIdx == 1)
			{
				num4 = this.tmpData.BonusCrystal;
				this.ScrollComp[panelObjectIdx].CrystalImg.enabled = true;
				this.ScrollComp[panelObjectIdx].LEBtn.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].HIBtn.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].Btn3.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].CrystalImg.rectTransform.anchoredPosition = this.OriginImagePos;
				this.ScrollComp[panelObjectIdx].ItemName.fontSize = 28;
				this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 28;
				this.ScrollComp[panelObjectIdx].ItemCountText.color = this.ItemCountCrystalColor;
				this.ScrollComp[panelObjectIdx].ItemCountOutline.effectColor = this.ItemCountCrystalOutLineColor;
				anchoredPosition = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos);
				this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = anchoredPosition;
				this.ScrollComp[panelObjectIdx].ItemCountText.alignment = ((!this.GM.IsArabic) ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft);
				this.ScrollComp[panelObjectIdx].ItemName.color = this.ItemNameCrystalColor;
			}
			else if (dataIdx > num && dataIdx < (int)this.tmpData.DataLen + (num + 1))
			{
				int num8 = dataIdx - (num + 1);
				num2 = this.tmpData.Item[num8].ItemID;
				if (this.tmpData.Type == ETreasureType.ETST_Month)
				{
					num4 = (uint)(this.tmpData.Item[num8].Num * 30);
				}
				else
				{
					num4 = (uint)this.tmpData.Item[num8].Num;
				}
				b = this.tmpData.Item[num8].ItemRank;
				this.ScrollComp[panelObjectIdx].CrystalImg.enabled = false;
				this.ScrollComp[panelObjectIdx].CrystalImg.rectTransform.anchoredPosition = this.OriginImagePos;
				this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
				this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
				this.ScrollComp[panelObjectIdx].ItemCountText.color = this.ItemCountOriginColor;
				this.ScrollComp[panelObjectIdx].ItemCountOutline.effectColor = this.ItemCountOutLineOriginColor;
				anchoredPosition = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos);
				this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = anchoredPosition;
				this.ScrollComp[panelObjectIdx].ItemCountText.alignment = ((!this.GM.IsArabic) ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft);
				this.ScrollComp[panelObjectIdx].ItemName.color = this.ItemCountOriginColor;
			}
			else
			{
				if (this.bLastItem && dataIdx == (int)(this.ItemCount - 1))
				{
					num2 = 1255;
					num4 = 1u;
				}
				else if (this.bLastItem && dataIdx == (int)(this.ItemCount - 2))
				{
					num2 = 1309;
					num4 = 1u;
				}
				else
				{
					int num9 = dataIdx - (num + 1) - (int)this.tmpData.DataLen;
					num2 = this.tmpData.AllianceGift[num9].ItemID;
					num4 = (uint)this.tmpData.AllianceGift[num9].Num;
				}
				this.ScrollComp[panelObjectIdx].CrystalImg.enabled = false;
				this.ScrollComp[panelObjectIdx].CrystalImg.rectTransform.anchoredPosition = this.OriginImagePos;
				this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
				this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
				this.ScrollComp[panelObjectIdx].ItemCountText.color = this.ItemCountOriginColor;
				this.ScrollComp[panelObjectIdx].ItemCountOutline.effectColor = this.ItemCountOutLineOriginColor;
				anchoredPosition = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos);
				this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = anchoredPosition;
				this.ScrollComp[panelObjectIdx].ItemCountText.alignment = ((!this.GM.IsArabic) ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft);
				this.ScrollComp[panelObjectIdx].ItemName.color = this.ItemCountOriginColor;
			}
			this.ScrollComp[panelObjectIdx].LineImage.color = new Color(this.tmpData.LineColor.r, this.tmpData.LineColor.g, this.tmpData.LineColor.b);
			if (num == 1 && dataIdx == 1)
			{
				this.NameStr[panelObjectIdx].Length = 0;
				StringManager.IntToStr(this.NameStr[panelObjectIdx], (long)((ulong)num4), 1, true);
				this.ScrollComp[panelObjectIdx].ItemName.text = this.NameStr[panelObjectIdx].ToString();
				this.ScrollComp[panelObjectIdx].ItemName.SetAllDirty();
				this.ScrollComp[panelObjectIdx].ItemName.cachedTextGenerator.Invalidate();
				this.ScrollComp[panelObjectIdx].ItemName.fontSize = 28;
				this.ScrollComp[panelObjectIdx].ItemCountText.text = this.DM.mStringTable.GetStringByID(876u);
			}
			else
			{
				if (dataIdx > 0)
				{
					Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(num2);
					byte equipKind = recordByKey.EquipKind;
					this.ScrollComp[panelObjectIdx].Hint3.Parm1 = num2;
					this.ScrollComp[panelObjectIdx].Hint3.Parm2 = b;
					bool flag = this.GM.IsLeadItem(equipKind);
					if (flag)
					{
						GUIManager.Instance.ChangeLordEquipImg(this.ScrollComp[panelObjectIdx].LEBtn.transform, num2, b, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
					}
					else
					{
						GUIManager.Instance.ChangeHeroItemImg(this.ScrollComp[panelObjectIdx].HIBtn.transform, eHeroOrItem.Item, num2, 0, 0, 0);
					}
					this.ScrollComp[panelObjectIdx].LEBtn.gameObject.SetActive(flag);
					this.ScrollComp[panelObjectIdx].HIBtn.gameObject.SetActive(!flag);
					if (flag || !this.MM.CheckCanOpenDetail(num2))
					{
						this.ScrollComp[panelObjectIdx].Hint3.enabled = true;
					}
					else
					{
						this.ScrollComp[panelObjectIdx].Hint3.enabled = false;
					}
					this.ScrollComp[panelObjectIdx].Btn3.gameObject.SetActive(this.ScrollComp[panelObjectIdx].Hint3.enabled);
					this.NameStr[panelObjectIdx].Length = 0;
					this.NameStr[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.EquipName));
					this.NameStr[panelObjectIdx].AppendFormat("{0}");
					this.ScrollComp[panelObjectIdx].ItemName.text = this.NameStr[panelObjectIdx].ToString();
					this.ScrollComp[panelObjectIdx].ItemName.color = this.MM.GetItemRankColor(b);
					this.ScrollComp[panelObjectIdx].ItemName.SetAllDirty();
					this.ScrollComp[panelObjectIdx].ItemName.cachedTextGenerator.Invalidate();
				}
				this.CountStr[panelObjectIdx].Length = 0;
				if (dataIdx == 0 && this.tmpData.Type != ETreasureType.ETST_Month && this.NeedUpDate)
				{
					this.CountStr[panelObjectIdx].Append("-");
				}
				else
				{
					StringManager.IntToStr(this.CountStr[panelObjectIdx], (long)((ulong)num4), 1, true);
				}
				this.ScrollComp[panelObjectIdx].ItemCountText.text = this.CountStr[panelObjectIdx].ToString();
				this.ScrollComp[panelObjectIdx].ItemCountText.SetAllDirty();
				this.ScrollComp[panelObjectIdx].ItemCountText.cachedTextGenerator.Invalidate();
			}
		}
	}

	// Token: 0x06001E4F RID: 7759 RVA: 0x003A2798 File Offset: 0x003A0998
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		int num = (this.tmpData.BonusCrystal <= 0u || this.tmpData.Type == ETreasureType.ETST_Month) ? 0 : 1;
		if (dataIndex < num + 1 || dataIndex > (int)this.ItemCount)
		{
			return;
		}
		ushort hiid;
		if (this.tmpData.AllianceGiftShowTop == 1)
		{
			if (dataIndex > num && dataIndex < (int)this.AllianceGiftCount + (num + 1))
			{
				int num2 = dataIndex - (num + 1);
				hiid = this.tmpData.AllianceGift[num2].ItemID;
			}
			else if (this.bLastItem && dataIndex == (int)(this.ItemCount - 1))
			{
				hiid = 1255;
			}
			else if (this.bLastItem && dataIndex == (int)(this.ItemCount - 2))
			{
				hiid = 1309;
			}
			else
			{
				int num3 = dataIndex - (num + 1) - (int)this.AllianceGiftCount;
				hiid = this.tmpData.Item[num3].ItemID;
			}
		}
		else if (dataIndex > num && dataIndex < (int)this.tmpData.DataLen + (num + 1))
		{
			int num4 = dataIndex - (num + 1);
			hiid = this.tmpData.Item[num4].ItemID;
		}
		else if (this.bLastItem && dataIndex == (int)(this.ItemCount - 1))
		{
			hiid = 1255;
		}
		else if (this.bLastItem && dataIndex == (int)(this.ItemCount - 2))
		{
			hiid = 1309;
		}
		else
		{
			int num5 = dataIndex - (num + 1) - (int)this.tmpData.DataLen;
			hiid = this.tmpData.AllianceGift[num5].ItemID;
		}
		if (this.MM.CheckCanOpenDetail(hiid) && this.MM.OpenDetail(hiid))
		{
			AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		}
	}

	// Token: 0x06001E50 RID: 7760 RVA: 0x003A2984 File Offset: 0x003A0B84
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
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
				this.MM.Send_Mall_Check(this.tmpData.SN, true);
			}
			if (sender.m_BtnID2 == 2)
			{
				if (this.GM.BuildingData.GetBuildData(15, 0).Level < 1)
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(7533u), 255, true);
					return;
				}
				if (this.DM.mLordEquip == null)
				{
					this.DM.mLordEquip = LordEquipData.Instance();
				}
				if (this.door)
				{
					this.door.ClearWindowStack(EGUIWindow.UI_Mall, EGUIWindow.UI_Mall_Detail);
					this.DM.mLordEquip.OpenForgeSet(this.tmpData.SetNo, 4);
				}
			}
			if (sender.m_BtnID2 == 3 && this.door)
			{
				this.door.CloseMenu(false);
			}
		}
		else if (sender.m_BtnID1 == 2)
		{
		}
	}

	// Token: 0x06001E51 RID: 7761 RVA: 0x003A2B14 File Offset: 0x003A0D14
	public void OnHIButtonClick(UIHIBtn sender)
	{
		if (this.MM.OpenDetail(sender.HIID))
		{
			AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		}
	}

	// Token: 0x06001E52 RID: 7762 RVA: 0x003A2B38 File Offset: 0x003A0D38
	public void OnLEButtonClick(UILEBtn sender)
	{
	}

	// Token: 0x06001E53 RID: 7763 RVA: 0x003A2B3C File Offset: 0x003A0D3C
	public void OnButtonDown(UIButtonHint sender)
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

	// Token: 0x06001E54 RID: 7764 RVA: 0x003A2BD8 File Offset: 0x003A0DD8
	public void OnButtonUp(UIButtonHint sender)
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

	// Token: 0x06001E55 RID: 7765 RVA: 0x003A2C3C File Offset: 0x003A0E3C
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		if (this.door)
		{
			img.sprite = this.door.LoadSprite(ImageName);
			img.material = this.door.LoadMaterial();
		}
	}

	// Token: 0x06001E56 RID: 7766 RVA: 0x003A2C7C File Offset: 0x003A0E7C
	public void SetTimeTextAndPic()
	{
		if (this.m_transform == null || this.tmpData == null)
		{
			return;
		}
		this.TimeStr.Length = 0;
		if (this.tmpData.Type == ETreasureType.ETST_SHLevelUp)
		{
			this.bLVUPPack = true;
			this.m_transform.GetChild(10).GetComponent<UIText>().enabled = false;
			this.m_transform.GetChild(9).GetComponent<Image>().enabled = false;
			this.m_transform.GetChild(11).gameObject.SetActive(true);
			GameConstants.GetTimeString(this.TimeStr, this.tmpData.uTime, false, false, true, false, false);
			this.TimeText = this.m_transform.GetChild(11).GetComponent<UIText>();
		}
		else
		{
			this.bLVUPPack = false;
			this.m_transform.GetChild(10).GetComponent<UIText>().enabled = (this.tmpData.EndTime != 0L);
			this.m_transform.GetChild(9).GetComponent<Image>().enabled = (this.tmpData.EndTime != 0L);
			this.m_transform.GetChild(11).gameObject.SetActive(false);
			GameConstants.GetTimeString(this.TimeStr, (uint)(this.tmpData.EndTime - this.DM.ServerTime), false, false, true, false, true);
			this.TimeText = this.m_transform.GetChild(10).GetComponent<UIText>();
		}
		this.TimeText.font = this.tmpFont;
		this.TimeText.text = this.TimeStr.ToString();
		this.TimeText.SetAllDirty();
		this.TimeText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001E57 RID: 7767 RVA: 0x003A2E40 File Offset: 0x003A1040
	public void SetBackName()
	{
		if (this.tmpData.bDownLoadPic)
		{
			if (this.tmpData.bUpDatePic)
			{
				this.tmpData.UnloadAB(true);
				this.tmpData.bUpDatePic = false;
			}
			if (this.tmpData.m_AssetBundleKey == 0)
			{
				this.tmpData.InitialAB();
			}
			this.Back.sprite = this.tmpData.m_BackImage2;
			this.Back.material = this.tmpData.m_Material;
			this.Back.gameObject.SetActive(true);
		}
		if (this.tmpData.bDownLoadStr)
		{
			if (this.tmpData.bUpDateStr)
			{
				this.tmpData.UnloadStrAB();
				this.tmpData.bUpDateStr = false;
			}
			if (this.tmpData.m_StrAssetBundleKey == 0)
			{
				this.tmpData.InitialABString();
			}
			if (this.tmpData.DownLoadStr != null)
			{
				byte b = this.DM.UserLanguage - GameLanguage.GL_Eng;
				if ((int)b >= this.tmpData.DownLoadStr.Header.Length || this.tmpData.DownLoadStr.Header[(int)b] == string.Empty)
				{
					b = 0;
				}
				this.PackageName.text = this.tmpData.DownLoadStr.Header[(int)b];
			}
		}
		else
		{
			this.PackageName.text = string.Empty;
		}
	}

	// Token: 0x06001E58 RID: 7768 RVA: 0x003A2FC4 File Offset: 0x003A11C4
	private void SavePos()
	{
		this.UIIndex = this.Scroll.GetTopIdx();
		this.UIPos = this.cScrollRect.content.anchoredPosition.y;
	}

	// Token: 0x06001E59 RID: 7769 RVA: 0x003A3000 File Offset: 0x003A1200
	private bool CheckShowLastItem()
	{
		if (this.tmpData != null && !this.DM.CheckPrizeFlag(9))
		{
			uint treasureID = this.tmpData.TreasureID;
			uint num = treasureID;
			switch (num)
			{
			case 11650u:
			case 11651u:
			case 11652u:
			case 11653u:
			case 11654u:
			case 11655u:
			case 11656u:
			case 11657u:
			case 11658u:
			case 11659u:
			case 11663u:
				break;
			default:
				switch (num)
				{
				case 14057u:
				case 14058u:
				case 14059u:
				case 14060u:
				case 14061u:
					break;
				default:
					switch (num)
					{
					case 14149u:
					case 14150u:
					case 14151u:
						break;
					default:
						switch (num)
						{
						case 14247u:
						case 14248u:
						case 14249u:
							break;
						default:
							if (num != 11608u && num != 11609u && num != 11575u && num != 11595u && num != 11599u)
							{
								return false;
							}
							break;
						}
						break;
					}
					break;
				}
				break;
			}
			return true;
		}
		return false;
	}

	// Token: 0x04005FC8 RID: 24520
	private const int UnitCount = 9;

	// Token: 0x04005FC9 RID: 24521
	private Transform m_transform;

	// Token: 0x04005FCA RID: 24522
	private DataManager DM;

	// Token: 0x04005FCB RID: 24523
	private GUIManager GM;

	// Token: 0x04005FCC RID: 24524
	private MallManager MM;

	// Token: 0x04005FCD RID: 24525
	private Font tmpFont;

	// Token: 0x04005FCE RID: 24526
	private Door m_door;

	// Token: 0x04005FCF RID: 24527
	private CString TimeStr;

	// Token: 0x04005FD0 RID: 24528
	private UIText TimeText;

	// Token: 0x04005FD1 RID: 24529
	private Image Back;

	// Token: 0x04005FD2 RID: 24530
	private UIText PackageName;

	// Token: 0x04005FD3 RID: 24531
	private CScrollRect cScrollRect;

	// Token: 0x04005FD4 RID: 24532
	private ScrollPanel Scroll;

	// Token: 0x04005FD5 RID: 24533
	private List<float> NowHeightList = new List<float>();

	// Token: 0x04005FD6 RID: 24534
	private int DataIndex;

	// Token: 0x04005FD7 RID: 24535
	private MallDataType tmpData;

	// Token: 0x04005FD8 RID: 24536
	private ushort SN;

	// Token: 0x04005FD9 RID: 24537
	private byte ItemCount;

	// Token: 0x04005FDA RID: 24538
	private bool[] bFindScrollComp = new bool[9];

	// Token: 0x04005FDB RID: 24539
	private UnitComp_MallDetail[] ScrollComp = new UnitComp_MallDetail[9];

	// Token: 0x04005FDC RID: 24540
	private CString[] CountStr = new CString[9];

	// Token: 0x04005FDD RID: 24541
	private CString[] NameStr = new CString[9];

	// Token: 0x04005FDE RID: 24542
	private CString PriceStr;

	// Token: 0x04005FDF RID: 24543
	private CString DisStr;

	// Token: 0x04005FE0 RID: 24544
	private CString PriceStr2;

	// Token: 0x04005FE1 RID: 24545
	private Color ItemNameCrystalColor = new Color(1f, 0.9333f, 0.6196f);

	// Token: 0x04005FE2 RID: 24546
	private Color ItemCountOriginColor = new Color(1f, 1f, 1f);

	// Token: 0x04005FE3 RID: 24547
	private Color ItemCountOutLineOriginColor = new Color(0.3725f, 0.0862f, 0f);

	// Token: 0x04005FE4 RID: 24548
	private Color ItemCountCrystalColor = new Color(0.2f, 0.921f, 0.404f);

	// Token: 0x04005FE5 RID: 24549
	private Color ItemCountCrystalOutLineColor = new Color(0.1882f, 0.0862f, 0.06274f);

	// Token: 0x04005FE6 RID: 24550
	private Vector2 OriginImagePos;

	// Token: 0x04005FE7 RID: 24551
	private Vector2 OriginCountPos;

	// Token: 0x04005FE8 RID: 24552
	private bool NeedUpDate;

	// Token: 0x04005FE9 RID: 24553
	private int UIIndex = -1;

	// Token: 0x04005FEA RID: 24554
	private float UIPos;

	// Token: 0x04005FEB RID: 24555
	private Text PriceText;

	// Token: 0x04005FEC RID: 24556
	private UIText BuyText;

	// Token: 0x04005FED RID: 24557
	private UIText GatAllText;

	// Token: 0x04005FEE RID: 24558
	private UIText OnceText;

	// Token: 0x04005FEF RID: 24559
	private bool bLastItem;

	// Token: 0x04005FF0 RID: 24560
	private byte AllianceGiftCount;

	// Token: 0x04005FF1 RID: 24561
	private Color TimeTextColor = new Color(1f, 0.9411f, 0.5568f);

	// Token: 0x04005FF2 RID: 24562
	private bool bResourceRed;

	// Token: 0x04005FF3 RID: 24563
	private float ResourceRedTime;

	// Token: 0x04005FF4 RID: 24564
	private bool bLVUPPack;

	// Token: 0x04005FF5 RID: 24565
	public UIText Lable_DisText;

	// Token: 0x04005FF6 RID: 24566
	public Text Lable_PriceText1;

	// Token: 0x04005FF7 RID: 24567
	public Text Lable_PriceText2;

	// Token: 0x04005FF8 RID: 24568
	private bool OpenEnd;
}
