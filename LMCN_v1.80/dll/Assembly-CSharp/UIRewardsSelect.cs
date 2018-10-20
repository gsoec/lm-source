using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200064D RID: 1613
internal class UIRewardsSelect : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUILEBtnClickHandler
{
	// Token: 0x06001F26 RID: 7974 RVA: 0x003BB4B4 File Offset: 0x003B96B4
	public override void OnOpen(int arg1, int arg2)
	{
		this.bReadOnly = (arg1 == 1);
		this.GM = GUIManager.Instance;
		this.DM = DataManager.Instance;
		this.MD = MobilizationManager.Instance;
		this.AC = ActivityManager.Instance;
		this.TTF = this.GM.GetTTFFont();
		this.door = (this.GM.FindMenu(EGUIWindow.Door) as Door);
		this.m_TimeSrt = StringManager.Instance.SpawnString(30);
		this.m_GiftHintStr = StringManager.Instance.SpawnString(100);
		this.MaxDegree = this.GetDegree();
		this.InitUI();
		this.MD.GetRewardsSelecteDataSave();
		if (this.MD.bFirstRequestActivityAmDegeePrize)
		{
			this.m_ScrollPanel.gameObject.SetActive(true);
			this.SetData();
			this.UpdateScrollPanel();
			this.m_ScrollPanel.GoTo(this.MD.UIRewardsSelectIndex, this.MD.RewardsSelectPosY);
		}
		else
		{
			this.MD.SendActivityAmDegeePrize();
			this.SetFakeData();
			this.m_ScrollPanel.gameObject.SetActive(false);
		}
		this.CheckType();
		this.bShowFirstClick = this.CheckFirstClick();
		this.m_SpecialPrize.gameObject.SetActive(this.IsSpecialPrize());
	}

	// Token: 0x06001F27 RID: 7975 RVA: 0x003BB608 File Offset: 0x003B9808
	public override void OnClose()
	{
		for (int i = 0; i < 6; i++)
		{
			if (this.m_PanelObject[i].m_NumTextStr != null)
			{
				StringManager.Instance.DeSpawnString(this.m_PanelObject[i].m_NumTextStr);
				this.m_PanelObject[i].m_NumTextStr = null;
			}
			for (int j = 0; j < 3; j++)
			{
				if (this.m_PanelObject[i].m_ItemNumTextStr[j] != null)
				{
					StringManager.Instance.DeSpawnString(this.m_PanelObject[i].m_ItemNumTextStr[j]);
					this.m_PanelObject[i].m_ItemNumTextStr[j] = null;
				}
			}
		}
		if (this.m_TimeSrt != null)
		{
			StringManager.Instance.DeSpawnString(this.m_TimeSrt);
			this.m_TimeSrt = null;
		}
		if (this.m_GiftHintStr != null)
		{
			StringManager.Instance.DeSpawnString(this.m_GiftHintStr);
			this.m_GiftHintStr = null;
		}
		if (this.m_ScrollPanel != null && this.m_ScrollContentRT != null)
		{
			this.MD.UIRewardsSelectIndex = this.m_ScrollPanel.GetTopIdx();
			this.MD.RewardsSelectPosY = this.m_ScrollContentRT.anchoredPosition.y;
		}
		this.MD.SetRewardsSelectDataSave();
	}

