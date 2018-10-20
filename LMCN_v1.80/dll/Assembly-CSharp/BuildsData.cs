using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x02000340 RID: 832
public class BuildsData
{
	// Token: 0x060010E8 RID: 4328 RVA: 0x001E2674 File Offset: 0x001E0874
	public BuildsData()
	{
		this.castleSkin = new CastleSkin();
	}

	// Token: 0x17000081 RID: 129
	// (get) Token: 0x060010E9 RID: 4329 RVA: 0x001E2704 File Offset: 0x001E0904
	// (set) Token: 0x060010EA RID: 4330 RVA: 0x001E270C File Offset: 0x001E090C
	public byte CastleID
	{
		get
		{
			return this._CastleID;
		}
		set
		{
			if (this._CastleID == value + 1)
			{
				return;
			}
			this._CastleID = value + 1;
			this.UpdateBuildState(12, 1);
		}
	}

	// Token: 0x060010EB RID: 4331 RVA: 0x001E2734 File Offset: 0x001E0934
	private void InitialBuildData()
	{
		ushort mapCount = DataManager.Instance.BuildManorData.MapCount;
		this.AllBuildsData = new RoleBuildingData[(int)mapCount];
		this.SortBuildsData = new ushort[(int)mapCount];
		this.BuildlevelupCheck = new byte[(int)DataManager.Instance.BuildsTypeData.MapCount];
		for (ushort num = 0; num < mapCount; num += 1)
		{
			this.SortBuildsData[(int)num] = num;
		}
	}

	// Token: 0x060010EC RID: 4332 RVA: 0x001E27A0 File Offset: 0x001E09A0
	public void MakeIndexTable()
	{
		int tableCount = DataManager.Instance.BuildsLevelRequestGroup.TableCount;
		if (tableCount == 0)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		ushort num = 0;
		BuildLevelRequestGroup recordByIndex = instance.BuildsLevelRequestGroup.GetRecordByIndex(tableCount - 1);
		this.BuildsLevelRequestGroupIndexTbl = new int[(int)recordByIndex.GroupID];
		ushort num2 = 0;
		while ((int)num2 < tableCount)
		{
			recordByIndex = instance.BuildsLevelRequestGroup.GetRecordByIndex((int)num2);
			ushort groupID = recordByIndex.GroupID;
			this.GetRequestGroupIDEnd(ref recordByIndex, groupID, ref num2);
			ushort num3 = num2 - num;
			int num4 = ((int)num << 16) + (int)num3;
			this.BuildsLevelRequestGroupIndexTbl[(int)(groupID - 1)] = num4;
			num = num2;
		}
		tableCount = instance.BuildManorData.TableCount;
		this.BuildManorGroupIndexTbl = new List<byte>[(int)(instance.BuildManorData.GetRecordByIndex(tableCount - 1).MapGroup + 1)];
		ushort num5 = 0;
		while ((int)num5 < tableCount)
		{
			BuildManorData recordByIndex2 = instance.BuildManorData.GetRecordByIndex((int)num5);
			if (this.BuildManorGroupIndexTbl[(int)recordByIndex2.MapGroup] == null)
			{
				this.BuildManorGroupIndexTbl[(int)recordByIndex2.MapGroup] = new List<byte>();
			}
			this.BuildManorGroupIndexTbl[(int)recordByIndex2.MapGroup].Add((byte)num5);
			num5 += 1;
		}
		this.BuildIDCount = new byte[(int)instance.BuildsTypeData.MapCount];
		this.SortBuildStart = new ushort[(int)instance.BuildsTypeData.MapCount];
		this.InitialBuildData();
	}

	// Token: 0x060010ED RID: 4333 RVA: 0x001E2908 File Offset: 0x001E0B08
	private void GetRequestGroupIDEnd(ref BuildLevelRequestGroup Data, ushort groupID, ref ushort index)
	{
		DataManager instance = DataManager.Instance;
		index += 1;
		if ((int)index >= instance.BuildsLevelRequestGroup.TableCount)
		{
			return;
		}
		Data = instance.BuildsLevelRequestGroup.GetRecordByIndex((int)index);
		if (Data.GroupID == groupID)
		{
			this.GetRequestGroupIDEnd(ref Data, groupID, ref index);
		}
	}

	// Token: 0x060010EE RID: 4334 RVA: 0x001E2960 File Offset: 0x001E0B60
	private void GetRequestGroupIDEnd(ref BuildManorData Data, ushort groupID, ref ushort index)
	{
		DataManager instance = DataManager.Instance;
		index += 1;
		if ((int)index >= instance.BuildManorData.TableCount)
		{
			return;
		}
		Data = instance.BuildManorData.GetRecordByIndex((int)index);
		if (Data.MapGroup == groupID)
		{
			this.GetRequestGroupIDEnd(ref Data, groupID, ref index);
		}
	}

	// Token: 0x060010EF RID: 4335 RVA: 0x001E29B8 File Offset: 0x001E0BB8
	public BuildLevelRequest GetBuildLevelRequestData(ushort BuildID, byte Level)
	{
		int index = (int)(25 * (BuildID - 1) + (ushort)(Level - 1));
		return DataManager.Instance.BuildsRequest.GetRecordByIndex(index);
	}

	// Token: 0x060010F0 RID: 4336 RVA: 0x001E29E4 File Offset: 0x001E0BE4
	public void GetLevelRequestGroupIndex(ushort groupID, ref int BeginIndex, ref int Num)
	{
		if (groupID == 0)
		{
			BeginIndex = 0;
			Num = 0;
			return;
		}
		int num = this.BuildsLevelRequestGroupIndexTbl[(int)(groupID - 1)];
		int num2 = 65535;
		BeginIndex = num >> 16;
		Num = (num & num2);
	}

	// Token: 0x060010F1 RID: 4337 RVA: 0x001E2A1C File Offset: 0x001E0C1C
	public void GetManorGroup(ushort groupID, ref int BeginIndex, ref int Num)
	{
		BeginIndex = (int)this.BuildManorGroupIndexTbl[(int)groupID][0];
		Num = this.BuildManorGroupIndexTbl[(int)groupID].Count;
	}

	// Token: 0x060010F2 RID: 4338 RVA: 0x001E2A40 File Offset: 0x001E0C40
	public int GetCurrentChapterBuildCount()
	{
		StageManager stageDataController = DataManager.StageDataController;
		int num = (int)stageDataController.StageRecord[2];
		int num2 = 0;
		if (stageDataController.limitRecord[2] == stageDataController.StageRecord[2])
		{
			num++;
		}
		for (int i = num; i >= 0; i--)
		{
			if (this.BuildManorGroupIndexTbl != null && this.BuildManorGroupIndexTbl.Length > i)
			{
				num2 += this.BuildManorGroupIndexTbl[i].Count;
			}
		}
		return num2;
	}

	// Token: 0x060010F3 RID: 4339 RVA: 0x001E2AB8 File Offset: 0x001E0CB8
	public byte GetMonorIndex(int Index)
	{
		for (int i = 0; i < this.BuildManorGroupIndexTbl.Length; i++)
		{
			if (this.BuildManorGroupIndexTbl[i].Count > Index)
			{
				return this.BuildManorGroupIndexTbl[i][Index];
			}
			Index -= this.BuildManorGroupIndexTbl[i].Count;
		}
		return 0;
	}

