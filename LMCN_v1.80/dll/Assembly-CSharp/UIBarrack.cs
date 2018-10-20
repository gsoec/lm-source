using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004F0 RID: 1264
public class UIBarrack : GUIWindow, IBuildingWindowType, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUTimeBarOnTimer
{
	// Token: 0x06001943 RID: 6467 RVA: 0x002A900C File Offset: 0x002A720C
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
		{
			this.BG.gameObject.SetActive(true);
			this.BG1.gameObject.SetActive(true);
			this.m_itemView.gameObject.SetActive(true);
			if (this.GuideSoldierID != 0)
			{
				this.m_itemView2.gameObject.SetActive(true);
			}
			if (!this.bTraining)
			{
				this.text_Training.gameObject.SetActive(true);
			}
		}
		else
		{
			this.m_ScrollRect.StopMovement();
			this.BG.gameObject.SetActive(false);
			this.BG1.gameObject.SetActive(false);
			this.m_itemView.gameObject.SetActive(false);
			this.m_itemView2.gameObject.SetActive(false);
			this.GuideSoldierID = 0;
			this.DM.GuideSoldierNum = 0;
			if (!this.bTraining)
			{
				this.text_Training.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001944 RID: 6468 RVA: 0x002A9128 File Offset: 0x002A7328
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.B_ID = arg1;
		this.AssetName = "BuildingWindow";
		this.m_BW = this.GUIM.AddSpriteAsset(this.AssetName);
		this.AssetName1 = "UI_arms";
		this.m_Arms = this.GUIM.AddSpriteAsset(this.AssetName1);
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.Cstr_Total = StringManager.Instance.SpawnString(30);
		Transform child = this.GameT.GetChild(0);
		this.BG = child.GetComponent<Image>();
		this.BG.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_04");
		this.BG.material = this.m_BW;
		Transform child2 = child.GetChild(0);
		this.timeBar = child2.GetComponent<UITimeBar>();
		long num = this.DM.ServerTime;
		long target = this.DM.SoldierBeginTime + (long)((ulong)this.DM.SoldierNeedTime) - num;
		this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
		this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
		this.timeBar.m_Handler = this;
		this.timeBar.m_TimeBarID = 1;
		this.timeBar.gameObject.SetActive(false);
		child2 = child.GetChild(1);
		this.text_Training = child2.GetComponent<UIText>();
		this.text_Training.font = this.TTFont;
		this.text_Training.text = this.DM.mStringTable.GetStringByID(3833u);
		if (this.DM.queueBarData[10].bActive)
		{
			num = this.DM.queueBarData[10].StartTime;
			target = num + (long)((ulong)this.DM.queueBarData[10].TotalTime);
			long notifyTime = 0L;
			int num2 = (int)(this.DM.SoldierKind * 4 + this.DM.SoldierRank);
			this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num2 + 1));
			CString cstring = StringManager.Instance.StaticString1024();
			StringManager.IntToStr(cstring, (long)((ulong)this.DM.SoldierTrainingQty), 1, true);
			this.tmpString.Length = 0;
			this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(4048u), this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name), cstring.ToString());
			this.GUIM.SetTimerBar(this.timeBar, num, target, notifyTime, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(4047u), this.tmpString.ToString());
			this.timeBar.gameObject.SetActive(true);
			this.text_Training.gameObject.SetActive(false);
			this.bTraining = true;
		}
		child2 = child.GetChild(2);
		this.text_Total = child2.GetComponent<UIText>();
		this.text_Total.font = this.TTFont;
		this.SoldierTotal = this.DM.SoldierTotal;
		this.Cstr_Total.ClearString();
		this.Cstr_Total.IntToFormat(this.SoldierTotal, 1, true);
		this.Cstr_Total.AppendFormat(this.DM.mStringTable.GetStringByID(3873u));
		this.text_Total.text = this.Cstr_Total.ToString();
		child2 = child.GetChild(3);
		this.BGArmy = child2.GetComponent<Image>();
		this.BGArmy.sprite = this.door.LoadSprite("UI_EO_icon_01");
		this.BGArmy.material = this.door.LoadMaterial();
		UIButtonHint uibuttonHint = this.BGArmy.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 1;
		this.BGArmy.gameObject.SetActive(true);
		child = this.GameT.GetChild(1);
		this.m_itemView = child.GetComponent<ScrollPanel>();
		this.m_itemView.m_ScrollPanelID = 1;
		Image component = child.gameObject.GetComponent<Image>();
		component.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_alp");
		component.material = this.m_BW;
		child = this.GameT.GetChild(2);
		for (int i = 0; i < 4; i++)
		{
			child2 = child.GetChild(i);
			UIButton component2 = child2.GetComponent<UIButton>();
			component2.image.sprite = this.GUIM.LoadSprite("UI_arms", "q10010");
			component2.image.material = this.m_Arms;
			component2.image.type = Image.Type.Simple;
			component2.m_Handler = this;
			component2.m_BtnID1 = i + 1;
			component2.SoundIndex = 64;
			component2.m_EffectType = e_EffectType.e_Scale;
			component2.transition = Selectable.Transition.None;
			Transform child3 = child2.GetChild(0);
			component = child3.GetComponent<Image>();
			component.sprite = this.GUIM.LoadSprite("UI_arms", "q10010");
			component.material = this.m_Arms;
			if (this.GUIM.IsArabic)
			{
				component.transform.localScale = new Vector3(-1f, component.transform.localScale.y, component.transform.localScale.z);
			}
			child3 = child2.GetChild(1);
			component = child3.GetComponent<Image>();
			component.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_23");
			component.material = this.m_BW;
			Transform child4 = child3.GetChild(0);
			UIText component3 = child4.GetComponent<UIText>();
			component3.font = this.TTFont;
			child3 = child2.GetChild(2);
			component = child3.GetComponent<Image>();
			component.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_20");
			component.material = this.m_BW;
			child4 = child3.GetChild(0);
			component3 = child4.GetComponent<UIText>();
			component3.font = this.TTFont;
			child3 = child2.GetChild(3);
			component = child3.GetComponent<Image>();
			component.sprite = this.door.LoadSprite("UI_main_lock");
			component.material = this.door.LoadMaterial();
			component.SetNativeSize();
		}
		List<float> list = new List<float>();
		for (int j = 0; j < 4; j++)
		{
			list.Add(227f);
		}
		this.m_itemView.IntiScrollPanel(285f, 0f, 20f, list, 3, this);
		this.m_ScrollRect = this.m_itemView.GetComponent<CScrollRect>();
		this.m_ItemConet = this.m_itemView.transform.GetChild(0).GetComponent<RectTransform>();
		if (this.GUIM.UIBarrack_Y > -1f)
		{
			this.m_itemView.GoTo(0, this.GUIM.UIBarrack_Y);
		}
		child = this.GameT.GetChild(3);
		this.BG1 = child.GetComponent<Image>();
		this.BG1.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_divider_02");
		this.BG1.material = this.m_BW;
		child = this.GameT.GetChild(4);
		this.m_itemView2 = child.GetComponent<ScrollPanel>();
		this.m_itemView2.m_ScrollPanelID = 2;
		child = this.GameT.GetChild(5);
		child2 = child.GetChild(0);
		this.m_itemView2.IntiScrollPanel(285f, 0f, 20f, list, 3, this);
		this.m_ItemX = this.m_itemView2.transform.GetComponent<RectTransform>();
		this.m_ItemConetY = this.m_itemView2.transform.GetChild(0).GetComponent<RectTransform>();
		if (!NewbieManager.IsWorking())
		{
			NewbieManager.EntryTeach(ETeachKind.SPAWN_SOLDIERS);
		}
		if (this.GUIM.BuildingData.GuideSoldierID > 0 && this.GUIM.BuildingData.GuideSoldierID < 17 && !NewbieManager.IsWorking())
		{
			this.GuideSoldierID = this.GUIM.BuildingData.GuideSoldierID;
			this.DM.GuideSoldierNum = (ushort)this.GUIM.BuildingData.GuideSoldierNum;
			this.m_itemView2.gameObject.SetActive(true);
			this.m_itemView.GoTo((int)((this.GuideSoldierID - 1) % 4));
			this.m_itemView2.GoTo((int)((this.GuideSoldierID - 1) % 4));
			this.m_ItemX.anchoredPosition = new Vector2((float)(-376 + (int)(189 * ((this.GuideSoldierID - 1) / 4))), this.m_ItemX.anchoredPosition.y);
		}
		if (this.GuideSoldierID == 0)
		{
			this.DM.GuideSoldierNum = 0;
		}
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001945 RID: 6469 RVA: 0x002A9A70 File Offset: 0x002A7C70
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 >= 1 && sender.m_BtnID1 <= 4)
		{
			this.GUIM.UIBarrack_Y = this.m_ItemConet.anchoredPosition.y;
			Transform parent = sender.gameObject.transform.parent;
			int num = 1 + parent.GetComponent<ScrollPanelItem>().m_BtnID1 + (sender.m_BtnID1 - 1) * 4;
			if ((int)this.GuideSoldierID != num)
			{
				this.DM.GuideSoldierNum = 0;
			}
			this.door.OpenMenu(EGUIWindow.UI_Barrack_Soldier, num, 0, false);
		}
	}

	// Token: 0x06001946 RID: 6470 RVA: 0x002A9B08 File Offset: 0x002A7D08
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelId == 1)
		{
			if (this.tmpItem[panelObjectIdx] == null)
			{
				this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
				Transform child;
				for (int i = 0; i < 4; i++)
				{
					int num = panelObjectIdx * 4 + i;
					child = item.transform.GetChild(i);
					this.tmpItemBtn[num] = child.GetComponent<UIButton>();
					this.tmpItemBtn[num].m_Handler = this;
					this.tmpItemBtn[num].image.material = this.m_Arms;
					Transform child2 = child.GetChild(0);
					this.tmpItemImg_Soldier[num] = child2.GetComponent<Image>();
					child2 = child.GetChild(1).GetChild(0);
					this.tmpItemtextName[num] = child2.GetComponent<UIText>();
					int num2 = this.tmpItem[panelObjectIdx].m_BtnID1 + i * 4;
					this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num2 + 1));
					child2 = child.GetChild(1).GetChild(1);
					this.tmpItemIcon[num] = child2.GetComponent<Image>();
					this.tmpItemIcon[num].sprite = this.SArray.m_Sprites[num2 / 4];
					this.tmpItemIcon[num].gameObject.SetActive(true);
					this.tmpItemtextName[num].rectTransform.anchoredPosition = new Vector2(-52f, this.tmpItemtextName[num].rectTransform.anchoredPosition.y);
					this.tmpItemtextName[num].rectTransform.sizeDelta = new Vector2(139f, this.tmpItemtextName[num].rectTransform.sizeDelta.y);
					child2 = child.GetChild(2).GetChild(0);
					this.tmpItemtextNum[num] = child2.GetComponent<UIText>();
					child2 = child.GetChild(3);
					this.tmpItemImg[num] = child2.GetComponent<Image>();
				}
				child = this.tmpItem[panelObjectIdx].transform.GetChild(5);
				this.tmpItemtextTitle[panelObjectIdx] = child.GetComponent<UIText>();
				this.tmpItemtextTitle[panelObjectIdx].font = this.TTFont;
			}
			for (int j = 0; j < 4; j++)
			{
				int num = panelObjectIdx * 4 + j;
				this.tmpString.Length = 0;
				this.tmpString.AppendFormat("q10{0:000}", j * 100 + (dataIdx + 1) * 10);
				this.tmpItemBtn[num].image.sprite = this.GUIM.LoadSprite("UI_arms", this.tmpString.ToString());
				this.tmpItemImg_Soldier[num].sprite = this.GUIM.LoadSprite("UI_arms", this.tmpString.ToString());
				int num2 = this.tmpItem[panelObjectIdx].m_BtnID1 + j * 4;
				this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num2 + 1));
				this.tmpItemtextName[num].text = this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name);
				this.tmpString.Length = 0;
				GameConstants.FormatResourceValue(this.tmpString, this.DM.RoleAttr.m_Soldier[num2]);
				this.tmpItemtextNum[num].text = this.tmpString.ToString();
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
			this.tmpItemtextTitle[panelObjectIdx].text = this.DM.mStringTable.GetStringByID((uint)(3834 + item.GetComponent<ScrollPanelItem>().m_BtnID1));
		}
		else if (dataIdx == (int)((this.GuideSoldierID - 1) % 4))
		{
			item.transform.GetChild(0).gameObject.SetActive(true);
		}
		else
		{
			item.transform.GetChild(0).gameObject.SetActive(false);
		}
	}

	// Token: 0x06001947 RID: 6471 RVA: 0x002A9F48 File Offset: 0x002A8148
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001948 RID: 6472 RVA: 0x002A9F4C File Offset: 0x002A814C
	private void Start()
	{
		this.baseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.baseBuild.m_Handler = this;
		byte level = this.GUIM.BuildingData.AllBuildsData[this.B_ID].Level;
		this.baseBuild.InitBuildingWindow(6, (ushort)this.B_ID, 2, level);
		this.baseBuild.baseTransform.SetAsFirstSibling();
		if (!NewbieManager.CheckNewbie(this))
		{
			NewbieManager.CheckTeach(ETeachKind.SPAWN_SOLDIERS, this, false);
		}
	}

	// Token: 0x06001949 RID: 6473 RVA: 0x002A9FD8 File Offset: 0x002A81D8
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
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
		if (this.timeBar != null)
		{
			this.GUIM.RemoverTimeBaarToList(this.timeBar);
		}
		this.GUIM.UIBarrack_Y = this.m_ItemConet.anchoredPosition.y;
		if (this.Cstr_Total != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Total);
		}
	}

	// Token: 0x0600194A RID: 6474 RVA: 0x002AA098 File Offset: 0x002A8298
	public void OnButtonDown(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintArmy, 0, 0f, 0, 0, 0, Vector2.zero, UIButtonHint.ePosition.Original);
	}

	// Token: 0x0600194B RID: 6475 RVA: 0x002AA0C8 File Offset: 0x002A82C8
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(true);
	}

	// Token: 0x0600194C RID: 6476 RVA: 0x002AA0DC File Offset: 0x002A82DC
	public void OnTimer(UITimeBar sender)
	{
		this.timeBar.gameObject.SetActive(false);
		this.text_Training.gameObject.SetActive(true);
		this.bTraining = false;
	}

	// Token: 0x0600194D RID: 6477 RVA: 0x002AA114 File Offset: 0x002A8314
	public void OnNotify(UITimeBar sender)
	{
	}

	// Token: 0x0600194E RID: 6478 RVA: 0x002AA118 File Offset: 0x002A8318
	public void Onfunc(UITimeBar sender)
	{
		if (sender.m_TimerSpriteType == eTimerSpriteType.Speed)
		{
			this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 10, false);
		}
	}

	// Token: 0x0600194F RID: 6479 RVA: 0x002AA138 File Offset: 0x002A8338
	public void OnCancel(UITimeBar sender)
	{
		this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(3924u), this.DM.mStringTable.GetStringByID(3853u), 0, 0, this.DM.mStringTable.GetStringByID(3925u), this.DM.mStringTable.GetStringByID(3926u));
	}

	// Token: 0x06001950 RID: 6480 RVA: 0x002AA1A8 File Offset: 0x002A83A8
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 == 0)
			{
				if (GUIManager.Instance.ShowUILock(EUILock.SoldierTrain))
				{
					MessagePacket messagePacket = new MessagePacket(1024);
					messagePacket.Protocol = Protocol._MSG_REQUEST_CANCELTRAINING;
					messagePacket.AddSeqId();
					messagePacket.Send(false);
				}
			}
		}
	}

	// Token: 0x06001951 RID: 6481 RVA: 0x002AA204 File Offset: 0x002A8404
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_Soldier:
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					int num = j * 4 + this.tmpItem[i].m_BtnID1;
					this.tmpString.Length = 0;
					GameConstants.FormatResourceValue(this.tmpString, this.DM.RoleAttr.m_Soldier[num]);
					this.tmpItemtextNum[i * 4 + j].text = this.tmpString.ToString();
				}
			}
			this.Cstr_Total.ClearString();
			this.Cstr_Total.IntToFormat(this.DM.SoldierTotal, 1, true);
			this.Cstr_Total.AppendFormat(this.DM.mStringTable.GetStringByID(3873u));
			this.text_Total.text = this.Cstr_Total.ToString();
			this.text_Total.SetAllDirty();
			this.text_Total.cachedTextGenerator.Invalidate();
			break;
		default:
			if (networkNews != NetworkNews.Login)
			{
				if (networkNews != NetworkNews.Refresh_AttribEffectVal)
				{
					if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
					{
						this.Refresh_FontTexture();
						if (this.baseBuild != null)
						{
							this.baseBuild.Refresh_FontTexture();
						}
						if (this.timeBar != null && this.timeBar.enabled)
						{
							this.timeBar.Refresh_FontTexture();
						}
					}
				}
				else if (this.baseBuild != null)
				{
					this.baseBuild.MyUpdate(0, false);
				}
			}
			else
			{
				if (this.DM.queueBarData[10].bActive)
				{
					long startTime = this.DM.queueBarData[10].StartTime;
					long target = startTime + (long)((ulong)this.DM.queueBarData[10].TotalTime);
					long notifyTime = 0L;
					int num2 = (int)(this.DM.SoldierKind * 4 + this.DM.SoldierRank);
					this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num2 + 1));
					CString cstring = StringManager.Instance.StaticString1024();
					StringManager.IntToStr(cstring, (long)((ulong)this.DM.SoldierTrainingQty), 1, true);
					this.tmpString.Length = 0;
					this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(4048u), this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name), cstring.ToString());
					this.GUIM.SetTimerBar(this.timeBar, startTime, target, notifyTime, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(4047u), this.tmpString.ToString());
					this.timeBar.gameObject.SetActive(true);
					this.text_Training.gameObject.SetActive(false);
					this.bTraining = true;
				}
				else
				{
					this.GUIM.RemoverTimeBaarToList(this.timeBar);
					this.timeBar.gameObject.SetActive(false);
					this.text_Training.gameObject.SetActive(true);
					this.bTraining = false;
				}
				int num3 = (int)(this.DM.SoldierKind * 4 + this.DM.SoldierRank);
				this.tmpString.Length = 0;
				GameConstants.FormatResourceValue(this.tmpString, this.DM.RoleAttr.m_Soldier[num3]);
				for (int k = 0; k < 3; k++)
				{
					if (this.tmpItem[k].m_BtnID1 == (int)this.DM.SoldierRank)
					{
						this.tmpItemtextNum[k * 4 + (int)this.DM.SoldierKind].text = this.tmpString.ToString();
					}
				}
				this.Cstr_Total.ClearString();
				this.Cstr_Total.IntToFormat(this.DM.SoldierTotal, 1, true);
				this.Cstr_Total.AppendFormat(this.DM.mStringTable.GetStringByID(3873u));
				this.text_Total.text = this.Cstr_Total.ToString();
				this.text_Total.SetAllDirty();
				this.text_Total.cachedTextGenerator.Invalidate();
			}
			break;
		case NetworkNews.Refresh_BuildBase:
			if (meg[1] == 1)
			{
				this.door.CloseMenu(true);
			}
			else if (this.baseBuild != null)
			{
				this.baseBuild.MyUpdate(meg[1], false);
			}
			break;
		}
	}

	// Token: 0x06001952 RID: 6482 RVA: 0x002AA6B4 File Offset: 0x002A88B4
	public void Refresh_FontTexture()
	{
		if (this.text_Total != null && this.text_Total.enabled)
		{
			this.text_Total.enabled = false;
			this.text_Total.enabled = true;
		}
		if (this.text_Training != null && this.text_Training.enabled)
		{
			this.text_Training.enabled = false;
			this.text_Training.enabled = true;
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.tmpItemtextTitle[i] != null && this.tmpItemtextTitle[i].enabled)
			{
				this.tmpItemtextTitle[i].enabled = false;
				this.tmpItemtextTitle[i].enabled = true;
			}
		}
		for (int j = 0; j < 12; j++)
		{
			if (this.tmpItemtextNum[j] != null && this.tmpItemtextNum[j].enabled)
			{
				this.tmpItemtextNum[j].enabled = false;
				this.tmpItemtextNum[j].enabled = true;
			}
			if (this.tmpItemtextName[j] != null && this.tmpItemtextName[j].enabled)
			{
				this.tmpItemtextName[j].enabled = false;
				this.tmpItemtextName[j].enabled = true;
			}
		}
	}

	// Token: 0x06001953 RID: 6483 RVA: 0x002AA81C File Offset: 0x002A8A1C
	public override void UpdateUI(int arg1, int arg2)
	{
		if (this.baseBuild == null)
		{
			return;
		}
		if (arg1 != 1)
		{
			if (arg1 == 2)
			{
				int num = (int)(this.DM.SoldierKind * 4 + this.DM.SoldierRank);
				this.tmpString.Length = 0;
				GameConstants.FormatResourceValue(this.tmpString, this.DM.RoleAttr.m_Soldier[num]);
				for (int i = 0; i < 3; i++)
				{
					if (this.tmpItem[i].m_BtnID1 == (int)this.DM.SoldierRank)
					{
						this.tmpItemtextNum[i * 4 + (int)this.DM.SoldierKind].text = this.tmpString.ToString();
					}
				}
				this.Cstr_Total.ClearString();
				this.Cstr_Total.IntToFormat(this.DM.SoldierTotal, 1, true);
				this.Cstr_Total.AppendFormat(this.DM.mStringTable.GetStringByID(3873u));
				this.text_Total.text = this.Cstr_Total.ToString();
				this.text_Total.SetAllDirty();
				this.text_Total.cachedTextGenerator.Invalidate();
			}
		}
		else if (this.DM.queueBarData[10].bActive)
		{
			long startTime = this.DM.queueBarData[10].StartTime;
			long target = startTime + (long)((ulong)this.DM.queueBarData[10].TotalTime);
			long notifyTime = 0L;
			int num2 = (int)(this.DM.SoldierKind * 4 + this.DM.SoldierRank);
			this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(num2 + 1));
			CString cstring = StringManager.Instance.StaticString1024();
			StringManager.IntToStr(cstring, (long)((ulong)this.DM.SoldierTrainingQty), 1, true);
			this.tmpString.Length = 0;
			this.tmpString.AppendFormat(this.DM.mStringTable.GetStringByID(4048u), this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name), cstring.ToString());
			this.GUIM.SetTimerBar(this.timeBar, startTime, target, notifyTime, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(4047u), this.tmpString.ToString());
			this.timeBar.gameObject.SetActive(true);
			this.text_Training.gameObject.SetActive(false);
			this.bTraining = true;
		}
		else
		{
			this.GUIM.RemoverTimeBaarToList(this.timeBar);
			this.timeBar.gameObject.SetActive(false);
			this.text_Training.gameObject.SetActive(true);
			this.bTraining = false;
		}
	}

	// Token: 0x06001954 RID: 6484 RVA: 0x002AAB08 File Offset: 0x002A8D08
	private void Update()
	{
		if (this.m_itemView2.gameObject.activeSelf)
		{
			this.m_ItemConetY.anchoredPosition = new Vector2(this.m_ItemConetY.anchoredPosition.x, this.m_ItemConet.anchoredPosition.y);
		}
	}

	// Token: 0x04004ACA RID: 19146
	private DataManager DM;

	// Token: 0x04004ACB RID: 19147
	private GUIManager GUIM;

	// Token: 0x04004ACC RID: 19148
	private Transform GameT;

	// Token: 0x04004ACD RID: 19149
	private ScrollPanel m_itemView;

	// Token: 0x04004ACE RID: 19150
	private CScrollRect m_ScrollRect;

	// Token: 0x04004ACF RID: 19151
	private RectTransform m_ItemConet;

	// Token: 0x04004AD0 RID: 19152
	private ScrollPanel m_itemView2;

	// Token: 0x04004AD1 RID: 19153
	private RectTransform m_ItemX;

	// Token: 0x04004AD2 RID: 19154
	private RectTransform m_ItemConetY;

	// Token: 0x04004AD3 RID: 19155
	private Image BG;

	// Token: 0x04004AD4 RID: 19156
	private Image BG1;

	// Token: 0x04004AD5 RID: 19157
	private Image BGArmy;

	// Token: 0x04004AD6 RID: 19158
	private UIText text_Total;

	// Token: 0x04004AD7 RID: 19159
	private UIText text_Training;

	// Token: 0x04004AD8 RID: 19160
	private StringBuilder tmpString = new StringBuilder();

	// Token: 0x04004AD9 RID: 19161
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x04004ADA RID: 19162
	private SoldierData tmpSD;

	// Token: 0x04004ADB RID: 19163
	public BuildingWindow baseBuild;

	// Token: 0x04004ADC RID: 19164
	public UITimeBar timeBar;

	// Token: 0x04004ADD RID: 19165
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[3];

	// Token: 0x04004ADE RID: 19166
	public UIButton[] tmpItemBtn = new UIButton[12];

	// Token: 0x04004ADF RID: 19167
	private Image[] tmpItemImg_Soldier = new Image[12];

	// Token: 0x04004AE0 RID: 19168
	private Image[] tmpItemImg = new Image[12];

	// Token: 0x04004AE1 RID: 19169
	private Image[] tmpItemIcon = new Image[12];

	// Token: 0x04004AE2 RID: 19170
	private UIText[] tmpItemtextNum = new UIText[12];

	// Token: 0x04004AE3 RID: 19171
	private UIText[] tmpItemtextName = new UIText[12];

	// Token: 0x04004AE4 RID: 19172
	private UIText[] tmpItemtextTitle = new UIText[3];

	// Token: 0x04004AE5 RID: 19173
	private long SoldierTotal;

	// Token: 0x04004AE6 RID: 19174
	private bool bTraining;

	// Token: 0x04004AE7 RID: 19175
	private string AssetName;

	// Token: 0x04004AE8 RID: 19176
	private string AssetName1;

	// Token: 0x04004AE9 RID: 19177
	private Door door;

	// Token: 0x04004AEA RID: 19178
	private Material m_BW;

	// Token: 0x04004AEB RID: 19179
	private Material m_Arms;

	// Token: 0x04004AEC RID: 19180
	private int B_ID;

	// Token: 0x04004AED RID: 19181
	private CString Cstr_Total;

	// Token: 0x04004AEE RID: 19182
	private ushort GuideSoldierID;

	// Token: 0x04004AEF RID: 19183
	private UISpritesArray SArray;
}
