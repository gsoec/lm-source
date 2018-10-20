using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000393 RID: 915
public class LeaderBoardManager
{
	// Token: 0x060012D0 RID: 4816 RVA: 0x0020D414 File Offset: 0x0020B614
	private LeaderBoardManager()
	{
		this.BoardUpdateTime = new long[19];
		this.BoardRecived = new byte[19];
		this.MyRank = new ushort[19];
		this.TopBoard = new LeaderBoardTopBoard();
		this.Boards = new List<BoardUnit>[19];
		for (int i = 0; i < 19; i++)
		{
			this.Boards[i] = new List<BoardUnit>();
			this.Boards[i].Clear();
		}
		this.KvKTopBoard = new KVKBoardTopBoard();
		this.KvKTopBoard.KvKAlliTopPlayerHead = 0;
		this.KvKTopBoard.KvKAlliTopPlayerName.ClearString();
		this.KvKTopBoard.KvKAlliTopPlayerValue = 0UL;
		this.KVSTopBoard = new KVSBoardTopBoard();
		this.MobiGroupBoard = new List<MobilizationGroupBroudUnit>();
		this.MobiAlliBoard = new List<MobilizationAlliBroudUnit>();
		this.MobiWorldKingBoard = new List<HistoryWorldKingDataType>();
		this.WorldLeaderBoardTopBoard = new WorldLeaderBoardTopBoard();
		this.KingofWorldBoard = new List<KingofWorldBoardUnit>();
		this.NobileBoard = new List<KingofWorldBoardUnit>();
		this.FootBallTopBoard = new FootBallTopBoard();
		this.MobilizationAlliWorldBoard = new List<MobilizationAlliWorldBroudUnit>();
		ushort mobiGroupSaveVer = 0;
		uint mobiGroupLastScore = 0u;
		if (ushort.TryParse(PlayerPrefs.GetString("AllianceMobilizationVer_" + DataManager.Instance.RoleAttr.UserId), out mobiGroupSaveVer))
		{
			this.MobiGroupSaveVer = mobiGroupSaveVer;
		}
		if (uint.TryParse(PlayerPrefs.GetString("AllianceMobilizationScore_" + DataManager.Instance.RoleAttr.UserId), out mobiGroupLastScore))
		{
			this.MobiGroupLastScore = mobiGroupLastScore;
		}
	}

	// Token: 0x060012D1 RID: 4817 RVA: 0x0020D59C File Offset: 0x0020B79C
	public bool ClearBoard(int BoardID)
	{
		for (int i = 0; i < this.Boards[BoardID].Count; i++)
		{
			StringManager.Instance.DeSpawnString(this.Boards[BoardID][i].AlliaceTag);
			StringManager.Instance.DeSpawnString(this.Boards[BoardID][i].Name);
		}
		this.Boards[BoardID].Clear();
		this.BoardUpdateTime[BoardID] = 0L;
		byte b = this.BoardRecived[BoardID];
		this.BoardRecived[BoardID] = 0;
		return b != 0;
	}

	// Token: 0x060012D2 RID: 4818 RVA: 0x0020D634 File Offset: 0x0020B834
	public void TotalClear()
	{
		this.TopBoard.SortTime = 0L;
		this.KingdomBoardNextTime = 0L;
		this.FootBallBoardTime = 0L;
		for (int i = 0; i < 19; i++)
		{
			this.ClearBoard(i);
		}
	}

	// Token: 0x060012D3 RID: 4819 RVA: 0x0020D67C File Offset: 0x0020B87C
	public void ClearMobilizationBoard(UI_LeaderBoardUpdateKind kind)
	{
		if (kind == UI_LeaderBoardUpdateKind.MobilizationGroupData)
		{
			for (int i = 0; i < this.MobiGroupBoard.Count; i++)
			{
				StringManager.Instance.DeSpawnString(this.MobiGroupBoard[i].AllianceTag);
				StringManager.Instance.DeSpawnString(this.MobiGroupBoard[i].Name);
			}
			this.MobiGroupBoard.Clear();
			this.MobiGroupBoardUpdateTime = 0L;
		}
		else if (kind == UI_LeaderBoardUpdateKind.MobilizationAlliData)
		{
			for (int j = 0; j < this.MobiAlliBoard.Count; j++)
			{
				StringManager.Instance.DeSpawnString(this.MobiAlliBoard[j].Name);
			}
			this.MobiAlliBoard.Clear();
			this.MobiAlliBoardUpdateTime = 0L;
		}
	}

	// Token: 0x060012D4 RID: 4820 RVA: 0x0020D750 File Offset: 0x0020B950
	public void ClearMobiAlliWorldBoard()
	{
		for (int i = 0; i < this.MobilizationAlliWorldBoard.Count; i++)
		{
			StringManager.Instance.DeSpawnString(this.MobilizationAlliWorldBoard[i].Name);
			StringManager.Instance.DeSpawnString(this.MobilizationAlliWorldBoard[i].AllianceTag);
		}
		this.MobilizationAlliWorldBoard.Clear();
		this.MobilizationAlliWorldBoardTime = 0L;
	}

