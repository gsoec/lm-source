using System;
using System.Collections.Generic;

// Token: 0x0200037A RID: 890
public class JailManage
{
	// Token: 0x0600128C RID: 4748 RVA: 0x00209F04 File Offset: 0x00208104
	public static void MSG_RESP_LORD_BEINGCAPTIVE(MessagePacket MP)
	{
		if (DataManager.Instance.beCaptured.AlliTag == null)
		{
			DataManager.Instance.beCaptured.AlliTag = StringManager.Instance.SpawnString(30);
		}
		if (DataManager.Instance.beCaptured.name == null)
		{
			DataManager.Instance.beCaptured.name = StringManager.Instance.SpawnString(30);
		}
		DataManager.Instance.beCaptured.AlliTag.ClearString();
		DataManager.Instance.beCaptured.name.ClearString();
		DataManager.Instance.beCaptured.KingdomID = MP.ReadUShort(-1);
		DataManager.Instance.beCaptured.head = MP.ReadUShort(-1);
		MP.ReadStringPlus(3, DataManager.Instance.beCaptured.AlliTag, -1);
		MP.ReadStringPlus(13, DataManager.Instance.beCaptured.name, -1);
		PointCode pointCode = default(PointCode);
		pointCode.zoneID = MP.ReadUShort(-1);
		pointCode.pointID = MP.ReadByte(-1);
		DataManager.Instance.beCaptured.MapID = GameConstants.PointCodeToMapID(pointCode.zoneID, pointCode.pointID);
		byte prisonerStat = MP.ReadByte(-1);
		DataManager.Instance.beCaptured.prisonerStat = (PrisonerState)prisonerStat;
		DataManager.Instance.beCaptured.nowCaptureStat = LoadCaptureState.Captured;
		DataManager.Instance.beCaptured.StartActionTime = MP.ReadLong(-1);
		DataManager.Instance.beCaptured.TotalTime = MP.ReadUInt(-1);
		DataManager.Instance.beCaptured.Ransom = MP.ReadUInt(-1);
		DataManager.Instance.beCaptured.Bounty = MP.ReadUInt(-1);
		byte b = MP.ReadByte(-1);
		DataManager.Instance.beCaptured.HomeKingdomID = MP.ReadUShort(-1);
		ushort leaderID = DataManager.Instance.GetLeaderID();
		if (leaderID != 0)
		{
			DataManager.Instance.TempFightHeroID[(int)leaderID] = 1;
			DataManager.Instance.SetFightHeroData();
			GameManager.OnRefresh(NetworkNews.Refresh_Hero, null);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroList_Soldier2, 1, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 3, 0);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 18, 0);
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Hero);
		DataManager.Instance.AttribVal.UpdateLordEquipData();
	}

	// Token: 0x0600128D RID: 4749 RVA: 0x0020A15C File Offset: 0x0020835C
	public static void MSG_RESP_UPDATE_CAPTIVE(MessagePacket MP)
	{
		switch (MP.ReadByte(-1))
		{
		case 0:
			DataManager.Instance.beCaptured.head = MP.ReadUShort(-1);
			break;
		case 1:
			DataManager.Instance.beCaptured.AlliTag.ClearString();
			MP.ReadStringPlus(3, DataManager.Instance.beCaptured.AlliTag, -1);
			break;
		case 2:
			DataManager.Instance.beCaptured.name.ClearString();
			MP.ReadStringPlus(13, DataManager.Instance.beCaptured.name, -1);
			break;
		case 3:
		{
			PointCode pointCode = default(PointCode);
			pointCode.zoneID = MP.ReadUShort(-1);
			pointCode.pointID = MP.ReadByte(-1);
			DataManager.Instance.beCaptured.MapID = GameConstants.PointCodeToMapID(pointCode.zoneID, pointCode.pointID);
			break;
		}
		case 4:
			DataManager.Instance.beCaptured.prisonerStat = (PrisonerState)MP.ReadByte(-1);
			DataManager.Instance.beCaptured.StartActionTime = MP.ReadLong(-1);
			DataManager.Instance.beCaptured.TotalTime = MP.ReadUInt(-1);
			break;
		case 5:
			DataManager.Instance.beCaptured.Ransom = MP.ReadUInt(-1);
			break;
		case 6:
		{
			PointCode pointCode2 = default(PointCode);
			pointCode2.zoneID = MP.ReadUShort(-1);
			pointCode2.pointID = MP.ReadByte(-1);
			DataManager.Instance.beCaptured.MapID = GameConstants.PointCodeToMapID(pointCode2.zoneID, pointCode2.pointID);
			DataManager.Instance.beCaptured.KingdomID = MP.ReadUShort(-1);
			DataManager.Instance.beCaptured.HomeKingdomID = MP.ReadUShort(-1);
			break;
		}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
	}

	// Token: 0x0600128E RID: 4750 RVA: 0x0020A348 File Offset: 0x00208548
	public static void MSG_RESP_CHANGE_BOUNTY(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			DataManager.Instance.beCaptured.Bounty = MP.ReadUInt(-1);
			DataManager.Instance.Resource[4].Stock = MP.ReadUInt(-1);
			GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
		}
		else if (b == 3)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7796u), 255, true);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
		}
	}

	// Token: 0x0600128F RID: 4751 RVA: 0x0020A3E4 File Offset: 0x002085E4
	public static void MSG_RESP_PAY_RANSOM(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			DataManager.Instance.Resource[4].Stock = MP.ReadUInt(-1);
			GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
		}
	}

	// Token: 0x06001290 RID: 4752 RVA: 0x0020A420 File Offset: 0x00208620
	public static void RecvLordReleasedTime(MessagePacket MP)
	{
		DataManager.Instance.beCaptured.StartActionTime = MP.ReadLong(-1);
		DataManager.Instance.beCaptured.TotalTime = MP.ReadUInt(-1);
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.LordReturn, true, DataManager.Instance.beCaptured.StartActionTime, DataManager.Instance.beCaptured.TotalTime);
		DataManager.Instance.SetRecvQueueBarData(30);
		DataManager.Instance.CheckTroolCount();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
	}

	// Token: 0x06001291 RID: 4753 RVA: 0x0020A4B8 File Offset: 0x002086B8
	public static void MSG_RESP_LORD_BEINGRELEASED(MessagePacket MP)
	{
		PointCode pointCode = default(PointCode);
		pointCode.zoneID = MP.ReadUShort(-1);
		pointCode.pointID = MP.ReadByte(-1);
		DataManager.Instance.beCaptured.nowCaptureStat = LoadCaptureState.Returning;
		DataManager.Instance.beCaptured.MapID = GameConstants.PointCodeToMapID(pointCode.zoneID, pointCode.pointID);
		DataManager.Instance.beCaptured.StartActionTime = MP.ReadLong(-1);
		DataManager.Instance.beCaptured.TotalTime = MP.ReadUInt(-1);
		byte b = MP.ReadByte(-1);
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.LordReturn, true, DataManager.Instance.beCaptured.StartActionTime, DataManager.Instance.beCaptured.TotalTime);
		DataManager.Instance.SetRecvQueueBarData(30);
		DataManager.Instance.CheckTroolCount();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0, 0);
		ushort leaderID = DataManager.Instance.GetLeaderID();
		if (leaderID != 0)
		{
			DataManager.Instance.TempFightHeroID[(int)leaderID] = 1;
			DataManager.Instance.SetFightHeroData();
			GameManager.OnRefresh(NetworkNews.Refresh_Hero, null);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroList_Soldier2, 0, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 2, 0);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 18, 0);
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Hero);
		DataManager.Instance.AttribVal.UpdateLordEquipData();
		GUIManager.Instance.CloseMenu(EGUIWindow.UI_SuicideBox);
	}

	// Token: 0x06001292 RID: 4754 RVA: 0x0020A634 File Offset: 0x00208834
	public static void MSG_RESP_LORD_BEINGEXECUTED(MessagePacket MP)
	{
		DataManager.Instance.beCaptured.nowCaptureStat = LoadCaptureState.Dead;
		DataManager.Instance.beCaptured.StartActionTime = MP.ReadLong(-1);
		DataManager.Instance.beCaptured.TotalTime = MP.ReadUInt(-1);
		ushort leaderID = DataManager.Instance.GetLeaderID();
		if (leaderID != 0)
		{
			DataManager.Instance.TempFightHeroID[(int)leaderID] = 1;
			DataManager.Instance.SetFightHeroData();
			GameManager.OnRefresh(NetworkNews.Refresh_Hero, null);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroList_Soldier2, 0, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 2, 0);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 18, 0);
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Hero);
		DataManager.Instance.AttribVal.UpdateLordEquipData();
		GUIManager.Instance.CloseMenu(EGUIWindow.UI_SuicideBox);
	}

	// Token: 0x06001293 RID: 4755 RVA: 0x0020A714 File Offset: 0x00208914
	public static void MSG_RESP_LORD_HOME(MessagePacket MP)
	{
		DataManager.Instance.beCaptured.nowCaptureStat = LoadCaptureState.None;
		DataManager.Instance.beCaptured.StartActionTime = 0L;
		DataManager.Instance.beCaptured.TotalTime = 0u;
		ushort leaderID = DataManager.Instance.GetLeaderID();
		if (leaderID != 0)
		{
			DataManager.Instance.TempFightHeroID[(int)leaderID] = 0;
			DataManager.Instance.SetFightHeroData();
			GameManager.OnRefresh(NetworkNews.Refresh_Hero, null);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroList_Soldier2, 0, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 2, 0);
		}
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.LordReturn, false, 0L, 0u);
		DataManager.Instance.CheckTroolCount();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 18, 0);
		DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Hero);
		DataManager.Instance.AttribVal.UpdateLordEquipData();
	}

	// Token: 0x06001294 RID: 4756 RVA: 0x0020A800 File Offset: 0x00208A00
	public static void MSG_RESP_LORD_REVIVE(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			DataManager.Instance.beCaptured.nowCaptureStat = LoadCaptureState.None;
			DataManager.Instance.beCaptured.StartActionTime = 0L;
			DataManager.Instance.beCaptured.TotalTime = 0u;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 18, 0);
			ushort leaderID = DataManager.Instance.GetLeaderID();
			if (leaderID != 0)
			{
				DataManager.Instance.TempFightHeroID[(int)leaderID] = 0;
				DataManager.Instance.SetFightHeroData();
				GameManager.OnRefresh(NetworkNews.Refresh_Hero, null);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroList_Soldier2, 0, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 2, 0);
			}
			GUIManager.Instance.HideUILock(EUILock.LordInfo);
		}
	}

	// Token: 0x06001295 RID: 4757 RVA: 0x0020A8C0 File Offset: 0x00208AC0
	public static void MSG_RESP_PRISONER_NUM_AND_HIGHESTLEVEL(MessagePacket MP)
	{
		DataManager.Instance.PrisonerNum = MP.ReadByte(-1);
		DataManager.Instance.PrisonerHighestLevel = MP.ReadByte(-1);
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
		GUIManager.Instance.BuildingData.UpdateBuildState(11, 255);
		DataManager.Instance.AttribVal.UpdateJailData();
		if (DataManager.Instance.PrisonerNum > 0 && !DataManager.Instance.Prisoner_Requested)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_PRISONER_LIST;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
		}
	}

	// Token: 0x06001296 RID: 4758 RVA: 0x0020A96C File Offset: 0x00208B6C
	public static void MSG_RESP_PRISONER_LIST(MessagePacket MP)
	{
		JailManage.CleanJail();
		DataManager.Instance.Prisoner_Requested = true;
		byte b = MP.ReadByte(-1);
		for (int i = 0; i < (int)b; i++)
		{
			JailManage.readPrisonerData(MP);
		}
		JailManage.sortJail();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_JailRoom, 0, 0);
	}

	// Token: 0x06001297 RID: 4759 RVA: 0x0020A9CC File Offset: 0x00208BCC
	public static void MSG_RESP_ADD_PRISONER(MessagePacket MP)
	{
		JailManage.readPrisonerData(MP);
		JailManage.sortJail();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_JailRoom, 0, 0);
	}

	// Token: 0x06001298 RID: 4760 RVA: 0x0020AA00 File Offset: 0x00208C00
	public static void MSG_RESP_UPDATE_PRISONER(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		switch (MP.ReadByte(-1))
		{
		case 0:
			if (DataManager.Instance.PrisonerList[(int)b].AlliTag == null)
			{
				DataManager.Instance.PrisonerList[(int)b].AlliTag = StringManager.Instance.SpawnString(30);
			}
			DataManager.Instance.PrisonerList[(int)b].AlliTag.ClearString();
			MP.ReadStringPlus(3, DataManager.Instance.PrisonerList[(int)b].AlliTag, -1);
			break;
		case 1:
			if (DataManager.Instance.PrisonerList[(int)b].name == null)
			{
				DataManager.Instance.PrisonerList[(int)b].name = StringManager.Instance.SpawnString(30);
			}
			DataManager.Instance.PrisonerList[(int)b].name.ClearString();
			MP.ReadStringPlus(13, DataManager.Instance.PrisonerList[(int)b].name, -1);
			break;
		case 2:
			DataManager.Instance.PrisonerList[(int)b].nowStat = (PrisonerState)MP.ReadByte(-1);
			DataManager.Instance.PrisonerList[(int)b].StartActionTime = MP.ReadLong(-1);
			DataManager.Instance.PrisonerList[(int)b].TotalTime = MP.ReadUInt(-1);
			break;
		case 4:
			DataManager.Instance.PrisonerList[(int)b].KingdomID = MP.ReadUShort(-1);
			break;
		}
		JailManage.sortJail();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_JailRoom, 0, 0);
	}

	// Token: 0x06001299 RID: 4761 RVA: 0x0020ABD0 File Offset: 0x00208DD0
	public static void MSG_RESP_PRISONER_ESCAPED(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		DataManager.Instance.PrisonerList[(int)b].nowStat = PrisonerState.None;
		JailManage.sortJail();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0, 0);
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom) != null)
		{
			UIJailRoom uijailRoom = (UIJailRoom)GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom);
			if (uijailRoom.DMIdx == b)
			{
				Door door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
				door.CloseMenu(false);
			}
		}
	}

	// Token: 0x0600129A RID: 4762 RVA: 0x0020AC5C File Offset: 0x00208E5C
	public static void MSG_RESP_PRISONER_BAILED(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (!GameConstants.IsBetween((int)b, 0, 30))
		{
			return;
		}
		DataManager.Instance.PrisonerList[(int)b].nowStat = PrisonerState.None;
		DataManager.Instance.Resource[4].Stock = MP.ReadUInt(-1);
		GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
		JailManage.sortJail();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0, 0);
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom) != null)
		{
			UIJailRoom uijailRoom = (UIJailRoom)GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom);
			if (uijailRoom.DMIdx == b)
			{
				Door door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
				door.CloseMenu(false);
			}
		}
	}

	// Token: 0x0600129B RID: 4763 RVA: 0x0020AD18 File Offset: 0x00208F18
	public static void MSG_RESP_RELEASE_ALL_PRISONER(MessagePacket MP)
	{
		DataManager.Instance.PrisonerNum = 0;
		DataManager.Instance.PrisonerHighestLevel = 0;
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
		DataManager.Instance.AttribVal.UpdateJailData();
		for (byte b = 0; b < 30; b += 1)
		{
			DataManager.Instance.PrisonerList[(int)b].nowStat = PrisonerState.None;
		}
		JailManage.sortJail();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0, 0);
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom) != null)
		{
			Door door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
			door.CloseMenu(false);
		}
	}

	// Token: 0x0600129C RID: 4764 RVA: 0x0020ADCC File Offset: 0x00208FCC
	public static void MSG_RESP_CHANGE_RANSOM(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			byte b = MP.ReadByte(-1);
			DataManager.Instance.PrisonerList[(int)b].Ransom = MP.ReadUInt(-1);
		}
		JailManage.sortJail();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_JailRoom, 0, 0);
	}

	// Token: 0x0600129D RID: 4765 RVA: 0x0020AE2C File Offset: 0x0020902C
	public static void MSG_RESP_RELEASE_PRISONER(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			byte b = MP.ReadByte(-1);
			DataManager.Instance.PrisonerList[(int)b].nowStat = PrisonerState.None;
		}
		JailManage.sortJail();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_JailRoom, 0, 0);
	}

	// Token: 0x0600129E RID: 4766 RVA: 0x0020AE88 File Offset: 0x00209088
	public static void MSG_RESP_EXECUTE_PRISONER(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			byte b = MP.ReadByte(-1);
			if (!GameConstants.IsBetween((int)b, 0, 30))
			{
				return;
			}
			DataManager.Instance.PrisonerList[(int)b].nowStat = PrisonerState.None;
			GUIManager.Instance.MsgStr.ClearString();
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			ushort kingdomID = (DataManager.Instance.PrisonerList[(int)b].KingdomID == DataManager.MapDataController.kingdomData.kingdomID) ? 0 : DataManager.Instance.PrisonerList[(int)b].KingdomID;
			GUIManager.Instance.FormatRoleNameForChat(cstring, DataManager.Instance.PrisonerList[(int)b].name, DataManager.Instance.PrisonerList[(int)b].AlliTag, kingdomID, GUIManager.Instance.IsArabic);
			GUIManager.Instance.MsgStr.StringToFormat(cstring);
			GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12062u));
			GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), 31, true);
			Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(DataManager.Instance.PrisonerList[(int)b].head);
			if (DataManager.Instance.CheckHeroSound(DataManager.Instance.PrisonerList[(int)b].head))
			{
				AudioManager.Instance.PlaySFX(recordByKey.DyingSound, 0f, PitchKind.SpeechSound, null, null);
			}
			UIJailRoom x = GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom) as UIJailRoom;
			if (x != null)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door != null)
				{
					door.CloseMenu(false);
				}
			}
			FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_EXECUTION);
		}
		JailManage.sortJail();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_JailRoom, 0, 0);
	}

	// Token: 0x0600129F RID: 4767 RVA: 0x0020B0A8 File Offset: 0x002092A8
	public static void MSG_PRISON_RESP_PRISONER_POISONEFFECT(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		DataManager.Instance.PrisonerList[(int)b].nowStat = PrisonerState.None;
		JailManage.sortJail();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0, 0);
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom) != null)
		{
			UIJailRoom uijailRoom = (UIJailRoom)GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom);
			if (uijailRoom.DMIdx == b)
			{
				Door door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
				door.CloseMenu(false);
			}
		}
	}

	// Token: 0x060012A0 RID: 4768 RVA: 0x0020B134 File Offset: 0x00209334
	public static void Send_MSG_REQUEST_MAP_PRISONER_LIST(int MapPointID)
	{
		MessagePacket messagePacket;
		if (DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
		{
			messagePacket = new MessagePacket(1024);
		}
		else
		{
			messagePacket = MessagePacket.GetGuestMessagePack();
		}
		messagePacket.Protocol = Protocol._MSG_REQUEST_MAP_PRISONER_LIST;
		messagePacket.AddSeqId();
		ushort data;
		byte data2;
		GameConstants.MapIDToPointCode(MapPointID, out data, out data2);
		messagePacket.Add(data);
		messagePacket.Add(data2);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Jail);
	}

	// Token: 0x060012A1 RID: 4769 RVA: 0x0020B1B4 File Offset: 0x002093B4
	public static void MSG_RESP_MAP_PRISONER_LIST(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = MP.ReadByte(-1);
		if (DataManager.Instance.MapPrisoners == null)
		{
			DataManager.Instance.MapPrisoners = new List<MapPrisoner>();
		}
		for (int i = 0; i < DataManager.Instance.MapPrisoners.Count; i++)
		{
			StringManager.Instance.DeSpawnString(DataManager.Instance.MapPrisoners[i].TagName);
			DataManager.Instance.MapPrisoners[i].TagName = null;
		}
		DataManager.Instance.MapPrisoners.Clear();
		CString cstring = StringManager.Instance.SpawnString(30);
		CString cstring2 = StringManager.Instance.SpawnString(30);
		for (int j = 0; j < (int)b2; j++)
		{
			cstring.ClearString();
			cstring2.ClearString();
			uint money = MP.ReadUInt(-1);
			ushort kingdomID = MP.ReadUShort(-1);
			MP.ReadStringPlus(3, cstring, -1);
			MP.ReadStringPlus(13, cstring2, -1);
			DataManager.Instance.MapPrisoners.Add(new MapPrisoner(money, kingdomID, cstring, cstring2));
		}
		if (b != 0)
		{
			Door door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
			door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 5, 0, false);
			GUIManager.Instance.HideUILock(EUILock.Jail);
		}
		StringManager.Instance.DeSpawnString(cstring);
		StringManager.Instance.DeSpawnString(cstring2);
	}

	// Token: 0x060012A2 RID: 4770 RVA: 0x0020B324 File Offset: 0x00209524
	public static void LoginCheckPrisoner()
	{
		if (DataManager.Instance.PrisonerNum > 0)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_PRISONER_LIST;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
		}
	}

	// Token: 0x060012A3 RID: 4771 RVA: 0x0020B368 File Offset: 0x00209568
	public static void readPrisonerData(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (!GameConstants.IsBetween((int)b, 0, 30))
		{
			return;
		}
		if (DataManager.Instance.PrisonerList[(int)b].AlliTag == null)
		{
			DataManager.Instance.PrisonerList[(int)b].AlliTag = StringManager.Instance.SpawnString(30);
		}
		if (DataManager.Instance.PrisonerList[(int)b].name == null)
		{
			DataManager.Instance.PrisonerList[(int)b].name = StringManager.Instance.SpawnString(30);
		}
		DataManager.Instance.PrisonerList[(int)b].AlliTag.ClearString();
		DataManager.Instance.PrisonerList[(int)b].name.ClearString();
		DataManager.Instance.PrisonerList[(int)b].KingdomID = MP.ReadUShort(-1);
		MP.ReadStringPlus(3, DataManager.Instance.PrisonerList[(int)b].AlliTag, -1);
		MP.ReadStringPlus(13, DataManager.Instance.PrisonerList[(int)b].name, -1);
		DataManager.Instance.PrisonerList[(int)b].LordLevel = MP.ReadByte(-1);
		DataManager.Instance.PrisonerList[(int)b].head = MP.ReadUShort(-1);
		byte nowStat = MP.ReadByte(-1);
		DataManager.Instance.PrisonerList[(int)b].nowStat = (PrisonerState)nowStat;
		DataManager.Instance.PrisonerList[(int)b].StartActionTime = MP.ReadLong(-1);
		DataManager.Instance.PrisonerList[(int)b].TotalTime = MP.ReadUInt(-1);
		DataManager.Instance.PrisonerList[(int)b].Ransom = MP.ReadUInt(-1);
		MP.ReadUInt(-1);
	}

	// Token: 0x060012A4 RID: 4772 RVA: 0x0020B540 File Offset: 0x00209740
	public static void sortJail()
	{
		if (!DataManager.Instance.Prisoner_Requested)
		{
			return;
		}
		DataManager.Instance.PrisonerNum = 0;
		DataManager.Instance.PrisonerHighestLevel = 0;
		byte b = 0;
		while ((int)b < DataManager.Instance.PrisonerList.Length)
		{
			DataManager.Instance.sortedPrisonerList[(int)b] = b;
			if (DataManager.Instance.PrisonerList[(int)b].nowStat != PrisonerState.None)
			{
				DataManager instance = DataManager.Instance;
				instance.PrisonerNum += 1;
				if (DataManager.Instance.PrisonerList[(int)b].LordLevel > DataManager.Instance.PrisonerHighestLevel)
				{
					DataManager.Instance.PrisonerHighestLevel = DataManager.Instance.PrisonerList[(int)b].LordLevel;
				}
			}
			b += 1;
		}
		Array.Sort<byte>(DataManager.Instance.sortedPrisonerList, new Comparison<byte>(JailManage.PrisonerListComparer));
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
		DataManager.Instance.AttribVal.UpdateJailData();
		GUIManager.Instance.BuildingData.UpdateBuildState(11, 255);
	}

	// Token: 0x060012A5 RID: 4773 RVA: 0x0020B664 File Offset: 0x00209864
	public static byte FindPrisonerSortIndex(byte dataIndex)
	{
		byte b = 0;
		while ((int)b < DataManager.Instance.PrisonerList.Length)
		{
			if (DataManager.Instance.sortedPrisonerList[(int)b] == dataIndex)
			{
				return b;
			}
			b += 1;
		}
		return (byte)DataManager.Instance.PrisonerList.Length;
	}

	// Token: 0x060012A6 RID: 4774 RVA: 0x0020B6B0 File Offset: 0x002098B0
	public static void CleanJail()
	{
		byte b = 0;
		while ((int)b < DataManager.Instance.PrisonerList.Length)
		{
			DataManager.Instance.PrisonerList[(int)b].nowStat = PrisonerState.None;
			b += 1;
		}
	}

	// Token: 0x060012A7 RID: 4775 RVA: 0x0020B6F4 File Offset: 0x002098F4
	public static int PrisonerListComparer(byte x, byte y)
	{
		byte[] array = new byte[]
		{
			0,
			1,
			2,
			3
		};
		Prisoner prisoner = DataManager.Instance.PrisonerList[(int)x];
		Prisoner prisoner2 = DataManager.Instance.PrisonerList[(int)y];
		if (prisoner.nowStat > prisoner2.nowStat)
		{
			return -1;
		}
		if (prisoner.nowStat < prisoner2.nowStat)
		{
			return 1;
		}
		if (prisoner.nowStat == PrisonerState.None)
		{
			return 0;
		}
		if (prisoner.nowStat == prisoner2.nowStat)
		{
			if (prisoner.StartActionTime + (long)((ulong)prisoner.TotalTime) < prisoner2.StartActionTime + (long)((ulong)prisoner2.TotalTime))
			{
				return -1;
			}
			if (prisoner.StartActionTime + (long)((ulong)prisoner.TotalTime) < prisoner2.StartActionTime + (long)((ulong)prisoner2.TotalTime))
			{
				return 1;
			}
		}
		return 0;
	}

	// Token: 0x040039E5 RID: 14821
	public const int Execution_CountDown = 21600;

	// Token: 0x040039E6 RID: 14822
	public const int Poison_Take = 108000;
}
