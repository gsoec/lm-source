using System;

// Token: 0x02000190 RID: 400
public class AttribValManager
{
	// Token: 0x060005A9 RID: 1449 RVA: 0x0007DD80 File Offset: 0x0007BF80
	public AttribValManager()
	{
		ushort num = 205;
		this.UpdateBaseVal = new uint[8][];
		for (int i = 0; i < this.UpdateBaseVal.Length; i++)
		{
			this.UpdateBaseVal[i] = new uint[(int)num];
		}
		this.bUpdate = new bool[8];
		this.TotalBaseVal = new uint[(int)num];
		this.TalentBaseVa = new uint[(int)num];
		this.LordEquipBaseVa = new uint[(int)num];
		this.LordBaseVal = new uint[(int)num];
		this.calcHeroData = new CalcHeroDataType[100];
	}

	// Token: 0x1700003D RID: 61
	// (get) Token: 0x060005AA RID: 1450 RVA: 0x0007DE3C File Offset: 0x0007C03C
	public ulong TotalSoldierConsume
	{
		get
		{
			ulong num = (ulong)this.GetEffectBaseVal(GATTR_ENUM.EGA_UPKEEP_REDUCTION);
			if (num > 10000UL)
			{
				num = 0UL;
			}
			else
			{
				num = 10000UL - num;
			}
			return (this.TotalOuterSoldierConsume + this.TotalInnerSoldierConsume + this.TotalHideSoldierConsume) * num / 10000UL;
		}
	}

	// Token: 0x1700003E RID: 62
	// (get) Token: 0x060005AB RID: 1451 RVA: 0x0007DE90 File Offset: 0x0007C090
	public uint[] BaseVal_Total
	{
		get
		{
			return this.TotalBaseVal;
		}
	}

	// Token: 0x060005AC RID: 1452 RVA: 0x0007DE98 File Offset: 0x0007C098
	public void ResetAllVal()
	{
		GameConstants.ArrayFill<bool>(this.bUpdate, true);
		this.bUpdateTalentVal = true;
		this.bUpdateLordEquipVal = true;
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x0007DEB4 File Offset: 0x0007C0B4
	public void GetWallValue()
	{
		uint effectBaseVal = this.GetEffectBaseVal(GATTR_ENUM.EGA_WALL_HEALTH);
		uint num = effectBaseVal - DataManager.Instance.m_WallRepairMaxValue;
		DataManager.Instance.m_WallRepairMaxValue = effectBaseVal;
		DataManager.Instance.m_WallRepairNowValue += num;
		DataManager.Instance.bNeedShowWallQueueBar = true;
	}

	// Token: 0x060005AE RID: 1454 RVA: 0x0007DF00 File Offset: 0x0007C100
	public void UpdateTalentData()
	{
		this.bUpdateTalentVal = true;
		GameManager.OnRefresh(NetworkNews.Refresh_AttribEffectVal, null);
		this.UpdateResourceMission();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
	}

	// Token: 0x060005AF RID: 1455 RVA: 0x0007DF30 File Offset: 0x0007C130
	public void UpdateLordEquipData()
	{
		this.bUpdateLordEquipVal = true;
		GameManager.OnRefresh(NetworkNews.Refresh_AttribEffectVal, null);
		this.UpdateResourceMission();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
	}

	// Token: 0x060005B0 RID: 1456 RVA: 0x0007DF60 File Offset: 0x0007C160
	public void UpdateJailData()
	{
		if (GUIManager.Instance.BuildingData.GetBuildData(18, 0).Level == 25)
		{
			this.bUpdateJailVal = true;
			GameManager.OnRefresh(NetworkNews.Refresh_AttribEffectVal, null);
		}
	}

	// Token: 0x060005B1 RID: 1457 RVA: 0x0007DFA0 File Offset: 0x0007C1A0
	public void UpdateAttrVal(UpdateAttrKind Kind)
	{
		this.bUpdate[(int)((byte)Kind)] = true;
		if (Kind == UpdateAttrKind.Build)
		{
			this.bUpdate[6] = true;
		}
		if (Kind == UpdateAttrKind.Hero)
		{
			DataManager.MissionDataManager.SetCompleteWhileLogin(eMissionKind.Record);
		}
		if (Kind == UpdateAttrKind.Build || Kind == UpdateAttrKind.Technoolgy || Kind == UpdateAttrKind.Wonder || Kind == UpdateAttrKind.Pet)
		{
			for (int i = 0; i < DataManager.Instance.Resource.Length; i++)
			{
				DataManager.Instance.Resource[i].UpdateCapacity();
			}
			DataManager.Instance.PetResource.UpdateCapacity();
		}
		DataManager.Instance.MaxMarchEventNum = (byte)this.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
		GameManager.OnRefresh(NetworkNews.Refresh_AttribEffectVal, null);
		this.UpdateResourceMission();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
		if (Kind == UpdateAttrKind.Build)
		{
			PetManager.Instance.SetTrainingCenterNum();
		}
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x0007E070 File Offset: 0x0007C270
	private void UpdateResourceMission()
	{
		for (ResourceType resourceType = ResourceType.Grain; resourceType < ResourceType.MAX; resourceType += 1)
		{
			long num = DataManager.MissionDataManager.UpdateResourceInfo(resourceType);
			if (num > 0L)
			{
				DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort)(1 + resourceType), (num >= 65535L) ? ushort.MaxValue : ((ushort)num));
			}
		}
	}

