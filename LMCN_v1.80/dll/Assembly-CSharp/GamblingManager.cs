using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020001E6 RID: 486
public class GamblingManager
{
	// Token: 0x17000071 RID: 113
	// (get) Token: 0x060008D5 RID: 2261 RVA: 0x000B5514 File Offset: 0x000B3714
	public static GamblingManager Instance
	{
		get
		{
			if (GamblingManager.instance == null)
			{
				GamblingManager.instance = new GamblingManager();
			}
			return GamblingManager.instance;
		}
	}

	// Token: 0x060008D6 RID: 2262 RVA: 0x000B5530 File Offset: 0x000B3730
	public void Send_MSG_REQUEST_GAMBLE_INFO()
	{
		if (GUIManager.Instance.ShowUILock(EUILock.UIBattleGambling))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_GAMBLE_INFO;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
		}
	}

	// Token: 0x060008D7 RID: 2263 RVA: 0x000B5574 File Offset: 0x000B3774
	public void Send_MSG_REQUEST_GAMBLE_STARTGAME(byte Type)
	{
		if (GUIManager.Instance.ShowUILock(EUILock.UIBattleGambling))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_GAMBLE_STARTGAME;
			messagePacket.AddSeqId();
			messagePacket.Add(Type);
			messagePacket.Send(false);
		}
	}

	// Token: 0x060008D8 RID: 2264 RVA: 0x000B55C0 File Offset: 0x000B37C0
	public void Send_MSG_REQUEST_GAMBLE_PRIZE()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_GAMBLE_PRIZE;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x060008D9 RID: 2265 RVA: 0x000B55F4 File Offset: 0x000B37F4
	public void Recv_MSG_RESP_GAMBLE_INFO(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		GUIManager.Instance.HideUILock(EUILock.UIBattleGambling);
		if (b == 0 || b == 1)
		{
			this.m_GambleGameInfo.InitGambleGameInfo();
			this.m_GambleGameInfo.BigCost = MP.ReadUInt(-1);
			this.m_GambleGameInfo.SmallCost = MP.ReadUInt(-1);
			for (int i = 0; i < this.m_GambleGameInfo.GambleData.Length; i++)
			{
				this.m_GambleGameInfo.GambleData[i].Stage = MP.ReadByte(-1);
				this.m_GambleGameInfo.GambleData[i].RemainFreePlay = MP.ReadByte(-1);
				if (this.m_GambleGameInfo.GambleData[i].RemainFreePlay != 0 && this.mComboMax == 0)
				{
					this.mComboMax = this.m_GambleGameInfo.GambleData[i].RemainFreePlay;
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 22, 0);
				}
			}
			this.m_GambleGameInfo.Prize = MP.ReadUInt(-1);
			GUIManager guimanager = GUIManager.Instance;
			DataManager dataManager = DataManager.Instance;
			guimanager.bClearWindowStack = false;
			this.BattleMonsterID = this.m_GambleEventSave.MonsterID;
			if (!DataManager.CheckGambleBattleResources())
			{
				GUIManager.Instance.AddHUDMessage(dataManager.mStringTable.GetStringByID(8350u), 255, true);
				return;
			}
			if (BattleController.IsGambleMode)
			{
				BattleController.GambleResult = 0;
				BattleNetwork.RefreshGambleMode(BattleController.GambleMode);
			}
			else
			{
				DataManager.Instance.WorldCameraTransitionsPos = GameConstants.GamblingGuy;
				BattleController.GambleMode = EGambleMode.Normal;
				BattleController.GambleResult = 0;
				BattleController.BattleMode = EBattleMode.Gambling;
				guimanager.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.GambleBattle);
			}
		}
	}

	// Token: 0x060008DA RID: 2266 RVA: 0x000B57B0 File Offset: 0x000B39B0
	public void Recv_MSG_RESP_GAMBLE_STARTGAME(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.UIBattleGambling);
		byte b = 0;
		if (this.GambleMode < (UIBattle_Gambling.eMode)this.m_GambleGameInfo.GambleData.Length)
		{
			b = this.m_GambleGameInfo.GambleData[(int)this.GambleMode].RemainFreePlay;
		}
		bool flag = this.IsDailyFreeScardStar(this.GambleMode);
		byte b2 = MP.ReadByte(-1);
		byte b3 = MP.ReadByte(-1);
		if ((int)b3 >= this.m_GambleGameInfo.GambleData.Length)
		{
			return;
		}
		if (b2 > 100)
		{
			return;
		}
		this.m_GambleGameInfo.GambleData[(int)b3].Stage = MP.ReadByte(-1);
		uint num = MP.ReadUInt(-1);
		GUIManager.Instance.SetRoleAttrDiamond(DataManager.Instance.RoleAttr.Diamond + num, 0, eSpentCredits.eMax);
		DataManager.Instance.RoleAttr.ScardStar = MP.ReadUInt(-1);
		this.m_GambleGameInfo.Prize = MP.ReadUInt(-1);
		CommonItemDataType item = default(CommonItemDataType);
		item.ItemID = MP.ReadUShort(-1);
		item.Num = MP.ReadUShort(-1);
		item.ItemRank = MP.ReadByte(-1);
		int remainFreePlay = (int)this.m_GambleGameInfo.GambleData[(int)b3].RemainFreePlay;
		this.m_GambleGameInfo.GambleData[(int)b3].RemainFreePlay = MP.ReadByte(-1);
		if (remainFreePlay == 0 && this.m_GambleGameInfo.GambleData[(int)b3].RemainFreePlay > 0)
		{
			this.mComboMax = this.m_GambleGameInfo.GambleData[(int)b3].RemainFreePlay;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 22, 0);
		}
		DataManager.Instance.RoleAttr.DailyFreeScardStar = MP.ReadByte(-1);
		if (BattleController.IsGambleMode)
		{
			BattleController battleController = GameManager.ActiveGameplay as BattleController;
			if (b2 == 0)
			{
				BattleNetwork.SetBattleGambleState(EBattleGambleState.MONSTER_HIT);
			}
			else if (b2 == 1 || b2 == 4)
			{
				BattleNetwork.SetBattleGambleState(EBattleGambleState.MONSTER_DIE);
				if (b2 == 4)
				{
					DataManager.MissionDataManager.CheckChanged(eMissionKind.Mark, 159, 1);
				}
			}
			else if (b2 == 2)
			{
				BattleNetwork.SetBattleGambleState(EBattleGambleState.SUPPORT_WORK);
				DataManager.MissionDataManager.CheckChanged(eMissionKind.Mark, 158, 1);
			}
			else if (b2 == 3)
			{
				BattleNetwork.SetBattleGambleState(EBattleGambleState.MONSTER_LEAVE);
			}
			if (b2 != 4 && item.ItemID != 0)
			{
				this.m_QueueGamebleItem.Add(item);
				battleController.AddGambleItemBox(item.ItemID, item.ItemRank);
				if (num == 0u)
				{
					ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(item.ItemID, item.ItemRank);
					DataManager.Instance.SetCurItemQuantity(item.ItemID, curItemQuantity + item.Num, item.ItemRank, 0L);
				}
			}
		}
		if (b2 == 1 || b2 == 2)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 7, 0);
		}
		else if (this.m_GambleGameInfo.GambleData[(int)b3].Stage != 1)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 6, 0);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 8, (int)b2);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_MonsterCrypt, 0, 0);
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
		GameManager.OnRefresh(NetworkNews.Refresh, null);
		if (b != 0 && this.m_GambleGameInfo.GambleData[(int)this.GambleMode].RemainFreePlay == 0 && this.m_GambleGameInfo.GambleData[(int)b3].RemainFreePlay == 0)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 16, 0);
		}
		if (flag && !this.IsDailyFreeScardStar(this.GambleMode) && DataManager.Instance.RoleAttr.DailyFreeScardStar == 1)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 16, 0);
		}
		if (b == 0 && this.m_GambleGameInfo.GambleData[(int)this.GambleMode].RemainFreePlay > 0)
		{
			AudioManager.Instance.PlaySFX(40029, 0f, PitchKind.NoPitch, null, null);
		}
	}

	// Token: 0x060008DB RID: 2267 RVA: 0x000B5BF8 File Offset: 0x000B3DF8
	public void Recv_MSG_RESP_GAMBLE_PRIZE(MessagePacket MP)
	{
		this.m_GambleGameInfo.Prize = MP.ReadUInt(-1);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 2, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_MonsterCrypt, 0, 0);
	}

	// Token: 0x060008DC RID: 2268 RVA: 0x000B5C4C File Offset: 0x000B3E4C
	public void Recv_MSG_GAMBLE_JACKPOT(MessagePacket MP)
	{
		GamblingManager.GamebleJackpot gamebleJackpot = new GamblingManager.GamebleJackpot();
		gamebleJackpot.KingdomID = MP.ReadUShort(-1);
		MP.ReadStringPlus(3, gamebleJackpot.Tag, -1);
		MP.ReadStringPlus(13, gamebleJackpot.Name, -1);
		uint num = MP.ReadUInt(-1);
		gamebleJackpot.PrizeWins = MP.ReadUInt(-1);
		gamebleJackpot.GameType = (UIBattle_Gambling.eMode)MP.ReadByte(-1);
		gamebleJackpot.WonTime = MP.ReadLong(-1);
		bool flag = DataManager.CompareStr(gamebleJackpot.Name, DataManager.Instance.RoleAttr.Name) == 0;
		this.AddJackpotData(gamebleJackpot);
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) || gamebleJackpot.KingdomID == DataManager.MapDataController.kingdomData.kingdomID)
		{
			DataManager dataManager = DataManager.Instance;
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.Append("<color=#FFFF00>");
			cstring.IntToFormat((long)((ulong)gamebleJackpot.PrizeWins), 1, true);
			cstring.AppendFormat(dataManager.mStringTable.GetStringByID(8473u));
			cstring.Append("</color>");
			MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.m_GambleEventSave.MonsterID);
			HeroTeam recordByKey2 = dataManager.TeamTable.GetRecordByKey(recordByKey.MapTeamInfo[0].TeamID);
			Hero recordByKey3 = dataManager.HeroTable.GetRecordByKey(recordByKey2.Arrays[10].Hero);
			CString cstring2 = StringManager.Instance.StaticString1024();
			GameConstants.FormatRoleName(cstring2, gamebleJackpot.Name, gamebleJackpot.Tag, null, 0, (gamebleJackpot.KingdomID != DataManager.MapDataController.kingdomData.kingdomID) ? gamebleJackpot.KingdomID : 0, null, null, null, null);
			CString cstring3 = StringManager.Instance.StaticString1024();
			cstring3.Append("<color=#FFFF00>");
			cstring3.Append(cstring2);
			cstring3.Append("</color>");
			CString cstring4 = StringManager.Instance.SpawnString(1024);
			cstring4.StringToFormat(cstring3);
			if (gamebleJackpot.GameType == UIBattle_Gambling.eMode.Normal)
			{
				cstring4.StringToFormat(dataManager.mStringTable.GetStringByID(9171u));
			}
			else
			{
				cstring4.StringToFormat(dataManager.mStringTable.GetStringByID(9179u));
			}
			cstring4.StringToFormat(dataManager.mStringTable.GetStringByID((uint)recordByKey3.HeroName));
			cstring4.StringToFormat(cstring);
			cstring4.AppendFormat(dataManager.mStringTable.GetStringByID(9180u));
			this.GambleCountStr.Add(cstring4);
			GUIManager.Instance.SetRunningText(cstring4);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 2, 0);
		if (flag)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 9, 0);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_MonsterCrypt, 0, 0);
	}

	// Token: 0x060008DD RID: 2269 RVA: 0x000B5F38 File Offset: 0x000B4138
	public void Recv_MSG_RESP_GAMBLE_UPDATEINFO(MessagePacket MP)
	{
		uint sn = this.m_GambleEventSave.SN;
		this.m_GambleEventSave.SN = MP.ReadUInt(-1);
		this.m_GambleEventSave.State = (EActivityState)MP.ReadByte(-1);
		this.m_GambleEventSave.BeginTime = MP.ReadLong(-1);
		this.m_GambleEventSave.RequireTime = MP.ReadUInt(-1);
		this.m_GambleEventSave.GroupID = MP.ReadUShort(-1);
		this.m_GambleEventSave.MonsterID = MP.ReadUShort(-1);
		if (this.m_GambleEventSave.State != EActivityState.EAS_Run)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 13, 0);
		}
		if (BattleController.IsGambleMode && sn != this.m_GambleEventSave.SN)
		{
			this.Send_MSG_REQUEST_GAMBLE_INFO();
		}
	}

	// Token: 0x060008DE RID: 2270 RVA: 0x000B6004 File Offset: 0x000B4204
	public void Recv_MSG_GAMBLE_HISTORY(MessagePacket MP)
	{
		if (this.m_GamebleJackpots == null)
		{
			return;
		}
		this.m_GamebleJackpots.Clear();
		GamblingManager.GamebleJackpot[] array = new GamblingManager.GamebleJackpot[3];
		for (int i = 0; i < 3; i++)
		{
			array[i] = new GamblingManager.GamebleJackpot();
			array[i].KingdomID = MP.ReadUShort(-1);
			MP.ReadStringPlus(3, array[i].Tag, -1);
			MP.ReadStringPlus(13, array[i].Name, -1);
			array[i].PrizeWins = MP.ReadUInt(-1);
			array[i].GameType = (UIBattle_Gambling.eMode)MP.ReadByte(-1);
			array[i].WonTime = MP.ReadLong(-1);
		}
		int num = 2;
		while (num >= 0 && num < array.Length)
		{
			if (array[num].PrizeWins != 0u)
			{
				this.AddJackpotData(array[num]);
			}
			num--;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 2, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_MonsterCrypt, 0, 0);
	}

	// Token: 0x060008DF RID: 2271 RVA: 0x000B610C File Offset: 0x000B430C
	public void AddJackpotData(GamblingManager.GamebleJackpot data)
	{
		this.m_GamebleJackpots.Insert(0, data);
		if (this.m_GamebleJackpots.Count >= 4)
		{
			this.m_GamebleJackpots.RemoveAt(this.m_GamebleJackpots.Count - 1);
		}
	}

	// Token: 0x060008E0 RID: 2272 RVA: 0x000B6150 File Offset: 0x000B4350
	public uint GetCost()
	{
		if (this.GetRemainFreePlay(this.GambleMode) > 0 || this.IsDailyFreeScardStar(this.GambleMode))
		{
			return 0u;
		}
		if (this.GambleMode == UIBattle_Gambling.eMode.Normal)
		{
			return this.m_GambleGameInfo.SmallCost;
		}
		return this.m_GambleGameInfo.BigCost;
	}

	// Token: 0x060008E1 RID: 2273 RVA: 0x000B61A8 File Offset: 0x000B43A8
	public bool IsDailyFreeScardStar(UIBattle_Gambling.eMode mod)
	{
		if (mod == UIBattle_Gambling.eMode.Turbo)
		{
			bool flag = DataManager.Instance.CheckPrizeFlag(9);
			if (flag)
			{
				bool flag2 = DataManager.Instance.RoleAttr.DailyFreeScardStar == 1 || DataManager.Instance.RoleAttr.DailyFreeScardStar == 3;
				return !flag2;
			}
			return false;
		}
		else
		{
			bool flag3 = DataManager.Instance.CheckPrizeFlag(9);
			if (flag3)
			{
				return DataManager.Instance.RoleAttr.DailyFreeScardStar == 0 && NewbieManager.IsTeachWorking(ETeachKind.GAMBLING1);
			}
			bool flag2 = DataManager.Instance.RoleAttr.DailyFreeScardStar == 2 || DataManager.Instance.RoleAttr.DailyFreeScardStar == 3;
			return !flag2;
		}
	}

	// Token: 0x060008E2 RID: 2274 RVA: 0x000B6268 File Offset: 0x000B4468
	public byte GetRemainFreePlay(UIBattle_Gambling.eMode mod)
	{
		if (mod == UIBattle_Gambling.eMode.Normal)
		{
			return GamblingManager.Instance.m_GambleGameInfo.GambleData[1].RemainFreePlay;
		}
		return GamblingManager.Instance.m_GambleGameInfo.GambleData[0].RemainFreePlay;
	}

	// Token: 0x060008E3 RID: 2275 RVA: 0x000B62B4 File Offset: 0x000B44B4
	public bool IsSpecialType(UIBattle_Gambling.eMode mod)
	{
		int num;
		if (mod == UIBattle_Gambling.eMode.Normal)
		{
			num = 1;
		}
		else
		{
			num = 0;
		}
		return GamblingManager.Instance.m_GambleGameInfo.GambleData[num].Stage > 10;
	}

	// Token: 0x060008E4 RID: 2276 RVA: 0x000B62F4 File Offset: 0x000B44F4
	public void MakeMonsterPriceIndexTable()
	{
		CExternalTableWithWordKey<MonsterPriceTbl>[] gambleMonsterPriceTable = DataManager.Instance.GambleMonsterPriceTable;
		MonsterPriceTbl recordByIndex = gambleMonsterPriceTable[0].GetRecordByIndex(gambleMonsterPriceTable[0].TableCount - 1);
		this.MonsterPriceIndex[0] = new DataIndexTbl[(int)(recordByIndex.Group + 1)];
		recordByIndex = gambleMonsterPriceTable[1].GetRecordByIndex(gambleMonsterPriceTable[1].TableCount - 1);
		this.MonsterPriceIndex[1] = new DataIndexTbl[(int)(recordByIndex.Group + 1)];
		for (int i = 0; i < gambleMonsterPriceTable.Length; i++)
		{
			for (int j = 0; j < gambleMonsterPriceTable[i].TableCount; j++)
			{
				recordByIndex = gambleMonsterPriceTable[i].GetRecordByIndex(j);
				if (this.MonsterPriceIndex[i][(int)recordByIndex.Group].BeginIdx == 0)
				{
					this.MonsterPriceIndex[i][(int)recordByIndex.Group].BeginIdx = (ushort)(j + 1);
				}
				DataIndexTbl[] array = this.MonsterPriceIndex[i];
				ushort group = recordByIndex.Group;
				array[(int)group].Num = array[(int)group].Num + 1;
			}
		}
	}

	// Token: 0x060008E5 RID: 2277 RVA: 0x000B63F4 File Offset: 0x000B45F4
	public bool GetMonsterPriceGroupIndex(ushort group, ref DataIndexTbl Data)
	{
		int gambleMode = (int)BattleController.GambleMode;
		if (gambleMode >= this.MonsterPriceIndex.Length)
		{
			return false;
		}
		Data = this.MonsterPriceIndex[gambleMode][(int)group];
		return true;
	}

	// Token: 0x060008E6 RID: 2278 RVA: 0x000B6434 File Offset: 0x000B4634
	public void ClearGambleStr()
	{
		for (int i = 0; i < this.GambleCountStr.Count; i++)
		{
			StringManager.Instance.DeSpawnString(this.GambleCountStr[i]);
		}
		this.GambleCountStr.Clear();
	}

	// Token: 0x060008E7 RID: 2279 RVA: 0x000B6480 File Offset: 0x000B4680
	public bool OpenMenu(EGUIWindow eWin, int arg1 = 0, int arg2 = 0, bool bCameraMode = false)
	{
		GUIManager guimanager = GUIManager.Instance;
		if (!(guimanager.FindMenu(eWin) != null))
		{
			guimanager.OpenMenu(eWin, arg1, arg2, bCameraMode, false, false);
			GUIWindowStackData item;
			item.m_eWindow = eWin;
			if (eWin == EGUIWindow.UI_Chat)
			{
				arg1 = 0;
			}
			item.m_Arg1 = arg1;
			item.m_Arg2 = arg2;
			item.bCameraMode = bCameraMode;
			guimanager.m_WindowStack.Add(item);
			if (eWin != EGUIWindow.UI_Chat && eWin != EGUIWindow.UI_OpenBox)
			{
				UIBattle_Gambling uibattle_Gambling = guimanager.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
				if (uibattle_Gambling != null)
				{
					uibattle_Gambling.DimPanle.gameObject.SetActive(true);
				}
			}
			else
			{
				UIBattle_Gambling uibattle_Gambling2 = guimanager.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
				if (uibattle_Gambling2 != null)
				{
					uibattle_Gambling2.DimPanle.gameObject.SetActive(false);
				}
			}
			guimanager.UpdateUI(EGUIWindow.UI_Battle_Gambling, 11, 0);
			return true;
		}
		if (guimanager.m_Chat != null && guimanager.m_Chat.activeInHierarchy)
		{
			guimanager.CloseMenu(guimanager.Chatwin.m_eWindow);
			GUIWindowStackData item2;
			item2.m_eWindow = eWin;
			item2.m_Arg1 = arg1;
			item2.m_Arg2 = arg2;
			item2.bCameraMode = bCameraMode;
			guimanager.m_WindowStack.Add(item2);
			return true;
		}
		return false;
	}

	// Token: 0x060008E8 RID: 2280 RVA: 0x000B65D4 File Offset: 0x000B47D4
	public void CloseMenu(bool bClear = false)
	{
		GUIManager guimanager = GUIManager.Instance;
		if (guimanager.m_WindowStack.Count == 0)
		{
			return;
		}
		EGUIWindow eWindow = guimanager.m_WindowStack[guimanager.m_WindowStack.Count - 1].m_eWindow;
		if (bClear)
		{
			for (int i = guimanager.m_WindowStack.Count - 1; i > -1; i--)
			{
				guimanager.CloseMenu(guimanager.m_WindowStack[i].m_eWindow);
			}
			guimanager.m_WindowStack.Clear();
			guimanager.bClearWindowStack = bClear;
		}
		else
		{
			guimanager.CloseMenu(eWindow);
			guimanager.m_WindowStack.RemoveAt(guimanager.m_WindowStack.Count - 1);
		}
		if (guimanager.m_WindowStack.Count == 0)
		{
			UIBattle_Gambling uibattle_Gambling = guimanager.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
			if (uibattle_Gambling != null)
			{
				uibattle_Gambling.DimPanle.gameObject.SetActive(false);
			}
			if (guimanager.m_ChatBox != null)
			{
				guimanager.m_ChatBox.gameObject.SetActive(true);
			}
			guimanager.UpdateUI(EGUIWindow.UI_Battle_Gambling, 10, 0);
		}
		else
		{
			if (guimanager.m_Window2 == null || eWindow != EGUIWindow.UI_Chat)
			{
				guimanager.OpenMenu(guimanager.m_WindowStack[guimanager.m_WindowStack.Count - 1].m_eWindow, guimanager.m_WindowStack[guimanager.m_WindowStack.Count - 1].m_Arg1, guimanager.m_WindowStack[guimanager.m_WindowStack.Count - 1].m_Arg2, guimanager.m_WindowStack[guimanager.m_WindowStack.Count - 1].bCameraMode, false, false);
			}
			else
			{
				guimanager.m_Window2.ReOnOpen();
			}
			if (guimanager.m_WindowStack[guimanager.m_WindowStack.Count - 1].m_eWindow != EGUIWindow.UI_Chat && guimanager.m_WindowStack[guimanager.m_WindowStack.Count - 1].m_eWindow != EGUIWindow.UI_OpenBox)
			{
				UIBattle_Gambling uibattle_Gambling2 = guimanager.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
				if (uibattle_Gambling2 != null)
				{
					uibattle_Gambling2.DimPanle.gameObject.SetActive(true);
				}
			}
			else
			{
				UIBattle_Gambling uibattle_Gambling3 = guimanager.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
				if (uibattle_Gambling3 != null)
				{
					uibattle_Gambling3.DimPanle.gameObject.SetActive(false);
				}
			}
			guimanager.UpdateUI(EGUIWindow.UI_Battle_Gambling, 11, 0);
		}
	}

	// Token: 0x060008E9 RID: 2281 RVA: 0x000B6880 File Offset: 0x000B4A80
	public bool OnBackButtonClick()
	{
		GUIManager guimanager = GUIManager.Instance;
		if (guimanager.m_WindowStack.Count != 0)
		{
			GUIWindow guiwindow = guimanager.FindMenu(guimanager.m_WindowStack[guimanager.m_WindowStack.Count - 1].m_eWindow);
			if (guiwindow != null && guiwindow.OnBackButtonClick())
			{
				return true;
			}
			this.CloseMenu(false);
		}
		else
		{
			UIBattle_Gambling uibattle_Gambling = guimanager.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
			if (uibattle_Gambling != null)
			{
				uibattle_Gambling.CloseUI();
			}
		}
		return true;
	}

	// Token: 0x060008EA RID: 2282 RVA: 0x000B6914 File Offset: 0x000B4B14
	public void saveGambleMode()
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.uLongToFormat((ulong)DataManager.Instance.RoleAttr.UserId, 1, false);
		cstring.AppendFormat("{0}_GambleMode");
		PlayerPrefs.SetInt(cstring.ToString(), (int)(this.GambleMode + 1));
	}

	// Token: 0x060008EB RID: 2283 RVA: 0x000B6968 File Offset: 0x000B4B68
	public void loadGambleMode()
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.uLongToFormat((ulong)DataManager.Instance.RoleAttr.UserId, 1, false);
		cstring.AppendFormat("{0}_GambleMode");
		int @int = PlayerPrefs.GetInt(cstring.ToString());
		if (@int > 0 && @int < 3)
		{
			this.GambleMode = (UIBattle_Gambling.eMode)(@int - 1);
		}
		else
		{
			this.GambleMode = UIBattle_Gambling.eMode.Normal;
			this.saveGambleMode();
		}
	}

	// Token: 0x04001D87 RID: 7559
	private const int MaxGambleGameDataNum = 2;

	// Token: 0x04001D88 RID: 7560
	private static GamblingManager instance;

	// Token: 0x04001D89 RID: 7561
	public GamblingManager.GambleGameInfo m_GambleGameInfo;

	// Token: 0x04001D8A RID: 7562
	public GamblingManager.GambleEventSave m_GambleEventSave;

	// Token: 0x04001D8B RID: 7563
	public Vector2 m_ItemPos;

	// Token: 0x04001D8C RID: 7564
	public List<GamblingManager.GamebleJackpot> m_GamebleJackpots = new List<GamblingManager.GamebleJackpot>();

	// Token: 0x04001D8D RID: 7565
	public List<CommonItemDataType> m_QueueGamebleItem = new List<CommonItemDataType>();

	// Token: 0x04001D8E RID: 7566
	public UIBattle_Gambling.eMode GambleMode = UIBattle_Gambling.eMode.Normal;

	// Token: 0x04001D8F RID: 7567
	public bool bIsFirstOpen;

	// Token: 0x04001D90 RID: 7568
	public GambleBoxAnim m_GambleBoxAnim;

	// Token: 0x04001D91 RID: 7569
	public NpcParticleType m_NpcParticleType;

	// Token: 0x04001D92 RID: 7570
	public HeroBattleData[] BattleHeroData = new HeroBattleData[5];

	// Token: 0x04001D93 RID: 7571
	public byte BattleHeroCount;

	// Token: 0x04001D94 RID: 7572
	public ushort BattleMonsterID;

	// Token: 0x04001D95 RID: 7573
	private DataIndexTbl[][] MonsterPriceIndex = new DataIndexTbl[2][];

	// Token: 0x04001D96 RID: 7574
	public List<CString> GambleCountStr = new List<CString>();

	// Token: 0x04001D97 RID: 7575
	public byte bOpenTreasure;

	// Token: 0x04001D98 RID: 7576
	public byte mComboMax;

	// Token: 0x020001E7 RID: 487
	public struct GambleEventSave
	{
		// Token: 0x04001D99 RID: 7577
		public uint SN;

		// Token: 0x04001D9A RID: 7578
		public EActivityState State;

		// Token: 0x04001D9B RID: 7579
		public long BeginTime;

		// Token: 0x04001D9C RID: 7580
		public uint RequireTime;

		// Token: 0x04001D9D RID: 7581
		public ushort GroupID;

		// Token: 0x04001D9E RID: 7582
		public ushort MonsterID;
	}

	// Token: 0x020001E8 RID: 488
	public struct GambleGameData
	{
		// Token: 0x060008EC RID: 2284 RVA: 0x000B69E0 File Offset: 0x000B4BE0
		public void InitGambleGameData()
		{
			this.Stage = 0;
			this.RemainFreePlay = 0;
		}

		// Token: 0x04001D9F RID: 7583
		public byte Stage;

		// Token: 0x04001DA0 RID: 7584
		public byte RemainFreePlay;
	}

	// Token: 0x020001E9 RID: 489
	public struct GambleGameInfo
	{
		// Token: 0x060008ED RID: 2285 RVA: 0x000B69F0 File Offset: 0x000B4BF0
		public void InitGambleGameInfo()
		{
			this.BigCost = 0u;
			this.SmallCost = 0u;
			this.GambleData = new GamblingManager.GambleGameData[2];
			for (int i = 0; i < this.GambleData.Length; i++)
			{
				this.GambleData[i].InitGambleGameData();
			}
		}

		// Token: 0x04001DA1 RID: 7585
		public uint BigCost;

		// Token: 0x04001DA2 RID: 7586
		public uint SmallCost;

		// Token: 0x04001DA3 RID: 7587
		public GamblingManager.GambleGameData[] GambleData;

		// Token: 0x04001DA4 RID: 7588
		public uint Prize;
	}

	// Token: 0x020001EA RID: 490
	public class GamebleJackpot
	{
		// Token: 0x060008EE RID: 2286 RVA: 0x000B6A44 File Offset: 0x000B4C44
		public GamebleJackpot()
		{
			this.KingdomID = 0;
			this.Tag = StringManager.Instance.SpawnString(30);
			this.Name = StringManager.Instance.SpawnString(30);
			this.PrizeWins = 0u;
			this.GameType = UIBattle_Gambling.eMode.Normal;
			this.WonTime = 0L;
		}

		// Token: 0x04001DA5 RID: 7589
		public ushort KingdomID;

		// Token: 0x04001DA6 RID: 7590
		public CString Tag;

		// Token: 0x04001DA7 RID: 7591
		public CString Name;

		// Token: 0x04001DA8 RID: 7592
		public uint PrizeWins;

		// Token: 0x04001DA9 RID: 7593
		public UIBattle_Gambling.eMode GameType;

		// Token: 0x04001DAA RID: 7594
		public long WonTime;
	}
}
