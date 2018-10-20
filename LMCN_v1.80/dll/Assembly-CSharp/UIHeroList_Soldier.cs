using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000591 RID: 1425
public class UIHeroList_Soldier : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06001C30 RID: 7216 RVA: 0x0031C2AC File Offset: 0x0031A4AC
	public override void OnOpen(int arg1, int arg2)
	{
		this.sb = new StringBuilder();
		GUIManager.Instance.AddSpriteAsset("UIExpedition");
		GUIManager.Instance.AddSpriteAsset("UI_frame");
		this.m_TitleText = base.transform.GetChild(18).GetChild(0).GetComponent<Text>();
		this.m_TitleText.text = DataManager.Instance.mStringTable.GetStringByID(339u);
		this.m_TitleText.font = GUIManager.Instance.GetTTFFont();
		this.m_InfoPanel = base.transform.GetChild(15);
		Transform child = this.m_InfoPanel.GetChild(3);
		this.m_OKBtn = child.GetComponent<UIButton>();
		this.m_OKBtn.m_BtnID1 = 1;
		this.m_OKBtn.m_Handler = this;
		this.m_OKLoadBg = child.GetChild(0).GetComponent<Image>();
		this.m_OKLoadBg.material = this.GetArmsMat();
		this.m_OKLoadBg.sprite = GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_13");
		this.m_OKLoadFlash = child.GetChild(1).GetComponent<Image>();
		this.m_OKLoadFlash.material = this.GetArmsMat();
		this.m_OKLoadFlash.sprite = GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_12");
		this.m_OKBtnText1Rt = child.GetChild(2).GetComponent<RectTransform>();
		this.m_OKBtnText1 = child.GetChild(2).GetComponent<Text>();
		this.m_OKBtnText1.font = GUIManager.Instance.GetTTFFont();
		this.m_OKBtnText1.text = DataManager.Instance.mStringTable.GetStringByID(3u);
		this.m_OKBtnText2 = child.GetChild(3).GetComponent<Text>();
		this.m_OKBtnText2.font = GUIManager.Instance.GetTTFFont();
		this.m_OKBtnText2.text = "領主在軍團中";
		child = base.transform.GetChild(13);
		this.m_ExitBtn = child.GetChild(0).GetComponent<UIButton>();
		this.m_ExitBtn.m_BtnID1 = 2;
		this.m_ExitBtn.m_Handler = this;
		this.m_SoldierCountText = this.m_InfoPanel.GetChild(0).GetChild(1).GetComponent<Text>();
		this.m_SoldierCountText.font = GUIManager.Instance.GetTTFFont();
		this.m_SoldierCountText.text = DataManager.Instance.LegionBattleSildoers.ToString();
		DataManager.Instance.LegionBattleHero.Clear();
		DataManager.Instance.LegionBattleSildoers = 0;
		this.m_SoldierValueCount = base.transform.GetChild(15).GetChild(2).GetChild(1).GetComponent<Text>();
		this.m_SoldierCountText.font = GUIManager.Instance.GetTTFFont();
		this.m_SoldierValueCount.font = GUIManager.Instance.GetTTFFont();
		this.sb.Length = 0;
		this.sb.AppendFormat("{0}/{1}", 0, this.MaxSelectHero);
		this.m_SoldierValueCount.text = this.sb.ToString();
		this.m_ScrollPanel = base.transform.GetChild(14).GetComponent<ScrollPanel>();
		child = base.transform.GetChild(20).GetChild(0);
		UIButtonHint uibuttonHint = child.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		child.GetComponent<UIButton>().m_BtnID1 = 98;
		child.GetComponent<UIButton>().m_Handler = this;
		this.m_HiBtn1 = child.GetChild(0);
		GUIManager.Instance.InitianHeroItemImg(this.m_HiBtn1, eHeroOrItem.Hero, 1, 1, 1, 1, false, false, true, false);
		Text component = child.GetChild(3).GetComponent<Text>();
		component.font = GUIManager.Instance.GetTTFFont();
		component = child.GetChild(4).GetComponent<Text>();
		component.font = GUIManager.Instance.GetTTFFont();
		child = base.transform.GetChild(20).GetChild(1);
		uibuttonHint = child.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		child.GetComponent<UIButton>().m_BtnID1 = 99;
		child.GetComponent<UIButton>().m_Handler = this;
		this.m_HiBtn2 = child.GetChild(0);
		GUIManager.Instance.InitianHeroItemImg(this.m_HiBtn2, eHeroOrItem.Hero, 1, 1, 1, 1, false, false, true, false);
		component = child.GetChild(3).GetComponent<Text>();
		component.font = GUIManager.Instance.GetTTFFont();
		component = child.GetChild(4).GetComponent<Text>();
		component.font = GUIManager.Instance.GetTTFFont();
		child = base.transform.GetChild(16);
		this.m_SortBtn = child.GetComponent<UIButton>();
		this.m_SortBtn.m_BtnID1 = 8;
		this.m_SortBtn.m_Handler = this;
		this.m_SortBtnText = child.GetChild(0).GetComponent<Text>();
		this.m_SortBtnText.font = GUIManager.Instance.GetTTFFont();
		this.m_SortBtnText.text = DataManager.Instance.mStringTable.GetStringByID(343u);
		child = base.transform.GetChild(17);
		this.m_AutoBtn = child.GetComponent<UIButton>();
		this.m_AutoBtn.m_BtnID1 = 9;
		this.m_AutoBtn.m_Handler = this;
		component = child.GetChild(0).GetComponent<Text>();
		component.font = GUIManager.Instance.GetTTFFont();
		component.text = DataManager.Instance.mStringTable.GetStringByID(340u);
		this.m_SortPanel = base.transform.GetChild(19);
		for (int i = 0; i < 5; i++)
		{
			child = this.m_SortPanel.GetChild(i);
			UIButton component2 = child.GetComponent<UIButton>();
			component2.m_BtnID1 = 3 + i;
			component2.m_Handler = this;
			component = child.GetChild(0).GetComponent<Text>();
			component.font = GUIManager.Instance.GetTTFFont();
			component.text = DataManager.Instance.mStringTable.GetStringByID(this.m_SrotStrIDs[i]);
		}
		child = base.transform.GetChild(20).GetChild(3);
		component = child.GetChild(0).GetComponent<Text>();
		component.font = GUIManager.Instance.GetTTFFont();
		component.text = DataManager.Instance.mStringTable.GetStringByID(338u);
		component = child.GetChild(1).GetComponent<Text>();
		component.font = GUIManager.Instance.GetTTFFont();
		component.text = DataManager.Instance.mStringTable.GetStringByID(339u);
		child = base.transform.GetChild(20).GetChild(2);
		component = child.GetChild(0).GetComponent<Text>();
		component.font = GUIManager.Instance.GetTTFFont();
		component.text = DataManager.Instance.mStringTable.GetStringByID(339u);
		this.m_SkillPanel = base.transform.GetChild(21);
		this.m_SkillHero = this.m_SkillPanel.GetChild(0).GetChild(1).GetComponent<UIHIBtn>();
		this.m_SkillBtn1 = this.m_SkillPanel.GetChild(1).GetChild(1).GetComponent<UIHIBtn>();
		this.m_SkillBtn2 = this.m_SkillPanel.GetChild(2).GetChild(1).GetComponent<UIHIBtn>();
		this.m_SkillBtn3 = this.m_SkillPanel.GetChild(3).GetChild(1).GetComponent<UIHIBtn>();
		this.m_SkillBtn4 = this.m_SkillPanel.GetChild(4).GetChild(1).GetComponent<UIHIBtn>();
		this.m_SkillEnhance = this.m_SkillPanel.GetChild(0).GetChild(2).GetComponent<Image>();
		this.m_SkillEnhance.material = this.GetEnhanceMat();
		this.m_SkillEnhance.sprite = this.GetEnhanceIcon(1);
		GUIManager.Instance.InitianHeroItemImg(this.m_SkillHero.transform, eHeroOrItem.Hero, 1, 1, 1, 1, false, false, true, false);
		GUIManager.Instance.InitianHeroItemImg(this.m_SkillBtn1.transform, eHeroOrItem.Hero, 1, 1, 1, 1, false, false, true, false);
		GUIManager.Instance.InitianHeroItemImg(this.m_SkillBtn2.transform, eHeroOrItem.Hero, 1, 1, 1, 1, false, false, true, false);
		GUIManager.Instance.InitianHeroItemImg(this.m_SkillBtn3.transform, eHeroOrItem.Hero, 1, 1, 1, 1, false, false, true, false);
		GUIManager.Instance.InitianHeroItemImg(this.m_SkillBtn4.transform, eHeroOrItem.Hero, 1, 1, 1, 1, false, false, true, false);
		this.m_MaxPanelObject = 8;
		this.m_ItemHIBtns1 = new UIHIBtn[this.m_MaxPanelObject];
		this.m_ItemArmsTexts1 = new Text[this.m_MaxPanelObject];
		this.m_ItemNumTexts1 = new Text[this.m_MaxPanelObject];
		this.m_ItemHIBtns2 = new UIHIBtn[this.m_MaxPanelObject];
		this.m_ItemArmsIcons1 = new Image[this.m_MaxPanelObject];
		this.m_ItemArmsIcons2 = new Image[this.m_MaxPanelObject];
		this.m_ItemEnhanceIcons1 = new Image[this.m_MaxPanelObject];
		this.m_ItemEnhanceIcons2 = new Image[this.m_MaxPanelObject];
		this.m_ItemArmsTexts1 = new Text[this.m_MaxPanelObject];
		this.m_ItemArmsTexts2 = new Text[this.m_MaxPanelObject];
		this.m_ItemNumTexts1 = new Text[this.m_MaxPanelObject];
		this.m_ItemNumTexts2 = new Text[this.m_MaxPanelObject];
		this.m_Item1 = new Transform[this.m_MaxPanelObject];
		this.m_Item2 = new Transform[this.m_MaxPanelObject];
		this.m_ItemLines = new Transform[this.m_MaxPanelObject];
		this.m_MaskImage1s = new Transform[this.m_MaxPanelObject];
		this.m_MaskImage2s = new Transform[this.m_MaxPanelObject];
		this.m_SelectImage1s = new Transform[this.m_MaxPanelObject];
		this.m_SelectImage2s = new Transform[this.m_MaxPanelObject];
		this.m_LineItem = new Transform[this.m_MaxPanelObject];
		this.m_LastStrItem = new Transform[this.m_MaxPanelObject];
		this.m_ItemBtns1 = new UIButton[this.m_MaxPanelObject];
		this.m_ItemBtns2 = new UIButton[this.m_MaxPanelObject];
		this.m_FightIcons1 = new Transform[this.m_MaxPanelObject];
		this.m_FightIcons2 = new Transform[this.m_MaxPanelObject];
		this.m_ItemLordBgs = new Transform[this.m_MaxPanelObject];
		this.m_ItemLordFlash = new Transform[this.m_MaxPanelObject];
		this.m_HeroList_Soldier_Items = new List<HeroList_Soldier_Item>();
		this.m_HeroList_Soldier_Items2 = new List<HeroList_Soldier_Item>();
		this.m_HeroList_Soldier_Items3 = new List<HeroList_Soldier_Item>();
		this.m_HeroList_Soldier_Items4 = new List<HeroList_Soldier_Item>();
		this.m_HeroList_Soldier_Items5 = new List<HeroList_Soldier_Item>();
		this.m_FlashLords = new Image[3];
		this.m_FlashLords[2] = this.m_OKLoadFlash;
		this.m_HeightData = new List<float>();
		this.CheckSendBtn();
		this.UpdateScrollData();
		this.SortAllType();
		this.UpdateScrollPanel(true);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 6);
	}

	// Token: 0x06001C31 RID: 7217 RVA: 0x0031CD34 File Offset: 0x0031AF34
	public override void OnClose()
	{
		this.DespawnPool();
		this.m_HeroList_Soldier_Items = null;
		GUIManager.Instance.RemoveSpriteAsset("UIExpedition");
		GUIManager.Instance.RemoveSpriteAsset("UI_frame");
	}

	// Token: 0x06001C32 RID: 7218 RVA: 0x0031CD6C File Offset: 0x0031AF6C
	private void DespawnPool()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		for (int i = this.m_HeroList_Soldier_Items.Count - 1; i >= 0; i--)
		{
			GUIManager.Instance.m_HeroList_Soldier_ItemDataPool.despawn(this.m_HeroList_Soldier_Items[i]);
		}
	}

	// Token: 0x06001C33 RID: 7219 RVA: 0x0031CDC4 File Offset: 0x0031AFC4
	public override void UpdateUI(int arg1, int arg2)
	{
	}

	// Token: 0x06001C34 RID: 7220 RVA: 0x0031CDC8 File Offset: 0x0031AFC8
	public override void UpdateNetwork(byte[] meg)
	{
	}

	// Token: 0x06001C35 RID: 7221 RVA: 0x0031CDCC File Offset: 0x0031AFCC
	private void Update()
	{
		if (this.bShowHint)
		{
			this.m_HintTick += Time.deltaTime;
			if (this.m_HintTick > 0.3f)
			{
				this.m_SkillPanel.gameObject.SetActive(true);
				this.m_HintTick = 0f;
				this.bShowHint = false;
				this.bCanClick = false;
			}
		}
		this.m_ColorTick += Time.deltaTime;
		if (this.m_ColorTick >= 0.05f)
		{
			this.m_ColorA += 0.1f;
			if (this.m_ColorA >= 2f)
			{
				this.m_ColorA = 0f;
			}
			for (int i = 0; i < 3; i++)
			{
				if (this.m_FlashLords[i] != null)
				{
					if (this.m_ColorA > 1f)
					{
						this.m_FlashLords[i].color = new Color(1f, 1f, 1f, 2f - this.m_ColorA);
					}
					else
					{
						this.m_FlashLords[i].color = new Color(1f, 1f, 1f, this.m_ColorA);
					}
				}
			}
			this.m_ColorTick = 0f;
		}
	}

	// Token: 0x06001C36 RID: 7222 RVA: 0x0031CF18 File Offset: 0x0031B118
	public void OnButtonDown(UIButtonHint sender)
	{
		this.bCanClick = true;
		this.bShowHint = true;
		this.m_HintTick = 0f;
	}

	// Token: 0x06001C37 RID: 7223 RVA: 0x0031CF34 File Offset: 0x0031B134
	public void OnButtonUp(UIButtonHint sender)
	{
		this.m_SkillPanel.gameObject.SetActive(false);
		this.bShowHint = false;
		this.m_HintTick = 0f;
	}

	// Token: 0x06001C38 RID: 7224 RVA: 0x0031CF5C File Offset: 0x0031B15C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.m_ItemHIBtns1[panelObjectIdx] == null)
		{
			Transform child = item.transform.GetChild(0);
			this.m_Item1[panelObjectIdx] = child;
			this.m_ItemBtns1[panelObjectIdx] = child.GetComponent<UIButton>();
			this.m_ItemHIBtns1[panelObjectIdx] = child.GetChild(0).GetComponent<UIHIBtn>();
			this.m_ItemArmsIcons1[panelObjectIdx] = child.GetChild(1).GetComponent<Image>();
			this.m_ItemArmsIcons1[panelObjectIdx].material = this.GetArmsMat();
			this.m_ItemEnhanceIcons1[panelObjectIdx] = child.GetChild(2).GetComponent<Image>();
			this.m_ItemEnhanceIcons1[panelObjectIdx].material = this.GetEnhanceMat();
			this.m_ItemArmsTexts1[panelObjectIdx] = child.GetChild(3).GetComponent<Text>();
			this.m_ItemNumTexts1[panelObjectIdx] = child.GetChild(4).GetComponent<Text>();
			this.m_MaskImage1s[panelObjectIdx] = child.GetChild(5);
			this.m_SelectImage1s[panelObjectIdx] = child.GetChild(6);
			this.m_FightIcons1[panelObjectIdx] = child.GetChild(7);
			this.m_ItemLordBgs[panelObjectIdx] = child.GetChild(8);
			this.m_ItemLordFlash[panelObjectIdx] = child.GetChild(9);
			this.m_ItemLordBgs[panelObjectIdx].GetComponent<Image>().material = this.GetArmsMat();
			this.m_ItemLordBgs[panelObjectIdx].GetComponent<Image>().sprite = GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_13");
			this.m_ItemLordFlash[panelObjectIdx].GetComponent<Image>().material = this.GetArmsMat();
			this.m_ItemLordFlash[panelObjectIdx].GetComponent<Image>().sprite = GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_12");
			child = item.transform.GetChild(1);
			this.m_Item2[panelObjectIdx] = child;
			this.m_ItemBtns2[panelObjectIdx] = child.GetComponent<UIButton>();
			this.m_ItemHIBtns2[panelObjectIdx] = child.GetChild(0).GetComponent<UIHIBtn>();
			this.m_ItemArmsIcons2[panelObjectIdx] = child.GetChild(1).GetComponent<Image>();
			this.m_ItemArmsIcons2[panelObjectIdx].material = this.GetArmsMat();
			this.m_ItemEnhanceIcons2[panelObjectIdx] = child.GetChild(2).GetComponent<Image>();
			this.m_ItemEnhanceIcons2[panelObjectIdx].material = this.GetEnhanceMat();
			this.m_ItemArmsTexts2[panelObjectIdx] = child.GetChild(3).GetComponent<Text>();
			this.m_ItemNumTexts2[panelObjectIdx] = child.GetChild(4).GetComponent<Text>();
			this.m_MaskImage2s[panelObjectIdx] = child.GetChild(5);
			this.m_SelectImage2s[panelObjectIdx] = child.GetChild(6);
			this.m_FightIcons2[panelObjectIdx] = child.GetChild(7);
			this.m_LineItem[panelObjectIdx] = item.transform.GetChild(2);
			this.m_LastStrItem[panelObjectIdx] = item.transform.GetChild(3);
		}
		int num = dataIdx * 2;
		int num2 = num + 1;
		List<HeroList_Soldier_Item> list = this.m_HeroList_Soldier_Items;
		if (this.m_SortType == eSort.Sort1)
		{
			list = this.m_HeroList_Soldier_Items;
		}
		else if (this.m_SortType == eSort.Sort2)
		{
			list = this.m_HeroList_Soldier_Items2;
		}
		else if (this.m_SortType == eSort.Sort3)
		{
			list = this.m_HeroList_Soldier_Items3;
		}
		else if (this.m_SortType == eSort.Sort4)
		{
			list = this.m_HeroList_Soldier_Items4;
		}
		else if (this.m_SortType == eSort.Sort5)
		{
			list = this.m_HeroList_Soldier_Items5;
		}
		if (num < list.Count)
		{
			byte type = list[num].Type;
			if (type == 0)
			{
				this.m_ItemBtns1[panelObjectIdx].m_Handler = this;
				this.m_ItemBtns1[panelObjectIdx].m_BtnID1 = 98;
				this.m_ItemBtns1[panelObjectIdx].m_BtnID2 = num;
				this.m_Item1[panelObjectIdx].gameObject.SetActive(true);
				this.m_Item2[panelObjectIdx].gameObject.SetActive(true);
				this.m_LineItem[panelObjectIdx].gameObject.SetActive(false);
				this.m_LastStrItem[panelObjectIdx].gameObject.SetActive(false);
				GUIManager.Instance.ChangeHeroItemImg(this.m_ItemHIBtns1[panelObjectIdx].gameObject.transform, eHeroOrItem.Hero, list[num].HeroID, list[num].Enhance, 0, 0);
				this.m_ItemArmsIcons1[panelObjectIdx].sprite = this.GetArmsIcon(list[num].Arms);
				this.m_ItemEnhanceIcons1[panelObjectIdx].sprite = this.GetEnhanceIcon(list[num].Enhance);
				this.m_ItemArmsTexts1[panelObjectIdx].text = this.GetArmsStr(list[num].Arms);
				this.m_ItemNumTexts1[panelObjectIdx].text = list[num].MaxNum.ToString();
				if (list[num].HeroID == 0)
				{
					this.m_Item1[panelObjectIdx].gameObject.SetActive(false);
				}
				if (list[num].bSelect)
				{
					this.m_MaskImage1s[panelObjectIdx].gameObject.SetActive(true);
					this.m_SelectImage1s[panelObjectIdx].gameObject.SetActive(true);
				}
				else
				{
					this.m_MaskImage1s[panelObjectIdx].gameObject.SetActive(false);
					this.m_SelectImage1s[panelObjectIdx].gameObject.SetActive(false);
				}
				if (list[num].bIsFight)
				{
					this.m_FightIcons1[panelObjectIdx].gameObject.SetActive(true);
				}
				else
				{
					this.m_FightIcons1[panelObjectIdx].gameObject.SetActive(false);
				}
				if (this.LoadsDataIdx == dataIdx)
				{
					this.m_ItemLordBgs[panelObjectIdx].gameObject.SetActive(false);
					this.m_ItemLordFlash[panelObjectIdx].gameObject.SetActive(false);
					this.SetLordIcon(0, this.m_ItemLordFlash[panelObjectIdx].GetComponent<Image>());
				}
				else
				{
					this.m_ItemLordBgs[panelObjectIdx].gameObject.SetActive(false);
					this.m_ItemLordFlash[panelObjectIdx].gameObject.SetActive(false);
				}
				if (num2 < list.Count)
				{
					this.m_ItemBtns2[panelObjectIdx].m_Handler = this;
					this.m_ItemBtns2[panelObjectIdx].m_BtnID1 = 99;
					this.m_ItemBtns2[panelObjectIdx].m_BtnID2 = num2;
					GUIManager.Instance.ChangeHeroItemImg(this.m_ItemHIBtns2[panelObjectIdx].gameObject.transform, eHeroOrItem.Hero, list[num2].HeroID, list[num2].Enhance, 0, 0);
					this.m_ItemArmsIcons2[panelObjectIdx].sprite = this.GetArmsIcon(list[num2].Arms);
					this.m_ItemEnhanceIcons2[panelObjectIdx].sprite = this.GetEnhanceIcon(list[num2].Enhance);
					this.m_ItemArmsTexts2[panelObjectIdx].text = this.GetArmsStr(list[num2].Arms);
					this.m_ItemNumTexts2[panelObjectIdx].text = list[num2].MaxNum.ToString();
					if (list[num2].HeroID == 0)
					{
						this.m_Item2[panelObjectIdx].gameObject.SetActive(false);
					}
					if (list[num2].bSelect)
					{
						this.m_MaskImage2s[panelObjectIdx].gameObject.SetActive(true);
						this.m_SelectImage2s[panelObjectIdx].gameObject.SetActive(true);
					}
					else
					{
						this.m_MaskImage2s[panelObjectIdx].gameObject.SetActive(false);
						this.m_SelectImage2s[panelObjectIdx].gameObject.SetActive(false);
					}
					if (list[num2].bIsFight)
					{
						this.m_FightIcons2[panelObjectIdx].gameObject.SetActive(true);
					}
					else
					{
						this.m_FightIcons2[panelObjectIdx].gameObject.SetActive(false);
					}
				}
			}
			else
			{
				this.m_Item1[panelObjectIdx].gameObject.SetActive(false);
				this.m_Item2[panelObjectIdx].gameObject.SetActive(false);
				if (type == 1)
				{
					this.m_LineItem[panelObjectIdx].gameObject.SetActive(true);
				}
				else if (type == 2)
				{
					this.m_LastStrItem[panelObjectIdx].gameObject.SetActive(true);
				}
			}
		}
	}

	// Token: 0x06001C39 RID: 7225 RVA: 0x0031D724 File Offset: 0x0031B924
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		switch (btnID)
		{
		case 1:
		case 2:
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				door.CloseMenu(false);
			}
			break;
		}
		case 3:
			this.OnSortClick(0);
			break;
		case 4:
			this.OnSortClick(1);
			break;
		case 5:
			this.OnSortClick(2);
			break;
		case 6:
			this.OnSortClick(3);
			break;
		case 7:
			this.OnSortClick(4);
			break;
		case 8:
			this.OpenSortPanel(!this.m_bShowSortPanel);
			break;
		case 9:
			Debug.Log("AutonBtn");
			this.AutoSelect(this.MaxSelectHero);
			break;
		default:
			if (btnID != 98)
			{
				if (btnID == 99)
				{
					if (!this.bCanClick || this.m_HeroList_Soldier_Items[sender.m_BtnID2].bIsFight)
					{
						return;
					}
					int num = sender.m_BtnID2 / 2;
					if (this.m_HeroList_Soldier_Items[sender.m_BtnID2].bSelect)
					{
						this.m_MaskImage2s[num].gameObject.SetActive(false);
						this.m_SelectImage2s[num].gameObject.SetActive(false);
						this.RemoveSelect(sender.m_BtnID2);
						this.m_HeroList_Soldier_Items[sender.m_BtnID2].bSelect = false;
					}
					else
					{
						this.m_MaskImage2s[num].gameObject.SetActive(true);
						this.m_SelectImage2s[num].gameObject.SetActive(true);
						this.AddSelect(sender.m_BtnID2);
						this.m_HeroList_Soldier_Items[sender.m_BtnID2].bSelect = true;
					}
					this.CheckSendBtn();
				}
			}
			else
			{
				if (!this.bCanClick || this.m_HeroList_Soldier_Items[sender.m_BtnID2].bIsFight)
				{
					return;
				}
				int num = sender.m_BtnID2 / 2;
				if (this.m_HeroList_Soldier_Items[sender.m_BtnID2].bSelect)
				{
					this.m_MaskImage1s[num].gameObject.SetActive(false);
					this.m_SelectImage1s[num].gameObject.SetActive(false);
					this.RemoveSelect(sender.m_BtnID2);
					this.m_HeroList_Soldier_Items[sender.m_BtnID2].bSelect = false;
				}
				else
				{
					this.m_MaskImage1s[num].gameObject.SetActive(true);
					this.m_SelectImage1s[num].gameObject.SetActive(true);
					this.AddSelect(sender.m_BtnID2);
					this.m_HeroList_Soldier_Items[sender.m_BtnID2].bSelect = true;
				}
				this.CheckSendBtn();
			}
			break;
		}
	}

	// Token: 0x06001C3A RID: 7226 RVA: 0x0031D9EC File Offset: 0x0031BBEC
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001C3B RID: 7227 RVA: 0x0031D9F0 File Offset: 0x0031BBF0
	private void SetLordIcon(int iconIdx, Image image)
	{
		if (iconIdx >= 0 && iconIdx < 3)
		{
			this.m_FlashLords[iconIdx] = image;
		}
	}

	// Token: 0x06001C3C RID: 7228 RVA: 0x0031DA0C File Offset: 0x0031BC0C
	private void SetSkillPanel()
	{
		GUIManager.Instance.ChangeHeroItemImg(this.m_SkillHero.transform, eHeroOrItem.Hero, 1, 1, 0, 0);
		GUIManager.Instance.ChangeHeroItemImg(this.m_SkillBtn1.transform, eHeroOrItem.Hero, 1, 1, 0, 0);
		GUIManager.Instance.ChangeHeroItemImg(this.m_SkillBtn2.transform, eHeroOrItem.Hero, 1, 1, 0, 0);
		GUIManager.Instance.ChangeHeroItemImg(this.m_SkillBtn3.transform, eHeroOrItem.Hero, 1, 1, 0, 0);
		GUIManager.Instance.ChangeHeroItemImg(this.m_SkillBtn4.transform, eHeroOrItem.Hero, 1, 1, 0, 0);
	}

	// Token: 0x06001C3D RID: 7229 RVA: 0x0031DA9C File Offset: 0x0031BC9C
	private void CheckSendBtn()
	{
		if (DataManager.Instance.LegionBattleHero.Count > 0)
		{
			this.m_OKBtn.interactable = true;
		}
		else
		{
			this.m_OKBtn.interactable = false;
		}
		int count = DataManager.Instance.LegionBattleHero.Count;
		this.m_OKLoadBg.gameObject.SetActive(false);
		this.m_OKLoadFlash.gameObject.SetActive(false);
		this.m_OKBtnText1Rt.anchoredPosition = new Vector2(0f, 2f);
		this.m_OKBtnText2.gameObject.SetActive(false);
		for (int i = 0; i < count; i++)
		{
			if ((int)DataManager.Instance.LegionBattleHero[i] == this.m_LordID)
			{
				this.m_OKLoadBg.gameObject.SetActive(true);
				this.m_OKLoadFlash.gameObject.SetActive(true);
				this.m_OKBtnText1Rt.anchoredPosition = new Vector2(27f, 2f);
				this.m_OKBtnText2.gameObject.SetActive(true);
				break;
			}
		}
	}

	// Token: 0x06001C3E RID: 7230 RVA: 0x0031DBB8 File Offset: 0x0031BDB8
	private void AutoSelect(int num)
	{
		int count = this.m_HeroList_Soldier_Items.Count;
		for (int i = 0; i < count; i++)
		{
			this.m_HeroList_Soldier_Items[i].bSelect = false;
		}
		DataManager.Instance.LegionBattleHero.Clear();
		DataManager.Instance.LegionBattleSildoers = 0;
		int num2 = 0;
		while (num2 < num && num2 < count && (long)num2 < (long)((ulong)this.NonFightHeroNum))
		{
			this.AddSelect(num2);
			this.m_HeroList_Soldier_Items[num2].bSelect = true;
			num2++;
		}
		this.CheckSendBtn();
		this.UpdateScrollPanel(false);
	}

	// Token: 0x06001C3F RID: 7231 RVA: 0x0031DC5C File Offset: 0x0031BE5C
	private void AddSelect(int idx)
	{
		DataManager.Instance.LegionBattleHero.Add(this.m_HeroList_Soldier_Items[idx].HeroID);
		DataManager.Instance.LegionBattleSildoers += (int)this.m_HeroList_Soldier_Items[idx].MaxNum;
		this.m_SoldierCountText.text = DataManager.Instance.LegionBattleSildoers.ToString();
		int count = DataManager.Instance.LegionBattleHero.Count;
		this.sb.Length = 0;
		this.sb.AppendFormat("{0}/{1}", count, this.MaxSelectHero);
		this.m_SoldierValueCount.text = this.sb.ToString();
	}

	// Token: 0x06001C40 RID: 7232 RVA: 0x0031DD1C File Offset: 0x0031BF1C
	private void RemoveSelect(int idx)
	{
		DataManager.Instance.LegionBattleHero.Remove(this.m_HeroList_Soldier_Items[idx].HeroID);
		DataManager.Instance.LegionBattleSildoers -= (int)this.m_HeroList_Soldier_Items[idx].MaxNum;
		this.m_SoldierCountText.text = DataManager.Instance.LegionBattleSildoers.ToString();
		int count = DataManager.Instance.LegionBattleHero.Count;
		this.sb.Length = 0;
		this.sb.AppendFormat("{0}/{1}", count, this.MaxSelectHero);
		this.m_SoldierValueCount.text = this.sb.ToString();
	}

	// Token: 0x06001C41 RID: 7233 RVA: 0x0031DDDC File Offset: 0x0031BFDC
	private void OpenSortPanel(bool bShow)
	{
		this.m_SortPanel.gameObject.SetActive(bShow);
		this.m_bShowSortPanel = bShow;
	}

	// Token: 0x06001C42 RID: 7234 RVA: 0x0031DDF8 File Offset: 0x0031BFF8
	private void SortAllType()
	{
		int curHeroDataCount = (int)DataManager.Instance.CurHeroDataCount;
		UIHeroList_Soldier.SoldierComparer soldierComparer = new UIHeroList_Soldier.SoldierComparer();
		soldierComparer.SortType = eSort.Sort1;
		this.m_HeroList_Soldier_Items.Sort(0, curHeroDataCount, soldierComparer);
	}

	// Token: 0x06001C43 RID: 7235 RVA: 0x0031DE2C File Offset: 0x0031C02C
	private void OnSortClick(int sortType)
	{
		switch (sortType)
		{
		case 0:
			this.m_SortType = eSort.Sort1;
			this.m_SortBtnText.text = DataManager.Instance.mStringTable.GetStringByID(this.m_SrotStrIDs[sortType]);
			break;
		case 1:
			this.m_SortType = eSort.Sort2;
			this.m_SortBtnText.text = DataManager.Instance.mStringTable.GetStringByID(this.m_SrotStrIDs[sortType]);
			break;
		case 2:
			this.m_SortType = eSort.Sort3;
			this.m_SortBtnText.text = DataManager.Instance.mStringTable.GetStringByID(this.m_SrotStrIDs[sortType]);
			break;
		case 3:
			this.m_SortType = eSort.Sort4;
			this.m_SortBtnText.text = DataManager.Instance.mStringTable.GetStringByID(this.m_SrotStrIDs[sortType]);
			break;
		case 4:
			this.m_SortType = eSort.Sort5;
			this.m_SortBtnText.text = DataManager.Instance.mStringTable.GetStringByID(this.m_SrotStrIDs[sortType]);
			break;
		}
		this.UpdateScrollPanel(false);
		this.m_SortPanel.gameObject.SetActive(false);
		this.m_bShowSortPanel = false;
	}

	// Token: 0x06001C44 RID: 7236 RVA: 0x0031DF60 File Offset: 0x0031C160
	private void UpdateScrollData()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		this.FightHeroNum = DataManager.Instance.FightHeroCount;
		this.NonFightHeroNum = DataManager.Instance.CurHeroDataCount - this.FightHeroNum;
		this.DespawnPool();
		this.m_HeroList_Soldier_Items.Clear();
		this.m_HeroList_Soldier_Items2.Clear();
		this.m_HeroList_Soldier_Items3.Clear();
		this.m_HeroList_Soldier_Items4.Clear();
		this.m_HeroList_Soldier_Items5.Clear();
		this.m_HeightData.Clear();
		if (DataManager.Instance.CurHeroDataCount % 2u == 0u)
		{
			this.DataCount = (int)(DataManager.Instance.CurHeroDataCount + 4u);
		}
		else
		{
			this.DataCount = (int)(DataManager.Instance.CurHeroDataCount + 1u + 4u);
		}
		int num = (int)((this.NonFightHeroNum % 2u != 0u) ? (this.NonFightHeroNum + 1u) : this.NonFightHeroNum);
		for (int i = 0; i < num; i++)
		{
			HeroList_Soldier_Item heroList_Soldier_Item = GUIManager.Instance.m_HeroList_Soldier_ItemDataPool.spawn();
			this.m_HeroList_Soldier_Items.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items2.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items3.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items4.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items5.Add(heroList_Soldier_Item);
			heroList_Soldier_Item.Arms = 0;
			uint key = DataManager.Instance.NonFightHeroID[i];
			CurHeroData curHeroData = DataManager.Instance.curHeroData[key];
			heroList_Soldier_Item.Enhance = curHeroData.Enhance;
			heroList_Soldier_Item.HeroID = curHeroData.ID;
			heroList_Soldier_Item.MaxNum = DataManager.Instance.RankSoldiers[(int)curHeroData.Enhance];
			heroList_Soldier_Item.bIsLords = false;
			heroList_Soldier_Item.bSelect = false;
			heroList_Soldier_Item.bIsFight = false;
			heroList_Soldier_Item.Type = 0;
			if (i % 2 == 0)
			{
				this.m_HeightData.Add(80f);
			}
		}
		for (int j = 0; j < 2; j++)
		{
			HeroList_Soldier_Item heroList_Soldier_Item = GUIManager.Instance.m_HeroList_Soldier_ItemDataPool.spawn();
			this.m_HeroList_Soldier_Items.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items2.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items3.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items4.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items5.Add(heroList_Soldier_Item);
			heroList_Soldier_Item.Type = 1;
			if (j % 2 == 0)
			{
				this.m_HeightData.Add(40f);
			}
		}
		int num2 = (int)((this.FightHeroNum % 2u != 0u) ? (this.FightHeroNum + 1u) : this.FightHeroNum);
		for (int k = 0; k < num2; k++)
		{
			HeroList_Soldier_Item heroList_Soldier_Item = GUIManager.Instance.m_HeroList_Soldier_ItemDataPool.spawn();
			this.m_HeroList_Soldier_Items.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items2.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items3.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items4.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items5.Add(heroList_Soldier_Item);
			heroList_Soldier_Item.Arms = 0;
			uint key = DataManager.Instance.FightHeroID[k];
			CurHeroData curHeroData = DataManager.Instance.curHeroData[key];
			heroList_Soldier_Item.Enhance = curHeroData.Enhance;
			heroList_Soldier_Item.HeroID = curHeroData.ID;
			heroList_Soldier_Item.MaxNum = DataManager.Instance.RankSoldiers[(int)curHeroData.Enhance];
			heroList_Soldier_Item.bIsLords = false;
			heroList_Soldier_Item.bSelect = false;
			heroList_Soldier_Item.bIsFight = true;
			heroList_Soldier_Item.Type = 0;
			if (k % 2 == 0)
			{
				this.m_HeightData.Add(80f);
			}
		}
		for (int l = 0; l < 2; l++)
		{
			HeroList_Soldier_Item heroList_Soldier_Item = GUIManager.Instance.m_HeroList_Soldier_ItemDataPool.spawn();
			this.m_HeroList_Soldier_Items.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items2.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items3.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items4.Add(heroList_Soldier_Item);
			this.m_HeroList_Soldier_Items5.Add(heroList_Soldier_Item);
			heroList_Soldier_Item.Type = 2;
			if (l % 2 == 0)
			{
				this.m_HeightData.Add(60f);
			}
		}
	}

	// Token: 0x06001C45 RID: 7237 RVA: 0x0031E354 File Offset: 0x0031C554
	private void UpdateScrollPanel(bool bInit)
	{
		if (bInit)
		{
			this.m_ScrollPanel.IntiScrollPanel(442.7f, 10f, 4f, this.m_HeightData, this.m_MaxPanelObject, this);
		}
		else
		{
			this.m_ScrollPanel.AddNewDataHeight(this.m_HeightData, true, true);
		}
	}

	// Token: 0x06001C46 RID: 7238 RVA: 0x0031E3A8 File Offset: 0x0031C5A8
	private string GetArmsStr(byte arms)
	{
		return DataManager.Instance.mStringTable.GetStringByID(3841u + (uint)arms);
	}

	// Token: 0x06001C47 RID: 7239 RVA: 0x0031E3C0 File Offset: 0x0031C5C0
	private Sprite GetArmsIcon(byte arms)
	{
		if (arms == 0)
		{
			return GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_a");
		}
		if (arms == 1)
		{
			return GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_b");
		}
		if (arms == 2)
		{
			return GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_c");
		}
		if (arms == 3)
		{
			return GUIManager.Instance.LoadSprite("UIExpedition", "UI_legion_icon_d");
		}
		return null;
	}

	// Token: 0x06001C48 RID: 7240 RVA: 0x0031E440 File Offset: 0x0031C640
	private Material GetArmsMat()
	{
		return GUIManager.Instance.LoadMaterial("UIExpedition", "UI_legion_m");
	}

	// Token: 0x06001C49 RID: 7241 RVA: 0x0031E458 File Offset: 0x0031C658
	private Sprite GetEnhanceIcon(byte Enhance)
	{
		this.sb.Length = 0;
		this.sb.AppendFormat("hf{0}", (int)(Enhance + 100));
		return GUIManager.Instance.LoadSprite("UI_frame", this.sb.ToString());
	}

	// Token: 0x06001C4A RID: 7242 RVA: 0x0031E4A8 File Offset: 0x0031C6A8
	private Material GetEnhanceMat()
	{
		return GUIManager.Instance.GetFrameMaterial();
	}

	// Token: 0x04005551 RID: 21841
	private Transform m_InfoPanel;

	// Token: 0x04005552 RID: 21842
	private Transform m_SortPanel;

	// Token: 0x04005553 RID: 21843
	private Transform m_SkillPanel;

	// Token: 0x04005554 RID: 21844
	private Text m_TitleText;

	// Token: 0x04005555 RID: 21845
	private Text m_OKBtnText1;

	// Token: 0x04005556 RID: 21846
	private Text m_OKBtnText2;

	// Token: 0x04005557 RID: 21847
	private RectTransform m_OKBtnText1Rt;

	// Token: 0x04005558 RID: 21848
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04005559 RID: 21849
	private UIButton m_ExitBtn;

	// Token: 0x0400555A RID: 21850
	private UIButton m_OKBtn;

	// Token: 0x0400555B RID: 21851
	private UIButton m_SortBtn;

	// Token: 0x0400555C RID: 21852
	private UIButton m_AutoBtn;

	// Token: 0x0400555D RID: 21853
	private Image m_OKLoadBg;

	// Token: 0x0400555E RID: 21854
	private Image m_OKLoadFlash;

	// Token: 0x0400555F RID: 21855
	private Transform m_HiBtn1;

	// Token: 0x04005560 RID: 21856
	private Transform m_HiBtn2;

	// Token: 0x04005561 RID: 21857
	private Text m_SoldierCountText;

	// Token: 0x04005562 RID: 21858
	private Text m_SoldierValueCount;

	// Token: 0x04005563 RID: 21859
	private Text m_SortBtnText;

	// Token: 0x04005564 RID: 21860
	private UIHIBtn m_SkillHero;

	// Token: 0x04005565 RID: 21861
	private UIHIBtn m_SkillBtn1;

	// Token: 0x04005566 RID: 21862
	private UIHIBtn m_SkillBtn2;

	// Token: 0x04005567 RID: 21863
	private UIHIBtn m_SkillBtn3;

	// Token: 0x04005568 RID: 21864
	private UIHIBtn m_SkillBtn4;

	// Token: 0x04005569 RID: 21865
	private Image m_SkillEnhance;

	// Token: 0x0400556A RID: 21866
	private int MaxSelectHero = 10;

	// Token: 0x0400556B RID: 21867
	private StringBuilder sb;

	// Token: 0x0400556C RID: 21868
	private int m_MaxPanelObject;

	// Token: 0x0400556D RID: 21869
	private UIHIBtn[] m_ItemHIBtns1;

	// Token: 0x0400556E RID: 21870
	private Image[] m_ItemArmsIcons1;

	// Token: 0x0400556F RID: 21871
	private Image[] m_ItemEnhanceIcons1;

	// Token: 0x04005570 RID: 21872
	private Text[] m_ItemArmsTexts1;

	// Token: 0x04005571 RID: 21873
	private Text[] m_ItemNumTexts1;

	// Token: 0x04005572 RID: 21874
	private UIHIBtn[] m_ItemHIBtns2;

	// Token: 0x04005573 RID: 21875
	private Image[] m_ItemArmsIcons2;

	// Token: 0x04005574 RID: 21876
	private Image[] m_ItemEnhanceIcons2;

	// Token: 0x04005575 RID: 21877
	private Text[] m_ItemArmsTexts2;

	// Token: 0x04005576 RID: 21878
	private Text[] m_ItemNumTexts2;

	// Token: 0x04005577 RID: 21879
	private Transform[] m_Item1;

	// Token: 0x04005578 RID: 21880
	private Transform[] m_Item2;

	// Token: 0x04005579 RID: 21881
	private Transform[] m_ItemLines;

	// Token: 0x0400557A RID: 21882
	private Transform[] m_MaskImage1s;

	// Token: 0x0400557B RID: 21883
	private Transform[] m_MaskImage2s;

	// Token: 0x0400557C RID: 21884
	private Transform[] m_SelectImage1s;

	// Token: 0x0400557D RID: 21885
	private Transform[] m_SelectImage2s;

	// Token: 0x0400557E RID: 21886
	private Transform[] m_LineItem;

	// Token: 0x0400557F RID: 21887
	private Transform[] m_LastStrItem;

	// Token: 0x04005580 RID: 21888
	private UIButton[] m_ItemBtns1;

	// Token: 0x04005581 RID: 21889
	private UIButton[] m_ItemBtns2;

	// Token: 0x04005582 RID: 21890
	private Transform[] m_FightIcons1;

	// Token: 0x04005583 RID: 21891
	private Transform[] m_FightIcons2;

	// Token: 0x04005584 RID: 21892
	private Transform[] m_ItemLordBgs;

	// Token: 0x04005585 RID: 21893
	private Transform[] m_ItemLordFlash;

	// Token: 0x04005586 RID: 21894
	private uint[] m_SrotStrIDs = new uint[]
	{
		343u,
		3841u,
		3842u,
		3843u,
		3844u
	};

	// Token: 0x04005587 RID: 21895
	private bool m_bShowSortPanel;

	// Token: 0x04005588 RID: 21896
	private eSort m_SortType;

	// Token: 0x04005589 RID: 21897
	private uint FightHeroNum;

	// Token: 0x0400558A RID: 21898
	private uint NonFightHeroNum;

	// Token: 0x0400558B RID: 21899
	private int DataCount = (int)(DataManager.Instance.CurHeroDataCount + 4u);

	// Token: 0x0400558C RID: 21900
	private float m_HintTick;

	// Token: 0x0400558D RID: 21901
	private bool bShowHint;

	// Token: 0x0400558E RID: 21902
	private bool bCanClick;

	// Token: 0x0400558F RID: 21903
	private Image[] m_FlashLords;

	// Token: 0x04005590 RID: 21904
	private float m_ColorA;

	// Token: 0x04005591 RID: 21905
	private float m_ColorTick;

	// Token: 0x04005592 RID: 21906
	private int LoadsDataIdx;

	// Token: 0x04005593 RID: 21907
	private int m_LordID = 1;

	// Token: 0x04005594 RID: 21908
	public List<HeroList_Soldier_Item> m_HeroList_Soldier_Items;

	// Token: 0x04005595 RID: 21909
	public List<HeroList_Soldier_Item> m_HeroList_Soldier_Items2;

	// Token: 0x04005596 RID: 21910
	public List<HeroList_Soldier_Item> m_HeroList_Soldier_Items3;

	// Token: 0x04005597 RID: 21911
	public List<HeroList_Soldier_Item> m_HeroList_Soldier_Items4;

	// Token: 0x04005598 RID: 21912
	public List<HeroList_Soldier_Item> m_HeroList_Soldier_Items5;

	// Token: 0x04005599 RID: 21913
	public List<float> m_HeightData;

	// Token: 0x02000592 RID: 1426
	public class SoldierComparer : IComparer<HeroList_Soldier_Item>
	{
		// Token: 0x06001C4C RID: 7244 RVA: 0x0031E4D4 File Offset: 0x0031C6D4
		public int Compare(HeroList_Soldier_Item x, HeroList_Soldier_Item y)
		{
			if (this.SortType == eSort.Sort1)
			{
				return this.CompareType1(x, y);
			}
			if (this.SortType == eSort.Sort2)
			{
				return this.CompareType2(x, y);
			}
			if (this.SortType == eSort.Sort3)
			{
				return this.CompareType3(x, y);
			}
			return this.CompareType4(x, y);
		}

		// Token: 0x06001C4D RID: 7245 RVA: 0x0031E528 File Offset: 0x0031C728
		public int CompareType1(HeroList_Soldier_Item x, HeroList_Soldier_Item y)
		{
			if (x.Arms != 0)
			{
				return -1;
			}
			if (x.MaxNum < y.MaxNum)
			{
				return 1;
			}
			return -1;
		}

		// Token: 0x06001C4E RID: 7246 RVA: 0x0031E54C File Offset: 0x0031C74C
		public int CompareType2(HeroList_Soldier_Item x, HeroList_Soldier_Item y)
		{
			if (x.Arms != 0)
			{
				return -1;
			}
			if (x.MaxNum > y.MaxNum)
			{
				return 1;
			}
			return -1;
		}

		// Token: 0x06001C4F RID: 7247 RVA: 0x0031E570 File Offset: 0x0031C770
		public int CompareType3(HeroList_Soldier_Item x, HeroList_Soldier_Item y)
		{
			if (x.Arms != 0)
			{
				return -1;
			}
			if (x.MaxNum > y.MaxNum)
			{
				return 1;
			}
			return -1;
		}

		// Token: 0x06001C50 RID: 7248 RVA: 0x0031E594 File Offset: 0x0031C794
		public int CompareType4(HeroList_Soldier_Item x, HeroList_Soldier_Item y)
		{
			if (x.Arms != 0)
			{
				return -1;
			}
			if (x.MaxNum > y.MaxNum)
			{
				return 1;
			}
			return -1;
		}

		// Token: 0x0400559A RID: 21914
		public eSort SortType;

		// Token: 0x0400559B RID: 21915
		private UIHeroList_Soldier heroList_Soldier = GUIManager.Instance.FindMenu(EGUIWindow.UI_HeroList_Soldier) as UIHeroList_Soldier;
	}
}
