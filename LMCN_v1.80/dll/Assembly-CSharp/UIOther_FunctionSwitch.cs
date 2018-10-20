using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000449 RID: 1097
public class UIOther_FunctionSwitch : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x060015FF RID: 5631 RVA: 0x00257E30 File Offset: 0x00256030
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.m_Mat = this.door.LoadMaterial();
		this.mOpenType = arg1;
		Transform child = this.GameT.GetChild(0).GetChild(0).GetChild(0);
		this.text_tmpStr = child.GetComponent<UIText>();
		this.text_tmpStr.font = this.TTFont;
		if (this.mOpenType == 0)
		{
			this.text_tmpStr.text = this.DM.mStringTable.GetStringByID(7025u);
		}
		else
		{
			this.text_tmpStr.text = this.DM.mStringTable.GetStringByID(7026u);
		}
		child = this.GameT.GetChild(2);
		UIButton component = child.GetChild(1).GetComponent<UIButton>();
		component.m_Handler = this;
		component.SoundIndex = 64;
		this.tmpImg = child.GetChild(2).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.tmpImg.transform.localScale = new Vector3(-1f, this.tmpImg.transform.localScale.y, this.tmpImg.transform.localScale.z);
		}
		this.tmptext = child.GetChild(3).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmptext = child.GetChild(4).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		child = this.GameT.GetChild(3);
		this.m_ScrollPanel = child.GetComponent<ScrollPanel>();
		this.tmplist.Clear();
		child = this.GameT.GetChild(4);
		this.tmptext = child.GetChild(0).GetChild(1).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		component = child.GetChild(1).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.SoundIndex = 64;
		this.tmpImg = child.GetChild(1).GetChild(1).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.tmpImg.transform.localScale = new Vector3(-1f, this.tmpImg.transform.localScale.y, this.tmpImg.transform.localScale.z);
		}
		this.tmptext = child.GetChild(1).GetChild(2).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		if (this.mOpenType == 0)
		{
			this.tmplist.Add(33f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7039u));
			this.mListItemType.Add(FunctionSwitch_Type.e_Title);
			this.tmplist.Add(70f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7052u));
			this.mListItemType.Add(FunctionSwitch_Type.e_ShowMission);
			this.tmplist.Add(33f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7040u));
			this.mListItemType.Add(FunctionSwitch_Type.e_Title);
			this.tmplist.Add(70f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9049u));
			this.mListItemType.Add(FunctionSwitch_Type.e_ShowTrainingIdle);
			this.tmplist.Add(33f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7041u));
			this.mListItemType.Add(FunctionSwitch_Type.e_Title);
			this.tmplist.Add(70f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7054u));
			this.mListItemType.Add(FunctionSwitch_Type.e_ShowBuildingIdle);
			this.tmplist.Add(33f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7042u));
			this.mListItemType.Add(FunctionSwitch_Type.e_Title);
			this.tmplist.Add(70f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7055u));
			this.mListItemType.Add(FunctionSwitch_Type.e_ShowResearchingIdle);
			this.tmplist.Add(33f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(8417u));
			this.mListItemType.Add(FunctionSwitch_Type.e_Title);
			this.tmplist.Add(70f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(8418u));
			this.mListItemType.Add(FunctionSwitch_Type.e_ShowBuildUp);
			this.tmplist.Add(33f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7538u));
			this.mListItemType.Add(FunctionSwitch_Type.e_Title);
			this.tmplist.Add(70f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(7539u));
			this.mListItemType.Add(FunctionSwitch_Type.e_ShowEquipUp);
			this.tmplist.Add(33f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9042u));
			this.mListItemType.Add(FunctionSwitch_Type.e_Title);
			this.tmplist.Add(70f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9043u));
			this.mListItemType.Add(FunctionSwitch_Type.e_ShowArena);
			this.tmplist.Add(33f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9663u));
			this.mListItemType.Add(FunctionSwitch_Type.e_Title);
			this.tmplist.Add(70f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9664u));
			this.mListItemType.Add(FunctionSwitch_Type.e_ShowPrison);
			this.tmplist.Add(33f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9064u));
			this.mListItemType.Add(FunctionSwitch_Type.e_Title);
			this.tmplist.Add(70f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9065u));
			this.mListItemType.Add(FunctionSwitch_Type.e_ShowChatFight);
			this.tmplist.Add(33f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9082u));
			this.mListItemType.Add(FunctionSwitch_Type.e_Title);
			this.tmplist.Add(70f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(9083u));
			this.mListItemType.Add(FunctionSwitch_Type.e_ShowTimeBar);
			this.tmplist.Add(33f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(16073u));
			this.mListItemType.Add(FunctionSwitch_Type.e_Title);
			this.tmplist.Add(70f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(16074u));
			this.mListItemType.Add(FunctionSwitch_Type.e_ShowMainMenu);
			this.tmplist.Add(33f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(10138u));
			this.mListItemType.Add(FunctionSwitch_Type.e_Title);
			this.tmplist.Add(70f);
			this.mListItemStr.Add(this.DM.mStringTable.GetStringByID(10139u));
			this.mListItemType.Add(FunctionSwitch_Type.e_ShowMonsterPointMax);
		}
		else
		{
			this.CheckPushSwitch();
			for (int i = 0; i < this.DM.PushNotification.TableCount; i++)
			{
				this.tmpPushNData = this.DM.PushNotification.GetRecordByIndex((int)((ushort)i));
				if (this.tmpPushNData.PushNType == 0)
				{
					this.tmplist.Add(33f);
					this.mListItemType.Add(FunctionSwitch_Type.e_Title);
				}
				else if (this.tmpPushNData.PushNType == 2)
				{
					this.tmplist.Add(70f);
					this.mListItemType.Add(FunctionSwitch_Type.e_Updata);
				}
				else if (this.tmpPushNData.PushNType == 1)
				{
					this.tmplist.Add(65f);
					this.mListItemType.Add(FunctionSwitch_Type.e_Updata);
				}
				this.mListItemStr.Add(this.DM.mStringTable.GetStringByID((uint)this.tmpPushNData.PushNStr));
			}
		}
		this.m_ScrollPanel.IntiScrollPanel(504f, 10f, 0f, this.tmplist, 12, this);
		this.tmpImg = this.GameT.GetChild(5).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
		this.tmpImg.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(5).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.m_Mat;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001600 RID: 5632 RVA: 0x002588CC File Offset: 0x00256ACC
	public void CheckPushSwitch()
	{
		if (this.DM.mSetNotice != 65535)
		{
			if ((this.DM.mSetNotice & 1) != 1)
			{
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 1UL);
			}
			if ((this.DM.mSetNotice >> 1 & 1) != 1)
			{
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 2UL);
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 4UL);
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 8UL);
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 16UL);
			}
			if ((this.DM.mSetNotice >> 2 & 1) != 1)
			{
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 32UL);
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 64UL);
			}
			if ((this.DM.mSetNotice >> 3 & 1) != 1)
			{
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 32768UL);
			}
			if ((this.DM.mSetNotice >> 4 & 1) != 1)
			{
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 65536UL);
			}
			if ((this.DM.mSetNotice >> 5 & 1) != 1)
			{
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 131072UL);
			}
			if ((this.DM.mSetNotice >> 6 & 1) != 1)
			{
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 262144UL);
			}
			if ((this.DM.mSetNotice >> 7 & 1) != 1)
			{
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 524288UL);
			}
			if ((this.DM.mSetNotice >> 8 & 1) != 1)
			{
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 2048UL);
			}
			if ((this.DM.mSetNotice >> 9 & 1) != 1)
			{
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 256UL);
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 512UL);
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 1024UL);
			}
			if ((this.DM.mSetNotice >> 10 & 1) != 1)
			{
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 2097152UL);
			}
			if ((this.DM.mSetNotice >> 11 & 1) != 1)
			{
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 1048576UL);
			}
			if ((this.DM.mSetNotice >> 12 & 1) != 1)
			{
				this.DM.mNewPushSwitch = (this.DM.mNewPushSwitch | 128UL);
			}
			this.DM.mSetNotice = ushort.MaxValue;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_SET_PUSH_SWITCH;
			messagePacket.AddSeqId();
			messagePacket.Add(this.DM.mSetNotice);
			messagePacket.Send(false);
		}
	}

	// Token: 0x06001601 RID: 5633 RVA: 0x00258C54 File Offset: 0x00256E54
	public void OnButtonClick(UIButton sender)
	{
		GUI_OFS_btn btnID = (GUI_OFS_btn)sender.m_BtnID1;
		if (btnID != GUI_OFS_btn.btn_EXIT)
		{
			if (btnID == GUI_OFS_btn.btn_Item)
			{
				if (this.mOpenType == 0)
				{
					this.SetFunctionSwitch(this.tmpItem[sender.m_BtnID3].m_BtnID1, this.tmpItem[sender.m_BtnID3].m_BtnID2);
				}
				else
				{
					this.SetSysNotice(sender.m_BtnID3, sender.m_BtnID2);
				}
			}
		}
		else if (this.door != null)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001602 RID: 5634 RVA: 0x00258CF0 File Offset: 0x00256EF0
	public void SetFunctionSwitch(int mIdx, int itemIdx)
	{
		if (this.mOpenType == 0)
		{
			switch (this.mListItemType[mIdx])
			{
			case FunctionSwitch_Type.e_ShowMission:
				this.DM.MySysSetting.bShowMission = !this.DM.MySysSetting.bShowMission;
				this.Img_Item[itemIdx].gameObject.SetActive(this.DM.MySysSetting.bShowMission);
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
				break;
			case FunctionSwitch_Type.e_ShowTrainingIdle:
				this.DM.MySysSetting.bShowTrainingIdle = !this.DM.MySysSetting.bShowTrainingIdle;
				this.Img_Item[itemIdx].gameObject.SetActive(this.DM.MySysSetting.bShowTrainingIdle);
				GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
				break;
			case FunctionSwitch_Type.e_ShowBuildingIdle:
				this.DM.MySysSetting.bShowBuildingIdle = !this.DM.MySysSetting.bShowBuildingIdle;
				this.Img_Item[itemIdx].gameObject.SetActive(this.DM.MySysSetting.bShowBuildingIdle);
				break;
			case FunctionSwitch_Type.e_ShowResearchingIdle:
				this.DM.MySysSetting.bShowResearchingIdle = !this.DM.MySysSetting.bShowResearchingIdle;
				this.Img_Item[itemIdx].gameObject.SetActive(this.DM.MySysSetting.bShowResearchingIdle);
				break;
			case FunctionSwitch_Type.e_ShowBuildUp:
				this.DM.MySysSetting.bShowBuildUp = !this.DM.MySysSetting.bShowBuildUp;
				this.Img_Item[itemIdx].gameObject.SetActive(this.DM.MySysSetting.bShowBuildUp);
				GUIManager.Instance.BuildingData.UpdateBuildState(9, 255);
				break;
			case FunctionSwitch_Type.e_ShowEquipUp:
				this.DM.MySysSetting.bShowEquipUp = !this.DM.MySysSetting.bShowEquipUp;
				this.Img_Item[itemIdx].gameObject.SetActive(this.DM.MySysSetting.bShowEquipUp);
				GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
				break;
			case FunctionSwitch_Type.e_ShowArena:
				this.DM.MySysSetting.bShowArena = !this.DM.MySysSetting.bShowArena;
				this.Img_Item[itemIdx].gameObject.SetActive(this.DM.MySysSetting.bShowArena);
				GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
				break;
			case FunctionSwitch_Type.e_ShowChatFight:
				this.DM.MySysSetting.bShowChatFight = !this.DM.MySysSetting.bShowChatFight;
				this.Img_Item[itemIdx].gameObject.SetActive(this.DM.MySysSetting.bShowChatFight);
				break;
			case FunctionSwitch_Type.e_ShowTimeBar:
				this.DM.MySysSetting.bShowTimeBar = !this.DM.MySysSetting.bShowTimeBar;
				this.Img_Item[itemIdx].gameObject.SetActive(this.DM.MySysSetting.bShowTimeBar);
				break;
			case FunctionSwitch_Type.e_ShowPrison:
				this.DM.MySysSetting.bShowPrison = !this.DM.MySysSetting.bShowPrison;
				this.Img_Item[itemIdx].gameObject.SetActive(this.DM.MySysSetting.bShowPrison);
				GUIManager.Instance.BuildingData.UpdateBuildState(11, 255);
				break;
			case FunctionSwitch_Type.e_ShowMainMenu:
				this.DM.MySysSetting.bShowMainMenu = !this.DM.MySysSetting.bShowMainMenu;
				this.Img_Item[itemIdx].gameObject.SetActive(this.DM.MySysSetting.bShowMainMenu);
				break;
			case FunctionSwitch_Type.e_ShowMonsterPointMax:
				this.DM.MySysSetting.bShowMonsterPointMax = !this.DM.MySysSetting.bShowMonsterPointMax;
				this.Img_Item[itemIdx].gameObject.SetActive(this.DM.MySysSetting.bShowMonsterPointMax);
				GameManager.OnRefresh(NetworkNews.Refresh_MonsterPoint, null);
				break;
			}
		}
	}

	// Token: 0x06001603 RID: 5635 RVA: 0x0025914C File Offset: 0x0025734C
	public ulong GetValuebyIdx(int Idx)
	{
		if (Idx < this.DM.PushNotification.TableCount)
		{
			this.tmpPushNData = this.DM.PushNotification.GetRecordByIndex((int)((ushort)Idx));
			if (this.tmpPushNData.PushNType != 0)
			{
				this.tmpValue = 1UL << (int)this.tmpPushNData.PushNswitch;
			}
		}
		return this.tmpValue;
	}

	// Token: 0x06001604 RID: 5636 RVA: 0x002591B4 File Offset: 0x002573B4
	public bool CheckValuebyIdx(int Idx)
	{
		bool result = false;
		if (Idx < this.DM.PushNotification.TableCount)
		{
			this.tmpPushNData = this.DM.PushNotification.GetRecordByIndex((int)((ushort)Idx));
			if (this.tmpPushNData.PushNType != 0)
			{
				result = ((this.DM.mNewPushSwitch >> (int)this.tmpPushNData.PushNswitch & 1UL) != 1UL);
			}
		}
		return result;
	}

	// Token: 0x06001605 RID: 5637 RVA: 0x00259228 File Offset: 0x00257428
	public void SetSysNotice(int itemIdx, int Idx)
	{
		this.tmpValue = this.GetValuebyIdx(Idx);
		if (Idx < this.DM.PushNotification.TableCount)
		{
			this.tmpPushNData = this.DM.PushNotification.GetRecordByIndex((int)((ushort)Idx));
			if (this.tmpPushNData.PushNType != 0)
			{
				this.tmpValue = 1UL << (int)this.tmpPushNData.PushNswitch;
				if ((this.DM.mNewPushSwitch >> (int)this.tmpPushNData.PushNswitch & 1UL) != 1UL)
				{
					this.DM.mNewPushSwitch = this.DM.mNewPushSwitch + this.tmpValue;
					this.Img_Item[itemIdx].gameObject.SetActive(false);
				}
				else
				{
					this.DM.mNewPushSwitch = this.DM.mNewPushSwitch - this.tmpValue;
					this.Img_Item[itemIdx].gameObject.SetActive(true);
				}
			}
		}
	}

	// Token: 0x06001606 RID: 5638 RVA: 0x00259320 File Offset: 0x00257520
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.tmpItem[panelObjectIdx] == null)
		{
			this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			this.Item_TilteT[panelObjectIdx] = this.tmpItem[panelObjectIdx].transform.GetChild(0);
			this.textItem_Title[panelObjectIdx] = this.Item_TilteT[panelObjectIdx].GetChild(1).GetComponent<UIText>();
			this.textItem_Title[panelObjectIdx].font = this.TTFont;
			this.Item_TextT[panelObjectIdx] = this.tmpItem[panelObjectIdx].transform.GetChild(1);
			this.btnItem[panelObjectIdx] = this.Item_TextT[panelObjectIdx].GetChild(0).GetComponent<UIButton>();
			this.btnItem[panelObjectIdx].m_Handler = this;
			this.Img_Item[panelObjectIdx] = this.Item_TextT[panelObjectIdx].GetChild(1).GetComponent<Image>();
			this.textItem[panelObjectIdx] = this.Item_TextT[panelObjectIdx].GetChild(2).GetComponent<UIText>();
			this.textItem[panelObjectIdx].font = this.TTFont;
		}
		this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
		if (this.mListItemType[dataIdx] == FunctionSwitch_Type.e_Title)
		{
			this.Item_TilteT[panelObjectIdx].gameObject.SetActive(true);
			this.Item_TextT[panelObjectIdx].gameObject.SetActive(false);
		}
		else
		{
			this.Item_TilteT[panelObjectIdx].gameObject.SetActive(false);
			this.Item_TextT[panelObjectIdx].gameObject.SetActive(true);
		}
		FunctionSwitch_Type functionSwitch_Type = this.mListItemType[dataIdx];
		if (functionSwitch_Type != FunctionSwitch_Type.e_Title)
		{
			this.textItem[panelObjectIdx].text = this.mListItemStr[dataIdx];
		}
		else
		{
			this.textItem_Title[panelObjectIdx].text = this.mListItemStr[dataIdx];
		}
		this.btnItem[panelObjectIdx].m_BtnID1 = 1;
		this.btnItem[panelObjectIdx].m_BtnID2 = dataIdx;
		this.btnItem[panelObjectIdx].m_BtnID3 = panelObjectIdx;
		if (this.mOpenType == 0)
		{
			switch (this.mListItemType[dataIdx])
			{
			case FunctionSwitch_Type.e_ShowMission:
				this.Img_Item[panelObjectIdx].gameObject.SetActive(this.DM.MySysSetting.bShowMission);
				break;
			case FunctionSwitch_Type.e_ShowTrainingIdle:
				this.Img_Item[panelObjectIdx].gameObject.SetActive(this.DM.MySysSetting.bShowTrainingIdle);
				break;
			case FunctionSwitch_Type.e_ShowBuildingIdle:
				this.Img_Item[panelObjectIdx].gameObject.SetActive(this.DM.MySysSetting.bShowBuildingIdle);
				break;
			case FunctionSwitch_Type.e_ShowResearchingIdle:
				this.Img_Item[panelObjectIdx].gameObject.SetActive(this.DM.MySysSetting.bShowResearchingIdle);
				break;
			case FunctionSwitch_Type.e_ShowBuildUp:
				this.Img_Item[panelObjectIdx].gameObject.SetActive(this.DM.MySysSetting.bShowBuildUp);
				break;
			case FunctionSwitch_Type.e_ShowEquipUp:
				this.Img_Item[panelObjectIdx].gameObject.SetActive(this.DM.MySysSetting.bShowEquipUp);
				break;
			case FunctionSwitch_Type.e_ShowArena:
				this.Img_Item[panelObjectIdx].gameObject.SetActive(this.DM.MySysSetting.bShowArena);
				break;
			case FunctionSwitch_Type.e_ShowChatFight:
				this.Img_Item[panelObjectIdx].gameObject.SetActive(this.DM.MySysSetting.bShowChatFight);
				break;
			case FunctionSwitch_Type.e_ShowTimeBar:
				this.Img_Item[panelObjectIdx].gameObject.SetActive(this.DM.MySysSetting.bShowTimeBar);
				break;
			case FunctionSwitch_Type.e_ShowPrison:
				this.Img_Item[panelObjectIdx].gameObject.SetActive(this.DM.MySysSetting.bShowPrison);
				break;
			case FunctionSwitch_Type.e_ShowMainMenu:
				this.Img_Item[panelObjectIdx].gameObject.SetActive(this.DM.MySysSetting.bShowMainMenu);
				break;
			case FunctionSwitch_Type.e_ShowMonsterPointMax:
				this.Img_Item[panelObjectIdx].gameObject.SetActive(this.DM.MySysSetting.bShowMonsterPointMax);
				break;
			default:
				this.Img_Item[panelObjectIdx].gameObject.SetActive(false);
				break;
			}
		}
		else
		{
			this.btnItem[panelObjectIdx].gameObject.SetActive(true);
			this.Img_Item[panelObjectIdx].gameObject.SetActive(this.CheckValuebyIdx(dataIdx));
		}
	}

	// Token: 0x06001607 RID: 5639 RVA: 0x00259784 File Offset: 0x00257984
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001608 RID: 5640 RVA: 0x00259788 File Offset: 0x00257988
	public override void OnClose()
	{
		if (this.mOpenType == 1)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_SET_NEW_PUSHSWITCH;
			messagePacket.AddSeqId();
			messagePacket.Add(this.DM.mNewPushSwitch);
			messagePacket.Send(false);
		}
		this.DM.SetSysSettingSave();
	}

	// Token: 0x06001609 RID: 5641 RVA: 0x002597E4 File Offset: 0x002579E4
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			if (this.mOpenType == 1)
			{
				this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			}
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
			break;
		}
	}

	// Token: 0x0600160A RID: 5642 RVA: 0x00259844 File Offset: 0x00257A44
	public void Refresh_FontTexture()
	{
		if (this.text_tmpStr != null && this.text_tmpStr.enabled)
		{
			this.text_tmpStr.enabled = false;
			this.text_tmpStr.enabled = true;
		}
		for (int i = 0; i < 12; i++)
		{
			if (this.textItem_Title[i] != null && this.textItem_Title[i].enabled)
			{
				this.textItem_Title[i].enabled = false;
				this.textItem_Title[i].enabled = true;
			}
			if (this.textItem[i] != null && this.textItem[i].enabled)
			{
				this.textItem[i].enabled = false;
				this.textItem[i].enabled = true;
			}
		}
	}

	// Token: 0x0600160B RID: 5643 RVA: 0x00259920 File Offset: 0x00257B20
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 1)
		{
		}
	}

	// Token: 0x0600160C RID: 5644 RVA: 0x00259940 File Offset: 0x00257B40
	private void Start()
	{
	}

	// Token: 0x0600160D RID: 5645 RVA: 0x00259944 File Offset: 0x00257B44
	private void Update()
	{
	}

	// Token: 0x0400414E RID: 16718
	private DataManager DM;

	// Token: 0x0400414F RID: 16719
	private GUIManager GUIM;

	// Token: 0x04004150 RID: 16720
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04004151 RID: 16721
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x04004152 RID: 16722
	private Door door;

	// Token: 0x04004153 RID: 16723
	private Transform GameT;

	// Token: 0x04004154 RID: 16724
	private Transform[] Item_TilteT = new Transform[12];

	// Token: 0x04004155 RID: 16725
	private Transform[] Item_TextT = new Transform[12];

	// Token: 0x04004156 RID: 16726
	private UIButton btn_EXIT;

	// Token: 0x04004157 RID: 16727
	private UIButton[] btnItem = new UIButton[12];

	// Token: 0x04004158 RID: 16728
	private Image tmpImg;

	// Token: 0x04004159 RID: 16729
	private Image[] Img_Item = new Image[12];

	// Token: 0x0400415A RID: 16730
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[12];

	// Token: 0x0400415B RID: 16731
	private UIText tmptext;

	// Token: 0x0400415C RID: 16732
	private UIText text_tmpStr;

	// Token: 0x0400415D RID: 16733
	private UIText[] textItem_Title = new UIText[12];

	// Token: 0x0400415E RID: 16734
	private UIText[] textItem = new UIText[12];

	// Token: 0x0400415F RID: 16735
	private Material m_Mat;

	// Token: 0x04004160 RID: 16736
	private string[] mStr_Title = new string[12];

	// Token: 0x04004161 RID: 16737
	private string[] mStr = new string[12];

	// Token: 0x04004162 RID: 16738
	private List<float> tmplist = new List<float>();

	// Token: 0x04004163 RID: 16739
	private List<string> mListItemStr = new List<string>();

	// Token: 0x04004164 RID: 16740
	private List<FunctionSwitch_Type> mListItemType = new List<FunctionSwitch_Type>();

	// Token: 0x04004165 RID: 16741
	private int mOpenType;

	// Token: 0x04004166 RID: 16742
	private ulong tmpValue;

	// Token: 0x04004167 RID: 16743
	private PushNotificationData tmpPushNData = default(PushNotificationData);
}
