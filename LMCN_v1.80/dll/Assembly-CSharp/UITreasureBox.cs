using System;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x020006A5 RID: 1701
public class UITreasureBox : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x0600208C RID: 8332 RVA: 0x003DC018 File Offset: 0x003DA218
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.MM = MallManager.Instance;
		this.TTFont = this.GUIM.GetTTFFont();
		this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		this.GameT = base.gameObject.transform;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.GameT.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.GameT.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.Cstr_Time = StringManager.Instance.SpawnString(30);
		this.Cstr_Count = StringManager.Instance.SpawnString(150);
		this.Cstr_Info = StringManager.Instance.SpawnString(100);
		this.Cstr_Info2 = StringManager.Instance.SpawnString(30);
		this.Cstr_Get = StringManager.Instance.SpawnString(30);
		this.Cstr_Get2[0] = StringManager.Instance.SpawnString(30);
		this.Cstr_Get2[1] = StringManager.Instance.SpawnString(150);
		this.Cstr_Score = StringManager.Instance.SpawnString(150);
		for (int i = 0; i < 8; i++)
		{
			this.Cstr_Items[i] = StringManager.Instance.SpawnString(30);
		}
		this.Cstr_Items[8] = StringManager.Instance.SpawnString(150);
		this.Cstr_P10Time = StringManager.Instance.SpawnString(150);
		this.Cstr_P10Num = StringManager.Instance.SpawnString(30);
		this.mKind = arg1;
		this.mGetType = arg2;
		Array.Clear(this.tmpfValue, 0, this.tmpfValue.Length);
		this.P1_T = this.GameT.GetChild(0);
		this.LightP1_T = this.P1_T.GetChild(0);
		this.Tmp = this.P1_T.GetChild(2).GetChild(0);
		this.text_Time = this.Tmp.GetComponent<UIText>();
		this.text_Time.font = this.TTFont;
		this.Tmp = this.P1_T.GetChild(3).GetChild(0);
		this.text_Count = this.Tmp.GetComponent<UIText>();
		this.text_Count.font = this.TTFont;
		this.Tmp = this.P1_T.GetChild(4);
		this.btn_OK = this.Tmp.GetComponent<UIButton>();
		this.btn_OK.m_Handler = this;
		this.btn_OK.m_BtnID1 = 1;
		this.btn_OK.m_EffectType = e_EffectType.e_Scale;
		this.btn_OK.transition = Selectable.Transition.None;
		this.Tmp = this.P1_T.GetChild(4).GetChild(0);
		this.text_tmpStr[0] = this.Tmp.GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7671u);
		this.P2_T = this.GameT.GetChild(1);
		this.Tmp = this.P2_T.GetChild(3);
		this.Hbtn_Item = this.Tmp.GetComponent<UIHIBtn>();
		this.Hbtn_Item.m_Handler = this;
		this.Tmp = this.P2_T.GetChild(4);
		this.btn_Get = this.Tmp.GetComponent<UIButton>();
		this.btn_Get.m_Handler = this;
		this.btn_Get.m_BtnID1 = 2;
		this.btn_Get.m_EffectType = e_EffectType.e_Scale;
		this.btn_Get.transition = Selectable.Transition.None;
		this.Tmp = this.P2_T.GetChild(4).GetChild(0);
		this.text_tmpStr[1] = this.Tmp.GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(7693u);
		this.mCount1_T = this.P2_T.GetChild(5);
		this.text_Get2[0] = this.mCount1_T.GetChild(0).GetComponent<UIText>();
		this.text_Get2[0].font = this.TTFont;
		this.text_Get2[1] = this.mCount1_T.GetChild(1).GetComponent<UIText>();
		this.text_Get2[1].font = this.TTFont;
		this.mCount2_T = this.P2_T.GetChild(6);
		this.text_Get = this.mCount2_T.GetChild(0).GetComponent<UIText>();
		this.text_Get.font = this.TTFont;
		this.P3_T = this.GameT.GetChild(2);
		this.P4_T = this.GameT.GetChild(3);
		this.P5_T = this.GameT.GetChild(4);
		this.P6_T = this.GameT.GetChild(5);
		this.P7_T = this.GameT.GetChild(6);
		this.P8_T = this.GameT.GetChild(7);
		this.P9_T = this.GameT.GetChild(8);
		this.P10_T = this.GameT.GetChild(9);
		int index = this.GameT.childCount - 1;
		this.Tmp = this.GameT.GetChild(index).GetChild(0);
		this.Img_5X = this.Tmp.GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_5X.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.Tmp = this.GameT.GetChild(index).GetChild(1);
		this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.Tmp = this.GameT.GetChild(index).GetChild(2);
		this.text_Title = this.Tmp.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.text = this.DM.mStringTable.GetStringByID(7669u);
		this.Tmp = this.GameT.GetChild(index).GetChild(3);
		this.text_Info = this.Tmp.GetComponent<UIText>();
		this.text_Info.font = this.TTFont;
		this.Info_RT = this.Tmp.GetComponent<RectTransform>();
		this.OutsideExitBtn = base.gameObject.AddComponent<HelperUIButton>();
		this.OutsideExitBtn.m_Handler = this;
		this.OutsideExitBtn.m_BtnID1 = 0;
		this.OutsideExitBtn.enabled = false;
		switch (this.mKind)
		{
		case 0:
		{
			this.OutsideExitBtn.enabled = true;
			this.P1_T.gameObject.SetActive(true);
			this.Cstr_Time.ClearString();
			long num = this.DM.RoleAttr.NextOnlineGiftOpenTime - this.DM.ServerTime;
			GameConstants.GetTimeString(this.Cstr_Time, (uint)num, false, false, true, false, true);
			this.text_Time.text = this.Cstr_Time.ToString();
			this.text_Time.SetAllDirty();
			this.text_Time.cachedTextGenerator.Invalidate();
			this.Cstr_Count.ClearString();
			if (this.DM.RoleAttr.OnlineGiftOpenTimes == 19)
			{
				this.Img_5X.gameObject.SetActive(true);
				this.Cstr_Count.Append(this.DM.mStringTable.GetStringByID(8258u));
			}
			else
			{
				this.Cstr_Count.IntToFormat((long)(20 - this.DM.RoleAttr.OnlineGiftOpenTimes), 1, true);
				this.Cstr_Count.AppendFormat(this.DM.mStringTable.GetStringByID(7677u));
			}
			this.text_Count.text = this.Cstr_Count.ToString();
			this.text_Count.SetAllDirty();
			this.text_Count.cachedTextGenerator.Invalidate();
			this.text_Info.text = this.DM.mStringTable.GetStringByID(7670u);
			this.text_Info.SetAllDirty();
			this.text_Info.cachedTextGenerator.Invalidate();
			break;
		}
		case 1:
		case 2:
			this.TimeOutSet();
			break;
		case 3:
			this.SetHeroPage((ushort)arg2);
			GUIManager.Instance.LoadLvUpLight(base.transform);
			break;
		case 4:
			this.SetScore();
			break;
		case 5:
			this.SetFB_Reward();
			break;
		case 6:
			this.btn_EXIT.gameObject.SetActive(false);
			this.SetHeroPage(true);
			GUIManager.Instance.LoadLvUpLight(base.transform);
			break;
		case 7:
			this.btn_EXIT.gameObject.SetActive(false);
			this.SetHeroPage(false);
			GUIManager.Instance.LoadLvUpLight(base.transform);
			break;
		case 8:
			this.btn_EXIT.gameObject.SetActive(false);
			this.P1_T.gameObject.SetActive(false);
			this.P2_T.gameObject.SetActive(false);
			this.P3_T.gameObject.SetActive(true);
			this.Light1_T = this.P3_T.GetChild(0);
			this.Light2_T = this.P3_T.GetChild(1);
			this.Tmp = this.P3_T.GetChild(3);
			this.Hbtn_Item2 = this.Tmp.GetComponent<UIHIBtn>();
			this.Hbtn_Item2.m_Handler = this;
			this.Hbtn_Item2.gameObject.SetActive(false);
			this.Tmp = this.P3_T.GetChild(4);
			this.Tmp.gameObject.SetActive(true);
			this.Tmp = this.P3_T.GetChild(5);
			this.text_GetType = this.Tmp.GetComponent<UIText>();
			this.text_GetType.font = this.TTFont;
			this.text_GetType.gameObject.SetActive(false);
			this.Cstr_Info.ClearString();
			this.text_Title.text = this.DM.mStringTable.GetStringByID(7385u);
			this.Cstr_Info.StringToFormat(this.DM.mStringTable.GetStringByID(3393u));
			this.Cstr_Info.AppendFormat("{0}");
			this.text_Info.text = this.Cstr_Info.ToString();
			this.text_Info.SetAllDirty();
			this.text_Info.cachedTextGenerator.Invalidate();
			GUIManager.Instance.LoadLvUpLight(base.transform);
			break;
		case 9:
		{
			this.OutsideExitBtn.enabled = true;
			this.P7_T.gameObject.SetActive(true);
			this.LightP1_T = this.P7_T.GetChild(0);
			this.text_Title.text = this.DM.mStringTable.GetStringByID(9141u);
			this.text_Time = this.P7_T.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.Cstr_Time.ClearString();
			this.text_Time.font = this.TTFont;
			this.Cstr_Time.ClearString();
			DateTime dateTime = GameConstants.GetDateTime(this.DM.ServerTime).ToUniversalTime();
			uint num2;
			if (dateTime.Hour + -5 < 0)
			{
				num2 = (uint)((dateTime.Hour + 19) * 3600 + dateTime.Minute * 60 + dateTime.Second);
			}
			else
			{
				num2 = (uint)((dateTime.Hour + -5) * 3600 + dateTime.Minute * 60 + dateTime.Second);
			}
			uint num3 = 10800u - num2 % 10800u;
			this.Cstr_Time.IntToFormat((long)((ulong)(num3 / 3600u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num3 % 3600u / 60u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num3 % 60u)), 2, false);
			this.Cstr_Time.AppendFormat("{0}:{1}:{2}");
			this.text_Time.text = this.Cstr_Time.ToString();
			this.text_Time.SetAllDirty();
			this.text_Time.cachedTextGenerator.Invalidate();
			Image component = this.P7_T.GetChild(2).GetComponent<Image>();
			this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
			component.sprite = this.door.LoadSprite("UI_main_money_02");
			component.material = this.door.LoadMaterial();
			this.text_Arena[0] = this.P7_T.GetChild(2).GetChild(0).GetComponent<UIText>();
			this.text_Arena[0].font = this.TTFont;
			this.text_Arena[0].text = this.DM.mStringTable.GetStringByID(9158u);
			if (this.text_Arena[0].preferredWidth > this.text_Arena[0].rectTransform.sizeDelta.x)
			{
				if (this.text_Arena[0].preferredWidth <= 230f)
				{
					this.text_Arena[0].rectTransform.sizeDelta = new Vector2(this.text_Arena[0].preferredWidth, this.text_Arena[0].rectTransform.sizeDelta.y);
				}
				else
				{
					this.text_Arena[0].rectTransform.sizeDelta = new Vector2(230f, this.text_Arena[0].rectTransform.sizeDelta.y);
				}
				if (this.text_Arena[0].preferredWidth > 160f)
				{
					component.rectTransform.anchoredPosition = new Vector2(component.rectTransform.anchoredPosition.x + (this.text_Arena[0].preferredWidth - 100f) / 2f, component.rectTransform.anchoredPosition.y);
				}
			}
			if (ArenaManager.Instance.CheckArenaClose() > 0)
			{
				this.text_Time.transform.parent.gameObject.SetActive(false);
				this.text_Arena[0].transform.parent.gameObject.SetActive(false);
			}
			this.text_Arena[1] = this.P7_T.GetChild(2).GetChild(1).GetComponent<UIText>();
			this.text_Arena[1].font = this.TTFont;
			num2 = (uint)ArenaManager.Instance.GetNowCrystal();
			this.Cstr_Info.ClearString();
			this.Cstr_Info.IntToFormat((long)((ulong)num2), 1, true);
			this.Cstr_Info.AppendFormat("{0}");
			this.text_Arena[1].text = this.Cstr_Info.ToString();
			this.btn_ArenaReward = this.P7_T.GetChild(3).GetComponent<UIButton>();
			this.btn_ArenaReward.m_Handler = this;
			this.btn_ArenaReward.m_BtnID1 = 5;
			this.btn_ArenaReward.m_EffectType = e_EffectType.e_Scale;
			this.btn_ArenaReward.transition = Selectable.Transition.None;
			this.text_ArenaReward = this.P7_T.GetChild(3).GetChild(0).GetComponent<UIText>();
			this.text_ArenaReward.font = this.TTFont;
			this.text_ArenaReward.text = this.DM.mStringTable.GetStringByID(9143u);
			this.Hbtn_Item2 = this.P7_T.GetChild(4).GetComponent<UIHIBtn>();
			this.Hbtn_Item2.m_Handler = this;
			this.GUIM.InitianHeroItemImg(this.Hbtn_Item2.transform, eHeroOrItem.Item, 1224, 0, 0, 0, false, false, true, false);
			this.text_ArenaRewardNum = this.P7_T.GetChild(5).GetComponent<UIText>();
			this.text_ArenaRewardNum.font = this.TTFont;
			this.Cstr_Info2.ClearString();
			this.Cstr_Info2.IntToFormat((long)((ulong)ArenaManager.Instance.m_ArenaCrystalPrize), 1, true);
			this.Cstr_Info2.AppendFormat("{0}");
			this.text_ArenaRewardNum.text = this.Cstr_Info2.ToString();
			this.text_ArenaRewardNum.SetAllDirty();
			this.text_ArenaRewardNum.cachedTextGenerator.Invalidate();
			this.text_ArenaRewardNum.gameObject.SetActive(true);
			this.text_ArenaReward_Get = this.P7_T.GetChild(6).GetComponent<UIText>();
			this.text_ArenaReward_Get.font = this.TTFont;
			if (ArenaManager.Instance.m_ArenaCrystalPrize > 0u)
			{
				this.text_ArenaReward.text = this.DM.mStringTable.GetStringByID(9143u);
				this.text_ArenaReward_Get.text = this.DM.mStringTable.GetStringByID(9142u);
				this.text_ArenaRewardNum.gameObject.SetActive(true);
			}
			else
			{
				this.text_ArenaReward.text = this.DM.mStringTable.GetStringByID(7671u);
				this.text_ArenaReward_Get.text = this.DM.mStringTable.GetStringByID(9164u);
				this.text_ArenaRewardNum.gameObject.SetActive(false);
			}
			this.text_ArenaReward.SetAllDirty();
			this.text_ArenaReward.cachedTextGenerator.Invalidate();
			this.text_ArenaReward_Get.SetAllDirty();
			this.text_ArenaReward_Get.cachedTextGenerator.Invalidate();
			break;
		}
		case 10:
			this.OutsideExitBtn.enabled = true;
			this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
			this.RefreshIndemnifyResources();
			for (int j = 0; j < 4; j++)
			{
				Image component2 = this.P8_T.GetChild(1 + j).GetComponent<Image>();
				this.LoadCustomImage(component2, this.ResIcon[j], null);
				component2.SetNativeSize();
			}
			this.btn_Indemnify = this.P8_T.GetChild(0).GetComponent<UIButton>();
			this.btn_Indemnify.m_Handler = this;
			this.btn_Indemnify.m_BtnID1 = 6;
			this.BtnName = this.P8_T.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.BtnName.font = this.TTFont;
			this.BtnName.text = this.DM.mStringTable.GetStringByID(1520u);
			this.text_Title.text = this.DM.mStringTable.GetStringByID(8594u);
			this.P8_T.gameObject.SetActive(true);
			break;
		case 11:
		{
			this.OutsideExitBtn.enabled = true;
			this.btn_CardReward = this.P9_T.GetChild(0).GetComponent<UIButton>();
			this.btn_CardReward.m_Handler = this;
			this.btn_CardReward.m_BtnID1 = 7;
			this.btn_CardReward.m_EffectType = e_EffectType.e_Scale;
			this.btn_CardReward.transition = Selectable.Transition.None;
			this.BtnName = this.P9_T.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.BtnName.font = this.TTFont;
			this.BtnName.text = this.DM.mStringTable.GetStringByID(1520u);
			this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
			Image component3 = this.P9_T.GetChild(1).GetComponent<Image>();
			component3.sprite = this.door.LoadSprite("UI_main_money_02_big");
			component3.material = this.door.LoadMaterial();
			component3.SetNativeSize();
			this.text_Cards[0] = this.P9_T.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.text_Cards[0].font = this.TTFont;
			this.Cstr_Items[0].ClearString();
			this.Cstr_Items[0].IntToFormat((long)((ulong)this.MM.mMonthTreasureCrystal), 1, false);
			this.Cstr_Items[0].AppendFormat("{0}");
			this.text_Cards[0].text = this.Cstr_Items[0].ToString();
			for (int k = 0; k < 7; k++)
			{
				this.Hbtn_Items[k] = this.P9_T.GetChild(2 + k).GetComponent<UIHIBtn>();
				this.Hbtn_Items[k].m_Handler = this;
				this.GUIM.InitianHeroItemImg(this.Hbtn_Items[k].transform, eHeroOrItem.Item, this.MM.mMonthTreasureItem[k].ItemID, 0, this.MM.mMonthTreasureItem[k].ItemRank, 0, true, true, true, false);
				this.text_Cards[k + 1] = this.P9_T.GetChild(9 + k).GetComponent<UIText>();
				this.text_Cards[k + 1].font = this.TTFont;
				this.Cstr_Items[k + 1].ClearString();
				this.Cstr_Items[k + 1].IntToFormat((long)this.MM.mMonthTreasureItem[k].Num, 1, false);
				if (this.GUIM.IsArabic)
				{
					this.Cstr_Items[k + 1].AppendFormat("{0}x");
				}
				else
				{
					this.Cstr_Items[k + 1].AppendFormat("x{0}");
				}
				this.text_Cards[k + 1].text = this.Cstr_Items[k + 1].ToString();
			}
			this.Cstr_Items[8].ClearString();
			this.text_Cards[8] = this.P9_T.GetChild(16).GetComponent<UIText>();
			this.text_Cards[8].font = this.TTFont;
			if (this.MM.BuyMonthTreasureTime != 0L && this.MM.LastGetMonthTreasurePrizeTime == 0L)
			{
				this.Cstr_Items[8].IntToFormat(30L, 1, true);
			}
			else
			{
				this.Cstr_Items[8].IntToFormat(29L - (this.MM.LastGetMonthTreasurePrizeTime - this.MM.BuyMonthTreasureTime) / 86400L, 1, true);
			}
			this.Cstr_Items[8].AppendFormat(this.DM.mStringTable.GetStringByID(922u));
			this.text_Cards[8].text = this.Cstr_Items[8].ToString();
			this.text_Cards[8].SetAllDirty();
			this.text_Cards[8].cachedTextGenerator.Invalidate();
			this.P9_T.gameObject.SetActive(true);
			this.text_Title.text = this.DM.mStringTable.GetStringByID(921u);
			break;
		}
		case 12:
			this.SetHeroPage();
			this.Img_5X.transform.parent.gameObject.SetActive(false);
			break;
		}
	}

	// Token: 0x0600208D RID: 8333 RVA: 0x003DD74C File Offset: 0x003DB94C
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		if (this.door)
		{
			img.sprite = this.door.LoadSprite(ImageName);
			img.material = this.door.LoadMaterial();
		}
	}

	// Token: 0x0600208E RID: 8334 RVA: 0x003DD78C File Offset: 0x003DB98C
	public void RefreshIndemnifyResources()
	{
		if (this.mKind != 10)
		{
			return;
		}
		Indemnify instance = Indemnify.Instance;
		for (int i = 0; i < 4; i++)
		{
			if (this.TextIndemnify[i] == null)
			{
				this.TextIndemnify[i] = this.P8_T.GetChild(5 + i).GetComponent<UIText>();
				this.TextIndemnify[i].font = this.TTFont;
				this.TextIndemnify[i].resizeTextForBestFit = true;
				this.TextIndemnify[i].resizeTextMaxSize = 24;
			}
			if (this.CStr_Indemnify[i] == null)
			{
				this.CStr_Indemnify[i] = StringManager.Instance.SpawnString(30);
			}
			if (instance.ResourceCache[i] != 0L)
			{
				this.CStr_Indemnify[i].ClearString();
				this.CStr_Indemnify[i].IntToFormat(instance.ResourceCache[i], 1, true);
				this.CStr_Indemnify[i].AppendFormat("{0}");
				this.TextIndemnify[i].text = this.CStr_Indemnify[i].ToString();
			}
			else
			{
				this.TextIndemnify[i].text = "-";
			}
			this.TextIndemnify[i].SetAllDirty();
			this.TextIndemnify[i].cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x0600208F RID: 8335 RVA: 0x003DD8D4 File Offset: 0x003DBAD4
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.mKind == 0)
		{
			long num = this.DM.RoleAttr.NextOnlineGiftOpenTime - this.DM.ServerTime;
			if (num <= 0L)
			{
				this.mKind = 1;
				this.TimeOutSet();
			}
			this.Cstr_Time.ClearString();
			GameConstants.GetTimeString(this.Cstr_Time, (uint)num, false, false, true, false, true);
			this.text_Time.text = this.Cstr_Time.ToString();
			this.text_Time.SetAllDirty();
			this.text_Time.cachedTextGenerator.Invalidate();
		}
		else if (this.mKind == 9 && !ArenaManager.Instance.bArenaKVK)
		{
			DateTime dateTime = GameConstants.GetDateTime(this.DM.ServerTime).ToUniversalTime();
			this.Cstr_Time.ClearString();
			uint num2;
			if (dateTime.Hour + -5 < 0)
			{
				num2 = (uint)((dateTime.Hour + 19) * 3600 + dateTime.Minute * 60 + dateTime.Second);
			}
			else
			{
				num2 = (uint)((dateTime.Hour + -5) * 3600 + dateTime.Minute * 60 + dateTime.Second);
			}
			uint num3 = 10800u - num2 % 10800u;
			this.Cstr_Time.IntToFormat((long)((ulong)(num3 / 3600u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num3 % 3600u / 60u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num3 % 60u)), 2, false);
			this.Cstr_Time.AppendFormat("{0}:{1}:{2}");
			this.text_Time.text = this.Cstr_Time.ToString();
			this.text_Time.SetAllDirty();
			this.text_Time.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06002090 RID: 8336 RVA: 0x003DDAA4 File Offset: 0x003DBCA4
	public void TimeOutSet()
	{
		if (this.mKind == 1)
		{
			this.P1_T.gameObject.SetActive(false);
			this.P2_T.gameObject.SetActive(true);
			this.Cstr_Info.ClearString();
			switch (this.mGetType)
			{
			case 0:
				this.OutsideExitBtn.enabled = true;
				this.DM.TreasureBox_CDTime = 0f;
				this.GUIM.InitianHeroItemImg(this.Hbtn_Item.transform, eHeroOrItem.Item, this.DM.EquipTable.GetRecordByKey(this.DM.RoleAttr.OnlineGiftItemID.ItemID).EquipKey, 0, 0, 0, true, true, true, false);
				if (this.DM.RoleAttr.OnlineGiftOpenTimes == 19)
				{
					this.Img_5X.gameObject.SetActive(true);
				}
				this.Cstr_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(this.DM.RoleAttr.OnlineGiftItemID.ItemID).EquipName));
				this.Cstr_Info.AppendFormat(this.DM.mStringTable.GetStringByID(7675u));
				if (this.DM.RoleAttr.OnlineGiftItemID.Quantity > 1)
				{
					if (this.DM.RoleAttr.OnlineGiftOpenTimes == 19)
					{
						this.mCount1_T.gameObject.SetActive(false);
						this.mCount2_T.gameObject.SetActive(true);
						this.Cstr_Get.ClearString();
						this.Cstr_Get.IntToFormat((long)this.DM.RoleAttr.OnlineGiftItemID.Quantity, 1, true);
						this.Cstr_Get.AppendFormat(this.DM.mStringTable.GetStringByID(7676u));
						this.text_Get.text = this.Cstr_Get.ToString();
						this.text_Get.SetAllDirty();
						this.text_Get.cachedTextGenerator.Invalidate();
					}
					else
					{
						this.mCount1_T.gameObject.SetActive(true);
						this.mCount2_T.gameObject.SetActive(false);
						this.Cstr_Get2[0].ClearString();
						this.Cstr_Get2[0].IntToFormat((long)this.DM.RoleAttr.OnlineGiftItemID.Quantity, 1, true);
						this.Cstr_Get2[0].AppendFormat(this.DM.mStringTable.GetStringByID(7676u));
						this.text_Get2[0].text = this.Cstr_Get2[0].ToString();
						this.text_Get2[0].SetAllDirty();
						this.text_Get2[0].cachedTextGenerator.Invalidate();
					}
				}
				if (this.DM.RoleAttr.OnlineGiftOpenTimes != 19)
				{
					this.Cstr_Get2[1].ClearString();
					this.Cstr_Get2[1].IntToFormat((long)(20 - this.DM.RoleAttr.OnlineGiftOpenTimes), 1, true);
					this.Cstr_Get2[1].AppendFormat(this.DM.mStringTable.GetStringByID(7677u));
					this.text_Get2[1].text = this.Cstr_Get2[1].ToString();
					this.text_Get2[1].SetAllDirty();
					this.text_Get2[1].cachedTextGenerator.Invalidate();
				}
				break;
			case 1:
				this.Cstr_Info.IntToFormat((long)((ulong)this.DM.m_Maintain), 1, false);
				this.Cstr_Info.AppendFormat(this.DM.mStringTable.GetStringByID(8473u));
				this.GUIM.InitianHeroItemImg(this.Hbtn_Item.transform, eHeroOrItem.Item, 1224, 0, 0, 0, false, false, true, false);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8406u);
				this.mCount1_T.gameObject.SetActive(false);
				this.mCount2_T.gameObject.SetActive(true);
				this.text_Get.text = this.DM.mStringTable.GetStringByID(8472u).ToString();
				this.text_Get.SetAllDirty();
				this.text_Get.cachedTextGenerator.Invalidate();
				break;
			case 2:
				this.Cstr_Info.IntToFormat((long)((ulong)this.DM.m_UpdateVersion), 1, false);
				this.Cstr_Info.AppendFormat(this.DM.mStringTable.GetStringByID(8473u));
				this.GUIM.InitianHeroItemImg(this.Hbtn_Item.transform, eHeroOrItem.Item, 1224, 0, 0, 0, false, false, true, false);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8406u);
				this.mCount1_T.gameObject.SetActive(false);
				this.mCount2_T.gameObject.SetActive(true);
				this.text_Get.text = this.DM.mStringTable.GetStringByID(8471u).ToString();
				this.text_Get.SetAllDirty();
				this.text_Get.cachedTextGenerator.Invalidate();
				break;
			}
			this.Light1_T = this.P2_T.GetChild(0);
			this.Light2_T = this.P2_T.GetChild(1);
		}
		else if (this.mKind == 2)
		{
			this.P1_T.gameObject.SetActive(false);
			this.P2_T.gameObject.SetActive(false);
			this.P3_T.gameObject.SetActive(true);
			this.Light1_T = this.P3_T.GetChild(0);
			this.Light2_T = this.P3_T.GetChild(1);
			this.Tmp = this.P3_T.GetChild(3);
			this.Hbtn_Item2 = this.Tmp.GetComponent<UIHIBtn>();
			this.Hbtn_Item2.m_Handler = this;
			this.Tmp = this.P3_T.GetChild(5);
			this.text_GetType = this.Tmp.GetComponent<UIText>();
			this.text_GetType.font = this.TTFont;
			this.Cstr_Info.ClearString();
			GUIManager instance = GUIManager.Instance;
			switch (this.mGetType)
			{
			case 0:
				this.GUIM.InitianHeroItemImg(this.Hbtn_Item2.transform, eHeroOrItem.Item, 1228, 0, 0, 0, true, true, true, false);
				this.text_GetType.text = this.DM.mStringTable.GetStringByID(748u);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8406u);
				this.Cstr_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(1228).EquipName));
				this.Cstr_Info.AppendFormat("{0}");
				instance.m_SpeciallyEffect.mDiamondValue = 250u;
				break;
			case 1:
				this.GUIM.InitianHeroItemImg(this.Hbtn_Item2.transform, eHeroOrItem.Item, 1226, 0, 0, 0, true, true, true, false);
				this.text_GetType.text = this.DM.mStringTable.GetStringByID(8419u);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(8406u);
				this.Cstr_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(1226).EquipName));
				this.Cstr_Info.AppendFormat("{0}");
				instance.m_SpeciallyEffect.mDiamondValue = 200u;
				break;
			case 2:
			{
				this.GUIM.InitianHeroItemImg(this.Hbtn_Item2.transform, eHeroOrItem.Item, 1226, 0, 0, 0, true, true, true, false);
				if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
				{
					this.text_GetType.text = this.DM.mStringTable.GetStringByID(11175u);
				}
				else
				{
					this.text_GetType.text = this.DM.mStringTable.GetStringByID(7386u);
				}
				this.text_Title.text = this.DM.mStringTable.GetStringByID(7385u);
				if (this.text_GetType.preferredWidth > 200f)
				{
					this.text_GetType.rectTransform.sizeDelta = new Vector2(340f, this.text_GetType.rectTransform.sizeDelta.y);
					if (this.text_GetType.preferredWidth > 340f)
					{
						this.text_GetType.rectTransform.sizeDelta = new Vector2(340f, this.text_GetType.preferredHeight + 1f);
					}
				}
				this.text_GetType.alignment = TextAnchor.MiddleLeft;
				RectTransform component = this.P3_T.GetComponent<RectTransform>();
				component.sizeDelta = new Vector2(component.sizeDelta.x, component.sizeDelta.y + this.text_GetType.preferredHeight + 1f - 33f);
				this.Cstr_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(1226).EquipName));
				this.Cstr_Info.AppendFormat("{0}");
				instance.m_SpeciallyEffect.mDiamondValue = 200u;
				break;
			}
			case 3:
			{
				this.GUIM.InitianHeroItemImg(this.Hbtn_Item2.transform, eHeroOrItem.Item, 1226, 0, 0, 0, true, true, true, false);
				this.text_GetType.text = this.DM.mStringTable.GetStringByID(7388u);
				this.text_Title.text = this.DM.mStringTable.GetStringByID(7385u);
				if (this.text_GetType.preferredWidth > 200f)
				{
					this.text_GetType.rectTransform.sizeDelta = new Vector2(340f, this.text_GetType.rectTransform.sizeDelta.y);
					if (this.text_GetType.preferredWidth > 340f)
					{
						this.text_GetType.rectTransform.sizeDelta = new Vector2(340f, this.text_GetType.preferredHeight + 1f);
					}
				}
				this.text_GetType.alignment = TextAnchor.MiddleLeft;
				RectTransform component2 = this.P3_T.GetComponent<RectTransform>();
				component2.sizeDelta = new Vector2(component2.sizeDelta.x, component2.sizeDelta.y + this.text_GetType.preferredHeight + 1f - 33f);
				this.Cstr_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(1226).EquipName));
				this.Cstr_Info.AppendFormat("{0}");
				instance.m_SpeciallyEffect.mDiamondValue = 200u;
				break;
			}
			}
			int num = 0;
			Array.Clear(instance.SE_Kind, 0, instance.SE_Kind.Length);
			instance.SE_Kind[num] = SpeciallyEffect_Kind.Diamond;
			num++;
			Array.Clear(instance.SE_ItemID, 0, instance.SE_ItemID.Length);
			instance.mStartV2 = new Vector2(instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x / 2f, instance.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.y / 2f);
			instance.m_SpeciallyEffect.AddIconShow(instance.mStartV2, instance.SE_Kind, instance.SE_ItemID, true);
		}
		this.text_Info.text = this.Cstr_Info.ToString();
		this.text_Info.SetAllDirty();
		this.text_Info.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06002091 RID: 8337 RVA: 0x003DE700 File Offset: 0x003DC900
	public void SetHeroPage(ushort HeroID)
	{
		this.GUIM.m_UICanvas.renderMode = RenderMode.ScreenSpaceCamera;
		this.GUIM.SetCanvasChanged();
		DataManager.msgBuffer[0] = 84;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		AudioManager.Instance.PlayUISFX(UIKind.CompleteImmediate);
		this.P4_T.gameObject.SetActive(true);
		this.Hero_Pos = this.P4_T.GetChild(0);
		this.text_HeroName = this.P4_T.GetChild(2).GetComponent<UIText>();
		this.text_HeroName.font = this.TTFont;
		this.text_HeroTitle = this.P4_T.GetChild(1).GetComponent<UIText>();
		this.text_HeroTitle.font = this.TTFont;
		this.mHeroAct[0] = "idle";
		this.mHeroAct[1] = "moving";
		this.mHeroAct[2] = "attack";
		this.mHeroAct[3] = "skill_1";
		this.mHeroAct[4] = "skill_2";
		this.mHeroAct[5] = "skill_3";
		this.mHeroAct[6] = "victory";
		this.sHero = this.DM.HeroTable.GetRecordByKey(HeroID);
		this.text_HeroName.text = this.DM.mStringTable.GetStringByID((uint)this.sHero.HeroName);
		this.text_HeroTitle.text = this.DM.mStringTable.GetStringByID((uint)this.sHero.HeroTitle);
		this.LoadHero3D();
		this.text_Title.text = this.DM.mStringTable.GetStringByID(6u);
		this.text_Title.fontSize = 50;
		this.text_Title.resizeTextMaxSize = 50;
		RectTransform component = this.text_Title.transform.GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(component.sizeDelta.x, 70f);
		this.tmpfValue[0] = (float)this.sHero.Camera_Horizontal;
		this.tmpfValue[1] = (float)this.sHero.CameraScaleRate;
	}

	// Token: 0x06002092 RID: 8338 RVA: 0x003DE914 File Offset: 0x003DCB14
	public void SetHeroPage(bool bFirst)
	{
		this.GUIM.m_UICanvas.renderMode = RenderMode.ScreenSpaceCamera;
		this.GUIM.SetCanvasChanged();
		this.P4_T.gameObject.SetActive(true);
		this.P4_T.GetChild(3).gameObject.SetActive(false);
		this.P4_T.GetChild(4).gameObject.SetActive(false);
		this.Hero_Pos = this.P4_T.GetChild(0);
		this.text_HeroName = this.P4_T.GetChild(2).GetComponent<UIText>();
		this.text_HeroName.font = this.TTFont;
		this.text_HeroTitle = this.P4_T.GetChild(1).GetComponent<UIText>();
		this.text_HeroTitle.font = this.TTFont;
		this.mHeroAct[0] = "idle";
		this.mHeroAct[1] = "moving";
		this.mHeroAct[2] = "attack";
		this.mHeroAct[3] = "skill_1";
		this.mHeroAct[4] = "skill_2";
		this.mHeroAct[5] = "skill_3";
		this.mHeroAct[6] = "victory";
		if (bFirst)
		{
			this.text_HeroName.text = this.DM.mStringTable.GetStringByID(1601u);
			this.text_HeroTitle.text = this.DM.mStringTable.GetStringByID(1602u);
			this.ActionTime = 0f;
			this.ActionTimeRandom = 2f;
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.IntToFormat(1L, 5, false);
			cstring.AppendFormat("Role/hero_{0}");
			this.AB = AssetManager.GetAssetBundle(cstring, out this.AssetKey);
			if (this.AB != null)
			{
				this.AR = this.AB.LoadAsync("m", typeof(GameObject));
				this.ABIsDone = false;
				this.tmpfValue[0] = 170f;
				this.tmpfValue[1] = 180f;
			}
		}
		else
		{
			this.text_HeroName.text = this.DM.mStringTable.GetStringByID(1625u);
			this.text_HeroTitle.text = this.DM.mStringTable.GetStringByID(1626u);
			this.ActionTime = 0f;
			this.ActionTimeRandom = 2f;
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring2.IntToFormat(9L, 5, false);
			cstring2.AppendFormat("Role/hero_{0}");
			this.AB = AssetManager.GetAssetBundle(cstring2, out this.AssetKey);
			if (this.AB != null)
			{
				this.AR = this.AB.LoadAsync("m", typeof(GameObject));
				this.ABIsDone = false;
				this.tmpfValue[0] = 175f;
				this.tmpfValue[1] = 180f;
			}
		}
		this.text_Title.text = this.DM.mStringTable.GetStringByID(6u);
		this.text_Title.fontSize = 50;
		this.text_Title.resizeTextMaxSize = 50;
		RectTransform component = this.text_Title.transform.GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(component.sizeDelta.x, 70f);
	}

	// Token: 0x06002093 RID: 8339 RVA: 0x003DEC60 File Offset: 0x003DCE60
	public void SetHeroPage()
	{
		this.GUIM.m_SimpleItemInfo.m_RectTransform.SetParent(this.GUIM.m_OtherCanvasTransform, false);
		this.GUIM.HintMaskObj.m_RectTransform.SetParent(this.GUIM.m_OtherCanvasTransform, false);
		this.GUIM.m_UICanvas.renderMode = RenderMode.ScreenSpaceCamera;
		this.GUIM.SetCanvasChanged();
		DataManager.msgBuffer[0] = 84;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		this.Light1_T = this.P10_T.GetChild(2);
		this.Light2_T = this.P10_T.GetChild(3);
		this.Hbtn_Item2 = this.P10_T.GetChild(4).GetComponent<UIHIBtn>();
		this.Hbtn_Item2.m_Handler = this;
		this.Img_ItemInfo = this.P10_T.GetChild(4).GetChild(0).GetComponent<Image>();
		this.GUIM.InitianHeroItemImg(this.Hbtn_Item2.transform, eHeroOrItem.Item, this.DM.mDailyGift.ItemData.ItemID, 0, 0, 0, false, true, true, false);
		this.Img_ItemInfo.transform.SetAsLastSibling();
		this.Hbtn_Item2.transform.GetComponent<UIButtonHint>().m_eHint = EUIButtonHint.DownUpHandler;
		this.Hbtn_Item2.transform.GetComponent<UIButtonHint>().m_Handler = this;
		if (this.MM.CheckCanOpenDetail(this.DM.mDailyGift.ItemData.ItemID))
		{
			this.Hbtn_Item2.transform.GetComponent<UIButtonHint>().enabled = false;
			this.Hbtn_Item2.gameObject.GetComponent<uButtonScale>().enabled = true;
			this.Hbtn_Item2.transition = Selectable.Transition.None;
			this.Img_ItemInfo.gameObject.SetActive(true);
		}
		else
		{
			this.Hbtn_Item2.transform.GetComponent<UIButtonHint>().enabled = true;
			this.Img_ItemInfo.gameObject.SetActive(false);
		}
		this.btn_box2Reward = this.P10_T.GetChild(5).GetComponent<UIButton>();
		this.btn_box2Reward.m_Handler = this;
		this.btn_box2Reward.m_BtnID1 = 8;
		this.btn_box2Reward.m_EffectType = e_EffectType.e_Scale;
		this.btn_box2Reward.transition = Selectable.Transition.None;
		this.BtnName = this.P10_T.GetChild(5).GetChild(0).GetComponent<UIText>();
		this.BtnName.font = this.TTFont;
		this.BtnName.text = this.DM.mStringTable.GetStringByID(1520u);
		this.text_P10Str[0] = this.P10_T.GetChild(6).GetChild(0).GetComponent<UIText>();
		this.text_P10Str[0].font = this.TTFont;
		this.text_P10Str[0].text = this.DM.mStringTable.GetStringByID(8170u);
		this.text_P10Str[1] = this.P10_T.GetChild(7).GetComponent<UIText>();
		this.text_P10Str[1].font = this.TTFont;
		this.Cstr_P10Time.ClearString();
		this.Cstr_P10Time.StringToFormat(this.DM.mStringTable.GetStringByID(8171u));
		this.Cstr_P10Time.StringToFormat(GameConstants.GetDateTime(this.DM.mDailyGift.BeginTime).ToString("MM/dd/yy HH:mm"));
		this.Cstr_P10Time.StringToFormat(GameConstants.GetDateTime(this.DM.mDailyGift.EndTime).ToString("MM/dd/yy HH:mm"));
		this.Cstr_P10Time.AppendFormat("{0}\n{1} ~ {2}");
		this.text_P10Str[1].text = this.Cstr_P10Time.ToString();
		this.text_P10Str[1].SetAllDirty();
		this.text_P10Str[1].cachedTextGenerator.Invalidate();
		this.text_P10Str[2] = this.P10_T.GetChild(8).GetComponent<UIText>();
		this.text_P10Str[2].font = this.TTFont;
		Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mDailyGift.ItemData.ItemID);
		this.text_P10Str[2].text = this.DM.mStringTable.GetStringByID((uint)recordByKey.EquipName);
		this.text_P10Str[3] = this.P10_T.GetChild(9).GetComponent<UIText>();
		this.text_P10Str[3].font = this.TTFont;
		this.P10_T.GetChild(9).GetComponent<RectTransform>().sizeDelta = new Vector2(this.aTreasureNumWidth, this.aTreasureNumHeight);
		this.text_P10Str[3].resizeTextMaxSize = this.aTreasureNumMaxSize;
		if (this.DM.mDailyGift.ItemData.Num > 1)
		{
			this.text_P10Str[3].gameObject.SetActive(true);
			this.Cstr_P10Num.ClearString();
			this.Cstr_P10Num.IntToFormat((long)this.DM.mDailyGift.ItemData.Num, 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_P10Num.AppendFormat("{0}x");
			}
			else
			{
				this.Cstr_P10Num.AppendFormat("x{0}");
			}
			this.text_P10Str[3].text = this.Cstr_P10Num.ToString();
			this.text_P10Str[3].SetAllDirty();
			this.text_P10Str[3].cachedTextGenerator.Invalidate();
		}
		this.Hero_Pos = this.P10_T.GetChild(10);
		this.mHeroAct[0] = "idle";
		this.AB = AssetManager.GetAssetBundle("Role/Priest", out this.AssetKey, false);
		if (this.AB != null)
		{
			this.AR = this.AB.LoadAsync("Priest", typeof(GameObject));
			this.ABIsDone = false;
		}
		this.tmpfValue[0] = 184f;
		this.tmpfValue[1] = 270f;
		this.tmpfValue[2] = -55.7f;
	}

	// Token: 0x06002094 RID: 8340 RVA: 0x003DF270 File Offset: 0x003DD470
	public void Hero3D_Destroy()
	{
		if (this.go2 != null)
		{
			this.go2.transform.SetParent(this.Hero_Pos.parent, false);
			UnityEngine.Object.Destroy(this.go2);
		}
		if (this.Hero_Model != null)
		{
			UnityEngine.Object.Destroy(this.Hero_Model);
		}
		this.Hero_Model = null;
		this.go2 = null;
		AssetManager.UnloadAssetBundle(this.AssetKey, false);
	}

	// Token: 0x06002095 RID: 8341 RVA: 0x003DF2EC File Offset: 0x003DD4EC
	public void LoadHero3D()
	{
		this.ActionTime = 0f;
		this.ActionTimeRandom = 2f;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.IntToFormat((long)this.sHero.Modle, 5, false);
		cstring.AppendFormat("Role/hero_{0}");
		this.AB = AssetManager.GetAssetBundle(cstring, out this.AssetKey);
		if (this.AB != null)
		{
			this.AR = this.AB.LoadAsync("m", typeof(GameObject));
			this.ABIsDone = false;
		}
	}

	// Token: 0x06002096 RID: 8342 RVA: 0x003DF384 File Offset: 0x003DD584
	public void HeroActionChang()
	{
		if (this.ABIsDone && this.Hero_Model != null)
		{
			this.tmpAN = this.Hero_Model.GetComponent<Animation>();
			this.tmpAN.wrapMode = WrapMode.Loop;
			if (this.tmpAN.GetClip(this.mHeroAct[2]) != null)
			{
				this.HeroAct = this.mHeroAct[2];
				this.tmpAN[this.mHeroAct[2]].layer = 1;
				this.tmpAN[this.mHeroAct[2]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(this.mHeroAct[3]) != null)
			{
				this.HeroAct = this.mHeroAct[3];
				this.tmpAN[this.mHeroAct[3]].layer = 1;
				this.tmpAN[this.mHeroAct[3]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[4]) != null)
			{
				this.HeroAct = this.mHeroAct[4];
				this.tmpAN[this.mHeroAct[4]].layer = 1;
				this.tmpAN[this.mHeroAct[4]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(this.mHeroAct[5]) != null)
			{
				this.HeroAct = this.mHeroAct[5];
				this.tmpAN[this.mHeroAct[5]].layer = 1;
				this.tmpAN[this.mHeroAct[5]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(this.mHeroAct[6]) != null)
			{
				this.HeroAct = this.mHeroAct[6];
				this.tmpAN[this.mHeroAct[6]].layer = 1;
				this.tmpAN[this.mHeroAct[6]].wrapMode = WrapMode.Once;
			}
			int num = UnityEngine.Random.Range(1, 7);
			AnimationClip animationClip = this.tmpAN.GetClip(this.mHeroAct[(int)((byte)num)]);
			this.HeroAct = this.mHeroAct[(int)((byte)num)];
			if (num == 3)
			{
				AnimationClip clip = this.tmpAN.GetClip(this.HeroAct + "_ch");
				if (clip != null)
				{
					animationClip = null;
				}
			}
			if (animationClip != null)
			{
				this.tmpAN.CrossFade(animationClip.name);
				this.MovingTimer = 0f;
				if (num == 1)
				{
					this.MovingTimer = 2f;
				}
			}
			this.ActionTimeRandom = 0f;
			this.ActionTime = 0f;
		}
	}

	// Token: 0x06002097 RID: 8343 RVA: 0x003DF64C File Offset: 0x003DD84C
	public void SetScore()
	{
		this.P5_T.gameObject.SetActive(true);
		this.Light1_T = this.P5_T.GetChild(5);
		this.Light2_T = this.P5_T.GetChild(6);
		this.Tmp = this.P5_T.GetChild(8);
		this.Hbtn_Item2 = this.Tmp.GetComponent<UIHIBtn>();
		this.Hbtn_Item2.m_Handler = this;
		this.GUIM.InitianHeroItemImg(this.Hbtn_Item2.transform, eHeroOrItem.Item, 1226, 0, 0, 0, true, true, true, false);
		for (int i = 0; i < 8; i++)
		{
			this.Tmp = this.P5_T.GetChild(i);
			this.Tmp.gameObject.SetActive(false);
		}
		this.Hbtn_Item2.gameObject.SetActive(false);
		this.Tmp = this.P5_T.GetChild(11);
		this.Tmp.gameObject.SetActive(false);
		this.btn_Score = this.P5_T.GetChild(9).GetComponent<UIButton>();
		this.btn_Score.m_Handler = this;
		this.btn_Score.m_BtnID1 = 3;
		this.btn_Score.m_EffectType = e_EffectType.e_Scale;
		this.btn_Score.transition = Selectable.Transition.None;
		this.text_tmpStr[2] = this.P5_T.GetChild(9).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[2].font = this.TTFont;
		this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(7400u);
		this.Cstr_Score.ClearString();
		this.text_tmpStr[3] = this.P5_T.GetChild(11).GetComponent<UIText>();
		this.text_tmpStr[3].font = this.TTFont;
		this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(1226).EquipName);
		this.Cstr_Score.StringToFormat(this.DM.mStringTable.GetStringByID(7380u));
		this.Cstr_Score.AppendFormat(this.DM.mStringTable.GetStringByID(7378u));
		this.text_Score = this.P5_T.GetChild(10).GetComponent<UIText>();
		this.text_Score.font = this.TTFont;
		this.text_Score.text = this.Cstr_Score.ToString();
		this.text_Score.SetAllDirty();
		this.text_Score.cachedTextGenerator.Invalidate();
		this.text_Score.cachedTextGeneratorForLayout.Invalidate();
		this.text_Title.text = this.DM.mStringTable.GetStringByID(7395u);
		this.text_Title.SetAllDirty();
		this.text_Title.cachedTextGenerator.Invalidate();
		this.text_ScoreStr = this.P5_T.GetChild(12).GetComponent<UIText>();
		this.text_ScoreStr.font = this.TTFont;
		this.text_ScoreStr.text = this.DM.mStringTable.GetStringByID(9912u);
		bool flag = false;
		long num = 0L;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.IntToFormat(NetworkManager.UserID, 1, false);
		cstring.AppendFormat("{0}_Score_UseID");
		long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out num);
		if (num != 0L)
		{
			cstring.ClearString();
			cstring.IntToFormat(num, 1, false);
			cstring.AppendFormat("{0}_Score_bScoreFirst");
			bool.TryParse(PlayerPrefs.GetString(cstring.ToString()), out flag);
			if (flag)
			{
				byte b = 0;
				cstring.ClearString();
				cstring.IntToFormat(num, 1, false);
				cstring.AppendFormat("{0}_Score_Count");
				byte.TryParse(PlayerPrefs.GetString(cstring.ToString()), out b);
				b += 1;
				PlayerPrefs.SetString(cstring.ToString(), b.ToString());
			}
			else
			{
				flag = true;
				cstring.ClearString();
				cstring.IntToFormat(num, 1, false);
				cstring.AppendFormat("{0}_Score_bScoreFirst");
				PlayerPrefs.SetString(cstring.ToString(), flag.ToString());
			}
			cstring.ClearString();
			cstring.IntToFormat(num, 1, false);
			cstring.AppendFormat("{0}_Score_CD");
			PlayerPrefs.SetString(cstring.ToString(), this.DM.ServerTime.ToString());
		}
		else
		{
			PlayerPrefs.SetString(cstring.ToString(), NetworkManager.UserID.ToString());
			long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out num);
			flag = true;
			cstring.ClearString();
			cstring.IntToFormat(num, 1, false);
			cstring.AppendFormat("{0}_Score_bScoreFirst");
			PlayerPrefs.SetString(cstring.ToString(), flag.ToString());
			bool.TryParse(PlayerPrefs.GetString(cstring.ToString()), out flag);
			cstring.ClearString();
			cstring.IntToFormat(num, 1, false);
			cstring.AppendFormat("{0}_Score_CD");
			PlayerPrefs.SetString(cstring.ToString(), this.DM.ServerTime.ToString());
		}
	}

	// Token: 0x06002098 RID: 8344 RVA: 0x003DFB68 File Offset: 0x003DDD68
	public void SetFB_Reward()
	{
		this.P6_T.gameObject.SetActive(true);
		this.Light1_T = this.P6_T.GetChild(0);
		this.Light2_T = this.P6_T.GetChild(1);
		this.Tmp = this.P6_T.GetChild(3);
		this.Hbtn_Item2 = this.Tmp.GetComponent<UIHIBtn>();
		this.Hbtn_Item2.m_Handler = this;
		this.GUIM.InitianHeroItemImg(this.Hbtn_Item2.transform, eHeroOrItem.Item, 1226, 0, 0, 0, true, true, true, false);
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			this.text_Title.text = this.DM.mStringTable.GetStringByID(11266u);
			this.text_Info.gameObject.SetActive(false);
		}
		else
		{
			this.text_Title.text = this.DM.mStringTable.GetStringByID(7382u);
		}
		this.Cstr_Info.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(1226).EquipName));
		this.Cstr_Info.AppendFormat("{0}");
		this.text_Info.text = this.Cstr_Info.ToString();
		this.text_Info.SetAllDirty();
		this.text_Info.cachedTextGenerator.Invalidate();
		this.Info_RT.anchoredPosition = new Vector2(this.Info_RT.anchoredPosition.x, this.Info_RT.anchoredPosition.y - 50f);
		this.btn_GOTOFB = this.P6_T.GetChild(4).GetComponent<UIButton>();
		this.btn_GOTOFB.m_Handler = this;
		this.btn_GOTOFB.m_BtnID1 = 4;
		this.btn_GOTOFB.m_EffectType = e_EffectType.e_Scale;
		this.btn_GOTOFB.transition = Selectable.Transition.None;
		this.text_tmpStr[4] = this.P6_T.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[4].font = this.TTFont;
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(11171u);
		}
		else
		{
			this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(7383u);
		}
		this.text_tmpStr[5] = this.P6_T.GetChild(5).GetComponent<UIText>();
		this.text_tmpStr[5].font = this.TTFont;
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			this.text_tmpStr[5].text = this.DM.mStringTable.GetStringByID(11267u);
		}
		else
		{
			this.text_tmpStr[5].text = this.DM.mStringTable.GetStringByID(7384u);
		}
		bool flag = false;
		long num = 0L;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.IntToFormat(NetworkManager.UserID, 1, false);
		cstring.AppendFormat("{0}_FB_UseID");
		long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out num);
		if (num != 0L)
		{
			cstring.ClearString();
			cstring.IntToFormat(num, 1, false);
			cstring.AppendFormat("{0}_FB_bScoreFirst");
			bool.TryParse(PlayerPrefs.GetString(cstring.ToString()), out flag);
			if (flag)
			{
				byte b = 0;
				cstring.ClearString();
				cstring.IntToFormat(num, 1, false);
				cstring.AppendFormat("{0}_FB_Count");
				byte.TryParse(PlayerPrefs.GetString(cstring.ToString()), out b);
				b += 1;
				PlayerPrefs.SetString(cstring.ToString(), b.ToString());
			}
			else
			{
				flag = true;
				cstring.ClearString();
				cstring.IntToFormat(num, 1, false);
				cstring.AppendFormat("{0}_FB_bScoreFirst");
				PlayerPrefs.SetString(cstring.ToString(), flag.ToString());
			}
			cstring.ClearString();
			cstring.IntToFormat(num, 1, false);
			cstring.AppendFormat("{0}_FB_CD");
			PlayerPrefs.SetString(cstring.ToString(), this.DM.ServerTime.ToString());
		}
		else
		{
			PlayerPrefs.SetString(cstring.ToString(), NetworkManager.UserID.ToString());
			long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out num);
			flag = true;
			cstring.ClearString();
			cstring.IntToFormat(num, 1, false);
			cstring.AppendFormat("{0}_FB_bScoreFirst");
			PlayerPrefs.SetString(cstring.ToString(), flag.ToString());
			bool.TryParse(PlayerPrefs.GetString(cstring.ToString()), out flag);
			cstring.ClearString();
			cstring.IntToFormat(num, 1, false);
			cstring.AppendFormat("{0}_FB_CD");
			PlayerPrefs.SetString(cstring.ToString(), this.DM.ServerTime.ToString());
		}
	}

	// Token: 0x06002099 RID: 8345 RVA: 0x003E0050 File Offset: 0x003DE250
	public override void OnClose()
	{
		if (this.door != null && this.door.m_WindowStack.Count == 0)
		{
			DataManager.msgBuffer[0] = 85;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
		if (this.Cstr_Time != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Time);
		}
		if (this.Cstr_Count != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Count);
		}
		if (this.Cstr_Info != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Info);
		}
		if (this.Cstr_Info2 != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Info2);
		}
		if (this.Cstr_Get != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Get);
		}
		if (this.Cstr_Score != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Score);
		}
		if (this.Cstr_P10Time != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_P10Time);
		}
		if (this.Cstr_P10Num != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_P10Num);
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.Cstr_Get2[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Get2[i]);
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (this.CStr_Indemnify[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.CStr_Indemnify[j]);
			}
		}
		for (int k = 0; k < 9; k++)
		{
			if (this.Cstr_Items[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Items[k]);
			}
		}
		this.Hero3D_Destroy();
		if (this.mKind == 3)
		{
			GUIManager.Instance.ReleaseLvUpLight();
		}
		if (this.mKind == 3)
		{
			UIStageSelect x = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect;
			if (x != null)
			{
				NewbieManager.CheckTeach(ETeachKind.PRESS_X, null, true);
			}
		}
	}

	// Token: 0x0600209A RID: 8346 RVA: 0x003E0260 File Offset: 0x003DE460
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
		case 1:
			this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
			this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			if (this.mKind == 2 && this.mGetType == 1)
			{
				this.GUIM.OpenMenu(EGUIWindow.UI_Other_Account, 0, 0, false, true, false);
			}
			if (this.mKind == 1 && this.mGetType == 1)
			{
				this.DM.m_MaintainCount = false;
			}
			if (this.mKind == 1 && this.mGetType == 2)
			{
				this.DM.m_UpdateVersionCount = false;
			}
			break;
		case 2:
			switch (this.mGetType)
			{
			case 0:
				this.DM.SendTreasureBox();
				break;
			case 1:
			case 2:
				this.DM.SendGet_Compensation((byte)(this.mGetType - 1));
				break;
			}
			break;
		case 3:
		{
			bool flag = true;
			long num = 0L;
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring.IntToFormat(NetworkManager.UserID, 1, false);
			cstring.AppendFormat("{0}");
			long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out num);
			if (num != 0L)
			{
				cstring.ClearString();
				cstring.IntToFormat(num, 1, false);
				cstring.AppendFormat("{0}_Score_bScoreEnd");
				PlayerPrefs.SetString(cstring.ToString(), flag.ToString());
			}
			IGGSDKPlugin.RateGooglePlayApplication(GameConstants.GlobalEditionClassNames);
			this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
			this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			break;
		}
		case 4:
		{
			this.GUIM.ShowUILock(EUILock.TreasureBox);
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_FB_FANS_PRIZE;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			break;
		}
		case 5:
			if (ArenaManager.Instance.m_ArenaCrystalPrize > 0u)
			{
				ArenaManager.Instance.SendArena_Arena_GetPrize();
			}
			else
			{
				this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
				this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			}
			break;
		case 6:
			Indemnify.SendRequestIndemnify();
			break;
		case 7:
			if (MallManager.Instance.BuyMonthTreasureTime != 0L)
			{
				MallManager.Instance.Send_Treasure_Get_Monthprize();
			}
			else
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(7013u), 255, true);
			}
			break;
		case 8:
		{
			this.GUIM.ShowUILock(EUILock.TreasureBox);
			MessagePacket messagePacket2 = new MessagePacket(1024);
			messagePacket2.Protocol = Protocol._MSG_REQUEST_ACTIVITY_DAILYGIFT;
			messagePacket2.AddSeqId();
			messagePacket2.Send(false);
			break;
		}
		}
	}

	// Token: 0x0600209B RID: 8347 RVA: 0x003E0524 File Offset: 0x003DE724
	public void OnHIButtonClick(UIHIBtn sender)
	{
		this.MM.OpenDetail(sender.HIID);
	}

	// Token: 0x0600209C RID: 8348 RVA: 0x003E0538 File Offset: 0x003DE738
	public void OnButtonDown(UIButtonHint sender)
	{
		this.GUIM.m_SimpleItemInfo.Show(sender, this.DM.mDailyGift.ItemData.ItemID, -1, UIButtonHint.ePosition.Original, new Vector3?(new Vector2(-250f, 0f)));
	}

	// Token: 0x0600209D RID: 8349 RVA: 0x003E0588 File Offset: 0x003DE788
	public void OnButtonUp(UIButtonHint sender)
	{
		this.GUIM.m_SimpleItemInfo.Hide(sender);
	}

	// Token: 0x0600209E RID: 8350 RVA: 0x003E059C File Offset: 0x003DE79C
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Fallout)
			{
				if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
				{
					if (networkNews == NetworkNews.Refresh_IndemnifyResources)
					{
						this.RefreshIndemnifyResources();
					}
				}
				else
				{
					this.Refresh_FontTexture();
				}
			}
			else
			{
				base.gameObject.SetActive(false);
			}
		}
		else
		{
			base.gameObject.SetActive(true);
			if (this.mKind == 12)
			{
				this.GUIM.m_SimpleItemInfo.m_RectTransform.SetParent(GUIManager.Instance.m_ItemInfoLayer, false);
				this.GUIM.m_SimpleItemInfo.m_RectTransform.SetAsFirstSibling();
				this.GUIM.m_SimpleItemInfo.m_RectTransform.anchoredPosition3D = Vector3.zero;
				this.GUIM.HintMaskObj.m_RectTransform.SetParent(GUIManager.Instance.m_ItemInfoLayer, false);
				this.GUIM.HintMaskObj.m_RectTransform.SetSiblingIndex(6);
				this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
				this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			}
		}
	}

	// Token: 0x0600209F RID: 8351 RVA: 0x003E06B4 File Offset: 0x003DE8B4
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_Info != null && this.text_Info.enabled)
		{
			this.text_Info.enabled = false;
			this.text_Info.enabled = true;
		}
		if (this.text_Time != null && this.text_Time.enabled)
		{
			this.text_Time.enabled = false;
			this.text_Time.enabled = true;
		}
		if (this.text_Count != null && this.text_Count.enabled)
		{
			this.text_Count.enabled = false;
			this.text_Count.enabled = true;
		}
		if (this.text_Get != null && this.text_Get.enabled)
		{
			this.text_Get.enabled = false;
			this.text_Get.enabled = true;
		}
		if (this.text_HeroName != null && this.text_HeroName.enabled)
		{
			this.text_HeroName.enabled = false;
			this.text_HeroName.enabled = true;
		}
		if (this.text_HeroTitle != null && this.text_HeroTitle.enabled)
		{
			this.text_HeroTitle.enabled = false;
			this.text_HeroTitle.enabled = true;
		}
		if (this.text_GetType != null && this.text_GetType.enabled)
		{
			this.text_GetType.enabled = false;
			this.text_GetType.enabled = true;
		}
		if (this.text_Score != null && this.text_Score.enabled)
		{
			this.text_Score.enabled = false;
			this.text_Score.enabled = true;
		}
		if (this.text_ScoreStr != null && this.text_ScoreStr.enabled)
		{
			this.text_ScoreStr.enabled = false;
			this.text_ScoreStr.enabled = true;
		}
		if (this.text_ArenaReward != null && this.text_ArenaReward.enabled)
		{
			this.text_ArenaReward.enabled = false;
			this.text_ArenaReward.enabled = true;
		}
		if (this.text_ArenaRewardNum != null && this.text_ArenaRewardNum.enabled)
		{
			this.text_ArenaRewardNum.enabled = false;
			this.text_ArenaRewardNum.enabled = true;
		}
		if (this.text_ArenaReward_Get != null && this.text_ArenaReward_Get.enabled)
		{
			this.text_ArenaReward_Get.enabled = false;
			this.text_ArenaReward_Get.enabled = true;
		}
		if (this.BtnName != null && this.BtnName.enabled)
		{
			this.BtnName.enabled = false;
			this.BtnName.enabled = true;
		}
		if (this.Hbtn_Item != null && this.Hbtn_Item.enabled)
		{
			this.Hbtn_Item.Refresh_FontTexture();
		}
		if (this.Hbtn_Item2 != null && this.Hbtn_Item2.enabled)
		{
			this.Hbtn_Item2.Refresh_FontTexture();
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_Get2[i] != null && this.text_Get2[i].enabled)
			{
				this.text_Get2[i].enabled = false;
				this.text_Get2[i].enabled = true;
			}
			if (this.text_Arena[i] != null && this.text_Arena[i].enabled)
			{
				this.text_Arena[i].enabled = false;
				this.text_Arena[i].enabled = true;
			}
		}
		for (int j = 0; j < 6; j++)
		{
			if (this.text_tmpStr[j] != null && this.text_tmpStr[j].enabled)
			{
				this.text_tmpStr[j].enabled = false;
				this.text_tmpStr[j].enabled = true;
			}
		}
		for (int k = 0; k < 8; k++)
		{
			if (this.text_Cards[k] != null && this.text_Cards[k].enabled)
			{
				this.text_Cards[k].enabled = false;
				this.text_Cards[k].enabled = true;
			}
		}
		for (int l = 0; l < 7; l++)
		{
			if (this.Hbtn_Items[l] != null && this.Hbtn_Items[l].enabled)
			{
				this.Hbtn_Items[l].Refresh_FontTexture();
			}
		}
		for (int m = 0; m < 4; m++)
		{
			if (this.text_P10Str[m] != null && this.text_P10Str[m].enabled)
			{
				this.text_P10Str[m].enabled = false;
				this.text_P10Str[m].enabled = true;
			}
		}
	}

	// Token: 0x060020A0 RID: 8352 RVA: 0x003E0C10 File Offset: 0x003DEE10
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
			this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			this.GUIM.OpenUI_Queued_Restricted(EGUIWindow.UI_TreasureBox, 2, 3, false, 0);
			GameManager.OnRefresh(NetworkNews.Refresh, null);
			break;
		case 2:
			this.Cstr_Info.ClearString();
			this.Cstr_Info.IntToFormat((long)((ulong)this.DM.m_Maintain), 1, false);
			this.Cstr_Info.AppendFormat(this.DM.mStringTable.GetStringByID(8473u));
			this.text_Info.text = this.Cstr_Info.ToString();
			this.text_Info.SetAllDirty();
			this.text_Info.cachedTextGenerator.Invalidate();
			break;
		case 3:
			this.Cstr_Info.ClearString();
			this.Cstr_Info.IntToFormat((long)((ulong)this.DM.m_UpdateVersion), 1, false);
			this.Cstr_Info.AppendFormat(this.DM.mStringTable.GetStringByID(8473u));
			this.text_Info.text = this.Cstr_Info.ToString();
			this.text_Info.SetAllDirty();
			this.text_Info.cachedTextGenerator.Invalidate();
			break;
		case 4:
			if (this.mKind == 9)
			{
				this.Cstr_Info2.ClearString();
				this.Cstr_Info2.IntToFormat((long)((ulong)ArenaManager.Instance.m_ArenaCrystalPrize), 1, true);
				this.Cstr_Info2.AppendFormat("{0}");
				this.text_ArenaRewardNum.text = this.Cstr_Info2.ToString();
				this.text_ArenaRewardNum.SetAllDirty();
				this.text_ArenaRewardNum.cachedTextGenerator.Invalidate();
				if (ArenaManager.Instance.m_ArenaCrystalPrize > 0u)
				{
					this.text_ArenaReward.text = this.DM.mStringTable.GetStringByID(9143u);
					this.text_ArenaReward_Get.text = this.DM.mStringTable.GetStringByID(9142u);
					this.text_ArenaRewardNum.gameObject.SetActive(true);
				}
				else
				{
					this.text_ArenaReward.text = this.DM.mStringTable.GetStringByID(7671u);
					this.text_ArenaReward_Get.text = this.DM.mStringTable.GetStringByID(9164u);
					this.text_ArenaRewardNum.gameObject.SetActive(false);
				}
				this.text_ArenaReward.SetAllDirty();
				this.text_ArenaReward.cachedTextGenerator.Invalidate();
				this.text_ArenaReward_Get.SetAllDirty();
				this.text_ArenaReward_Get.cachedTextGenerator.Invalidate();
			}
			break;
		case 5:
			if (this.mKind == 9)
			{
				ushort nowCrystal = ArenaManager.Instance.GetNowCrystal();
				this.Cstr_Info.ClearString();
				this.Cstr_Info.IntToFormat((long)nowCrystal, 1, true);
				this.Cstr_Info.AppendFormat("{0}");
				this.text_Arena[1].text = this.Cstr_Info.ToString();
				this.text_Arena[1].SetAllDirty();
				this.text_Arena[1].cachedTextGenerator.Invalidate();
			}
			break;
		case 6:
			if (this.mKind == 11)
			{
				this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
				this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			}
			break;
		case 7:
			if (this.mKind == 11 && this.P9_T.gameObject.activeSelf)
			{
				this.Cstr_Items[0].ClearString();
				this.Cstr_Items[0].IntToFormat((long)((ulong)this.MM.mMonthTreasureCrystal), 1, false);
				this.Cstr_Items[0].AppendFormat("{0}");
				this.text_Cards[0].text = this.Cstr_Items[0].ToString();
				this.text_Cards[0].SetAllDirty();
				this.text_Cards[0].cachedTextGenerator.Invalidate();
				for (int i = 0; i < 7; i++)
				{
					this.GUIM.ChangeHeroItemImg(this.Hbtn_Items[i].transform, eHeroOrItem.Item, this.MM.mMonthTreasureItem[i].ItemID, 0, this.MM.mMonthTreasureItem[i].ItemRank, 0);
					this.Cstr_Items[i + 1].ClearString();
					this.Cstr_Items[i + 1].IntToFormat((long)this.MM.mMonthTreasureItem[i].Num, 1, false);
					if (this.GUIM.IsArabic)
					{
						this.Cstr_Items[i + 1].AppendFormat("{0}x");
					}
					else
					{
						this.Cstr_Items[i + 1].AppendFormat("x{0}");
					}
					this.text_Cards[i + 1].text = this.Cstr_Items[i + 1].ToString();
					this.text_Cards[i + 1].SetAllDirty();
					this.text_Cards[i + 1].cachedTextGenerator.Invalidate();
				}
				this.Cstr_Items[8].ClearString();
				this.text_Cards[8] = this.P9_T.GetChild(16).GetComponent<UIText>();
				this.text_Cards[8].font = this.TTFont;
				if (this.MM.BuyMonthTreasureTime != 0L && this.MM.LastGetMonthTreasurePrizeTime == 0L)
				{
					this.Cstr_Items[8].IntToFormat(30L, 1, true);
				}
				else
				{
					this.Cstr_Items[8].IntToFormat(29L - (this.MM.LastGetMonthTreasurePrizeTime - this.MM.BuyMonthTreasureTime) / 86400L, 1, true);
				}
				this.Cstr_Items[8].AppendFormat(this.DM.mStringTable.GetStringByID(922u));
				this.text_Cards[8].text = this.Cstr_Items[8].ToString();
				this.text_Cards[8].SetAllDirty();
				this.text_Cards[8].cachedTextGenerator.Invalidate();
			}
			break;
		case 8:
			if (this.mKind == 12 && !this.DM.CheckDailyGift())
			{
				this.GUIM.m_SimpleItemInfo.m_RectTransform.SetParent(GUIManager.Instance.m_ItemInfoLayer, false);
				this.GUIM.m_SimpleItemInfo.m_RectTransform.SetAsFirstSibling();
				this.GUIM.m_SimpleItemInfo.m_RectTransform.anchoredPosition3D = Vector3.zero;
				this.GUIM.HintMaskObj.m_RectTransform.SetParent(GUIManager.Instance.m_ItemInfoLayer, false);
				this.GUIM.HintMaskObj.m_RectTransform.SetSiblingIndex(6);
				this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
				this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			}
			break;
		case 9:
			if (this.mKind == 12)
			{
				if (!this.DM.CheckDailyGift())
				{
					this.GUIM.CloseMenu(EGUIWindow.UI_TreasureBox);
					this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
				}
				else
				{
					this.Cstr_P10Time.ClearString();
					this.Cstr_P10Time.StringToFormat(this.DM.mStringTable.GetStringByID(8171u));
					this.Cstr_P10Time.StringToFormat(GameConstants.GetDateTime(this.DM.mDailyGift.BeginTime).ToString("MM/dd/yy HH:mm"));
					this.Cstr_P10Time.StringToFormat(GameConstants.GetDateTime(this.DM.mDailyGift.EndTime).ToString("MM/dd/yy HH:mm"));
					this.Cstr_P10Time.AppendFormat("{0}\n{1} ~ {2}");
					this.text_P10Str[1].text = this.Cstr_P10Time.ToString();
					this.text_P10Str[1].SetAllDirty();
					this.text_P10Str[1].cachedTextGenerator.Invalidate();
					this.GUIM.ChangeHeroItemImg(this.Hbtn_Item2.transform, eHeroOrItem.Item, this.DM.mDailyGift.ItemData.ItemID, 0, 0, 0);
					Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mDailyGift.ItemData.ItemID);
					this.text_P10Str[2].text = this.DM.mStringTable.GetStringByID((uint)recordByKey.EquipName);
					this.text_P10Str[2].SetAllDirty();
					this.text_P10Str[2].cachedTextGenerator.Invalidate();
					if (this.DM.mDailyGift.ItemData.Num > 1)
					{
						this.text_P10Str[3].gameObject.SetActive(true);
						this.Cstr_P10Num.ClearString();
						this.Cstr_P10Num.IntToFormat((long)this.DM.mDailyGift.ItemData.Num, 1, false);
						if (this.GUIM.IsArabic)
						{
							this.Cstr_P10Num.AppendFormat("{0}x");
						}
						else
						{
							this.Cstr_P10Num.AppendFormat("x{0}");
						}
						this.text_P10Str[3].text = this.Cstr_P10Num.ToString();
						this.text_P10Str[3].SetAllDirty();
						this.text_P10Str[3].cachedTextGenerator.Invalidate();
					}
					else
					{
						this.text_P10Str[3].gameObject.SetActive(false);
					}
				}
			}
			break;
		}
	}

	// Token: 0x060020A1 RID: 8353 RVA: 0x003E1580 File Offset: 0x003DF780
	public override bool OnBackButtonClick()
	{
		return this.mKind == 12;
	}

	// Token: 0x060020A2 RID: 8354 RVA: 0x003E1594 File Offset: 0x003DF794
	private void Start()
	{
	}

	// Token: 0x060020A3 RID: 8355 RVA: 0x003E1598 File Offset: 0x003DF798
	private void Update()
	{
		if ((this.P2_T.gameObject.activeSelf || this.P3_T.gameObject.activeSelf || this.P5_T.gameObject.activeSelf || this.P6_T.gameObject.activeSelf || this.P10_T.gameObject.activeSelf) && this.Light1_T != null && this.Light2_T != null)
		{
			this.Light1_T.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
			this.Light2_T.Rotate(Vector3.forward * Time.smoothDeltaTime * 50f);
		}
		else if (this.LightP1_T != null)
		{
			this.LightP1_T.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
		if (this.mKind == 12 && this.P10_T != null && !this.P10_T.gameObject.gameObject.activeSelf)
		{
			this.P10_T.gameObject.SetActive(true);
		}
		if (this.P4_T.gameObject.activeSelf || this.P10_T.gameObject.activeSelf)
		{
			if (!this.ABIsDone && this.AR != null && this.AR.isDone)
			{
				this.go2 = (GameObject)UnityEngine.Object.Instantiate(this.AR.asset);
				this.go2.transform.SetParent(this.Hero_Pos, false);
				Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
				localRotation.eulerAngles = new Vector3(0f, this.tmpfValue[0], 0f);
				this.go2.transform.localRotation = localRotation;
				this.go2.transform.localScale = new Vector3(this.tmpfValue[1], this.tmpfValue[1], this.tmpfValue[1]);
				this.go2.transform.localPosition = new Vector3(0f, this.tmpfValue[2], 0f);
				this.GUIM.SetLayer(this.go2, 5);
				this.Tmp = this.Hero_Pos.GetChild(0);
				this.Hero_Model = this.Tmp.GetComponent<Transform>();
				if (this.Hero_Model != null)
				{
					this.tmpAN = this.Hero_Model.GetComponent<Animation>();
					this.tmpAN.wrapMode = WrapMode.Loop;
					this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
					this.tmpAN.Play(AnimationUnit.ANIM_STRING[0]);
					this.tmpAN.clip = this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[0]);
					if (this.Hero_Pos.gameObject.activeSelf)
					{
						SkinnedMeshRenderer componentInChildren = this.Hero_Model.GetComponentInChildren<SkinnedMeshRenderer>();
						componentInChildren.useLightProbes = false;
						componentInChildren.updateWhenOffscreen = true;
					}
				}
				this.ABIsDone = true;
			}
			if (this.ABIsDone && this.Hero_Model != null && (!this.tmpAN.IsPlaying(this.HeroAct) || this.HeroAct == "idle") && (double)this.ActionTimeRandom < 0.0001)
			{
				this.ActionTimeRandom = (float)UnityEngine.Random.Range(3, 7);
				this.ActionTime = 0f;
			}
			if ((double)this.ActionTimeRandom > 0.0001 && this.P4_T.gameObject.activeSelf)
			{
				this.ActionTime += Time.smoothDeltaTime;
				if (this.ActionTime >= this.ActionTimeRandom)
				{
					this.HeroActionChang();
				}
			}
			if (this.ABIsDone && this.Hero_Model != null && this.MovingTimer > 0f)
			{
				this.MovingTimer -= Time.deltaTime;
				if (this.MovingTimer <= 0f)
				{
					this.tmpAN.CrossFade("idle");
					this.HeroAct = "idle";
				}
			}
		}
	}

	// Token: 0x040066AE RID: 26286
	private Transform GameT;

	// Token: 0x040066AF RID: 26287
	private Transform Tmp;

	// Token: 0x040066B0 RID: 26288
	private Transform P1_T;

	// Token: 0x040066B1 RID: 26289
	private Transform P2_T;

	// Token: 0x040066B2 RID: 26290
	private Transform P3_T;

	// Token: 0x040066B3 RID: 26291
	private Transform P4_T;

	// Token: 0x040066B4 RID: 26292
	private Transform P5_T;

	// Token: 0x040066B5 RID: 26293
	private Transform P6_T;

	// Token: 0x040066B6 RID: 26294
	private Transform P7_T;

	// Token: 0x040066B7 RID: 26295
	private Transform P8_T;

	// Token: 0x040066B8 RID: 26296
	private Transform P9_T;

	// Token: 0x040066B9 RID: 26297
	private Transform P10_T;

	// Token: 0x040066BA RID: 26298
	private Transform LightP1_T;

	// Token: 0x040066BB RID: 26299
	private Transform Light1_T;

	// Token: 0x040066BC RID: 26300
	private Transform Light2_T;

	// Token: 0x040066BD RID: 26301
	private Transform Hero_Pos;

	// Token: 0x040066BE RID: 26302
	private Transform Hero_Model;

	// Token: 0x040066BF RID: 26303
	private Transform mCount1_T;

	// Token: 0x040066C0 RID: 26304
	private Transform mCount2_T;

	// Token: 0x040066C1 RID: 26305
	private RectTransform Info_RT;

	// Token: 0x040066C2 RID: 26306
	private UIButton btn_EXIT;

	// Token: 0x040066C3 RID: 26307
	private UIButton btn_OK;

	// Token: 0x040066C4 RID: 26308
	private UIButton btn_Get;

	// Token: 0x040066C5 RID: 26309
	private UIButton btn_Score;

	// Token: 0x040066C6 RID: 26310
	private UIButton btn_GOTOFB;

	// Token: 0x040066C7 RID: 26311
	private UIButton btn_ArenaReward;

	// Token: 0x040066C8 RID: 26312
	private UIButton btn_CardReward;

	// Token: 0x040066C9 RID: 26313
	private UIButton btn_box2Reward;

	// Token: 0x040066CA RID: 26314
	private UIHIBtn Hbtn_Item;

	// Token: 0x040066CB RID: 26315
	private UIHIBtn Hbtn_Item2;

	// Token: 0x040066CC RID: 26316
	private UIHIBtn[] Hbtn_Items = new UIHIBtn[7];

	// Token: 0x040066CD RID: 26317
	private Image Img_5X;

	// Token: 0x040066CE RID: 26318
	private Image Img_ItemInfo;

	// Token: 0x040066CF RID: 26319
	private UIText text_Title;

	// Token: 0x040066D0 RID: 26320
	private UIText text_Info;

	// Token: 0x040066D1 RID: 26321
	private UIText text_Time;

	// Token: 0x040066D2 RID: 26322
	private UIText text_Count;

	// Token: 0x040066D3 RID: 26323
	private UIText text_Get;

	// Token: 0x040066D4 RID: 26324
	private UIText[] text_Get2 = new UIText[2];

	// Token: 0x040066D5 RID: 26325
	private UIText text_HeroName;

	// Token: 0x040066D6 RID: 26326
	private UIText text_HeroTitle;

	// Token: 0x040066D7 RID: 26327
	private UIText text_GetType;

	// Token: 0x040066D8 RID: 26328
	private UIText text_Score;

	// Token: 0x040066D9 RID: 26329
	private UIText text_ArenaReward;

	// Token: 0x040066DA RID: 26330
	private UIText text_ArenaRewardNum;

	// Token: 0x040066DB RID: 26331
	private UIText text_ArenaReward_Get;

	// Token: 0x040066DC RID: 26332
	private UIText text_ScoreStr;

	// Token: 0x040066DD RID: 26333
	private UIText[] text_tmpStr = new UIText[6];

	// Token: 0x040066DE RID: 26334
	private UIText[] text_Arena = new UIText[2];

	// Token: 0x040066DF RID: 26335
	private UIText[] text_Cards = new UIText[9];

	// Token: 0x040066E0 RID: 26336
	private UIText[] text_P10Str = new UIText[4];

	// Token: 0x040066E1 RID: 26337
	private CString Cstr_Time;

	// Token: 0x040066E2 RID: 26338
	private CString Cstr_Count;

	// Token: 0x040066E3 RID: 26339
	private CString Cstr_Info;

	// Token: 0x040066E4 RID: 26340
	private CString Cstr_Info2;

	// Token: 0x040066E5 RID: 26341
	private CString Cstr_Get;

	// Token: 0x040066E6 RID: 26342
	private CString[] Cstr_Get2 = new CString[2];

	// Token: 0x040066E7 RID: 26343
	private CString Cstr_Score;

	// Token: 0x040066E8 RID: 26344
	private CString[] Cstr_Items = new CString[9];

	// Token: 0x040066E9 RID: 26345
	private CString Cstr_P10Time;

	// Token: 0x040066EA RID: 26346
	private CString Cstr_P10Num;

	// Token: 0x040066EB RID: 26347
	private DataManager DM;

	// Token: 0x040066EC RID: 26348
	private GUIManager GUIM;

	// Token: 0x040066ED RID: 26349
	private MallManager MM;

	// Token: 0x040066EE RID: 26350
	private Font TTFont;

	// Token: 0x040066EF RID: 26351
	public int mKind;

	// Token: 0x040066F0 RID: 26352
	public int mGetType;

	// Token: 0x040066F1 RID: 26353
	private GameObject go2;

	// Token: 0x040066F2 RID: 26354
	private int AssetKey;

	// Token: 0x040066F3 RID: 26355
	private float ActionTime;

	// Token: 0x040066F4 RID: 26356
	private float ActionTimeRandom;

	// Token: 0x040066F5 RID: 26357
	private float MovingTimer;

	// Token: 0x040066F6 RID: 26358
	private Hero sHero;

	// Token: 0x040066F7 RID: 26359
	private AssetBundle AB;

	// Token: 0x040066F8 RID: 26360
	private AssetBundleRequest AR;

	// Token: 0x040066F9 RID: 26361
	private bool ABIsDone;

	// Token: 0x040066FA RID: 26362
	private string HeroAct;

	// Token: 0x040066FB RID: 26363
	private Animation tmpAN;

	// Token: 0x040066FC RID: 26364
	public string[] mHeroAct = new string[7];

	// Token: 0x040066FD RID: 26365
	private float aTreasureNumWidth = 100f;

	// Token: 0x040066FE RID: 26366
	private float aTreasureNumHeight = 35f;

	// Token: 0x040066FF RID: 26367
	private int aTreasureNumMaxSize = 100;

	// Token: 0x04006700 RID: 26368
	private UIButton btn_Indemnify;

	// Token: 0x04006701 RID: 26369
	private UIText[] TextIndemnify = new UIText[4];

	// Token: 0x04006702 RID: 26370
	private CString[] CStr_Indemnify = new CString[4];

	// Token: 0x04006703 RID: 26371
	private string[] ResIcon = new string[]
	{
		"UI_main_res_food",
		"UI_main_res_stone",
		"UI_main_res_wood",
		"UI_main_res_iron"
	};

	// Token: 0x04006704 RID: 26372
	private float[] tmpfValue = new float[3];

	// Token: 0x04006705 RID: 26373
	private Door door;

	// Token: 0x04006706 RID: 26374
	private UIText BtnName;

	// Token: 0x04006707 RID: 26375
	private HelperUIButton OutsideExitBtn;
}