	// Token: 0x060010F4 RID: 4340 RVA: 0x001E2B14 File Offset: 0x001E0D14
	public void EmptyManorGuide(ushort BuildID, bool UiGuide = false)
	{
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		RoleBuildingData buildData = this.GetBuildData(BuildID, 0);
		ushort value = 0;
		ushort value2 = 0;
		BuildManorData buildManorData = instance.BuildManorData.GetRecordByKey(buildData.ManorID);
		if (this.BuildingManorID > 0 && (int)this.BuildingManorID < this.AllBuildsData.Length && this.AllBuildsData[(int)this.BuildingManorID].BuildID == BuildID)
		{
			buildManorData = DataManager.Instance.BuildManorData.GetRecordByKey(this.BuildingManorID);
			DataManager.msgBuffer[0] = 24;
			GameConstants.GetBytes(buildManorData.MapGroup, DataManager.msgBuffer, 1);
			GameConstants.GetBytes(buildManorData.ID, DataManager.msgBuffer, 3);
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			if (UiGuide)
			{
				instance2.GuideParm1 = 2;
				instance2.GuideParm2 = buildData.ManorID;
			}
			return;
		}
		StageManager stageDataController = DataManager.StageDataController;
		byte kind = instance.BuildsTypeData.GetRecordByKey(BuildID).Kind;
		int num = (int)stageDataController.StageRecord[2];
		if (stageDataController.limitRecord[2] == stageDataController.StageRecord[2])
		{
			num++;
		}
		List<byte> list = this.BuildManorGroupIndexTbl[0];
		ushort num2 = 0;
		while ((int)num2 < list.Count)
		{
			buildManorData = DataManager.Instance.BuildManorData.GetRecordByIndex((int)list[(int)num2]);
			if (buildManorData.Kind == kind && this.AllBuildsData[(int)buildManorData.ID].BuildID == 0)
			{
				if (!NewbieManager.IsWorking())
				{
					this.GuideBuildID = BuildID;
				}
				this.FindNearMainTown(ref buildManorData, list, (int)(num2 + 1), list.Count - (int)(num2 + 1), ref value, ref value2);
				DataManager.msgBuffer[0] = 24;
				GameConstants.GetBytes(value, DataManager.msgBuffer, 1);
				GameConstants.GetBytes(value2, DataManager.msgBuffer, 3);
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				if (UiGuide)
				{
					instance2.GuideParm1 = 1;
					instance2.GuideParm2 = BuildID;
				}
				return;
			}
			num2 += 1;
		}
		ushort num3 = 1;
		while ((int)num3 < this.BuildManorGroupIndexTbl.Length)
		{
			list = this.BuildManorGroupIndexTbl[(int)num3];
			buildManorData = DataManager.Instance.BuildManorData.GetRecordByIndex((int)list[0]);
			if (buildManorData.Kind == kind)
			{
				if (num < (int)num3)
				{
					GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(5802u), 255, true);
					return;
				}
				for (int i = 0; i < list.Count; i++)
				{
					buildManorData = DataManager.Instance.BuildManorData.GetRecordByIndex((int)list[i]);
					if (this.AllBuildsData[(int)buildManorData.ID].BuildID == 0)
					{
						if (!NewbieManager.IsWorking())
						{
							this.GuideBuildID = BuildID;
						}
						this.FindNearMainTown(ref buildManorData, list, i + 1, list.Count - (i + 1), ref value, ref value2);
						DataManager.msgBuffer[0] = 24;
						GameConstants.GetBytes(value, DataManager.msgBuffer, 1);
						GameConstants.GetBytes(value2, DataManager.msgBuffer, 3);
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						if (UiGuide)
						{
							instance2.GuideParm1 = 1;
							instance2.GuideParm2 = BuildID;
						}
						return;
					}
				}
			}
			num3 += 1;
		}
		GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(5803u), 255, true);
	}

	// Token: 0x060010F5 RID: 4341 RVA: 0x001E2E78 File Offset: 0x001E1078
	public void ManorGuild(ushort BuildID, bool UiGuide = false)
	{
		GUIManager instance = GUIManager.Instance;
		DataManager instance2 = DataManager.Instance;
		RoleBuildingData buildData = this.GetBuildData(BuildID, 0);
		ushort value = 0;
		ushort value2 = 0;
		instance.BuildGuildQueue = 0;
		Door door = instance.FindMenu(EGUIWindow.Door) as Door;
		if (door == null)
		{
			return;
		}
		if (door.m_eMapMode == EUIOriginMapMode.KingdomMap)
		{
			instance.BuildGuildQueue = BuildID;
		}
		if (buildData.BuildID > 0)
		{
			if (door.m_eMapMode == EUIOriginMapMode.KingdomMap)
			{
				instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToMap);
			}
			else
			{
				BuildManorData buildManorData = instance2.BuildManorData.GetRecordByKey(buildData.ManorID);
				DataManager.msgBuffer[0] = 24;
				GameConstants.GetBytes(buildManorData.MapGroup, DataManager.msgBuffer, 1);
				GameConstants.GetBytes(buildManorData.ID, DataManager.msgBuffer, 3);
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				if (UiGuide)
				{
					instance.GuideParm1 = 2;
					instance.GuideParm2 = buildData.ManorID;
				}
			}
			return;
		}
		bool flag = false;
		if (this.BuildingManorID > 0 && (int)this.BuildingManorID < this.AllBuildsData.Length && this.AllBuildsData[(int)this.BuildingManorID].BuildID == BuildID)
		{
			BuildManorData buildManorData = DataManager.Instance.BuildManorData.GetRecordByKey(this.BuildingManorID);
			DataManager.msgBuffer[0] = 24;
			GameConstants.GetBytes(buildManorData.MapGroup, DataManager.msgBuffer, 1);
			GameConstants.GetBytes(buildManorData.ID, DataManager.msgBuffer, 3);
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			return;
		}
		StageManager stageDataController = DataManager.StageDataController;
		byte kind = instance2.BuildsTypeData.GetRecordByKey(BuildID).Kind;
		int num = (int)stageDataController.StageRecord[2];
		if (stageDataController.limitRecord[2] == stageDataController.StageRecord[2])
		{
			num++;
		}
		List<byte> list = this.BuildManorGroupIndexTbl[0];
		ushort num2 = 0;
		while ((int)num2 < list.Count)
		{
			BuildManorData buildManorData = DataManager.Instance.BuildManorData.GetRecordByIndex((int)list[(int)num2]);
			if (buildManorData.Kind == kind && (int)buildManorData.ID < this.AllBuildsData.Length && this.AllBuildsData[(int)buildManorData.ID].BuildID == 0)
			{
				if (!NewbieManager.IsWorking())
				{
					this.GuideBuildID = BuildID;
				}
				this.FindNearMainTown(ref buildManorData, list, (int)(num2 + 1), list.Count - (int)(num2 + 1), ref value, ref value2);
				DataManager.msgBuffer[0] = 24;
				GameConstants.GetBytes(value, DataManager.msgBuffer, 1);
				GameConstants.GetBytes(value2, DataManager.msgBuffer, 3);
				flag = true;
				if (UiGuide)
				{
					instance.GuideParm1 = 1;
					instance.GuideParm2 = BuildID;
				}
				break;
			}
			num2 += 1;
		}
		ushort num3 = 1;
		while ((int)num3 < this.BuildManorGroupIndexTbl.Length)
		{
			if (flag)
			{
				break;
			}
			list = this.BuildManorGroupIndexTbl[(int)num3];
			for (int i = 0; i < list.Count; i++)
			{
				if (flag)
				{
					break;
				}
				if (num3 < 8 && i > 0)
				{
					break;
				}
				BuildManorData buildManorData = DataManager.Instance.BuildManorData.GetRecordByIndex((int)list[i]);
				if (buildManorData.Kind == kind)
				{
					if (num < (int)num3)
					{
						GUIManager.Instance.AddHUDMessage(instance2.mStringTable.GetStringByID(5802u), 255, true);
						return;
					}
					for (int j = 0; j < list.Count; j++)
					{
						buildManorData = DataManager.Instance.BuildManorData.GetRecordByIndex((int)list[j]);
						if (this.AllBuildsData[(int)buildManorData.ID].BuildID == 0 && kind == buildManorData.Kind)
						{
							if (!NewbieManager.IsWorking())
							{
								this.GuideBuildID = BuildID;
							}
							this.FindNearMainTown(ref buildManorData, list, j + 1, list.Count - (j + 1), ref value, ref value2);
							DataManager.msgBuffer[0] = 24;
							GameConstants.GetBytes(value, DataManager.msgBuffer, 1);
							GameConstants.GetBytes(value2, DataManager.msgBuffer, 3);
							flag = true;
							if (UiGuide)
							{
								instance.GuideParm1 = 1;
								instance.GuideParm2 = BuildID;
							}
							break;
						}
					}
				}
			}
			num3 += 1;
		}
		if (flag)
		{
			if (instance.BuildGuildQueue > 0)
			{
				instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToMap);
			}
			else
			{
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			return;
		}
		GUIManager.Instance.AddHUDMessage(instance2.mStringTable.GetStringByID(5803u), 255, true);
	}

	// Token: 0x060010F6 RID: 4342 RVA: 0x001E330C File Offset: 0x001E150C
	public void ArneaGuild()
	{
		DataManager.msgBuffer[0] = 25;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x060010F7 RID: 4343 RVA: 0x001E3324 File Offset: 0x001E1524
	public void DugoutGuild()
	{
		DataManager.msgBuffer[0] = 26;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x060010F8 RID: 4344 RVA: 0x001E333C File Offset: 0x001E153C
	public void BlackMarketGuild()
	{
		DataManager.msgBuffer[0] = 27;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x060010F9 RID: 4345 RVA: 0x001E3354 File Offset: 0x001E1554
	public void WarLobbyGuide()
	{
		DataManager.msgBuffer[0] = 28;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x060010FA RID: 4346 RVA: 0x001E336C File Offset: 0x001E156C
	public void CasinoGuide()
	{
		DataManager.msgBuffer[0] = 29;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x060010FB RID: 4347 RVA: 0x001E3384 File Offset: 0x001E1584
	public void LaboratoryGuide()
	{
		DataManager.msgBuffer[0] = 30;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		this.bHideLaboryPromptLock = 1;
		this.UpdateBuildState(5, 255);
	}

	// Token: 0x060010FC RID: 4348 RVA: 0x001E33BC File Offset: 0x001E15BC
	public void PetListGuide()
	{
		DataManager.msgBuffer[0] = 31;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x060010FD RID: 4349 RVA: 0x001E33D4 File Offset: 0x001E15D4
	public void OpenWarlobbyUI()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OpenMenu(EGUIWindow.UI_WarLobby, (int)this.GuideParm, 11, false);
		}
	}

	// Token: 0x060010FE RID: 4350 RVA: 0x001E3410 File Offset: 0x001E1610
	private void FindNearMainTown(ref BuildManorData ManorData, List<byte> MonorList, int Begin, int Num, ref ushort searchGroupID, ref ushort searchManorID)
	{
		byte searchPriority = ManorData.SearchPriority;
		byte kind = ManorData.Kind;
		searchGroupID = ManorData.MapGroup;
		searchManorID = ManorData.ID;
		ushort num = 0;
		while ((int)num < Num)
		{
			ManorData = DataManager.Instance.BuildManorData.GetRecordByIndex((int)MonorList[Begin + (int)num]);
			if (ManorData.SearchPriority < searchPriority && ManorData.Kind == kind && this.AllBuildsData[(int)ManorData.ID].BuildID == 0)
			{
				searchPriority = ManorData.SearchPriority;
				searchGroupID = ManorData.MapGroup;
				searchManorID = ManorData.ID;
			}
			num += 1;
		}
	}

	// Token: 0x060010FF RID: 4351 RVA: 0x001E34BC File Offset: 0x001E16BC
	public byte CheckLevelupRule(ushort BuildID, byte Level)
	{
		int num = 0;
		int num2 = 0;
		DataManager instance = DataManager.Instance;
		if (instance.BuildsTypeData.GetRecordByKey(BuildID).Kind == 3 && ((Level == 1 && this.GetBuildNumByID(BuildID) > 0) || ((int)this.BuildingManorID < this.AllBuildsData.Length && this.AllBuildsData[(int)this.BuildingManorID].BuildID == BuildID)))
		{
			return 3;
		}
		BuildLevelRequest buildLevelRequestData = this.GetBuildLevelRequestData(BuildID, Level);
		if (buildLevelRequestData.GroupID > 0)
		{
			this.GetLevelRequestGroupIndex(buildLevelRequestData.GroupID, ref num, ref num2);
		}
		if (num2 > 0)
		{
			for (int i = num; i < num + num2; i++)
			{
				BuildLevelRequestGroup recordByIndex = instance.BuildsLevelRequestGroup.GetRecordByIndex(i);
				if (recordByIndex.ConditionType == 1)
				{
					if ((ushort)this.GetBuildData(recordByIndex.Condition, 0).Level < recordByIndex.Num)
					{
						return 2;
					}
				}
				else if (recordByIndex.ConditionType == 2)
				{
					ushort curItemQuantity = instance.GetCurItemQuantity(recordByIndex.Condition, 0);
					if (curItemQuantity < recordByIndex.Num)
					{
						return 2;
					}
				}
			}
		}
		if (buildLevelRequestData.RequestFood > instance.Resource[0].Stock || buildLevelRequestData.RequestWood > instance.Resource[2].Stock || buildLevelRequestData.RequestIron > instance.Resource[3].Stock || buildLevelRequestData.RequestRock > instance.Resource[1].Stock || buildLevelRequestData.RequestGold > instance.Resource[4].Stock)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06001100 RID: 4352 RVA: 0x001E366C File Offset: 0x001E186C
	public byte GetBuildNumByID(ushort BuildID)
	{
		this.SortBuildData();
		if (this.BuildIDCount == null || this.BuildIDCount.Length <= (int)BuildID)
		{
			return 0;
		}
		return this.BuildIDCount[(int)BuildID];
	}

	// Token: 0x06001101 RID: 4353 RVA: 0x001E3698 File Offset: 0x001E1898
	public void UpdateLevelupResource()
	{
		if (this.AllBuildsData == null)
		{
			this.InitialBuildData();
		}
		DataManager instance = DataManager.Instance;
		if (!instance.MySysSetting.bShowBuildUp)
		{
			return;
		}
		byte b = 1;
		while ((int)b < this.BuildlevelupCheck.Length)
		{
			this.BuildlevelupCheck[(int)b] = 0;
			byte b2 = 0;
			ushort num = (ushort)b;
			if (num == 16 && this.GetBuildData(num, (ushort)b2).Level == 9)
			{
				this.BuildlevelupCheck[(int)b] = 9;
			}
			else if (this.GetBuildNumByID(num) == 1 && this.GetBuildData(num, (ushort)b2).Level == 25)
			{
				this.BuildlevelupCheck[(int)b] = 25;
			}
			else
			{
				byte b4;
				BuildLevelRequest buildLevelRequestData;
				do
				{
					ushort buildID = num;
					byte b3 = b2;
					b2 = b3 + 1;
					RoleBuildingData buildData;
					RoleBuildingData roleBuildingData = buildData = this.GetBuildData(buildID, (ushort)b3);
					if (buildData.BuildID == 0)
					{
						goto IL_182;
					}
					b4 = Math.Min(25, roleBuildingData.Level + 1);
					buildLevelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(num, b4);
				}
				while (buildLevelRequestData.RequestFood > instance.Resource[0].Stock || buildLevelRequestData.RequestRock > instance.Resource[1].Stock || buildLevelRequestData.RequestWood > instance.Resource[2].Stock || buildLevelRequestData.RequestIron > instance.Resource[3].Stock || buildLevelRequestData.RequestGold > instance.Resource[4].Stock);
				this.BuildlevelupCheck[(int)b] = b4;
			}
			IL_182:
			b += 1;
		}
		this.UpdateBuildState(8, 255);
	}

	// Token: 0x06001102 RID: 4354 RVA: 0x001E384C File Offset: 0x001E1A4C
	private void SortBuildData()
	{
		if (!this.NeedSortData || this.SortBuildsData == null || this.SortBuildStart == null || this.BuildIDCount == null)
		{
			return;
		}
		Array.Sort<ushort>(this.SortBuildsData, this.buildDataComparer);
		Array.Clear(this.SortBuildStart, 0, this.SortBuildStart.Length);
		Array.Clear(this.BuildIDCount, 0, this.BuildIDCount.Length);
		this.NeedSortData = false;
		ushort num = 0;
		ushort num2 = 0;
		while ((int)num2 < this.SortBuildsData.Length)
		{
			ushort num3 = this.SortBuildsData[(int)num2];
			if (this.AllBuildsData[(int)num3].BuildID != 0 && this.AllBuildsData[(int)num3].Level != 0)
			{
				ushort buildID = this.AllBuildsData[(int)num3].BuildID;
				if (buildID != num)
				{
					this.SortBuildStart[(int)buildID] = num2;
					this.BuildIDCount[(int)buildID] = 1;
					num = buildID;
				}
				else
				{
					byte[] buildIDCount = this.BuildIDCount;
					ushort buildID2 = this.AllBuildsData[(int)num3].BuildID;
					buildIDCount[(int)buildID2] = buildIDCount[(int)buildID2] + 1;
				}
			}
			num2 += 1;
		}
	}

	// Token: 0x06001103 RID: 4355 RVA: 0x001E3974 File Offset: 0x001E1B74
	public void GetBuildSprite(ushort ManorID, SpriteRenderer spriterender, SpriteRenderer levelrender)
	{
		if (this.AllBuildsData == null)
		{
			this.InitialBuildData();
		}
		if (this.SpriteBaseSizeY <= 0f)
		{
			Sprite spriteByName = this.mapspriteManager.GetSpriteByName("space_01-1");
			this.SpriteBaseSizeY = spriteByName.rect.size.y;
		}
		BuildManorData recordByKey = DataManager.Instance.BuildManorData.GetRecordByKey(ManorID);
		if (ManorID < 100 && ManorID != recordByKey.ID)
		{
			return;
		}
		this.SpriteName.Remove(0, this.SpriteName.Length);
		spriterender.name = this.SpriteName.AppendFormat("Sprite{0}", ManorID).ToString();
		Vector3 position = spriterender.transform.position;
		float new_x;
		float new_y;
		float new_z;
		Quaternion rotation;
		switch ((byte)ManorID)
		{
		case 100:
			new_x = 22f;
			new_y = 1f;
			new_z = 60f;
			spriterender.sprite = this.mapspriteManager.GetSpriteByName("herotower");
			if (DataManager.StageDataController.StageRecord[2] == 0)
			{
				spriterender.enabled = false;
			}
			spriterender.sortingOrder = -33;
			break;
		case 101:
			new_x = 119.07f;
			new_y = 2.8f;
			new_z = 78.78f;
			if (DataManager.StageDataController.StageRecord[2] < 2)
			{
				spriterender.enabled = false;
			}
			else
			{
				spriterender.sprite = this.mapspriteManager.GetSpriteByName("Arena");
			}
			spriterender.sortingOrder = -33;
			break;
		case 102:
			new_x = -22.22f;
			new_y = 13.39f;
			new_z = -22.2f;
			spriterender.sprite = this.mapspriteManager.GetSpriteByName("build_22-1");
			spriterender.sortingOrder = -33;
			break;
		case 103:
			new_x = 1.6f;
			new_y = -1.5f;
			new_z = 39.12f;
			spriterender.sprite = this.mapspriteManager.GetSpriteByName("Cantonment");
			spriterender.enabled = false;
			spriterender.sortingOrder = -33;
			break;
		case 104:
			new_x = 51.5f;
			new_y = -0.5f;
			new_z = 87.44f;
			if (DataManager.StageDataController.StageRecord[2] < 2)
			{
				spriterender.enabled = false;
			}
			else
			{
				spriterender.sprite = this.mapspriteManager.GetSpriteByName("cargo_ship");
			}
			spriterender.sortingOrder = -33;
			break;
		case 105:
			new_x = -5.179f;
			new_y = 0.6343f;
			new_z = 130.0719f;
			spriterender.sprite = this.mapspriteManager.GetSpriteByName("Dark_Alchemy");
			spriterender.sortingOrder = -33;
			break;
		case 106:
			new_x = 131.4549f;
			new_y = 9.1178f;
			new_z = -7.681f;
			if (DataManager.StageDataController.StageRecord[2] < 8)
			{
				spriterender.enabled = false;
			}
			else
			{
				spriterender.sprite = this.mapspriteManager.GetSpriteByName("Underground_city");
			}
			spriterender.sortingOrder = -33;
			break;
		default:
			if (this.AllBuildsData[(int)ManorID].BuildID <= 0)
			{
				new_x = ((recordByKey.mPosionX <= 30000) ? ((float)recordByKey.mPosionX) : ((float)recordByKey.mPosionX - 65535f)) * 0.01f;
				new_y = ((recordByKey.mPosionY <= 32768) ? ((float)recordByKey.mPosionY) : ((float)recordByKey.mPosionY - 65535f)) * 0.01f;
				new_z = ((recordByKey.mPosionZ <= 32768) ? ((float)recordByKey.mPosionZ) : ((float)recordByKey.mPosionZ - 65535f)) * 0.01f;
				position.Set(new_x, new_y, new_z);
				spriterender.transform.position = position;
				if (recordByKey.Kind == 1)
				{
					spriterender.sprite = this.mapspriteManager.GetSpriteByName("space_01-1");
				}
				else if (recordByKey.Kind == 2)
				{
					spriterender.sprite = this.mapspriteManager.GetSpriteByName("space_01-2");
				}
				else if (recordByKey.Kind == 3)
				{
					spriterender.sprite = this.mapspriteManager.GetSpriteByName("space_01-3");
				}
				else
				{
					spriterender.sprite = this.mapspriteManager.GetSpriteByName("space_01-4");
				}
				rotation = spriterender.transform.rotation;
				rotation.eulerAngles = this.BuildRot;
				spriterender.transform.rotation = rotation;
				float num = 9f;
				position.Set(num, num, num);
				spriterender.transform.localScale = position;
				levelrender.sprite = null;
				levelrender.enabled = false;
				spriterender.sortingOrder = -61;
				return;
			}
			new_x = ((recordByKey.bPosionX <= 30000) ? ((float)recordByKey.bPosionX) : ((float)recordByKey.bPosionX - 65535f)) * 0.01f;
			new_y = ((recordByKey.bPosionY <= 32768) ? ((float)recordByKey.bPosionY) : ((float)recordByKey.bPosionY - 65535f)) * 0.01f;
			new_z = ((recordByKey.bPosionZ <= 32768) ? ((float)recordByKey.bPosionZ) : ((float)recordByKey.bPosionZ - 65535f)) * 0.01f;
			if (this.AllBuildsData[(int)ManorID].BuildID == 8)
			{
				spriterender.sprite = this.castleSkin.GetSprite(this.CastleID, this.AllBuildsData[(int)ManorID].Level);
				spriterender.material = this.castleSkin.GetMaterial(this.CastleID, this.AllBuildsData[(int)ManorID].Level);
				spriterender.sortingOrder = -34;
			}
			else
			{
				spriterender.sprite = this.GetBuildSprite(this.AllBuildsData[(int)ManorID].BuildID, this.AllBuildsData[(int)ManorID].Level);
				spriterender.sortingOrder = -33;
			}
			levelrender.enabled = true;
			break;
		}
		position.Set(new_x, new_y, new_z);
		spriterender.transform.position = position;
		rotation = spriterender.transform.rotation;
		if (ManorID == 103)
		{
			rotation.eulerAngles = new Vector3(30f, 185f, 3f);
		}
		else
		{
			rotation.eulerAngles = this.BuildRot;
		}
		spriterender.transform.rotation = rotation;
		if ((int)ManorID < this.AllBuildsData.Length && this.AllBuildsData[(int)ManorID].BuildID == 12)
		{
			spriterender.transform.localScale = this.GateScale;
		}
		else
		{
			spriterender.transform.localScale = this.BaseBuildScale;
		}
		if ((int)ManorID < this.AllBuildsData.Length && this.AllBuildsData[(int)ManorID].Level > 0)
		{
			this.SpriteName.Remove(0, this.SpriteName.Length);
			this.SpriteName.AppendFormat("rank_{0:00}", this.AllBuildsData[(int)ManorID].Level);
			levelrender.sprite = this.mapspriteManager.GetSpriteByName(this.SpriteName.ToString());
			levelrender.transform.position = spriterender.transform.position;
			levelrender.transform.rotation = spriterender.transform.rotation;
			levelrender.transform.localScale = this.BaseBuildScale;
		}
		else
		{
			levelrender.enabled = false;
		}
	}

	// Token: 0x06001104 RID: 4356 RVA: 0x001E410C File Offset: 0x001E230C
	public Sprite GetBuildSprite(ushort BuildID, byte Level)
	{
		if (this.mapspriteManager == null || this.AllBuildsData == null)
		{
			return null;
		}
		byte b = 1;
		if (BuildID != 16)
		{
			if (Level >= 9 && Level < 17)
			{
				b = 2;
			}
			else if (Level >= 17 && Level < 25)
			{
				b = 3;
			}
			else if (Level >= 25)
			{
				b = 4;
			}
		}
		else if (Level >= 3 && Level < 6)
		{
			b = 2;
		}
		else if (Level >= 6 && Level < 9)
		{
			b = 3;
		}
		else if (Level >= 9)
		{
			b = 4;
		}
		this.SpriteName.Remove(0, this.SpriteName.Length);
		BuildTypeData recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey(BuildID);
		if (BuildID == 8)
		{
			return this.castleSkin.GetUISprite(0, Level);
		}
		this.SpriteName.AppendFormat("build_{0}-{1}", recordByKey.GraphicID.ToString("d2"), b);
		Sprite sprite = this.mapspriteManager.GetSpriteByName(this.SpriteName.ToString());
		if (sprite == null && BuildID != 1)
		{
			sprite = this.GetBuildSprite(1, 1);
		}
		return sprite;
	}

	// Token: 0x06001105 RID: 4357 RVA: 0x001E424C File Offset: 0x001E244C
	public void NotifyOpenUI(ushort ManorID)
	{
		DataManager.msgBuffer[0] = 23;
		GameConstants.GetBytes(ManorID, DataManager.msgBuffer, 1);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06001106 RID: 4358 RVA: 0x001E4270 File Offset: 0x001E2470
	public void NotifyCloseUI()
	{
		DataManager.msgBuffer[0] = 33;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06001107 RID: 4359 RVA: 0x001E4288 File Offset: 0x001E2488
	public void OpenUI(ushort ManorID, Door doorController)
	{
		Debug.Log("SentBuild  " + ManorID);
		bool bCameraMode = false;
		switch ((byte)ManorID)
		{
		case 100:
			if (DataManager.StageDataController.StageRecord[2] > 1)
			{
				DataManager.StageDataController.resetStageMode(DataManager.StageDataController.inoutStageMode);
				DataManager.Instance.WorldCameraTransitionsPos = GameConstants.GoldGuy;
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.DoorOpenUp);
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5899u), 255, true);
			}
			GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Hero);
			return;
		case 101:
			if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 10)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9101u), 255, true);
			}
			else
			{
				doorController.OpenMenu(EGUIWindow.UI_Arena, 0, 0, false);
			}
			return;
		case 102:
			if (DataManager.StageDataController.StageRecord[2] < 3)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8585u), 255, true);
			}
			else
			{
				HideArmyManager.Instance.OpenHideArmyUI();
			}
			return;
		case 103:
			doorController.OpenMenu(EGUIWindow.UI_Ambush, 0, 0, false);
			return;
		case 104:
			if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 13)
			{
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(1479u));
				cstring.IntToFormat(13L, 1, false);
				cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9749u));
				GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
			}
			else
			{
				doorController.OpenMenu(EGUIWindow.UI_Merchantman, 0, 0, false);
			}
			return;
		case 105:
			if ((DataManager.Instance.RoleAttr.Guide & 16777216UL) == 0UL && GUIManager.Instance.BoxID[0] == 0)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12045u), 255, true);
				return;
			}
			doorController.OpenMenu(EGUIWindow.UIAlchemy, 0, 0, true);
			return;
		case 106:
			if (GamblingManager.Instance.m_GambleEventSave.State == EActivityState.EAS_None)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9182u), 255, true);
				return;
			}
			GamblingManager.Instance.BattleMonsterID = GamblingManager.Instance.m_GambleEventSave.MonsterID;
			if (!DataManager.CheckGambleBattleResources())
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8350u), 255, true);
				return;
			}
			if (!NewbieManager.CheckGambleNormal())
			{
				GamblingManager.Instance.Send_MSG_REQUEST_GAMBLE_INFO();
			}
			return;
		default:
		{
			EGUIWindow eguiwindow;
			switch (this.AllBuildsData[(int)ManorID].BuildID)
			{
			case 0:
				eguiwindow = EGUIWindow.UI_SuitBuilding;
				goto IL_46A;
			case 6:
				eguiwindow = EGUIWindow.UI_Barrack;
				goto IL_46A;
			case 7:
				eguiwindow = EGUIWindow.UI_Hospital;
				goto IL_46A;
			case 8:
				eguiwindow = EGUIWindow.UI_Castle;
				goto IL_46A;
			case 9:
				eguiwindow = EGUIWindow.UI_Warehouse;
				goto IL_46A;
			case 10:
				eguiwindow = EGUIWindow.UI_TechInstitute;
				goto IL_46A;
			case 11:
				eguiwindow = EGUIWindow.UI_WarLobby;
				goto IL_46A;
			case 12:
				eguiwindow = EGUIWindow.UI_CityWall;
				goto IL_46A;
			case 13:
				eguiwindow = EGUIWindow.UI_Watchtower;
				goto IL_46A;
			case 14:
				eguiwindow = EGUIWindow.UI_Embassy;
				goto IL_46A;
			case 15:
				eguiwindow = EGUIWindow.UI_Forge;
				goto IL_46A;
			case 16:
				eguiwindow = EGUIWindow.UI_Crypt;
				if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 17)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(3929u), 255, true);
					return;
				}
				goto IL_46A;
			case 17:
				eguiwindow = EGUIWindow.UI_Market;
				goto IL_46A;
			case 18:
				eguiwindow = EGUIWindow.UI_Jail;
				goto IL_46A;
			case 19:
				bCameraMode = true;
				eguiwindow = EGUIWindow.UI_Altar;
				goto IL_46A;
			case 20:
				eguiwindow = EGUIWindow.UI_PetList;
				goto IL_46A;
			case 21:
				eguiwindow = EGUIWindow.UI_PetResourceStation;
				goto IL_46A;
			case 22:
				eguiwindow = EGUIWindow.UI_PetFusionbuilding;
				goto IL_46A;
			case 23:
				eguiwindow = EGUIWindow.UI_PetTrainingCenter;
				goto IL_46A;
			}
			eguiwindow = EGUIWindow.UIResourceBuilding;
			IL_46A:
			this.OpenUiManorID = ManorID;
			doorController.OpenMenu(eguiwindow, (int)ManorID, (int)this.AllBuildsData[(int)ManorID].BuildID, bCameraMode);
			this.GuideBuildID = 0;
			this.GuideSoldierNum = 0u;
			if (eguiwindow != EGUIWindow.UI_CityWall)
			{
				this.GuideSoldierID = 0;
			}
			return;
		}
		}
	}

	// Token: 0x06001108 RID: 4360 RVA: 0x001E4740 File Offset: 0x001E2940
	public RoleBuildingData GetBuildData(ushort BuildID, ushort Index)
	{
		if (this.AllBuildsData == null)
		{
			this.InitialBuildData();
		}
		if (this.BuildIDCount == null)
		{
			return default(RoleBuildingData);
		}
		this.SortBuildData();
		if ((ushort)this.BuildIDCount[(int)BuildID] > Index)
		{
			ushort num = this.SortBuildsData[(int)(this.SortBuildStart[(int)BuildID] + Index)];
			return this.AllBuildsData[(int)num];
		}
		return this.AllBuildsData[0];
	}

	// Token: 0x06001109 RID: 4361 RVA: 0x001E47BC File Offset: 0x001E29BC
	public void sendStartBuilding(ushort MonorID, ushort BuildID)
	{
		if (NewbieManager.IsNewbie)
		{
			return;
		}
		if (!GUIManager.Instance.ShowUILock(EUILock.Build))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_BUILDBEGIN;
		messagePacket.AddSeqId();
		messagePacket.Add(MonorID);
		messagePacket.Add(BuildID);
		messagePacket.Send(false);
	}

	// Token: 0x0600110A RID: 4362 RVA: 0x001E4818 File Offset: 0x001E2A18
	public void sendBuildingCancel()
	{
		if (!GUIManager.Instance.ShowUILock(EUILock.Build))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_BUILDCANCEL;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x0600110B RID: 4363 RVA: 0x001E485C File Offset: 0x001E2A5C
	public void sendBuildCompleteFree()
	{
		if (!GUIManager.Instance.ShowUILock(EUILock.Build))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_BUILDFREE;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
		if (DataManager.Instance.OpenBuildingWindowUpdateNoClose == 1)
		{
			this.bClose = false;
		}
		else
		{
			this.bClose = true;
		}
	}

	// Token: 0x0600110C RID: 4364 RVA: 0x001E48C4 File Offset: 0x001E2AC4
	public void sendBuildCompleteImmediate(ushort ManorID, ushort BuildID = 0)
	{
		if (NewbieManager.IsNewbie)
		{
			return;
		}
		if (!GUIManager.Instance.ShowUILock(EUILock.Build))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_INSTANTBUILD;
		messagePacket.AddSeqId();
		messagePacket.Add(ManorID);
		if (BuildID == 0)
		{
			messagePacket.Add(this.AllBuildsData[(int)ManorID].BuildID);
		}
		else
		{
			messagePacket.Add(BuildID);
		}
		messagePacket.Send(false);
		if (BuildID == 8)
		{
			NewbieManager.BuildCastleImmediate = true;
		}
	}

	// Token: 0x0600110D RID: 4365 RVA: 0x001E4950 File Offset: 0x001E2B50
	public void sendBuildFinish()
	{
		if (!GUIManager.Instance.ShowUILock(EUILock.Build))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_FINISHBUILD;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x0600110E RID: 4366 RVA: 0x001E4994 File Offset: 0x001E2B94
	public void sendBuildDismantle(ushort ManorID)
	{
		if (!GUIManager.Instance.ShowUILock(EUILock.Build))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_DECONSTRBEGIN;
		messagePacket.AddSeqId();
		messagePacket.Add(ManorID);
		messagePacket.Send(false);
	}

	// Token: 0x0600110F RID: 4367 RVA: 0x001E49E0 File Offset: 0x001E2BE0
	public void sendBuildDismantleCancel()
	{
		if (!GUIManager.Instance.ShowUILock(EUILock.Build))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_DECONSTRCANCEL;
		messagePacket.AddSeqId();
		messagePacket.Add(this.BuildingManorID);
		messagePacket.Send(false);
	}

	// Token: 0x06001110 RID: 4368 RVA: 0x001E4A30 File Offset: 0x001E2C30
	public void sendBuildDismantleImmediate(ushort ManorID)
	{
		if (!GUIManager.Instance.ShowUILock(EUILock.Build))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_INSTANTDECONSTR;
		messagePacket.AddSeqId();
		messagePacket.Add(ManorID);
		messagePacket.Send(false);
	}

	// Token: 0x06001111 RID: 4369 RVA: 0x001E4A7C File Offset: 0x001E2C7C
	public void sendBuildDismantleFinish()
	{
		if (!GUIManager.Instance.ShowUILock(EUILock.Build))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_FINISHDECONSTR;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06001112 RID: 4370 RVA: 0x001E4AC0 File Offset: 0x001E2CC0
	public void RecvAllBuildData(MessagePacket MP)
	{
		if (this.AllBuildsData == null)
		{
			this.InitialBuildData();
		}
		Array.Clear(this.AllBuildsData, 0, this.AllBuildsData.Length);
		if (this.BuildIDCount != null)
		{
			Array.Clear(this.BuildIDCount, 0, this.BuildIDCount.Length);
		}
		ushort num = 0;
		while ((int)num < this.AllBuildsData.Length)
		{
			this.AllBuildsData[(int)num].ManorID = num;
			num += 1;
		}
		byte b = MP.ReadByte(-1);
		for (byte b2 = 0; b2 < b; b2 += 1)
		{
			ushort num2 = MP.ReadUShort(-1);
			if ((int)num2 >= this.AllBuildsData.Length)
			{
				MP.ReadUShort(-1);
				MP.ReadByte(-1);
			}
			else
			{
				ushort num3 = MP.ReadUShort(-1);
				byte level = MP.ReadByte(-1);
				if (DataManager.Instance.BuildsTypeData.GetRecordByKey(num3).BuildID == num3)
				{
					this.AllBuildsData[(int)num2].BuildID = num3;
					this.AllBuildsData[(int)num2].Level = level;
				}
			}
		}
		this.bHideLaboryPromptLock = 0;
		if (this.BuildingManorID > 0)
		{
			this.UpdateBuildState(3, this.BuildingManorID);
			this.BuildingManorID = 0;
		}
		this.NeedSortData = true;
		this.ImmEffect = 0;
		DataManager.MissionDataManager.SetCompleteWhileLogin(eMissionKind.Build);
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Build);
		for (byte b3 = 0; b3 < 7; b3 += 1)
		{
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort)(21 + b3), (ushort)this.GetBuildNumByID((ushort)(b3 + 1)));
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuitBuilding, 0, 0);
		if (this.GetBuildData(8, 0).Level > 2)
		{
			GUIManager.Instance.SetFrontMark(1);
		}
		AssetManager.SetCastleLevel(this.GetBuildData(12, 0).Level, 0);
		GUIManager.Instance.BuildingData.UpdateBuildState(6, 255);
		ActivityManager.Instance.CheckCastleLevel();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 19, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 16, 0);
	}

	// Token: 0x06001113 RID: 4371 RVA: 0x001E4CEC File Offset: 0x001E2EEC
	public void RecvBuildingQueue(MessagePacket MP)
	{
		if (this.AllBuildsData == null)
		{
			this.InitialBuildData();
		}
		this.QueueBuildType = MP.ReadByte(-1);
		ushort num = MP.ReadUShort(-1);
		if ((int)num >= this.AllBuildsData.Length)
		{
			this.QueueBuildType = 0;
			return;
		}
		this.BuildingManorID = num;
		this.AllBuildsData[(int)num].BuildID = MP.ReadUShort(-1);
		MP.ReadByte(-1);
		long startTime = MP.ReadLong(-1);
		uint totalTime = MP.ReadUInt(-1);
		this.UpdateBuildState(2, num);
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, this.BuildingManorID != 0, startTime, totalTime);
		DataManager.Instance.SetRecvQueueBarData(0);
		PetManager.Instance.SetTrainingCenterNum();
	}

	// Token: 0x06001114 RID: 4372 RVA: 0x001E4DA4 File Offset: 0x001E2FA4
	public void RecvUpdateBuildData(MessagePacket MP)
	{
		ushort num = MP.ReadUShort(-1);
		if (this.AllBuildsData.Length <= (int)num)
		{
			return;
		}
		this.BuildingManorID = num;
		this.AllBuildsData[(int)num].BuildID = MP.ReadUShort(-1);
		byte b = MP.ReadByte(-1);
		if (num == 1 && b == 3 && !NewbieManager.IsWorking() && NewbieManager.EntryTeach(ETeachKind.TURBO) && NewbieManager.Get() != null)
		{
			NewbieManager.Get().CheckTimeBarStatus();
		}
		long startTime = MP.ReadLong(-1);
		uint totalTime = MP.ReadUInt(-1);
		DataManager instance = DataManager.Instance;
		byte b2 = 0;
		while ((int)b2 < instance.Resource.Length)
		{
			instance.Resource[(int)b2].Stock = MP.ReadUInt(-1);
			b2 += 1;
		}
		ushort num2 = MP.ReadUShort(-1);
		for (ushort num3 = 0; num3 < num2; num3 += 1)
		{
			ushort itemID = MP.ReadUShort(-1);
			ushort quantity = instance.GetCurItemQuantity(itemID, 0) - MP.ReadUShort(-1);
			DataManager.Instance.SetCurItemQuantity(itemID, quantity, 0, 0L);
		}
		GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
		this.UpdateBuildState(2, num);
		this.QueueBuildType = 1;
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, true, startTime, totalTime);
		GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
		GameConstants.GetBytes(1, DataManager.msgBuffer, 0);
		GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
		AudioManager.Instance.PlayUISFX(UIKind.Construction);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
		GUIManager.Instance.HideUILock(EUILock.Build);
	}

	// Token: 0x06001115 RID: 4373 RVA: 0x001E4F34 File Offset: 0x001E3134
	public void RecvBuildCancel(MessagePacket MP)
	{
		DataManager instance = DataManager.Instance;
		byte b = 0;
		while ((int)b < instance.Resource.Length)
		{
			instance.Resource[(int)b].Stock = MP.ReadUInt(-1);
			b += 1;
		}
		this.NeedSortData = true;
		ushort num = MP.ReadUShort(-1);
		for (ushort num2 = 0; num2 < num; num2 += 1)
		{
			ushort itemID = MP.ReadUShort(-1);
			ushort quantity = instance.GetCurItemQuantity(itemID, 0) + MP.ReadUShort(-1);
			instance.SetCurItemQuantity(itemID, quantity, 0, 0L);
		}
		GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
		ushort buildingManorID = this.BuildingManorID;
		this.BuildingManorID = 0;
		if ((int)buildingManorID < this.AllBuildsData.Length && this.AllBuildsData[(int)buildingManorID].Level == 0)
		{
			this.AllBuildsData[(int)buildingManorID].BuildID = 0;
		}
		this.UpdateBuildState(4, buildingManorID);
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0u);
		GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
		GameConstants.GetBytes(1, DataManager.msgBuffer, 0);
		GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuitBuilding, 0, 0);
		GUIManager.Instance.HideUILock(EUILock.Build);
	}

	// Token: 0x06001116 RID: 4374 RVA: 0x001E5064 File Offset: 0x001E3264
	public void RecvBuildComplete(MessagePacket MP)
	{
		this.BuildingManorID = 0;
		ushort num = MP.ReadUShort(-1);
		if ((int)num >= this.AllBuildsData.Length)
		{
			return;
		}
		this.AllBuildsData[(int)num].BuildID = MP.ReadUShort(-1);
		this.NeedSortData = true;
		this.AllBuildsData[(int)num].Level = MP.ReadByte(-1);
		if (NewbieManager.IsTeachWorking(ETeachKind.TURBO) && num == 1 && this.AllBuildsData[(int)num].Level == 3)
		{
			NewbieManager.Get().IgnoreStep(true, -1);
			NewbieManager.Get().RestoreTimeBarStatus();
		}
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Build);
		if (this.AllBuildsData[(int)num].BuildID == 8)
		{
			for (int i = 0; i < 5; i++)
			{
				DataManager.Instance.Resource[i].Stock = MP.ReadUInt(-1);
			}
			for (ushort num2 = 0; num2 < 4; num2 += 1)
			{
				ushort num3 = MP.ReadUShort(-1);
				ushort quantity = MP.ReadUShort(-1);
				if (num3 != 0)
				{
					DataManager.Instance.SetCurItemQuantity(num3, quantity, 0, 0L);
				}
			}
			this.UpdateBuildState(5, 255);
			GUIManager.Instance.SetFrontMark(1);
			if (this.AllBuildsData[(int)num].Level == 15)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 6, 0);
			}
		}
		this.ImmEffect = 0;
		this.UpdateBuildState(3, num);
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0u);
		this.ShowBuildHUD(num, 1);
		if (!this.bClose)
		{
			GameConstants.GetBytes(0, DataManager.msgBuffer, 0);
		}
		else
		{
			GameConstants.GetBytes(1, DataManager.msgBuffer, 0);
			this.bClose = false;
		}
		GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
		DataManager.Instance.OpenBuildingWindowUpdateNoClose = 0;
		if (this.AllBuildsData[(int)num].BuildID == 8)
		{
			bool flag = false;
			Door door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
			if (door != null && door.m_eMode == EUIOriginMode.Show && door.m_eMapMode == EUIOriginMapMode.OriginMap)
			{
				flag = true;
			}
			if (GUIManager.Instance.m_SecWindow != null || GUIManager.Instance.m_OtheCanvas != null)
			{
				flag = false;
			}
			if (!NewbieManager.IsWorking() && flag)
			{
				if (this.AllBuildsData[(int)num].Level == 5)
				{
					NewbieManager.EntryTeach(ETeachKind.ACTIVITY);
				}
				else if (this.AllBuildsData[(int)num].Level == 10)
				{
					NewbieManager.EntryTeach(ETeachKind.ARENA);
				}
				else if (this.AllBuildsData[(int)num].Level == 13)
				{
					NewbieManager.EntryTeach(ETeachKind.BLACK_MARKET);
				}
				else if (this.AllBuildsData[(int)num].Level == 9)
				{
					NewbieManager.EntryTeach(ETeachKind.DESHIELD);
				}
			}
			AFAdvanceManager.Instance.CheckCastleLvEvent(GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level);
			FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.CASTLE_LEVEL, 0L, 0UL);
			if (this.AllBuildsData[(int)num].Level >= 7)
			{
				FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.ACHIEVED_LEVEL);
			}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuitBuilding, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_DevelopmentDetails, 0, 0);
		if (this.AllBuildsData[(int)num].BuildID == 13)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Watchtower_Details, 1, 0);
		}
		if (this.AllBuildsData[(int)num].BuildID == 12)
		{
			AssetManager.SetCastleLevel(this.AllBuildsData[(int)num].Level, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Trap, 2, 0);
			GameManager.OnRefresh(NetworkNews.Refresh_Soldier, null);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hospital, 1, 0);
		}
		if (this.AllBuildsData[(int)num].BuildID == 6)
		{
			GameManager.OnRefresh(NetworkNews.Refresh_Soldier, null);
		}
		if (this.AllBuildsData[(int)num].BuildID == 7)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hospital, 1, 0);
		}
		if (this.AllBuildsData[(int)num].BuildID == 8)
		{
			GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_CastleUpgradeReward, (int)this.AllBuildsData[(int)num].Level, 0, false, 0);
			GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
			ActivityManager.Instance.CheckCastleLevel();
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 19, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 16, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27, 0);
			LandWalkerManager.SetNewCastleLevel(this.AllBuildsData[(int)num].Level);
			if (NewbieManager.IsTeachWorking(ETeachKind.ACTIVITY))
			{
				NewbieManager.CheckTeach(ETeachKind.ACTIVITY, null, false);
			}
			else if (NewbieManager.IsTeachWorking(ETeachKind.ARENA))
			{
				NewbieManager.CheckTeach(ETeachKind.ARENA, null, false);
			}
			else if (NewbieManager.IsTeachWorking(ETeachKind.BLACK_MARKET))
			{
				NewbieManager.CheckTeach(ETeachKind.BLACK_MARKET, null, false);
			}
			else if (NewbieManager.IsTeachWorking(ETeachKind.DESHIELD))
			{
				NewbieManager.CheckTeach(ETeachKind.DESHIELD, null, false);
			}
			if (this.AllBuildsData[(int)num].Level == 12)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other, 2, 0);
			}
			if (this.AllBuildsData[(int)num].Level == 7)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other, 4, 0);
			}
		}
		if (this.AllBuildsData[(int)num].BuildID == 16)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_CryptDig, 0, 0);
		}
		if (this.AllBuildsData[(int)num].BuildID == 4)
		{
			AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.BUILD_FARM);
		}
		DataManager.MissionDataManager.CheckChanged(eMissionKind.Build, this.AllBuildsData[(int)num].BuildID, (ushort)this.AllBuildsData[(int)num].Level);
		if (this.AllBuildsData[(int)num].BuildID >= 1 && this.AllBuildsData[(int)num].BuildID <= 7)
		{
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 20 + this.AllBuildsData[(int)num].BuildID, (ushort)this.GetBuildNumByID(this.AllBuildsData[(int)num].BuildID));
		}
		GUIManager.Instance.HideUILock(EUILock.Build);
	}

	// Token: 0x06001117 RID: 4375 RVA: 0x001E56B0 File Offset: 0x001E38B0
	public void RecvBuildErrMsg(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		GUIManager.Instance.HideUILock(EUILock.Build);
	}

	// Token: 0x06001118 RID: 4376 RVA: 0x001E56D4 File Offset: 0x001E38D4
	public void RecvResources(MessagePacket MP)
	{
		DataManager instance = DataManager.Instance;
		byte b = 0;
		while ((int)b < instance.Resource.Length)
		{
			instance.Resource[(int)b].SetResource(MP.ReadUInt(-1), MP.ReadLong(-1));
			b += 1;
		}
		GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
	}

	// Token: 0x06001119 RID: 4377 RVA: 0x001E5724 File Offset: 0x001E3924
	public void RecvResourcesUpdate(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if ((int)b < DataManager.Instance.Resource.Length)
		{
			DataManager.Instance.Resource[(int)b].SetResource(MP.ReadUInt(-1), MP.ReadLong(-1));
		}
		if (MP.ReadByte(-1) == 1)
		{
			uint num = MP.ReadUInt(-1);
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(3952u + (uint)b));
			cstring.IntToFormat((long)((ulong)num), 1, true);
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12612u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 35, true);
			GUIManager.Instance.m_SpeciallyEffect.mResValue[(int)b] = num;
			GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
			GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, SpeciallyEffect_Kind.Food + (int)b, 0, 0, true, 2f);
		}
		GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
	}

	// Token: 0x0600111A RID: 4378 RVA: 0x001E5874 File Offset: 0x001E3A74
	public void RecvBuildCompleteImmediate(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eBuildImmediate);
			ushort num = MP.ReadUShort(-1);
			if ((int)num >= this.AllBuildsData.Length)
			{
				return;
			}
			this.AllBuildsData[(int)num].BuildID = MP.ReadUShort(-1);
			this.AllBuildsData[(int)num].Level = MP.ReadByte(-1);
			for (byte b = 0; b < 5; b += 1)
			{
				DataManager.Instance.Resource[(int)b].Stock = MP.ReadUInt(-1);
			}
			ushort num2 = MP.ReadUShort(-1);
			ushort num3 = MP.ReadUShort(-1);
			for (ushort num4 = 0; num4 < num2; num4 += 1)
			{
				ushort itemID = MP.ReadUShort(-1);
				ushort num5 = DataManager.Instance.GetCurItemQuantity(itemID, 0);
				num5 -= MP.ReadUShort(-1);
				DataManager.Instance.SetCurItemQuantity(itemID, num5, 0, 0L);
			}
			for (ushort num6 = 0; num6 < num3; num6 += 1)
			{
				ushort itemID = MP.ReadUShort(-1);
				ushort num5 = MP.ReadUShort(-1);
				DataManager.Instance.SetCurItemQuantity(itemID, num5, 0, 0L);
			}
			this.ImmEffect = 1;
			this.UpdateBuildState(3, num);
			this.NeedSortData = true;
			this.ShowBuildHUD(num, 1);
			DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Build);
			if (this.AllBuildsData[(int)num].BuildID == 8)
			{
				AFAdvanceManager.Instance.CheckCastleLvEvent(GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level);
				FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.CASTLE_LEVEL, 0L, 0UL);
				if (this.AllBuildsData[(int)num].Level >= 7)
				{
					FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.ACHIEVED_LEVEL);
				}
				if (!NewbieManager.IsWorking())
				{
					if (this.AllBuildsData[(int)num].Level == 5)
					{
						NewbieManager.EntryTeach(ETeachKind.ACTIVITY);
					}
					else if (this.AllBuildsData[(int)num].Level == 10)
					{
						NewbieManager.EntryTeach(ETeachKind.ARENA);
					}
					else if (this.AllBuildsData[(int)num].Level == 13)
					{
						NewbieManager.EntryTeach(ETeachKind.BLACK_MARKET);
					}
					else if (this.AllBuildsData[(int)num].Level == 9)
					{
						NewbieManager.EntryTeach(ETeachKind.DESHIELD);
					}
				}
				this.UpdateBuildState(5, 255);
				GUIManager.Instance.SetFrontMark(1);
				if (this.AllBuildsData[(int)num].Level == 15)
				{
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 6, 0);
				}
			}
			GameConstants.GetBytes(1, DataManager.msgBuffer, 0);
			GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuitBuilding, 0, 0);
			if (this.AllBuildsData[(int)num].BuildID == 13)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Watchtower_Details, 1, 0);
			}
			if (this.AllBuildsData[(int)num].BuildID == 12)
			{
				AssetManager.SetCastleLevel(this.AllBuildsData[(int)num].Level, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Trap, 2, 0);
				GameManager.OnRefresh(NetworkNews.Refresh_Soldier, null);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hospital, 1, 0);
			}
			if (this.AllBuildsData[(int)num].BuildID == 10)
			{
				GameManager.OnRefresh(NetworkNews.Refresh_QBarTime, null);
			}
			if (this.AllBuildsData[(int)num].BuildID == 6)
			{
				GameManager.OnRefresh(NetworkNews.Refresh_Soldier, null);
			}
			if (this.AllBuildsData[(int)num].BuildID == 7)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hospital, 1, 0);
			}
			if (this.AllBuildsData[(int)num].BuildID == 8)
			{
				GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_CastleUpgradeReward, (int)this.AllBuildsData[(int)num].Level, 0, false, 0);
				ActivityManager.Instance.CheckCastleLevel();
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 19, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 16, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27, 0);
				LandWalkerManager.SetNewCastleLevel(this.AllBuildsData[(int)num].Level);
				if (NewbieManager.IsTeachWorking(ETeachKind.ACTIVITY))
				{
					NewbieManager.CheckTeach(ETeachKind.ACTIVITY, null, false);
				}
				else if (NewbieManager.IsTeachWorking(ETeachKind.ARENA))
				{
					NewbieManager.CheckTeach(ETeachKind.ARENA, null, false);
				}
				else if (NewbieManager.IsTeachWorking(ETeachKind.BLACK_MARKET))
				{
					NewbieManager.CheckTeach(ETeachKind.BLACK_MARKET, null, false);
				}
				else if (NewbieManager.IsTeachWorking(ETeachKind.DESHIELD))
				{
					NewbieManager.CheckTeach(ETeachKind.DESHIELD, null, false);
				}
			}
			if (this.AllBuildsData[(int)num].BuildID == 4)
			{
				AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.BUILD_FARM);
			}
			GameManager.OnRefresh(NetworkNews.Refresh, null);
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Build, this.AllBuildsData[(int)num].BuildID, (ushort)this.AllBuildsData[(int)num].Level);
			if (this.AllBuildsData[(int)num].BuildID >= 1 && this.AllBuildsData[(int)num].BuildID <= 7)
			{
				DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 20 + this.AllBuildsData[(int)num].BuildID, (ushort)this.GetBuildNumByID(this.AllBuildsData[(int)num].BuildID));
			}
		}
		GUIManager.Instance.HideUILock(EUILock.Build);
	}

	// Token: 0x0600111B RID: 4379 RVA: 0x001E5DD4 File Offset: 0x001E3FD4
	public void RecvBuildFinish(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			this.BuildingManorID = 0;
			GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eBuildFinish);
			ushort num = MP.ReadUShort(-1);
			if ((int)num >= this.AllBuildsData.Length)
			{
				return;
			}
			this.AllBuildsData[(int)num].BuildID = MP.ReadUShort(-1);
			this.AllBuildsData[(int)num].Level = MP.ReadByte(-1);
			DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Build);
			if (this.AllBuildsData[(int)num].BuildID == 8)
			{
				if (!NewbieManager.CheckActivity(true) && !NewbieManager.CheckArena(true) && !NewbieManager.CheckBlackmarket(false) && !NewbieManager.CheckTroopMemory(false))
				{
					NewbieManager.CheckDeShield();
				}
				for (int i = 0; i < 5; i++)
				{
					DataManager.Instance.Resource[i].Stock = MP.ReadUInt(-1);
				}
				for (ushort num2 = 0; num2 < 4; num2 += 1)
				{
					ushort num3 = MP.ReadUShort(-1);
					ushort quantity = MP.ReadUShort(-1);
					if (num3 != 0)
					{
						DataManager.Instance.SetCurItemQuantity(num3, quantity, 0, 0L);
					}
				}
				this.UpdateBuildState(5, 255);
				GUIManager.Instance.SetFrontMark(1);
				if (this.AllBuildsData[(int)num].Level == 15)
				{
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 6, 0);
				}
			}
			this.ImmEffect = 1;
			this.ShowBuildHUD(num, 1);
			this.UpdateBuildState(3, num);
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0u);
			GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, null);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuitBuilding, 0, 0);
			if (this.AllBuildsData[(int)num].BuildID == 13)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Watchtower_Details, 1, 0);
			}
			if (this.AllBuildsData[(int)num].BuildID == 12)
			{
				AssetManager.SetCastleLevel(this.AllBuildsData[(int)num].Level, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Trap, 2, 0);
				GameManager.OnRefresh(NetworkNews.Refresh_Soldier, null);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hospital, 1, 0);
			}
			if (this.AllBuildsData[(int)num].BuildID == 6)
			{
				GameManager.OnRefresh(NetworkNews.Refresh_Soldier, null);
			}
			if (this.AllBuildsData[(int)num].BuildID == 7)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hospital, 1, 0);
			}
			if (this.AllBuildsData[(int)num].BuildID == 8)
			{
				GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_CastleUpgradeReward, (int)this.AllBuildsData[(int)num].Level, 0, false, 0);
				ActivityManager.Instance.CheckCastleLevel();
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 19, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 16, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27, 0);
				LandWalkerManager.SetNewCastleLevel(this.AllBuildsData[(int)num].Level);
				if (NewbieManager.IsTeachWorking(ETeachKind.ACTIVITY))
				{
					NewbieManager.CheckTeach(ETeachKind.ACTIVITY, null, false);
				}
				else if (NewbieManager.IsTeachWorking(ETeachKind.ARENA))
				{
					NewbieManager.CheckTeach(ETeachKind.ARENA, null, false);
				}
				else if (NewbieManager.IsTeachWorking(ETeachKind.BLACK_MARKET))
				{
					NewbieManager.CheckTeach(ETeachKind.BLACK_MARKET, null, false);
				}
				else if (NewbieManager.IsTeachWorking(ETeachKind.DESHIELD))
				{
					NewbieManager.CheckTeach(ETeachKind.DESHIELD, null, false);
				}
				AFAdvanceManager.Instance.CheckCastleLvEvent(GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level);
				FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.CASTLE_LEVEL, 0L, 0UL);
				if (this.AllBuildsData[(int)num].Level >= 7)
				{
					FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.ACHIEVED_LEVEL);
				}
			}
			GameManager.OnRefresh(NetworkNews.Refresh, null);
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Build, this.AllBuildsData[(int)num].BuildID, (ushort)this.AllBuildsData[(int)num].Level);
			if (this.AllBuildsData[(int)num].BuildID >= 1 && this.AllBuildsData[(int)num].BuildID <= 7)
			{
				DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 20 + this.AllBuildsData[(int)num].BuildID, (ushort)this.GetBuildNumByID(this.AllBuildsData[(int)num].BuildID));
			}
			if (this.AllBuildsData[(int)num].BuildID == 4)
			{
				AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.BUILD_FARM);
			}
		}
		GUIManager.Instance.HideUILock(EUILock.Build);
	}

	// Token: 0x0600111C RID: 4380 RVA: 0x001E6258 File Offset: 0x001E4458
	public void RecvBuildDismantle(MessagePacket MP)
	{
		ushort num = MP.ReadUShort(-1);
		if ((int)num >= this.AllBuildsData.Length)
		{
			return;
		}
		this.BuildingManorID = num;
		long startTime = MP.ReadLong(-1);
		uint totalTime = MP.ReadUInt(-1);
		this.UpdateBuildState(2, num);
		this.QueueBuildType = 2;
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, true, startTime, totalTime);
		GameConstants.GetBytes(1, DataManager.msgBuffer, 0);
		GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
		AudioManager.Instance.PlayUISFX(UIKind.Construction);
		GUIManager.Instance.HideUILock(EUILock.Build);
		PetManager.Instance.SetTrainingCenterNum();
	}

	// Token: 0x0600111D RID: 4381 RVA: 0x001E62F0 File Offset: 0x001E44F0
	public void RecvBuildDismantleComplete(MessagePacket MP)
	{
		ushort num = MP.ReadUShort(-1);
		if ((int)num >= this.AllBuildsData.Length)
		{
			return;
		}
		this.ShowBuildHUD(num, 2);
		ushort buildID = this.AllBuildsData[(int)num].BuildID;
		this.AllBuildsData[(int)num].BuildID = 0;
		this.AllBuildsData[(int)num].Level = 0;
		this.NeedSortData = true;
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Build);
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0u);
		if (this.OpenUiManorID == num)
		{
			GameConstants.GetBytes(1, DataManager.msgBuffer, 0);
		}
		else
		{
			GameConstants.GetBytes(0, DataManager.msgBuffer, 0);
		}
		GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
		this.BuildingManorID = 0;
		GUIManager.Instance.HideUILock(EUILock.Build);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuitBuilding, 0, 0);
		this.UpdateBuildState(3, num);
		DataManager.MissionDataManager.CheckChanged(eMissionKind.Build, buildID, 0);
		if (buildID >= 1 && buildID <= 7)
		{
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 20 + buildID, (ushort)this.GetBuildNumByID(buildID));
		}
	}

	// Token: 0x0600111E RID: 4382 RVA: 0x001E640C File Offset: 0x001E460C
	public void RecvBuildDismantleCancel(MessagePacket MP)
	{
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0u);
		this.UpdateBuildState(4, this.BuildingManorID);
		this.BuildingManorID = 0;
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0u);
		GameConstants.GetBytes(1, DataManager.msgBuffer, 0);
		GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
		GUIManager.Instance.HideUILock(EUILock.Build);
		PetManager.Instance.SetTrainingCenterNum();
	}

	// Token: 0x0600111F RID: 4383 RVA: 0x001E647C File Offset: 0x001E467C
	public void RecvBuildDismantleCompleteImmediate(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b > 0)
		{
			return;
		}
		GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eBuildDismentleImmediate);
		ushort num = MP.ReadUShort(-1);
		ushort num2 = MP.ReadUShort(-1);
		if (num > 0 && num2 > 0)
		{
			ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(num, 0);
			DataManager.Instance.SetCurItemQuantity(num, curItemQuantity - num2, 0, 0L);
		}
		ushort num3 = MP.ReadUShort(-1);
		if ((int)num3 >= this.AllBuildsData.Length)
		{
			return;
		}
		ushort buildID = this.AllBuildsData[(int)num3].BuildID;
		this.ShowBuildHUD(num3, 2);
		this.AllBuildsData[(int)num3].BuildID = 0;
		this.AllBuildsData[(int)num3].Level = 0;
		this.NeedSortData = true;
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Build);
		GameConstants.GetBytes(1, DataManager.msgBuffer, 0);
		GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
		this.UpdateBuildState(3, num3);
		GameManager.OnRefresh(NetworkNews.Refresh, null);
		DataManager.MissionDataManager.CheckChanged(eMissionKind.Build, buildID, 0);
		if (buildID >= 1 && buildID <= 7)
		{
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 20 + buildID, (ushort)this.GetBuildNumByID(buildID));
		}
		AudioManager.Instance.PlayUISFX(UIKind.BuildDestroy);
		GUIManager.Instance.HideUILock(EUILock.Build);
	}

	// Token: 0x06001120 RID: 4384 RVA: 0x001E65DC File Offset: 0x001E47DC
	public void RecvBuildDismantleCompleteFinish(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b > 0)
		{
			return;
		}
		GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eBuildDismentleFinish);
		ushort num = MP.ReadUShort(-1);
		if ((int)num >= this.AllBuildsData.Length)
		{
			return;
		}
		ushort buildID = this.AllBuildsData[(int)num].BuildID;
		this.ShowBuildHUD(num, 2);
		DataManager.MissionDataManager.CheckChanged(eMissionKind.Build, this.AllBuildsData[(int)num].BuildID, 0);
		if (buildID >= 1 && buildID <= 7)
		{
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 20 + buildID, (ushort)this.GetBuildNumByID(buildID));
		}
		this.AllBuildsData[(int)num].BuildID = 0;
		this.AllBuildsData[(int)num].Level = 0;
		this.NeedSortData = true;
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Build);
		if (this.OpenUiManorID == num)
		{
			GameConstants.GetBytes(1, DataManager.msgBuffer, 0);
		}
		else
		{
			GameConstants.GetBytes(0, DataManager.msgBuffer, 0);
		}
		GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
		this.BuildingManorID = 0;
		this.UpdateBuildState(3, num);
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0u);
		GameManager.OnRefresh(NetworkNews.Refresh, null);
		DataManager.MissionDataManager.CheckChanged(eMissionKind.Build, buildID, 0);
		if (buildID >= 1 && buildID <= 7)
		{
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, 20 + buildID, (ushort)this.GetBuildNumByID(buildID));
		}
		GUIManager.Instance.HideUILock(EUILock.Build);
	}

	// Token: 0x06001121 RID: 4385 RVA: 0x001E6758 File Offset: 0x001E4958
	private void ShowBuildHUD(ushort ManorID, byte BuildType)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		BuildTypeData recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey(this.AllBuildsData[(int)ManorID].BuildID);
		if (BuildType == 1)
		{
			cstring.IntToFormat((long)this.AllBuildsData[(int)ManorID].Level, 1, false);
			cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.NameID));
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3919u));
		}
		else
		{
			cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.NameID));
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3920u));
		}
		GUIManager.Instance.AddHUDMessage(cstring.ToString(), 1, true);
	}

	// Token: 0x06001122 RID: 4386 RVA: 0x001E6838 File Offset: 0x001E4A38
	public void UpdateBuildState(byte State, ushort Parm)
	{
		DataManager.msgBuffer[0] = 32;
		DataManager.msgBuffer[11] = State;
		GameConstants.GetBytes(Parm, DataManager.msgBuffer, 12);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x0400372F RID: 14127
	private int[] BuildsLevelRequestGroupIndexTbl;

	// Token: 0x04003730 RID: 14128
	private List<byte>[] BuildManorGroupIndexTbl;

	// Token: 0x04003731 RID: 14129
	private ushort[] SortBuildStart;

	// Token: 0x04003732 RID: 14130
	public byte[] BuildIDCount;

	// Token: 0x04003733 RID: 14131
	public bool NeedSortData;

	// Token: 0x04003734 RID: 14132
	public BuildDataComparer buildDataComparer = new BuildDataComparer();

	// Token: 0x04003735 RID: 14133
	public MapSpriteManager mapspriteManager;

	// Token: 0x04003736 RID: 14134
	public ushort BuildingManorID;

	// Token: 0x04003737 RID: 14135
	public ushort OpenUiManorID;

	// Token: 0x04003738 RID: 14136
	public ushort GuideBuildID;

	// Token: 0x04003739 RID: 14137
	public ushort GuideSoldierID;

	// Token: 0x0400373A RID: 14138
	public uint GuideSoldierNum;

	// Token: 0x0400373B RID: 14139
	public byte QueueBuildType;

	// Token: 0x0400373C RID: 14140
	public byte ImmEffect;

	// Token: 0x0400373D RID: 14141
	public RoleBuildingData[] AllBuildsData;

	// Token: 0x0400373E RID: 14142
	public ushort[] SortBuildsData;

	// Token: 0x0400373F RID: 14143
	public Vector3 BuildRot = new Vector3(45f, 185f, 3f);

	// Token: 0x04003740 RID: 14144
	public Vector3 BaseBuildScale = new Vector3(10f, 10f, 10f);

	// Token: 0x04003741 RID: 14145
	private Vector3 GateScale = new Vector3(12f, 12f, 12f);

	// Token: 0x04003742 RID: 14146
	private float SpriteBaseSizeY;

	// Token: 0x04003743 RID: 14147
	private StringBuilder SpriteName = new StringBuilder();

	// Token: 0x04003744 RID: 14148
	public Transform[] ManorGride = new Transform[10];

	// Token: 0x04003745 RID: 14149
	public ushort GuideParm;

	// Token: 0x04003746 RID: 14150
	public byte[] BuildlevelupCheck;

	// Token: 0x04003747 RID: 14151
	private bool bClose;

	// Token: 0x04003748 RID: 14152
	public byte bHideLaboryPromptLock;

	// Token: 0x04003749 RID: 14153
	public CastleSkin castleSkin;

	// Token: 0x0400374A RID: 14154
	private byte _CastleID;
}
