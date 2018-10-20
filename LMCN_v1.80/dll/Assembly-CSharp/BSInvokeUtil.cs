using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x020001D1 RID: 465
public class BSInvokeUtil : IDisposable
{
	// Token: 0x060007E9 RID: 2025 RVA: 0x000A7D74 File Offset: 0x000A5F74
	private BSInvokeUtil()
	{
		BSInvokeUtil.DllCreateTableInstance();
		CExternalTableWithWordKey<Hero> heroTable = DataManager.Instance.HeroTable;
		BSInvokeUtil.DllSetHerosExtTable(heroTable.MapPtr, heroTable.MapCount, heroTable.TablePtr, heroTable.TableCount);
		CExternalTableWithWordKey<Skill> skillTable = DataManager.Instance.SkillTable;
		BSInvokeUtil.DllSetSkillsExtTable(skillTable.MapPtr, skillTable.MapCount, skillTable.TablePtr, skillTable.TableCount);
		CExternalTableWithWordKey<AI> aitable = DataManager.Instance.AITable;
		BSInvokeUtil.DllSetAIExtTable(aitable.MapPtr, aitable.MapCount, aitable.TablePtr, aitable.TableCount);
		CExternalTableWithWordKey<Buff> buffTable = DataManager.Instance.BuffTable;
		BSInvokeUtil.DllSetBuffExtTable(buffTable.MapPtr, buffTable.MapCount, buffTable.TablePtr, buffTable.TableCount);
		CExternalTableWithWordKey<Enhance> enhanceTable = DataManager.Instance.EnhanceTable;
		BSInvokeUtil.DllSetEnhanceExtTable(enhanceTable.MapPtr, enhanceTable.MapCount, enhanceTable.TablePtr, enhanceTable.TableCount);
		CExternalTableWithWordKey<Equip> equipTable = DataManager.Instance.EquipTable;
		BSInvokeUtil.DllSetEquipExtTable(equipTable.MapPtr, equipTable.MapCount, equipTable.TablePtr, equipTable.TableCount);
		CExternalTableWithWordKey<Level> cexternalTableWithWordKey = DataManager.StageDataController.LevelTable[1];
		BSInvokeUtil.DllSetNormalStageExtTable(cexternalTableWithWordKey.MapPtr, cexternalTableWithWordKey.MapCount, cexternalTableWithWordKey.TablePtr, cexternalTableWithWordKey.TableCount);
		CExternalTableWithWordKey<HeroTeam> teamTable = DataManager.Instance.TeamTable;
		BSInvokeUtil.DllSetEnemyExtTable(teamTable.MapPtr, teamTable.MapCount, teamTable.TablePtr, teamTable.TableCount);
		CExternalTableWithWordKey<HeroArray> arrayTable = DataManager.Instance.ArrayTable;
		BSInvokeUtil.DllSetArrayExtTable(arrayTable.MapPtr, arrayTable.MapCount, arrayTable.TablePtr, arrayTable.TableCount);
		CExternalTableWithWordKey<Level> cexternalTableWithWordKey2 = DataManager.StageDataController.LevelTable[0];
		BSInvokeUtil.DllSetNormalMiniStageExtTable(cexternalTableWithWordKey2.MapPtr, cexternalTableWithWordKey2.MapCount, cexternalTableWithWordKey2.TablePtr, cexternalTableWithWordKey2.TableCount);
		CExternalTableWithWordKey<Level> cexternalTableWithWordKey3 = DataManager.StageDataController.LevelTable[2];
		BSInvokeUtil.DllSetAdvanceStageExtTable(cexternalTableWithWordKey3.MapPtr, cexternalTableWithWordKey3.MapCount, cexternalTableWithWordKey3.TablePtr, cexternalTableWithWordKey3.TableCount);
		CExternalTableWithWordKey<SoldierData> soldierDataTable = DataManager.Instance.SoldierDataTable;
		BSInvokeUtil.DllSetSoldierExtTable(soldierDataTable.MapPtr, soldierDataTable.MapCount, soldierDataTable.TablePtr, soldierDataTable.TableCount);
		CExternalTableWithWordKey<Combo> comboTable = DataManager.Instance.ComboTable;
		BSInvokeUtil.DllSetComboExtTable(comboTable.MapPtr, comboTable.MapCount, comboTable.TablePtr, comboTable.TableCount);
		CExternalTableWithWordKey<BuildLevelRequest> buildsRequest = DataManager.Instance.BuildsRequest;
		BSInvokeUtil.DllSetBuildUpExtTable(buildsRequest.MapPtr, buildsRequest.MapCount, buildsRequest.TablePtr, buildsRequest.TableCount);
		CExternalTableWithWordKey<TechLevelTbl> techLevel = DataManager.Instance.TechLevel;
		BSInvokeUtil.DllSetTechLvExtTable(techLevel.MapPtr, techLevel.MapCount, techLevel.TablePtr, techLevel.TableCount);
		CExternalTableWithWordKey<CorpsStage> corpsStageTable = DataManager.StageDataController.CorpsStageTable;
		BSInvokeUtil.DllSetCombatStageInterfaceExtTable(corpsStageTable.MapPtr, corpsStageTable.MapCount, corpsStageTable.TablePtr, corpsStageTable.TableCount);
		CExternalTableWithWordKey<CorpsStageBattle> corpsStageBattleTable = DataManager.StageDataController.CorpsStageBattleTable;
		BSInvokeUtil.DllSetCombatStageFightExtTable(corpsStageBattleTable.MapPtr, corpsStageBattleTable.MapCount, corpsStageBattleTable.TablePtr, corpsStageBattleTable.TableCount);
		CExternalTableWithWordKey<TalentLevelTbl> talentLevel = DataManager.Instance.TalentLevel;
		BSInvokeUtil.DllSetTalentLevelExtTable(talentLevel.MapPtr, talentLevel.MapCount, talentLevel.TablePtr, talentLevel.TableCount);
		CExternalTableWithWordKey<VIP_DataTbl> viplevelTable = DataManager.Instance.VIPLevelTable;
		BSInvokeUtil.DllSetVIPExtTable(viplevelTable.MapPtr, viplevelTable.MapCount, viplevelTable.TablePtr, viplevelTable.TableCount);
		CExternalTableWithWordKey<LordEquipEffectData> lordEquipEffectTable = DataManager.Instance.LordEquipEffectTable;
		BSInvokeUtil.DllSetLordEquipEffectExtTable(lordEquipEffectTable.MapPtr, lordEquipEffectTable.MapCount, lordEquipEffectTable.TablePtr, lordEquipEffectTable.TableCount);
		CExternalTableWithWordKey<ArenaHeroTopic> arenaHeroTopicData = DataManager.Instance.ArenaHeroTopicData;
		BSInvokeUtil.DllSetArenaHeroTopicExtTable(arenaHeroTopicData.MapPtr, arenaHeroTopicData.MapCount, arenaHeroTopicData.TablePtr, (ushort)arenaHeroTopicData.TableCount);
		CExternalTableWithWordKey<WondersInfoTbl> mapWondersInfoTable = DataManager.MapDataController.MapWondersInfoTable;
		BSInvokeUtil.DllSetWondersInformationExtTable(mapWondersInfoTable.MapPtr, mapWondersInfoTable.MapCount, mapWondersInfoTable.TablePtr, (int)((ushort)mapWondersInfoTable.TableCount));
		CExternalTableWithWordKey<TitleData> cexternalTableWithWordKey4 = DataManager.Instance.TitleData;
		BSInvokeUtil.DllSetWondersTitleExtTable(cexternalTableWithWordKey4.MapPtr, cexternalTableWithWordKey4.MapCount, cexternalTableWithWordKey4.TablePtr, (int)((ushort)cexternalTableWithWordKey4.TableCount));
		cexternalTableWithWordKey4 = DataManager.Instance.TitleDataW;
		BSInvokeUtil.DllSetEmperorTitleExtTable(cexternalTableWithWordKey4.MapPtr, cexternalTableWithWordKey4.MapCount, cexternalTableWithWordKey4.TablePtr, (int)((ushort)cexternalTableWithWordKey4.TableCount));
		cexternalTableWithWordKey4 = DataManager.Instance.TitleDataN;
		BSInvokeUtil.DllSetEmperorKingdomTitleExtTable(cexternalTableWithWordKey4.MapPtr, cexternalTableWithWordKey4.MapCount, cexternalTableWithWordKey4.TablePtr, (int)((ushort)cexternalTableWithWordKey4.TableCount));
		cexternalTableWithWordKey4 = DataManager.Instance.TitleDataF;
		BSInvokeUtil.DllSetFederalTitleExtTable(cexternalTableWithWordKey4.MapPtr, cexternalTableWithWordKey4.MapCount, cexternalTableWithWordKey4.TablePtr, (int)((ushort)cexternalTableWithWordKey4.TableCount));
		CExternalTableWithWordKey<CoordData> coordTable = DataManager.Instance.CoordTable;
		BSInvokeUtil.DllSetCoordinateTable(coordTable.MapPtr, coordTable.MapCount, coordTable.TablePtr, (int)((ushort)coordTable.TableCount));
		CExternalTableWithWordKey<StageConditionData> stageConditionDataTable = DataManager.StageDataController.StageConditionDataTable;
		BSInvokeUtil.DllSetHeroChallengeQuestTable(stageConditionDataTable.MapPtr, stageConditionDataTable.MapCount, stageConditionDataTable.TablePtr, (ushort)stageConditionDataTable.TableCount);
		CExternalTableWithWordKey<CastleSkinTbl> castleSkinTable = GUIManager.Instance.BuildingData.castleSkin.CastleSkinTable;
		BSInvokeUtil.DllSetCastleSkinTable(castleSkinTable.MapPtr, (uint)castleSkinTable.MapCount, castleSkinTable.TablePtr, (ushort)castleSkinTable.TableCount);
		CExternalTableWithWordKey<CastleEnhanceTbl> castleEnhanceTable = GUIManager.Instance.BuildingData.castleSkin.CastleEnhanceTable;
		BSInvokeUtil.DllSetCastleSkinEnhanceTable(castleEnhanceTable.MapPtr, castleEnhanceTable.MapCount, castleEnhanceTable.TablePtr, (ushort)castleEnhanceTable.TableCount);
		CExternalTableWithWordKey<PetTbl> petTable = PetManager.Instance.PetTable;
		BSInvokeUtil.DllSetPetTable(petTable.MapPtr, petTable.MapCount, petTable.TablePtr, (ushort)petTable.TableCount);
		CExternalTableWithWordKey<PetSkillTbl> petSkillTable = PetManager.Instance.PetSkillTable;
		BSInvokeUtil.DllSetPetSkillTable(petSkillTable.MapPtr, petSkillTable.MapCount, petSkillTable.TablePtr, (ushort)petSkillTable.TableCount);
		CExternalTableWithWordKey<PetSkillValTbl> petSkillValTable = PetManager.Instance.PetSkillValTable;
		BSInvokeUtil.DllSetCPetSkillValueTable(petSkillValTable.MapPtr, petSkillValTable.MapCount, petSkillValTable.TablePtr, (ushort)petSkillValTable.TableCount);
		CExternalTableWithWordKey<LordEquipExtendData> lordEquipExtendTable = DataManager.Instance.LordEquipExtendTable;
		BSInvokeUtil.DllSetLordEquipExtendTable(lordEquipExtendTable.MapPtr, lordEquipExtendTable.MapCount, lordEquipExtendTable.TablePtr, (ushort)lordEquipExtendTable.TableCount);
		this.m_pBSObject = BSInvokeUtil.DllCreateBSInstance();
		this.m_pCSObject = BSInvokeUtil.DllCreateCSInstance();
	}

