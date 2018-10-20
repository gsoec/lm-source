using System;

// Token: 0x020002B9 RID: 697
public struct AllianceBattle
{
	// Token: 0x06000E0E RID: 3598 RVA: 0x001648B0 File Offset: 0x00162AB0
	public static void CheckBattleStationA()
	{
		AllianceBattle.BattleRoyaleView.Clear();
		AllianceBattle.BattleRoyale.Clear();
	}

	// Token: 0x06000E0F RID: 3599 RVA: 0x001648C8 File Offset: 0x00162AC8
	public static void Reset()
	{
		AllianceBattle.ReplayPaused = false;
	}

	// Token: 0x06000E10 RID: 3600 RVA: 0x001648D0 File Offset: 0x00162AD0
	public static bool Check()
	{
		return ActivityManager.Instance.AW_Round == AllianceBattle.BattleRoyale.GameRound && ActivityManager.Instance.AW_RoundBeginTime == AllianceBattle.BattleRoyale.BeginTime;
	}

	// Token: 0x06000E11 RID: 3601 RVA: 0x00164910 File Offset: 0x00162B10
	public static void RecvAllianceBattleStation(MessagePacket MP)
	{
		switch (MP.Protocol)
		{
		case Protocol._MSG_RESP_ALLIANCEWAR_LIVE_LEFTSIDE_LIST:
		{
			if (AllianceBattle.BattleRoyale.AutobotTag == null)
			{
				AllianceBattle.BattleRoyale.AutobotTag = StringManager.Instance.SpawnString(3);
			}
			MP.ReadStringPlus(3, AllianceBattle.BattleRoyale.AutobotTag, -1);
			AllianceBattle.BattleRoyale.CampAutobot = MP.ReadByte(-1);
			AllianceBattle.BattleRoyale.AutobotIcon = MP.ReadUShort(-1);
			AllianceBattle.BattleRoyale.AutobotPos = MP.ReadByte(-1);
			AllianceBattle.BattleRoyale.Autobots = MP.ReadByte(-1);
			ActivityManager.Instance.AllianceWarMgr.Initial();
			int num = 0;
			while (num < (int)AllianceBattle.BattleRoyale.Autobots && num < ActivityManager.Instance.AllianceWarMgr.RegisterData.Length)
			{
				ActivityManager.Instance.AllianceWarMgr.RegisterData[(int)AllianceBattle.BattleRoyale.Autobots - num - 1].Initial();
				MP.ReadStringPlus(13, ActivityManager.Instance.AllianceWarMgr.RegisterData[(int)AllianceBattle.BattleRoyale.Autobots - num - 1].Name, -1);
				ActivityManager.Instance.AllianceWarMgr.RegisterData[(int)AllianceBattle.BattleRoyale.Autobots - num - 1].Power = MP.ReadULong(-1);
				ActivityManager.Instance.AllianceWarMgr.RegisterData[(int)AllianceBattle.BattleRoyale.Autobots - num - 1].Head = MP.ReadUShort(-1);
				num++;
			}
			if (AllianceBattle.BattleRoyale.Autobots > 0 && AllianceBattle.BattleRoyale.AutobotPos > 0 && AllianceBattle.BattleRoyale.Autobots >= AllianceBattle.BattleRoyale.AutobotPos)
			{
				AllianceBattle.BattleRoyale.AutobotPos = AllianceBattle.BattleRoyale.Autobots - AllianceBattle.BattleRoyale.AutobotPos + 1;
			}
			break;
		}
		case Protocol._MSG_RESP_ALLIANCEWAR_LIVE_RIGHTSIDE_LIST:
		{
			if (AllianceBattle.BattleRoyale.DecepticonTag == null)
			{
				AllianceBattle.BattleRoyale.DecepticonTag = StringManager.Instance.SpawnString(3);
			}
			MP.ReadStringPlus(3, AllianceBattle.BattleRoyale.DecepticonTag, -1);
			AllianceBattle.BattleRoyale.CampDecepticon = MP.ReadByte(-1);
			AllianceBattle.BattleRoyale.DecepticonIcon = MP.ReadUShort(-1);
			AllianceBattle.BattleRoyale.DecepticonPos = MP.ReadByte(-1);
			AllianceBattle.BattleRoyale.Decepticons = MP.ReadByte(-1);
			ActivityManager.Instance.AllianceWarMgr.Initial();
			int num2 = 0;
			while (num2 < (int)AllianceBattle.BattleRoyale.Decepticons && num2 < ActivityManager.Instance.AllianceWarMgr.WaitData.Length)
			{
				ActivityManager.Instance.AllianceWarMgr.WaitData[(int)AllianceBattle.BattleRoyale.Decepticons - num2 - 1].Initial();
				MP.ReadStringPlus(13, ActivityManager.Instance.AllianceWarMgr.WaitData[(int)AllianceBattle.BattleRoyale.Decepticons - num2 - 1].Name, -1);
				ActivityManager.Instance.AllianceWarMgr.WaitData[(int)AllianceBattle.BattleRoyale.Decepticons - num2 - 1].Power = MP.ReadULong(-1);
				ActivityManager.Instance.AllianceWarMgr.WaitData[(int)AllianceBattle.BattleRoyale.Decepticons - num2 - 1].Head = MP.ReadUShort(-1);
				num2++;
			}
			if (AllianceBattle.BattleRoyale.Decepticons > 0 && AllianceBattle.BattleRoyale.DecepticonPos > 0 && AllianceBattle.BattleRoyale.Decepticons >= AllianceBattle.BattleRoyale.DecepticonPos)
			{
				AllianceBattle.BattleRoyale.DecepticonPos = AllianceBattle.BattleRoyale.Decepticons - AllianceBattle.BattleRoyale.DecepticonPos + 1;
			}
			break;
		}
		case Protocol._MSG_RESP_ALLIANCEWAR_LIVE_WAR_DETAIL:
		{
			if (AllianceBattle.BattleRoyale.CampAutobot > 0)
			{
				AllianceBattle.BattleRoyale.BattleSide = 1;
			}
			else if (AllianceBattle.BattleRoyale.CampDecepticon > 0)
			{
				AllianceBattle.BattleRoyale.BattleSide = 2;
			}
			else
			{
				AllianceBattle.BattleRoyale.BattleSide = 0;
			}
			if (AllianceBattle.BattleRoyale.AutobotPos > 0)
			{
				AllianceBattle.BattleRoyale.BattlePosition = AllianceBattle.BattleRoyale.AutobotPos;
			}
			else if (AllianceBattle.BattleRoyale.DecepticonPos > 0)
			{
				AllianceBattle.BattleRoyale.BattlePosition = AllianceBattle.BattleRoyale.DecepticonPos;
			}
			else
			{
				AllianceBattle.BattleRoyale.BattlePosition = 0;
			}
			byte b = MP.ReadByte(-1);
			AllianceBattle.BattleRoyale.OnLive = MP.ReadByte(-1);
			AllianceBattle.BattleRoyale.MatchID = MP.ReadByte(-1);
			AllianceBattle.BattleRoyale.GameRound = MP.ReadByte(-1);
			AllianceBattle.BattleRoyale.BattleMatchs = MP.ReadByte(-1);
			if (b == 0 || AllianceBattle.BattleRoyale.BattleMatch == null || AllianceBattle.BattleRoyale.BattleMatch.Length != (int)AllianceBattle.BattleRoyale.BattleMatchs)
			{
				AllianceBattle.BattleRoyale.BattleMatch = new AlliWarWarDetail[(int)AllianceBattle.BattleRoyale.BattleMatchs];
			}
			for (int i = 0; i < AllianceBattle.BattleRoyale.BattleMatch.Length; i++)
			{
				if (b == 0)
				{
					AllianceBattle.BattleRoyale.BattleMatch[i].WinnerSide = MP.ReadByte(-1);
					AllianceBattle.BattleRoyale.BattleMatch[i].LeftSurvive = MP.ReadUInt(-1);
					AllianceBattle.BattleRoyale.BattleMatch[i].RightSurvive = MP.ReadUInt(-1);
				}
				else
				{
					AllianceBattle.BattleRoyale.BattleMatch[i].WinnerSide = MP.ReadByte(-1);
					AllianceBattle.BattleRoyale.BattleMatch[i].LeftDead = MP.ReadUInt(-1);
					AllianceBattle.BattleRoyale.BattleMatch[i].RightDead = MP.ReadUInt(-1);
				}
			}
			if (AllianceBattle.BattleRoyale.OnLive > 0)
			{
				AllianceBattle.BattleRoyale.BeginTime = ActivityManager.Instance.AW_RoundBeginTime;
			}
			if (b == 1)
			{
				ActivityManager.Instance.AW_bcalculateEnd = true;
				GUIManager.Instance.HideUILock(EUILock.Activity);
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door)
				{
					ActivityManager.Instance.AllianceWarReopenCheck();
					if (GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarBattle))
					{
						GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarBattle, 4, 0);
					}
					else
					{
						door.OpenMenu(EGUIWindow.UI_AllianceWarBattle, 0, 0, true);
					}
				}
			}
			break;
		}
		case Protocol._MSG_RESP_ALLIANCEWAR_REPLAY_LEFTSIDE_LIST:
		{
			if (AllianceBattle.BattleRoyaleView.AutobotTag == null)
			{
				AllianceBattle.BattleRoyaleView.AutobotTag = StringManager.Instance.SpawnString(3);
			}
			if (AllianceBattle.BattleRoyaleView.Autobot == null)
			{
				AllianceBattle.BattleRoyaleView.Autobot = new AllianceWarManager._RegisterData[80];
			}
			MP.ReadStringPlus(3, AllianceBattle.BattleRoyaleView.AutobotTag, -1);
			AllianceBattle.BattleRoyaleView.CampAutobot = MP.ReadByte(-1);
			AllianceBattle.BattleRoyaleView.AutobotIcon = MP.ReadUShort(-1);
			AllianceBattle.BattleRoyaleView.AutobotPos = MP.ReadByte(-1);
			AllianceBattle.BattleRoyaleView.Autobots = Math.Min(MP.ReadByte(-1), (byte)AllianceBattle.BattleRoyaleView.Autobot.Length);
			int num3 = 0;
			while (num3 < (int)AllianceBattle.BattleRoyaleView.Autobots && num3 < AllianceBattle.BattleRoyaleView.Autobot.Length)
			{
				AllianceBattle.BattleRoyaleView.Autobot[(int)AllianceBattle.BattleRoyaleView.Autobots - num3 - 1].Initial();
				MP.ReadStringPlus(13, AllianceBattle.BattleRoyaleView.Autobot[(int)AllianceBattle.BattleRoyaleView.Autobots - num3 - 1].Name, -1);
				AllianceBattle.BattleRoyaleView.Autobot[(int)AllianceBattle.BattleRoyaleView.Autobots - num3 - 1].Power = MP.ReadULong(-1);
				AllianceBattle.BattleRoyaleView.Autobot[(int)AllianceBattle.BattleRoyaleView.Autobots - num3 - 1].Head = MP.ReadUShort(-1);
				num3++;
			}
			if (AllianceBattle.BattleRoyaleView.Autobots > 0 && AllianceBattle.BattleRoyaleView.AutobotPos > 0 && AllianceBattle.BattleRoyaleView.Autobots >= AllianceBattle.BattleRoyaleView.AutobotPos)
			{
				AllianceBattle.BattleRoyaleView.AutobotPos = AllianceBattle.BattleRoyaleView.Autobots - AllianceBattle.BattleRoyaleView.AutobotPos + 1;
			}
			break;
		}
		case Protocol._MSG_RESP_ALLIANCEWAR_REPLAY_RIGHTSIDE_LIST:
		{
			if (AllianceBattle.BattleRoyaleView.DecepticonTag == null)
			{
				AllianceBattle.BattleRoyaleView.DecepticonTag = StringManager.Instance.SpawnString(3);
			}
			if (AllianceBattle.BattleRoyaleView.Decepticon == null)
			{
				AllianceBattle.BattleRoyaleView.Decepticon = new AllianceWarManager._RegisterData[80];
			}
			MP.ReadStringPlus(3, AllianceBattle.BattleRoyaleView.DecepticonTag, -1);
			AllianceBattle.BattleRoyaleView.CampDecepticon = MP.ReadByte(-1);
			AllianceBattle.BattleRoyaleView.DecepticonIcon = MP.ReadUShort(-1);
			AllianceBattle.BattleRoyaleView.DecepticonPos = MP.ReadByte(-1);
			AllianceBattle.BattleRoyaleView.Decepticons = Math.Min(MP.ReadByte(-1), (byte)AllianceBattle.BattleRoyaleView.Decepticon.Length);
			int num4 = 0;
			while (num4 < (int)AllianceBattle.BattleRoyaleView.Decepticons && num4 < AllianceBattle.BattleRoyaleView.Decepticon.Length)
			{
				AllianceBattle.BattleRoyaleView.Decepticon[(int)AllianceBattle.BattleRoyaleView.Decepticons - num4 - 1].Initial();
				MP.ReadStringPlus(13, AllianceBattle.BattleRoyaleView.Decepticon[(int)AllianceBattle.BattleRoyaleView.Decepticons - num4 - 1].Name, -1);
				AllianceBattle.BattleRoyaleView.Decepticon[(int)AllianceBattle.BattleRoyaleView.Decepticons - num4 - 1].Power = MP.ReadULong(-1);
				AllianceBattle.BattleRoyaleView.Decepticon[(int)AllianceBattle.BattleRoyaleView.Decepticons - num4 - 1].Head = MP.ReadUShort(-1);
				num4++;
			}
			if (AllianceBattle.BattleRoyaleView.Decepticons > 0 && AllianceBattle.BattleRoyaleView.DecepticonPos > 0 && AllianceBattle.BattleRoyaleView.Decepticons >= AllianceBattle.BattleRoyaleView.DecepticonPos)
			{
				AllianceBattle.BattleRoyaleView.DecepticonPos = AllianceBattle.BattleRoyaleView.Decepticons - AllianceBattle.BattleRoyaleView.DecepticonPos + 1;
			}
			break;
		}
		case Protocol._MSG_RESP_ALLIANCEWAR_REPLAY_WAR_DETAIL:
		{
			if (AllianceBattle.BattleRoyaleView.CampAutobot > 0)
			{
				AllianceBattle.BattleRoyaleView.BattleSide = 1;
			}
			else if (AllianceBattle.BattleRoyaleView.CampDecepticon > 0)
			{
				AllianceBattle.BattleRoyaleView.BattleSide = 2;
			}
			else
			{
				AllianceBattle.BattleRoyaleView.BattleSide = 0;
			}
			if (AllianceBattle.BattleRoyaleView.AutobotPos > 0)
			{
				AllianceBattle.BattleRoyaleView.BattlePosition = AllianceBattle.BattleRoyaleView.AutobotPos;
			}
			else if (AllianceBattle.BattleRoyaleView.DecepticonPos > 0)
			{
				AllianceBattle.BattleRoyaleView.BattlePosition = AllianceBattle.BattleRoyaleView.DecepticonPos;
			}
			else
			{
				AllianceBattle.BattleRoyaleView.BattlePosition = 0;
			}
			byte b2 = MP.ReadByte(-1);
			AllianceBattle.BattleRoyaleView.OnLive = MP.ReadByte(-1);
			AllianceBattle.BattleRoyaleView.MatchID = MP.ReadByte(-1);
			AllianceBattle.BattleRoyaleView.GameRound = MP.ReadByte(-1);
			AllianceBattle.BattleRoyaleView.BattleMatchs = MP.ReadByte(-1);
			if (b2 == 0 || AllianceBattle.BattleRoyaleView.BattleMatch == null || AllianceBattle.BattleRoyaleView.BattleMatch.Length != (int)AllianceBattle.BattleRoyaleView.BattleMatchs)
			{
				AllianceBattle.BattleRoyaleView.BattleMatch = new AlliWarWarDetail[(int)AllianceBattle.BattleRoyaleView.BattleMatchs];
			}
			for (int j = 0; j < AllianceBattle.BattleRoyaleView.BattleMatch.Length; j++)
			{
				if (b2 == 0)
				{
					AllianceBattle.BattleRoyaleView.BattleMatch[j].WinnerSide = MP.ReadByte(-1);
					AllianceBattle.BattleRoyaleView.BattleMatch[j].LeftSurvive = MP.ReadUInt(-1);
					AllianceBattle.BattleRoyaleView.BattleMatch[j].RightSurvive = MP.ReadUInt(-1);
				}
				else
				{
					AllianceBattle.BattleRoyaleView.BattleMatch[j].WinnerSide = MP.ReadByte(-1);
					AllianceBattle.BattleRoyaleView.BattleMatch[j].LeftDead = MP.ReadUInt(-1);
					AllianceBattle.BattleRoyaleView.BattleMatch[j].RightDead = MP.ReadUInt(-1);
				}
			}
			if (AllianceBattle.BattleRoyaleView.OnLive > 0)
			{
				AllianceBattle.BattleRoyaleView.BeginTime = ActivityManager.Instance.AW_RoundBeginTime;
			}
			if (b2 == 1)
			{
				GUIManager.Instance.HideUILock(EUILock.Activity);
				Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door2)
				{
					ActivityManager.Instance.AllianceWarReopenCheck();
					UIAllianceWarBattle.ResetMatchID();
					if (GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarBattle))
					{
						GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarBattle, 4, 0);
					}
					else
					{
						door2.OpenMenu(EGUIWindow.UI_AllianceWarBattle, 0, 1, true);
					}
				}
			}
			break;
		}
		}
	}

	// Token: 0x04002D64 RID: 11620
	public static BattleStation BattleRoyale;

	// Token: 0x04002D65 RID: 11621
	public static BattleStation BattleRoyaleView;

	// Token: 0x04002D66 RID: 11622
	public static bool ReplayPaused;

	// Token: 0x04002D67 RID: 11623
	public static byte ReplaySpeed;
}
