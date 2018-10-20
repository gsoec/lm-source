using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200036F RID: 879
public class UIGroundInfo : IUIButtonClickHandler, IUIButtonDownUpHandler, IUICalculatorHandler
{
	// Token: 0x06001207 RID: 4615 RVA: 0x001F2BC0 File Offset: 0x001F0DC0
	public void Refresh_FontTexture()
	{
		if (this.m_GroundTitle != null && this.m_GroundTitle.enabled)
		{
			this.m_GroundTitle.enabled = false;
			this.m_GroundTitle.enabled = true;
		}
		if (this.m_ButtonText1 != null && this.m_ButtonText1.enabled)
		{
			this.m_ButtonText1.enabled = false;
			this.m_ButtonText1.enabled = true;
		}
		if (this.m_ButtonText2 != null && this.m_ButtonText2.enabled)
		{
			this.m_ButtonText2.enabled = false;
			this.m_ButtonText2.enabled = true;
		}
		if (this.m_ButtonText3 != null && this.m_ButtonText3.enabled)
		{
			this.m_ButtonText3.enabled = false;
			this.m_ButtonText3.enabled = true;
		}
		if (this.m_ButtonText6 != null && this.m_ButtonText6.enabled)
		{
			this.m_ButtonText6.enabled = false;
			this.m_ButtonText6.enabled = true;
		}
		if (this.m_ButtonText7 != null && this.m_ButtonText7.enabled)
		{
			this.m_ButtonText7.enabled = false;
			this.m_ButtonText7.enabled = true;
		}
		if (this.m_ButtonText8 != null && this.m_ButtonText8.enabled)
		{
			this.m_ButtonText8.enabled = false;
			this.m_ButtonText8.enabled = true;
		}
		if (this.m_ButtonText9 != null && this.m_ButtonText9.enabled)
		{
			this.m_ButtonText9.enabled = false;
			this.m_ButtonText9.enabled = true;
		}
		if (this.m_ButtonText10 != null && this.m_ButtonText10.enabled)
		{
			this.m_ButtonText10.enabled = false;
			this.m_ButtonText10.enabled = true;
		}
		if (this.m_LocationText != null && this.m_LocationText.enabled)
		{
			this.m_LocationText.enabled = false;
			this.m_LocationText.enabled = true;
		}
		if (this.m_GroundText != null && this.m_GroundText.enabled)
		{
			this.m_GroundText.enabled = false;
			this.m_GroundText.enabled = true;
		}
		if (this.m_ResourceText != null && this.m_ResourceText.enabled)
		{
			this.m_ResourceText.enabled = false;
			this.m_ResourceText.enabled = true;
		}
		if (this.m_ResourceProductionTitle != null && this.m_ResourceProductionTitle.enabled)
		{
			this.m_ResourceProductionTitle.enabled = false;
			this.m_ResourceProductionTitle.enabled = true;
		}
		if (this.m_ResourceProductionText != null && this.m_ResourceProductionText.enabled)
		{
			this.m_ResourceProductionText.enabled = false;
			this.m_ResourceProductionText.enabled = true;
		}
		if (this.m_ResourceOwnerText != null && this.m_ResourceOwnerText.enabled)
		{
			this.m_ResourceOwnerText.enabled = false;
			this.m_ResourceOwnerText.enabled = true;
		}
		if (this.m_SliderText1 != null && this.m_SliderText1.enabled)
		{
			this.m_SliderText1.enabled = false;
			this.m_SliderText1.enabled = true;
		}
		if (this.m_SliderText2 != null && this.m_SliderText2.enabled)
		{
			this.m_SliderText2.enabled = false;
			this.m_SliderText2.enabled = true;
		}
		if (this.m_CampTitleText != null && this.m_CampTitleText.enabled)
		{
			this.m_CampTitleText.enabled = false;
			this.m_CampTitleText.enabled = true;
		}
		if (this.m_IDText != null && this.m_IDText.enabled)
		{
			this.m_IDText.enabled = false;
			this.m_IDText.enabled = true;
		}
		if (this.m_StrengthText != null && this.m_StrengthText.enabled)
		{
			this.m_StrengthText.enabled = false;
			this.m_StrengthText.enabled = true;
		}
		if (this.m_WipeOutText != null && this.m_WipeOutText.enabled)
		{
			this.m_WipeOutText.enabled = false;
			this.m_WipeOutText.enabled = true;
		}
		if (this.m_LeagueText != null && this.m_LeagueText.enabled)
		{
			this.m_LeagueText.enabled = false;
			this.m_LeagueText.enabled = true;
		}
		if (this.m_KingdomText != null && this.m_KingdomText.enabled)
		{
			this.m_KingdomText.enabled = false;
			this.m_KingdomText.enabled = true;
		}
		if (this.m_VipText != null && this.m_VipText.enabled)
		{
			this.m_VipText.enabled = false;
			this.m_VipText.enabled = true;
		}
		if (this.m_RankText != null && this.m_RankText.enabled)
		{
			this.m_RankText.enabled = false;
			this.m_RankText.enabled = true;
		}
		if (this.m_TeamLocText != null && this.m_TeamLocText.enabled)
		{
			this.m_TeamLocText.enabled = false;
			this.m_TeamLocText.enabled = true;
		}
		if (this.m_TimeText != null && this.m_TimeText.enabled)
		{
			this.m_TimeText.enabled = false;
			this.m_TimeText.enabled = true;
		}
		if (this.m_TeamReturnText != null && this.m_TeamReturnText.enabled)
		{
			this.m_TeamReturnText.enabled = false;
			this.m_TeamReturnText.enabled = true;
		}
		if (this.m_TeamTargetText != null && this.m_TeamTargetText.enabled)
		{
			this.m_TeamTargetText.enabled = false;
			this.m_TeamTargetText.enabled = true;
		}
		if (this.m_PveTitle != null && this.m_PveTitle.enabled)
		{
			this.m_PveTitle.enabled = false;
			this.m_PveTitle.enabled = true;
		}
		if (this.m_PveHeroName != null && this.m_PveHeroName.enabled)
		{
			this.m_PveHeroName.enabled = false;
			this.m_PveHeroName.enabled = true;
		}
		if (this.m_PvePowerText != null && this.m_PvePowerText.enabled)
		{
			this.m_PvePowerText.enabled = false;
			this.m_PvePowerText.enabled = true;
		}
		if (this.m_RewardText != null && this.m_RewardText.enabled)
		{
			this.m_RewardText.enabled = false;
			this.m_RewardText.enabled = true;
		}
		if (this.m_HintText != null && this.m_HintText.enabled)
		{
			this.m_HintText.enabled = false;
			this.m_HintText.enabled = true;
		}
		if (this.m_TeamIDText != null && this.m_TeamIDText.enabled)
		{
			this.m_TeamIDText.enabled = false;
			this.m_TeamIDText.enabled = true;
		}
		if (this.m_TempText != null)
		{
			for (int i = 0; i < this.m_TempText.Length; i++)
			{
				if (this.m_TempText[i] != null && this.m_TempText[i].enabled)
				{
					this.m_TempText[i].enabled = false;
					this.m_TempText[i].enabled = true;
				}
			}
		}
		if (this.inputField != null)
		{
			if (this.inputField.textComponent != null && this.inputField.textComponent.enabled)
			{
				this.inputField.placeholder.enabled = false;
				this.inputField.placeholder.enabled = true;
			}
			if (this.inputField.placeholder != null && this.inputField.placeholder.enabled)
			{
				this.inputField.placeholder.enabled = false;
				this.inputField.placeholder.enabled = true;
			}
		}
		if (this.m_CampHiBtn != null && this.m_CampHiBtn.enabled)
		{
			this.m_CampHiBtn.Refresh_FontTexture();
		}
		if (this.m_PveHeroBtn != null && this.m_PveHeroBtn.enabled)
		{
			this.m_PveHeroBtn.Refresh_FontTexture();
		}
		if (this.m_WonderID != null && this.m_WonderID.enabled)
		{
			this.m_WonderID.enabled = false;
			this.m_WonderID.enabled = true;
		}
		if (this.m_WonderState != null && this.m_WonderState.enabled)
		{
			this.m_WonderState.enabled = false;
			this.m_WonderState.enabled = true;
		}
		if (this.m_WonderTime != null && this.m_WonderTime.enabled)
		{
			this.m_WonderTime.enabled = false;
			this.m_WonderTime.enabled = true;
		}
		if (this.m_WonderAlliance != null && this.m_WonderAlliance.enabled)
		{
			this.m_WonderAlliance.enabled = false;
			this.m_WonderAlliance.enabled = true;
		}
		if (this.m_WonderOwner != null && this.m_WonderOwner.enabled)
		{
			this.m_WonderOwner.enabled = false;
			this.m_WonderOwner.enabled = true;
		}
		if (this.m_WonderKingdom != null && this.m_WonderKingdom.enabled)
		{
			this.m_WonderKingdom.enabled = false;
			this.m_WonderKingdom.enabled = true;
		}
		if (this.m_DetectPanelText != null && this.m_DetectPanelText.enabled)
		{
			this.m_DetectPanelText.enabled = false;
			this.m_DetectPanelText.enabled = true;
		}
		if (this.m_AttackPanelTimeText != null)
		{
			for (int j = 0; j < this.m_AttackPanelTimeText.Length; j++)
			{
				if (this.m_AttackPanelTimeText[j] != null && this.m_AttackPanelTimeText[j].enabled)
				{
					this.m_AttackPanelTimeText[j].enabled = false;
					this.m_AttackPanelTimeText[j].enabled = true;
				}
			}
		}
		if (this.m_AttackPanelTitleText != null && this.m_AttackPanelTitleText.enabled)
		{
			this.m_AttackPanelTitleText.enabled = false;
			this.m_AttackPanelTitleText.enabled = true;
		}
		if (this.m_AttackPanelInfoText != null && this.m_AttackPanelInfoText.enabled)
		{
			this.m_AttackPanelInfoText.enabled = false;
			this.m_AttackPanelInfoText.enabled = true;
		}
		if (this.m_AttackPanelPosText != null && this.m_AttackPanelPosText.enabled)
		{
			this.m_AttackPanelPosText.enabled = false;
			this.m_AttackPanelPosText.enabled = true;
		}
		if (this.m_NpcCastleIDText != null && this.m_NpcCastleIDText.enabled)
		{
			this.m_NpcCastleIDText.enabled = false;
			this.m_NpcCastleIDText.enabled = true;
		}
		if (this.m_NpcCastleStrengthText != null && this.m_NpcCastleStrengthText.enabled)
		{
			this.m_NpcCastleStrengthText.enabled = false;
			this.m_NpcCastleStrengthText.enabled = true;
		}
		if (this.m_NpcCastleTimeText != null && this.m_NpcCastleTimeText.enabled)
		{
			this.m_NpcCastleTimeText.enabled = false;
			this.m_NpcCastleTimeText.enabled = true;
		}
		if (this.m_NpcCastleInfoText != null && this.m_NpcCastleInfoText.enabled)
		{
			this.m_NpcCastleInfoText.enabled = false;
			this.m_NpcCastleInfoText.enabled = true;
		}
	}

	// Token: 0x06001208 RID: 4616 RVA: 0x001F3884 File Offset: 0x001F1A84
	public void Load(Door door)
	{
		this.sb = new StringBuilder();
		for (int i = 0; i < 51; i++)
		{
			this.m_Str[i] = StringManager.Instance.SpawnString(100);
		}
		this.BookMarkNameStr = StringManager.Instance.SpawnString(30);
		this.m_AssetBundle = AssetManager.GetAssetBundle("UI/UIGroundInfo", out this.m_AssetBundleKey, false);
		if (this.m_AssetBundle == null)
		{
			return;
		}
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.m_AssetBundle.mainAsset);
		this.m_RectTransform = (RectTransform)gameObject.transform;
		this.m_Door = door;
		this.m_RectTransform.SetParent(this.m_Door.m_TopLayer, false);
		this.m_Panel = (RectTransform)this.m_RectTransform.GetChild(0);
		this.m_PanelGameObject = this.m_Panel.gameObject;
		this.m_PanelGameObject.SetActive(false);
		this.m_TeamPanel = (RectTransform)this.m_RectTransform.GetChild(1);
		this.m_TeamPanelGameObject = this.m_TeamPanel.gameObject;
		this.m_TeamPanelGameObject.SetActive(false);
		this.m_BGPanel = (RectTransform)this.m_Panel.GetChild(0);
		this.m_ButtonPanel = (RectTransform)this.m_Panel.GetChild(1);
		this.m_GroundPanel = (RectTransform)this.m_Panel.GetChild(2);
		this.m_ResourcePanel = (RectTransform)this.m_Panel.GetChild(3);
		this.m_CampPanel = (RectTransform)this.m_Panel.GetChild(4);
		this.m_WondersPanel = (RectTransform)this.m_Panel.GetChild(5);
		this.m_NpcCastlePanel = (RectTransform)this.m_Panel.GetChild(6);
		this.m_LocationRt = (RectTransform)this.m_Panel.GetChild(7);
		Transform child = this.m_Panel.GetChild(7);
		this.m_LocationText = child.GetComponent<UIText>();
		this.m_LocationText.font = GUIManager.Instance.GetTTFFont();
		this.m_ChatBtnRt = (RectTransform)this.m_Panel.GetChild(8);
		this.m_BookmarkBtn = this.m_Panel.GetChild(9).GetComponent<UIButton>();
		this.m_ExpressionBtn = this.m_Panel.GetChild(11).GetComponent<UIButton>();
		this.m_ExpressionBtn.m_Handler = this;
		this.m_ExpressionBtn.m_BtnID2 = 329;
		this.m_Exclamationmark = this.m_Panel.GetChild(11).GetChild(0);
		UIButton component;
		for (int j = 8; j < 11; j++)
		{
			child = this.m_Panel.GetChild(j);
			component = child.GetComponent<UIButton>();
			component.m_Handler = this;
		}
		this.m_GroundTextBGRect = (RectTransform)this.m_BGPanel.GetChild(2);
		child = this.m_BGPanel.GetChild(4);
		child = child.GetChild(0);
		this.m_BGIcon = child.GetComponent<Image>();
		UIButtonHint uibuttonHint = child.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 11;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		child = child.GetChild(0);
		this.m_BGIconMask = child.GetComponent<Image>();
		child = this.m_BGPanel.GetChild(5);
		this.m_GroundTitle = child.GetComponent<UIText>();
		this.m_GroundTitle.font = GUIManager.Instance.GetTTFFont();
		this.m_GroundTitle.text = DataManager.Instance.mStringTable.GetStringByID(4579u);
		this.m_CityOutwardLevelTf = (RectTransform)this.m_BGPanel.GetChild(4).GetChild(0).GetChild(1);
		for (int k = 0; k < this.m_CityOutwardLevelImages.Length; k++)
		{
			child = this.m_CityOutwardLevelTf.GetChild(k);
			if (child != null)
			{
				this.m_CityOutwardLevelImages[k] = child.GetComponent<Image>();
			}
		}
		this.m_ButtonRect1 = (RectTransform)this.m_ButtonPanel.GetChild(0);
		this.m_Buttons[0] = this.m_ButtonRect1.GetComponent<UIButton>();
		this.m_Buttons[0].m_Handler = this;
		child = this.m_ButtonRect1.GetChild(0);
		this.m_ButtonText1 = child.GetComponent<UIText>();
		this.m_ButtonText1.font = GUIManager.Instance.GetTTFFont();
		this.m_ButtonRect2 = (RectTransform)this.m_ButtonPanel.GetChild(1);
		this.m_Buttons[1] = this.m_ButtonRect2.GetComponent<UIButton>();
		this.m_Buttons[1].m_Handler = this;
		child = this.m_ButtonRect2.GetChild(0);
		this.m_ButtonText2 = child.GetComponent<UIText>();
		this.m_ButtonText2.font = GUIManager.Instance.GetTTFFont();
		this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4538u);
		this.m_ButtonRect3 = (RectTransform)this.m_ButtonPanel.GetChild(2);
		this.m_Buttons[2] = this.m_ButtonRect3.GetComponent<UIButton>();
		this.m_Buttons[2].m_Handler = this;
		child = this.m_ButtonRect3.GetChild(0);
		this.m_ButtonText3 = child.GetComponent<UIText>();
		this.m_ButtonText3.font = GUIManager.Instance.GetTTFFont();
		this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4544u);
		this.m_ButtonRect4 = (RectTransform)this.m_ButtonPanel.GetChild(3);
		child = this.m_ButtonRect4.GetChild(0);
		this.m_Buttons[3] = this.m_ButtonRect4.GetComponent<UIButton>();
		this.m_Buttons[3].m_Handler = this;
		child = this.m_ButtonRect4.GetChild(1);
		UIText component2 = child.GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4533u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_ButtonRect5 = (RectTransform)this.m_ButtonPanel.GetChild(4);
		child = this.m_ButtonRect5.GetChild(0);
		this.m_Buttons[4] = this.m_ButtonRect5.GetComponent<UIButton>();
		this.m_Buttons[4].m_Handler = this;
		child = this.m_ButtonRect5.GetChild(1);
		component2 = child.GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4534u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_ButtonRect6 = (RectTransform)this.m_ButtonPanel.GetChild(5);
		this.m_Buttons[5] = this.m_ButtonRect6.GetComponent<UIButton>();
		this.m_Buttons[5].m_Handler = this;
		child = this.m_ButtonRect6.GetChild(0);
		this.m_ButtonText6 = child.GetComponent<UIText>();
		this.m_ButtonText6.font = GUIManager.Instance.GetTTFFont();
		this.m_ButtonRect7 = (RectTransform)this.m_ButtonPanel.GetChild(6);
		this.m_Buttons[6] = this.m_ButtonRect7.GetComponent<UIButton>();
		this.m_Buttons[6].m_Handler = this;
		child = this.m_ButtonRect7.GetChild(0);
		this.m_ButtonText7 = child.GetComponent<UIText>();
		this.m_ButtonText7.font = GUIManager.Instance.GetTTFFont();
		this.m_ButtonRect8 = (RectTransform)this.m_ButtonPanel.GetChild(7);
		this.m_Buttons[7] = this.m_ButtonRect8.GetComponent<UIButton>();
		this.m_Buttons[7].m_Handler = this;
		child = this.m_ButtonRect8.GetChild(0);
		this.m_ButtonText8 = child.GetComponent<UIText>();
		this.m_ButtonText8.font = GUIManager.Instance.GetTTFFont();
		this.m_ButtonRect9 = (RectTransform)this.m_ButtonPanel.GetChild(8);
		this.m_Buttons[8] = this.m_ButtonRect9.GetComponent<UIButton>();
		this.m_Buttons[8].m_Handler = this;
		child = this.m_ButtonRect9.GetChild(0);
		this.m_ButtonText9 = child.GetComponent<UIText>();
		this.m_ButtonText9.font = GUIManager.Instance.GetTTFFont();
		this.m_ButtonRect10 = (RectTransform)this.m_ButtonPanel.GetChild(9);
		this.m_CustmCastleExclamation = (RectTransform)this.m_ButtonPanel.GetChild(9).GetChild(2);
		this.m_Buttons[9] = this.m_ButtonRect10.GetComponent<UIButton>();
		this.m_Buttons[9].m_Handler = this;
		child = this.m_ButtonRect10.GetChild(0);
		this.m_ButtonText10 = child.GetComponent<UIText>();
		this.m_ButtonText10.font = GUIManager.Instance.GetTTFFont();
		this.m_ButtonRect11 = (RectTransform)this.m_ButtonPanel.GetChild(10);
		this.m_Buttons[10] = this.m_ButtonRect11.GetComponent<UIButton>();
		this.m_Buttons[10].m_Handler = this;
		child = this.m_ButtonRect11.GetChild(0);
		this.m_ButtonText11 = child.GetComponent<UIText>();
		this.m_ButtonText11.font = GUIManager.Instance.GetTTFFont();
		child = this.m_GroundPanel.GetChild(0);
		this.m_GroundText = child.GetComponent<UIText>();
		this.m_GroundText.font = GUIManager.Instance.GetTTFFont();
		this.m_SpriteArray = this.m_ResourcePanel.GetComponent<UISpritesArray>();
		child = this.m_ResourcePanel.GetChild(0);
		this.m_ResourceIcon = child.GetComponent<Image>();
		child = this.m_ResourcePanel.GetChild(1);
		this.m_ResourceText = child.GetComponent<UIText>();
		this.m_ResourceText.font = GUIManager.Instance.GetTTFFont();
		child = this.m_ResourcePanel.GetChild(2);
		this.m_ResourceProductionTitle = child.GetComponent<UIText>();
		this.m_ResourceProductionTitle.font = GUIManager.Instance.GetTTFFont();
		this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4524u);
		child = this.m_ResourcePanel.GetChild(3);
		this.m_ResourceProductionText = child.GetComponent<UIText>();
		this.m_ResourceProductionText.font = GUIManager.Instance.GetTTFFont();
		RectTransform rectTransform = (RectTransform)this.m_ResourcePanel.GetChild(4);
		component2 = rectTransform.GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4530u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		rectTransform = (RectTransform)this.m_ResourcePanel.GetChild(5);
		this.m_ResourceOwnerText = rectTransform.GetComponent<UIText>();
		this.m_ResourceOwnerText.font = GUIManager.Instance.GetTTFFont();
		child = this.m_ResourcePanel.GetChild(9);
		this.m_ValueBar1 = child.GetComponent<RectTransform>();
		this.m_Slider11 = this.m_ValueBar1.GetChild(0).GetComponent<Image>();
		this.m_Slider12 = this.m_ValueBar1.GetChild(1).GetComponent<Image>();
		this.m_SliderText1 = this.m_ValueBar1.GetChild(2).GetComponent<UIText>();
		this.m_SliderText1.font = GUIManager.Instance.GetTTFFont();
		child = this.m_ResourcePanel.GetChild(10);
		this.m_ValueBar2 = child.GetComponent<RectTransform>();
		this.m_Slider2 = this.m_ValueBar2.GetChild(0).GetComponent<Image>();
		this.m_SliderText2 = this.m_ValueBar2.GetChild(1).GetComponent<UIText>();
		this.m_SliderText2.font = GUIManager.Instance.GetTTFFont();
		this.m_InformationBtn = this.m_ResourcePanel.GetChild(11).GetComponent<UIButton>();
		this.m_InformationBtn.m_BtnID2 = 323;
		this.m_InformationBtn.m_Handler = this;
		if (GUIManager.Instance.IsArabic)
		{
			this.m_InformationBtn.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		child = gameObject.transform.GetChild(0).GetChild(4);
		this.m_CampHiBtn = child.GetChild(4).GetComponent<UIHIBtn>();
		this.m_CampHiBtn.transform.gameObject.AddComponent<IgnoreRaycast>();
		GUIManager.Instance.InitianHeroItemImg(this.m_CampHiBtn.transform, eHeroOrItem.Hero, 1, 11, 0, 0, false, false, true, false);
		this.m_CampTitleTextRt = child.GetChild(5).GetComponent<RectTransform>();
		this.m_CampTitleText = child.GetChild(5).GetComponent<UIText>();
		this.m_IDTextRt = child.GetChild(6).GetComponent<RectTransform>();
		this.m_IDText = child.GetChild(6).GetComponent<UIText>();
		this.m_StrengthText = child.GetChild(7).GetComponent<UIText>();
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component3 = child.GetChild(7).GetChild(0).GetComponent<RectTransform>();
			Vector2 anchoredPosition = component3.anchoredPosition;
			anchoredPosition.x = 130f;
			component3.anchoredPosition = anchoredPosition;
			component3 = child.GetChild(8).GetChild(0).GetComponent<RectTransform>();
			anchoredPosition.x = 130f;
			component3.anchoredPosition = anchoredPosition;
		}
		uibuttonHint = child.GetChild(7).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 3;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint = child.GetChild(7).GetChild(0).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 3;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.m_WipeOutText = child.GetChild(8).GetComponent<UIText>();
		uibuttonHint = child.GetChild(8).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 4;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint = child.GetChild(8).GetChild(0).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 4;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.m_LeagueText = child.GetChild(9).GetComponent<UIText>();
		this.m_KingdomText = child.GetChild(10).GetComponent<UIText>();
		this.m_CampTitleText.font = GUIManager.Instance.GetTTFFont();
		this.m_IDText.font = GUIManager.Instance.GetTTFFont();
		this.m_StrengthText.font = GUIManager.Instance.GetTTFFont();
		this.m_WipeOutText.font = GUIManager.Instance.GetTTFFont();
		this.m_LeagueText.font = GUIManager.Instance.GetTTFFont();
		this.m_KingdomText.font = GUIManager.Instance.GetTTFFont();
		this.m_VipText = this.m_CampPanel.GetChild(3).GetChild(1).GetComponent<UIText>();
		this.m_VipText.font = GUIManager.Instance.GetTTFFont();
		this.m_VipTf = this.m_CampPanel.GetChild(3);
		if (GUIManager.Instance.IsArabic)
		{
			Vector2 anchoredPosition2 = this.m_VipTf.GetChild(0).GetComponent<RectTransform>().anchoredPosition;
			Vector3 localScale = this.m_VipTf.GetChild(0).GetComponent<RectTransform>().localScale;
			localScale.x *= -1f;
			this.m_VipTf.GetChild(0).GetComponent<RectTransform>().localScale = localScale;
			anchoredPosition2.x = 38f;
			this.m_VipTf.GetChild(0).GetComponent<RectTransform>().anchoredPosition = anchoredPosition2;
		}
		this.m_RankText = this.m_CampPanel.GetChild(2).GetChild(1).GetComponent<UIText>();
		this.m_RankText.font = GUIManager.Instance.GetTTFFont();
		this.m_RankTf = this.m_CampPanel.GetChild(2);
		if (GUIManager.Instance.IsArabic)
		{
			Vector2 anchoredPosition3 = this.m_RankTf.GetChild(0).GetComponent<RectTransform>().anchoredPosition;
			Vector3 localScale2 = this.m_RankTf.GetChild(0).GetComponent<RectTransform>().localScale;
			localScale2.x *= -1f;
			this.m_RankTf.GetChild(0).GetComponent<RectTransform>().localScale = localScale2;
			anchoredPosition3.x = -51f;
			this.m_RankTf.GetChild(0).GetComponent<RectTransform>().anchoredPosition = anchoredPosition3;
		}
		uibuttonHint = this.m_RankTf.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 1;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint = this.m_VipTf.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 2;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.m_RankImage = this.m_RankTf.GetChild(0).GetComponent<Image>();
		this.m_TitleIcon = this.m_CampPanel.GetChild(11).GetComponent<Image>();
		uibuttonHint = this.m_CampPanel.GetChild(11).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 5;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.m_WorldTitleIcon = this.m_CampPanel.GetChild(12).GetComponent<Image>();
		uibuttonHint = this.m_CampPanel.GetChild(12).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 8;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.m_NobilityTitleIcon = this.m_CampPanel.GetChild(13).GetComponent<Image>();
		uibuttonHint = this.m_CampPanel.GetChild(13).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 12;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.m_PetSkillTf = this.m_CampPanel.GetChild(14);
		this.m_PetSkillUse = this.m_CampPanel.GetChild(15).GetComponent<UIButton>();
		this.m_PetSkillUse.m_Handler = this;
		this.m_PetSkillUse.m_BtnID2 = 331;
		Image component4;
		for (int l = 0; l < this.m_PetNegativeBuff.Length; l++)
		{
			this.m_PetNegativeBuff[l] = this.m_PetSkillTf.GetChild(l + 1).GetComponent<Image>();
			component4 = this.m_PetNegativeBuff[l].transform.GetChild(0).GetComponent<Image>();
			component4.sprite = GUIManager.Instance.LoadFrameSprite("sk");
			component4.material = GUIManager.Instance.GetFrameMaterial();
			uibuttonHint = this.m_PetSkillTf.GetChild(l + 1).gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_DownUpHandler = this;
			uibuttonHint.Parm1 = 14;
			uibuttonHint.Parm2 = (byte)l;
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		}
		this.m_HintPanel = this.m_RectTransform.GetChild(9);
		this.m_HintBg = this.m_RectTransform.GetChild(9).GetComponent<Image>();
		this.m_HintText = this.m_HintPanel.GetChild(0).GetComponent<UIText>();
		this.m_HintText.font = GUIManager.Instance.GetTTFFont();
		component4 = this.m_HintPanel.GetComponent<Image>();
		component4.sprite = door.LoadSprite("UI_main_box_012");
		component4.material = door.LoadMaterial();
		component4.type = Image.Type.Sliced;
		this.m_WonderAllianeIcon = this.m_WondersPanel.GetChild(1);
		GUIManager.Instance.InitBadgeTotem(this.m_WonderAllianeIcon, 0);
		this.m_WonderAllianeFrame = this.m_WondersPanel.GetChild(0).GetComponent<Image>();
		this.m_WonderHIBtn = this.m_WondersPanel.GetChild(2).GetComponent<UIHIBtn>();
		GUIManager.Instance.InitianHeroItemImg(this.m_WonderHIBtn.transform, eHeroOrItem.Hero, 11, 1, 0, 0, false, false, true, false);
		if (GUIManager.Instance.IsArabic)
		{
			this.m_WonderHIBtn.transform.GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.m_WonderID = this.m_WondersPanel.GetChild(4).GetComponent<UIText>();
		this.m_WonderID.font = GUIManager.Instance.GetTTFFont();
		this.m_WonderState = this.m_WondersPanel.GetChild(5).GetComponent<UIText>();
		uibuttonHint = this.m_WondersPanel.GetChild(5).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 6;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint = this.m_WondersPanel.GetChild(6).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 7;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.m_WonderState.font = GUIManager.Instance.GetTTFFont();
		this.m_WonderStateImage1 = this.m_WondersPanel.GetChild(5).GetChild(0).GetComponent<Image>();
		this.m_WonderStateImage2 = this.m_WondersPanel.GetChild(5).GetChild(1).GetComponent<Image>();
		this.m_WonderStateImage3 = this.m_WondersPanel.GetChild(5).GetChild(2).GetComponent<Image>();
		this.m_WonderTimeTF = this.m_WondersPanel.GetChild(6);
		this.m_WonderTime = this.m_WonderTimeTF.GetComponent<UIText>();
		this.m_WonderTime.font = GUIManager.Instance.GetTTFFont();
		if (GUIManager.Instance.IsArabic)
		{
			Vector2 anchoredPosition4 = this.m_WonderStateImage1.rectTransform.anchoredPosition;
			anchoredPosition4.x = 139f;
			this.m_WonderStateImage1.rectTransform.anchoredPosition = anchoredPosition4;
			anchoredPosition4 = this.m_WonderStateImage2.rectTransform.anchoredPosition;
			anchoredPosition4.x = 139f;
			this.m_WonderStateImage2.rectTransform.anchoredPosition = anchoredPosition4;
			anchoredPosition4 = this.m_WonderStateImage3.rectTransform.anchoredPosition;
			anchoredPosition4.x = 139f;
			this.m_WonderStateImage3.rectTransform.anchoredPosition = anchoredPosition4;
			RectTransform component5 = this.m_WondersPanel.GetChild(6).GetChild(0).GetComponent<RectTransform>();
			anchoredPosition4 = component5.anchoredPosition;
			anchoredPosition4.x = 138f;
			component5.anchoredPosition = anchoredPosition4;
		}
		this.m_WonderAlliance = this.m_WondersPanel.GetChild(7).GetComponent<UIText>();
		this.m_WonderAlliance.font = GUIManager.Instance.GetTTFFont();
		this.m_WonderOwner = this.m_WondersPanel.GetChild(8).GetComponent<UIText>();
		this.m_WonderOwner.font = GUIManager.Instance.GetTTFFont();
		this.m_WonderKingdom = this.m_WondersPanel.GetChild(9).GetComponent<UIText>();
		this.m_WonderKingdom.font = GUIManager.Instance.GetTTFFont();
		this.m_TeamExitBtn = this.m_TeamPanel.GetChild(3).GetComponent<UIButton>();
		this.m_TeamExitBtn.m_BtnID2 = 203;
		this.m_TeamExitBtn.m_Handler = this;
		this.m_TeamIDBtn = this.m_TeamPanel.GetChild(4).GetComponent<UIButton>();
		this.m_TeamIDBtn.m_Handler = this;
		this.m_TeamIDBtn.m_BtnID2 = 204;
		this.m_TeamIDLine = this.m_TeamPanel.GetChild(4).GetChild(0).GetComponent<Image>();
		this.m_TeamIDText = this.m_TeamPanel.GetChild(4).GetChild(1).GetComponent<UIText>();
		this.m_TeamIDText.font = GUIManager.Instance.GetTTFFont();
		this.m_TeamTargetText = this.m_TeamPanel.GetChild(5).GetComponent<UIText>();
		this.m_TeamTargetText.font = GUIManager.Instance.GetTTFFont();
		this.m_TeamTargetText.text = DataManager.Instance.mStringTable.GetStringByID(4572u);
		this.m_TeamLocBtn = this.m_TeamPanel.GetChild(6).GetComponent<UIButton>();
		this.m_TeamLocBtn.m_Handler = this;
		this.m_TeamLocBtn.m_BtnID2 = 205;
		this.m_TeamLocLine = this.m_TeamPanel.GetChild(6).GetChild(0).GetComponent<Image>();
		this.m_TeamLocText = this.m_TeamPanel.GetChild(6).GetChild(1).GetComponent<UIText>();
		this.m_TeamLocText.font = GUIManager.Instance.GetTTFFont();
		this.m_TeamRetureBtn = this.m_TeamPanel.GetChild(9).GetChild(0).GetComponent<UIButton>();
		component2 = this.m_TeamPanel.GetChild(9).GetChild(0).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4558u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_TeamRetureBtn.m_BtnID2 = 201;
		this.m_TeamRetureBtn.m_Handler = this;
		this.m_TeamSpeedBtn = this.m_TeamPanel.GetChild(9).GetChild(1).GetComponent<UIButton>();
		this.m_TeamSpeedBtnGameObject = this.m_TeamSpeedBtn.gameObject;
		component2 = this.m_TeamPanel.GetChild(9).GetChild(1).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(3825u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_TeamSpeedBtn.m_BtnID2 = 202;
		this.m_TeamSpeedBtn.m_Handler = this;
		this.m_TeamReturnText = this.m_TeamPanel.GetChild(7).GetComponent<UIText>();
		this.m_TeamReturnText.font = GUIManager.Instance.GetTTFFont();
		this.m_TeamReturnText.text = DataManager.Instance.mStringTable.GetStringByID(4574u);
		this.m_TimeText = this.m_TeamPanel.GetChild(8).GetComponent<UIText>();
		this.m_TimeText.font = GUIManager.Instance.GetTTFFont();
		this.m_TeamExpressionBtn = this.m_TeamPanel.GetChild(10).GetComponent<UIButton>();
		this.m_TeamExpressionBtn.m_Handler = this;
		this.m_TeamExpressionBtn.m_BtnID2 = 329;
		this.m_TeamExclamationmark = this.m_TeamPanel.GetChild(10).GetChild(0);
		this.m_SearchPanel = (RectTransform)this.m_RectTransform.GetChild(2);
		component2 = this.m_SearchPanel.GetChild(11).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4501u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_SearchPanel.GetChild(4).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4502u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_SearchPanel.GetChild(15).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_SearchPanel.GetChild(6).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4507u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_SearchPanel.GetChild(12).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		if (GUIManager.Instance.IsArabic)
		{
			component2.text = ":K";
		}
		else
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(4504u);
		}
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_SearchPanel.GetChild(13).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		if (GUIManager.Instance.IsArabic)
		{
			component2.text = ":X";
		}
		else
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(4505u);
		}
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_SearchPanel.GetChild(14).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		if (GUIManager.Instance.IsArabic)
		{
			component2.text = ":Y";
		}
		else
		{
			component2.text = DataManager.Instance.mStringTable.GetStringByID(4506u);
		}
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_SearchPanel.GetChild(8).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component = this.m_SearchPanel.GetChild(8).GetComponent<UIButton>();
		component.m_BtnID2 = 324;
		component.m_Handler = this;
		component2 = this.m_SearchPanel.GetChild(9).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component = this.m_SearchPanel.GetChild(9).GetComponent<UIButton>();
		component.m_BtnID2 = 325;
		component.m_Handler = this;
		component2 = this.m_SearchPanel.GetChild(10).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component = this.m_SearchPanel.GetChild(10).GetComponent<UIButton>();
		component.m_BtnID2 = 326;
		component.m_Handler = this;
		component = this.m_SearchPanel.GetChild(6).GetComponent<UIButton>();
		component.m_BtnID2 = 301;
		component.m_Handler = this;
		component = this.m_SearchPanel.GetChild(7).GetComponent<UIButton>();
		component.m_BtnID2 = 302;
		component.m_Handler = this;
		component = this.m_SearchPanel.GetComponent<UIButton>();
		component.m_BtnID2 = 302;
		component.m_Handler = this;
		component2 = this.m_SearchPanel.GetChild(16).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(14581u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_SearchPanel.GetChild(16).GetChild(2).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		this.m_Str[50].ClearString();
		this.m_Str[50].IntToFormat(71L, 1, false);
		this.m_Str[50].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(14582u));
		component2.text = this.m_Str[50].ToString();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component4 = this.m_SearchPanel.GetChild(16).GetChild(2).GetChild(2).GetComponent<Image>();
		this.SetCenterText(component4, component2, 416.42f);
		component4 = this.m_SearchPanel.GetChild(16).GetChild(2).GetChild(1).GetComponent<Image>();
		component4.rectTransform.sizeDelta = new Vector2(component2.preferredWidth, 3f);
		component4.rectTransform.anchoredPosition = new Vector2(component2.rectTransform.anchoredPosition.x, component4.rectTransform.anchoredPosition.y);
		RectTransform component6 = this.m_SearchPanel.GetChild(16).GetChild(2).GetChild(3).GetComponent<RectTransform>();
		component6.sizeDelta = component2.rectTransform.sizeDelta;
		component6.anchoredPosition = component2.rectTransform.anchoredPosition;
		component = this.m_SearchPanel.GetChild(16).GetChild(2).GetChild(3).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = 330;
		uibuttonHint = this.m_SearchPanel.GetChild(16).GetChild(2).GetChild(2).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.Parm1 = 13;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_DownUpHandler = this;
		this.m_ReinforcePanel = (RectTransform)this.m_RectTransform.GetChild(3);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			this.m_ReinforcePanel.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			this.m_ReinforcePanel.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		component2 = this.m_ReinforcePanel.GetChild(4).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_ReinforcePanel.GetChild(7).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4591u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_ReinforcePanel.GetChild(6).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4553u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_ReinforcePanel.GetChild(9).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4553u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_ReinforcePanel.GetChild(8).GetChild(3).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component = this.m_ReinforcePanel.GetChild(9).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = 303;
		component = this.m_ReinforcePanel.GetChild(10).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = 304;
		HelperUIButton helperUIButton = this.m_ReinforcePanel.gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID2 = 304;
		this.m_DetectPanel = (RectTransform)this.m_RectTransform.GetChild(4);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			this.m_DetectPanel.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			this.m_DetectPanel.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		component2 = this.m_DetectPanel.GetChild(6).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4533u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_DetectPanelText = this.m_DetectPanel.GetChild(7).GetComponent<UIText>();
		this.m_DetectPanelText.font = GUIManager.Instance.GetTTFFont();
		this.m_DetectPanelText.text = DataManager.Instance.mStringTable.GetStringByID(4536u);
		component2 = this.m_DetectPanel.GetChild(4).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_DetectPanel.GetChild(8).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_DetectPanel.GetChild(9).GetChild(2).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4533u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_DetectPanel.GetChild(9).GetChild(1).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component = this.m_DetectPanel.GetChild(9).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = 305;
		component = this.m_DetectPanel.GetChild(10).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = 306;
		helperUIButton = this.m_DetectPanel.gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID2 = 306;
		this.m_AttackPanel = (RectTransform)this.m_RectTransform.GetChild(5);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			this.m_AttackPanel.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			this.m_AttackPanel.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		helperUIButton = this.m_AttackPanel.gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID2 = 308;
		this.m_AttackPanelIcon = this.m_AttackPanel.GetChild(5).GetComponent<Image>();
		this.m_AttackPanelTitleText = this.m_AttackPanel.GetChild(6).GetComponent<UIText>();
		this.m_AttackPanelTitleText.font = GUIManager.Instance.GetTTFFont();
		this.m_AttackPanelTitleText.text = DataManager.Instance.mStringTable.GetStringByID(4554u);
		this.m_AttackPanelPosTf = this.m_AttackPanel.GetChild(4);
		this.m_AttackPanelPosText = this.m_AttackPanel.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.m_AttackPanelPosText.font = GUIManager.Instance.GetTTFFont();
		this.m_AttackPanelInfoText = this.m_AttackPanel.GetChild(9).GetComponent<UIText>();
		this.m_AttackPanelInfoText.font = GUIManager.Instance.GetTTFFont();
		this.m_AttackPanelInfoText.text = DataManager.Instance.mStringTable.GetStringByID(4593u);
		this.m_AttackPanelTimeText[0] = this.m_AttackPanel.GetChild(10).GetChild(2).GetComponent<UIText>();
		this.m_AttackPanelTimeText[0].font = GUIManager.Instance.GetTTFFont();
		this.m_AttackPanelTimeBtn[0] = this.m_AttackPanel.GetChild(10).GetComponent<UIButton>();
		this.m_AttackPanelTimeBtn[0].m_BtnID2 = 309;
		this.m_AttackPanelTimeBtn[0].m_Handler = this;
		this.m_AttackPanelTimeText[0].text = DataManager.Instance.mStringTable.GetStringByID(4594u);
		this.m_AttackPanelTimeSelectImg[0] = this.m_AttackPanel.GetChild(10).GetChild(1).GetComponent<Image>();
		this.m_AttackPanelTimeText[1] = this.m_AttackPanel.GetChild(11).GetChild(2).GetComponent<UIText>();
		this.m_AttackPanelTimeText[1].font = GUIManager.Instance.GetTTFFont();
		this.m_AttackPanelTimeBtn[1] = this.m_AttackPanel.GetChild(11).GetComponent<UIButton>();
		this.m_AttackPanelTimeBtn[1].m_BtnID2 = 310;
		this.m_AttackPanelTimeBtn[1].m_Handler = this;
		this.m_AttackPanelTimeText[1].text = DataManager.Instance.mStringTable.GetStringByID(4595u);
		this.m_AttackPanelTimeSelectImg[1] = this.m_AttackPanel.GetChild(11).GetChild(1).GetComponent<Image>();
		this.m_AttackPanelTimeText[2] = this.m_AttackPanel.GetChild(12).GetChild(2).GetComponent<UIText>();
		this.m_AttackPanelTimeText[2].font = GUIManager.Instance.GetTTFFont();
		this.m_AttackPanelTimeBtn[2] = this.m_AttackPanel.GetChild(12).GetComponent<UIButton>();
		this.m_AttackPanelTimeBtn[2].m_BtnID2 = 311;
		this.m_AttackPanelTimeBtn[2].m_Handler = this;
		this.m_AttackPanelTimeText[1].text = DataManager.Instance.mStringTable.GetStringByID(4596u);
		this.m_AttackPanelTimeSelectImg[2] = this.m_AttackPanel.GetChild(12).GetChild(1).GetComponent<Image>();
		this.m_AttackPanelTimeText[3] = this.m_AttackPanel.GetChild(13).GetChild(2).GetComponent<UIText>();
		this.m_AttackPanelTimeText[3].font = GUIManager.Instance.GetTTFFont();
		this.m_AttackPanelTimeBtn[3] = this.m_AttackPanel.GetChild(13).GetComponent<UIButton>();
		this.m_AttackPanelTimeBtn[3].m_BtnID2 = 312;
		this.m_AttackPanelTimeBtn[3].m_Handler = this;
		this.m_AttackPanelTimeText[1].text = DataManager.Instance.mStringTable.GetStringByID(4597u);
		this.m_AttackPanelTimeSelectImg[3] = this.m_AttackPanel.GetChild(13).GetChild(1).GetComponent<Image>();
		if (GUIManager.Instance.IsArabic)
		{
			for (int m = 0; m < this.m_AttackPanelTimeSelectImg.Length; m++)
			{
				RectTransform component7 = this.m_AttackPanelTimeSelectImg[m].GetComponent<RectTransform>();
				Vector3 localScale3 = component7.localScale;
				localScale3.x = -1f;
				component7.localScale = localScale3;
				Vector2 anchoredPosition5 = component7.anchoredPosition;
				anchoredPosition5.x = 339f;
				component7.anchoredPosition = anchoredPosition5;
			}
		}
		component2 = this.m_AttackPanel.GetChild(7).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(3u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component = this.m_AttackPanel.GetChild(7).GetComponent<UIButton>();
		component.m_BtnID2 = 307;
		component.m_Handler = this;
		component = this.m_AttackPanel.GetChild(8).GetComponent<UIButton>();
		component.m_BtnID2 = 308;
		component.m_Handler = this;
		this.m_BookmarksPanel = (RectTransform)this.m_RectTransform.GetChild(6);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			this.m_BookmarksPanel.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			this.m_BookmarksPanel.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		this.BookmarkSwitch = new UIGroundInfo._BookmarkSwitch(this.m_BookmarksPanel);
		component2 = this.m_BookmarksPanel.GetChild(8).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4518u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_BookmarksPanel.GetChild(5).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_BookmarksPanel.GetChild(6).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4520u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_BookmarksPanel.GetChild(10).GetChild(3).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4521u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_BookmarksPanel.GetChild(11).GetChild(3).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4522u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_BookmarksPanel.GetChild(12).GetChild(3).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4523u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_BookmarksPanel.GetChild(13).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(3u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.inputField = this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>();
		this.inputField.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
		component2 = this.m_BookmarksPanel.GetChild(9).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_BookmarksPanel.GetChild(9).GetChild(1).GetComponent<UIText>();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component = this.m_BookmarksPanel.GetChild(9).GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = 318;
		component2.font = GUIManager.Instance.GetTTFFont();
		component = this.m_BookmarksPanel.GetChild(13).GetComponent<UIButton>();
		component.m_BtnID2 = 313;
		component.m_Handler = this;
		component = this.m_BookmarksPanel.GetChild(14).GetComponent<UIButton>();
		component.m_BtnID2 = 314;
		component.m_Handler = this;
		component2 = this.m_BookmarksPanel.GetChild(15).GetChild(3).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4624u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		helperUIButton = this.m_BookmarksPanel.gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID2 = 314;
		component = this.m_BookmarksPanel.GetChild(10).GetComponent<UIButton>();
		component.m_BtnID2 = 315;
		component.m_Handler = this;
		component = this.m_BookmarksPanel.GetChild(11).GetComponent<UIButton>();
		component.m_BtnID2 = 316;
		component.m_Handler = this;
		component = this.m_BookmarksPanel.GetChild(12).GetComponent<UIButton>();
		component.m_BtnID2 = 317;
		component.m_Handler = this;
		component = this.m_BookmarksPanel.GetChild(15).GetComponent<UIButton>();
		component.m_BtnID2 = 332;
		component.m_Handler = this;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component8;
			Vector3 localScale4;
			Vector2 anchoredPosition6;
			for (int n = 0; n < 3; n++)
			{
				component8 = this.m_BookmarksPanel.GetChild(10 + n).GetChild(1).GetComponent<RectTransform>();
				localScale4 = component8.localScale;
				localScale4.x = -1f;
				component8.localScale = localScale4;
				anchoredPosition6 = component8.anchoredPosition;
				anchoredPosition6.x = 339f;
				component8.anchoredPosition = anchoredPosition6;
			}
			component8 = this.m_BookmarksPanel.GetChild(15).GetChild(1).GetComponent<RectTransform>();
			localScale4 = component8.localScale;
			localScale4.x = -1f;
			component8.localScale = localScale4;
			anchoredPosition6 = component8.anchoredPosition;
			anchoredPosition6.x = 339f;
			component8.anchoredPosition = anchoredPosition6;
		}
		this.m_PvePanel = (RectTransform)this.m_RectTransform.GetChild(7);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			this.m_PvePanel.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			this.m_PvePanel.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		child = this.m_PvePanel.GetChild(10);
		component = child.GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = 319;
		child = child.GetChild(1);
		component2 = child.GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4533u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_ButtonRect5 = (RectTransform)this.m_ButtonPanel.GetChild(4);
		child = this.m_PvePanel.GetChild(11);
		component = child.GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = 320;
		child = child.GetChild(1);
		component2 = child.GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(4534u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_PveHeroBtn = this.m_PvePanel.GetChild(4).GetComponent<UIHIBtn>();
		GUIManager.Instance.InitianHeroItemImg(this.m_PveHeroBtn.transform, eHeroOrItem.Hero, 11, 1, 0, 0, false, false, true, false);
		this.m_PveTitle = this.m_PvePanel.GetChild(5).GetComponent<UIText>();
		this.m_PveTitle.font = GUIManager.Instance.GetTTFFont();
		this.m_PveHeroName = this.m_PvePanel.GetChild(6).GetComponent<UIText>();
		this.m_PveHeroName.font = GUIManager.Instance.GetTTFFont();
		this.m_PvePowerIcon = this.m_PvePanel.GetChild(7).GetComponent<Image>();
		this.m_PvePowerText = this.m_PvePanel.GetChild(8).GetComponent<UIText>();
		this.m_PvePowerText.font = GUIManager.Instance.GetTTFFont();
		component2 = this.m_PvePanel.GetChild(9).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(791u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component = this.m_PvePanel.GetChild(12).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = 321;
		helperUIButton = this.m_PvePanel.gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID2 = 321;
		this.m_RewardPanel = (RectTransform)this.m_RectTransform.GetChild(8);
		this.m_RewardBtn = this.m_RewardPanel.GetChild(7).GetComponent<UIButton>();
		this.m_RewardBtn.m_Handler = this;
		this.m_RewardBtn.m_BtnID2 = 322;
		this.m_RewardText = this.m_RewardPanel.GetChild(6).GetComponent<UIText>();
		this.m_RewardText.font = GUIManager.Instance.GetTTFFont();
		component2 = this.m_RewardPanel.GetChild(4).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(861u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_RewardPanel.GetChild(5).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(862u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = this.m_RewardPanel.GetChild(7).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(863u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_TitlePanel = (RectTransform)this.m_RectTransform.GetChild(10);
		component = this.m_TitlePanel.GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = 327;
		component2 = this.m_TitlePanel.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9348u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_NpcCastleIcon = this.m_NpcCastlePanel.GetChild(0).gameObject;
		this.m_NpcCastleIconBone = this.m_NpcCastlePanel.GetChild(0).GetChild(0);
		this.m_NpcCastleFrame = this.m_NpcCastlePanel.GetChild(0).GetChild(1).GetComponent<Image>();
		this.m_NpcCastleFrame.sprite = GUIManager.Instance.LoadFrameSprite(EFrameSprite.Hero, 11);
		this.m_NpcCastleFrame.material = GUIManager.Instance.GetFrameMaterial();
		this.m_NpcCastleIDText = this.m_NpcCastlePanel.GetChild(1).GetComponent<UIText>();
		this.m_NpcCastleIDText.font = GUIManager.Instance.GetTTFFont();
		this.m_NpcCastleStrengthText = this.m_NpcCastlePanel.GetChild(2).GetComponent<UIText>();
		this.m_NpcCastleStrengthText.font = GUIManager.Instance.GetTTFFont();
		this.m_NpcCastleTimeText = this.m_NpcCastlePanel.GetChild(3).GetComponent<UIText>();
		this.m_NpcCastleTimeText.font = GUIManager.Instance.GetTTFFont();
		this.m_NpcCastleInfoText = this.m_NpcCastlePanel.GetChild(4).GetComponent<UIText>();
		this.m_NpcCastleInfoText.font = GUIManager.Instance.GetTTFFont();
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component9 = this.m_NpcCastlePanel.GetChild(2).GetChild(0).GetComponent<RectTransform>();
			Vector2 anchoredPosition7 = component9.anchoredPosition;
			anchoredPosition7.x = 130f;
			component9.anchoredPosition = anchoredPosition7;
			component9 = this.m_NpcCastlePanel.GetChild(3).GetChild(0).GetComponent<RectTransform>();
			anchoredPosition7.x = 130f;
			component9.anchoredPosition = anchoredPosition7;
			Vector3 localScale5 = this.m_NpcCastlePanel.GetChild(5).GetComponent<RectTransform>().localScale;
			localScale5.x *= -1f;
			this.m_NpcCastlePanel.GetChild(5).GetComponent<RectTransform>().localScale = localScale5;
		}
		this.m_NpcCastleInfoBtn = this.m_NpcCastlePanel.GetChild(5).GetComponent<UIButton>();
		this.m_NpcCastleInfoBtn.m_Handler = this;
		this.m_NpcCastleInfoBtn.m_BtnID2 = 328;
		uibuttonHint = this.m_NpcCastleStrengthText.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 9;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint = this.m_NpcCastleStrengthText.transform.GetChild(0).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.Parm1 = 9;
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint = this.m_NpcCastleTimeText.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.Parm1 = 10;
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint = this.m_NpcCastleTimeText.transform.GetChild(0).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.Parm1 = 10;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_DownUpHandler = this;
	}

	// Token: 0x06001209 RID: 4617 RVA: 0x001F7220 File Offset: 0x001F5420
	public void HideNormalPanel()
	{
		this.m_PanelGameObject.SetActive(false);
		this.m_TeamPanelGameObject.SetActive(false);
		this.m_GroundPanel.gameObject.SetActive(false);
		this.m_ResourcePanel.gameObject.SetActive(false);
		this.m_CampPanel.gameObject.SetActive(false);
		this.m_WondersPanel.gameObject.SetActive(false);
		this.m_RewardPanel.gameObject.SetActive(false);
		this.m_NpcCastlePanel.gameObject.SetActive(false);
	}

	// Token: 0x0600120A RID: 4618 RVA: 0x001F72AC File Offset: 0x001F54AC
	public string GetLocation(int MapPointID, bool bHaveArbText = false, bool bWonder = false)
	{
		Vector2 vector;
		if (bWonder)
		{
			MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[MapPointID];
			vector = DataManager.MapDataController.GetYolkPos(mapPoint.tableID, DataManager.MapDataController.FocusKingdomID);
		}
		else
		{
			vector = GameConstants.getTileMapPosbySpriteID(MapPointID);
		}
		this.sb.Length = 0;
		if (GUIManager.Instance.IsArabic)
		{
			if (bHaveArbText)
			{
				this.sb.AppendFormat("{1}{0} {3}{2} {5}{4}", new object[]
				{
					DataManager.Instance.mStringTable.GetStringByID(4504u),
					DataManager.MapDataController.FocusKingdomID,
					DataManager.Instance.mStringTable.GetStringByID(4505u),
					(int)vector.x,
					DataManager.Instance.mStringTable.GetStringByID(4506u),
					(int)vector.y
				});
			}
			else
			{
				this.sb.AppendFormat("{5}{4} {3}{2} {1}{0}", new object[]
				{
					DataManager.Instance.mStringTable.GetStringByID(4504u),
					DataManager.MapDataController.FocusKingdomID,
					DataManager.Instance.mStringTable.GetStringByID(4505u),
					(int)vector.x,
					DataManager.Instance.mStringTable.GetStringByID(4506u),
					(int)vector.y
				});
			}
		}
		else
		{
			this.sb.AppendFormat("{0}{1} {2}{3} {4}{5}", new object[]
			{
				DataManager.Instance.mStringTable.GetStringByID(4504u),
				DataManager.MapDataController.FocusKingdomID,
				DataManager.Instance.mStringTable.GetStringByID(4505u),
				(int)vector.x,
				DataManager.Instance.mStringTable.GetStringByID(4506u),
				(int)vector.y
			});
		}
		return this.sb.ToString();
	}

	// Token: 0x0600120B RID: 4619 RVA: 0x001F74E0 File Offset: 0x001F56E0
	public string GetYolkLocation(ushort YolkID, ushort KingdomID, bool bHaveArbText = false)
	{
		Vector2 yolkPos = DataManager.MapDataController.GetYolkPos(YolkID, KingdomID);
		this.sb.Length = 0;
		if (GUIManager.Instance.IsArabic)
		{
			if (bHaveArbText)
			{
				this.sb.AppendFormat("{1}{0} {3}{2} {5}{4}", new object[]
				{
					DataManager.Instance.mStringTable.GetStringByID(4504u),
					DataManager.MapDataController.FocusKingdomID,
					DataManager.Instance.mStringTable.GetStringByID(4505u),
					(int)yolkPos.x,
					DataManager.Instance.mStringTable.GetStringByID(4506u),
					(int)yolkPos.y
				});
			}
			else
			{
				this.sb.AppendFormat("{5}{4} {3}{2} {1}{0}", new object[]
				{
					DataManager.Instance.mStringTable.GetStringByID(4504u),
					DataManager.MapDataController.FocusKingdomID,
					DataManager.Instance.mStringTable.GetStringByID(4505u),
					(int)yolkPos.x,
					DataManager.Instance.mStringTable.GetStringByID(4506u),
					(int)yolkPos.y
				});
			}
		}
		else
		{
			this.sb.AppendFormat("{0}{1} {2}{3} {4}{5}", new object[]
			{
				DataManager.Instance.mStringTable.GetStringByID(4504u),
				DataManager.MapDataController.FocusKingdomID,
				DataManager.Instance.mStringTable.GetStringByID(4505u),
				(int)yolkPos.x,
				DataManager.Instance.mStringTable.GetStringByID(4506u),
				(int)yolkPos.y
			});
		}
		return this.sb.ToString();
	}

	// Token: 0x0600120C RID: 4620 RVA: 0x001F76DC File Offset: 0x001F58DC
	public void OpenSearchPanel(bool IsOpen, bool IsWorldMap = false)
	{
		if (IsOpen)
		{
			this.HideNormalPanel();
			this.m_SearchPanel.GetChild(15).gameObject.SetActive(false);
			if (IsWorldMap)
			{
				if (this.m_SearchLocationK == 0)
				{
					this.m_SearchLocationK = DataManager.MapDataController.OtherKingdomData.kingdomID;
					this.m_Str[20].ClearString();
					this.m_Str[20].IntToFormat((long)this.m_SearchLocationK, 1, false);
					this.m_Str[20].AppendFormat("{0}");
					this.m_SearchPanel.GetChild(8).GetChild(0).GetComponent<UIText>().text = this.m_Str[20].ToString();
				}
				RectTransform component = this.m_SearchPanel.GetChild(0).GetComponent<RectTransform>();
				Vector2 sizeDelta = component.sizeDelta;
				sizeDelta.y = 390f;
				component.sizeDelta = sizeDelta;
				Vector2 anchoredPosition = component.anchoredPosition;
				anchoredPosition.y = 16f;
				component.anchoredPosition = anchoredPosition;
				component = this.m_SearchPanel.GetChild(6).GetComponent<RectTransform>();
				anchoredPosition = component.anchoredPosition;
				anchoredPosition.y = 12f;
				component.anchoredPosition = anchoredPosition;
				this.m_SearchPanel.GetChild(16).gameObject.SetActive(true);
				this.m_SearchPanel.GetChild(9).gameObject.SetActive(false);
				this.m_SearchPanel.GetChild(10).gameObject.SetActive(false);
				this.m_SearchPanel.GetChild(13).gameObject.SetActive(false);
				this.m_SearchPanel.GetChild(14).gameObject.SetActive(false);
				RectTransform rectTransform = (RectTransform)this.m_SearchPanel.GetChild(8);
				rectTransform.anchoredPosition = new Vector2(12f, 84.5f);
				rectTransform = (RectTransform)this.m_SearchPanel.GetChild(12);
				rectTransform.anchoredPosition = new Vector2(-44.5f, 84.5f);
				UIText component2 = this.m_SearchPanel.GetChild(4).GetChild(0).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(792u);
			}
			else
			{
				int focusKingdomID = (int)DataManager.MapDataController.FocusKingdomID;
				this.m_SearchPanel.GetChild(9).gameObject.SetActive(true);
				this.m_SearchPanel.GetChild(10).gameObject.SetActive(true);
				this.m_SearchPanel.GetChild(13).gameObject.SetActive(true);
				this.m_SearchPanel.GetChild(14).gameObject.SetActive(true);
				RectTransform rectTransform = (RectTransform)this.m_SearchPanel.GetChild(8);
				rectTransform.anchoredPosition = new Vector2(-105f, 84.5f);
				rectTransform = (RectTransform)this.m_SearchPanel.GetChild(12);
				rectTransform.anchoredPosition = new Vector2(-162.5f, 84.5f);
				UIText component3 = this.m_SearchPanel.GetChild(4).GetChild(0).GetComponent<UIText>();
				component3.text = DataManager.Instance.mStringTable.GetStringByID(4502u);
				this.m_Str[20].ClearString();
				this.m_Str[20].IntToFormat((long)focusKingdomID, 1, false);
				this.m_Str[20].AppendFormat("{0}");
				this.m_SearchPanel.GetChild(8).GetChild(0).GetComponent<UIText>().text = this.m_Str[20].ToString();
				RectTransform component = this.m_SearchPanel.GetChild(0).GetComponent<RectTransform>();
				Vector2 sizeDelta = component.sizeDelta;
				sizeDelta.y = 297f;
				component.sizeDelta = sizeDelta;
				Vector2 anchoredPosition = component.anchoredPosition;
				anchoredPosition.y = 62.5f;
				component.anchoredPosition = anchoredPosition;
				component = this.m_SearchPanel.GetChild(6).GetComponent<RectTransform>();
				anchoredPosition = component.anchoredPosition;
				anchoredPosition.y = -15f;
				component.anchoredPosition = anchoredPosition;
				this.m_SearchPanel.GetChild(16).gameObject.SetActive(false);
				if (this.m_SearchLocationX == 0)
				{
					this.m_SearchLocationX = this.m_Door.m_CapitalLocationX;
					this.m_SearchLocationY = this.m_Door.m_CapitalLocationY;
					this.m_Str[21].ClearString();
					this.m_Str[21].IntToFormat((long)this.m_SearchLocationX, 1, false);
					this.m_Str[21].AppendFormat("{0}");
					this.m_SearchPanel.GetChild(9).GetChild(0).GetComponent<UIText>().text = string.Empty;
					this.m_SearchPanel.GetChild(9).GetChild(0).GetComponent<UIText>().text = this.m_Str[21].ToString();
					this.m_Str[22].ClearString();
					this.m_Str[22].IntToFormat((long)this.m_SearchLocationY, 1, false);
					this.m_Str[22].AppendFormat("{0}");
					this.m_SearchPanel.GetChild(10).GetChild(0).GetComponent<UIText>().text = string.Empty;
					this.m_SearchPanel.GetChild(10).GetChild(0).GetComponent<UIText>().text = this.m_Str[22].ToString();
				}
			}
		}
		this.m_SearchPanel.gameObject.SetActive(IsOpen);
		this.bGroundInfoOpen = IsOpen;
	}

	// Token: 0x0600120D RID: 4621 RVA: 0x001F7C3C File Offset: 0x001F5E3C
	public void OpenReinforcePanel(bool IsOpen, bool bShowBackground = false, bool bShowLoc = true)
	{
		if (IsOpen)
		{
			UIText component = this.m_ReinforcePanel.GetChild(4).GetChild(0).GetComponent<UIText>();
			if (bShowLoc)
			{
				component.text = this.GetLocation(this.m_MapPointID, false, false);
			}
			else
			{
				component.text = string.Empty;
			}
			this.SetReinforceValue(DataManager.Instance.m_CurrTroopAmount, DataManager.Instance.m_InForceCapacity);
			this.HideNormalPanel();
			if (bShowBackground)
			{
				this.m_ReinforcePanel.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.7f);
			}
			else
			{
				this.m_ReinforcePanel.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.7f);
			}
		}
		if (bShowLoc)
		{
			this.bOpenUIExpedition_FromList = false;
		}
		else
		{
			this.bOpenUIExpedition_FromList = true;
		}
		this.m_ReinforcePanel.gameObject.SetActive(IsOpen);
		this.bGroundInfoOpen = IsOpen;
	}

	// Token: 0x0600120E RID: 4622 RVA: 0x001F7D40 File Offset: 0x001F5F40
	public void SetReinforceValue(uint value, uint max)
	{
		this.sb.Length = 0;
		float num = 0f;
		if (max > 0u)
		{
			num = value / max;
		}
		this.m_Str[27].ClearString();
		RectTransform component = this.m_ReinforcePanel.GetChild(8).GetChild(0).GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(253f * num, component.sizeDelta.y);
		this.m_Str[27].IntToFormat((long)((ulong)value), 1, true);
		this.m_Str[27].IntToFormat((long)((ulong)max), 1, true);
		if (GUIManager.Instance.IsArabic)
		{
			this.m_Str[27].AppendFormat("{1} / {0}");
		}
		else
		{
			this.m_Str[27].AppendFormat("{0} / {1}");
		}
		UIText component2 = this.m_ReinforcePanel.GetChild(8).GetChild(3).GetComponent<UIText>();
		component2.text = this.m_Str[27].ToString();
	}

	// Token: 0x0600120F RID: 4623 RVA: 0x001F7E40 File Offset: 0x001F6040
	public void OpenDetectPanel(bool IsOpen, byte lv = 0, bool bWonder = false)
	{
		if (IsOpen)
		{
			if (this.ScoutCheckBox(eScoutCheckBox.PreScout))
			{
				UIText component = this.m_DetectPanel.GetChild(4).GetChild(0).GetComponent<UIText>();
				component.text = this.GetLocation(this.m_MapPointID, false, bWonder);
				this.SetDetectPanel(lv, bWonder);
				this.HideNormalPanel();
				this.m_DetectPanel.gameObject.SetActive(IsOpen);
			}
			else
			{
				this.Close();
			}
		}
		else
		{
			this.m_DetectPanel.gameObject.SetActive(false);
		}
		this.bGroundInfoOpen = IsOpen;
	}

	// Token: 0x06001210 RID: 4624 RVA: 0x001F7ED4 File Offset: 0x001F60D4
	public void SetDetectPanel(byte lv = 0, bool bWonder = false)
	{
		if (this.m_MapPointID >= DataManager.MapDataController.LayoutMapInfo.Length)
		{
			return;
		}
		if (bWonder)
		{
			this.m_DetectPanelText.text = DataManager.Instance.mStringTable.GetStringByID(7273u);
		}
		else
		{
			this.m_DetectPanelText.text = DataManager.Instance.mStringTable.GetStringByID(4536u);
		}
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
		Vector2 a = new Vector2((float)this.m_Door.m_CapitalLocationX, (float)this.m_Door.m_CapitalLocationY);
		Vector2 b;
		if (bWonder)
		{
			MapPoint mapPoint2 = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
			b = DataManager.MapDataController.GetYolkPos(mapPoint2.tableID, DataManager.MapDataController.FocusKingdomID);
		}
		else
		{
			b = GameConstants.getTileMapPosbySpriteID(this.m_MapPointID);
		}
		float num = Mathf.Ceil(Vector2.Distance(a, b));
		float num2 = 0.6f;
		int num3 = (int)Mathf.Ceil(num * num2);
		this.sb.Length = 0;
		int num4 = num3 / 60;
		int num5 = num3 % 60;
		this.m_Str[18].ClearString();
		UIText component = this.m_DetectPanel.GetChild(8).GetChild(0).GetComponent<UIText>();
		this.m_Str[18].ClearString();
		this.m_Str[18].IntToFormat((long)num4, 2, false);
		this.m_Str[18].IntToFormat((long)num5, 2, false);
		this.m_Str[18].AppendFormat("{0}:{1}");
		component.text = this.m_Str[18].ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		this.m_Str[19].ClearString();
		this.m_ScoutTagLv = 0;
		if ((int)mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
		{
			this.m_ScoutTagLv = DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].level;
		}
		if (bWonder)
		{
			this.m_Str[19].IntToFormat(10000L, 1, false);
		}
		else if (lv == 0)
		{
			this.m_Str[19].IntToFormat((long)this.GetScoutMoney(this.m_ScoutTagLv, POINT_KIND.PK_CITY), 1, true);
		}
		else
		{
			this.m_ScoutTagLv = lv;
			this.m_Str[19].IntToFormat((long)this.GetScoutMoney(lv, POINT_KIND.PK_CITY), 1, true);
		}
		this.m_Str[19].AppendFormat("{0}");
		component = this.m_DetectPanel.GetChild(9).GetChild(1).GetComponent<UIText>();
		component.text = this.m_Str[19].ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.m_ReinforcePanel.GetChild(4).GetChild(0).GetComponent<UIText>();
		component.text = this.GetLocation(this.m_MapPointID, false, false);
	}

	// Token: 0x06001211 RID: 4625 RVA: 0x001F81D8 File Offset: 0x001F63D8
	public void OpenAttackPanel(bool IsOpen, bool bHideArmy = false)
	{
		if (IsOpen)
		{
			UIText component = this.m_AttackPanel.GetChild(4).GetChild(0).GetComponent<UIText>();
			if (DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID].pointKind == 11 && DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID].tableID < 40)
			{
				component.text = this.GetLocation(this.m_MapPointID, false, true);
			}
			else
			{
				component.text = this.GetLocation(this.m_MapPointID, false, false);
			}
			this.SetAttackPanel(bHideArmy, byte.MaxValue);
			this.HideNormalPanel();
		}
		this.m_AttackPanel.gameObject.SetActive(IsOpen);
		this.bGroundInfoOpen = IsOpen;
	}

	// Token: 0x06001212 RID: 4626 RVA: 0x001F829C File Offset: 0x001F649C
	public void SetAttackPanel(bool bHideArmy = false, byte index = 255)
	{
		UISpritesArray component = this.m_AttackPanel.GetComponent<UISpritesArray>();
		byte b;
		if (bHideArmy)
		{
			this.bHideSelectMod = true;
			byte[] array = new byte[]
			{
				1,
				4,
				8,
				12
			};
			this.m_AttackPanelIcon.sprite = component.GetSprite(3);
			this.m_AttackPanelIcon.SetNativeSize();
			this.m_AttackPanelIcon.rectTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
			this.m_AttackPanelPosTf.gameObject.SetActive(false);
			this.m_AttackPanelTitleText.text = DataManager.Instance.mStringTable.GetStringByID(9046u);
			this.m_AttackPanelInfoText.text = DataManager.Instance.mStringTable.GetStringByID(8586u);
			this.m_AttackPanelInfoText.rectTransform.anchoredPosition = new Vector2(0f, 100f);
			for (int i = 0; i < this.m_AttackPanelTimeText.Length; i++)
			{
				int num = 42 + i;
				if (num < this.m_Str.Length && i < array.Length)
				{
					this.m_Str[num].ClearString();
					this.m_Str[num].IntToFormat((long)array[i], 1, false);
					this.m_Str[num].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8588u));
					this.m_AttackPanelTimeText[i].text = this.m_Str[num].ToString();
					this.m_AttackPanelTimeText[i].SetAllDirty();
					this.m_AttackPanelTimeText[i].cachedTextGenerator.Invalidate();
				}
			}
			if (index != 255)
			{
				this.m_HideSelect = index;
			}
			b = this.m_HideSelect;
		}
		else
		{
			this.bHideSelectMod = false;
			this.m_AttackPanelIcon.sprite = component.GetSprite(2);
			this.m_AttackPanelIcon.SetNativeSize();
			this.m_AttackPanelIcon.rectTransform.localScale = new Vector3(1f, 1f, 1f);
			this.m_AttackPanelPosTf.gameObject.SetActive(true);
			this.m_AttackPanelInfoText.rectTransform.anchoredPosition = new Vector2(0f, 82.7f);
			this.m_AttackPanelTitleText.text = DataManager.Instance.mStringTable.GetStringByID(4554u);
			this.m_AttackPanelInfoText.text = DataManager.Instance.mStringTable.GetStringByID(4593u);
			for (int j = 0; j < this.m_AttackPanelTimeText.Length; j++)
			{
				this.m_AttackPanelTimeText[j].text = DataManager.Instance.mStringTable.GetStringByID((uint)(4594 + j));
			}
			GameConstants.MapIDToPointCode(this.m_MapPointID, out DataManager.Instance.RallyDesPoint.zoneID, out DataManager.Instance.RallyDesPoint.pointID);
			if (index != 255)
			{
				this.m_AttackSelect = index;
			}
			b = this.m_AttackSelect;
		}
		for (int k = 0; k < 4; k++)
		{
			if ((int)b == k)
			{
				this.m_AttackPanelTimeBtn[k].image.sprite = component.GetSprite(1);
				this.m_AttackPanelTimeSelectImg[k].gameObject.SetActive(true);
			}
			else
			{
				this.m_AttackPanelTimeBtn[k].image.sprite = component.GetSprite(0);
				this.m_AttackPanelTimeSelectImg[k].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001213 RID: 4627 RVA: 0x001F8618 File Offset: 0x001F6818
	public void OpenMonsterBookmarksPanel(bool IsOpen, int mapPoint)
	{
		this.m_ModifyBookMarkID = 0;
		this.m_MonsterMapPoint = mapPoint;
		MapPoint mapPoint2 = DataManager.MapDataController.LayoutMapInfo[this.m_MonsterMapPoint];
		if (mapPoint2.pointKind != 10)
		{
			return;
		}
		NPCPoint npcpoint = DataManager.MapDataController.NPCPointTable[(int)mapPoint2.tableID];
		if (IsOpen)
		{
			UIText uitext = this.m_BookmarksPanel.GetChild(8).GetComponent<UIText>();
			uitext.font = GUIManager.Instance.GetTTFFont();
			uitext.text = DataManager.Instance.mStringTable.GetStringByID(4518u);
			uitext = this.m_BookmarksPanel.GetChild(5).GetChild(0).GetComponent<UIText>();
			uitext.text = this.GetLocation(this.m_MonsterMapPoint, false, false);
			if (npcpoint.NPCAllianceTag.Length > 0 && npcpoint.NPCAllianceTag[0] != '0')
			{
				this.BookMarkNameStr.ClearString();
				this.BookMarkNameStr.StringToFormat(npcpoint.NPCAllianceTag);
				this.BookMarkNameStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)DataManager.MapDataController.MapMonsterTable.GetRecordByKey(npcpoint.NPCNum).NameID));
				if (GUIManager.Instance.IsArabic)
				{
					this.BookMarkNameStr.AppendFormat("{1}[{0}]");
				}
				else
				{
					this.BookMarkNameStr.AppendFormat("[{0}]{1}");
				}
				this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = this.BookMarkNameStr.ToString();
				uitext = this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().textComponent;
				uitext.SetAllDirty();
				uitext.cachedTextGeneratorForLayout.Invalidate();
			}
			else
			{
				this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = DataManager.Instance.mStringTable.GetStringByID((uint)DataManager.MapDataController.MapMonsterTable.GetRecordByKey(npcpoint.NPCNum).NameID);
			}
			if ((DataManager.Instance.RoleAlliance.Id == 0u || DataManager.Instance.RoleAlliance.Rank < AllianceRank.RANK4) && this.m_BookmarkSelect == 3)
			{
				this.m_BookmarkSelect = 0;
			}
			this.HideNormalPanel();
			this.SetBookmarksPanel();
		}
		this.BookmarkSwitch.Switch(UIGroundInfo._BookmarkSwitch.eType.AddBookmark);
		this.m_BookmarksPanel.gameObject.SetActive(true);
		this.bGroundInfoOpen = IsOpen;
	}

	// Token: 0x06001214 RID: 4628 RVA: 0x001F889C File Offset: 0x001F6A9C
	public void OpenBookmarksPanel(bool IsOpen)
	{
		this.m_ModifyBookMarkID = 0;
		if (IsOpen)
		{
			UIText component = this.m_BookmarksPanel.GetChild(8).GetComponent<UIText>();
			component.font = GUIManager.Instance.GetTTFFont();
			component.text = DataManager.Instance.mStringTable.GetStringByID(4518u);
			this.UpdateBookmarkTitlePos();
			component = this.m_BookmarksPanel.GetChild(5).GetChild(0).GetComponent<UIText>();
			MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
			bool bWonder = mapPoint.pointKind == 11;
			component.text = this.GetLocation(this.m_MapPointID, false, bWonder);
			int num = DataManager.MapDataController.ResourcesPointTable.Length;
			if ((int)mapPoint.tableID >= num)
			{
				return;
			}
			ushort level = (ushort)DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].level;
			switch (DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)this.m_MapPointID))
			{
			case POINT_KIND.PK_NONE:
				if (this.m_MapPointID >= 0 && this.m_MapPointID < this.m_Door.TileMapController.TileMapInfo.Length)
				{
					int num2 = (int)this.m_Door.TileMapController.TileMapInfo[this.m_MapPointID];
				}
				this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = this.GetPKNoneGroundTitle(this.m_MapPointID);
				break;
			case POINT_KIND.PK_FOOD:
				this.sb.Length = 0;
				this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4566u), level);
				this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4525u);
				this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = this.sb.ToString();
				break;
			case POINT_KIND.PK_STONE:
				this.sb.Length = 0;
				this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4568u), level);
				this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4526u);
				this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = this.sb.ToString();
				break;
			case POINT_KIND.PK_IRON:
				this.sb.Length = 0;
				this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4567u), level);
				this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4527u);
				this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = this.sb.ToString();
				break;
			case POINT_KIND.PK_WOOD:
				this.sb.Length = 0;
				this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4570u), level);
				this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4524u);
				this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = this.sb.ToString();
				break;
			case POINT_KIND.PK_GOLD:
				this.sb.Length = 0;
				this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4569u), level);
				this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4528u);
				this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = this.sb.ToString();
				break;
			case POINT_KIND.PK_CRYSTAL:
				this.sb.Length = 0;
				this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4571u), level);
				this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4529u);
				this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = this.sb.ToString();
				break;
			case POINT_KIND.PK_CITY:
				if (this.IsNpcCastleType(POINT_KIND.PK_CITY, mapPoint.tableID))
				{
					this.m_Str[14].ClearString();
					StringManager.Instance.IntToFormat((long)DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].level, 1, false);
					this.m_Str[14].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021u));
					this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = "{0}";
					this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = this.m_Str[14].ToString();
				}
				else if ((int)mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
				{
					this.m_Str[14].ClearString();
					if (DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag != null && DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag.Length > 0)
					{
						StringManager.Instance.StringToFormat(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag);
						StringManager.Instance.StringToFormat(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName);
						this.m_Str[14].AppendFormat("[{0}]{1}");
					}
					else
					{
						StringManager.Instance.StringToFormat(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName);
						this.m_Str[14].AppendFormat("{0}");
					}
					this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = "{0}";
					this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = this.m_Str[14].ToString();
				}
				break;
			case POINT_KIND.PK_CAMP:
				this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = DataManager.Instance.mStringTable.GetStringByID(4540u);
				break;
			case POINT_KIND.PK_YOLK:
				if ((int)mapPoint.tableID < DataManager.MapDataController.YolkPointTable.Length)
				{
					MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int)mapPoint.tableID];
					this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = DataManager.MapDataController.GetYolkName((ushort)mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID).ToString();
				}
				break;
			}
			this.HideNormalPanel();
			this.SetBookmarksPanel();
		}
		if (IsOpen)
		{
			this.BookmarkSwitch.Switch(UIGroundInfo._BookmarkSwitch.eType.AddBookmark);
		}
		this.m_BookmarksPanel.gameObject.SetActive(IsOpen);
		this.bGroundInfoOpen = IsOpen;
	}

	// Token: 0x06001215 RID: 4629 RVA: 0x001F8FF4 File Offset: 0x001F71F4
	public void UpdateBookmarkTitlePos()
	{
		UIText component = this.m_BookmarksPanel.GetChild(8).GetComponent<UIText>();
		RectTransform rectTransform = this.m_BookmarksPanel.GetChild(7) as RectTransform;
		float num = component.preferredWidth;
		if (num > 290f)
		{
			component.resizeTextForBestFit = true;
			component.resizeTextMaxSize = 21;
			component.resizeTextMinSize = 10;
			num = 290f;
		}
		else
		{
			component.resizeTextForBestFit = false;
		}
		Vector2 vector = component.rectTransform.sizeDelta;
		vector.x = num;
		component.rectTransform.sizeDelta = vector;
		float num2 = (num + 53f + 10f) / 2f;
		vector = rectTransform.anchoredPosition;
		vector.x = -num2;
		rectTransform.anchoredPosition = vector;
		vector = component.rectTransform.anchoredPosition;
		vector.x = rectTransform.anchoredPosition.x + 26.5f + 10f + num / 2f;
		component.rectTransform.anchoredPosition = vector;
	}

	// Token: 0x06001216 RID: 4630 RVA: 0x001F90F8 File Offset: 0x001F72F8
	public void OpenPvePanel(bool IsOpen, ushort CorpsStagekey = 1)
	{
		ushort hiid = 0;
		CorpsStage recordByKey = DataManager.StageDataController.CorpsStageTable.GetRecordByKey(CorpsStagekey);
		if (recordByKey.Heros != null)
		{
			hiid = recordByKey.Heros[0].HeroID;
		}
		if (IsOpen)
		{
			this.m_PveTitle.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.LordTile);
			this.m_PveHeroName.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.LordName);
			this.m_Str[16].ClearString();
			this.m_Str[16].IntToFormat((long)((ulong)DataManager.StageDataController.CorpsStagetotalStrength), 1, false);
			this.m_Str[16].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4541u));
			this.m_PvePowerText.text = this.m_Str[16].ToString();
			this.m_PvePowerText.SetAllDirty();
			this.m_PvePowerText.cachedTextGenerator.Invalidate();
			this.m_PvePowerText.cachedTextGeneratorForLayout.Invalidate();
			this.m_PvePowerText.rectTransform.sizeDelta = new Vector2(this.m_PvePowerText.preferredWidth, this.m_PvePowerText.rectTransform.sizeDelta.y);
			this.m_PvePowerText.rectTransform.anchoredPosition = new Vector2(13f, this.m_PvePowerText.rectTransform.anchoredPosition.y);
			this.m_PvePowerIcon.rectTransform.anchoredPosition = new Vector2(-(this.m_PvePowerText.preferredWidth / 2f) - 3f, this.m_PvePowerIcon.rectTransform.anchoredPosition.y);
			GUIManager.Instance.ChangeHeroItemImg(this.m_PveHeroBtn.transform, eHeroOrItem.Hero, hiid, 11, 0, 0);
			NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT, this, false);
		}
		this.m_PvePanel.gameObject.SetActive(IsOpen);
		this.bGroundInfoOpen = IsOpen;
	}

	// Token: 0x06001217 RID: 4631 RVA: 0x001F92FC File Offset: 0x001F74FC
	public void OpenRewardPanel(bool IsOpen)
	{
		this.m_RewardPanel.gameObject.SetActive(IsOpen);
	}

	// Token: 0x06001218 RID: 4632 RVA: 0x001F9310 File Offset: 0x001F7510
	public void OpenTitlePanel(bool IsOpen)
	{
		this.m_TitlePanel.gameObject.SetActive(IsOpen);
	}

	// Token: 0x06001219 RID: 4633 RVA: 0x001F9324 File Offset: 0x001F7524
	public void ModifyBookmarksPanel(ushort bookMarkDataIdx, UIGroundInfo._BookmarkSwitch.eType bookType)
	{
		this.m_ModifyBookMarkID = bookMarkDataIdx;
		bookMarkDataIdx -= 1;
		if (bookType == UIGroundInfo._BookmarkSwitch.eType.ModifyBookmark && (int)bookMarkDataIdx < DataManager.Instance.RoleBookMark.AllData.Length)
		{
			UIText component = this.m_BookmarksPanel.GetChild(8).GetComponent<UIText>();
			component.font = GUIManager.Instance.GetTTFFont();
			component.text = DataManager.Instance.mStringTable.GetStringByID(788u);
			int mapID = DataManager.Instance.RoleBookMark.AllData[(int)bookMarkDataIdx].MapID;
			component = this.m_BookmarksPanel.GetChild(5).GetChild(0).GetComponent<UIText>();
			component.text = this.GetLocation(mapID, false, false);
			this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = StringManager.InputTemp;
			this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = DataManager.Instance.RoleBookMark.AllData[(int)bookMarkDataIdx].Name.ToString();
			this.m_BookmarkSelect = DataManager.Instance.RoleBookMark.AllData[(int)bookMarkDataIdx].Type;
			this.SetBookmarksPanel();
		}
		else if (bookType == UIGroundInfo._BookmarkSwitch.eType.ModifyAlliancemark && (int)bookMarkDataIdx < DataManager.Instance.RoleBookMark.AllAllianceData.Length)
		{
			UIText component2 = this.m_BookmarksPanel.GetChild(8).GetComponent<UIText>();
			component2.font = GUIManager.Instance.GetTTFFont();
			component2.text = DataManager.Instance.mStringTable.GetStringByID(12635u);
			int mapID = DataManager.Instance.RoleBookMark.AllAllianceData[(int)bookMarkDataIdx].MapID;
			component2 = this.m_BookmarksPanel.GetChild(5).GetChild(0).GetComponent<UIText>();
			component2.text = this.GetLocation(mapID, false, false);
			this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = StringManager.InputTemp;
			this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text = DataManager.Instance.RoleBookMark.AllAllianceData[(int)bookMarkDataIdx].Name.ToString();
			this.m_BookmarkSelect = DataManager.Instance.RoleBookMark.AllAllianceData[(int)bookMarkDataIdx].Type;
			this.SetBookmarksPanel();
		}
		this.UpdateBookmarkTitlePos();
		this.BookmarkSwitch.Switch(bookType);
		this.m_BookmarksPanel.gameObject.SetActive(true);
	}

	// Token: 0x0600121A RID: 4634 RVA: 0x001F9590 File Offset: 0x001F7790
	public bool ScoutCheckBox(eScoutCheckBox eCheck)
	{
		GUIManager instance = GUIManager.Instance;
		StringTable mStringTable = DataManager.Instance.mStringTable;
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
		ResourcesPoint resourcesPoint = DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID];
		PlayerPoint playerPoint = DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID];
		byte capitalFlag = playerPoint.capitalFlag;
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
		byte techLevel = DataManager.Instance.GetTechLevel(43);
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			if (DataManager.Instance.MarchEventData[i].Type != EMarchEventType.EMET_Standby)
			{
				num++;
			}
		}
		if (DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
		{
			num++;
		}
		POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)this.m_MapPointID);
		bool flag;
		if (DataManager.MapDataController.IsResources((uint)this.m_MapPointID))
		{
			flag = DataManager.Instance.IsSameAlliance(resourcesPoint.allianceTag);
		}
		else if (mapPoint.pointKind == 11)
		{
			flag = DataManager.Instance.IsSameAlliance(DataManager.MapDataController.YolkPointTable[(int)mapPoint.tableID].WonderAllianceTag);
		}
		else
		{
			flag = DataManager.Instance.IsSameAlliance(playerPoint.allianceTag);
		}
		bool result = false;
		this.m_Str[17].ClearString();
		if (eCheck == eScoutCheckBox.PreScout)
		{
			if (layoutMapInfoPointKind == POINT_KIND.PK_CITY && (capitalFlag & 4) != 0)
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(4898u), mStringTable.GetStringByID(4899u), null, null, 0, 0, false, false, false, false, false);
				result = false;
			}
			else if ((long)num >= (long)((ulong)effectBaseVal))
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(3967u), mStringTable.GetStringByID(3959u), null, null, 0, 0, false, false, false, false, false);
				result = false;
			}
			else if (techLevel <= 0)
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(5710u), mStringTable.GetStringByID(5711u), 9, mStringTable.GetStringByID(3968u), 0, 0, true, false, false, false, false);
				result = false;
			}
			else
			{
				result = true;
			}
		}
		else if (eCheck == eScoutCheckBox.Shield_Self)
		{
			if ((long)num >= (long)((ulong)effectBaseVal))
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(3967u), mStringTable.GetStringByID(3959u), null, null, 0, 0, false, false, false, false, false);
				result = false;
			}
			else if (techLevel <= 0)
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(5710u), mStringTable.GetStringByID(5711u), 9, mStringTable.GetStringByID(3968u), 0, 0, true, false, false, false, false);
				result = false;
			}
			else if (this.IsSameScouting())
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(5710u), mStringTable.GetStringByID(5711u), null, null, 0, 0, false, false, false, false, false);
				result = false;
			}
			else if (layoutMapInfoPointKind == POINT_KIND.PK_NONE)
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(5715u), mStringTable.GetStringByID(5716u), null, null, 0, 0, false, false, false, false, false);
			}
			else if (layoutMapInfoPointKind == POINT_KIND.PK_CITY && (capitalFlag & 4) != 0)
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(4898u), mStringTable.GetStringByID(4899u), null, null, 0, 0, false, false, false, false, false);
				result = false;
			}
			else if (flag)
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(5718u), mStringTable.GetStringByID(5719u), null, null, 0, 0, false, false, false, false, false);
				result = false;
			}
			else if ((ulong)DataManager.Instance.Resource[4].Stock < (ulong)((long)this.GetScoutMoney(this.m_ScoutTagLv, layoutMapInfoPointKind)))
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(5721u), mStringTable.GetStringByID(5722u), 6, mStringTable.GetStringByID(5723u), 0, 0, true, false, false, false, false);
				this.OpenDetectPanel(false, 0, false);
				result = false;
			}
			else
			{
				result = true;
			}
		}
		else if (eCheck == eScoutCheckBox.NoShield_Self)
		{
			if ((long)num >= (long)((ulong)effectBaseVal))
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(3967u), mStringTable.GetStringByID(3959u), null, null, 0, 0, false, false, false, false, false);
				result = false;
			}
			else if (techLevel <= 0)
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(5710u), mStringTable.GetStringByID(5711u), 9, mStringTable.GetStringByID(3968u), 0, 0, true, false, false, false, false);
				result = false;
			}
			else if (this.IsSameScouting())
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(5725u), mStringTable.GetStringByID(5726u), null, null, 0, 0, false, false, false, false, false);
				result = false;
			}
			else if (layoutMapInfoPointKind == POINT_KIND.PK_NONE)
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(5715u), mStringTable.GetStringByID(5716u), null, null, 0, 0, false, false, false, false, false);
			}
			else if (layoutMapInfoPointKind == POINT_KIND.PK_CITY && (capitalFlag & 4) != 0)
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(4898u), mStringTable.GetStringByID(4899u), null, null, 0, 0, false, false, false, false, false);
				result = false;
			}
			else if (flag)
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(5718u), mStringTable.GetStringByID(5719u), null, null, 0, 0, false, false, false, false, false);
				result = false;
			}
			else if ((ulong)DataManager.Instance.Resource[4].Stock < (ulong)((long)this.GetScoutMoney(this.m_ScoutTagLv, layoutMapInfoPointKind)))
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(5721u), mStringTable.GetStringByID(5722u), 6, mStringTable.GetStringByID(5723u), 0, 0, true, false, false, false, false);
				this.OpenDetectPanel(false, 0, false);
				result = false;
			}
			else
			{
				result = true;
			}
		}
		else if (eCheck == eScoutCheckBox.Shield_Other)
		{
			if (layoutMapInfoPointKind == POINT_KIND.PK_CITY && (capitalFlag & 4) != 0)
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(4898u), mStringTable.GetStringByID(4899u), null, null, 0, 0, false, false, false, false, false);
				result = false;
			}
			else if ((ulong)DataManager.Instance.Resource[4].Stock < (ulong)((long)this.GetScoutMoney(this.m_ScoutTagLv, layoutMapInfoPointKind)))
			{
				instance.OpenMessageBox(mStringTable.GetStringByID(5721u), mStringTable.GetStringByID(5722u), 6, mStringTable.GetStringByID(5723u), 0, 0, true, false, false, false, false);
				this.OpenDetectPanel(false, 0, false);
				result = false;
			}
			else
			{
				result = true;
			}
		}
		return result;
	}

	// Token: 0x0600121B RID: 4635 RVA: 0x001F9C28 File Offset: 0x001F7E28
	public bool AttackCheckBox()
	{
		GUIManager instance = GUIManager.Instance;
		StringTable mStringTable = DataManager.Instance.mStringTable;
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
		PlayerPoint playerPoint = DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID];
		byte capitalFlag = playerPoint.capitalFlag;
		POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)this.m_MapPointID);
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			if (DataManager.Instance.MarchEventData[i].Type != EMarchEventType.EMET_Standby)
			{
				num++;
			}
		}
		bool result;
		if (layoutMapInfoPointKind == POINT_KIND.PK_CITY && (capitalFlag & 4) != 0)
		{
			instance.OpenMessageBox(mStringTable.GetStringByID(4898u), mStringTable.GetStringByID(4899u), null, null, 0, 0, false, false, false, false, false);
			result = false;
		}
		else if ((long)num >= (long)((ulong)effectBaseVal))
		{
			instance.OpenMessageBox(mStringTable.GetStringByID(3967u), mStringTable.GetStringByID(3959u), null, null, 0, 0, false, false, false, false, false);
			result = false;
		}
		else
		{
			result = true;
		}
		return result;
	}

	// Token: 0x0600121C RID: 4636 RVA: 0x001F9D60 File Offset: 0x001F7F60
	public bool ReinforceCheck()
	{
		GUIManager instance = GUIManager.Instance;
		StringTable mStringTable = DataManager.Instance.mStringTable;
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			if (DataManager.Instance.MarchEventData[i].Type != EMarchEventType.EMET_Standby)
			{
				num++;
			}
		}
		this.m_Str[26].ClearString();
		bool flag;
		if ((long)num >= (long)((ulong)effectBaseVal))
		{
			instance.OpenMessageBox(mStringTable.GetStringByID(3967u), mStringTable.GetStringByID(3959u), null, null, 0, 0, false, false, false, false, false);
			flag = false;
		}
		else
		{
			flag = true;
		}
		if (!flag)
		{
			this.Close();
		}
		return flag;
	}

	// Token: 0x0600121D RID: 4637 RVA: 0x001F9E20 File Offset: 0x001F8020
	public bool RallyCheck()
	{
		GUIManager instance = GUIManager.Instance;
		StringTable mStringTable = DataManager.Instance.mStringTable;
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
		PlayerPoint playerPoint = DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID];
		byte capitalFlag = playerPoint.capitalFlag;
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			if (DataManager.Instance.MarchEventData[i].Type != EMarchEventType.EMET_Standby)
			{
				num++;
			}
		}
		bool flag = GUIManager.Instance.BuildingData.GetBuildData(11, 0).Level > 0;
		POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)this.m_MapPointID);
		bool result;
		if (layoutMapInfoPointKind == POINT_KIND.PK_CITY && (capitalFlag & 4) != 0)
		{
			instance.OpenMessageBox(mStringTable.GetStringByID(4898u), mStringTable.GetStringByID(4899u), null, null, 0, 0, false, false, false, false, false);
			result = false;
		}
		else if ((long)num >= (long)((ulong)effectBaseVal))
		{
			instance.OpenMessageBox(mStringTable.GetStringByID(3967u), mStringTable.GetStringByID(3959u), null, null, 0, 0, false, false, false, false, false);
			result = false;
		}
		else if (DataManager.Instance.RoleAlliance.Id == 0u)
		{
			instance.OpenMessageBox(mStringTable.GetStringByID(4892u), mStringTable.GetStringByID(4893u), null, null, 0, 0, false, false, false, false, false);
			result = false;
		}
		else if (!flag)
		{
			instance.OpenMessageBox(mStringTable.GetStringByID(4895u), mStringTable.GetStringByID(4896u), null, null, 0, 0, false, false, false, false, false);
			result = false;
		}
		else if (!this.IsNpcCastleType((POINT_KIND)mapPoint.pointKind, mapPoint.tableID) && mapPoint.pointKind != 11 && playerPoint.level < 17 && playerPoint.allianceTag.Length == 0)
		{
			instance.OpenMessageBox(mStringTable.GetStringByID(4901u), mStringTable.GetStringByID(4902u), null, null, 0, 0, false, false, false, false, false);
			result = false;
		}
		else
		{
			result = true;
		}
		return result;
	}

	// Token: 0x0600121E RID: 4638 RVA: 0x001FA064 File Offset: 0x001F8264
	public bool IsSameScouting()
	{
		bool result = false;
		for (int i = 0; i < 8; i++)
		{
			if (DataManager.Instance.MarchEventData[i].Type == EMarchEventType.EMET_ScoutMarching || DataManager.Instance.MarchEventData[i].Type == EMarchEventType.EMET_ScoutReturn)
			{
				PointCode pointCode;
				GameConstants.MapIDToPointCode(this.m_MapPointID, out pointCode.zoneID, out pointCode.pointID);
				if (DataManager.Instance.MarchEventData[i].Point.zoneID == pointCode.zoneID && DataManager.Instance.MarchEventData[i].Point.pointID == pointCode.pointID)
				{
					result = true;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x0600121F RID: 4639 RVA: 0x001FA12C File Offset: 0x001F832C
	public int GetScoutMoney(byte lv, POINT_KIND kind = POINT_KIND.PK_CITY)
	{
		int result = 0;
		if (kind == POINT_KIND.PK_YOLK)
		{
			result = 10000;
		}
		else if (this.m_MapPointID >= 0 && this.m_MapPointID < DataManager.MapDataController.LayoutMapInfo.Length)
		{
			MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
			if (this.IsNpcCastleType(kind, mapPoint.tableID))
			{
				int num = Mathf.Clamp((int)(lv - 1), 0, this.ScoutNeedMoney_NpcCastle.Length - 1);
				result = this.ScoutNeedMoney_NpcCastle[num];
			}
			else
			{
				int num = Mathf.Clamp((int)(lv - 1), 0, this.ScoutNeedMoney.Length - 1);
				result = this.ScoutNeedMoney[num];
			}
		}
		return result;
	}

	// Token: 0x06001220 RID: 4640 RVA: 0x001FA1E4 File Offset: 0x001F83E4
	public string GetBooksPanelTitle()
	{
		return this.m_BookmarksPanel.GetChild(9).GetComponent<UIEmojiInput>().text;
	}

	// Token: 0x06001221 RID: 4641 RVA: 0x001FA200 File Offset: 0x001F8400
	public ushort GetKingdomIDByMapPointID(int mapPointID)
	{
		return 0;
	}

	// Token: 0x06001222 RID: 4642 RVA: 0x001FA204 File Offset: 0x001F8404
	public void SetBookmarksPanel()
	{
		UISpritesArray component = this.m_AttackPanel.GetComponent<UISpritesArray>();
		if (this.m_BookmarkSelect == 3)
		{
			this.m_BookmarksPanel.GetChild(15).GetComponent<Image>().sprite = component.GetSprite(1);
			this.m_BookmarksPanel.GetChild(15).GetChild(1).gameObject.SetActive(true);
			for (int i = 0; i < 3; i++)
			{
				this.m_BookmarksPanel.GetChild(10 + i).GetComponent<Image>().sprite = component.GetSprite(0);
				this.m_BookmarksPanel.GetChild(10 + i).GetChild(1).gameObject.SetActive(false);
			}
		}
		else
		{
			this.m_BookmarksPanel.GetChild(15).GetComponent<Image>().sprite = component.GetSprite(0);
			this.m_BookmarksPanel.GetChild(15).GetChild(1).gameObject.SetActive(false);
			for (int j = 0; j < 3; j++)
			{
				if ((int)this.m_BookmarkSelect == j)
				{
					this.m_BookmarksPanel.GetChild(10 + j).GetComponent<Image>().sprite = component.GetSprite(1);
					this.m_BookmarksPanel.GetChild(10 + j).GetChild(1).gameObject.SetActive(true);
				}
				else
				{
					this.m_BookmarksPanel.GetChild(10 + j).GetComponent<Image>().sprite = component.GetSprite(0);
					this.m_BookmarksPanel.GetChild(10 + j).GetChild(1).gameObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x06001223 RID: 4643 RVA: 0x001FA39C File Offset: 0x001F859C
	public void Unload()
	{
		this.m_PanelGameObject = (this.m_TeamPanelGameObject = null);
		for (int i = 0; i < 51; i++)
		{
			if (this.m_Str[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.m_Str[i]);
			}
		}
		StringManager.Instance.DeSpawnString(this.BookMarkNameStr);
		if (this.m_AssetBundle == null)
		{
			return;
		}
		AssetManager.UnloadAssetBundle(this.m_AssetBundleKey, true);
		this.m_AssetBundle = null;
		this.m_AssetBundleKey = 0;
		UnityEngine.Object.Destroy(this.m_RectTransform.gameObject);
		if (this.WonderTileMapMat1 != null)
		{
			UnityEngine.Object.Destroy(this.WonderTileMapMat1);
		}
		if (this.WonderTileMapMat2 != null)
		{
			UnityEngine.Object.Destroy(this.WonderTileMapMat2);
		}
		if (this.m_BGIcon != null)
		{
			this.m_BGIcon.sprite = null;
		}
	}

	// Token: 0x06001224 RID: 4644 RVA: 0x001FA490 File Offset: 0x001F8690
	public void OnButtonClick(UIButton sender)
	{
		ushort kingdomID = 0;
		int in_posx = 0;
		int in_posy = 0;
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
		POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)this.m_MapPointID);
		if (sender.m_BtnID2 >= 101 && sender.m_BtnID2 <= 110 && sender.m_BtnID3 >= 100)
		{
			this.ShowCantClickMsg(sender.m_BtnID3);
			return;
		}
		int btnID = sender.m_BtnID2;
		switch (btnID)
		{
		case 301:
			if (this.m_Door.m_eMapMode == EUIOriginMapMode.WorldMap)
			{
				UIText component = sender.gameObject.transform.parent.GetChild(8).GetChild(0).GetComponent<UIText>();
				ushort.TryParse(component.text, out kingdomID);
				if (DataManager.MapDataController.CheckKingdomID(kingdomID))
				{
					this.m_Door.GoToKingdom(kingdomID, -1);
					this.Close();
				}
				else
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4503u), 255, true);
				}
			}
			else
			{
				UIText component = sender.gameObject.transform.parent.GetChild(8).GetChild(0).GetComponent<UIText>();
				ushort.TryParse(component.text, out kingdomID);
				component = sender.gameObject.transform.parent.GetChild(9).GetChild(0).GetComponent<UIText>();
				int.TryParse(component.text, out in_posx);
				component = sender.gameObject.transform.parent.GetChild(10).GetChild(0).GetComponent<UIText>();
				int.TryParse(component.text, out in_posy);
				bool flag = DataManager.MapDataController.CheckKingdomID(kingdomID) && GameConstants.CheckTileMapPos(in_posx, in_posy);
				if (flag)
				{
					this.m_Door.CheckFocusGroup();
					DataManager.MapDataController.FocusGroupID = 10;
					this.m_Door.GoToMapID(kingdomID, GameConstants.TileMapPosToMapID(in_posx, in_posy), 0, 1, true);
				}
				else
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4503u), 255, true);
				}
			}
			break;
		case 302:
			this.OpenSearchPanel(false, false);
			break;
		case 303:
			if (this.ReinforceCheck())
			{
				if (this.bOpenUIExpedition_FromList)
				{
					DataManager.Instance.ReinforceCheckType = eReinforceCheck.OpenUIExpedition_FromList;
					DataManager.Instance.SendAllyInforceInfo(DataManager.Instance.m_InForceName);
				}
				else
				{
					DataManager.Instance.ReinforceCheckType = eReinforceCheck.OpenUIExpedition;
					if (layoutMapInfoPointKind != POINT_KIND.PK_YOLK && (int)mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
					{
						DataManager.Instance.SendAllyInforceInfo(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName.ToString());
					}
				}
				this.Close();
			}
			else
			{
				this.Close();
			}
			break;
		case 304:
			this.OpenReinforcePanel(false, false, true);
			break;
		case 305:
		{
			this.OpenDetectPanel(false, 0, false);
			bool flag2 = this.ScoutCheckBox(eScoutCheckBox.Shield_Other);
			bool flag3 = this.IsNpcCastleType(layoutMapInfoPointKind, mapPoint.tableID);
			if (flag2)
			{
				if (!flag3 && ShieldLogManager.Instance.HasShieldState())
				{
					int warBuffCD = DataManager.Instance.GetWarBuffCD();
					if (warBuffCD > 0)
					{
						CString cstring = StringManager.Instance.StaticString1024();
						cstring.ClearString();
						cstring.IntToFormat((long)warBuffCD, 1, false);
						cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9933u));
						GUIManager.Instance.OpenOKCancelBox(7, DataManager.Instance.mStringTable.GetStringByID(4840u), cstring.ToString(), this.m_MapPointID, 0, DataManager.Instance.mStringTable.GetStringByID(4842u), DataManager.Instance.mStringTable.GetStringByID(4843u));
					}
					else
					{
						GUIManager.Instance.OpenOKCancelBox(7, DataManager.Instance.mStringTable.GetStringByID(4840u), DataManager.Instance.mStringTable.GetStringByID(4841u), this.m_MapPointID, 0, DataManager.Instance.mStringTable.GetStringByID(4842u), DataManager.Instance.mStringTable.GetStringByID(4843u));
					}
				}
				else
				{
					flag2 = this.ScoutCheckBox(eScoutCheckBox.NoShield_Self);
					if (flag2)
					{
						DataManager.Instance.ScoutDesPoint.pointID = 0;
						DataManager.Instance.ScoutDesPoint.zoneID = 0;
						GameConstants.MapIDToPointCode(this.m_MapPointID, out DataManager.Instance.ScoutDesPoint.zoneID, out DataManager.Instance.ScoutDesPoint.pointID);
						DataManager.Instance.SendScout(DataManager.Instance.ScoutDesPoint);
					}
				}
			}
			break;
		}
		case 306:
			this.OpenDetectPanel(false, 0, false);
			break;
		case 307:
			if (this.bHideSelectMod)
			{
				DataManager.Instance.RallyCountDownIndex = this.m_HideSelect;
				this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, 0, 4, true);
			}
			else
			{
				PointCode point;
				GameConstants.MapIDToPointCode(this.m_MapPointID, out point.zoneID, out point.pointID);
				if (DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) != 0f)
				{
					DataManager.Instance.RallyCountDownIndex = this.m_AttackSelect;
					if (this.IsNpcCastleType(layoutMapInfoPointKind, mapPoint.tableID))
					{
						this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, 0, 9, true);
					}
					else
					{
						this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, 0, 3, true);
					}
					this.OpenAttackPanel(false, false);
				}
				else
				{
					GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829u), DataManager.Instance.mStringTable.GetStringByID(119u), null, null, 0, 0, false, false, false, false, false);
				}
			}
			break;
		case 308:
			this.OpenAttackPanel(false, false);
			break;
		case 309:
			this.SetAttackPanel(this.bHideSelectMod, 0);
			break;
		case 310:
			this.SetAttackPanel(this.bHideSelectMod, 1);
			break;
		case 311:
			this.SetAttackPanel(this.bHideSelectMod, 2);
			break;
		case 312:
			this.SetAttackPanel(this.bHideSelectMod, 3);
			break;
		case 313:
			if (this.m_ModifyBookMarkID == 0)
			{
				if (this.m_MonsterMapPoint >= 0)
				{
					DataManager.Instance.RoleBookMark.sendAddBookMark(this.GetBooksPanelTitle(), this.m_BookmarkSelect, DataManager.MapDataController.FocusKingdomID, this.m_MonsterMapPoint);
					this.m_MonsterMapPoint = -1;
				}
				else
				{
					DataManager.Instance.RoleBookMark.sendAddBookMark(this.GetBooksPanelTitle(), this.m_BookmarkSelect, DataManager.MapDataController.FocusKingdomID, this.m_MapPointID);
				}
			}
			else
			{
				DataManager.Instance.RoleBookMark.sendModifyBookMark(this.m_ModifyBookMarkID, this.m_BookmarkSelect, this.GetBooksPanelTitle());
				this.m_ModifyBookMarkID = 0;
			}
			this.OpenBookmarksPanel(false);
			break;
		case 314:
			this.OpenBookmarksPanel(false);
			break;
		case 315:
			this.m_BookmarkSelect = 0;
			this.SetBookmarksPanel();
			break;
		case 316:
			this.m_BookmarkSelect = 1;
			this.SetBookmarksPanel();
			break;
		case 317:
			this.m_BookmarkSelect = 2;
			this.SetBookmarksPanel();
			break;
		case 318:
			this.inputField.ActivateInputField();
			break;
		case 319:
			this.OpenPvePanel(false, 1);
			this.bOpenPvePanel = true;
			this.m_Door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 4, 0, false);
			break;
		case 320:
			this.OpenPvePanel(false, 1);
			this.bOpenPvePanel = true;
			this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, 0, 1, true);
			break;
		case 321:
			this.OpenPvePanel(false, 1);
			this.bOpenPvePanel = false;
			break;
		case 322:
			this.Close();
			JailManage.Send_MSG_REQUEST_MAP_PRISONER_LIST(this.m_MapPointID);
			break;
		case 323:
		{
			ushort id = 0;
			if (this.m_ResType == 1)
			{
				id = 858;
			}
			else if (this.m_ResType == 2)
			{
				id = 860;
			}
			else if (this.m_ResType == 4)
			{
				id = 859;
			}
			else if (this.m_ResType == 3)
			{
				id = 857;
			}
			else if (this.m_ResType == 6)
			{
				id = 983;
			}
			GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(892u), DataManager.Instance.mStringTable.GetStringByID((uint)id), DataManager.Instance.mStringTable.GetStringByID(3u), null, 0, 0, false, true);
			break;
		}
		case 324:
			this.m_SearchInput = 0;
			GUIManager.Instance.m_UICalculator.m_CalculatorHandler = this;
			GUIManager.Instance.m_UICalculator.OpenCalculator(9999L, 0L, 280f, 0f, null, 0L);
			break;
		case 325:
			this.m_SearchInput = 1;
			GUIManager.Instance.m_UICalculator.m_CalculatorHandler = this;
			GUIManager.Instance.m_UICalculator.OpenCalculator(999L, 0L, 280f, 0f, null, 0L);
			break;
		case 326:
			this.m_SearchInput = 2;
			GUIManager.Instance.m_UICalculator.m_CalculatorHandler = this;
			GUIManager.Instance.m_UICalculator.OpenCalculator(9999L, 0L, 280f, 0f, null, 0L);
			break;
		case 327:
			if ((int)mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
			{
				byte btnType = this.ShowCanonizedBtnByTableID(mapPoint.tableID);
				switch (btnType)
				{
				case 1:
					TitleManager.Instance.OpenTitleSet(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName);
					break;
				case 2:
					TitleManager.Instance.OpenTitleListW(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName);
					break;
				case 3:
				case 5:
				case 6:
				case 7:
					GUIManager.Instance.OpenCanonizedPanel(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName, 1, (int)btnType);
					break;
				case 4:
					TitleManager.Instance.OpenNobilityTitleSet(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName);
					break;
				}
			}
			break;
		case 328:
			GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(12043u), DataManager.Instance.mStringTable.GetStringByID(12042u), null, null, 0, 0, true, true);
			break;
		case 329:
			this.OpenExpressionUI();
			break;
		case 330:
		{
			ushort kingdomID2 = 71;
			if (DataManager.MapDataController.CheckKingdomID(kingdomID2))
			{
				this.m_Door.GoToKingdom(kingdomID2, -1);
				this.Close();
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4503u), 255, true);
			}
			break;
		}
		case 331:
			if (sender.m_BtnID3 > 0)
			{
				if (sender.m_BtnID3 == 7744)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID((uint)sender.m_BtnID3), 255, true);
				}
				else if (sender.m_BtnID3 == 12572)
				{
					GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826u), DataManager.Instance.mStringTable.GetStringByID(12572u), null, null, 0, 0, false, false, false, false, false);
					this.Close();
				}
				else if (sender.m_BtnID3 == 12563)
				{
					GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826u), DataManager.Instance.mStringTable.GetStringByID(12563u), null, null, 0, 0, false, false, false, false, false);
					this.Close();
				}
			}
			else if (PetBuff.ShowActive(1))
			{
				this.Close();
				GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_PetSkill, this.m_MapPointID, 2, false, 0);
			}
			break;
		case 332:
			this.m_BookmarkSelect = 3;
			this.SetBookmarksPanel();
			break;
		default:
			switch (btnID)
			{
			case 101:
				switch (this.m_eGroundInfoKind)
				{
				case EGroundInfoKind.Resource:
					if (this.OwnerKind == 1)
					{
						DataManager.Instance.TroopeTakeBack(this.m_MapPointID, EMarchEventType.EMET_Gathering);
						GUIManager.Instance.HideUILock(EUILock.Expedition);
						this.Close();
					}
					else if (this.OwnerKind == 2 || this.OwnerKind == 3)
					{
						DataManager.Instance.ShowLordProfile(DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].playerName.ToString());
					}
					else if (this.OwnerKind == 0)
					{
						if (this.CheckMarchEventDataCount())
						{
							PointCode point;
							GameConstants.MapIDToPointCode(this.m_MapPointID, out point.zoneID, out point.pointID);
							if (DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) != 0f)
							{
								this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, this.m_MapPointID, 11, true);
							}
							else
							{
								GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829u), DataManager.Instance.mStringTable.GetStringByID(119u), null, null, 0, 0, false, false, false, false, false);
								this.Close();
							}
						}
						else
						{
							this.Close();
						}
					}
					break;
				case EGroundInfoKind.Camp:
					if (this.OwnerKind == 2 || this.OwnerKind == 3)
					{
						DataManager.Instance.ShowLordProfile(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName.ToString());
					}
					break;
				case EGroundInfoKind.Castle:
					if (this.OwnerKind == 1)
					{
						DataManager.MapDataController.OutMap();
						GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToMap);
						this.Close();
					}
					else if (this.OwnerKind == 2)
					{
						if (this.bHaveAlly)
						{
							this.m_Door.AllianceOnJoin(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag.ToString());
						}
						else
						{
							DataManager.Instance.SendAllinceInvite(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName.ToString());
						}
					}
					else if (this.OwnerKind == 3)
					{
						DataManager.Instance.ShowLordProfile(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName.ToString());
					}
					break;
				case EGroundInfoKind.NpcCastle:
					if (this.m_Door != null)
					{
						this.m_Door.AllianceOnClick();
						this.Close();
					}
					break;
				case EGroundInfoKind.Wonder:
					if (this.m_Door)
					{
						this.m_Door.OpenMenu(EGUIWindow.UI_WonderLand, this.m_MapPointID, 0, true);
					}
					break;
				}
				break;
			case 102:
				switch (this.m_eGroundInfoKind)
				{
				case EGroundInfoKind.Ground:
					DataManager.Instance.MoveTo(DataManager.MapDataController.FocusKingdomID, this.m_MapPointID);
					this.Close();
					break;
				case EGroundInfoKind.Camp:
					DataManager.Instance.TroopeTakeBack(this.m_MapPointID, EMarchEventType.EMET_Camp);
					this.Close();
					break;
				case EGroundInfoKind.Castle:
				{
					int ownerKind = this.OwnerKind;
					if (ownerKind != 2)
					{
						if (ownerKind == 3)
						{
							if (DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) == 0f)
							{
								GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829u), DataManager.Instance.mStringTable.GetStringByID(119u), null, null, 0, 0, false, false, false, false, false);
								this.Close();
								return;
							}
							bool flag4 = GUIManager.Instance.CanResourceTransport();
							if (flag4)
							{
								if (this.bRequsetAdvanceMapdata)
								{
									GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8459u), 255, true);
									return;
								}
								if (!this.IsSameKingdom())
								{
									GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826u), DataManager.Instance.mStringTable.GetStringByID(3957u), DataManager.Instance.mStringTable.GetStringByID(4828u), null, 0, 0, false, false, false, false, false);
									return;
								}
								if (this.m_Door)
								{
									this.m_Door.OpenMenu(EGUIWindow.UI_Market_Help, 1, this.m_MapPointID, false);
								}
							}
							else
							{
								this.Close();
							}
						}
					}
					else
					{
						DataManager.Instance.ShowLordProfile(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName.ToString());
					}
					break;
				}
				case EGroundInfoKind.WonderForest:
					GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(851u), DataManager.Instance.mStringTable.GetStringByID(852u), null, null, 0, 0, true, true);
					this.Close();
					break;
				case EGroundInfoKind.Wonder:
					if (this.m_Door)
					{
						this.m_Door.OpenMenu(EGUIWindow.UI_WonderLand, this.m_MapPointID, 0, true);
					}
					break;
				}
				break;
			case 103:
				switch (this.m_eGroundInfoKind)
				{
				case EGroundInfoKind.Ground:
					if (this.CheckMarchEventDataCount())
					{
						PointCode point;
						GameConstants.MapIDToPointCode(this.m_MapPointID, out point.zoneID, out point.pointID);
						if (DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) != 0f)
						{
							this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, this.m_MapPointID, 12, true);
						}
						else
						{
							GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829u), DataManager.Instance.mStringTable.GetStringByID(119u), null, null, 0, 0, false, false, false, false, false);
							this.Close();
						}
					}
					else
					{
						this.Close();
					}
					break;
				case EGroundInfoKind.Camp:
					if (this.m_Door)
					{
						int marcheventIdx = this.GetMarcheventIdx(this.m_MapPointID);
						this.m_Door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 1, marcheventIdx, false);
					}
					break;
				case EGroundInfoKind.Castle:
					if (this.OwnerKind == 3)
					{
						if (DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) == 0f)
						{
							GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829u), DataManager.Instance.mStringTable.GetStringByID(119u), null, null, 0, 0, false, false, false, false, false);
							this.Close();
							return;
						}
						if (this.ReinforceCheck())
						{
							DataManager.Instance.ReinforceCheckType = eReinforceCheck.OpenReinforce;
							DataManager.Instance.SendAllyInforceInfo(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName.ToString());
							this.Close();
						}
						else
						{
							this.Close();
						}
					}
					else
					{
						if (DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) == 0f)
						{
							GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829u), DataManager.Instance.mStringTable.GetStringByID(119u), null, null, 0, 0, false, false, false, false, false);
							this.Close();
							return;
						}
						if (this.RallyCheck())
						{
							this.OpenTitlePanel(false);
							this.OpenAttackPanel(true, false);
						}
						else
						{
							this.Close();
						}
					}
					break;
				case EGroundInfoKind.NpcCastle:
					if (DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) == 0f)
					{
						GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829u), DataManager.Instance.mStringTable.GetStringByID(119u), null, null, 0, 0, false, false, false, false, false);
						this.Close();
						return;
					}
					if (this.RallyCheck())
					{
						this.OpenTitlePanel(false);
						this.OpenAttackPanel(true, false);
					}
					break;
				case EGroundInfoKind.WonderForest:
					DataManager.Instance.MoveTo(DataManager.MapDataController.FocusKingdomID, this.m_MapPointID);
					this.Close();
					break;
				case EGroundInfoKind.Wonder:
					if (this.OwnerKind == 2)
					{
						if (this.RallyCheck())
						{
							this.OpenAttackPanel(true, false);
						}
						else
						{
							this.Close();
						}
					}
					else if ((this.OwnerKind == 1 || this.OwnerKind == 3) && (int)mapPoint.tableID < DataManager.MapDataController.YolkPointTable.Length)
					{
						MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int)mapPoint.tableID];
						if (this.m_Door != null)
						{
							this.m_Door.OpenMenu(EGUIWindow.UI_Rally, 101, (int)mapYolk.WonderID, false);
						}
					}
					break;
				}
				break;
			case 104:
				switch (this.m_eGroundInfoKind)
				{
				case EGroundInfoKind.Resource:
				{
					PointCode point;
					GameConstants.MapIDToPointCode(this.m_MapPointID, out point.zoneID, out point.pointID);
					DataManager.Instance.SendResPointLv(point);
					break;
				}
				case EGroundInfoKind.Camp:
				case EGroundInfoKind.Castle:
				case EGroundInfoKind.NpcCastle:
					this.OpenDetectPanel(true, 0, false);
					this.OpenTitlePanel(false);
					break;
				case EGroundInfoKind.Wonder:
					this.OpenDetectPanel(true, 0, true);
					break;
				}
				break;
			case 105:
				switch (this.m_eGroundInfoKind)
				{
				case EGroundInfoKind.Resource:
				case EGroundInfoKind.Camp:
				case EGroundInfoKind.Castle:
				case EGroundInfoKind.Wonder:
				{
					bool flag5 = this.AttackCheckBox();
					if (flag5)
					{
						PointCode point;
						GameConstants.MapIDToPointCode(this.m_MapPointID, out point.zoneID, out point.pointID);
						if (DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) != 0f)
						{
							this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, this.m_MapPointID, 0, true);
						}
						else
						{
							GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829u), DataManager.Instance.mStringTable.GetStringByID(119u), null, null, 0, 0, false, false, false, false, false);
							this.Close();
						}
					}
					else
					{
						this.Close();
					}
					break;
				}
				}
				break;
			case 106:
			{
				EGroundInfoKind eGroundInfoKind = this.m_eGroundInfoKind;
				if (eGroundInfoKind == EGroundInfoKind.Castle)
				{
					if (this.OwnerKind == 3)
					{
						DataManager.Instance.ShowLordProfile(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName.ToString());
					}
				}
				break;
			}
			case 107:
			{
				EGroundInfoKind eGroundInfoKind = this.m_eGroundInfoKind;
				if (eGroundInfoKind == EGroundInfoKind.Castle)
				{
					if (this.OwnerKind == 3)
					{
						if (DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) == 0f)
						{
							GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829u), DataManager.Instance.mStringTable.GetStringByID(119u), null, null, 0, 0, false, false, false, false, false);
							this.Close();
							return;
						}
						if (this.CheckMarchEventDataCount())
						{
							AmbushManager.Instance.SendAllyAmbushInfo(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName.ToString());
						}
						else
						{
							this.Close();
						}
					}
				}
				break;
			}
			case 108:
				break;
			case 109:
				if (this.bRequsetAdvanceMapdata)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8459u), 255, true);
					return;
				}
				if (this.m_Door)
				{
					this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, this.m_MapPointID, 7, true);
				}
				break;
			case 110:
				if (this.m_Door)
				{
					this.m_Door.OpenMenu(EGUIWindow.UI_CastleSkin, 0, 0, true);
				}
				break;
			case 111:
			{
				ushort parameter = 0;
				byte parameter2 = 0;
				GameConstants.MapIDToPointCode(-1, out parameter, out parameter2);
				GUIManager.Instance.UseOrSpend(GameConstants.RandomTeleportItemID, DataManager.Instance.mStringTable.GetStringByID(4512u), DataManager.MapDataController.FocusKingdomID, parameter, (ushort)parameter2, UseOrSpendType.UST_DIAMOND_DOUBLE_CHECK, null, null, string.Empty, 0);
				this.Close();
				break;
			}
			default:
				switch (btnID)
				{
				case 201:
					DataManager.Instance.TroopeTakeBack((uint)this.m_MapPointID);
					return;
				case 202:
					if (this.m_Door)
					{
						EMarchEventType lineFlag = (EMarchEventType)DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag;
						if (lineFlag == EMarchEventType.EMET_LordReturn)
						{
							this.m_Door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 30, false);
						}
						else
						{
							this.m_Door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 1073741824 | this.m_MapPointID, false);
						}
					}
					return;
				case 203:
					break;
				case 204:
					if (this.m_Door && this.m_MapPointID < DataManager.MapDataController.MapLineTable.Count)
					{
						if (GameConstants.IsSoccerRunningLine(this.m_MapPointID))
						{
							return;
						}
						MapLine mapLine = DataManager.MapDataController.MapLineTable[this.m_MapPointID];
						PointCode pointCode = mapLine.end;
						if (GameConstants.IsPetSkillLine(this.m_MapPointID))
						{
							pointCode = mapLine.start;
						}
						else if ((mapLine.lineFlag > 4 && mapLine.lineFlag < 14) || mapLine.lineFlag == 28)
						{
							pointCode = mapLine.start;
						}
						this.m_Door.GoToPointCode(DataManager.MapDataController.FocusKingdomID, pointCode.zoneID, pointCode.pointID, 0);
					}
					return;
				case 205:
					if (this.m_Door && this.m_MapPointID < DataManager.MapDataController.MapLineTable.Count)
					{
						PointCode end = DataManager.MapDataController.MapLineTable[this.m_MapPointID].end;
						this.m_Door.GoToPointCode(DataManager.MapDataController.FocusKingdomID, end.zoneID, end.pointID, 0);
					}
					return;
				default:
					switch (btnID)
					{
					case 1:
						break;
					case 2:
						this.m_BookmarkSelect = 0;
						this.OpenTitlePanel(false);
						this.OpenBookmarksPanel(true);
						return;
					case 3:
						this.SetChatText(this.m_MapPointID);
						return;
					default:
						return;
					}
					break;
				}
				this.Close();
				break;
			}
			break;
		}
	}

	// Token: 0x06001225 RID: 4645 RVA: 0x001FBFC8 File Offset: 0x001FA1C8
	public bool CheckMarchEventDataCount()
	{
		bool result = true;
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			if (DataManager.Instance.MarchEventData[i].Type != EMarchEventType.EMET_Standby)
			{
				num++;
			}
		}
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
		if ((long)num >= (long)((ulong)effectBaseVal))
		{
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3967u), DataManager.Instance.mStringTable.GetStringByID(3959u), null, null, 0, 0, false, false, false, false, false);
			result = false;
		}
		return result;
	}

	// Token: 0x06001226 RID: 4646 RVA: 0x001FC064 File Offset: 0x001FA264
	public void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 0)
		{
			POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)this.m_MapPointID);
			if (this.m_PanelGameObject.activeSelf)
			{
				if (this.m_infoKind == POINT_KIND.PK_NONE)
				{
					this.UpdateUIData_None(this.m_MapPointID);
				}
				else if (layoutMapInfoPointKind == POINT_KIND.PK_NPC)
				{
					this.Close();
				}
				else if (layoutMapInfoPointKind != this.m_PreKind)
				{
					this.Open(this.m_MapPointID, POINT_KIND.PK_MAX);
				}
				else
				{
					this.SetOwnerKind();
					this.UpdateUIData(this.m_MapPointID, false);
				}
			}
			else if (this.m_TeamPanelGameObject.activeSelf)
			{
				this.SetOwnerKind();
				this.UpdateTeamData();
			}
			else if (UIPetSkill.nowMapPoint == this.m_MapPointID && UIPetSkill.nowKind != layoutMapInfoPointKind && GUIManager.Instance.FindMenu(EGUIWindow.UI_PetSkill))
			{
				GUIManager.Instance.CloseMenu(EGUIWindow.UI_PetSkill);
				GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			}
		}
		else if (arg1 == 1)
		{
			if (this.m_PanelGameObject.activeSelf)
			{
				this.SetNegativePetSkillBtn(true);
				this.UpdatemPetNegativeBuff(arg2, false);
			}
			else if (this.m_Door && GUIManager.Instance.FindMenu(EGUIWindow.UI_PetSkill) && arg2 == UIPetSkill.nowMapPoint && DataManager.MapDataController.getStateCountByKind(0) > 0)
			{
				GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826u), DataManager.Instance.mStringTable.GetStringByID(12572u), null, null, 0, 0, false, false, false, false, false);
				GUIManager.Instance.CloseMenu(EGUIWindow.UI_PetSkill);
				GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			}
		}
	}

	// Token: 0x06001227 RID: 4647 RVA: 0x001FC238 File Offset: 0x001FA438
	private void SetOwnerKind()
	{
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
		this.OwnerKind = 0;
		this.bHaveAlly = false;
		this.bHaveAlly_Self = false;
		if (DataManager.Instance.RoleAlliance.Id != 0u)
		{
			this.bHaveAlly_Self = true;
		}
		POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)this.m_MapPointID);
		if (DataManager.MapDataController.IsResources((uint)this.m_MapPointID))
		{
			if (DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].playerName.Length != 0)
			{
				if (DataManager.CompareStr(DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].playerName, DataManager.Instance.RoleAttr.Name) == 0)
				{
					this.OwnerKind = 1;
				}
				else if (DataManager.Instance.IsSameAlliance(DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].allianceTag))
				{
					this.OwnerKind = 3;
				}
				else
				{
					this.OwnerKind = 2;
				}
			}
		}
		else if (layoutMapInfoPointKind == POINT_KIND.PK_CITY)
		{
			if (this.m_MapPointID == DataManager.Instance.RoleAttr.CapitalPoint && DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
			{
				this.OwnerKind = 1;
			}
			else if (DataManager.Instance.IsSameAlliance(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag))
			{
				this.OwnerKind = 3;
			}
			else
			{
				this.OwnerKind = 2;
			}
			if (DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag.Length != 0)
			{
				this.bHaveAlly = true;
			}
		}
		else if (layoutMapInfoPointKind == POINT_KIND.PK_CAMP)
		{
			if (DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName.Length != 0)
			{
				if (DataManager.CompareStr(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName, DataManager.Instance.RoleAttr.Name) == 0)
				{
					this.OwnerKind = 1;
				}
				else if (DataManager.Instance.IsSameAlliance(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag))
				{
					this.OwnerKind = 3;
				}
				else
				{
					this.OwnerKind = 2;
				}
			}
			if (DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag.Length != 0)
			{
				this.bHaveAlly = true;
			}
		}
		else if (layoutMapInfoPointKind == POINT_KIND.PK_YOLK)
		{
			if (DataManager.Instance.RoleAlliance.Tag == null || DataManager.Instance.RoleAlliance.Tag.Length <= 0)
			{
				this.OwnerKind = 4;
			}
			else if (this.CheckWonderArmy())
			{
				this.OwnerKind = 1;
			}
			else if (DataManager.MapDataController.YolkPointTable[(int)mapPoint.tableID].OwnerAllianceName != null)
			{
				if (DataManager.Instance.IsSameAlliance(DataManager.MapDataController.YolkPointTable[(int)mapPoint.tableID].WonderAllianceTag))
				{
					this.OwnerKind = 3;
				}
				else
				{
					this.OwnerKind = 2;
				}
			}
		}
	}

	// Token: 0x06001228 RID: 4648 RVA: 0x001FC5A8 File Offset: 0x001FA7A8
	private void UpdateTeamData()
	{
		this.m_TeamPanelGameObject.SetActive(true);
		this.m_PanelGameObject.SetActive(false);
		this.m_eGroundInfoKind = EGroundInfoKind.Team;
		if (this.m_MapPointID >= DataManager.MapDataController.MapLineTable.Count)
		{
			return;
		}
		if (GameConstants.IsSoccerRunningLine(this.m_MapPointID))
		{
			this.OwnerKind = 4;
		}
		else if (DataManager.MapDataController.MapLineTable[this.m_MapPointID].playerName != null && DataManager.CompareStr(DataManager.MapDataController.MapLineTable[this.m_MapPointID].playerName, DataManager.Instance.RoleAttr.Name) == 0)
		{
			this.OwnerKind = 1;
		}
		else if (DataManager.Instance.IsSameAlliance(DataManager.MapDataController.MapLineTable[this.m_MapPointID].allianceTag))
		{
			this.OwnerKind = 3;
		}
		else
		{
			this.OwnerKind = 2;
		}
		this.m_Str[13].ClearString();
		if (DataManager.MapDataController.MapLineTable[this.m_MapPointID].allianceTag != null && DataManager.MapDataController.MapLineTable[this.m_MapPointID].allianceTag.Length != 0)
		{
			GameConstants.FormatRoleName(this.m_Str[13], DataManager.MapDataController.MapLineTable[this.m_MapPointID].playerName, DataManager.MapDataController.MapLineTable[this.m_MapPointID].allianceTag, null, 0, 0, null, null, null, null);
		}
		else
		{
			StringManager.Instance.StringToFormat(DataManager.MapDataController.MapLineTable[this.m_MapPointID].playerName);
			this.m_Str[13].AppendFormat("{0}");
		}
		this.m_TeamIDText.text = this.m_Str[13].ToString();
		this.m_TeamIDText.SetAllDirty();
		this.m_TeamIDText.cachedTextGenerator.Invalidate();
		this.m_TeamIDText.cachedTextGeneratorForLayout.Invalidate();
		this.m_TeamIDLine.rectTransform.sizeDelta = new Vector2(this.m_TeamIDText.preferredWidth, this.m_TeamIDLine.rectTransform.sizeDelta.y);
		this.m_TeamIDLine.enabled = true;
		EMarchEventType lineFlag = (EMarchEventType)DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag;
		if (this.OwnerKind == 1)
		{
			if (GameConstants.IsPetSkillLine(this.m_MapPointID))
			{
				RectTransform component = this.m_TeamRetureBtn.gameObject.GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(-105f, -251f);
				component = this.m_TeamSpeedBtnGameObject.GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(30f, -251f);
				this.m_TeamRetureBtn.gameObject.SetActive(false);
				this.m_TeamSpeedBtnGameObject.SetActive(false);
				this.SetTempLocation(this.m_Str[11]);
				this.m_TeamLocText.enabled = true;
				this.m_TeamLocLine.enabled = true;
				this.m_TeamReturnText.enabled = false;
				this.m_TeamTargetText.enabled = true;
			}
			else if (GameConstants.IsMarchDeparture(lineFlag))
			{
				RectTransform component = this.m_TeamRetureBtn.gameObject.GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(-105f, -251f);
				component = this.m_TeamSpeedBtnGameObject.GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(30f, -251f);
				this.m_TeamRetureBtn.gameObject.SetActive(true);
				this.m_TeamSpeedBtnGameObject.SetActive(true);
				this.SetTempLocation(this.m_Str[11]);
				this.m_TeamLocText.enabled = true;
				this.m_TeamLocLine.enabled = true;
				this.m_TeamReturnText.enabled = false;
				this.m_TeamTargetText.enabled = true;
				if (lineFlag == EMarchEventType.EMET_RallyAttack || lineFlag == EMarchEventType.EMET_RallyStanby)
				{
					this.m_TeamRetureBtn.gameObject.SetActive(false);
					this.m_TeamSpeedBtnGameObject.SetActive(false);
				}
				else if (lineFlag == EMarchEventType.EMET_RallyMarching)
				{
					component = this.m_TeamSpeedBtnGameObject.GetComponent<RectTransform>();
					component.anchoredPosition = new Vector2(-39f, -251f);
					this.m_TeamRetureBtn.gameObject.SetActive(false);
					this.m_TeamSpeedBtnGameObject.SetActive(true);
				}
			}
			else if (GameConstants.IsMarchReturnOrRetreat(lineFlag))
			{
				RectTransform component = this.m_TeamRetureBtn.gameObject.GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(-39f, -251f);
				component = this.m_TeamSpeedBtnGameObject.GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(-39f, -251f);
				this.m_TeamRetureBtn.gameObject.SetActive(false);
				long num = DataManager.Instance.ServerTime - (long)DataManager.MapDataController.MapLineTable[this.m_MapPointID].begin;
				this.m_TeamSpeedBtnGameObject.SetActive(!this.IsAttackActionLineFlag((byte)lineFlag) || num > 5L);
				this.m_TeamLocText.enabled = false;
				this.m_TeamLocLine.enabled = false;
				this.m_TeamReturnText.enabled = true;
				this.m_TeamTargetText.enabled = false;
			}
		}
		else if (this.OwnerKind == 4)
		{
			this.m_TeamRetureBtn.gameObject.SetActive(false);
			this.m_TeamSpeedBtnGameObject.SetActive(false);
			RectTransform component = this.m_TeamRetureBtn.gameObject.GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(-105f, -251f);
			component = this.m_TeamSpeedBtnGameObject.GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(30f, -251f);
			this.SetTempLocation(this.m_Str[11]);
			this.m_TeamLocText.enabled = true;
			this.m_TeamLocLine.enabled = true;
			this.m_TeamIDLine.enabled = false;
			this.m_TeamReturnText.enabled = false;
			this.m_TeamTargetText.enabled = true;
		}
		else
		{
			this.m_TeamRetureBtn.gameObject.SetActive(false);
			this.m_TeamSpeedBtnGameObject.SetActive(false);
			if (GameConstants.IsPetSkillLine(this.m_MapPointID))
			{
				Debug.Log("IsPetSkillLine");
				RectTransform component = this.m_TeamRetureBtn.gameObject.GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(-105f, -251f);
				component = this.m_TeamSpeedBtnGameObject.GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(30f, -251f);
				this.SetTempLocation(this.m_Str[11]);
				this.m_TeamLocText.enabled = true;
				this.m_TeamLocLine.enabled = true;
				this.m_TeamReturnText.enabled = false;
				this.m_TeamTargetText.enabled = true;
			}
			else if (GameConstants.IsMarchDeparture(lineFlag))
			{
				this.SetTempLocation(this.m_Str[11]);
				this.m_TeamLocText.color = new Color(1f, 0.93f, 0.619f, 1f);
				this.m_TeamLocText.enabled = true;
				this.m_TeamLocLine.enabled = true;
				this.m_TeamReturnText.enabled = false;
				this.m_TeamTargetText.enabled = true;
			}
			else if (GameConstants.IsMarchReturnOrRetreat(lineFlag))
			{
				this.SetTempLocation(this.m_Str[11]);
				this.m_TeamLocText.enabled = false;
				this.m_TeamLocLine.enabled = false;
				this.m_TeamReturnText.enabled = true;
				this.m_TeamTargetText.enabled = false;
			}
		}
		if (lineFlag == EMarchEventType.EMET_RallyAttack && DataManager.MapDataController.MapLineTable[this.m_MapPointID].allianceTag != null && DataManager.MapDataController.MapLineTable[this.m_MapPointID].allianceTag.Length != 0 && DataManager.CompareStr(DataManager.MapDataController.MapLineTable[this.m_MapPointID].allianceTag, DataManager.Instance.RoleAlliance.Tag) == 0)
		{
			RectTransform component = this.m_TeamSpeedBtnGameObject.GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(-39f, -251f);
			this.m_TeamSpeedBtnGameObject.SetActive(true);
		}
		if (!this.SetExpressionButton(this.OwnerKind, POINT_KIND.PK_UNDEFINED))
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UIEmojiSelect, 3, 0);
		}
	}

	// Token: 0x06001229 RID: 4649 RVA: 0x001FCDFC File Offset: 0x001FAFFC
	public void UpdateUIData(int MapPointID, bool bDisbaleColor = false)
	{
		Vector2 zero = Vector2.zero;
		ushort num = 0;
		int num2 = DataManager.MapDataController.ResourcesPointTable.Length;
		if (this.TileMapMat == null)
		{
			this.TileMapMat = (UnityEngine.Object.Instantiate(this.m_Door.TileMapController.TileSprites.m_Image.material) as Material);
			this.TileMapMat.renderQueue = 3000;
		}
		POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)MapPointID);
		if (layoutMapInfoPointKind == POINT_KIND.PK_DYNAMIC_OBSTACLE)
		{
			return;
		}
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[MapPointID];
		this.m_PanelGameObject.SetActive(true);
		this.m_TeamPanelGameObject.SetActive(false);
		this.m_GroundPanel.gameObject.SetActive(false);
		this.m_ResourcePanel.gameObject.SetActive(false);
		if (layoutMapInfoPointKind != POINT_KIND.PK_CITY && layoutMapInfoPointKind != POINT_KIND.PK_CAMP)
		{
			this.m_CampPanel.gameObject.SetActive(false);
		}
		if (layoutMapInfoPointKind != POINT_KIND.PK_YOLK)
		{
			this.m_WondersPanel.gameObject.SetActive(false);
		}
		if (!this.IsNpcCastleType(layoutMapInfoPointKind, mapPoint.tableID))
		{
			this.m_NpcCastlePanel.gameObject.SetActive(false);
		}
		this.SetOwnerKind();
		this.m_ButtonRect6.gameObject.SetActive(false);
		this.m_ButtonRect7.gameObject.SetActive(false);
		this.m_ButtonRect8.gameObject.SetActive(false);
		this.m_ButtonRect9.gameObject.SetActive(false);
		this.m_ButtonRect10.gameObject.SetActive(false);
		this.m_ButtonRect11.gameObject.SetActive(false);
		zero.Set(121f, -170f);
		this.m_ButtonRect2.anchoredPosition = zero;
		zero.Set(295f, -170f);
		this.m_ButtonRect3.anchoredPosition = zero;
		this.m_BookmarkBtn.gameObject.SetActive(true);
		this.m_LocationText.enabled = true;
		this.m_ChatBtnRt.gameObject.SetActive(true);
		this.m_BGIcon.rectTransform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
		if (GUIManager.Instance.IsArabic && this.m_BGIcon.gameObject.GetComponent<ArabicItemTextureRot>() == null)
		{
			this.m_BGIcon.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.SetCityOutwardLevel(0);
		POINT_KIND point_KIND = layoutMapInfoPointKind;
		switch (point_KIND)
		{
		case POINT_KIND.PK_CITY:
			if (this.GetCastleType(mapPoint.tableID) == CITY_PROPERTY.CP_NPC)
			{
				this.SetNpcCastle(MapPointID, bDisbaleColor);
			}
			else
			{
				this.SetPlayerCastle(MapPointID, bDisbaleColor);
			}
			break;
		case POINT_KIND.PK_CAMP:
			if ((int)mapPoint.tableID < num2)
			{
				num = (ushort)DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].level;
			}
			this.m_eGroundInfoKind = EGroundInfoKind.Camp;
			this.m_Door.TileMapController.getTileMapSprite(ref this.m_BGIcon, layoutMapInfoPointKind, (int)num, CITY_OUTWARD.CO_PLAYER);
			this.m_BGIcon.material = this.TileMapMat;
			this.m_BGIcon.SetNativeSize();
			this.m_BGIconMask.enabled = false;
			this.m_CampPanel.gameObject.SetActive(true);
			this.m_WondersPanel.gameObject.SetActive(false);
			this.m_NpcCastlePanel.gameObject.SetActive(false);
			zero.Set(416f, 441f);
			this.m_Panel.sizeDelta = zero;
			zero.Set(35f, -124f);
			this.m_Panel.anchoredPosition = zero;
			zero.Set(377f, 126f);
			this.m_GroundTextBGRect.sizeDelta = zero;
			zero.Set(20f, -94f);
			this.m_GroundTextBGRect.anchoredPosition = zero;
			zero.Set(0f, -163f);
			this.m_LocationRt.anchoredPosition = zero;
			zero.Set(0f, -185f);
			this.m_ChatBtnRt.anchoredPosition = zero;
			this.m_GroundTitle.text = DataManager.Instance.mStringTable.GetStringByID(6305u);
			this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4535u);
			this.m_ButtonRect1.gameObject.SetActive(true);
			this.m_ButtonRect2.gameObject.SetActive(false);
			this.m_ButtonRect3.gameObject.SetActive(false);
			this.m_ButtonRect4.gameObject.SetActive(false);
			this.m_ButtonRect5.gameObject.SetActive(false);
			switch (this.OwnerKind)
			{
			case 1:
				this.m_ButtonRect1.gameObject.SetActive(false);
				this.m_ButtonRect2.gameObject.SetActive(true);
				this.m_ButtonRect3.gameObject.SetActive(true);
				this.m_ButtonRect4.gameObject.SetActive(false);
				this.m_ButtonRect5.gameObject.SetActive(false);
				zero.Set(this.m_ButtonRect2.anchoredPosition.x, -250f);
				this.m_ButtonRect2.anchoredPosition = zero;
				zero.Set(this.m_ButtonRect3.anchoredPosition.x, -250f);
				this.m_ButtonRect3.anchoredPosition = zero;
				this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4538u);
				this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4544u);
				break;
			case 2:
				this.m_ButtonRect1.gameObject.SetActive(true);
				this.m_ButtonRect2.gameObject.SetActive(false);
				this.m_ButtonRect3.gameObject.SetActive(false);
				this.m_ButtonRect4.gameObject.SetActive(true);
				this.m_ButtonRect5.gameObject.SetActive(true);
				zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
				this.m_ButtonRect1.anchoredPosition = zero;
				zero.Set(this.m_ButtonRect4.anchoredPosition.x, -309f);
				this.m_ButtonRect4.anchoredPosition = zero;
				zero.Set(this.m_ButtonRect5.anchoredPosition.x, -309f);
				this.m_ButtonRect5.anchoredPosition = zero;
				break;
			case 3:
				this.m_ButtonRect1.gameObject.SetActive(true);
				this.m_ButtonRect2.gameObject.SetActive(false);
				this.m_ButtonRect3.gameObject.SetActive(false);
				this.m_ButtonRect4.gameObject.SetActive(false);
				this.m_ButtonRect5.gameObject.SetActive(false);
				zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
				this.m_ButtonRect1.anchoredPosition = zero;
				this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4535u);
				break;
			}
			this.SetCampInfo(this.m_MapPointID, this.OwnerKind, bDisbaleColor);
			break;
		default:
			if (point_KIND != POINT_KIND.PK_NONE)
			{
				if ((int)mapPoint.tableID < num2)
				{
					num = (ushort)DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].level;
				}
				this.m_ResStartTime = this.GetResStartTime(this.m_MapPointID);
				this.m_ResTotalCount = DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].count;
				this.m_ResRate = DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].rate;
				this.m_MaxOverload = this.GetMaxOverload(this.m_MapPointID);
				this.m_MaxOverload = (uint)Mathf.Clamp(this.m_MaxOverload, 0f, this.m_ResTotalCount);
				this.m_Door.TileMapController.getTileMapSprite(ref this.m_BGIcon, layoutMapInfoPointKind, (int)num, CITY_OUTWARD.CO_PLAYER);
				this.m_BGIcon.material = this.TileMapMat;
				this.m_BGIcon.SetNativeSize();
				this.m_BGIconMask.enabled = false;
				this.m_Str[4].ClearString();
				if (DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].allianceTag.Length != 0)
				{
					if (DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].kingdomID != DataManager.MapDataController.kingdomData.kingdomID && DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].kingdomID != 0)
					{
						GameConstants.FormatRoleName(this.m_Str[4], DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].playerName, DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].allianceTag, null, 0, DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].kingdomID, null, null, null, null);
					}
					else
					{
						GameConstants.FormatRoleName(this.m_Str[4], DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].playerName, DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].allianceTag, null, 0, 0, null, null, null, null);
					}
				}
				else if (DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].kingdomID != DataManager.MapDataController.kingdomData.kingdomID && DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].kingdomID != 0)
				{
					GameConstants.FormatRoleName(this.m_Str[4], DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].playerName, null, null, 0, 0, null, null, null, null);
				}
				else
				{
					StringManager.Instance.StringToFormat(DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].playerName);
					this.m_Str[4].AppendFormat("{0}");
				}
				this.m_ResourceOwnerText.text = this.m_Str[4].ToString();
				switch (layoutMapInfoPointKind)
				{
				case POINT_KIND.PK_FOOD:
					this.sb.Length = 0;
					this.sb.AppendFormat("{0} {1}{2}", DataManager.Instance.mStringTable.GetStringByID(6306u), DataManager.Instance.mStringTable.GetStringByID(32u), num);
					this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4525u);
					this.m_GroundTitle.text = this.sb.ToString();
					this.m_ResourceIcon.sprite = this.m_SpriteArray.GetSprite(0);
					this.m_ResourceIcon.SetNativeSize();
					this.m_ResType = 1;
					this.m_InformationBtn.gameObject.SetActive(true);
					break;
				case POINT_KIND.PK_STONE:
					this.sb.Length = 0;
					this.sb.AppendFormat("{0} {1}{2}", DataManager.Instance.mStringTable.GetStringByID(6308u), DataManager.Instance.mStringTable.GetStringByID(32u), num);
					this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4526u);
					this.m_GroundTitle.text = this.sb.ToString();
					this.m_ResourceIcon.sprite = this.m_SpriteArray.GetSprite(1);
					this.m_ResourceIcon.SetNativeSize();
					this.m_ResType = 2;
					this.m_InformationBtn.gameObject.SetActive(true);
					break;
				case POINT_KIND.PK_IRON:
					this.sb.Length = 0;
					this.sb.AppendFormat("{0} {1}{2}", DataManager.Instance.mStringTable.GetStringByID(6307u), DataManager.Instance.mStringTable.GetStringByID(32u), num);
					this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4527u);
					this.m_GroundTitle.text = this.sb.ToString();
					this.m_ResourceIcon.sprite = this.m_SpriteArray.GetSprite(2);
					this.m_ResourceIcon.SetNativeSize();
					this.m_ResType = 3;
					this.m_InformationBtn.gameObject.SetActive(true);
					break;
				case POINT_KIND.PK_WOOD:
					this.sb.Length = 0;
					this.sb.AppendFormat("{0} {1}{2}", DataManager.Instance.mStringTable.GetStringByID(6309u), DataManager.Instance.mStringTable.GetStringByID(32u), num);
					this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4524u);
					this.m_GroundTitle.text = this.sb.ToString();
					this.m_ResourceIcon.sprite = this.m_SpriteArray.GetSprite(3);
					this.m_ResourceIcon.SetNativeSize();
					this.m_ResType = 4;
					this.m_InformationBtn.gameObject.SetActive(true);
					break;
				case POINT_KIND.PK_GOLD:
					this.sb.Length = 0;
					this.sb.AppendFormat("{0} {1}{2}", DataManager.Instance.mStringTable.GetStringByID(6311u), DataManager.Instance.mStringTable.GetStringByID(32u), num);
					this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4528u);
					this.m_GroundTitle.text = this.sb.ToString();
					this.m_ResourceIcon.sprite = this.m_SpriteArray.GetSprite(4);
					this.m_ResourceIcon.SetNativeSize();
					this.m_ResType = 5;
					this.m_InformationBtn.gameObject.SetActive(false);
					break;
				case POINT_KIND.PK_CRYSTAL:
					this.sb.Length = 0;
					this.sb.AppendFormat("{0} {1}{2}", DataManager.Instance.mStringTable.GetStringByID(6310u), DataManager.Instance.mStringTable.GetStringByID(32u), num);
					this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4529u);
					this.m_GroundTitle.text = this.sb.ToString();
					this.m_ResourceIcon.sprite = this.m_SpriteArray.GetSprite(5);
					this.m_ResourceIcon.SetNativeSize();
					this.m_ResType = 6;
					this.m_InformationBtn.gameObject.SetActive(true);
					break;
				}
				this.m_eGroundInfoKind = EGroundInfoKind.Resource;
				zero.Set(377f, 126f);
				this.m_GroundTextBGRect.sizeDelta = zero;
				zero.Set(20f, -47f);
				this.m_GroundTextBGRect.anchoredPosition = zero;
				zero.Set(0f, -140f);
				this.m_LocationRt.anchoredPosition = zero;
				zero.Set(0f, -165f);
				this.m_ChatBtnRt.anchoredPosition = zero;
				this.m_GroundText.gameObject.SetActive(false);
				this.m_ButtonRect1.gameObject.SetActive(true);
				this.m_ButtonRect2.gameObject.SetActive(false);
				this.m_ButtonRect3.gameObject.SetActive(false);
				this.m_ButtonRect4.gameObject.SetActive(false);
				this.m_ButtonRect5.gameObject.SetActive(false);
				this.m_ValueBar1.gameObject.SetActive(false);
				this.m_ValueBar2.gameObject.SetActive(false);
				this.m_ResourceText.text = DataManager.Instance.mStringTable.GetStringByID(4565u);
				this.m_ResourceProductionText.text = this.m_ResTotalCount.ToString("N0");
				this.m_SliderText1.text = DataManager.Instance.mStringTable.GetStringByID(4590u);
				switch (this.OwnerKind)
				{
				case 0:
					zero.Set(this.m_ButtonRect1.anchoredPosition.x, -203f);
					this.m_ButtonRect1.anchoredPosition = zero;
					this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(706u);
					this.m_ResourceOwnerText.text = DataManager.Instance.mStringTable.GetStringByID(4576u);
					this.m_ResourceOwnerText.color = new Color(1f, 0.443f, 0.443f);
					break;
				case 1:
					if (this.m_ResType == 6)
					{
						zero.Set(43f, -185f);
						this.m_ValueBar1.anchoredPosition = zero;
						zero.Set(43f, -216f);
						this.m_ValueBar2.anchoredPosition = zero;
						this.m_ValueBar1.gameObject.SetActive(true);
						this.m_ValueBar2.gameObject.SetActive(true);
					}
					else
					{
						zero.Set(43f, -208f);
						this.m_ValueBar2.anchoredPosition = zero;
						this.m_ValueBar2.gameObject.SetActive(true);
					}
					zero.Set(this.m_ButtonRect1.anchoredPosition.x, -275f);
					this.m_ButtonRect1.anchoredPosition = zero;
					this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4538u);
					this.m_ResourceOwnerText.color = new Color(0.807f, 1f, 0.713f);
					break;
				case 2:
					zero.Set(this.m_ButtonRect1.anchoredPosition.x, -203f);
					this.m_ButtonRect1.anchoredPosition = zero;
					zero.Set(this.m_ButtonRect4.anchoredPosition.x, -262f);
					this.m_ButtonRect4.anchoredPosition = zero;
					zero.Set(this.m_ButtonRect5.anchoredPosition.x, -262f);
					this.m_ButtonRect5.anchoredPosition = zero;
					this.m_ButtonRect4.gameObject.SetActive(true);
					this.m_ButtonRect5.gameObject.SetActive(true);
					this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4535u);
					this.m_ResourceOwnerText.color = new Color(0.807f, 1f, 0.713f);
					break;
				case 3:
					zero.Set(this.m_ButtonRect1.anchoredPosition.x, -203f);
					this.m_ButtonRect1.anchoredPosition = zero;
					this.m_ButtonRect4.gameObject.SetActive(false);
					this.m_ButtonRect5.gameObject.SetActive(false);
					this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4535u);
					this.m_ResourceOwnerText.color = new Color(0.807f, 1f, 0.713f);
					break;
				}
				zero.Set(416f, 394f);
				this.m_Panel.sizeDelta = zero;
				this.m_ResourcePanel.gameObject.SetActive(true);
				this.m_TimeTick = 1f;
				this.UpdateResourceInfo();
			}
			else
			{
				int item = 0;
				this.m_Door.TileMapController.getTileMapSprite(ref this.m_BGIcon, layoutMapInfoPointKind, this.m_MapPointID, CITY_OUTWARD.CO_PLAYER);
				this.m_BGIcon.material = this.TileMapMat;
				this.m_BGIcon.SetNativeSize();
				this.m_BGIconMask.enabled = true;
				this.m_eGroundInfoKind = EGroundInfoKind.Ground;
				zero.Set(377f, 126f);
				this.m_GroundTextBGRect.sizeDelta = zero;
				zero.Set(20f, -8f);
				this.m_GroundTextBGRect.anchoredPosition = zero;
				zero.Set(0f, -79f);
				this.m_LocationRt.anchoredPosition = zero;
				zero.Set(0f, -105f);
				this.m_ChatBtnRt.anchoredPosition = zero;
				if (this.m_MapPointID >= 0 && this.m_MapPointID < this.m_Door.TileMapController.TileMapInfo.Length)
				{
					item = (int)this.m_Door.TileMapController.TileMapInfo[this.m_MapPointID];
				}
				this.m_GroundTitle.text = this.GetPKNoneGroundTitle(this.m_MapPointID);
				this.m_ButtonRect1.gameObject.SetActive(false);
				this.m_ButtonRect2.gameObject.SetActive(true);
				this.m_ButtonRect4.gameObject.SetActive(false);
				this.m_ButtonRect5.gameObject.SetActive(false);
				this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4512u);
				this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4511u);
				this.m_GroundPanel.gameObject.SetActive(true);
				this.m_Str[10].ClearString();
				this.m_Str[31].ClearString();
				DataManager.MapDataController.GetKingdomName(DataManager.MapDataController.FocusKingdomID, ref this.m_Str[31]);
				StringManager.Instance.StringToFormat(this.m_Str[31]);
				this.m_Str[10].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(802u));
				this.m_GroundText.text = this.m_Str[10].ToString();
				this.m_GroundText.SetAllDirty();
				this.m_GroundText.cachedTextGenerator.Invalidate();
				zero.Set(416f, 267f);
				this.m_Panel.sizeDelta = zero;
				if (this.m_Door.TileMapController.CheckObstacle(MapPointID))
				{
					this.m_ButtonRect3.gameObject.SetActive(false);
					this.m_ButtonRect2.gameObject.SetActive(false);
				}
				else
				{
					this.m_ButtonRect3.gameObject.SetActive(true);
					this.m_ButtonRect2.gameObject.SetActive(true);
					this.m_ButtonRect2.anchoredPosition = new Vector2(121f, this.m_ButtonRect3.anchoredPosition.y);
				}
				this.m_ResourcePanel.gameObject.SetActive(false);
				this.m_GroundText.gameObject.SetActive(true);
				if (GameConstants.IsBetween(item, 109, 112))
				{
					this.m_eGroundInfoKind = EGroundInfoKind.WonderForest;
					this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(851u);
					this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4512u);
					this.m_GroundText.text = DataManager.Instance.mStringTable.GetStringByID(850u);
					this.m_GroundText.SetAllDirty();
					this.m_GroundText.cachedTextGenerator.Invalidate();
				}
				else if (GameConstants.IsBetween(item, 99, 108))
				{
					this.m_GroundText.text = DataManager.Instance.mStringTable.GetStringByID(855u);
					this.m_GroundText.SetAllDirty();
					this.m_GroundText.cachedTextGenerator.Invalidate();
				}
			}
			break;
		case POINT_KIND.PK_YOLK:
			if ((int)mapPoint.tableID < num2)
			{
				num = (ushort)DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].level;
			}
			this.m_eGroundInfoKind = EGroundInfoKind.Wonder;
			this.m_WondersPanel.gameObject.SetActive(true);
			this.m_CampPanel.gameObject.SetActive(false);
			zero.Set(416f, 441f);
			this.m_Panel.sizeDelta = zero;
			zero.Set(0f, -124f);
			this.m_Panel.anchoredPosition = zero;
			zero.Set(377f, 126f);
			this.m_GroundTextBGRect.sizeDelta = zero;
			zero.Set(20f, -94f);
			this.m_GroundTextBGRect.anchoredPosition = zero;
			zero.Set(0f, -163f);
			this.m_LocationRt.anchoredPosition = zero;
			zero.Set(0f, -185f);
			this.m_ChatBtnRt.anchoredPosition = zero;
			this.m_GroundTitle.text = string.Empty;
			this.m_BGIconMask.enabled = false;
			this.SetWondersInfo(this.m_MapPointID, bDisbaleColor);
			this.m_BGIcon.SetNativeSize();
			this.m_BGIcon.rectTransform.localScale = new Vector3(0.32f, 0.32f, 0.32f);
			break;
		}
		bool bLocalKindom = DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID;
		this.SetButtonColor(layoutMapInfoPointKind, bLocalKindom);
		if (!this.SetExpressionButton(this.OwnerKind, layoutMapInfoPointKind))
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UIEmojiSelect, 3, 0);
		}
	}

	// Token: 0x0600122A RID: 4650 RVA: 0x001FE760 File Offset: 0x001FC960
	public void UpdateUIData_None(int MapPointID)
	{
		Vector2 zero = Vector2.zero;
		if (this.TileMapMat == null)
		{
			this.TileMapMat = (UnityEngine.Object.Instantiate(this.m_Door.TileMapController.TileSprites.m_Image.material) as Material);
			this.TileMapMat.renderQueue = 3000;
		}
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[MapPointID];
		this.m_Door.TileMapController.getTileMapSprite(ref this.m_BGIcon, POINT_KIND.PK_NONE, this.m_MapPointID, CITY_OUTWARD.CO_PLAYER);
		this.m_BGIcon.material = this.TileMapMat;
		this.m_BGIcon.SetNativeSize();
		this.m_BGIconMask.enabled = true;
		if (this.m_MapPointID >= 0 && this.m_MapPointID < this.m_Door.TileMapController.TileMapInfo.Length)
		{
			int num = (int)this.m_Door.TileMapController.TileMapInfo[this.m_MapPointID];
		}
		this.m_GroundTitle.text = this.GetPKNoneGroundTitle(this.m_MapPointID);
		DataManager.MapDataController.GetKingdomName(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomID, ref this.m_Str[28]);
		StringManager.Instance.StringToFormat(this.m_Str[28]);
		this.m_Str[28].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4509u));
		this.m_GroundText.text = this.m_Str[28].ToString();
		this.m_eGroundInfoKind = EGroundInfoKind.Ground;
		zero.Set(377f, 126f);
		this.m_GroundTextBGRect.sizeDelta = zero;
		zero.Set(20f, -8f);
		this.m_GroundTextBGRect.anchoredPosition = zero;
		zero.Set(0f, -79f);
		this.m_LocationRt.anchoredPosition = zero;
		zero.Set(0f, -105f);
		this.m_ChatBtnRt.anchoredPosition = zero;
		zero.Set(416f, 267f);
		this.m_Panel.sizeDelta = zero;
		this.m_BookmarkBtn.gameObject.SetActive(false);
		this.m_LocationText.enabled = false;
		this.m_ChatBtnRt.gameObject.SetActive(false);
		this.m_ButtonRect1.gameObject.SetActive(false);
		this.m_ButtonRect2.gameObject.SetActive(false);
		this.m_ButtonRect3.gameObject.SetActive(false);
		this.m_ButtonRect4.gameObject.SetActive(false);
		this.m_ButtonRect5.gameObject.SetActive(false);
		this.m_ButtonRect10.gameObject.SetActive(false);
		this.m_ButtonRect11.gameObject.SetActive(false);
		this.m_PanelGameObject.SetActive(true);
		this.m_TeamPanelGameObject.SetActive(false);
		this.m_GroundPanel.gameObject.SetActive(true);
		this.m_ResourcePanel.gameObject.SetActive(false);
		this.m_CampPanel.gameObject.SetActive(false);
		this.m_WondersPanel.gameObject.SetActive(false);
		this.m_NpcCastlePanel.gameObject.SetActive(false);
		this.SetCityOutwardLevel(0);
		this.SetExpressionButton(this.OwnerKind, POINT_KIND.PK_NONE);
	}

	// Token: 0x0600122B RID: 4651 RVA: 0x001FEAB4 File Offset: 0x001FCCB4
	public void Open(int MapPointID, POINT_KIND infoKind = POINT_KIND.PK_MAX)
	{
		this.m_TimeTick = 1f;
		Vector2 zero = Vector2.zero;
		Vector2 vector;
		if (infoKind == POINT_KIND.PK_YOLK)
		{
			MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[MapPointID];
			vector = DataManager.MapDataController.GetYolkPos(mapPoint.tableID, DataManager.MapDataController.FocusKingdomID);
		}
		else
		{
			vector = GameConstants.getTileMapPosbySpriteID(MapPointID);
		}
		this.m_Str[8].ClearString();
		StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4504u));
		StringManager.Instance.IntToFormat((long)DataManager.MapDataController.FocusKingdomID, 1, false);
		StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4505u));
		StringManager.Instance.IntToFormat((long)((int)vector.x), 1, false);
		StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4506u));
		StringManager.Instance.IntToFormat((long)((int)vector.y), 1, false);
		if (GUIManager.Instance.IsArabic)
		{
			this.m_Str[8].AppendFormat("{5}{4} {3}{2} {1}{0}");
		}
		else
		{
			this.m_Str[8].AppendFormat("{0}{1} {2}{3} {4}{5}");
		}
		this.m_LocationText.text = this.m_Str[8].ToString();
		this.m_LocationText.SetAllDirty();
		this.m_LocationText.cachedTextGenerator.Invalidate();
		this.m_MapPointID = MapPointID;
		this.m_infoKind = infoKind;
		if (infoKind == POINT_KIND.PK_UNDEFINED)
		{
			this.UpdateTeamData();
			CHAOS chaos = GameManager.ActiveGameplay as CHAOS;
			if (chaos != null && chaos.realmController != null && chaos.realmController.mapLineController != null)
			{
				GameObject lineObject = DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineObject;
				LineNode nodeByGameObject = chaos.realmController.mapLineController.GetNodeByGameObject(lineObject, false);
				if (nodeByGameObject != null && nodeByGameObject.IsSoccerRunningLine && this.SoccerRun_SFXKey == 255)
				{
					if (nodeByGameObject.action == ELineAction.NORMAL)
					{
						AudioManager.Instance.PlaySFXLoop(40078, out this.SoccerRun_SFXKey, null, SFXEffect.Normal, 0f);
					}
					else
					{
						AudioManager.Instance.PlaySFXLoop(40078, out this.SoccerRun_SFXKey, null, SFXEffect.Normal, 1f);
					}
					Debug.LogWarning("PlaySFXLoop 40078");
				}
			}
		}
		else if (infoKind == POINT_KIND.PK_NONE)
		{
			this.UpdateUIData_None(MapPointID);
		}
		else
		{
			MapPoint mapPoint2 = DataManager.MapDataController.LayoutMapInfo[MapPointID];
			this.UpdateUIData(MapPointID, true);
			this.m_PreKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)MapPointID);
			if (DataManager.MapDataController.IsCityOrCamp((uint)MapPointID) || this.m_PreKind == POINT_KIND.PK_YOLK)
			{
				this.RequsetAdvanceMapdata(this.m_MapPointID);
			}
			if (DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)MapPointID) == POINT_KIND.PK_CITY)
			{
				this.SetNegativePetSkillBtn(false);
			}
		}
		this.bGroundInfoOpen = true;
	}

	// Token: 0x0600122C RID: 4652 RVA: 0x001FEDB8 File Offset: 0x001FCFB8
	private void SetWondersInfo(int _MapPointID, bool bDisbaleColor = false)
	{
		Vector2 zero = Vector2.zero;
		if (this.bRequsetAdvanceMapdata)
		{
			bDisbaleColor = this.bRequsetAdvanceMapdata;
		}
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[_MapPointID];
		if ((int)mapPoint.tableID < DataManager.MapDataController.YolkPointTable.Length)
		{
			MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int)mapPoint.tableID];
			if (mapYolk.WonderState == 2)
			{
				this.Close();
			}
			if (this.m_Door.TileMapController != null && this.m_Door.TileMapController.yolk != null)
			{
				if (mapYolk.WonderID == 0)
				{
					if (this.WonderTileMapMat1 == null)
					{
						this.WonderTileMapMat1 = (UnityEngine.Object.Instantiate(this.m_Door.TileMapController.yolk.getMapTileYolkMaterial(mapYolk.WonderID)) as Material);
						this.WonderTileMapMat1.renderQueue = 3000;
					}
					this.m_BGIcon.material = this.WonderTileMapMat1;
				}
				else
				{
					if (this.WonderTileMapMat2 == null)
					{
						this.WonderTileMapMat2 = (UnityEngine.Object.Instantiate(this.m_Door.TileMapController.yolk.getMapTileYolkMaterial(mapYolk.WonderID)) as Material);
						this.WonderTileMapMat2.renderQueue = 3000;
					}
					this.m_BGIcon.material = this.WonderTileMapMat2;
				}
				this.m_BGIcon.sprite = this.m_Door.TileMapController.yolk.getMapTileYolkSprite(mapYolk.WonderID);
				this.m_BGIcon.color = new Color(1f, 1f, 1f, 1f);
			}
			if (this.OwnerKind == 2)
			{
				if (mapYolk.WonderState == 0)
				{
					this.SetGroundInfoBtnState(UIGroundInfo.BtnState.WondersInfo_NA_Peace);
				}
				else if (mapYolk.WonderState == 1)
				{
					this.SetGroundInfoBtnState(UIGroundInfo.BtnState.WondersInfo_NA_Fight);
				}
			}
			else if (this.OwnerKind == 3)
			{
				if (mapYolk.WonderState == 0)
				{
					this.SetGroundInfoBtnState(UIGroundInfo.BtnState.WondersInfo_Ally_Peace);
				}
				else if (mapYolk.WonderState == 1)
				{
					this.SetGroundInfoBtnState(UIGroundInfo.BtnState.WondersInfo_Ally_Fight);
				}
			}
			else if (this.OwnerKind == 1)
			{
				if (mapYolk.WonderState == 0)
				{
					this.SetGroundInfoBtnState(UIGroundInfo.BtnState.WondersInfo_Army_Peace);
				}
				else if (mapYolk.WonderState == 1)
				{
					this.SetGroundInfoBtnState(UIGroundInfo.BtnState.WondersInfo_Army_Fight);
				}
			}
			else if (this.OwnerKind == 4)
			{
				this.SetGroundInfoBtnState(UIGroundInfo.BtnState.WondersInfo_NoAllIance);
			}
			this.m_WonderID.text = DataManager.MapDataController.GetYolkName((ushort)mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID).ToString();
			if (mapYolk.WonderState == 0)
			{
				this.m_WonderState.text = DataManager.Instance.mStringTable.GetStringByID(7232u);
				this.m_WonderState.color = new Color(0.207f, 0.968f, 0.423f, 1f);
				this.m_WonderTime.color = new Color(0.207f, 0.968f, 0.423f, 1f);
				this.m_WonderStateImage1.gameObject.SetActive(true);
				this.m_WonderStateImage2.gameObject.SetActive(false);
				this.m_WonderStateImage3.gameObject.SetActive(false);
				if (this.IsInWorldWarSelf())
				{
					this.m_WonderTimeTF.gameObject.SetActive(false);
				}
				else
				{
					this.m_WonderTimeTF.gameObject.SetActive(true);
				}
			}
			else if (mapYolk.WonderState == 1)
			{
				this.m_WonderTimeTF.gameObject.SetActive(true);
				if (this.IsInKvk(true) && !this.IsInWorldWarSelf())
				{
					this.m_WonderStateImage1.gameObject.SetActive(false);
					this.m_WonderStateImage2.gameObject.SetActive(false);
					this.m_WonderStateImage3.gameObject.SetActive(true);
					this.m_WonderState.text = DataManager.Instance.mStringTable.GetStringByID(9373u);
					this.m_WonderTime.color = new Color(1f, 0.788f, 0.439f, 1f);
					this.m_WonderState.color = new Color(1f, 0.788f, 0.439f, 1f);
				}
				else
				{
					this.m_WonderState.text = DataManager.Instance.mStringTable.GetStringByID(7233u);
					this.m_WonderState.color = new Color(1f, 0.227f, 0.333f, 1f);
					this.m_WonderTime.color = new Color(1f, 0.227f, 0.333f, 1f);
					this.m_WonderStateImage2.gameObject.SetActive(true);
					this.m_WonderStateImage1.gameObject.SetActive(false);
					this.m_WonderStateImage3.gameObject.SetActive(false);
				}
			}
			this.m_WonderAlliance.text = mapYolk.OwnerAllianceName.ToString();
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			DataManager.MapDataController.GetKingdomName(DataManager.MapDataController.FocusKingdomID, ref cstring);
			this.m_Str[40].ClearString();
			if (DataManager.MapDataController.kingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
			{
				this.m_Str[40].StringToFormat(cstring);
				this.m_Str[40].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4509u));
			}
			else
			{
				this.m_Str[40].IntToFormat((long)DataManager.MapDataController.FocusKingdomID, 1, false);
				this.m_Str[40].StringToFormat(cstring);
				this.m_Str[40].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9906u));
			}
			this.m_WonderKingdom.text = this.m_Str[40].ToString();
			this.m_WonderKingdom.color = Color.white;
			if (mapYolk.WonderAllianceTag.Length == 0)
			{
				GUIManager.Instance.ChangeWonderImg(this.m_WonderHIBtn.transform, mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID);
				this.m_WonderHIBtn.gameObject.SetActive(true);
				this.m_WonderAllianeIcon.gameObject.SetActive(false);
				this.m_WonderAllianeFrame.gameObject.SetActive(false);
			}
			else
			{
				GUIManager.Instance.SetBadgeTotemImg(this.m_WonderAllianeIcon, mapYolk.OwnerEmblem);
				this.m_WonderHIBtn.gameObject.SetActive(false);
				this.m_WonderAllianeIcon.gameObject.SetActive(true);
				this.m_WonderAllianeFrame.gameObject.SetActive(true);
			}
			if (mapYolk.WonderLeader[0] == '\0')
			{
				bool flag = DataManager.MapDataController.FocusKingdomID == ActivityManager.Instance.KOWKingdomID;
				this.m_Str[39].ClearString();
				if (flag)
				{
					this.m_Str[39].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(245u));
					if (mapYolk.WonderID > 0)
					{
						if (mapYolk.WonderState == 0)
						{
							this.m_Str[39].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11156u));
						}
						else
						{
							this.m_Str[39].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11037u));
						}
					}
					else if (mapYolk.WonderState == 0)
					{
						this.m_Str[39].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11036u));
					}
					else
					{
						this.m_Str[39].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11037u));
					}
				}
				else
				{
					this.m_Str[39].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(245u));
					this.m_Str[39].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7230u));
				}
				this.m_WonderOwner.text = this.m_Str[39].ToString();
			}
			else
			{
				this.m_Str[39].ClearString();
				if (mapYolk.WonderAllianceTag != null)
				{
					this.SetWonderOwnerText_WorldWar(this.m_Str[39], mapYolk);
				}
				this.m_WonderOwner.text = this.m_Str[39].ToString();
			}
			this.m_Str[38].ClearString();
			if (mapYolk.OwnerAllianceName[0] == '\0')
			{
				this.m_Str[38].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(245u));
				this.m_Str[38].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4600u));
			}
			else
			{
				CString cstring2 = StringManager.Instance.StaticString1024();
				CString cstring3 = StringManager.Instance.StaticString1024();
				CString cstring4 = StringManager.Instance.StaticString1024();
				if (DataManager.Instance.RoleAlliance.KingdomID == mapYolk.AllianceKingdomID)
				{
					if (GUIManager.Instance.IsArabic)
					{
						cstring3.Append(mapYolk.OwnerAllianceName);
						cstring4.Append(mapYolk.WonderAllianceTag);
						GUIManager.Instance.FormatRoleNameForChat(cstring2, cstring3, cstring4, 0, GUIManager.Instance.IsArabic);
						this.m_Str[38].StringToFormat(cstring2);
						this.m_Str[38].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4543u));
					}
					else
					{
						this.m_Str[38].StringToFormat(mapYolk.WonderAllianceTag);
						this.m_Str[38].StringToFormat(mapYolk.OwnerAllianceName);
						this.m_Str[38].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4543u));
					}
				}
				else if (GUIManager.Instance.IsArabic)
				{
					cstring3.Append(mapYolk.OwnerAllianceName);
					cstring4.Append(mapYolk.WonderAllianceTag);
					GUIManager.Instance.FormatRoleNameForChat(cstring2, cstring3, cstring4, mapYolk.AllianceKingdomID, GUIManager.Instance.IsArabic);
					this.m_Str[38].StringToFormat(cstring2);
					this.m_Str[38].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9904u));
				}
				else
				{
					this.m_Str[38].IntToFormat((long)mapYolk.AllianceKingdomID, 1, false);
					this.m_Str[38].StringToFormat(mapYolk.WonderAllianceTag);
					this.m_Str[38].StringToFormat(mapYolk.OwnerAllianceName);
					this.m_Str[38].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9904u));
				}
			}
			this.m_WonderAlliance.text = this.m_Str[38].ToString();
			if (bDisbaleColor)
			{
				this.m_WonderAlliance.color = Color.gray;
				this.m_WonderOwner.color = Color.gray;
			}
			else
			{
				this.m_WonderAlliance.color = Color.white;
				this.m_WonderOwner.color = Color.white;
			}
			this.m_WonderTime.text = DataManager.Instance.mStringTable.GetStringByID(9321u);
			this.m_WonderState.SetAllDirty();
			this.m_WonderState.cachedTextGenerator.Invalidate();
			this.m_WonderID.SetAllDirty();
			this.m_WonderID.cachedTextGenerator.Invalidate();
			this.m_WonderAlliance.SetAllDirty();
			this.m_WonderAlliance.cachedTextGenerator.Invalidate();
			this.m_WonderOwner.SetAllDirty();
			this.m_WonderOwner.cachedTextGenerator.Invalidate();
			this.m_WonderKingdom.SetAllDirty();
			this.m_WonderKingdom.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x0600122D RID: 4653 RVA: 0x001FF9CC File Offset: 0x001FDBCC
	private void SetWonderTimeInfo(int _MapPointID)
	{
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[_MapPointID];
		if ((int)mapPoint.tableID < DataManager.MapDataController.YolkPointTable.Length)
		{
			MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int)mapPoint.tableID];
			if (mapYolk.StateBegin > 0UL)
			{
				ulong num = mapYolk.StateBegin + (ulong)mapYolk.StateDuring;
				if (num >= (ulong)DataManager.Instance.ServerTime)
				{
					uint sec = (uint)(num - (ulong)DataManager.Instance.ServerTime);
					this.m_Str[37].ClearString();
					GameConstants.GetTimeString(this.m_Str[37], sec, false, false, true, false, true);
					this.m_WonderTime.text = this.m_Str[37].ToString();
					this.m_WonderTime.SetAllDirty();
					this.m_WonderTime.cachedTextGenerator.Invalidate();
				}
			}
		}
	}

	// Token: 0x0600122E RID: 4654 RVA: 0x001FFABC File Offset: 0x001FDCBC
	private bool CheckWonderArmy()
	{
		bool result = false;
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
		if ((int)mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
		{
			MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int)mapPoint.tableID];
			byte wonderID = mapYolk.WonderID;
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
			{
				int num = 0;
				while ((long)num < (long)((ulong)effectBaseVal))
				{
					if (DataManager.Instance.MarchEventData[num].Type == EMarchEventType.EMET_Camp && DataManager.Instance.MarchEventData[num].PointKind == POINT_KIND.PK_YOLK)
					{
						Vector2 tileMapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(DataManager.Instance.MarchEventData[num].Point.zoneID, DataManager.Instance.MarchEventData[num].Point.pointID);
						if (DataManager.MapDataController.GetYolkPos((ushort)wonderID, 0) == tileMapPosbyPointCode)
						{
							result = true;
							break;
						}
					}
					num++;
				}
			}
		}
		return result;
	}

	// Token: 0x0600122F RID: 4655 RVA: 0x001FFC04 File Offset: 0x001FDE04
	private void SetCampInfo(int _MapPointID, int _OwnerType, bool bDisbaleColor = false)
	{
		Vector2 zero = Vector2.zero;
		if (this.bRequsetAdvanceMapdata)
		{
			bDisbaleColor = this.bRequsetAdvanceMapdata;
		}
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[_MapPointID];
		bool flag = DataManager.MapDataController.IsEnemy(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomID);
		if ((int)mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
		{
			ushort portraitID = DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].portraitID;
			if (!bDisbaleColor)
			{
				if (portraitID >= 1 && portraitID <= 100)
				{
					GUIManager.Instance.ChangeHeroItemImg(this.m_CampHiBtn.transform, eHeroOrItem.Hero, portraitID, 11, 0, 0);
				}
				else
				{
					GUIManager.Instance.ChangeHeroItemImg(this.m_CampHiBtn.transform, eHeroOrItem.Hero, 1, 11, 0, 0);
				}
				this.m_CampHiBtn.gameObject.SetActive(true);
			}
			else
			{
				this.m_CampHiBtn.gameObject.SetActive(false);
			}
			if (DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomID == 0)
			{
				zero.Set(this.m_IDTextRt.anchoredPosition.x, -68.5f);
				this.m_IDTextRt.anchoredPosition = this.m_IDText.ArabicFixPos(zero);
				this.m_IDTextRt.gameObject.SetActive(true);
				this.m_CampTitleTextRt.gameObject.SetActive(false);
			}
			else
			{
				zero.Set(this.m_CampTitleTextRt.anchoredPosition.x, -61f);
				this.m_CampTitleTextRt.anchoredPosition = zero;
				zero.Set(this.m_IDTextRt.anchoredPosition.x, -63f);
				this.m_IDTextRt.anchoredPosition = this.m_IDText.ArabicFixPos(zero);
				this.m_IDTextRt.gameObject.SetActive(true);
				this.m_CampTitleTextRt.gameObject.SetActive(true);
			}
			this.m_CampTitleText.gameObject.SetActive(false);
			this.m_Str[30].ClearString();
			this.m_Str[30].IntToFormat((long)((ulong)DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].bounty), 1, true);
			this.m_Str[30].AppendFormat("{0}");
			this.m_RewardText.text = this.m_Str[30].ToString();
			this.m_RewardText.SetAllDirty();
			this.m_RewardText.cachedTextGenerator.Invalidate();
			this.m_Str[5].ClearString();
			if (flag)
			{
				if (DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag != null && DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag.Length > 0)
				{
					GameConstants.FormatRoleName(this.m_Str[5], DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName, DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag, null, 0, DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomID, null, null, null, null);
				}
				else
				{
					GameConstants.FormatRoleName(this.m_Str[5], DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName, null, null, 0, DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomID, null, null, null, null);
				}
			}
			else if (DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag != null && DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag.Length > 0)
			{
				GameConstants.FormatRoleName(this.m_Str[5], DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName, DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag, null, 0, 0, null, null, null, null);
			}
			else
			{
				StringManager.Instance.StringToFormat(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].playerName);
				this.m_Str[5].AppendFormat("{0}");
			}
			this.m_IDText.text = this.m_Str[5].ToString();
			this.m_IDText.SetAllDirty();
			this.m_IDText.cachedTextGenerator.Invalidate();
			if (DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].VIP != 0)
			{
				this.m_Str[6].ClearString();
				this.m_VipText.alignment = TextAnchor.MiddleCenter;
				this.m_VipText.color = new Color(1f, 0.941f, 0.639f);
				StringManager.Instance.IntToFormat((long)DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].VIP, 1, false);
				this.m_Str[6].AppendFormat("{0}");
				this.m_VipText.text = this.m_Str[6].ToString();
				this.m_VipTf.gameObject.SetActive(true);
			}
			else
			{
				this.m_VipTf.gameObject.SetActive(false);
			}
			if (DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceRank != 0)
			{
				byte allianceRank = DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceRank;
				this.m_RankImage.sprite = this.m_SpriteArray.GetSprite((int)(5 + allianceRank));
				this.m_RankTf.gameObject.SetActive(true);
			}
			else
			{
				this.m_RankTf.gameObject.SetActive(false);
			}
			this.SetTitleIcon();
			this.m_Str[0].ClearString();
			StringManager.Instance.uLongToFormat(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].power, 1, true);
			this.m_Str[0].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4541u));
			this.m_StrengthText.text = this.m_Str[0].ToString();
			this.m_Str[1].ClearString();
			StringManager.Instance.uLongToFormat(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kill, 1, true);
			this.m_Str[1].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4542u));
			this.m_WipeOutText.text = this.m_Str[1].ToString();
			this.m_Str[2].ClearString();
			if (DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag.Length == 0)
			{
				StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(245u));
				this.m_Str[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4600u));
			}
			else
			{
				CString cstring = StringManager.Instance.StaticString1024();
				CString cstring2 = StringManager.Instance.StaticString1024();
				CString cstring3 = StringManager.Instance.StaticString1024();
				if (DataManager.Instance.RoleAlliance.KingdomID == DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceKingdomID)
				{
					if (GUIManager.Instance.IsArabic)
					{
						cstring2.Append(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceName);
						cstring3.Append(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag);
						GUIManager.Instance.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, GUIManager.Instance.IsArabic);
						this.m_Str[2].StringToFormat(cstring);
						this.m_Str[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4543u));
					}
					else
					{
						StringManager.Instance.StringToFormat(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag);
						StringManager.Instance.StringToFormat(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceName);
						this.m_Str[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4543u));
					}
				}
				else if (GUIManager.Instance.IsArabic)
				{
					cstring2.Append(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceName);
					cstring3.Append(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag);
					GUIManager.Instance.FormatRoleNameForChat(cstring, cstring2, cstring3, DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceKingdomID, GUIManager.Instance.IsArabic);
					this.m_Str[2].StringToFormat(cstring);
					this.m_Str[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9904u));
				}
				else
				{
					this.m_Str[2].IntToFormat((long)DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceKingdomID, 1, false);
					this.m_Str[2].StringToFormat(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceTag);
					this.m_Str[2].StringToFormat(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceName);
					this.m_Str[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9904u));
				}
			}
			this.m_LeagueText.text = this.m_Str[2].ToString();
			this.m_Str[3].ClearString();
			if (DataManager.MapDataController.kingdomData.kingdomID == DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomID)
			{
				DataManager.MapDataController.GetKingdomName(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomID, ref this.m_Str[28]);
				StringManager.Instance.StringToFormat(this.m_Str[28]);
				this.m_Str[3].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4509u));
			}
			else
			{
				DataManager.MapDataController.GetKingdomName(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomID, ref this.m_Str[28]);
				StringManager.Instance.IntToFormat((long)DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomID, 1, false);
				StringManager.Instance.StringToFormat(this.m_Str[28]);
				this.m_Str[3].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9906u));
			}
			this.m_KingdomText.text = this.m_Str[3].ToString();
			if (bDisbaleColor)
			{
				this.m_StrengthText.color = Color.gray;
				this.m_WipeOutText.color = Color.gray;
				this.m_LeagueText.color = Color.gray;
				this.m_KingdomText.color = Color.gray;
			}
			else
			{
				Color white = Color.white;
				this.m_StrengthText.color = white;
				this.m_WipeOutText.color = white;
				this.m_LeagueText.color = white;
				this.m_KingdomText.color = white;
			}
			this.m_StrengthText.SetAllDirty();
			this.m_WipeOutText.SetAllDirty();
			this.m_LeagueText.SetAllDirty();
			this.m_KingdomText.SetAllDirty();
			this.m_VipText.SetAllDirty();
			this.m_RankText.SetAllDirty();
			this.m_StrengthText.cachedTextGenerator.Invalidate();
			this.m_WipeOutText.cachedTextGenerator.Invalidate();
			this.m_LeagueText.cachedTextGenerator.Invalidate();
			this.m_KingdomText.cachedTextGenerator.Invalidate();
			this.m_VipText.cachedTextGenerator.Invalidate();
			this.m_RankText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06001230 RID: 4656 RVA: 0x002008C8 File Offset: 0x001FEAC8
	public void SetChatText(int MapPointID)
	{
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
		ushort num = 0;
		int num2 = DataManager.MapDataController.ResourcesPointTable.Length;
		if ((int)mapPoint.tableID < num2)
		{
			num = (ushort)DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].level;
		}
		this.sb.Length = 0;
		this.m_Str[15].ClearString();
		switch (DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)this.m_MapPointID))
		{
		case POINT_KIND.PK_NONE:
			if (this.m_MapPointID >= 0 && this.m_MapPointID < this.m_Door.TileMapController.TileMapInfo.Length)
			{
				byte b = this.m_Door.TileMapController.TileMapInfo[this.m_MapPointID];
			}
			this.m_Str[15].StringToFormat(this.GetPKNoneGroundTitle(this.m_MapPointID));
			this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true, false));
			this.m_Str[15].AppendFormat("{0} {1}");
			break;
		case POINT_KIND.PK_FOOD:
			this.m_Str[15].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(6306u));
			this.m_Str[15].IntToFormat((long)num, 1, false);
			this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true, false));
			this.m_Str[15].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(810u));
			break;
		case POINT_KIND.PK_STONE:
			this.m_Str[15].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(6308u));
			this.m_Str[15].IntToFormat((long)num, 1, false);
			this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true, false));
			this.m_Str[15].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(810u));
			break;
		case POINT_KIND.PK_IRON:
			this.m_Str[15].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(6307u));
			this.m_Str[15].IntToFormat((long)num, 1, false);
			this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true, false));
			this.m_Str[15].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(810u));
			break;
		case POINT_KIND.PK_WOOD:
			this.m_Str[15].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(6309u));
			this.m_Str[15].IntToFormat((long)num, 1, false);
			this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true, false));
			this.m_Str[15].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(810u));
			break;
		case POINT_KIND.PK_GOLD:
			this.m_Str[15].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(6311u));
			this.m_Str[15].IntToFormat((long)num, 1, false);
			this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true, false));
			this.m_Str[15].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(810u));
			break;
		case POINT_KIND.PK_CRYSTAL:
			this.m_Str[15].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(6310u));
			this.m_Str[15].IntToFormat((long)num, 1, false);
			this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true, false));
			this.m_Str[15].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(810u));
			break;
		case POINT_KIND.PK_CITY:
		{
			PlayerPoint playerPoint = DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID];
			if (this.IsNpcCastleType(POINT_KIND.PK_CITY, mapPoint.tableID))
			{
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.IntToFormat((long)playerPoint.level, 1, false);
				cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021u));
				this.m_Str[15].StringToFormat(cstring);
				this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, false, false));
				if (GUIManager.Instance.IsArabic)
				{
					this.m_Str[15].AppendFormat("{1} {0}");
				}
				else
				{
					this.m_Str[15].AppendFormat("{0} {1}");
				}
			}
			else if (playerPoint.allianceTag.Length != 0)
			{
				this.m_Str[15].StringToFormat(playerPoint.allianceTag);
				this.m_Str[15].StringToFormat(playerPoint.playerName);
				this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, false, false));
				if (GUIManager.Instance.IsArabic)
				{
					this.m_Str[15].AppendFormat("{2} {1}[{0}]");
				}
				else
				{
					this.m_Str[15].AppendFormat("[{0}]{1} {2}");
				}
			}
			else
			{
				this.m_Str[15].StringToFormat(playerPoint.playerName);
				this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, false, false));
				if (GUIManager.Instance.IsArabic)
				{
					this.m_Str[15].AppendFormat("{1} {0}");
				}
				else
				{
					this.m_Str[15].AppendFormat("{0} {1}");
				}
			}
			break;
		}
		case POINT_KIND.PK_CAMP:
			this.m_Str[15].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4540u));
			this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true, false));
			this.m_Str[15].AppendFormat("{0} {1}");
			break;
		case POINT_KIND.PK_YOLK:
			if ((int)mapPoint.tableID < DataManager.MapDataController.YolkPointTable.Length)
			{
				MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int)mapPoint.tableID];
				this.m_Str[15].StringToFormat(DataManager.MapDataController.GetYolkName((ushort)mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID));
				this.m_Str[15].StringToFormat(this.GetYolkLocation((ushort)mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID, true));
				this.m_Str[15].AppendFormat("{0} {1}");
			}
			break;
		}
		this.m_Door.OpenMenu(EGUIWindow.UI_Chat, (int)(GUIManager.Instance.ChannelIndex + 1), 0, false);
		UIChat uichat = (UIChat)GUIManager.Instance.FindMenu(EGUIWindow.UI_Chat);
		uichat.SetInputText(this.m_Str[15].ToString());
	}

	// Token: 0x06001231 RID: 4657 RVA: 0x00200FE8 File Offset: 0x001FF1E8
	public void Close()
	{
		if (this.delayOpenTime != 0f)
		{
			GUIManager.Instance.HideUILock(EUILock.Normal);
			this.delayOpenTime = 0f;
		}
		this.m_PreKind = POINT_KIND.PK_MAX;
		this.m_TeamPanelGameObject.SetActive(false);
		this.m_PanelGameObject.SetActive(false);
		this.m_GroundPanel.gameObject.SetActive(false);
		this.m_ResourcePanel.gameObject.SetActive(false);
		this.m_CampPanel.gameObject.SetActive(false);
		this.m_WondersPanel.gameObject.SetActive(false);
		this.m_NpcCastlePanel.gameObject.SetActive(false);
		this.OpenSearchPanel(false, false);
		this.OpenReinforcePanel(false, false, true);
		this.OpenDetectPanel(false, 0, false);
		this.OpenAttackPanel(false, false);
		this.OpenBookmarksPanel(false);
		this.OpenPvePanel(false, 1);
		this.OpenRewardPanel(false);
		this.OpenTitlePanel(false);
		DataManager.msgBuffer[0] = 77;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		this.bGroundInfoOpen = false;
		if (this.WonderTileMapMat1 != null)
		{
			UnityEngine.Object.Destroy(this.WonderTileMapMat1);
			this.WonderTileMapMat1 = null;
		}
		if (this.WonderTileMapMat2 != null)
		{
			UnityEngine.Object.Destroy(this.WonderTileMapMat2);
			this.WonderTileMapMat2 = null;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UIEmojiSelect, 3, 0);
		if (this.m_PetSkillUse)
		{
			this.m_PetSkillUse.gameObject.SetActive(false);
		}
		this.UpdatemPetNegativeBuff(this.m_MapPointID, true);
		if (this.SoccerRun_SFXKey != 255)
		{
			Debug.LogWarning("SFX Close");
			AudioManager.Instance.StopSFX(this.SoccerRun_SFXKey, false);
			this.SoccerRun_SFXKey = byte.MaxValue;
		}
		GUIManager.Instance.ClearCalculator();
	}

	// Token: 0x06001232 RID: 4658 RVA: 0x002011B4 File Offset: 0x001FF3B4
	private uint GetMaxOverload(int _MapPointID)
	{
		Vector2 tileMapPosbySpriteID = GameConstants.getTileMapPosbySpriteID(_MapPointID);
		uint result = 0u;
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
		int num = 0;
		while ((long)num < (long)((ulong)effectBaseVal))
		{
			if (DataManager.Instance.MarchEventData[num].Type == EMarchEventType.EMET_Gathering)
			{
				int num2 = GameConstants.PointCodeToMapID(DataManager.Instance.MarchEventData[num].Point.zoneID, DataManager.Instance.MarchEventData[num].Point.pointID);
				if (num2 == _MapPointID)
				{
					result = DataManager.Instance.MarchEventData[num].MaxOverLoad;
					break;
				}
			}
			num++;
		}
		return result;
	}

	// Token: 0x06001233 RID: 4659 RVA: 0x00201274 File Offset: 0x001FF474
	private int GetMarcheventIdx(int _MapPointID)
	{
		int result = 0;
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
		int num = 0;
		while ((long)num < (long)((ulong)effectBaseVal))
		{
			int num2 = GameConstants.PointCodeToMapID(DataManager.Instance.MarchEventData[num].Point.zoneID, DataManager.Instance.MarchEventData[num].Point.pointID);
			if (num2 == _MapPointID)
			{
				result = num;
				break;
			}
			num++;
		}
		return result;
	}

	// Token: 0x06001234 RID: 4660 RVA: 0x002012F4 File Offset: 0x001FF4F4
	private long GetResStartTime(int _MapPointID)
	{
		long result = 0L;
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
		if (DataManager.MapDataController.IsResources((uint)this.m_MapPointID))
		{
			result = (long)DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].time;
		}
		return result;
	}

	// Token: 0x06001235 RID: 4661 RVA: 0x00201354 File Offset: 0x001FF554
	public void UpdateResourceInfo()
	{
		this.m_TimeTick += Time.deltaTime;
		float num = 0f;
		if (this.OwnerKind < 1)
		{
			return;
		}
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
		POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)this.m_MapPointID);
		if (this.m_TimeTick >= this.m_ResTextChangeTime * 2f)
		{
			this.m_TimeTick = 0f;
			if (this.m_ResTextType == 0)
			{
				this.m_ResTextType = 1;
			}
			else
			{
				this.m_ResTextType = 0;
			}
		}
		float a;
		if (this.m_TimeTick >= this.m_ResTextChangeTime)
		{
			a = Mathf.Lerp(0f, 2f, (this.m_ResTextChangeTime * 2f - this.m_TimeTick) / this.m_ResTextChangeTime);
		}
		else
		{
			a = Mathf.Lerp(0f, 2f, this.m_TimeTick / this.m_ResTextChangeTime);
		}
		this.m_SliderText2.color = new Color(1f, 1f, 1f, a);
		if (layoutMapInfoPointKind > POINT_KIND.PK_NONE && layoutMapInfoPointKind < POINT_KIND.PK_CRYSTAL)
		{
			if (this.OwnerKind == 1)
			{
				if (NetworkManager.ServerTime >= (double)this.m_ResStartTime)
				{
					num = (uint)((NetworkManager.ServerTime - (double)this.m_ResStartTime) * (double)this.m_ResRate);
					num = (uint)Mathf.Clamp(num, 0f, this.m_MaxOverload);
					uint sec = (uint)(this.m_MaxOverload / this.m_ResRate) - (uint)(num / this.m_ResRate);
					this.m_Slider2.fillAmount = num / this.m_MaxOverload;
					this.m_Str[23].ClearString();
					this.m_Str[24].ClearString();
					if (num <= this.m_ResTotalCount)
					{
						if (this.m_ResTextType == 0)
						{
							this.m_Str[23].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4539u));
							this.m_Str[23].IntToFormat((long)((int)num), 1, true);
							this.m_Str[23].IntToFormat((long)((ulong)this.m_MaxOverload), 1, true);
							this.m_Str[23].AppendFormat("{0} {1}/{2}");
						}
						else
						{
							this.m_Str[25].ClearString();
							GameConstants.GetTimeString(this.m_Str[25], sec, false, false, true, false, true);
							this.m_Str[23].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(817u));
							this.m_Str[23].StringToFormat(this.m_Str[25]);
							this.m_Str[23].AppendFormat("{0} {1}");
						}
						uint num2 = (this.m_ResTotalCount <= (uint)num) ? 0u : (this.m_ResTotalCount - (uint)num);
						this.m_Str[24].IntToFormat((long)((ulong)num2), 1, true);
						this.m_Str[24].AppendFormat("{0}");
						this.m_SliderText2.text = this.m_Str[23].ToString();
						this.m_ResourceProductionText.text = this.m_Str[24].ToString();
						this.m_SliderText2.SetAllDirty();
						this.m_ResourceProductionText.SetAllDirty();
						this.m_SliderText2.cachedTextGenerator.Invalidate();
						this.m_ResourceProductionText.cachedTextGenerator.Invalidate();
					}
				}
				else
				{
					this.m_Str[23].ClearString();
					this.m_Str[24].ClearString();
					this.m_Slider2.fillAmount = 0f;
					this.m_Str[23].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4539u));
					this.m_Str[23].IntToFormat((long)((int)num), 1, true);
					this.m_Str[23].IntToFormat((long)((ulong)this.m_MaxOverload), 1, true);
					this.m_Str[23].AppendFormat("{0} {1}/{2}");
					this.m_SliderText2.text = this.m_Str[23].ToString();
					this.m_Str[24].IntToFormat((long)((ulong)this.m_ResTotalCount - (ulong)((long)((int)num))), 1, true);
					this.m_Str[24].AppendFormat("{0}");
					this.m_ResourceProductionText.text = this.m_Str[24].ToString();
				}
			}
			else if (num < this.m_ResTotalCount)
			{
				num = (uint)((NetworkManager.ServerTime - (double)this.m_ResStartTime) * (double)this.m_ResRate);
				this.m_Str[24].ClearString();
				uint num2 = (this.m_ResTotalCount <= (uint)num) ? 0u : (this.m_ResTotalCount - (uint)num);
				this.m_Str[24].IntToFormat((long)((ulong)num2), 1, true);
				this.m_Str[24].AppendFormat("{0}");
				this.m_ResourceProductionText.text = this.m_Str[24].ToString();
			}
		}
		else if (layoutMapInfoPointKind == POINT_KIND.PK_CRYSTAL)
		{
			if (this.m_ResRate == 0f)
			{
				return;
			}
			if (this.OwnerKind == 1)
			{
				if (NetworkManager.ServerTime >= (double)this.m_ResStartTime)
				{
					num = (float)((NetworkManager.ServerTime - (double)this.m_ResStartTime) * (double)this.m_ResRate);
					if (num >= this.m_MaxOverload)
					{
						num = this.m_MaxOverload;
					}
					uint sec = (uint)((double)(this.m_MaxOverload / this.m_ResRate) - (NetworkManager.ServerTime - (double)this.m_ResStartTime));
					if (this.m_MaxOverload <= 0u)
					{
						this.m_MaxOverload = 1u;
					}
					double num3 = this.m_MaxOverload / (double)this.m_ResRate;
					float num4 = (float)(num3 / this.m_MaxOverload);
					this.m_Slider11.fillAmount = (float)((NetworkManager.ServerTime - (double)this.m_ResStartTime) % (double)num4) / num4;
					this.m_Slider12.fillAmount = this.m_Slider11.fillAmount;
					if (num <= this.m_ResTotalCount)
					{
						this.m_Slider2.fillAmount = num / this.m_MaxOverload;
						this.m_Str[23].ClearString();
						this.m_Str[24].ClearString();
						if (this.m_ResTextType == 0)
						{
							this.m_Str[23].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(691u));
							this.m_Str[23].IntToFormat((long)((ulong)((uint)num)), 1, true);
							this.m_Str[23].IntToFormat((long)((ulong)this.m_MaxOverload), 1, true);
							this.m_Str[23].AppendFormat("{0} {1}/{2}");
						}
						else
						{
							this.m_Str[25].ClearString();
							GameConstants.GetTimeString(this.m_Str[25], sec, false, false, true, false, true);
							this.m_Str[23].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(817u));
							this.m_Str[23].StringToFormat(this.m_Str[25]);
							this.m_Str[23].AppendFormat("{0} {1}");
						}
						uint num2 = (this.m_ResTotalCount <= (uint)num) ? 0u : (this.m_ResTotalCount - (uint)num);
						this.m_Str[24].IntToFormat((long)((ulong)num2), 1, true);
						this.m_Str[24].AppendFormat("{0}");
						this.m_SliderText2.text = this.m_Str[23].ToString();
						this.m_ResourceProductionText.text = this.m_Str[24].ToString();
						this.m_SliderText2.SetAllDirty();
						this.m_ResourceProductionText.SetAllDirty();
						this.m_SliderText2.cachedTextGenerator.Invalidate();
						this.m_ResourceProductionText.cachedTextGenerator.Invalidate();
					}
				}
				else
				{
					this.m_Str[23].ClearString();
					this.m_Str[24].ClearString();
					this.m_Slider2.fillAmount = 0f;
					this.m_Str[23].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4539u));
					this.m_Str[23].IntToFormat((long)((ulong)((uint)num)), 1, true);
					this.m_Str[23].IntToFormat((long)((ulong)this.m_MaxOverload), 1, true);
					this.m_Str[23].AppendFormat("{0} {1}/{2}");
					this.m_SliderText2.text = this.m_Str[23].ToString();
					uint num2 = (this.m_ResTotalCount <= (uint)num) ? 0u : (this.m_ResTotalCount - (uint)num);
					this.m_Str[24].IntToFormat((long)((ulong)num2), 1, true);
					this.m_Str[24].AppendFormat("{0}");
					this.m_ResourceProductionText.text = this.m_Str[24].ToString();
				}
			}
			else if (num < this.m_ResTotalCount)
			{
				num = (uint)((NetworkManager.ServerTime - (double)this.m_ResStartTime) * (double)this.m_ResRate);
				this.m_Str[24].ClearString();
				uint num2 = (this.m_ResTotalCount <= (uint)num) ? 0u : (this.m_ResTotalCount - (uint)num);
				this.m_Str[24].IntToFormat((long)((ulong)num2), 1, true);
				this.m_Str[24].AppendFormat("{0}");
				this.m_ResourceProductionText.text = this.m_Str[24].ToString();
			}
		}
	}

	// Token: 0x06001236 RID: 4662 RVA: 0x00201CA4 File Offset: 0x001FFEA4
	public void SetTimeText(CString str, double time)
	{
		int num = (int)time % 60;
		int num2 = (int)(time / 60.0) % 60;
		int num3 = (int)(time % 86400.0) / 3600;
		int num4 = (int)time / 86400;
		StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4575u));
		if (num4 > 0)
		{
			StringManager.Instance.IntToFormat((long)num4, 1, false);
			StringManager.Instance.IntToFormat((long)num3, 2, false);
			StringManager.Instance.IntToFormat((long)num2, 2, false);
			StringManager.Instance.IntToFormat((long)num, 2, false);
			str.ClearString();
			str.AppendFormat("{0}{1}:{2}:{3}:{4}");
		}
		else if (num3 > 0)
		{
			StringManager.Instance.IntToFormat((long)num3, 1, false);
			StringManager.Instance.IntToFormat((long)num2, 2, false);
			StringManager.Instance.IntToFormat((long)num, 2, false);
			str.ClearString();
			str.AppendFormat("{0}{1}:{2}:{3}");
		}
		else
		{
			StringManager.Instance.IntToFormat((long)num2, 2, false);
			StringManager.Instance.IntToFormat((long)num, 2, false);
			str.ClearString();
			str.AppendFormat("{0}{1}:{2}");
		}
	}

	// Token: 0x06001237 RID: 4663 RVA: 0x00201DD4 File Offset: 0x001FFFD4
	public void UpdateTeamTime()
	{
		if (this.m_MapPointID < DataManager.MapDataController.MapLineTable.Count)
		{
			long num = (long)(DataManager.MapDataController.MapLineTable[this.m_MapPointID].begin + (ulong)DataManager.MapDataController.MapLineTable[this.m_MapPointID].during);
			double num2 = (double)(num - DataManager.Instance.ServerTime);
			if (num2 >= 0.0)
			{
				this.SetTimeText(this.m_Str[12], num2);
				this.m_TimeText.text = this.m_Str[12].ToString();
				this.m_TimeText.SetAllDirty();
				this.m_TimeText.cachedTextGenerator.Invalidate();
			}
			if (this.OwnerKind == 1 && !this.m_TeamSpeedBtnGameObject.activeSelf && this.IsAttackActionLineFlag(DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag))
			{
				long num3 = DataManager.Instance.ServerTime - (long)DataManager.MapDataController.MapLineTable[this.m_MapPointID].begin;
				if (num3 > 5L)
				{
					this.m_TeamSpeedBtnGameObject.SetActive(true);
					this.SetExpressionButton(this.OwnerKind, POINT_KIND.PK_UNDEFINED);
				}
			}
		}
		else
		{
			this.Close();
		}
	}

	// Token: 0x06001238 RID: 4664 RVA: 0x00201F28 File Offset: 0x00200128
	public void SetTempLocation(CString str)
	{
		Vector2 zero = Vector2.zero;
		if (this.m_MapPointID >= DataManager.MapDataController.MapLineTable.Count)
		{
			return;
		}
		if (str == null)
		{
			return;
		}
		PointCode end = DataManager.MapDataController.MapLineTable[this.m_MapPointID].end;
		int num = GameConstants.PointCodeToMapID(end.zoneID, end.pointID);
		Vector2 vector = Vector2.zero;
		if (DataManager.MapDataController.LayoutMapInfo[num].pointKind == 11 && DataManager.MapDataController.LayoutMapInfo[num].tableID < 40)
		{
			vector = DataManager.MapDataController.GetYolkPos(DataManager.MapDataController.LayoutMapInfo[num].tableID, DataManager.MapDataController.FocusKingdomID);
		}
		else
		{
			vector = GameConstants.getTileMapPosbyMapID(num);
		}
		str.ClearString();
		StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4505u));
		StringManager.Instance.IntToFormat((long)((int)vector.x), 1, false);
		StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4506u));
		StringManager.Instance.IntToFormat((long)((int)vector.y), 1, false);
		if (GUIManager.Instance.IsArabic)
		{
			str.AppendFormat("{3}{2} {1}{0}");
		}
		else
		{
			str.AppendFormat("{0}{1} {2}{3}");
		}
		this.m_TeamLocText.text = this.m_Str[11].ToString();
		this.m_TeamLocText.SetAllDirty();
		this.m_TeamLocText.cachedTextGenerator.Invalidate();
		this.m_TeamLocText.cachedTextGeneratorForLayout.Invalidate();
		this.m_TeamLocLine.rectTransform.sizeDelta = new Vector2(this.m_TeamLocText.preferredWidth, this.m_TeamLocLine.rectTransform.sizeDelta.y);
		this.m_TeamLocLine.enabled = true;
		zero.Set(this.m_TeamTargetText.preferredWidth, this.m_TeamTargetText.rectTransform.sizeDelta.y);
		this.m_TeamTargetText.rectTransform.sizeDelta = zero;
		float num2 = 10f;
		float num3 = (314f - this.m_TeamTargetText.preferredWidth - this.m_TeamLocText.preferredWidth - num2) / 2f;
		zero.Set(num3, this.m_TeamTargetText.rectTransform.anchoredPosition.y);
		this.m_TeamTargetText.rectTransform.anchoredPosition = zero;
		RectTransform component = this.m_TeamLocBtn.gameObject.GetComponent<RectTransform>();
		zero.Set(num3 + num2 + this.m_TeamTargetText.preferredWidth, component.anchoredPosition.y);
		component.anchoredPosition = zero;
	}

	// Token: 0x06001239 RID: 4665 RVA: 0x00202204 File Offset: 0x00200404
	public void RequsetAdvanceMapdata(int MapPointID)
	{
		this.bRequsetAdvanceMapdata = true;
		this.m_RequsetMapID = MapPointID;
		this.m_RequsetTick = 0f;
		DataManager.MapDataController.RequsetAdvanceMapdata(this.m_MapPointID);
	}

	// Token: 0x0600123A RID: 4666 RVA: 0x00202230 File Offset: 0x00200430
	public void CheckMapInfoID(int mapInfoID)
	{
		if (this.m_PanelGameObject.activeSelf && this.bRequsetAdvanceMapdata && this.m_MapPointID == mapInfoID)
		{
			this.bRequsetAdvanceMapdata = false;
			this.m_RequsetMapID = -1;
			this.m_RequsetTick = 0f;
		}
	}

	// Token: 0x0600123B RID: 4667 RVA: 0x00202280 File Offset: 0x00200480
	public void Run()
	{
		if (this.m_eGroundInfoKind == EGroundInfoKind.Resource)
		{
			this.UpdateResourceInfo();
		}
		if (this.m_eGroundInfoKind == EGroundInfoKind.Team)
		{
			this.UpdateTeamTime();
		}
		if (this.m_eGroundInfoKind == EGroundInfoKind.Wonder)
		{
			this.SetWonderTimeInfo(this.m_MapPointID);
		}
		if (this.m_eGroundInfoKind == EGroundInfoKind.NpcCastle)
		{
			this.SetNpcCastleTimeInfo();
		}
		if (this.m_PanelGameObject.activeSelf && this.bRequsetAdvanceMapdata)
		{
			this.m_RequsetTick += Time.deltaTime;
			if (this.m_RequsetTick >= 3f)
			{
				this.RequsetAdvanceMapdata(this.m_RequsetMapID);
				this.m_RequsetTick = 0f;
			}
		}
		if (this.delayOpenTime != 0f)
		{
			this.delayOpenTime -= Time.deltaTime;
			if (this.delayOpenTime <= 0f)
			{
				GUIManager.Instance.HideUILock(EUILock.Normal);
				this.delayOpenTime = 0f;
				this.Open(this.delayMapInfoID, this.delayInfoKind);
			}
		}
	}

	// Token: 0x0600123C RID: 4668 RVA: 0x0020238C File Offset: 0x0020058C
	public void delayOpen(int mapInfoID, POINT_KIND infoKind = POINT_KIND.PK_MAX)
	{
		if (this.delayOpenTime == 0f)
		{
			GUIManager.Instance.ShowUILock(EUILock.Normal);
		}
		this.delayOpenTime = 0.2f;
		this.delayMapInfoID = mapInfoID;
		this.delayInfoKind = infoKind;
	}

	// Token: 0x0600123D RID: 4669 RVA: 0x002023C4 File Offset: 0x002005C4
	public void SetButtonColor(POINT_KIND kind, bool bLocalKindom)
	{
		ColorBlock colors = default(ColorBlock);
		Color color = new Color(1f, 1f, 1f);
		Color color2 = new Color(0.5f, 0.5f, 0.5f);
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
		PlayerPoint playerPoint = DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID];
		bool flag = DataManager.Instance.IsSameAlliance(playerPoint.allianceTag);
		Color color3;
		int btnID;
		if (bLocalKindom)
		{
			color3 = color;
			colors.normalColor = color;
			btnID = 0;
		}
		else
		{
			color3 = color2;
			colors.normalColor = color2;
			btnID = 100;
		}
		for (int i = 0; i < this.m_Buttons.Length; i++)
		{
			this.m_Buttons[i].colors = colors;
			UIText component = this.m_Buttons[i].gameObject.transform.GetChild(0).GetComponent<UIText>();
			if (component)
			{
				component.color = color3;
			}
			else
			{
				Image component2 = this.m_Buttons[i].gameObject.transform.GetChild(0).GetComponent<Image>();
				component = this.m_Buttons[i].gameObject.transform.GetChild(1).GetComponent<UIText>();
				if (component2)
				{
					component2.color = color3;
				}
				if (component)
				{
					component.color = color3;
				}
			}
			this.m_Buttons[i].m_BtnID3 = btnID;
		}
		colors.normalColor = color;
		color3 = color;
		switch (kind)
		{
		case POINT_KIND.PK_NONE:
		{
			MAP_TERRAIN_KIND map_TERRAIN_KIND = MAP_TERRAIN_KIND.MTK_NONE;
			if (this.m_Door)
			{
				map_TERRAIN_KIND = this.m_Door.GetTerrain(DataManager.MapDataController.FocusKingdomID, (uint)this.m_MapPointID);
			}
			if (DataManager.Instance.IsNewbie())
			{
				int num = (DataManager.Instance.GetCurItemQuantity(GameConstants.NewbieTeleportItemID, 0) <= 0) ? 0 : 1;
				if (map_TERRAIN_KIND == MAP_TERRAIN_KIND.MTK_FOREST)
				{
					this.m_Buttons[1].colors = colors;
					this.m_Buttons[1].m_BtnID3 = 0;
					UIText component = this.m_Buttons[1].gameObject.transform.GetChild(0).GetComponent<UIText>();
					if (component)
					{
						component.color = color3;
					}
					this.m_Buttons[2].colors = colors;
					component = this.m_Buttons[2].gameObject.transform.GetChild(0).GetComponent<UIText>();
					this.SetTransBtnState(this.m_Buttons[2]);
				}
				else
				{
					this.m_Buttons[1].colors = colors;
					UIText component = this.m_Buttons[1].gameObject.transform.GetChild(0).GetComponent<UIText>();
					this.SetTransBtnState(this.m_Buttons[1]);
				}
			}
			else
			{
				if (bLocalKindom)
				{
					int num2 = (DataManager.Instance.GetCurItemQuantity(GameConstants.AdvanceTeleportItemID, 0) <= 0) ? 0 : 1;
				}
				else
				{
					int num3 = (DataManager.Instance.GetCurItemQuantity(GameConstants.WorldTeleportItemID, 0) <= 0) ? 0 : 1;
				}
				if (map_TERRAIN_KIND == MAP_TERRAIN_KIND.MTK_FOREST)
				{
					this.m_Buttons[1].colors = colors;
					this.m_Buttons[1].m_BtnID3 = 0;
					UIText component = this.m_Buttons[1].gameObject.transform.GetChild(0).GetComponent<UIText>();
					if (component)
					{
						component.color = color3;
					}
					this.m_Buttons[2].colors = colors;
					component = this.m_Buttons[2].gameObject.transform.GetChild(0).GetComponent<UIText>();
					this.SetTransBtnState(this.m_Buttons[2]);
				}
				else
				{
					this.m_Buttons[1].colors = colors;
					UIText component = this.m_Buttons[1].gameObject.transform.GetChild(0).GetComponent<UIText>();
					this.SetTransBtnState(this.m_Buttons[1]);
				}
			}
			break;
		}
		case POINT_KIND.PK_FOOD:
		case POINT_KIND.PK_STONE:
		case POINT_KIND.PK_IRON:
		case POINT_KIND.PK_WOOD:
		case POINT_KIND.PK_GOLD:
		case POINT_KIND.PK_CRYSTAL:
			if (this.OwnerKind != 0)
			{
				this.m_Buttons[0].colors = colors;
				this.m_Buttons[0].m_BtnID3 = 0;
				UIText component = this.m_Buttons[0].gameObject.transform.GetChild(0).GetComponent<UIText>();
				if (component)
				{
					component.color = color3;
				}
			}
			break;
		case POINT_KIND.PK_CITY:
			if (this.OwnerKind == 3)
			{
				this.m_Buttons[5].colors = colors;
				this.m_Buttons[5].m_BtnID3 = 0;
				UIText component = this.m_Buttons[5].gameObject.transform.GetChild(0).GetComponent<UIText>();
				if (component)
				{
					component.color = color3;
				}
			}
			else if (this.OwnerKind != 1)
			{
				if (this.bHaveAlly_Self && this.bHaveAlly && flag)
				{
					this.m_Buttons[0].colors = colors;
					this.m_Buttons[0].m_BtnID3 = 0;
					UIText component = this.m_Buttons[0].gameObject.transform.GetChild(0).GetComponent<UIText>();
					if (component)
					{
						component.color = color3;
					}
				}
				else
				{
					this.m_Buttons[1].colors = colors;
					this.m_Buttons[1].m_BtnID3 = 0;
					UIText component = this.m_Buttons[1].gameObject.transform.GetChild(0).GetComponent<UIText>();
					if (component)
					{
						component.color = color3;
					}
				}
			}
			break;
		case POINT_KIND.PK_CAMP:
		{
			this.m_Buttons[0].colors = colors;
			this.m_Buttons[0].m_BtnID3 = 0;
			UIText component = this.m_Buttons[0].gameObject.transform.GetChild(0).GetComponent<UIText>();
			if (component)
			{
				component.color = color3;
			}
			break;
		}
		case POINT_KIND.PK_YOLK:
			if ((int)mapPoint.tableID < DataManager.MapDataController.YolkPointTable.Length)
			{
				MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int)mapPoint.tableID];
				if (mapYolk.WonderState == 0 || this.OwnerKind == 4)
				{
					this.m_Buttons[0].colors = colors;
					this.m_Buttons[0].m_BtnID3 = 0;
					UIText component = this.m_Buttons[0].gameObject.transform.GetChild(0).GetComponent<UIText>();
					if (component)
					{
						component.color = color3;
					}
				}
				else
				{
					this.m_Buttons[1].colors = colors;
					this.m_Buttons[1].m_BtnID3 = 0;
					UIText component = this.m_Buttons[1].gameObject.transform.GetChild(0).GetComponent<UIText>();
					if (component)
					{
						component.color = color3;
					}
				}
			}
			break;
		}
	}

	// Token: 0x0600123E RID: 4670 RVA: 0x00202AD4 File Offset: 0x00200CD4
	public void SetTransBtnState(UIButton btn)
	{
		Color color = new Color(1f, 1f, 1f);
		Color color2 = new Color(0.5f, 0.5f, 0.5f);
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
		UIText component = btn.gameObject.transform.GetChild(0).GetComponent<UIText>();
		if (component == null)
		{
			return;
		}
		bool flag = DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.kingdomData.kingdomID;
		bool bIsNewbie = DataManager.Instance.IsNewbie();
		bool flag2 = DataManager.Instance.CheckMoveingKingdom();
		bool bIsKvk = this.IsInKvk(false);
		bool flag3 = this.IsInKvkSelf();
		bool flag4 = this.IsInWorldWarSelf();
		bool bHaveItem = this.HaveTransItem(bIsNewbie, bIsKvk, flag3, flag);
		bool flag5 = ActivityManager.Instance.CheckIsMatchKingdom(DataManager.MapDataController.FocusKingdomID);
		bool flag6 = (int)mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length && DataManager.MapDataController.IsEnemy(DataManager.MapDataController.FocusKingdomID);
		bool flag7 = flag2 && this.IsWorldTeleport(bIsNewbie, bIsKvk, flag3, flag);
		if (DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
		{
			btn.m_BtnID3 = 0;
			component.color = color;
		}
		else if (DataManager.Instance.bHaveWarBuff && !flag7)
		{
			btn.m_BtnID3 = 104;
		}
		else if (flag4)
		{
			if (ActivityManager.Instance.IsKOWRunning(false))
			{
				btn.m_BtnID3 = this.CheckWorldWarTranstion(flag2, ref component);
			}
			else if (ActivityManager.Instance.IsNobilityWarRunning(false))
			{
				btn.m_BtnID3 = this.CheckNoboilityBattle(ref component);
			}
			else
			{
				btn.m_BtnID3 = 106;
				component.color = color2;
			}
		}
		else
		{
			btn.m_BtnID3 = this.CheckOtherTranstion(flag2, bIsKvk, flag3, flag6, bHaveItem, bIsNewbie, ref component);
		}
		if (flag6 && flag3 && !flag4)
		{
			if (DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
			{
				component.text = DataManager.Instance.mStringTable.GetStringByID(4512u);
			}
			else
			{
				component.text = DataManager.Instance.mStringTable.GetStringByID(974u);
			}
		}
		else if (flag4)
		{
			if (DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
			{
				component.text = DataManager.Instance.mStringTable.GetStringByID(4512u);
			}
			else
			{
				component.text = DataManager.Instance.mStringTable.GetStringByID(974u);
			}
		}
		else if (!flag)
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(949u);
		}
		else
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(4512u);
		}
	}

	// Token: 0x0600123F RID: 4671 RVA: 0x00202DFC File Offset: 0x00200FFC
	public bool HaveTransItem(bool bIsNewbie, bool bIsKvk, bool bIsInKvkSelf, bool bIsInMyKindom)
	{
		bool flag = this.IsInWorldWarSelf();
		bool result;
		if (bIsNewbie)
		{
			result = (DataManager.Instance.GetCurItemQuantity(GameConstants.NewbieTeleportItemID, 0) > 0);
		}
		else if (bIsKvk && bIsInKvkSelf)
		{
			result = (DataManager.Instance.GetCurItemQuantity(GameConstants.AdvanceTeleportItemID, 0) > 0);
		}
		else if (flag)
		{
			result = (DataManager.Instance.GetCurItemQuantity(GameConstants.WorldWarTeleportItemID, 0) > 0);
		}
		else
		{
			result = (!bIsInMyKindom || true);
		}
		return result;
	}

	// Token: 0x06001240 RID: 4672 RVA: 0x00202EA4 File Offset: 0x002010A4
	private int CheckWorldWarTranstion(bool bCheckMove, ref UIText text)
	{
		Color color = new Color(1f, 1f, 1f);
		Color color2 = new Color(0.5f, 0.5f, 0.5f);
		int result;
		if (bCheckMove)
		{
			if (ActivityManager.Instance.IsKOWRunning(false))
			{
				if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 25)
				{
					result = 0;
					text.color = color;
				}
				else
				{
					result = 105;
					text.color = color2;
				}
			}
			else
			{
				result = 106;
				text.color = color2;
			}
		}
		else
		{
			result = 108;
			text.color = color2;
		}
		return result;
	}

	// Token: 0x06001241 RID: 4673 RVA: 0x00202F50 File Offset: 0x00201150
	private int CheckNoboilityBattle(ref UIText text)
	{
		Color color = new Color(1f, 1f, 1f);
		Color color2 = new Color(0.5f, 0.5f, 0.5f);
		ActivityManager instance = ActivityManager.Instance;
		bool flag = instance.FederalActKingdomWonderID == instance.FederalHomeKingdomWonderID;
		int num;
		if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 25)
		{
			if (instance.FederalActKingdomWonderID != 0)
			{
				if (instance.FederalActKingdomWonderID == instance.FederalFightingWonderID)
				{
					if (instance.FederalActKingdomWonderID == instance.FederalHomeKingdomWonderID)
					{
						num = 0;
					}
					else
					{
						num = 109;
					}
				}
				else
				{
					num = 110;
				}
			}
			else
			{
				num = 111;
			}
		}
		else
		{
			num = 105;
		}
		text.color = ((num <= 0) ? color : color2);
		return num;
	}

	// Token: 0x06001242 RID: 4674 RVA: 0x00203028 File Offset: 0x00201228
	private int CheckOtherTranstion(bool bCheckMove, bool bIsKvk, bool bIsInKvkSelf, bool bIsEnemy, bool bHaveItem, bool bIsNewbie, ref UIText text)
	{
		Color color = new Color(1f, 1f, 1f);
		Color color2 = new Color(0.5f, 0.5f, 0.5f);
		int result;
		if (bCheckMove)
		{
			result = 0;
			text.color = color;
			if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.kingdomData.kingdomID)
			{
				if (bIsKvk && bIsInKvkSelf)
				{
					if (!bIsEnemy)
					{
						text.color = color2;
						result = 107;
					}
				}
				else if ((!bIsKvk && bIsInKvkSelf) || (bIsKvk && !bIsInKvkSelf))
				{
					text.color = color2;
					result = 107;
				}
				else if (!bIsKvk && !bIsInKvkSelf && !bHaveItem)
				{
					if (bIsNewbie)
					{
						result = 101;
					}
					else
					{
						result = 102;
					}
				}
			}
		}
		else
		{
			result = 103;
		}
		return result;
	}

	// Token: 0x06001243 RID: 4675 RVA: 0x00203110 File Offset: 0x00201310
	public bool IsWorldTeleport(bool bIsNewbie, bool bIsKvk, bool bIsInKvkSelf, bool bIsInMyKindom)
	{
		bool flag = this.IsInWorldWarSelf();
		return !bIsNewbie && (!bIsKvk || !bIsInKvkSelf) && !flag && !bIsInMyKindom;
	}

	// Token: 0x06001244 RID: 4676 RVA: 0x00203144 File Offset: 0x00201344
	public void ShowCantClickMsg(int msgid = 100)
	{
		switch (msgid)
		{
		case 100:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7744u), 255, true);
			break;
		case 101:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(615u), 255, true);
			break;
		case 102:
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3782u), DataManager.Instance.mStringTable.GetStringByID(955u), null, null, 0, 0, true, false, false, false, false);
			break;
		case 103:
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3782u), DataManager.Instance.mStringTable.GetStringByID(956u), null, null, 0, 0, true, false, false, false, false);
			break;
		case 104:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9943u), 255, true);
			break;
		case 105:
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.IntToFormat(25L, 1, false);
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9167u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
			break;
		}
		case 106:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107u), 255, true);
			break;
		case 107:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(952u), 255, true);
			break;
		case 108:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(10035u), 255, true);
			break;
		case 109:
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.IntToFormat((long)ActivityManager.Instance.FederalActKingdomWonderID, 1, false);
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10066u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
			break;
		}
		case 110:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(10065u), 255, true);
			break;
		case 111:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(10064u), 255, true);
			break;
		}
	}

	// Token: 0x06001245 RID: 4677 RVA: 0x002033FC File Offset: 0x002015FC
	protected char OnValidateInput(string text, int index, char check)
	{
		int num = Encoding.UTF8.GetByteCount(text) + Encoding.UTF8.GetByteCount(check.ToString());
		if (num > (int)(DataManager.Instance.RoleBookMark.GetNameSize() - 1) || !DataManager.Instance.isNotEmojiCharacter(check))
		{
			return '\0';
		}
		return check;
	}

	// Token: 0x06001246 RID: 4678 RVA: 0x00203454 File Offset: 0x00201654
	public void OnButtonDown(UIButtonHint sender)
	{
		bool active = true;
		switch (sender.Parm1)
		{
		case 1:
		{
			this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(539u);
			Vector2 sizeDelta = this.m_HintText.rectTransform.sizeDelta;
			sizeDelta.y = this.m_HintText.preferredHeight;
			this.m_HintText.rectTransform.sizeDelta = sizeDelta;
			this.m_HintBg.rectTransform.sizeDelta = sizeDelta + new Vector2(20f, 10f);
			this.m_HintBg.rectTransform.anchoredPosition = new Vector2(51f, 143f);
			break;
		}
		case 2:
		{
			this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(540u);
			Vector2 sizeDelta2 = this.m_HintText.rectTransform.sizeDelta;
			sizeDelta2.y = this.m_HintText.preferredHeight;
			this.m_HintText.rectTransform.sizeDelta = sizeDelta2;
			this.m_HintBg.rectTransform.sizeDelta = sizeDelta2 + new Vector2(20f, 10f);
			this.m_HintBg.rectTransform.anchoredPosition = new Vector2(51f, 143f);
			break;
		}
		case 3:
		{
			this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(7347u);
			Vector2 sizeDelta3 = this.m_HintText.rectTransform.sizeDelta;
			sizeDelta3.y = this.m_HintText.preferredHeight;
			this.m_HintText.rectTransform.sizeDelta = sizeDelta3;
			this.m_HintBg.rectTransform.sizeDelta = sizeDelta3 + new Vector2(20f, 10f);
			this.m_HintBg.rectTransform.anchoredPosition = new Vector2(67f, 82f);
			break;
		}
		case 4:
		{
			this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(7348u);
			Vector2 sizeDelta4 = this.m_HintText.rectTransform.sizeDelta;
			sizeDelta4.y = this.m_HintText.preferredHeight;
			this.m_HintText.rectTransform.sizeDelta = sizeDelta4;
			this.m_HintBg.rectTransform.sizeDelta = sizeDelta4 + new Vector2(20f, 10f);
			this.m_HintBg.rectTransform.anchoredPosition = new Vector2(67f, 82f);
			break;
		}
		case 5:
		{
			this.m_Str[46].ClearString();
			MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
			if ((int)mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
			{
				TitleData recordByKey = DataManager.Instance.TitleData.GetRecordByKey((ushort)DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomTitle);
				this.m_Str[46].StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.StringID));
				this.m_Str[46].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9370u));
				this.m_HintText.text = this.m_Str[46].ToString();
				Vector2 sizeDelta5 = this.m_HintText.rectTransform.sizeDelta;
				sizeDelta5.y = this.m_HintText.preferredHeight;
				this.m_HintText.rectTransform.sizeDelta = sizeDelta5;
				this.m_HintBg.rectTransform.sizeDelta = sizeDelta5 + new Vector2(20f, 10f);
				this.m_HintBg.rectTransform.anchoredPosition = new Vector2(51f, 143f);
			}
			break;
		}
		case 6:
		{
			MapPoint mapPoint2 = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
			if ((int)mapPoint2.tableID < DataManager.MapDataController.YolkPointTable.Length)
			{
				MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int)mapPoint2.tableID];
				if (ActivityManager.Instance.IsInKvK((DataManager.MapDataController.FocusKingdomID != 0) ? DataManager.MapDataController.FocusKingdomID : DataManager.MapDataController.OtherKingdomData.kingdomID, false))
				{
					this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(9902u);
				}
				else if (mapYolk.WonderState == 0)
				{
					this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(9399u);
				}
				else if (mapYolk.WonderState == 1)
				{
					if (DataManager.MapDataController.FocusKingdomID == ActivityManager.Instance.KOWKingdomID && mapYolk.WonderID > 0)
					{
						this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(11033u);
					}
					else if (ActivityManager.Instance.IsKOWRunning(false) && DataManager.MapDataController.FocusKingdomID == ActivityManager.Instance.KOWKingdomID)
					{
						this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(11033u);
					}
					else
					{
						this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(9397u);
					}
				}
			}
			Vector2 sizeDelta6 = this.m_HintText.rectTransform.sizeDelta;
			sizeDelta6.y = this.m_HintText.preferredHeight;
			this.m_HintText.rectTransform.sizeDelta = sizeDelta6;
			this.m_HintBg.rectTransform.sizeDelta = sizeDelta6 + new Vector2(20f, 10f);
			this.m_HintBg.rectTransform.anchoredPosition = new Vector2(79f, 135f);
			break;
		}
		case 7:
		{
			MapPoint mapPoint3 = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
			if ((int)mapPoint3.tableID < DataManager.MapDataController.YolkPointTable.Length)
			{
				MapYolk mapYolk2 = DataManager.MapDataController.YolkPointTable[(int)mapPoint3.tableID];
				if (ActivityManager.Instance.IsInKvK((DataManager.MapDataController.FocusKingdomID != 0) ? DataManager.MapDataController.FocusKingdomID : DataManager.MapDataController.OtherKingdomData.kingdomID, false))
				{
					this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(9398u);
				}
				else if (mapYolk2.WonderState == 0)
				{
					this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(9400u);
				}
				else if (mapYolk2.WonderState == 1)
				{
					if (ActivityManager.Instance.IsKOWRunning(false) && DataManager.MapDataController.FocusKingdomID == ActivityManager.Instance.KOWKingdomID)
					{
						this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(11034u);
					}
					else if (mapYolk2.WonderID > 0 && DataManager.MapDataController.FocusKingdomID == ActivityManager.Instance.KOWKingdomID)
					{
						this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(11096u);
					}
					else
					{
						this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(9398u);
					}
				}
			}
			Vector2 sizeDelta7 = this.m_HintText.rectTransform.sizeDelta;
			sizeDelta7.y = this.m_HintText.preferredHeight;
			this.m_HintText.rectTransform.sizeDelta = sizeDelta7;
			this.m_HintBg.rectTransform.sizeDelta = sizeDelta7 + new Vector2(20f, 10f);
			this.m_HintBg.rectTransform.anchoredPosition = new Vector2(79f, 135f);
			break;
		}
		case 8:
			this.m_Str[46].ClearString();
			if (this.m_MapPointID >= 0 && this.m_MapPointID < DataManager.MapDataController.LayoutMapInfo.Length)
			{
				MapPoint mapPoint4 = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
				if ((int)mapPoint4.tableID < DataManager.MapDataController.PlayerPointTable.Length)
				{
					TitleData recordByKey2 = DataManager.Instance.TitleDataW.GetRecordByKey((ushort)DataManager.MapDataController.PlayerPointTable[(int)mapPoint4.tableID].worldTitle);
					this.m_Str[46].StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey2.StringID));
					this.m_Str[46].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11032u));
					this.m_HintText.text = this.m_Str[46].ToString();
					Vector2 sizeDelta8 = this.m_HintText.rectTransform.sizeDelta;
					sizeDelta8.y = this.m_HintText.preferredHeight;
					this.m_HintText.rectTransform.sizeDelta = sizeDelta8;
					this.m_HintBg.rectTransform.sizeDelta = sizeDelta8 + new Vector2(20f, 10f);
					this.m_HintBg.rectTransform.anchoredPosition = new Vector2(51f, 143f);
				}
			}
			break;
		case 9:
		{
			this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(12023u);
			Vector2 sizeDelta9 = this.m_HintText.rectTransform.sizeDelta;
			sizeDelta9.y = this.m_HintText.preferredHeight;
			this.m_HintBg.rectTransform.sizeDelta = sizeDelta9 + new Vector2(20f, 10f);
			this.m_HintBg.rectTransform.anchoredPosition = new Vector2(51f, 143f);
			break;
		}
		case 10:
		{
			this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(12020u);
			Vector2 sizeDelta10 = this.m_HintText.rectTransform.sizeDelta;
			sizeDelta10.y = this.m_HintText.preferredHeight;
			this.m_HintBg.rectTransform.sizeDelta = sizeDelta10 + new Vector2(20f, 10f);
			this.m_HintBg.rectTransform.anchoredPosition = new Vector2(51f, 143f);
			break;
		}
		case 11:
			active = false;
			if (this.m_MapPointID >= 0 && this.m_MapPointID < DataManager.MapDataController.LayoutMapInfo.Length)
			{
				POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)this.m_MapPointID);
				MapPoint mapPoint5 = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
				if ((int)mapPoint5.tableID < DataManager.MapDataController.PlayerPointTable.Length && layoutMapInfoPointKind == POINT_KIND.PK_CITY && !this.IsNpcCastleType(POINT_KIND.PK_CITY, mapPoint5.tableID))
				{
					bool flag = DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && DataManager.MapDataController.IsEnemy(DataManager.MapDataController.PlayerPointTable[(int)mapPoint5.tableID].kingdomID);
					if (flag)
					{
						return;
					}
					byte cityOutward = (byte)DataManager.MapDataController.PlayerPointTable[(int)mapPoint5.tableID].cityOutward;
					this.m_Str[46].ClearString();
					this.m_Str[46].StringToFormat(GUIManager.Instance.BuildingData.castleSkin.GetCastleSkinName(cityOutward));
					this.m_Str[46].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9690u));
					this.m_HintText.text = this.m_Str[46].ToString();
					Vector2 sizeDelta11 = this.m_HintText.rectTransform.sizeDelta;
					sizeDelta11.y = this.m_HintText.preferredHeight;
					this.m_HintBg.rectTransform.sizeDelta = sizeDelta11 + new Vector2(20f, 10f);
					this.m_HintBg.rectTransform.anchoredPosition = new Vector2(51f, 143f);
					active = true;
				}
			}
			break;
		case 12:
			this.m_Str[46].ClearString();
			if (this.m_MapPointID >= 0 && this.m_MapPointID < DataManager.MapDataController.LayoutMapInfo.Length)
			{
				MapPoint mapPoint6 = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
				if ((int)mapPoint6.tableID < DataManager.MapDataController.PlayerPointTable.Length)
				{
					TitleData recordByKey3 = DataManager.Instance.TitleDataF.GetRecordByKey((ushort)DataManager.MapDataController.PlayerPointTable[(int)mapPoint6.tableID].nobilityTitle);
					this.m_Str[46].StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey3.StringID));
					this.m_Str[46].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11152u));
					this.m_HintText.text = this.m_Str[46].ToString();
					Vector2 sizeDelta12 = this.m_HintText.rectTransform.sizeDelta;
					sizeDelta12.y = this.m_HintText.preferredHeight;
					this.m_HintText.rectTransform.sizeDelta = sizeDelta12;
					this.m_HintBg.rectTransform.sizeDelta = sizeDelta12 + new Vector2(20f, 10f);
					this.m_HintBg.rectTransform.anchoredPosition = new Vector2(51f, 143f);
				}
			}
			break;
		case 13:
		{
			this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(14583u);
			Vector2 sizeDelta13 = this.m_HintText.rectTransform.sizeDelta;
			sizeDelta13.y = this.m_HintText.preferredHeight;
			this.m_HintText.rectTransform.sizeDelta = sizeDelta13;
			this.m_HintBg.rectTransform.sizeDelta = sizeDelta13 + new Vector2(20f, 10f);
			this.m_HintBg.rectTransform.anchoredPosition = new Vector2(88f, -35f);
			break;
		}
		case 14:
		{
			Vector2 upsetPos;
			if (sender.Parm2 >= 0 && sender.Parm2 < 4)
			{
				upsetPos = new Vector2(-5f, 0f);
			}
			else
			{
				upsetPos = new Vector2(-53f, 0f);
			}
			ushort stateSkillIDByIndex = DataManager.MapDataController.getStateSkillIDByIndex(1, sender.Parm2);
			byte stateSkillLevelByIndex = DataManager.MapDataController.getStateSkillLevelByIndex(1, sender.Parm2);
			GUIManager.Instance.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.State, 0, stateSkillIDByIndex, stateSkillLevelByIndex, upsetPos, UIButtonHint.ePosition.LeftSide);
			return;
		}
		}
		this.m_HintPanel.gameObject.SetActive(active);
	}

	// Token: 0x06001247 RID: 4679 RVA: 0x002043B0 File Offset: 0x002025B0
	public void OnButtonUp(UIButtonHint sender)
	{
		this.m_HintPanel.gameObject.SetActive(false);
		GUIManager.Instance.m_Hint.Hide(true);
	}

	// Token: 0x06001248 RID: 4680 RVA: 0x002043D4 File Offset: 0x002025D4
	public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS = null)
	{
		if (this.m_SearchInput == 0)
		{
			this.m_Str[32].ClearString();
			this.m_Str[32].IntToFormat(mValue, 1, false);
			this.m_Str[32].AppendFormat("{0}");
			this.m_SearchPanel.GetChild(8).GetChild(0).GetComponent<UIText>().text = this.m_Str[32].ToString();
			this.m_SearchPanel.GetChild(8).GetChild(0).GetComponent<UIText>().SetAllDirty();
			this.m_SearchPanel.GetChild(8).GetChild(0).GetComponent<UIText>().cachedTextGenerator.Invalidate();
		}
		if (this.m_SearchInput == 1)
		{
			this.m_Str[33].ClearString();
			this.m_Str[33].IntToFormat(mValue, 1, false);
			this.m_Str[33].AppendFormat("{0}");
			this.m_SearchPanel.GetChild(9).GetChild(0).GetComponent<UIText>().text = this.m_Str[33].ToString();
			this.m_SearchPanel.GetChild(9).GetChild(0).GetComponent<UIText>().SetAllDirty();
			this.m_SearchPanel.GetChild(9).GetChild(0).GetComponent<UIText>().cachedTextGenerator.Invalidate();
		}
		if (this.m_SearchInput == 2)
		{
			this.m_Str[34].ClearString();
			this.m_Str[34].IntToFormat(mValue, 1, false);
			this.m_Str[34].AppendFormat("{0}");
			this.m_SearchPanel.GetChild(10).GetChild(0).GetComponent<Text>().text = this.m_Str[34].ToString();
			this.m_SearchPanel.GetChild(10).GetChild(0).GetComponent<Text>().SetAllDirty();
			this.m_SearchPanel.GetChild(10).GetChild(0).GetComponent<Text>().cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06001249 RID: 4681 RVA: 0x002045D8 File Offset: 0x002027D8
	private bool IsInKvk(bool bExceptRanking = false)
	{
		if (bExceptRanking)
		{
			return ActivityManager.Instance.IsInKvK(0, true);
		}
		return ActivityManager.Instance.IsInKvK((DataManager.MapDataController.FocusKingdomID != 0) ? DataManager.MapDataController.FocusKingdomID : DataManager.MapDataController.OtherKingdomData.kingdomID, false);
	}

	// Token: 0x0600124A RID: 4682 RVA: 0x00204630 File Offset: 0x00202830
	private bool IsInKvkSelf()
	{
		return ActivityManager.Instance.IsInKvK(DataManager.MapDataController.OtherKingdomData.kingdomID, false);
	}

	// Token: 0x0600124B RID: 4683 RVA: 0x0020464C File Offset: 0x0020284C
	private bool IsInWorldWarSelf()
	{
		return DataManager.MapDataController.FocusKingdomID == ActivityManager.Instance.KOWKingdomID;
	}

	// Token: 0x0600124C RID: 4684 RVA: 0x00204664 File Offset: 0x00202864
	private void SetWonderOwnerText_WorldWar(CString str, MapYolk mapYolk)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		CString cstring3 = StringManager.Instance.StaticString1024();
		bool flag = DataManager.MapDataController.FocusKingdomID == ActivityManager.Instance.KOWKingdomID;
		if (DataManager.MapDataController.kingdomData.kingdomID == mapYolk.LeaderHomeKingdomID)
		{
			if (GUIManager.Instance.IsArabic)
			{
				cstring2.Append(mapYolk.WonderLeader);
				cstring3.Append(mapYolk.WonderAllianceTag);
				GUIManager.Instance.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, GUIManager.Instance.IsArabic);
				str.StringToFormat(cstring);
			}
			else
			{
				CString cstring4 = StringManager.Instance.StaticString1024();
				cstring4.ClearString();
				if (mapYolk.WonderAllianceTag[0] == '\0' || mapYolk.WonderAllianceTag.Length == 0)
				{
					cstring4.StringToFormat(mapYolk.WonderLeader);
					cstring4.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7007u));
				}
				else
				{
					cstring4.StringToFormat(mapYolk.WonderAllianceTag);
					cstring4.StringToFormat(mapYolk.WonderLeader);
					cstring4.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9315u));
				}
				str.StringToFormat(cstring4);
			}
			if (flag)
			{
				if (mapYolk.WonderState == 0)
				{
					if (mapYolk.WonderID == 0)
					{
						str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11036u));
					}
					else
					{
						str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11156u));
					}
				}
				else if (mapYolk.WonderState == 1)
				{
					str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11037u));
				}
			}
			else
			{
				str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7230u));
			}
		}
		else
		{
			if (GUIManager.Instance.IsArabic)
			{
				cstring2.Append(mapYolk.WonderLeader);
				cstring3.Append(mapYolk.WonderAllianceTag);
				GUIManager.Instance.FormatRoleNameForChat(cstring, cstring2, cstring3, mapYolk.LeaderHomeKingdomID, GUIManager.Instance.IsArabic);
				str.StringToFormat(cstring);
			}
			else
			{
				str.IntToFormat((long)mapYolk.LeaderHomeKingdomID, 1, false);
				str.StringToFormat(mapYolk.WonderAllianceTag);
				str.StringToFormat(mapYolk.WonderLeader);
			}
			if (flag)
			{
				if (mapYolk.WonderState == 0)
				{
					if (mapYolk.WonderID == 0)
					{
						str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11020u));
					}
					else
					{
						str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11097u));
					}
				}
				else if (mapYolk.WonderState == 1)
				{
					str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11021u));
				}
			}
			else
			{
				str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9905u));
			}
		}
	}

	// Token: 0x0600124D RID: 4685 RVA: 0x00204988 File Offset: 0x00202B88
	private void SetTitleIcon(MapPoint nowMapPoint)
	{
		byte b = 0;
		if ((int)nowMapPoint.tableID >= DataManager.MapDataController.PlayerPointTable.Length || nowMapPoint.tableID < 0)
		{
			return;
		}
		WORLD_PLAYER_DESIGNATION worldTitle = DataManager.MapDataController.PlayerPointTable[(int)nowMapPoint.tableID].worldTitle;
		KINGDOM_DESIGNATION kingdomTitle = DataManager.MapDataController.PlayerPointTable[(int)nowMapPoint.tableID].kingdomTitle;
		if (worldTitle != WORLD_PLAYER_DESIGNATION.WKD_NULL)
		{
			this.m_WorldTitleIcon.gameObject.SetActive(true);
			TitleData recordByKey = DataManager.Instance.TitleDataW.GetRecordByKey((ushort)worldTitle);
			this.m_WorldTitleIcon.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.WorldTitle);
			this.m_WorldTitleIcon.material = GUIManager.Instance.GetTitleMaterial();
			b += 1;
		}
		else
		{
			this.m_WorldTitleIcon.gameObject.SetActive(false);
		}
		if (kingdomTitle != KINGDOM_DESIGNATION.KD_NONE)
		{
			this.m_TitleIcon.gameObject.SetActive(true);
			TitleData recordByKey = DataManager.Instance.TitleData.GetRecordByKey((ushort)DataManager.MapDataController.PlayerPointTable[(int)nowMapPoint.tableID].kingdomTitle);
			this.m_TitleIcon.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.KvkTitle);
			this.m_TitleIcon.material = GUIManager.Instance.GetTitleMaterial();
			b += 2;
		}
		else
		{
			this.m_TitleIcon.gameObject.SetActive(false);
		}
		if (b == 0)
		{
			Vector2 vector = this.m_IDText.rectTransform.anchoredPosition;
			vector.x = 138f;
			this.m_IDTextRt.anchoredPosition = this.m_IDText.ArabicFixPos(vector);
		}
		else
		{
			switch (b)
			{
			case 1:
			{
				Vector2 vector = this.m_WorldTitleIcon.rectTransform.anchoredPosition;
				vector.x = 149.5f;
				this.m_WorldTitleIcon.rectTransform.anchoredPosition = vector;
				vector = this.m_IDText.rectTransform.anchoredPosition;
				vector.x = 174f;
				this.m_IDTextRt.anchoredPosition = this.m_IDText.ArabicFixPos(vector);
				vector = this.m_IDText.rectTransform.sizeDelta;
				vector.x = 227f;
				this.m_IDTextRt.sizeDelta = vector;
				this.m_IDText.UpdateArabicPos();
				break;
			}
			case 2:
			{
				Vector2 vector = this.m_TitleIcon.rectTransform.anchoredPosition;
				vector.x = 149.5f;
				this.m_TitleIcon.rectTransform.anchoredPosition = vector;
				vector = this.m_IDText.rectTransform.anchoredPosition;
				vector.x = 174f;
				this.m_IDTextRt.anchoredPosition = this.m_IDText.ArabicFixPos(vector);
				vector = this.m_IDText.rectTransform.sizeDelta;
				vector.x = 227f;
				this.m_IDTextRt.sizeDelta = vector;
				this.m_IDText.UpdateArabicPos();
				break;
			}
			case 3:
			{
				Vector2 vector = this.m_WorldTitleIcon.rectTransform.anchoredPosition;
				vector.x = 149.5f;
				this.m_WorldTitleIcon.rectTransform.anchoredPosition = vector;
				vector = this.m_TitleIcon.rectTransform.anchoredPosition;
				vector.x = 195.5f;
				this.m_TitleIcon.rectTransform.anchoredPosition = vector;
				vector = this.m_IDText.rectTransform.anchoredPosition;
				vector.x = 223f;
				this.m_IDTextRt.anchoredPosition = this.m_IDText.ArabicFixPos(vector);
				vector = this.m_IDText.rectTransform.sizeDelta;
				vector.x = 178f;
				this.m_IDTextRt.sizeDelta = vector;
				this.m_IDText.UpdateArabicPos();
				break;
			}
			}
		}
	}

	// Token: 0x0600124E RID: 4686 RVA: 0x00204D58 File Offset: 0x00202F58
	private bool IsSameKingdom()
	{
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
		return (int)mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length && DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID;
	}

	// Token: 0x0600124F RID: 4687 RVA: 0x00204DB8 File Offset: 0x00202FB8
	private byte NoCommander(MapYolk mapYolk)
	{
		if (mapYolk.AllianceKingdomID == 65535)
		{
			return 0;
		}
		if (mapYolk.OwnerName == null || mapYolk.WonderLeader == null)
		{
			return 0;
		}
		if (mapYolk.OwnerName[0] == '\0' && mapYolk.WonderLeader[0] != '\0')
		{
			return 2;
		}
		return 1;
	}

	// Token: 0x06001250 RID: 4688 RVA: 0x00204E1C File Offset: 0x0020301C
	private byte ShowCanonizedBtnByTableID(ushort tableID)
	{
		if ((int)tableID >= DataManager.MapDataController.PlayerPointTable.Length || tableID < 0)
		{
			return 0;
		}
		byte b = 0;
		byte[] array = new byte[]
		{
			0,
			1,
			2,
			4
		};
		bool flag = DataManager.MapDataController.IsKing() && DataManager.MapDataController.PlayerPointTable[(int)tableID].kingdomID == DataManager.MapDataController.kingdomData.kingdomID && KINGDOM_DESIGNATION.KD_1 != DataManager.MapDataController.PlayerPointTable[(int)tableID].kingdomTitle;
		bool flag2 = DataManager.MapDataController.IsKingdomChief() && DataManager.MapDataController.PlayerPointTable[(int)tableID].kingdomID == DataManager.MapDataController.kingdomData.kingdomID && DataManager.MapDataController.PlayerPointTable[(int)tableID].kingdomTitle != KINGDOM_DESIGNATION.KD_1 && KINGDOM_DESIGNATION.KD_20 != DataManager.MapDataController.PlayerPointTable[(int)tableID].kingdomTitle;
		bool flag3 = DataManager.MapDataController.IsWorldKing() && DataManager.MapDataController.PlayerPointTable[(int)tableID].worldTitle != WORLD_PLAYER_DESIGNATION.WKD_1;
		bool flag4 = DataManager.MapDataController.IsWorldChief() && DataManager.MapDataController.PlayerPointTable[(int)tableID].worldTitle != WORLD_PLAYER_DESIGNATION.WKD_1 && DataManager.MapDataController.PlayerPointTable[(int)tableID].worldTitle != WORLD_PLAYER_DESIGNATION.WKD_14;
		bool flag5 = DataManager.MapDataController.IsNobilityKing() && DataManager.MapDataController.PlayerPointTable[(int)tableID].nobilityTitle != 1 && ActivityManager.Instance.CheckCanonizationNoility(DataManager.MapDataController.PlayerPointTable[(int)tableID].kingdomID);
		bool flag6 = DataManager.MapDataController.IsNobilityChief() && DataManager.MapDataController.PlayerPointTable[(int)tableID].nobilityTitle != 1 && DataManager.MapDataController.PlayerPointTable[(int)tableID].nobilityTitle != 14 && ActivityManager.Instance.CheckCanonizationNoility(DataManager.MapDataController.PlayerPointTable[(int)tableID].kingdomID);
		if (flag || flag2)
		{
			b += array[1];
		}
		if (flag3 || flag4)
		{
			b += array[2];
		}
		if (flag5 || flag6)
		{
			b += array[3];
		}
		return b;
	}

	// Token: 0x06001251 RID: 4689 RVA: 0x00205094 File Offset: 0x00203294
	private string GetPKNoneGroundTitle(int _MapPointID)
	{
		int num = 0;
		if (this.m_Door.TileMapController.TileMapInfoEx != null && _MapPointID >= 0 && _MapPointID < this.m_Door.TileMapController.TileMapInfoEx.Length && this.m_Door.TileMapController.TileMapInfoEx[_MapPointID] != 0)
		{
			num = (int)this.m_Door.TileMapController.TileMapInfoEx[_MapPointID];
			uint id = 0u;
			int num2 = num;
			switch (num2)
			{
			case 1:
				id = 6219u;
				break;
			case 2:
				id = 6220u;
				break;
			case 3:
				id = 6221u;
				break;
			case 4:
				id = 6222u;
				break;
			case 5:
				id = 6223u;
				break;
			case 6:
				id = 6218u;
				break;
			case 7:
				id = 6218u;
				break;
			case 8:
				id = 6218u;
				break;
			case 9:
				id = 6218u;
				break;
			default:
				switch (num2)
				{
				case 192:
					id = 6214u;
					break;
				case 193:
					id = 6215u;
					break;
				case 194:
					id = 6216u;
					break;
				case 195:
					id = 6217u;
					break;
				case 196:
					id = 6218u;
					break;
				}
				break;
			}
			return DataManager.Instance.mStringTable.GetStringByID(id);
		}
		if (_MapPointID >= 0 && _MapPointID < this.m_Door.TileMapController.TileMapInfo.Length)
		{
			num = (int)this.m_Door.TileMapController.TileMapInfo[_MapPointID];
		}
		return DataManager.Instance.mStringTable.GetStringByID((uint)(6101 + num));
	}

	// Token: 0x06001252 RID: 4690 RVA: 0x0020524C File Offset: 0x0020344C
	public bool CompareMapPointID(int id)
	{
		return id == this.m_MapPointID;
	}

	// Token: 0x06001253 RID: 4691 RVA: 0x00205258 File Offset: 0x00203458
	private CITY_PROPERTY GetCastleType(ushort tableID)
	{
		if ((int)tableID < DataManager.MapDataController.PlayerPointTable.Length)
		{
			return DataManager.MapDataController.PlayerPointTable[(int)tableID].cityProperty;
		}
		return CITY_PROPERTY.CP_PLAYER;
	}

	// Token: 0x06001254 RID: 4692 RVA: 0x00205284 File Offset: 0x00203484
	private bool IsNpcCastleType(POINT_KIND infoKind, ushort tableID)
	{
		return infoKind == POINT_KIND.PK_CITY && this.GetCastleType(tableID) == CITY_PROPERTY.CP_NPC;
	}

	// Token: 0x06001255 RID: 4693 RVA: 0x0020529C File Offset: 0x0020349C
	private void SetPlayerCastle(int MapPointID, bool bDisbaleColor = false)
	{
		Vector2 zero = Vector2.zero;
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[MapPointID];
		int num = DataManager.MapDataController.PlayerPointTable.Length;
		if ((int)mapPoint.tableID >= num)
		{
			return;
		}
		ushort capitalFlag = (ushort)DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].capitalFlag;
		ushort level = (ushort)DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].level;
		POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)MapPointID);
		this.m_eGroundInfoKind = EGroundInfoKind.Castle;
		this.m_CampPanel.gameObject.SetActive(true);
		zero.Set(416f, 441f);
		this.m_Panel.sizeDelta = zero;
		zero.Set(0f, -124f);
		this.m_Panel.anchoredPosition = zero;
		zero.Set(377f, 126f);
		this.m_GroundTextBGRect.sizeDelta = zero;
		zero.Set(20f, -94f);
		this.m_GroundTextBGRect.anchoredPosition = zero;
		zero.Set(0f, -163f);
		this.m_LocationRt.anchoredPosition = zero;
		zero.Set(0f, -185f);
		this.m_ChatBtnRt.anchoredPosition = zero;
		this.m_GroundTitle.text = string.Empty;
		bool flag = DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && DataManager.MapDataController.IsEnemy(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomID);
		this.m_Door.TileMapController.getTileMapSprite(ref this.m_BGIcon, layoutMapInfoPointKind, (int)level, (!flag) ? DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].cityOutward : CITY_OUTWARD.CO_EMEMY);
		this.m_BGIcon.rectTransform.pivot = new Vector2(0.5f + -this.m_BGIcon.sprite.bounds.center.x / this.m_BGIcon.sprite.bounds.extents.x / 2f, 0f);
		float num2 = 1f;
		RectTransform component = this.m_CityOutwardLevelTf.GetComponent<RectTransform>();
		if (this.m_BGIcon.rectTransform.localScale.x > 0f)
		{
			num2 = 1f / this.m_BGIcon.rectTransform.localScale.x;
		}
		component.localScale = new Vector3(num2, num2, num2);
		this.m_BGIcon.material = this.TileMapMat;
		this.m_BGIcon.SetNativeSize();
		this.m_BGIconMask.enabled = false;
		if (flag)
		{
			this.SetCityOutwardLevel(0);
		}
		else
		{
			this.SetCityOutwardLevel(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].cityOutwardLevel);
		}
		switch (this.OwnerKind)
		{
		case 1:
		{
			this.m_ButtonRect1.gameObject.SetActive(true);
			this.m_ButtonRect2.gameObject.SetActive(false);
			this.m_ButtonRect3.gameObject.SetActive(false);
			this.m_ButtonRect4.gameObject.SetActive(false);
			this.m_ButtonRect5.gameObject.SetActive(false);
			this.m_ButtonRect11.gameObject.SetActive(true);
			zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
			this.m_ButtonRect1.anchoredPosition = zero;
			this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4557u);
			bool flag2 = GUIManager.Instance.BuildingData.castleSkin.CheckShowCastleSkin();
			this.m_ButtonRect10.gameObject.SetActive(flag2);
			this.m_CustmCastleExclamation.gameObject.SetActive(GUIManager.Instance.BuildingData.castleSkin.CheckShowExclamation(false));
			zero.Set(this.m_ButtonRect10.anchoredPosition.x, -300f);
			this.m_ButtonRect10.anchoredPosition = zero;
			this.m_ButtonText10.text = DataManager.Instance.mStringTable.GetStringByID(9682u);
			if (flag2)
			{
				zero.Set(this.m_ButtonRect11.anchoredPosition.x, -350f);
				this.m_ButtonRect11.anchoredPosition = zero;
				this.m_ButtonText11.text = DataManager.Instance.mStringTable.GetStringByID(2760u);
			}
			else
			{
				zero.Set(this.m_ButtonRect11.anchoredPosition.x, -300f);
				this.m_ButtonRect11.anchoredPosition = zero;
				this.m_ButtonText11.text = DataManager.Instance.mStringTable.GetStringByID(2760u);
			}
			break;
		}
		case 2:
			if (this.bHaveAlly_Self)
			{
				if (this.bHaveAlly)
				{
					this.m_ButtonRect1.gameObject.SetActive(false);
					this.m_ButtonRect2.gameObject.SetActive(true);
					this.m_ButtonRect3.gameObject.SetActive(true);
					this.m_ButtonRect4.gameObject.SetActive(true);
					this.m_ButtonRect5.gameObject.SetActive(true);
					zero.Set(this.m_ButtonRect2.anchoredPosition.x, -250f);
					this.m_ButtonRect2.anchoredPosition = zero;
					this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4535u);
					zero.Set(this.m_ButtonRect3.anchoredPosition.x, -250f);
					this.m_ButtonRect3.anchoredPosition = zero;
					this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4554u);
					zero.Set(this.m_ButtonRect4.anchoredPosition.x, -309f);
					this.m_ButtonRect4.anchoredPosition = zero;
					zero.Set(this.m_ButtonRect5.anchoredPosition.x, -309f);
					this.m_ButtonRect5.anchoredPosition = zero;
				}
				else
				{
					if (DataManager.Instance.RoleAlliance.Rank >= AllianceRank.RANK4)
					{
						this.m_ButtonRect1.gameObject.SetActive(true);
						zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
						this.m_ButtonRect1.anchoredPosition = zero;
						this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4556u);
						zero.Set(this.m_ButtonRect2.anchoredPosition.x, -300f);
						this.m_ButtonRect2.anchoredPosition = zero;
						this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4535u);
						zero.Set(this.m_ButtonRect3.anchoredPosition.x, -300f);
						this.m_ButtonRect3.anchoredPosition = zero;
						this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4554u);
						zero.Set(this.m_ButtonRect4.anchoredPosition.x, -350f);
						this.m_ButtonRect4.anchoredPosition = zero;
						zero.Set(this.m_ButtonRect5.anchoredPosition.x, -350f);
						this.m_ButtonRect5.anchoredPosition = zero;
					}
					else
					{
						this.m_ButtonRect1.gameObject.SetActive(false);
						zero.Set(this.m_ButtonRect2.anchoredPosition.x, -250f);
						this.m_ButtonRect2.anchoredPosition = zero;
						this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4535u);
						zero.Set(this.m_ButtonRect3.anchoredPosition.x, -250f);
						this.m_ButtonRect3.anchoredPosition = zero;
						this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4554u);
						zero.Set(this.m_ButtonRect4.anchoredPosition.x, -309f);
						this.m_ButtonRect4.anchoredPosition = zero;
						zero.Set(this.m_ButtonRect5.anchoredPosition.x, -309f);
						this.m_ButtonRect5.anchoredPosition = zero;
					}
					this.m_ButtonRect2.gameObject.SetActive(true);
					this.m_ButtonRect3.gameObject.SetActive(true);
					this.m_ButtonRect4.gameObject.SetActive(true);
					this.m_ButtonRect5.gameObject.SetActive(true);
				}
			}
			else if (this.bHaveAlly)
			{
				this.m_ButtonRect1.gameObject.SetActive(true);
				this.m_ButtonRect2.gameObject.SetActive(true);
				this.m_ButtonRect3.gameObject.SetActive(true);
				this.m_ButtonRect4.gameObject.SetActive(true);
				this.m_ButtonRect5.gameObject.SetActive(true);
				zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
				this.m_ButtonRect1.anchoredPosition = zero;
				this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4555u);
				zero.Set(this.m_ButtonRect2.anchoredPosition.x, -300f);
				this.m_ButtonRect2.anchoredPosition = zero;
				this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4535u);
				zero.Set(this.m_ButtonRect3.anchoredPosition.x, -300f);
				this.m_ButtonRect3.anchoredPosition = zero;
				this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4554u);
				zero.Set(this.m_ButtonRect4.anchoredPosition.x, -350f);
				this.m_ButtonRect4.anchoredPosition = zero;
				zero.Set(this.m_ButtonRect5.anchoredPosition.x, -350f);
				this.m_ButtonRect5.anchoredPosition = zero;
			}
			else
			{
				this.m_ButtonRect1.gameObject.SetActive(false);
				this.m_ButtonRect2.gameObject.SetActive(true);
				this.m_ButtonRect3.gameObject.SetActive(true);
				this.m_ButtonRect4.gameObject.SetActive(true);
				this.m_ButtonRect5.gameObject.SetActive(true);
				zero.Set(this.m_ButtonRect2.anchoredPosition.x, -250f);
				this.m_ButtonRect2.anchoredPosition = zero;
				this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4535u);
				zero.Set(this.m_ButtonRect3.anchoredPosition.x, -250f);
				this.m_ButtonRect3.anchoredPosition = zero;
				this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4554u);
				zero.Set(this.m_ButtonRect4.anchoredPosition.x, -309f);
				this.m_ButtonRect4.anchoredPosition = zero;
				zero.Set(this.m_ButtonRect5.anchoredPosition.x, -309f);
				this.m_ButtonRect5.anchoredPosition = zero;
			}
			break;
		case 3:
			this.m_ButtonRect1.gameObject.SetActive(false);
			this.m_ButtonRect2.gameObject.SetActive(true);
			this.m_ButtonRect3.gameObject.SetActive(true);
			this.m_ButtonRect4.gameObject.SetActive(false);
			this.m_ButtonRect5.gameObject.SetActive(false);
			this.m_ButtonRect6.gameObject.SetActive(true);
			this.m_ButtonRect7.gameObject.SetActive(true);
			zero.Set(this.m_ButtonRect2.anchoredPosition.x, -309f);
			this.m_ButtonRect2.anchoredPosition = zero;
			this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4552u);
			zero.Set(this.m_ButtonRect3.anchoredPosition.x, -309f);
			this.m_ButtonRect3.anchoredPosition = zero;
			this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4553u);
			zero.Set(this.m_ButtonRect6.anchoredPosition.x, -250f);
			this.m_ButtonRect6.anchoredPosition = zero;
			this.m_ButtonText6.text = DataManager.Instance.mStringTable.GetStringByID(4535u);
			zero.Set(this.m_ButtonRect7.anchoredPosition.x, -250f);
			this.m_ButtonRect7.anchoredPosition = zero;
			this.m_ButtonText7.text = DataManager.Instance.mStringTable.GetStringByID(9739u);
			break;
		}
		this.SetCampInfo(this.m_MapPointID, this.OwnerKind, bDisbaleColor);
		capitalFlag = (ushort)DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].capitalFlag;
		if ((capitalFlag & 8) != 0)
		{
			this.OpenRewardPanel(true);
		}
		else
		{
			this.OpenRewardPanel(false);
		}
		if (this.ShowCanonizedBtnByTableID(mapPoint.tableID) != 0)
		{
			this.OpenTitlePanel(true);
		}
		else
		{
			this.OpenTitlePanel(false);
		}
	}

	// Token: 0x06001256 RID: 4694 RVA: 0x002060CC File Offset: 0x002042CC
	private void SetNpcCastle(int MapPointID, bool bDisbaleColor = false)
	{
		Vector2 zero = Vector2.zero;
		bool flag = DataManager.Instance.RoleAlliance.Id != 0u;
		int num = 0;
		ulong x = 0UL;
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[MapPointID];
		if ((int)mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
		{
			num = (int)DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].level;
			x = DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].power;
			if (!bDisbaleColor)
			{
				this.SetCastleIcon(DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].portraitID);
			}
		}
		POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)MapPointID);
		this.m_eGroundInfoKind = EGroundInfoKind.NpcCastle;
		this.m_Door.TileMapController.getTileMapSprite(ref this.m_BGIcon, layoutMapInfoPointKind, num, DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].cityOutward);
		this.m_BGIcon.material = this.TileMapMat;
		this.m_BGIcon.SetNativeSize();
		this.m_BGIconMask.enabled = false;
		this.m_CampPanel.gameObject.SetActive(false);
		this.m_NpcCastlePanel.gameObject.SetActive(true);
		zero.Set(416f, 441f);
		this.m_Panel.sizeDelta = zero;
		zero.Set(0f, -124f);
		this.m_Panel.anchoredPosition = zero;
		zero.Set(377f, 126f);
		this.m_GroundTextBGRect.sizeDelta = zero;
		zero.Set(20f, -94f);
		this.m_GroundTextBGRect.anchoredPosition = zero;
		zero.Set(0f, -163f);
		this.m_LocationRt.anchoredPosition = zero;
		zero.Set(0f, -185f);
		this.m_ChatBtnRt.anchoredPosition = zero;
		this.m_GroundTitle.text = string.Empty;
		this.m_Str[47].ClearString();
		this.m_Str[47].IntToFormat((long)num, 1, false);
		this.m_Str[47].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021u));
		this.m_NpcCastleIDText.text = this.m_Str[47].ToString();
		this.m_Str[48].ClearString();
		this.m_Str[48].uLongToFormat(x, 1, true);
		this.m_Str[48].AppendFormat("{0}");
		this.m_NpcCastleStrengthText.text = this.m_Str[48].ToString();
		this.m_NpcCastleInfoText.text = DataManager.Instance.mStringTable.GetStringByID(12022u);
		if (flag)
		{
			this.m_NpcCastleInfoText.enabled = true;
		}
		else
		{
			this.m_NpcCastleInfoText.enabled = false;
		}
		if (bDisbaleColor)
		{
			this.m_NpcCastleIcon.SetActive(false);
			this.m_NpcCastleStrengthText.color = Color.gray;
		}
		else
		{
			this.m_NpcCastleIcon.SetActive(true);
			this.m_NpcCastleStrengthText.color = Color.white;
		}
		if (flag)
		{
			this.SetGroundInfoBtnState(UIGroundInfo.BtnState.NpcCastle);
		}
		else
		{
			this.SetGroundInfoBtnState(UIGroundInfo.BtnState.NpcCastle_NoAllIance);
		}
	}

	// Token: 0x06001257 RID: 4695 RVA: 0x00206420 File Offset: 0x00204620
	private void SetNpcCastleTimeInfo()
	{
		if (this.m_ResStartTime != ActivityManager.Instance.NPCCityCountTime)
		{
			this.m_ResStartTime = ActivityManager.Instance.NPCCityCountTime;
			this.m_Str[25].ClearString();
			GameConstants.GetTimeString(this.m_Str[25], (uint)this.m_ResStartTime, false, true, false, false, true);
			this.m_NpcCastleTimeText.text = this.m_Str[25].ToString();
			this.m_NpcCastleTimeText.SetAllDirty();
			this.m_NpcCastleTimeText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06001258 RID: 4696 RVA: 0x002064B0 File Offset: 0x002046B0
	private void SetCastleIcon(ushort id)
	{
		if (id != 0)
		{
			this.m_NpcCastleHeadID = DataManager.Instance.HeroTable.GetRecordByKey(id).Graph;
			this.UpdateCastleIcon();
		}
	}

	// Token: 0x06001259 RID: 4697 RVA: 0x002064E8 File Offset: 0x002046E8
	public int Get0NpcCastleHeadID()
	{
		return (int)this.m_NpcCastleHeadID;
	}

	// Token: 0x0600125A RID: 4698 RVA: 0x002064F0 File Offset: 0x002046F0
	public void UpdateCastleIcon()
	{
		this.DestroyNpcCastleIcon();
		if (this.m_NpcCastleHeadID < 50000)
		{
			if (this.m_NpcCastleDLImg == null && this.m_TempNpcCastleDLImg == null)
			{
				this.m_TempNpcCastleDLImg = new GameObject("NpcCastleDLImg");
				Image image = this.m_TempNpcCastleDLImg.AddComponent<Image>();
				image.material = GUIManager.Instance.m_IconSpriteAsset.GetMaterial();
				this.m_TempNpcCastleDLImg.transform.SetParent(this.m_NpcCastleIconBone);
				RectTransform component = this.m_TempNpcCastleDLImg.GetComponent<RectTransform>();
				component.anchorMax = new Vector2(1f, 1f);
				component.anchorMin = new Vector2(0f, 0f);
				component.offsetMax = new Vector2(0f, 0f);
				component.offsetMin = new Vector2(0f, 0f);
				this.m_TempNpcCastleDLImg.transform.localPosition = new Vector3(0f, 0f, 0f);
				this.m_TempNpcCastleDLImg.transform.localScale = new Vector3(1f, 1f, 1f);
			}
			this.m_NpcCastleDLImg = this.m_TempNpcCastleDLImg;
			this.m_NpcCastleDLImg.SetActive(true);
			this.m_NpcCastleDLImg.GetComponent<Image>().sprite = GUIManager.Instance.m_IconSpriteAsset.LoadSprite(this.m_NpcCastleHeadID);
		}
		else
		{
			if (this.m_TempNpcCastleDLImg != null)
			{
				this.m_TempNpcCastleDLImg.SetActive(false);
			}
			this.m_Str[49].ClearString();
			this.m_Str[49].IntToFormat((long)this.m_NpcCastleHeadID, 1, false);
			this.m_Str[49].AppendFormat("UI/MapNPCHead_{0}");
			if (AssetManager.GetAssetBundleDownload(this.m_Str[49], AssetPath.UI, AssetType.NPCHead, this.m_NpcCastleHeadID, false))
			{
				AssetBundle assetBundle = AssetManager.GetAssetBundle(this.m_Str[49], out this.m_NpcCastleHeadAssetKey);
				if (assetBundle != null)
				{
					this.m_NpcCastleDLImg = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
					if (this.m_NpcCastleDLImg != null)
					{
						this.m_NpcCastleDLImg.transform.SetParent(this.m_NpcCastleIconBone);
						RectTransform component2 = this.m_NpcCastleDLImg.GetComponent<RectTransform>();
						component2.anchorMax = new Vector2(1f, 1f);
						component2.anchorMin = new Vector2(0f, 0f);
						component2.offsetMax = new Vector2(0f, 0f);
						component2.offsetMin = new Vector2(0f, 0f);
						this.m_NpcCastleDLImg.gameObject.SetActive(true);
						this.m_NpcCastleDLImg.transform.localPosition = new Vector3(0f, 0f, 0f);
						this.m_NpcCastleDLImg.transform.localScale = new Vector3(1f, 1f, 1f);
					}
				}
			}
		}
	}

	// Token: 0x0600125B RID: 4699 RVA: 0x002067F0 File Offset: 0x002049F0
	private void DestroyNpcCastleIcon()
	{
		if (this.m_NpcCastleHeadAssetKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.m_NpcCastleHeadAssetKey, false);
			this.m_NpcCastleHeadAssetKey = 0;
			if (this.m_NpcCastleDLImg != null)
			{
				UnityEngine.Object.Destroy(this.m_NpcCastleDLImg);
				this.m_NpcCastleDLImg = null;
			}
		}
	}

	// Token: 0x0600125C RID: 4700 RVA: 0x00206840 File Offset: 0x00204A40
	private void SetGroundInfoBtnState(UIGroundInfo.BtnState state)
	{
		Vector2 zero = Vector2.zero;
		MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[0];
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
		if ((int)mapPoint.tableID < DataManager.MapDataController.YolkPointTable.Length)
		{
			mapYolk = DataManager.MapDataController.YolkPointTable[(int)mapPoint.tableID];
		}
		bool flag = DataManager.MapDataController.FocusKingdomID == ActivityManager.Instance.KOWKingdomID;
		switch (state)
		{
		case UIGroundInfo.BtnState.WondersInfo_Ally_Peace:
			this.m_ButtonRect1.gameObject.SetActive(true);
			this.m_ButtonRect2.gameObject.SetActive(false);
			this.m_ButtonRect3.gameObject.SetActive(false);
			this.m_ButtonRect4.gameObject.SetActive(false);
			this.m_ButtonRect5.gameObject.SetActive(false);
			this.m_ButtonRect6.gameObject.SetActive(false);
			this.m_ButtonRect7.gameObject.SetActive(false);
			this.m_ButtonRect8.gameObject.SetActive(false);
			this.m_ButtonRect9.gameObject.SetActive(false);
			this.m_ButtonRect10.gameObject.SetActive(false);
			this.m_ButtonRect11.gameObject.SetActive(false);
			zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
			this.m_ButtonRect1.anchoredPosition = zero;
			if (mapYolk.WonderID == 0)
			{
				this.m_Str[41].ClearString();
				this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
				this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231u));
			}
			else
			{
				this.m_Str[41].ClearString();
				if (flag)
				{
					this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
				}
				else
				{
					this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309u));
				}
				this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231u));
			}
			this.m_ButtonText1.text = this.m_Str[41].ToString();
			this.m_ButtonText1.SetAllDirty();
			this.m_ButtonText1.cachedTextGenerator.Invalidate();
			break;
		case UIGroundInfo.BtnState.WondersInfo_Ally_Fight:
		{
			this.m_ButtonRect1.gameObject.SetActive(false);
			this.m_ButtonRect2.gameObject.SetActive(true);
			this.m_ButtonRect3.gameObject.SetActive(true);
			this.m_ButtonRect4.gameObject.SetActive(false);
			this.m_ButtonRect5.gameObject.SetActive(false);
			this.m_ButtonRect6.gameObject.SetActive(false);
			this.m_ButtonRect7.gameObject.SetActive(false);
			this.m_ButtonRect8.gameObject.SetActive(false);
			this.m_ButtonRect9.gameObject.SetActive(false);
			this.m_ButtonRect10.gameObject.SetActive(false);
			this.m_ButtonRect11.gameObject.SetActive(false);
			zero.Set(this.m_ButtonRect2.anchoredPosition.x, -250f);
			this.m_ButtonRect2.anchoredPosition = zero;
			zero.Set(this.m_ButtonRect3.anchoredPosition.x, -250f);
			this.m_ButtonRect3.anchoredPosition = zero;
			if (mapYolk.WonderID == 0)
			{
				this.m_Str[41].ClearString();
				this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
				this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231u));
			}
			else
			{
				this.m_Str[41].ClearString();
				if (flag)
				{
					this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
				}
				else
				{
					this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309u));
				}
				this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231u));
			}
			this.m_ButtonText2.text = this.m_Str[41].ToString();
			this.m_ButtonText2.SetAllDirty();
			this.m_ButtonText2.cachedTextGenerator.Invalidate();
			this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(7234u);
			byte b = this.NoCommander(mapYolk);
			if (b == 2)
			{
				this.m_ButtonRect3.gameObject.SetActive(false);
				this.m_ButtonRect9.gameObject.SetActive(true);
				zero.Set(this.m_ButtonRect9.anchoredPosition.x, -250f);
				this.m_ButtonRect9.anchoredPosition = zero;
				this.m_ButtonText9.text = DataManager.Instance.mStringTable.GetStringByID(9910u);
			}
			else if (b == 0)
			{
				this.m_ButtonRect3.gameObject.SetActive(false);
				this.m_ButtonRect9.gameObject.SetActive(false);
			}
			break;
		}
		case UIGroundInfo.BtnState.WondersInfo_NA_Peace:
			this.m_ButtonRect1.gameObject.SetActive(true);
			this.m_ButtonRect2.gameObject.SetActive(false);
			this.m_ButtonRect3.gameObject.SetActive(false);
			this.m_ButtonRect4.gameObject.SetActive(false);
			this.m_ButtonRect5.gameObject.SetActive(false);
			this.m_ButtonRect6.gameObject.SetActive(false);
			this.m_ButtonRect7.gameObject.SetActive(false);
			this.m_ButtonRect8.gameObject.SetActive(false);
			this.m_ButtonRect9.gameObject.SetActive(false);
			this.m_ButtonRect10.gameObject.SetActive(false);
			this.m_ButtonRect11.gameObject.SetActive(false);
			zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
			this.m_ButtonRect1.anchoredPosition = zero;
			if (mapYolk.WonderID == 0)
			{
				this.m_Str[41].ClearString();
				this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
				this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231u));
			}
			else
			{
				this.m_Str[41].ClearString();
				if (flag)
				{
					this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
				}
				else
				{
					this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309u));
				}
				this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231u));
			}
			this.m_ButtonText1.text = this.m_Str[41].ToString();
			this.m_ButtonText1.SetAllDirty();
			this.m_ButtonText1.cachedTextGenerator.Invalidate();
			break;
		case UIGroundInfo.BtnState.WondersInfo_NA_Fight:
			this.m_ButtonRect1.gameObject.SetActive(false);
			this.m_ButtonRect2.gameObject.SetActive(true);
			this.m_ButtonRect3.gameObject.SetActive(true);
			this.m_ButtonRect4.gameObject.SetActive(true);
			this.m_ButtonRect5.gameObject.SetActive(true);
			this.m_ButtonRect6.gameObject.SetActive(false);
			this.m_ButtonRect7.gameObject.SetActive(false);
			this.m_ButtonRect8.gameObject.SetActive(false);
			this.m_ButtonRect9.gameObject.SetActive(false);
			this.m_ButtonRect10.gameObject.SetActive(false);
			this.m_ButtonRect11.gameObject.SetActive(false);
			zero.Set(this.m_ButtonRect2.anchoredPosition.x, -250f);
			this.m_ButtonRect2.anchoredPosition = zero;
			if (mapYolk.WonderID == 0)
			{
				this.m_Str[41].ClearString();
				this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
				this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231u));
			}
			else
			{
				this.m_Str[41].ClearString();
				if (flag)
				{
					this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
				}
				else
				{
					this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309u));
				}
				this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231u));
			}
			this.m_ButtonText2.text = this.m_Str[41].ToString();
			this.m_ButtonText2.SetAllDirty();
			this.m_ButtonText2.cachedTextGenerator.Invalidate();
			zero.Set(this.m_ButtonRect3.anchoredPosition.x, -250f);
			this.m_ButtonRect3.anchoredPosition = zero;
			this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4554u);
			zero.Set(this.m_ButtonRect4.anchoredPosition.x, -309f);
			this.m_ButtonRect4.anchoredPosition = zero;
			zero.Set(this.m_ButtonRect5.anchoredPosition.x, -309f);
			this.m_ButtonRect5.anchoredPosition = zero;
			break;
		case UIGroundInfo.BtnState.WondersInfo_Army_Peace:
			this.m_ButtonRect1.gameObject.SetActive(true);
			this.m_ButtonRect2.gameObject.SetActive(false);
			this.m_ButtonRect3.gameObject.SetActive(false);
			this.m_ButtonRect4.gameObject.SetActive(false);
			this.m_ButtonRect5.gameObject.SetActive(false);
			this.m_ButtonRect6.gameObject.SetActive(false);
			this.m_ButtonRect7.gameObject.SetActive(false);
			this.m_ButtonRect8.gameObject.SetActive(false);
			this.m_ButtonRect9.gameObject.SetActive(false);
			this.m_ButtonRect10.gameObject.SetActive(false);
			this.m_ButtonRect11.gameObject.SetActive(false);
			zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
			this.m_ButtonRect1.anchoredPosition = zero;
			if (mapYolk.WonderID == 0)
			{
				this.m_Str[41].ClearString();
				this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
				this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231u));
			}
			else
			{
				this.m_Str[41].ClearString();
				if (flag)
				{
					this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
				}
				else
				{
					this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309u));
				}
				this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231u));
			}
			this.m_ButtonText1.text = this.m_Str[41].ToString();
			this.m_ButtonText1.SetAllDirty();
			this.m_ButtonText1.cachedTextGenerator.Invalidate();
			break;
		case UIGroundInfo.BtnState.WondersInfo_Army_Fight:
			this.m_ButtonRect1.gameObject.SetActive(false);
			this.m_ButtonRect2.gameObject.SetActive(true);
			this.m_ButtonRect3.gameObject.SetActive(true);
			this.m_ButtonRect4.gameObject.SetActive(false);
			this.m_ButtonRect5.gameObject.SetActive(false);
			this.m_ButtonRect6.gameObject.SetActive(false);
			this.m_ButtonRect7.gameObject.SetActive(false);
			this.m_ButtonRect8.gameObject.SetActive(false);
			this.m_ButtonRect9.gameObject.SetActive(false);
			this.m_ButtonRect10.gameObject.SetActive(false);
			this.m_ButtonRect11.gameObject.SetActive(false);
			zero.Set(this.m_ButtonRect2.anchoredPosition.x, -250f);
			this.m_ButtonRect2.anchoredPosition = zero;
			zero.Set(this.m_ButtonRect3.anchoredPosition.x, -250f);
			this.m_ButtonRect3.anchoredPosition = zero;
			if (mapYolk.WonderID == 0)
			{
				this.m_Str[41].ClearString();
				this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
				this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231u));
			}
			else
			{
				this.m_Str[41].ClearString();
				if (flag)
				{
					this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
				}
				else
				{
					this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309u));
				}
				this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231u));
			}
			this.m_ButtonText2.text = this.m_Str[41].ToString();
			this.m_ButtonText2.SetAllDirty();
			this.m_ButtonText2.cachedTextGenerator.Invalidate();
			this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(7234u);
			break;
		case UIGroundInfo.BtnState.WondersInfo_NoAllIance:
			this.m_ButtonRect1.gameObject.SetActive(true);
			this.m_ButtonRect2.gameObject.SetActive(false);
			this.m_ButtonRect3.gameObject.SetActive(false);
			this.m_ButtonRect4.gameObject.SetActive(false);
			this.m_ButtonRect5.gameObject.SetActive(false);
			this.m_ButtonRect6.gameObject.SetActive(false);
			this.m_ButtonRect7.gameObject.SetActive(false);
			this.m_ButtonRect8.gameObject.SetActive(false);
			this.m_ButtonRect9.gameObject.SetActive(false);
			this.m_ButtonRect10.gameObject.SetActive(false);
			this.m_ButtonRect11.gameObject.SetActive(false);
			zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
			this.m_ButtonRect1.anchoredPosition = zero;
			if (mapYolk.WonderID == 0)
			{
				this.m_Str[41].ClearString();
				this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
				this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231u));
			}
			else
			{
				this.m_Str[41].ClearString();
				if (flag)
				{
					this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
				}
				else
				{
					this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309u));
				}
				this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231u));
			}
			this.m_ButtonText1.text = this.m_Str[41].ToString();
			this.m_ButtonText1.SetAllDirty();
			this.m_ButtonText1.cachedTextGenerator.Invalidate();
			break;
		case UIGroundInfo.BtnState.NpcCastle:
			this.m_ButtonRect3.gameObject.SetActive(true);
			this.m_ButtonRect4.gameObject.SetActive(true);
			this.m_ButtonRect1.gameObject.SetActive(false);
			this.m_ButtonRect2.gameObject.SetActive(false);
			this.m_ButtonRect5.gameObject.SetActive(false);
			this.m_ButtonRect6.gameObject.SetActive(false);
			this.m_ButtonRect7.gameObject.SetActive(false);
			this.m_ButtonRect8.gameObject.SetActive(false);
			this.m_ButtonRect9.gameObject.SetActive(false);
			this.m_ButtonRect10.gameObject.SetActive(false);
			this.m_ButtonRect11.gameObject.SetActive(false);
			zero.Set(this.m_ButtonRect3.anchoredPosition.x, -295f);
			this.m_ButtonRect3.anchoredPosition = zero;
			zero.Set(this.m_ButtonRect4.anchoredPosition.x, -295f);
			this.m_ButtonRect4.anchoredPosition = zero;
			this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4554u);
			break;
		case UIGroundInfo.BtnState.NpcCastle_NoAllIance:
			this.m_ButtonRect1.gameObject.SetActive(true);
			this.m_ButtonRect2.gameObject.SetActive(false);
			this.m_ButtonRect3.gameObject.SetActive(false);
			this.m_ButtonRect4.gameObject.SetActive(false);
			this.m_ButtonRect5.gameObject.SetActive(false);
			this.m_ButtonRect6.gameObject.SetActive(false);
			this.m_ButtonRect7.gameObject.SetActive(false);
			this.m_ButtonRect8.gameObject.SetActive(false);
			this.m_ButtonRect9.gameObject.SetActive(false);
			this.m_ButtonRect10.gameObject.SetActive(false);
			this.m_ButtonRect11.gameObject.SetActive(false);
			zero.Set(this.m_ButtonRect1.anchoredPosition.x, -295f);
			this.m_ButtonRect1.anchoredPosition = zero;
			this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4601u);
			break;
		}
	}

	// Token: 0x0600125D RID: 4701 RVA: 0x00207B50 File Offset: 0x00205D50
	private bool SetExpressionButton(int ownerKind, POINT_KIND pointKind)
	{
		bool flag = true;
		if ((pointKind == POINT_KIND.PK_FOOD || pointKind == POINT_KIND.PK_STONE || pointKind == POINT_KIND.PK_IRON || pointKind == POINT_KIND.PK_WOOD || pointKind == POINT_KIND.PK_GOLD || pointKind == POINT_KIND.PK_CRYSTAL || pointKind == POINT_KIND.PK_SP_MINE || pointKind == POINT_KIND.PK_CITY || pointKind == POINT_KIND.PK_CAMP) && ownerKind == 1)
		{
			this.m_TeamExpressionBtn.gameObject.SetActive(true);
			this.m_ExpressionBtn.gameObject.SetActive(true);
		}
		else if (pointKind == POINT_KIND.PK_YOLK && (ownerKind == 3 || ownerKind == 1))
		{
			this.m_TeamExpressionBtn.gameObject.SetActive(true);
			this.m_ExpressionBtn.gameObject.SetActive(true);
		}
		else if (pointKind == POINT_KIND.PK_UNDEFINED && ownerKind == 1 && !this.CheckAttackAction())
		{
			this.m_TeamExpressionBtn.gameObject.SetActive(true);
			this.m_ExpressionBtn.gameObject.SetActive(true);
		}
		else if (pointKind == POINT_KIND.PK_UNDEFINED && ownerKind == 3 && DataManager.MapDataController.MapLineTable != null && this.m_MapPointID < DataManager.MapDataController.MapLineTable.Count && !GameConstants.IsPetSkillLine(this.m_MapPointID) && DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag == 12)
		{
			this.m_TeamExpressionBtn.gameObject.SetActive(true);
			this.m_ExpressionBtn.gameObject.SetActive(true);
		}
		else
		{
			flag = false;
			this.m_TeamExpressionBtn.gameObject.SetActive(false);
			this.m_ExpressionBtn.gameObject.SetActive(false);
		}
		if (flag)
		{
			this.SetExclamationmark(DataManager.Instance.CheckShowOnGroundInfo());
		}
		return flag;
	}

	// Token: 0x0600125E RID: 4702 RVA: 0x00207D18 File Offset: 0x00205F18
	public void SetExclamationmark(bool show)
	{
		this.m_Exclamationmark.gameObject.SetActive(show);
		this.m_TeamExclamationmark.gameObject.SetActive(show);
	}

	// Token: 0x0600125F RID: 4703 RVA: 0x00207D48 File Offset: 0x00205F48
	private bool CheckAttackAction()
	{
		CHAOS chaos = GameManager.ActiveGameplay as CHAOS;
		if (chaos != null && chaos.realmController != null && chaos.realmController.mapLineController != null && DataManager.MapDataController.MapLineTable != null && this.m_MapPointID < DataManager.MapDataController.MapLineTable.Count && this.IsAttackActionLineFlag(DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag))
		{
			LineNode nodeByGameObject = chaos.realmController.mapLineController.GetNodeByGameObject(DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineObject, false);
			if (nodeByGameObject != null && nodeByGameObject.action != ELineAction.NORMAL)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001260 RID: 4704 RVA: 0x00207E18 File Offset: 0x00206018
	private bool IsAttackActionLineFlag(byte lineFlag)
	{
		return !GameConstants.IsPetSkillLine(this.m_MapPointID) && (DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag == 23 || DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag == 24 || DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag == 25 || DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag == 26 || DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag == 27);
	}

	// Token: 0x06001261 RID: 4705 RVA: 0x00207EE0 File Offset: 0x002060E0
	private void OpenExpressionUI()
	{
		GUIManager.Instance.OpenMenu(EGUIWindow.UIEmojiSelect, 1, 0, false, true, false);
	}

	// Token: 0x06001262 RID: 4706 RVA: 0x00207F04 File Offset: 0x00206104
	private void SetTitleIcon()
	{
		float[] array = new float[]
		{
			78.5f,
			133f,
			184f
		};
		float[] array2 = new float[]
		{
			319.5f,
			266f,
			214f
		};
		this.m_WorldTitleIcon.gameObject.SetActive(false);
		this.m_NobilityTitleIcon.gameObject.SetActive(false);
		this.m_TitleIcon.gameObject.SetActive(false);
		this.m_RankTf.gameObject.SetActive(false);
		this.m_VipTf.gameObject.SetActive(false);
		byte[] array3 = new byte[3];
		byte b = 0;
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
		if ((int)mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
		{
			WORLD_PLAYER_DESIGNATION worldTitle = DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].worldTitle;
			KINGDOM_DESIGNATION kingdomTitle = DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomTitle;
			byte nobilityTitle = DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].nobilityTitle;
			byte allianceRank = DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].allianceRank;
			byte vip = DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].VIP;
			if (worldTitle == WORLD_PLAYER_DESIGNATION.WKD_1)
			{
				byte[] array4 = array3;
				byte b2 = b;
				b = b2 + 1;
				array4[(int)b2] = 1;
			}
			if (nobilityTitle == 1)
			{
				byte[] array5 = array3;
				byte b3 = b;
				b = b3 + 1;
				array5[(int)b3] = 2;
			}
			if (kingdomTitle == KINGDOM_DESIGNATION.KD_1)
			{
				byte[] array6 = array3;
				byte b4 = b;
				b = b4 + 1;
				array6[(int)b4] = 3;
			}
			if ((int)b < array3.Length && worldTitle != WORLD_PLAYER_DESIGNATION.WKD_NULL && worldTitle != WORLD_PLAYER_DESIGNATION.WKD_1)
			{
				byte[] array7 = array3;
				byte b5 = b;
				b = b5 + 1;
				array7[(int)b5] = 4;
			}
			if ((int)b < array3.Length && nobilityTitle != 0 && nobilityTitle != 1)
			{
				byte[] array8 = array3;
				byte b6 = b;
				b = b6 + 1;
				array8[(int)b6] = 5;
			}
			if ((int)b < array3.Length && kingdomTitle != KINGDOM_DESIGNATION.KD_NONE && kingdomTitle != KINGDOM_DESIGNATION.KD_1)
			{
				byte[] array9 = array3;
				byte b7 = b;
				b = b7 + 1;
				array9[(int)b7] = 6;
			}
			if ((int)b < array3.Length && allianceRank > 0)
			{
				byte[] array10 = array3;
				byte b8 = b;
				b = b8 + 1;
				array10[(int)b8] = 7;
			}
			if ((int)b < array3.Length && vip > 0)
			{
				byte[] array11 = array3;
				byte b9 = b;
				b = b9 + 1;
				array11[(int)b9] = 8;
			}
			if (worldTitle != WORLD_PLAYER_DESIGNATION.WKD_NULL)
			{
				TitleData recordByKey = DataManager.Instance.TitleDataW.GetRecordByKey((ushort)worldTitle);
				this.m_WorldTitleIcon.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.WorldTitle);
				this.m_WorldTitleIcon.material = GUIManager.Instance.GetTitleMaterial();
			}
			if (kingdomTitle != KINGDOM_DESIGNATION.KD_NONE)
			{
				TitleData recordByKey = DataManager.Instance.TitleData.GetRecordByKey((ushort)DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].kingdomTitle);
				this.m_TitleIcon.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.KvkTitle);
				this.m_TitleIcon.material = GUIManager.Instance.GetTitleMaterial();
			}
			if (nobilityTitle != 0)
			{
				TitleData recordByKey = DataManager.Instance.TitleDataF.GetRecordByKey((ushort)nobilityTitle);
				this.m_NobilityTitleIcon.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.NobilityTitle);
				this.m_NobilityTitleIcon.material = GUIManager.Instance.GetTitleMaterial();
			}
		}
		int num = 0;
		for (int i = 0; i < array3.Length; i++)
		{
			if (array3[i] != 0)
			{
				this.SetTitleIcon(i, array3[i]);
				num++;
			}
		}
		num = Mathf.Clamp(num - 1, 0, 2);
		Vector2 vector = this.m_IDText.rectTransform.sizeDelta;
		vector.x = array2[num];
		this.m_IDText.rectTransform.sizeDelta = vector;
		vector = this.m_IDText.rectTransform.anchoredPosition;
		vector.x = array[num];
		this.m_IDTextRt.anchoredPosition = this.m_IDText.ArabicFixPos(vector);
	}

	// Token: 0x06001263 RID: 4707 RVA: 0x002082E0 File Offset: 0x002064E0
	private void SetTitleIcon(int idx, byte type)
	{
		float[] array = new float[]
		{
			-153f,
			-103f,
			-52.5f
		};
		float[] array2 = new float[]
		{
			-153f,
			-103f,
			-52.5f
		};
		float[] array3 = new float[]
		{
			-153f,
			-103f,
			-52.5f
		};
		float[] array4 = new float[]
		{
			-153f,
			-103f,
			-52.5f
		};
		float[] array5 = new float[]
		{
			-153f,
			-103f,
			-52.5f
		};
		if (idx >= 3)
		{
			return;
		}
		switch (type)
		{
		case 1:
		case 4:
			this.m_WorldTitleIcon.gameObject.SetActive(true);
			this.m_WorldTitleIcon.rectTransform.anchoredPosition = new Vector2(array[idx], 141f);
			break;
		case 2:
		case 5:
			this.m_NobilityTitleIcon.gameObject.SetActive(true);
			this.m_NobilityTitleIcon.rectTransform.anchoredPosition = new Vector2(array2[idx], 141f);
			break;
		case 3:
		case 6:
			this.m_TitleIcon.gameObject.SetActive(true);
			this.m_TitleIcon.rectTransform.anchoredPosition = new Vector2(array3[idx], 141f);
			break;
		case 7:
			this.m_RankTf.gameObject.SetActive(true);
			((RectTransform)this.m_RankTf).anchoredPosition = new Vector2(array4[idx], 141f);
			break;
		case 8:
			this.m_VipTf.gameObject.SetActive(true);
			((RectTransform)this.m_VipTf).anchoredPosition = new Vector2(array5[idx], 141f);
			break;
		}
	}

	// Token: 0x06001264 RID: 4708 RVA: 0x002084C4 File Offset: 0x002066C4
	private void SetCityOutwardLevel(byte level)
	{
		if (level > 0)
		{
			int num = (int)(level - 1);
			if (this.m_CityOutwardLevelTf && !this.m_CityOutwardLevelTf.gameObject.activeInHierarchy)
			{
				this.m_CityOutwardLevelTf.gameObject.SetActive(true);
			}
			for (int i = 0; i < this.m_CityOutwardLevelImages.Length; i++)
			{
				if (this.m_CityOutwardLevelImages[i] != null)
				{
					if (i <= num)
					{
						if (!this.m_CityOutwardLevelImages[i].gameObject.activeInHierarchy)
						{
							this.m_CityOutwardLevelImages[i].gameObject.SetActive(true);
						}
					}
					else if (this.m_CityOutwardLevelImages[i].gameObject.activeInHierarchy)
					{
						this.m_CityOutwardLevelImages[i].gameObject.SetActive(false);
					}
				}
			}
		}
		else if (this.m_CityOutwardLevelTf && this.m_CityOutwardLevelTf.gameObject.activeInHierarchy)
		{
			this.m_CityOutwardLevelTf.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001265 RID: 4709 RVA: 0x002085DC File Offset: 0x002067DC
	private void SetCenterText(Image image, UIText text, float width)
	{
		float num = 10f;
		float x = (width - (image.rectTransform.sizeDelta.x + text.preferredWidth + num)) / 2f;
		image.rectTransform.anchoredPosition = new Vector2(x, image.rectTransform.anchoredPosition.y);
		text.rectTransform.anchoredPosition = new Vector2(image.rectTransform.anchoredPosition.x + image.rectTransform.sizeDelta.x + num, text.rectTransform.anchoredPosition.y);
	}

	// Token: 0x06001266 RID: 4710 RVA: 0x00208688 File Offset: 0x00206888
	private void SetCenterText(float width, RectTransform rect, Image image)
	{
		float num = 10f;
		Text component = rect.GetChild(0).GetComponent<UIText>();
		float x = (width - (image.rectTransform.sizeDelta.x + component.preferredWidth + num)) / 2f;
		image.rectTransform.anchoredPosition = new Vector2(x, image.rectTransform.anchoredPosition.y);
		rect.anchoredPosition = new Vector2(rect.anchoredPosition.x + image.rectTransform.sizeDelta.x + num, component.rectTransform.anchoredPosition.y);
	}

	// Token: 0x06001267 RID: 4711 RVA: 0x00208738 File Offset: 0x00206938
	private void UpdatemPetNegativeBuff(int mapPointID = 0, bool bHideAllIcon = true)
	{
		if (this.m_PetSkillTf != null && mapPointID == this.m_MapPointID)
		{
			byte kind = 1;
			Image component = this.m_PetSkillTf.GetChild(0).GetComponent<Image>();
			this.SetOwnerKind();
			RectTransform component2 = this.m_PetSkillTf.GetComponent<RectTransform>();
			Vector2 vector = component2.anchoredPosition;
			if (this.m_PetSkillUse.gameObject.activeInHierarchy)
			{
				vector.y = -30f;
			}
			else
			{
				vector.y = -79f;
			}
			component2.anchoredPosition = vector;
			if (bHideAllIcon)
			{
				byte b = 0;
				while ((int)b < this.m_PetNegativeBuff.Length)
				{
					this.m_PetNegativeBuff[(int)b].gameObject.SetActive(false);
					b += 1;
				}
				if (component)
				{
					component.gameObject.SetActive(false);
				}
			}
			else
			{
				int stateCountByKind = (int)DataManager.MapDataController.getStateCountByKind(kind);
				byte b2 = 0;
				while ((int)b2 < this.m_PetNegativeBuff.Length)
				{
					if ((int)b2 < stateCountByKind)
					{
						ushort stateSkillIDByIndex = DataManager.MapDataController.getStateSkillIDByIndex(kind, b2);
						this.m_PetNegativeBuff[(int)b2].sprite = PetManager.Instance.LoadPetSkillIcon(stateSkillIDByIndex);
						this.m_PetNegativeBuff[(int)b2].material = GUIManager.Instance.GetSkillMaterial();
						this.m_PetNegativeBuff[(int)b2].gameObject.SetActive(true);
					}
					else
					{
						this.m_PetNegativeBuff[(int)b2].sprite = PetManager.Instance.LoadPetSkillIcon(0);
						this.m_PetNegativeBuff[(int)b2].material = GUIManager.Instance.GetSkillMaterial();
						this.m_PetNegativeBuff[(int)b2].gameObject.SetActive(false);
					}
					b2 += 1;
				}
				if (component)
				{
					vector = component.rectTransform.sizeDelta;
					if (stateCountByKind > 4)
					{
						vector.x = 106f;
					}
					else
					{
						vector.x = 56f;
					}
					component.rectTransform.sizeDelta = vector;
					if (stateCountByKind > 0)
					{
						component.gameObject.SetActive(true);
					}
				}
			}
		}
	}

	// Token: 0x06001268 RID: 4712 RVA: 0x00208950 File Offset: 0x00206B50
	private void SetNegativePetSkillBtn(bool bCheckShieldKind = false)
	{
		byte kind = 0;
		this.m_PetSkillUse.gameObject.SetActive(this.OwnerKind == 2 && PetBuff.ShowActive(1));
		RectTransform component = this.m_PetSkillUse.gameObject.GetComponent<RectTransform>();
		if (this.m_ButtonRect1 != null && this.m_ButtonRect1.gameObject.activeSelf)
		{
			component.anchoredPosition = new Vector2(component.anchoredPosition.x, -105f);
		}
		else
		{
			component.anchoredPosition = new Vector2(component.anchoredPosition.x, -56f);
		}
		Image component2 = this.m_PetSkillUse.transform.GetChild(0).GetComponent<Image>();
		Image component3 = this.m_PetSkillUse.transform.GetChild(1).GetComponent<Image>();
		if (component2)
		{
			component2.color = Color.white;
			if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID)
			{
				if (component3)
				{
					component3.enabled = false;
				}
				this.m_PetSkillUse.m_BtnID3 = 7744;
				component2.color = Color.gray;
				return;
			}
		}
		if (component3)
		{
			int stateCountByKind = (int)DataManager.MapDataController.getStateCountByKind(kind);
			if (stateCountByKind > 0 && bCheckShieldKind)
			{
				component3.gameObject.SetActive(true);
				this.m_PetSkillUse.m_BtnID3 = 12572;
			}
			else if (DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) == 0f)
			{
				component3.gameObject.SetActive(false);
				this.m_PetSkillUse.m_BtnID3 = 12563;
			}
			else
			{
				component3.gameObject.SetActive(false);
				this.m_PetSkillUse.m_BtnID3 = 0;
			}
		}
	}

	// Token: 0x040038E0 RID: 14560
	private const int m_StrCount = 51;

	// Token: 0x040038E1 RID: 14561
	private const int MaxTempTextNum = 52;

	// Token: 0x040038E2 RID: 14562
	private int[] ScoutNeedMoney_NpcCastle = new int[]
	{
		250,
		1500,
		2250,
		3500,
		5000
	};

	// Token: 0x040038E3 RID: 14563
	private int[] ScoutNeedMoney = new int[]
	{
		1000,
		1100,
		1200,
		1300,
		1400,
		1500,
		1600,
		1700,
		1800,
		1900,
		2000,
		2100,
		2200,
		2300,
		2400,
		2500,
		2600,
		2700,
		2800,
		2900,
		3000,
		3200,
		3400,
		3500,
		4000
	};

	// Token: 0x040038E4 RID: 14564
	public RectTransform m_Panel;

	// Token: 0x040038E5 RID: 14565
	public RectTransform m_TeamPanel;

	// Token: 0x040038E6 RID: 14566
	public GameObject m_PanelGameObject;

	// Token: 0x040038E7 RID: 14567
	public GameObject m_TeamPanelGameObject;

	// Token: 0x040038E8 RID: 14568
	public RectTransform m_SearchPanel;

	// Token: 0x040038E9 RID: 14569
	public RectTransform m_ReinforcePanel;

	// Token: 0x040038EA RID: 14570
	public RectTransform m_DetectPanel;

	// Token: 0x040038EB RID: 14571
	public RectTransform m_AttackPanel;

	// Token: 0x040038EC RID: 14572
	public RectTransform m_BookmarksPanel;

	// Token: 0x040038ED RID: 14573
	public RectTransform m_PvePanel;

	// Token: 0x040038EE RID: 14574
	public RectTransform m_RewardPanel;

	// Token: 0x040038EF RID: 14575
	public RectTransform m_TitlePanel;

	// Token: 0x040038F0 RID: 14576
	public RectTransform m_RectTransform;

	// Token: 0x040038F1 RID: 14577
	private Transform m_HintPanel;

	// Token: 0x040038F2 RID: 14578
	private RectTransform m_BGPanel;

	// Token: 0x040038F3 RID: 14579
	private Image m_BGIcon;

	// Token: 0x040038F4 RID: 14580
	private Image m_BGIconMask;

	// Token: 0x040038F5 RID: 14581
	private Transform m_CityOutwardLevelTf;

	// Token: 0x040038F6 RID: 14582
	private Image[] m_CityOutwardLevelImages = new Image[5];

	// Token: 0x040038F7 RID: 14583
	private RectTransform m_GroundTextBGRect;

	// Token: 0x040038F8 RID: 14584
	private UIText m_GroundTitle;

	// Token: 0x040038F9 RID: 14585
	private RectTransform m_ButtonPanel;

	// Token: 0x040038FA RID: 14586
	private RectTransform m_ButtonRect1;

	// Token: 0x040038FB RID: 14587
	private RectTransform m_ButtonRect2;

	// Token: 0x040038FC RID: 14588
	private RectTransform m_ButtonRect3;

	// Token: 0x040038FD RID: 14589
	private RectTransform m_ButtonRect4;

	// Token: 0x040038FE RID: 14590
	private RectTransform m_ButtonRect5;

	// Token: 0x040038FF RID: 14591
	private RectTransform m_ButtonRect6;

	// Token: 0x04003900 RID: 14592
	private RectTransform m_ButtonRect7;

	// Token: 0x04003901 RID: 14593
	private RectTransform m_ButtonRect8;

	// Token: 0x04003902 RID: 14594
	private RectTransform m_ButtonRect9;

	// Token: 0x04003903 RID: 14595
	private RectTransform m_ButtonRect10;

	// Token: 0x04003904 RID: 14596
	private RectTransform m_ButtonRect11;

	// Token: 0x04003905 RID: 14597
	private RectTransform m_CustmCastleExclamation;

	// Token: 0x04003906 RID: 14598
	private UIButton[] m_Buttons = new UIButton[11];

	// Token: 0x04003907 RID: 14599
	private UIText m_ButtonText1;

	// Token: 0x04003908 RID: 14600
	private UIText m_ButtonText2;

	// Token: 0x04003909 RID: 14601
	private UIText m_ButtonText3;

	// Token: 0x0400390A RID: 14602
	private UIText m_ButtonText6;

	// Token: 0x0400390B RID: 14603
	private UIText m_ButtonText7;

	// Token: 0x0400390C RID: 14604
	private UIText m_ButtonText8;

	// Token: 0x0400390D RID: 14605
	private UIText m_ButtonText9;

	// Token: 0x0400390E RID: 14606
	private UIText m_ButtonText10;

	// Token: 0x0400390F RID: 14607
	private UIText m_ButtonText11;

	// Token: 0x04003910 RID: 14608
	private UIText m_LocationText;

	// Token: 0x04003911 RID: 14609
	private UIButton m_BookmarkBtn;

	// Token: 0x04003912 RID: 14610
	private UIButton m_ExpressionBtn;

	// Token: 0x04003913 RID: 14611
	private UIButton m_TeamExpressionBtn;

	// Token: 0x04003914 RID: 14612
	private Transform m_Exclamationmark;

	// Token: 0x04003915 RID: 14613
	private Transform m_TeamExclamationmark;

	// Token: 0x04003916 RID: 14614
	private Door m_Door;

	// Token: 0x04003917 RID: 14615
	private AssetBundle m_AssetBundle;

	// Token: 0x04003918 RID: 14616
	private int m_AssetBundleKey;

	// Token: 0x04003919 RID: 14617
	public int m_MapPointID;

	// Token: 0x0400391A RID: 14618
	public int m_MonsterMapPoint = -1;

	// Token: 0x0400391B RID: 14619
	public EGroundInfoKind m_eGroundInfoKind;

	// Token: 0x0400391C RID: 14620
	private RectTransform m_GroundPanel;

	// Token: 0x0400391D RID: 14621
	private UIText m_GroundText;

	// Token: 0x0400391E RID: 14622
	private RectTransform m_LocationRt;

	// Token: 0x0400391F RID: 14623
	private RectTransform m_ChatBtnRt;

	// Token: 0x04003920 RID: 14624
	private RectTransform m_ResourcePanel;

	// Token: 0x04003921 RID: 14625
	private RectTransform m_ValueBar1;

	// Token: 0x04003922 RID: 14626
	private RectTransform m_ValueBar2;

	// Token: 0x04003923 RID: 14627
	private Image m_ResourceIcon;

	// Token: 0x04003924 RID: 14628
	private UIText m_ResourceText;

	// Token: 0x04003925 RID: 14629
	private UIText m_ResourceProductionTitle;

	// Token: 0x04003926 RID: 14630
	private UIText m_ResourceProductionText;

	// Token: 0x04003927 RID: 14631
	private UIText m_ResourceOwnerText;

	// Token: 0x04003928 RID: 14632
	private Image m_Slider11;

	// Token: 0x04003929 RID: 14633
	private Image m_Slider12;

	// Token: 0x0400392A RID: 14634
	private Image m_Slider2;

	// Token: 0x0400392B RID: 14635
	private UIText m_SliderText1;

	// Token: 0x0400392C RID: 14636
	private UIText m_SliderText2;

	// Token: 0x0400392D RID: 14637
	private UISpritesArray m_SpriteArray;

	// Token: 0x0400392E RID: 14638
	private RectTransform m_CampPanel;

	// Token: 0x0400392F RID: 14639
	private RectTransform m_CampTitleTextRt;

	// Token: 0x04003930 RID: 14640
	private RectTransform m_IDTextRt;

	// Token: 0x04003931 RID: 14641
	private Transform m_VipTf;

	// Token: 0x04003932 RID: 14642
	private Transform m_RankTf;

	// Token: 0x04003933 RID: 14643
	private UIHIBtn m_CampHiBtn;

	// Token: 0x04003934 RID: 14644
	private UIText m_CampTitleText;

	// Token: 0x04003935 RID: 14645
	private UIText m_IDText;

	// Token: 0x04003936 RID: 14646
	private UIText m_StrengthText;

	// Token: 0x04003937 RID: 14647
	private UIText m_WipeOutText;

	// Token: 0x04003938 RID: 14648
	private UIText m_LeagueText;

	// Token: 0x04003939 RID: 14649
	private UIText m_KingdomText;

	// Token: 0x0400393A RID: 14650
	private UIText m_VipText;

	// Token: 0x0400393B RID: 14651
	private UIText m_RankText;

	// Token: 0x0400393C RID: 14652
	private Image m_RankImage;

	// Token: 0x0400393D RID: 14653
	private Image m_TitleIcon;

	// Token: 0x0400393E RID: 14654
	private Image m_WorldTitleIcon;

	// Token: 0x0400393F RID: 14655
	private Image m_NobilityTitleIcon;

	// Token: 0x04003940 RID: 14656
	private RectTransform m_WondersPanel;

	// Token: 0x04003941 RID: 14657
	private RectTransform m_NpcCastlePanel;

	// Token: 0x04003942 RID: 14658
	private UIButton m_InformationBtn;

	// Token: 0x04003943 RID: 14659
	private UIButton m_TeamIDBtn;

	// Token: 0x04003944 RID: 14660
	private UIButton m_TeamLocBtn;

	// Token: 0x04003945 RID: 14661
	private UIButton m_TeamExitBtn;

	// Token: 0x04003946 RID: 14662
	private UIButton m_TeamRetureBtn;

	// Token: 0x04003947 RID: 14663
	private UIButton m_TeamSpeedBtn;

	// Token: 0x04003948 RID: 14664
	private GameObject m_TeamSpeedBtnGameObject;

	// Token: 0x04003949 RID: 14665
	private UIText m_TeamIDText;

	// Token: 0x0400394A RID: 14666
	private UIText m_TeamLocText;

	// Token: 0x0400394B RID: 14667
	private UIText m_TimeText;

	// Token: 0x0400394C RID: 14668
	private UIText m_TeamReturnText;

	// Token: 0x0400394D RID: 14669
	private UIText m_TeamTargetText;

	// Token: 0x0400394E RID: 14670
	private Image m_TeamLocLine;

	// Token: 0x0400394F RID: 14671
	private Image m_TeamIDLine;

	// Token: 0x04003950 RID: 14672
	private UIEmojiInput inputField;

	// Token: 0x04003951 RID: 14673
	private POINT_KIND m_PreKind = POINT_KIND.PK_MAX;

	// Token: 0x04003952 RID: 14674
	private UIHIBtn m_PveHeroBtn;

	// Token: 0x04003953 RID: 14675
	private UIText m_PveTitle;

	// Token: 0x04003954 RID: 14676
	private UIText m_PveHeroName;

	// Token: 0x04003955 RID: 14677
	private UIText m_PvePowerText;

	// Token: 0x04003956 RID: 14678
	private Image m_PvePowerIcon;

	// Token: 0x04003957 RID: 14679
	private UIButton m_RewardBtn;

	// Token: 0x04003958 RID: 14680
	private UIText m_RewardText;

	// Token: 0x04003959 RID: 14681
	private UIText m_HintText;

	// Token: 0x0400395A RID: 14682
	private Image m_HintBg;

	// Token: 0x0400395B RID: 14683
	private GameObject m_NpcCastleIcon;

	// Token: 0x0400395C RID: 14684
	private Transform m_NpcCastleIconBone;

	// Token: 0x0400395D RID: 14685
	private Image m_NpcCastleFrame;

	// Token: 0x0400395E RID: 14686
	private UIText m_NpcCastleIDText;

	// Token: 0x0400395F RID: 14687
	private UIText m_NpcCastleStrengthText;

	// Token: 0x04003960 RID: 14688
	private UIText m_NpcCastleTimeText;

	// Token: 0x04003961 RID: 14689
	private UIText m_NpcCastleInfoText;

	// Token: 0x04003962 RID: 14690
	private GameObject m_NpcCastleDLImg;

	// Token: 0x04003963 RID: 14691
	private GameObject m_TempNpcCastleDLImg;

	// Token: 0x04003964 RID: 14692
	private UIButton m_NpcCastleInfoBtn;

	// Token: 0x04003965 RID: 14693
	private Transform m_PetSkillTf;

	// Token: 0x04003966 RID: 14694
	private UIButton m_PetSkillUse;

	// Token: 0x04003967 RID: 14695
	private Image[] m_PetNegativeBuff = new Image[8];

	// Token: 0x04003968 RID: 14696
	private ushort m_NpcCastleHeadID;

	// Token: 0x04003969 RID: 14697
	private int m_NpcCastleHeadAssetKey;

	// Token: 0x0400396A RID: 14698
	private StringBuilder sb;

	// Token: 0x0400396B RID: 14699
	public Material TileMapMat;

	// Token: 0x0400396C RID: 14700
	public Material WonderTileMapMat1;

	// Token: 0x0400396D RID: 14701
	public Material WonderTileMapMat2;

	// Token: 0x0400396E RID: 14702
	private CString[] m_Str = new CString[51];

	// Token: 0x0400396F RID: 14703
	private CString BookMarkNameStr;

	// Token: 0x04003970 RID: 14704
	public bool bHaveAlly_Self;

	// Token: 0x04003971 RID: 14705
	public bool bHaveAlly;

	// Token: 0x04003972 RID: 14706
	public byte m_ResType = 1;

	// Token: 0x04003973 RID: 14707
	public int OwnerKind;

	// Token: 0x04003974 RID: 14708
	private long m_ResStartTime;

	// Token: 0x04003975 RID: 14709
	private uint m_ResTotalCount;

	// Token: 0x04003976 RID: 14710
	private float m_ResRate;

	// Token: 0x04003977 RID: 14711
	private uint m_MaxOverload;

	// Token: 0x04003978 RID: 14712
	private float m_TimeTick;

	// Token: 0x04003979 RID: 14713
	private float m_ResTextChangeTime = 1.5f;

	// Token: 0x0400397A RID: 14714
	private byte m_ResTextType;

	// Token: 0x0400397B RID: 14715
	private float delayOpenTime;

	// Token: 0x0400397C RID: 14716
	private int delayMapInfoID;

	// Token: 0x0400397D RID: 14717
	private POINT_KIND delayInfoKind = POINT_KIND.PK_MAX;

	// Token: 0x0400397E RID: 14718
	private bool bHideSelectMod;

	// Token: 0x0400397F RID: 14719
	private byte m_AttackSelect;

	// Token: 0x04003980 RID: 14720
	private byte m_HideSelect;

	// Token: 0x04003981 RID: 14721
	private byte m_BookmarkSelect;

	// Token: 0x04003982 RID: 14722
	public bool bRequsetAdvanceMapdata;

	// Token: 0x04003983 RID: 14723
	public int m_RequsetMapID = -1;

	// Token: 0x04003984 RID: 14724
	public float m_RequsetTick;

	// Token: 0x04003985 RID: 14725
	public ushort m_ModifyBookMarkID;

	// Token: 0x04003986 RID: 14726
	public bool bOpenPvePanel;

	// Token: 0x04003987 RID: 14727
	public byte m_ScoutTagLv;

	// Token: 0x04003988 RID: 14728
	public bool bOpenUIExpedition_FromList;

	// Token: 0x04003989 RID: 14729
	public bool bGroundInfoOpen;

	// Token: 0x0400398A RID: 14730
	public ushort m_SearchLocationK;

	// Token: 0x0400398B RID: 14731
	public ushort m_SearchLocationX;

	// Token: 0x0400398C RID: 14732
	public ushort m_SearchLocationY;

	// Token: 0x0400398D RID: 14733
	public byte m_SearchInput;

	// Token: 0x0400398E RID: 14734
	public UIText m_WonderID;

	// Token: 0x0400398F RID: 14735
	public UIText m_WonderState;

	// Token: 0x04003990 RID: 14736
	public UIText m_WonderTime;

	// Token: 0x04003991 RID: 14737
	public UIText m_WonderAlliance;

	// Token: 0x04003992 RID: 14738
	public UIText m_WonderOwner;

	// Token: 0x04003993 RID: 14739
	public UIText m_WonderKingdom;

	// Token: 0x04003994 RID: 14740
	public UIText m_DetectPanelText;

	// Token: 0x04003995 RID: 14741
	public Transform m_WonderTimeTF;

	// Token: 0x04003996 RID: 14742
	public UIHIBtn m_WonderHIBtn;

	// Token: 0x04003997 RID: 14743
	public Transform m_WonderAllianeIcon;

	// Token: 0x04003998 RID: 14744
	public Image m_WonderAllianeFrame;

	// Token: 0x04003999 RID: 14745
	public Image m_WonderStateImage1;

	// Token: 0x0400399A RID: 14746
	public Image m_WonderStateImage2;

	// Token: 0x0400399B RID: 14747
	public Image m_WonderStateImage3;

	// Token: 0x0400399C RID: 14748
	private UIText[] m_TempText = new UIText[52];

	// Token: 0x0400399D RID: 14749
	private int m_TempTextIdx;

	// Token: 0x0400399E RID: 14750
	private byte SoccerRun_SFXKey = byte.MaxValue;

	// Token: 0x0400399F RID: 14751
	private UIText[] m_AttackPanelTimeText = new UIText[4];

	// Token: 0x040039A0 RID: 14752
	private UIText m_AttackPanelTitleText;

	// Token: 0x040039A1 RID: 14753
	private UIText m_AttackPanelInfoText;

	// Token: 0x040039A2 RID: 14754
	private UIText m_AttackPanelPosText;

	// Token: 0x040039A3 RID: 14755
	private UIButton[] m_AttackPanelTimeBtn = new UIButton[4];

	// Token: 0x040039A4 RID: 14756
	private Image[] m_AttackPanelTimeSelectImg = new Image[4];

	// Token: 0x040039A5 RID: 14757
	private Image m_AttackPanelIcon;

	// Token: 0x040039A6 RID: 14758
	private Transform m_AttackPanelPosTf;

	// Token: 0x040039A7 RID: 14759
	private UIGroundInfo._BookmarkSwitch BookmarkSwitch;

	// Token: 0x040039A8 RID: 14760
	private POINT_KIND m_infoKind;

	// Token: 0x02000370 RID: 880
	private enum BtnState
	{
		// Token: 0x040039AA RID: 14762
		None,
		// Token: 0x040039AB RID: 14763
		WondersInfo_Ally_Peace,
		// Token: 0x040039AC RID: 14764
		WondersInfo_Ally_Fight,
		// Token: 0x040039AD RID: 14765
		WondersInfo_NA_Peace,
		// Token: 0x040039AE RID: 14766
		WondersInfo_NA_Fight,
		// Token: 0x040039AF RID: 14767
		WondersInfo_Army_Peace,
		// Token: 0x040039B0 RID: 14768
		WondersInfo_Army_Fight,
		// Token: 0x040039B1 RID: 14769
		WondersInfo_NoAllIance,
		// Token: 0x040039B2 RID: 14770
		NpcCastle,
		// Token: 0x040039B3 RID: 14771
		NpcCastle_NoAllIance,
		// Token: 0x040039B4 RID: 14772
		Max
	}

	// Token: 0x02000371 RID: 881
	public struct _BookmarkSwitch
	{
		// Token: 0x06001269 RID: 4713 RVA: 0x00208B34 File Offset: 0x00206D34
		public _BookmarkSwitch(RectTransform rectTrans)
		{
			this.SizeTrans = (rectTrans.GetChild(0) as RectTransform);
			this.SelTitleObj = rectTrans.GetChild(6).gameObject;
			this.SelObjs = new GameObject[4];
			for (int i = 0; i < 3; i++)
			{
				this.SelObjs[i] = rectTrans.GetChild(10 + i).gameObject;
			}
			this.SelObjs[3] = rectTrans.GetChild(15).gameObject;
			this.ConfirmTrans = (rectTrans.GetChild(13) as RectTransform);
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x00208BC4 File Offset: 0x00206DC4
		public void Switch(UIGroundInfo._BookmarkSwitch.eType bookType)
		{
			switch (bookType)
			{
			case UIGroundInfo._BookmarkSwitch.eType.AddBookmark:
				this.SelTitleObj.SetActive(true);
				if (DataManager.Instance.RoleAlliance.Id > 0u && DataManager.Instance.RoleAlliance.Rank >= AllianceRank.RANK4)
				{
					this.SizeTrans.sizeDelta = new Vector2(416f, 498f);
					for (int i = 0; i < this.SelObjs.Length; i++)
					{
						this.SelObjs[i].SetActive(true);
					}
					this.ConfirmTrans.anchoredPosition = new Vector2(-1f, -215f);
				}
				else
				{
					this.SizeTrans.sizeDelta = new Vector2(416f, 453f);
					for (int j = 0; j < this.SelObjs.Length - 1; j++)
					{
						this.SelObjs[j].SetActive(true);
					}
					this.SelObjs[3].SetActive(false);
					this.ConfirmTrans.anchoredPosition = new Vector2(-1f, -170f);
				}
				break;
			case UIGroundInfo._BookmarkSwitch.eType.ModifyBookmark:
				this.SelTitleObj.SetActive(true);
				this.SizeTrans.sizeDelta = new Vector2(416f, 453f);
				for (int k = 0; k < this.SelObjs.Length - 1; k++)
				{
					this.SelObjs[k].SetActive(true);
				}
				this.SelObjs[3].SetActive(false);
				this.ConfirmTrans.anchoredPosition = new Vector2(-1f, -170f);
				break;
			case UIGroundInfo._BookmarkSwitch.eType.ModifyAlliancemark:
				this.SizeTrans.sizeDelta = new Vector2(416f, 266f);
				this.SelTitleObj.SetActive(false);
				for (int l = 0; l < this.SelObjs.Length; l++)
				{
					this.SelObjs[l].SetActive(false);
				}
				this.ConfirmTrans.anchoredPosition = new Vector2(-1f, 17f);
				break;
			}
		}

		// Token: 0x040039B5 RID: 14773
		private RectTransform SizeTrans;

		// Token: 0x040039B6 RID: 14774
		private RectTransform ConfirmTrans;

		// Token: 0x040039B7 RID: 14775
		private GameObject SelTitleObj;

		// Token: 0x040039B8 RID: 14776
		private GameObject[] SelObjs;

		// Token: 0x02000372 RID: 882
		public enum eType
		{
			// Token: 0x040039BA RID: 14778
			AddBookmark,
			// Token: 0x040039BB RID: 14779
			ModifyBookmark,
			// Token: 0x040039BC RID: 14780
			ModifyAlliancemark
		}
	}
}