	// Token: 0x060007EB RID: 2027
	[DllImport("BattleSimDll")]
	private static extern int DllCanUnload();

	// Token: 0x060007EC RID: 2028
	[DllImport("BattleSimDll")]
	private static extern uint DllGetVersionNum();

	// Token: 0x060007ED RID: 2029
	[DllImport("BattleSimDll")]
	private static extern IntPtr DllCreateBSInstance();

	// Token: 0x060007EE RID: 2030
	[DllImport("BattleSimDll")]
	private static extern void DllDisposeBSInstance(IntPtr BSObject);

	// Token: 0x060007EF RID: 2031
	[DllImport("BattleSimDll")]
	private static extern bool DllBSInit(IntPtr BSObject, ushort RandomSeed, ushort RandomGap, byte BattleType, byte StageKind, ushort StageID, byte primarySide);

	// Token: 0x060007F0 RID: 2032
	[DllImport("BattleSimDll")]
	private static extern bool DllBSSetHero(IntPtr BSObject, ushort Side, ushort id, CalcAttrDataType attrdata);

	// Token: 0x060007F1 RID: 2033
	[DllImport("BattleSimDll")]
	private static extern void DLLBSSetHeroOver(IntPtr BSObject, byte[] pHeroDataLeft, byte[] pHeroDataRight);