	// Token: 0x06001F28 RID: 7976 RVA: 0x003BB770 File Offset: 0x003B9970
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 0:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 1:
			if (!this.m_ScrollPanel.gameObject.activeSelf)
			{
				this.m_ScrollPanel.gameObject.SetActive(true);
			}
			this.SetData();
			this.UpdateScrollPanel();
			this.CheckType();
			this.bShowFirstClick = this.CheckFirstClick();
			if (this.MD != null && this.m_SpecialPrize != null)
			{
				this.m_SpecialPrize.gameObject.SetActive(this.IsSpecialPrize());
			}
			break;
		case 2:
			this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1594u), 255, true);
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 3:
			if (!this.m_ScrollPanel.gameObject.activeSelf)
			{
				this.m_ScrollPanel.gameObject.SetActive(true);
			}
			this.SetData();
			this.UpdateScrollPanel();
			this.CheckType();
			break;
		}
	}

	// Token: 0x06001F29 RID: 7977 RVA: 0x003BB8BC File Offset: 0x003B9ABC
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
		}
		else if (ActivityManager.Instance.AllyMobilizationData.EventBeginTime != this.MD.AllyMobilizationBeginTime)
		{
			this.MD.SendActivityAmDegeePrize();
		}
	}

	// Token: 0x06001F2A RID: 7978 RVA: 0x003BB91C File Offset: 0x003B9B1C
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x06001F2B RID: 7979 RVA: 0x003BB920 File Offset: 0x003B9B20
	private void Update()
	{
		this.UpdateTimer();
		if (!this.MD.bRewardsSelectFirstClickItem && this.bShowFirstClick)
		{
			if (this.CheckFingerRange())
			{
				this.m_FingerImageObject.SetActive(true);
			}
			else
			{
				this.m_FingerImageObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001F2C RID: 7980 RVA: 0x003BB978 File Offset: 0x003B9B78
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID4 == 300)
		{
			this.OnClick(sender.m_BtnID1, sender.m_BtnID2, sender.m_BtnID3, false);
			this.OpenDetail(sender.m_BtnID1, sender.m_BtnID2);
		}
		else
		{
			int btnID = sender.m_BtnID1;
			if (btnID != 100)
			{
				if (btnID != 200)
				{
					this.OnClick(sender.m_BtnID1, sender.m_BtnID2, sender.m_BtnID3, true);
				}
				else if (this.m_Type == UIRewardsSelect.eRewardsSelectType.Decide)
				{
					this.MD.SendActivityAmGetDegreePrize();
				}
				else if (this.m_Type == UIRewardsSelect.eRewardsSelectType.Preview)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9794u), 254, true);
				}
				else if (this.m_Type == UIRewardsSelect.eRewardsSelectType.Selection)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1372u), 255, true);
				}
			}
			else if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
		}
	}

	// Token: 0x06001F2D RID: 7981 RVA: 0x003BBAAC File Offset: 0x003B9CAC
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelObjectIdx < this.m_PanelObject.Length && panelObjectIdx >= 0)
		{
			if (this.m_PanelObject[panelObjectIdx].m_NumText == null)
			{
				this.m_PanelObject[panelObjectIdx].m_Background = item.transform.GetChild(0).GetComponent<Image>();
				this.m_PanelObject[panelObjectIdx].m_NumText = item.transform.GetChild(1).GetChild(1).GetComponent<UIText>();
				this.m_PanelObject[panelObjectIdx].m_NumText.font = this.TTF;
				this.m_PanelObject[panelObjectIdx].m_SpecialPrize = item.transform.GetChild(1).GetChild(2).GetComponent<Image>();
				for (int i = 0; i < 3; i++)
				{
					this.m_PanelObject[panelObjectIdx].m_ItemBackground[i] = item.transform.GetChild(2 + i).GetChild(0).GetComponent<Image>();
					this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[i] = item.transform.GetChild(2 + i).GetChild(0).GetChild(0).GetComponent<UIHIBtn>();
					this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[i].m_Handler = this;
					this.m_PanelObject[panelObjectIdx].m_BtnHint[i] = item.transform.GetChild(2 + i).GetChild(0).GetChild(0).GetComponent<UIButtonHint>();
					this.m_PanelObject[panelObjectIdx].m_BtnHint[i].m_eHint = EUIButtonHint.CountDown;
					this.m_PanelObject[panelObjectIdx].m_BtnHint[i].m_Handler = this;
					this.m_PanelObject[panelObjectIdx].m_BtnHint[i].DelayTime = 0.2f;
					this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[i] = item.transform.GetChild(2 + i).GetChild(0).GetChild(3).GetComponent<UILEBtn>();
					this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[i].m_Handler = this;
					this.m_PanelObject[panelObjectIdx].m_BtnHint_LE[i] = item.transform.GetChild(2 + i).GetChild(0).GetChild(3).GetComponent<UIButtonHint>();
					this.m_PanelObject[panelObjectIdx].m_BtnHint_LE[i].m_eHint = EUIButtonHint.CountDown;
					this.m_PanelObject[panelObjectIdx].m_BtnHint_LE[i].m_Handler = this;
					this.m_PanelObject[panelObjectIdx].m_BtnHint_LE[i].DelayTime = 0.2f;
					this.m_PanelObject[panelObjectIdx].m_DetailBtn[i] = item.transform.GetChild(2 + i).GetChild(0).GetChild(4).GetComponent<UIButton>();
					this.m_PanelObject[panelObjectIdx].m_DetailBtn[i].m_Handler = this;
					this.m_PanelObject[panelObjectIdx].m_ItemSelectImage[i] = item.transform.GetChild(2 + i).GetChild(0).GetChild(1).GetComponent<Image>();
					this.m_PanelObject[panelObjectIdx].m_ItemNumText[i] = item.transform.GetChild(2 + i).GetChild(0).GetChild(2).GetComponent<UIText>();
					this.m_PanelObject[panelObjectIdx].m_ItemNumText[i].font = this.TTF;
					this.m_PanelObject[panelObjectIdx].m_Btn[i] = item.transform.GetChild(2 + i).GetChild(0).GetComponent<UIButton>();
					this.m_PanelObject[panelObjectIdx].m_Btn[i].m_Handler = this;
					this.m_PanelObject[panelObjectIdx].m_LockImage[i] = item.transform.GetChild(2 + i).GetChild(0).GetChild(5).GetComponent<Image>();
				}
				this.m_PanelObject[panelObjectIdx].m_MaskImage = item.transform.GetChild(6).GetComponent<Image>();
			}
			this.SetScrollItem(dataIdx, panelObjectIdx);
		}
	}

	// Token: 0x06001F2E RID: 7982 RVA: 0x003BBEBC File Offset: 0x003BA0BC
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001F2F RID: 7983 RVA: 0x003BBEC0 File Offset: 0x003BA0C0
	public void OnClick(int btnID1, int btnID2, int btnID3, bool showMsg = false)
	{
		if (btnID1 >= (int)this.DM.RoleAlliance.AMMaxDegree)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(3713u), 254, true);
		}
		else if (!this.bReadOnly && btnID1 >= 0 && btnID1 < 35 && btnID1 < this.MD.m_RecvRewardsSelect.Length)
		{
			if (this.m_Data[btnID1].SelectIndex != 4)
			{
				this.m_Data[btnID1].SelectIndex = (byte)(btnID2 + 1);
				this.MD.m_RecvRewardsSelect[btnID1].SelectIndex = this.m_Data[btnID1].SelectIndex;
				this.SetItemSelect(btnID1, btnID3);
				this.CheckType();
				if (btnID1 == 0 && !this.MD.bRewardsSelectFirstClickItem)
				{
					this.MD.bRewardsSelectFirstClickItem = true;
					this.CheckFirstClick();
				}
			}
		}
		else if (showMsg)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9794u), 254, true);
		}
	}

	// Token: 0x06001F30 RID: 7984 RVA: 0x003BBFF4 File Offset: 0x003BA1F4
	public void OpenDetail(int btnID1, int btnID2)
	{
		ushort hiid = 0;
		if (btnID1 >= 0 && btnID1 < this.m_Data.Length && btnID2 < 3)
		{
			hiid = this.m_Data[btnID1].ItemID[btnID2];
		}
		MallManager.Instance.OpenDetail(hiid);
	}

	// Token: 0x06001F31 RID: 7985 RVA: 0x003BC040 File Offset: 0x003BA240
	public void OnHIButtonClick(UIHIBtn sender)
	{
		this.OnClick(sender.m_BtnID1, sender.m_BtnID2, sender.m_BtnID3, false);
	}

	// Token: 0x06001F32 RID: 7986 RVA: 0x003BC05C File Offset: 0x003BA25C
	public void OnLEButtonClick(UILEBtn sender)
	{
		this.OnClick(sender.m_BtnID1, sender.m_BtnID2, sender.m_BtnID3, false);
	}

	// Token: 0x06001F33 RID: 7987 RVA: 0x003BC078 File Offset: 0x003BA278
	public void OnButtonDown(UIButtonHint sender)
	{
		if (sender != null && this.m_AllyRankImageHint != null && sender == this.m_AllyRankImageHint)
		{
			ushort[] array = new ushort[]
			{
				1028,
				1027,
				1026,
				1025,
				1024
			};
			this.m_GiftHintStr.ClearString();
			if (this.DM.RoleAlliance.AMRank >= 0 && (int)this.DM.RoleAlliance.AMRank < array.Length)
			{
				this.m_GiftHintStr.Append(this.DM.mStringTable.GetStringByID((uint)array[(int)this.DM.RoleAlliance.AMRank]));
			}
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.m_GiftHintStr, Vector2.zero);
		}
		else if (sender != null && this.m_GitImageHint != null && sender == this.m_GitImageHint && this.IsSpecialPrize())
		{
			this.m_GiftHintStr.ClearString();
			this.m_GiftHintStr.StringToFormat(this.DM.mStringTable.GetStringByID(1339u));
			this.m_GiftHintStr.AppendFormat(this.DM.mStringTable.GetStringByID(1003u));
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.m_GiftHintStr, Vector2.zero);
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

	// Token: 0x06001F34 RID: 7988 RVA: 0x003BC294 File Offset: 0x003BA494
	public void OnButtonUp(UIButtonHint sender)
	{
		if (sender != null && this.m_GitImageHint != null && sender == this.m_AllyRankImageHint)
		{
			GUIManager.Instance.m_Hint.Hide(true);
		}
		else if (sender != null && this.m_GitImageHint != null && sender == this.m_GitImageHint)
		{
			GUIManager.Instance.m_Hint.Hide(true);
		}
		else
		{
			this.GM.m_SimpleItemInfo.Hide(sender);
		}
	}

	// Token: 0x06001F35 RID: 7989 RVA: 0x003BC338 File Offset: 0x003BA538
	private void InitUI()
	{
		for (int i = 0; i < this.m_Data.Length; i++)
		{
			this.m_Data[i].Init();
		}
		for (int j = 0; j < this.m_PanelObject.Length; j++)
		{
			this.m_PanelObject[j].Init();
		}
		this.m_SpArray = base.transform.gameObject.GetComponent<UISpritesArray>();
		this.m_TitleText1 = base.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
		this.m_TitleText1.font = this.TTF;
		this.m_TitleText1.text = this.DM.mStringTable.GetStringByID(1339u);
		this.m_TitleText2 = base.transform.GetChild(0).GetChild(8).GetComponent<UIText>();
		this.m_TitleText2.font = this.TTF;
		this.m_TitleText2.text = this.DM.mStringTable.GetStringByID(1368u);
		this.m_OverText = base.transform.GetChild(0).GetChild(10).GetComponent<UIText>();
		this.m_OverText.font = this.TTF;
		this.m_OverText.text = this.DM.mStringTable.GetStringByID(1369u);
		this.m_OverText.color = new Color(1f, 0.968f, 0.6f, 1f);
		this.m_TimeIcon = base.transform.GetChild(0).GetChild(6).GetComponent<Image>();
		this.m_TimeText = base.transform.GetChild(0).GetChild(7).GetComponent<UIText>();
		this.m_TimeText.font = this.TTF;
		this.m_GitImageHint = base.transform.GetChild(0).GetChild(9).gameObject.AddComponent<UIButtonHint>();
		this.m_GitImageHint.m_Handler = this;
		this.m_GitImageHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.m_SpecialPrize = base.transform.GetChild(0).GetChild(11).GetComponent<Image>();
		this.m_ScrollPanel = base.transform.GetChild(1).GetComponent<ScrollPanel>();
		this.m_Send = base.transform.GetChild(3).GetComponent<UIButton>();
		this.m_Send.m_BtnID1 = 200;
		this.m_Send.m_Handler = this;
		this.m_FlashImage = base.transform.GetChild(3).GetChild(0).GetComponent<Image>();
		UIText component = base.transform.GetChild(3).GetChild(1).GetComponent<UIText>();
		component.font = this.TTF;
		component.text = this.DM.mStringTable.GetStringByID(1542u);
		this.m_Exit = base.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
		this.m_Exit.m_BtnID1 = 100;
		this.m_Exit.m_Handler = this;
		Image component2 = base.transform.GetChild(4).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close_base");
		component2.material = this.door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX && component2)
		{
			component2.enabled = false;
		}
		this.m_Exit.image.sprite = this.door.LoadSprite("UI_main_close");
		this.m_Exit.image.material = this.door.LoadMaterial();
		this.m_FingerImageObject = base.transform.GetChild(5).gameObject;
		for (int k = 2; k <= 4; k++)
		{
			UIHIBtn component3 = base.transform.GetChild(2).GetChild(k).GetChild(0).GetChild(0).GetComponent<UIHIBtn>();
			this.GM.InitianHeroItemImg(component3.gameObject.transform, eHeroOrItem.Item, 0, 0, 0, 0, false, true, true, false);
			UILEBtn component4 = base.transform.GetChild(2).GetChild(k).GetChild(0).GetChild(3).GetComponent<UILEBtn>();
			component4.gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
			this.GM.InitLordEquipImg(component4.gameObject.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		}
		this.m_AllyRankImage = base.transform.GetChild(0).GetChild(12).GetComponent<Image>();
		this.m_AllyRankImageHint = base.transform.GetChild(0).GetChild(12).gameObject.AddComponent<UIButtonHint>();
		this.m_AllyRankImageHint.m_Handler = this;
		this.m_AllyRankImageHint.m_eHint = EUIButtonHint.DownUpHandler;
		if (this.m_AllyRankImage != null)
		{
			if (this.DM.RoleAlliance.AMRank >= 0)
			{
				this.GM.SetAllyRankImage(this.m_AllyRankImage, this.DM.RoleAlliance.AMRank);
				this.m_AllyRankImage.gameObject.SetActive(true);
			}
			else
			{
				this.m_AllyRankImage.gameObject.SetActive(false);
			}
		}
		base.transform.GetChild(2).GetChild(5).GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.6274f);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 1);
	}

	// Token: 0x06001F36 RID: 7990 RVA: 0x003BC8B4 File Offset: 0x003BAAB4
	private void SetData()
	{
		this.SelectCount = 0;
		int num = 0;
		while (num < this.MD.m_RecvRewardsSelect.Length && num < 35 && num < (int)this.MaxDegree)
		{
			MobilizationDegreeData recordByIndex;
			if (this.MD.SpecialPrize == 2)
			{
				recordByIndex = this.DM.AllianceMobilizationDegreeInfos[0].GetRecordByIndex(num);
			}
			else if (this.MD.SpecialPrize == 3)
			{
				recordByIndex = this.DM.AllianceMobilizationDegreeInfos[1].GetRecordByIndex(num);
			}
			else if (this.MD.SpecialPrize == 4)
			{
				recordByIndex = this.DM.AllianceMobilizationDegreeInfos[2].GetRecordByIndex(num);
			}
			else if (this.MD.SpecialPrize == 5)
			{
				recordByIndex = this.DM.AllianceMobilizationDegreeInfos[3].GetRecordByIndex(num);
			}
			else
			{
				recordByIndex = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex(num);
			}
			int num2 = 0;
			while (num2 < this.MD.m_RecvRewardsSelect[num].ItemIndex.Length && num2 < 3)
			{
				int num3 = this.MD.m_RecvRewardsSelect[num].ItemIndex[num2] - 1;
				if (num3 >= 0 && num3 < recordByIndex.MissionItemData.Length)
				{
					this.m_Data[num].ItemID[num2] = recordByIndex.MissionItemData[num3].ItemID;
					this.m_Data[num].ItemNum[num2] = recordByIndex.MissionItemData[num3].ItemNum;
					this.m_Data[num].ItemRank[num2] = recordByIndex.MissionItemData[num3].ItemRank;
				}
				this.m_Data[num].SelectIndex = this.MD.m_RecvRewardsSelect[num].SelectIndex;
				num2++;
			}
			num++;
		}
	}

	// Token: 0x06001F37 RID: 7991 RVA: 0x003BCAB0 File Offset: 0x003BACB0
	private void UpdateScrollPanel()
	{
		if (this.m_ScrollPanel == null)
		{
			return;
		}
		List<float> list = new List<float>();
		int num = 0;
		while (num < 35 && num < (int)this.MaxDegree)
		{
			list.Add(111f);
			num++;
		}
		if (this.bFirstInit)
		{
			this.m_ScrollPanel.IntiScrollPanel(395f, 0f, 0f, list, 6, this);
		}
		else
		{
			this.m_ScrollPanel.AddNewDataHeight(list, false, false);
		}
		UIButtonHint.scrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
		this.m_ScrollContentRT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
		this.bFirstInit = false;
	}

	// Token: 0x06001F38 RID: 7992 RVA: 0x003BCB70 File Offset: 0x003BAD70
	private void SetScrollItem(int dataIdx, int panelObjectIdx)
	{
		if (dataIdx >= 0 && dataIdx < this.m_Data.Length)
		{
			this.SetItemNumText(dataIdx, panelObjectIdx);
			this.SetItemHIBtn(dataIdx, panelObjectIdx);
			this.SetItemSelect(dataIdx, panelObjectIdx);
			this.SetItemCount(dataIdx, panelObjectIdx);
			this.SetItemClickBtn(dataIdx, panelObjectIdx);
			this.SetItemMask(dataIdx, panelObjectIdx);
			this.SetBtnHint(dataIdx, panelObjectIdx);
			this.SetSpecialPrizeImg(dataIdx, panelObjectIdx);
			this.SetItemBackground(dataIdx, panelObjectIdx);
		}
	}

	// Token: 0x06001F39 RID: 7993 RVA: 0x003BCBDC File Offset: 0x003BADDC
	private void SetItemNumText(int dataIdx, int panelObjectIdx)
	{
		this.m_PanelObject[panelObjectIdx].m_NumTextStr.ClearString();
		this.m_PanelObject[panelObjectIdx].m_NumTextStr.IntToFormat((long)(dataIdx + 1), 1, false);
		this.m_PanelObject[panelObjectIdx].m_NumTextStr.AppendFormat("{0}");
		this.m_PanelObject[panelObjectIdx].m_NumText.text = this.m_PanelObject[panelObjectIdx].m_NumTextStr.ToString();
		this.m_PanelObject[panelObjectIdx].m_NumText.SetAllDirty();
		this.m_PanelObject[panelObjectIdx].m_NumText.cachedTextGenerator.Invalidate();
		if (this.m_Data[dataIdx].SelectIndex == 4)
		{
			this.m_PanelObject[panelObjectIdx].m_NumText.color = new Color(1f, 1f, 1f, 0.5333f);
		}
		else
		{
			this.m_PanelObject[panelObjectIdx].m_NumText.color = new Color(1f, 1f, 1f, 1f);
		}
	}

	// Token: 0x06001F3A RID: 7994 RVA: 0x003BCD10 File Offset: 0x003BAF10
	private void SetItemCount(int dataIdx, int panelObjectIdx)
	{
		for (int i = 0; i < 3; i++)
		{
			if (dataIdx >= (int)this.DM.RoleAlliance.AMMaxDegree)
			{
				this.m_PanelObject[panelObjectIdx].m_ItemNumText[i].gameObject.SetActive(false);
			}
			else
			{
				this.m_PanelObject[panelObjectIdx].m_ItemNumTextStr[i].ClearString();
				this.m_PanelObject[panelObjectIdx].m_ItemNumTextStr[i].IntToFormat((long)this.m_Data[dataIdx].ItemNum[i], 1, false);
				if (GUIManager.Instance.IsArabic)
				{
					this.m_PanelObject[panelObjectIdx].m_ItemNumTextStr[i].AppendFormat("{0}X");
				}
				else
				{
					this.m_PanelObject[panelObjectIdx].m_ItemNumTextStr[i].AppendFormat("X{0}");
				}
				this.m_PanelObject[panelObjectIdx].m_ItemNumText[i].text = this.m_PanelObject[panelObjectIdx].m_ItemNumTextStr[i].ToString();
				this.m_PanelObject[panelObjectIdx].m_ItemNumText[i].SetAllDirty();
				this.m_PanelObject[panelObjectIdx].m_ItemNumText[i].cachedTextGenerator.Invalidate();
				if (this.m_Data[dataIdx].SelectIndex == 4)
				{
					this.m_PanelObject[panelObjectIdx].m_ItemNumText[i].color = new Color(1f, 1f, 1f, 0.666666f);
				}
				else
				{
					this.m_PanelObject[panelObjectIdx].m_ItemNumText[i].color = new Color(1f, 1f, 1f, 1f);
				}
				this.m_PanelObject[panelObjectIdx].m_ItemNumText[i].gameObject.SetActive(true);
			}
		}
	}

	// Token: 0x06001F3B RID: 7995 RVA: 0x003BCF00 File Offset: 0x003BB100
	private void SetItemClickBtn(int dataIdx, int panelObjectIdx)
	{
		for (int i = 0; i < 3; i++)
		{
			this.m_PanelObject[panelObjectIdx].m_Btn[i].m_BtnID1 = dataIdx;
			this.m_PanelObject[panelObjectIdx].m_Btn[i].m_BtnID2 = i;
			this.m_PanelObject[panelObjectIdx].m_Btn[i].m_BtnID3 = panelObjectIdx;
			this.m_PanelObject[panelObjectIdx].m_DetailBtn[i].m_BtnID1 = dataIdx;
			this.m_PanelObject[panelObjectIdx].m_DetailBtn[i].m_BtnID2 = i;
			this.m_PanelObject[panelObjectIdx].m_DetailBtn[i].m_BtnID3 = panelObjectIdx;
			this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[i].m_BtnID1 = dataIdx;
			this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[i].m_BtnID2 = i;
			this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[i].m_BtnID3 = panelObjectIdx;
			this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[i].m_BtnID1 = dataIdx;
			this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[i].m_BtnID2 = i;
			this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[i].m_BtnID3 = panelObjectIdx;
		}
	}

	// Token: 0x06001F3C RID: 7996 RVA: 0x003BD04C File Offset: 0x003BB24C
	private void SetItemHIBtn(int dataIdx, int panelObjectIdx)
	{
		for (int i = 0; i < 3; i++)
		{
			ushort num = this.m_Data[dataIdx].ItemID[i];
			byte b = this.m_Data[dataIdx].ItemRank[i];
			Equip recordByKey = this.DM.EquipTable.GetRecordByKey(num);
			bool flag = this.GM.IsLeadItem(recordByKey.EquipKind);
			bool flag2 = MallManager.Instance.CheckCanOpenDetail(num);
			this.m_PanelObject[panelObjectIdx].m_DetailBtn[i].targetGraphic = this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[i].HIImage;
			if (dataIdx >= (int)this.DM.RoleAlliance.AMMaxDegree)
			{
				this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[i].gameObject.SetActive(false);
				this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[i].gameObject.SetActive(false);
				this.m_PanelObject[panelObjectIdx].m_DetailBtn[i].gameObject.SetActive(false);
				this.m_PanelObject[panelObjectIdx].m_LockImage[i].gameObject.SetActive(true);
			}
			else
			{
				if (flag)
				{
					this.GM.ChangeLordEquipImg(this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[i].transform, num, b, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
					this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[i].gameObject.SetActive(true);
					this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[i].gameObject.SetActive(false);
					this.m_PanelObject[panelObjectIdx].m_DetailBtn[i].gameObject.SetActive(false);
				}
				else
				{
					if (flag2)
					{
						this.m_PanelObject[panelObjectIdx].m_DetailBtn[i].m_BtnID4 = 300;
						this.m_PanelObject[panelObjectIdx].m_DetailBtn[i].m_BtnID2 = (int)num;
						this.m_PanelObject[panelObjectIdx].m_DetailBtn[i].gameObject.SetActive(true);
					}
					else
					{
						this.m_PanelObject[panelObjectIdx].m_DetailBtn[i].m_BtnID4 = 301;
						this.m_PanelObject[panelObjectIdx].m_DetailBtn[i].m_BtnID2 = 0;
						this.m_PanelObject[panelObjectIdx].m_DetailBtn[i].gameObject.SetActive(false);
					}
					this.GM.ChangeHeroItemImg(this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[i].transform, eHeroOrItem.Item, num, b, 0, 0);
					this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[i].gameObject.SetActive(true);
					this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[i].gameObject.SetActive(false);
				}
				this.m_PanelObject[panelObjectIdx].m_LockImage[i].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001F3D RID: 7997 RVA: 0x003BD370 File Offset: 0x003BB570
	private void SetItemSelect(int dataIdx, int panelObjectIdx)
	{
		for (int i = 0; i < 3; i++)
		{
			this.m_PanelObject[panelObjectIdx].m_ItemSelectImage[i].enabled = false;
		}
		int selectIndex = (int)this.m_Data[dataIdx].SelectIndex;
		if (selectIndex > 0 && selectIndex <= 3)
		{
			this.m_PanelObject[panelObjectIdx].m_ItemSelectImage[selectIndex - 1].enabled = true;
		}
	}

	// Token: 0x06001F3E RID: 7998 RVA: 0x003BD3E8 File Offset: 0x003BB5E8
	private void SetItemMask(int dataIdx, int panelObjectIdx)
	{
		if (this.m_Data[dataIdx].SelectIndex == 4 || dataIdx >= (int)this.MaxDegree)
		{
			this.m_PanelObject[panelObjectIdx].m_MaskImage.enabled = true;
		}
		else
		{
			this.m_PanelObject[panelObjectIdx].m_MaskImage.enabled = false;
		}
	}

	// Token: 0x06001F3F RID: 7999 RVA: 0x003BD44C File Offset: 0x003BB64C
	private void SetBtnHint(int dataIdx, int panelObjectIdx)
	{
		for (int i = 0; i < 3; i++)
		{
			if (dataIdx >= 0 && dataIdx < this.m_Data.Length)
			{
				this.m_PanelObject[panelObjectIdx].m_BtnHint[i].Parm1 = this.m_Data[dataIdx].ItemID[i];
				this.m_PanelObject[panelObjectIdx].m_BtnHint[i].Parm2 = this.m_Data[dataIdx].ItemRank[i];
				this.m_PanelObject[panelObjectIdx].m_BtnHint_LE[i].Parm1 = this.m_Data[dataIdx].ItemID[i];
				this.m_PanelObject[panelObjectIdx].m_BtnHint_LE[i].Parm2 = this.m_Data[dataIdx].ItemRank[i];
			}
		}
	}

	// Token: 0x06001F40 RID: 8000 RVA: 0x003BD52C File Offset: 0x003BB72C
	private void SetSpecialPrizeImg(int dataIdx, int panelObjectIdx)
	{
		this.m_PanelObject[panelObjectIdx].m_SpecialPrize.gameObject.SetActive(this.IsSpecialPrize());
	}

	// Token: 0x06001F41 RID: 8001 RVA: 0x003BD550 File Offset: 0x003BB750
	private void SetItemBackground(int dataIdx, int panelObjectIdx)
	{
		int rankImageIdx = this.GetRankImageIdx(dataIdx);
		if (rankImageIdx > 0)
		{
			this.m_PanelObject[panelObjectIdx].m_Background.sprite = this.m_SpArray.GetSprite(rankImageIdx + 2);
			this.m_PanelObject[panelObjectIdx].m_Background.gameObject.SetActive(true);
		}
		else
		{
			this.m_PanelObject[panelObjectIdx].m_Background.gameObject.SetActive(false);
		}
		for (int i = 0; i < 3; i++)
		{
			this.m_PanelObject[panelObjectIdx].m_ItemBackground[i].sprite = this.m_SpArray.GetSprite(rankImageIdx + 7);
		}
	}

	// Token: 0x06001F42 RID: 8002 RVA: 0x003BD608 File Offset: 0x003BB808
	private int GetRankImageIdx(int dataIdx)
	{
		for (int i = 0; i < this.MD.DegreeRanges.Length - 1; i++)
		{
			if (dataIdx >= (int)this.MD.DegreeRanges[i] && dataIdx < (int)this.MD.DegreeRanges[i + 1])
			{
				return i;
			}
		}
		return 0;
	}

	// Token: 0x06001F43 RID: 8003 RVA: 0x003BD660 File Offset: 0x003BB860
	private void UpdateSendBtnType(UIRewardsSelect.eRewardsSelectType type)
	{
		if (type == UIRewardsSelect.eRewardsSelectType.Preview)
		{
			this.m_OverText.gameObject.SetActive(true);
			this.m_Send.gameObject.SetActive(false);
			this.m_FlashImage.gameObject.SetActive(false);
		}
		else if (type == UIRewardsSelect.eRewardsSelectType.Selection)
		{
			this.m_Send.image.sprite = this.m_SpArray.GetSprite(1);
			this.m_Send.ForTextChange(e_BtnType.e_ChangeText);
			this.m_Send.gameObject.SetActive(true);
			this.m_OverText.gameObject.SetActive(false);
			this.m_FlashImage.gameObject.SetActive(false);
		}
		else if (type == UIRewardsSelect.eRewardsSelectType.Decide)
		{
			this.m_Send.image.sprite = this.m_SpArray.GetSprite(0);
			this.m_Send.ForTextChange(e_BtnType.e_Normal);
			this.m_Send.gameObject.SetActive(true);
			this.m_OverText.gameObject.SetActive(false);
			this.m_FlashImage.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001F44 RID: 8004 RVA: 0x003BD774 File Offset: 0x003BB974
	private void SetType(UIRewardsSelect.eRewardsSelectType type)
	{
		this.m_Type = type;
		this.UpdateSendBtnType(this.m_Type);
	}

	// Token: 0x06001F45 RID: 8005 RVA: 0x003BD78C File Offset: 0x003BB98C
	private void CheckType()
	{
		this.SelectCount = 0;
		for (int i = 0; i < this.m_Data.Length; i++)
		{
			if (this.m_Data[i].SelectIndex != 0 && this.m_Data[i].SelectIndex != 4)
			{
				this.SelectCount++;
			}
		}
		if (this.bReadOnly)
		{
			this.SetType(UIRewardsSelect.eRewardsSelectType.Preview);
			this.m_TimeIcon.gameObject.SetActive(false);
			this.m_TimeText.gameObject.SetActive(false);
		}
		else
		{
			this.m_TimeIcon.gameObject.SetActive(true);
			this.m_TimeText.gameObject.SetActive(true);
			if (this.SelectCount >= (int)this.MD.AMCompleteDegree)
			{
				this.SetType(UIRewardsSelect.eRewardsSelectType.Decide);
			}
			else
			{
				this.SetType(UIRewardsSelect.eRewardsSelectType.Selection);
			}
		}
	}

	// Token: 0x06001F46 RID: 8006 RVA: 0x003BD878 File Offset: 0x003BBA78
	private bool IsSpecialPrize()
	{
		return this.MD != null && this.MD.SpecialPrize > 1;
	}

	// Token: 0x06001F47 RID: 8007 RVA: 0x003BD898 File Offset: 0x003BBA98
	private void UpdateTimer()
	{
		if (!this.bReadOnly)
		{
			this.m_TimeTick += Time.deltaTime;
			if (this.m_TimeTick >= 1f)
			{
				this.m_TimeSrt.ClearString();
				GameConstants.GetTimeString(this.m_TimeSrt, (uint)this.AC.AllyMobilizationData.EventCountTime, false, false, true, false, true);
				this.m_TimeText.text = this.m_TimeSrt.ToString();
				this.m_TimeText.SetAllDirty();
				this.m_TimeText.cachedTextGenerator.Invalidate();
				this.m_TimeTick = 0f;
			}
		}
	}

	// Token: 0x06001F48 RID: 8008 RVA: 0x003BD93C File Offset: 0x003BBB3C
	public float ATween(float t, float b, float c, float d)
	{
		float num = (t /= d) * t;
		float num2 = num * t;
		return b + c * (num2 * num);
	}

	// Token: 0x06001F49 RID: 8009 RVA: 0x003BD960 File Offset: 0x003BBB60
	private void FlashImageAlpha()
	{
		if (this.m_Type == UIRewardsSelect.eRewardsSelectType.Decide)
		{
			this.ColorTime += Time.deltaTime;
			if (this.ColorTime >= this.FlashTime)
			{
				this.ColorTime = 0f;
			}
			if (this.m_FlashImage != null)
			{
				if (this.ColorTime > 1f)
				{
					this.m_FlashImage.color = new Color(1f, 1f, 1f, 2f - this.ColorTime);
				}
				else
				{
					this.m_FlashImage.color = new Color(1f, 1f, 1f, this.ColorTime);
				}
			}
		}
		else if (this.m_Type == UIRewardsSelect.eRewardsSelectType.Selection && this.m_FlashImage.color.a < 1f)
		{
			this.m_FlashImage.color = new Color(1f, 1f, 1f, 1f);
		}
	}

	// Token: 0x06001F4A RID: 8010 RVA: 0x003BDA70 File Offset: 0x003BBC70
	private void SetFakeData()
	{
		if (!this.bFirstInit)
		{
			for (int i = 0; i < this.m_Data.Length; i++)
			{
				this.m_Data[i].SelectIndex = 4;
			}
			this.m_Data[0].SelectIndex = 0;
			List<float> list = new List<float>();
			int num = 0;
			while (num < 35 && num < (int)this.MaxDegree)
			{
				list.Add(111f);
				num++;
			}
			this.m_ScrollPanel.AddNewDataHeight(list, false, false);
		}
	}

	// Token: 0x06001F4B RID: 8011 RVA: 0x003BDB04 File Offset: 0x003BBD04
	private bool CheckFirstClick()
	{
		bool flag = !this.MD.bRewardsSelectFirstClickItem && this.m_Type == UIRewardsSelect.eRewardsSelectType.Selection && this.MD.AMCompleteDegree >= 1;
		if (flag)
		{
			this.SetFakeData();
			this.m_FingerImageObject.SetActive(true);
		}
		else
		{
			this.m_FingerImageObject.SetActive(false);
			if (this.MD.bFirstRequestActivityAmDegeePrize)
			{
				this.UpdateUI(3, 0);
			}
		}
		return flag;
	}

	// Token: 0x06001F4C RID: 8012 RVA: 0x003BDB8C File Offset: 0x003BBD8C
	private bool CheckFingerRange()
	{
		bool result = false;
		if (this.m_ScrollContentRT != null)
		{
			result = (this.m_ScrollContentRT.anchoredPosition.y <= 40f && this.m_ScrollContentRT.anchoredPosition.y > -30f);
		}
		return result;
	}

	// Token: 0x06001F4D RID: 8013 RVA: 0x003BDBE8 File Offset: 0x003BBDE8
	private byte GetDegree()
	{
		byte b = this.DM.RoleAlliance.AMRank + 1;
		byte range;
		if (b <= 4)
		{
			range = this.DM.AllianceMobilizationDegreeRange.GetRecordByIndex((int)b).Range;
		}
		else
		{
			range = this.DM.AllianceMobilizationDegreeRange.GetRecordByIndex(4).Range;
		}
		return range;
	}

	// Token: 0x06001F4E RID: 8014 RVA: 0x003BDC4C File Offset: 0x003BBE4C
	private void Refresh_FontTexture()
	{
		if (!this.bFirstInit && this.m_PanelObject != null)
		{
			for (int i = 0; i < this.m_PanelObject.Length; i++)
			{
				if (this.m_PanelObject[i].m_NumText != null && this.m_PanelObject[i].m_NumText.enabled)
				{
					this.m_PanelObject[i].m_NumText.enabled = false;
					this.m_PanelObject[i].m_NumText.enabled = true;
				}
				for (int j = 0; j < 3; j++)
				{
					if (this.m_PanelObject[i].m_ItemNumText != null && this.m_PanelObject[i].m_ItemNumText[j] != null && this.m_PanelObject[i].m_ItemNumText[j].enabled)
					{
						this.m_PanelObject[i].m_ItemNumText[j].enabled = false;
						this.m_PanelObject[i].m_ItemNumText[j].enabled = true;
					}
					if (this.m_PanelObject[i].m_ItemHIBtn[j] != null)
					{
						this.m_PanelObject[i].m_ItemHIBtn[j].Refresh_FontTexture();
					}
					if (this.m_PanelObject[i].m_ItemLEBtn[j] != null)
					{
						LordEquipData.ResetLordEquipFont(this.m_PanelObject[i].m_ItemLEBtn[j]);
					}
				}
			}
		}
		if (this.m_TimeText != null && this.m_TimeText.enabled)
		{
			this.m_TimeText.enabled = false;
			this.m_TimeText.enabled = true;
		}
		if (this.m_OverText != null && this.m_OverText.enabled)
		{
			this.m_OverText.enabled = false;
			this.m_OverText.enabled = true;
		}
		if (this.m_TitleText1 != null && this.m_TitleText1.enabled)
		{
			this.m_TitleText1.enabled = false;
			this.m_TitleText1.enabled = true;
		}
		if (this.m_TitleText2 != null && this.m_TitleText2.enabled)
		{
			this.m_TitleText2.enabled = false;
			this.m_TitleText2.enabled = true;
		}
	}

	// Token: 0x040062C1 RID: 25281
	private const ushort MaxRank = 4;

	// Token: 0x040062C2 RID: 25282
	private const int MaxData = 35;

	// Token: 0x040062C3 RID: 25283
	private const int MaxScrollCount = 6;

	// Token: 0x040062C4 RID: 25284
	private const float ItemHeight = 111f;

	// Token: 0x040062C5 RID: 25285
	private const float FingerShowRangeBegin = -30f;

	// Token: 0x040062C6 RID: 25286
	private const float FingerShowRangeEnd = 40f;

	// Token: 0x040062C7 RID: 25287
	private GUIManager GM;

	// Token: 0x040062C8 RID: 25288
	private DataManager DM;

	// Token: 0x040062C9 RID: 25289
	private MobilizationManager MD;

	// Token: 0x040062CA RID: 25290
	private ActivityManager AC;

	// Token: 0x040062CB RID: 25291
	private Font TTF;

	// Token: 0x040062CC RID: 25292
	private Door door;

	// Token: 0x040062CD RID: 25293
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040062CE RID: 25294
	private RectTransform m_ScrollContentRT;

	// Token: 0x040062CF RID: 25295
	private UIButton m_Send;

	// Token: 0x040062D0 RID: 25296
	private UIButton m_Exit;

	// Token: 0x040062D1 RID: 25297
	private UIText m_TimeText;

	// Token: 0x040062D2 RID: 25298
	private UIText m_OverText;

	// Token: 0x040062D3 RID: 25299
	private UIText m_TitleText1;

	// Token: 0x040062D4 RID: 25300
	private UIText m_TitleText2;

	// Token: 0x040062D5 RID: 25301
	private Image m_FlashImage;

	// Token: 0x040062D6 RID: 25302
	private Image m_TimeIcon;

	// Token: 0x040062D7 RID: 25303
	private Image m_SpecialPrize;

	// Token: 0x040062D8 RID: 25304
	private Image m_AllyRankImage;

	// Token: 0x040062D9 RID: 25305
	private UIButtonHint m_GitImageHint;

	// Token: 0x040062DA RID: 25306
	private UIButtonHint m_AllyRankImageHint;

	// Token: 0x040062DB RID: 25307
	private GameObject m_FingerImageObject;

	// Token: 0x040062DC RID: 25308
	private float ColorTime;

	// Token: 0x040062DD RID: 25309
	private float FlashTime = 1.8f;

	// Token: 0x040062DE RID: 25310
	private CString m_TimeSrt;

	// Token: 0x040062DF RID: 25311
	private CString m_GiftHintStr;

	// Token: 0x040062E0 RID: 25312
	private UISpritesArray m_SpArray;

	// Token: 0x040062E1 RID: 25313
	private UIRewardsSelect.sRewardsSelect[] m_Data = new UIRewardsSelect.sRewardsSelect[35];

	// Token: 0x040062E2 RID: 25314
	private UIRewardsSelect.panelObject[] m_PanelObject = new UIRewardsSelect.panelObject[6];

	// Token: 0x040062E3 RID: 25315
	private byte[] m_SendData = new byte[35];

	// Token: 0x040062E4 RID: 25316
	private bool bFirstInit = true;

	// Token: 0x040062E5 RID: 25317
	private bool bReadOnly;

	// Token: 0x040062E6 RID: 25318
	private bool bShowFirstClick;

	// Token: 0x040062E7 RID: 25319
	private UIRewardsSelect.eRewardsSelectType m_Type = UIRewardsSelect.eRewardsSelectType.Selection;

	// Token: 0x040062E8 RID: 25320
	private int SelectCount;

	// Token: 0x040062E9 RID: 25321
	private float m_TimeTick = 1f;

	// Token: 0x040062EA RID: 25322
	private byte MaxDegree;

	// Token: 0x0200064E RID: 1614
	private struct panelObject
	{
		// Token: 0x06001F4F RID: 8015 RVA: 0x003BDED4 File Offset: 0x003BC0D4
		public void Init()
		{
			this.m_Background = null;
			this.m_NumText = null;
			this.m_ItemNumText = new UIText[3];
			this.m_ItemHIBtn = new UIHIBtn[3];
			this.m_ItemLEBtn = new UILEBtn[3];
			this.m_BtnHint = new UIButtonHint[3];
			this.m_BtnHint_LE = new UIButtonHint[3];
			this.m_DetailBtn = new UIButton[3];
			this.m_ItemBackground = new Image[3];
			this.m_ItemSelectImage = new Image[3];
			this.m_MaskImage = null;
			this.m_SpecialPrize = null;
			this.m_LockImage = new Image[3];
			this.m_Btn = new UIButton[3];
			this.m_NumTextStr = StringManager.Instance.SpawnString(30);
			this.m_ItemNumTextStr = new CString[3];
			for (int i = 0; i < 3; i++)
			{
				this.m_ItemNumTextStr[i] = StringManager.Instance.SpawnString(30);
			}
		}

		// Token: 0x040062EB RID: 25323
		public Image m_Background;

		// Token: 0x040062EC RID: 25324
		public UIText m_NumText;

		// Token: 0x040062ED RID: 25325
		public UIText[] m_ItemNumText;

		// Token: 0x040062EE RID: 25326
		public UIHIBtn[] m_ItemHIBtn;

		// Token: 0x040062EF RID: 25327
		public UILEBtn[] m_ItemLEBtn;

		// Token: 0x040062F0 RID: 25328
		public UIButtonHint[] m_BtnHint;

		// Token: 0x040062F1 RID: 25329
		public UIButtonHint[] m_BtnHint_LE;

		// Token: 0x040062F2 RID: 25330
		public UIButton[] m_DetailBtn;

		// Token: 0x040062F3 RID: 25331
		public Image[] m_ItemBackground;

		// Token: 0x040062F4 RID: 25332
		public Image[] m_ItemSelectImage;

		// Token: 0x040062F5 RID: 25333
		public Image m_MaskImage;

		// Token: 0x040062F6 RID: 25334
		public Image m_SpecialPrize;

		// Token: 0x040062F7 RID: 25335
		public Image[] m_LockImage;

		// Token: 0x040062F8 RID: 25336
		public UIButton[] m_Btn;

		// Token: 0x040062F9 RID: 25337
		public CString m_NumTextStr;

		// Token: 0x040062FA RID: 25338
		public CString[] m_ItemNumTextStr;
	}

	// Token: 0x0200064F RID: 1615
	private struct sRewardsSelect
	{
		// Token: 0x06001F50 RID: 8016 RVA: 0x003BDFBC File Offset: 0x003BC1BC
		public void Init()
		{
			this.Num = 0;
			this.SelectIndex = 0;
			this.ItemID = new ushort[3];
			this.ItemNum = new byte[3];
			this.ItemRank = new byte[3];
		}

		// Token: 0x040062FB RID: 25339
		public int Num;

		// Token: 0x040062FC RID: 25340
		public byte SelectIndex;

		// Token: 0x040062FD RID: 25341
		public ushort[] ItemID;

		// Token: 0x040062FE RID: 25342
		public byte[] ItemRank;

		// Token: 0x040062FF RID: 25343
		public byte[] ItemNum;
	}

	// Token: 0x02000650 RID: 1616
	private enum eRewardsSelect
	{
		// Token: 0x04006301 RID: 25345
		BGPanel,
		// Token: 0x04006302 RID: 25346
		ScrollView,
		// Token: 0x04006303 RID: 25347
		Item,
		// Token: 0x04006304 RID: 25348
		Send,
		// Token: 0x04006305 RID: 25349
		Exit,
		// Token: 0x04006306 RID: 25350
		FingerImage
	}

	// Token: 0x02000651 RID: 1617
	private enum eRewardsSelectType
	{
		// Token: 0x04006308 RID: 25352
		Preview,
		// Token: 0x04006309 RID: 25353
		Selection,
		// Token: 0x0400630A RID: 25354
		Decide
	}

	// Token: 0x02000652 RID: 1618
	private enum eSpriteArry
	{
		// Token: 0x0400630C RID: 25356
		ButtonDark,
		// Token: 0x0400630D RID: 25357
		ButtonLight,
		// Token: 0x0400630E RID: 25358
		ImageBox,
		// Token: 0x0400630F RID: 25359
		BackgroundRank1,
		// Token: 0x04006310 RID: 25360
		BackgroundRank2,
		// Token: 0x04006311 RID: 25361
		BackgroundRank3,
		// Token: 0x04006312 RID: 25362
		BackgroundRank4,
		// Token: 0x04006313 RID: 25363
		ItemBackgroundRank0,
		// Token: 0x04006314 RID: 25364
		ItemBackgroundRank1,
		// Token: 0x04006315 RID: 25365
		ItemBackgroundRank2,
		// Token: 0x04006316 RID: 25366
		ItemBackgroundRank3,
		// Token: 0x04006317 RID: 25367
		ItemBackgroundRank4
	}
}
