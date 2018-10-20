using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x020002D5 RID: 725
public class UIAlliance_ActivityGift : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x06000E96 RID: 3734 RVA: 0x0017FFBC File Offset: 0x0017E1BC
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.AGM = ActivityGiftManager.Instance;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.GameT = base.gameObject.transform;
		this.m_Mat = this.door.LoadMaterial();
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.Cstr_CDTime = StringManager.Instance.SpawnString(200);
		this.Cstr_ActivityCDTime = StringManager.Instance.SpawnString(30);
		this.Cstr_HintNum = StringManager.Instance.SpawnString(200);
		this.Cstr_HintTime = StringManager.Instance.SpawnString(200);
		this.Cstr_HintRank = StringManager.Instance.SpawnString(200);
		this.Cstr_HintNum.Append(this.DM.mStringTable.GetStringByID(11213u));
		this.Cstr_HintTime.Append(this.DM.mStringTable.GetStringByID(11212u));
		this.Cstr_HintRank.Append(this.DM.mStringTable.GetStringByID(539u));
		for (int i = 0; i < 6; i++)
		{
			this.Cstr_GiftNum[i] = StringManager.Instance.SpawnString(100);
			this.Cstr_GiftCDTime[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_Price[i] = StringManager.Instance.SpawnString(30);
		}
		byte groupID = this.AGM.GroupID;
		ushort num = 0;
		for (int j = 0; j < this.DM.FastivalSpecialDataTable.TableCount; j++)
		{
			FastivalSpecialData fastivalSpecialData = this.DM.FastivalSpecialDataTable.GetRecordByKey((ushort)(j + 1));
			if (groupID == fastivalSpecialData.GroupID)
			{
				this.GroupID_Data.Add(fastivalSpecialData.ID);
				num += 1;
			}
		}
		this.mPackID = groupID;
		for (int k = 0; k < 6; k++)
		{
			this.bFindScrollp[k] = false;
			this.bFindScrollp_Buy[k] = false;
		}
		this.Img_BG = this.GameT.GetChild(0).GetChild(0).GetComponent<Image>();
		for (int l = 0; l < 2; l++)
		{
			this.Tmp = this.GameT.GetChild(0).GetChild(1 + l);
			this.btnPage[l] = this.Tmp.GetComponent<UIButton>();
			this.btnPage[l].m_Handler = this;
			this.btnPage[l].m_BtnID1 = 1 + l;
			this.Tmp = this.GameT.GetChild(0).GetChild(1 + l).GetChild(0);
			this.Img_PageBG[l] = this.Tmp.GetComponent<Image>();
			this.Tmp = this.GameT.GetChild(0).GetChild(1 + l).GetChild(1);
			this.Img_PageIcon[l] = this.Tmp.GetComponent<Image>();
			this.GUIM.SetFastivalImage(this.mPackID, 2, this.Img_PageIcon[l]);
			this.Img_PageIcon[l].SetNativeSize();
			this.PageT[l] = this.GameT.GetChild(0).GetChild(3 + l);
		}
		this.Img_GiftNum = this.GameT.GetChild(0).GetChild(1).GetChild(3).GetComponent<Image>();
		this.Img_MainGiftNum = this.GameT.GetChild(0).GetChild(1).GetChild(3).GetChild(0).GetComponent<Image>();
		this.Img_MainGiftNum.sprite = this.door.LoadSprite("UI_main_mess_ex_dark");
		this.Img_MainGiftNum.material = this.door.LoadMaterial();
		this.tmpImg = this.GameT.GetChild(0).GetChild(1).GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_mess_ex_light");
		this.tmpImg.material = this.door.LoadMaterial();
		this.text_GiftNum = this.GameT.GetChild(0).GetChild(1).GetChild(3).GetChild(1).GetComponent<UIText>();
		this.text_GiftNum.font = this.TTFont;
		this.text_GiftNum.text = this.AGM.EnableRedPocketNum.ToString();
		this.text_GiftNum.SetAllDirty();
		this.text_GiftNum.cachedTextGenerator.Invalidate();
		this.text_GiftNum.cachedTextGeneratorForLayout.Invalidate();
		this.Img_GiftNum.rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_GiftNum.preferredWidth), this.Img_GiftNum.rectTransform.sizeDelta.y);
		if (ActivityManager.Instance.ServerEventTime - ActivityGiftManager.Instance.ActivityGiftBeginTime >= 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && this.DM.RoleAlliance.Rank == AllianceRank.RANK5 && ActivityGiftManager.Instance.mLeaderRedPocketResetTime - ActivityManager.Instance.ServerEventTime <= 0L)
		{
			this.Img_GiftNum.gameObject.SetActive(true);
			this.Img_MainGiftNum.gameObject.SetActive(true);
			this.text_GiftNum.gameObject.SetActive(false);
		}
		else
		{
			this.Img_MainGiftNum.gameObject.SetActive(false);
			if (this.AGM.EnableRedPocketNum > 0)
			{
				this.text_GiftNum.gameObject.SetActive(true);
				this.Img_GiftNum.gameObject.SetActive(true);
			}
			else
			{
				this.text_GiftNum.gameObject.SetActive(false);
				this.Img_GiftNum.gameObject.SetActive(false);
			}
		}
		this.btn_I = this.GameT.GetChild(0).GetChild(5).GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_I.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_I.m_Handler = this;
		this.btn_I.m_BtnID1 = 7;
		this.btn_I.m_EffectType = e_EffectType.e_Scale;
		this.btn_I.transition = Selectable.Transition.None;
		this.Img_ActTime = this.GameT.GetChild(0).GetChild(6).GetComponent<Image>();
		this.text_Close[0] = this.GameT.GetChild(0).GetChild(6).GetChild(0).GetComponent<UIText>();
		this.text_Close[0].font = this.TTFont;
		this.text_Close[0].text = this.DM.mStringTable.GetStringByID(8110u);
		this.text_Close[1] = this.GameT.GetChild(0).GetChild(6).GetChild(1).GetComponent<UIText>();
		this.text_Close[1].font = this.TTFont;
		this.text_Close[2] = this.GameT.GetChild(0).GetChild(6).GetChild(2).GetComponent<UIText>();
		this.text_Close[2].font = this.TTFont;
		this.text_Close[2].text = this.DM.mStringTable.GetStringByID(5042u);
		if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && ActivityManager.Instance.ServerEventTime - this.AGM.ActivityGiftBeginTime >= 0L)
		{
			this.text_Close[0].gameObject.SetActive(true);
			this.text_Close[1].gameObject.SetActive(true);
			this.text_Close[2].gameObject.SetActive(false);
			this.Img_ActTime.sprite = this.SArray.m_Sprites[5];
			this.Cstr_ActivityCDTime.ClearString();
			if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 86400L)
			{
				this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) / 86400L, 1, false);
				this.Cstr_ActivityCDTime.AppendFormat("{0}d");
			}
			else if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime >= 0L)
			{
				this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) / 3600L, 2, false);
				this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) % 3600L / 60L, 2, false);
				this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) % 60L, 2, false);
				this.Cstr_ActivityCDTime.AppendFormat("{0}:{1}:{2}");
			}
			else
			{
				this.Cstr_ActivityCDTime.AppendFormat("00:00:00");
			}
			this.text_Close[1].text = this.Cstr_ActivityCDTime.ToString();
			this.text_Close[1].SetAllDirty();
			this.text_Close[1].cachedTextGenerator.Invalidate();
		}
		else
		{
			this.IsActTime = false;
			this.text_Close[0].gameObject.SetActive(false);
			this.text_Close[1].gameObject.SetActive(false);
			this.text_Close[2].gameObject.SetActive(true);
			this.Img_ActTime.sprite = this.SArray.m_Sprites[6];
		}
		this.Img_MainGifeBG = this.PageT[0].GetChild(0).GetComponent<Image>();
		this.btn_MainGift = this.PageT[0].GetChild(0).GetChild(0).GetComponent<UIButton>();
		this.btn_MainGift.m_Handler = this;
		this.btn_MainGift.m_BtnID1 = 3;
		this.btn_MainGift.SetButtonEffectType(e_EffectType.e_Scale);
		this.btn_MainGift.transition = Selectable.Transition.None;
		this.uToolMainGift = this.PageT[0].GetChild(0).GetChild(0).GetComponent<uButtonScale>();
		this.text_MainGiftGive = this.PageT[0].GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_MainGiftGive.font = this.TTFont;
		this.Img_MainGife = this.PageT[0].GetChild(0).GetChild(1).GetComponent<Image>();
		this.text_MainGiftGive_Meber = this.PageT[0].GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_MainGiftGive_Meber.font = this.TTFont;
		this.Img_MainGifeLight = this.PageT[0].GetChild(0).GetChild(2).GetComponent<Image>();
		this.Img_MainGifeIcon = this.PageT[0].GetChild(0).GetChild(3).GetComponent<Image>();
		this.GUIM.SetFastivalImage(this.mPackID, 1, this.Img_MainGifeIcon);
		this.Img_MainGifeIcon.SetNativeSize();
		this.text_MainGiftReSetTime = this.PageT[0].GetChild(0).GetChild(4).GetComponent<UIText>();
		this.text_MainGiftReSetTime.font = this.TTFont;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		this.Cstr_CDTime.ClearString();
		if (GameConstants.GetDateTime(this.AGM.ActivityGiftBeginTime).Hour == 0)
		{
			cstring.IntToFormat(24L, 2, false);
		}
		else
		{
			cstring.IntToFormat((long)GameConstants.GetDateTime(this.AGM.ActivityGiftBeginTime).Hour, 2, false);
		}
		cstring.IntToFormat((long)GameConstants.GetDateTime(this.AGM.ActivityGiftBeginTime).Minute, 2, false);
		cstring.AppendFormat("{0}:{1}");
		this.Cstr_CDTime.StringToFormat(cstring);
		this.Cstr_CDTime.AppendFormat(this.DM.mStringTable.GetStringByID(11200u));
		this.text_MainGiftReSetTime.resizeTextMinSize = 10;
		this.text_MainGiftReSetTime.text = this.Cstr_CDTime.ToString();
		this.text_MainGiftReSetTime.rectTransform.sizeDelta = new Vector2(411f, this.text_MainGiftReSetTime.rectTransform.sizeDelta.y);
		this.text_MainGiftReSetTime.SetAllDirty();
		this.text_MainGiftReSetTime.cachedTextGenerator.Invalidate();
		this.text_MainGiftReSetTime.cachedTextGeneratorForLayout.Invalidate();
		this.text_MainGiftInfo[0] = this.PageT[0].GetChild(0).GetChild(5).GetComponent<UIText>();
		this.text_MainGiftInfo[0].font = this.TTFont;
		this.text_MainGiftInfo[1] = this.PageT[0].GetChild(0).GetChild(6).GetComponent<UIText>();
		this.text_MainGiftInfo[1].font = this.TTFont;
		if (this.GroupID_Data.Count > 0)
		{
			this.text_MainGiftInfo[0].text = this.DM.mStringTable.GetStringByID((uint)this.DM.FastivalSpecialDataTable.GetRecordByKey(this.GroupID_Data[0]).ItemName);
			this.text_MainGiftInfo[1].text = this.DM.mStringTable.GetStringByID((uint)this.DM.FastivalSpecialDataTable.GetRecordByKey(this.GroupID_Data[0]).ItemHint);
		}
		this.MainGiftBtnCheck();
		this.Img_NoGiftGet = this.PageT[0].GetChild(1).GetComponent<Image>();
		this.text_NoGiftGet = this.PageT[0].GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_NoGiftGet.font = this.TTFont;
		this.text_NoGiftGet.text = this.DM.mStringTable.GetStringByID(11203u);
		this.m_ScrollPanel = this.PageT[0].GetChild(2).GetComponent<ScrollPanel>();
		this.m_ScrollPanel.m_ScrollPanelID = 1;
		this.Tmp = this.PageT[0].GetChild(3);
		this.tmpImg = this.Tmp.GetChild(1).GetChild(0).GetComponent<Image>();
		this.tmpImg.material = this.GUIM.m_ItemIconSpriteAsset.GetMaterial();
		this.tmpImg = this.Tmp.GetChild(1).GetChild(1).GetComponent<Image>();
		this.tmpImg.material = this.GUIM.GetFrameMaterial();
		UIButton component = this.Tmp.GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 4;
		component.SoundIndex = 64;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		UIText component2 = this.Tmp.GetChild(2).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTFont;
		component2.text = this.DM.mStringTable.GetStringByID(11189u);
		this.tmpImg = this.Tmp.GetChild(3).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.tmpImg.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		component2 = this.Tmp.GetChild(3).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTFont;
		component2.text = this.DM.mStringTable.GetStringByID(7012u);
		this.tmpImg = this.Tmp.GetChild(4).GetComponent<Image>();
		this.GUIM.SetFastivalImage(this.mPackID, 3, this.tmpImg);
		this.tmpImg.SetNativeSize();
		component2 = this.Tmp.GetChild(4).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTFont;
		component2 = this.Tmp.GetChild(5).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTFont;
		this.tmpImg = this.Tmp.GetChild(6).GetComponent<Image>();
		this.tmpbtnHint = this.tmpImg.gameObject.AddComponent<UIButtonHint>();
		this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.tmpbtnHint.m_Handler = this;
		this.tmpbtnHint.Parm1 = 3;
		component2 = this.Tmp.GetChild(6).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTFont;
		component2 = this.Tmp.GetChild(7).GetComponent<UIText>();
		component2.font = this.TTFont;
		component2.rectTransform.sizeDelta = new Vector2(240f, component2.rectTransform.sizeDelta.y);
		this.tmpImg = this.Tmp.GetChild(8).GetComponent<Image>();
		this.tmpbtnHint = this.tmpImg.gameObject.AddComponent<UIButtonHint>();
		this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.tmpbtnHint.m_Handler = this;
		this.tmpbtnHint.Parm1 = 1;
		this.tmpImg = this.Tmp.GetChild(9).GetComponent<Image>();
		this.tmpbtnHint = this.tmpImg.gameObject.AddComponent<UIButtonHint>();
		this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.tmpbtnHint.m_Handler = this;
		this.tmpbtnHint.Parm1 = 2;
		this.AGM.sortData();
		this.tmplist.Clear();
		for (int m = 0; m < this.AGM.mListActGift.Count; m++)
		{
			this.tmplist.Add(137f);
		}
		this.m_ScrollPanel.IntiScrollPanel(337f, 0f, 0f, this.tmplist, 6, this);
		this.m_Mask = this.m_ScrollPanel.transform.GetComponent<CScrollRect>();
		UIButtonHint.scrollRect = this.m_Mask;
		this.ScrollPanelCheck();
		this.text_Info = this.PageT[1].GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_Info.font = this.TTFont;
		this.text_Info.text = this.DM.mStringTable.GetStringByID(11201u);
		this.Img_NoGiftBuy = this.PageT[1].GetChild(1).GetComponent<Image>();
		this.text_NoGiftBuy = this.PageT[1].GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_NoGiftBuy.font = this.TTFont;
		this.text_NoGiftBuy.text = this.DM.mStringTable.GetStringByID(11211u);
		this.m_ScrollPanel_Buy = this.PageT[1].GetChild(2).GetComponent<ScrollPanel>();
		this.m_ScrollPanel_Buy.m_ScrollPanelID = 2;
		this.Tmp = this.PageT[1].GetChild(3);
		component = this.Tmp.GetChild(1).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 5;
		component.SoundIndex = 64;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		this.tmpImg = this.Tmp.GetChild(1).GetChild(0).GetComponent<Image>();
		this.tmpImg.material = this.GUIM.m_ItemIconSpriteAsset.GetMaterial();
		this.tmpImg = this.Tmp.GetChild(1).GetChild(1).GetComponent<Image>();
		this.tmpImg.material = this.GUIM.GetFrameMaterial();
		component = this.Tmp.GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 6;
		component.SoundIndex = 64;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		component2 = this.Tmp.GetChild(2).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTFont;
		component2 = this.Tmp.GetChild(2).GetChild(1).GetComponent<UIText>();
		component2.font = this.TTFont;
		component2.text = this.DM.mStringTable.GetStringByID(284u);
		component2 = this.Tmp.GetChild(2).GetChild(3).GetComponent<UIText>();
		component2.font = this.TTFont;
		component2 = this.Tmp.GetChild(3).GetComponent<UIText>();
		component2.font = this.TTFont;
		component2 = this.Tmp.GetChild(4).GetComponent<UIText>();
		component2.font = this.TTFont;
		component2.resizeTextMinSize = 10;
		if (this.bThirdParty)
		{
			this.Tmp.GetChild(2).GetChild(0).gameObject.SetActive(false);
			this.Tmp.GetChild(2).GetChild(2).gameObject.SetActive(true);
			this.Tmp.GetChild(2).GetChild(3).gameObject.SetActive(true);
		}
		if (this.GUIM.IsArabic)
		{
			this.Tmp.GetChild(2).GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(-1f, 1f, 1f);
			this.Tmp.GetChild(2).GetChild(3).GetComponent<RectTransform>().localScale = new Vector3(-1f, 1f, 1f);
		}
		int tableCount = this.DM.FastivalSpecialDataTable.TableCount;
		for (int n = 0; n < tableCount; n++)
		{
			FastivalSpecialData fastivalSpecialData = this.DM.FastivalSpecialDataTable.GetRecordByIndex(n);
			for (int num2 = 0; num2 < this.GroupID_Data.Count; num2++)
			{
				if (fastivalSpecialData.ID == this.GroupID_Data[num2] && fastivalSpecialData.StoreID > 0u)
				{
					this.tmplist_Buy.Add(120f);
					this.GroupID_Buy_Data.Add(fastivalSpecialData.ID);
					break;
				}
			}
		}
		this.m_ScrollPanel_Buy.IntiScrollPanel(424f, 0f, 0f, this.tmplist_Buy, 6, this);
		if (this.tmplist_Buy.Count == 0 || this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime < 0L)
		{
			this.Img_NoGiftBuy.gameObject.SetActive(true);
			this.m_ScrollPanel_Buy.gameObject.SetActive(false);
		}
		else
		{
			this.Img_NoGiftBuy.gameObject.SetActive(false);
			this.m_ScrollPanel_Buy.gameObject.SetActive(true);
		}
		if (this.tmplist_Buy.Count == 0)
		{
			this.btnPage[1].gameObject.SetActive(false);
		}
		else
		{
			this.btnPage[1].gameObject.SetActive(true);
		}
		this.text_Title = this.GameT.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.tmpImg = this.GameT.GetChild(2).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
		this.tmpImg.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(2).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.m_Mat;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
		this.SetPage(this.AGM.mActivityGiftPage);
	}

	// Token: 0x06000E97 RID: 3735 RVA: 0x00181834 File Offset: 0x0017FA34
	public void ScrollPanelCheck()
	{
		if (this.tmplist.Count == 0)
		{
			this.Img_NoGiftGet.gameObject.SetActive(true);
			this.m_ScrollPanel.gameObject.SetActive(false);
		}
		else
		{
			this.Img_NoGiftGet.gameObject.SetActive(false);
			this.m_ScrollPanel.gameObject.SetActive(true);
		}
	}

	// Token: 0x06000E98 RID: 3736 RVA: 0x0018189C File Offset: 0x0017FA9C
	public void SetPage(byte Idx)
	{
		this.mPage = Idx;
		if (this.mPage == 0)
		{
			this.text_Title.text = this.DM.mStringTable.GetStringByID(11186u);
			this.PageT[0].gameObject.SetActive(true);
			this.PageT[1].gameObject.SetActive(false);
			this.Img_PageBG[0].color = new Color(1f, 1f, 1f, 1f);
			this.Img_PageBG[1].color = new Color(1f, 1f, 1f, 0f);
			this.Img_BG.gameObject.SetActive(true);
			this.btn_I.gameObject.SetActive(true);
			this.AGM.sortData();
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			this.m_Mask.StopMovement();
			this.m_ScrollPanel.GoTo(0);
		}
		else
		{
			this.text_Title.text = this.DM.mStringTable.GetStringByID(11216u);
			this.PageT[0].gameObject.SetActive(false);
			this.PageT[1].gameObject.SetActive(true);
			this.Img_PageBG[0].color = new Color(1f, 1f, 1f, 0f);
			this.Img_PageBG[1].color = new Color(1f, 1f, 1f, 1f);
			this.Img_BG.gameObject.SetActive(false);
			this.btn_I.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000E99 RID: 3737 RVA: 0x00181A60 File Offset: 0x0017FC60
	public override void OnClose()
	{
		if (this.Cstr_CDTime != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_CDTime);
		}
		if (this.Cstr_ActivityCDTime != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_ActivityCDTime);
		}
		if (this.Cstr_HintNum != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_HintNum);
		}
		if (this.Cstr_HintTime != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_HintTime);
		}
		if (this.Cstr_HintRank != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_HintRank);
		}
		for (int i = 0; i < 6; i++)
		{
			if (this.Cstr_GiftNum[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_GiftNum[i]);
			}
			if (this.Cstr_GiftCDTime[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_GiftCDTime[i]);
			}
			if (this.Cstr_Price[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Price[i]);
			}
		}
	}

	// Token: 0x06000E9A RID: 3738 RVA: 0x00181B6C File Offset: 0x0017FD6C
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
		case 2:
			if (this.mPage != (byte)(sender.m_BtnID1 - 1))
			{
				this.SetPage((byte)(sender.m_BtnID1 - 1));
			}
			break;
		case 3:
			if (this.GUIM.ShowUILock(EUILock.ActGift))
			{
				this.AGM.AllianceLeaderSendGift();
			}
			break;
		case 4:
		{
			if (sender.m_BtnID2 < 0 || this.tmpSendTime >= 0f)
			{
				return;
			}
			this.tmpSendTime = 0f;
			RectTransform component = sender.transform.parent.GetComponent<RectTransform>();
			RectTransform component2 = sender.transform.parent.parent.GetComponent<RectTransform>();
			RectTransform component3 = sender.transform.parent.parent.parent.GetComponent<RectTransform>();
			RectTransform component4 = sender.transform.parent.parent.parent.parent.GetComponent<RectTransform>();
			this.GUIM.mStartV2 = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + component.anchoredPosition.x + component2.anchoredPosition.x + component3.anchoredPosition.x - component3.sizeDelta.x / 2f + component4.sizeDelta.x + 46f, this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - component.anchoredPosition.y - component2.anchoredPosition.y - component3.anchoredPosition.y - component3.sizeDelta.y / 2f - 17f);
			this.AGM.GetGift(this.AGM.mListActGift[sender.m_BtnID2].serverIndex, this.DM.FastivalSpecialDataTable.GetRecordByKey(this.AGM.mListActGift[sender.m_BtnID2].SN).StoreID);
			break;
		}
		case 5:
			ActivityGiftManager.Instance.mActivityGiftPage = 1;
			MallManager.Instance.OpenDetail((ushort)sender.m_BtnID2);
			break;
		case 6:
		{
			if (this.GUIM.BuildingData.GetBuildData(8, 0).Level < 17)
			{
				this.GUIM.MsgStr.ClearString();
				this.GUIM.MsgStr.Append(this.DM.mStringTable.GetStringByID(11210u));
				GUIManager.Instance.AddHUDMessage(this.GUIM.MsgStr.ToString(), 255, true);
				return;
			}
			if (this.AGM.mListActGift.Count > 9)
			{
				this.GUIM.MsgStr.ClearString();
				this.GUIM.MsgStr.Append(this.DM.mStringTable.GetStringByID(11209u));
				GUIManager.Instance.AddHUDMessage(this.GUIM.MsgStr.ToString(), 255, true);
				return;
			}
			if (sender.m_BtnID2 < 0 || this.GroupID_Buy_Data.Count < 1)
			{
				return;
			}
			if (MallManager.Instance.CheckbWaitBuy_RedPocket(true))
			{
				return;
			}
			FastivalSpecialData recordByKey = DataManager.Instance.FastivalSpecialDataTable.GetRecordByKey(this.GroupID_Buy_Data[sender.m_BtnID2]);
			MallManager.Instance.Send_SPTREASURE_PREBUY_CHECK(ESpcialTreasureType.ESTST_RedPocket, recordByKey.StoreID, true);
			break;
		}
		case 7:
			this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(11186u), this.DM.mStringTable.GetStringByID(11199u), null, null, 0, 0, true, true);
			break;
		}
	}

	// Token: 0x06000E9B RID: 3739 RVA: 0x00181FB4 File Offset: 0x001801B4
	public void OnButtonDown(UIButtonHint sender)
	{
		switch (sender.Parm1)
		{
		case 1:
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.Cstr_HintNum, Vector2.zero);
			break;
		case 2:
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.Cstr_HintTime, Vector2.zero);
			break;
		case 3:
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.Cstr_HintRank, Vector2.zero);
			break;
		}
	}

	// Token: 0x06000E9C RID: 3740 RVA: 0x0018205C File Offset: 0x0018025C
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(true);
	}

	// Token: 0x06000E9D RID: 3741 RVA: 0x00182070 File Offset: 0x00180270
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x06000E9E RID: 3742 RVA: 0x00182074 File Offset: 0x00180274
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06000E9F RID: 3743 RVA: 0x00182078 File Offset: 0x00180278
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelId == 1)
		{
			if (panelObjectIdx < 6)
			{
				if (!this.bFindScrollp[panelObjectIdx])
				{
					this.bFindScrollp[panelObjectIdx] = true;
					Transform transform = item.transform;
					this.tmpItem[panelObjectIdx].ItemGO = item;
					this.tmpItem[panelObjectIdx].ScrollItem = transform.GetComponent<ScrollPanelItem>();
					this.tmpItem[panelObjectIdx].ScrollItem.m_BtnID1 = panelObjectIdx;
					this.tmpItem[panelObjectIdx].GiftItem_F = transform.GetChild(1).GetChild(1).GetComponent<Image>();
					this.tmpItem[panelObjectIdx].GiftItem = transform.GetChild(1).GetChild(0).GetComponent<Image>();
					this.tmpItem[panelObjectIdx].ReceiveBtn = transform.GetChild(2).GetComponent<UIButton>();
					this.tmpItem[panelObjectIdx].ReceiveBtn.m_Handler = this;
					this.tmpItem[panelObjectIdx].ReceiveBtnText = transform.GetChild(2).GetChild(0).GetComponent<UIText>();
					this.tmpItem[panelObjectIdx].ReceiveImage = transform.GetChild(3).GetComponent<Image>();
					this.tmpItem[panelObjectIdx].ReceiveImgText = transform.GetChild(3).GetChild(0).GetComponent<UIText>();
					this.tmpItem[panelObjectIdx].NumImage = transform.GetChild(4).GetComponent<Image>();
					this.tmpItem[panelObjectIdx].NumText = transform.GetChild(4).GetChild(0).GetComponent<UIText>();
					this.tmpItem[panelObjectIdx].CDTimeImage = transform.GetChild(5).GetComponent<Image>();
					this.tmpItem[panelObjectIdx].CDTimeText = transform.GetChild(5).GetChild(0).GetComponent<UIText>();
					this.tmpItem[panelObjectIdx].RankImage = transform.GetChild(6).GetComponent<Image>();
					this.tmpbtnHint = this.tmpItem[panelObjectIdx].RankImage.gameObject.AddComponent<UIButtonHint>();
					this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
					this.tmpbtnHint.m_Handler = this;
					this.tmpbtnHint.Parm1 = 3;
					this.tmpItem[panelObjectIdx].PlayerNameText = transform.GetChild(6).GetChild(0).GetComponent<UIText>();
					this.tmpItem[panelObjectIdx].GiftNameText = transform.GetChild(7).GetComponent<UIText>();
					this.tmpImg = transform.GetChild(8).GetComponent<Image>();
					this.tmpbtnHint = this.tmpImg.gameObject.AddComponent<UIButtonHint>();
					this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
					this.tmpbtnHint.m_Handler = this;
					this.tmpbtnHint.Parm1 = 1;
					this.tmpImg = transform.GetChild(9).GetComponent<Image>();
					this.tmpbtnHint = this.tmpImg.gameObject.AddComponent<UIButtonHint>();
					this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
					this.tmpbtnHint.m_Handler = this;
					this.tmpbtnHint.Parm1 = 2;
				}
				if (dataIdx < 0 || dataIdx > this.tmplist.Count || dataIdx > this.AGM.mListActGift.Count)
				{
					return;
				}
				FastivalSpecialData recordByKey = DataManager.Instance.FastivalSpecialDataTable.GetRecordByKey(this.AGM.mListActGift[dataIdx].SN);
				this.tmpItem[panelObjectIdx].GiftItem_F.sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Item, (byte)recordByKey.FrameColor);
				this.tmpItem[panelObjectIdx].GiftItem.sprite = this.GUIM.m_ItemIconSpriteAsset.LoadSprite(recordByKey.PicNo);
				if (this.AGM.mListActGift[dataIdx].Status == 0)
				{
					this.tmpItem[panelObjectIdx].ReceiveBtn.gameObject.SetActive(true);
					this.tmpItem[panelObjectIdx].ReceiveImage.gameObject.SetActive(false);
				}
				else
				{
					this.tmpItem[panelObjectIdx].ReceiveBtn.gameObject.SetActive(false);
					this.tmpItem[panelObjectIdx].ReceiveImage.gameObject.SetActive(true);
				}
				if (this.AGM.mListActGift[dataIdx].Num <= 5)
				{
					this.tmpItem[panelObjectIdx].NumText.color = this.text_Red;
				}
				else
				{
					this.tmpItem[panelObjectIdx].NumText.color = this.text_Green;
				}
				this.Cstr_GiftNum[panelObjectIdx].ClearString();
				this.Cstr_GiftNum[panelObjectIdx].IntToFormat((long)this.AGM.mListActGift[dataIdx].Num, 1, true);
				this.Cstr_GiftNum[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(11190u));
				this.tmpItem[panelObjectIdx].NumText.text = this.Cstr_GiftNum[panelObjectIdx].ToString();
				this.tmpItem[panelObjectIdx].NumText.SetAllDirty();
				this.tmpItem[panelObjectIdx].NumText.cachedTextGenerator.Invalidate();
				this.Cstr_GiftCDTime[panelObjectIdx].ClearString();
				if (this.AGM.mListActGift[dataIdx].RcvTime - ActivityManager.Instance.ServerEventTime >= 0L)
				{
					this.Cstr_GiftCDTime[panelObjectIdx].IntToFormat((this.AGM.mListActGift[dataIdx].RcvTime - ActivityManager.Instance.ServerEventTime) / 3600L, 2, false);
					this.Cstr_GiftCDTime[panelObjectIdx].IntToFormat((this.AGM.mListActGift[dataIdx].RcvTime - ActivityManager.Instance.ServerEventTime) % 3600L / 60L, 2, false);
					this.Cstr_GiftCDTime[panelObjectIdx].IntToFormat((this.AGM.mListActGift[dataIdx].RcvTime - ActivityManager.Instance.ServerEventTime) % 60L, 2, false);
				}
				else
				{
					this.Cstr_GiftCDTime[panelObjectIdx].IntToFormat(0L, 2, false);
					this.Cstr_GiftCDTime[panelObjectIdx].IntToFormat(0L, 2, false);
					this.Cstr_GiftCDTime[panelObjectIdx].IntToFormat(0L, 2, false);
				}
				this.Cstr_GiftCDTime[panelObjectIdx].AppendFormat("{0}:{1}:{2}");
				this.tmpItem[panelObjectIdx].CDTimeText.text = this.Cstr_GiftCDTime[panelObjectIdx].ToString();
				this.tmpItem[panelObjectIdx].CDTimeText.SetAllDirty();
				this.tmpItem[panelObjectIdx].CDTimeText.cachedTextGenerator.Invalidate();
				this.tmpItem[panelObjectIdx].RankImage.sprite = this.SArray.m_Sprites[(int)(this.AGM.mListActGift[dataIdx].Rank - 1)];
				this.tmpItem[panelObjectIdx].PlayerNameText.text = this.AGM.mListActGift[dataIdx].Name.ToString();
				this.tmpItem[panelObjectIdx].PlayerNameText.SetAllDirty();
				this.tmpItem[panelObjectIdx].PlayerNameText.cachedTextGenerator.Invalidate();
				this.tmpItem[panelObjectIdx].GiftNameText.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.ItemName);
				this.tmpItem[panelObjectIdx].GiftNameText.SetAllDirty();
				this.tmpItem[panelObjectIdx].GiftNameText.cachedTextGenerator.Invalidate();
				this.tmpItem[panelObjectIdx].ReceiveBtn.m_BtnID2 = dataIdx;
				this.tmpItem[panelObjectIdx].DataIndex = (byte)dataIdx;
			}
		}
		else if (panelObjectIdx < 6)
		{
			if (!this.bFindScrollp_Buy[panelObjectIdx])
			{
				this.bFindScrollp_Buy[panelObjectIdx] = true;
				Transform transform2 = item.transform;
				this.tmpItem_Buy[panelObjectIdx].ItemGO = item;
				this.tmpItem_Buy[panelObjectIdx].ScrollItem = transform2.GetComponent<ScrollPanelItem>();
				this.tmpItem_Buy[panelObjectIdx].ScrollItem.m_BtnID1 = panelObjectIdx;
				this.tmpItem_Buy[panelObjectIdx].BuyItemBtn = transform2.GetChild(1).GetComponent<UIButton>();
				this.tmpItem_Buy[panelObjectIdx].BuyItemBtn.m_Handler = this;
				this.tmpItem_Buy[panelObjectIdx].BuyItemImage = transform2.GetChild(1).GetChild(0).GetComponent<Image>();
				this.tmpItem_Buy[panelObjectIdx].BuyItemImage_F = transform2.GetChild(1).GetChild(1).GetComponent<Image>();
				this.tmpItem_Buy[panelObjectIdx].BuyBtn = transform2.GetChild(2).GetComponent<UIButton>();
				this.tmpItem_Buy[panelObjectIdx].BuyBtn.m_Handler = this;
				this.tmpItem_Buy[panelObjectIdx].PriceText = transform2.GetChild(2).GetChild(0).GetComponent<UIText>();
				this.tmpItem_Buy[panelObjectIdx].BuyText = transform2.GetChild(2).GetChild(1).GetComponent<UIText>();
				this.tmpItem_Buy[panelObjectIdx].ThirdPartyImage = transform2.GetChild(2).GetChild(2).GetComponent<Image>();
				this.tmpItem_Buy[panelObjectIdx].Price_ThirdPartyText = transform2.GetChild(2).GetChild(3).GetComponent<UIText>();
				this.tmpItem_Buy[panelObjectIdx].GiftNameText = transform2.GetChild(3).GetComponent<UIText>();
				this.tmpItem_Buy[panelObjectIdx].GiftInfoText = transform2.GetChild(4).GetComponent<UIText>();
			}
			if (dataIdx < 0 || dataIdx > this.tmplist_Buy.Count)
			{
				return;
			}
			FastivalSpecialData recordByKey2 = DataManager.Instance.FastivalSpecialDataTable.GetRecordByKey(this.GroupID_Buy_Data[dataIdx]);
			this.tmpItem_Buy[panelObjectIdx].BuyItemImage_F.sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Item, (byte)recordByKey2.FrameColor);
			this.tmpItem_Buy[panelObjectIdx].BuyItemImage.sprite = this.GUIM.m_ItemIconSpriteAsset.LoadSprite(recordByKey2.PicNo);
			uint storeID = recordByKey2.StoreID;
			if (this.bThirdParty)
			{
				this.SetPrice(this.tmpItem_Buy[panelObjectIdx].Price_ThirdPartyText, this.Cstr_Price[panelObjectIdx], storeID);
			}
			else
			{
				this.SetPrice(this.tmpItem_Buy[panelObjectIdx].PriceText, this.Cstr_Price[panelObjectIdx], storeID);
			}
			this.tmpItem_Buy[panelObjectIdx].GiftNameText.text = this.DM.mStringTable.GetStringByID((uint)recordByKey2.ItemName);
			this.tmpItem_Buy[panelObjectIdx].GiftNameText.SetAllDirty();
			this.tmpItem_Buy[panelObjectIdx].GiftNameText.cachedTextGenerator.Invalidate();
			this.tmpItem_Buy[panelObjectIdx].GiftInfoText.text = this.DM.mStringTable.GetStringByID((uint)recordByKey2.ItemHint);
			this.tmpItem_Buy[panelObjectIdx].GiftInfoText.SetAllDirty();
			this.tmpItem_Buy[panelObjectIdx].GiftInfoText.cachedTextGenerator.Invalidate();
			this.tmpItem_Buy[panelObjectIdx].BuyItemBtn.m_BtnID2 = (int)recordByKey2.ItemID;
			this.tmpItem_Buy[panelObjectIdx].BuyBtn.m_BtnID2 = dataIdx;
			this.tmpItem_Buy[panelObjectIdx].DataIndex = (byte)dataIdx;
		}
	}

	// Token: 0x06000EA0 RID: 3744 RVA: 0x00182C34 File Offset: 0x00180E34
	public void SetPrice(UIText PriceText, CString PriceStr, uint TreasureID)
	{
		if (PriceText == null)
		{
			return;
		}
		TreasureID = MallManager.Instance.TreasureIDTransToNew(TreasureID);
		PriceStr.Length = 0;
		string productPaltformPriceByID = MallManager.Instance.GetProductPaltformPriceByID((int)TreasureID);
		string productPriceByID = MallManager.Instance.GetProductPriceByID((int)TreasureID);
		if (productPaltformPriceByID != null && productPaltformPriceByID != string.Empty)
		{
			PriceStr.Append(productPaltformPriceByID);
		}
		else
		{
			if (productPriceByID == null)
			{
				double f = 0.0;
				this.NeedUpDate = true;
				PriceStr.DoubleToFormat(f, 2, true);
			}
			else
			{
				PriceStr.StringToFormat(productPriceByID);
			}
			string currency = MallManager.Instance.GetCurrency((int)TreasureID);
			if (currency != null)
			{
				PriceStr.StringToFormat(currency);
				if (MallManager.Instance.bChangePosCurrency(currency))
				{
					PriceStr.AppendFormat("{0} {1}");
				}
				else
				{
					PriceStr.AppendFormat("{1} {0}");
				}
			}
			else
			{
				PriceStr.AppendFormat("${0}");
			}
		}
		PriceText.text = PriceStr.ToString();
		PriceText.SetAllDirty();
		PriceText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000EA1 RID: 3745 RVA: 0x00182D3C File Offset: 0x00180F3C
	public void UpDateItemNum(byte Idx)
	{
		for (int i = 0; i < 6; i++)
		{
			if (this.bFindScrollp[i] && (int)this.tmpItem[i].DataIndex < this.AGM.mListActGift.Count)
			{
				if (this.AGM.mListActGift[(int)this.tmpItem[i].DataIndex].Num <= 5)
				{
					this.tmpItem[i].NumText.color = this.text_Red;
				}
				else
				{
					this.tmpItem[i].NumText.color = this.text_Green;
				}
				this.Cstr_GiftNum[i].ClearString();
				this.Cstr_GiftNum[i].IntToFormat((long)this.AGM.mListActGift[(int)this.tmpItem[i].DataIndex].Num, 1, true);
				this.Cstr_GiftNum[i].AppendFormat(this.DM.mStringTable.GetStringByID(11190u));
				this.tmpItem[i].NumText.text = this.Cstr_GiftNum[i].ToString();
				this.tmpItem[i].NumText.SetAllDirty();
				this.tmpItem[i].NumText.cachedTextGenerator.Invalidate();
			}
		}
	}

	// Token: 0x06000EA2 RID: 3746 RVA: 0x00182EB4 File Offset: 0x001810B4
	public void UpDateItemStatus(byte Idx)
	{
		for (int i = 0; i < 6; i++)
		{
			if (this.bFindScrollp[i] && this.tmpItem[i].ItemGO.activeInHierarchy && (int)this.tmpItem[i].DataIndex < this.AGM.mListActGift.Count && Idx == this.AGM.mListActGift[(int)this.tmpItem[i].DataIndex].serverIndex)
			{
				if (this.AGM.mListActGift[(int)this.tmpItem[i].DataIndex].Status == 0)
				{
					this.tmpItem[i].ReceiveBtn.gameObject.SetActive(true);
					this.tmpItem[i].ReceiveImage.gameObject.SetActive(false);
				}
				else
				{
					this.tmpItem[i].ReceiveBtn.gameObject.SetActive(false);
					this.tmpItem[i].ReceiveImage.gameObject.SetActive(true);
				}
			}
		}
	}

	// Token: 0x06000EA3 RID: 3747 RVA: 0x00182FF0 File Offset: 0x001811F0
	public void UpdateItemPrice()
	{
		uint treasureID = 0u;
		for (int i = 0; i < 6; i++)
		{
			if (this.bFindScrollp_Buy[i] && this.tmpItem_Buy[i].ItemGO.activeInHierarchy)
			{
				if (this.bThirdParty)
				{
					this.SetPrice(this.tmpItem_Buy[i].PriceText, this.Cstr_Price[i], treasureID);
				}
				else
				{
					this.SetPrice(this.tmpItem_Buy[i].Price_ThirdPartyText, this.Cstr_Price[i], treasureID);
				}
			}
		}
	}

	// Token: 0x06000EA4 RID: 3748 RVA: 0x0018308C File Offset: 0x0018128C
	public void MainGiftBtnCheck()
	{
		if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && ActivityManager.Instance.ServerEventTime - this.AGM.ActivityGiftBeginTime >= 0L)
		{
			if (this.DM.RoleAlliance.Rank == AllianceRank.RANK5)
			{
				this.btn_MainGift.gameObject.SetActive(true);
				this.Img_MainGife.gameObject.SetActive(false);
			}
			else
			{
				this.btn_MainGift.gameObject.SetActive(false);
				this.Img_MainGife.gameObject.SetActive(true);
			}
			if (this.text_MainGiftReSetTime != null)
			{
				this.text_MainGiftReSetTime.gameObject.SetActive(true);
			}
		}
		else
		{
			this.btn_MainGift.gameObject.SetActive(false);
			this.Img_MainGife.gameObject.SetActive(false);
			if (this.text_MainGiftReSetTime != null)
			{
				this.text_MainGiftReSetTime.gameObject.SetActive(false);
			}
		}
		if (this.AGM.mLeaderRedPocketResetTime - ActivityManager.Instance.ServerEventTime <= 0L)
		{
			this.text_MainGiftGive.text = this.DM.mStringTable.GetStringByID(11187u);
			this.text_MainGiftGive_Meber.text = this.DM.mStringTable.GetStringByID(11204u);
			this.text_MainGiftGive.color = Color.white;
			this.text_MainGiftGive_Meber.color = this.text_Gray;
			this.uToolMainGift.enabled = true;
		}
		else
		{
			this.text_MainGiftGive.text = this.DM.mStringTable.GetStringByID(11188u);
			this.text_MainGiftGive_Meber.text = this.DM.mStringTable.GetStringByID(11188u);
			this.text_MainGiftGive.color = this.text_Gray;
			this.text_MainGiftGive_Meber.color = this.text_Meber;
			this.uToolMainGift.enabled = false;
		}
	}

	// Token: 0x06000EA5 RID: 3749 RVA: 0x0018329C File Offset: 0x0018149C
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			this.tmplist.Clear();
			for (int i = 0; i < this.AGM.mListActGift.Count; i++)
			{
				this.tmplist.Add(137f);
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			this.ScrollPanelCheck();
			break;
		case 2:
			this.UpDateItemNum((byte)arg2);
			break;
		case 3:
			this.UpDateItemStatus((byte)arg2);
			break;
		case 4:
			this.MainGiftBtnCheck();
			if (ActivityManager.Instance.ServerEventTime - ActivityGiftManager.Instance.ActivityGiftBeginTime >= 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && this.DM.RoleAlliance.Rank == AllianceRank.RANK5 && ActivityGiftManager.Instance.mLeaderRedPocketResetTime - ActivityManager.Instance.ServerEventTime <= 0L)
			{
				this.Img_GiftNum.gameObject.SetActive(true);
				this.Img_MainGiftNum.gameObject.SetActive(true);
				this.text_GiftNum.gameObject.SetActive(false);
			}
			else
			{
				this.Img_MainGiftNum.gameObject.SetActive(false);
				if (this.AGM.EnableRedPocketNum > 0)
				{
					this.text_GiftNum.gameObject.SetActive(true);
					this.Img_GiftNum.gameObject.SetActive(true);
				}
				else
				{
					this.text_GiftNum.gameObject.SetActive(false);
					this.Img_GiftNum.gameObject.SetActive(false);
				}
			}
			if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime < 0L)
			{
				this.Img_NoGiftBuy.gameObject.SetActive(true);
				this.m_ScrollPanel_Buy.gameObject.SetActive(false);
				this.IsActTime = false;
				this.text_Close[0].gameObject.SetActive(false);
				this.text_Close[1].gameObject.SetActive(false);
				this.text_Close[2].gameObject.SetActive(true);
				this.Img_ActTime.sprite = this.SArray.m_Sprites[6];
			}
			else
			{
				this.Img_NoGiftBuy.gameObject.SetActive(false);
				this.m_ScrollPanel_Buy.gameObject.SetActive(true);
				this.text_Close[0].gameObject.SetActive(true);
				this.text_Close[1].gameObject.SetActive(true);
				this.text_Close[2].gameObject.SetActive(false);
				this.Img_ActTime.sprite = this.SArray.m_Sprites[5];
				this.Cstr_ActivityCDTime.ClearString();
				if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 86400L)
				{
					this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) / 86400L, 1, false);
					this.Cstr_ActivityCDTime.AppendFormat("{0}d");
				}
				else if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime >= 0L)
				{
					this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) / 3600L, 2, false);
					this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) % 3600L / 60L, 2, false);
					this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) % 60L, 2, false);
					this.Cstr_ActivityCDTime.AppendFormat("{0}:{1}:{2}");
				}
				else
				{
					this.Cstr_ActivityCDTime.AppendFormat("00:00:00");
				}
				this.text_Close[1].text = this.Cstr_ActivityCDTime.ToString();
				this.text_Close[1].SetAllDirty();
				this.text_Close[1].cachedTextGenerator.Invalidate();
			}
			if (this.mPackID != this.AGM.GroupID && this.AGM.GroupID != 0)
			{
				this.mPackID = this.AGM.GroupID;
				for (int j = 0; j < 2; j++)
				{
					this.GUIM.SetFastivalImage(this.mPackID, 2, this.Img_PageIcon[j]);
					this.Img_PageIcon[j].SetNativeSize();
				}
				this.GUIM.SetFastivalImage(this.mPackID, 1, this.Img_MainGifeIcon);
				this.Img_MainGifeIcon.SetNativeSize();
				for (int k = 0; k < 6; k++)
				{
					if (this.bFindScrollp[k])
					{
						this.GUIM.SetFastivalImage(this.mPackID, 3, this.tmpItem[k].NumImage);
						this.tmpItem[k].NumImage.SetNativeSize();
					}
				}
			}
			break;
		case 5:
			this.SetPage(0);
			this.tmplist.Clear();
			for (int l = 0; l < this.AGM.mListActGift.Count; l++)
			{
				this.tmplist.Add(137f);
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			this.ScrollPanelCheck();
			break;
		case 6:
			this.text_GiftNum.text = this.AGM.EnableRedPocketNum.ToString();
			this.text_GiftNum.SetAllDirty();
			this.text_GiftNum.cachedTextGenerator.Invalidate();
			this.text_GiftNum.cachedTextGeneratorForLayout.Invalidate();
			this.Img_GiftNum.rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_GiftNum.preferredWidth), this.Img_GiftNum.rectTransform.sizeDelta.y);
			if (ActivityManager.Instance.ServerEventTime - ActivityGiftManager.Instance.ActivityGiftBeginTime >= 0L && ActivityGiftManager.Instance.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 0L && this.DM.RoleAlliance.Rank == AllianceRank.RANK5 && ActivityGiftManager.Instance.mLeaderRedPocketResetTime - ActivityManager.Instance.ServerEventTime <= 0L)
			{
				this.Img_GiftNum.gameObject.SetActive(true);
				this.Img_MainGiftNum.gameObject.SetActive(true);
				this.text_GiftNum.gameObject.SetActive(false);
			}
			else
			{
				this.Img_MainGiftNum.gameObject.SetActive(false);
				if (this.AGM.EnableRedPocketNum > 0)
				{
					this.text_GiftNum.gameObject.SetActive(true);
					this.Img_GiftNum.gameObject.SetActive(true);
				}
				else
				{
					this.text_GiftNum.gameObject.SetActive(false);
					this.Img_GiftNum.gameObject.SetActive(false);
				}
			}
			break;
		case 7:
			if (this.m_Mask != null)
			{
				this.m_Mask.StopMovement();
			}
			break;
		case 10:
			if (this.door != null && this.DM.RoleAlliance.Id == 0u)
			{
				this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_ActivityGift);
			}
			break;
		}
	}

	// Token: 0x06000EA6 RID: 3750 RVA: 0x00183A2C File Offset: 0x00181C2C
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
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
				this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_ActivityGift);
				return;
			}
			this.tmplist.Clear();
			for (int i = 0; i < this.AGM.mListActGift.Count; i++)
			{
				this.tmplist.Add(137f);
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			this.ScrollPanelCheck();
		}
	}

	// Token: 0x06000EA7 RID: 3751 RVA: 0x00183ADC File Offset: 0x00181CDC
	public void Refresh_FontTexture()
	{
		if (this.text_Info != null && this.text_Info.enabled)
		{
			this.text_Info.enabled = false;
			this.text_Info.enabled = true;
		}
		if (this.text_MainGiftGive != null && this.text_MainGiftGive.enabled)
		{
			this.text_MainGiftGive.enabled = false;
			this.text_MainGiftGive.enabled = true;
		}
		if (this.text_MainGiftReSetTime != null && this.text_MainGiftReSetTime.enabled)
		{
			this.text_MainGiftReSetTime.enabled = false;
			this.text_MainGiftReSetTime.enabled = true;
		}
		if (this.text_NoGiftGet != null && this.text_NoGiftGet.enabled)
		{
			this.text_NoGiftGet.enabled = false;
			this.text_NoGiftGet.enabled = true;
		}
		if (this.text_NoGiftBuy != null && this.text_NoGiftBuy.enabled)
		{
			this.text_NoGiftBuy.enabled = false;
			this.text_NoGiftBuy.enabled = true;
		}
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_GiftNum != null && this.text_GiftNum.enabled)
		{
			this.text_GiftNum.enabled = false;
			this.text_GiftNum.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_MainGiftInfo[i] != null && this.text_MainGiftInfo[i].enabled)
			{
				this.text_MainGiftInfo[i].enabled = false;
				this.text_MainGiftInfo[i].enabled = true;
			}
		}
		for (int j = 0; j < 3; j++)
		{
			if (this.text_Close[j] != null && this.text_Close[j].enabled)
			{
				this.text_Close[j].enabled = false;
				this.text_Close[j].enabled = true;
			}
		}
		for (int k = 0; k < 6; k++)
		{
			if (this.bFindScrollp[k])
			{
				if (this.tmpItem[k].ReceiveBtnText != null && this.tmpItem[k].ReceiveBtnText.enabled)
				{
					this.tmpItem[k].ReceiveBtnText.enabled = false;
					this.tmpItem[k].ReceiveBtnText.enabled = true;
				}
				if (this.tmpItem[k].ReceiveImgText != null && this.tmpItem[k].ReceiveImgText.enabled)
				{
					this.tmpItem[k].ReceiveImgText.enabled = false;
					this.tmpItem[k].ReceiveImgText.enabled = true;
				}
				if (this.tmpItem[k].NumText != null && this.tmpItem[k].NumText.enabled)
				{
					this.tmpItem[k].NumText.enabled = false;
					this.tmpItem[k].NumText.enabled = true;
				}
				if (this.tmpItem[k].CDTimeText != null && this.tmpItem[k].CDTimeText.enabled)
				{
					this.tmpItem[k].CDTimeText.enabled = false;
					this.tmpItem[k].CDTimeText.enabled = true;
				}
				if (this.tmpItem[k].PlayerNameText != null && this.tmpItem[k].PlayerNameText.enabled)
				{
					this.tmpItem[k].PlayerNameText.enabled = false;
					this.tmpItem[k].PlayerNameText.enabled = true;
				}
				if (this.tmpItem[k].GiftNameText != null && this.tmpItem[k].GiftNameText.enabled)
				{
					this.tmpItem[k].GiftNameText.enabled = false;
					this.tmpItem[k].GiftNameText.enabled = true;
				}
			}
			if (this.bFindScrollp_Buy[k])
			{
				if (this.tmpItem_Buy[k].PriceText != null && this.tmpItem_Buy[k].PriceText.enabled)
				{
					this.tmpItem_Buy[k].PriceText.enabled = false;
					this.tmpItem_Buy[k].PriceText.enabled = true;
				}
				if (this.tmpItem_Buy[k].BuyText != null && this.tmpItem_Buy[k].BuyText.enabled)
				{
					this.tmpItem_Buy[k].BuyText.enabled = false;
					this.tmpItem_Buy[k].BuyText.enabled = true;
				}
				if (this.tmpItem_Buy[k].Price_ThirdPartyText != null && this.tmpItem_Buy[k].Price_ThirdPartyText.enabled)
				{
					this.tmpItem_Buy[k].Price_ThirdPartyText.enabled = false;
					this.tmpItem_Buy[k].Price_ThirdPartyText.enabled = true;
				}
				if (this.tmpItem_Buy[k].GiftNameText != null && this.tmpItem_Buy[k].GiftNameText.enabled)
				{
					this.tmpItem_Buy[k].GiftNameText.enabled = false;
					this.tmpItem_Buy[k].GiftNameText.enabled = true;
				}
				if (this.tmpItem_Buy[k].GiftInfoText != null && this.tmpItem_Buy[k].GiftInfoText.enabled)
				{
					this.tmpItem_Buy[k].GiftInfoText.enabled = false;
					this.tmpItem_Buy[k].GiftInfoText.enabled = true;
				}
			}
		}
	}

	// Token: 0x06000EA8 RID: 3752 RVA: 0x001841A4 File Offset: 0x001823A4
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.tmpSendTime >= 0f)
		{
			this.tmpSendTime += Time.smoothDeltaTime;
			if (this.tmpSendTime >= 0.3f)
			{
				this.tmpSendTime = -1f;
			}
		}
		if (this.Img_MainGifeLight != null)
		{
			this.Img_MainGifeLight.transform.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
		if (bOnSecond)
		{
			if (this.NeedUpDate && IGGGameSDK.Instance.bPaymentReady)
			{
				this.NeedUpDate = false;
				this.UpdateItemPrice();
			}
			if (this.IsActTime && this.AGM.ActivityGiftEndTime <= ActivityManager.Instance.ServerEventTime)
			{
				this.IsActTime = false;
				this.text_Close[0].gameObject.SetActive(false);
				this.text_Close[1].gameObject.SetActive(false);
				this.text_Close[2].gameObject.SetActive(true);
				this.Img_ActTime.sprite = this.SArray.m_Sprites[6];
			}
			if (this.text_Close[1] != null && this.text_Close[1].gameObject.activeSelf)
			{
				this.Cstr_ActivityCDTime.ClearString();
				if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime > 86400L)
				{
					this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) / 86400L, 1, false);
					this.Cstr_ActivityCDTime.AppendFormat("{0}d");
				}
				else if (this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime >= 0L)
				{
					this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) / 3600L, 2, false);
					this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) % 3600L / 60L, 2, false);
					this.Cstr_ActivityCDTime.IntToFormat((this.AGM.ActivityGiftEndTime - ActivityManager.Instance.ServerEventTime) % 60L, 2, false);
					this.Cstr_ActivityCDTime.AppendFormat("{0}:{1}:{2}");
				}
				else
				{
					this.Cstr_ActivityCDTime.AppendFormat("00:00:00");
				}
				this.text_Close[1].text = this.Cstr_ActivityCDTime.ToString();
				this.text_Close[1].SetAllDirty();
				this.text_Close[1].cachedTextGenerator.Invalidate();
			}
			for (int i = 0; i < 6; i++)
			{
				if (this.bFindScrollp[i] && (int)this.tmpItem[i].DataIndex < this.AGM.mListActGift.Count)
				{
					this.Cstr_GiftCDTime[i].ClearString();
					if (this.AGM.mListActGift[(int)this.tmpItem[i].DataIndex].RcvTime - ActivityManager.Instance.ServerEventTime >= 0L)
					{
						this.Cstr_GiftCDTime[i].IntToFormat((this.AGM.mListActGift[(int)this.tmpItem[i].DataIndex].RcvTime - ActivityManager.Instance.ServerEventTime) / 3600L, 2, false);
						this.Cstr_GiftCDTime[i].IntToFormat((this.AGM.mListActGift[(int)this.tmpItem[i].DataIndex].RcvTime - ActivityManager.Instance.ServerEventTime) % 3600L / 60L, 2, false);
						this.Cstr_GiftCDTime[i].IntToFormat((this.AGM.mListActGift[(int)this.tmpItem[i].DataIndex].RcvTime - ActivityManager.Instance.ServerEventTime) % 60L, 2, false);
						this.Cstr_GiftCDTime[i].AppendFormat("{0}:{1}:{2}");
					}
					else
					{
						this.Cstr_GiftCDTime[i].IntToFormat(0L, 2, false);
						this.Cstr_GiftCDTime[i].IntToFormat(0L, 2, false);
						this.Cstr_GiftCDTime[i].IntToFormat(0L, 2, false);
						this.Cstr_GiftCDTime[i].AppendFormat("{0}:{1}:{2}");
						if (!this.AGM.mListActGift[(int)this.tmpItem[i].DataIndex].CDtime)
						{
							this.AGM.SendDataReset(this.AGM.mListActGift[(int)this.tmpItem[i].DataIndex].serverIndex);
							this.AGM.mListActGift[(int)this.tmpItem[i].DataIndex].CDtime = true;
						}
					}
					this.tmpItem[i].CDTimeText.text = this.Cstr_GiftCDTime[i].ToString();
					this.tmpItem[i].CDTimeText.SetAllDirty();
					this.tmpItem[i].CDTimeText.cachedTextGenerator.Invalidate();
				}
			}
		}
	}

	// Token: 0x06000EA9 RID: 3753 RVA: 0x001846FC File Offset: 0x001828FC
	private void Start()
	{
	}

	// Token: 0x06000EAA RID: 3754 RVA: 0x00184700 File Offset: 0x00182900
	private void Update()
	{
	}

	// Token: 0x04002EF4 RID: 12020
	private const int ScrollItemCount = 6;

	// Token: 0x04002EF5 RID: 12021
	private DataManager DM;

	// Token: 0x04002EF6 RID: 12022
	private GUIManager GUIM;

	// Token: 0x04002EF7 RID: 12023
	private ActivityGiftManager AGM;

	// Token: 0x04002EF8 RID: 12024
	private Transform GameT;

	// Token: 0x04002EF9 RID: 12025
	private Transform Tmp;

	// Token: 0x04002EFA RID: 12026
	private Transform[] PageT = new Transform[2];

	// Token: 0x04002EFB RID: 12027
	private bool[] bFindScrollp = new bool[6];

	// Token: 0x04002EFC RID: 12028
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04002EFD RID: 12029
	private UnitItem[] tmpItem = new UnitItem[6];

	// Token: 0x04002EFE RID: 12030
	private bool[] bFindScrollp_Buy = new bool[6];

	// Token: 0x04002EFF RID: 12031
	private ScrollPanel m_ScrollPanel_Buy;

	// Token: 0x04002F00 RID: 12032
	private UnitItem_Buy[] tmpItem_Buy = new UnitItem_Buy[6];

	// Token: 0x04002F01 RID: 12033
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x04002F02 RID: 12034
	private Door door;

	// Token: 0x04002F03 RID: 12035
	private Material m_Mat;

	// Token: 0x04002F04 RID: 12036
	private UISpritesArray SArray;

	// Token: 0x04002F05 RID: 12037
	private UIButton btn_EXIT;

	// Token: 0x04002F06 RID: 12038
	private UIButton btn_MainGift;

	// Token: 0x04002F07 RID: 12039
	private UIButton btn_I;

	// Token: 0x04002F08 RID: 12040
	private UIButton[] btnPage = new UIButton[2];

	// Token: 0x04002F09 RID: 12041
	private UIButton[] btnBuyItem = new UIButton[6];

	// Token: 0x04002F0A RID: 12042
	private Image tmpImg;

	// Token: 0x04002F0B RID: 12043
	private Image Img_ActTime;

	// Token: 0x04002F0C RID: 12044
	private Image Img_MainGifeBG;

	// Token: 0x04002F0D RID: 12045
	private Image Img_MainGife;

	// Token: 0x04002F0E RID: 12046
	private Image Img_MainGifeLight;

	// Token: 0x04002F0F RID: 12047
	private Image Img_MainGifeIcon;

	// Token: 0x04002F10 RID: 12048
	private Image Img_NoGiftGet;

	// Token: 0x04002F11 RID: 12049
	private Image Img_NoGiftBuy;

	// Token: 0x04002F12 RID: 12050
	private Image Img_BG;

	// Token: 0x04002F13 RID: 12051
	private Image Img_GiftNum;

	// Token: 0x04002F14 RID: 12052
	private Image Img_MainGiftNum;

	// Token: 0x04002F15 RID: 12053
	private Image[] Img_PageBG = new Image[2];

	// Token: 0x04002F16 RID: 12054
	private Image[] Img_PageIcon = new Image[2];

	// Token: 0x04002F17 RID: 12055
	private UIText text_Info;

	// Token: 0x04002F18 RID: 12056
	private UIText text_MainGiftGive;

	// Token: 0x04002F19 RID: 12057
	private UIText text_MainGiftGive_Meber;

	// Token: 0x04002F1A RID: 12058
	private UIText text_MainGiftReSetTime;

	// Token: 0x04002F1B RID: 12059
	private UIText text_NoGiftGet;

	// Token: 0x04002F1C RID: 12060
	private UIText text_NoGiftBuy;

	// Token: 0x04002F1D RID: 12061
	private UIText text_Title;

	// Token: 0x04002F1E RID: 12062
	private UIText text_GiftNum;

	// Token: 0x04002F1F RID: 12063
	private UIText[] text_MainGiftInfo = new UIText[2];

	// Token: 0x04002F20 RID: 12064
	private UIText[] text_Close = new UIText[3];

	// Token: 0x04002F21 RID: 12065
	private CString Cstr_CDTime;

	// Token: 0x04002F22 RID: 12066
	private CString Cstr_ActivityCDTime;

	// Token: 0x04002F23 RID: 12067
	private CString Cstr_HintNum;

	// Token: 0x04002F24 RID: 12068
	private CString Cstr_HintTime;

	// Token: 0x04002F25 RID: 12069
	private CString Cstr_HintRank;

	// Token: 0x04002F26 RID: 12070
	private CString[] Cstr_GiftNum = new CString[6];

	// Token: 0x04002F27 RID: 12071
	private CString[] Cstr_GiftCDTime = new CString[6];

	// Token: 0x04002F28 RID: 12072
	private CString[] Cstr_Price = new CString[6];

	// Token: 0x04002F29 RID: 12073
	private List<float> tmplist = new List<float>();

	// Token: 0x04002F2A RID: 12074
	private List<float> tmplist_Buy = new List<float>();

	// Token: 0x04002F2B RID: 12075
	private List<ushort> GroupID_Data = new List<ushort>();

	// Token: 0x04002F2C RID: 12076
	private List<ushort> GroupID_Buy_Data = new List<ushort>();

	// Token: 0x04002F2D RID: 12077
	private bool bThirdParty;

	// Token: 0x04002F2E RID: 12078
	private byte mPage;

	// Token: 0x04002F2F RID: 12079
	private byte mPackID = 1;

	// Token: 0x04002F30 RID: 12080
	private bool NeedUpDate;

	// Token: 0x04002F31 RID: 12081
	private Color text_Red = new Color(0.6431f, 0f, 0f);

	// Token: 0x04002F32 RID: 12082
	private Color text_Green = new Color(0f, 0.3686f, 0.0823f);

	// Token: 0x04002F33 RID: 12083
	private Color text_Gray = new Color(0.584f, 0.584f, 0.584f);

	// Token: 0x04002F34 RID: 12084
	private Color text_Meber = new Color(1f, 0.9687f, 0.6f);

	// Token: 0x04002F35 RID: 12085
	private UIButtonHint tmpbtnHint;

	// Token: 0x04002F36 RID: 12086
	private bool IsActTime = true;

	// Token: 0x04002F37 RID: 12087
	private CScrollRect m_Mask;

	// Token: 0x04002F38 RID: 12088
	private uButtonScale uToolMainGift;

	// Token: 0x04002F39 RID: 12089
	private float tmpSendTime = -1f;
}