	// Token: 0x060007F2 RID: 2034
	[DllImport("BattleSimDll")]
	private static extern byte DllBSNextStage(IntPtr pBSObject, byte[] pHeroDataLeft, byte[] pHeroDataRight);

	// Token: 0x060007F3 RID: 2035
	[DllImport("BattleSimDll")]
	private static extern void DllSetHerosExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x060007F4 RID: 2036
	[DllImport("BattleSimDll")]
	private static extern void DllSetSkillsExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x060007F5 RID: 2037
	[DllImport("BattleSimDll")]
	private static extern void DllSetAIExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x060007F6 RID: 2038
	[DllImport("BattleSimDll")]
	private static extern void DllSetBuffExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x060007F7 RID: 2039
	[DllImport("BattleSimDll")]
	private static extern void DllSetEnhanceExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x060007F8 RID: 2040
	[DllImport("BattleSimDll")]
	private static extern void DllSetEquipExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x060007F9 RID: 2041
	[DllImport("BattleSimDll")]
	private static extern void DllSetNormalStageExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x060007FA RID: 2042
	[DllImport("BattleSimDll")]
	private static extern void DllSetNormalMiniStageExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x060007FB RID: 2043
	[DllImport("BattleSimDll")]
	private static extern void DllSetAdvanceStageExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x060007FC RID: 2044
	[DllImport("BattleSimDll")]
	private static extern void DllSetEnemyExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x060007FD RID: 2045
	[DllImport("BattleSimDll")]
	private static extern void DllSetArrayExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x060007FE RID: 2046
	[DllImport("BattleSimDll")]
	private static extern void DllSetSoldierExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x060007FF RID: 2047
	[DllImport("BattleSimDll")]
	private static extern void DllSetComboExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x06000800 RID: 2048
	[DllImport("BattleSimDll")]
	private static extern uint DllUpdateFightScore(IntPtr pBSObject, ushort HeroID, uint HP, ushort[] pAttr, byte[] SkillLV);

	// Token: 0x06000801 RID: 2049
	[DllImport("BattleSimDll")]
	private static extern void DllCalculateAttribute(IntPtr pBSObject, ushort HeroID, CalcAttrDataType CalcAttrData, ref uint HP, ushort[] pAttr);

	// Token: 0x06000802 RID: 2050
	[DllImport("BattleSimDll")]
	private static extern void DLLCalculateHeroEquipEffect(IntPtr pBSObject, ushort HeroID, byte Enhance, byte Equip, ref uint HP, ushort[] pAttr);

	// Token: 0x06000803 RID: 2051
	[DllImport("BattleSimDll")]
	private static extern byte DLLBSSetPVEMonsterHP(IntPtr BSObject, uint maxHp, uint nowHp);

	// Token: 0x06000804 RID: 2052
	[DllImport("BattleSimDll")]
	private static extern uint DLLBSGetPVEMonsterHP(IntPtr BSObject);

	// Token: 0x06000805 RID: 2053
	[DllImport("BattleSimDll")]
	private static extern bool DLLBSSetPVEMonsterAttr(IntPtr BSObject, MonsterAttrDataType AttrData);

	// Token: 0x06000806 RID: 2054
	[DllImport("BattleSimDll")]
	private static extern IntPtr DllCreateCSInstance();

	// Token: 0x06000807 RID: 2055
	[DllImport("BattleSimDll")]
	private static extern bool DllCSInit(IntPtr CSObject, ushort RandomSeed, ushort RandomGap);

	// Token: 0x06000808 RID: 2056
	[DllImport("BattleSimDll")]
	private static extern bool DllCSSetCombatInfo(IntPtr CSObject, byte LeftLv, TroopLeaderType[] pleftLeaderData, byte leftLeaderNum, uint[,] pleftTroopForce, byte RightLv, TroopLeaderType[] prightLeaderData, byte rightLeaderNum, uint[,] prightTroopForce);

	// Token: 0x06000809 RID: 2057
	[DllImport("BattleSimDll")]
	private static extern int DLLCSSetTroopOver(IntPtr CSObject, byte[] pHeroDataLeft, byte[] pHeroDataRight);

	// Token: 0x0600080A RID: 2058
	[DllImport("BattleSimDll")]
	private static extern byte DllCSUpdateClient(IntPtr CSObject, uint Tick, byte[] pCommandsBuffLeft, byte[] pCommandsBuffRight);

	// Token: 0x0600080B RID: 2059
	[DllImport("BattleSimDll")]
	private static extern void DllDisposeCSInstance(IntPtr CSObject);

	// Token: 0x0600080C RID: 2060
	[DllImport("BattleSimDll")]
	private static extern bool DllCSSetWallTrapInfo(IntPtr BSObject, uint WallDefence, uint WallDefenceMax, uint[,] pTrapForce);

	// Token: 0x0600080D RID: 2061
	[DllImport("BattleSimDll")]
	private static extern void DllCreateTableInstance();

	// Token: 0x0600080E RID: 2062
	[DllImport("BattleSimDll")]
	private static extern void DllDisposeTableInstance();

	// Token: 0x0600080F RID: 2063
	[DllImport("BattleSimDll")]
	private static extern uint DllBSCheckUltraCondition(IntPtr BSObject);

	// Token: 0x06000810 RID: 2064
	[DllImport("BattleSimDll")]
	private static extern uint DllBSCheckRightUltraCondition(IntPtr BSObject);

