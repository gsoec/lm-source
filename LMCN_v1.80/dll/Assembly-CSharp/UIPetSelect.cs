using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200047C RID: 1148
public class UIPetSelect : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x0600173A RID: 5946 RVA: 0x0027EB5C File Offset: 0x0027CD5C
	public override void OnOpen(int arg1, int arg2)
	{
		this.PetMgr = PetManager.Instance;
		this.DM = DataManager.Instance;
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.SCROLL_DATA_COUNT = this.PetMgr.PetTable.TableCount / 2 + 10;
		this.m_TrainingSetIdx = (byte)arg1;
		this.m_CoachHeroId = new List<ushort>();
		this.m_CoachHeroTime = 0u;
		this.m_ColorCount = new byte[5];
		this.bShowSelectEffect = false;
		this.m_SelectEffectAlpha = 0f;
		this.m_SelectTime = 0f;
		this.m_RanSelectTime = new float[6];
		this.m_RanSelectAlpha = new float[6];
		this.SpawnCStr();
		this.PetIdelCount = this.PetMgr.SortPetIdle();
		DataManager.SortHeroData();
		this.m_PetScrollData = new List<UIPetSelect.SScrollData>();
		this.m_HeroScrollData = new List<UIPetSelect.SScrollData>();
		this.m_ScrollIdx = new int[2];
		this.m_ScrollPosY = new float[2];
		this.SetPetData((int)this.m_TrainingSetIdx);
		this.SetHeroData((int)this.m_TrainingSetIdx);
		this.Init();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
	}

	// Token: 0x0600173B RID: 5947 RVA: 0x0027EC80 File Offset: 0x0027CE80
	public override void OnClose()
	{
		this.DeSpawnCStr();
		this.DeSpawnPetData();
		this.DeSpawnHeroData();
	}

	// Token: 0x0600173C RID: 5948 RVA: 0x0027EC94 File Offset: 0x0027CE94
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 0)
		{
			if (this.door)
			{
				this.door.CloseMenu(false);
			}
		}
	}

	// Token: 0x0600173D RID: 5949 RVA: 0x0027ECD0 File Offset: 0x0027CED0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Hero)
			{
				if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
				{
					if (networkNews == NetworkNews.Refresh_Pet)
					{
						this.PetIdelCount = this.PetMgr.SortPetIdle();
						this.DeSpawnPetData();
						this.SetPetData(-1);
						this.SetType(this.m_UIType);
						this.UpdateScrollPanel(false, false);
					}
				}
				else
				{
					this.RefreshFontTexture();
				}
			}
			else
			{
				DataManager.SortHeroData();
				this.DeSpawnHeroData();
				this.SetHeroData(-1);
				this.SetType(this.m_UIType);
				this.UpdateScrollPanel(false, false);
			}
		}
		else if (this.m_TrainingSetIdx >= 0 && (int)this.m_TrainingSetIdx < this.PetMgr.m_PetTrainingData.Length)
		{
			if (this.PetMgr.m_PetTrainingData[(int)this.m_TrainingSetIdx].m_State == PetManager.EPetTrainDataState.Training || this.PetMgr.m_PetTrainingData[(int)this.m_TrainingSetIdx].m_State == PetManager.EPetTrainDataState.CanReceive || this.PetMgr.m_PetTrainingData[(int)this.m_TrainingSetIdx].m_State == PetManager.EPetTrainDataState.Closed)
			{
				if (this.door != null)
				{
					this.door.CloseMenu(false);
				}
			}
			else
			{
				this.PetIdelCount = this.PetMgr.SortPetIdle();
				DataManager.SortHeroData();
				this.DeSpawnHeroData();
				this.DeSpawnPetData();
				this.SetHeroData(-1);
				this.SetPetData(-1);
				this.SetType(this.m_UIType);
				this.UpdateScrollPanel(false, false);
			}
		}
	}

	// Token: 0x0600173E RID: 5950 RVA: 0x0027EE64 File Offset: 0x0027D064
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		ushort id = this.m_PetSelect.m_ID;
		if (bOK)
		{
			switch (arg1)
			{
			case 0:
			case 1:
				this.PetMgr.RequestPetTrainingBegin(this.m_TrainingSetIdx, id, this.m_CoachHeroId);
				break;
			case 2:
				this.PetMgr.OpenPetEvoPanel(arg2, true);
				break;
			}
		}
	}

	// Token: 0x0600173F RID: 5951 RVA: 0x0027EECC File Offset: 0x0027D0CC
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x06001740 RID: 5952 RVA: 0x0027EED0 File Offset: 0x0027D0D0
	private void Update()
	{
		if (this.bShowSelectEffect && this.m_SelectTime < 0.5f)
		{
			this.m_SelectTime += Time.deltaTime;
			this.m_SelectEffectAlpha = Mathf.Lerp(0f, 2f, this.m_SelectTime / 0.5f);
			if (this.m_SelectEffectAlpha > 1f)
			{
				this.m_SelectEffect.color = new Color(1f, 1f, 1f, 2f - this.m_SelectEffectAlpha);
			}
			else
			{
				this.m_SelectEffect.color = new Color(1f, 1f, 1f, this.m_SelectEffectAlpha);
			}
			if (this.m_SelectEffectAlpha >= 2f)
			{
				this.m_SelectTime = 0f;
				this.bShowSelectEffect = false;
			}
		}
		if (this.m_RankSelect != null)
		{
			int num = 0;
			while (num < this.m_RanSelectTime.Length && num < this.m_RankSelect.Length)
			{
				if (this.m_RanSelectTime[num] < 0.3f && this.m_RankSelect[num].enabled)
				{
					this.m_RanSelectTime[num] += Time.deltaTime;
					this.m_RanSelectAlpha[num] = Mathf.Lerp(0f, 2f, this.m_RanSelectTime[num] / 0.3f);
					if (this.m_RanSelectAlpha[num] > 1f)
					{
						this.m_RankSelect[num].color = new Color(1f, 1f, 1f, 2f - this.m_RanSelectAlpha[num]);
					}
					else
					{
						this.m_RankSelect[num].color = new Color(1f, 1f, 1f, this.m_RanSelectAlpha[num]);
					}
					if (this.m_RanSelectAlpha[num] >= 2f)
					{
						this.m_RanSelectTime[num] = 0f;
						this.m_RankSelect[num].enabled = false;
					}
				}
				num++;
			}
		}
		if (this.m_PetSelect.m_ID != 0)
		{
			this.m_SliderTime += Time.deltaTime;
			this.m_SliderEffectAlpha = Mathf.Lerp(0f, 2f, this.m_SliderTime / 1f);
			if (this.m_SliderEffectAlpha > 1f)
			{
				this.m_PetInfoDeltaExp.color = new Color(1f, 1f, 1f, 2f - this.m_SliderEffectAlpha);
			}
			else
			{
				this.m_PetInfoDeltaExp.color = new Color(1f, 1f, 1f, this.m_SliderEffectAlpha);
			}
			if (this.m_SliderEffectAlpha >= 2f)
			{
				this.m_SliderTime = 0f;
			}
		}
	}

	// Token: 0x06001741 RID: 5953 RVA: 0x0027F1A4 File Offset: 0x0027D3A4
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelObjectIdx < 7)
		{
			if (!this.m_ScrollObjects[panelObjectIdx].m_PetItem.HasInstance)
			{
				this.InitScrollItem(item, panelObjectIdx);
			}
			this.UpdateScrollItem(item, dataIdx, panelObjectIdx);
		}
	}

	// Token: 0x06001742 RID: 5954 RVA: 0x0027F1E4 File Offset: 0x0027D3E4
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001743 RID: 5955 RVA: 0x0027F1E8 File Offset: 0x0027D3E8
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			this.SetType(UIPetSelect.EUIType.Hero);
			break;
		case 1:
			if (this.m_AutoState == UIPetSelect.EAutoState.AutoState)
			{
				this.ClearAutoSelect();
				this.AutoSelectHero();
			}
			else if (this.m_AutoState == UIPetSelect.EAutoState.ClearnState)
			{
				this.ClearAutoSelect();
			}
			break;
		case 2:
			if (this.m_UIType == UIPetSelect.EUIType.Hero)
			{
				this.SetType(UIPetSelect.EUIType.Pet);
			}
			else
			{
				this.RequestPetTrainingBegin();
			}
			break;
		case 3:
		{
			UIPetSelect.EItemIdx btnID = (UIPetSelect.EItemIdx)sender.m_BtnID2;
			int btnID2 = sender.m_BtnID3;
			int btnID3 = sender.m_BtnID4;
			if (this.m_UIType == UIPetSelect.EUIType.Pet)
			{
				if (this.m_PetScrollData[btnID2].CheckIconType(btnID, UIPetSelect.EIconType.Training))
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(17105u), 35, true);
				}
				else if (this.m_PetScrollData[btnID2].CheckIconType(btnID, UIPetSelect.EIconType.LockLimit))
				{
					ushort num = this.m_PetScrollData[btnID2].m_ID[(int)btnID];
					if (num > 0)
					{
						PetData petData = this.PetMgr.FindPetData(num);
						if (petData != null)
						{
							if (petData.CheckState(PetManager.EPetState.Evolution))
							{
								GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(17150u), 35, true);
							}
							else
							{
								GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(16082u), this.DM.mStringTable.GetStringByID(16069u), this.DM.mStringTable.GetStringByID(3968u), this, 2, (int)num, true, false, false, false, false);
							}
						}
					}
				}
				else if (this.m_PetScrollData[btnID2].CheckIconType(btnID, UIPetSelect.EIconType.Lock))
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(17089u), 35, true);
				}
				else if (!this.m_PetScrollData[btnID2].CheckIconType(btnID, UIPetSelect.EIconType.Training))
				{
					for (int i = 0; i < this.m_ScrollObjects.Length; i++)
					{
						if (this.m_ScrollObjects[i].m_PetItem.HasInstance)
						{
							this.m_ScrollObjects[i].m_PetItem.RemoveIcon(UIPetSelect.EItemIdx.Left, UIPetSelect.EIconType.Select);
							this.m_ScrollObjects[i].m_PetItem.RemoveIcon(UIPetSelect.EItemIdx.Right, UIPetSelect.EIconType.Select);
						}
					}
					this.m_ScrollObjects[btnID3].m_PetItem.OnSelect(btnID);
					if (this.m_PetSelect.m_DataIdx != 255 && (int)this.m_PetSelect.m_DataIdx <= this.m_PetScrollData.Count)
					{
						this.m_PetScrollData[(int)this.m_PetSelect.m_DataIdx].RemoveSelectIcon(this.m_PetSelect.m_ItemIdx);
					}
					this.m_PetSelect = this.m_PetScrollData[btnID2].OnSelect(btnID, (byte)btnID2);
					this.SetInfoPanel();
					this.bShowSelectEffect = true;
					this.SetSelectCountPanel();
				}
			}
			else if (this.m_UIType == UIPetSelect.EUIType.Hero)
			{
				if (!this.m_HeroScrollData[btnID2].CheckIconType(btnID, UIPetSelect.EIconType.Training))
				{
					this.m_ScrollObjects[btnID3].m_HeroItem.OnSelect(btnID);
					UIPetSelect.ESelectItem eselectItem = this.m_HeroScrollData[btnID2].OnSelect(btnID, (byte)btnID2);
					ushort num2 = this.m_HeroScrollData[btnID2].m_ID[(int)btnID];
					if (eselectItem.m_DataIdx != 255)
					{
						if ((int)this.m_HeroScrollData[btnID2].m_Color[(int)btnID] < this.m_ColorCount.Length)
						{
							byte[] colorCount = this.m_ColorCount;
							byte b = this.m_HeroScrollData[btnID2].m_Color[(int)btnID];
							colorCount[(int)b] = colorCount[(int)b] + 1;
						}
						if ((int)this.m_HeroScrollData[btnID2].m_Color[(int)btnID] < this.m_RankSelect.Length)
						{
							this.m_RankSelect[(int)this.m_HeroScrollData[btnID2].m_Color[(int)btnID]].enabled = true;
						}
						this.m_RankSelect[5].enabled = true;
						this.m_CoachHeroTime += this.m_HeroScrollData[btnID2].m_TrainTime[(int)btnID];
						this.m_CoachHeroId.Add(num2);
					}
					else
					{
						if ((int)this.m_HeroScrollData[btnID2].m_Color[(int)btnID] < this.m_ColorCount.Length)
						{
							byte[] colorCount2 = this.m_ColorCount;
							byte b2 = this.m_HeroScrollData[btnID2].m_Color[(int)btnID];
							colorCount2[(int)b2] = colorCount2[(int)b2] - 1;
						}
						this.m_CoachHeroTime -= this.m_HeroScrollData[btnID2].m_TrainTime[(int)btnID];
						if (!this.m_CoachHeroId.Remove(num2))
						{
							Debug.Log("heroID " + num2 + " RemoveError");
						}
					}
					this.SetInfoPanel();
					this.SetSelectCountPanel();
				}
				else
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(17112u), 35, true);
				}
			}
			break;
		}
		case 4:
			if (this.m_UIType == UIPetSelect.EUIType.Hero)
			{
				this.SetType(UIPetSelect.EUIType.Pet);
			}
			else if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		}
	}

	// Token: 0x06001744 RID: 5956 RVA: 0x0027F758 File Offset: 0x0027D958
	public void OnButtonDown(UIButtonHint sender)
	{
		if (sender.Parm1 == 10 || sender.Parm1 == 11 || sender.Parm1 == 12)
		{
			int num = (int)(sender.Parm1 - 10);
			PetData petData = this.PetMgr.FindPetData(this.m_PetSelect.m_ID);
			if (petData != null && petData.ID == this.m_PetSelect.m_ID && num >= 0 && num < petData.SkillLv.Length && num < petData.SkillID.Length)
			{
				GUIManager.Instance.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Normal, petData.ID, petData.SkillID[num], petData.SkillLv[num], new Vector2(-22f, 0f), UIButtonHint.ePosition.LeftSide);
			}
		}
		else
		{
			ushort parm = 0;
			if (sender.Parm1 == 5)
			{
				parm = 17108;
			}
			else if (sender.Parm1 == 6)
			{
				parm = 17109;
			}
			else if (sender.Parm1 == 7)
			{
				parm = 17110;
			}
			else if (sender.Parm1 == 8)
			{
				parm = 17111;
			}
			else if (sender.Parm1 == 9)
			{
				parm = 17095;
			}
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 277f, 20, (int)parm, 0, Vector2.zero, UIButtonHint.ePosition.Original);
		}
		AudioManager.Instance.PlayUISFX(UIKind.Normal);
	}

	// Token: 0x06001745 RID: 5957 RVA: 0x0027F8CC File Offset: 0x0027DACC
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(false);
	}

	// Token: 0x06001746 RID: 5958 RVA: 0x0027F8E0 File Offset: 0x0027DAE0
	private void Init()
	{
		this.m_Sp = base.transform.GetComponent<UISpritesArray>();
		this.m_ScrollPanel = base.transform.GetChild(2).GetComponent<ScrollPanel>();
		Transform child = base.transform.GetChild(4);
		Transform child2 = base.transform.GetChild(1);
		this.m_SelectCountTransform = new Transform[2];
		this.m_SelectCountTransform[0] = child2.GetChild(0);
		this.m_SelectCountTransform[1] = child2.GetChild(1);
		this.m_InfoTitleText = child.GetChild(1).GetComponent<UIText>();
		this.m_InfoTitleText.font = GUIManager.Instance.GetTTFFont();
		this.m_InfoTitleText.text = DataManager.Instance.mStringTable.GetStringByID(17098u);
		this.m_InfoTitleText2 = child.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_InfoTitleText2.font = GUIManager.Instance.GetTTFFont();
		this.m_InfoTitleText2.text = DataManager.Instance.mStringTable.GetStringByID(17102u);
		if (GUIManager.Instance.IsArabic)
		{
			this.m_InfoTitleText2.rectTransform.Rotate(0f, 180f, 0f);
		}
		this.m_InfoTransform = new Transform[2];
		this.m_InfoTransform[0] = child.GetChild(2);
		this.m_PetHiBtn = this.m_InfoTransform[0].GetChild(0).GetChild(0).GetComponent<UIHIBtn>();
		GUIManager.Instance.InitianHeroItemImg(this.m_PetHiBtn.transform, eHeroOrItem.Pet, 0, 0, 0, 0, true, true, true, false);
		this.m_SelectEffect = this.m_InfoTransform[0].GetChild(0).GetChild(1).GetComponent<Image>();
		this.m_SkillIconTf = this.m_InfoTransform[0].GetChild(0).GetChild(2);
		Image component = this.m_InfoTransform[0].GetChild(0).GetChild(2).GetComponent<Image>();
		component.sprite = this.PetMgr.LoadPetSkillIcon(0);
		component.material = GUIManager.Instance.GetSkillMaterial();
		component = this.m_InfoTransform[0].GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>();
		component.sprite = GUIManager.Instance.LoadFrameSprite("sk");
		component.material = GUIManager.Instance.GetFrameMaterial();
		UIButtonHint uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 9;
		this.m_InfoExpTf = this.m_InfoTransform[0].GetChild(1);
		this.m_PetInfoExp = this.m_InfoTransform[0].GetChild(1).GetChild(1).GetComponent<Image>();
		this.m_PetInfoDeltaExp = this.m_InfoTransform[0].GetChild(1).GetChild(0).GetComponent<Image>();
		this.m_LvText = this.m_InfoTransform[0].GetChild(1).GetChild(2).GetChild(1).GetComponent<UIText>();
		this.m_LvText.font = GUIManager.Instance.GetTTFFont();
		this.m_InfoRandSkillText = this.m_InfoTransform[0].GetChild(1).GetChild(3).GetComponent<UIText>();
		this.m_InfoRandSkillText.font = GUIManager.Instance.GetTTFFont();
		this.m_InfoRandSkillText2 = this.m_InfoTransform[0].GetChild(1).GetChild(4).GetComponent<UIText>();
		this.m_InfoRandSkillText2.font = GUIManager.Instance.GetTTFFont();
		this.m_PetInfoText = new UIText[3];
		this.m_PetInfoText[0] = this.m_InfoTransform[0].GetChild(2).GetChild(1).GetComponent<UIText>();
		this.m_PetInfoText[0].font = GUIManager.Instance.GetTTFFont();
		this.m_PetInfoText[1] = this.m_InfoTransform[0].GetChild(2).GetChild(2).GetComponent<UIText>();
		this.m_PetInfoText[1].font = GUIManager.Instance.GetTTFFont();
		this.m_PetInfoText[2] = this.m_InfoTransform[0].GetChild(3).GetChild(1).GetComponent<UIText>();
		this.m_PetInfoText[2].font = GUIManager.Instance.GetTTFFont();
		this.m_PetInfoOverTimeIcon = this.m_InfoTransform[0].GetChild(3).GetChild(2).GetComponent<Image>();
		this.m_PetInfoSkillTf = new Transform[3];
		this.m_PetInfoSkillIcon = new Image[3];
		this.m_PetInfoSkillHint = new UIButtonHint[3];
		this.m_PetInfoSkillLcokImg = new Image[3];
		this.m_PetInfoSkillBackImg = new Image[3];
		for (int i = 0; i < 3; i++)
		{
			this.m_PetInfoSkillTf[i] = this.m_InfoTransform[0].GetChild(4).GetChild(i);
			this.m_PetInfoSkillHint[i] = this.m_PetInfoSkillTf[i].GetChild(0).gameObject.AddComponent<UIButtonHint>();
			this.m_PetInfoSkillHint[i].m_eHint = EUIButtonHint.DownUpHandler;
			this.m_PetInfoSkillHint[i].m_Handler = this;
			this.m_PetInfoSkillHint[i].Parm1 = (ushort)(10 + i);
			this.m_PetInfoSkillIcon[i] = this.m_PetInfoSkillTf[i].GetChild(0).GetComponent<Image>();
			this.m_PetInfoSkillIcon[i].sprite = this.PetMgr.LoadPetSkillIcon(0);
			this.m_PetInfoSkillIcon[i].material = GUIManager.Instance.GetSkillMaterial();
			component = this.m_PetInfoSkillTf[i].GetChild(1).GetComponent<Image>();
			component.sprite = GUIManager.Instance.LoadFrameSprite("sk");
			component.material = GUIManager.Instance.GetFrameMaterial();
			this.m_PetInfoSkillLcokImg[i] = this.m_PetInfoSkillTf[i].GetChild(2).GetComponent<Image>();
			this.m_PetInfoSkillBackImg[i] = this.m_PetInfoSkillTf[i].GetChild(3).GetComponent<Image>();
		}
		uint selectHeroTime = this.GetSelectHeroTime();
		this.m_CStr[2].ClearString();
		this.m_CStr[2].IntToFormat((long)((ulong)this.GetSelectHeroExpByMin(selectHeroTime / 60.0)), 1, true);
		this.m_CStr[2].AppendFormat("{0}");
		this.m_PetInfoText[0].text = this.m_CStr[2].ToString();
		this.m_PetInfoText[0].SetAllDirty();
		this.m_PetInfoText[0].cachedTextGenerator.Invalidate();
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETTRAININGEXP_EXP_PERCENT);
		float f = (float)effectBaseVal / 100f;
		this.m_CStr[1].ClearString();
		this.m_CStr[1].FloatToFormat(f, 2, false);
		this.m_CStr[1].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17130u));
		this.m_PetInfoText[1].text = this.m_CStr[1].ToString();
		this.m_PetInfoText[1].SetAllDirty();
		this.m_PetInfoText[1].cachedTextGenerator.Invalidate();
		this.m_CStr[3].ClearString();
		UIPetSelect.GetTimeInfoString(this.m_CStr[3], selectHeroTime, false);
		this.m_PetInfoText[2].text = this.m_CStr[3].ToString();
		this.m_PetInfoText[2].SetAllDirty();
		this.m_PetInfoText[2].cachedTextGenerator.Invalidate();
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			component = this.m_InfoTransform[0].GetChild(2).GetComponent<Image>();
			component.sprite = this.m_Sp.GetSprite(3);
		}
		this.m_InfoTransform[0].GetChild(2).gameObject.AddComponent<ArabicItemTextureRot>();
		uibuttonHint = this.m_InfoTransform[0].GetChild(2).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 5;
		uibuttonHint = this.m_InfoTransform[0].GetChild(3).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 6;
		this.m_InfoTransform[1] = child.GetChild(3);
		UIButton component2 = this.m_InfoTransform[1].GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 1;
		component2 = child.GetChild(4).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 2;
		this.m_OKTExt = child.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.m_OKTExt.font = GUIManager.Instance.GetTTFFont();
		this.m_OKTExt.text = this.DM.mStringTable.GetStringByID(189u);
		this.m_PetHeroSelectBlack = this.m_SelectCountTransform[0].GetChild(0).GetComponent<Image>();
		this.m_SelectCountTransform[0].GetChild(3).gameObject.AddComponent<ArabicItemTextureRot>();
		this.m_HeroInfoCount = this.m_SelectCountTransform[0].GetChild(3).GetChild(1).GetComponent<UIText>();
		this.m_HeroInfoCount.font = GUIManager.Instance.GetTTFFont();
		this.m_HeroInfoText = new UIText[5];
		this.m_RankSelect = new Image[6];
		for (int j = 0; j < this.m_HeroInfoText.Length; j++)
		{
			this.m_RankSelect[j] = this.m_SelectCountTransform[0].GetChild(4 + j).GetChild(0).GetComponent<Image>();
			this.m_HeroInfoText[j] = this.m_SelectCountTransform[0].GetChild(4 + j).GetChild(1).GetComponent<UIText>();
			if (this.m_HeroInfoText[j] != null)
			{
				this.m_HeroInfoText[j].font = GUIManager.Instance.GetTTFFont();
			}
		}
		this.m_RankSelect[5] = this.m_SelectCountTransform[0].GetChild(3).GetChild(0).GetComponent<Image>();
		this.m_RankSelect[5].gameObject.AddComponent<ArabicItemTextureRot>();
		this.m_AutoSelectText = new UIText[2];
		this.m_AutoSelectText[0] = base.transform.GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
		this.m_AutoSelectText[0].font = GUIManager.Instance.GetTTFFont();
		this.m_AutoSelectText[1] = this.m_InfoTransform[1].GetChild(0).GetChild(0).GetComponent<UIText>();
		this.m_AutoSelectText[1].font = GUIManager.Instance.GetTTFFont();
		this.m_SwitchHeroTypeBtn = base.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<UIButton>();
		this.m_SwitchHeroTypeBtn.m_Handler = this;
		this.m_SwitchHeroTypeBtn.m_BtnID1 = 0;
		this.m_HeroImage = base.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
		this.m_HeroImageText = base.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.m_HeroImageText.font = GUIManager.Instance.GetTTFFont();
		this.m_HeroImageText.text = this.DM.mStringTable.GetStringByID(17090u);
		this.m_AutoSelectHeroBtn = base.transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<UIButton>();
		this.m_AutoSelectHeroBtn.m_Handler = this;
		this.m_AutoSelectHeroBtn.m_BtnID1 = 1;
		this.m_SelectCountTransform[1].GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			component = this.m_SelectCountTransform[1].GetChild(1).GetComponent<Image>();
			component.sprite = this.m_Sp.GetSprite(3);
		}
		this.m_HeroInfoExp = this.m_SelectCountTransform[1].GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_HeroInfoExp.font = GUIManager.Instance.GetTTFFont();
		this.m_HeroInfoTime = this.m_SelectCountTransform[1].GetChild(2).GetChild(0).GetComponent<UIText>();
		this.m_HeroInfoTime.font = GUIManager.Instance.GetTTFFont();
		uibuttonHint = this.m_SelectCountTransform[1].GetChild(4).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 7;
		uibuttonHint = this.m_SelectCountTransform[1].GetChild(5).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 8;
		component = base.transform.GetChild(5).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close_base");
		component.material = this.door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX && component)
		{
			component.enabled = false;
		}
		component2 = base.transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 4;
		component2.image.sprite = this.door.LoadSprite("UI_main_close");
		component2.image.material = this.door.LoadMaterial();
		if (this.m_CoachHeroId != null && this.m_CoachHeroId.Count > 0)
		{
			this.SetAutoBtnState(UIPetSelect.EAutoState.ClearnState);
		}
		else
		{
			this.SetAutoBtnState(UIPetSelect.EAutoState.AutoState);
		}
		this.InitScorllPanel();
		this.SetType(UIPetSelect.EUIType.Pet);
	}

	// Token: 0x06001747 RID: 5959 RVA: 0x00280630 File Offset: 0x0027E830
	private UIPetSelect.SScrollData SpawnPetData()
	{
		return this.PetMgr.m_PetSelectPool.spawn();
	}

	// Token: 0x06001748 RID: 5960 RVA: 0x00280644 File Offset: 0x0027E844
	private UIPetSelect.SScrollData SpawnHeroData()
	{
		return this.PetMgr.m_HeroSelectPool.spawn();
	}

	// Token: 0x06001749 RID: 5961 RVA: 0x00280658 File Offset: 0x0027E858
	private void SetPetData(int selectIdx)
	{
		ushort num = 0;
		if (selectIdx >= 0 && selectIdx < this.PetMgr.m_PetTrainingClinetSave.Length)
		{
			num = this.PetMgr.m_PetTrainingClinetSave[selectIdx].m_PetTrainingSet.m_PetId;
		}
		else if (selectIdx == -1)
		{
			num = this.m_PetSelect.m_ID;
		}
		int num2 = 0;
		int num3 = 0;
		UIPetSelect.SScrollData sscrollData = null;
		bool flag = false;
		int num4 = 0;
		while (num4 < (int)this.PetIdelCount && num4 < this.PetMgr.m_PetTrainginSortData.Count)
		{
			if (num2 == 0)
			{
				sscrollData = this.SpawnPetData();
				flag = true;
			}
			if (sscrollData != null)
			{
				sscrollData.bLineType = false;
				sscrollData.bShowOnlyLeft = true;
				sscrollData.bDataPadding = true;
				sscrollData.m_DataIdx[num2] = (int)this.PetMgr.m_PetTrainginSortData[num4];
				PetData petData = this.PetMgr.GetPetData((int)((byte)sscrollData.m_DataIdx[num2]));
				sscrollData.m_ID[num2] = petData.ID;
				sscrollData.m_EIconType[num2] = UIPetSelect.EIconType.None;
				if (petData.CheckState(PetManager.EPetState.Training))
				{
					sscrollData.m_EIconType[num2] |= UIPetSelect.EIconType.Training;
				}
				else if (petData.CheckState(PetManager.EPetState.LockLimit))
				{
					sscrollData.m_EIconType[num2] |= UIPetSelect.EIconType.LockLimit;
				}
				else if (num == petData.ID)
				{
					this.m_PetSelect.m_ID = num;
					this.m_PetSelect.m_DataIdx = (byte)this.m_PetScrollData.Count;
					this.m_PetSelect.m_ItemIdx = (UIPetSelect.EItemIdx)num2;
					sscrollData.m_EIconType[num2] |= UIPetSelect.EIconType.Select;
				}
				if (num2 == 1)
				{
					this.m_PetScrollData.Add(sscrollData);
					flag = false;
				}
				if (num2 == 1)
				{
					num2 = 0;
					sscrollData.bShowOnlyLeft = false;
				}
				else if (num2 == 0)
				{
					num2 = 1;
				}
			}
			num4++;
		}
		if (flag && sscrollData != null)
		{
			this.m_PetScrollData.Add(sscrollData);
		}
		byte b = 1;
		if (PetManager.Instance.PetDataCount > (ushort)this.PetIdelCount)
		{
			sscrollData = this.SpawnPetData();
			for (int i = 0; i < 2; i++)
			{
				sscrollData.bLineType = true;
				sscrollData.bShowOnlyLeft = true;
				sscrollData.bDataPadding = true;
				b += 1;
				if (b > 2)
				{
					this.m_PetScrollData.Add(sscrollData);
					num3++;
				}
			}
		}
		b = 1;
		int num5 = (int)this.PetIdelCount;
		while (num5 < (int)PetManager.Instance.PetDataCount && num5 < this.PetMgr.m_PetTrainginSortData.Count)
		{
			if (b == 1)
			{
				sscrollData = this.SpawnPetData();
				num2 = 0;
			}
			else
			{
				num2 = 1;
			}
			sscrollData.bLineType = false;
			sscrollData.bShowOnlyLeft = true;
			sscrollData.bDataPadding = true;
			sscrollData.m_DataIdx[num2] = (int)this.PetMgr.m_PetTrainginSortData[num5];
			PetData petData = this.PetMgr.GetPetData((int)((byte)sscrollData.m_DataIdx[num2]));
			sscrollData.m_ID[num2] = petData.ID;
			petData = this.PetMgr.FindPetData(petData.ID);
			if (selectIdx >= 0 && selectIdx < this.PetMgr.m_PetTrainingClinetSave.Length)
			{
				num = this.PetMgr.m_PetTrainingClinetSave[selectIdx].m_PetTrainingSet.m_PetId;
			}
			sscrollData.m_EIconType[num2] = UIPetSelect.EIconType.None;
			sscrollData.m_EIconType[num2] |= UIPetSelect.EIconType.Lock;
			b += 1;
			if (num2 == 1 || num5 == (int)(PetManager.Instance.PetDataCount - 1))
			{
				if (num2 == 1)
				{
					sscrollData.bShowOnlyLeft = false;
				}
				else
				{
					sscrollData.bShowOnlyLeft = true;
				}
				this.m_PetScrollData.Add(sscrollData);
				num3++;
				b = 1;
			}
			num5++;
		}
	}

	// Token: 0x0600174A RID: 5962 RVA: 0x00280A24 File Offset: 0x0027EC24
	private void SetHeroData(int selectIdx)
	{
		int num = 0;
		int num2 = 0;
		UIPetSelect.SScrollData sscrollData = null;
		List<ushort> list = new List<ushort>();
		if (selectIdx != -1)
		{
			list.Clear();
			this.m_CoachHeroId.Clear();
		}
		this.m_CoachHeroTime = 0u;
		Array.Clear(this.m_ColorCount, 0, this.m_ColorCount.Length);
		bool flag = false;
		this.m_CanSelectHeroCount = 0;
		int num3 = 0;
		while ((long)num3 < (long)((ulong)this.DM.CurHeroDataCount))
		{
			if (this.DM.curHeroData.ContainsKey(this.DM.sortHeroData[num3]))
			{
				CurHeroData curHeroData = this.DM.curHeroData[this.DM.sortHeroData[num3]];
				if (!this.PetMgr.IsTrainingHero(curHeroData.ID))
				{
					if (num == 0)
					{
						sscrollData = this.SpawnHeroData();
						flag = true;
					}
					if (sscrollData != null)
					{
						this.m_CanSelectHeroCount += 1;
						sscrollData.bShowOnlyLeft = true;
						sscrollData.bLineType = false;
						sscrollData.bDataPadding = true;
						sscrollData.m_DataIdx[num] = (int)this.DM.sortHeroData[num3];
						sscrollData.m_ID[num] = curHeroData.ID;
						sscrollData.m_TrainTime[num] = (uint)(curHeroData.Star * 10 + 10);
						sscrollData.m_Color[num] = curHeroData.Star - 1;
						if (selectIdx == -1)
						{
							if (this.m_CoachHeroId.Contains(curHeroData.ID))
							{
								sscrollData.m_EIconType[num] = UIPetSelect.EIconType.Select;
								this.m_CoachHeroTime += sscrollData.m_TrainTime[num];
								if ((int)sscrollData.m_Color[num] < this.m_ColorCount.Length)
								{
									byte[] colorCount = this.m_ColorCount;
									byte b = sscrollData.m_Color[num];
									colorCount[(int)b] = colorCount[(int)b] + 1;
								}
							}
						}
						else if (selectIdx >= 0 && selectIdx < this.PetMgr.m_PetTrainingClinetSave.Length)
						{
							if (this.PetMgr.m_PetTrainingClinetSave[selectIdx].m_PetTrainingSet.m_CoachHeroId.Contains(curHeroData.ID))
							{
								this.m_CoachHeroId.Add(curHeroData.ID);
								sscrollData.m_EIconType[num] = UIPetSelect.EIconType.Select;
								this.m_CoachHeroTime += sscrollData.m_TrainTime[num];
								if ((int)sscrollData.m_Color[num] < this.m_ColorCount.Length)
								{
									byte[] colorCount2 = this.m_ColorCount;
									byte b2 = sscrollData.m_Color[num];
									colorCount2[(int)b2] = colorCount2[(int)b2] + 1;
								}
							}
						}
						else
						{
							sscrollData.m_EIconType[num] = UIPetSelect.EIconType.None;
						}
						if (num == 1)
						{
							this.m_HeroScrollData.Add(sscrollData);
							flag = false;
						}
						if (num == 1)
						{
							num = 0;
							sscrollData.bShowOnlyLeft = false;
						}
						else if (num == 0)
						{
							num = 1;
						}
					}
				}
				else
				{
					list.Add(curHeroData.ID);
				}
			}
			num3++;
		}
		if (flag && sscrollData != null)
		{
			this.m_HeroScrollData.Add(sscrollData);
		}
		byte b3 = 1;
		if (list.Count > 0)
		{
			for (int i = 0; i < 2; i++)
			{
				if (b3 == 1)
				{
					sscrollData = this.SpawnHeroData();
					num = 0;
				}
				else
				{
					num = 1;
				}
				sscrollData.bLineType = true;
				sscrollData.bShowOnlyLeft = true;
				sscrollData.bDataPadding = true;
				sscrollData.m_EIconType[num] = UIPetSelect.EIconType.None;
				b3 += 1;
				if (b3 > 2)
				{
					this.m_HeroScrollData.Add(sscrollData);
					num2++;
				}
			}
		}
		b3 = 1;
		if (list.Count > 0)
		{
			for (int j = 0; j < list.Count; j++)
			{
				if (b3 == 1)
				{
					sscrollData = this.SpawnHeroData();
					num = 0;
				}
				else
				{
					num = 1;
				}
				sscrollData.bLineType = false;
				sscrollData.bShowOnlyLeft = true;
				sscrollData.bDataPadding = true;
				sscrollData.m_DataIdx[num] = (int)list[j];
				if (this.DM.curHeroData.ContainsKey((uint)sscrollData.m_DataIdx[num]))
				{
					CurHeroData curHeroData = this.DM.curHeroData[(uint)sscrollData.m_DataIdx[num]];
					sscrollData.m_ID[num] = curHeroData.ID;
					sscrollData.m_TrainTime[num] = (uint)(curHeroData.Star * 10 + 10);
					sscrollData.m_Color[num] = curHeroData.Star - 1;
					sscrollData.m_EIconType[num] = UIPetSelect.EIconType.Training;
					b3 += 1;
					if (b3 > 2 || j == list.Count - 1)
					{
						if (b3 > 2)
						{
							sscrollData.bShowOnlyLeft = false;
						}
						this.m_HeroScrollData.Add(sscrollData);
						num2++;
						b3 = 1;
					}
				}
			}
		}
	}

	// Token: 0x0600174B RID: 5963 RVA: 0x00280E98 File Offset: 0x0027F098
	private void SetType(UIPetSelect.EUIType type)
	{
		if (this.m_ScrollPanel != null)
		{
			this.m_ScrollIdx[(int)this.m_UIType] = this.m_ScrollPanel.GetTopIdx();
			this.m_ScrollPosY[(int)this.m_UIType] = this.m_ScrollPanel.GetContentPos();
		}
		this.m_UIType = type;
		this.UpdateScrollPanel(true, true);
		this.SetInfoPanel();
		this.SetSelectCountPanel();
	}

	// Token: 0x0600174C RID: 5964 RVA: 0x00280F04 File Offset: 0x0027F104
	private double GetExpPerMinute()
	{
		bool bSkill = false;
		PetData petData = this.PetMgr.FindPetData(this.m_PetSelect.m_ID);
		if (petData != null)
		{
			bSkill = (petData.Level == 60);
		}
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETTRAININGEXP_EXP_PERCENT);
		double num = effectBaseVal / 10000.0;
		ushort trainExpByHeroCount = this.PetMgr.GetTrainExpByHeroCount((ushort)this.m_CoachHeroId.Count, bSkill);
		return (double)(10 + trainExpByHeroCount) * (1.0 + num) / 60.0;
	}

	// Token: 0x0600174D RID: 5965 RVA: 0x00280F98 File Offset: 0x0027F198
	private uint GetSelectHeroExpByMin(double minute)
	{
		return (uint)(this.GetExpPerMinute() * minute);
	}

	// Token: 0x0600174E RID: 5966 RVA: 0x00280FB0 File Offset: 0x0027F1B0
	private uint GetSelectHeroExp()
	{
		bool bSkill = false;
		PetData petData = this.PetMgr.FindPetData(this.m_PetSelect.m_ID);
		if (petData != null)
		{
			bSkill = (petData.Level == 60);
		}
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETTRAININGEXP_EXP_PERCENT);
		float num = effectBaseVal / 10000f;
		ushort trainExpByHeroCount = this.PetMgr.GetTrainExpByHeroCount((ushort)this.m_CoachHeroId.Count, bSkill);
		return (uint)((float)(10 + trainExpByHeroCount) * (1f + num));
	}

	// Token: 0x0600174F RID: 5967 RVA: 0x00281034 File Offset: 0x0027F234
	private uint GetSelectHeroTime()
	{
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETTRAININGEXP_TIME);
		return (120u + this.m_CoachHeroTime + effectBaseVal) * 60u;
	}

	// Token: 0x06001750 RID: 5968 RVA: 0x00281068 File Offset: 0x0027F268
	private void SetInfoPanel()
	{
		if (this.m_UIType == UIPetSelect.EUIType.Pet)
		{
			this.m_InfoTransform[0].gameObject.SetActive(true);
			if (this.m_PetSelect.m_ID == 0)
			{
				this.m_InfoTitleText.text = DataManager.Instance.mStringTable.GetStringByID(17098u);
			}
			else
			{
				this.m_InfoTitleText.text = DataManager.Instance.mStringTable.GetStringByID(17107u);
			}
			this.m_InfoTitleText2.enabled = false;
			byte dataIdx = this.m_PetSelect.m_DataIdx;
			UIPetSelect.EItemIdx itemIdx = this.m_PetSelect.m_ItemIdx;
			if ((int)dataIdx < this.m_PetScrollData.Count && itemIdx < UIPetSelect.EItemIdx.Max)
			{
				int num = this.m_PetScrollData[(int)dataIdx].m_DataIdx[(int)itemIdx];
				PetData petData = this.PetMgr.GetPetData((int)((byte)num));
				if (petData != null)
				{
					PetTbl recordByKey = this.PetMgr.PetTable.GetRecordByKey(petData.ID);
					if (this.m_PetHiBtn != null)
					{
						GUIManager.Instance.ChangeHeroItemImg(this.m_PetHiBtn.transform, eHeroOrItem.Pet, petData.ID, petData.Enhance, 0, 0);
					}
					float num2 = 183f;
					PetExpTbl recordByKey2 = this.PetMgr.PetExpTable.GetRecordByKey((ushort)petData.Level);
					uint num3 = petData.Exp;
					uint selectHeroExpByMin = this.GetSelectHeroExpByMin(this.GetSelectHeroTime() / 60.0);
					uint num4 = 0u;
					byte b = 0;
					uint num5 = selectHeroExpByMin;
					byte maxLevel = petData.GetMaxLevel(true);
					for (ushort num6 = (ushort)petData.Level; num6 <= (ushort)maxLevel; num6 += 1)
					{
						recordByKey2 = this.PetMgr.PetExpTable.GetRecordByKey(num6);
						num4 = this.PetMgr.GetNeedExp((byte)num6, recordByKey.Rare);
						b = (byte)num6;
						if (num6 == (ushort)petData.Level)
						{
							num3 = petData.Exp;
						}
						else if (num6 > (ushort)petData.Level)
						{
							num3 = 0u;
						}
						uint num7 = num4 - num3;
						if (num6 == (ushort)maxLevel)
						{
							if (num5 >= num7)
							{
								num5 = num4 - 1u;
							}
							break;
						}
						if (num5 <= num7)
						{
							break;
						}
						num5 -= num7;
					}
					this.m_CStr[0].ClearString();
					this.m_CStr[0].IntToFormat((long)b, 1, false);
					this.m_CStr[0].AppendFormat("{0}");
					this.m_LvText.text = this.m_CStr[0].ToString();
					this.m_LvText.SetAllDirty();
					this.m_LvText.cachedTextGenerator.Invalidate();
					if (b > petData.Level)
					{
						this.m_LvText.color = new Color(0.031f, 0.956f, 0.29f, 1f);
					}
					else
					{
						this.m_LvText.color = new Color(1f, 1f, 1f, 1f);
					}
					Vector2 sizeDelta = this.m_PetInfoDeltaExp.rectTransform.sizeDelta;
					if (num5 != 0u)
					{
						byte level = DataManager.Instance.RoleAttr.Level;
						float min = 1f;
						if (b == 60 || (b >= 15 && b >= level && petData.Exp >= num4 - 1u))
						{
							min = 0f;
							sizeDelta.x = 0f;
						}
						else if (b == petData.Level)
						{
							sizeDelta.x = ((num4 <= 0u) ? 0f : (num2 * ((num5 + num3) / num4)));
							min = Mathf.Clamp(sizeDelta.x, num2 * num3 / num4 + 1f, num2);
						}
						else
						{
							sizeDelta.x = ((num4 <= 0u) ? 0f : (num2 * (num5 / num4)));
						}
						sizeDelta.x = Mathf.Clamp(sizeDelta.x, min, num2);
						this.m_PetInfoDeltaExp.rectTransform.sizeDelta = sizeDelta;
					}
					else
					{
						sizeDelta.x = 0f;
						this.m_PetInfoDeltaExp.rectTransform.sizeDelta = sizeDelta;
					}
					sizeDelta = this.m_PetInfoExp.rectTransform.sizeDelta;
					if (b >= 60)
					{
						sizeDelta.x = 0f;
						this.m_PetInfoExp.rectTransform.sizeDelta = sizeDelta;
					}
					else if (b == petData.Level)
					{
						recordByKey2 = this.PetMgr.PetExpTable.GetRecordByKey((ushort)petData.Level);
						num4 = this.PetMgr.GetNeedExp(petData.Level, recordByKey.Rare);
						num3 = petData.Exp;
						sizeDelta.x = ((num4 <= 0u) ? 0f : (num2 * (num3 / num4)));
						sizeDelta.x = Mathf.Clamp(sizeDelta.x, 0f, num2 - 1f);
						this.m_PetInfoExp.rectTransform.sizeDelta = sizeDelta;
					}
					else
					{
						sizeDelta.x = 0f;
						this.m_PetInfoExp.rectTransform.sizeDelta = sizeDelta;
					}
					uint maxLevelExp = this.GetMaxLevelExp(petData.ID, petData.Level, petData.Exp, b);
					uint selectHeroTime = this.GetSelectHeroTime();
					uint selectHeroExpByMin2 = this.GetSelectHeroExpByMin(selectHeroTime / 60.0);
					uint canTrainTime = this.GetCanTrainTime(maxLevelExp, selectHeroExpByMin2, selectHeroTime);
					this.m_CStr[2].ClearString();
					bool flag = selectHeroExpByMin2 > maxLevelExp && maxLevelExp > 0u;
					if (maxLevelExp > 0u)
					{
						this.m_CStr[2].IntToFormat((long)((ulong)((!flag) ? selectHeroExpByMin2 : maxLevelExp)), 1, true);
					}
					else
					{
						this.m_CStr[2].IntToFormat((long)((ulong)selectHeroExpByMin2), 1, true);
					}
					this.m_CStr[2].AppendFormat("{0}");
					this.m_PetInfoText[0].text = this.m_CStr[2].ToString();
					this.m_PetInfoText[0].SetAllDirty();
					this.m_PetInfoText[0].cachedTextGenerator.Invalidate();
					uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETTRAININGEXP_EXP_PERCENT);
					float f = (float)effectBaseVal / 100f;
					this.m_CStr[1].ClearString();
					this.m_CStr[1].FloatToFormat(f, 2, false);
					this.m_CStr[1].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17130u));
					this.m_PetInfoText[1].text = this.m_CStr[1].ToString();
					this.m_PetInfoText[1].SetAllDirty();
					this.m_PetInfoText[1].cachedTextGenerator.Invalidate();
					this.m_CStr[3].ClearString();
					UIPetSelect.GetTimeInfoString(this.m_CStr[3], (!flag) ? selectHeroTime : canTrainTime, false);
					this.m_PetInfoText[2].text = this.m_CStr[3].ToString();
					this.m_PetInfoText[2].SetAllDirty();
					if (flag)
					{
						this.m_PetInfoText[2].color = new Color(1f, 0.988f, 0.819f);
					}
					else
					{
						this.m_PetInfoText[2].color = new Color(1f, 0.952f, 0.278f);
					}
					this.m_PetInfoText[2].cachedTextGenerator.Invalidate();
					this.ErrorType = 0;
					this.m_InfoExpTf.GetComponent<Image>().enabled = true;
					for (int i = 0; i < this.m_InfoExpTf.childCount; i++)
					{
						this.m_InfoExpTf.GetChild(i).gameObject.SetActive(true);
					}
					this.m_InfoExpTf.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector2(-44f, -43f);
					this.m_InfoExpTf.GetChild(3).GetComponent<UIText>().UpdateArabicPos();
					this.m_InfoRandSkillText2.gameObject.SetActive(false);
					if (this.m_PetSelect.m_ID == 0)
					{
						this.m_InfoExpTf.gameObject.SetActive(this.m_PetSelect.m_ID != 0);
					}
					else if (this.PetMgr.IsMaxLevelExp(petData.ID))
					{
						this.m_InfoRandSkillText.text = DataManager.Instance.mStringTable.GetStringByID(17100u);
						this.m_InfoRandSkillText.enabled = true;
						this.m_SkillIconTf.gameObject.SetActive(false);
						this.m_InfoExpTf.gameObject.SetActive(true);
						this.m_InfoExpTf.GetComponent<Image>().enabled = false;
						this.m_InfoExpTf.GetChild(0).gameObject.SetActive(false);
						this.m_InfoExpTf.GetChild(1).gameObject.SetActive(false);
						this.m_InfoExpTf.GetChild(2).gameObject.SetActive(false);
						this.m_InfoExpTf.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector2(-44f, 0f);
						this.m_InfoExpTf.GetChild(3).GetComponent<UIText>().UpdateArabicPos();
						this.m_InfoRandSkillText.alignment = TextAnchor.UpperLeft;
					}
					else if (petData.CheckState(PetManager.EPetState.LockLimit) || (num5 + num3 >= num4 - 1u && b == maxLevel))
					{
						if (b == 60)
						{
							this.m_CStr[15].ClearString();
							this.m_CStr[15].IntToFormat((long)petData.Level, 1, false);
							this.m_CStr[15].IntToFormat((long)b, 1, false);
							this.m_CStr[15].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17104u));
							this.m_InfoRandSkillText2.text = this.m_CStr[15].ToString();
							this.m_InfoRandSkillText2.gameObject.SetActive(true);
							this.m_InfoRandSkillText2.SetAllDirty();
							this.m_InfoRandSkillText2.cachedTextGenerator.Invalidate();
							this.m_InfoRandSkillText.text = DataManager.Instance.mStringTable.GetStringByID(17099u);
							this.m_InfoRandSkillText.enabled = true;
							this.m_SkillIconTf.gameObject.SetActive(false);
							this.m_InfoExpTf.gameObject.SetActive(true);
							this.m_InfoRandSkillText.alignment = TextAnchor.UpperLeft;
							this.m_InfoRandSkillText.rectTransform.anchoredPosition = new Vector2(-44f, -68.85f);
							this.m_InfoRandSkillText.UpdateArabicPos();
						}
						else
						{
							byte level2 = DataManager.Instance.RoleAttr.Level;
							if (b >= 15 && b >= level2)
							{
								this.m_InfoRandSkillText.text = DataManager.Instance.mStringTable.GetStringByID(17140u);
								if (petData.Exp >= num4 - 1u)
								{
									this.ErrorType = 1;
								}
								else
								{
									this.ErrorType = 2;
								}
							}
							else
							{
								this.ErrorType = 2;
								this.m_InfoRandSkillText.text = DataManager.Instance.mStringTable.GetStringByID(17099u);
							}
							this.m_InfoRandSkillText.enabled = true;
							this.m_SkillIconTf.gameObject.SetActive(false);
							this.m_InfoExpTf.gameObject.SetActive(true);
							this.m_InfoRandSkillText.alignment = TextAnchor.UpperLeft;
						}
						this.m_InfoRandSkillText.color = new Color(0.937f, 0.227f, 0.329f, 1f);
					}
					else if (b >= petData.Level)
					{
						this.m_CStr[14].ClearString();
						this.m_CStr[14].IntToFormat((long)petData.Level, 1, false);
						this.m_CStr[14].IntToFormat((long)b, 1, false);
						this.m_CStr[14].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17104u));
						this.m_InfoRandSkillText.text = this.m_CStr[14].ToString();
						this.m_InfoRandSkillText.SetAllDirty();
						this.m_InfoRandSkillText.cachedTextGenerator.Invalidate();
						this.m_InfoRandSkillText.enabled = true;
						this.m_InfoRandSkillText.alignment = TextAnchor.UpperCenter;
						this.m_SkillIconTf.gameObject.SetActive(false);
						this.m_InfoExpTf.gameObject.SetActive(true);
						if (b == petData.Level)
						{
							this.m_InfoRandSkillText.enabled = false;
						}
					}
					this.SetPetSkillcon(petData.ID);
					this.m_PetInfoOverTimeIcon.gameObject.SetActive(flag);
				}
				else
				{
					this.m_InfoExpTf.gameObject.SetActive(false);
				}
			}
			else
			{
				this.m_InfoExpTf.gameObject.SetActive(false);
			}
			this.m_InfoTransform[1].gameObject.SetActive(false);
			this.m_InfoTitleText2.enabled = false;
		}
		else
		{
			this.m_InfoTransform[0].gameObject.SetActive(false);
			this.m_InfoTransform[1].gameObject.SetActive(true);
			this.m_InfoTitleText.text = this.DM.mStringTable.GetStringByID(17101u);
			this.m_InfoTitleText2.text = this.DM.mStringTable.GetStringByID(17102u);
			this.m_InfoTitleText2.enabled = true;
		}
	}

	// Token: 0x06001751 RID: 5969 RVA: 0x00281DCC File Offset: 0x0027FFCC
	private void SetPetSkillcon(ushort petID)
	{
		byte b = 0;
		PetData petData = this.PetMgr.FindPetData(petID);
		if (petData != null)
		{
			b = petData.Enhance;
		}
		if (this.m_PetInfoSkillTf != null && petData.ID == petID)
		{
			for (int i = 0; i < this.m_PetInfoSkillTf.Length; i++)
			{
				if (petData.SkillID[i] > 0)
				{
					this.m_PetInfoSkillTf[i].gameObject.SetActive(true);
					this.m_PetInfoSkillIcon[i].sprite = this.PetMgr.LoadPetSkillIcon(petData.SkillID[i]);
					this.m_PetInfoSkillHint[i].Parm2 = petData.SkillLv[i];
					if (i <= (int)b)
					{
						this.m_PetInfoSkillBackImg[i].gameObject.SetActive(false);
						this.m_PetInfoSkillLcokImg[i].gameObject.SetActive(false);
					}
					else
					{
						this.m_PetInfoSkillBackImg[i].gameObject.SetActive(true);
						this.m_PetInfoSkillLcokImg[i].gameObject.SetActive(true);
					}
				}
				else
				{
					this.m_PetInfoSkillTf[i].gameObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x06001752 RID: 5970 RVA: 0x00281EF0 File Offset: 0x002800F0
	private void SetSelectCountPanel()
	{
		if (this.m_UIType == UIPetSelect.EUIType.Pet)
		{
			this.m_SelectCountTransform[1].gameObject.SetActive(false);
			this.SetPetColorCount();
			this.m_AutoSelectHeroBtn.gameObject.SetActive(true);
			this.m_SwitchHeroTypeBtn.gameObject.SetActive(true);
			this.m_PetHeroSelectBlack.enabled = false;
		}
		else
		{
			if (this.m_CoachHeroTime > 0u)
			{
				this.m_CStr[12].ClearString();
				UIPetSelect.GetTimeInfoString(this.m_CStr[12], this.m_CoachHeroTime * 60u, true);
				this.m_HeroInfoTime.text = this.m_CStr[12].ToString();
				this.m_HeroInfoTime.SetAllDirty();
				this.m_HeroInfoTime.cachedTextGenerator.Invalidate();
			}
			else
			{
				this.m_HeroInfoTime.text = this.DM.mStringTable.GetStringByID(17135u);
				this.m_HeroInfoTime.SetAllDirty();
				this.m_HeroInfoTime.cachedTextGenerator.Invalidate();
			}
			if (this.m_CoachHeroId != null)
			{
				ushort trainExpByHeroCount = this.PetMgr.GetTrainExpByHeroCount((ushort)this.m_CoachHeroId.Count, false);
				if (this.m_CoachHeroId.Count > 0)
				{
					this.m_CStr[13].ClearString();
					this.m_CStr[13].Append("+");
					this.m_CStr[13].IntToFormat((long)trainExpByHeroCount, 1, true);
					this.m_CStr[13].AppendFormat(this.DM.mStringTable.GetStringByID(17136u));
					this.m_HeroInfoExp.text = this.m_CStr[13].ToString();
					this.m_HeroInfoExp.SetAllDirty();
					this.m_HeroInfoExp.cachedTextGenerator.Invalidate();
				}
				else
				{
					this.m_HeroInfoExp.text = this.DM.mStringTable.GetStringByID(17135u);
					this.m_HeroInfoExp.SetAllDirty();
					this.m_HeroInfoExp.cachedTextGenerator.Invalidate();
				}
			}
			this.m_SelectCountTransform[1].gameObject.SetActive(true);
			this.SetHeroColorCount();
			this.m_AutoSelectHeroBtn.gameObject.SetActive(false);
			this.m_SwitchHeroTypeBtn.gameObject.SetActive(false);
			this.m_PetHeroSelectBlack.enabled = true;
		}
	}

	// Token: 0x06001753 RID: 5971 RVA: 0x00282144 File Offset: 0x00280344
	private void SetPetColorCount()
	{
		if (this.m_CoachHeroId.Count > 0)
		{
			this.m_HeroImage.gameObject.SetActive(false);
		}
		else
		{
			this.m_HeroImage.gameObject.SetActive(true);
		}
		this.m_SelectCountTransform[0].gameObject.SetActive(true);
		this.m_CStr[4].ClearString();
		this.m_CStr[4].IntToFormat((long)this.m_CoachHeroId.Count, 1, false);
		this.m_CStr[4].AppendFormat("{0}");
		this.m_HeroInfoCount.text = this.m_CStr[4].ToString();
		this.m_HeroInfoCount.SetAllDirty();
		this.m_HeroInfoCount.cachedTextGenerator.Invalidate();
		this.m_HeroInfoCount.transform.parent.gameObject.SetActive(this.m_CoachHeroId.Count > 0);
		float[] array = new float[]
		{
			279.8333f,
			325.8333f,
			371.8333f,
			417.8333f,
			463.8333f
		};
		byte b = 0;
		int num = this.m_ColorCount.Length - 1;
		while (num >= 0 && num < this.m_HeroInfoText.Length)
		{
			if (this.m_ColorCount[num] > 0)
			{
				this.m_CStr[7 + num].ClearString();
				this.m_CStr[7 + num].IntToFormat((long)this.m_ColorCount[num], 1, false);
				this.m_CStr[7 + num].AppendFormat("{0}");
				this.m_HeroInfoText[num].text = this.m_CStr[7 + num].ToString();
				this.m_HeroInfoText[num].SetAllDirty();
				this.m_HeroInfoText[num].cachedTextGenerator.Invalidate();
				RectTransform component = this.m_HeroInfoText[num].transform.parent.gameObject.GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(array[(int)b], component.anchoredPosition.y);
				b += 1;
				this.m_HeroInfoText[num].transform.parent.gameObject.SetActive(true);
			}
			else
			{
				this.m_HeroInfoText[num].transform.parent.gameObject.SetActive(false);
			}
			num--;
		}
	}

	// Token: 0x06001754 RID: 5972 RVA: 0x00282374 File Offset: 0x00280574
	private void SetHeroColorCount()
	{
		this.m_HeroImage.gameObject.SetActive(false);
		if (this.m_CoachHeroId.Count > 0)
		{
			this.m_SelectCountTransform[0].gameObject.SetActive(true);
			this.m_CStr[4].ClearString();
			this.m_CStr[4].IntToFormat((long)this.m_CoachHeroId.Count, 1, false);
			this.m_CStr[4].AppendFormat("{0}");
			this.m_HeroInfoCount.text = this.m_CStr[4].ToString();
			this.m_HeroInfoCount.SetAllDirty();
			this.m_HeroInfoCount.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.m_HeroInfoCount.text = DataManager.Instance.mStringTable.GetStringByID(17135u);
			this.m_HeroInfoCount.SetAllDirty();
			this.m_HeroInfoCount.cachedTextGenerator.Invalidate();
		}
		this.m_HeroInfoCount.transform.parent.gameObject.SetActive(true);
		float[] array = new float[]
		{
			279.8333f,
			325.8333f,
			371.8333f,
			417.8333f,
			463.8333f
		};
		byte b = 0;
		int num = this.m_ColorCount.Length - 1;
		while (num >= 0 && num < this.m_HeroInfoText.Length)
		{
			if (this.m_ColorCount[num] > 0)
			{
				this.m_CStr[7 + num].ClearString();
				this.m_CStr[7 + num].IntToFormat((long)this.m_ColorCount[num], 1, false);
				this.m_CStr[7 + num].AppendFormat("{0}");
				this.m_HeroInfoText[num].text = this.m_CStr[7 + num].ToString();
				this.m_HeroInfoText[num].SetAllDirty();
				this.m_HeroInfoText[num].cachedTextGenerator.Invalidate();
				RectTransform component = this.m_HeroInfoText[num].transform.parent.gameObject.GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(array[(int)b], component.anchoredPosition.y);
				b += 1;
				this.m_HeroInfoText[num].transform.parent.gameObject.SetActive(true);
			}
			else
			{
				this.m_HeroInfoText[num].transform.parent.gameObject.SetActive(false);
			}
			num--;
		}
	}

	// Token: 0x06001755 RID: 5973 RVA: 0x002825C0 File Offset: 0x002807C0
	private void RequestPetTrainingBegin()
	{
		ushort id = this.m_PetSelect.m_ID;
		if (this.ErrorType == 1)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17140u), 35, true);
		}
		else if (id == 0)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17098u), 35, true);
		}
		else if (this.m_CoachHeroId.Count == 0 && this.m_CanSelectHeroCount > 0)
		{
			GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(614u), DataManager.Instance.mStringTable.GetStringByID(17144u), 1, 0, null, null);
		}
		else if (this.ErrorType == 2)
		{
			GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(614u), DataManager.Instance.mStringTable.GetStringByID(17143u), 0, 0, null, null);
		}
		else
		{
			this.PetMgr.RequestPetTrainingBegin(this.m_TrainingSetIdx, id, this.m_CoachHeroId);
		}
	}

	// Token: 0x06001756 RID: 5974 RVA: 0x002826F0 File Offset: 0x002808F0
	private void AutoSelectHero()
	{
		this.m_CoachHeroId.Clear();
		byte b = 0;
		while ((int)b < this.m_HeroScrollData.Count)
		{
			if (this.m_HeroScrollData[(int)b].HasInstance)
			{
				for (int i = 0; i < 2; i++)
				{
					if (!this.m_HeroScrollData[(int)b].CheckIconType((UIPetSelect.EItemIdx)i, UIPetSelect.EIconType.Training) && !this.m_HeroScrollData[(int)b].CheckIconType((UIPetSelect.EItemIdx)i, UIPetSelect.EIconType.Select) && !this.m_HeroScrollData[(int)b].CheckIconType((UIPetSelect.EItemIdx)i, UIPetSelect.EIconType.LockLimit) && !this.m_HeroScrollData[(int)b].CheckIconType((UIPetSelect.EItemIdx)i, UIPetSelect.EIconType.Lock) && this.m_HeroScrollData[(int)b].m_ID[i] != 0 && !this.m_HeroScrollData[(int)b].bLineType)
					{
						if ((int)this.m_HeroScrollData[(int)b].m_Color[i] < this.m_ColorCount.Length)
						{
							byte[] colorCount = this.m_ColorCount;
							byte b2 = this.m_HeroScrollData[(int)b].m_Color[i];
							colorCount[(int)b2] = colorCount[(int)b2] + 1;
						}
						this.m_HeroScrollData[(int)b].OnSelect((UIPetSelect.EItemIdx)i, b);
						this.m_CoachHeroId.Add(this.m_HeroScrollData[(int)b].m_ID[i]);
						this.m_CoachHeroTime += this.m_HeroScrollData[(int)b].m_TrainTime[i];
					}
				}
			}
			b += 1;
		}
		if (this.m_UIType == UIPetSelect.EUIType.Hero)
		{
			for (int j = 0; j < this.m_RankSelect.Length; j++)
			{
				this.m_RankSelect[j].enabled = true;
			}
		}
		if (this.m_CoachHeroId.Count != 0)
		{
			this.UpdateScrollPanel(false, false);
			this.SetAutoBtnState(UIPetSelect.EAutoState.ClearnState);
			this.SetInfoPanel();
			this.SetSelectCountPanel();
		}
		else
		{
			GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(17137u), 35, true);
		}
	}

	// Token: 0x06001757 RID: 5975 RVA: 0x002828F8 File Offset: 0x00280AF8
	private void ClearAutoSelect()
	{
		this.m_CoachHeroId.Clear();
		this.m_CoachHeroTime = 0u;
		Array.Clear(this.m_ColorCount, 0, this.m_ColorCount.Length);
		for (int i = 0; i < this.m_ColorCount.Length; i++)
		{
			this.m_ColorCount[i] = 0;
		}
		byte b = 0;
		while ((int)b < this.m_HeroScrollData.Count)
		{
			if (this.m_HeroScrollData[(int)b].HasInstance)
			{
				for (int j = 0; j < 2; j++)
				{
					this.m_HeroScrollData[(int)b].RemoveIcon((UIPetSelect.EItemIdx)j, UIPetSelect.EIconType.Select);
					this.m_CoachHeroId.Remove(this.m_HeroScrollData[(int)b].m_ID[j]);
				}
			}
			b += 1;
		}
		this.UpdateScrollPanel(false, false);
		this.SetAutoBtnState(UIPetSelect.EAutoState.AutoState);
		this.SetInfoPanel();
		this.SetSelectCountPanel();
	}

	// Token: 0x06001758 RID: 5976 RVA: 0x002829E0 File Offset: 0x00280BE0
	private void SetAutoBtnState(UIPetSelect.EAutoState state)
	{
		this.m_AutoState = state;
		if (this.m_AutoState == UIPetSelect.EAutoState.AutoState)
		{
			this.m_AutoSelectText[0].text = DataManager.Instance.mStringTable.GetStringByID(824u);
			this.m_AutoSelectText[1].text = DataManager.Instance.mStringTable.GetStringByID(824u);
		}
		else if (this.m_AutoState == UIPetSelect.EAutoState.ClearnState)
		{
			this.m_AutoSelectText[0].text = DataManager.Instance.mStringTable.GetStringByID(825u);
			this.m_AutoSelectText[1].text = DataManager.Instance.mStringTable.GetStringByID(825u);
		}
	}

	// Token: 0x06001759 RID: 5977 RVA: 0x00282A94 File Offset: 0x00280C94
	private void InitScorllPanel()
	{
		if (!this.bInitScroll)
		{
			List<float> list = new List<float>();
			for (int i = 0; i < this.m_PetScrollData.Count; i++)
			{
				if (this.m_PetScrollData[i].bDataPadding)
				{
					if (this.m_PetScrollData[i].bLineType)
					{
						list.Add(30f);
					}
					else
					{
						list.Add(80f);
					}
				}
			}
			if (this.m_ScrollPanel != null)
			{
				this.m_ScrollPanel.IntiScrollPanel(403f, 10f, 6f, list, 7, this);
			}
			this.bInitScroll = true;
		}
	}

	// Token: 0x0600175A RID: 5978 RVA: 0x00282B4C File Offset: 0x00280D4C
	private void UpdateScrollPanel(bool IsSetBeginPos = true, bool bUsePos = false)
	{
		if (this.m_ScrollPanel == null && !this.bInitScroll)
		{
			return;
		}
		List<float> list = new List<float>();
		List<UIPetSelect.SScrollData> list2;
		if (this.m_UIType == UIPetSelect.EUIType.Pet)
		{
			list2 = this.m_PetScrollData;
		}
		else
		{
			list2 = this.m_HeroScrollData;
		}
		for (int i = 0; i < list2.Count; i++)
		{
			if (list2[i].bDataPadding)
			{
				if (list2[i].bLineType)
				{
					list.Add(50f);
				}
				else
				{
					list.Add(80f);
				}
			}
		}
		this.m_ScrollPanel.AddNewDataHeight(list, IsSetBeginPos, true);
		if (bUsePos)
		{
			this.m_ScrollPanel.GoTo(this.m_ScrollIdx[(int)this.m_UIType], this.m_ScrollPosY[(int)this.m_UIType]);
		}
	}

	// Token: 0x0600175B RID: 5979 RVA: 0x00282C28 File Offset: 0x00280E28
	private void InitScrollItem(GameObject item, int panelObjectIdx)
	{
		if (panelObjectIdx < this.m_ScrollObjects.Length)
		{
			Transform child = item.transform.GetChild(0);
			Transform child2 = item.transform.GetChild(1);
			Transform child3 = item.transform.GetChild(2);
			Transform[] array = new Transform[2];
			UIButton[] array2 = new UIButton[2];
			UIHIBtn[] array3 = new UIHIBtn[2];
			UIText[] array4 = new UIText[2];
			UIText[] array5 = new UIText[2];
			Image[] array6 = new Image[2];
			Image[] array7 = new Image[2];
			Image[][] array8 = new Image[][]
			{
				new Image[3],
				new Image[3]
			};
			UIButton[] array9 = new UIButton[2];
			Transform[] array10 = new Transform[2];
			UIHIBtn[] array11 = new UIHIBtn[2];
			UIText[] array12 = new UIText[2];
			Image[] array13 = new Image[2];
			Image[][] array14 = new Image[][]
			{
				new Image[3],
				new Image[3]
			};
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = child.GetChild(i);
			}
			for (int j = 0; j < 2; j++)
			{
				array2[j] = array[j].GetComponent<UIButton>();
				array2[j].m_BtnID1 = 3;
				array2[j].m_Handler = this;
				array3[j] = array[j].GetChild(0).GetComponent<UIHIBtn>();
				array4[j] = array[j].GetChild(1).GetComponent<UIText>();
				array4[j].font = GUIManager.Instance.GetTTFFont();
				array6[j] = array[j].GetChild(2).GetChild(0).GetComponent<Image>();
				array5[j] = array[j].GetChild(2).GetChild(1).GetComponent<UIText>();
				array5[j].font = GUIManager.Instance.GetTTFFont();
				array7[j] = array[j].GetChild(3).GetComponent<Image>();
				array8[j][0] = array[j].GetChild(4).GetComponent<Image>();
				array8[j][1] = array[j].GetChild(5).GetComponent<Image>();
				array8[j][2] = array[j].GetChild(6).GetComponent<Image>();
				array8[j][2].gameObject.AddComponent<ArabicItemTextureRot>();
			}
			for (int k = 0; k < array10.Length; k++)
			{
				array10[k] = child2.GetChild(k);
			}
			for (int l = 0; l < 2; l++)
			{
				array9[l] = array10[l].GetComponent<UIButton>();
				array9[l].m_BtnID1 = 3;
				array9[l].m_Handler = this;
				array11[l] = array10[l].GetChild(0).GetComponent<UIHIBtn>();
				array12[l] = array10[l].GetChild(1).GetChild(0).GetComponent<UIText>();
				array12[l].font = GUIManager.Instance.GetTTFFont();
				array13[l] = array10[l].GetChild(2).GetComponent<Image>();
				array14[l][0] = array10[l].GetChild(3).GetComponent<Image>();
				array14[l][1] = array10[l].GetChild(4).GetComponent<Image>();
				array14[l][2] = array10[l].GetChild(5).GetComponent<Image>();
				array14[l][2].gameObject.AddComponent<ArabicItemTextureRot>();
			}
			UIText component = child3.GetChild(0).GetComponent<UIText>();
			component.font = GUIManager.Instance.GetTTFFont();
			this.m_ScrollObjects[panelObjectIdx] = new UIPetSelect.SSrollPanelItem(UIPetSelect.SSrollPanelItem.EItemType.PetType, this.m_Sp);
			this.m_ScrollObjects[panelObjectIdx].m_PetItem.Init(child, array, array2, array3, array4, array5, array6, array7, array8);
			this.m_ScrollObjects[panelObjectIdx].m_LineItem.Init(child3, component);
			this.m_ScrollObjects[panelObjectIdx].m_HeroItem.Init(child2, array10, array9, array11, array12, array13, array14);
		}
	}

	// Token: 0x0600175C RID: 5980 RVA: 0x00283000 File Offset: 0x00281200
	private void UpdateScrollItem(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (panelObjectIdx < 7)
		{
			if (this.m_UIType == UIPetSelect.EUIType.Pet)
			{
				if (dataIdx >= 0 && dataIdx < this.m_PetScrollData.Count)
				{
					this.UpdateScrollItemPet(dataIdx, panelObjectIdx);
				}
			}
			else if (dataIdx >= 0 && dataIdx < this.m_HeroScrollData.Count)
			{
				this.UpdateScrollItemHero(dataIdx, panelObjectIdx);
			}
		}
	}

	// Token: 0x0600175D RID: 5981 RVA: 0x00283064 File Offset: 0x00281264
	private void UpdateScrollItemPet(int dataIdx, int panelObjectIdx)
	{
		if (this.m_ScrollObjects[panelObjectIdx].m_PetItem.HasInstance)
		{
			UIPetSelect.SScrollData sscrollData = this.m_PetScrollData[dataIdx];
			if (sscrollData.m_ID != null && sscrollData.m_DataIdx != null && sscrollData.m_EIconType != null)
			{
				PetData petData = PetManager.Instance.GetPetData((int)((byte)sscrollData.m_DataIdx[0]));
				PetData petData2 = PetManager.Instance.GetPetData((int)((byte)sscrollData.m_DataIdx[1]));
				if (sscrollData.bLineType)
				{
					this.m_ScrollObjects[panelObjectIdx].SetType(UIPetSelect.SSrollPanelItem.EItemType.LineType, true);
				}
				else
				{
					this.m_ScrollObjects[panelObjectIdx].SetType(UIPetSelect.SSrollPanelItem.EItemType.PetType, true);
					if (petData != null && petData2 != null)
					{
						this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetBtnID(UIPetSelect.EItemIdx.Left, dataIdx, panelObjectIdx);
						this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetBtnID(UIPetSelect.EItemIdx.Right, dataIdx, panelObjectIdx);
						this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetHiBtn(UIPetSelect.EItemIdx.Left, petData.ID, petData.Enhance, petData.Rare, (int)petData.Level);
						this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetHiBtn(UIPetSelect.EItemIdx.Right, petData2.ID, petData2.Enhance, petData2.Rare, (int)petData2.Level);
						uint needExp = this.PetMgr.GetNeedExp(petData.Level, petData.Rare);
						uint needExp2 = this.PetMgr.GetNeedExp(petData2.Level, petData2.Rare);
						byte maxLevel = petData.GetMaxLevel(true);
						byte maxLevel2 = petData2.GetMaxLevel(true);
						this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetSlider(UIPetSelect.EItemIdx.Left, petData.Exp, needExp, petData.Level, maxLevel);
						this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetSlider(UIPetSelect.EItemIdx.Right, petData2.Exp, needExp2, petData2.Level, maxLevel2);
						this.m_ScrollObjects[panelObjectIdx].m_PetItem.ClearIcon(UIPetSelect.EItemIdx.Left);
						this.m_ScrollObjects[panelObjectIdx].m_PetItem.ClearIcon(UIPetSelect.EItemIdx.Right);
						this.m_ScrollObjects[panelObjectIdx].m_PetItem.AddIcon(UIPetSelect.EItemIdx.Left, sscrollData.m_EIconType[0]);
						this.m_ScrollObjects[panelObjectIdx].m_PetItem.AddIcon(UIPetSelect.EItemIdx.Right, sscrollData.m_EIconType[1]);
						this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetName(UIPetSelect.EItemIdx.Left, petData.ID);
						this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetName(UIPetSelect.EItemIdx.Right, petData2.ID);
						if (sscrollData.bShowOnlyLeft)
						{
							this.m_ScrollObjects[panelObjectIdx].m_PetItem.OnlyShowLeft(sscrollData.bShowOnlyLeft);
						}
					}
					else
					{
						Debug.Log("dataIdx " + dataIdx + "is Null");
					}
				}
			}
		}
	}

	// Token: 0x0600175E RID: 5982 RVA: 0x00283330 File Offset: 0x00281530
	private void UpdateScrollItemHero(int dataIdx, int panelObjectIdx)
	{
		if (this.m_ScrollObjects[panelObjectIdx].m_HeroItem.HasInstance)
		{
			UIPetSelect.SScrollData sscrollData = this.m_HeroScrollData[dataIdx];
			if (sscrollData.m_ID != null && sscrollData.m_DataIdx != null && sscrollData.m_EIconType != null)
			{
				if (sscrollData.bLineType)
				{
					this.m_ScrollObjects[panelObjectIdx].SetType(UIPetSelect.SSrollPanelItem.EItemType.LineType, false);
				}
				else
				{
					this.m_ScrollObjects[panelObjectIdx].SetType(UIPetSelect.SSrollPanelItem.EItemType.HeroType, false);
					this.m_ScrollObjects[panelObjectIdx].m_HeroItem.SetBtnID(UIPetSelect.EItemIdx.Left, dataIdx, panelObjectIdx);
					this.m_ScrollObjects[panelObjectIdx].m_HeroItem.SetBtnID(UIPetSelect.EItemIdx.Right, dataIdx, panelObjectIdx);
					if (!sscrollData.bShowOnlyLeft)
					{
						if (!this.DM.curHeroData.ContainsKey((uint)sscrollData.m_DataIdx[1]))
						{
							return;
						}
						CurHeroData curHeroData = this.DM.curHeroData[(uint)sscrollData.m_DataIdx[1]];
						this.m_ScrollObjects[panelObjectIdx].m_HeroItem.SetHiBtn(UIPetSelect.EItemIdx.Right, curHeroData.ID, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
					}
					else
					{
						this.m_ScrollObjects[panelObjectIdx].m_HeroItem.OnlyShowLeft(true);
					}
					if (!this.DM.curHeroData.ContainsKey((uint)sscrollData.m_DataIdx[0]))
					{
						return;
					}
					CurHeroData curHeroData2 = this.DM.curHeroData[(uint)sscrollData.m_DataIdx[0]];
					this.m_ScrollObjects[panelObjectIdx].m_HeroItem.SetHiBtn(UIPetSelect.EItemIdx.Left, curHeroData2.ID, curHeroData2.Star, curHeroData2.Enhance, (int)curHeroData2.Level);
					this.m_ScrollObjects[panelObjectIdx].m_HeroItem.SetTrainTime(UIPetSelect.EItemIdx.Left, sscrollData.m_TrainTime[0]);
					this.m_ScrollObjects[panelObjectIdx].m_HeroItem.SetTrainTime(UIPetSelect.EItemIdx.Right, sscrollData.m_TrainTime[1]);
					this.m_ScrollObjects[panelObjectIdx].m_HeroItem.ClearIcon(UIPetSelect.EItemIdx.Left);
					this.m_ScrollObjects[panelObjectIdx].m_HeroItem.ClearIcon(UIPetSelect.EItemIdx.Right);
					this.m_ScrollObjects[panelObjectIdx].m_HeroItem.AddIcon(UIPetSelect.EItemIdx.Left, sscrollData.m_EIconType[0]);
					this.m_ScrollObjects[panelObjectIdx].m_HeroItem.AddIcon(UIPetSelect.EItemIdx.Right, sscrollData.m_EIconType[1]);
					if (sscrollData.bShowOnlyLeft)
					{
						this.m_ScrollObjects[panelObjectIdx].m_HeroItem.OnlyShowLeft(sscrollData.bShowOnlyLeft);
					}
				}
			}
		}
	}

	// Token: 0x0600175F RID: 5983 RVA: 0x002835BC File Offset: 0x002817BC
	public void SpawnCStr()
	{
		this.m_CStr = new CString[16];
		for (int i = 0; i < this.m_CStr.Length; i++)
		{
			this.m_CStr[i] = StringManager.Instance.SpawnString(100);
		}
	}

	// Token: 0x06001760 RID: 5984 RVA: 0x00283604 File Offset: 0x00281804
	public void DeSpawnCStr()
	{
		if (this.m_CStr != null)
		{
			for (int i = 0; i < this.m_CStr.Length; i++)
			{
				if (this.m_CStr[i] != null)
				{
					StringManager.Instance.DeSpawnString(this.m_CStr[i]);
					this.m_CStr[i] = null;
				}
			}
		}
		for (int j = 0; j < 7; j++)
		{
			if (this.m_ScrollObjects[j].m_HeroItem.HasInstance)
			{
				this.m_ScrollObjects[j].m_HeroItem.DeSpawn();
				this.m_ScrollObjects[j].m_PetItem.DeSpawn();
			}
		}
	}

	// Token: 0x06001761 RID: 5985 RVA: 0x002836B8 File Offset: 0x002818B8
	public void DeSpawnPetData()
	{
		for (int i = 0; i < this.m_PetScrollData.Count; i++)
		{
			this.m_PetScrollData[i].Empty();
			this.PetMgr.m_PetSelectPool.despawn(this.m_PetScrollData[i]);
		}
		this.m_PetScrollData.Clear();
	}

	// Token: 0x06001762 RID: 5986 RVA: 0x0028371C File Offset: 0x0028191C
	public void DeSpawnHeroData()
	{
		for (int i = 0; i < this.m_HeroScrollData.Count; i++)
		{
			this.m_HeroScrollData[i].Empty();
			this.PetMgr.m_HeroSelectPool.despawn(this.m_HeroScrollData[i]);
		}
		this.m_HeroScrollData.Clear();
	}

	// Token: 0x06001763 RID: 5987 RVA: 0x00283780 File Offset: 0x00281980
	private void RefreshFontTexture()
	{
		for (int i = 0; i < 7; i++)
		{
			if (this.m_ScrollObjects[i].m_HeroItem.HasInstance)
			{
				if (this.m_ScrollObjects[i].m_HeroItem.HasInstance)
				{
					this.m_ScrollObjects[i].m_HeroItem.RefreshFontTexture();
				}
				if (this.m_ScrollObjects[i].m_PetItem.HasInstance)
				{
					this.m_ScrollObjects[i].m_PetItem.RefreshFontTexture();
				}
				if (this.m_ScrollObjects[i].m_LineItem.HasInstance)
				{
					this.m_ScrollObjects[i].m_LineItem.RefreshFontTexture();
				}
			}
		}
		if (this.m_InfoTitleText != null && this.m_InfoTitleText.enabled)
		{
			this.m_InfoTitleText.enabled = false;
			this.m_InfoTitleText.enabled = true;
		}
		if (this.m_InfoTitleText2 != null && this.m_InfoTitleText2.enabled)
		{
			this.m_InfoTitleText2.enabled = false;
			this.m_InfoTitleText2.enabled = true;
		}
		if (this.m_InfoRandSkillText != null && this.m_InfoRandSkillText.enabled)
		{
			this.m_InfoRandSkillText.enabled = false;
			this.m_InfoRandSkillText.enabled = true;
		}
		if (this.m_InfoRandSkillText2 != null && this.m_InfoRandSkillText2.enabled)
		{
			this.m_InfoRandSkillText2.enabled = false;
			this.m_InfoRandSkillText2.enabled = true;
		}
		if (this.m_LvText != null && this.m_LvText.enabled)
		{
			this.m_LvText.enabled = false;
			this.m_LvText.enabled = true;
		}
		for (int j = 0; j < this.m_PetInfoText.Length; j++)
		{
			if (this.m_PetInfoText[j] != null && this.m_PetInfoText[j].enabled)
			{
				this.m_PetInfoText[j].enabled = false;
				this.m_PetInfoText[j].enabled = true;
			}
		}
		if (this.m_HeroInfoExp != null && this.m_HeroInfoExp.enabled)
		{
			this.m_HeroInfoExp.enabled = false;
			this.m_HeroInfoExp.enabled = true;
		}
		if (this.m_HeroInfoTime != null && this.m_HeroInfoTime.enabled)
		{
			this.m_HeroInfoTime.enabled = false;
			this.m_HeroInfoTime.enabled = true;
		}
		if (this.m_HeroInfoCount != null && this.m_HeroInfoCount.enabled)
		{
			this.m_HeroInfoCount.enabled = false;
			this.m_HeroInfoCount.enabled = true;
		}
		for (int k = 0; k < this.m_HeroInfoText.Length; k++)
		{
			if (this.m_HeroInfoText[k] != null && this.m_HeroInfoText[k].enabled)
			{
				this.m_HeroInfoText[k].enabled = false;
				this.m_HeroInfoText[k].enabled = true;
			}
		}
		for (int l = 0; l < this.m_AutoSelectText.Length; l++)
		{
			if (this.m_AutoSelectText != null && this.m_AutoSelectText[l] != null && this.m_AutoSelectText[l].enabled)
			{
				this.m_AutoSelectText[l].enabled = false;
				this.m_AutoSelectText[l].enabled = true;
			}
		}
		if (this.m_OKTExt != null && this.m_OKTExt.enabled)
		{
			this.m_OKTExt.enabled = false;
			this.m_OKTExt.enabled = true;
		}
	}

	// Token: 0x06001764 RID: 5988 RVA: 0x00283B68 File Offset: 0x00281D68
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
			if (num > 0u)
			{
				if (num % 60u == 0u)
				{
					CStr.IntToFormat((long)(num / 60u), 1, false);
				}
				else
				{
					CStr.IntToFormat((long)(num / 60u + 1u), 1, false);
				}
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
			if (num > 0u)
			{
				if (num % 60u == 0u)
				{
					CStr.IntToFormat((long)(num / 60u), 1, false);
				}
				else
				{
					CStr.IntToFormat((long)(num / 60u + 1u), 1, false);
				}
				CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17133u));
			}
		}
	}

	// Token: 0x06001765 RID: 5989 RVA: 0x00283CF8 File Offset: 0x00281EF8
	private uint GetMaxLevelExp(ushort petID, byte nowLv, uint nowExp, byte maxLv)
	{
		PetData petData = this.PetMgr.FindPetData(petID);
		if (petData != null)
		{
			PetTbl recordByKey = this.PetMgr.PetTable.GetRecordByKey(petID);
			uint num = 0u;
			maxLv = (byte)Mathf.Clamp((int)maxLv, 2, 59);
			for (byte b = nowLv; b <= maxLv; b += 1)
			{
				num += this.PetMgr.GetNeedExp(b, recordByKey.Rare);
			}
			num -= nowExp;
			if (petData != null)
			{
				byte maxLevel = petData.GetMaxLevel(true);
				if (maxLevel == maxLv && maxLv != 60)
				{
					num -= 1u;
				}
			}
			return num;
		}
		return 0u;
	}

	// Token: 0x06001766 RID: 5990 RVA: 0x00283D90 File Offset: 0x00281F90
	private uint GetCanTrainTime(uint MaxLevelExp, uint totalExp, uint nowTime)
	{
		if (MaxLevelExp >= totalExp)
		{
			return nowTime;
		}
		double expPerMinute = this.GetExpPerMinute();
		if (expPerMinute > 0.0)
		{
			uint num = (uint)(MaxLevelExp / expPerMinute * 60.0);
			return (uint)Mathf.Clamp(num, 1f, num);
		}
		return 0u;
	}

	// Token: 0x0400458A RID: 17802
	private const int PANEL_OBJECT_COUNT = 7;

	// Token: 0x0400458B RID: 17803
	private int SCROLL_DATA_COUNT;

	// Token: 0x0400458C RID: 17804
	private UIPetSelect.SSrollPanelItem[] m_ScrollObjects = new UIPetSelect.SSrollPanelItem[7];

	// Token: 0x0400458D RID: 17805
	private bool bInitScroll;

	// Token: 0x0400458E RID: 17806
	private byte PetIdelCount;

	// Token: 0x0400458F RID: 17807
	private byte HeroIdleCount;

	// Token: 0x04004590 RID: 17808
	private UIPetSelect.EUIType m_UIType;

	// Token: 0x04004591 RID: 17809
	private List<UIPetSelect.SScrollData> m_PetScrollData;

	// Token: 0x04004592 RID: 17810
	private List<UIPetSelect.SScrollData> m_HeroScrollData;

	// Token: 0x04004593 RID: 17811
	private PetManager PetMgr;

	// Token: 0x04004594 RID: 17812
	private DataManager DM;

	// Token: 0x04004595 RID: 17813
	private Door door;

	// Token: 0x04004596 RID: 17814
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04004597 RID: 17815
	private Transform[] m_SelectCountTransform;

	// Token: 0x04004598 RID: 17816
	private Transform[] m_InfoTransform;

	// Token: 0x04004599 RID: 17817
	private Transform m_InfoExpTf;

	// Token: 0x0400459A RID: 17818
	private Transform m_SkillIconTf;

	// Token: 0x0400459B RID: 17819
	private UIHIBtn m_PetHiBtn;

	// Token: 0x0400459C RID: 17820
	private UIText m_InfoTitleText;

	// Token: 0x0400459D RID: 17821
	private UIText m_InfoTitleText2;

	// Token: 0x0400459E RID: 17822
	private UIText m_InfoRandSkillText;

	// Token: 0x0400459F RID: 17823
	private UIText m_InfoRandSkillText2;

	// Token: 0x040045A0 RID: 17824
	private UIText m_LvText;

	// Token: 0x040045A1 RID: 17825
	private UIText[] m_PetInfoText;

	// Token: 0x040045A2 RID: 17826
	private UIText m_HeroInfoCount;

	// Token: 0x040045A3 RID: 17827
	private UIText[] m_HeroInfoText;

	// Token: 0x040045A4 RID: 17828
	private UIText m_HeroInfoExp;

	// Token: 0x040045A5 RID: 17829
	private UIText m_HeroInfoTime;

	// Token: 0x040045A6 RID: 17830
	private UIText[] m_AutoSelectText;

	// Token: 0x040045A7 RID: 17831
	private UIText m_OKTExt;

	// Token: 0x040045A8 RID: 17832
	private UIText m_HeroImageText;

	// Token: 0x040045A9 RID: 17833
	private Image m_PetHeroSelectBlack;

	// Token: 0x040045AA RID: 17834
	private Image m_PetInfoExp;

	// Token: 0x040045AB RID: 17835
	private Image m_PetInfoDeltaExp;

	// Token: 0x040045AC RID: 17836
	private Image m_SelectEffect;

	// Token: 0x040045AD RID: 17837
	private Image m_HeroImage;

	// Token: 0x040045AE RID: 17838
	private Image[] m_RankSelect;

	// Token: 0x040045AF RID: 17839
	private Image[] m_PetInfoSkillIcon;

	// Token: 0x040045B0 RID: 17840
	private Image[] m_PetInfoSkillLcokImg;

	// Token: 0x040045B1 RID: 17841
	private Image[] m_PetInfoSkillBackImg;

	// Token: 0x040045B2 RID: 17842
	private Image m_PetInfoOverTimeIcon;

	// Token: 0x040045B3 RID: 17843
	private UIButtonHint[] m_PetInfoSkillHint;

	// Token: 0x040045B4 RID: 17844
	private Transform[] m_PetInfoSkillTf;

	// Token: 0x040045B5 RID: 17845
	private UIButton m_AutoSelectHeroBtn;

	// Token: 0x040045B6 RID: 17846
	private UIButton m_SwitchHeroTypeBtn;

	// Token: 0x040045B7 RID: 17847
	private CString[] m_CStr;

	// Token: 0x040045B8 RID: 17848
	private int[] m_ScrollIdx;

	// Token: 0x040045B9 RID: 17849
	private float[] m_ScrollPosY;

	// Token: 0x040045BA RID: 17850
	private byte m_TrainingSetIdx;

	// Token: 0x040045BB RID: 17851
	private List<ushort> m_CoachHeroId;

	// Token: 0x040045BC RID: 17852
	private uint m_CoachHeroTime;

	// Token: 0x040045BD RID: 17853
	private byte[] m_ColorCount;

	// Token: 0x040045BE RID: 17854
	private ushort m_CanSelectHeroCount;

	// Token: 0x040045BF RID: 17855
	private UIPetSelect.EAutoState m_AutoState;

	// Token: 0x040045C0 RID: 17856
	private bool bShowSelectEffect;

	// Token: 0x040045C1 RID: 17857
	private float m_SelectEffectAlpha;

	// Token: 0x040045C2 RID: 17858
	private float m_SelectTime;

	// Token: 0x040045C3 RID: 17859
	private float[] m_RanSelectTime;

	// Token: 0x040045C4 RID: 17860
	private float[] m_RanSelectAlpha;

	// Token: 0x040045C5 RID: 17861
	private float m_SliderEffectAlpha;

	// Token: 0x040045C6 RID: 17862
	private float m_SliderTime;

	// Token: 0x040045C7 RID: 17863
	private UIPetSelect.ESelectItem m_PetSelect = new UIPetSelect.ESelectItem(UIPetSelect.EItemIdx.Left);

	// Token: 0x040045C8 RID: 17864
	private byte ErrorType;

	// Token: 0x040045C9 RID: 17865
	private UISpritesArray m_Sp;

	// Token: 0x0200047D RID: 1149
	private enum EAutoState
	{
		// Token: 0x040045CB RID: 17867
		AutoState,
		// Token: 0x040045CC RID: 17868
		ClearnState
	}

	// Token: 0x0200047E RID: 1150
	private enum ECStrID
	{
		// Token: 0x040045CE RID: 17870
		PetInfoLv,
		// Token: 0x040045CF RID: 17871
		PetInfoExpAddition,
		// Token: 0x040045D0 RID: 17872
		PetInfoHeroExp,
		// Token: 0x040045D1 RID: 17873
		PetInfoHeroTime,
		// Token: 0x040045D2 RID: 17874
		HeroInfoHeroNum,
		// Token: 0x040045D3 RID: 17875
		HeroInfoHeroExp,
		// Token: 0x040045D4 RID: 17876
		HeroInfoHeroTime,
		// Token: 0x040045D5 RID: 17877
		HeroInfoText1,
		// Token: 0x040045D6 RID: 17878
		HeroInfoText2,
		// Token: 0x040045D7 RID: 17879
		HeroInfoText3,
		// Token: 0x040045D8 RID: 17880
		HeroInfoText4,
		// Token: 0x040045D9 RID: 17881
		HeroInfoText5,
		// Token: 0x040045DA RID: 17882
		HeroSelectTime,
		// Token: 0x040045DB RID: 17883
		HeroSelectExp,
		// Token: 0x040045DC RID: 17884
		PetInfoLvUp,
		// Token: 0x040045DD RID: 17885
		PetInfoLvUp2,
		// Token: 0x040045DE RID: 17886
		Max
	}

	// Token: 0x0200047F RID: 1151
	private enum EUIType
	{
		// Token: 0x040045E0 RID: 17888
		Pet,
		// Token: 0x040045E1 RID: 17889
		Hero,
		// Token: 0x040045E2 RID: 17890
		Max
	}

	// Token: 0x02000480 RID: 1152
	private enum EPetSelect
	{
		// Token: 0x040045E4 RID: 17892
		BgPanel,
		// Token: 0x040045E5 RID: 17893
		SelectCountPanel,
		// Token: 0x040045E6 RID: 17894
		ScrollPanel,
		// Token: 0x040045E7 RID: 17895
		Item,
		// Token: 0x040045E8 RID: 17896
		InfoPanel,
		// Token: 0x040045E9 RID: 17897
		ExiteBtn
	}

	// Token: 0x02000481 RID: 1153
	private enum EBtnID
	{
		// Token: 0x040045EB RID: 17899
		SwitchHeroType,
		// Token: 0x040045EC RID: 17900
		AutoSelectHero,
		// Token: 0x040045ED RID: 17901
		OK,
		// Token: 0x040045EE RID: 17902
		ItemSelect,
		// Token: 0x040045EF RID: 17903
		ExitBtn,
		// Token: 0x040045F0 RID: 17904
		ExpHint,
		// Token: 0x040045F1 RID: 17905
		TimeHint,
		// Token: 0x040045F2 RID: 17906
		HeroSelectLeft,
		// Token: 0x040045F3 RID: 17907
		HeroSelectRight,
		// Token: 0x040045F4 RID: 17908
		SkillIconHint,
		// Token: 0x040045F5 RID: 17909
		PetInfoSkillHint1,
		// Token: 0x040045F6 RID: 17910
		PetInfoSkillHint2,
		// Token: 0x040045F7 RID: 17911
		PetInfoSkillHint3,
		// Token: 0x040045F8 RID: 17912
		PetInfoOverTime
	}

	// Token: 0x02000482 RID: 1154
	private enum EMsgBox
	{
		// Token: 0x040045FA RID: 17914
		OverTimer,
		// Token: 0x040045FB RID: 17915
		NoSelectHero,
		// Token: 0x040045FC RID: 17916
		NeedEvo
	}

	// Token: 0x02000483 RID: 1155
	public enum EItemIdx
	{
		// Token: 0x040045FE RID: 17918
		Left,
		// Token: 0x040045FF RID: 17919
		Right,
		// Token: 0x04004600 RID: 17920
		Max
	}

	// Token: 0x02000484 RID: 1156
	public enum EIconType
	{
		// Token: 0x04004602 RID: 17922
		None,
		// Token: 0x04004603 RID: 17923
		Lock,
		// Token: 0x04004604 RID: 17924
		Training,
		// Token: 0x04004605 RID: 17925
		Select = 4,
		// Token: 0x04004606 RID: 17926
		LockLimit = 8
	}

	// Token: 0x02000485 RID: 1157
	public struct ESelectItem
	{
		// Token: 0x06001767 RID: 5991 RVA: 0x00283DE4 File Offset: 0x00281FE4
		public ESelectItem(UIPetSelect.EItemIdx idx)
		{
			this.m_DataIdx = byte.MaxValue;
			this.m_ItemIdx = idx;
			this.m_ID = 0;
		}

		// Token: 0x04004607 RID: 17927
		public const byte NoneSelect = 255;

		// Token: 0x04004608 RID: 17928
		public byte m_DataIdx;

		// Token: 0x04004609 RID: 17929
		public UIPetSelect.EItemIdx m_ItemIdx;

		// Token: 0x0400460A RID: 17930
		public ushort m_ID;
	}

	// Token: 0x02000486 RID: 1158
	private struct PetItem
	{
		// Token: 0x06001768 RID: 5992 RVA: 0x00283E00 File Offset: 0x00282000
		public PetItem(Transform transform, UISpritesArray sp)
		{
			this.m_Sp = sp;
			this.m_MainTf = null;
			this.m_Transform = null;
			this.m_Btn = new UIButton[2];
			this.m_HiBtn = new UIHIBtn[2];
			this.m_Name = new UIText[2];
			this.m_SliderText = new UIText[2];
			this.m_Slider = new Image[2];
			this.m_Mask = new Image[2];
			this.m_StateIcon = new Image[2][];
			this.m_StateIcon[0] = new Image[4];
			this.m_StateIcon[1] = new Image[4];
			this.m_NameCStr = new CString[2];
			this.m_ExpCStr = new CString[2];
			this.m_NameCStr[0] = StringManager.Instance.SpawnString(30);
			this.m_NameCStr[1] = StringManager.Instance.SpawnString(30);
			this.m_ExpCStr[0] = StringManager.Instance.SpawnString(30);
			this.m_ExpCStr[1] = StringManager.Instance.SpawnString(30);
			this.m_IconType = new UIPetSelect.EIconType[2];
			this.m_IconType[0] = UIPetSelect.EIconType.None;
			this.m_IconType[1] = UIPetSelect.EIconType.None;
			this.bHasInstance = false;
		}

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06001769 RID: 5993 RVA: 0x00283F20 File Offset: 0x00282120
		public bool HasInstance
		{
			get
			{
				return this.bHasInstance;
			}
		}

		// Token: 0x0600176A RID: 5994 RVA: 0x00283F28 File Offset: 0x00282128
		private void InitHiBtn()
		{
			GUIManager.Instance.InitianHeroItemImg(this.m_HiBtn[0].transform, eHeroOrItem.Pet, 0, 1, 0, 1, true, false, true, false);
			this.m_HiBtn[0].transform.gameObject.AddComponent<IgnoreRaycast>();
			GUIManager.Instance.InitianHeroItemImg(this.m_HiBtn[1].transform, eHeroOrItem.Pet, 0, 0, 0, 0, true, false, true, false);
			this.m_HiBtn[1].transform.gameObject.AddComponent<IgnoreRaycast>();
		}

		// Token: 0x0600176B RID: 5995 RVA: 0x00283FA8 File Offset: 0x002821A8
		public void Init(Transform mainTf, Transform[] trans, UIButton[] btn, UIHIBtn[] hiBtn, UIText[] name, UIText[] sliderText, Image[] slider, Image[] mask, Image[][] stateIcon)
		{
			this.m_MainTf = mainTf;
			this.m_Transform = trans;
			this.m_Btn = btn;
			this.m_HiBtn = hiBtn;
			this.m_Name = name;
			this.m_Slider = slider;
			this.m_StateIcon = stateIcon;
			this.m_SliderText = sliderText;
			this.m_Mask = mask;
			this.InitHiBtn();
			this.bHasInstance = true;
		}

		// Token: 0x0600176C RID: 5996 RVA: 0x00284008 File Offset: 0x00282208
		public void SetName(UIPetSelect.EItemIdx idx, ushort id)
		{
			if (this.m_Name != null && this.m_Name[(int)idx] != null)
			{
				this.m_Name[(int)idx].text = PetManager.Instance.GetPetNameByID(id);
			}
		}

		// Token: 0x0600176D RID: 5997 RVA: 0x0028404C File Offset: 0x0028224C
		public void SetHiBtn(UIPetSelect.EItemIdx idx, ushort id, byte circle = 0, byte rank = 0, int lv = 0)
		{
			GUIManager.Instance.ChangeHeroItemImg(this.m_HiBtn[(int)idx].transform, eHeroOrItem.Pet, id, circle, 0, lv);
		}

		// Token: 0x0600176E RID: 5998 RVA: 0x00284078 File Offset: 0x00282278
		public void SetSlider(UIPetSelect.EItemIdx idx, uint value, uint Max, byte petLv, byte maxLv)
		{
			float num = 0f;
			float num2 = 151f;
			Vector2 sizeDelta = Vector2.zero;
			if (this.m_Slider[(int)idx] != null)
			{
				sizeDelta = this.m_Slider[(int)idx].rectTransform.sizeDelta;
				num = Mathf.Clamp(value / Max, 0f, 1f);
				sizeDelta.x = num * num2;
				this.m_Slider[(int)idx].rectTransform.sizeDelta = sizeDelta;
			}
			if (this.m_SliderText != null && this.m_SliderText[(int)idx] != null)
			{
				this.m_ExpCStr[(int)idx].ClearString();
				this.m_ExpCStr[(int)idx].IntToFormat((long)((int)(num * 100f)), 1, false);
				if (GUIManager.Instance.IsArabic)
				{
					this.m_ExpCStr[(int)idx].AppendFormat("%{0}");
				}
				else
				{
					this.m_ExpCStr[(int)idx].AppendFormat("{0}%");
				}
				this.m_SliderText[(int)idx].text = this.m_ExpCStr[(int)idx].ToString();
				this.m_SliderText[(int)idx].SetAllDirty();
				this.m_SliderText[(int)idx].cachedTextGenerator.Invalidate();
				this.m_SliderText[(int)idx].cachedTextGeneratorForLayout.Invalidate();
			}
			if (petLv == 60)
			{
				this.m_SliderText[(int)idx].text = DataManager.Instance.mStringTable.GetStringByID(1507u);
				this.m_SliderText[(int)idx].SetAllDirty();
				this.m_SliderText[(int)idx].cachedTextGenerator.Invalidate();
				this.m_SliderText[(int)idx].cachedTextGeneratorForLayout.Invalidate();
				sizeDelta.x = num2;
				this.m_Slider[(int)idx].rectTransform.sizeDelta = sizeDelta;
				this.m_Slider[(int)idx].sprite = this.m_Sp.GetSprite(1);
			}
			else if (petLv >= maxLv && value >= Max - 1u)
			{
				this.m_SliderText[(int)idx].text = DataManager.Instance.mStringTable.GetStringByID(16051u);
				this.m_SliderText[(int)idx].SetAllDirty();
				this.m_SliderText[(int)idx].cachedTextGenerator.Invalidate();
				this.m_SliderText[(int)idx].cachedTextGeneratorForLayout.Invalidate();
			}
			else
			{
				this.m_Slider[(int)idx].sprite = this.m_Sp.GetSprite(0);
			}
		}

		// Token: 0x0600176F RID: 5999 RVA: 0x002842D0 File Offset: 0x002824D0
		public void SetBtnID(UIPetSelect.EItemIdx idx, int dataIdx, int panelObjectIdx)
		{
			this.m_Btn[(int)idx].m_BtnID2 = (int)idx;
			this.m_Btn[(int)idx].m_BtnID3 = dataIdx;
			this.m_Btn[(int)idx].m_BtnID4 = panelObjectIdx;
		}

		// Token: 0x06001770 RID: 6000 RVA: 0x00284308 File Offset: 0x00282508
		public void ClearIcon(UIPetSelect.EItemIdx idx)
		{
			this.m_IconType[(int)idx] = UIPetSelect.EIconType.None;
		}

		// Token: 0x06001771 RID: 6001 RVA: 0x00284314 File Offset: 0x00282514
		public void AddIcon(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
		{
			this.m_IconType[(int)idx] |= type;
			this.m_StateIcon[(int)idx][0].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.LockLimit) == UIPetSelect.EIconType.LockLimit);
			this.m_StateIcon[(int)idx][1].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Training) == UIPetSelect.EIconType.Training);
			this.m_StateIcon[(int)idx][2].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select);
			this.m_Mask[(int)idx].enabled = (this.m_IconType[(int)idx] != UIPetSelect.EIconType.None);
		}

		// Token: 0x06001772 RID: 6002 RVA: 0x002843A4 File Offset: 0x002825A4
		public void RemoveIcon(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
		{
			if (this.m_IconType != null)
			{
				this.m_IconType[(int)idx] &= ~type;
				this.m_StateIcon[(int)idx][0].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.LockLimit) == UIPetSelect.EIconType.LockLimit);
				this.m_StateIcon[(int)idx][1].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Training) == UIPetSelect.EIconType.Training);
				this.m_StateIcon[(int)idx][2].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select);
				this.m_Mask[(int)idx].enabled = (this.m_IconType[(int)idx] != UIPetSelect.EIconType.None);
			}
		}

		// Token: 0x06001773 RID: 6003 RVA: 0x00284440 File Offset: 0x00282640
		public void SetIcon(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
		{
			if (this.m_IconType != null)
			{
				this.m_IconType[(int)idx] = type;
				this.m_StateIcon[(int)idx][0].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Lock) == UIPetSelect.EIconType.Lock);
				this.m_StateIcon[(int)idx][0].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.LockLimit) == UIPetSelect.EIconType.LockLimit);
				this.m_StateIcon[(int)idx][1].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Training) == UIPetSelect.EIconType.Training);
				this.m_StateIcon[(int)idx][2].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select);
				this.m_Mask[(int)idx].enabled = (this.m_IconType[(int)idx] != UIPetSelect.EIconType.None);
			}
		}

		// Token: 0x06001774 RID: 6004 RVA: 0x002844EC File Offset: 0x002826EC
		public void OnSelect(UIPetSelect.EItemIdx idx)
		{
			if (this.m_IconType != null)
			{
				bool flag = (this.m_IconType[(int)idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select;
				if (flag)
				{
					this.m_IconType[(int)idx] &= (UIPetSelect.EIconType)(-5);
				}
				else
				{
					this.m_IconType[(int)idx] |= UIPetSelect.EIconType.Select;
				}
				this.m_StateIcon[(int)idx][2].enabled = !flag;
				this.m_Mask[(int)idx].enabled = (this.m_IconType[(int)idx] != UIPetSelect.EIconType.None);
			}
		}

		// Token: 0x06001775 RID: 6005 RVA: 0x00284570 File Offset: 0x00282770
		public void Show(bool bShow)
		{
			if (this.m_MainTf != null)
			{
				this.m_MainTf.gameObject.SetActive(bShow);
			}
			if (this.m_Transform[0])
			{
				this.m_Transform[0].gameObject.SetActive(bShow);
			}
			if (this.m_Transform[1])
			{
				this.m_Transform[1].gameObject.SetActive(bShow);
			}
		}

		// Token: 0x06001776 RID: 6006 RVA: 0x002845EC File Offset: 0x002827EC
		public void OnlyShowLeft(bool onlyLeft)
		{
			if (this.m_Transform[1])
			{
				this.m_Transform[1].gameObject.SetActive(!onlyLeft);
			}
			if (this.m_Transform[0])
			{
				this.m_Transform[0].gameObject.SetActive(true);
			}
		}

		// Token: 0x06001777 RID: 6007 RVA: 0x00284648 File Offset: 0x00282848
		public void DeSpawn()
		{
			if (this.m_NameCStr[0] != null)
			{
				StringManager.Instance.DeSpawnString(this.m_NameCStr[0]);
				this.m_NameCStr[0] = null;
			}
			if (this.m_NameCStr[1] != null)
			{
				StringManager.Instance.DeSpawnString(this.m_NameCStr[1]);
				this.m_NameCStr[1] = null;
			}
			if (this.m_ExpCStr[0] != null)
			{
				StringManager.Instance.DeSpawnString(this.m_NameCStr[0]);
				this.m_ExpCStr[0] = null;
			}
			if (this.m_ExpCStr[1] != null)
			{
				StringManager.Instance.DeSpawnString(this.m_NameCStr[1]);
				this.m_ExpCStr[1] = null;
			}
		}

		// Token: 0x06001778 RID: 6008 RVA: 0x002846FC File Offset: 0x002828FC
		public void RefreshFontTexture()
		{
			if (this.m_HiBtn[0] != null && this.m_HiBtn[0].enabled)
			{
				this.m_HiBtn[0].Refresh_FontTexture();
			}
			if (this.m_HiBtn[1] != null && this.m_HiBtn[1].enabled)
			{
				this.m_HiBtn[1].Refresh_FontTexture();
			}
			if (this.m_Name[0] != null && this.m_Name[0].enabled)
			{
				this.m_Name[0].enabled = false;
				this.m_Name[0].enabled = true;
			}
			if (this.m_Name != null && this.m_Name[1].enabled)
			{
				this.m_Name[1].enabled = false;
				this.m_Name[1].enabled = true;
			}
			if (this.m_SliderText[0] != null && this.m_SliderText[0].enabled)
			{
				this.m_SliderText[0].enabled = false;
				this.m_SliderText[0].enabled = true;
			}
			if (this.m_SliderText[1] != null && this.m_SliderText[1].enabled)
			{
				this.m_SliderText[1].enabled = false;
				this.m_SliderText[1].enabled = true;
			}
		}

		// Token: 0x0400460B RID: 17931
		private const byte NoneSelect = 255;

		// Token: 0x0400460C RID: 17932
		private Transform m_MainTf;

		// Token: 0x0400460D RID: 17933
		private Transform[] m_Transform;

		// Token: 0x0400460E RID: 17934
		private UIButton[] m_Btn;

		// Token: 0x0400460F RID: 17935
		private UIHIBtn[] m_HiBtn;

		// Token: 0x04004610 RID: 17936
		private UIText[] m_Name;

		// Token: 0x04004611 RID: 17937
		private UIText[] m_SliderText;

		// Token: 0x04004612 RID: 17938
		private Image[] m_Slider;

		// Token: 0x04004613 RID: 17939
		private Image[] m_Mask;

		// Token: 0x04004614 RID: 17940
		private Image[][] m_StateIcon;

		// Token: 0x04004615 RID: 17941
		private CString[] m_NameCStr;

		// Token: 0x04004616 RID: 17942
		private CString[] m_ExpCStr;

		// Token: 0x04004617 RID: 17943
		private UIPetSelect.EIconType[] m_IconType;

		// Token: 0x04004618 RID: 17944
		private UISpritesArray m_Sp;

		// Token: 0x04004619 RID: 17945
		private bool bHasInstance;
	}

	// Token: 0x02000487 RID: 1159
	private struct HeroItem
	{
		// Token: 0x06001779 RID: 6009 RVA: 0x0028486C File Offset: 0x00282A6C
		public HeroItem(Transform transform = null)
		{
			this.m_MainTf = null;
			this.m_Transform = new Transform[2];
			this.m_Btn = new UIButton[2];
			this.m_HiBtn = new UIHIBtn[2];
			this.m_AdditionalTimeText = new UIText[2];
			this.m_Mask = new Image[2];
			this.m_StateIcon = new Image[2][];
			this.m_StateIcon[0] = new Image[4];
			this.m_StateIcon[1] = new Image[4];
			this.m_TimeTextCStr = new CString[2];
			this.m_TimeTextCStr[0] = StringManager.Instance.SpawnString(30);
			this.m_TimeTextCStr[1] = StringManager.Instance.SpawnString(30);
			this.m_IconType = new UIPetSelect.EIconType[2];
			this.m_IconType[0] = UIPetSelect.EIconType.None;
			this.m_IconType[1] = UIPetSelect.EIconType.None;
			this.bHasInstance = false;
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x0600177A RID: 6010 RVA: 0x00284940 File Offset: 0x00282B40
		public bool HasInstance
		{
			get
			{
				return this.bHasInstance;
			}
		}

		// Token: 0x0600177B RID: 6011 RVA: 0x00284948 File Offset: 0x00282B48
		private void InitHiBtn()
		{
			GUIManager.Instance.InitianHeroItemImg(this.m_HiBtn[0].transform, eHeroOrItem.Hero, 0, 0, 0, 0, false, false, true, false);
			this.m_HiBtn[0].transform.gameObject.AddComponent<IgnoreRaycast>();
			GUIManager.Instance.InitianHeroItemImg(this.m_HiBtn[1].transform, eHeroOrItem.Hero, 0, 0, 0, 0, false, false, true, false);
			this.m_HiBtn[1].transform.gameObject.AddComponent<IgnoreRaycast>();
		}

		// Token: 0x0600177C RID: 6012 RVA: 0x002849C8 File Offset: 0x00282BC8
		public void Init(Transform mainTf, Transform[] trans, UIButton[] btn, UIHIBtn[] hiBtn, UIText[] additionalTimeText, Image[] mask, Image[][] stateIcon)
		{
			this.m_MainTf = mainTf;
			this.m_Transform = trans;
			this.m_Btn = btn;
			this.m_HiBtn = hiBtn;
			this.m_AdditionalTimeText = additionalTimeText;
			this.m_Mask = mask;
			this.m_StateIcon = stateIcon;
			this.m_TimeTextCStr[0] = StringManager.Instance.SpawnString(30);
			this.m_TimeTextCStr[1] = StringManager.Instance.SpawnString(30);
			this.InitHiBtn();
			this.bHasInstance = true;
		}

		// Token: 0x0600177D RID: 6013 RVA: 0x00284A40 File Offset: 0x00282C40
		public void SetHiBtn(UIPetSelect.EItemIdx idx, ushort id, byte circle = 0, byte rank = 0, int lv = 0)
		{
			GUIManager.Instance.ChangeHeroItemImg(this.m_HiBtn[(int)idx].transform, eHeroOrItem.Hero, id, circle, 0, lv);
		}

		// Token: 0x0600177E RID: 6014 RVA: 0x00284A6C File Offset: 0x00282C6C
		public void SetBtnID(UIPetSelect.EItemIdx idx, int dataIdx, int panelObjectIdx)
		{
			this.m_Btn[(int)idx].m_BtnID2 = (int)idx;
			this.m_Btn[(int)idx].m_BtnID3 = dataIdx;
			this.m_Btn[(int)idx].m_BtnID4 = panelObjectIdx;
		}

		// Token: 0x0600177F RID: 6015 RVA: 0x00284AA4 File Offset: 0x00282CA4
		public void SetTrainTime(UIPetSelect.EItemIdx idx, uint minute)
		{
			this.m_TimeTextCStr[(int)idx].ClearString();
			UIPetSelect.GetTimeInfoString(this.m_TimeTextCStr[(int)idx], minute * 60u, false);
			this.m_AdditionalTimeText[(int)idx].text = this.m_TimeTextCStr[(int)idx].ToString();
			this.m_AdditionalTimeText[(int)idx].SetAllDirty();
			this.m_AdditionalTimeText[(int)idx].cachedTextGenerator.Invalidate();
		}

		// Token: 0x06001780 RID: 6016 RVA: 0x00284B0C File Offset: 0x00282D0C
		public void ClearIcon(UIPetSelect.EItemIdx idx)
		{
			this.m_IconType[(int)idx] = UIPetSelect.EIconType.None;
		}

		// Token: 0x06001781 RID: 6017 RVA: 0x00284B18 File Offset: 0x00282D18
		public void AddIcon(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
		{
			this.m_IconType[(int)idx] |= type;
			this.m_StateIcon[(int)idx][0].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Lock) == UIPetSelect.EIconType.Lock);
			this.m_StateIcon[(int)idx][0].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.LockLimit) == UIPetSelect.EIconType.LockLimit);
			this.m_StateIcon[(int)idx][1].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Training) == UIPetSelect.EIconType.Training);
			this.m_StateIcon[(int)idx][2].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select);
			this.m_Mask[(int)idx].enabled = (this.m_IconType[(int)idx] != UIPetSelect.EIconType.None);
		}

		// Token: 0x06001782 RID: 6018 RVA: 0x00284BC4 File Offset: 0x00282DC4
		public void RemoveIcon(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
		{
			this.m_IconType[(int)idx] &= ~type;
			this.m_StateIcon[(int)idx][0].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Lock) == UIPetSelect.EIconType.Lock);
			this.m_StateIcon[(int)idx][0].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.LockLimit) == UIPetSelect.EIconType.LockLimit);
			this.m_StateIcon[(int)idx][1].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Training) == UIPetSelect.EIconType.Training);
			this.m_StateIcon[(int)idx][2].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select);
			this.m_Mask[(int)idx].enabled = (this.m_IconType[(int)idx] != UIPetSelect.EIconType.None);
		}

		// Token: 0x06001783 RID: 6019 RVA: 0x00284C70 File Offset: 0x00282E70
		public void SetIcon(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
		{
			this.m_IconType[(int)idx] = type;
			this.m_StateIcon[(int)idx][0].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Lock) == UIPetSelect.EIconType.Lock);
			this.m_StateIcon[(int)idx][0].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.LockLimit) == UIPetSelect.EIconType.LockLimit);
			this.m_StateIcon[(int)idx][1].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Training) == UIPetSelect.EIconType.Training);
			this.m_StateIcon[(int)idx][2].enabled = ((this.m_IconType[(int)idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select);
			this.m_Mask[(int)idx].enabled = (this.m_IconType[(int)idx] != UIPetSelect.EIconType.None);
		}

		// Token: 0x06001784 RID: 6020 RVA: 0x00284D14 File Offset: 0x00282F14
		public void OnSelect(UIPetSelect.EItemIdx idx)
		{
			bool flag = (this.m_IconType[(int)idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select;
			if (flag)
			{
				this.m_IconType[(int)idx] &= (UIPetSelect.EIconType)(-5);
			}
			else
			{
				this.m_IconType[(int)idx] |= UIPetSelect.EIconType.Select;
			}
			this.m_StateIcon[(int)idx][2].enabled = !flag;
			this.m_Mask[(int)idx].enabled = (this.m_IconType[(int)idx] != UIPetSelect.EIconType.None);
		}

		// Token: 0x06001785 RID: 6021 RVA: 0x00284D8C File Offset: 0x00282F8C
		public void Show(bool bShow)
		{
			if (this.m_MainTf)
			{
				this.m_MainTf.gameObject.SetActive(bShow);
			}
			if (this.m_Transform[0])
			{
				this.m_Transform[0].gameObject.SetActive(bShow);
			}
			if (this.m_Transform[1])
			{
				this.m_Transform[1].gameObject.SetActive(bShow);
			}
		}

		// Token: 0x06001786 RID: 6022 RVA: 0x00284E04 File Offset: 0x00283004
		public void OnlyShowLeft(bool onlyLeft)
		{
			if (this.m_Transform[1])
			{
				this.m_Transform[1].gameObject.SetActive(!onlyLeft);
			}
			if (this.m_Transform[0])
			{
				this.m_Transform[0].gameObject.SetActive(true);
			}
		}

		// Token: 0x06001787 RID: 6023 RVA: 0x00284E60 File Offset: 0x00283060
		public void DeSpawn()
		{
			if (this.m_TimeTextCStr[0] != null)
			{
				StringManager.Instance.DeSpawnString(this.m_TimeTextCStr[0]);
				this.m_TimeTextCStr[0] = null;
			}
			if (this.m_TimeTextCStr[1] != null)
			{
				StringManager.Instance.DeSpawnString(this.m_TimeTextCStr[1]);
				this.m_TimeTextCStr[1] = null;
			}
		}

		// Token: 0x06001788 RID: 6024 RVA: 0x00284EC0 File Offset: 0x002830C0
		public void RefreshFontTexture()
		{
			if (this.m_HiBtn[0] != null && this.m_HiBtn[0].enabled)
			{
				this.m_HiBtn[0].Refresh_FontTexture();
			}
			if (this.m_HiBtn[1] != null && this.m_HiBtn[1].enabled)
			{
				this.m_HiBtn[1].Refresh_FontTexture();
			}
			if (this.m_AdditionalTimeText[0] != null && this.m_AdditionalTimeText[0].enabled)
			{
				this.m_AdditionalTimeText[0].enabled = false;
				this.m_AdditionalTimeText[0].enabled = true;
			}
			if (this.m_AdditionalTimeText[1] != null && this.m_AdditionalTimeText[1].enabled)
			{
				this.m_AdditionalTimeText[1].enabled = false;
				this.m_AdditionalTimeText[1].enabled = true;
			}
		}

		// Token: 0x0400461A RID: 17946
		private Transform m_MainTf;

		// Token: 0x0400461B RID: 17947
		private UIButton[] m_Btn;

		// Token: 0x0400461C RID: 17948
		private Transform[] m_Transform;

		// Token: 0x0400461D RID: 17949
		private UIHIBtn[] m_HiBtn;

		// Token: 0x0400461E RID: 17950
		private UIText[] m_AdditionalTimeText;

		// Token: 0x0400461F RID: 17951
		private Image[] m_Mask;

		// Token: 0x04004620 RID: 17952
		private Image[][] m_StateIcon;

		// Token: 0x04004621 RID: 17953
		private CString[] m_TimeTextCStr;

		// Token: 0x04004622 RID: 17954
		private UIPetSelect.EIconType[] m_IconType;

		// Token: 0x04004623 RID: 17955
		private bool bHasInstance;
	}

	// Token: 0x02000488 RID: 1160
	private struct LinelItem
	{
		// Token: 0x06001789 RID: 6025 RVA: 0x00284FB4 File Offset: 0x002831B4
		public LinelItem(Transform transform = null)
		{
			this.m_Transform = transform;
			this.m_Content = null;
			this.bHasInstance = false;
		}

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x0600178A RID: 6026 RVA: 0x00284FCC File Offset: 0x002831CC
		public bool HasInstance
		{
			get
			{
				return this.bHasInstance;
			}
		}

		// Token: 0x0600178B RID: 6027 RVA: 0x00284FD4 File Offset: 0x002831D4
		public void Init(Transform trans, UIText content)
		{
			this.m_Transform = trans;
			this.m_Content = content;
			this.m_Content.text = DataManager.Instance.mStringTable.GetStringByID(17097u);
			this.bHasInstance = true;
		}

		// Token: 0x0600178C RID: 6028 RVA: 0x00285018 File Offset: 0x00283218
		public void Show(bool bShow, bool bPet = true)
		{
			this.m_Transform.gameObject.SetActive(bShow);
			if (bShow)
			{
				if (bPet)
				{
					this.m_Content.text = DataManager.Instance.mStringTable.GetStringByID(17097u);
				}
				else
				{
					this.m_Content.text = DataManager.Instance.mStringTable.GetStringByID(17103u);
				}
			}
		}

		// Token: 0x0600178D RID: 6029 RVA: 0x00285088 File Offset: 0x00283288
		public void RefreshFontTexture()
		{
			if (this.m_Content != null && this.m_Content.enabled)
			{
				this.m_Content.enabled = false;
				this.m_Content.enabled = true;
			}
		}

		// Token: 0x04004624 RID: 17956
		private Transform m_Transform;

		// Token: 0x04004625 RID: 17957
		private UIText m_Content;

		// Token: 0x04004626 RID: 17958
		private bool bHasInstance;
	}

	// Token: 0x02000489 RID: 1161
	private struct SSrollPanelItem
	{
		// Token: 0x0600178E RID: 6030 RVA: 0x002850C4 File Offset: 0x002832C4
		public SSrollPanelItem(UIPetSelect.SSrollPanelItem.EItemType type, UISpritesArray sp)
		{
			this.m_Sp = sp;
			this.m_ItemType = type;
			this.m_PetItem = new UIPetSelect.PetItem(null, this.m_Sp);
			this.m_HeroItem = new UIPetSelect.HeroItem(null);
			this.m_LineItem = new UIPetSelect.LinelItem(null);
		}

		// Token: 0x0600178F RID: 6031 RVA: 0x0028510C File Offset: 0x0028330C
		public void SetType(UIPetSelect.SSrollPanelItem.EItemType type, bool bPetLine = true)
		{
			if (type == UIPetSelect.SSrollPanelItem.EItemType.PetType)
			{
				this.m_PetItem.Show(true);
				this.m_HeroItem.Show(false);
				this.m_LineItem.Show(false, true);
			}
			else if (type == UIPetSelect.SSrollPanelItem.EItemType.HeroType)
			{
				this.m_PetItem.Show(false);
				this.m_HeroItem.Show(true);
				this.m_LineItem.Show(false, true);
			}
			else
			{
				this.m_PetItem.Show(false);
				this.m_HeroItem.Show(false);
				if (bPetLine)
				{
					this.m_LineItem.Show(true, true);
				}
				else
				{
					this.m_LineItem.Show(true, false);
				}
			}
		}

		// Token: 0x04004627 RID: 17959
		public UIPetSelect.SSrollPanelItem.EItemType m_ItemType;

		// Token: 0x04004628 RID: 17960
		public UIPetSelect.PetItem m_PetItem;

		// Token: 0x04004629 RID: 17961
		public UIPetSelect.HeroItem m_HeroItem;

		// Token: 0x0400462A RID: 17962
		public UIPetSelect.LinelItem m_LineItem;

		// Token: 0x0400462B RID: 17963
		private UISpritesArray m_Sp;

		// Token: 0x0200048A RID: 1162
		public enum EItemType
		{
			// Token: 0x0400462D RID: 17965
			PetType,
			// Token: 0x0400462E RID: 17966
			HeroType,
			// Token: 0x0400462F RID: 17967
			LineType
		}
	}

	// Token: 0x0200048B RID: 1163
	public class SScrollData
	{
		// Token: 0x06001790 RID: 6032 RVA: 0x002851B8 File Offset: 0x002833B8
		public SScrollData()
		{
			this.bLineType = false;
			this.bShowOnlyLeft = true;
			this.bDataPadding = false;
			this.m_DataIdx = new int[2];
			this.m_ID = new ushort[2];
			this.m_EIconType = new UIPetSelect.EIconType[2];
			this.m_TrainTime = new uint[2];
			this.m_Color = new byte[2];
			this.bHasInstance = true;
		}

		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06001791 RID: 6033 RVA: 0x00285224 File Offset: 0x00283424
		public bool HasInstance
		{
			get
			{
				return this.bHasInstance;
			}
		}

		// Token: 0x06001792 RID: 6034 RVA: 0x0028522C File Offset: 0x0028342C
		public void Empty()
		{
			this.bLineType = false;
			this.bShowOnlyLeft = true;
			this.bDataPadding = false;
			Array.Clear(this.m_DataIdx, 0, 2);
			Array.Clear(this.m_ID, 0, 2);
			Array.Clear(this.m_EIconType, 0, 2);
			Array.Clear(this.m_TrainTime, 0, 2);
			this.m_Color[0] = 0;
			this.m_Color[1] = 0;
		}

		// Token: 0x06001793 RID: 6035 RVA: 0x00285294 File Offset: 0x00283494
		public UIPetSelect.ESelectItem OnSelect(UIPetSelect.EItemIdx idx, byte dataIdx)
		{
			UIPetSelect.ESelectItem result = new UIPetSelect.ESelectItem(UIPetSelect.EItemIdx.Left);
			if (this.m_EIconType != null)
			{
				bool flag = (this.m_EIconType[(int)idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select;
				if (flag)
				{
					this.m_EIconType[(int)idx] &= (UIPetSelect.EIconType)(-5);
					result.m_DataIdx = byte.MaxValue;
					result.m_ID = 0;
				}
				else
				{
					this.m_EIconType[(int)idx] |= UIPetSelect.EIconType.Select;
					result.m_DataIdx = dataIdx;
					result.m_ItemIdx = idx;
					result.m_ID = this.m_ID[(int)idx];
				}
				return result;
			}
			return result;
		}

		// Token: 0x06001794 RID: 6036 RVA: 0x00285328 File Offset: 0x00283528
		public void RemoveSelectIcon(UIPetSelect.EItemIdx idx)
		{
			if (this.m_EIconType != null)
			{
				this.m_EIconType[(int)idx] &= (UIPetSelect.EIconType)(-5);
			}
		}

		// Token: 0x06001795 RID: 6037 RVA: 0x00285348 File Offset: 0x00283548
		public void RemoveIcon(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
		{
			if (this.m_EIconType != null)
			{
				this.m_EIconType[(int)idx] &= (UIPetSelect.EIconType)(-5);
			}
		}

		// Token: 0x06001796 RID: 6038 RVA: 0x00285368 File Offset: 0x00283568
		public ushort GetPetSelectID()
		{
			return 0;
		}

		// Token: 0x06001797 RID: 6039 RVA: 0x00285378 File Offset: 0x00283578
		public ushort GetHeroSelectID(UIPetSelect.EItemIdx idx)
		{
			ushort result = 0;
			if (this.m_EIconType != null && this.m_ID != null)
			{
				bool flag = (this.m_EIconType[(int)idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select;
				if (flag)
				{
					result = this.m_ID[(int)idx];
				}
			}
			return result;
		}

		// Token: 0x06001798 RID: 6040 RVA: 0x002853BC File Offset: 0x002835BC
		public bool CheckIconType(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
		{
			return this.m_EIconType != null && (this.m_EIconType[(int)idx] & type) == type;
		}

		// Token: 0x04004630 RID: 17968
		public bool bLineType;

		// Token: 0x04004631 RID: 17969
		public bool bShowOnlyLeft;

		// Token: 0x04004632 RID: 17970
		public bool bDataPadding;

		// Token: 0x04004633 RID: 17971
		public ushort[] m_ID;

		// Token: 0x04004634 RID: 17972
		public int[] m_DataIdx;

		// Token: 0x04004635 RID: 17973
		public UIPetSelect.EIconType[] m_EIconType;

		// Token: 0x04004636 RID: 17974
		public uint[] m_TrainTime;

		// Token: 0x04004637 RID: 17975
		public byte[] m_Color;

		// Token: 0x04004638 RID: 17976
		private bool bHasInstance;
	}
}
