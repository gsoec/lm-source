using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002DF RID: 735
public class UIAlliance_HelpSpeedup : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIHIBtnClickHandler
{
	// Token: 0x06000EE6 RID: 3814 RVA: 0x00196DF8 File Offset: 0x00194FF8
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.IconMaterial = this.GUIM.m_IconSpriteAsset.GetMaterial();
		this.Cstr_AllianceMoney = StringManager.Instance.SpawnString(100);
		this.Cstr_ReSetTime = StringManager.Instance.SpawnString(30);
		for (int i = 0; i < 2; i++)
		{
			this.Cstr_HelpTitle[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_HelpValue[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_StrValue[i] = StringManager.Instance.SpawnString(30);
		}
		for (int j = 0; j < 6; j++)
		{
			this.Cstr_ItemHelpTitle[j] = StringManager.Instance.SpawnString(100);
			this.Cstr_ItemHelpValue[j] = StringManager.Instance.SpawnString(100);
		}
		this.Tmp = this.GameT.GetChild(1);
		this.ImgUp_RT = this.Tmp.GetChild(0).GetComponent<RectTransform>();
		this.CDTime_Img_RT = this.Tmp.GetChild(1).GetComponent<RectTransform>();
		this.btn_Info = this.Tmp.GetChild(2).GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_Info.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_Info.m_Handler = this;
		this.btn_Info.m_BtnID1 = 1;
		this.btn_Info.m_EffectType = e_EffectType.e_Scale;
		this.btn_Info.transition = Selectable.Transition.None;
		this.Hbtn_Player = this.Tmp.GetChild(3).GetComponent<UIHIBtn>();
		this.GUIM.InitianHeroItemImg(this.Hbtn_Player.transform, eHeroOrItem.Hero, this.DM.RoleAttr.Head, 11, 0, 0, false, false, true, false);
		this.Img_PlayerRank = this.Tmp.GetChild(4).GetComponent<Image>();
		if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK1)
		{
			this.Img_PlayerRank.sprite = this.SArray.m_Sprites[(int)(this.DM.RoleAlliance.Rank - AllianceRank.RANK1)];
		}
		else
		{
			this.Img_PlayerRank.sprite = this.SArray.m_Sprites[0];
		}
		if (this.GUIM.IsArabic)
		{
			this.Img_PlayerRank.transform.localScale = new Vector3(-1f, this.Img_PlayerRank.transform.localScale.y, this.Img_PlayerRank.transform.localScale.z);
		}
		this.AllianceMoney_RT = this.Tmp.GetChild(5).GetChild(0).GetComponent<RectTransform>();
		this.text_tmpStr[0] = this.Tmp.GetChild(5).GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(751u);
		this.text_tmpStr[0].rectTransform.anchoredPosition = new Vector2(-63.5f, this.text_tmpStr[0].rectTransform.anchoredPosition.y);
		this.text_tmpStr[0].rectTransform.sizeDelta = new Vector2(200f, this.text_tmpStr[0].rectTransform.sizeDelta.y);
		this.text_AllianceMoney = this.Tmp.GetChild(5).GetChild(2).GetComponent<UIText>();
		this.text_AllianceMoney.font = this.TTFont;
		this.text_AllianceMoney.resizeTextForBestFit = true;
		this.Cstr_AllianceMoney.ClearString();
		this.DM.DailyHelpGetAllianceMoney = (uint)Mathf.Clamp(this.DM.DailyHelpGetAllianceMoney, 0f, (float)(40000 * (this.DM.AllianceMoneyBonusRate / 100)));
		this.Cstr_AllianceMoney.IntToFormat((long)((ulong)this.DM.DailyHelpGetAllianceMoney), 1, true);
		this.Cstr_AllianceMoney.IntToFormat((long)(40000 * (this.DM.AllianceMoneyBonusRate / 100)), 1, true);
		if (this.GUIM.IsArabic)
		{
			if (this.DM.AllianceMoneyBonusRate > 100)
			{
				this.Cstr_AllianceMoney.AppendFormat("<color=#ffff00>{1}</color> / {0}");
			}
			else
			{
				this.Cstr_AllianceMoney.AppendFormat("{1} / {0}");
			}
		}
		else if (this.DM.AllianceMoneyBonusRate > 100)
		{
			this.Cstr_AllianceMoney.AppendFormat("{0} / <color=#ffff00>{1}</color>");
		}
		else
		{
			this.Cstr_AllianceMoney.AppendFormat("{0} / {1}");
		}
		this.text_AllianceMoney.text = this.Cstr_AllianceMoney.ToString();
		this.text_AllianceMoney.rectTransform.anchoredPosition = new Vector2(104f, this.text_AllianceMoney.rectTransform.anchoredPosition.y);
		this.text_AllianceMoney.rectTransform.sizeDelta = new Vector2(140f, this.text_AllianceMoney.rectTransform.sizeDelta.y);
		this.AllianceMoney_RT.sizeDelta = new Vector2(340u * this.DM.DailyHelpGetAllianceMoney / (float)(40000 * (this.DM.AllianceMoneyBonusRate / 100)), this.AllianceMoney_RT.sizeDelta.y);
		this.Img_BonusRate[0] = this.Tmp.GetChild(6).GetChild(0).GetComponent<Image>();
		this.Img_BonusRate[0].material = this.door.LoadMaterial();
		this.Img_BonusRate[1] = this.Tmp.GetChild(6).GetChild(1).GetComponent<Image>();
		this.Img_BonusRate[1].material = this.door.LoadMaterial();
		if (this.GUIM.IsArabic)
		{
			this.Img_BonusRate[0].gameObject.AddComponent<ArabicItemTextureRot>();
			this.Img_BonusRate[1].gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.Img_Help[0] = this.Tmp.GetChild(7).GetComponent<Image>();
		this.Img_HelpFull[0] = this.Tmp.GetChild(7).GetChild(0).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_HelpFull[0].transform.localScale = new Vector3(-1f, this.Img_HelpFull[0].transform.localScale.y, this.Img_HelpFull[0].transform.localScale.z);
		}
		this.text_Help1[0] = this.Tmp.GetChild(7).GetChild(4).GetComponent<UIText>();
		this.text_Help1[0].font = this.TTFont;
		this.Help_RT[0] = this.Tmp.GetChild(7).GetChild(1).GetComponent<RectTransform>();
		this.text_Help1[1] = this.Tmp.GetChild(7).GetChild(2).GetComponent<UIText>();
		this.text_Help1[1].font = this.TTFont;
		this.text_Help1[2] = this.Tmp.GetChild(7).GetChild(3).GetComponent<UIText>();
		this.text_Help1[2].font = this.TTFont;
		this.Img_Help[1] = this.Tmp.GetChild(8).GetComponent<Image>();
		this.Img_HelpFull[1] = this.Tmp.GetChild(8).GetChild(0).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_HelpFull[1].transform.localScale = new Vector3(-1f, this.Img_HelpFull[1].transform.localScale.y, this.Img_HelpFull[1].transform.localScale.z);
		}
		this.text_Help2[0] = this.Tmp.GetChild(8).GetChild(4).GetComponent<UIText>();
		this.text_Help2[0].font = this.TTFont;
		this.Help_RT[1] = this.Tmp.GetChild(8).GetChild(1).GetComponent<RectTransform>();
		this.text_Help2[1] = this.Tmp.GetChild(8).GetChild(2).GetComponent<UIText>();
		this.text_Help2[1].font = this.TTFont;
		this.text_Help2[2] = this.Tmp.GetChild(8).GetChild(3).GetComponent<UIText>();
		this.text_Help2[2].font = this.TTFont;
		this.NoHelp_RT = this.Tmp.GetChild(9).GetComponent<RectTransform>();
		this.text_tmpStr[1] = this.Tmp.GetChild(9).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(761u);
		if (this.text_tmpStr[1].preferredWidth > this.text_tmpStr[1].rectTransform.sizeDelta.x)
		{
			this.text_tmpStr[1].rectTransform.sizeDelta = new Vector2(this.text_tmpStr[1].preferredWidth, this.text_tmpStr[1].rectTransform.sizeDelta.y);
			RectTransform component = this.Tmp.GetChild(9).GetChild(0).GetComponent<RectTransform>();
			component.sizeDelta = new Vector2(16f + this.text_tmpStr[1].preferredWidth, component.sizeDelta.y);
		}
		this.text_PlayerName = this.Tmp.GetChild(10).GetComponent<UIText>();
		this.text_PlayerName.font = this.TTFont;
		this.text_PlayerName.text = this.DM.RoleAttr.Name.ToString();
		this.text_ReSetTime = this.Tmp.GetChild(11).GetComponent<UIText>();
		this.text_ReSetTime.font = this.TTFont;
		this.CDTime_text_RT = this.Tmp.GetChild(11).GetComponent<RectTransform>();
		this.Cstr_ReSetTime.ClearString();
		this.Cstr_ReSetTime.IntToFormat((long)GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Hour, 2, false);
		this.Cstr_ReSetTime.IntToFormat((long)GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Minute, 2, false);
		this.Cstr_ReSetTime.AppendFormat(this.DM.mStringTable.GetStringByID(753u));
		this.text_ReSetTime.text = this.Cstr_ReSetTime.ToString();
		this.text_ReSetTime.SetAllDirty();
		this.text_ReSetTime.cachedTextGenerator.Invalidate();
		this.text_ReSetTime.cachedTextGeneratorForLayout.Invalidate();
		this.CDTime_text_RT.sizeDelta = new Vector2(this.text_ReSetTime.preferredWidth, this.CDTime_text_RT.sizeDelta.y);
		this.CDTime_Img_RT.anchoredPosition = new Vector2(this.CDTime_text_RT.anchoredPosition.x - this.text_ReSetTime.preferredWidth - 8f, this.CDTime_Img_RT.anchoredPosition.y);
		this.text_tmpStr[2] = this.Tmp.GetChild(12).GetComponent<UIText>();
		this.text_tmpStr[2].font = this.TTFont;
		this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(750u);
		this.Socrll_T = this.GameT.GetChild(2);
		this.ImgScroll_RT = this.GameT.GetChild(2).GetComponent<RectTransform>();
		this.m_ScrollPanel = this.GameT.GetChild(2).GetChild(0).GetComponent<ScrollPanel>();
		this.ImgScrollPanel_RT = this.GameT.GetChild(2).GetChild(0).GetComponent<RectTransform>();
		this.Tmp = this.GameT.GetChild(2).GetChild(1);
		this.tmptext = this.Tmp.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext = this.Tmp.GetChild(0).GetChild(1).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmpImg = this.Tmp.GetChild(1).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.tmpImg.transform.localScale = new Vector3(-1f, this.tmpImg.transform.localScale.y, this.tmpImg.transform.localScale.z);
		}
		this.tmptext = this.Tmp.GetChild(2).GetChild(1).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext = this.Tmp.GetChild(2).GetChild(2).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmpbtn = this.Tmp.GetChild(3).GetComponent<UIButton>();
		this.tmpbtn.m_Handler = this;
		this.tmpbtn.m_BtnID1 = 3;
		this.tmpbtn.SoundIndex = 64;
		this.tmpbtn.m_EffectType = e_EffectType.e_Scale;
		this.tmpbtn.transition = Selectable.Transition.None;
		this.text_tmpStr[3] = this.Tmp.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[3].font = this.TTFont;
		this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(759u);
		this.tmpHbtn = this.Tmp.GetChild(4).GetComponent<UIHIBtn>();
		this.tmpHbtn.m_Handler = this;
		this.tmpHbtn.image.material = this.IconMaterial;
		this.GUIM.InitianHeroItemImg(this.tmpHbtn.transform, eHeroOrItem.Hero, 0, 11, 0, 0, false, false, true, false);
		this.btn_AllHelp = this.GameT.GetChild(3).GetComponent<UIButton>();
		this.btn_AllHelp.m_Handler = this;
		this.btn_AllHelp.m_BtnID1 = 2;
		this.btn_AllHelp.m_EffectType = e_EffectType.e_Scale;
		this.btn_AllHelp.transition = Selectable.Transition.None;
		this.text_tmpStr[4] = this.GameT.GetChild(3).GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[4].font = this.TTFont;
		this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(760u);
		this.Img_BonusRate[2] = this.GameT.GetChild(5).GetComponent<Image>();
		this.Img_BonusRate[2].sprite = this.door.LoadSprite("UI_mall_x_001");
		this.Img_BonusRate[2].material = this.door.LoadMaterial();
		this.Img_BonusRate[3] = this.GameT.GetChild(5).GetChild(0).GetComponent<Image>();
		this.Img_BonusRate[3].material = this.door.LoadMaterial();
		this.Img_BonusRate[4] = this.GameT.GetChild(5).GetChild(1).GetComponent<Image>();
		this.Img_BonusRate[4].material = this.door.LoadMaterial();
		if (this.DM.AllianceMoneyBonusRate > 100 && this.DM.AllianceMoneyBonusRate <= 400)
		{
			this.Cstr_StrValue[0].ClearString();
			this.Cstr_StrValue[0].IntToFormat((long)(this.DM.AllianceMoneyBonusRate / 100), 1, false);
			this.Cstr_StrValue[0].AppendFormat("UI_mall_{0}_001");
			if (this.GUIM.IsArabic)
			{
				this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_x_001");
				this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_x_001");
				this.Img_BonusRate[1].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
				this.Img_BonusRate[4].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
			}
			else
			{
				this.Img_BonusRate[0].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
				this.Img_BonusRate[3].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
				this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_x_001");
				this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_x_001");
			}
		}
		else if (this.GUIM.IsArabic)
		{
			this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_x_001");
			this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_x_001");
			this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_2_001");
			this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_2_001");
		}
		else
		{
			this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_2_001");
			this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_2_001");
			this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_x_001");
			this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_x_001");
		}
		if (this.GUIM.IsArabic)
		{
			this.Img_BonusRate[3].gameObject.AddComponent<ArabicItemTextureRot>();
			this.Img_BonusRate[4].gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.CheckHelpChang();
		this.UpdatePanel(true);
		this.tmpImg = this.GameT.GetChild(6).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
		this.tmpImg.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(6).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.door.LoadMaterial();
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06000EE7 RID: 3815 RVA: 0x001981F8 File Offset: 0x001963F8
	public void CheckHelpChang()
	{
		this.mType = 0;
		int num = 0;
		for (int i = 0; i < 2; i++)
		{
			switch (this.DM.mPlayHelpDataType[i].Kind)
			{
			case 1:
				if (this.DM.mPlayHelpDataType[i].HelpMax != 0 && this.DM.mPlayHelpDataType[i].AlreadyHelperNum == this.DM.mPlayHelpDataType[i].HelpMax)
				{
					this.mType++;
					this.Help_RT[num].gameObject.SetActive(true);
					num++;
				}
				break;
			case 2:
				this.mType++;
				this.Help_RT[num].gameObject.SetActive(true);
				num++;
				break;
			}
			if (i == 0 && this.mType == 1)
			{
				this.Cstr_HelpTitle[0].ClearString();
				this.tmpTechD = this.DM.TechData.GetRecordByKey(this.DM.ResearchTech);
				this.Cstr_HelpTitle[0].IntToFormat((long)(this.DM.GetTechLevel(this.DM.ResearchTech) + 1), 1, false);
				this.Cstr_HelpTitle[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpTechD.TechName));
				this.Cstr_HelpTitle[0].AppendFormat(this.DM.mStringTable.GetStringByID(4044u));
				this.text_Help1[0].text = this.Cstr_HelpTitle[0].ToString();
				this.text_Help1[1].text = this.DM.mStringTable.GetStringByID(755u);
				this.text_Help1[1].SetAllDirty();
				this.text_Help1[1].cachedTextGenerator.Invalidate();
				this.Cstr_HelpValue[0].ClearString();
				if (this.GUIM.IsArabic)
				{
					this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].HelpMax, 1, false);
					this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].AlreadyHelperNum, 1, false);
				}
				else
				{
					this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].AlreadyHelperNum, 1, false);
					this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].HelpMax, 1, false);
				}
				this.Cstr_HelpValue[0].AppendFormat("{0} / {1}");
				this.text_Help1[2].text = this.Cstr_HelpValue[0].ToString();
				this.text_Help1[2].SetAllDirty();
				this.text_Help1[2].cachedTextGenerator.Invalidate();
				this.Help_RT[0].sizeDelta = new Vector2((float)(259 * (int)this.DM.mPlayHelpDataType[0].AlreadyHelperNum) / (float)this.DM.mPlayHelpDataType[0].HelpMax, this.Help_RT[0].sizeDelta.y);
				if (this.DM.mPlayHelpDataType[0].AlreadyHelperNum == this.DM.mPlayHelpDataType[0].HelpMax)
				{
					this.Img_HelpFull[0].gameObject.SetActive(true);
				}
				else
				{
					this.Img_HelpFull[0].gameObject.SetActive(false);
				}
			}
			if (i == 1)
			{
				if (this.mType == 1 && this.DM.mPlayHelpDataType[0].Kind <= 1 && this.DM.mPlayHelpDataType[0].HelpMax == 0)
				{
					this.Cstr_HelpTitle[0].ClearString();
					this.tmpBuildData = this.GUIM.BuildingData.AllBuildsData[(int)this.GUIM.BuildingData.BuildingManorID];
					this.tmpBuildID = this.tmpBuildData.BuildID;
					this.tmpBuildD = this.DM.BuildsTypeData.GetRecordByKey(this.tmpBuildID);
					this.Cstr_HelpTitle[0].IntToFormat((long)(this.tmpBuildData.Level + 1), 1, false);
					this.Cstr_HelpTitle[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpBuildD.NameID));
					this.Cstr_HelpTitle[0].AppendFormat(this.DM.mStringTable.GetStringByID(4044u));
					this.text_Help1[0].text = this.Cstr_HelpTitle[0].ToString();
					this.text_Help1[1].text = this.DM.mStringTable.GetStringByID(754u);
					this.text_Help1[1].SetAllDirty();
					this.text_Help1[1].cachedTextGenerator.Invalidate();
					this.Cstr_HelpValue[0].ClearString();
					if (this.GUIM.IsArabic)
					{
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[1].HelpMax, 1, false);
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[1].AlreadyHelperNum, 1, false);
					}
					else
					{
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[1].AlreadyHelperNum, 1, false);
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[1].HelpMax, 1, false);
					}
					this.Cstr_HelpValue[0].AppendFormat("{0} / {1}");
					this.text_Help1[2].text = this.Cstr_HelpValue[0].ToString();
					this.text_Help1[2].SetAllDirty();
					this.text_Help1[2].cachedTextGenerator.Invalidate();
					this.Help_RT[0].sizeDelta = new Vector2((float)(259 * (int)this.DM.mPlayHelpDataType[1].AlreadyHelperNum) / (float)this.DM.mPlayHelpDataType[1].HelpMax, this.Help_RT[0].sizeDelta.y);
					if (this.DM.mPlayHelpDataType[1].AlreadyHelperNum == this.DM.mPlayHelpDataType[1].HelpMax)
					{
						this.Img_HelpFull[0].gameObject.SetActive(true);
					}
					else
					{
						this.Img_HelpFull[0].gameObject.SetActive(false);
					}
				}
				else
				{
					this.Cstr_HelpTitle[1].ClearString();
					if ((int)this.GUIM.BuildingData.BuildingManorID < this.GUIM.BuildingData.AllBuildsData.Length)
					{
						this.tmpBuildData = this.GUIM.BuildingData.AllBuildsData[(int)this.GUIM.BuildingData.BuildingManorID];
					}
					this.tmpBuildID = this.tmpBuildData.BuildID;
					this.tmpBuildD = this.DM.BuildsTypeData.GetRecordByKey(this.tmpBuildID);
					this.Cstr_HelpTitle[1].IntToFormat((long)(this.tmpBuildData.Level + 1), 1, false);
					this.Cstr_HelpTitle[1].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpBuildD.NameID));
					this.Cstr_HelpTitle[1].AppendFormat(this.DM.mStringTable.GetStringByID(4044u));
					this.text_Help2[0].text = this.Cstr_HelpTitle[1].ToString();
					this.text_Help2[1].text = this.DM.mStringTable.GetStringByID(754u);
					this.text_Help2[1].SetAllDirty();
					this.text_Help2[1].cachedTextGenerator.Invalidate();
					this.Cstr_HelpValue[1].ClearString();
					if (this.GUIM.IsArabic)
					{
						this.Cstr_HelpValue[1].IntToFormat((long)this.DM.mPlayHelpDataType[1].HelpMax, 1, false);
						this.Cstr_HelpValue[1].IntToFormat((long)this.DM.mPlayHelpDataType[1].AlreadyHelperNum, 1, false);
					}
					else
					{
						this.Cstr_HelpValue[1].IntToFormat((long)this.DM.mPlayHelpDataType[1].AlreadyHelperNum, 1, false);
						this.Cstr_HelpValue[1].IntToFormat((long)this.DM.mPlayHelpDataType[1].HelpMax, 1, false);
					}
					this.Cstr_HelpValue[1].AppendFormat("{0} / {1}");
					this.text_Help2[2].text = this.Cstr_HelpValue[1].ToString();
					this.text_Help2[2].SetAllDirty();
					this.text_Help2[2].cachedTextGenerator.Invalidate();
					this.Help_RT[1].sizeDelta = new Vector2((float)(259 * (int)this.DM.mPlayHelpDataType[1].AlreadyHelperNum) / (float)this.DM.mPlayHelpDataType[1].HelpMax, this.Help_RT[1].sizeDelta.y);
					if (this.DM.mPlayHelpDataType[1].AlreadyHelperNum == this.DM.mPlayHelpDataType[1].HelpMax)
					{
						this.Img_HelpFull[1].gameObject.SetActive(true);
					}
					else
					{
						this.Img_HelpFull[1].gameObject.SetActive(false);
					}
				}
			}
		}
		if (this.mType == 0)
		{
			for (int j = 0; j < 2; j++)
			{
				this.Img_Help[j].gameObject.SetActive(false);
			}
		}
		else if (this.mType == 1)
		{
			this.Img_Help[1].gameObject.SetActive(false);
		}
	}

	// Token: 0x06000EE8 RID: 3816 RVA: 0x00198C70 File Offset: 0x00196E70
	public void UpdatePanel(bool bFirst = false)
	{
		this.tmplist.Clear();
		for (int i = 0; i < this.DM.mHelpDataList.Count; i++)
		{
			this.tmplist.Add(74f);
		}
		this.ImgScroll_RT.anchoredPosition = new Vector2(this.ImgScroll_RT.anchoredPosition.x, (float)(120 - this.mType * 34));
		this.ImgScrollPanel_RT.sizeDelta = new Vector2(this.ImgScrollPanel_RT.sizeDelta.x, (float)(347 - this.mType * 34));
		this.ImgUp_RT.sizeDelta = new Vector2(this.ImgUp_RT.sizeDelta.x, (float)(88 + this.mType * 34));
		this.NoHelp_RT.anchoredPosition = new Vector2(this.NoHelp_RT.anchoredPosition.x, -143.5f - (float)(this.mType * 34));
		this.NoHelp_RT.sizeDelta = new Vector2(this.NoHelp_RT.sizeDelta.x, (float)(347 - this.mType * 34));
		if (bFirst)
		{
			this.m_ScrollPanel.IntiScrollPanel((float)(347 - this.mType * 34), 0f, 0f, this.tmplist, 6, this);
		}
		else
		{
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, (float)(347 - this.mType * 34), true);
		}
		if (this.DM.AllianceMoneyBonusRate > 100)
		{
			this.Img_BonusRate[0].gameObject.SetActive(true);
			this.Img_BonusRate[1].gameObject.SetActive(true);
		}
		if (this.DM.AllianceMoneyBonusRate > 100 && this.DM.AllianceMoneyBonusRate <= 400)
		{
			this.Cstr_StrValue[0].ClearString();
			this.Cstr_StrValue[0].IntToFormat((long)(this.DM.AllianceMoneyBonusRate / 100), 1, false);
			this.Cstr_StrValue[0].AppendFormat("UI_mall_{0}_001");
			if (this.GUIM.IsArabic)
			{
				this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_x_001");
				this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_x_001");
				this.Img_BonusRate[1].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
				this.Img_BonusRate[4].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
			}
			else
			{
				this.Img_BonusRate[0].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
				this.Img_BonusRate[3].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
				this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_x_001");
				this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_x_001");
			}
		}
		else if (this.GUIM.IsArabic)
		{
			this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_x_001");
			this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_x_001");
			this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_2_001");
			this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_2_001");
		}
		else
		{
			this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_2_001");
			this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_2_001");
			this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_x_001");
			this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_x_001");
		}
		if (this.DM.mHelpDataList.Count == 0)
		{
			this.NoHelp_RT.gameObject.SetActive(true);
			this.Socrll_T.gameObject.SetActive(false);
			this.btn_AllHelp.enabled = false;
			if (!this.bShowText && this.Img_BonusRate[2].gameObject.activeSelf)
			{
				this.Img_BonusRate[2].gameObject.SetActive(false);
			}
		}
		else
		{
			this.NoHelp_RT.gameObject.SetActive(false);
			this.Socrll_T.gameObject.SetActive(true);
			this.btn_AllHelp.enabled = true;
		}
	}

	// Token: 0x06000EE9 RID: 3817 RVA: 0x00199164 File Offset: 0x00197364
	public override void OnClose()
	{
		if (this.Cstr_AllianceMoney != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_AllianceMoney);
		}
		if (this.Cstr_ReSetTime != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_ReSetTime);
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.Cstr_HelpTitle[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_HelpTitle[i]);
			}
			if (this.Cstr_HelpValue[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_HelpValue[i]);
			}
			if (this.Cstr_StrValue[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_StrValue[i]);
			}
		}
		for (int j = 0; j < 6; j++)
		{
			if (this.Cstr_ItemHelpTitle[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemHelpTitle[j]);
			}
			if (this.Cstr_ItemHelpValue[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemHelpValue[j]);
			}
		}
		this.GUIM.m_SpeciallyEffect.mUITransform = null;
	}

	// Token: 0x06000EEA RID: 3818 RVA: 0x00199280 File Offset: 0x00197480
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 1:
			this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(750u), this.DM.mStringTable.GetStringByID(799u), null, null, 0, 0, true, true);
			break;
		case 2:
			if (this.GUIM.ShowUILock(EUILock.Alliance_Help))
			{
				int num = this.DM.mHelpDataList.Count / 30;
				if (this.DM.mHelpDataList.Count % 30 != 0)
				{
					num++;
				}
				int num2 = this.DM.mHelpDataList.Count;
				for (int i = 0; i < num; i++)
				{
					MessagePacket messagePacket = new MessagePacket(1024);
					messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_HELP_SOMEBODY;
					messagePacket.AddSeqId();
					int num3;
					if (num2 - 30 > 0)
					{
						num3 = 30;
						num2 -= 30;
					}
					else
					{
						num3 = num2;
					}
					messagePacket.Add((ushort)num3);
					for (int j = 0; j < num3; j++)
					{
						messagePacket.Add(this.DM.mHelpDataList[i * 30 + j].AllianceHelpRecordSN);
					}
					messagePacket.Send(false);
				}
				this.DM.mHelpDataList.Clear();
				this.UpdatePanel(false);
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 11, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 17, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Info, 3, 0);
				RectTransform component = sender.transform.GetComponent<RectTransform>();
				this.GUIM.mStartV2 = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + component.anchoredPosition.x, this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - component.anchoredPosition.y);
				RectTransform component2 = this.btn_Info.transform.parent.GetComponent<RectTransform>();
				RectTransform component3 = this.AllianceMoney_RT.transform.parent.GetComponent<RectTransform>();
				float num4 = 0f;
				if (this.GUIM.bOpenOnIPhoneX)
				{
					num4 = this.GUIM.IPhoneX_DeltaX;
				}
				this.GUIM.m_SpeciallyEffect.UI_bezieEnd = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + 2.5f - num4, -(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - component2.anchoredPosition.y - component3.anchoredPosition.y));
				this.GUIM.m_SpeciallyEffect.mUITransform = this.GameT.GetChild(1).GetChild(6);
			}
			break;
		case 3:
		{
			this.CheckOnClick(sender.m_BtnID2);
			RectTransform component4 = sender.transform.parent.parent.parent.parent.GetComponent<RectTransform>();
			RectTransform component5 = sender.transform.parent.GetComponent<RectTransform>();
			RectTransform component6 = sender.transform.GetComponent<RectTransform>();
			this.GUIM.mStartV2 = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + component4.anchoredPosition.x + component6.anchoredPosition.x, this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - component4.anchoredPosition.y - component5.anchoredPosition.y - component6.anchoredPosition.y);
			RectTransform component7 = this.btn_Info.transform.parent.GetComponent<RectTransform>();
			RectTransform component8 = this.AllianceMoney_RT.transform.parent.GetComponent<RectTransform>();
			float num5 = 0f;
			if (this.GUIM.bOpenOnIPhoneX)
			{
				num5 = this.GUIM.IPhoneX_DeltaX;
			}
			this.GUIM.m_SpeciallyEffect.UI_bezieEnd = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + 2.5f - num5, -(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - component7.anchoredPosition.y - component8.anchoredPosition.y));
			this.GUIM.m_SpeciallyEffect.mUITransform = this.GameT.GetChild(1).GetChild(6);
			break;
		}
		}
	}

	// Token: 0x06000EEB RID: 3819 RVA: 0x001997D0 File Offset: 0x001979D0
	public void CheckOnClick(int Idx)
	{
		if (GUIManager.Instance.ShowUILock(EUILock.Alliance_Help))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_HELP_SOMEBODY;
			messagePacket.AddSeqId();
			messagePacket.Add(1);
			messagePacket.Add(this.DM.mHelpDataList[Idx].AllianceHelpRecordSN);
			messagePacket.Send(false);
			this.DM.mHelpDataList.RemoveAt(Idx);
		}
	}

	// Token: 0x06000EEC RID: 3820 RVA: 0x0019984C File Offset: 0x00197A4C
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x06000EED RID: 3821 RVA: 0x00199850 File Offset: 0x00197A50
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		this.ItemT = item.GetComponent<Transform>();
		if (this.tmpItem[panelObjectIdx] == null)
		{
			this.tmpItem[panelObjectIdx] = this.ItemT.GetComponent<ScrollPanelItem>();
			this.Img_ItemRank[panelObjectIdx] = this.ItemT.GetChild(1).GetComponent<Image>();
			this.text_ItemName[panelObjectIdx] = this.ItemT.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.text_ItemHelpTitle[panelObjectIdx] = this.ItemT.GetChild(0).GetChild(1).GetComponent<UIText>();
			this.MemberHelp_RT[panelObjectIdx] = this.ItemT.GetChild(2).GetChild(0).GetComponent<RectTransform>();
			this.text_ItemHelpKind[panelObjectIdx] = this.ItemT.GetChild(2).GetChild(1).GetComponent<UIText>();
			this.text_ItemHelpValue[panelObjectIdx] = this.ItemT.GetChild(2).GetChild(2).GetComponent<UIText>();
			this.btn_MemberHelp[panelObjectIdx] = this.ItemT.GetChild(3).GetComponent<UIButton>();
			this.btn_MemberHelp[panelObjectIdx].m_Handler = this;
			this.Hbtn_Member[panelObjectIdx] = this.ItemT.GetChild(4).GetComponent<UIHIBtn>();
		}
		this.Img_ItemRank[panelObjectIdx].sprite = this.SArray.m_Sprites[(int)(this.DM.mHelpDataList[dataIdx].Rank - AllianceRank.RANK1)];
		this.text_ItemName[panelObjectIdx].text = this.DM.mHelpDataList[dataIdx].PlayerName;
		this.text_ItemName[panelObjectIdx].SetAllDirty();
		this.text_ItemName[panelObjectIdx].cachedTextGenerator.Invalidate();
		this.btn_MemberHelp[panelObjectIdx].m_BtnID2 = dataIdx;
		this.Cstr_ItemHelpTitle[panelObjectIdx].ClearString();
		if (this.DM.mHelpDataList[dataIdx].HelpKind == EAllianceHelpKind.EAHK_Research)
		{
			this.text_ItemHelpKind[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(755u);
			this.tmpTechD = this.DM.TechData.GetRecordByKey(this.DM.mHelpDataList[dataIdx].EventID);
			this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID(757u));
			this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID(755u));
			this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID(4549u));
			this.Cstr_ItemHelpTitle[panelObjectIdx].IntToFormat((long)this.DM.mHelpDataList[dataIdx].EventDataLv, 1, false);
			this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpTechD.TechName));
			this.Cstr_ItemHelpTitle[panelObjectIdx].AppendFormat("{0}<color=#FFEE9E>{1} {2}{3} {4}</color>");
		}
		else
		{
			this.text_ItemHelpKind[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(754u);
			this.tmpBuildD = this.DM.BuildsTypeData.GetRecordByKey(this.DM.mHelpDataList[dataIdx].EventID);
			this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID(757u));
			this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID(754u));
			this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID(4549u));
			this.Cstr_ItemHelpTitle[panelObjectIdx].IntToFormat((long)this.DM.mHelpDataList[dataIdx].EventDataLv, 1, false);
			this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpBuildD.NameID));
			this.Cstr_ItemHelpTitle[panelObjectIdx].AppendFormat("{0}<color=#FFEE9E>{1} {2}{3} {4}</color>");
		}
		this.text_ItemHelpTitle[panelObjectIdx].text = this.Cstr_ItemHelpTitle[panelObjectIdx].ToString();
		this.text_ItemHelpTitle[panelObjectIdx].SetAllDirty();
		this.text_ItemHelpTitle[panelObjectIdx].cachedTextGenerator.Invalidate();
		this.MemberHelp_RT[panelObjectIdx].sizeDelta = new Vector2((float)(259 * (int)this.DM.mHelpDataList[dataIdx].AlreadyHelperNum / (int)this.DM.mHelpDataList[dataIdx].HelpMax), this.MemberHelp_RT[panelObjectIdx].sizeDelta.y);
		this.Cstr_ItemHelpValue[panelObjectIdx].ClearString();
		if (this.GUIM.IsArabic)
		{
			this.Cstr_ItemHelpValue[panelObjectIdx].IntToFormat((long)this.DM.mHelpDataList[dataIdx].HelpMax, 1, false);
			this.Cstr_ItemHelpValue[panelObjectIdx].IntToFormat((long)this.DM.mHelpDataList[dataIdx].AlreadyHelperNum, 1, false);
		}
		else
		{
			this.Cstr_ItemHelpValue[panelObjectIdx].IntToFormat((long)this.DM.mHelpDataList[dataIdx].AlreadyHelperNum, 1, false);
			this.Cstr_ItemHelpValue[panelObjectIdx].IntToFormat((long)this.DM.mHelpDataList[dataIdx].HelpMax, 1, false);
		}
		this.Cstr_ItemHelpValue[panelObjectIdx].AppendFormat("{0} / {1}");
		this.text_ItemHelpValue[panelObjectIdx].text = this.Cstr_ItemHelpValue[panelObjectIdx].ToString();
		this.text_ItemHelpValue[panelObjectIdx].SetAllDirty();
		this.text_ItemHelpValue[panelObjectIdx].cachedTextGenerator.Invalidate();
		this.GUIM.ChangeHeroItemImg(this.Hbtn_Member[panelObjectIdx].transform, eHeroOrItem.Hero, this.DM.mHelpDataList[dataIdx].Head, 11, 0, 0);
	}

	// Token: 0x06000EEE RID: 3822 RVA: 0x00199E68 File Offset: 0x00198068
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06000EEF RID: 3823 RVA: 0x00199E6C File Offset: 0x0019806C
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Alliance)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else
			{
				if (this.DM.RoleAlliance.Id == 0u)
				{
					this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_HelpSpeedup);
					return;
				}
				this.UpdatePanel(false);
			}
		}
		else
		{
			if (this.DM.RoleAlliance.Id == 0u)
			{
				this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_HelpSpeedup);
				return;
			}
			if (this.mType == 1)
			{
				this.Cstr_HelpValue[0].ClearString();
				if (this.DM.mPlayHelpDataType[0].Kind != 0)
				{
					if (this.GUIM.IsArabic)
					{
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].HelpMax, 1, false);
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].AlreadyHelperNum, 1, false);
					}
					else
					{
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].AlreadyHelperNum, 1, false);
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].HelpMax, 1, false);
					}
					this.Help_RT[0].sizeDelta = new Vector2((float)(259 * (int)this.DM.mPlayHelpDataType[0].AlreadyHelperNum) / (float)this.DM.mPlayHelpDataType[0].HelpMax, this.Help_RT[0].sizeDelta.y);
					if (this.DM.mPlayHelpDataType[0].AlreadyHelperNum == this.DM.mPlayHelpDataType[0].HelpMax)
					{
						this.Img_HelpFull[0].gameObject.SetActive(true);
					}
					else
					{
						this.Img_HelpFull[0].gameObject.SetActive(false);
					}
				}
				else
				{
					if (this.GUIM.IsArabic)
					{
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[1].HelpMax, 1, false);
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[1].AlreadyHelperNum, 1, false);
					}
					else
					{
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[1].AlreadyHelperNum, 1, false);
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[1].HelpMax, 1, false);
					}
					this.Help_RT[0].sizeDelta = new Vector2((float)(259 * (int)this.DM.mPlayHelpDataType[1].AlreadyHelperNum) / (float)this.DM.mPlayHelpDataType[1].HelpMax, this.Help_RT[0].sizeDelta.y);
					if (this.DM.mPlayHelpDataType[1].AlreadyHelperNum == this.DM.mPlayHelpDataType[1].HelpMax)
					{
						this.Img_HelpFull[0].gameObject.SetActive(true);
					}
					else
					{
						this.Img_HelpFull[0].gameObject.SetActive(false);
					}
				}
				this.Cstr_HelpValue[0].AppendFormat("{0} / {1}");
				this.text_Help1[2].text = this.Cstr_HelpValue[0].ToString();
				this.text_Help1[2].SetAllDirty();
				this.text_Help1[2].cachedTextGenerator.Invalidate();
			}
			else
			{
				this.Cstr_HelpValue[0].ClearString();
				if (this.GUIM.IsArabic)
				{
					this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].HelpMax, 1, false);
					this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].AlreadyHelperNum, 1, false);
				}
				else
				{
					this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].AlreadyHelperNum, 1, false);
					this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].HelpMax, 1, false);
				}
				this.Cstr_HelpValue[0].AppendFormat("{0} / {1}");
				this.text_Help1[2].text = this.Cstr_HelpValue[0].ToString();
				this.text_Help1[2].SetAllDirty();
				this.text_Help1[2].cachedTextGenerator.Invalidate();
				if (this.DM.mPlayHelpDataType[0].AlreadyHelperNum == this.DM.mPlayHelpDataType[0].HelpMax)
				{
					this.Img_HelpFull[0].gameObject.SetActive(true);
				}
				else
				{
					this.Img_HelpFull[0].gameObject.SetActive(false);
				}
				this.Cstr_HelpValue[1].ClearString();
				if (this.GUIM.IsArabic)
				{
					this.Cstr_HelpValue[1].IntToFormat((long)this.DM.mPlayHelpDataType[1].HelpMax, 1, false);
					this.Cstr_HelpValue[1].IntToFormat((long)this.DM.mPlayHelpDataType[1].AlreadyHelperNum, 1, false);
				}
				else
				{
					this.Cstr_HelpValue[1].IntToFormat((long)this.DM.mPlayHelpDataType[1].AlreadyHelperNum, 1, false);
					this.Cstr_HelpValue[1].IntToFormat((long)this.DM.mPlayHelpDataType[1].HelpMax, 1, false);
				}
				this.Cstr_HelpValue[1].AppendFormat("{0} / {1}");
				this.text_Help2[2].text = this.Cstr_HelpValue[1].ToString();
				this.text_Help2[2].SetAllDirty();
				this.text_Help2[2].cachedTextGenerator.Invalidate();
				if (this.DM.mPlayHelpDataType[1].AlreadyHelperNum == this.DM.mPlayHelpDataType[1].HelpMax)
				{
					this.Img_HelpFull[1].gameObject.SetActive(true);
				}
				else
				{
					this.Img_HelpFull[1].gameObject.SetActive(false);
				}
				this.Help_RT[0].sizeDelta = new Vector2((float)(259 * (int)this.DM.mPlayHelpDataType[0].AlreadyHelperNum) / (float)this.DM.mPlayHelpDataType[0].HelpMax, this.Help_RT[0].sizeDelta.y);
				this.Help_RT[1].sizeDelta = new Vector2((float)(259 * (int)this.DM.mPlayHelpDataType[1].AlreadyHelperNum) / (float)this.DM.mPlayHelpDataType[1].HelpMax, this.Help_RT[0].sizeDelta.y);
			}
		}
	}

	// Token: 0x06000EF0 RID: 3824 RVA: 0x0019A5DC File Offset: 0x001987DC
	public void Refresh_FontTexture()
	{
		if (this.text_PlayerName != null && this.text_PlayerName.enabled)
		{
			this.text_PlayerName.enabled = false;
			this.text_PlayerName.enabled = true;
		}
		if (this.text_AllianceMoney != null && this.text_AllianceMoney.enabled)
		{
			this.text_AllianceMoney.enabled = false;
			this.text_AllianceMoney.enabled = true;
		}
		if (this.text_ReSetTime != null && this.text_ReSetTime.enabled)
		{
			this.text_ReSetTime.enabled = false;
			this.text_ReSetTime.enabled = true;
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.text_Help1[i] != null && this.text_Help1[i].enabled)
			{
				this.text_Help1[i].enabled = false;
				this.text_Help1[i].enabled = true;
			}
			if (this.text_Help2[i] != null && this.text_Help2[i].enabled)
			{
				this.text_Help2[i].enabled = false;
				this.text_Help2[i].enabled = true;
			}
		}
		for (int j = 0; j < 6; j++)
		{
			if (this.text_ItemName[j] != null && this.text_ItemName[j].enabled)
			{
				this.text_ItemName[j].enabled = false;
				this.text_ItemName[j].enabled = true;
			}
			if (this.text_ItemHelpTitle[j] != null && this.text_ItemHelpTitle[j].enabled)
			{
				this.text_ItemHelpTitle[j].enabled = false;
				this.text_ItemHelpTitle[j].enabled = true;
			}
			if (this.text_ItemHelpKind[j] != null && this.text_ItemHelpKind[j].enabled)
			{
				this.text_ItemHelpKind[j].enabled = false;
				this.text_ItemHelpKind[j].enabled = true;
			}
			if (this.text_ItemHelpValue[j] != null && this.text_ItemHelpValue[j].enabled)
			{
				this.text_ItemHelpValue[j].enabled = false;
				this.text_ItemHelpValue[j].enabled = true;
			}
		}
		for (int k = 0; k < 5; k++)
		{
			if (this.text_tmpStr[k] != null && this.text_tmpStr[k].enabled)
			{
				this.text_tmpStr[k].enabled = false;
				this.text_tmpStr[k].enabled = true;
			}
		}
		if (this.Hbtn_Player != null && this.Hbtn_Player.enabled)
		{
			this.Hbtn_Player.enabled = false;
			this.Hbtn_Player.enabled = true;
		}
		if (this.tmpHbtn != null && this.tmpHbtn.enabled)
		{
			this.tmpHbtn.enabled = false;
			this.tmpHbtn.enabled = true;
		}
		for (int l = 0; l < 6; l++)
		{
			if (this.Hbtn_Member[l] != null && this.Hbtn_Member[l].enabled)
			{
				this.Hbtn_Member[l].Refresh_FontTexture();
			}
		}
	}

	// Token: 0x06000EF1 RID: 3825 RVA: 0x0019A948 File Offset: 0x00198B48
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			this.CheckHelpChang();
			this.UpdatePanel(false);
			break;
		case 2:
			if (this.mType == 1)
			{
				this.Cstr_HelpValue[0].ClearString();
				if (this.DM.mPlayHelpDataType[0].Kind > 1)
				{
					if (this.GUIM.IsArabic)
					{
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].HelpMax, 1, false);
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].AlreadyHelperNum, 1, false);
					}
					else
					{
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].AlreadyHelperNum, 1, false);
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].HelpMax, 1, false);
					}
					this.Help_RT[0].sizeDelta = new Vector2((float)(259 * (int)this.DM.mPlayHelpDataType[0].AlreadyHelperNum) / (float)this.DM.mPlayHelpDataType[0].HelpMax, this.Help_RT[0].sizeDelta.y);
					if (this.DM.mPlayHelpDataType[0].AlreadyHelperNum == this.DM.mPlayHelpDataType[0].HelpMax)
					{
						this.Img_HelpFull[0].gameObject.SetActive(true);
					}
					else
					{
						this.Img_HelpFull[0].gameObject.SetActive(false);
					}
				}
				else
				{
					if (this.GUIM.IsArabic)
					{
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[1].HelpMax, 1, false);
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[1].AlreadyHelperNum, 1, false);
					}
					else
					{
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[1].AlreadyHelperNum, 1, false);
						this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[1].HelpMax, 1, false);
					}
					this.Help_RT[0].sizeDelta = new Vector2((float)(259 * (int)this.DM.mPlayHelpDataType[1].AlreadyHelperNum) / (float)this.DM.mPlayHelpDataType[1].HelpMax, this.Help_RT[0].sizeDelta.y);
					if (this.DM.mPlayHelpDataType[1].AlreadyHelperNum == this.DM.mPlayHelpDataType[1].HelpMax)
					{
						this.Img_HelpFull[0].gameObject.SetActive(true);
					}
					else
					{
						this.Img_HelpFull[0].gameObject.SetActive(false);
					}
				}
				this.Cstr_HelpValue[0].AppendFormat("{0} / {1}");
				this.text_Help1[2].text = this.Cstr_HelpValue[0].ToString();
				this.text_Help1[2].SetAllDirty();
				this.text_Help1[2].cachedTextGenerator.Invalidate();
			}
			else
			{
				this.Cstr_HelpValue[0].ClearString();
				if (this.GUIM.IsArabic)
				{
					this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].HelpMax, 1, false);
					this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].AlreadyHelperNum, 1, false);
				}
				else
				{
					this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].AlreadyHelperNum, 1, false);
					this.Cstr_HelpValue[0].IntToFormat((long)this.DM.mPlayHelpDataType[0].HelpMax, 1, false);
				}
				this.Cstr_HelpValue[0].AppendFormat("{0} / {1}");
				this.text_Help1[2].text = this.Cstr_HelpValue[0].ToString();
				this.text_Help1[2].SetAllDirty();
				this.text_Help1[2].cachedTextGenerator.Invalidate();
				if (this.DM.mPlayHelpDataType[0].AlreadyHelperNum == this.DM.mPlayHelpDataType[0].HelpMax)
				{
					this.Img_HelpFull[0].gameObject.SetActive(true);
				}
				else
				{
					this.Img_HelpFull[0].gameObject.SetActive(false);
				}
				this.Cstr_HelpValue[1].ClearString();
				if (this.GUIM.IsArabic)
				{
					this.Cstr_HelpValue[1].IntToFormat((long)this.DM.mPlayHelpDataType[1].HelpMax, 1, false);
					this.Cstr_HelpValue[1].IntToFormat((long)this.DM.mPlayHelpDataType[1].AlreadyHelperNum, 1, false);
				}
				else
				{
					this.Cstr_HelpValue[1].IntToFormat((long)this.DM.mPlayHelpDataType[1].AlreadyHelperNum, 1, false);
					this.Cstr_HelpValue[1].IntToFormat((long)this.DM.mPlayHelpDataType[1].HelpMax, 1, false);
				}
				this.Cstr_HelpValue[1].AppendFormat("{0} / {1}");
				this.text_Help2[2].text = this.Cstr_HelpValue[1].ToString();
				this.text_Help2[2].SetAllDirty();
				this.text_Help2[2].cachedTextGenerator.Invalidate();
				if (this.DM.mPlayHelpDataType[1].AlreadyHelperNum == this.DM.mPlayHelpDataType[1].HelpMax)
				{
					this.Img_HelpFull[1].gameObject.SetActive(true);
				}
				else
				{
					this.Img_HelpFull[1].gameObject.SetActive(false);
				}
				this.Help_RT[0].sizeDelta = new Vector2((float)(259 * (int)this.DM.mPlayHelpDataType[0].AlreadyHelperNum) / (float)this.DM.mPlayHelpDataType[0].HelpMax, this.Help_RT[0].sizeDelta.y);
				this.Help_RT[1].sizeDelta = new Vector2((float)(259 * (int)this.DM.mPlayHelpDataType[1].AlreadyHelperNum) / (float)this.DM.mPlayHelpDataType[1].HelpMax, this.Help_RT[0].sizeDelta.y);
			}
			break;
		case 3:
			this.Cstr_AllianceMoney.ClearString();
			this.DM.DailyHelpGetAllianceMoney = (uint)Mathf.Clamp(this.DM.DailyHelpGetAllianceMoney, 0f, (float)(40000 * (this.DM.AllianceMoneyBonusRate / 100)));
			this.Cstr_AllianceMoney.IntToFormat((long)((ulong)this.DM.DailyHelpGetAllianceMoney), 1, true);
			this.Cstr_AllianceMoney.IntToFormat((long)(40000 * (this.DM.AllianceMoneyBonusRate / 100)), 1, true);
			if (this.GUIM.IsArabic)
			{
				if (this.DM.AllianceMoneyBonusRate > 100)
				{
					this.Cstr_AllianceMoney.AppendFormat("<color=#ffff00>{1}</color> / {0}");
				}
				else
				{
					this.Cstr_AllianceMoney.AppendFormat("{1} / {0}");
				}
			}
			else if (this.DM.AllianceMoneyBonusRate > 100)
			{
				this.Cstr_AllianceMoney.AppendFormat("{0} / <color=#ffff00>{1}</color>");
			}
			else
			{
				this.Cstr_AllianceMoney.AppendFormat("{0} / {1}");
			}
			this.text_AllianceMoney.text = this.Cstr_AllianceMoney.ToString();
			this.text_AllianceMoney.SetAllDirty();
			this.text_AllianceMoney.cachedTextGenerator.Invalidate();
			this.AllianceMoney_RT.sizeDelta = new Vector2(340u * this.DM.DailyHelpGetAllianceMoney / (float)(40000 * (this.DM.AllianceMoneyBonusRate / 100)), this.AllianceMoney_RT.sizeDelta.y);
			this.UpdatePanel(false);
			break;
		case 4:
			this.Cstr_AllianceMoney.ClearString();
			this.Cstr_AllianceMoney.IntToFormat((long)((ulong)this.DM.DailyHelpGetAllianceMoney), 1, true);
			this.Cstr_AllianceMoney.IntToFormat((long)(40000 * (this.DM.AllianceMoneyBonusRate / 100)), 1, true);
			if (this.GUIM.IsArabic)
			{
				if (this.DM.AllianceMoneyBonusRate > 100)
				{
					this.Cstr_AllianceMoney.AppendFormat("<color=#ffff00>{1}</color> / {0}");
				}
				else
				{
					this.Cstr_AllianceMoney.AppendFormat("{1} / {0}");
				}
			}
			else if (this.DM.AllianceMoneyBonusRate > 100)
			{
				this.Cstr_AllianceMoney.AppendFormat("{0} / <color=#ffff00>{1}</color>");
			}
			else
			{
				this.Cstr_AllianceMoney.AppendFormat("{0} / {1}");
			}
			this.text_AllianceMoney.text = this.Cstr_AllianceMoney.ToString();
			this.text_AllianceMoney.SetAllDirty();
			this.text_AllianceMoney.cachedTextGenerator.Invalidate();
			this.AllianceMoney_RT.sizeDelta = new Vector2(340u * this.DM.DailyHelpGetAllianceMoney / (float)(40000 * (this.DM.AllianceMoneyBonusRate / 100)), this.AllianceMoney_RT.sizeDelta.y);
			break;
		case 5:
			this.Cstr_AllianceMoney.ClearString();
			this.DM.DailyHelpGetAllianceMoney = (uint)Mathf.Clamp(this.DM.DailyHelpGetAllianceMoney, 0f, (float)(40000 * (this.DM.AllianceMoneyBonusRate / 100)));
			this.Cstr_AllianceMoney.IntToFormat((long)((ulong)this.DM.DailyHelpGetAllianceMoney), 1, true);
			this.Cstr_AllianceMoney.IntToFormat((long)(40000 * (this.DM.AllianceMoneyBonusRate / 100)), 1, true);
			if (this.GUIM.IsArabic)
			{
				if (this.DM.AllianceMoneyBonusRate > 100)
				{
					this.Cstr_AllianceMoney.AppendFormat("<color=#ffff00>{1}</color> / {0}");
				}
				else
				{
					this.Cstr_AllianceMoney.AppendFormat("{1} / {0}");
				}
			}
			else if (this.DM.AllianceMoneyBonusRate > 100)
			{
				this.Cstr_AllianceMoney.AppendFormat("{0} / <color=#ffff00>{1}</color>");
			}
			else
			{
				this.Cstr_AllianceMoney.AppendFormat("{0} / {1}");
			}
			this.text_AllianceMoney.text = this.Cstr_AllianceMoney.ToString();
			this.text_AllianceMoney.SetAllDirty();
			this.text_AllianceMoney.cachedTextGenerator.Invalidate();
			this.AllianceMoney_RT.sizeDelta = new Vector2(340u * this.DM.DailyHelpGetAllianceMoney / (float)(40000 * (this.DM.AllianceMoneyBonusRate / 100)), this.AllianceMoney_RT.sizeDelta.y);
			if (this.DM.AllianceMoneyBonusRate > 100)
			{
				this.Img_BonusRate[0].gameObject.SetActive(true);
				this.Img_BonusRate[1].gameObject.SetActive(true);
			}
			else
			{
				this.Img_BonusRate[0].gameObject.SetActive(false);
				this.Img_BonusRate[1].gameObject.SetActive(false);
			}
			if (this.DM.AllianceMoneyBonusRate > 100 && this.DM.AllianceMoneyBonusRate <= 400)
			{
				this.Cstr_StrValue[0].ClearString();
				this.Cstr_StrValue[0].IntToFormat((long)(this.DM.AllianceMoneyBonusRate / 100), 1, false);
				this.Cstr_StrValue[0].AppendFormat("UI_mall_{0}_001");
				if (this.GUIM.IsArabic)
				{
					this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_x_001");
					this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_x_001");
					this.Img_BonusRate[1].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
					this.Img_BonusRate[4].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
				}
				else
				{
					this.Img_BonusRate[0].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
					this.Img_BonusRate[3].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
					this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_x_001");
					this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_x_001");
				}
			}
			else if (this.GUIM.IsArabic)
			{
				this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_x_001");
				this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_x_001");
				this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_2_001");
				this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_2_001");
			}
			else
			{
				this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_2_001");
				this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_2_001");
				this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_x_001");
				this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_x_001");
			}
			break;
		case 6:
			if (this.bShowText)
			{
				if (this.mShowStatus == 2)
				{
					this.mShowTime = 2f;
				}
			}
			else if (this.DM.AllianceMoneyBonusRate > 100)
			{
				this.mShowStatus = 1;
				this.mShowTime = 0f;
				this.bShowText = true;
				this.scaleCount = 0.5f;
				this.Img_BonusRate[2].gameObject.SetActive(true);
				this.Img_BonusRate[2].rectTransform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
				this.Img_BonusRate[3].color = new Color(1f, 1f, 1f, 1f);
				this.Img_BonusRate[4].color = new Color(1f, 1f, 1f, 1f);
			}
			break;
		}
	}

	// Token: 0x06000EF2 RID: 3826 RVA: 0x0019B890 File Offset: 0x00199A90
	private void Start()
	{
	}

	// Token: 0x06000EF3 RID: 3827 RVA: 0x0019B894 File Offset: 0x00199A94
	private void Update()
	{
		if (this.bShowText && this.Img_BonusRate[2] != null && this.Img_BonusRate[2].gameObject.activeSelf)
		{
			if (this.mShowStatus == 1)
			{
				if (this.mShowTime < 0.1f)
				{
					this.mShowTime += Time.smoothDeltaTime;
					this.scaleCount = Mathf.Lerp(0.5f, 1.3f, 0.5f + 8f * this.mShowTime);
					this.Img_BonusRate[2].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
				}
				else
				{
					this.mShowStatus = 2;
					this.mShowTime = 1f;
				}
			}
			else if (this.mShowStatus == 2)
			{
				if (this.mShowTime > 0f)
				{
					this.mShowTime -= Time.smoothDeltaTime;
				}
				else
				{
					this.mShowStatus = 3;
					this.mShowTime = 0.5f;
				}
			}
			else if (this.mShowStatus == 3)
			{
				if (this.mShowTime > 0f)
				{
					this.mShowTime -= Time.smoothDeltaTime;
					this.Img_BonusRate[3].color = new Color(1f, 1f, 1f, this.mShowTime);
					this.Img_BonusRate[4].color = new Color(1f, 1f, 1f, this.mShowTime);
				}
				else
				{
					this.bShowText = false;
					this.mShowStatus = 0;
					this.mShowTime = 0f;
					this.Img_BonusRate[2].gameObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x040030F5 RID: 12533
	private Transform GameT;

	// Token: 0x040030F6 RID: 12534
	private Transform Tmp;

	// Token: 0x040030F7 RID: 12535
	private Transform ItemT;

	// Token: 0x040030F8 RID: 12536
	private Transform Socrll_T;

	// Token: 0x040030F9 RID: 12537
	private RectTransform ImgUp_RT;

	// Token: 0x040030FA RID: 12538
	private RectTransform ImgScroll_RT;

	// Token: 0x040030FB RID: 12539
	private RectTransform ImgScrollPanel_RT;

	// Token: 0x040030FC RID: 12540
	private RectTransform NoHelp_RT;

	// Token: 0x040030FD RID: 12541
	private RectTransform AllianceMoney_RT;

	// Token: 0x040030FE RID: 12542
	private RectTransform CDTime_text_RT;

	// Token: 0x040030FF RID: 12543
	private RectTransform CDTime_Img_RT;

	// Token: 0x04003100 RID: 12544
	private RectTransform[] Help_RT = new RectTransform[2];

	// Token: 0x04003101 RID: 12545
	private RectTransform[] MemberHelp_RT = new RectTransform[6];

	// Token: 0x04003102 RID: 12546
	private UIButton btn_EXIT;

	// Token: 0x04003103 RID: 12547
	private UIButton btn_Info;

	// Token: 0x04003104 RID: 12548
	private UIButton btn_AllHelp;

	// Token: 0x04003105 RID: 12549
	private UIButton[] btn_MemberHelp = new UIButton[6];

	// Token: 0x04003106 RID: 12550
	private UIButton tmpbtn;

	// Token: 0x04003107 RID: 12551
	private UIHIBtn Hbtn_Player;

	// Token: 0x04003108 RID: 12552
	private UIHIBtn[] Hbtn_Member = new UIHIBtn[6];

	// Token: 0x04003109 RID: 12553
	private UIHIBtn tmpHbtn;

	// Token: 0x0400310A RID: 12554
	private Image Img_PlayerRank;

	// Token: 0x0400310B RID: 12555
	private Image[] Img_HelpFull = new Image[2];

	// Token: 0x0400310C RID: 12556
	private Image[] Img_Help = new Image[6];

	// Token: 0x0400310D RID: 12557
	private Image[] Img_ItemRank = new Image[6];

	// Token: 0x0400310E RID: 12558
	private Image[] Img_BonusRate = new Image[5];

	// Token: 0x0400310F RID: 12559
	private Image tmpImg;

	// Token: 0x04003110 RID: 12560
	private UIText text_PlayerName;

	// Token: 0x04003111 RID: 12561
	private UIText text_AllianceMoney;

	// Token: 0x04003112 RID: 12562
	private UIText text_ReSetTime;

	// Token: 0x04003113 RID: 12563
	private UIText[] text_Help1 = new UIText[3];

	// Token: 0x04003114 RID: 12564
	private UIText[] text_Help2 = new UIText[3];

	// Token: 0x04003115 RID: 12565
	private UIText[] text_ItemName = new UIText[6];

	// Token: 0x04003116 RID: 12566
	private UIText[] text_ItemHelpTitle = new UIText[6];

	// Token: 0x04003117 RID: 12567
	private UIText[] text_ItemHelpKind = new UIText[6];

	// Token: 0x04003118 RID: 12568
	private UIText[] text_ItemHelpValue = new UIText[6];

	// Token: 0x04003119 RID: 12569
	private UIText[] text_tmpStr = new UIText[5];

	// Token: 0x0400311A RID: 12570
	private UIText[] text_StrValue = new UIText[2];

	// Token: 0x0400311B RID: 12571
	private UIText tmptext;

	// Token: 0x0400311C RID: 12572
	private CString Cstr_AllianceMoney;

	// Token: 0x0400311D RID: 12573
	private CString Cstr_ReSetTime;

	// Token: 0x0400311E RID: 12574
	private CString[] Cstr_HelpTitle = new CString[2];

	// Token: 0x0400311F RID: 12575
	private CString[] Cstr_HelpValue = new CString[2];

	// Token: 0x04003120 RID: 12576
	private CString[] Cstr_StrValue = new CString[2];

	// Token: 0x04003121 RID: 12577
	private CString[] Cstr_ItemHelpTitle = new CString[6];

	// Token: 0x04003122 RID: 12578
	private CString[] Cstr_ItemHelpValue = new CString[6];

	// Token: 0x04003123 RID: 12579
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04003124 RID: 12580
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[6];

	// Token: 0x04003125 RID: 12581
	private DataManager DM;

	// Token: 0x04003126 RID: 12582
	private GUIManager GUIM;

	// Token: 0x04003127 RID: 12583
	private UISpritesArray SArray;

	// Token: 0x04003128 RID: 12584
	private Font TTFont;

	// Token: 0x04003129 RID: 12585
	private Door door;

	// Token: 0x0400312A RID: 12586
	private Material IconMaterial;

	// Token: 0x0400312B RID: 12587
	private List<float> tmplist = new List<float>();

	// Token: 0x0400312C RID: 12588
	private ushort tmpBuildID;

	// Token: 0x0400312D RID: 12589
	private RoleBuildingData tmpBuildData;

	// Token: 0x0400312E RID: 12590
	private TechDataTbl tmpTechD;

	// Token: 0x0400312F RID: 12591
	private BuildTypeData tmpBuildD;

	// Token: 0x04003130 RID: 12592
	private int mType;

	// Token: 0x04003131 RID: 12593
	private bool bShowText;

	// Token: 0x04003132 RID: 12594
	private float mShowTime;

	// Token: 0x04003133 RID: 12595
	private int mShowStatus;

	// Token: 0x04003134 RID: 12596
	private float scaleCount;
}
