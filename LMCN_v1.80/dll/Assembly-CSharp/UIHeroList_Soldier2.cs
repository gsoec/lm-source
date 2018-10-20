using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x0200059A RID: 1434
public class UIHeroList_Soldier2 : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x06001C53 RID: 7251 RVA: 0x0031E5E0 File Offset: 0x0031C7E0
	public override void OnOpen(int arg1, int arg2)
	{
		GameObject gameObject = new GameObject();
		this.context = gameObject.AddComponent<UIText>();
		this.context.enabled = false;
		gameObject.transform.SetParent(base.transform, false);
		this.m_OpenType = arg1;
		this.bPreselectedTeam = (arg2 == 1);
		this.GM = GUIManager.Instance;
		this.DM = DataManager.Instance;
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.TTF = this.GM.GetTTFFont();
		this.m_Data = new List<SoldierScrollItem>();
		this.m_EffetData = new List<SkillEffect>();
		this.m_TweenAlpha = new uTweenAlpha[5];
		this.m_TweenAlphaImage = new Image[5];
		this.m_SkliiNameText = new UIText[4];
		this.m_SkillInfoText = new UIText[4];
		this.m_SkillImage = new Image[4];
		this.m_SkillFrame = new Image[4];
		this.m_SkillMaskTf = new Transform[4];
		this.m_ColorTick = new float[5];
		this.m_ColorA = new float[5];
		this.m_ColoeAImage = new Image[5];
		this.m_BattleHero = new UIHIBtn[5];
		this.m_BattleHeroPlus = new Image[5];
		this.m_BattleHeroLock = new Image[5];
		this.m_MoveHero = new UIHIBtn[5];
		this.moveStack = new MoveObject[5];
		this.bCanClick = true;
		this.MoveBtnCount = 0;
		this.bCanClickbtn = false;
		this.m_BattleHeroNum = (byte)this.DM.GetMaxDefenders();
		this.m_BattleHeroID = new ushort[5];
		this.m_SelectNum = 0;
		for (int i = 0; i < this.m_BattleHeroID.Length; i++)
		{
			this.moveStack[i] = new MoveObject();
			this.m_BattleHeroID[i] = 0;
		}
		this.m_MaxNum = 0u;
		this.m_SpriteStr = StringManager.Instance.SpawnString(30);
		this.m_SkillInfoStr = new CString[4];
		for (int j = 0; j < 4; j++)
		{
			this.m_SkillInfoStr[j] = StringManager.Instance.SpawnString(30);
		}
		this.m_HeroMaxNumStr = StringManager.Instance.SpawnString(30);
		this.m_MaxNumStr = StringManager.Instance.SpawnString(30);
		GUIManager.Instance.AddSpriteAsset("UI_frame");
		this.InitUI();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 6);
	}

	// Token: 0x06001C54 RID: 7252 RVA: 0x0031E83C File Offset: 0x0031CA3C
	public override void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.m_SpriteStr);
		for (int i = 0; i < this.m_ScrollObj.Length; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				if (this.m_ScrollObj[i].PanelItem[j].MaxNumStr != null)
				{
					StringManager.Instance.DeSpawnString(this.m_ScrollObj[i].PanelItem[j].MaxNumStr);
				}
			}
		}
		for (int k = 0; k < 12; k++)
		{
			StringManager.Instance.DeSpawnString(this.m_TextItem[k].Text1Str);
			StringManager.Instance.DeSpawnString(this.m_TextItem[k].Text2Str);
		}
		for (int l = 0; l < 4; l++)
		{
			StringManager.Instance.DeSpawnString(this.m_SkillInfoStr[l]);
		}
		StringManager.Instance.DeSpawnString(this.m_HeroMaxNumStr);
		for (int m = this.m_Data.Count - 1; m >= 0; m--)
		{
			this.m_Data[m].Item[0].Type = 0;
			this.m_Data[m].Item[1].Type = 0;
			this.GM.m_HeroList_Soldier_ItemDataPool2.despawn(this.m_Data[m]);
		}
		GUIManager.Instance.RemoveSpriteAsset("UI_frame");
	}

	// Token: 0x06001C55 RID: 7253 RVA: 0x0031E9D8 File Offset: 0x0031CBD8
	public override void UpdateUI(int arg1, int arg2)
	{
		ushort leaderID = this.DM.GetLeaderID();
		for (int i = 0; i < this.m_BattleHeroID.Length; i++)
		{
			if (this.m_BattleHeroID[i] != 0 && this.m_BattleHeroID[i] == leaderID && this.DM.beCaptured.nowCaptureStat != LoadCaptureState.None)
			{
				this.OnHIButtonClick(this.m_BattleHero[i]);
				break;
			}
		}
		for (int j = this.m_Data.Count - 1; j >= 0; j--)
		{
			this.m_Data[j].Item[0].Type = 0;
			this.m_Data[j].Item[1].Type = 0;
			this.GM.m_HeroList_Soldier_ItemDataPool2.despawn(this.m_Data[j]);
		}
		this.m_Data.Clear();
		this.m_EffetData.Clear();
		this.m_SelectNum = 0;
		this.m_MaxNum = 0u;
		this.SetData();
		this.UpdateData(true);
	}

	// Token: 0x06001C56 RID: 7254 RVA: 0x0031EAF4 File Offset: 0x0031CCF4
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
		case NetworkNews.Refresh_Hero:
			this.UpdateUI(0, 0);
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
			break;
		}
	}

	// Token: 0x06001C57 RID: 7255 RVA: 0x0031EB48 File Offset: 0x0031CD48
	public void Refresh_FontTexture()
	{
		if (this.m_BtnText != null && this.m_BtnText.enabled)
		{
			this.m_BtnText.enabled = false;
			this.m_BtnText.enabled = true;
		}
		if (this.m_EmptyStr != null && this.m_EmptyStr.enabled)
		{
			this.m_EmptyStr.enabled = false;
			this.m_EmptyStr.enabled = true;
		}
		if (this.m_AutoText != null && this.m_AutoText.enabled)
		{
			this.m_AutoText.enabled = false;
			this.m_AutoText.enabled = true;
		}
		if (this.m_MaxNumText != null && this.m_MaxNumText.enabled)
		{
			this.m_MaxNumText.enabled = false;
			this.m_MaxNumText.enabled = true;
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
		if (this.context != null && this.context.enabled)
		{
			this.context.enabled = false;
			this.context.enabled = true;
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.m_SkliiNameText[i] != null && this.m_SkliiNameText[i].enabled)
			{
				this.m_SkliiNameText[i].enabled = false;
				this.m_SkliiNameText[i].enabled = true;
			}
			if (this.m_SkillInfoText[i] != null && this.m_SkillInfoText[i].enabled)
			{
				this.m_SkillInfoText[i].enabled = false;
				this.m_SkillInfoText[i].enabled = true;
			}
		}
		if (this.m_HeroIcon)
		{
			this.m_HeroIcon.Refresh_FontTexture();
		}
		for (int j = 0; j < 3; j++)
		{
			if (this.m_tmptext[j] != null && this.m_tmptext[j].enabled)
			{
				this.m_tmptext[j].enabled = false;
				this.m_tmptext[j].enabled = true;
			}
		}
		if (this.m_TextItem != null)
		{
			for (int k = 0; k < this.m_TextItem.Length; k++)
			{
				if (this.m_TextItem[k].Text1 != null && this.m_TextItem[k].Text1.enabled)
				{
					this.m_TextItem[k].Text1.enabled = false;
					this.m_TextItem[k].Text1.enabled = true;
				}
				if (this.m_TextItem[k].Text2 != null && this.m_TextItem[k].Text2.enabled)
				{
					this.m_TextItem[k].Text2.enabled = false;
					this.m_TextItem[k].Text2.enabled = true;
				}
			}
		}
		if (this.m_ScrollObj != null)
		{
			for (int l = 0; l < this.m_ScrollObj.Length; l++)
			{
				if (this.m_ScrollObj[l].PanelItem != null)
				{
					for (int m = 0; m < this.m_ScrollObj[l].PanelItem.Length; m++)
					{
						if (this.m_ScrollObj[l].PanelItem[m].HeroBtn != null && this.m_ScrollObj[l].PanelItem[m].HeroBtn.enabled)
						{
							this.m_ScrollObj[l].PanelItem[m].HeroBtn.Refresh_FontTexture();
						}
						if (this.m_ScrollObj[l].PanelItem[m].MaxNumText != null && this.m_ScrollObj[l].PanelItem[m].MaxNumText != null)
						{
							this.m_ScrollObj[l].PanelItem[m].MaxNumText.enabled = false;
							this.m_ScrollObj[l].PanelItem[m].MaxNumText.enabled = true;
						}
						if (this.m_ScrollObj[l].PanelItem[m].ArmsText != null && this.m_ScrollObj[l].PanelItem[m].ArmsText != null)
						{
							this.m_ScrollObj[l].PanelItem[m].ArmsText.enabled = false;
							this.m_ScrollObj[l].PanelItem[m].ArmsText.enabled = true;
						}
					}
				}
			}
		}
		if (this.m_BattleHero != null)
		{
			for (int n = 0; n < this.m_BattleHero.Length; n++)
			{
				if (this.m_BattleHero[n] != null)
				{
					this.m_BattleHero[n].Refresh_FontTexture();
				}
			}
		}
		if (this.m_MoveHero != null)
		{
			for (int num = 0; num < this.m_MoveHero.Length; num++)
			{
				if (this.m_MoveHero[num] != null)
				{
					this.m_MoveHero[num].Refresh_FontTexture();
				}
			}
		}
	}

	// Token: 0x06001C58 RID: 7256 RVA: 0x0031F1A0 File Offset: 0x0031D3A0
	private void InitUI()
	{
		this.m_SpritesArray = base.transform.GetComponent<UISpritesArray>();
		this.m_AutoBtn = base.transform.GetChild(4).GetChild(3).GetComponent<UIButton>();
		this.m_AutoBtn.m_Handler = this;
		this.m_AutoBtn.m_BtnID1 = 998;
		this.m_AutoText = base.transform.GetChild(4).GetChild(3).GetChild(0).GetComponent<UIText>();
		this.m_AutoText.font = this.TTF;
		UIButton component = base.transform.GetChild(4).GetChild(4).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 1000;
		this.m_BtnText = base.transform.GetChild(4).GetChild(4).GetChild(1).GetComponent<UIText>();
		this.m_BtnText.font = this.TTF;
		this.m_BtnText.text = this.DM.mStringTable.GetStringByID(189u);
		this.m_BtnLeaderImageTf = base.transform.GetChild(4).GetChild(4).GetChild(0);
		Image component2 = base.transform.GetChild(5).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close_base");
		component2.material = this.door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX && component2)
		{
			component2.enabled = false;
		}
		component = base.transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
		component.image.sprite = this.door.LoadSprite("UI_main_close");
		component.image.material = this.door.LoadMaterial();
		component.m_BtnID1 = 999;
		component.m_Handler = this;
		for (int i = 0; i < 5; i++)
		{
			this.m_BattleHero[i] = base.transform.GetChild(1).GetChild(i).GetChild(1).GetComponent<UIHIBtn>();
			this.m_BattleHero[i].m_Handler = this;
			this.m_BattleHero[i].m_BtnID1 = i;
			this.GM.InitianHeroItemImg(this.m_BattleHero[i].transform, eHeroOrItem.Hero, 0, 0, 0, 0, true, false, true, false);
			this.m_MoveHero[i] = base.transform.GetChild(1).GetChild(i + 5).GetComponent<UIHIBtn>();
			this.GM.InitianHeroItemImg(this.m_MoveHero[i].transform, eHeroOrItem.Hero, 0, 0, 0, 0, true, false, true, false);
			this.m_TweenAlpha[i] = base.transform.GetChild(1).GetChild(i).GetChild(4).GetComponent<uTweenAlpha>();
			this.m_TweenAlphaImage[i] = base.transform.GetChild(1).GetChild(i).GetChild(4).GetComponent<Image>();
			this.m_TweenAlphaImage[i].enabled = false;
			this.m_BattleHeroPlus[i] = base.transform.GetChild(1).GetChild(i).GetChild(2).GetComponent<Image>();
			this.m_BattleHeroLock[i] = base.transform.GetChild(1).GetChild(i).GetChild(3).GetComponent<Image>();
			component = base.transform.GetChild(1).GetChild(i).GetChild(3).GetComponent<UIButton>();
			component.m_BtnID1 = 997;
			component.m_Handler = this;
			if (i < (int)this.m_BattleHeroNum)
			{
				this.m_BattleHeroPlus[i].enabled = true;
				this.m_BattleHeroLock[i].enabled = false;
			}
			else
			{
				this.m_BattleHeroPlus[i].enabled = false;
				this.m_BattleHeroLock[i].enabled = true;
			}
		}
		this.m_LeaderImageTf = base.transform.GetChild(1).GetChild(10);
		this.m_ScrollObj = new ScrollPanelObject[8];
		for (int j = 0; j < 8; j++)
		{
			this.m_ScrollObj[j].PanelItem = new SoldierPanelObject[2];
		}
		this.m_TextItem = new TextItem[12];
		for (int k = 0; k < 12; k++)
		{
			this.m_TextItem[k].Text1Str = StringManager.Instance.SpawnString(30);
			this.m_TextItem[k].Text2Str = StringManager.Instance.SpawnString(30);
		}
		this.m_MaxNumText = base.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<UIText>();
		this.m_MaxNumText.font = this.TTF;
		this.m_MaxNumStr.ClearString();
		UIButtonHint uibuttonHint = base.transform.GetChild(4).GetChild(1).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_Handler = this;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.m_SkillHintPanel = base.transform.GetChild(10);
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
		for (int l = 0; l < 4; l++)
		{
			this.m_SkillImage[l] = this.m_SkillHintPanel.GetChild(l + 1).GetChild(1).GetComponent<Image>();
			this.m_SkillFrame[l] = this.m_SkillHintPanel.GetChild(l + 1).GetChild(1).GetChild(0).GetComponent<Image>();
			this.m_SkliiNameText[l] = this.m_SkillHintPanel.GetChild(l + 1).GetChild(2).GetComponent<UIText>();
			this.m_SkliiNameText[l].font = this.TTF;
			this.m_SkillInfoText[l] = this.m_SkillHintPanel.GetChild(l + 1).GetChild(3).GetComponent<UIText>();
			this.m_SkillInfoText[l].font = this.TTF;
			this.m_SkillMaskTf[l] = this.m_SkillHintPanel.GetChild(l + 1).GetChild(4);
		}
		this.m_ItemPanel = base.transform.GetChild(3);
		UIHIBtn component3 = this.m_ItemPanel.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIHIBtn>();
		this.GM.InitianHeroItemImg(component3.transform, eHeroOrItem.Hero, 1, 0, 0, 0, true, false, true, false);
		component3 = this.m_ItemPanel.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component4 = this.m_ItemPanel.GetChild(0).GetChild(0).GetChild(7).GetComponent<RectTransform>();
			Vector3 localScale = component4.localScale;
			localScale.x = -1f;
			component4.localScale = localScale;
			component4 = this.m_ItemPanel.GetChild(0).GetChild(1).GetChild(7).GetComponent<RectTransform>();
			localScale = component4.localScale;
			localScale.x = -1f;
			component4.localScale = localScale;
		}
		this.GM.InitianHeroItemImg(component3.transform, eHeroOrItem.Hero, 1, 0, 0, 0, true, false, true, false);
		uibuttonHint = this.m_ItemPanel.GetChild(0).GetChild(0).GetChild(0).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_Handler = this;
		uibuttonHint = this.m_ItemPanel.GetChild(0).GetChild(1).GetChild(0).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_Handler = this;
		this.m_IconHintPanel = base.transform.GetChild(8);
		component2 = this.m_IconHintPanel.GetComponent<Image>();
		component2.type = Image.Type.Sliced;
		component2.sprite = this.door.LoadSprite("UI_main_box_012");
		component2.material = this.door.LoadMaterial();
		this.m_tmptext[this.mTextCount] = this.m_IconHintPanel.GetChild(0).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		if (this.m_OpenType == 1)
		{
			component2.rectTransform.sizeDelta = new Vector2(330f, 88f);
			this.m_tmptext[this.mTextCount].rectTransform.sizeDelta = new Vector2(280f, 78f);
			this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(816u);
		}
		else
		{
			this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(713u);
		}
		this.mTextCount++;
		this.m_EmptyStr = base.transform.GetChild(9).GetComponent<UIText>();
		this.m_EmptyStr.font = this.TTF;
		this.m_EmptyStr.resizeTextForBestFit = true;
		this.m_EmptyStr.resizeTextMaxSize = 22;
		this.m_EmptyStr.resizeTextMinSize = 10;
		this.m_EmptyStr.rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
		this.m_EmptyStr.rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
		this.m_EmptyStr.rectTransform.pivot = new Vector2(0f, 1f);
		this.m_EmptyStr.text = this.DM.mStringTable.GetStringByID(714u);
		Vector2 sizeDelta = this.m_EmptyStr.rectTransform.sizeDelta;
		sizeDelta.y = this.m_EmptyStr.preferredHeight;
		this.m_EmptyStr.rectTransform.sizeDelta = sizeDelta;
		this.m_EmptyStr.rectTransform.anchoredPosition = new Vector2(169f, 163f);
		this.m_tmptext[this.mTextCount] = this.m_ItemPanel.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(341u);
		this.mTextCount++;
		this.m_LockText = base.transform.GetChild(11);
		this.m_tmptext[this.mTextCount] = this.m_LockText.GetChild(0).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(726u);
		this.m_tmptext[this.mTextCount].color = new Color(0.811f, 0.662f, 0.447f, 1f);
		this.mTextCount++;
		this.m_ScrollPanel = base.transform.GetChild(2).GetComponent<ScrollPanel>();
		this.m_EffScrollPanel = base.transform.GetChild(4).GetChild(2).GetChild(0).GetComponent<ScrollPanel>();
		this.InitData();
		UIButtonHint.scrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
		this.CheckAutoSelectText();
	}

	// Token: 0x06001C59 RID: 7257 RVA: 0x0031FDA8 File Offset: 0x0031DFA8
	private void InitData()
	{
		this.SetData();
		List<float> list = new List<float>();
		for (int i = 0; i < this.m_Data.Count; i++)
		{
			list.Add(this.m_Data[i].Height);
		}
		this.m_ScrollPanel.IntiScrollPanel(403f, 10f, 6f, list, 8, this);
		list.Clear();
		for (int j = 0; j < this.m_EffetData.Count; j++)
		{
			if (this.m_EffetData[j].Type == 2)
			{
				list.Add(60f);
			}
			else
			{
				list.Add(this.m_EffetData[j].TextHeight);
			}
		}
		this.m_EffScrollPanel.IntiScrollPanel(284f, 0f, 0f, list, 12, this);
		if (list.Count == 0)
		{
			this.m_EmptyStr.gameObject.SetActive(true);
		}
		if (this.m_OpenType == 1)
		{
			this.m_LockText.gameObject.SetActive(true);
		}
		else
		{
			this.m_LockText.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001C5A RID: 7258 RVA: 0x0031FEE8 File Offset: 0x0031E0E8
	private void SetData()
	{
		SoldierScrollItem soldierScrollItem = null;
		this.DM.SetSortNonFightHeroID();
		this.DM.SetSortFightHeroID();
		bool flag = false;
		int num = 0;
		while ((long)num < (long)((ulong)this.DM.NonFightHeroCount))
		{
			int num2 = num % 2;
			uint num3 = this.DM.SortNonFightHeroID[num];
			eHeroState heroState = this.DM.GetHeroState((ushort)num3);
			if (num2 == 0)
			{
				soldierScrollItem = this.GM.m_HeroList_Soldier_ItemDataPool2.spawn();
				soldierScrollItem.Item[0].Enable = false;
				soldierScrollItem.Item[0].Type = 0;
				soldierScrollItem.Item[1].Enable = false;
				soldierScrollItem.Item[1].Type = 0;
				soldierScrollItem.Item[0].HeroID = 0;
				soldierScrollItem.Item[1].HeroID = 0;
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
				if (num3 == (uint)this.DM.GetLeaderID())
				{
					soldierScrollItem.Item[num2].bIsLords = true;
				}
				else
				{
					soldierScrollItem.Item[num2].bIsLords = false;
				}
				soldierScrollItem.Item[num2].bSelect = false;
				for (int i = 0; i < this.m_BattleHeroID.Length; i++)
				{
					if (i < this.m_BattleHeroID.Length && this.m_BattleHeroID[i] != 0 && (uint)this.m_BattleHeroID[i] == num3 && heroState == eHeroState.None)
					{
						this.m_MaxNum += (uint)this.DM.RankSoldiers[(int)curHeroData.Enhance];
						soldierScrollItem.Item[num2].bSelect = true;
						flag = true;
						this.m_SelectNum++;
						if (this.m_BattleHeroID[i] == this.DM.GetLeaderID())
						{
							this.bHaveLeader = true;
						}
					}
				}
				if (this.m_OpenType == 0)
				{
					for (int j = 0; j < this.DM.LegionBattleHero.Count; j++)
					{
						if (!flag && (uint)this.DM.LegionBattleHero[j] == num3)
						{
							soldierScrollItem.Item[num2].bSelect = true;
							this.m_MaxNum += (uint)this.DM.RankSoldiers[(int)curHeroData.Enhance];
							this.GM.ChangeHeroItemImg(this.m_BattleHero[j].transform, eHeroOrItem.Hero, (ushort)num3, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
							this.m_BattleHero[j].gameObject.SetActive(true);
							this.m_BattleHeroPlus[j].enabled = false;
							this.m_BattleHeroID[j] = (ushort)num3;
							this.m_SelectNum++;
							if (this.DM.LegionBattleHero[j] == this.DM.GetLeaderID())
							{
								this.bHaveLeader = true;
							}
							break;
						}
					}
				}
				else
				{
					for (int k = 0; k < this.DM.m_DefendersID.Length; k++)
					{
						if (!flag && this.DM.m_DefendersID[k] != 0 && num3 == (uint)this.DM.m_DefendersID[k])
						{
							soldierScrollItem.Item[num2].bSelect = true;
							this.m_MaxNum += (uint)this.DM.RankSoldiers[(int)curHeroData.Enhance];
							this.GM.ChangeHeroItemImg(this.m_BattleHero[k].transform, eHeroOrItem.Hero, (ushort)num3, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
							this.m_BattleHero[k].gameObject.SetActive(true);
							this.m_BattleHeroPlus[k].enabled = false;
							this.m_BattleHeroID[k] = (ushort)num3;
							this.m_SelectNum++;
							if (this.DM.m_DefendersID[k] == this.DM.GetLeaderID())
							{
								this.bHaveLeader = true;
							}
							break;
						}
					}
				}
				soldierScrollItem.Item[num2].bIsFight = false;
				soldierScrollItem.Item[num2].Type = 0;
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
			soldierScrollItem.Height = 50f;
			this.m_Data.Add(soldierScrollItem);
		}
		int num4 = 0;
		while ((long)num4 < (long)((ulong)this.DM.FightHeroCount))
		{
			int num2 = num4 % 2;
			uint num3 = this.DM.SortFightHeroID[num4];
			eHeroState heroState = this.DM.GetHeroState((ushort)num3);
			if (num2 == 0)
			{
				soldierScrollItem = this.GM.m_HeroList_Soldier_ItemDataPool2.spawn();
				soldierScrollItem.Item[0].Enable = false;
				soldierScrollItem.Item[0].Type = 0;
				soldierScrollItem.Item[1].Enable = false;
				soldierScrollItem.Item[1].Type = 0;
				soldierScrollItem.Item[0].HeroID = 0;
				soldierScrollItem.Item[1].HeroID = 0;
			}
			soldierScrollItem.Item[num2].Type = 0;
			soldierScrollItem.Item[num2].HeroID = (ushort)num3;
			soldierScrollItem.Height = 80f;
			if (DataManager.Instance.curHeroData.ContainsKey(num3))
			{
				soldierScrollItem.Item[num2].Enable = false;
				soldierScrollItem.Item[num2].HeroID = (ushort)num3;
				Hero recordByKey = this.DM.HeroTable.GetRecordByKey((ushort)num3);
				soldierScrollItem.Item[num2].Enable = true;
				CurHeroData curHeroData = DataManager.Instance.curHeroData[num3];
				soldierScrollItem.Item[num2].Lv = curHeroData.Level;
				soldierScrollItem.Item[num2].Enhance = curHeroData.Enhance;
				soldierScrollItem.Item[num2].Arms = recordByKey.SoldierKind;
				soldierScrollItem.Item[num2].Star = curHeroData.Star;
				soldierScrollItem.Item[num2].MaxNum = this.DM.RankSoldiers[(int)curHeroData.Enhance];
				if (num3 == (uint)this.DM.GetLeaderID())
				{
					soldierScrollItem.Item[num2].bIsLords = true;
				}
				else
				{
					soldierScrollItem.Item[num2].bIsLords = false;
				}
				soldierScrollItem.Item[num2].bSelect = false;
				soldierScrollItem.Item[num2].bIsFight = true;
				soldierScrollItem.Item[num2].Type = 0;
				if (this.m_OpenType == 1)
				{
					for (int l = 0; l < this.DM.m_DefendersID.Length; l++)
					{
						if (this.DM.m_DefendersID[l] != 0 && num3 == (uint)this.DM.m_DefendersID[l])
						{
							soldierScrollItem.Item[num2].bSelect = true;
							this.m_MaxNum += (uint)this.DM.RankSoldiers[(int)curHeroData.Enhance];
							this.GM.ChangeHeroItemImg(this.m_BattleHero[l].transform, eHeroOrItem.Hero, (ushort)num3, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
							this.m_BattleHero[l].HIImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
							this.m_BattleHero[l].CircleImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
							this.m_BattleHero[l].HeroRankImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
							this.m_BattleHero[l].LvOrNum.color = new Color(0.5f, 0.5f, 0.5f, 1f);
							this.m_BattleHero[l].gameObject.SetActive(true);
							this.m_BattleHeroPlus[l].enabled = false;
							this.m_BattleHeroID[l] = (ushort)num3;
							if (heroState != eHeroState.None)
							{
								this.m_SelectNum++;
							}
							if (this.DM.m_DefendersID[l] == this.DM.GetLeaderID())
							{
								this.bHaveLeader = true;
							}
							break;
						}
					}
				}
				else if (this.m_OpenType == 0 && this.bPreselectedTeam)
				{
					for (int m = 0; m < this.DM.LegionBattleHero.Count; m++)
					{
						if (this.DM.LegionBattleHero[m] != 0 && num3 == (uint)this.DM.LegionBattleHero[m])
						{
							soldierScrollItem.Item[num2].bSelect = true;
							this.m_MaxNum += (uint)this.DM.RankSoldiers[(int)curHeroData.Enhance];
							this.GM.ChangeHeroItemImg(this.m_BattleHero[m].transform, eHeroOrItem.Hero, (ushort)num3, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
							this.m_BattleHero[m].HIImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
							this.m_BattleHero[m].CircleImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
							this.m_BattleHero[m].HeroRankImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
							this.m_BattleHero[m].LvOrNum.color = new Color(0.5f, 0.5f, 0.5f, 1f);
							this.m_BattleHero[m].gameObject.SetActive(true);
							this.m_BattleHeroPlus[m].enabled = false;
							this.m_BattleHeroID[m] = (ushort)num3;
							if (heroState != eHeroState.None)
							{
								this.m_SelectNum++;
							}
							if (this.DM.LegionBattleHero[m] == this.DM.GetLeaderID())
							{
								this.bHaveLeader = true;
							}
							break;
						}
					}
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
		this.m_MaxNumStr.ClearString();
		if (this.m_OpenType == 1)
		{
			if (this.m_MaxNum > 0u)
			{
				this.m_MaxNumText.text = this.DM.mStringTable.GetStringByID(815u);
			}
			else
			{
				this.m_MaxNumText.text = string.Empty;
			}
		}
		else
		{
			StringManager.Instance.IntToFormat((long)((ulong)this.m_MaxNum), 1, true);
			if (GUIManager.Instance.IsArabic)
			{
				this.m_MaxNumStr.AppendFormat("{0}+");
			}
			else
			{
				this.m_MaxNumStr.AppendFormat("+{0}");
			}
			this.m_MaxNumText.text = this.m_MaxNumStr.ToString();
		}
		this.SetEffectData();
		this.m_MaxNumText.SetAllDirty();
		this.m_MaxNumText.cachedTextGenerator.Invalidate();
		if (this.bHaveLeader)
		{
			this.m_BtnLeaderImageTf.gameObject.SetActive(true);
			this.m_LeaderImageTf.gameObject.SetActive(true);
			this.m_BtnText.rectTransform.anchoredPosition = new Vector2(27f, 0f);
		}
		else
		{
			this.m_BtnLeaderImageTf.gameObject.SetActive(false);
			this.m_LeaderImageTf.gameObject.SetActive(false);
			this.m_BtnText.rectTransform.anchoredPosition = new Vector2(0f, 0f);
		}
	}

	// Token: 0x06001C5B RID: 7259 RVA: 0x00320D20 File Offset: 0x0031EF20
	private void UpdateData(bool bMoveTop = true)
	{
		List<float> list = new List<float>();
		for (int i = 0; i < this.m_Data.Count; i++)
		{
			list.Add(this.m_Data[i].Height);
		}
		this.m_ScrollPanel.AddNewDataHeight(list, bMoveTop, true);
	}

	// Token: 0x06001C5C RID: 7260 RVA: 0x00320D74 File Offset: 0x0031EF74
	private void AddToMoveStack(int beginIdx, ushort heroID, Vector2 begin, Vector2 end, int endBtnIdx)
	{
		if (endBtnIdx >= 0 && endBtnIdx < 5 && beginIdx >= 0 && beginIdx < 5)
		{
			if (this.moveStack[beginIdx].bMoving)
			{
				GUIManager.Instance.AddHUDMessage("moveStack[{0}].bMoving", 255, true);
				return;
			}
			this.m_MoveHero[beginIdx].gameObject.SetActive(true);
			this.m_BattleHero[beginIdx].gameObject.SetActive(false);
			this.m_BattleHeroPlus[beginIdx].enabled = true;
			CurHeroData curHeroData = DataManager.Instance.curHeroData[(uint)heroID];
			GUIManager.Instance.ChangeHeroItemImg(this.m_MoveHero[beginIdx].transform, eHeroOrItem.Hero, heroID, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
			GUIManager.Instance.ChangeHeroItemImg(this.m_BattleHero[endBtnIdx].transform, eHeroOrItem.Hero, heroID, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
			this.m_MoveHero[beginIdx].gameObject.GetComponent<RectTransform>().anchoredPosition = begin;
			this.m_BattleHero[endBtnIdx].gameObject.SetActive(false);
			this.moveStack[beginIdx].heroID = heroID;
			this.moveStack[beginIdx].begin = begin;
			this.moveStack[beginIdx].end = end;
			this.moveStack[beginIdx].battleBtnIdx = endBtnIdx;
			this.moveStack[beginIdx].bMoving = true;
			this.MoveBtnCount++;
		}
	}

	// Token: 0x06001C5D RID: 7261 RVA: 0x00320EEC File Offset: 0x0031F0EC
	private void RemoveBattleHero(int index)
	{
		if (!this.bCanClick || this.MoveBtnCount > 0)
		{
			return;
		}
		for (int i = index; i < this.m_SelectNum - 1; i++)
		{
			Vector2 anchoredPosition = this.m_BattleHero[i + 1].transform.parent.GetComponent<RectTransform>().anchoredPosition;
			Vector2 anchoredPosition2 = this.m_BattleHero[i].transform.parent.GetComponent<RectTransform>().anchoredPosition;
			this.AddToMoveStack(i + 1, this.m_BattleHeroID[i + 1], anchoredPosition, anchoredPosition2, i);
			this.m_BattleHeroID[i] = this.m_BattleHeroID[i + 1];
			this.m_BattleHero[i].m_BtnID2 = this.m_BattleHero[i + 1].m_BtnID2;
			this.m_BattleHero[i].m_BtnID3 = this.m_BattleHero[i + 1].m_BtnID3;
		}
		this.m_SelectNum--;
		this.m_BattleHeroID[this.m_SelectNum] = 0;
		this.m_BattleHero[this.m_SelectNum].gameObject.SetActive(false);
		this.m_BattleHeroPlus[this.m_SelectNum].enabled = true;
	}

	// Token: 0x06001C5E RID: 7262 RVA: 0x00321010 File Offset: 0x0031F210
	private void Update()
	{
		this.bMoving = false;
		for (int i = 0; i < this.moveStack.Length; i++)
		{
			if (this.moveStack[i].bMoving)
			{
				this.bMoving = true;
				Vector2 vector = Vector2.MoveTowards(this.moveStack[i].begin, this.moveStack[i].end, 2000f * Time.deltaTime);
				this.m_MoveHero[i].GetComponent<RectTransform>().anchoredPosition = vector;
				this.moveStack[i].begin = vector;
				if (this.moveStack[i].begin == this.moveStack[i].end)
				{
					this.m_BattleHero[this.moveStack[i].battleBtnIdx].gameObject.SetActive(true);
					this.m_BattleHeroPlus[this.moveStack[i].battleBtnIdx].enabled = false;
					this.m_MoveHero[i].gameObject.SetActive(false);
					this.moveStack[i].bMoving = false;
					this.MoveBtnCount--;
				}
			}
		}
		for (int j = 0; j < 5; j++)
		{
			if (this.m_TweenAlphaImage[j] != null && this.m_TweenAlphaImage[j].enabled)
			{
				this.m_ColorTick[j] += Time.deltaTime;
				if (this.m_ColorTick[j] >= 0.01f)
				{
					this.m_ColorA[j] -= 0.02f;
					this.m_TweenAlphaImage[j].color = new Color(1f, 1f, 1f, this.m_ColorA[j]);
					if (this.m_ColorA[j] < 0f)
					{
						this.m_ColorA[j] = 1f;
						this.m_TweenAlphaImage[j].enabled = false;
					}
					this.m_ColorTick[j] = 0f;
				}
			}
		}
	}

	// Token: 0x06001C5F RID: 7263 RVA: 0x00321204 File Offset: 0x0031F404
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		Transform[] array = new Transform[2];
		bool[] array2 = new bool[]
		{
			true,
			true
		};
		if (panelId == 1)
		{
			if (dataIdx < this.m_EffetData.Count)
			{
				if (this.m_TextItem[panelObjectIdx].Text1 == null)
				{
					this.m_TextItem[panelObjectIdx].Text1 = item.transform.GetChild(0).GetComponent<UIText>();
					this.m_TextItem[panelObjectIdx].Text2 = item.transform.GetChild(1).GetComponent<UIText>();
					this.m_TextItem[panelObjectIdx].Text2.rectTransform.sizeDelta = new Vector2(80f, 30f);
					this.m_TextItem[panelObjectIdx].Text1.rectTransform.anchoredPosition = new Vector2(5f, 0f);
					this.m_TextItem[panelObjectIdx].Text1.rectTransform.sizeDelta = new Vector2(156f, 30f);
					this.m_TextItem[panelObjectIdx].Text1.resizeTextForBestFit = true;
					this.m_TextItem[panelObjectIdx].Text1.resizeTextMaxSize = 20;
					this.m_TextItem[panelObjectIdx].Text1.resizeTextMinSize = 10;
					this.m_TextItem[panelObjectIdx].Text2.resizeTextForBestFit = true;
					this.m_TextItem[panelObjectIdx].Text2.resizeTextMaxSize = 20;
					this.m_TextItem[panelObjectIdx].Text2.resizeTextMinSize = 10;
					this.m_TextItem[panelObjectIdx].Text1.font = this.TTF;
					this.m_TextItem[panelObjectIdx].Text2.font = this.TTF;
				}
				if (this.m_EffetData[dataIdx].Type == 0)
				{
					this.m_TextItem[panelObjectIdx].Text1.rectTransform.sizeDelta = new Vector2(148.7f, 30f);
					this.m_TextItem[panelObjectIdx].Text1.alignment = TextAnchor.MiddleLeft;
					this.m_TextItem[panelObjectIdx].Text1Str.ClearString();
					this.m_TextItem[panelObjectIdx].Text2Str.ClearString();
					GameConstants.GetEffectValue(this.m_TextItem[panelObjectIdx].Text1Str, this.m_EffetData[dataIdx].EffectID, (uint)this.m_EffetData[dataIdx].Value, 8, 0f);
					GameConstants.GetEffectValue(this.m_TextItem[panelObjectIdx].Text2Str, this.m_EffetData[dataIdx].EffectID, 0u, 5, this.m_EffetData[dataIdx].Value);
					this.m_TextItem[panelObjectIdx].Text1.text = this.m_TextItem[panelObjectIdx].Text1Str.ToString();
					this.m_TextItem[panelObjectIdx].Text2.text = this.m_TextItem[panelObjectIdx].Text2Str.ToString();
					Vector2 sizeDelta = this.m_TextItem[panelObjectIdx].Text1.rectTransform.sizeDelta;
					sizeDelta.y = this.m_EffetData[dataIdx].TextHeight;
					this.m_TextItem[panelObjectIdx].Text1.rectTransform.sizeDelta = sizeDelta;
					this.m_TextItem[panelObjectIdx].Text1.SetAllDirty();
					this.m_TextItem[panelObjectIdx].Text1.cachedTextGeneratorForLayout.Invalidate();
					this.m_TextItem[panelObjectIdx].Text1.cachedTextGenerator.Invalidate();
					this.m_TextItem[panelObjectIdx].Text1.UpdateArabicPos();
					this.m_TextItem[panelObjectIdx].Text2.SetAllDirty();
					this.m_TextItem[panelObjectIdx].Text2.cachedTextGenerator.Invalidate();
					this.m_TextItem[panelObjectIdx].Text2.UpdateArabicPos();
				}
				else if (this.m_EffetData[dataIdx].Type == 1)
				{
					this.m_TextItem[panelObjectIdx].Text1.rectTransform.sizeDelta = new Vector2(222.65f, 30f);
					this.m_TextItem[panelObjectIdx].Text1.alignment = TextAnchor.MiddleCenter;
					this.m_TextItem[panelObjectIdx].Text2Str.ClearString();
					this.m_TextItem[panelObjectIdx].Text2.text = this.m_TextItem[panelObjectIdx].Text2Str.ToString();
					this.m_TextItem[panelObjectIdx].Text2.SetAllDirty();
					this.m_TextItem[panelObjectIdx].Text2.cachedTextGenerator.Invalidate();
					this.m_TextItem[panelObjectIdx].Text1.text = this.DM.mStringTable.GetStringByID((uint)this.m_EffetData[dataIdx].EffectID);
				}
				else if (this.m_EffetData[dataIdx].Type == 2)
				{
					this.m_TextItem[panelObjectIdx].Text1.rectTransform.sizeDelta = new Vector2(222.65f, 60f);
					this.m_TextItem[panelObjectIdx].Text1.alignment = TextAnchor.MiddleLeft;
					this.m_TextItem[panelObjectIdx].Text2Str.ClearString();
					this.m_TextItem[panelObjectIdx].Text2.text = this.m_TextItem[panelObjectIdx].Text2Str.ToString();
					this.m_TextItem[panelObjectIdx].Text2.SetAllDirty();
					this.m_TextItem[panelObjectIdx].Text2.cachedTextGenerator.Invalidate();
					this.m_TextItem[panelObjectIdx].Text1.text = this.DM.mStringTable.GetStringByID((uint)this.m_EffetData[dataIdx].EffectID);
					Vector2 sizeDelta2 = this.m_TextItem[panelObjectIdx].Text1.rectTransform.sizeDelta;
					sizeDelta2.y = this.m_TextItem[panelObjectIdx].Text1.preferredHeight;
					this.m_TextItem[panelObjectIdx].Text1.rectTransform.sizeDelta = sizeDelta2;
				}
			}
		}
		else
		{
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
					UIButtonHint component3 = array[i].GetChild(0).GetComponent<UIButtonHint>();
					component3.m_Handler = this;
					component3.m_eHint = EUIButtonHint.Slider;
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
					UIText component4 = this.m_ScrollObj[panelObjectIdx].Line.GetChild(0).GetComponent<UIText>();
					component4.font = this.TTF;
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
						this.m_ScrollObj[panelObjectIdx].PanelItem[j].ArmsText.SetAllDirty();
						this.m_ScrollObj[panelObjectIdx].PanelItem[j].ArmsText.cachedTextGenerator.Invalidate();
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
						if (this.m_Data[dataIdx].Item[j].bSelect || this.m_Data[dataIdx].Item[j].bIsFight)
						{
							this.m_ScrollObj[panelObjectIdx].PanelItem[j].MaskImage.enabled = true;
							this.m_ScrollObj[panelObjectIdx].PanelItem[j].SelectImage.enabled = false;
							this.m_ScrollObj[panelObjectIdx].PanelItem[j].FightImage.enabled = false;
							if (this.m_Data[dataIdx].Item[j].bSelect)
							{
								this.m_ScrollObj[panelObjectIdx].PanelItem[j].SelectImage.enabled = true;
							}
							if (this.m_Data[dataIdx].Item[j].bIsFight)
							{
								this.m_ScrollObj[panelObjectIdx].PanelItem[j].FightImage.enabled = true;
								if (this.m_Data[dataIdx].Item[j].bIsLords)
								{
									if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Captured)
									{
										this.m_ScrollObj[panelObjectIdx].PanelItem[j].FightImage.sprite = this.m_SpritesArray.GetSprite(5);
									}
									else if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
									{
										this.m_ScrollObj[panelObjectIdx].PanelItem[j].FightImage.sprite = this.m_SpritesArray.GetSprite(4);
									}
									else if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Dead)
									{
										this.m_ScrollObj[panelObjectIdx].PanelItem[j].FightImage.sprite = this.m_SpritesArray.GetSprite(6);
									}
								}
								else
								{
									this.m_ScrollObj[panelObjectIdx].PanelItem[j].FightImage.sprite = this.m_SpritesArray.GetSprite(4);
								}
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
	}

	// Token: 0x06001C60 RID: 7264 RVA: 0x0032243C File Offset: 0x0032063C
	private Sprite GetEnhanceIcon(byte Enhance)
	{
		this.m_SpriteStr.ClearString();
		StringManager.Instance.IntToFormat((long)(Enhance + 100), 1, false);
		this.m_SpriteStr.AppendFormat("hf{0}");
		return GUIManager.Instance.LoadSprite("UI_frame", this.m_SpriteStr);
	}

	// Token: 0x06001C61 RID: 7265 RVA: 0x0032248C File Offset: 0x0032068C
	private Material GetEnhanceMat()
	{
		return GUIManager.Instance.GetFrameMaterial();
	}

	// Token: 0x06001C62 RID: 7266 RVA: 0x00322498 File Offset: 0x00320698
	private Sprite GetArmsIcon(byte arms)
	{
		return this.m_SpritesArray.GetSprite((int)arms);
	}

	// Token: 0x06001C63 RID: 7267 RVA: 0x003224A8 File Offset: 0x003206A8
	private string GetArmsStr(byte arms)
	{
		return DataManager.Instance.mStringTable.GetStringByID(3841u + (uint)arms);
	}

	// Token: 0x06001C64 RID: 7268 RVA: 0x003224C0 File Offset: 0x003206C0
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001C65 RID: 7269 RVA: 0x003224C4 File Offset: 0x003206C4
	public void OnHIButtonClick(UIHIBtn sender)
	{
		int btnID = sender.m_BtnID1;
		int index = 0;
		int num = 0;
		for (int i = 0; i < this.m_Data.Count; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				if (this.m_Data[i].Item[j].HeroID == this.m_BattleHeroID[btnID])
				{
					index = i;
					num = j;
					break;
				}
			}
		}
		if (!this.bMoving && this.m_Data[index].Item[num].bSelect)
		{
			uint heroID = (uint)this.m_Data[index].Item[num].HeroID;
			if (this.m_OpenType == 0)
			{
				if (heroID == (uint)this.DM.GetLeaderID())
				{
					this.bHaveLeader = false;
				}
			}
			else if (heroID == (uint)this.DM.GetLeaderID())
			{
				this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(725u), 255, true);
				return;
			}
			CurHeroData curHeroData = DataManager.Instance.curHeroData[heroID];
			this.m_Data[index].Item[num].bSelect = false;
			this.m_Data[index].Item[num].Type = 0;
			this.m_MaxNum -= (uint)this.DM.RankSoldiers[(int)curHeroData.Enhance];
			this.m_TweenAlphaImage[btnID].enabled = false;
			this.m_TweenAlphaImage[btnID].color = new Color(1f, 1f, 1f, 0f);
			this.RemoveBattleHero(btnID);
			this.m_BattleHero[btnID].gameObject.SetActive(false);
			this.m_BattleHeroPlus[btnID].enabled = true;
			if (this.bHaveLeader)
			{
				this.m_BtnLeaderImageTf.gameObject.SetActive(true);
				this.m_LeaderImageTf.gameObject.SetActive(true);
				this.m_BtnText.rectTransform.anchoredPosition = new Vector2(27f, 0f);
			}
			else
			{
				this.m_BtnLeaderImageTf.gameObject.SetActive(false);
				this.m_LeaderImageTf.gameObject.SetActive(false);
				this.m_BtnText.rectTransform.anchoredPosition = new Vector2(0f, 0f);
			}
			this.m_MaxNumStr.ClearString();
			if (this.m_OpenType == 1)
			{
				if (this.m_MaxNum > 0u)
				{
					this.m_MaxNumText.text = this.DM.mStringTable.GetStringByID(815u);
				}
				else
				{
					this.m_MaxNumText.text = string.Empty;
				}
			}
			else
			{
				StringManager.Instance.IntToFormat((long)((ulong)this.m_MaxNum), 1, true);
				if (GUIManager.Instance.IsArabic)
				{
					this.m_MaxNumStr.AppendFormat("{0}+");
				}
				else
				{
					this.m_MaxNumStr.AppendFormat("+{0}");
				}
				this.m_MaxNumText.text = this.m_MaxNumStr.ToString();
			}
			this.SetEffectData();
			List<float> list = new List<float>();
			for (int k = 0; k < this.m_EffetData.Count; k++)
			{
				list.Add(this.m_EffetData[k].TextHeight);
			}
			this.m_EffScrollPanel.AddNewDataHeight(list, false, true);
			list.Clear();
			for (int l = 0; l < this.m_Data.Count; l++)
			{
				list.Add(this.m_Data[l].Height);
			}
			this.m_ScrollPanel.AddNewDataHeight(list, false, true);
			this.m_MaxNumText.SetAllDirty();
			this.m_MaxNumText.cachedTextGenerator.Invalidate();
			this.CheckBattleHero();
			this.CheckAutoSelectText();
		}
	}

	// Token: 0x06001C66 RID: 7270 RVA: 0x003228D4 File Offset: 0x00320AD4
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		int btnID2 = sender.m_BtnID2;
		int btnID3 = sender.m_BtnID3;
		int num = (int)this.m_BattleHeroNum - this.m_SelectNum;
		if (this.bHint)
		{
			this.bHint = false;
			this.bOnClick = false;
			return;
		}
		if (this.bOnClick || this.MoveBtnCount > 0)
		{
			this.bOnClick = false;
			return;
		}
		UIButtonHint component = sender.gameObject.GetComponent<UIButtonHint>();
		if (component != null)
		{
			sender.gameObject.GetComponent<UIButtonHint>().bCountDown = false;
			sender.gameObject.GetComponent<UIButtonHint>().m_Time = 0f;
		}
		this.bOnClick = true;
		if (btnID >= 0 && btnID < 100 && !this.bMoving)
		{
			if (this.m_OpenType == 0)
			{
				if (!this.bPreselectedTeam && this.m_Data[btnID].Item[btnID3].bIsFight)
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(708u), 255, true);
					this.bOnClick = false;
					return;
				}
			}
			else if (this.m_Data[btnID].Item[btnID3].HeroID == this.DM.GetLeaderID())
			{
				this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(725u), 255, true);
				this.bOnClick = false;
				return;
			}
			this.SetItemType(sender);
			this.CheckAutoSelectText();
		}
		else if (sender.m_BtnID1 == 997)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(330u), 255, true);
		}
		else if (sender.m_BtnID1 == 998)
		{
			int num2;
			if (this.m_OpenType == 0)
			{
				num2 = Mathf.Clamp((int)this.DM.NonFightHeroCount, 0, (int)this.m_BattleHeroNum);
			}
			else
			{
				num2 = (int)this.m_BattleHeroNum;
			}
			if (num2 == this.m_SelectNum)
			{
				this.AutoClear();
			}
			else
			{
				this.AutoSelect();
			}
			this.CheckAutoSelectText();
		}
		else if (sender.m_BtnID1 == 999)
		{
			this.door.CloseMenu(false);
		}
		else if (sender.m_BtnID1 == 1000)
		{
			if (this.m_OpenType == 0)
			{
				this.DM.LegionBattleHero.Clear();
				for (int i = 0; i < 5; i++)
				{
					if (this.m_BattleHeroID[i] != 0)
					{
						this.DM.LegionBattleHero.Add(this.m_BattleHeroID[i]);
					}
				}
				this.door.CloseMenu(false);
			}
			else
			{
				Array.Clear(this.DM.m_DefendersID, 0, this.DM.m_DefendersID.Length);
				for (int j = 0; j < 5; j++)
				{
					this.DM.m_DefendersID[j] = this.m_BattleHeroID[j];
				}
				if (this.m_BattleHeroNum > 1)
				{
					this.DM.SendDefenderID();
				}
				this.door.CloseMenu(false);
			}
		}
		this.bOnClick = false;
	}

	// Token: 0x06001C67 RID: 7271 RVA: 0x00322C2C File Offset: 0x00320E2C
	public void CheckAutoSelectText()
	{
		if (this.m_SelectNum == (int)this.m_BattleHeroNum)
		{
			this.m_AutoText.text = this.DM.mStringTable.GetStringByID(825u);
		}
		else
		{
			this.m_AutoText.text = this.DM.mStringTable.GetStringByID(824u);
		}
	}

	// Token: 0x06001C68 RID: 7272 RVA: 0x00322C90 File Offset: 0x00320E90
	public void SetEffectData()
	{
		ushort[] array = new ushort[4];
		bool flag = false;
		byte[] array2 = new byte[]
		{
			1,
			2,
			4,
			8,
			20
		};
		this.m_EffetData.Clear();
		if (this.bHaveLeader)
		{
			SkillEffect item;
			item.Type = 1;
			item.EffectID = 351;
			item.Value = 0f;
			item.TextHeight = 30f;
			this.m_EffetData.Add(item);
		}
		int num = 0;
		while (num < this.m_SelectNum && num < this.m_BattleHeroID.Length)
		{
			Hero recordByKey = this.DM.HeroTable.GetRecordByKey(this.m_BattleHeroID[num]);
			array[0] = recordByKey.GroupSkill1;
			array[1] = recordByKey.GroupSkill2;
			array[2] = recordByKey.GroupSkill3;
			array[3] = recordByKey.GroupSkill4;
			for (int i = 0; i < array.Length; i++)
			{
				Skill recordByKey2 = this.DM.SkillTable.GetRecordByKey(array[i]);
				if (this.DM.curHeroData.ContainsKey((uint)this.m_BattleHeroID[num]))
				{
					CurHeroData curHeroData = this.DM.curHeroData[(uint)this.m_BattleHeroID[num]];
					if (recordByKey2.SkillType == 11 && curHeroData.SkillLV[i] > 0 && i < curHeroData.SkillLV.Length)
					{
						if (this.m_BattleHeroID[num] != 0)
						{
							float num2 = (float)recordByKey2.HurtValue + (float)((ushort)array2[(int)(curHeroData.Star - 1)] * recordByKey2.HurtIncreaseValue) / 1000f;
							num2 *= 100f;
							SkillEffect skillEffect;
							skillEffect.Type = 0;
							skillEffect.EffectID = recordByKey2.HurtAddition;
							skillEffect.Value = num2;
							skillEffect.TextHeight = this.CalculateTextHeight(skillEffect.EffectID, 156f, this.context);
							bool flag2 = false;
							for (int j = 0; j < this.m_EffetData.Count; j++)
							{
								if (this.m_EffetData[j].EffectID == skillEffect.EffectID && this.m_EffetData[j].Type == 0)
								{
									skillEffect.Value += this.m_EffetData[j].Value;
									this.m_EffetData[j] = skillEffect;
									flag2 = true;
									break;
								}
							}
							if (!flag2)
							{
								this.m_EffetData.Add(skillEffect);
							}
							flag = true;
						}
					}
				}
			}
			num++;
		}
		if (this.m_OpenType == 0 && !flag && this.m_SelectNum > 0)
		{
			SkillEffect item2;
			item2.Type = 2;
			item2.EffectID = 814;
			item2.Value = 0f;
			item2.TextHeight = this.CalculateTextHeight(item2.EffectID, 156f, this.context);
			if (this.bHaveLeader)
			{
				this.m_EffetData.Insert(1, item2);
			}
			else
			{
				this.m_EffetData.Insert(0, item2);
			}
		}
		if (this.m_EffetData.Count == 0)
		{
			this.m_EmptyStr.gameObject.SetActive(true);
		}
		else
		{
			this.m_EmptyStr.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001C69 RID: 7273 RVA: 0x00323014 File Offset: 0x00321214
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

	// Token: 0x06001C6A RID: 7274 RVA: 0x00323394 File Offset: 0x00321594
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

	// Token: 0x06001C6B RID: 7275 RVA: 0x00323454 File Offset: 0x00321654
	private void AutoSelect()
	{
		int num = (int)this.m_BattleHeroNum - this.m_SelectNum;
		if (this.DM.NonFightHeroCount == 0u)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(875u), 255, true);
			return;
		}
		for (int i = 0; i < this.m_Data.Count; i++)
		{
			int num2 = 0;
			while (num2 < 2 && num > 0)
			{
				if (!this.m_Data[i].Item[num2].bSelect && this.m_Data[i].Item[num2].HeroID != 0)
				{
					if (this.m_OpenType != 0 || !this.m_Data[i].Item[num2].bIsFight)
					{
						this.m_Data[i].Item[num2].bSelect = true;
						this.m_MaxNum += (uint)this.m_Data[i].Item[num2].MaxNum;
						if (this.m_Data[i].Item[num2].bIsLords)
						{
							for (int j = this.m_SelectNum; j > 0; j--)
							{
								Vector2 anchoredPosition = this.m_BattleHero[j - 1].transform.parent.GetComponent<RectTransform>().anchoredPosition;
								Vector2 anchoredPosition2 = this.m_BattleHero[j].transform.parent.GetComponent<RectTransform>().anchoredPosition;
								this.AddToMoveStack(j - 1, this.m_BattleHeroID[j - 1], anchoredPosition, anchoredPosition2, j);
								this.m_BattleHeroID[j] = this.m_BattleHeroID[j - 1];
							}
							this.GM.ChangeHeroItemImg(this.m_BattleHero[0].transform, eHeroOrItem.Hero, this.m_Data[i].Item[num2].HeroID, this.m_Data[i].Item[num2].Star, this.m_Data[i].Item[num2].Enhance, (int)this.m_Data[num2].Item[num2].Lv);
							this.m_BattleHeroID[0] = this.m_Data[i].Item[num2].HeroID;
							this.m_BattleHero[0].gameObject.SetActive(true);
							this.m_BattleHeroPlus[0].enabled = false;
							this.m_TweenAlphaImage[0].enabled = true;
							if (this.m_SelectNum < (int)this.m_BattleHeroNum)
							{
								this.m_SelectNum++;
							}
							this.bHaveLeader = true;
						}
						else if (this.m_SelectNum < (int)this.m_BattleHeroNum)
						{
							this.GM.ChangeHeroItemImg(this.m_BattleHero[this.m_SelectNum].transform, eHeroOrItem.Hero, this.m_Data[i].Item[num2].HeroID, this.m_Data[i].Item[num2].Star, this.m_Data[i].Item[num2].Enhance, (int)this.m_Data[i].Item[num2].Lv);
							this.m_BattleHero[this.m_SelectNum].gameObject.SetActive(true);
							this.m_BattleHeroPlus[this.m_SelectNum].enabled = false;
							this.m_BattleHeroID[this.m_SelectNum] = this.m_Data[i].Item[num2].HeroID;
							this.m_TweenAlphaImage[this.m_SelectNum].enabled = true;
							this.m_ColorTick[this.m_SelectNum] = 0.01f;
							this.m_ColorA[this.m_SelectNum] = 1f;
							this.m_SelectNum++;
						}
						num--;
					}
				}
				num2++;
			}
		}
		this.m_MaxNumStr.ClearString();
		if (this.m_OpenType == 1)
		{
			this.m_MaxNumText.text = this.DM.mStringTable.GetStringByID(815u);
		}
		else
		{
			StringManager.Instance.IntToFormat((long)((ulong)this.m_MaxNum), 1, true);
			if (GUIManager.Instance.IsArabic)
			{
				this.m_MaxNumStr.AppendFormat("{0}+");
			}
			else
			{
				this.m_MaxNumStr.AppendFormat("+{0}");
			}
			this.m_MaxNumText.text = this.m_MaxNumStr.ToString();
		}
		this.CheckBattleHero();
		this.UpdateData(false);
		this.SetEffectData();
		this.m_MaxNumText.SetAllDirty();
		this.m_MaxNumText.cachedTextGenerator.Invalidate();
		List<float> list = new List<float>();
		for (int k = 0; k < this.m_EffetData.Count; k++)
		{
			if (this.m_EffetData[k].Type == 2)
			{
				list.Add(60f);
			}
			else
			{
				list.Add(this.m_EffetData[k].TextHeight);
			}
		}
		this.m_EffScrollPanel.AddNewDataHeight(list, false, true);
		if (this.bHaveLeader)
		{
			this.m_BtnLeaderImageTf.gameObject.SetActive(true);
			this.m_LeaderImageTf.gameObject.SetActive(true);
			this.m_BtnText.rectTransform.anchoredPosition = new Vector2(27f, 0f);
		}
		else
		{
			this.m_BtnLeaderImageTf.gameObject.SetActive(false);
			this.m_LeaderImageTf.gameObject.SetActive(false);
			this.m_BtnText.rectTransform.anchoredPosition = new Vector2(0f, 0f);
		}
	}

	// Token: 0x06001C6C RID: 7276 RVA: 0x00323A70 File Offset: 0x00321C70
	private void AutoClear()
	{
		for (int i = 0; i < this.m_Data.Count; i++)
		{
			int num = 0;
			while (num < 2 && this.m_SelectNum > 0)
			{
				if (this.m_Data[i].Item[num].bSelect && this.m_Data[i].Item[num].HeroID != 0)
				{
					if (this.m_Data[i].Item[num].HeroID == this.DM.GetLeaderID())
					{
						if (this.m_OpenType == 1)
						{
							goto IL_125;
						}
						this.bHaveLeader = false;
					}
					this.m_Data[i].Item[num].bSelect = false;
					this.m_MaxNum -= (uint)this.m_Data[i].Item[num].MaxNum;
					this.m_SelectNum--;
					this.m_BattleHeroID[this.m_SelectNum] = 0;
					this.m_BattleHero[this.m_SelectNum].gameObject.SetActive(false);
					this.m_BattleHeroPlus[this.m_SelectNum].enabled = true;
				}
				IL_125:
				num++;
			}
		}
		if (this.bHaveLeader)
		{
			this.m_BtnLeaderImageTf.gameObject.SetActive(true);
			this.m_LeaderImageTf.gameObject.SetActive(true);
			this.m_BtnText.rectTransform.anchoredPosition = new Vector2(27f, 0f);
		}
		else
		{
			this.m_BtnLeaderImageTf.gameObject.SetActive(false);
			this.m_LeaderImageTf.gameObject.SetActive(false);
			this.m_BtnText.rectTransform.anchoredPosition = new Vector2(0f, 0f);
		}
		this.m_MaxNumStr.ClearString();
		if (this.m_OpenType == 1)
		{
			this.m_MaxNumText.text = this.DM.mStringTable.GetStringByID(815u);
		}
		else
		{
			StringManager.Instance.IntToFormat((long)((ulong)this.m_MaxNum), 1, true);
			if (GUIManager.Instance.IsArabic)
			{
				this.m_MaxNumStr.AppendFormat("{0}+");
			}
			else
			{
				this.m_MaxNumStr.AppendFormat("+{0}");
			}
			this.m_MaxNumText.text = this.m_MaxNumStr.ToString();
		}
		this.UpdateData(false);
		this.SetEffectData();
		this.m_MaxNumText.SetAllDirty();
		this.m_MaxNumText.cachedTextGenerator.Invalidate();
		List<float> list = new List<float>();
		for (int j = 0; j < this.m_EffetData.Count; j++)
		{
			if (this.m_EffetData[j].Type == 2)
			{
				list.Add(60f);
			}
			else
			{
				list.Add(this.m_EffetData[j].TextHeight);
			}
		}
		this.m_EffScrollPanel.AddNewDataHeight(list, false, true);
		if (this.bHaveLeader)
		{
			this.m_BtnLeaderImageTf.gameObject.SetActive(true);
			this.m_LeaderImageTf.gameObject.SetActive(true);
			this.m_BtnText.rectTransform.anchoredPosition = new Vector2(27f, 0f);
		}
		else
		{
			this.m_BtnLeaderImageTf.gameObject.SetActive(false);
			this.m_LeaderImageTf.gameObject.SetActive(false);
			this.m_BtnText.rectTransform.anchoredPosition = new Vector2(0f, 0f);
		}
	}

	// Token: 0x06001C6D RID: 7277 RVA: 0x00323E2C File Offset: 0x0032202C
	public void OnButtonDown(UIButtonHint sender)
	{
		if (sender.m_eHint == EUIButtonHint.DownUpHandler)
		{
			this.m_IconHintPanel.gameObject.SetActive(true);
		}
		else
		{
			int btnID = sender.transform.parent.GetComponent<UIButton>().m_BtnID1;
			int btnID2 = sender.transform.parent.GetComponent<UIButton>().m_BtnID3;
			ushort heroID = this.m_Data[btnID].Item[btnID2].HeroID;
			byte enhance = this.m_Data[btnID].Item[btnID2].Enhance;
			int maxNum = (int)this.m_Data[btnID].Item[btnID2].MaxNum;
			byte arms = this.m_Data[btnID].Item[btnID2].Arms;
			this.SetSkillHint(heroID, enhance, maxNum, arms);
			this.m_SkillHintPanel.gameObject.SetActive(true);
			this.bHint = true;
		}
	}

	// Token: 0x06001C6E RID: 7278 RVA: 0x00323F24 File Offset: 0x00322124
	public void OnButtonUp(UIButtonHint sender)
	{
		if (sender.m_eHint == EUIButtonHint.DownUpHandler)
		{
			this.m_IconHintPanel.gameObject.SetActive(false);
		}
		else
		{
			sender.bCountDown = false;
			sender.m_Time = 0f;
			this.bHint = false;
			this.m_SkillHintPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001C6F RID: 7279 RVA: 0x00323F80 File Offset: 0x00322180
	public void SetItemType(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		int btnID2 = sender.m_BtnID3;
		if (btnID >= this.m_Data.Count)
		{
			return;
		}
		int selectNum = this.m_SelectNum;
		int num = (int)this.m_BattleHeroNum - this.m_SelectNum;
		if (!this.m_Data[btnID].Item[btnID2].bSelect)
		{
			if (num > 0)
			{
				if (this.m_Data[btnID].Item[btnID2].bIsLords)
				{
					for (int i = selectNum; i > 0; i--)
					{
						Vector2 anchoredPosition = this.m_BattleHero[i - 1].transform.parent.GetComponent<RectTransform>().anchoredPosition;
						Vector2 anchoredPosition2 = this.m_BattleHero[i].transform.parent.GetComponent<RectTransform>().anchoredPosition;
						this.AddToMoveStack(i - 1, this.m_BattleHeroID[i - 1], anchoredPosition, anchoredPosition2, i);
						this.m_BattleHeroID[i] = this.m_BattleHeroID[i - 1];
						this.m_BattleHero[i].m_BtnID2 = this.m_BattleHero[i - 1].m_BtnID2;
						this.m_BattleHero[i].m_BtnID3 = this.m_BattleHero[i - 1].m_BtnID3;
					}
					this.GM.ChangeHeroItemImg(this.m_BattleHero[0].transform, eHeroOrItem.Hero, this.m_Data[btnID].Item[btnID2].HeroID, this.m_Data[btnID].Item[btnID2].Star, this.m_Data[btnID].Item[btnID2].Enhance, (int)this.m_Data[btnID].Item[btnID2].Lv);
					this.m_BattleHeroID[0] = this.m_Data[btnID].Item[btnID2].HeroID;
					this.m_BattleHero[0].gameObject.SetActive(true);
					this.m_BattleHeroPlus[0].enabled = false;
					this.m_TweenAlphaImage[0].enabled = true;
					if (this.m_SelectNum < (int)this.m_BattleHeroNum)
					{
						this.m_SelectNum++;
					}
					this.bHaveLeader = true;
				}
				else if (this.m_SelectNum < (int)this.m_BattleHeroNum)
				{
					this.GM.ChangeHeroItemImg(this.m_BattleHero[this.m_SelectNum].transform, eHeroOrItem.Hero, this.m_Data[btnID].Item[btnID2].HeroID, this.m_Data[btnID].Item[btnID2].Star, this.m_Data[btnID].Item[btnID2].Enhance, (int)this.m_Data[btnID].Item[btnID2].Lv);
					this.m_BattleHero[this.m_SelectNum].gameObject.SetActive(true);
					this.m_BattleHeroPlus[this.m_SelectNum].enabled = false;
					this.m_BattleHeroID[this.m_SelectNum] = this.m_Data[btnID].Item[btnID2].HeroID;
					this.m_TweenAlphaImage[this.m_SelectNum].enabled = true;
					this.m_ColorTick[this.m_SelectNum] = 0.01f;
					this.m_ColorA[this.m_SelectNum] = 1f;
					this.m_BattleHero[this.m_SelectNum].m_BtnID2 = btnID;
					this.m_BattleHero[this.m_SelectNum].m_BtnID3 = btnID2;
					this.m_SelectNum++;
				}
				this.m_MaxNum += (uint)this.m_Data[btnID].Item[btnID2].MaxNum;
				this.m_Data[btnID].Item[btnID2].bSelect = true;
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(770u), 255, true);
			}
		}
		else
		{
			for (int j = 0; j < (int)this.m_BattleHeroNum; j++)
			{
				if (this.m_BattleHeroID[j] == this.m_Data[btnID].Item[btnID2].HeroID)
				{
					this.m_TweenAlphaImage[j].enabled = false;
					this.m_TweenAlphaImage[j].color = new Color(1f, 1f, 1f, 0f);
					this.RemoveBattleHero(j);
					if (this.m_Data[btnID].Item[btnID2].HeroID == this.DM.GetLeaderID())
					{
						this.bHaveLeader = false;
					}
				}
			}
			this.m_MaxNum -= (uint)this.m_Data[btnID].Item[btnID2].MaxNum;
			this.m_Data[btnID].Item[btnID2].bSelect = false;
		}
		this.m_MaxNumStr.ClearString();
		if (this.m_OpenType == 1)
		{
			if (this.m_MaxNum > 0u)
			{
				this.m_MaxNumText.text = this.DM.mStringTable.GetStringByID(815u);
			}
			else
			{
				this.m_MaxNumText.text = string.Empty;
			}
		}
		else
		{
			StringManager.Instance.IntToFormat((long)((ulong)this.m_MaxNum), 1, true);
			if (GUIManager.Instance.IsArabic)
			{
				this.m_MaxNumStr.AppendFormat("{0}+");
			}
			else
			{
				this.m_MaxNumStr.AppendFormat("+{0}");
			}
			this.m_MaxNumText.text = this.m_MaxNumStr.ToString();
		}
		this.SetEffectData();
		this.m_MaxNumText.SetAllDirty();
		this.m_MaxNumText.cachedTextGenerator.Invalidate();
		if (this.bHaveLeader)
		{
			this.m_BtnLeaderImageTf.gameObject.SetActive(true);
			this.m_LeaderImageTf.gameObject.SetActive(true);
			this.m_BtnText.rectTransform.anchoredPosition = new Vector2(27f, 0f);
		}
		else
		{
			this.m_BtnLeaderImageTf.gameObject.SetActive(false);
			this.m_LeaderImageTf.gameObject.SetActive(false);
			this.m_BtnText.rectTransform.anchoredPosition = new Vector2(0f, 0f);
		}
		this.CheckBattleHero();
		List<float> list = new List<float>();
		for (int k = 0; k < this.m_EffetData.Count; k++)
		{
			if (this.m_EffetData[k].Type == 2)
			{
				list.Add(60f);
			}
			else
			{
				list.Add(this.m_EffetData[k].TextHeight);
			}
		}
		this.m_EffScrollPanel.AddNewDataHeight(list, false, true);
		list.Clear();
		for (int l = 0; l < this.m_Data.Count; l++)
		{
			list.Add(this.m_Data[l].Height);
		}
		this.m_ScrollPanel.AddNewDataHeight(list, false, true);
	}

	// Token: 0x06001C70 RID: 7280 RVA: 0x003246E4 File Offset: 0x003228E4
	public void CheckBattleHero()
	{
		for (int i = 0; i < this.m_BattleHero.Length; i++)
		{
			this.m_BattleHero[i].HIImage.color = new Color(1f, 1f, 1f, 1f);
			this.m_BattleHero[i].CircleImage.color = new Color(1f, 1f, 1f, 1f);
			this.m_BattleHero[i].HeroRankImage.color = new Color(1f, 1f, 1f, 1f);
			this.m_BattleHero[i].LvOrNum.color = new Color(1f, 1f, 1f, 1f);
		}
		int num = 0;
		while ((long)num < (long)((ulong)this.DM.FightHeroID[num]))
		{
			for (int j = 0; j < this.m_BattleHero.Length; j++)
			{
				if (this.DM.FightHeroID[num] == (uint)this.m_BattleHeroID[j])
				{
					this.m_BattleHero[j].HIImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
					this.m_BattleHero[j].CircleImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
					this.m_BattleHero[j].HeroRankImage.color = new Color(0.5f, 0.5f, 0.5f, 1f);
					this.m_BattleHero[j].LvOrNum.color = new Color(0.5f, 0.5f, 0.5f, 1f);
				}
			}
			num++;
		}
	}

	// Token: 0x06001C71 RID: 7281 RVA: 0x003248B8 File Offset: 0x00322AB8
	public float CalculateTextHeight(ushort meffectId, float width, UIText context)
	{
		int num = 20;
		context.fontSize = num;
		context.font = this.TTF;
		context.resizeTextForBestFit = true;
		context.resizeTextMaxSize = num;
		context.resizeTextMinSize = 10;
		context.rectTransform.sizeDelta = new Vector2(width, 30f);
		Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(meffectId);
		context.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.InfoID);
		context.SetAllDirty();
		context.cachedTextGeneratorForLayout.Invalidate();
		return Mathf.Clamp(context.preferredHeight + 2f, 25f, context.preferredHeight + 2f);
	}

	// Token: 0x040055CE RID: 21966
	private const int m_MaxTextObj = 12;

	// Token: 0x040055CF RID: 21967
	private const int m_MaxPanelObject = 8;

	// Token: 0x040055D0 RID: 21968
	private const int TextMax = 3;

	// Token: 0x040055D1 RID: 21969
	private Transform m_ItemPanel;

	// Token: 0x040055D2 RID: 21970
	private Transform m_SkillHintPanel;

	// Token: 0x040055D3 RID: 21971
	private Transform m_LeaderImageTf;

	// Token: 0x040055D4 RID: 21972
	private Transform m_IconHintPanel;

	// Token: 0x040055D5 RID: 21973
	private Transform m_LockText;

	// Token: 0x040055D6 RID: 21974
	private Transform[] m_SkillMaskTf;

	// Token: 0x040055D7 RID: 21975
	private Transform m_BtnLeaderImageTf;

	// Token: 0x040055D8 RID: 21976
	private UIText m_BtnText;

	// Token: 0x040055D9 RID: 21977
	private UIText m_EmptyStr;

	// Token: 0x040055DA RID: 21978
	private UIText m_AutoText;

	// Token: 0x040055DB RID: 21979
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040055DC RID: 21980
	private ScrollPanel m_EffScrollPanel;

	// Token: 0x040055DD RID: 21981
	private UIButton m_AutoBtn;

	// Token: 0x040055DE RID: 21982
	private UIText m_MaxNumText;

	// Token: 0x040055DF RID: 21983
	private UISpritesArray m_SpritesArray;

	// Token: 0x040055E0 RID: 21984
	private uTweenAlpha[] m_TweenAlpha;

	// Token: 0x040055E1 RID: 21985
	private Image[] m_TweenAlphaImage;

	// Token: 0x040055E2 RID: 21986
	private UIText m_HeroNameText;

	// Token: 0x040055E3 RID: 21987
	private UIText m_HeroArmsText;

	// Token: 0x040055E4 RID: 21988
	private UIText m_HeroMaxNum;

	// Token: 0x040055E5 RID: 21989
	private Image m_HeroEnhanceIcon;

	// Token: 0x040055E6 RID: 21990
	private UIHIBtn m_HeroIcon;

	// Token: 0x040055E7 RID: 21991
	private UIText[] m_SkliiNameText;

	// Token: 0x040055E8 RID: 21992
	private UIText[] m_SkillInfoText;

	// Token: 0x040055E9 RID: 21993
	private Image[] m_SkillImage;

	// Token: 0x040055EA RID: 21994
	private Image[] m_SkillFrame;

	// Token: 0x040055EB RID: 21995
	private List<SoldierScrollItem> m_Data;

	// Token: 0x040055EC RID: 21996
	private List<SkillEffect> m_EffetData;

	// Token: 0x040055ED RID: 21997
	private ScrollPanelObject[] m_ScrollObj;

	// Token: 0x040055EE RID: 21998
	private TextItem[] m_TextItem;

	// Token: 0x040055EF RID: 21999
	private UIHIBtn[] m_BattleHero;

	// Token: 0x040055F0 RID: 22000
	private Image[] m_BattleHeroPlus;

	// Token: 0x040055F1 RID: 22001
	private Image[] m_BattleHeroLock;

	// Token: 0x040055F2 RID: 22002
	private UIHIBtn[] m_MoveHero;

	// Token: 0x040055F3 RID: 22003
	private MoveObject[] moveStack;

	// Token: 0x040055F4 RID: 22004
	private bool bCanClick;

	// Token: 0x040055F5 RID: 22005
	private int MoveBtnCount;

	// Token: 0x040055F6 RID: 22006
	private bool bCanClickbtn;

	// Token: 0x040055F7 RID: 22007
	private byte m_BattleHeroNum;

	// Token: 0x040055F8 RID: 22008
	private ushort[] m_BattleHeroID;

	// Token: 0x040055F9 RID: 22009
	private bool bMoving;

	// Token: 0x040055FA RID: 22010
	private bool bOnClick;

	// Token: 0x040055FB RID: 22011
	private int m_SelectNum;

	// Token: 0x040055FC RID: 22012
	private uint m_MaxNum;

	// Token: 0x040055FD RID: 22013
	private bool bHaveLeader;

	// Token: 0x040055FE RID: 22014
	private bool bHint;

	// Token: 0x040055FF RID: 22015
	private CString m_SpriteStr;

	// Token: 0x04005600 RID: 22016
	private CString[] m_SkillInfoStr;

	// Token: 0x04005601 RID: 22017
	private CString m_HeroMaxNumStr;

	// Token: 0x04005602 RID: 22018
	private CString m_MaxNumStr;

	// Token: 0x04005603 RID: 22019
	private float[] m_ColorTick;

	// Token: 0x04005604 RID: 22020
	private float[] m_ColorA;

	// Token: 0x04005605 RID: 22021
	private Image[] m_ColoeAImage;

	// Token: 0x04005606 RID: 22022
	private int m_OpenType;

	// Token: 0x04005607 RID: 22023
	private GUIManager GM;

	// Token: 0x04005608 RID: 22024
	private DataManager DM;

	// Token: 0x04005609 RID: 22025
	private Door door;

	// Token: 0x0400560A RID: 22026
	private Font TTF;

	// Token: 0x0400560B RID: 22027
	private UIText context;

	// Token: 0x0400560C RID: 22028
	private int mTextCount;

	// Token: 0x0400560D RID: 22029
	private UIText[] m_tmptext = new UIText[3];

	// Token: 0x0400560E RID: 22030
	private bool bPreselectedTeam;
}
