using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000276 RID: 630
public class UIMapMonster : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x06000C09 RID: 3081 RVA: 0x0011505C File Offset: 0x0011325C
	void IUIHIBtnClickHandler.OnHIButtonClick(UIHIBtn sender)
	{
		if (sender.m_BtnID2 == 0)
		{
			return;
		}
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		door.OpenMenu(EGUIWindow.UI_OpenBox, 1, sender.m_BtnID2, false);
	}

	// Token: 0x06000C0A RID: 3082 RVA: 0x00115098 File Offset: 0x00113298
	public override void OnOpen(int arg1, int arg2)
	{
		this.MonsterMapID = arg1;
		this.CountdownFlag = arg2;
		DataManager instance = DataManager.Instance;
		Font ttffont = GUIManager.Instance.GetTTFFont();
		Transform child = base.transform.GetChild(0);
		this.Panel2 = child.gameObject;
		if (arg2 == 1)
		{
			this.DelayShow = 0f;
		}
		this.maxRoleEnergy = instance.GetMaxMonsterPoint();
		this.TimesStr = StringManager.Instance.SpawnString(30);
		this.HurtStr = StringManager.Instance.SpawnString(30);
		this.LeftTimeStr = StringManager.Instance.SpawnString(30);
		this.CrusadeMStr = StringManager.Instance.SpawnString(30);
		this.UpperMessageStr = StringManager.Instance.SpawnString(100);
		this.CrusadeCostStr = StringManager.Instance.SpawnString(30);
		this.CrusadeMCostStr = StringManager.Instance.SpawnString(30);
		this.DestTimeStr = StringManager.Instance.SpawnString(30);
		this.BoostsStr = StringManager.Instance.SpawnString(30);
		this.PositionStr = StringManager.Instance.SpawnString(30);
		this.MonsterLvStr = StringManager.Instance.SpawnString(30);
		this.ArrChatStr = StringManager.Instance.SpawnString(30);
		this.MonsterNameStr = StringManager.Instance.SpawnString(30);
		this.MonsterNameText = child.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.MonsterNameText.font = ttffont;
		this.AddRefreshText(this.MonsterNameText);
		this.MonsterPositionText = child.GetChild(7).GetChild(4).GetComponent<UIText>();
		this.MonsterPositionText.font = ttffont;
		this.AddRefreshText(this.MonsterPositionText);
		this.MonsterLvText = child.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
		this.MonsterLvText.font = ttffont;
		this.AddRefreshText(this.MonsterLvText);
		this.MonsterDegree.Init(child.GetChild(0).GetChild(1), 274);
		this.AddRefreshText(this.MonsterDegree.TitleText);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			child.GetChild(15).GetComponent<CustomImage>().enabled = false;
		}
		else
		{
			child.GetChild(15).GetComponent<CustomImage>().hander = GUIManager.Instance.m_ItemInfo;
		}
		child.GetChild(15).GetChild(0).GetComponent<CustomImage>().hander = GUIManager.Instance.m_ItemInfo;
		this.MonsterTrans = child.GetChild(3);
		UIButton component = child.GetChild(1).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 0;
		if (GUIManager.Instance.IsArabic)
		{
			component.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		component = child.GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 1;
		component = child.GetChild(7).GetChild(3).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 2;
		component = child.GetChild(7).GetChild(5).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 3;
		this.CrusadeBtn = child.GetChild(8).GetComponent<UIButton>();
		this.CrusadeBtn.m_Handler = this;
		this.CrusadeBtn.m_BtnID1 = 5;
		this.CrusadeMBtn = child.GetChild(9).GetComponent<UIButton>();
		this.CrusadeMBtn.m_Handler = this;
		this.CrusadeMBtn.m_BtnID1 = 6;
		if (GUIManager.Instance.IsArabic)
		{
			this.CrusadeBtn.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
			this.CrusadeMBtn.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
		}
		this.FuncBtnRect = child.GetChild(10).GetComponent<RectTransform>();
		this.FuncBtn = child.GetChild(10).GetComponent<UIButton>();
		this.FuncBtn.m_Handler = this;
		this.FuncBtn.m_BtnID1 = 7;
		component = child.GetChild(15).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 4;
		this.UpperMessageText = child.GetChild(5).GetComponent<UIText>();
		this.UpperMessageText.font = ttffont;
		this.AddRefreshText(this.UpperMessageText);
		this.CrusadeTrans = child.GetChild(6);
		this.HurtText = this.CrusadeTrans.GetChild(0).GetComponent<UIText>();
		this.HurtText.font = ttffont;
		this.AddRefreshText(this.HurtText);
		this.LeftTimeText = this.CrusadeTrans.GetChild(1).GetComponent<UIText>();
		this.LeftTimeText.font = ttffont;
		this.AddRefreshText(this.LeftTimeText);
		this.TimesText = this.CrusadeTrans.GetChild(2).GetComponent<UIText>();
		this.TimesText.font = ttffont;
		this.AddRefreshText(this.TimesText);
		UIText component2 = this.CrusadeTrans.GetChild(3).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = instance.mStringTable.GetStringByID(8332u);
		this.AddRefreshText(component2);
		component2 = this.CrusadeTrans.GetChild(4).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = instance.mStringTable.GetStringByID(8333u);
		this.AddRefreshText(component2);
		this.DestTimeText = child.GetChild(7).GetChild(0).GetComponent<UIText>();
		this.DestTimeText.font = ttffont;
		this.AddRefreshText(this.DestTimeText);
		this.BoostsText = child.GetChild(7).GetChild(1).GetComponent<UIText>();
		this.BoostsText.font = ttffont;
		this.AddRefreshText(this.BoostsText);
		this.HintRect = child.GetChild(14).GetChild(0).GetComponent<RectTransform>();
		this.HintText = child.GetChild(14).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.HintText.font = ttffont;
		this.AddRefreshText(this.HintText);
		child.GetChild(14).GetChild(0).GetComponent<CustomImage>().hander = GUIManager.Instance.m_ItemInfo;
		UIButtonHint uibuttonHint = child.GetChild(7).GetChild(6).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.ScrollID = 1;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = this.HintRect.gameObject;
		uibuttonHint.Parm1 = 8352;
		this.EnergyDegree.Init(child.GetChild(7).GetChild(2), 336);
		this.AddRefreshText(this.EnergyDegree.TitleText);
		if (GUIManager.Instance.IsArabic)
		{
			child.GetChild(7).GetChild(2).GetChild(2).localScale = new Vector3(-1f, 1f, 1f);
		}
		this.CrusadeCostText = child.GetChild(8).GetChild(1).GetComponent<UIText>();
		this.CrusadeCostText.font = ttffont;
		this.AddRefreshText(this.CrusadeCostText);
		this.CrusadeText = child.GetChild(8).GetChild(2).GetComponent<UIText>();
		this.CrusadeText.font = ttffont;
		this.CrusadeText.text = instance.mStringTable.GetStringByID(8335u);
		this.AddRefreshText(this.CrusadeText);
		this.CrusadeMCostText = child.GetChild(9).GetChild(1).GetComponent<UIText>();
		this.CrusadeMCostText.font = ttffont;
		this.AddRefreshText(this.CrusadeMCostText);
		this.CrusadeMText = child.GetChild(9).GetChild(2).GetComponent<UIText>();
		this.CrusadeMText.font = ttffont;
		this.AddRefreshText(this.CrusadeMText);
		this.FuncBtnText = child.GetChild(10).GetChild(0).GetComponent<UIText>();
		this.FuncBtnText.font = ttffont;
		this.FuncBtnText.text = instance.mStringTable.GetStringByID(8337u);
		this.AddRefreshText(this.FuncBtnText);
		this.DownMessageText = child.GetChild(11).GetComponent<UIText>();
		this.DownMessageText.font = ttffont;
		this.AddRefreshText(this.DownMessageText);
		component2 = child.GetChild(12).GetChild(1).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = instance.mStringTable.GetStringByID(1590u);
		this.AddRefreshText(component2);
		this.PriceCont = child.GetChild(12).GetChild(2).GetChild(0).GetComponent<RectTransform>();
		this.PriceScroll = this.PriceCont.parent.GetComponent<CScrollRect>();
		if (this.CountdownFlag == 1)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 3);
			this.ShowUIVisible(this.bShowUI);
			this.DelayShow = 0f;
			this.PassInit = 2;
		}
		this.PriceTitleText.Init(child.GetChild(13).GetChild(4).GetChild(1).GetComponent<RectTransform>(), child.GetChild(13).GetChild(4).GetChild(0), 372.5f, ttffont);
		this.PriceTitleText.SetText(instance.mStringTable.GetStringByID(14506u));
		uibuttonHint = this.PriceTitleText.Button.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.ScrollID = 1;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = this.HintRect.gameObject;
		uibuttonHint.Parm1 = 14510;
		this.PriceGo = child.GetChild(12).gameObject;
		this.SummonPriceGo = child.GetChild(13).gameObject;
		this.SummonPriceTrans = child.GetChild(13).GetChild(3);
		GUIManager.Instance.InitianHeroItemImg(this.SummonPriceTrans, eHeroOrItem.Item, 0, 0, 0, 0, false, false, true, false);
		this.AnList = new AnimationUnit.AnimName[this.ANIndex.Length];
		this.MonsterAct = StringManager.Instance.SpawnString(30);
		this.MonsterAct.Append(AnimationUnit.ANIM_STRING[0]);
		this.IdleHash = this.MonsterAct.GetHashCode(false);
	}

	// Token: 0x06000C0B RID: 3083 RVA: 0x00115AEC File Offset: 0x00113CEC
	public override void OnClose()
	{
		this.MonsterDegree.Destroy();
		this.EnergyDegree.Destroy();
		StringManager.Instance.DeSpawnString(this.HurtStr);
		StringManager.Instance.DeSpawnString(this.LeftTimeStr);
		StringManager.Instance.DeSpawnString(this.CrusadeMStr);
		StringManager.Instance.DeSpawnString(this.UpperMessageStr);
		StringManager.Instance.DeSpawnString(this.CrusadeCostStr);
		StringManager.Instance.DeSpawnString(this.CrusadeMCostStr);
		StringManager.Instance.DeSpawnString(this.TimesStr);
		StringManager.Instance.DeSpawnString(this.DestTimeStr);
		StringManager.Instance.DeSpawnString(this.BoostsStr);
		StringManager.Instance.DeSpawnString(this.PositionStr);
		StringManager.Instance.DeSpawnString(this.MonsterLvStr);
		StringManager.Instance.DeSpawnString(this.ArrChatStr);
		StringManager.Instance.DeSpawnString(this.MonsterAct);
		StringManager.Instance.DeSpawnString(this.MonsterNameStr);
		if (this.MonsterGo != null)
		{
			this.MonsterGo.transform.SetParent(GUIManager.Instance.m_WindowsTransform);
			ModelLoader.Instance.Unload(this.MonsterGo);
		}
		if (this.AssetKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey, true);
		}
	}

	// Token: 0x06000C0C RID: 3084 RVA: 0x00115C50 File Offset: 0x00113E50
	public void OnDisable()
	{
		this.bShowUI = false;
	}

	// Token: 0x06000C0D RID: 3085 RVA: 0x00115C5C File Offset: 0x00113E5C
	public override void ReOnOpen()
	{
		this.bShowUI = true;
		this.ShowUIVisible(this.bShowUI);
		this.Set3Denvironment();
		if (this.MonsterGo != null && this.MonsterSkin == null)
		{
			this.MonsterSkin = this.MonsterGo.GetComponentInChildren<SkinnedMeshRenderer>();
			if (this.MonsterSkin != null)
			{
				this.MonsterSkin.useLightProbes = false;
			}
		}
		if (this.MonsterAN != null)
		{
			this.MonsterAN.enabled = false;
			this.MonsterAN.enabled = true;
		}
	}

	// Token: 0x06000C0E RID: 3086 RVA: 0x00115CFC File Offset: 0x00113EFC
	private void ShowUIVisible(bool bShow)
	{
		this.Panel2.SetActive(bShow);
		if (this.Panel2.activeSelf)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 3);
		}
		else
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 9);
		}
	}

	// Token: 0x06000C0F RID: 3087 RVA: 0x00115D48 File Offset: 0x00113F48
	private bool CheckValidMapID(int mapID)
	{
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[mapID];
		if (mapPoint.pointKind != 10)
		{
			return false;
		}
		this.MonsterPoint = DataManager.MapDataController.NPCPointTable[(int)mapPoint.tableID];
		this.UpdatePetStateHitMonterTimes();
		this.UpdateLeftHurtAddionalTime();
		return true;
	}

	// Token: 0x06000C10 RID: 3088 RVA: 0x00115DAC File Offset: 0x00113FAC
	public override void UpdateUI(int arg1, int arg2)
	{
		this.UpdatePetStateHitMonterTimes();
		this.CheckInit();
		this.UpdateData();
		this.UpdateTitle();
	}

	// Token: 0x06000C11 RID: 3089 RVA: 0x00115DC8 File Offset: 0x00113FC8
	public void UpdateData()
	{
		DataManager instance = DataManager.Instance;
		bool flag = false;
		ushort num = (ushort)(75 + this.MonsterPoint.level);
		uint monsterPoint = instance.RoleAttr.MonsterPoint;
		ushort needEnergy = this.GetNeedEnergy(this.MonsterPoint.level);
		this.ActionTimes = (int)((byte)(monsterPoint / (uint)needEnergy));
		byte b = 1;
		bool active = false;
		bool active2 = false;
		bool active3 = false;
		bool active4 = false;
		bool active5 = false;
		bool active6 = false;
		bool enabled = true;
		this.CrusadeCostText.color = this.CrusadeMCostText.color;
		byte btnID = 1;
		if (ActivityManager.Instance.IsInKvK(0, false))
		{
			if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID)
			{
				b = 0;
			}
		}
		else if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.kingdomData.kingdomID)
		{
			b = 0;
		}
		if (instance.RoleAlliance.Id == 0u)
		{
			this.UpperMessageText.text = instance.mStringTable.GetStringByID(8340u);
			this.FuncBtnText.text = instance.mStringTable.GetStringByID(4701u);
			this.FuncBtn.m_BtnID1 = 9;
			this.FuncBtnRect.sizeDelta = new Vector2(375f, 91f);
			this.FuncBtnRect.anchoredPosition = new Vector2(199.5f, -104.5f);
			active = (active5 = true);
		}
		else if (instance.GetTechLevel(num) == 0)
		{
			TechDataTbl recordByKey = instance.TechData.GetRecordByKey(num);
			this.UpperMessageStr.ClearString();
			this.UpperMessageStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey.TechName));
			this.UpperMessageStr.AppendFormat(instance.mStringTable.GetStringByID(8339u));
			this.UpperMessageText.text = this.UpperMessageStr.ToString();
			this.UpperMessageText.SetAllDirty();
			this.UpperMessageText.cachedTextGenerator.Invalidate();
			this.FuncBtnText.text = instance.mStringTable.GetStringByID(3776u);
			this.FuncBtn.m_BtnID1 = 8;
			this.FuncBtn.m_BtnID2 = (int)recordByKey.TechID;
			this.FuncBtnRect.sizeDelta = new Vector2(375f, 91f);
			this.FuncBtnRect.anchoredPosition = new Vector2(199.5f, -104.5f);
			active = (active5 = true);
		}
		else
		{
			for (byte b2 = 0; b2 < instance.MaxMarchEventNum; b2 += 1)
			{
				if (instance.MarchEventData[(int)b2].Type == EMarchEventType.EMET_HitMonsterMarching || instance.MarchEventData[(int)b2].Type == EMarchEventType.EMET_HitMonsterReturn || instance.MarchEventData[(int)b2].Type == EMarchEventType.EMET_HitMonsterRetreat)
				{
					flag = true;
					break;
				}
			}
			if (b == 0)
			{
				this.UpperMessageText.text = instance.mStringTable.GetStringByID(7744u);
				active = true;
			}
			else if (instance.RoleAttr.LastHitMonsterSerialNO != this.MonsterPoint.Key)
			{
				if (this.PetHitTimes == 0)
				{
					this.UpperMessageText.text = instance.mStringTable.GetStringByID(8334u);
					active = true;
				}
				else
				{
					this.UpdateTitle();
					active2 = true;
				}
			}
			else
			{
				this.UpdateTitle();
				active2 = true;
			}
			if (flag)
			{
				this.DownMessageText.text = instance.mStringTable.GetStringByID(8338u);
				active6 = true;
			}
			else if (monsterPoint < (uint)needEnergy)
			{
				btnID = 0;
				this.CrusadeCostText.color = this.DownMessageText.color;
				enabled = true;
				this.CrusadeCostStr.ClearString();
				this.CrusadeCostStr.IntToFormat((long)needEnergy, 1, true);
				this.CrusadeCostStr.AppendFormat("<color=#ff5a71ff>{0}</color>");
				this.CrusadeCostText.text = this.CrusadeCostStr.ToString();
				this.CrusadeCostText.SetAllDirty();
				this.CrusadeCostText.cachedTextGenerator.Invalidate();
				this.FuncBtnRect.sizeDelta = new Vector2(188f, 91f);
				this.FuncBtnRect.anchoredPosition = new Vector2(306f, -107.5f);
				this.FuncBtnText.text = instance.mStringTable.GetStringByID(8337u);
				this.FuncBtn.m_BtnID1 = 2;
				active5 = (active3 = true);
				if (b == 0)
				{
					enabled = false;
					this.CrusadeText.color = Color.gray;
				}
			}
			else if (this.ActionTimes == 1 || this.MonsterType == UIMapMonster.eMonsterType.ResourceMonster || this.MonsterType == UIMapMonster.eMonsterType.SummonMonster)
			{
				this.CrusadeCostStr.ClearString();
				this.CrusadeCostStr.IntToFormat((long)needEnergy, 1, true);
				this.CrusadeCostStr.AppendFormat("{0}");
				this.CrusadeCostText.text = this.CrusadeCostStr.ToString();
				this.CrusadeCostText.SetAllDirty();
				this.CrusadeCostText.cachedTextGenerator.Invalidate();
				if (b == 0)
				{
					enabled = false;
					this.CrusadeText.color = Color.gray;
				}
				this.FuncBtnRect.sizeDelta = new Vector2(188f, 91f);
				this.FuncBtnRect.anchoredPosition = new Vector2(306f, -107.5f);
				this.FuncBtnText.text = instance.mStringTable.GetStringByID(8337u);
				this.FuncBtn.m_BtnID1 = 2;
				active5 = (active3 = true);
			}
			else
			{
				this.CrusadeCostStr.ClearString();
				this.CrusadeCostStr.IntToFormat((long)needEnergy, 1, true);
				this.CrusadeCostStr.AppendFormat("{0}");
				this.CrusadeCostText.text = this.CrusadeCostStr.ToString();
				this.CrusadeCostText.SetAllDirty();
				this.CrusadeCostText.cachedTextGenerator.Invalidate();
				this.CrusadeMCostStr.ClearString();
				this.CrusadeMCostStr.IntToFormat((long)((int)needEnergy * this.ActionTimes), 1, true);
				this.CrusadeMCostStr.AppendFormat("{0}");
				this.CrusadeMCostText.text = this.CrusadeMCostStr.ToString();
				this.CrusadeMCostText.SetAllDirty();
				this.CrusadeMCostText.cachedTextGenerator.Invalidate();
				this.CrusadeMStr.ClearString();
				this.CrusadeMStr.IntToFormat((long)this.ActionTimes, 1, false);
				this.CrusadeMStr.AppendFormat(instance.mStringTable.GetStringByID(8336u));
				this.CrusadeMText.text = this.CrusadeMStr.ToString();
				this.CrusadeMText.SetAllDirty();
				this.CrusadeMText.cachedTextGenerator.Invalidate();
				active4 = (active3 = true);
				if (b == 0)
				{
					enabled = false;
					this.CrusadeMBtn.enabled = false;
					this.CrusadeText.color = Color.gray;
					this.CrusadeMText.color = Color.gray;
				}
			}
		}
		this.CrusadeBtn.m_BtnID3 = (int)btnID;
		this.CrusadeBtn.enabled = enabled;
		this.UpperMessageText.gameObject.SetActive(active);
		this.CrusadeTrans.gameObject.SetActive(active2);
		this.CrusadeBtn.gameObject.SetActive(active3);
		this.CrusadeMBtn.gameObject.SetActive(active4);
		this.FuncBtn.gameObject.SetActive(active5);
		this.DownMessageText.gameObject.SetActive(active6);
	}

	// Token: 0x06000C12 RID: 3090 RVA: 0x0011654C File Offset: 0x0011474C
	private void UpdateTitle()
	{
		DataManager instance = DataManager.Instance;
		int num;
		if (instance.RoleAttr.LastHitMonsterSerialNO != this.MonsterPoint.Key)
		{
			num = (int)this.PetHitTimes;
		}
		else
		{
			num = (int)(instance.RoleAttr.DamageRateForMonster + this.PetHitTimes);
		}
		uint num2 = 5u + DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MONSTERKILL_COMBOMAX);
		if ((long)num > (long)((ulong)num2))
		{
			num = (int)num2;
		}
		float f = (19.5f + (float)num * 0.5f) * (float)num * 0.5f + 4f;
		StringTable mStringTable = DataManager.Instance.mStringTable;
		this.TimesStr.ClearString();
		this.TimesStr.IntToFormat((long)num, 1, false);
		this.TimesStr.AppendFormat(mStringTable.GetStringByID(8331u));
		this.TimesText.text = this.TimesStr.ToString();
		this.TimesText.SetAllDirty();
		this.TimesText.cachedTextGenerator.Invalidate();
		this.HurtStr.ClearString();
		this.HurtStr.FloatToFormat(f, 2, false);
		if (GUIManager.Instance.IsArabic)
		{
			this.HurtStr.AppendFormat("%{0}");
		}
		else
		{
			this.HurtStr.AppendFormat("{0}%");
		}
		this.HurtText.text = this.HurtStr.ToString();
		this.HurtText.SetAllDirty();
		this.HurtText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000C13 RID: 3091 RVA: 0x001166C8 File Offset: 0x001148C8
	private void UpdateAttrib()
	{
		DataManager instance = DataManager.Instance;
		SoldierData recordByKey = instance.SoldierDataTable.GetRecordByKey(30);
		uint effectBaseVal = instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED);
		uint effectBaseVal2 = instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_HERO_MARCH_SPEED);
		uint effectBaseVal3 = instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_DEBUFF);
		uint effectBaseVal4 = instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_CURSE);
		float num = (10000f + effectBaseVal4) / (10000u + effectBaseVal2 + effectBaseVal - effectBaseVal3);
		float num2 = DataManager.MapDataController.CalcDistance(this.MonsterMapID, instance.RoleAttr.CapitalPoint, 0);
		uint num3 = GameConstants.appCeil(GameConstants.FastInvSqrt(num2 * num2) * ((float)recordByKey.Speed * num));
		this.DestTimeStr.ClearString();
		this.DestTimeStr.IntToFormat((long)((ulong)(num3 / 60u)), 2, false);
		this.DestTimeStr.IntToFormat((long)((ulong)(num3 % 60u)), 2, false);
		this.DestTimeStr.AppendFormat("{0} : {1}");
		this.DestTimeText.text = this.DestTimeStr.ToString();
		this.DestTimeText.SetAllDirty();
		this.DestTimeText.cachedTextGenerator.Invalidate();
		this.BoostsStr.ClearString();
		this.BoostsStr.StringToFormat(instance.mStringTable.GetStringByID(353u));
		this.BoostsStr.FloatToFormat((effectBaseVal2 + effectBaseVal - effectBaseVal3) / 100f, 2, false);
		this.BoostsStr.AppendFormat("{0}<color=#1BF568FF>{1}%</color>");
		this.BoostsText.text = this.BoostsStr.ToString();
		this.BoostsText.SetAllDirty();
		this.BoostsText.cachedTextGenerator.Invalidate();
		this.EnergyDegree.SetValue(instance.RoleAttr.MonsterPoint, this.maxRoleEnergy);
	}

	// Token: 0x06000C14 RID: 3092 RVA: 0x00116894 File Offset: 0x00114A94
	public void UpdateMonster()
	{
		DataManager instance = DataManager.Instance;
		MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.MonsterPoint.NPCNum);
		CString cstring = StringManager.Instance.StaticString1024();
		this.HeroID = recordByKey.ModelID;
		this.Modle = instance.HeroTable.GetRecordByKey(this.HeroID).Modle;
		cstring.IntToFormat((long)this.Modle, 5, false);
		cstring.AppendFormat("Role/hero_{0}");
		if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, this.Modle, true))
		{
			this.AB = AssetManager.GetAssetBundle(cstring, out this.AssetKey);
			if (this.AB != null)
			{
				this.AR = this.AB.LoadAsync("m", typeof(GameObject));
			}
		}
		if (this.MonsterPoint.NPCAllianceTag.Length > 0 && this.MonsterPoint.NPCAllianceTag[0] != '0')
		{
			this.MonsterType = UIMapMonster.eMonsterType.SummonMonster;
		}
		else if (DataManager.MapDataController.GetMonsterType(this.MonsterPoint.NPCNum) == 1)
		{
			this.MonsterType = UIMapMonster.eMonsterType.ResourceMonster;
		}
		if (this.MonsterType == UIMapMonster.eMonsterType.SummonMonster)
		{
			this.MonsterNameStr.ClearString();
			if (GUIManager.Instance.IsArabic)
			{
				this.MonsterNameStr.Append(instance.mStringTable.GetStringByID((uint)recordByKey.NameID));
				this.MonsterNameStr.StringToFormat(this.MonsterPoint.NPCAllianceTag);
				this.MonsterNameStr.AppendFormat("[{0}]");
			}
			else
			{
				this.MonsterNameStr.StringToFormat(this.MonsterPoint.NPCAllianceTag);
				this.MonsterNameStr.AppendFormat("[{0}]");
				this.MonsterNameStr.Append(instance.mStringTable.GetStringByID((uint)recordByKey.NameID));
			}
			this.MonsterNameText.text = this.MonsterNameStr.ToString();
			this.MonsterNameText.SetAllDirty();
			this.MonsterNameText.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.MonsterNameStr.ClearString();
			this.MonsterNameStr.Append(instance.mStringTable.GetStringByID((uint)recordByKey.NameID));
			this.MonsterNameText.text = this.MonsterNameStr.ToString();
			this.MonsterNameText.SetAllDirty();
			this.MonsterNameText.cachedTextGenerator.Invalidate();
		}
		this.MonsterDegree.SetValue(this.MonsterPoint.Blood);
		Vector2 tileMapPosbySpriteID = GameConstants.getTileMapPosbySpriteID(this.MonsterMapID);
		this.PositionStr.ClearString();
		this.PositionStr.StringToFormat(instance.mStringTable.GetStringByID(4504u));
		this.PositionStr.IntToFormat((long)DataManager.MapDataController.FocusKingdomID, 1, false);
		this.PositionStr.StringToFormat(instance.mStringTable.GetStringByID(4505u));
		this.PositionStr.IntToFormat((long)((int)tileMapPosbySpriteID.x), 1, false);
		this.PositionStr.StringToFormat(instance.mStringTable.GetStringByID(4506u));
		this.PositionStr.IntToFormat((long)((int)tileMapPosbySpriteID.y), 1, false);
		if (GUIManager.Instance.IsArabic)
		{
			this.PositionStr.AppendFormat("{5}{4} {3}{2} {1}{0}");
		}
		else
		{
			this.PositionStr.AppendFormat("{0}{1} {2}{3} {4}{5}");
		}
		this.MonsterPositionText.text = this.PositionStr.ToString();
		this.MonsterPositionText.SetAllDirty();
		this.MonsterPositionText.cachedTextGenerator.Invalidate();
		this.ArrChatStr.ClearString();
		this.ArrChatStr.StringToFormat(this.MonsterNameStr.ToString());
		this.ArrChatStr.StringToFormat(instance.mStringTable.GetStringByID(4504u));
		this.ArrChatStr.IntToFormat((long)DataManager.MapDataController.FocusKingdomID, 1, false);
		this.ArrChatStr.StringToFormat(instance.mStringTable.GetStringByID(4505u));
		this.ArrChatStr.IntToFormat((long)((int)tileMapPosbySpriteID.x), 1, false);
		this.ArrChatStr.StringToFormat(instance.mStringTable.GetStringByID(4506u));
		this.ArrChatStr.IntToFormat((long)((int)tileMapPosbySpriteID.y), 1, false);
		if (GUIManager.Instance.IsArabic)
		{
			this.ArrChatStr.AppendFormat("{0} {2}{1} {4}{3} {6}{5}");
		}
		else
		{
			this.ArrChatStr.AppendFormat("{0} {1}{2} {3}{4} {5}{6}");
		}
		this.MonsterLvStr.ClearString();
		this.MonsterLvStr.IntToFormat((long)this.MonsterPoint.level, 1, false);
		this.MonsterLvStr.AppendFormat("{0}");
		this.MonsterLvText.text = this.MonsterLvStr.ToString();
		this.MonsterLvText.SetAllDirty();
		this.MonsterLvText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000C15 RID: 3093 RVA: 0x00116D90 File Offset: 0x00114F90
	private void UpdateLeftHurtAddionalTime()
	{
		DataManager instance = DataManager.Instance;
		if (instance.RoleAttr.LastHitMonsterSerialNO == this.MonsterPoint.Key)
		{
			long num = instance.RoleAttr.LastHitMonsterTime + 3600L - instance.ServerTime;
			if (num <= 0L)
			{
				instance.RoleAttr.DamageRateForMonster = 0;
				instance.RoleAttr.LastHitMonsterSerialNO = 0u;
				this.UpdateData();
			}
			else
			{
				this.LeftTimeStr.ClearString();
				this.LeftTimeStr.IntToFormat(num / 60L, 2, false);
				this.LeftTimeStr.IntToFormat(num % 60L, 2, false);
				this.LeftTimeStr.AppendFormat("{0} : {1}");
				this.LeftTimeText.text = this.LeftTimeStr.ToString();
				this.LeftTimeText.SetAllDirty();
				this.LeftTimeText.cachedTextGenerator.Invalidate();
			}
		}
		else if (this.PetHitTimes > 0)
		{
			this.LeftTimeText.text = "-";
		}
	}

	// Token: 0x06000C16 RID: 3094 RVA: 0x00116E98 File Offset: 0x00115098
	private ushort GetNeedEnergy(byte MonsterLv)
	{
		if (this.MonsterType == UIMapMonster.eMonsterType.ResourceMonster || this.MonsterType == UIMapMonster.eMonsterType.SummonMonster)
		{
			return 1;
		}
		uint num = 1u;
		switch (MonsterLv)
		{
		case 1:
			num = 3000u;
			break;
		case 2:
			num = 5000u;
			break;
		case 3:
			num = 8000u;
			break;
		case 4:
			num = 14000u;
			break;
		case 5:
			num = 18000u;
			break;
		}
		num -= num * DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MONSTERPOINT_COST_REDUCTION) / 10000u;
		return (ushort)num;
	}

	// Token: 0x06000C17 RID: 3095 RVA: 0x00116F3C File Offset: 0x0011513C
	private void CheckInit()
	{
		if (this.PassInit <= 0)
		{
			return;
		}
		this.PassInit = 0;
		GUIManager instance = GUIManager.Instance;
		UIButtonHint.scrollRect = this.PriceScroll;
		for (byte b = 0; b < 8; b += 1)
		{
			instance.InitianHeroItemImg(this.PriceCont.GetChild(0).GetChild(0).GetChild((int)b), eHeroOrItem.Item, 0, 0, 0, 0, true, true, true, false);
			this.AddRefreshText(this.PriceCont.GetChild(0).GetChild(0).GetChild((int)b).GetChild(4).GetComponent<UIText>());
		}
		for (byte b2 = 0; b2 < 8; b2 += 1)
		{
			instance.InitLordEquipImg(this.PriceCont.GetChild(0).GetChild(1).GetChild((int)b2), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
			this.PriceCont.GetChild(0).GetChild(1).GetChild((int)b2).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
		}
		if (!this.CheckValidMapID(this.MonsterMapID))
		{
			Door door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
			door.CloseMenu(false);
			return;
		}
		if (this.CountdownFlag == 0)
		{
			Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			GUIWindowStackData value = door2.m_WindowStack[door2.m_WindowStack.Count - 1];
			value.m_Arg2 = 1;
			door2.m_WindowStack[door2.m_WindowStack.Count - 1] = value;
		}
		else
		{
			this.DelayShow = 0f;
		}
		if (this.DelayShow <= 0f)
		{
			this.PassInit = -1;
			this.ShowUIVisible(this.bShowUI);
			this.Set3Denvironment();
		}
		this.UpdateMonster();
		if (this.MonsterType != UIMapMonster.eMonsterType.SummonMonster)
		{
			this.InitPrice();
		}
		else
		{
			this.InitSummonPrice();
		}
		this.UpdateData();
		this.UpdateAttrib();
	}

	// Token: 0x06000C18 RID: 3096 RVA: 0x00117128 File Offset: 0x00115328
	private void Set3Denvironment()
	{
		DataManager.msgBuffer[0] = 84;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		GUIManager.Instance.m_UICanvas.renderMode = RenderMode.ScreenSpaceCamera;
		GUIManager.Instance.SetCanvasChanged();
	}

	// Token: 0x06000C19 RID: 3097 RVA: 0x0011715C File Offset: 0x0011535C
	private void InitPrice()
	{
		this.PriceGo.SetActive(true);
		DataManager instance = DataManager.Instance;
		byte b = 0;
		MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.MonsterPoint.NPCNum);
		if (this.MonsterPoint.level == 0)
		{
			return;
		}
		MapMonsterPrice recordByKey2 = DataManager.MapDataController.MapMonsterPriceTable.GetRecordByKey(recordByKey.MapTeamInfo[(int)(this.MonsterPoint.level - 1)].ItemGroup);
		if ((ActivityManager.Instance.bSpecialMonsterTreasureEvent & 1UL) > 0UL && recordByKey2.SpecItemID > 0)
		{
			Equip recordByKey3 = instance.EquipTable.GetRecordByKey(recordByKey2.SpecItemID);
			if (!GUIManager.Instance.IsLeadItem(recordByKey3.EquipKind))
			{
				GUIManager.Instance.ChangeHeroItemImg(this.PriceCont.GetChild(0).GetChild(0).GetChild((int)b), eHeroOrItem.Item, recordByKey2.SpecItemID, 0, 0, 0);
				this.PriceCont.GetChild(0).GetChild(0).GetChild((int)b).gameObject.SetActive(true);
			}
			else
			{
				GUIManager.Instance.ChangeLordEquipImg(this.PriceCont.GetChild(0).GetChild(1).GetChild((int)b), recordByKey2.SpecItemID, this.MonsterPoint.level, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				this.PriceCont.GetChild(0).GetChild(1).GetChild((int)b).gameObject.SetActive(true);
			}
			b += 1;
		}
		for (int i = 0; i < recordByKey2.ItemID.Length; i++)
		{
			if (recordByKey2.ItemID[i] != 0)
			{
				Equip recordByKey3 = instance.EquipTable.GetRecordByKey(recordByKey2.ItemID[i]);
				if (!GUIManager.Instance.IsLeadItem(recordByKey3.EquipKind))
				{
					UIHIBtn component;
					if ((int)b < this.PriceCont.GetChild(0).GetChild(0).childCount)
					{
						GUIManager.Instance.ChangeHeroItemImg(this.PriceCont.GetChild(0).GetChild(0).GetChild((int)b), eHeroOrItem.Item, recordByKey2.ItemID[i], 0, 0, 0);
						this.PriceCont.GetChild(0).GetChild(0).GetChild((int)b).gameObject.SetActive(true);
						component = this.PriceCont.GetChild(0).GetChild(0).GetChild((int)b).GetComponent<UIHIBtn>();
					}
					else
					{
						RectTransform rectTransform = UnityEngine.Object.Instantiate(this.PriceCont.GetChild(0).GetChild(0).GetChild(0)) as RectTransform;
						rectTransform.SetParent(this.PriceCont.GetChild(0).GetChild(0));
						rectTransform.anchoredPosition3D = new Vector3(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y, 0f);
						Quaternion localRotation = rectTransform.localRotation;
						localRotation.eulerAngles = Vector3.zero;
						rectTransform.localRotation = localRotation;
						rectTransform.localScale = Vector3.one;
						rectTransform.anchoredPosition = new Vector2((float)(36 + 74 * b), -37f);
						rectTransform.gameObject.SetActive(true);
						GUIManager.Instance.ChangeHeroItemImg(rectTransform, eHeroOrItem.Item, recordByKey2.ItemID[i], 0, 0, 0);
						this.AddRefreshText(rectTransform.GetChild(4).GetComponent<UIText>());
						component = rectTransform.GetComponent<UIHIBtn>();
						component.GetComponent<UIButtonHint>().enabled = true;
						GUIManager.Instance.SetItemScaleClickSound(component, false, true);
					}
					EItemType eitemType = (EItemType)(recordByKey3.EquipKind - 1);
					if (eitemType == EItemType.EIT_ComboTreasureBox || (eitemType == EItemType.EIT_MaterialTreasureBox && recordByKey3.PropertiesInfo[0].Propertieskey == 4) || (eitemType == EItemType.EIT_MaterialTreasureBox && (recordByKey3.PropertiesInfo[2].Propertieskey < 1 || recordByKey3.PropertiesInfo[2].Propertieskey > 3)))
					{
						component.m_BtnID2 = (int)recordByKey3.EquipKey;
						component.m_Handler = this;
						component.GetComponent<UIButtonHint>().enabled = false;
						EventPatchery component2 = component.gameObject.GetComponent<EventPatchery>();
						if (component2 == null)
						{
							component.gameObject.AddComponent<EventPatchery>().SetEvnetObj(this.PriceScroll);
						}
						else
						{
							component2.SetEvnetObj(this.PriceScroll);
						}
						GUIManager.Instance.SetItemScaleClickSound(component, true, true);
					}
				}
				else if ((int)b < this.PriceCont.GetChild(0).GetChild(1).childCount)
				{
					GUIManager.Instance.ChangeLordEquipImg(this.PriceCont.GetChild(0).GetChild(1).GetChild((int)b), recordByKey2.ItemID[i], this.MonsterPoint.level, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
					this.PriceCont.GetChild(0).GetChild(1).GetChild((int)b).gameObject.SetActive(true);
				}
				else
				{
					RectTransform rectTransform = UnityEngine.Object.Instantiate(this.PriceCont.GetChild(0).GetChild(1).GetChild(0)) as RectTransform;
					rectTransform.SetParent(this.PriceCont.GetChild(0).GetChild(1));
					rectTransform.anchoredPosition3D = new Vector3(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.y, 0f);
					Quaternion localRotation2 = rectTransform.localRotation;
					localRotation2.eulerAngles = Vector3.zero;
					rectTransform.localRotation = localRotation2;
					rectTransform.localScale = Vector3.one;
					rectTransform.anchoredPosition = new Vector2((float)(36 + 74 * b), -37f);
					rectTransform.gameObject.SetActive(true);
					GUIManager.Instance.ChangeLordEquipImg(rectTransform, recordByKey2.ItemID[i], this.MonsterPoint.level, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				}
				b += 1;
			}
		}
		float num = 4f + 74f * (float)b;
		if (this.PriceCont.sizeDelta.x < num)
		{
			Vector2 sizeDelta = this.PriceCont.sizeDelta;
			sizeDelta.x = num + 4f;
			this.PriceCont.sizeDelta = sizeDelta;
		}
		else
		{
			this.PriceScroll.enabled = false;
		}
	}

	// Token: 0x06000C1A RID: 3098 RVA: 0x00117788 File Offset: 0x00115988
	private void InitSummonPrice()
	{
		this.SummonPriceGo.SetActive(true);
		MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.MonsterPoint.NPCNum);
		if (this.MonsterPoint.level == 0)
		{
			return;
		}
		GUIManager.Instance.ChangeHeroItemImg(this.SummonPriceTrans, eHeroOrItem.Item, recordByKey.MapTeamInfo[(int)(this.MonsterPoint.level - 1)].AllianceItem, 0, 0, 0);
		UIHIBtn component = this.SummonPriceTrans.GetComponent<UIHIBtn>();
		component.m_Handler = this;
		component.m_BtnID2 = (int)recordByKey.MapTeamInfo[(int)(this.MonsterPoint.level - 1)].AllianceItem;
	}

	// Token: 0x06000C1B RID: 3099 RVA: 0x00117838 File Offset: 0x00115A38
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.DelayShow > 0f)
		{
			this.DelayShow -= Time.deltaTime;
		}
		if (this.PassInit > 0)
		{
			this.PassInit -= 1;
			if (this.PassInit == 1)
			{
				this.CheckInit();
			}
			return;
		}
		if (bOnSecond)
		{
			this.UpdateLeftHurtAddionalTime();
		}
		if (this.DelayShow <= 0f && !this.bABInitial && this.AR != null && this.AR.isDone)
		{
			if (this.PassInit == 0)
			{
				this.ShowUIVisible(this.bShowUI);
			}
			this.Set3Denvironment();
			Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.HeroID);
			this.bABInitial = true;
			this.MonsterGo = ModelLoader.Instance.Load(recordByKey.Modle, this.AB, (ushort)recordByKey.TextureNo);
			this.MonsterGo.transform.SetParent(this.MonsterTrans, false);
			if (recordByKey.Camera_Horizontal == 0)
			{
				this.MonsterGo.transform.localRotation = new Quaternion(0f, -180f, 0f, 0f);
			}
			else
			{
				Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
				localRotation.eulerAngles = new Vector3(0f, (float)recordByKey.Camera_Horizontal, 0f);
				this.MonsterGo.transform.localRotation = localRotation;
			}
			this.MonsterGo.transform.localScale = new Vector3((float)recordByKey.CameraScaleRate, (float)recordByKey.CameraScaleRate, (float)recordByKey.CameraScaleRate);
			GUIManager.Instance.SetLayer(this.MonsterGo, 5);
			if (this.MonsterGo != null)
			{
				this.MonsterAN = this.MonsterGo.GetComponent<Animation>();
				this.MonsterAN.wrapMode = WrapMode.Loop;
				this.MonsterAN.cullingType = AnimationCullingType.AlwaysAnimate;
				for (int i = 0; i < this.ANIndex.Length; i++)
				{
					byte b = (byte)this.ANIndex[i];
					if (this.MonsterAN.GetClip(AnimationUnit.ANIM_STRING[(int)b]) != null)
					{
						this.MonsterAN[AnimationUnit.ANIM_STRING[(int)b]].layer = 1;
						this.MonsterAN[AnimationUnit.ANIM_STRING[(int)b]].wrapMode = WrapMode.Once;
						this.AnList[i] = this.ANIndex[i];
					}
				}
				this.MonsterAN.clip = this.MonsterAN.GetClip(this.MonsterAct.ToString());
				this.MonsterAN.Play(this.MonsterAct.ToString());
				this.MonsterSkin = this.MonsterGo.GetComponentInChildren<SkinnedMeshRenderer>();
				if (this.MonsterSkin != null)
				{
					this.MonsterSkin.useLightProbes = false;
				}
			}
		}
		else if (this.DelayShow <= 0f && this.PassInit == 0)
		{
			this.PassInit = -1;
			this.ShowUIVisible(this.bShowUI);
			this.Set3Denvironment();
		}
		if (this.Panel2.activeSelf && this.MonsterGo != null)
		{
			this.MonsterAN = this.MonsterGo.GetComponent<Animation>();
			if ((!this.MonsterAN.IsPlaying(this.MonsterAct.ToString()) || this.MonsterAct.GetHashCode(false) == this.IdleHash) && this.ActionTimeRandom < 0.0001f)
			{
				this.ActionTimeRandom = (float)UnityEngine.Random.Range(3, 7);
				this.ActionTime = 0f;
			}
			if (this.ActionTimeRandom > 0.0001f)
			{
				this.ActionTime += Time.smoothDeltaTime;
				if (this.ActionTime >= this.ActionTimeRandom)
				{
					this.MonsterActionChang();
				}
			}
		}
		if (bOnSecond && DataManager.Instance.RoleAttr.MonsterPoint == this.maxRoleEnergy)
		{
			this.UpdateData();
		}
	}

	// Token: 0x06000C1C RID: 3100 RVA: 0x00117C54 File Offset: 0x00115E54
	public void MonsterActionChang()
	{
		if (this.MonsterGo == null)
		{
			return;
		}
		int num = UnityEngine.Random.Range(0, this.AnList.Length);
		this.MonsterAct.ClearString();
		this.MonsterAct.Append(AnimationUnit.ANIM_STRING[(int)this.AnList[num]]);
		AnimationClip animationClip = this.MonsterAN.GetClip(this.MonsterAct.ToString());
		if (this.AnList[num] == AnimationUnit.AnimName.SKILL1)
		{
			this.MonsterAct.Append("_ch");
			AnimationClip clip = this.MonsterAN.GetClip(this.MonsterAct.ToString());
			if (clip != null)
			{
				animationClip = null;
			}
		}
		if (animationClip != null)
		{
			this.MonsterAN.CrossFade(animationClip.name);
		}
		this.ActionTimeRandom = 0f;
		this.ActionTime = 0f;
	}

	// Token: 0x06000C1D RID: 3101 RVA: 0x00117D34 File Offset: 0x00115F34
	public void UpdatePetStateHitMonterTimes()
	{
		this.PetHitTimes = 0;
		PetManager instance = PetManager.Instance;
		List<PSBuffInfoData> buffInfo = instance.BuffInfo;
		for (int i = 0; i < buffInfo.Count; i++)
		{
			if (buffInfo[i].SkillID != 0 && buffInfo[i].Level != 0)
			{
				PetSkillTbl recordByKey = instance.PetSkillTable.GetRecordByKey(buffInfo[i].SkillID);
				if (recordByKey.Kind == 19)
				{
					this.PetHitTimes += (byte)instance.PetSkillValTable.GetRecordByKey(recordByKey.XValue).EffectBySkillLv[(int)(buffInfo[i].Level - 1)];
				}
			}
		}
	}

	// Token: 0x06000C1E RID: 3102 RVA: 0x00117E08 File Offset: 0x00116008
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.CloseMenu(false);
			break;
		}
		default:
			if (networkNews != NetworkNews.Refresh_MonsterPoint)
			{
				if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
				{
					if (networkNews == NetworkNews.Refresh_AttribEffectVal)
					{
						this.maxRoleEnergy = DataManager.Instance.GetMaxMonsterPoint();
					}
				}
				else
				{
					for (int i = 0; i < this.RefreshTextArray.Count; i++)
					{
						if (this.RefreshTextArray[i] != null && this.RefreshTextArray[i].enabled)
						{
							this.RefreshTextArray[i].enabled = false;
							this.RefreshTextArray[i].enabled = true;
						}
					}
					this.PriceTitleText.TextRefresh();
				}
			}
			else
			{
				this.UpdateAttrib();
				this.UpdateData();
			}
			break;
		case NetworkNews.Refresh_Asset:
			if (meg[1] == 1 && meg[2] == 2 && GameConstants.ConvertBytesToUShort(meg, 3) == this.Modle && this.AB == null)
			{
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.IntToFormat((long)this.Modle, 5, false);
				cstring.AppendFormat("Role/hero_{0}");
				this.AB = AssetManager.GetAssetBundle(cstring, out this.AssetKey);
				if (this.AB != null)
				{
					this.AR = this.AB.LoadAsync("m", typeof(GameObject));
				}
			}
			break;
		}
	}

	// Token: 0x06000C1F RID: 3103 RVA: 0x00117FB0 File Offset: 0x001161B0
	public void OnButtonClick(UIButton sender)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		StringTable mStringTable = DataManager.Instance.mStringTable;
		switch (sender.m_BtnID1)
		{
		case 0:
			door.OpenMenu(EGUIWindow.UI_MonsterInfo, (int)this.MonsterPoint.NPCNum, (int)this.MonsterType, false);
			break;
		case 1:
			door.CloseMenu(false);
			door.m_GroundInfo.OpenMonsterBookmarksPanel(true, this.MonsterMapID);
			break;
		case 2:
			GUIManager.Instance.OpenItemKindFilterUI(10, 30, 0);
			break;
		case 3:
		{
			this.ShowUIVisible(false);
			door.OpenMenu(EGUIWindow.UI_Chat, (int)(GUIManager.Instance.ChannelIndex + 1), 0, false);
			UIChat uichat = (UIChat)GUIManager.Instance.FindMenu(EGUIWindow.UI_Chat);
			uichat.SetInputText(this.ArrChatStr.ToString());
			break;
		}
		case 4:
			door.CloseMenu(false);
			break;
		case 5:
			if (sender.m_BtnID3 == 0)
			{
				GUIManager.Instance.AddHUDMessage(mStringTable.GetStringByID(8344u), 255, true);
			}
			else
			{
				Vector2 tileMapPosbySpriteID = GameConstants.getTileMapPosbySpriteID(this.MonsterMapID);
				if (DataManager.MapDataController.CheckLenght(tileMapPosbySpriteID) == 0f)
				{
					GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(3967u), mStringTable.GetStringByID(119u), mStringTable.GetStringByID(4034u), null, 0, 0, false, false, false, false, false);
				}
				else
				{
					door.OpenMenu(EGUIWindow.UI_BattleHeroSelect, this.MonsterMapID, 1, true);
				}
			}
			break;
		case 6:
		{
			Vector2 tileMapPosbySpriteID2 = GameConstants.getTileMapPosbySpriteID(this.MonsterMapID);
			if (DataManager.MapDataController.CheckLenght(tileMapPosbySpriteID2) == 0f)
			{
				GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(3967u), mStringTable.GetStringByID(119u), mStringTable.GetStringByID(4034u), null, 0, 0, false, false, false, false, false);
			}
			else
			{
				door.OpenMenu(EGUIWindow.UI_BattleHeroSelect, this.MonsterMapID, this.ActionTimes, true);
			}
			break;
		}
		case 8:
			GUIManager.Instance.OpenTechTree((ushort)sender.m_BtnID2, false);
			break;
		case 9:
			DataManager.Instance.SetSelectRequest = 0;
			door.OpenMenu(EGUIWindow.UI_AllianceHint, 0, 0, false);
			break;
		}
	}

	// Token: 0x06000C20 RID: 3104 RVA: 0x001181F4 File Offset: 0x001163F4
	public void OnButtonDown(UIButtonHint sender)
	{
		this.HintText.text = DataManager.Instance.mStringTable.GetStringByID((uint)sender.Parm1);
		Vector2 sizeDelta = this.HintRect.sizeDelta;
		sizeDelta.y = this.HintText.preferredHeight + 16f;
		this.HintRect.sizeDelta = sizeDelta;
		sender.GetTipPosition(this.HintRect, UIButtonHint.ePosition.Original, null);
		this.HintRect.gameObject.SetActive(true);
		AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
	}

	// Token: 0x06000C21 RID: 3105 RVA: 0x00118284 File Offset: 0x00116484
	public void OnButtonUp(UIButtonHint sender)
	{
		this.HintRect.gameObject.SetActive(false);
	}

	// Token: 0x06000C22 RID: 3106 RVA: 0x00118298 File Offset: 0x00116498
	public void AddRefreshText(UIText text)
	{
		this.RefreshTextArray.Add(text);
	}

	// Token: 0x040027A3 RID: 10147
	private Transform CrusadeTrans;

	// Token: 0x040027A4 RID: 10148
	private Transform MonsterTrans;

	// Token: 0x040027A5 RID: 10149
	private Transform SummonPriceTrans;

	// Token: 0x040027A6 RID: 10150
	private RectTransform PriceCont;

	// Token: 0x040027A7 RID: 10151
	private RectTransform FuncBtnRect;

	// Token: 0x040027A8 RID: 10152
	private RectTransform HintRect;

	// Token: 0x040027A9 RID: 10153
	private UIMapMonster.DegreeBar MonsterDegree;

	// Token: 0x040027AA RID: 10154
	private UIMapMonster.DegreeBar EnergyDegree;

	// Token: 0x040027AB RID: 10155
	private UIText UpperMessageText;

	// Token: 0x040027AC RID: 10156
	private UIText TimesText;

	// Token: 0x040027AD RID: 10157
	private UIText HurtText;

	// Token: 0x040027AE RID: 10158
	private UIText LeftTimeText;

	// Token: 0x040027AF RID: 10159
	private UIText DestTimeText;

	// Token: 0x040027B0 RID: 10160
	private UIText BoostsText;

	// Token: 0x040027B1 RID: 10161
	private UIText CrusadeText;

	// Token: 0x040027B2 RID: 10162
	private UIText CrusadeMText;

	// Token: 0x040027B3 RID: 10163
	private UIText CrusadeCostText;

	// Token: 0x040027B4 RID: 10164
	private UIText CrusadeMCostText;

	// Token: 0x040027B5 RID: 10165
	private UIText FuncBtnText;

	// Token: 0x040027B6 RID: 10166
	private UIText DownMessageText;

	// Token: 0x040027B7 RID: 10167
	private UIText MonsterNameText;

	// Token: 0x040027B8 RID: 10168
	private UIText MonsterPositionText;

	// Token: 0x040027B9 RID: 10169
	private UIText MonsterLvText;

	// Token: 0x040027BA RID: 10170
	private UIText HintText;

	// Token: 0x040027BB RID: 10171
	private UIButton FuncBtn;

	// Token: 0x040027BC RID: 10172
	private UIButton CrusadeBtn;

	// Token: 0x040027BD RID: 10173
	private UIButton CrusadeMBtn;

	// Token: 0x040027BE RID: 10174
	private CString TimesStr;

	// Token: 0x040027BF RID: 10175
	private CString HurtStr;

	// Token: 0x040027C0 RID: 10176
	private CString LeftTimeStr;

	// Token: 0x040027C1 RID: 10177
	private CString CrusadeMStr;

	// Token: 0x040027C2 RID: 10178
	private CString UpperMessageStr;

	// Token: 0x040027C3 RID: 10179
	private CString CrusadeCostStr;

	// Token: 0x040027C4 RID: 10180
	private CString CrusadeMCostStr;

	// Token: 0x040027C5 RID: 10181
	private CString DestTimeStr;

	// Token: 0x040027C6 RID: 10182
	private CString BoostsStr;

	// Token: 0x040027C7 RID: 10183
	private CString PositionStr;

	// Token: 0x040027C8 RID: 10184
	private CString MonsterLvStr;

	// Token: 0x040027C9 RID: 10185
	private CString ArrChatStr;

	// Token: 0x040027CA RID: 10186
	private CString MonsterNameStr;

	// Token: 0x040027CB RID: 10187
	private CScrollRect PriceScroll;

	// Token: 0x040027CC RID: 10188
	private GameObject Panel2;

	// Token: 0x040027CD RID: 10189
	private SkinnedMeshRenderer MonsterSkin;

	// Token: 0x040027CE RID: 10190
	private NPCPoint MonsterPoint;

	// Token: 0x040027CF RID: 10191
	private AssetBundle AB;

	// Token: 0x040027D0 RID: 10192
	private AssetBundleRequest AR;

	// Token: 0x040027D1 RID: 10193
	private ushort HeroID;

	// Token: 0x040027D2 RID: 10194
	private ushort Modle;

	// Token: 0x040027D3 RID: 10195
	private int AssetKey;

	// Token: 0x040027D4 RID: 10196
	private int MonsterMapID;

	// Token: 0x040027D5 RID: 10197
	private int ActionTimes;

	// Token: 0x040027D6 RID: 10198
	private int CountdownFlag;

	// Token: 0x040027D7 RID: 10199
	private bool bABInitial;

	// Token: 0x040027D8 RID: 10200
	private GameObject MonsterGo;

	// Token: 0x040027D9 RID: 10201
	private GameObject PriceGo;

	// Token: 0x040027DA RID: 10202
	private GameObject SummonPriceGo;

	// Token: 0x040027DB RID: 10203
	private float DelayShow = 0.2f;

	// Token: 0x040027DC RID: 10204
	private List<UIText> RefreshTextArray = new List<UIText>();

	// Token: 0x040027DD RID: 10205
	private UIMapMonster.eMonsterType MonsterType;

	// Token: 0x040027DE RID: 10206
	private Animation MonsterAN;

	// Token: 0x040027DF RID: 10207
	private CString MonsterAct;

	// Token: 0x040027E0 RID: 10208
	private int IdleHash;

	// Token: 0x040027E1 RID: 10209
	private float ActionTime;

	// Token: 0x040027E2 RID: 10210
	private float ActionTimeRandom;

	// Token: 0x040027E3 RID: 10211
	private AnimationUnit.AnimName[] ANIndex = new AnimationUnit.AnimName[]
	{
		AnimationUnit.AnimName.ATTACK,
		AnimationUnit.AnimName.SKILL1,
		AnimationUnit.AnimName.SKILL2,
		AnimationUnit.AnimName.SKILL3,
		AnimationUnit.AnimName.VICTORY
	};

	// Token: 0x040027E4 RID: 10212
	private AnimationUnit.AnimName[] AnList;

	// Token: 0x040027E5 RID: 10213
	private uint maxRoleEnergy;

	// Token: 0x040027E6 RID: 10214
	private byte PetHitTimes;

	// Token: 0x040027E7 RID: 10215
	private short PassInit = 3;

	// Token: 0x040027E8 RID: 10216
	private bool bShowUI = true;

	// Token: 0x040027E9 RID: 10217
	private UISummonMonster._TextUnderLine PriceTitleText;

	// Token: 0x02000277 RID: 631
	private struct DegreeBar
	{
		// Token: 0x06000C23 RID: 3107 RVA: 0x001182A8 File Offset: 0x001164A8
		public void Init(Transform transform, ushort MaxWidth)
		{
			this.BloodTran = transform.GetChild(0).GetComponent<RectTransform>();
			this.TitleText = transform.GetChild(1).GetComponent<UIText>();
			this.TitleText.font = GUIManager.Instance.GetTTFFont();
			this.TitleStr = StringManager.Instance.SpawnString(30);
			this.BloodWidth = (float)MaxWidth;
		}

		// Token: 0x06000C24 RID: 3108 RVA: 0x00118308 File Offset: 0x00116508
		public void SetValue(float Percentage)
		{
			float x = this.BloodWidth * Percentage * 0.01f;
			Vector2 sizeDelta = this.BloodTran.sizeDelta;
			sizeDelta.x = x;
			this.BloodTran.sizeDelta = sizeDelta;
			this.TitleStr.ClearString();
			if (Percentage > 0.01f)
			{
				this.TitleStr.FloatToFormat(Percentage, 2, false);
			}
			else
			{
				this.TitleStr.StringToFormat("0.01");
			}
			if (GUIManager.Instance.IsArabic)
			{
				this.TitleStr.AppendFormat("%{0}");
			}
			else
			{
				this.TitleStr.AppendFormat("{0}%");
			}
			this.TitleText.text = this.TitleStr.ToString();
			this.TitleText.SetAllDirty();
			this.TitleText.cachedTextGenerator.Invalidate();
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x001183E4 File Offset: 0x001165E4
		public void SetValue(uint NowVal, uint MaxVal)
		{
			float x = NowVal * (this.BloodWidth / MaxVal);
			Vector2 sizeDelta = this.BloodTran.sizeDelta;
			sizeDelta.x = x;
			this.BloodTran.sizeDelta = sizeDelta;
			this.TitleStr.ClearString();
			this.TitleStr.IntToFormat((long)((ulong)NowVal), 1, true);
			this.TitleStr.IntToFormat((long)((ulong)MaxVal), 1, true);
			if (GUIManager.Instance.IsArabic)
			{
				this.TitleStr.AppendFormat("{1} / {0}");
			}
			else
			{
				this.TitleStr.AppendFormat("{0} / {1}");
			}
			this.TitleText.text = this.TitleStr.ToString();
			this.TitleText.SetAllDirty();
			this.TitleText.cachedTextGenerator.Invalidate();
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x001184B0 File Offset: 0x001166B0
		public void Destroy()
		{
			StringManager.Instance.DeSpawnString(this.TitleStr);
		}

		// Token: 0x040027EA RID: 10218
		private RectTransform BloodTran;

		// Token: 0x040027EB RID: 10219
		public UIText TitleText;

		// Token: 0x040027EC RID: 10220
		private CString TitleStr;

		// Token: 0x040027ED RID: 10221
		private float BloodWidth;
	}

	// Token: 0x02000278 RID: 632
	private enum UIControl
	{
		// Token: 0x040027EF RID: 10223
		MonsterData,
		// Token: 0x040027F0 RID: 10224
		Info,
		// Token: 0x040027F1 RID: 10225
		BookMark,
		// Token: 0x040027F2 RID: 10226
		Monster,
		// Token: 0x040027F3 RID: 10227
		ContSkin,
		// Token: 0x040027F4 RID: 10228
		UpperMessage,
		// Token: 0x040027F5 RID: 10229
		CrusadeTitle,
		// Token: 0x040027F6 RID: 10230
		ContFunc,
		// Token: 0x040027F7 RID: 10231
		CrusadeBtn,
		// Token: 0x040027F8 RID: 10232
		CrusadeMBtn,
		// Token: 0x040027F9 RID: 10233
		ReCharge,
		// Token: 0x040027FA RID: 10234
		DownMessage,
		// Token: 0x040027FB RID: 10235
		Price,
		// Token: 0x040027FC RID: 10236
		Price_Summon,
		// Token: 0x040027FD RID: 10237
		Hint,
		// Token: 0x040027FE RID: 10238
		Close
	}

	// Token: 0x02000279 RID: 633
	private enum UIFuncControl
	{
		// Token: 0x04002800 RID: 10240
		Time,
		// Token: 0x04002801 RID: 10241
		Boost,
		// Token: 0x04002802 RID: 10242
		EnemyBlood,
		// Token: 0x04002803 RID: 10243
		Filter,
		// Token: 0x04002804 RID: 10244
		Position,
		// Token: 0x04002805 RID: 10245
		ChatBtn,
		// Token: 0x04002806 RID: 10246
		TimeHintBtn
	}

	// Token: 0x0200027A RID: 634
	private enum eClickType
	{
		// Token: 0x04002808 RID: 10248
		Info,
		// Token: 0x04002809 RID: 10249
		BookMark,
		// Token: 0x0400280A RID: 10250
		Filter,
		// Token: 0x0400280B RID: 10251
		AddChat,
		// Token: 0x0400280C RID: 10252
		Close,
		// Token: 0x0400280D RID: 10253
		Crusade,
		// Token: 0x0400280E RID: 10254
		CrusadeM,
		// Token: 0x0400280F RID: 10255
		GetEnergy,
		// Token: 0x04002810 RID: 10256
		LearnTech,
		// Token: 0x04002811 RID: 10257
		JoinAlliance
	}

	// Token: 0x0200027B RID: 635
	public enum eMonsterType
	{
		// Token: 0x04002813 RID: 10259
		ResourceMonster = 1,
		// Token: 0x04002814 RID: 10260
		SummonMonster = 3
	}
}