	// Token: 0x06000811 RID: 2065
	[DllImport("BattleSimDll")]
	private static extern bool DllBSInitUltra(IntPtr BSObject, byte HeroIndex, ref byte ClosestHeroIndex, ref float PosX, ref float PosY);

	// Token: 0x06000812 RID: 2066
	[DllImport("BattleSimDll")]
	private static extern void DllBSCheckUltraHitTarget(IntPtr BSObject, byte Param1, byte Param2, ref uint HitNum);

	// Token: 0x06000813 RID: 2067
	[DllImport("BattleSimDll")]
	private static extern void DllBSUltraInput(IntPtr BSObject, byte Param1, byte Param2);

	// Token: 0x06000814 RID: 2068
	[DllImport("BattleSimDll")]
	private static extern byte DllBSUpdateClient(IntPtr BSObject, uint Tick, byte[] pCommandsBuffLeft, byte[] pCommandsBuffRight, byte[] pEventBuffer);

	// Token: 0x06000815 RID: 2069
	[DllImport("BattleSimDll")]
	private unsafe static extern void DllCSCalculateBuildingBonus(IntPtr pCSObject, RoleBuildingData* pCalcBuildingData, byte bAlterOpen, uint[] pResultAttr);

	// Token: 0x06000816 RID: 2070
	[DllImport("BattleSimDll")]
	private static extern void DllCSCalculateResearchBonus(IntPtr pCSObject, byte[] pCalcResearchData, uint[] pResultAttr);

	// Token: 0x06000817 RID: 2071
	[DllImport("BattleSimDll")]
	private static extern void DllSetBuildUpExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x06000818 RID: 2072
	[DllImport("BattleSimDll")]
	private static extern void DllSetTechLvExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x06000819 RID: 2073
	[DllImport("BattleSimDll")]
	private static extern void DllCSCalculateHeroSkillBonus(IntPtr pCSObject, byte HeroNum, CalcHeroDataType[] pCalcHeroData, byte LordStatus, ushort LordID, uint[] pResultAttr);

	// Token: 0x0600081A RID: 2074
	[DllImport("BattleSimDll")]
	private static extern int DllCSSetTroopAttrData(IntPtr CSObject, uint[] pLeftAtk, uint[] pLeftDef, uint[] pLeftHp, uint[] pRightAtk, uint[] pRightDef, uint[] pRightHp);

	// Token: 0x0600081B RID: 2075
	[DllImport("BattleSimDll")]
	private static extern int DllCSSetTrapAttrData(IntPtr CSObject, CombatCastleDefAttrDataType TrapAttr);

	// Token: 0x0600081C RID: 2076
	[DllImport("BattleSimDll")]
	private static extern void DllCSGetCombatStageAttr(IntPtr pCSObject, byte CombatStageID, ushort Head, byte HeroNum, TroopLeaderType[] pHeroData, uint[] pCalcCombatAttr, uint[] pCalcCombatLoadAttr, uint[] pResultLeftAtk, uint[] pResultLeftDef, uint[] pResultLeftHp, uint[] pResultRightAtk, uint[] pResultRightDef, uint[] pResultRightHp, ref CombatCastleDefAttrDataType pResultTrapAttr, bool bInDeShieldBuff);

	// Token: 0x0600081D RID: 2077
	[DllImport("BattleSimDll")]
	private static extern void DllSetTalentLevelExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x0600081E RID: 2078
	[DllImport("BattleSimDll")]
	private static extern void DllSetCombatStageFightExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x0600081F RID: 2079
	[DllImport("BattleSimDll")]
	private static extern void DllSetCombatStageInterfaceExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x06000820 RID: 2080
	[DllImport("BattleSimDll")]
	private static extern void DllCSCalculateTalentBonus(IntPtr pCSObject, byte[] pCalcTalentData, uint[] pResultAttr);

	// Token: 0x06000821 RID: 2081
	[DllImport("BattleSimDll")]
	private static extern uint DLLBSGetEventDataLen(IntPtr BSObject);

	// Token: 0x06000822 RID: 2082
	[DllImport("BattleSimDll")]
	private static extern void DllCSCalculateBuffBonus(IntPtr pCSObject, byte BuffNum, ushort[] BuffItemID, byte PetBuffNum, _CalcPetBuffDataType[] PetBuffData, uint[] pResultAttr);

	// Token: 0x06000823 RID: 2083
	[DllImport("BattleSimDll")]
	private static extern void DllCSCalculateVIPBonus(IntPtr pCSObject, byte VIPLevel, uint[] pResultAttr);

	// Token: 0x06000824 RID: 2084
	[DllImport("BattleSimDll")]
	private static extern void DllSetVIPExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x06000825 RID: 2085
	[DllImport("BattleSimDll")]
	private static extern void DllSetLordEquipEffectExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x06000826 RID: 2086
	[DllImport("BattleSimDll")]
	private static extern void DllCSCalculateOnLordEquipBonus(IntPtr pCSObject, LordEquipSerialData[] pCalcOnLordEquipData, uint[] pResultAttr);

	// Token: 0x06000827 RID: 2087
	[DllImport("BattleSimDll")]
	private static extern void DLLBSSetUserData(IntPtr BSObject, long UserId, ulong BattleCode);

