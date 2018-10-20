using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200066A RID: 1642
public class UISynthesis : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIHIBtnClickHandler
{
	// Token: 0x170000BD RID: 189
	// (get) Token: 0x06001F94 RID: 8084 RVA: 0x003C3380 File Offset: 0x003C1580
	// (set) Token: 0x06001F95 RID: 8085 RVA: 0x003C3388 File Offset: 0x003C1588
	public bool m_MovingExit
	{
		get
		{
			return this._m_MovingExit;
		}
		set
		{
			this._m_MovingExit = value;
			if (this._m_MovingExit)
			{
				Vector2 beginMove = this.m_BeginMove;
				this.m_BeginMove = this.m_EndMove;
				this.m_EndMove = beginMove;
			}
		}
	}

	// Token: 0x06001F96 RID: 8086 RVA: 0x003C33C4 File Offset: 0x003C15C4
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager.Instance.bClearWindowStack = true;
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 1);
		this.m_LevelTableKind = LevelTableKind.NormalStage;
		this.m_ItemData = new List<ushort>();
		this.m_FisetItemID = (ushort)arg1;
		this.m_ItemSourceData = new List<ushort>();
		this.sb = new StringBuilder();
		this.m_ItemSourceNameStr = StringManager.Instance.SpawnString(30);
		if (GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta.x / GUIManager.Instance.m_UICanvas.scaleFactor <= 853f)
		{
			this.m_BeginMove.x = (this.m_EndMove.x = -32.5f);
		}
		else
		{
			this.m_BeginMove.x = (this.m_EndMove.x = 0f);
		}
		this.InitUI(null);
		if (!GUIManager.Instance.m_ItemInfo.m_RectTransform.gameObject.activeSelf)
		{
			GUIManager.Instance.m_ItemInfo.Show(EUIItemInfo.HeroEquip, this.m_FisetItemID, 0, 0);
		}
		this.m_Step = this.m_BeginMove;
		this.m_Moveing = true;
	}

	// Token: 0x06001F97 RID: 8087 RVA: 0x003C34F4 File Offset: 0x003C16F4
	public void MyOnOpen(int arg1, Transform tf)
	{
		base.transform.GetComponent<Image>().color = new Color(1f, 1.01f, 1f, 0.7f);
		this.m_LevelTableKind = LevelTableKind.AdvanceStage;
		this.m_ItemData = new List<ushort>();
		this.m_FisetItemID = (ushort)arg1;
		this.m_ItemSourceData = new List<ushort>();
		this.sb = new StringBuilder();
		this.m_ItemSourceNameStr = StringManager.Instance.SpawnString(30);
		this.InitUI(tf);
		this.m_TransForm = tf;
		this.m_CenterPos = true;
		this.m_Moveing = true;
		this.m_EndMove = this.m_BeginMove;
		this.m_Step = this.m_EndMove;
		((RectTransform)this.m_SynPanel).anchorMax = new Vector2(0.5f, 0.5f);
		((RectTransform)this.m_SynPanel).anchorMin = new Vector2(0.5f, 0.5f);
		((RectTransform)this.m_SynPanel).pivot = new Vector2(0.5f, 0.5f);
		((RectTransform)this.m_SynPanel).anchoredPosition = new Vector2(0f, 0f);
		((RectTransform)this.m_ExiteBtn.transform.parent).pivot = new Vector2(0.5f, 0.5f);
		((RectTransform)this.m_ExiteBtn.transform.parent).anchorMax = new Vector2(0.5f, 0.5f);
		((RectTransform)this.m_ExiteBtn.transform.parent).anchorMin = new Vector2(0.5f, 0.5f);
		((RectTransform)this.m_ExiteBtn.transform.parent).anchoredPosition = new Vector2(359.5f, 136f);
		this.m_ExiteBtnImage.enabled = false;
		this.m_ReturnBtn.gameObject.SetActive(false);
		this.bInit = true;
	}

	// Token: 0x06001F98 RID: 8088 RVA: 0x003C36E4 File Offset: 0x003C18E4
	public override void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.m_ItemSourceNameStr);
		GUIManager.Instance.m_ItemInfo.Hide();
		if (this.bNeedSaveUIState)
		{
			this.SaveUIState();
		}
		else if (this.bSaveUIState_Money)
		{
			this.SaveUIState();
		}
		else
		{
			this.GM.ClearSynthesisUIData();
		}
	}

	// Token: 0x06001F99 RID: 8089 RVA: 0x003C3748 File Offset: 0x003C1948
	public void Destroy()
	{
	}

	// Token: 0x06001F9A RID: 8090 RVA: 0x003C374C File Offset: 0x003C194C
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 0)
		{
			if (arg1 == 1)
			{
				if (this.m_ExiteBtn != null)
				{
					this.OnButtonClick(this.m_ExiteBtn);
				}
			}
		}
		else if (this.m_ItemData.Count > 0)
		{
			if (this.m_ItemData.Count > 1)
			{
				this.GoTo(this.m_ItemData.Count - 2);
			}
			this.UpdatePageType(this.m_ItemData[this.m_ItemData.Count - 1], false);
		}
	}

	// Token: 0x06001F9B RID: 8091 RVA: 0x003C37E8 File Offset: 0x003C19E8
	public override void UpdateNetwork(byte[] meg)
	{
		List<float> list = new List<float>();
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_VIP:
			break;
		default:
			if (networkNews != NetworkNews.Login)
			{
				return;
			}
			break;
		case NetworkNews.Refresh_FontTextureRebuilt:
			this.Refresh_FontTexture();
			return;
		}
		for (int i = 0; i < this.m_ItemSourceData.Count; i++)
		{
			list.Add(this.m_SourceItemHeight);
		}
		this.m_SourceItemScrollPanel.AddNewDataHeight(list, false, true);
	}

	// Token: 0x06001F9C RID: 8092 RVA: 0x003C3868 File Offset: 0x003C1A68
	public void Refresh_FontTexture()
	{
		if (this.m_ResultItemText != null && this.m_ResultItemText.enabled)
		{
			this.m_ResultItemText.enabled = false;
			this.m_ResultItemText.enabled = true;
		}
		if (this.m_NeedMoneyText != null && this.m_NeedMoneyText.enabled)
		{
			this.m_NeedMoneyText.enabled = false;
			this.m_NeedMoneyText.enabled = true;
		}
		if (this.m_HeroItemText != null && this.m_HeroItemText.enabled)
		{
			this.m_HeroItemText.enabled = false;
			this.m_HeroItemText.enabled = true;
		}
		if (this.m_ItemSourceName != null && this.m_ItemSourceName.enabled)
		{
			this.m_ItemSourceName.enabled = false;
			this.m_ItemSourceName.enabled = true;
		}
		if (this.m_SourceText != null && this.m_SourceText.enabled)
		{
			this.m_SourceText.enabled = false;
			this.m_SourceText.enabled = true;
		}
		if (this.m_tmpStr1 != null && this.m_tmpStr1.enabled)
		{
			this.m_tmpStr1.enabled = false;
			this.m_tmpStr1.enabled = true;
		}
		if (this.m_tmpStr2 != null && this.m_tmpStr2.enabled)
		{
			this.m_tmpStr2.enabled = false;
			this.m_tmpStr2.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.m_FuncBtnText[i] != null && this.m_FuncBtnText[i].enabled)
			{
				this.m_FuncBtnText[i].enabled = false;
				this.m_FuncBtnText[i].enabled = true;
			}
		}
		for (int j = 0; j < 5; j++)
		{
			if (this.m_SynthesisBtnTexts[j] != null && this.m_SynthesisBtnTexts[j].enabled)
			{
				this.m_SynthesisBtnTexts[j].enabled = false;
				this.m_SynthesisBtnTexts[j].enabled = true;
			}
		}
		for (int k = 0; k < 5; k++)
		{
			if (this.m_tmptext[k] != null && this.m_tmptext[k].enabled)
			{
				this.m_tmptext[k].enabled = false;
				this.m_tmptext[k].enabled = true;
			}
		}
		for (int l = 0; l < 3; l++)
		{
			for (int m = 0; m < 2; m++)
			{
				if (this.m_tmpItemtext1[l][m] != null && this.m_tmpItemtext1[l][m].enabled)
				{
					this.m_tmpItemtext1[l][m].enabled = false;
					this.m_tmpItemtext1[l][m].enabled = true;
				}
				if (this.m_tmpItemtext2[l][m] != null && this.m_tmpItemtext2[l][m].enabled)
				{
					this.m_tmpItemtext2[l][m].enabled = false;
					this.m_tmpItemtext2[l][m].enabled = true;
				}
				if (this.m_tmpItemtext3[l][m] != null && this.m_tmpItemtext3[l][m].enabled)
				{
					this.m_tmpItemtext3[l][m].enabled = false;
					this.m_tmpItemtext3[l][m].enabled = true;
				}
			}
		}
		if (this.m_ItemBtns != null)
		{
			for (int n = 0; n < this.m_ItemBtns.Length; n++)
			{
				if (this.m_ItemBtns[n] != null && this.m_ItemBtns[n].enabled)
				{
					this.m_ItemBtns[n].Refresh_FontTexture();
				}
			}
		}
		if (this.m_SourceBtn1s != null)
		{
			for (int num = 0; num < this.m_SourceBtn1s.Length; num++)
			{
				if (this.m_SourceBtn1s[num] != null && this.m_SourceBtn1s[num].enabled)
				{
					this.m_SourceBtn1s[num].Refresh_FontTexture();
				}
			}
		}
		if (this.m_SourceBtn2s != null)
		{
			for (int num2 = 0; num2 < this.m_SourceBtn2s.Length; num2++)
			{
				if (this.m_SourceBtn2s[num2] != null && this.m_SourceBtn2s[num2].enabled)
				{
					this.m_SourceBtn2s[num2].Refresh_FontTexture();
				}
			}
		}
		if (this.m_SourceBtn3s != null)
		{
			for (int num3 = 0; num3 < this.m_SourceBtn2s.Length; num3++)
			{
				if (this.m_SourceBtn3s[num3] != null && this.m_SourceBtn3s[num3].enabled)
				{
					this.m_SourceBtn3s[num3].Refresh_FontTexture();
				}
			}
		}
	}

	// Token: 0x06001F9D RID: 8093 RVA: 0x003C3D80 File Offset: 0x003C1F80
	private void Update()
	{
		if (this.m_ShowTransEffect)
		{
			this.m_ColorTick += Time.deltaTime;
			if (this.m_ColorTick >= 0.05f)
			{
				this.m_ColorA += 0.1f;
				if (this.m_ColorA >= 2f)
				{
					this.m_ColorA = 0f;
					this.m_EffectImage1Rt.localScale = new Vector3(1f, 1f, 1f);
					this.m_ShowTransEffect = false;
				}
				for (int i = 0; i < 3; i++)
				{
					if (this.m_EffectImage[i] != null)
					{
						if (this.m_ColorA > 1f)
						{
							this.m_EffectImage[i].color = new Color(1f, 1f, 1f, 2f - this.m_ColorA);
						}
						else
						{
							this.m_EffectImage[i].color = new Color(1f, 1f, 1f, this.m_ColorA);
						}
						if (i == 2 && this.m_ColorA > 1f)
						{
							this.m_EffectImage1Rt.localScale = new Vector3(this.m_ColorA, this.m_ColorA, this.m_ColorA);
						}
					}
				}
				this.m_ColorTick = 0f;
			}
		}
		if (this.m_Moveing)
		{
			if (!this.m_CenterPos && !this.bInit)
			{
				if (this.PassFrame > 0)
				{
					((RectTransform)this.m_SynPanel).anchoredPosition = this.m_BeginMove;
					this.PassFrame -= 1;
					return;
				}
				float num = 0.3f;
				this.MoveDelta = Mathf.Clamp(this.MoveDelta + Time.deltaTime, 0f, num);
				this.m_Step = ((RectTransform)this.m_SynPanel).anchoredPosition;
				this.m_Step.y = EasingEffect.Linear(this.MoveDelta, this.m_BeginMove.y, this.m_EndMove.y - this.m_BeginMove.y, num);
				((RectTransform)this.m_SynPanel).anchoredPosition = this.m_Step;
				GUIManager.Instance.m_ItemInfo.UpdatePosition(this.MoveDelta);
				if (this.m_Step == this.m_EndMove)
				{
					this.MoveDelta = 0f;
					this.bInit = true;
					return;
				}
			}
			if (this.bInit)
			{
				this.m_Moveing = false;
				this.InitHintn();
				List<float> list = new List<float>();
				list.Add(this.m_ItemHeight);
				this.m_ItemScrollPanel.IntiScrollPanel(370f, 10f, 5f, list, this.m_MaxItemPanelObject, this);
				list.Clear();
				list.Add(this.m_SourceItemHeight);
				this.m_SourceItemScrollPanel.IntiScrollPanel(237f, 0f, 0f, list, 3, this);
				this.m_SourceItemScrollPanelRect = this.m_SourceItemScrollPanel.gameObject.transform.GetChild(0).GetComponent<RectTransform>();
				this.UpdatePageType(this.m_FisetItemID, true);
				this.SetUIState();
				this.GM.ClearSynthesisUIData();
			}
		}
		if (this._m_MovingExit)
		{
			float num2 = 0.3f;
			this.MoveDelta = Mathf.Clamp(this.MoveDelta + Time.deltaTime, 0f, num2);
			this.m_Step = ((RectTransform)this.m_SynPanel).anchoredPosition;
			this.m_Step.y = EasingEffect.Linear(this.MoveDelta, this.m_BeginMove.y, this.m_EndMove.y - this.m_BeginMove.y, num2);
			((RectTransform)this.m_SynPanel).anchoredPosition = this.m_Step;
			GUIManager.Instance.m_ItemInfo.UpdatePosition(this.MoveDelta);
			if (this.m_Step == this.m_EndMove)
			{
				this.PassFrame -= 1;
				if (this.PassFrame == -2)
				{
					GUIManager.Instance.m_ItemInfo.m_Background.gameObject.SetActive(true);
					Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
					door.CloseMenu(false);
					UIItemInfo itemInfo = GUIManager.Instance.m_ItemInfo;
					GUIManager.Instance.m_ItemInfo.Show(EUIItemInfo.HeroEquip, itemInfo.m_ItemID, itemInfo.m_HeroID, itemInfo.m_EquipPos);
				}
			}
		}
	}

	// Token: 0x06001F9E RID: 8094 RVA: 0x003C41F4 File Offset: 0x003C23F4
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelId == 1)
		{
			if (dataIdx >= this.m_ItemData.Count)
			{
				return;
			}
			if (this.m_ItemBtns[panelObjectIdx] == null)
			{
				Transform child = item.transform.GetChild(0);
				this.m_ItemBtns[panelObjectIdx] = child.GetComponent<UIHIBtn>();
				this.m_ItemBtns[panelObjectIdx].m_BtnID1 = 100;
				this.m_ItemBtns[panelObjectIdx].m_BtnID2 = dataIdx;
				this.m_ItemBtns[panelObjectIdx].m_Handler = this;
				child = item.transform.GetChild(2);
				this.m_ItemSelects[panelObjectIdx] = child.GetComponent<Image>();
			}
			ushort num = this.m_ItemData[dataIdx];
			Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(num);
			GUIManager.Instance.ChangeHeroItemImg(this.m_ItemBtns[panelObjectIdx].transform, eHeroOrItem.Item, num, recordByKey.Color, 0, 0);
			if (dataIdx == this.m_ItemData.Count - 1)
			{
				this.m_ItemSelects[panelObjectIdx].gameObject.SetActive(true);
			}
			else
			{
				this.m_ItemSelects[panelObjectIdx].gameObject.SetActive(false);
			}
		}
		else if (panelId == 2)
		{
			if (this.m_SourceItemBtn1s[panelObjectIdx] == null)
			{
				this.m_SourceItemBtn1s[panelObjectIdx] = item.transform.GetChild(1);
				this.m_SourceBtn1s[panelObjectIdx] = this.m_SourceItemBtn1s[panelObjectIdx].GetChild(0).GetComponent<UIHIBtn>();
				this.m_SourceBtn1s[panelObjectIdx].m_BtnID1 = 101;
				this.m_SourceBtn1s[panelObjectIdx].m_Handler = this;
				this.m_SourceUIBtn1s[panelObjectIdx] = this.m_SourceItemBtn1s[panelObjectIdx].GetComponent<UIButton>();
				this.m_SourceUIBtn1s[panelObjectIdx].m_BtnID1 = 101;
				this.m_SourceUIBtn1s[panelObjectIdx].m_Handler = this;
				this.m_tmpItemtext1[panelObjectIdx][0] = this.m_SourceItemBtn1s[panelObjectIdx].GetChild(2).GetComponent<UIText>();
				this.m_tmpItemtext1[panelObjectIdx][0].font = GUIManager.Instance.GetTTFFont();
				this.m_tmpItemtext1[panelObjectIdx][1] = this.m_SourceItemBtn1s[panelObjectIdx].GetChild(3).GetChild(0).GetComponent<UIText>();
				this.m_tmpItemtext1[panelObjectIdx][1].font = GUIManager.Instance.GetTTFFont();
				this.m_SourceItemBtn2s[panelObjectIdx] = item.transform.GetChild(2);
				this.m_SourceBtn2s[panelObjectIdx] = this.m_SourceItemBtn2s[panelObjectIdx].GetChild(0).GetComponent<UIHIBtn>();
				this.m_SourceBtn2s[panelObjectIdx].m_BtnID1 = 101;
				this.m_SourceBtn2s[panelObjectIdx].m_Handler = this;
				this.m_SourceUIBtn2s[panelObjectIdx] = this.m_SourceItemBtn2s[panelObjectIdx].GetComponent<UIButton>();
				this.m_SourceUIBtn2s[panelObjectIdx].m_BtnID1 = 101;
				this.m_SourceUIBtn2s[panelObjectIdx].m_Handler = this;
				this.m_tmpItemtext2[panelObjectIdx][0] = this.m_SourceItemBtn2s[panelObjectIdx].GetChild(2).GetComponent<UIText>();
				this.m_tmpItemtext2[panelObjectIdx][0].font = GUIManager.Instance.GetTTFFont();
				this.m_tmpItemtext2[panelObjectIdx][1] = this.m_SourceItemBtn2s[panelObjectIdx].GetChild(3).GetChild(0).GetComponent<UIText>();
				this.m_tmpItemtext2[panelObjectIdx][1].font = GUIManager.Instance.GetTTFFont();
				this.m_SourceItemBtn3s[panelObjectIdx] = item.transform.GetChild(3);
				this.m_SourceBtn3s[panelObjectIdx] = this.m_SourceItemBtn3s[panelObjectIdx].GetChild(0).GetComponent<UIHIBtn>();
				this.m_SourceBtn3s[panelObjectIdx].m_BtnID1 = 101;
				this.m_SourceBtn3s[panelObjectIdx].m_Handler = this;
				this.m_SourceUIBtn2s[panelObjectIdx] = this.m_SourceItemBtn3s[panelObjectIdx].GetComponent<UIButton>();
				this.m_SourceUIBtn2s[panelObjectIdx].m_BtnID1 = 101;
				this.m_SourceUIBtn2s[panelObjectIdx].m_Handler = this;
				this.m_tmpItemtext3[panelObjectIdx][0] = this.m_SourceItemBtn3s[panelObjectIdx].GetChild(2).GetComponent<UIText>();
				this.m_tmpItemtext3[panelObjectIdx][0].font = GUIManager.Instance.GetTTFFont();
				this.m_tmpItemtext3[panelObjectIdx][1] = this.m_SourceItemBtn3s[panelObjectIdx].GetChild(3).GetChild(0).GetComponent<UIText>();
				this.m_tmpItemtext3[panelObjectIdx][1].font = GUIManager.Instance.GetTTFFont();
			}
			ushort num2 = (ushort)(dataIdx * 3);
			if ((int)num2 < this.m_ItemSourceData.Count)
			{
				this.SetStageBtn(this.m_ItemSourceData[(int)num2], this.m_SourceItemBtn1s[panelObjectIdx], this.m_LevelTableKind);
				this.m_SourceItemBtn1s[panelObjectIdx].gameObject.SetActive(true);
			}
			else
			{
				this.m_SourceItemBtn1s[panelObjectIdx].gameObject.SetActive(false);
			}
			num2 = (ushort)(dataIdx * 3 + 1);
			if ((int)num2 < this.m_ItemSourceData.Count)
			{
				this.SetStageBtn(this.m_ItemSourceData[(int)num2], this.m_SourceItemBtn2s[panelObjectIdx], this.m_LevelTableKind);
				this.m_SourceItemBtn2s[panelObjectIdx].gameObject.SetActive(true);
			}
			else
			{
				this.m_SourceItemBtn2s[panelObjectIdx].gameObject.SetActive(false);
			}
			num2 = (ushort)(dataIdx * 3 + 2);
			if ((int)num2 < this.m_ItemSourceData.Count)
			{
				this.SetStageBtn(this.m_ItemSourceData[(int)num2], this.m_SourceItemBtn3s[panelObjectIdx], this.m_LevelTableKind);
				this.m_SourceItemBtn3s[panelObjectIdx].gameObject.SetActive(true);
			}
			else
			{
				this.m_SourceItemBtn3s[panelObjectIdx].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001F9F RID: 8095 RVA: 0x003C472C File Offset: 0x003C292C
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001FA0 RID: 8096 RVA: 0x003C4730 File Offset: 0x003C2930
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 95:
			if (this.m_ItemData.Count > 0)
			{
				if (sender.m_BtnID2 == 0)
				{
					DataManager.Instance.SendSynthesis(this.m_ItemData[this.m_ItemData.Count - 1]);
					this.m_ShowTransEffect = true;
				}
				else if (sender.m_BtnID2 == 1)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(2715u), 255, true);
				}
				else if (sender.m_BtnID2 == 2)
				{
					Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
					if (door)
					{
						this.bSaveUIState_Money = true;
						door.OpenMenu(EGUIWindow.UI_BagFilter, 589825, (int)this.MixPrice, false);
					}
				}
			}
			break;
		case 96:
			if (this.m_LevelTableKind != LevelTableKind.NormalStage)
			{
				this.SetLevelTableKind(this.m_SourceItemPanelID, LevelTableKind.NormalStage);
			}
			break;
		case 97:
			if (this.m_LevelTableKind != LevelTableKind.AdvanceStage)
			{
				this.SetLevelTableKind(this.m_SourceItemPanelID, LevelTableKind.AdvanceStage);
			}
			break;
		case 98:
			if (this.m_ItemData.Count > 1)
			{
				this.ReturnItem();
				this.UpdatePageType(this.m_ItemData[this.m_ItemData.Count - 1], false);
			}
			break;
		case 99:
			if (this.m_TransForm != null)
			{
				GUIManager.Instance.m_IsOpenedUISynthesis = false;
				GUIManager.Instance.CloseMenu(EGUIWindow.UI_Synthesis);
			}
			else
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hero_Info, 9, 0);
				Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door2.CloseMenu(false);
			}
			break;
		case 101:
			if (sender.m_BtnID2 != 0)
			{
				this.bNeedSaveUIState = true;
				GUIManager.Instance.m_ItemInfo.Hide();
				DataManager.StageDataController.SaveCurrentChapter();
				DataManager.StageDataController.currentChapterID = (byte)((sender.m_BtnID2 % 6 != 0) ? (sender.m_BtnID2 / 6 + 1) : (sender.m_BtnID2 / 6));
				if (this.m_LevelTableKind == LevelTableKind.AdvanceStage)
				{
					DataManager.StageDataController._stageMode = StageMode.Lean;
					DataManager.StageDataController.currentPointID = (ushort)sender.m_BtnID2;
				}
				else
				{
					DataManager.StageDataController._stageMode = StageMode.Full;
					DataManager.StageDataController.currentPointID = (ushort)(sender.m_BtnID2 * 3);
				}
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hero_Info, 9, 0);
				Door door3 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door3.OpenMenu(EGUIWindow.UI_StageInfo, 0, 0, true);
				GUIManager.Instance.bClearWindowStack = false;
				if (this.m_TransForm != null)
				{
					GUIManager.Instance.m_IsOpenedUISynthesis = true;
					GUIManager.Instance.m_UISynthesisID = this.m_FisetItemID;
					GUIManager.Instance.CloseMenu(EGUIWindow.UI_Synthesis);
				}
			}
			else
			{
				Debug.Log("關卡未開放");
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(237u), 255, true);
			}
			break;
		case 102:
			if (this.m_HeroItem != null)
			{
				UIButtonHint component = this.m_HeroItem.GetComponent<UIButtonHint>();
				if (component != null)
				{
					component.ControlFadeOut = GUIManager.Instance.m_SimpleItemInfo.m_RectTransform.gameObject;
					GUIManager.Instance.m_SimpleItemInfo.Show(component, this.m_HeroItem.HIID, -1, UIButtonHint.ePosition.Original, null);
					GUIManager.Instance.HintMaskObj.Show(component);
					GUIManager.Instance.HintMaskObj.HideBtn.m_Handler = component;
				}
			}
			break;
		}
	}

	// Token: 0x06001FA1 RID: 8097 RVA: 0x003C4AEC File Offset: 0x003C2CEC
	public void OnHIButtonClick(UIHIBtn sender)
	{
		int btnID = sender.m_BtnID1;
		switch (btnID)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
			GUIManager.Instance.m_SynthesisItemIdx = (ushort)sender.m_BtnID1;
			this.NowClickIdx = (byte)sender.m_BtnID1;
			this.UpdatePageType((ushort)sender.m_BtnID2, true);
			break;
		case 5:
			break;
		default:
			if (btnID != 100)
			{
				if (btnID != 101)
				{
				}
			}
			else
			{
				if (GUIManager.Instance.m_SimpleItemInfo.m_RectTransform.gameObject.activeSelf && sender.HIID == GUIManager.Instance.m_SimpleItemInfo.m_ItemBtn.HIID)
				{
					UIButtonHint buttonHint = GUIManager.Instance.m_SimpleItemInfo.m_ButtonHint;
					buttonHint.SkipDisabelEvent = 1;
				}
				this.GoTo(sender.m_BtnID2);
			}
			break;
		}
	}

	// Token: 0x06001FA2 RID: 8098 RVA: 0x003C4BD8 File Offset: 0x003C2DD8
	private void InitUI(Transform tf = null)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (tf != null)
		{
			this.m_SynPanel = tf.GetChild(0);
			this.m_ExiteBtnImage = tf.GetChild(1).GetComponent<Image>();
			this.m_ExiteBtn = tf.GetChild(1).GetChild(0).GetComponent<UIButton>();
		}
		else
		{
			this.m_SynPanel = base.transform.GetChild(0);
			this.m_ExiteBtnImage = base.transform.GetChild(1).GetComponent<Image>();
			this.m_ExiteBtn = base.transform.GetChild(1).GetChild(0).GetComponent<UIButton>();
		}
		if (this.GM.bOpenOnIPhoneX)
		{
			((RectTransform)base.transform).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0f);
			((RectTransform)base.transform).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0f);
		}
		HelperUIButton helperUIButton = base.gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID1 = 99;
		IgnoreRaycast component = this.m_SynPanel.GetChild(0).GetComponent<IgnoreRaycast>();
		UnityEngine.Object.Destroy(component);
		this.m_ExiteBtn.m_BtnID1 = 99;
		this.m_ExiteBtn.m_Handler = this;
		this.m_ExiteBtnImage.sprite = door.LoadSprite("UI_main_close_base");
		this.m_ExiteBtnImage.material = door.LoadMaterial();
		this.m_ExiteBtn.image.sprite = door.LoadSprite("UI_main_close");
		this.m_ExiteBtn.image.material = door.LoadMaterial();
		this.m_HeroItemPanel = this.m_SynPanel.GetChild(1);
		this.m_ItemPanel = this.m_SynPanel.GetChild(2);
		this.m_ItemScrollPanel = this.m_ItemPanel.GetChild(0).GetComponent<ScrollPanel>();
		this.m_RequirementPanel = this.m_SynPanel.GetChild(3);
		this.m_SynthesisBtns = new UIHIBtn[5];
		this.m_SynthesisBtnTexts = new UIText[5];
		this.m_ResultItem = this.m_RequirementPanel.GetChild(1).GetComponent<UIHIBtn>();
		this.m_ResultItemText = this.m_RequirementPanel.GetChild(1).GetChild(1).GetComponent<UIText>();
		this.m_ResultItemText.font = GUIManager.Instance.GetTTFFont();
		this.m_TransBtn = this.m_RequirementPanel.GetChild(7).GetComponent<UIButton>();
		this.m_TransBtn.m_Handler = this;
		this.m_TransBtn.m_BtnID1 = 95;
		this.m_NeedMoneyText = this.m_RequirementPanel.GetChild(7).GetChild(1).GetComponent<UIText>();
		this.m_NeedMoneyText.font = GUIManager.Instance.GetTTFFont();
		this.m_tmptext[this.mTextCount] = this.m_RequirementPanel.GetChild(7).GetChild(2).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = GUIManager.Instance.GetTTFFont();
		this.m_tmptext[this.mTextCount].text = DataManager.Instance.mStringTable.GetStringByID(87u);
		this.mTextCount++;
		this.m_HeroItem = this.m_HeroItemPanel.GetChild(1).GetComponent<UIHIBtn>();
		this.m_HeroItemText = this.m_HeroItemPanel.GetChild(2).GetComponent<UIText>();
		this.m_HeroItemText.font = GUIManager.Instance.GetTTFFont();
		this.m_InfoBtn = this.m_HeroItemPanel.GetChild(3).GetComponent<UIButton>();
		this.m_InfoBtn.m_Handler = this;
		this.m_InfoBtn.m_BtnID1 = 102;
		if (GUIManager.Instance.IsArabic)
		{
			this.m_InfoBtn.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.m_EffectPanel = this.m_RequirementPanel.GetChild(8);
		this.m_EffectImage = new Image[3];
		this.m_EffectImage[0] = this.m_EffectPanel.GetChild(0).GetComponent<Image>();
		this.m_EffectImage[1] = this.m_EffectPanel.GetChild(1).GetComponent<Image>();
		this.m_EffectImage[2] = this.m_EffectPanel.GetChild(2).GetComponent<Image>();
		this.m_EffectImage1Rt = this.m_EffectPanel.GetChild(2).GetComponent<RectTransform>();
		this.m_ItemSourcePanel = this.m_SynPanel.GetChild(4);
		this.m_SourceItemScrollPanel = this.m_ItemSourcePanel.GetChild(4).GetComponent<ScrollPanel>();
		this.m_ReturnBtn = this.m_SynPanel.GetChild(5).GetComponent<UIButton>();
		this.m_ReturnBtn.m_BtnID1 = 98;
		this.m_ReturnBtn.m_Handler = this;
		this.m_tmptext[this.mTextCount] = this.m_SynPanel.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = GUIManager.Instance.GetTTFFont();
		this.m_tmptext[this.mTextCount].text = DataManager.Instance.mStringTable.GetStringByID(196u);
		this.mTextCount++;
		this.m_ItemSourceName = this.m_SynPanel.GetChild(4).GetChild(3).GetComponent<UIText>();
		this.m_ItemSourceName.font = GUIManager.Instance.GetTTFFont();
		this.m_ArrowImgae = new Transform[2];
		this.m_FuncBtnText = new UIText[2];
		this.m_FuncBtnImage = new Image[2];
		this.m_SourceBtn = new Transform[2];
		this.m_SourceBtn[0] = this.m_SynPanel.GetChild(4).GetChild(5);
		this.m_FuncBtnText[0] = this.m_SynPanel.GetChild(4).GetChild(5).GetChild(0).GetComponent<UIText>();
		this.m_FuncBtnText[0].font = GUIManager.Instance.GetTTFFont();
		this.m_FuncBtnText[0].text = DataManager.Instance.mStringTable.GetStringByID(197u);
		this.m_ArrowImgae[0] = this.m_SynPanel.GetChild(4).GetChild(5).GetChild(1);
		this.m_FuncBtnImage[0] = this.m_SynPanel.GetChild(4).GetChild(5).GetComponent<Image>();
		UIButton component2 = this.m_SynPanel.GetChild(4).GetChild(5).GetComponent<UIButton>();
		component2.m_BtnID1 = 96;
		component2.m_Handler = this;
		this.m_SourceBtn[1] = this.m_SynPanel.GetChild(4).GetChild(6);
		this.m_FuncBtnText[1] = this.m_SynPanel.GetChild(4).GetChild(6).GetChild(0).GetComponent<UIText>();
		this.m_FuncBtnText[1].font = GUIManager.Instance.GetTTFFont();
		this.m_FuncBtnText[1].text = DataManager.Instance.mStringTable.GetStringByID(198u);
		this.m_ArrowImgae[1] = this.m_SynPanel.GetChild(4).GetChild(6).GetChild(1);
		this.m_FuncBtnImage[1] = this.m_SynPanel.GetChild(4).GetChild(6).GetComponent<Image>();
		component2 = this.m_SynPanel.GetChild(4).GetChild(6).GetComponent<UIButton>();
		component2.m_BtnID1 = 97;
		component2.m_Handler = this;
		this.m_SourceText = this.m_SynPanel.GetChild(4).GetChild(7).GetComponent<UIText>();
		this.m_SourceText.font = GUIManager.Instance.GetTTFFont();
		for (int i = 1; i <= 3; i++)
		{
			Image component3 = this.m_SynPanel.GetChild(7).GetChild(i).GetChild(1).GetComponent<Image>();
			component3.sprite = GUIManager.Instance.LoadFrameSprite("UI_complex_box_006");
			component3.material = GUIManager.Instance.GetFrameMaterial();
			this.m_tmptext[this.mTextCount] = this.m_SynPanel.GetChild(7).GetChild(i).GetChild(1).GetChild(0).GetComponent<UIText>();
			this.m_tmptext[this.mTextCount].font = GUIManager.Instance.GetTTFFont();
			this.m_tmptext[this.mTextCount].text = DataManager.Instance.mStringTable.GetStringByID(198u);
			this.mTextCount++;
			component3 = this.m_SynPanel.GetChild(7).GetChild(i).GetChild(3).GetComponent<Image>();
			component3.sprite = GUIManager.Instance.LoadFrameSprite("UI_black_top");
			component3.material = GUIManager.Instance.GetFrameMaterial();
		}
		this.m_ItemBtns = new UIHIBtn[this.m_MaxItemPanelObject];
		this.m_ItemSelects = new Image[this.m_MaxItemPanelObject];
		this.m_SourceItemBtn1s = new Transform[3];
		this.m_SourceItemBtn2s = new Transform[3];
		this.m_SourceItemBtn3s = new Transform[3];
		for (int j = 0; j < 3; j++)
		{
			this.m_tmpItemtext1[j] = new UIText[2];
			this.m_tmpItemtext2[j] = new UIText[2];
			this.m_tmpItemtext3[j] = new UIText[2];
		}
		this.m_SourceBtn1s = new UIHIBtn[3];
		this.m_SourceBtn2s = new UIHIBtn[3];
		this.m_SourceBtn3s = new UIHIBtn[3];
		this.m_SourceUIBtn1s = new UIButton[3];
		this.m_SourceUIBtn2s = new UIButton[3];
		this.m_SourceUIBtn3s = new UIButton[3];
	}

	// Token: 0x06001FA3 RID: 8099 RVA: 0x003C552C File Offset: 0x003C372C
	private void InitHintn()
	{
		GUIManager.Instance.InitianHeroItemImg(this.m_ResultItem.transform, eHeroOrItem.Item, 1, 1, 0, 0, false, true, true, false);
		for (int i = 0; i < 5; i++)
		{
			this.m_SynthesisBtnTexts[i] = this.m_RequirementPanel.GetChild(i + 2).GetChild(0).GetComponent<UIText>();
			this.m_SynthesisBtnTexts[i].font = GUIManager.Instance.GetTTFFont();
			this.m_SynthesisBtns[i] = this.m_RequirementPanel.GetChild(i + 2).GetComponent<UIHIBtn>();
			this.m_SynthesisBtns[i].m_BtnID1 = i;
			this.m_SynthesisBtns[i].m_Handler = this;
			GUIManager.Instance.InitianHeroItemImg(this.m_SynthesisBtns[i].transform, eHeroOrItem.Item, 1, 1, 0, 0, false, false, true, false);
		}
		GUIManager.Instance.InitianHeroItemImg(this.m_HeroItem.transform, eHeroOrItem.Item, 1, 1, 0, 0, false, true, true, false);
		this.m_Item = this.m_SynPanel.GetChild(6).GetChild(0).GetComponent<UIHIBtn>();
		GUIManager.Instance.InitianHeroItemImg(this.m_Item.transform, eHeroOrItem.Item, this.m_FisetItemID, 1, 0, 0, false, true, true, false);
		this.m_ItemSource1 = this.m_SynPanel.GetChild(7).GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
		this.m_ItemSource1.gameObject.AddComponent<IgnoreRaycast>();
		GUIManager.Instance.InitianHeroItemImg(this.m_ItemSource1.transform, eHeroOrItem.Hero, 1, 1, 0, 0, false, false, true, false);
		Image image = this.m_SynPanel.GetChild(7).GetChild(1).gameObject.AddComponent<Image>();
		image.material = GUIManager.Instance.GetFrameMaterial();
		image.color = new Color(1f, 1f, 1f, 0f);
		this.m_SynPanel.GetChild(7).GetChild(1).gameObject.AddComponent<UIButton>();
		this.m_ItemSource2 = this.m_SynPanel.GetChild(7).GetChild(2).GetChild(0).GetComponent<UIHIBtn>();
		this.m_ItemSource2.gameObject.AddComponent<IgnoreRaycast>();
		GUIManager.Instance.InitianHeroItemImg(this.m_ItemSource2.transform, eHeroOrItem.Hero, 1, 1, 0, 0, false, false, true, false);
		image = this.m_SynPanel.GetChild(7).GetChild(2).gameObject.AddComponent<Image>();
		image.material = GUIManager.Instance.GetFrameMaterial();
		image.color = new Color(1f, 1f, 1f, 0f);
		this.m_SynPanel.GetChild(7).GetChild(2).gameObject.AddComponent<UIButton>();
		this.m_ItemSource3 = this.m_SynPanel.GetChild(7).GetChild(3).GetChild(0).GetComponent<UIHIBtn>();
		this.m_ItemSource3.gameObject.AddComponent<IgnoreRaycast>();
		GUIManager.Instance.InitianHeroItemImg(this.m_ItemSource3.transform, eHeroOrItem.Hero, 1, 1, 0, 0, false, false, true, false);
		image = this.m_SynPanel.GetChild(7).GetChild(3).gameObject.AddComponent<Image>();
		image.material = GUIManager.Instance.GetFrameMaterial();
		image.color = new Color(1f, 1f, 1f, 0f);
		this.m_SynPanel.GetChild(7).GetChild(3).gameObject.AddComponent<UIButton>();
	}

	// Token: 0x06001FA4 RID: 8100 RVA: 0x003C5890 File Offset: 0x003C3A90
	private void UpdatePageType(ushort itemID, bool bAdd = true)
	{
		bool flag = true;
		this.m_PageType = e_SynPageType.Synthesis;
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(itemID);
		byte b = recordByKey.EquipKind;
		b -= 1;
		if (b >= 0 && b <= 2)
		{
			int num = recordByKey.SyntheticParts.Length;
			for (int i = 0; i < num; i++)
			{
				if (recordByKey.SyntheticParts[i].SyntheticItem != 0)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				this.m_PageType = e_SynPageType.ItemSource;
			}
		}
		else if (b == 3)
		{
			this.m_PageType = e_SynPageType.FragmentSource;
		}
		else
		{
			this.m_PageType = e_SynPageType.HeroSource;
		}
		this.TypeChange(itemID, bAdd);
	}

	// Token: 0x06001FA5 RID: 8101 RVA: 0x003C5948 File Offset: 0x003C3B48
	private void TypeChange(ushort itemID, bool bAdd = true)
	{
		if (this.m_PageType == e_SynPageType.Synthesis)
		{
			if (bAdd)
			{
				this.AddItem(itemID);
			}
			this.UpdateRequirementPanel(itemID);
			this.m_ItemPanel.gameObject.SetActive(true);
			this.m_HeroItemPanel.gameObject.SetActive(false);
			this.m_ItemSourcePanel.gameObject.SetActive(false);
			this.m_RequirementPanel.gameObject.SetActive(true);
		}
		else if (this.m_PageType == e_SynPageType.ItemSource || this.m_PageType == e_SynPageType.FragmentSource)
		{
			if (bAdd)
			{
				this.AddItem(itemID);
			}
			this.m_SourceItemPanelID = itemID;
			this.SetLevelTableKind(itemID, this.m_LevelTableKind);
			this.m_ItemPanel.gameObject.SetActive(true);
			this.m_HeroItemPanel.gameObject.SetActive(false);
			this.m_ItemSourcePanel.gameObject.SetActive(true);
			this.m_RequirementPanel.gameObject.SetActive(false);
			this.m_SourceBtn[0].gameObject.SetActive(true);
			this.m_SourceBtn[1].gameObject.SetActive(true);
			((RectTransform)this.m_SourceBtn[1]).anchoredPosition = new Vector2(644f, -524.5f);
		}
		else if (this.m_PageType == e_SynPageType.HeroSource)
		{
			this.m_SourceBtn[0].gameObject.SetActive(false);
			this.m_SourceBtn[1].gameObject.SetActive(true);
			this.m_SourceItemPanelID = itemID;
			this.m_HeroItemPanel.gameObject.SetActive(true);
			this.UpdateHeroItemPanel(this.m_SourceItemPanelID);
			this.m_ItemPanel.gameObject.SetActive(false);
			this.SetLevelTableKind(itemID, LevelTableKind.AdvanceStage);
			this.m_ItemSourcePanel.gameObject.SetActive(true);
			this.m_RequirementPanel.gameObject.SetActive(false);
			((RectTransform)this.m_SourceBtn[1]).anchoredPosition = new Vector2(644f, -451.5f);
		}
		if (this.m_ItemData.Count > 1)
		{
			this.m_ReturnBtn.gameObject.SetActive(true);
		}
		else
		{
			this.m_ReturnBtn.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001FA6 RID: 8102 RVA: 0x003C5B70 File Offset: 0x003C3D70
	private void UpdateRequirementPanel(ushort resItemID)
	{
		this.MixPrice = 0u;
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(resItemID);
		byte color = recordByKey.Color;
		this.m_TransBtn.m_BtnID2 = 0;
		this.m_TransBtn.ForTextChange(e_BtnType.e_Normal);
		GUIManager.Instance.ChangeHeroItemImg(this.m_ResultItem.transform, eHeroOrItem.Item, resItemID, color, 0, 0);
		this.m_ResultItemText.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.EquipName);
		this.MixPrice = recordByKey.MixPrice;
		for (int i = 0; i < 5; i++)
		{
			ushort syntheticItem = recordByKey.SyntheticParts[i].SyntheticItem;
			ushort syntheticItemNum = (ushort)recordByKey.SyntheticParts[i].SyntheticItemNum;
			ushort num = syntheticItemNum;
			for (int j = 0; j < 5; j++)
			{
				if (i != j && syntheticItem == recordByKey.SyntheticParts[j].SyntheticItem)
				{
					num += (ushort)recordByKey.SyntheticParts[j].SyntheticItemNum;
				}
			}
			if (syntheticItem != 0)
			{
				GUIManager.Instance.ChangeHeroItemImg(this.m_SynthesisBtns[i].transform, eHeroOrItem.Item, syntheticItem, 0, 0, 0);
				this.m_SynthesisBtns[i].gameObject.SetActive(true);
				this.m_SynthesisBtns[i].m_BtnID2 = (int)syntheticItem;
				ushort num2 = DataManager.Instance.GetCurItemQuantity(syntheticItem, 0);
				if (num2 < num)
				{
					for (int k = 0; k < i; k++)
					{
						if (i != k && syntheticItem == recordByKey.SyntheticParts[k].SyntheticItem && num2 >= (ushort)recordByKey.SyntheticParts[i].SyntheticItemNum)
						{
							num2 -= (ushort)recordByKey.SyntheticParts[i].SyntheticItemNum;
						}
					}
				}
				if (num2 < 0)
				{
					num2 = 0;
				}
				this.sb.Length = 0;
				if (i < this.Fragment.Length)
				{
					this.Fragment[i] = num2;
					this.FragmentMax[i] = syntheticItemNum;
					this.RequirementNum[i] = num;
				}
				if (num2 >= syntheticItemNum)
				{
					if (this.GM.IsArabic)
					{
						this.sb.AppendFormat("{0} / {1}", syntheticItemNum, num2);
					}
					else
					{
						this.sb.AppendFormat("{0} / {1}", num2, syntheticItemNum);
					}
				}
				else
				{
					this.m_TransBtn.m_BtnID2 = 1;
					this.m_TransBtn.ForTextChange(e_BtnType.e_ChangeText);
					if (this.GM.IsArabic)
					{
						this.sb.AppendFormat("{0} / <color=#FF0000>{1}</color>", syntheticItemNum, num2);
					}
					else
					{
						this.sb.AppendFormat("<color=#FF0000>{0}</color> / {1}", num2, syntheticItemNum);
					}
				}
				this.m_SynthesisBtnTexts[i].text = this.sb.ToString();
				this.m_SynthesisBtnTexts[i].gameObject.SetActive(true);
			}
			else
			{
				this.m_SynthesisBtns[i].gameObject.SetActive(false);
				this.m_SynthesisBtnTexts[i].gameObject.SetActive(false);
			}
		}
		this.m_NeedMoneyText.text = this.MixPrice.ToString();
		if (this.MixPrice > DataManager.Instance.Resource[4].Stock)
		{
			this.m_TransBtn.ForTextChange(e_BtnType.e_ChangeText);
			this.m_TransBtn.m_BtnID2 = 2;
		}
		GUIManager.Instance.m_ItemInfo.UpdateSynthesis();
	}

	// Token: 0x06001FA7 RID: 8103 RVA: 0x003C5F14 File Offset: 0x003C4114
	private bool UpdateSourceItemPanel(ushort resItemID, LevelTableKind kind)
	{
		int num = 0;
		int num2 = DataManager.StageDataController.LevelTable[(int)kind].TableCount;
		bool result = false;
		this.m_ItemSourceData.Clear();
		for (int i = 0; i < num2; i++)
		{
			Level recordByIndex = DataManager.StageDataController.LevelTable[(int)kind].GetRecordByIndex(i);
			for (int j = 0; j < 7; j++)
			{
				RewardScore recordByKey = DataManager.Instance.RewardScoreTable.GetRecordByKey(recordByIndex.TreasureNo);
				if (recordByKey.Rewards != null && recordByKey.Rewards[j] == resItemID)
				{
					this.m_ItemSourceData.Add(recordByIndex.LevelKey);
					num++;
					break;
				}
			}
		}
		num2 = ((this.m_ItemSourceData.Count % 3 != 0) ? (this.m_ItemSourceData.Count / 3 + 1) : (this.m_ItemSourceData.Count / 3));
		List<float> list = new List<float>();
		for (int k = 0; k < num2; k++)
		{
			list.Add(this.m_SourceItemHeight);
		}
		this.m_SourceItemScrollPanel.AddNewDataHeight(list, true, true);
		Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(resItemID);
		this.m_ItemSourceNameStr.ClearString();
		UIItemInfo.SetNameProperties(this.m_ItemSourceName, null, this.m_ItemSourceNameStr, null, ref recordByKey2, null);
		ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(resItemID, 0);
		if (this.m_PageType == e_SynPageType.FragmentSource && (int)this.NowClickIdx < this.Fragment.Length)
		{
			this.sb.Length = 0;
			if (curItemQuantity < this.FragmentMax[(int)this.NowClickIdx])
			{
				this.sb.AppendFormat("{0} <color=#FF0000>{1}</color><color=#FFFFFF> / {2}</color>", this.m_ItemSourceName.text, curItemQuantity, this.FragmentMax[(int)this.NowClickIdx]);
			}
			else
			{
				this.sb.AppendFormat("{0} <color=#FFFFFF>{1}</color><color=#FFFFFF> / {2}</color>", this.m_ItemSourceName.text, curItemQuantity, this.FragmentMax[(int)this.NowClickIdx]);
			}
			this.m_ItemSourceName.text = this.sb.ToString();
		}
		if (recordByKey2.SyntheticParts != null && recordByKey2.SyntheticParts[1].SyntheticItem != 0)
		{
			this.m_SourceText.enabled = true;
			this.m_SourceText.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey2.SyntheticParts[1].SyntheticItem);
			result = true;
		}
		else
		{
			this.m_SourceText.enabled = false;
		}
		return result;
	}

	// Token: 0x06001FA8 RID: 8104 RVA: 0x003C61B4 File Offset: 0x003C43B4
	private void UpdateHeroItemPanel(ushort itemID)
	{
		ushort[] array = new ushort[]
		{
			10,
			30,
			80,
			180,
			330
		};
		bool flag = false;
		ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(itemID, 0);
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(itemID);
		if (recordByKey.SyntheticParts == null)
		{
			return;
		}
		GUIManager.Instance.ChangeHeroItemImg(this.m_HeroItem.gameObject.transform, eHeroOrItem.Item, itemID, recordByKey.Color, 0, 0);
		ushort num = (ushort)recordByKey.SyntheticParts[0].SyntheticItemNum;
		this.sb.Length = 0;
		Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(recordByKey.SyntheticParts[0].SyntheticItem);
		if (!DataManager.Instance.curHeroData.ContainsKey((uint)recordByKey.SyntheticParts[0].SyntheticItem))
		{
			if (recordByKey2.defaultStar >= 1 && (int)(recordByKey2.defaultStar - 1) < array.Length)
			{
				num = array[(int)(recordByKey2.defaultStar - 1)];
			}
		}
		else
		{
			CurHeroData curHeroData = DataManager.Instance.curHeroData[(uint)recordByKey2.HeroKey];
			int num2 = DataManager.Instance.Medal.Length;
			if (curHeroData.Star >= 0 && (int)curHeroData.Star < num2)
			{
				num = (ushort)DataManager.Instance.Medal[(int)curHeroData.Star];
			}
			else
			{
				flag = true;
			}
		}
		if (!flag)
		{
			if (curItemQuantity >= num)
			{
				if (this.GM.IsArabic)
				{
					this.sb.AppendFormat("{0} / {1}", num, curItemQuantity);
				}
				else
				{
					this.sb.AppendFormat("{0} / {1}", curItemQuantity, num);
				}
			}
			else if (this.GM.IsArabic)
			{
				this.sb.AppendFormat("{0} / <color=#FF0000>{1}</color>", num, curItemQuantity);
			}
			else
			{
				this.sb.AppendFormat("<color=#FF0000>{0}</color> / {1}", curItemQuantity, num);
			}
		}
		else
		{
			this.sb.AppendFormat("{0} {1}", DataManager.Instance.mStringTable.GetStringByID(281u), curItemQuantity);
		}
		this.m_HeroItemText.text = this.sb.ToString();
	}

	// Token: 0x06001FA9 RID: 8105 RVA: 0x003C6418 File Offset: 0x003C4618
	private void SetStageBtn(ushort stageKey, Transform btn, LevelTableKind kind)
	{
		Level recordByKey = DataManager.StageDataController.LevelTable[(int)kind].GetRecordByKey(stageKey);
		HeroTeam recordByKey2 = DataManager.Instance.TeamTable.GetRecordByKey(recordByKey.Team[2]);
		int num = recordByKey2.Arrays.Length;
		for (int i = 0; i < num; i++)
		{
			if (recordByKey2.Arrays[i].Type == 3)
			{
				GUIManager.Instance.ChangeHeroItemImg(btn.GetChild(0), eHeroOrItem.Hero, recordByKey2.Arrays[i].Hero, recordByKey2.HeroStar, 0, 0);
				this.m_tmpStr1 = btn.GetChild(2).GetComponent<UIText>();
				this.sb.Length = 0;
				int num2 = (int)((stageKey % 6 != 0) ? (stageKey / 6 + 1) : (stageKey / 6));
				int num3 = (int)((stageKey % 6 != 0) ? (stageKey % 6) : 6);
				if (this.GM.IsArabic)
				{
					this.sb.AppendFormat("{1}-{0}", num2, num3 * 3);
				}
				else
				{
					this.sb.AppendFormat("{0}-{1}", num2, num3 * 3);
				}
				this.m_tmpStr1.text = this.sb.ToString();
				ushort num4 = (kind != LevelTableKind.NormalStage) ? DataManager.StageDataController.StageRecord[1] : DataManager.StageDataController.StageRecord[0];
				ushort num5 = (kind != LevelTableKind.NormalStage) ? stageKey : (stageKey * 3);
				int num6 = 0;
				if (this.m_LevelTableKind == LevelTableKind.NormalStage)
				{
					num6 = DataManager.StageDataController.GetStagePoint(stageKey * 3, 1);
				}
				else if (this.m_LevelTableKind == LevelTableKind.AdvanceStage)
				{
					num6 = DataManager.StageDataController.GetStagePoint(stageKey, 2);
				}
				if (num5 <= num4 && num6 > 0)
				{
					btn.GetComponent<UIButton>().m_BtnID2 = (int)stageKey;
					btn.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f);
					if (kind == LevelTableKind.AdvanceStage)
					{
						btn.GetChild(1).gameObject.SetActive(true);
						btn.GetChild(3).gameObject.SetActive(true);
						this.m_tmpStr2 = btn.GetChild(3).GetChild(0).GetComponent<UIText>();
						int num7 = DataManager.StageDataController.StageInfo[1][(int)(stageKey - 1)] >> 2 & 63;
						VIP_DataTbl recordByKey3 = DataManager.Instance.VIPLevelTable.GetRecordByKey((ushort)DataManager.Instance.RoleAttr.VIPLevel);
						if (recordByKey3.DailyResetElite == 255)
						{
							this.m_tmpStr2.resizeTextMaxSize = 30;
							this.m_tmpStr2.text = DataManager.Instance.mStringTable.GetStringByID(5808u);
							this.m_tmpStr2.rectTransform.sizeDelta = new Vector2(this.m_tmpStr2.rectTransform.sizeDelta.x, 36f);
						}
						else
						{
							this.m_tmpStr2.resizeTextMaxSize = 20;
							this.m_tmpStr2.rectTransform.sizeDelta = new Vector2(this.m_tmpStr2.rectTransform.sizeDelta.x, 26f);
							int num8 = (int)recordByKey3.DailyResetElite - num7;
							this.sb.Length = 0;
							if (num8 <= 0)
							{
								if (this.GM.IsArabic)
								{
									this.sb.AppendFormat("{0} / <color=#FF0000>{1}</color>", recordByKey3.DailyResetElite, num8);
								}
								else
								{
									this.sb.AppendFormat("<color=#FF0000>{0}</color> / {1}", num8, recordByKey3.DailyResetElite);
								}
							}
							else if (this.GM.IsArabic)
							{
								this.sb.AppendFormat("{0} / {1}", recordByKey3.DailyResetElite, num8);
							}
							else
							{
								this.sb.AppendFormat("{0} / {1}", num8, recordByKey3.DailyResetElite);
							}
							this.m_tmpStr2.text = this.sb.ToString();
						}
					}
					else
					{
						btn.GetChild(3).gameObject.SetActive(false);
						btn.GetChild(1).gameObject.SetActive(false);
					}
				}
				else
				{
					btn.GetComponent<UIButton>().m_BtnID2 = 0;
					btn.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
					if (kind == LevelTableKind.AdvanceStage)
					{
						btn.GetChild(1).gameObject.SetActive(true);
					}
					else
					{
						btn.GetChild(1).gameObject.SetActive(false);
					}
					btn.GetChild(3).gameObject.SetActive(false);
				}
				break;
			}
		}
	}

	// Token: 0x06001FAA RID: 8106 RVA: 0x003C68FC File Offset: 0x003C4AFC
	private void SetLevelTableKind(ushort resItemID, LevelTableKind kind)
	{
		this.m_LevelTableKind = kind;
		bool flag = this.UpdateSourceItemPanel(resItemID, this.m_LevelTableKind);
		this.m_ArrowImgae[0].gameObject.SetActive(false);
		this.m_ArrowImgae[1].gameObject.SetActive(false);
		this.m_FuncBtnText[0].color = new Color(0.7f, 0.7f, 0.7f, 1f);
		this.m_FuncBtnText[1].color = new Color(0.7f, 0.7f, 0.7f, 1f);
		this.m_FuncBtnImage[0].color = new Color(0.7f, 0.7f, 0.7f, 1f);
		this.m_FuncBtnImage[1].color = new Color(0.7f, 0.7f, 0.7f, 1f);
		if (kind == LevelTableKind.AdvanceStage)
		{
			if (flag)
			{
				this.m_SourceBtn[1].gameObject.SetActive(false);
				this.m_ArrowImgae[1].gameObject.SetActive(false);
			}
			else
			{
				this.m_ArrowImgae[1].gameObject.SetActive(true);
			}
			this.m_FuncBtnText[1].color = new Color(1f, 1f, 1f, 1f);
			this.m_FuncBtnImage[1].color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			this.m_ArrowImgae[0].gameObject.SetActive(true);
			this.m_FuncBtnText[0].color = new Color(1f, 1f, 1f, 1f);
			this.m_FuncBtnImage[0].color = new Color(1f, 1f, 1f, 1f);
		}
	}

	// Token: 0x06001FAB RID: 8107 RVA: 0x003C6AD8 File Offset: 0x003C4CD8
	private void AddItem(ushort itemID)
	{
		this.m_ItemData.Add(itemID);
		int count = this.m_ItemData.Count;
		List<float> list = new List<float>();
		for (int i = 0; i < count; i++)
		{
			list.Add(this.m_ItemHeight);
		}
		this.m_ItemScrollPanel.AddNewDataHeight(list, true, true);
	}

	// Token: 0x06001FAC RID: 8108 RVA: 0x003C6B30 File Offset: 0x003C4D30
	private void ReturnItem()
	{
		int num = this.m_ItemData.Count - 1;
		if (num >= 0 && num < this.m_ItemData.Count)
		{
			this.m_ItemData.RemoveAt(num);
			List<float> list = new List<float>();
			for (int i = 0; i < this.m_ItemData.Count; i++)
			{
				list.Add(this.m_ItemHeight);
			}
			this.m_ItemScrollPanel.AddNewDataHeight(list, true, true);
			if (list.Count > 1)
			{
				this.m_ReturnBtn.gameObject.SetActive(true);
			}
			else
			{
				this.m_ReturnBtn.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001FAD RID: 8109 RVA: 0x003C6BE0 File Offset: 0x003C4DE0
	private void GoTo(int idx)
	{
		ushort itemID = this.m_ItemData[idx];
		int num = this.m_ItemData.Count - 1;
		this.m_ItemData.RemoveRange(idx, this.m_ItemData.Count - idx);
		List<float> list = new List<float>();
		for (int i = 0; i < this.m_ItemData.Count; i++)
		{
			list.Add(this.m_ItemHeight);
		}
		this.m_ItemScrollPanel.AddNewDataHeight(list, true, true);
		this.UpdatePageType(itemID, true);
	}

	// Token: 0x06001FAE RID: 8110 RVA: 0x003C6C68 File Offset: 0x003C4E68
	public override bool OnBackButtonClick()
	{
		if (GUIManager.Instance.m_ItemInfo.m_RectTransform.gameObject.activeSelf)
		{
			GUIManager.Instance.m_ItemInfo.Hide();
		}
		return false;
	}

	// Token: 0x06001FAF RID: 8111 RVA: 0x003C6CA4 File Offset: 0x003C4EA4
	public void SaveUIState()
	{
		int count = this.m_ItemData.Count;
		for (int i = 1; i < count; i++)
		{
			this.GM.m_SynthesisItemData.Add(this.m_ItemData[i]);
		}
		this.GM.m_SynthesisPageType = this.m_PageType;
		this.GM.m_SynthesisScrollIdx = this.m_SourceItemScrollPanel.GetTopIdx();
		this.GM.m_SynthesisScrollRectY = this.m_SourceItemScrollPanelRect.anchoredPosition.y;
		this.GM.m_SynthesisBtnType = this.m_LevelTableKind;
		for (int j = 0; j < this.RequirementNum.Length; j++)
		{
			this.GM.m_RequirementNum[j] = this.RequirementNum[j];
		}
	}

	// Token: 0x06001FB0 RID: 8112 RVA: 0x003C6D70 File Offset: 0x003C4F70
	public void SetUIState()
	{
		if (this.m_PageType != e_SynPageType.HeroSource)
		{
			this.m_PageType = GUIManager.Instance.m_SynthesisPageType;
		}
		int count = this.GM.m_SynthesisItemData.Count;
		if (this.m_PageType != e_SynPageType.HeroSource)
		{
			this.m_LevelTableKind = this.GM.m_SynthesisBtnType;
			if (this.m_LevelTableKind == LevelTableKind.NormalStage)
			{
				this.SetLevelTableKind(this.m_SourceItemPanelID, LevelTableKind.NormalStage);
			}
			else
			{
				this.SetLevelTableKind(this.m_SourceItemPanelID, LevelTableKind.AdvanceStage);
			}
		}
		for (int i = 0; i < count; i++)
		{
			this.UpdatePageType(this.GM.m_SynthesisItemData[i], true);
		}
		ushort synthesisItemIdx = GUIManager.Instance.m_SynthesisItemIdx;
		if (this.GM.m_RequirementNum[(int)synthesisItemIdx] != 0 && this.Fragment[(int)synthesisItemIdx] >= this.GM.m_RequirementNum[(int)synthesisItemIdx])
		{
			if (this.m_PageType != e_SynPageType.Synthesis)
			{
				this.ReturnItem();
			}
			if (this.m_ItemData.Count > 0)
			{
				this.UpdatePageType(this.m_ItemData[this.m_ItemData.Count - 1], false);
			}
		}
		this.m_SourceItemScrollPanel.GoTo(this.GM.m_SynthesisScrollIdx, this.GM.m_SynthesisScrollRectY);
	}

	// Token: 0x040063D3 RID: 25555
	private const int m_MaxSourceItemPanelObject = 3;

	// Token: 0x040063D4 RID: 25556
	private const int TextMax = 5;

	// Token: 0x040063D5 RID: 25557
	private Transform m_SynPanel;

	// Token: 0x040063D6 RID: 25558
	private Transform m_HeroItemPanel;

	// Token: 0x040063D7 RID: 25559
	private Transform m_ItemPanel;

	// Token: 0x040063D8 RID: 25560
	private Transform m_RequirementPanel;

	// Token: 0x040063D9 RID: 25561
	private Transform m_ItemSourcePanel;

	// Token: 0x040063DA RID: 25562
	private Transform[] m_SourceBtn;

	// Token: 0x040063DB RID: 25563
	private Image m_ExiteBtnImage;

	// Token: 0x040063DC RID: 25564
	public UIButton m_ExiteBtn;

	// Token: 0x040063DD RID: 25565
	private UIButton m_ReturnBtn;

	// Token: 0x040063DE RID: 25566
	private ScrollPanel m_ItemScrollPanel;

	// Token: 0x040063DF RID: 25567
	private UIHIBtn m_Item;

	// Token: 0x040063E0 RID: 25568
	private UIHIBtn m_ResultItem;

	// Token: 0x040063E1 RID: 25569
	private UIText m_ResultItemText;

	// Token: 0x040063E2 RID: 25570
	private UIHIBtn[] m_SynthesisBtns;

	// Token: 0x040063E3 RID: 25571
	private UIText[] m_SynthesisBtnTexts;

	// Token: 0x040063E4 RID: 25572
	private UIButton m_TransBtn;

	// Token: 0x040063E5 RID: 25573
	private UIText m_NeedMoneyText;

	// Token: 0x040063E6 RID: 25574
	private UIHIBtn m_HeroItem;

	// Token: 0x040063E7 RID: 25575
	private UIText m_HeroItemText;

	// Token: 0x040063E8 RID: 25576
	private UIButton m_InfoBtn;

	// Token: 0x040063E9 RID: 25577
	private Image[] m_EffectImage;

	// Token: 0x040063EA RID: 25578
	private Transform m_EffectPanel;

	// Token: 0x040063EB RID: 25579
	private RectTransform m_EffectImage1Rt;

	// Token: 0x040063EC RID: 25580
	private ScrollPanel m_SourceItemScrollPanel;

	// Token: 0x040063ED RID: 25581
	private UIHIBtn m_ItemSource1;

	// Token: 0x040063EE RID: 25582
	private UIHIBtn m_ItemSource2;

	// Token: 0x040063EF RID: 25583
	private UIHIBtn m_ItemSource3;

	// Token: 0x040063F0 RID: 25584
	private UIText m_ItemSourceName;

	// Token: 0x040063F1 RID: 25585
	private CString m_ItemSourceNameStr;

	// Token: 0x040063F2 RID: 25586
	private Transform[] m_ArrowImgae;

	// Token: 0x040063F3 RID: 25587
	private UIText[] m_FuncBtnText;

	// Token: 0x040063F4 RID: 25588
	private Image[] m_FuncBtnImage;

	// Token: 0x040063F5 RID: 25589
	private UIText m_SourceText;

	// Token: 0x040063F6 RID: 25590
	private int m_MaxItemPanelObject = 6;

	// Token: 0x040063F7 RID: 25591
	private UIHIBtn[] m_ItemBtns;

	// Token: 0x040063F8 RID: 25592
	private Image[] m_ItemSelects;

	// Token: 0x040063F9 RID: 25593
	private Transform[] m_SourceItemBtn1s;

	// Token: 0x040063FA RID: 25594
	private Transform[] m_SourceItemBtn2s;

	// Token: 0x040063FB RID: 25595
	private Transform[] m_SourceItemBtn3s;

	// Token: 0x040063FC RID: 25596
	private UIHIBtn[] m_SourceBtn1s;

	// Token: 0x040063FD RID: 25597
	private UIHIBtn[] m_SourceBtn2s;

	// Token: 0x040063FE RID: 25598
	private UIHIBtn[] m_SourceBtn3s;

	// Token: 0x040063FF RID: 25599
	private UIButton[] m_SourceUIBtn1s;

	// Token: 0x04006400 RID: 25600
	private UIButton[] m_SourceUIBtn2s;

	// Token: 0x04006401 RID: 25601
	private UIButton[] m_SourceUIBtn3s;

	// Token: 0x04006402 RID: 25602
	private e_SynPageType m_PageType;

	// Token: 0x04006403 RID: 25603
	private LevelTableKind m_LevelTableKind;

	// Token: 0x04006404 RID: 25604
	private ushort m_FisetItemID = 105;

	// Token: 0x04006405 RID: 25605
	private List<ushort> m_ItemData;

	// Token: 0x04006406 RID: 25606
	private List<ushort> m_ItemSourceData;

	// Token: 0x04006407 RID: 25607
	private ushort m_SourceItemPanelID;

	// Token: 0x04006408 RID: 25608
	private float m_ItemHeight = 64f;

	// Token: 0x04006409 RID: 25609
	private float m_SourceItemHeight = 160f;

	// Token: 0x0400640A RID: 25610
	private float m_ColorTick;

	// Token: 0x0400640B RID: 25611
	private float m_ColorA;

	// Token: 0x0400640C RID: 25612
	private bool m_ShowTransEffect;

	// Token: 0x0400640D RID: 25613
	private Vector2 m_BeginMove = new Vector2(-33f, 145.5f);

	// Token: 0x0400640E RID: 25614
	private Vector2 m_EndMove = new Vector2(-33f, 0f);

	// Token: 0x0400640F RID: 25615
	private Vector2 m_Step;

	// Token: 0x04006410 RID: 25616
	private bool m_Moveing;

	// Token: 0x04006411 RID: 25617
	private bool m_CenterPos;

	// Token: 0x04006412 RID: 25618
	private bool _m_MovingExit;

	// Token: 0x04006413 RID: 25619
	private uint MixPrice;

	// Token: 0x04006414 RID: 25620
	private RectTransform m_SourceItemScrollPanelRect;

	// Token: 0x04006415 RID: 25621
	private StringBuilder sb;

	// Token: 0x04006416 RID: 25622
	private Transform m_TransForm;

	// Token: 0x04006417 RID: 25623
	private GUIManager GM = GUIManager.Instance;

	// Token: 0x04006418 RID: 25624
	private bool bNeedSaveUIState;

	// Token: 0x04006419 RID: 25625
	private bool bSaveUIState_Money;

	// Token: 0x0400641A RID: 25626
	private byte NowClickIdx;

	// Token: 0x0400641B RID: 25627
	private ushort[] Fragment = new ushort[5];

	// Token: 0x0400641C RID: 25628
	private ushort[] FragmentMax = new ushort[5];

	// Token: 0x0400641D RID: 25629
	private ushort[] RequirementNum = new ushort[5];

	// Token: 0x0400641E RID: 25630
	private ushort[] SynthesisItemNum = new ushort[5];

	// Token: 0x0400641F RID: 25631
	private int mTextCount;

	// Token: 0x04006420 RID: 25632
	private UIText[] m_tmptext = new UIText[5];

	// Token: 0x04006421 RID: 25633
	private UIText m_tmpStr1;

	// Token: 0x04006422 RID: 25634
	private UIText m_tmpStr2;

	// Token: 0x04006423 RID: 25635
	private UIText[][] m_tmpItemtext1 = new UIText[3][];

	// Token: 0x04006424 RID: 25636
	private UIText[][] m_tmpItemtext2 = new UIText[3][];

	// Token: 0x04006425 RID: 25637
	private UIText[][] m_tmpItemtext3 = new UIText[3][];

	// Token: 0x04006426 RID: 25638
	private float MoveDelta;

	// Token: 0x04006427 RID: 25639
	private short PassFrame = 3;

	// Token: 0x04006428 RID: 25640
	private bool bInit;
}
