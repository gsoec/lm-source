using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005D0 RID: 1488
public class UILetter_Collection : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIHIBtnClickHandler, IUILEBtnClickHandler
{
	// Token: 0x06001D80 RID: 7552 RVA: 0x0036755C File Offset: 0x0036575C
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.mMaT = this.door.LoadMaterial();
		this.Favor.Serial = this.DM.OpenMail.Serial;
		this.Favor.Type = this.DM.OpenMail.Type;
		this.Favor.Kind = this.DM.OpenMail.Kind;
		if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
		{
			this.Report = this.Favor.Combat;
			if (this.Report.UnSeen > 0)
			{
				this.DM.BattleReportRead(this.Report.SerialID, false);
			}
			this.mCollectionMax = (int)this.Report.More;
			for (int i = 0; i < this.mCollectionMax; i++)
			{
				this.tmpCR = this.DM.GatherReportGet(this.mCollectionMax - (1 + i));
				if (!this.tmpCR.BeRead)
				{
					this.UnRead++;
				}
			}
			CString cstring = StringManager.Instance.StaticString1024();
			this.Cstr_Page = StringManager.Instance.SpawnString(30);
			this.Cstr_LastTitle = StringManager.Instance.SpawnString(30);
			for (int j = 0; j < 6; j++)
			{
				this.Hbtn_Item[j] = new UIHIBtn[10];
				this.Lbtn_Item[j] = new UILEBtn[5];
				this.text_Item_Num[j] = new UIText[15];
				this.Cstr_Item_Num[j] = new CString[10];
				for (int k = 0; k < 10; k++)
				{
					this.Cstr_Item_Num[j][k] = StringManager.Instance.SpawnString(30);
				}
				this.Cstr_ItemXY[j] = StringManager.Instance.SpawnString(30);
				this.Cstr_Item_Title[j] = StringManager.Instance.SpawnString(30);
				this.Cstr_Item_Time[j] = StringManager.Instance.SpawnString(30);
				this.Cstr_Item_ResourcesNum[j] = StringManager.Instance.SpawnString(30);
			}
			this.Tmp = this.GameT.GetChild(0).GetChild(1).GetChild(0);
			this.text_TitleName = this.Tmp.GetComponent<UIText>();
			this.text_TitleName.font = this.TTFont;
			this.text_TitleName.text = this.DM.mStringTable.GetStringByID(6047u);
			this.Cstr_Page.ClearString();
			this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_MAX);
			MailType kind = this.DM.OpenMail.Kind;
			if (kind == MailType.EMAIL_BATTLE)
			{
				this.Cstr_Page.IntToFormat((long)(this.Report.Index + 1), 1, false);
				this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
			}
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Page.AppendFormat("{1}/{0}");
			}
			else
			{
				this.Cstr_Page.AppendFormat("{0}/{1}");
			}
			this.Tmp = this.GameT.GetChild(0).GetChild(1).GetChild(1);
			this.text_Page = this.Tmp.GetComponent<UIText>();
			this.text_Page.font = this.TTFont;
			this.text_Page.text = this.Cstr_Page.ToString();
			this.Tmp = this.GameT.GetChild(3).GetChild(0);
			this.btn_Delete = this.Tmp.GetComponent<UIButton>();
			this.btn_Delete.m_Handler = this;
			this.btn_Delete.m_BtnID1 = 1;
			this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
			this.btn_Delete.transition = Selectable.Transition.None;
			this.Tmp = this.GameT.GetChild(3).GetChild(1);
			this.text_LastTitle = this.Tmp.GetComponent<UIText>();
			this.text_LastTitle.font = this.TTFont;
			this.Tmp = this.GameT.GetChild(3).GetChild(2);
			this.text_Time[0] = this.Tmp.GetComponent<UIText>();
			this.text_Time[0].font = this.TTFont;
			this.Tmp = this.GameT.GetChild(3).GetChild(3);
			this.text_Time[1] = this.Tmp.GetComponent<UIText>();
			this.text_Time[1].font = this.TTFont;
			this.SetPageData(true);
			this.m_ScrollPanel = this.GameT.GetChild(1).GetComponent<ScrollPanel>();
			this.Tmp = this.GameT.GetChild(2).GetChild(1);
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
			UIButton component = this.Tmp1.GetComponent<UIButton>();
			component.m_Handler = this;
			component.m_BtnID1 = 4;
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(0).GetChild(1);
			this.tmptext = this.Tmp1.GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(1).GetChild(0);
			this.tmptext = this.Tmp1.GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			this.tmptext.text = this.DM.mStringTable.GetStringByID(6048u);
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(2);
			this.tmptext = this.Tmp1.GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(3);
			this.tmptext = this.Tmp1.GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			this.Tmp1 = this.Tmp.GetChild(1);
			this.tmptext = this.Tmp1.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			for (int l = 0; l < 5; l++)
			{
				this.tmpHbtn = this.Tmp1.GetChild(1).GetChild(l).GetComponent<UIHIBtn>();
				this.GUIM.InitianHeroItemImg(this.tmpHbtn.transform, eHeroOrItem.Item, 0, 0, 0, 0, true, true, true, false);
				this.tmpLbtn = this.Tmp1.GetChild(1).GetChild(l + 5).GetComponent<UILEBtn>();
				this.GUIM.InitLordEquipImg(this.tmpLbtn.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
				this.tmpLbtn.gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
				this.tmptext = this.Tmp1.GetChild(1).GetChild(l + 10).GetComponent<UIText>();
				this.tmptext.font = this.TTFont;
				this.tmpHbtn = this.Tmp1.GetChild(2).GetChild(l).GetComponent<UIHIBtn>();
				this.GUIM.InitianHeroItemImg(this.tmpHbtn.transform, eHeroOrItem.Hero, 0, 0, 0, 0, true, true, true, false);
				this.tmptext = this.Tmp1.GetChild(2).GetChild(l + 5).GetComponent<UIText>();
				this.tmptext.font = this.TTFont;
				this.tmptext = this.Tmp1.GetChild(2).GetChild(l + 10).GetComponent<UIText>();
				this.tmptext.font = this.TTFont;
				this.tmptext.text = this.DM.mStringTable.GetStringByID(7695u);
			}
			this.tmplist.Add(101f);
			for (int m = 0; m < this.mCollectionMax; m++)
			{
				this.tmpCR = this.DM.GatherReportGet(this.mCollectionMax - (1 + m));
				this.tmpHH = 35f;
				this.tmpHH += 87f;
				if (this.tmpCR.Gather.HeroNum > 0)
				{
					this.tmpHH += 71f;
				}
				this.tmplist.Add(this.tmpHH);
			}
			this.m_ScrollPanel.IntiScrollPanel(437f, 0f, 0f, this.tmplist, 6, this);
			float x = this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x;
			this.tempL = (this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x - 853f) / 2f;
			this.PreviousT = this.GameT.GetChild(4);
			this.btn_Previous = this.PreviousT.GetComponent<UIButton>();
			this.btn_Previous.m_Handler = this;
			this.btn_Previous.m_BtnID1 = 2;
			this.btn_Previous.m_EffectType = e_EffectType.e_Scale;
			this.btn_Previous.transition = Selectable.Transition.None;
			this.NextT = this.GameT.GetChild(5);
			this.btn_Next = this.NextT.GetComponent<UIButton>();
			this.btn_Next.m_Handler = this;
			this.btn_Next.m_BtnID1 = 3;
			this.btn_Next.m_EffectType = e_EffectType.e_Scale;
			this.btn_Next.transition = Selectable.Transition.None;
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
			if (this.MaxLetterNum > 1)
			{
				if (this.Report.Index + 1 == 1)
				{
					this.btn_Previous.gameObject.SetActive(false);
					if (!this.btn_Next.IsActive())
					{
						this.btn_Next.gameObject.SetActive(true);
					}
				}
				if ((int)(this.Report.Index + 1) == this.MaxLetterNum)
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
			this.Tmp = this.GameT.GetChild(6);
			this.tmpImg = this.Tmp.GetComponent<Image>();
			cstring.ClearString();
			cstring.AppendFormat("UI_main_close_base");
			this.tmpImg.sprite = this.door.LoadSprite(cstring);
			this.tmpImg.material = this.mMaT;
			if (this.GUIM.bOpenOnIPhoneX)
			{
				this.tmpImg.enabled = false;
			}
			this.Tmp = this.GameT.GetChild(6).GetChild(0);
			this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
			cstring.ClearString();
			cstring.AppendFormat("UI_main_close");
			this.btn_EXIT.image.sprite = this.door.LoadSprite(cstring);
			this.btn_EXIT.image.material = this.mMaT;
			this.btn_EXIT.m_Handler = this;
			this.btn_EXIT.m_BtnID1 = 0;
			this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
			this.btn_EXIT.transition = Selectable.Transition.None;
			this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
			return;
		}
		this.door.CloseMenu(false);
	}

	// Token: 0x06001D81 RID: 7553 RVA: 0x003682D4 File Offset: 0x003664D4
	public override void OnClose()
	{
		if (this.Cstr_Page != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Page);
		}
		if (this.Cstr_LastTitle != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_LastTitle);
		}
		for (int i = 0; i < 6; i++)
		{
			if (this.Cstr_ItemXY[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemXY[i]);
			}
			if (this.Cstr_Item_Title[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Item_Title[i]);
			}
			if (this.Cstr_Item_Time[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Item_Time[i]);
			}
			if (this.Cstr_Item_ResourcesNum[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Item_ResourcesNum[i]);
			}
			for (int j = 0; j < 10; j++)
			{
				if (this.Cstr_Item_Num[i] != null && this.Cstr_Item_Num[i][j] != null)
				{
					StringManager.Instance.DeSpawnString(this.Cstr_Item_Num[i][j]);
				}
			}
		}
	}

	// Token: 0x06001D82 RID: 7554 RVA: 0x003683F0 File Offset: 0x003665F0
	public void GetTitleString(int mLv, byte mType, CString CStr)
	{
		CStr.IntToFormat((long)mLv, 1, false);
		CStr.AppendFormat(this.DM.mStringTable.GetStringByID(5377u));
		switch (mType)
		{
		case 0:
			CStr.StringToFormat(this.DM.mStringTable.GetStringByID(6031u));
			break;
		case 1:
			CStr.StringToFormat(this.DM.mStringTable.GetStringByID(6029u));
			break;
		case 2:
			CStr.StringToFormat(this.DM.mStringTable.GetStringByID(6028u));
			break;
		case 3:
			CStr.StringToFormat(this.DM.mStringTable.GetStringByID(6030u));
			break;
		case 4:
			CStr.StringToFormat(this.DM.mStringTable.GetStringByID(6033u));
			break;
		case 5:
			CStr.StringToFormat(this.DM.mStringTable.GetStringByID(6032u));
			break;
		}
		CStr.AppendFormat("{0}");
	}

	// Token: 0x06001D83 RID: 7555 RVA: 0x0036851C File Offset: 0x0036671C
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			this.door.CloseMenu(false);
			break;
		case 1:
			if (this.DM.BattleReportDelete(this.Report.SerialID))
			{
				this.door.CloseMenu(false);
			}
			break;
		case 2:
			this.Open_NP_Mail(false);
			break;
		case 3:
			this.Open_NP_Mail(true);
			break;
		case 4:
			this.tmpCR = this.DM.GatherReportGet(sender.m_BtnID2);
			this.door.GoToPointCode(this.tmpCR.Gather.KingdomID, this.tmpCR.Gather.GatherZone, this.tmpCR.Gather.GatherPoint, 0);
			break;
		}
	}

	// Token: 0x06001D84 RID: 7556 RVA: 0x003685FC File Offset: 0x003667FC
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.ItemT[panelObjectIdx] == null)
		{
			this.ItemT[panelObjectIdx] = item.GetComponent<Transform>();
			this.mScrollItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			this.Itme_PT1[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(0);
			this.Itme_PT2[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(1);
			this.btn_ItemXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetComponent<UIButton>();
			this.btn_ItemXY[panelObjectIdx].m_Handler = this;
			this.BtnXY_ItemRT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetComponent<RectTransform>();
			this.ImgXY_ItemRT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetChild(0).GetComponent<RectTransform>();
			this.TextXY_ItemRT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetChild(1).GetComponent<RectTransform>();
			this.text_ItemXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetChild(1).GetComponent<UIText>();
			this.Img_ItemNew[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetComponent<Image>();
			this.text_ItemNew[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
			this.text_Item_Title[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(2).GetComponent<UIText>();
			this.Title_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(2).GetComponent<RectTransform>();
			this.text_Item_Time[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(3).GetComponent<UIText>();
			this.ImgBG_ItemRT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetComponent<RectTransform>();
			this.Img_ItemIcon[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0).GetComponent<Image>();
			this.Img_ItemIconRT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0).GetComponent<RectTransform>();
			this.text_Item_ResourcesNum[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
			this.ImgItems_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetComponent<RectTransform>();
			for (int i = 0; i < 5; i++)
			{
				this.Hbtn_Item[panelObjectIdx][i] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(i).GetComponent<UIHIBtn>();
				this.Lbtn_Item[panelObjectIdx][i] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(i + 5).GetComponent<UILEBtn>();
				this.text_Item_Num[panelObjectIdx][i] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(i + 10).GetComponent<UIText>();
			}
			this.ImgItems_1_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(0).GetComponent<RectTransform>();
			this.ImgItems_2_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(1).GetComponent<RectTransform>();
			this.ImgItems_L1_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(5).GetComponent<RectTransform>();
			this.ImgItems_L2_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(6).GetComponent<RectTransform>();
			this.textItems_1_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(10).GetComponent<RectTransform>();
			this.textItems_2_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(11).GetComponent<RectTransform>();
			this.ImgHeros_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(2).GetComponent<RectTransform>();
			for (int j = 0; j < 5; j++)
			{
				this.Hbtn_Item[panelObjectIdx][j + 5] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(2).GetChild(j).GetComponent<UIHIBtn>();
				this.text_Item_Num[panelObjectIdx][j + 5] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(2).GetChild(j + 5).GetComponent<UIText>();
				this.text_Item_Num[panelObjectIdx][j + 10] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(2).GetChild(j + 10).GetComponent<UIText>();
			}
			this.Hero_1_RT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(2).GetChild(0).GetComponent<RectTransform>();
		}
		if (dataIdx == 0)
		{
			this.Itme_PT1[panelObjectIdx].gameObject.SetActive(true);
			this.Itme_PT2[panelObjectIdx].gameObject.SetActive(false);
		}
		else
		{
			this.Itme_PT1[panelObjectIdx].gameObject.SetActive(false);
			this.Itme_PT2[panelObjectIdx].gameObject.SetActive(true);
			this.SetItemData(dataIdx, panelObjectIdx);
		}
	}

	// Token: 0x06001D85 RID: 7557 RVA: 0x00368B38 File Offset: 0x00366D38
	public void SetItemData(int Idx, int ItemIdx)
	{
		this.tmpCR = this.DM.GatherReportGet(this.mCollectionMax - Idx);
		if (this.UnRead > Idx - 1)
		{
			this.Img_ItemNew[ItemIdx].gameObject.SetActive(true);
			this.Title_RT[ItemIdx].anchoredPosition = this.text_Item_Title[ItemIdx].ArabicFixPos(new Vector2(104f, this.Title_RT[ItemIdx].anchoredPosition.y));
		}
		else
		{
			this.Img_ItemNew[ItemIdx].gameObject.SetActive(false);
			this.Title_RT[ItemIdx].anchoredPosition = this.text_Item_Title[ItemIdx].ArabicFixPos(new Vector2(22f, this.Title_RT[ItemIdx].anchoredPosition.y));
		}
		this.Cstr_ItemXY[ItemIdx].ClearString();
		this.tmpV2 = Vector2.zero;
		this.tmpV2 = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.tmpCR.Gather.GatherZone, this.tmpCR.Gather.GatherPoint));
		this.Cstr_ItemXY[ItemIdx].StringToFormat(this.DM.mStringTable.GetStringByID(4505u));
		this.Cstr_ItemXY[ItemIdx].IntToFormat((long)((int)this.tmpV2.x), 1, false);
		this.Cstr_ItemXY[ItemIdx].StringToFormat(this.DM.mStringTable.GetStringByID(4506u));
		this.Cstr_ItemXY[ItemIdx].IntToFormat((long)((int)this.tmpV2.y), 1, false);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_ItemXY[ItemIdx].AppendFormat("{3}{2} {1}{0}");
		}
		else
		{
			this.Cstr_ItemXY[ItemIdx].AppendFormat("{0}{1} {2}{3}");
		}
		this.text_ItemXY[ItemIdx].text = this.Cstr_ItemXY[ItemIdx].ToString();
		this.text_ItemXY[ItemIdx].SetAllDirty();
		this.text_ItemXY[ItemIdx].cachedTextGenerator.Invalidate();
		this.text_ItemXY[ItemIdx].cachedTextGeneratorForLayout.Invalidate();
		this.BtnXY_ItemRT[ItemIdx].sizeDelta = new Vector2(this.text_ItemXY[ItemIdx].preferredWidth, this.BtnXY_ItemRT[ItemIdx].sizeDelta.y);
		this.ImgXY_ItemRT[ItemIdx].sizeDelta = new Vector2(this.text_ItemXY[ItemIdx].preferredWidth, this.ImgXY_ItemRT[ItemIdx].sizeDelta.y);
		this.TextXY_ItemRT[ItemIdx].sizeDelta = new Vector2(this.text_ItemXY[ItemIdx].preferredWidth, this.TextXY_ItemRT[ItemIdx].sizeDelta.y);
		this.btn_ItemXY[ItemIdx].m_BtnID2 = this.mCollectionMax - Idx;
		this.Cstr_Item_Title[ItemIdx].ClearString();
		this.Cstr_Item_Title[ItemIdx].IntToFormat((long)this.tmpCR.Gather.GatherPointLevel, 1, false);
		this.Cstr_Item_Title[ItemIdx].StringToFormat(this.GUIM.GetPointName_Letter(this.tmpCR.Gather.GatherPointKind));
		this.Cstr_Item_Title[ItemIdx].AppendFormat(this.DM.mStringTable.GetStringByID(6002u));
		this.text_Item_Title[ItemIdx].text = this.Cstr_Item_Title[ItemIdx].ToString();
		this.text_Item_Title[ItemIdx].SetAllDirty();
		this.text_Item_Title[ItemIdx].cachedTextGenerator.Invalidate();
		this.text_Item_Time[ItemIdx].text = GameConstants.GetDateTime(this.tmpCR.Times).ToString("MM/dd/yy HH:mm:ss");
		this.text_Item_Time[ItemIdx].SetAllDirty();
		this.text_Item_Time[ItemIdx].cachedTextGenerator.Invalidate();
		this.mResourcesKind[Idx - 1] = this.GatherPointKind(this.tmpCR.Gather.GatherPointKind);
		this.Img_ItemIcon[ItemIdx].sprite = this.SArray.m_Sprites[(int)this.mResourcesKind[Idx - 1]];
		this.Img_ItemIcon[ItemIdx].SetNativeSize();
		this.Cstr_Item_ResourcesNum[ItemIdx].ClearString();
		GameConstants.FormatResourceValue(this.Cstr_Item_ResourcesNum[ItemIdx], this.tmpCR.Gather.Resource);
		this.text_Item_ResourcesNum[ItemIdx].text = this.Cstr_Item_ResourcesNum[ItemIdx].ToString();
		this.text_Item_ResourcesNum[ItemIdx].SetAllDirty();
		this.text_Item_ResourcesNum[ItemIdx].cachedTextGenerator.Invalidate();
		float num = 0f;
		this.mItems[Idx - 1] = this.tmpCR.Gather.ItemLen;
		num -= 87f;
		if (this.tmpCR.Gather.ItemLen > 0)
		{
			this.ImgItems_RT[ItemIdx].gameObject.SetActive(true);
			if (this.tmpCR.Gather.ItemLen < 3)
			{
				this.Img_ItemIconRT[ItemIdx].anchoredPosition = new Vector2(300f, this.Img_ItemIconRT[ItemIdx].anchoredPosition.y);
				this.ImgItems_1_RT[ItemIdx].anchoredPosition = new Vector2(389f, this.ImgItems_1_RT[ItemIdx].anchoredPosition.y);
				this.ImgItems_2_RT[ItemIdx].anchoredPosition = new Vector2(518f, this.ImgItems_2_RT[ItemIdx].anchoredPosition.y);
				this.ImgItems_L1_RT[ItemIdx].anchoredPosition = new Vector2(389f, this.ImgItems_L1_RT[ItemIdx].anchoredPosition.y);
				this.ImgItems_L2_RT[ItemIdx].anchoredPosition = new Vector2(518f, this.ImgItems_L2_RT[ItemIdx].anchoredPosition.y);
				this.textItems_1_RT[ItemIdx].anchoredPosition = new Vector2(454f, this.textItems_1_RT[ItemIdx].anchoredPosition.y);
				this.textItems_2_RT[ItemIdx].anchoredPosition = new Vector2(583f, this.textItems_2_RT[ItemIdx].anchoredPosition.y);
			}
			else
			{
				this.ImgItems_1_RT[ItemIdx].anchoredPosition = new Vector2(131f, this.ImgItems_1_RT[ItemIdx].anchoredPosition.y);
				this.ImgItems_2_RT[ItemIdx].anchoredPosition = new Vector2(260f, this.ImgItems_2_RT[ItemIdx].anchoredPosition.y);
				this.ImgItems_L1_RT[ItemIdx].anchoredPosition = new Vector2(131f, this.ImgItems_L1_RT[ItemIdx].anchoredPosition.y);
				this.ImgItems_L2_RT[ItemIdx].anchoredPosition = new Vector2(260f, this.ImgItems_L2_RT[ItemIdx].anchoredPosition.y);
				this.textItems_1_RT[ItemIdx].anchoredPosition = new Vector2(196f, this.textItems_1_RT[ItemIdx].anchoredPosition.y);
				this.textItems_2_RT[ItemIdx].anchoredPosition = new Vector2(325f, this.textItems_2_RT[ItemIdx].anchoredPosition.y);
			}
			this.ImgHeros_RT[ItemIdx].anchoredPosition = new Vector2(this.ImgHeros_RT[ItemIdx].anchoredPosition.x, -71f);
			for (int i = 0; i < (int)this.tmpCR.Gather.ItemLen; i++)
			{
				this.text_Item_Num[ItemIdx][i].gameObject.SetActive(true);
				this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.tmpCR.Gather.mResourceItem[i].ItemID);
				bool flag = this.GUIM.IsLeadItem(this.tmpEquip.EquipKind);
				if (flag)
				{
					this.GUIM.ChangeLordEquipImg(this.Lbtn_Item[ItemIdx][i].transform, this.tmpCR.Gather.mResourceItem[i].ItemID, this.tmpCR.Gather.mResourceItem[i].Rank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
					this.Lbtn_Item[ItemIdx][i].gameObject.SetActive(true);
					this.Hbtn_Item[ItemIdx][i].gameObject.SetActive(false);
				}
				else
				{
					this.GUIM.ChangeHeroItemImg(this.Hbtn_Item[ItemIdx][i].transform, eHeroOrItem.Item, this.tmpCR.Gather.mResourceItem[i].ItemID, 0, 0, 0);
					this.Lbtn_Item[ItemIdx][i].gameObject.SetActive(false);
					this.Hbtn_Item[ItemIdx][i].gameObject.SetActive(true);
				}
				this.Cstr_Item_Num[ItemIdx][i].ClearString();
				this.Cstr_Item_Num[ItemIdx][i].IntToFormat((long)this.tmpCR.Gather.mResourceItem[i].Quantity, 1, true);
				if (this.GUIM.IsArabic)
				{
					this.Cstr_Item_Num[ItemIdx][i].AppendFormat("{0}x");
				}
				else
				{
					this.Cstr_Item_Num[ItemIdx][i].AppendFormat("x{0}");
				}
				this.text_Item_Num[ItemIdx][i].text = this.Cstr_Item_Num[ItemIdx][i].ToString();
				this.text_Item_Num[ItemIdx][i].SetAllDirty();
				this.text_Item_Num[ItemIdx][i].cachedTextGenerator.Invalidate();
			}
			for (int j = (int)this.tmpCR.Gather.ItemLen; j < 5; j++)
			{
				this.Hbtn_Item[ItemIdx][j].gameObject.SetActive(false);
				this.Lbtn_Item[ItemIdx][j].gameObject.SetActive(false);
				this.text_Item_Num[ItemIdx][j].gameObject.SetActive(false);
			}
		}
		else
		{
			this.ImgItems_RT[ItemIdx].gameObject.SetActive(false);
			this.Img_ItemIconRT[ItemIdx].anchoredPosition = new Vector2(397f, this.Img_ItemIconRT[ItemIdx].anchoredPosition.y);
		}
		if (this.tmpCR.Gather.HeroNum > 0)
		{
			num -= 71f;
			this.ImgHeros_RT[ItemIdx].anchoredPosition = new Vector2(this.ImgHeros_RT[ItemIdx].anchoredPosition.x, -71f);
			this.ImgHeros_RT[ItemIdx].gameObject.SetActive(true);
			for (int k = 0; k < (int)this.tmpCR.Gather.HeroNum; k++)
			{
				this.Hbtn_Item[ItemIdx][k + 5].gameObject.SetActive(true);
				this.text_Item_Num[ItemIdx][k + 5].gameObject.SetActive(true);
				this.text_Item_Num[ItemIdx][k + 10].gameObject.SetActive(true);
				this.GUIM.ChangeHeroItemImg(this.Hbtn_Item[ItemIdx][k + 5].transform, eHeroOrItem.Hero, this.tmpCR.Gather.mHero[k].HeroID, this.tmpCR.Gather.mHero[k].Star, 0, 0);
				this.Cstr_Item_Num[ItemIdx][k + 5].ClearString();
				this.Cstr_Item_Num[ItemIdx][k + 5].IntToFormat((long)((ulong)this.tmpCR.Gather.mHero[k].Exp), 1, true);
				if (this.GUIM.IsArabic)
				{
					this.Cstr_Item_Num[ItemIdx][k + 5].AppendFormat("{0}+");
				}
				else
				{
					this.Cstr_Item_Num[ItemIdx][k + 5].AppendFormat("+{0}");
				}
				this.text_Item_Num[ItemIdx][k + 5].text = this.Cstr_Item_Num[ItemIdx][k + 5].ToString();
				this.text_Item_Num[ItemIdx][k + 5].SetAllDirty();
				this.text_Item_Num[ItemIdx][k + 5].cachedTextGenerator.Invalidate();
			}
			for (int l = (int)this.tmpCR.Gather.HeroNum; l < 5; l++)
			{
				this.Hbtn_Item[ItemIdx][l + 5].gameObject.SetActive(false);
				this.text_Item_Num[ItemIdx][l + 5].gameObject.SetActive(false);
				this.text_Item_Num[ItemIdx][l + 10].gameObject.SetActive(false);
			}
		}
		else
		{
			this.ImgHeros_RT[ItemIdx].gameObject.SetActive(false);
		}
		this.ImgBG_ItemRT[ItemIdx].sizeDelta = new Vector2(this.ImgBG_ItemRT[ItemIdx].sizeDelta.x, -num);
	}

	// Token: 0x06001D86 RID: 7558 RVA: 0x003697F4 File Offset: 0x003679F4
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001D87 RID: 7559 RVA: 0x003697F8 File Offset: 0x003679F8
	public void Open_NP_Mail(bool bNext)
	{
		if (this.DM.MailReportGet(ref this.Favor, bNext))
		{
			MailType type = this.Favor.Type;
			if (type == MailType.EMAIL_BATTLE)
			{
				this.DM.OpenMail.Serial = this.Favor.Serial;
				this.DM.OpenMail.Type = this.Favor.Type;
				this.DM.OpenMail.Kind = this.Favor.Kind;
				switch (this.Favor.Combat.Type)
				{
				case CombatCollectReport.CCR_BATTLE:
				case CombatCollectReport.CCR_NPCCOMBAT:
					this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Collection);
					break;
				case CombatCollectReport.CCR_RESOURCE:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Resources, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Collection);
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
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Collection);
					break;
				case CombatCollectReport.CCR_RECON:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Collection);
					break;
				case CombatCollectReport.CCR_MONSTER:
					if (this.Favor.Combat.Monster.Result < 2 || this.Favor.Combat.Monster.Result > 3)
					{
						this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 1, 0, false);
					}
					else
					{
						this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
					}
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Collection);
					break;
				case CombatCollectReport.CCR_NPCSCOUT:
					this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Collection);
					break;
				case CombatCollectReport.CCR_PETREPORT:
					this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Collection);
					break;
				}
			}
		}
	}

	// Token: 0x06001D88 RID: 7560 RVA: 0x00369A44 File Offset: 0x00367C44
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x06001D89 RID: 7561 RVA: 0x00369A48 File Offset: 0x00367C48
	public void OnLEButtonClick(UILEBtn sender)
	{
	}

	// Token: 0x06001D8A RID: 7562 RVA: 0x00369A4C File Offset: 0x00367C4C
	public void SetPageData(bool bopen = false)
	{
		this.Cstr_LastTitle.ClearString();
		this.Cstr_LastTitle.IntToFormat((long)this.Report.Gather.GatherPointLevel, 1, false);
		this.Cstr_LastTitle.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Gather.GatherPointKind));
		this.Cstr_LastTitle.AppendFormat(this.DM.mStringTable.GetStringByID(6050u));
		this.text_LastTitle.text = this.Cstr_LastTitle.ToString();
		this.text_LastTitle.SetAllDirty();
		this.text_LastTitle.cachedTextGenerator.Invalidate();
		this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Times).ToString("MM/dd/yy");
		this.text_Time[0].SetAllDirty();
		this.text_Time[0].cachedTextGenerator.Invalidate();
		this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Times).ToString("HH:mm:ss");
		this.text_Time[1].SetAllDirty();
		this.text_Time[1].cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001D8B RID: 7563 RVA: 0x00369B90 File Offset: 0x00367D90
	public byte GatherPointKind(POINT_KIND mPointkind)
	{
		byte result = 0;
		switch (mPointkind)
		{
		case POINT_KIND.PK_FOOD:
			result = 0;
			break;
		case POINT_KIND.PK_STONE:
			result = 2;
			break;
		case POINT_KIND.PK_IRON:
			result = 3;
			break;
		case POINT_KIND.PK_WOOD:
			result = 1;
			break;
		case POINT_KIND.PK_GOLD:
			result = 4;
			break;
		case POINT_KIND.PK_CRYSTAL:
			result = 5;
			break;
		}
		return result;
	}

	// Token: 0x06001D8C RID: 7564 RVA: 0x00369BF4 File Offset: 0x00367DF4
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.mCollectionMax = this.DM.GetMailboxGatherSize();
			this.tmplist.Clear();
			this.tmplist.Add(101f);
			for (int i = 0; i < this.mCollectionMax; i++)
			{
				this.tmpCR = this.DM.GatherReportGet(this.mCollectionMax - (1 + i));
				this.tmpHH = 35f;
				this.tmpHH += 87f;
				if (this.tmpCR.Gather.HeroNum > 0)
				{
					this.tmpHH += 71f;
				}
				this.tmplist.Add(this.tmpHH);
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
		}
	}

	// Token: 0x06001D8D RID: 7565 RVA: 0x00369CDC File Offset: 0x00367EDC
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
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else
			{
				if (meg[1] == 1 && meg[2] == 1)
				{
					this.Favor.Serial = this.DM.GetMailboxReportSerial(ReportSubSet.REPORTSet_GATHER);
					this.Favor.Type = this.DM.OpenMail.Type;
					this.Favor.Kind = this.DM.OpenMail.Kind;
					if (!this.DM.MailReportGet(ref this.Favor) || this.Favor.Type != MailType.EMAIL_BATTLE)
					{
						this.door.CloseMenu(false);
						return;
					}
					this.Report = this.Favor.Combat;
					if (this.Report.UnSeen > 0)
					{
						this.DM.BattleReportRead(this.Report.SerialID, false);
					}
					this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Times).ToString("MM/dd/yy");
					this.text_Time[0].SetAllDirty();
					this.text_Time[0].cachedTextGenerator.Invalidate();
					this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Times).ToString("HH:mm:ss");
					this.text_Time[1].SetAllDirty();
					this.text_Time[1].cachedTextGenerator.Invalidate();
					this.tmplist.Clear();
					this.tmplist.Add(101f);
					this.mCollectionMax = this.DM.GetMailboxGatherSize();
					for (int i = 0; i < this.mCollectionMax; i++)
					{
						this.tmpCR = this.DM.GatherReportGet(this.mCollectionMax - (1 + i));
						if (!this.tmpCR.BeRead)
						{
							this.UnRead++;
						}
						this.tmpHH = 35f;
						this.tmpHH += 87f;
						if (this.tmpCR.Gather.HeroNum > 0)
						{
							this.tmpHH += 71f;
						}
						this.tmplist.Add(this.tmpHH);
					}
					this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
					this.SetPageData(false);
				}
				this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_MAX);
				if (this.MaxLetterNum > 1)
				{
					if (this.Report.Index + 1 == 1)
					{
						this.btn_Previous.gameObject.SetActive(false);
					}
					else
					{
						this.btn_Previous.gameObject.SetActive(true);
					}
					if ((int)(this.Report.Index + 1) == this.MaxLetterNum)
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
				this.Cstr_Page.ClearString();
				MailType kind = this.DM.OpenMail.Kind;
				if (kind == MailType.EMAIL_BATTLE)
				{
					this.Cstr_Page.IntToFormat((long)(this.Report.Index + 1), 1, false);
					this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
				}
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

	// Token: 0x06001D8E RID: 7566 RVA: 0x0036A0FC File Offset: 0x003682FC
	public void Refresh_FontTexture()
	{
		if (this.text_TitleName != null && this.text_TitleName.enabled)
		{
			this.text_TitleName.enabled = false;
			this.text_TitleName.enabled = true;
		}
		if (this.text_Page != null && this.text_Page.enabled)
		{
			this.text_Page.enabled = false;
			this.text_Page.enabled = true;
		}
		if (this.text_LastTitle != null && this.text_LastTitle.enabled)
		{
			this.text_LastTitle.enabled = false;
			this.text_LastTitle.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_Time[i] != null && this.text_Time[i].enabled)
			{
				this.text_Time[i].enabled = false;
				this.text_Time[i].enabled = true;
			}
		}
		for (int j = 0; j < 6; j++)
		{
			if (this.text_ItemNew[j] != null && this.text_ItemNew[j].enabled)
			{
				this.text_ItemNew[j].enabled = false;
				this.text_ItemNew[j].enabled = true;
			}
			if (this.text_ItemXY[j] != null && this.text_ItemXY[j].enabled)
			{
				this.text_ItemXY[j].enabled = false;
				this.text_ItemXY[j].enabled = true;
			}
			if (this.text_Item_Title[j] != null && this.text_Item_Title[j].enabled)
			{
				this.text_Item_Title[j].enabled = false;
				this.text_Item_Title[j].enabled = true;
			}
			if (this.text_Item_Time[j] != null && this.text_Item_Time[j].enabled)
			{
				this.text_Item_Time[j].enabled = false;
				this.text_Item_Time[j].enabled = true;
			}
			if (this.text_Item_ResourcesNum[j] != null && this.text_Item_ResourcesNum[j].enabled)
			{
				this.text_Item_ResourcesNum[j].enabled = false;
				this.text_Item_ResourcesNum[j].enabled = true;
			}
			for (int k = 0; k < 15; k++)
			{
				if (this.text_Item_Num[j][k] != null && this.text_Item_Num[j][k].enabled)
				{
					this.text_Item_Num[j][k].enabled = false;
					this.text_Item_Num[j][k].enabled = true;
				}
			}
			for (int l = 0; l < 10; l++)
			{
				if (this.Hbtn_Item[j][l] != null && this.Hbtn_Item[j][l].enabled)
				{
					this.Hbtn_Item[j][l].Refresh_FontTexture();
				}
			}
		}
	}

	// Token: 0x06001D8F RID: 7567 RVA: 0x0036A408 File Offset: 0x00368608
	private void Start()
	{
	}

	// Token: 0x06001D90 RID: 7568 RVA: 0x0036A40C File Offset: 0x0036860C
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

	// Token: 0x04005ACB RID: 23243
	private DataManager DM;

	// Token: 0x04005ACC RID: 23244
	private GUIManager GUIM;

	// Token: 0x04005ACD RID: 23245
	private Font TTFont;

	// Token: 0x04005ACE RID: 23246
	private Door door;

	// Token: 0x04005ACF RID: 23247
	private Transform GameT;

	// Token: 0x04005AD0 RID: 23248
	private Transform Tmp;

	// Token: 0x04005AD1 RID: 23249
	private Transform Tmp1;

	// Token: 0x04005AD2 RID: 23250
	private Transform PreviousT;

	// Token: 0x04005AD3 RID: 23251
	private Transform NextT;

	// Token: 0x04005AD4 RID: 23252
	private Transform[] ItemT = new Transform[6];

	// Token: 0x04005AD5 RID: 23253
	private Transform[] Itme_PT1 = new Transform[6];

	// Token: 0x04005AD6 RID: 23254
	private Transform[] Itme_PT2 = new Transform[6];

	// Token: 0x04005AD7 RID: 23255
	private RectTransform[] BtnXY_ItemRT = new RectTransform[6];

	// Token: 0x04005AD8 RID: 23256
	private RectTransform[] ImgXY_ItemRT = new RectTransform[6];

	// Token: 0x04005AD9 RID: 23257
	private RectTransform[] TextXY_ItemRT = new RectTransform[6];

	// Token: 0x04005ADA RID: 23258
	private RectTransform[] Title_RT = new RectTransform[6];

	// Token: 0x04005ADB RID: 23259
	private RectTransform[] ImgBG_ItemRT = new RectTransform[6];

	// Token: 0x04005ADC RID: 23260
	private RectTransform[] Img_ItemIconRT = new RectTransform[6];

	// Token: 0x04005ADD RID: 23261
	private RectTransform[] ImgHeros_RT = new RectTransform[6];

	// Token: 0x04005ADE RID: 23262
	private RectTransform[] ImgItems_RT = new RectTransform[6];

	// Token: 0x04005ADF RID: 23263
	private RectTransform[] ImgItems_1_RT = new RectTransform[6];

	// Token: 0x04005AE0 RID: 23264
	private RectTransform[] ImgItems_2_RT = new RectTransform[6];

	// Token: 0x04005AE1 RID: 23265
	private RectTransform[] ImgItems_L1_RT = new RectTransform[6];

	// Token: 0x04005AE2 RID: 23266
	private RectTransform[] ImgItems_L2_RT = new RectTransform[6];

	// Token: 0x04005AE3 RID: 23267
	private RectTransform[] textItems_1_RT = new RectTransform[6];

	// Token: 0x04005AE4 RID: 23268
	private RectTransform[] textItems_2_RT = new RectTransform[6];

	// Token: 0x04005AE5 RID: 23269
	private RectTransform[] Hero_1_RT = new RectTransform[6];

	// Token: 0x04005AE6 RID: 23270
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04005AE7 RID: 23271
	private ScrollPanelItem[] mScrollItem = new ScrollPanelItem[6];

	// Token: 0x04005AE8 RID: 23272
	private UIButton btn_EXIT;

	// Token: 0x04005AE9 RID: 23273
	private UIButton btn_Delete;

	// Token: 0x04005AEA RID: 23274
	private UIButton btn_Previous;

	// Token: 0x04005AEB RID: 23275
	private UIButton btn_Next;

	// Token: 0x04005AEC RID: 23276
	private UIButton[] btn_ItemXY = new UIButton[6];

	// Token: 0x04005AED RID: 23277
	private UIHIBtn tmpHbtn;

	// Token: 0x04005AEE RID: 23278
	private UILEBtn tmpLbtn;

	// Token: 0x04005AEF RID: 23279
	private UIHIBtn[][] Hbtn_Item = new UIHIBtn[6][];

	// Token: 0x04005AF0 RID: 23280
	private UILEBtn[][] Lbtn_Item = new UILEBtn[6][];

	// Token: 0x04005AF1 RID: 23281
	private Image tmpImg;

	// Token: 0x04005AF2 RID: 23282
	private Image[] Img_ItemNew = new Image[6];

	// Token: 0x04005AF3 RID: 23283
	private Image[] Img_ItemIcon = new Image[6];

	// Token: 0x04005AF4 RID: 23284
	private UIText tmptext;

	// Token: 0x04005AF5 RID: 23285
	private UIText text_TitleName;

	// Token: 0x04005AF6 RID: 23286
	private UIText text_Page;

	// Token: 0x04005AF7 RID: 23287
	private UIText text_LastTitle;

	// Token: 0x04005AF8 RID: 23288
	private UIText[] text_Time = new UIText[2];

	// Token: 0x04005AF9 RID: 23289
	private UIText[] text_ItemNew = new UIText[6];

	// Token: 0x04005AFA RID: 23290
	private UIText[] text_ItemXY = new UIText[6];

	// Token: 0x04005AFB RID: 23291
	private UIText[] text_Item_Title = new UIText[6];

	// Token: 0x04005AFC RID: 23292
	private UIText[] text_Item_Time = new UIText[6];

	// Token: 0x04005AFD RID: 23293
	private UIText[] text_Item_ResourcesNum = new UIText[6];

	// Token: 0x04005AFE RID: 23294
	private UIText[][] text_Item_Num = new UIText[6][];

	// Token: 0x04005AFF RID: 23295
	private CString Cstr_Page;

	// Token: 0x04005B00 RID: 23296
	private CString Cstr_LastTitle;

	// Token: 0x04005B01 RID: 23297
	private CString[] Cstr_ItemXY = new CString[6];

	// Token: 0x04005B02 RID: 23298
	private CString[] Cstr_Item_Title = new CString[6];

	// Token: 0x04005B03 RID: 23299
	private CString[] Cstr_Item_Time = new CString[6];

	// Token: 0x04005B04 RID: 23300
	private CString[] Cstr_Item_ResourcesNum = new CString[6];

	// Token: 0x04005B05 RID: 23301
	private CString[][] Cstr_Item_Num = new CString[6][];

	// Token: 0x04005B06 RID: 23302
	private Material mMaT;

	// Token: 0x04005B07 RID: 23303
	private UISpritesArray SArray;

	// Token: 0x04005B08 RID: 23304
	private Vector3 Vec3Instance;

	// Token: 0x04005B09 RID: 23305
	private Vector2 tmpV2;

	// Token: 0x04005B0A RID: 23306
	private float tempL;

	// Token: 0x04005B0B RID: 23307
	private float MoveTime1;

	// Token: 0x04005B0C RID: 23308
	private float MoveTime2;

	// Token: 0x04005B0D RID: 23309
	private float TmpTime;

	// Token: 0x04005B0E RID: 23310
	private byte[] mItems = new byte[20];

	// Token: 0x04005B0F RID: 23311
	private byte[] mResourcesKind = new byte[20];

	// Token: 0x04005B10 RID: 23312
	private float tmpHH;

	// Token: 0x04005B11 RID: 23313
	private int mCollectionMax;

	// Token: 0x04005B12 RID: 23314
	private int MaxLetterNum;

	// Token: 0x04005B13 RID: 23315
	private int UnRead;

	// Token: 0x04005B14 RID: 23316
	private CombatReport Report;

	// Token: 0x04005B15 RID: 23317
	private CombatReport tmpCR;

	// Token: 0x04005B16 RID: 23318
	private MyFavorite Favor = new MyFavorite(MailType.EMAIL_MAX, 0u);

	// Token: 0x04005B17 RID: 23319
	private List<float> tmplist = new List<float>();

	// Token: 0x04005B18 RID: 23320
	private Equip tmpEquip;
}
