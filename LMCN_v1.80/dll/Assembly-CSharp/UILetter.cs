using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005C9 RID: 1481
public class UILetter : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001D4B RID: 7499 RVA: 0x00348948 File Offset: 0x00346B48
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		if (IGGGameSDK.Instance.GetTranslateStatus() && this.DM.MySysSetting.bAutoTranslate)
		{
			this.bTrans = true;
		}
		this.m_Mat = this.door.LoadMaterial();
		for (int i = 0; i < 6; i++)
		{
			this.Cstr_PluralTotal[i] = StringManager.Instance.SpawnString(30);
			this.Cstrtext_1[i] = StringManager.Instance.SpawnString(30);
			this.Cstrtext_2[i] = StringManager.Instance.SpawnString(30);
			this.Cstrtext_3[i] = StringManager.Instance.SpawnString(1024);
		}
		this.AllSelect = 0;
		if (this.GUIM.BattleSerialNo > 0u)
		{
			this.BattleReport.Serial = (this.DM.OpenMail.Serial = this.GUIM.BattleSerialNo);
			this.BattleReport.Type = (this.BattleReport.Kind = MailType.EMAIL_BATTLE);
			this.DM.Letter_Y = -1f;
			this.Pending = true;
			this.NowPage = 1;
		}
		else
		{
			this.NowPage = (int)this.DM.OpenMail.Kind;
		}
		this.DM.Outlooking = true;
		this.DM.bNoPlural = false;
		this.DM.MIB.Flag = 1;
		this.tmpPage[0] = 3;
		this.tmpPage[1] = 1;
		this.tmpPage[2] = 0;
		this.tmpPage[3] = 2;
		for (int j = 0; j < 4; j++)
		{
			this.Str_HeroColor[j] = this.DM.mStringTable.GetStringByID((uint)((ushort)(7651 + j)));
		}
		this.Title = this.GameT.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.Title.font = this.TTFont;
		this.Title.text = this.DM.mStringTable.GetStringByID((uint)((ushort)(this.tmpPage[this.NowPage] + 5391)));
		for (int k = 0; k < 4; k++)
		{
			this.btn_Page[k] = this.GameT.GetChild(1 + k).GetComponent<UIButton>();
			this.btn_Page[k].m_Handler = this;
			this.btn_Page[k].m_BtnID1 = 9 + k;
			this.Img_PageShow[k] = this.GameT.GetChild(1 + k).GetChild(0).GetComponent<Image>();
			this.Img_PageIcon[k] = this.GameT.GetChild(1 + k).GetChild(1).GetComponent<Image>();
			this.Img_PageIcon[k].sprite = this.SArray.m_Sprites[k * 2 + 1];
			this.Img_PageUnRead[k] = this.GameT.GetChild(1 + k).GetChild(2).GetComponent<Image>();
			this.Img_PageUnRead[k].sprite = this.door.LoadSprite("UI_main_redbox_01");
			this.Img_PageUnRead[k].material = this.door.LoadMaterial();
			this.PageImg_RT[k] = this.GameT.GetChild(1 + k).GetChild(2).GetComponent<RectTransform>();
			this.text_UnRead[k] = this.GameT.GetChild(1 + k).GetChild(2).GetChild(0).GetComponent<UIText>();
			this.PageText_RT[k] = this.GameT.GetChild(1 + k).GetChild(2).GetChild(0).GetComponent<RectTransform>();
			this.text_UnRead[k].font = this.TTFont;
		}
		this.UpdataUnRead();
		this.btn_Select = this.GameT.GetChild(5).GetComponent<UIButton>();
		this.btn_Select.m_Handler = this;
		this.btn_Select.m_BtnID1 = 1;
		this.btn_Select.m_EffectType = e_EffectType.e_Scale;
		this.btn_Select.transition = Selectable.Transition.None;
		if (this.GUIM.IsArabic)
		{
			this.btn_Select.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_WL = this.GameT.GetChild(6).GetComponent<UIButton>();
		this.btn_WL.m_Handler = this;
		this.btn_WL.m_BtnID1 = 2;
		this.btn_WL.m_EffectType = e_EffectType.e_Scale;
		this.btn_WL.transition = Selectable.Transition.None;
		this.ImgEditor = this.GameT.GetChild(6).GetChild(0).GetComponent<Image>();
		this.Tmp = this.GameT.GetChild(7);
		this.m_ScrollPanel = this.Tmp.GetChild(0).GetComponent<ScrollPanel>();
		this.Tmp1 = this.Tmp.GetChild(1);
		this.tmpbtn = this.Tmp1.GetChild(1).GetComponent<UIButton>();
		this.tmpbtn.m_Handler = this;
		this.tmpbtn.m_BtnID1 = 3;
		this.tmpbtn.SoundIndex = 64;
		this.tmpbtn = this.Tmp1.GetChild(2).GetComponent<UIButton>();
		this.tmpbtn.m_Handler = this;
		this.tmpImg = this.Tmp1.GetChild(3).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.tmpImg.transform.localScale = new Vector3(-1f, this.tmpImg.transform.localScale.y, this.tmpImg.transform.localScale.z);
		}
		this.tmpbtn.m_BtnID1 = 4;
		this.tmpbtn.SoundIndex = 64;
		this.tmpbtn = this.Tmp1.GetChild(8).GetComponent<UIButton>();
		this.tmpbtn.m_Handler = this;
		this.tmpbtn.m_BtnID1 = 5;
		this.tmpbtn.SoundIndex = 64;
		this.tmpImg = this.Tmp1.GetChild(9).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_redbox_01");
		this.tmpImg.material = this.door.LoadMaterial();
		this.tmptext = this.Tmp1.GetChild(9).GetChild(0).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext = this.Tmp1.GetChild(11).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext = this.Tmp1.GetChild(12).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext = this.Tmp1.GetChild(13).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext.SetCheckArabic(true);
		this.tmptext = this.Tmp1.GetChild(14).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext.SetCheckArabic(true);
		this.tmptext = this.Tmp1.GetChild(15).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmpImg = this.Tmp1.GetChild(16).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.tmpImg.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.tmplist.Clear();
		this.Datalist.Clear();
		this.btmpList.Clear();
		this.bReadList.Clear();
		this.m_ScrollPanel.IntiScrollPanel(501f, 0f, 0f, this.tmplist, 6, this);
		this.tmpcontentRcT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
		this.ImgFunction = this.GameT.GetChild(8).GetComponent<Image>();
		this.btn_Delete = this.GameT.GetChild(8).GetChild(0).GetComponent<UIButton>();
		this.btn_Delete.m_Handler = this;
		this.btn_Delete.m_BtnID1 = 6;
		this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
		this.btn_Delete.transition = Selectable.Transition.None;
		this.btn_Read = this.GameT.GetChild(8).GetChild(1).GetComponent<UIButton>();
		this.btn_Read.m_Handler = this;
		this.btn_Read.m_BtnID1 = 7;
		this.btn_Read.m_EffectType = e_EffectType.e_Scale;
		this.btn_Read.transition = Selectable.Transition.None;
		this.btn_Cancel = this.GameT.GetChild(8).GetChild(2).GetComponent<UIButton>();
		this.btn_Cancel.m_Handler = this;
		this.btn_Cancel.m_BtnID1 = 8;
		this.btn_Cancel.m_EffectType = e_EffectType.e_Scale;
		this.btn_Cancel.transition = Selectable.Transition.None;
		this.ImgNoLetter = this.GameT.GetChild(9).GetComponent<Image>();
		this.NoLetterMsg = this.GameT.GetChild(9).GetChild(0).GetComponent<UIText>();
		this.NoLetterMsg.font = this.TTFont;
		this.NoLetterMsg.text = this.DM.mStringTable.GetStringByID(6016u);
		this.tmpImg = this.GameT.GetChild(10).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
		this.tmpImg.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(10).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.m_Mat;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		if (this.DM.bPlural)
		{
			this.NowPageKind = 1;
			this.mPluralReplyID = this.DM.Letter_PluralReplyID;
			this.mPluralSenderName = this.DM.Letter_PluralSenderName;
			if (this.DM.GetMailboxSize(this.mPluralReplyID, this.mPluralSenderName) == 1)
			{
				this.DM.bPlural = false;
				this.NowPageKind = 0;
			}
		}
		this.SetPageData();
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001D4C RID: 7500 RVA: 0x0034944C File Offset: 0x0034764C
	public void UpdataUnRead()
	{
		for (int i = 0; i < 4; i++)
		{
			int mailboxUnread = (int)this.DM.GetMailboxUnread((MailType)i);
			if (mailboxUnread != 0)
			{
				this.Img_PageUnRead[i].gameObject.SetActive(true);
			}
			else
			{
				this.Img_PageUnRead[i].gameObject.SetActive(false);
			}
			this.text_UnRead[i].text = mailboxUnread.ToString();
			this.PageImg_RT[i].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_UnRead[i].preferredWidth), this.PageImg_RT[i].sizeDelta.y);
		}
	}

	// Token: 0x06001D4D RID: 7501 RVA: 0x003494FC File Offset: 0x003476FC
	public override void OnClose()
	{
		this.DM.Outlooking = false;
		this.SetAllSelect(false, false);
		if (this.Pending)
		{
			this.GUIM.BattleSerialNo = 0u;
		}
		else if (this.NowPageKind == 0)
		{
			this.DM.Letter_Y = this.tmpcontentRcT.anchoredPosition.y;
			this.DM.Letter_Idx = this.m_ScrollPanel.GetTopIdx();
		}
		else
		{
			this.DM.Letter_PluralY = this.tmpcontentRcT.anchoredPosition.y;
			this.DM.Letter_PluralIdx = this.m_ScrollPanel.GetTopIdx();
		}
		for (int i = 0; i < 6; i++)
		{
			if (this.Cstr_PluralTotal[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_PluralTotal[i]);
			}
			if (this.Cstrtext_1[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstrtext_1[i]);
			}
			if (this.Cstrtext_2[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstrtext_2[i]);
			}
			if (this.Cstrtext_3[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstrtext_3[i]);
			}
		}
	}

	// Token: 0x06001D4E RID: 7502 RVA: 0x00349644 File Offset: 0x00347844
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			this.CloseSelf();
			break;
		case 1:
			this.SetAllSelect(true, true);
			break;
		case 2:
			this.SetAllSelect(false, true);
			if (this.NowPageKind == 1)
			{
				this.DM.bPlural = true;
				this.DM.Letter_PluralReplyID = this.mPluralReplyID;
				this.DM.Letter_PluralSenderName = this.mPluralSenderName;
			}
			this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 0, 0, false);
			break;
		case 3:
			if (!this.bOpenImg)
			{
				if (this.NowPageKind != 1)
				{
					this.DM.Letter_Y = this.tmpcontentRcT.anchoredPosition.y;
					this.DM.Letter_Idx = this.m_ScrollPanel.GetTopIdx();
				}
				Transform parent = sender.gameObject.transform.parent;
				if (this.NowPage == 2)
				{
					MailContent mailContent;
					if (this.NowPageKind == 0)
					{
						mailContent = this.DM.MailReportGet(parent.GetComponent<ScrollPanelItem>().m_BtnID1);
					}
					else
					{
						mailContent = this.DM.MailReportGet(parent.GetComponent<ScrollPanelItem>().m_BtnID1, this.mPluralReplyID, this.mPluralSenderName);
						this.DM.bPlural = true;
						this.DM.Letter_PluralReplyID = this.mPluralReplyID;
						this.DM.Letter_PluralSenderName = this.mPluralSenderName;
					}
					if (this.text_PluralTotal[parent.GetComponent<ScrollPanelItem>().m_BtnID2].IsActive())
					{
						this.NowPageKind = 1;
						if (mailContent != null)
						{
							this.mPluralTotal = (int)mailContent.More;
							this.mPluralReplyID = mailContent.ReplyID;
							this.mPluralSenderName = mailContent.SenderName;
						}
						this.SetPageData();
					}
					else if (mailContent != null)
					{
						this.DM.OpenMail.Serial = mailContent.SerialID;
						this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
					}
				}
				else if (this.NowPage == 1)
				{
					CombatReport combatReport = this.DM.CombatReportGet(parent.GetComponent<ScrollPanelItem>().m_BtnID1);
					if (combatReport != null)
					{
						this.DM.OpenMail.Serial = combatReport.SerialID;
						switch (combatReport.Type)
						{
						case CombatCollectReport.CCR_BATTLE:
						case CombatCollectReport.CCR_NPCCOMBAT:
							this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 0, 0, false);
							break;
						case CombatCollectReport.CCR_RESOURCE:
							this.door.OpenMenu(EGUIWindow.UI_Letter_Resources, 0, 0, false);
							break;
						case CombatCollectReport.CCR_COLLECT:
							this.door.OpenMenu(EGUIWindow.UI_Letter_Collection, 0, 0, false);
							break;
						case CombatCollectReport.CCR_SCOUT:
							if (combatReport.Scout.ScoutLevel != 0)
							{
								this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 0, 0, false);
							}
							else
							{
								this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 1, 0, false);
							}
							break;
						case CombatCollectReport.CCR_RECON:
							this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon, 0, 0, false);
							break;
						case CombatCollectReport.CCR_MONSTER:
							if (combatReport.Monster.Result < 2 || combatReport.Monster.Result > 3)
							{
								this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 1, 0, false);
							}
							else
							{
								this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
							}
							break;
						case CombatCollectReport.CCR_NPCSCOUT:
							if (combatReport.NPCScout.ScoutLevel != 0)
							{
								this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout, 0, 0, false);
							}
							else
							{
								this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout, 1, 0, false);
							}
							break;
						case CombatCollectReport.CCR_PETREPORT:
							this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS, 0, 0, false);
							break;
						}
					}
				}
				else if (this.NowPage == 3)
				{
					MyFavorite myFavorite = this.DM.FavorReportGet(parent.GetComponent<ScrollPanelItem>().m_BtnID1);
					if (myFavorite != null)
					{
						switch (myFavorite.Type)
						{
						case MailType.EMAIL_SYSTEM:
							this.DM.OpenMail.Type = myFavorite.Type;
							this.DM.OpenMail.Serial = myFavorite.System.SerialID;
							this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
							break;
						case MailType.EMAIL_BATTLE:
							this.DM.OpenMail.Type = myFavorite.Type;
							this.DM.OpenMail.Serial = myFavorite.Combat.SerialID;
							switch (myFavorite.Combat.Type)
							{
							case CombatCollectReport.CCR_BATTLE:
							case CombatCollectReport.CCR_NPCCOMBAT:
								this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 0, 0, false);
								break;
							case CombatCollectReport.CCR_SCOUT:
								if (myFavorite.Combat.Scout.ScoutLevel != 0)
								{
									this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 0, 0, false);
								}
								else
								{
									this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 1, 0, false);
								}
								break;
							case CombatCollectReport.CCR_RECON:
								this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon, 0, 0, false);
								break;
							case CombatCollectReport.CCR_MONSTER:
								if (myFavorite.Combat.Monster.Result < 2 || myFavorite.Combat.Monster.Result > 3)
								{
									this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 1, 0, false);
								}
								else
								{
									this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
								}
								break;
							case CombatCollectReport.CCR_NPCSCOUT:
								if (myFavorite.Combat.NPCScout.ScoutLevel != 0)
								{
									this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout, 0, 0, false);
								}
								else
								{
									this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout, 1, 0, false);
								}
								break;
							case CombatCollectReport.CCR_PETREPORT:
								this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS, 0, 0, false);
								break;
							}
							break;
						case MailType.EMAIL_LETTER:
							this.DM.OpenMail.Type = myFavorite.Type;
							this.DM.OpenMail.Serial = myFavorite.Mail.SerialID;
							this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
							break;
						}
					}
				}
				else if (this.NowPage == 0)
				{
					NoticeContent noticeContent = this.DM.SystemReportGet(parent.GetComponent<ScrollPanelItem>().m_BtnID1);
					if (noticeContent != null)
					{
						this.DM.OpenMail.Type = MailType.EMAIL_SYSTEM;
						this.DM.OpenMail.Serial = noticeContent.SerialID;
						this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
					}
				}
			}
			else
			{
				this.CheckSelect(sender);
			}
			break;
		case 4:
			this.CheckSelect(sender);
			break;
		case 5:
			if (!this.bOpenImg)
			{
				if (this.NowPage == 3)
				{
					return;
				}
				Transform parent2 = sender.gameObject.transform.parent;
				if (this.NowPage == 2)
				{
					if (this.NowPageKind == 1)
					{
						this.DM.MailReportSave(parent2.GetComponent<ScrollPanelItem>().m_BtnID1, this.mPluralReplyID, this.mPluralSenderName);
					}
					else
					{
						this.DM.MailReportSave(parent2.GetComponent<ScrollPanelItem>().m_BtnID1);
					}
				}
				else if (this.NowPage == 1)
				{
					this.DM.BattleReportSave(parent2.GetComponent<ScrollPanelItem>().m_BtnID1);
				}
				else if (this.NowPage == 0)
				{
					this.DM.SystemReportSave(parent2.GetComponent<ScrollPanelItem>().m_BtnID1);
				}
				else if (this.btmpList.Count >= parent2.GetComponent<ScrollPanelItem>().m_BtnID1)
				{
					for (int i = parent2.GetComponent<ScrollPanelItem>().m_BtnID1; i < this.Datalist.Count - 1; i++)
					{
						this.Datalist[i] = this.Datalist[i + 1];
					}
					this.btmpList.RemoveAt(this.btmpList.Count - 1);
					this.bReadList.RemoveAt(this.btmpList.Count - 1);
					this.Datalist.RemoveAt(this.Datalist.Count - 1);
					this.tmplist.RemoveAt(this.tmplist.Count - 1);
					this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
				}
			}
			break;
		case 6:
			if (this.NowPage == 2)
			{
				if (this.NowPageKind == 1)
				{
					this.DM.MailReportDelete(0u, this.mPluralReplyID, this.mPluralSenderName);
				}
				else
				{
					this.DM.MailReportDelete(0u);
				}
			}
			else if (this.NowPage == 1)
			{
				this.DM.BattleReportDelete(0u);
			}
			else if (this.NowPage == 3)
			{
				this.DM.FavorReportDelete(0u);
			}
			else if (this.NowPage == 0)
			{
				this.DM.SystemReportDelete(0u);
			}
			this.SetAllSelect(false, true);
			this.ImgFunction.gameObject.SetActive(false);
			break;
		case 7:
			if (this.NowPage == 2)
			{
				if (this.NowPageKind == 1)
				{
					this.DM.MailReportRead(0u, this.mPluralReplyID, this.mPluralSenderName, true);
				}
				else
				{
					this.DM.MailReportRead(0u, true);
				}
			}
			else if (this.NowPage == 1)
			{
				this.DM.BattleReportRead(0u, true);
			}
			else if (this.NowPage == 3)
			{
				this.DM.FavorReportRead(0u, true);
			}
			else if (this.NowPage == 0)
			{
				this.DM.SystemReportRead(0u, true);
			}
			this.SetAllSelect(false, true);
			this.ImgFunction.gameObject.SetActive(false);
			break;
		case 8:
			this.SetAllSelect(false, true);
			this.bOpenImg = false;
			break;
		case 9:
		case 10:
		case 11:
		case 12:
			this.SetAllSelect(false, true);
			if (this.NowPage == sender.m_BtnID1 - 9)
			{
				return;
			}
			this.tmplist.Clear();
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, true, true);
			this.Img_PageShow[this.NowPage].color = new Color(1f, 1f, 1f, 0f);
			this.NowPage = sender.m_BtnID1 - 9;
			this.PageShowTime = 0f;
			this.DM.Letter_Y = -1f;
			this.NowPageKind = 0;
			this.DM.bPlural = false;
			this.SetPageData();
			break;
		}
	}

	// Token: 0x06001D4F RID: 7503 RVA: 0x0034A110 File Offset: 0x00348310
	private void CloseSelf()
	{
		if (this.NowPageKind == 1)
		{
			this.SetAllSelect(false, true);
			this.bOpenImg = false;
			this.NowPageKind = 0;
			this.DM.bPlural = false;
			this.DM.Letter_PluralY = -1f;
			this.DM.Letter_PluralIdx = -1;
			this.SetPageData();
		}
		else if (this.door != null)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001D50 RID: 7504 RVA: 0x0034A190 File Offset: 0x00348390
	public override bool OnBackButtonClick()
	{
		this.CloseSelf();
		return true;
	}

	// Token: 0x06001D51 RID: 7505 RVA: 0x0034A19C File Offset: 0x0034839C
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_Mailbox:
			this.UpdataUnRead();
			break;
		case NetworkNews.Refresh_Mailing:
			if (!this.Pending && this.NowPageKind == 0)
			{
				this.DM.Letter_Y = this.tmpcontentRcT.anchoredPosition.y;
				this.DM.Letter_Idx = this.m_ScrollPanel.GetTopIdx();
			}
			if (this.NowPageKind == 1 && this.DM.GetMailboxSize(this.mPluralReplyID, this.mPluralSenderName) <= 1)
			{
				this.NowPageKind = 0;
			}
			this.SetPageData();
			break;
		case NetworkNews.Refresh_Letter:
			if (this.bTrans)
			{
				if (this.NowPage == 2)
				{
					for (int i = 0; i < 6; i++)
					{
						if (this.tmpItem[i] != null && this.text_2[i] != null && this.text_3[i] != null)
						{
							this.Cstrtext_2[i].ClearString();
							this.Cstrtext_3[i].ClearString();
							MailContent mailContent;
							if (this.NowPageKind == 0)
							{
								mailContent = this.DM.MailReportGet(this.tmpItem[i].m_BtnID1);
							}
							else
							{
								mailContent = this.DM.MailReportGet(this.tmpItem[i].m_BtnID1, this.mPluralReplyID, this.mPluralSenderName);
							}
							if (mailContent != null)
							{
								if (mailContent.MailType == 1)
								{
									this.Cstrtext_2[i].Append(this.DM.mStringTable.GetStringByID(6014u));
								}
								if (mailContent.Translation && mailContent.MailType != 2 && this.DM.CheckLanguageTranslateByIdx((int)mailContent.LanguageSource) && mailContent.LanguageTarget == (byte)this.DM.UserLanguage && this.GUIM.CheckNeedTranslate(mailContent.Title))
								{
									this.Cstrtext_2[i].Append(mailContent.TitleT);
								}
								else
								{
									this.Cstrtext_2[i].Append(mailContent.Title);
								}
								this.text_2[i].text = this.Cstrtext_2[i].ToString();
								this.text_2[i].SetAllDirty();
								this.text_2[i].cachedTextGenerator.Invalidate();
								if (mailContent.Translation && mailContent.MailType != 2 && this.DM.CheckLanguageTranslateByIdx((int)mailContent.LanguageSource) && mailContent.LanguageTarget == (byte)this.DM.UserLanguage)
								{
									this.Cstrtext_3[i].Append(mailContent.ContentT);
								}
								else
								{
									this.Cstrtext_3[i].Append(mailContent.Content);
								}
								this.text_3[i].text = this.Cstrtext_3[i].ToString();
								this.text_3[i].SetAllDirty();
								this.text_3[i].cachedTextGenerator.Invalidate();
							}
						}
					}
				}
				else if (this.NowPage == 3)
				{
					for (int j = 0; j < 6; j++)
					{
						if (this.tmpItem[j] != null && this.text_2[j] != null && this.text_3[j] != null)
						{
							this.Cstrtext_2[j].ClearString();
							this.Cstrtext_3[j].ClearString();
							MyFavorite myFavorite = this.DM.FavorReportGet(this.tmpItem[j].m_BtnID1);
							if (myFavorite != null && myFavorite.Type == MailType.EMAIL_LETTER)
							{
								MailContent mail = myFavorite.Mail;
								if (mail.MailType == 1)
								{
									this.Cstrtext_2[j].Append(this.DM.mStringTable.GetStringByID(6014u));
								}
								if (mail.Translation && mail.MailType != 2 && this.DM.CheckLanguageTranslateByIdx((int)mail.LanguageSource) && mail.LanguageTarget == (byte)this.DM.UserLanguage && this.GUIM.CheckNeedTranslate(mail.Title))
								{
									this.Cstrtext_2[j].Append(mail.TitleT);
								}
								else
								{
									this.Cstrtext_2[j].Append(mail.Title);
								}
								this.text_2[j].text = this.Cstrtext_2[j].ToString();
								this.text_2[j].SetAllDirty();
								this.text_2[j].cachedTextGenerator.Invalidate();
								if (mail.Translation && mail.MailType != 2 && this.DM.CheckLanguageTranslateByIdx((int)mail.LanguageSource) && mail.LanguageTarget == (byte)this.DM.UserLanguage)
								{
									this.Cstrtext_3[j].Append(mail.ContentT);
								}
								else
								{
									this.Cstrtext_3[j].Append(mail.Content);
								}
								this.text_3[j].text = this.Cstrtext_3[j].ToString();
								this.text_3[j].SetAllDirty();
								this.text_3[j].cachedTextGenerator.Invalidate();
							}
						}
					}
				}
			}
			break;
		default:
			if (networkNews != NetworkNews.Login)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else
			{
				this.UpdateMailData();
			}
			break;
		}
	}

	// Token: 0x06001D52 RID: 7506 RVA: 0x0034A73C File Offset: 0x0034893C
	public void Refresh_FontTexture()
	{
		if (this.Title != null && this.Title.enabled)
		{
			this.Title.enabled = false;
			this.Title.enabled = true;
		}
		if (this.NoLetterMsg != null && this.NoLetterMsg.enabled)
		{
			this.NoLetterMsg.enabled = false;
			this.NoLetterMsg.enabled = true;
		}
		for (int i = 0; i < 4; i++)
		{
			if (this.text_UnRead[i] != null && this.text_UnRead[i].enabled)
			{
				this.text_UnRead[i].enabled = false;
				this.text_UnRead[i].enabled = true;
			}
		}
		for (int j = 0; j < 6; j++)
		{
			if (this.text_Time[j] != null && this.text_Time[j].enabled)
			{
				this.text_Time[j].enabled = false;
				this.text_Time[j].enabled = true;
			}
			if (this.text_1[j] != null && this.text_1[j].enabled)
			{
				this.text_1[j].enabled = false;
				this.text_1[j].enabled = true;
			}
			if (this.text_2[j] != null && this.text_2[j].enabled)
			{
				this.text_2[j].enabled = false;
				this.text_2[j].enabled = true;
			}
			if (this.text_3[j] != null && this.text_3[j].enabled)
			{
				this.text_3[j].enabled = false;
				this.text_3[j].enabled = true;
			}
			if (this.text_PluralNoRead[j] != null && this.text_PluralNoRead[j].enabled)
			{
				this.text_PluralNoRead[j].enabled = false;
				this.text_PluralNoRead[j].enabled = true;
			}
			if (this.text_PluralTotal[j] != null && this.text_PluralTotal[j].enabled)
			{
				this.text_PluralTotal[j].enabled = false;
				this.text_PluralTotal[j].enabled = true;
			}
		}
	}

	// Token: 0x06001D53 RID: 7507 RVA: 0x0034A9A8 File Offset: 0x00348BA8
	public bool UpdateMailData()
	{
		switch (this.NowPage)
		{
		case 0:
			this.DM.OpenMail.Kind = (this.DM.OpenMail.Type = (MailType)this.NowPage);
			return this.DM.CheckMail(Protocol._MSG_REQUEST_NOTICEINFO) && this.DM.Mailing.SystemSerial.New == 0u;
		case 1:
			this.DM.OpenMail.Kind = (this.DM.OpenMail.Type = (MailType)this.NowPage);
			return this.DM.CheckMail(Protocol._MSG_REQUEST_REPORTINFO) && this.DM.Mailing.ReportSerial.New == 0u;
		case 2:
			this.DM.OpenMail.Kind = (this.DM.OpenMail.Type = (MailType)this.NowPage);
			return this.DM.CheckMail(Protocol._MSG_REQUEST_MAILINFO) && this.DM.Mailing.MailSerial.New == 0u;
		case 3:
			this.DM.OpenMail.Kind = (MailType)this.NowPage;
			this.DM.Mailing.FavorSerial.Pulling = true;
			this.DM.CheckMail(Protocol._MSG_REQUEST_REPORTINFO);
			this.DM.CheckMail(Protocol._MSG_REQUEST_NOTICEINFO);
			this.DM.CheckMail(Protocol._MSG_REQUEST_MAILINFO);
			break;
		}
		return false;
	}

	// Token: 0x06001D54 RID: 7508 RVA: 0x0034AB50 File Offset: 0x00348D50
	public void SetPageData()
	{
		if (this.UpdateMailData() || this.GUIM.BattleSerialNo > 0u)
		{
			return;
		}
		if (this.NowPage < 4)
		{
			this.Title.text = this.DM.mStringTable.GetStringByID((uint)((ushort)(this.tmpPage[this.NowPage] + 5391)));
		}
		else
		{
			this.Title.text = this.DM.mStringTable.GetStringByID((uint)((ushort)(this.tmpPage[3] + 5391)));
		}
		bool flag = false;
		switch (this.NowPage)
		{
		case 0:
		{
			this.tmplist.Clear();
			this.Datalist.Clear();
			this.btmpList.Clear();
			this.bReadList.Clear();
			this.bCheckList.Clear();
			this.DM.MailDataRefresh((MailType)this.NowPage);
			int num = 0;
			while ((long)num < (long)((ulong)this.DM.Mailing.SystemSerial.Count))
			{
				if (this.ImgFunction.IsActive() && !flag)
				{
					NoticeContent noticeContent = this.DM.SystemReportGet(num);
					if (noticeContent != null && noticeContent.BeChecked)
					{
						flag = true;
					}
				}
				this.tmplist.Add(97f);
				this.Datalist.Add((float)num);
				this.btmpList.Add(false);
				this.bReadList.Add(false);
				num++;
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			if (this.DM.Letter_Y > -1f)
			{
				this.m_ScrollPanel.GoTo(this.DM.Letter_Idx, this.DM.Letter_Y);
			}
			this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_SYSTEM);
			break;
		}
		case 1:
		{
			this.tmplist.Clear();
			this.Datalist.Clear();
			this.btmpList.Clear();
			this.bReadList.Clear();
			this.bCheckList.Clear();
			this.DM.MailDataRefresh((MailType)this.NowPage);
			int num2 = 0;
			while ((long)num2 < (long)((ulong)this.DM.Mailing.ReportSerial.Count))
			{
				if (this.ImgFunction.IsActive() && !flag)
				{
					CombatReport combatReport = this.DM.CombatReportGet(num2);
					if (combatReport != null && combatReport.BeChecked)
					{
						flag = true;
					}
				}
				this.tmplist.Add(97f);
				this.Datalist.Add((float)num2);
				this.btmpList.Add(false);
				this.bReadList.Add(false);
				num2++;
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			if (this.DM.Letter_Y > -1f)
			{
				this.m_ScrollPanel.GoTo(this.DM.Letter_Idx, this.DM.Letter_Y);
			}
			this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_BATTLE);
			break;
		}
		case 2:
			this.tmplist.Clear();
			this.Datalist.Clear();
			this.btmpList.Clear();
			this.bReadList.Clear();
			this.bCheckList.Clear();
			if (this.NowPageKind == 0)
			{
				int num3 = 0;
				while ((long)num3 < (long)((ulong)this.DM.Mailing.MailSerial.Count))
				{
					if (this.ImgFunction.IsActive() && !flag)
					{
						MailContent mailContent = this.DM.MailReportGet(num3);
						if (mailContent != null && mailContent.BeChecked)
						{
							flag = true;
						}
					}
					this.tmplist.Add(97f);
					this.Datalist.Add((float)num3);
					this.btmpList.Add(false);
					this.bReadList.Add(false);
					num3++;
				}
				this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
				if (this.DM.Letter_Y > -1f)
				{
					this.m_ScrollPanel.GoTo(this.DM.Letter_Idx, this.DM.Letter_Y);
				}
				this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_LETTER);
			}
			else
			{
				for (int i = 0; i < this.DM.GetMailboxSize(this.mPluralReplyID, this.mPluralSenderName); i++)
				{
					if (this.ImgFunction.IsActive() && !flag)
					{
						MailContent mailContent = this.DM.MailReportGet(i, this.mPluralReplyID, this.mPluralSenderName);
						if (mailContent != null && mailContent.BeChecked)
						{
							flag = true;
						}
					}
					this.tmplist.Add(97f);
					this.Datalist.Add((float)i);
					this.btmpList.Add(false);
					this.bReadList.Add(false);
				}
				this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
				if (this.DM.Letter_PluralY > -1f)
				{
					this.m_ScrollPanel.GoTo(this.DM.Letter_PluralIdx, this.DM.Letter_PluralY);
				}
				this.MaxLetterNum = this.DM.GetMailboxSize(this.mPluralReplyID, this.mPluralSenderName);
			}
			break;
		case 3:
		{
			this.tmplist.Clear();
			this.Datalist.Clear();
			this.btmpList.Clear();
			this.bReadList.Clear();
			this.bCheckList.Clear();
			this.DM.MailDataRefresh((MailType)this.NowPage);
			int num4 = 0;
			while ((long)num4 < (long)((ulong)this.DM.Mailing.FavorSerial.Count))
			{
				MyFavorite myFavorite = this.DM.FavorReportGet(num4);
				if (myFavorite != null)
				{
					if (myFavorite.Type == MailType.EMAIL_LETTER)
					{
						if (this.ImgFunction.IsActive() && !flag && myFavorite.Mail.BeChecked)
						{
							flag = true;
						}
					}
					else if (myFavorite.Type == MailType.EMAIL_BATTLE)
					{
						if (this.ImgFunction.IsActive() && !flag && myFavorite.Combat.BeChecked)
						{
							flag = true;
						}
					}
					else if (myFavorite.Type == MailType.EMAIL_SYSTEM && this.ImgFunction.IsActive() && !flag && myFavorite.System.BeChecked)
					{
						flag = true;
					}
				}
				this.tmplist.Add(97f);
				this.Datalist.Add((float)num4);
				this.btmpList.Add(false);
				this.bReadList.Add(false);
				num4++;
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			if (this.DM.Letter_Y > -1f)
			{
				this.m_ScrollPanel.GoTo(this.DM.Letter_Idx, this.DM.Letter_Y);
			}
			this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_FAVORY);
			break;
		}
		case 5:
			this.MaxLetterNum = this.mPluralTotal;
			this.tmplist.Clear();
			this.Datalist.Clear();
			this.btmpList.Clear();
			this.bReadList.Clear();
			this.bCheckList.Clear();
			for (int j = 0; j < this.MaxLetterNum; j++)
			{
				if (this.ImgFunction.IsActive() && !flag)
				{
					MailContent mailContent2 = this.DM.MailReportGet(j, this.mPluralReplyID, this.mPluralSenderName);
					if (mailContent2.BeChecked)
					{
						flag = true;
					}
				}
				this.tmplist.Add(97f);
				this.Datalist.Add((float)j);
				this.btmpList.Add(false);
				this.bReadList.Add(false);
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			break;
		}
		if (!flag && this.ImgFunction.IsActive())
		{
			this.ImgFunction.gameObject.SetActive(false);
			this.bOpenImg = false;
		}
		if (this.tmplist.Count == 0 && !this.ImgNoLetter.IsActive())
		{
			this.ImgNoLetter.gameObject.SetActive(true);
		}
		else if (this.tmplist.Count > 0 && this.ImgNoLetter.IsActive())
		{
			this.ImgNoLetter.gameObject.SetActive(false);
		}
		this.UpdataUnRead();
	}

	// Token: 0x06001D55 RID: 7509 RVA: 0x0034B430 File Offset: 0x00349630
	public void SetAllSelect(bool bAllSelect, bool Refresh = true)
	{
		if (this.AllSelect < this.MaxLetterNum && bAllSelect)
		{
			this.AllSelect = this.MaxLetterNum;
		}
		else
		{
			this.AllSelect = 0;
			bAllSelect = false;
		}
		if (this.NowPage == 2)
		{
			if (this.NowPageKind == 1)
			{
				this.DM.MailReportSelect((!bAllSelect) ? 0 : -1, this.mPluralReplyID, this.mPluralSenderName, Refresh, true);
				this.bOpenImg = (this.DM.Mailing.MailSerial.Select > 0u);
			}
			else
			{
				this.DM.MailReportSelect((!bAllSelect) ? 0 : -1, Refresh);
				this.bOpenImg = (this.DM.Mailing.MailSerial.Select > 0u);
			}
		}
		else if (this.NowPage == 1)
		{
			this.DM.CombatReportSelect((!bAllSelect) ? 0 : -1, Refresh);
			this.bOpenImg = (this.DM.Mailing.ReportSerial.Select > 0u);
		}
		else if (this.NowPage == 3)
		{
			this.DM.FavorReportSelect(-1, bAllSelect, Refresh);
			this.bOpenImg = (this.DM.Mailing.FavorSerial.Select > 0u);
		}
		else if (this.NowPage == 0)
		{
			this.DM.SystemReportSelect((!bAllSelect) ? 0 : -1, Refresh);
			this.bOpenImg = (this.DM.Mailing.SystemSerial.Select > 0u);
		}
		if (this.bOpenImg)
		{
			this.ImgFunction.gameObject.SetActive(true);
		}
		else
		{
			this.ImgFunction.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001D56 RID: 7510 RVA: 0x0034B60C File Offset: 0x0034980C
	public void CheckSelect(UIButton sender)
	{
		Transform parent = sender.gameObject.transform.parent;
		int btnID = parent.GetComponent<ScrollPanelItem>().m_BtnID1;
		int btnID2 = parent.GetComponent<ScrollPanelItem>().m_BtnID2;
		if (this.NowPage == 2)
		{
			MailContent mailContent;
			if (this.NowPageKind == 1)
			{
				mailContent = this.DM.MailReportGet(btnID, this.mPluralReplyID, this.mPluralSenderName);
			}
			else
			{
				mailContent = this.DM.MailReportGet(btnID);
			}
			if (mailContent != null)
			{
				if (this.NowPageKind == 1)
				{
					this.DM.MailReportSelect((int)mailContent.SerialID, mailContent.ReplyID, mailContent.SenderName, true, true);
				}
				else
				{
					this.DM.MailReportSelect((int)mailContent.SerialID, true);
				}
				if (mailContent.BeChecked)
				{
					this.bCheckList.Add(mailContent.SerialID);
					this.ImgSelect[btnID2].gameObject.SetActive(true);
					this.AllSelect++;
				}
				else
				{
					this.bCheckList.Remove(mailContent.SerialID);
					this.ImgSelect[btnID2].gameObject.SetActive(false);
					this.AllSelect--;
				}
				this.bOpenImg = (this.DM.Mailing.MailSerial.Select > 0u);
			}
		}
		else if (this.NowPage == 1)
		{
			CombatReport combatReport = this.DM.CombatReportGet(btnID);
			if (combatReport != null)
			{
				this.DM.CombatReportSelect((int)combatReport.SerialID, true);
				if (combatReport.BeChecked)
				{
					this.bCheckList.Add(combatReport.SerialID);
					this.ImgSelect[btnID2].gameObject.SetActive(true);
					this.AllSelect++;
				}
				else
				{
					this.bCheckList.Remove(combatReport.SerialID);
					this.ImgSelect[btnID2].gameObject.SetActive(false);
					this.AllSelect--;
				}
				this.bOpenImg = (this.DM.Mailing.ReportSerial.Select > 0u);
			}
		}
		else if (this.NowPage == 3)
		{
			this.ImgSelect[btnID2].gameObject.SetActive(this.DM.FavorReportSelect(btnID, false, true));
			this.bOpenImg = (this.DM.Mailing.FavorSerial.Select > 0u);
		}
		else if (this.NowPage == 0)
		{
			NoticeContent noticeContent = this.DM.SystemReportGet(btnID);
			if (noticeContent != null)
			{
				this.DM.SystemReportSelect((int)noticeContent.SerialID, true);
				if (noticeContent.BeChecked)
				{
					this.bCheckList.Add(noticeContent.SerialID);
					this.ImgSelect[btnID2].gameObject.SetActive(true);
					this.AllSelect++;
				}
				else
				{
					this.bCheckList.Remove(noticeContent.SerialID);
					this.ImgSelect[btnID2].gameObject.SetActive(false);
					this.AllSelect--;
				}
				this.bOpenImg = (this.DM.Mailing.SystemSerial.Select > 0u);
			}
		}
		else if (this.btmpList.Count >= btnID)
		{
			if (!this.btmpList[btnID])
			{
				this.btmpList[btnID] = true;
				this.ImgSelect[btnID2].gameObject.SetActive(true);
				this.AllSelect++;
				if (!this.bOpenImg)
				{
					this.bOpenImg = true;
				}
			}
			else
			{
				this.btmpList[btnID] = false;
				this.ImgSelect[btnID2].gameObject.SetActive(false);
				this.AllSelect--;
				bool flag = false;
				for (int i = 0; i < 30; i++)
				{
					if (this.btmpList[i])
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					this.bOpenImg = false;
				}
			}
		}
		if (this.bOpenImg)
		{
			if (!this.ImgFunction.IsActive())
			{
				this.ImgFunction.gameObject.SetActive(true);
			}
		}
		else
		{
			this.ImgFunction.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001D57 RID: 7511 RVA: 0x0034BA70 File Offset: 0x00349C70
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		this.ItemT = item.GetComponent<Transform>();
		if (this.tmpItem[panelObjectIdx] == null)
		{
			this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
			if (this.Datalist.Count > 0 && this.Datalist.Count >= dataIdx)
			{
				this.ImgNoRead2[panelObjectIdx] = this.ItemT.GetChild(0).GetComponent<Image>();
				this.btn_ItemDetail[panelObjectIdx] = this.ItemT.GetChild(1).GetComponent<UIButton>();
				this.btn_ItemDetail[panelObjectIdx].m_Handler = this;
				this.btn_ItemSelect[panelObjectIdx] = this.ItemT.GetChild(2).GetComponent<UIButton>();
				this.btn_ItemSelect[panelObjectIdx].m_Handler = this;
				this.ImgSelect[panelObjectIdx] = this.ItemT.GetChild(3).GetComponent<Image>();
				if (this.btmpList[dataIdx])
				{
					this.ImgSelect[panelObjectIdx].gameObject.SetActive(true);
				}
				else
				{
					this.ImgSelect[panelObjectIdx].gameObject.SetActive(false);
				}
				this.ImgNoRead[panelObjectIdx] = this.ItemT.GetChild(4).GetComponent<Image>();
				this.ImgRead[panelObjectIdx] = this.ItemT.GetChild(5).GetComponent<Image>();
				this.ImgIcon[panelObjectIdx] = this.ItemT.GetChild(6).GetComponent<Image>();
				this.ImgIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[10 + this.mIcon];
				this.ImgBookMark[panelObjectIdx] = this.ItemT.GetChild(7).GetComponent<Image>();
				this.btn_ItemCollect[panelObjectIdx] = this.ItemT.GetChild(8).GetComponent<UIButton>();
				this.btn_ItemCollect[panelObjectIdx].m_Handler = this;
				this.btn_ItemCollect[panelObjectIdx].image.sprite = this.SArray.m_Sprites[20];
				this.ImgPlural[panelObjectIdx] = this.ItemT.GetChild(9).GetComponent<Image>();
				this.Plural_RT[panelObjectIdx] = this.ItemT.GetChild(9).GetComponent<RectTransform>();
				this.text_PluralNoRead[panelObjectIdx] = this.ItemT.GetChild(9).GetChild(0).GetComponent<UIText>();
				this.text_Time[panelObjectIdx] = this.ItemT.GetChild(11).GetComponent<UIText>();
				this.text_1[panelObjectIdx] = this.ItemT.GetChild(12).GetComponent<UIText>();
				this.mtextOutline[panelObjectIdx] = this.ItemT.GetChild(12).GetComponent<Outline>();
				this.mtextShadow[panelObjectIdx] = this.ItemT.GetChild(12).GetComponent<Shadow>();
				this.text_2[panelObjectIdx] = this.ItemT.GetChild(13).GetComponent<UIText>();
				this.text_2[panelObjectIdx].SetCheckArabic(true);
				this.text_3[panelObjectIdx] = this.ItemT.GetChild(14).GetComponent<UIText>();
				this.text_3[panelObjectIdx].SetCheckArabic(true);
				this.text_PluralTotal[panelObjectIdx] = this.ItemT.GetChild(15).GetComponent<UIText>();
				this.ImgLM_Icon[panelObjectIdx] = this.ItemT.GetChild(16).GetComponent<Image>();
				this.ImgLM_Icon[panelObjectIdx].sprite = this.SArray.m_Sprites[22];
				this.ImgLM_Icon[panelObjectIdx].SetNativeSize();
			}
		}
		else
		{
			this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
			if (this.Datalist.Count > 0 && this.Datalist.Count >= dataIdx)
			{
				this.btn_ItemCollect[panelObjectIdx].image.sprite = this.SArray.m_Sprites[20];
			}
		}
		this.ImgIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[10 + this.mIcon];
		this.Cstrtext_1[panelObjectIdx].ClearString();
		this.Cstrtext_2[panelObjectIdx].ClearString();
		this.Cstrtext_3[panelObjectIdx].ClearString();
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		CString cstring3 = StringManager.Instance.StaticString1024();
		this.ImgLM_Icon[panelObjectIdx].gameObject.SetActive(false);
		this.ImgIcon[panelObjectIdx].gameObject.SetActive(true);
		if (this.NowPage == 2)
		{
			MailContent mailContent;
			if (this.NowPageKind == 0)
			{
				mailContent = this.DM.MailReportGet(dataIdx);
			}
			else
			{
				mailContent = this.DM.MailReportGet(dataIdx, this.mPluralReplyID, this.mPluralSenderName);
			}
			if (mailContent != null)
			{
				if (mailContent.SenderTag.Length != 0)
				{
					cstring.ClearString();
					cstring2.ClearString();
					cstring3.ClearString();
					if (mailContent.MailType != 3)
					{
						if (mailContent.MailType == 4)
						{
							cstring2.Append(mailContent.SenderName);
							cstring3.Append(mailContent.SenderTag);
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
							this.Cstrtext_1[panelObjectIdx].StringToFormat(cstring);
							this.Cstrtext_1[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(11055u));
						}
						else
						{
							cstring2.Append(mailContent.SenderName);
							cstring3.Append(mailContent.SenderTag);
							GameConstants.FormatRoleName(this.Cstrtext_1[panelObjectIdx], cstring2, cstring3, null, 0, 0, null, null, null, null);
						}
					}
					else
					{
						cstring2.Append(mailContent.SenderName);
						cstring3.Append(mailContent.SenderTag);
						if (mailContent.SenderKindom != DataManager.MapDataController.kingdomData.kingdomID)
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mailContent.SenderKindom, this.GUIM.IsArabic);
						}
						else
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
						}
						this.Cstrtext_1[panelObjectIdx].StringToFormat(cstring);
						this.Cstrtext_1[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(1473u));
					}
				}
				else if (mailContent.MailType == 2)
				{
					this.Cstrtext_1[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(8252u));
					this.Cstrtext_2[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(8257u));
					this.ImgLM_Icon[panelObjectIdx].gameObject.SetActive(true);
					this.ImgIcon[panelObjectIdx].gameObject.SetActive(false);
				}
				else if (mailContent.MailType == 4)
				{
					this.Cstrtext_1[panelObjectIdx].StringToFormat(mailContent.SenderName);
					this.Cstrtext_1[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(11055u));
				}
				else
				{
					this.Cstrtext_1[panelObjectIdx].Append(mailContent.SenderName);
				}
				this.text_1[panelObjectIdx].text = this.Cstrtext_1[panelObjectIdx].ToString();
				if (mailContent.MailType == 1)
				{
					this.Cstrtext_2[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(6014u));
				}
				else if (mailContent.MailType == 3)
				{
					this.Cstrtext_2[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(1474u));
				}
				if (this.bTrans && mailContent.Translation && mailContent.MailType != 2 && this.DM.CheckLanguageTranslateByIdx((int)mailContent.LanguageSource) && mailContent.LanguageTarget == (byte)this.DM.UserLanguage && this.GUIM.CheckNeedTranslate(mailContent.Title))
				{
					this.Cstrtext_2[panelObjectIdx].Append(mailContent.TitleT);
				}
				else
				{
					this.Cstrtext_2[panelObjectIdx].Append(mailContent.Title);
				}
				this.text_2[panelObjectIdx].text = this.Cstrtext_2[panelObjectIdx].ToString();
				if (this.bTrans && mailContent.Translation && mailContent.MailType != 2 && this.DM.CheckLanguageTranslateByIdx((int)mailContent.LanguageSource) && mailContent.LanguageTarget == (byte)this.DM.UserLanguage)
				{
					this.Cstrtext_3[panelObjectIdx].Append(mailContent.ContentT);
				}
				else
				{
					this.Cstrtext_3[panelObjectIdx].Append(mailContent.Content);
				}
				this.text_3[panelObjectIdx].text = this.Cstrtext_3[panelObjectIdx].ToString();
				this.text_Time[panelObjectIdx].text = mailContent.DateTime;
				if (mailContent.BeChecked)
				{
					this.ImgSelect[panelObjectIdx].gameObject.SetActive(true);
				}
				else
				{
					this.ImgSelect[panelObjectIdx].gameObject.SetActive(false);
				}
				if (mailContent.BeRead)
				{
					this.ImgNoRead2[panelObjectIdx].gameObject.SetActive(false);
					this.mtextOutline[panelObjectIdx].enabled = false;
					this.mtextShadow[panelObjectIdx].enabled = false;
				}
				else
				{
					this.ImgNoRead2[panelObjectIdx].gameObject.SetActive(true);
					this.mtextOutline[panelObjectIdx].enabled = true;
					this.mtextShadow[panelObjectIdx].enabled = true;
				}
				if (mailContent.More > 1 && this.NowPageKind == 0)
				{
					this.btn_ItemCollect[panelObjectIdx].gameObject.SetActive(false);
					this.text_PluralTotal[panelObjectIdx].gameObject.SetActive(true);
					this.Cstr_PluralTotal[panelObjectIdx].ClearString();
					this.Cstr_PluralTotal[panelObjectIdx].IntToFormat((long)mailContent.More, 1, false);
					this.Cstr_PluralTotal[panelObjectIdx].AppendFormat("({0})");
					this.text_PluralTotal[panelObjectIdx].text = this.Cstr_PluralTotal[panelObjectIdx].ToString();
					this.text_PluralTotal[panelObjectIdx].SetAllDirty();
					this.text_PluralTotal[panelObjectIdx].cachedTextGenerator.Invalidate();
					this.text_PluralNoRead[panelObjectIdx].text = mailContent.UnSeen.ToString();
					if (mailContent.UnSeen > 0)
					{
						this.ImgPlural[panelObjectIdx].gameObject.SetActive(true);
					}
					else
					{
						this.ImgPlural[panelObjectIdx].gameObject.SetActive(false);
					}
					this.Plural_RT[panelObjectIdx].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PluralNoRead[panelObjectIdx].preferredWidth), this.Plural_RT[panelObjectIdx].sizeDelta.y);
				}
				else
				{
					this.btn_ItemCollect[panelObjectIdx].gameObject.SetActive(true);
					this.ImgPlural[panelObjectIdx].gameObject.SetActive(false);
					this.text_PluralTotal[panelObjectIdx].gameObject.SetActive(false);
				}
				if (mailContent.MailType != 2)
				{
					this.ImgNoRead[panelObjectIdx].gameObject.SetActive(!mailContent.BeRead);
					this.ImgRead[panelObjectIdx].gameObject.SetActive(mailContent.BeRead);
				}
				else
				{
					this.ImgNoRead[panelObjectIdx].gameObject.SetActive(false);
					this.ImgRead[panelObjectIdx].gameObject.SetActive(false);
				}
			}
		}
		else if (this.NowPage == 1)
		{
			CombatReport combatReport = this.DM.CombatReportGet(dataIdx);
			if (combatReport != null)
			{
				this.SetCombatReport(combatReport, panelObjectIdx);
				if (combatReport.More != 0)
				{
					this.btn_ItemCollect[panelObjectIdx].gameObject.SetActive(false);
				}
				else
				{
					this.btn_ItemCollect[panelObjectIdx].gameObject.SetActive(true);
				}
				if (combatReport.More > 1)
				{
					if (combatReport.UnSeen > 0)
					{
						this.ImgPlural[panelObjectIdx].gameObject.SetActive(true);
					}
					else
					{
						this.ImgPlural[panelObjectIdx].gameObject.SetActive(false);
					}
					this.text_PluralTotal[panelObjectIdx].gameObject.SetActive(true);
					this.Cstr_PluralTotal[panelObjectIdx].ClearString();
					this.Cstr_PluralTotal[panelObjectIdx].IntToFormat((long)combatReport.More, 1, false);
					this.Cstr_PluralTotal[panelObjectIdx].AppendFormat("({0})");
					this.text_PluralTotal[panelObjectIdx].text = this.Cstr_PluralTotal[panelObjectIdx].ToString();
					this.text_PluralTotal[panelObjectIdx].SetAllDirty();
					this.text_PluralTotal[panelObjectIdx].cachedTextGenerator.Invalidate();
					this.text_PluralNoRead[panelObjectIdx].text = combatReport.UnSeen.ToString();
					this.Plural_RT[panelObjectIdx].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PluralNoRead[panelObjectIdx].preferredWidth), this.Plural_RT[panelObjectIdx].sizeDelta.y);
				}
				else
				{
					this.ImgPlural[panelObjectIdx].gameObject.SetActive(false);
					this.text_PluralTotal[panelObjectIdx].gameObject.SetActive(false);
				}
			}
			else
			{
				this.text_1[panelObjectIdx].text = string.Empty;
				this.text_2[panelObjectIdx].text = string.Empty;
				this.text_3[panelObjectIdx].text = string.Empty;
				this.text_Time[panelObjectIdx].text = string.Empty;
			}
		}
		else if (this.NowPage == 3)
		{
			this.ImgPlural[panelObjectIdx].gameObject.SetActive(false);
			this.text_PluralTotal[panelObjectIdx].gameObject.SetActive(false);
			MyFavorite myFavorite = this.DM.FavorReportGet(dataIdx);
			if (myFavorite != null)
			{
				this.btn_ItemCollect[panelObjectIdx].gameObject.SetActive(true);
				this.btn_ItemCollect[panelObjectIdx].image.sprite = this.SArray.m_Sprites[21];
				if (myFavorite.Type == MailType.EMAIL_LETTER)
				{
					MailContent mail = myFavorite.Mail;
					if (mail.SenderTag.Length != 0)
					{
						cstring.ClearString();
						cstring2.ClearString();
						cstring3.ClearString();
						if (mail.MailType != 3)
						{
							if (mail.MailType == 4)
							{
								cstring2.Append(mail.SenderName);
								cstring3.Append(mail.SenderTag);
								this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
								this.Cstrtext_1[panelObjectIdx].StringToFormat(cstring);
								this.Cstrtext_1[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(11055u));
							}
							else
							{
								cstring2.Append(mail.SenderName);
								cstring3.Append(mail.SenderTag);
								GameConstants.FormatRoleName(this.Cstrtext_1[panelObjectIdx], cstring2, cstring3, null, 0, 0, null, null, null, null);
							}
						}
						else
						{
							cstring2.Append(mail.SenderName);
							cstring3.Append(mail.SenderTag);
							if (mail.SenderKindom != DataManager.MapDataController.kingdomData.kingdomID)
							{
								this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mail.SenderKindom, this.GUIM.IsArabic);
							}
							else
							{
								this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
							}
							this.Cstrtext_1[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(1473u));
							this.text_1[panelObjectIdx].text = this.Cstrtext_1[panelObjectIdx].ToString();
						}
					}
					else if (mail.MailType == 2)
					{
						this.Cstrtext_1[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(8252u));
						this.Cstrtext_2[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(8257u));
						this.ImgLM_Icon[panelObjectIdx].gameObject.SetActive(true);
						this.ImgIcon[panelObjectIdx].gameObject.SetActive(false);
					}
					else if (mail.MailType == 4)
					{
						this.Cstrtext_1[panelObjectIdx].StringToFormat(mail.SenderName);
						this.Cstrtext_1[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(11055u));
					}
					else
					{
						this.Cstrtext_1[panelObjectIdx].Append(mail.SenderName);
					}
					this.text_1[panelObjectIdx].text = this.Cstrtext_1[panelObjectIdx].ToString();
					if (mail.MailType == 1)
					{
						this.Cstrtext_2[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(6014u));
					}
					else if (mail.MailType == 3)
					{
						this.Cstrtext_2[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(1474u));
					}
					if (this.bTrans && mail.Translation && mail.MailType != 2 && this.DM.CheckLanguageTranslateByIdx((int)mail.LanguageSource) && mail.LanguageTarget == (byte)this.DM.UserLanguage && this.GUIM.CheckNeedTranslate(mail.Title))
					{
						this.Cstrtext_2[panelObjectIdx].Append(mail.TitleT);
					}
					else
					{
						this.Cstrtext_2[panelObjectIdx].Append(mail.Title);
					}
					this.text_2[panelObjectIdx].text = this.Cstrtext_2[panelObjectIdx].ToString();
					if (this.bTrans && mail.Translation && mail.MailType != 2 && this.DM.CheckLanguageTranslateByIdx((int)mail.LanguageSource) && mail.LanguageTarget == (byte)this.DM.UserLanguage)
					{
						this.Cstrtext_3[panelObjectIdx].Append(mail.ContentT);
					}
					else
					{
						this.Cstrtext_3[panelObjectIdx].Append(mail.Content);
					}
					this.text_3[panelObjectIdx].text = this.Cstrtext_3[panelObjectIdx].ToString();
					this.text_Time[panelObjectIdx].text = mail.DateTime;
					if (mail.BeChecked)
					{
						this.ImgSelect[panelObjectIdx].gameObject.SetActive(true);
					}
					else
					{
						this.ImgSelect[panelObjectIdx].gameObject.SetActive(false);
					}
					if (mail.BeRead)
					{
						this.ImgNoRead2[panelObjectIdx].gameObject.SetActive(false);
						this.mtextOutline[panelObjectIdx].enabled = false;
						this.mtextShadow[panelObjectIdx].enabled = false;
					}
					else
					{
						this.ImgNoRead2[panelObjectIdx].gameObject.SetActive(true);
						this.mtextOutline[panelObjectIdx].enabled = true;
						this.mtextShadow[panelObjectIdx].enabled = true;
					}
					this.btn_ItemCollect[panelObjectIdx].gameObject.SetActive(true);
					this.ImgPlural[panelObjectIdx].gameObject.SetActive(false);
					if (mail.MailType != 2)
					{
						this.ImgNoRead[panelObjectIdx].gameObject.SetActive(!mail.BeRead);
						this.ImgRead[panelObjectIdx].gameObject.SetActive(mail.BeRead);
					}
					else
					{
						this.ImgNoRead[panelObjectIdx].gameObject.SetActive(false);
						this.ImgRead[panelObjectIdx].gameObject.SetActive(false);
					}
				}
				else if (myFavorite.Type == MailType.EMAIL_BATTLE)
				{
					CombatReport combat = myFavorite.Combat;
					this.SetCombatReport(combat, panelObjectIdx);
				}
				else if (myFavorite.Type == MailType.EMAIL_SYSTEM)
				{
					NoticeContent system = myFavorite.System;
					if (system != null)
					{
						if ((system.Type >= NoticeReport.Enotice_NewbieOver && system.Type <= NoticeReport.Enotice_SHLevel5) || system.Type == NoticeReport.Enotice_FirstUnderPetAttack)
						{
							this.text_1[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(3717u);
						}
						else
						{
							this.text_1[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(6079u);
						}
						this.ImgIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[13];
						this.SetNoticeContent(system, panelObjectIdx);
					}
				}
			}
			else
			{
				this.text_1[panelObjectIdx].text = string.Empty;
				this.text_2[panelObjectIdx].text = string.Empty;
				this.text_3[panelObjectIdx].text = string.Empty;
				this.text_Time[panelObjectIdx].text = string.Empty;
			}
		}
		else if (this.NowPage == 0)
		{
			this.btn_ItemCollect[panelObjectIdx].gameObject.SetActive(true);
			this.ImgPlural[panelObjectIdx].gameObject.SetActive(false);
			this.text_PluralTotal[panelObjectIdx].gameObject.SetActive(false);
			NoticeContent noticeContent = this.DM.SystemReportGet(dataIdx);
			if (noticeContent != null)
			{
				if ((noticeContent.Type >= NoticeReport.Enotice_NewbieOver && noticeContent.Type <= NoticeReport.Enotice_SHLevel5) || noticeContent.Type == NoticeReport.Enotice_FirstUnderPetAttack)
				{
					this.text_1[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(3717u);
				}
				else
				{
					this.text_1[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(6079u);
				}
				this.ImgIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[13];
				this.SetNoticeContent(noticeContent, panelObjectIdx);
			}
			else
			{
				this.text_1[panelObjectIdx].text = string.Empty;
				this.text_2[panelObjectIdx].text = string.Empty;
				this.text_3[panelObjectIdx].text = string.Empty;
				this.text_Time[panelObjectIdx].text = string.Empty;
			}
		}
		this.text_1[panelObjectIdx].SetAllDirty();
		this.text_1[panelObjectIdx].cachedTextGenerator.Invalidate();
		if (this.Cstrtext_2[panelObjectIdx].Length != 0)
		{
			this.CheckTextWidth(this.text_2[panelObjectIdx], this.Cstrtext_2[panelObjectIdx]);
		}
		this.text_2[panelObjectIdx].SetAllDirty();
		this.text_2[panelObjectIdx].cachedTextGenerator.Invalidate();
		this.text_2[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
		if (this.Cstrtext_3[panelObjectIdx].Length != 0)
		{
			this.CheckTextWidth(this.text_3[panelObjectIdx], this.Cstrtext_3[panelObjectIdx]);
		}
		this.text_3[panelObjectIdx].SetAllDirty();
		this.text_3[panelObjectIdx].cachedTextGenerator.Invalidate();
		this.text_3[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
		this.ImgIcon[panelObjectIdx].SetNativeSize();
	}

	// Token: 0x06001D58 RID: 7512 RVA: 0x0034D0F0 File Offset: 0x0034B2F0
	public void SetCombatReport(CombatReport mReport, int Idx)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		switch (mReport.Type)
		{
		case CombatCollectReport.CCR_BATTLE:
			this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[16];
			if (mReport.Combat.CombatPointKind == POINT_KIND.PK_YOLK)
			{
				this.tmpV = DataManager.MapDataController.GetYolkPos((ushort)mReport.Combat.CombatPoint, mReport.Combat.KingdomID);
			}
			else
			{
				this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(mReport.Combat.CombatlZone, mReport.Combat.CombatPoint));
			}
			cstring.IntToFormat((long)mReport.Combat.KingdomID, 1, false);
			cstring.IntToFormat((long)((int)this.tmpV.x), 1, false);
			cstring.IntToFormat((long)((int)this.tmpV.y), 1, false);
			if (this.GUIM.IsArabic)
			{
				cstring.AppendFormat("{0}:K {1}:X {2}:Y");
			}
			else
			{
				cstring.AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
			}
			this.Cstrtext_1[Idx].StringToFormat(cstring);
			this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(5305u));
			this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
			this.GetTextCombatbySide(mReport.Combat, this.Cstrtext_2[Idx]);
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			if (mReport.Combat.Result >= CombatReportResultType.ECRR_COMBATVICTORY && mReport.Combat.Result < CombatReportResultType.ECRR_COMBATMASSIVEDEFEAT)
			{
				this.temp = (int)mReport.Combat.Result;
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID((uint)((ushort)(5307 + this.temp))));
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			else if (mReport.Combat.Result == CombatReportResultType.ECRR_COMBATMASSIVEDEFEAT)
			{
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5308u));
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			else if (mReport.Combat.Result == CombatReportResultType.ECRR_DEFENDERSHIELDUP || mReport.Combat.Result == CombatReportResultType.ECRR_ALLYDEFENDER)
			{
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(625u));
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			else if (mReport.Combat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER || mReport.Combat.Result == CombatReportResultType.ECRR_WONDERVICTORY)
			{
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5307u));
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			break;
		case CombatCollectReport.CCR_RESOURCE:
			this.text_1[Idx].text = string.Empty;
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6042u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].StringToFormat(mReport.Resource.Name);
			if (mReport.Resource.Result == 0)
			{
				this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6044u));
			}
			else if (mReport.Resource.Result == 1)
			{
				this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6043u));
			}
			else
			{
				this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6045u));
			}
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[18];
			break;
		case CombatCollectReport.CCR_COLLECT:
			this.Cstrtext_1[Idx].IntToFormat((long)mReport.Gather.GatherPointLevel, 1, false);
			this.Cstrtext_1[Idx].StringToFormat(this.GUIM.GetPointName_Letter(mReport.Gather.GatherPointKind));
			this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6050u));
			this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6047u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[19];
			break;
		case CombatCollectReport.CCR_SCOUT:
		{
			this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[15];
			if (mReport.Scout.CombatPointKind != POINT_KIND.PK_YOLK)
			{
				this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(mReport.Scout.CombatlZone, mReport.Scout.CombatPoint));
				this.Cstrtext_1[Idx].IntToFormat((long)mReport.Scout.KingdomID, 1, false);
				this.Cstrtext_1[Idx].IntToFormat((long)((int)this.tmpV.x), 1, false);
				this.Cstrtext_1[Idx].IntToFormat((long)((int)this.tmpV.y), 1, false);
				if (this.GUIM.IsArabic)
				{
					this.Cstrtext_1[Idx].AppendFormat("{0}:K {1}:X {2}:Y");
				}
				else
				{
					this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
				}
				this.Cstrtext_1[Idx].Append(this.GUIM.GetPointName_Letter(mReport.Scout.CombatPointKind));
			}
			else
			{
				this.tmpV = DataManager.MapDataController.GetYolkPos((ushort)mReport.Scout.CombatPoint, mReport.Scout.KingdomID);
				this.Cstrtext_1[Idx].IntToFormat((long)mReport.Scout.KingdomID, 1, false);
				this.Cstrtext_1[Idx].IntToFormat((long)((int)this.tmpV.x), 1, false);
				this.Cstrtext_1[Idx].IntToFormat((long)((int)this.tmpV.y), 1, false);
				if (this.GUIM.IsArabic)
				{
					this.Cstrtext_1[Idx].AppendFormat("{0}:K {1}:X {2}:Y");
				}
				else
				{
					this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
				}
				if (mReport.Scout.CombatPoint == 0 || mReport.Scout.KingdomID == ActivityManager.Instance.KOWKingdomID)
				{
					this.Cstrtext_1[Idx].Append(this.DM.mStringTable.GetStringByID(9308u));
				}
				else
				{
					this.Cstrtext_1[Idx].Append(this.DM.mStringTable.GetStringByID(9309u));
				}
			}
			this.Cstrtext_1[Idx].Append(this.DM.mStringTable.GetStringByID(5347u));
			this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
			CString cstring2 = StringManager.Instance.StaticString1024();
			CString cstring3 = StringManager.Instance.StaticString1024();
			cstring2.ClearString();
			cstring3.ClearString();
			cstring.ClearString();
			if (mReport.Scout.ScoutResult == 0)
			{
				if (mReport.Scout.CombatPointKind != POINT_KIND.PK_YOLK)
				{
					cstring.ClearString();
					cstring2.Append(mReport.Scout.ObjName);
					if (mReport.Scout.ObjAllianceTag.Length != 0)
					{
						cstring3.Append(mReport.Scout.ObjAllianceTag);
						if (mReport.Scout.ObjKingdomID != DataManager.MapDataController.kingdomData.kingdomID)
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mReport.Scout.ObjKingdomID, this.GUIM.IsArabic);
						}
						else
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
						}
					}
					else if (mReport.Scout.ObjKingdomID != DataManager.MapDataController.kingdomData.kingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mReport.Scout.ObjKingdomID, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
					}
				}
				else
				{
					cstring.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)mReport.Scout.CombatPoint, mReport.Scout.KingdomID));
					cstring.AppendFormat("{0}");
				}
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5348u));
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			else
			{
				if (mReport.Scout.ScoutResult == 3 && mReport.Scout.CombatPointKind == POINT_KIND.PK_YOLK)
				{
					this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5348u));
					cstring.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)mReport.Scout.CombatPoint, mReport.Scout.KingdomID));
					cstring.AppendFormat("{0}");
				}
				else
				{
					this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5349u));
				}
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			this.Cstrtext_2[Idx].StringToFormat(cstring);
			this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7259u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			break;
		}
		case CombatCollectReport.CCR_RECON:
			this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[17];
			this.Cstrtext_1[Idx].Append(this.DM.mStringTable.GetStringByID(5350u));
			this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
			if (mReport.Recon.CombatPointKind == POINT_KIND.PK_YOLK)
			{
				this.Cstrtext_2[Idx].StringToFormat(DataManager.MapDataController.GetYolkName((ushort)mReport.Recon.CombatPoint, mReport.Recon.KingdomID));
			}
			else
			{
				this.Cstrtext_2[Idx].StringToFormat(this.GUIM.GetPointName_Letter(mReport.Recon.CombatPointKind));
			}
			if (mReport.Recon.AntiScout == 0)
			{
				if (mReport.Recon.CombatPointKind == POINT_KIND.PK_YOLK)
				{
					this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7263u));
				}
				else
				{
					this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(5355u));
				}
			}
			else
			{
				this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(5355u));
			}
			if (mReport.Recon.bAmbush == 1)
			{
				this.Cstrtext_2[Idx].ClearString();
				this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9748u));
			}
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			break;
		case CombatCollectReport.CCR_MONSTER:
			this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(mReport.Monster.Zone, mReport.Monster.Point));
			cstring.IntToFormat((long)mReport.Monster.KindgomID, 1, false);
			cstring.IntToFormat((long)((int)this.tmpV.x), 1, false);
			cstring.IntToFormat((long)((int)this.tmpV.y), 1, false);
			if (this.GUIM.IsArabic)
			{
				cstring.AppendFormat("{0}:K {1}:X {2}:Y");
			}
			else
			{
				cstring.AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
			}
			this.Cstrtext_1[Idx].StringToFormat(cstring);
			this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8218u));
			this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
			if (mReport.Monster.Result > 1 && mReport.Monster.Result < 4)
			{
				this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8217u));
			}
			else if (mReport.Monster.Result < 2)
			{
				this.Cstrtext_2[Idx].IntToFormat((long)mReport.Monster.MonsterLv, 1, false);
				this.Cstrtext_2[Idx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)DataManager.MapDataController.MapMonsterTable.GetRecordByKey(mReport.Monster.MonsterID).NameID));
				if (mReport.Monster.Result == 0)
				{
					this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8221u));
				}
				else
				{
					this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8223u));
				}
			}
			else
			{
				CString cstring4 = StringManager.Instance.StaticString1024();
				cstring4.StringToFormat(mReport.Monster.AllianceTag);
				cstring4.StringToFormat(this.DM.mStringTable.GetStringByID((uint)DataManager.MapDataController.MapMonsterTable.GetRecordByKey(mReport.Monster.MonsterID).NameID));
				cstring4.AppendFormat("[{0}]{1}");
				this.Cstrtext_2[Idx].IntToFormat((long)mReport.Monster.MonsterLv, 1, false);
				this.Cstrtext_2[Idx].StringToFormat(cstring4);
				if (mReport.Monster.Result == 4)
				{
					this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8221u));
				}
				else
				{
					this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8223u));
				}
			}
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			break;
		case CombatCollectReport.CCR_NPCSCOUT:
			this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[15];
			this.Cstrtext_1[Idx].Append(this.DM.mStringTable.GetStringByID(5347u));
			this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
			cstring.ClearString();
			cstring.IntToFormat((long)mReport.NPCScout.NPCLevel, 1, false);
			cstring.AppendFormat(this.DM.mStringTable.GetStringByID(12021u));
			this.Cstrtext_2[Idx].StringToFormat(cstring);
			this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7259u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			if (mReport.NPCScout.ScoutResult == 0)
			{
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5348u));
			}
			else
			{
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5349u));
			}
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case CombatCollectReport.CCR_NPCCOMBAT:
			this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[16];
			if (mReport.NPCCombat.CombatPointKind == POINT_KIND.PK_YOLK)
			{
				this.tmpV = DataManager.MapDataController.GetYolkPos((ushort)mReport.NPCCombat.CombatPoint, mReport.NPCCombat.KingdomID);
			}
			else
			{
				this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(mReport.NPCCombat.CombatlZone, mReport.NPCCombat.CombatPoint));
			}
			cstring.IntToFormat((long)mReport.NPCCombat.KingdomID, 1, false);
			cstring.IntToFormat((long)((int)this.tmpV.x), 1, false);
			cstring.IntToFormat((long)((int)this.tmpV.y), 1, false);
			if (this.GUIM.IsArabic)
			{
				cstring.AppendFormat("{0}:K {1}:X {2}:Y");
			}
			else
			{
				cstring.AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
			}
			this.Cstrtext_1[Idx].StringToFormat(cstring);
			this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(5305u));
			this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
			this.GetTextCombatbySide(mReport.NPCCombat, this.Cstrtext_2[Idx]);
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			if (mReport.NPCCombat.Result >= CombatReportResultType.ECRR_COMBATVICTORY && mReport.NPCCombat.Result < CombatReportResultType.ECRR_COMBATMASSIVEDEFEAT)
			{
				this.temp = (int)mReport.NPCCombat.Result;
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID((uint)((ushort)(5307 + this.temp))));
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			else if (mReport.NPCCombat.Result == CombatReportResultType.ECRR_COMBATMASSIVEDEFEAT)
			{
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5308u));
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			else if (mReport.NPCCombat.Result == CombatReportResultType.ECRR_DEFENDERSHIELDUP || mReport.NPCCombat.Result == CombatReportResultType.ECRR_ALLYDEFENDER)
			{
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(625u));
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			else if (mReport.NPCCombat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER || mReport.NPCCombat.Result == CombatReportResultType.ECRR_WONDERVICTORY)
			{
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5307u));
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			break;
		case CombatCollectReport.CCR_PETREPORT:
		{
			this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[8];
			this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(mReport.Pet.Zone, mReport.Pet.Point));
			cstring.IntToFormat((long)mReport.Pet.KindgomID, 1, false);
			cstring.IntToFormat((long)((int)this.tmpV.x), 1, false);
			cstring.IntToFormat((long)((int)this.tmpV.y), 1, false);
			if (this.GUIM.IsArabic)
			{
				cstring.AppendFormat("{0}:K {1}:X {2}:Y");
			}
			else
			{
				cstring.AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
			}
			this.Cstrtext_1[Idx].StringToFormat(cstring);
			this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(10092u));
			this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
			CString cstring5 = StringManager.Instance.StaticString1024();
			CString cstring6 = StringManager.Instance.StaticString1024();
			CString cstring7 = StringManager.Instance.StaticString1024();
			cstring5.ClearString();
			cstring6.ClearString();
			cstring7.ClearString();
			if (mReport.Pet.Side == 0)
			{
				cstring6.Append(mReport.Pet.DefenceName);
				if (mReport.Pet.DefenceAllianceTag != string.Empty)
				{
					cstring7.Append(mReport.Pet.DefenceAllianceTag);
					if (mReport.Pet.AssaultKingdomID != mReport.Pet.DefenceKingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, mReport.Pet.DefenceKingdomID, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					}
				}
				else if (mReport.Pet.AssaultKingdomID != mReport.Pet.DefenceKingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, mReport.Pet.DefenceKingdomID, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, 0, this.GUIM.IsArabic);
				}
				this.Cstrtext_2[Idx].StringToFormat(cstring5);
				this.Cstrtext_2[Idx].StringToFormat(this.GUIM.GetPointName_Letter((POINT_KIND)mReport.Pet.Kind));
				this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(10093u));
				this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
				if (mReport.Pet.Result == PetReportResultType.EPRR_ATTACKFAILED)
				{
					this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(10097u));
				}
				else
				{
					this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(10095u));
				}
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			else
			{
				cstring6.Append(mReport.Pet.AssaultName);
				if (mReport.Pet.AssaultAllianceTag != string.Empty)
				{
					cstring7.Append(mReport.Pet.AssaultAllianceTag);
					if (mReport.Pet.AssaultKingdomID != mReport.Pet.DefenceKingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, mReport.Pet.AssaultKingdomID, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring5, cstring6, cstring7, 0, this.GUIM.IsArabic);
					}
				}
				else if (mReport.Pet.AssaultKingdomID != mReport.Pet.DefenceKingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, mReport.Pet.AssaultKingdomID, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring5, cstring6, null, 0, this.GUIM.IsArabic);
				}
				this.Cstrtext_2[Idx].StringToFormat(cstring5);
				this.Cstrtext_2[Idx].StringToFormat(this.GUIM.GetPointName_Letter((POINT_KIND)mReport.Pet.Kind));
				this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(10094u));
				this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(10110u));
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			break;
		}
		}
		this.text_Time[Idx].text = mReport.DateTime;
		if (mReport.BeChecked)
		{
			this.ImgSelect[Idx].gameObject.SetActive(true);
		}
		else
		{
			this.ImgSelect[Idx].gameObject.SetActive(false);
		}
		if (mReport.BeRead)
		{
			this.ImgNoRead2[Idx].gameObject.SetActive(false);
			this.mtextOutline[Idx].enabled = false;
			this.mtextShadow[Idx].enabled = false;
		}
		else
		{
			this.ImgNoRead2[Idx].gameObject.SetActive(true);
			this.mtextOutline[Idx].enabled = true;
			this.mtextShadow[Idx].enabled = true;
		}
		this.ImgNoRead[Idx].gameObject.SetActive(!mReport.BeRead);
		this.ImgRead[Idx].gameObject.SetActive(mReport.BeRead);
	}

	// Token: 0x06001D59 RID: 7513 RVA: 0x0034EAEC File Offset: 0x0034CCEC
	public void SetNoticeContent(NoticeContent mNoticeRp, int Idx)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		CString cstring3 = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring2.ClearString();
		cstring3.ClearString();
		switch (mNoticeRp.Type)
		{
		case NoticeReport.ENotice_Enhance:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6080u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			break;
		case NoticeReport.ENotice_StarUp:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6084u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			break;
		case NoticeReport.ENotice_JoinAlliance:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6051u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			if (this.GUIM.IsArabic)
			{
				cstring2.Append(mNoticeRp.Notice_JoinAlliance.Name);
				cstring3.Append(mNoticeRp.Notice_JoinAlliance.Tag);
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				this.Cstrtext_3[Idx].StringToFormat(cstring);
				this.Cstrtext_3[Idx].StringToFormat(string.Empty);
			}
			else
			{
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_JoinAlliance.Tag);
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_JoinAlliance.Name);
			}
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6052u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_ApplyAlliance:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6053u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			if (this.GUIM.IsArabic)
			{
				cstring2.Append(mNoticeRp.Notice_ApplyAlliance.Name);
				cstring3.Append(mNoticeRp.Notice_ApplyAlliance.Tag);
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				this.Cstrtext_3[Idx].StringToFormat(cstring);
				this.Cstrtext_3[Idx].StringToFormat(string.Empty);
			}
			else
			{
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_ApplyAlliance.Tag);
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_ApplyAlliance.Name);
			}
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6054u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_ApplyAllianceBeDenied:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6055u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			if (this.GUIM.IsArabic)
			{
				cstring2.Append(mNoticeRp.Notice_ApplyAllianceBeDenied.Name);
				cstring3.Append(mNoticeRp.Notice_ApplyAllianceBeDenied.Tag);
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_ApplyAllianceBeDenied.Dealer);
				this.Cstrtext_3[Idx].StringToFormat(cstring);
				this.Cstrtext_3[Idx].StringToFormat(string.Empty);
			}
			else
			{
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_ApplyAllianceBeDenied.Dealer);
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_ApplyAllianceBeDenied.Tag);
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_ApplyAllianceBeDenied.Name);
			}
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6056u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_AllianceDismiss:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6059u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_AllianceDismiss.Leader);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6060u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_AllianceLeaderStepDown:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6063u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_AllianceLeaderStepDown.OldLeader);
			this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_AllianceLeaderStepDown.NewLeader);
			this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_AllianceLeaderStepDown.NewLeader);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6064u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_ActivityDegreePrize:
			if (mNoticeRp.Notice_ActivityDegreePrize.Type == NoticeContent.ActivityCircleEventType.EACET_SoloEvent)
			{
				this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7686u));
				this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(7678u));
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			else if (mNoticeRp.Notice_ActivityDegreePrize.Type == NoticeContent.ActivityCircleEventType.EACET_InfernalEvent)
			{
				this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7688u));
				this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(7682u));
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			break;
		case NoticeReport.Enotice_ActivityRankPrize:
			if (mNoticeRp.Notice_ActivityRankPrize.Type == NoticeContent.ActivityCircleEventType.EACET_SoloEvent)
			{
				this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7686u));
				this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
				this.Cstrtext_3[Idx].IntToFormat((long)mNoticeRp.Notice_ActivityRankPrize.Place, 1, false);
				this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7679u));
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			else if (mNoticeRp.Notice_ActivityRankPrize.Type == NoticeContent.ActivityCircleEventType.EACET_InfernalEvent)
			{
				this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7688u));
				this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
				this.Cstrtext_3[Idx].IntToFormat((long)mNoticeRp.Notice_ActivityRankPrize.Place, 1, false);
				this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7683u));
				this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			}
			break;
		case NoticeReport.Enotice_InviteAlliance:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6057u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			if (this.GUIM.IsArabic)
			{
				cstring2.Append(mNoticeRp.Notice_InviteAlliance.Name);
				cstring3.Append(mNoticeRp.Notice_InviteAlliance.Tag);
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_InviteAlliance.InviterName);
				this.Cstrtext_3[Idx].StringToFormat(cstring);
				this.Cstrtext_3[Idx].StringToFormat(string.Empty);
			}
			else
			{
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_InviteAlliance.InviterName);
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_InviteAlliance.Tag);
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_InviteAlliance.Name);
			}
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6058u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_SynLordEquip:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7700u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(mNoticeRp.Notice_SynLordEquip.ItemID).EquipName));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_RallyCancel:
		case NoticeReport.Enotice_RallyCancel_AsTargetAlly:
		case NoticeReport.Enotice_RallyCancel_Moving:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6067u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			break;
		case NoticeReport.Enotice_CryptFinish:
			this.text_2[Idx].text = this.DM.mStringTable.GetStringByID(6077u);
			this.text_3[Idx].text = this.DM.mStringTable.GetStringByID(6078u);
			break;
		case NoticeReport.Enotice_OtherSavedLord:
		{
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6074u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			CString cstring4 = StringManager.Instance.StaticString1024();
			cstring4.ClearString();
			cstring2.Append(mNoticeRp.Notice_OtherSavedLord.Name);
			if (mNoticeRp.Notice_OtherSavedLord.AllianceTag != string.Empty)
			{
				cstring3.Append(mNoticeRp.Notice_OtherSavedLord.AllianceTag);
				if (mNoticeRp.Notice_OtherSavedLord.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mNoticeRp.Notice_OtherSavedLord.HomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				}
			}
			else if (mNoticeRp.Notice_OtherSavedLord.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mNoticeRp.Notice_OtherSavedLord.HomeKingdom, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
			}
			this.Cstrtext_3[Idx].StringToFormat(cstring);
			this.Cstrtext_3[Idx].StringToFormat(string.Empty);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6071u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		}
		case NoticeReport.Enotice_SelfSavedLord:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7656u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(6075u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_LordBeingReleased:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6072u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			cstring2.Append(mNoticeRp.Notice_LordBeingReleased.Name);
			if (mNoticeRp.Notice_LordBeingReleased.AllianceTag != string.Empty)
			{
				cstring3.Append(mNoticeRp.Notice_LordBeingReleased.AllianceTag);
				if (mNoticeRp.Notice_LordBeingReleased.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mNoticeRp.Notice_LordBeingReleased.HomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				}
			}
			else if (mNoticeRp.Notice_LordBeingReleased.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mNoticeRp.Notice_LordBeingReleased.HomeKingdom, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
			}
			this.Cstrtext_3[Idx].StringToFormat(cstring);
			this.Cstrtext_3[Idx].StringToFormat(string.Empty);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6073u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_LordBeingExecuted:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7659u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			cstring2.Append(mNoticeRp.Notice_LordBeingExecuted.Name);
			if (mNoticeRp.Notice_LordBeingExecuted.AllianceTag != string.Empty)
			{
				cstring3.Append(mNoticeRp.Notice_LordBeingExecuted.AllianceTag);
				if (mNoticeRp.Notice_LordBeingExecuted.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mNoticeRp.Notice_LordBeingExecuted.HomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				}
			}
			else if (mNoticeRp.Notice_LordBeingExecuted.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mNoticeRp.Notice_LordBeingExecuted.HomeKingdom, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
			}
			this.Cstrtext_3[Idx].StringToFormat(cstring);
			this.Cstrtext_3[Idx].StringToFormat(string.Empty);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7660u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_LordEscaped:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6070u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(7655u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_OtherBreakPrison:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7665u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			cstring2.Append(mNoticeRp.Notice_OtherBreakPrison.Name);
			if (mNoticeRp.Notice_OtherBreakPrison.AllianceTag != string.Empty)
			{
				cstring3.Append(mNoticeRp.Notice_OtherBreakPrison.AllianceTag);
				if (mNoticeRp.Notice_OtherBreakPrison.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mNoticeRp.Notice_OtherBreakPrison.HomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				}
			}
			else if (mNoticeRp.Notice_OtherBreakPrison.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mNoticeRp.Notice_OtherBreakPrison.HomeKingdom, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
			}
			this.Cstrtext_3[Idx].StringToFormat(cstring);
			this.Cstrtext_3[Idx].StringToFormat(string.Empty);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7666u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_RescuedPrisoner:
			cstring2.Append(mNoticeRp.Notice_RescuedPrisoner.Name);
			if (mNoticeRp.Notice_RescuedPrisoner.AllianceTag != string.Empty)
			{
				cstring3.Append(mNoticeRp.Notice_RescuedPrisoner.AllianceTag);
				if (mNoticeRp.Notice_RescuedPrisoner.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mNoticeRp.Notice_RescuedPrisoner.HomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				}
			}
			else if (mNoticeRp.Notice_RescuedPrisoner.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mNoticeRp.Notice_RescuedPrisoner.HomeKingdom, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
			}
			this.Cstrtext_3[Idx].StringToFormat(cstring);
			this.Cstrtext_3[Idx].StringToFormat(string.Empty);
			this.Cstrtext_3[Idx].IntToFormat((long)mNoticeRp.Notice_RescuedPrisoner.PrisonerNum, 1, false);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7663u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			if (mNoticeRp.Notice_RescuedPrisoner.ClaimReward > 0u)
			{
				this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6076u));
			}
			else
			{
				this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8235u));
			}
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			break;
		case NoticeReport.Enotice_RequestRansom:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7658u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].IntToFormat((long)((ulong)mNoticeRp.Notice_RequestRansom.Ransom), 1, true);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7657u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_ReceivedRansom:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8232u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].IntToFormat((long)((ulong)mNoticeRp.Notice_ReceivedRansom.Ransom), 1, true);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7661u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_PrisonFull:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8234u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			cstring2.Append(mNoticeRp.Notice_PrisonFull.Name);
			if (mNoticeRp.Notice_PrisonFull.AllianceTag != string.Empty)
			{
				cstring3.Append(mNoticeRp.Notice_PrisonFull.AllianceTag);
				if (mNoticeRp.Notice_PrisonFull.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mNoticeRp.Notice_PrisonFull.HomeKingdom, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				}
			}
			else if (mNoticeRp.Notice_PrisonFull.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mNoticeRp.Notice_PrisonFull.HomeKingdom, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
			}
			this.Cstrtext_3[Idx].StringToFormat(cstring);
			this.Cstrtext_3[Idx].StringToFormat(string.Empty);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8233u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_BeQuitAlliance:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8215u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			if (this.GUIM.IsArabic)
			{
				cstring2.Append(mNoticeRp.Notice_BeQuitAlliance.Alliance);
				cstring3.Append(mNoticeRp.Notice_BeQuitAlliance.AllianceTag);
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_BeQuitAlliance.Dealer);
				this.Cstrtext_3[Idx].StringToFormat(cstring);
				this.Cstrtext_3[Idx].StringToFormat(string.Empty);
			}
			else
			{
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_BeQuitAlliance.Dealer);
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_BeQuitAlliance.AllianceTag);
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_BeQuitAlliance.Alliance);
			}
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8214u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_BuyTreasure:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8236u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(8237u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_AtkFailedSelfShield:
			if (mNoticeRp.Enotice_AtkFailedSelfShield.FailedType == 1)
			{
				this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8250u));
			}
			else
			{
				this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8251u));
			}
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			break;
		case NoticeReport.Enotice_InactiveState:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8249u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(8248u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_NewbieOver:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3718u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3719u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_SHLevel6:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3720u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3721u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_SHLevel10:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3722u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3723u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_SHLevel15:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3724u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3725u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_SHLevel17:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3726u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3727u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_FirstUnderAttack:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3728u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3729u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_FirstJoinAlliance:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3730u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3731u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_SHLevel5:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3732u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3733u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_BuyMonthTreature:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8236u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(920u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_RecivedGift:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9095u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			if (this.GUIM.IsArabic)
			{
				cstring2.Append(mNoticeRp.Enotice_RecivedGift.GiftsName);
				cstring3.Append(mNoticeRp.Enotice_RecivedGift.GiftsTag);
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				this.Cstrtext_3[Idx].StringToFormat(cstring);
				this.Cstrtext_3[Idx].StringToFormat(string.Empty);
			}
			else
			{
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Enotice_RecivedGift.GiftsTag);
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Enotice_RecivedGift.GiftsName);
			}
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9093u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_PrisonAmnestied:
			cstring2.Append(mNoticeRp.Enotice_PrisonAmnestied.KingdomName);
			cstring3.Append(mNoticeRp.Enotice_PrisonAmnestied.KingdomTag);
			this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
			this.Cstrtext_1[Idx].StringToFormat(cstring);
			this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(1473u));
			this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(1475u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(1463u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_LordBeingAmnestied:
			cstring2.Append(mNoticeRp.Enotice_LordBeingAmnestied.KingdomName);
			cstring3.Append(mNoticeRp.Enotice_LordBeingAmnestied.KingdomTag);
			this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
			this.Cstrtext_1[Idx].StringToFormat(cstring);
			this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(1473u));
			this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(1475u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			cstring2.ClearString();
			cstring3.ClearString();
			cstring2.Append(mNoticeRp.Enotice_LordBeingAmnestied.Name);
			cstring3.Append(mNoticeRp.Enotice_LordBeingAmnestied.Tag);
			this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
			this.Cstrtext_3[Idx].StringToFormat(cstring);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(1462u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_RulerGift:
			if (mNoticeRp.Enotice_RulerGift.RulerKind == 1)
			{
				this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9714u));
			}
			else if (mNoticeRp.Enotice_RulerGift.RulerKind == 2)
			{
				this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9799u));
			}
			else if (mNoticeRp.Enotice_RulerGift.RulerKind == 3)
			{
				this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(11086u));
			}
			else
			{
				this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(1049u));
			}
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			cstring2.Append(mNoticeRp.Enotice_RulerGift.Name);
			cstring3.Append(mNoticeRp.Enotice_RulerGift.Tag);
			this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
			this.Cstrtext_3[Idx].StringToFormat(cstring);
			if (mNoticeRp.Enotice_RulerGift.RulerKind == 1)
			{
				this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9715u));
			}
			else if (mNoticeRp.Enotice_RulerGift.RulerKind == 2)
			{
				this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9800u));
			}
			else if (mNoticeRp.Enotice_RulerGift.RulerKind == 3)
			{
				this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(11087u));
			}
			else
			{
				this.Cstrtext_3[Idx].AppendFormat("{0}");
				this.Cstrtext_3[Idx].ClearString();
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(1049u));
			}
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_DismissAllianceLeader:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9529u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Enotice_DismissAllianceLeader.OldLeader);
			this.Cstrtext_3[Idx].IntToFormat((long)mNoticeRp.Enotice_DismissAllianceLeader.OffLineDay, 1, false);
			this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Enotice_DismissAllianceLeader.NewLeader);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9535u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_AmbushDefSuccess:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9754u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			break;
		case NoticeReport.Enotice_AmbushDefFailed:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9756u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			break;
		case NoticeReport.Enotice_ActivityKVKDegreePrize:
			switch (mNoticeRp.Enotice_ActivityKVKDegreePrize.EventType)
			{
			case EActivityKingdomEventType.EAKET_SoloEvent:
				if (mNoticeRp.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomKillEvent || mNoticeRp.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomMatchEvent)
				{
					this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9846u));
					this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(9842u));
				}
				else if (mNoticeRp.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomNormalEvent)
				{
					this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9844u));
					this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(9838u));
				}
				else if (mNoticeRp.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_FIFA)
				{
					this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(12235u));
					this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(12236u));
				}
				break;
			case EActivityKingdomEventType.EAKET_AllianceEvent:
				if (mNoticeRp.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomKillEvent || mNoticeRp.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomMatchEvent)
				{
					this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9845u));
					this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(9840u));
				}
				else if (mNoticeRp.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_FIFA)
				{
					this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(12232u));
					this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(12233u));
				}
				break;
			}
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_ActivityKVKRankPrize:
			switch (mNoticeRp.Enotice_ActivityKVKRankPrize.EventType)
			{
			case EActivityKingdomEventType.EAKET_SoloEvent:
				if (mNoticeRp.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomKillEvent || mNoticeRp.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomMatchEvent)
				{
					this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9846u));
					this.Cstrtext_3[Idx].IntToFormat((long)mNoticeRp.Enotice_ActivityKVKRankPrize.Place, 1, false);
					this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9843u));
				}
				else if (mNoticeRp.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomNormalEvent)
				{
					this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9844u));
					this.Cstrtext_3[Idx].IntToFormat((long)mNoticeRp.Enotice_ActivityKVKRankPrize.Place, 1, false);
					this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9839u));
				}
				else if (mNoticeRp.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_FIFA)
				{
					this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(12235u));
					this.Cstrtext_3[Idx].IntToFormat((long)mNoticeRp.Enotice_ActivityKVKRankPrize.Place, 1, false);
					this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(12237u));
				}
				break;
			case EActivityKingdomEventType.EAKET_AllianceEvent:
				if (mNoticeRp.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomKillEvent || mNoticeRp.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomMatchEvent)
				{
					this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9845u));
					this.Cstrtext_3[Idx].IntToFormat((long)mNoticeRp.Enotice_ActivityKVKRankPrize.Place, 1, false);
					this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9841u));
				}
				else if (mNoticeRp.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_FIFA)
				{
					this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(12232u));
					this.Cstrtext_3[Idx].IntToFormat((long)mNoticeRp.Enotice_ActivityKVKRankPrize.Place, 1, false);
					this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(12234u));
				}
				break;
			}
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_BuyBlackMarketTreasure:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8236u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(9776u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_KickOffTeam:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9914u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			break;
		case NoticeReport.Enotice_AutoDismissWarning:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9557u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(9558u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_AutoDismiss:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9559u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(9560u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_AMRankPrize:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(1339u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].IntToFormat((long)mNoticeRp.Enotice_AMRankPrize.Place, 1, false);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(1366u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_AllianceHomeKingdom:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9567u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			cstring2.Append(mNoticeRp.Enotice_AllianceHomeKingdom.Leader);
			cstring3.Append(mNoticeRp.Enotice_AllianceHomeKingdom.AllianceTag);
			this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
			this.Cstrtext_3[Idx].StringToFormat(cstring);
			this.Cstrtext_3[Idx].IntToFormat((long)mNoticeRp.Enotice_AllianceHomeKingdom.HomeKingdom, 1, false);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9572u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_WorldKingPrize:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(11023u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11024u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_BackendAddCrystal:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8173u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].IntToFormat((long)((ulong)mNoticeRp.Enotice_BackendAddCrystal.Crystal), 1, true);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8174u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_KOWTelItem:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8472u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11040u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_LoginConpensate:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8173u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].IntToFormat((long)((ulong)mNoticeRp.Enotice_LoginConpensate.Crystal), 1, true);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(11041u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_PurchaseConpensate:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8173u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].IntToFormat((long)((ulong)mNoticeRp.Enotice_PurchaseConpensate.Crystal), 1, true);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(11042u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_RallyNPCCancel:
		case NoticeReport.Enotice_RallyNPCCancelInvalid:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6067u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			break;
		case NoticeReport.Enotice_ForceTeleport:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(12053u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			break;
		case NoticeReport.Enotice_LordEquipExpire:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9665u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(mNoticeRp.Enotice_LordEquipExpire.ItemID).EquipName));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_WorldNotKingPrize:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(11023u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			if (mNoticeRp.Enotice_WorldNotKingPrize.Place == 2)
			{
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11051u));
			}
			else if (mNoticeRp.Enotice_WorldNotKingPrize.Place == 3)
			{
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11052u));
			}
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_BuyEmoteTreasure:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8236u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.DM.EquipTable.GetRecordByKey(mNoticeRp.Enotice_BuyEmoteTreasure.ItemID).EquipName));
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(12070u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_LordPoisonEffect:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(15009u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(15010u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_PrisnerUsePoison:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(15011u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			cstring2.Append(mNoticeRp.Enotice_PrisnerUsePoison.Name);
			cstring3.Append(mNoticeRp.Enotice_PrisnerUsePoison.AllianceTag);
			if (mNoticeRp.Enotice_PrisnerUsePoison.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mNoticeRp.Enotice_PrisnerUsePoison.HomeKingdom, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
			}
			this.Cstrtext_3[Idx].StringToFormat(cstring);
			this.Cstrtext_3[Idx].IntToFormat((long)((ulong)(mNoticeRp.Enotice_PrisnerUsePoison.EffectTime / 3600u)), 1, false);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(15012u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_PrisnerPoisonEffect:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(15011u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			cstring2.Append(mNoticeRp.Enotice_PrisnerPoisonEffect.Name);
			cstring3.Append(mNoticeRp.Enotice_PrisnerPoisonEffect.AllianceTag);
			if (mNoticeRp.Enotice_PrisnerPoisonEffect.HomeKingdom != DataManager.MapDataController.kingdomData.kingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mNoticeRp.Enotice_PrisnerPoisonEffect.HomeKingdom, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
			}
			this.Cstrtext_3[Idx].StringToFormat(cstring);
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(15013u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_BackendActivity:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(11053u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11054u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_BuyCastleSkinTreasure:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8236u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(9684u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_FederalRankPrize:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(11091u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			if (mNoticeRp.Enotice_FederalRankPrize.Place == 1)
			{
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11092u));
			}
			if (mNoticeRp.Enotice_FederalRankPrize.Place == 2)
			{
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11108u));
			}
			else if (mNoticeRp.Enotice_FederalRankPrize.Place == 3)
			{
				this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11109u));
			}
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_FederalTelBack:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(11093u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11094u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_RcvGiftRestrict:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(16028u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(16029u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_CancelRcvGiftRestrict:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(16030u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(16031u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_TreasureBackPrize:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8236u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(10077u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_LookingForStringTable:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(mNoticeRp.Enotice_LookingForStringTable.Title));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(mNoticeRp.Enotice_LookingForStringTable.Content));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_MarchingPet_Cancel:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(10106u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			break;
		case NoticeReport.ENotice_PetStarUp:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(10121u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			break;
		case NoticeReport.ENotice_PrisonerPetSkillEscaped:
		{
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6070u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			PetTbl recordByKey = PetManager.Instance.PetTable.GetRecordByKey(mNoticeRp.ENotice_PrisonerPetSkillEscaped.PetID);
			PetSkillTbl recordByKey2 = PetManager.Instance.PetSkillTable.GetRecordByKey(mNoticeRp.ENotice_PrisonerPetSkillEscaped.Skill_ID);
			this.Cstrtext_3[Idx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
			this.Cstrtext_3[Idx].IntToFormat((long)mNoticeRp.ENotice_PrisonerPetSkillEscaped.Skill_LV, 1, false);
			this.Cstrtext_3[Idx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey2.Name));
			if (recordByKey2.Type == 1)
			{
				this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(10114u));
			}
			else
			{
				this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(10116u));
			}
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		}
		case NoticeReport.ENotice_LordPetSkillEscaped:
		{
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6070u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			PetTbl recordByKey3 = PetManager.Instance.PetTable.GetRecordByKey(mNoticeRp.ENotice_LordPetSkillEscaped.PetID);
			PetSkillTbl recordByKey4 = PetManager.Instance.PetSkillTable.GetRecordByKey(mNoticeRp.ENotice_LordPetSkillEscaped.Skill_ID);
			this.Cstrtext_3[Idx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey3.Name));
			this.Cstrtext_3[Idx].IntToFormat((long)mNoticeRp.ENotice_LordPetSkillEscaped.Skill_LV, 1, false);
			this.Cstrtext_3[Idx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey4.Name));
			if (recordByKey4.Type == 1)
			{
				this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(10115u));
			}
			else
			{
				this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(10117u));
			}
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		}
		case NoticeReport.Enotice_FirstUnderPetAttack:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(10101u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(10111u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_ScoutTargetLeave:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(10109u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			break;
		case NoticeReport.Enotice_AttackTargetLeave:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(10108u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.text_3[Idx].text = string.Empty;
			break;
		case NoticeReport.Enotice_MaintainCompensation:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID((uint)mNoticeRp.Enotice_MaintainCompensation.MailTitleStrID));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID((uint)mNoticeRp.Enotice_MaintainCompensation.MailContentStrID));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_BuyRedPocketTreasure:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8236u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)mNoticeRp.Enotice_BuyRedPocketTreasure.StringID));
			this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(11198u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_SocialFriendModify:
		{
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(12177u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			ushort id = 12174;
			if (mNoticeRp.Enotice_SocialFriendModify.PlayerName.Length == 0 && mNoticeRp.Enotice_SocialFriendModify.TargetName.Length == 0)
			{
				if (mNoticeRp.Enotice_SocialFriendModify.RemoveType == 0)
				{
					id = 12196;
				}
				else if (mNoticeRp.Enotice_SocialFriendModify.RemoveType == 1)
				{
					id = 12197;
				}
				if (mNoticeRp.Enotice_SocialFriendModify.RemoveType < 2)
				{
					this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID((uint)id));
				}
			}
			else
			{
				if (mNoticeRp.Enotice_SocialFriendModify.RemoveType == 1)
				{
					id = 12175;
				}
				else if (mNoticeRp.Enotice_SocialFriendModify.RemoveType == 2)
				{
					id = 12176;
				}
				else if (mNoticeRp.Enotice_SocialFriendModify.RemoveType == 3)
				{
					id = 12198;
				}
				cstring2.Append(mNoticeRp.Enotice_SocialFriendModify.PlayerName);
				cstring3.Append(mNoticeRp.Enotice_SocialFriendModify.PlayerTag);
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Enotice_SocialFriendModify.TargetName);
				this.Cstrtext_3[Idx].StringToFormat(cstring);
				this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID((uint)id));
			}
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		}
		case NoticeReport.Enotice_ReturnCeremony:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(10175u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(10176u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		case NoticeReport.Enotice_FirstBuyTreasurePrize:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8236u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(10188u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		default:
			this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(1049u));
			this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
			this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(1049u));
			this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
			break;
		}
		this.text_Time[Idx].text = mNoticeRp.DateTime;
		if (mNoticeRp.BeChecked)
		{
			this.ImgSelect[Idx].gameObject.SetActive(true);
		}
		else
		{
			this.ImgSelect[Idx].gameObject.SetActive(false);
		}
		if (mNoticeRp.BeRead)
		{
			this.ImgNoRead2[Idx].gameObject.SetActive(false);
			this.mtextOutline[Idx].enabled = false;
			this.mtextShadow[Idx].enabled = false;
		}
		else
		{
			this.ImgNoRead2[Idx].gameObject.SetActive(true);
			this.mtextOutline[Idx].enabled = true;
			this.mtextShadow[Idx].enabled = true;
		}
		this.ImgNoRead[Idx].gameObject.SetActive(!mNoticeRp.BeRead);
		this.ImgRead[Idx].gameObject.SetActive(mNoticeRp.BeRead);
	}

	// Token: 0x06001D5A RID: 7514 RVA: 0x0035310C File Offset: 0x0035130C
	public unsafe void CheckTextWidth(UIText mtext, CString Str)
	{
		Font font = mtext.font;
		CharacterInfo characterInfo = default(CharacterInfo);
		float num = 365f;
		font.RequestCharactersInTexture(Str.ToString(), mtext.fontSize);
		int num2 = -1;
		fixed (string text = Str.ToString(), ptr = text + RuntimeHelpers.OffsetToStringData / 2)
		{
			float num3 = 0f;
			int i = 0;
			byte b = 0;
			while (i < Str.Length)
			{
				if (Str[i] == '<' && (Str[i + 1] == 'c' || Str[i + 1] == '/'))
				{
					if (Str[i + 1] == 'c')
					{
						b = 1;
					}
					else if (b == 1)
					{
						b = 0;
					}
					int num4 = 2;
					while (Str[i + num4] != '>' && i + num4 < Str.Length)
					{
						num4++;
					}
					i += num4;
				}
				else
				{
					if (font.GetCharacterInfo(Str[i], out characterInfo, mtext.fontSize))
					{
						num3 += characterInfo.width;
					}
					else
					{
						num3 += 15f;
					}
					if (num3 > num)
					{
						ptr[i] = '.';
						ptr[i + 1] = '.';
						ptr[i + 2] = '.';
						ptr[i + 3] = '\0';
						num2 = i;
						break;
					}
				}
				i++;
			}
			if (num2 != -1 && b == 1)
			{
				Str.Insert(num2, "</color>", -1);
			}
			mtext.text = Str.ToString();
		}
	}

	// Token: 0x06001D5B RID: 7515 RVA: 0x003532AC File Offset: 0x003514AC
	public void GetTextCombatbySide(CombatReportContent mConbat, CString mCstr)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring2.ClearString();
		CString cstring3 = StringManager.Instance.StaticString1024();
		cstring3.ClearString();
		switch (mConbat.Side)
		{
		case 0:
			if (mConbat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER)
			{
				mCstr.Append(this.DM.mStringTable.GetStringByID(6021u));
				mCstr.Append(DataManager.MapDataController.GetYolkName((ushort)mConbat.CombatPoint, mConbat.KingdomID));
			}
			else if (mConbat.Result == CombatReportResultType.ECRR_WONDERVICTORY)
			{
				mCstr.Append(this.DM.mStringTable.GetStringByID(6021u));
				cstring2.Append(mConbat.DefenceName);
				if (mConbat.DefenceAllianceTag != string.Empty)
				{
					cstring3.Append(mConbat.DefenceAllianceTag);
					if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mConbat.DefenceKingdomID, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
					}
				}
				else if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mConbat.DefenceKingdomID, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
				}
				mCstr.Append(cstring);
				mCstr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)mConbat.CombatPoint, mConbat.KingdomID));
				mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(9304u));
			}
			else
			{
				mCstr.Append(this.DM.mStringTable.GetStringByID(6021u));
				cstring2.Append(mConbat.DefenceName);
				if (mConbat.DefenceAllianceTag != string.Empty)
				{
					cstring3.Append(mConbat.DefenceAllianceTag);
					if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mConbat.DefenceKingdomID, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
					}
				}
				else if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mConbat.DefenceKingdomID, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
				}
				if (mConbat.CombatPointKind == POINT_KIND.PK_YOLK)
				{
					mCstr.Append(cstring);
					mCstr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)mConbat.CombatPoint, mConbat.KingdomID));
					mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(9304u));
				}
				else if (this.DM.UserLanguage != GameLanguage.GL_Jpn)
				{
					if (this.GUIM.IsArabic)
					{
						mCstr.StringToFormat(this.GUIM.GetPointName_Letter(mConbat.CombatPointKind));
						mCstr.StringToFormat(cstring);
					}
					else
					{
						mCstr.StringToFormat(cstring);
						mCstr.StringToFormat(this.GUIM.GetPointName_Letter(mConbat.CombatPointKind));
					}
					mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(6022u));
				}
				else
				{
					mCstr.ClearString();
					mCstr.StringToFormat(cstring);
					mCstr.StringToFormat(this.GUIM.GetPointName_Letter(mConbat.CombatPointKind));
					mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(6022u));
					mCstr.Append(this.DM.mStringTable.GetStringByID(6021u));
				}
			}
			break;
		case 1:
			cstring2.Append(mConbat.AssaultName);
			if (mConbat.AssaultAllianceTag != string.Empty)
			{
				cstring3.Append(mConbat.AssaultAllianceTag);
				if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mConbat.AssaultKingdomID, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				}
			}
			else if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mConbat.AssaultKingdomID, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
			}
			if (this.GUIM.IsArabic)
			{
				if (mConbat.CombatPointKind == POINT_KIND.PK_YOLK)
				{
					mCstr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)mConbat.CombatPoint, mConbat.KingdomID));
				}
				else
				{
					mCstr.StringToFormat(this.GUIM.GetPointName_Letter(mConbat.CombatPointKind));
				}
				mCstr.StringToFormat(cstring);
			}
			else
			{
				mCstr.StringToFormat(cstring);
				if (mConbat.CombatPointKind == POINT_KIND.PK_YOLK)
				{
					mCstr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)mConbat.CombatPoint, mConbat.KingdomID));
				}
				else
				{
					mCstr.StringToFormat(this.GUIM.GetPointName_Letter(mConbat.CombatPointKind));
				}
			}
			mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(6020u));
			break;
		case 2:
			if (mConbat.Result != CombatReportResultType.ECRR_TAKEOVERWONDER)
			{
				cstring2.Append(mConbat.AssaultName);
				if (mConbat.AssaultAllianceTag != string.Empty)
				{
					cstring3.Append(mConbat.AssaultAllianceTag);
					if (mConbat.AssaultKingdomID != mConbat.KingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mConbat.AssaultKingdomID, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
					}
				}
				else if (mConbat.AssaultKingdomID != mConbat.KingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mConbat.AssaultKingdomID, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
				}
				CString cstring4 = StringManager.Instance.StaticString1024();
				cstring4.ClearString();
				cstring4.Append(this.DM.mStringTable.GetStringByID(6023u));
				cstring4.StringToFormat(cstring);
				cstring4.AppendFormat(this.DM.mStringTable.GetStringByID(6024u));
				cstring.ClearString();
				cstring2.ClearString();
				cstring3.ClearString();
				cstring2.Append(mConbat.DefenceName);
				if (mConbat.DefenceAllianceTag != string.Empty)
				{
					cstring3.Append(mConbat.DefenceAllianceTag);
					if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mConbat.DefenceKingdomID, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
					}
				}
				else if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mConbat.DefenceKingdomID, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
				}
				mCstr.Append(cstring4);
				if (this.GUIM.IsArabic)
				{
					if (mConbat.CombatPointKind == POINT_KIND.PK_YOLK)
					{
						mCstr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)mConbat.CombatPoint, mConbat.KingdomID));
					}
					else
					{
						mCstr.StringToFormat(this.GUIM.GetPointName_Letter(mConbat.CombatPointKind));
					}
					mCstr.StringToFormat(cstring);
				}
				else
				{
					mCstr.StringToFormat(cstring);
					if (mConbat.CombatPointKind == POINT_KIND.PK_YOLK)
					{
						mCstr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)mConbat.CombatPoint, mConbat.KingdomID));
					}
					else
					{
						mCstr.StringToFormat(this.GUIM.GetPointName_Letter(mConbat.CombatPointKind));
					}
				}
				mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(6022u));
			}
			else
			{
				mCstr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)mConbat.CombatPoint, mConbat.KingdomID));
				mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(4987u));
			}
			break;
		case 3:
		{
			cstring2.Append(mConbat.AssaultName);
			if (mConbat.AssaultAllianceTag != string.Empty)
			{
				cstring3.Append(mConbat.AssaultAllianceTag);
				if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mConbat.AssaultKingdomID, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				}
			}
			else if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mConbat.AssaultKingdomID, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
			}
			CString cstring5 = StringManager.Instance.StaticString1024();
			cstring5.StringToFormat(cstring);
			cstring5.AppendFormat(this.DM.mStringTable.GetStringByID(6025u));
			cstring.ClearString();
			cstring2.ClearString();
			cstring3.ClearString();
			cstring2.Append(mConbat.DefenceName);
			if (mConbat.DefenceAllianceTag != string.Empty)
			{
				cstring3.Append(mConbat.DefenceAllianceTag);
				if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mConbat.DefenceKingdomID, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				}
			}
			else if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mConbat.DefenceKingdomID, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
			}
			mCstr.Append(cstring5);
			mCstr.StringToFormat(cstring);
			mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(6026u));
			break;
		}
		case 4:
		case 6:
			cstring2.Append(mConbat.DefenceName);
			if (mConbat.DefenceAllianceTag != string.Empty)
			{
				cstring3.Append(mConbat.DefenceAllianceTag);
				if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mConbat.DefenceKingdomID, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				}
			}
			else if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mConbat.DefenceKingdomID, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
			}
			mCstr.StringToFormat(cstring);
			mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(9751u));
			break;
		case 5:
			cstring2.Append(mConbat.AssaultName);
			if (mConbat.DefenceAllianceTag != string.Empty)
			{
				cstring3.Append(mConbat.AssaultAllianceTag);
				if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mConbat.AssaultKingdomID, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				}
			}
			else if (mConbat.AssaultKingdomID != mConbat.DefenceKingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mConbat.AssaultKingdomID, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
			}
			mCstr.StringToFormat(cstring);
			mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(9752u));
			break;
		}
	}

	// Token: 0x06001D5C RID: 7516 RVA: 0x00353FB4 File Offset: 0x003521B4
	public void GetTextCombatbySide(NPCCombatReportContent mConbat, CString mCstr)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring2.ClearString();
		CString cstring3 = StringManager.Instance.StaticString1024();
		cstring3.ClearString();
		cstring2.Append(mConbat.AssaultName);
		if (mConbat.AssaultAllianceTag != string.Empty)
		{
			cstring3.Append(mConbat.AssaultAllianceTag);
			if (mConbat.AssaultKingdomID != mConbat.KingdomID)
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, mConbat.AssaultKingdomID, this.GUIM.IsArabic);
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
			}
		}
		else if (mConbat.AssaultKingdomID != mConbat.KingdomID)
		{
			this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, mConbat.AssaultKingdomID, this.GUIM.IsArabic);
		}
		else
		{
			this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
		}
		CString cstring4 = StringManager.Instance.StaticString1024();
		cstring4.ClearString();
		cstring4.Append(this.DM.mStringTable.GetStringByID(6023u));
		cstring4.StringToFormat(cstring);
		cstring4.AppendFormat(this.DM.mStringTable.GetStringByID(6024u));
		cstring.ClearString();
		cstring2.ClearString();
		cstring3.ClearString();
		cstring2.Append(mConbat.NPCLevel.ToString());
		this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
		mCstr.Append(cstring4);
		cstring.ClearString();
		cstring2.ClearString();
		cstring2.IntToFormat((long)mConbat.NPCLevel, 1, false);
		cstring2.AppendFormat(this.DM.mStringTable.GetStringByID(12021u));
		mCstr.Append(cstring);
		mCstr.Append(cstring2);
	}

	// Token: 0x06001D5D RID: 7517 RVA: 0x003541A4 File Offset: 0x003523A4
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001D5E RID: 7518 RVA: 0x003541A8 File Offset: 0x003523A8
	private void Start()
	{
	}

	// Token: 0x06001D5F RID: 7519 RVA: 0x003541AC File Offset: 0x003523AC
	private void Update()
	{
		if (this.Pending && this.DM.MailReportGet(ref this.BattleReport))
		{
			if (this.BattleReport.Combat != null && this.BattleReport.Combat.Type == CombatCollectReport.CCR_MONSTER)
			{
				this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 1, 0, false);
			}
			else
			{
				this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 0, 0, false);
			}
		}
		this.EditorShowTime += Time.smoothDeltaTime;
		if (this.EditorShowTime >= 0f)
		{
			if (this.EditorShowTime >= 2f)
			{
				this.EditorShowTime = 0f;
			}
			float a = (this.EditorShowTime <= 1f) ? this.EditorShowTime : (2f - this.EditorShowTime);
			this.ImgEditor.color = new Color(1f, 1f, 1f, a);
		}
		this.PageShowTime += Time.smoothDeltaTime;
		if (this.PageShowTime >= 2f)
		{
			this.PageShowTime = 0f;
		}
		float a2 = (this.PageShowTime <= 1f) ? this.PageShowTime : (2f - this.PageShowTime);
		this.Img_PageShow[this.NowPage].color = new Color(1f, 1f, 1f, a2);
	}

	// Token: 0x04005999 RID: 22937
	private Transform GameT;

	// Token: 0x0400599A RID: 22938
	private Transform Tmp;

	// Token: 0x0400599B RID: 22939
	private Transform Tmp1;

	// Token: 0x0400599C RID: 22940
	private Transform ItemT;

	// Token: 0x0400599D RID: 22941
	private RectTransform tmpcontentRcT;

	// Token: 0x0400599E RID: 22942
	private RectTransform[] PageImg_RT = new RectTransform[4];

	// Token: 0x0400599F RID: 22943
	private RectTransform[] PageText_RT = new RectTransform[4];

	// Token: 0x040059A0 RID: 22944
	private RectTransform[] Plural_RT = new RectTransform[6];

	// Token: 0x040059A1 RID: 22945
	private UIButton btn_EXIT;

	// Token: 0x040059A2 RID: 22946
	private UIButton btn_Select;

	// Token: 0x040059A3 RID: 22947
	private UIButton btn_WL;

	// Token: 0x040059A4 RID: 22948
	private UIButton btn_Delete;

	// Token: 0x040059A5 RID: 22949
	private UIButton btn_Read;

	// Token: 0x040059A6 RID: 22950
	private UIButton btn_Cancel;

	// Token: 0x040059A7 RID: 22951
	private UIButton[] btn_Page = new UIButton[4];

	// Token: 0x040059A8 RID: 22952
	private UIButton[] btn_ItemDetail = new UIButton[6];

	// Token: 0x040059A9 RID: 22953
	private UIButton[] btn_ItemSelect = new UIButton[6];

	// Token: 0x040059AA RID: 22954
	private UIButton[] btn_ItemCollect = new UIButton[6];

	// Token: 0x040059AB RID: 22955
	private UIButton tmpbtn;

	// Token: 0x040059AC RID: 22956
	private Image tmpImg;

	// Token: 0x040059AD RID: 22957
	private Image ImgFunction;

	// Token: 0x040059AE RID: 22958
	private Image ImgEditor;

	// Token: 0x040059AF RID: 22959
	private Image ImgNoLetter;

	// Token: 0x040059B0 RID: 22960
	private Image[] Img_PageShow = new Image[4];

	// Token: 0x040059B1 RID: 22961
	private Image[] Img_PageIcon = new Image[4];

	// Token: 0x040059B2 RID: 22962
	private Image[] Img_PageUnRead = new Image[4];

	// Token: 0x040059B3 RID: 22963
	private Image[] ImgSelect = new Image[6];

	// Token: 0x040059B4 RID: 22964
	private Image[] ImgNoRead = new Image[6];

	// Token: 0x040059B5 RID: 22965
	private Image[] ImgRead = new Image[6];

	// Token: 0x040059B6 RID: 22966
	private Image[] ImgIcon = new Image[6];

	// Token: 0x040059B7 RID: 22967
	private Image[] ImgBookMark = new Image[6];

	// Token: 0x040059B8 RID: 22968
	private Image[] ImgPlural = new Image[6];

	// Token: 0x040059B9 RID: 22969
	private Image[] ImgNoRead2 = new Image[6];

	// Token: 0x040059BA RID: 22970
	private Image[] ImgLM_Icon = new Image[6];

	// Token: 0x040059BB RID: 22971
	private UIText tmptext;

	// Token: 0x040059BC RID: 22972
	private UIText Title;

	// Token: 0x040059BD RID: 22973
	private UIText NoLetterMsg;

	// Token: 0x040059BE RID: 22974
	private UIText[] text_Time = new UIText[6];

	// Token: 0x040059BF RID: 22975
	private UIText[] text_1 = new UIText[6];

	// Token: 0x040059C0 RID: 22976
	private UIText[] text_2 = new UIText[6];

	// Token: 0x040059C1 RID: 22977
	private UIText[] text_3 = new UIText[6];

	// Token: 0x040059C2 RID: 22978
	private UIText[] text_PluralNoRead = new UIText[6];

	// Token: 0x040059C3 RID: 22979
	private UIText[] text_PluralTotal = new UIText[6];

	// Token: 0x040059C4 RID: 22980
	private UIText[] text_UnRead = new UIText[4];

	// Token: 0x040059C5 RID: 22981
	private CString[] Cstr_PluralTotal = new CString[6];

	// Token: 0x040059C6 RID: 22982
	private CString[] Cstrtext_1 = new CString[6];

	// Token: 0x040059C7 RID: 22983
	private CString[] Cstrtext_2 = new CString[6];

	// Token: 0x040059C8 RID: 22984
	private CString[] Cstrtext_3 = new CString[6];

	// Token: 0x040059C9 RID: 22985
	private Outline[] mtextOutline = new Outline[6];

	// Token: 0x040059CA RID: 22986
	private Shadow[] mtextShadow = new Shadow[6];

	// Token: 0x040059CB RID: 22987
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040059CC RID: 22988
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[6];

	// Token: 0x040059CD RID: 22989
	private DataManager DM;

	// Token: 0x040059CE RID: 22990
	private GUIManager GUIM;

	// Token: 0x040059CF RID: 22991
	private UISpritesArray SArray;

	// Token: 0x040059D0 RID: 22992
	private Font TTFont;

	// Token: 0x040059D1 RID: 22993
	private Door door;

	// Token: 0x040059D2 RID: 22994
	private Material m_Mat;

	// Token: 0x040059D3 RID: 22995
	private List<float> tmplist = new List<float>();

	// Token: 0x040059D4 RID: 22996
	private List<float> Datalist = new List<float>();

	// Token: 0x040059D5 RID: 22997
	private List<bool> btmpList = new List<bool>();

	// Token: 0x040059D6 RID: 22998
	private List<bool> bReadList = new List<bool>();

	// Token: 0x040059D7 RID: 22999
	private List<uint> bCheckList = new List<uint>();

	// Token: 0x040059D8 RID: 23000
	private bool bOpenImg;

	// Token: 0x040059D9 RID: 23001
	private bool Pending;

	// Token: 0x040059DA RID: 23002
	private int AllSelect;

	// Token: 0x040059DB RID: 23003
	private int MaxLetterNum;

	// Token: 0x040059DC RID: 23004
	private MyFavorite BattleReport = new MyFavorite(MailType.EMAIL_MAX, 0u);

	// Token: 0x040059DD RID: 23005
	private int NowPage;

	// Token: 0x040059DE RID: 23006
	private int NowPageKind;

	// Token: 0x040059DF RID: 23007
	private int mIcon;

	// Token: 0x040059E0 RID: 23008
	private float EditorShowTime;

	// Token: 0x040059E1 RID: 23009
	private float PageShowTime;

	// Token: 0x040059E2 RID: 23010
	private Vector2 tmpV;

	// Token: 0x040059E3 RID: 23011
	private int temp;

	// Token: 0x040059E4 RID: 23012
	private int mPluralTotal;

	// Token: 0x040059E5 RID: 23013
	private uint mPluralReplyID;

	// Token: 0x040059E6 RID: 23014
	private string mPluralSenderName;

	// Token: 0x040059E7 RID: 23015
	private string[] Str_HeroColor = new string[4];

	// Token: 0x040059E8 RID: 23016
	private int[] tmpPage = new int[4];

	// Token: 0x040059E9 RID: 23017
	private bool bTrans;
}