	// Token: 0x06000828 RID: 2088
	[DllImport("BattleSimDll")]
	private static extern void DllSetArenaHeroTopicExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, ushort RecNumber);

	// Token: 0x06000829 RID: 2089
	[DllImport("BattleSimDll")]
	private static extern void DLLBSSetArenaTopic(IntPtr BSObject, byte TopicID1, byte TopicID2, ArenaTopicEffectDataType Effect1, ArenaTopicEffectDataType Effect2);

	// Token: 0x0600082A RID: 2090
	[DllImport("BattleSimDll")]
	private static extern void DllSetWondersInformationExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x0600082B RID: 2091
	[DllImport("BattleSimDll")]
	private static extern void DllCSCalculateWonderBonus(IntPtr pCSObject, byte WonderID, uint[] pResultAttr);

	// Token: 0x0600082C RID: 2092
	[DllImport("BattleSimDll")]
	private static extern void DllSetWondersTitleExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x0600082D RID: 2093
	[DllImport("BattleSimDll")]
	private static extern void DllCSCalculateWonderTitleBonus(IntPtr pCSObject, byte Title, uint[] pResultAttr);

	// Token: 0x0600082E RID: 2094
	[DllImport("BattleSimDll")]
	private static extern void DllSetCoordinateTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x0600082F RID: 2095
	[DllImport("BattleSimDll")]
	private static extern void DLLSetCoordData(ushort LeftCoord, ushort RightCoord);

	// Token: 0x06000830 RID: 2096
	[DllImport("BattleSimDll")]
	private static extern void DllSetEmperorTitleExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x06000831 RID: 2097
	[DllImport("BattleSimDll")]
	private static extern void DllSetEmperorKingdomTitleExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x06000832 RID: 2098
	[DllImport("BattleSimDll")]
	private static extern void DllSetFederalTitleExtTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, int RecNumber);

	// Token: 0x06000833 RID: 2099
	[DllImport("BattleSimDll")]
	private static extern void DllCSCalculateWorldTitleBonus(IntPtr pCSObject, byte Title, byte NationTitle, uint[] pResultAttr);

	// Token: 0x06000834 RID: 2100
	[DllImport("BattleSimDll")]
	private static extern void DllCSCalculateFederalTitleBonus(IntPtr pCSObject, byte Title, uint[] pResultAttr);

	// Token: 0x06000835 RID: 2101
	[DllImport("BattleSimDll")]
	private static extern void DLLBSCasinoModeInput(IntPtr pBSObject, byte Param);

	// Token: 0x06000836 RID: 2102
	[DllImport("BattleSimDll")]
	private static extern void DllSetHeroChallengeQuestTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, ushort RecNumber);

	// Token: 0x06000837 RID: 2103
	[DllImport("BattleSimDll")]
	private static extern void DLLBSetHeroChallengeDifficulty(IntPtr pBSObject, ushort questA, ushort questB);

	// Token: 0x06000838 RID: 2104
	[DllImport("BattleSimDll")]
	private static extern byte DLLBGetHeroChallengeFailedQuest(IntPtr pBSObject);

	// Token: 0x06000839 RID: 2105
	[DllImport("BattleSimDll")]
	private static extern void DllCSCalculateCastleSKinBonus(IntPtr pCSObject, byte[] SkinUnlock, byte[] SkinLevel, uint[] pResultAttr);

	// Token: 0x0600083A RID: 2106
	[DllImport("BattleSimDll")]
	private static extern void DllSetCastleSkinTable(IntPtr TableIndx, uint IndexCount, IntPtr Table, ushort RecNumber);

	// Token: 0x0600083B RID: 2107
	[DllImport("BattleSimDll")]
	private static extern void DllSetCastleSkinEnhanceTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, ushort RecNumber);

	// Token: 0x0600083C RID: 2108
	[DllImport("BattleSimDll")]
	private static extern void DllCSCalculatePetSkillBonus(IntPtr pCSObject, ushort PetNum, _CalcPetDataType[] pCalcPetData, uint[] pResultAttr);

	// Token: 0x0600083D RID: 2109
	[DllImport("BattleSimDll")]
	private static extern void DllSetPetTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, ushort RecNumber);

	// Token: 0x0600083E RID: 2110
	[DllImport("BattleSimDll")]
	private static extern void DllSetPetSkillTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, ushort RecNumber);

	// Token: 0x0600083F RID: 2111
	[DllImport("BattleSimDll")]
	private static extern void DllSetCPetSkillValueTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, ushort RecNumber);

	// Token: 0x06000840 RID: 2112
	[DllImport("BattleSimDll")]
	private static extern void DllSetLordEquipExtendTable(IntPtr TableIndx, ushort IndexCount, IntPtr Table, ushort RecNumber);

	// Token: 0x17000066 RID: 102
	// (get) Token: 0x06000841 RID: 2113 RVA: 0x000A83CC File Offset: 0x000A65CC
	public static BSInvokeUtil getInstance
	{
		get
		{
			if (BSInvokeUtil.Self == null)
			{
				BSInvokeUtil.Self = new BSInvokeUtil();
			}
			return BSInvokeUtil.Self;
		}
	}

	// Token: 0x06000842 RID: 2114 RVA: 0x000A83E8 File Offset: 0x000A65E8
	public static void free()
	{
		if (BSInvokeUtil.Self != null)
		{
			BSInvokeUtil.Self.Dispose();
			BSInvokeUtil.Self = null;
		}
	}

	// Token: 0x06000843 RID: 2115 RVA: 0x000A8404 File Offset: 0x000A6604
	~BSInvokeUtil()
	{
		Debug.Log("~BSInvokeUtil called");
	}

	// Token: 0x06000844 RID: 2116 RVA: 0x000A8444 File Offset: 0x000A6644
	public void Dispose()
	{
		BSInvokeUtil.DllDisposeBSInstance(this.m_pBSObject);
		BSInvokeUtil.DllDisposeCSInstance(this.m_pCSObject);
		BSInvokeUtil.DllDisposeTableInstance();
		this.m_pBSObject = IntPtr.Zero;
		this.m_pCSObject = IntPtr.Zero;
	}

	// Token: 0x06000845 RID: 2117 RVA: 0x000A8478 File Offset: 0x000A6678
	public void InitSimulator(ref BattleInfo battleInfo)
	{
		if (!BSInvokeUtil.DllBSInit(this.m_pBSObject, battleInfo.RandomSeed, battleInfo.RandomGap, battleInfo.BattleType, battleInfo.StageKind, battleInfo.StageID, battleInfo.PrimarySide))
		{
			Debug.LogError(string.Concat(new string[]
			{
				"Init BS Failed IsNull:",
				false.ToString(),
				" RandomSeed: ",
				battleInfo.RandomSeed.ToString(),
				" RandomGap: ",
				battleInfo.RandomGap.ToString(),
				" BattleType: ",
				battleInfo.BattleType.ToString(),
				" StageKind: ",
				battleInfo.StageKind.ToString(),
				" StageID: ",
				battleInfo.StageID.ToString(),
				" PrimarySide: ",
				battleInfo.PrimarySide.ToString()
			}));
		}
	}

	// Token: 0x06000846 RID: 2118 RVA: 0x000A8568 File Offset: 0x000A6768
	public void setHeroState(ushort Side, ushort id, ref CalcAttrDataType attrData)
	{
		BSInvokeUtil.DllBSSetHero(this.m_pBSObject, Side, id, attrData);
	}

	// Token: 0x06000847 RID: 2119 RVA: 0x000A8580 File Offset: 0x000A6780
	public byte updateBattleData(uint Tick, [Out] byte[] pCommandsBuffLeft, [Out] byte[] pCommandsBuffRight, [Out] byte[] pCommandsBuffForServer)
	{
		return BSInvokeUtil.DllBSUpdateClient(this.m_pBSObject, Tick, pCommandsBuffLeft, pCommandsBuffRight, pCommandsBuffForServer);
	}

	// Token: 0x06000848 RID: 2120 RVA: 0x000A8594 File Offset: 0x000A6794
	public void setHeroOver(byte[] pHeroDataLeft, byte[] pHeroDataRight)
	{
		BSInvokeUtil.DLLBSSetHeroOver(this.m_pBSObject, pHeroDataLeft, pHeroDataRight);
	}

	// Token: 0x06000849 RID: 2121 RVA: 0x000A85A4 File Offset: 0x000A67A4
	public byte setNextStage(byte[] pHeroDataLeft, byte[] pHeroDataRight)
	{
		return BSInvokeUtil.DllBSNextStage(this.m_pBSObject, pHeroDataLeft, pHeroDataRight);
	}

	// Token: 0x0600084A RID: 2122 RVA: 0x000A85B4 File Offset: 0x000A67B4
	public uint updateFightScore(ushort HeroID, uint HP, ushort[] pAttr, byte[] SkillLV)
	{
		return BSInvokeUtil.DllUpdateFightScore(this.m_pBSObject, HeroID, HP, pAttr, SkillLV);
	}

	// Token: 0x0600084B RID: 2123 RVA: 0x000A85C8 File Offset: 0x000A67C8
	public void setCalculateAttribute(ushort HeroID, ref CalcAttrDataType CalcAttrData, ref uint HP, [Out] ushort[] pAttr)
	{
		BSInvokeUtil.DllCalculateAttribute(this.m_pBSObject, HeroID, CalcAttrData, ref HP, pAttr);
	}

	// Token: 0x0600084C RID: 2124 RVA: 0x000A85E0 File Offset: 0x000A67E0
	public void setCalculateHeroEquipEffect(ushort HeroID, byte Enhance, byte Equip, ref uint HP, [Out] ushort[] pAttr)
	{
		BSInvokeUtil.DLLCalculateHeroEquipEffect(this.m_pBSObject, HeroID, Enhance, Equip, ref HP, pAttr);
	}

	// Token: 0x0600084D RID: 2125 RVA: 0x000A85F4 File Offset: 0x000A67F4
	public void InitCSSimulator(ushort RndSeed, ushort RndGap)
	{
		if (!BSInvokeUtil.DllCSInit(this.m_pCSObject, RndSeed, RndGap))
		{
			Debug.LogError("Init CS Failed");
		}
	}

	// Token: 0x0600084E RID: 2126 RVA: 0x000A8614 File Offset: 0x000A6814
	public void setCombatInfo(byte LeftLv, TroopLeaderType[] pleftLeaderData, byte leftLeaderNum, uint[,] pleftTroopForce, byte RightLv, TroopLeaderType[] prightLeaderData, byte rightLeaderNum, uint[,] prightTroopForce)
	{
		BSInvokeUtil.DllCSSetCombatInfo(this.m_pCSObject, LeftLv, pleftLeaderData, leftLeaderNum, pleftTroopForce, RightLv, prightLeaderData, rightLeaderNum, prightTroopForce);
	}

	// Token: 0x0600084F RID: 2127 RVA: 0x000A863C File Offset: 0x000A683C
	public int setTroopOver(byte[] pHeroDataLeft, byte[] pHeroDataRight)
	{
		return BSInvokeUtil.DLLCSSetTroopOver(this.m_pCSObject, pHeroDataLeft, pHeroDataRight);
	}

	// Token: 0x06000850 RID: 2128 RVA: 0x000A864C File Offset: 0x000A684C
	public int setTroopAttrData(uint[] pLeftAtk, uint[] pLeftDef, uint[] pLeftHp, uint[] pRightAtk, uint[] pRightDef, uint[] pRightHp)
	{
		return BSInvokeUtil.DllCSSetTroopAttrData(this.m_pCSObject, pLeftAtk, pLeftDef, pLeftHp, pRightAtk, pRightDef, pRightHp);
	}

	// Token: 0x06000851 RID: 2129 RVA: 0x000A8664 File Offset: 0x000A6864
	public int setTrapAttrData(ref CombatCastleDefAttrDataType TrapAttr)
	{
		return BSInvokeUtil.DllCSSetTrapAttrData(this.m_pCSObject, TrapAttr);
	}

	// Token: 0x06000852 RID: 2130 RVA: 0x000A8678 File Offset: 0x000A6878
	public byte updateWarData(uint Tick, byte[] pCommandsBuffLeft, byte[] pCommandsBuffRight)
	{
		return BSInvokeUtil.DllCSUpdateClient(this.m_pCSObject, Tick, pCommandsBuffLeft, pCommandsBuffRight);
	}

	// Token: 0x06000853 RID: 2131 RVA: 0x000A8688 File Offset: 0x000A6888
	public bool setWallTrapInfo(uint WallDefence, uint WallDefenceMax, uint[,] pTrapForce)
	{
		return BSInvokeUtil.DllCSSetWallTrapInfo(this.m_pCSObject, WallDefence, WallDefenceMax, pTrapForce);
	}

	// Token: 0x06000854 RID: 2132 RVA: 0x000A8698 File Offset: 0x000A6898
	public bool initUltra(byte heroIdx, ref byte closetHeroIdx, ref float posX, ref float posY)
	{
		return BSInvokeUtil.DllBSInitUltra(this.m_pBSObject, heroIdx, ref closetHeroIdx, ref posX, ref posY);
	}

	// Token: 0x06000855 RID: 2133 RVA: 0x000A86AC File Offset: 0x000A68AC
	public void ultraInput(byte param1, byte param2)
	{
		BSInvokeUtil.DllBSUltraInput(this.m_pBSObject, param1, param2);
	}

	// Token: 0x06000856 RID: 2134 RVA: 0x000A86BC File Offset: 0x000A68BC
	public uint checkUltraCondition()
	{
		return BSInvokeUtil.DllBSCheckUltraCondition(this.m_pBSObject);
	}

	// Token: 0x06000857 RID: 2135 RVA: 0x000A86CC File Offset: 0x000A68CC
	public uint checkRightUltraCondition()
	{
		return BSInvokeUtil.DllBSCheckRightUltraCondition(this.m_pBSObject);
	}

	// Token: 0x06000858 RID: 2136 RVA: 0x000A86DC File Offset: 0x000A68DC
	public void checkUltraHitTarget(byte Param1, byte Param2, ref uint HitNum)
	{
		BSInvokeUtil.DllBSCheckUltraHitTarget(this.m_pBSObject, Param1, Param2, ref HitNum);
	}

	// Token: 0x06000859 RID: 2137 RVA: 0x000A86EC File Offset: 0x000A68EC
	public unsafe void updateBuildEffectval(uint[] EffVal)
	{
		byte bAlterOpen = 0;
		if (GUIManager.Instance.BuildingData.GetBuildNumByID(19) > 0 && DataManager.Instance.m_AltarEffect.BeginTime > 0L)
		{
			bAlterOpen = 1;
		}
		if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 0)
		{
			fixed (RoleBuildingData* ptr = ref (GUIManager.Instance.BuildingData.AllBuildsData != null && GUIManager.Instance.BuildingData.AllBuildsData.Length != 0) ? ref GUIManager.Instance.BuildingData.AllBuildsData[0] : ref *null)
			{
				BSInvokeUtil.DllCSCalculateBuildingBonus(this.m_pCSObject, ptr + 1, bAlterOpen, EffVal);
			}
		}
	}

	// Token: 0x0600085A RID: 2138 RVA: 0x000A87A0 File Offset: 0x000A69A0
	public void updateTechnlolgyEffectval(uint[] EffVal)
	{
		BSInvokeUtil.DllCSCalculateResearchBonus(this.m_pCSObject, DataManager.Instance.AllTechData, EffVal);
	}

	// Token: 0x0600085B RID: 2139 RVA: 0x000A87B8 File Offset: 0x000A69B8
	public void updateHeroEffectval(byte HeroNum, CalcHeroDataType[] calcHeroData, uint[] EffVal)
	{
		if (HeroNum == 0)
		{
			Array.Clear(EffVal, 0, EffVal.Length);
			return;
		}
		BSInvokeUtil.DllCSCalculateHeroSkillBonus(this.m_pCSObject, HeroNum, calcHeroData, (byte)DataManager.Instance.beCaptured.nowCaptureStat, DataManager.Instance.GetLeaderID(), EffVal);
	}

	// Token: 0x0600085C RID: 2140 RVA: 0x000A8800 File Offset: 0x000A6A00
	public void updateTalentval(uint[] EffVal)
	{
		BSInvokeUtil.DllCSCalculateTalentBonus(this.m_pCSObject, DataManager.Instance.AllTalentData, EffVal);
	}

	// Token: 0x0600085D RID: 2141 RVA: 0x000A8818 File Offset: 0x000A6A18
	public void updateBuffBonus(byte buffNum, ushort[] ItemID, uint[] EffVal)
	{
		byte petBuffNum = PetManager.Instance.UpdateCalculateBuffInfo();
		BSInvokeUtil.DllCSCalculateBuffBonus(this.m_pCSObject, buffNum, ItemID, petBuffNum, PetManager.Instance.CalcPetBuffDataType, EffVal);
	}

	// Token: 0x0600085E RID: 2142 RVA: 0x000A884C File Offset: 0x000A6A4C
	public void updateVIPBonus(uint[] EffVal)
	{
		BSInvokeUtil.DllCSCalculateVIPBonus(this.m_pCSObject, DataManager.Instance.RoleAttr.VIPLevel, EffVal);
	}

	// Token: 0x0600085F RID: 2143 RVA: 0x000A886C File Offset: 0x000A6A6C
	public void updateLordBonus(uint[] EffVal)
	{
		BSInvokeUtil.DllCSCalculateOnLordEquipBonus(this.m_pCSObject, LordEquipData.RoleEquip, EffVal);
	}

	// Token: 0x06000860 RID: 2144 RVA: 0x000A8880 File Offset: 0x000A6A80
	public void updateWonderBonus(uint[] EffVal)
	{
		List<WonderData> wonders = DataManager.Instance.m_Wonders;
		Array.Clear(EffVal, 0, EffVal.Length);
		if (this.WonderCheck == null)
		{
			this.WonderCheck = new byte[DataManager.MapDataController.MapWondersInfoTable.TableCount];
		}
		else
		{
			Array.Clear(this.WonderCheck, 0, this.WonderCheck.Length);
		}
		for (int i = 0; i < wonders.Count; i++)
		{
			if ((int)wonders[i].WonderID < this.WonderCheck.Length && this.WonderCheck[(int)wonders[i].WonderID] <= 0)
			{
				this.WonderCheck[(int)wonders[i].WonderID] = 1;
				BSInvokeUtil.DllCSCalculateWonderBonus(this.m_pCSObject, wonders[i].WonderID + 1, EffVal);
			}
		}
		BSInvokeUtil.DllCSCalculateWonderTitleBonus(this.m_pCSObject, (byte)DataManager.Instance.RoleAttr.KingdomTitle, EffVal);
		BSInvokeUtil.DllCSCalculateWorldTitleBonus(this.m_pCSObject, (byte)DataManager.Instance.RoleAttr.WorldTitle_Personal, (byte)DataManager.Instance.RoleAttr.WorldTitle_Country, EffVal);
		BSInvokeUtil.DllCSCalculateFederalTitleBonus(this.m_pCSObject, (byte)DataManager.Instance.RoleAttr.NobilityTitle, EffVal);
	}

	// Token: 0x06000861 RID: 2145 RVA: 0x000A89D0 File Offset: 0x000A6BD0
	public void updateCastleSkinBonus(uint[] EffVal)
	{
		BuildsData buildingData = GUIManager.Instance.BuildingData;
		if (buildingData.castleSkin.SkinUnlock != null && buildingData.castleSkin.SkinLevel != null && buildingData.GetBuildData(8, 0).Level >= 9)
		{
			BSInvokeUtil.DllCSCalculateCastleSKinBonus(this.m_pCSObject, buildingData.castleSkin.SkinUnlock, buildingData.castleSkin.SkinLevel, EffVal);
		}
	}

	// Token: 0x06000862 RID: 2146 RVA: 0x000A8A44 File Offset: 0x000A6C44
	public void updatePetAttribBonum(uint[] EffVal)
	{
		ushort petDataCount = PetManager.Instance.PetDataCount;
		PetManager instance = PetManager.Instance;
		_CalcPetDataType[] calcPetDataType = PetManager.Instance.CalcPetDataType;
		byte b = 0;
		while ((ushort)b < petDataCount)
		{
			PetData petData = instance.GetPetData((int)b);
			calcPetDataType[(int)b].PetID = petData.ID;
			calcPetDataType[(int)b].Star = petData.Enhance;
			calcPetDataType[(int)b].SkillLV = petData.SkillLv;
			b += 1;
		}
		BSInvokeUtil.DllCSCalculatePetSkillBonus(this.m_pCSObject, petDataCount, calcPetDataType, EffVal);
	}

	// Token: 0x06000863 RID: 2147 RVA: 0x000A8AD4 File Offset: 0x000A6CD4
	public void getCombatStageAttr(byte CombatStageID, ushort Head, byte HeroNum, TroopLeaderType[] pHeroData, uint[] pCalcCombatAttr, uint[] pCalcCombatLoadAttr, uint[] pResultLeftAtk, uint[] pResultLeftDef, uint[] pResultLeftHp, uint[] pResultRightAtk, uint[] pResultRightDef, uint[] pResultRightHp, ref CombatCastleDefAttrDataType pResultTrapAttr, bool bInDeShieldBuff)
	{
		BSInvokeUtil.DllCSGetCombatStageAttr(this.m_pCSObject, CombatStageID, Head, HeroNum, pHeroData, pCalcCombatAttr, pCalcCombatLoadAttr, pResultLeftAtk, pResultLeftDef, pResultLeftHp, pResultRightAtk, pResultRightDef, pResultRightHp, ref pResultTrapAttr, bInDeShieldBuff);
	}

	// Token: 0x06000864 RID: 2148 RVA: 0x000A8B08 File Offset: 0x000A6D08
	public uint getEventDataLen()
	{
		return BSInvokeUtil.DLLBSGetEventDataLen(this.m_pBSObject);
	}

	// Token: 0x06000865 RID: 2149 RVA: 0x000A8B18 File Offset: 0x000A6D18
	public byte SetMonsterHP(uint MaxHP, uint NowHP)
	{
		return BSInvokeUtil.DLLBSSetPVEMonsterHP(this.m_pBSObject, MaxHP, NowHP);
	}

	// Token: 0x06000866 RID: 2150 RVA: 0x000A8B28 File Offset: 0x000A6D28
	public bool SetMonsterAttrData(ref MonsterAttrDataType AttrData)
	{
		return BSInvokeUtil.DLLBSSetPVEMonsterAttr(this.m_pBSObject, AttrData);
	}

	// Token: 0x06000867 RID: 2151 RVA: 0x000A8B3C File Offset: 0x000A6D3C
	public uint GetVersion()
	{
		return BSInvokeUtil.DllGetVersionNum();
	}

	// Token: 0x06000868 RID: 2152 RVA: 0x000A8B44 File Offset: 0x000A6D44
	public void SetArenaTopic(byte TopicID1, byte TopicID2, ArenaTopicEffectDataType Effect1, ArenaTopicEffectDataType Effect2)
	{
		BSInvokeUtil.DLLBSSetArenaTopic(this.m_pBSObject, TopicID1, TopicID2, Effect1, Effect2);
	}

	// Token: 0x06000869 RID: 2153 RVA: 0x000A8B58 File Offset: 0x000A6D58
	public void SetCoordData(ushort LeftCoord, ushort RightCoord)
	{
		BSInvokeUtil.DLLSetCoordData(LeftCoord, RightCoord);
	}

	// Token: 0x0600086A RID: 2154 RVA: 0x000A8B64 File Offset: 0x000A6D64
	public void SetUserData(long UserId, ulong BattleCode)
	{
	}

	// Token: 0x0600086B RID: 2155 RVA: 0x000A8B68 File Offset: 0x000A6D68
	public void CasinoModeInput(byte Param)
	{
		BSInvokeUtil.DLLBSCasinoModeInput(this.m_pBSObject, Param);
	}

	// Token: 0x0600086C RID: 2156 RVA: 0x000A8B78 File Offset: 0x000A6D78
	public void SetHeroChallengeDifficulty(ushort QuestA, ushort QuestB = 0)
	{
		BSInvokeUtil.DLLBSetHeroChallengeDifficulty(this.m_pBSObject, QuestA, QuestB);
	}

	// Token: 0x0600086D RID: 2157 RVA: 0x000A8B88 File Offset: 0x000A6D88
	public byte GetHeroChallengeFailedQuest()
	{
		return BSInvokeUtil.DLLBGetHeroChallengeFailedQuest(this.m_pBSObject);
	}

	// Token: 0x04001C91 RID: 7313
	private IntPtr m_pBSObject = IntPtr.Zero;

	// Token: 0x04001C92 RID: 7314
	private IntPtr m_pCSObject = IntPtr.Zero;

	// Token: 0x04001C93 RID: 7315
	private static BSInvokeUtil Self;

	// Token: 0x04001C94 RID: 7316
	private byte[] WonderCheck;
}
