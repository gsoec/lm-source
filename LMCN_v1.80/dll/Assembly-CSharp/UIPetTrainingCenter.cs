using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000492 RID: 1170
internal class UIPetTrainingCenter : GUIWindow, IBuildingWindowType, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUTimeBarOnTimer
{
	// Token: 0x060017C3 RID: 6083 RVA: 0x00287568 File Offset: 0x00285768
	public override void OnOpen(int arg1, int arg2)
	{
		this.m_ManorID = (ushort)arg1;
		PetManager.Instance.SortPetIdle();
		this.PetMgr = PetManager.Instance;
		this.m_Sp = base.transform.GetComponent<UISpritesArray>();
		this.m_ScrollObjects = new UIPetTrainingCenter.SSrollPanelItem[6];
		for (int i = 0; i < this.m_ScrollObjects.Length; i++)
		{
			this.m_ScrollObjects[i] = new UIPetTrainingCenter.SSrollPanelItem(this.m_Sp);
		}
		this.m_AdditionExpText = new UIText[2];
		this.m_TrainCountText = new UIText[2];
		this.SpawnString();
		this.Init();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
		if (GUIManager.Instance.BuildingData.AllBuildsData[(int)this.m_ManorID].Level != 0)
		{
			NewbieManager.CheckPetTraining();
		}
	}

	// Token: 0x060017C4 RID: 6084 RVA: 0x00287640 File Offset: 0x00285840
	public override void OnClose()
	{
		if (this.m_BuildingWindow != null)
		{
			this.m_BuildingWindow.DestroyBuildingWindow();
		}
		this.DeSpawnString();
		if (this.m_ScrollPanel != null)
		{
			this.PetMgr.m_TrainListIndex = this.m_ScrollPanel.GetTopIdx();
			this.PetMgr.m_TrainListY = this.m_ScrollPanel.GetContentPos();
		}
	}

	// Token: 0x060017C5 RID: 6085 RVA: 0x002876AC File Offset: 0x002858AC
	public override void UpdateUI(int arg1, int arg2)
	{
		this.UpdateScrollPanel(-1);
		this.UpdateTrainPet();
	}

