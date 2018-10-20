using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000657 RID: 1623
public class UISearchList : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001F52 RID: 8018 RVA: 0x003BE064 File Offset: 0x003BC264
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.TTF = this.GM.GetTTFFont();
		this.m_door = (this.GM.FindMenu(EGUIWindow.Door) as Door);
		this.m_SearchItem = new SearchItemObj[7];
		this.m_TabType = (eTabPanel)this.DM.mLastSearchPage;
		this.m_SearchTextStr = StringManager.Instance.SpawnString(30);
		this.m_SearchTitleStr = StringManager.Instance.SpawnString(100);
		this.m_EmptyMsgTextStr = StringManager.Instance.SpawnString(100);
		this.m_SPArray = base.transform.GetComponent<UISpritesArray>();
		this.Title = base.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<UIText>();
		this.Title.font = this.TTF;
		Image component = base.transform.GetChild(7).GetComponent<Image>();
		component.sprite = this.m_door.LoadSprite("UI_main_close_base");
		component.material = this.m_door.LoadMaterial();
		if (this.GM.bOpenOnIPhoneX && component)
		{
			component.enabled = false;
		}
		UIButton component2 = base.transform.GetChild(7).GetChild(0).GetComponent<UIButton>();
		component2.image.sprite = this.m_door.LoadSprite("UI_main_close");
		component2.image.material = this.m_door.LoadMaterial();
		component2.m_BtnID1 = 999;
		component2.m_Handler = this;
		this.m_InputField = base.transform.GetChild(1).GetChild(0).GetComponent<UIEmojiInput>();
		this.m_InputField.onValueChange.AddListener(delegate(string input)
		{
			this.ValueChange(input);
		});
		this.m_InputField.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
		this.m_InputText[0] = base.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.m_InputText[0].font = this.TTF;
		this.m_InputText[0].text = this.DM.mStringTable.GetStringByID(4718u);
		this.m_InputText[1] = base.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>();
		this.m_InputText[1].font = this.TTF;
		this.m_SearchPanel = base.transform.GetChild(1);
		this.m_TextStr[0] = base.transform.GetChild(1).GetChild(3).GetComponent<UIText>();
		this.m_TextStr[0].font = this.TTF;
		this.m_SearchTitleStr.StringToFormat(this.DM.mStringTable.GetStringByID(4717u));
		this.m_SearchTitleStr.AppendFormat("{0}");
		this.m_TextStr[0].text = this.m_SearchTitleStr.ToString();
		this.m_TextStr[1] = base.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
		this.m_TextStr[1].font = this.TTF;
		this.m_TextStr[1].text = this.DM.mStringTable.GetStringByID(7056u);
		this.m_SearchText = base.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
		this.m_SearchText.font = this.TTF;
		component2 = base.transform.GetChild(1).GetChild(1).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 998;
		this.m_CancelInput = base.transform.GetChild(1).GetChild(2).GetComponent<UIButton>();
		this.m_CancelInput.m_Handler = this;
		this.m_CancelInput.m_BtnID1 = 997;
		this.m_EmptyMsgPanel = base.transform.GetChild(6);
		this.m_EmptyMsgText = this.m_EmptyMsgPanel.GetChild(1).GetComponent<UIText>();
		this.m_EmptyMsgText.font = this.TTF;
		this.SetEmptyMsgPanel(eMsgPanel.PlzInputName);
		UIHIBtn component3 = base.transform.GetChild(3).GetChild(2).GetComponent<UIHIBtn>();
		this.GM.InitianHeroItemImg(component3.transform, eHeroOrItem.Hero, 0, 11, 0, 0, false, false, true, false);
		this.btn_Text = base.transform.GetChild(3).GetChild(8).GetChild(0).GetComponent<UIText>();
		this.btn_Text.font = this.TTF;
		this.btn_Text.text = this.DM.mStringTable.GetStringByID(4634u);
		component2 = base.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 996;
		this.m_TabBg1 = base.transform.GetChild(4).GetChild(0).GetComponent<Image>();
		this.m_TabIcon1 = base.transform.GetChild(4).GetChild(0).GetChild(1).GetComponent<Image>();
		this.m_TweenA1 = base.transform.GetChild(4).GetChild(0).GetChild(0);
		component2 = base.transform.GetChild(4).GetChild(1).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 995;
		this.m_TabBg2 = base.transform.GetChild(4).GetChild(1).GetComponent<Image>();
		this.m_TabIcon2 = base.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<Image>();
		this.m_TweenA2 = base.transform.GetChild(4).GetChild(1).GetChild(0);
		this.m_ScrollPanel = base.transform.GetChild(2).GetComponent<ScrollPanel>();
		List<float> list = new List<float>();
		for (int i = 0; i < (int)this.DM.m_RecvSearchPlayerCount; i++)
		{
			list.Add(72f);
		}
		this.m_ScrollPanel.IntiScrollPanel(417f, 0f, 0f, list, 7, this);
		this.m_ScrollContentRT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
		this.cScrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
		if (!this.DM.bClaerSearchData)
		{
			if (this.DM.m_RecvSearchPlayerCount > 0)
			{
				this.m_ScrollPanel.GoTo(this.DM.m_SearchListScrollIndex, this.DM.m_SearchListScrollPos);
				this.m_InputField.text = string.Empty;
				this.m_InputField.text = this.DM.m_PreSearchName;
				this.SetSearchText(true);
			}
			else
			{
				this.SetSearchText(false);
			}
		}
		this.SetAlliancePanel();
		this.SetTabPanel(this.m_TabType);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001F53 RID: 8019 RVA: 0x003BE758 File Offset: 0x003BC958
	public override void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.m_SearchTextStr);
		StringManager.Instance.DeSpawnString(this.m_SearchTitleStr);
		StringManager.Instance.DeSpawnString(this.m_EmptyMsgTextStr);
		for (int i = 0; i < 7; i++)
		{
			if (this.m_SearchItem[i].NameStr != null)
			{
				StringManager.Instance.DeSpawnString(this.m_SearchItem[i].NameStr);
			}
			if (this.m_SearchItem[i].PowerStr != null)
			{
				StringManager.Instance.DeSpawnString(this.m_SearchItem[i].PowerStr);
			}
			if (this.m_SearchItem[i].KillStr != null)
			{
				StringManager.Instance.DeSpawnString(this.m_SearchItem[i].KillStr);
			}
		}
		this.DM.mLastSearchPage = ((this.DM.mLastSearchPage <= 1) ? 0 : 1);
	}

	// Token: 0x06001F54 RID: 8020 RVA: 0x003BE864 File Offset: 0x003BCA64
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg2 < 100)
		{
			this.AllianceUpdate(arg1, arg2);
		}
	}

	// Token: 0x06001F55 RID: 8021 RVA: 0x003BE878 File Offset: 0x003BCA78
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			this.UpdateScroll();
			break;
		default:
			if (networkNews != NetworkNews.Refresh_SearchList)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else if (!this.DM.bSearchError)
			{
				if (this.DM.m_RecvSearchPlayerCount <= 0)
				{
					this.SetEmptyMsgPanel(eMsgPanel.SearchError);
					this.UpdateScroll();
				}
				else
				{
					this.SetEmptyMsgPanel(eMsgPanel.None);
					this.UpdateScroll();
				}
			}
			break;
		}
	}

	// Token: 0x06001F56 RID: 8022 RVA: 0x003BE90C File Offset: 0x003BCB0C
	public void Refresh_FontTexture()
	{
		if (this.Title != null && this.Title.enabled)
		{
			this.Title.enabled = false;
			this.Title.enabled = true;
		}
		if (this.m_SearchText != null && this.m_SearchText.enabled)
		{
			this.m_SearchText.enabled = false;
			this.m_SearchText.enabled = true;
		}
		if (this.m_EmptyMsgText != null && this.m_EmptyMsgText.enabled)
		{
			this.m_EmptyMsgText.enabled = false;
			this.m_EmptyMsgText.enabled = true;
		}
		if (this.btn_Text != null && this.btn_Text.enabled)
		{
			this.btn_Text.enabled = false;
			this.btn_Text.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.m_InputText[i] != null && this.m_InputText[i].enabled)
			{
				this.m_InputText[i].enabled = false;
				this.m_InputText[i].enabled = true;
			}
			if (this.m_TextStr[i] != null && this.m_TextStr[i].enabled)
			{
				this.m_TextStr[i].enabled = false;
				this.m_TextStr[i].enabled = true;
			}
		}
		for (int j = 0; j < 7; j++)
		{
			if (this.m_ItemBtnStr != null && this.m_ItemBtnStr[j] != null && this.m_ItemBtnStr[j].enabled)
			{
				this.m_ItemBtnStr[j].enabled = false;
				this.m_ItemBtnStr[j].enabled = true;
			}
			if (this.ItemTag != null)
			{
				for (int k = 0; k < 5; k++)
				{
					if (this.ItemTag[j][k] != null && this.ItemTag[j][k].enabled)
					{
						this.ItemTag[j][k].enabled = false;
						this.ItemTag[j][k].enabled = true;
					}
				}
			}
		}
		if (this.m_SearchItem != null)
		{
			for (int l = 0; l < 7; l++)
			{
				if (this.m_SearchItem[l].NameText != null && this.m_SearchItem[l].NameText.enabled)
				{
					this.m_SearchItem[l].NameText.enabled = false;
					this.m_SearchItem[l].NameText.enabled = true;
				}
				if (this.m_SearchItem[l].PowerText != null && this.m_SearchItem[l].PowerText.enabled)
				{
					this.m_SearchItem[l].PowerText.enabled = false;
					this.m_SearchItem[l].PowerText.enabled = true;
				}
				if (this.m_SearchItem[l].KillText != null && this.m_SearchItem[l].KillText.enabled)
				{
					this.m_SearchItem[l].KillText.enabled = false;
					this.m_SearchItem[l].KillText.enabled = true;
				}
				if (this.m_SearchItem[l].Hibtn != null && this.m_SearchItem[l].Hibtn.enabled)
				{
					this.m_SearchItem[l].Hibtn.Refresh_FontTexture();
				}
			}
		}
		for (int m = 0; m < 9; m++)
		{
			if (this.m_text[m] != null && this.m_text[m].enabled)
			{
				this.m_text[m].enabled = false;
				this.m_text[m].enabled = true;
			}
		}
		if (this.s_input != null)
		{
			if (this.s_input.textComponent != null && this.s_input.textComponent.enabled)
			{
				this.s_input.textComponent.enabled = false;
				this.s_input.textComponent.enabled = true;
			}
			if (this.s_input.placeholder != null && this.s_input.placeholder.enabled)
			{
				this.s_input.placeholder.enabled = false;
				this.s_input.placeholder.enabled = true;
			}
		}
		if (this.m_InputField != null)
		{
			if (this.m_InputField.textComponent != null && this.m_InputField.textComponent.enabled)
			{
				this.m_InputField.textComponent.enabled = false;
				this.m_InputField.textComponent.enabled = true;
			}
			if (this.m_InputField.placeholder != null && this.m_InputField.placeholder.enabled)
			{
				this.m_InputField.placeholder.enabled = false;
				this.m_InputField.placeholder.enabled = true;
			}
		}
	}

	// Token: 0x06001F57 RID: 8023 RVA: 0x003BEEA0 File Offset: 0x003BD0A0
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID2 > 0)
		{
			if (sender.m_BtnID2 == 2)
			{
				this.DM.mLastSearchPage = 30;
				AllianceHint.Positioning = this.m_scroll.GetTopIdx();
				AllianceHint.Scrolling = this.SearchRT.anchoredPosition.y;
				this.DM.AllianceView.Id = AllianceHint.Search[sender.m_BtnID1].ID;
				this.m_door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5, 0, false);
				this.DM.mAllianceSearchView = true;
			}
			else if (sender.m_BtnID1 == 31)
			{
				if (AllianceHint.FilterIdx == 0 && AllianceHint.FilterName.Length == 0)
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(4711u), 255, true);
					return;
				}
				if (AllianceHint.FilterName.Length > 0 && AllianceHint.FilterName.Length < 3)
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(4710u), 255, true);
					return;
				}
				AllianceHint.Proceeding = 1L;
				GUIManager.Instance.ShowUILock(EUILock.AllianceCreate);
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_SEARCH;
				messagePacket.AddSeqId();
				messagePacket.Add(AllianceHint.FilterIdx);
				if (AllianceHint.FilterName.Length > 0)
				{
					messagePacket.Add((byte)AllianceHint.FilterName.Length);
					messagePacket.Add(AllianceHint.FilterName, AllianceHint.FilterName.Length);
				}
				messagePacket.Send(false);
				this.Path.Length = 0;
				this.m_filter.text = (AllianceHint.SearchLang = ((AllianceHint.FilterIdx <= 0) ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703u), this.Alliance.GetChild(3).GetChild(17).GetChild(0).GetComponent<UIText>().text).ToString()));
				this.Path.Length = 0;
				this.m_text[8].text = (AllianceHint.SearchName = ((AllianceHint.FilterName.Length <= 0) ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703u), AllianceHint.FilterName).ToString()));
				AllianceHint.SeekKind = byte.MaxValue;
			}
			else if (sender.m_BtnID1 == 32)
			{
				this.DM.mLastSearchPage = 30;
				this.DM.CurSelectLanguage = AllianceHint.GenuineLang;
				this.m_door.OpenMenu(EGUIWindow.UI_LanguageSelect, 0, 0, false);
				this.DM.mAllianceSearchView = true;
			}
			else if (sender.m_BtnID1 == 33)
			{
				this.s_input.text = string.Empty;
				AllianceHint.SeekKind = 0;
				AllianceHint.SearchNum = 0;
				this.m_text[8].text = (AllianceHint.SearchName = (AllianceHint.FilterName = string.Empty));
				this.AllianceUpdate(4, 10);
			}
			else if (sender.m_BtnID1 == 34)
			{
				this.SetFilterName(0);
				AllianceHint.SeekKind = 0;
				AllianceHint.SearchNum = 0;
				AllianceHint.GenuineLang = (AllianceHint.FilterIdx = (this.DM.CurSelectLanguage = 0));
				this.m_filter.text = (AllianceHint.SearchLang = string.Empty);
				this.AllianceUpdate(5, 10);
			}
			return;
		}
		if (sender.m_BtnID1 == 999)
		{
			this.ClearUIInfo();
			this.ClearAlliance();
			this.m_door.CloseMenu(false);
		}
		else if (sender.m_BtnID1 == 998)
		{
			if (this.m_InputField.text.Length >= 3)
			{
				this.DM.SendSearchPlayer(this.m_InputField.text);
				this.SetSearchText(true);
			}
			else
			{
				this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4710u), 255, true);
			}
		}
		else if (sender.m_BtnID1 == 997)
		{
			this.SetEmptyInput();
		}
		else if (sender.m_BtnID1 == 996)
		{
			this.SetTabPanel(eTabPanel.Personal);
		}
		else if (sender.m_BtnID1 == 995)
		{
			this.SetTabPanel(eTabPanel.Alliance);
		}
		else if (sender.m_BtnID1 >= 0 && sender.m_BtnID1 < (int)this.DM.m_RecvSearchPlayerCount)
		{
			this.SaveUIInfo();
			if (sender.m_BtnID1 < (int)this.DM.m_RecvSearchPlayerCount && sender.m_BtnID1 >= 0)
			{
				this.DM.ShowLordProfile(this.DM.m_SearchPlayerData[sender.m_BtnID1].Name.ToString());
			}
		}
	}

	// Token: 0x06001F58 RID: 8024 RVA: 0x003BF39C File Offset: 0x003BD59C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelId == 0 && dataIdx < this.DM.m_SearchPlayerData.Length)
		{
			int num = dataIdx % 2;
			if (this.m_SearchItem[panelObjectIdx].Hibtn == null)
			{
				this.m_SearchItem[panelObjectIdx].Bg1 = item.transform.GetChild(0).GetComponent<Image>();
				this.m_SearchItem[panelObjectIdx].Bg2 = item.transform.GetChild(1).GetComponent<Image>();
				this.m_SearchItem[panelObjectIdx].Hibtn = item.transform.GetChild(2).GetComponent<UIHIBtn>();
				this.m_SearchItem[panelObjectIdx].NameText = item.transform.GetChild(5).GetComponent<UIText>();
				this.m_SearchItem[panelObjectIdx].NameText.font = this.TTF;
				this.m_SearchItem[panelObjectIdx].PowerText = item.transform.GetChild(6).GetComponent<UIText>();
				this.m_SearchItem[panelObjectIdx].PowerText.font = this.TTF;
				this.m_SearchItem[panelObjectIdx].KillText = item.transform.GetChild(7).GetComponent<UIText>();
				this.m_SearchItem[panelObjectIdx].KillText.font = this.TTF;
				this.m_SearchItem[panelObjectIdx].Btn = item.transform.GetChild(8).GetComponent<UIButton>();
				this.m_SearchItem[panelObjectIdx].Btn.m_Handler = this;
				this.m_SearchItem[panelObjectIdx].NameStr = StringManager.Instance.SpawnString(30);
				this.m_SearchItem[panelObjectIdx].PowerStr = StringManager.Instance.SpawnString(30);
				this.m_SearchItem[panelObjectIdx].KillStr = StringManager.Instance.SpawnString(30);
				this.m_ItemBtnStr[panelObjectIdx] = item.transform.GetChild(8).GetChild(0).GetComponent<UIText>();
			}
			this.GM.ChangeHeroItemImg(this.m_SearchItem[panelObjectIdx].Hibtn.transform, eHeroOrItem.Hero, this.DM.m_SearchPlayerData[dataIdx].Head, 11, 0, 0);
			this.m_SearchItem[panelObjectIdx].NameStr.ClearString();
			if (this.DM.m_SearchPlayerData[dataIdx].AllianceTag.Length != 0)
			{
				this.m_SearchItem[panelObjectIdx].NameStr.StringToFormat(this.DM.m_SearchPlayerData[dataIdx].AllianceTag);
				this.m_SearchItem[panelObjectIdx].NameStr.StringToFormat(this.DM.m_SearchPlayerData[dataIdx].Name);
				this.m_SearchItem[panelObjectIdx].NameStr.AppendFormat("[{0}]{1}");
			}
			else
			{
				this.m_SearchItem[panelObjectIdx].NameStr.Append(this.DM.m_SearchPlayerData[dataIdx].Name);
			}
			this.m_SearchItem[panelObjectIdx].NameText.text = this.m_SearchItem[panelObjectIdx].NameStr.ToString();
			this.m_SearchItem[panelObjectIdx].NameText.SetAllDirty();
			this.m_SearchItem[panelObjectIdx].NameText.cachedTextGenerator.Invalidate();
			this.m_SearchItem[panelObjectIdx].PowerStr.ClearString();
			this.m_SearchItem[panelObjectIdx].PowerStr.uLongToFormat(this.DM.m_SearchPlayerData[dataIdx].Power, 1, true);
			this.m_SearchItem[panelObjectIdx].PowerStr.AppendFormat("{0}");
			this.m_SearchItem[panelObjectIdx].PowerText.text = this.m_SearchItem[panelObjectIdx].PowerStr.ToString();
			this.m_SearchItem[panelObjectIdx].PowerText.SetAllDirty();
			this.m_SearchItem[panelObjectIdx].PowerText.cachedTextGenerator.Invalidate();
			this.m_SearchItem[panelObjectIdx].KillStr.ClearString();
			this.m_SearchItem[panelObjectIdx].KillStr.uLongToFormat(this.DM.m_SearchPlayerData[dataIdx].TroopKillNum, 1, true);
			this.m_SearchItem[panelObjectIdx].KillStr.AppendFormat("{0}");
			this.m_SearchItem[panelObjectIdx].KillText.text = this.m_SearchItem[panelObjectIdx].KillStr.ToString();
			this.m_SearchItem[panelObjectIdx].KillText.SetAllDirty();
			this.m_SearchItem[panelObjectIdx].KillText.cachedTextGenerator.Invalidate();
			this.m_SearchItem[panelObjectIdx].Btn.m_BtnID1 = dataIdx;
			if (num == 0)
			{
				this.m_SearchItem[panelObjectIdx].Bg1.enabled = true;
				this.m_SearchItem[panelObjectIdx].Bg2.enabled = false;
			}
		}
		else if (panelId == 1)
		{
			this.ItemTag[panelObjectIdx][0] = item.transform.GetChild(2).GetChild(9).GetComponent<UIText>();
			this.ItemTag[panelObjectIdx][0].font = this.TTF;
			this.ItemTag[panelObjectIdx][0].text = "[" + AllianceHint.Search[dataIdx].Tag + "]  " + AllianceHint.Search[dataIdx].Name;
			this.ItemTag[panelObjectIdx][1] = item.transform.GetChild(2).GetChild(11).GetComponent<UIText>();
			this.ItemTag[panelObjectIdx][1].font = this.TTF;
			this.Path.Length = 0;
			this.ItemTag[panelObjectIdx][1].text = AllianceHint.Search[dataIdx].Power.ToString("N0");
			this.ItemTag[panelObjectIdx][2] = item.transform.GetChild(2).GetChild(12).GetComponent<UIText>();
			this.ItemTag[panelObjectIdx][2].font = this.TTF;
			this.Path.Length = 0;
			this.ItemTag[panelObjectIdx][2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4723u), AllianceHint.Search[dataIdx].GiftLv).ToString();
			this.ItemTag[panelObjectIdx][3] = item.transform.GetChild(2).GetChild(13).GetComponent<UIText>();
			this.ItemTag[panelObjectIdx][3].font = this.TTF;
			this.Path.Length = 0;
			this.ItemTag[panelObjectIdx][3].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(795u), AllianceHint.Search[dataIdx].Member).ToString();
			this.ItemTag[panelObjectIdx][4] = item.transform.GetChild(2).GetChild(14).GetComponent<UIText>();
			this.ItemTag[panelObjectIdx][4].font = this.TTF;
			this.ItemTag[panelObjectIdx][4].text = DataManager.Instance.GetLanguageStr(AllianceHint.Search[dataIdx].Language);
			ushort emblem = AllianceHint.Search[dataIdx].Emblem;
			int num2 = (int)(emblem & 7);
			int num3 = emblem >> 3 & 7;
			int num4 = num3 * 8 + num2 + 1;
			if (num4 > 64)
			{
				num4 = 64;
			}
			int num5 = (emblem >> 6 & 63) + 1;
			if (num5 > 64)
			{
				num5 = 64;
			}
			this.GM.SetBadgeTotemImg(item.transform.GetChild(2).GetChild(1), num4, num5);
			UIButton component = item.transform.GetChild(2).GetChild(8).GetComponent<UIButton>();
			component.m_BtnID1 = dataIdx;
			component.m_Handler = this;
			if (!this.m_panel[panelObjectIdx])
			{
				this.m_panel[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			}
			item.transform.GetChild(2).gameObject.SetActive(AllianceHint.Search[dataIdx].ID > 0u);
			item.transform.GetChild(3).gameObject.SetActive(AllianceHint.Search[dataIdx].ID == 0u);
			item.transform.GetChild(0).GetChild(0).gameObject.SetActive(dataIdx % 2 == 0);
			item.transform.GetChild(0).GetChild(1).gameObject.SetActive(dataIdx % 2 == 1);
			if (AllianceHint.Proceeding == 1L && AllianceHint.Pending == 0L && AllianceHint.Search[dataIdx].ID == 0u)
			{
				this.AllianceUpdate(22, 0);
			}
		}
	}

	// Token: 0x06001F59 RID: 8025 RVA: 0x003BFCD4 File Offset: 0x003BDED4
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001F5A RID: 8026 RVA: 0x003BFCD8 File Offset: 0x003BDED8
	private void UpdateScroll()
	{
		List<float> list = new List<float>();
		for (int i = 0; i < (int)this.DM.m_RecvSearchPlayerCount; i++)
		{
			list.Add(72f);
		}
		this.m_ScrollPanel.AddNewDataHeight(list, true, true);
	}

	// Token: 0x06001F5B RID: 8027 RVA: 0x003BFD20 File Offset: 0x003BDF20
	private void ValueChange(string input)
	{
		if (input != string.Empty)
		{
			if (!this.m_CancelInput.gameObject.activeSelf)
			{
				this.m_CancelInput.gameObject.SetActive(true);
			}
		}
		else
		{
			if (this.m_CancelInput.gameObject.activeSelf)
			{
				this.m_CancelInput.gameObject.SetActive(false);
			}
			this.SetSearchText(false);
		}
	}

	// Token: 0x06001F5C RID: 8028 RVA: 0x003BFD98 File Offset: 0x003BDF98
	protected char OnValidateInput(string text, int index, char check)
	{
		return ((check < 'A' || check > 'Z') && (check < 'a' || check > 'z') && (check < '0' || check > '9') && check != ' ') ? '\0' : check;
	}

	// Token: 0x06001F5D RID: 8029 RVA: 0x003BFDE4 File Offset: 0x003BDFE4
	private void SetEmptyInput()
	{
		this.m_InputField.text = string.Empty;
		this.SetSearchText(false);
		if (this.DM.m_RecvSearchPlayerCount == 0)
		{
			this.SetEmptyMsgPanel(eMsgPanel.PlzInputName);
		}
		else
		{
			this.SetEmptyMsgPanel(eMsgPanel.None);
		}
	}

	// Token: 0x06001F5E RID: 8030 RVA: 0x003BFE2C File Offset: 0x003BE02C
	private void SetSearchText(bool bShow)
	{
		if (bShow)
		{
			this.m_SearchTextStr.ClearString();
			this.m_SearchTextStr.StringToFormat(this.m_InputField.text);
			this.m_SearchTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(7051u));
			this.m_SearchText.text = this.m_SearchTextStr.ToString();
			this.m_SearchText.SetAllDirty();
			this.m_SearchText.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.m_SearchText.text = string.Empty;
		}
	}

	// Token: 0x06001F5F RID: 8031 RVA: 0x003BFEC8 File Offset: 0x003BE0C8
	private void SetEmptyMsgPanel(eMsgPanel msg)
	{
		if (msg == eMsgPanel.None)
		{
			this.m_EmptyMsgPanel.gameObject.SetActive(false);
		}
		else if (msg == eMsgPanel.PlzInputName)
		{
			this.m_EmptyMsgText.text = this.DM.mStringTable.GetStringByID(7021u);
			this.m_EmptyMsgPanel.gameObject.SetActive(true);
		}
		else if (msg == eMsgPanel.SearchError)
		{
			this.m_EmptyMsgTextStr.ClearString();
			this.m_EmptyMsgTextStr.StringToFormat(this.m_InputField.text);
			this.m_EmptyMsgTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(7050u));
			this.m_EmptyMsgText.text = this.m_EmptyMsgTextStr.ToString();
			this.m_EmptyMsgText.SetAllDirty();
			this.m_EmptyMsgText.cachedTextGenerator.Invalidate();
			this.m_EmptyMsgPanel.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001F60 RID: 8032 RVA: 0x003BFFBC File Offset: 0x003BE1BC
	private void SetTabPanel(eTabPanel tab)
	{
		if (tab == eTabPanel.Personal)
		{
			this.Title.text = this.DM.mStringTable.GetStringByID(7057u);
			this.m_TabType = eTabPanel.Personal;
			this.m_TweenA1.gameObject.SetActive(true);
			this.m_TweenA2.gameObject.SetActive(false);
			this.m_TabIcon1.sprite = this.m_SPArray.GetSprite(2);
			this.m_TabIcon2.sprite = this.m_SPArray.GetSprite(4);
			if (this.DM.m_RecvSearchPlayerCount > 0)
			{
				this.SetEmptyMsgPanel(eMsgPanel.None);
			}
			else
			{
				this.SetEmptyMsgPanel(eMsgPanel.PlzInputName);
			}
			this.m_SearchPanel.gameObject.SetActive(true);
			this.m_ScrollPanel.gameObject.SetActive(true);
			this.Alliance.gameObject.SetActive(false);
			if (this.cScrollRect != null)
			{
				this.cScrollRect.StopMovement();
			}
		}
		else
		{
			this.Title.text = this.DM.mStringTable.GetStringByID(7058u);
			this.m_TabType = eTabPanel.Alliance;
			this.m_TweenA1.gameObject.SetActive(false);
			this.m_TweenA2.gameObject.SetActive(true);
			this.m_TabIcon1.sprite = this.m_SPArray.GetSprite(2);
			this.m_TabIcon2.sprite = this.m_SPArray.GetSprite(4);
			this.m_EmptyMsgPanel.gameObject.SetActive(false);
			this.m_SearchPanel.gameObject.SetActive(false);
			this.m_ScrollPanel.gameObject.SetActive(false);
			this.Alliance.gameObject.SetActive(true);
			this.m_scroll.gameObject.SetActive(true);
			if (this.DM.mAllianceSearchView)
			{
				this.AllianceUpdate(3, 10);
				this.DM.mAllianceSearchView = false;
				this.m_scroll.GoTo(AllianceHint.Positioning, AllianceHint.Scrolling);
			}
			if (AllianceHint.SearchNum > 0)
			{
				this.SetEmptyMsgAlly(eMsgPanel.None);
			}
			else
			{
				this.SetEmptyMsgAlly(eMsgPanel.PlzInputName);
			}
		}
		this.DM.mLastSearchPage = (byte)tab;
	}

	// Token: 0x06001F61 RID: 8033 RVA: 0x003C01F0 File Offset: 0x003BE3F0
	private void SaveUIInfo()
	{
		this.DM.m_SearchListScrollIndex = this.m_ScrollPanel.GetTopIdx();
		this.DM.m_SearchListScrollPos = this.m_ScrollContentRT.anchoredPosition.y;
		this.DM.m_PreSearchName = this.m_InputField.text;
		this.DM.bClaerSearchData = false;
	}

	// Token: 0x06001F62 RID: 8034 RVA: 0x003C0254 File Offset: 0x003BE454
	private void ClearUIInfo()
	{
		this.DM.m_SearchListScrollIndex = 0;
		this.DM.m_SearchListScrollPos = 0f;
		this.DM.m_RecvSearchPlayerCount = 0;
		this.DM.m_PreSearchName = string.Empty;
		this.DM.bClaerSearchData = false;
	}

	// Token: 0x06001F63 RID: 8035 RVA: 0x003C02A8 File Offset: 0x003BE4A8
	private void SetAlliancePanel()
	{
		for (int i = 0; i < 7; i++)
		{
			this.ItemTag[i] = new UIText[5];
		}
		this.Alliance = base.transform.GetChild(5).GetChild(0);
		this.Alliance.GetChild(3).GetChild(16).GetComponent<UIButton>().m_Handler = this;
		this.Alliance.GetChild(3).GetChild(20).GetComponent<UIButton>().m_Handler = this;
		this.Alliance.GetChild(3).GetChild(21).GetComponent<UIButton>().m_Handler = this;
		this.Alliance.GetChild(3).GetChild(17).GetComponent<UIButton>().m_Handler = this;
		this.Alliance.GetChild(3).GetChild(17).GetChild(0).GetComponent<UIText>().font = this.TTF;
		this.m_text[0] = this.Alliance.GetChild(3).GetChild(17).GetChild(0).GetComponent<UIText>();
		this.Alliance.GetChild(3).GetChild(17).GetChild(1).GetComponent<Text>().font = this.TTF;
		this.m_text[1] = this.Alliance.GetChild(3).GetChild(4).GetChild(0).GetComponent<UIText>();
		this.m_text[1].font = this.TTF;
		this.m_text[1].text = this.DM.mStringTable.GetStringByID(4702u);
		this.m_text[2] = this.Alliance.GetChild(3).GetChild(4).GetChild(1).GetComponent<UIText>();
		this.m_text[2].font = this.TTF;
		this.m_text[3] = this.Alliance.GetChild(3).GetChild(5).GetChild(0).GetComponent<UIText>();
		this.m_text[3].font = this.TTF;
		this.m_text[3].text = this.DM.mStringTable.GetStringByID(4704u);
		this.m_text[4] = this.Alliance.GetChild(3).GetChild(15).GetChild(0).GetComponent<UIText>();
		this.m_text[4].font = this.TTF;
		this.m_text[5] = this.Alliance.GetChild(3).GetChild(15).GetChild(1).GetComponent<UIText>();
		this.m_text[5].font = this.TTF;
		this.m_text[5].text = this.DM.mStringTable.GetStringByID(793u);
		this.m_text[6] = this.Alliance.GetChild(3).GetChild(17).GetChild(1).GetComponent<UIText>();
		this.m_text[6].font = this.TTF;
		this.m_text[6].text = this.DM.mStringTable.GetStringByID(794u);
		this.m_text[7] = this.Alliance.GetChild(5).GetChild(2).GetChild(8).GetChild(0).GetComponent<UIText>();
		this.m_text[7].text = this.DM.mStringTable.GetStringByID(4634u);
		this.m_text[7].font = this.TTF;
		this.m_text[8] = this.Alliance.GetChild(3).GetChild(4).GetChild(2).GetComponent<UIText>();
		this.m_text[8].font = this.TTF;
		this.m_filter = this.Alliance.GetChild(3).GetChild(5).GetChild(1).GetComponent<UIText>();
		this.m_filter.font = this.TTF;
		this.s_input = this.Alliance.GetChild(3).GetChild(15).GetComponent<UIEmojiInput>();
		this.s_input.onValueChange.AddListener(delegate(string input)
		{
			this.SearchChange(input);
		});
		this.s_input.characterLimit = 20;
		AllianceHint.GenuineLang = this.DM.GetUserLanguageID();
		this.m_panel = new ScrollPanelItem[7];
		if (AllianceHint.Search == null)
		{
			AllianceHint.Search = new AllianceSearch[101];
		}
		this.GM.InitBadgeTotem(this.Alliance.GetChild(5).GetChild(2).GetChild(1), 0);
		this.m_scroll = this.Alliance.GetChild(4).GetComponent<ScrollPanel>();
		this.m_scroll.IntiScrollPanel(420f, 3f, 4f, this.ItemsHeight, 7, this);
		this.m_scroll.AddNewDataHeight(this.ItemsHeight, true, true);
		this.SearchRT = this.m_scroll.transform.GetChild(0).GetComponent<RectTransform>();
		if (!this.DM.mAllianceSearchView)
		{
			AllianceHint.SeekKind = 0;
			AllianceHint.SearchNum = 0;
			AllianceHint.GenuineLang = (AllianceHint.FilterIdx = (this.DM.CurSelectLanguage = 0));
			AllianceHint.SearchLang = (AllianceHint.SearchName = (AllianceHint.FilterName = string.Empty));
		}
		else
		{
			this.m_text[8].text = (AllianceHint.SearchName = ((AllianceHint.FilterName.Length <= 0) ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703u), AllianceHint.FilterName).ToString()));
			this.Path.Length = 0;
			this.SetFilterName(AllianceHint.GenuineLang = this.DM.CurSelectLanguage);
			this.m_filter.text = (AllianceHint.SearchLang = ((AllianceHint.FilterIdx <= 0) ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703u), this.Alliance.GetChild(3).GetChild(17).GetChild(0).GetComponent<UIText>().text).ToString()));
			this.s_input.text = AllianceHint.FilterName;
			this.SearchChange(AllianceHint.FilterName);
		}
	}

	// Token: 0x06001F64 RID: 8036 RVA: 0x003C08E0 File Offset: 0x003BEAE0
	private void ClearAlliance()
	{
		this.DM.mAllianceSearchView = false;
	}

	// Token: 0x06001F65 RID: 8037 RVA: 0x003C08F0 File Offset: 0x003BEAF0
	private void AllianceUpdate(int arg1, int arg2)
	{
		if (AllianceHint.Search == null)
		{
			return;
		}
		if (arg1 == 0)
		{
			AllianceHint.Pending = (long)(AllianceHint.SearchNum = Mathf.Min((int)DataManager.msgBuffer[1], 100));
		}
		else if (arg1 == 2)
		{
			AllianceHint.SearchPage = 0;
			while (AllianceHint.SearchPage < AllianceHint.SearchNum && this.m_scroll && AllianceHint.SearchPage < this.m_panel.Length && this.m_panel[AllianceHint.SearchPage] && this.m_panel[AllianceHint.SearchPage].m_BtnID1 >= 0)
			{
				this.UpDateRowItem(this.m_panel[AllianceHint.SearchPage].gameObject, this.m_panel[AllianceHint.SearchPage].m_BtnID1, 0, 1);
				AllianceHint.SearchPage++;
			}
		}
		else if (arg1 == 22)
		{
			if ((AllianceHint.SearchNum / 10 > (int)AllianceHint.SearchIdx || (AllianceHint.SearchNum / 10 == (int)AllianceHint.SearchIdx && AllianceHint.SearchNum % 10 != 0)) && NetworkManager.Connected())
			{
				byte searchIdx = AllianceHint.SearchIdx;
				AllianceHint.SearchIdx = searchIdx + 1;
				AllianceHint.Pending = (long)searchIdx;
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_SEARCHRESULT;
				messagePacket.AddSeqId();
				messagePacket.Add(AllianceHint.SearchIdx);
				messagePacket.Send(false);
			}
		}
		else if (arg1 == 23)
		{
			this.m_scroll.gameObject.SetActive(false);
		}
		else if (arg1 == 24)
		{
			this.m_scroll.gameObject.SetActive(true);
		}
		if (arg2 == 10)
		{
			if (AllianceHint.SearchNum > 0)
			{
				this.SetEmptyMsgAlly(eMsgPanel.None);
				for (int i = 0; i < AllianceHint.SearchNum; i++)
				{
					if (!this.DM.mAllianceSearchView)
					{
						AllianceHint.Search[i].ID = 0u;
					}
					if (this.ItemsHeight.Count < AllianceHint.SearchNum)
					{
						this.ItemsHeight.Add(96f);
					}
				}
				if (this.ItemsHeight.Count > AllianceHint.SearchNum)
				{
					this.ItemsHeight.RemoveRange(AllianceHint.SearchNum - 1, this.ItemsHeight.Count - AllianceHint.SearchNum);
				}
			}
			else
			{
				this.ItemsHeight.Clear();
				AllianceHint.SearchIdx = 0;
				this.SetEmptyMsgAlly(eMsgPanel.PlzInputName);
			}
			if (this.m_scroll)
			{
				this.m_scroll.gameObject.SetActive(true);
				this.m_scroll.AddNewDataHeight(this.ItemsHeight, true, true);
			}
		}
	}

	// Token: 0x06001F66 RID: 8038 RVA: 0x003C0B9C File Offset: 0x003BED9C
	private void SearchChange(string input)
	{
		AllianceHint.FilterName = input;
		this.Alliance.GetChild(3).GetChild(16).gameObject.SetActive(AllianceHint.FilterName.Length > 0);
	}

	// Token: 0x06001F67 RID: 8039 RVA: 0x003C0BDC File Offset: 0x003BEDDC
	private void SetFilterName(byte Filter)
	{
		AllianceHint.FilterIdx = Filter;
		this.Alliance.GetChild(3).GetChild(17).GetChild(1).gameObject.SetActive(Filter == 0);
		this.Alliance.GetChild(3).GetChild(20).gameObject.SetActive(Filter > 0);
		if (Filter > 0)
		{
			this.Alliance.GetChild(3).GetChild(17).GetChild(0).GetComponent<UIText>().text = this.DM.GetLanguageStr(Filter);
		}
		else
		{
			this.Alliance.GetChild(3).GetChild(17).GetChild(0).GetComponent<UIText>().text = string.Empty;
		}
	}

	// Token: 0x06001F68 RID: 8040 RVA: 0x003C0C9C File Offset: 0x003BEE9C
	private void SetEmptyMsgAlly(eMsgPanel msg)
	{
		if (msg == eMsgPanel.None)
		{
			this.m_EmptyMsgPanel.gameObject.SetActive(false);
		}
		else if (msg == eMsgPanel.PlzInputName)
		{
			this.m_EmptyMsgTextStr.ClearString();
			if (AllianceHint.SeekKind == 0)
			{
				this.m_EmptyMsgTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(4711u));
			}
			else if (AllianceHint.SearchLang != string.Empty && AllianceHint.SearchName != string.Empty)
			{
				this.m_EmptyMsgTextStr.StringToFormat(AllianceHint.FilterName);
				this.m_EmptyMsgTextStr.StringToFormat(this.DM.GetLanguageStr(AllianceHint.FilterIdx));
				this.m_EmptyMsgTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(735u));
			}
			else if (AllianceHint.SearchName != string.Empty)
			{
				this.m_EmptyMsgTextStr.StringToFormat(AllianceHint.FilterName);
				this.m_EmptyMsgTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(4709u));
			}
			else if (AllianceHint.SearchLang != string.Empty)
			{
				this.m_EmptyMsgTextStr.StringToFormat(this.DM.GetLanguageStr(AllianceHint.FilterIdx));
				this.m_EmptyMsgTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(4709u));
			}
			this.m_EmptyMsgText.text = this.m_EmptyMsgTextStr.ToString();
			this.m_EmptyMsgText.SetAllDirty();
			this.m_EmptyMsgText.cachedTextGenerator.Invalidate();
			this.m_EmptyMsgPanel.gameObject.SetActive(true);
		}
		else if (msg == eMsgPanel.SearchError)
		{
			this.m_EmptyMsgTextStr.ClearString();
			this.m_EmptyMsgTextStr.StringToFormat(this.m_InputField.text);
			this.m_EmptyMsgTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(7050u));
			this.m_EmptyMsgText.text = this.m_EmptyMsgTextStr.ToString();
			this.m_EmptyMsgText.SetAllDirty();
			this.m_EmptyMsgText.cachedTextGenerator.Invalidate();
			this.m_EmptyMsgPanel.gameObject.SetActive(true);
		}
	}

	// Token: 0x04006332 RID: 25394
	private const int MaxScrollCount = 7;

	// Token: 0x04006333 RID: 25395
	private DataManager DM;

	// Token: 0x04006334 RID: 25396
	private GUIManager GM;

	// Token: 0x04006335 RID: 25397
	private Font TTF;

	// Token: 0x04006336 RID: 25398
	private Door m_door;

	// Token: 0x04006337 RID: 25399
	private SearchItemObj[] m_SearchItem;

	// Token: 0x04006338 RID: 25400
	private UIEmojiInput m_InputField;

	// Token: 0x04006339 RID: 25401
	private UIText m_SearchText;

	// Token: 0x0400633A RID: 25402
	private ScrollPanel m_ScrollPanel;

	// Token: 0x0400633B RID: 25403
	private Transform m_SearchPanel;

	// Token: 0x0400633C RID: 25404
	private CScrollRect cScrollRect;

	// Token: 0x0400633D RID: 25405
	private UIText Title;

	// Token: 0x0400633E RID: 25406
	private UIText btn_Text;

	// Token: 0x0400633F RID: 25407
	private UIText[] m_InputText = new UIText[2];

	// Token: 0x04006340 RID: 25408
	private UIText[] m_TextStr = new UIText[2];

	// Token: 0x04006341 RID: 25409
	private UIText[] m_ItemBtnStr = new UIText[7];

	// Token: 0x04006342 RID: 25410
	private Transform Alliance;

	// Token: 0x04006343 RID: 25411
	private UIEmojiInput s_input;

	// Token: 0x04006344 RID: 25412
	private ScrollPanel m_scroll;

	// Token: 0x04006345 RID: 25413
	private ScrollPanelItem[] m_panel;

	// Token: 0x04006346 RID: 25414
	private UIText m_search;

	// Token: 0x04006347 RID: 25415
	private UIText m_filter;

	// Token: 0x04006348 RID: 25416
	private UIText[][] ItemTag = new UIText[7][];

	// Token: 0x04006349 RID: 25417
	private UIText[] m_text = new UIText[9];

	// Token: 0x0400634A RID: 25418
	private Transform Transformer;

	// Token: 0x0400634B RID: 25419
	private RectTransform SearchRT;

	// Token: 0x0400634C RID: 25420
	private StringBuilder Path = new StringBuilder();

	// Token: 0x0400634D RID: 25421
	private List<float> ItemsHeight = new List<float>();

	// Token: 0x0400634E RID: 25422
	private RectTransform m_ScrollContentRT;

	// Token: 0x0400634F RID: 25423
	private Transform m_EmptyMsgPanel;

	// Token: 0x04006350 RID: 25424
	private UIText m_EmptyMsgText;

	// Token: 0x04006351 RID: 25425
	private UISpritesArray m_SPArray;

	// Token: 0x04006352 RID: 25426
	private Image m_TabBg1;

	// Token: 0x04006353 RID: 25427
	private Image m_TabBg2;

	// Token: 0x04006354 RID: 25428
	private Image m_TabIcon1;

	// Token: 0x04006355 RID: 25429
	private Image m_TabIcon2;

	// Token: 0x04006356 RID: 25430
	private Transform m_TweenA1;

	// Token: 0x04006357 RID: 25431
	private Transform m_TweenA2;

	// Token: 0x04006358 RID: 25432
	private UIButton m_CancelInput;

	// Token: 0x04006359 RID: 25433
	private eTabPanel m_TabType;

	// Token: 0x0400635A RID: 25434
	private CString m_SearchTextStr;

	// Token: 0x0400635B RID: 25435
	private CString m_SearchTitleStr;

	// Token: 0x0400635C RID: 25436
	private CString m_EmptyMsgTextStr;
}
