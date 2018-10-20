using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020003F8 RID: 1016
public class MissionManager
{
	// Token: 0x060014B5 RID: 5301 RVA: 0x0023BDE0 File Offset: 0x00239FE0
	public MissionManager()
	{
		this.TimerMissionData = new TimerTypeMission[2];
		for (int i = 0; i < this.TimerMissionData.Length; i++)
		{
			this.TimerMissionData[i] = new TimerTypeMission();
		}
		this.UIManorAimKind = new _UIClassificationTbl[6];
		for (int j = 0; j < this.UIManorAimKind.Length; j++)
		{
			this.UIManorAimKind[j] = new _UIClassificationTbl();
		}
		this.RewardList = new _UIClassificationTbl();
		this.ManorAimMission = new _ManorAimTypeMission[10];
		this.ManorAimMission[0] = new BuildAimMission();
		this.ManorAimMission[1] = new ArmyAimMission(this.DynaMark);
		this.ManorAimMission[2] = new TechAimMission();
		this.ManorAimMission[3] = new NormalAimMission();
		this.ManorAimMission[4] = new AdvanceAimMission();
		this.ManorAimMission[5] = new CropsAimMission();
		this.ManorAimMission[6] = new RecordAimMission();
		this.ManorAimMission[7] = new MarkAimMission(this.DynaMark);
		this.ManorAimMission[8] = new ChallengeAimMission();
		this.ManorAimMission[9] = new ChallengeAdvanceAimMission();
		this.AchievementMgr = DataManager.AchievementMgr;
	}

	// Token: 0x060014B6 RID: 5302 RVA: 0x0023BF74 File Offset: 0x0023A174
	public void LoadTable()
	{
		this.AffairCardinalTable = new CExternalTableWithWordKey<AffairCardinalTbl>();
		this.AllianceCardinalTable = new CExternalTableWithWordKey<AllianceCardinalTbl>();
		this.ManorAimTable = new CExternalTableWithWordKey<ManorAimTbl>();
		this.AffairCardinalTable.LoadTable("QuestWaitR");
		this.AllianceCardinalTable.LoadTable("QuestWaitRA");
		this.ManorAimTable.LoadTable("QuestLand");
		this.AffairNarrativeTable = new CExternalTableWithWordKey<AffairNarrativeTbl>();
		this.AllianceNarrativeTable = new CExternalTableWithWordKey<AffairNarrativeTbl>();
		this.ProbabilityTable = new CExternalTableWithWordKey<ProbabilityTbl>();
		this.AffairNarrativeTable.LoadTable("QuestWaitS");
		this.AllianceNarrativeTable.LoadTable("QuestWaitSA");
		this.ProbabilityTable.LoadTable("QuestWait");
		this.Make();
	}

	// Token: 0x060014B7 RID: 5303 RVA: 0x0023C030 File Offset: 0x0023A230
	private void Make()
	{
		ushort num = 0;
		int tableCount = this.ManorAimTable.TableCount;
		this.RecommandTable.RecommandID = new ushort[65535];
		this.RecommandTable.Achievement = new byte[65535];
		this.RecommandTable.MinIndex = ushort.MaxValue;
		this.RecommandTable.SaveIndex = 1;
		for (int i = 0; i < this.UIManorAimKind.Length; i++)
		{
			if (this.UIManorAimKind[i].Priority.Count > 0)
			{
				this.UIManorAimKind[i].Priority.Clear();
			}
		}
		for (int j = 0; j < this.ManorAimMission.Length; j++)
		{
			this.ManorAimMission[j].ClearAll();
		}
		for (int k = 0; k < tableCount; k++)
		{
			ManorAimTbl recordByIndex = this.ManorAimTable.GetRecordByIndex(k);
			if ((int)(recordByIndex.UIKind - 1) < this.UIManorAimKind.Length)
			{
				this.RecommandTable.RecommandID[(int)recordByIndex.UIPriority] = recordByIndex.ID;
				this.RecommandTable.CheckMin(recordByIndex.UIPriority);
				int num2 = this.UIManorAimKind[(int)(recordByIndex.UIKind - 1)].Priority.BinarySearch(recordByIndex.UIPriority);
				this.UIManorAimKind[(int)(recordByIndex.UIKind - 1)].Priority.Insert(~num2, recordByIndex.UIPriority);
			}
			num = Math.Max(num, recordByIndex.ID);
			if ((int)recordByIndex.MissionKind <= this.ManorAimMission.Length)
			{
				if (recordByIndex.MissionKind <= 10)
				{
					this.ManorAimMission[(int)(recordByIndex.MissionKind - 1)].AddData(recordByIndex.UIPriority, recordByIndex.Parm1, (ushort)recordByIndex.Parm2);
				}
			}
			else
			{
				Debug.Log("Data Error");
			}
		}
		if ((num & 7) > 0)
		{
			this.BoolMark = new byte[(num >> 3) + 1];
		}
		else
		{
			this.BoolMark = new byte[num >> 3];
		}
	}

	// Token: 0x060014B8 RID: 5304 RVA: 0x0023C248 File Offset: 0x0023A448
	public void Reset()
	{
		this.bFirst = 1;
		this.RewardList.Priority.Clear();
		this.RewardList.SaveIndex = 1;
		this.RecommandTable.Reset();
		for (int i = 0; i < this.ManorAimMission.Length; i++)
		{
			this.ManorAimMission[i].Reset();
		}
	}