	// Token: 0x060017C6 RID: 6086 RVA: 0x002876BC File Offset: 0x002858BC
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			this.UpdateScrollPanel(-1);
			break;
		default:
			if (networkNews != NetworkNews.Refresh_BuildBase)
			{
				if (networkNews != NetworkNews.Refresh_AttribEffectVal)
				{
					if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
					{
						this.RefreshFontTexture();
					}
				}
				else
				{
					this.UpdateAdditionExp();
				}
			}
			else
			{
				this.m_BuildingWindow.MyUpdate(meg[1], false);
			}
			break;
		}
	}

	// Token: 0x060017C7 RID: 6087 RVA: 0x00287734 File Offset: 0x00285934
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK && arg2 == 255)
		{
			GUIManager.Instance.BuildingData.ManorGuild((ushort)arg1, false);
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.CloseMenu(false);
		}
		else if (arg1 < 2)
		{
			if (bOK)
			{
				this.DialogOnOK((UIPetTrainingCenter.EDialogState)arg1, (byte)arg2);
			}
		}
		else
		{
			int num = arg1 - 2;
			byte dataIdx = (byte)arg2;
			if (num >= 0 && num < this.m_ScrollObjects.Length)
			{
				this.m_ScrollObjects[num].OnTrain(dataIdx);
			}
		}
	}

	// Token: 0x060017C8 RID: 6088 RVA: 0x002877CC File Offset: 0x002859CC
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x060017C9 RID: 6089 RVA: 0x002877D0 File Offset: 0x002859D0
	private void Update()
	{
		for (int i = 0; i < this.m_ScrollObjects.Length; i++)
		{
			this.m_ScrollObjects[i].Run();
		}
		UIPetTrainingCenter.SSrollPanelItem.StaticRun();
	}

	// Token: 0x060017CA RID: 6090 RVA: 0x0028780C File Offset: 0x00285A0C
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
		{
			this.SetType(UIPetTrainingCenter.EUIPage.eFirst);
		}
		else
		{
			this.SetType(UIPetTrainingCenter.EUIPage.eSecond);
		}
	}

	// Token: 0x060017CB RID: 6091 RVA: 0x00287838 File Offset: 0x00285A38
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelObjectIdx < 6)
		{
			if (!this.m_ScrollObjects[panelObjectIdx].HasInstance)
			{
				this.InitScrollItem(item, dataIdx, panelObjectIdx);
			}
			this.UpdateScrollItem(dataIdx, panelObjectIdx);
		}
	}

	// Token: 0x060017CC RID: 6092 RVA: 0x00287874 File Offset: 0x00285A74
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x060017CD RID: 6093 RVA: 0x00287878 File Offset: 0x00285A78
	public void OnTimer(UITimeBar sender)
	{
	}

	// Token: 0x060017CE RID: 6094 RVA: 0x0028787C File Offset: 0x00285A7C
	public void OnNotify(UITimeBar sender)
	{
	}

	// Token: 0x060017CF RID: 6095 RVA: 0x00287880 File Offset: 0x00285A80
	public void Onfunc(UITimeBar sender)
	{
	}

	// Token: 0x060017D0 RID: 6096 RVA: 0x00287884 File Offset: 0x00285A84
	public void OnCancel(UITimeBar sender)
	{
		if (sender != null && sender.m_CancelBtn != null)
		{
			byte panelObjectIdx = (byte)sender.m_CancelBtn.m_BtnID3;
			this.ShowDialog(UIPetTrainingCenter.EDialogState.CancelTrain, (int)panelObjectIdx);
		}
	}

	// Token: 0x060017D1 RID: 6097 RVA: 0x002878C4 File Offset: 0x00285AC4
	public void OnButtonClick(UIButton sender)
	{
		byte b = (byte)sender.m_BtnID2;
		int btnID = sender.m_BtnID3;
		switch (sender.m_BtnID1)
		{
		case 0:
			this.ShowDialog(UIPetTrainingCenter.EDialogState.CancelTrain, btnID);
			break;
		case 1:
			if (PetManager.Instance.PetDataCount == 0)
			{
				StringTable mStringTable = DataManager.Instance.mStringTable;
				GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(17138u), mStringTable.GetStringByID(17139u), mStringTable.GetStringByID(3968u), this, 22, 255, true, false, true, false, false);
			}
			else if (btnID >= 0 && btnID < this.m_ScrollObjects.Length)
			{
				ushort petId = this.PetMgr.m_PetTrainingClinetSave[(int)b].m_PetTrainingSet.m_PetId;
				bool flag = false;
				for (int i = 0; i < this.PetMgr.m_PetTrainingData.Length; i++)
				{
					if (i != (int)b && (this.PetMgr.m_PetTrainingData[i].m_State == PetManager.EPetTrainDataState.Training || this.PetMgr.m_PetTrainingData[i].m_State == PetManager.EPetTrainDataState.CanReceive))
					{
						if (this.PetMgr.m_PetTrainingData[i].m_PetTrainingSet.m_PetId == petId)
						{
							flag = true;
							break;
						}
						for (int j = 0; j < this.PetMgr.m_PetTrainingClinetSave[(int)b].m_PetTrainingSet.m_CoachHeroId.Count; j++)
						{
							ushort item = this.PetMgr.m_PetTrainingClinetSave[(int)b].m_PetTrainingSet.m_CoachHeroId[j];
							if (this.PetMgr.m_PetTrainingData[i].m_PetTrainingSet.m_CoachHeroId.Contains(item))
							{
								flag = true;
								break;
							}
						}
					}
				}
				if (flag)
				{
					GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(17115u), DataManager.Instance.mStringTable.GetStringByID(17116u), null, this, btnID + 2, (int)b, false, false, false, false, false);
					return;
				}
				this.m_ScrollObjects[btnID].OnTrain(b);
			}
			break;
		case 2:
			if ((int)b < this.PetMgr.m_PetTrainingData.Length)
			{
				uint totalExp = this.PetMgr.m_PetTrainingData[(int)b].m_TotalExp;
				ushort petId2 = this.PetMgr.m_PetTrainingData[(int)b].m_PetTrainingSet.m_PetId;
				PetData petData = this.PetMgr.FindPetData(petId2);
				byte maxLevel = petData.GetMaxLevel(true);
				if (petData != null)
				{
					uint num = 0u;
					if (petData.Level < 60)
					{
						byte b2 = petData.Level;
						while (b2 < 60 && b2 <= maxLevel)
						{
							uint needExp = this.PetMgr.GetNeedExp(b2, petData.Rare);
							uint num2;
							if (petData.Level == b2)
							{
								num2 = petData.Exp;
							}
							else
							{
								num2 = 0u;
							}
							num += needExp - num2;
							b2 += 1;
						}
					}
					if (petData.Level < 60 && totalExp >= num)
					{
						this.ShowDialog(UIPetTrainingCenter.EDialogState.OverExp, btnID);
					}
					else if (btnID >= 0 && btnID < this.m_ScrollObjects.Length)
					{
						this.m_ScrollObjects[btnID].OnReceive();
					}
				}
			}
			break;
		}
	}

	// Token: 0x060017D2 RID: 6098 RVA: 0x00287C44 File Offset: 0x00285E44
	public void OnHIButtonClick(UIHIBtn sender)
	{
		int btnID = sender.m_BtnID2;
		PetData petData = this.PetMgr.FindPetData((ushort)btnID);
		if (btnID > 0 && petData != null)
		{
			this.PetMgr.OpenPetUI(0, btnID);
		}
	}

	// Token: 0x060017D3 RID: 6099 RVA: 0x00287C80 File Offset: 0x00285E80
	public void OnButtonDown(UIButtonHint sender)
	{
		ushort parm = 17083;
		if (sender.Parm1 == 4)
		{
			parm = 17083;
		}
		else if (sender.Parm1 == 5)
		{
			parm = 17084;
		}
		else if (sender.Parm1 == 6)
		{
			parm = 17085;
		}
		else if (sender.Parm1 == 7)
		{
			parm = 17095;
		}
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 277f, 20, (int)parm, 0, Vector2.zero, UIButtonHint.ePosition.Original);
		AudioManager.Instance.PlayUISFX(UIKind.Normal);
	}

	// Token: 0x060017D4 RID: 6100 RVA: 0x00287D1C File Offset: 0x00285F1C
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(false);
	}

	// Token: 0x060017D5 RID: 6101 RVA: 0x00287D30 File Offset: 0x00285F30
	private void Init()
	{
		this.m_ScrollPanel = base.transform.GetChild(0).GetComponent<ScrollPanel>();
		this.m_BgPenel = base.transform.GetChild(2);
		this.m_TrainCountText[0] = this.m_BgPenel.GetChild(3).GetComponent<UIText>();
		this.m_TrainCountText[1] = this.m_BgPenel.GetChild(4).GetComponent<UIText>();
		this.m_TrainCountText[0].font = GUIManager.Instance.GetTTFFont();
		this.m_TrainCountText[1].font = GUIManager.Instance.GetTTFFont();
		this.m_TrainCountText[0].text = DataManager.Instance.mStringTable.GetStringByID(17081u);
		this.m_AdditionExpText[0] = this.m_BgPenel.GetChild(5).GetComponent<UIText>();
		this.m_AdditionExpText[1] = this.m_BgPenel.GetChild(6).GetComponent<UIText>();
		this.m_AdditionExpText[0].font = GUIManager.Instance.GetTTFFont();
		this.m_AdditionExpText[1].font = GUIManager.Instance.GetTTFFont();
		this.m_AdditionExpText[0].text = DataManager.Instance.mStringTable.GetStringByID(17082u);
		this.InitScorllPanel();
		this.UpdateAdditionExp();
		this.UpdateTrainPet();
		this.m_BuildingWindow = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.m_BuildingWindow.m_Handler = this;
		this.m_BuildingWindow.InitBuildingWindow(23, this.m_ManorID, 2, 1);
		this.m_BuildingWindow.baseTransform.SetAsFirstSibling();
	}

	// Token: 0x060017D6 RID: 6102 RVA: 0x00287EC4 File Offset: 0x002860C4
	private void InitScorllPanel()
	{
		if (!this.bInitScroll)
		{
			byte trainBuildNum = PetManager.Instance.GetTrainBuildNum();
			List<float> list = new List<float>();
			for (int i = 0; i < this.PetMgr.m_PetTrainingData.Length; i++)
			{
				if (this.PetMgr.m_PetTrainingData[i].m_State != PetManager.EPetTrainDataState.Closed)
				{
					list.Add(89f);
				}
			}
			if (this.m_ScrollPanel != null)
			{
				this.m_ScrollPanel.IntiScrollPanel(403f, 0f, 0f, list, 6, this);
			}
			UIButtonHint.scrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
			this.m_ScrollPanel.GoTo(this.PetMgr.m_TrainListIndex, this.PetMgr.m_TrainListY);
			this.bInitScroll = true;
		}
	}

	// Token: 0x060017D7 RID: 6103 RVA: 0x00287F98 File Offset: 0x00286198
	public void UpdateAdditionExp()
	{
		if (this.m_AdditionExpText != null && this.m_AdditionExpText[1] != null)
		{
			uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETTRAININGEXP_EXP_PERCENT);
			float f = effectBaseVal / 100f;
			this.m_CStr[0].ClearString();
			this.m_CStr[0].FloatToFormat(f, 2, false);
			if (GUIManager.Instance.IsArabic)
			{
				this.m_CStr[0].AppendFormat("%{0}");
			}
			else
			{
				this.m_CStr[0].AppendFormat("{0}%");
			}
			this.m_AdditionExpText[1].text = this.m_CStr[0].ToString();
			this.m_AdditionExpText[1].SetAllDirty();
			this.m_AdditionExpText[1].cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x060017D8 RID: 6104 RVA: 0x00288074 File Offset: 0x00286274
	public void UpdateTrainPet()
	{
		if (this.m_TrainCountText != null && this.m_TrainCountText[1] != null)
		{
			byte b = 0;
			byte b2 = 0;
			for (int i = 0; i < this.PetMgr.m_PetTrainingData.Length; i++)
			{
				if (this.PetMgr.m_PetTrainingData[i].m_State == PetManager.EPetTrainDataState.Training)
				{
					b += 1;
				}
				if (this.PetMgr.m_PetTrainingData[i].m_State != PetManager.EPetTrainDataState.Closed && this.PetMgr.m_PetTrainingData[i].m_State != PetManager.EPetTrainDataState.NextOpen)
				{
					b2 += 1;
				}
			}
			this.m_CStr[1].ClearString();
			this.m_CStr[1].IntToFormat((long)b, 1, false);
			this.m_CStr[1].IntToFormat((long)b2, 1, false);
			if (GUIManager.Instance.IsArabic)
			{
				this.m_CStr[1].AppendFormat("{1} / {0}");
			}
			else
			{
				this.m_CStr[1].AppendFormat("{0} / {1}");
			}
			this.m_TrainCountText[1].text = this.m_CStr[1].ToString();
			this.m_TrainCountText[1].SetAllDirty();
			this.m_TrainCountText[1].cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x060017D9 RID: 6105 RVA: 0x002881C4 File Offset: 0x002863C4
	private void UpdateScrollPanel(int animIdx = -1)
	{
		if (this.bInitScroll)
		{
			byte trainBuildNum = PetManager.Instance.GetTrainBuildNum();
			List<float> list = new List<float>();
			for (int i = 0; i < this.PetMgr.m_PetTrainingData.Length; i++)
			{
				if (this.PetMgr.m_PetTrainingData[i].m_State != PetManager.EPetTrainDataState.Closed)
				{
					list.Add(89f);
				}
			}
			if (this.m_ScrollPanel != null)
			{
				this.m_ScrollPanel.AddNewDataHeight(list, false, true);
			}
		}
	}

	// Token: 0x060017DA RID: 6106 RVA: 0x00288254 File Offset: 0x00286454
	private void InitScrollItem(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (panelObjectIdx < this.m_ScrollObjects.Length)
		{
			UIText[] array = new UIText[3];
			Image[] array2 = new Image[3];
			Transform[] array3 = new Transform[]
			{
				item.transform.GetChild(0),
				item.transform.GetChild(1)
			};
			array2[0] = array3[0].GetChild(0).GetChild(0).GetComponent<Image>();
			array2[1] = array3[0].GetChild(0).GetChild(1).GetComponent<Image>();
			array2[2] = array3[0].GetChild(0).GetChild(2).GetComponent<Image>();
			if (GUIManager.Instance.IsArabic)
			{
				array2[2].sprite = this.m_Sp.GetSprite(3);
			}
			UIHIBtn component = array3[0].GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
			component.m_Handler = this;
			component.m_BtnID1 = 3;
			array3[0].GetChild(1).gameObject.AddComponent<EventPatchery>().SetEvnetObj(this.m_ScrollPanel.GetComponent<CScrollRect>());
			Image component2 = array3[0].GetChild(1).GetChild(2).GetComponent<Image>();
			UIText component3 = array3[0].GetChild(1).GetChild(3).GetComponent<UIText>();
			component3.font = GUIManager.Instance.GetTTFFont();
			GUIManager.Instance.InitianHeroItemImg(component.transform, eHeroOrItem.Pet, 1, 1, 0, 1, true, true, true, false);
			Transform component4 = array3[0].GetChild(1).GetChild(1).GetComponent<Transform>();
			Image component5 = array3[0].GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>();
			UIText component6 = array3[0].GetChild(1).GetChild(1).GetChild(2).GetComponent<UIText>();
			component6.font = GUIManager.Instance.GetTTFFont();
			Image component7 = array3[0].GetChild(1).GetChild(4).GetComponent<Image>();
			array3[0].GetChild(2).gameObject.AddComponent<ArabicItemTextureRot>();
			UIButtonHint uibuttonHint = array3[0].GetChild(2).gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 4;
			array[0] = array3[0].GetChild(2).GetChild(0).GetComponent<UIText>();
			array[0].font = GUIManager.Instance.GetTTFFont();
			Image component8 = array3[0].GetChild(3).GetComponent<Image>();
			if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
			{
				component8.sprite = this.m_Sp.GetSprite(2);
			}
			uibuttonHint = array3[0].GetChild(3).gameObject.AddComponent<UIButtonHint>();
			array3[0].GetChild(3).gameObject.AddComponent<ArabicItemTextureRot>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 5;
			array[1] = array3[0].GetChild(3).GetChild(0).GetComponent<UIText>();
			array[1].font = GUIManager.Instance.GetTTFFont();
			uibuttonHint = array3[0].GetChild(4).gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 6;
			array[2] = array3[0].GetChild(4).GetChild(0).GetComponent<UIText>();
			array[2].font = GUIManager.Instance.GetTTFFont();
			UITimeBar component9 = array3[0].GetChild(5).GetComponent<UITimeBar>();
			UIButton component10 = array3[0].GetChild(6).GetComponent<UIButton>();
			component10.m_Handler = this;
			component10.m_BtnID1 = 1;
			UIText component11 = array3[0].GetChild(6).GetChild(0).GetComponent<UIText>();
			component11.font = GUIManager.Instance.GetTTFFont();
			component11.text = DataManager.Instance.mStringTable.GetStringByID(17087u);
			UIButton component12 = array3[0].GetChild(7).GetComponent<UIButton>();
			component12.m_Handler = this;
			component12.m_BtnID1 = 2;
			component11 = array3[0].GetChild(7).GetChild(1).GetComponent<UIText>();
			component11.font = GUIManager.Instance.GetTTFFont();
			component11.text = DataManager.Instance.mStringTable.GetStringByID(17093u);
			Image component13 = array3[0].GetChild(7).GetChild(0).GetComponent<Image>();
			Transform child = array3[0].GetChild(8);
			Image component14 = child.GetChild(0).GetComponent<Image>();
			uibuttonHint = component14.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 7;
			Transform child2 = child.GetChild(1);
			UIText component15 = child2.GetChild(2).GetComponent<UIText>();
			component15.font = GUIManager.Instance.GetTTFFont();
			Image component16 = child2.GetChild(0).GetComponent<Image>();
			Image component17 = child.GetChild(2).GetComponent<Image>();
			UIText component18 = child.GetChild(3).GetComponent<UIText>();
			component18.font = GUIManager.Instance.GetTTFFont();
			array3[1].GetChild(0).GetComponent<Image>();
			Image component19 = array3[1].GetChild(0).GetComponent<Image>();
			UIText component20 = array3[1].GetChild(1).GetComponent<UIText>();
			component20.font = GUIManager.Instance.GetTTFFont();
			component20.text = DataManager.Instance.mStringTable.GetStringByID(17086u);
			this.SetCenterText(component19, component20, 829f);
			this.m_ScrollObjects[panelObjectIdx].Init(array3, component20, array2, component, component5, component4, component6, component7, array, component9, dataIdx, component10, component12, component13, component2, component3, child, child2, component15, component18, component17, component16, component14);
		}
	}

	// Token: 0x060017DB RID: 6107 RVA: 0x002887DC File Offset: 0x002869DC
	private void UpdateScrollItem(int dataIdx, int panelObjectIdx)
	{
		if (panelObjectIdx < this.m_ScrollObjects.Length)
		{
			ushort petId = this.PetMgr.m_PetTrainingData[dataIdx].m_PetTrainingSet.m_PetId;
			PetData petData = this.PetMgr.FindPetData(petId);
			PetManager.EPetTrainDataState state = this.PetMgr.m_PetTrainingData[dataIdx].m_State;
			PetManager.EPetTrainDataState state2 = this.PetMgr.m_PetTrainingClinetSave[dataIdx].m_State;
			this.m_ScrollObjects[panelObjectIdx].StopAnim();
			if (state == PetManager.EPetTrainDataState.Training || state == PetManager.EPetTrainDataState.CanReceive)
			{
				if (petData != null && petId != 0)
				{
					PetExpTbl recordByKey = this.PetMgr.PetExpTable.GetRecordByKey((ushort)petData.Level);
					PetTbl recordByKey2 = this.PetMgr.PetTable.GetRecordByKey(petData.ID);
					uint needExp = this.PetMgr.GetNeedExp(petData.Level, recordByKey2.Rare);
					this.m_ScrollObjects[panelObjectIdx].SetPetHibtn(petId, petData.Enhance, petData.Rare, petData.Level);
					if (this.PetMgr.m_LevelUpStae == 1 && this.PetMgr.m_LevelUpIdx == dataIdx)
					{
						this.m_ScrollObjects[panelObjectIdx].ShowAnim = true;
					}
					else
					{
						this.m_ScrollObjects[panelObjectIdx].ShowAnim = false;
					}
					if (this.PetMgr.m_LevelUpStae == 2 && this.PetMgr.m_LevelUpIdx == dataIdx)
					{
						this.m_ScrollObjects[panelObjectIdx].ShowSkillAnim = true;
					}
					else
					{
						this.m_ScrollObjects[panelObjectIdx].ShowSkillAnim = false;
					}
					this.m_ScrollObjects[panelObjectIdx].SetAnimLvExp(petData.Level, petData.Exp, needExp);
					byte skillIdx = (byte)Mathf.Clamp(this.PetMgr.m_LevelUpSkillIdx, 0, 3);
					uint petSkillMaxExp = PetManager.Instance.GetPetSkillMaxExp(petData.ID, skillIdx);
					this.m_ScrollObjects[panelObjectIdx].SetSkillAnimLvExp(this.PetMgr.m_LevelUpLV, this.PetMgr.m_LevelOldExp, this.PetMgr.m_LevelNowExp, petSkillMaxExp, this.PetMgr.m_LevelSkillID);
					this.m_ScrollObjects[panelObjectIdx].SetHeroNum((int)this.PetMgr.m_PetTrainingData[dataIdx].CoachHeroCount);
					if (this.PetMgr.m_PetTrainingClinetSave[dataIdx].m_CancelExp > 0u)
					{
						this.m_ScrollObjects[panelObjectIdx].SetPetExp(this.PetMgr.m_PetTrainingClinetSave[dataIdx].m_CancelExp, false);
					}
					else
					{
						this.m_ScrollObjects[panelObjectIdx].SetPetExp(this.PetMgr.m_PetTrainingData[dataIdx].m_TotalExp, false);
					}
					this.m_ScrollObjects[panelObjectIdx].SetPetTime(this.PetMgr.m_PetTrainingData[dataIdx].m_EventTime.RequireTime);
					this.m_ScrollObjects[panelObjectIdx].SetTimer(this.PetMgr.m_PetTrainingData[dataIdx].m_EventTime.BeginTime, (long)((ulong)this.PetMgr.m_PetTrainingData[dataIdx].m_EventTime.RequireTime), PetManager.Instance.GetPetNameByID(petId), this);
					this.m_ScrollObjects[panelObjectIdx].SetState(state);
				}
				else
				{
					this.m_ScrollObjects[panelObjectIdx].SetEmpty(this);
					this.m_ScrollObjects[panelObjectIdx].SetState(PetManager.EPetTrainDataState.Empty);
				}
			}
			else if (state != PetManager.EPetTrainDataState.NextOpen && (state == PetManager.EPetTrainDataState.Received || state2 == PetManager.EPetTrainDataState.Received))
			{
				petId = this.PetMgr.m_PetTrainingClinetSave[dataIdx].m_PetTrainingSet.m_PetId;
				petData = this.PetMgr.FindPetData(petId);
				if (petId != 0 && petData != null)
				{
					PetExpTbl recordByKey3 = this.PetMgr.PetExpTable.GetRecordByKey((ushort)petData.Level);
					PetTbl recordByKey4 = this.PetMgr.PetTable.GetRecordByKey(petData.ID);
					uint needExp2 = this.PetMgr.GetNeedExp(petData.Level, recordByKey4.Rare);
					this.m_ScrollObjects[panelObjectIdx].SetPetHibtn(petId, petData.Enhance, petData.Rare, petData.Level);
					if (this.PetMgr.m_LevelUpStae == 1 && this.PetMgr.m_LevelUpIdx == dataIdx)
					{
						this.m_ScrollObjects[panelObjectIdx].ShowAnim = true;
					}
					else
					{
						this.m_ScrollObjects[panelObjectIdx].ShowAnim = false;
					}
					if (this.PetMgr.m_LevelUpStae == 2 && this.PetMgr.m_LevelUpIdx == dataIdx)
					{
						this.m_ScrollObjects[panelObjectIdx].ShowSkillAnim = true;
					}
					else
					{
						this.m_ScrollObjects[panelObjectIdx].ShowSkillAnim = false;
					}
					this.m_ScrollObjects[panelObjectIdx].SetAnimLvExp(petData.Level, petData.Exp, needExp2);
					byte skillIdx2 = (byte)Mathf.Clamp(this.PetMgr.m_LevelUpSkillIdx, 0, 3);
					uint petSkillMaxExp2 = PetManager.Instance.GetPetSkillMaxExp(petData.ID, skillIdx2);
					if (petData.ID == 51)
					{
						Debug.Log(string.Empty);
					}
					this.m_ScrollObjects[panelObjectIdx].SetSkillAnimLvExp(this.PetMgr.m_LevelUpLV, this.PetMgr.m_LevelOldExp, this.PetMgr.m_LevelNowExp, petSkillMaxExp2, this.PetMgr.m_LevelSkillID);
					this.m_ScrollObjects[panelObjectIdx].SetHeroNum((int)this.PetMgr.m_PetTrainingClinetSave[dataIdx].CoachHeroCount);
					this.m_ScrollObjects[panelObjectIdx].SetPetExp(this.PetMgr.m_PetTrainingClinetSave[dataIdx].m_TotalExp, false);
					this.m_ScrollObjects[panelObjectIdx].SetPetTime(this.PetMgr.m_PetTrainingClinetSave[dataIdx].m_EventTime.RequireTime);
					this.m_ScrollObjects[panelObjectIdx].SetState(PetManager.EPetTrainDataState.Received);
				}
				else
				{
					this.m_ScrollObjects[panelObjectIdx].SetEmpty(this);
					this.m_ScrollObjects[panelObjectIdx].SetState(PetManager.EPetTrainDataState.Empty);
				}
			}
			else if (state == PetManager.EPetTrainDataState.Empty)
			{
				this.m_ScrollObjects[panelObjectIdx].SetEmpty(this);
				this.m_ScrollObjects[panelObjectIdx].SetState(state);
			}
			else
			{
				this.m_ScrollObjects[panelObjectIdx].SetState(state);
			}
			this.m_ScrollObjects[panelObjectIdx].SetCancelBtnID(dataIdx, panelObjectIdx);
			this.m_ScrollObjects[panelObjectIdx].SetTrainBtnID(dataIdx, panelObjectIdx);
			this.m_ScrollObjects[panelObjectIdx].SetReceiveBtnID(dataIdx, panelObjectIdx);
			this.m_ScrollObjects[panelObjectIdx].SetPetBtnID((int)petId);
		}
	}

	// Token: 0x060017DC RID: 6108 RVA: 0x00288E90 File Offset: 0x00287090
	private void SetType(UIPetTrainingCenter.EUIPage page)
	{
		this.m_UIType = page;
		if (this.m_UIType == UIPetTrainingCenter.EUIPage.eFirst)
		{
			if (this.m_ScrollPanel)
			{
				this.m_ScrollPanel.gameObject.SetActive(true);
			}
			if (this.m_BgPenel)
			{
				this.m_BgPenel.gameObject.SetActive(true);
			}
		}
		else
		{
			if (this.m_ScrollPanel)
			{
				this.m_ScrollPanel.gameObject.SetActive(false);
			}
			if (this.m_BgPenel)
			{
				this.m_BgPenel.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x060017DD RID: 6109 RVA: 0x00288F38 File Offset: 0x00287138
	private void ShowDialog(UIPetTrainingCenter.EDialogState state, int panelObjectIdx)
	{
		if (state != UIPetTrainingCenter.EDialogState.CancelTrain)
		{
			if (state == UIPetTrainingCenter.EDialogState.OverExp)
			{
				GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(685u), DataManager.Instance.mStringTable.GetStringByID(17141u), (int)state, panelObjectIdx, DataManager.Instance.mStringTable.GetStringByID(1520u), DataManager.Instance.mStringTable.GetStringByID(4u));
			}
		}
		else
		{
			GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(17091u), DataManager.Instance.mStringTable.GetStringByID(17092u), (int)state, panelObjectIdx, null, null);
		}
	}

	// Token: 0x060017DE RID: 6110 RVA: 0x00288FF4 File Offset: 0x002871F4
	private void DialogOnOK(UIPetTrainingCenter.EDialogState state, byte panelObjectIdx)
	{
		if (state != UIPetTrainingCenter.EDialogState.CancelTrain)
		{
			if (state == UIPetTrainingCenter.EDialogState.OverExp)
			{
				if (panelObjectIdx >= 0 && (int)panelObjectIdx < this.m_ScrollObjects.Length)
				{
					this.m_ScrollObjects[(int)panelObjectIdx].OnReceive();
				}
			}
		}
		else if (panelObjectIdx >= 0 && (int)panelObjectIdx < this.m_ScrollObjects.Length)
		{
			this.m_ScrollObjects[(int)panelObjectIdx].OnCancel();
		}
	}

	// Token: 0x060017DF RID: 6111 RVA: 0x0028906C File Offset: 0x0028726C
	public static void GetTimeInfoString(CString CStr, uint sec, bool needPlus = false)
	{
		uint num = sec;
		StringTable mStringTable = DataManager.Instance.mStringTable;
		if (needPlus)
		{
			CStr.Append("+");
		}
		if (num > 86400u)
		{
			CStr.IntToFormat((long)(num / 86400u), 1, false);
			CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17131u));
			num %= 86400u;
			if (num >= 3600u)
			{
				CStr.Append(" ");
				CStr.IntToFormat((long)(num / 3600u), 1, false);
				CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17132u));
				num %= 3600u;
			}
			if (num >= 60u)
			{
				CStr.Append(" ");
				CStr.IntToFormat((long)(num / 60u), 1, false);
				CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17133u));
			}
		}
		else
		{
			if (num >= 3600u)
			{
				CStr.IntToFormat((long)(num / 3600u), 1, false);
				CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17132u));
				num %= 3600u;
			}
			if (num >= 60u)
			{
				CStr.IntToFormat((long)(num / 60u), 1, false);
				CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17133u));
			}
		}
	}

	// Token: 0x060017E0 RID: 6112 RVA: 0x002891CC File Offset: 0x002873CC
	private void SetCenterText(Image image, UIText text, float width)
	{
		float num = 10f;
		float num2 = Mathf.Clamp(text.preferredWidth, 0f, 500f);
		float x = (width - (image.rectTransform.sizeDelta.x + num2 + num)) / 2f;
		image.rectTransform.anchoredPosition = new Vector2(x, image.rectTransform.anchoredPosition.y);
		text.rectTransform.anchoredPosition = new Vector2(image.rectTransform.anchoredPosition.x + image.rectTransform.sizeDelta.x + num, text.rectTransform.anchoredPosition.y);
	}

	// Token: 0x060017E1 RID: 6113 RVA: 0x0028928C File Offset: 0x0028748C
	private void SpawnString()
	{
		if (this.m_CStr == null)
		{
			this.m_CStr = new CString[2];
		}
		for (int i = 0; i < this.m_CStr.Length; i++)
		{
			this.m_CStr[i] = StringManager.Instance.SpawnString(30);
		}
	}

	// Token: 0x060017E2 RID: 6114 RVA: 0x002892E0 File Offset: 0x002874E0
	private void DeSpawnString()
	{
		for (int i = 0; i < this.m_CStr.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.m_CStr[i]);
			this.m_CStr[i] = null;
		}
	}

	// Token: 0x060017E3 RID: 6115 RVA: 0x00289324 File Offset: 0x00287524
	private void RefreshFontTexture()
	{
		for (int i = 0; i < this.m_ScrollObjects.Length; i++)
		{
			if (this.m_ScrollObjects[i].m_Timer != null)
			{
				this.m_ScrollObjects[i].m_Timer.RefreshFontTexture();
			}
		}
		if (this.m_BuildingWindow != null)
		{
			this.m_BuildingWindow.Refresh_FontTexture();
		}
		if (this.m_TrainCountText != null)
		{
			for (int j = 0; j < this.m_TrainCountText.Length; j++)
			{
				if (this.m_TrainCountText[j] != null && this.m_TrainCountText[j].enabled)
				{
					this.m_TrainCountText[j].enabled = false;
					this.m_TrainCountText[j].enabled = true;
				}
			}
		}
		if (this.m_AdditionExpText != null)
		{
			for (int k = 0; k < this.m_AdditionExpText.Length; k++)
			{
				if (this.m_AdditionExpText[k] != null && this.m_AdditionExpText[k].enabled)
				{
					this.m_AdditionExpText[k].enabled = false;
					this.m_AdditionExpText[k].enabled = true;
				}
			}
		}
	}

	// Token: 0x0400468C RID: 18060
	private const byte BUILD_ID = 23;

	// Token: 0x0400468D RID: 18061
	private const int PANEL_OBJECT_COUNT = 6;

	// Token: 0x0400468E RID: 18062
	private BuildingWindow m_BuildingWindow;

	// Token: 0x0400468F RID: 18063
	private ushort m_ManorID;

	// Token: 0x04004690 RID: 18064
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04004691 RID: 18065
	private Transform m_BgPenel;

	// Token: 0x04004692 RID: 18066
	private UIPetTrainingCenter.SSrollPanelItem[] m_ScrollObjects;

	// Token: 0x04004693 RID: 18067
	private UIText[] m_AdditionExpText;

	// Token: 0x04004694 RID: 18068
	private UIText[] m_TrainCountText;

	// Token: 0x04004695 RID: 18069
	private bool bInitScroll;

	// Token: 0x04004696 RID: 18070
	private UIPetTrainingCenter.EUIPage m_UIType;

	// Token: 0x04004697 RID: 18071
	private PetManager PetMgr;

	// Token: 0x04004698 RID: 18072
	private CString[] m_CStr;

	// Token: 0x04004699 RID: 18073
	private UISpritesArray m_Sp;

	// Token: 0x02000493 RID: 1171
	private enum EUIPetTrainingCenter
	{
		// Token: 0x0400469B RID: 18075
		ScrollPanel,
		// Token: 0x0400469C RID: 18076
		Item,
		// Token: 0x0400469D RID: 18077
		BgPanel
	}

	// Token: 0x02000494 RID: 1172
	private enum ECStrID
	{
		// Token: 0x0400469F RID: 18079
		UpdateAdditionExp,
		// Token: 0x040046A0 RID: 18080
		UpdateTrainPetCount,
		// Token: 0x040046A1 RID: 18081
		Max
	}

	// Token: 0x02000495 RID: 1173
	private enum EBtnID
	{
		// Token: 0x040046A3 RID: 18083
		Cancel,
		// Token: 0x040046A4 RID: 18084
		Train,
		// Token: 0x040046A5 RID: 18085
		Receive,
		// Token: 0x040046A6 RID: 18086
		PetIcon,
		// Token: 0x040046A7 RID: 18087
		HeroCountHint,
		// Token: 0x040046A8 RID: 18088
		ExpHint,
		// Token: 0x040046A9 RID: 18089
		TimeHint,
		// Token: 0x040046AA RID: 18090
		SkillIconHint
	}

	// Token: 0x02000496 RID: 1174
	private enum EUIPage
	{
		// Token: 0x040046AC RID: 18092
		eFirst,
		// Token: 0x040046AD RID: 18093
		eSecond
	}

	// Token: 0x02000497 RID: 1175
	private enum EDialogState
	{
		// Token: 0x040046AF RID: 18095
		CancelTrain,
		// Token: 0x040046B0 RID: 18096
		OverExp,
		// Token: 0x040046B1 RID: 18097
		Max
	}

	// Token: 0x02000498 RID: 1176
	private struct SSrollPanelItem
	{
		// Token: 0x060017E4 RID: 6116 RVA: 0x0028945C File Offset: 0x0028765C
		public SSrollPanelItem(UISpritesArray sp)
		{
			this.m_Sp = sp;
			this.m_SkillTf = null;
			this.m_SkillExpTf = null;
			this.m_SkillTf = null;
			this.m_SkillExpTf = null;
			this.m_SkillLvText = null;
			this.m_SkillExpImg = null;
			this.m_SkillExpText = null;
			this.m_SkillSliderImg = null;
			this.m_SkillIcon = null;
			this.m_ItemTrams = null;
			this.m_Item2Text = null;
			this.m_ImageBg = null;
			this.m_PetHiBtn = null;
			this.m_SliderImg = null;
			this.m_LockIcon = null;
			this.m_ExpTf = null;
			this.m_LvText = null;
			this.m_ValueText = new UIText[3];
			this.m_ExpText = null;
			this.m_ReceiveEffectImg = null;
			this.m_Timer = new PetTrainingTimer();
			this.m_Animation = new LvUpAnimation();
			this.m_AnimationSkill = new LvUpAnimation();
			this.m_CStr = null;
			this.bHasInstance = false;
			this.m_ReceiveColor = Color.white;
			this.m_Lv = 0;
			this.m_ExpDeltaWidth = new float[2];
			this.m_ExpDeltaWidth[0] = 0f;
			this.m_ExpDeltaWidth[1] = 0f;
			this.m_ExpWidth = new float[2];
			this.m_ExpWidth[0] = 0f;
			this.m_ExpWidth[1] = 1f;
			this.m_Exp = 0u;
			this.bSkill = false;
			this.m_PetID = 0;
			UIPetTrainingCenter.SSrollPanelItem.m_StsticDeltaTime = 0f;
			this.m_DeltaTime = new float[4];
			this.m_DeltaTime[0] = 0f;
			this.m_DeltaTime[1] = 0f;
			this.m_DeltaTime[2] = 0f;
			this.m_DeltaTime[3] = 0f;
			this.m_AddTime = new bool[4];
			this.m_AddTime[0] = false;
			this.m_AddTime[1] = false;
			this.m_AddTime[2] = false;
			this.m_AddTime[3] = false;
			this.bShowAnim = false;
			this.bShowSkillAnim = false;
			this.m_SkillIdx = 0;
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060017E5 RID: 6117 RVA: 0x00289634 File Offset: 0x00287834
		// (set) Token: 0x060017E6 RID: 6118 RVA: 0x0028963C File Offset: 0x0028783C
		public bool ShowAnim
		{
			get
			{
				return this.bShowAnim;
			}
			set
			{
				this.bShowAnim = value;
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060017E7 RID: 6119 RVA: 0x00289648 File Offset: 0x00287848
		// (set) Token: 0x060017E8 RID: 6120 RVA: 0x00289650 File Offset: 0x00287850
		public bool ShowSkillAnim
		{
			get
			{
				return this.bShowSkillAnim;
			}
			set
			{
				this.bShowSkillAnim = value;
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060017E9 RID: 6121 RVA: 0x0028965C File Offset: 0x0028785C
		// (set) Token: 0x060017EA RID: 6122 RVA: 0x00289664 File Offset: 0x00287864
		public byte SkillIdx
		{
			get
			{
				return this.m_SkillIdx;
			}
			set
			{
				this.m_SkillIdx = value;
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060017EB RID: 6123 RVA: 0x00289670 File Offset: 0x00287870
		public bool HasInstance
		{
			get
			{
				return this.bHasInstance;
			}
		}

		// Token: 0x060017EC RID: 6124 RVA: 0x00289678 File Offset: 0x00287878
		public void SetItemTransform(Transform[] item)
		{
			this.m_ItemTrams = item;
		}

		// Token: 0x060017ED RID: 6125 RVA: 0x00289684 File Offset: 0x00287884
		public void Init(Transform[] itemTf, UIText item2Text, Image[] imageBg, UIHIBtn hiBtn, Image sliderImg, Transform expTf, UIText lvText, Image lockIcon, UIText[] valueText, UITimeBar timer, int timerID, UIButton traningBtn, UIButton receive, Image receiveEffectImg, Image expImg, UIText expText, Transform skillTf, Transform skillExpTf, UIText skillLvText, UIText skillExpText, Image skillExpImg, Image skillSliderImg, Image skillIcon)
		{
			this.m_ItemTrams = itemTf;
			this.m_Item2Text = item2Text;
			this.m_ReceiveEffectImg = receiveEffectImg;
			this.m_ReceiveColor = this.m_ReceiveEffectImg.color;
			this.m_ImageBg = imageBg;
			this.m_PetHiBtn = hiBtn;
			this.m_SliderImg = sliderImg;
			this.m_LockIcon = lockIcon;
			this.m_ExpTf = expTf;
			this.m_LvText = lvText;
			this.m_ExpText = expText;
			this.m_ValueText = valueText;
			this.m_SkillTf = skillTf;
			this.m_SkillExpTf = skillExpTf;
			this.m_SkillLvText = skillLvText;
			this.m_SkillExpText = skillExpText;
			this.m_SkillExpImg = skillExpImg;
			this.m_SkillSliderImg = skillSliderImg;
			this.m_SkillIcon = skillIcon;
			this.m_Timer.Init(timer, traningBtn, receive, timerID);
			this.m_Animation.Init(expImg, this.m_ExpText);
			this.m_AnimationSkill.Init(skillExpImg, skillExpText, skillIcon);
			this.SpawnString();
			this.bHasInstance = true;
		}

		// Token: 0x060017EE RID: 6126 RVA: 0x00289774 File Offset: 0x00287974
		public static void StaticRun()
		{
			UIPetTrainingCenter.SSrollPanelItem.m_StsticDeltaTime += Time.deltaTime;
			if (UIPetTrainingCenter.SSrollPanelItem.m_StsticDeltaTime >= 2f)
			{
				UIPetTrainingCenter.SSrollPanelItem.m_StsticDeltaTime = 0f;
			}
		}

		// Token: 0x060017EF RID: 6127 RVA: 0x002897A0 File Offset: 0x002879A0
		public void Run()
		{
			if (this.bHasInstance && this.m_Animation != null && this.m_AnimationSkill != null && this.m_Animation != null)
			{
				this.m_Animation.Run();
				this.m_AnimationSkill.Run();
			}
			if (this.m_ReceiveEffectImg != null && this.m_ReceiveEffectImg.gameObject.activeInHierarchy)
			{
				float num = Mathf.Lerp(0f, 2f, UIPetTrainingCenter.SSrollPanelItem.m_StsticDeltaTime / 2f);
				if (num > 1f)
				{
					this.m_ReceiveColor.a = 2f - num;
				}
				else
				{
					this.m_ReceiveColor.a = num;
				}
				this.m_ReceiveEffectImg.color = this.m_ReceiveColor;
			}
			if (this.m_ExpDeltaWidth[0] > 0f && this.m_ExpDeltaWidth[0] <= 45f)
			{
				float num2 = 0.5f * (this.m_ExpDeltaWidth[0] / 45f);
				this.m_DeltaTime[1] += Time.deltaTime;
				float num3 = Mathf.Lerp(0f, this.m_ExpDeltaWidth[0], this.m_DeltaTime[1] / num2);
				Vector2 sizeDelta = this.m_SliderImg.rectTransform.sizeDelta;
				sizeDelta.x = this.m_ExpWidth[0] + num3;
				this.m_SliderImg.rectTransform.sizeDelta = sizeDelta;
				if (num3 >= this.m_ExpDeltaWidth[0])
				{
					this.m_ExpDeltaWidth[0] = 0f;
				}
			}
			if (this.m_ExpDeltaWidth[1] > 0f && this.m_ExpDeltaWidth[1] <= 36f)
			{
				float num4 = 0.5f;
				this.m_DeltaTime[1] += Time.deltaTime;
				if (this.m_DeltaTime[1] >= num4)
				{
					float num5 = 0.5f * (this.m_ExpDeltaWidth[1] / 36f);
					float num6 = Mathf.Lerp(0f, this.m_ExpDeltaWidth[1], (this.m_DeltaTime[1] - num4) / num5);
					Vector2 sizeDelta2 = this.m_SkillSliderImg.rectTransform.sizeDelta;
					sizeDelta2.x = this.m_ExpWidth[1] + num6;
					this.m_SkillSliderImg.rectTransform.sizeDelta = sizeDelta2;
					if (num6 >= this.m_ExpDeltaWidth[1])
					{
						this.m_ExpDeltaWidth[1] = 0f;
					}
					Debug.Log(this.m_SkillSliderImg.rectTransform.sizeDelta.x);
				}
			}
			if (this.m_AddTime[2])
			{
				this.m_DeltaTime[2] += Time.deltaTime;
				if (this.m_DeltaTime[2] > 0f && this.m_DeltaTime[2] >= 0.5f)
				{
					this.m_SkillExpTf.gameObject.SetActive(true);
					this.m_DeltaTime[2] = 0f;
					this.m_AddTime[2] = false;
				}
			}
			if (this.m_AddTime[3])
			{
				this.m_DeltaTime[3] += Time.deltaTime;
				if (this.m_DeltaTime[3] > 0f && this.m_DeltaTime[3] >= 1.5f)
				{
					this.m_SkillExpTf.gameObject.SetActive(false);
					this.m_DeltaTime[3] = 0f;
					this.m_AddTime[3] = false;
				}
			}
		}

		// Token: 0x060017F0 RID: 6128 RVA: 0x00289B00 File Offset: 0x00287D00
		public void SetCancelBtnID(int dataIdx, int panelObjectIdx)
		{
			this.m_Timer.SetCancelBtnID(dataIdx, panelObjectIdx);
		}

		// Token: 0x060017F1 RID: 6129 RVA: 0x00289B10 File Offset: 0x00287D10
		public void SetTrainBtnID(int dataIdx, int panelObjectIdx)
		{
			this.m_Timer.SetTrainBtnID(dataIdx, panelObjectIdx);
		}

		// Token: 0x060017F2 RID: 6130 RVA: 0x00289B20 File Offset: 0x00287D20
		public void SetReceiveBtnID(int dataIdx, int panelObjectIdx)
		{
			this.m_Timer.SetReceiveBtnID(dataIdx, panelObjectIdx);
		}

		// Token: 0x060017F3 RID: 6131 RVA: 0x00289B30 File Offset: 0x00287D30
		public void SetPetBtnID(int petID)
		{
			this.m_PetHiBtn.m_BtnID2 = petID;
		}

		// Token: 0x060017F4 RID: 6132 RVA: 0x00289B40 File Offset: 0x00287D40
		public void SetPetHibtn(ushort petID, byte Enhance, byte Rare, byte level)
		{
			GUIManager.Instance.ChangeHeroItemImg(this.m_PetHiBtn.transform, eHeroOrItem.Pet, petID, Enhance, 0, 0);
			this.m_PetID = petID;
			this.SetSkillIcon(this.m_PetID, 0);
		}

		// Token: 0x060017F5 RID: 6133 RVA: 0x00289B7C File Offset: 0x00287D7C
		public void SetAnimLvExp(byte lv, uint exp, uint max)
		{
			float num = 45f;
			float num2 = 0f;
			Vector2 sizeDelta = this.m_SliderImg.rectTransform.sizeDelta;
			this.m_ExpWidth[0] = sizeDelta.x;
			this.m_Lv = lv;
			if (this.m_ExpTf != null)
			{
				this.m_ExpTf.gameObject.SetActive(this.m_Lv != 0);
			}
			if (max != 0u)
			{
				float num3 = Mathf.Clamp(exp / max, 0f, 1f);
				num2 = num * num3;
			}
			if (this.m_Animation != null)
			{
				this.m_AnimationSkill.End();
				uint num4 = exp - this.m_Exp;
				if (num4 > 0u && this.ShowAnim)
				{
					if (this.m_Lv == lv)
					{
						this.m_ExpDeltaWidth[0] = num2 - this.m_ExpWidth[0];
					}
					this.m_Animation.Start(this.m_CStr[5], num4, 0);
					this.m_DeltaTime[1] = 0f;
					this.ShowAnim = false;
				}
				else
				{
					sizeDelta.x = num2;
					this.m_SliderImg.rectTransform.sizeDelta = sizeDelta;
				}
				this.m_Exp = exp;
			}
			this.m_LockIcon.gameObject.SetActive(false);
			PetData petData = PetManager.Instance.FindPetData(this.m_PetID);
			if (petData != null)
			{
				byte maxLevel = petData.GetMaxLevel(true);
				if (petData.Level == maxLevel && exp >= max - 1u)
				{
					this.m_LockIcon.gameObject.SetActive(true);
				}
			}
			this.m_CStr[3].ClearString();
			this.m_CStr[3].IntToFormat((long)lv, 1, false);
			this.m_CStr[3].AppendFormat("{0}");
			this.m_LvText.text = this.m_CStr[3].ToString();
			this.m_LvText.SetAllDirty();
			this.m_LvText.cachedTextGenerator.Invalidate();
			if (lv < 60)
			{
				this.m_SliderImg.sprite = this.m_Sp.GetSprite(0);
			}
			else
			{
				sizeDelta.x = num;
				this.m_SliderImg.rectTransform.sizeDelta = sizeDelta;
				this.m_SliderImg.sprite = this.m_Sp.GetSprite(1);
			}
		}

		// Token: 0x060017F6 RID: 6134 RVA: 0x00289DC4 File Offset: 0x00287FC4
		public void SetSkillAnimLvExp(byte lv = 1, uint oldexp = 1u, uint nowExp = 1u, uint max = 1u, ushort skillID = 0)
		{
			float num = 36f;
			float num2 = 0f;
			Vector2 sizeDelta = this.m_SkillSliderImg.rectTransform.sizeDelta;
			this.m_ExpWidth[1] = num * oldexp / max;
			this.m_Lv = lv;
			if (this.m_ExpTf != null)
			{
				this.m_ExpTf.gameObject.SetActive(this.m_Lv != 0);
			}
			if (max != 0u)
			{
				float num3 = Mathf.Clamp(nowExp / max, 0f, 1f);
				num2 = num * num3;
			}
			if (this.m_AnimationSkill != null)
			{
				this.m_AnimationSkill.End();
				uint num4 = nowExp - oldexp;
				if (num4 > 0u && this.bShowSkillAnim)
				{
					if (this.m_Lv == lv)
					{
						this.m_ExpDeltaWidth[1] = num2 - this.m_ExpWidth[1];
					}
					this.m_AnimationSkill.Start(this.m_CStr[5], num4, skillID);
					this.m_DeltaTime[1] = 0f;
					this.m_DeltaTime[2] = 0f;
					this.m_DeltaTime[3] = 0f;
					this.m_AddTime[2] = true;
					this.m_AddTime[3] = true;
					this.m_SkillExpTf.gameObject.SetActive(false);
					this.bShowSkillAnim = false;
				}
				else
				{
					sizeDelta.x = num2;
					this.m_SkillSliderImg.rectTransform.sizeDelta = sizeDelta;
					this.m_SkillExpTf.gameObject.SetActive(false);
				}
			}
			this.m_CStr[4].ClearString();
			this.m_CStr[4].IntToFormat((long)lv, 1, false);
			this.m_CStr[4].AppendFormat("{0}");
			this.m_SkillLvText.text = this.m_CStr[4].ToString();
			this.m_SkillLvText.SetAllDirty();
			this.m_SkillLvText.cachedTextGenerator.Invalidate();
		}

		// Token: 0x060017F7 RID: 6135 RVA: 0x00289FA4 File Offset: 0x002881A4
		public void SetHeroNum(int num)
		{
			this.m_CStr[0].ClearString();
			if (num <= 0)
			{
				this.m_CStr[0].Append(DataManager.Instance.mStringTable.GetStringByID(17135u));
			}
			else
			{
				this.m_CStr[0].IntToFormat((long)num, 1, false);
				this.m_CStr[0].AppendFormat("{0}");
			}
			this.m_ValueText[0].text = this.m_CStr[0].ToString();
			this.m_ValueText[0].SetAllDirty();
			this.m_ValueText[0].cachedTextGenerator.Invalidate();
		}

		// Token: 0x060017F8 RID: 6136 RVA: 0x0028A048 File Offset: 0x00288248
		public void SetPetExp(uint exp, bool bMaxLv = false)
		{
			this.m_CStr[1].ClearString();
			if (exp <= 0u)
			{
				this.m_CStr[1].Append(DataManager.Instance.mStringTable.GetStringByID(17135u));
			}
			else
			{
				this.m_CStr[1].IntToFormat((long)((ulong)exp), 1, true);
				this.m_CStr[1].AppendFormat("{0}");
			}
			this.m_ValueText[1].text = this.m_CStr[1].ToString();
			this.m_ValueText[1].SetAllDirty();
			this.m_ValueText[1].cachedTextGenerator.Invalidate();
		}

		// Token: 0x060017F9 RID: 6137 RVA: 0x0028A0EC File Offset: 0x002882EC
		public void SetSkillIcon(ushort petID, ushort skillID)
		{
			bool active = PetManager.Instance.IsMaxLevelExp(petID);
			if (this.m_SkillIcon.sprite == null)
			{
				this.m_SkillIcon.sprite = PetManager.Instance.LoadPetSkillIcon(skillID);
				this.m_SkillIcon.material = GUIManager.Instance.m_ItemIconSpriteAsset.GetMaterial();
				Image component = this.m_SkillIcon.transform.GetChild(0).GetComponent<Image>();
				if (component != null)
				{
					component.sprite = GUIManager.Instance.LoadFrameSprite("sk");
					component.material = GUIManager.Instance.GetFrameMaterial();
				}
			}
			this.m_SkillTf.gameObject.SetActive(active);
		}

		// Token: 0x060017FA RID: 6138 RVA: 0x0028A1A4 File Offset: 0x002883A4
		public void SetPetTime(uint time)
		{
			this.m_CStr[2].ClearString();
			if (time <= 0u)
			{
				this.m_CStr[2].Append(DataManager.Instance.mStringTable.GetStringByID(17135u));
			}
			else
			{
				UIPetTrainingCenter.GetTimeInfoString(this.m_CStr[2], time, false);
			}
			this.m_ValueText[2].text = this.m_CStr[2].ToString();
			this.m_ValueText[2].SetAllDirty();
			this.m_ValueText[2].cachedTextGenerator.Invalidate();
		}

		// Token: 0x060017FB RID: 6139 RVA: 0x0028A234 File Offset: 0x00288434
		public void SetEmpty(IUTimeBarOnTimer hander)
		{
			this.SetPetHibtn(0, 0, 0, 0);
			this.SetHeroNum(0);
			this.SetPetExp(0u, false);
			this.SetPetTime(0u);
			this.m_Timer.SetTimer(0L, 0L, string.Empty, hander);
			if (this.m_ExpTf != null)
			{
				this.m_ExpTf.gameObject.SetActive(false);
			}
			if (this.m_LockIcon != null)
			{
				this.m_LockIcon.gameObject.SetActive(false);
			}
			this.m_Timer.SetState(PetManager.EPetTrainDataState.Empty);
		}

		// Token: 0x060017FC RID: 6140 RVA: 0x0028A2C8 File Offset: 0x002884C8
		public void SetTimer(long begin, long require, string petName, IUTimeBarOnTimer hander)
		{
			this.m_Timer.SetTimer(begin, require, petName, hander);
		}

		// Token: 0x060017FD RID: 6141 RVA: 0x0028A2DC File Offset: 0x002884DC
		public void SetState(PetManager.EPetTrainDataState state)
		{
			if (this.bHasInstance)
			{
				if (state == PetManager.EPetTrainDataState.NextOpen)
				{
					this.m_ItemTrams[0].gameObject.SetActive(false);
					this.m_ItemTrams[1].gameObject.SetActive(true);
				}
				else
				{
					this.m_ItemTrams[0].gameObject.SetActive(true);
					this.m_ItemTrams[1].gameObject.SetActive(false);
					if (state == PetManager.EPetTrainDataState.Training || state == PetManager.EPetTrainDataState.CanReceive)
					{
						if (this.m_ImageBg[0] != null && this.m_ImageBg[1] != null)
						{
							this.m_ImageBg[0].enabled = true;
							this.m_ImageBg[1].enabled = false;
						}
					}
					else if (this.m_ImageBg[0] != null && this.m_ImageBg[1] != null)
					{
						this.m_ImageBg[0].enabled = false;
						this.m_ImageBg[1].enabled = true;
					}
					this.m_Timer.SetState(state);
					this.SetIconTextColor(state);
					this.SetReceived(state);
				}
			}
		}

		// Token: 0x060017FE RID: 6142 RVA: 0x0028A400 File Offset: 0x00288600
		private void SetIconTextColor(PetManager.EPetTrainDataState state)
		{
			if (this.bHasInstance)
			{
				switch (state)
				{
				case PetManager.EPetTrainDataState.Empty:
				case PetManager.EPetTrainDataState.Received:
				{
					Image component = this.m_ValueText[0].transform.parent.GetComponent<Image>();
					component.color = new Color(0.5f, 0.5f, 0.5f, 1f);
					this.m_ValueText[0].color = new Color(0.5f, 0.5f, 0.5f, 1f);
					component = this.m_ValueText[1].transform.parent.GetComponent<Image>();
					component.color = new Color(0.5f, 0.5f, 0.5f, 1f);
					this.m_ValueText[1].color = new Color(0.14f, 0.48f, 0.48f, 1f);
					component = this.m_ValueText[2].transform.parent.GetComponent<Image>();
					component.color = new Color(0.5f, 0.5f, 0.5f, 1f);
					this.m_ValueText[2].color = new Color(0.5f, 0.5f, 0.5f, 1f);
					if (state == PetManager.EPetTrainDataState.Received)
					{
						this.m_ImageBg[2].enabled = true;
					}
					else
					{
						this.m_ImageBg[2].enabled = false;
					}
					break;
				}
				case PetManager.EPetTrainDataState.Training:
				case PetManager.EPetTrainDataState.CanReceive:
				{
					Image component = this.m_ValueText[0].transform.parent.GetComponent<Image>();
					component.color = new Color(1f, 1f, 1f, 1f);
					this.m_ValueText[0].color = new Color(1f, 1f, 1f, 1f);
					component = this.m_ValueText[1].transform.parent.GetComponent<Image>();
					component.color = new Color(1f, 1f, 1f, 1f);
					this.m_ValueText[1].color = new Color(0.28f, 0.96f, 0.96f, 1f);
					component = this.m_ValueText[2].transform.parent.GetComponent<Image>();
					component.color = new Color(1f, 1f, 1f, 1f);
					this.m_ValueText[2].color = new Color(1f, 1f, 1f, 1f);
					this.m_ImageBg[2].enabled = false;
					break;
				}
				}
			}
		}

		// Token: 0x060017FF RID: 6143 RVA: 0x0028A6A4 File Offset: 0x002888A4
		public void SetReceived(PetManager.EPetTrainDataState state)
		{
			Image component = this.m_ValueText[2].transform.parent.GetComponent<Image>();
			RectTransform component2 = this.m_ValueText[1].transform.parent.GetComponent<RectTransform>();
			if (state == PetManager.EPetTrainDataState.Received || state == PetManager.EPetTrainDataState.Empty)
			{
				component2.anchoredPosition = new Vector2(366f, -27f);
				component.gameObject.SetActive(true);
			}
			else
			{
				component2.anchoredPosition = new Vector2(366f, -45f);
				component.gameObject.SetActive(false);
			}
		}

		// Token: 0x06001800 RID: 6144 RVA: 0x0028A738 File Offset: 0x00288938
		public ushort GetPetID()
		{
			return (ushort)this.m_PetHiBtn.m_BtnID2;
		}

		// Token: 0x06001801 RID: 6145 RVA: 0x0028A748 File Offset: 0x00288948
		public void StopAnim()
		{
			this.m_AnimationSkill.End();
			this.m_Animation.End();
			this.m_ExpDeltaWidth[0] = 0f;
			this.m_ExpDeltaWidth[1] = 0f;
			this.m_AddTime[2] = false;
			this.m_AddTime[3] = false;
		}

		// Token: 0x06001802 RID: 6146 RVA: 0x0028A798 File Offset: 0x00288998
		public void OnTimer()
		{
		}

		// Token: 0x06001803 RID: 6147 RVA: 0x0028A79C File Offset: 0x0028899C
		public void onFinish()
		{
			if (this.m_Timer != null)
			{
				this.m_Timer.onFinish();
			}
		}

		// Token: 0x06001804 RID: 6148 RVA: 0x0028A7B4 File Offset: 0x002889B4
		public void OnClose()
		{
			if (this.m_Timer != null)
			{
				this.m_Timer.OnClose();
			}
			this.DeSpawnString();
		}

		// Token: 0x06001805 RID: 6149 RVA: 0x0028A7D4 File Offset: 0x002889D4
		public void OnTrain(byte dataIdx)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door)
			{
				door.OpenMenu(EGUIWindow.UI_PetSelect, (int)dataIdx, 0, true);
			}
		}

		// Token: 0x06001806 RID: 6150 RVA: 0x0028A80C File Offset: 0x00288A0C
		public void OnReceive()
		{
			if (this.m_PetID != 0)
			{
				PetManager.Instance.RequestPetTrainingComplete(this.m_PetID);
			}
		}

		// Token: 0x06001807 RID: 6151 RVA: 0x0028A82C File Offset: 0x00288A2C
		public void OnCancel()
		{
			PetManager.Instance.RequestPetTrainingCancel(this.m_PetID);
		}

		// Token: 0x06001808 RID: 6152 RVA: 0x0028A840 File Offset: 0x00288A40
		private void SpawnString()
		{
			if (this.m_CStr == null)
			{
				this.m_CStr = new CString[6];
			}
			for (int i = 0; i < this.m_CStr.Length; i++)
			{
				this.m_CStr[i] = StringManager.Instance.SpawnString(30);
			}
		}

		// Token: 0x06001809 RID: 6153 RVA: 0x0028A894 File Offset: 0x00288A94
		private void DeSpawnString()
		{
			for (int i = 0; i < this.m_CStr.Length; i++)
			{
				StringManager.Instance.DeSpawnString(this.m_CStr[i]);
				this.m_CStr[i] = null;
			}
		}

		// Token: 0x0600180A RID: 6154 RVA: 0x0028A8D8 File Offset: 0x00288AD8
		public void RefreshFontTexture()
		{
			if (this.m_PetHiBtn != null)
			{
				this.m_PetHiBtn.Refresh_FontTexture();
			}
			if (this.m_Timer != null)
			{
				this.m_Timer.RefreshFontTexture();
			}
			if (this.m_ValueText != null)
			{
				for (int i = 0; i < this.m_ValueText.Length; i++)
				{
					if (this.m_ValueText[i] != null && this.m_ValueText[i].enabled)
					{
						this.m_ValueText[i].enabled = false;
						this.m_ValueText[i].enabled = true;
					}
				}
			}
			if (this.m_LvText != null && this.m_LvText.enabled)
			{
				this.m_LvText.enabled = false;
				this.m_LvText.enabled = true;
			}
			if (this.m_ExpText != null && this.m_ExpText.enabled)
			{
				this.m_ExpText.enabled = false;
				this.m_ExpText.enabled = true;
			}
			if (this.m_Item2Text != null && this.m_Item2Text.enabled)
			{
				this.m_Item2Text.enabled = false;
				this.m_Item2Text.enabled = true;
			}
		}

		// Token: 0x040046B2 RID: 18098
		private Transform[] m_ItemTrams;

		// Token: 0x040046B3 RID: 18099
		private UIText m_Item2Text;

		// Token: 0x040046B4 RID: 18100
		private Transform m_ExpTf;

		// Token: 0x040046B5 RID: 18101
		private Image[] m_ImageBg;

		// Token: 0x040046B6 RID: 18102
		private UIHIBtn m_PetHiBtn;

		// Token: 0x040046B7 RID: 18103
		private Image m_SliderImg;

		// Token: 0x040046B8 RID: 18104
		private UIText m_LvText;

		// Token: 0x040046B9 RID: 18105
		private UIText m_ExpText;

		// Token: 0x040046BA RID: 18106
		private Image m_LockIcon;

		// Token: 0x040046BB RID: 18107
		private UIText[] m_ValueText;

		// Token: 0x040046BC RID: 18108
		private Image m_ReceiveEffectImg;

		// Token: 0x040046BD RID: 18109
		public Transform m_SkillTf;

		// Token: 0x040046BE RID: 18110
		public Transform m_SkillExpTf;

		// Token: 0x040046BF RID: 18111
		private UIText m_SkillLvText;

		// Token: 0x040046C0 RID: 18112
		private UIText m_SkillExpText;

		// Token: 0x040046C1 RID: 18113
		private Image m_SkillSliderImg;

		// Token: 0x040046C2 RID: 18114
		private Image m_SkillExpImg;

		// Token: 0x040046C3 RID: 18115
		private Image m_SkillIcon;

		// Token: 0x040046C4 RID: 18116
		private UISpritesArray m_Sp;

		// Token: 0x040046C5 RID: 18117
		private Color m_ReceiveColor;

		// Token: 0x040046C6 RID: 18118
		private byte m_Lv;

		// Token: 0x040046C7 RID: 18119
		private float[] m_ExpWidth;

		// Token: 0x040046C8 RID: 18120
		private float[] m_ExpDeltaWidth;

		// Token: 0x040046C9 RID: 18121
		public uint m_Exp;

		// Token: 0x040046CA RID: 18122
		private bool bSkill;

		// Token: 0x040046CB RID: 18123
		public PetTrainingTimer m_Timer;

		// Token: 0x040046CC RID: 18124
		public LvUpAnimation m_Animation;

		// Token: 0x040046CD RID: 18125
		public LvUpAnimation m_AnimationSkill;

		// Token: 0x040046CE RID: 18126
		private CString[] m_CStr;

		// Token: 0x040046CF RID: 18127
		private ushort m_PetID;

		// Token: 0x040046D0 RID: 18128
		private static float m_StsticDeltaTime;

		// Token: 0x040046D1 RID: 18129
		private float[] m_DeltaTime;

		// Token: 0x040046D2 RID: 18130
		private bool[] m_AddTime;

		// Token: 0x040046D3 RID: 18131
		private bool bShowAnim;

		// Token: 0x040046D4 RID: 18132
		private bool bShowSkillAnim;

		// Token: 0x040046D5 RID: 18133
		private bool bHasInstance;

		// Token: 0x040046D6 RID: 18134
		private byte m_SkillIdx;

		// Token: 0x02000499 RID: 1177
		private enum ECStrID
		{
			// Token: 0x040046D8 RID: 18136
			HeroCount,
			// Token: 0x040046D9 RID: 18137
			PetExp,
			// Token: 0x040046DA RID: 18138
			PetTime,
			// Token: 0x040046DB RID: 18139
			LVText,
			// Token: 0x040046DC RID: 18140
			SkillLVText,
			// Token: 0x040046DD RID: 18141
			ExpText,
			// Token: 0x040046DE RID: 18142
			Max
		}
	}
}