	// Token: 0x060005B3 RID: 1459 RVA: 0x0007E0CC File Offset: 0x0007C2CC
	public void UpdateHeroCalData()
	{
		DataManager instance = DataManager.Instance;
		Array.Clear(this.calcHeroData, 0, this.calcHeroData.Length);
		this.HeroNum = 0;
		for (int i = 0; i < instance.curHeroData.Keys.Length; i++)
		{
			if (instance.curHeroData.Keys[i] != 0u)
			{
				CurHeroData curHeroData = instance.curHeroData[instance.curHeroData.Keys[i]];
				this.calcHeroData[(int)this.HeroNum].HeroID = curHeroData.ID;
				this.calcHeroData[(int)this.HeroNum].Rank = curHeroData.Enhance;
				this.calcHeroData[(int)this.HeroNum].Star = curHeroData.Star;
				this.HeroNum += 1;
			}
		}
		DataManager.MissionDataManager.SetCompleteWhileLogin(eMissionKind.Record);
	}

	// Token: 0x060005B4 RID: 1460 RVA: 0x0007E1BC File Offset: 0x0007C3BC
	public void UpdateBuffData()
	{
		DataManager instance = DataManager.Instance;
		if (this.BuffItem == null)
		{
			this.BuffItem = new ushort[instance.MaxBuffTableCount];
		}
		Array.Clear(this.BuffItem, 0, this.BuffItem.Length);
		this.BuffNum = 0;
		for (int i = 0; i < instance.MaxBuffTableCount; i++)
		{
			if (instance.m_RecvItemBuffData[i].bEnable)
			{
				ushort[] buffItem = this.BuffItem;
				byte buffNum;
				this.BuffNum = (buffNum = this.BuffNum) + 1;
				buffItem[(int)buffNum] = instance.m_RecvItemBuffData[i].ItemID;
			}
		}
	}