	// Token: 0x060014B9 RID: 5305 RVA: 0x0023C2AC File Offset: 0x0023A4AC
	public void SetMissionComplete(ushort ID = 132)
	{
		if ((int)ID < this.DynaMark.Length && this.DynaMark[(int)ID] == 0)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.AddSeqId();
			messagePacket.Add(ID);
			messagePacket.Protocol = Protocol._MSG_REQUEST_MISSION_SET;
			messagePacket.Send(false);
		}
	}

	// Token: 0x060014BA RID: 5306 RVA: 0x0023C300 File Offset: 0x0023A500
	public void SetCompleteWhileLogin(eMissionKind Kind)
	{
		this.ManorAimMission[(int)((byte)Kind)].SetCompleteWhileLogin();
		if (Kind == eMissionKind.Army)
		{
			AFAdvanceManager.Instance.CheckTrainTroop();
		}
		if (Kind == eMissionKind.Mark)
		{
			AFAdvanceManager.Instance.CheckCompleteQuest();
		}
		if (Kind == eMissionKind.Mark)
		{
			AFAdvanceManager.Instance.CheckGatherTimber();
		}
		if (Kind == eMissionKind.Mark)
		{
			AFAdvanceManager.Instance.CheckHitMonster();
		}
	}

	// Token: 0x060014BB RID: 5307 RVA: 0x0023C360 File Offset: 0x0023A560
	public bool CheckChanged(eMissionKind Kind, ushort Key, ushort Val)
	{
		if (Kind == eMissionKind.Record && Key == 20)
		{
			this.HeroNum = Val;
			AFAdvanceManager.Instance.CheckHeroCount((ulong)this.HeroNum);
		}
		bool result = this.ManorAimMission[(int)((byte)Kind)].CheckValueChanged(Key, Val);
		if (Kind == eMissionKind.Army && Key >= 1 && Key <= 16)
		{
			AFAdvanceManager.Instance.CheckTrainTroop();
		}
		if (Kind == eMissionKind.Mark && Key == 101)
		{
			AFAdvanceManager.Instance.CheckCompleteQuest();
		}
		if (Kind == eMissionKind.Mark && Key == 126)
		{
			AFAdvanceManager.Instance.CheckGatherTimber();
		}
		if (Kind == eMissionKind.Mark && (Key == 145 || Key == 146))
		{
			AFAdvanceManager.Instance.CheckHitMonster();
		}
		return result;
	}

	// Token: 0x060014BC RID: 5308 RVA: 0x0023C424 File Offset: 0x0023A624
	public ushort GetReCommandMissionID()
	{
		while ((int)this.RecommandTable.SaveIndex <= this.RecommandTable.RecommandID.Length)
		{
			if ((int)this.RecommandTable.SaveIndex == this.RecommandTable.RecommandID.Length || (this.RecommandTable.RecommandID[(int)this.RecommandTable.SaveIndex] > 0 && !this.CheckBoolMark(this.RecommandTable.RecommandID[(int)this.RecommandTable.SaveIndex]) && !this.CheckManorAim(this.RecommandTable.RecommandID[(int)this.RecommandTable.SaveIndex])))
			{
				break;
			}
			this.RecommandTable.SaveIndex = this.RecommandTable.SaveIndex + 1;
		}
		ushort num = 0;
		int num2 = 0;
		DataManager instance = DataManager.Instance;
		BuildsData buildingData = GUIManager.Instance.BuildingData;
		while ((int)(this.RecommandTable.SaveIndex + num) < this.RecommandTable.RecommandID.Length)
		{
			ushort num3 = this.RecommandTable.RecommandID[(int)(this.RecommandTable.SaveIndex + num)];
			if (num3 == 0)
			{
				num += 1;
			}
			else
			{
				ManorAimTbl recordByKey = this.ManorAimTable.GetRecordByKey(num3);
				if (!this.CheckBoolMark(recordByKey.ID) && !this.CheckManorAim(recordByKey.ID))
				{
					switch (recordByKey.MissionKind)
					{
					case 1:
						if (buildingData.AllBuildsData[(int)buildingData.BuildingManorID].BuildID == recordByKey.Parm1 && (long)(buildingData.AllBuildsData[(int)buildingData.BuildingManorID].Level + 1) == (long)((ulong)recordByKey.Parm2) && buildingData.QueueBuildType == 1 && (num2 & 1) == 0)
						{
							num2 |= 1;
							num += 1;
							continue;
						}
						break;
					case 2:
						if (recordByKey.Parm1 <= 16)
						{
							if (instance.queueBarData[10].bActive && (ushort)(4 * instance.SoldierKind + instance.SoldierRank + 1) == recordByKey.Parm1 && (num2 & 4) == 0)
							{
								num2 |= 4;
								num += 1;
								continue;
							}
						}
						else if (instance.queueBarData[14].bActive && (ushort)(4 * instance.TrapKind + instance.TrapRank + 17) == recordByKey.Parm1 && (num2 & 8) == 0)
						{
							num2 |= 8;
							num += 1;
							continue;
						}
						break;
					case 3:
						if (instance.ResearchTech == recordByKey.Parm1 && (num2 & 2) == 0)
						{
							num2 |= 2;
							num += 1;
							continue;
						}
						break;
					case 7:
					{
						eRecordKind parm = (eRecordKind)recordByKey.Parm1;
						if (parm >= eRecordKind.CollectionWood && parm <= eRecordKind.CollectTreament && (num2 & 16) == 0 && buildingData.AllBuildsData[(int)buildingData.BuildingManorID].BuildID == recordByKey.Parm1 - 21 + 1 && buildingData.QueueBuildType == 1)
						{
							num2 |= 16;
							num += 1;
							continue;
						}
						break;
					}
					}
					break;
				}
				num += 1;
			}
		}
		if ((int)(this.RecommandTable.SaveIndex + num) == this.RecommandTable.RecommandID.Length)
		{
			return ushort.MaxValue;
		}
		return this.RecommandTable.RecommandID[(int)(this.RecommandTable.SaveIndex + num)];
	}

	// Token: 0x060014BD RID: 5309 RVA: 0x0023C7C0 File Offset: 0x0023A9C0
	public _eMarkAimNarrativeType GetMarkNarrativeType(ushort MarkID)
	{
		_eMarkAimNarrativeType result;
		if (MarkID != 101 && MarkID != 102)
		{
			result = _eMarkAimNarrativeType.Once;
		}
		else
		{
			result = _eMarkAimNarrativeType.Accumlate;
		}
		return result;
	}

	// Token: 0x060014BE RID: 5310 RVA: 0x0023C7F4 File Offset: 0x0023A9F4
	public void GetNarrative(CString NarrativeStr, ref ManorAimTbl ManorData)
	{
		DataManager instance = DataManager.Instance;
		NarrativeStr.ClearString();
		switch (ManorData.MissionKind)
		{
		case 1:
		{
			ushort id = instance.BuildsTypeData.GetRecordByKey(ManorData.Parm1).NameID;
			NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint)id));
			NarrativeStr.IntToFormat((long)((ulong)ManorData.Parm2), 1, false);
			NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint)ManorData.Narrative));
			break;
		}
		case 2:
		{
			ushort id = instance.SoldierDataTable.GetRecordByKey(ManorData.Parm1).Name;
			NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint)id));
			NarrativeStr.IntToFormat((long)((ulong)ManorData.Parm2), 1, false);
			NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint)ManorData.Narrative));
			break;
		}
		case 3:
		{
			TechDataTbl recordByKey = instance.TechData.GetRecordByKey(ManorData.Parm1);
			NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey.TechName));
			if (ManorData.Narrative == 8053)
			{
				NarrativeStr.IntToFormat((long)((ulong)ManorData.Parm2), 1, false);
			}
			NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint)ManorData.Narrative));
			break;
		}
		case 4:
		case 5:
		case 9:
		case 10:
		{
			CString cstring = StringManager.Instance.StaticString1024();
			int num = (int)((ManorData.Parm1 - 1) / 6 + 1);
			cstring.IntToFormat((long)num, 1, false);
			cstring.IntToFormat((long)((int)(ManorData.Parm1 * 3) - (num - 1) * 18), 1, false);
			cstring.AppendFormat("{0}-{1}");
			NarrativeStr.StringToFormat(cstring);
			NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint)ManorData.Narrative));
			break;
		}
		case 6:
		{
			ushort id = DataManager.StageDataController.CorpsStageTable.GetRecordByKey(ManorData.Parm1).StageName;
			NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint)id));
			NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint)ManorData.Narrative));
			break;
		}
		case 7:
		{
			eRecordKind parm = (eRecordKind)ManorData.Parm1;
			switch (parm)
			{
			case eRecordKind.CollectionWood:
			case eRecordKind.CollectionRock:
			case eRecordKind.CollectionSteel:
			case eRecordKind.CollectionGrain:
			case eRecordKind.CollectionMoney:
			case eRecordKind.CollectBarrack:
			case eRecordKind.CollectTreament:
			{
				NarrativeStr.IntToFormat((long)((ulong)ManorData.Parm2), 1, true);
				BuildTypeData recordByKey2 = instance.BuildsTypeData.GetRecordByKey(ManorData.Parm1 - 20);
				NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey2.NameID));
				break;
			}
			default:
				switch (parm)
				{
				case eRecordKind.Grain:
				case eRecordKind.Rock:
				case eRecordKind.Wood:
				case eRecordKind.Steel:
				case eRecordKind.Money:
					NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint)(ManorData.Parm1 + 3951)));
					NarrativeStr.IntToFormat((long)((ulong)ManorData.Parm2), 1, true);
					break;
				default:
					NarrativeStr.IntToFormat((long)((ulong)ManorData.Parm2), 1, true);
					break;
				}
				break;
			}
			NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint)ManorData.Narrative));
			break;
		}
		case 8:
			if (ManorData.Parm1 == 103 || ManorData.Parm1 == 104 || (ManorData.Parm1 >= 108 && ManorData.Parm1 <= 110) || ManorData.Parm1 == 113 || ManorData.Parm1 == 115 || ManorData.Parm1 == 116 || ManorData.Parm1 == 129 || ManorData.Parm1 == 130 || ManorData.Parm1 == 185 || ManorData.Parm1 == 186 || ManorData.Parm1 == 187 || (ManorData.Parm1 >= 134 && ManorData.Parm1 <= 154))
			{
				NarrativeStr.IntToFormat((long)((ulong)ManorData.Parm2), 1, false);
				NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint)ManorData.Narrative));
			}
			else if (ManorData.Parm1 >= 124 && ManorData.Parm1 <= 128)
			{
				NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint)(3951 + ManorData.Parm1 - 123)));
				NarrativeStr.IntToFormat((long)((ulong)ManorData.Parm2), 1, false);
				NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint)ManorData.Narrative));
			}
			else if (ManorData.Parm1 >= 160 && ManorData.Parm1 <= 184)
			{
				NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint)instance.NPCPrize.GetRecordByKey(ManorData.Parm1 - 159).Element));
				NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint)ManorData.Narrative));
			}
			else if (ManorData.Parm1 == 118 || ManorData.Parm1 == 155 || this.GetMarkNarrativeType(ManorData.Parm1) == _eMarkAimNarrativeType.Accumlate)
			{
				NarrativeStr.IntToFormat((long)((ulong)ManorData.Parm2), 1, false);
				NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint)ManorData.Narrative));
			}
			else
			{
				NarrativeStr.Append(instance.mStringTable.GetStringByID((uint)ManorData.Narrative));
			}
			break;
		}
	}

	// Token: 0x060014BF RID: 5311 RVA: 0x0023CD68 File Offset: 0x0023AF68
	public void GetManorAimGuide(ushort ID)
	{
		ManorAimTbl recordByKey = this.ManorAimTable.GetRecordByKey(ID);
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		StageManager stageDataController = DataManager.StageDataController;
		switch (recordByKey.MissionKind)
		{
		case 1:
			instance2.BuildingData.ManorGuild(recordByKey.Parm1, true);
			break;
		case 2:
			if (recordByKey.Parm1 < 17)
			{
				instance2.BuildingData.ManorGuild(6, false);
			}
			else
			{
				instance2.BuildingData.ManorGuild(12, false);
			}
			instance2.BuildingData.GuideSoldierID = recordByKey.Parm1;
			instance2.BuildingData.GuideSoldierNum = recordByKey.Parm2;
			break;
		case 3:
			instance2.GuideParm1 = 3;
			instance2.GuideParm2 = recordByKey.Parm1;
			instance2.OpenTechTree(instance2.GuideParm2, false);
			break;
		case 4:
		{
			byte currentChapterID = stageDataController.currentChapterID;
			StageMode stageMode = stageDataController._stageMode;
			stageDataController.currentChapterID = (byte)((recordByKey.Parm1 - 1) / GameConstants.StagePointNum[1]);
			stageDataController._stageMode = StageMode.Full;
			if ((ushort)stageDataController.currentChapterID >= stageDataController.StageRecord[2])
			{
				instance2.AddHUDMessage(instance.mStringTable.GetStringByID(668u), 255, true);
				stageDataController.currentChapterID = currentChapterID;
				stageDataController._stageMode = stageMode;
			}
			else
			{
				if ((ushort)stageDataController.currentChapterID > stageDataController.StageRecord[0] / GameConstants.StagePointNum[0])
				{
					stageDataController.currentChapterID = (byte)(stageDataController.StageRecord[0] / GameConstants.StagePointNum[0]);
				}
				StageManager stageManager = stageDataController;
				stageManager.currentChapterID += 1;
				stageDataController.currentPointID = (ushort)(stageDataController.currentChapterID - 1) * GameConstants.StagePointNum[(int)stageDataController._stageMode] + 1;
				stageDataController.SaveUserStage(stageDataController._stageMode);
				stageDataController.SaveUserStageMode(stageDataController._stageMode);
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.DoorOpenUp);
			}
			break;
		}
		case 5:
		{
			byte currentChapterID2 = stageDataController.currentChapterID;
			StageMode stageMode2 = stageDataController._stageMode;
			stageDataController.currentChapterID = (byte)((recordByKey.Parm1 - 1) / GameConstants.StagePointNum[1]);
			stageDataController._stageMode = StageMode.Lean;
			if ((ushort)stageDataController.currentChapterID >= stageDataController.StageRecord[2])
			{
				instance2.AddHUDMessage(instance.mStringTable.GetStringByID(668u), 255, true);
				stageDataController.currentChapterID = currentChapterID2;
				stageDataController._stageMode = stageMode2;
			}
			else if (stageDataController.StageRecord[0] / GameConstants.StagePointNum[0] <= (ushort)stageDataController.currentChapterID)
			{
				instance2.AddHUDMessage(instance.mStringTable.GetStringByID(1593u), 255, true);
				stageDataController.currentChapterID = currentChapterID2;
				stageDataController._stageMode = stageMode2;
			}
			else
			{
				if ((ushort)stageDataController.currentChapterID > stageDataController.StageRecord[1] / GameConstants.StagePointNum[1])
				{
					stageDataController.currentChapterID = (byte)(stageDataController.StageRecord[1] / GameConstants.StagePointNum[1]);
				}
				StageManager stageManager2 = stageDataController;
				stageManager2.currentChapterID += 1;
				stageDataController.currentPointID = (ushort)(stageDataController.currentChapterID - 1) * GameConstants.StagePointNum[(int)stageDataController._stageMode] + 1;
				stageDataController.SaveUserStage(stageDataController._stageMode);
				stageDataController.SaveUserStageMode(stageDataController._stageMode);
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.DoorOpenUp);
			}
			break;
		}
		case 6:
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				door.OnButtonClick(door.m_BattleButton);
			}
			break;
		}
		case 7:
			if (recordByKey.Parm1 == 7)
			{
				Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				DataManager.Instance.SetSelectRequest = 0;
				door2.OpenMenu(EGUIWindow.UI_AllianceHint, 0, 0, false);
			}
			else if (recordByKey.Parm1 == 19)
			{
				instance2.BuildingData.ManorGuild(12, false);
				instance2.BuildingData.GuideSoldierID = 30;
			}
			else if (recordByKey.Parm1 >= 21 && recordByKey.Parm1 <= 27)
			{
				GUIManager.Instance.BuildingData.EmptyManorGuide(recordByKey.Parm1 - 20, true);
			}
			break;
		case 8:
			if (recordByKey.Parm1 == 131)
			{
				if (!NewbieManager.CheckRename(false))
				{
					DataManager.Instance.CheckUseItem(1006, 0, 0, 0);
				}
			}
			else if (recordByKey.Parm1 == 132)
			{
				Door door3 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				instance2.GuideArrow((RectTransform)door3.m_MapSwitchButton.transform, ArrowDirect.Ar_Up, 10f);
			}
			break;
		case 9:
		case 10:
		{
			byte currentChapterID3 = stageDataController.currentChapterID;
			StageMode stageMode3 = stageDataController._stageMode;
			stageDataController.currentChapterID = (byte)((recordByKey.Parm1 - 1) / GameConstants.StagePointNum[1]);
			stageDataController._stageMode = StageMode.Dare;
			if ((ushort)stageDataController.currentChapterID > stageDataController.StageRecord[3] / GameConstants.StagePointNum[3])
			{
				stageDataController.currentChapterID = (byte)(stageDataController.StageRecord[3] / GameConstants.StagePointNum[3]);
			}
			StageManager stageManager3 = stageDataController;
			stageManager3.currentChapterID += 1;
			stageDataController.currentPointID = (ushort)(stageDataController.currentChapterID - 1) * GameConstants.StagePointNum[(int)stageDataController._stageMode] + 1;
			stageDataController.SaveUserStage(stageDataController._stageMode);
			stageDataController.SaveUserStageMode(stageDataController._stageMode);
			GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.DoorOpenUp);
			break;
		}
		}
	}

	// Token: 0x060014C0 RID: 5312 RVA: 0x0023D2C4 File Offset: 0x0023B4C4
	public void UpdateReCommandSaveIndex(ushort index)
	{
		if (this.RecommandTable.SaveIndex > index && !this.CheckBoolMark(this.RecommandTable.RecommandID[(int)index]))
		{
			this.RecommandTable.SaveIndex = index;
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
		}
	}

	// Token: 0x060014C1 RID: 5313 RVA: 0x0023D314 File Offset: 0x0023B514
	public ushort GetUIMissionItemKind(eUIMissionKind Kind, ref int beginID)
	{
		List<ushort> priority = this.UIManorAimKind[(int)((byte)Kind)].Priority;
		ushort reCommandMissionID = this.GetReCommandMissionID();
		for (int i = beginID; i < priority.Count; i++)
		{
			ushort missionID = this.GetMissionID(priority[i]);
			if (missionID == 0)
			{
				return ushort.MaxValue;
			}
			if (reCommandMissionID != missionID && !this.CheckBoolMark(missionID) && !this.CheckManorAim(missionID))
			{
				beginID = i + 1;
				return missionID;
			}
		}
		return ushort.MaxValue;
	}

	// Token: 0x060014C2 RID: 5314 RVA: 0x0023D394 File Offset: 0x0023B594
	public ushort GetMissionID(ushort priority)
	{
		return this.RecommandTable.RecommandID[(int)priority];
	}

	// Token: 0x060014C3 RID: 5315 RVA: 0x0023D3A4 File Offset: 0x0023B5A4
	public bool CheckBoolMark(ushort ID)
	{
		if (ID == 0)
		{
			return false;
		}
		int num = (ID -= 1) >> 3;
		int num2 = (int)(ID & 7);
		return ((int)this.BoolMark[num] & 1 << num2) > 0;
	}

	// Token: 0x060014C4 RID: 5316 RVA: 0x0023D3E4 File Offset: 0x0023B5E4
	private void SetBoolMark(ushort ID)
	{
		if (ID == 0)
		{
			return;
		}
		int num = (ID -= 1) >> 3;
		int num2 = (int)(ID & 7);
		byte[] boolMark = this.BoolMark;
		int num3 = num;
		boolMark[num3] |= (byte)(1 << num2);
	}

	// Token: 0x060014C5 RID: 5317 RVA: 0x0023D420 File Offset: 0x0023B620
	private bool CheckManorAim(ushort ID)
	{
		DataManager instance = DataManager.Instance;
		ManorAimTbl recordByKey = this.ManorAimTable.GetRecordByKey(ID);
		switch (recordByKey.MissionKind)
		{
		case 1:
		{
			RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(recordByKey.Parm1, 0);
			if (buildData.BuildID == 0)
			{
				return false;
			}
			if ((uint)buildData.Level >= recordByKey.Parm2)
			{
				return true;
			}
			break;
		}
		case 2:
			if ((uint)this.DynaMark[(int)recordByKey.Parm1] >= recordByKey.Parm2)
			{
				return true;
			}
			break;
		case 3:
			if ((uint)instance.GetTechLevel(recordByKey.Parm1) >= recordByKey.Parm2)
			{
				return true;
			}
			break;
		case 4:
			if (DataManager.StageDataController.StageRecord[0] >= recordByKey.Parm1 * 3)
			{
				return true;
			}
			break;
		case 5:
			if (DataManager.StageDataController.StageRecord[1] >= recordByKey.Parm1)
			{
				return true;
			}
			break;
		case 6:
			if (DataManager.StageDataController.StageRecord[2] >= recordByKey.Parm1)
			{
				return true;
			}
			break;
		case 7:
		{
			eRecordKind parm = (eRecordKind)recordByKey.Parm1;
			if (parm >= eRecordKind.Grain && parm <= eRecordKind.Money)
			{
				if (this.UpdateResourceInfo((ResourceType)(recordByKey.Parm1 - 1)) >= (long)((ulong)recordByKey.Parm2))
				{
					return true;
				}
			}
			else if (parm == eRecordKind.Level)
			{
				if ((uint)instance.RoleAttr.Level >= recordByKey.Parm2)
				{
					return true;
				}
			}
			else if (parm == eRecordKind.Alliance)
			{
				if (instance.RoleAlliance.Id > 0u)
				{
					return true;
				}
			}
			else if (parm >= eRecordKind.Enhance2 && parm <= eRecordKind.Enhance12)
			{
				RecordAimMission recordAimMission = this.ManorAimMission[6] as RecordAimMission;
				if ((uint)recordAimMission.HeroEnhanceNum[parm - eRecordKind.Enhance2] >= recordByKey.Parm2)
				{
					return true;
				}
			}
			else if (parm == eRecordKind.DefenderHero)
			{
				RecordAimMission recordAimMission2 = this.ManorAimMission[6] as RecordAimMission;
				if ((uint)recordAimMission2.DefenderNum >= recordByKey.Parm2)
				{
					return true;
				}
			}
			else if (parm == eRecordKind.HeroNum)
			{
				if (instance.CurHeroDataCount >= recordByKey.Parm2)
				{
					return true;
				}
			}
			else if (parm >= eRecordKind.CollectionWood && parm <= eRecordKind.CollectTreament)
			{
				byte buildNumByID = GUIManager.Instance.BuildingData.GetBuildNumByID((ushort)(parm - eRecordKind.CollectionWood + 1));
				if ((uint)buildNumByID >= recordByKey.Parm2)
				{
					return true;
				}
			}
			else if (parm == eRecordKind.ArneaStartHero)
			{
				if ((uint)ArenaManager.Instance.GetHeroAstrologyNum() >= recordByKey.Parm2)
				{
					return true;
				}
			}
			else if (parm == eRecordKind.ArneaHiRank)
			{
				if (ArenaManager.Instance.m_ArenaHistoryPlace <= recordByKey.Parm2)
				{
					return true;
				}
			}
			else if (parm == eRecordKind.PetCount && (uint)PetManager.Instance.PetDataCount >= recordByKey.Parm2)
			{
				return true;
			}
			break;
		}
		case 8:
			if (this.DynaMark.Length > (int)recordByKey.Parm1 && (uint)this.DynaMark[(int)recordByKey.Parm1] >= recordByKey.Parm2)
			{
				return true;
			}
			break;
		case 9:
			if (DataManager.StageDataController.StageRecord[3] >= recordByKey.Parm1 * 3)
			{
				return true;
			}
			break;
		case 10:
			if (DataManager.StageDataController.StageRecord[3] >= recordByKey.Parm1 * 3 && (long)DataManager.StageDataController.GetStagePoint(recordByKey.Parm1 * 3, 3) >= (long)((ulong)recordByKey.Parm2))
			{
				return true;
			}
			break;
		}
		return false;
	}

	// Token: 0x060014C6 RID: 5318 RVA: 0x0023D7B4 File Offset: 0x0023B9B4
	public void AddRewardMission(ushort Priority)
	{
		ushort missionID = this.GetMissionID(Priority);
		if (this.CheckBoolMark(missionID) || !this.CheckManorAim(missionID))
		{
			return;
		}
		int num = this.RewardList.Priority.BinarySearch(Priority);
		if (num < 0)
		{
			if (this.RewardList.Priority.Count == 0)
			{
				this.RewardList.Priority.Add(Priority);
			}
			else
			{
				this.RewardList.Priority.Insert(~num, Priority);
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
		}
	}

	// Token: 0x060014C7 RID: 5319 RVA: 0x0023D848 File Offset: 0x0023BA48
	public byte GetRewardCount(int MaxCount)
	{
		byte b = 0;
		for (int i = 0; i < this.RewardList.Priority.Count; i++)
		{
			if ((int)b == MaxCount)
			{
				return b;
			}
			ushort missionID = this.GetMissionID(this.RewardList.Priority[(int)b]);
			if (this.CheckBoolMark(missionID) || !this.CheckManorAim(missionID))
			{
				this.RewardList.Priority.Remove(this.RewardList.Priority[(int)b]);
				i--;
			}
			else
			{
				b += 1;
			}
		}
		return b;
	}

	// Token: 0x060014C8 RID: 5320 RVA: 0x0023D8E4 File Offset: 0x0023BAE4
	public TimerTypeMission GetTimerMissionData(_eMissionType Type)
	{
		if (Type == _eMissionType.Affair)
		{
			return this.TimerMissionData[0];
		}
		return this.TimerMissionData[1];
	}

	// Token: 0x060014C9 RID: 5321 RVA: 0x0023D900 File Offset: 0x0023BB00
	public CString FormatMissionTime(uint time)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		TimeSpan timeSpan = new TimeSpan((long)((ulong)time * 10000000UL));
		if (timeSpan.Hours > 0)
		{
			cstring.IntToFormat((long)timeSpan.Hours, 2, false);
			cstring.IntToFormat((long)timeSpan.Minutes, 2, false);
			cstring.IntToFormat((long)timeSpan.Seconds, 2, false);
			cstring.AppendFormat("{0}:{1}:{2}");
		}
		else
		{
			cstring.IntToFormat((long)timeSpan.Minutes, 2, false);
			cstring.IntToFormat((long)timeSpan.Seconds, 2, false);
			cstring.AppendFormat("{0}:{1}");
		}
		return cstring;
	}

	// Token: 0x060014CA RID: 5322 RVA: 0x0023D9A8 File Offset: 0x0023BBA8
	public byte GetTotalAccessMissionCount()
	{
		byte b = 0;
		for (int i = 0; i < this.AccessMissionCount.Length; i++)
		{
			if (i != 2 || DataManager.Instance.RoleAlliance.Id != 0u)
			{
				b += this.AccessMissionCount[i];
			}
		}
		return b;
	}

	// Token: 0x060014CB RID: 5323 RVA: 0x0023DA00 File Offset: 0x0023BC00
	public long UpdateResourceInfo(ResourceType Type)
	{
		AttribValManager attribVal = DataManager.Instance.AttribVal;
		long num = 0L;
		uint num2 = 0u;
		uint num3 = 0u;
		switch (Type)
		{
		case ResourceType.Grain:
			num = (long)((ulong)(attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_FOOD_PRODUCTION) + 1000u));
			num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_FOOD_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
			num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_FOOD_PRODUCTION_PERCENT_DEBUFF);
			break;
		case ResourceType.Rock:
			num = (long)((ulong)(attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ROCK_PRODUCTION) + 1000u));
			num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ROCK_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
			num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ROCK_PRODUCTION_PERCENT_DEBUFF);
			break;
		case ResourceType.Wood:
			num = (long)((ulong)(attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_WOOD_PRODUCTION) + 1000u));
			num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_WOOD_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
			num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_WOOD_PRODUCTION_PERCENT_DEBUFF);
			break;
		case ResourceType.Steel:
			num = (long)((ulong)(attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_STEEL_PRODUCTION) + 1000u));
			num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_STEEL_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
			num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_STEEL_PRODUCTION_PERCENT_DEBUFF);
			break;
		case ResourceType.Money:
			num = (long)((ulong)attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MONEY_PRODUCTION));
			num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MONEY_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
			num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MONEY_PRODUCTION_PERCENT_DEBUFF);
			break;
		}
		if (num3 > num2)
		{
			uint num4 = num3 - num2;
			if (num4 > 9900u)
			{
				num4 = 9900u;
			}
			num = 10000L * num - num * (long)((ulong)num4);
		}
		else
		{
			uint num4 = num2 - num3;
			num = 10000L * num + num * (long)((ulong)num4);
		}
		num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_CURSE);
		if (num3 > 9900u)
		{
			num3 = 9900u;
		}
		num = 10000L * num - num * (long)((ulong)num3);
		return num / 100000000L;
	}

	// Token: 0x060014CC RID: 5324 RVA: 0x0023DBE4 File Offset: 0x0023BDE4
	public void UpdateVipState()
	{
		DataManager instance = DataManager.Instance;
		VIP_DataTbl recordByKey = instance.VIPLevelTable.GetRecordByKey((ushort)instance.RoleAttr.VIPLevel);
		this.VipAutoComplete[0] = recordByKey.AutoDailyMission;
		this.VipAutoComplete[1] = recordByKey.AutoDailyAlliMission;
		if (this.VipAutoComplete[0] == 1)
		{
			TimerTypeMission timerMissionData = this.GetTimerMissionData(_eMissionType.Affair);
			for (int i = 0; i < (int)timerMissionData.MissionCount; i++)
			{
				if (timerMissionData.TimeMission[i].State == _eTimerMissionState.Countdown)
				{
					byte[] accessMissionCount = this.AccessMissionCount;
					int num = 1;
					accessMissionCount[num] += 1;
				}
				if (timerMissionData.TimeMission[i].State == _eTimerMissionState.Wait || timerMissionData.TimeMission[i].State == _eTimerMissionState.Countdown)
				{
					timerMissionData.TimeMission[i].State = _eTimerMissionState.AutoComplete;
				}
			}
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.AffairMission, false, 0L, 0u);
		}
		if (this.VipAutoComplete[1] == 1)
		{
			TimerTypeMission timerMissionData = this.GetTimerMissionData(_eMissionType.Alliance);
			for (int j = 0; j < (int)timerMissionData.MissionCount; j++)
			{
				if (timerMissionData.TimeMission[j].State == _eTimerMissionState.Countdown)
				{
					byte[] accessMissionCount2 = this.AccessMissionCount;
					int num2 = 2;
					accessMissionCount2[num2] += 1;
				}
				if (timerMissionData.TimeMission[j].State == _eTimerMissionState.Wait || timerMissionData.TimeMission[j].State == _eTimerMissionState.Countdown)
				{
					timerMissionData.TimeMission[j].State = _eTimerMissionState.AutoComplete;
				}
			}
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.AllianceMission, false, 0L, 0u);
		}
		this.VipBoxStateMax = 0;
		for (int k = 0; k < this.VipLvRestrict.Length; k++)
		{
			if (this.VipLvRestrict[k] > instance.RoleAttr.VIPLevel)
			{
				break;
			}
			this.VipBoxStateMax |= (byte)(1 << k);
		}
		this.UpdateVipTime();
		this.UpdateVipCount();
	}

	// Token: 0x060014CD RID: 5325 RVA: 0x0023DDE8 File Offset: 0x0023BFE8
	public void Update(float delta)
	{
		int num = 0;
		int num2 = 0;
		long serverTime = DataManager.Instance.ServerTime;
		for (int i = 0; i < this.TimerMissionData.Length; i++)
		{
			if (!NewbieManager.IsNewbie && this.TimerMissionData[i].ResetTime > 0L && this.TimerMissionData[i].ResetTime < serverTime)
			{
				this.TimerMissionData[i].ResetTime = -1L;
				if (i == 0 || i == 1)
				{
					MessagePacket messagePacket = new MessagePacket(1024);
					messagePacket.AddSeqId();
					messagePacket.Add((byte)(i + 1));
					messagePacket.Protocol = Protocol._MSG_REQUEST_MISSIONINFO;
					messagePacket.Send(false);
				}
			}
			if (this.TimerMissionData[i].MissionTime > 0L && this.TimerMissionData[i].MissionTime <= serverTime && this.TimerMissionData[i].TimeMission.Length > (int)this.TimerMissionData[i].ProcessIdx)
			{
				this.TimerMissionData[i].MissionTime = -1L;
				this.TimerMissionData[i].TimeMission[(int)this.TimerMissionData[i].ProcessIdx].State = _eTimerMissionState.Reward;
				num |= 1;
				this.MissionNotice |= (byte)(1 << i + 1);
				num2 = i + 1;
				DataManager instance = DataManager.Instance;
				if (i == 0)
				{
					GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(7942u), 25, true);
					instance.SetQueueBarData(EQueueBarIndex.AffairMission, false, 0L, 0u);
				}
				else
				{
					GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(7943u), 25, true);
					instance.SetQueueBarData(EQueueBarIndex.AllianceMission, false, 0L, 0u);
				}
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
			}
		}
		if (num2 > 0)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, num, num2);
		}
		if (this.VipBoxState != this.VipBoxStateMax && serverTime - this.VipRewardStartTime >= 3600L && (this.MissionNotice >> 3 & 1) == 0)
		{
			this.MissionNotice |= 8;
			this.UpdateVipTime();
			if (this.bFirst == 0)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7944u), 11, true);
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, 4, 3);
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
		}
		if (this.bFirst == 255)
		{
			this.bFirst = 0;
		}
		this.AchievementMgr.Update(delta);
	}

	// Token: 0x060014CE RID: 5326 RVA: 0x0023E078 File Offset: 0x0023C278
	public void UpdateTimeMissionTime(byte QueuebarIndex)
	{
		DataManager instance = DataManager.Instance;
		byte b = QueuebarIndex - 19;
		this.TimerMissionData[(int)b].MissionTime = instance.queueBarData[(int)QueuebarIndex].StartTime + (long)((ulong)instance.queueBarData[(int)QueuebarIndex].TotalTime);
		if (this.TimerMissionData[(int)b].MissionTime <= instance.ServerTime)
		{
			this.Update(0f);
		}
	}

	// Token: 0x060014CF RID: 5327 RVA: 0x0023E0E8 File Offset: 0x0023C2E8
	public void RecvTimeMissionInfo(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = 0;
		if (b == 1)
		{
			if (this.TimerMissionData[(int)b2].ResetTime < 0L)
			{
				this.TimerMissionData[(int)b2].ResetTime = DataManager.Instance.ServerTime + 2L;
			}
			else
			{
				this.TimerMissionData[1].ResetTime = DataManager.Instance.ServerTime + 2L;
			}
			return;
		}
		b2 = MP.ReadByte(-1) - 1;
		if ((int)b2 >= this.TimerMissionData.Length)
		{
			return;
		}
		byte b3 = b2 + 1;
		this.TimerMissionData[(int)b2].ResetTime = MP.ReadLong(-1);
		this.TimerMissionData[(int)b2].MissionTime = MP.ReadLong(-1);
		this.TimerMissionData[(int)b2].MissionCount = MP.ReadByte(-1);
		this.TimerMissionData[(int)b2].ProcessIdx = byte.MaxValue;
		this.AccessMissionCount[(int)b3] = 0;
		this.MissionNotice = (byte)((int)this.MissionNotice & ~(1 << (int)b3));
		for (byte b4 = 0; b4 < this.TimerMissionData[(int)b2].MissionCount; b4 += 1)
		{
			this.TimerMissionData[(int)b2].TimeMission[(int)b4].Index = b4;
			this.TimerMissionData[(int)b2].TimeMission[(int)b4].ID = MP.ReadUShort(-1);
			this.TimerMissionData[(int)b2].TimeMission[(int)b4].Quality = MP.ReadUShort(-1);
			this.TimerMissionData[(int)b2].TimeMission[(int)b4].Base = MP.ReadUShort(-1);
			this.TimerMissionData[(int)b2].TimeMission[(int)b4].ItemID = MP.ReadUShort(-1);
			this.TimerMissionData[(int)b2].TimeMission[(int)b4].State = (_eTimerMissionState)MP.ReadByte(-1);
			if (this.VipAutoComplete[(int)b2] == 1 && (this.TimerMissionData[(int)b2].TimeMission[(int)b4].State == _eTimerMissionState.Wait || this.TimerMissionData[(int)b2].TimeMission[(int)b4].State == _eTimerMissionState.Countdown))
			{
				byte[] accessMissionCount = this.AccessMissionCount;
				byte b5 = b3;
				accessMissionCount[(int)b5] = accessMissionCount[(int)b5] + 1;
				this.TimerMissionData[(int)b2].TimeMission[(int)b4].State = _eTimerMissionState.AutoComplete;
			}
			else if (this.TimerMissionData[(int)b2].TimeMission[(int)b4].State == _eTimerMissionState.Wait)
			{
				byte[] accessMissionCount2 = this.AccessMissionCount;
				byte b6 = b3;
				accessMissionCount2[(int)b6] = accessMissionCount2[(int)b6] + 1;
			}
			else if (this.TimerMissionData[(int)b2].TimeMission[(int)b4].State == _eTimerMissionState.Reward)
			{
				this.TimerMissionData[(int)b2].MissionTime = -1L;
				this.MissionNotice |= (byte)(1 << (int)b3);
				if (b2 == 0)
				{
					DataManager.Instance.SetQueueBarData(EQueueBarIndex.AffairMission, false, 0L, 0u);
				}
				else
				{
					DataManager.Instance.SetQueueBarData(EQueueBarIndex.AllianceMission, false, 0L, 0u);
				}
			}
			else if (this.TimerMissionData[(int)b2].TimeMission[(int)b4].State == _eTimerMissionState.Countdown)
			{
				this.TimerMissionData[(int)b2].ProcessIdx = b4;
				if (b2 == 0)
				{
					AffairNarrativeTbl recordByIndex = this.AffairNarrativeTable.GetRecordByIndex((int)this.TimerMissionData[(int)b2].TimeMission[(int)b4].ID);
					DataManager.Instance.SetQueueBarData(EQueueBarIndex.AffairMission, true, this.TimerMissionData[(int)b2].MissionTime - (long)recordByIndex.TotalTime, (uint)recordByIndex.TotalTime);
					DataManager.Instance.SetRecvQueueBarData(19);
				}
				else
				{
					AffairNarrativeTbl recordByIndex2 = this.AllianceNarrativeTable.GetRecordByIndex((int)this.TimerMissionData[(int)b2].TimeMission[(int)b4].ID);
					DataManager.Instance.SetQueueBarData(EQueueBarIndex.AllianceMission, true, this.TimerMissionData[(int)b2].MissionTime - (long)recordByIndex2.TotalTime, (uint)recordByIndex2.TotalTime);
					DataManager.Instance.SetRecvQueueBarData(20);
				}
			}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, 4, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
		GUIManager.Instance.HideUILock(EUILock.Mission);
	}

	// Token: 0x060014D0 RID: 5328 RVA: 0x0023E4EC File Offset: 0x0023C6EC
	public void RecvTimeMissionStart(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1) - 1;
		byte b2 = MP.ReadByte(-1);
		if (b2 == 0)
		{
			return;
		}
		if ((int)b >= this.TimerMissionData.Length)
		{
			return;
		}
		byte b3 = b + 1;
		byte[] accessMissionCount = this.AccessMissionCount;
		byte b4 = b3;
		accessMissionCount[(int)b4] = accessMissionCount[(int)b4] - 1;
		this.TimerMissionData[(int)b].ProcessIdx = b2 - 1;
		this.TimerMissionData[(int)b].MissionTime = MP.ReadLong(-1);
		this.TimerMissionData[(int)b].TimeMission[(int)this.TimerMissionData[(int)b].ProcessIdx].State = _eTimerMissionState.Countdown;
		if (b == 0)
		{
			AffairNarrativeTbl recordByIndex = this.AffairNarrativeTable.GetRecordByIndex((int)this.TimerMissionData[(int)b].TimeMission[(int)this.TimerMissionData[(int)b].ProcessIdx].ID);
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.AffairMission, true, this.TimerMissionData[(int)b].MissionTime - (long)recordByIndex.TotalTime, (uint)recordByIndex.TotalTime);
		}
		else
		{
			AffairNarrativeTbl recordByIndex = this.AllianceNarrativeTable.GetRecordByIndex((int)this.TimerMissionData[(int)b].TimeMission[(int)this.TimerMissionData[(int)b].ProcessIdx].ID);
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.AllianceMission, true, this.TimerMissionData[(int)b].MissionTime - (long)recordByIndex.TotalTime, (uint)recordByIndex.TotalTime);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, 2, (int)b3);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
		GUIManager.Instance.HideUILock(EUILock.Mission);
	}

	// Token: 0x060014D1 RID: 5329 RVA: 0x0023E670 File Offset: 0x0023C870
	public void RecvTimeMissionReward(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1) - 1;
		byte b2 = MP.ReadByte(-1);
		if (b2 == 0)
		{
			return;
		}
		if ((int)b >= this.TimerMissionData.Length || (int)b2 > this.TimerMissionData[(int)b].TimeMission.Length)
		{
			return;
		}
		byte b3 = b + 1;
		this.MissionNotice = (byte)((int)this.MissionNotice & ~(1 << (int)b3));
		this.TimerMissionData[(int)b].ProcessIdx = byte.MaxValue;
		if (this.TimerMissionData[(int)b].TimeMission[(int)(b2 -= 1)].State == _eTimerMissionState.AutoComplete)
		{
			byte[] accessMissionCount = this.AccessMissionCount;
			byte b4 = b3;
			accessMissionCount[(int)b4] = accessMissionCount[(int)b4] - 1;
		}
		this.TimerMissionData[(int)b].TimeMission[(int)b2].State = _eTimerMissionState.Complete;
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		int num = 0;
		Array.Clear(instance2.SE_Kind, 0, instance2.SE_Kind.Length);
		if (b3 == 1)
		{
			AffairCardinalTbl recordByIndex = this.AffairCardinalTable.GetRecordByIndex((int)this.TimerMissionData[(int)b].TimeMission[(int)b2].Base);
			for (int i = 0; i < 5; i++)
			{
				if (recordByIndex.ResourceCardinal != null && i < recordByIndex.ResourceCardinal.Length && recordByIndex.ResourceCardinal[i] > 0u)
				{
					instance2.SE_Kind[num] = SpeciallyEffect_Kind.Food + (int)((byte)i);
					instance2.m_SpeciallyEffect.mResValue[i] = recordByIndex.ResourceCardinal[i];
					num++;
				}
			}
			if (recordByIndex.Exp > 0u)
			{
				instance2.SE_Kind[num] = SpeciallyEffect_Kind.LeadExp;
				num++;
			}
		}
		else
		{
			AllianceCardinalTbl recordByIndex2 = this.AllianceCardinalTable.GetRecordByIndex((int)this.TimerMissionData[(int)b].TimeMission[(int)b2].Base);
			for (int j = 0; j < 5; j++)
			{
				if (recordByIndex2.ResourceCardinal != null && j < recordByIndex2.ResourceCardinal.Length && recordByIndex2.ResourceCardinal[j] > 0u)
				{
					instance2.SE_Kind[num] = SpeciallyEffect_Kind.Food + (int)((byte)j);
					instance2.m_SpeciallyEffect.mResValue[j] = recordByIndex2.ResourceCardinal[j];
					num++;
				}
			}
			if (recordByIndex2.Exp > 0u)
			{
				instance2.SE_Kind[num] = SpeciallyEffect_Kind.LeadExp;
				num++;
			}
			if (recordByIndex2.AllianceMoney > 0)
			{
				instance2.SE_Kind[num] = SpeciallyEffect_Kind.AllianceMoney;
				num++;
			}
		}
		Array.Clear(instance2.SE_Stock, 0, instance2.SE_Stock.Length);
		for (int k = 0; k < 5; k++)
		{
			instance.Resource[k].Stock = MP.ReadUInt(-1);
		}
		instance2.SE_Stock[4] = instance.RoleAlliance.Money;
		if (b3 == 1)
		{
			MP.ReadUInt(-1);
		}
		else
		{
			instance.RoleAlliance.Money = MP.ReadUInt(-1);
		}
		ushort morale = instance.RoleAttr.Morale;
		DataManager.StageDataController.RoleAttrLevelUp(MP, 59);
		if (this.TimerMissionData[(int)b].TimeMission[(int)b2].ItemID > 0)
		{
			DataManager.Instance.ReflashMaterialItem = 1;
			instance.SetCurItemQuantity(this.TimerMissionData[(int)b].TimeMission[(int)b2].ItemID, MP.ReadUShort(-1), (byte)(this.TimerMissionData[(int)b].TimeMission[(int)b2].Quality + 1), 0L);
		}
		Array.Clear(instance2.SE_ItemID, 0, instance2.SE_ItemID.Length);
		if (this.TimerMissionData[(int)b].TimeMission[(int)b2].ItemID > 0)
		{
			instance2.SE_ItemID[0] = this.TimerMissionData[(int)b].TimeMission[(int)b2].ItemID;
			instance2.SE_Item_L_Color[0] = (byte)(this.TimerMissionData[(int)b].TimeMission[(int)b2].Quality + 1);
		}
		if (instance.RoleAttr.Morale - morale > 0)
		{
			instance2.SE_Kind[num] = SpeciallyEffect_Kind.Morale;
			num++;
		}
		instance2.m_SpeciallyEffect.AddIconShow(instance2.mStartV2, instance2.SE_Kind, instance2.SE_ItemID, true);
		instance2.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7946u + (uint)b), 11, true);
		GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
		instance2.UpdateUI(EGUIWindow.UI_Mission, 4, (int)b3);
		instance2.UpdateUI(EGUIWindow.Door, 15, 0);
		this.CheckChanged(eMissionKind.Mark, 102, 1);
		instance2.HideUILock(EUILock.Mission);
	}

	// Token: 0x060014D2 RID: 5330 RVA: 0x0023EB04 File Offset: 0x0023CD04
	public void RecvTimeMissionCompleteInst(MessagePacket MP)
	{
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		byte b = MP.ReadByte(-1) - 1;
		byte b2 = MP.ReadByte(-1);
		if (b2 == 0)
		{
			return;
		}
		if ((int)b >= this.TimerMissionData.Length || (int)b2 > this.TimerMissionData[(int)b].TimeMission.Length)
		{
			return;
		}
		instance2.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eMission);
		byte b3 = b + 1;
		this.TimerMissionData[(int)b].ProcessIdx = byte.MaxValue;
		this.TimerMissionData[(int)b].MissionTime = -1L;
		this.TimerMissionData[(int)b].TimeMission[(int)(b2 - 1)].State = _eTimerMissionState.Reward;
		this.MissionNotice |= (byte)(1 << (int)b3);
		if (b3 == 1)
		{
			instance.SetQueueBarData(EQueueBarIndex.AffairMission, false, 0L, 0u);
			instance2.AddHUDMessage(instance.mStringTable.GetStringByID(7942u), 25, true);
		}
		else
		{
			instance.SetQueueBarData(EQueueBarIndex.AllianceMission, false, 0L, 0u);
			instance2.AddHUDMessage(instance.mStringTable.GetStringByID(7943u), 25, true);
		}
		instance2.UpdateUI(EGUIWindow.UI_Mission, 1, (int)b3);
		instance2.HideUILock(EUILock.Mission);
		GameManager.OnRefresh(NetworkNews.Refresh, null);
	}

	// Token: 0x060014D3 RID: 5331 RVA: 0x0023EC3C File Offset: 0x0023CE3C
	public void RecvMissionComplete(MessagePacket MP)
	{
		ushort num = MP.ReadUShort(-1);
		if (num == 0)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		int num2 = 0;
		Array.Clear(instance2.SE_Kind, 0, instance2.SE_Kind.Length);
		this.SetBoolMark(num);
		ManorAimTbl recordByKey = this.ManorAimTable.GetRecordByKey(num);
		this.RewardList.Priority.Remove(this.ManorAimTable.GetRecordByKey(num).UIPriority);
		DataManager.StageDataController.UpdateRoleAttrExp(MP.ReadUInt(-1));
		if (recordByKey.Exp > 0u)
		{
			instance2.SE_Kind[num2] = SpeciallyEffect_Kind.LeadExp;
			num2++;
		}
		instance.RoleAttr.Power = MP.ReadULong(-1);
		if (recordByKey.Force > 0u)
		{
			instance2.SE_Kind[num2] = SpeciallyEffect_Kind.Power;
			num2++;
		}
		instance2.PreLeadLevel = (int)instance.RoleAttr.Level;
		DataManager.StageDataController.RoleAttrLevelUp(MP, 57);
		if (recordByKey.RewardMorale > 0)
		{
			instance2.SE_Kind[num2] = SpeciallyEffect_Kind.Morale;
			num2++;
		}
		Array.Clear(instance2.SE_Stock, 0, instance2.SE_Stock.Length);
		for (ResourceType resourceType = ResourceType.Grain; resourceType < ResourceType.MAX; resourceType += 1)
		{
			instance2.SE_Stock[(int)resourceType] = instance.Resource[(int)resourceType].Stock;
			instance.Resource[(int)resourceType].Stock = MP.ReadUInt(-1);
			if (recordByKey.RewardResource != null && (int)resourceType < recordByKey.RewardResource.Length && recordByKey.RewardResource[(int)resourceType] > 0u)
			{
				instance2.SE_Kind[num2] = SpeciallyEffect_Kind.Food + (int)resourceType;
				instance2.m_SpeciallyEffect.mResValue[(int)resourceType] = recordByKey.RewardResource[(int)resourceType];
				num2++;
			}
		}
		byte b = MP.ReadByte(-1);
		Array.Clear(instance2.SE_ItemID, 0, instance2.SE_ItemID.Length);
		for (int i = 0; i < (int)b; i++)
		{
			instance.SetCurItemQuantity(MP.ReadUShort(-1), MP.ReadUShort(-1), 0, 0L);
		}
		if (recordByKey.RewardItems != null)
		{
			if (recordByKey.RewardItems[0].ItemID > 0)
			{
				instance2.SE_ItemID[0] = recordByKey.RewardItems[0].ItemID;
			}
			if (recordByKey.RewardItems[1].ItemID > 0)
			{
				instance2.SE_ItemID[1] = recordByKey.RewardItems[1].ItemID;
			}
			if (recordByKey.RewardItems[2].ItemID > 0)
			{
				instance2.SE_ItemID[2] = recordByKey.RewardItems[2].ItemID;
			}
		}
		instance2.m_SpeciallyEffect.AddIconShow(instance2.mStartV2, instance2.SE_Kind, instance2.SE_ItemID, true);
		this.CheckChanged(eMissionKind.Mark, 101, 1);
		instance2.HideUILock(EUILock.Mission);
		instance2.UpdateUI(EGUIWindow.Door, 15, 0);
		instance2.AddHUDMessage(instance.mStringTable.GetStringByID(7945u), 11, true);
		GameManager.OnRefresh(NetworkNews.Refresh, null);
		GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
		GameManager.OnRefresh(NetworkNews.Refresh_Attr, null);
		AFAdvanceManager.Instance.CheckTurfQuestUnbroken();
	}

	// Token: 0x060014D4 RID: 5332 RVA: 0x0023EF50 File Offset: 0x0023D150
	public void RecvMissionFlag(MessagePacket MP)
	{
		ushort val = MP.ReadUShort(-1);
		MP.ReadBlock(this.BoolMark, 0, Math.Min((int)val, this.BoolMark.Length), -1);
	}

	// Token: 0x060014D5 RID: 5333 RVA: 0x0023EF84 File Offset: 0x0023D184
	public void RecvMissionMark(MessagePacket MP)
	{
		ushort num = MP.ReadUShort(-1);
		for (ushort num2 = 0; num2 < num; num2 += 1)
		{
			if (this.DynaMark.Length > (int)num2)
			{
				this.DynaMark[(int)num2] = MP.ReadUShort(-1);
			}
		}
		this.SetCompleteWhileLogin(eMissionKind.Mark);
		this.SetCompleteWhileLogin(eMissionKind.Army);
	}

	// Token: 0x060014D6 RID: 5334 RVA: 0x0023EFD8 File Offset: 0x0023D1D8
	public void RecvMissionmarkUpdate(MessagePacket MP)
	{
		ushort num = MP.ReadUShort(-1);
		if ((int)num >= this.DynaMark.Length)
		{
			return;
		}
		this.DynaMark[(int)num] = MP.ReadUShort(-1);
		if (num >= 124 && num <= 128)
		{
			this.CollectDelay = (byte)num;
		}
		else
		{
			this.CheckChanged(eMissionKind.Mark, num, this.DynaMark[(int)num]);
		}
	}

	// Token: 0x060014D7 RID: 5335 RVA: 0x0023F03C File Offset: 0x0023D23C
	public void sendTimeMissionStart(_eMissionType type, byte index)
	{
		if (NewbieManager.IsNewbie)
		{
			return;
		}
		if (!GUIManager.Instance.ShowUILock(EUILock.Mission))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_MISSION_START;
		messagePacket.Add((byte)(type - _eMissionType.Affair + 1));
		messagePacket.Add(index);
		messagePacket.Send(false);
	}

	// Token: 0x060014D8 RID: 5336 RVA: 0x0023F0A0 File Offset: 0x0023D2A0
	public void sendTimeMissionReward(_eMissionType type, byte index)
	{
		if (!GUIManager.Instance.ShowUILock(EUILock.Mission))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_MISSION_FINISH;
		messagePacket.Add((byte)(type - _eMissionType.Affair + 1));
		messagePacket.Add(index);
		messagePacket.Send(false);
	}

	// Token: 0x060014D9 RID: 5337 RVA: 0x0023F0F8 File Offset: 0x0023D2F8
	public void sendMissionComplete(ushort ID, ushort ManorID = 0)
	{
		if (NewbieManager.IsNewbie)
		{
			this.SetBoolMark(ID);
			this.RewardList.Priority.Remove(this.ManorAimTable.GetRecordByKey(ID).UIPriority);
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
		}
		else if (!BattleController.IsActive)
		{
			if (!GUIManager.Instance.ShowUILock(EUILock.Mission))
			{
				return;
			}
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.AddSeqId();
			messagePacket.Protocol = Protocol._MSG_REQUEST_MISSION_COMPLETE;
			messagePacket.Add(ID);
			if (ManorID > 0)
			{
				messagePacket.Add(ManorID);
			}
			messagePacket.Send(false);
		}
	}

	// Token: 0x060014DA RID: 5338 RVA: 0x0023F1A4 File Offset: 0x0023D3A4
	public void CheckResourceCollect()
	{
		if (this.CollectDelay == 0)
		{
			return;
		}
		this.CheckChanged(eMissionKind.Mark, (ushort)this.CollectDelay, this.DynaMark[(int)this.CollectDelay]);
		this.CollectDelay = 0;
	}

	// Token: 0x060014DB RID: 5339 RVA: 0x0023F1E0 File Offset: 0x0023D3E0
	public bool HaveEmptyBox()
	{
		return this.VipBoxState != this.VipBoxStateMax;
	}

	// Token: 0x060014DC RID: 5340 RVA: 0x0023F1FC File Offset: 0x0023D3FC
	public int GetVipBoxState(byte index)
	{
		return this.VipBoxState >> (int)index & 1;
	}

	// Token: 0x060014DD RID: 5341 RVA: 0x0023F20C File Offset: 0x0023D40C
	public void CleanVipBoxState()
	{
		this.VipBoxState = 0;
		this.VipRewardStartTime = 0L;
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.VIPMission, false, 0L, 0u);
		this.UpdateVipCount();
		this.Update(0f);
	}

	// Token: 0x060014DE RID: 5342 RVA: 0x0023F24C File Offset: 0x0023D44C
	public void RecvVipMission(MessagePacket MP)
	{
		DataManager instance = DataManager.Instance;
		byte b = MP.ReadByte(-1);
		if (b > 0)
		{
			GUIManager.Instance.HideUILock(EUILock.Mission);
			return;
		}
		byte b2 = MP.ReadByte(-1);
		this.UpdateUIBox = (b2 ^ this.VipBoxState);
		this.VipBoxState = b2;
		this.VipRewardStartTime = MP.ReadLong(-1);
		DataManager dataManager = instance;
		dataManager.RoleAttr.Diamond = dataManager.RoleAttr.Diamond + MP.ReadUInt(-1);
		DataManager dataManager2 = instance;
		dataManager2.RoleAlliance.Money = dataManager2.RoleAlliance.Money + MP.ReadUInt(-1);
		this.BoxEffectID = (byte)Mathf.Clamp((int)MP.ReadByte(-1), 1, 5);
		byte b3 = MP.ReadByte(-1);
		if (this.UpdateUIBox > 0)
		{
			this.MissionNotice = (byte)((int)this.MissionNotice & -9);
		}
		this.UpdateVipCount();
		this.UpdateVipTime();
		byte b4 = 0;
		if (b3 > 0)
		{
			this.RewardVipDiamond = 0u;
			for (byte b5 = 0; b5 < b3; b5 += 1)
			{
				ushort num = MP.ReadUShort(-1);
				Equip recordByKey = instance.EquipTable.GetRecordByKey(num);
				if ((int)b4 < this.VipRewardItem.Length)
				{
					this.VipRewardItem[(int)b4] = num;
					this.VipRewardKind[(int)b4] = SpeciallyEffect_Kind.Kind;
				}
				if (recordByKey.EquipKind == 11 && recordByKey.PropertiesInfo != null && (recordByKey.PropertiesInfo[0].Propertieskey == 6 || recordByKey.PropertiesInfo[0].Propertieskey == 7))
				{
					if ((int)b4 < this.VipRewardItem.Length)
					{
						if (recordByKey.PropertiesInfo[0].Propertieskey == 6)
						{
							this.RewardVipDiamond += (uint)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue);
							this.VipRewardKind[(int)b4] = SpeciallyEffect_Kind.Diamond;
						}
						else if (recordByKey.PropertiesInfo[0].Propertieskey == 7)
						{
							this.VipRewardKind[(int)b4] = SpeciallyEffect_Kind.AllianceMoney;
						}
					}
					MP.ReadUShort(-1);
					MP.ReadByte(-1);
					b4 += 1;
				}
				else
				{
					ushort num2 = instance.GetCurItemQuantity(recordByKey.EquipKey, 0);
					num2 += MP.ReadUShort(-1);
					byte rare = MP.ReadByte(-1);
					instance.SetCurItemQuantity(recordByKey.EquipKey, num2, rare, 0L);
					b4 += 1;
				}
			}
			Array.Clear(this.VipRewardItem, (int)b4, this.VipRewardItem.Length - (int)b3);
			Array.Clear(this.VipRewardKind, (int)b4, this.VipRewardKind.Length - (int)b3);
		}
		GUIManager.Instance.HideUILock(EUILock.Mission);
		GameManager.OnRefresh(NetworkNews.Refresh, null);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, 4, 3);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
		this.UpdateUIBox = 0;
		this.BoxEffectID = 0;
	}

	// Token: 0x060014DF RID: 5343 RVA: 0x0023F520 File Offset: 0x0023D720
	public void sendReceiveVipBox(byte index)
	{
		if (!GUIManager.Instance.ShowUILock(EUILock.Mission))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_MISSION_VIP_COLLECT;
		messagePacket.Add(index);
		messagePacket.Send(false);
	}

	// Token: 0x060014E0 RID: 5344 RVA: 0x0023F56C File Offset: 0x0023D76C
	public void sendVipMissionImmed()
	{
		if (!GUIManager.Instance.ShowUILock(EUILock.Mission))
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_MISSION_VIP_SPEEDUP;
		messagePacket.Send(false);
	}

	// Token: 0x060014E1 RID: 5345 RVA: 0x0023F5B0 File Offset: 0x0023D7B0
	public void RecvVipMissionImmed(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Mission);
		byte b = MP.ReadByte(-1);
		if (b > 0)
		{
			return;
		}
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.VIPMission, false, 0L, 0u);
		DataManager.Instance.RoleAttr.Diamond = MP.ReadUInt(-1);
		this.VipRewardStartTime = 0L;
		GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7944u), 11, true);
		if (this.VipBoxState != this.VipBoxStateMax)
		{
			this.MissionNotice |= 8;
		}
		GameManager.OnRefresh(NetworkNews.Refresh, null);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, 4, 3);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
	}

	// Token: 0x060014E2 RID: 5346 RVA: 0x0023F66C File Offset: 0x0023D86C
	public void UpdateVipTime()
	{
		DataManager instance = DataManager.Instance;
		if (this.VipBoxState != this.VipBoxStateMax && this.VipRewardStartTime + 3600L > instance.ServerTime)
		{
			instance.SetQueueBarData(EQueueBarIndex.VIPMission, true, this.VipRewardStartTime, 3600u);
			instance.SetRecvQueueBarData(21);
		}
		else
		{
			instance.SetQueueBarData(EQueueBarIndex.VIPMission, false, 0L, 0u);
		}
	}

	// Token: 0x060014E3 RID: 5347 RVA: 0x0023F6D8 File Offset: 0x0023D8D8
	private void UpdateVipCount()
	{
		DataManager instance = DataManager.Instance;
		this.AccessMissionCount[3] = 0;
		for (int i = 0; i < this.VipLvRestrict.Length; i++)
		{
			if (this.VipLvRestrict[i] <= instance.RoleAttr.VIPLevel && (this.VipBoxState >> i & 1) == 0)
			{
				byte[] accessMissionCount = this.AccessMissionCount;
				int num = 3;
				accessMissionCount[num] += 1;
			}
		}
	}

	// Token: 0x060014E4 RID: 5348 RVA: 0x0023F74C File Offset: 0x0023D94C
	public ushort CheckDynaMark(byte id)
	{
		if ((int)id < this.DynaMark.Length)
		{
			return this.DynaMark[(int)id];
		}
		return 0;
	}

	// Token: 0x04003DA5 RID: 15781
	private const byte DynaMarkMax = 188;

	// Token: 0x04003DA6 RID: 15782
	public const ushort VipRewardTotalTime = 3600;

	// Token: 0x04003DA7 RID: 15783
	public CExternalTableWithWordKey<AffairCardinalTbl> AffairCardinalTable;

	// Token: 0x04003DA8 RID: 15784
	public CExternalTableWithWordKey<AllianceCardinalTbl> AllianceCardinalTable;

	// Token: 0x04003DA9 RID: 15785
	public CExternalTableWithWordKey<AffairNarrativeTbl> AffairNarrativeTable;

	// Token: 0x04003DAA RID: 15786
	public CExternalTableWithWordKey<AffairNarrativeTbl> AllianceNarrativeTable;

	// Token: 0x04003DAB RID: 15787
	public CExternalTableWithWordKey<ProbabilityTbl> ProbabilityTable;

	// Token: 0x04003DAC RID: 15788
	public CExternalTableWithWordKey<ManorAimTbl> ManorAimTable;

	// Token: 0x04003DAD RID: 15789
	public TimerTypeMission[] TimerMissionData;

	// Token: 0x04003DAE RID: 15790
	public byte[] AccessMissionCount = new byte[4];

	// Token: 0x04003DAF RID: 15791
	public byte MissionNotice;

	// Token: 0x04003DB0 RID: 15792
	public byte bFirst = 1;

	// Token: 0x04003DB1 RID: 15793
	private byte CollectDelay;

	// Token: 0x04003DB2 RID: 15794
	public _RecommandTbl RecommandTable;

	// Token: 0x04003DB3 RID: 15795
	public _UIClassificationTbl[] UIManorAimKind;

	// Token: 0x04003DB4 RID: 15796
	private _ManorAimTypeMission[] ManorAimMission;

	// Token: 0x04003DB5 RID: 15797
	public _UIClassificationTbl RewardList;

	// Token: 0x04003DB6 RID: 15798
	public byte[] VipAutoComplete = new byte[2];

	// Token: 0x04003DB7 RID: 15799
	private ushort[] DynaMark = new ushort[188];

	// Token: 0x04003DB8 RID: 15800
	public byte[] BoolMark;

	// Token: 0x04003DB9 RID: 15801
	public ushort HeroNum;

	// Token: 0x04003DBA RID: 15802
	public GamePlayAchievementManager AchievementMgr;

	// Token: 0x04003DBB RID: 15803
	private byte VipBoxState;

	// Token: 0x04003DBC RID: 15804
	private byte VipBoxStateMax;

	// Token: 0x04003DBD RID: 15805
	public byte UpdateUIBox;

	// Token: 0x04003DBE RID: 15806
	public byte BoxEffectID;

	// Token: 0x04003DBF RID: 15807
	public long VipRewardStartTime;

	// Token: 0x04003DC0 RID: 15808
	public uint RewardVipDiamond;

	// Token: 0x04003DC1 RID: 15809
	public ushort[] VipRewardItem = new ushort[10];

	// Token: 0x04003DC2 RID: 15810
	public SpeciallyEffect_Kind[] VipRewardKind = new SpeciallyEffect_Kind[10];

	// Token: 0x04003DC3 RID: 15811
	public readonly byte[] VipLvRestrict = new byte[]
	{
		2,
		4,
		6,
		9,
		12,
		15,
		18
	};

	// Token: 0x04003DC4 RID: 15812
	public ushort AllianceMissionBonusRate = 100;
}
