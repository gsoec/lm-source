using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020006A3 RID: 1699
public class UITrap : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUTimeBarOnTimer
{
	// Token: 0x0600207A RID: 8314 RVA: 0x003DA05C File Offset: 0x003D825C
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.AssetName = "BuildingWindow";
		this.m_BW = this.GUIM.AddSpriteAsset(this.AssetName);
		this.AssetName1 = "UI_trap";
		this.m_Arms = this.GUIM.AddSpriteAsset(this.AssetName1);
		this.AssetName2 = "UIBarrack";
		this.GUIM.AddSpriteAsset(this.AssetName2);
		this.m_Barrack = this.GUIM.LoadMaterial(this.AssetName2, "UI_teach_Arrow_m");
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.m_Mat = this.door.LoadMaterial();
		this.mBD = this.GUIM.BuildingData.GetBuildData(12, 0);
		this.mBR = this.GUIM.BuildingData.GetBuildLevelRequestData(12, this.mBD.Level);
		this.UnitMax = this.mBR.Value1;
		for (int i = 0; i < 9; i++)
		{
			this.Cstr_Num[i] = StringManager.Instance.SpawnString(30);
		}
		this.Cstr_TrapValue = StringManager.Instance.SpawnString(30);
		this.Cstr_TimeBar = StringManager.Instance.SpawnString(30);
		this.Cstr_Hint_Info = StringManager.Instance.SpawnString(200);
		for (int j = 0; j < 12; j++)
		{
			this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(j + 17));
			this.tmpStr.ClearString();
			this.tmpStr.IntToFormat((long)this.tmpSD.Icon, 1, false);
			this.tmpStr.AppendFormat("q{0}");
			this.msprite[j] = this.GUIM.LoadSprite(this.AssetName1, this.tmpStr);
		}
		this.mIcon[0] = this.door.LoadSprite("UI_legion_icon_e");
		this.mIcon[1] = this.door.LoadSprite("UI_legion_icon_f");
		this.mIcon[2] = this.door.LoadSprite("UI_legion_icon_g");
		this.mIcon[3] = this.door.LoadSprite("UI_walllist_icon_01");
		Transform child = this.GameT.GetChild(0);
		this.tmpImg = child.GetComponent<Image>();
		this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_04");
		this.tmpImg.material = this.m_BW;
		Transform child2 = child.GetChild(0);
		this.tmpImg = child2.GetComponent<Image>();
		this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_19");
		this.tmpImg.material = this.m_BW;
		this.text_tmpStr[0] = child2.GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(3748u);
		child2 = child.GetChild(1);
		this.tmpImg = child2.GetComponent<Image>();
		this.tmpImg.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_box_99");
		this.tmpImg.material = this.m_BW;
		child2 = child.GetChild(2);
		this.tmpImg = child2.GetComponent<Image>();
		this.tmpImg.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_divider_02");
		this.tmpImg.material = this.m_BW;
		child2 = child.GetChild(3);
		this.timeBar = child2.GetComponent<UITimeBar>();
		this.begin = this.DM.ServerTime;
		this.target = this.DM.SoldierBeginTime + (long)((ulong)this.DM.SoldierNeedTime) - this.begin;
		this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
		this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
		this.timeBar.m_Handler = this;
		this.timeBar.m_TimeBarID = 1;
		this.timeBar.gameObject.SetActive(false);
		this.text_timeBar[0] = child2.GetChild(2).GetComponent<UIText>();
		this.text_timeBar[1] = child2.GetChild(3).GetComponent<UIText>();
		this.text_Manufacturing = child.GetChild(4).GetComponent<UIText>();
		this.text_Manufacturing.font = this.TTFont;
		this.text_Manufacturing.text = this.DM.mStringTable.GetStringByID(3763u);
		this.text_TrapValue = child.GetChild(5).GetComponent<UIText>();
		this.text_TrapValue.font = this.TTFont;
		this.Cstr_TrapValue.ClearString();
		this.Cstr_TrapValue.ClearString();
		this.Cstr_TrapValue.IntToFormat((long)((ulong)this.DM.TrapTotal), 1, true);
		this.Cstr_TrapValue.IntToFormat((long)((ulong)this.UnitMax), 1, true);
		this.Cstr_TrapValue.AppendFormat(this.DM.mStringTable.GetStringByID(3762u));
		this.text_TrapValue.text = this.Cstr_TrapValue.ToString();
		if (this.DM.queueBarData[14].bActive)
		{
			this.begin = this.DM.queueBarData[14].StartTime;
			this.target = this.begin + (long)((ulong)this.DM.queueBarData[14].TotalTime);
			this.notify = 0L;
			int num = (int)(this.DM.TrapKind * 4 + this.DM.TrapRank);
			this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num + 17));
			this.Cstr_TimeBar.ClearString();
			this.Cstr_TimeBar.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
			this.Cstr_TimeBar.IntToFormat((long)((ulong)this.DM.TrapTrainingQty), 1, true);
			this.Cstr_TimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(4048u));
			this.GUIM.SetTimerBar(this.timeBar, this.begin, this.target, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(3764u), this.Cstr_TimeBar.ToString());
			this.timeBar.gameObject.SetActive(true);
		}
		else
		{
			this.text_Manufacturing.gameObject.SetActive(true);
		}
		this.text_tmpStr[1] = child.GetChild(6).GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(3771u);
		this.Img_Hint = child.GetChild(7).GetComponent<Image>();
		this.Img_Hint.sprite = this.mIcon[3];
		this.Img_Hint.material = this.m_Mat;
		this.Img_Hint.gameObject.SetActive(true);
		this.Img_ArmyHint = child.GetChild(8).GetComponent<Image>();
		this.Img_ArmyHint.sprite = this.door.LoadSprite("UI_EO_icon_02");
		this.Img_ArmyHint.material = this.m_Mat;
		UIButtonHint uibuttonHint = this.Img_ArmyHint.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 2;
		this.Img_ArmyHint.gameObject.SetActive(true);
		child = this.GameT.GetChild(1);
		this.m_itemView = child.GetComponent<ScrollPanel>();
		this.m_itemView.m_ScrollPanelID = 1;
		this.tmpImg = child.gameObject.GetComponent<Image>();
		this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_alp");
		this.tmpImg.material = this.m_BW;
		child = this.GameT.GetChild(2);
		for (int k = 0; k < 3; k++)
		{
			child2 = child.GetChild(k);
			UIButton component = child2.GetComponent<UIButton>();
			component.image.sprite = this.GUIM.LoadSprite(this.AssetName1, "q10350");
			component.image.material = this.m_Arms;
			component.m_Handler = this;
			component.m_BtnID1 = k + 1;
			component.SoundIndex = 64;
			component.m_EffectType = e_EffectType.e_Scale;
			component.transition = Selectable.Transition.None;
			this.tmpImg = child2.GetChild(0).GetComponent<Image>();
			this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName1, "q10350");
			this.tmpImg.material = this.m_Arms;
			if (this.GUIM.IsArabic)
			{
				this.tmpImg.transform.localScale = new Vector3(-1f, this.tmpImg.transform.localScale.y, this.tmpImg.transform.localScale.z);
			}
			this.tmpImg = child2.GetChild(1).GetComponent<Image>();
			this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_23");
			this.tmpImg.material = this.m_BW;
			this.tmptext = child2.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			this.tmpImg = child2.GetChild(1).GetChild(1).GetComponent<Image>();
			this.tmpImg.sprite = this.mIcon[0];
			this.tmpImg.material = this.m_Mat;
			this.tmpImg = child2.GetChild(2).GetComponent<Image>();
			this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_20");
			this.tmpImg.material = this.m_BW;
			this.tmptext = child2.GetChild(2).GetChild(0).GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			this.tmpImg = child2.GetChild(3).GetComponent<Image>();
			this.tmpImg.sprite = this.door.LoadSprite("UI_main_lock");
			this.tmpImg.material = this.m_Mat;
			this.tmpImg.SetNativeSize();
		}
		this.tmptext = child.GetChild(3).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		List<float> list = new List<float>();
		for (int l = 0; l < 4; l++)
		{
			list.Add(227f);
		}
		this.m_itemView.IntiScrollPanel(285f, 0f, 20f, list, 3, this);
		this.m_ItemConet = this.m_itemView.transform.GetChild(0).GetComponent<RectTransform>();
		if (this.GUIM.UIBarrack_TrapY > -1f)
		{
			this.m_itemView.GoTo(0, this.GUIM.UIBarrack_TrapY);
		}
		child = this.GameT.GetChild(3);
		this.BG = child.GetComponent<Image>();
		this.BG.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_divider_02");
		this.BG.material = this.m_BW;
		this.Img_Hint_Info = child.GetChild(0).GetComponent<Image>();
		this.Img_Hint_Info.sprite = this.door.LoadSprite("UI_main_box_012");
		this.Img_Hint_Info.material = this.m_Mat;
		uibuttonHint = this.Img_Hint.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = this.Img_Hint_Info.gameObject;
		uibuttonHint.Parm1 = 1;
		this.text_Hint_Info = child.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_Hint_Info.font = this.TTFont;
		this.Cstr_Hint_Info.ClearString();
		this.Cstr_Hint_Info.StringToFormat(this.DM.mStringTable.GetStringByID(3895u));
		this.Cstr_Hint_Info.AppendFormat(this.DM.mStringTable.GetStringByID(11157u));
		this.text_Hint_Info.text = this.Cstr_Hint_Info.ToString();
		this.text_Hint_Info.SetAllDirty();
		this.text_Hint_Info.cachedTextGenerator.Invalidate();
		this.text_Hint_Info.cachedTextGeneratorForLayout.Invalidate();
		this.text_Hint_Info.rectTransform.sizeDelta = new Vector2(this.text_Hint_Info.rectTransform.sizeDelta.x, this.text_Hint_Info.preferredHeight + 1f);
		this.Img_Hint_Info.rectTransform.sizeDelta = new Vector2(this.Img_Hint_Info.rectTransform.sizeDelta.x, this.text_Hint_Info.preferredHeight + 21f);
		child = this.GameT.GetChild(4);
		this.m_itemView2 = child.GetComponent<ScrollPanel>();
		this.m_itemView2.m_ScrollPanelID = 2;
		this.tmpImg = child.GetComponent<Image>();
		this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName2, "UI_lett_alpha_d002");
		this.tmpImg.material = this.m_Barrack;
		child = this.GameT.GetChild(5);
		child2 = child.GetChild(0);
		this.tmpImg = child2.GetComponent<Image>();
		this.tmpImg.sprite = this.GUIM.LoadSprite(this.AssetName2, "UI_new_arrow_01");
		this.tmpImg.material = this.m_Barrack;
		this.m_itemView2.IntiScrollPanel(285f, 0f, 20f, list, 3, this);
		this.m_ItemX = this.m_itemView2.transform.GetComponent<RectTransform>();
		this.m_ItemConetY = this.m_itemView2.transform.GetChild(0).GetComponent<RectTransform>();
		if (this.GUIM.BuildingData.GuideSoldierID != 0)
		{
			this.GuideSoldierID = this.GUIM.BuildingData.GuideSoldierID;
			this.m_itemView2.gameObject.SetActive(true);
			this.m_itemView.GoTo((int)((this.GuideSoldierID - 17) % 4));
			this.m_itemView2.GoTo((int)((this.GuideSoldierID - 17) % 4));
			this.m_ItemX.anchoredPosition = new Vector2((float)(-376 + (int)(241 * ((this.GuideSoldierID - 17) / 4))), this.m_ItemX.anchoredPosition.y);
			this.GUIM.BuildingData.GuideSoldierID = 0;
		}
		this.tmpImg = this.GameT.GetChild(6).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
		this.tmpImg.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(6).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.m_Mat;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x0600207B RID: 8315 RVA: 0x003DB0A4 File Offset: 0x003D92A4
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
		case 3:
		{
			this.GUIM.UIBarrack_TrapY = this.m_ItemConet.anchoredPosition.y;
			Transform parent = sender.gameObject.transform.parent;
			int arg = 17 + parent.GetComponent<ScrollPanelItem>().m_BtnID1 + (sender.m_BtnID1 - 1) * 4;
			this.door.OpenMenu(EGUIWindow.UI_Barrack_Soldier, arg, 0, false);
			break;
		}
		}
	}

	// Token: 0x0600207C RID: 8316 RVA: 0x003DB154 File Offset: 0x003D9354
	public void OnButtonDown(UIButtonHint sender)
	{
		if (sender.Parm1 == 1)
		{
			this.Img_Hint_Info.gameObject.SetActive(true);
		}
		else
		{
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintArmy, 0, 0f, 0, 1, 0, Vector2.zero, UIButtonHint.ePosition.Original);
		}
	}

	// Token: 0x0600207D RID: 8317 RVA: 0x003DB1A4 File Offset: 0x003D93A4
	public void OnButtonUp(UIButtonHint sender)
	{
		this.Img_Hint_Info.gameObject.SetActive(false);
		GUIManager.Instance.m_Hint.Hide(true);
	}

	// Token: 0x0600207E RID: 8318 RVA: 0x003DB1C8 File Offset: 0x003D93C8
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelId == 1)
		{
			if (this.tmpItem[panelObjectIdx] == null)
			{
				this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
				this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
				Transform child;
				for (int i = 0; i < 3; i++)
				{
					int num = panelObjectIdx * 3 + i;
					int num2 = this.tmpItem[panelObjectIdx].m_BtnID1 + i * 4 + 16;
					this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num2 + 1));
					child = item.transform.GetChild(i);
					this.tmpItemBtn[num] = child.GetComponent<UIButton>();
					this.tmpItemBtn[num].m_Handler = this;
					this.tmpItemBtn[num].image.material = this.m_Arms;
					Transform child2 = child.GetChild(0);
					this.tmpItemImg_Soldier[num] = child2.GetComponent<Image>();
					this.tmpItemImg_Soldier[num].material = this.m_Arms;
					child2 = child.GetChild(1).GetChild(0);
					this.tmpItemtextName[num] = child2.GetComponent<UIText>();
					child2 = child.GetChild(1).GetChild(1);
					this.tmpItemIcon[num] = child2.GetComponent<Image>();
					if (num2 / 4 - 4 < 3)
					{
						this.tmpItemIcon[num].sprite = this.mIcon[num2 / 4 - 4];
					}
					this.tmpItemIcon[num].gameObject.SetActive(true);
					this.tmpItemtextName[num].rectTransform.anchoredPosition = new Vector2(-52f, this.tmpItemtextName[num].rectTransform.anchoredPosition.y);
					this.tmpItemtextName[num].rectTransform.sizeDelta = new Vector2(139f, this.tmpItemtextName[num].rectTransform.sizeDelta.y);
					child2 = child.GetChild(2).GetChild(0);
					this.tmpItemtextNum[num] = child2.GetComponent<UIText>();
					child2 = child.GetChild(3);
					this.tmpItemImg[num] = child2.GetComponent<Image>();
				}
				child = this.tmpItem[panelObjectIdx].transform.GetChild(3);
				this.tmpItemtextTitle[panelObjectIdx] = child.GetComponent<UIText>();
				this.tmpItemtextTitle[panelObjectIdx].font = this.TTFont;
			}
			for (int j = 0; j < 3; j++)
			{
				int num = panelObjectIdx * 3 + j;
				int num2 = this.tmpItem[panelObjectIdx].m_BtnID1 + j * 4 + 16;
				this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num2 + 1));
				this.tmpItemBtn[num].image.sprite = this.msprite[num2 - 16];
				this.tmpItemImg_Soldier[num].sprite = this.msprite[num2 - 16];
				this.tmpItemtextName[num].text = this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name);
				this.Cstr_Num[num].ClearString();
				GameConstants.FormatResourceValue(this.Cstr_Num[num], this.DM.mTrapQty[num2 - 16]);
				this.tmpItemtextNum[num].text = this.Cstr_Num[num].ToString();
				if (this.tmpSD.Science != 0 && this.DM.GetTechLevel(this.tmpSD.Science) == 0)
				{
					this.tmpItemImg_Soldier[num].color = Color.gray;
					this.tmpItemImg[num].gameObject.SetActive(true);
				}
				else
				{
					this.tmpItemImg_Soldier[num].color = Color.white;
					this.tmpItemImg[num].gameObject.SetActive(false);
				}
			}
			this.tmpItemtextTitle[panelObjectIdx].text = this.DM.mStringTable.GetStringByID((uint)(3767 + item.GetComponent<ScrollPanelItem>().m_BtnID1));
		}
		else if (dataIdx == (int)((this.GuideSoldierID - 17) % 4))
		{
			item.transform.GetChild(0).gameObject.SetActive(true);
		}
		else
		{
			item.transform.GetChild(0).gameObject.SetActive(false);
		}
	}

	// Token: 0x0600207F RID: 8319 RVA: 0x003DB5EC File Offset: 0x003D97EC
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06002080 RID: 8320 RVA: 0x003DB5F0 File Offset: 0x003D97F0
	public override void OnClose()
	{
		if (this.AssetName != null)
		{
			this.GUIM.RemoveSpriteAsset(this.AssetName);
		}
		if (this.AssetName1 != null)
		{
			this.GUIM.RemoveSpriteAsset(this.AssetName1);
		}
		if (this.AssetName2 != null)
		{
			this.GUIM.RemoveSpriteAsset(this.AssetName2);
		}
		this.GUIM.UIBarrack_TrapY = this.m_ItemConet.anchoredPosition.y;
		if (this.Cstr_TrapValue != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_TrapValue);
		}
		if (this.Cstr_TimeBar != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_TimeBar);
		}
		if (this.Cstr_Hint_Info != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Hint_Info);
		}
		for (int i = 0; i < 9; i++)
		{
			if (this.Cstr_Num[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Num[i]);
			}
		}
		if (this.timeBar != null)
		{
			this.GUIM.RemoverTimeBaarToList(this.timeBar);
		}
	}

	// Token: 0x06002081 RID: 8321 RVA: 0x003DB718 File Offset: 0x003D9918
	public void OnTimer(UITimeBar sender)
	{
	}

	// Token: 0x06002082 RID: 8322 RVA: 0x003DB71C File Offset: 0x003D991C
	public void OnNotify(UITimeBar sender)
	{
	}

	// Token: 0x06002083 RID: 8323 RVA: 0x003DB720 File Offset: 0x003D9920
	public void Onfunc(UITimeBar sender)
	{
		if (sender.m_TimerSpriteType == eTimerSpriteType.Speed)
		{
			this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 14, false);
		}
	}

	// Token: 0x06002084 RID: 8324 RVA: 0x003DB740 File Offset: 0x003D9940
	public void OnCancel(UITimeBar sender)
	{
		this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(3735u), this.DM.mStringTable.GetStringByID(3766u), 4, 0, this.DM.mStringTable.GetStringByID(3925u), this.DM.mStringTable.GetStringByID(3926u));
	}

	// Token: 0x06002085 RID: 8325 RVA: 0x003DB7B0 File Offset: 0x003D99B0
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 == 4)
			{
				if (GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
				{
					MessagePacket messagePacket = new MessagePacket(1024);
					messagePacket.Protocol = Protocol._MSG_REQUEST_CANCELTRAPCONSTRUCT;
					messagePacket.AddSeqId();
					messagePacket.Send(false);
				}
			}
		}
	}

	// Token: 0x06002086 RID: 8326 RVA: 0x003DB80C File Offset: 0x003D9A0C
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews != NetworkNews.Refresh_Trap)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
					if (this.timeBar != null && this.timeBar.enabled)
					{
						this.timeBar.Refresh_FontTexture();
					}
				}
			}
			else
			{
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						int num = j * 4 + this.tmpItem[i].m_BtnID1;
						this.tmpString.Length = 0;
						GameConstants.FormatResourceValue(this.tmpString, this.DM.mTrapQty[num]);
						this.tmpItemtextNum[i * 3 + j].text = this.tmpString.ToString();
					}
				}
				this.UnitMax = this.DM.GetMaxTrapValue();
				this.Cstr_TrapValue.ClearString();
				this.Cstr_TrapValue.IntToFormat((long)((ulong)this.DM.TrapTotal), 1, true);
				this.Cstr_TrapValue.IntToFormat((long)((ulong)this.UnitMax), 1, true);
				this.Cstr_TrapValue.AppendFormat(this.DM.mStringTable.GetStringByID(3762u));
				this.text_TrapValue.text = this.Cstr_TrapValue.ToString();
				this.text_TrapValue.SetAllDirty();
				this.text_TrapValue.cachedTextGenerator.Invalidate();
			}
			break;
		}
	}

	// Token: 0x06002087 RID: 8327 RVA: 0x003DB99C File Offset: 0x003D9B9C
	public void Refresh_FontTexture()
	{
		if (this.text_TrapValue != null && this.text_TrapValue.enabled)
		{
			this.text_TrapValue.enabled = false;
			this.text_TrapValue.enabled = true;
		}
		if (this.text_Manufacturing != null && this.text_Manufacturing.enabled)
		{
			this.text_Manufacturing.enabled = false;
			this.text_Manufacturing.enabled = true;
		}
		if (this.text_Hint_Info != null && this.text_Hint_Info.enabled)
		{
			this.text_Hint_Info.enabled = false;
			this.text_Hint_Info.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_tmpStr[i] != null && this.text_tmpStr[i].enabled)
			{
				this.text_tmpStr[i].enabled = false;
				this.text_tmpStr[i].enabled = true;
			}
			if (this.text_timeBar[i] != null && this.text_timeBar[i].enabled)
			{
				this.text_timeBar[i].enabled = false;
				this.text_timeBar[i].enabled = true;
			}
		}
		for (int j = 0; j < 3; j++)
		{
			if (this.tmpItemtextTitle[j] != null && this.tmpItemtextTitle[j].enabled)
			{
				this.tmpItemtextTitle[j].enabled = false;
				this.tmpItemtextTitle[j].enabled = true;
			}
		}
		for (int k = 0; k < 9; k++)
		{
			if (this.tmpItemtextNum[k] != null && this.tmpItemtextNum[k].enabled)
			{
				this.tmpItemtextNum[k].enabled = false;
				this.tmpItemtextNum[k].enabled = true;
			}
			if (this.tmpItemtextName[k] != null && this.tmpItemtextName[k].enabled)
			{
				this.tmpItemtextName[k].enabled = false;
				this.tmpItemtextName[k].enabled = true;
			}
		}
	}

	// Token: 0x06002088 RID: 8328 RVA: 0x003DBBD0 File Offset: 0x003D9DD0
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 1)
		{
			if (arg1 == 2)
			{
				int num = (int)(this.DM.TrapKind * 4 + this.DM.TrapRank);
				this.tmpString.Length = 0;
				GameConstants.FormatResourceValue(this.tmpString, this.DM.mTrapQty[num]);
				for (int i = 0; i < 3; i++)
				{
					if (this.tmpItem[i].m_BtnID2 == (int)this.DM.TrapRank && i == (int)this.DM.TrapKind)
					{
						this.tmpItemtextNum[i * 3 + (int)this.DM.TrapKind].text = this.tmpString.ToString();
					}
				}
				this.UnitMax = this.DM.GetMaxTrapValue();
				this.Cstr_TrapValue.ClearString();
				this.Cstr_TrapValue.IntToFormat((long)((ulong)this.DM.TrapTotal), 1, true);
				this.Cstr_TrapValue.IntToFormat((long)((ulong)this.UnitMax), 1, true);
				this.Cstr_TrapValue.AppendFormat(this.DM.mStringTable.GetStringByID(3762u));
				this.text_TrapValue.text = this.Cstr_TrapValue.ToString();
				this.text_TrapValue.SetAllDirty();
				this.text_TrapValue.cachedTextGenerator.Invalidate();
			}
		}
		else if (this.DM.queueBarData[14].bActive)
		{
			long startTime = this.DM.queueBarData[14].StartTime;
			long num2 = startTime + (long)((ulong)this.DM.queueBarData[14].TotalTime);
			long notifyTime = 0L;
			int num3 = (int)(this.DM.TrapKind * 4 + this.DM.TrapRank);
			this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num3 + 17));
			this.Cstr_TimeBar.ClearString();
			this.Cstr_TimeBar.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name));
			this.Cstr_TimeBar.IntToFormat((long)((ulong)this.DM.TrapQuantity), 1, true);
			this.Cstr_TimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(4048u));
			this.GUIM.SetTimerBar(this.timeBar, startTime, num2, notifyTime, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(3764u), this.Cstr_TimeBar.ToString());
			this.timeBar.gameObject.SetActive(true);
			this.text_Manufacturing.gameObject.SetActive(false);
		}
		else
		{
			this.GUIM.RemoverTimeBaarToList(this.timeBar);
			this.timeBar.gameObject.SetActive(false);
			this.text_Manufacturing.gameObject.SetActive(true);
		}
	}

	// Token: 0x06002089 RID: 8329 RVA: 0x003DBECC File Offset: 0x003DA0CC
	private void Start()
	{
	}

	// Token: 0x0600208A RID: 8330 RVA: 0x003DBED0 File Offset: 0x003DA0D0
	private void Update()
	{
		if (this.m_itemView2.gameObject.activeSelf)
		{
			this.m_ItemConetY.anchoredPosition = new Vector2(this.m_ItemConetY.anchoredPosition.x, this.m_ItemConet.anchoredPosition.y);
		}
	}

	// Token: 0x0400666D RID: 26221
	private DataManager DM;

	// Token: 0x0400666E RID: 26222
	private GUIManager GUIM;

	// Token: 0x0400666F RID: 26223
	private ScrollPanel m_itemView;

	// Token: 0x04006670 RID: 26224
	private RectTransform m_ItemConet;

	// Token: 0x04006671 RID: 26225
	private ScrollPanel m_itemView2;

	// Token: 0x04006672 RID: 26226
	private RectTransform m_ItemX;

	// Token: 0x04006673 RID: 26227
	private RectTransform m_ItemConetY;

	// Token: 0x04006674 RID: 26228
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x04006675 RID: 26229
	private string AssetName;

	// Token: 0x04006676 RID: 26230
	private string AssetName1;

	// Token: 0x04006677 RID: 26231
	private string AssetName2;

	// Token: 0x04006678 RID: 26232
	private Door door;

	// Token: 0x04006679 RID: 26233
	private Material m_BW;

	// Token: 0x0400667A RID: 26234
	private Material m_Arms;

	// Token: 0x0400667B RID: 26235
	private Material m_Mat;

	// Token: 0x0400667C RID: 26236
	private Material m_Barrack;

	// Token: 0x0400667D RID: 26237
	private Transform GameT;

	// Token: 0x0400667E RID: 26238
	private UIButton btn_EXIT;

	// Token: 0x0400667F RID: 26239
	private Image BG;

	// Token: 0x04006680 RID: 26240
	private Image tmpImg;

	// Token: 0x04006681 RID: 26241
	private Image Img_Hint_Info;

	// Token: 0x04006682 RID: 26242
	private Image Img_Hint;

	// Token: 0x04006683 RID: 26243
	private Image Img_ArmyHint;

	// Token: 0x04006684 RID: 26244
	private UIText tmptext;

	// Token: 0x04006685 RID: 26245
	private UIText text_TrapValue;

	// Token: 0x04006686 RID: 26246
	private UIText text_Manufacturing;

	// Token: 0x04006687 RID: 26247
	private UIText text_Hint_Info;

	// Token: 0x04006688 RID: 26248
	private UIText[] text_tmpStr = new UIText[2];

	// Token: 0x04006689 RID: 26249
	private UIText[] text_timeBar = new UIText[2];

	// Token: 0x0400668A RID: 26250
	private UITimeBar timeBar;

	// Token: 0x0400668B RID: 26251
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[3];

	// Token: 0x0400668C RID: 26252
	private UIButton[] tmpItemBtn = new UIButton[9];

	// Token: 0x0400668D RID: 26253
	private Image[] tmpItemImg_Soldier = new Image[9];

	// Token: 0x0400668E RID: 26254
	private Image[] tmpItemImg = new Image[9];

	// Token: 0x0400668F RID: 26255
	private Image[] tmpItemIcon = new Image[9];

	// Token: 0x04006690 RID: 26256
	private UIText[] tmpItemtextNum = new UIText[9];

	// Token: 0x04006691 RID: 26257
	private UIText[] tmpItemtextName = new UIText[9];

	// Token: 0x04006692 RID: 26258
	private UIText[] tmpItemtextTitle = new UIText[3];

	// Token: 0x04006693 RID: 26259
	private CString tmpStr = StringManager.Instance.StaticString1024();

	// Token: 0x04006694 RID: 26260
	private CString Cstr_TrapValue;

	// Token: 0x04006695 RID: 26261
	private CString Cstr_TimeBar;

	// Token: 0x04006696 RID: 26262
	private CString Cstr_Hint_Info;

	// Token: 0x04006697 RID: 26263
	private CString[] Cstr_Num = new CString[9];

	// Token: 0x04006698 RID: 26264
	private long begin;

	// Token: 0x04006699 RID: 26265
	private long target;

	// Token: 0x0400669A RID: 26266
	private long notify;

	// Token: 0x0400669B RID: 26267
	private SoldierData tmpSD;

	// Token: 0x0400669C RID: 26268
	private StringBuilder tmpString = new StringBuilder();

	// Token: 0x0400669D RID: 26269
	private RoleBuildingData mBD;

	// Token: 0x0400669E RID: 26270
	private BuildLevelRequest mBR;

	// Token: 0x0400669F RID: 26271
	private uint UnitMax;

	// Token: 0x040066A0 RID: 26272
	private ushort GuideSoldierID;

	// Token: 0x040066A1 RID: 26273
	private Sprite[] msprite = new Sprite[12];

	// Token: 0x040066A2 RID: 26274
	private Sprite[] mIcon = new Sprite[4];
}
