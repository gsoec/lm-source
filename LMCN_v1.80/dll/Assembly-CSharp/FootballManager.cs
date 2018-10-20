using System;
using UnityEngine;

// Token: 0x0200035E RID: 862
public class FootballManager
{
	// Token: 0x17000085 RID: 133
	// (get) Token: 0x060011A7 RID: 4519 RVA: 0x001EDD54 File Offset: 0x001EBF54
	public static FootballManager Instance
	{
		get
		{
			if (FootballManager.instance == null)
			{
				FootballManager.instance = new FootballManager();
			}
			return FootballManager.instance;
		}
	}

	// Token: 0x060011A8 RID: 4520 RVA: 0x001EDD70 File Offset: 0x001EBF70
	public void LoadTable()
	{
		this.FootBallSkillTable = new CExternalTableWithWordKey<FootBallSkillData>();
		this.FootBallSkillTable.LoadTable("FootballSkill");
		this.FootBallComboTable = new CExternalTableWithWordKey<FootBallCombo>();
		this.FootBallComboTable.LoadTable("FootballCombo");
	}

	// Token: 0x060011A9 RID: 4521 RVA: 0x001EDDB8 File Offset: 0x001EBFB8
	public void RecvFootBall_Skill_Use(MessagePacket MP)
	{
		GUIManager guimanager = GUIManager.Instance;
		DataManager dataManager = DataManager.Instance;
		guimanager.HideUILock(EUILock.FootBallSkill);
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			ushort num = MP.ReadUShort(-1);
			num = (ushort)Mathf.Clamp((int)(num - 1), 0, this.mFootballSkillCDTime.Length - 1);
			this.mFootballSkillCDTime[(int)num] = MP.ReadLong(-1);
			byte b2 = MP.ReadByte(-1);
			b2 = (byte)Mathf.Clamp((int)b2, 0, dataManager.MarchEventData.Length - 1);
			dataManager.MarchEventData[(int)b2].Type = EMarchEventType.EMET_FooballMarching;
			dataManager.MarchEventData[(int)b2].Point.zoneID = MP.ReadUShort(-1);
			dataManager.MarchEventData[(int)b2].Point.pointID = MP.ReadByte(-1);
			dataManager.MarchEventData[(int)b2].PointKind = POINT_KIND.PK_NPC;
			dataManager.MarchEventTime[(int)b2].BeginTime = MP.ReadLong(-1);
			dataManager.MarchEventTime[(int)b2].RequireTime = MP.ReadUInt(-1);
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					dataManager.MarchEventData[(int)b2].TroopData[i][j] = MP.ReadUInt(-1);
					dataManager.RoleAttr.m_Soldier[i * 4 + j] -= dataManager.MarchEventData[(int)b2].TroopData[i][j];
					dataManager.SoldierTotal -= (long)((ulong)dataManager.MarchEventData[(int)b2].TroopData[i][j]);
				}
			}
			dataManager.CheckTroolCount();
			dataManager.SetQueueBarData(EQueueBarIndex.MarchingBegin + (int)b2, true, dataManager.MarchEventTime[(int)b2].BeginTime, dataManager.MarchEventTime[(int)b2].RequireTime);
			dataManager.SetRecvQueueBarData((int)(2 + b2));
			guimanager.UpdateUI(EGUIWindow.UI_FootBall, 3, 0);
			DataManager.msgBuffer[0] = 81;
			GameConstants.GetBytes((ushort)b2, DataManager.msgBuffer, 1);
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			guimanager.UpdateUI(EGUIWindow.UI_ArmyInfo, 0, 0);
			AudioManager.Instance.PlayUISFX(UIKind.Expedition);
			DataManager.MapDataController.MyFocusBallLineTableID = -1;
		}
		else
		{
			switch (b)
			{
			case 1:
			case 2:
			case 7:
			case 8:
			case 10:
				guimanager.MsgStr.ClearString();
				guimanager.MsgStr.IntToFormat((long)b, 1, false);
				guimanager.MsgStr.AppendFormat(dataManager.mStringTable.GetStringByID(17207u));
				guimanager.AddHUDMessage(guimanager.MsgStr.ToString(), 255, true);
				break;
			case 3:
				guimanager.AddHUDMessage(dataManager.mStringTable.GetStringByID(17211u), 255, true);
				break;
			case 4:
				guimanager.AddHUDMessage(dataManager.mStringTable.GetStringByID(8351u), 255, true);
				break;
			case 5:
				guimanager.AddHUDMessage(dataManager.mStringTable.GetStringByID(17198u), 255, true);
				break;
			case 6:
				guimanager.AddHUDMessage(dataManager.mStringTable.GetStringByID(17208u), 255, true);
				break;
			case 9:
				guimanager.AddHUDMessage(dataManager.mStringTable.GetStringByID(119u), 255, true);
				break;
			}
			guimanager.UpdateUI(EGUIWindow.UI_FootBall, 4, 0);
		}
	}

	// Token: 0x060011AA RID: 4522 RVA: 0x001EE140 File Offset: 0x001EC340
	public void RecvFootBall_Data(MessagePacket MP)
	{
		this.mFootballKickData.last_football_id = MP.ReadUInt(-1);
		this.mFootballKickData.last_kick_time = MP.ReadLong(-1);
		this.mFootballKickData.combo = MP.ReadUShort(-1);
		for (int i = 0; i < 4; i++)
		{
			this.mFootballSkillCDTime[i] = MP.ReadLong(-1);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBall, 1, 255);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBall, 2, 0);
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			door.CheckhowFIFA_FindBtn();
		}
	}

	// Token: 0x060011AB RID: 4523 RVA: 0x001EE1EC File Offset: 0x001EC3EC
	public void RecvFootBall_Kick_Data(MessagePacket MP)
	{
		this.mFootballKickData.last_football_id = MP.ReadUInt(-1);
		this.mFootballKickData.last_kick_time = MP.ReadLong(-1);
		this.mFootballKickData.combo = MP.ReadUShort(-1);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBall, 2, 0);
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			door.CheckhowFIFA_FindBtn();
		}
		if (DataManager.MapDataController.MyFocusBallLineTableID > -1)
		{
			DataManager.msgBuffer[0] = 108;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
		else
		{
			DataManager.MapDataController.MyFocusBallLineTableID = -2;
		}
	}

	// Token: 0x060011AC RID: 4524 RVA: 0x001EE298 File Offset: 0x001EC498
	public void SendFootBall_Skill(ushort zoneID, byte pointID, ushort skill_id, byte direction)
	{
		GUIManager.Instance.ShowUILock(EUILock.FootBallSkill);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_FOOTBALL_SKILL_USE;
		messagePacket.AddSeqId();
		messagePacket.Add(zoneID);
		messagePacket.Add(pointID);
		messagePacket.Add(skill_id);
		messagePacket.Add(direction);
		messagePacket.Send(false);
	}

	// Token: 0x060011AD RID: 4525 RVA: 0x001EE2F4 File Offset: 0x001EC4F4
	public void CheckFootBallIDHitClose(int mKind = 1)
	{
		UIFootBall x = GUIManager.Instance.FindMenu(EGUIWindow.UI_FootBall) as UIFootBall;
		if (x != null)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBall, 3, mKind);
		}
		else
		{
			this.mCloseFootBallSkill = (byte)mKind;
		}
	}

	// Token: 0x060011AE RID: 4526 RVA: 0x001EE340 File Offset: 0x001EC540
	public void RecvFootBallKickFailedReturn(MessagePacket MP)
	{
		DataManager dataManager = DataManager.Instance;
		GUIManager guimanager = GUIManager.Instance;
		FAILED_REASON failed_REASON = (FAILED_REASON)MP.ReadByte(-1);
		byte b = MP.ReadByte(-1);
		if (b >= 8)
		{
			return;
		}
		dataManager.MarchEventData[(int)b].Type = (EMarchEventType)MP.ReadByte(-1);
		dataManager.MarchEventTime[(int)b].BeginTime = MP.ReadLong(-1);
		dataManager.MarchEventTime[(int)b].RequireTime = MP.ReadUInt(-1);
		dataManager.SetQueueBarData(EQueueBarIndex.MarchingBegin + (int)b, true, dataManager.MarchEventTime[(int)b].BeginTime, dataManager.MarchEventTime[(int)b].RequireTime);
		dataManager.CheckTroolCount();
		guimanager.UpdateUI(EGUIWindow.UI_ArmyInfo, 0, 0);
		guimanager.UpdateUI(EGUIWindow.UI_BagFilter, -1, (int)(2 + b));
		guimanager.UpdateUI(EGUIWindow.UI_Rally, 0, 0);
		if (failed_REASON == FAILED_REASON.FAILED_REASON_KICK_AWAY)
		{
			guimanager.AddHUDMessage(dataManager.mStringTable.GetStringByID(14737u), 255, true);
		}
		else if (failed_REASON == FAILED_REASON.FAILED_REASON_KICK_VANISH)
		{
			guimanager.AddHUDMessage(dataManager.mStringTable.GetStringByID(14738u), 255, true);
		}
	}

	// Token: 0x060011AF RID: 4527 RVA: 0x001EE458 File Offset: 0x001EC658
	public void MoveToFootballPos()
	{
		if (this.mFootballKickData.combo > 0 && this.bWaitingPos == 0)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_FOOTBALL_KICK_POSITION;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			this.bWaitingPos = 1;
		}
	}

	// Token: 0x060011B0 RID: 4528 RVA: 0x001EE4AC File Offset: 0x001EC6AC
	public void RecvFootballeKickPosition(MessagePacket MP)
	{
		this.bWaitingPos = 0;
		byte b = MP.ReadByte(-1);
		if (b > 0)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14734u), 255, true);
			return;
		}
		this.FootballPosition.zoneID = MP.ReadUShort(-1);
		this.FootballPosition.pointID = MP.ReadByte(-1);
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			door.GoToMapID(DataManager.MapDataController.OtherKingdomData.kingdomID, GameConstants.PointCodeToMapID(this.FootballPosition.zoneID, this.FootballPosition.pointID), 0, 1, true);
		}
	}

	// Token: 0x060011B1 RID: 4529 RVA: 0x001EE568 File Offset: 0x001EC768
	public void RecvFootballeKick_Member_Goal(MessagePacket MP)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		MP.ReadStringPlus(13, cstring, -1);
		byte wonderID = MP.ReadByte(-1);
		GUIManager guimanager = GUIManager.Instance;
		DataManager dataManager = DataManager.Instance;
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring2.StringToFormat(cstring);
		cstring2.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)wonderID, DataManager.MapDataController.OtherKingdomData.kingdomID));
		cstring2.AppendFormat(dataManager.mStringTable.GetStringByID(14743u));
		guimanager.AddHUDMessage(cstring2.ToString(), 255, true);
	}

	// Token: 0x060011B2 RID: 4530 RVA: 0x001EE600 File Offset: 0x001EC800
	public void loginFinish()
	{
		this.bWaitingPos = 0;
	}

	// Token: 0x0400383A RID: 14394
	private static FootballManager instance;

	// Token: 0x0400383B RID: 14395
	public CExternalTableWithWordKey<FootBallSkillData> FootBallSkillTable;

	// Token: 0x0400383C RID: 14396
	public CExternalTableWithWordKey<FootBallCombo> FootBallComboTable;

	// Token: 0x0400383D RID: 14397
	public FootballKickDataModel mFootballKickData = default(FootballKickDataModel);

	// Token: 0x0400383E RID: 14398
	public long[] mFootballSkillCDTime = new long[4];

	// Token: 0x0400383F RID: 14399
	public bool bFirstOpen = true;

	// Token: 0x04003840 RID: 14400
	public uint NowBallID;

	// Token: 0x04003841 RID: 14401
	public int mFootBallMapID;

	// Token: 0x04003842 RID: 14402
	public byte mCloseFootBallSkill;

	// Token: 0x04003843 RID: 14403
	public Vector2 mFootBallCenterPos = Vector2.zero;

	// Token: 0x04003844 RID: 14404
	public byte mUIOpenState;

	// Token: 0x04003845 RID: 14405
	public bool bFirstFootBallMiniMap = true;

	// Token: 0x04003846 RID: 14406
	public PointCode FootballPosition;

	// Token: 0x04003847 RID: 14407
	private byte bWaitingPos;
}
