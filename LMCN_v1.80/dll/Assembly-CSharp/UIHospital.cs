using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005AD RID: 1453
public class UIHospital : GUIWindow, IBuildingWindowType, IUpDateScrollPanel, IUIButtonClickHandler, IUICalculatorHandler, IUTimeBarOnTimer, IUIUnitRSliderHandler
{
	// Token: 0x06001CCC RID: 7372 RVA: 0x003355E4 File Offset: 0x003337E4
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
		{
			this.BG.gameObject.SetActive(true);
			this.m_DResources.gameObject.SetActive(true);
			this.btn_ALL.gameObject.SetActive(true);
			this.btn_Treatment.gameObject.SetActive(true);
			this.btn_TreatmentCompleted.gameObject.SetActive(true);
			this.Img_Slider[0].gameObject.SetActive(true);
			if (this.bTreatmenting)
			{
				this.Img_Treatment.gameObject.SetActive(true);
			}
			if (this.bNOInjured)
			{
				this.m_ScrollPanel.gameObject.SetActive(false);
				this.text_NoNeedTreatment.gameObject.SetActive(true);
				this.btn_ALL.ForTextChange(e_BtnType.e_ChangeText);
				this.btn_Treatment.ForTextChange(e_BtnType.e_ChangeText);
			}
			else
			{
				this.m_ScrollPanel.gameObject.SetActive(true);
				this.text_NoNeedTreatment.gameObject.SetActive(false);
				this.CheckAllMax(false);
				this.SetDRformURS(false);
				if (this.buildID == 7)
				{
					this.HospitalNum = this.GetHospitalMaxCapacity();
					this.text_InjuredTroops[1].gameObject.SetActive(true);
					this.text_InjuredTroops[2].gameObject.SetActive(true);
					this.Cstr_InjuredTroop[0].ClearString();
					this.Cstr_InjuredTroop[0].IntToFormat((long)((ulong)this.InjuredNum), 1, true);
					this.Cstr_InjuredTroop[0].AppendFormat("{0}");
					this.text_InjuredTroops[1].text = this.Cstr_InjuredTroop[0].ToString();
					this.text_InjuredTroops[1].SetAllDirty();
					this.text_InjuredTroops[1].cachedTextGenerator.Invalidate();
					this.Cstr_InjuredTroop[1].ClearString();
					this.Cstr_InjuredTroop[1].IntToFormat((long)((ulong)this.HospitalNum), 1, true);
					if (this.GUIM.IsArabic)
					{
						this.Cstr_InjuredTroop[1].AppendFormat("{0} / ");
					}
					else
					{
						this.Cstr_InjuredTroop[1].AppendFormat(" / {0}");
					}
					this.text_InjuredTroops[2].text = this.Cstr_InjuredTroop[1].ToString();
					this.text_InjuredTroops[2].SetAllDirty();
					this.text_InjuredTroops[2].cachedTextGenerator.Invalidate();
				}
				else
				{
					this.HospitalNum = this.GetTrapCapacity();
					this.Cstr_TrapNum[0].ClearString();
					this.Cstr_TrapNum[0].IntToFormat((long)((ulong)this.DM.TrapHospitalTotal), 1, true);
					this.Cstr_TrapNum[0].AppendFormat("{0}");
					this.text_TrapNum[0].text = this.Cstr_TrapNum[0].ToString();
					this.text_TrapNum[0].SetAllDirty();
					this.text_TrapNum[0].cachedTextGenerator.Invalidate();
					this.Cstr_TrapNum[1].ClearString();
					this.Cstr_TrapNum[1].IntToFormat((long)((ulong)this.HospitalNum), 1, true);
					if (this.GUIM.IsArabic)
					{
						this.Cstr_TrapNum[1].AppendFormat("{0} / ");
					}
					else
					{
						this.Cstr_TrapNum[1].AppendFormat(" / {0}");
					}
					this.text_TrapNum[1].text = this.Cstr_TrapNum[1].ToString();
					this.text_TrapNum[1].SetAllDirty();
					this.text_TrapNum[1].cachedTextGenerator.Invalidate();
				}
			}
		}
		else
		{
			this.m_ScrollRect.StopMovement();
			this.BG.gameObject.SetActive(false);
			this.m_DResources.gameObject.SetActive(false);
			this.btn_ALL.gameObject.SetActive(false);
			this.btn_Treatment.gameObject.SetActive(false);
			this.btn_TreatmentCompleted.gameObject.SetActive(false);
			this.m_ScrollPanel.gameObject.SetActive(false);
			this.Img_Slider[0].gameObject.SetActive(false);
			if (this.bTreatmenting)
			{
				this.Img_Treatment.gameObject.SetActive(false);
			}
			this.text_NoNeedTreatment.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001CCD RID: 7373 RVA: 0x00335A18 File Offset: 0x00333C18
	public void OnVauleChang(UnitResourcesSlider sender)
	{
		int id = sender.m_ID;
		bool drformURS = true;
		if (sender.Value < this.m_Soldier[id])
		{
			drformURS = false;
		}
		if (this.buildID == 12 && (ulong)this.mTrapTreatmentMax < (ulong)(this.TreatmentNum - this.m_Soldier[id] + sender.Value) && sender.Type == 1)
		{
			sender.Value = (long)((ulong)this.mTrapTreatmentMax - (ulong)this.TreatmentNum + (ulong)this.m_Soldier[id]);
			sender.m_slider.value = (double)sender.Value;
			this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(3755u), 255, true);
			return;
		}
		if (sender.Type == 1)
		{
			Transform parent = sender.gameObject.transform.parent;
			int btnID = parent.GetComponent<ScrollPanelItem>().m_BtnID2;
			this.Cstr_ItemSliderQty[btnID].ClearString();
			this.Cstr_ItemSliderQty[btnID].IntToFormat(sender.Value, 1, true);
			this.Cstr_ItemSliderQty[btnID].AppendFormat("{0}");
			sender.m_inputText.text = this.Cstr_ItemSliderQty[btnID].ToString();
			sender.m_inputText.SetAllDirty();
			sender.m_inputText.cachedTextGenerator.Invalidate();
			this.m_Soldier[id] = sender.Value;
			this.DM.mExpeditionSoldierList[id] = (uint)this.m_Soldier[id];
			this.SetDRformURS(drformURS);
		}
		else
		{
			this.Cstr.ClearString();
			StringManager.IntToStr(this.Cstr, sender.Value, 1, true);
			sender.m_inputText.text = this.Cstr.ToString();
			sender.m_inputText.SetAllDirty();
			sender.m_inputText.cachedTextGenerator.Invalidate();
			if (sender.Value == 0L && this.btn_Disband.m_BtnType == e_BtnType.e_Normal)
			{
				this.btn_Disband.ForTextChange(e_BtnType.e_ChangeText);
			}
			else if (this.btn_Disband.m_BtnType == e_BtnType.e_ChangeText)
			{
				this.btn_Disband.ForTextChange(e_BtnType.e_Normal);
			}
		}
	}

