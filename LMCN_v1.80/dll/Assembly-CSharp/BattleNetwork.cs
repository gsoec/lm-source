using System;
using UnityEngine;

// Token: 0x020001DF RID: 479
public class BattleNetwork
{
	// Token: 0x060008C0 RID: 2240 RVA: 0x000B4154 File Offset: 0x000B2354
	public static bool sendInitBattle()
	{
		if (DataManager.StageDataController._stageMode == StageMode.Dare)
		{
			return BattleNetwork.sendInitBattleEx();
		}
		if (!GUIManager.Instance.ShowUILock(EUILock.Battle))
		{
			return false;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_BATTLEINIT_NPC;
		ushort currentPointID = BattleNetwork.battlePointID;
		if (!BattleNetwork.bReplay)
		{
			currentPointID = DataManager.StageDataController.currentPointID;
			BattleNetwork.battlePointID = currentPointID;
		}
		messagePacket.Add((byte)(DataManager.StageDataController._stageMode + 1));
		messagePacket.Add(currentPointID);
		for (int i = 0; i < 5; i++)
		{
			messagePacket.Add(DataManager.Instance.heroBattleData[i].HeroID);
		}
		if (!messagePacket.Send(false))
		{
			GUIManager.Instance.HideUILock(EUILock.Battle);
			return false;
		}
		return true;
	}

	// Token: 0x060008C1 RID: 2241 RVA: 0x000B4228 File Offset: 0x000B2428
	public static void RecvInitBattle(MessagePacket MP)
	{
		DataManager instance = DataManager.Instance;
		GUIManager.Instance.HideUILock(EUILock.Battle);
		BATTLEINIT_RESULT battleinit_RESULT = (BATTLEINIT_RESULT)MP.ReadByte(-1);
		if (battleinit_RESULT == BATTLEINIT_RESULT.BATTLEINIT_RESULT_SUCCESS)
		{
			instance.BattleSeqID = MP.ReadULong(-1);
			byte b = MP.ReadByte(-1);
			ushort num = MP.ReadUShort(-1);
			ushort randomSeed = MP.ReadUShort(-1);
			byte randomGap = MP.ReadByte(-1);
			DataManager.StageDataController.UpdateRoleAttrMorale(MP.ReadUShort(-1));
			for (int i = 0; i < 5; i++)
			{
				instance.heroBattleData[i].HeroID = MP.ReadUShort(-1);
			}
			for (int j = 0; j < 5; j++)
			{
				instance.heroBattleData[j].AttrData.SkillLV1 = MP.ReadByte(-1);
				instance.heroBattleData[j].AttrData.SkillLV2 = MP.ReadByte(-1);
				instance.heroBattleData[j].AttrData.SkillLV3 = MP.ReadByte(-1);
				instance.heroBattleData[j].AttrData.SkillLV4 = MP.ReadByte(-1);
				instance.heroBattleData[j].AttrData.LV = MP.ReadByte(-1);
				instance.heroBattleData[j].AttrData.Star = MP.ReadByte(-1);
				instance.heroBattleData[j].AttrData.Enhance = MP.ReadByte(-1);
				instance.heroBattleData[j].AttrData.Equip = MP.ReadByte(-1);
			}
			MP.ReadBlock(instance.RewardLen, 0, 4, -1);
			instance.RewardCount = (int)(instance.RewardLen[0] + instance.RewardLen[1] + instance.RewardLen[2] + instance.RewardLen[3]);
			for (int k = 0; k < instance.RewardCount; k++)
			{
				instance.RewardData[k] = MP.ReadUShort(-1);
			}
			instance.battleInfo.RandomSeed = randomSeed;
			instance.battleInfo.RandomGap = (ushort)randomGap;
			instance.battleInfo.BattleType = 1;
			BattleNetwork.SendBattleEndStatus = 0;
			GameManager.OnRefresh(NetworkNews.Refresh, null);
			if (!BattleNetwork.bReplay)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 0, 0);
			}
			else
			{
				BattleNetwork.bReplay = false;
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleReplay);
				AudioManager.Instance.LoadAndPlayBGM(BGMType.War, 1, false);
			}
		}
		else if (!BattleNetwork.bReplay)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 1, 0);
			uint id = (uint)((byte)660 + battleinit_RESULT);
			GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(id), 2, true);
		}
		else
		{
			BattleNetwork.bReplay = false;
			uint id2 = (uint)((byte)660 + battleinit_RESULT);
			GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(id2), 2, true);
		}
	}

	// Token: 0x060008C2 RID: 2242 RVA: 0x000B4510 File Offset: 0x000B2710
	public static bool sendBattleEnd()
	{
		if (DataManager.StageDataController._stageMode == StageMode.Dare)
		{
			return BattleNetwork.sendBattleEndEx();
		}
		if (!GUIManager.Instance.ShowUILock(EUILock.Battle))
		{
			return false;
		}
		ushort num = (ushort)BSInvokeUtil.getInstance.getEventDataLen();
		int num2 = (int)(num + 22);
		if (num2 < 1024)
		{
			num2 = 1024;
		}
		MessagePacket messagePacket = new MessagePacket((ushort)num2);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_BATTLEEND;
		messagePacket.Add(DataManager.Instance.BattleSeqID);
		messagePacket.Add(num);
		messagePacket.Add(BattleController.EventBuffer, 0, (int)num);
		if (!messagePacket.Send(false))
		{
			GUIManager.Instance.HideUILock(EUILock.Battle);
			return false;
		}
		return true;
	}

	// Token: 0x060008C3 RID: 2243 RVA: 0x000B45C0 File Offset: 0x000B27C0
	public static void RecvBattleEnd(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Battle);
		DataManager instance = DataManager.Instance;
		byte b = MP.ReadByte(-1);
		instance.lastBattleResult = (short)b;
		instance.BattleSeqID = 0UL;
		BattleNetwork.SendBattleEndStatus = 0;
		if (b != 0)
		{
			instance.RWMoney = (uint)DataManager.StageDataController.GetLevelBycurrentPointID(0).Money;
			instance.KingOldLv = instance.RoleAttr.Level;
			instance.KingOldExp = instance.RoleAttr.Exp;
			DataManager.StageDataController.RoleAttrLevelUp(MP, 63);
			byte b2 = MP.ReadByte(-1);
			ushort in_StageRecord = MP.ReadUShort(-1);
			ushort freq = MP.ReadUShort(-1);
			b2 -= 1;
			DataManager.StageDataController.SetStagePoint(BattleNetwork.battlePointID, b, freq);
			DataManager.StageDataController.UpdateStageRecord((StageMode)b2, in_StageRecord);
			BattleNetwork.bStageFirstTry[(int)b2] = true;
			for (int i = 0; i < 5; i++)
			{
				ushort num = MP.ReadUShort(-1);
				if (num != 0 && instance.curHeroData.ContainsKey((uint)num))
				{
					CurHeroData curHeroData = instance.curHeroData[(uint)num];
					instance.heroLv[i] = curHeroData.Level;
					instance.heroExp[i] = curHeroData.Exp;
					instance.UpdateHeroAttr(num, MP);
				}
				else
				{
					MP.ReadByte(-1);
					MP.ReadUInt(-1);
					MP.ReadUInt(-1);
				}
			}
			int num2 = 0;
			while (num2 < instance.RewardCount && num2 < 128)
			{
				ushort itemID = instance.RewardData[num2];
				ushort curItemQuantity = instance.GetCurItemQuantity(itemID, 0);
				if (curItemQuantity < 65535)
				{
					instance.SetCurItemQuantity(itemID, curItemQuantity + 1, 0, 0L);
				}
				num2++;
			}
			GameManager.OnRefresh(NetworkNews.Refresh, null);
			GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
			if (instance.KingOldLv != instance.RoleAttr.Level)
			{
				GameManager.OnRefresh(NetworkNews.Refresh_Attr, null);
			}
			DataManager.msgBuffer[0] = 32;
			DataManager.msgBuffer[1] = 2;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			AFAdvanceManager.Instance.CheckHeroStageUnbroken();
		}
	}

	// Token: 0x060008C4 RID: 2244 RVA: 0x000B47CC File Offset: 0x000B29CC
	public static int GambleGetHeroPriority(ushort _heroID)
	{
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(_heroID);
		if (recordByKey.HeroKey == _heroID)
		{
			if (recordByKey.Pos >= 1 && recordByKey.Pos <= 300)
			{
				return 0;
			}
			if (recordByKey.Pos >= 301 && recordByKey.Pos <= 600)
			{
				return 1;
			}
			if (recordByKey.Pos >= 601 && recordByKey.Pos <= 1000)
			{
				return 2;
			}
		}
		return -1;
	}

	// Token: 0x060008C5 RID: 2245 RVA: 0x000B4860 File Offset: 0x000B2A60
	public static void GambleGetRandomHero()
	{
		Array.Clear(BattleNetwork.GambleHeroIDTemp, 0, 15);
		Array.Clear(BattleNetwork.GambleHeroCount, 0, 3);
		Array.Clear(BattleNetwork.GambleActionHeroIDTemp, 0, 5);
		GamblingManager instance = GamblingManager.Instance;
		DataManager instance2 = DataManager.Instance;
		int num = 0;
		int num2 = 0;
		while ((long)num2 < (long)((ulong)instance2.CurHeroDataCount))
		{
			ushort num3 = (ushort)instance2.sortHeroData[num2];
			int num4 = BattleNetwork.GambleGetHeroPriority(num3);
			if (num4 != -1 && DataManager.CheckHeroResourceReady(num3))
			{
				BattleNetwork.GambleHeroIDTemp[num4, BattleNetwork.GambleHeroCount[num4]] = num3;
				BattleNetwork.GambleHeroCount[num4]++;
			}
			num2++;
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < BattleNetwork.GambleHeroPriorityCount[i]; j++)
			{
				if (BattleNetwork.GambleHeroCount[i] > 0)
				{
					int num5 = UnityEngine.Random.Range(0, BattleNetwork.GambleHeroCount[i]);
					BattleNetwork.GambleActionHeroIDTemp[num] = BattleNetwork.GambleHeroIDTemp[i, num5];
					num++;
					BattleNetwork.GambleHeroIDTemp[i, num5] = BattleNetwork.GambleHeroIDTemp[i, BattleNetwork.GambleHeroCount[i] - 1];
					BattleNetwork.GambleHeroCount[i]--;
				}
			}
		}
		int num6;
		do
		{
			num6 = 0;
			if (BattleNetwork.GambleHeroCount[1] > 0)
			{
				BattleNetwork.GambleHeroIDTemp[0, BattleNetwork.GambleHeroCount[0]] = BattleNetwork.GambleHeroIDTemp[1, 0];
				BattleNetwork.GambleHeroCount[0]++;
				BattleNetwork.GambleHeroCount[1]--;
			}
			else
			{
				num6++;
			}
			if (BattleNetwork.GambleHeroCount[2] > 0)
			{
				BattleNetwork.GambleHeroIDTemp[0, BattleNetwork.GambleHeroCount[0]] = BattleNetwork.GambleHeroIDTemp[2, 0];
				BattleNetwork.GambleHeroCount[0]++;
				BattleNetwork.GambleHeroCount[2]--;
			}
			else
			{
				num6++;
			}
		}
		while (num6 != 2);
		for (int k = 0; k < 5; k++)
		{
			if (BattleNetwork.GambleActionHeroIDTemp[k] == 0 && BattleNetwork.GambleHeroCount[0] > 0)
			{
				int num7 = UnityEngine.Random.Range(0, BattleNetwork.GambleHeroCount[0]);
				BattleNetwork.GambleActionHeroIDTemp[k] = BattleNetwork.GambleHeroIDTemp[0, num7];
				BattleNetwork.GambleHeroIDTemp[0, num7] = BattleNetwork.GambleHeroIDTemp[0, BattleNetwork.GambleHeroCount[0] - 1];
				BattleNetwork.GambleHeroCount[0]--;
			}
		}
		instance.BattleHeroCount = 0;
		Array.Clear(instance.BattleHeroData, 0, 5);
		for (int l = 0; l < 5; l++)
		{
			if (BattleNetwork.GambleActionHeroIDTemp[l] != 0)
			{
				instance.BattleHeroData[(int)instance.BattleHeroCount].HeroID = BattleNetwork.GambleActionHeroIDTemp[l];
				GamblingManager gamblingManager = instance;
				gamblingManager.BattleHeroCount += 1;
			}
		}
		for (int m = 0; m < (int)instance.BattleHeroCount; m++)
		{
			CurHeroData curHeroData = instance2.curHeroData[(uint)instance.BattleHeroData[m].HeroID];
			instance.BattleHeroData[m].AttrData.SkillLV1 = curHeroData.SkillLV[0];
			instance.BattleHeroData[m].AttrData.SkillLV2 = curHeroData.SkillLV[1];
			instance.BattleHeroData[m].AttrData.SkillLV3 = curHeroData.SkillLV[2];
			instance.BattleHeroData[m].AttrData.SkillLV4 = curHeroData.SkillLV[3];
			instance.BattleHeroData[m].AttrData.LV = curHeroData.Level;
			instance.BattleHeroData[m].AttrData.Star = curHeroData.Star;
			instance.BattleHeroData[m].AttrData.Enhance = curHeroData.Enhance;
			instance.BattleHeroData[m].AttrData.Equip = curHeroData.Equip;
		}
	}

	// Token: 0x060008C6 RID: 2246 RVA: 0x000B4C84 File Offset: 0x000B2E84
	public static void RefreshGambleMode(EGambleMode mode)
	{
		if (!BattleController.IsGambleMode)
		{
			return;
		}
		BattleController.GambleMode = mode;
		GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.GambleSwitchMode);
	}

	// Token: 0x060008C7 RID: 2247 RVA: 0x000B4CAC File Offset: 0x000B2EAC
	public static void SetBattleGambleState(EBattleGambleState state)
	{
		if (!BattleController.IsGambleMode)
		{
			return;
		}
		BattleController battleController = GameManager.ActiveGameplay as BattleController;
		if (state == EBattleGambleState.SUPPORT_WORK)
		{
			BSInvokeUtil.getInstance.CasinoModeInput(3);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 5, 0);
		}
		else if (state == EBattleGambleState.MONSTER_DIE)
		{
			BSInvokeUtil.getInstance.CasinoModeInput(2);
			BattleController.GambleResult = 1;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 5, 0);
		}
		else if (state == EBattleGambleState.MONSTER_LEAVE)
		{
			BattleController.GambleResult = 2;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 5, 0);
		}
		else if (state == EBattleGambleState.MONSTER_HIT)
		{
			BSInvokeUtil.getInstance.CasinoModeInput(1);
		}
	}

	// Token: 0x060008C8 RID: 2248 RVA: 0x000B4D5C File Offset: 0x000B2F5C
	public static bool sendInitBattleEx()
	{
		if (!GUIManager.Instance.ShowUILock(EUILock.Battle))
		{
			return false;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_EX_BATTLEINIT_NPC;
		ushort num = BattleNetwork.battlePointID;
		if (!BattleNetwork.bReplay)
		{
			num = DataManager.StageDataController.currentPointID;
			BattleNetwork.battlePointID = num;
		}
		StageMode stageMode = DataManager.StageDataController.StageDareMode(BattleNetwork.battlePointID);
		messagePacket.Add((stageMode != StageMode.Full) ? 2 : 1);
		if (stageMode == StageMode.Lean)
		{
			num /= 3;
		}
		messagePacket.Add(num);
		for (int i = 0; i < 5; i++)
		{
			messagePacket.Add(DataManager.Instance.heroBattleData[i].HeroID);
		}
		byte currentNodus = DataManager.StageDataController.currentNodus;
		messagePacket.Add(currentNodus);
		if (!messagePacket.Send(false))
		{
			GUIManager.Instance.HideUILock(EUILock.Battle);
			return false;
		}
		StageManager stageDataController = DataManager.StageDataController;
		DataManager instance = DataManager.Instance;
		if (stageDataController.StageDareMode(num) == StageMode.Lean)
		{
			LevelEX levelEXBycurrentPointID = stageDataController.GetLevelEXBycurrentPointID(0);
			if (currentNodus == 1)
			{
				instance.BattleConditionKey = levelEXBycurrentPointID.NodusOneID;
			}
			else if (currentNodus == 2)
			{
				instance.BattleConditionKey = levelEXBycurrentPointID.NodusTwoID;
			}
			else if (currentNodus == 3)
			{
				instance.BattleConditionKey = levelEXBycurrentPointID.NodusThrID;
			}
		}
		else
		{
			instance.BattleConditionKey = stageDataController.GetLevelEXBycurrentPointID(0).NodusTwoID;
		}
		return true;
	}

	// Token: 0x060008C9 RID: 2249 RVA: 0x000B4EDC File Offset: 0x000B30DC
	public static void RecvInitBattleEx(MessagePacket MP)
	{
		DataManager instance = DataManager.Instance;
		GUIManager.Instance.HideUILock(EUILock.Battle);
		BATTLEINIT_RESULT battleinit_RESULT = (BATTLEINIT_RESULT)MP.ReadByte(-1);
		if (battleinit_RESULT == BATTLEINIT_RESULT.BATTLEINIT_RESULT_SUCCESS)
		{
			instance.BattleSeqID = MP.ReadULong(-1);
			byte b = MP.ReadByte(-1);
			ushort num = MP.ReadUShort(-1);
			byte b2 = MP.ReadByte(-1);
			ushort randomSeed = MP.ReadUShort(-1);
			byte randomGap = MP.ReadByte(-1);
			for (int i = 0; i < 5; i++)
			{
				instance.heroBattleData[i].HeroID = MP.ReadUShort(-1);
			}
			for (int j = 0; j < 5; j++)
			{
				instance.heroBattleData[j].AttrData.SkillLV1 = MP.ReadByte(-1);
				instance.heroBattleData[j].AttrData.SkillLV2 = MP.ReadByte(-1);
				instance.heroBattleData[j].AttrData.SkillLV3 = MP.ReadByte(-1);
				instance.heroBattleData[j].AttrData.SkillLV4 = MP.ReadByte(-1);
				instance.heroBattleData[j].AttrData.LV = MP.ReadByte(-1);
				instance.heroBattleData[j].AttrData.Star = MP.ReadByte(-1);
				instance.heroBattleData[j].AttrData.Enhance = MP.ReadByte(-1);
				instance.heroBattleData[j].AttrData.Equip = MP.ReadByte(-1);
			}
			instance.battleInfo.RandomSeed = randomSeed;
			instance.battleInfo.RandomGap = (ushort)randomGap;
			instance.battleInfo.BattleType = 6;
			BattleNetwork.SendBattleEndStatus = 0;
			GameManager.OnRefresh(NetworkNews.Refresh, null);
			if (!BattleNetwork.bReplay)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 0, 0);
			}
			else
			{
				BattleNetwork.bReplay = false;
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleReplay);
				AudioManager.Instance.LoadAndPlayBGM(BGMType.War, 1, false);
			}
		}
		else if (!BattleNetwork.bReplay)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 1, 0);
			uint id = (uint)((byte)660 + battleinit_RESULT);
			GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(id), 2, true);
		}
		else
		{
			BattleNetwork.bReplay = false;
			uint id2 = (uint)((byte)660 + battleinit_RESULT);
			GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(id2), 2, true);
		}
	}

	// Token: 0x060008CA RID: 2250 RVA: 0x000B5158 File Offset: 0x000B3358
	public static bool sendBattleEndEx()
	{
		if (!GUIManager.Instance.ShowUILock(EUILock.Battle))
		{
			return false;
		}
		ushort num = (ushort)BSInvokeUtil.getInstance.getEventDataLen();
		int num2 = (int)(num + 22);
		if (num2 < 1024)
		{
			num2 = 1024;
		}
		MessagePacket messagePacket = new MessagePacket((ushort)num2);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_EX_BATTLEEND;
		messagePacket.Add(DataManager.Instance.BattleSeqID);
		messagePacket.Add(num);
		messagePacket.Add(BattleController.EventBuffer, 0, (int)num);
		if (!messagePacket.Send(false))
		{
			GUIManager.Instance.HideUILock(EUILock.Battle);
			return false;
		}
		return true;
	}

	// Token: 0x060008CB RID: 2251 RVA: 0x000B51F4 File Offset: 0x000B33F4
	public static void RecvBattleEndEx(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Battle);
		DataManager instance = DataManager.Instance;
		byte b = MP.ReadByte(-1);
		instance.BattleFailureIndex = MP.ReadByte(-1);
		instance.lastBattleResult = (short)b;
		instance.BattleSeqID = 0UL;
		BattleNetwork.SendBattleEndStatus = 0;
		if (b != 0)
		{
			instance.RWMoney = 0u;
			instance.KingOldLv = instance.RoleAttr.Level;
			instance.KingOldExp = instance.RoleAttr.Exp;
			byte b2 = MP.ReadByte(-1);
			ushort num = MP.ReadUShort(-1);
			byte b3 = MP.ReadByte(-1);
			ushort num2 = MP.ReadUShort(-1);
			if (b2 == 1)
			{
				DataManager.StageDataController.UpdateStageRecord(StageMode.Dare, num);
			}
			else if (b2 == 2)
			{
				DataManager.StageDataController.SetStagePoint(BattleNetwork.battlePointID, b3, 1);
			}
			if (num2 > 0)
			{
				DataManager instance2 = DataManager.Instance;
				instance2.RoleAttr.Diamond = instance2.RoleAttr.Diamond + (uint)num2;
				GUIManager.Instance.SetChallegeRewardUI((int)num2, num, b3);
			}
			GameManager.OnRefresh(NetworkNews.Refresh, null);
			GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
			if (instance.KingOldLv != instance.RoleAttr.Level)
			{
				GameManager.OnRefresh(NetworkNews.Refresh_Attr, null);
			}
			DataManager.msgBuffer[0] = 32;
			DataManager.msgBuffer[1] = 2;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
	}

	// Token: 0x04001D67 RID: 7527
	public static bool bReplay = false;

	// Token: 0x04001D68 RID: 7528
	public static bool[] bStageFirstTry = new bool[4];

	// Token: 0x04001D69 RID: 7529
	public static ushort battlePointID = 0;

	// Token: 0x04001D6A RID: 7530
	public static byte NetworkError = 0;

	// Token: 0x04001D6B RID: 7531
	public static byte SendBattleEndStatus = 0;

	// Token: 0x04001D6C RID: 7532
	private static ushort[,] GambleHeroIDTemp = new ushort[3, 100];

	// Token: 0x04001D6D RID: 7533
	private static ushort[] GambleActionHeroIDTemp = new ushort[5];

	// Token: 0x04001D6E RID: 7534
	private static int[] GambleHeroCount = new int[3];

	// Token: 0x04001D6F RID: 7535
	private static readonly int[] GambleHeroPriorityCount = new int[]
	{
		1,
		2,
		2
	};
}
