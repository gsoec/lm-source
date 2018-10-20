using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200054F RID: 1359
public class UIExpedition : GUIWindow, IComparer<byte>, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUICalculatorHandler, IUIUnitRSliderHandler
{
	// Token: 0x06001AF2 RID: 6898 RVA: 0x002DBBF8 File Offset: 0x002D9DF8
	public int Compare(byte x, byte y)
	{
		if (this.bSpeed)
		{
			return this.SpeedCompare(x, y);
		}
		return this.LoadCompare(x, y);
	}

	// Token: 0x06001AF3 RID: 6899 RVA: 0x002DBC18 File Offset: 0x002D9E18
	public int SpeedCompare(byte x, byte y)
	{
		if (x == y)
		{
			return 0;
		}
		Soldier_H soldier_H = this.m_SoldierData[(int)x];
		Soldier_H soldier_H2 = this.m_SoldierData[(int)y];
		if (soldier_H.Speed < soldier_H2.Speed)
		{
			return 1;
		}
		if (soldier_H.Speed > soldier_H2.Speed)
		{
			return -1;
		}
		return 0;
	}

	// Token: 0x06001AF4 RID: 6900 RVA: 0x002DBC80 File Offset: 0x002D9E80
	public int LoadCompare(byte x, byte y)
	{
		Soldier_H soldier_H = this.m_SoldierData[(int)x];
		Soldier_H soldier_H2 = this.m_SoldierData[(int)y];
		if (soldier_H.Traffic < soldier_H2.Traffic)
		{
			return 1;
		}
		if (soldier_H.Traffic > soldier_H2.Traffic)
		{
			return -1;
		}
		return 0;
	}

	// Token: 0x06001AF5 RID: 6901 RVA: 0x002DBCDC File Offset: 0x002D9EDC
	public void OnVauleChang(UnitResourcesSlider sender)
	{
		long num = this.ExpeditionNum - this.m_Soldier[sender.m_ID];
		if (num + sender.Value > (long)((ulong)this.Hero_Total + (ulong)((long)this.mExpeditionlimit)))
		{
			double num2 = (double)((ulong)this.Hero_Total + (ulong)((long)this.mExpeditionlimit) - (ulong)num);
			if (num2 >= 0.0)
			{
				sender.m_slider.value = num2;
				return;
			}
			sender.Value = 0L;
			sender.m_slider.value = 0.0;
		}
		this.Cstr_Soldier_Text[(int)sender.Type].ClearString();
		this.Cstr_Soldier_Text[(int)sender.Type].IntToFormat(sender.Value, 1, true);
		this.Cstr_Soldier_Text[(int)sender.Type].AppendFormat("{0}");
		sender.m_inputText.text = this.Cstr_Soldier_Text[(int)sender.Type].ToString();
		sender.m_inputText.SetAllDirty();
		sender.m_inputText.cachedTextGenerator.Invalidate();
		this.m_Soldier[sender.m_ID] = sender.Value;
		if (sender.Value != 0L)
		{
			sender.m_inputText.color = this.mtextColor;
		}
		else
		{
			sender.m_inputText.color = Color.white;
		}
		this.Cstr_Soldier_ItemNum[(int)sender.Type].ClearString();
		this.Cstr_Soldier_ItemNum[(int)sender.Type].IntToFormat((long)((ulong)this.m_SoldierMax[sender.m_ID].Value[0] - (ulong)this.m_Soldier[sender.m_ID]), 1, true);
		this.Cstr_Soldier_ItemNum[(int)sender.Type].AppendFormat("{0}");
		this.Text_Soldier_ItemNum[(int)sender.Type].text = this.Cstr_Soldier_ItemNum[(int)sender.Type].ToString();
		this.Text_Soldier_ItemNum[(int)sender.Type].SetAllDirty();
		this.Text_Soldier_ItemNum[(int)sender.Type].cachedTextGenerator.Invalidate();
		this.SetDRformURS(sender.m_ID);
	}

	// Token: 0x06001AF6 RID: 6902 RVA: 0x002DBEE4 File Offset: 0x002DA0E4
	public void OnTextChang(UnitResourcesSlider sender)
	{
		long num = this.ExpeditionNum - this.m_Soldier[sender.m_ID];
		if (num + sender.Value > (long)((ulong)this.Hero_Total + (ulong)((long)this.mExpeditionlimit)))
		{
			sender.Value = (long)((ulong)this.Hero_Total + (ulong)((long)this.mExpeditionlimit) - (ulong)num);
			sender.m_slider.value = (double)sender.Value;
		}
		this.Cstr_Soldier_Text[(int)sender.Type].ClearString();
		this.Cstr_Soldier_Text[(int)sender.Type].IntToFormat(sender.Value, 1, true);
		this.Cstr_Soldier_Text[(int)sender.Type].AppendFormat("{0}");
		sender.m_inputText.text = this.Cstr_Soldier_Text[(int)sender.Type].ToString();
		sender.m_inputText.SetAllDirty();
		sender.m_inputText.cachedTextGenerator.Invalidate();
		this.m_Soldier[sender.m_ID] = sender.Value;
		if (sender.Value != 0L)
		{
			sender.m_inputText.color = this.mtextColor;
		}
		else
		{
			sender.m_inputText.color = Color.white;
		}
		this.Cstr_Soldier_ItemNum[(int)sender.Type].ClearString();
		this.Cstr_Soldier_ItemNum[(int)sender.Type].IntToFormat((long)((ulong)this.m_SoldierMax[sender.m_ID].Value[0] - (ulong)this.m_Soldier[sender.m_ID]), 1, true);
		this.Cstr_Soldier_ItemNum[(int)sender.Type].AppendFormat("{0}");
		this.Text_Soldier_ItemNum[(int)sender.Type].text = this.Cstr_Soldier_ItemNum[(int)sender.Type].ToString();
		this.Text_Soldier_ItemNum[(int)sender.Type].SetAllDirty();
		this.Text_Soldier_ItemNum[(int)sender.Type].cachedTextGenerator.Invalidate();
		this.SetDRformURS(sender.m_ID);
	}

