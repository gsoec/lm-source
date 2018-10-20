using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200064B RID: 1611
internal class UIReplaceLord : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06001F09 RID: 7945 RVA: 0x003B7E80 File Offset: 0x003B6080
	public override void OnOpen(int arg1, int arg2)
	{
		this.GM = GUIManager.Instance;
		this.DM = DataManager.Instance;
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.TTF = this.GM.GetTTFFont();
		GUIManager.Instance.AddSpriteAsset("UI_frame");
		this.DM.SetSortNonFightHeroID();
		this.DM.SetSortFightHeroID();
		this.m_SpriteStr = StringManager.Instance.SpawnString(30);
		this.m_OriginaArmyNumStr = StringManager.Instance.SpawnString(30);
		this.m_ChangeArmyNumStr = StringManager.Instance.SpawnString(30);
		this.m_HeroMaxNumStr = StringManager.Instance.SpawnString(30);
		this.m_SkillInfoStr = new CString[4];
		for (int i = 0; i < this.m_SkillInfoStr.Length; i++)
		{
			this.m_SkillInfoStr[i] = StringManager.Instance.SpawnString(30);
		}
		this.m_Data = new List<SoldierScrollItem>();
		this.m_ScrollObj = new ScrollPanelObject[8];
		for (int j = 0; j < 8; j++)
		{
			this.m_ScrollObj[j].PanelItem = new SoldierPanelObject[2];
		}
		this.m_SpritesArray = base.transform.GetComponent<UISpritesArray>();
		Image component = base.transform.GetChild(8).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close_base");
		component.material = this.door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX && component)
		{
			component.enabled = false;
		}
		component = base.transform.GetChild(8).GetChild(0).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close");
		component.material = this.door.LoadMaterial();
		UIButton component2 = base.transform.GetChild(8).GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 999;
		this.m_tmptext[this.mTextCount] = base.transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(731u);
		this.mTextCount++;
		this.m_tmptext[this.mTextCount] = base.transform.GetChild(0).GetChild(3).GetChild(2).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(733u);
		this.mTextCount++;
		this.m_tmptext[this.mTextCount] = base.transform.GetChild(0).GetChild(8).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(730u);
		this.mTextCount++;
		component2 = base.transform.GetChild(7).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 998;
		this.m_tmptext[this.mTextCount] = base.transform.GetChild(7).GetChild(0).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(189u);
		this.mTextCount++;
		this.m_OriginaHIBtn = base.transform.GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
		this.GM.InitianHeroItemImg(this.m_OriginaHIBtn.transform, eHeroOrItem.Hero, 1, 1, 1, 1, true, false, true, false);
		this.m_ChangeHIBtn = base.transform.GetChild(2).GetChild(0).GetComponent<UIHIBtn>();
		this.GM.InitianHeroItemImg(this.m_ChangeHIBtn.transform, eHeroOrItem.Hero, 1, 1, 1, 1, true, false, true, false);
		this.m_OriginaIcon1 = base.transform.GetChild(1).GetChild(1).GetComponent<Image>();
		this.m_OriginaIcon2 = base.transform.GetChild(1).GetChild(2).GetComponent<Image>();
		this.m_OriginaName = base.transform.GetChild(1).GetChild(3).GetComponent<UIText>();
		this.m_OriginaName.font = this.TTF;
		this.m_OriginaArmyText = base.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
		this.m_OriginaArmyText.font = this.TTF;
		this.m_OriginaArmyNumText = base.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
		this.m_OriginaArmyNumText.font = this.TTF;
		this.m_ChangeIcon1 = base.transform.GetChild(2).GetChild(1).GetComponent<Image>();
		this.m_ChangeIcon2 = base.transform.GetChild(2).GetChild(2).GetComponent<Image>();
		this.m_ChangeName = base.transform.GetChild(2).GetChild(3).GetComponent<UIText>();
		this.m_ChangeName.font = this.TTF;
		this.m_ChangeArmyText = base.transform.GetChild(2).GetChild(4).GetComponent<UIText>();
		this.m_ChangeArmyText.font = this.TTF;
		this.m_ChangeArmyNumText = base.transform.GetChild(2).GetChild(5).GetComponent<UIText>();
		this.m_ChangeArmyNumText.font = this.TTF;
		UIHIBtn component3 = base.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(0).GetComponent<UIHIBtn>();
		this.GM.InitianHeroItemImg(component3.transform, eHeroOrItem.Hero, 1, 0, 0, 0, true, false, true, false);
		component3 = base.transform.GetChild(6).GetChild(0).GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
		this.GM.InitianHeroItemImg(component3.transform, eHeroOrItem.Hero, 1, 0, 0, 0, true, false, true, false);
		this.m_tmptext[this.mTextCount] = base.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(3).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		this.mTextCount++;
		this.m_tmptext[this.mTextCount] = base.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(4).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		this.mTextCount++;
		this.m_tmptext[this.mTextCount] = base.transform.GetChild(6).GetChild(0).GetChild(1).GetChild(3).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		this.mTextCount++;
		this.m_tmptext[this.mTextCount] = base.transform.GetChild(6).GetChild(0).GetChild(1).GetChild(4).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		this.mTextCount++;
		this.m_tmptext[this.mTextCount] = base.transform.GetChild(6).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(341u);
		this.mTextCount++;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform rectTransform = base.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(7).GetComponent<Image>().rectTransform;
			Vector3 localScale = rectTransform.localScale;
			localScale.x = -1f;
			rectTransform.localScale = localScale;
			rectTransform = base.transform.GetChild(6).GetChild(0).GetChild(1).GetChild(7).GetComponent<Image>().rectTransform;
			localScale = rectTransform.localScale;
			localScale.x = -1f;
			rectTransform.localScale = localScale;
		}
		this.m_SkillHintPanel = base.transform.GetChild(9);
		this.m_HeroIcon = this.m_SkillHintPanel.GetChild(0).GetChild(1).GetComponent<UIHIBtn>();
		this.GM.InitianHeroItemImg(this.m_HeroIcon.transform, eHeroOrItem.Hero, 0, 0, 0, 0, true, false, true, false);
		this.m_HeroNameText = this.m_SkillHintPanel.GetChild(0).GetChild(3).GetComponent<UIText>();
		this.m_HeroNameText.font = this.TTF;
		this.m_HeroArmsText = this.m_SkillHintPanel.GetChild(0).GetChild(4).GetComponent<UIText>();
		this.m_HeroArmsText.font = this.TTF;
		this.m_HeroMaxNum = this.m_SkillHintPanel.GetChild(0).GetChild(5).GetComponent<UIText>();
		this.m_HeroMaxNum.font = this.TTF;
		this.m_HeroEnhanceIcon = this.m_SkillHintPanel.GetChild(0).GetChild(2).GetComponent<Image>();
		this.m_HeroEnhanceIcon.material = this.GetEnhanceMat();
		this.m_SkillImage = new Image[4];
		this.m_SkillFrame = new Image[4];
		this.m_SkillMaskTf = new Transform[4];
		this.m_SkliiNameText = new UIText[4];
		this.m_SkillInfoText = new UIText[4];
		for (int k = 0; k < 4; k++)
		{
			Transform child = this.m_SkillHintPanel.GetChild(k + 1);
			this.m_SkillImage[k] = child.GetChild(1).GetComponent<Image>();
			this.m_SkillFrame[k] = this.m_SkillHintPanel.GetChild(k + 1).GetChild(1).GetChild(0).GetComponent<Image>();
			this.m_SkliiNameText[k] = this.m_SkillHintPanel.GetChild(k + 1).GetChild(2).GetComponent<UIText>();
			this.m_SkliiNameText[k].font = this.TTF;
			this.m_SkillInfoText[k] = this.m_SkillHintPanel.GetChild(k + 1).GetChild(3).GetComponent<UIText>();
			this.m_SkillInfoText[k].font = this.TTF;
			this.m_SkillMaskTf[k] = this.m_SkillHintPanel.GetChild(k + 1).GetChild(4);
		}
		this.SetData(0);
		this.m_ScrollPanel = base.transform.GetChild(4).GetComponent<ScrollPanel>();
		List<float> list = new List<float>();
		for (int l = 0; l < this.m_Data.Count; l++)
		{
			list.Add(this.m_Data[l].Height);
		}
		this.m_ScrollPanel.IntiScrollPanel(497f, 10f, 6f, list, 8, this);
		UIButtonHint.scrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
		this.SetChangeLord(0, 0, 0, 0, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001F0A RID: 7946 RVA: 0x003B8A50 File Offset: 0x003B6C50
	public override void OnClose()
	{
		GUIManager.Instance.RemoveSpriteAsset("UI_frame");
		StringManager.Instance.DeSpawnString(this.m_SpriteStr);
		StringManager.Instance.DeSpawnString(this.m_OriginaArmyNumStr);
		StringManager.Instance.DeSpawnString(this.m_ChangeArmyNumStr);
		if (this.m_HeroMaxNumStr != null)
		{
			StringManager.Instance.DeSpawnString(this.m_HeroMaxNumStr);
			this.m_HeroMaxNumStr = null;
		}
		if (this.m_SkillInfoStr != null)
		{
			for (int i = 0; i < this.m_SkillInfoStr.Length; i++)
			{
				if (this.m_SkillInfoStr[i] != null)
				{
					StringManager.Instance.DeSpawnString(this.m_SkillInfoStr[i]);
					this.m_SkillInfoStr[i] = null;
				}
			}
		}
		for (int j = 0; j < this.m_ScrollObj.Length; j++)
		{
			for (int k = 0; k < 2; k++)
			{
				if (this.m_ScrollObj[j].PanelItem[k].MaxNumStr != null)
				{
					StringManager.Instance.DeSpawnString(this.m_ScrollObj[j].PanelItem[k].MaxNumStr);
				}
			}
		}
		this.Despawn();
		this.m_Data.Clear();
		this.m_Data = null;
	}

	// Token: 0x06001F0B RID: 7947 RVA: 0x003B8B9C File Offset: 0x003B6D9C
	public override void UpdateUI(int arg1, int arg2)
	{
	}

	// Token: 0x06001F0C RID: 7948 RVA: 0x003B8BA0 File Offset: 0x003B6DA0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews == NetworkNews.Refresh_ChangeLord)
			{
				if (meg[1] == 0)
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(734u), 255, true);
				}
				if (this.door)
				{
					this.door.CloseMenu(false);
				}
				return;
			}
			if (networkNews != NetworkNews.Refresh_TroopHome)
			{
				if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
				{
					return;
				}
				this.Refresh_FontTexture();
				return;
			}
			break;
		}
		this.DM.SetSortNonFightHeroID();
		this.DM.SetSortFightHeroID();
		this.Despawn();
		if (meg[0] == 29)
		{
			this.SetData(this.m_SelectHeroID);
		}
		else
		{
			this.SetData(0);
		}
		this.UpdateScroll(false);
		this.SetChangeLord(0, 0, 0, 0, 0, 0);
	}

	// Token: 0x06001F0D RID: 7949 RVA: 0x003B8C90 File Offset: 0x003B6E90
	public void Refresh_FontTexture()
	{
		if (this.m_OriginaName != null && this.m_OriginaName.enabled)
		{
			this.m_OriginaName.enabled = false;
			this.m_OriginaName.enabled = true;
		}
		if (this.m_OriginaArmyText != null && this.m_OriginaArmyText.enabled)
		{
			this.m_OriginaArmyText.enabled = false;
			this.m_OriginaArmyText.enabled = true;
		}
		if (this.m_OriginaArmyNumText != null && this.m_OriginaArmyNumText.enabled)
		{
			this.m_OriginaArmyNumText.enabled = false;
			this.m_OriginaArmyNumText.enabled = true;
		}
		if (this.m_ChangeName != null && this.m_ChangeName.enabled)
		{
			this.m_ChangeName.enabled = false;
			this.m_ChangeName.enabled = true;
		}
		if (this.m_ChangeArmyText != null && this.m_ChangeArmyText.enabled)
		{
			this.m_ChangeArmyText.enabled = false;
			this.m_ChangeArmyText.enabled = true;
		}
		if (this.m_ChangeArmyNumText != null && this.m_ChangeArmyNumText.enabled)
		{
			this.m_ChangeArmyNumText.enabled = false;
			this.m_ChangeArmyNumText.enabled = true;
		}
		for (int i = 0; i < 9; i++)
		{
			if (this.m_tmptext[i] != null && this.m_tmptext[i].enabled)
			{
				this.m_tmptext[i].enabled = false;
				this.m_tmptext[i].enabled = true;
			}
		}
		if (this.m_ScrollObj != null)
		{
			for (int j = 0; j < this.m_ScrollObj.Length; j++)
			{
				if (this.m_ScrollObj[j].PanelItem != null)
				{
					for (int k = 0; k < this.m_ScrollObj[j].PanelItem.Length; k++)
					{
						if (this.m_ScrollObj[j].PanelItem[k].HeroBtn != null && this.m_ScrollObj[j].PanelItem[k].HeroBtn.enabled)
						{
							this.m_ScrollObj[j].PanelItem[k].HeroBtn.Refresh_FontTexture();
						}
						if (this.m_ScrollObj[j].PanelItem[k].MaxNumText != null && this.m_ScrollObj[j].PanelItem[k].MaxNumText != null)
						{
							this.m_ScrollObj[j].PanelItem[k].MaxNumText.enabled = false;
							this.m_ScrollObj[j].PanelItem[k].MaxNumText.enabled = true;
						}
						if (this.m_ScrollObj[j].PanelItem[k].ArmsText != null && this.m_ScrollObj[j].PanelItem[k].ArmsText != null)
						{
							this.m_ScrollObj[j].PanelItem[k].ArmsText.enabled = false;
							this.m_ScrollObj[j].PanelItem[k].ArmsText.enabled = true;
						}
					}
				}
			}
		}
		if (this.m_HeroNameText != null && this.m_HeroNameText.enabled)
		{
			this.m_HeroNameText.enabled = false;
			this.m_HeroNameText.enabled = true;
		}
		if (this.m_HeroArmsText != null && this.m_HeroArmsText.enabled)
		{
			this.m_HeroArmsText.enabled = false;
			this.m_HeroArmsText.enabled = true;
		}
		if (this.m_HeroMaxNum != null && this.m_HeroMaxNum.enabled)
		{
			this.m_HeroMaxNum.enabled = false;
			this.m_HeroMaxNum.enabled = true;
		}
		if (this.m_SkliiNameText != null)
		{
			for (int l = 0; l < this.m_SkliiNameText.Length; l++)
			{
				if (this.m_SkliiNameText[l] != null && this.m_SkliiNameText[l].enabled)
				{
					this.m_SkliiNameText[l].enabled = false;
					this.m_SkliiNameText[l].enabled = true;
				}
			}
		}
		if (this.m_SkillInfoText != null)
		{
			for (int m = 0; m < this.m_SkillInfoText.Length; m++)
			{
				if (this.m_SkillInfoText[m] != null && this.m_SkillInfoText[m].enabled)
				{
					this.m_SkillInfoText[m].enabled = false;
					this.m_SkillInfoText[m].enabled = true;
				}
			}
		}
		if (this.m_HeroIcon)
		{
			this.m_HeroIcon.Refresh_FontTexture();
		}
		if (this.m_OriginaHIBtn)
		{
			this.m_OriginaHIBtn.Refresh_FontTexture();
		}
		if (this.m_ChangeHIBtn)
		{
			this.m_ChangeHIBtn.Refresh_FontTexture();
		}
	}

	// Token: 0x06001F0E RID: 7950 RVA: 0x003B9208 File Offset: 0x003B7408
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		int btnID2 = sender.m_BtnID3;
		if (sender.m_BtnID1 == 999)
		{
			if (this.door)
			{
				this.door.CloseMenu(false);
			}
		}
		else if (sender.m_BtnID1 == 998)
		{
			if (this.m_SelectHeroID != 0)
			{
				if (!this.bLordIsFight)
				{
					this.DM.SendChangeLord(this.m_SelectHeroID);
				}
				else
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(727u), 255, true);
				}
			}
		}
		else if (btnID >= 0 && btnID < 100 && btnID < this.m_Data.Count && btnID2 >= 0 && btnID2 < 2)
		{
			bool bIsFight = this.m_Data[btnID].Item[btnID2].bIsFight;
			bool bSelect = this.m_Data[btnID].Item[btnID2].bSelect;
			bool bIsLords = this.m_Data[btnID].Item[btnID2].bIsLords;
			if (!bIsFight)
			{
				if (!bIsLords)
				{
					ushort heroID = this.m_Data[btnID].Item[btnID2].HeroID;
					byte arms = this.m_Data[btnID].Item[btnID2].Arms;
					byte enhance = this.m_Data[btnID].Item[btnID2].Enhance;
					ushort maxNum = this.m_Data[btnID].Item[btnID2].MaxNum;
					byte star = this.m_Data[btnID].Item[btnID2].Star;
					byte lv = this.m_Data[btnID].Item[btnID2].Lv;
					if (!bSelect)
					{
						if (this.NowSelectIdx >= 0 && this.NowSelectIdx < this.m_Data.Count && this.NowLeft >= 0 && this.NowLeft < 2 && this.m_Data[this.NowSelectIdx].Item[this.NowLeft].bSelect)
						{
							this.m_Data[this.NowSelectIdx].Item[this.NowLeft].bSelect = false;
						}
						this.m_SelectHeroID = heroID;
						this.SetChangeLord(heroID, arms, enhance, maxNum, star, lv);
						this.m_Data[btnID].Item[btnID2].bSelect = true;
					}
					else
					{
						this.m_Data[btnID].Item[btnID2].bSelect = false;
						this.SetChangeLord(0, 0, 0, 0, 0, 0);
						this.m_SelectHeroID = 0;
					}
					this.NowSelectIdx = btnID;
					this.NowLeft = btnID2;
					this.UpdateScroll(false);
				}
				else
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(732u), 255, true);
				}
			}
			else
			{
				this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(708u), 255, true);
			}
		}
	}

	// Token: 0x06001F0F RID: 7951 RVA: 0x003B9580 File Offset: 0x003B7780
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		Transform[] array = new Transform[2];
		ScrollPanelItem component = item.transform.GetComponent<ScrollPanelItem>();
		component.m_BtnID1 = dataIdx;
		component.m_BtnID2 = panelObjectIdx;
		if (this.m_ScrollObj[panelObjectIdx].PanelItem[0].HeroBtn == null)
		{
			for (int i = 0; i < 2; i++)
			{
				array[i] = item.transform.GetChild(0).GetChild(i);
				UIButton component2 = array[i].GetComponent<UIButton>();
				component2.m_Handler = this;
				this.m_ScrollObj[panelObjectIdx].PanelItem[i].HeroBtn = array[i].GetChild(0).GetComponent<UIHIBtn>();
				UIButtonHint uibuttonHint = array[i].GetChild(0).gameObject.AddComponent<UIButtonHint>();
				uibuttonHint.m_Handler = this;
				uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.m_ScrollObj[panelObjectIdx].PanelItem[i].EnhanceIcon = array[i].GetChild(2).GetComponent<Image>();
				this.m_ScrollObj[panelObjectIdx].PanelItem[i].EnhanceIcon.material = this.GetEnhanceMat();
				this.m_ScrollObj[panelObjectIdx].PanelItem[i].ArmsIcons = array[i].GetChild(1).GetComponent<Image>();
				this.m_ScrollObj[panelObjectIdx].PanelItem[i].ArmsText = array[i].GetChild(3).GetComponent<UIText>();
				this.m_ScrollObj[panelObjectIdx].PanelItem[i].ArmsText.font = this.TTF;
				this.m_ScrollObj[panelObjectIdx].PanelItem[i].MaxNumText = array[i].GetChild(4).GetComponent<UIText>();
				this.m_ScrollObj[panelObjectIdx].PanelItem[i].MaxNumText.font = this.TTF;
				this.m_ScrollObj[panelObjectIdx].PanelItem[i].MaskImage = array[i].GetChild(5).GetComponent<Image>();
				this.m_ScrollObj[panelObjectIdx].PanelItem[i].SelectImage = array[i].GetChild(7).GetComponent<Image>();
				this.m_ScrollObj[panelObjectIdx].PanelItem[i].FightImage = array[i].GetChild(6).GetComponent<Image>();
				this.m_ScrollObj[panelObjectIdx].ItemTf1 = item.transform.GetChild(0).GetChild(0);
				this.m_ScrollObj[panelObjectIdx].ItemTf2 = item.transform.GetChild(0).GetChild(1);
				this.m_ScrollObj[panelObjectIdx].Line = item.transform.GetChild(0).GetChild(2);
				this.m_ScrollObj[panelObjectIdx].FinalText = item.transform.GetChild(0).GetChild(3);
				UIText component3 = this.m_ScrollObj[panelObjectIdx].Line.GetChild(0).GetComponent<UIText>();
				component3.font = this.TTF;
			}
		}
		for (int j = 0; j < 2; j++)
		{
			array[j] = item.transform.GetChild(0).GetChild(j);
			this.m_Data[dataIdx].panelObjectIdx = panelObjectIdx;
			if (this.m_Data[dataIdx].Item[j].Type == 1)
			{
				this.m_ScrollObj[panelObjectIdx].Line.gameObject.SetActive(true);
				this.m_ScrollObj[panelObjectIdx].FinalText.gameObject.SetActive(false);
				this.m_ScrollObj[panelObjectIdx].ItemTf1.gameObject.SetActive(false);
				this.m_ScrollObj[panelObjectIdx].ItemTf2.gameObject.SetActive(false);
			}
			else
			{
				this.m_ScrollObj[panelObjectIdx].Line.gameObject.SetActive(false);
				this.m_ScrollObj[panelObjectIdx].FinalText.gameObject.SetActive(false);
				this.m_ScrollObj[panelObjectIdx].ItemTf1.gameObject.SetActive(true);
				this.m_ScrollObj[panelObjectIdx].ItemTf2.gameObject.SetActive(true);
				if (this.m_Data[dataIdx].Item[j].Enable)
				{
					if (!array[j].gameObject.activeSelf)
					{
						array[j].gameObject.SetActive(true);
					}
					uint heroID = (uint)this.m_Data[dataIdx].Item[j].HeroID;
					if (j == 0)
					{
						GameObject gameObject = item.transform.GetChild(0).GetChild(0).GetChild(8).gameObject;
						if (heroID == (uint)this.DM.GetLeaderID())
						{
							gameObject.SetActive(true);
						}
						else
						{
							gameObject.SetActive(false);
						}
					}
					UIButton component2 = array[j].GetComponent<UIButton>();
					component2.m_BtnID1 = dataIdx;
					component2.m_BtnID2 = panelObjectIdx;
					component2.m_BtnID3 = j;
					this.GM.ChangeHeroItemImg(this.m_ScrollObj[panelObjectIdx].PanelItem[j].HeroBtn.transform, eHeroOrItem.Hero, (ushort)heroID, this.m_Data[dataIdx].Item[j].Star, 0, (int)this.m_Data[dataIdx].Item[j].Lv);
					this.m_ScrollObj[panelObjectIdx].PanelItem[j].EnhanceIcon.sprite = this.GetEnhanceIcon(this.m_Data[dataIdx].Item[j].Enhance);
					this.m_ScrollObj[panelObjectIdx].PanelItem[j].ArmsIcons.sprite = this.GetArmsIcon(this.m_Data[dataIdx].Item[j].Arms);
					this.m_ScrollObj[panelObjectIdx].PanelItem[j].ArmsText = array[j].GetChild(3).GetComponent<UIText>();
					this.m_ScrollObj[panelObjectIdx].PanelItem[j].ArmsText.text = this.GetArmsStr(this.m_Data[dataIdx].Item[j].Arms);
					this.m_ScrollObj[panelObjectIdx].PanelItem[j].MaxNumText = array[j].GetChild(4).GetComponent<UIText>();
					if (this.m_ScrollObj[panelObjectIdx].PanelItem[j].MaxNumStr == null)
					{
						this.m_ScrollObj[panelObjectIdx].PanelItem[j].MaxNumStr = StringManager.Instance.SpawnString(30);
					}
					this.m_ScrollObj[panelObjectIdx].PanelItem[j].MaxNumStr.ClearString();
					StringManager.Instance.IntToFormat((long)this.m_Data[dataIdx].Item[j].MaxNum, 1, true);
					this.m_ScrollObj[panelObjectIdx].PanelItem[j].MaxNumStr.AppendFormat("{0}");
					this.m_ScrollObj[panelObjectIdx].PanelItem[j].MaxNumText.text = this.m_ScrollObj[panelObjectIdx].PanelItem[j].MaxNumStr.ToString();
					this.m_ScrollObj[panelObjectIdx].PanelItem[j].MaxNumText.SetAllDirty();
					this.m_ScrollObj[panelObjectIdx].PanelItem[j].MaxNumText.cachedTextGenerator.Invalidate();
					if (this.m_Data[dataIdx].Item[j].bSelect || this.m_Data[dataIdx].Item[j].bIsFight || this.m_Data[dataIdx].Item[j].bIsLords)
					{
						this.m_ScrollObj[panelObjectIdx].PanelItem[j].MaskImage.enabled = true;
						if (this.m_Data[dataIdx].Item[j].bSelect && this.m_Data[dataIdx].Item[j].bIsFight)
						{
							this.m_ScrollObj[panelObjectIdx].PanelItem[j].SelectImage.enabled = true;
							this.m_ScrollObj[panelObjectIdx].PanelItem[j].FightImage.enabled = true;
						}
						else if (this.m_Data[dataIdx].Item[j].bSelect && !this.m_Data[dataIdx].Item[j].bIsFight && !this.m_Data[dataIdx].Item[j].bIsLords)
						{
							this.m_ScrollObj[panelObjectIdx].PanelItem[j].SelectImage.enabled = true;
							this.m_ScrollObj[panelObjectIdx].PanelItem[j].FightImage.enabled = false;
						}
						else if (this.m_Data[dataIdx].Item[j].bIsFight && !this.m_Data[dataIdx].Item[j].bSelect && !this.m_Data[dataIdx].Item[j].bIsLords)
						{
							this.m_ScrollObj[panelObjectIdx].PanelItem[j].FightImage.enabled = true;
							this.m_ScrollObj[panelObjectIdx].PanelItem[j].SelectImage.enabled = false;
						}
						else if (this.m_Data[dataIdx].Item[j].bIsLords && !this.m_Data[dataIdx].Item[j].bSelect && !this.m_Data[dataIdx].Item[j].bIsFight)
						{
							this.m_ScrollObj[panelObjectIdx].PanelItem[j].FightImage.enabled = false;
							this.m_ScrollObj[panelObjectIdx].PanelItem[j].SelectImage.enabled = false;
						}
						else if (this.m_Data[dataIdx].Item[j].bIsLords && this.m_Data[dataIdx].Item[j].bIsFight && !this.m_Data[dataIdx].Item[j].bSelect)
						{
							this.m_ScrollObj[panelObjectIdx].PanelItem[j].FightImage.enabled = true;
							this.m_ScrollObj[panelObjectIdx].PanelItem[j].SelectImage.enabled = false;
						}
					}
					else
					{
						this.m_ScrollObj[panelObjectIdx].PanelItem[j].MaskImage.enabled = false;
						this.m_ScrollObj[panelObjectIdx].PanelItem[j].SelectImage.enabled = false;
						this.m_ScrollObj[panelObjectIdx].PanelItem[j].FightImage.enabled = false;
					}
				}
				else if (array[j].gameObject.activeSelf)
				{
					array[j].gameObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x06001F10 RID: 7952 RVA: 0x003BA23C File Offset: 0x003B843C
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001F11 RID: 7953 RVA: 0x003BA240 File Offset: 0x003B8440
	private void SetData(ushort SelectHeroID = 0)
	{
		SoldierScrollItem soldierScrollItem = null;
		ushort leaderID = this.DM.GetLeaderID();
		this.m_Data.Clear();
		this.bLordIsFight = false;
		int num = 0;
		while ((long)num < (long)((ulong)this.DM.NonFightHeroCount))
		{
			int num2 = num % 2;
			uint num3 = this.DM.SortNonFightHeroID[num];
			if (num2 == 0)
			{
				soldierScrollItem = this.GM.m_HeroList_Soldier_ItemDataPool2.spawn();
				soldierScrollItem.Item[0].Enable = false;
				soldierScrollItem.Item[0].Type = 0;
				soldierScrollItem.Item[1].Enable = false;
				soldierScrollItem.Item[1].Type = 0;
				soldierScrollItem.Item[0].HeroID = 0;
				soldierScrollItem.Item[1].HeroID = 0;
				soldierScrollItem.Item[0].bIsLords = false;
				soldierScrollItem.Item[1].bIsLords = false;
			}
			soldierScrollItem.Height = 80f;
			if (DataManager.Instance.curHeroData.ContainsKey(num3))
			{
				Hero recordByKey = this.DM.HeroTable.GetRecordByKey((ushort)num3);
				soldierScrollItem.Item[num2].HeroID = (ushort)num3;
				soldierScrollItem.Item[num2].Enable = true;
				CurHeroData curHeroData = DataManager.Instance.curHeroData[num3];
				soldierScrollItem.Item[num2].Lv = curHeroData.Level;
				soldierScrollItem.Item[num2].Enhance = curHeroData.Enhance;
				soldierScrollItem.Item[num2].Arms = recordByKey.SoldierKind;
				soldierScrollItem.Item[num2].Star = curHeroData.Star;
				soldierScrollItem.Item[num2].MaxNum = this.DM.RankSoldiers[(int)curHeroData.Enhance];
				soldierScrollItem.Item[num2].bIsLords = false;
				soldierScrollItem.Item[num2].bSelect = false;
				soldierScrollItem.Item[num2].bIsFight = false;
				soldierScrollItem.Item[num2].Type = 0;
				if (num3 == (uint)leaderID)
				{
					soldierScrollItem.Item[num2].bIsLords = true;
					this.SetOriginalLord((ushort)num3, soldierScrollItem.Item[num2].Arms, soldierScrollItem.Item[num2].Enhance, soldierScrollItem.Item[num2].MaxNum, soldierScrollItem.Item[num2].Star, soldierScrollItem.Item[num2].Lv);
				}
				if ((uint)SelectHeroID == num3)
				{
					soldierScrollItem.Item[num2].bSelect = true;
					this.SetChangeLord((ushort)num3, soldierScrollItem.Item[num2].Arms, soldierScrollItem.Item[num2].Enhance, soldierScrollItem.Item[num2].MaxNum, soldierScrollItem.Item[num2].Star, soldierScrollItem.Item[num2].Lv);
					this.NowSelectIdx = this.m_Data.Count;
					this.NowLeft = num2;
				}
				if (num2 == 1 || (long)num == (long)((ulong)(this.DM.NonFightHeroCount - 1u)))
				{
					this.m_Data.Add(soldierScrollItem);
				}
			}
			else if (num2 == 1 || (long)num == (long)((ulong)(this.DM.NonFightHeroCount - 1u)))
			{
				this.GM.m_HeroList_Soldier_ItemDataPool2.despawn(soldierScrollItem);
			}
			num++;
		}
		if (this.DM.FightHeroCount > 0u)
		{
			soldierScrollItem = this.GM.m_HeroList_Soldier_ItemDataPool2.spawn();
			soldierScrollItem.Item[0].Type = 1;
			soldierScrollItem.Item[1].Type = 1;
			soldierScrollItem.Item[0].HeroID = 0;
			soldierScrollItem.Item[1].HeroID = 0;
			soldierScrollItem.Item[0].Enable = true;
			soldierScrollItem.Item[1].Enable = true;
			soldierScrollItem.Item[0].bIsLords = false;
			soldierScrollItem.Item[1].bIsLords = false;
			soldierScrollItem.Height = 50f;
			this.m_Data.Add(soldierScrollItem);
		}
		int num4 = 0;
		while ((long)num4 < (long)((ulong)this.DM.FightHeroCount))
		{
			int num2 = num4 % 2;
			uint num3 = this.DM.SortFightHeroID[num4];
			if (num2 == 0)
			{
				soldierScrollItem = this.GM.m_HeroList_Soldier_ItemDataPool2.spawn();
				soldierScrollItem.Item[0].Enable = false;
				soldierScrollItem.Item[0].Type = 0;
				soldierScrollItem.Item[1].Enable = false;
				soldierScrollItem.Item[1].Type = 0;
				soldierScrollItem.Item[0].HeroID = 0;
				soldierScrollItem.Item[1].HeroID = 0;
				soldierScrollItem.Item[0].bIsLords = false;
				soldierScrollItem.Item[1].bIsLords = false;
			}
			soldierScrollItem.Item[num2].Type = 0;
			soldierScrollItem.Item[num2].HeroID = (ushort)num3;
			soldierScrollItem.Height = 80f;
			if (DataManager.Instance.curHeroData.ContainsKey(num3))
			{
				soldierScrollItem.Item[num2].HeroID = (ushort)num3;
				Hero recordByKey = this.DM.HeroTable.GetRecordByKey((ushort)num3);
				soldierScrollItem.Item[num2].Enable = true;
				CurHeroData curHeroData = DataManager.Instance.curHeroData[num3];
				soldierScrollItem.Item[num2].Lv = curHeroData.Level;
				soldierScrollItem.Item[num2].Enhance = curHeroData.Enhance;
				soldierScrollItem.Item[num2].Arms = recordByKey.SoldierKind;
				soldierScrollItem.Item[num2].Star = curHeroData.Star;
				soldierScrollItem.Item[num2].MaxNum = this.DM.RankSoldiers[(int)curHeroData.Enhance];
				soldierScrollItem.Item[num2].bIsLords = false;
				soldierScrollItem.Item[num2].bSelect = false;
				soldierScrollItem.Item[num2].bIsFight = true;
				soldierScrollItem.Item[num2].Type = 0;
				if (num3 == (uint)leaderID)
				{
					this.bLordIsFight = true;
					soldierScrollItem.Item[num2].bIsLords = true;
					this.m_OriginaHIBtn.gameObject.SetActive(true);
					this.SetOriginalLord((ushort)num3, soldierScrollItem.Item[num2].Arms, soldierScrollItem.Item[num2].Enhance, soldierScrollItem.Item[num2].MaxNum, soldierScrollItem.Item[num2].Star, soldierScrollItem.Item[num2].Lv);
				}
				if (num2 == 1 || (long)num4 == (long)((ulong)(this.DM.FightHeroCount - 1u)))
				{
					this.m_Data.Add(soldierScrollItem);
				}
			}
			else if (num2 == 1 || (long)num4 == (long)((ulong)(this.DM.FightHeroCount - 1u)))
			{
				this.GM.m_HeroList_Soldier_ItemDataPool2.despawn(soldierScrollItem);
			}
			num4++;
		}
	}

	// Token: 0x06001F12 RID: 7954 RVA: 0x003BA9EC File Offset: 0x003B8BEC
	private void UpdateScroll(bool bMoveToFirst = false)
	{
		List<float> list = new List<float>();
		for (int i = 0; i < this.m_Data.Count; i++)
		{
			list.Add(this.m_Data[i].Height);
		}
		this.m_ScrollPanel.AddNewDataHeight(list, bMoveToFirst, true);
	}

	// Token: 0x06001F13 RID: 7955 RVA: 0x003BAA40 File Offset: 0x003B8C40
	private Sprite GetEnhanceIcon(byte Enhance)
	{
		this.m_SpriteStr.ClearString();
		StringManager.Instance.IntToFormat((long)(Enhance + 100), 1, false);
		this.m_SpriteStr.AppendFormat("hf{0}");
		return GUIManager.Instance.LoadSprite("UI_frame", this.m_SpriteStr);
	}

	// Token: 0x06001F14 RID: 7956 RVA: 0x003BAA90 File Offset: 0x003B8C90
	private Material GetEnhanceMat()
	{
		return GUIManager.Instance.GetFrameMaterial();
	}

	// Token: 0x06001F15 RID: 7957 RVA: 0x003BAA9C File Offset: 0x003B8C9C
	private Sprite GetArmsIcon(byte arms)
	{
		return this.m_SpritesArray.GetSprite((int)arms);
	}

	// Token: 0x06001F16 RID: 7958 RVA: 0x003BAAAC File Offset: 0x003B8CAC
	private string GetArmsStr(byte arms)
	{
		return DataManager.Instance.mStringTable.GetStringByID(3841u + (uint)arms);
	}

	// Token: 0x06001F17 RID: 7959 RVA: 0x003BAAC4 File Offset: 0x003B8CC4
	private void SetOriginalLord(ushort HeroID, byte Arms, byte enhance, ushort MaxNum, byte Star, byte Level)
	{
		Hero recordByKey = this.DM.HeroTable.GetRecordByKey(HeroID);
		this.GM.ChangeHeroItemImg(this.m_OriginaHIBtn.transform, eHeroOrItem.Hero, HeroID, Star, enhance, (int)Level);
		this.m_OriginaIcon1.sprite = this.GetArmsIcon(Arms);
		this.m_OriginaIcon2.sprite = this.GetEnhanceIcon(enhance);
		this.m_OriginaIcon2.material = this.GetEnhanceMat();
		this.m_OriginaName.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.HeroTitle);
		this.m_OriginaArmyText.text = this.GetArmsStr(Arms);
		this.m_OriginaArmyNumStr.ClearString();
		this.m_OriginaArmyNumStr.IntToFormat((long)MaxNum, 1, true);
		this.m_OriginaArmyNumStr.AppendFormat("{0}");
		this.m_OriginaArmyNumText.text = this.m_OriginaArmyNumStr.ToString();
	}

	// Token: 0x06001F18 RID: 7960 RVA: 0x003BABAC File Offset: 0x003B8DAC
	private void SetChangeLord(ushort HeroID, byte Arms, byte enhance, ushort MaxNum, byte Star, byte Level)
	{
		ushort leaderID = this.DM.GetLeaderID();
		if (leaderID == HeroID || HeroID == 0)
		{
			this.m_ChangeHIBtn.gameObject.SetActive(false);
			this.m_ChangeIcon1.enabled = false;
			this.m_ChangeIcon2.enabled = false;
			this.m_ChangeName.enabled = false;
			this.m_ChangeArmyText.enabled = false;
			this.m_ChangeArmyNumText.enabled = false;
		}
		else
		{
			this.m_ChangeHIBtn.gameObject.SetActive(true);
			this.m_ChangeIcon1.enabled = true;
			this.m_ChangeIcon2.enabled = true;
			this.m_ChangeName.enabled = true;
			this.m_ChangeArmyText.enabled = true;
			this.m_ChangeArmyNumText.enabled = true;
			Hero recordByKey = this.DM.HeroTable.GetRecordByKey(HeroID);
			this.GM.ChangeHeroItemImg(this.m_ChangeHIBtn.transform, eHeroOrItem.Hero, HeroID, Star, enhance, (int)Level);
			this.m_ChangeIcon1.sprite = this.GetArmsIcon(Arms);
			this.m_ChangeIcon2.sprite = this.GetEnhanceIcon(enhance);
			this.m_ChangeIcon2.material = this.GetEnhanceMat();
			this.m_ChangeName.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.HeroTitle);
			this.m_ChangeArmyText.text = this.GetArmsStr(Arms);
			this.m_ChangeArmyNumStr.ClearString();
			this.m_ChangeArmyNumStr.IntToFormat((long)MaxNum, 1, true);
			this.m_ChangeArmyNumStr.AppendFormat("{0}");
			this.m_ChangeArmyNumText.text = this.m_ChangeArmyNumStr.ToString();
			this.m_ChangeArmyNumText.SetAllDirty();
			this.m_ChangeArmyNumText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06001F19 RID: 7961 RVA: 0x003BAD68 File Offset: 0x003B8F68
	private void Despawn()
	{
		for (int i = this.m_Data.Count - 1; i >= 0; i--)
		{
			this.m_Data[i].Item[0].Type = 0;
			this.m_Data[i].Item[1].Type = 0;
			this.GM.m_HeroList_Soldier_ItemDataPool2.despawn(this.m_Data[i]);
		}
	}

	// Token: 0x06001F1A RID: 7962 RVA: 0x003BADEC File Offset: 0x003B8FEC
	private void SetSkillHint(ushort heroID, byte enhance, int MaxNum, byte Arms)
	{
		byte[] array = new byte[]
		{
			1,
			2,
			4,
			8,
			20
		};
		Hero recordByKey = this.DM.HeroTable.GetRecordByKey(heroID);
		ushort[] array2 = new ushort[]
		{
			recordByKey.GroupSkill1,
			recordByKey.GroupSkill2,
			recordByKey.GroupSkill3,
			recordByKey.GroupSkill4
		};
		CurHeroData curHeroData = this.DM.curHeroData[(uint)heroID];
		this.GM.ChangeHeroItemImg(this.m_HeroIcon.transform, eHeroOrItem.Hero, heroID, curHeroData.Star, 0, 0);
		this.m_HeroNameText.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.HeroTitle);
		this.m_HeroArmsText.text = this.GetArmsStr(Arms);
		this.m_HeroEnhanceIcon.sprite = this.GetEnhanceIcon(enhance);
		this.m_HeroMaxNumStr.ClearString();
		StringManager.Instance.IntToFormat((long)MaxNum, 1, true);
		this.m_HeroMaxNumStr.AppendFormat("{0}");
		this.m_HeroMaxNum.text = this.m_HeroMaxNumStr.ToString();
		for (int i = 0; i < 4; i++)
		{
			Skill recordByKey2 = this.DM.SkillTable.GetRecordByKey(array2[i]);
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring.IntToFormat((long)recordByKey2.SkillIcon, 5, false);
			cstring.AppendFormat("s{0}");
			this.m_SkillImage[i].sprite = this.GM.LoadSkillSprite(cstring);
			this.m_SkillImage[i].material = this.GM.GetSkillMaterial();
			this.m_SkillFrame[i].sprite = this.GM.LoadFrameSprite("sk");
			this.m_SkillFrame[i].material = this.GM.GetFrameMaterial();
			this.m_SkliiNameText[i].text = this.DM.mStringTable.GetStringByID((uint)recordByKey2.SkillName);
			this.m_SkillInfoStr[i].ClearString();
			float num = (float)recordByKey2.HurtValue + (float)((ushort)array[(int)(curHeroData.Star - 1)] * recordByKey2.HurtIncreaseValue) / 1000f;
			if (recordByKey2.HurtKind == 1)
			{
				GameConstants.GetEffectValue(this.m_SkillInfoStr[i], recordByKey2.HurtAddition, 0u, 7, 0f);
				this.m_SkillInfoStr[i].IntToFormat((long)((ushort)array[(int)(curHeroData.Star - 1)] * recordByKey2.HurtIncreaseValue), 1, false);
				this.m_SkillInfoStr[i].AppendFormat("{0}");
				this.m_SkillInfoText[i].text = this.m_SkillInfoStr[i].ToString();
			}
			else
			{
				if (recordByKey2.SkillType == 10)
				{
					GameConstants.GetEffectValue(this.m_SkillInfoStr[i], recordByKey2.HurtAddition, (uint)num, 1, 0f);
				}
				else
				{
					GameConstants.GetEffectValue(this.m_SkillInfoStr[i], recordByKey2.HurtAddition, 0u, 6, num * 100f);
				}
				this.m_SkillInfoText[i].text = this.m_SkillInfoStr[i].ToString();
			}
			if (curHeroData.SkillLV[i] == 0)
			{
				this.SetMaskColor(i, true);
				this.m_SkillMaskTf[i].gameObject.SetActive(true);
			}
			else
			{
				this.SetMaskColor(i, false);
				this.m_SkillMaskTf[i].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001F1B RID: 7963 RVA: 0x003BB16C File Offset: 0x003B936C
	private void SetMaskColor(int idx, bool bDarkColor)
	{
		Color color = new Color(0.5f, 0.5f, 0.5f, 1f);
		Color color2 = new Color(1f, 1f, 1f, 1f);
		if (bDarkColor)
		{
			this.m_SkillImage[idx].color = color;
			this.m_SkillFrame[idx].color = color;
			this.m_SkliiNameText[idx].color = color;
			this.m_SkillInfoText[idx].color = color;
		}
		else
		{
			this.m_SkillImage[idx].color = color2;
			this.m_SkillFrame[idx].color = color2;
			this.m_SkliiNameText[idx].color = color2;
			this.m_SkillInfoText[idx].color = color2;
		}
	}

	// Token: 0x06001F1C RID: 7964 RVA: 0x003BB22C File Offset: 0x003B942C
	public void OnButtonDown(UIButtonHint sender)
	{
		int btnID = sender.transform.parent.GetComponent<UIButton>().m_BtnID1;
		int btnID2 = sender.transform.parent.GetComponent<UIButton>().m_BtnID3;
		ushort heroID = this.m_Data[btnID].Item[btnID2].HeroID;
		byte enhance = this.m_Data[btnID].Item[btnID2].Enhance;
		int maxNum = (int)this.m_Data[btnID].Item[btnID2].MaxNum;
		byte arms = this.m_Data[btnID].Item[btnID2].Arms;
		this.SetSkillHint(heroID, enhance, maxNum, arms);
		this.m_SkillHintPanel.gameObject.SetActive(true);
	}

	// Token: 0x06001F1D RID: 7965 RVA: 0x003BB2F8 File Offset: 0x003B94F8
	public void OnButtonUp(UIButtonHint sender)
	{
		sender.bCountDown = false;
		sender.m_Time = 0f;
		this.m_SkillHintPanel.gameObject.SetActive(false);
	}

	// Token: 0x04006294 RID: 25236
	private const int m_MaxPanelObject = 8;

	// Token: 0x04006295 RID: 25237
	private const int TextMax = 9;

	// Token: 0x04006296 RID: 25238
	private GUIManager GM;

	// Token: 0x04006297 RID: 25239
	private DataManager DM;

	// Token: 0x04006298 RID: 25240
	private Door door;

	// Token: 0x04006299 RID: 25241
	private Font TTF;

	// Token: 0x0400629A RID: 25242
	private List<SoldierScrollItem> m_Data;

	// Token: 0x0400629B RID: 25243
	private UIHIBtn m_OriginaHIBtn;

	// Token: 0x0400629C RID: 25244
	private UIHIBtn m_ChangeHIBtn;

	// Token: 0x0400629D RID: 25245
	private Image m_OriginaIcon1;

	// Token: 0x0400629E RID: 25246
	private Image m_OriginaIcon2;

	// Token: 0x0400629F RID: 25247
	private Image m_ChangeIcon1;

	// Token: 0x040062A0 RID: 25248
	private Image m_ChangeIcon2;

	// Token: 0x040062A1 RID: 25249
	private UIText m_OriginaName;

	// Token: 0x040062A2 RID: 25250
	private UIText m_OriginaArmyText;

	// Token: 0x040062A3 RID: 25251
	private UIText m_OriginaArmyNumText;

	// Token: 0x040062A4 RID: 25252
	private UIText m_ChangeName;

	// Token: 0x040062A5 RID: 25253
	private UIText m_ChangeArmyText;

	// Token: 0x040062A6 RID: 25254
	private UIText m_ChangeArmyNumText;

	// Token: 0x040062A7 RID: 25255
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040062A8 RID: 25256
	private UISpritesArray m_SpritesArray;

	// Token: 0x040062A9 RID: 25257
	private Transform m_SkillHintPanel;

	// Token: 0x040062AA RID: 25258
	private Transform[] m_SkillMaskTf;

	// Token: 0x040062AB RID: 25259
	private UIText m_HeroNameText;

	// Token: 0x040062AC RID: 25260
	private UIText m_HeroArmsText;

	// Token: 0x040062AD RID: 25261
	private UIText m_HeroMaxNum;

	// Token: 0x040062AE RID: 25262
	private Image m_HeroEnhanceIcon;

	// Token: 0x040062AF RID: 25263
	private UIHIBtn m_HeroIcon;

	// Token: 0x040062B0 RID: 25264
	private UIText[] m_SkliiNameText;

	// Token: 0x040062B1 RID: 25265
	private UIText[] m_SkillInfoText;

	// Token: 0x040062B2 RID: 25266
	private Image[] m_SkillImage;

	// Token: 0x040062B3 RID: 25267
	private Image[] m_SkillFrame;

	// Token: 0x040062B4 RID: 25268
	private ScrollPanelObject[] m_ScrollObj;

	// Token: 0x040062B5 RID: 25269
	private int NowSelectIdx;

	// Token: 0x040062B6 RID: 25270
	private int NowLeft;

	// Token: 0x040062B7 RID: 25271
	private ushort m_SelectHeroID;

	// Token: 0x040062B8 RID: 25272
	private bool bLordIsFight;

	// Token: 0x040062B9 RID: 25273
	private CString m_SpriteStr;

	// Token: 0x040062BA RID: 25274
	private CString m_OriginaArmyNumStr;

	// Token: 0x040062BB RID: 25275
	private CString m_ChangeArmyNumStr;

	// Token: 0x040062BC RID: 25276
	private CString m_HeroMaxNumStr;

	// Token: 0x040062BD RID: 25277
	private CString[] m_SkillInfoStr;

	// Token: 0x040062BE RID: 25278
	private int mTextCount;

	// Token: 0x040062BF RID: 25279
	private UIText[] m_tmptext = new UIText[9];
}