	// Token: 0x060012D5 RID: 4821 RVA: 0x0020D7C4 File Offset: 0x0020B9C4
	public void Recv_MSG_RESP_LEADERBOARDS_CLIENT(MessagePacket MP)
	{
		this.TopBoard.SortTime = MP.ReadLong(-1);
		MP.ReadStringPlus(3, this.TopBoard.PowerTop.AlliaceTag, -1);
		MP.ReadStringPlus(13, this.TopBoard.PowerTop.Name, -1);
		this.TopBoard.PowerTop.Value = MP.ReadULong(-1);
		this.TopBoard.PowerTopHead = MP.ReadUShort(-1);
		MP.ReadStringPlus(3, this.TopBoard.KillsTop.AlliaceTag, -1);
		MP.ReadStringPlus(13, this.TopBoard.KillsTop.Name, -1);
		this.TopBoard.KillsTop.Value = MP.ReadULong(-1);
		this.TopBoard.KillTopHead = MP.ReadUShort(-1);
		MP.ReadStringPlus(3, this.TopBoard.AlliPowerTop.AlliaceTag, -1);
		MP.ReadStringPlus(20, this.TopBoard.AlliPowerTop.Name, -1);
		this.TopBoard.AlliPowerTop.Value = MP.ReadULong(-1);
		MP.ReadUInt(-1);
		this.TopBoard.PowerTopEmblem = MP.ReadUShort(-1);
		MP.ReadStringPlus(3, this.TopBoard.AlliKillsTop.AlliaceTag, -1);
		MP.ReadStringPlus(20, this.TopBoard.AlliKillsTop.Name, -1);
		this.TopBoard.AlliKillsTop.Value = MP.ReadULong(-1);
		MP.ReadUInt(-1);
		this.TopBoard.KillsTopEmblem = MP.ReadUShort(-1);
		MP.ReadStringPlus(3, this.TopBoard.ArenaTop.AlliaceTag, -1);
		MP.ReadStringPlus(13, this.TopBoard.ArenaTop.Name, -1);
		this.TopBoard.ArenaTop.Value = MP.ReadULong(-1);
		this.TopBoard.ArenaTopHead = MP.ReadUShort(-1);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 2, 0);
	}

	// Token: 0x060012D6 RID: 4822 RVA: 0x0020D9C4 File Offset: 0x0020BBC4
	public void Recv_MSG_RESP_BOARDCONTENT(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = MP.ReadByte(-1);
		ushort num = MP.ReadUShort(-1);
		long num2 = MP.ReadLong(-1);
		byte b3 = MP.ReadByte(-1);
		bool flag = false;
		if (b >= 19)
		{
			return;
		}
		if (b2 == 0)
		{
			flag = this.ClearBoard((int)b);
			this.BoardUpdateTime[(int)b] = num2;
			this.MyRank[(int)b] = num;
			if (GameConstants.IsBetween((int)b, 5, 7))
			{
				this.BoardUpdateTime[(int)b] = DataManager.Instance.ServerTime + 43200L;
			}
			if (GameConstants.IsBetween((int)b, 12, 18))
			{
				this.BoardUpdateTime[(int)b] = DataManager.Instance.ServerTime + 43200L;
			}
		}
		if (b2 > 0 && b2 != this.BoardRecived[(int)b] + 1)
		{
			return;
		}
		this.BoardRecived[(int)b] = b2;
		switch (b)
		{
		case 0:
		case 1:
		case 4:
			for (int i = 0; i < 20; i++)
			{
				BoardUnit boardUnit = new BoardUnit();
				MP.ReadStringPlus(3, boardUnit.AlliaceTag, -1);
				MP.ReadStringPlus(13, boardUnit.Name, -1);
				boardUnit.Value = MP.ReadULong(-1);
				this.Boards[(int)b].Add(boardUnit);
			}
			break;
		case 2:
		case 3:
			for (int j = 0; j < 20; j++)
			{
				BoardUnitAlliance boardUnitAlliance = new BoardUnitAlliance();
				MP.ReadStringPlus(3, boardUnitAlliance.AlliaceTag, -1);
				MP.ReadStringPlus(20, boardUnitAlliance.Name, -1);
				boardUnitAlliance.Value = MP.ReadULong(-1);
				boardUnitAlliance.AllianceID = MP.ReadUInt(-1);
				this.Boards[(int)b].Add(boardUnitAlliance);
			}
			break;
		case 5:
		case 12:
			for (int k = 0; k < 20; k++)
			{
				BoardUnitKingdom boardUnitKingdom = new BoardUnitKingdom();
				boardUnitKingdom.KingdomID = MP.ReadUShort(-1);
				MP.ReadStringPlus(3, boardUnitKingdom.AlliaceTag, -1);
				MP.ReadStringPlus(13, boardUnitKingdom.Name, -1);
				boardUnitKingdom.KingKingdomID = MP.ReadUShort(-1);
				this.Boards[(int)b].Add(boardUnitKingdom);
			}
			break;
		case 6:
		case 13:
			for (int l = 0; l < 20; l++)
			{
				BoardUnitKingdomWarAlliance boardUnitKingdomWarAlliance = new BoardUnitKingdomWarAlliance();
				boardUnitKingdomWarAlliance.KingdomID = MP.ReadUShort(-1);
				boardUnitKingdomWarAlliance.AllianceID = MP.ReadUInt(-1);
				MP.ReadStringPlus(3, boardUnitKingdomWarAlliance.AlliaceTag, -1);
				MP.ReadStringPlus(20, boardUnitKingdomWarAlliance.Name, -1);
				boardUnitKingdomWarAlliance.Value = MP.ReadULong(-1);
				this.Boards[(int)b].Add(boardUnitKingdomWarAlliance);
			}
			break;
		case 8:
		case 9:
		case 14:
		case 15:
		case 17:
			for (int m = 0; m < 20; m++)
			{
				WorldRankingBoardUnit worldRankingBoardUnit = new WorldRankingBoardUnit();
				MP.ReadStringPlus(3, worldRankingBoardUnit.AlliaceTag, -1);
				MP.ReadStringPlus(13, worldRankingBoardUnit.Name, -1);
				worldRankingBoardUnit.Value = MP.ReadULong(-1);
				worldRankingBoardUnit.KingdomID = MP.ReadUShort(-1);
				this.Boards[(int)b].Add(worldRankingBoardUnit);
			}
			break;
		case 10:
		case 11:
		case 16:
			for (int n = 0; n < 20; n++)
			{
				WorldRankingBoardUnitAlliance worldRankingBoardUnitAlliance = new WorldRankingBoardUnitAlliance();
				MP.ReadStringPlus(3, worldRankingBoardUnitAlliance.AlliaceTag, -1);
				MP.ReadStringPlus(20, worldRankingBoardUnitAlliance.Name, -1);
				worldRankingBoardUnitAlliance.Value = MP.ReadULong(-1);
				worldRankingBoardUnitAlliance.AllianceID = MP.ReadUInt(-1);
				worldRankingBoardUnitAlliance.KingdomID = MP.ReadUShort(-1);
				this.Boards[(int)b].Add(worldRankingBoardUnitAlliance);
			}
			break;
		}
		if (flag)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8457u), 255, true);
		}
		if (b2 == 0)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 4, (int)b);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_KingdomVSLBoard, 4, (int)b);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_KVKLBoard, 4, (int)b);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBallBoard, 4, (int)b);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBallKVKBoard, 4, (int)b);
		}
		else
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 3, (int)b);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_KingdomVSLBoard, 3, (int)b);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_KVKLBoard, 3, (int)b);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBallBoard, 3, (int)b);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBallKVKBoard, 3, (int)b);
		}
	}

	// Token: 0x060012D7 RID: 4823 RVA: 0x0020DE64 File Offset: 0x0020C064
	public void Recv_MSG_RESP_ARENA_BOARDDATA(MessagePacket MP)
	{
		ArenaManager.Instance.m_ArenaTargetHint.AllianceTagTag = MP.ReadString(3, -1);
		ArenaManager.Instance.m_ArenaTargetHint.Name = MP.ReadString(13, -1);
		ArenaManager.Instance.m_ArenaTargetHint.Place = (uint)((byte)MP.ReadULong(-1));
		ArenaManager.Instance.m_ArenaTargetHint.HeroData = new ArenaTargetHeroDataType[5];
		ArenaManager instance = ArenaManager.Instance;
		instance.m_ArenaTargetHint.Place = instance.m_ArenaTargetHint.Place + 1u;
		for (int i = 0; i < 5; i++)
		{
			ArenaManager.Instance.m_ArenaTargetHint.HeroData[i].ID = MP.ReadUShort(-1);
			ArenaManager.Instance.m_ArenaTargetHint.HeroData[i].Level = MP.ReadByte(-1);
			ArenaManager.Instance.m_ArenaTargetHint.HeroData[i].Rank = MP.ReadByte(-1);
			ArenaManager.Instance.m_ArenaTargetHint.HeroData[i].Star = MP.ReadByte(-1);
			ArenaManager.Instance.m_ArenaTargetHint.HeroData[i].Equip = MP.ReadByte(-1);
			MP.ReadInt(-1);
		}
		ArenaManager.Instance.m_ArenaTargetHint.Head = ArenaManager.Instance.m_ArenaTargetHint.HeroData[0].ID;
		Transform parent = this.hintTarget.transform.parent;
		this.hintTarget.transform.SetParent(this.hintCenter);
		Vector2 anchoredPosition = this.hintTarget.GetComponent<RectTransform>().anchoredPosition;
		this.hintTarget.transform.SetParent(parent);
		this.hintTarget.transform.SetSiblingIndex(11);
		float num = anchoredPosition.y + 410f;
		num = Mathf.Clamp(num, -190f, 150f);
		GUIManager.Instance.m_Arena_Hint.Show(this.hintTarget, -40f, num, 0);
	}

	// Token: 0x060012D8 RID: 4824 RVA: 0x0020E064 File Offset: 0x0020C264
	public void Recv_MSG_RESP_ACTIVITY_AEVENT_PERSONAL_RANK(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			byte b = MP.ReadByte(-1);
			byte b2 = MP.ReadByte(-1);
			if ((b & 1) > 0)
			{
				this.ClearBoard(7);
				this.MyRank[7] = 0;
			}
			for (int i = 0; i < (int)b2; i++)
			{
				BoardUnit boardUnit = new BoardUnit();
				MP.ReadStringPlus(13, boardUnit.Name, -1);
				boardUnit.Value = MP.ReadULong(-1);
				boardUnit.AlliaceTag.Append(DataManager.Instance.RoleAlliance.Tag);
				this.Boards[7].Add(boardUnit);
			}
			if (b >= 2)
			{
				LeaderBoardManager.Instance.BoardUpdateTime[7] = DataManager.Instance.ServerTime + 43200L;
				this.Boards[7].Sort(new Comparison<BoardUnit>(LeaderBoardManager.BoardUnitSortByValue));
				for (int j = 0; j < this.Boards[7].Count; j++)
				{
					if (DataManager.CompareStr(this.Boards[7][j].Name, DataManager.Instance.RoleAttr.Name) == 0)
					{
						this.MyRank[7] = (ushort)(j + 1);
					}
				}
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 3, 7);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_KingdomVSLBoard, 3, 7);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_KVKLBoard, 3, 7);
			}
		}
	}

	// Token: 0x060012D9 RID: 4825 RVA: 0x0020E1D4 File Offset: 0x0020C3D4
	public void Recv_MSG_RESP_KVK_TOPBORAD(MessagePacket MP)
	{
		LeaderBoardManager.Instance.KingdomBoardNextTime = DataManager.Instance.ServerTime + 43200L;
		if (this.KvKTopBoard == null)
		{
			this.KvKTopBoard = new KVKBoardTopBoard();
		}
		this.KvKTopBoard.SortTime = MP.ReadLong(-1);
		this.KvKTopBoard.TopKingdom = MP.ReadUShort(-1);
		this.KvKTopBoard.KvKTopAlliKingdomID = MP.ReadUShort(-1);
		this.KvKTopBoard.KvKTopAlliAllianceID = MP.ReadUInt(-1);
		MP.ReadStringPlus(3, this.KvKTopBoard.KvKTopAlliTag, -1);
		MP.ReadStringPlus(20, this.KvKTopBoard.KvKTopAlliName, -1);
		this.KvKTopBoard.KvKTopAlliScore = MP.ReadULong(-1);
		this.KvKTopBoard.KvKTopAlliEmblem = MP.ReadUShort(-1);
		MP.ReadStringPlus(13, this.KvKTopBoard.KvKAlliTopPlayerName, -1);
		this.KvKTopBoard.KvKAlliTopPlayerValue = MP.ReadULong(-1);
		this.KvKTopBoard.KvKAlliTopPlayerHead = MP.ReadUShort(-1);
		this.KvKTopBoard.KingdomEventRequireTime = MP.ReadUInt(-1);
		MP.ReadStringPlus(3, this.KvKTopBoard.KvKTopPlayerTag, -1);
		MP.ReadStringPlus(13, this.KvKTopBoard.KvKTopPlayerName, -1);
		this.KvKTopBoard.KvKPlayerValue = MP.ReadULong(-1);
		this.KvKTopBoard.KvKTopPlayerKingdomID = MP.ReadUShort(-1);
		this.KvKTopBoard.KvKPlayerHead = MP.ReadUShort(-1);
		this.KvKTopBoard.AllianceID = (ulong)DataManager.Instance.RoleAlliance.Id;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_KVKLBoard, 2, 0);
	}

	// Token: 0x060012DA RID: 4826 RVA: 0x0020E378 File Offset: 0x0020C578
	public void Recv_MSG_RESP_KINGDOM_VS_TOPBOARD(MessagePacket MP)
	{
		LeaderBoardManager.Instance.KingdomBoardNextTime = DataManager.Instance.ServerTime + 43200L;
		if (this.KVSTopBoard == null)
		{
			this.KVSTopBoard = new KVSBoardTopBoard();
		}
		this.KVSTopBoard.SortTime = MP.ReadLong(-1);
		if (this.KVSTopBoard.SortTime == 0L)
		{
			LeaderBoardManager.Instance.KingdomBoardNextTime = 0L;
		}
		this.KVSTopBoard.KVSTopKingdom = MP.ReadUShort(-1);
		this.KVSTopBoard.KVSTopAlliKingdomID = MP.ReadUShort(-1);
		this.KVSTopBoard.KVSTopAlliAllianceID = MP.ReadUInt(-1);
		MP.ReadStringPlus(3, this.KVSTopBoard.KVSTopAlliTag, -1);
		MP.ReadStringPlus(20, this.KVSTopBoard.KVSTopAlliName, -1);
		this.KVSTopBoard.KVSTopAlliScore = MP.ReadULong(-1);
		this.KVSTopBoard.KVSTopAlliEmblem = MP.ReadUShort(-1);
		MP.ReadStringPlus(3, this.KVSTopBoard.KVSTopPlayerTag, -1);
		MP.ReadStringPlus(13, this.KVSTopBoard.KVSTopPlayerName, -1);
		this.KVSTopBoard.KVSPlayerValue = MP.ReadULong(-1);
		this.KVSTopBoard.KVSTopPlayerKingdomID = MP.ReadUShort(-1);
		this.KVSTopBoard.KVSPlayerHead = MP.ReadUShort(-1);
		MP.ReadStringPlus(13, this.KVSTopBoard.KvKAlliTopPlayerName, -1);
		this.KVSTopBoard.KvKAlliTopPlayerValue = MP.ReadULong(-1);
		this.KVSTopBoard.KvKAlliTopPlayerHead = MP.ReadUShort(-1);
		this.KVSTopBoard.KVKTopKingdom = MP.ReadUShort(-1);
		this.KVSTopBoard.KvKTopAlliKingdomID = MP.ReadUShort(-1);
		this.KVSTopBoard.KvKTopAlliAllianceID = MP.ReadUInt(-1);
		MP.ReadStringPlus(3, this.KVSTopBoard.KvKTopAlliTag, -1);
		MP.ReadStringPlus(20, this.KVSTopBoard.KvKTopAlliName, -1);
		this.KVSTopBoard.KvKTopAlliScore = MP.ReadULong(-1);
		this.KVSTopBoard.KvKTopAlliEmblem = MP.ReadUShort(-1);
		MP.ReadStringPlus(3, this.KVSTopBoard.KvKTopPlayerTag, -1);
		MP.ReadStringPlus(13, this.KVSTopBoard.KvKTopPlayerName, -1);
		this.KVSTopBoard.KvKPlayerValue = MP.ReadULong(-1);
		this.KVSTopBoard.KvKTopPlayerKingdomID = MP.ReadUShort(-1);
		this.KVSTopBoard.KvKPlayerHead = MP.ReadUShort(-1);
		this.KVSTopBoard.KingdomEventRequireTime = MP.ReadUInt(-1);
		this.KVSTopBoard.AllianceID = (ulong)DataManager.Instance.RoleAlliance.Id;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_KingdomVSLBoard, 2, 0);
	}

	// Token: 0x060012DB RID: 4827 RVA: 0x0020E618 File Offset: 0x0020C818
	public void Recv_MSG_RESP_ACTIVITY_AM_MEMBER_RANK(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b != 0)
		{
			return;
		}
		byte b2 = MP.ReadByte(-1);
		this.ClearMobilizationBoard(UI_LeaderBoardUpdateKind.MobilizationAlliData);
		this.MobiAlliBoardUpdateTime = DataManager.Instance.ServerTime + 180L;
		this.MobiGroupAllianceID = DataManager.Instance.RoleAlliance.Id;
		for (int i = 0; i < (int)b2; i++)
		{
			MobilizationAlliBroudUnit mobilizationAlliBroudUnit = new MobilizationAlliBroudUnit();
			MP.ReadStringPlus(13, mobilizationAlliBroudUnit.Name, -1);
			mobilizationAlliBroudUnit.Score = MP.ReadUShort(-1);
			mobilizationAlliBroudUnit.AquiredMission = MP.ReadByte(-1);
			mobilizationAlliBroudUnit.FinishedMission = MP.ReadByte(-1);
			mobilizationAlliBroudUnit.index = (byte)(i + 1);
			this.MobiAlliBoard.Add(mobilizationAlliBroudUnit);
		}
		this.MobiAlliBoard.Sort(new Comparison<MobilizationAlliBroudUnit>(LeaderBoardManager.MobiGroupUnitSortByValue));
		for (int j = 0; j < this.MobiAlliBoard.Count; j++)
		{
			if (DataManager.CompareStr(this.MobiAlliBoard[j].Name, DataManager.Instance.RoleAttr.Name) == 0)
			{
				this.MobiAlliRank = (int)((ushort)(j + 1));
			}
		}
		if (DataManager.Instance.RoleAlliance.AMRank < 4)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 7, 0);
		}
	}

	// Token: 0x060012DC RID: 4828 RVA: 0x0020E764 File Offset: 0x0020C964
	public void Recv_MSG_RESP_ACTIVITY_AM_MEMBER_RANKEX(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		for (int i = 0; i < (int)b; i++)
		{
			bool flag = MP.ReadByte(-1) > 0;
			if (flag)
			{
				for (int j = 0; j < this.MobiAlliBoard.Count; j++)
				{
					if ((int)this.MobiAlliBoard[j].index == i + 1)
					{
						this.MobiAlliBoard[j].finishBonus = true;
						break;
					}
				}
			}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 7, 0);
	}

	// Token: 0x060012DD RID: 4829 RVA: 0x0020E7F8 File Offset: 0x0020C9F8
	public void Recv_MSG_RESP_ACTIVITY_AM_ALLIANCE_RANK(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b != 0)
		{
			return;
		}
		byte b2 = MP.ReadByte(-1);
		ushort num = MP.ReadUShort(-1);
		byte b3 = MP.ReadByte(-1);
		if ((b2 & 1) > 0)
		{
			if (this.MobiGroupAllianceID != DataManager.Instance.RoleAlliance.Id)
			{
				this.ClearMobilizationBoard(UI_LeaderBoardUpdateKind.MobilizationGroupData);
			}
			else if (ActivityManager.Instance.AllyMobilizationData.EventBeginTime != this.AlliMobiEventTime)
			{
				this.ClearMobilizationBoard(UI_LeaderBoardUpdateKind.MobilizationGroupData);
			}
			this.AlliMobiEventTime = ActivityManager.Instance.AllyMobilizationData.EventBeginTime;
			this.MobiGroupBoardUpdateTime = DataManager.Instance.ServerTime + 180L;
			this.MobiGroupAllianceID = DataManager.Instance.RoleAlliance.Id;
		}
		for (int i = 0; i < (int)b3; i++)
		{
			uint num2 = MP.ReadUInt(-1);
			bool flag = false;
			for (int j = 0; j < this.MobiGroupBoard.Count; j++)
			{
				if (this.MobiGroupBoard[j].AlliacneID == num2)
				{
					this.MobiGroupBoard[j].AllianceTag.ClearString();
					this.MobiGroupBoard[j].Name.ClearString();
					MP.ReadStringPlus(3, this.MobiGroupBoard[j].AllianceTag, -1);
					MP.ReadStringPlus(20, this.MobiGroupBoard[j].Name, -1);
					this.MobiGroupBoard[j].Score = MP.ReadUInt(-1);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				MobilizationGroupBroudUnit mobilizationGroupBroudUnit = new MobilizationGroupBroudUnit();
				mobilizationGroupBroudUnit.AlliacneID = num2;
				MP.ReadStringPlus(3, mobilizationGroupBroudUnit.AllianceTag, -1);
				MP.ReadStringPlus(20, mobilizationGroupBroudUnit.Name, -1);
				mobilizationGroupBroudUnit.Score = MP.ReadUInt(-1);
				this.MobiGroupBoard.Add(mobilizationGroupBroudUnit);
			}
		}
		if (b2 >= 2)
		{
			this.MobiGroupBoard.Sort(new Comparison<MobilizationGroupBroudUnit>(LeaderBoardManager.MobiGroupUnitSortByValue));
			for (int k = 0; k < this.MobiGroupBoard.Count; k++)
			{
				if (this.MobiGroupBoard[k].Rank > 0)
				{
					this.MobiGroupBoard[k].ChangeRank = this.MobiGroupBoard[k].Rank - k - 1;
				}
				this.MobiGroupBoard[k].Rank = k + 1;
				if (DataManager.CompareStr(this.MobiGroupBoard[k].AllianceTag, DataManager.Instance.RoleAlliance.Tag) == 0)
				{
					this.MobiGroupRank = (int)((ushort)(k + 1));
					if (this.MobiGroupSaveVer != num)
					{
						this.MobiGroupLastScore = 0u;
					}
					if (this.MobiGroupLastScore != this.MobiGroupBoard[k].Score)
					{
						UILeaderBoard.ShowSP = true;
						UILeaderBoard.SPScoreValue = (int)this.MobiGroupLastScore;
						UILeaderBoard.SPScoreFlyValue = (int)(this.MobiGroupBoard[k].Score - this.MobiGroupLastScore);
						UILeaderBoard.SPRankChange = this.MobiGroupBoard[this.MobiGroupRank - 1].ChangeRank;
						this.MobiGroupLastScore = this.MobiGroupBoard[k].Score;
						this.MobiGroupSaveVer = num;
						PlayerPrefs.SetString("AllianceMobilizationVer_" + DataManager.Instance.RoleAttr.UserId, this.MobiGroupSaveVer.ToString());
						PlayerPrefs.SetString("AllianceMobilizationScore_" + DataManager.Instance.RoleAttr.UserId, this.MobiGroupLastScore.ToString());
					}
				}
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 6, 0);
		}
	}

	// Token: 0x060012DE RID: 4830 RVA: 0x0020EBC0 File Offset: 0x0020CDC0
	public void Recv_MSG_RESP_KINGOFTHEWORLD_HISTORYKINGDATA(MessagePacket MP)
	{
		this.MobiWorldKingBoard.Clear();
		this.KingHead = MP.ReadUShort(-1);
		this.HistoryKingDataNum = MP.ReadByte(-1);
		for (int i = 0; i < (int)this.HistoryKingDataNum; i++)
		{
			HistoryWorldKingDataType historyWorldKingDataType = new HistoryWorldKingDataType();
			historyWorldKingDataType.HomeKingdomID = MP.ReadUShort(-1);
			MP.ReadStringPlus(3, historyWorldKingDataType.AllianceTag, -1);
			MP.ReadStringPlus(13, historyWorldKingDataType.Name, -1);
			historyWorldKingDataType.OccupyTime = MP.ReadUInt(-1);
			historyWorldKingDataType.TakeOfficeTime = MP.ReadLong(-1);
			this.MobiWorldKingBoard.Add(historyWorldKingDataType);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 9, 0);
	}

	// Token: 0x060012DF RID: 4831 RVA: 0x0020EC70 File Offset: 0x0020CE70
	public void Send_MSG_REQUEST_KINGOFTHEWORLD_HISTORYKINGDATA()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_KINGOFTHEWORLD_HISTORYKINGDATA;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x060012E0 RID: 4832 RVA: 0x0020ECA4 File Offset: 0x0020CEA4
	public void Recv_MSG_RESP_WORLDRANKING_LEADERBOARDS_CLIENT(MessagePacket MP)
	{
		this.WorldLeaderBoardTopBoard.SortTime = MP.ReadLong(-1);
		MP.ReadStringPlus(3, this.WorldLeaderBoardTopBoard.PowerTop.AlliaceTag, -1);
		MP.ReadStringPlus(13, this.WorldLeaderBoardTopBoard.PowerTop.Name, -1);
		this.WorldLeaderBoardTopBoard.PowerTop.Value = MP.ReadULong(-1);
		this.WorldLeaderBoardTopBoard.PowerTop.KingdomID = MP.ReadUShort(-1);
		this.WorldLeaderBoardTopBoard.PowerTopHead = MP.ReadUShort(-1);
		MP.ReadStringPlus(3, this.WorldLeaderBoardTopBoard.KillsTop.AlliaceTag, -1);
		MP.ReadStringPlus(13, this.WorldLeaderBoardTopBoard.KillsTop.Name, -1);
		this.WorldLeaderBoardTopBoard.KillsTop.Value = MP.ReadULong(-1);
		this.WorldLeaderBoardTopBoard.KillsTop.KingdomID = MP.ReadUShort(-1);
		this.WorldLeaderBoardTopBoard.KillsTopHead = MP.ReadUShort(-1);
		MP.ReadStringPlus(3, this.WorldLeaderBoardTopBoard.AlliPowerTop.AlliaceTag, -1);
		MP.ReadStringPlus(20, this.WorldLeaderBoardTopBoard.AlliPowerTop.Name, -1);
		this.WorldLeaderBoardTopBoard.AlliPowerTop.Value = MP.ReadULong(-1);
		MP.ReadUInt(-1);
		this.WorldLeaderBoardTopBoard.AlliPowerTop.KingdomID = MP.ReadUShort(-1);
		this.WorldLeaderBoardTopBoard.PowerTopEmblem = MP.ReadUShort(-1);
		MP.ReadStringPlus(3, this.WorldLeaderBoardTopBoard.AlliKillsTop.AlliaceTag, -1);
		MP.ReadStringPlus(20, this.WorldLeaderBoardTopBoard.AlliKillsTop.Name, -1);
		this.WorldLeaderBoardTopBoard.AlliKillsTop.Value = MP.ReadULong(-1);
		MP.ReadUInt(-1);
		this.WorldLeaderBoardTopBoard.AlliKillsTop.KingdomID = MP.ReadUShort(-1);
		this.WorldLeaderBoardTopBoard.KillsTopEmblem = MP.ReadUShort(-1);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 2, 0);
	}

	// Token: 0x060012E1 RID: 4833 RVA: 0x0020EEA8 File Offset: 0x0020D0A8
	public void Send_MSG_REQUEST_FEDERAL_HISTORYKINGDATA(byte WonderID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_FEDERAL_HISTORYKINGDATA;
		messagePacket.AddSeqId();
		messagePacket.Add(WonderID);
		messagePacket.Send(false);
	}

	// Token: 0x060012E2 RID: 4834 RVA: 0x0020EEE0 File Offset: 0x0020D0E0
	public void Recv_MSG_RESP_FEDERAL_HISTORYKINGDATA(MessagePacket MP)
	{
		this.MobiWorldKingBoard.Clear();
		if (MP.ReadByte(-1) == 0)
		{
			byte b = MP.ReadByte(-1);
			this.KingHead = MP.ReadUShort(-1);
			this.HistoryKingDataNum = MP.ReadByte(-1);
			for (int i = 0; i < (int)this.HistoryKingDataNum; i++)
			{
				HistoryWorldKingDataType historyWorldKingDataType = new HistoryWorldKingDataType();
				historyWorldKingDataType.HomeKingdomID = MP.ReadUShort(-1);
				MP.ReadStringPlus(3, historyWorldKingDataType.AllianceTag, -1);
				MP.ReadStringPlus(13, historyWorldKingDataType.Name, -1);
				historyWorldKingDataType.OccupyTime = MP.ReadUInt(-1);
				historyWorldKingDataType.TakeOfficeTime = MP.ReadLong(-1);
				this.MobiWorldKingBoard.Add(historyWorldKingDataType);
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_NobilityBoard, 0, 0);
		}
		else
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_NobilityBoard, 0, 2);
		}
	}

	// Token: 0x060012E3 RID: 4835 RVA: 0x0020EFC0 File Offset: 0x0020D1C0
	public void Recv_MSG_RESP_KINGOFTHEWORLD_RANKDATA(MessagePacket MP)
	{
		this.KingofWorldTime = DataManager.Instance.ServerTime + 21600L;
		this.KingofWorldHead = MP.ReadUShort(-1);
		this.KingofWorldBoard.Clear();
		for (int i = 0; i < 10; i++)
		{
			KingofWorldBoardUnit kingofWorldBoardUnit = new KingofWorldBoardUnit();
			kingofWorldBoardUnit.HomeKingdomID = MP.ReadUShort(-1);
			MP.ReadStringPlus(3, kingofWorldBoardUnit.AllianceTag, -1);
			MP.ReadStringPlus(13, kingofWorldBoardUnit.Name, -1);
			kingofWorldBoardUnit.OccupyTime = MP.ReadUInt(-1);
			this.KingofWorldBoard.Add(kingofWorldBoardUnit);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 10, 0);
	}

	// Token: 0x060012E4 RID: 4836 RVA: 0x0020F068 File Offset: 0x0020D268
	public void Recv_MSG_RESP_Nobile_RANKDATA(MessagePacket MP)
	{
		this.NobileWonderId = (ushort)MP.ReadByte(-1);
		this.NobileTime = DataManager.Instance.ServerTime + 21600L;
		this.NobileHead = MP.ReadUShort(-1);
		this.NobileBoard.Clear();
		for (int i = 0; i < 10; i++)
		{
			KingofWorldBoardUnit kingofWorldBoardUnit = new KingofWorldBoardUnit();
			kingofWorldBoardUnit.HomeKingdomID = MP.ReadUShort(-1);
			MP.ReadStringPlus(3, kingofWorldBoardUnit.AllianceTag, -1);
			MP.ReadStringPlus(13, kingofWorldBoardUnit.Name, -1);
			kingofWorldBoardUnit.OccupyTime = MP.ReadUInt(-1);
			this.NobileBoard.Add(kingofWorldBoardUnit);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_NobilityOccupyBoard, (int)this.NobileWonderId, 0);
	}

	// Token: 0x060012E5 RID: 4837 RVA: 0x0020F124 File Offset: 0x0020D324
	public void Recv_MSG_RESP_AlliHunt_RANKDATA(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b != 0)
		{
			return;
		}
		byte b2 = MP.ReadByte(-1);
		byte b3 = MP.ReadByte(-1);
		if (this.AlliHuntBoard == null)
		{
			this.AlliHuntBoard = new List<BoardUnit>();
		}
		if ((b2 & 1) > 0)
		{
			this.AlliHuntBoard.Clear();
			this.AlliHuntBoardUpdateTime = DataManager.Instance.ServerTime + 180L;
			this.MobiGroupAllianceID = DataManager.Instance.RoleAlliance.Id;
		}
		for (int i = 0; i < (int)b3; i++)
		{
			BoardUnit boardUnit = new BoardUnit();
			MP.ReadStringPlus(13, boardUnit.Name, -1);
			boardUnit.Value = MP.ReadULong(-1);
			this.AlliHuntBoard.Add(boardUnit);
		}
		if (b2 >= 2)
		{
			this.AlliHuntBoard.Sort(new Comparison<BoardUnit>(LeaderBoardManager.BoardUnitSortByValue));
			for (int j = 0; j < this.AlliHuntBoard.Count; j++)
			{
				if (DataManager.CompareStr(this.AlliHuntBoard[j].Name, DataManager.Instance.RoleAttr.Name) == 0)
				{
					this.AlliHuntRank = j + 1;
				}
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_AlliHuntBoard, 11, 0);
		}
	}

	// Token: 0x060012E6 RID: 4838 RVA: 0x0020F270 File Offset: 0x0020D470
	public void Recv_MSG_RESP_ALLIANCEWAR_RANK(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b != 0)
		{
			return;
		}
		if (this.AllianceWarGroupBoard == null)
		{
			this.AllianceWarGroupBoard = new List<AllianceWarBroudUnit>();
		}
		this.AllianceWarGroupBoard.Clear();
		this.AllianceWarGroupRank = 0;
		this.AllianceWarGroupBoardUpdateTime = DataManager.Instance.ServerTime + 180L;
		this.MobiGroupAllianceID = DataManager.Instance.RoleAlliance.Id;
		this.AllianceWarGroupRankUpNum = MP.ReadByte(-1);
		this.AllianceWarGroupRankDownNum = MP.ReadByte(-1);
		this.AllianceWarGroupRankDownNum = 16 - this.AllianceWarGroupRankDownNum + 1;
		for (int i = 0; i < 16; i++)
		{
			uint num = MP.ReadUInt(-1);
			AllianceWarBroudUnit allianceWarBroudUnit = new AllianceWarBroudUnit();
			allianceWarBroudUnit.AlliacneID = num;
			MP.ReadStringPlus(3, allianceWarBroudUnit.AllianceTag, -1);
			MP.ReadStringPlus(20, allianceWarBroudUnit.Name, -1);
			allianceWarBroudUnit.Score = (int)MP.ReadUShort(-1);
			allianceWarBroudUnit.Power = MP.ReadULong(-1);
			if (num != 0u)
			{
				this.AllianceWarGroupBoard.Add(allianceWarBroudUnit);
				if (allianceWarBroudUnit.AlliacneID == DataManager.Instance.RoleAlliance.Id)
				{
					this.AllianceWarGroupRank = this.AllianceWarGroupBoard.Count;
				}
			}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_AlliVSGroupBoard, 0, 0);
	}

	// Token: 0x060012E7 RID: 4839 RVA: 0x0020F3C0 File Offset: 0x0020D5C0
	public void Recv_MSG_RESP_FOOTBALL_TOPBOARD(MessagePacket MP)
	{
		this.FootBallBoardTime = ActivityManager.Instance.ServerEventTime + 43200L;
		if (this.FootBallTopBoard == null)
		{
			this.FootBallTopBoard = new FootBallTopBoard();
		}
		this.FootBallTopBoard.SortTime = MP.ReadLong(-1);
		if (this.FootBallTopBoard.SortTime == 0L)
		{
			this.FootBallBoardTime = 0L;
		}
		this.FootBallBoardType = MP.ReadByte(-1);
		this.FootBallTopBoard.EventRequireTime = MP.ReadUInt(-1);
		this.FootBallTopBoard.KingdomAlliance.KingdomID = MP.ReadUShort(-1);
		this.FootBallTopBoard.KingdomAlliance.AllianceID = MP.ReadUInt(-1);
		MP.ReadStringPlus(3, this.FootBallTopBoard.KingdomAlliance.AlliaceTag, -1);
		MP.ReadStringPlus(20, this.FootBallTopBoard.KingdomAlliance.Name, -1);
		this.FootBallTopBoard.KingdomAlliance.Value = MP.ReadULong(-1);
		this.FootBallTopBoard.KingdomAllianceTopEmblem = MP.ReadUShort(-1);
		MP.ReadStringPlus(3, this.FootBallTopBoard.KingdomPlayer.AlliaceTag, -1);
		MP.ReadStringPlus(13, this.FootBallTopBoard.KingdomPlayer.Name, -1);
		this.FootBallTopBoard.KingdomPlayer.Value = MP.ReadULong(-1);
		this.FootBallTopBoard.KingdomPlayer.KingdomID = MP.ReadUShort(-1);
		this.FootBallTopBoard.KingdomPlayerTopHead = MP.ReadUShort(-1);
		MP.ReadStringPlus(13, this.FootBallTopBoard.AlliancePlayer.Name, -1);
		this.FootBallTopBoard.AlliancePlayer.Value = MP.ReadULong(-1);
		this.FootBallTopBoard.AlliancePlayerTopHead = MP.ReadUShort(-1);
		if (this.FootBallBoardType == 2)
		{
			this.FootBallTopBoard.TopKingdom = MP.ReadUShort(-1);
			MP.ReadUShort(-1);
			this.FootBallTopBoard.TopWorldKingdom = MP.ReadUShort(-1);
			MP.ReadUShort(-1);
			this.FootBallTopBoard.WorldKingdomAlliance.KingdomID = MP.ReadUShort(-1);
			this.FootBallTopBoard.WorldKingdomAlliance.AllianceID = MP.ReadUInt(-1);
			MP.ReadStringPlus(3, this.FootBallTopBoard.WorldKingdomAlliance.AlliaceTag, -1);
			MP.ReadStringPlus(20, this.FootBallTopBoard.WorldKingdomAlliance.Name, -1);
			this.FootBallTopBoard.WorldKingdomAlliance.Value = MP.ReadULong(-1);
			this.FootBallTopBoard.WorldKingdomAllianceEmblem = MP.ReadUShort(-1);
			MP.ReadStringPlus(3, this.FootBallTopBoard.WorldKingdomPlayer.AlliaceTag, -1);
			MP.ReadStringPlus(13, this.FootBallTopBoard.WorldKingdomPlayer.Name, -1);
			this.FootBallTopBoard.WorldKingdomPlayer.Value = MP.ReadULong(-1);
			this.FootBallTopBoard.WorldKingdomPlayer.KingdomID = MP.ReadUShort(-1);
			this.FootBallTopBoard.WorldKingdomPlayerHead = MP.ReadUShort(-1);
		}
		this.FootBallTopBoard.AllianceID = (ulong)DataManager.Instance.RoleAlliance.Id;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBallBoard, 2, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBallKVKBoard, 2, 0);
	}

	// Token: 0x060012E8 RID: 4840 RVA: 0x0020F6F4 File Offset: 0x0020D8F4
	public void Recv_MSG_RESP_FOOTBALL_ASOLO_RANK(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			byte b = MP.ReadByte(-1);
			byte b2 = MP.ReadByte(-1);
			if ((b & 1) > 0)
			{
				this.ClearBoard(18);
				this.MyRank[18] = 0;
			}
			for (int i = 0; i < (int)b2; i++)
			{
				BoardUnit boardUnit = new BoardUnit();
				MP.ReadStringPlus(13, boardUnit.Name, -1);
				boardUnit.Value = MP.ReadULong(-1);
				boardUnit.AlliaceTag.Append(DataManager.Instance.RoleAlliance.Tag);
				this.Boards[18].Add(boardUnit);
			}
			if (b >= 2)
			{
				LeaderBoardManager.Instance.BoardUpdateTime[18] = ActivityManager.Instance.ServerEventTime + 43200L;
				this.Boards[18].Sort(new Comparison<BoardUnit>(LeaderBoardManager.BoardUnitSortByValue));
				for (int j = 0; j < this.Boards[18].Count; j++)
				{
					if (DataManager.CompareStr(this.Boards[18][j].Name, DataManager.Instance.RoleAttr.Name) == 0)
					{
						this.MyRank[18] = (ushort)(j + 1);
					}
				}
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBallBoard, 3, 18);
			}
		}
	}

	// Token: 0x060012E9 RID: 4841 RVA: 0x0020F850 File Offset: 0x0020DA50
	public void Recv_MSG_RESP_ALLIANCEMOBILIZATION_LEGENDRANK(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			ushort mobilizationAlliWorldRank = MP.ReadUShort(-1);
			ushort mobilizationAlliWorldLastRank = MP.ReadUShort(-1);
			byte b2 = MP.ReadByte(-1);
			ushort num = MP.ReadUShort(-1);
			if ((b2 & 1) > 0)
			{
				this.ClearMobiAlliWorldBoard();
				this.MobilizationAlliWorldRank = 0;
				this.MobilizationAlliWorldLastRank = 0;
				this.MobiAlliWorldAllianceID = DataManager.Instance.RoleAlliance.Id;
			}
			this.MobilizationAlliWorldRank = (int)mobilizationAlliWorldRank;
			this.MobilizationAlliWorldLastRank = (int)mobilizationAlliWorldLastRank;
			for (int i = 0; i < (int)num; i++)
			{
				MobilizationAlliWorldBroudUnit mobilizationAlliWorldBroudUnit = new MobilizationAlliWorldBroudUnit();
				mobilizationAlliWorldBroudUnit.AlliacneID = MP.ReadUInt(-1);
				mobilizationAlliWorldBroudUnit.State = MP.ReadByte(-1);
				mobilizationAlliWorldBroudUnit.ChangeRank = MP.ReadByte(-1);
				mobilizationAlliWorldBroudUnit.KingdomID = MP.ReadUShort(-1);
				MP.ReadStringPlus(3, mobilizationAlliWorldBroudUnit.AllianceTag, -1);
				MP.ReadStringPlus(20, mobilizationAlliWorldBroudUnit.Name, -1);
				mobilizationAlliWorldBroudUnit.Score = MP.ReadUInt(-1);
				this.MobilizationAlliWorldBoard.Add(mobilizationAlliWorldBroudUnit);
			}
			if (b2 >= 2)
			{
				this.MobilizationAlliWorldBoardTime = ActivityManager.Instance.ServerEventTime + 43200L;
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_AlliMobi_WorldBoard, 0, 0);
			}
		}
		else if (b == 2)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_AlliMobi_WorldBoard, 2, 0);
		}
		else
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_AlliMobi_WorldBoard, 5, 0);
		}
	}

	// Token: 0x17000090 RID: 144
	// (get) Token: 0x060012EA RID: 4842 RVA: 0x0020F9C0 File Offset: 0x0020DBC0
	public static LeaderBoardManager Instance
	{
		get
		{
			if (LeaderBoardManager._instance == null)
			{
				LeaderBoardManager._instance = new LeaderBoardManager();
			}
			return LeaderBoardManager._instance;
		}
	}

	// Token: 0x060012EB RID: 4843 RVA: 0x0020F9DC File Offset: 0x0020DBDC
	public void CheckNextPart(byte BoardID, byte Index)
	{
		if (BoardID == 7)
		{
			return;
		}
		byte b = Index / 20;
		if (b < 5 && b > this.BoardRecived[(int)BoardID])
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_LEADERBOARD_CONTENT;
			messagePacket.AddSeqId();
			ushort data;
			byte data2;
			GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out data, out data2);
			messagePacket.Add(data);
			messagePacket.Add(data2);
			messagePacket.Add(BoardID);
			messagePacket.Add(b);
			if (GameConstants.IsBetween((int)BoardID, 5, 7))
			{
				messagePacket.Add(LeaderBoardManager.Instance.KvKTopBoard.SortTime);
			}
			else
			{
				messagePacket.Add(LeaderBoardManager.Instance.BoardUpdateTime[(int)BoardID]);
			}
			messagePacket.Send(false);
		}
	}

	// Token: 0x060012EC RID: 4844 RVA: 0x0020FAA0 File Offset: 0x0020DCA0
	public static int isOpenArena()
	{
		EActivityState eventState = ActivityManager.Instance.KvKActivityData[4].EventState;
		if (eventState == EActivityState.EAS_Run || eventState == EActivityState.EAS_HomeStart || eventState == EActivityState.EAS_HomeEnd || eventState == EActivityState.EAS_StartRanking)
		{
			return 1;
		}
		if (ArenaManager.Instance.m_ArenaClose_ActivityType == EActivityType.EAT_KingOfTheWorld && ArenaManager.Instance.m_ArenaClose_CDTime > ActivityManager.Instance.ServerEventTime)
		{
			return 2;
		}
		if (ArenaManager.Instance.m_ArenaClose_ActivityType == EActivityType.EAT_FederalEvent && ArenaManager.Instance.m_ArenaClose_CDTime > ActivityManager.Instance.ServerEventTime)
		{
			return 3;
		}
		return 0;
	}

	// Token: 0x060012ED RID: 4845 RVA: 0x0020FB38 File Offset: 0x0020DD38
	private static int BoardUnitSortByValue(BoardUnit x, BoardUnit y)
	{
		if (x.Value > y.Value)
		{
			return -1;
		}
		if (x.Value < y.Value)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x060012EE RID: 4846 RVA: 0x0020FB64 File Offset: 0x0020DD64
	private static int MobiGroupUnitSortByValue(MobilizationGroupBroudUnit x, MobilizationGroupBroudUnit y)
	{
		if (x.Score > y.Score)
		{
			return -1;
		}
		if (x.Score < y.Score)
		{
			return 1;
		}
		return DataManager.CompareStr(x.AllianceTag, y.AllianceTag);
	}

	// Token: 0x060012EF RID: 4847 RVA: 0x0020FBA0 File Offset: 0x0020DDA0
	private static int MobiGroupUnitSortByValue(MobilizationAlliBroudUnit x, MobilizationAlliBroudUnit y)
	{
		if (x.Score > y.Score)
		{
			return -1;
		}
		if (x.Score < y.Score)
		{
			return 1;
		}
		if (x.FinishedMission > y.FinishedMission)
		{
			return -1;
		}
		if (x.FinishedMission < y.FinishedMission)
		{
			return 1;
		}
		return DataManager.CompareStr(x.Name, y.Name);
	}

	// Token: 0x04003AC0 RID: 15040
	private const int boardCount = 19;

	// Token: 0x04003AC1 RID: 15041
	public const int AllianceWarGap = 43200;

	// Token: 0x04003AC2 RID: 15042
	public const int MobilizationUpdateGap = 180;

	// Token: 0x04003AC3 RID: 15043
	public const int AlliHuntUpdateGap = 180;

	// Token: 0x04003AC4 RID: 15044
	public LeaderBoardTopBoard TopBoard;

	// Token: 0x04003AC5 RID: 15045
	public long[] BoardUpdateTime;

	// Token: 0x04003AC6 RID: 15046
	public List<BoardUnit>[] Boards;

	// Token: 0x04003AC7 RID: 15047
	public ushort[] MyRank;

	// Token: 0x04003AC8 RID: 15048
	public byte[] BoardRecived;

	// Token: 0x04003AC9 RID: 15049
	public UIButtonHint hintTarget;

	// Token: 0x04003ACA RID: 15050
	public Transform hintCenter;

	// Token: 0x04003ACB RID: 15051
	public long KingdomBoardNextTime;

	// Token: 0x04003ACC RID: 15052
	public KVKBoardTopBoard KvKTopBoard;

	// Token: 0x04003ACD RID: 15053
	public long AlliMobiEventTime;

	// Token: 0x04003ACE RID: 15054
	public uint MobiGroupAllianceID;

	// Token: 0x04003ACF RID: 15055
	public List<MobilizationGroupBroudUnit> MobiGroupBoard;

	// Token: 0x04003AD0 RID: 15056
	public long MobiGroupBoardUpdateTime;

	// Token: 0x04003AD1 RID: 15057
	public int MobiGroupRank;

	// Token: 0x04003AD2 RID: 15058
	public uint MobiGroupLastScore;

	// Token: 0x04003AD3 RID: 15059
	public ushort MobiGroupSaveVer;

	// Token: 0x04003AD4 RID: 15060
	public List<MobilizationAlliBroudUnit> MobiAlliBoard;

	// Token: 0x04003AD5 RID: 15061
	public long MobiAlliBoardUpdateTime;

	// Token: 0x04003AD6 RID: 15062
	public int MobiAlliRank;

	// Token: 0x04003AD7 RID: 15063
	public List<HistoryWorldKingDataType> MobiWorldKingBoard;

	// Token: 0x04003AD8 RID: 15064
	public byte HistoryKingDataNum;

	// Token: 0x04003AD9 RID: 15065
	public ushort KingHead;

	// Token: 0x04003ADA RID: 15066
	public WorldLeaderBoardTopBoard WorldLeaderBoardTopBoard;

	// Token: 0x04003ADB RID: 15067
	public long KingofWorldTime;

	// Token: 0x04003ADC RID: 15068
	public ushort KingofWorldHead;

	// Token: 0x04003ADD RID: 15069
	public List<KingofWorldBoardUnit> KingofWorldBoard;

	// Token: 0x04003ADE RID: 15070
	public ushort NobileWonderId;

	// Token: 0x04003ADF RID: 15071
	public long NobileTime;

	// Token: 0x04003AE0 RID: 15072
	public ushort NobileHead;

	// Token: 0x04003AE1 RID: 15073
	public List<KingofWorldBoardUnit> NobileBoard;

	// Token: 0x04003AE2 RID: 15074
	public KVSBoardTopBoard KVSTopBoard;

	// Token: 0x04003AE3 RID: 15075
	public List<BoardUnit> AlliHuntBoard;

	// Token: 0x04003AE4 RID: 15076
	public long AlliHuntBoardUpdateTime;

	// Token: 0x04003AE5 RID: 15077
	public int AlliHuntRank;

	// Token: 0x04003AE6 RID: 15078
	public long AlliHuntEventTime;

	// Token: 0x04003AE7 RID: 15079
	public long AlliVSEventTime;

	// Token: 0x04003AE8 RID: 15080
	public List<AllianceWarBroudUnit> AllianceWarGroupBoard;

	// Token: 0x04003AE9 RID: 15081
	public long AllianceWarGroupBoardUpdateTime;

	// Token: 0x04003AEA RID: 15082
	public int AllianceWarGroupRank;

	// Token: 0x04003AEB RID: 15083
	public byte AllianceWarGroupRankUpNum;

	// Token: 0x04003AEC RID: 15084
	public byte AllianceWarGroupRankDownNum;

	// Token: 0x04003AED RID: 15085
	public long AllianceWarAlliBoardUpdateTime;

	// Token: 0x04003AEE RID: 15086
	public long FootBallBoardTime;

	// Token: 0x04003AEF RID: 15087
	public FootBallTopBoard FootBallTopBoard;

	// Token: 0x04003AF0 RID: 15088
	public byte FootBallBoardType;

	// Token: 0x04003AF1 RID: 15089
	public List<MobilizationAlliWorldBroudUnit> MobilizationAlliWorldBoard;

	// Token: 0x04003AF2 RID: 15090
	public long MobilizationAlliWorldBoardTime;

	// Token: 0x04003AF3 RID: 15091
	public int MobilizationAlliWorldRank;

	// Token: 0x04003AF4 RID: 15092
	public int MobilizationAlliWorldLastRank;

	// Token: 0x04003AF5 RID: 15093
	public uint MobiAlliWorldAllianceID;

	// Token: 0x04003AF6 RID: 15094
	private static LeaderBoardManager _instance;
}
