using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002E1 RID: 737
public class UIAlliance_Info : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06000EF5 RID: 3829 RVA: 0x0019BCE8 File Offset: 0x00199EE8
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		if (this.DM.RoleAlliance.Id == 0u)
		{
			this.door.CloseMenu(false);
			return;
		}
		this.ResetEffectText();
		this.FrameMaterial = this.GUIM.GetFrameMaterial();
		this.Cstr_Alliance_K = StringManager.Instance.SpawnString(30);
		this.Cstr_AllianceName = StringManager.Instance.SpawnString(30);
		this.Cstr_AllianceChief = StringManager.Instance.SpawnString(30);
		this.Cstr_AllianceStrength = StringManager.Instance.SpawnString(30);
		this.Cstr_AllianceMember = StringManager.Instance.SpawnString(30);
		this.Cstr_GifeLV = StringManager.Instance.SpawnString(30);
		this.Cstr_Alliance_Money = StringManager.Instance.SpawnString(30);
		this.Cstr_Null = StringManager.Instance.SpawnString(30);
		this.Cstr_Translation = StringManager.Instance.SpawnString(100);
		for (int i = 0; i < 6; i++)
		{
			this.Cstr_Item_K[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_Item_Time[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_ItemEffect[i] = new CString[4];
			for (int j = 0; j < 4; j++)
			{
				this.Cstr_ItemEffect[i][j] = StringManager.Instance.SpawnString(100);
			}
		}
		this.img_BG = this.GameT.GetChild(0).GetComponent<Image>();
		this.img_AMRank_BG = this.GameT.GetChild(0).GetChild(0).GetComponent<Image>();
		this.img_AMRank_BG2 = this.GameT.GetChild(0).GetChild(1).GetComponent<Image>();
		this.PageT = this.GameT.GetChild(1);
		for (int k = 0; k < 3; k++)
		{
			this.Tmp = this.GameT.GetChild(2 + k);
			this.btnPage[k] = this.Tmp.GetComponent<UIButton>();
			this.btnPage[k].m_Handler = this;
			this.btnPage[k].m_BtnID1 = 1 + k;
			this.Tmp = this.GameT.GetChild(2 + k).GetChild(0);
			this.img_PageBG[k] = this.Tmp.GetComponent<Image>();
			this.Tmp = this.GameT.GetChild(2 + k).GetChild(1);
			this.tmpImg = this.GameT.GetChild(2 + k).GetChild(2).GetComponent<Image>();
			this.PageImg_RT[k] = this.GameT.GetChild(2 + k).GetChild(2).GetComponent<RectTransform>();
			this.tmpImg.sprite = this.door.LoadSprite("UI_main_redbox_01");
			this.tmpImg.material = this.door.LoadMaterial();
			this.Tmp = this.GameT.GetChild(2 + k).GetChild(2).GetChild(0);
			this.PageText_RT[k] = this.Tmp.GetComponent<RectTransform>();
			this.text_PageNum[k] = this.Tmp.GetComponent<UIText>();
			this.text_PageNum[k].font = this.TTFont;
			this.PageImg_RT[k].gameObject.SetActive(false);
		}
		int num = (int)this.DM.RoleAlliance.GiftNum;
		long num2 = this.DM.RoleAlliance.ChatMax - this.DM.RoleAlliance.ChatId;
		if (num2 > 0L)
		{
			num += ((num2 <= 20L) ? ((int)num2) : 20);
		}
		if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
		{
			num += (int)this.DM.RoleAlliance.Applicant;
		}
		if (ActivityGiftManager.Instance.ActivityGiftBeginTime - ActivityManager.Instance.ServerEventTime < 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && ActivityGiftManager.Instance.EnableRedPocketNum > 0)
		{
			num += (int)ActivityGiftManager.Instance.EnableRedPocketNum;
		}
		if (num > 0)
		{
			this.text_PageNum[0].text = num.ToString();
			this.PageImg_RT[0].gameObject.SetActive(true);
			this.PageImg_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[0].preferredWidth), this.PageImg_RT[0].sizeDelta.y);
		}
		num = (int)(this.DM.ActiveRallyRecNum + this.DM.BeingRallyRecNum);
		if (num > 0)
		{
			this.text_PageNum[1].text = num.ToString();
			this.text_PageNum[1].SetAllDirty();
			this.text_PageNum[1].cachedTextGenerator.Invalidate();
			this.text_PageNum[1].cachedTextGeneratorForLayout.Invalidate();
			this.PageImg_RT[1].gameObject.SetActive(true);
			this.PageImg_RT[1].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[1].preferredWidth), this.PageImg_RT[1].sizeDelta.y);
		}
		if (this.DM.mHelpDataList.Count > 0)
		{
			this.text_PageNum[2].text = this.DM.mHelpDataList.Count.ToString();
			this.PageImg_RT[2].gameObject.SetActive(true);
			this.PageImg_RT[2].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[2].preferredWidth), this.PageImg_RT[2].sizeDelta.y);
		}
		this.Tmp = this.GameT.GetChild(6);
		this.img_Title = this.Tmp.GetComponent<Image>();
		this.Tmp = this.GameT.GetChild(6).GetChild(0);
		this.text_Title = this.Tmp.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.Tmp1 = this.GameT.GetChild(7);
		this.btn_ActivityGift = this.Tmp1.GetComponent<UIButton>();
		this.GUIM.SetFastivalImage(ActivityGiftManager.Instance.GroupID, 4, this.btn_ActivityGift.image);
		this.btn_ActivityGift.image.SetNativeSize();
		this.btn_ActivityGift.image.type = Image.Type.Simple;
		this.btn_ActivityGift.m_Handler = this;
		this.btn_ActivityGift.m_BtnID1 = 30;
		this.btn_ActivityGift.m_EffectType = e_EffectType.e_Scale;
		this.btn_ActivityGift.transition = Selectable.Transition.None;
		this.img_ActivityGift[0] = this.Tmp1.GetChild(0).GetComponent<Image>();
		this.img_ActivityGift[1] = this.Tmp1.GetChild(0).GetChild(0).GetComponent<Image>();
		this.img_ActivityGift[0].gameObject.SetActive(true);
		this.img_ActivityGift[1].gameObject.SetActive(true);
		this.img_ActivityGift[0].rectTransform.anchoredPosition = new Vector2(27f, 7f);
		this.img_ActivityGift[1].sprite = this.door.LoadSprite("UI_main_mess_ex_dark");
		this.img_ActivityGift[1].material = this.door.LoadMaterial();
		this.tmpImg = this.Tmp1.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_mess_ex_light");
		this.tmpImg.material = this.door.LoadMaterial();
		this.m_text_ActivityGiftNum = this.Tmp1.GetChild(0).GetChild(1).GetComponent<UIText>();
		this.m_text_ActivityGiftNum.font = this.TTFont;
		this.m_text_ActivityGiftNum.text = ActivityGiftManager.Instance.EnableRedPocketNum.ToString();
		this.m_text_ActivityGiftNum.SetAllDirty();
		this.m_text_ActivityGiftNum.cachedTextGenerator.Invalidate();
		this.img_ActivityGift[0].rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_text_ActivityGiftNum.preferredWidth), this.img_ActivityGift[0].rectTransform.sizeDelta.y);
		if (arg1 == 0)
		{
			arg1 = (int)this.DM.mOpenPage;
		}
		if (arg1 >= 0 && arg1 <= 2)
		{
			this.SetPage(arg1);
		}
		this.Tmp = this.GameT.GetChild(5);
		this.img_InputBG = this.Tmp.GetComponent<Image>();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.img_InputBG.rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.img_InputBG.rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.btn_Input_Edit = this.Tmp.GetChild(0).GetComponent<UIButton>();
		this.btn_Input_Edit.m_Handler = this;
		this.btn_Input_Edit.m_BtnID1 = 23;
		this.text_InputCheck = this.Tmp.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_InputCheck.font = this.TTFont;
		this.text_InputCheck.SetCheckArabic(true);
		this.btn_Input_OK = this.Tmp.GetChild(2).GetComponent<UIButton>();
		this.btn_Input_OK.m_Handler = this;
		this.btn_Input_OK.m_BtnID1 = 21;
		this.btn_Input_OK.m_EffectType = e_EffectType.e_Scale;
		this.btn_Input_OK.transition = Selectable.Transition.None;
		this.text_tmpStr[0] = this.Tmp.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(512u);
		this.btn_Input_C = this.Tmp.GetChild(3).GetComponent<UIButton>();
		this.btn_Input_C.m_Handler = this;
		this.btn_Input_C.m_BtnID1 = 22;
		this.btn_Input_C.m_EffectType = e_EffectType.e_Scale;
		this.btn_Input_C.transition = Selectable.Transition.None;
		this.text_tmpStr[1] = this.Tmp.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(513u);
		this.text_tmpStr[2] = this.Tmp.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[2].font = this.TTFont;
		this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(774u);
		this.Tmp = this.GameT.GetChild(6).GetChild(0);
		this.text_Title = this.Tmp.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.tmpImg = this.GameT.GetChild(8).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
		this.tmpImg.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(8).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.door.LoadMaterial();
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
		this.bOpenEnd = true;
	}

	// Token: 0x06000EF6 RID: 3830 RVA: 0x0019C970 File Offset: 0x0019AB70
	public void ResetEffectText()
	{
		for (int i = 0; i < 7; i++)
		{
			this.mWonderEffect[i] = -1;
		}
		for (int j = 0; j < this.DM.m_Wonders.Count; j++)
		{
			if (this.DM.m_Wonders[j].WonderID >= 0 && this.DM.m_Wonders[j].WonderID < 7 && this.mWonderEffect[(int)this.DM.m_Wonders[j].WonderID] == -1)
			{
				this.mWonderEffect[(int)this.DM.m_Wonders[j].WonderID] = (int)((byte)j);
			}
		}
	}

	// Token: 0x06000EF7 RID: 3831 RVA: 0x0019CA44 File Offset: 0x0019AC44
	public void ChangText(string ID)
	{
		this.text_InputCheck.text = ID;
		this.text_InputCheck.SetAllDirty();
		this.text_InputCheck.cachedTextGenerator.Invalidate();
		this.text_InputCheck.cachedTextGeneratorForLayout.Invalidate();
		this.mInput.text = StringManager.InputTemp;
		this.mInput.text = ID;
		this.OpenInputCheck(true);
		this.bcheckInput = true;
	}

	// Token: 0x06000EF8 RID: 3832 RVA: 0x0019CAB4 File Offset: 0x0019ACB4
	protected char OnValidateInput(string text, int index, char check)
	{
		int num = Encoding.UTF8.GetByteCount(text) + Encoding.UTF8.GetByteCount(check.ToString());
		if (num > 480)
		{
			return '\0';
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.Append(text);
		cstring.Append(check.ToString());
		this.text_InputCheck.text = cstring.ToString();
		this.text_InputCheck.SetAllDirty();
		this.text_InputCheck.cachedTextGenerator.Invalidate();
		this.text_InputCheck.cachedTextGeneratorForLayout.Invalidate();
		if (this.text_InputCheck.preferredHeight > 156f)
		{
			return '\0';
		}
		return check;
	}

	// Token: 0x06000EF9 RID: 3833 RVA: 0x0019CB60 File Offset: 0x0019AD60
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
		if (this.Cstr_Alliance_Money != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Alliance_Money);
		}
		if (this.Cstr_Null != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Null);
		}
		if (this.Cstr_Translation != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Translation);
		}
		for (int i = 0; i < 6; i++)
		{
			if (this.Cstr_Item_K[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Item_K[i]);
			}
			if (this.Cstr_Item_Time[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Item_Time[i]);
			}
			if (this.Cstr_ItemEffect[i] != null)
			{
				for (int j = 0; j < 4; j++)
				{
					if (this.Cstr_ItemEffect[i][j] != null)
					{
						StringManager.Instance.DeSpawnString(this.Cstr_ItemEffect[i][j]);
					}
				}
			}
		}
		if (this.MarshalInst != null)
		{
			this.MarshalInst.OnClose();
		}
		if (this.Pagedata[0] != null)
		{
			this.DM.mAllianceInfoScroll_Y = this.mContentRT.anchoredPosition.y;
			this.DM.mAllianceInfoScroll_Idx = this.m_ScrollPanel.GetTopIdx();
			if (this.mInput != null)
			{
				this.mInput.onEndEdit.RemoveAllListeners();
			}
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
		if (this.AMWHintGO != null && this.Pagedata[0] != null)
		{
			this.AMWHintGO.transform.SetParent(this.Pagedata[0], false);
		}
	}

	// Token: 0x06000EFA RID: 3834 RVA: 0x0019CE10 File Offset: 0x0019B010
	public void SetPage(int nowpage)
	{
		if (nowpage != this.mNowPage)
		{
			this.mNowPage = nowpage;
			this.DM.mOpenPage = (byte)nowpage;
			if (this.Pagedata[this.mNowPage] == null)
			{
				this.LoadPageData();
			}
			for (int i = 0; i < 3; i++)
			{
				this.btnPage[i].image.sprite = this.SArray.m_Sprites[1];
				if (this.Pagedata[i])
				{
					this.Pagedata[i].gameObject.SetActive(false);
				}
				this.img_PageBG[i].color = new Color(1f, 1f, 1f, 0f);
			}
			this.img_PageBG[nowpage].color = new Color(1f, 1f, 1f, 1f);
			if (this.Pagedata[nowpage])
			{
				this.Pagedata[nowpage].gameObject.SetActive(true);
			}
			if (this.mNowPage == 0)
			{
				this.text_Title.text = this.DM.mStringTable.GetStringByID(4624u);
			}
			else if (this.mNowPage == 1)
			{
				this.text_Title.text = this.DM.mStringTable.GetStringByID(768u);
			}
			else
			{
				this.text_Title.text = this.DM.mStringTable.GetStringByID(765u);
			}
			this.CheckGiftBtnShow();
			if (this.bOpenCheck)
			{
				this.CheckAMPlaceMainInfo();
				if (this.img_Title != null)
				{
					if ((this.mNowPage == 0 && this.tmpRank == 0) || this.mNowPage != 0)
					{
						this.img_Title.gameObject.SetActive(true);
					}
					else
					{
						this.img_Title.gameObject.SetActive(false);
					}
				}
			}
		}
	}

	// Token: 0x06000EFB RID: 3835 RVA: 0x0019D014 File Offset: 0x0019B214
	public void LoadPageData()
	{
		switch (this.mNowPage)
		{
		case 0:
		{
			this.go = (GameObject)UnityEngine.Object.Instantiate(this.m_AssetBundle.Load("UIAlliance_Info_P1"));
			this.Pagedata[0] = this.go.GetComponent<Transform>();
			this.Pagedata[0].SetParent(this.PageT, false);
			this.Tmp = this.Pagedata[0].GetChild(0);
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
			this.img_AMRankNew_BG = this.Tmp1.GetComponent<Image>();
			this.img_AMRank_LF = this.Tmp1.GetChild(1).GetComponent<Image>();
			this.ImgSA_LF = this.Tmp1.GetChild(1).GetComponent<UISpritesArray>();
			this.img_AMRank_RF = this.Tmp1.GetChild(2).GetComponent<Image>();
			this.ImgSA_RF = this.Tmp1.GetChild(2).GetComponent<UISpritesArray>();
			this.img_AMRank1_F = this.Tmp1.GetChild(3).GetComponent<Image>();
			this.img_AMRank_Title = this.Tmp1.GetChild(4).GetComponent<Image>();
			this.text_Title_AMP = this.Tmp1.GetChild(4).GetChild(0).GetComponent<UIText>();
			this.text_Title_AMP.font = this.TTFont;
			this.text_Title_AMP.text = this.DM.mStringTable.GetStringByID(4624u);
			this.BadgeT = this.Tmp.GetChild(2);
			this.GUIM.InitBadgeTotem(this.BadgeT, this.DM.RoleAlliance.Emblem);
			this.Tmp1 = this.Tmp.GetChild(3).GetChild(0);
			this.text_Propaganda = this.Tmp1.GetComponent<UIText>();
			RectTransform component = this.Tmp1.GetComponent<RectTransform>();
			this.text_Propaganda.font = this.TTFont;
			this.text_Propaganda.text = this.DM.RoleAlliance.Header;
			this.Tmp1 = this.Tmp.GetChild(3).GetChild(1);
			this.tmptext = this.Tmp1.GetComponent<UIText>();
			RectTransform component2 = this.Tmp1.GetComponent<RectTransform>();
			this.tmptext.font = this.TTFont;
			this.tmptext.text = this.DM.RoleAlliance.Header;
			this.Tmp1 = this.Tmp.GetChild(3);
			this.img_text = this.Tmp1.GetComponent<UIRunningText>();
			if (this.GUIM.IsArabic)
			{
				this.img_text.tmpLength = 562f;
			}
			else
			{
				this.img_text.tmpLength = 281f;
			}
			this.img_text.m_RunningText1 = this.text_Propaganda;
			this.img_text.m_RunRT1 = this.text_Propaganda.rectTransform;
			this.img_text.m_RunningText2 = this.tmptext;
			this.img_text.m_RunRT2 = this.tmptext.rectTransform;
			if (this.text_Propaganda.preferredWidth > 281f)
			{
				component.sizeDelta = new Vector2(this.text_Propaganda.preferredWidth, component.sizeDelta.y);
				if (this.GUIM.IsArabic)
				{
					this.text_Propaganda.UpdateArabicPos();
				}
				component2.anchoredPosition = new Vector2(this.text_Propaganda.preferredWidth, component2.anchoredPosition.y);
				component2.sizeDelta = new Vector2(this.text_Propaganda.preferredWidth, component2.sizeDelta.y);
				if (this.GUIM.IsArabic)
				{
					this.tmptext.UpdateArabicPos();
				}
				this.img_text.tmpLength = this.text_Propaganda.preferredWidth;
			}
			if (this.DM.RoleAlliance.Header.Length == 0)
			{
				this.img_text.gameObject.SetActive(false);
			}
			else
			{
				this.img_text.gameObject.SetActive(true);
			}
			this.Tmp1 = this.Tmp.GetChild(4).GetChild(0);
			this.text_AllianceChief = this.Tmp1.GetComponent<UIText>();
			this.text_AllianceChief.font = this.TTFont;
			this.Cstr_AllianceChief.ClearString();
			this.Cstr_AllianceChief.StringToFormat(this.DM.RoleAlliance.Leader);
			this.Cstr_AllianceChief.AppendFormat(this.DM.mStringTable.GetStringByID(4625u));
			this.text_AllianceChief.text = this.Cstr_AllianceChief.ToString();
			this.Tmp1 = this.Tmp.GetChild(5).GetChild(0);
			this.text_AllianceStrength = this.Tmp1.GetComponent<UIText>();
			this.text_AllianceStrength.font = this.TTFont;
			this.Cstr_AllianceStrength.ClearString();
			this.Cstr_AllianceStrength.uLongToFormat(this.DM.RoleAlliance.Power, 1, true);
			this.Cstr_AllianceStrength.AppendFormat(this.DM.mStringTable.GetStringByID(4626u));
			this.text_AllianceStrength.text = this.Cstr_AllianceStrength.ToString();
			this.Tmp1 = this.Tmp.GetChild(6).GetChild(0);
			this.text_AllianceMember = this.Tmp1.GetComponent<UIText>();
			this.text_AllianceMember.font = this.TTFont;
			this.Cstr_AllianceMember.ClearString();
			this.Cstr_AllianceMember.IntToFormat((long)this.DM.RoleAlliance.Member, 1, false);
			this.Cstr_AllianceMember.AppendFormat(this.DM.mStringTable.GetStringByID(4627u));
			this.text_AllianceMember.text = this.Cstr_AllianceMember.ToString();
			this.Tmp1 = this.Tmp.GetChild(7);
			this.btn_Letter = this.Tmp1.GetComponent<UIButton>();
			this.btn_Letter.m_Handler = this;
			this.btn_Letter.m_BtnID1 = 10;
			this.btn_Letter.m_EffectType = e_EffectType.e_Scale;
			this.btn_Letter.transition = Selectable.Transition.None;
			this.img_AMRank_Letter = this.Tmp1.GetChild(1).GetComponent<Image>();
			this.Tmp1 = this.Tmp.GetChild(7).GetChild(3);
			this.text_tmpStr[3] = this.Tmp1.GetComponent<UIText>();
			this.text_tmpStr[3].font = this.TTFont;
			this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(4637u);
			this.Tmp1 = this.Tmp.GetChild(7).GetChild(2);
			this.btnMessageNum_RT[0] = this.Tmp1.GetComponent<RectTransform>();
			this.tmpImg = this.Tmp1.GetComponent<Image>();
			this.tmpImg.sprite = this.door.LoadSprite("UI_main_redbox_01");
			this.tmpImg.material = this.door.LoadMaterial();
			this.btnMessageNum_RT[1] = this.Tmp1.GetChild(0).GetComponent<RectTransform>();
			this.text_MessageNum = this.Tmp1.GetChild(0).GetComponent<UIText>();
			this.text_MessageNum.font = this.TTFont;
			long num = this.DM.RoleAlliance.ChatMax - this.DM.RoleAlliance.ChatId;
			if (num > 0L)
			{
				num = (long)((num <= 20L) ? ((int)num) : 20);
				this.text_MessageNum.text = num.ToString();
				this.text_MessageNum.SetAllDirty();
				this.text_MessageNum.cachedTextGenerator.Invalidate();
				this.text_MessageNum.cachedTextGeneratorForLayout.Invalidate();
				this.btnMessageNum_RT[0].gameObject.SetActive(true);
				this.btnMessageNum_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_MessageNum.preferredWidth), this.btnMessageNum_RT[0].sizeDelta.y);
			}
			else
			{
				this.btnMessageNum_RT[0].gameObject.SetActive(false);
			}
			this.Tmp1 = this.Tmp.GetChild(8);
			this.btn_Member = this.Tmp1.GetComponent<UIButton>();
			this.btn_Member.m_Handler = this;
			this.btn_Member.m_BtnID1 = 5;
			this.btn_Member.m_EffectType = e_EffectType.e_Scale;
			this.btn_Member.transition = Selectable.Transition.None;
			this.img_AMRank_Member = this.Tmp1.GetChild(1).GetComponent<Image>();
			this.Tmp1 = this.Tmp.GetChild(8).GetChild(2);
			this.text_tmpStr[4] = this.Tmp1.GetComponent<UIText>();
			this.text_tmpStr[4].font = this.TTFont;
			this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(4629u);
			this.Tmp1 = this.Tmp.GetChild(9);
			this.btn_Application = this.Tmp1.GetComponent<UIButton>();
			this.btn_Application.m_Handler = this;
			this.btn_Application.m_BtnID1 = 6;
			this.btn_Application.m_EffectType = e_EffectType.e_Scale;
			this.btn_Application.transition = Selectable.Transition.None;
			this.img_AMRank_Application = this.Tmp1.GetChild(1).GetComponent<Image>();
			this.Tmp1 = this.Tmp.GetChild(9).GetChild(2);
			this.tmpImg = this.Tmp1.GetComponent<Image>();
			this.btnApplicationNum_RT[0] = this.Tmp1.GetComponent<RectTransform>();
			this.tmpImg.sprite = this.door.LoadSprite("UI_main_redbox_01");
			this.tmpImg.material = this.door.LoadMaterial();
			this.btnApplicationNum_RT[1] = this.Tmp1.GetChild(0).GetComponent<RectTransform>();
			this.text_btnApplicationNum = this.Tmp1.GetChild(0).GetComponent<UIText>();
			this.text_btnApplicationNum.font = this.TTFont;
			this.text_btnApplicationNum.text = this.DM.RoleAlliance.Applicant.ToString();
			if (this.DM.RoleAlliance.Applicant > 0 && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
			{
				this.btnApplicationNum_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_btnApplicationNum.preferredWidth), this.btnApplicationNum_RT[0].sizeDelta.y);
			}
			else
			{
				this.btnApplicationNum_RT[0].gameObject.SetActive(false);
			}
			this.Tmp1 = this.Tmp.GetChild(9).GetChild(3);
			this.text_tmpStr[5] = this.Tmp1.GetComponent<UIText>();
			this.text_tmpStr[5].font = this.TTFont;
			this.text_tmpStr[5].text = this.DM.mStringTable.GetStringByID(4630u);
			this.Tmp1 = this.Tmp.GetChild(10);
			this.btn_Gift = this.Tmp1.GetComponent<UIButton>();
			this.btn_Gift.m_Handler = this;
			this.btn_Gift.m_BtnID1 = 7;
			this.btn_Gift.m_EffectType = e_EffectType.e_Scale;
			this.btn_Gift.transition = Selectable.Transition.None;
			this.img_AMRank_Gift = this.Tmp1.GetChild(1).GetComponent<Image>();
			this.Tmp1 = this.Tmp.GetChild(10).GetChild(2);
			this.tmpImg = this.Tmp1.GetComponent<Image>();
			this.tmpImg.sprite = this.door.LoadSprite("UI_main_redbox_01");
			this.tmpImg.material = this.door.LoadMaterial();
			this.btnGiftNum_RT[0] = this.Tmp1.GetComponent<RectTransform>();
			this.btnGiftNum_RT[1] = this.Tmp1.GetChild(0).GetComponent<RectTransform>();
			this.text_btnGife[0] = this.Tmp1.GetChild(0).GetComponent<UIText>();
			this.text_btnGife[0].font = this.TTFont;
			this.text_btnGife[0].text = this.DM.RoleAlliance.GiftNum.ToString();
			if (this.DM.RoleAlliance.GiftNum > 0)
			{
				this.btnGiftNum_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_btnGife[0].preferredWidth), this.btnGiftNum_RT[0].sizeDelta.y);
			}
			else
			{
				this.btnGiftNum_RT[0].gameObject.SetActive(false);
			}
			this.Tmp1 = this.Tmp.GetChild(10).GetChild(3);
			this.text_btnGife[1] = this.Tmp1.GetComponent<UIText>();
			this.text_btnGife[1].font = this.TTFont;
			this.Cstr_GifeLV.ClearString();
			this.Cstr_GifeLV.IntToFormat((long)this.DM.RoleAlliance.GiftLv, 1, false);
			this.Cstr_GifeLV.AppendFormat(this.DM.mStringTable.GetStringByID(4631u));
			this.text_btnGife[1].text = this.Cstr_GifeLV.ToString();
			this.Tmp1 = this.Tmp.GetChild(11);
			this.btn_KHint = this.Tmp1.GetComponent<UIButton>();
			this.btn_KHint.m_Handler = this;
			this.btn_KHint.m_BtnID1 = 28;
			UIButtonHint uibuttonHint = this.btn_KHint.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			this.img_KHint = this.Tmp.GetChild(14).GetComponent<Image>();
			uibuttonHint.ControlFadeOut = this.img_KHint.gameObject;
			uibuttonHint.ScrollID = 1;
			this.text_tmpItmeStr[9] = this.Tmp.GetChild(14).GetChild(0).GetComponent<UIText>();
			this.text_tmpItmeStr[9].font = this.TTFont;
			this.text_tmpItmeStr[9].text = this.DM.mStringTable.GetStringByID(9549u);
			this.text_tmpItmeStr[9].cachedTextGeneratorForLayout.Invalidate();
			this.text_tmpItmeStr[9].rectTransform.sizeDelta = new Vector2(this.text_tmpItmeStr[9].preferredWidth, this.text_tmpItmeStr[9].rectTransform.sizeDelta.y);
			if (this.GUIM.IsArabic)
			{
				this.text_tmpItmeStr[9].UpdateArabicPos();
			}
			this.text_tmpItmeStr[10] = this.Tmp.GetChild(14).GetChild(1).GetComponent<UIText>();
			this.text_tmpItmeStr[10].font = this.TTFont;
			this.text_tmpItmeStr[10].text = this.DM.mStringTable.GetStringByID(9550u);
			this.text_tmpItmeStr[10].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_tmpItmeStr[10].preferredWidth > this.text_tmpItmeStr[10].rectTransform.sizeDelta.x)
			{
				this.img_KHint.rectTransform.sizeDelta = new Vector2(this.text_tmpItmeStr[10].preferredWidth + 12f, this.img_KHint.rectTransform.sizeDelta.y);
				this.text_tmpItmeStr[10].rectTransform.sizeDelta = new Vector2(this.text_tmpItmeStr[10].preferredWidth, this.text_tmpItmeStr[10].rectTransform.sizeDelta.y);
				if (this.GUIM.IsArabic)
				{
					this.text_tmpItmeStr[10].UpdateArabicPos();
				}
			}
			this.Tmp1 = this.Tmp.GetChild(12);
			this.text_AllianceName = this.Tmp1.GetComponent<UIText>();
			this.text_AllianceName.font = this.TTFont;
			this.Cstr_AllianceName.ClearString();
			GameConstants.FormatRoleName(this.Cstr_AllianceName, this.DM.RoleAlliance.Name, this.DM.RoleAlliance.Tag, null, 0, 0, null, null, null, null);
			this.text_AllianceName.text = this.Cstr_AllianceName.ToString();
			this.Tmp1 = this.Tmp.GetChild(13);
			this.text_Alliance_K = this.Tmp1.GetComponent<UIText>();
			this.text_Alliance_K.font = this.TTFont;
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
			this.text_Alliance_K.cachedTextGeneratorForLayout.Invalidate();
			this.text_Alliance_K.rectTransform.sizeDelta = new Vector2(this.text_Alliance_K.preferredWidth + 1f, this.text_Alliance_K.rectTransform.sizeDelta.y);
			if (this.DM.RoleAlliance.KingdomID != DataManager.MapDataController.kingdomData.kingdomID)
			{
				this.text_Alliance_K.gameObject.SetActive(true);
				this.btn_KHint.gameObject.SetActive(true);
			}
			else
			{
				this.text_Alliance_K.gameObject.SetActive(false);
				this.btn_KHint.gameObject.SetActive(false);
			}
			this.Tmp1 = this.Pagedata[0].GetChild(1);
			this.m_ScrollPanel = this.Tmp1.GetComponent<ScrollPanel>();
			this.Tmp1 = this.Pagedata[0].GetChild(2);
			this.Tmp2 = this.Tmp1.GetChild(0);
			this.text_tmpItmeStr[0] = this.Tmp2.GetChild(2).GetChild(0).GetComponent<UIText>();
			this.text_tmpItmeStr[0].font = this.TTFont;
			this.text_tmpItmeStr[1] = this.Tmp2.GetChild(3).GetChild(0).GetComponent<UIText>();
			this.text_tmpItmeStr[1].font = this.TTFont;
			this.tmpImg = this.Tmp2.GetChild(5).GetChild(0).GetComponent<Image>();
			this.tmpImg.material = this.GUIM.m_WonderMaterial;
			RectTransform rectTransform = this.tmpImg.rectTransform;
			rectTransform.anchorMin = new Vector2(0.0703125f, 0.0703125f);
			rectTransform.anchorMax = new Vector2(0.9296875f, 0.9296875f);
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
			if (this.GUIM.IsArabic)
			{
				this.tmpImg.gameObject.AddComponent<ArabicItemTextureRot>();
			}
			this.tmpImg = this.Tmp2.GetChild(5).GetChild(1).GetComponent<Image>();
			this.tmpImg.sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, 11);
			this.tmpImg.material = this.FrameMaterial;
			rectTransform = this.tmpImg.rectTransform.GetComponent<RectTransform>();
			rectTransform.anchorMin = Vector2.zero;
			rectTransform.anchorMax = new Vector2(1f, 1f);
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;
			UIButton component3 = this.Tmp2.GetChild(6).GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = 25;
			this.text_tmpItmeStr[2] = this.Tmp2.GetChild(7).GetChild(0).GetComponent<UIText>();
			this.text_tmpItmeStr[2].font = this.TTFont;
			for (int i = 0; i < 5; i++)
			{
				this.text_tmpItmeStr[3 + i] = this.Tmp2.GetChild(8).GetChild(i).GetComponent<UIText>();
				this.text_tmpItmeStr[3 + i].font = this.TTFont;
			}
			component3 = this.Tmp2.GetChild(9).GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = 27;
			uibuttonHint = component3.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			this.tmpImg = this.Tmp2.GetChild(10).GetComponent<Image>();
			uibuttonHint.ControlFadeOut = this.tmpImg.gameObject;
			this.text_tmpItmeStr[8] = this.Tmp2.GetChild(10).GetChild(0).GetComponent<UIText>();
			this.text_tmpItmeStr[8].font = this.TTFont;
			this.Tmp2 = this.Tmp1.GetChild(1);
			for (int j = 0; j < 5; j++)
			{
				component3 = this.Tmp2.GetChild(j).GetComponent<UIButton>();
				this.btn_RT[j] = component3.GetComponent<RectTransform>();
				this.btn_Pos[j] = new Vector2(this.btn_RT[j].anchoredPosition.x, this.btn_RT[j].anchoredPosition.y);
				component3.m_Handler = this;
				if (j != 2)
				{
					component3.m_BtnID1 = 8 + j;
				}
				else
				{
					component3.m_BtnID1 = 4;
				}
				this.text_tmpItmeP2Str[j * 2] = this.Tmp2.GetChild(j).GetChild(1).GetChild(0).GetComponent<UIText>();
				this.text_tmpItmeP2Str[j * 2].font = this.TTFont;
				this.text_tmpItmeP2Str[j * 2 + 1] = this.Tmp2.GetChild(j).GetChild(2).GetComponent<UIText>();
				this.text_tmpItmeP2Str[j * 2 + 1].font = this.TTFont;
				this.tmpImg = this.Tmp2.GetChild(j).GetChild(1).GetComponent<Image>();
				this.tmpImg.sprite = this.door.LoadSprite("UI_main_redbox_01");
				this.tmpImg.material = this.door.LoadMaterial();
				this.tmpImg.gameObject.SetActive(false);
			}
			this.text_tmpItmeP2Str[10] = this.Tmp2.GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
			this.text_tmpItmeP2Str[10].font = this.TTFont;
			this.text_tmpItmeP2Str[1].text = this.DM.mStringTable.GetStringByID(4635u);
			this.text_tmpItmeP2Str[3].text = this.DM.mStringTable.GetStringByID(4636u);
			this.text_tmpItmeP2Str[5].text = this.DM.mStringTable.GetStringByID(4628u);
			this.text_tmpItmeP2Str[7].text = this.DM.mStringTable.GetStringByID(4639u);
			this.text_tmpItmeP2Str[9].text = this.DM.mStringTable.GetStringByID(4640u);
			for (int k = 0; k < 6; k++)
			{
				this.btn_Fun[k] = new UIButton[5];
				this.text_ItembtnName[k] = new UIText[5];
				this.img_Wonders[k] = new Image[2];
				this.text_ItemName[k] = new UIText[2];
				this.text_ItemEffect[k] = new UIText[4];
			}
			UIEmojiInput component4 = this.Tmp2.GetChild(5).GetChild(1).GetComponent<UIEmojiInput>();
			this.text_tmpItmeP2Str[11] = component4.textComponent;
			this.text_tmpItmeP2Str[11].font = this.TTFont;
			this.text_tmpItmeP2Str[12] = (component4.placeholder as UIText);
			this.text_tmpItmeP2Str[12].font = this.TTFont;
			if (this.DM.RoleAlliance.Bullet != null && this.DM.RoleAlliance.Bullet.Length != 0 && component4 != null)
			{
				component4.text = this.DM.RoleAlliance.Bullet;
			}
			else if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
			{
				this.text_tmpItmeP2Str[12].text = this.DM.mStringTable.GetStringByID(772u);
			}
			else
			{
				this.Cstr_Null.ClearString();
				this.text_tmpItmeP2Str[12].text = this.Cstr_Null.ToString();
				component4.text = this.Cstr_Null.ToString();
			}
			component3 = this.Tmp2.GetChild(5).GetChild(2).GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = 24;
			this.text_tmpItmeP2Str[13] = this.Tmp2.GetChild(5).GetChild(3).GetComponent<UIText>();
			this.text_tmpItmeP2Str[13].font = this.TTFont;
			this.text_tmpItmeP2Str[13].gameObject.SetActive(false);
			this.text_tmpItmeP2Str[13].SetCheckArabic(true);
			this.Tmp2.GetChild(5).GetChild(4).gameObject.SetActive(false);
			component3 = this.Tmp2.GetChild(5).GetChild(4).GetChild(0).GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = 29;
			component3.m_EffectType = e_EffectType.e_Scale;
			component3.transition = Selectable.Transition.None;
			this.text_tmpItmeP2Str[14] = this.Tmp2.GetChild(5).GetChild(4).GetChild(2).GetComponent<UIText>();
			this.text_tmpItmeP2Str[14].font = this.TTFont;
			component3 = this.Tmp2.GetChild(6).GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = 17;
			component3.m_EffectType = e_EffectType.e_Scale;
			component3.transition = Selectable.Transition.None;
			this.tmpHeight = 166f;
			if (!this.bshowbtn1)
			{
				this.btn_RT[0].gameObject.SetActive(false);
				for (int l = 1; l < 5; l++)
				{
					this.btn_RT[l].anchoredPosition = new Vector2(this.btn_Pos[l - 1].x, this.btn_Pos[l - 1].y);
				}
				this.tmpHeight += (this.btn_RT[0].sizeDelta.y + 5f) * 2f;
			}
			else
			{
				this.tmpHeight += (this.btn_RT[0].sizeDelta.y + 5f) * 3f;
			}
			this.tmplist.Clear();
			for (int m = 0; m < this.DM.m_Wonders.Count; m++)
			{
				this.tmplist.Add(93f);
			}
			if (IGGGameSDK.Instance.GetTranslateStatus() && this.text_tmpItmeP2Str[11].preferredHeight > 120f)
			{
				this.tmpTransH = this.text_tmpItmeP2Str[11].preferredHeight - 120f;
				float item = this.tmpHeight + 40f;
				this.tmplist.Add(item);
				for (int n = 0; n < 5; n++)
				{
					if (!this.bshowbtn1 && n > 0)
					{
						this.btn_RT[n].anchoredPosition = new Vector2(this.btn_Pos[n - 1].x, this.btn_Pos[n - 1].y - this.tmpTransH);
					}
				}
			}
			else
			{
				this.tmplist.Add(this.tmpHeight);
			}
			this.m_ScrollPanel.IntiScrollPanel(351f, 0f, 0f, this.tmplist, 6, this);
			this.m_ScrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
			this.mContentRT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
			this.m_ScrollPanel.GoTo(this.DM.mAllianceInfoScroll_Idx, this.DM.mAllianceInfoScroll_Y);
			if (this.tmplist.Count <= 1)
			{
				this.m_ScrollRect.enabled = false;
			}
			UIButtonHint.scrollRect = this.m_ScrollRect;
			component3 = this.Tmp.GetChild(15).GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = 31;
			uibuttonHint = component3.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			this.AM1 = this.Tmp.GetChild(15).GetComponent<UISpritesArray>();
			component3 = this.Tmp.GetChild(16).GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = 31;
			uibuttonHint = component3.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			this.AW1 = this.Tmp.GetChild(16).GetComponent<UISpritesArray>();
			this.AWRank1 = this.Tmp.GetChild(16).GetChild(0).GetComponent<UIText>();
			this.AWRank1.font = this.TTFont;
			this.Tmp1 = this.Pagedata[0].GetChild(3);
			this.Tmp1.SetParent(this.GUIM.m_ItemInfoLayer, false);
			this.AMWHintGO = this.Tmp1.gameObject;
			this.AMWTitle = this.Tmp1.GetChild(0).GetComponent<UIText>();
			this.AMWTitle.font = this.TTFont;
			this.AMWTitle.text = this.DM.mStringTable.GetStringByID(16149u);
			this.AM2 = this.Tmp1.GetChild(2).GetComponent<UISpritesArray>();
			this.AW2 = this.Tmp1.GetChild(3).GetComponent<UISpritesArray>();
			this.AWRank2 = this.Tmp1.GetChild(3).GetChild(0).GetComponent<UIText>();
			this.AWRank2.font = this.TTFont;
			this.AMHint = this.Tmp1.GetChild(4).GetComponent<UIText>();
			this.AMHint.font = this.TTFont;
			this.AWHint = this.Tmp1.GetChild(5).GetComponent<UIText>();
			this.AWHint.font = this.TTFont;
			this.CheckShowAMWBtn();
			break;
		}
		case 1:
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.m_AssetBundle.Load("UIAlliance_Marshal"));
			this.MarshalInst = new UIAlliance_Marshal();
			this.Pagedata[this.mNowPage] = gameObject.transform;
			gameObject.transform.SetParent(this.PageT);
			this.MarshalInst.OnOpen(gameObject.transform);
			this.Pagedata[this.mNowPage].localPosition = Vector3.zero;
			this.Pagedata[this.mNowPage].localScale = Vector3.one;
			Quaternion localRotation = this.Pagedata[this.mNowPage].localRotation;
			localRotation.eulerAngles = Vector3.zero;
			this.Pagedata[this.mNowPage].localRotation = localRotation;
			break;
		}
		case 2:
			this.go = (GameObject)UnityEngine.Object.Instantiate(this.m_AssetBundle.Load("UIAlliance_Help"));
			this.Pagedata[this.mNowPage] = this.go.GetComponent<Transform>();
			this.Pagedata[this.mNowPage].SetParent(this.PageT, false);
			this.Tmp = this.Pagedata[this.mNowPage].GetChild(1);
			this.Tmp1 = this.Tmp.GetChild(0);
			this.btn_Help = this.Tmp1.GetComponent<UIButton>();
			this.btn_Help.m_Handler = this;
			this.btn_Help.m_BtnID1 = 18;
			this.btn_Help.SetButtonEffectType(e_EffectType.e_Scale);
			this.btn_Help.transition = Selectable.Transition.None;
			if (this.GUIM.IsArabic)
			{
				this.Tmp.GetChild(0).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
			}
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(2);
			this.btnHelp_RT = this.Tmp1.GetComponent<RectTransform>();
			this.tmpImg = this.Tmp1.GetComponent<Image>();
			this.tmpImg.sprite = this.door.LoadSprite("UI_main_redbox_01");
			this.tmpImg.material = this.door.LoadMaterial();
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(2).GetChild(0);
			this.text_HelpNum = this.Tmp1.GetComponent<UIText>();
			this.text_HelpNum.font = this.TTFont;
			if (this.DM.mHelpDataList.Count > 0)
			{
				this.text_HelpNum.text = this.DM.mHelpDataList.Count.ToString();
				this.btnHelp_RT.gameObject.SetActive(true);
				this.btnHelp_RT.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_HelpNum.preferredWidth), this.btnHelp_RT.sizeDelta.y);
			}
			this.Tmp1 = this.Tmp.GetChild(1);
			this.btn_Transport = this.Tmp1.GetComponent<UIButton>();
			this.btn_Transport.m_Handler = this;
			this.btn_Transport.m_BtnID1 = 19;
			this.btn_Transport.SetButtonEffectType(e_EffectType.e_Scale);
			this.btn_Transport.transition = Selectable.Transition.None;
			this.Tmp1 = this.Tmp.GetChild(2);
			this.btn_Reinforce = this.Tmp1.GetComponent<UIButton>();
			this.btn_Reinforce.m_Handler = this;
			this.btn_Reinforce.m_BtnID1 = 20;
			this.btn_Reinforce.SetButtonEffectType(e_EffectType.e_Scale);
			this.btn_Reinforce.transition = Selectable.Transition.None;
			this.Tmp1 = this.Tmp.GetChild(3);
			this.btn_Cantonment = this.Tmp1.GetComponent<UIButton>();
			this.btn_Cantonment.m_Handler = this;
			this.btn_Cantonment.m_BtnID1 = 26;
			this.btn_Cantonment.SetButtonEffectType(e_EffectType.e_Scale);
			this.btn_Cantonment.transition = Selectable.Transition.None;
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(1);
			this.text_tmpStr[6] = this.Tmp1.GetComponent<UIText>();
			this.text_tmpStr[6].font = this.TTFont;
			this.text_tmpStr[6].text = this.DM.mStringTable.GetStringByID(750u);
			this.Tmp1 = this.Tmp.GetChild(1).GetChild(1);
			this.text_tmpStr[7] = this.Tmp1.GetComponent<UIText>();
			this.text_tmpStr[7].font = this.TTFont;
			this.text_tmpStr[7].text = this.DM.mStringTable.GetStringByID(766u);
			this.Tmp1 = this.Tmp.GetChild(2).GetChild(1);
			this.text_tmpStr[8] = this.Tmp1.GetComponent<UIText>();
			this.text_tmpStr[8].font = this.TTFont;
			this.text_tmpStr[8].text = this.DM.mStringTable.GetStringByID(767u);
			this.Tmp1 = this.Tmp.GetChild(3).GetChild(1);
			this.text_tmpStr[9] = this.Tmp1.GetComponent<UIText>();
			this.text_tmpStr[9].font = this.TTFont;
			this.text_tmpStr[9].text = this.DM.mStringTable.GetStringByID(9739u);
			break;
		}
	}

	// Token: 0x06000EFC RID: 3836 RVA: 0x0019F4C0 File Offset: 0x0019D6C0
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		this.ItemT = item.GetComponent<Transform>();
		if (this.tmpItem[panelObjectIdx] == null)
		{
			this.tmpItem[panelObjectIdx] = this.ItemT.GetComponent<ScrollPanelItem>();
			this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
			this.ItemPT1[panelObjectIdx] = this.ItemT.GetChild(0);
			this.Img_ItemP1BG[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(0).GetComponent<Image>();
			this.Img_ItemP1BG2[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(1).GetComponent<Image>();
			this.text_Item_K[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(2).GetChild(0).GetComponent<UIText>();
			this.img_Wonders[panelObjectIdx][0] = this.ItemPT1[panelObjectIdx].GetChild(3).GetComponent<Image>();
			this.text_ItemCDtime[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(3).GetChild(0).GetComponent<UIText>();
			this.img_Wonders[panelObjectIdx][1] = this.ItemPT1[panelObjectIdx].GetChild(5).GetChild(0).GetComponent<Image>();
			this.btn_Item[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(6).GetComponent<UIButton>();
			this.btn_Item[panelObjectIdx].m_Handler = this;
			this.ItemPT_W1[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(7);
			this.text_ItemName[panelObjectIdx][0] = this.ItemPT_W1[panelObjectIdx].GetChild(0).GetComponent<UIText>();
			this.ItemPT_W2[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(8);
			this.text_ItemName[panelObjectIdx][1] = this.ItemPT_W2[panelObjectIdx].GetChild(0).GetComponent<UIText>();
			this.btn_ItemHint[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(9).GetComponent<UIButton>();
			this.btn_ItemHint[panelObjectIdx].m_Handler = this;
			this.btn_ItemHint[panelObjectIdx].m_BtnID1 = 27;
			this.btn_ItemHint[panelObjectIdx].m_BtnID2 = panelObjectIdx;
			this.mbtnH_Item[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(9).GetComponent<UIButtonHint>();
			this.mbtnH_Item[panelObjectIdx].m_Handler = this;
			this.img_ItemHint[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(10).GetComponent<Image>();
			this.mbtnH_Item[panelObjectIdx].ControlFadeOut = this.img_ItemHint[panelObjectIdx].gameObject;
			this.text_Item_Hint[panelObjectIdx] = this.ItemPT1[panelObjectIdx].GetChild(10).GetChild(0).GetComponent<UIText>();
			this.text_Item_Hint[panelObjectIdx].alignment = TextAnchor.MiddleLeft;
			for (int i = 0; i < 4; i++)
			{
				this.text_ItemEffect[panelObjectIdx][i] = this.ItemPT_W2[panelObjectIdx].GetChild(1 + i).GetComponent<UIText>();
			}
			this.ItemPT2[panelObjectIdx] = this.ItemT.GetChild(1);
			for (int j = 0; j < 5; j++)
			{
				this.btn_Fun[panelObjectIdx][j] = this.ItemPT2[panelObjectIdx].GetChild(j).GetComponent<UIButton>();
				this.btn_Fun[panelObjectIdx][j].m_Handler = this;
				this.text_ItembtnName[panelObjectIdx][j] = this.ItemPT2[panelObjectIdx].GetChild(j).GetChild(2).GetComponent<UIText>();
			}
			this.Img_ItemInputBG[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetComponent<Image>();
			this.Img_ItemInputBG2[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetChild(0).GetComponent<Image>();
			this.mItemInput[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetChild(1).GetComponent<UIEmojiInput>();
			this.btn_ItemInput[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetChild(2).GetComponent<UIButton>();
			this.btn_ItemInput[panelObjectIdx].m_Handler = this;
			this.text_Trans[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetChild(3).GetComponent<UIText>();
			this.text_Trans[panelObjectIdx].SetCheckArabic(true);
			this.TranslationRT[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetChild(4).GetComponent<RectTransform>();
			this.btn_Translation[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetChild(4).GetChild(0).GetComponent<UIButton>();
			this.btn_Translation[panelObjectIdx].m_Handler = this;
			this.Img_Translate[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetChild(4).GetChild(1).GetComponent<Image>();
			this.text_Translation[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(5).GetChild(4).GetChild(2).GetComponent<UIText>();
			this.btn_InputField[panelObjectIdx] = this.ItemPT2[panelObjectIdx].GetChild(6).GetComponent<UIButton>();
			this.btn_InputField[panelObjectIdx].m_Handler = this;
			this.btn_InputField[panelObjectIdx].m_BtnID2 = panelObjectIdx;
		}
		if (this.tmplist.Count - 1 == dataIdx)
		{
			this.ItemPT1[panelObjectIdx].gameObject.SetActive(false);
			this.ItemPT2[panelObjectIdx].gameObject.SetActive(true);
			this.mInput = this.mItemInput[panelObjectIdx];
			this.mInput.onEndEdit.AddListener(delegate(string id)
			{
				this.ChangText(id);
			});
			this.mInput.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
			this.text_Input1 = (this.mInput.placeholder as UIText);
			this.text_Input1.font = this.TTFont;
			this.text_Trans[panelObjectIdx].text = this.mInput.text;
			this.text_Alliance_Money = this.ItemPT2[panelObjectIdx].GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
			this.Cstr_Alliance_Money.ClearString();
			this.Cstr_Alliance_Money.IntToFormat((long)((ulong)this.DM.RoleAlliance.Money), 1, true);
			this.Cstr_Alliance_Money.AppendFormat("{0}");
			this.text_Alliance_Money.text = this.Cstr_Alliance_Money.ToString();
			this.text_Alliance_Money.SetAllDirty();
			this.text_Alliance_Money.cachedTextGenerator.Invalidate();
			if (this.DM.RoleAlliance.Bullet != null && !this.bcheckInput)
			{
				this.mInput.text = this.DM.RoleAlliance.Bullet;
			}
			if (this.DM.RoleAlliance.Id != 0u && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
			{
				this.mInput.interactable = true;
				this.btn_ItemInput[panelObjectIdx].enabled = true;
				this.btn_InputField[panelObjectIdx].gameObject.SetActive(true);
			}
			else
			{
				this.mInput.DeactivateInputField();
				if (this.mInput.text == string.Empty)
				{
					this.text_Input1.text = string.Empty;
				}
				this.mInput.interactable = false;
				this.btn_ItemInput[panelObjectIdx].enabled = false;
				this.btn_InputField[panelObjectIdx].gameObject.SetActive(false);
				if (this.img_InputBG != null)
				{
					this.OpenInputCheck(false);
					this.bcheckInput = false;
				}
			}
			this.m_TranslationRT = this.TranslationRT[panelObjectIdx];
			this.m_text_Trans = this.text_Trans[panelObjectIdx];
			this.m_btn_Translation = this.btn_Translation[panelObjectIdx];
			this.m_Img_Translate = this.Img_Translate[panelObjectIdx];
			this.m_text_Translation = this.text_Translation[panelObjectIdx];
			if (IGGGameSDK.Instance.GetTranslateStatus())
			{
				if (this.bShowTranslate)
				{
					this.mInput.gameObject.SetActive(false);
					this.m_text_Trans.text = IGGGameSDK.Instance.TranslateStringOut_AA_Info.ToString();
					this.m_text_Trans.resizeTextForBestFit = true;
					this.m_text_Trans.resizeTextMaxSize = 17;
					this.m_text_Trans.gameObject.SetActive(true);
					this.m_text_Trans.cachedTextGeneratorForLayout.Invalidate();
					this.Cstr_Translation.ClearString();
					this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte)this.DM.mAA_Info_L));
					this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054u));
					this.m_text_Translation.text = this.Cstr_Translation.ToString();
				}
				else
				{
					this.mInput.gameObject.SetActive(true);
					this.m_text_Trans.text = this.mInput.text;
					this.m_text_Trans.resizeTextForBestFit = false;
					this.m_text_Trans.cachedTextGeneratorForLayout.Invalidate();
					this.m_text_Trans.gameObject.SetActive(false);
					this.m_text_Translation.text = this.DM.mStringTable.GetStringByID(9052u);
				}
				this.m_btn_Translation.gameObject.SetActive(true);
				this.m_Img_Translate.gameObject.SetActive(false);
				if (this.tmpRank == 0)
				{
					if (this.m_text_Translation != null)
					{
						this.m_text_Translation.color = new Color(0.3765f, 0.455f, 0.5176f);
					}
				}
				else if (this.m_text_Translation != null)
				{
					this.m_text_Translation.color = new Color(0.5255f, 0.447f, 0.255f);
				}
				this.m_text_Translation.SetAllDirty();
				this.m_text_Translation.cachedTextGenerator.Invalidate();
				this.m_text_Translation.cachedTextGeneratorForLayout.Invalidate();
				if (this.m_text_Translation.preferredWidth > this.m_text_Translation.rectTransform.sizeDelta.x)
				{
					this.m_text_Translation.rectTransform.sizeDelta = new Vector2(this.m_text_Translation.preferredWidth + 2f, this.m_text_Translation.rectTransform.sizeDelta.y);
				}
				if (this.GUIM.IsArabic)
				{
					this.m_text_Translation.UpdateArabicPos();
				}
				if (-0.5f - this.m_text_Trans.preferredHeight > -157.5f)
				{
					this.m_TranslationRT.anchoredPosition = new Vector2(this.m_TranslationRT.anchoredPosition.x, -0.5f - this.m_text_Trans.preferredHeight);
				}
				else
				{
					this.m_TranslationRT.anchoredPosition = new Vector2(this.m_TranslationRT.anchoredPosition.x, -157.5f);
				}
				if (this.m_text_Trans.preferredHeight > 120f)
				{
					this.tmpTransH = 40f;
				}
				else
				{
					this.tmpTransH = 0f;
				}
				for (int k = 0; k < 5; k++)
				{
					this.btn_ItemRT[k] = this.btn_Fun[panelObjectIdx][k].transform.GetComponent<RectTransform>();
					if (!this.bshowbtn1 && k > 0)
					{
						this.btn_ItemRT[k].anchoredPosition = new Vector2(this.btn_Pos[k - 1].x, this.btn_Pos[k - 1].y - this.tmpTransH);
					}
					else
					{
						this.btn_ItemRT[k].anchoredPosition = new Vector2(this.btn_Pos[k].x, this.btn_Pos[k].y - this.tmpTransH);
					}
				}
				if (this.DM.RoleAlliance.Bullet != null && this.DM.RoleAlliance.Bullet.Length > 0)
				{
					this.m_TranslationRT.gameObject.SetActive(true);
				}
				else
				{
					this.m_TranslationRT.gameObject.SetActive(false);
				}
			}
		}
		else
		{
			this.ItemPT1[panelObjectIdx].gameObject.SetActive(true);
			if (this.tmpRank == 0)
			{
				if (this.Img_ItemP1BG[panelObjectIdx] != null)
				{
					this.Img_ItemP1BG[panelObjectIdx].gameObject.SetActive(true);
				}
				if (this.Img_ItemP1BG2[panelObjectIdx] != null)
				{
					this.Img_ItemP1BG2[panelObjectIdx].gameObject.SetActive(false);
				}
				if (this.Img_ItemInputBG[panelObjectIdx] != null)
				{
					this.Img_ItemInputBG[panelObjectIdx].color = new Color(1f, 1f, 1f, 1f);
				}
				if (this.Img_ItemInputBG2[panelObjectIdx] != null)
				{
					this.Img_ItemInputBG2[panelObjectIdx].gameObject.SetActive(false);
				}
			}
			else
			{
				if (this.Img_ItemP1BG[panelObjectIdx] != null)
				{
					this.Img_ItemP1BG[panelObjectIdx].gameObject.SetActive(false);
				}
				if (this.Img_ItemP1BG2[panelObjectIdx] != null)
				{
					this.Img_ItemP1BG2[panelObjectIdx].gameObject.SetActive(true);
				}
				if (this.Img_ItemInputBG[panelObjectIdx] != null)
				{
					this.Img_ItemInputBG[panelObjectIdx].color = new Color(1f, 1f, 1f, 0f);
				}
				if (this.Img_ItemInputBG2[panelObjectIdx] != null)
				{
					this.Img_ItemInputBG2[panelObjectIdx].gameObject.SetActive(true);
				}
			}
			this.ItemPT2[panelObjectIdx].gameObject.SetActive(false);
			this.btn_Item[panelObjectIdx].m_BtnID2 = dataIdx;
			this.Cstr_Item_K[panelObjectIdx].ClearString();
			this.Cstr_Item_K[panelObjectIdx].IntToFormat((long)this.DM.m_Wonders[dataIdx].KingdomID, 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Item_K[panelObjectIdx].AppendFormat("{0}#");
			}
			else
			{
				this.Cstr_Item_K[panelObjectIdx].AppendFormat("#{0}");
			}
			this.text_Item_K[panelObjectIdx].text = this.Cstr_Item_K[panelObjectIdx].ToString();
			this.text_Item_K[panelObjectIdx].SetAllDirty();
			this.text_Item_K[panelObjectIdx].cachedTextGenerator.Invalidate();
			if (this.DM.m_Wonders[dataIdx].KingdomID != DataManager.MapDataController.kingdomData.kingdomID)
			{
				this.text_Item_K[panelObjectIdx].gameObject.SetActive(true);
			}
			else
			{
				this.text_Item_K[panelObjectIdx].gameObject.SetActive(false);
			}
			if (this.DM.m_Wonders[dataIdx].WonderID < 7)
			{
				this.img_Wonders[panelObjectIdx][1].sprite = this.GUIM.GetWonderSprite(this.DM.m_Wonders[dataIdx].WonderID, this.DM.m_Wonders[dataIdx].KingdomID, 0);
			}
			else
			{
				this.img_Wonders[panelObjectIdx][1].sprite = this.GUIM.GetWonderSprite(0, this.DM.m_Wonders[dataIdx].KingdomID, 0);
			}
			if (this.DM.m_Wonders[dataIdx].WonderID == 0)
			{
				this.ItemPT_W1[panelObjectIdx].gameObject.SetActive(true);
				this.ItemPT_W2[panelObjectIdx].gameObject.SetActive(false);
				this.text_ItemName[panelObjectIdx][0].text = DataManager.MapDataController.GetYolkName(0, this.DM.m_Wonders[dataIdx].KingdomID).ToString();
			}
			else
			{
				bool flag = false;
				if (dataIdx != -1 && this.DM.m_Wonders[dataIdx].WonderID >= 0 && this.DM.m_Wonders[dataIdx].WonderID < 7 && this.mWonderEffect[(int)this.DM.m_Wonders[dataIdx].WonderID] != -1 && this.mWonderEffect[(int)this.DM.m_Wonders[dataIdx].WonderID] == dataIdx)
				{
					flag = true;
				}
				this.ItemPT_W1[panelObjectIdx].gameObject.SetActive(false);
				this.ItemPT_W2[panelObjectIdx].gameObject.SetActive(true);
				if (this.DM.m_Wonders[dataIdx].WonderID < 7)
				{
					this.text_ItemName[panelObjectIdx][1].text = DataManager.MapDataController.GetYolkName((ushort)this.DM.m_Wonders[dataIdx].WonderID, this.DM.m_Wonders[dataIdx].KingdomID).ToString();
				}
				this.Cstr_ItemEffect[panelObjectIdx][0].ClearString();
				this.Cstr_ItemEffect[panelObjectIdx][1].ClearString();
				WondersInfoTbl recordByIndex = DataManager.MapDataController.MapWondersInfoTable.GetRecordByIndex((int)this.DM.m_Wonders[dataIdx].WonderID);
				if (flag)
				{
					GameConstants.GetEffectValue(this.Cstr_ItemEffect[panelObjectIdx][0], recordByIndex.Effect[0].Effect, 0u, 0, 0f);
					this.text_ItemEffect[panelObjectIdx][0].text = this.Cstr_ItemEffect[panelObjectIdx][0].ToString();
					this.text_ItemEffect[panelObjectIdx][0].SetAllDirty();
					this.text_ItemEffect[panelObjectIdx][0].cachedTextGenerator.Invalidate();
					this.text_ItemEffect[panelObjectIdx][0].cachedTextGeneratorForLayout.Invalidate();
					GameConstants.GetEffectValue(this.Cstr_ItemEffect[panelObjectIdx][1], recordByIndex.Effect[1].Effect, 0u, 0, 0f);
					this.text_ItemEffect[panelObjectIdx][1].text = this.Cstr_ItemEffect[panelObjectIdx][1].ToString();
					this.text_ItemEffect[panelObjectIdx][1].SetAllDirty();
					this.text_ItemEffect[panelObjectIdx][1].cachedTextGenerator.Invalidate();
					this.text_ItemEffect[panelObjectIdx][1].cachedTextGeneratorForLayout.Invalidate();
				}
				else
				{
					this.text_ItemEffect[panelObjectIdx][0].text = this.DM.mStringTable.GetStringByID(11043u);
					this.text_ItemEffect[panelObjectIdx][0].SetAllDirty();
					this.text_ItemEffect[panelObjectIdx][0].cachedTextGenerator.Invalidate();
					this.text_ItemEffect[panelObjectIdx][0].cachedTextGeneratorForLayout.Invalidate();
				}
				this.Cstr_ItemEffect[panelObjectIdx][2].ClearString();
				Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(recordByIndex.Effect[0].Effect);
				if (recordByIndex.Effect[0].Value != 0 && flag)
				{
					this.text_ItemEffect[panelObjectIdx][0].gameObject.SetActive(true);
					this.text_ItemEffect[panelObjectIdx][2].gameObject.SetActive(true);
					if (recordByKey.ValueID == 4378)
					{
						this.Cstr_ItemEffect[panelObjectIdx][2].IntToFormat((long)(recordByIndex.Effect[0].Value / 100), 1, false);
						if (this.GUIM.IsArabic)
						{
							this.Cstr_ItemEffect[panelObjectIdx][2].AppendFormat("<color=#35F76C>%{0}</color>");
						}
						else
						{
							this.Cstr_ItemEffect[panelObjectIdx][2].AppendFormat("<color=#35F76C>{0}%</color>");
						}
					}
					else
					{
						this.Cstr_ItemEffect[panelObjectIdx][2].IntToFormat((long)recordByIndex.Effect[0].Value, 1, false);
						this.Cstr_ItemEffect[panelObjectIdx][2].AppendFormat("<color=#35F76C>{0}</color>");
					}
				}
				else
				{
					if (!flag)
					{
						this.text_ItemEffect[panelObjectIdx][0].gameObject.SetActive(true);
					}
					this.text_ItemEffect[panelObjectIdx][2].gameObject.SetActive(false);
				}
				this.text_ItemEffect[panelObjectIdx][2].text = this.Cstr_ItemEffect[panelObjectIdx][2].ToString();
				this.text_ItemEffect[panelObjectIdx][2].SetAllDirty();
				this.text_ItemEffect[panelObjectIdx][2].cachedTextGenerator.Invalidate();
				this.text_ItemEffect[panelObjectIdx][2].cachedTextGeneratorForLayout.Invalidate();
				this.Cstr_ItemEffect[panelObjectIdx][3].ClearString();
				recordByKey = DataManager.Instance.EffectData.GetRecordByKey(recordByIndex.Effect[1].Effect);
				if (recordByIndex.Effect[1].Value != 0 && flag)
				{
					this.text_ItemEffect[panelObjectIdx][1].gameObject.SetActive(true);
					this.text_ItemEffect[panelObjectIdx][3].gameObject.SetActive(true);
					if (recordByKey.ValueID == 4378)
					{
						this.Cstr_ItemEffect[panelObjectIdx][3].IntToFormat((long)(recordByIndex.Effect[1].Value / 100), 1, false);
						if (this.GUIM.IsArabic)
						{
							this.Cstr_ItemEffect[panelObjectIdx][3].AppendFormat("<color=#35F76C>%{0}</color>");
						}
						else
						{
							this.Cstr_ItemEffect[panelObjectIdx][3].AppendFormat("<color=#35F76C>{0}%</color>");
						}
					}
					else
					{
						this.Cstr_ItemEffect[panelObjectIdx][3].IntToFormat((long)recordByIndex.Effect[1].Value, 1, false);
						this.Cstr_ItemEffect[panelObjectIdx][3].AppendFormat("<color=#35F76C>{0}</color>");
					}
				}
				else
				{
					this.text_ItemEffect[panelObjectIdx][1].gameObject.SetActive(false);
					this.text_ItemEffect[panelObjectIdx][3].gameObject.SetActive(false);
				}
				this.text_ItemEffect[panelObjectIdx][3].text = this.Cstr_ItemEffect[panelObjectIdx][3].ToString();
				this.text_ItemEffect[panelObjectIdx][3].SetAllDirty();
				this.text_ItemEffect[panelObjectIdx][3].cachedTextGenerator.Invalidate();
				this.text_ItemEffect[panelObjectIdx][3].cachedTextGeneratorForLayout.Invalidate();
				if (!flag && this.text_ItemEffect[panelObjectIdx][0].preferredWidth >= 370f)
				{
					this.text_ItemEffect[panelObjectIdx][0].rectTransform.sizeDelta = new Vector2(370f, 50f);
				}
				else
				{
					this.text_ItemEffect[panelObjectIdx][0].rectTransform.sizeDelta = new Vector2(this.text_ItemEffect[panelObjectIdx][0].preferredWidth, 25f);
				}
				if (this.GUIM.IsArabic)
				{
					this.text_ItemEffect[panelObjectIdx][0].UpdateArabicPos();
				}
				this.text_ItemEffect[panelObjectIdx][1].rectTransform.sizeDelta = new Vector2(this.text_ItemEffect[panelObjectIdx][1].preferredWidth, this.text_ItemEffect[panelObjectIdx][1].rectTransform.sizeDelta.y);
				if (this.GUIM.IsArabic)
				{
					this.text_ItemEffect[panelObjectIdx][1].UpdateArabicPos();
				}
				this.text_ItemEffect[panelObjectIdx][2].rectTransform.anchoredPosition = new Vector2(this.text_ItemEffect[panelObjectIdx][0].rectTransform.anchoredPosition.x + this.text_ItemEffect[panelObjectIdx][0].rectTransform.sizeDelta.x + 10f, this.text_ItemEffect[panelObjectIdx][0].rectTransform.anchoredPosition.y);
				if (this.GUIM.IsArabic)
				{
					this.text_ItemEffect[panelObjectIdx][2].UpdateArabicPos();
				}
				this.text_ItemEffect[panelObjectIdx][3].rectTransform.anchoredPosition = new Vector2(this.text_ItemEffect[panelObjectIdx][1].rectTransform.anchoredPosition.x + this.text_ItemEffect[panelObjectIdx][1].rectTransform.sizeDelta.x + 10f, this.text_ItemEffect[panelObjectIdx][1].rectTransform.anchoredPosition.y);
				if (this.GUIM.IsArabic)
				{
					this.text_ItemEffect[panelObjectIdx][3].UpdateArabicPos();
				}
			}
			if (this.DM.m_Wonders[dataIdx].OpenState == 1)
			{
				if (ActivityManager.Instance.IsInKvK(0, true))
				{
					this.img_Wonders[panelObjectIdx][0].sprite = this.SArray.m_Sprites[10];
					this.text_ItemCDtime[panelObjectIdx].color = new Color(1f, 0.788f, 0.239f);
					this.text_Item_Hint[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(9902u);
				}
				else
				{
					this.img_Wonders[panelObjectIdx][0].sprite = this.SArray.m_Sprites[9];
					this.text_ItemCDtime[panelObjectIdx].color = new Color(1f, 0.2275f, 0.3333f);
					this.text_Item_Hint[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(9397u);
				}
			}
			else if (this.DM.m_Wonders[dataIdx].OpenState == 0)
			{
				this.img_Wonders[panelObjectIdx][0].sprite = this.SArray.m_Sprites[8];
				this.text_ItemCDtime[panelObjectIdx].color = new Color(0.2078f, 0.9686f, 0.4235f);
				this.text_Item_Hint[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(9399u);
			}
			this.text_Item_Hint[panelObjectIdx].SetAllDirty();
			this.text_Item_Hint[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.text_Item_Hint[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_Item_Hint[panelObjectIdx].preferredWidth > this.text_Item_Hint[panelObjectIdx].rectTransform.sizeDelta.x)
			{
				this.img_ItemHint[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.text_Item_Hint[panelObjectIdx].preferredWidth + 12f, this.img_ItemHint[panelObjectIdx].rectTransform.sizeDelta.y);
				this.text_Item_Hint[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.text_Item_Hint[panelObjectIdx].preferredWidth, this.text_Item_Hint[panelObjectIdx].rectTransform.sizeDelta.y);
				if (this.GUIM.IsArabic)
				{
					this.text_Item_Hint[panelObjectIdx].UpdateArabicPos();
				}
			}
			if (this.text_Item_Hint[panelObjectIdx].preferredHeight > this.text_Item_Hint[panelObjectIdx].rectTransform.sizeDelta.y)
			{
				this.img_ItemHint[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.img_ItemHint[panelObjectIdx].rectTransform.sizeDelta.x, this.text_Item_Hint[panelObjectIdx].preferredHeight + 16f);
				this.text_Item_Hint[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.text_Item_Hint[panelObjectIdx].rectTransform.sizeDelta.x, this.text_Item_Hint[panelObjectIdx].preferredHeight);
			}
			this.Cstr_Item_Time[panelObjectIdx].ClearString();
			long num = this.DM.m_Wonders[dataIdx].StateCountDown.BeginTime + (long)((ulong)this.DM.m_Wonders[dataIdx].StateCountDown.RequireTime) - this.DM.ServerTime;
			if (num > 0L)
			{
				if (num > 86400L)
				{
					this.Cstr_Item_Time[panelObjectIdx].IntToFormat(num / 86400L, 1, false);
					num %= 86400L;
					this.Cstr_Item_Time[panelObjectIdx].IntToFormat(num / 3600L, 2, false);
					num %= 3600L;
					this.Cstr_Item_Time[panelObjectIdx].IntToFormat(num / 60L, 2, false);
					num %= 60L;
					this.Cstr_Item_Time[panelObjectIdx].IntToFormat(num, 2, false);
					this.Cstr_Item_Time[panelObjectIdx].AppendFormat("{0}d {1}:{2}:{3}");
				}
				else
				{
					this.Cstr_Item_Time[panelObjectIdx].IntToFormat(num / 3600L, 2, false);
					num %= 3600L;
					this.Cstr_Item_Time[panelObjectIdx].IntToFormat(num / 60L, 2, false);
					num %= 60L;
					this.Cstr_Item_Time[panelObjectIdx].IntToFormat(num, 2, false);
					this.Cstr_Item_Time[panelObjectIdx].AppendFormat("{0}:{1}:{2}");
				}
			}
			else if (this.DM.m_Wonders[dataIdx].WonderID != 0)
			{
				if (this.DM.m_Wonders[dataIdx].OpenState == 0)
				{
					this.Cstr_Item_Time[panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(9321u));
				}
				else
				{
					this.Cstr_Item_Time[panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(9314u));
				}
			}
			else
			{
				this.Cstr_Item_Time[panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(9320u));
			}
			this.text_ItemCDtime[panelObjectIdx].text = this.Cstr_Item_Time[panelObjectIdx].ToString();
			this.text_ItemCDtime[panelObjectIdx].SetAllDirty();
			this.text_ItemCDtime[panelObjectIdx].cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06000EFD RID: 3837 RVA: 0x001A1230 File Offset: 0x0019F430
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06000EFE RID: 3838 RVA: 0x001A1234 File Offset: 0x0019F434
	public void OnButtonClick(UIButton sender)
	{
		if (this.bcheckInput && sender.m_BtnID1 != 23 && sender.m_BtnID1 != 21 && sender.m_BtnID1 != 22)
		{
			return;
		}
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 1:
		case 2:
		case 3:
			this.SetPage(sender.m_BtnID1 - 1);
			break;
		case 4:
			if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK2)
			{
				this.DM.Letter_ReplyName = this.DM.mStringTable.GetStringByID(4628u);
				this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 3, 0, false);
			}
			else
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4753u), 255, true);
			}
			break;
		case 5:
			this.door.OpenMenu(EGUIWindow.UI_Alliance_List, 0, 0, false);
			break;
		case 6:
			if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
			{
				this.door.OpenMenu(EGUIWindow.UI_Alliance_List, 1, 0, false);
			}
			else
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4753u), 255, true);
			}
			break;
		case 7:
			this.door.OpenMenu(EGUIWindow.UI_Alliance_Gift, 0, 0, false);
			break;
		case 9:
			this.door.OpenMenu(EGUIWindow.UI_BagFilter, 0, 3, false);
			break;
		case 10:
			this.DM.AskMessageBoard(this.DM.RoleAlliance.Id);
			break;
		case 11:
			UILeaderBoard.NewOpen = true;
			this.door.OpenMenu(EGUIWindow.UI_LeaderBoard, 0, 0, false);
			break;
		case 12:
			this.door.OpenMenu(EGUIWindow.UI_Alliance_Management, 0, 0, false);
			break;
		case 17:
			if (this.mInput != null && this.mInput.transform.parent.parent.gameObject.activeSelf)
			{
				if (!this.mInput.gameObject.activeSelf)
				{
					this.m_text_Trans.gameObject.SetActive(false);
					this.mInput.gameObject.SetActive(true);
				}
				this.mInput.ActivateInputField();
				this.bcheckInput = true;
				this.m_ScrollRect.enabled = false;
			}
			break;
		case 18:
			this.door.OpenMenu(EGUIWindow.UI_Alliance_HelpSpeedup, 0, 0, false);
			break;
		case 19:
			this.door.OpenMenu(EGUIWindow.UI_Alliance_List, 4, 0, false);
			break;
		case 20:
			this.door.OpenMenu(EGUIWindow.UI_Alliance_List, 5, 0, false);
			break;
		case 21:
			if (this.DM.RoleAlliance.Rank < AllianceRank.RANK4)
			{
				if (this.img_InputBG != null)
				{
					this.OpenInputCheck(false);
					this.bcheckInput = false;
				}
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
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_BULLETIN;
				messagePacket.AddSeqId();
				messagePacket.Add((ushort)bytes.Length);
				messagePacket.Add(bytes, 0, 900);
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
			this.bcheckInput = false;
			if (this.DM.m_Wonders.Count > 0)
			{
				this.m_ScrollRect.enabled = true;
			}
			break;
		case 22:
			if (this.mInput != null && this.mInput.transform.parent.parent.gameObject.activeSelf)
			{
				if (IGGGameSDK.Instance.GetTranslateStatus() && !this.m_text_Trans.gameObject.activeSelf)
				{
					this.m_text_Trans.gameObject.SetActive(true);
					this.mInput.gameObject.SetActive(false);
				}
				if (this.DM.RoleAlliance.Bullet != null)
				{
					this.mInput.text = this.DM.RoleAlliance.Bullet;
				}
				this.OpenInputCheck(false);
				this.bcheckInput = false;
				if (this.DM.m_Wonders.Count > 0)
				{
					this.m_ScrollRect.enabled = true;
				}
			}
			break;
		case 23:
			if (this.mInput != null && this.mInput.transform.parent.parent.gameObject.activeSelf)
			{
				this.OpenInputCheck(false);
				this.mInput.ActivateInputField();
				this.m_ScrollRect.enabled = false;
			}
			break;
		case 24:
			if (this.mInput != null && this.mInput.transform.parent.parent.gameObject.activeSelf)
			{
				if (!this.mInput.gameObject.activeSelf)
				{
					this.m_text_Trans.gameObject.SetActive(false);
					this.mInput.gameObject.SetActive(true);
				}
				this.mInput.ActivateInputField();
				this.m_ScrollRect.enabled = false;
			}
			break;
		case 25:
			this.door.GoToWonder(this.DM.m_Wonders[sender.m_BtnID2].KingdomID, this.DM.m_Wonders[sender.m_BtnID2].WonderID);
			break;
		case 26:
			this.door.OpenMenu(EGUIWindow.UI_Alliance_List, 7, 0, false);
			break;
		case 29:
			if (this.DM.bWaitTranslate_AA)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8459u), 255, true);
				return;
			}
			if (this.DM.bNeedTranslate_AA_Info && !this.DM.bTranslate_AA_Info && !this.DM.bWaitTranslate_AA)
			{
				this.m_btn_Translation.gameObject.SetActive(false);
				this.m_Img_Translate.gameObject.SetActive(true);
				this.DM.bWaitTranslate_AA = true;
				this.DM.bTransAA = true;
				if (this.DM.RoleAlliance.Bullet != null)
				{
					IGGSDKPlugin.Translate_AA(this.DM.RoleAlliance.Bullet);
				}
			}
			else
			{
				if (!this.bShowTranslate)
				{
					this.m_text_Trans.resizeTextForBestFit = true;
					this.m_text_Trans.resizeTextMaxSize = 17;
					this.m_text_Trans.text = IGGGameSDK.Instance.TranslateStringOut_AA_Info.ToString();
					this.Cstr_Translation.ClearString();
					this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte)this.DM.mAA_Info_L));
					this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054u));
					this.m_text_Translation.text = this.Cstr_Translation.ToString();
					this.bShowTranslate = true;
				}
				else
				{
					this.m_text_Trans.resizeTextForBestFit = false;
					if (this.DM.RoleAlliance.Bullet != null)
					{
						this.m_text_Trans.text = this.DM.RoleAlliance.Bullet;
					}
					this.m_text_Translation.text = this.DM.mStringTable.GetStringByID(9052u);
					this.bShowTranslate = false;
				}
				this.m_text_Trans.SetAllDirty();
				this.m_text_Trans.cachedTextGenerator.Invalidate();
				this.m_text_Trans.cachedTextGeneratorForLayout.Invalidate();
				this.m_text_Translation.SetAllDirty();
				this.m_text_Translation.cachedTextGenerator.Invalidate();
				this.m_text_Translation.cachedTextGeneratorForLayout.Invalidate();
				if (this.m_text_Trans.preferredHeight > 120f)
				{
					this.tmpTransH = this.m_text_Trans.preferredHeight - 120f;
				}
				else
				{
					this.tmpTransH = 0f;
				}
				this.tmplist.Clear();
				for (int i = 0; i < this.DM.m_Wonders.Count; i++)
				{
					this.tmplist.Add(93f);
				}
				if (this.tmpTransH > 0f)
				{
					float item = this.tmpHeight + 40f;
					this.tmplist.Add(item);
				}
				else
				{
					this.tmplist.Add(this.tmpHeight);
				}
				this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
				if (this.tmplist.Count <= 1)
				{
					this.m_ScrollRect.enabled = false;
				}
				else
				{
					this.m_ScrollRect.enabled = true;
				}
				if (this.m_text_Translation.preferredWidth > this.m_text_Translation.rectTransform.sizeDelta.x)
				{
					this.m_text_Translation.rectTransform.sizeDelta = new Vector2(this.m_text_Translation.preferredWidth + 2f, this.m_text_Translation.rectTransform.sizeDelta.y);
				}
				if (this.GUIM.IsArabic)
				{
					this.m_text_Translation.UpdateArabicPos();
				}
			}
			break;
		case 30:
			ActivityGiftManager.Instance.mActivityGiftPage = 0;
			this.door.OpenMenu(EGUIWindow.UI_Alliance_ActivityGift, 0, 0, false);
			break;
		}
	}

	// Token: 0x06000EFF RID: 3839 RVA: 0x001A1CF0 File Offset: 0x0019FEF0
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		switch (uibutton.m_BtnID1)
		{
		case 27:
			this.img_ItemHint[uibutton.m_BtnID2].gameObject.SetActive(true);
			break;
		case 28:
			this.img_KHint.gameObject.SetActive(true);
			break;
		case 31:
			this.SetAMWHint(true, uibutton.transform);
			break;
		}
	}

	// Token: 0x06000F00 RID: 3840 RVA: 0x001A1D78 File Offset: 0x0019FF78
	public void OnButtonUp(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		switch (uibutton.m_BtnID1)
		{
		case 27:
			this.img_ItemHint[uibutton.m_BtnID2].gameObject.SetActive(false);
			break;
		case 28:
			this.img_KHint.gameObject.SetActive(false);
			break;
		case 31:
			this.SetAMWHint(false, null);
			break;
		}
	}

	// Token: 0x06000F01 RID: 3841 RVA: 0x001A1DFC File Offset: 0x0019FFFC
	public override void UpdateNetwork(byte[] meg)
	{
		if (this.MarshalInst != null)
		{
			this.MarshalInst.UpdateNetwork(meg);
		}
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			if (this.DM.RoleAlliance.Id == 0u)
			{
				this.OpenInputCheck(false);
				this.bcheckInput = false;
				this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_Info);
				return;
			}
			if (this.img_InputBG.IsActive())
			{
				this.OpenInputCheck(false);
			}
			this.CheckGiftBtnShow();
			this.CheckAMPlaceMainInfo();
			if (this.img_Title != null)
			{
				if ((this.mNowPage == 0 && this.tmpRank == 0) || this.mNowPage != 0)
				{
					this.img_Title.gameObject.SetActive(true);
				}
				else
				{
					this.img_Title.gameObject.SetActive(false);
				}
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
				if (this.DM.RoleAlliance.Id == 0u)
				{
					this.OpenInputCheck(false);
					this.bcheckInput = false;
					this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_Info);
					return;
				}
				if (this.Pagedata[0] != null)
				{
					this.Cstr_AllianceChief.ClearString();
					this.Cstr_AllianceChief.StringToFormat(this.DM.RoleAlliance.Leader);
					this.Cstr_AllianceChief.AppendFormat(this.DM.mStringTable.GetStringByID(4625u));
					this.text_AllianceChief.text = this.Cstr_AllianceChief.ToString();
					this.text_AllianceChief.SetAllDirty();
					this.text_AllianceChief.cachedTextGenerator.Invalidate();
					this.Cstr_AllianceStrength.ClearString();
					this.Cstr_AllianceStrength.uLongToFormat(this.DM.RoleAlliance.Power, 1, true);
					this.Cstr_AllianceStrength.AppendFormat(this.DM.mStringTable.GetStringByID(4626u));
					this.text_AllianceStrength.text = this.Cstr_AllianceStrength.ToString();
					this.text_AllianceStrength.SetAllDirty();
					this.text_AllianceStrength.cachedTextGenerator.Invalidate();
					this.Cstr_AllianceMember.ClearString();
					this.Cstr_AllianceMember.IntToFormat((long)this.DM.RoleAlliance.Member, 1, false);
					this.Cstr_AllianceMember.AppendFormat(this.DM.mStringTable.GetStringByID(4627u));
					this.text_AllianceMember.text = this.Cstr_AllianceMember.ToString();
					this.text_AllianceMember.SetAllDirty();
					this.text_AllianceMember.cachedTextGenerator.Invalidate();
					this.text_btnApplicationNum.text = this.DM.RoleAlliance.Applicant.ToString();
					if (this.DM.RoleAlliance.Applicant > 0 && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
					{
						this.btnApplicationNum_RT[0].gameObject.SetActive(true);
						this.btnApplicationNum_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_btnApplicationNum.preferredWidth), this.btnApplicationNum_RT[0].sizeDelta.y);
					}
					else
					{
						this.btnApplicationNum_RT[0].gameObject.SetActive(false);
					}
					this.Cstr_GifeLV.ClearString();
					this.Cstr_GifeLV.IntToFormat((long)this.DM.RoleAlliance.GiftLv, 1, false);
					this.Cstr_GifeLV.AppendFormat(this.DM.mStringTable.GetStringByID(4631u));
					this.text_btnGife[1].text = this.Cstr_GifeLV.ToString();
					this.text_btnGife[1].SetAllDirty();
					this.text_btnGife[1].cachedTextGenerator.Invalidate();
					this.text_btnGife[0].text = this.DM.RoleAlliance.GiftNum.ToString();
					if (this.DM.RoleAlliance.GiftNum > 0)
					{
						this.btnGiftNum_RT[0].gameObject.SetActive(true);
						this.btnGiftNum_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_btnGife[0].preferredWidth), this.btnGiftNum_RT[0].sizeDelta.y);
					}
					else
					{
						this.btnGiftNum_RT[0].gameObject.SetActive(false);
					}
					long num = this.DM.RoleAlliance.ChatMax - this.DM.RoleAlliance.ChatId;
					if (this.btnMessageNum_RT[0] != null)
					{
						if (num > 0L)
						{
							num = (long)((num <= 20L) ? ((int)num) : 20);
							this.text_MessageNum.text = num.ToString();
							this.text_MessageNum.SetAllDirty();
							this.text_MessageNum.cachedTextGenerator.Invalidate();
							this.text_MessageNum.cachedTextGeneratorForLayout.Invalidate();
							this.btnMessageNum_RT[0].gameObject.SetActive(true);
							this.btnMessageNum_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_MessageNum.preferredWidth), this.btnMessageNum_RT[0].sizeDelta.y);
						}
						else
						{
							this.btnMessageNum_RT[0].gameObject.SetActive(false);
						}
					}
					int num2 = (int)this.DM.RoleAlliance.GiftNum;
					if (num > 0L)
					{
						num2 += (int)num;
					}
					if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
					{
						num2 += (int)this.DM.RoleAlliance.Applicant;
					}
					if (ActivityGiftManager.Instance.ActivityGiftBeginTime - ActivityManager.Instance.ServerEventTime < 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && ActivityGiftManager.Instance.EnableRedPocketNum > 0)
					{
						num2 += (int)ActivityGiftManager.Instance.EnableRedPocketNum;
					}
					if (num2 > 0)
					{
						this.text_PageNum[0].text = num2.ToString();
						this.text_PageNum[0].SetAllDirty();
						this.text_PageNum[0].cachedTextGenerator.Invalidate();
						this.text_PageNum[0].cachedTextGeneratorForLayout.Invalidate();
						this.PageImg_RT[0].gameObject.SetActive(true);
						this.PageImg_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[0].preferredWidth), this.PageImg_RT[0].sizeDelta.y);
					}
					else
					{
						this.PageImg_RT[0].gameObject.SetActive(false);
					}
					this.Cstr_AllianceName.ClearString();
					GameConstants.FormatRoleName(this.Cstr_AllianceName, this.DM.RoleAlliance.Name, this.DM.RoleAlliance.Tag, null, 0, 0, null, null, null, null);
					this.text_AllianceName.text = this.Cstr_AllianceName.ToString();
					this.text_AllianceName.SetAllDirty();
					this.text_AllianceName.cachedTextGenerator.Invalidate();
					this.GUIM.SetBadgeTotemImg(this.BadgeT, this.DM.RoleAlliance.Emblem);
					if (this.text_Alliance_Money != null)
					{
						this.Cstr_Alliance_Money.ClearString();
						this.Cstr_Alliance_Money.IntToFormat((long)((ulong)this.DM.RoleAlliance.Money), 1, true);
						this.Cstr_Alliance_Money.AppendFormat("{0}");
						this.text_Alliance_Money.text = this.Cstr_Alliance_Money.ToString();
						this.text_Alliance_Money.SetAllDirty();
						this.text_Alliance_Money.cachedTextGenerator.Invalidate();
					}
					if (this.text_Alliance_K != null && this.btn_KHint != null && this.Cstr_Alliance_K != null)
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
						this.text_Alliance_K.cachedTextGeneratorForLayout.Invalidate();
						this.text_Alliance_K.rectTransform.sizeDelta = new Vector2(this.text_Alliance_K.preferredWidth + 1f, this.text_Alliance_K.rectTransform.sizeDelta.y);
						this.SetKingdomBtn(-1f);
						if (this.DM.RoleAlliance.KingdomID != DataManager.MapDataController.kingdomData.kingdomID)
						{
							this.text_Alliance_K.gameObject.SetActive(true);
							this.btn_KHint.gameObject.SetActive(true);
						}
						else
						{
							this.text_Alliance_K.gameObject.SetActive(false);
							this.btn_KHint.gameObject.SetActive(false);
						}
					}
					if (this.DM.bSetAllianceScroll)
					{
						this.tmplist.Clear();
						for (int i = 0; i < this.DM.m_Wonders.Count; i++)
						{
							this.tmplist.Add(93f);
						}
						this.ResetEffectText();
						float num3 = this.tmpHeight;
						if (IGGGameSDK.Instance.GetTranslateStatus() && this.m_TranslationRT != null && this.m_TranslationRT.anchoredPosition.y < -120.5f)
						{
							num3 += 40f;
						}
						this.tmplist.Add(num3);
						if (this.tmplist.Count <= 1)
						{
							this.m_ScrollRect.enabled = false;
							this.m_ScrollPanel.AddNewDataHeight(this.tmplist, true, true);
						}
						else
						{
							this.m_ScrollRect.enabled = true;
							this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
						}
					}
					this.DM.bSetAllianceScroll = false;
				}
			}
			break;
		}
	}

	// Token: 0x06000F02 RID: 3842 RVA: 0x001A2868 File Offset: 0x001A0A68
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_Propaganda != null && this.text_Propaganda.enabled)
		{
			this.text_Propaganda.enabled = false;
			this.text_Propaganda.enabled = true;
		}
		if (this.text_AllianceName != null && this.text_AllianceName.enabled)
		{
			this.text_AllianceName.enabled = false;
			this.text_AllianceName.enabled = true;
		}
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
		if (this.text_InputCheck != null && this.text_InputCheck.enabled)
		{
			this.text_InputCheck.enabled = false;
			this.text_InputCheck.enabled = true;
		}
		if (this.text_btnApplicationNum != null && this.text_btnApplicationNum.enabled)
		{
			this.text_btnApplicationNum.enabled = false;
			this.text_btnApplicationNum.enabled = true;
		}
		if (this.text_Input1 != null && this.text_Input1.enabled)
		{
			this.text_Input1.enabled = false;
			this.text_Input1.enabled = true;
		}
		if (this.text_Alliance_Money != null && this.text_Alliance_Money.enabled)
		{
			this.text_Alliance_Money.enabled = false;
			this.text_Alliance_Money.enabled = true;
		}
		if (this.text_HelpNum != null && this.text_HelpNum.enabled)
		{
			this.text_HelpNum.enabled = false;
			this.text_HelpNum.enabled = true;
		}
		if (this.text_MessageNum != null && this.text_MessageNum.enabled)
		{
			this.text_MessageNum.enabled = false;
			this.text_MessageNum.enabled = true;
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
		if (this.mInput != null && this.mInput.textComponent.enabled)
		{
			this.mInput.textComponent.enabled = false;
			this.mInput.textComponent.enabled = true;
		}
		if (this.m_text_ActivityGiftNum != null && this.m_text_ActivityGiftNum.enabled)
		{
			this.m_text_ActivityGiftNum.enabled = false;
			this.m_text_ActivityGiftNum.enabled = true;
		}
		if (this.text_Title_AMP != null && this.text_Title_AMP.enabled)
		{
			this.text_Title_AMP.enabled = false;
			this.text_Title_AMP.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_btnGife[i] != null && this.text_btnGife[i].enabled)
			{
				this.text_btnGife[i].enabled = false;
				this.text_btnGife[i].enabled = true;
			}
		}
		for (int j = 0; j < 3; j++)
		{
			if (this.text_PageNum[j] != null && this.text_PageNum[j].enabled)
			{
				this.text_PageNum[j].enabled = false;
				this.text_PageNum[j].enabled = true;
			}
		}
		for (int k = 0; k < 10; k++)
		{
			if (this.text_tmpStr[k] != null && this.text_tmpStr[k].enabled)
			{
				this.text_tmpStr[k].enabled = false;
				this.text_tmpStr[k].enabled = true;
			}
		}
		if (this.Pagedata[0] != null)
		{
			for (int l = 0; l < 6; l++)
			{
				if (this.text_ItembtnName[l] != null)
				{
					for (int m = 0; m < 5; m++)
					{
						if (this.text_ItembtnName[l][m] != null && this.text_ItembtnName[l][m].enabled)
						{
							this.text_ItembtnName[l][m].enabled = false;
							this.text_ItembtnName[l][m].enabled = true;
						}
					}
				}
			}
		}
		for (int n = 0; n < 11; n++)
		{
			if (this.text_tmpItmeStr[n] != null && this.text_tmpItmeStr[n].enabled)
			{
				this.text_tmpItmeStr[n].enabled = false;
				this.text_tmpItmeStr[n].enabled = true;
			}
		}
		for (int num = 0; num < 15; num++)
		{
			if (this.text_tmpItmeP2Str[num] != null && this.text_tmpItmeP2Str[num].enabled)
			{
				this.text_tmpItmeP2Str[num].enabled = false;
				this.text_tmpItmeP2Str[num].enabled = true;
			}
		}
		if (this.Pagedata[0] != null)
		{
			if (this.m_text_Trans != null && this.m_text_Trans.enabled)
			{
				this.m_text_Trans.enabled = false;
				this.m_text_Trans.enabled = true;
			}
			if (this.m_text_Translation != null && this.m_text_Translation.enabled)
			{
				this.m_text_Translation.enabled = false;
				this.m_text_Translation.enabled = true;
			}
			for (int num2 = 0; num2 < 6; num2++)
			{
				if (this.text_ItemName[num2] != null)
				{
					for (int num3 = 0; num3 < 2; num3++)
					{
						if (this.text_ItemName[num2][num3] != null && this.text_ItemName[num2][num3].enabled)
						{
							this.text_ItemName[num2][num3].enabled = false;
							this.text_ItemName[num2][num3].enabled = true;
						}
					}
				}
				if (this.text_ItemEffect[num2] != null)
				{
					for (int num4 = 0; num4 < 4; num4++)
					{
						if (this.text_ItemEffect[num2][num4] != null && this.text_ItemEffect[num2][num4].enabled)
						{
							this.text_ItemEffect[num2][num4].enabled = false;
							this.text_ItemEffect[num2][num4].enabled = true;
						}
					}
				}
				if (this.text_Item_Hint[num2] != null && this.text_Item_Hint[num2] != null && this.text_Item_Hint[num2].enabled)
				{
					this.text_Item_Hint[num2].enabled = false;
					this.text_Item_Hint[num2].enabled = true;
				}
				if (this.text_Trans[num2] != null && this.text_Trans[num2] != null && this.text_Trans[num2].enabled)
				{
					this.text_Trans[num2].enabled = false;
					this.text_Trans[num2].enabled = true;
				}
				if (this.text_Translation[num2] != null && this.text_Translation[num2] != null && this.text_Translation[num2].enabled)
				{
					this.text_Translation[num2].enabled = false;
					this.text_Translation[num2].enabled = true;
				}
			}
		}
		for (int num5 = 0; num5 < 6; num5++)
		{
			if (this.text_ItemCDtime[num5] != null && this.text_ItemCDtime[num5].enabled)
			{
				this.text_ItemCDtime[num5].enabled = false;
				this.text_ItemCDtime[num5].enabled = true;
			}
			if (this.text_Item_K[num5] != null && this.text_Item_K[num5].enabled)
			{
				this.text_Item_K[num5].enabled = false;
				this.text_Item_K[num5].enabled = true;
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

	// Token: 0x06000F03 RID: 3843 RVA: 0x001A331C File Offset: 0x001A151C
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 0:
			if (this.door != null)
			{
				this.OpenInputCheck(false);
				this.bcheckInput = false;
				this.door.CloseMenu(false);
			}
			break;
		case 1:
			if (this.Pagedata[0] != null)
			{
				if (this.DM.RoleAlliance.Bullet != null && this.DM.RoleAlliance.Bullet.Length != 0)
				{
					if (this.mInput != null)
					{
						this.mInput.text = this.DM.RoleAlliance.Bullet;
					}
					this.text_tmpItmeP2Str[11].text = this.DM.RoleAlliance.Bullet;
				}
				else if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
				{
					if (this.text_Input1 != null)
					{
						this.text_Input1.text = this.DM.mStringTable.GetStringByID(772u);
					}
				}
				else
				{
					this.Cstr_Null.ClearString();
					if (this.text_Input1 != null)
					{
						this.text_Input1.text = this.Cstr_Null.ToString();
					}
					if (this.mInput != null)
					{
						this.mInput.text = this.Cstr_Null.ToString();
					}
					this.text_tmpItmeP2Str[11].text = this.Cstr_Null.ToString();
				}
				this.bShowTranslate = false;
				this.text_tmpItmeP2Str[11].SetAllDirty();
				this.text_tmpItmeP2Str[11].cachedTextGenerator.Invalidate();
				this.text_tmpItmeP2Str[11].cachedTextGeneratorForLayout.Invalidate();
				this.tmplist.Clear();
				for (int i = 0; i < this.DM.m_Wonders.Count; i++)
				{
					this.tmplist.Add(93f);
				}
				this.tmpTransH = 0f;
				if (IGGGameSDK.Instance.GetTranslateStatus() && this.text_tmpItmeP2Str[11].preferredHeight > 120f)
				{
					float item = this.tmpHeight + 40f;
					this.tmplist.Add(item);
				}
				else
				{
					this.tmplist.Add(this.tmpHeight);
				}
				this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
				if (this.tmplist.Count <= 1)
				{
					this.m_ScrollRect.enabled = false;
				}
				else
				{
					this.m_ScrollRect.enabled = true;
				}
				this.DM.bNeedTranslate_AA_Info = true;
			}
			break;
		case 2:
			if (this.mInput != null && this.mInput.transform.parent.parent.gameObject.activeSelf)
			{
				if (!this.mInput.gameObject.activeSelf)
				{
					this.m_text_Trans.gameObject.SetActive(false);
					this.mInput.gameObject.SetActive(true);
				}
				this.mInput.ActivateInputField();
			}
			break;
		case 3:
			if (this.Pagedata[2] != null)
			{
				this.text_HelpNum.text = this.DM.mHelpDataList.Count.ToString();
				this.text_HelpNum.SetAllDirty();
				this.text_HelpNum.cachedTextGenerator.Invalidate();
				this.text_HelpNum.cachedTextGeneratorForLayout.Invalidate();
				this.btnHelp_RT.gameObject.SetActive(true);
				this.btnHelp_RT.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_HelpNum.preferredWidth), this.btnHelp_RT.sizeDelta.y);
				if (this.DM.mHelpDataList.Count > 0)
				{
					this.btnHelp_RT.gameObject.SetActive(true);
				}
				else
				{
					this.btnHelp_RT.gameObject.SetActive(false);
				}
			}
			if (this.DM.mHelpDataList.Count > 0)
			{
				this.text_PageNum[2].text = this.DM.mHelpDataList.Count.ToString();
				this.text_PageNum[2].SetAllDirty();
				this.text_PageNum[2].cachedTextGenerator.Invalidate();
				this.text_PageNum[2].cachedTextGeneratorForLayout.Invalidate();
				this.PageImg_RT[2].gameObject.SetActive(true);
				this.PageImg_RT[2].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[2].preferredWidth), this.PageImg_RT[2].sizeDelta.y);
			}
			else
			{
				this.PageImg_RT[2].gameObject.SetActive(false);
			}
			break;
		case 4:
		{
			if (this.MarshalInst != null)
			{
				this.MarshalInst.UpdateUI(arg1, arg2);
			}
			uint num = this.DM.ActiveRallyRecNum + this.DM.BeingRallyRecNum;
			if (num > 0u)
			{
				this.text_PageNum[1].text = num.ToString();
				this.text_PageNum[1].SetAllDirty();
				this.text_PageNum[1].cachedTextGenerator.Invalidate();
				this.text_PageNum[1].cachedTextGeneratorForLayout.Invalidate();
				this.PageImg_RT[1].gameObject.SetActive(true);
				this.PageImg_RT[1].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[1].preferredWidth), this.PageImg_RT[1].sizeDelta.y);
			}
			else
			{
				this.PageImg_RT[1].gameObject.SetActive(false);
			}
			break;
		}
		case 5:
		{
			if (this.Pagedata[0] != null)
			{
				this.Cstr_GifeLV.ClearString();
				this.Cstr_GifeLV.IntToFormat((long)this.DM.RoleAlliance.GiftLv, 1, false);
				this.Cstr_GifeLV.AppendFormat(this.DM.mStringTable.GetStringByID(4631u));
				this.text_btnGife[1].text = this.Cstr_GifeLV.ToString();
				this.text_btnGife[1].SetAllDirty();
				this.text_btnGife[1].cachedTextGenerator.Invalidate();
				this.text_btnGife[0].text = this.DM.RoleAlliance.GiftNum.ToString();
				if (this.DM.RoleAlliance.GiftNum > 0)
				{
					this.btnGiftNum_RT[0].gameObject.SetActive(true);
					this.btnGiftNum_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_btnGife[0].preferredWidth), this.btnGiftNum_RT[0].sizeDelta.y);
				}
				else
				{
					this.btnGiftNum_RT[0].gameObject.SetActive(false);
				}
			}
			int num2 = (int)this.DM.RoleAlliance.GiftNum;
			long num3 = this.DM.RoleAlliance.ChatMax - this.DM.RoleAlliance.ChatId;
			if (num3 > 0L)
			{
				num2 += ((num3 <= 20L) ? ((int)num3) : 20);
			}
			if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
			{
				num2 += (int)this.DM.RoleAlliance.Applicant;
			}
			if (ActivityGiftManager.Instance.ActivityGiftBeginTime - ActivityManager.Instance.ServerEventTime < 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && ActivityGiftManager.Instance.EnableRedPocketNum > 0)
			{
				num2 += (int)ActivityGiftManager.Instance.EnableRedPocketNum;
			}
			if (num2 > 0)
			{
				this.text_PageNum[0].text = num2.ToString();
				this.PageImg_RT[0].gameObject.SetActive(true);
				this.PageImg_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[0].preferredWidth), this.PageImg_RT[0].sizeDelta.y);
			}
			else
			{
				this.PageImg_RT[0].gameObject.SetActive(false);
			}
			break;
		}
		case 6:
			if (this.Pagedata[0] != null)
			{
				if (this.DM.RoleAlliance.Bullet != null)
				{
					if (!this.bShowTranslate)
					{
						this.text_tmpItmeP2Str[11].text = this.DM.RoleAlliance.Bullet;
					}
					else
					{
						this.text_tmpItmeP2Str[11].text = IGGGameSDK.Instance.TranslateStringOut_AA_Info.ToString();
					}
				}
				else
				{
					this.text_tmpItmeP2Str[11].text = string.Empty;
				}
				this.text_tmpItmeP2Str[11].SetAllDirty();
				this.text_tmpItmeP2Str[11].cachedTextGenerator.Invalidate();
				this.text_tmpItmeP2Str[11].cachedTextGeneratorForLayout.Invalidate();
				this.tmplist.Clear();
				for (int j = 0; j < this.DM.m_Wonders.Count; j++)
				{
					this.tmplist.Add(93f);
				}
				this.tmpTransH = 0f;
				this.ResetEffectText();
				if (IGGGameSDK.Instance.GetTranslateStatus() && this.text_tmpItmeP2Str[11].preferredHeight > 120f)
				{
					float item2 = this.tmpHeight + 40f;
					this.tmplist.Add(item2);
				}
				else
				{
					this.tmplist.Add(this.tmpHeight);
				}
				if (this.tmplist.Count <= 1)
				{
					this.m_ScrollRect.enabled = false;
					this.m_ScrollPanel.AddNewDataHeight(this.tmplist, true, true);
				}
				else
				{
					this.m_ScrollRect.enabled = true;
					this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
				}
				if (this.img_InputBG != null)
				{
					this.OpenInputCheck(false);
					this.bcheckInput = false;
				}
			}
			break;
		case 7:
			this.bShowTranslate = true;
			this.text_tmpItmeP2Str[11].text = IGGGameSDK.Instance.TranslateStringOut_AA_Info.ToString();
			this.text_tmpItmeP2Str[11].SetAllDirty();
			this.text_tmpItmeP2Str[11].cachedTextGenerator.Invalidate();
			this.text_tmpItmeP2Str[11].cachedTextGeneratorForLayout.Invalidate();
			this.tmplist.Clear();
			for (int k = 0; k < this.DM.m_Wonders.Count; k++)
			{
				this.tmplist.Add(93f);
			}
			this.tmpTransH = 0f;
			if (this.text_tmpItmeP2Str[11].preferredHeight > 120f)
			{
				float item3 = this.tmpHeight + 40f;
				this.tmplist.Add(item3);
			}
			else
			{
				this.tmplist.Add(this.tmpHeight);
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			if (this.tmplist.Count <= 1)
			{
				this.m_ScrollRect.enabled = false;
			}
			else
			{
				this.m_ScrollRect.enabled = true;
			}
			break;
		case 8:
			this.m_btn_Translation.gameObject.SetActive(true);
			this.m_Img_Translate.gameObject.SetActive(false);
			this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9077u), 255, true);
			break;
		case 9:
		{
			this.m_text_ActivityGiftNum.text = ActivityGiftManager.Instance.EnableRedPocketNum.ToString();
			this.m_text_ActivityGiftNum.SetAllDirty();
			this.m_text_ActivityGiftNum.cachedTextGenerator.Invalidate();
			this.m_text_ActivityGiftNum.cachedTextGeneratorForLayout.Invalidate();
			this.img_ActivityGift[0].rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_text_ActivityGiftNum.preferredWidth), this.img_ActivityGift[0].rectTransform.sizeDelta.y);
			this.CheckGiftBtnShow();
			int num4 = (int)this.DM.RoleAlliance.GiftNum;
			long num5 = this.DM.RoleAlliance.ChatMax - this.DM.RoleAlliance.ChatId;
			if (num5 > 0L)
			{
				num4 += ((num5 <= 20L) ? ((int)num5) : 20);
			}
			if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
			{
				num4 += (int)this.DM.RoleAlliance.Applicant;
			}
			if (ActivityGiftManager.Instance.ActivityGiftBeginTime - ActivityManager.Instance.ServerEventTime < 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && ActivityGiftManager.Instance.EnableRedPocketNum > 0)
			{
				num4 += (int)ActivityGiftManager.Instance.EnableRedPocketNum;
			}
			if (num4 > 0)
			{
				this.text_PageNum[0].text = num4.ToString();
				this.PageImg_RT[0].gameObject.SetActive(true);
				this.PageImg_RT[0].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PageNum[0].preferredWidth), this.PageImg_RT[0].sizeDelta.y);
			}
			else
			{
				this.PageImg_RT[0].gameObject.SetActive(false);
			}
			break;
		}
		case 10:
			this.m_text_ActivityGiftNum.text = ActivityGiftManager.Instance.EnableRedPocketNum.ToString();
			this.m_text_ActivityGiftNum.SetAllDirty();
			this.m_text_ActivityGiftNum.cachedTextGenerator.Invalidate();
			this.m_text_ActivityGiftNum.cachedTextGeneratorForLayout.Invalidate();
			this.img_ActivityGift[0].rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_text_ActivityGiftNum.preferredWidth), this.img_ActivityGift[0].rectTransform.sizeDelta.y);
			break;
		case 11:
			this.CheckGiftBtnShow();
			break;
		case 12:
			this.CheckAMPlaceMainInfo();
			if (this.img_Title != null)
			{
				if ((this.mNowPage == 0 && this.tmpRank == 0) || this.mNowPage != 0)
				{
					this.img_Title.gameObject.SetActive(true);
				}
				else
				{
					this.img_Title.gameObject.SetActive(false);
				}
			}
			break;
		case 13:
			this.CheckShowAMWBtn();
			if (this.AMWHintGO.activeInHierarchy)
			{
				this.SetAMWHint(false, null);
				this.SetAMWHint(true, this.AMWOpenBtnT);
			}
			break;
		}
	}

	// Token: 0x06000F04 RID: 3844 RVA: 0x001A423C File Offset: 0x001A243C
	public void CheckGiftBtnShow()
	{
		if (this.Pagedata[0] == null || (this.Pagedata[0] != null && !this.Pagedata[0].gameObject.activeSelf))
		{
			this.btn_ActivityGift.gameObject.SetActive(false);
			return;
		}
		if ((ActivityManager.Instance.ServerEventTime - ActivityGiftManager.Instance.ActivityGiftBeginTime >= 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L) || ActivityGiftManager.Instance.EnableRedPocketNum > 0)
		{
			this.btn_ActivityGift.gameObject.SetActive(true);
			this.GUIM.SetFastivalImage(ActivityGiftManager.Instance.GroupID, 4, this.btn_ActivityGift.image);
			this.btn_ActivityGift.image.SetNativeSize();
			this.btn_ActivityGift.image.type = Image.Type.Simple;
			if (ActivityManager.Instance.ServerEventTime - ActivityGiftManager.Instance.ActivityGiftBeginTime >= 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && this.DM.RoleAlliance.Rank == AllianceRank.RANK5 && ActivityGiftManager.Instance.mLeaderRedPocketResetTime - ActivityManager.Instance.ServerEventTime <= 0L)
			{
				this.img_ActivityGift[1].gameObject.SetActive(true);
				this.img_ActivityGift[0].gameObject.SetActive(true);
				this.m_text_ActivityGiftNum.gameObject.SetActive(false);
			}
			else
			{
				this.img_ActivityGift[1].gameObject.SetActive(false);
				if (ActivityGiftManager.Instance.EnableRedPocketNum > 0)
				{
					this.m_text_ActivityGiftNum.gameObject.SetActive(true);
					this.img_ActivityGift[0].gameObject.SetActive(true);
				}
				else
				{
					this.img_ActivityGift[0].gameObject.SetActive(false);
				}
			}
		}
		else
		{
			this.btn_ActivityGift.gameObject.SetActive(false);
		}
		if (this.Pagedata[0] != null)
		{
			this.CheckShowAMWBtn();
		}
	}

	// Token: 0x06000F05 RID: 3845 RVA: 0x001A4468 File Offset: 0x001A2668
	public void Update()
	{
		if (this.MarshalInst != null && this.mNowPage == 1)
		{
			this.MarshalInst.Update();
		}
		this.PageBGTime += Time.smoothDeltaTime;
		if (this.PageBGTime >= 0f && this.mNowPage < this.img_PageBG.Length && this.img_PageBG[this.mNowPage] != null)
		{
			if (this.PageBGTime >= 2f)
			{
				this.PageBGTime = 0f;
			}
			float a = (this.PageBGTime <= 1f) ? this.PageBGTime : (2f - this.PageBGTime);
			this.img_PageBG[this.mNowPage].color = new Color(1f, 1f, 1f, a);
		}
		if (this.DM.bTranslate_AA_Info)
		{
			this.GUIM.UpdateUI(EGUIWindow.UI_Alliance_Info, 7, 0);
			this.DM.bTranslate_AA_Info = false;
			this.DM.bNeedTranslate_AA_Info = false;
		}
		if (this.DM.bTranslate_AA_InfoFailed)
		{
			this.GUIM.UpdateUI(EGUIWindow.UI_Alliance_Info, 8, 0);
			this.DM.bTranslate_AA_InfoFailed = false;
		}
	}

	// Token: 0x06000F06 RID: 3846 RVA: 0x001A45B0 File Offset: 0x001A27B0
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond)
		{
			for (int i = 0; i < 6; i++)
			{
				if (this.ItemPT1[i] != null && this.ItemPT1[i].gameObject.activeSelf && this.tmpItem[i] != null && this.DM.m_Wonders.Count > this.tmpItem[i].m_BtnID1 && this.tmpItem[i].m_BtnID1 >= 0)
				{
					this.Cstr_Item_Time[this.tmpItem[i].m_BtnID2].ClearString();
					long num = this.DM.m_Wonders[this.tmpItem[i].m_BtnID1].StateCountDown.BeginTime + (long)((ulong)this.DM.m_Wonders[this.tmpItem[i].m_BtnID1].StateCountDown.RequireTime) - this.DM.ServerTime;
					if (num > 0L)
					{
						if (num > 86400L)
						{
							this.Cstr_Item_Time[this.tmpItem[i].m_BtnID2].IntToFormat(num / 86400L, 1, false);
							num %= 86400L;
							this.Cstr_Item_Time[this.tmpItem[i].m_BtnID2].IntToFormat(num / 3600L, 2, false);
							num %= 3600L;
							this.Cstr_Item_Time[this.tmpItem[i].m_BtnID2].IntToFormat(num / 60L, 2, false);
							num %= 60L;
							this.Cstr_Item_Time[this.tmpItem[i].m_BtnID2].IntToFormat(num, 2, false);
							this.Cstr_Item_Time[this.tmpItem[i].m_BtnID2].AppendFormat("{0}d {1}:{2}:{3}");
						}
						else
						{
							this.Cstr_Item_Time[this.tmpItem[i].m_BtnID2].IntToFormat(num / 3600L, 2, false);
							num %= 3600L;
							this.Cstr_Item_Time[this.tmpItem[i].m_BtnID2].IntToFormat(num / 60L, 2, false);
							num %= 60L;
							this.Cstr_Item_Time[this.tmpItem[i].m_BtnID2].IntToFormat(num, 2, false);
							this.Cstr_Item_Time[this.tmpItem[i].m_BtnID2].AppendFormat("{0}:{1}:{2}");
						}
					}
					else if (this.DM.m_Wonders[this.tmpItem[i].m_BtnID1].WonderID != 0)
					{
						if (this.DM.m_Wonders[this.tmpItem[i].m_BtnID1].OpenState == 0)
						{
							this.Cstr_Item_Time[this.tmpItem[i].m_BtnID2].Append(DataManager.Instance.mStringTable.GetStringByID(9321u));
						}
						else
						{
							this.Cstr_Item_Time[this.tmpItem[i].m_BtnID2].Append(DataManager.Instance.mStringTable.GetStringByID(9314u));
						}
					}
					else
					{
						this.Cstr_Item_Time[this.tmpItem[i].m_BtnID2].Append(DataManager.Instance.mStringTable.GetStringByID(9320u));
					}
					this.text_ItemCDtime[this.tmpItem[i].m_BtnID2].text = this.Cstr_Item_Time[this.tmpItem[i].m_BtnID2].ToString();
					this.text_ItemCDtime[this.tmpItem[i].m_BtnID2].SetAllDirty();
					this.text_ItemCDtime[this.tmpItem[i].m_BtnID2].cachedTextGenerator.Invalidate();
				}
			}
		}
		else if (this.bOpenEnd)
		{
			this.bOpenEnd = false;
			if (!this.bOpenCheck)
			{
				this.CheckAMPlaceMainInfo();
				if (this.img_Title != null)
				{
					if ((this.mNowPage == 0 && this.tmpRank == 0) || this.mNowPage != 0)
					{
						this.img_Title.gameObject.SetActive(true);
					}
					else
					{
						this.img_Title.gameObject.SetActive(false);
					}
				}
				this.bOpenCheck = true;
			}
		}
	}

	// Token: 0x06000F07 RID: 3847 RVA: 0x001A4A04 File Offset: 0x001A2C04
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

	// Token: 0x06000F08 RID: 3848 RVA: 0x001A4A84 File Offset: 0x001A2C84
	public override bool OnBackButtonClick()
	{
		if (this.img_InputBG.IsActive())
		{
			this.OpenInputCheck(false);
			this.bcheckInput = false;
		}
		return false;
	}

	// Token: 0x06000F09 RID: 3849 RVA: 0x001A4AA8 File Offset: 0x001A2CA8
	public void CheckAMPlaceMainInfo()
	{
		this.tmpRank = 0;
		if (this.DM.RoleAlliance.AMPlaceMainInfoUIShow == 1)
		{
			this.tmpRank = 1;
		}
		else if (this.DM.RoleAlliance.AMPlaceMainInfoUIShow >= 2 && this.DM.RoleAlliance.AMPlaceMainInfoUIShow <= 10)
		{
			this.tmpRank = 2;
		}
		else if (this.DM.RoleAlliance.AMPlaceMainInfoUIShow >= 11 && this.DM.RoleAlliance.AMPlaceMainInfoUIShow <= 50)
		{
			this.tmpRank = 3;
		}
		else if (this.DM.RoleAlliance.AMPlaceMainInfoUIShow >= 51 && this.DM.RoleAlliance.AMPlaceMainInfoUIShow <= 100)
		{
			this.tmpRank = 4;
		}
		if (this.img_AMRank_BG != null)
		{
			this.img_AMRank_BG.gameObject.SetActive(false);
		}
		if (this.img_AMRank_BG2 != null)
		{
			this.img_AMRank_BG2.gameObject.SetActive(false);
		}
		if (this.img_AMRank1_F != null)
		{
			this.img_AMRank1_F.gameObject.SetActive(false);
		}
		this.img_BG.color = new Color(1f, 1f, 1f, 1f);
		if (this.tmpRank == 0)
		{
			if (this.img_AMRankNew_BG != null)
			{
				this.img_AMRankNew_BG.gameObject.SetActive(false);
			}
			if (this.img_AMRank_Letter != null)
			{
				this.img_AMRank_Letter.gameObject.SetActive(false);
			}
			if (this.img_AMRank_Member != null)
			{
				this.img_AMRank_Member.gameObject.SetActive(false);
			}
			if (this.img_AMRank_Application != null)
			{
				this.img_AMRank_Application.gameObject.SetActive(false);
			}
			if (this.img_AMRank_Gift != null)
			{
				this.img_AMRank_Gift.gameObject.SetActive(false);
			}
			for (int i = 0; i < 6; i++)
			{
				if (this.Img_ItemP1BG[i] != null)
				{
					this.Img_ItemP1BG[i].gameObject.SetActive(true);
				}
				if (this.Img_ItemP1BG2[i] != null)
				{
					this.Img_ItemP1BG2[i].gameObject.SetActive(false);
				}
				if (this.Img_ItemInputBG[i] != null)
				{
					this.Img_ItemInputBG[i].color = new Color(1f, 1f, 1f, 1f);
				}
				if (this.Img_ItemInputBG2[i] != null)
				{
					this.Img_ItemInputBG2[i].gameObject.SetActive(false);
				}
			}
			if (this.m_text_Translation != null)
			{
				this.m_text_Translation.color = new Color(0.3765f, 0.455f, 0.5176f);
			}
		}
		else
		{
			if (this.img_AMRank_BG != null && this.mNowPage == 0)
			{
				this.img_AMRank_BG.gameObject.SetActive(true);
				this.img_BG.color = new Color(1f, 1f, 1f, 0f);
			}
			if (this.img_AMRankNew_BG != null)
			{
				this.img_AMRankNew_BG.gameObject.SetActive(true);
			}
			if (this.img_AMRank_Letter != null)
			{
				this.img_AMRank_Letter.gameObject.SetActive(true);
			}
			if (this.img_AMRank_Member != null)
			{
				this.img_AMRank_Member.gameObject.SetActive(true);
			}
			if (this.img_AMRank_Application != null)
			{
				this.img_AMRank_Application.gameObject.SetActive(true);
			}
			if (this.img_AMRank_Gift != null)
			{
				this.img_AMRank_Gift.gameObject.SetActive(true);
			}
			for (int j = 0; j < 6; j++)
			{
				if (this.Img_ItemP1BG[j] != null)
				{
					this.Img_ItemP1BG[j].gameObject.SetActive(false);
				}
				if (this.Img_ItemP1BG2[j] != null)
				{
					this.Img_ItemP1BG2[j].gameObject.SetActive(true);
				}
				if (this.Img_ItemInputBG[j] != null)
				{
					this.Img_ItemInputBG[j].color = new Color(1f, 1f, 1f, 0f);
				}
				if (this.Img_ItemInputBG2[j] != null)
				{
					this.Img_ItemInputBG2[j].gameObject.SetActive(true);
				}
			}
			if (this.m_text_Translation != null)
			{
				this.m_text_Translation.color = new Color(0.5255f, 0.447f, 0.255f);
			}
			if (this.img_AMRank_BG2 != null && (this.tmpRank == 1 || this.tmpRank == 2) && this.mNowPage == 0)
			{
				this.img_AMRank_BG2.gameObject.SetActive(true);
			}
			if (this.img_AMRank1_F != null && this.DM.RoleAlliance.AMPlaceMainInfoUIShow == 1)
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
		}
	}

	// Token: 0x06000F0A RID: 3850 RVA: 0x001A5258 File Offset: 0x001A3458
	private byte GetAWRank()
	{
		return this.DM.RoleAlliance.AWRankMainInfoUIShow;
	}

	// Token: 0x06000F0B RID: 3851 RVA: 0x001A526C File Offset: 0x001A346C
	public void SetKingdomBtn(float tmpDelta = -1f)
	{
		float num;
		if (tmpDelta == -1f)
		{
			num = (float)((!this.btn_ActivityGift.gameObject.activeSelf) ? 0 : 70);
			if (this.DM.RoleAlliance.AMRankMainInfoUIShow >= 1 && this.DM.RoleAlliance.AMRankMainInfoUIShow <= 4)
			{
				num += 43f;
			}
			if (this.GetAWRank() >= 2)
			{
				num += 43f;
			}
		}
		else
		{
			num = tmpDelta;
		}
		RectTransform component = this.btn_KHint.gameObject.GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(144f + num, component.anchoredPosition.y);
		this.text_Alliance_K.rectTransform.anchoredPosition = new Vector2(component.anchoredPosition.x + 50f, this.text_Alliance_K.rectTransform.anchoredPosition.y);
		component.sizeDelta = new Vector2(50f + this.text_Alliance_K.preferredWidth + 1f, component.sizeDelta.y);
		if (this.GUIM.IsArabic)
		{
			this.text_Alliance_K.UpdateArabicPos();
		}
	}

	// Token: 0x06000F0C RID: 3852 RVA: 0x001A53B8 File Offset: 0x001A35B8
	public void CheckShowAMWBtn()
	{
		if (this.AMHint == null)
		{
			return;
		}
		float num = (float)((!this.btn_ActivityGift.gameObject.activeSelf) ? 0 : 66);
		if (this.DM.RoleAlliance.AMRankMainInfoUIShow >= 1 && this.DM.RoleAlliance.AMRankMainInfoUIShow <= 4)
		{
			RectTransform rectTransform = (RectTransform)this.AM1.gameObject.transform;
			rectTransform.anchoredPosition = new Vector2(-215.5f + num, rectTransform.anchoredPosition.y);
			num += 43f;
			this.AM1.SetSpriteIndex((int)this.DM.RoleAlliance.AMRankMainInfoUIShow);
			this.AM1.gameObject.SetActive(true);
		}
		else
		{
			this.AM1.gameObject.SetActive(false);
		}
		if (this.GetAWRank() >= 2)
		{
			RectTransform rectTransform = (RectTransform)this.AW1.gameObject.transform;
			rectTransform.anchoredPosition = new Vector2(-215.5f + num, rectTransform.anchoredPosition.y);
			num += 43f;
			byte b = (this.GetAWRank() - 1) / 5;
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
			StringManager.IntToStr(this.CStrAWRank, (long)this.GetAWRank(), 1, false);
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

	// Token: 0x06000F0D RID: 3853 RVA: 0x001A55B8 File Offset: 0x001A37B8
	public void SetAMWHint(bool bshow, Transform BtnT = null)
	{
		if (this.AMHint == null)
		{
			return;
		}
		if (bshow && BtnT)
		{
			this.AMWOpenBtnT = BtnT;
			byte b = 0;
			float num = 330f;
			float num2 = 0f;
			if (this.DM.RoleAlliance.AMRankMainInfoUIShow >= 1 && this.DM.RoleAlliance.AMRankMainInfoUIShow <= 4)
			{
				this.AM2.SetSpriteIndex((int)this.DM.RoleAlliance.AMRankMainInfoUIShow);
				this.AM2.gameObject.SetActive(true);
				if (this.CStrAMHint == null)
				{
					this.CStrAMHint = StringManager.Instance.SpawnString(300);
				}
				this.CStrAMHint.Length = 0;
				if (this.DM.RoleAlliance.AMPlaceMainInfoUIShow >= 1 && this.DM.RoleAlliance.AMPlaceMainInfoUIShow <= 100)
				{
					this.CStrAMHint.IntToFormat((long)this.DM.RoleAlliance.AMPlaceMainInfoUIShow, 1, false);
					this.CStrAMHint.AppendFormat(this.DM.mStringTable.GetStringByID(16152u));
				}
				else
				{
					this.CStrAMHint.StringToFormat(this.DM.mStringTable.GetStringByID(1033u - (uint)this.DM.RoleAlliance.AMRankMainInfoUIShow));
					this.CStrAMHint.AppendFormat(this.DM.mStringTable.GetStringByID(16150u));
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
			if (this.GetAWRank() >= 2)
			{
				if (b == 0)
				{
					rectTransform = (RectTransform)this.AW2.transform;
					rectTransform.anchoredPosition = new Vector2(39f, -71f);
					this.AWHint.rectTransform.anchoredPosition = new Vector2(91f, -60.6f);
				}
				byte b2 = (this.GetAWRank() - 1) / 5;
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
				StringManager.IntToStr(this.CStrAWRank, (long)this.GetAWRank(), 1, false);
				this.AWRank2.text = this.CStrAWRank.ToString();
				this.AWRank2.SetAllDirty();
				this.AWRank2.cachedTextGenerator.Invalidate();
				if (this.CStrAWHint == null)
				{
					this.CStrAWHint = StringManager.Instance.SpawnString(300);
				}
				this.CStrAWHint.Length = 0;
				this.CStrAWHint.IntToFormat((long)this.GetAWRank(), 1, false);
				this.CStrAWHint.AppendFormat(this.DM.mStringTable.GetStringByID(16151u));
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
			if (b == 0)
			{
				this.AMWHintGO.SetActive(false);
				return;
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
			this.AMWHintGO.SetActive(true);
		}
		else
		{
			this.AMWHintGO.SetActive(false);
		}
	}

	// Token: 0x04003156 RID: 12630
	private Transform GameT;

	// Token: 0x04003157 RID: 12631
	private Transform Tmp;

	// Token: 0x04003158 RID: 12632
	private Transform Tmp1;

	// Token: 0x04003159 RID: 12633
	private Transform Tmp2;

	// Token: 0x0400315A RID: 12634
	private Transform PageT;

	// Token: 0x0400315B RID: 12635
	private Transform BadgeT;

	// Token: 0x0400315C RID: 12636
	private Transform[] Pagedata = new Transform[3];

	// Token: 0x0400315D RID: 12637
	private Transform[] ItemPT1 = new Transform[6];

	// Token: 0x0400315E RID: 12638
	private Transform[] ItemPT2 = new Transform[6];

	// Token: 0x0400315F RID: 12639
	private Transform[] ItemPT_W1 = new Transform[6];

	// Token: 0x04003160 RID: 12640
	private Transform[] ItemPT_W2 = new Transform[6];

	// Token: 0x04003161 RID: 12641
	private Transform ItemT;

	// Token: 0x04003162 RID: 12642
	private RectTransform btnHelp_RT;

	// Token: 0x04003163 RID: 12643
	private RectTransform mContentRT;

	// Token: 0x04003164 RID: 12644
	private RectTransform[] btn_RT = new RectTransform[5];

	// Token: 0x04003165 RID: 12645
	private RectTransform[] PageImg_RT = new RectTransform[3];

	// Token: 0x04003166 RID: 12646
	private RectTransform[] PageText_RT = new RectTransform[3];

	// Token: 0x04003167 RID: 12647
	private RectTransform[] btnApplicationNum_RT = new RectTransform[2];

	// Token: 0x04003168 RID: 12648
	private RectTransform[] btnGiftNum_RT = new RectTransform[2];

	// Token: 0x04003169 RID: 12649
	private RectTransform[] btnMessageNum_RT = new RectTransform[2];

	// Token: 0x0400316A RID: 12650
	private RectTransform[] TranslationRT = new RectTransform[6];

	// Token: 0x0400316B RID: 12651
	private RectTransform m_TranslationRT;

	// Token: 0x0400316C RID: 12652
	private RectTransform[] btn_ItemRT = new RectTransform[5];

	// Token: 0x0400316D RID: 12653
	private UIButton btn_EXIT;

	// Token: 0x0400316E RID: 12654
	private UIButton[] btnPage = new UIButton[3];

	// Token: 0x0400316F RID: 12655
	private UIButton btn_Letter;

	// Token: 0x04003170 RID: 12656
	private UIButton btn_Member;

	// Token: 0x04003171 RID: 12657
	private UIButton btn_Application;

	// Token: 0x04003172 RID: 12658
	private UIButton btn_Gift;

	// Token: 0x04003173 RID: 12659
	private UIButton[] btn_InputField = new UIButton[6];

	// Token: 0x04003174 RID: 12660
	private UIButton[][] btn_Fun = new UIButton[6][];

	// Token: 0x04003175 RID: 12661
	private UIButton[] btn_Item = new UIButton[6];

	// Token: 0x04003176 RID: 12662
	private UIButton[] btn_Translation = new UIButton[6];

	// Token: 0x04003177 RID: 12663
	private UIButton m_btn_Translation;

	// Token: 0x04003178 RID: 12664
	private UIButton btn_Input_OK;

	// Token: 0x04003179 RID: 12665
	private UIButton btn_Input_C;

	// Token: 0x0400317A RID: 12666
	private UIButton btn_Input_Edit;

	// Token: 0x0400317B RID: 12667
	private UIButton btn_Help;

	// Token: 0x0400317C RID: 12668
	private UIButton btn_Transport;

	// Token: 0x0400317D RID: 12669
	private UIButton btn_Reinforce;

	// Token: 0x0400317E RID: 12670
	private UIButton btn_Cantonment;

	// Token: 0x0400317F RID: 12671
	private UIButton[] btn_ItemInput = new UIButton[6];

	// Token: 0x04003180 RID: 12672
	private UIButton[] btn_ItemHint = new UIButton[6];

	// Token: 0x04003181 RID: 12673
	private UIButtonHint[] mbtnH_Item = new UIButtonHint[6];

	// Token: 0x04003182 RID: 12674
	private UIButton btn_KHint;

	// Token: 0x04003183 RID: 12675
	private UIButton btn_ActivityGift;

	// Token: 0x04003184 RID: 12676
	private Image tmpImg;

	// Token: 0x04003185 RID: 12677
	private Image img_InputBG;

	// Token: 0x04003186 RID: 12678
	private Image[] img_PageBG = new Image[3];

	// Token: 0x04003187 RID: 12679
	private Image[][] img_Wonders = new Image[6][];

	// Token: 0x04003188 RID: 12680
	private Image[] img_ItemHint = new Image[6];

	// Token: 0x04003189 RID: 12681
	private Image img_KHint;

	// Token: 0x0400318A RID: 12682
	private Image[] Img_Translate = new Image[6];

	// Token: 0x0400318B RID: 12683
	private Image m_Img_Translate;

	// Token: 0x0400318C RID: 12684
	private Image[] img_ActivityGift = new Image[2];

	// Token: 0x0400318D RID: 12685
	private Image img_Title;

	// Token: 0x0400318E RID: 12686
	private Image img_BG;

	// Token: 0x0400318F RID: 12687
	private Image img_AMRank_Title;

	// Token: 0x04003190 RID: 12688
	private Image img_AMRank_BG;

	// Token: 0x04003191 RID: 12689
	private Image img_AMRank_BG2;

	// Token: 0x04003192 RID: 12690
	private Image img_AMRank_Letter;

	// Token: 0x04003193 RID: 12691
	private Image img_AMRank_Member;

	// Token: 0x04003194 RID: 12692
	private Image img_AMRank_Application;

	// Token: 0x04003195 RID: 12693
	private Image img_AMRank_Gift;

	// Token: 0x04003196 RID: 12694
	private Image img_AMRank1_F;

	// Token: 0x04003197 RID: 12695
	private Image img_AMRank_LF;

	// Token: 0x04003198 RID: 12696
	private Image img_AMRank_RF;

	// Token: 0x04003199 RID: 12697
	private Image img_AMRankNew_BG;

	// Token: 0x0400319A RID: 12698
	private Image[] Img_ItemInputBG = new Image[6];

	// Token: 0x0400319B RID: 12699
	private Image[] Img_ItemP1BG = new Image[6];

	// Token: 0x0400319C RID: 12700
	private Image[] Img_ItemInputBG2 = new Image[6];

	// Token: 0x0400319D RID: 12701
	private Image[] Img_ItemP1BG2 = new Image[6];

	// Token: 0x0400319E RID: 12702
	private UIRunningText img_text;

	// Token: 0x0400319F RID: 12703
	private UIText tmptext;

	// Token: 0x040031A0 RID: 12704
	private UIText text_Title;

	// Token: 0x040031A1 RID: 12705
	private UIText text_Alliance_K;

	// Token: 0x040031A2 RID: 12706
	private UIText text_Propaganda;

	// Token: 0x040031A3 RID: 12707
	private UIText text_AllianceName;

	// Token: 0x040031A4 RID: 12708
	private UIText text_AllianceChief;

	// Token: 0x040031A5 RID: 12709
	private UIText text_AllianceStrength;

	// Token: 0x040031A6 RID: 12710
	private UIText text_AllianceMember;

	// Token: 0x040031A7 RID: 12711
	private UIText text_InputCheck;

	// Token: 0x040031A8 RID: 12712
	private UIText[] text_PageNum = new UIText[3];

	// Token: 0x040031A9 RID: 12713
	private UIText text_btnApplicationNum;

	// Token: 0x040031AA RID: 12714
	private UIText[] text_btnGife = new UIText[2];

	// Token: 0x040031AB RID: 12715
	private UIText text_Input1;

	// Token: 0x040031AC RID: 12716
	private UIText text_Alliance_Money;

	// Token: 0x040031AD RID: 12717
	private UIText text_HelpNum;

	// Token: 0x040031AE RID: 12718
	private UIText text_MessageNum;

	// Token: 0x040031AF RID: 12719
	private UIText[][] text_ItembtnName = new UIText[6][];

	// Token: 0x040031B0 RID: 12720
	private UIText[] text_tmpStr = new UIText[10];

	// Token: 0x040031B1 RID: 12721
	private UIText[][] text_ItemName = new UIText[6][];

	// Token: 0x040031B2 RID: 12722
	private UIText[] text_ItemCDtime = new UIText[6];

	// Token: 0x040031B3 RID: 12723
	private UIText[] text_Item_K = new UIText[6];

	// Token: 0x040031B4 RID: 12724
	private UIText[][] text_ItemEffect = new UIText[6][];

	// Token: 0x040031B5 RID: 12725
	private UIText[] text_Item_Hint = new UIText[6];

	// Token: 0x040031B6 RID: 12726
	private UIText[] text_tmpItmeStr = new UIText[11];

	// Token: 0x040031B7 RID: 12727
	private UIText[] text_tmpItmeP2Str = new UIText[15];

	// Token: 0x040031B8 RID: 12728
	private UIText[] text_Trans = new UIText[6];

	// Token: 0x040031B9 RID: 12729
	private UIText[] text_Translation = new UIText[6];

	// Token: 0x040031BA RID: 12730
	private UIText m_text_Trans;

	// Token: 0x040031BB RID: 12731
	private UIText m_text_Translation;

	// Token: 0x040031BC RID: 12732
	private UIText m_text_ActivityGiftNum;

	// Token: 0x040031BD RID: 12733
	private UIText text_Title_AMP;

	// Token: 0x040031BE RID: 12734
	private UIEmojiInput mInput;

	// Token: 0x040031BF RID: 12735
	private UIEmojiInput[] mItemInput = new UIEmojiInput[6];

	// Token: 0x040031C0 RID: 12736
	private CString Cstr_Alliance_K;

	// Token: 0x040031C1 RID: 12737
	private CString Cstr_AllianceName;

	// Token: 0x040031C2 RID: 12738
	private CString Cstr_AllianceChief;

	// Token: 0x040031C3 RID: 12739
	private CString Cstr_AllianceStrength;

	// Token: 0x040031C4 RID: 12740
	private CString Cstr_AllianceMember;

	// Token: 0x040031C5 RID: 12741
	private CString Cstr_GifeLV;

	// Token: 0x040031C6 RID: 12742
	private CString Cstr_Alliance_Money;

	// Token: 0x040031C7 RID: 12743
	private CString Cstr_Null;

	// Token: 0x040031C8 RID: 12744
	private CString[] Cstr_Item_K = new CString[6];

	// Token: 0x040031C9 RID: 12745
	private CString[] Cstr_Item_Time = new CString[6];

	// Token: 0x040031CA RID: 12746
	private CString[][] Cstr_ItemEffect = new CString[6][];

	// Token: 0x040031CB RID: 12747
	private CString Cstr_Translation;

	// Token: 0x040031CC RID: 12748
	private GameObject AMWHintGO;

	// Token: 0x040031CD RID: 12749
	private UISpritesArray AM1;

	// Token: 0x040031CE RID: 12750
	private UISpritesArray AW1;

	// Token: 0x040031CF RID: 12751
	private UISpritesArray AM2;

	// Token: 0x040031D0 RID: 12752
	private UISpritesArray AW2;

	// Token: 0x040031D1 RID: 12753
	private UIText AWRank1;

	// Token: 0x040031D2 RID: 12754
	private UIText AWRank2;

	// Token: 0x040031D3 RID: 12755
	private UIText AMHint;

	// Token: 0x040031D4 RID: 12756
	private UIText AWHint;

	// Token: 0x040031D5 RID: 12757
	private UIText AMWTitle;

	// Token: 0x040031D6 RID: 12758
	private CString CStrAWRank;

	// Token: 0x040031D7 RID: 12759
	private CString CStrAMHint;

	// Token: 0x040031D8 RID: 12760
	private CString CStrAWHint;

	// Token: 0x040031D9 RID: 12761
	private Transform AMWOpenBtnT;

	// Token: 0x040031DA RID: 12762
	private DataManager DM;

	// Token: 0x040031DB RID: 12763
	private GUIManager GUIM;

	// Token: 0x040031DC RID: 12764
	private UISpritesArray SArray;

	// Token: 0x040031DD RID: 12765
	private Font TTFont;

	// Token: 0x040031DE RID: 12766
	private Door door;

	// Token: 0x040031DF RID: 12767
	private Material FrameMaterial;

	// Token: 0x040031E0 RID: 12768
	private GameObject go;

	// Token: 0x040031E1 RID: 12769
	private bool bshowbtn1;

	// Token: 0x040031E2 RID: 12770
	private bool bcheckInput;

	// Token: 0x040031E3 RID: 12771
	private int mNowPage = 3;

	// Token: 0x040031E4 RID: 12772
	private Vector2[] btn_Pos = new Vector2[5];

	// Token: 0x040031E5 RID: 12773
	private float PageBGTime;

	// Token: 0x040031E6 RID: 12774
	private UIAlliance_Marshal MarshalInst;

	// Token: 0x040031E7 RID: 12775
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040031E8 RID: 12776
	private CScrollRect m_ScrollRect;

	// Token: 0x040031E9 RID: 12777
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[6];

	// Token: 0x040031EA RID: 12778
	private List<float> tmplist = new List<float>();

	// Token: 0x040031EB RID: 12779
	private float tmpHeight;

	// Token: 0x040031EC RID: 12780
	private bool bShowTranslate;

	// Token: 0x040031ED RID: 12781
	private float tmpTransH;

	// Token: 0x040031EE RID: 12782
	public int[] mWonderEffect = new int[7];

	// Token: 0x040031EF RID: 12783
	private bool bOpenCheck;

	// Token: 0x040031F0 RID: 12784
	private bool bOpenEnd;

	// Token: 0x040031F1 RID: 12785
	private UISpritesArray ImgSA_LF;

	// Token: 0x040031F2 RID: 12786
	private UISpritesArray ImgSA_RF;

	// Token: 0x040031F3 RID: 12787
	private byte tmpRank;
}