	// Token: 0x060005B5 RID: 1461 RVA: 0x0007E260 File Offset: 0x0007C460
	public uint GetEffectBaseVal(GATTR_ENUM Type)
	{
		bool flag = false;
		for (int i = 0; i < this.bUpdate.Length; i++)
		{
			if (this.bUpdate[i])
			{
				switch (i)
				{
				case 0:
					BSInvokeUtil.getInstance.updateBuildEffectval(this.UpdateBaseVal[i]);
					break;
				case 1:
					BSInvokeUtil.getInstance.updateTechnlolgyEffectval(this.UpdateBaseVal[i]);
					break;
				case 2:
					this.UpdateHeroCalData();
					BSInvokeUtil.getInstance.updateHeroEffectval(this.HeroNum, this.calcHeroData, this.UpdateBaseVal[i]);
					break;
				case 3:
					this.UpdateBuffData();
					BSInvokeUtil.getInstance.updateBuffBonus(this.BuffNum, this.BuffItem, this.UpdateBaseVal[i]);
					break;
				case 4:
					BSInvokeUtil.getInstance.updateVIPBonus(this.UpdateBaseVal[i]);
					break;
				case 5:
					BSInvokeUtil.getInstance.updateWonderBonus(this.UpdateBaseVal[i]);
					break;
				case 6:
					BSInvokeUtil.getInstance.updateCastleSkinBonus(this.UpdateBaseVal[i]);
					break;
				case 7:
					BSInvokeUtil.getInstance.updatePetAttribBonum(this.UpdateBaseVal[i]);
					break;
				}
				this.bUpdate[i] = false;
				flag = true;
			}
		}
		if (this.bUpdateLordEquipVal)
		{
			BSInvokeUtil.getInstance.updateLordBonus(this.LordEquipBaseVa);
			flag = true;
		}
		this.bUpdateLordEquipVal = false;
		if (this.bUpdateTalentVal)
		{
			BSInvokeUtil.getInstance.updateTalentval(this.TalentBaseVa);
			flag = true;
		}
		this.bUpdateTalentVal = false;
		DataManager instance = DataManager.Instance;
		if (this.bUpdateJailVal)
		{
			if (instance.PrisonerHighestLevel != 0)
			{
				this.JailAddTroopAtk = (uint)instance.LevelUpTable.GetRecordByKey((ushort)instance.PrisonerHighestLevel).PrisonEffect;
			}
			else
			{
				this.JailAddTroopAtk = 0u;
			}
			flag = true;
		}
		this.bUpdateJailVal = false;
		if (flag)
		{
			Array.Clear(this.TotalBaseVal, 0, this.TotalBaseVal.Length);
			for (int j = 0; j < this.TotalBaseVal.Length; j++)
			{
				for (int k = 0; k < this.UpdateBaseVal.Length; k++)
				{
					this.TotalBaseVal[j] += this.UpdateBaseVal[k][j];
				}
			}
			Array.Clear(this.LordBaseVal, 0, this.LordBaseVal.Length);
			if (instance.beCaptured.nowCaptureStat == LoadCaptureState.None || instance.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
			{
				for (int l = 0; l < this.LordBaseVal.Length; l++)
				{
					this.LordBaseVal[l] = this.TalentBaseVa[l] + this.LordEquipBaseVa[l];
				}
			}
			this.TotalBaseVal[15] += this.JailAddTroopAtk;
		}
		if (Type == GATTR_ENUM.EGA_WALL_DEFENCE_ADD && instance.beCaptured.nowCaptureStat != LoadCaptureState.None && instance.beCaptured.nowCaptureStat != LoadCaptureState.Returning)
		{
			return 0u;
		}
		if (instance.beCaptured.nowCaptureStat == LoadCaptureState.None || instance.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
		{
			return this.TotalBaseVal[(int)Type] + this.TalentBaseVa[(int)Type] + this.LordEquipBaseVa[(int)Type];
		}
		return this.TotalBaseVal[(int)Type];
	}

	// Token: 0x060005B6 RID: 1462 RVA: 0x0007E5A8 File Offset: 0x0007C7A8
	public void UpdateSoldierConsume(SoldierConsumeType Type, byte Index = 255)
	{
		DataManager instance = DataManager.Instance;
		MissionManager missionDataManager = DataManager.MissionDataManager;
		switch (Type)
		{
		case SoldierConsumeType.Inner:
			if (Index == 255)
			{
				int num = instance.RoleAttr.m_Soldier.Length;
				Array.Clear(this.InnerSoldierConsume, 0, this.InnerSoldierConsume.Length);
				this.TotalInnerSoldierConsume = 0UL;
				ushort num2 = 0;
				while ((int)num2 < num)
				{
					ushort num3 = num2 + 1;
					int salaries = (int)instance.SoldierDataTable.GetRecordByKey(num3).Salaries;
					this.InnerSoldierConsume[(int)num2] = (ulong)instance.RoleAttr.m_Soldier[(int)num2] * (ulong)((long)salaries);
					this.TotalInnerSoldierConsume += this.InnerSoldierConsume[(int)num2];
					num2 += 1;
				}
			}
			else
			{
				long num4 = (long)this.InnerSoldierConsume[(int)Index];
				ushort num3 = (ushort)(Index + 1);
				this.TotalInnerSoldierConsume -= this.InnerSoldierConsume[(int)Index];
				int salaries = (int)instance.SoldierDataTable.GetRecordByKey(num3).Salaries;
				this.InnerSoldierConsume[(int)Index] = (ulong)instance.RoleAttr.m_Soldier[(int)Index] * (ulong)((long)salaries);
				this.TotalInnerSoldierConsume += this.InnerSoldierConsume[(int)Index];
				num4 = (long)(this.InnerSoldierConsume[(int)Index] - (ulong)num4);
				if (num4 > 0L)
				{
					num4 /= (long)salaries;
					missionDataManager.CheckChanged(eMissionKind.Army, num3, (ushort)num4);
				}
			}
			break;
		case SoldierConsumeType.Outer:
			if (Index == 255)
			{
				uint effectBaseVal = this.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
				Array.Clear(this.OuterSoldierConsume, 0, this.OuterSoldierConsume.Length);
				Array.Clear(this.OuterSoldier, 0, this.OuterSoldier.Length);
				this.TotalOuterSoldierConsume = 0UL;
				this.TotalOuterSoldier = 0u;
				int num5 = 0;
				while ((long)num5 < (long)((ulong)effectBaseVal))
				{
					for (int i = 0; i < 4; i++)
					{
						for (int j = 0; j < 4; j++)
						{
							ushort num3 = (ushort)(i * 4 + j + 1);
							int salaries = (int)instance.SoldierDataTable.GetRecordByKey(num3).Salaries;
							this.OuterSoldierConsume[num5] += (uint)((ulong)instance.MarchEventData[num5].TroopData[i][j] * (ulong)((long)salaries));
							this.OuterSoldier[num5] += instance.MarchEventData[num5].TroopData[i][j];
						}
					}
					this.TotalOuterSoldierConsume += (ulong)this.OuterSoldierConsume[num5];
					this.TotalOuterSoldier += this.OuterSoldier[num5];
					num5++;
				}
			}
			else
			{
				this.TotalOuterSoldierConsume -= (ulong)this.OuterSoldierConsume[(int)Index];
				this.TotalOuterSoldier -= this.OuterSoldier[(int)Index];
				this.OuterSoldierConsume[(int)Index] = 0u;
				this.OuterSoldier[(int)Index] = 0u;
				for (int k = 0; k < 4; k++)
				{
					for (int l = 0; l < 4; l++)
					{
						ushort num3 = (ushort)(k * 4 + l + 1);
						int salaries = (int)instance.SoldierDataTable.GetRecordByKey(num3).Salaries;
						this.OuterSoldierConsume[(int)Index] += (uint)((ulong)instance.MarchEventData[(int)Index].TroopData[k][l] * (ulong)((long)salaries));
						this.OuterSoldier[(int)Index] += instance.MarchEventData[(int)Index].TroopData[k][l];
					}
				}
				this.TotalOuterSoldierConsume += (ulong)this.OuterSoldierConsume[(int)Index];
				this.TotalOuterSoldier += this.OuterSoldier[(int)Index];
			}
			break;
		case SoldierConsumeType.Hide:
			this.TotalDugoutSoldier = 0u;
			this.TotalHideSoldierConsume = 0UL;
			if (Index != 0)
			{
				uint[] hideTroopData = HideArmyManager.Instance.GetHideTroopData();
				for (int m = 0; m < hideTroopData.Length; m++)
				{
					ushort num3 = (ushort)(m + 1);
					int salaries = (int)instance.SoldierDataTable.GetRecordByKey(num3).Salaries;
					this.TotalHideSoldierConsume += (ulong)hideTroopData[m] * (ulong)((long)salaries);
					this.TotalDugoutSoldier += hideTroopData[m];
				}
			}
			break;
		}
		GameManager.OnRefresh(NetworkNews.Refresh_AttribEffectVal, null);
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
	}

	// Token: 0x060005B7 RID: 1463 RVA: 0x0007EA08 File Offset: 0x0007CC08
	public uint[] GetLordBaseVal()
	{
		bool flag = false;
		if (this.bUpdateLordEquipVal)
		{
			BSInvokeUtil.getInstance.updateLordBonus(this.LordEquipBaseVa);
			this.bUpdateLordEquipVal = false;
			flag = true;
		}
		if (this.bUpdateTalentVal)
		{
			BSInvokeUtil.getInstance.updateTalentval(this.TalentBaseVa);
			this.bUpdateTalentVal = false;
			flag = true;
		}
		if (flag)
		{
			Array.Clear(this.LordBaseVal, 0, this.LordBaseVal.Length);
			if (DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.None || DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
			{
				for (int i = 0; i < this.LordBaseVal.Length; i++)
				{
					this.LordBaseVal[i] = this.TalentBaseVa[i] + this.LordEquipBaseVa[i];
				}
			}
		}
		return this.LordBaseVal;
	}

	// Token: 0x060005B8 RID: 1464 RVA: 0x0007EADC File Offset: 0x0007CCDC
	public uint GetEffectBaseValByEffectID(ushort effectID)
	{
		if (effectID > 200 && effectID < 406)
		{
			return this.GetEffectBaseVal((GATTR_ENUM)(effectID - 201));
		}
		return 0u;
	}

	// Token: 0x060005B9 RID: 1465 RVA: 0x0007EB10 File Offset: 0x0007CD10
	public uint GetEffectBaseValDueLord(ushort effectID, bool isLordCount)
	{
		if (!GameConstants.IsBetween((int)effectID, 201, 399))
		{
			return 0u;
		}
		effectID -= 201;
		if ((int)effectID > this.TotalBaseVal.Length)
		{
			return 0u;
		}
		uint num = this.TotalBaseVal[(int)effectID] + this.TalentBaseVa[(int)effectID] + this.LordEquipBaseVa[(int)effectID];
		if (isLordCount)
		{
			switch (effectID)
			{
			case 0:
				num += this.TotalBaseVal[179] + this.TalentBaseVa[179] + this.LordEquipBaseVa[179];
				if (DataManager.Instance.bHaveWarBuff)
				{
					num += this.TotalBaseVal[191] + this.TalentBaseVa[191] + this.LordEquipBaseVa[191];
				}
				return num;
			case 1:
				num += this.TotalBaseVal[180] + this.TalentBaseVa[180] + this.LordEquipBaseVa[180];
				if (DataManager.Instance.bHaveWarBuff)
				{
					num += this.TotalBaseVal[192] + this.TalentBaseVa[192] + this.LordEquipBaseVa[192];
				}
				return num;
			case 2:
				num += this.TotalBaseVal[181] + this.TalentBaseVa[181] + this.LordEquipBaseVa[181];
				if (DataManager.Instance.bHaveWarBuff)
				{
					num += this.TotalBaseVal[193] + this.TalentBaseVa[193] + this.LordEquipBaseVa[193];
				}
				return num;
			case 3:
				num += this.TotalBaseVal[182] + this.TalentBaseVa[182] + this.LordEquipBaseVa[182];
				if (DataManager.Instance.bHaveWarBuff)
				{
					num += this.TotalBaseVal[194] + this.TalentBaseVa[194] + this.LordEquipBaseVa[194];
				}
				return num;
			case 5:
				num += this.TotalBaseVal[183] + this.TalentBaseVa[183] + this.LordEquipBaseVa[183];
				if (DataManager.Instance.bHaveWarBuff)
				{
					num += this.TotalBaseVal[195] + this.TalentBaseVa[195] + this.LordEquipBaseVa[195];
				}
				return num;
			case 6:
				num += this.TotalBaseVal[184] + this.TalentBaseVa[184] + this.LordEquipBaseVa[184];
				if (DataManager.Instance.bHaveWarBuff)
				{
					num += this.TotalBaseVal[196] + this.TalentBaseVa[196] + this.LordEquipBaseVa[196];
				}
				return num;
			case 7:
				num += this.TotalBaseVal[185] + this.TalentBaseVa[185] + this.LordEquipBaseVa[185];
				if (DataManager.Instance.bHaveWarBuff)
				{
					num += this.TotalBaseVal[197] + this.TalentBaseVa[197] + this.LordEquipBaseVa[197];
				}
				return num;
			case 8:
				num += this.TotalBaseVal[186] + this.TalentBaseVa[186] + this.LordEquipBaseVa[186];
				if (DataManager.Instance.bHaveWarBuff)
				{
					num += this.TotalBaseVal[198] + this.TalentBaseVa[198] + this.LordEquipBaseVa[198];
				}
				return num;
			case 10:
				num += this.TotalBaseVal[187] + this.TalentBaseVa[187] + this.LordEquipBaseVa[187];
				if (DataManager.Instance.bHaveWarBuff)
				{
					num += this.TotalBaseVal[199] + this.TalentBaseVa[199] + this.LordEquipBaseVa[199];
				}
				return num;
			case 11:
				num += this.TotalBaseVal[188] + this.TalentBaseVa[188] + this.LordEquipBaseVa[188];
				if (DataManager.Instance.bHaveWarBuff)
				{
					num += this.TotalBaseVal[200] + this.TalentBaseVa[200] + this.LordEquipBaseVa[200];
				}
				return num;
			case 12:
				num += this.TotalBaseVal[189] + this.TalentBaseVa[189] + this.LordEquipBaseVa[189];
				if (DataManager.Instance.bHaveWarBuff)
				{
					num += this.TotalBaseVal[201] + this.TalentBaseVa[201] + this.LordEquipBaseVa[201];
				}
				return num;
			case 13:
				num += this.TotalBaseVal[190] + this.TalentBaseVa[190] + this.LordEquipBaseVa[190];
				if (DataManager.Instance.bHaveWarBuff)
				{
					num += this.TotalBaseVal[202] + this.TalentBaseVa[202] + this.LordEquipBaseVa[202];
				}
				return num;
			}
			return num;
		}
		num = this.TotalBaseVal[(int)effectID];
		switch (effectID)
		{
		case 0:
			if (DataManager.Instance.bHaveWarBuff)
			{
				num += this.TotalBaseVal[191];
			}
			return num;
		case 1:
			if (DataManager.Instance.bHaveWarBuff)
			{
				num += this.TotalBaseVal[192];
			}
			return num;
		case 2:
			if (DataManager.Instance.bHaveWarBuff)
			{
				num += this.TotalBaseVal[193];
			}
			return num;
		case 3:
			if (DataManager.Instance.bHaveWarBuff)
			{
				num += this.TotalBaseVal[194];
			}
			return num;
		case 5:
			if (DataManager.Instance.bHaveWarBuff)
			{
				num += this.TotalBaseVal[195];
			}
			return num;
		case 6:
			if (DataManager.Instance.bHaveWarBuff)
			{
				num += this.TotalBaseVal[196];
			}
			return num;
		case 7:
			if (DataManager.Instance.bHaveWarBuff)
			{
				num += this.TotalBaseVal[197];
			}
			return num;
		case 8:
			if (DataManager.Instance.bHaveWarBuff)
			{
				num += this.TotalBaseVal[198];
			}
			return num;
		case 10:
			if (DataManager.Instance.bHaveWarBuff)
			{
				num += this.TotalBaseVal[199];
			}
			return num;
		case 11:
			if (DataManager.Instance.bHaveWarBuff)
			{
				num += this.TotalBaseVal[200];
			}
			return num;
		case 12:
			if (DataManager.Instance.bHaveWarBuff)
			{
				num += this.TotalBaseVal[201];
			}
			return num;
		case 13:
			if (DataManager.Instance.bHaveWarBuff)
			{
				num += this.TotalBaseVal[202];
			}
			return num;
		}
		return this.TotalBaseVal[(int)effectID];
	}

	// Token: 0x0400167A RID: 5754
	private uint[][] UpdateBaseVal;

	// Token: 0x0400167B RID: 5755
	private bool[] bUpdate;

	// Token: 0x0400167C RID: 5756
	private uint[] TotalBaseVal;

	// Token: 0x0400167D RID: 5757
	private uint[] TalentBaseVa;

	// Token: 0x0400167E RID: 5758
	private uint[] LordEquipBaseVa;

	// Token: 0x0400167F RID: 5759
	private uint[] LordBaseVal;

	// Token: 0x04001680 RID: 5760
	private bool bUpdateTalentVal;

	// Token: 0x04001681 RID: 5761
	private bool bUpdateLordEquipVal;

	// Token: 0x04001682 RID: 5762
	private bool bUpdateJailVal;

	// Token: 0x04001683 RID: 5763
	private byte HeroNum;

	// Token: 0x04001684 RID: 5764
	private byte BuffNum;

	// Token: 0x04001685 RID: 5765
	private CalcHeroDataType[] calcHeroData;

	// Token: 0x04001686 RID: 5766
	private ushort[] BuffItem;

	// Token: 0x04001687 RID: 5767
	private uint[] OuterSoldier = new uint[8];

	// Token: 0x04001688 RID: 5768
	public uint TotalOuterSoldier;

	// Token: 0x04001689 RID: 5769
	public uint TotalDugoutSoldier;

	// Token: 0x0400168A RID: 5770
	private uint[] OuterSoldierConsume = new uint[8];

	// Token: 0x0400168B RID: 5771
	private ulong TotalOuterSoldierConsume;

	// Token: 0x0400168C RID: 5772
	private ulong[] InnerSoldierConsume = new ulong[16];

	// Token: 0x0400168D RID: 5773
	private ulong TotalInnerSoldierConsume;

	// Token: 0x0400168E RID: 5774
	private ulong TotalHideSoldierConsume;

	// Token: 0x0400168F RID: 5775
	private uint JailAddTroopAtk;
}
