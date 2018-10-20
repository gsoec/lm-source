using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005D3 RID: 1491
public class UILetter_Resources : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001D9F RID: 7583 RVA: 0x0036D9AC File Offset: 0x0036BBAC
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		CString cstring = StringManager.Instance.StaticString1024();
		this.Cstr_Page = StringManager.Instance.SpawnString(30);
		for (int i = 0; i < 7; i++)
		{
			this.Cstr_ItemTitle[i] = StringManager.Instance.SpawnString(60);
			this.Cstr_ItemName[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_ItemRes_1[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_ItemRes_2[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_ItemRes_3[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_ItemRes_4[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_ItemRes_5[i] = StringManager.Instance.SpawnString(30);
		}
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
			this.mResourcesMax = (int)this.Report.More;
			for (int j = 0; j < this.mResourcesMax; j++)
			{
				this.tmpCR = this.DM.ResourceReportGet(this.mResourcesMax - (1 + j));
				if (this.tmpCR != null && !this.tmpCR.BeRead)
				{
					this.UnReadNum++;
				}
			}
			this.Tmp = this.GameT.GetChild(0).GetChild(1).GetChild(0);
			this.text_TitleName = this.Tmp.GetComponent<UIText>();
			this.text_TitleName.font = this.TTFont;
			this.text_TitleName.text = this.DM.mStringTable.GetStringByID(6042u);
			this.Tmp = this.GameT.GetChild(0).GetChild(1).GetChild(1);
			this.text_Page = this.Tmp.GetComponent<UIText>();
			this.text_Page.font = this.TTFont;
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
			this.text_Page.text = this.Cstr_Page.ToString();
			this.Tmp = this.GameT.GetChild(1).GetChild(0);
			this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
			Transform child = this.GameT.GetChild(1).GetChild(1);
			this.Tmp1 = child.GetChild(1);
			this.Tmp2 = this.Tmp1.GetChild(0).GetChild(0).GetChild(0);
			this.tmptext = this.Tmp2.GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			this.tmptext.text = this.DM.mStringTable.GetStringByID(6048u);
			this.Tmp2 = this.Tmp1.GetChild(0).GetChild(1);
			this.tmptext = this.Tmp2.GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			this.Tmp2 = this.Tmp1.GetChild(0).GetChild(2);
			this.tmptext = this.Tmp2.GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			this.Tmp2 = this.Tmp1.GetChild(0).GetChild(3);
			this.tmptext = this.Tmp2.GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			this.Tmp2 = this.Tmp1.GetChild(0).GetChild(4);
			UIButton component = this.Tmp2.GetComponent<UIButton>();
			component.m_BtnID1 = 4;
			component.m_Handler = this;
			this.Tmp2 = this.Tmp1.GetChild(0).GetChild(4).GetChild(1);
			this.tmptext = this.Tmp2.GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			for (int k = 0; k < 5; k++)
			{
				this.Tmp2 = this.Tmp1.GetChild(1).GetChild(0).GetChild(k).GetChild(0);
				this.tmptext = this.Tmp2.GetComponent<UIText>();
				this.tmptext.font = this.TTFont;
			}
			this.Tmp2 = this.Tmp1.GetChild(1).GetChild(1);
			this.tmptext = this.Tmp2.GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			this.tmptext.text = this.DM.mStringTable.GetStringByID(6046u);
			for (int l = 0; l < this.mResourcesMax + 1; l++)
			{
				this.tmplist.Add(101f);
			}
			this.m_ScrollPanel.IntiScrollPanel(437f, 0f, 0f, this.tmplist, 7, this);
			this.Tmp = this.GameT.GetChild(2).GetChild(0);
			this.btn_Delete = this.Tmp.GetComponent<UIButton>();
			this.btn_Delete.m_Handler = this;
			this.btn_Delete.m_BtnID1 = 1;
			this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
			this.btn_Delete.transition = Selectable.Transition.None;
			this.Tmp = this.GameT.GetChild(2).GetChild(1);
			this.text_Time[0] = this.Tmp.GetComponent<UIText>();
			this.text_Time[0].font = this.TTFont;
			this.Tmp = this.GameT.GetChild(2).GetChild(2);
			this.text_Time[1] = this.Tmp.GetComponent<UIText>();
			this.text_Time[1].font = this.TTFont;
			this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Times).ToString("MM/dd/yy");
			this.text_Time[0].SetAllDirty();
			this.text_Time[0].cachedTextGenerator.Invalidate();
			this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Times).ToString("HH:mm:ss");
			this.text_Time[1].SetAllDirty();
			this.text_Time[1].cachedTextGenerator.Invalidate();
			float x = this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x;
			this.tempL = (this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x - 853f) / 2f;
			this.PreviousT = this.GameT.GetChild(3);
			this.btn_Previous = this.PreviousT.GetComponent<UIButton>();
			this.btn_Previous.m_Handler = this;
			this.btn_Previous.m_BtnID1 = 2;
			this.btn_Previous.m_EffectType = e_EffectType.e_Scale;
			this.btn_Previous.transition = Selectable.Transition.None;
			this.NextT = this.GameT.GetChild(4);
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
			this.Tmp = this.GameT.GetChild(5);
			this.tmpImg = this.Tmp.GetComponent<Image>();
			cstring.ClearString();
			cstring.AppendFormat("UI_main_close_base");
			this.tmpImg.sprite = this.door.LoadSprite(cstring);
			this.tmpImg.material = this.mMaT;
			if (this.GUIM.bOpenOnIPhoneX)
			{
				this.tmpImg.enabled = false;
			}
			this.Tmp = this.GameT.GetChild(5).GetChild(0);
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

	// Token: 0x06001DA0 RID: 7584 RVA: 0x0036E604 File Offset: 0x0036C804
	public override void OnClose()
	{
		if (this.Cstr_Page != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Page);
		}
		for (int i = 0; i < 7; i++)
		{
			if (this.Cstr_ItemTitle[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemTitle[i]);
			}
			if (this.Cstr_ItemName[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemName[i]);
			}
			if (this.Cstr_ItemRes_1[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemRes_1[i]);
			}
			if (this.Cstr_ItemRes_2[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemRes_2[i]);
			}
			if (this.Cstr_ItemRes_3[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemRes_3[i]);
			}
			if (this.Cstr_ItemRes_4[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemRes_4[i]);
			}
			if (this.Cstr_ItemRes_5[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemRes_5[i]);
			}
		}
	}

	// Token: 0x06001DA1 RID: 7585 RVA: 0x0036E720 File Offset: 0x0036C920
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
			this.tmpCR = this.DM.ResourceReportGet(sender.m_BtnID2);
			if (this.tmpCR != null)
			{
				DataManager.Instance.ShowLordProfile(this.tmpCR.Resource.Name);
			}
			break;
		}
	}

	// Token: 0x06001DA2 RID: 7586 RVA: 0x0036E7FC File Offset: 0x0036C9FC
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
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Resources);
					break;
				case CombatCollectReport.CCR_COLLECT:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Collection, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Resources);
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
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Resources);
					break;
				case CombatCollectReport.CCR_RECON:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Resources);
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
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Resources);
					break;
				case CombatCollectReport.CCR_NPCSCOUT:
					this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Resources);
					break;
				case CombatCollectReport.CCR_PETREPORT:
					this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Resources);
					break;
				}
			}
		}
	}

	// Token: 0x06001DA3 RID: 7587 RVA: 0x0036EA48 File Offset: 0x0036CC48
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (dataIdx > 0)
		{
			this.tmpCR = this.DM.ResourceReportGet(this.mResourcesMax - dataIdx);
		}
		if (this.ItemT[panelObjectIdx] == null)
		{
			this.ItemT[panelObjectIdx] = item.GetComponent<Transform>();
			this.mScrollItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			this.Itme_PT1[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(0);
			this.Itme_PT2[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(1);
			this.Img_ItemTitle[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetComponent<Image>();
			this.Img_ItemNew[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetComponent<Image>();
			this.text_ItemNew[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
			this.text_ItemTitle[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetComponent<UIText>();
			this.Item_textTitleT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetComponent<RectTransform>();
			this.text_ItemTime[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(2).GetComponent<UIText>();
			this.text_ItemTitle2[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(3).GetComponent<UIText>();
			this.btn_Hero_Porfile[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(4).GetComponent<UIButton>();
			this.btn_Hero_Porfile[panelObjectIdx].m_Handler = this;
			this.btn_Hero_Porfile[panelObjectIdx].m_BtnID2 = this.mResourcesMax - dataIdx;
			this.Item_btnPorfileT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(4).GetComponent<RectTransform>();
			this.Img_ItemPorfile[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(4).GetChild(0).GetComponent<Image>();
			this.text_ItemPorfile[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(4).GetChild(1).GetComponent<UIText>();
			this.Img_ItemBG[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetComponent<Image>();
			this.ItemResT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0);
			this.text_ItemRes_1[panelObjectIdx] = this.ItemResT[panelObjectIdx].GetChild(0).GetChild(0).GetComponent<UIText>();
			this.text_ItemRes_2[panelObjectIdx] = this.ItemResT[panelObjectIdx].GetChild(1).GetChild(0).GetComponent<UIText>();
			this.text_ItemRes_3[panelObjectIdx] = this.ItemResT[panelObjectIdx].GetChild(2).GetChild(0).GetComponent<UIText>();
			this.text_ItemRes_4[panelObjectIdx] = this.ItemResT[panelObjectIdx].GetChild(3).GetChild(0).GetComponent<UIText>();
			this.text_ItemRes_5[panelObjectIdx] = this.ItemResT[panelObjectIdx].GetChild(4).GetChild(0).GetComponent<UIText>();
			this.text_Item[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetComponent<UIText>();
			this.Img_ItemIcon1[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(2).GetChild(0).GetComponent<Image>();
			this.Img_ItemIcon2[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(2).GetChild(1).GetComponent<Image>();
			this.Img_ItemIcon3[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(2).GetChild(2).GetComponent<Image>();
			if (dataIdx == 0)
			{
				this.Itme_PT1[panelObjectIdx].gameObject.SetActive(true);
			}
			else
			{
				this.Itme_PT2[panelObjectIdx].gameObject.SetActive(true);
				if (this.tmpCR != null)
				{
					this.SetItemIcon(panelObjectIdx, (int)this.tmpCR.Resource.Result, true);
				}
				if (this.UnReadNum >= dataIdx)
				{
					this.Img_ItemNew[panelObjectIdx].gameObject.SetActive(true);
				}
			}
		}
		else
		{
			this.btn_Hero_Porfile[panelObjectIdx].m_BtnID2 = this.mResourcesMax - dataIdx;
			if (dataIdx == 0)
			{
				this.Itme_PT1[panelObjectIdx].gameObject.SetActive(true);
				this.Itme_PT2[panelObjectIdx].gameObject.SetActive(false);
			}
			else
			{
				this.Itme_PT1[panelObjectIdx].gameObject.SetActive(false);
				this.Itme_PT2[panelObjectIdx].gameObject.SetActive(true);
				this.SetItemIcon(panelObjectIdx, this.mScrollItem[panelObjectIdx].m_BtnID2, false);
				if (this.tmpCR != null)
				{
					this.SetItemIcon(panelObjectIdx, (int)this.tmpCR.Resource.Result, true);
				}
			}
		}
		if (dataIdx > 0)
		{
			if (this.UnReadNum >= dataIdx)
			{
				this.Item_textTitleT[panelObjectIdx].anchoredPosition = this.text_ItemTitle[panelObjectIdx].ArabicFixPos(new Vector2(121f, this.Item_textTitleT[panelObjectIdx].anchoredPosition.y));
				this.Img_ItemNew[panelObjectIdx].gameObject.SetActive(true);
			}
			else
			{
				this.Item_textTitleT[panelObjectIdx].anchoredPosition = this.text_ItemTitle[panelObjectIdx].ArabicFixPos(new Vector2(39f, this.Item_textTitleT[panelObjectIdx].anchoredPosition.y));
				this.Img_ItemNew[panelObjectIdx].gameObject.SetActive(false);
			}
			if (this.tmpCR != null)
			{
				this.Cstr_ItemName[panelObjectIdx].ClearString();
				this.Cstr_ItemName[panelObjectIdx].Append(this.tmpCR.Resource.Name);
				this.Cstr_ItemTitle[panelObjectIdx].ClearString();
				this.text_ItemTitle2[panelObjectIdx].gameObject.SetActive(false);
				switch (this.tmpCR.Resource.Result)
				{
				case 0:
					this.Cstr_ItemTitle[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(12084u));
					break;
				case 1:
					this.Cstr_ItemTitle[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(12085u));
					break;
				case 2:
					this.Cstr_ItemTitle[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(12082u));
					break;
				}
				this.text_ItemTitle[panelObjectIdx].text = this.Cstr_ItemTitle[panelObjectIdx].ToString();
				this.text_ItemTitle[panelObjectIdx].SetAllDirty();
				this.text_ItemTitle[panelObjectIdx].cachedTextGenerator.Invalidate();
				this.text_ItemTitle[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
				this.text_ItemPorfile[panelObjectIdx].text = this.Cstr_ItemName[panelObjectIdx].ToString();
				this.text_ItemPorfile[panelObjectIdx].SetAllDirty();
				this.text_ItemPorfile[panelObjectIdx].cachedTextGenerator.Invalidate();
				this.text_ItemPorfile[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
				this.text_ItemPorfile[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.text_ItemPorfile[panelObjectIdx].preferredWidth + 1f, this.text_ItemPorfile[panelObjectIdx].rectTransform.sizeDelta.y);
				if (this.GUIM.IsArabic)
				{
					this.text_ItemPorfile[panelObjectIdx].UpdateArabicPos();
				}
				this.Item_btnPorfileT[panelObjectIdx].sizeDelta = new Vector2(this.text_ItemPorfile[panelObjectIdx].preferredWidth + 1f, this.Item_btnPorfileT[panelObjectIdx].sizeDelta.y);
				this.Img_ItemPorfile[panelObjectIdx].rectTransform.sizeDelta = new Vector2(this.text_ItemPorfile[panelObjectIdx].preferredWidth + 1f, this.Img_ItemPorfile[panelObjectIdx].rectTransform.sizeDelta.y);
				if (this.GUIM.IsArabic && this.text_ItemTitle[panelObjectIdx].rectTransform.localScale.x == -1f)
				{
					this.Item_btnPorfileT[panelObjectIdx].anchoredPosition = new Vector2(this.text_ItemTitle[panelObjectIdx].rectTransform.anchoredPosition.x - this.text_ItemTitle[panelObjectIdx].rectTransform.sizeDelta.x + this.text_ItemTitle[panelObjectIdx].preferredWidth + 1f, this.Item_btnPorfileT[panelObjectIdx].anchoredPosition.y);
				}
				else
				{
					this.Item_btnPorfileT[panelObjectIdx].anchoredPosition = new Vector2(this.text_ItemTitle[panelObjectIdx].rectTransform.anchoredPosition.x + this.text_ItemTitle[panelObjectIdx].preferredWidth + 1f, this.Item_btnPorfileT[panelObjectIdx].anchoredPosition.y);
				}
				this.text_ItemTime[panelObjectIdx].text = GameConstants.GetDateTime(this.tmpCR.Times).ToString("MM/dd/yy HH:mm:ss");
				this.text_ItemTime[panelObjectIdx].SetAllDirty();
				this.text_ItemTime[panelObjectIdx].cachedTextGenerator.Invalidate();
				if (this.tmpCR.Resource.Result < 2)
				{
					this.Cstr_ItemRes_1[panelObjectIdx].ClearString();
					GameConstants.FormatResourceValue(this.Cstr_ItemRes_1[panelObjectIdx], this.tmpCR.Resource.Resource[0]);
					this.text_ItemRes_1[panelObjectIdx].text = this.Cstr_ItemRes_1[panelObjectIdx].ToString();
					this.text_ItemRes_1[panelObjectIdx].SetAllDirty();
					this.text_ItemRes_1[panelObjectIdx].cachedTextGenerator.Invalidate();
					this.Cstr_ItemRes_2[panelObjectIdx].ClearString();
					GameConstants.FormatResourceValue(this.Cstr_ItemRes_2[panelObjectIdx], this.tmpCR.Resource.Resource[1]);
					this.text_ItemRes_2[panelObjectIdx].text = this.Cstr_ItemRes_2[panelObjectIdx].ToString();
					this.text_ItemRes_2[panelObjectIdx].SetAllDirty();
					this.text_ItemRes_2[panelObjectIdx].cachedTextGenerator.Invalidate();
					this.Cstr_ItemRes_3[panelObjectIdx].ClearString();
					GameConstants.FormatResourceValue(this.Cstr_ItemRes_3[panelObjectIdx], this.tmpCR.Resource.Resource[2]);
					this.text_ItemRes_3[panelObjectIdx].text = this.Cstr_ItemRes_3[panelObjectIdx].ToString();
					this.text_ItemRes_3[panelObjectIdx].SetAllDirty();
					this.text_ItemRes_3[panelObjectIdx].cachedTextGenerator.Invalidate();
					this.Cstr_ItemRes_4[panelObjectIdx].ClearString();
					GameConstants.FormatResourceValue(this.Cstr_ItemRes_4[panelObjectIdx], this.tmpCR.Resource.Resource[3]);
					this.text_ItemRes_4[panelObjectIdx].text = this.Cstr_ItemRes_4[panelObjectIdx].ToString();
					this.text_ItemRes_4[panelObjectIdx].SetAllDirty();
					this.text_ItemRes_4[panelObjectIdx].cachedTextGenerator.Invalidate();
					this.Cstr_ItemRes_5[panelObjectIdx].ClearString();
					GameConstants.FormatResourceValue(this.Cstr_ItemRes_5[panelObjectIdx], this.tmpCR.Resource.Resource[4]);
					this.text_ItemRes_5[panelObjectIdx].text = this.Cstr_ItemRes_5[panelObjectIdx].ToString();
					this.text_ItemRes_5[panelObjectIdx].SetAllDirty();
					this.text_ItemRes_5[panelObjectIdx].cachedTextGenerator.Invalidate();
					this.ItemResT[panelObjectIdx].gameObject.SetActive(true);
					this.text_Item[panelObjectIdx].gameObject.SetActive(false);
				}
				else
				{
					this.ItemResT[panelObjectIdx].gameObject.SetActive(false);
					this.text_Item[panelObjectIdx].gameObject.SetActive(true);
				}
			}
		}
	}

	// Token: 0x06001DA4 RID: 7588 RVA: 0x0036F5B0 File Offset: 0x0036D7B0
	public void SetItemIcon(int ListIdx, int Result, bool bShow)
	{
		switch (Result)
		{
		case 0:
			this.Img_ItemTitle[ListIdx].sprite = this.SArray.m_Sprites[1];
			this.Img_ItemIcon2[ListIdx].gameObject.SetActive(bShow);
			break;
		case 1:
			this.Img_ItemTitle[ListIdx].sprite = this.SArray.m_Sprites[0];
			this.Img_ItemIcon1[ListIdx].gameObject.SetActive(bShow);
			break;
		case 2:
			this.Img_ItemTitle[ListIdx].sprite = this.SArray.m_Sprites[2];
			this.Img_ItemIcon3[ListIdx].gameObject.SetActive(bShow);
			break;
		}
		if (bShow)
		{
			this.mScrollItem[ListIdx].m_BtnID2 = Result;
		}
	}

	// Token: 0x06001DA5 RID: 7589 RVA: 0x0036F680 File Offset: 0x0036D880
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001DA6 RID: 7590 RVA: 0x0036F684 File Offset: 0x0036D884
	public void SetPageData(bool bopen = false)
	{
	}

	// Token: 0x06001DA7 RID: 7591 RVA: 0x0036F688 File Offset: 0x0036D888
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.tmplist.Clear();
			this.mResourcesMax = this.DM.GetMailboxResourceSize();
			for (int i = 0; i < this.mResourcesMax + 1; i++)
			{
				this.tmplist.Add(101f);
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
		}
	}

	// Token: 0x06001DA8 RID: 7592 RVA: 0x0036F700 File Offset: 0x0036D900
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
				if (meg[1] == 1 && meg[2] == 2)
				{
					this.Favor.Serial = this.DM.GetMailboxReportSerial(ReportSubSet.REPORTSet_HELP);
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
					this.mResourcesMax = this.DM.GetMailboxResourceSize();
					for (int i = 0; i < this.mResourcesMax; i++)
					{
						this.tmplist.Add(101f);
						this.tmpCR = this.DM.ResourceReportGet(this.mResourcesMax - (1 + i));
						if (this.tmpCR != null && !this.tmpCR.BeRead)
						{
							this.UnReadNum++;
						}
					}
					this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
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

	// Token: 0x06001DA9 RID: 7593 RVA: 0x0036FAE0 File Offset: 0x0036DCE0
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
		for (int i = 0; i < 2; i++)
		{
			if (this.text_Time[i] != null && this.text_Time[i].enabled)
			{
				this.text_Time[i].enabled = false;
				this.text_Time[i].enabled = true;
			}
		}
		for (int j = 0; j < 7; j++)
		{
			if (this.text_ItemTitle[j] != null && this.text_ItemTitle[j].enabled)
			{
				this.text_ItemTitle[j].enabled = false;
				this.text_ItemTitle[j].enabled = true;
			}
			if (this.text_ItemTime[j] != null && this.text_ItemTime[j].enabled)
			{
				this.text_ItemTime[j].enabled = false;
				this.text_ItemTime[j].enabled = true;
			}
			if (this.text_ItemRes_1[j] != null && this.text_ItemRes_1[j].enabled)
			{
				this.text_ItemRes_1[j].enabled = false;
				this.text_ItemRes_1[j].enabled = true;
			}
			if (this.text_ItemRes_2[j] != null && this.text_ItemRes_2[j].enabled)
			{
				this.text_ItemRes_2[j].enabled = false;
				this.text_ItemRes_2[j].enabled = true;
			}
			if (this.text_ItemRes_3[j] != null && this.text_ItemRes_3[j].enabled)
			{
				this.text_ItemRes_3[j].enabled = false;
				this.text_ItemRes_3[j].enabled = true;
			}
			if (this.text_ItemRes_4[j] != null && this.text_ItemRes_4[j].enabled)
			{
				this.text_ItemRes_4[j].enabled = false;
				this.text_ItemRes_4[j].enabled = true;
			}
			if (this.text_ItemRes_5[j] != null && this.text_ItemRes_5[j].enabled)
			{
				this.text_ItemRes_5[j].enabled = false;
				this.text_ItemRes_5[j].enabled = true;
			}
			if (this.text_Item[j] != null && this.text_Item[j].enabled)
			{
				this.text_Item[j].enabled = false;
				this.text_Item[j].enabled = true;
			}
			if (this.text_ItemNew[j] != null && this.text_ItemNew[j].enabled)
			{
				this.text_ItemNew[j].enabled = false;
				this.text_ItemNew[j].enabled = true;
			}
			if (this.text_ItemPorfile[j] != null && this.text_ItemPorfile[j].enabled)
			{
				this.text_ItemPorfile[j].enabled = false;
				this.text_ItemPorfile[j].enabled = true;
			}
			if (this.text_ItemTitle2[j] != null && this.text_ItemTitle2[j].enabled)
			{
				this.text_ItemTitle2[j].enabled = false;
				this.text_ItemTitle2[j].enabled = true;
			}
		}
	}

	// Token: 0x06001DAA RID: 7594 RVA: 0x0036FE90 File Offset: 0x0036E090
	private void Start()
	{
	}

	// Token: 0x06001DAB RID: 7595 RVA: 0x0036FE94 File Offset: 0x0036E094
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

	// Token: 0x04005B69 RID: 23401
	private DataManager DM;

	// Token: 0x04005B6A RID: 23402
	private GUIManager GUIM;

	// Token: 0x04005B6B RID: 23403
	private Font TTFont;

	// Token: 0x04005B6C RID: 23404
	private Door door;

	// Token: 0x04005B6D RID: 23405
	private Transform GameT;

	// Token: 0x04005B6E RID: 23406
	private Transform Tmp;

	// Token: 0x04005B6F RID: 23407
	private Transform Tmp1;

	// Token: 0x04005B70 RID: 23408
	private Transform Tmp2;

	// Token: 0x04005B71 RID: 23409
	private Transform PreviousT;

	// Token: 0x04005B72 RID: 23410
	private Transform NextT;

	// Token: 0x04005B73 RID: 23411
	private Transform[] ItemT = new Transform[7];

	// Token: 0x04005B74 RID: 23412
	private Transform[] Itme_PT1 = new Transform[7];

	// Token: 0x04005B75 RID: 23413
	private Transform[] Itme_PT2 = new Transform[7];

	// Token: 0x04005B76 RID: 23414
	private Transform[] ItemResT = new Transform[7];

	// Token: 0x04005B77 RID: 23415
	private RectTransform[] Item_textTitleT = new RectTransform[7];

	// Token: 0x04005B78 RID: 23416
	private RectTransform[] Item_btnPorfileT = new RectTransform[7];

	// Token: 0x04005B79 RID: 23417
	private UIButton btn_EXIT;

	// Token: 0x04005B7A RID: 23418
	private UIButton btn_Delete;

	// Token: 0x04005B7B RID: 23419
	private UIButton btn_Previous;

	// Token: 0x04005B7C RID: 23420
	private UIButton btn_Next;

	// Token: 0x04005B7D RID: 23421
	private UIButton[] btn_Hero_Porfile = new UIButton[7];

	// Token: 0x04005B7E RID: 23422
	private Image tmpImg;

	// Token: 0x04005B7F RID: 23423
	private Image[] Img_ItemNew = new Image[7];

	// Token: 0x04005B80 RID: 23424
	private Image[] Img_ItemTitle = new Image[7];

	// Token: 0x04005B81 RID: 23425
	private Image[] Img_ItemBG = new Image[7];

	// Token: 0x04005B82 RID: 23426
	private Image[] Img_ItemIcon1 = new Image[7];

	// Token: 0x04005B83 RID: 23427
	private Image[] Img_ItemIcon2 = new Image[7];

	// Token: 0x04005B84 RID: 23428
	private Image[] Img_ItemIcon3 = new Image[7];

	// Token: 0x04005B85 RID: 23429
	private Image[] Img_ItemPorfile = new Image[7];

	// Token: 0x04005B86 RID: 23430
	private UIText tmptext;

	// Token: 0x04005B87 RID: 23431
	private UIText text_TitleName;

	// Token: 0x04005B88 RID: 23432
	private UIText text_Page;

	// Token: 0x04005B89 RID: 23433
	private UIText[] text_Time = new UIText[2];

	// Token: 0x04005B8A RID: 23434
	private UIText[] text_ItemTitle = new UIText[7];

	// Token: 0x04005B8B RID: 23435
	private UIText[] text_ItemTime = new UIText[7];

	// Token: 0x04005B8C RID: 23436
	private UIText[] text_ItemRes_1 = new UIText[7];

	// Token: 0x04005B8D RID: 23437
	private UIText[] text_ItemRes_2 = new UIText[7];

	// Token: 0x04005B8E RID: 23438
	private UIText[] text_ItemRes_3 = new UIText[7];

	// Token: 0x04005B8F RID: 23439
	private UIText[] text_ItemRes_4 = new UIText[7];

	// Token: 0x04005B90 RID: 23440
	private UIText[] text_ItemRes_5 = new UIText[7];

	// Token: 0x04005B91 RID: 23441
	private UIText[] text_Item = new UIText[7];

	// Token: 0x04005B92 RID: 23442
	private UIText[] text_ItemNew = new UIText[7];

	// Token: 0x04005B93 RID: 23443
	private UIText[] text_ItemPorfile = new UIText[7];

	// Token: 0x04005B94 RID: 23444
	private UIText[] text_ItemTitle2 = new UIText[7];

	// Token: 0x04005B95 RID: 23445
	private CString Cstr_Page;

	// Token: 0x04005B96 RID: 23446
	private CString[] Cstr_ItemTitle = new CString[7];

	// Token: 0x04005B97 RID: 23447
	private CString[] Cstr_ItemName = new CString[7];

	// Token: 0x04005B98 RID: 23448
	private CString[] Cstr_ItemRes_1 = new CString[7];

	// Token: 0x04005B99 RID: 23449
	private CString[] Cstr_ItemRes_2 = new CString[7];

	// Token: 0x04005B9A RID: 23450
	private CString[] Cstr_ItemRes_3 = new CString[7];

	// Token: 0x04005B9B RID: 23451
	private CString[] Cstr_ItemRes_4 = new CString[7];

	// Token: 0x04005B9C RID: 23452
	private CString[] Cstr_ItemRes_5 = new CString[7];

	// Token: 0x04005B9D RID: 23453
	private Material mMaT;

	// Token: 0x04005B9E RID: 23454
	private UISpritesArray SArray;

	// Token: 0x04005B9F RID: 23455
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04005BA0 RID: 23456
	private ScrollPanelItem[] mScrollItem = new ScrollPanelItem[7];

	// Token: 0x04005BA1 RID: 23457
	private float tempL;

	// Token: 0x04005BA2 RID: 23458
	private float MoveTime1;

	// Token: 0x04005BA3 RID: 23459
	private float MoveTime2;

	// Token: 0x04005BA4 RID: 23460
	private float TmpTime;

	// Token: 0x04005BA5 RID: 23461
	private int MaxLetterNum;

	// Token: 0x04005BA6 RID: 23462
	private int mResourcesMax;

	// Token: 0x04005BA7 RID: 23463
	private int UnReadNum;

	// Token: 0x04005BA8 RID: 23464
	private CombatReport Report;

	// Token: 0x04005BA9 RID: 23465
	private CombatReport tmpCR;

	// Token: 0x04005BAA RID: 23466
	private MyFavorite Favor = new MyFavorite(MailType.EMAIL_MAX, 0u);

	// Token: 0x04005BAB RID: 23467
	private Vector3 Vec3Instance;

	// Token: 0x04005BAC RID: 23468
	private List<float> tmplist = new List<float>();
}
