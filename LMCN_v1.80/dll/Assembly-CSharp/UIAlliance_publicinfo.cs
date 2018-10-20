using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000317 RID: 791
public class UIAlliance_publicinfo : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06001024 RID: 4132 RVA: 0x001C91F0 File Offset: 0x001C73F0
	public override void OnOpen(int arg1, int arg2)
	{
		this.mType = arg1;
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		if (this.DM.RoleAlliance.Id == 0u && this.mType != 5)
		{
			this.door.CloseMenu(false);
			return;
		}
		this.Cstr_Alliance_K = StringManager.Instance.SpawnString(30);
		this.Cstr_AllianceName = StringManager.Instance.SpawnString(30);
		this.Cstr_AllianceChief = StringManager.Instance.SpawnString(30);
		this.Cstr_AllianceStrength = StringManager.Instance.SpawnString(30);
		this.Cstr_AllianceMember = StringManager.Instance.SpawnString(30);
		this.Cstr_GifeLV = StringManager.Instance.SpawnString(30);
		this.Cstr_AllianceLanguage = StringManager.Instance.SpawnString(30);
		this.Cstr_Null = StringManager.Instance.SpawnString(30);
		this.Cstr_Translation = StringManager.Instance.SpawnString(50);
		this.tmpImg = this.GameT.GetChild(0).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
		this.tmpImg.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(0).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.door.LoadMaterial();
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.Tmp = this.GameT.GetChild(1);
		this.img_AMRank_BG = this.Tmp.GetComponent<Image>();
		this.Tmp1 = this.Tmp.GetChild(0);
		this.img_AMRankNew_BG = this.Tmp1.GetComponent<Image>();
		this.img_AMRankNew_BG2 = this.Tmp1.GetChild(2).GetComponent<Image>();
		this.img_AMRank_LF = this.Tmp1.GetChild(3).GetComponent<Image>();
		this.ImgSA_LF = this.Tmp1.GetChild(3).GetComponent<UISpritesArray>();
		this.img_AMRank_RF = this.Tmp1.GetChild(4).GetComponent<Image>();
		this.ImgSA_RF = this.Tmp1.GetChild(4).GetComponent<UISpritesArray>();
		this.img_AMRank1_F = this.Tmp1.GetChild(5).GetComponent<Image>();
		this.img_AMRank_Title = this.Tmp1.GetChild(6).GetComponent<Image>();
		this.text_Title_AMP = this.Tmp1.GetChild(6).GetChild(0).GetComponent<UIText>();
		this.text_Title_AMP.font = this.TTFont;
		this.text_Title_AMP.text = this.DM.mStringTable.GetStringByID(4641u);
		this.Tmp1 = this.Tmp.GetChild(1);
		this.img_AMRank_TopBG = this.Tmp1.GetComponent<Image>();
		this.Tmp1 = this.Tmp.GetChild(2);
		this.img_AMRank_TopBG2 = this.Tmp1.GetComponent<Image>();
		this.Tmp1 = this.Tmp.GetChild(3);
		this.img_Title = this.Tmp1.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_tmpStr[0] = this.Tmp2.GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(4641u);
		this.Tmp1 = this.Tmp.GetChild(4);
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_AllianceChief = this.Tmp2.GetComponent<UIText>();
		this.text_AllianceChief.font = this.TTFont;
		this.Cstr_AllianceChief.ClearString();
		this.Cstr_AllianceChief.StringToFormat(this.DM.AllianceView.Leader);
		this.Cstr_AllianceChief.AppendFormat(this.DM.mStringTable.GetStringByID(4625u));
		this.text_AllianceChief.text = this.Cstr_AllianceChief.ToString();
		this.text_AllianceChief.gameObject.SetActive(false);
		this.Tmp1 = this.Tmp.GetChild(5);
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_AllianceStrength = this.Tmp2.GetComponent<UIText>();
		this.text_AllianceStrength.font = this.TTFont;
		this.Cstr_AllianceStrength.ClearString();
		this.Cstr_AllianceStrength.uLongToFormat(this.DM.AllianceView.Power, 1, true);
		this.Cstr_AllianceStrength.AppendFormat(this.DM.mStringTable.GetStringByID(4626u));
		this.text_AllianceStrength.text = this.Cstr_AllianceStrength.ToString();
		this.text_AllianceStrength.gameObject.SetActive(false);
		this.Tmp1 = this.Tmp.GetChild(6);
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_AllianceMember = this.Tmp2.GetComponent<UIText>();
		this.text_AllianceMember.font = this.TTFont;
		this.Cstr_AllianceMember.ClearString();
		this.Cstr_AllianceMember.IntToFormat((long)this.DM.AllianceView.Member, 1, false);
		this.Cstr_AllianceMember.AppendFormat(this.DM.mStringTable.GetStringByID(4627u));
		this.text_AllianceMember.text = this.Cstr_AllianceMember.ToString();
		this.text_AllianceMember.gameObject.SetActive(false);
		this.Tmp1 = this.Tmp.GetChild(7);
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_AllianceLanguage = this.Tmp2.GetComponent<UIText>();
		this.text_AllianceLanguage.font = this.TTFont;
		this.Cstr_AllianceLanguage.ClearString();
		this.Cstr_AllianceLanguage.StringToFormat(this.DM.GetLanguageStr(this.DM.AllianceView.Language));
		this.Cstr_AllianceLanguage.AppendFormat(this.DM.mStringTable.GetStringByID(4642u));
		this.text_AllianceLanguage.text = this.Cstr_AllianceLanguage.ToString();
		this.text_AllianceLanguage.gameObject.SetActive(false);
		this.Tmp1 = this.Tmp.GetChild(8);
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_Propaganda[0] = this.Tmp2.GetComponent<UIText>();
		this.text_Propaganda[0].font = this.TTFont;
		RectTransform component = this.Tmp2.GetComponent<RectTransform>();
		this.tmpString.Length = 0;
		this.tmpString.Append(this.DM.AllianceView.Header);
		this.text_Propaganda[0].text = this.tmpString.ToString();
		this.text_Propaganda[0].gameObject.SetActive(false);
		this.Tmp2 = this.Tmp1.GetChild(1);
		this.text_Propaganda[1] = this.Tmp2.GetComponent<UIText>();
		this.text_Propaganda[1].font = this.TTFont;
		this.text_Propaganda[1].text = this.tmpString.ToString();
		this.text_Propaganda[1].gameObject.SetActive(false);
		RectTransform component2 = this.Tmp2.GetComponent<RectTransform>();
		this.img_text = this.Tmp1.GetComponent<UIRunningText>();
		if (this.GUIM.IsArabic)
		{
			this.img_text.tmpLength = 562f;
		}
		else
		{
			this.img_text.tmpLength = 281f;
		}
		this.img_text.m_RunningText1 = this.text_Propaganda[0];
		this.img_text.m_RunRT1 = this.text_Propaganda[0].rectTransform;
		this.img_text.m_RunningText2 = this.text_Propaganda[1];
		this.img_text.m_RunRT2 = this.text_Propaganda[1].rectTransform;
		if (this.text_Propaganda[0].preferredWidth > 281f)
		{
			component.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth, component.sizeDelta.y);
			if (this.GUIM.IsArabic)
			{
				this.text_Propaganda[0].UpdateArabicPos();
			}
			component2.anchoredPosition = new Vector2(this.text_Propaganda[0].preferredWidth, component2.anchoredPosition.y);
			component2.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth, component2.sizeDelta.y);
			if (this.GUIM.IsArabic)
			{
				this.text_Propaganda[1].UpdateArabicPos();
			}
			this.img_text.tmpLength = this.text_Propaganda[0].preferredWidth;
		}
		if (this.DM.AllianceView.Id != this.DM.RoleAlliance.Id)
		{
			if (this.DM.AllianceView.Header == null || this.DM.AllianceView.Header.Length == 0)
			{
				this.img_text.gameObject.SetActive(false);
			}
			else
			{
				this.img_text.gameObject.SetActive(true);
			}
		}
		else if (this.DM.RoleAlliance.Header == null || this.DM.RoleAlliance.Header.Length == 0)
		{
			this.img_text.gameObject.SetActive(false);
		}
		else
		{
			this.img_text.gameObject.SetActive(true);
		}
		this.BadgeT = this.Tmp.GetChild(10);
		this.Tmp1 = this.Tmp.GetChild(11);
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_Gife = this.Tmp2.GetComponent<UIText>();
		this.text_Gife.font = this.TTFont;
		this.Cstr_GifeLV.ClearString();
		this.Cstr_GifeLV.IntToFormat((long)this.DM.AllianceView.GiftLv, 1, false);
		this.Cstr_GifeLV.AppendFormat(this.DM.mStringTable.GetStringByID(4631u));
		this.text_Gife.text = this.Cstr_GifeLV.ToString();
		this.text_Gife.gameObject.SetActive(false);
		this.Tmp1 = this.Tmp.GetChild(12);
		this.Img_Join = this.Tmp1.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_join = this.Tmp2.GetComponent<UIText>();
		this.text_join.font = this.TTFont;
		this.text_join.gameObject.SetActive(false);
		this.Tmp1 = this.Tmp.GetChild(13);
		this.img_AMRank_InputBG = this.Tmp1.GetChild(0).GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(1);
		this.mInput = this.Tmp2.GetComponent<UIEmojiInput>();
		this.mInput.textComponent.font = this.TTFont;
		this.text_Input1 = (this.mInput.placeholder as UIText);
		this.text_Input1.font = this.TTFont;
		this.mInput.onEndEdit.AddListener(delegate(string id)
		{
			this.ChangText(id);
		});
		this.mInput.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
		this.mInput.textComponent.gameObject.AddComponent<UITextBoundCheck>();
		if (this.DM.AllianceView.Notice != null && this.DM.AllianceView.Notice.Length != 0 && this.DM.AllianceView.Id == this.DM.RoleAlliance.Id)
		{
			this.mInput.text = this.DM.AllianceView.Notice;
		}
		if (this.DM.AllianceView.Id == this.DM.RoleAlliance.Id && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
		{
			this.text_Input1.text = this.DM.mStringTable.GetStringByID(773u);
		}
		this.text_Trans = this.Tmp.GetChild(13).GetChild(2).GetComponent<UIText>();
		this.text_Trans.font = this.TTFont;
		this.text_Trans.text = this.mInput.text;
		this.text_Trans.SetCheckArabic(true);
		this.text_Trans.gameObject.AddComponent<UITextBoundCheck>();
		this.btn_InputField = this.Tmp.GetChild(14).GetComponent<UIButton>();
		this.btn_InputField.m_Handler = this;
		this.btn_InputField.m_BtnID1 = 6;
		this.btn_InputField2 = this.Tmp.GetChild(15).GetComponent<UIButton>();
		this.btn_InputField2.m_Handler = this;
		this.btn_InputField2.m_BtnID1 = 6;
		if (this.DM.AllianceView.Id != this.DM.RoleAlliance.Id || this.DM.RoleAlliance.Rank < AllianceRank.RANK4)
		{
			this.mInput.interactable = false;
			this.btn_InputField.gameObject.SetActive(false);
			this.btn_InputField2.gameObject.SetActive(false);
		}
		this.Tmp1 = this.Tmp.GetChild(16);
		this.btn_KHint = this.Tmp1.GetComponent<UIButton>();
		this.btn_KHint.m_Handler = this;
		this.btn_KHint.m_BtnID1 = 10;
		UIButtonHint uibuttonHint = this.btn_KHint.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		this.img_KHint = this.Tmp.GetChild(19).GetComponent<Image>();
		uibuttonHint.ControlFadeOut = this.img_KHint.gameObject;
		this.text_tmpStr[8] = this.Tmp.GetChild(19).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[8].font = this.TTFont;
		this.text_tmpStr[8].text = this.DM.mStringTable.GetStringByID(9549u);
		this.text_tmpStr[8].cachedTextGeneratorForLayout.Invalidate();
		this.text_tmpStr[8].rectTransform.sizeDelta = new Vector2(this.text_tmpStr[8].preferredWidth, this.text_tmpStr[8].rectTransform.sizeDelta.y);
		if (this.GUIM.IsArabic)
		{
			this.text_tmpStr[8].UpdateArabicPos();
		}
		this.text_tmpStr[9] = this.Tmp.GetChild(19).GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[9].font = this.TTFont;
		this.text_tmpStr[9].text = this.DM.mStringTable.GetStringByID(9550u);
		this.text_tmpStr[9].cachedTextGeneratorForLayout.Invalidate();
		if (this.text_tmpStr[9].preferredWidth > this.text_tmpStr[9].rectTransform.sizeDelta.x)
		{
			this.img_KHint.rectTransform.sizeDelta = new Vector2(this.text_tmpStr[9].preferredWidth + 12f, this.img_KHint.rectTransform.sizeDelta.y);
			this.text_tmpStr[9].rectTransform.sizeDelta = new Vector2(this.text_tmpStr[9].preferredWidth, this.text_tmpStr[9].rectTransform.sizeDelta.y);
			if (this.GUIM.IsArabic)
			{
				this.text_tmpStr[9].UpdateArabicPos();
			}
		}
		this.Tmp1 = this.Tmp.GetChild(20);
		this.TranslationRT = this.Tmp1.GetComponent<RectTransform>();
		this.btn_Translation = this.Tmp1.GetChild(0).GetComponent<UIButton>();
		this.btn_Translation.m_Handler = this;
		this.btn_Translation.m_BtnID1 = 11;
		this.Img_Translate = this.Tmp1.GetChild(1).GetComponent<Image>();
		this.text_Translation = this.Tmp1.GetChild(2).GetComponent<UIText>();
		this.text_Translation.font = this.TTFont;
		this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052u);
		if (this.text_Translation.preferredWidth > this.text_Translation.rectTransform.sizeDelta.x)
		{
			this.text_Translation.rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, this.text_Translation.rectTransform.sizeDelta.y);
		}
		if (this.GUIM.IsArabic)
		{
			this.text_Translation.UpdateArabicPos();
		}
		this.text_Trans.resizeTextForBestFit = false;
		this.text_Trans.cachedTextGeneratorForLayout.Invalidate();
		this.text_Trans.gameObject.SetActive(false);
		this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, -237.5f - this.text_Trans.preferredHeight);
		this.TranslationRT.gameObject.SetActive(false);
		this.Tmp1 = this.Tmp.GetChild(17);
		this.text_AllianceName = this.Tmp1.GetComponent<UIText>();
		this.text_AllianceName.font = this.TTFont;
		this.Cstr_AllianceName.ClearString();
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring2.ClearString();
		cstring.Append(this.DM.AllianceView.Name);
		cstring2.Append(this.DM.AllianceView.Tag);
		GameConstants.FormatRoleName(this.Cstr_AllianceName, cstring, cstring2, null, 0, 0, null, null, null, null);
		this.text_AllianceName.text = this.Cstr_AllianceName.ToString();
		this.text_AllianceName.gameObject.SetActive(false);
		this.Tmp1 = this.Tmp.GetChild(18);
		this.text_Alliance_K = this.Tmp1.GetComponent<UIText>();
		this.text_Alliance_K.font = this.TTFont;
		this.Cstr_Alliance_K.ClearString();
		this.Cstr_Alliance_K.IntToFormat((long)this.DM.AllianceView.KingdomID, 1, false);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_Alliance_K.AppendFormat("{0}#");
		}
		else
		{
			this.Cstr_Alliance_K.AppendFormat("#{0}");
		}
		this.text_Alliance_K.text = this.Cstr_Alliance_K.ToString();
		this.text_Alliance_K.gameObject.SetActive(false);
		this.Tmp = this.GameT.GetChild(2);
		this.btn_Msg = this.Tmp.GetComponent<UIButton>();
		this.btn_Msg.m_Handler = this;
		this.btn_Msg.m_BtnID1 = 1;
		this.btn_Msg.m_EffectType = e_EffectType.e_Scale;
		this.btn_Msg.transition = Selectable.Transition.None;
		this.Tmp1 = this.Tmp.GetChild(1);
		this.img_AMRank_Msg = this.Tmp1.GetComponent<Image>();
		this.Tmp1 = this.Tmp.GetChild(2);
		this.text_tmpStr[1] = this.Tmp1.GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(4637u);
		this.Tmp = this.GameT.GetChild(3);
		this.btn_Member = this.Tmp.GetComponent<UIButton>();
		this.btn_Member.m_Handler = this;
		this.btn_Member.m_BtnID1 = 2;
		this.btn_Member.m_EffectType = e_EffectType.e_Scale;
		this.btn_Member.transition = Selectable.Transition.None;
		this.Tmp1 = this.Tmp.GetChild(1);
		this.img_AMRank_Member = this.Tmp1.GetComponent<Image>();
		this.Tmp1 = this.Tmp.GetChild(2);
		this.text_tmpStr[2] = this.Tmp1.GetComponent<UIText>();
		this.text_tmpStr[2].font = this.TTFont;
		this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(4629u);
		this.Tmp = this.GameT.GetChild(4);
		this.btn_Data = this.Tmp.GetComponent<UIButton>();
		this.btn_Data.m_Handler = this;
		this.btn_Data.m_BtnID1 = 3;
		this.btn_Data.m_EffectType = e_EffectType.e_Scale;
		this.btn_Data.transition = Selectable.Transition.None;
		this.Tmp1 = this.Tmp.GetChild(1);
		this.img_AMRank_Data = this.Tmp1.GetComponent<Image>();
		this.Tmp1 = this.Tmp.GetChild(2);
		this.text_tmpStr[3] = this.Tmp1.GetComponent<UIText>();
		this.text_tmpStr[3].font = this.TTFont;
		this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(4639u);
		this.Tmp = this.GameT.GetChild(5);
		this.btn_Letter = this.Tmp.GetComponent<UIButton>();
		this.btn_Letter.m_Handler = this;
		this.btn_Letter.m_BtnID1 = 4;
		this.btn_Letter.m_EffectType = e_EffectType.e_Scale;
		this.btn_Letter.transition = Selectable.Transition.None;
		this.Tmp1 = this.Tmp.GetChild(1);
		this.img_AMRank_Letter = this.Tmp1.GetComponent<Image>();
		this.Tmp1 = this.Tmp.GetChild(2);
		this.text_tmpStr[4] = this.Tmp1.GetComponent<UIText>();
		this.text_tmpStr[4].font = this.TTFont;
		this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(4645u);
		this.Tmp = this.GameT.GetChild(6);
		this.btn_Join = this.Tmp.GetComponent<UIButton>();
		this.btn_Join.m_Handler = this;
		this.btn_Join.m_BtnID1 = 5;
		this.btn_Join.m_EffectType = e_EffectType.e_Scale;
		this.btn_Join.transition = Selectable.Transition.None;
		this.Tmp1 = this.Tmp.GetChild(1);
		this.text_join_btn = this.Tmp1.GetComponent<UIText>();
		this.text_join_btn.font = this.TTFont;
		if (this.DM.RoleAlliance.Id != 0u)
		{
			this.btn_Join.gameObject.SetActive(false);
		}
		this.Tmp = this.GameT.GetChild(7);
		this.img_InputBG = this.Tmp.GetComponent<Image>();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.img_InputBG.rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.img_InputBG.rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.btn_Input_Edit = this.Tmp.GetChild(0).GetComponent<UIButton>();
		this.btn_Input_Edit.m_Handler = this;
		this.btn_Input_Edit.m_BtnID1 = 9;
		this.btn_Input_Edit.m_EffectType = e_EffectType.e_Scale;
		this.btn_Input_Edit.transition = Selectable.Transition.None;
		this.text_InputCheck = this.Tmp.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_InputCheck.font = this.TTFont;
		this.text_InputCheck.SetCheckArabic(true);
		this.btn_Input_OK = this.Tmp.GetChild(2).GetComponent<UIButton>();
		this.btn_Input_OK.m_Handler = this;
		this.btn_Input_OK.m_BtnID1 = 7;
		this.btn_Input_OK.m_EffectType = e_EffectType.e_Scale;
		this.btn_Input_OK.transition = Selectable.Transition.None;
		this.text_tmpStr[5] = this.Tmp.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[5].font = this.TTFont;
		this.text_tmpStr[5].text = this.DM.mStringTable.GetStringByID(512u);
		this.btn_Input_C = this.Tmp.GetChild(3).GetComponent<UIButton>();
		this.btn_Input_C.m_Handler = this;
		this.btn_Input_C.m_BtnID1 = 8;
		this.btn_Input_C.m_EffectType = e_EffectType.e_Scale;
		this.btn_Input_C.transition = Selectable.Transition.None;
		this.text_tmpStr[6] = this.Tmp.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[6].font = this.TTFont;
		this.text_tmpStr[6].text = this.DM.mStringTable.GetStringByID(513u);
		this.text_tmpStr[7] = this.Tmp.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[7].font = this.TTFont;
		this.text_tmpStr[7].text = this.DM.mStringTable.GetStringByID(774u);
		if (this.mState == 0)
		{
			this.text_join_btn.text = this.DM.mStringTable.GetStringByID(4646u);
		}
		else if (this.mState == 1)
		{
			this.text_join_btn.text = this.DM.mStringTable.GetStringByID(4647u);
		}
		else if (this.mState == 2)
		{
			this.text_join_btn.text = this.DM.mStringTable.GetStringByID(4648u);
		}
		else
		{
			this.btn_Letter.gameObject.SetActive(false);
		}
		if (this.DM.AllianceView.Approval == 0)
		{
			this.bNeedApplication = false;
		}
		else
		{
			this.bNeedApplication = true;
		}
		if (this.bNeedApplication)
		{
			this.text_join.text = this.DM.mStringTable.GetStringByID(4643u);
			this.text_join.color = this.Color_Red;
			this.Img_Join.sprite = this.SArray.m_Sprites[0];
			this.btn_Join.image.sprite = this.SArray.m_Sprites[3];
		}
		else
		{
			this.text_join.text = this.DM.mStringTable.GetStringByID(4644u);
			this.text_join.color = this.Color_Green;
			this.Img_Join.sprite = this.SArray.m_Sprites[1];
			this.btn_Join.image.sprite = this.SArray.m_Sprites[2];
		}
		this.Tmp = this.GameT.GetChild(8);
		UIButton component3 = this.Tmp.GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 12;
		uibuttonHint = component3.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		this.AM1 = this.Tmp.GetComponent<UISpritesArray>();
		this.Tmp = this.GameT.GetChild(9);
		component3 = this.Tmp.GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 12;
		uibuttonHint = component3.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		this.AW1 = this.Tmp.GetComponent<UISpritesArray>();
		this.AWRank1 = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.AWRank1.font = this.TTFont;
		this.Tmp = this.GameT.GetChild(10);
		this.Tmp.SetParent(this.GUIM.m_ItemInfoLayer, false);
		this.AMWHintGO = this.Tmp.gameObject;
		this.AMWTitle = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.AMWTitle.font = this.TTFont;
		this.AMWTitle.text = this.DM.mStringTable.GetStringByID(16149u);
		this.AM2 = this.Tmp.GetChild(2).GetComponent<UISpritesArray>();
		this.AW2 = this.Tmp.GetChild(3).GetComponent<UISpritesArray>();
		this.AWRank2 = this.Tmp.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.AWRank2.font = this.TTFont;
		this.AMHint = this.Tmp.GetChild(4).GetComponent<UIText>();
		this.AMHint.font = this.TTFont;
		this.AWHint = this.Tmp.GetChild(5).GetComponent<UIText>();
		this.AWHint.font = this.TTFont;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001025 RID: 4133 RVA: 0x001CB050 File Offset: 0x001C9250
	public void ChangText(string ID)
	{
		this.text_InputCheck.text = ID;
		this.text_InputCheck.SetAllDirty();
		this.text_InputCheck.cachedTextGenerator.Invalidate();
		this.mInput.text = StringManager.InputTemp;
		this.mInput.text = ID;
		this.OpenInputCheck(true);
	}

	// Token: 0x06001026 RID: 4134 RVA: 0x001CB0A8 File Offset: 0x001C92A8
	protected char OnValidateInput(string text, int index, char check)
	{
		int num = Encoding.UTF8.GetByteCount(text) + Encoding.UTF8.GetByteCount(check.ToString());
		if (num > 756)
		{
			return '\0';
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.Append(text);
		cstring.Append(check.ToString());
		this.text_InputCheck.text = cstring.ToString();
		this.text_InputCheck.SetAllDirty();
		this.text_InputCheck.cachedTextGenerator.Invalidate();
		if (this.text_InputCheck.preferredHeight > 234f)
		{
			return '\0';
		}
		return check;
	}

	// Token: 0x06001027 RID: 4135 RVA: 0x001CB144 File Offset: 0x001C9344
	public override void OnClose()
	{
		if (this.Cstr_Alliance_K != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Alliance_K);
		}
		if (this.Cstr_AllianceName != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_AllianceName);
		}
		if (this.Cstr_AllianceChief != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_AllianceChief);
		}
		if (this.Cstr_AllianceStrength != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_AllianceStrength);
		}
		if (this.Cstr_AllianceMember != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_AllianceMember);
		}
		if (this.Cstr_GifeLV != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_GifeLV);
		}
		if (this.Cstr_AllianceLanguage != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_AllianceLanguage);
		}
		if (this.Cstr_Null != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Null);
		}
		if (this.Cstr_Translation != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Translation);
		}
		if (this.mInput != null)
		{
			this.mInput.onEndEdit.RemoveAllListeners();
		}
		if (this.CStrAWRank != null)
		{
			StringManager.Instance.DeSpawnString(this.CStrAWRank);
		}
		if (this.CStrAMHint != null)
		{
			StringManager.Instance.DeSpawnString(this.CStrAMHint);
		}
		if (this.CStrAWHint != null)
		{
			StringManager.Instance.DeSpawnString(this.CStrAWHint);
		}
		if (this.AMWHintGO != null && this.GameT != null)
		{
			this.AMWHintGO.transform.SetParent(this.GameT, false);
		}
	}

	// Token: 0x06001028 RID: 4136 RVA: 0x001CB2FC File Offset: 0x001C94FC
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
			this.DM.AskMessageBoard(this.DM.AllianceView.Id);
			break;
		case 2:
			this.door.OpenMenu(EGUIWindow.UI_Alliance_List, 3, (int)this.DM.AllianceView.Id, false);
			break;
		case 3:
			UILeaderBoard.NewOpen = true;
			this.door.OpenMenu(EGUIWindow.UI_LeaderBoard, 1, (int)this.DM.AllianceView.Id, false);
			break;
		case 4:
			this.DM.Letter_ReplyName = this.DM.AllianceView.Leader;
			this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 2, 0, false);
			break;
		case 5:
			if (this.door != null)
			{
				this.door.AllianceOnJoin(this.DM.AllianceView.Id, this.DM.AllianceView.Approval);
			}
			break;
		case 6:
			if (!this.mInput.gameObject.activeSelf)
			{
				this.mInput.gameObject.SetActive(true);
			}
			this.mInput.ActivateInputField();
			if (this.text_Trans.gameObject.activeSelf)
			{
				this.text_Trans.gameObject.SetActive(false);
			}
			break;
		case 7:
			if (this.DM.RoleAlliance.Rank < AllianceRank.RANK4)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4753u), 255, true);
				this.door.CloseMenu(false);
				return;
			}
			if (this.DM.RoleAlliance.Id != 0u && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4 && GUIManager.Instance.ShowUILock(EUILock.Alliance_Manage))
			{
				char[] array = this.mInput.text.ToCharArray();
				if (this.DM.m_BannedWord != null)
				{
					this.DM.m_BannedWord.CheckBannedWord(array);
				}
				byte[] bytes = Encoding.UTF8.GetBytes(array);
				MessagePacket messagePacket = new MessagePacket(1311);
				messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_BRIEF;
				messagePacket.AddSeqId();
				messagePacket.Add((ushort)bytes.Length);
				messagePacket.Add(bytes, 0, 1300);
				byte data;
				if (ArabicTransfer.Instance.IsArabicStr(this.mInput.text))
				{
					data = 2;
				}
				else
				{
					data = 1;
				}
				messagePacket.Add(data);
				messagePacket.Send(false);
			}
			this.OpenInputCheck(false);
			break;
		case 8:
			if (this.mInput.gameObject.activeSelf)
			{
				this.mInput.gameObject.SetActive(false);
			}
			this.mInput.text = this.DM.AllianceView.Notice;
			if (!this.text_Trans.gameObject.activeSelf)
			{
				this.text_Trans.gameObject.SetActive(true);
			}
			this.bShowTranslate = true;
			this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052u);
			this.text_Translation.SetAllDirty();
			this.text_Translation.cachedTextGenerator.Invalidate();
			this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
			if (-237.5f - this.text_Trans.preferredHeight > -470f)
			{
				this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, -237.5f - this.text_Trans.preferredHeight);
			}
			else
			{
				this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, -470f);
			}
			if (this.text_Translation.preferredWidth > this.text_Translation.rectTransform.sizeDelta.x)
			{
				this.text_Translation.rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, this.text_Translation.rectTransform.sizeDelta.y);
			}
			if (this.GUIM.IsArabic)
			{
				this.text_Translation.UpdateArabicPos();
			}
			this.OpenInputCheck(false);
			break;
		case 9:
			this.OpenInputCheck(false);
			this.mInput.ActivateInputField();
			if (this.text_Trans.gameObject.activeSelf)
			{
				this.text_Trans.gameObject.SetActive(false);
			}
			break;
		case 11:
			if (this.DM.bWaitTranslate_AA)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8459u), 255, true);
				return;
			}
			if (IGGGameSDK.Instance.GetTranslateStatus() && this.DM.bNeedTranslate_AA_P && !this.DM.bTranslate_AA_P && !this.DM.bWaitTranslate_AA)
			{
				this.btn_Translation.gameObject.SetActive(false);
				this.Img_Translate.gameObject.SetActive(true);
				this.DM.bWaitTranslate_AA = true;
				this.DM.bTransAA = false;
				IGGSDKPlugin.Translate_AA(this.DM.AllianceView.Notice);
			}
			else
			{
				if (!this.bShowTranslate)
				{
					this.text_Trans.text = this.DM.AllianceView.Notice;
					this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052u);
					this.bShowTranslate = true;
				}
				else
				{
					this.text_Trans.text = IGGGameSDK.Instance.TranslateStringOut_AA_Public.ToString();
					this.Cstr_Translation.ClearString();
					this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte)this.DM.mAA_P_L));
					this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054u));
					this.text_Translation.text = this.Cstr_Translation.ToString();
					this.bShowTranslate = false;
				}
				this.text_Trans.SetAllDirty();
				this.text_Trans.cachedTextGenerator.Invalidate();
				this.text_Trans.cachedTextGeneratorForLayout.Invalidate();
				this.text_Translation.SetAllDirty();
				this.text_Translation.cachedTextGenerator.Invalidate();
				this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
				if (-237.5f - this.text_Trans.preferredHeight > -470f)
				{
					this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, -237.5f - this.text_Trans.preferredHeight);
				}
				else
				{
					this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, -470f);
				}
				if (this.text_Translation.preferredWidth > this.text_Translation.rectTransform.sizeDelta.x)
				{
					this.text_Translation.rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, this.text_Translation.rectTransform.sizeDelta.y);
				}
				if (this.GUIM.IsArabic)
				{
					this.text_Translation.UpdateArabicPos();
				}
			}
			break;
		}
	}

	// Token: 0x06001029 RID: 4137 RVA: 0x001CBAE4 File Offset: 0x001C9CE4
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		switch (uibutton.m_BtnID1)
		{
		case 10:
			this.img_KHint.gameObject.SetActive(true);
			break;
		case 12:
			this.SetAMWHint(true, uibutton.transform);
			break;
		}
	}

	// Token: 0x0600102A RID: 4138 RVA: 0x001CBB48 File Offset: 0x001C9D48
	public void OnButtonUp(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		switch (uibutton.m_BtnID1)
		{
		case 10:
			this.img_KHint.gameObject.SetActive(false);
			break;
		case 12:
			this.SetAMWHint(false, null);
			break;
		}
	}

	// Token: 0x0600102B RID: 4139 RVA: 0x001CBBA8 File Offset: 0x001C9DA8
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			if (this.DM.RoleAlliance.Id == 0u && this.mType != 5)
			{
				if (this.img_InputBG != null)
				{
					this.OpenInputCheck(false);
				}
				this.door.CloseMenu_Alliance(EGUIWindow.UIAlliance_publicinfo);
				return;
			}
			break;
		default:
			if (networkNews != NetworkNews.Refresh_Alliance)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else
			{
				if (this.DM.RoleAlliance.Id == 0u && this.mType != 5)
				{
					this.door.CloseMenu_Alliance(EGUIWindow.UIAlliance_publicinfo);
					return;
				}
				if (this.DM.RoleAlliance.Id == this.DM.AllianceView.Id && this.Cstr_Alliance_K != null && this.text_Alliance_K != null && this.btn_KHint != null)
				{
					this.Cstr_Alliance_K.ClearString();
					this.Cstr_Alliance_K.IntToFormat((long)this.DM.RoleAlliance.KingdomID, 1, false);
					if (this.GUIM.IsArabic)
					{
						this.Cstr_Alliance_K.AppendFormat("{0}#");
					}
					else
					{
						this.Cstr_Alliance_K.AppendFormat("#{0}");
					}
					this.text_Alliance_K.text = this.Cstr_Alliance_K.ToString();
					this.text_Alliance_K.SetAllDirty();
					this.text_Alliance_K.cachedTextGenerator.Invalidate();
					this.DM.AllianceView.KingdomID = this.DM.RoleAlliance.KingdomID;
					this.SetKingdomBtn(-1f);
				}
			}
			break;
		}
	}

	// Token: 0x0600102C RID: 4140 RVA: 0x001CBD78 File Offset: 0x001C9F78
	public void Refresh_FontTexture()
	{
		if (this.text_AllianceChief != null && this.text_AllianceChief.enabled)
		{
			this.text_AllianceChief.enabled = false;
			this.text_AllianceChief.enabled = true;
		}
		if (this.text_AllianceStrength != null && this.text_AllianceStrength.enabled)
		{
			this.text_AllianceStrength.enabled = false;
			this.text_AllianceStrength.enabled = true;
		}
		if (this.text_AllianceMember != null && this.text_AllianceMember.enabled)
		{
			this.text_AllianceMember.enabled = false;
			this.text_AllianceMember.enabled = true;
		}
		if (this.text_AllianceLanguage != null && this.text_AllianceLanguage.enabled)
		{
			this.text_AllianceLanguage.enabled = false;
			this.text_AllianceLanguage.enabled = true;
		}
		if (this.text_Gife != null && this.text_Gife.enabled)
		{
			this.text_Gife.enabled = false;
			this.text_Gife.enabled = true;
		}
		if (this.text_join != null && this.text_join.enabled)
		{
			this.text_join.enabled = false;
			this.text_join.enabled = true;
		}
		if (this.text_join_btn != null && this.text_join_btn.enabled)
		{
			this.text_join_btn.enabled = false;
			this.text_join_btn.enabled = true;
		}
		if (this.text_AllianceName != null && this.text_AllianceName.enabled)
		{
			this.text_AllianceName.enabled = false;
			this.text_AllianceName.enabled = true;
		}
		if (this.text_InputCheck != null && this.text_InputCheck.enabled)
		{
			this.text_InputCheck.enabled = false;
			this.text_InputCheck.enabled = true;
		}
		if (this.text_Input1 != null && this.text_Input1.enabled)
		{
			this.text_Input1.enabled = false;
			this.text_Input1.enabled = true;
		}
		if (this.mInput != null && this.mInput.textComponent.enabled)
		{
			this.mInput.textComponent.enabled = false;
			this.mInput.textComponent.enabled = true;
		}
		if (this.img_text != null)
		{
			if (this.img_text.m_RunningText1 != null && this.img_text.m_RunningText1.enabled)
			{
				this.img_text.m_RunningText1.enabled = false;
				this.img_text.m_RunningText1.enabled = true;
			}
			if (this.img_text.m_RunningText2 != null && this.img_text.m_RunningText2.enabled)
			{
				this.img_text.m_RunningText2.enabled = false;
				this.img_text.m_RunningText2.enabled = true;
			}
		}
		if (this.text_Trans != null && this.text_Trans.enabled)
		{
			this.text_Trans.enabled = false;
			this.text_Trans.enabled = true;
		}
		if (this.text_Translation != null && this.text_Translation.enabled)
		{
			this.text_Translation.enabled = false;
			this.text_Translation.enabled = true;
		}
		if (this.text_Title_AMP != null && this.text_Title_AMP.enabled)
		{
			this.text_Title_AMP.enabled = false;
			this.text_Title_AMP.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_Propaganda[i] != null && this.text_Propaganda[i].enabled)
			{
				this.text_Propaganda[i].enabled = false;
				this.text_Propaganda[i].enabled = true;
			}
		}
		for (int j = 0; j < 10; j++)
		{
			if (this.text_tmpStr[j] != null && this.text_tmpStr[j].enabled)
			{
				this.text_tmpStr[j].enabled = false;
				this.text_tmpStr[j].enabled = true;
			}
		}
		if (this.AWRank1 != null && this.AWRank1.enabled)
		{
			this.AWRank1.enabled = false;
			this.AWRank1.enabled = true;
		}
		if (this.AWRank2 != null && this.AWRank2.enabled)
		{
			this.AWRank2.enabled = false;
			this.AWRank2.enabled = true;
		}
		if (this.AMHint != null && this.AMHint.enabled)
		{
			this.AMHint.enabled = false;
			this.AMHint.enabled = true;
		}
		if (this.AWHint != null && this.AWHint.enabled)
		{
			this.AWHint.enabled = false;
			this.AWHint.enabled = true;
		}
		if (this.AMWTitle != null && this.AMWTitle.enabled)
		{
			this.AMWTitle.enabled = false;
			this.AMWTitle.enabled = true;
		}
	}

	// Token: 0x0600102D RID: 4141 RVA: 0x001CC324 File Offset: 0x001CA524
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
		{
			this.Cstr_AllianceChief.ClearString();
			this.Cstr_AllianceChief.StringToFormat(this.DM.AllianceView.Leader);
			this.Cstr_AllianceChief.AppendFormat(this.DM.mStringTable.GetStringByID(4625u));
			this.text_AllianceChief.text = this.Cstr_AllianceChief.ToString();
			this.text_AllianceChief.SetAllDirty();
			this.text_AllianceChief.cachedTextGenerator.Invalidate();
			this.text_AllianceChief.gameObject.SetActive(true);
			this.Cstr_AllianceStrength.ClearString();
			this.Cstr_AllianceStrength.uLongToFormat(this.DM.AllianceView.Power, 1, true);
			this.Cstr_AllianceStrength.AppendFormat(this.DM.mStringTable.GetStringByID(4626u));
			this.text_AllianceStrength.text = this.Cstr_AllianceStrength.ToString();
			this.text_AllianceStrength.SetAllDirty();
			this.text_AllianceStrength.cachedTextGenerator.Invalidate();
			this.text_AllianceStrength.gameObject.SetActive(true);
			this.Cstr_AllianceMember.ClearString();
			this.Cstr_AllianceMember.IntToFormat((long)this.DM.AllianceView.Member, 1, false);
			this.Cstr_AllianceMember.AppendFormat(this.DM.mStringTable.GetStringByID(4627u));
			this.text_AllianceMember.text = this.Cstr_AllianceMember.ToString();
			this.text_AllianceMember.SetAllDirty();
			this.text_AllianceMember.cachedTextGenerator.Invalidate();
			this.text_AllianceMember.gameObject.SetActive(true);
			this.Cstr_AllianceLanguage.ClearString();
			this.Cstr_AllianceLanguage.StringToFormat(this.DM.GetLanguageStr(this.DM.AllianceView.Language));
			this.Cstr_AllianceLanguage.AppendFormat(this.DM.mStringTable.GetStringByID(4642u));
			this.text_AllianceLanguage.text = this.Cstr_AllianceLanguage.ToString();
			this.text_AllianceLanguage.SetAllDirty();
			this.text_AllianceLanguage.cachedTextGenerator.Invalidate();
			this.text_AllianceLanguage.gameObject.SetActive(true);
			this.Cstr_GifeLV.ClearString();
			this.Cstr_GifeLV.IntToFormat((long)this.DM.AllianceView.GiftLv, 1, false);
			this.Cstr_GifeLV.AppendFormat(this.DM.mStringTable.GetStringByID(4631u));
			this.text_Gife.text = this.Cstr_GifeLV.ToString();
			this.text_Gife.SetAllDirty();
			this.text_Gife.cachedTextGenerator.Invalidate();
			this.text_Gife.gameObject.SetActive(true);
			if (this.DM.AllianceView.Approval == 0)
			{
				this.bNeedApplication = false;
			}
			else
			{
				this.bNeedApplication = true;
			}
			if (this.bNeedApplication)
			{
				this.text_join.text = this.DM.mStringTable.GetStringByID(4643u);
				this.text_join.color = this.Color_Red;
				this.Img_Join.sprite = this.SArray.m_Sprites[0];
				this.btn_Join.image.sprite = this.SArray.m_Sprites[3];
				this.text_join_btn.text = this.DM.mStringTable.GetStringByID(4647u);
			}
			else
			{
				this.text_join.text = this.DM.mStringTable.GetStringByID(4644u);
				this.text_join.color = this.Color_Green;
				this.Img_Join.sprite = this.SArray.m_Sprites[1];
				this.btn_Join.image.sprite = this.SArray.m_Sprites[2];
				this.text_join_btn.text = this.DM.mStringTable.GetStringByID(4646u);
			}
			this.text_join.gameObject.SetActive(true);
			this.text_join.SetAllDirty();
			this.text_join.cachedTextGenerator.Invalidate();
			if (this.DM.RoleAlliance.ApplyList != null)
			{
				bool flag = false;
				for (int i = 0; i < this.DM.RoleAlliance.ApplyList.Length; i++)
				{
					if (this.DM.RoleAlliance.ApplyList[i] == this.DM.AllianceView.Id)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					this.text_join_btn.text = this.DM.mStringTable.GetStringByID(4648u);
					this.btn_Join.image.sprite = this.SArray.m_Sprites[4];
				}
			}
			this.text_join_btn.SetAllDirty();
			this.text_join_btn.cachedTextGenerator.Invalidate();
			if (this.DM.AllianceView.Notice != null)
			{
				this.Cstr_Null.ClearString();
				this.mInput.text = this.Cstr_Null.ToString();
				if (this.DM.AllianceView.Notice.Length != 0)
				{
					this.mInput.text = this.DM.AllianceView.Notice;
				}
				else if (this.DM.AllianceView.Id == this.DM.RoleAlliance.Id && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
				{
					this.text_Input1.text = this.DM.mStringTable.GetStringByID(773u);
					this.mInput.text = this.DM.mStringTable.GetStringByID(773u);
				}
				else
				{
					this.text_Input1.text = this.Cstr_Null.ToString();
				}
				this.text_Trans.text = this.mInput.text;
				this.text_Trans.resizeTextForBestFit = false;
				this.text_Trans.SetAllDirty();
				this.text_Trans.cachedTextGenerator.Invalidate();
				this.text_Trans.cachedTextGeneratorForLayout.Invalidate();
				this.text_Trans.gameObject.SetActive(false);
				if (-237.5f - this.text_Trans.preferredHeight > -470f)
				{
					this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, -237.5f - this.text_Trans.preferredHeight);
				}
				else
				{
					this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, -470f);
				}
				if (IGGGameSDK.Instance.GetTranslateStatus() && this.DM.AllianceView.Notice != null && this.DM.AllianceView.Notice.Length > 0)
				{
					this.TranslationRT.gameObject.SetActive(true);
				}
				else
				{
					this.TranslationRT.gameObject.SetActive(false);
				}
				this.DM.bNeedTranslate_AA_P = true;
			}
			if (this.DM.AllianceView.Id == this.DM.RoleAlliance.Id && this.DM.RoleAlliance.Rank < AllianceRank.RANK4)
			{
				this.mInput.DeactivateInputField();
			}
			this.Cstr_AllianceName.ClearString();
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring2.ClearString();
			cstring.Append(this.DM.AllianceView.Name);
			cstring2.Append(this.DM.AllianceView.Tag);
			GameConstants.FormatRoleName(this.Cstr_AllianceName, cstring, cstring2, null, 0, 0, null, null, null, null);
			this.text_AllianceName.text = this.Cstr_AllianceName.ToString();
			this.text_AllianceName.SetAllDirty();
			this.text_AllianceName.cachedTextGenerator.Invalidate();
			this.text_AllianceName.gameObject.SetActive(true);
			this.GUIM.InitBadgeTotem(this.BadgeT, this.DM.AllianceView.Emblem);
			RectTransform component = this.text_Propaganda[0].transform.GetComponent<RectTransform>();
			this.tmpString.Length = 0;
			this.tmpString.Append(this.DM.AllianceView.Header);
			this.text_Propaganda[0].text = this.tmpString.ToString();
			this.text_Propaganda[0].gameObject.SetActive(true);
			this.text_Propaganda[1].text = this.tmpString.ToString();
			this.text_Propaganda[1].gameObject.SetActive(true);
			RectTransform component2 = this.text_Propaganda[1].GetComponent<RectTransform>();
			if (this.text_Propaganda[0].preferredWidth > 281f)
			{
				component.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth, component.sizeDelta.y);
				if (this.GUIM.IsArabic)
				{
					this.text_Propaganda[0].UpdateArabicPos();
				}
				component2.anchoredPosition = new Vector2(this.text_Propaganda[0].preferredWidth, component2.anchoredPosition.y);
				component2.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth, component2.sizeDelta.y);
				if (this.GUIM.IsArabic)
				{
					this.text_Propaganda[1].UpdateArabicPos();
				}
				this.img_text.tmpLength = this.text_Propaganda[0].preferredWidth;
			}
			if (this.DM.AllianceView.Id != this.DM.RoleAlliance.Id)
			{
				if (this.DM.AllianceView.Header == null || this.DM.AllianceView.Header.Length == 0)
				{
					this.img_text.gameObject.SetActive(false);
				}
				else
				{
					this.img_text.gameObject.SetActive(true);
				}
			}
			else if (this.DM.RoleAlliance.Header == null || this.DM.RoleAlliance.Header.Length == 0)
			{
				this.img_text.gameObject.SetActive(false);
			}
			else
			{
				this.img_text.gameObject.SetActive(true);
			}
			this.Cstr_Alliance_K.ClearString();
			this.Cstr_Alliance_K.IntToFormat((long)this.DM.AllianceView.KingdomID, 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Alliance_K.AppendFormat("{0}#");
			}
			else
			{
				this.Cstr_Alliance_K.AppendFormat("#{0}");
			}
			this.text_Alliance_K.text = this.Cstr_Alliance_K.ToString();
			this.text_Alliance_K.SetAllDirty();
			this.text_Alliance_K.cachedTextGenerator.Invalidate();
			this.CheckAMPlaceMainInfo();
			this.CheckShowAMWBtn();
			break;
		}
		case 2:
			this.text_join_btn.text = this.DM.mStringTable.GetStringByID(4648u);
			this.btn_Join.image.sprite = this.SArray.m_Sprites[4];
			this.text_join_btn.SetAllDirty();
			this.text_join_btn.cachedTextGenerator.Invalidate();
			break;
		case 3:
			if (this.DM.AllianceView.Id == this.DM.RoleAlliance.Id)
			{
				this.mInput.text = this.DM.RoleAlliance.Notice;
				this.DM.AllianceView.Notice = this.DM.RoleAlliance.Notice;
				this.text_Trans.text = this.mInput.text;
				this.text_Trans.resizeTextForBestFit = false;
				this.text_Trans.SetAllDirty();
				this.text_Trans.cachedTextGenerator.Invalidate();
				this.text_Trans.cachedTextGeneratorForLayout.Invalidate();
				this.text_Trans.gameObject.SetActive(false);
				if (-237.5f - this.text_Trans.preferredHeight > -470f)
				{
					this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, -237.5f - this.text_Trans.preferredHeight);
				}
				else
				{
					this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, -470f);
				}
				if (IGGGameSDK.Instance.GetTranslateStatus() && this.DM.AllianceView.Notice != null && this.DM.AllianceView.Notice.Length > 0)
				{
					this.TranslationRT.gameObject.SetActive(true);
				}
				else
				{
					this.TranslationRT.gameObject.SetActive(false);
				}
				this.DM.bNeedTranslate_AA_P = true;
				this.bShowTranslate = false;
				if (IGGGameSDK.Instance.GetTranslateStatus())
				{
					if (!this.bShowTranslate)
					{
						this.text_Trans.text = this.DM.AllianceView.Notice;
						this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052u);
						this.bShowTranslate = true;
					}
					else
					{
						this.text_Trans.text = IGGGameSDK.Instance.TranslateStringOut_AA_Public.ToString();
						this.Cstr_Translation.ClearString();
						this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte)this.DM.mAA_P_L));
						this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054u));
						this.text_Translation.text = this.Cstr_Translation.ToString();
						this.bShowTranslate = false;
					}
					this.text_Trans.SetAllDirty();
					this.text_Trans.cachedTextGenerator.Invalidate();
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
				}
			}
			break;
		case 4:
			if (this.DM.AllianceView.Id == this.DM.RoleAlliance.Id)
			{
				this.Cstr_AllianceLanguage.ClearString();
				this.Cstr_AllianceLanguage.StringToFormat(this.DM.GetLanguageStr(this.DM.RoleAlliance.Language));
				this.Cstr_AllianceLanguage.AppendFormat(this.DM.mStringTable.GetStringByID(4642u));
				this.text_AllianceLanguage.text = this.Cstr_AllianceLanguage.ToString();
				this.text_AllianceLanguage.SetAllDirty();
				this.text_AllianceLanguage.cachedTextGenerator.Invalidate();
			}
			break;
		case 5:
			this.mInput.ActivateInputField();
			if (this.text_Trans.gameObject.activeSelf)
			{
				this.text_Trans.gameObject.SetActive(false);
			}
			break;
		case 6:
			this.door.CloseMenu(false);
			break;
		case 7:
			this.bShowTranslate = false;
			this.mInput.gameObject.SetActive(false);
			this.text_Trans.text = IGGGameSDK.Instance.TranslateStringOut_AA_Public.ToString();
			this.text_Trans.resizeTextForBestFit = true;
			this.text_Trans.resizeTextMaxSize = 17;
			this.text_Trans.gameObject.SetActive(true);
			this.text_Trans.cachedTextGeneratorForLayout.Invalidate();
			if (-237.5f - this.text_Trans.preferredHeight > -470f)
			{
				this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, -237.5f - this.text_Trans.preferredHeight);
			}
			else
			{
				this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, -470f);
			}
			this.btn_Translation.gameObject.SetActive(true);
			this.Img_Translate.gameObject.SetActive(false);
			this.Cstr_Translation.ClearString();
			this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte)this.DM.mAA_P_L));
			this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054u));
			this.text_Translation.text = this.Cstr_Translation.ToString();
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
			break;
		case 8:
			this.btn_Translation.gameObject.SetActive(true);
			this.Img_Translate.gameObject.SetActive(false);
			this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9077u), 255, true);
			break;
		case 9:
			if (this.DM.RoleAlliance.Id == this.DM.AllianceView.Id)
			{
				if (this.DM.RoleAlliance.Rank < AllianceRank.RANK4)
				{
					this.mInput.DeactivateInputField();
					this.btn_InputField.gameObject.SetActive(false);
					this.btn_InputField2.gameObject.SetActive(false);
					if (this.img_InputBG != null)
					{
						this.OpenInputCheck(false);
					}
					if (!this.DM.bNeedTranslate_AA_P && this.mInput.gameObject.activeSelf)
					{
						this.mInput.gameObject.SetActive(false);
					}
					if (!this.DM.bNeedTranslate_AA_P && !this.text_Trans.gameObject.activeSelf)
					{
						this.text_Trans.gameObject.SetActive(true);
					}
					this.mInput.interactable = false;
				}
				else
				{
					this.mInput.interactable = true;
					this.btn_InputField.gameObject.SetActive(true);
					this.btn_InputField2.gameObject.SetActive(true);
				}
				if (this.DM.AllianceView.Notice == null)
				{
					if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
					{
						this.text_Input1.text = this.DM.mStringTable.GetStringByID(773u);
					}
					else
					{
						this.Cstr_Null.ClearString();
						this.text_Input1.text = this.Cstr_Null.ToString();
						this.mInput.text = this.Cstr_Null.ToString();
						this.text_Trans.text = this.mInput.text;
					}
				}
			}
			break;
		}
	}

	// Token: 0x0600102E RID: 4142 RVA: 0x001CD7B8 File Offset: 0x001CB9B8
	public void OpenInputCheck(bool bOpen)
	{
		if (bOpen)
		{
			this.img_InputBG.transform.SetParent(this.GUIM.m_SecWindowLayer, false);
			this.img_InputBG.gameObject.SetActive(true);
		}
		else
		{
			this.img_InputBG.transform.SetParent(this.GameT, false);
			this.img_InputBG.transform.SetSiblingIndex(5);
			this.img_InputBG.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600102F RID: 4143 RVA: 0x001CD838 File Offset: 0x001CBA38
	public override bool OnBackButtonClick()
	{
		if (this.img_InputBG.IsActive())
		{
			this.OpenInputCheck(false);
		}
		return false;
	}

	// Token: 0x06001030 RID: 4144 RVA: 0x001CD854 File Offset: 0x001CBA54
	public void CheckAMPlaceMainInfo()
	{
		this.tmpRank = 0;
		if (this.DM.AllianceView.AMPlaceMainInfoUIShow == 1)
		{
			this.tmpRank = 1;
		}
		else if (this.DM.AllianceView.AMPlaceMainInfoUIShow >= 2 && this.DM.AllianceView.AMPlaceMainInfoUIShow <= 10)
		{
			this.tmpRank = 2;
		}
		else if (this.DM.AllianceView.AMPlaceMainInfoUIShow >= 11 && this.DM.AllianceView.AMPlaceMainInfoUIShow <= 50)
		{
			this.tmpRank = 3;
		}
		else if (this.DM.AllianceView.AMPlaceMainInfoUIShow >= 51 && this.DM.AllianceView.AMPlaceMainInfoUIShow <= 100)
		{
			this.tmpRank = 4;
		}
		if (this.img_AMRankNew_BG2 != null)
		{
			this.img_AMRankNew_BG2.gameObject.SetActive(false);
		}
		if (this.img_AMRank1_F != null)
		{
			this.img_AMRank1_F.gameObject.SetActive(false);
		}
		if (this.tmpRank > 0)
		{
			if (this.img_Title != null)
			{
				this.img_Title.gameObject.SetActive(false);
			}
			if (this.img_AMRank_Title != null)
			{
				this.img_AMRank_Title.gameObject.SetActive(true);
			}
			if (this.img_AMRank_TopBG != null)
			{
				this.img_AMRank_TopBG.gameObject.SetActive(false);
			}
			if (this.img_AMRank_TopBG2 != null)
			{
				this.img_AMRank_TopBG2.gameObject.SetActive(false);
			}
			if (this.img_AMRankNew_BG != null)
			{
				this.img_AMRankNew_BG.gameObject.SetActive(true);
			}
			if (this.img_AMRank_InputBG != null)
			{
				this.img_AMRank_InputBG.gameObject.SetActive(true);
			}
			if (this.img_AMRank_Msg != null)
			{
				this.img_AMRank_Msg.gameObject.SetActive(true);
			}
			if (this.img_AMRank_Member != null)
			{
				this.img_AMRank_Member.gameObject.SetActive(true);
			}
			if (this.img_AMRank_Data != null)
			{
				this.img_AMRank_Data.gameObject.SetActive(true);
			}
			if (this.img_AMRank_Letter != null)
			{
				this.img_AMRank_Letter.gameObject.SetActive(true);
			}
			if (this.img_AMRankNew_BG2 != null && (this.tmpRank == 1 || this.tmpRank == 2))
			{
				this.img_AMRankNew_BG2.gameObject.SetActive(true);
			}
			if (this.img_AMRank1_F != null && this.DM.AllianceView.AMPlaceMainInfoUIShow == 1)
			{
				this.img_AMRank1_F.gameObject.SetActive(true);
			}
			if (this.img_AMRank_LF != null)
			{
				if (this.tmpRank == 1)
				{
					this.img_AMRank_LF.rectTransform.sizeDelta = new Vector2(this.img_AMRank_LF.rectTransform.sizeDelta.x, 218f);
				}
				else if (this.tmpRank == 2)
				{
					this.img_AMRank_LF.rectTransform.sizeDelta = new Vector2(this.img_AMRank_LF.rectTransform.sizeDelta.x, 198f);
				}
				else
				{
					this.img_AMRank_LF.rectTransform.sizeDelta = new Vector2(this.img_AMRank_LF.rectTransform.sizeDelta.x, 174f);
				}
				if (this.tmpRank >= 1 && this.tmpRank < 4)
				{
					this.ImgSA_LF.SetSpriteIndex((int)(this.tmpRank - 1));
					this.img_AMRank_LF.gameObject.SetActive(true);
				}
				else
				{
					this.img_AMRank_LF.gameObject.SetActive(false);
				}
			}
			if (this.img_AMRank_RF != null)
			{
				if (this.tmpRank == 1)
				{
					this.img_AMRank_RF.rectTransform.sizeDelta = new Vector2(this.img_AMRank_RF.rectTransform.sizeDelta.x, 218f);
				}
				else if (this.tmpRank == 2)
				{
					this.img_AMRank_RF.rectTransform.sizeDelta = new Vector2(this.img_AMRank_RF.rectTransform.sizeDelta.x, 198f);
				}
				else
				{
					this.img_AMRank_RF.rectTransform.sizeDelta = new Vector2(this.img_AMRank_RF.rectTransform.sizeDelta.x, 174f);
				}
				if (this.tmpRank >= 1 && this.tmpRank < 4)
				{
					this.ImgSA_RF.SetSpriteIndex((int)(this.tmpRank - 1));
					this.img_AMRank_RF.gameObject.SetActive(true);
				}
				else
				{
					this.img_AMRank_RF.gameObject.SetActive(false);
				}
			}
			if (this.text_Translation != null)
			{
				this.text_Translation.color = new Color(0.5255f, 0.447f, 0.255f);
			}
		}
	}

	// Token: 0x06001031 RID: 4145 RVA: 0x001CDDB0 File Offset: 0x001CBFB0
	private void Update()
	{
		if (this.bOpen)
		{
			this.DM.SendAlliancePublicInfo(this.DM.AllianceView.Id, this.DM.AllianceView.Tag, 0);
			this.bOpen = false;
		}
		if (this.DM.bTranslate_AA_P)
		{
			this.GUIM.UpdateUI(EGUIWindow.UIAlliance_publicinfo, 7, 0);
			this.DM.bTranslate_AA_P = false;
			this.DM.bNeedTranslate_AA_P = false;
		}
		if (this.DM.bTranslate_AA_PFailed)
		{
			this.GUIM.UpdateUI(EGUIWindow.UIAlliance_publicinfo, 8, 0);
			this.DM.bTranslate_AA_PFailed = false;
		}
	}

	// Token: 0x06001032 RID: 4146 RVA: 0x001CDE60 File Offset: 0x001CC060
	public void SetKingdomBtn(float tmpDelta = -1f)
	{
		DataManager instance = DataManager.Instance;
		float num = 0f;
		if (tmpDelta == -1f)
		{
			if (instance.AllianceView.AMRankMainInfoUIShow >= 1 && instance.AllianceView.AMRankMainInfoUIShow <= 4)
			{
				num += 43f;
			}
			if (instance.AllianceView.AWRankMainInfoUIShow >= 2)
			{
				num += 43f;
			}
		}
		else
		{
			num = tmpDelta;
		}
		RectTransform component = this.btn_KHint.gameObject.GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(158f + num, component.anchoredPosition.y);
		this.text_Alliance_K.rectTransform.anchoredPosition = new Vector2(component.anchoredPosition.x + 50f, this.text_Alliance_K.rectTransform.anchoredPosition.y);
		component.sizeDelta = new Vector2(50f + this.text_Alliance_K.preferredWidth + 1f, component.sizeDelta.y);
		if (instance.AllianceView.KingdomID != DataManager.MapDataController.kingdomData.kingdomID)
		{
			this.text_Alliance_K.gameObject.SetActive(true);
			this.btn_KHint.gameObject.SetActive(true);
		}
		else
		{
			this.text_Alliance_K.gameObject.SetActive(false);
			this.btn_KHint.gameObject.SetActive(false);
		}
		if (this.GUIM.IsArabic)
		{
			this.text_Alliance_K.UpdateArabicPos();
		}
	}

	// Token: 0x06001033 RID: 4147 RVA: 0x001CDFF8 File Offset: 0x001CC1F8
	public void CheckShowAMWBtn()
	{
		if (this.AMHint == null)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		float num = 0f;
		if (instance.AllianceView.AMRankMainInfoUIShow >= 1 && instance.AllianceView.AMRankMainInfoUIShow <= 4)
		{
			num += 43f;
			this.AM1.SetSpriteIndex((int)instance.AllianceView.AMRankMainInfoUIShow);
			this.AM1.gameObject.SetActive(true);
		}
		else
		{
			this.AM1.gameObject.SetActive(false);
		}
		if (instance.AllianceView.AWRankMainInfoUIShow >= 2)
		{
			RectTransform rectTransform = (RectTransform)this.AW1.gameObject.transform;
			rectTransform.anchoredPosition = new Vector2(-247f + num, rectTransform.anchoredPosition.y);
			num += 43f;
			byte b = (instance.AllianceView.AWRankMainInfoUIShow - 1) / 5;
			if (b >= 0 && b <= 4)
			{
				this.AW1.SetSpriteIndex((int)b);
			}
			else
			{
				this.AW1.SetSpriteIndex(0);
			}
			if (this.CStrAWRank == null)
			{
				this.CStrAWRank = StringManager.Instance.SpawnString(30);
			}
			StringManager.IntToStr(this.CStrAWRank, (long)instance.AllianceView.AWRankMainInfoUIShow, 1, false);
			this.AWRank1.text = this.CStrAWRank.ToString();
			this.AWRank1.SetAllDirty();
			this.AWRank1.cachedTextGenerator.Invalidate();
			this.AW1.gameObject.SetActive(true);
		}
		else
		{
			this.AW1.gameObject.SetActive(false);
		}
		this.SetKingdomBtn(num);
	}

	// Token: 0x06001034 RID: 4148 RVA: 0x001CE1AC File Offset: 0x001CC3AC
	public void SetAMWHint(bool bshow, Transform BtnT = null)
	{
		if (bshow)
		{
			DataManager instance = DataManager.Instance;
			byte b = 0;
			float num = 330f;
			float num2 = 0f;
			if (instance.AllianceView.AMRankMainInfoUIShow >= 1 && instance.AllianceView.AMRankMainInfoUIShow <= 4)
			{
				this.AM2.SetSpriteIndex((int)instance.AllianceView.AMRankMainInfoUIShow);
				this.AM2.gameObject.SetActive(true);
				if (this.CStrAMHint == null)
				{
					this.CStrAMHint = StringManager.Instance.SpawnString(300);
				}
				this.CStrAMHint.Length = 0;
				if (instance.AllianceView.AMPlaceMainInfoUIShow >= 1 && instance.AllianceView.AMPlaceMainInfoUIShow <= 100)
				{
					this.CStrAMHint.IntToFormat((long)instance.AllianceView.AMPlaceMainInfoUIShow, 1, false);
					this.CStrAMHint.AppendFormat(instance.mStringTable.GetStringByID(16152u));
				}
				else
				{
					this.CStrAMHint.StringToFormat(instance.mStringTable.GetStringByID(1033u - (uint)instance.AllianceView.AMRankMainInfoUIShow));
					this.CStrAMHint.AppendFormat(instance.mStringTable.GetStringByID(16150u));
				}
				this.AMHint.text = this.CStrAMHint.ToString();
				this.AMHint.SetAllDirty();
				this.AMHint.cachedTextGenerator.Invalidate();
				this.AMHint.cachedTextGeneratorForLayout.Invalidate();
				float preferredWidth = this.AMHint.preferredWidth;
				if (preferredWidth > num)
				{
					this.AMHint.rectTransform.sizeDelta = new Vector2(preferredWidth + 1f, this.AMHint.rectTransform.sizeDelta.y);
					num2 = preferredWidth - num;
				}
				b += 1;
			}
			else
			{
				this.AM2.gameObject.SetActive(false);
				this.AMHint.gameObject.SetActive(false);
			}
			RectTransform rectTransform;
			if (instance.AllianceView.AWRankMainInfoUIShow >= 2)
			{
				if (b == 0)
				{
					rectTransform = (RectTransform)this.AW2.transform;
					rectTransform.anchoredPosition = new Vector2(39f, -71f);
					this.AWHint.rectTransform.anchoredPosition = new Vector2(91f, -60.6f);
				}
				byte b2 = (instance.AllianceView.AWRankMainInfoUIShow - 1) / 5;
				if (b2 >= 0 && b2 <= 4)
				{
					this.AW2.SetSpriteIndex((int)b2);
				}
				else
				{
					this.AW2.SetSpriteIndex(0);
				}
				if (this.CStrAWRank == null)
				{
					this.CStrAWRank = StringManager.Instance.SpawnString(30);
				}
				this.CStrAWRank.Length = 0;
				StringManager.IntToStr(this.CStrAWRank, (long)instance.AllianceView.AWRankMainInfoUIShow, 1, false);
				this.AWRank2.text = this.CStrAWRank.ToString();
				this.AWRank2.SetAllDirty();
				this.AWRank2.cachedTextGenerator.Invalidate();
				if (this.CStrAWHint == null)
				{
					this.CStrAWHint = StringManager.Instance.SpawnString(300);
				}
				this.CStrAWHint.Length = 0;
				this.CStrAWHint.IntToFormat((long)instance.AllianceView.AWRankMainInfoUIShow, 1, false);
				this.CStrAWHint.AppendFormat(instance.mStringTable.GetStringByID(16151u));
				this.AWHint.text = this.CStrAWHint.ToString();
				this.AWHint.SetAllDirty();
				this.AWHint.cachedTextGenerator.Invalidate();
				this.AWHint.cachedTextGeneratorForLayout.Invalidate();
				float preferredWidth2 = this.AWHint.preferredWidth;
				if (preferredWidth2 > num)
				{
					this.AWHint.rectTransform.sizeDelta = new Vector2(preferredWidth2 + 1f, this.AWHint.rectTransform.sizeDelta.y);
					float num3 = preferredWidth2 - num;
					if (num3 > num2)
					{
						num2 = num3;
					}
				}
				this.AW2.gameObject.SetActive(true);
				this.AWHint.gameObject.SetActive(true);
				b += 1;
			}
			else
			{
				this.AW2.gameObject.SetActive(false);
				this.AWHint.gameObject.SetActive(false);
			}
			if (num2 != 0f)
			{
				num2 += 15f;
			}
			rectTransform = (RectTransform)this.AMWHintGO.transform;
			float y = 200f;
			if (b == 1)
			{
				y = 144f;
			}
			rectTransform = (RectTransform)this.AMWHintGO.transform;
			rectTransform.sizeDelta = new Vector2(450f + num2, y);
			rectTransform.position = BtnT.position;
			rectTransform.anchoredPosition += new Vector2(-17f, -17f);
			RectTransform component = GUIManager.Instance.m_UICanvas.GetComponent<RectTransform>();
			float x = component.sizeDelta.x;
			if (rectTransform.sizeDelta.x >= x)
			{
				rectTransform.anchoredPosition = new Vector2(0f, -128.3f);
			}
			else if (rectTransform.anchoredPosition.x + rectTransform.sizeDelta.x > x)
			{
				rectTransform.anchoredPosition = new Vector2(x - rectTransform.sizeDelta.x, -128.3f);
			}
		}
		this.AMWHintGO.SetActive(bshow);
	}

	// Token: 0x040034D3 RID: 13523
	private Transform GameT;

	// Token: 0x040034D4 RID: 13524
	private Transform Tmp;

	// Token: 0x040034D5 RID: 13525
	private Transform Tmp1;

	// Token: 0x040034D6 RID: 13526
	private Transform Tmp2;

	// Token: 0x040034D7 RID: 13527
	private Transform BadgeT;

	// Token: 0x040034D8 RID: 13528
	private RectTransform TranslationRT;

	// Token: 0x040034D9 RID: 13529
	private UIButton btn_EXIT;

	// Token: 0x040034DA RID: 13530
	private UIButton btn_Msg;

	// Token: 0x040034DB RID: 13531
	private UIButton btn_Member;

	// Token: 0x040034DC RID: 13532
	private UIButton btn_Data;

	// Token: 0x040034DD RID: 13533
	private UIButton btn_Letter;

	// Token: 0x040034DE RID: 13534
	private UIButton btn_Join;

	// Token: 0x040034DF RID: 13535
	private UIButton btn_InputField;

	// Token: 0x040034E0 RID: 13536
	private UIButton btn_InputField2;

	// Token: 0x040034E1 RID: 13537
	private UIButton btn_Input_OK;

	// Token: 0x040034E2 RID: 13538
	private UIButton btn_Input_C;

	// Token: 0x040034E3 RID: 13539
	private UIButton btn_Input_Edit;

	// Token: 0x040034E4 RID: 13540
	private UIButton btn_KHint;

	// Token: 0x040034E5 RID: 13541
	private UIButton btn_Translation;

	// Token: 0x040034E6 RID: 13542
	private UIRunningText img_text;

	// Token: 0x040034E7 RID: 13543
	private Image tmpImg;

	// Token: 0x040034E8 RID: 13544
	private Image Img_Join;

	// Token: 0x040034E9 RID: 13545
	private Image img_InputBG;

	// Token: 0x040034EA RID: 13546
	private Image img_KHint;

	// Token: 0x040034EB RID: 13547
	private Image Img_Translate;

	// Token: 0x040034EC RID: 13548
	private Image img_Title;

	// Token: 0x040034ED RID: 13549
	private Image img_AMRank_Title;

	// Token: 0x040034EE RID: 13550
	private Image img_AMRank_BG;

	// Token: 0x040034EF RID: 13551
	private Image img_AMRank_TopBG;

	// Token: 0x040034F0 RID: 13552
	private Image img_AMRank_TopBG2;

	// Token: 0x040034F1 RID: 13553
	private Image img_AMRank_Msg;

	// Token: 0x040034F2 RID: 13554
	private Image img_AMRank_Member;

	// Token: 0x040034F3 RID: 13555
	private Image img_AMRank_Data;

	// Token: 0x040034F4 RID: 13556
	private Image img_AMRank_Letter;

	// Token: 0x040034F5 RID: 13557
	private Image img_AMRank_InputBG;

	// Token: 0x040034F6 RID: 13558
	private Image img_AMRank1_F;

	// Token: 0x040034F7 RID: 13559
	private Image img_AMRank_LF;

	// Token: 0x040034F8 RID: 13560
	private Image img_AMRank_RF;

	// Token: 0x040034F9 RID: 13561
	private Image img_AMRankNew_BG;

	// Token: 0x040034FA RID: 13562
	private Image img_AMRankNew_BG2;

	// Token: 0x040034FB RID: 13563
	private UIText text_Alliance_K;

	// Token: 0x040034FC RID: 13564
	private UIText text_AllianceChief;

	// Token: 0x040034FD RID: 13565
	private UIText text_AllianceStrength;

	// Token: 0x040034FE RID: 13566
	private UIText text_AllianceMember;

	// Token: 0x040034FF RID: 13567
	private UIText text_AllianceLanguage;

	// Token: 0x04003500 RID: 13568
	private UIText[] text_Propaganda = new UIText[2];

	// Token: 0x04003501 RID: 13569
	private UIText text_Gife;

	// Token: 0x04003502 RID: 13570
	private UIText text_join;

	// Token: 0x04003503 RID: 13571
	private UIText text_join_btn;

	// Token: 0x04003504 RID: 13572
	private UIText text_AllianceName;

	// Token: 0x04003505 RID: 13573
	private UIText text_InputCheck;

	// Token: 0x04003506 RID: 13574
	private UIText text_Input1;

	// Token: 0x04003507 RID: 13575
	private UIText[] text_tmpStr = new UIText[10];

	// Token: 0x04003508 RID: 13576
	private UIText text_Trans;

	// Token: 0x04003509 RID: 13577
	private UIText text_Translation;

	// Token: 0x0400350A RID: 13578
	private UIText text_Title_AMP;

	// Token: 0x0400350B RID: 13579
	private UIEmojiInput mInput;

	// Token: 0x0400350C RID: 13580
	private CString Cstr_Alliance_K;

	// Token: 0x0400350D RID: 13581
	private CString Cstr_AllianceName;

	// Token: 0x0400350E RID: 13582
	private CString Cstr_AllianceChief;

	// Token: 0x0400350F RID: 13583
	private CString Cstr_AllianceStrength;

	// Token: 0x04003510 RID: 13584
	private CString Cstr_AllianceMember;

	// Token: 0x04003511 RID: 13585
	private CString Cstr_GifeLV;

	// Token: 0x04003512 RID: 13586
	private CString Cstr_AllianceLanguage;

	// Token: 0x04003513 RID: 13587
	private CString Cstr_Null;

	// Token: 0x04003514 RID: 13588
	private CString Cstr_Translation;

	// Token: 0x04003515 RID: 13589
	private StringBuilder tmpString = new StringBuilder();

	// Token: 0x04003516 RID: 13590
	private DataManager DM;

	// Token: 0x04003517 RID: 13591
	private GUIManager GUIM;

	// Token: 0x04003518 RID: 13592
	private UISpritesArray SArray;

	// Token: 0x04003519 RID: 13593
	private Font TTFont;

	// Token: 0x0400351A RID: 13594
	private Door door;

	// Token: 0x0400351B RID: 13595
	private bool bNeedApplication = true;

	// Token: 0x0400351C RID: 13596
	private byte mState;

	// Token: 0x0400351D RID: 13597
	private Color Color_Red = new Color(1f, 0.639f, 0.6039f, 1f);

	// Token: 0x0400351E RID: 13598
	private Color Color_Green = new Color(0.6f, 1f, 0.4f, 1f);

	// Token: 0x0400351F RID: 13599
	private bool bOpen = true;

	// Token: 0x04003520 RID: 13600
	private int mType;

	// Token: 0x04003521 RID: 13601
	private bool bShowTranslate;

	// Token: 0x04003522 RID: 13602
	private UISpritesArray ImgSA_LF;

	// Token: 0x04003523 RID: 13603
	private UISpritesArray ImgSA_RF;

	// Token: 0x04003524 RID: 13604
	private byte tmpRank;

	// Token: 0x04003525 RID: 13605
	private GameObject AMWHintGO;

	// Token: 0x04003526 RID: 13606
	private UISpritesArray AM1;

	// Token: 0x04003527 RID: 13607
	private UISpritesArray AW1;

	// Token: 0x04003528 RID: 13608
	private UISpritesArray AM2;

	// Token: 0x04003529 RID: 13609
	private UISpritesArray AW2;

	// Token: 0x0400352A RID: 13610
	private UIText AWRank1;

	// Token: 0x0400352B RID: 13611
	private UIText AWRank2;

	// Token: 0x0400352C RID: 13612
	private UIText AMHint;

	// Token: 0x0400352D RID: 13613
	private UIText AWHint;

	// Token: 0x0400352E RID: 13614
	private UIText AMWTitle;

	// Token: 0x0400352F RID: 13615
	private CString CStrAWRank;

	// Token: 0x04003530 RID: 13616
	private CString CStrAMHint;

	// Token: 0x04003531 RID: 13617
	private CString CStrAWHint;
}
