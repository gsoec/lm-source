using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002EB RID: 747
public class UIAlliance_Management : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06000F40 RID: 3904 RVA: 0x001AEA80 File Offset: 0x001ACC80
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		if (this.DM.RoleAlliance.Id == 0u)
		{
			this.door.CloseMenu(false);
			return;
		}
		this.Cstr_Limit = StringManager.Instance.SpawnString(30);
		this.Cstr_CDTime = StringManager.Instance.SpawnString(30);
		this.m_Mat = this.door.LoadMaterial();
		this.m_FMat = this.GUIM.GetFrameMaterial();
		this.RankLv = (int)this.DM.RoleAlliance.Rank;
		this.text_tmpStr[0] = this.GameT.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(458u);
		this.btn_I = this.GameT.GetChild(0).GetChild(1).GetChild(1).GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_I.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_I.m_Handler = this;
		this.btn_I.m_BtnID1 = 14;
		this.btn_I.m_EffectType = e_EffectType.e_Scale;
		this.btn_I.transition = Selectable.Transition.None;
		this.text_tmpStr[1] = this.GameT.GetChild(1).GetChild(3).GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(459u);
		this.btn_Publicinfo = this.GameT.GetChild(1).GetChild(0).GetComponent<UIButton>();
		this.btn_Publicinfo.m_Handler = this;
		this.btn_Publicinfo.m_BtnID1 = 1;
		this.btn_Publicinfo.m_EffectType = e_EffectType.e_Scale;
		this.btn_Publicinfo.transition = Selectable.Transition.None;
		this.text_tmpStr[2] = this.GameT.GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[2].font = this.TTFont;
		this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(460u);
		this.btn_AlliancEXIT = this.GameT.GetChild(1).GetChild(1).GetComponent<UIButton>();
		this.btn_AlliancEXIT.m_Handler = this;
		this.btn_AlliancEXIT.m_BtnID1 = 2;
		this.btn_AlliancEXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_AlliancEXIT.transition = Selectable.Transition.None;
		this.text_tmpStr[3] = this.GameT.GetChild(1).GetChild(1).GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[3].font = this.TTFont;
		this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(463u);
		this.btn_Recruit = this.GameT.GetChild(1).GetChild(2).GetComponent<UIButton>();
		this.btn_Recruit.m_Handler = this;
		this.btn_Recruit.m_BtnID1 = 3;
		this.btn_Recruit.m_EffectType = e_EffectType.e_Scale;
		this.btn_Recruit.transition = Selectable.Transition.None;
		this.text_Recruit = this.GameT.GetChild(1).GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_Recruit.font = this.TTFont;
		if (this.DM.RoleAlliance.Approval == 0)
		{
			this.CheckRecruit(true);
		}
		else
		{
			this.CheckRecruit(false);
		}
		this.text_tmpStr[4] = this.GameT.GetChild(1).GetChild(2).GetChild(2).GetComponent<UIText>();
		this.text_tmpStr[4].font = this.TTFont;
		this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(532u);
		this.ChangeT = this.GameT.GetChild(2);
		this.text_tmpStr[5] = this.ChangeT.GetChild(8).GetComponent<UIText>();
		this.text_tmpStr[5].font = this.TTFont;
		this.text_tmpStr[5].text = this.DM.mStringTable.GetStringByID(464u);
		for (int i = 0; i < 8; i++)
		{
			this.btn_Change[i] = this.ChangeT.GetChild(i).GetComponent<UIButton>();
			this.btn_Change[i].m_Handler = this;
			this.btn_Change[i].m_BtnID1 = 4 + i;
			this.btn_Change[i].m_EffectType = e_EffectType.e_Scale;
			this.btn_Change[i].transition = Selectable.Transition.None;
			this.text_Change[i] = this.ChangeT.GetChild(i).GetChild(1).GetComponent<UIText>();
			this.text_Change[i].font = this.TTFont;
			if (i == 7)
			{
				this.text_Change[i].text = this.DM.mStringTable.GetStringByID(9567u);
			}
			else
			{
				this.text_Change[i].text = this.DM.mStringTable.GetStringByID((uint)((ushort)(465 + i)));
			}
		}
		this.AdvancedT = this.GameT.GetChild(3);
		this.text_tmpStr[6] = this.AdvancedT.GetChild(2).GetComponent<UIText>();
		this.text_tmpStr[6].font = this.TTFont;
		this.text_tmpStr[6].text = this.DM.mStringTable.GetStringByID(473u);
		this.btn_Abdicate = this.AdvancedT.GetChild(0).GetComponent<UIButton>();
		this.btn_Abdicate.m_Handler = this;
		this.btn_Abdicate.m_BtnID1 = 12;
		this.btn_Abdicate.m_EffectType = e_EffectType.e_Scale;
		this.btn_Abdicate.transition = Selectable.Transition.None;
		this.text_tmpStr[7] = this.AdvancedT.GetChild(0).GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[7].font = this.TTFont;
		this.text_tmpStr[7].text = this.DM.mStringTable.GetStringByID(474u);
		this.btn_Disband = this.AdvancedT.GetChild(1).GetComponent<UIButton>();
		this.btn_Disband.m_Handler = this;
		this.btn_Disband.m_BtnID1 = 13;
		this.btn_Disband.m_EffectType = e_EffectType.e_Scale;
		this.btn_Disband.transition = Selectable.Transition.None;
		this.text_tmpStr[8] = this.AdvancedT.GetChild(1).GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[8].font = this.TTFont;
		this.text_tmpStr[8].text = this.DM.mStringTable.GetStringByID(475u);
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.AppendFormat("UI_main_close_base");
		this.tmpImg = this.GameT.GetChild(4).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite(cstring);
		this.tmpImg.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(4).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		cstring.ClearString();
		cstring.AppendFormat("UI_main_close");
		this.btn_EXIT.image.sprite = this.door.LoadSprite(cstring);
		this.btn_EXIT.image.material = this.m_Mat;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.SloganT = this.GameT.GetChild(5);
		this.tmpImg = this.SloganT.GetComponent<Image>();
		cstring.ClearString();
		cstring.AppendFormat("UI_main_black");
		this.tmpImg.sprite = this.door.LoadSprite(cstring);
		this.tmpImg.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.tmpImg.rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.tmpImg = this.SloganT.GetChild(0).GetComponent<Image>();
		cstring.ClearString();
		cstring.AppendFormat("UI_main_box_009");
		this.tmpImg.sprite = this.door.LoadSprite(cstring);
		this.tmpImg.material = this.m_Mat;
		this.tmpImg = this.SloganT.GetChild(1).GetComponent<Image>();
		cstring.ClearString();
		cstring.AppendFormat("UI_con_title_orange");
		this.tmpImg.sprite = this.door.LoadSprite(cstring);
		this.tmpImg.material = this.m_Mat;
		this.tmpImg = this.SloganT.GetChild(2).GetComponent<Image>();
		cstring.ClearString();
		cstring.AppendFormat("UI_con_title_blue_01");
		this.tmpImg.sprite = this.door.LoadSprite(cstring);
		this.tmpImg.material = this.m_Mat;
		this.text_tmpStr[9] = this.SloganT.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[9].font = this.TTFont;
		this.text_tmpStr[9].text = this.DM.mStringTable.GetStringByID(456u);
		this.tmpImg = this.SloganT.GetChild(3).GetComponent<Image>();
		cstring.ClearString();
		cstring.AppendFormat("UI_main_strip_05");
		this.tmpImg.sprite = this.door.LoadSprite(cstring);
		this.tmpImg.material = this.m_Mat;
		this.mInput = this.SloganT.GetChild(3).GetComponent<UIEmojiInput>();
		this.mInput.textComponent.font = this.TTFont;
		this.mInput.textComponent.fontSize = 24;
		this.text_Input1 = (this.mInput.placeholder as UIText);
		this.text_Input1.font = this.TTFont;
		this.text_Input1.text = this.DM.mStringTable.GetStringByID(455u);
		if (this.DM.RoleAlliance.Header.Length != 0)
		{
			this.mInput.text = this.DM.RoleAlliance.Header;
		}
		this.mInput.shouldHideMobileInput = false;
		this.text_Slogan = this.SloganT.GetChild(3).GetChild(1).GetComponent<UIText>();
		this.text_Slogan.font = this.TTFont;
		this.mInput.onValueChange.AddListener(delegate(string id)
		{
			this.ChangText(id);
		});
		this.mInput.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
		this.btn_SloganEXIT = this.SloganT.GetChild(4).GetComponent<UIButton>();
		this.btn_SloganEXIT.m_Handler = this;
		this.btn_SloganEXIT.m_BtnID1 = 15;
		this.btn_SloganEXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_SloganEXIT.transition = Selectable.Transition.None;
		cstring.ClearString();
		cstring.AppendFormat("UI_main_close");
		this.btn_SloganEXIT.image.sprite = this.door.LoadSprite(cstring);
		this.btn_SloganEXIT.image.material = this.m_Mat;
		this.btn_OK = this.SloganT.GetChild(5).GetComponent<UIButton>();
		this.btn_OK.m_Handler = this;
		this.btn_OK.m_BtnID1 = 16;
		this.btn_OK.m_EffectType = e_EffectType.e_Scale;
		this.btn_OK.transition = Selectable.Transition.None;
		cstring.ClearString();
		cstring.AppendFormat("UI_main_but_y_01");
		this.btn_OK.image.sprite = this.door.LoadSprite(cstring);
		this.btn_OK.image.material = this.m_Mat;
		this.text_tmpStr[10] = this.SloganT.GetChild(5).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[10].font = this.TTFont;
		this.text_tmpStr[10].text = this.DM.mStringTable.GetStringByID(457u);
		this.text_Limit = this.SloganT.GetChild(6).GetComponent<UIText>();
		this.text_Limit.font = this.TTFont;
		this.Cstr_Limit.ClearString();
		this.Cstr_Limit.IntToFormat(20L, 1, false);
		this.Cstr_Limit.AppendFormat(this.DM.mStringTable.GetStringByID(4614u));
		this.text_Limit.text = this.Cstr_Limit.ToString();
		this.text_Limit.SetAllDirty();
		this.text_Limit.cachedTextGenerator.Invalidate();
		this.text_tmpStr[11] = this.SloganT.GetChild(7).GetComponent<UIText>();
		this.text_tmpStr[11].font = this.TTFont;
		this.text_tmpStr[11].text = this.DM.mStringTable.GetStringByID(451u);
		this.DisbandT = this.GameT.GetChild(6);
		this.tmpImg = this.DisbandT.GetComponent<Image>();
		this.tmpImg.color = new Color(1f, 1f, 1f, 0.647f);
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.tmpImg.rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.tmpImg = this.DisbandT.GetChild(0).GetComponent<Image>();
		cstring.ClearString();
		cstring.AppendFormat("UI_main_box_007");
		this.tmpImg.sprite = this.GUIM.LoadFrameSprite(cstring);
		this.tmpImg.material = this.m_FMat;
		this.tmpImg = this.DisbandT.GetChild(0).GetChild(0).GetComponent<Image>();
		cstring.ClearString();
		cstring.AppendFormat("UI_main_title_01");
		this.tmpImg.sprite = this.GUIM.LoadFrameSprite(cstring);
		this.tmpImg.material = this.m_FMat;
		this.text_tmpStr[12] = this.DisbandT.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[12].font = this.TTFont;
		this.text_tmpStr[12].text = this.DM.mStringTable.GetStringByID(508u);
		this.btn_DisbandCancel = this.DisbandT.GetChild(0).GetChild(2).GetComponent<UIButton>();
		this.btn_DisbandCancel.m_Handler = this;
		this.btn_DisbandCancel.m_BtnID1 = 19;
		this.btn_DisbandCancel.m_EffectType = e_EffectType.e_Scale;
		this.btn_DisbandCancel.transition = Selectable.Transition.None;
		this.text_tmpStr[13] = this.DisbandT.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[13].font = this.TTFont;
		this.text_tmpStr[13].text = this.DM.mStringTable.GetStringByID(513u);
		this.btn_DisbandOK = this.DisbandT.GetChild(0).GetChild(3).GetComponent<UIButton>();
		this.btn_DisbandOK.m_Handler = this;
		this.btn_DisbandOK.m_BtnID1 = 18;
		this.btn_DisbandOK.m_EffectType = e_EffectType.e_Scale;
		this.btn_DisbandOK.transition = Selectable.Transition.None;
		this.btn_DisbandOK.enabled = false;
		this.text_tmpStr[14] = this.DisbandT.GetChild(0).GetChild(3).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[14].font = this.TTFont;
		this.text_tmpStr[14].text = this.DM.mStringTable.GetStringByID(475u);
		this.text_tmpStr[15] = this.DisbandT.GetChild(0).GetChild(4).GetComponent<UIText>();
		this.text_tmpStr[15].font = this.TTFont;
		this.text_tmpStr[15].text = this.DM.mStringTable.GetStringByID(9656u);
		this.text_tmpStr[16] = this.DisbandT.GetChild(0).GetChild(5).GetComponent<UIText>();
		this.text_tmpStr[16].font = this.TTFont;
		this.btn_DisbandEXIT = this.DisbandT.GetChild(1).GetComponent<UIButton>();
		this.btn_DisbandEXIT.m_Handler = this;
		this.btn_DisbandEXIT.m_BtnID1 = 17;
		this.btn_DisbandEXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_DisbandEXIT.transition = Selectable.Transition.None;
		cstring.ClearString();
		cstring.AppendFormat("UI_main_close");
		this.btn_DisbandEXIT.image.sprite = this.door.LoadSprite(cstring);
		this.btn_DisbandEXIT.image.material = this.m_Mat;
		this.CheckRankShow(this.RankLv);
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06000F41 RID: 3905 RVA: 0x001AFCD0 File Offset: 0x001ADED0
	public override void OnClose()
	{
		if (this.Cstr_Limit != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Limit);
		}
		if (this.Cstr_CDTime != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_CDTime);
		}
	}

	// Token: 0x06000F42 RID: 3906 RVA: 0x001AFD18 File Offset: 0x001ADF18
	public void CheckRecruit(bool bpublic)
	{
		this.bPublicRecruit = bpublic;
		if (this.bPublicRecruit)
		{
			this.text_Recruit.text = this.DM.mStringTable.GetStringByID(462u);
			this.text_Recruit.color = this.Color_G;
		}
		else
		{
			this.text_Recruit.text = this.DM.mStringTable.GetStringByID(461u);
			this.text_Recruit.color = this.Color_R;
		}
	}

	// Token: 0x06000F43 RID: 3907 RVA: 0x001AFDA0 File Offset: 0x001ADFA0
	public void CheckRankShow(int mRank)
	{
		this.btn_Recruit.gameObject.SetActive(false);
		this.AdvancedT.gameObject.SetActive(false);
		switch (mRank)
		{
		case 1:
		case 2:
		case 3:
			this.btn_AlliancEXIT.gameObject.SetActive(true);
			this.ChangeT.gameObject.SetActive(false);
			this.SloganT.transform.SetParent(this.GameT, false);
			this.SloganT.transform.SetSiblingIndex(5);
			this.SloganT.gameObject.SetActive(false);
			if (this.DisbandT != null && this.DisbandT.gameObject.activeSelf)
			{
				this.SetDisbandShow(false);
			}
			break;
		case 4:
			this.btn_AlliancEXIT.gameObject.SetActive(true);
			this.ChangeT.gameObject.SetActive(true);
			for (int i = 0; i < 3; i++)
			{
				this.btn_Change[i].gameObject.SetActive(true);
			}
			for (int j = 3; j < 8; j++)
			{
				this.btn_Change[j].gameObject.SetActive(false);
			}
			if (this.DisbandT != null && this.DisbandT.gameObject.activeSelf)
			{
				this.SetDisbandShow(false);
			}
			break;
		case 5:
			this.ChangeT.gameObject.SetActive(true);
			for (int k = 0; k < 8; k++)
			{
				this.btn_Change[k].gameObject.SetActive(true);
			}
			this.btn_Recruit.gameObject.SetActive(true);
			this.AdvancedT.gameObject.SetActive(true);
			this.btn_AlliancEXIT.gameObject.SetActive(false);
			break;
		}
	}

	// Token: 0x06000F44 RID: 3908 RVA: 0x001AFF8C File Offset: 0x001AE18C
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
			this.DM.AllianceView.Id = this.DM.RoleAlliance.Id;
			this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 0, 0, false);
			break;
		case 2:
			if (MobilizationManager.Instance.mMissionID != 0 && MobilizationManager.Instance.mMissionStatus == 0)
			{
				this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(505u), this.DM.mStringTable.GetStringByID(16091u), 8, 0, this.DM.mStringTable.GetStringByID(3u), this.DM.mStringTable.GetStringByID(4773u));
			}
			else
			{
				this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(505u), this.DM.mStringTable.GetStringByID(506u), 4, 0, this.DM.mStringTable.GetStringByID(507u), this.DM.mStringTable.GetStringByID(4773u));
			}
			break;
		case 3:
			if (GUIManager.Instance.ShowUILock(EUILock.Alliance_Manage))
			{
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_NEEDAPPLY;
				messagePacket.AddSeqId();
				byte data = 0;
				if (this.bPublicRecruit)
				{
					data = 1;
				}
				messagePacket.Add(data);
				messagePacket.Send(false);
			}
			break;
		case 4:
			this.SloganT.transform.SetParent(this.GUIM.m_SecWindowLayer, false);
			this.SloganT.gameObject.SetActive(true);
			break;
		case 5:
			this.door.CloseMenu(false);
			this.GUIM.UpdateUI(EGUIWindow.UI_Alliance_Info, 2, 0);
			break;
		case 6:
			this.DM.AllianceView.Id = this.DM.RoleAlliance.Id;
			this.DM.AllianceView.Language = this.DM.RoleAlliance.Language;
			this.DM.AllianceView.Tag = this.DM.RoleAlliance.Tag.ToString();
			this.DM.AllianceView.Name = this.DM.RoleAlliance.Name.ToString();
			this.DM.AllianceView.Notice = this.DM.RoleAlliance.Notice;
			this.DM.AllianceView.Header = this.DM.RoleAlliance.Header;
			this.DM.AllianceView.Leader = this.DM.RoleAlliance.Leader.ToString();
			this.DM.AllianceView.Power = this.DM.RoleAlliance.Power;
			this.DM.AllianceView.Emblem = this.DM.RoleAlliance.Emblem;
			this.DM.AllianceView.Member = this.DM.RoleAlliance.Member;
			this.DM.AllianceView.Approval = this.DM.RoleAlliance.Approval;
			this.DM.AllianceView.GiftLv = this.DM.RoleAlliance.GiftLv;
			this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 0, 0, false);
			this.GUIM.UpdateUI(EGUIWindow.UIAlliance_publicinfo, 5, 0);
			break;
		case 7:
			this.DM.CurSelectLanguage = this.DM.RoleAlliance.Language;
			this.door.OpenMenu(EGUIWindow.UI_LanguageSelect, 1, 0, false);
			break;
		case 8:
			this.GUIM.UseOrSpend(1007, this.DM.mStringTable.GetStringByID(4957u), 0, 0, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
			break;
		case 9:
			this.GUIM.UseOrSpend(1120, this.DM.mStringTable.GetStringByID(4957u), 0, 0, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
			break;
		case 10:
			this.DM.CurSelectBadge = this.DM.RoleAlliance.Emblem;
			this.door.OpenMenu(EGUIWindow.UIAlliance_Badge, 100, 0, false);
			break;
		case 11:
		{
			if (ActivityManager.Instance.IsInKvK(0, false))
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9571u), 255, true);
				return;
			}
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			if (this.DM.RoleAlliance.KingdomID != DataManager.MapDataController.kingdomData.kingdomID)
			{
				cstring.IntToFormat((long)this.DM.RoleAlliance.KingdomID, 1, false);
				cstring.IntToFormat((long)DataManager.MapDataController.kingdomData.kingdomID, 1, false);
				cstring.AppendFormat(this.DM.mStringTable.GetStringByID(9569u));
				GUIManager.Instance.OpenSpendWindow_Normal(this, this.DM.mStringTable.GetStringByID(9567u), cstring.ToString(), 1000, 6, 0, this.DM.mStringTable.GetStringByID(9146u), false);
			}
			else
			{
				cstring.IntToFormat((long)DataManager.MapDataController.kingdomData.kingdomID, 1, false);
				cstring.AppendFormat(this.DM.mStringTable.GetStringByID(9570u));
				GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(9567u), cstring.ToString(), this.DM.mStringTable.GetStringByID(3u), null, 0, 0, false, false, false, false, false);
			}
			break;
		}
		case 12:
			if (DataManager.MapDataController.IsKing())
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9366u), 255, true);
			}
			else if (this.CheckWonderID())
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9369u), 255, true);
			}
			else
			{
				this.door.OpenMenu(EGUIWindow.UI_Alliance_List, 2, 0, false);
			}
			break;
		case 13:
			if (DataManager.MapDataController.IsKing())
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9366u), 255, true);
			}
			else if (this.CheckWonderID())
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9369u), 255, true);
			}
			else
			{
				this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(520u), this.DM.mStringTable.GetStringByID(521u), 1, 0, this.DM.mStringTable.GetStringByID(522u), this.DM.mStringTable.GetStringByID(4773u));
			}
			break;
		case 14:
			this.door.OpenMenu(EGUIWindow.UI_Alliance_Permission, 0, 0, false);
			break;
		case 15:
			this.SloganT.transform.SetParent(this.GameT, false);
			this.SloganT.transform.SetSiblingIndex(5);
			this.SloganT.gameObject.SetActive(false);
			break;
		case 16:
		{
			if (!GUIManager.Instance.ShowUILock(EUILock.Alliance_Manage) || this.DM.RoleAlliance.Rank < AllianceRank.RANK4)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4753u), 255, true);
				return;
			}
			char[] array = this.text_Slogan.text.ToCharArray();
			if (this.DM.m_BannedWord != null)
			{
				this.DM.m_BannedWord.CheckBannedWord(array);
			}
			byte[] bytes = Encoding.UTF8.GetBytes(array, 0, this.text_Slogan.text.Length);
			MessagePacket messagePacket2 = new MessagePacket(1024);
			messagePacket2.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_SLOGAN;
			messagePacket2.AddSeqId();
			messagePacket2.Add((byte)bytes.Length);
			messagePacket2.Add(bytes, 0, 20);
			messagePacket2.Send(false);
			break;
		}
		case 17:
		case 19:
			this.SetDisbandShow(false);
			this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9649u), 255, true);
			break;
		case 18:
			if (this.btn_DisbandOK.image.sprite == this.SArray.m_Sprites[0] && this.DM.mAllianceDisband == 0)
			{
				byte data2 = 2;
				if (GUIManager.Instance.ShowUILock(EUILock.Alliance_Manage))
				{
					MessagePacket messagePacket3 = new MessagePacket(1024);
					messagePacket3.Protocol = Protocol._MSG_REQUEST_ALLIANCE_QUIT;
					messagePacket3.AddSeqId();
					messagePacket3.Add(data2);
					messagePacket3.Send(false);
				}
			}
			break;
		}
	}

	// Token: 0x06000F45 RID: 3909 RVA: 0x001B0924 File Offset: 0x001AEB24
	public bool CheckWonderID()
	{
		bool result = false;
		for (int i = 0; i < this.DM.m_Wonders.Count; i++)
		{
			if (this.DM.m_Wonders[i].WonderID == 0)
			{
				result = true;
				break;
			}
		}
		return result;
	}

	// Token: 0x06000F46 RID: 3910 RVA: 0x001B097C File Offset: 0x001AEB7C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			switch (arg1)
			{
			case 1:
				this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(523u), this.DM.mStringTable.GetStringByID(527u), 2, 0, null, null);
				break;
			case 2:
				this.SetDisbandShow(true);
				break;
			case 3:
			{
				byte data = 1;
				if (GUIManager.Instance.ShowUILock(EUILock.Alliance_Manage))
				{
					MessagePacket messagePacket = new MessagePacket(1024);
					messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_QUIT;
					messagePacket.AddSeqId();
					messagePacket.Add(data);
					messagePacket.Send(false);
				}
				break;
			}
			case 4:
				this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(508u), this.DM.mStringTable.GetStringByID(509u), 3, 0, null, null);
				break;
			case 6:
				if (this.DM.RoleAttr.Diamond >= 1000u)
				{
					GUIManager.Instance.ShowUILock(EUILock.AllianceChangHomeKingdom);
					MessagePacket messagePacket2 = new MessagePacket(1024);
					messagePacket2.Protocol = Protocol._MSG_REQUEST_ALLIANCE_CHANGE_HOMEKINGDOM;
					messagePacket2.AddSeqId();
					messagePacket2.Send(false);
				}
				else
				{
					this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966u), this.DM.mStringTable.GetStringByID(646u), this.DM.mStringTable.GetStringByID(3968u), this, 7, 0, true, false, false, false, false);
				}
				break;
			case 7:
				MallManager.Instance.Send_Mall_Info();
				break;
			case 8:
				this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(505u), this.DM.mStringTable.GetStringByID(506u), 4, 0, this.DM.mStringTable.GetStringByID(507u), this.DM.mStringTable.GetStringByID(4773u));
				break;
			}
		}
	}

	// Token: 0x06000F47 RID: 3911 RVA: 0x001B0BA8 File Offset: 0x001AEDA8
	public void SetDisbandShow(bool bshow = true)
	{
		if (bshow)
		{
			this.DM.mAllianceDisband = 60;
			this.Cstr_CDTime.ClearString();
			this.Cstr_CDTime.IntToFormat(1L, 2, true);
			this.Cstr_CDTime.IntToFormat(0L, 2, true);
			this.Cstr_CDTime.AppendFormat(this.DM.mStringTable.GetStringByID(9650u));
			this.text_tmpStr[16].text = this.Cstr_CDTime.ToString();
			this.text_tmpStr[16].SetAllDirty();
			this.text_tmpStr[16].cachedTextGenerator.Invalidate();
			this.btn_DisbandOK.image.sprite = this.SArray.m_Sprites[1];
			this.DisbandT.transform.SetParent(this.GUIM.m_SecWindowLayer, false);
			this.DisbandT.gameObject.SetActive(true);
			this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		}
		else
		{
			this.DisbandT.transform.SetParent(this.GameT, false);
			this.DisbandT.transform.SetSiblingIndex(6);
			this.DisbandT.gameObject.SetActive(false);
			this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		}
	}

	// Token: 0x06000F48 RID: 3912 RVA: 0x001B0CF0 File Offset: 0x001AEEF0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			if (this.DM.RoleAlliance.Id == 0u)
			{
				if (this.SloganT != null && this.SloganT.gameObject.activeSelf)
				{
					this.SloganT.transform.SetParent(this.GameT, false);
					this.SloganT.transform.SetSiblingIndex(5);
					this.SloganT.gameObject.SetActive(false);
				}
				if (this.DisbandT != null && this.DisbandT.gameObject.activeSelf)
				{
					this.SetDisbandShow(false);
				}
				this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_Management);
				return;
			}
			this.CheckRankShow(this.RankLv);
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
				if (this.DM.RoleAlliance.Id == 0u)
				{
					if (this.SloganT != null && this.SloganT.gameObject.activeSelf)
					{
						this.SloganT.transform.SetParent(this.GameT, false);
						this.SloganT.transform.SetSiblingIndex(5);
						this.SloganT.gameObject.SetActive(false);
					}
					if (this.DisbandT != null && this.DisbandT.gameObject.activeSelf)
					{
						this.SetDisbandShow(false);
					}
					this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_Management);
					return;
				}
				this.CheckRankShow((int)this.DM.RoleAlliance.Rank);
			}
			break;
		}
	}

	// Token: 0x06000F49 RID: 3913 RVA: 0x001B0EC0 File Offset: 0x001AF0C0
	public void Refresh_FontTexture()
	{
		if (this.text_Recruit != null && this.text_Recruit.enabled)
		{
			this.text_Recruit.enabled = false;
			this.text_Recruit.enabled = true;
		}
		if (this.text_Slogan != null && this.text_Slogan.enabled)
		{
			this.text_Slogan.enabled = false;
			this.text_Slogan.enabled = true;
		}
		if (this.text_Limit != null && this.text_Limit.enabled)
		{
			this.text_Limit.enabled = false;
			this.text_Limit.enabled = true;
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
		for (int i = 0; i < 8; i++)
		{
			if (this.text_Change[i] != null && this.text_Change[i].enabled)
			{
				this.text_Change[i].enabled = false;
				this.text_Change[i].enabled = true;
			}
		}
		for (int j = 0; j < 17; j++)
		{
			if (this.text_tmpStr[j] != null && this.text_tmpStr[j].enabled)
			{
				this.text_tmpStr[j].enabled = false;
				this.text_tmpStr[j].enabled = true;
			}
		}
	}

	// Token: 0x06000F4A RID: 3914 RVA: 0x001B10A0 File Offset: 0x001AF2A0
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			this.CheckRankShow(this.RankLv);
			break;
		case 2:
		{
			bool bpublic = false;
			if (this.DM.RoleAlliance.Approval == 0)
			{
				bpublic = true;
			}
			this.CheckRecruit(bpublic);
			break;
		}
		case 3:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 4:
			this.SloganT.transform.SetParent(this.GameT, false);
			this.SloganT.transform.SetSiblingIndex(5);
			this.SloganT.gameObject.SetActive(false);
			break;
		}
	}

	// Token: 0x06000F4B RID: 3915 RVA: 0x001B1164 File Offset: 0x001AF364
	public void ChangText(string ID)
	{
		int byteCount = Encoding.UTF8.GetByteCount(ID);
		this.Cstr_Limit.ClearString();
		this.Cstr_Limit.IntToFormat((long)(20 - byteCount), 1, false);
		this.Cstr_Limit.AppendFormat(this.DM.mStringTable.GetStringByID(4614u));
		this.text_Limit.text = this.Cstr_Limit.ToString();
		this.text_Limit.SetAllDirty();
		this.text_Limit.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000F4C RID: 3916 RVA: 0x001B11EC File Offset: 0x001AF3EC
	protected char OnValidateInput(string text, int index, char check)
	{
		return (check < ' ' || check > '~') ? '\0' : check;
	}

	// Token: 0x06000F4D RID: 3917 RVA: 0x001B1208 File Offset: 0x001AF408
	public override bool OnBackButtonClick()
	{
		if (this.SloganT.gameObject.activeSelf)
		{
			this.SloganT.transform.SetParent(this.GameT, false);
			this.SloganT.transform.SetSiblingIndex(5);
			this.SloganT.gameObject.SetActive(false);
			return false;
		}
		if (this.DisbandT != null && this.DisbandT.gameObject.activeSelf)
		{
			this.SetDisbandShow(false);
			this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9649u), 255, true);
			return true;
		}
		return false;
	}

	// Token: 0x06000F4E RID: 3918 RVA: 0x001B12BC File Offset: 0x001AF4BC
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond && this.DisbandT != null && this.DisbandT.gameObject.activeSelf)
		{
			if (this.DM.mAllianceDisband > 0)
			{
				DataManager dm = this.DM;
				dm.mAllianceDisband -= 1;
			}
			if (this.DM.mAllianceDisband == 0 && this.btn_DisbandOK.image.sprite != this.SArray.m_Sprites[0])
			{
				this.btn_DisbandOK.enabled = true;
				this.btn_DisbandOK.image.sprite = this.SArray.m_Sprites[0];
			}
			this.Cstr_CDTime.ClearString();
			this.Cstr_CDTime.IntToFormat(0L, 2, true);
			this.Cstr_CDTime.IntToFormat((long)this.DM.mAllianceDisband, 2, true);
			this.Cstr_CDTime.AppendFormat(this.DM.mStringTable.GetStringByID(9650u));
			this.text_tmpStr[16].text = this.Cstr_CDTime.ToString();
			this.text_tmpStr[16].SetAllDirty();
			this.text_tmpStr[16].cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06000F4F RID: 3919 RVA: 0x001B140C File Offset: 0x001AF60C
	private void Start()
	{
	}

	// Token: 0x06000F50 RID: 3920 RVA: 0x001B1410 File Offset: 0x001AF610
	private void Update()
	{
	}

	// Token: 0x04003278 RID: 12920
	private Transform GameT;

	// Token: 0x04003279 RID: 12921
	private Transform ChangeT;

	// Token: 0x0400327A RID: 12922
	private Transform AdvancedT;

	// Token: 0x0400327B RID: 12923
	private Transform SloganT;

	// Token: 0x0400327C RID: 12924
	private Transform DisbandT;

	// Token: 0x0400327D RID: 12925
	private UIButton btn_EXIT;

	// Token: 0x0400327E RID: 12926
	private UIButton btn_Publicinfo;

	// Token: 0x0400327F RID: 12927
	private UIButton btn_AlliancEXIT;

	// Token: 0x04003280 RID: 12928
	private UIButton btn_Recruit;

	// Token: 0x04003281 RID: 12929
	private UIButton btn_Abdicate;

	// Token: 0x04003282 RID: 12930
	private UIButton btn_Disband;

	// Token: 0x04003283 RID: 12931
	private UIButton btn_I;

	// Token: 0x04003284 RID: 12932
	private UIButton[] btn_Change = new UIButton[8];

	// Token: 0x04003285 RID: 12933
	private UIButton btn_SloganEXIT;

	// Token: 0x04003286 RID: 12934
	private UIButton btn_OK;

	// Token: 0x04003287 RID: 12935
	private UIButton btn_DisbandEXIT;

	// Token: 0x04003288 RID: 12936
	private UIButton btn_DisbandOK;

	// Token: 0x04003289 RID: 12937
	private UIButton btn_DisbandCancel;

	// Token: 0x0400328A RID: 12938
	private Image tmpImg;

	// Token: 0x0400328B RID: 12939
	private UIText text_Recruit;

	// Token: 0x0400328C RID: 12940
	private UIText text_Slogan;

	// Token: 0x0400328D RID: 12941
	private UIText text_Limit;

	// Token: 0x0400328E RID: 12942
	private UIText[] text_Change = new UIText[8];

	// Token: 0x0400328F RID: 12943
	private UIText[] text_tmpStr = new UIText[17];

	// Token: 0x04003290 RID: 12944
	private CString Cstr_Limit;

	// Token: 0x04003291 RID: 12945
	private CString Cstr_CDTime;

	// Token: 0x04003292 RID: 12946
	private UIEmojiInput mInput;

	// Token: 0x04003293 RID: 12947
	private UIText text_Input1;

	// Token: 0x04003294 RID: 12948
	private DataManager DM;

	// Token: 0x04003295 RID: 12949
	private GUIManager GUIM;

	// Token: 0x04003296 RID: 12950
	private Font TTFont;

	// Token: 0x04003297 RID: 12951
	private Door door;

	// Token: 0x04003298 RID: 12952
	private int RankLv;

	// Token: 0x04003299 RID: 12953
	private bool bPublicRecruit = true;

	// Token: 0x0400329A RID: 12954
	private Color Color_R = new Color(1f, 0.4f, 0.4f, 1f);

	// Token: 0x0400329B RID: 12955
	private Color Color_G = new Color(0.6f, 1f, 0.4f, 1f);

	// Token: 0x0400329C RID: 12956
	private Material m_Mat;

	// Token: 0x0400329D RID: 12957
	private Material m_FMat;

	// Token: 0x0400329E RID: 12958
	private UISpritesArray SArray;
}