	// Token: 0x06001AF7 RID: 6903 RVA: 0x002DC0CC File Offset: 0x002DA2CC
	public void SetDRformURS(int Idx)
	{
		this.Load_Total = 0L;
		this.ExpeditionNum = 0L;
		bool flag = false;
		this.mSpeedIdx = 16;
		for (int i = 0; i < 16; i++)
		{
			this.ExpeditionNum += this.m_Soldier[i];
			this.Load_Total += this.m_Soldier[i] * (long)this.m_SoldierData[i].Traffic;
			int num = (int)this.SpeedsortData[i];
			if (!flag && this.m_Soldier[num] != 0L && (i < this.mSpeedIdx || this.m_Soldier[i] == 0L))
			{
				flag = true;
				this.mSpeedIdx = i;
				this.Time_Total = GameConstants.appCeil(GameConstants.FastInvSqrt(this.Distance_Total * this.Distance_Total) * ((float)this.m_SoldierData[num].Speed * this.tmpTime));
				this.Cstr_Time.ClearString();
				if (this.Time_Total > 3600u)
				{
					this.Cstr_Time.IntToFormat((long)((ulong)(this.Time_Total / 3600u)), 2, false);
					this.Cstr_Time.IntToFormat((long)((ulong)(this.Time_Total % 3600u / 60u)), 2, false);
					this.Cstr_Time.IntToFormat((long)((ulong)(this.Time_Total % 60u)), 2, false);
					this.Cstr_Time.AppendFormat("{0}:{1}:{2}");
				}
				else
				{
					this.Cstr_Time.IntToFormat((long)((ulong)(this.Time_Total / 60u)), 2, false);
					this.Cstr_Time.IntToFormat((long)((ulong)(this.Time_Total % 60u)), 2, false);
					this.Cstr_Time.AppendFormat("{0}:{1}");
				}
			}
		}
		if (this.ExpeditionNum == 0L)
		{
			this.Cstr_Time.ClearString();
			this.Time_Total = 0u;
			this.Cstr_Time.IntToFormat((long)((ulong)(this.Time_Total / 60u)), 2, false);
			this.Cstr_Time.IntToFormat((long)((ulong)(this.Time_Total % 60u)), 2, false);
			this.Cstr_Time.AppendFormat("{0}:{1}");
			this.mSpeedIdx = 16;
			this.bClear = false;
			this.Text_Formation.text = this.mbtnFormation[0];
			this.Text_Load[0].color = Color.white;
			this.Text_Time[0].color = Color.white;
			if (this.mStatus == 1 && this.mUI_CK != 255)
			{
				this.Text_SelectMenu[0].gameObject.SetActive(false);
				this.Text_SelectMenu[1].gameObject.SetActive(true);
				if (this.mUI_CK < 2)
				{
					this.Img_SelectMenu[0].gameObject.SetActive(true);
				}
				else
				{
					this.Img_SelectMenu[1].gameObject.SetActive(true);
				}
			}
			if (this.mWarlobbyKind >= 0 && this.mWarlobbyKind <= 2 && this.mUI_WarlobbyK != 255)
			{
				this.Set_W_SelectText(this.mUI_WarlobbyK, false);
			}
		}
		else
		{
			this.bClear = true;
			this.Text_Formation.text = this.mbtnFormation[1];
			this.Text_Load[0].color = this.mtextColor;
			this.Text_Time[0].color = this.mtextColor;
			if (this.mStatus == 1 && this.mUI_CK != 255)
			{
				this.Text_SelectMenu[1].gameObject.SetActive(false);
				this.Img_SelectMenu[0].gameObject.SetActive(false);
				this.Img_SelectMenu[1].gameObject.SetActive(false);
				this.Text_SelectMenu[0].gameObject.SetActive(true);
			}
			if (this.mWarlobbyKind >= 0 && this.mWarlobbyKind <= 2)
			{
				this.Set_W_SelectText(this.mUI_WarlobbyK, true);
			}
		}
		this.Text_Time[0].text = this.Cstr_Time.ToString();
		this.Text_Time[0].SetAllDirty();
		this.Text_Time[0].cachedTextGenerator.Invalidate();
		this.Cstr_Troops[0].ClearString();
		this.Cstr_Troops[1].ClearString();
		if (this.ExpeditionNum > (long)((ulong)this.Hero_Total))
		{
			this.Cstr_Troops[0].StringToFormat("<color=#e5004fff>");
			this.Cstr_Troops[0].IntToFormat(this.ExpeditionNum, 1, true);
			this.Cstr_Troops[0].AppendFormat("{0}{1}</color>");
		}
		else if (this.ExpeditionNum != 0L)
		{
			this.Cstr_Troops[0].StringToFormat("<color=#ffdf2bff>");
			this.Cstr_Troops[0].IntToFormat(this.ExpeditionNum, 1, true);
			this.Cstr_Troops[0].AppendFormat("{0}{1}</color>");
		}
		else
		{
			this.Cstr_Troops[0].IntToFormat(this.ExpeditionNum, 1, true);
			this.Cstr_Troops[0].AppendFormat("{0}");
		}
		this.Text_Troops[0].text = this.Cstr_Troops[0].ToString();
		this.Text_Troops[0].SetAllDirty();
		this.Text_Troops[0].cachedTextGenerator.Invalidate();
		this.Cstr_Troops[1].IntToFormat((long)((ulong)this.Hero_Total), 1, true);
		if (this.mOpenKind != 10)
		{
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Troops[1].AppendFormat("{0} /");
			}
			else
			{
				this.Cstr_Troops[1].AppendFormat("/ {0}");
			}
		}
		else if (this.GUIM.IsArabic)
		{
			this.Cstr_Troops[1].AppendFormat("<color=#00ff00ff>{0} /</color>");
		}
		else
		{
			this.Cstr_Troops[1].AppendFormat("<color=#00ff00ff>/ {0}</color>");
		}
		this.Text_Troops[1].text = this.Cstr_Troops[1].ToString();
		this.Text_Troops[1].SetAllDirty();
		this.Text_Troops[1].cachedTextGenerator.Invalidate();
		if (this.mStatus == 0)
		{
			this.Cstr_LoadNum[0].ClearString();
			this.Load_Total = (long)((float)this.Load_Total * this.tmpLoad) / 10000L;
			this.Cstr_LoadNum[0].IntToFormat(this.Load_Total, 1, true);
			this.Cstr_LoadNum[0].AppendFormat("{0}");
			this.Text_Load[0].text = this.Cstr_LoadNum[0].ToString();
			this.Text_Load[0].SetAllDirty();
			this.Text_Load[0].cachedTextGenerator.Invalidate();
		}
		else if (this.mStatus == 1)
		{
			this.Load_Total = (long)((float)this.Load_Total * this.tmpLoad) / 10000L;
			this.Cstr_LoadNum[0].ClearString();
			if (this.mResourcesKind == 1)
			{
				this.Cstr_LoadNum[0].IntToFormat(this.Load_Total / 1000L, 1, true);
			}
			else
			{
				this.Cstr_LoadNum[0].IntToFormat(this.Load_Total, 1, true);
			}
			this.Cstr_LoadNum[0].AppendFormat("{0}");
			this.Text_Load[0].text = this.Cstr_LoadNum[0].ToString();
			this.Text_Load[0].SetAllDirty();
			this.Text_Load[0].cachedTextGenerator.Invalidate();
			this.Text_Load[0].cachedTextGeneratorForLayout.Invalidate();
		}
		if (this.bOpenEnd && this.mOpenKind == 6 && !this.DM.bChangSoldier && this.DM.mOpenExpeditionNum != this.ExpeditionNum)
		{
			this.DM.bChangSoldier = true;
		}
	}

	// Token: 0x06001AF8 RID: 6904 RVA: 0x002DC87C File Offset: 0x002DAA7C
	public override void OnOpen(int arg1, int arg2)
	{
		this.GameT = base.gameObject.transform;
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.FrameMaterial = this.GUIM.GetFrameMaterial();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.AssetName = "UIExpedition";
		this.AssetName1 = "UI_legion_m";
		this.Cstr = StringManager.Instance.SpawnString(30);
		this.Cstr_MusterTime = StringManager.Instance.SpawnString(30);
		this.Cstr_Time = StringManager.Instance.SpawnString(30);
		this.Cstr_Accelerate = StringManager.Instance.SpawnString(30);
		this.AllyName = StringManager.Instance.SpawnString(30);
		for (int i = 0; i < 2; i++)
		{
			this.Cstr_LoadNum[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_Troops[i] = StringManager.Instance.SpawnString(30);
		}
		for (int j = 0; j < 7; j++)
		{
			this.Cstr_Soldier_ItemNum[j] = StringManager.Instance.SpawnString(30);
			this.Cstr_Soldier_Text[j] = StringManager.Instance.SpawnString(30);
		}
		this.Cstr_TeamName = StringManager.Instance.SpawnString(50);
		this.Cstr_WarlobbyKindText = StringManager.Instance.SpawnString(200);
		this.Cstr_WarlobbySolder = StringManager.Instance.SpawnString(100);
		this.Cstr_WarlobbyMaxSolder = StringManager.Instance.SpawnString(30);
		this.Cstr_HintNum = StringManager.Instance.SpawnString(1024);
		for (int k = 0; k < 11; k++)
		{
			this.Cstr_WarSoldier_Text[k] = StringManager.Instance.SpawnString(100);
			this.Cstr_WarSoldierRate_Text[k] = StringManager.Instance.SpawnString(100);
		}
		this.MapID = arg1;
		this.mOpenKind = arg2;
		this.GUIM.AddSpriteAsset(this.AssetName);
		this.m_BW = this.GUIM.LoadMaterial(this.AssetName, this.AssetName1);
		this.mbtnFormation[0] = this.DM.mStringTable.GetStringByID(694u);
		this.mbtnFormation[1] = this.DM.mStringTable.GetStringByID(823u);
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.Tmp = this.GameT.GetChild(0);
		this.Tmp1 = this.Tmp.GetChild(1);
		this.Img_Frame = this.Tmp1.GetComponent<Image>();
		this.btn_MainHeroImg = this.Tmp1.GetChild(1).GetComponent<UIHIBtn>();
		if (this.DM.curHeroData.ContainsKey((uint)this.DM.GetLeaderID()))
		{
			this.GUIM.InitianHeroItemImg(this.btn_MainHeroImg.transform, eHeroOrItem.Hero, this.DM.GetLeaderID(), 11, 0, 0, true, false, true, false);
		}
		this.btn_MainHeroImg.gameObject.AddComponent<IgnoreRaycast>();
		this.Img_CaveMain[0] = this.Tmp1.GetChild(2).GetComponent<Image>();
		this.Img_CaveMain[1] = this.Tmp1.GetChild(2).GetChild(0).GetComponent<Image>();
		this.Img_CaveMain[0].gameObject.SetActive(true);
		this.Img_HeroStatus = this.Tmp1.GetChild(3).GetComponent<Image>();
		eHeroState heroState = this.DM.GetHeroState(this.DM.GetLeaderID());
		switch (heroState)
		{
		case eHeroState.IsFighting:
			this.Img_HeroStatus.sprite = this.SArray.m_Sprites[16];
			break;
		case eHeroState.Captured:
			this.Img_HeroStatus.sprite = this.SArray.m_Sprites[17];
			break;
		case eHeroState.Dead:
			this.Img_HeroStatus.sprite = this.SArray.m_Sprites[18];
			break;
		}
		this.btn_CaveCheck = this.Tmp1.GetChild(4).GetChild(0).GetComponent<UIButton>();
		this.btn_CaveCheck.m_Handler = this;
		this.btn_CaveCheck.m_BtnID1 = 20;
		this.Img_CaveStatus = this.Tmp1.GetChild(5).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_CaveStatus.transform.localScale = new Vector3(-1f, this.Img_CaveStatus.transform.localScale.y, this.Img_CaveStatus.transform.localScale.z);
		}
		this.Text_CaveMain = this.Tmp1.GetChild(6).GetComponent<UIText>();
		this.Text_CaveMain.font = this.TTFont;
		this.Text_CaveMain.text = this.DM.mStringTable.GetStringByID(8587u);
		if (this.mOpenKind == 4)
		{
			if (heroState != eHeroState.None)
			{
				this.Img_HeroStatus.gameObject.SetActive(true);
				this.Img_CaveStatus.gameObject.SetActive(false);
				this.bCaveMainHero = false;
			}
			else
			{
				this.DM.LegionBattleHero.Clear();
				this.DM.LegionBattleHero.Add(this.DM.GetLeaderID());
			}
			this.bLeaderHero = true;
		}
		this.BG_T1 = this.GameT.GetChild(1);
		this.Tmp = this.BG_T1.GetChild(0);
		this.btn_HeroTeam = this.Tmp.GetComponent<UIButton>();
		this.btn_HeroTeam.m_Handler = this;
		this.btn_HeroTeam.m_BtnID1 = 6;
		this.Tmp = this.BG_T1.GetChild(2);
		this.btn_HeroFormation = this.Tmp.GetComponent<UIButton>();
		this.btn_HeroFormation.m_Handler = this;
		this.btn_HeroFormation.m_BtnID1 = 17;
		this.btn_HeroFormation.m_EffectType = e_EffectType.e_Scale;
		this.btn_HeroFormation.transition = Selectable.Transition.None;
		this.Text_tmpStr[0] = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.Text_tmpStr[0].font = this.TTFont;
		this.Text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(824u);
		this.Tmp = this.BG_T1.GetChild(3);
		this.Text_HeroTeam = this.Tmp.GetComponent<UIText>();
		this.Text_HeroTeam.font = this.TTFont;
		this.BG_T2 = this.GameT.GetChild(2);
		this.Tmp = this.BG_T2.GetChild(0);
		this.btn_Clear = this.Tmp.GetComponent<UIButton>();
		this.btn_Clear.m_Handler = this;
		this.btn_Clear.m_BtnID1 = 18;
		this.btn_Clear.m_EffectType = e_EffectType.e_Scale;
		this.btn_Clear.transition = Selectable.Transition.None;
		this.Text_tmpStr[1] = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.Text_tmpStr[1].font = this.TTFont;
		this.Text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(825u);
		this.LockCount = (int)((byte)this.DM.GetMaxDefenders());
		for (int l = 0; l < 5; l++)
		{
			this.Tmp = this.BG_T2.GetChild(1 + l);
			this.btn_Hero[l] = this.Tmp.GetComponent<UIButton>();
			this.btn_Hero[l].m_Handler = this;
			this.btn_Hero[l].m_BtnID1 = 1 + l;
			this.Tmp = this.BG_T2.GetChild(6 + l);
			this.btn_HeroImg[l] = this.Tmp.GetComponent<UIHIBtn>();
			this.GUIM.InitianHeroItemImg(this.btn_HeroImg[l].transform, eHeroOrItem.Hero, 0, 0, 0, 0, true, false, true, false);
			this.Tmp = this.BG_T2.GetChild(11 + l);
			this.Img_AddBG[l] = this.Tmp.GetComponent<Image>();
			this.Img_AddBG[l].gameObject.SetActive(false);
			this.Tmp = this.BG_T2.GetChild(16 + l);
			this.Img_Lock[l] = this.Tmp.GetComponent<Image>();
		}
		this.Img_Leader[0] = this.BG_T2.GetChild(21).GetComponent<Image>();
		this.Img_Leader[1] = this.BG_T2.GetChild(21).GetChild(0).GetComponent<Image>();
		if (this.DM.LegionBattleHero.Count > 0)
		{
			this.bExpeditionHero = true;
		}
		else if (!this.DM.bSetExpediton && this.mOpenKind == 1)
		{
			this.DM.LegionBattleHero.Clear();
			this.DM.SetSortNonFightHeroID();
			int num = 0;
			while (num < this.DM.GetMaxDefenders() && (long)num < (long)((ulong)this.DM.NonFightHeroCount))
			{
				this.DM.LegionBattleHero.Add((ushort)this.DM.SortNonFightHeroID[num]);
				num++;
			}
			this.bExpeditionHero = true;
		}
		this.BG_T3 = this.GameT.GetChild(3);
		this.Tmp = this.BG_T3.GetChild(0);
		this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
		this.m_ScrollPanel.m_ScrollPanelID = 1;
		this.Tmp = this.BG_T3.GetChild(1);
		this.Tmp1 = this.Tmp.GetChild(1);
		this.m_UnitRS = this.Tmp1.GetComponent<UnitResourcesSlider>();
		this.GUIM.InitUnitResourcesSlider(this.Tmp1, eUnitSlider.Expedition, 0u, 1000u, 0.7f);
		this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.BtnIncrease, 161f, -16f, 70f, 60f, 0f, 0f);
		this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.BtnLessen, -192f, -16f, 70f, 60f, 0f, 0f);
		this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.m_slider, -14f, -16f, 264f, 19f, 0f, 0f);
		this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.m_sliderBG1, 0f, 0f, 264f, 19f, 0f, 0f);
		this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.Input, 150f, 25f, 84f, 24f, 0f, 0f);
		this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.m_Img, 95f, 22f, 26f, 34f, 0f, 0f);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.BtnIncrease, this.SArray.m_Sprites[0], this.m_BW);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.BtnLessen, this.SArray.m_Sprites[1], this.m_BW);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.Input, this.SArray.m_Sprites[4], this.m_BW);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_sliderBG1, this.SArray.m_Sprites[2], this.m_BW);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_sliderBG2, this.SArray.m_Sprites[3], this.m_BW);
		this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_Img, this.SArray.m_Sprites[5], this.m_BW);
		this.m_UnitRS.BtnInputText.m_Handler = this;
		this.m_UnitRS.BtnInputText.m_BtnID1 = 19;
		this.Tmp1 = this.Tmp.GetChild(2);
		Image component = this.Tmp1.GetComponent<Image>();
		component.sprite = this.GUIM.LoadFrameSprite("hf004");
		component.material = this.FrameMaterial;
		component = this.Tmp1.GetChild(0).gameObject.GetComponent<Image>();
		component.material = this.GUIM.m_IconSpriteAsset.GetMaterial();
		this.tmpRC = this.Tmp1.GetChild(0).GetComponent<RectTransform>();
		this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
		this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		component = this.Tmp1.GetChild(1).gameObject.GetComponent<Image>();
		component.sprite = this.GUIM.LoadFrameSprite("hf004");
		component.material = this.FrameMaterial;
		this.tmpRC = this.Tmp1.GetChild(1).GetComponent<RectTransform>();
		this.tmpRC.anchorMin = Vector2.zero;
		this.tmpRC.anchorMax = new Vector2(1f, 1f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		this.Tmp1 = this.Tmp.GetChild(3);
		component = this.Tmp1.gameObject.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(1);
		UIText component2 = this.Tmp2.GetComponent<UIText>();
		component2.font = this.TTFont;
		this.Tmp1 = this.Tmp.GetChild(4);
		component2 = this.Tmp2.GetComponent<UIText>();
		component2.font = this.TTFont;
		this.SoldierMax = 0L;
		this.UpDataSoldier();
		this.Tmp = this.GameT.GetChild(4);
		int num2 = 0;
		this.Tmp1 = this.Tmp.GetChild(0);
		this.btn_Troops = this.Tmp1.GetComponent<UIButton>();
		this.btn_Troops.m_Handler = this;
		this.btn_Troops.m_BtnID1 = 14;
		UIButtonHint uibuttonHint = this.Tmp1.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		this.mAllianceWarImg = this.Tmp.GetChild(0).GetChild(0).GetChild(0).gameObject;
		if (this.mOpenKind == 10)
		{
			this.mAllianceWarImg.gameObject.SetActive(true);
		}
		this.Tmp1 = this.Tmp.GetChild(0).GetChild(1);
		this.Img_HintBG[0] = this.Tmp1.GetComponent<Image>();
		this.Img_HintBG[0].sprite = this.door.LoadSprite("UI_main_box_012");
		this.Img_HintBG[0].material = this.door.LoadMaterial();
		this.Img_HintBG[0].type = Image.Type.Sliced;
		uibuttonHint.ControlFadeOut = this.Img_HintBG[0].gameObject;
		this.Img_HintRT[0] = this.Tmp1.GetComponent<RectTransform>();
		this.Tmp1 = this.Tmp.GetChild(0).GetChild(1).GetChild(0);
		this.Text_HintRT[0] = this.Tmp1.GetComponent<RectTransform>();
		this.Text_Hint[0] = this.Tmp1.GetComponent<UIText>();
		this.Text_Hint[0].font = this.TTFont;
		if (this.mOpenKind != 10)
		{
			this.Text_Hint[0].text = this.DM.mStringTable.GetStringByID(335u);
		}
		else
		{
			this.Text_Hint[0].text = this.DM.mStringTable.GetStringByID(17077u);
		}
		this.Text_HintRT[0].sizeDelta = new Vector2(this.Text_HintRT[0].sizeDelta.x, this.Text_Hint[0].preferredHeight);
		this.Img_HintRT[0].sizeDelta = new Vector2(this.Img_HintRT[0].sizeDelta.x, this.Text_Hint[0].preferredHeight + 20f);
		if (this.Text_Hint[0].preferredWidth < this.Text_HintRT[0].sizeDelta.x)
		{
			this.Text_HintRT[0].sizeDelta = new Vector2(this.Text_Hint[0].preferredWidth, this.Img_HintRT[0].sizeDelta.y);
			this.Img_HintRT[0].sizeDelta = new Vector2(this.Text_Hint[0].preferredWidth + 50f, this.Img_HintRT[0].sizeDelta.y);
		}
		this.mTroops_T = this.Tmp.GetChild(0);
		this.Tmp1 = this.Tmp.GetChild(0).GetChild(3);
		this.Text_Troops[0] = this.Tmp1.GetComponent<UIText>();
		this.Text_Troops[0].font = this.TTFont;
		this.Tmp1 = this.Tmp.GetChild(0).GetChild(2);
		this.Text_Troops[1] = this.Tmp1.GetComponent<UIText>();
		this.Text_Troops[1].font = this.TTFont;
		this.mLoad_T = this.Tmp.GetChild(1);
		this.btn_Load = this.mLoad_T.GetComponent<UIButton>();
		this.btn_Load.m_Handler = this;
		this.btn_Load.m_BtnID1 = 15;
		uibuttonHint = this.mLoad_T.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		for (int m = 0; m < 3; m++)
		{
			this.Img_StatusBG2[m] = this.Tmp.GetChild(1).GetChild(m).GetComponent<Image>();
		}
		this.Tmp1 = this.Tmp.GetChild(1).GetChild(3);
		this.Img_HintBG[1] = this.Tmp1.GetComponent<Image>();
		this.Img_HintBG[1].sprite = this.door.LoadSprite("UI_main_box_012");
		this.Img_HintBG[1].material = this.door.LoadMaterial();
		this.Img_HintBG[1].type = Image.Type.Sliced;
		uibuttonHint.ControlFadeOut = this.Img_HintBG[1].gameObject;
		this.Img_HintRT[1] = this.Tmp1.GetComponent<RectTransform>();
		this.Tmp1 = this.Tmp.GetChild(1).GetChild(3).GetChild(0);
		this.Text_HintRT[1] = this.Tmp1.GetComponent<RectTransform>();
		this.Text_Hint[1] = this.Tmp1.GetComponent<UIText>();
		this.Text_Hint[1].font = this.TTFont;
		this.Tmp1 = this.Tmp.GetChild(1).GetChild(4);
		this.Text_Load[0] = this.Tmp1.GetComponent<UIText>();
		this.Text_Load[0].font = this.TTFont;
		this.Text_Load[0].text = num2.ToString();
		this.mLoadBG_T = this.Tmp.GetChild(2);
		this.Img_StatusBG = this.Tmp.GetChild(2).GetComponent<Image>();
		this.Img_TargetBG = this.Tmp.GetChild(2).GetChild(0).GetComponent<Image>();
		this.Img_TargetRT = this.Tmp.GetChild(2).GetChild(0).GetComponent<RectTransform>();
		this.Tmp1 = this.Tmp.GetChild(2).GetChild(1);
		this.Text_Load[1] = this.Tmp1.GetComponent<UIText>();
		this.Text_Load[1].font = this.TTFont;
		this.Text_Load[1].text = num2.ToString();
		this.Text_LoadRT = this.Tmp1.GetComponent<RectTransform>();
		this.Tmp1 = this.Tmp.GetChild(2).GetChild(2);
		this.Text_Load[2] = this.Tmp1.GetComponent<UIText>();
		this.Text_Load[2].font = this.TTFont;
		this.Text_Load[2].text = this.DM.mStringTable.GetStringByID(691u);
		this.Tmp1 = this.Tmp.GetChild(2).GetChild(3);
		this.Text_Load[3] = this.Tmp1.GetComponent<UIText>();
		this.Text_Load[3].font = this.TTFont;
		this.mTime_T = this.Tmp.GetChild(3);
		this.btn_Time = this.mTime_T.GetComponent<UIButton>();
		this.btn_Time.m_Handler = this;
		this.btn_Time.m_BtnID1 = 16;
		uibuttonHint = this.mTime_T.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		this.Tmp1 = this.Tmp.GetChild(3).GetChild(1);
		this.Img_HintBG[2] = this.Tmp1.GetComponent<Image>();
		this.Img_HintBG[2].sprite = this.door.LoadSprite("UI_main_box_012");
		this.Img_HintBG[2].material = this.door.LoadMaterial();
		this.Img_HintBG[2].type = Image.Type.Sliced;
		uibuttonHint.ControlFadeOut = this.Img_HintBG[2].gameObject;
		this.Img_HintRT[2] = this.Tmp1.GetComponent<RectTransform>();
		this.Tmp1 = this.Tmp.GetChild(3).GetChild(1).GetChild(0);
		this.Text_HintRT[2] = this.Tmp1.GetComponent<RectTransform>();
		this.Text_Hint[2] = this.Tmp1.GetComponent<UIText>();
		this.Text_Hint[2].font = this.TTFont;
		this.Text_Hint[2].text = this.DM.mStringTable.GetStringByID(337u);
		this.Text_HintRT[2].sizeDelta = new Vector2(this.Text_HintRT[2].sizeDelta.x, this.Text_Hint[2].preferredHeight);
		this.Img_HintRT[2].sizeDelta = new Vector2(this.Img_HintRT[2].sizeDelta.x, this.Text_Hint[2].preferredHeight + 20f);
		if (this.Text_Hint[2].preferredWidth < this.Text_HintRT[2].sizeDelta.x)
		{
			this.Text_HintRT[2].sizeDelta = new Vector2(this.Text_Hint[2].preferredWidth, this.Img_HintRT[2].sizeDelta.y);
			this.Img_HintRT[2].sizeDelta = new Vector2(this.Text_Hint[2].preferredWidth + 50f, this.Img_HintRT[2].sizeDelta.y);
		}
		this.Tmp1 = this.Tmp.GetChild(3).GetChild(2);
		this.Text_Time[0] = this.Tmp1.GetComponent<UIText>();
		this.Text_Time[0].font = this.TTFont;
		this.Text_Time[0].text = num2.ToString();
		this.Tmp1 = this.Tmp.GetChild(3).GetChild(3);
		this.Text_Time[1] = this.Tmp1.GetComponent<UIText>();
		this.Text_Time[1].font = this.TTFont;
		this.Text_Time[1].text = this.DM.mStringTable.GetStringByID(353u);
		if (this.Text_Time[1].preferredWidth > this.Text_Time[1].rectTransform.sizeDelta.x)
		{
			this.Text_Time[1].rectTransform.sizeDelta = new Vector2(this.Text_Time[1].preferredWidth, this.Text_Time[1].rectTransform.sizeDelta.y);
		}
		this.Tmp1 = this.Tmp.GetChild(3).GetChild(4);
		this.Text_Time[2] = this.Tmp1.GetComponent<UIText>();
		this.Text_Time[2].font = this.TTFont;
		this.Cstr_Accelerate.ClearString();
		this.Cstr_Accelerate.IntToFormat((long)num2, 1, false);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_Accelerate.AppendFormat("%{0}");
		}
		else
		{
			this.Cstr_Accelerate.AppendFormat("{0}%");
		}
		this.Text_Time[2].text = this.Cstr_Accelerate.ToString();
		this.Text_Time[2].SetAllDirty();
		this.Text_Time[2].cachedTextGenerator.Invalidate();
		this.tmpString.Length = 0;
		this.Img_MusterTimeBG = this.Tmp.GetChild(7).GetComponent<Image>();
		this.Img_CombatpowerBG = this.Tmp.GetChild(7).GetChild(0).GetComponent<Image>();
		this.Text_MusterTime = this.Tmp.GetChild(7).GetChild(1).GetComponent<UIText>();
		this.Text_MusterTime.font = this.TTFont;
		this.Cstr_MusterTime.ClearString();
		this.Text_MusterTime.text = this.Cstr_MusterTime.ToString();
		this.Tmp1 = this.Tmp.GetChild(4);
		this.btn_Formation = this.Tmp1.GetComponent<UIButton>();
		this.btn_Formation.m_Handler = this;
		this.btn_Formation.m_BtnID1 = 7;
		this.btn_Formation.m_EffectType = e_EffectType.e_Scale;
		this.btn_Formation.transition = Selectable.Transition.None;
		this.Tmp1 = this.Tmp.GetChild(4).GetChild(1);
		this.Text_Formation = this.Tmp1.GetComponent<UIText>();
		this.Text_Formation.font = this.TTFont;
		this.Text_Formation.text = this.DM.mStringTable.GetStringByID(694u);
		this.Tmp1 = this.Tmp.GetChild(5);
		this.btn_Expedition = this.Tmp1.GetComponent<UIButton>();
		this.btn_Expedition.m_Handler = this;
		this.btn_Expedition.m_BtnID1 = 9;
		this.Tmp1 = this.Tmp.GetChild(6);
		this.Img_NoSoldierBG = this.Tmp1.GetComponent<Image>();
		this.Text_tmpStr[2] = this.Tmp1.GetChild(0).GetComponent<UIText>();
		this.Text_tmpStr[2].font = this.TTFont;
		this.Text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(771u);
		if (this.SoldierMax == 0L)
		{
			this.Img_NoSoldierBG.gameObject.SetActive(true);
		}
		this.Tmp1 = this.Tmp.GetChild(8);
		this.btn_SelectMenu[0] = this.Tmp1.GetComponent<UIButton>();
		this.btn_SelectMenu[0].m_Handler = this;
		this.btn_SelectMenu[0].m_BtnID1 = 21;
		this.btn_SelectMenu[0].m_EffectType = e_EffectType.e_Scale;
		this.btn_SelectMenu[0].transition = Selectable.Transition.None;
		this.Tmp1 = this.Tmp.GetChild(8).GetChild(0);
		this.Img_SelectMenu[0] = this.Tmp1.GetComponent<Image>();
		this.Tmp1 = this.Tmp.GetChild(8).GetChild(1);
		this.Img_SelectMenu[1] = this.Tmp1.GetComponent<Image>();
		this.Tmp1 = this.Tmp.GetChild(8).GetChild(2);
		this.Text_SelectMenu[0] = this.Tmp1.GetComponent<UIText>();
		this.Text_SelectMenu[0].font = this.TTFont;
		this.Tmp1 = this.Tmp.GetChild(8).GetChild(3);
		this.Text_SelectMenu[1] = this.Tmp1.GetComponent<UIText>();
		this.Text_SelectMenu[1].font = this.TTFont;
		if (this.DM.mcollectionKind != 255)
		{
			this.Text_SelectMenu[0].gameObject.SetActive(false);
			if (this.DM.mcollectionKind % 2 == 0)
			{
				this.Text_SelectMenu[1].text = this.DM.mStringTable.GetStringByID(333u);
			}
			else
			{
				this.Text_SelectMenu[1].text = this.DM.mStringTable.GetStringByID(334u);
			}
			this.Text_SelectMenu[1].gameObject.SetActive(true);
			this.Text_SelectMenu[0].text = this.mbtnFormation[1];
		}
		else
		{
			this.Text_SelectMenu[0].text = this.DM.mStringTable.GetStringByID(5219u);
		}
		this.Tmp1 = this.Tmp.GetChild(9);
		this.btn_SelectMenu[1] = this.Tmp1.GetComponent<UIButton>();
		this.btn_SelectMenu[1].m_Handler = this;
		this.btn_SelectMenu[1].m_BtnID1 = 22;
		this.btn_SelectMenu[1].m_EffectType = e_EffectType.e_Scale;
		this.btn_SelectMenu[1].transition = Selectable.Transition.None;
		this.mSave_T = this.Tmp.GetChild(10);
		this.Tmp1 = this.mSave_T.GetChild(0);
		this.btn_SetName = this.Tmp1.GetComponent<UIButton>();
		this.btn_SetName.m_Handler = this;
		this.btn_SetName.m_BtnID1 = 23;
		this.btn_SetName.m_EffectType = e_EffectType.e_Scale;
		this.btn_SetName.transition = Selectable.Transition.None;
		this.Tmp1 = this.mSave_T.GetChild(1);
		this.btn_Save = this.Tmp1.GetComponent<UIButton>();
		this.btn_Save.m_Handler = this;
		this.btn_Save.m_BtnID1 = 24;
		this.btn_Save.m_EffectType = e_EffectType.e_Scale;
		this.btn_Save.transition = Selectable.Transition.None;
		this.Tmp1 = this.mSave_T.GetChild(1).GetChild(0);
		this.Text_Save = this.Tmp1.GetComponent<UIText>();
		this.Text_Save.font = this.TTFont;
		this.Text_Save.text = this.DM.mStringTable.GetStringByID(929u);
		this.Tmp1 = this.mSave_T.GetChild(2);
		this.Text_Name = this.Tmp1.GetComponent<UIText>();
		this.Text_Name.font = this.TTFont;
		this.mApply_T = this.Tmp.GetChild(11);
		this.Tmp1 = this.mApply_T.GetChild(0);
		this.btn_Apply = this.Tmp1.GetComponent<UIButton>();
		this.btn_Apply.m_Handler = this;
		this.btn_Apply.m_BtnID1 = 26;
		this.btn_Apply.m_EffectType = e_EffectType.e_Scale;
		this.btn_Apply.transition = Selectable.Transition.None;
		this.Tmp1 = this.mApply_T.GetChild(0).GetChild(0);
		this.Text_btnApply = this.Tmp1.GetComponent<UIText>();
		this.Text_btnApply.font = this.TTFont;
		this.Text_btnApply.text = this.DM.mStringTable.GetStringByID(508u);
		this.Tmp1 = this.mApply_T.GetChild(1);
		this.Text_Apply = this.Tmp1.GetComponent<UIText>();
		this.Text_Apply.font = this.TTFont;
		this.Text_Apply.text = this.DM.mStringTable.GetStringByID(17016u);
		this.mWarlobbyT = this.Tmp.GetChild(12);
		this.Tmp1 = this.mWarlobbyT.GetChild(0);
		this.btn_W_MenuSelect[0] = this.Tmp1.GetComponent<UIButton>();
		this.btn_W_MenuSelect[0].m_Handler = this;
		this.btn_W_MenuSelect[0].m_BtnID1 = 27;
		this.btn_W_MenuSelect[0].m_EffectType = e_EffectType.e_Scale;
		this.btn_W_MenuSelect[0].transition = Selectable.Transition.None;
		this.Tmp1 = this.mWarlobbyT.GetChild(1);
		this.btn_W_MenuSelect[1] = this.Tmp1.GetComponent<UIButton>();
		this.btn_W_MenuSelect[1].m_Handler = this;
		this.btn_W_MenuSelect[1].m_BtnID1 = 28;
		this.btn_W_MenuSelect[1].m_EffectType = e_EffectType.e_Scale;
		this.btn_W_MenuSelect[1].transition = Selectable.Transition.None;
		this.Img_W_SelectIcon = this.Tmp1.GetChild(0).GetComponent<Image>();
		this.Text_W_Select[0] = this.Tmp1.GetChild(1).GetComponent<UIText>();
		this.Text_W_Select[0].font = this.TTFont;
		this.Text_W_Select[0].text = this.DM.mStringTable.GetStringByID(14710u);
		this.Text_W_Select[1] = this.Tmp1.GetChild(2).GetComponent<UIText>();
		this.Text_W_Select[1].font = this.TTFont;
		component = this.GameT.GetChild(5).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close_base");
		component.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			component.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(5).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.door.LoadMaterial();
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.Tmp = this.GameT.GetChild(6);
		this.btn_FormationMenu = this.Tmp.GetComponent<UIButton>();
		this.btn_FormationMenu.m_Handler = this;
		this.btn_FormationMenu.m_BtnID1 = 8;
		this.btn_FormationMenu.image.sprite = this.door.LoadSprite("UI_main_black");
		this.btn_FormationMenu.image.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.Tmp.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.Tmp.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.Tmp1 = this.Tmp.GetChild(0);
		for (int n = 0; n < 4; n++)
		{
			this.Tmp2 = this.Tmp1.GetChild(n);
			this.btn_Menu[n] = this.Tmp2.GetComponent<UIButton>();
			this.btn_Menu[n].m_Handler = this;
			this.btn_Menu[n].m_BtnID1 = 10 + n;
			this.Tmp2 = this.Tmp1.GetChild(n).GetChild(1);
			this.Text_Menu[n] = this.Tmp2.GetComponent<UIText>();
			this.Text_Menu[n].font = this.TTFont;
			if (n % 2 == 0)
			{
				this.Text_Menu[n].text = this.DM.mStringTable.GetStringByID(331u);
			}
			else
			{
				this.Text_Menu[n].text = this.DM.mStringTable.GetStringByID(332u);
			}
		}
		this.Img_SelectMenuKind[0] = this.Tmp1.GetChild(0).GetChild(0).GetComponent<Image>();
		this.Img_SelectMenuKind[1] = this.Tmp1.GetChild(1).GetChild(0).GetComponent<Image>();
		this.mSelectTeam_T = this.GameT.GetChild(7);
		for (int num3 = 0; num3 < 5; num3++)
		{
			this.Tmp1 = this.mSelectTeam_T.GetChild(num3);
			this.btn_SelectTeam[num3] = this.Tmp1.GetComponent<UIButton>();
			this.btn_SelectTeam[num3].m_Handler = this;
			this.btn_SelectTeam[num3].m_BtnID1 = 25;
			this.btn_SelectTeam[num3].m_BtnID2 = num3;
			this.btn_SelectTeam[num3].m_EffectType = e_EffectType.e_Scale;
			this.btn_SelectTeam[num3].transition = Selectable.Transition.None;
			if ((int)this.DM.GetTechLevel(120) < num3 + 1)
			{
				this.SetaApplyEnable(this.btn_SelectTeam[num3], false);
			}
			this.Tmp1 = this.mSelectTeam_T.GetChild(num3).GetChild(1);
			this.Text_D[num3] = this.Tmp1.GetComponent<UIText>();
			this.Text_D[num3].font = this.TTFont;
			this.Text_D[num3].text = (num3 + 1).ToString();
		}
		this.mSelectTeam_LT = this.GameT.GetChild(8);
		for (int num4 = 0; num4 < 5; num4++)
		{
			this.Tmp1 = this.mSelectTeam_LT.GetChild(num4);
			this.btn_SelectTeam[num4 + 5] = this.Tmp1.GetComponent<UIButton>();
			this.btn_SelectTeam[num4 + 5].m_Handler = this;
			this.btn_SelectTeam[num4 + 5].m_BtnID1 = 25;
			this.btn_SelectTeam[num4 + 5].m_BtnID2 = num4;
			this.btn_SelectTeam[num4 + 5].m_EffectType = e_EffectType.e_Scale;
			this.btn_SelectTeam[num4 + 5].transition = Selectable.Transition.None;
			if ((int)this.DM.GetTechLevel(120) < num4 + 1)
			{
				this.SetaApplyEnable(this.btn_SelectTeam[num4 + 5], false);
			}
			this.Tmp1 = this.mSelectTeam_LT.GetChild(num4).GetChild(1);
			this.Text_L[num4] = this.Tmp1.GetComponent<UIText>();
			this.Text_L[num4].font = this.TTFont;
			this.Text_L[num4].text = (num4 + 1).ToString();
		}
		this.Tmp = this.GameT.GetChild(9);
		this.btn_W_MenuBack = this.Tmp.GetComponent<UIButton>();
		this.btn_W_MenuBack.m_Handler = this;
		this.btn_W_MenuBack.m_BtnID1 = 29;
		this.btn_W_MenuBack.image.sprite = this.door.LoadSprite("UI_main_black");
		this.btn_W_MenuBack.image.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.Tmp.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.Tmp.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.Img_W_MenuSelect = this.Tmp.GetChild(0).GetComponent<Image>();
		for (int num5 = 0; num5 < 3; num5++)
		{
			this.btn_W_MenuKind[num5] = this.Tmp.GetChild(0).GetChild(num5).GetComponent<UIButton>();
			this.btn_W_MenuKind[num5].m_Handler = this;
			this.btn_W_MenuKind[num5].m_BtnID1 = 31 + num5;
			this.btn_W_MenuKind[num5].m_EffectType = e_EffectType.e_Scale;
			this.btn_W_MenuKind[num5].transition = Selectable.Transition.None;
			if (num5 == 0)
			{
				this.Text_W_MenuKind[num5] = this.Tmp.GetChild(0).GetChild(num5).GetChild(0).GetComponent<UIText>();
			}
			else
			{
				this.Text_W_MenuKind[num5] = this.Tmp.GetChild(0).GetChild(num5).GetChild(1).GetComponent<UIText>();
			}
			this.Text_W_MenuKind[num5].font = this.TTFont;
		}
		this.Text_W_MenuKind[0].text = this.DM.mStringTable.GetStringByID(694u);
		this.Text_W_MenuKind[1].text = this.DM.mStringTable.GetStringByID(14711u);
		this.Text_W_MenuKind[2].text = this.DM.mStringTable.GetStringByID(14712u);
		this.Text_W_MenuKind[3] = this.Tmp.GetChild(0).GetChild(3).GetChild(0).GetComponent<UIText>();
		this.Text_W_MenuKind[3].font = this.TTFont;
		this.Tmp1 = this.Tmp.GetChild(1);
		this.Img_W_Menu = this.Tmp1.GetComponent<Image>();
		this.Img_W_Menu.sprite = this.door.LoadSprite("UI_main_black");
		this.Img_W_Menu.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.Tmp1.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.Tmp1.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.Tmp1 = this.Tmp.GetChild(1).GetChild(0);
		this.btn_W_InfoBack[0] = this.Tmp1.GetComponent<UIButton>();
		this.btn_W_InfoBack[0].m_Handler = this;
		this.btn_W_InfoBack[0].m_BtnID1 = 30;
		this.btn_W_InfoBack[0].image.sprite = this.door.LoadSprite("UI_main_black");
		this.btn_W_InfoBack[0].image.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.Tmp1.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.Tmp1.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.Tmp1 = this.Tmp.GetChild(1).GetChild(1);
		component = this.Tmp1.GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_box_009_bb");
		component.material = this.door.LoadMaterial();
		component = this.Tmp1.GetChild(0).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_con_title_orange");
		component.material = this.door.LoadMaterial();
		this.Text_W_SelectTilte = this.Tmp1.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.Text_W_SelectTilte.font = this.TTFont;
		this.m_ScrollPanel_Warlobby = this.Tmp1.GetChild(1).GetComponent<ScrollPanel>();
		this.m_ScrollPanel_Warlobby.m_ScrollPanelID = 2;
		component = this.Tmp1.GetChild(1).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_con_alp_02");
		component.material = this.door.LoadMaterial();
		this.Tmp2 = this.Tmp1.GetChild(2);
		component = this.Tmp2.GetChild(0).GetChild(0).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_box_011");
		component.material = this.door.LoadMaterial();
		component2 = this.Tmp2.GetChild(0).GetChild(1).GetComponent<UIText>();
		component2.font = this.TTFont;
		component2.text = this.DM.mStringTable.GetStringByID(14718u);
		this.Text_W_Scroll[0] = this.Tmp2.GetChild(0).GetChild(2).GetComponent<UIText>();
		this.Text_W_Scroll[0].font = this.TTFont;
		this.Text_W_Scroll[1] = this.Tmp2.GetChild(0).GetChild(3).GetComponent<UIText>();
		this.Text_W_Scroll[1].font = this.TTFont;
		this.Text_W_Scroll[2] = this.Tmp2.GetChild(0).GetChild(4).GetComponent<UIText>();
		this.Text_W_Scroll[2].font = this.TTFont;
		this.Text_W_Scroll[3] = this.Tmp2.GetChild(0).GetChild(5).GetComponent<UIText>();
		this.Text_W_Scroll[3].font = this.TTFont;
		this.Text_W_Scroll[0].text = this.DM.mStringTable.GetStringByID(14719u);
		this.Text_W_Scroll[0].SetAllDirty();
		this.Text_W_Scroll[0].cachedTextGenerator.Invalidate();
		this.Text_W_Scroll[0].cachedTextGeneratorForLayout.Invalidate();
		if (this.Text_W_Scroll[0].preferredHeight > this.Text_W_Scroll[0].rectTransform.sizeDelta.y)
		{
			this.Text_W_Scroll[0].rectTransform.sizeDelta = new Vector2(this.Text_W_Scroll[0].rectTransform.sizeDelta.x, 56f);
			this.Text_W_Scroll[2].rectTransform.anchoredPosition = new Vector2(-58f, -58f);
			this.bScrollItemH = true;
			this.Text_W_Scroll[1].rectTransform.anchoredPosition = new Vector2(this.Text_W_Scroll[1].rectTransform.anchoredPosition.x, -112f);
			this.Text_W_Scroll[3].rectTransform.anchoredPosition = new Vector2(this.Text_W_Scroll[3].rectTransform.anchoredPosition.x, -112f);
		}
		else
		{
			this.Text_W_Scroll[0].rectTransform.sizeDelta = new Vector2(this.Text_W_Scroll[0].rectTransform.sizeDelta.x, 28f);
			this.Text_W_Scroll[2].rectTransform.anchoredPosition = new Vector2(-58f, -44f);
			this.Text_W_Scroll[1].rectTransform.anchoredPosition = new Vector2(this.Text_W_Scroll[1].rectTransform.anchoredPosition.x, -84f);
			this.Text_W_Scroll[3].rectTransform.anchoredPosition = new Vector2(this.Text_W_Scroll[3].rectTransform.anchoredPosition.x, -84f);
		}
		this.Text_W_Scroll[1].text = this.DM.mStringTable.GetStringByID(14721u);
		this.Text_W_Scroll[1].SetAllDirty();
		this.Text_W_Scroll[1].cachedTextGenerator.Invalidate();
		this.Text_W_Scroll[1].cachedTextGeneratorForLayout.Invalidate();
		if (this.Text_W_Scroll[1].preferredHeight > 28f)
		{
			this.bScrollItemH2 = true;
		}
		this.Text_W_Scroll[1].text = this.DM.mStringTable.GetStringByID(14720u);
		this.Text_W_Scroll[1].SetAllDirty();
		this.Text_W_Scroll[1].cachedTextGenerator.Invalidate();
		this.Text_W_Scroll[1].cachedTextGeneratorForLayout.Invalidate();
		if (this.Text_W_Scroll[1].preferredHeight > 28f)
		{
			this.bScrollItemH1 = true;
		}
		component = this.Tmp2.GetChild(1).GetChild(0).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_box_011");
		component.material = this.door.LoadMaterial();
		component2 = this.Tmp2.GetChild(1).GetChild(1).GetComponent<UIText>();
		component2.font = this.TTFont;
		component2.text = this.DM.mStringTable.GetStringByID(4925u);
		component = this.Tmp2.GetChild(2).GetChild(0).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_legion_icon_a");
		component.material = this.door.LoadMaterial();
		component2 = this.Tmp2.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTFont;
		component2 = this.Tmp2.GetChild(2).GetChild(0).GetChild(1).GetComponent<UIText>();
		component2.font = this.TTFont;
		component2 = this.Tmp2.GetChild(2).GetChild(0).GetChild(2).GetComponent<UIText>();
		component2.font = this.TTFont;
		component = this.Tmp2.GetChild(2).GetChild(1).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_leg_icon_Ex");
		component.material = this.door.LoadMaterial();
		component2 = this.Tmp2.GetChild(2).GetChild(2).GetComponent<UIText>();
		component2.font = this.TTFont;
		for (int num6 = 0; num6 < 11; num6++)
		{
			this.m_Warlobby_Item[num6].text_T1 = new UIText[5];
			this.m_Warlobby_Item[num6].text_SolderT = new UIText[4];
			this.InitSoldierInfoItem[num6] = false;
		}
		this.tmplist_Warlooby.Add(118f);
		this.tmplist_Warlooby.Add(38f);
		this.m_ScrollPanel_Warlobby.IntiScrollPanel(376f, 15f, 0f, this.tmplist_Warlooby, 11, this);
		this.m_ScrollRect_Warlobby = this.m_ScrollPanel_Warlobby.transform.GetComponent<CScrollRect>();
		UIButtonHint.scrollRect = this.m_ScrollRect_Warlobby;
		this.btn_W_InfoBack[1] = this.Tmp1.GetChild(3).GetComponent<UIButton>();
		this.btn_W_InfoBack[1].m_Handler = this;
		this.btn_W_InfoBack[1].m_BtnID1 = 30;
		this.btn_W_InfoBack[1].image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_W_InfoBack[1].image.material = this.door.LoadMaterial();
		this.btn_W_InfoBack[1].m_EffectType = e_EffectType.e_Scale;
		this.btn_W_InfoBack[1].transition = Selectable.Transition.None;
		this.btn_W_MenuSet = this.Tmp1.GetChild(4).GetComponent<UIButton>();
		this.btn_W_MenuSet.m_Handler = this;
		this.btn_W_MenuSet.m_BtnID1 = 34;
		this.btn_W_MenuSet.image.sprite = this.door.LoadSprite("UI_main_butt_a");
		this.btn_W_MenuSet.image.material = this.door.LoadMaterial();
		this.btn_W_MenuSet.m_EffectType = e_EffectType.e_Scale;
		this.btn_W_MenuSet.transition = Selectable.Transition.None;
		this.Text_W_MenuSet = this.Tmp1.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.Text_W_MenuSet.font = this.TTFont;
		this.Text_W_MenuSet.text = this.DM.mStringTable.GetStringByID(924u);
		this.btn_W_MenuSet.m_Text = this.Text_W_MenuSet;
		component = this.Tmp1.GetChild(5).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_fr_box_005");
		component.material = this.door.LoadMaterial();
		this.mResources[0] = this.door.LoadSprite("UI_main_res_food");
		this.mResources[1] = this.door.LoadSprite("UI_main_res_wood");
		this.mResources[2] = this.door.LoadSprite("UI_main_res_iron");
		this.mResources[3] = this.door.LoadSprite("UI_main_res_stone");
		this.mResources[4] = this.door.LoadSprite("UI_main_money_01");
		this.mResources[5] = this.door.LoadSprite("UI_main_money_02");
		this.mWarlobbyIcon[0] = this.door.LoadSprite("UI_legion_icon_a");
		this.mWarlobbyIcon[1] = this.door.LoadSprite("UI_legion_icon_b");
		this.mWarlobbyIcon[2] = this.door.LoadSprite("UI_legion_icon_c");
		this.mWarlobbyIcon[3] = this.door.LoadSprite("UI_legion_icon_d");
		if (this.mOpenKind == 0 || (this.mOpenKind >= 11 && this.mOpenKind <= 12))
		{
			this.nowMapPoint = DataManager.MapDataController.LayoutMapInfo[this.MapID];
			this.Distance_Total = DataManager.MapDataController.CalcDistance(this.MapID, this.DM.RoleAttr.CapitalPoint, 0);
			switch (DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)this.MapID))
			{
			case POINT_KIND.PK_NONE:
				this.mStatus = 0;
				break;
			case POINT_KIND.PK_FOOD:
				this.mStatus = 1;
				this.Img_TargetBG.sprite = this.mResources[0];
				this.Img_SelectMenuKind[0].sprite = this.mResources[0];
				this.Img_SelectMenuKind[1].sprite = this.mResources[0];
				this.Img_SelectMenu[0].sprite = this.mResources[0];
				break;
			case POINT_KIND.PK_STONE:
				this.mStatus = 1;
				this.Img_TargetBG.sprite = this.mResources[3];
				this.Img_SelectMenuKind[0].sprite = this.mResources[3];
				this.Img_SelectMenuKind[1].sprite = this.mResources[3];
				this.Img_SelectMenu[0].sprite = this.mResources[3];
				break;
			case POINT_KIND.PK_IRON:
				this.mStatus = 1;
				this.Img_TargetBG.sprite = this.mResources[2];
				this.Img_SelectMenuKind[0].sprite = this.mResources[2];
				this.Img_SelectMenuKind[1].sprite = this.mResources[2];
				this.Img_SelectMenu[0].sprite = this.mResources[2];
				break;
			case POINT_KIND.PK_WOOD:
				this.mStatus = 1;
				this.Img_TargetBG.sprite = this.mResources[1];
				this.Img_SelectMenuKind[0].sprite = this.mResources[1];
				this.Img_SelectMenuKind[1].sprite = this.mResources[1];
				this.Img_SelectMenu[0].sprite = this.mResources[1];
				break;
			case POINT_KIND.PK_GOLD:
				this.mStatus = 1;
				this.Img_TargetBG.sprite = this.mResources[4];
				this.Img_SelectMenuKind[0].sprite = this.mResources[4];
				this.Img_SelectMenuKind[1].sprite = this.mResources[4];
				this.Img_SelectMenu[0].sprite = this.mResources[4];
				break;
			case POINT_KIND.PK_CRYSTAL:
				this.mStatus = 1;
				this.mResourcesKind = 1;
				this.Img_TargetBG.sprite = this.mResources[5];
				this.Img_SelectMenuKind[0].sprite = this.mResources[5];
				this.Img_SelectMenuKind[1].sprite = this.mResources[5];
				this.Img_SelectMenu[0].sprite = this.mResources[5];
				break;
			}
			ushort tableID = DataManager.MapDataController.LayoutMapInfo[this.MapID].tableID;
			if (this.mStatus == 1 && DataManager.MapDataController.ResourcesPointTable[(int)tableID].playerName.Length != 0)
			{
				this.mStatus = 0;
			}
			this.Img_TargetBG.SetNativeSize();
			this.Img_SelectMenuKind[0].material = this.door.LoadMaterial();
			this.Img_SelectMenuKind[0].SetNativeSize();
			this.Img_SelectMenuKind[1].material = this.door.LoadMaterial();
			this.Img_SelectMenuKind[1].SetNativeSize();
			this.Img_SelectMenu[0].material = this.door.LoadMaterial();
			this.Img_SelectMenu[0].SetNativeSize();
			this.Text_LoadRT.sizeDelta = new Vector2(this.Text_Load[1].preferredWidth, this.Text_LoadRT.sizeDelta.y);
			this.tmpL = Mathf.Ceil(this.Text_LoadRT.anchoredPosition.x + this.Text_Load[1].preferredWidth) - 20f;
			this.Img_TargetRT.anchoredPosition = new Vector2(-this.tmpL, this.Img_TargetRT.anchoredPosition.y);
			this.Text_Load[2].rectTransform.anchoredPosition = new Vector2(-this.tmpL - this.Img_TargetRT.sizeDelta.x, this.Text_Load[2].rectTransform.anchoredPosition.y);
		}
		else if (this.mOpenKind == 1)
		{
			this.mLoad_T.gameObject.SetActive(false);
			this.mLoadBG_T.gameObject.SetActive(false);
			this.mTime_T.gameObject.SetActive(false);
			this.tmpPVEPower[0] = 1f;
			this.tmpPVEPower[1] = 2f;
			this.tmpPVEPower[2] = 3f;
			this.tmpPVEPower[3] = 4.5f;
		}
		else if (this.mOpenKind == 2)
		{
			if (this.MapID == 2 || this.MapID == 3)
			{
				this.ZoneID = this.DM.WarlobbyDetail.AllyCapitalPoint.zoneID;
				this.PointID = this.DM.WarlobbyDetail.AllyCapitalPoint.pointID;
			}
			else if (this.MapID == 4)
			{
				this.ZoneID = this.DM.WarlobbyDetail.EnemyCapitalPoint.zoneID;
				this.PointID = this.DM.WarlobbyDetail.EnemyCapitalPoint.pointID;
				for (int num7 = 0; num7 < 4; num7++)
				{
					this.WarlobbyTroopData[num7] = new uint[4];
				}
				if (this.DM.WarlobbyDetail.AttackOrDefense == 2 && this.DM.WarTroop.Count > 0)
				{
					this.WarlobbyTroopTotalTroopNum = this.DM.WarTroop[0].TotalTroopNum;
					for (int num8 = 0; num8 < 16; num8++)
					{
						this.WarlobbyTroopData[num8 >> 2][num8 & 3] = this.DM.WarTroop[0].TroopData[num8 & 3][3 - (num8 >> 2)];
					}
				}
				this.Text_W_MenuKind[3].text = this.DM.mStringTable.GetStringByID(14716u);
				this.mWarlobbyKind = 1;
			}
			else
			{
				this.ZoneID = this.DM.m_InForcePoint.zoneID;
				this.PointID = this.DM.m_InForcePoint.pointID;
			}
			if (this.CheckIsYolk(this.ZoneID, this.PointID))
			{
				this.Img_MusterTimeBG.gameObject.SetActive(true);
				this.Img_CombatpowerBG.gameObject.SetActive(true);
				this.Cstr_MusterTime.ClearString();
				this.Cstr_MusterTime.IntToFormat((long)((ulong)this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_JOINRALLY_COMBATPOWER)), 1, true);
				this.Cstr_MusterTime.AppendFormat(this.DM.mStringTable.GetStringByID(12244u));
				this.Text_MusterTime.text = this.Cstr_MusterTime.ToString();
				this.Text_MusterTime.SetAllDirty();
				this.Text_MusterTime.cachedTextGenerator.Invalidate();
				this.Text_MusterTime.cachedTextGeneratorForLayout.Invalidate();
				if (this.Text_MusterTime.preferredWidth <= 200f)
				{
					this.Text_MusterTime.rectTransform.sizeDelta = new Vector2(this.Text_MusterTime.preferredWidth + 1f, this.Text_MusterTime.rectTransform.sizeDelta.y);
				}
				this.Text_MusterTime.rectTransform.anchoredPosition = new Vector2(this.Img_CombatpowerBG.rectTransform.sizeDelta.x / 2f + 2f, this.Text_MusterTime.rectTransform.anchoredPosition.y);
				this.Img_CombatpowerBG.rectTransform.anchoredPosition = new Vector2(-this.Text_MusterTime.rectTransform.sizeDelta.x / 2f - 2f, this.Img_CombatpowerBG.rectTransform.anchoredPosition.y);
			}
			this.Distance_Total = DataManager.MapDataController.CalcDistance(GameConstants.PointCodeToMapID(this.ZoneID, this.PointID), this.DM.RoleAttr.CapitalPoint, 0);
			this.mStatus = 2;
			this.btn_HeroFormation.gameObject.SetActive(false);
		}
		else if (this.mOpenKind == 3 || this.mOpenKind == 9)
		{
			if (this.MapID == 0)
			{
				this.ZoneID = this.DM.RallyDesPoint.zoneID;
				this.PointID = this.DM.RallyDesPoint.pointID;
			}
			else
			{
				this.ZoneID = this.DM.WarlobbyDetail.AllyCapitalPoint.zoneID;
				this.PointID = this.DM.WarlobbyDetail.AllyCapitalPoint.pointID;
			}
			this.Distance_Total = DataManager.MapDataController.CalcDistance(GameConstants.PointCodeToMapID(this.ZoneID, this.PointID), this.DM.RoleAttr.CapitalPoint, 0);
			this.mStatus = 3;
			if (this.MapID == 1)
			{
				this.mStatus = 4;
				this.AllyName.ClearString();
				this.AllyName.Append(this.DM.WarlobbyDetail.AllyName);
				this.btn_HeroFormation.gameObject.SetActive(false);
				for (int num9 = 0; num9 < 4; num9++)
				{
					this.WarlobbyTroopData[num9] = new uint[4];
				}
				if (this.DM.WarlobbyDetail.AttackOrDefense == 0 && this.DM.WarTroop.Count > 0)
				{
					this.WarlobbyTroopTotalTroopNum = this.DM.WarTroop[0].TotalTroopNum;
					for (int num10 = 0; num10 < 16; num10++)
					{
						this.WarlobbyTroopData[num10 >> 2][num10 & 3] = this.DM.WarTroop[0].TroopData[num10 & 3][3 - (num10 >> 2)];
					}
				}
				this.Text_W_MenuKind[3].text = this.DM.mStringTable.GetStringByID(14715u);
				this.mWarlobbyKind = 0;
				if (this.DM.WarlobbyDetail.WonderID != 255)
				{
					this.Img_MusterTimeBG.gameObject.SetActive(true);
					this.Img_CombatpowerBG.gameObject.SetActive(true);
					this.Cstr_MusterTime.ClearString();
					this.Cstr_MusterTime.IntToFormat((long)((ulong)this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_JOINRALLY_COMBATPOWER)), 1, true);
					this.Cstr_MusterTime.AppendFormat(this.DM.mStringTable.GetStringByID(12244u));
					this.Text_MusterTime.text = this.Cstr_MusterTime.ToString();
					this.Text_MusterTime.SetAllDirty();
					this.Text_MusterTime.cachedTextGenerator.Invalidate();
					this.Text_MusterTime.cachedTextGeneratorForLayout.Invalidate();
					if (this.Text_MusterTime.preferredWidth <= 200f)
					{
						this.Text_MusterTime.rectTransform.sizeDelta = new Vector2(this.Text_MusterTime.preferredWidth + 1f, this.Text_MusterTime.rectTransform.sizeDelta.y);
					}
					this.Text_MusterTime.rectTransform.anchoredPosition = new Vector2(this.Img_CombatpowerBG.rectTransform.sizeDelta.x / 2f + 2f, this.Text_MusterTime.rectTransform.anchoredPosition.y);
					this.Img_CombatpowerBG.rectTransform.anchoredPosition = new Vector2(-this.Text_MusterTime.rectTransform.sizeDelta.x / 2f - 2f, this.Img_CombatpowerBG.rectTransform.anchoredPosition.y);
				}
			}
			else
			{
				this.Img_MusterTimeBG.gameObject.SetActive(true);
				this.Cstr_MusterTime.ClearString();
				this.mRallyCountDown[0] = 5;
				this.mRallyCountDown[1] = 10;
				this.mRallyCountDown[2] = 60;
				this.mRallyCountDown[3] = 480;
				if (this.DM.RallyCountDownIndex < 2)
				{
					this.Cstr_MusterTime.IntToFormat((long)this.mRallyCountDown[(int)this.DM.RallyCountDownIndex], 1, false);
					this.Cstr_MusterTime.AppendFormat(this.DM.mStringTable.GetStringByID(696u));
				}
				else
				{
					this.Cstr_MusterTime.IntToFormat((long)(this.mRallyCountDown[(int)this.DM.RallyCountDownIndex] / 60), 1, false);
					this.Cstr_MusterTime.AppendFormat(this.DM.mStringTable.GetStringByID(848u));
				}
				this.Text_MusterTime.rectTransform.anchoredPosition = new Vector2(0f, this.Text_MusterTime.rectTransform.anchoredPosition.y);
				this.Text_MusterTime.text = this.Cstr_MusterTime.ToString();
				this.Text_MusterTime.SetAllDirty();
				this.Text_MusterTime.cachedTextGenerator.Invalidate();
				this.Text_MusterTime.cachedTextGeneratorForLayout.Invalidate();
			}
		}
		else if (this.mOpenKind == 4)
		{
			this.mLoad_T.gameObject.SetActive(false);
			this.mLoadBG_T.gameObject.SetActive(false);
			this.mTime_T.gameObject.SetActive(false);
			this.Img_MusterTimeBG.gameObject.SetActive(true);
			this.mRallyCountDown[0] = 1;
			this.mRallyCountDown[1] = 4;
			this.mRallyCountDown[2] = 8;
			this.mRallyCountDown[3] = 12;
			this.Cstr_MusterTime.ClearString();
			this.Cstr_MusterTime.IntToFormat((long)this.mRallyCountDown[(int)this.DM.RallyCountDownIndex], 1, false);
			this.Cstr_MusterTime.AppendFormat(this.DM.mStringTable.GetStringByID(8588u));
			this.Text_MusterTime.text = this.Cstr_MusterTime.ToString();
			this.Text_MusterTime.rectTransform.anchoredPosition = new Vector2(0f, this.Text_MusterTime.rectTransform.anchoredPosition.y);
			this.Text_MusterTime.SetAllDirty();
			this.Text_MusterTime.cachedTextGenerator.Invalidate();
		}
		else if (this.mOpenKind == 5)
		{
			this.Distance_Total = DataManager.MapDataController.CalcDistance(GameConstants.PointCodeToMapID(AmbushManager.Instance.ObjPoint.zoneID, AmbushManager.Instance.ObjPoint.pointID), this.DM.RoleAttr.CapitalPoint, 0);
			this.mStatus = 0;
		}
		else if (this.mOpenKind == 6)
		{
			this.mSave_T.gameObject.SetActive(true);
			RectTransform component3 = this.mTroops_T.transform.GetComponent<RectTransform>();
			component3.anchoredPosition = new Vector2(component3.anchoredPosition.x, 123f);
			component3 = this.mLoad_T.transform.GetComponent<RectTransform>();
			component3.anchoredPosition = new Vector2(component3.anchoredPosition.x, 40f);
			component3 = this.mLoadBG_T.transform.GetComponent<RectTransform>();
			component3.anchoredPosition = new Vector2(component3.anchoredPosition.x, 10f);
			this.mTime_T.gameObject.SetActive(false);
			this.mStatus = 0;
			this.tmpTMD = default(TroopMemoryData);
			this.tmpTMD.Leader = new ushort[5];
			this.tmpTMD.TroopData = new uint[16];
			this.TMD_Idx = (byte)arg1;
			this.TMD_Name = string.Empty;
			if (this.DM.TeamName.Length == 0 && this.DM.mTroopMemoryData[(int)this.TMD_Idx].Label != null && this.DM.mTroopMemoryData[(int)this.TMD_Idx].Label != string.Empty)
			{
				this.TMD_Name = this.DM.mTroopMemoryData[(int)this.TMD_Idx].Label;
			}
			else if (this.DM.TeamName.Length == 0)
			{
				this.Cstr_TeamName.ClearString();
				this.Cstr_TeamName.IntToFormat((long)(this.TMD_Idx + 1), 1, false);
				this.Cstr_TeamName.AppendFormat(this.DM.mStringTable.GetStringByID(993u));
				this.TMD_Name = this.Cstr_TeamName.ToString();
			}
			else
			{
				this.TMD_Name = this.DM.TeamName.ToString();
			}
			this.Text_Name.text = this.TMD_Name;
			this.Text_Name.SetAllDirty();
			this.Text_Name.cachedTextGenerator.Invalidate();
			if (!this.bExpeditionHero && this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader != null && this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[0] != 0)
			{
				this.DM.LegionBattleHero.Clear();
				this.bExpeditionHero = true;
				bool flag = false;
				int num11 = 0;
				for (int num12 = 0; num12 < 5; num12++)
				{
					if (this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[num12] != 0 && this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[num12] == this.DM.GetLeaderID())
					{
						flag = true;
						num11 = num12;
						break;
					}
				}
				for (int num13 = 0; num13 < 5; num13++)
				{
					if (flag && num11 != 0)
					{
						if (num13 == 0)
						{
							this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[num11]);
						}
						else if (num13 == num11)
						{
							this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[0]);
						}
						else
						{
							this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[num13]);
						}
					}
					else if (this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[num13] != 0)
					{
						this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[num13]);
					}
				}
			}
			for (int num14 = 0; num14 < 16; num14++)
			{
				if (this.DM.mTroopMemoryData[(int)this.TMD_Idx].TroopData[num14] != 0u)
				{
					this.DM.mExpeditionSoldierList[num14] = this.DM.mTroopMemoryData[(int)this.TMD_Idx].TroopData[num14];
				}
			}
			this.DM.bSetExpediton = true;
			this.UpDataSoldier();
		}
		else if (this.mOpenKind == 7)
		{
			MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.MapID];
			this.Distance_Total = DataManager.MapDataController.CalcDistance(this.MapID, this.DM.RoleAttr.CapitalPoint, 0);
			if ((int)mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
			{
				MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int)mapPoint.tableID];
				this.mWonderId = mapYolk.WonderID;
			}
			this.mStatus = 0;
		}
		else if (this.mOpenKind == 8)
		{
			this.mWonderId = (byte)this.MapID;
			this.Distance_Total = DataManager.MapDataController.CalcDistance(GameConstants.PointCodeToMapID(this.DM.WarlobbyDetail.EnemyCapitalPoint.zoneID, this.DM.WarlobbyDetail.EnemyCapitalPoint.pointID), this.DM.RoleAttr.CapitalPoint, 0);
			this.mStatus = 0;
			for (int num15 = 0; num15 < 4; num15++)
			{
				this.WarlobbyTroopData[num15] = new uint[4];
			}
			if (this.DM.WarlobbyDetail.AttackOrDefense == 2 && this.DM.WarTroop.Count > 0)
			{
				this.WarlobbyTroopTotalTroopNum = this.DM.WarTroop[0].TotalTroopNum;
				for (int num16 = 0; num16 < 16; num16++)
				{
					this.WarlobbyTroopData[num16 >> 2][num16 & 3] = this.DM.WarTroop[0].TroopData[num16 & 3][3 - (num16 >> 2)];
				}
				this.Text_W_MenuKind[3].text = this.DM.mStringTable.GetStringByID(14716u);
				this.mWarlobbyKind = 2;
			}
		}
		else if (this.mOpenKind == 10)
		{
			this.mApply_T.gameObject.SetActive(true);
			RectTransform component4 = this.mTroops_T.transform.GetComponent<RectTransform>();
			component4.anchoredPosition = new Vector2(component4.anchoredPosition.x, 70f);
			this.mTime_T.gameObject.SetActive(false);
			this.mLoad_T.gameObject.SetActive(false);
			this.mLoadBG_T.gameObject.SetActive(false);
		}
		this.EGASpeed = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED);
		this.EGASpeed2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_DEBUFF);
		this.EGASpeed3 = 0u;
		this.EGASpeed4 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_CURSE);
		this.EGACapacityKind = 0u;
		RoleBuildingData buildData = this.GUIM.BuildingData.GetBuildData(8, 0);
		this.BaseNum = this.GUIM.BuildingData.GetBuildLevelRequestData(8, buildData.Level).Value1;
		this.Hero_Total = this.BaseNum;
		if (!this.bExpeditionHero)
		{
			if (this.mOpenKind == 1)
			{
				if (this.DM.LegionBattleHero.Count > 0)
				{
					this.BG_T1.gameObject.SetActive(false);
					this.BG_T2.gameObject.SetActive(true);
				}
				else
				{
					this.BG_T1.gameObject.SetActive(true);
					this.BG_T2.gameObject.SetActive(false);
				}
				this.SetHero_Total();
			}
		}
		else if (this.mOpenKind != 4)
		{
			this.BG_T1.gameObject.SetActive(false);
			this.BG_T2.gameObject.SetActive(true);
			this.SetHero_Total();
		}
		if (this.mOpenKind == 4)
		{
			this.Img_Frame.gameObject.SetActive(true);
			this.BG_T1.gameObject.SetActive(false);
			this.BG_T2.gameObject.SetActive(false);
			this.SetHero_Total();
		}
		switch (this.mStatus)
		{
		case 0:
			this.Text_Load[3].gameObject.SetActive(true);
			this.Text_Load[3].text = this.DM.mStringTable.GetStringByID(697u);
			this.Img_StatusBG2[0].gameObject.SetActive(true);
			this.Text_Hint[1].text = this.DM.mStringTable.GetStringByID(769u);
			this.Img_StatusBG.sprite = this.SArray.m_Sprites[13];
			this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ATTACK_MARCH_SPEED);
			this.EGALoadKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_LOAD);
			this.tmpLoad = 10000u + this.EGALoadKind;
			this.Text_HeroTeam.text = this.DM.mStringTable.GetStringByID(690u);
			NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT, this, false);
			if (this.mOpenKind == 4)
			{
				this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_SHELTER_TROOP_AMOUNT);
			}
			if (this.mOpenKind == 8 && this.DM.WarTroop.Count > 0)
			{
				if (this.DM.GetTechLevel(191) != 0)
				{
					this.btn_Formation.gameObject.SetActive(false);
					this.mWarlobbyT.gameObject.SetActive(true);
				}
				this.Set_W_SelectText(this.DM.mWarlobby_Kind, false);
			}
			break;
		case 1:
			if (this.DM.GetTechLevel(119) != 0)
			{
				this.bShowSelectC = true;
			}
			if (this.bShowSelectC)
			{
				this.btn_Formation.gameObject.SetActive(false);
				this.btn_SelectMenu[0].gameObject.SetActive(true);
				this.btn_SelectMenu[1].gameObject.SetActive(true);
			}
			else
			{
				this.btn_Formation.gameObject.SetActive(true);
				this.btn_SelectMenu[0].gameObject.SetActive(false);
				this.btn_SelectMenu[1].gameObject.SetActive(false);
			}
			if (this.DM.mcollectionKind != 255)
			{
				this.mUI_CK = this.DM.mcollectionKind;
				this.mNewType = this.mUI_CK + 1;
				if (this.mUI_CK != 255)
				{
					if (this.mUI_CK < 2)
					{
						this.Img_SelectMenu[0].gameObject.SetActive(true);
						this.Img_SelectMenu[1].gameObject.SetActive(false);
					}
					else
					{
						this.Img_SelectMenu[0].gameObject.SetActive(false);
						this.Img_SelectMenu[1].gameObject.SetActive(true);
					}
				}
			}
			this.ResourcesMax = DataManager.MapDataController.ResourcesPointTable[(int)this.nowMapPoint.tableID].count;
			this.Text_Load[1].gameObject.SetActive(true);
			this.Text_Load[2].gameObject.SetActive(true);
			this.Cstr_LoadNum[1].ClearString();
			this.Cstr_LoadNum[1].IntToFormat((long)((ulong)this.ResourcesMax), 1, true);
			this.Cstr_LoadNum[1].AppendFormat("{0}");
			this.Text_Load[1].text = this.Cstr_LoadNum[1].ToString();
			this.Text_Load[1].SetAllDirty();
			this.Text_Load[1].cachedTextGenerator.Invalidate();
			this.Text_Load[1].cachedTextGeneratorForLayout.Invalidate();
			this.Text_LoadRT.sizeDelta = new Vector2(this.Text_Load[1].preferredWidth, this.Text_LoadRT.sizeDelta.y);
			this.tmpL = Mathf.Ceil(this.Text_LoadRT.anchoredPosition.x + this.Text_Load[1].preferredWidth) - 20f;
			this.Img_TargetRT.anchoredPosition = new Vector2(-this.tmpL, this.Img_TargetRT.anchoredPosition.y);
			this.Text_Load[2].rectTransform.anchoredPosition = new Vector2(-this.tmpL - this.Img_TargetRT.sizeDelta.x, this.Text_Load[2].rectTransform.anchoredPosition.y);
			this.Img_TargetBG.gameObject.SetActive(true);
			this.Img_StatusBG2[0].gameObject.SetActive(true);
			this.Img_StatusBG.sprite = this.SArray.m_Sprites[13];
			this.Img_TargetBG.material = this.door.LoadMaterial();
			this.Text_Hint[1].text = this.DM.mStringTable.GetStringByID(336u);
			this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_GATHERING_MARCH_SPEED);
			this.EGALoadKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_LOAD);
			this.tmpLoad = 10000u + this.EGALoadKind;
			this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_GATHERING_CAPACITY);
			this.Text_HeroTeam.text = this.DM.mStringTable.GetStringByID(690u);
			break;
		case 2:
			this.Img_StatusBG2[1].gameObject.SetActive(true);
			this.Img_StatusBG.sprite = this.SArray.m_Sprites[14];
			this.Text_Load[3].gameObject.SetActive(true);
			this.Text_Load[3].text = this.DM.mStringTable.GetStringByID(698u);
			this.Text_Hint[1].text = this.DM.mStringTable.GetStringByID(692u);
			if (this.MapID < 3)
			{
				this.EGAKind = this.DM.m_InForceMarchSpeedPlus;
			}
			else
			{
				this.EGAKind = 0u;
			}
			this.Text_HeroTeam.text = this.DM.mStringTable.GetStringByID(821u);
			this.Cstr_LoadNum[0].ClearString();
			if (this.MapID < 2)
			{
				this.GoToMaxSoldier = this.DM.m_InForceCapacity - this.DM.m_CurrTroopAmount;
			}
			else
			{
				if (this.DM.WarlobbyDetail != null)
				{
					this.GoToMaxSoldier = this.DM.WarlobbyDetail.AllyMAXTroop - this.DM.WarlobbyDetail.AllyCurrTroop;
				}
				if (this.MapID >= 3)
				{
					this.Text_Load[3].text = this.DM.mStringTable.GetStringByID(7267u);
					this.Text_HeroTeam.text = this.DM.mStringTable.GetStringByID(7266u);
					this.Text_Hint[1].text = this.DM.mStringTable.GetStringByID(9303u);
				}
			}
			this.Cstr_LoadNum[0].IntToFormat((long)((ulong)this.GoToMaxSoldier), 1, true);
			this.Cstr_LoadNum[0].AppendFormat("{0}");
			this.Text_Load[0].text = this.Cstr_LoadNum[0].ToString();
			this.Text_Load[0].SetAllDirty();
			this.Text_Load[0].cachedTextGenerator.Invalidate();
			if (this.mOpenKind == 2 && this.MapID == 4)
			{
				if (this.DM.GetTechLevel(191) != 0)
				{
					this.btn_Formation.gameObject.SetActive(false);
					this.mWarlobbyT.gameObject.SetActive(true);
				}
				this.Set_W_SelectText(this.DM.mWarlobby_Kind, false);
			}
			break;
		case 3:
		case 4:
			this.Img_StatusBG2[2].gameObject.SetActive(true);
			this.Img_StatusBG.sprite = this.SArray.m_Sprites[15];
			this.Text_Load[3].gameObject.SetActive(true);
			this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RALLY_SPEED);
			if (this.mOpenKind == 9)
			{
				if (this.mStatus == 3)
				{
					this.EGASpeed3 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_RALLY_SPEED);
				}
				if (this.mStatus == 4)
				{
					this.EGASpeed3 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_JOINRALLY_SPEED);
				}
			}
			if (this.mOpenKind == 9)
			{
				this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_TROOP_AMOUNT);
			}
			this.Cstr_LoadNum[0].ClearString();
			if (this.mStatus == 4)
			{
				this.Cstr_LoadNum[0].IntToFormat((long)((ulong)(this.DM.WarlobbyDetail.AllyMAXTroop - this.DM.WarlobbyDetail.AllyCurrTroop)), 1, true);
				this.Text_Load[3].text = this.DM.mStringTable.GetStringByID(699u);
				this.Text_Hint[1].text = this.DM.mStringTable.GetStringByID(693u);
				this.Text_HeroTeam.text = this.DM.mStringTable.GetStringByID(822u);
				if (this.DM.GetTechLevel(191) != 0)
				{
					this.btn_Formation.gameObject.SetActive(false);
					this.mWarlobbyT.gameObject.SetActive(true);
				}
				this.Set_W_SelectText(this.DM.mWarlobby_Kind, false);
			}
			else
			{
				this.Cstr_LoadNum[0].IntToFormat((long)((ulong)(this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RALLY_CAPACITY) + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_PETSKILL_RALLY_CAPACITY))), 1, true);
				this.Text_Load[3].text = this.DM.mStringTable.GetStringByID(5879u);
				this.Text_HeroTeam.text = this.DM.mStringTable.GetStringByID(690u);
				this.Text_Hint[1].text = this.DM.mStringTable.GetStringByID(847u);
			}
			this.Cstr_LoadNum[0].AppendFormat("{0}");
			this.Text_Load[0].text = this.Cstr_LoadNum[0].ToString();
			this.Text_Load[0].SetAllDirty();
			this.Text_Load[0].cachedTextGenerator.Invalidate();
			break;
		}
		this.tmpTime = (10000u + this.EGASpeed4) / (10000u + this.EGAKind + this.EGASpeed - this.EGASpeed2 + this.EGASpeed3);
		this.Hero_Total += this.EGACapacityKind;
		this.Text_HintRT[1].sizeDelta = new Vector2(this.Text_HintRT[1].sizeDelta.x, this.Text_Hint[1].preferredHeight);
		this.Img_HintRT[1].sizeDelta = new Vector2(this.Img_HintRT[1].sizeDelta.x, this.Text_Hint[1].preferredHeight + 20f);
		if (this.Text_Hint[1].preferredWidth < this.Text_HintRT[1].sizeDelta.x)
		{
			this.Text_HintRT[1].sizeDelta = new Vector2(this.Text_Hint[1].preferredWidth, this.Img_HintRT[1].sizeDelta.y);
			this.Img_HintRT[1].sizeDelta = new Vector2(this.Text_Hint[1].preferredWidth + 50f, this.Img_HintRT[1].sizeDelta.y);
		}
		this.ItemBuffDataIdx = this.DM.GetRecvBuffDataIdxByID(5);
		if (this.mOpenKind != 10)
		{
			if (this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].bEnable)
			{
				this.mEquip = this.DM.EquipTable.GetRecordByKey(this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].ItemID);
				this.mBuffTotal = (uint)this.mEquip.PropertiesInfo[1].PropertiesValue;
			}
			else
			{
				this.mBuffTotal = 0u;
			}
		}
		else
		{
			this.mBuffTotal = 5000u;
		}
		this.Hero_Total = (uint)(this.Hero_Total * ((10000u + this.mBuffTotal) / 10000.0));
		if (this.mStatus == 2 && this.GoToMaxSoldier < this.Hero_Total)
		{
			this.mExpeditionlimit = (int)(this.GoToMaxSoldier - this.Hero_Total);
		}
		if (this.mStatus == 4)
		{
			uint num17 = this.DM.WarlobbyDetail.AllyMAXTroop - this.DM.WarlobbyDetail.AllyCurrTroop;
			if (num17 < this.Hero_Total)
			{
				this.mExpeditionlimit = (int)(num17 - this.Hero_Total);
			}
		}
		this.Cstr_Troops[0].ClearString();
		this.ExpeditionNum = 0L;
		this.Cstr_Troops[0].IntToFormat(this.ExpeditionNum, 1, true);
		this.Cstr_Troops[0].IntToFormat((long)((ulong)this.Hero_Total), 1, true);
		this.Cstr_Troops[0].AppendFormat("{0} / {1}");
		this.Text_Troops[0].text = this.Cstr_Troops[0].ToString();
		this.Text_Troops[0].SetAllDirty();
		this.Text_Troops[0].cachedTextGenerator.Invalidate();
		this.Cstr_Accelerate.ClearString();
		int num18 = (int)(this.EGAKind + this.EGASpeed - this.EGASpeed2 + this.EGASpeed3);
		if ((float)num18 % 100f != 0f)
		{
			this.Cstr_Accelerate.FloatToFormat((float)num18 / 100f, 2, false);
		}
		else
		{
			this.Cstr_Accelerate.IntToFormat((long)(num18 / 100), 1, false);
		}
		if (this.GUIM.IsArabic)
		{
			this.Cstr_Accelerate.AppendFormat("%{0}");
		}
		else
		{
			this.Cstr_Accelerate.AppendFormat("{0}%");
		}
		this.Text_Time[2].text = this.Cstr_Accelerate.ToString();
		this.Text_Time[2].SetAllDirty();
		this.Text_Time[2].cachedTextGenerator.Invalidate();
		this.Text_Time[2].cachedTextGeneratorForLayout.Invalidate();
		this.Text_Time[2].rectTransform.sizeDelta = new Vector2(this.Text_Time[2].preferredWidth, this.Text_Time[2].rectTransform.sizeDelta.y);
		this.Text_Time[1].rectTransform.anchoredPosition = new Vector2(this.Text_Time[2].rectTransform.anchoredPosition.x - this.Text_Time[2].rectTransform.sizeDelta.x, this.Text_Time[2].rectTransform.anchoredPosition.y);
		if (this.mOpenKind != 1 && this.mOpenKind != 4 && this.mOpenKind != 6 && this.DM.GetTechLevel(120) > 0)
		{
			this.tmpRC = this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>();
			if ((this.tmpRC.sizeDelta.x - 843f) / 2f > 90f)
			{
				this.mSelectTeam_LT.gameObject.SetActive(true);
			}
			else
			{
				this.mSelectTeam_T.gameObject.SetActive(true);
			}
		}
		if (this.mSelectTeam_T.gameObject.activeSelf)
		{
			this.m_ScrollPanel.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(this.m_ScrollPanel.transform.GetComponent<RectTransform>().sizeDelta.x, 344f);
			this.m_ScrollPanel.IntiScrollPanel(344f, 0f, 0f, this.tmplist, 7, this);
		}
		else
		{
			this.m_ScrollPanel.IntiScrollPanel(412f, 0f, 0f, this.tmplist, 7, this);
		}
		this.m_ScrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
		this.mContentRT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
		if (this.DM.bSetExpediton)
		{
			this.m_ScrollPanel.GoTo(this.DM.mScroll_Idx);
			this.DM.bSetExpediton = false;
			this.bPVEOpen = false;
		}
		this.bSpeed = true;
		Array.Sort<byte>(this.SpeedsortData, this);
		this.CheckMaxSelect();
		this.SelectFormation();
		if ((this.mOpenKind == 1 && this.bPVEOpen) || this.mOpenKind == 4)
		{
			this.UpPanelData(0);
		}
		else
		{
			this.SetDRformURS(0);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 6);
		if (this.door != null && this.mOpenKind != 6 && this.mOpenKind != 10)
		{
			this.door.ShowFightButton(new Vector3(280f, -282f, -500f), 250f, false, E3DButtonKind.BK_Big);
		}
		this.DM.bSetExpediton = true;
		for (int num19 = 0; num19 < 16; num19++)
		{
			this.DM.mExpeditionSoldierList[num19] = (uint)this.m_Soldier[num19];
		}
		if (this.mOpenKind == 6)
		{
			this.DM.mOpenExpeditionNum = this.ExpeditionNum;
		}
		this.bOpenEnd = true;
	}

	// Token: 0x06001AF9 RID: 6905 RVA: 0x002E27D8 File Offset: 0x002E09D8
	public void SetaApplyEnable(UIButton sender, bool Enable)
	{
		if (Enable)
		{
			sender.image.color = Color.white;
		}
		else
		{
			sender.image.color = Color.gray;
		}
	}

	// Token: 0x06001AFA RID: 6906 RVA: 0x002E2810 File Offset: 0x002E0A10
	public void OnButtonClick(UIButton sender)
	{
		if (this.fightButtonTime > 0f)
		{
			return;
		}
		this.m_ScrollRect.StopMovement();
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.mOpenKind == 6)
			{
				if (this.DM.bChangHero)
				{
					if (this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[0] != 0)
					{
						byte b = 0;
						for (int i = 0; i < 5; i++)
						{
							if (this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[i] != 0)
							{
								b += 1;
							}
						}
						if (this.DM.LegionBattleHero.Count != (int)b)
						{
							GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5893u), this.DM.mStringTable.GetStringByID(997u), 3, 0, this.DM.mStringTable.GetStringByID(3u), this.DM.mStringTable.GetStringByID(4u));
							return;
						}
						int num = 0;
						while (num < 5 && num < this.DM.LegionBattleHero.Count)
						{
							if (this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[num] != this.DM.LegionBattleHero[num])
							{
								GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5893u), this.DM.mStringTable.GetStringByID(997u), 3, 0, this.DM.mStringTable.GetStringByID(3u), this.DM.mStringTable.GetStringByID(4u));
								return;
							}
							num++;
						}
					}
					else if (this.DM.LegionBattleHero.Count > 0)
					{
						GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5893u), this.DM.mStringTable.GetStringByID(997u), 3, 0, this.DM.mStringTable.GetStringByID(3u), this.DM.mStringTable.GetStringByID(4u));
						return;
					}
				}
				if (this.DM.bChangSoldier)
				{
					for (int j = 0; j < 16; j++)
					{
						if ((ulong)this.DM.mTroopMemoryData[(int)this.TMD_Idx].TroopData[j] != (ulong)this.m_Soldier[j])
						{
							GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5893u), this.DM.mStringTable.GetStringByID(997u), 3, 0, this.DM.mStringTable.GetStringByID(3u), this.DM.mStringTable.GetStringByID(4u));
							return;
						}
					}
				}
				if (this.DM.bChangName && string.Compare(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Label, 0, this.TMD_Name, 0, this.DM.mTroopMemoryData[(int)this.TMD_Idx].Label.Length) != 0)
				{
					GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5893u), this.DM.mStringTable.GetStringByID(997u), 3, 0, this.DM.mStringTable.GetStringByID(3u), this.DM.mStringTable.GetStringByID(4u));
					return;
				}
			}
			this.DM.bSetExpediton = false;
			for (int k = 0; k < 16; k++)
			{
				this.DM.mExpeditionSoldierList[k] = 0u;
			}
			this.DM.LegionBattleHero.Clear();
			if (this.mWarlobbyKind >= 0 && this.mWarlobbyKind <= 2)
			{
				this.mUI_WarlobbyK = byte.MaxValue;
			}
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			if (this.mOpenKind == 4)
			{
				HideArmyManager.Instance.OpenHideArmyUI();
			}
			if (this.mOpenKind == 6)
			{
				this.DM.TeamName.ClearString();
			}
			this.DM.bChangHero = false;
			this.DM.bChangName = false;
			this.DM.bChangSoldier = false;
			break;
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
			if (this.mOpenKind == 2 || this.mStatus == 4)
			{
				return;
			}
			if (this.DM.NonFightHeroCount == 0u)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(875u), 255, true);
				return;
			}
			this.DM.bSetExpediton = true;
			this.DM.mMapId = this.MapID;
			this.DM.mScroll_Y = this.mContentRT.anchoredPosition.y;
			this.DM.mScroll_Idx = this.m_ScrollPanel.GetTopIdx();
			for (int l = 0; l < 16; l++)
			{
				this.DM.mExpeditionSoldierList[l] = (uint)this.m_Soldier[l];
			}
			if (this.door != null)
			{
				if (this.mOpenKind != 6)
				{
					this.door.OpenMenu(EGUIWindow.UI_HeroList_Soldier2, 0, 0, false);
				}
				else
				{
					this.door.OpenMenu(EGUIWindow.UI_HeroList_Soldier2, 0, 1, false);
				}
			}
			if (this.mOpenKind == 6 && !this.DM.bChangHero)
			{
				this.DM.bChangHero = true;
			}
			break;
		case 7:
			if (!this.bClear)
			{
				this.UpPanelData(0);
			}
			else
			{
				this.ClearSoldier();
			}
			break;
		case 8:
			this.ShowSelectMenu(false);
			break;
		case 9:
			if (this.mOpenKind == 0 && DataManager.MapDataController.LayoutMapInfo[this.MapID].pointKind != 0)
			{
				ushort tableID = DataManager.MapDataController.LayoutMapInfo[this.MapID].tableID;
				if (DataManager.MapDataController.IsResources((uint)tableID))
				{
					if (DataManager.MapDataController.ResourcesPointTable[(int)tableID].playerName.Length != 0 && (DataManager.CompareStr(DataManager.MapDataController.ResourcesPointTable[(int)tableID].playerName, DataManager.Instance.RoleAttr.Name) == 0 || DataManager.Instance.IsSameAlliance(DataManager.MapDataController.ResourcesPointTable[(int)tableID].allianceTag)))
					{
						this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(614u), this.DM.mStringTable.GetStringByID(645u), null, null, 0, 0, false, false, false, false, false);
						return;
					}
				}
				else if (DataManager.MapDataController.IsCityOrCamp((uint)this.MapID) && (this.MapID == DataManager.Instance.RoleAttr.CapitalPoint || DataManager.Instance.IsSameAlliance(DataManager.MapDataController.PlayerPointTable[(int)tableID].allianceTag)))
				{
					this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(614u), this.DM.mStringTable.GetStringByID(645u), null, null, 0, 0, false, false, false, false, false);
					return;
				}
			}
			if (this.fightButtonTime > 0f)
			{
				return;
			}
			if (this.ExpeditionNum < 1L)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(695u), 255, true);
				return;
			}
			if (this.ExpeditionNum > (long)((ulong)this.Hero_Total))
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(712u), 255, true);
				return;
			}
			if (this.mOpenKind == 0)
			{
				MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.MapID];
				POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)this.MapID);
				if (DataManager.MapDataController.IsResources((uint)this.MapID))
				{
					if (DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].playerName.Length != 0 && DataManager.CompareStr(DataManager.MapDataController.ResourcesPointTable[(int)mapPoint.tableID].playerName, DataManager.Instance.RoleAttr.Name) != 0 && ShieldLogManager.Instance.HasShieldState())
					{
						int warBuffCD = this.DM.GetWarBuffCD();
						if (warBuffCD > 0)
						{
							this.GUIM.MsgStr.ClearString();
							this.GUIM.MsgStr.IntToFormat((long)warBuffCD, 1, false);
							this.GUIM.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9933u));
							this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4840u), this.GUIM.MsgStr.ToString(), 1, 0, this.DM.mStringTable.GetStringByID(4842u), this.DM.mStringTable.GetStringByID(4843u));
						}
						else
						{
							this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4840u), this.DM.mStringTable.GetStringByID(621u), 1, 0, this.DM.mStringTable.GetStringByID(3u), this.DM.mStringTable.GetStringByID(617u));
						}
						return;
					}
				}
				else if (ShieldLogManager.Instance.HasShieldState() && (layoutMapInfoPointKind == POINT_KIND.PK_CITY || layoutMapInfoPointKind == POINT_KIND.PK_CAMP || layoutMapInfoPointKind == POINT_KIND.PK_YOLK))
				{
					int warBuffCD2 = this.DM.GetWarBuffCD();
					if (warBuffCD2 > 0)
					{
						this.GUIM.MsgStr.ClearString();
						this.GUIM.MsgStr.IntToFormat((long)warBuffCD2, 1, false);
						this.GUIM.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9933u));
						this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4840u), this.GUIM.MsgStr.ToString(), 1, 0, this.DM.mStringTable.GetStringByID(4842u), this.DM.mStringTable.GetStringByID(4843u));
					}
					else
					{
						this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4840u), this.DM.mStringTable.GetStringByID(621u), 1, 0, this.DM.mStringTable.GetStringByID(3u), this.DM.mStringTable.GetStringByID(617u));
					}
					return;
				}
			}
			if (this.mOpenKind == 3 && this.mStatus == 4)
			{
				this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4964u), this.DM.mStringTable.GetStringByID(4965u), 2, 0, this.DM.mStringTable.GetStringByID(4966u), this.DM.mStringTable.GetStringByID(4967u));
				return;
			}
			if (this.mOpenKind == 9 && this.mStatus == 4)
			{
				this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4964u), this.DM.mStringTable.GetStringByID(4965u), 4, 0, this.DM.mStringTable.GetStringByID(4966u), this.DM.mStringTable.GetStringByID(4967u));
				return;
			}
			if ((this.mOpenKind == 2 || this.mOpenKind == 3 || this.mOpenKind == 5 || this.mOpenKind == 7 || this.mOpenKind == 8) && ShieldLogManager.Instance.HasShieldState())
			{
				int warBuffCD3 = this.DM.GetWarBuffCD();
				if (warBuffCD3 > 0)
				{
					this.GUIM.MsgStr.ClearString();
					this.GUIM.MsgStr.IntToFormat((long)warBuffCD3, 1, false);
					this.GUIM.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9933u));
					this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4840u), this.GUIM.MsgStr.ToString(), 1, 0, this.DM.mStringTable.GetStringByID(4842u), this.DM.mStringTable.GetStringByID(4843u));
				}
				else
				{
					this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(614u), this.DM.mStringTable.GetStringByID(621u), 1, 0, this.DM.mStringTable.GetStringByID(3u), this.DM.mStringTable.GetStringByID(617u));
				}
				return;
			}
			if (this.mOpenKind == 1 && !this.CheckPower())
			{
				this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(7376u), this.DM.mStringTable.GetStringByID(7375u), 1, 0, null, null);
				return;
			}
			if (this.mOpenKind != 4 && this.mOpenKind != 5)
			{
				this.GUIM.ShowUILock(EUILock.Expedition);
				this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_Expedition);
			}
			if (this.mOpenKind == 1)
			{
				this.SendExpedition();
			}
			else
			{
				this.fightButtonTime = this.door.PlayFight(0f);
			}
			break;
		case 10:
		case 11:
		case 12:
		case 13:
			this.mUI_CK = (byte)(sender.m_BtnID1 - 10);
			this.mNewType = this.mUI_CK + 1;
			if (this.mUI_CK % 2 == 0)
			{
				this.Text_SelectMenu[1].text = this.DM.mStringTable.GetStringByID(333u);
			}
			else
			{
				this.Text_SelectMenu[1].text = this.DM.mStringTable.GetStringByID(334u);
			}
			this.Text_SelectMenu[1].SetAllDirty();
			this.Text_SelectMenu[1].cachedTextGenerator.Invalidate();
			this.Text_SelectMenu[0].text = this.mbtnFormation[1];
			this.Text_SelectMenu[0].SetAllDirty();
			this.Text_SelectMenu[0].cachedTextGenerator.Invalidate();
			this.UpPanelData(this.mNewType);
			this.ShowSelectMenu(false);
			break;
		case 17:
		{
			if (this.mOpenKind == 2 || this.mStatus == 4)
			{
				return;
			}
			if (this.DM.NonFightHeroCount == 0u && this.mOpenKind != 6)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(875u), 255, true);
				return;
			}
			this.DM.SetSortNonFightHeroID();
			int num2 = 0;
			while (num2 < this.DM.GetMaxDefenders() && (long)num2 < (long)((ulong)this.DM.NonFightHeroCount))
			{
				this.DM.LegionBattleHero.Add((ushort)this.DM.SortNonFightHeroID[num2]);
				num2++;
			}
			this.BG_T1.gameObject.SetActive(false);
			this.BG_T2.gameObject.SetActive(true);
			this.SetHero_Total();
			if (this.mStatus == 1 || this.mOpenKind == 9)
			{
				this.Hero_Total += this.EGACapacityKind;
			}
			this.Hero_Total = (uint)(this.Hero_Total * ((10000u + this.mBuffTotal) / 10000.0));
			for (int m = 0; m < 7; m++)
			{
				if (this.m_UnitRS_Item[m] != null)
				{
					int type = (int)this.m_UnitRS_Item[m].Type;
					long num3 = this.m_Soldier[this.m_UnitRS_Item[type].m_ID];
					this.m_UnitRS_Item[type].MaxValue = (long)((ulong)this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0]);
					this.m_UnitRS_Item[type].Value = num3;
					this.m_UnitRS_Item[type].m_slider.maxValue = this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0];
					this.m_UnitRS_Item[type].m_slider.value = (double)num3;
					if (this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0] >= this.Hero_Total)
					{
						this.m_UnitRS_Item[type].MaxValue = (long)((ulong)this.Hero_Total);
						this.m_UnitRS_Item[type].m_slider.maxValue = this.Hero_Total;
					}
					if (num3 >= (long)((ulong)this.Hero_Total))
					{
						this.m_UnitRS_Item[type].Value = (long)((ulong)this.Hero_Total);
						this.m_UnitRS_Item[type].m_slider.value = this.Hero_Total;
						num3 = (long)((ulong)this.Hero_Total);
					}
					this.Cstr_Soldier_Text[type].ClearString();
					this.Cstr_Soldier_Text[type].IntToFormat(num3, 1, true);
					this.Cstr_Soldier_Text[type].AppendFormat("{0}");
					this.m_UnitRS_Item[type].m_inputText.text = this.Cstr_Soldier_Text[type].ToString();
					this.m_UnitRS_Item[type].m_inputText.SetAllDirty();
					this.m_UnitRS_Item[type].m_inputText.cachedTextGenerator.Invalidate();
					if (num3 != 0L)
					{
						this.m_UnitRS_Item[type].m_inputText.color = this.mtextColor;
					}
					else
					{
						this.m_UnitRS_Item[type].m_inputText.color = Color.white;
					}
					this.Cstr_Soldier_ItemNum[type].ClearString();
					this.Cstr_Soldier_ItemNum[type].IntToFormat((long)((ulong)this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0] - (ulong)num3), 1, true);
					this.Cstr_Soldier_ItemNum[type].AppendFormat("{0}");
					this.Text_Soldier_ItemNum[type].text = this.Cstr_Soldier_ItemNum[type].ToString();
					this.Text_Soldier_ItemNum[type].SetAllDirty();
					this.Text_Soldier_ItemNum[type].cachedTextGenerator.Invalidate();
				}
			}
			this.SetDRformURS(0);
			if (this.mStatus == 1)
			{
				this.CheckMaxSelect();
				this.SelectFormation();
			}
			if (this.mOpenKind == 6 && !this.DM.bChangHero)
			{
				this.DM.bChangHero = true;
			}
			break;
		}
		case 18:
			this.DM.LegionBattleHero.Clear();
			this.BG_T1.gameObject.SetActive(true);
			this.BG_T2.gameObject.SetActive(false);
			this.SetHero_Total();
			if (this.mStatus == 1 || this.mOpenKind == 9)
			{
				this.Hero_Total += this.EGACapacityKind;
			}
			this.Hero_Total = (uint)(this.Hero_Total * ((10000u + this.mBuffTotal) / 10000.0));
			for (int n = 0; n < 7; n++)
			{
				if (this.m_UnitRS_Item[n] != null)
				{
					int type2 = (int)this.m_UnitRS_Item[n].Type;
					long num4 = this.m_Soldier[this.m_UnitRS_Item[type2].m_ID];
					this.m_UnitRS_Item[type2].MaxValue = (long)((ulong)this.m_SoldierMax[this.m_UnitRS_Item[type2].m_ID].Value[0]);
					this.m_UnitRS_Item[type2].Value = num4;
					this.m_UnitRS_Item[type2].m_slider.maxValue = this.m_SoldierMax[this.m_UnitRS_Item[type2].m_ID].Value[0];
					this.m_UnitRS_Item[type2].m_slider.value = (double)num4;
					if (this.m_SoldierMax[this.m_UnitRS_Item[type2].m_ID].Value[0] >= this.Hero_Total)
					{
						this.m_UnitRS_Item[type2].MaxValue = (long)((ulong)this.Hero_Total);
						this.m_UnitRS_Item[type2].m_slider.maxValue = this.Hero_Total;
					}
					if (num4 >= (long)((ulong)this.Hero_Total))
					{
						this.m_UnitRS_Item[type2].Value = (long)((ulong)this.Hero_Total);
						this.m_UnitRS_Item[type2].m_slider.value = this.Hero_Total;
						num4 = (long)((ulong)this.Hero_Total);
						this.m_Soldier[this.m_UnitRS_Item[type2].m_ID] = num4;
					}
					this.Cstr_Soldier_Text[type2].ClearString();
					this.Cstr_Soldier_Text[type2].IntToFormat(num4, 1, true);
					this.Cstr_Soldier_Text[type2].AppendFormat("{0}");
					this.m_UnitRS_Item[type2].m_inputText.text = this.Cstr_Soldier_Text[type2].ToString();
					this.m_UnitRS_Item[type2].m_inputText.SetAllDirty();
					this.m_UnitRS_Item[type2].m_inputText.cachedTextGenerator.Invalidate();
					if (num4 != 0L)
					{
						this.m_UnitRS_Item[type2].m_inputText.color = this.mtextColor;
					}
					else
					{
						this.m_UnitRS_Item[type2].m_inputText.color = Color.white;
					}
					this.Cstr_Soldier_ItemNum[type2].ClearString();
					this.Cstr_Soldier_ItemNum[type2].IntToFormat((long)((ulong)this.m_SoldierMax[this.m_UnitRS_Item[type2].m_ID].Value[0] - (ulong)num4), 1, true);
					this.Cstr_Soldier_ItemNum[type2].AppendFormat("{0}");
					this.Text_Soldier_ItemNum[type2].text = this.Cstr_Soldier_ItemNum[type2].ToString();
					this.Text_Soldier_ItemNum[type2].SetAllDirty();
					this.Text_Soldier_ItemNum[type2].cachedTextGenerator.Invalidate();
				}
			}
			this.SetDRformURS(0);
			if (this.mStatus == 1)
			{
				this.CheckMaxSelect();
				this.SelectFormation();
			}
			if (this.mOpenKind == 6 && !this.DM.bChangHero)
			{
				this.DM.bChangHero = true;
			}
			break;
		case 19:
			this.GUIM.m_UICalculator.m_CalculatorHandler = this;
			this.GUIM.m_UICalculator.OpenCalculator(this.m_UnitRS_Item[sender.m_BtnID2].MaxValue, this.m_UnitRS_Item[sender.m_BtnID2].Value, 289f, -100f, this.m_UnitRS_Item[sender.m_BtnID2], 0L);
			break;
		case 20:
			if (this.DM.GetHeroState(this.DM.GetLeaderID()) != eHeroState.None)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(708u), 255, true);
				return;
			}
			this.bCaveMainHero = !this.bCaveMainHero;
			this.Img_CaveStatus.gameObject.SetActive(this.bCaveMainHero);
			if (this.bCaveMainHero)
			{
				this.DM.LegionBattleHero.Add(this.DM.GetLeaderID());
			}
			else
			{
				this.DM.LegionBattleHero.Clear();
			}
			this.SetHero_Total();
			if (this.mOpenKind != 10)
			{
				if (this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].bEnable)
				{
					this.mEquip = this.DM.EquipTable.GetRecordByKey(this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].ItemID);
					this.mBuffTotal = (uint)this.mEquip.PropertiesInfo[1].PropertiesValue;
				}
				else
				{
					this.mBuffTotal = 0u;
				}
			}
			else
			{
				this.mBuffTotal = 5000u;
			}
			this.Hero_Total += this.EGACapacityKind;
			this.Hero_Total = (uint)(this.Hero_Total * ((10000u + this.mBuffTotal) / 10000.0));
			this.SetDRformURS(0);
			break;
		case 21:
			if (this.mUI_CK != 255)
			{
				if (!this.bClear)
				{
					this.UpPanelData(this.mNewType);
				}
				else
				{
					this.ClearSoldier();
				}
			}
			else
			{
				this.ShowSelectMenu(true);
			}
			break;
		case 22:
			this.ShowSelectMenu(true);
			break;
		case 23:
			if (!this.DM.bChangName)
			{
				this.DM.bChangName = true;
			}
			this.DM.OpenAllianceBox(39, 10, false, 0L);
			break;
		case 24:
			if (this.ExpeditionNum > (long)((ulong)this.Hero_Total))
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(712u), 255, true);
				return;
			}
			this.SendSaveTeam();
			break;
		case 25:
		{
			if (this.mOpenKind != 10)
			{
				if (this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].bEnable)
				{
					this.mEquip = this.DM.EquipTable.GetRecordByKey(this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].ItemID);
					this.mBuffTotal = (uint)this.mEquip.PropertiesInfo[1].PropertiesValue;
				}
				else
				{
					this.mBuffTotal = 0u;
				}
			}
			else
			{
				this.mBuffTotal = 5000u;
			}
			this.Hero_Total = this.BaseNum;
			int btnID = sender.m_BtnID2;
			if (btnID < 0 && btnID > 5)
			{
				return;
			}
			CString cstring = StringManager.Instance.StaticString1024();
			if (btnID + 1 > (int)this.DM.GetTechLevel(120))
			{
				cstring.StringToFormat(this.DM.mStringTable.GetStringByID(5220u));
				cstring.AppendFormat(this.DM.mStringTable.GetStringByID(3775u));
				this.GUIM.AddHUDMessage(cstring.ToString(), 255, true);
				return;
			}
			long num5 = 0L;
			for (int num6 = 0; num6 < 16; num6++)
			{
				num5 += (long)((ulong)this.DM.mTroopMemoryData[btnID].TroopData[num6]);
			}
			if (this.DM.mTroopMemoryData[btnID].Leader[0] == 0 && num5 == 0L)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(995u), 255, true);
				return;
			}
			bool flag = false;
			this.DM.LegionBattleHero.Clear();
			if (this.mOpenKind != 2 && this.mStatus != 4 && this.mOpenKind != 4)
			{
				bool flag2 = false;
				int num7 = 0;
				int num8 = 0;
				for (int num9 = 0; num9 < 5; num9++)
				{
					eHeroState heroState = this.DM.GetHeroState(this.DM.mTroopMemoryData[btnID].Leader[num9]);
					if (this.DM.mTroopMemoryData[btnID].Leader[num9] != 0 && heroState == eHeroState.None)
					{
						if (this.DM.mTroopMemoryData[btnID].Leader[num9] == this.DM.GetLeaderID())
						{
							flag2 = true;
							num7 = num9;
						}
						num8++;
					}
				}
				for (int num10 = 0; num10 < 5; num10++)
				{
					if (this.DM.mTroopMemoryData[btnID].Leader[num10] > 0)
					{
						if (this.DM.GetHeroState(this.DM.mTroopMemoryData[btnID].Leader[num10]) == eHeroState.None)
						{
							if (flag2 && num7 != 0)
							{
								if (num10 == 0)
								{
									this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[btnID].Leader[num7]);
								}
								else if (num8 < 5 && num10 == num8 - 1)
								{
									this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[btnID].Leader[0]);
								}
								else if (num8 == 5 && this.DM.mTroopMemoryData[btnID].Leader[num10] == this.DM.GetLeaderID())
								{
									this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[btnID].Leader[0]);
								}
								else
								{
									this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[btnID].Leader[num10]);
								}
							}
							else
							{
								this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[btnID].Leader[num10]);
							}
						}
						else
						{
							flag = true;
						}
					}
				}
				if (this.DM.LegionBattleHero.Count > 0)
				{
					this.bExpeditionHero = true;
					this.BG_T1.gameObject.SetActive(false);
					this.BG_T2.gameObject.SetActive(true);
				}
				else
				{
					this.bExpeditionHero = false;
					this.BG_T1.gameObject.SetActive(true);
					this.BG_T2.gameObject.SetActive(false);
				}
			}
			this.DM.bSetExpediton = true;
			this.SetHero_Total();
			if (this.mStatus == 1 || this.mOpenKind == 9)
			{
				this.Hero_Total += this.EGACapacityKind;
			}
			this.Hero_Total = (uint)(this.Hero_Total * ((10000u + this.mBuffTotal) / 10000.0));
			long num11 = (long)((ulong)this.Hero_Total + (ulong)((long)this.mExpeditionlimit));
			if (num11 < (long)((ulong)this.DM.mTroopMemoryData[btnID].MaxTroop) && num5 > num11)
			{
				double num12 = (double)num11 / this.DM.mTroopMemoryData[btnID].MaxTroop;
				for (int num13 = 0; num13 < 16; num13++)
				{
					this.DM.mExpeditionSoldierList[num13] = (uint)(this.DM.mTroopMemoryData[btnID].TroopData[num13] * num12);
				}
			}
			else
			{
				for (int num14 = 0; num14 < 16; num14++)
				{
					this.DM.mExpeditionSoldierList[num14] = this.DM.mTroopMemoryData[btnID].TroopData[num14];
				}
			}
			for (int num15 = 0; num15 < 16; num15++)
			{
				ushort num16 = (ushort)(4 - num15 / 4 + num15 % 4 * 4);
				if (this.DM.mExpeditionSoldierList[num15] > this.DM.RoleAttr.m_Soldier[(int)(num16 - 1)])
				{
					this.DM.mExpeditionSoldierList[num15] = this.DM.RoleAttr.m_Soldier[(int)(num16 - 1)];
					flag = true;
				}
			}
			this.ClearSoldier();
			this.UpDataSoldier();
			this.bSpeed = true;
			Array.Sort<byte>(this.SpeedsortData, this);
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			this.SetDRformURS(0);
			if (flag)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(994u), 255, true);
			}
			cstring.ClearString();
			cstring.StringToFormat(this.DM.mTroopMemoryData[btnID].Label);
			cstring.AppendFormat(this.DM.mStringTable.GetStringByID(996u));
			this.GUIM.AddHUDMessage(cstring.ToString(), 255, true);
			this.CheckMaxSelect();
			this.SelectFormation();
			break;
		}
		case 26:
			this.SendExpedition();
			break;
		case 27:
			this.SetWarlobbyMenu(true, 0);
			break;
		case 28:
			if (this.mUI_WarlobbyK != 255)
			{
				if (!this.bClear)
				{
					if (this.mUI_WarlobbyK == 0)
					{
						this.UpPanelData(0);
					}
					else
					{
						this.CheckWarlobbyTroopSelect(this.mUI_WarlobbyK, true);
						this.SetWarlobbyMenu(true, 1);
					}
				}
				else
				{
					this.ClearSoldier();
				}
			}
			else
			{
				this.SetWarlobbyMenu(true, 0);
			}
			break;
		case 29:
			this.mUI_WarlobbyK_btn = byte.MaxValue;
			this.SetWarlobbyMenu(false, 0);
			break;
		case 30:
			this.mUI_WarlobbyK_btn = byte.MaxValue;
			this.SetWarlobbyMenu(false, 0);
			break;
		case 31:
			this.mUI_WarlobbyK = 0;
			this.SetWarlobbyMenu(false, 0);
			this.Set_W_SelectText(0, true);
			this.UpPanelData(0);
			break;
		case 32:
		case 33:
			this.mUI_WarlobbyK_btn = (byte)(sender.m_BtnID1 - 31);
			this.CheckWarlobbyTroopSelect(this.mUI_WarlobbyK_btn, true);
			this.SetWarlobbyMenu(true, 1);
			break;
		case 34:
			if (sender.m_BtnType == e_BtnType.e_ChangeText)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(14725u), 255, true);
			}
			else if (this.WarlobbySelectQty == this.WarlobbyTroopMax || !this.GUIM.OpenCheckWarlobbyTroopSelect())
			{
				if (this.mUI_WarlobbyK_btn != 255)
				{
					this.mUI_WarlobbyK = this.mUI_WarlobbyK_btn;
				}
				this.SetWarlobbyMenu(false, 0);
				this.SetWarlobbyTroopSelect();
			}
			break;
		}
	}

	// Token: 0x06001AFB RID: 6907 RVA: 0x002E4B5C File Offset: 0x002E2D5C
	public void SendSaveTeam()
	{
		for (int i = 0; i < 5; i++)
		{
			this.tmpTMD.Leader[i] = (ushort)this.Hero_ID[i];
		}
		this.tmpTMD.MaxTroop = this.Hero_Total;
		for (int j = 0; j < 16; j++)
		{
			int num = (3 - j % 4) * 4 + j / 4;
			this.tmpTMD.TroopData[j] = (uint)this.m_Soldier[num];
		}
		this.Cstr_TeamName.ClearString();
		this.Cstr_TeamName.IntToFormat((long)(this.TMD_Idx + 1), 1, false);
		this.Cstr_TeamName.AppendFormat(this.DM.mStringTable.GetStringByID(993u));
		if (string.Compare(this.Cstr_TeamName.ToString(), 0, this.TMD_Name, 0, this.Cstr_TeamName.Length) == 0)
		{
			this.tmpTMD.Label = string.Empty;
		}
		else
		{
			this.tmpTMD.Label = this.TMD_Name;
		}
		this.DM.SendTroopmemory_Setup(this.TMD_Idx, this.tmpTMD);
	}

	// Token: 0x06001AFC RID: 6908 RVA: 0x002E4C80 File Offset: 0x002E2E80
	public void ShowSelectMenu(bool bopen)
	{
		if (bopen)
		{
			this.btn_FormationMenu.gameObject.SetActive(true);
		}
		else
		{
			this.btn_FormationMenu.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001AFD RID: 6909 RVA: 0x002E4CBC File Offset: 0x002E2EBC
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			switch (arg1)
			{
			case 1:
				if (this.mOpenKind != 5)
				{
					this.GUIM.ShowUILock(EUILock.Expedition);
					this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_Expedition);
				}
				this.SendExpedition();
				break;
			case 2:
				if (ShieldLogManager.Instance.HasShieldState())
				{
					int warBuffCD = this.DM.GetWarBuffCD();
					if (warBuffCD <= 0)
					{
						this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(614u), this.DM.mStringTable.GetStringByID(621u), 1, 0, this.DM.mStringTable.GetStringByID(3u), this.DM.mStringTable.GetStringByID(617u));
						return;
					}
					this.GUIM.MsgStr.ClearString();
					this.GUIM.MsgStr.IntToFormat((long)warBuffCD, 1, false);
					this.GUIM.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9933u));
					this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4840u), this.GUIM.MsgStr.ToString(), 1, 0, this.DM.mStringTable.GetStringByID(4842u), this.DM.mStringTable.GetStringByID(4843u));
				}
				else
				{
					this.GUIM.ShowUILock(EUILock.Expedition);
					this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_Expedition);
					this.SendExpedition();
				}
				break;
			case 3:
				this.DM.bSetExpediton = false;
				for (int i = 0; i < 16; i++)
				{
					this.DM.mExpeditionSoldierList[i] = 0u;
				}
				this.DM.LegionBattleHero.Clear();
				if (this.mOpenKind == 6)
				{
					this.DM.TeamName.ClearString();
				}
				if (this.door != null)
				{
					this.door.CloseMenu(false);
				}
				this.DM.bChangHero = false;
				this.DM.bChangName = false;
				this.DM.bChangSoldier = false;
				break;
			case 4:
				this.GUIM.ShowUILock(EUILock.Expedition);
				this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_Expedition);
				this.SendExpedition();
				break;
			}
		}
	}

	// Token: 0x06001AFE RID: 6910 RVA: 0x002E4F44 File Offset: 0x002E3144
	public bool CheckPower()
	{
		StageManager stageDataController = DataManager.StageDataController;
		float num = 0f;
		float num2 = 0f;
		for (int i = 0; i < 16; i++)
		{
			if (this.m_Soldier[i] > 0L)
			{
				ushort inKey = (ushort)(4 - i / 4 + i % 4 * 4);
				this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey(inKey);
				num += (float)this.m_Soldier[i] * this.tmpPVEPower[(int)(this.tmpSD.Tier - 1)];
			}
		}
		for (int j = 0; j < (int)stageDataController.mStageTroopsCount; j++)
		{
			if (stageDataController.NowCombatStageInfo[j].Amount > 0u)
			{
				this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)stageDataController.NowCombatStageInfo[j].SoldierTableID);
				num2 += stageDataController.NowCombatStageInfo[j].Amount * this.tmpPVEPower[(int)(this.tmpSD.Tier - 1)];
			}
		}
		for (int k = (int)stageDataController.mStageTroopsCount; k < (int)(stageDataController.mStageTroopsCount + stageDataController.mStageTrapsCount); k++)
		{
			if (stageDataController.CorpsStageWallDefence > 0u && stageDataController.NowCombatStageInfo[k].Amount > 0u)
			{
				this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)stageDataController.NowCombatStageInfo[k].SoldierTableID);
				num2 += stageDataController.NowCombatStageInfo[k].Amount * this.tmpPVEPower[(int)(this.tmpSD.Tier - 1)];
			}
		}
		return num > num2;
	}

	// Token: 0x06001AFF RID: 6911 RVA: 0x002E5104 File Offset: 0x002E3304
	public void SendExpedition()
	{
		if (this.ExpeditionNum < 1L)
		{
			this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(695u), 255, true);
			return;
		}
		this.DM.mMapId = 0;
		this.DM.bSetExpediton = false;
		if (this.mOpenKind == 3 || this.mOpenKind == 9)
		{
			if (this.mStatus == 4)
			{
				MessagePacket messagePacket = new MessagePacket(1024);
				uint[] array = new uint[16];
				for (int i = 0; i < 16; i++)
				{
					int num = (3 - i % 4) * 4 + i / 4;
					array[i] = (uint)this.m_Soldier[num];
				}
				messagePacket.Protocol = Protocol._MSG_REQUEST_JOIN_RALLY;
				ushort num2 = 0;
				int num3 = 1;
				byte[] array2 = new byte[64];
				int num4 = 0;
				messagePacket.AddSeqId();
				messagePacket.Add(this.AllyName.ToString(), 13);
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j] != 0u)
					{
						num2 |= (ushort)(num3 << j);
						GameConstants.GetBytes(array[j], array2, num4);
						num4 += 4;
					}
				}
				messagePacket.Add(num2);
				messagePacket.Add(array2, 0, num4);
				messagePacket.Send(false);
			}
			else
			{
				ushort[] array3 = new ushort[5];
				uint[] array4 = new uint[16];
				for (int k = 0; k < 5; k++)
				{
					array3[k] = (ushort)this.Hero_ID[k];
				}
				for (int l = 0; l < 16; l++)
				{
					int num = (3 - l % 4) * 4 + l / 4;
					array4[l] = (uint)this.m_Soldier[num];
				}
				this.DM.SendBeginRally(ref array3, ref array4);
			}
		}
		else if (this.mOpenKind < 3)
		{
			MessagePacket messagePacket2 = new MessagePacket(1024);
			if (this.mOpenKind < 2)
			{
				if (this.mOpenKind == 0)
				{
					messagePacket2.Protocol = Protocol._MSG_REQUEST_TROOPMARCH;
					this.DM.mMapId = this.MapID;
				}
				else
				{
					messagePacket2.Protocol = Protocol._MSG_REQUEST_COMBATINIT_NPC;
					Array.Clear(this.DM.pLeftTroopForce, 0, this.DM.pLeftTroopForce.Length);
					for (int m = 0; m < 5; m++)
					{
						this.DM.pLeftLeaderData[m] = default(TroopLeaderType);
					}
					this.DM.War_LeftHeroNum = 0;
					for (int n = 0; n < 5; n++)
					{
						if (this.Hero_ID[n] != 0u)
						{
							CurHeroData curHeroData = this.DM.curHeroData[this.Hero_ID[n]];
							this.DM.pLeftLeaderData[n].HeroID = curHeroData.ID;
							this.DM.pLeftLeaderData[n].Rank = curHeroData.Enhance;
							this.DM.pLeftLeaderData[n].Star = curHeroData.Star;
							DataManager dm = this.DM;
							dm.War_LeftHeroNum += 1;
						}
					}
					ushort[] array5 = new ushort[10];
					for (int num5 = 0; num5 < 5; num5++)
					{
						array5[num5] = this.DM.pLeftLeaderData[num5].HeroID;
					}
					if (!WarManager.CheckVersion(true))
					{
						this.GUIM.HideUILock(EUILock.Expedition);
						return;
					}
					if (!this.DM.CheckHeroBattleResourceReady(HeroFightType.LegionBatte, array5))
					{
						this.GUIM.HideUILock(EUILock.Expedition);
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(8350u), 255, true);
						return;
					}
					for (int num6 = 0; num6 < 16; num6++)
					{
						int num7 = (3 - num6 % 4) * 4 + num6 / 4;
						this.DM.pLeftTroopForce[num6 / 4, num6 % 4] = (uint)this.m_Soldier[num7];
					}
					this.DM.War_LeftCastleLv = GUIManager.Instance.BuildingData.GetBuildData(12, 0).Level;
				}
				messagePacket2.AddSeqId();
				for (int num8 = 0; num8 < 5; num8++)
				{
					messagePacket2.Add((ushort)this.Hero_ID[num8]);
				}
				for (int num9 = 0; num9 < 16; num9++)
				{
					int num = (3 - num9 % 4) * 4 + num9 / 4;
					messagePacket2.Add((uint)this.m_Soldier[num]);
				}
				if (this.mOpenKind == 0)
				{
					Vector2 in_mapPos = GameConstants.getTileMapPosbySpriteID(this.MapID);
					in_mapPos = GameConstants.MapPosToPointCode(in_mapPos);
					messagePacket2.Add((ushort)in_mapPos.x);
					messagePacket2.Add((byte)in_mapPos.y);
				}
			}
			else if (this.mOpenKind == 2)
			{
				if (this.MapID >= 2 || this.MapID <= 4)
				{
					this.DM.bWonderFight = true;
				}
				else
				{
					this.DM.bWonderFight = false;
				}
				messagePacket2.Protocol = Protocol._MSG_REQUEST_SEND_INFORCE;
				messagePacket2.AddSeqId();
				messagePacket2.Add(this.ZoneID);
				messagePacket2.Add(this.PointID);
				for (int num10 = 0; num10 < 16; num10++)
				{
					int num = (3 - num10 % 4) * 4 + num10 / 4;
					messagePacket2.Add((uint)this.m_Soldier[num]);
				}
			}
			messagePacket2.Send(false);
		}
		else if (this.mOpenKind == 4)
		{
			uint[] array6 = new uint[16];
			for (int num11 = 0; num11 < 16; num11++)
			{
				int num = (3 - num11 % 4) * 4 + num11 / 4;
				array6[num11] = (uint)this.m_Soldier[num];
			}
			byte hideLord = 0;
			if (this.bCaveMainHero)
			{
				hideLord = 1;
			}
			HideArmyManager.Instance.SendHideTroopInshelter(hideLord, this.DM.RallyCountDownIndex, ref array6);
		}
		else if (this.mOpenKind == 5)
		{
			ushort[] array7 = new ushort[5];
			uint[] array8 = new uint[16];
			for (int num12 = 0; num12 < 5; num12++)
			{
				array7[num12] = (ushort)this.Hero_ID[num12];
			}
			for (int num13 = 0; num13 < 16; num13++)
			{
				int num = (3 - num13 % 4) * 4 + num13 / 4;
				array8[num13] = (uint)this.m_Soldier[num];
			}
			AmbushManager.Instance.SendAmbush(array7, array8);
		}
		else if (this.mOpenKind == 7 || this.mOpenKind == 8)
		{
			ushort[] array9 = new ushort[5];
			uint[] array10 = new uint[16];
			for (int num14 = 0; num14 < 5; num14++)
			{
				array9[num14] = (ushort)this.Hero_ID[num14];
			}
			for (int num15 = 0; num15 < 16; num15++)
			{
				int num = (3 - num15 % 4) * 4 + num15 / 4;
				array10[num15] = (uint)this.m_Soldier[num];
			}
			this.DM.SendWonderHost(array9, array10, this.mWonderId);
		}
		else if (this.mOpenKind == 10)
		{
			this.GUIM.ShowUILock(EUILock.Expedition);
			this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_Expedition);
			MessagePacket messagePacket3 = new MessagePacket(1024);
			messagePacket3.Protocol = Protocol._MSG_REQUEST_SIGNUP_ALLIANCEWAR;
			messagePacket3.AddSeqId();
			for (int num16 = 0; num16 < this.Hero_ID.Length; num16++)
			{
				messagePacket3.Add((ushort)this.Hero_ID[num16]);
			}
			for (int num17 = 0; num17 < 16; num17++)
			{
				int num = (3 - num17 % 4) * 4 + num17 / 4;
				messagePacket3.Add((uint)this.m_Soldier[num]);
			}
			messagePacket3.Send(false);
		}
		else if (this.mOpenKind >= 11 && this.mOpenKind <= 12)
		{
			MessagePacket messagePacket4 = new MessagePacket(1024);
			messagePacket4.Protocol = Protocol._MSG_REQUEST_TROOPMARCH_NOTATK;
			messagePacket4.AddSeqId();
			for (int num18 = 0; num18 < 5; num18++)
			{
				messagePacket4.Add((ushort)this.Hero_ID[num18]);
			}
			for (int num19 = 0; num19 < 16; num19++)
			{
				int num = (3 - num19 % 4) * 4 + num19 / 4;
				messagePacket4.Add((uint)this.m_Soldier[num]);
			}
			Vector2 in_mapPos2 = GameConstants.getTileMapPosbySpriteID(this.MapID);
			in_mapPos2 = GameConstants.MapPosToPointCode(in_mapPos2);
			messagePacket4.Add((ushort)in_mapPos2.x);
			messagePacket4.Add((byte)in_mapPos2.y);
			messagePacket4.Send(false);
		}
		if (this.mOpenKind != 1)
		{
			this.DM.LegionBattleHero.Clear();
		}
	}

	// Token: 0x06001B00 RID: 6912 RVA: 0x002E59E8 File Offset: 0x002E3BE8
	public void OnButtonDown(UIButtonHint sender)
	{
		if (sender.Parm1 == 1)
		{
			this.Cstr_HintNum.ClearString();
			this.Cstr_HintNum.IntToFormat(this.m_NeedWarlobbySoldier[(int)sender.Parm2], 1, true);
			this.Cstr_HintNum.IntToFormat(this.m_NeedWarlobbySoldier[(int)sender.Parm2] - (long)((ulong)this.m_SoldierMax[(int)sender.Parm2].Value[0]), 1, true);
			this.Cstr_HintNum.AppendFormat(this.DM.mStringTable.GetStringByID(14724u));
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.Cstr_HintNum, Vector2.zero);
		}
		else
		{
			UIButton uibutton = sender.m_Button as UIButton;
			switch (uibutton.m_BtnID1)
			{
			case 14:
				if (!this.Img_HintBG[0].IsActive())
				{
					this.Img_HintBG[0].gameObject.SetActive(true);
				}
				break;
			case 15:
				if (!this.Img_HintBG[1].IsActive())
				{
					this.Img_HintBG[1].gameObject.SetActive(true);
				}
				break;
			case 16:
				if (!this.Img_HintBG[2].IsActive())
				{
					this.Img_HintBG[2].gameObject.SetActive(true);
				}
				break;
			}
		}
	}

	// Token: 0x06001B01 RID: 6913 RVA: 0x002E5B50 File Offset: 0x002E3D50
	public void OnButtonUp(UIButtonHint sender)
	{
		if (sender.Parm1 == 1)
		{
			GUIManager.Instance.m_Hint.Hide(true);
		}
		else
		{
			UIButton uibutton = sender.m_Button as UIButton;
			switch (uibutton.m_BtnID1)
			{
			case 14:
				if (this.Img_HintBG[0].IsActive())
				{
					this.Img_HintBG[0].gameObject.SetActive(false);
				}
				break;
			case 15:
				if (this.Img_HintBG[1].IsActive())
				{
					this.Img_HintBG[1].gameObject.SetActive(false);
				}
				break;
			case 16:
				if (this.Img_HintBG[2].IsActive())
				{
					this.Img_HintBG[2].gameObject.SetActive(false);
				}
				break;
			}
		}
	}

	// Token: 0x06001B02 RID: 6914 RVA: 0x002E5C2C File Offset: 0x002E3E2C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelId == 1)
		{
			if (this.ShowListIndex[dataIdx] > 0)
			{
				this.tmpListIdx = (int)(this.ShowListIndex[dataIdx] - 1);
			}
			if (this.m_UnitRS_Item[panelObjectIdx] == null)
			{
				this.m_UnitRS_Item[panelObjectIdx] = item.transform.GetChild(1).GetComponent<UnitResourcesSlider>();
				this.m_UnitRS_Item[panelObjectIdx].m_Handler = this;
				this.m_UnitRS_Item[panelObjectIdx].m_ID = this.tmpListIdx;
				this.m_UnitRS_Item[panelObjectIdx].MaxValue = (long)((ulong)this.m_SoldierMax[this.tmpListIdx].Value[0]);
				this.m_UnitRS_Item[panelObjectIdx].Value = this.m_Soldier[this.tmpListIdx];
				this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = this.m_SoldierMax[this.tmpListIdx].Value[0];
				this.m_UnitRS_Item[panelObjectIdx].m_slider.value = (double)this.m_Soldier[this.tmpListIdx];
				this.btn_ItemInput[panelObjectIdx] = this.m_UnitRS_Item[panelObjectIdx].BtnInputText;
				this.btn_ItemInput[panelObjectIdx].m_Handler = this;
				this.btn_ItemInput[panelObjectIdx].m_BtnID2 = panelObjectIdx;
				if (this.m_SoldierMax[this.tmpListIdx].Value[0] >= this.Hero_Total)
				{
					this.m_UnitRS_Item[panelObjectIdx].MaxValue = (long)((ulong)this.Hero_Total);
					this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = this.Hero_Total;
				}
				this.m_UnitRS_Item[panelObjectIdx].Type = (byte)panelObjectIdx;
				this.Tmp = item.transform.GetChild(2).GetChild(0);
				this.Img_Soldier_Item[panelObjectIdx] = this.Tmp.GetComponent<Image>();
				this.Tmp = item.transform.GetChild(2).GetChild(1);
				this.Img_Soldier_ItemFrame[panelObjectIdx] = this.Tmp.GetComponent<Image>();
				this.Img_Soldier_ItemFrame[panelObjectIdx].material = this.FrameMaterial;
				this.Tmp = item.transform.GetChild(3).GetChild(0);
				this.Img_Soldier_Kind[panelObjectIdx] = this.Tmp.GetComponent<Image>();
				this.Img_Soldier_Kind[panelObjectIdx].material = this.m_BW;
				this.Tmp = item.transform.GetChild(4);
				this.Text_Soldier_ItemNum[panelObjectIdx] = this.Tmp.GetComponent<UIText>();
				this.Text_Soldier_ItemNum[panelObjectIdx].font = this.TTFont;
				this.Tmp = item.transform.GetChild(3).GetChild(1);
				this.Text_Soldier_ItemName[panelObjectIdx] = this.Tmp.GetComponent<UIText>();
				this.Text_Soldier_ItemName[panelObjectIdx].font = this.TTFont;
			}
			else
			{
				this.m_UnitRS_Item[panelObjectIdx].m_ID = this.tmpListIdx;
				this.m_UnitRS_Item[panelObjectIdx].MaxValue = (long)((ulong)this.m_SoldierMax[this.tmpListIdx].Value[0]);
				this.m_UnitRS_Item[panelObjectIdx].Value = this.m_Soldier[this.tmpListIdx];
				if (this.m_SoldierMax[this.tmpListIdx].Value[0] < this.m_UnitRS_Item[panelObjectIdx].m_slider.value)
				{
					this.m_UnitRS_Item[panelObjectIdx].m_slider.value = (double)this.m_Soldier[this.tmpListIdx];
					this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = this.m_SoldierMax[this.tmpListIdx].Value[0];
				}
				else
				{
					this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = this.m_SoldierMax[this.tmpListIdx].Value[0];
					this.m_UnitRS_Item[panelObjectIdx].m_slider.value = (double)this.m_Soldier[this.tmpListIdx];
				}
				if (this.m_SoldierMax[this.tmpListIdx].Value[0] >= this.Hero_Total)
				{
					this.m_UnitRS_Item[panelObjectIdx].MaxValue = (long)((ulong)this.Hero_Total);
					this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = this.Hero_Total;
				}
				this.m_UnitRS_Item[panelObjectIdx].Type = (byte)panelObjectIdx;
			}
			this.Img_Soldier_Item[panelObjectIdx].sprite = this.m_SoldierSprite[this.tmpListIdx];
			this.Img_Soldier_ItemFrame[panelObjectIdx].sprite = this.m_SoldierSpriteFrame[this.tmpListIdx];
			this.Img_Soldier_Kind[panelObjectIdx].sprite = this.SArray.m_Sprites[6 + this.tmpListIdx % 4];
			if (this.m_Soldier[this.tmpListIdx] != 0L)
			{
				this.m_UnitRS_Item[panelObjectIdx].m_inputText.color = this.mtextColor;
			}
			else
			{
				this.m_UnitRS_Item[panelObjectIdx].m_inputText.color = Color.white;
			}
			this.Cstr_Soldier_ItemNum[panelObjectIdx].ClearString();
			this.Cstr_Soldier_ItemNum[panelObjectIdx].IntToFormat((long)((ulong)this.m_SoldierMax[this.tmpListIdx].Value[0] - (ulong)this.m_Soldier[this.tmpListIdx]), 1, true);
			this.Cstr_Soldier_ItemNum[panelObjectIdx].AppendFormat("{0}");
			this.Text_Soldier_ItemNum[panelObjectIdx].text = this.Cstr_Soldier_ItemNum[panelObjectIdx].ToString();
			this.Text_Soldier_ItemNum[panelObjectIdx].SetAllDirty();
			this.Text_Soldier_ItemNum[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.Text_Soldier_ItemName[panelObjectIdx].text = this.m_SoldierName[this.tmpListIdx];
			this.Cstr_Soldier_Text[panelObjectIdx].ClearString();
			this.Cstr_Soldier_Text[panelObjectIdx].IntToFormat(this.m_Soldier[this.tmpListIdx], 1, true);
			this.Cstr_Soldier_Text[panelObjectIdx].AppendFormat("{0}");
			this.m_UnitRS_Item[panelObjectIdx].m_inputText.text = this.Cstr_Soldier_Text[panelObjectIdx].ToString();
			this.m_UnitRS_Item[panelObjectIdx].m_inputText.SetAllDirty();
			this.m_UnitRS_Item[panelObjectIdx].m_inputText.cachedTextGenerator.Invalidate();
		}
		else if (panelId == 2)
		{
			if (!this.InitSoldierInfoItem[panelObjectIdx])
			{
				this.InitSoldierInfoItem[panelObjectIdx] = true;
				this.m_Warlobby_Item[panelObjectIdx].T1 = item.transform.GetChild(0);
				for (int i = 0; i < 5; i++)
				{
					this.m_Warlobby_Item[panelObjectIdx].text_T1[i] = this.m_Warlobby_Item[panelObjectIdx].T1.GetChild(1 + i).GetComponent<UIText>();
				}
				this.m_Warlobby_Item[panelObjectIdx].T2 = item.transform.GetChild(1);
				this.m_Warlobby_Item[panelObjectIdx].text_T2 = this.m_Warlobby_Item[panelObjectIdx].T2.GetChild(1).GetComponent<UIText>();
				this.m_Warlobby_Item[panelObjectIdx].SolderT = item.transform.GetChild(2);
				this.m_Warlobby_Item[panelObjectIdx].SolderIcon = this.m_Warlobby_Item[panelObjectIdx].SolderT.GetChild(0).GetComponent<Image>();
				for (int j = 0; j < 3; j++)
				{
					this.m_Warlobby_Item[panelObjectIdx].text_SolderT[j] = this.m_Warlobby_Item[panelObjectIdx].SolderT.GetChild(0).GetChild(j).GetComponent<UIText>();
				}
				this.m_Warlobby_Item[panelObjectIdx].SolderIconEX = this.m_Warlobby_Item[panelObjectIdx].SolderT.GetChild(1).GetComponent<Image>();
				this.m_Warlobby_Item[panelObjectIdx].mWarlobbybtnHint = this.m_Warlobby_Item[panelObjectIdx].SolderIconEX.gameObject.AddComponent<UIButtonHint>();
				this.m_Warlobby_Item[panelObjectIdx].mWarlobbybtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.m_Warlobby_Item[panelObjectIdx].mWarlobbybtnHint.m_Handler = this;
				this.m_Warlobby_Item[panelObjectIdx].mWarlobbybtnHint.Parm1 = 1;
				this.m_Warlobby_Item[panelObjectIdx].text_SolderT[3] = this.m_Warlobby_Item[panelObjectIdx].SolderT.GetChild(2).GetComponent<UIText>();
			}
			if (dataIdx == 0)
			{
				this.m_Warlobby_Item[panelObjectIdx].T1.gameObject.SetActive(true);
				this.m_Warlobby_Item[panelObjectIdx].T2.gameObject.SetActive(false);
				this.m_Warlobby_Item[panelObjectIdx].SolderT.gameObject.SetActive(false);
				if (this.mWarlobbyKind == 2)
				{
					this.m_Warlobby_Item[panelObjectIdx].text_T1[2].gameObject.SetActive(false);
					this.m_Warlobby_Item[panelObjectIdx].text_T1[4].gameObject.SetActive(false);
				}
				else
				{
					this.m_Warlobby_Item[panelObjectIdx].text_T1[2].gameObject.SetActive(true);
					this.m_Warlobby_Item[panelObjectIdx].text_T1[4].gameObject.SetActive(true);
				}
				if (this.bScrollItemH)
				{
					this.m_Warlobby_Item[panelObjectIdx].text_T1[1].rectTransform.sizeDelta = new Vector2(this.m_Warlobby_Item[panelObjectIdx].text_T1[1].rectTransform.sizeDelta.x, 56f);
					this.m_Warlobby_Item[panelObjectIdx].text_T1[3].rectTransform.anchoredPosition = new Vector2(-58f, -58f);
					this.m_Warlobby_Item[panelObjectIdx].text_T1[2].rectTransform.anchoredPosition = new Vector2(this.m_Warlobby_Item[panelObjectIdx].text_T1[2].rectTransform.anchoredPosition.x, -112f);
				}
				else
				{
					this.m_Warlobby_Item[panelObjectIdx].text_T1[1].rectTransform.sizeDelta = new Vector2(this.m_Warlobby_Item[panelObjectIdx].text_T1[1].rectTransform.sizeDelta.x, 28f);
					this.m_Warlobby_Item[panelObjectIdx].text_T1[3].rectTransform.anchoredPosition = new Vector2(-58f, -44f);
					this.m_Warlobby_Item[panelObjectIdx].text_T1[2].rectTransform.anchoredPosition = new Vector2(this.m_Warlobby_Item[panelObjectIdx].text_T1[2].rectTransform.anchoredPosition.x, -84f);
				}
				if ((this.bScrollItemH1 && this.mWarlobbyKind == 0) || (this.bScrollItemH2 && this.mWarlobbyKind == 1))
				{
					this.m_Warlobby_Item[panelObjectIdx].text_T1[2].rectTransform.sizeDelta = new Vector2(this.m_Warlobby_Item[panelObjectIdx].text_T1[2].rectTransform.sizeDelta.x, 56f);
					if (this.bScrollItemH)
					{
						this.m_Warlobby_Item[panelObjectIdx].text_T1[4].rectTransform.anchoredPosition = new Vector2(-58f, -126f);
					}
					else
					{
						this.m_Warlobby_Item[panelObjectIdx].text_T1[4].rectTransform.anchoredPosition = new Vector2(-58f, -98f);
					}
				}
				else
				{
					this.m_Warlobby_Item[panelObjectIdx].text_T1[2].rectTransform.sizeDelta = new Vector2(this.m_Warlobby_Item[panelObjectIdx].text_T1[2].rectTransform.sizeDelta.x, 28f);
					if (this.bScrollItemH)
					{
						this.m_Warlobby_Item[panelObjectIdx].text_T1[4].rectTransform.anchoredPosition = new Vector2(-58f, -112f);
					}
					else
					{
						this.m_Warlobby_Item[panelObjectIdx].text_T1[4].rectTransform.anchoredPosition = new Vector2(-58f, -84f);
					}
				}
				this.Cstr_WarlobbySolder.ClearString();
				this.Cstr_WarlobbySolder.IntToFormat(this.WarlobbySelectQty, 1, true);
				this.Cstr_WarlobbySolder.IntToFormat(this.WarlobbyTroopMax, 1, true);
				if (this.WarlobbySelectQty < this.WarlobbyTroopMax)
				{
					if (this.GUIM.IsArabic)
					{
						this.Cstr_WarlobbySolder.AppendFormat("{1} / <color=#ff0000ff>{0}</color>");
					}
					else
					{
						this.Cstr_WarlobbySolder.AppendFormat("<color=#ff0000ff>{0}</color> / {1}");
					}
				}
				else if (this.GUIM.IsArabic)
				{
					this.Cstr_WarlobbySolder.AppendFormat("{1} / {0}");
				}
				else
				{
					this.Cstr_WarlobbySolder.AppendFormat("{0} / {1}");
				}
				this.m_Warlobby_Item[panelObjectIdx].text_T1[3].text = this.Cstr_WarlobbySolder.ToString();
				this.m_Warlobby_Item[panelObjectIdx].text_T1[3].SetAllDirty();
				this.m_Warlobby_Item[panelObjectIdx].text_T1[3].cachedTextGenerator.Invalidate();
				this.m_Warlobby_Item[panelObjectIdx].text_T1[4].text = this.Cstr_LoadNum[0].ToString();
				this.m_Warlobby_Item[panelObjectIdx].text_T1[4].SetAllDirty();
				this.m_Warlobby_Item[panelObjectIdx].text_T1[4].cachedTextGenerator.Invalidate();
				this.m_Warlobby_Item[panelObjectIdx].text_T1[2].text = this.Cstr_WarlobbyKindText.ToString();
				this.m_Warlobby_Item[panelObjectIdx].text_T1[2].SetAllDirty();
				this.m_Warlobby_Item[panelObjectIdx].text_T1[2].cachedTextGenerator.Invalidate();
				this.m_Warlobby_Item[panelObjectIdx].text_T1[2].cachedTextGeneratorForLayout.Invalidate();
			}
			else if (dataIdx == 1)
			{
				this.m_Warlobby_Item[panelObjectIdx].T1.gameObject.SetActive(false);
				this.m_Warlobby_Item[panelObjectIdx].T2.gameObject.SetActive(true);
				this.m_Warlobby_Item[panelObjectIdx].SolderT.gameObject.SetActive(false);
			}
			else
			{
				this.m_Warlobby_Item[panelObjectIdx].T1.gameObject.SetActive(false);
				this.m_Warlobby_Item[panelObjectIdx].T2.gameObject.SetActive(false);
				this.m_Warlobby_Item[panelObjectIdx].SolderT.gameObject.SetActive(true);
				if (dataIdx > 1)
				{
					this.mSrcollDataIdx = this.mShowSolderIdx[dataIdx - 2];
					this.m_Warlobby_Item[panelObjectIdx].SolderIcon.sprite = this.mWarlobbyIcon[(int)(this.mSrcollDataIdx % 4)];
					this.m_Warlobby_Item[panelObjectIdx].text_SolderT[0].text = ((int)(4 - this.mSrcollDataIdx / 4)).ToString();
					this.m_Warlobby_Item[panelObjectIdx].text_SolderT[1].text = this.m_SoldierName[(int)this.mSrcollDataIdx];
					this.Cstr_WarSoldier_Text[panelObjectIdx].ClearString();
					StringManager.IntToStr(this.Cstr_WarSoldier_Text[panelObjectIdx], this.m_WarlobbySoldier[(int)this.mSrcollDataIdx], 1, true);
					this.m_Warlobby_Item[panelObjectIdx].text_SolderT[2].text = this.Cstr_WarSoldier_Text[panelObjectIdx].ToString();
					this.m_Warlobby_Item[panelObjectIdx].text_SolderT[2].SetAllDirty();
					this.m_Warlobby_Item[panelObjectIdx].text_SolderT[2].cachedTextGenerator.Invalidate();
					this.Cstr_WarSoldierRate_Text[panelObjectIdx].ClearString();
					if (this.WarlobbySelectQty > 0L)
					{
						this.Cstr_WarSoldierRate_Text[panelObjectIdx].DoubleToFormat((double)this.m_WarlobbySoldier[(int)this.mSrcollDataIdx] * 100.0 / (double)this.WarlobbySelectQty, 1, true);
					}
					else
					{
						this.Cstr_WarSoldierRate_Text[panelObjectIdx].DoubleToFormat(0.0, 1, true);
					}
					if (this.GUIM.IsArabic)
					{
						this.Cstr_WarSoldierRate_Text[panelObjectIdx].AppendFormat("%{0}");
					}
					else
					{
						this.Cstr_WarSoldierRate_Text[panelObjectIdx].AppendFormat("{0}%");
					}
					this.m_Warlobby_Item[panelObjectIdx].text_SolderT[3].text = this.Cstr_WarSoldierRate_Text[panelObjectIdx].ToString();
					this.m_Warlobby_Item[panelObjectIdx].text_SolderT[3].SetAllDirty();
					this.m_Warlobby_Item[panelObjectIdx].text_SolderT[3].cachedTextGenerator.Invalidate();
					this.m_Warlobby_Item[panelObjectIdx].mWarlobbybtnHint.Parm2 = this.mSrcollDataIdx;
					if ((ulong)this.m_SoldierMax[(int)this.mSrcollDataIdx].Value[0] < (ulong)this.m_NeedWarlobbySoldier[(int)this.mSrcollDataIdx])
					{
						this.m_Warlobby_Item[panelObjectIdx].SolderIconEX.gameObject.SetActive(true);
					}
					else
					{
						this.m_Warlobby_Item[panelObjectIdx].SolderIconEX.gameObject.SetActive(false);
					}
				}
			}
		}
	}

	// Token: 0x06001B03 RID: 6915 RVA: 0x002E6DA0 File Offset: 0x002E4FA0
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001B04 RID: 6916 RVA: 0x002E6DA4 File Offset: 0x002E4FA4
	public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
	{
		URS.m_slider.value = (double)mValue;
		URS.SliderValueChange();
	}

	// Token: 0x06001B05 RID: 6917 RVA: 0x002E6DBC File Offset: 0x002E4FBC
	public override bool OnBackButtonClick()
	{
		if (this.mOpenKind == 1 && (this.GUIM.GetUILock() == EUILock.Expedition || this.fightButtonTime > 0f))
		{
			return true;
		}
		if (this.mOpenKind == 4)
		{
			HideArmyManager.Instance.OpenHideArmyUI();
		}
		if (this.mOpenKind == 6)
		{
			if (this.DM.bChangHero)
			{
				if (this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[0] != 0)
				{
					byte b = 0;
					for (int i = 0; i < 5; i++)
					{
						if (this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[i] != 0)
						{
							b += 1;
						}
					}
					if (this.DM.LegionBattleHero.Count != (int)b)
					{
						GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5893u), this.DM.mStringTable.GetStringByID(997u), 3, 0, this.DM.mStringTable.GetStringByID(3u), this.DM.mStringTable.GetStringByID(4u));
						return true;
					}
					int num = 0;
					while (num < 5 && num < this.DM.LegionBattleHero.Count)
					{
						if (this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[num] != this.DM.LegionBattleHero[num])
						{
							GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5893u), this.DM.mStringTable.GetStringByID(997u), 3, 0, this.DM.mStringTable.GetStringByID(3u), this.DM.mStringTable.GetStringByID(4u));
							return true;
						}
						num++;
					}
				}
				else if (this.DM.LegionBattleHero.Count > 0)
				{
					GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5893u), this.DM.mStringTable.GetStringByID(997u), 3, 0, this.DM.mStringTable.GetStringByID(3u), this.DM.mStringTable.GetStringByID(4u));
					return true;
				}
			}
			if (this.DM.bChangSoldier)
			{
				for (int j = 0; j < 16; j++)
				{
					if ((ulong)this.DM.mTroopMemoryData[(int)this.TMD_Idx].TroopData[j] != (ulong)this.m_Soldier[j])
					{
						GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5893u), this.DM.mStringTable.GetStringByID(997u), 3, 0, this.DM.mStringTable.GetStringByID(3u), this.DM.mStringTable.GetStringByID(4u));
						return true;
					}
				}
			}
			if (this.DM.bChangName && string.Compare(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Label, 0, this.TMD_Name, 0, this.DM.mTroopMemoryData[(int)this.TMD_Idx].Label.Length) != 0)
			{
				GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5893u), this.DM.mStringTable.GetStringByID(997u), 3, 0, this.DM.mStringTable.GetStringByID(3u), this.DM.mStringTable.GetStringByID(4u));
				return true;
			}
			this.DM.TeamName.ClearString();
			this.DM.LegionBattleHero.Clear();
			for (int k = 0; k < 16; k++)
			{
				this.DM.mExpeditionSoldierList[k] = 0u;
			}
			this.DM.bChangHero = false;
			this.DM.bChangName = false;
			this.DM.bChangSoldier = false;
		}
		else
		{
			this.DM.LegionBattleHero.Clear();
			for (int l = 0; l < 16; l++)
			{
				this.DM.mExpeditionSoldierList[l] = 0u;
			}
		}
		if (this.mWarlobbyKind >= 0 && this.mWarlobbyKind <= 2)
		{
			this.mUI_WarlobbyK = byte.MaxValue;
		}
		return false;
	}

	// Token: 0x06001B06 RID: 6918 RVA: 0x002E7250 File Offset: 0x002E5450
	public void UpDataSoldier()
	{
		this.SoldierMax = 0L;
		int num = 0;
		this.tmplist.Clear();
		for (int i = 0; i < 16; i++)
		{
			if (!this.bLogin)
			{
				this.m_Soldier[i] = 0L;
			}
			this.m_SoldierMax[i].Value = new uint[5];
			ushort num2 = (ushort)(4 - i / 4 + i % 4 * 4);
			if (this.DM.bSetExpediton)
			{
				if (this.DM.RoleAttr.m_Soldier[(int)(num2 - 1)] >= this.DM.mExpeditionSoldierList[i] || this.mOpenKind == 6)
				{
					this.m_Soldier[i] = (long)((ulong)this.DM.mExpeditionSoldierList[i]);
				}
				else
				{
					this.m_Soldier[i] = (long)((ulong)this.DM.RoleAttr.m_Soldier[(int)(num2 - 1)]);
				}
			}
			this.m_SoldierMax[i].Value[0] = this.DM.RoleAttr.m_Soldier[(int)(num2 - 1)];
			if (this.mOpenKind == 6)
			{
				for (int j = 0; j < this.DM.MarchEventData.Length; j++)
				{
					if (this.DM.MarchEventData[j].Type != EMarchEventType.EMET_Standby)
					{
						this.m_SoldierMax[i].Value[0] += this.DM.MarchEventData[j].TroopData[(int)((num2 - 1) / 4)][(int)((num2 - 1) % 4)];
					}
				}
				if (this.m_Soldier[i] > (long)((ulong)this.m_SoldierMax[i].Value[0]))
				{
					this.m_Soldier[i] = (long)((ulong)this.m_SoldierMax[i].Value[0]);
				}
			}
			this.m_SoldierMax[i].Value[1] = 0u;
			this.m_SoldierMax[i].Value[2] = 0u;
			this.m_SoldierMax[i].Value[3] = 0u;
			this.m_SoldierMax[i].Value[4] = 0u;
			this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey(num2);
			this.tmpString.Length = 0;
			this.m_SoldierSprite[i] = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpSD.Icon);
			this.tmpString.Length = 0;
			this.tmpString.AppendFormat("hf00{0}", this.tmpSD.Tier);
			this.m_SoldierSpriteFrame[i] = this.GUIM.LoadFrameSprite(this.tmpString.ToString());
			this.m_SoldierName[i] = this.DM.mStringTable.GetStringByID((uint)this.tmpSD.Name);
			this.m_SoldierData[i].Speed = this.tmpSD.Speed;
			this.m_SoldierData[i].Traffic = this.tmpSD.Traffic;
			this.SpeedsortData[i] = (byte)i;
			this.LoadsortData[i] = (byte)i;
			this.SoldierMax += (long)((ulong)this.m_SoldierMax[i].Value[0]);
			if (this.m_SoldierMax[i].Value[0] > 0u)
			{
				this.ShowListIndex[num] = (byte)(i + 1);
				this.tmplist.Add(98f);
				num++;
			}
		}
	}

	// Token: 0x06001B07 RID: 6919 RVA: 0x002E75C8 File Offset: 0x002E57C8
	public void ClearSoldier()
	{
		for (int i = 0; i < 16; i++)
		{
			this.m_Soldier[i] = 0L;
		}
		for (int j = 0; j < 7; j++)
		{
			if (this.m_UnitRS_Item[j] != null)
			{
				long num = this.m_Soldier[this.m_UnitRS_Item[j].m_ID];
				this.m_UnitRS_Item[j].MaxValue = (long)((ulong)this.m_SoldierMax[this.m_UnitRS_Item[j].m_ID].Value[0]);
				this.m_UnitRS_Item[j].Value = num;
				this.m_UnitRS_Item[j].m_slider.maxValue = this.m_SoldierMax[this.m_UnitRS_Item[j].m_ID].Value[0];
				if (this.m_SoldierMax[this.m_UnitRS_Item[j].m_ID].Value[0] >= this.Hero_Total)
				{
					this.m_UnitRS_Item[j].MaxValue = (long)((ulong)this.Hero_Total);
					this.m_UnitRS_Item[j].m_slider.maxValue = this.Hero_Total;
				}
				this.m_UnitRS_Item[j].m_slider.value = (double)num;
				this.Cstr_Soldier_Text[j].ClearString();
				this.Cstr_Soldier_Text[j].IntToFormat(num, 1, true);
				this.Cstr_Soldier_Text[j].AppendFormat("{0}");
				this.m_UnitRS_Item[j].m_inputText.text = this.Cstr_Soldier_Text[j].ToString();
				this.m_UnitRS_Item[j].m_inputText.SetAllDirty();
				this.m_UnitRS_Item[j].m_inputText.cachedTextGenerator.Invalidate();
				this.Text_Soldier_ItemNum[j].color = Color.white;
				this.Cstr_Soldier_ItemNum[j].ClearString();
				this.Cstr_Soldier_ItemNum[j].IntToFormat((long)((ulong)this.m_SoldierMax[this.m_UnitRS_Item[j].m_ID].Value[0] - (ulong)num), 1, true);
				this.Cstr_Soldier_ItemNum[j].AppendFormat("{0}");
				this.Text_Soldier_ItemNum[j].text = this.Cstr_Soldier_ItemNum[j].ToString();
				this.Text_Soldier_ItemNum[j].SetAllDirty();
				this.Text_Soldier_ItemNum[j].cachedTextGenerator.Invalidate();
			}
		}
		this.SetDRformURS(0);
	}

	// Token: 0x06001B08 RID: 6920 RVA: 0x002E7824 File Offset: 0x002E5A24
	public void CheckMaxSelect()
	{
		uint num = this.Hero_Total;
		uint num2;
		if (this.mResourcesKind == 1)
		{
			num2 = this.ResourcesMax * 1000u;
		}
		else
		{
			num2 = this.ResourcesMax;
		}
		float num3 = (float)Math.Ceiling(num2 * (double)(10000f / this.tmpLoad));
		for (int i = 0; i < 16; i++)
		{
			if (this.m_SoldierMax[i].Value[0] * (uint)this.m_SoldierData[i].Traffic < num3)
			{
				num -= this.m_SoldierMax[i].Value[0];
				this.m_SoldierMax[i].Value[1] = this.m_SoldierMax[i].Value[0];
				num3 -= this.m_SoldierMax[i].Value[0] * (uint)this.m_SoldierData[i].Traffic;
			}
			else
			{
				this.m_SoldierMax[i].Value[1] = GameConstants.appCeil(num3 / (float)this.m_SoldierData[i].Traffic);
				if (this.m_SoldierMax[i].Value[1] <= num)
				{
					num -= this.m_SoldierMax[i].Value[1];
				}
				else
				{
					this.m_SoldierMax[i].Value[1] = num;
					num = 0u;
				}
				num3 = 0f;
			}
			if (num3 == 0f || num == 0u)
			{
				break;
			}
		}
		num = this.Hero_Total;
		num3 = (float)Math.Ceiling(num2 * (double)(10000f / this.tmpLoad));
		for (int j = 0; j < 16; j++)
		{
			int num4 = (3 - j / 4) * 4 + j % 4;
			if (this.m_SoldierMax[num4].Value[0] * (uint)this.m_SoldierData[num4].Traffic < num3)
			{
				if (this.m_SoldierMax[num4].Value[0] <= num)
				{
					num -= this.m_SoldierMax[num4].Value[0];
					this.m_SoldierMax[num4].Value[2] = this.m_SoldierMax[num4].Value[0];
					num3 -= this.m_SoldierMax[num4].Value[0] * (uint)this.m_SoldierData[num4].Traffic;
				}
				else
				{
					this.m_SoldierMax[num4].Value[2] = num;
					num = 0u;
				}
			}
			else
			{
				this.m_SoldierMax[num4].Value[2] = GameConstants.appCeil(num3 / (float)this.m_SoldierData[num4].Traffic);
				if (this.m_SoldierMax[num4].Value[2] <= num)
				{
					num -= this.m_SoldierMax[num4].Value[2];
				}
				else
				{
					this.m_SoldierMax[num4].Value[2] = num;
					num = 0u;
				}
				num3 = 0f;
			}
			if (num3 == 0f || num == 0u)
			{
				break;
			}
		}
	}

	// Token: 0x06001B09 RID: 6921 RVA: 0x002E7B68 File Offset: 0x002E5D68
	public void SelectFormation()
	{
		uint num = this.Hero_Total;
		if ((ulong)num > (ulong)this.SoldierMax)
		{
			for (int i = 0; i < 16; i++)
			{
				this.m_SoldierMax[i].Value[3] = this.m_SoldierMax[i].Value[0];
				this.m_SoldierMax[i].Value[4] = this.m_SoldierMax[i].Value[0];
			}
		}
		else
		{
			for (int j = 0; j < 16; j++)
			{
				uint num2;
				if (num > this.m_SoldierMax[j].Value[0])
				{
					num -= this.m_SoldierMax[j].Value[0];
					num2 = this.m_SoldierMax[j].Value[0];
				}
				else
				{
					num2 = num;
					num = 0u;
				}
				this.m_SoldierMax[j].Value[3] = num2;
				if (num == 0u)
				{
					break;
				}
			}
			num = this.Hero_Total;
			for (int k = 0; k < 16; k++)
			{
				int num3 = (3 - k / 4) * 4 + k % 4;
				uint num2;
				if (num > this.m_SoldierMax[num3].Value[0])
				{
					num -= this.m_SoldierMax[num3].Value[0];
					num2 = this.m_SoldierMax[num3].Value[0];
				}
				else
				{
					num2 = num;
					num = 0u;
				}
				this.m_SoldierMax[num3].Value[4] = num2;
				if (num == 0u)
				{
					break;
				}
			}
		}
	}

	// Token: 0x06001B0A RID: 6922 RVA: 0x002E7D0C File Offset: 0x002E5F0C
	public void Set_W_SelectText(byte Kind = 255, bool bClear = false)
	{
		if (Kind != 255)
		{
			this.mUI_WarlobbyK = Kind;
			if (Kind > 0)
			{
				this.Text_W_Select[0].text = this.mbtnFormation[1];
				this.Img_W_SelectIcon.gameObject.SetActive(!bClear);
				this.Text_W_Select[1].gameObject.SetActive(!bClear);
				this.Text_W_Select[0].gameObject.SetActive(bClear);
				if (!bClear)
				{
					if (Kind == 1)
					{
						this.Text_W_Select[1].text = this.DM.mStringTable.GetStringByID(14713u);
					}
					else if (Kind == 2)
					{
						this.Text_W_Select[1].text = this.DM.mStringTable.GetStringByID(14714u);
					}
				}
			}
			else
			{
				this.Img_W_SelectIcon.gameObject.SetActive(false);
				this.Text_W_Select[1].gameObject.SetActive(false);
				this.Text_W_Select[0].gameObject.SetActive(true);
				if (!bClear)
				{
					this.Text_W_Select[0].text = this.mbtnFormation[0];
				}
				else
				{
					this.Text_W_Select[0].text = this.mbtnFormation[1];
				}
			}
		}
		this.Text_W_Select[0].SetAllDirty();
		this.Text_W_Select[0].cachedTextGenerator.Invalidate();
		this.Text_W_Select[1].SetAllDirty();
		this.Text_W_Select[1].cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001B0B RID: 6923 RVA: 0x002E7E90 File Offset: 0x002E6090
	public void SetWarlobbyMenu(bool bopen, byte type = 0)
	{
		if (!bopen)
		{
			if (this.Img_W_MenuSelect.gameObject.activeSelf)
			{
				this.Img_W_MenuSelect.gameObject.SetActive(bopen);
			}
			else if (this.Img_W_Menu.gameObject.activeSelf)
			{
				this.Img_W_Menu.gameObject.SetActive(bopen);
			}
		}
		else
		{
			this.Img_W_MenuSelect.gameObject.SetActive(bopen && type == 0);
			this.Img_W_Menu.gameObject.SetActive(bopen && type == 1);
		}
		this.btn_W_MenuBack.enabled = this.Img_W_MenuSelect.gameObject.activeSelf;
		if (this.bAllZero)
		{
			this.btn_W_MenuSet.ForTextChange(e_BtnType.e_ChangeText);
			this.btn_W_MenuSet.image.color = Color.gray;
		}
		else
		{
			this.btn_W_MenuSet.ForTextChange(e_BtnType.e_Normal);
			this.btn_W_MenuSet.image.color = Color.white;
		}
		this.btn_W_MenuBack.gameObject.SetActive(bopen);
	}

	// Token: 0x06001B0C RID: 6924 RVA: 0x002E7FB4 File Offset: 0x002E61B4
	public void CheckScrollH()
	{
		this.Cstr_WarlobbyKindText.ClearString();
		if (this.mWarlobbyKind == 0)
		{
			this.Cstr_WarlobbyKindText.Append(this.DM.mStringTable.GetStringByID(14720u));
		}
		else if (this.mWarlobbyKind == 1)
		{
			this.Cstr_WarlobbyKindText.Append(this.DM.mStringTable.GetStringByID(14721u));
		}
		float num = 0f;
		num += (float)((!this.bScrollItemH) ? 0 : 28);
		num += (float)((!this.bScrollItemH1 || this.mWarlobbyKind != 0) ? 0 : 28);
		num += (float)((!this.bScrollItemH2 || this.mWarlobbyKind != 1) ? 0 : 28);
		if (this.mWarlobbyKind == 2)
		{
			num -= 37f;
		}
		this.tmplist_Warlooby.Clear();
		this.tmplist_Warlooby.Add(118f + num);
		this.tmplist_Warlooby.Add(38f);
		for (int i = 0; i < (int)this.mWarlobbySolderList; i++)
		{
			this.tmplist_Warlooby.Add(39f);
		}
		this.m_ScrollPanel_Warlobby.AddNewDataHeight(this.tmplist_Warlooby, true, true);
	}

	// Token: 0x06001B0D RID: 6925 RVA: 0x002E8108 File Offset: 0x002E6308
	public void CheckWarlobbyTroopSelect(byte mKind = 1, bool ReSetText = true)
	{
		if (mKind < 1 || mKind > 2)
		{
			return;
		}
		long num = (long)((ulong)this.Hero_Total + (ulong)((long)this.mExpeditionlimit));
		long num2 = (long)((ulong)this.Hero_Total + (ulong)((long)this.mExpeditionlimit));
		this.WarlobbyTroopMax = (long)((ulong)this.Hero_Total + (ulong)((long)this.mExpeditionlimit));
		bool flag = true;
		long num3 = 0L;
		double num4 = 0.0;
		Array.Clear(this.mShowSolderIdx, 0, this.mShowSolderIdx.Length);
		Array.Clear(this.m_WarlobbySoldier, 0, this.m_WarlobbySoldier.Length);
		Array.Clear(this.mWarlobbySolderValue, 0, this.mWarlobbySolderValue.Length);
		Array.Clear(this.m_NeedWarlobbySoldier, 0, this.m_NeedWarlobbySoldier.Length);
		this.mWarlobbySolderList = 0;
		this.bAllZero = false;
		byte[] array = new byte[16];
		byte[] array2 = new byte[16];
		byte b = 0;
		if (mKind == 1)
		{
			this.Text_W_SelectTilte.text = this.DM.mStringTable.GetStringByID(14717u);
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (this.m_SoldierMax[j * 4 + i].Value[0] > 0u)
					{
						array[i] = (byte)(j * 4 + i + 1);
						break;
					}
				}
				int num5 = (int)(array[i] - 1);
				if (num5 < 0)
				{
					for (int k = 0; k < 4; k++)
					{
						this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort)(i * 4 + (4 - k)));
						if ((this.tmpSD.Science != 0 && this.DM.GetTechLevel(this.tmpSD.Science) != 0) || this.tmpSD.Tier == 1)
						{
							num5 = k * 4 + i;
							break;
						}
					}
				}
				if (num5 >= 0 && this.WarlobbyTroopTotalTroopNum > 0u)
				{
					this.mWarlobbySolderValue[num5] = (this.WarlobbyTroopData[0][i] + this.WarlobbyTroopData[1][i] + this.WarlobbyTroopData[2][i] + this.WarlobbyTroopData[3][i]) / this.WarlobbyTroopTotalTroopNum;
				}
				if (num5 >= 0 && this.mWarlobbySolderValue[num5] * 100.0 > 0.0)
				{
					array2[(int)b] = (byte)num5;
					this.m_NeedWarlobbySoldier[num5] = (long)(this.mWarlobbySolderValue[num5] * (double)this.WarlobbyTroopMax);
					num2 -= this.m_NeedWarlobbySoldier[num5];
					b += 1;
				}
			}
		}
		else if (mKind == 2)
		{
			this.Text_W_SelectTilte.text = this.DM.mStringTable.GetStringByID(14723u);
			for (int l = 0; l < 16; l++)
			{
				if (this.WarlobbyTroopTotalTroopNum > 0u)
				{
					this.mWarlobbySolderValue[l] = this.WarlobbyTroopData[l >> 2][l & 3] / this.WarlobbyTroopTotalTroopNum;
				}
				if (this.mWarlobbySolderValue[l] * 100.0 > 0.0)
				{
					array2[(int)b] = (byte)l;
					this.m_NeedWarlobbySoldier[l] = (long)(this.mWarlobbySolderValue[l] * (double)this.WarlobbyTroopMax);
					num2 -= this.m_NeedWarlobbySoldier[l];
					b += 1;
				}
			}
		}
		byte b2;
		if (num2 > 0L)
		{
			b2 = 0;
			for (int m = 0; m < (int)b; m++)
			{
				int num5 = (int)array2[m];
				if (this.mWarlobbySolderValue[num5] * 100.0 > 0.0 && this.mWarlobbySolderValue[num5] * (double)this.WarlobbyTroopMax >= 1.0)
				{
					b2 += 1;
				}
			}
			if (b2 > 0)
			{
				num3 = ((num2 % (long)b2 <= 0L) ? (num2 / (long)b2) : (num2 / (long)b2 + 1L));
			}
			for (int n = 0; n < (int)b; n++)
			{
				int num5 = (int)array2[n];
				if (this.mWarlobbySolderValue[num5] * 100.0 > 0.0 && this.mWarlobbySolderValue[num5] * (double)this.WarlobbyTroopMax >= 1.0 && num2 > 0L)
				{
					this.m_NeedWarlobbySoldier[num5] += ((num2 - num3 <= 0L) ? num2 : num3);
					num2 = ((num2 - num3 < 0L) ? num2 : (num2 - num3));
					if (num2 <= 0L)
					{
						break;
					}
				}
			}
		}
		b2 = 0;
		for (int num6 = 0; num6 < (int)b; num6++)
		{
			int num5 = (int)array2[num6];
			if (this.mWarlobbySolderValue[num5] * 100.0 > 0.0 && this.mWarlobbySolderValue[num5] * (double)this.WarlobbyTroopMax >= 1.0)
			{
				if (this.m_SoldierMax[num5].Value[0] < (uint)(this.mWarlobbySolderValue[num5] * (double)this.WarlobbyTroopMax))
				{
					if (this.m_SoldierMax[num5].Value[0] == 0u)
					{
						this.bAllZero = true;
					}
					flag = false;
				}
				else
				{
					this.m_WarlobbySoldier[num5] = (long)(this.mWarlobbySolderValue[num5] * (double)this.WarlobbyTroopMax);
					num -= (long)(this.mWarlobbySolderValue[num5] * (double)this.WarlobbyTroopMax);
					b2 += 1;
				}
			}
		}
		if (flag && num > 0L)
		{
			if (b2 > 0)
			{
				num3 = ((num % (long)b2 <= 0L) ? (num / (long)b2) : (num / (long)b2 + 1L));
			}
			for (int num7 = 0; num7 < (int)b; num7++)
			{
				int num5 = (int)array2[num7];
				if (this.mWarlobbySolderValue[num5] * 100.0 > 0.0 && this.mWarlobbySolderValue[num5] * (double)this.WarlobbyTroopMax >= 1.0 && num > 0L)
				{
					if ((ulong)this.m_SoldierMax[num5].Value[0] < (ulong)(this.m_WarlobbySoldier[num5] + num3) && (ulong)this.m_SoldierMax[num5].Value[0] < (ulong)(this.m_WarlobbySoldier[num5] + num))
					{
						flag = false;
						break;
					}
					this.m_WarlobbySoldier[num5] += ((num - num3 <= 0L) ? num : num3);
					num = ((num - num3 < 0L) ? num : (num - num3));
					if (num <= 0L)
					{
						break;
					}
				}
			}
		}
		b2 = 0;
		if (!flag)
		{
			num = (long)((ulong)this.Hero_Total + (ulong)((long)this.mExpeditionlimit));
			for (int num8 = 0; num8 < (int)b; num8++)
			{
				int num5 = (int)array2[num8];
				if (this.mWarlobbySolderValue[num5] * 100.0 > 0.0)
				{
					double num9 = this.m_SoldierMax[num5].Value[0] / this.mWarlobbySolderValue[num5];
					if (num9 > 0.0)
					{
						if (num4 == 0.0)
						{
							num4 = num9;
							b2 = (byte)num5;
						}
						else if (num9 < num4)
						{
							num4 = num9;
							b2 = (byte)num5;
						}
					}
				}
			}
			if (num4 > 0.0)
			{
				for (int num10 = 0; num10 < (int)b; num10++)
				{
					int num5 = (int)array2[num10];
					if ((int)b2 == num5)
					{
						this.m_WarlobbySoldier[num5] = (long)((ulong)this.m_SoldierMax[num5].Value[0]);
					}
					else
					{
						this.m_WarlobbySoldier[num5] = (long)(num4 * this.mWarlobbySolderValue[num5]);
					}
					num -= this.m_WarlobbySoldier[num5];
				}
			}
		}
		for (int num11 = 0; num11 < (int)b; num11++)
		{
			int num5 = (int)array2[num11];
			if (this.m_NeedWarlobbySoldier[num5] > 0L)
			{
				this.mShowSolderIdx[(int)this.mWarlobbySolderList] = (byte)num5;
				this.mWarlobbySolderList += 1;
			}
		}
		if (this.bAllZero)
		{
			num = (long)((ulong)this.Hero_Total + (ulong)((long)this.mExpeditionlimit));
			Array.Clear(this.m_WarlobbySoldier, 0, this.m_WarlobbySoldier.Length);
		}
		this.WarlobbySelectQty = this.WarlobbyTroopMax - num;
		this.Text_W_SelectTilte.SetAllDirty();
		this.Text_W_SelectTilte.cachedTextGenerator.Invalidate();
		this.CheckScrollH();
	}

	// Token: 0x06001B0E RID: 6926 RVA: 0x002E89D0 File Offset: 0x002E6BD0
	public void SetWarlobbyTroopSelect()
	{
		for (int i = 0; i < 16; i++)
		{
			this.m_Soldier[i] = this.m_WarlobbySoldier[i];
		}
		for (int j = 0; j < 7; j++)
		{
			if (this.m_UnitRS_Item[j] != null)
			{
				int type = (int)this.m_UnitRS_Item[j].Type;
				long num = this.m_Soldier[this.m_UnitRS_Item[type].m_ID];
				this.m_UnitRS_Item[type].MaxValue = (long)((ulong)this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0]);
				this.m_UnitRS_Item[type].Value = num;
				this.m_UnitRS_Item[type].m_slider.maxValue = this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0];
				this.m_UnitRS_Item[type].m_slider.value = (double)num;
				if (this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0] >= this.Hero_Total)
				{
					this.m_UnitRS_Item[type].MaxValue = (long)((ulong)this.Hero_Total);
					this.m_UnitRS_Item[type].m_slider.maxValue = this.Hero_Total;
				}
				this.Cstr_Soldier_Text[type].ClearString();
				this.Cstr_Soldier_Text[type].IntToFormat(num, 1, true);
				this.Cstr_Soldier_Text[type].AppendFormat("{0}");
				this.m_UnitRS_Item[type].m_inputText.text = this.Cstr_Soldier_Text[type].ToString();
				this.m_UnitRS_Item[type].m_inputText.SetAllDirty();
				this.m_UnitRS_Item[type].m_inputText.cachedTextGenerator.Invalidate();
				if (num != 0L)
				{
					this.m_UnitRS_Item[j].m_inputText.color = this.mtextColor;
				}
				else
				{
					this.m_UnitRS_Item[j].m_inputText.color = Color.white;
				}
				this.Cstr_Soldier_ItemNum[type].ClearString();
				this.Cstr_Soldier_ItemNum[type].IntToFormat((long)((ulong)this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0] - (ulong)num), 1, true);
				this.Cstr_Soldier_ItemNum[type].AppendFormat("{0}");
				this.Text_Soldier_ItemNum[type].text = this.Cstr_Soldier_ItemNum[type].ToString();
				this.Text_Soldier_ItemNum[type].SetAllDirty();
				this.Text_Soldier_ItemNum[type].cachedTextGenerator.Invalidate();
			}
		}
		this.SetDRformURS(0);
	}

	// Token: 0x06001B0F RID: 6927 RVA: 0x002E8C6C File Offset: 0x002E6E6C
	public void UpPanelData(byte mKind = 0)
	{
		long num = (long)((ulong)this.Hero_Total + (ulong)((long)this.mExpeditionlimit));
		for (int i = 0; i < 16; i++)
		{
			if (num - (long)((ulong)this.m_SoldierMax[i].Value[(int)mKind]) >= 0L)
			{
				this.m_Soldier[i] = (long)((ulong)this.m_SoldierMax[i].Value[(int)mKind]);
			}
			else
			{
				this.m_Soldier[i] = num;
			}
			num -= this.m_Soldier[i];
		}
		for (int j = 0; j < 7; j++)
		{
			if (this.m_UnitRS_Item[j] != null)
			{
				int type = (int)this.m_UnitRS_Item[j].Type;
				long num2 = this.m_Soldier[this.m_UnitRS_Item[type].m_ID];
				this.m_UnitRS_Item[type].MaxValue = (long)((ulong)this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0]);
				this.m_UnitRS_Item[type].Value = num2;
				this.m_UnitRS_Item[type].m_slider.maxValue = this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0];
				this.m_UnitRS_Item[type].m_slider.value = (double)num2;
				if (this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0] >= this.Hero_Total)
				{
					this.m_UnitRS_Item[type].MaxValue = (long)((ulong)this.Hero_Total);
					this.m_UnitRS_Item[type].m_slider.maxValue = this.Hero_Total;
				}
				this.Cstr_Soldier_Text[type].ClearString();
				this.Cstr_Soldier_Text[type].IntToFormat(num2, 1, true);
				this.Cstr_Soldier_Text[type].AppendFormat("{0}");
				this.m_UnitRS_Item[type].m_inputText.text = this.Cstr_Soldier_Text[type].ToString();
				this.m_UnitRS_Item[type].m_inputText.SetAllDirty();
				this.m_UnitRS_Item[type].m_inputText.cachedTextGenerator.Invalidate();
				if (num2 != 0L)
				{
					this.m_UnitRS_Item[j].m_inputText.color = this.mtextColor;
				}
				else
				{
					this.m_UnitRS_Item[j].m_inputText.color = Color.white;
				}
				this.Cstr_Soldier_ItemNum[type].ClearString();
				this.Cstr_Soldier_ItemNum[type].IntToFormat((long)((ulong)this.m_SoldierMax[this.m_UnitRS_Item[type].m_ID].Value[0] - (ulong)num2), 1, true);
				this.Cstr_Soldier_ItemNum[type].AppendFormat("{0}");
				this.Text_Soldier_ItemNum[type].text = this.Cstr_Soldier_ItemNum[type].ToString();
				this.Text_Soldier_ItemNum[type].SetAllDirty();
				this.Text_Soldier_ItemNum[type].cachedTextGenerator.Invalidate();
			}
		}
		this.SetDRformURS(0);
	}

	// Token: 0x06001B10 RID: 6928 RVA: 0x002E8F60 File Offset: 0x002E7160
	public void SetHero_Total()
	{
		if (this.DM.LegionBattleHero.Count > 0 && this.DM.LegionBattleHero[0] == this.DM.GetLeaderID())
		{
			if (this.mOpenKind != 4)
			{
				this.Img_Leader[0].gameObject.SetActive(true);
			}
			this.bLeaderHero = true;
		}
		else
		{
			this.Img_Leader[0].gameObject.SetActive(false);
			this.bLeaderHero = false;
		}
		Array.Clear(this.Hero_ID, 0, this.Hero_ID.Length);
		this.Hero_Total = this.BaseNum;
		for (int i = 0; i < this.DM.LegionBattleHero.Count; i++)
		{
			uint key = (uint)this.DM.LegionBattleHero[i];
			if (this.DM.curHeroData.ContainsKey(key))
			{
				CurHeroData curHeroData = this.DM.curHeroData[key];
				this.Hero_ID[i] = (uint)curHeroData.ID;
				this.GUIM.ChangeHeroItemImg(this.btn_HeroImg[i].transform, eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
				this.Hero_Total += (uint)this.DM.RankSoldiers[(int)curHeroData.Enhance];
				this.Img_AddBG[i].gameObject.SetActive(false);
				this.btn_HeroImg[i].gameObject.SetActive(true);
			}
		}
		for (int j = this.DM.LegionBattleHero.Count; j < 5; j++)
		{
			this.btn_HeroImg[j].gameObject.SetActive(false);
		}
		for (int k = this.LockCount; k < 5; k++)
		{
			this.Img_Lock[k].gameObject.SetActive(true);
			this.Img_AddBG[k].gameObject.SetActive(false);
		}
	}

	// Token: 0x06001B11 RID: 6929 RVA: 0x002E9168 File Offset: 0x002E7368
	public override void OnClose()
	{
		if (this.AssetName != null)
		{
			this.GUIM.RemoveSpriteAsset(this.AssetName);
		}
		if (this.Cstr != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr);
		}
		if (this.Cstr_MusterTime != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_MusterTime);
		}
		if (this.Cstr_Time != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Time);
		}
		if (this.Cstr_Accelerate != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Accelerate);
		}
		if (this.AllyName != null)
		{
			StringManager.Instance.DeSpawnString(this.AllyName);
		}
		if (this.Cstr_TeamName != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_TeamName);
		}
		if (this.Cstr_WarlobbyKindText != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_WarlobbyKindText);
		}
		if (this.Cstr_WarlobbySolder != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_WarlobbySolder);
		}
		if (this.Cstr_WarlobbyMaxSolder != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_WarlobbyMaxSolder);
		}
		if (this.Cstr_HintNum != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_HintNum);
		}
		for (int i = 0; i < 11; i++)
		{
			if (this.Cstr_WarSoldier_Text[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_WarSoldier_Text[i]);
			}
			if (this.Cstr_WarSoldierRate_Text[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_WarSoldierRate_Text[i]);
			}
		}
		for (int j = 0; j < 2; j++)
		{
			if (this.Cstr_LoadNum[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_LoadNum[j]);
			}
			if (this.Cstr_Troops[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Troops[j]);
			}
		}
		for (int k = 0; k < 7; k++)
		{
			if (this.Cstr_Soldier_ItemNum[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Soldier_ItemNum[k]);
			}
			if (this.Cstr_Soldier_Text[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Soldier_Text[k]);
			}
		}
		if (!this.DM.bSetExpediton)
		{
			this.DM.mScroll_Idx = 0;
			this.DM.mScroll_Y = 0f;
		}
		this.GUIM.ClearCalculator();
		if (this.door)
		{
			this.door.HideFightButton();
		}
		if (this.mUI_CK != 255)
		{
			this.DM.mcollectionKind = this.mUI_CK;
			PlayerPrefs.SetString("CollectionKind", this.DM.mcollectionKind.ToString());
		}
		if (this.mUI_WarlobbyK != 255)
		{
			this.DM.mWarlobby_Kind = this.mUI_WarlobbyK;
			PlayerPrefs.SetString("WarlobbyKind", this.DM.mWarlobby_Kind.ToString());
		}
		if (this.mOpenKind == 1)
		{
			this.DM.LegionBattleHero.Clear();
		}
	}

	// Token: 0x06001B12 RID: 6930 RVA: 0x002E9484 File Offset: 0x002E7684
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			this.fightButtonTime = this.door.PlayFight(0f);
			break;
		case 2:
			this.DM.bSetExpediton = false;
			for (int i = 0; i < 16; i++)
			{
				this.DM.mExpeditionSoldierList[i] = 0u;
			}
			this.DM.LegionBattleHero.Clear();
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 3:
			if (this.DM.TeamName.Length == 0)
			{
				this.DM.TeamName.ClearString();
				this.DM.TeamName.IntToFormat((long)(this.TMD_Idx + 1), 1, false);
				this.DM.TeamName.AppendFormat(this.DM.mStringTable.GetStringByID(993u));
			}
			this.TMD_Name = this.DM.TeamName.ToString();
			this.Text_Name.text = this.TMD_Name;
			this.Text_Name.SetAllDirty();
			this.Text_Name.cachedTextGenerator.Invalidate();
			this.DM.LegionBattleHero.Clear();
			break;
		case 4:
			if (this.mOpenKind == 6)
			{
				this.DM.LegionBattleHero.Clear();
				if (this.TMD_Idx >= 0 && this.TMD_Idx <= 4)
				{
					bool flag = false;
					int num = 0;
					for (int j = 0; j < 5; j++)
					{
						if (this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[j] != 0 && this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[j] == this.DM.GetLeaderID())
						{
							flag = true;
							num = j;
							break;
						}
					}
					for (int k = 0; k < 5; k++)
					{
						if (flag && num != 0)
						{
							if (k == 0)
							{
								this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[num]);
							}
							else if (k == num)
							{
								this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[0]);
							}
							else
							{
								this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[k]);
							}
						}
						else
						{
							this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[k]);
						}
					}
					if (this.DM.LegionBattleHero.Count > 0)
					{
						this.BG_T1.gameObject.SetActive(false);
						this.BG_T2.gameObject.SetActive(true);
						this.bExpeditionHero = true;
					}
					this.DM.bSetExpediton = true;
					for (int l = 0; l < 16; l++)
					{
						this.DM.mExpeditionSoldierList[l] = this.DM.mTroopMemoryData[(int)this.TMD_Idx].TroopData[l];
					}
				}
				this.UpDataSoldier();
				this.bSpeed = true;
				Array.Sort<byte>(this.SpeedsortData, this);
				this.m_ScrollPanel.AddNewDataHeight(this.tmplist, true, true);
				this.SetDRformURS(0);
				if (this.SoldierMax == 0L)
				{
					this.Img_NoSoldierBG.gameObject.SetActive(true);
				}
				else
				{
					this.Img_NoSoldierBG.gameObject.SetActive(false);
				}
				this.CheckMaxSelect();
				this.SelectFormation();
			}
			break;
		case 5:
			if ((this.mWarlobbyKind == 0 && this.DM.WarlobbyDetail.AttackOrDefense == 0 && this.WarlobbyTroopTotalTroopNum == 0u && this.DM.WarTroop.Count > 0) || (this.mWarlobbyKind >= 1 && this.mWarlobbyKind <= 2 && this.DM.WarlobbyDetail.AttackOrDefense == 2 && this.DM.WarTroop.Count > 0))
			{
				this.WarlobbyTroopTotalTroopNum = this.DM.WarTroop[0].TotalTroopNum;
				for (int m = 0; m < 16; m++)
				{
					this.WarlobbyTroopData[m >> 2][m & 3] = this.DM.WarTroop[0].TroopData[m >> 2][3 - (m & 3)];
				}
			}
			break;
		case 6:
			if ((this.mWarlobbyKind == 0 && this.DM.WarlobbyDetail.AttackOrDefense == 0) || (this.mWarlobbyKind >= 1 && this.mWarlobbyKind <= 2 && this.DM.WarlobbyDetail.AttackOrDefense == 2))
			{
				if (this.mUI_WarlobbyK_btn != 255)
				{
					this.mUI_WarlobbyK = this.mUI_WarlobbyK_btn;
				}
				this.SetWarlobbyMenu(false, 0);
				this.SetWarlobbyTroopSelect();
			}
			break;
		}
	}

	// Token: 0x06001B13 RID: 6931 RVA: 0x002E99FC File Offset: 0x002E7BFC
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		{
			if (this.mOpenKind == 4)
			{
				if (HideArmyManager.Instance.IsHideArmy())
				{
					this.DM.bSetExpediton = false;
					for (int i = 0; i < 16; i++)
					{
						this.DM.mExpeditionSoldierList[i] = 0u;
					}
					this.DM.LegionBattleHero.Clear();
					if (this.door != null)
					{
						this.door.CloseMenu(false);
					}
				}
				else
				{
					this.door.ShowFightButton(new Vector3(280f, -282f, -500f), 250f, false, E3DButtonKind.BK_Big);
				}
				eHeroState heroState = this.DM.GetHeroState(this.DM.GetLeaderID());
				if (heroState != eHeroState.None)
				{
					this.Img_HeroStatus.gameObject.SetActive(true);
					this.Img_CaveStatus.gameObject.SetActive(false);
					this.bCaveMainHero = false;
				}
				else
				{
					this.DM.LegionBattleHero.Clear();
					this.DM.LegionBattleHero.Add(this.DM.GetLeaderID());
				}
				this.bLeaderHero = true;
			}
			this.bLogin = true;
			this.DM.bSetExpediton = true;
			for (int j = 0; j < 16; j++)
			{
				this.m_Soldier[j] = (long)((ulong)this.DM.mExpeditionSoldierList[j]);
			}
			if (this.mOpenKind != 4)
			{
				this.BG_T1.gameObject.SetActive(true);
				this.BG_T2.gameObject.SetActive(false);
				if (this.mOpenKind == 1)
				{
					this.DM.LegionBattleHero.Clear();
					this.DM.SetSortNonFightHeroID();
					int num = 0;
					while (num < this.DM.GetMaxDefenders() && (long)num < (long)((ulong)this.DM.NonFightHeroCount))
					{
						this.DM.LegionBattleHero.Add((ushort)this.DM.SortNonFightHeroID[num]);
						num++;
					}
					if (this.DM.LegionBattleHero.Count > 0)
					{
						this.BG_T1.gameObject.SetActive(false);
						this.BG_T2.gameObject.SetActive(true);
						this.bExpeditionHero = true;
					}
				}
				else if (this.mOpenKind == 6)
				{
					this.DM.LegionBattleHero.Clear();
					if (this.TMD_Idx >= 0 && this.TMD_Idx <= 4)
					{
						bool flag = false;
						int num2 = 0;
						for (int k = 0; k < 5; k++)
						{
							if (this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[k] != 0 && this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[k] == this.DM.GetLeaderID())
							{
								flag = true;
								num2 = k;
								break;
							}
						}
						for (int l = 0; l < 5; l++)
						{
							if (flag && num2 != 0)
							{
								if (l == 0)
								{
									this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[num2]);
								}
								else if (l == num2)
								{
									this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[0]);
								}
								else
								{
									this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[l]);
								}
							}
							else
							{
								this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[l]);
							}
						}
						if (this.DM.LegionBattleHero.Count > 0)
						{
							this.BG_T1.gameObject.SetActive(false);
							this.BG_T2.gameObject.SetActive(true);
							this.bExpeditionHero = true;
						}
						this.DM.bSetExpediton = true;
						for (int m = 0; m < 16; m++)
						{
							this.DM.mExpeditionSoldierList[m] = this.DM.mTroopMemoryData[(int)this.TMD_Idx].TroopData[m];
						}
					}
				}
			}
			if (this.mOpenKind != 10)
			{
				if (this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].bEnable)
				{
					this.mEquip = this.DM.EquipTable.GetRecordByKey(this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].ItemID);
					this.mBuffTotal = (uint)this.mEquip.PropertiesInfo[1].PropertiesValue;
				}
				else
				{
					this.mBuffTotal = 0u;
				}
			}
			else
			{
				this.mBuffTotal = 5000u;
			}
			this.EGASpeed = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED);
			this.EGASpeed2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_DEBUFF);
			this.EGASpeed3 = 0u;
			this.EGASpeed4 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_CURSE);
			this.EGACapacityKind = 0u;
			RoleBuildingData buildData = this.GUIM.BuildingData.GetBuildData(8, 0);
			this.BaseNum = this.GUIM.BuildingData.GetBuildLevelRequestData(8, buildData.Level).Value1;
			this.Hero_Total = this.BaseNum;
			this.SetHero_Total();
			this.UpDataSoldier();
			this.bSpeed = true;
			Array.Sort<byte>(this.SpeedsortData, this);
			switch (this.mStatus)
			{
			case 0:
				this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ATTACK_MARCH_SPEED);
				if (this.mOpenKind == 4)
				{
					this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_SHELTER_TROOP_AMOUNT);
				}
				break;
			case 1:
				this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_GATHERING_MARCH_SPEED);
				this.EGALoadKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_LOAD);
				this.tmpLoad = 10000u + this.EGALoadKind;
				this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_GATHERING_CAPACITY);
				break;
			case 2:
				if (this.MapID < 3)
				{
					this.EGAKind = this.DM.m_InForceMarchSpeedPlus;
				}
				else
				{
					this.EGAKind = 0u;
				}
				break;
			case 3:
				this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RALLY_SPEED);
				if (this.mOpenKind == 9)
				{
					this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_TROOP_AMOUNT);
					this.EGASpeed3 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_RALLY_SPEED);
				}
				break;
			case 4:
				this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RALLY_SPEED);
				if (this.mOpenKind == 9)
				{
					this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_TROOP_AMOUNT);
					this.EGASpeed3 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_JOINRALLY_SPEED);
				}
				break;
			}
			this.tmpTime = (10000u + this.EGASpeed4) / (10000u + this.EGAKind + this.EGASpeed - this.EGASpeed2 + this.EGASpeed3);
			this.Hero_Total += this.EGACapacityKind;
			this.Hero_Total = (uint)(this.Hero_Total * ((10000u + this.mBuffTotal) / 10000.0));
			this.SetDRformURS(0);
			this.CheckMaxSelect();
			this.SelectFormation();
			this.Cstr_Accelerate.ClearString();
			int num3 = (int)(this.EGAKind + this.EGASpeed - this.EGASpeed2 + this.EGASpeed3);
			if ((float)num3 % 100f != 0f)
			{
				this.Cstr_Accelerate.FloatToFormat((float)num3 / 100f, 2, false);
			}
			else
			{
				this.Cstr_Accelerate.IntToFormat((long)(num3 / 100), 1, false);
			}
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Accelerate.AppendFormat("%{0}");
			}
			else
			{
				this.Cstr_Accelerate.AppendFormat("{0}%");
			}
			this.Text_Time[2].text = this.Cstr_Accelerate.ToString();
			this.Text_Time[2].SetAllDirty();
			this.Text_Time[2].cachedTextGenerator.Invalidate();
			break;
		}
		default:
			if (networkNews != NetworkNews.Refresh_Soldier)
			{
				if (networkNews != NetworkNews.Refresh_AttribEffectVal && networkNews != NetworkNews.Refresh_BuffList)
				{
					if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
					{
						this.Refresh_FontTexture();
						if (this.m_UnitRS != null)
						{
							this.m_UnitRS.Refresh_FontTexture();
						}
						for (int n = 0; n < 7; n++)
						{
							if (this.m_UnitRS_Item[n] != null)
							{
								this.m_UnitRS_Item[n].Refresh_FontTexture();
							}
						}
					}
				}
				else
				{
					if (this.mOpenKind != 10)
					{
						if (this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].bEnable)
						{
							this.mEquip = this.DM.EquipTable.GetRecordByKey(this.DM.m_RecvItemBuffData[this.ItemBuffDataIdx].ItemID);
							this.mBuffTotal = (uint)this.mEquip.PropertiesInfo[1].PropertiesValue;
						}
						else
						{
							this.mBuffTotal = 0u;
						}
					}
					else
					{
						this.mBuffTotal = 5000u;
					}
					this.EGASpeed = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED);
					this.EGASpeed2 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_DEBUFF);
					this.EGASpeed3 = 0u;
					this.EGASpeed4 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_CURSE);
					this.EGACapacityKind = 0u;
					RoleBuildingData buildData2 = this.GUIM.BuildingData.GetBuildData(8, 0);
					this.BaseNum = this.GUIM.BuildingData.GetBuildLevelRequestData(8, buildData2.Level).Value1;
					this.Hero_Total = this.BaseNum;
					if (this.DM.LegionBattleHero.Count != 0)
					{
						if (this.mOpenKind != 4)
						{
							this.BG_T1.gameObject.SetActive(false);
							this.BG_T2.gameObject.SetActive(true);
						}
					}
					this.SetHero_Total();
					switch (this.mStatus)
					{
					case 0:
						this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ATTACK_MARCH_SPEED);
						if (this.mOpenKind == 4)
						{
							this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_SHELTER_TROOP_AMOUNT);
						}
						break;
					case 1:
						this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_GATHERING_MARCH_SPEED);
						this.EGALoadKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_LOAD);
						this.tmpLoad = 10000u + this.EGALoadKind;
						this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_GATHERING_CAPACITY);
						break;
					case 2:
						if (this.MapID < 3)
						{
							this.EGAKind = this.DM.m_InForceMarchSpeedPlus;
						}
						else
						{
							this.EGAKind = 0u;
						}
						break;
					case 3:
						this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RALLY_SPEED);
						if (this.mOpenKind == 9)
						{
							this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_TROOP_AMOUNT);
							this.EGASpeed3 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_RALLY_SPEED);
						}
						break;
					case 4:
						this.EGAKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RALLY_SPEED);
						if (this.mOpenKind == 9)
						{
							this.EGACapacityKind = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_TROOP_AMOUNT);
							this.EGASpeed3 = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_JOINRALLY_SPEED);
						}
						break;
					}
					this.tmpTime = (10000u + this.EGASpeed4) / (10000u + this.EGAKind + this.EGASpeed - this.EGASpeed2 + this.EGASpeed3);
					this.Hero_Total += this.EGACapacityKind;
					this.Hero_Total = (uint)(this.Hero_Total * ((10000u + this.mBuffTotal) / 10000.0));
					this.SetDRformURS(0);
					this.Cstr_Accelerate.ClearString();
					int num4 = (int)(this.EGAKind + this.EGASpeed - this.EGASpeed2 + this.EGASpeed3);
					if ((float)num4 % 100f != 0f)
					{
						this.Cstr_Accelerate.FloatToFormat((float)num4 / 100f, 2, false);
					}
					else
					{
						this.Cstr_Accelerate.IntToFormat((long)(num4 / 100), 1, false);
					}
					if (this.GUIM.IsArabic)
					{
						this.Cstr_Accelerate.AppendFormat("%{0}");
					}
					else
					{
						this.Cstr_Accelerate.AppendFormat("{0}%");
					}
					this.Text_Time[2].text = this.Cstr_Accelerate.ToString();
					this.Text_Time[2].SetAllDirty();
					this.Text_Time[2].cachedTextGenerator.Invalidate();
					if (this.Img_MusterTimeBG.gameObject.activeInHierarchy && (this.mOpenKind == 2 || (this.mOpenKind == 3 && this.MapID == 1)))
					{
						this.Cstr_MusterTime.ClearString();
						this.Cstr_MusterTime.IntToFormat((long)((ulong)this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_JOINRALLY_COMBATPOWER)), 1, true);
						this.Cstr_MusterTime.AppendFormat(this.DM.mStringTable.GetStringByID(12244u));
						this.Text_MusterTime.text = this.Cstr_MusterTime.ToString();
						this.Text_MusterTime.SetAllDirty();
						this.Text_MusterTime.cachedTextGenerator.Invalidate();
						this.Text_MusterTime.cachedTextGeneratorForLayout.Invalidate();
						if (this.Text_MusterTime.preferredWidth <= 200f)
						{
							this.Text_MusterTime.rectTransform.sizeDelta = new Vector2(this.Text_MusterTime.preferredWidth + 1f, this.Text_MusterTime.rectTransform.sizeDelta.y);
						}
						this.Text_MusterTime.rectTransform.anchoredPosition = new Vector2(this.Img_CombatpowerBG.rectTransform.sizeDelta.x / 2f + 2f, this.Text_MusterTime.rectTransform.anchoredPosition.y);
						this.Img_CombatpowerBG.rectTransform.anchoredPosition = new Vector2(-this.Text_MusterTime.rectTransform.sizeDelta.x / 2f - 2f, this.Img_CombatpowerBG.rectTransform.anchoredPosition.y);
					}
				}
			}
			else
			{
				if (this.mOpenKind == 6)
				{
					this.DM.LegionBattleHero.Clear();
					if (this.TMD_Idx >= 0 && this.TMD_Idx <= 4)
					{
						bool flag2 = false;
						int num5 = 0;
						for (int num6 = 0; num6 < 5; num6++)
						{
							if (this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[num6] != 0 && this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[num6] == this.DM.GetLeaderID())
							{
								flag2 = true;
								num5 = num6;
								break;
							}
						}
						for (int num7 = 0; num7 < 5; num7++)
						{
							if (flag2 && num5 != 0)
							{
								if (num7 == 0)
								{
									this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[num5]);
								}
								else if (num7 == num5)
								{
									this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[0]);
								}
								else
								{
									this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[num7]);
								}
							}
							else
							{
								this.DM.LegionBattleHero.Add(this.DM.mTroopMemoryData[(int)this.TMD_Idx].Leader[num7]);
							}
						}
						if (this.DM.LegionBattleHero.Count > 0)
						{
							this.BG_T1.gameObject.SetActive(false);
							this.BG_T2.gameObject.SetActive(true);
							this.bExpeditionHero = true;
						}
						this.DM.bSetExpediton = true;
						for (int num8 = 0; num8 < 16; num8++)
						{
							this.DM.mExpeditionSoldierList[num8] = this.DM.mTroopMemoryData[(int)this.TMD_Idx].TroopData[num8];
						}
					}
				}
				else
				{
					for (int num9 = 0; num9 < 16; num9++)
					{
						this.DM.mExpeditionSoldierList[num9] = (uint)this.m_Soldier[num9];
					}
				}
				this.UpDataSoldier();
				this.bSpeed = true;
				Array.Sort<byte>(this.SpeedsortData, this);
				this.m_ScrollPanel.AddNewDataHeight(this.tmplist, true, true);
				this.SetDRformURS(0);
				if (this.SoldierMax == 0L)
				{
					this.Img_NoSoldierBG.gameObject.SetActive(true);
				}
				else
				{
					this.Img_NoSoldierBG.gameObject.SetActive(false);
				}
				this.CheckMaxSelect();
				this.SelectFormation();
			}
			break;
		case NetworkNews.Refresh:
			break;
		case NetworkNews.Refresh_Hero:
			if (this.mOpenKind == 4)
			{
				eHeroState heroState2 = this.DM.GetHeroState(this.DM.GetLeaderID());
				if (heroState2 == eHeroState.None)
				{
					this.Img_HeroStatus.gameObject.SetActive(false);
				}
				else
				{
					this.Img_HeroStatus.gameObject.SetActive(true);
					this.DM.LegionBattleHero.Clear();
					this.SetHero_Total();
					this.SetDRformURS(0);
					switch (heroState2)
					{
					case eHeroState.IsFighting:
						this.Img_HeroStatus.sprite = this.SArray.m_Sprites[16];
						break;
					case eHeroState.Captured:
						this.Img_HeroStatus.sprite = this.SArray.m_Sprites[17];
						break;
					case eHeroState.Dead:
						this.Img_HeroStatus.sprite = this.SArray.m_Sprites[18];
						break;
					}
				}
			}
			break;
		}
	}

	// Token: 0x06001B14 RID: 6932 RVA: 0x002EADC4 File Offset: 0x002E8FC4
	public void Refresh_FontTexture()
	{
		if (this.Text_MusterTime != null && this.Text_MusterTime.enabled)
		{
			this.Text_MusterTime.enabled = false;
			this.Text_MusterTime.enabled = true;
		}
		if (this.Text_HeroTeam != null && this.Text_HeroTeam.enabled)
		{
			this.Text_HeroTeam.enabled = false;
			this.Text_HeroTeam.enabled = true;
		}
		if (this.Text_Formation != null && this.Text_Formation.enabled)
		{
			this.Text_Formation.enabled = false;
			this.Text_Formation.enabled = true;
		}
		if (this.Text_CaveMain != null && this.Text_CaveMain.enabled)
		{
			this.Text_CaveMain.enabled = false;
			this.Text_CaveMain.enabled = true;
		}
		if (this.Text_Name != null && this.Text_Name.enabled)
		{
			this.Text_Name.enabled = false;
			this.Text_Name.enabled = true;
		}
		if (this.Text_Save != null && this.Text_Save.enabled)
		{
			this.Text_Save.enabled = false;
			this.Text_Save.enabled = true;
		}
		if (this.Text_Apply != null && this.Text_Apply.enabled)
		{
			this.Text_Apply.enabled = false;
			this.Text_Apply.enabled = true;
		}
		if (this.Text_btnApply != null && this.Text_btnApply.enabled)
		{
			this.Text_btnApply.enabled = false;
			this.Text_btnApply.enabled = true;
		}
		if (this.Text_W_SelectTilte != null && this.Text_W_SelectTilte.enabled)
		{
			this.Text_W_SelectTilte.enabled = false;
			this.Text_W_SelectTilte.enabled = true;
		}
		if (this.Text_W_MenuSet != null && this.Text_W_MenuSet.enabled)
		{
			this.Text_W_MenuSet.enabled = false;
			this.Text_W_MenuSet.enabled = true;
		}
		for (int i = 0; i < 5; i++)
		{
			if (this.Text_D[i] != null && this.Text_D[i].enabled)
			{
				this.Text_D[i].enabled = false;
				this.Text_D[i].enabled = true;
			}
			if (this.Text_L[i] != null && this.Text_L[i].enabled)
			{
				this.Text_L[i].enabled = false;
				this.Text_L[i].enabled = true;
			}
		}
		for (int j = 0; j < 2; j++)
		{
			if (this.Text_Troops[j] != null && this.Text_Troops[j].enabled)
			{
				this.Text_Troops[j].enabled = false;
				this.Text_Troops[j].enabled = true;
			}
			if (this.Text_SelectMenu[j] != null && this.Text_SelectMenu[j].enabled)
			{
				this.Text_SelectMenu[j].enabled = false;
				this.Text_SelectMenu[j].enabled = true;
			}
			if (this.Text_W_Select[j] != null && this.Text_W_Select[j].enabled)
			{
				this.Text_W_Select[j].enabled = false;
				this.Text_W_Select[j].enabled = true;
			}
		}
		for (int k = 0; k < 3; k++)
		{
			if (this.Text_Time[k] != null && this.Text_Time[k].enabled)
			{
				this.Text_Time[k].enabled = false;
				this.Text_Time[k].enabled = true;
			}
			if (this.Text_Hint[k] != null && this.Text_Hint[k].enabled)
			{
				this.Text_Hint[k].enabled = false;
				this.Text_Hint[k].enabled = true;
			}
			if (this.Text_tmpStr[k] != null && this.Text_tmpStr[k].enabled)
			{
				this.Text_tmpStr[k].enabled = false;
				this.Text_tmpStr[k].enabled = true;
			}
		}
		for (int l = 0; l < 4; l++)
		{
			if (this.Text_Load[l] != null && this.Text_Load[l].enabled)
			{
				this.Text_Load[l].enabled = false;
				this.Text_Load[l].enabled = true;
			}
			if (this.Text_Menu[l] != null && this.Text_Menu[l].enabled)
			{
				this.Text_Menu[l].enabled = false;
				this.Text_Menu[l].enabled = true;
			}
			if (this.Text_W_MenuKind[l] != null && this.Text_W_MenuKind[l].enabled)
			{
				this.Text_W_MenuKind[l].enabled = false;
				this.Text_W_MenuKind[l].enabled = true;
			}
			if (this.Text_W_Scroll[l] != null && this.Text_W_Scroll[l].enabled)
			{
				this.Text_W_Scroll[l].enabled = false;
				this.Text_W_Scroll[l].enabled = true;
			}
		}
		for (int m = 0; m < 7; m++)
		{
			if (this.Text_Soldier_ItemNum[m] != null && this.Text_Soldier_ItemNum[m].enabled)
			{
				this.Text_Soldier_ItemNum[m].enabled = false;
				this.Text_Soldier_ItemNum[m].enabled = true;
			}
			if (this.Text_Soldier_ItemName[m] != null && this.Text_Soldier_ItemName[m].enabled)
			{
				this.Text_Soldier_ItemName[m].enabled = false;
				this.Text_Soldier_ItemName[m].enabled = true;
			}
		}
		for (int n = 0; n < 11; n++)
		{
			for (int num = 0; num < 5; num++)
			{
				if (this.m_Warlobby_Item[n].text_T1[num] != null && this.m_Warlobby_Item[n].text_T1[num].enabled)
				{
					this.m_Warlobby_Item[n].text_T1[num].enabled = false;
					this.m_Warlobby_Item[n].text_T1[num].enabled = true;
				}
			}
			for (int num2 = 0; num2 < 4; num2++)
			{
				if (this.m_Warlobby_Item[n].text_SolderT[num2] != null && this.m_Warlobby_Item[n].text_SolderT[num2].enabled)
				{
					this.m_Warlobby_Item[n].text_SolderT[num2].enabled = false;
					this.m_Warlobby_Item[n].text_SolderT[num2].enabled = true;
				}
			}
			if (this.m_Warlobby_Item[n].text_T2 != null && this.m_Warlobby_Item[n].text_T2.enabled)
			{
				this.m_Warlobby_Item[n].text_T2.enabled = false;
				this.m_Warlobby_Item[n].text_T2.enabled = true;
			}
		}
		for (int num3 = 0; num3 < 5; num3++)
		{
			if (this.btn_HeroImg[num3] != null && this.btn_HeroImg[num3].enabled)
			{
				this.btn_HeroImg[num3].Refresh_FontTexture();
			}
		}
		if (this.btn_MainHeroImg != null && this.btn_MainHeroImg.enabled)
		{
			this.btn_MainHeroImg.Refresh_FontTexture();
		}
	}

	// Token: 0x06001B15 RID: 6933 RVA: 0x002EB60C File Offset: 0x002E980C
	private void Update()
	{
		if (this.bLeaderHero)
		{
			this.ShowTime += Time.smoothDeltaTime;
			if (this.ShowTime >= 0f)
			{
				if (this.ShowTime >= 2f)
				{
					this.ShowTime = 0f;
				}
				float a = (this.ShowTime <= 1f) ? this.ShowTime : (2f - this.ShowTime);
				if (this.Img_Leader[0].IsActive())
				{
					this.Img_Leader[1].color = new Color(1f, 1f, 1f, a);
				}
				if (this.Img_CaveMain[0].IsActive())
				{
					this.Img_CaveMain[1].color = new Color(1f, 1f, 1f, a);
				}
			}
		}
		if (this.fightButtonTime > 0f)
		{
			this.fightButtonTime -= Time.deltaTime;
			if (this.fightButtonTime <= 0f)
			{
				AudioManager.Instance.PlayUISFX(UIKind.Expedition);
				if (this.mOpenKind == 1)
				{
					GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MapToWar_Stage);
					if (this.door != null)
					{
						this.door.m_GroundInfo.bOpenPvePanel = false;
						this.door.CloseMenu(false);
					}
					GameManager.OnRefresh(NetworkNews.Refresh_Soldier, null);
					GameManager.OnRefresh(NetworkNews.Refresh_Hospital, null);
					GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
				}
				else
				{
					this.SendExpedition();
				}
				GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Expedition);
			}
		}
	}

	// Token: 0x06001B16 RID: 6934 RVA: 0x002EB7B0 File Offset: 0x002E99B0
	public override void ReOnOpen()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && this.mOpenKind != 6)
		{
			door.ShowFightButton(new Vector3(280f, -282f, -500f), 250f, false, E3DButtonKind.BK_Big);
		}
	}

	// Token: 0x06001B17 RID: 6935 RVA: 0x002EB808 File Offset: 0x002E9A08
	public bool CheckIsYolk(ushort mZoneID, byte mPointID)
	{
		bool result = false;
		if (DataManager.MapDataController.getYolkIDbyPointCode(mZoneID, mPointID, 0) != 40)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x0400500D RID: 20493
	private DataManager DM;

	// Token: 0x0400500E RID: 20494
	private GUIManager GUIM;

	// Token: 0x0400500F RID: 20495
	private RectTransform tmpRC;

	// Token: 0x04005010 RID: 20496
	private RectTransform Img_TargetRT;

	// Token: 0x04005011 RID: 20497
	private RectTransform Text_LoadRT;

	// Token: 0x04005012 RID: 20498
	private RectTransform[] Img_HintRT = new RectTransform[3];

	// Token: 0x04005013 RID: 20499
	private RectTransform[] Text_HintRT = new RectTransform[3];

	// Token: 0x04005014 RID: 20500
	private RectTransform mContentRT;

	// Token: 0x04005015 RID: 20501
	private Transform GameT;

	// Token: 0x04005016 RID: 20502
	private Transform Tmp;

	// Token: 0x04005017 RID: 20503
	private Transform Tmp1;

	// Token: 0x04005018 RID: 20504
	private Transform Tmp2;

	// Token: 0x04005019 RID: 20505
	private Transform BG_T1;

	// Token: 0x0400501A RID: 20506
	private Transform BG_T2;

	// Token: 0x0400501B RID: 20507
	private Transform BG_T3;

	// Token: 0x0400501C RID: 20508
	private Transform mLoad_T;

	// Token: 0x0400501D RID: 20509
	private Transform mLoadBG_T;

	// Token: 0x0400501E RID: 20510
	private Transform mTime_T;

	// Token: 0x0400501F RID: 20511
	private Transform mTroops_T;

	// Token: 0x04005020 RID: 20512
	private Transform mSave_T;

	// Token: 0x04005021 RID: 20513
	private Transform mSelectTeam_T;

	// Token: 0x04005022 RID: 20514
	private Transform mSelectTeam_LT;

	// Token: 0x04005023 RID: 20515
	private Transform mApply_T;

	// Token: 0x04005024 RID: 20516
	private Transform mWarlobbyT;

	// Token: 0x04005025 RID: 20517
	private UIButton btn_EXIT;

	// Token: 0x04005026 RID: 20518
	private UIButton btn_HeroTeam;

	// Token: 0x04005027 RID: 20519
	private UIButton btn_Formation;

	// Token: 0x04005028 RID: 20520
	private UIButton btn_FormationMenu;

	// Token: 0x04005029 RID: 20521
	private UIButton btn_Troops;

	// Token: 0x0400502A RID: 20522
	private UIButton btn_Load;

	// Token: 0x0400502B RID: 20523
	private UIButton btn_Time;

	// Token: 0x0400502C RID: 20524
	public UIButton btn_Expedition;

	// Token: 0x0400502D RID: 20525
	private UIButton btn_HeroFormation;

	// Token: 0x0400502E RID: 20526
	private UIButton btn_Clear;

	// Token: 0x0400502F RID: 20527
	private UIButton[] btn_ItemInput = new UIButton[7];

	// Token: 0x04005030 RID: 20528
	private UIButton[] btn_Menu = new UIButton[4];

	// Token: 0x04005031 RID: 20529
	private UIButton[] btn_SelectMenu = new UIButton[2];

	// Token: 0x04005032 RID: 20530
	private UIButton[] btn_Hero = new UIButton[5];

	// Token: 0x04005033 RID: 20531
	private UIButton btn_CaveCheck;

	// Token: 0x04005034 RID: 20532
	private UIHIBtn[] btn_HeroImg = new UIHIBtn[5];

	// Token: 0x04005035 RID: 20533
	private UIHIBtn btn_MainHeroImg;

	// Token: 0x04005036 RID: 20534
	private UIButton btn_SetName;

	// Token: 0x04005037 RID: 20535
	private UIButton btn_Save;

	// Token: 0x04005038 RID: 20536
	private UIButton[] btn_SelectTeam = new UIButton[10];

	// Token: 0x04005039 RID: 20537
	private UIButton btn_Apply;

	// Token: 0x0400503A RID: 20538
	private UIButton[] btn_W_MenuSelect = new UIButton[2];

	// Token: 0x0400503B RID: 20539
	private UIButton btn_W_MenuBack;

	// Token: 0x0400503C RID: 20540
	private UIButton[] btn_W_MenuKind = new UIButton[3];

	// Token: 0x0400503D RID: 20541
	private UIButton btn_W_MenuSet;

	// Token: 0x0400503E RID: 20542
	private UIButton[] btn_W_InfoBack = new UIButton[2];

	// Token: 0x0400503F RID: 20543
	private Image[] Img_Lock = new Image[5];

	// Token: 0x04005040 RID: 20544
	private Image[] Img_AddBG = new Image[5];

	// Token: 0x04005041 RID: 20545
	private Image[] Img_Leader = new Image[2];

	// Token: 0x04005042 RID: 20546
	private Image Img_StatusBG;

	// Token: 0x04005043 RID: 20547
	private Image[] Img_StatusBG2 = new Image[3];

	// Token: 0x04005044 RID: 20548
	private Image[] Img_HintBG = new Image[3];

	// Token: 0x04005045 RID: 20549
	private Image Img_TargetBG;

	// Token: 0x04005046 RID: 20550
	private Image Img_MusterTimeBG;

	// Token: 0x04005047 RID: 20551
	private Image Img_CombatpowerBG;

	// Token: 0x04005048 RID: 20552
	private Image Img_NoSoldierBG;

	// Token: 0x04005049 RID: 20553
	private Image[] Img_Soldier_Kind = new Image[7];

	// Token: 0x0400504A RID: 20554
	private Image[] Img_Soldier_Item = new Image[7];

	// Token: 0x0400504B RID: 20555
	private Image[] Img_Soldier_ItemFrame = new Image[7];

	// Token: 0x0400504C RID: 20556
	private Image Img_Frame;

	// Token: 0x0400504D RID: 20557
	private Image[] Img_CaveMain = new Image[2];

	// Token: 0x0400504E RID: 20558
	private Image Img_HeroStatus;

	// Token: 0x0400504F RID: 20559
	private Image Img_CaveStatus;

	// Token: 0x04005050 RID: 20560
	private Image[] Img_SelectMenu = new Image[2];

	// Token: 0x04005051 RID: 20561
	private Image[] Img_SelectMenuKind = new Image[2];

	// Token: 0x04005052 RID: 20562
	private Image Img_W_SelectIcon;

	// Token: 0x04005053 RID: 20563
	private Image Img_W_MenuSelect;

	// Token: 0x04005054 RID: 20564
	private Image Img_W_Menu;

	// Token: 0x04005055 RID: 20565
	private Sprite[] m_SoldierSprite = new Sprite[16];

	// Token: 0x04005056 RID: 20566
	private Sprite[] m_SoldierSpriteFrame = new Sprite[16];

	// Token: 0x04005057 RID: 20567
	private Sprite[] mResources = new Sprite[6];

	// Token: 0x04005058 RID: 20568
	private Sprite[] mWarlobbyIcon = new Sprite[4];

	// Token: 0x04005059 RID: 20569
	private UIText Text_MusterTime;

	// Token: 0x0400505A RID: 20570
	private UIText Text_HeroTeam;

	// Token: 0x0400505B RID: 20571
	private UIText Text_Formation;

	// Token: 0x0400505C RID: 20572
	private UIText[] Text_Troops = new UIText[2];

	// Token: 0x0400505D RID: 20573
	private UIText[] Text_Load = new UIText[4];

	// Token: 0x0400505E RID: 20574
	private UIText[] Text_Time = new UIText[3];

	// Token: 0x0400505F RID: 20575
	private UIText[] Text_Menu = new UIText[4];

	// Token: 0x04005060 RID: 20576
	private UIText[] Text_Hint = new UIText[3];

	// Token: 0x04005061 RID: 20577
	private UIText[] Text_tmpStr = new UIText[3];

	// Token: 0x04005062 RID: 20578
	private UIText[] Text_Soldier_ItemNum = new UIText[7];

	// Token: 0x04005063 RID: 20579
	private UIText[] Text_Soldier_ItemName = new UIText[7];

	// Token: 0x04005064 RID: 20580
	private UIText Text_CaveMain;

	// Token: 0x04005065 RID: 20581
	private UIText[] Text_SelectMenu = new UIText[2];

	// Token: 0x04005066 RID: 20582
	private UIText Text_Name;

	// Token: 0x04005067 RID: 20583
	private UIText Text_Save;

	// Token: 0x04005068 RID: 20584
	private UIText[] Text_D = new UIText[5];

	// Token: 0x04005069 RID: 20585
	private UIText[] Text_L = new UIText[5];

	// Token: 0x0400506A RID: 20586
	private UIText Text_Apply;

	// Token: 0x0400506B RID: 20587
	private UIText Text_btnApply;

	// Token: 0x0400506C RID: 20588
	private UIText[] Text_W_Select = new UIText[2];

	// Token: 0x0400506D RID: 20589
	private UIText[] Text_W_MenuKind = new UIText[4];

	// Token: 0x0400506E RID: 20590
	private UIText Text_W_SelectTilte;

	// Token: 0x0400506F RID: 20591
	private UIText Text_W_MenuSet;

	// Token: 0x04005070 RID: 20592
	private UIText[] Text_W_Scroll = new UIText[4];

	// Token: 0x04005071 RID: 20593
	private CString Cstr;

	// Token: 0x04005072 RID: 20594
	private CString[] Cstr_Troops = new CString[2];

	// Token: 0x04005073 RID: 20595
	private CString Cstr_MusterTime;

	// Token: 0x04005074 RID: 20596
	private CString Cstr_Time;

	// Token: 0x04005075 RID: 20597
	private CString Cstr_Accelerate;

	// Token: 0x04005076 RID: 20598
	private CString[] Cstr_LoadNum = new CString[2];

	// Token: 0x04005077 RID: 20599
	private CString[] Cstr_Soldier_ItemNum = new CString[7];

	// Token: 0x04005078 RID: 20600
	private CString[] Cstr_Soldier_Text = new CString[7];

	// Token: 0x04005079 RID: 20601
	private CString Cstr_TeamName;

	// Token: 0x0400507A RID: 20602
	private CString[] Cstr_WarSoldier_Text = new CString[11];

	// Token: 0x0400507B RID: 20603
	private CString[] Cstr_WarSoldierRate_Text = new CString[11];

	// Token: 0x0400507C RID: 20604
	private CString Cstr_WarlobbyKindText;

	// Token: 0x0400507D RID: 20605
	private CString Cstr_WarlobbySolder;

	// Token: 0x0400507E RID: 20606
	private CString Cstr_WarlobbyMaxSolder;

	// Token: 0x0400507F RID: 20607
	private CString Cstr_HintNum;

	// Token: 0x04005080 RID: 20608
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04005081 RID: 20609
	private CScrollRect m_ScrollRect;

	// Token: 0x04005082 RID: 20610
	private UnitResourcesSlider m_UnitRS;

	// Token: 0x04005083 RID: 20611
	private UnitResourcesSlider[] m_UnitRS_Item = new UnitResourcesSlider[7];

	// Token: 0x04005084 RID: 20612
	private UISpritesArray SArray;

	// Token: 0x04005085 RID: 20613
	private ScrollPanel m_ScrollPanel_Warlobby;

	// Token: 0x04005086 RID: 20614
	private CScrollRect m_ScrollRect_Warlobby;

	// Token: 0x04005087 RID: 20615
	private SoldierInfoItem[] m_Warlobby_Item = new SoldierInfoItem[11];

	// Token: 0x04005088 RID: 20616
	private bool[] InitSoldierInfoItem = new bool[11];

	// Token: 0x04005089 RID: 20617
	private StringBuilder tmpString = new StringBuilder();

	// Token: 0x0400508A RID: 20618
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x0400508B RID: 20619
	private SoldierData tmpSD;

	// Token: 0x0400508C RID: 20620
	private Material FrameMaterial;

	// Token: 0x0400508D RID: 20621
	private Material m_BW;

	// Token: 0x0400508E RID: 20622
	private Soldier_H[] m_SoldierData = new Soldier_H[16];

	// Token: 0x0400508F RID: 20623
	private Soldier_Select[] m_SoldierMax = new Soldier_Select[16];

	// Token: 0x04005090 RID: 20624
	private long[] m_Soldier = new long[16];

	// Token: 0x04005091 RID: 20625
	private uint[] Hero_ID = new uint[5];

	// Token: 0x04005092 RID: 20626
	private uint Hero_Total;

	// Token: 0x04005093 RID: 20627
	private uint BaseNum;

	// Token: 0x04005094 RID: 20628
	private long SoldierMax;

	// Token: 0x04005095 RID: 20629
	private long ExpeditionNum;

	// Token: 0x04005096 RID: 20630
	private uint Time_Total;

	// Token: 0x04005097 RID: 20631
	private float Distance_Total;

	// Token: 0x04005098 RID: 20632
	private long Load_Total;

	// Token: 0x04005099 RID: 20633
	private bool bExpeditionHero;

	// Token: 0x0400509A RID: 20634
	private bool bLeaderHero;

	// Token: 0x0400509B RID: 20635
	private bool bSpeed = true;

	// Token: 0x0400509C RID: 20636
	private int LockCount = 5;

	// Token: 0x0400509D RID: 20637
	private int tmpListIdx;

	// Token: 0x0400509E RID: 20638
	private int MapID;

	// Token: 0x0400509F RID: 20639
	private int mStatus;

	// Token: 0x040050A0 RID: 20640
	private int mResourcesKind;

	// Token: 0x040050A1 RID: 20641
	private int mOpenKind;

	// Token: 0x040050A2 RID: 20642
	private float fightButtonTime;

	// Token: 0x040050A3 RID: 20643
	private uint ResourcesMax;

	// Token: 0x040050A4 RID: 20644
	private float tmpL;

	// Token: 0x040050A5 RID: 20645
	private float tmpTime;

	// Token: 0x040050A6 RID: 20646
	private float tmpLoad;

	// Token: 0x040050A7 RID: 20647
	private uint EGAKind;

	// Token: 0x040050A8 RID: 20648
	private uint EGASpeed;

	// Token: 0x040050A9 RID: 20649
	private uint EGASpeed2;

	// Token: 0x040050AA RID: 20650
	private uint EGASpeed3;

	// Token: 0x040050AB RID: 20651
	private uint EGASpeed4;

	// Token: 0x040050AC RID: 20652
	private uint EGALoadKind;

	// Token: 0x040050AD RID: 20653
	private uint EGACapacityKind;

	// Token: 0x040050AE RID: 20654
	private uint mBuffTotal;

	// Token: 0x040050AF RID: 20655
	private int mSpeedIdx = 16;

	// Token: 0x040050B0 RID: 20656
	private MapPoint nowMapPoint;

	// Token: 0x040050B1 RID: 20657
	private int ItemBuffDataIdx;

	// Token: 0x040050B2 RID: 20658
	private bool bClear;

	// Token: 0x040050B3 RID: 20659
	private int mExpeditionlimit;

	// Token: 0x040050B4 RID: 20660
	private byte[] SpeedsortData = new byte[16];

	// Token: 0x040050B5 RID: 20661
	private byte[] LoadsortData = new byte[16];

	// Token: 0x040050B6 RID: 20662
	private byte[] ShowListIndex = new byte[16];

	// Token: 0x040050B7 RID: 20663
	private string AssetName;

	// Token: 0x040050B8 RID: 20664
	private string AssetName1;

	// Token: 0x040050B9 RID: 20665
	private string[] m_SoldierName = new string[16];

	// Token: 0x040050BA RID: 20666
	private string[] mbtnFormation = new string[2];

	// Token: 0x040050BB RID: 20667
	private float ShowTime;

	// Token: 0x040050BC RID: 20668
	private Door door;

	// Token: 0x040050BD RID: 20669
	private List<float> tmplist = new List<float>();

	// Token: 0x040050BE RID: 20670
	private List<float> tmplist_Warlooby = new List<float>();

	// Token: 0x040050BF RID: 20671
	private Equip mEquip;

	// Token: 0x040050C0 RID: 20672
	private Color mtextColor = new Color(1f, 0.845f, 0.1686f);

	// Token: 0x040050C1 RID: 20673
	private ushort[] mRallyCountDown = new ushort[4];

	// Token: 0x040050C2 RID: 20674
	private ushort ZoneID;

	// Token: 0x040050C3 RID: 20675
	private byte PointID;

	// Token: 0x040050C4 RID: 20676
	private uint GoToMaxSoldier;

	// Token: 0x040050C5 RID: 20677
	private bool bPVEOpen = true;

	// Token: 0x040050C6 RID: 20678
	private float[] tmpPVEPower = new float[4];

	// Token: 0x040050C7 RID: 20679
	private bool bLogin;

	// Token: 0x040050C8 RID: 20680
	private CString AllyName;

	// Token: 0x040050C9 RID: 20681
	private bool bCaveMainHero = true;

	// Token: 0x040050CA RID: 20682
	private byte mUI_CK = byte.MaxValue;

	// Token: 0x040050CB RID: 20683
	private bool bShowSelectC;

	// Token: 0x040050CC RID: 20684
	private byte mNewType;

	// Token: 0x040050CD RID: 20685
	private TroopMemoryData tmpTMD;

	// Token: 0x040050CE RID: 20686
	private byte TMD_Idx;

	// Token: 0x040050CF RID: 20687
	private string TMD_Name;

	// Token: 0x040050D0 RID: 20688
	private byte mWonderId;

	// Token: 0x040050D1 RID: 20689
	private bool bOpenEnd;

	// Token: 0x040050D2 RID: 20690
	private GameObject mAllianceWarImg;

	// Token: 0x040050D3 RID: 20691
	private bool bScrollItemH;

	// Token: 0x040050D4 RID: 20692
	private bool bScrollItemH1;

	// Token: 0x040050D5 RID: 20693
	private bool bScrollItemH2;

	// Token: 0x040050D6 RID: 20694
	private bool bAllZero;

	// Token: 0x040050D7 RID: 20695
	private byte mUI_WarlobbyK = byte.MaxValue;

	// Token: 0x040050D8 RID: 20696
	private byte mUI_WarlobbyK_btn = byte.MaxValue;

	// Token: 0x040050D9 RID: 20697
	private byte mWarlobbySolderList;

	// Token: 0x040050DA RID: 20698
	private byte[] mShowSolderIdx = new byte[16];

	// Token: 0x040050DB RID: 20699
	private double[] mWarlobbySolderValue = new double[16];

	// Token: 0x040050DC RID: 20700
	public uint WarlobbyTroopTotalTroopNum;

	// Token: 0x040050DD RID: 20701
	public uint[][] WarlobbyTroopData = new uint[4][];

	// Token: 0x040050DE RID: 20702
	private long WarlobbySelectQty;

	// Token: 0x040050DF RID: 20703
	private long WarlobbyTroopMax;

	// Token: 0x040050E0 RID: 20704
	private long[] m_WarlobbySoldier = new long[16];

	// Token: 0x040050E1 RID: 20705
	private long[] m_NeedWarlobbySoldier = new long[16];

	// Token: 0x040050E2 RID: 20706
	private byte mWarlobbyKind;

	// Token: 0x040050E3 RID: 20707
	private byte mSrcollDataIdx;
}
