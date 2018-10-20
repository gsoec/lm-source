using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005D7 RID: 1495
public class UILetter_Watchtower_Recon : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001DB8 RID: 7608 RVA: 0x00374B74 File Offset: 0x00372D74
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		CString cstring = StringManager.Instance.StaticString1024();
		this.Cstr_Title = StringManager.Instance.SpawnString(30);
		this.Cstr_Page = StringManager.Instance.SpawnString(30);
		for (int i = 0; i < 6; i++)
		{
			this.Cstr_ItemTitle[i] = StringManager.Instance.SpawnString(300);
			this.Cstr_ItemInfo[i] = StringManager.Instance.SpawnString(300);
			this.Cstr_ItemKXY[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_ItemNameKXY[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_ItemKingdom[i] = StringManager.Instance.SpawnString(30);
		}
		this.mMaT = this.door.LoadMaterial();
		this.IconMaterial = this.GUIM.m_IconSpriteAsset.GetMaterial();
		this.FrameMaterial = this.GUIM.GetFrameMaterial();
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
			this.Tmp = this.GameT.GetChild(0).GetChild(1).GetChild(0);
			this.text_TitleName = this.Tmp.GetComponent<UIText>();
			this.text_TitleName.font = this.TTFont;
			this.Cstr_Title.ClearString();
			if (this.Report.Recon.bAmbush == 1)
			{
				this.Cstr_Title.Append(this.DM.mStringTable.GetStringByID(9748u));
			}
			else if (this.Report.Recon.CombatPointKind == POINT_KIND.PK_YOLK)
			{
				this.Cstr_Title.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Recon.CombatPoint, this.Report.Recon.KingdomID));
				this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(7263u));
			}
			else
			{
				this.Cstr_Title.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Recon.CombatPointKind));
				this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(5355u));
			}
			this.text_TitleName.text = this.Cstr_Title.ToString();
			this.text_TitleName.SetAllDirty();
			this.text_TitleName.cachedTextGenerator.Invalidate();
			this.Tmp = this.GameT.GetChild(0).GetChild(1).GetChild(1);
			this.text_Page = this.Tmp.GetComponent<UIText>();
			this.text_Page.font = this.TTFont;
			this.m_ScrollPanel = this.GameT.GetChild(1).GetComponent<ScrollPanel>();
			this.Tmp = this.GameT.GetChild(2).GetChild(1);
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(0).GetChild(0);
			UIText component = this.Tmp1.GetComponent<UIText>();
			component.font = this.TTFont;
			component.text = this.DM.mStringTable.GetStringByID(6048u);
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(1);
			UIButton uibutton = this.Tmp1.GetComponent<UIButton>();
			uibutton.m_Handler = this;
			uibutton.m_BtnID1 = 4;
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(1).GetChild(1);
			component = this.Tmp1.GetComponent<UIText>();
			component.font = this.TTFont;
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(2);
			component = this.Tmp1.GetComponent<UIText>();
			component.font = this.TTFont;
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(3);
			component = this.Tmp1.GetComponent<UIText>();
			component.font = this.TTFont;
			this.Tmp = this.GameT.GetChild(2).GetChild(1).GetChild(1).GetChild(0);
			this.Tmp1 = this.Tmp.GetChild(0);
			this.tmpImg = this.Tmp1.GetComponent<Image>();
			IgnoreRaycast component2 = this.tmpImg.GetComponent<IgnoreRaycast>();
			if (component2 != null)
			{
				UnityEngine.Object.DestroyImmediate(component2);
			}
			uibutton = this.tmpImg.gameObject.AddComponent<UIButton>();
			uibutton.m_EffectType = e_EffectType.e_Scale;
			uibutton.transition = Selectable.Transition.None;
			uibutton.m_BtnID1 = 5;
			uibutton.m_Handler = this;
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
			this.tmpImg = this.Tmp1.GetComponent<Image>();
			this.tmpImg.material = this.IconMaterial;
			this.tmpRCT = this.tmpImg.GetComponent<RectTransform>();
			this.tmpRCT.anchorMin = new Vector2(0.0703125f, 0.0703125f);
			this.tmpRCT.anchorMax = new Vector2(0.9296875f, 0.9296875f);
			this.tmpRCT.offsetMin = Vector2.zero;
			this.tmpRCT.offsetMax = Vector2.zero;
			this.tmpRCT.pivot = new Vector2(0.5f, 0.5f);
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(1);
			this.tmpImg = this.Tmp1.GetComponent<Image>();
			this.tmpImg.material = this.FrameMaterial;
			this.tmpImg.sprite = this.GUIM.LoadFrameSprite("hf011");
			this.tmpRCT = this.tmpImg.GetComponent<RectTransform>();
			this.tmpRCT.anchorMin = Vector2.zero;
			this.tmpRCT.anchorMax = new Vector2(1f, 1f);
			this.tmpRCT.offsetMin = Vector2.zero;
			this.tmpRCT.offsetMax = Vector2.zero;
			this.Tmp1 = this.Tmp.GetChild(1).GetChild(0);
			this.tmpImg = this.Tmp1.GetComponent<Image>();
			if (this.GUIM.IsArabic)
			{
				this.tmpImg.gameObject.AddComponent<ArabicItemTextureRot>();
			}
			this.Tmp = this.GameT.GetChild(2).GetChild(1).GetChild(1);
			this.Tmp1 = this.Tmp.GetChild(1);
			uibutton = this.Tmp1.GetComponent<UIButton>();
			uibutton.m_BtnID1 = 5;
			uibutton.m_Handler = this;
			this.Tmp1 = this.Tmp.GetChild(1).GetChild(1);
			component = this.Tmp1.GetComponent<UIText>();
			component.font = this.TTFont;
			this.Tmp1 = this.Tmp.GetChild(2);
			component = this.Tmp1.GetComponent<UIText>();
			component.font = this.TTFont;
			component.rectTransform.sizeDelta = new Vector2(581f, component.rectTransform.sizeDelta.y);
			component.resizeTextMinSize = 9;
			this.Tmp1 = this.Tmp.GetChild(3);
			component = this.Tmp1.GetComponent<UIText>();
			component.font = this.TTFont;
			component.text = this.DM.mStringTable.GetStringByID(5354u);
			this.Tmp1 = this.Tmp.GetChild(4);
			component = this.Tmp1.GetComponent<UIText>();
			component.font = this.TTFont;
			component.text = this.DM.mStringTable.GetStringByID(6015u);
			this.Tmp1 = this.Tmp.GetChild(5);
			component = this.Tmp1.GetComponent<UIText>();
			component.font = this.TTFont;
			this.Tmp1 = this.Tmp.GetChild(6);
			component = this.Tmp1.GetComponent<UIText>();
			component.font = this.TTFont;
			this.mReconMax = (int)this.Report.More;
			for (int j = 0; j < this.mReconMax; j++)
			{
				this.tmpCR = this.DM.ReconReportGet(this.mReconMax - (1 + j));
				if (this.tmpCR != null && !this.tmpCR.BeRead)
				{
					this.UnReadNum++;
				}
			}
			for (int k = 0; k < this.mReconMax + 1; k++)
			{
				this.tmplist.Add(101f);
			}
			this.m_ScrollPanel.IntiScrollPanel(437f, 0f, 0f, this.tmplist, 6, this);
			this.Tmp = this.GameT.GetChild(3).GetChild(0);
			this.btn_Delete = this.Tmp.GetComponent<UIButton>();
			this.btn_Delete.m_Handler = this;
			this.btn_Delete.m_BtnID1 = 1;
			this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
			this.btn_Delete.transition = Selectable.Transition.None;
			this.Tmp = this.GameT.GetChild(3).GetChild(1);
			this.text_LastTitle = this.Tmp.GetComponent<UIText>();
			this.text_LastTitle.font = this.TTFont;
			this.text_LastTitle.text = this.DM.mStringTable.GetStringByID(5350u);
			this.Tmp = this.GameT.GetChild(3).GetChild(2);
			this.text_Time[0] = this.Tmp.GetComponent<UIText>();
			this.text_Time[0].font = this.TTFont;
			this.Tmp = this.GameT.GetChild(3).GetChild(3);
			this.text_Time[1] = this.Tmp.GetComponent<UIText>();
			this.text_Time[1].font = this.TTFont;
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
			this.text_Page.SetAllDirty();
			this.text_Page.cachedTextGenerator.Invalidate();
			this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Times).ToString("MM/dd/yy");
			this.text_Time[0].SetAllDirty();
			this.text_Time[0].cachedTextGenerator.Invalidate();
			this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Times).ToString("HH:mm:ss");
			this.text_Time[1].SetAllDirty();
			this.text_Time[1].cachedTextGenerator.Invalidate();
			this.btn_Previous.gameObject.SetActive(true);
			this.btn_Next.gameObject.SetActive(true);
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
			this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
			return;
		}
		this.Report = null;
		this.door.CloseMenu(false);
	}

	// Token: 0x06001DB9 RID: 7609 RVA: 0x00375C44 File Offset: 0x00373E44
	public override void OnClose()
	{
		if (this.Cstr_Title != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Title);
		}
		if (this.Cstr_Page != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Page);
		}
		for (int i = 0; i < 6; i++)
		{
			if (this.Cstr_ItemTitle[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemTitle[i]);
			}
			if (this.Cstr_ItemInfo[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemInfo[i]);
			}
			if (this.Cstr_ItemKXY[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemKXY[i]);
			}
			if (this.Cstr_ItemNameKXY[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemNameKXY[i]);
			}
			if (this.Cstr_ItemKingdom[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemKingdom[i]);
			}
		}
	}

	// Token: 0x06001DBA RID: 7610 RVA: 0x00375D3C File Offset: 0x00373F3C
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
			this.tmpCR = this.DM.ReconReportGet(sender.m_BtnID2);
			if (this.tmpCR == null)
			{
				return;
			}
			if (this.tmpCR.Recon.CombatPointKind != POINT_KIND.PK_YOLK)
			{
				this.door.GoToPointCode(this.tmpCR.Recon.KingdomID, this.tmpCR.Recon.CombatlZone, this.tmpCR.Recon.CombatPoint, 0);
			}
			else
			{
				this.door.GoToWonder(this.tmpCR.Recon.KingdomID, this.tmpCR.Recon.CombatPoint);
			}
			break;
		case 5:
			this.tmpCR = this.DM.ReconReportGet(sender.m_BtnID2);
			if (this.tmpCR != null && this.tmpCR.Recon != null && this.tmpCR.Recon.SrcName != null && this.tmpCR.Recon.SrcName != string.Empty)
			{
				DataManager.Instance.ShowLordProfile(this.tmpCR.Recon.SrcName);
			}
			break;
		}
	}

	// Token: 0x06001DBB RID: 7611 RVA: 0x00375F0C File Offset: 0x0037410C
	public void Open_NP_Mail(bool bNext)
	{
		if (this.DM.MailReportGet(ref this.Favor, bNext))
		{
			switch (this.Favor.Type)
			{
			case MailType.EMAIL_SYSTEM:
				this.DM.OpenMail.Serial = this.Favor.Serial;
				this.DM.OpenMail.Type = this.Favor.Type;
				this.DM.OpenMail.Kind = this.Favor.Kind;
				this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
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
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
					break;
				case CombatCollectReport.CCR_RESOURCE:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Resources, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
					break;
				case CombatCollectReport.CCR_COLLECT:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Collection, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
					break;
				case CombatCollectReport.CCR_SCOUT:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
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
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
					break;
				case CombatCollectReport.CCR_NPCSCOUT:
					this.door.CloseMenu(false);
					this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout, 0, 0, false);
					break;
				case CombatCollectReport.CCR_PETREPORT:
					this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
					break;
				}
				break;
			case MailType.EMAIL_LETTER:
				this.DM.OpenMail.Serial = this.Favor.Serial;
				this.DM.OpenMail.Type = this.Favor.Type;
				this.DM.OpenMail.Kind = this.Favor.Kind;
				this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
				break;
			}
		}
	}

	// Token: 0x06001DBC RID: 7612 RVA: 0x00376230 File Offset: 0x00374430
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.ItemT[panelObjectIdx] == null)
		{
			this.ItemT[panelObjectIdx] = item.GetComponent<Transform>();
			this.mScrollItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			this.Itme_PT1[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(0);
			this.Itme_PT2[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(1);
			this.Img_New[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetComponent<Image>();
			this.text_ItemNew[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
			this.btn_KXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetComponent<UIButton>();
			this.btn_KXY[panelObjectIdx].m_Handler = this;
			this.BtnKXY_ItemRT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetComponent<RectTransform>();
			this.Img_KXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
			this.text_ItemKXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetChild(1).GetComponent<UIText>();
			this.text_ItemTitle[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(2).GetComponent<UIText>();
			this.text_ItemTime[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(3).GetComponent<UIText>();
			this.Img_Hero[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();
			this.btn_Hero_Porfile[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0).GetChild(0).GetComponent<UIButton>();
			this.btn_Hero_Porfile[panelObjectIdx].m_Handler = this;
			this.Img_HeroHead[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
			this.Img_NoHero[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0).GetChild(1).GetComponent<Image>();
			this.btn_NameKXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetComponent<UIButton>();
			this.btn_NameKXY[panelObjectIdx].m_Handler = this;
			this.BtnNameKXY_ItemRT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetComponent<RectTransform>();
			this.Img_NameKXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>();
			this.text_ItemNameKXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(1).GetComponent<UIText>();
			this.text_ItemInfo[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(2).GetComponent<UIText>();
			this.text_ItemLv[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(3).GetComponent<UIText>();
			this.text_ItemRecon[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(4).GetComponent<UIText>();
			this.text_ItemName[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(5).GetComponent<UIText>();
			this.text_ItemKingdom[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(6).GetComponent<UIText>();
			if (this.UnReadNum >= dataIdx)
			{
				this.Img_New[panelObjectIdx].gameObject.SetActive(true);
			}
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

	// Token: 0x06001DBD RID: 7613 RVA: 0x00376634 File Offset: 0x00374834
	public void SetItemData(int Idx, int ItemIdx)
	{
		this.tmpCR = this.DM.ReconReportGet(this.mReconMax - Idx);
		if (this.tmpCR == null)
		{
			return;
		}
		if (this.UnReadNum >= Idx)
		{
			this.text_ItemTitle[ItemIdx].rectTransform.anchoredPosition = this.text_ItemTitle[ItemIdx].ArabicFixPos(new Vector2(121f, this.text_ItemTitle[ItemIdx].rectTransform.anchoredPosition.y));
			this.Img_New[ItemIdx].gameObject.SetActive(true);
		}
		else
		{
			this.text_ItemTitle[ItemIdx].rectTransform.anchoredPosition = this.text_ItemTitle[ItemIdx].ArabicFixPos(new Vector2(22f, this.text_ItemTitle[ItemIdx].rectTransform.anchoredPosition.y));
			this.Img_New[ItemIdx].gameObject.SetActive(false);
		}
		this.text_ItemTime[ItemIdx].text = GameConstants.GetDateTime(this.tmpCR.Times).ToString("MM/dd/yy HH:mm:ss");
		this.text_ItemTime[ItemIdx].SetAllDirty();
		this.text_ItemTime[ItemIdx].cachedTextGenerator.Invalidate();
		this.Cstr_ItemTitle[ItemIdx].ClearString();
		if (this.tmpCR.Recon.bAmbush == 1)
		{
			this.Cstr_ItemTitle[ItemIdx].Append(this.DM.mStringTable.GetStringByID(9726u));
		}
		else if (this.tmpCR.Recon.CombatPointKind == POINT_KIND.PK_YOLK)
		{
			this.Cstr_ItemTitle[ItemIdx].Append(DataManager.MapDataController.GetYolkName((ushort)this.tmpCR.Recon.CombatPoint, this.tmpCR.Recon.KingdomID));
		}
		else
		{
			this.Cstr_ItemTitle[ItemIdx].Append(this.GUIM.GetPointName_Letter(this.tmpCR.Recon.CombatPointKind));
		}
		this.text_ItemTitle[ItemIdx].text = this.Cstr_ItemTitle[ItemIdx].ToString();
		this.text_ItemTitle[ItemIdx].SetAllDirty();
		this.text_ItemTitle[ItemIdx].cachedTextGenerator.Invalidate();
		this.text_ItemTitle[ItemIdx].cachedTextGeneratorForLayout.Invalidate();
		if (this.text_ItemTitle[ItemIdx].preferredWidth + 1f > this.text_ItemTitle[ItemIdx].rectTransform.sizeDelta.x)
		{
			this.text_ItemTitle[ItemIdx].rectTransform.sizeDelta = new Vector2(this.text_ItemTitle[ItemIdx].preferredWidth + 1f, this.text_ItemTitle[ItemIdx].rectTransform.sizeDelta.y);
		}
		this.Cstr_ItemNameKXY[ItemIdx].ClearString();
		this.mWatchLv = (int)this.tmpCR.Recon.WatchLevel;
		this.text_ItemKingdom[ItemIdx].gameObject.SetActive(false);
		if (this.mWatchLv >= 4)
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			if (this.mWatchLv >= 10)
			{
				CString cstring2 = StringManager.Instance.StaticString1024();
				cstring2.ClearString();
				cstring.Append(this.tmpCR.Recon.SrcName);
				if (this.tmpCR.Recon.SrcAllianceTag != null && this.tmpCR.Recon.SrcAllianceTag.Length != 0)
				{
					cstring2.Append(this.tmpCR.Recon.SrcAllianceTag);
					GameConstants.FormatRoleName(this.Cstr_ItemNameKXY[ItemIdx], cstring, cstring2, null, 0, 0, null, null, null, null);
				}
				else
				{
					GameConstants.FormatRoleName(this.Cstr_ItemNameKXY[ItemIdx], cstring, null, null, 0, 0, null, null, null, null);
				}
				this.Cstr_ItemKingdom[ItemIdx].ClearString();
				if (this.tmpCR.Recon.SrcKingdomID != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.Cstr_ItemKingdom[ItemIdx].IntToFormat((long)this.tmpCR.Recon.SrcKingdomID, 1, false);
					if (this.GUIM.IsArabic)
					{
						this.Cstr_ItemKingdom[ItemIdx].AppendFormat("{0}#");
					}
					else
					{
						this.Cstr_ItemKingdom[ItemIdx].AppendFormat("#{0}");
					}
					this.text_ItemKingdom[ItemIdx].gameObject.SetActive(true);
				}
				this.text_ItemKingdom[ItemIdx].text = this.Cstr_ItemKingdom[ItemIdx].ToString();
				this.text_ItemKingdom[ItemIdx].SetAllDirty();
				this.text_ItemKingdom[ItemIdx].cachedTextGenerator.Invalidate();
				this.text_ItemKingdom[ItemIdx].cachedTextGeneratorForLayout.Invalidate();
			}
			else
			{
				cstring.Append(this.tmpCR.Recon.SrcName);
				GameConstants.FormatRoleName(this.Cstr_ItemNameKXY[ItemIdx], cstring, null, null, 0, 0, null, null, null, null);
			}
			this.text_ItemName[ItemIdx].text = this.Cstr_ItemNameKXY[ItemIdx].ToString();
			this.text_ItemNameKXY[ItemIdx].text = this.Cstr_ItemNameKXY[ItemIdx].ToString();
			this.text_ItemNameKXY[ItemIdx].SetAllDirty();
			this.text_ItemNameKXY[ItemIdx].cachedTextGenerator.Invalidate();
			this.text_ItemNameKXY[ItemIdx].cachedTextGeneratorForLayout.Invalidate();
			this.BtnNameKXY_ItemRT[ItemIdx].sizeDelta = new Vector2(this.text_ItemNameKXY[ItemIdx].preferredWidth + 1f, this.BtnNameKXY_ItemRT[ItemIdx].sizeDelta.y);
			this.Img_NameKXY[ItemIdx].rectTransform.sizeDelta = new Vector2(this.text_ItemNameKXY[ItemIdx].preferredWidth + 1f, this.Img_NameKXY[ItemIdx].rectTransform.sizeDelta.y);
			this.text_ItemNameKXY[ItemIdx].rectTransform.sizeDelta = new Vector2(this.text_ItemNameKXY[ItemIdx].preferredWidth + 1f, this.text_ItemNameKXY[ItemIdx].rectTransform.sizeDelta.y);
			if (this.text_ItemKingdom[ItemIdx].gameObject.activeSelf)
			{
				this.text_ItemKingdom[ItemIdx].rectTransform.sizeDelta = new Vector2(this.text_ItemKingdom[ItemIdx].preferredWidth, this.text_ItemKingdom[ItemIdx].rectTransform.sizeDelta.y);
				this.BtnNameKXY_ItemRT[ItemIdx].anchoredPosition = new Vector2(-321f + (this.text_ItemNameKXY[ItemIdx].rectTransform.sizeDelta.x / 2f + this.text_ItemKingdom[ItemIdx].preferredWidth + 2f), this.BtnNameKXY_ItemRT[ItemIdx].anchoredPosition.y);
				this.text_ItemName[ItemIdx].rectTransform.anchoredPosition = new Vector2(this.text_ItemKingdom[ItemIdx].rectTransform.anchoredPosition.x + this.text_ItemKingdom[ItemIdx].preferredWidth + 3f, this.text_ItemName[ItemIdx].rectTransform.anchoredPosition.y);
			}
			else
			{
				this.BtnNameKXY_ItemRT[ItemIdx].anchoredPosition = new Vector2(-321f + this.text_ItemNameKXY[ItemIdx].rectTransform.sizeDelta.x / 2f, this.BtnNameKXY_ItemRT[ItemIdx].anchoredPosition.y);
				this.text_ItemName[ItemIdx].rectTransform.anchoredPosition = new Vector2(76f, this.text_ItemName[ItemIdx].rectTransform.anchoredPosition.y);
			}
		}
		else
		{
			this.text_ItemName[ItemIdx].text = this.DM.mStringTable.GetStringByID(12072u);
			this.text_ItemName[ItemIdx].rectTransform.anchoredPosition = new Vector2(76f, this.text_ItemName[ItemIdx].rectTransform.anchoredPosition.y);
		}
		this.text_ItemName[ItemIdx].SetAllDirty();
		this.text_ItemName[ItemIdx].cachedTextGenerator.Invalidate();
		this.text_ItemName[ItemIdx].cachedTextGeneratorForLayout.Invalidate();
		this.text_ItemName[ItemIdx].rectTransform.sizeDelta = new Vector2(this.text_ItemName[ItemIdx].preferredWidth + 1f, this.text_ItemName[ItemIdx].rectTransform.sizeDelta.y);
		if (this.GUIM.IsArabic)
		{
			this.text_ItemName[ItemIdx].UpdateArabicPos();
		}
		if (this.mWatchLv >= 15 && this.tmpCR.Recon.SrcHead != 0)
		{
			this.Img_Hero[ItemIdx].gameObject.SetActive(true);
			this.Img_NoHero[ItemIdx].gameObject.SetActive(false);
			this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.tmpCR.Recon.SrcHead);
			this.Img_HeroHead[ItemIdx].sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
		}
		else
		{
			this.Img_Hero[ItemIdx].gameObject.SetActive(false);
			this.Img_NoHero[ItemIdx].gameObject.SetActive(true);
		}
		this.btn_Hero_Porfile[ItemIdx].m_BtnID2 = this.mReconMax - Idx;
		this.btn_NameKXY[ItemIdx].m_BtnID2 = this.mReconMax - Idx;
		if (this.mWatchLv < 15)
		{
			this.text_ItemLv[ItemIdx].gameObject.SetActive(true);
			this.text_ItemName[ItemIdx].gameObject.SetActive(true);
			this.btn_NameKXY[ItemIdx].gameObject.SetActive(false);
		}
		else
		{
			this.text_ItemLv[ItemIdx].gameObject.SetActive(false);
			this.btn_NameKXY[ItemIdx].gameObject.SetActive(true);
			this.text_ItemName[ItemIdx].gameObject.SetActive(false);
		}
		if (this.tmpCR.Recon.AntiScout == 1)
		{
			this.mStatus = 4;
		}
		else if (this.tmpCR.Recon.CombatPointKind == POINT_KIND.PK_CITY && this.tmpCR.Recon.bAmbush == 0)
		{
			this.mStatus = 2;
		}
		else
		{
			this.mStatus = 3;
		}
		this.btn_KXY[ItemIdx].gameObject.SetActive(false);
		this.btn_KXY[ItemIdx].m_BtnID2 = this.mReconMax - Idx;
		this.Cstr_ItemInfo[ItemIdx].ClearString();
		switch (this.mStatus)
		{
		case 2:
			this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.tmpCR.Recon.CombatlZone, this.tmpCR.Recon.CombatPoint));
			this.Cstr_ItemInfo[ItemIdx].StringToFormat(this.GUIM.GetPointName_Letter(this.tmpCR.Recon.CombatPointKind));
			this.Cstr_ItemInfo[ItemIdx].AppendFormat(this.DM.mStringTable.GetStringByID(5355u));
			break;
		case 3:
			if (this.tmpCR.Recon.bAmbush == 1)
			{
				this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.tmpCR.Recon.CombatlZone, this.tmpCR.Recon.CombatPoint));
				this.Cstr_ItemInfo[ItemIdx].Append(this.DM.mStringTable.GetStringByID(9748u));
			}
			else if (this.tmpCR.Recon.CombatPointKind == POINT_KIND.PK_YOLK)
			{
				this.tmpV = DataManager.MapDataController.GetYolkPos((ushort)this.tmpCR.Recon.CombatPoint, this.tmpCR.Recon.KingdomID);
				this.Cstr_ItemInfo[ItemIdx].StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.tmpCR.Recon.CombatPoint, this.tmpCR.Recon.KingdomID));
				this.Cstr_ItemInfo[ItemIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7263u));
			}
			else
			{
				this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.tmpCR.Recon.CombatlZone, this.tmpCR.Recon.CombatPoint));
				this.Cstr_ItemInfo[ItemIdx].StringToFormat(this.GUIM.GetPointName_Letter(this.tmpCR.Recon.CombatPointKind));
				this.Cstr_ItemInfo[ItemIdx].AppendFormat(this.DM.mStringTable.GetStringByID(5355u));
			}
			break;
		case 4:
			this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.tmpCR.Recon.CombatlZone, this.tmpCR.Recon.CombatPoint));
			if (this.tmpCR.Recon.bAmbush == 1)
			{
				this.Cstr_ItemInfo[ItemIdx].Append(this.DM.mStringTable.GetStringByID(9748u));
			}
			this.Cstr_ItemInfo[ItemIdx].StringToFormat(this.GUIM.GetPointName_Letter(this.tmpCR.Recon.CombatPointKind));
			this.Cstr_ItemInfo[ItemIdx].AppendFormat(this.DM.mStringTable.GetStringByID(12077u));
			break;
		}
		this.text_ItemInfo[ItemIdx].text = this.Cstr_ItemInfo[ItemIdx].ToString();
		this.text_ItemInfo[ItemIdx].SetAllDirty();
		this.text_ItemInfo[ItemIdx].cachedTextGenerator.Invalidate();
		this.text_ItemInfo[ItemIdx].cachedTextGeneratorForLayout.Invalidate();
		this.Cstr_ItemKXY[ItemIdx].ClearString();
		this.Cstr_ItemKXY[ItemIdx].IntToFormat((long)this.tmpCR.Recon.KingdomID, 1, false);
		this.Cstr_ItemKXY[ItemIdx].IntToFormat((long)((int)this.tmpV.x), 1, false);
		this.Cstr_ItemKXY[ItemIdx].IntToFormat((long)((int)this.tmpV.y), 1, false);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_ItemKXY[ItemIdx].AppendFormat("{2}:Y {1}:X {0}:K");
		}
		else
		{
			this.Cstr_ItemKXY[ItemIdx].AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
		}
		this.text_ItemKXY[ItemIdx].text = this.Cstr_ItemKXY[ItemIdx].ToString();
		this.text_ItemKXY[ItemIdx].SetAllDirty();
		this.text_ItemKXY[ItemIdx].cachedTextGenerator.Invalidate();
		this.text_ItemKXY[ItemIdx].cachedTextGeneratorForLayout.Invalidate();
		this.btn_KXY[ItemIdx].gameObject.SetActive(true);
		this.BtnKXY_ItemRT[ItemIdx].sizeDelta = new Vector2(this.text_ItemKXY[ItemIdx].preferredWidth + 1f, this.BtnKXY_ItemRT[ItemIdx].sizeDelta.y);
		this.Img_KXY[ItemIdx].rectTransform.sizeDelta = new Vector2(this.text_ItemKXY[ItemIdx].preferredWidth + 1f, this.Img_KXY[ItemIdx].rectTransform.sizeDelta.y);
		this.text_ItemKXY[ItemIdx].rectTransform.sizeDelta = new Vector2(this.text_ItemKXY[ItemIdx].preferredWidth + 1f, this.text_ItemKXY[ItemIdx].rectTransform.sizeDelta.y);
	}

	// Token: 0x06001DBE RID: 7614 RVA: 0x003775E0 File Offset: 0x003757E0
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001DBF RID: 7615 RVA: 0x003775E4 File Offset: 0x003757E4
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.tmplist.Clear();
			this.mReconMax = this.DM.GetMailboxReconSize();
			for (int i = 0; i < this.mReconMax + 1; i++)
			{
				this.tmplist.Add(101f);
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
		}
	}

	// Token: 0x06001DC0 RID: 7616 RVA: 0x0037765C File Offset: 0x0037585C
	public override void UpdateTime(bool bOnSecond)
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

	// Token: 0x06001DC1 RID: 7617 RVA: 0x0037778C File Offset: 0x0037598C
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Mailing)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else
			{
				if (meg[1] == 1 && meg[2] == 3)
				{
					this.Favor.Serial = this.DM.GetMailboxReportSerial(ReportSubSet.REPORTSet_RECON);
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
					this.Cstr_Title.ClearString();
					if (this.Report.Recon.bAmbush == 1)
					{
						this.Cstr_Title.Append(this.DM.mStringTable.GetStringByID(9748u));
					}
					else if (this.Report.Recon.CombatPointKind == POINT_KIND.PK_YOLK)
					{
						this.Cstr_Title.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Recon.CombatPoint, this.Report.Recon.KingdomID));
						this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(7263u));
					}
					else
					{
						this.Cstr_Title.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Recon.CombatPointKind));
						this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(5355u));
					}
					this.text_TitleName.text = this.Cstr_Title.ToString();
					this.text_TitleName.SetAllDirty();
					this.text_TitleName.cachedTextGenerator.Invalidate();
					this.tmplist.Clear();
					this.tmplist.Add(101f);
					this.mReconMax = this.DM.GetMailboxReconSize();
					for (int i = 0; i < this.mReconMax; i++)
					{
						this.tmplist.Add(101f);
						this.tmpCR = this.DM.ReconReportGet(this.mReconMax - (1 + i));
						if (this.tmpCR != null && !this.tmpCR.BeRead)
						{
							this.UnReadNum++;
						}
					}
					this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
				}
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
				this.text_Page.SetAllDirty();
				this.text_Page.cachedTextGenerator.Invalidate();
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
			}
		}
	}

	// Token: 0x06001DC2 RID: 7618 RVA: 0x00377C90 File Offset: 0x00375E90
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
			if (this.text_ItemInfo[j] != null && this.text_ItemInfo[j].enabled)
			{
				this.text_ItemInfo[j].enabled = false;
				this.text_ItemInfo[j].enabled = true;
			}
			if (this.text_ItemKXY[j] != null && this.text_ItemKXY[j].enabled)
			{
				this.text_ItemKXY[j].enabled = false;
				this.text_ItemKXY[j].enabled = true;
			}
			if (this.text_ItemNew[j] != null && this.text_ItemNew[j].enabled)
			{
				this.text_ItemNew[j].enabled = false;
				this.text_ItemNew[j].enabled = true;
			}
			if (this.text_ItemNameKXY[j] != null && this.text_ItemNameKXY[j].enabled)
			{
				this.text_ItemNameKXY[j].enabled = false;
				this.text_ItemNameKXY[j].enabled = true;
			}
			if (this.text_ItemName[j] != null && this.text_ItemName[j].enabled)
			{
				this.text_ItemName[j].enabled = false;
				this.text_ItemName[j].enabled = true;
			}
			if (this.text_ItemKingdom[j] != null && this.text_ItemKingdom[j].enabled)
			{
				this.text_ItemKingdom[j].enabled = false;
				this.text_ItemKingdom[j].enabled = true;
			}
			if (this.text_ItemRecon[j] != null && this.text_ItemRecon[j].enabled)
			{
				this.text_ItemRecon[j].enabled = false;
				this.text_ItemRecon[j].enabled = true;
			}
			if (this.text_ItemLv[j] != null && this.text_ItemLv[j].enabled)
			{
				this.text_ItemLv[j].enabled = false;
				this.text_ItemLv[j].enabled = true;
			}
		}
	}

	// Token: 0x04005C0B RID: 23563
	private DataManager DM;

	// Token: 0x04005C0C RID: 23564
	private GUIManager GUIM;

	// Token: 0x04005C0D RID: 23565
	private Font TTFont;

	// Token: 0x04005C0E RID: 23566
	private Door door;

	// Token: 0x04005C0F RID: 23567
	private Transform GameT;

	// Token: 0x04005C10 RID: 23568
	private Transform Tmp;

	// Token: 0x04005C11 RID: 23569
	private Transform Tmp1;

	// Token: 0x04005C12 RID: 23570
	private Transform Tmp2;

	// Token: 0x04005C13 RID: 23571
	private Transform PreviousT;

	// Token: 0x04005C14 RID: 23572
	private Transform NextT;

	// Token: 0x04005C15 RID: 23573
	private Transform[] ItemT = new Transform[6];

	// Token: 0x04005C16 RID: 23574
	private Transform[] Itme_PT1 = new Transform[6];

	// Token: 0x04005C17 RID: 23575
	private Transform[] Itme_PT2 = new Transform[6];

	// Token: 0x04005C18 RID: 23576
	private RectTransform tmpRCT;

	// Token: 0x04005C19 RID: 23577
	private RectTransform[] BtnKXY_ItemRT = new RectTransform[6];

	// Token: 0x04005C1A RID: 23578
	private RectTransform[] BtnNameKXY_ItemRT = new RectTransform[6];

	// Token: 0x04005C1B RID: 23579
	private UIButton btn_EXIT;

	// Token: 0x04005C1C RID: 23580
	private UIButton btn_Delete;

	// Token: 0x04005C1D RID: 23581
	private UIButton btn_Previous;

	// Token: 0x04005C1E RID: 23582
	private UIButton btn_Next;

	// Token: 0x04005C1F RID: 23583
	private UIButton[] btn_KXY = new UIButton[6];

	// Token: 0x04005C20 RID: 23584
	private UIButton[] btn_NameKXY = new UIButton[6];

	// Token: 0x04005C21 RID: 23585
	private UIButton[] btn_Hero_Porfile = new UIButton[6];

	// Token: 0x04005C22 RID: 23586
	private Image tmpImg;

	// Token: 0x04005C23 RID: 23587
	private Image[] Img_Hero = new Image[6];

	// Token: 0x04005C24 RID: 23588
	private Image[] Img_HeroHead = new Image[6];

	// Token: 0x04005C25 RID: 23589
	private Image[] Img_NoHero = new Image[6];

	// Token: 0x04005C26 RID: 23590
	private Image[] Img_KXY = new Image[6];

	// Token: 0x04005C27 RID: 23591
	private Image[] Img_NameKXY = new Image[6];

	// Token: 0x04005C28 RID: 23592
	private Image[] Img_New = new Image[6];

	// Token: 0x04005C29 RID: 23593
	private UIText text_TitleName;

	// Token: 0x04005C2A RID: 23594
	private UIText text_Page;

	// Token: 0x04005C2B RID: 23595
	private UIText text_LastTitle;

	// Token: 0x04005C2C RID: 23596
	private UIText[] text_Time = new UIText[2];

	// Token: 0x04005C2D RID: 23597
	private UIText[] text_ItemTitle = new UIText[6];

	// Token: 0x04005C2E RID: 23598
	private UIText[] text_ItemTime = new UIText[6];

	// Token: 0x04005C2F RID: 23599
	private UIText[] text_ItemInfo = new UIText[6];

	// Token: 0x04005C30 RID: 23600
	private UIText[] text_ItemKXY = new UIText[6];

	// Token: 0x04005C31 RID: 23601
	private UIText[] text_ItemNew = new UIText[6];

	// Token: 0x04005C32 RID: 23602
	private UIText[] text_ItemNameKXY = new UIText[6];

	// Token: 0x04005C33 RID: 23603
	private UIText[] text_ItemName = new UIText[6];

	// Token: 0x04005C34 RID: 23604
	private UIText[] text_ItemKingdom = new UIText[6];

	// Token: 0x04005C35 RID: 23605
	private UIText[] text_ItemRecon = new UIText[6];

	// Token: 0x04005C36 RID: 23606
	private UIText[] text_ItemLv = new UIText[6];

	// Token: 0x04005C37 RID: 23607
	private CString Cstr_Title;

	// Token: 0x04005C38 RID: 23608
	private CString Cstr_Page;

	// Token: 0x04005C39 RID: 23609
	private CString[] Cstr_ItemTitle = new CString[6];

	// Token: 0x04005C3A RID: 23610
	private CString[] Cstr_ItemInfo = new CString[6];

	// Token: 0x04005C3B RID: 23611
	private CString[] Cstr_ItemKXY = new CString[6];

	// Token: 0x04005C3C RID: 23612
	private CString[] Cstr_ItemNameKXY = new CString[6];

	// Token: 0x04005C3D RID: 23613
	private CString[] Cstr_ItemKingdom = new CString[6];

	// Token: 0x04005C3E RID: 23614
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04005C3F RID: 23615
	private ScrollPanelItem[] mScrollItem = new ScrollPanelItem[6];

	// Token: 0x04005C40 RID: 23616
	private Material mMaT;

	// Token: 0x04005C41 RID: 23617
	private Material IconMaterial;

	// Token: 0x04005C42 RID: 23618
	private Material FrameMaterial;

	// Token: 0x04005C43 RID: 23619
	private CombatReport Report;

	// Token: 0x04005C44 RID: 23620
	private CombatReport tmpCR;

	// Token: 0x04005C45 RID: 23621
	private MyFavorite Favor = new MyFavorite(MailType.EMAIL_MAX, 0u);

	// Token: 0x04005C46 RID: 23622
	private float tempL;

	// Token: 0x04005C47 RID: 23623
	private float MoveTime1;

	// Token: 0x04005C48 RID: 23624
	private float MoveTime2;

	// Token: 0x04005C49 RID: 23625
	private float TmpTime;

	// Token: 0x04005C4A RID: 23626
	private float ShowMainHeroTime1;

	// Token: 0x04005C4B RID: 23627
	private int MaxLetterNum;

	// Token: 0x04005C4C RID: 23628
	private int mReconMax;

	// Token: 0x04005C4D RID: 23629
	private int UnReadNum;

	// Token: 0x04005C4E RID: 23630
	private int mWatchLv;

	// Token: 0x04005C4F RID: 23631
	private int mStatus;

	// Token: 0x04005C50 RID: 23632
	private Vector3 Vec3Instance;

	// Token: 0x04005C51 RID: 23633
	private Vector2 tmpV;

	// Token: 0x04005C52 RID: 23634
	private Hero tmpHero;

	// Token: 0x04005C53 RID: 23635
	private List<float> tmplist = new List<float>();
}
