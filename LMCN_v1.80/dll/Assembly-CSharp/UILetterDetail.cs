using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005CC RID: 1484
public class UILetterDetail : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUILEBtnClickHandler
{
	// Token: 0x06001D61 RID: 7521 RVA: 0x003545E4 File Offset: 0x003527E4
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.MM = MallManager.Instance;
		this.GameT = base.gameObject.transform;
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.m_Mat = this.door.LoadMaterial();
		if (IGGGameSDK.Instance.GetTranslateStatus() && this.DM.MySysSetting.bAutoTranslate)
		{
			this.bTrans = true;
		}
		this.Favor.Serial = this.DM.OpenMail.Serial;
		this.Favor.Type = this.DM.OpenMail.Type;
		this.Favor.Kind = this.DM.OpenMail.Kind;
		if (this.DM.MailReportGet(ref this.Favor))
		{
			switch (this.Favor.Type)
			{
			case MailType.EMAIL_SYSTEM:
				this.SC = this.Favor.System;
				if (!this.SC.BeRead)
				{
					if (this.Favor.Kind == MailType.EMAIL_SYSTEM)
					{
						this.DM.SystemReportRead(this.SC.SerialID, false);
					}
					else
					{
						this.DM.FavorReportRead(this.SC.SerialID, false);
					}
				}
				this.mLetterKind = 1;
				break;
			case MailType.EMAIL_BATTLE:
				this.CR = this.Favor.Combat;
				if (!this.CR.BeRead)
				{
					if (this.Favor.Kind == MailType.EMAIL_BATTLE)
					{
						this.DM.BattleReportRead(this.CR.SerialID, false);
					}
					else
					{
						this.DM.FavorReportRead(this.CR.SerialID, false);
					}
				}
				this.mLetterKind = 2;
				break;
			case MailType.EMAIL_LETTER:
				this.MC = this.Favor.Mail;
				if (!this.MC.BeRead)
				{
					if (this.Favor.Kind == MailType.EMAIL_LETTER)
					{
						this.DM.MailReportRead(this.MC.SerialID, false);
					}
					else
					{
						this.DM.FavorReportRead(this.MC.SerialID, false);
					}
				}
				this.mLetterKind = 0;
				break;
			}
			this.Cstr_Name = StringManager.Instance.SpawnString(30);
			this.Cstr_Page = StringManager.Instance.SpawnString(30);
			this.Cstr_Skill = StringManager.Instance.SpawnString(30);
			this.Cstr_Title = StringManager.Instance.SpawnString(500);
			this.Cstr_S_Title = StringManager.Instance.SpawnString(30);
			this.Cstr_LordEquip_Lv = StringManager.Instance.SpawnString(100);
			this.Cstr_Translation = StringManager.Instance.SpawnString(100);
			for (int i = 0; i < 2; i++)
			{
				this.Cstr_Time[i] = StringManager.Instance.SpawnString(30);
				this.Cstr_SkillIcon[i] = StringManager.Instance.SpawnString(30);
				this.Cstr_LordEquip[i] = StringManager.Instance.SpawnString(100);
				this.Cstr_Gifts[i] = StringManager.Instance.SpawnString(100);
			}
			for (int j = 0; j < 4; j++)
			{
				this.Cstr_StarUpValue[j] = StringManager.Instance.SpawnString(30);
			}
			for (int k = 0; k < 3; k++)
			{
				this.Cstr_S_Top[k] = StringManager.Instance.SpawnString(30);
			}
			for (int l = 0; l < 6; l++)
			{
				this.Hbtn_Item[l] = new UIHIBtn[5];
				this.Lebtn_Item[l] = new UILEBtn[5];
				this.text_S_ItemNum[l] = new UIText[5];
				this.Cstr_S_ItemNum[l] = new CString[5];
				for (int m = 0; m < 5; m++)
				{
					this.Cstr_S_ItemNum[l][m] = StringManager.Instance.SpawnString(10);
				}
				this.Cstr_LordEquip_Effect[l] = new CString[2];
				this.text_LordEquip_Effect[l] = new UIText[2];
				for (int n = 0; n < 2; n++)
				{
					this.Cstr_LordEquip_Effect[l][n] = StringManager.Instance.SpawnString(30);
				}
			}
			for (int num = 0; num < 10; num++)
			{
				this.Cstr_BookMarkList2[num] = StringManager.Instance.SpawnString(30);
			}
			this.Cstr_Contents_S = StringManager.Instance.SpawnString(300);
			for (int num2 = 0; num2 < 4; num2++)
			{
				this.Str_HeroColor[num2] = this.DM.mStringTable.GetStringByID((uint)((ushort)(7651 + num2)));
			}
			this.Tmp = this.GameT.GetChild(0);
			this.Img_BG = this.Tmp.GetComponent<Image>();
			this.Tmp = this.GameT.GetChild(0).GetChild(0);
			this.Img_TitleIcon = this.Tmp.GetComponent<Image>();
			this.mStatus = arg1;
			this.Img_TitleIcon.sprite = this.SArray.m_Sprites[5 + this.mStatus];
			this.Img_TitleIcon.SetNativeSize();
			this.Tmp = this.GameT.GetChild(0).GetChild(1);
			this.Img_Title = this.Tmp.GetComponent<Image>();
			this.Tmp = this.GameT.GetChild(0).GetChild(3);
			this.text_Title = this.Tmp.GetComponent<UIText>();
			this.text_Title.font = this.TTFont;
			this.text_Title.SetCheckArabic(true);
			this.Tmp = this.GameT.GetChild(0).GetChild(4);
			this.text_Page = this.Tmp.GetComponent<UIText>();
			this.text_Page.font = this.TTFont;
			this.Tmp = this.GameT.GetChild(0).GetChild(5);
			this.text_Time[0] = this.Tmp.GetComponent<UIText>();
			this.text_Time[0].font = this.TTFont;
			this.Cstr_Time[0].ClearString();
			this.Tmp = this.GameT.GetChild(0).GetChild(6);
			this.text_Time[1] = this.Tmp.GetComponent<UIText>();
			this.text_Time[1].font = this.TTFont;
			this.Cstr_Time[1].ClearString();
			this.Tmp = this.GameT.GetChild(0).GetChild(7);
			this.text_Name = this.Tmp.GetComponent<UIText>();
			this.text_Name.font = this.TTFont;
			this.Tmp = this.GameT.GetChild(0).GetChild(9);
			this.Img_Icon = this.Tmp.GetComponent<Image>();
			if (this.GUIM.IsArabic)
			{
				this.Img_Icon.gameObject.AddComponent<ArabicItemTextureRot>();
			}
			this.Img_Icon.sprite = this.SArray.m_Sprites[24];
			this.Img_Icon.SetNativeSize();
			this.Mask_T = this.GameT.GetChild(1);
			this.Tmp = this.Mask_T.GetChild(0);
			this.ContentRT = this.Tmp.GetComponent<RectTransform>();
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
			this.Img_Hero = this.Tmp1.gameObject.GetComponent<Image>();
			this.Img_Hero.material = this.GUIM.m_IconSpriteAsset.GetMaterial();
			this.baseline = this.GameT.GetChild(0).GetChild(8);
			this.rectBaseLine = this.GameT.GetChild(0).GetChild(8).GetChild(0).gameObject.GetComponent<RectTransform>();
			this.rectBaseLineBtn = this.GameT.GetChild(0).GetChild(8).gameObject.GetComponent<RectTransform>();
			this.btn_Name = this.GameT.GetChild(0).GetChild(8).gameObject.GetComponent<UIButton>();
			this.btn_Name.m_Handler = this;
			this.btn_Name.m_BtnID1 = 18;
			this.btn_Name.m_BtnID2 = 1;
			UIButton component = this.Tmp.GetChild(0).GetComponent<UIButton>();
			component.m_Handler = this;
			component.m_BtnID1 = 18;
			component.m_BtnID2 = 2;
			component.m_EffectType = e_EffectType.e_Scale;
			component.transition = Selectable.Transition.None;
			this.tmpRC = this.Tmp1.GetComponent<RectTransform>();
			this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
			this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(1);
			this.Img_HeroF = this.Tmp1.gameObject.GetComponent<Image>();
			this.Img_HeroF.sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, 11);
			this.Img_HeroF.material = this.GUIM.GetFrameMaterial();
			this.tmpRC = this.Tmp1.GetComponent<RectTransform>();
			this.tmpRC.anchorMin = Vector2.zero;
			this.tmpRC.anchorMax = new Vector2(1f, 1f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.Tmp1 = this.Tmp.GetChild(6);
			this.tmpRC = this.Tmp1.GetComponent<RectTransform>();
			this.text_Contents = this.Tmp1.GetComponent<UIText>();
			this.text_Contents.font = this.TTFont;
			this.text_Contents.SetCheckArabic(true);
			this.tmpHeight = 22f + this.text_Contents.preferredHeight + 1f + 24f;
			this.Tmp1 = this.Tmp.GetChild(1);
			this.tmpRC = this.Tmp1.GetComponent<RectTransform>();
			this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x, -this.tmpHeight);
			this.tmpHeight += 41f;
			this.BookMarkT = this.Tmp.GetChild(2);
			this.tmpRC = this.BookMarkT.GetComponent<RectTransform>();
			this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x, -this.tmpHeight);
			this.Img_BookMarkList[0] = this.BookMarkT.GetChild(0).GetComponent<Image>();
			this.Img_BookMarkList[0].sprite = this.SArray.m_Sprites[5];
			this.btn_BookMarkList[0] = this.BookMarkT.GetChild(1).GetComponent<UIButton>();
			this.btn_BookMarkList[0].m_Handler = this;
			this.btn_BookMarkList[0].m_BtnID1 = 7;
			this.btn_BookMarkList[0].m_BtnID2 = 1;
			this.BookMark_XYRT[0] = this.BookMarkT.GetChild(0).GetChild(0).GetComponent<RectTransform>();
			this.btn_BookMarkListXY[0] = this.BookMarkT.GetChild(0).GetChild(0).GetComponent<UIButton>();
			this.btn_BookMarkListXY[0].m_Handler = this;
			this.btn_BookMarkListXY[0].m_BtnID1 = 13;
			this.btn_BookMarkListXY[0].m_BtnID2 = 1;
			this.BookMark_TextRT[0] = this.BookMarkT.GetChild(0).GetChild(1).GetComponent<RectTransform>();
			this.text_BookMarkList[0] = this.BookMarkT.GetChild(0).GetChild(1).GetComponent<UIText>();
			this.text_BookMarkList[0].font = this.TTFont;
			this.text_BookMarkList2[0] = this.BookMarkT.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
			this.text_BookMarkList2[0].font = this.TTFont;
			this.BookMarkList[0] = this.BookMarkT;
			this.tmpHeight += 57f;
			this.Tmp1 = this.Tmp.GetChild(3);
			this.btn_Translation = this.Tmp1.GetComponent<UIButton>();
			this.btn_Translation.m_Handler = this;
			this.btn_Translation.m_BtnID1 = 17;
			this.TranslationRT = this.Tmp1.GetComponent<RectTransform>();
			this.Tmp1 = this.Tmp.GetChild(4);
			this.Img_Translate = this.Tmp1.GetComponent<Image>();
			this.Tmp1 = this.Tmp.GetChild(5);
			this.text_Translation = this.Tmp1.GetComponent<UIText>();
			this.text_Translation.font = this.TTFont;
			this.Letter_T = this.GameT.GetChild(2);
			this.Tmp = this.Letter_T.GetChild(0);
			this.btn_Delete = this.Tmp.GetComponent<UIButton>();
			this.btn_Delete.m_Handler = this;
			this.btn_Delete.m_BtnID1 = 3;
			this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
			this.btn_Delete.transition = Selectable.Transition.None;
			this.DeleteRT = this.Tmp.GetComponent<RectTransform>();
			this.Tmp = this.Letter_T.GetChild(1);
			this.btn_Collect = this.Tmp.GetComponent<UIButton>();
			this.btn_Collect.m_Handler = this;
			this.btn_Collect.m_BtnID1 = 5;
			this.btn_Collect.m_EffectType = e_EffectType.e_Scale;
			this.btn_Collect.transition = Selectable.Transition.None;
			this.CollectRT = this.Tmp.GetComponent<RectTransform>();
			this.Tmp = this.Letter_T.GetChild(2);
			this.btn_Reply = this.Tmp.GetComponent<UIButton>();
			this.btn_Reply.m_Handler = this;
			this.btn_Reply.m_BtnID1 = 6;
			this.btn_Reply.m_EffectType = e_EffectType.e_Scale;
			this.btn_Reply.transition = Selectable.Transition.None;
			this.ReplyRT = this.Tmp.GetComponent<RectTransform>();
			this.Letter_S_T = this.GameT.GetChild(3);
			this.Mask_T2 = this.Letter_S_T.GetChild(0);
			this.Mask_S_SR = this.Mask_T2.GetComponent<CScrollRect>();
			this.Tmp = this.Mask_T2.GetChild(0);
			this.Content_RT2 = this.Tmp.GetComponent<RectTransform>();
			this.Tmp = this.Mask_T2.GetChild(0).GetChild(0);
			this.Img_Hero_S = this.Tmp.GetChild(0).GetComponent<Image>();
			this.Img_Hero_S.material = this.GUIM.m_IconSpriteAsset.GetMaterial();
			this.tmpRC = this.Tmp.GetChild(0).GetComponent<RectTransform>();
			this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
			this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.Img_HeroF_S = this.Tmp.GetChild(1).GetComponent<Image>();
			this.Img_HeroF_S.sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, 11);
			this.Img_HeroF_S.material = this.GUIM.GetFrameMaterial();
			this.tmpRC = this.Tmp.GetChild(1).GetComponent<RectTransform>();
			this.tmpRC.anchorMin = Vector2.zero;
			this.tmpRC.anchorMax = new Vector2(1f, 1f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.text_Contents_S = this.Tmp.GetChild(2).GetComponent<UIText>();
			this.text_Contents_S.font = this.TTFont;
			this.text_Contents_S.SetCheckArabic(true);
			this.Tmp = this.Letter_S_T.GetChild(1);
			this.Img_HeroSkill[0] = this.Tmp.GetComponent<Image>();
			this.Img_HeroSkill_1[0] = this.Tmp.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();
			this.Img_HeroSkill_1[0].material = this.GUIM.GetSkillMaterial();
			UIButton component2 = this.Tmp.GetChild(1).GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 11;
			UIButtonHint uibuttonHint = this.Tmp.GetChild(1).gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.ControlFadeOut = this.GUIM.m_SkillInfo.m_RectTransform.gameObject;
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			this.tmpRC = this.Tmp.GetChild(1).GetChild(0).GetChild(0).GetComponent<RectTransform>();
			this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
			this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.Img_HeroSkill_1[1] = this.Tmp.GetChild(1).GetChild(0).GetChild(1).GetComponent<Image>();
			this.Img_HeroSkill_1[1].sprite = this.GUIM.LoadFrameSprite("sk");
			this.Img_HeroSkill_1[1].material = this.GUIM.GetFrameMaterial();
			this.tmpRC = this.Tmp.GetChild(1).GetChild(0).GetChild(1).GetComponent<RectTransform>();
			this.tmpRC.anchorMin = Vector2.zero;
			this.tmpRC.anchorMax = new Vector2(1f, 1f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.text_tmpStr[0] = this.Tmp.GetChild(2).GetComponent<UIText>();
			this.text_tmpStr[0].font = this.TTFont;
			this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(369u);
			this.text_Skill_1[0] = this.Tmp.GetChild(3).GetComponent<UIText>();
			this.text_Skill_1[0].font = this.TTFont;
			this.text_Skill_1[1] = this.Tmp.GetChild(4).GetComponent<UIText>();
			this.text_Skill_1[1].font = this.TTFont;
			this.Tmp = this.Letter_S_T.GetChild(2);
			this.Img_HeroSkill[1] = this.Tmp.GetComponent<Image>();
			this.Img_HeroSkill_2[0] = this.Tmp.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();
			this.Img_HeroSkill_2[0].material = this.GUIM.GetSkillMaterial();
			component2 = this.Tmp.GetChild(1).GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 12;
			uibuttonHint = this.Tmp.GetChild(1).gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.ControlFadeOut = this.GUIM.m_SkillInfo.m_RectTransform.gameObject;
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			this.tmpRC = this.Tmp.GetChild(1).GetChild(0).GetChild(0).GetComponent<RectTransform>();
			this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
			this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.Img_HeroSkill_2[1] = this.Tmp.GetChild(1).GetChild(0).GetChild(1).GetComponent<Image>();
			this.Img_HeroSkill_2[1].sprite = this.GUIM.LoadFrameSprite("sk");
			this.Img_HeroSkill_2[1].material = this.GUIM.GetFrameMaterial();
			this.tmpRC = this.Tmp.GetChild(1).GetChild(0).GetChild(1).GetComponent<RectTransform>();
			this.tmpRC.anchorMin = Vector2.zero;
			this.tmpRC.anchorMax = new Vector2(1f, 1f);
			this.tmpRC.offsetMin = Vector2.zero;
			this.tmpRC.offsetMax = Vector2.zero;
			this.text_tmpStr[1] = this.Tmp.GetChild(2).GetComponent<UIText>();
			this.text_tmpStr[1].font = this.TTFont;
			this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(33u);
			this.text_Skill_2[0] = this.Tmp.GetChild(3).GetComponent<UIText>();
			this.text_Skill_2[0].font = this.TTFont;
			this.text_Skill_2[1] = this.Tmp.GetChild(4).GetComponent<UIText>();
			this.text_Skill_2[1].font = this.TTFont;
			this.btn_AllianceInvite_S = this.Letter_S_T.GetChild(3).GetComponent<UIButton>();
			this.btn_AllianceInvite_S.m_Handler = this;
			this.btn_AllianceInvite_S.m_BtnID1 = 10;
			this.btn_AllianceInvite_S.m_EffectType = e_EffectType.e_Scale;
			this.btn_AllianceInvite_S.transition = Selectable.Transition.None;
			this.text_tmpStr[2] = this.Letter_S_T.GetChild(3).GetChild(1).GetComponent<UIText>();
			this.text_tmpStr[2].font = this.TTFont;
			this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(6087u);
			this.btn_Delete_S = this.Letter_S_T.GetChild(4).GetComponent<UIButton>();
			this.btn_Delete_S.m_Handler = this;
			this.btn_Delete_S.m_BtnID1 = 8;
			this.btn_Delete_S.m_EffectType = e_EffectType.e_Scale;
			this.btn_Delete_S.transition = Selectable.Transition.None;
			this.btn_Collect_S = this.Letter_S_T.GetChild(5).GetComponent<UIButton>();
			this.btn_Collect_S.m_Handler = this;
			this.btn_Collect_S.m_BtnID1 = 9;
			this.btn_Collect_S.m_EffectType = e_EffectType.e_Scale;
			this.btn_Collect_S.transition = Selectable.Transition.None;
			if (this.mLetterKind == 1 && (this.SC.Type == NoticeReport.Enotice_ActivityDegreePrize || this.SC.Type == NoticeReport.Enotice_ActivityRankPrize || this.SC.Type == NoticeReport.Enotice_ActivityKVKDegreePrize || this.SC.Type == NoticeReport.Enotice_ActivityKVKRankPrize || this.SC.Type == NoticeReport.Enotice_AMRankPrize || this.SC.Type == NoticeReport.Enotice_WorldKingPrize || this.SC.Type == NoticeReport.Enotice_WorldNotKingPrize || this.SC.Type == NoticeReport.Enotice_FederalRankPrize))
			{
				this.Tmp = this.Letter_S_T.GetChild(6);
				this.Img_S_Activity_BG = this.Tmp.GetComponent<Image>();
				this.m_ScrollPanel = this.Tmp.GetChild(1).GetComponent<ScrollPanel>();
				this.m_ScrollPanel.m_ScrollPanelID = 1;
				this.Tmp1 = this.Tmp.GetChild(2);
				this.Img_S_Title = this.Tmp1.GetChild(0).GetChild(0).GetComponent<Image>();
				this.Img_S_Crystal = this.Tmp1.GetChild(0).GetChild(1).GetComponent<Image>();
				this.Tmp = this.Tmp1.GetChild(0).GetChild(0).GetChild(0);
				this.text_S_Title = this.Tmp.GetComponent<UIText>();
				this.text_S_Title.font = this.TTFont;
				for (int num3 = 0; num3 < 3; num3++)
				{
					this.Tmp = this.Tmp1.GetChild(0).GetChild(2 + num3);
					this.text_S_Top[num3] = this.Tmp.GetComponent<UIText>();
					this.text_S_Top[num3].font = this.TTFont;
				}
				this.Tmp = this.Tmp1.GetChild(1);
				for (int num4 = 0; num4 < 5; num4++)
				{
					UIHIBtn component3 = this.Tmp.GetChild(num4).GetComponent<UIHIBtn>();
					this.GUIM.InitianHeroItemImg(component3.transform, eHeroOrItem.Item, 0, 0, 0, 0, true, true, true, false);
					UILEBtn component4 = this.Tmp.GetChild(num4 + 5).GetComponent<UILEBtn>();
					this.GUIM.InitLordEquipImg(component4.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
					component4.gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
					this.tmptext = this.Tmp.GetChild(num4 + 10).GetComponent<UIText>();
					this.tmptext.font = this.TTFont;
				}
				component2 = this.Tmp1.GetChild(2).GetChild(0).GetComponent<UIButton>();
				component2.m_Handler = this;
				component2.m_BtnID1 = 15;
				this.text_tmpStr[3] = this.Tmp1.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
				this.text_tmpStr[3].font = this.TTFont;
				this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(8244u);
			}
			if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.Enotice_SynLordEquip)
			{
				this.Tmp = this.Letter_S_T.GetChild(7);
				this.Img_LordEquip_BG = this.Tmp.GetComponent<Image>();
				this.Tmp = this.Letter_S_T.GetChild(7).GetChild(0);
				for (int num5 = 0; num5 < 2; num5++)
				{
					this.text_LordEquip[num5] = this.Tmp.GetChild(num5).GetComponent<UIText>();
					this.text_LordEquip[num5].font = this.TTFont;
				}
				this.Tmp = this.Letter_S_T.GetChild(7).GetChild(1);
				this.mLebtn = this.Tmp.GetComponent<UILEBtn>();
				this.mLebtn.m_Handler = this;
				this.Tmp = this.Letter_S_T.GetChild(7).GetChild(3);
				this.text_LordEquip_Lv = this.Tmp.GetComponent<UIText>();
				this.text_LordEquip_Lv.font = this.TTFont;
				for (int num6 = 0; num6 < 6; num6++)
				{
					this.Tmp = this.Letter_S_T.GetChild(7).GetChild(4 + num6);
					this.text_LordEquip_Effect[num6][0] = this.Tmp.GetComponent<UIText>();
					this.text_LordEquip_Effect[num6][0].font = this.TTFont;
					this.Tmp = this.Letter_S_T.GetChild(7).GetChild(10 + num6);
					this.text_LordEquip_Effect[num6][1] = this.Tmp.GetComponent<UIText>();
					this.text_LordEquip_Effect[num6][1].font = this.TTFont;
				}
			}
			if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.Enotice_CryptFinish)
			{
				this.Tmp = this.Letter_S_T.GetChild(8);
				this.Img_CryptFinish_BG = this.Tmp.GetComponent<Image>();
				this.Tmp1 = this.Tmp.GetChild(1).GetChild(0);
				this.text_CryptFinish = this.Tmp1.GetComponent<UIText>();
				this.text_CryptFinish.font = this.TTFont;
				this.text_CryptFinish.rectTransform.sizeDelta = new Vector2(200f, this.text_CryptFinish.rectTransform.sizeDelta.y);
				this.text_CryptFinish.resizeTextForBestFit = true;
				this.Tmp1 = this.Tmp.GetChild(2);
				this.text_tmpStr[4] = this.Tmp1.GetComponent<UIText>();
				this.text_tmpStr[4].font = this.TTFont;
				this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(8228u);
			}
			if (this.mLetterKind == 1 && (this.SC.Type == NoticeReport.Enotice_BuyTreasure || this.SC.Type == NoticeReport.Enotice_BuyBlackMarketTreasure || this.SC.Type == NoticeReport.Enotice_BackendActivity || this.SC.Type == NoticeReport.Enotice_TreasureBackPrize || this.SC.Type == NoticeReport.Enotice_MaintainCompensation || this.SC.Type == NoticeReport.Enotice_ReturnCeremony || this.SC.Type == NoticeReport.Enotice_FirstBuyTreasurePrize))
			{
				this.Tmp = this.Letter_S_T.GetChild(9);
				this.Img_BuyTreasure_BG = this.Tmp.GetComponent<Image>();
				this.m_ScrollPanel_Buy = this.Tmp.GetChild(0).GetComponent<ScrollPanel>();
				this.m_ScrollPanel_Buy.m_ScrollPanelID = 2;
				this.GUIM.InitianHeroItemImg(this.Tmp.GetChild(1).GetChild(2), eHeroOrItem.Item, 1, 0, 0, 0, false, true, true, false);
				this.GUIM.InitLordEquipImg(this.Tmp.GetChild(1).GetChild(3), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
				this.Tmp.GetChild(1).GetChild(3).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
				this.Tmp1 = this.Tmp.GetChild(1).GetChild(4);
				this.tmptext = this.Tmp1.GetComponent<UIText>();
				this.tmptext.font = this.TTFont;
				this.Tmp1 = this.Tmp.GetChild(1).GetChild(5);
				this.tmptext = this.Tmp1.GetComponent<UIText>();
				this.tmptext.font = this.TTFont;
			}
			if (this.mLetterKind == 2)
			{
				this.MonsterXY_T = this.Letter_S_T.GetChild(10);
				this.btn_MonsterXY = this.MonsterXY_T.GetChild(0).GetComponent<UIButton>();
				this.btn_MonsterXY.m_Handler = this;
				this.btn_MonsterXY.m_BtnID1 = 14;
				this.Tmp = this.MonsterXY_T.GetChild(0).GetChild(1);
				this.text_MonsterXY = this.Tmp.GetComponent<UIText>();
				this.text_MonsterXY.font = this.TTFont;
			}
			if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.ENotice_StarUp)
			{
				this.HeroStarUp_T = this.Letter_S_T.GetChild(11);
				this.text_tmpStr[5] = this.HeroStarUp_T.GetChild(0).GetChild(0).GetComponent<UIText>();
				this.text_tmpStr[5].font = this.TTFont;
				this.text_tmpStr[5].text = this.DM.mStringTable.GetStringByID(369u);
				for (int num7 = 0; num7 < 4; num7++)
				{
					component2 = this.HeroStarUp_T.GetChild(1 + num7).GetComponent<UIButton>();
					component2.m_Handler = this;
					component2.m_BtnID1 = 16;
					component2.m_BtnID2 = num7;
					uibuttonHint = this.HeroStarUp_T.GetChild(1 + num7).gameObject.AddComponent<UIButtonHint>();
					uibuttonHint.ControlFadeOut = this.GUIM.m_SkillInfo.m_RectTransform.gameObject;
					uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
					uibuttonHint.m_Handler = this;
					this.tmpRC = this.HeroStarUp_T.GetChild(1 + num7).GetChild(0).GetChild(0).GetComponent<RectTransform>();
					this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
					this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
					this.tmpRC.offsetMin = Vector2.zero;
					this.tmpRC.offsetMax = Vector2.zero;
					this.Img_StarUpSkill[num7] = this.HeroStarUp_T.GetChild(1 + num7).GetChild(0).GetChild(0).GetComponent<Image>();
					this.Img_StarUpSkill[num7].material = this.GUIM.GetSkillMaterial();
					this.tmpImg = this.HeroStarUp_T.GetChild(1 + num7).GetChild(0).GetChild(1).GetComponent<Image>();
					this.tmpImg.sprite = this.GUIM.LoadFrameSprite("sk");
					this.tmpImg.material = this.GUIM.GetFrameMaterial();
					this.tmpRC = this.HeroStarUp_T.GetChild(1 + num7).GetChild(0).GetChild(1).GetComponent<RectTransform>();
					this.tmpRC.anchorMin = Vector2.zero;
					this.tmpRC.anchorMax = new Vector2(1f, 1f);
					this.tmpRC.offsetMin = Vector2.zero;
					this.tmpRC.offsetMax = Vector2.zero;
					this.Img_StarUpSkill_2[num7] = this.HeroStarUp_T.GetChild(5 + num7).GetComponent<Image>();
					this.Img_StarUpSkill_2[num7].sprite = this.GUIM.LoadFrameSprite("UI_box_hero_dark_01");
					this.Img_StarUpSkill_2[num7].material = this.GUIM.GetFrameMaterial();
					this.text_StarUp_1[num7] = this.HeroStarUp_T.GetChild(5 + num7).GetChild(0).GetComponent<UIText>();
					this.text_StarUp_1[num7].font = this.TTFont;
					this.text_StarUp_2[num7] = this.HeroStarUp_T.GetChild(5 + num7).GetChild(1).GetComponent<UIText>();
					this.text_StarUp_2[num7].font = this.TTFont;
					this.text_StarUp_2[num7].text = this.DM.mStringTable.GetStringByID(115u);
					this.Img_StarUpSkill_L[num7] = this.HeroStarUp_T.GetChild(9 + num7).GetComponent<Image>();
				}
			}
			if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.Enotice_RecivedGift)
			{
				this.Gifts_T = this.Letter_S_T.GetChild(12);
				this.GiftsHbtn_Item = this.Gifts_T.GetChild(0).GetComponent<UIHIBtn>();
				this.GUIM.InitianHeroItemImg(this.GiftsHbtn_Item.transform, eHeroOrItem.Item, this.SC.Enotice_RecivedGift.Item.ItemID, 0, 0, 0, true, true, true, false);
				this.text_Gifts[0] = this.Gifts_T.GetChild(1).GetComponent<UIText>();
				this.text_Gifts[0].font = this.TTFont;
				this.Cstr_Gifts[0].ClearString();
				Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(this.SC.Enotice_RecivedGift.Item.ItemID);
				this.Cstr_Gifts[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.EquipName));
				this.Cstr_Gifts[0].AppendFormat("{0}");
				this.text_Gifts[0].text = this.Cstr_Gifts[0].ToString();
				this.text_Gifts[1] = this.Gifts_T.GetChild(2).GetComponent<UIText>();
				this.text_Gifts[1].font = this.TTFont;
				StringManager.IntToStr(this.Cstr_Gifts[1], (long)this.SC.Enotice_RecivedGift.Item.ItemNum, 1, true);
				this.text_Gifts[1].text = this.Cstr_Gifts[1].ToString();
			}
			if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.Enotice_RulerGift)
			{
				this.Gifts_T = this.Letter_S_T.GetChild(12);
				this.GiftsHbtn_Item = this.Gifts_T.GetChild(0).GetComponent<UIHIBtn>();
				this.GUIM.InitianHeroItemImg(this.GiftsHbtn_Item.transform, eHeroOrItem.Item, this.SC.Enotice_RulerGift.Gifts[0].ItemID, 0, 0, 0, true, true, true, false);
				this.text_Gifts[0] = this.Gifts_T.GetChild(1).GetComponent<UIText>();
				this.text_Gifts[0].font = this.TTFont;
				this.Cstr_Gifts[0].ClearString();
				Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(this.SC.Enotice_RulerGift.Gifts[0].ItemID);
				this.Cstr_Gifts[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey2.EquipName));
				this.Cstr_Gifts[0].AppendFormat("{0}");
				this.text_Gifts[0].text = this.Cstr_Gifts[0].ToString();
				this.text_Gifts[1] = this.Gifts_T.GetChild(2).GetComponent<UIText>();
				this.text_Gifts[1].font = this.TTFont;
				StringManager.IntToStr(this.Cstr_Gifts[1], (long)this.SC.Enotice_RulerGift.Gifts[0].ItemNum, 1, true);
				this.text_Gifts[1].text = this.Cstr_Gifts[1].ToString();
			}
			if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.Enotice_BuyEmoteTreasure)
			{
				this.Gifts_T = this.Letter_S_T.GetChild(12);
				this.GiftsHbtn_Item = this.Gifts_T.GetChild(0).GetComponent<UIHIBtn>();
				this.GUIM.InitianHeroItemImg(this.GiftsHbtn_Item.transform, eHeroOrItem.Item, this.SC.Enotice_BuyEmoteTreasure.ItemID, 0, 0, 0, true, true, true, false);
				this.text_Gifts[0] = this.Gifts_T.GetChild(1).GetComponent<UIText>();
				this.text_Gifts[0].font = this.TTFont;
				this.Cstr_Gifts[0].ClearString();
				Equip recordByKey3 = DataManager.Instance.EquipTable.GetRecordByKey(this.SC.Enotice_BuyEmoteTreasure.ItemID);
				this.Cstr_Gifts[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey3.EquipName));
				this.Cstr_Gifts[0].AppendFormat("{0}");
				this.text_Gifts[0].text = this.Cstr_Gifts[0].ToString();
				this.text_Gifts[1] = this.Gifts_T.GetChild(2).GetComponent<UIText>();
				this.text_Gifts[1].font = this.TTFont;
				StringManager.IntToStr(this.Cstr_Gifts[1], (long)this.SC.Enotice_BuyEmoteTreasure.ItemNum, 1, true);
				this.text_Gifts[1].text = this.Cstr_Gifts[1].ToString();
			}
			if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.Enotice_BuyCastleSkinTreasure)
			{
				this.Gifts_T = this.Letter_S_T.GetChild(12);
				if (this.SC.Enotice_BuyCastleSkinTreasure.ItemID > 0)
				{
					this.GiftsHbtn_Item = this.Gifts_T.GetChild(0).GetComponent<UIHIBtn>();
					this.GUIM.InitianHeroItemImg(this.GiftsHbtn_Item.transform, eHeroOrItem.Item, this.SC.Enotice_BuyCastleSkinTreasure.ItemID, 0, 0, 0, true, true, true, false);
					this.text_Gifts[0] = this.Gifts_T.GetChild(1).GetComponent<UIText>();
					this.text_Gifts[0].font = this.TTFont;
					this.Cstr_Gifts[0].ClearString();
					Equip recordByKey4 = DataManager.Instance.EquipTable.GetRecordByKey(this.SC.Enotice_BuyCastleSkinTreasure.ItemID);
					this.Cstr_Gifts[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey4.EquipName));
					this.Cstr_Gifts[0].AppendFormat("{0}");
					this.text_Gifts[0].text = this.Cstr_Gifts[0].ToString();
					this.text_Gifts[1] = this.Gifts_T.GetChild(2).GetComponent<UIText>();
					this.text_Gifts[1].font = this.TTFont;
					StringManager.IntToStr(this.Cstr_Gifts[1], (long)this.SC.Enotice_BuyCastleSkinTreasure.ItemNum, 1, true);
					this.text_Gifts[1].text = this.Cstr_Gifts[1].ToString();
					this.Gifts_T.gameObject.SetActive(true);
				}
			}
			if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.Enotice_AutoDismiss)
			{
				this.btn_JoinAlliance = this.Letter_S_T.GetChild(13).GetComponent<UIButton>();
				this.btn_JoinAlliance.m_Handler = this;
				this.btn_JoinAlliance.m_BtnID1 = 19;
				this.btn_JoinAlliance.m_EffectType = e_EffectType.e_Scale;
				this.btn_JoinAlliance.transition = Selectable.Transition.None;
				this.btn_JoinAlliance.gameObject.SetActive(true);
				this.text_tmpStr[6] = this.Letter_S_T.GetChild(13).GetChild(1).GetComponent<UIText>();
				this.text_tmpStr[6].font = this.TTFont;
				this.text_tmpStr[6].text = this.DM.mStringTable.GetStringByID(4610u);
			}
			this.PreviousT = this.GameT.GetChild(4);
			this.btn_Previous = this.PreviousT.GetComponent<UIButton>();
			this.btn_Previous.m_Handler = this;
			this.btn_Previous.m_BtnID1 = 1;
			this.btn_Previous.m_EffectType = e_EffectType.e_Scale;
			this.btn_Previous.transition = Selectable.Transition.None;
			this.NextT = this.GameT.GetChild(5);
			this.btn_Next = this.NextT.GetComponent<UIButton>();
			this.btn_Next.m_Handler = this;
			this.btn_Next.m_BtnID1 = 2;
			this.btn_Next.m_EffectType = e_EffectType.e_Scale;
			this.btn_Next.transition = Selectable.Transition.None;
			float x = this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x;
			this.tempL = (this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x - 853f) / 2f;
			if (this.tempL > 0f && this.NextT.localPosition.x + this.tempL > x / 2f)
			{
				this.tempL = x / 2f - this.NextT.localPosition.x;
			}
			this.MoveTime1 = this.NextT.localPosition.x + this.tempL;
			this.MoveTime2 = this.PreviousT.localPosition.x - this.tempL;
			if (this.GUIM.bOpenOnIPhoneX)
			{
				this.MoveTime1 -= this.GUIM.IPhoneX_DeltaX;
				this.MoveTime2 += this.GUIM.IPhoneX_DeltaX;
			}
			this.Vec3Instance.Set(this.MoveTime1, this.NextT.localPosition.y, this.NextT.localPosition.z);
			this.NextT.localPosition = this.Vec3Instance;
			this.Vec3Instance.Set(this.MoveTime2, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
			this.PreviousT.localPosition = this.Vec3Instance;
			this.SetLetterData();
			if (this.mLetterKind == 1)
			{
				if (this.SC.Type == NoticeReport.Enotice_ActivityDegreePrize || this.SC.Type == NoticeReport.Enotice_ActivityRankPrize || this.SC.Type == NoticeReport.Enotice_ActivityKVKDegreePrize || this.SC.Type == NoticeReport.Enotice_ActivityKVKRankPrize || this.SC.Type == NoticeReport.Enotice_AMRankPrize || this.SC.Type == NoticeReport.Enotice_WorldKingPrize || this.SC.Type == NoticeReport.Enotice_WorldNotKingPrize || this.SC.Type == NoticeReport.Enotice_FederalRankPrize)
				{
					this.Img_S_Activity_BG.gameObject.SetActive(true);
					int num8 = 0;
					switch (this.mPrizeType)
					{
					case Detail_Prize.Enotice_ActivityDegreePrize:
						num8 = (int)(20 - this.SC.Notice_ActivityDegreePrize.Degree);
						this.text_S_Title.text = this.DM.mStringTable.GetStringByID((uint)((ushort)(7689 + (int)this.SC.Notice_ActivityDegreePrize.Degree)));
						break;
					case Detail_Prize.Enotice_ActivityRankPrize:
						switch (this.SC.Notice_ActivityRankPrize.Place)
						{
						case 1:
						case 2:
						case 3:
							num8 = (int)(16 + this.SC.Notice_ActivityRankPrize.Place);
							break;
						default:
							num8 = 20;
							break;
						}
						this.Cstr_S_Title.IntToFormat((long)this.SC.Notice_ActivityRankPrize.Place, 1, true);
						this.Cstr_S_Title.AppendFormat(this.DM.mStringTable.GetStringByID(7694u));
						this.text_S_Title.text = this.Cstr_S_Title.ToString();
						break;
					case Detail_Prize.Enotice_ActivityKVKDegreePrize:
						num8 = (int)(20 - this.SC.Enotice_ActivityKVKDegreePrize.Degree);
						this.text_S_Title.text = this.DM.mStringTable.GetStringByID((uint)((ushort)(7689 + (int)this.SC.Enotice_ActivityKVKDegreePrize.Degree)));
						break;
					case Detail_Prize.Enotice_ActivityKVKRankPrize:
						switch (this.SC.Enotice_ActivityKVKRankPrize.Place)
						{
						case 1:
						case 2:
						case 3:
							num8 = (int)(16 + this.SC.Enotice_ActivityKVKRankPrize.Place);
							break;
						default:
							num8 = 20;
							break;
						}
						this.Cstr_S_Title.IntToFormat((long)this.SC.Enotice_ActivityKVKRankPrize.Place, 1, true);
						this.Cstr_S_Title.AppendFormat(this.DM.mStringTable.GetStringByID(7694u));
						this.text_S_Title.text = this.Cstr_S_Title.ToString();
						break;
					case Detail_Prize.Enotice_AMRankPrize:
						switch (this.SC.Enotice_AMRankPrize.Place)
						{
						case 1:
						case 2:
						case 3:
							num8 = (int)(16 + this.SC.Enotice_AMRankPrize.Place);
							break;
						default:
							num8 = 20;
							break;
						}
						this.Cstr_S_Title.IntToFormat((long)this.SC.Enotice_AMRankPrize.Place, 1, true);
						this.Cstr_S_Title.AppendFormat(this.DM.mStringTable.GetStringByID(7694u));
						this.text_S_Title.text = this.Cstr_S_Title.ToString();
						break;
					case Detail_Prize.Enotice_WorldKingPrize:
					case Detail_Prize.Enotice_WorldNotKingPrize:
						num8 = 17;
						this.Cstr_S_Title.Append(this.DM.mStringTable.GetStringByID(11023u));
						this.text_S_Title.text = this.Cstr_S_Title.ToString();
						break;
					case Detail_Prize.Enotice_FederalRankPrize:
						num8 = 17;
						this.Cstr_S_Title.Append(this.DM.mStringTable.GetStringByID(11091u));
						this.text_S_Title.text = this.Cstr_S_Title.ToString();
						break;
					}
					this.Img_S_Title.sprite = this.SArray.m_Sprites[num8];
					for (int num9 = 0; num9 < 3; num9++)
					{
						this.Cstr_S_Top[num9].ClearString();
					}
					this.Cstr_S_Top[0].IntToFormat((long)((ulong)this.mDiamond), 1, true);
					if (this.GUIM.IsArabic)
					{
						this.Cstr_S_Top[0].AppendFormat("{0}x");
					}
					else
					{
						this.Cstr_S_Top[0].AppendFormat("x{0}");
					}
					this.Cstr_S_Top[1].IntToFormat((long)((ulong)this.mValue), 1, true);
					this.Cstr_S_Top[1].AppendFormat(this.DM.mStringTable.GetStringByID(8122u));
					this.Cstr_S_Top[2].IntToFormat((long)this.mNoValueCount, 1, true);
					this.Cstr_S_Top[2].AppendFormat(this.DM.mStringTable.GetStringByID(8123u));
					this.text_S_Title.SetAllDirty();
					this.text_S_Title.cachedTextGenerator.Invalidate();
					for (int num10 = 0; num10 < 3; num10++)
					{
						this.text_S_Top[num10].text = this.Cstr_S_Top[num10].ToString();
						this.text_S_Top[num10].SetAllDirty();
						this.text_S_Top[num10].cachedTextGenerator.Invalidate();
					}
					if (this.mDiamond == 0u)
					{
						this.Img_S_Crystal.gameObject.SetActive(false);
						this.text_S_Top[0].gameObject.SetActive(false);
					}
					else
					{
						this.Img_S_Crystal.gameObject.SetActive(true);
						this.text_S_Top[0].gameObject.SetActive(true);
					}
					if (this.mNoValueCount == 0)
					{
						this.text_S_Top[2].gameObject.SetActive(false);
					}
					else
					{
						this.text_S_Top[2].gameObject.SetActive(true);
					}
					this.tmplist.Clear();
					this.tmplist.Add(131f);
					for (int num11 = 0; num11 < (this.tmplistItem.Count - 1) / 5 + 1; num11++)
					{
						this.tmplist.Add(62f);
					}
					this.tmplist.Add(62f);
					this.m_ScrollPanel.IntiScrollPanel(490f, 0f, 0f, this.tmplist, 6, this);
					UIButtonHint.scrollRect = this.m_ScrollPanel.transform.GetComponent<CScrollRect>();
				}
				if (this.SC.Type == NoticeReport.Enotice_BuyTreasure)
				{
					this.Img_BuyTreasure_BG.gameObject.SetActive(true);
					this.ItemCount = 0;
					this.GiftTopCount = 0;
					this.tmplist.Clear();
					this.ItemCount += 1;
					this.tmplist.Add(60f);
					if (this.SC.Notice_BuyTreasure.BonusCrystal > 0u)
					{
						this.ItemCount += 1;
						this.tmplist.Add(60f);
					}
					for (int num12 = 0; num12 < (int)this.SC.Notice_BuyTreasure.ItemNum; num12++)
					{
						this.tmplist.Add(60f);
						this.ItemCount += 1;
					}
					for (int num13 = 0; num13 < this.SC.Notice_BuyTreasure.Gift.Length; num13++)
					{
						if (this.SC.Notice_BuyTreasure.Gift[num13].ItemID != 0)
						{
							this.tmplist.Add(60f);
							this.ItemCount += 1;
							this.GiftTopCount += 1;
						}
					}
					this.m_ScrollPanel_Buy.IntiScrollPanel(315f, 1f, 0f, this.tmplist, 7, this);
				}
				if (this.SC.Type == NoticeReport.Enotice_BuyBlackMarketTreasure)
				{
					this.Img_BuyTreasure_BG.gameObject.SetActive(true);
					this.ItemCount = 0;
					this.tmplist.Clear();
					if (this.SC.Enotice_BuyBlackMarketTreasure.Crystal > 0u)
					{
						this.ItemCount += 1;
						this.tmplist.Add(60f);
					}
					if (this.SC.Enotice_BuyBlackMarketTreasure.BonusCrystal > 0u)
					{
						this.ItemCount += 1;
						this.tmplist.Add(60f);
					}
					for (int num14 = 0; num14 < (int)this.SC.Enotice_BuyBlackMarketTreasure.ItemNum; num14++)
					{
						this.tmplist.Add(60f);
						this.ItemCount += 1;
					}
					for (int num15 = 0; num15 < this.SC.Enotice_BuyBlackMarketTreasure.Gift.Length; num15++)
					{
						if (this.SC.Enotice_BuyBlackMarketTreasure.Gift[num15].ItemID != 0)
						{
							this.tmplist.Add(60f);
							this.ItemCount += 1;
						}
					}
					this.m_ScrollPanel_Buy.IntiScrollPanel(315f, 1f, 0f, this.tmplist, 7, this);
				}
				if (this.SC.Type == NoticeReport.Enotice_BackendActivity)
				{
					this.Img_BuyTreasure_BG.gameObject.SetActive(true);
					this.ItemCount = 0;
					this.tmplist.Clear();
					if (this.SC.Enotice_BackendActivity.Crystal > 0u)
					{
						this.ItemCount += 1;
						this.tmplist.Add(60f);
					}
					for (int num16 = 0; num16 < (int)this.SC.Enotice_BackendActivity.ItemNum; num16++)
					{
						this.tmplist.Add(60f);
						this.ItemCount += 1;
					}
					this.m_ScrollPanel_Buy.IntiScrollPanel(315f, 1f, 0f, this.tmplist, 7, this);
				}
				if (this.SC.Type == NoticeReport.Enotice_TreasureBackPrize)
				{
					this.Img_BuyTreasure_BG.gameObject.SetActive(true);
					this.ItemCount = 0;
					this.tmplist.Clear();
					if (this.SC.Enotice_TreasureBackPrize.Crystal > 0u)
					{
						this.ItemCount += 1;
						this.tmplist.Add(60f);
					}
					if (this.SC.Enotice_TreasureBackPrize.BonusCrystal > 0u)
					{
						this.ItemCount += 1;
						this.tmplist.Add(60f);
					}
					for (int num17 = 0; num17 < (int)this.SC.Enotice_TreasureBackPrize.ItemNum; num17++)
					{
						this.tmplist.Add(60f);
						this.ItemCount += 1;
					}
					for (int num18 = 0; num18 < this.SC.Enotice_TreasureBackPrize.Gift.Length; num18++)
					{
						if (this.SC.Enotice_TreasureBackPrize.Gift[num18].ItemID != 0)
						{
							this.tmplist.Add(60f);
							this.ItemCount += 1;
						}
					}
					this.m_ScrollPanel_Buy.IntiScrollPanel(315f, 1f, 0f, this.tmplist, 7, this);
				}
				if (this.SC.Type == NoticeReport.Enotice_MaintainCompensation)
				{
					this.Img_BuyTreasure_BG.gameObject.SetActive(true);
					this.ItemCount = 0;
					this.tmplist.Clear();
					if (this.SC.Enotice_MaintainCompensation.Crystal > 0u)
					{
						this.ItemCount += 1;
						this.tmplist.Add(60f);
					}
					for (int num19 = 0; num19 < (int)this.SC.Enotice_MaintainCompensation.ItemNum; num19++)
					{
						this.tmplist.Add(60f);
						this.ItemCount += 1;
					}
					this.m_ScrollPanel_Buy.IntiScrollPanel(315f, 1f, 0f, this.tmplist, 7, this);
				}
				if (this.SC.Type == NoticeReport.Enotice_ReturnCeremony)
				{
					this.Img_BuyTreasure_BG.gameObject.SetActive(true);
					this.ItemCount = 0;
					this.tmplist.Clear();
					if (this.SC.Enotice_ReturnCeremony.Crystal > 0u)
					{
						this.ItemCount += 1;
						this.tmplist.Add(60f);
					}
					for (int num20 = 0; num20 < (int)this.SC.Enotice_ReturnCeremony.ItemNum; num20++)
					{
						this.tmplist.Add(60f);
						this.ItemCount += 1;
					}
					this.m_ScrollPanel_Buy.IntiScrollPanel(315f, 1f, 0f, this.tmplist, 7, this);
				}
				if (this.SC.Type == NoticeReport.Enotice_FirstBuyTreasurePrize)
				{
					this.Img_BuyTreasure_BG.gameObject.SetActive(true);
					this.ItemCount = 0;
					this.tmplist.Clear();
					if (this.SC.Enotice_FirstBuyTreasurePrize.Crystal > 0u)
					{
						this.ItemCount += 1;
						this.tmplist.Add(60f);
					}
					for (int num21 = 0; num21 < (int)this.SC.Enotice_FirstBuyTreasurePrize.ItemNum; num21++)
					{
						this.tmplist.Add(60f);
						this.ItemCount += 1;
					}
					this.m_ScrollPanel_Buy.IntiScrollPanel(315f, 1f, 0f, this.tmplist, 7, this);
				}
			}
			this.Cstr_Page.ClearString();
			this.Cstr_Page.IntToFormat((long)this.tmpPageNum, 1, false);
			this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Page.AppendFormat("{1}/{0}");
			}
			else
			{
				this.Cstr_Page.AppendFormat("{0}/{1}");
			}
			this.text_Page.text = this.Cstr_Page.ToString();
			this.text_Page.SetAllDirty();
			this.text_Page.cachedTextGenerator.Invalidate();
			this.text_Name.SetAllDirty();
			this.text_Name.cachedTextGenerator.Invalidate();
			this.tmpImg = this.GameT.GetChild(6).GetComponent<Image>();
			this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
			this.tmpImg.material = this.m_Mat;
			if (this.GUIM.bOpenOnIPhoneX)
			{
				this.tmpImg.enabled = false;
			}
			this.btn_EXIT = this.GameT.GetChild(6).GetChild(0).GetComponent<UIButton>();
			this.btn_EXIT.m_Handler = this;
			this.btn_EXIT.m_BtnID1 = 0;
			this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
			this.btn_EXIT.image.material = this.m_Mat;
			this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
			this.btn_EXIT.transition = Selectable.Transition.None;
			this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
			return;
		}
		this.door.CloseMenu(false);
	}

	// Token: 0x06001D62 RID: 7522 RVA: 0x003581D4 File Offset: 0x003563D4
	public void SetLetterData()
	{
		if (this.mLetterKind == 0)
		{
			if (this.MC.MailType == 1)
			{
				this.Cstr_Title.ClearString();
				this.Cstr_Title.StringToFormat(this.DM.mStringTable.GetStringByID(6014u));
				if (this.bTrans && this.MC.Translation && this.DM.CheckLanguageTranslateByIdx((int)this.MC.LanguageSource) && this.MC.LanguageTarget == (byte)this.DM.UserLanguage && this.GUIM.CheckNeedTranslate(this.MC.Title))
				{
					this.Cstr_Title.StringToFormat(this.MC.TitleT);
				}
				else
				{
					this.Cstr_Title.StringToFormat(this.MC.Title);
				}
				this.Cstr_Title.AppendFormat("{0}{1}");
				this.text_Title.text = this.Cstr_Title.ToString();
			}
			else if (this.bTrans && this.MC.Translation && this.DM.CheckLanguageTranslateByIdx((int)this.MC.LanguageSource) && this.MC.LanguageTarget == (byte)this.DM.UserLanguage && this.GUIM.CheckNeedTranslate(this.MC.Title))
			{
				this.text_Title.text = this.MC.TitleT;
			}
			else
			{
				this.text_Title.text = this.MC.Title;
			}
			if (this.DM.bPlural)
			{
				this.MaxLetterNum = this.DM.GetMailboxSize(this.MC.ReplyID, this.MC.SenderName);
				this.tmpPageNum = (int)(this.MC.MoreIndex + 1);
				if (this.MaxLetterNum > 1)
				{
					if (this.MC.MoreIndex + 1 == 1)
					{
						this.btn_Previous.gameObject.SetActive(false);
						if (!this.btn_Next.IsActive())
						{
							this.btn_Next.gameObject.SetActive(true);
						}
					}
					if ((int)(this.MC.MoreIndex + 1) == this.MaxLetterNum)
					{
						this.btn_Next.gameObject.SetActive(false);
						if (!this.btn_Previous.IsActive())
						{
							this.btn_Previous.gameObject.SetActive(true);
						}
					}
				}
				else
				{
					this.btn_Previous.gameObject.SetActive(false);
					this.btn_Next.gameObject.SetActive(false);
				}
			}
			else
			{
				this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_MAX);
				this.tmpPageNum = (int)(this.MC.Index + 1);
				if (this.MaxLetterNum > 1)
				{
					if (this.MC.Index + 1 == 1)
					{
						this.btn_Previous.gameObject.SetActive(false);
						if (!this.btn_Next.IsActive())
						{
							this.btn_Next.gameObject.SetActive(true);
						}
					}
					if ((int)(this.MC.Index + 1) == this.MaxLetterNum)
					{
						this.btn_Next.gameObject.SetActive(false);
						if (!this.btn_Previous.IsActive())
						{
							this.btn_Previous.gameObject.SetActive(true);
						}
					}
				}
				else
				{
					this.btn_Previous.gameObject.SetActive(false);
					this.btn_Next.gameObject.SetActive(false);
				}
			}
			this.text_Time[0].text = GameConstants.GetDateTime(this.MC.Times).ToString("MM/dd/yy");
			this.text_Time[1].text = GameConstants.GetDateTime(this.MC.Times).ToString("HH:mm:ss");
			CString cstring = StringManager.Instance.StaticString1024();
			CString cstring2 = StringManager.Instance.StaticString1024();
			CString cstring3 = StringManager.Instance.StaticString1024();
			if (this.MC.SenderTag.Length != 0)
			{
				this.Cstr_Name.ClearString();
				if (this.MC.MailType != 3)
				{
					if (this.MC.MailType == 4)
					{
						cstring.ClearString();
						cstring2.ClearString();
						cstring2.Append(this.MC.SenderName);
						cstring3.Append(this.MC.SenderTag);
						GameConstants.FormatRoleName(cstring, cstring2, cstring3, null, 0, 0, null, null, null, null);
						this.Cstr_Name.StringToFormat(cstring);
						this.Cstr_Name.AppendFormat(this.DM.mStringTable.GetStringByID(11055u));
					}
					else
					{
						cstring.ClearString();
						cstring2.ClearString();
						cstring.Append(this.MC.SenderName);
						cstring2.Append(this.MC.SenderTag);
						GameConstants.FormatRoleName(this.Cstr_Name, cstring, cstring2, null, 0, 0, null, null, null, null);
					}
					this.text_Name.text = this.Cstr_Name.ToString();
				}
				else
				{
					cstring.ClearString();
					cstring2.ClearString();
					cstring3.ClearString();
					cstring2.Append(this.MC.SenderName);
					cstring3.Append(this.MC.SenderTag);
					if (this.MC.SenderKindom != DataManager.MapDataController.kingdomData.kingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, this.MC.SenderKindom, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
					}
					this.Cstr_Name.StringToFormat(cstring);
					this.Cstr_Name.AppendFormat(this.DM.mStringTable.GetStringByID(1473u));
					this.text_Name.text = this.Cstr_Name.ToString();
				}
			}
			else
			{
				if (this.MC.MailType == 4)
				{
					this.Cstr_Name.StringToFormat(this.MC.SenderName);
					this.Cstr_Name.AppendFormat(this.DM.mStringTable.GetStringByID(11055u));
				}
				else
				{
					this.Cstr_Name.Append(this.MC.SenderName);
				}
				this.text_Name.text = this.Cstr_Name.ToString();
			}
			if (this.MC.MailType == 2)
			{
				this.Img_Icon.gameObject.SetActive(true);
				this.Img_BG.sprite = this.SArray.m_Sprites[23];
				this.Img_Title.gameObject.SetActive(false);
				this.Img_TitleIcon.gameObject.SetActive(false);
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Name.text = this.DM.mStringTable.GetStringByID(8252u);
				this.text_Name.rectTransform.sizeDelta = new Vector2(420f, this.text_Name.rectTransform.sizeDelta.y);
				this.text_Name.rectTransform.anchoredPosition = new Vector2(this.text_Name.rectTransform.anchoredPosition.x + this.Img_Icon.rectTransform.sizeDelta.x - 8.5f, this.text_Name.rectTransform.anchoredPosition.y);
				this.text_Title.rectTransform.anchoredPosition = new Vector2(this.text_Title.rectTransform.anchoredPosition.x - 65f, this.text_Title.rectTransform.anchoredPosition.y);
				this.DeleteRT.anchoredPosition = new Vector2(226f, this.DeleteRT.anchoredPosition.y);
				this.CollectRT.anchoredPosition = new Vector2(287f, this.CollectRT.anchoredPosition.y);
				this.ReplyRT.gameObject.SetActive(false);
				this.Cstr_Title.ClearString();
				this.Cstr_Title.StringToFormat(this.DM.mStringTable.GetStringByID(8257u));
				this.Cstr_Title.StringToFormat(this.MC.Title);
				this.Cstr_Title.AppendFormat("{0}{1}");
				this.text_Title.text = this.Cstr_Title.ToString();
			}
			else
			{
				if (this.MC.MailType == 3)
				{
					this.text_Title.text = this.DM.mStringTable.GetStringByID(1474u);
				}
				if (this.MC.MailType == 4)
				{
					this.DeleteRT.anchoredPosition = new Vector2(226f, this.DeleteRT.anchoredPosition.y);
					this.CollectRT.anchoredPosition = new Vector2(287f, this.CollectRT.anchoredPosition.y);
					this.ReplyRT.gameObject.SetActive(false);
				}
				else
				{
					this.DeleteRT.anchoredPosition = new Vector2(165f, this.DeleteRT.anchoredPosition.y);
					this.CollectRT.anchoredPosition = new Vector2(226f, this.CollectRT.anchoredPosition.y);
					this.ReplyRT.gameObject.SetActive(true);
				}
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.MC.SenderHead);
			}
			this.Img_Hero.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
			if (this.MC.MailType != 2 && this.bTrans && this.MC.Translation && this.DM.CheckLanguageTranslateByIdx((int)this.MC.LanguageSource) && this.MC.LanguageTarget == (byte)this.DM.UserLanguage)
			{
				this.text_Contents.text = this.MC.ContentT;
			}
			else
			{
				this.text_Contents.text = this.MC.Content;
			}
			this.text_Contents.SetAllDirty();
			this.text_Contents.cachedTextGeneratorForLayout.Invalidate();
			this.text_Contents.cachedTextGenerator.Invalidate();
			if (this.text_Contents.preferredHeight > 158f)
			{
				this.text_Contents.rectTransform.sizeDelta = new Vector2(this.text_Contents.rectTransform.sizeDelta.x, this.text_Contents.preferredHeight + 1f);
				if (this.bTrans)
				{
					this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, -193f - (this.text_Contents.preferredHeight + 1f - 158f) - 33f);
					this.text_Translation.rectTransform.anchoredPosition = new Vector2(this.text_Translation.rectTransform.anchoredPosition.x, -179f - (this.text_Contents.preferredHeight + 1f - 158f) - 33f);
				}
			}
			if (this.MC.MailType != 2 && this.bTrans && this.GUIM.CheckNeedTranslate(this.MC.Content) && (!this.MC.Translation || (this.MC.Translation && this.DM.CheckLanguageTranslateByIdx((int)this.MC.LanguageSource))))
			{
				this.TranslationRT.gameObject.SetActive(true);
				this.text_Translation.gameObject.SetActive(true);
				if (this.MC.Translation && this.MC.LanguageTarget == (byte)this.DM.UserLanguage)
				{
					this.Cstr_Translation.ClearString();
					this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID(this.MC.LanguageSource));
					this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054u));
					this.text_Translation.text = this.Cstr_Translation.ToString();
				}
				else
				{
					this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052u);
				}
			}
			else
			{
				this.TranslationRT.gameObject.SetActive(false);
				this.text_Translation.gameObject.SetActive(false);
				this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052u);
			}
			this.text_Translation.SetAllDirty();
			this.text_Translation.cachedTextGenerator.Invalidate();
			this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
			if (this.text_Translation.preferredWidth > this.text_Translation.rectTransform.sizeDelta.x)
			{
				this.text_Translation.rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, this.text_Translation.rectTransform.sizeDelta.y);
			}
			float num = 0f;
			if (this.TranslationRT.gameObject.activeSelf)
			{
				num = 84f;
			}
			if (this.text_Contents.preferredHeight + 18f + num > 425f)
			{
				this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 18f + num + this.text_Contents.preferredHeight);
			}
			else
			{
				this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 425f);
			}
			this.Mask_T.gameObject.SetActive(true);
			this.Letter_T.gameObject.SetActive(true);
			this.text_Title.SetAllDirty();
			this.text_Title.cachedTextGenerator.Invalidate();
		}
		else if (this.mLetterKind == 1)
		{
			if ((this.SC.Type >= NoticeReport.Enotice_NewbieOver && this.SC.Type <= NoticeReport.Enotice_SHLevel5) || this.SC.Type == NoticeReport.Enotice_FirstUnderPetAttack)
			{
				this.text_Name.text = this.DM.mStringTable.GetStringByID(3717u);
			}
			else
			{
				this.text_Name.text = this.DM.mStringTable.GetStringByID(6079u);
			}
			this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_MAX);
			this.tmpPageNum = (int)(this.SC.Index + 1);
			this.text_Time[0].text = GameConstants.GetDateTime(this.SC.Times).ToString("MM/dd/yy");
			this.text_Time[1].text = GameConstants.GetDateTime(this.SC.Times).ToString("HH:mm:ss");
			this.mStatus = 8;
			CString cstring4 = StringManager.Instance.StaticString1024();
			CString cstring5 = StringManager.Instance.StaticString1024();
			CString cstring6 = StringManager.Instance.StaticString1024();
			CString cstring7 = StringManager.Instance.StaticString1024();
			CString cstring8 = StringManager.Instance.StaticString1024();
			cstring4.ClearString();
			cstring5.ClearString();
			cstring6.ClearString();
			cstring7.ClearString();
			cstring8.ClearString();
			switch (this.SC.Type)
			{
			case NoticeReport.ENotice_Enhance:
			{
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6080u);
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.SC.NoticeHeroEnhance.HeroID);
				this.mHeroSkill[0] = this.tmpHero.GroupSkill2;
				this.mHeroSkill[1] = this.tmpHero.GroupSkill3;
				this.mHeroSkill[2] = this.tmpHero.GroupSkill4;
				this.Cstr_Contents_S.ClearString();
				this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpHero.HeroTitle));
				this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpHero.HeroName));
				this.Cstr_Contents_S.IntToFormat((long)this.SC.NoticeHeroEnhance.Rank, 1, false);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6081u));
				this.Cstr_Contents_S.Append("\n \n \n");
				this.Cstr_Contents_S.IntToFormat((long)this.DM.RankSoldiers[(int)this.SC.NoticeHeroEnhance.Rank], 1, false);
				int rank = (int)this.SC.NoticeHeroEnhance.Rank;
				if (rank == 2 || rank == 4 || rank == 7)
				{
					this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6083u));
					this.Img_HeroSkill[0].gameObject.SetActive(true);
					this.Img_HeroSkill[1].gameObject.SetActive(true);
					this.mSkill = this.DM.SkillTable.GetRecordByKey(this.mHeroSkill[rank / 2 - 1]);
					this.Cstr_SkillIcon[0].ClearString();
					this.Cstr_SkillIcon[0].IntToFormat((long)this.mSkill.SkillIcon, 5, false);
					this.Cstr_SkillIcon[0].AppendFormat("s{0}");
					this.Img_HeroSkill_1[0].sprite = this.GUIM.LoadSkillSprite(this.Cstr_SkillIcon[0]);
					this.text_Skill_1[0].text = this.DM.mStringTable.GetStringByID((uint)this.mSkill.SkillName);
					this.Cstr_Skill.ClearString();
					float num2 = (float)this.mSkill.HurtValue + (float)((ushort)this.LegionRankMagnifation[(int)(this.SC.NoticeHeroEnhance.Star - 1)] * this.mSkill.HurtIncreaseValue) / 1000f;
					if (this.mSkill.SkillType == 10)
					{
						GameConstants.GetEffectValue(this.Cstr_Skill, this.mSkill.HurtAddition, (uint)num2, 1, 0f);
					}
					else if (this.mSkill.HurtKind == 1)
					{
						GameConstants.GetEffectValue(this.Cstr_Skill, this.mSkill.HurtAddition, (uint)(this.mSkill.HurtValue + this.mSkill.HurtIncreaseValue * (ushort)this.LegionRankMagnifation[(int)(this.SC.NoticeHeroEnhance.Star - 1)]), 9, 0f);
					}
					else
					{
						GameConstants.GetEffectValue(this.Cstr_Skill, this.mSkill.HurtAddition, 0u, 6, num2 * 100f);
					}
					this.text_Skill_1[1].text = this.Cstr_Skill.ToString();
					this.text_Skill_1[1].SetAllDirty();
					this.text_Skill_1[1].cachedTextGenerator.Invalidate();
					this.mSkill = this.DM.SkillTable.GetRecordByKey(this.tmpHero.AttackPower[rank / 2 + 1]);
					this.Cstr_SkillIcon[1].ClearString();
					this.Cstr_SkillIcon[1].IntToFormat((long)this.mSkill.SkillIcon, 5, false);
					this.Cstr_SkillIcon[1].AppendFormat("s{0}");
					this.Img_HeroSkill_2[0].sprite = this.GUIM.LoadSkillSprite(this.Cstr_SkillIcon[1]);
					this.text_Skill_2[0].text = this.DM.mStringTable.GetStringByID((uint)this.mSkill.SkillName);
					uint id;
					switch (this.mSkill.SkillType)
					{
					case 1:
						id = 476u;
						break;
					case 2:
						id = 477u;
						break;
					case 3:
					case 4:
					case 5:
						id = 478u;
						break;
					default:
						id = 479u;
						break;
					}
					this.text_Skill_2[1].text = this.DM.mStringTable.GetStringByID(id);
				}
				else
				{
					this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6082u));
				}
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			}
			case NoticeReport.ENotice_StarUp:
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6084u);
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.SC.NoticeHeroStarUp.HeroID);
				this.Cstr_Contents_S.ClearString();
				this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpHero.HeroTitle));
				this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpHero.HeroName));
				this.Cstr_Contents_S.StringToFormat(this.Str_HeroColor[(int)(this.SC.NoticeHeroStarUp.Star - 2)]);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6085u));
				this.Cstr_Contents_S.Append("\n \n \n");
				this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(6086u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				this.HeroStarUp_T.gameObject.SetActive(true);
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.SC.NoticeHeroStarUp.HeroID);
				this.mHeroSkill[0] = this.tmpHero.GroupSkill1;
				this.mHeroSkill[1] = this.tmpHero.GroupSkill2;
				this.mHeroSkill[2] = this.tmpHero.GroupSkill3;
				this.mHeroSkill[3] = this.tmpHero.GroupSkill4;
				for (int i = 0; i < 4; i++)
				{
					this.mSkill = this.DM.SkillTable.GetRecordByKey(this.mHeroSkill[i]);
					cstring4.ClearString();
					cstring4.IntToFormat((long)this.mSkill.SkillIcon, 5, false);
					cstring4.AppendFormat("s{0}");
					this.Img_StarUpSkill[i].sprite = this.GUIM.LoadSkillSprite(cstring4);
					this.Cstr_StarUpValue[i].ClearString();
					float num3 = (float)this.mSkill.HurtValue + (float)((ushort)this.LegionRankMagnifation[(int)(this.SC.NoticeHeroStarUp.Star - 1)] * this.mSkill.HurtIncreaseValue) / 1000f;
					if (this.mSkill.SkillType == 10)
					{
						this.Cstr_StarUpValue[i].IntToFormat((long)((ulong)((uint)num3)), 1, true);
						if (this.GUIM.IsArabic)
						{
							this.Cstr_StarUpValue[i].AppendFormat("%{0}");
						}
						else
						{
							this.Cstr_StarUpValue[i].AppendFormat("{0}%");
						}
					}
					else if (this.mSkill.HurtKind == 1)
					{
						this.Cstr_StarUpValue[i].IntToFormat((long)((ulong)(this.mSkill.HurtValue + this.mSkill.HurtIncreaseValue * (ushort)this.LegionRankMagnifation[(int)(this.SC.NoticeHeroStarUp.Star - 1)])), 1, true);
						this.Cstr_StarUpValue[i].AppendFormat("{0}");
					}
					else
					{
						this.Cstr_StarUpValue[i].FloatToFormat(num3, -1, true);
						if (this.GUIM.IsArabic)
						{
							this.Cstr_StarUpValue[i].AppendFormat("%{0}");
						}
						else
						{
							this.Cstr_StarUpValue[i].AppendFormat("{0}%");
						}
					}
					this.text_StarUp_1[i].text = this.Cstr_StarUpValue[i].ToString();
					this.text_StarUp_1[i].SetAllDirty();
					this.text_StarUp_1[i].cachedTextGenerator.Invalidate();
				}
				cstring4.ClearString();
				cstring4.IntToFormat((long)this.SC.NoticeHeroStarUp.Star, 1, false);
				cstring4.AppendFormat("UI_box_hero_light_0{0}");
				this.Img_StarUpSkill_2[0].sprite = this.GUIM.LoadFrameSprite(cstring4);
				this.text_StarUp_2[0].gameObject.SetActive(true);
				if (this.SC.NoticeHeroStarUp.Rank >= 2)
				{
					this.Img_StarUpSkill_2[1].sprite = this.GUIM.LoadFrameSprite(cstring4);
					this.Img_StarUpSkill_L[1].gameObject.SetActive(false);
					this.text_StarUp_2[1].gameObject.SetActive(true);
				}
				else
				{
					this.Img_StarUpSkill_L[1].gameObject.SetActive(true);
					this.text_StarUp_2[1].gameObject.SetActive(false);
				}
				if (this.SC.NoticeHeroStarUp.Rank >= 4)
				{
					this.Img_StarUpSkill_2[2].sprite = this.GUIM.LoadFrameSprite(cstring4);
					this.Img_StarUpSkill_L[2].gameObject.SetActive(false);
					this.text_StarUp_2[2].gameObject.SetActive(true);
				}
				else
				{
					this.Img_StarUpSkill_L[2].gameObject.SetActive(true);
					this.text_StarUp_2[2].gameObject.SetActive(false);
				}
				if (this.SC.NoticeHeroStarUp.Rank >= 7)
				{
					this.Img_StarUpSkill_2[3].sprite = this.GUIM.LoadFrameSprite(cstring4);
					this.Img_StarUpSkill_L[3].gameObject.SetActive(false);
					this.text_StarUp_2[3].gameObject.SetActive(true);
				}
				else
				{
					this.Img_StarUpSkill_L[3].gameObject.SetActive(true);
					this.text_StarUp_2[3].gameObject.SetActive(false);
				}
				break;
			case NoticeReport.ENotice_JoinAlliance:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6051u);
				this.Cstr_Contents_S.ClearString();
				if (this.GUIM.IsArabic)
				{
					cstring6.Append(this.SC.Notice_JoinAlliance.Name);
					cstring7.Append(this.SC.Notice_JoinAlliance.Tag);
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					this.Cstr_Contents_S.StringToFormat(cstring5);
					this.Cstr_Contents_S.StringToFormat(string.Empty);
				}
				else
				{
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_JoinAlliance.Tag);
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_JoinAlliance.Name);
				}
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6052u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_ApplyAlliance:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6053u);
				this.Cstr_Contents_S.ClearString();
				if (this.GUIM.IsArabic)
				{
					cstring6.Append(this.SC.Notice_ApplyAlliance.Name);
					cstring7.Append(this.SC.Notice_ApplyAlliance.Tag);
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					this.Cstr_Contents_S.StringToFormat(cstring5);
					this.Cstr_Contents_S.StringToFormat(string.Empty);
				}
				else
				{
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_ApplyAlliance.Tag);
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_ApplyAlliance.Name);
				}
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6054u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_ApplyAllianceBeDenied:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6055u);
				this.Cstr_Contents_S.ClearString();
				if (this.GUIM.IsArabic)
				{
					cstring6.Append(this.SC.Notice_ApplyAllianceBeDenied.Name);
					cstring7.Append(this.SC.Notice_ApplyAllianceBeDenied.Tag);
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_ApplyAllianceBeDenied.Dealer);
					this.Cstr_Contents_S.StringToFormat(cstring5);
					this.Cstr_Contents_S.StringToFormat(string.Empty);
				}
				else
				{
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_ApplyAllianceBeDenied.Dealer);
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_ApplyAllianceBeDenied.Tag);
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_ApplyAllianceBeDenied.Name);
				}
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6056u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_AllianceDismiss:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6059u);
				this.Cstr_Contents_S.ClearString();
				this.Cstr_Contents_S.StringToFormat(this.SC.Notice_AllianceDismiss.Leader);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6060u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_AllianceLeaderStepDown:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6063u);
				this.Cstr_Contents_S.ClearString();
				this.Cstr_Contents_S.StringToFormat(this.SC.Notice_AllianceLeaderStepDown.OldLeader);
				this.Cstr_Contents_S.StringToFormat(this.SC.Notice_AllianceLeaderStepDown.NewLeader);
				this.Cstr_Contents_S.StringToFormat(this.SC.Notice_AllianceLeaderStepDown.NewLeader);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6064u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_ActivityDegreePrize:
			case NoticeReport.Enotice_ActivityKVKDegreePrize:
			{
				this.Cstr_Contents_S.ClearString();
				int prizeNum;
				if (this.SC.Type == NoticeReport.Enotice_ActivityDegreePrize)
				{
					this.mPrizeType = Detail_Prize.Enotice_ActivityDegreePrize;
					if (this.SC.Notice_ActivityDegreePrize.Type == NoticeContent.ActivityCircleEventType.EACET_SoloEvent)
					{
						this.text_Title.text = this.DM.mStringTable.GetStringByID(7686u);
						this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(7678u));
						this.mStatus = 13;
					}
					else if (this.SC.Notice_ActivityDegreePrize.Type == NoticeContent.ActivityCircleEventType.EACET_InfernalEvent)
					{
						this.text_Title.text = this.DM.mStringTable.GetStringByID(7688u);
						this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(7682u));
						this.mStatus = 15;
					}
					prizeNum = (int)this.SC.Notice_ActivityDegreePrize.PrizeNum;
				}
				else
				{
					this.mPrizeType = Detail_Prize.Enotice_ActivityKVKDegreePrize;
					if (this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomKillEvent || this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomMatchEvent)
					{
						this.mStatus = 21;
					}
					else if (this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomNormalEvent)
					{
						this.mStatus = 16;
					}
					else if (this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_FIFA)
					{
						this.mStatus = 22;
					}
					if (this.SC.Enotice_ActivityKVKDegreePrize.EventType == EActivityKingdomEventType.EAKET_SoloEvent)
					{
						if (this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomKillEvent || this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomMatchEvent)
						{
							this.text_Title.text = this.DM.mStringTable.GetStringByID(9846u);
							this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(9842u));
						}
						else if (this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomNormalEvent)
						{
							this.text_Title.text = this.DM.mStringTable.GetStringByID(9844u);
							this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(9838u));
						}
						else if (this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_FIFA)
						{
							this.text_Title.text = this.DM.mStringTable.GetStringByID(12235u);
							this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(12236u));
						}
					}
					else if (this.SC.Enotice_ActivityKVKDegreePrize.EventType == EActivityKingdomEventType.EAKET_AllianceEvent)
					{
						if (this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomKillEvent || this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomMatchEvent)
						{
							this.text_Title.text = this.DM.mStringTable.GetStringByID(9845u);
							this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(9840u));
						}
						else if (this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_FIFA)
						{
							this.text_Title.text = this.DM.mStringTable.GetStringByID(12232u);
							this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(12233u));
						}
					}
					else if (this.SC.Enotice_ActivityKVKDegreePrize.EventType == EActivityKingdomEventType.EAKET_KingdomEvent)
					{
					}
					prizeNum = (int)this.SC.Enotice_ActivityKVKDegreePrize.PrizeNum;
				}
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				this.mDiamond = 0u;
				this.mValue = 0u;
				this.mNoValueCount = 0;
				this.tmplistItem.Clear();
				for (int j = 0; j < prizeNum; j++)
				{
					this.bAddList = true;
					ushort itemID;
					byte num4;
					if (this.mPrizeType == Detail_Prize.Enotice_ActivityDegreePrize)
					{
						itemID = this.SC.Notice_ActivityDegreePrize.PrizeData[j].ItemID;
						num4 = this.SC.Notice_ActivityDegreePrize.PrizeData[j].Num;
					}
					else
					{
						itemID = this.SC.Enotice_ActivityKVKDegreePrize.PrizeData[j].ItemID;
						num4 = this.SC.Enotice_ActivityKVKDegreePrize.PrizeData[j].Num;
					}
					this.tmpEQ = this.DM.EquipTable.GetRecordByKey(itemID);
					if (this.tmpEQ.EquipKind == 11 && this.tmpEQ.PropertiesInfo[0].Propertieskey == 6)
					{
						this.bAddList = false;
						this.mDiamond += (uint)(this.tmpEQ.PropertiesInfo[1].Propertieskey * this.tmpEQ.PropertiesInfo[1].PropertiesValue * (ushort)num4);
						this.mValue += (uint)(this.tmpEQ.PropertiesInfo[1].Propertieskey * this.tmpEQ.PropertiesInfo[1].PropertiesValue * (ushort)num4);
					}
					else
					{
						this.ShopID = this.DM.TotalShopItemData.Find(itemID);
						if (this.ShopID != 0 && this.DM.StoreData.GetRecordByKey(this.ShopID).Price > 0u)
						{
							this.mValue += this.DM.StoreData.GetRecordByKey(this.ShopID).Price * (uint)num4;
						}
						else
						{
							this.mNoValueCount += num4;
						}
					}
					if (this.bAddList)
					{
						this.tmplistItem.Add((ushort)j);
					}
				}
				break;
			}
			case NoticeReport.Enotice_ActivityRankPrize:
			case NoticeReport.Enotice_ActivityKVKRankPrize:
			{
				this.Cstr_Contents_S.ClearString();
				int prizeNum2;
				if (this.SC.Type == NoticeReport.Enotice_ActivityRankPrize)
				{
					this.mPrizeType = Detail_Prize.Enotice_ActivityRankPrize;
					this.Cstr_Contents_S.IntToFormat((long)this.SC.Notice_ActivityRankPrize.Place, 1, false);
					if (this.SC.Notice_ActivityRankPrize.Type == NoticeContent.ActivityCircleEventType.EACET_SoloEvent)
					{
						this.text_Title.text = this.DM.mStringTable.GetStringByID(7686u);
						this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(7679u));
						this.mStatus = 13;
					}
					else if (this.SC.Notice_ActivityRankPrize.Type == NoticeContent.ActivityCircleEventType.EACET_InfernalEvent)
					{
						this.text_Title.text = this.DM.mStringTable.GetStringByID(7688u);
						this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(7683u));
						this.mStatus = 15;
					}
					prizeNum2 = (int)this.SC.Notice_ActivityRankPrize.PrizeNum;
				}
				else
				{
					this.mPrizeType = Detail_Prize.Enotice_ActivityKVKRankPrize;
					this.Cstr_Contents_S.IntToFormat((long)this.SC.Enotice_ActivityKVKRankPrize.Place, 1, false);
					if (this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomKillEvent || this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomMatchEvent)
					{
						this.mStatus = 21;
					}
					else if (this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomNormalEvent)
					{
						this.mStatus = 16;
					}
					else if (this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_FIFA)
					{
						this.mStatus = 22;
					}
					if (this.SC.Enotice_ActivityKVKRankPrize.EventType == EActivityKingdomEventType.EAKET_SoloEvent)
					{
						if (this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomKillEvent || this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomMatchEvent)
						{
							this.text_Title.text = this.DM.mStringTable.GetStringByID(9846u);
							this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9843u));
						}
						else if (this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomNormalEvent)
						{
							this.text_Title.text = this.DM.mStringTable.GetStringByID(9844u);
							this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9839u));
						}
						else if (this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_FIFA)
						{
							this.text_Title.text = this.DM.mStringTable.GetStringByID(12235u);
							this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(12237u));
						}
					}
					else if (this.SC.Enotice_ActivityKVKRankPrize.EventType == EActivityKingdomEventType.EAKET_AllianceEvent)
					{
						if (this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomKillEvent || this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomMatchEvent)
						{
							this.text_Title.text = this.DM.mStringTable.GetStringByID(9845u);
							this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9841u));
						}
						else if (this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_FIFA)
						{
							this.text_Title.text = this.DM.mStringTable.GetStringByID(12232u);
							this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(12234u));
						}
					}
					else if (this.SC.Enotice_ActivityKVKRankPrize.EventType == EActivityKingdomEventType.EAKET_KingdomEvent)
					{
					}
					prizeNum2 = (int)this.SC.Enotice_ActivityKVKRankPrize.PrizeNum;
				}
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				this.mDiamond = 0u;
				this.mValue = 0u;
				this.mNoValueCount = 0;
				this.tmplistItem.Clear();
				for (int k = 0; k < prizeNum2; k++)
				{
					this.bAddList = true;
					ushort itemID2;
					byte num5;
					if (this.mPrizeType == Detail_Prize.Enotice_ActivityRankPrize)
					{
						itemID2 = this.SC.Notice_ActivityRankPrize.PrizeData[k].ItemID;
						num5 = this.SC.Notice_ActivityRankPrize.PrizeData[k].Num;
					}
					else
					{
						itemID2 = this.SC.Enotice_ActivityKVKRankPrize.PrizeData[k].ItemID;
						num5 = this.SC.Enotice_ActivityKVKRankPrize.PrizeData[k].Num;
					}
					this.tmpEQ = this.DM.EquipTable.GetRecordByKey(itemID2);
					if (this.tmpEQ.EquipKind == 11 && this.tmpEQ.PropertiesInfo[0].Propertieskey == 6)
					{
						this.bAddList = false;
						this.mDiamond += (uint)(this.tmpEQ.PropertiesInfo[1].Propertieskey * this.tmpEQ.PropertiesInfo[1].PropertiesValue * (ushort)num5);
						this.mValue += (uint)(this.tmpEQ.PropertiesInfo[1].Propertieskey * this.tmpEQ.PropertiesInfo[1].PropertiesValue * (ushort)num5);
					}
					else
					{
						this.ShopID = this.DM.TotalShopItemData.Find(itemID2);
						if (this.ShopID != 0 && this.DM.StoreData.GetRecordByKey(this.ShopID).Price > 0u)
						{
							this.mValue += this.DM.StoreData.GetRecordByKey(this.ShopID).Price * (uint)num5;
						}
						else
						{
							this.mNoValueCount += num5;
						}
					}
					if (this.bAddList)
					{
						this.tmplistItem.Add((ushort)k);
					}
				}
				break;
			}
			case NoticeReport.Enotice_InviteAlliance:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6057u);
				this.Cstr_Contents_S.ClearString();
				if (this.GUIM.IsArabic)
				{
					cstring6.Append(this.SC.Notice_InviteAlliance.Name);
					cstring7.Append(this.SC.Notice_InviteAlliance.Tag);
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_InviteAlliance.InviterName);
					this.Cstr_Contents_S.StringToFormat(cstring5);
					this.Cstr_Contents_S.StringToFormat(string.Empty);
				}
				else
				{
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_InviteAlliance.InviterName);
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_InviteAlliance.Tag);
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_InviteAlliance.Name);
				}
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6058u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				this.btn_AllianceInvite_S.gameObject.SetActive(true);
				break;
			case NoticeReport.Enotice_SynLordEquip:
			{
				this.text_Title.text = this.DM.mStringTable.GetStringByID(7700u);
				this.Img_Hero_S.transform.parent.gameObject.SetActive(false);
				this.Img_LordEquip_BG.gameObject.SetActive(true);
				this.Tmp = this.Letter_S_T.GetChild(7);
				this.Img_LordEquip_BG = this.Tmp.GetComponent<Image>();
				this.Tmp = this.Letter_S_T.GetChild(7).GetChild(0);
				Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.SC.Notice_SynLordEquip.ItemID);
				CString cstring9 = StringManager.Instance.StaticString1024();
				cstring9.ClearString();
				cstring9.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.EquipName));
				if (this.SC.Notice_SynLordEquip.Rank == 1)
				{
					cstring9.AppendFormat("<color=#ffffffff>{0}</color>");
				}
				else if (this.SC.Notice_SynLordEquip.Rank == 2)
				{
					cstring9.AppendFormat("<color=#005a2fff>{0}</color>");
				}
				else if (this.SC.Notice_SynLordEquip.Rank == 3)
				{
					cstring9.AppendFormat("<color=#004fa7ff>{0}</color>");
				}
				else if (this.SC.Notice_SynLordEquip.Rank == 4)
				{
					cstring9.AppendFormat("<color=#5a1ca7ff>{0}</color>");
				}
				else if (this.SC.Notice_SynLordEquip.Rank == 5)
				{
					cstring9.AppendFormat("<color=#ffff00ff>{0}</color>");
				}
				else if (this.SC.Notice_SynLordEquip.Rank == 6)
				{
					cstring9.AppendFormat("<color=#d24a00ff>{0}</color>");
				}
				else
				{
					cstring9.AppendFormat("{0}");
				}
				this.Cstr_LordEquip[0].ClearString();
				this.Cstr_LordEquip[0].StringToFormat(cstring9.ToString());
				this.Cstr_LordEquip[0].AppendFormat(this.DM.mStringTable.GetStringByID(7699u));
				this.Cstr_LordEquip[1].ClearString();
				this.Cstr_LordEquip[1].Append(this.DM.mStringTable.GetStringByID(7698u));
				this.Cstr_LordEquip[1].IntToFormat((long)((ulong)this.SC.Notice_SynLordEquip.AddExp), 1, true);
				this.Cstr_LordEquip[1].AppendFormat("<color=#24ff13ff>+{0}</color>");
				for (int l = 0; l < 2; l++)
				{
					this.text_LordEquip[l].text = this.Cstr_LordEquip[l].ToString();
					this.text_LordEquip[l].SetAllDirty();
					this.text_LordEquip[l].cachedTextGenerator.Invalidate();
				}
				this.GUIM.InitLordEquipImg(this.mLebtn.transform, this.SC.Notice_SynLordEquip.ItemID, this.SC.Notice_SynLordEquip.Rank, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
				this.mLebtn.gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
				this.Cstr_LordEquip_Lv.ClearString();
				this.Cstr_LordEquip_Lv.IntToFormat((long)recordByKey.NeedLv, 1, true);
				this.Cstr_LordEquip_Lv.AppendFormat(this.DM.mStringTable.GetStringByID(8201u));
				this.text_LordEquip_Lv.text = this.Cstr_LordEquip_Lv.ToString();
				this.text_LordEquip_Lv.SetAllDirty();
				this.text_LordEquip_Lv.cachedTextGenerator.Invalidate();
				this.effectList.Clear();
				LordEquipData.GetEffectList(recordByKey.EquipKey, this.SC.Notice_SynLordEquip.Rank, this.effectList);
				for (int m = 0; m < this.effectList.Count; m++)
				{
					this.Cstr_LordEquip_Effect[m][0].ClearString();
					GameConstants.GetEffectValue(this.Cstr_LordEquip_Effect[m][0], this.effectList[m].EffectID, 0u, 8, 0f);
					this.text_LordEquip_Effect[m][0].text = this.Cstr_LordEquip_Effect[m][0].ToString();
					this.text_LordEquip_Effect[m][0].SetAllDirty();
					this.text_LordEquip_Effect[m][0].cachedTextGenerator.Invalidate();
					this.Cstr_LordEquip_Effect[m][1].ClearString();
					GameConstants.GetEffectValue(this.Cstr_LordEquip_Effect[m][1], this.effectList[m].EffectID, (uint)this.effectList[m].EffectValue, 3, 0f);
					this.text_LordEquip_Effect[m][1].text = this.Cstr_LordEquip_Effect[m][1].ToString();
					this.text_LordEquip_Effect[m][1].SetAllDirty();
					this.text_LordEquip_Effect[m][1].cachedTextGenerator.Invalidate();
				}
				for (int n = this.effectList.Count; n < 6; n++)
				{
					this.text_LordEquip_Effect[n][0].gameObject.SetActive(false);
					this.text_LordEquip_Effect[n][1].gameObject.SetActive(false);
				}
				break;
			}
			case NoticeReport.Enotice_RallyCancel:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6067u);
				cstring6.Append(this.SC.Notice_RallyNotice.HostName);
				cstring7.Append(this.SC.Notice_RallyNotice.HostTag);
				this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
				cstring4.StringToFormat(cstring5);
				cstring4.StringToFormat(string.Empty);
				cstring4.AppendFormat(this.DM.mStringTable.GetStringByID(5389u));
				cstring5.ClearString();
				cstring6.ClearString();
				cstring7.ClearString();
				cstring6.Append(this.SC.Notice_RallyNotice.TargetName);
				cstring7.Append(this.SC.Notice_RallyNotice.TargetTag);
				this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
				cstring8.StringToFormat(cstring5);
				cstring8.StringToFormat(string.Empty);
				cstring8.AppendFormat(this.DM.mStringTable.GetStringByID(5390u));
				this.Cstr_Contents_S.ClearString();
				this.Cstr_Contents_S.StringToFormat(cstring4);
				this.Cstr_Contents_S.StringToFormat(cstring8);
				this.Cstr_Contents_S.AppendFormat("{0}\n{1}");
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_CryptFinish:
			{
				this.Img_CryptFinish_BG.gameObject.SetActive(true);
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6077u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(6078u);
				BuildLevelRequest buildLevelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(16, this.SC.Notice_CryptNotice.Level);
				double num6 = 1.0 + GameConstants.cryptInterest[(int)this.SC.Notice_CryptNotice.Kind] + buildLevelRequestData.Value2 / 10000.0;
				ushort money = this.SC.Notice_CryptNotice.Money;
				uint num7 = (uint)Math.Floor((double)money * num6);
				this.Cstr_Contents_S.ClearString();
				this.Cstr_Contents_S.IntToFormat((long)((ulong)num7), 1, true);
				if (this.GUIM.IsArabic)
				{
					this.Cstr_Contents_S.AppendFormat("{0} x");
				}
				else
				{
					this.Cstr_Contents_S.AppendFormat("x {0}");
				}
				this.text_CryptFinish.text = this.Cstr_Contents_S.ToString();
				break;
			}
			case NoticeReport.Enotice_OtherSavedLord:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6074u);
				this.Cstr_Contents_S.ClearString();
				cstring6.Append(this.SC.Notice_OtherSavedLord.Name);
				if (this.SC.Notice_OtherSavedLord.AllianceTag != string.Empty)
				{
					cstring7.Append(this.SC.Notice_OtherSavedLord.AllianceTag);
					if (this.SC.Notice_OtherSavedLord.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, this.SC.Notice_OtherSavedLord.HomeKingdom, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					}
				}
				else if (this.SC.Notice_OtherSavedLord.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, this.SC.Notice_OtherSavedLord.HomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, 0, this.GUIM.IsArabic);
				}
				this.Cstr_Contents_S.StringToFormat(cstring5);
				this.Cstr_Contents_S.StringToFormat(string.Empty);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6071u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_SelfSavedLord:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(7656u);
				this.Cstr_Contents_S.ClearString();
				this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(6075u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_LordBeingReleased:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6072u);
				this.Cstr_Contents_S.ClearString();
				cstring6.Append(this.SC.Notice_LordBeingReleased.Name);
				if (this.SC.Notice_LordBeingReleased.AllianceTag != string.Empty)
				{
					cstring7.Append(this.SC.Notice_LordBeingReleased.AllianceTag);
					if (this.SC.Notice_LordBeingReleased.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, this.SC.Notice_LordBeingReleased.HomeKingdom, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					}
				}
				else if (this.SC.Notice_LordBeingReleased.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, this.SC.Notice_LordBeingReleased.HomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, 0, this.GUIM.IsArabic);
				}
				this.Cstr_Contents_S.StringToFormat(cstring5);
				this.Cstr_Contents_S.StringToFormat(string.Empty);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6073u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_LordBeingExecuted:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(7659u);
				this.Cstr_Contents_S.ClearString();
				cstring6.Append(this.SC.Notice_LordBeingExecuted.Name);
				if (this.SC.Notice_LordBeingExecuted.AllianceTag != string.Empty)
				{
					cstring7.Append(this.SC.Notice_LordBeingExecuted.AllianceTag);
					if (this.SC.Notice_LordBeingExecuted.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, this.SC.Notice_LordBeingExecuted.HomeKingdom, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					}
				}
				else if (this.SC.Notice_LordBeingExecuted.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, this.SC.Notice_LordBeingExecuted.HomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, 0, this.GUIM.IsArabic);
				}
				this.Cstr_Contents_S.StringToFormat(cstring5);
				this.Cstr_Contents_S.StringToFormat(string.Empty);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(7660u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_LordEscaped:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6070u);
				this.Cstr_Contents_S.ClearString();
				this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(7655u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_OtherBreakPrison:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(7665u);
				this.Cstr_Contents_S.ClearString();
				cstring6.Append(this.SC.Notice_OtherBreakPrison.Name);
				if (this.SC.Notice_OtherBreakPrison.AllianceTag != string.Empty)
				{
					cstring7.Append(this.SC.Notice_OtherBreakPrison.AllianceTag);
					if (this.SC.Notice_OtherBreakPrison.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, this.SC.Notice_OtherBreakPrison.HomeKingdom, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					}
				}
				else if (this.SC.Notice_OtherBreakPrison.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, this.SC.Notice_OtherBreakPrison.HomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, 0, this.GUIM.IsArabic);
				}
				this.Cstr_Contents_S.StringToFormat(cstring5);
				this.Cstr_Contents_S.StringToFormat(string.Empty);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(7666u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_RescuedPrisoner:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.Cstr_Contents_S.ClearString();
				cstring6.Append(this.SC.Notice_RescuedPrisoner.Name);
				if (this.SC.Notice_RescuedPrisoner.AllianceTag != string.Empty)
				{
					cstring7.Append(this.SC.Notice_RescuedPrisoner.AllianceTag);
					if (this.SC.Notice_RescuedPrisoner.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, this.SC.Notice_RescuedPrisoner.HomeKingdom, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					}
				}
				else if (this.SC.Notice_RescuedPrisoner.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, this.SC.Notice_RescuedPrisoner.HomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, 0, this.GUIM.IsArabic);
				}
				this.Cstr_Contents_S.StringToFormat(cstring5);
				this.Cstr_Contents_S.StringToFormat(string.Empty);
				this.Cstr_Contents_S.IntToFormat((long)this.SC.Notice_RescuedPrisoner.PrisonerNum, 1, false);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(7663u));
				if (this.SC.Notice_RescuedPrisoner.ClaimReward != 0u)
				{
					cstring4.ClearString();
					cstring4.Append("\n");
					cstring4.IntToFormat((long)((ulong)this.SC.Notice_RescuedPrisoner.ClaimReward), 1, true);
					cstring4.AppendFormat(this.DM.mStringTable.GetStringByID(7664u));
					this.Cstr_Contents_S.Append(cstring4);
					this.text_Title.text = this.DM.mStringTable.GetStringByID(6076u);
				}
				else
				{
					this.text_Title.text = this.DM.mStringTable.GetStringByID(8235u);
				}
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_RequestRansom:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(7658u);
				this.Cstr_Contents_S.ClearString();
				this.Cstr_Contents_S.IntToFormat((long)((ulong)this.SC.Notice_RequestRansom.Ransom), 1, true);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(7657u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_ReceivedRansom:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8232u);
				this.Cstr_Contents_S.ClearString();
				this.Cstr_Contents_S.IntToFormat((long)((ulong)this.SC.Notice_ReceivedRansom.Ransom), 1, true);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(7661u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_PrisonFull:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8234u);
				this.Cstr_Contents_S.ClearString();
				cstring6.Append(this.SC.Notice_PrisonFull.Name);
				if (this.SC.Notice_PrisonFull.AllianceTag != string.Empty)
				{
					cstring7.Append(this.SC.Notice_PrisonFull.AllianceTag);
					if (this.SC.Notice_PrisonFull.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, this.SC.Notice_PrisonFull.HomeKingdom, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					}
				}
				else if (this.SC.Notice_PrisonFull.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, this.SC.Notice_PrisonFull.HomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, 0, this.GUIM.IsArabic);
				}
				this.Cstr_Contents_S.StringToFormat(cstring5);
				this.Cstr_Contents_S.StringToFormat(string.Empty);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(8233u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_RallyCancel_AsTargetAlly:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6067u);
				cstring6.Append(this.SC.Notice_AsTargetAlly.HostName);
				cstring7.Append(this.SC.Notice_AsTargetAlly.HostTag);
				this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
				cstring4.StringToFormat(cstring5);
				cstring4.StringToFormat(string.Empty);
				cstring4.AppendFormat(this.DM.mStringTable.GetStringByID(5389u));
				cstring6.ClearString();
				cstring7.ClearString();
				cstring6.Append(this.SC.Notice_AsTargetAlly.TargetName);
				cstring7.Append(this.SC.Notice_AsTargetAlly.HostTag);
				this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
				cstring8.StringToFormat(cstring5);
				cstring8.StringToFormat(string.Empty);
				cstring8.AppendFormat(this.DM.mStringTable.GetStringByID(5390u));
				cstring7.ClearString();
				cstring7.StringToFormat(this.SC.Notice_AsTargetAlly.TargetName);
				cstring7.AppendFormat(this.DM.mStringTable.GetStringByID(8216u));
				this.Cstr_Contents_S.ClearString();
				this.Cstr_Contents_S.StringToFormat(cstring4);
				this.Cstr_Contents_S.StringToFormat(cstring8);
				this.Cstr_Contents_S.StringToFormat(cstring7);
				this.Cstr_Contents_S.AppendFormat("{0}\n{1}\n{2}");
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_BeQuitAlliance:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8215u);
				this.Cstr_Contents_S.ClearString();
				if (this.GUIM.IsArabic)
				{
					cstring6.Append(this.SC.Notice_BeQuitAlliance.Alliance);
					cstring7.Append(this.SC.Notice_BeQuitAlliance.AllianceTag);
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_BeQuitAlliance.Dealer);
					this.Cstr_Contents_S.StringToFormat(cstring5);
					this.Cstr_Contents_S.StringToFormat(string.Empty);
				}
				else
				{
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_BeQuitAlliance.Dealer);
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_BeQuitAlliance.AllianceTag);
					this.Cstr_Contents_S.StringToFormat(this.SC.Notice_BeQuitAlliance.Alliance);
				}
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(8214u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_BuyTreasure:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8236u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(8237u);
				break;
			case NoticeReport.Enotice_RallyCancel_Moving:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6067u);
				cstring6.Append(this.SC.Notice_RallyNotice_Moving.HostName);
				cstring7.Append(this.SC.Notice_RallyNotice_Moving.HostTag);
				this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
				cstring4.StringToFormat(cstring5);
				cstring4.StringToFormat(string.Empty);
				cstring4.AppendFormat(this.DM.mStringTable.GetStringByID(5389u));
				cstring6.ClearString();
				cstring7.ClearString();
				cstring6.Append(this.SC.Notice_RallyNotice_Moving.TargetName);
				cstring7.Append(this.SC.Notice_RallyNotice_Moving.TargetTag);
				this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
				cstring8.StringToFormat(cstring5);
				cstring8.StringToFormat(string.Empty);
				cstring8.AppendFormat(this.DM.mStringTable.GetStringByID(5390u));
				cstring7.ClearString();
				cstring7.StringToFormat(cstring5);
				cstring7.StringToFormat(string.Empty);
				cstring7.AppendFormat(this.DM.mStringTable.GetStringByID(8245u));
				this.Cstr_Contents_S.ClearString();
				this.Cstr_Contents_S.StringToFormat(cstring4);
				this.Cstr_Contents_S.StringToFormat(cstring8);
				this.Cstr_Contents_S.StringToFormat(cstring7);
				this.Cstr_Contents_S.AppendFormat("{0}\n{1}\n{2}");
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_AtkFailedSelfShield:
			{
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				CString cstring10 = StringManager.Instance.StaticString1024();
				cstring10.ClearString();
				CString cstring11 = StringManager.Instance.StaticString1024();
				cstring11.ClearString();
				if (this.SC.Enotice_AtkFailedSelfShield.FailedType == 1)
				{
					this.text_Title.text = this.DM.mStringTable.GetStringByID(8250u);
					cstring11.Append(this.DM.mStringTable.GetStringByID(7668u));
				}
				else
				{
					this.text_Title.text = this.DM.mStringTable.GetStringByID(8251u);
					cstring11.Append(this.DM.mStringTable.GetStringByID(7667u));
				}
				this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.SC.Enotice_AtkFailedSelfShield.zoneID, this.SC.Enotice_AtkFailedSelfShield.pointID));
				cstring10.IntToFormat((long)this.SC.Enotice_AtkFailedSelfShield.KingdomID, 1, false);
				cstring10.IntToFormat((long)((int)this.tmpV.x), 1, false);
				cstring10.IntToFormat((long)((int)this.tmpV.y), 1, false);
				cstring10.AppendFormat("K:{0}X:{1}Y:{2}");
				this.Cstr_Contents_S.StringToFormat(cstring10);
				this.Cstr_Contents_S.StringToFormat(cstring11);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(657u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			}
			case NoticeReport.Enotice_InactiveState:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8249u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(8248u);
				break;
			case NoticeReport.Enotice_NewbieOver:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(3718u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3719u);
				break;
			case NoticeReport.Enotice_SHLevel6:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(3720u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3721u);
				break;
			case NoticeReport.Enotice_SHLevel10:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(3722u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3723u);
				break;
			case NoticeReport.Enotice_SHLevel15:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(3724u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3725u);
				break;
			case NoticeReport.Enotice_SHLevel17:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(3726u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3727u);
				break;
			case NoticeReport.Enotice_FirstUnderAttack:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(3728u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3729u);
				break;
			case NoticeReport.Enotice_FirstJoinAlliance:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(3730u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3731u);
				break;
			case NoticeReport.Enotice_SHLevel5:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(3732u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3733u);
				break;
			case NoticeReport.Enotice_BuyMonthTreature:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8236u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(920u);
				break;
			case NoticeReport.Enotice_RecivedGift:
				this.Gifts_T.gameObject.SetActive(true);
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(9095u);
				if (this.GUIM.IsArabic)
				{
					cstring6.Append(this.SC.Enotice_RecivedGift.GiftsName);
					cstring7.Append(this.SC.Enotice_RecivedGift.GiftsTag);
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					this.Cstr_Contents_S.StringToFormat(cstring5);
					this.Cstr_Contents_S.StringToFormat(string.Empty);
				}
				else
				{
					this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_RecivedGift.GiftsTag);
					this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_RecivedGift.GiftsName);
				}
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9093u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_PrisonAmnestied:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				cstring6.Append(this.SC.Enotice_PrisonAmnestied.KingdomName);
				cstring7.Append(this.SC.Enotice_PrisonAmnestied.KingdomTag);
				this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
				this.Cstr_Name.StringToFormat(cstring5);
				this.Cstr_Name.AppendFormat(this.DM.mStringTable.GetStringByID(1473u));
				this.text_Name.text = this.Cstr_Name.ToString();
				this.text_Title.text = this.DM.mStringTable.GetStringByID(1475u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(1463u);
				break;
			case NoticeReport.Enotice_LordBeingAmnestied:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				cstring6.Append(this.SC.Enotice_LordBeingAmnestied.KingdomName);
				cstring7.Append(this.SC.Enotice_LordBeingAmnestied.KingdomTag);
				this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
				this.Cstr_Name.StringToFormat(cstring5);
				this.Cstr_Name.AppendFormat(this.DM.mStringTable.GetStringByID(1473u));
				this.text_Name.text = this.Cstr_Name.ToString();
				this.text_Title.text = this.DM.mStringTable.GetStringByID(1475u);
				cstring6.ClearString();
				cstring7.ClearString();
				cstring6.Append(this.SC.Enotice_LordBeingAmnestied.Name);
				cstring7.Append(this.SC.Enotice_LordBeingAmnestied.Tag);
				this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
				this.Cstr_Contents_S.StringToFormat(cstring5);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(1462u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_RulerGift:
				this.Gifts_T.gameObject.SetActive(true);
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(9714u);
				cstring6.Append(this.SC.Enotice_RulerGift.Name);
				cstring7.Append(this.SC.Enotice_RulerGift.Tag);
				this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
				this.Cstr_Contents_S.StringToFormat(cstring5);
				if (this.SC.Enotice_RulerGift.RulerKind == 1)
				{
					this.text_Title.text = this.DM.mStringTable.GetStringByID(9714u);
					this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9715u));
				}
				else if (this.SC.Enotice_RulerGift.RulerKind == 2)
				{
					this.text_Title.text = this.DM.mStringTable.GetStringByID(9799u);
					this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9800u));
				}
				else if (this.SC.Enotice_RulerGift.RulerKind == 3)
				{
					this.text_Title.text = this.DM.mStringTable.GetStringByID(11086u);
					this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(11087u));
				}
				else
				{
					this.text_Title.text = this.DM.mStringTable.GetStringByID(1049u);
					this.Cstr_Contents_S.AppendFormat("{0}");
					this.Cstr_Contents_S.ClearString();
					this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(1049u));
				}
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_DismissAllianceLeader:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(9529u);
				this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_DismissAllianceLeader.OldLeader);
				this.Cstr_Contents_S.IntToFormat((long)this.SC.Enotice_DismissAllianceLeader.OffLineDay, 1, false);
				this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_DismissAllianceLeader.NewLeader);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9535u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_AmbushDefSuccess:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(9754u);
				cstring6.Append(this.SC.Enotice_AmbushDefSuccess.AtkPlayerName);
				if (this.SC.Enotice_AmbushDefSuccess.AtkPlayerAllianceTag != string.Empty)
				{
					cstring7.Append(this.SC.Enotice_AmbushDefSuccess.AtkPlayerAllianceTag);
					if (this.SC.Enotice_AmbushDefSuccess.AtkPlayerHomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, this.SC.Enotice_AmbushDefSuccess.AtkPlayerHomeKingdom, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					}
				}
				else if (this.SC.Enotice_AmbushDefSuccess.AtkPlayerHomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, this.SC.Enotice_AmbushDefSuccess.AtkPlayerHomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, 0, this.GUIM.IsArabic);
				}
				this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_AmbushDefSuccess.AmbushName);
				this.Cstr_Contents_S.StringToFormat(cstring5);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9755u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_AmbushDefFailed:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(9756u);
				cstring6.Append(this.SC.Enotice_AmbushDefFailed.AtkPlayerName);
				if (this.SC.Enotice_AmbushDefFailed.AtkPlayerAllianceTag != string.Empty)
				{
					cstring7.Append(this.SC.Enotice_AmbushDefFailed.AtkPlayerAllianceTag);
					if (this.SC.Enotice_AmbushDefFailed.AtkPlayerHomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, this.SC.Enotice_AmbushDefFailed.AtkPlayerHomeKingdom, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					}
				}
				else if (this.SC.Enotice_AmbushDefFailed.AtkPlayerHomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, this.SC.Enotice_AmbushDefFailed.AtkPlayerHomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, 0, this.GUIM.IsArabic);
				}
				this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_AmbushDefFailed.AmbushName);
				this.Cstr_Contents_S.StringToFormat(cstring5);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9757u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_BuyBlackMarketTreasure:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8236u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(9776u);
				break;
			case NoticeReport.Enotice_KickOffTeam:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(9914u);
				if (this.GUIM.IsArabic)
				{
					cstring6.Append(this.SC.Enotice_KickOffTeam.HostName);
					cstring7.Append(this.SC.Enotice_KickOffTeam.AllianceTag);
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					this.Cstr_Contents_S.StringToFormat(cstring5);
					this.Cstr_Contents_S.StringToFormat(string.Empty);
				}
				else
				{
					this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_KickOffTeam.AllianceTag);
					this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_KickOffTeam.HostName);
				}
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9915u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_AutoDismissWarning:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(9557u);
				this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(9558u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_AutoDismiss:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(9559u);
				this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(9560u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_AMRankPrize:
			{
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(1339u);
				this.Cstr_Contents_S.IntToFormat((long)this.SC.Enotice_AMRankPrize.Place, 1, false);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(1366u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				this.mPrizeType = Detail_Prize.Enotice_AMRankPrize;
				byte prizeNum3 = this.SC.Enotice_AMRankPrize.PrizeNum;
				this.mDiamond = 0u;
				this.mValue = 0u;
				this.mNoValueCount = 0;
				this.tmplistItem.Clear();
				for (int num8 = 0; num8 < (int)prizeNum3; num8++)
				{
					this.bAddList = true;
					ushort itemID3 = this.SC.Enotice_AMRankPrize.PrizeData[num8].ItemID;
					byte num9 = this.SC.Enotice_AMRankPrize.PrizeData[num8].Num;
					this.tmpEQ = this.DM.EquipTable.GetRecordByKey(itemID3);
					if (this.tmpEQ.EquipKind == 11 && this.tmpEQ.PropertiesInfo[0].Propertieskey == 6)
					{
						this.bAddList = false;
						this.mDiamond += (uint)(this.tmpEQ.PropertiesInfo[1].Propertieskey * this.tmpEQ.PropertiesInfo[1].PropertiesValue * (ushort)num9);
						this.mValue += (uint)(this.tmpEQ.PropertiesInfo[1].Propertieskey * this.tmpEQ.PropertiesInfo[1].PropertiesValue * (ushort)num9);
					}
					else
					{
						this.ShopID = this.DM.TotalShopItemData.Find(itemID3);
						if (this.ShopID != 0 && this.DM.StoreData.GetRecordByKey(this.ShopID).Price > 0u)
						{
							this.mValue += this.DM.StoreData.GetRecordByKey(this.ShopID).Price * (uint)num9;
						}
						else
						{
							this.mNoValueCount += num9;
						}
					}
					if (this.bAddList)
					{
						this.tmplistItem.Add((ushort)num8);
					}
				}
				break;
			}
			case NoticeReport.Enotice_AllianceHomeKingdom:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(9567u);
				cstring6.Append(this.SC.Enotice_AllianceHomeKingdom.Leader);
				cstring7.Append(this.SC.Enotice_AllianceHomeKingdom.AllianceTag);
				this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
				this.Cstr_Contents_S.StringToFormat(cstring5);
				this.Cstr_Contents_S.IntToFormat((long)this.SC.Enotice_AllianceHomeKingdom.HomeKingdom, 1, false);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9572u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_WorldKingPrize:
			{
				this.mPrizeType = Detail_Prize.Enotice_WorldKingPrize;
				this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11024u));
				this.text_Title.text = this.DM.mStringTable.GetStringByID(11023u);
				this.mStatus = 21;
				byte prizeNum4 = this.SC.Enotice_WorldKingPrize.PrizeNum;
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				this.mDiamond = 0u;
				this.mValue = 0u;
				this.mNoValueCount = 0;
				this.tmplistItem.Clear();
				for (int num10 = 0; num10 < (int)prizeNum4; num10++)
				{
					this.bAddList = true;
					ushort itemID4 = this.SC.Enotice_WorldKingPrize.PrizeData[num10].ItemID;
					byte num11 = this.SC.Enotice_WorldKingPrize.PrizeData[num10].Num;
					this.tmpEQ = this.DM.EquipTable.GetRecordByKey(itemID4);
					if (this.tmpEQ.EquipKind == 11 && this.tmpEQ.PropertiesInfo[0].Propertieskey == 6)
					{
						this.bAddList = false;
						this.mDiamond += (uint)(this.tmpEQ.PropertiesInfo[1].Propertieskey * this.tmpEQ.PropertiesInfo[1].PropertiesValue * (ushort)num11);
						this.mValue += (uint)(this.tmpEQ.PropertiesInfo[1].Propertieskey * this.tmpEQ.PropertiesInfo[1].PropertiesValue * (ushort)num11);
					}
					else
					{
						this.ShopID = this.DM.TotalShopItemData.Find(itemID4);
						if (this.ShopID != 0 && this.DM.StoreData.GetRecordByKey(this.ShopID).Price > 0u)
						{
							this.mValue += this.DM.StoreData.GetRecordByKey(this.ShopID).Price * (uint)num11;
						}
						else
						{
							this.mNoValueCount += num11;
						}
					}
					if (this.bAddList)
					{
						this.tmplistItem.Add((ushort)num10);
					}
				}
				break;
			}
			case NoticeReport.Enotice_BackendAddCrystal:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8173u);
				this.Cstr_Contents_S.IntToFormat((long)((ulong)this.SC.Enotice_BackendAddCrystal.Crystal), 1, true);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(8174u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_KOWTelItem:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8472u);
				this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11040u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_LoginConpensate:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8173u);
				this.Cstr_Contents_S.IntToFormat((long)((ulong)this.SC.Enotice_LoginConpensate.Crystal), 1, true);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(11041u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_PurchaseConpensate:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8173u);
				this.Cstr_Contents_S.IntToFormat((long)((ulong)this.SC.Enotice_PurchaseConpensate.Crystal), 1, true);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(11042u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_RallyNPCCancel:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6067u);
				cstring6.Append(this.SC.Enotice_RallyNPCCancel.HostName);
				cstring7.Append(this.SC.Enotice_RallyNPCCancel.AllianceTag);
				this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
				cstring4.StringToFormat(cstring5);
				cstring4.StringToFormat(string.Empty);
				cstring4.AppendFormat(this.DM.mStringTable.GetStringByID(5389u));
				cstring5.ClearString();
				cstring6.ClearString();
				cstring7.ClearString();
				cstring5.IntToFormat((long)this.SC.Enotice_RallyNPCCancel.NPCLevel, 1, false);
				cstring5.AppendFormat(this.DM.mStringTable.GetStringByID(12021u));
				cstring8.StringToFormat(cstring5);
				cstring8.StringToFormat(string.Empty);
				cstring8.AppendFormat(this.DM.mStringTable.GetStringByID(5390u));
				this.Cstr_Contents_S.ClearString();
				this.Cstr_Contents_S.StringToFormat(cstring4);
				this.Cstr_Contents_S.StringToFormat(cstring8);
				this.Cstr_Contents_S.AppendFormat("{0}\n{1}");
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_RallyNPCCancelInvalid:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6067u);
				this.Cstr_Contents_S.ClearString();
				this.Cstr_Contents_S.IntToFormat((long)this.SC.Enotice_RallyNPCCancelInvalid.NPCLevel, 1, false);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(12024u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_ForceTeleport:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(12053u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(12054u);
				break;
			case NoticeReport.Enotice_LordEquipExpire:
			{
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(9665u);
				Equip recordByKey2 = this.DM.EquipTable.GetRecordByKey(this.SC.Enotice_LordEquipExpire.ItemID);
				CString cstring12 = StringManager.Instance.StaticString1024();
				cstring12.ClearString();
				cstring12.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey2.EquipName));
				if (this.SC.Enotice_LordEquipExpire.Rank == 1)
				{
					cstring12.AppendFormat("<color=#ffffffff>{0}</color>");
				}
				else if (this.SC.Enotice_LordEquipExpire.Rank == 2)
				{
					cstring12.AppendFormat("<color=#005a2fff>{0}</color>");
				}
				else if (this.SC.Enotice_LordEquipExpire.Rank == 3)
				{
					cstring12.AppendFormat("<color=#004fa7ff>{0}</color>");
				}
				else if (this.SC.Enotice_LordEquipExpire.Rank == 4)
				{
					cstring12.AppendFormat("<color=#5a1ca7ff>{0}</color>");
				}
				else if (this.SC.Enotice_LordEquipExpire.Rank == 5)
				{
					cstring12.AppendFormat("<color=#ffff00ff>{0}</color>");
				}
				this.Cstr_Contents_S.ClearString();
				this.Cstr_Contents_S.StringToFormat(cstring12.ToString());
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9666u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			}
			case NoticeReport.Enotice_WorldNotKingPrize:
			{
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(11023u);
				this.mPrizeType = Detail_Prize.Enotice_WorldNotKingPrize;
				this.Cstr_Contents_S.ClearString();
				if (this.SC.Enotice_WorldNotKingPrize.Place == 2)
				{
					this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11051u));
				}
				else if (this.SC.Enotice_WorldNotKingPrize.Place == 3)
				{
					this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11052u));
				}
				this.mStatus = 21;
				byte prizeNum5 = this.SC.Enotice_WorldNotKingPrize.PrizeNum;
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				this.mDiamond = 0u;
				this.mValue = 0u;
				this.mNoValueCount = 0;
				this.tmplistItem.Clear();
				for (int num12 = 0; num12 < (int)prizeNum5; num12++)
				{
					this.bAddList = true;
					ushort itemID5 = this.SC.Enotice_WorldNotKingPrize.PrizeData[num12].ItemID;
					byte num13 = this.SC.Enotice_WorldNotKingPrize.PrizeData[num12].Num;
					this.tmpEQ = this.DM.EquipTable.GetRecordByKey(itemID5);
					if (this.tmpEQ.EquipKind == 11 && this.tmpEQ.PropertiesInfo[0].Propertieskey == 6)
					{
						this.bAddList = false;
						this.mDiamond += (uint)(this.tmpEQ.PropertiesInfo[1].Propertieskey * this.tmpEQ.PropertiesInfo[1].PropertiesValue * (ushort)num13);
						this.mValue += (uint)(this.tmpEQ.PropertiesInfo[1].Propertieskey * this.tmpEQ.PropertiesInfo[1].PropertiesValue * (ushort)num13);
					}
					else
					{
						this.ShopID = this.DM.TotalShopItemData.Find(itemID5);
						if (this.ShopID != 0 && this.DM.StoreData.GetRecordByKey(this.ShopID).Price > 0u)
						{
							this.mValue += this.DM.StoreData.GetRecordByKey(this.ShopID).Price * (uint)num13;
						}
						else
						{
							this.mNoValueCount += num13;
						}
					}
					if (this.bAddList)
					{
						this.tmplistItem.Add((ushort)num12);
					}
				}
				break;
			}
			case NoticeReport.Enotice_BuyEmoteTreasure:
				this.Gifts_T.gameObject.SetActive(true);
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8236u);
				this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(this.SC.Enotice_BuyEmoteTreasure.ItemID).EquipName));
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(12070u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_LordPoisonEffect:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(15009u);
				this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(15010u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_PrisnerUsePoison:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(15011u);
				cstring6.Append(this.SC.Enotice_PrisnerUsePoison.Name);
				cstring7.Append(this.SC.Enotice_PrisnerUsePoison.AllianceTag);
				if (this.SC.Enotice_PrisnerUsePoison.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, this.SC.Enotice_PrisnerUsePoison.HomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
				}
				this.Cstr_Contents_S.StringToFormat(cstring5);
				this.Cstr_Contents_S.IntToFormat((long)((ulong)(this.SC.Enotice_PrisnerUsePoison.EffectTime / 3600u)), 1, false);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(15012u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_PrisnerPoisonEffect:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(15011u);
				cstring6.Append(this.SC.Enotice_PrisnerPoisonEffect.Name);
				cstring7.Append(this.SC.Enotice_PrisnerPoisonEffect.AllianceTag);
				if (this.SC.Enotice_PrisnerPoisonEffect.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, this.SC.Enotice_PrisnerPoisonEffect.HomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
				}
				this.Cstr_Contents_S.StringToFormat(cstring5);
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(15013u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_BackendActivity:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(11053u);
				this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11054u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_BuyCastleSkinTreasure:
			{
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8236u);
				CastleSkinTbl recordByKey3 = this.GUIM.BuildingData.castleSkin.CastleSkinTable.GetRecordByKey(this.SC.Enotice_BuyCastleSkinTreasure.CastleSkinID);
				this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey3.Name));
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9685u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			}
			case NoticeReport.Enotice_FederalRankPrize:
			{
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(11091u);
				this.mPrizeType = Detail_Prize.Enotice_FederalRankPrize;
				this.Cstr_Contents_S.ClearString();
				if (this.SC.Enotice_FederalRankPrize.Place == 1)
				{
					this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11092u));
				}
				else if (this.SC.Enotice_FederalRankPrize.Place == 2)
				{
					this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11108u));
				}
				else if (this.SC.Enotice_FederalRankPrize.Place == 3)
				{
					this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11109u));
				}
				this.mStatus = 21;
				byte prizeNum6 = this.SC.Enotice_FederalRankPrize.PrizeNum;
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				this.mDiamond = 0u;
				this.mValue = 0u;
				this.mNoValueCount = 0;
				this.tmplistItem.Clear();
				for (int num14 = 0; num14 < (int)prizeNum6; num14++)
				{
					this.bAddList = true;
					ushort itemID6 = this.SC.Enotice_FederalRankPrize.PrizeData[num14].ItemID;
					byte num15 = this.SC.Enotice_FederalRankPrize.PrizeData[num14].Num;
					this.tmpEQ = this.DM.EquipTable.GetRecordByKey(itemID6);
					if (this.tmpEQ.EquipKind == 11 && this.tmpEQ.PropertiesInfo[0].Propertieskey == 6)
					{
						this.bAddList = false;
						this.mDiamond += (uint)(this.tmpEQ.PropertiesInfo[1].Propertieskey * this.tmpEQ.PropertiesInfo[1].PropertiesValue * (ushort)num15);
						this.mValue += (uint)(this.tmpEQ.PropertiesInfo[1].Propertieskey * this.tmpEQ.PropertiesInfo[1].PropertiesValue * (ushort)num15);
					}
					else
					{
						this.ShopID = this.DM.TotalShopItemData.Find(itemID6);
						if (this.ShopID != 0 && this.DM.StoreData.GetRecordByKey(this.ShopID).Price > 0u)
						{
							this.mValue += this.DM.StoreData.GetRecordByKey(this.ShopID).Price * (uint)num15;
						}
						else
						{
							this.mNoValueCount += num15;
						}
					}
					if (this.bAddList)
					{
						this.tmplistItem.Add((ushort)num14);
					}
				}
				break;
			}
			case NoticeReport.Enotice_FederalTelBack:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(11093u);
				this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11094u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_RcvGiftRestrict:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(16028u);
				this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(16029u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_CancelRcvGiftRestrict:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(16030u);
				this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(16031u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_TreasureBackPrize:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8236u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(10077u);
				break;
			case NoticeReport.Enotice_LookingForStringTable:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(this.SC.Enotice_LookingForStringTable.Title);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(this.SC.Enotice_LookingForStringTable.Content);
				break;
			case NoticeReport.Enotice_MarchingPet_Cancel:
			{
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(10106u);
				this.Cstr_Contents_S.ClearString();
				if (this.SC.Enotice_MarchingPet_Cancel.HasTarget > 0)
				{
					cstring6.Append(this.SC.Enotice_MarchingPet_Cancel.Name);
					if (this.SC.Enotice_MarchingPet_Cancel.AllianceTag != string.Empty)
					{
						cstring7.Append(this.SC.Enotice_MarchingPet_Cancel.AllianceTag);
						if (this.SC.Enotice_MarchingPet_Cancel.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
						{
							this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, this.SC.Enotice_MarchingPet_Cancel.HomeKingdom, this.GUIM.IsArabic);
						}
						else
						{
							this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
						}
					}
					else if (this.SC.Enotice_MarchingPet_Cancel.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, this.SC.Enotice_MarchingPet_Cancel.HomeKingdom, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, 0, this.GUIM.IsArabic);
					}
				}
				PetTbl recordByKey4 = PetManager.Instance.PetTable.GetRecordByKey(this.SC.Enotice_MarchingPet_Cancel.PetID);
				PetSkillTbl recordByKey5 = PetManager.Instance.PetSkillTable.GetRecordByKey(this.SC.Enotice_MarchingPet_Cancel.Skill_ID);
				cstring6.ClearString();
				cstring6.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey4.Name));
				cstring6.IntToFormat((long)this.SC.Enotice_MarchingPet_Cancel.Skill_LV, 1, false);
				cstring6.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey5.Name));
				cstring6.AppendFormat(this.DM.mStringTable.GetStringByID(10107u));
				if (this.SC.Enotice_MarchingPet_Cancel.HasTarget > 0)
				{
					cstring6.Append(cstring5);
				}
				this.Cstr_Contents_S.StringToFormat(cstring6);
				this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID(10099u));
				this.Cstr_Contents_S.AppendFormat("{0}\n{1}");
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			}
			case NoticeReport.ENotice_PetStarUp:
			{
				PetTbl recordByKey6 = PetManager.Instance.PetTable.GetRecordByKey(this.SC.ENotice_PetStarUp.PetID);
				this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(recordByKey6.HeroID);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(10121u);
				this.SC.ENotice_PetStarUp.PetStar = (byte)Mathf.Clamp((int)this.SC.ENotice_PetStarUp.PetStar, 0, recordByKey6.PetSkill.Length - 1);
				PetSkillTbl recordByKey7 = PetManager.Instance.PetSkillTable.GetRecordByKey(recordByKey6.PetSkill[(int)this.SC.ENotice_PetStarUp.PetStar]);
				this.Cstr_Contents_S.ClearString();
				cstring5.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey6.Name));
				if (this.SC.ENotice_PetStarUp.PetStar == 1)
				{
					cstring5.StringToFormat(this.DM.mStringTable.GetStringByID(16067u));
				}
				else
				{
					cstring5.StringToFormat(this.DM.mStringTable.GetStringByID(16068u));
				}
				cstring5.AppendFormat(this.DM.mStringTable.GetStringByID(10122u));
				cstring5.Append("\n \n \n");
				if (this.SC.ENotice_PetStarUp.PetStar == 1)
				{
					cstring6.IntToFormat(50L, 1, false);
				}
				else
				{
					cstring6.IntToFormat(60L, 1, false);
				}
				if ((int)this.SC.ENotice_PetStarUp.PetStar < recordByKey6.PetSkill.Length && recordByKey6.PetSkill[(int)this.SC.ENotice_PetStarUp.PetStar] > 0)
				{
					cstring6.AppendFormat(this.DM.mStringTable.GetStringByID(10124u));
					this.Img_HeroSkill[0].gameObject.SetActive(true);
					this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(10118u);
					this.text_Skill_1[0].text = this.DM.mStringTable.GetStringByID((uint)recordByKey7.Name);
					if (recordByKey7.Type == 1)
					{
						if (recordByKey7.Subject == 1)
						{
							this.text_Skill_1[1].text = this.DM.mStringTable.GetStringByID(10083u);
						}
						else if (recordByKey7.Subject == 2)
						{
							this.text_Skill_1[1].text = this.DM.mStringTable.GetStringByID(10084u);
						}
						else if (recordByKey7.Subject == 3)
						{
							this.text_Skill_1[1].text = this.DM.mStringTable.GetStringByID(10085u);
						}
						else
						{
							this.text_Skill_1[1].text = string.Empty;
						}
					}
					else if (recordByKey7.Type == 2)
					{
						this.text_Skill_1[1].text = this.DM.mStringTable.GetStringByID(10091u);
					}
					else
					{
						this.text_Skill_1[1].text = string.Empty;
					}
					this.Img_HeroSkill[0].rectTransform.anchoredPosition = new Vector2(0f, this.Img_HeroSkill[0].rectTransform.anchoredPosition.y);
					this.Cstr_SkillIcon[0].ClearString();
					this.Cstr_SkillIcon[0].IntToFormat((long)recordByKey7.Icon, 5, false);
					this.Cstr_SkillIcon[0].AppendFormat("s{0}");
					this.Img_HeroSkill_1[0].sprite = this.GUIM.LoadSkillSprite(this.Cstr_SkillIcon[0]);
				}
				else
				{
					cstring6.AppendFormat(this.DM.mStringTable.GetStringByID(10123u));
					this.Img_HeroSkill[0].gameObject.SetActive(false);
				}
				this.Cstr_Contents_S.StringToFormat(cstring5);
				this.Cstr_Contents_S.StringToFormat(cstring6);
				this.Cstr_Contents_S.AppendFormat("{0}{1}");
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			}
			case NoticeReport.ENotice_PrisonerPetSkillEscaped:
			{
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6070u);
				this.Cstr_Contents_S.ClearString();
				PetTbl recordByKey8 = PetManager.Instance.PetTable.GetRecordByKey(this.SC.ENotice_PrisonerPetSkillEscaped.PetID);
				PetSkillTbl recordByKey9 = PetManager.Instance.PetSkillTable.GetRecordByKey(this.SC.ENotice_PrisonerPetSkillEscaped.Skill_ID);
				this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey8.Name));
				this.Cstr_Contents_S.IntToFormat((long)this.SC.ENotice_PrisonerPetSkillEscaped.Skill_LV, 1, false);
				this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey9.Name));
				if (recordByKey9.Type == 1)
				{
					this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(10114u));
				}
				else
				{
					this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(10116u));
				}
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			}
			case NoticeReport.ENotice_LordPetSkillEscaped:
			{
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(6070u);
				this.Cstr_Contents_S.ClearString();
				PetTbl recordByKey10 = PetManager.Instance.PetTable.GetRecordByKey(this.SC.ENotice_LordPetSkillEscaped.PetID);
				PetSkillTbl recordByKey11 = PetManager.Instance.PetSkillTable.GetRecordByKey(this.SC.ENotice_LordPetSkillEscaped.Skill_ID);
				this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey10.Name));
				this.Cstr_Contents_S.IntToFormat((long)this.SC.ENotice_LordPetSkillEscaped.Skill_LV, 1, false);
				this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey11.Name));
				if (recordByKey11.Type == 1)
				{
					this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(10115u));
				}
				else
				{
					this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(10117u));
				}
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			}
			case NoticeReport.Enotice_FirstUnderPetAttack:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(10101u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(10111u);
				break;
			case NoticeReport.Enotice_ScoutTargetLeave:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(10109u);
				this.Cstr_Contents_S.ClearString();
				if (this.SC.Enotice_ScoutTargetLeave.OffsetLen > 0u)
				{
					cstring6.Append(this.SC.Enotice_ScoutTargetLeave.Name);
					if (this.SC.Enotice_ScoutTargetLeave.AllianceTag != string.Empty)
					{
						cstring7.Append(this.SC.Enotice_ScoutTargetLeave.AllianceTag);
						if (this.SC.Enotice_ScoutTargetLeave.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
						{
							this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, this.SC.Enotice_ScoutTargetLeave.HomeKingdom, this.GUIM.IsArabic);
						}
						else
						{
							this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
						}
					}
					else if (this.SC.Enotice_ScoutTargetLeave.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, this.SC.Enotice_ScoutTargetLeave.HomeKingdom, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, 0, this.GUIM.IsArabic);
					}
					cstring6.ClearString();
					cstring6.StringToFormat(cstring5);
					cstring6.AppendFormat(this.DM.mStringTable.GetStringByID(10126u));
				}
				else
				{
					cstring6.Append(this.DM.mStringTable.GetStringByID(10131u));
				}
				this.Cstr_Contents_S.StringToFormat(cstring6);
				this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID(10099u));
				this.Cstr_Contents_S.AppendFormat("{0}\n{1}");
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_AttackTargetLeave:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(10108u);
				this.Cstr_Contents_S.ClearString();
				if (this.SC.Enotice_AttackTargetLeave.OffsetLen > 0u)
				{
					cstring6.Append(this.SC.Enotice_AttackTargetLeave.Name);
					if (this.SC.Enotice_AttackTargetLeave.AllianceTag != string.Empty)
					{
						cstring7.Append(this.SC.Enotice_AttackTargetLeave.AllianceTag);
						if (this.SC.Enotice_AttackTargetLeave.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
						{
							this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, this.SC.Enotice_AttackTargetLeave.HomeKingdom, this.GUIM.IsArabic);
						}
						else
						{
							this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
						}
					}
					else if (this.SC.Enotice_AttackTargetLeave.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, this.SC.Enotice_AttackTargetLeave.HomeKingdom, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, 0, this.GUIM.IsArabic);
					}
					cstring6.ClearString();
					cstring6.StringToFormat(cstring5);
					cstring6.AppendFormat(this.DM.mStringTable.GetStringByID(10125u));
				}
				else
				{
					cstring6.Append(this.DM.mStringTable.GetStringByID(10130u));
				}
				this.Cstr_Contents_S.StringToFormat(cstring6);
				this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID(10099u));
				this.Cstr_Contents_S.AppendFormat("{0}\n{1}");
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_MaintainCompensation:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID((uint)this.SC.Enotice_MaintainCompensation.MailTitleStrID);
				this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID((uint)this.SC.Enotice_MaintainCompensation.MailContentStrID));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_BuyRedPocketTreasure:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8236u);
				this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.SC.Enotice_BuyRedPocketTreasure.StringID));
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(11198u));
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			case NoticeReport.Enotice_SocialFriendModify:
			{
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(12177u);
				ushort id2 = 12174;
				if (this.SC.Enotice_SocialFriendModify.PlayerName.Length == 0 && this.SC.Enotice_SocialFriendModify.TargetName.Length == 0)
				{
					if (this.SC.Enotice_SocialFriendModify.RemoveType == 0)
					{
						id2 = 12196;
					}
					else if (this.SC.Enotice_SocialFriendModify.RemoveType == 1)
					{
						id2 = 12197;
					}
					if (this.SC.Enotice_SocialFriendModify.RemoveType < 2)
					{
						this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID((uint)id2));
					}
				}
				else
				{
					if (this.SC.Enotice_SocialFriendModify.RemoveType == 1)
					{
						id2 = 12175;
					}
					else if (this.SC.Enotice_SocialFriendModify.RemoveType == 2)
					{
						id2 = 12176;
					}
					else if (this.SC.Enotice_SocialFriendModify.RemoveType == 3)
					{
						id2 = 12198;
					}
					cstring6.Append(this.SC.Enotice_SocialFriendModify.PlayerName);
					cstring7.Append(this.SC.Enotice_SocialFriendModify.PlayerTag);
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_SocialFriendModify.TargetName);
					this.Cstr_Contents_S.StringToFormat(cstring5);
					this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID((uint)id2));
				}
				this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
				break;
			}
			case NoticeReport.Enotice_ReturnCeremony:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(10175u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(10176u);
				break;
			case NoticeReport.Enotice_FirstBuyTreasurePrize:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8236u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(10188u);
				break;
			default:
				this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(1049u);
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(1049u);
				break;
			}
			this.text_Contents_S.SetAllDirty();
			this.text_Contents_S.cachedTextGenerator.Invalidate();
			this.text_Contents_S.cachedTextGeneratorForLayout.Invalidate();
			if (this.SC.Type != NoticeReport.Enotice_WorldNotKingPrize && this.SC.Type != NoticeReport.Enotice_BuyEmoteTreasure)
			{
				if (this.text_Contents_S.preferredHeight > 216f)
				{
					this.text_Contents_S.rectTransform.sizeDelta = new Vector2(this.text_Contents_S.rectTransform.sizeDelta.x, this.text_Contents_S.preferredHeight + 1f);
				}
				if (this.text_Contents_S.preferredHeight + 18f > 425f)
				{
					this.Mask_S_SR.enabled = true;
					this.Content_RT2.sizeDelta = new Vector2(this.Content_RT2.sizeDelta.x, 18f + this.text_Contents_S.preferredHeight);
				}
				else
				{
					this.Mask_S_SR.enabled = false;
					this.Content_RT2.sizeDelta = new Vector2(this.Content_RT2.sizeDelta.x, 425f);
				}
			}
			else
			{
				this.Mask_S_SR.enabled = false;
				this.text_Contents_S.resizeTextForBestFit = true;
				this.text_Contents_S.resizeTextMaxSize = 20;
				if (this.text_Contents_S.preferredHeight > 100f)
				{
					this.text_Contents_S.rectTransform.sizeDelta = new Vector2(this.text_Contents_S.rectTransform.sizeDelta.x, 100f);
				}
			}
			this.Img_TitleIcon.sprite = this.SArray.m_Sprites[this.mStatus];
			this.Img_TitleIcon.SetNativeSize();
			this.Img_Hero_S.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
			this.Letter_S_T.gameObject.SetActive(true);
			if (this.MaxLetterNum > 1)
			{
				if (this.SC.Index + 1 == 1)
				{
					this.btn_Previous.gameObject.SetActive(false);
					if (!this.btn_Next.IsActive())
					{
						this.btn_Next.gameObject.SetActive(true);
					}
				}
				if ((int)(this.SC.Index + 1) == this.MaxLetterNum)
				{
					this.btn_Next.gameObject.SetActive(false);
					if (!this.btn_Previous.IsActive())
					{
						this.btn_Previous.gameObject.SetActive(true);
					}
				}
			}
			else
			{
				this.btn_Previous.gameObject.SetActive(false);
				this.btn_Next.gameObject.SetActive(false);
			}
		}
		else if (this.mLetterKind == 2)
		{
			this.text_Title.text = this.DM.mStringTable.GetStringByID(8217u);
			this.text_Time[0].text = GameConstants.GetDateTime(this.CR.Times).ToString("MM/dd/yy");
			this.text_Time[1].text = GameConstants.GetDateTime(this.CR.Times).ToString("HH:mm:ss");
			this.tmpHero = this.DM.HeroTable.GetRecordByKey(101);
			this.Img_Hero_S.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
			if (this.CR.Monster.Result < 3)
			{
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(8220u);
			}
			else
			{
				this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(8219u);
			}
			this.text_Contents_S.SetAllDirty();
			this.text_Contents_S.cachedTextGenerator.Invalidate();
			this.text_Name.gameObject.SetActive(false);
			this.MonsterXY_T.gameObject.SetActive(true);
			this.btn_MonsterXY.gameObject.SetActive(true);
			this.Cstr_Name.ClearString();
			this.Cstr_Contents_S.ClearString();
			this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.CR.Monster.Zone, this.CR.Monster.Point));
			this.Cstr_Contents_S.IntToFormat((long)this.CR.Monster.KindgomID, 1, false);
			this.Cstr_Contents_S.IntToFormat((long)((int)this.tmpV.x), 1, false);
			this.Cstr_Contents_S.IntToFormat((long)((int)this.tmpV.y), 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Contents_S.AppendFormat("{0}:K {1}:X {2}:Y");
			}
			else
			{
				this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
			}
			this.Cstr_Name.StringToFormat(this.Cstr_Contents_S);
			this.Cstr_Name.AppendFormat(this.DM.mStringTable.GetStringByID(8218u));
			this.text_MonsterXY.text = this.Cstr_Name.ToString();
			this.text_MonsterXY.SetAllDirty();
			this.text_MonsterXY.cachedTextGenerator.Invalidate();
			this.text_MonsterXY.cachedTextGeneratorForLayout.Invalidate();
			this.tmpRC = this.btn_MonsterXY.transform.GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.text_MonsterXY.preferredWidth, this.tmpRC.sizeDelta.y);
			this.tmpRC = this.btn_MonsterXY.transform.GetChild(0).GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.text_MonsterXY.preferredWidth, this.tmpRC.sizeDelta.y);
			this.tmpRC = this.btn_MonsterXY.transform.GetChild(1).GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.text_MonsterXY.preferredWidth, this.tmpRC.sizeDelta.y);
			this.Letter_S_T.gameObject.SetActive(true);
			this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_MAX);
			this.tmpPageNum = (int)(this.CR.Index + 1);
			if (this.MaxLetterNum > 1)
			{
				if (this.CR.Index + 1 == 1)
				{
					this.btn_Previous.gameObject.SetActive(false);
					if (!this.btn_Next.IsActive())
					{
						this.btn_Next.gameObject.SetActive(true);
					}
				}
				if ((int)(this.CR.Index + 1) == this.MaxLetterNum)
				{
					this.btn_Next.gameObject.SetActive(false);
					if (!this.btn_Previous.IsActive())
					{
						this.btn_Previous.gameObject.SetActive(true);
					}
				}
			}
			else
			{
				this.btn_Previous.gameObject.SetActive(false);
				this.btn_Next.gameObject.SetActive(false);
			}
		}
		this.UpdateBaseline();
	}

	// Token: 0x06001D63 RID: 7523 RVA: 0x003612E8 File Offset: 0x0035F4E8
	public override void OnClose()
	{
		if (this.Cstr_Name != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Name);
		}
		if (this.Cstr_Page != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Page);
		}
		if (this.Cstr_Skill != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Skill);
		}
		if (this.Cstr_Title != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Title);
		}
		if (this.Cstr_Contents_S != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Contents_S);
		}
		if (this.Cstr_S_Title != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_S_Title);
		}
		if (this.Cstr_LordEquip_Lv != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_LordEquip_Lv);
		}
		if (this.Cstr_Translation != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Translation);
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.Cstr_Time[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Time[i]);
			}
			if (this.Cstr_SkillIcon[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_SkillIcon[i]);
			}
			if (this.Cstr_LordEquip[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_LordEquip[i]);
			}
			if (this.Cstr_Gifts[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Gifts[i]);
			}
		}
		for (int j = 0; j < 3; j++)
		{
			if (this.Cstr_S_Top[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_S_Top[j]);
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (this.Cstr_StarUpValue[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_StarUpValue[k]);
			}
		}
		for (int l = 0; l < 6; l++)
		{
			for (int m = 0; m < 5; m++)
			{
				if (this.Cstr_S_ItemNum[l] != null && this.Cstr_S_ItemNum[l][m] != null)
				{
					StringManager.Instance.DeSpawnString(this.Cstr_S_ItemNum[l][m]);
				}
			}
			for (int n = 0; n < 2; n++)
			{
				if (this.Cstr_LordEquip_Effect[l] != null && this.Cstr_LordEquip_Effect[l][n] != null)
				{
					StringManager.Instance.DeSpawnString(this.Cstr_LordEquip_Effect[l][n]);
				}
			}
		}
		for (int num = 0; num < 6; num++)
		{
			if (this.Cstr_BookMarkList2[num] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_BookMarkList2[num]);
			}
		}
	}

	// Token: 0x06001D64 RID: 7524 RVA: 0x003615A8 File Offset: 0x0035F7A8
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
			this.Open_NP_Mail(false);
			break;
		case 2:
			this.Open_NP_Mail(true);
			break;
		case 3:
			this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(6038u), this.DM.mStringTable.GetStringByID(6039u), 1, 0, this.DM.mStringTable.GetStringByID(6036u), this.DM.mStringTable.GetStringByID(6037u));
			break;
		case 5:
			if (this.Favor.Kind == MailType.EMAIL_FAVORY)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(6100u), 255, true);
				return;
			}
			this.DM.MailReportSave(this.MC.SerialID);
			break;
		case 6:
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring.Append(this.text_Name.text);
			if (this.DM.FindBlackList(cstring))
			{
				cstring.ClearString();
				cstring.StringToFormat(this.text_Name.text);
				cstring.AppendFormat(this.DM.mStringTable.GetStringByID(5382u));
				this.GUIM.AddHUDMessage(cstring.ToString(), 255, true);
				return;
			}
			this.DM.Letter_ReplyName = this.MC.SenderName;
			this.DM.Letter_ReplyTitle = this.MC.Title;
			this.DM.Letter_ReplyName_KTN.Length = 0;
			this.DM.Letter_ReplyName_KTN.Append(this.MC.SenderName);
			int arg = 0;
			if (this.MC.MailType == 1)
			{
				this.DM.Letter_ReplyTitle_Alliance.Length = 0;
				this.DM.Letter_ReplyTitle_Alliance.Append(this.text_Title.text);
				arg = 1;
			}
			else
			{
				this.DM.Letter_ReplyTitle_Alliance.Length = 0;
				this.DM.Letter_ReplyTitle_Alliance.Append(this.MC.Title);
			}
			if (this.MC.ReplyID == 0u)
			{
				this.DM.Letter_ReplyID = this.MC.SerialID;
			}
			else
			{
				this.DM.Letter_ReplyID = this.MC.ReplyID;
			}
			this.door.CloseMenu(false);
			this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 1, arg, false);
			break;
		}
		case 8:
			this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(6038u), this.DM.mStringTable.GetStringByID(6039u), 2, 0, this.DM.mStringTable.GetStringByID(6036u), this.DM.mStringTable.GetStringByID(6037u));
			break;
		case 9:
			if (this.Favor.Kind == MailType.EMAIL_FAVORY)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(6100u), 255, true);
				return;
			}
			if (this.mLetterKind != 2)
			{
				this.DM.SystemReportSave(this.SC.SerialID);
			}
			else
			{
				this.DM.BattleReportSave(this.CR.SerialID);
			}
			break;
		case 10:
			this.DM.AllianceView.Id = this.SC.Notice_InviteAlliance.AllianceID;
			this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5, 0, false);
			for (int i = this.door.m_WindowStack.Count - 1; i >= 0; i--)
			{
				if (this.door.m_WindowStack[i].m_eWindow == EGUIWindow.UI_LetterDetail || this.door.m_WindowStack[i].m_eWindow == EGUIWindow.UI_Letter)
				{
					this.door.m_WindowStack.RemoveAt(i);
				}
			}
			break;
		case 14:
			this.door.GoToPointCode(this.CR.Monster.KindgomID, this.CR.Monster.Zone, this.CR.Monster.Point, 0);
			break;
		case 15:
			ActivityManager.Instance.Send_ACTIVITY_EVENT_LIST();
			break;
		case 17:
			if (this.MC.Translation && this.bTrans && this.DM.CheckLanguageTranslateByIdx((int)this.MC.LanguageSource) && this.MC.LanguageTarget == (byte)this.DM.UserLanguage)
			{
				this.bTransBtnStatus = !this.bTransBtnStatus;
				if (this.mLetterKind == 0 && this.MC.MailType != 2)
				{
					if (this.bTransBtnStatus)
					{
						this.Cstr_Translation.ClearString();
						this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID(this.MC.LanguageSource));
						this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054u));
						this.text_Translation.text = this.Cstr_Translation.ToString();
					}
					else
					{
						this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052u);
					}
					this.text_Translation.SetAllDirty();
					this.text_Translation.cachedTextGenerator.Invalidate();
					this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
					if (this.text_Translation.preferredWidth > this.text_Translation.rectTransform.sizeDelta.x)
					{
						this.text_Translation.rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, this.text_Translation.rectTransform.sizeDelta.y);
					}
					if (this.GUIM.IsArabic)
					{
						this.text_Translation.UpdateArabicPos();
					}
					if (this.MC.MailType == 1)
					{
						this.Cstr_Title.ClearString();
						this.Cstr_Title.StringToFormat(this.DM.mStringTable.GetStringByID(6014u));
						if (this.bTransBtnStatus && this.GUIM.CheckNeedTranslate(this.MC.Title))
						{
							this.Cstr_Title.StringToFormat(this.MC.TitleT);
						}
						else
						{
							this.Cstr_Title.StringToFormat(this.MC.Title);
						}
						this.Cstr_Title.AppendFormat("{0}{1}");
						this.text_Title.text = this.Cstr_Title.ToString();
					}
					else if (this.MC.MailType == 3)
					{
						this.text_Title.text = this.DM.mStringTable.GetStringByID(1474u);
					}
					else if (this.bTransBtnStatus && this.GUIM.CheckNeedTranslate(this.MC.Title))
					{
						this.text_Title.text = this.MC.TitleT;
					}
					else
					{
						this.text_Title.text = this.MC.Title;
					}
					this.text_Title.SetAllDirty();
					this.text_Title.cachedTextGenerator.Invalidate();
					if (this.bTransBtnStatus)
					{
						this.text_Contents.text = this.MC.ContentT;
					}
					else
					{
						this.text_Contents.text = this.MC.Content;
					}
					this.text_Contents.SetAllDirty();
					this.text_Contents.cachedTextGeneratorForLayout.Invalidate();
					this.text_Contents.cachedTextGenerator.Invalidate();
					if (this.text_Contents.preferredHeight > 158f)
					{
						this.text_Contents.rectTransform.sizeDelta = new Vector2(this.text_Contents.rectTransform.sizeDelta.x, this.text_Contents.preferredHeight + 1f);
						this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, -193f - (this.text_Contents.preferredHeight + 1f - 158f) - 33f);
						this.text_Translation.rectTransform.anchoredPosition = new Vector2(this.text_Translation.rectTransform.anchoredPosition.x, -179f - (this.text_Contents.preferredHeight + 1f - 158f) - 33f);
					}
					if (this.text_Contents.preferredHeight + 18f + 84f > 425f)
					{
						this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 102f + this.text_Contents.preferredHeight);
					}
					else
					{
						this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 425f);
					}
				}
			}
			else if (this.DM.MailTranslate(this.Favor.Serial, this.Favor.Kind))
			{
				this.Img_Translate.gameObject.SetActive(true);
				this.btn_Translation.gameObject.SetActive(false);
				this.text_Translation.gameObject.SetActive(false);
			}
			else
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8459u), 255, true);
			}
			break;
		case 18:
			if (this.MC != null && this.MC.SenderName != null && this.MC.SenderName != string.Empty)
			{
				if (this.MC.MailType == 4 && sender.m_BtnID2 == 2)
				{
					DataManager.Instance.ShowLordProfile(this.DM.RoleAttr.Name.ToString());
				}
				else
				{
					DataManager.Instance.ShowLordProfile(this.MC.SenderName);
				}
			}
			break;
		case 19:
			if (this.DM.RoleAlliance.Id == 0u)
			{
				DataManager.Instance.SetSelectRequest = 0;
				this.door.OpenMenu(EGUIWindow.UI_AllianceHint, 11, 0, false);
			}
			else
			{
				this.GUIM.MsgStr.ClearString();
				this.GUIM.MsgStr.StringToFormat(this.DM.RoleAlliance.Name);
				this.GUIM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(598u));
				this.GUIM.AddHUDMessage(this.GUIM.MsgStr.ToString(), 255, true);
			}
			break;
		}
	}

	// Token: 0x06001D65 RID: 7525 RVA: 0x00362168 File Offset: 0x00360368
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		switch (uibutton.m_BtnID1)
		{
		case 11:
			if (this.SC.Type == NoticeReport.ENotice_Enhance)
			{
				this.GUIM.m_SkillInfo.Show(sender, (uint)this.SC.NoticeHeroEnhance.HeroID, this.SC.NoticeHeroEnhance.Rank / 2 + 4, 0, 0, false);
			}
			else if (this.SC.Type == NoticeReport.ENotice_PetStarUp)
			{
				PetTbl recordByKey = PetManager.Instance.PetTable.GetRecordByKey(this.SC.ENotice_PetStarUp.PetID);
				this.SC.ENotice_PetStarUp.PetStar = (byte)Mathf.Clamp((int)this.SC.ENotice_PetStarUp.PetStar, 0, recordByKey.PetSkill.Length - 1);
				PetSkillTbl recordByKey2 = PetManager.Instance.PetSkillTable.GetRecordByKey(recordByKey.PetSkill[(int)this.SC.ENotice_PetStarUp.PetStar]);
				this.SC.ENotice_PetStarUp.PetStar = (byte)Mathf.Clamp((int)this.SC.ENotice_PetStarUp.PetStar, 0, recordByKey.PetSkill.Length - 1);
				this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Normal, 0, recordByKey.PetSkill[(int)this.SC.ENotice_PetStarUp.PetStar], 1, Vector2.zero, UIButtonHint.ePosition.Original);
			}
			break;
		case 12:
		{
			CalcAttrDataType calcAttrDataType = default(CalcAttrDataType);
			byte[] array = new byte[4];
			CurHeroData curHeroData = this.DM.curHeroData[(uint)this.SC.NoticeHeroEnhance.HeroID];
			calcAttrDataType.SkillLV1 = curHeroData.SkillLV[0];
			calcAttrDataType.SkillLV2 = curHeroData.SkillLV[1];
			calcAttrDataType.SkillLV3 = curHeroData.SkillLV[2];
			calcAttrDataType.SkillLV4 = curHeroData.SkillLV[3];
			for (int i = 0; i < 4; i++)
			{
				array[i] = curHeroData.SkillLV[i];
			}
			calcAttrDataType.LV = curHeroData.Level;
			calcAttrDataType.Star = curHeroData.Star;
			calcAttrDataType.Enhance = curHeroData.Enhance;
			calcAttrDataType.Equip = curHeroData.Equip;
			uint num = 0u;
			ushort[] array2 = new ushort[28];
			BSInvokeUtil getInstance = BSInvokeUtil.getInstance;
			Array.Clear(array2, 0, array2.Length);
			getInstance.setCalculateAttribute(curHeroData.ID, ref calcAttrDataType, ref num, array2);
			this.mSkill = this.DM.SkillTable.GetRecordByKey(this.tmpHero.AttackPower[(int)(this.SC.NoticeHeroEnhance.Rank / 2 + 1)]);
			ushort heroAttrValA = GameConstants.SetHintValue(array2, this.mSkill.HurtKind, true);
			ushort heroAttrValB = GameConstants.SetHintValue(array2, this.mSkill.HurtKind, false);
			CurHeroData curHeroData2 = this.DM.curHeroData.Find((uint)this.SC.NoticeHeroEnhance.HeroID);
			if (this.DM.curHeroData.ContainsKey((uint)curHeroData2.ID))
			{
				this.GUIM.m_SkillInfo.Show(sender, (uint)curHeroData2.ID, this.SC.NoticeHeroEnhance.Rank / 2, heroAttrValA, heroAttrValB, false);
			}
			break;
		}
		case 16:
			this.GUIM.m_SkillInfo.Show(sender, (uint)this.SC.NoticeHeroStarUp.HeroID, (byte)(uibutton.m_BtnID2 + 4), 0, 0, false);
			break;
		}
	}

	// Token: 0x06001D66 RID: 7526 RVA: 0x00362500 File Offset: 0x00360700
	public void OnButtonUp(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		switch (uibutton.m_BtnID1)
		{
		case 11:
		case 12:
		case 16:
			this.GUIM.m_SkillInfo.Hide(sender);
			break;
		}
		this.GUIM.m_Hint.Hide(true);
	}

	// Token: 0x06001D67 RID: 7527 RVA: 0x00362570 File Offset: 0x00360770
	public void OnHIButtonClick(UIHIBtn sender)
	{
		this.MM.OpenDetail(sender.HIID);
	}

	// Token: 0x06001D68 RID: 7528 RVA: 0x00362584 File Offset: 0x00360784
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelId == 1)
		{
			if (this.ItemT[panelObjectIdx] == null)
			{
				this.ItemT[panelObjectIdx] = item.GetComponent<Transform>();
				this.mScrollItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
				this.Item_P1[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(0);
				this.Item_P2[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(1);
				for (int i = 0; i < 5; i++)
				{
					this.Hbtn_Item[panelObjectIdx][i] = this.ItemT[panelObjectIdx].GetChild(1).GetChild(i).GetComponent<UIHIBtn>();
					this.Hbtn_Item[panelObjectIdx][i].m_Handler = this;
					this.Lebtn_Item[panelObjectIdx][i] = this.ItemT[panelObjectIdx].GetChild(1).GetChild(i + 5).GetComponent<UILEBtn>();
					this.Lebtn_Item[panelObjectIdx][i].m_Handler = this;
					this.text_S_ItemNum[panelObjectIdx][i] = this.ItemT[panelObjectIdx].GetChild(1).GetChild(i + 10).GetComponent<UIText>();
				}
				this.Item_P3[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(2);
				UIButton component = this.ItemT[panelObjectIdx].GetChild(2).GetChild(0).GetComponent<UIButton>();
				component.m_Handler = this;
			}
			if (dataIdx == 0)
			{
				this.Item_P1[panelObjectIdx].gameObject.SetActive(true);
				this.Item_P2[panelObjectIdx].gameObject.SetActive(false);
				this.Item_P3[panelObjectIdx].gameObject.SetActive(false);
			}
			else if (dataIdx < (this.tmplistItem.Count - 1) / 5 + 2)
			{
				this.Item_P1[panelObjectIdx].gameObject.SetActive(false);
				this.Item_P2[panelObjectIdx].gameObject.SetActive(true);
				this.Item_P3[panelObjectIdx].gameObject.SetActive(false);
				this.mScrollItem[panelObjectIdx].m_BtnID2 = 1;
				ushort num = 0;
				byte b = 0;
				byte b2 = 0;
				int num2 = 0;
				while (num2 < this.tmplistItem.Count - (dataIdx - 1) * 5 && num2 < 5)
				{
					if (this.tmplistItem.Count < (dataIdx - 1) * 5 + num2)
					{
						break;
					}
					this.Cstr_S_ItemNum[panelObjectIdx][num2].ClearString();
					switch (this.mPrizeType)
					{
					case Detail_Prize.Enotice_ActivityDegreePrize:
						num = this.SC.Notice_ActivityDegreePrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].ItemID;
						b = this.SC.Notice_ActivityDegreePrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Rank;
						b2 = this.SC.Notice_ActivityDegreePrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Num;
						break;
					case Detail_Prize.Enotice_ActivityRankPrize:
						num = this.SC.Notice_ActivityRankPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].ItemID;
						b = this.SC.Notice_ActivityRankPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Rank;
						b2 = this.SC.Notice_ActivityRankPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Num;
						break;
					case Detail_Prize.Enotice_ActivityKVKDegreePrize:
						num = this.SC.Enotice_ActivityKVKDegreePrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].ItemID;
						b = this.SC.Enotice_ActivityKVKDegreePrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Rank;
						b2 = this.SC.Enotice_ActivityKVKDegreePrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Num;
						break;
					case Detail_Prize.Enotice_ActivityKVKRankPrize:
						num = this.SC.Enotice_ActivityKVKRankPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].ItemID;
						b = this.SC.Enotice_ActivityKVKRankPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Rank;
						b2 = this.SC.Enotice_ActivityKVKRankPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Num;
						break;
					case Detail_Prize.Enotice_AMRankPrize:
						num = this.SC.Enotice_AMRankPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].ItemID;
						b = this.SC.Enotice_AMRankPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Rank;
						b2 = this.SC.Enotice_AMRankPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Num;
						break;
					case Detail_Prize.Enotice_WorldKingPrize:
						num = this.SC.Enotice_WorldKingPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].ItemID;
						b = this.SC.Enotice_WorldKingPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Rank;
						b2 = this.SC.Enotice_WorldKingPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Num;
						break;
					case Detail_Prize.Enotice_WorldNotKingPrize:
						num = this.SC.Enotice_WorldNotKingPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].ItemID;
						b = this.SC.Enotice_WorldNotKingPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Rank;
						b2 = this.SC.Enotice_WorldNotKingPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Num;
						break;
					case Detail_Prize.Enotice_FederalRankPrize:
						num = this.SC.Enotice_FederalRankPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].ItemID;
						b = this.SC.Enotice_FederalRankPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Rank;
						b2 = this.SC.Enotice_FederalRankPrize.PrizeData[(int)this.tmplistItem[(dataIdx - 1) * 5 + num2]].Num;
						break;
					}
					byte equipKind = DataManager.Instance.EquipTable.GetRecordByKey(num).EquipKind;
					bool flag = this.GUIM.IsLeadItem(equipKind);
					if (flag)
					{
						this.GUIM.ChangeLordEquipImg(this.Lebtn_Item[panelObjectIdx][num2].transform, num, b, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
					}
					else
					{
						if (this.MM.CheckCanOpenDetail(num))
						{
							this.Hbtn_Item[panelObjectIdx][num2].transform.GetComponent<UIButtonHint>().enabled = false;
						}
						else
						{
							this.Hbtn_Item[panelObjectIdx][num2].transform.GetComponent<UIButtonHint>().enabled = true;
						}
						this.GUIM.ChangeHeroItemImg(this.Hbtn_Item[panelObjectIdx][num2].transform, eHeroOrItem.Item, num, 0, b, 0);
					}
					this.Lebtn_Item[panelObjectIdx][num2].gameObject.SetActive(flag);
					this.Hbtn_Item[panelObjectIdx][num2].gameObject.SetActive(!flag);
					this.Cstr_S_ItemNum[panelObjectIdx][num2].IntToFormat((long)b2, 1, true);
					if (b2 > 1)
					{
						this.text_S_ItemNum[panelObjectIdx][num2].gameObject.SetActive(true);
					}
					else
					{
						this.text_S_ItemNum[panelObjectIdx][num2].gameObject.SetActive(false);
					}
					if (this.GUIM.IsArabic)
					{
						this.Cstr_S_ItemNum[panelObjectIdx][num2].AppendFormat("{0}x");
					}
					else
					{
						this.Cstr_S_ItemNum[panelObjectIdx][num2].AppendFormat("x{0}");
					}
					this.text_S_ItemNum[panelObjectIdx][num2].text = this.Cstr_S_ItemNum[panelObjectIdx][num2].ToString();
					this.text_S_ItemNum[panelObjectIdx][num2].SetAllDirty();
					this.text_S_ItemNum[panelObjectIdx][num2].cachedTextGenerator.Invalidate();
					this.Hbtn_Item[panelObjectIdx][num2].gameObject.SetActive(true);
					num2++;
				}
				for (int j = this.tmplistItem.Count - (dataIdx - 1) * 5; j < 5; j++)
				{
					this.Hbtn_Item[panelObjectIdx][j].gameObject.SetActive(false);
					this.text_S_ItemNum[panelObjectIdx][j].gameObject.SetActive(false);
				}
			}
			else
			{
				this.Item_P1[panelObjectIdx].gameObject.SetActive(false);
				this.Item_P2[panelObjectIdx].gameObject.SetActive(false);
				if (this.mPrizeType != Detail_Prize.Enotice_WorldKingPrize && this.mPrizeType != Detail_Prize.Enotice_WorldNotKingPrize && this.mPrizeType != Detail_Prize.Enotice_FederalRankPrize)
				{
					this.Item_P3[panelObjectIdx].gameObject.SetActive(true);
				}
			}
		}
		else if (panelObjectIdx < 7)
		{
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
				this.ScrollComp[panelObjectIdx].ItemCountText = item.transform.GetChild(5).GetComponent<UIText>();
				if (this.GUIM.IsArabic)
				{
					this.ScrollComp[panelObjectIdx].ItemCountText.AdjuestUI();
				}
				this.CountStr[panelObjectIdx] = StringManager.Instance.SpawnString(30);
				this.NameStr[panelObjectIdx] = StringManager.Instance.SpawnString(150);
				if (panelObjectIdx == 0)
				{
					this.BuyIconRT = item.transform.GetChild(1).GetComponent<RectTransform>();
				}
			}
			if (dataIdx < 0 || dataIdx > (int)this.ItemCount)
			{
				return;
			}
			ushort num3 = 1;
			uint num4 = 1u;
			byte color = 0;
			int num5 = 0;
			if (this.SC.Type == NoticeReport.Enotice_BuyTreasure || this.SC.Type == NoticeReport.Enotice_BuyBlackMarketTreasure || this.SC.Type == NoticeReport.Enotice_TreasureBackPrize)
			{
				NoticeContent.BuyTreasure buyTreasure = new NoticeContent.BuyTreasure();
				if (this.SC.Type == NoticeReport.Enotice_BuyTreasure)
				{
					buyTreasure = this.SC.Notice_BuyTreasure;
				}
				else if (this.SC.Type == NoticeReport.Enotice_BuyBlackMarketTreasure)
				{
					buyTreasure = this.SC.Enotice_BuyBlackMarketTreasure;
				}
				else if (this.SC.Type == NoticeReport.Enotice_TreasureBackPrize)
				{
					buyTreasure = this.SC.Enotice_TreasureBackPrize;
				}
				num5 = ((buyTreasure.BonusCrystal <= 0u) ? 0 : 1);
				int num6 = dataIdx - (1 + num5);
				if (this.SC.Type == NoticeReport.Enotice_BuyBlackMarketTreasure || this.SC.Type == NoticeReport.Enotice_TreasureBackPrize)
				{
					num6 = dataIdx;
				}
				if (panelObjectIdx == 0)
				{
					if (dataIdx == 0 && buyTreasure.Crystal > 0u)
					{
						this.BuyIconRT.anchoredPosition = new Vector2(258f, this.BuyIconRT.anchoredPosition.y);
						this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleCenter;
						this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
						this.ScrollComp[panelObjectIdx].ItemCountText.color = new Color(1f, 0.9333f, 0.6196f);
					}
					else
					{
						this.BuyIconRT.anchoredPosition = new Vector2(29f, this.BuyIconRT.anchoredPosition.y);
						if (this.GUIM.IsArabic)
						{
							this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleLeft;
						}
						else
						{
							this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleRight;
						}
						this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 26;
						this.ScrollComp[panelObjectIdx].ItemCountText.color = new Color(1f, 1f, 1f);
					}
				}
				if (dataIdx == 0 && buyTreasure.Crystal > 0u)
				{
					num3 = 1001;
					num4 = buyTreasure.Crystal;
					this.ScrollComp[panelObjectIdx].ItemName.text = string.Empty;
					this.ScrollComp[panelObjectIdx].CrystalImg.enabled = true;
					this.ScrollComp[panelObjectIdx].LEBtn.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].HIBtn.gameObject.SetActive(false);
				}
				else if (this.SC.Type == NoticeReport.Enotice_BuyTreasure && buyTreasure.ItemNum > 0 && buyTreasure.GiftTop == 1)
				{
					if (buyTreasure.BonusCrystal > 0u && dataIdx == 1)
					{
						num3 = 1001;
						num4 = buyTreasure.BonusCrystal;
						this.ScrollComp[panelObjectIdx].CrystalImg.enabled = true;
						this.ScrollComp[panelObjectIdx].LEBtn.gameObject.SetActive(false);
						this.ScrollComp[panelObjectIdx].HIBtn.gameObject.SetActive(false);
						this.ScrollComp[panelObjectIdx].ItemName.fontSize = 28;
						this.ScrollComp[panelObjectIdx].ItemName.color = new Color(1f, 0.9333f, 0.6196f);
						this.ScrollComp[panelObjectIdx].ItemCountText.color = new Color(1f, 1f, 1f);
					}
					else if (dataIdx <= num5 + (int)this.GiftTopCount)
					{
						if (num6 >= 0 && num6 < buyTreasure.Gift.Length)
						{
							num3 = buyTreasure.Gift[num6].ItemID;
							num4 = (uint)buyTreasure.Gift[num6].ItemNum;
						}
						color = 0;
						this.ScrollComp[panelObjectIdx].CrystalImg.enabled = false;
						this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
						this.ScrollComp[panelObjectIdx].ItemName.color = new Color(1f, 1f, 1f);
					}
					else
					{
						num6 -= (int)this.GiftTopCount;
						if (num6 >= 0 && num6 < buyTreasure.Item.Length)
						{
							num3 = buyTreasure.Item[num6].ItemID;
							num4 = (uint)buyTreasure.Item[num6].ItemNum;
							color = buyTreasure.Item[num6].ItemRank;
						}
						this.ScrollComp[panelObjectIdx].CrystalImg.enabled = false;
						this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
						this.ScrollComp[panelObjectIdx].ItemName.color = new Color(1f, 1f, 1f);
					}
				}
				else if (buyTreasure.BonusCrystal > 0u && dataIdx == 1)
				{
					num3 = 1001;
					num4 = buyTreasure.BonusCrystal;
					this.ScrollComp[panelObjectIdx].CrystalImg.enabled = true;
					this.ScrollComp[panelObjectIdx].LEBtn.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].HIBtn.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].ItemName.fontSize = 28;
					this.ScrollComp[panelObjectIdx].ItemName.color = new Color(1f, 0.9333f, 0.6196f);
					this.ScrollComp[panelObjectIdx].ItemCountText.color = new Color(1f, 1f, 1f);
				}
				else if (dataIdx <= num5 + buyTreasure.Item.Length)
				{
					if (num6 >= 0 && num6 < buyTreasure.Item.Length)
					{
						num3 = buyTreasure.Item[num6].ItemID;
						num4 = (uint)buyTreasure.Item[num6].ItemNum;
						color = buyTreasure.Item[num6].ItemRank;
					}
					this.ScrollComp[panelObjectIdx].CrystalImg.enabled = false;
					this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
					this.ScrollComp[panelObjectIdx].ItemName.color = new Color(1f, 1f, 1f);
				}
				else
				{
					num6 -= buyTreasure.Item.Length;
					if (num6 >= 0 && num6 < buyTreasure.Gift.Length)
					{
						num3 = buyTreasure.Gift[num6].ItemID;
						num4 = (uint)buyTreasure.Gift[num6].ItemNum;
					}
					color = 0;
					this.ScrollComp[panelObjectIdx].CrystalImg.enabled = false;
					this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
					this.ScrollComp[panelObjectIdx].ItemName.color = new Color(1f, 1f, 1f);
				}
			}
			else if (this.SC.Type == NoticeReport.Enotice_BackendActivity)
			{
				NoticeContent.BackendActivity backendActivity = new NoticeContent.BackendActivity();
				backendActivity = this.SC.Enotice_BackendActivity;
				if (backendActivity.Crystal > 0u)
				{
					num5 = 1;
				}
				int num7 = dataIdx - num5;
				if (panelObjectIdx == 0)
				{
					if (dataIdx == 0 && backendActivity.Crystal > 0u)
					{
						this.BuyIconRT.anchoredPosition = new Vector2(258f, this.BuyIconRT.anchoredPosition.y);
						this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleCenter;
						this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
						this.ScrollComp[panelObjectIdx].ItemCountText.color = new Color(1f, 0.9333f, 0.6196f);
					}
					else
					{
						this.BuyIconRT.anchoredPosition = new Vector2(29f, this.BuyIconRT.anchoredPosition.y);
						if (this.GUIM.IsArabic)
						{
							this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleLeft;
						}
						else
						{
							this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleRight;
						}
						this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 26;
						this.ScrollComp[panelObjectIdx].ItemCountText.color = new Color(1f, 1f, 1f);
					}
				}
				if (dataIdx == 0 && backendActivity.Crystal > 0u)
				{
					num3 = 1001;
					num4 = backendActivity.Crystal;
					this.ScrollComp[panelObjectIdx].ItemName.text = string.Empty;
					this.ScrollComp[panelObjectIdx].CrystalImg.enabled = true;
					this.ScrollComp[panelObjectIdx].LEBtn.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].HIBtn.gameObject.SetActive(false);
				}
				else if (dataIdx < num5 + backendActivity.Item.Length)
				{
					if (num7 >= 0 && num7 < backendActivity.Item.Length)
					{
						num3 = backendActivity.Item[num7].ItemID;
						num4 = (uint)backendActivity.Item[num7].ItemNum;
						color = backendActivity.Item[num7].ItemRank;
					}
					this.ScrollComp[panelObjectIdx].CrystalImg.enabled = false;
					this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
					this.ScrollComp[panelObjectIdx].ItemName.color = new Color(1f, 1f, 1f);
				}
			}
			else if (this.SC.Type == NoticeReport.Enotice_MaintainCompensation)
			{
				NoticeContent.MaintainCompensation maintainCompensation = new NoticeContent.MaintainCompensation();
				maintainCompensation = this.SC.Enotice_MaintainCompensation;
				if (maintainCompensation.Crystal > 0u)
				{
					num5 = 1;
				}
				int num8 = dataIdx - num5;
				if (panelObjectIdx == 0)
				{
					if (dataIdx == 0 && maintainCompensation.Crystal > 0u)
					{
						this.BuyIconRT.anchoredPosition = new Vector2(258f, this.BuyIconRT.anchoredPosition.y);
						this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleCenter;
						this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
						this.ScrollComp[panelObjectIdx].ItemCountText.color = new Color(1f, 0.9333f, 0.6196f);
					}
					else
					{
						this.BuyIconRT.anchoredPosition = new Vector2(29f, this.BuyIconRT.anchoredPosition.y);
						if (this.GUIM.IsArabic)
						{
							this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleLeft;
						}
						else
						{
							this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleRight;
						}
						this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 26;
						this.ScrollComp[panelObjectIdx].ItemCountText.color = new Color(1f, 1f, 1f);
					}
				}
				if (dataIdx == 0 && maintainCompensation.Crystal > 0u)
				{
					num3 = 1001;
					num4 = maintainCompensation.Crystal;
					this.ScrollComp[panelObjectIdx].ItemName.text = string.Empty;
					this.ScrollComp[panelObjectIdx].CrystalImg.enabled = true;
					this.ScrollComp[panelObjectIdx].LEBtn.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].HIBtn.gameObject.SetActive(false);
				}
				else if (dataIdx < num5 + maintainCompensation.Item.Length)
				{
					if (num8 >= 0 && num8 < maintainCompensation.Item.Length)
					{
						num3 = maintainCompensation.Item[num8].ItemID;
						num4 = (uint)maintainCompensation.Item[num8].ItemNum;
						color = maintainCompensation.Item[num8].ItemRank;
					}
					this.ScrollComp[panelObjectIdx].CrystalImg.enabled = false;
					this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
					this.ScrollComp[panelObjectIdx].ItemName.color = new Color(1f, 1f, 1f);
				}
			}
			else if (this.SC.Type == NoticeReport.Enotice_ReturnCeremony || this.SC.Type == NoticeReport.Enotice_FirstBuyTreasurePrize)
			{
				NoticeContent.ReturnCeremony returnCeremony = new NoticeContent.ReturnCeremony();
				if (this.SC.Type == NoticeReport.Enotice_ReturnCeremony)
				{
					returnCeremony = this.SC.Enotice_ReturnCeremony;
				}
				else
				{
					returnCeremony = this.SC.Enotice_FirstBuyTreasurePrize;
				}
				if (returnCeremony.Crystal > 0u)
				{
					num5 = 1;
				}
				int num9 = dataIdx - num5;
				if (panelObjectIdx == 0)
				{
					if (dataIdx == 0 && returnCeremony.Crystal > 0u)
					{
						this.BuyIconRT.anchoredPosition = new Vector2(258f, this.BuyIconRT.anchoredPosition.y);
						this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleCenter;
						this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
						this.ScrollComp[panelObjectIdx].ItemCountText.color = new Color(1f, 0.9333f, 0.6196f);
					}
					else
					{
						this.BuyIconRT.anchoredPosition = new Vector2(29f, this.BuyIconRT.anchoredPosition.y);
						if (this.GUIM.IsArabic)
						{
							this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleLeft;
						}
						else
						{
							this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleRight;
						}
						this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 26;
						this.ScrollComp[panelObjectIdx].ItemCountText.color = new Color(1f, 1f, 1f);
					}
				}
				if (dataIdx == 0 && returnCeremony.Crystal > 0u)
				{
					num3 = 1001;
					num4 = returnCeremony.Crystal;
					this.ScrollComp[panelObjectIdx].ItemName.text = string.Empty;
					this.ScrollComp[panelObjectIdx].CrystalImg.enabled = true;
					this.ScrollComp[panelObjectIdx].LEBtn.gameObject.SetActive(false);
					this.ScrollComp[panelObjectIdx].HIBtn.gameObject.SetActive(false);
				}
				else if (dataIdx < num5 + returnCeremony.Item.Length)
				{
					if (num9 >= 0 && num9 < returnCeremony.Item.Length)
					{
						num3 = returnCeremony.Item[num9].ItemID;
						num4 = (uint)returnCeremony.Item[num9].ItemNum;
						color = returnCeremony.Item[num9].ItemRank;
					}
					this.ScrollComp[panelObjectIdx].CrystalImg.enabled = false;
					this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
					this.ScrollComp[panelObjectIdx].ItemName.color = new Color(1f, 1f, 1f);
				}
			}
			if ((dataIdx > 0 && dataIdx > num5 && this.SC.Type == NoticeReport.Enotice_BuyTreasure) || this.SC.Type == NoticeReport.Enotice_BuyBlackMarketTreasure || ((this.SC.Type == NoticeReport.Enotice_BackendActivity || this.SC.Type == NoticeReport.Enotice_MaintainCompensation || this.SC.Type == NoticeReport.Enotice_ReturnCeremony || this.SC.Type == NoticeReport.Enotice_FirstBuyTreasurePrize) && dataIdx >= num5) || this.SC.Type == NoticeReport.Enotice_TreasureBackPrize)
			{
				Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(num3);
				byte equipKind2 = recordByKey.EquipKind;
				bool flag2 = this.GUIM.IsLeadItem(equipKind2);
				if (flag2)
				{
					this.GUIM.ChangeLordEquipImg(this.ScrollComp[panelObjectIdx].LEBtn.transform, num3, color, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				}
				else
				{
					if (this.MM.CheckCanOpenDetail(num3))
					{
						this.ScrollComp[panelObjectIdx].Hint.enabled = false;
					}
					else
					{
						this.ScrollComp[panelObjectIdx].Hint.enabled = true;
					}
					this.GUIM.ChangeHeroItemImg(this.ScrollComp[panelObjectIdx].HIBtn.transform, eHeroOrItem.Item, num3, 0, 0, 0);
				}
				this.ScrollComp[panelObjectIdx].LEBtn.gameObject.SetActive(flag2);
				this.ScrollComp[panelObjectIdx].HIBtn.gameObject.SetActive(!flag2);
				this.NameStr[panelObjectIdx].Length = 0;
				this.NameStr[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.EquipName));
				this.NameStr[panelObjectIdx].AppendFormat("{0}");
				this.ScrollComp[panelObjectIdx].ItemName.text = this.NameStr[panelObjectIdx].ToString();
				this.ScrollComp[panelObjectIdx].ItemName.SetAllDirty();
				this.ScrollComp[panelObjectIdx].ItemName.cachedTextGenerator.Invalidate();
			}
			if (dataIdx == 1 && num3 == 1001)
			{
				this.NameStr[panelObjectIdx].Length = 0;
				StringManager.IntToStr(this.NameStr[panelObjectIdx], (long)((ulong)num4), 1, true);
				this.ScrollComp[panelObjectIdx].ItemName.text = this.NameStr[panelObjectIdx].ToString();
				this.ScrollComp[panelObjectIdx].ItemName.SetAllDirty();
				this.ScrollComp[panelObjectIdx].ItemName.cachedTextGenerator.Invalidate();
				this.CountStr[panelObjectIdx].Length = 0;
				this.ScrollComp[panelObjectIdx].ItemCountText.text = this.DM.mStringTable.GetStringByID(876u).ToString();
				this.ScrollComp[panelObjectIdx].ItemCountText.color = new Color(0.2f, 1f, 0.404f);
				this.ScrollComp[panelObjectIdx].ItemCountText.SetAllDirty();
				this.ScrollComp[panelObjectIdx].ItemCountText.cachedTextGenerator.Invalidate();
			}
			else
			{
				this.CountStr[panelObjectIdx].Length = 0;
				StringManager.IntToStr(this.CountStr[panelObjectIdx], (long)((ulong)num4), 1, true);
				this.ScrollComp[panelObjectIdx].ItemCountText.text = this.CountStr[panelObjectIdx].ToString();
				this.ScrollComp[panelObjectIdx].ItemCountText.SetAllDirty();
				this.ScrollComp[panelObjectIdx].ItemCountText.cachedTextGenerator.Invalidate();
				this.ScrollComp[panelObjectIdx].ItemCountText.color = new Color(1f, 1f, 1f);
			}
		}
	}

	// Token: 0x06001D69 RID: 7529 RVA: 0x00364510 File Offset: 0x00362710
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001D6A RID: 7530 RVA: 0x00364514 File Offset: 0x00362714
	public void OnLEButtonClick(UILEBtn sender)
	{
	}

	// Token: 0x06001D6B RID: 7531 RVA: 0x00364518 File Offset: 0x00362718
	public void Open_NP_Mail(bool bNext)
	{
		bool flag;
		if (this.DM.bPlural)
		{
			flag = this.DM.MailReportGet(ref this.Favor, bNext, this.DM.Letter_PluralReplyID, this.DM.Letter_PluralSenderName);
		}
		else
		{
			flag = this.DM.MailReportGet(ref this.Favor, bNext);
		}
		if (!flag)
		{
			return;
		}
		switch (this.Favor.Type)
		{
		case MailType.EMAIL_SYSTEM:
			this.DM.OpenMail.Serial = this.Favor.Serial;
			this.DM.OpenMail.Type = this.Favor.Type;
			this.DM.OpenMail.Kind = this.Favor.Kind;
			this.door.CloseMenu(false);
			this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
			break;
		case MailType.EMAIL_BATTLE:
			this.DM.OpenMail.Serial = this.Favor.Serial;
			this.DM.OpenMail.Type = this.Favor.Type;
			this.DM.OpenMail.Kind = this.Favor.Kind;
			switch (this.Favor.Combat.Type)
			{
			case CombatCollectReport.CCR_BATTLE:
			case CombatCollectReport.CCR_NPCCOMBAT:
				this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 0, 0, false);
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
				break;
			case CombatCollectReport.CCR_RESOURCE:
				this.door.OpenMenu(EGUIWindow.UI_Letter_Resources, 0, 0, false);
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
				break;
			case CombatCollectReport.CCR_COLLECT:
				this.door.OpenMenu(EGUIWindow.UI_Letter_Collection, 0, 0, false);
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
				break;
			case CombatCollectReport.CCR_SCOUT:
				if (this.Favor.Combat.Scout.ScoutLevel != 0)
				{
					this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 0, 0, false);
				}
				else
				{
					this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 1, 0, false);
				}
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
				break;
			case CombatCollectReport.CCR_RECON:
				this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon, 0, 0, false);
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
				break;
			case CombatCollectReport.CCR_MONSTER:
				if (this.Favor.Combat.Monster.Result < 2 || this.Favor.Combat.Monster.Result > 3)
				{
					this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 1, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
				}
				else
				{
					this.door.CloseMenu(false);
					this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
				}
				break;
			case CombatCollectReport.CCR_NPCSCOUT:
				this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout, 0, 0, false);
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
				break;
			case CombatCollectReport.CCR_PETREPORT:
				this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS, 0, 0, false);
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
				break;
			}
			break;
		case MailType.EMAIL_LETTER:
			this.DM.OpenMail.Serial = this.Favor.Serial;
			this.DM.OpenMail.Type = this.Favor.Type;
			this.DM.OpenMail.Kind = this.Favor.Kind;
			this.door.CloseMenu(false);
			this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
			this.DM.bNoPlural = !this.DM.bPlural;
			break;
		}
	}

	// Token: 0x06001D6C RID: 7532 RVA: 0x003648E0 File Offset: 0x00362AE0
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 != 1)
			{
				if (arg1 == 2)
				{
					if (this.mLetterKind != 2)
					{
						this.DM.SystemReportDelete(this.SC.SerialID);
						this.door.CloseMenu(false);
					}
					else
					{
						this.DM.BattleReportDelete(this.CR.SerialID);
						this.door.CloseMenu(false);
					}
				}
			}
			else if (this.DM.MailReportDelete(this.MC.SerialID))
			{
				this.door.CloseMenu(false);
			}
		}
	}

	// Token: 0x06001D6D RID: 7533 RVA: 0x00364990 File Offset: 0x00362B90
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 2)
		{
			if (arg1 == 3)
			{
				this.text_Contents.text = this.MC.Content;
				this.text_Contents.SetAllDirty();
				this.text_Contents.cachedTextGeneratorForLayout.Invalidate();
				this.text_Contents.cachedTextGenerator.Invalidate();
				if (this.text_Contents.preferredHeight > 158f)
				{
					this.text_Contents.rectTransform.sizeDelta = new Vector2(this.text_Contents.rectTransform.sizeDelta.x, this.text_Contents.preferredHeight + 1f);
				}
				if (this.text_Contents.preferredHeight + 18f > 425f)
				{
					this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 18f + this.text_Contents.preferredHeight);
				}
				else
				{
					this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 425f);
				}
			}
		}
		else if (!this.DM.MailReportGet(ref this.Favor))
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001D6E RID: 7534 RVA: 0x00364AF0 File Offset: 0x00362CF0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews != NetworkNews.Refresh_Mailing)
			{
				if (networkNews != NetworkNews.Refresh_Letter)
				{
					if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
					{
						this.Refresh_FontTexture();
					}
				}
				else if (meg[1] == 1 && meg[2] == 1)
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9077u), 255, true);
					this.Img_Translate.gameObject.SetActive(false);
					this.btn_Translation.gameObject.SetActive(true);
					this.text_Translation.gameObject.SetActive(true);
				}
				else if (meg[2] == 0 && GameConstants.ConvertBytesToUInt(meg, 4) == this.Favor.Serial && meg[3] == (byte)this.Favor.Kind && this.bTrans && this.MC.Translation && this.DM.CheckLanguageTranslateByIdx((int)this.MC.LanguageSource))
				{
					this.Img_Translate.gameObject.SetActive(false);
					this.btn_Translation.gameObject.SetActive(true);
					this.text_Translation.gameObject.SetActive(true);
					if (this.MC.MailType != 2 && this.bTrans && this.GUIM.CheckNeedTranslate(this.MC.Content))
					{
						this.TranslationRT.gameObject.SetActive(true);
						this.text_Translation.gameObject.SetActive(true);
						if (this.bTransBtnStatus && this.MC.LanguageTarget == (byte)this.DM.UserLanguage)
						{
							this.Cstr_Translation.ClearString();
							this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID(this.MC.LanguageSource));
							this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054u));
							this.text_Translation.text = this.Cstr_Translation.ToString();
						}
						else
						{
							this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052u);
						}
					}
					else
					{
						this.TranslationRT.gameObject.SetActive(false);
						this.text_Translation.gameObject.SetActive(false);
						this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052u);
					}
					this.text_Translation.SetAllDirty();
					this.text_Translation.cachedTextGenerator.Invalidate();
					this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
					if (this.text_Translation.preferredWidth > this.text_Translation.rectTransform.sizeDelta.x)
					{
						this.text_Translation.rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, this.text_Translation.rectTransform.sizeDelta.y);
					}
					if (this.GUIM.IsArabic)
					{
						this.text_Translation.UpdateArabicPos();
					}
					if (this.mLetterKind == 0 && this.MC.MailType != 2)
					{
						if (this.MC.MailType == 1)
						{
							this.Cstr_Title.ClearString();
							this.Cstr_Title.StringToFormat(this.DM.mStringTable.GetStringByID(6014u));
							if (this.bTransBtnStatus && this.MC.LanguageTarget == (byte)this.DM.UserLanguage && this.GUIM.CheckNeedTranslate(this.MC.Title))
							{
								this.Cstr_Title.StringToFormat(this.MC.TitleT);
							}
							else
							{
								this.Cstr_Title.StringToFormat(this.MC.Title);
							}
							this.Cstr_Title.AppendFormat("{0}{1}");
							this.text_Title.text = this.Cstr_Title.ToString();
						}
						else if (this.MC.MailType == 3)
						{
							this.text_Title.text = this.DM.mStringTable.GetStringByID(1474u);
						}
						else if (this.bTransBtnStatus && this.MC.LanguageTarget == (byte)this.DM.UserLanguage && this.GUIM.CheckNeedTranslate(this.MC.Title))
						{
							this.text_Title.text = this.MC.TitleT;
						}
						else
						{
							this.text_Title.text = this.MC.Title;
						}
						this.text_Title.SetAllDirty();
						this.text_Title.cachedTextGenerator.Invalidate();
						if (this.bTransBtnStatus)
						{
							this.text_Contents.text = this.MC.ContentT;
						}
						else
						{
							this.text_Contents.text = this.MC.Content;
						}
						this.text_Contents.SetAllDirty();
						this.text_Contents.cachedTextGeneratorForLayout.Invalidate();
						this.text_Contents.cachedTextGenerator.Invalidate();
						if (this.text_Contents.preferredHeight > 158f)
						{
							this.text_Contents.rectTransform.sizeDelta = new Vector2(this.text_Contents.rectTransform.sizeDelta.x, this.text_Contents.preferredHeight + 1f);
							this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, -193f - (this.text_Contents.preferredHeight + 1f - 158f) - 33f);
							this.text_Translation.rectTransform.anchoredPosition = new Vector2(this.text_Translation.rectTransform.anchoredPosition.x, -179f - (this.text_Contents.preferredHeight + 1f - 158f) - 33f);
						}
						float num = 0f;
						if (this.TranslationRT.gameObject.activeSelf)
						{
							num = 84f;
						}
						if (this.text_Contents.preferredHeight + 18f + num > 425f)
						{
							this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 18f + num + this.text_Contents.preferredHeight);
						}
						else
						{
							this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 425f);
						}
					}
				}
				else if (this.Img_Translate.gameObject.activeSelf)
				{
					this.Img_Translate.gameObject.SetActive(false);
					this.btn_Translation.gameObject.SetActive(true);
					this.text_Translation.gameObject.SetActive(true);
				}
			}
			else
			{
				if (!this.DM.MailReportGet(ref this.Favor))
				{
					this.door.CloseMenu(false);
					return;
				}
				if (this.mLetterKind == 0)
				{
					if (!this.DM.bNoPlural)
					{
						if (this.MC.More > 1 && !this.DM.bPlural)
						{
							this.DM.bPlural = true;
							this.DM.OpenMail.Serial = this.Favor.Serial;
							this.DM.OpenMail.Type = this.Favor.Type;
							this.DM.OpenMail.Kind = this.Favor.Kind;
							this.door.CloseMenu(false);
							this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
							return;
						}
						if (this.MC.More <= 1 && this.DM.bPlural)
						{
							this.DM.bPlural = false;
							this.DM.OpenMail.Serial = this.Favor.Serial;
							this.DM.OpenMail.Type = this.Favor.Type;
							this.DM.OpenMail.Kind = this.Favor.Kind;
							this.door.CloseMenu(false);
							this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
							return;
						}
					}
					if (this.DM.bPlural)
					{
						this.MaxLetterNum = this.DM.GetMailboxSize(this.MC.ReplyID, this.MC.SenderName);
						this.tmpPageNum = (int)(this.MC.MoreIndex + 1);
						if (this.MaxLetterNum > 1)
						{
							if (this.MC.MoreIndex + 1 == 1)
							{
								this.btn_Previous.gameObject.SetActive(false);
							}
							else
							{
								this.btn_Previous.gameObject.SetActive(true);
							}
							if ((int)(this.MC.MoreIndex + 1) == this.MaxLetterNum)
							{
								this.btn_Next.gameObject.SetActive(false);
							}
							else
							{
								this.btn_Next.gameObject.SetActive(true);
							}
						}
						else
						{
							this.btn_Previous.gameObject.SetActive(false);
							this.btn_Next.gameObject.SetActive(false);
						}
					}
					else
					{
						this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_MAX);
						this.tmpPageNum = (int)(this.MC.Index + 1);
						if (this.MaxLetterNum > 1)
						{
							if (this.MC.Index + 1 == 1)
							{
								this.btn_Previous.gameObject.SetActive(false);
							}
							else
							{
								this.btn_Previous.gameObject.SetActive(true);
							}
							if ((int)(this.MC.Index + 1) == this.MaxLetterNum)
							{
								this.btn_Next.gameObject.SetActive(false);
							}
							else
							{
								this.btn_Next.gameObject.SetActive(true);
							}
						}
						else
						{
							this.btn_Previous.gameObject.SetActive(false);
							this.btn_Next.gameObject.SetActive(false);
						}
					}
				}
				else if (this.mLetterKind == 1)
				{
					if ((this.SC.Type >= NoticeReport.Enotice_NewbieOver && this.SC.Type <= NoticeReport.Enotice_SHLevel5) || this.SC.Type == NoticeReport.Enotice_FirstUnderPetAttack)
					{
						this.text_Name.text = this.DM.mStringTable.GetStringByID(3717u);
					}
					else
					{
						this.text_Name.text = this.DM.mStringTable.GetStringByID(6079u);
					}
					this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_MAX);
					this.tmpPageNum = (int)(this.SC.Index + 1);
					if (this.MaxLetterNum > 1)
					{
						if (this.SC.Index + 1 == 1)
						{
							this.btn_Previous.gameObject.SetActive(false);
						}
						else
						{
							this.btn_Previous.gameObject.SetActive(true);
						}
						if ((int)(this.SC.Index + 1) == this.MaxLetterNum)
						{
							this.btn_Next.gameObject.SetActive(false);
						}
						else
						{
							this.btn_Next.gameObject.SetActive(true);
						}
					}
					else
					{
						this.btn_Previous.gameObject.SetActive(false);
						this.btn_Next.gameObject.SetActive(false);
					}
				}
				else if (this.mLetterKind == 2)
				{
					this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_MAX);
					this.tmpPageNum = (int)(this.CR.Index + 1);
					if (this.MaxLetterNum > 1)
					{
						if (this.CR.Index + 1 == 1)
						{
							this.btn_Previous.gameObject.SetActive(false);
						}
						else
						{
							this.btn_Previous.gameObject.SetActive(true);
						}
						if ((int)(this.CR.Index + 1) == this.MaxLetterNum)
						{
							this.btn_Next.gameObject.SetActive(false);
						}
						else
						{
							this.btn_Next.gameObject.SetActive(true);
						}
					}
					else
					{
						this.btn_Previous.gameObject.SetActive(false);
						this.btn_Next.gameObject.SetActive(false);
					}
				}
				this.Cstr_Page.ClearString();
				this.Cstr_Page.IntToFormat((long)this.tmpPageNum, 1, false);
				this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
				if (this.GUIM.IsArabic)
				{
					this.Cstr_Page.AppendFormat("{1}/{0}");
				}
				else
				{
					this.Cstr_Page.AppendFormat("{0}/{1}");
				}
				this.text_Page.text = this.Cstr_Page.ToString();
				this.text_Page.SetAllDirty();
				this.text_Page.cachedTextGenerator.Invalidate();
			}
			break;
		}
	}

	// Token: 0x06001D6F RID: 7535 RVA: 0x00365868 File Offset: 0x00363A68
	public void Refresh_FontTexture()
	{
		if (this.text_Page != null && this.text_Page.enabled)
		{
			this.text_Page.enabled = false;
			this.text_Page.enabled = true;
		}
		if (this.text_Name != null && this.text_Name.enabled)
		{
			this.text_Name.enabled = false;
			this.text_Name.enabled = true;
		}
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_Contents != null && this.text_Contents.enabled)
		{
			this.text_Contents.enabled = false;
			this.text_Contents.enabled = true;
		}
		if (this.text_Contents_S != null && this.text_Contents_S.enabled)
		{
			this.text_Contents_S.enabled = false;
			this.text_Contents_S.enabled = true;
		}
		if (this.text_S_Title != null && this.text_S_Title.enabled)
		{
			this.text_S_Title.enabled = false;
			this.text_S_Title.enabled = true;
		}
		if (this.text_LordEquip_Lv != null && this.text_LordEquip_Lv.enabled)
		{
			this.text_LordEquip_Lv.enabled = false;
			this.text_LordEquip_Lv.enabled = true;
		}
		if (this.text_CryptFinish != null && this.text_CryptFinish.enabled)
		{
			this.text_CryptFinish.enabled = false;
			this.text_CryptFinish.enabled = true;
		}
		if (this.text_MonsterXY != null && this.text_MonsterXY.enabled)
		{
			this.text_MonsterXY.enabled = false;
			this.text_MonsterXY.enabled = true;
		}
		if (this.text_Translation != null && this.text_Translation.enabled)
		{
			this.text_Translation.enabled = false;
			this.text_Translation.enabled = true;
		}
		if (this.GiftsHbtn_Item != null && this.GiftsHbtn_Item.enabled)
		{
			this.GiftsHbtn_Item.Refresh_FontTexture();
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_Time[i] != null && this.text_Time[i].enabled)
			{
				this.text_Time[i].enabled = false;
				this.text_Time[i].enabled = true;
			}
			if (this.text_Skill_1[i] != null && this.text_Skill_1[i].enabled)
			{
				this.text_Skill_1[i].enabled = false;
				this.text_Skill_1[i].enabled = true;
			}
			if (this.text_Skill_2[i] != null && this.text_Skill_2[i].enabled)
			{
				this.text_Skill_2[i].enabled = false;
				this.text_Skill_2[i].enabled = true;
			}
			if (this.text_LordEquip[i] != null && this.text_LordEquip[i].enabled)
			{
				this.text_LordEquip[i].enabled = false;
				this.text_LordEquip[i].enabled = true;
			}
			if (this.text_Gifts[i] != null && this.text_Gifts[i].enabled)
			{
				this.text_Gifts[i].enabled = false;
				this.text_Gifts[i].enabled = true;
			}
		}
		for (int j = 0; j < 3; j++)
		{
			if (this.text_S_Top[j] != null && this.text_S_Top[j].enabled)
			{
				this.text_S_Top[j].enabled = false;
				this.text_S_Top[j].enabled = true;
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (this.text_StarUp_1[k] != null && this.text_StarUp_1[k].enabled)
			{
				this.text_StarUp_1[k].enabled = false;
				this.text_StarUp_1[k].enabled = true;
			}
			if (this.text_StarUp_2[k] != null && this.text_StarUp_2[k].enabled)
			{
				this.text_StarUp_2[k].enabled = false;
				this.text_StarUp_2[k].enabled = true;
			}
		}
		for (int l = 0; l < 7; l++)
		{
			if (this.text_tmpStr[l] != null && this.text_tmpStr[l].enabled)
			{
				this.text_tmpStr[l].enabled = false;
				this.text_tmpStr[l].enabled = true;
			}
		}
		for (int m = 0; m < 6; m++)
		{
			for (int n = 0; n < 2; n++)
			{
				if (this.text_LordEquip_Effect[m][n] != null && this.text_LordEquip_Effect[m][n].enabled)
				{
					this.text_LordEquip_Effect[m][n].enabled = false;
					this.text_LordEquip_Effect[m][n].enabled = true;
				}
			}
			for (int num = 0; num < 5; num++)
			{
				if (this.text_S_ItemNum[m][num] != null && this.text_S_ItemNum[m][num].enabled)
				{
					this.text_S_ItemNum[m][num].enabled = false;
					this.text_S_ItemNum[m][num].enabled = true;
				}
				if (this.Hbtn_Item[m][num] != null && this.Hbtn_Item[m][num].enabled)
				{
					this.Hbtn_Item[m][num].Refresh_FontTexture();
				}
			}
		}
		for (int num2 = 0; num2 < 10; num2++)
		{
			if (this.text_BookMarkList[num2] != null && this.text_BookMarkList[num2].enabled)
			{
				this.text_BookMarkList[num2].enabled = false;
				this.text_BookMarkList[num2].enabled = true;
			}
			if (this.text_BookMarkList2[num2] != null && this.text_BookMarkList2[num2].enabled)
			{
				this.text_BookMarkList2[num2].enabled = false;
				this.text_BookMarkList2[num2].enabled = true;
			}
		}
	}

	// Token: 0x06001D70 RID: 7536 RVA: 0x00365F30 File Offset: 0x00364130
	private void Start()
	{
	}

	// Token: 0x06001D71 RID: 7537 RVA: 0x00365F34 File Offset: 0x00364134
	private void Update()
	{
		this.TmpTime += Time.smoothDeltaTime * 40f;
		if (this.TmpTime >= 40f)
		{
			this.TmpTime = 0f;
		}
		float num = (this.TmpTime <= 20f) ? this.TmpTime : (40f - this.TmpTime);
		if (num < 0f)
		{
			num = 0f;
		}
		if (this.NextT != null)
		{
			this.Vec3Instance.Set(this.MoveTime1 - num, this.NextT.localPosition.y, this.NextT.localPosition.z);
			this.NextT.localPosition = this.Vec3Instance;
		}
		if (this.PreviousT != null)
		{
			this.Vec3Instance.Set(this.MoveTime2 + num, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
			this.PreviousT.localPosition = this.Vec3Instance;
		}
	}

	// Token: 0x06001D72 RID: 7538 RVA: 0x00366064 File Offset: 0x00364264
	private void UpdateBaseline()
	{
		if (this.rectBaseLineBtn != null && this.rectBaseLine != null && this.text_Name != null)
		{
			Vector2 sizeDelta = this.rectBaseLineBtn.sizeDelta;
			sizeDelta.x = this.text_Name.preferredWidth;
			this.rectBaseLineBtn.sizeDelta = sizeDelta;
			sizeDelta = this.rectBaseLine.sizeDelta;
			sizeDelta.x = this.text_Name.preferredWidth;
			this.rectBaseLine.sizeDelta = sizeDelta;
			if (this.MC != null && (this.MC.MailType == 0 || this.MC.MailType == 1 || this.MC.MailType == 3 || this.MC.MailType == 4))
			{
				if (this.baseline && !this.baseline.gameObject.activeSelf)
				{
					this.baseline.gameObject.SetActive(true);
				}
			}
			else if (this.baseline && this.baseline.gameObject.activeSelf)
			{
				this.baseline.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x04005A08 RID: 23048
	private Transform GameT;

	// Token: 0x04005A09 RID: 23049
	private Transform Tmp;

	// Token: 0x04005A0A RID: 23050
	private Transform Tmp1;

	// Token: 0x04005A0B RID: 23051
	private Transform PreviousT;

	// Token: 0x04005A0C RID: 23052
	private Transform NextT;

	// Token: 0x04005A0D RID: 23053
	private Transform Mask_T;

	// Token: 0x04005A0E RID: 23054
	private Transform Mask_T2;

	// Token: 0x04005A0F RID: 23055
	private Transform Letter_T;

	// Token: 0x04005A10 RID: 23056
	private Transform Letter_S_T;

	// Token: 0x04005A11 RID: 23057
	private Transform BookMarkT;

	// Token: 0x04005A12 RID: 23058
	private Transform[] BookMarkList = new Transform[10];

	// Token: 0x04005A13 RID: 23059
	private Transform[] ItemT = new Transform[6];

	// Token: 0x04005A14 RID: 23060
	private Transform[] Item_P1 = new Transform[6];

	// Token: 0x04005A15 RID: 23061
	private Transform[] Item_P2 = new Transform[6];

	// Token: 0x04005A16 RID: 23062
	private Transform[] Item_P3 = new Transform[6];

	// Token: 0x04005A17 RID: 23063
	private Transform MonsterXY_T;

	// Token: 0x04005A18 RID: 23064
	private Transform HeroStarUp_T;

	// Token: 0x04005A19 RID: 23065
	private Transform Gifts_T;

	// Token: 0x04005A1A RID: 23066
	private Transform baseline;

	// Token: 0x04005A1B RID: 23067
	private RectTransform rectBaseLineBtn;

	// Token: 0x04005A1C RID: 23068
	private RectTransform rectBaseLine;

	// Token: 0x04005A1D RID: 23069
	private CScrollRect Mask_S_SR;

	// Token: 0x04005A1E RID: 23070
	private RectTransform[] BookMark_TextRT = new RectTransform[10];

	// Token: 0x04005A1F RID: 23071
	private RectTransform[] BookMark_XYRT = new RectTransform[10];

	// Token: 0x04005A20 RID: 23072
	private RectTransform ContentRT;

	// Token: 0x04005A21 RID: 23073
	private RectTransform BuyIconRT;

	// Token: 0x04005A22 RID: 23074
	private RectTransform DeleteRT;

	// Token: 0x04005A23 RID: 23075
	private RectTransform CollectRT;

	// Token: 0x04005A24 RID: 23076
	private RectTransform ReplyRT;

	// Token: 0x04005A25 RID: 23077
	private RectTransform Content_RT2;

	// Token: 0x04005A26 RID: 23078
	private RectTransform TranslationRT;

	// Token: 0x04005A27 RID: 23079
	private RectTransform tmpRC;

	// Token: 0x04005A28 RID: 23080
	private UIButton btn_EXIT;

	// Token: 0x04005A29 RID: 23081
	private UIButton btn_Previous;

	// Token: 0x04005A2A RID: 23082
	private UIButton btn_Next;

	// Token: 0x04005A2B RID: 23083
	private UIButton btn_Delete;

	// Token: 0x04005A2C RID: 23084
	private UIButton btn_Collect;

	// Token: 0x04005A2D RID: 23085
	private UIButton btn_Reply;

	// Token: 0x04005A2E RID: 23086
	private UIButton btn_Delete_S;

	// Token: 0x04005A2F RID: 23087
	private UIButton btn_Collect_S;

	// Token: 0x04005A30 RID: 23088
	private UIButton btn_AllianceInvite_S;

	// Token: 0x04005A31 RID: 23089
	private UIButton[] btn_BookMarkList = new UIButton[10];

	// Token: 0x04005A32 RID: 23090
	private UIButton[] btn_BookMarkListXY = new UIButton[10];

	// Token: 0x04005A33 RID: 23091
	private UIButton btn_MonsterXY;

	// Token: 0x04005A34 RID: 23092
	private UIButton btn_Translation;

	// Token: 0x04005A35 RID: 23093
	private UIButton btn_Name;

	// Token: 0x04005A36 RID: 23094
	private UIButton btn_JoinAlliance;

	// Token: 0x04005A37 RID: 23095
	private UIHIBtn[][] Hbtn_Item = new UIHIBtn[6][];

	// Token: 0x04005A38 RID: 23096
	private UIHIBtn GiftsHbtn_Item;

	// Token: 0x04005A39 RID: 23097
	private UILEBtn mLebtn;

	// Token: 0x04005A3A RID: 23098
	private UILEBtn[][] Lebtn_Item = new UILEBtn[6][];

	// Token: 0x04005A3B RID: 23099
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04005A3C RID: 23100
	private ScrollPanelItem[] mScrollItem = new ScrollPanelItem[6];

	// Token: 0x04005A3D RID: 23101
	private ScrollPanel m_ScrollPanel_Buy;

	// Token: 0x04005A3E RID: 23102
	private Image Img_TitleIcon;

	// Token: 0x04005A3F RID: 23103
	private Image Img_Hero;

	// Token: 0x04005A40 RID: 23104
	private Image Img_HeroF;

	// Token: 0x04005A41 RID: 23105
	private Image Img_Hero_S;

	// Token: 0x04005A42 RID: 23106
	private Image Img_HeroF_S;

	// Token: 0x04005A43 RID: 23107
	private Image Img_S_Activity_BG;

	// Token: 0x04005A44 RID: 23108
	private Image Img_S_Title;

	// Token: 0x04005A45 RID: 23109
	private Image Img_S_Crystal;

	// Token: 0x04005A46 RID: 23110
	private Image[] Img_HeroSkill = new Image[2];

	// Token: 0x04005A47 RID: 23111
	private Image[] Img_HeroSkill_1 = new Image[2];

	// Token: 0x04005A48 RID: 23112
	private Image[] Img_HeroSkill_2 = new Image[2];

	// Token: 0x04005A49 RID: 23113
	private Image[] Img_StarUpSkill = new Image[4];

	// Token: 0x04005A4A RID: 23114
	private Image[] Img_StarUpSkill_2 = new Image[4];

	// Token: 0x04005A4B RID: 23115
	private Image[] Img_StarUpSkill_L = new Image[4];

	// Token: 0x04005A4C RID: 23116
	private Image[] Img_BookMarkList = new Image[10];

	// Token: 0x04005A4D RID: 23117
	private Image Img_LordEquip_BG;

	// Token: 0x04005A4E RID: 23118
	private Image Img_CryptFinish_BG;

	// Token: 0x04005A4F RID: 23119
	private Image Img_BuyTreasure_BG;

	// Token: 0x04005A50 RID: 23120
	private Image Img_Translate;

	// Token: 0x04005A51 RID: 23121
	private Image tmpImg;

	// Token: 0x04005A52 RID: 23122
	private Image Img_BG;

	// Token: 0x04005A53 RID: 23123
	private Image Img_Title;

	// Token: 0x04005A54 RID: 23124
	private Image Img_Icon;

	// Token: 0x04005A55 RID: 23125
	private UIText text_Page;

	// Token: 0x04005A56 RID: 23126
	private UIText text_Name;

	// Token: 0x04005A57 RID: 23127
	private UIText text_Title;

	// Token: 0x04005A58 RID: 23128
	private UIText text_Contents;

	// Token: 0x04005A59 RID: 23129
	private UIText text_Contents_S;

	// Token: 0x04005A5A RID: 23130
	private UIText[] text_Time = new UIText[2];

	// Token: 0x04005A5B RID: 23131
	private UIText[] text_Skill_1 = new UIText[2];

	// Token: 0x04005A5C RID: 23132
	private UIText[] text_Skill_2 = new UIText[2];

	// Token: 0x04005A5D RID: 23133
	private UIText[] text_BookMarkList = new UIText[10];

	// Token: 0x04005A5E RID: 23134
	private UIText[] text_BookMarkList2 = new UIText[10];

	// Token: 0x04005A5F RID: 23135
	private UIText text_S_Title;

	// Token: 0x04005A60 RID: 23136
	private UIText[] text_S_Top = new UIText[3];

	// Token: 0x04005A61 RID: 23137
	private UIText[][] text_S_ItemNum = new UIText[6][];

	// Token: 0x04005A62 RID: 23138
	private UIText text_LordEquip_Lv;

	// Token: 0x04005A63 RID: 23139
	private UIText[] text_LordEquip = new UIText[2];

	// Token: 0x04005A64 RID: 23140
	private UIText[][] text_LordEquip_Effect = new UIText[6][];

	// Token: 0x04005A65 RID: 23141
	private UIText text_CryptFinish;

	// Token: 0x04005A66 RID: 23142
	private UIText text_MonsterXY;

	// Token: 0x04005A67 RID: 23143
	private UIText[] text_StarUp_1 = new UIText[4];

	// Token: 0x04005A68 RID: 23144
	private UIText[] text_StarUp_2 = new UIText[4];

	// Token: 0x04005A69 RID: 23145
	private UIText[] text_tmpStr = new UIText[7];

	// Token: 0x04005A6A RID: 23146
	private UIText text_Translation;

	// Token: 0x04005A6B RID: 23147
	private UIText tmptext;

	// Token: 0x04005A6C RID: 23148
	private UIText[] text_Gifts = new UIText[2];

	// Token: 0x04005A6D RID: 23149
	private CString Cstr_Name;

	// Token: 0x04005A6E RID: 23150
	private CString Cstr_Page;

	// Token: 0x04005A6F RID: 23151
	private CString Cstr_Skill;

	// Token: 0x04005A70 RID: 23152
	private CString Cstr_Title;

	// Token: 0x04005A71 RID: 23153
	private CString Cstr_Contents_S;

	// Token: 0x04005A72 RID: 23154
	private CString[] Cstr_SkillIcon = new CString[2];

	// Token: 0x04005A73 RID: 23155
	private CString[] Cstr_Time = new CString[2];

	// Token: 0x04005A74 RID: 23156
	private CString Cstr_S_Title;

	// Token: 0x04005A75 RID: 23157
	private CString[] Cstr_S_Top = new CString[3];

	// Token: 0x04005A76 RID: 23158
	private CString[][] Cstr_S_ItemNum = new CString[6][];

	// Token: 0x04005A77 RID: 23159
	private CString[] Cstr_BookMarkList2 = new CString[10];

	// Token: 0x04005A78 RID: 23160
	private CString Cstr_LordEquip_Lv;

	// Token: 0x04005A79 RID: 23161
	private CString[] Cstr_LordEquip = new CString[2];

	// Token: 0x04005A7A RID: 23162
	private CString[][] Cstr_LordEquip_Effect = new CString[6][];

	// Token: 0x04005A7B RID: 23163
	private CString[] Cstr_StarUpValue = new CString[4];

	// Token: 0x04005A7C RID: 23164
	private CString Cstr_Translation;

	// Token: 0x04005A7D RID: 23165
	private CString[] Cstr_Gifts = new CString[2];

	// Token: 0x04005A7E RID: 23166
	private DataManager DM;

	// Token: 0x04005A7F RID: 23167
	private GUIManager GUIM;

	// Token: 0x04005A80 RID: 23168
	private UISpritesArray SArray;

	// Token: 0x04005A81 RID: 23169
	private Font TTFont;

	// Token: 0x04005A82 RID: 23170
	private Door door;

	// Token: 0x04005A83 RID: 23171
	private Material m_Mat;

	// Token: 0x04005A84 RID: 23172
	private MallManager MM;

	// Token: 0x04005A85 RID: 23173
	private MailContent MC;

	// Token: 0x04005A86 RID: 23174
	private NoticeContent SC;

	// Token: 0x04005A87 RID: 23175
	private CombatReport CR;

	// Token: 0x04005A88 RID: 23176
	private int mStatus;

	// Token: 0x04005A89 RID: 23177
	private int MaxLetterNum;

	// Token: 0x04005A8A RID: 23178
	private float tmpHeight;

	// Token: 0x04005A8B RID: 23179
	private float tempL;

	// Token: 0x04005A8C RID: 23180
	private float MoveTime1;

	// Token: 0x04005A8D RID: 23181
	private float MoveTime2;

	// Token: 0x04005A8E RID: 23182
	private float TmpTime;

	// Token: 0x04005A8F RID: 23183
	private Vector3 Vec3Instance;

	// Token: 0x04005A90 RID: 23184
	private MyFavorite Favor = new MyFavorite(MailType.EMAIL_MAX, 0u);

	// Token: 0x04005A91 RID: 23185
	public byte[] LegionRankMagnifation = new byte[]
	{
		1,
		2,
		4,
		8,
		20
	};

	// Token: 0x04005A92 RID: 23186
	public byte[] LordExp = new byte[]
	{
		0,
		10,
		15,
		30,
		60,
		150
	};

	// Token: 0x04005A93 RID: 23187
	private int mLetterKind;

	// Token: 0x04005A94 RID: 23188
	private int tmpPageNum;

	// Token: 0x04005A95 RID: 23189
	private Hero tmpHero;

	// Token: 0x04005A96 RID: 23190
	private Skill mSkill;

	// Token: 0x04005A97 RID: 23191
	private ushort[] mHeroSkill = new ushort[4];

	// Token: 0x04005A98 RID: 23192
	private string[] Str_HeroColor = new string[4];

	// Token: 0x04005A99 RID: 23193
	private List<float> tmplist = new List<float>();

	// Token: 0x04005A9A RID: 23194
	private List<ushort> tmplistItem = new List<ushort>();

	// Token: 0x04005A9B RID: 23195
	private uint mDiamond;

	// Token: 0x04005A9C RID: 23196
	private uint mValue;

	// Token: 0x04005A9D RID: 23197
	private byte mNoValueCount;

	// Token: 0x04005A9E RID: 23198
	private bool bAddList = true;

	// Token: 0x04005A9F RID: 23199
	private ushort ShopID;

	// Token: 0x04005AA0 RID: 23200
	private Equip tmpEQ;

	// Token: 0x04005AA1 RID: 23201
	private List<LordEquipEffectSet> effectList = new List<LordEquipEffectSet>();

	// Token: 0x04005AA2 RID: 23202
	private Vector2 tmpV;

	// Token: 0x04005AA3 RID: 23203
	private bool[] bFindScrollComp = new bool[7];

	// Token: 0x04005AA4 RID: 23204
	private UnitComp_MallDetail[] ScrollComp = new UnitComp_MallDetail[7];

	// Token: 0x04005AA5 RID: 23205
	private CString[] CountStr = new CString[7];

	// Token: 0x04005AA6 RID: 23206
	private CString[] NameStr = new CString[7];

	// Token: 0x04005AA7 RID: 23207
	private byte ItemCount;

	// Token: 0x04005AA8 RID: 23208
	private bool bTrans;

	// Token: 0x04005AA9 RID: 23209
	private bool bTransBtnStatus = true;

	// Token: 0x04005AAA RID: 23210
	private byte GiftTopCount;

	// Token: 0x04005AAB RID: 23211
	private Detail_Prize mPrizeType;
}