	// Token: 0x06001CCE RID: 7374 RVA: 0x00335C30 File Offset: 0x00333E30
	public void OnTextChang(UnitResourcesSlider sender)
	{
		int id = sender.m_ID;
		if (this.buildID == 12 && (ulong)this.mTrapTreatmentMax < (ulong)(this.TreatmentNum - this.m_Soldier[id] + sender.Value) && sender.Type == 1)
		{
			sender.Value = (long)((ulong)this.mTrapTreatmentMax - (ulong)this.TreatmentNum + (ulong)this.m_Soldier[id]);
			sender.m_slider.value = (double)sender.Value;
			this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(3755u), 255, true);
			return;
		}
		bool drformURS = true;
		if (sender.Value < this.m_Soldier[id])
		{
			drformURS = false;
		}
		if (sender.Type == 1)
		{
			Transform parent = sender.gameObject.transform.parent;
			int btnID = parent.GetComponent<ScrollPanelItem>().m_BtnID2;
			this.Cstr_ItemSliderQty[btnID].ClearString();
			this.Cstr_ItemSliderQty[btnID].IntToFormat(sender.Value, 1, true);
			this.Cstr_ItemSliderQty[btnID].AppendFormat("{0}");
			sender.m_inputText.text = this.Cstr_ItemSliderQty[btnID].ToString();
			sender.m_inputText.SetAllDirty();
			sender.m_inputText.cachedTextGenerator.Invalidate();
			this.m_Soldier[id] = sender.Value;
			this.DM.mExpeditionSoldierList[id] = (uint)this.m_Soldier[id];
			this.SetDRformURS(drformURS);
		}
		else
		{
			this.Cstr.ClearString();
			StringManager.IntToStr(this.Cstr, sender.Value, 1, true);
			sender.m_inputText.text = this.Cstr.ToString();
			sender.m_inputText.SetAllDirty();
			sender.m_inputText.cachedTextGenerator.Invalidate();
			if (sender.Value == 0L && this.btn_Disband.m_BtnType == e_BtnType.e_Normal)
			{
				this.btn_Disband.ForTextChange(e_BtnType.e_ChangeText);
			}
			else if (this.btn_Disband.m_BtnType == e_BtnType.e_ChangeText)
			{
				this.btn_Disband.ForTextChange(e_BtnType.e_Normal);
			}
		}
	}

	// Token: 0x06001CCF RID: 7375 RVA: 0x00335E48 File Offset: 0x00334048
	public void SetDRformURS(bool bCheck)
	{
		long[] array = new long[6];
		Array.Clear(array, 0, array.Length);
		this.TreatmentNum = 0L;
		double num = 0.0;
		int num2 = 4;
		if (this.buildID == 12)
		{
			num2 = 3;
		}
		for (int i = 0; i < this.Count; i++)
		{
			int num3 = (3 - i / 4) * 4 + i % 4;
			if (this.buildID == 7)
			{
				uint num4 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM)(79 + num3));
				if (num4 >= 9900u)
				{
					num4 = 9900u;
				}
				this.tmpEGA_Cost = 1f - num4 / 10000f;
			}
			else
			{
				this.tmpEGA_Cost = 1f;
			}
			array[0] += (long)((ulong)GameConstants.appCeil(GameConstants.appCeil(this.m_UnitResources[i].Food * this.tmpEGA_Cost) / 2.5f) * (ulong)this.m_Soldier[i]);
			array[1] += (long)((ulong)GameConstants.appCeil(GameConstants.appCeil(this.m_UnitResources[i].Stone * this.tmpEGA_Cost) / 2.5f) * (ulong)this.m_Soldier[i]);
			array[2] += (long)((ulong)GameConstants.appCeil(GameConstants.appCeil(this.m_UnitResources[i].Wood * this.tmpEGA_Cost) / 2.5f) * (ulong)this.m_Soldier[i]);
			array[3] += (long)((ulong)GameConstants.appCeil(GameConstants.appCeil(this.m_UnitResources[i].Ironore * this.tmpEGA_Cost) / 2.5f) * (ulong)this.m_Soldier[i]);
			array[4] += (long)((ulong)GameConstants.appCeil(GameConstants.appCeil(this.m_UnitResources[i].Money * this.tmpEGA_Cost) / 2.5f) * (ulong)this.m_Soldier[i]);
			if (i >= this.Count - num2 && i < this.Count)
			{
				num = num;
			}
			else
			{
				num += (double)((float)((ulong)this.m_UnitResources[i].Time * (ulong)this.m_Soldier[i]) * this.tmpEGA_T);
			}
			this.TreatmentNum += this.m_Soldier[i];
		}
		this.GUIM.SetDemandResourcesText(this.m_DResources.GetComponent<Transform>(), array);
		num = GameConstants.appCeil((float)num);
		num = GameConstants.appCeil((float)num / 25f);
		uint num5 = GameConstants.appCeil((float)(num * (double)this.tmpEGA));
		uint num6 = num5 / 3600u;
		this.Cstr_Time.ClearString();
		if (num6 < 24u)
		{
			this.Cstr_Time.IntToFormat((long)((ulong)(num6 % 60u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num5 / 60u % 60u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num5 % 60u)), 2, false);
			this.Cstr_Time.AppendFormat("{0:00}:{1:00}:{2:00}");
		}
		else if (this.GUIM.IsArabic)
		{
			this.Cstr_Time.IntToFormat((long)((ulong)(num6 % 24u)), 1, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num5 / 60u % 60u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num5 % 60u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num6 / 24u)), 1, false);
			this.Cstr_Time.AppendFormat("{0:00}:{1:00}:{2:00} {3}d");
		}
		else
		{
			this.Cstr_Time.IntToFormat((long)((ulong)(num6 / 24u)), 1, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num6 % 24u)), 1, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num5 / 60u % 60u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(num5 % 60u)), 2, false);
			this.Cstr_Time.AppendFormat("{0}d {1:00}:{2:00}:{3:00}");
		}
		this.text_Time.text = this.Cstr_Time.ToString();
		this.text_Time.SetAllDirty();
		this.text_Time.cachedTextGenerator.Invalidate();
		this.needDiamond = 0u;
		for (int j = 0; j < 5; j++)
		{
			if (array[j] > (long)((ulong)this.DM.Resource[j].Stock))
			{
				this.needDiamond += this.DM.GetResourceExchange((PriceListType)j, (uint)array[j] - this.DM.Resource[j].Stock);
			}
		}
		this.needDiamond += this.DM.GetResourceExchange(PriceListType.Time, num5);
		this.Cstr_Gemstone.ClearString();
		this.Cstr_Gemstone.IntToFormat((long)((ulong)this.needDiamond), 1, true);
		this.Cstr_Gemstone.AppendFormat("{0}");
		this.text_Gemstone.text = this.Cstr_Gemstone.ToString();
		this.text_Gemstone.SetAllDirty();
		this.text_Gemstone.cachedTextGenerator.Invalidate();
		this.Cstr_SliderQty.ClearString();
		this.Cstr_SliderQty.IntToFormat(this.TreatmentNum, 1, true);
		this.Cstr_SliderQty.AppendFormat("{0}");
		if (this.buildID != 12)
		{
			this.text_Slider.text = this.Cstr_SliderQty.ToString();
			this.text_Slider.SetAllDirty();
			this.text_Slider.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.text_TrapTotal.text = this.Cstr_SliderQty.ToString();
			this.text_TrapTotal.SetAllDirty();
			this.text_TrapTotal.cachedTextGenerator.Invalidate();
		}
		if (this.bNOInjured)
		{
			this.btn_ALL.ForTextChange(e_BtnType.e_ChangeText);
			this.btn_TreatmentCompleted.ForTextChange(e_BtnType.e_ChangeText);
			this.btn_Treatment.ForTextChange(e_BtnType.e_ChangeText);
		}
		else
		{
			if (this.buildID == 12 && (ulong)this.mTrapTreatmentMax == (ulong)this.TreatmentNum)
			{
				this.btn_ALL.ForTextChange(e_BtnType.e_ChangeText);
			}
			else
			{
				this.btn_ALL.ForTextChange(e_BtnType.e_Normal);
			}
			bool flag = true;
			for (int k = 0; k < 5; k++)
			{
				if (flag && this.m_DResources.BtnResources[k].gameObject.activeSelf)
				{
					flag = false;
					break;
				}
			}
			if (!bCheck && this.TreatmentNum == 0L)
			{
				this.btn_TreatmentCompleted.ForTextChange(e_BtnType.e_ChangeText);
				this.btn_Treatment.ForTextChange(e_BtnType.e_ChangeText);
			}
			if (this.TreatmentNum > 0L)
			{
				if (!flag)
				{
					this.btn_Treatment.ForTextChange(e_BtnType.e_ChangeText);
				}
				else
				{
					this.btn_Treatment.ForTextChange(e_BtnType.e_Normal);
				}
				this.btn_TreatmentCompleted.ForTextChange(e_BtnType.e_Normal);
				this.text_ALL.text = this.DM.mStringTable.GetStringByID(7010u);
				this.bClear = true;
			}
			else
			{
				this.text_ALL.text = this.DM.mStringTable.GetStringByID(3878u);
				this.bClear = false;
			}
			this.text_ALL.SetAllDirty();
			this.text_ALL.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06001CD0 RID: 7376 RVA: 0x003365A0 File Offset: 0x003347A0
	public void UpdateTarpMax()
	{
		this.mTrapTreatmentMax = this.DM.TrapTotal;
		if (this.DM.queueBarData[14].bActive)
		{
			this.mTrapTreatmentMax += this.DM.TrapTrainingQty;
		}
		if (this.DM.queueBarData[15].bActive)
		{
			this.mTrapTreatmentMax += this.DM.Trap_TreatmentQuantity;
		}
		this.mTrapTreatmentMax = this.HospitalNum - this.mTrapTreatmentMax;
	}

	// Token: 0x06001CD1 RID: 7377 RVA: 0x0033663C File Offset: 0x0033483C
	public override void OnOpen(int arg1, int arg2)
	{
		this.FrameMaterial = GUIManager.Instance.GetFrameMaterial();
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		Transform transform = base.gameObject.transform;
		this.B_ID = arg1;
		Array.Clear(this.m_Soldier, 0, this.m_Soldier.Length);
		Array.Clear(this.m_SoldierMax, 0, this.m_SoldierMax.Length);
		if (this.B_ID < GUIManager.Instance.BuildingData.AllBuildsData.Length)
		{
			this.buildID = GUIManager.Instance.BuildingData.AllBuildsData[this.B_ID].BuildID;
		}
		this.Pos[0] = -42f;
		this.Pos[1] = -61f;
		this.Pos[2] = -70f;
		this.Pos[3] = -80f;
		this.Pos[4] = -87f;
		this.Width[0] = 66f;
		this.Width[1] = 90f;
		this.Width[2] = 114f;
		this.Width[3] = 134f;
		this.Width[4] = 150f;
		if (this.buildID != 12)
		{
			uint effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_HOSPITAL_HEALING_SPEED);
			this.tmpEGA = 10000f / (10000u + effectBaseVal);
			uint effectBaseVal2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED);
			float num = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED_DEBUFF);
			float num2 = 10000u + effectBaseVal2 - num;
			if (num2 <= 100f)
			{
				num2 = 100f;
			}
			this.tmpEGA_T = 10000f / num2;
			this.buildTypeData = this.DM.BuildsTypeData.GetRecordByKey(7);
			this.Count = 16;
			this.HospitalNum = this.GetHospitalMaxCapacity();
			this.AssetName_D = "UI_arms";
			this.m_Arms = this.GUIM.AddSpriteAsset(this.AssetName_D);
		}
		else
		{
			this.HospitalNum = this.GetTrapCapacity();
			uint effectBaseVal2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAP_TRAINING_SPEED);
			this.tmpEGA_T = 10000f / (10000u + effectBaseVal2);
			this.UpdateTarpMax();
			this.AssetName_D = "UI_trap";
			this.m_Arms = this.GUIM.AddSpriteAsset(this.AssetName_D);
		}
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.AssetName = "BuildingWindow";
		this.m_BW = this.GUIM.AddSpriteAsset(this.AssetName);
		this.m_Mat = this.door.LoadMaterial();
		this.Cstr = StringManager.Instance.SpawnString(30);
		this.Cstr_SliderQty = StringManager.Instance.SpawnString(30);
		this.Cstr_Gemstone = StringManager.Instance.SpawnString(30);
		this.Cstr_Time = StringManager.Instance.SpawnString(30);
		this.Cstr_TimeBar = StringManager.Instance.SpawnString(30);
		this.Cstr_Msg = StringManager.Instance.SpawnString(30);
		for (int i = 0; i < 2; i++)
		{
			this.Cstr_TrapNum[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_InjuredTroop[i] = StringManager.Instance.SpawnString(30);
		}
		for (int j = 0; j < 5; j++)
		{
			this.Cstr_SliderMaxQty[j] = StringManager.Instance.SpawnString(30);
			this.Cstr_ItemSliderQty[j] = StringManager.Instance.SpawnString(30);
		}
		this.Tmp = transform.GetChild(0);
		this.Img_Base = this.Tmp.GetComponent<Image>();
		this.Img_Base.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_04");
		this.Img_Base.material = this.m_BW;
		if (this.buildID == 12)
		{
			this.Img_Base.gameObject.SetActive(true);
			this.Tmp1 = this.Tmp.GetChild(0);
			this.tmpimg = this.Tmp1.GetComponent<Image>();
			this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_19");
			this.tmpimg.material = this.m_BW;
			this.text_tmpStr[0] = this.Tmp1.GetChild(0).GetComponent<UIText>();
			this.text_tmpStr[0].font = this.TTFont;
			this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(3750u);
			this.AssetName1 = "UICityWall";
			this.GUIM.AddSpriteAsset(this.AssetName1);
			this.Tmp1 = this.Tmp.GetChild(1);
			this.tmpimg = this.Tmp1.GetComponent<Image>();
			this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName1, "UI_walllist_pic_04");
			this.tmpimg.material = this.GUIM.LoadMaterial(this.AssetName1, "UI_wall_list_m");
			this.Tmp1 = this.Tmp.GetChild(2);
			this.Img_Lock = this.Tmp1.GetComponent<Image>();
			this.Img_Lock.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_market_bar_01");
			this.Img_Lock.material = this.m_BW;
			this.btn_RD = this.Tmp1.GetChild(0).GetComponent<UIButton>();
			this.btn_RD.m_Handler = this;
			this.btn_RD.m_BtnID1 = 3;
			this.btn_RD.image.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_butt_07");
			this.btn_RD.image.material = this.m_BW;
			this.btn_RD.m_EffectType = e_EffectType.e_Scale;
			this.btn_RD.transition = Selectable.Transition.None;
			this.text_tmpStr[1] = this.Tmp1.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.text_tmpStr[1].font = this.TTFont;
			this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(3776u);
			this.tmpimg = this.Tmp1.GetChild(1).GetComponent<Image>();
			this.tmpimg.sprite = this.door.LoadSprite("UI_main_lock");
			this.tmpimg.material = this.m_Mat;
			this.text_tmpStr[2] = this.Tmp1.GetChild(2).GetComponent<UIText>();
			this.text_tmpStr[2].font = this.TTFont;
			this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(3760u);
			this.Tmp1 = this.Tmp.GetChild(3);
			this.tmpimg = this.Tmp1.GetComponent<Image>();
			this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_06");
			this.tmpimg.material = this.m_BW;
			this.tmpimg = this.Tmp1.GetChild(0).GetComponent<Image>();
			this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_13");
			this.tmpimg.material = this.m_BW;
			this.tmpimg = this.Tmp1.GetChild(1).GetComponent<Image>();
			this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_wall_trap_03");
			this.tmpimg.material = this.m_BW;
			this.tmpimg = this.Tmp1.GetChild(2).GetComponent<Image>();
			this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_15");
			this.tmpimg.material = this.m_BW;
			this.text_TrapTotal = this.Tmp1.GetChild(2).GetChild(0).GetComponent<UIText>();
			this.text_TrapTotal.font = this.TTFont;
			this.text_TrapTotal.text = this.TreatmentNum.ToString();
			this.text_tmpStr[3] = this.Tmp1.GetChild(3).GetComponent<UIText>();
			this.text_tmpStr[3].font = this.TTFont;
			this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(3779u);
			this.text_TrapNum[0] = this.Tmp1.GetChild(4).GetComponent<UIText>();
			this.text_TrapNum[0].font = this.TTFont;
			this.text_TrapNum[1] = this.Tmp1.GetChild(5).GetComponent<UIText>();
			this.text_TrapNum[1].font = this.TTFont;
			this.Cstr_TrapNum[0].ClearString();
			this.Cstr_TrapNum[0].IntToFormat((long)((ulong)this.DM.TrapHospitalTotal), 1, true);
			this.Cstr_TrapNum[0].AppendFormat("{0}");
			this.text_TrapNum[0].text = this.Cstr_TrapNum[0].ToString();
			this.Cstr_TrapNum[1].ClearString();
			this.Cstr_TrapNum[1].IntToFormat((long)((ulong)this.HospitalNum), 1, true);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_TrapNum[1].AppendFormat("{0} / ");
			}
			else
			{
				this.Cstr_TrapNum[1].AppendFormat(" / {0}");
			}
			this.text_TrapNum[1].text = this.Cstr_TrapNum[1].ToString();
			this.text_tmpStr[4] = this.Tmp1.GetChild(6).GetComponent<UIText>();
			this.text_tmpStr[4].font = this.TTFont;
			this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(3780u);
			this.Tmp1 = this.Tmp.GetChild(4);
			this.tmpimg = this.Tmp1.GetComponent<Image>();
			this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_divider_01");
			this.tmpimg.material = this.m_BW;
		}
		this.Tmp = transform.GetChild(1);
		this.BG = this.Tmp.GetComponent<Image>();
		this.BG.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_divider_02");
		this.BG.material = this.m_BW;
		this.Tmp1 = this.Tmp.GetChild(0);
		this.tmpimg = this.Tmp1.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_16");
		this.tmpimg.material = this.m_BW;
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.tmpimg = this.Tmp2.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_17");
		this.tmpimg.material = this.m_BW;
		this.Tmp2 = this.Tmp1.GetChild(1);
		this.tmpimg = this.Tmp2.GetComponent<Image>();
		this.tmpimg.sprite = this.door.LoadSprite("UI_main_money_02");
		this.tmpimg.material = this.m_Mat;
		this.tmpimg.SetNativeSize();
		this.Tmp2 = this.Tmp1.GetChild(2);
		this.text_Gemstone = this.Tmp2.GetComponent<UIText>();
		this.text_Gemstone.font = this.TTFont;
		this.Cstr_Gemstone.ClearString();
		this.Cstr_Gemstone.IntToFormat(0L, 1, true);
		this.Cstr_Gemstone.AppendFormat("{0}");
		this.text_Gemstone.text = this.Cstr_Gemstone.ToString();
		this.Tmp1 = this.Tmp.GetChild(1);
		this.tmpimg = this.Tmp1.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_16");
		this.tmpimg.material = this.m_BW;
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.tmpimg = this.Tmp2.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_17");
		this.tmpimg.material = this.m_BW;
		this.Tmp2 = this.Tmp1.GetChild(1);
		this.tmpimg = this.Tmp2.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_icon_10");
		this.tmpimg.material = this.m_BW;
		this.tmpimg.SetNativeSize();
		this.Tmp2 = this.Tmp1.GetChild(2);
		this.text_Time = this.Tmp2.GetComponent<UIText>();
		this.text_Time.font = this.TTFont;
		this.Tmp = transform.GetChild(2);
		this.m_DResources = this.Tmp.GetComponent<DemandResources>();
		this.GUIM.InitDemandResources(this.Tmp, 489f, 98f, true);
		for (int k = 0; k < 5; k++)
		{
			this.m_DResources.TextResources[k].fontSize = 14;
		}
		this.Tmp = transform.GetChild(3);
		this.btn_ALL = this.Tmp.GetComponent<UIButton>();
		this.btn_ALL.image.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_butt_07");
		this.btn_ALL.image.material = this.m_BW;
		this.btn_ALL.m_Handler = this;
		this.btn_ALL.m_BtnID1 = 0;
		this.btn_ALL.m_EffectType = e_EffectType.e_Scale;
		this.btn_ALL.transition = Selectable.Transition.None;
		this.Tmp1 = this.Tmp.GetChild(0);
		this.text_ALL = this.Tmp1.GetComponent<UIText>();
		this.text_ALL.font = this.TTFont;
		this.text_ALL.text = this.DM.mStringTable.GetStringByID(3878u);
		this.btn_ALL.m_Text = this.text_ALL;
		this.Tmp = transform.GetChild(4);
		this.btn_TreatmentCompleted = this.Tmp.GetComponent<UIButton>();
		this.btn_TreatmentCompleted.image.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_butt_07");
		this.btn_TreatmentCompleted.image.material = this.m_BW;
		this.btn_TreatmentCompleted.m_Handler = this;
		this.btn_TreatmentCompleted.m_BtnID1 = 2;
		this.btn_TreatmentCompleted.m_EffectType = e_EffectType.e_Scale;
		this.btn_TreatmentCompleted.transition = Selectable.Transition.None;
		this.Tmp1 = this.Tmp.GetChild(0);
		this.text_TreatmentCompleted = this.Tmp1.GetComponent<UIText>();
		this.text_TreatmentCompleted.font = this.TTFont;
		this.btn_TreatmentCompleted.m_Text = this.text_TreatmentCompleted;
		this.Tmp = transform.GetChild(5);
		this.btn_Treatment = this.Tmp.GetComponent<UIButton>();
		this.btn_Treatment.image.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_butt_07");
		this.btn_Treatment.image.material = this.m_BW;
		this.btn_Treatment.m_Handler = this;
		this.btn_Treatment.m_BtnID1 = 1;
		this.btn_Treatment.m_EffectType = e_EffectType.e_Scale;
		this.btn_Treatment.transition = Selectable.Transition.None;
		this.Tmp1 = this.Tmp.GetChild(0);
		this.text_Treatment = this.Tmp1.GetComponent<UIText>();
		this.text_Treatment.font = this.TTFont;
		this.btn_Treatment.m_Text = this.text_Treatment;
		if (this.buildID != 12)
		{
			this.text_TreatmentCompleted.text = this.DM.mStringTable.GetStringByID(3879u);
			this.text_Treatment.text = this.DM.mStringTable.GetStringByID(3880u);
		}
		else
		{
			this.text_TreatmentCompleted.text = this.DM.mStringTable.GetStringByID(3777u);
			this.text_Treatment.text = this.DM.mStringTable.GetStringByID(3778u);
		}
		this.Tmp = transform.GetChild(6);
		this.Img_Slider[0] = this.Tmp.GetComponent<Image>();
		this.Img_Slider[0].sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_15");
		this.Img_Slider[0].material = this.m_BW;
		this.Tmp1 = this.Tmp.GetChild(0);
		this.Img_Slider[1] = this.Tmp1.GetComponent<Image>();
		this.Img_Slider[1].sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_icon_01");
		this.Img_Slider[1].material = this.m_BW;
		this.Img_Slider[1].SetNativeSize();
		this.Tmp1 = this.Tmp.GetChild(1);
		this.Img_Slider[2] = this.Tmp1.GetComponent<Image>();
		this.Img_Slider[2].sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_13");
		this.Img_Slider[2].material = this.m_BW;
		this.Tmp1 = this.Tmp.GetChild(2);
		this.text_Slider = this.Tmp1.GetComponent<UIText>();
		this.text_Slider.font = this.TTFont;
		this.Tmp1 = this.Tmp.GetChild(3);
		this.text_InjuredTroops[0] = this.Tmp1.GetComponent<UIText>();
		this.text_InjuredTroops[0].font = this.TTFont;
		this.text_InjuredTroops[0].text = this.DM.mStringTable.GetStringByID(3932u);
		this.Tmp1 = this.Tmp.GetChild(4);
		this.text_InjuredTroops[1] = this.Tmp1.GetComponent<UIText>();
		this.text_InjuredTroops[1].font = this.TTFont;
		this.Tmp1 = this.Tmp.GetChild(5);
		this.text_InjuredTroops[2] = this.Tmp1.GetComponent<UIText>();
		this.text_InjuredTroops[2].font = this.TTFont;
		this.Tmp1 = this.Tmp.GetChild(6);
		this.text_InjuredTroops[3] = this.Tmp1.GetComponent<UIText>();
		this.text_InjuredTroops[3].font = this.TTFont;
		this.text_InjuredTroops[3].text = this.DM.mStringTable.GetStringByID((uint)this.buildTypeData.UIExplain);
		this.tmpRC = this.Tmp1.GetComponent<RectTransform>();
		this.Tmp = transform.GetChild(7);
		this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
		this.tmpimg = this.Tmp.gameObject.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_alp");
		this.tmpimg.material = this.m_BW;
		Transform child = transform.GetChild(8);
		this.Tmp = child.GetChild(0);
		this.tmpimg = this.Tmp.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_07");
		this.tmpimg.material = this.m_BW;
		this.Tmp = child.GetChild(1);
		this.m_UnitRS = this.Tmp.GetComponent<UnitResourcesSlider>();
		this.GUIM.InitUnitResourcesSlider(this.Tmp, eUnitSlider.Hospital, 0u, 1000u, 0.7f);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp, eUnitSliderSize.BtnIncrease, this.GUIM.LoadSprite(this.AssetName, "UI_main_strip_01"), this.m_BW);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp, eUnitSliderSize.BtnLessen, this.GUIM.LoadSprite(this.AssetName, "UI_main_strip_02"), this.m_BW);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp, eUnitSliderSize.Input, this.GUIM.LoadSprite(this.AssetName, "UI_main_strip_05"), this.m_BW);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp, eUnitSliderSize.m_sliderBG1, this.GUIM.LoadSprite(this.AssetName, "UI_main_strip_03"), this.m_BW);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp, eUnitSliderSize.m_sliderBG2, this.GUIM.LoadSprite(this.AssetName, "UI_main_strip_04"), this.m_BW);
		if (this.buildID == 12)
		{
			this.GUIM.SetUnitResourcesSliderImg(this.Tmp, eUnitSliderSize.m_micon, this.GUIM.LoadSprite(this.AssetName, "UI_wall_trap_03"), this.m_BW);
		}
		this.m_UnitRS.m_Handler = this;
		this.m_UnitRS.Type = 1;
		this.m_UnitRS.BtnInputText.m_Handler = this;
		this.m_UnitRS.BtnInputText.m_BtnID1 = 8;
		this.Tmp = child.GetChild(2);
		this.tmpimg = this.Tmp.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(10010);
		this.tmpimg.material = this.GUIM.m_IconSpriteAsset.GetMaterial();
		this.Tmp = child.GetChild(2).GetChild(0);
		this.tmpRC = this.Tmp.GetComponent<RectTransform>();
		this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
		this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		this.tmpimg = this.Tmp.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(10010);
		this.tmpimg.material = this.GUIM.m_IconSpriteAsset.GetMaterial();
		if (this.GUIM.IsArabic)
		{
			this.tmpimg.transform.localScale = new Vector3(-1f, this.tmpimg.transform.localScale.y, this.tmpimg.transform.localScale.z);
		}
		UIButton component = child.GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.SoundIndex = 64;
		this.Tmp = child.GetChild(2).GetChild(1);
		this.tmpimg = this.Tmp.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.LoadFrameSprite("hf003");
		this.tmpimg.material = this.FrameMaterial;
		this.tmpRC = this.Tmp.GetComponent<RectTransform>();
		this.tmpRC.anchorMin = Vector2.zero;
		this.tmpRC.anchorMax = new Vector2(1f, 1f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		this.Tmp = child.GetChild(3);
		this.tmpimg = this.Tmp.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_26");
		this.tmpimg.material = this.m_BW;
		this.Tmp1 = this.Tmp.GetChild(0);
		this.tmptext = this.Tmp1.GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.tmplist.Clear();
		this.mTreatmentCount = 0;
		UnitResources_H unitResources_H = default(UnitResources_H);
		this.InjuredNum = 0u;
		for (int l = 0; l < this.Count; l++)
		{
			this.m_Soldier[l] = 0L;
			if (this.DM.bSetExpediton)
			{
				this.m_Soldier[l] = (long)((ulong)this.DM.mExpeditionSoldierList[l]);
			}
			else
			{
				this.DM.mExpeditionSoldierList[l] = 0u;
			}
			if (this.buildID == 7)
			{
				ushort num3 = (ushort)(4 - l / 4 + l % 4 * 4);
				this.m_SoldierMax[l] = this.DM.mSoldier_Hospital[(int)(num3 - 1)];
				this.InjuredNum += this.DM.mSoldier_Hospital[(int)(num3 - 1)];
				this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey(num3);
			}
			else if (this.buildID == 12)
			{
				ushort num3 = (ushort)(4 - l / 3 + l % 3 * 4);
				this.m_SoldierMax[l] = this.DM.mTrap_Hospital[(int)(num3 - 1)];
				this.InjuredNum += this.DM.mTrap_Hospital[(int)(num3 - 1)];
				this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey(num3 + 16);
			}
			unitResources_H.Food = (uint)this.tmpSD.FoodRequire;
			unitResources_H.Stone = (uint)this.tmpSD.StoneRequire;
			unitResources_H.Wood = (uint)this.tmpSD.WoodRequire;
			unitResources_H.Ironore = (uint)this.tmpSD.IronRequire;
			unitResources_H.Money = (uint)this.tmpSD.MoneyRequire;
			unitResources_H.Time = (uint)this.tmpSD.TimeRequire;
			this.m_UnitResources[l] = unitResources_H;
			this.m_SoldierSprite[l] = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpSD.Icon);
			this.tmpStr.ClearString();
			this.tmpStr.IntToFormat((long)this.tmpSD.Tier, 1, false);
			this.tmpStr.AppendFormat("hf00{0}");
			this.m_SoldierSpriteFrame[l] = this.GUIM.LoadFrameSprite(this.tmpStr);
			this.m_SoldierName[l] = this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name);
			if (this.m_SoldierMax[l] > 0u)
			{
				this.ShowListIndex[this.mTreatmentCount] = (byte)(l + 1);
				this.mTreatmentCount++;
				this.tmplist.Add(91f);
				if (this.bNOInjured)
				{
					this.bNOInjured = false;
				}
			}
		}
		this.m_ScrollPanel.IntiScrollPanel(318f, 0f, 0f, this.tmplist, 5, this);
		this.m_ScrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
		this.Cstr_InjuredTroop[0].ClearString();
		this.Cstr_InjuredTroop[0].IntToFormat((long)((ulong)this.InjuredNum), 1, true);
		this.Cstr_InjuredTroop[0].AppendFormat("{0}");
		this.text_InjuredTroops[1].text = this.Cstr_InjuredTroop[0].ToString();
		this.text_InjuredTroops[1].SetAllDirty();
		this.text_InjuredTroops[1].cachedTextGenerator.Invalidate();
		this.Cstr_InjuredTroop[1].ClearString();
		this.Cstr_InjuredTroop[1].IntToFormat((long)((ulong)this.HospitalNum), 1, true);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_InjuredTroop[1].AppendFormat("{0} / ");
		}
		else
		{
			this.Cstr_InjuredTroop[1].AppendFormat(" / {0}");
		}
		this.text_InjuredTroops[2].text = this.Cstr_InjuredTroop[1].ToString();
		this.text_InjuredTroops[2].SetAllDirty();
		this.text_InjuredTroops[2].cachedTextGenerator.Invalidate();
		this.Tmp = transform.GetChild(9);
		this.Img_Treatment = this.Tmp.GetComponent<Image>();
		this.Img_Treatment.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_black");
		this.Img_Treatment.material = this.m_BW;
		this.Tmp1 = this.Tmp.GetChild(0);
		this.timeBar = this.Tmp1.GetComponent<UITimeBar>();
		this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
		this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
		this.timeBar.m_Handler = this;
		this.timeBar.m_TimeBarID = 1;
		this.text_timeBar[0] = this.Tmp1.GetChild(2).GetComponent<UIText>();
		this.text_timeBar[1] = this.Tmp1.GetChild(3).GetComponent<UIText>();
		this.Tmp1 = this.Tmp.GetChild(1);
		this.text_Treatmenting = this.Tmp1.GetComponent<UIText>();
		this.text_Treatmenting.font = this.TTFont;
		uint num4 = 0u;
		if (this.buildID == 7 && this.DM.queueBarData[13].bActive)
		{
			this.bTreatmenting = true;
			this.Img_Treatment.gameObject.SetActive(true);
			this.begin = this.DM.queueBarData[13].StartTime;
			this.target = this.begin + (long)((ulong)this.DM.queueBarData[13].TotalTime);
			this.notify = 0L;
			for (int m = 0; m < this.Count; m++)
			{
				num4 += this.DM.mTreatmentSoldier[m];
			}
			this.Cstr_TimeBar.ClearString();
			this.Cstr_TimeBar.IntToFormat((long)((ulong)num4), 1, true);
			this.Cstr_TimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(4046u));
			this.GUIM.SetTimerBar(this.timeBar, this.begin, this.target, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(4045u), this.Cstr_TimeBar.ToString());
			this.timeBar.gameObject.SetActive(true);
			this.text_Treatmenting.text = this.DM.mStringTable.GetStringByID(3814u);
			this.text_Treatmenting.gameObject.SetActive(true);
			if (this.bNOInjured)
			{
				this.bNOInjured = false;
			}
		}
		if (this.buildID == 12 && this.DM.queueBarData[15].bActive)
		{
			this.bTreatmenting = true;
			this.Img_Treatment.gameObject.SetActive(true);
			this.begin = this.DM.queueBarData[15].StartTime;
			this.target = this.begin + (long)((ulong)this.DM.queueBarData[15].TotalTime);
			this.notify = 0L;
			this.Cstr_TimeBar.ClearString();
			this.Cstr_TimeBar.IntToFormat((long)((ulong)this.DM.Trap_TreatmentQuantity), 1, true);
			this.Cstr_TimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(1047u));
			this.GUIM.SetTimerBar(this.timeBar, this.begin, this.target, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(1046u), this.Cstr_TimeBar.ToString());
			this.timeBar.gameObject.SetActive(true);
			this.text_Treatmenting.text = this.DM.mStringTable.GetStringByID(1045u);
			this.text_Treatmenting.gameObject.SetActive(true);
			if (this.bNOInjured)
			{
				this.bNOInjured = false;
			}
		}
		this.Img_Exit = transform.GetChild(10).GetComponent<Image>();
		this.Img_Exit.sprite = this.door.LoadSprite("UI_main_close_base");
		this.Img_Exit.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.Img_Exit.enabled = false;
		}
		this.btn_EXIT = transform.GetChild(10).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 4;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.m_Mat;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.Tmp = transform.GetChild(11);
		this.ImgDisbandblack = this.Tmp.GetComponent<Image>();
		this.ImgDisbandblack.sprite = this.door.LoadSprite("UI_main_black");
		this.ImgDisbandblack.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.Tmp.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.Tmp.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		HelperUIButton helperUIButton = this.ImgDisbandblack.gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID1 = 5;
		this.Tmp1 = this.Tmp.GetChild(0);
		this.tmpimg = this.Tmp1.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_29");
		this.tmpimg.material = this.m_BW;
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.tmpimg = this.Tmp2.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_title_orange");
		this.tmpimg.material = this.m_BW;
		this.text_Disband_Title = this.Tmp2.GetChild(0).GetComponent<UIText>();
		this.text_Disband_Title.font = this.TTFont;
		if (this.buildID == 7)
		{
			this.text_Disband_Title.text = this.DM.mStringTable.GetStringByID(5772u);
		}
		else
		{
			this.text_Disband_Title.text = this.DM.mStringTable.GetStringByID(3794u);
		}
		this.Tmp1 = this.Tmp.GetChild(1);
		this.tmpimg = this.Tmp1.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_06");
		this.tmpimg.material = this.m_BW;
		this.Tmp1 = this.Tmp.GetChild(2);
		this.tmpimg = this.Tmp1.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_13");
		this.tmpimg.material = this.m_BW;
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_Disband_Name = this.Tmp2.GetComponent<UIText>();
		this.text_Disband_Name.font = this.TTFont;
		this.text_Disband_Name.text = this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name);
		this.Tmp1 = this.Tmp.GetChild(3);
		this.ImgDisband_Item = this.Tmp1.GetComponent<Image>();
		this.ImgDisband_Item.material = this.m_Arms;
		if (this.GUIM.IsArabic)
		{
			this.ImgDisband_Item.transform.localScale = new Vector3(-1f, this.ImgDisband_Item.transform.localScale.y, this.ImgDisband_Item.transform.localScale.z);
		}
		this.Tmp1 = this.Tmp.GetChild(4);
		this.tmpimg = this.Tmp1.GetComponent<Image>();
		this.tmpimg.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_20");
		this.tmpimg.material = this.m_BW;
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_Disband_Num = this.Tmp2.GetComponent<UIText>();
		this.text_Disband_Num.font = this.TTFont;
		this.Tmp1 = this.Tmp.GetChild(5);
		this.m_DisbandSlider = this.Tmp1.GetComponent<UnitResourcesSlider>();
		num4 = 0u;
		this.GUIM.InitUnitResourcesSlider(this.Tmp1, eUnitSlider.Other, 0u, num4, 0.7f);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.BtnIncrease, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_01"), this.m_BW);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.BtnLessen, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_02"), this.m_BW);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.Input, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_05"), this.m_BW);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_sliderBG1, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_03"), this.m_BW);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_sliderBG2, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_04"), this.m_BW);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_Img, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_06"), this.m_BW);
		this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.m_Img, 5f, 52.5f, 22f, 28f, 0f, 0f);
		this.m_DisbandSlider.m_Handler = this;
		this.m_DisbandSlider.Type = 2;
		this.m_DisbandSlider.BtnInputText.m_Handler = this;
		this.m_DisbandSlider.BtnInputText.m_BtnID1 = 9;
		this.tmpRC = this.m_DisbandSlider.m_TotalText.transform.GetComponent<RectTransform>();
		this.tmpRC.sizeDelta = new Vector2(120f, this.tmpRC.sizeDelta.y);
		this.tmpRC.anchoredPosition = new Vector2(269f, this.tmpRC.anchoredPosition.y);
		this.DisbandSliderRT = this.m_DisbandSlider.GetComponent<Transform>().GetChild(3).GetComponent<RectTransform>();
		this.Tmp1 = this.Tmp.GetChild(6);
		this.btn_Disband = this.Tmp1.GetComponent<UIButton>();
		this.btn_Disband.m_Handler = this;
		this.btn_Disband.m_BtnID1 = 6;
		this.btn_Disband.image.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_butt_07");
		this.btn_Disband.image.material = this.m_BW;
		this.btn_Disband.m_EffectType = e_EffectType.e_Scale;
		this.btn_Disband.transition = Selectable.Transition.None;
		this.Tmp2 = this.Tmp1.GetChild(0);
		this.text_Disband = this.Tmp2.GetComponent<UIText>();
		this.text_Disband.font = this.TTFont;
		this.text_Disband.text = this.DM.mStringTable.GetStringByID(4050u);
		this.Tmp1 = this.Tmp.GetChild(7);
		this.btn_Disband_Exit = this.Tmp1.GetComponent<UIButton>();
		this.btn_Disband_Exit.m_Handler = this;
		this.btn_Disband_Exit.m_BtnID1 = 5;
		this.btn_Disband_Exit.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_Disband_Exit.image.material = this.m_Mat;
		this.btn_Disband_Exit.m_EffectType = e_EffectType.e_Scale;
		this.btn_Disband_Exit.transition = Selectable.Transition.None;
		this.Tmp = transform.GetChild(12);
		this.text_NoNeedTreatment = this.Tmp.GetComponent<UIText>();
		this.text_NoNeedTreatment.font = this.TTFont;
		if (this.buildID == 12)
		{
			this.Img_Slider[0].gameObject.SetActive(false);
			this.Img_Exit.gameObject.SetActive(true);
			this.btn_EXIT.gameObject.SetActive(true);
			if (this.DM.GetTechLevel(56) == 0)
			{
				this.Img_Lock.gameObject.SetActive(true);
				this.btn_ALL.gameObject.SetActive(false);
				this.btn_Treatment.gameObject.SetActive(false);
				this.btn_TreatmentCompleted.gameObject.SetActive(false);
				this.BG.gameObject.SetActive(false);
				this.m_DResources.gameObject.SetActive(false);
			}
			else
			{
				this.Img_Lock.gameObject.SetActive(false);
			}
			this.text_Disband.text = this.DM.mStringTable.GetStringByID(3772u);
		}
		if (this.buildID == 7)
		{
			this.text_NoNeedTreatment.text = this.DM.mStringTable.GetStringByID(3829u);
		}
		else if (this.buildID == 12 && !this.Img_Lock.IsActive())
		{
			this.text_NoNeedTreatment.text = this.DM.mStringTable.GetStringByID(3791u);
		}
		if (this.bNOInjured)
		{
			this.m_ScrollPanel.gameObject.SetActive(false);
			this.text_NoNeedTreatment.gameObject.SetActive(true);
		}
		if (this.DM.bSetExpediton)
		{
			this.m_ScrollPanel.GoTo(this.DM.mScroll_Idx);
			this.DM.bSetExpediton = false;
			this.SetDRformURS(true);
		}
		else
		{
			if (!this.bTreatmenting)
			{
				this.CheckAllMax(true);
			}
			else
			{
				this.SetbTreatmenting();
			}
			if (this.mTreatmentCount >= 5)
			{
				this.mTreatmentCount = 5;
			}
			for (int n = 0; n < this.mTreatmentCount; n++)
			{
				this.m_UnitRS_Item[n].MaxValue = (long)((ulong)this.m_SoldierMax[this.m_UnitRS_Item[n].m_ID]);
				this.m_UnitRS_Item[n].Value = this.m_Soldier[this.m_UnitRS_Item[n].m_ID];
				this.m_UnitRS_Item[n].m_slider.maxValue = this.m_SoldierMax[this.m_UnitRS_Item[n].m_ID];
				this.m_UnitRS_Item[n].m_slider.value = (double)this.m_Soldier[this.m_UnitRS_Item[n].m_ID];
				this.Cstr_ItemSliderQty[n].ClearString();
				StringManager.IntToStr(this.Cstr_ItemSliderQty[n], this.m_UnitRS_Item[n].Value, 1, true);
				this.m_UnitRS_Item[n].m_inputText.text = this.Cstr_ItemSliderQty[n].ToString();
				this.m_UnitRS_Item[n].m_inputText.SetAllDirty();
				this.m_UnitRS_Item[n].m_inputText.cachedTextGenerator.Invalidate();
			}
			this.SetDRformURS(false);
		}
		if (this.buildID == 7)
		{
			for (int num5 = 0; num5 < 16; num5++)
			{
				this.DM.mExpeditionSoldierList[num5] = (uint)this.m_Soldier[num5];
			}
		}
		else
		{
			for (int num6 = 0; num6 < 12; num6++)
			{
				this.DM.mExpeditionSoldierList[num6] = (uint)this.m_Soldier[num6];
			}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001CD2 RID: 7378 RVA: 0x0033938C File Offset: 0x0033758C
	public uint GetHospitalMaxCapacity()
	{
		ulong num = (ulong)DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_HOSPITAL_CAPACITY_PERCENT);
		ulong num2 = (ulong)DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_HOSPITAL_CAPACITY);
		return (uint)(num2 + num2 * num / 10000UL);
	}

	// Token: 0x06001CD3 RID: 7379 RVA: 0x003393D0 File Offset: 0x003375D0
	public uint GetTrapCapacity()
	{
		return DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAP_CAPACITY);
	}

	// Token: 0x06001CD4 RID: 7380 RVA: 0x003393E4 File Offset: 0x003375E4
	public bool CheckDiamondToSend()
	{
		bool result = false;
		long[] array = new long[6];
		this.needDiamond = 0u;
		this.TreatmentNum = 0L;
		for (int i = 0; i < this.Count; i++)
		{
			byte b = this.ShowListIndex[i] - 1;
			if (this.ShowListIndex[i] == 0)
			{
				break;
			}
			int num = (int)((3 - b / 4) * 4 + b % 4);
			if (this.buildID == 7)
			{
				uint num2 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM)(79 + num));
				if (num2 >= 9900u)
				{
					num2 = 9900u;
				}
				this.tmpEGA_Cost = 1f - num2 / 10000f;
			}
			else
			{
				this.tmpEGA_Cost = 1f;
			}
			array[0] += (long)((ulong)GameConstants.appCeil(this.m_UnitResources[(int)b].Food / 2.5f * this.tmpEGA_Cost * (float)this.m_Soldier[(int)b]));
			array[1] += (long)((ulong)GameConstants.appCeil(this.m_UnitResources[(int)b].Stone / 2.5f * this.tmpEGA_Cost * (float)this.m_Soldier[(int)b]));
			array[2] += (long)((ulong)GameConstants.appCeil(this.m_UnitResources[(int)b].Wood / 2.5f * this.tmpEGA_Cost * (float)this.m_Soldier[(int)b]));
			array[3] += (long)((ulong)GameConstants.appCeil(this.m_UnitResources[(int)b].Ironore / 2.5f * this.tmpEGA_Cost * (float)this.m_Soldier[(int)b]));
			array[4] += (long)((ulong)GameConstants.appCeil(this.m_UnitResources[(int)b].Money / 2.5f * this.tmpEGA_Cost * (float)this.m_Soldier[(int)b]));
			if ((this.buildID == 7 && b >= 12 && b < 16) || (this.buildID == 12 && b >= 9 && b <= 12))
			{
				long[] array2 = array;
				int num3 = 5;
				array2[num3] = array2[num3];
			}
			else
			{
				array[5] += (long)((float)((ulong)this.m_UnitResources[(int)b].Time * (ulong)this.m_Soldier[(int)b]) * this.tmpEGA_T);
			}
			this.TreatmentNum += this.m_Soldier[(int)b];
		}
		for (int j = 0; j < 5; j++)
		{
			if (array[j] > (long)((ulong)this.DM.Resource[j].Stock))
			{
				this.needDiamond += this.DM.GetResourceExchange((PriceListType)j, (uint)array[j] - this.DM.Resource[j].Stock);
			}
		}
		array[5] = (long)((ulong)GameConstants.appCeil((float)array[5]));
		array[5] = (long)((ulong)GameConstants.appCeil((float)array[5] / 25f));
		uint num4 = GameConstants.appCeil((float)array[5] * this.tmpEGA);
		this.needDiamond += this.DM.GetResourceExchange(PriceListType.Time, num4);
		if (this.TreatmentNum > 0L && this.DM.RoleAttr.Diamond >= this.needDiamond)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x06001CD5 RID: 7381 RVA: 0x0033974C File Offset: 0x0033794C
	public byte CheckAllMax(bool bset = true)
	{
		this.TreatmentNum = 0L;
		byte b = 0;
		uint num = this.mTrapTreatmentMax;
		uint[] array = new uint[5];
		uint[] array2 = new uint[5];
		uint[] array3 = new uint[5];
		for (int i = 0; i < 5; i++)
		{
			array[i] = this.DM.Resource[i].Stock;
		}
		for (int j = 0; j < this.Count; j++)
		{
			byte b2 = 0;
			byte b3 = this.ShowListIndex[j] - 1;
			if (this.ShowListIndex[j] == 0)
			{
				break;
			}
			int num2 = (int)((3 - b3 / 4) * 4 + b3 % 4);
			if (this.buildID == 7)
			{
				uint num3 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM)(79 + num2));
				if (num3 >= 9900u)
				{
					num3 = 9900u;
				}
				this.tmpEGA_Cost = 1f - num3 / 10000f;
			}
			else
			{
				this.tmpEGA_Cost = 1f;
			}
			array3[0] = this.m_UnitResources[(int)b3].Food;
			array3[1] = this.m_UnitResources[(int)b3].Stone;
			array3[2] = this.m_UnitResources[(int)b3].Wood;
			array3[3] = this.m_UnitResources[(int)b3].Ironore;
			array3[4] = this.m_UnitResources[(int)b3].Money;
			for (int k = 0; k < 5; k++)
			{
				if (array3[k] != 0u)
				{
					uint num4 = GameConstants.appCeil(GameConstants.appCeil(array3[k] * this.tmpEGA_Cost) / 2.5f) * this.m_SoldierMax[(int)b3];
					if (array[k] == 0u)
					{
						b2 = 2;
						array2[k] = 0u;
						if (b != 2)
						{
							b = 2;
						}
					}
					else if (array[k] < num4 && b2 < 2)
					{
						b2 = 1;
						if (this.buildID == 12 && array[k] / GameConstants.appCeil(array3[k] / 2.5f) > num)
						{
							array2[k] = num;
						}
						else
						{
							array2[k] = array[k] / GameConstants.appCeil(GameConstants.appCeil(array3[k] * this.tmpEGA_Cost) / 2.5f);
						}
						if (b < 1)
						{
							b = 1;
						}
					}
					else if (this.buildID == 12 && this.m_SoldierMax[(int)b3] > num)
					{
						array2[k] = num;
					}
					else
					{
						array2[k] = this.m_SoldierMax[(int)b3];
					}
				}
			}
			if (bset)
			{
				if (b2 == 0)
				{
					if (this.buildID == 12 && this.m_SoldierMax[(int)b3] > num)
					{
						this.m_Soldier[(int)b3] = (long)((ulong)num);
					}
					else
					{
						this.m_Soldier[(int)b3] = (long)((ulong)this.m_SoldierMax[(int)b3]);
					}
				}
				else if (b2 == 1)
				{
					this.m_Soldier[(int)b3] = (long)((ulong)array2[0]);
					for (int l = 1; l < 5; l++)
					{
						if (array3[l] != 0u && this.m_Soldier[(int)b3] > (long)((ulong)array2[l]))
						{
							this.m_Soldier[(int)b3] = (long)((ulong)array2[l]);
						}
					}
				}
				this.DM.mExpeditionSoldierList[(int)b3] = (uint)this.m_Soldier[(int)b3];
				this.TreatmentNum += this.m_Soldier[(int)b3];
				if (this.buildID == 12)
				{
					num -= (uint)this.m_Soldier[(int)b3];
				}
				array[0] -= (uint)((ulong)GameConstants.appCeil(GameConstants.appCeil(this.m_UnitResources[(int)b3].Food * this.tmpEGA_Cost) / 2.5f) * (ulong)this.m_Soldier[(int)b3]);
				array[1] -= (uint)((ulong)GameConstants.appCeil(GameConstants.appCeil(this.m_UnitResources[(int)b3].Stone * this.tmpEGA_Cost) / 2.5f) * (ulong)this.m_Soldier[(int)b3]);
				array[2] -= (uint)((ulong)GameConstants.appCeil(GameConstants.appCeil(this.m_UnitResources[(int)b3].Wood * this.tmpEGA_Cost) / 2.5f) * (ulong)this.m_Soldier[(int)b3]);
				array[3] -= (uint)((ulong)GameConstants.appCeil(GameConstants.appCeil(this.m_UnitResources[(int)b3].Ironore * this.tmpEGA_Cost) / 2.5f) * (ulong)this.m_Soldier[(int)b3]);
				array[4] -= (uint)((ulong)GameConstants.appCeil(GameConstants.appCeil(this.m_UnitResources[(int)b3].Money * this.tmpEGA_Cost) / 2.5f) * (ulong)this.m_Soldier[(int)b3]);
			}
		}
		if (this.bNOInjured)
		{
			this.btn_ALL.ForTextChange(e_BtnType.e_ChangeText);
		}
		else
		{
			this.btn_ALL.ForTextChange(e_BtnType.e_Normal);
		}
		return b;
	}

	// Token: 0x06001CD6 RID: 7382 RVA: 0x00339C64 File Offset: 0x00337E64
	public void SetbTreatmenting()
	{
		this.TreatmentNum = 0L;
		for (int i = 0; i < this.Count; i++)
		{
			byte b = this.ShowListIndex[i] - 1;
			if (this.ShowListIndex[i] == 0)
			{
				break;
			}
			if (this.buildID == 7)
			{
				byte b2 = 4 - b / 4 + b % 4 * 4;
				this.m_Soldier[(int)b] = (long)((ulong)this.DM.mTreatmentSoldier[(int)(b2 - 1)]);
			}
			else
			{
				byte b2 = 4 - b / 3 + b % 3 * 4;
				this.m_Soldier[(int)b] = (long)((ulong)this.DM.mRepairTrap[(int)(b2 - 1)]);
			}
		}
	}

	// Token: 0x06001CD7 RID: 7383 RVA: 0x00339D10 File Offset: 0x00337F10
	public void SetALLMax()
	{
		byte b = 0;
		this.TreatmentNum = 0L;
		uint num = this.mTrapTreatmentMax;
		for (int i = 0; i < this.Count; i++)
		{
			if (b != 0)
			{
				break;
			}
			byte b2 = this.ShowListIndex[i] - 1;
			if (this.ShowListIndex[i] == 0)
			{
				break;
			}
			if (this.buildID == 12 && this.m_SoldierMax[(int)b2] > num)
			{
				this.m_Soldier[(int)b2] = (long)((ulong)num);
			}
			else
			{
				this.m_Soldier[(int)b2] = (long)((ulong)this.m_SoldierMax[(int)b2]);
			}
			this.DM.mExpeditionSoldierList[(int)b2] = (uint)this.m_Soldier[(int)b2];
			num -= (uint)this.m_Soldier[(int)b2];
			if (num < 0u)
			{
				num = 0u;
			}
			this.TreatmentNum += this.m_Soldier[(int)b2];
		}
		if (this.bNOInjured)
		{
			this.btn_ALL.ForTextChange(e_BtnType.e_ChangeText);
		}
		else if (this.buildID == 12 && (ulong)this.mTrapTreatmentMax == (ulong)this.TreatmentNum)
		{
			this.btn_ALL.ForTextChange(e_BtnType.e_ChangeText);
		}
		else
		{
			this.btn_ALL.ForTextChange(e_BtnType.e_Normal);
		}
	}

	// Token: 0x06001CD8 RID: 7384 RVA: 0x00339E44 File Offset: 0x00338044
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.bNOInjured)
			{
				return;
			}
			if (this.buildID == 12 && (ulong)this.mTrapTreatmentMax == (ulong)this.TreatmentNum)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(3755u), 255, true);
				return;
			}
			if (!this.bClear)
			{
				this.bClear = true;
				this.SetALLMax();
				this.text_ALL.text = this.DM.mStringTable.GetStringByID(7010u);
			}
			else
			{
				this.bClear = false;
				for (int i = 0; i < this.Count; i++)
				{
					this.m_Soldier[i] = 0L;
					this.DM.mExpeditionSoldierList[i] = (uint)this.m_Soldier[i];
				}
				this.text_ALL.text = this.DM.mStringTable.GetStringByID(3878u);
			}
			this.text_ALL.SetAllDirty();
			this.text_ALL.cachedTextGenerator.Invalidate();
			if (this.mTreatmentCount >= 5)
			{
				this.mTreatmentCount = 5;
			}
			for (int j = 0; j < this.mTreatmentCount; j++)
			{
				this.m_UnitRS_Item[j].MaxValue = (long)((ulong)this.m_SoldierMax[this.m_UnitRS_Item[j].m_ID]);
				this.m_UnitRS_Item[j].Value = this.m_Soldier[this.m_UnitRS_Item[j].m_ID];
				this.m_UnitRS_Item[j].m_slider.maxValue = this.m_SoldierMax[this.m_UnitRS_Item[j].m_ID];
				this.m_UnitRS_Item[j].m_slider.value = (double)this.m_Soldier[this.m_UnitRS_Item[j].m_ID];
				this.Cstr_ItemSliderQty[j].ClearString();
				StringManager.IntToStr(this.Cstr_ItemSliderQty[j], this.m_UnitRS_Item[j].Value, 1, true);
				this.m_UnitRS_Item[j].m_inputText.text = this.Cstr_ItemSliderQty[j].ToString();
				this.m_UnitRS_Item[j].m_inputText.SetAllDirty();
				this.m_UnitRS_Item[j].m_inputText.cachedTextGenerator.Invalidate();
			}
			this.SetDRformURS(false);
			break;
		case 1:
			if (this.bNOInjured)
			{
				return;
			}
			if (sender.m_BtnType == e_BtnType.e_Normal && GUIManager.Instance.ShowUILock(EUILock.Hospital))
			{
				MessagePacket messagePacket = new MessagePacket(1024);
				if (this.buildID == 7)
				{
					this.DM.TreatmentQuantity = 0u;
					messagePacket.Protocol = Protocol._MSG_REQUEST_HEALINGTROOP;
					messagePacket.AddSeqId();
					for (int k = 0; k < 16; k++)
					{
						int num = (3 - k % 4) * 4 + k / 4;
						messagePacket.Add((uint)this.m_Soldier[num]);
						this.DM.TreatmentQuantity += (uint)this.m_Soldier[num];
					}
				}
				else
				{
					this.DM.Trap_TreatmentQuantity = 0u;
					messagePacket.Protocol = Protocol._MSG_REQUEST_REPAIRTRAP;
					messagePacket.AddSeqId();
					for (int l = 0; l < 12; l++)
					{
						int num2 = (3 - l % 4) * 3 + l / 4;
						messagePacket.Add((uint)this.m_Soldier[num2]);
						this.DM.Trap_TreatmentQuantity += (uint)this.m_Soldier[num2];
					}
				}
				messagePacket.Send(false);
			}
			else if (sender.m_BtnType == e_BtnType.e_ChangeText)
			{
				if (this.TreatmentNum == 0L)
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5701u), 255, true);
				}
				else
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4888u), 255, true);
				}
			}
			this.SetDRformURS(false);
			break;
		case 2:
			if (this.bNOInjured)
			{
				return;
			}
			if (this.TreatmentNum == 0L)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5701u), 255, true);
				return;
			}
			if (!this.CheckDiamondToSend())
			{
				this.Cstr_Msg.ClearString();
				this.Cstr_Msg.StringToFormat(this.DM.mStringTable.GetStringByID(3880u));
				this.Cstr_Msg.AppendFormat(this.DM.mStringTable.GetStringByID(3857u));
				this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966u), this.Cstr_Msg.ToString(), this.DM.mStringTable.GetStringByID(3968u), this, 3, 0, true, false, false, false, false);
				this.Cstr_Gemstone.ClearString();
				this.Cstr_Gemstone.IntToFormat((long)((ulong)this.needDiamond), 1, true);
				this.Cstr_Gemstone.AppendFormat("{0}");
				this.text_Gemstone.text = this.Cstr_Gemstone.ToString();
				this.text_Gemstone.SetAllDirty();
				this.text_Gemstone.cachedTextGenerator.Invalidate();
				return;
			}
			if (sender.m_BtnType == e_BtnType.e_Normal)
			{
				if (this.buildID == 7)
				{
					if (!this.GUIM.OpenCheckCrystal(this.needDiamond, 5, (int)((int)this.m_eWindow << 16 | EGUIWindow.UI_VipLevelUp), -1))
					{
						this.SendInstHealing();
					}
				}
				else if (!this.GUIM.OpenCheckCrystal(this.needDiamond, 5, (int)((int)this.m_eWindow << 16 | EGUIWindow.UI_VipLevelUp), -1))
				{
					this.SendInstTrackFix();
				}
			}
			break;
		case 3:
			this.GUIM.OpenTechTree(56, false);
			break;
		case 4:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 5:
			this.ImgDisbandblack.gameObject.SetActive(false);
			break;
		case 6:
			if (sender.m_BtnType == e_BtnType.e_Normal)
			{
				if (this.buildID == 7)
				{
					this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5772u), this.DM.mStringTable.GetStringByID(5773u), 6, 0, this.DM.mStringTable.GetStringByID(4053u), this.DM.mStringTable.GetStringByID(4054u));
				}
				else
				{
					this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(3794u), this.DM.mStringTable.GetStringByID(3795u), 7, 0, this.DM.mStringTable.GetStringByID(4053u), this.DM.mStringTable.GetStringByID(4054u));
				}
			}
			break;
		case 7:
		{
			Transform parent = sender.gameObject.transform.parent;
			ushort num3 = (ushort)(this.ShowListIndex[parent.GetComponent<ScrollPanelItem>().m_BtnID1] - 1);
			this.tmpString.Length = 0;
			ushort num4;
			uint num5;
			if (this.buildID == 7)
			{
				num4 = 4 - num3 / 4 + num3 % 4 * 4;
				num5 = this.DM.mSoldier_Hospital[(int)(num4 - 1)];
			}
			else
			{
				num4 = 4 - num3 / 3 + num3 % 3 * 4 + 16;
				num5 = this.DM.mTrap_Hospital[(int)(num4 - 17)];
			}
			GameConstants.FormatValue(this.tmpString, num5);
			this.text_Disband_Num.text = this.tmpString.ToString();
			this.m_DisbandSlider.m_TotalText.text = this.tmpString.ToString();
			this.m_DisbandSlider.MaxValue = (long)((ulong)num5);
			this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey(num4);
			this.mDisband_Kind = this.tmpSD.SoldierKind;
			this.mDisband_Rank = this.tmpSD.Tier;
			this.tmpString.Length = 0;
			this.tmpString.AppendFormat("q{0}", this.tmpSD.Icon);
			this.ImgDisband_Item.sprite = this.GUIM.LoadSprite(this.AssetName_D, this.tmpString.ToString());
			this.text_Disband_Name.text = this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name);
			num4 = 0;
			if (num5 / 1000u > 0u)
			{
				if (num5 / 100000000u > 0u)
				{
					num4 = 4;
				}
				else if (num5 / 10000000u > 0u)
				{
					num4 = 3;
				}
				else if (num5 / 100000u > 0u)
				{
					num4 = 2;
				}
				else
				{
					num4 = 1;
				}
			}
			this.DisbandSliderRT.anchoredPosition = new Vector2(this.Pos[(int)num4], this.DisbandSliderRT.anchoredPosition.y);
			this.DisbandSliderRT.sizeDelta = new Vector2(this.Width[(int)num4], this.DisbandSliderRT.sizeDelta.y);
			this.Cstr.ClearString();
			StringManager.IntToStr(this.Cstr, 0L, 1, true);
			this.m_DisbandSlider.m_slider.maxValue = num5;
			this.m_DisbandSlider.m_slider.value = 0.0;
			this.m_DisbandSlider.m_inputText.text = this.Cstr.ToString();
			this.m_DisbandSlider.m_inputText.SetAllDirty();
			this.m_DisbandSlider.m_inputText.cachedTextGenerator.Invalidate();
			this.btn_Disband.ForTextChange(e_BtnType.e_ChangeText);
			this.ImgDisbandblack.gameObject.SetActive(true);
			break;
		}
		case 8:
			this.GUIM.m_UICalculator.m_CalculatorHandler = this;
			this.GUIM.m_UICalculator.OpenCalculator(this.m_UnitRS_Item[sender.m_BtnID2].MaxValue, this.m_UnitRS_Item[sender.m_BtnID2].Value, 270f, 0f, this.m_UnitRS_Item[sender.m_BtnID2], 0L);
			break;
		case 9:
			this.GUIM.m_UICalculator.m_CalculatorHandler = this;
			this.GUIM.m_UICalculator.OpenCalculator(this.m_DisbandSlider.MaxValue, this.m_DisbandSlider.Value, -283f, 0f, this.m_DisbandSlider, 0L);
			break;
		}
	}

	// Token: 0x06001CD9 RID: 7385 RVA: 0x0033A8F8 File Offset: 0x00338AF8
	private void SendInstHealing()
	{
		if (!GUIManager.Instance.ShowUILock(EUILock.Hospital))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_INSTANTHEALING;
		messagePacket.AddSeqId();
		for (int i = 0; i < this.Count; i++)
		{
			int num = (3 - i % 4) * 4 + i / 4;
			messagePacket.Add((uint)this.m_Soldier[num]);
		}
		messagePacket.Send(false);
	}

	// Token: 0x06001CDA RID: 7386 RVA: 0x0033A970 File Offset: 0x00338B70
	private void SendInstTrackFix()
	{
		if (!GUIManager.Instance.ShowUILock(EUILock.Hospital))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_INSTANTREPAIRTRAP;
		messagePacket.AddSeqId();
		for (int i = 0; i < this.Count; i++)
		{
			int num = (3 - i % 4) * 3 + i / 4;
			messagePacket.Add((uint)this.m_Soldier[num]);
		}
		messagePacket.Send(false);
	}

	// Token: 0x06001CDB RID: 7387 RVA: 0x0033A9E8 File Offset: 0x00338BE8
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		int num = (int)(this.ShowListIndex[dataIdx] - 1);
		if (this.m_UnitRS_Item[panelObjectIdx] == null)
		{
			ScrollPanelItem component = item.GetComponent<ScrollPanelItem>();
			component.m_BtnID2 = panelObjectIdx;
			this.m_UnitRS_Item[panelObjectIdx] = item.transform.GetChild(1).GetComponent<UnitResourcesSlider>();
			this.m_UnitRS_Item[panelObjectIdx].m_Handler = this;
			this.m_UnitRS_Item[panelObjectIdx].m_ID = num;
			this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = this.m_SoldierMax[num];
			this.m_UnitRS_Item[panelObjectIdx].m_slider.value = (double)this.m_Soldier[num];
			this.btn_ItemInput[panelObjectIdx] = this.m_UnitRS_Item[panelObjectIdx].BtnInputText;
			this.btn_ItemInput[panelObjectIdx].m_Handler = this;
			this.btn_ItemInput[panelObjectIdx].m_BtnID2 = panelObjectIdx;
			this.btn_Item[panelObjectIdx] = item.transform.GetChild(2).GetComponent<UIButton>();
			this.btn_Item[panelObjectIdx].m_Handler = this;
			this.btn_Item[panelObjectIdx].m_BtnID1 = 7;
			this.Tmp = item.transform.GetChild(2).GetChild(0);
			this.Img_Soldier_Item[panelObjectIdx] = this.Tmp.GetComponent<Image>();
			this.Tmp = item.transform.GetChild(2).GetChild(1);
			this.Img_Soldier_ItemFrame[panelObjectIdx] = this.Tmp.GetComponent<Image>();
			this.Img_Soldier_ItemFrame[panelObjectIdx].material = this.FrameMaterial;
			this.Tmp = item.transform.GetChild(3).GetChild(0);
			this.text_Soldier_Item[panelObjectIdx] = this.Tmp.GetComponent<UIText>();
			this.text_Soldier_Item[panelObjectIdx].font = this.TTFont;
		}
		else
		{
			this.m_UnitRS_Item[panelObjectIdx].m_ID = num;
			if (this.m_SoldierMax[num] < this.m_UnitRS_Item[panelObjectIdx].m_slider.value)
			{
				this.m_UnitRS_Item[panelObjectIdx].m_slider.value = (double)this.m_Soldier[num];
				this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = this.m_SoldierMax[num];
			}
			else
			{
				this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = this.m_SoldierMax[num];
				this.m_UnitRS_Item[panelObjectIdx].m_slider.value = (double)this.m_Soldier[num];
			}
		}
		this.m_UnitRS_Item[panelObjectIdx].MaxValue = (long)((ulong)this.m_SoldierMax[num]);
		this.m_UnitRS_Item[panelObjectIdx].Value = this.m_Soldier[num];
		this.Cstr_SliderMaxQty[panelObjectIdx].ClearString();
		this.Cstr_SliderMaxQty[panelObjectIdx].IntToFormat((long)((ulong)this.m_SoldierMax[num]), 1, true);
		this.Cstr_SliderMaxQty[panelObjectIdx].AppendFormat("{0}");
		this.m_UnitRS_Item[panelObjectIdx].m_TotalText.text = this.Cstr_SliderMaxQty[panelObjectIdx].ToString();
		this.m_UnitRS_Item[panelObjectIdx].m_TotalText.SetAllDirty();
		this.m_UnitRS_Item[panelObjectIdx].m_TotalText.cachedTextGenerator.Invalidate();
		this.Img_Soldier_Item[panelObjectIdx].sprite = this.m_SoldierSprite[num];
		this.Img_Soldier_ItemFrame[panelObjectIdx].sprite = this.m_SoldierSpriteFrame[num];
		this.text_Soldier_Item[panelObjectIdx].text = this.m_SoldierName[num];
		this.Cstr_ItemSliderQty[panelObjectIdx].ClearString();
		this.Cstr_ItemSliderQty[panelObjectIdx].IntToFormat(this.m_Soldier[num], 1, true);
		this.Cstr_ItemSliderQty[panelObjectIdx].AppendFormat("{0}");
		this.m_UnitRS_Item[panelObjectIdx].m_inputText.text = this.Cstr_ItemSliderQty[panelObjectIdx].ToString();
		this.m_UnitRS_Item[panelObjectIdx].m_inputText.SetAllDirty();
		this.m_UnitRS_Item[panelObjectIdx].m_inputText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001CDC RID: 7388 RVA: 0x0033ADAC File Offset: 0x00338FAC
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001CDD RID: 7389 RVA: 0x0033ADB0 File Offset: 0x00338FB0
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			switch (arg1)
			{
			case 1:
				if (GUIManager.Instance.ShowUILock(EUILock.Hospital))
				{
					MessagePacket messagePacket = new MessagePacket(1024);
					messagePacket.Protocol = Protocol._MSG_REQUEST_CANCELHEALING;
					messagePacket.AddSeqId();
					messagePacket.Send(false);
				}
				break;
			case 2:
				this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 13, false);
				break;
			case 3:
				MallManager.Instance.Send_Mall_Info();
				break;
			case 4:
				if (GUIManager.Instance.ShowUILock(EUILock.Hospital))
				{
					MessagePacket messagePacket2 = new MessagePacket(1024);
					messagePacket2.Protocol = Protocol._MSG_REQUEST_CANCELHEALING;
					messagePacket2.AddSeqId();
					messagePacket2.Send(false);
				}
				break;
			case 5:
				if (GUIManager.Instance.ShowUILock(EUILock.Hospital))
				{
					MessagePacket messagePacket3 = new MessagePacket(1024);
					messagePacket3.Protocol = Protocol._MSG_REQUEST_CANCELREPAIRTRAP;
					messagePacket3.AddSeqId();
					messagePacket3.Send(false);
				}
				break;
			case 6:
				if (GUIManager.Instance.ShowUILock(EUILock.Hospital))
				{
					byte data = this.mDisband_Kind;
					MessagePacket messagePacket4 = new MessagePacket(1024);
					messagePacket4.Protocol = Protocol._MSG_REQUEST_GIVEUP_HEALING;
					messagePacket4.AddSeqId();
					messagePacket4.Add(data);
					messagePacket4.Add(this.mDisband_Rank - 1);
					messagePacket4.Add((uint)this.m_DisbandSlider.Value);
					messagePacket4.Send(false);
					this.ImgDisbandblack.gameObject.SetActive(false);
				}
				break;
			case 7:
				if (GUIManager.Instance.ShowUILock(EUILock.Hospital))
				{
					byte b = this.mDisband_Kind;
					MessagePacket messagePacket5 = new MessagePacket(1024);
					messagePacket5.Protocol = Protocol._MSG_REQUEST_GIVEUP_TRAP_REPAIR;
					b -= 4;
					messagePacket5.AddSeqId();
					messagePacket5.Add(b);
					messagePacket5.Add(this.mDisband_Rank - 1);
					messagePacket5.Add((uint)this.m_DisbandSlider.Value);
					messagePacket5.Send(false);
					this.ImgDisbandblack.gameObject.SetActive(false);
				}
				break;
			}
		}
	}

	// Token: 0x06001CDE RID: 7390 RVA: 0x0033AFD0 File Offset: 0x003391D0
	public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
	{
		URS.m_slider.value = (double)mValue;
		URS.SliderValueChange();
	}

	// Token: 0x06001CDF RID: 7391 RVA: 0x0033AFE8 File Offset: 0x003391E8
	private void Start()
	{
		if (this.buildID != 12)
		{
			this.baseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
			this.baseBuild.m_Handler = this;
			byte buildLv = (this.B_ID >= this.GUIM.BuildingData.AllBuildsData.Length) ? 0 : this.GUIM.BuildingData.AllBuildsData[this.B_ID].Level;
			this.baseBuild.InitBuildingWindow(7, (ushort)this.B_ID, 1, buildLv);
			this.baseBuild.baseTransform.SetAsFirstSibling();
		}
	}

	// Token: 0x06001CE0 RID: 7392 RVA: 0x0033B090 File Offset: 0x00339290
	public override void OnClose()
	{
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
		if (this.AssetName != null)
		{
			GUIManager.Instance.RemoveSpriteAsset(this.AssetName);
		}
		if (this.AssetName1 != null)
		{
			GUIManager.Instance.RemoveSpriteAsset(this.AssetName1);
		}
		if (this.AssetName_D != null)
		{
			GUIManager.Instance.RemoveSpriteAsset(this.AssetName_D);
		}
		this.tmplist = null;
		if (this.Cstr != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr);
		}
		if (this.Cstr_SliderQty != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_SliderQty);
		}
		if (this.Cstr_Gemstone != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Gemstone);
		}
		if (this.Cstr_Time != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Time);
		}
		if (this.Cstr_TimeBar != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_TimeBar);
		}
		if (this.Cstr_Msg != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Msg);
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.Cstr_TrapNum[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_TrapNum[i]);
			}
			if (this.Cstr_InjuredTroop[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_InjuredTroop[i]);
			}
		}
		for (int j = 0; j < 5; j++)
		{
			if (this.Cstr_SliderMaxQty[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_SliderMaxQty[j]);
			}
			if (this.Cstr_ItemSliderQty[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemSliderQty[j]);
			}
		}
		if (!this.DM.bSetExpediton)
		{
			this.DM.mScroll_Idx = 0;
			this.DM.mScroll_Y = 0f;
		}
		else
		{
			this.DM.mScroll_Idx = this.m_ScrollPanel.GetTopIdx();
			for (int k = 0; k < 16; k++)
			{
				this.DM.mExpeditionSoldierList[k] = (uint)this.m_Soldier[k];
			}
		}
		this.GUIM.RemoverTimeBaarToList(this.timeBar);
		this.GUIM.ClearCalculator();
	}

	// Token: 0x06001CE1 RID: 7393 RVA: 0x0033B2EC File Offset: 0x003394EC
	public void OnTimer(UITimeBar sender)
	{
		if (this.timeBar != null)
		{
			this.timeBar.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001CE2 RID: 7394 RVA: 0x0033B31C File Offset: 0x0033951C
	public void OnNotify(UITimeBar sender)
	{
	}

	// Token: 0x06001CE3 RID: 7395 RVA: 0x0033B320 File Offset: 0x00339520
	public void RefreshSoldierUI()
	{
		this.tmplist.Clear();
		this.mTreatmentCount = 0;
		this.InjuredNum = 0u;
		this.bNOInjured = true;
		if (this.buildID == 7)
		{
			for (int i = 0; i < 16; i++)
			{
				this.m_Soldier[i] = (long)((ulong)this.DM.mExpeditionSoldierList[i]);
				ushort num = (ushort)(4 - i / 4 + i % 4 * 4);
				this.m_SoldierMax[i] = this.DM.mSoldier_Hospital[(int)(num - 1)];
				if (this.m_Soldier[i] > (long)((ulong)this.m_SoldierMax[i]))
				{
					this.m_Soldier[i] = (long)((ulong)this.m_SoldierMax[i]);
					this.DM.mExpeditionSoldierList[i] = (uint)this.m_Soldier[i];
				}
				this.InjuredNum += this.DM.mSoldier_Hospital[(int)(num - 1)];
				if (this.m_SoldierMax[i] > 0u)
				{
					this.ShowListIndex[this.mTreatmentCount] = (byte)(i + 1);
					this.mTreatmentCount++;
					this.tmplist.Add(91f);
					if (this.bNOInjured)
					{
						this.bNOInjured = false;
					}
				}
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, true, true);
		}
		else
		{
			for (int j = 0; j < 12; j++)
			{
				this.m_Soldier[j] = (long)((ulong)this.DM.mExpeditionSoldierList[j]);
				ushort num = (ushort)(4 - j / 3 + j % 3 * 4);
				this.m_SoldierMax[j] = this.DM.mTrap_Hospital[(int)(num - 1)];
				if (this.m_Soldier[j] > (long)((ulong)this.m_SoldierMax[j]))
				{
					this.m_Soldier[j] = (long)((ulong)this.m_SoldierMax[j]);
					this.DM.mExpeditionSoldierList[j] = (uint)this.m_Soldier[j];
				}
				this.InjuredNum += this.DM.mTrap_Hospital[(int)(num - 1)];
				if (this.m_SoldierMax[j] > 0u)
				{
					this.ShowListIndex[this.mTreatmentCount] = (byte)(j + 1);
					this.mTreatmentCount++;
					this.tmplist.Add(91f);
					if (this.bNOInjured)
					{
						this.bNOInjured = false;
					}
				}
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, true, true);
		}
		if (this.bNOInjured && this.baseBuild != null && (this.baseBuild.buildType == e_BuildType.Normal || this.baseBuild.buildType == e_BuildType.SelfUpgradeing || this.baseBuild.buildType == e_BuildType.SelfBackOuting))
		{
			this.text_NoNeedTreatment.gameObject.SetActive(true);
		}
		else
		{
			this.text_NoNeedTreatment.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001CE4 RID: 7396 RVA: 0x0033B5E8 File Offset: 0x003397E8
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_Hospital:
			this.RefreshSoldierUI();
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
		default:
			switch (networkNews)
			{
			case NetworkNews.Login:
			case NetworkNews.Refresh:
				if (this.baseBuild != null)
				{
					this.baseBuild.MyUpdate(0, false);
				}
				this.RefreshSoldierUI();
				this.SetDRformURS(true);
				break;
			default:
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
					if (this.baseBuild != null)
					{
						this.baseBuild.Refresh_FontTexture();
					}
					if (this.m_DResources != null)
					{
						this.m_DResources.Refresh_FontTexture();
					}
					if (this.m_UnitRS != null)
					{
						this.m_UnitRS.Refresh_FontTexture();
					}
					if (this.m_DisbandSlider != null)
					{
						this.m_DisbandSlider.Refresh_FontTexture();
					}
					for (int i = 0; i < 5; i++)
					{
						if (this.m_UnitRS_Item[i] != null)
						{
							this.m_UnitRS_Item[i].Refresh_FontTexture();
						}
					}
					if (this.timeBar != null && this.timeBar.enabled)
					{
						this.timeBar.Refresh_FontTexture();
					}
				}
				break;
			}
			break;
		case NetworkNews.Refresh_AttribEffectVal:
			if (this.buildID == 7)
			{
				uint effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_HOSPITAL_HEALING_SPEED);
				this.tmpEGA = 10000f / (10000u + effectBaseVal);
				this.HospitalNum = this.GetHospitalMaxCapacity();
			}
			else
			{
				this.HospitalNum = this.GetTrapCapacity();
				this.UpdateTarpMax();
			}
			if (this.baseBuild != null)
			{
				this.baseBuild.MyUpdate(0, false);
			}
			this.SetDRformURS(false);
			break;
		}
	}

	// Token: 0x06001CE5 RID: 7397 RVA: 0x0033B810 File Offset: 0x00339A10
	public void Refresh_FontTexture()
	{
		if (this.text_ALL != null && this.text_ALL.enabled)
		{
			this.text_ALL.enabled = false;
			this.text_ALL.enabled = true;
		}
		if (this.text_Treatment != null && this.text_Treatment.enabled)
		{
			this.text_Treatment.enabled = false;
			this.text_Treatment.enabled = true;
		}
		if (this.text_TreatmentCompleted != null && this.text_TreatmentCompleted.enabled)
		{
			this.text_TreatmentCompleted.enabled = false;
			this.text_TreatmentCompleted.enabled = true;
		}
		if (this.text_Gemstone != null && this.text_Gemstone.enabled)
		{
			this.text_Gemstone.enabled = false;
			this.text_Gemstone.enabled = true;
		}
		if (this.text_Time != null && this.text_Time.enabled)
		{
			this.text_Time.enabled = false;
			this.text_Time.enabled = true;
		}
		if (this.text_Slider != null && this.text_Slider.enabled)
		{
			this.text_Slider.enabled = false;
			this.text_Slider.enabled = true;
		}
		if (this.text_NoNeedTreatment != null && this.text_NoNeedTreatment.enabled)
		{
			this.text_NoNeedTreatment.enabled = false;
			this.text_NoNeedTreatment.enabled = true;
		}
		if (this.text_Treatmenting != null && this.text_Treatmenting.enabled)
		{
			this.text_Treatmenting.enabled = false;
			this.text_Treatmenting.enabled = true;
		}
		if (this.text_TrapTotal != null && this.text_TrapTotal.enabled)
		{
			this.text_TrapTotal.enabled = false;
			this.text_TrapTotal.enabled = true;
		}
		if (this.text_Disband_Name != null && this.text_Disband_Name.enabled)
		{
			this.text_Disband_Name.enabled = false;
			this.text_Disband_Name.enabled = true;
		}
		if (this.text_Disband_Num != null && this.text_Disband_Num.enabled)
		{
			this.text_Disband_Num.enabled = false;
			this.text_Disband_Num.enabled = true;
		}
		if (this.text_Disband_Title != null && this.text_Disband_Title.enabled)
		{
			this.text_Disband_Title.enabled = false;
			this.text_Disband_Title.enabled = true;
		}
		if (this.text_Disband != null && this.text_Disband.enabled)
		{
			this.text_Disband.enabled = false;
			this.text_Disband.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_TrapNum[i] != null && this.text_TrapNum[i].enabled)
			{
				this.text_TrapNum[i].enabled = false;
				this.text_TrapNum[i].enabled = true;
			}
			if (this.text_timeBar[i] != null && this.text_timeBar[i].enabled)
			{
				this.text_timeBar[i].enabled = false;
				this.text_timeBar[i].enabled = true;
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (this.text_InjuredTroops[j] != null && this.text_InjuredTroops[j].enabled)
			{
				this.text_InjuredTroops[j].enabled = false;
				this.text_InjuredTroops[j].enabled = true;
			}
		}
		for (int k = 0; k < 5; k++)
		{
			if (this.text_Soldier_Item[k] != null && this.text_Soldier_Item[k].enabled)
			{
				this.text_Soldier_Item[k].enabled = false;
				this.text_Soldier_Item[k].enabled = true;
			}
			if (this.text_tmpStr[k] != null && this.text_tmpStr[k].enabled)
			{
				this.text_tmpStr[k].enabled = false;
				this.text_tmpStr[k].enabled = true;
			}
		}
	}

	// Token: 0x06001CE6 RID: 7398 RVA: 0x0033BC80 File Offset: 0x00339E80
	public override void UpdateUI(int arg1, int arg2)
	{
		if (this.buildID == 7 && this.baseBuild == null)
		{
			return;
		}
		switch (arg1)
		{
		case 1:
			this.HospitalNum = 0u;
			if (this.buildID == 7)
			{
				this.HospitalNum = this.GetHospitalMaxCapacity();
				this.text_InjuredTroops[1].gameObject.SetActive(true);
				this.Cstr_InjuredTroop[0].ClearString();
				this.Cstr_InjuredTroop[0].IntToFormat((long)((ulong)this.InjuredNum), 1, true);
				this.Cstr_InjuredTroop[0].AppendFormat("{0}");
				this.text_InjuredTroops[1].text = this.Cstr_InjuredTroop[0].ToString();
				this.text_InjuredTroops[1].SetAllDirty();
				this.text_InjuredTroops[1].cachedTextGenerator.Invalidate();
				this.Cstr_InjuredTroop[1].ClearString();
				this.Cstr_InjuredTroop[1].IntToFormat((long)((ulong)this.HospitalNum), 1, true);
				if (this.GUIM.IsArabic)
				{
					this.Cstr_InjuredTroop[1].AppendFormat("{0} / ");
				}
				else
				{
					this.Cstr_InjuredTroop[1].AppendFormat(" / {0}");
				}
				this.text_InjuredTroops[2].text = this.Cstr_InjuredTroop[1].ToString();
				this.text_InjuredTroops[2].SetAllDirty();
				this.text_InjuredTroops[2].cachedTextGenerator.Invalidate();
				this.baseBuild.MyUpdate(0, false);
			}
			else if (this.buildID == 12)
			{
				this.HospitalNum = this.GetTrapCapacity();
				this.Cstr_TrapNum[0].ClearString();
				this.Cstr_TrapNum[0].IntToFormat((long)((ulong)this.DM.TrapHospitalTotal), 1, true);
				this.Cstr_TrapNum[0].AppendFormat("{0}");
				this.text_TrapNum[0].text = this.Cstr_TrapNum[0].ToString();
				this.text_TrapNum[0].SetAllDirty();
				this.text_TrapNum[0].cachedTextGenerator.Invalidate();
				this.Cstr_TrapNum[1].ClearString();
				this.Cstr_TrapNum[1].IntToFormat((long)((ulong)this.HospitalNum), 1, true);
				if (this.GUIM.IsArabic)
				{
					this.Cstr_TrapNum[1].AppendFormat("{0} / ");
				}
				else
				{
					this.Cstr_TrapNum[1].AppendFormat(" / {0}");
				}
				this.text_TrapNum[1].text = this.Cstr_TrapNum[1].ToString();
				this.text_TrapNum[1].SetAllDirty();
				this.text_TrapNum[1].cachedTextGenerator.Invalidate();
			}
			if (this.InjuredNum == 0u)
			{
				this.btn_ALL.ForTextChange(e_BtnType.e_ChangeText);
				this.bNOInjured = true;
			}
			break;
		case 2:
			this.bTreatmenting = true;
			if (this.bTreatmenting)
			{
				this.Img_Treatment.gameObject.SetActive(true);
				if (this.buildID == 7)
				{
					if (this.DM.queueBarData[13].bActive)
					{
						this.begin = this.DM.queueBarData[13].StartTime;
						this.target = this.begin + (long)((ulong)this.DM.queueBarData[13].TotalTime);
						this.notify = 0L;
						uint num = 0u;
						for (int i = 0; i < this.Count; i++)
						{
							num += this.DM.mTreatmentSoldier[i];
						}
						this.Cstr_TimeBar.ClearString();
						this.Cstr_TimeBar.IntToFormat((long)((ulong)num), 1, true);
						this.Cstr_TimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(4046u));
						this.GUIM.SetTimerBar(this.timeBar, this.begin, this.target, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(4045u), this.Cstr_TimeBar.ToString());
						this.timeBar.gameObject.SetActive(true);
						this.text_Treatmenting.text = this.DM.mStringTable.GetStringByID(3814u);
					}
				}
				else if (this.DM.queueBarData[15].bActive)
				{
					this.begin = this.DM.queueBarData[15].StartTime;
					this.target = this.begin + (long)((ulong)this.DM.queueBarData[15].TotalTime);
					this.notify = 0L;
					this.Cstr_TimeBar.ClearString();
					this.Cstr_TimeBar.IntToFormat((long)((ulong)this.DM.Trap_TreatmentQuantity), 1, true);
					this.Cstr_TimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(1047u));
					this.GUIM.SetTimerBar(this.timeBar, this.begin, this.target, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(1046u), this.Cstr_TimeBar.ToString());
					this.timeBar.gameObject.SetActive(true);
					this.text_Treatmenting.text = this.DM.mStringTable.GetStringByID(1045u);
				}
				this.text_Treatmenting.gameObject.SetActive(true);
			}
			break;
		case 3:
			this.bTreatmenting = false;
			this.Img_Treatment.gameObject.SetActive(false);
			this.timeBar.gameObject.SetActive(false);
			this.text_Treatmenting.gameObject.SetActive(false);
			break;
		case 4:
			this.UpdateTarpMax();
			break;
		default:
			if (arg1 == 100)
			{
				if (this.buildID == 7)
				{
					this.SendInstHealing();
				}
				else
				{
					this.SendInstTrackFix();
				}
			}
			break;
		}
	}

	// Token: 0x06001CE7 RID: 7399 RVA: 0x0033C278 File Offset: 0x0033A478
	public void Onfunc(UITimeBar sender)
	{
		if (sender.m_TimerSpriteType == eTimerSpriteType.Speed)
		{
			if (this.buildID == 7)
			{
				this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 13, false);
			}
			else
			{
				this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 15, false);
			}
		}
	}

	// Token: 0x06001CE8 RID: 7400 RVA: 0x0033C2C8 File Offset: 0x0033A4C8
	public void OnCancel(UITimeBar sender)
	{
		if (this.buildID == 7)
		{
			this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4993u), this.DM.mStringTable.GetStringByID(4994u), 4, 0, this.DM.mStringTable.GetStringByID(4995u), this.DM.mStringTable.GetStringByID(4996u));
		}
		else
		{
			this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(3785u), this.DM.mStringTable.GetStringByID(3786u), 5, 0, this.DM.mStringTable.GetStringByID(4995u), this.DM.mStringTable.GetStringByID(4996u));
		}
	}

	// Token: 0x040057E3 RID: 22499
	private DataManager DM;

	// Token: 0x040057E4 RID: 22500
	private GUIManager GUIM;

	// Token: 0x040057E5 RID: 22501
	private UIButton btn_ALL;

	// Token: 0x040057E6 RID: 22502
	private UIButton btn_Treatment;

	// Token: 0x040057E7 RID: 22503
	private UIButton btn_TreatmentCompleted;

	// Token: 0x040057E8 RID: 22504
	private UIButton btn_RD;

	// Token: 0x040057E9 RID: 22505
	private UIButton btn_EXIT;

	// Token: 0x040057EA RID: 22506
	private UIButton btn_Disband_Exit;

	// Token: 0x040057EB RID: 22507
	private UIButton btn_Disband;

	// Token: 0x040057EC RID: 22508
	private UIButton[] btn_Item = new UIButton[5];

	// Token: 0x040057ED RID: 22509
	private UIButton[] btn_ItemInput = new UIButton[5];

	// Token: 0x040057EE RID: 22510
	private Image BG;

	// Token: 0x040057EF RID: 22511
	private Image Img_Base;

	// Token: 0x040057F0 RID: 22512
	private Image Img_Lock;

	// Token: 0x040057F1 RID: 22513
	private Image Img_Exit;

	// Token: 0x040057F2 RID: 22514
	private Image Img_Treatment;

	// Token: 0x040057F3 RID: 22515
	private Image ImgDisbandblack;

	// Token: 0x040057F4 RID: 22516
	private Image ImgDisband_Item;

	// Token: 0x040057F5 RID: 22517
	private Image[] Img_Slider = new Image[3];

	// Token: 0x040057F6 RID: 22518
	private Image[] Img_Soldier_Item = new Image[5];

	// Token: 0x040057F7 RID: 22519
	private Image[] Img_Soldier_ItemFrame = new Image[5];

	// Token: 0x040057F8 RID: 22520
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040057F9 RID: 22521
	private CScrollRect m_ScrollRect;

	// Token: 0x040057FA RID: 22522
	private DemandResources m_DResources;

	// Token: 0x040057FB RID: 22523
	private UnitResourcesSlider m_UnitRS;

	// Token: 0x040057FC RID: 22524
	private UnitResourcesSlider m_DisbandSlider;

	// Token: 0x040057FD RID: 22525
	private UnitResourcesSlider[] m_UnitRS_Item = new UnitResourcesSlider[5];

	// Token: 0x040057FE RID: 22526
	private UIText text_ALL;

	// Token: 0x040057FF RID: 22527
	private UIText text_Treatment;

	// Token: 0x04005800 RID: 22528
	private UIText text_TreatmentCompleted;

	// Token: 0x04005801 RID: 22529
	private UIText text_Gemstone;

	// Token: 0x04005802 RID: 22530
	private UIText text_Time;

	// Token: 0x04005803 RID: 22531
	private UIText text_Slider;

	// Token: 0x04005804 RID: 22532
	private UIText text_NoNeedTreatment;

	// Token: 0x04005805 RID: 22533
	private UIText text_Treatmenting;

	// Token: 0x04005806 RID: 22534
	private UIText text_TrapTotal;

	// Token: 0x04005807 RID: 22535
	private UIText text_Disband_Name;

	// Token: 0x04005808 RID: 22536
	private UIText text_Disband_Num;

	// Token: 0x04005809 RID: 22537
	private UIText text_Disband_Title;

	// Token: 0x0400580A RID: 22538
	private UIText text_Disband;

	// Token: 0x0400580B RID: 22539
	private UIText[] text_TrapNum = new UIText[2];

	// Token: 0x0400580C RID: 22540
	private UIText[] text_InjuredTroops = new UIText[4];

	// Token: 0x0400580D RID: 22541
	private UIText[] text_Soldier_Item = new UIText[5];

	// Token: 0x0400580E RID: 22542
	private UIText[] text_tmpStr = new UIText[5];

	// Token: 0x0400580F RID: 22543
	private UIText[] text_timeBar = new UIText[2];

	// Token: 0x04005810 RID: 22544
	private Transform Tmp;

	// Token: 0x04005811 RID: 22545
	private Transform Tmp1;

	// Token: 0x04005812 RID: 22546
	private Transform Tmp2;

	// Token: 0x04005813 RID: 22547
	private RectTransform DisbandSliderRT;

	// Token: 0x04005814 RID: 22548
	public BuildTypeData buildTypeData;

	// Token: 0x04005815 RID: 22549
	private BuildingWindow baseBuild;

	// Token: 0x04005816 RID: 22550
	private StringBuilder tmpString = new StringBuilder();

	// Token: 0x04005817 RID: 22551
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x04005818 RID: 22552
	private SoldierData tmpSD;

	// Token: 0x04005819 RID: 22553
	private UITimeBar timeBar;

	// Token: 0x0400581A RID: 22554
	private uint HospitalNum;

	// Token: 0x0400581B RID: 22555
	private uint InjuredNum;

	// Token: 0x0400581C RID: 22556
	private long TreatmentNum;

	// Token: 0x0400581D RID: 22557
	public UnitResources_H[] m_UnitResources = new UnitResources_H[16];

	// Token: 0x0400581E RID: 22558
	private long[] m_Soldier = new long[16];

	// Token: 0x0400581F RID: 22559
	private uint[] m_SoldierMax = new uint[16];

	// Token: 0x04005820 RID: 22560
	private string[] m_SoldierName = new string[16];

	// Token: 0x04005821 RID: 22561
	private Sprite[] m_SoldierSprite = new Sprite[16];

	// Token: 0x04005822 RID: 22562
	private Sprite[] m_SoldierSpriteFrame = new Sprite[16];

	// Token: 0x04005823 RID: 22563
	private byte[] ShowListIndex = new byte[16];

	// Token: 0x04005824 RID: 22564
	private bool bTreatmenting;

	// Token: 0x04005825 RID: 22565
	private bool bNOInjured = true;

	// Token: 0x04005826 RID: 22566
	private bool bClear;

	// Token: 0x04005827 RID: 22567
	private Material FrameMaterial;

	// Token: 0x04005828 RID: 22568
	private Material m_BW;

	// Token: 0x04005829 RID: 22569
	private Material m_Arms;

	// Token: 0x0400582A RID: 22570
	private Material m_Mat;

	// Token: 0x0400582B RID: 22571
	private RectTransform tmpRC;

	// Token: 0x0400582C RID: 22572
	private Image tmpimg;

	// Token: 0x0400582D RID: 22573
	private UIText tmptext;

	// Token: 0x0400582E RID: 22574
	private Door door;

	// Token: 0x0400582F RID: 22575
	private string AssetName;

	// Token: 0x04005830 RID: 22576
	private string AssetName1;

	// Token: 0x04005831 RID: 22577
	private string AssetName_D;

	// Token: 0x04005832 RID: 22578
	private int B_ID;

	// Token: 0x04005833 RID: 22579
	private List<float> tmplist = new List<float>();

	// Token: 0x04005834 RID: 22580
	private long begin;

	// Token: 0x04005835 RID: 22581
	private long target;

	// Token: 0x04005836 RID: 22582
	private long notify;

	// Token: 0x04005837 RID: 22583
	private int mTreatmentCount;

	// Token: 0x04005838 RID: 22584
	private int Count = 12;

	// Token: 0x04005839 RID: 22585
	private ushort buildID;

	// Token: 0x0400583A RID: 22586
	private float tmpEGA = 1f;

	// Token: 0x0400583B RID: 22587
	private float tmpEGA_T = 1f;

	// Token: 0x0400583C RID: 22588
	private float[] Pos = new float[5];

	// Token: 0x0400583D RID: 22589
	private float[] Width = new float[5];

	// Token: 0x0400583E RID: 22590
	private uint mTrapTreatmentMax;

	// Token: 0x0400583F RID: 22591
	private uint needDiamond;

	// Token: 0x04005840 RID: 22592
	private byte mDisband_Kind;

	// Token: 0x04005841 RID: 22593
	private byte mDisband_Rank;

	// Token: 0x04005842 RID: 22594
	private CString tmpStr = StringManager.Instance.StaticString1024();

	// Token: 0x04005843 RID: 22595
	private CString Cstr;

	// Token: 0x04005844 RID: 22596
	private CString Cstr_SliderQty;

	// Token: 0x04005845 RID: 22597
	private CString Cstr_Gemstone;

	// Token: 0x04005846 RID: 22598
	private CString Cstr_Time;

	// Token: 0x04005847 RID: 22599
	private CString Cstr_TimeBar;

	// Token: 0x04005848 RID: 22600
	private CString Cstr_Msg;

	// Token: 0x04005849 RID: 22601
	private CString[] Cstr_TrapNum = new CString[2];

	// Token: 0x0400584A RID: 22602
	private CString[] Cstr_InjuredTroop = new CString[2];

	// Token: 0x0400584B RID: 22603
	private CString[] Cstr_SliderMaxQty = new CString[5];

	// Token: 0x0400584C RID: 22604
	private CString[] Cstr_ItemSliderQty = new CString[5];

	// Token: 0x0400584D RID: 22605
	private float tmpEGA_Cost = 1f;
}
