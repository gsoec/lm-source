using System;

// Token: 0x02000324 RID: 804
public class AmbushManager
{
	// Token: 0x06001065 RID: 4197 RVA: 0x001D479C File Offset: 0x001D299C
	private AmbushManager()
	{
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.m_AmbushPlayerName = StringManager.Instance.SpawnString(13);
		this.m_HeroInfo = new TroopLeaderType[5];
		this.m_TroopData = new uint[16];
		this.m_Str = StringManager.Instance.SpawnString(300);
	}

	// Token: 0x1700007F RID: 127
	// (get) Token: 0x06001066 RID: 4198 RVA: 0x001D4808 File Offset: 0x001D2A08
	public static AmbushManager Instance
	{
		get
		{
			if (AmbushManager.instance == null)
			{
				AmbushManager.instance = new AmbushManager();
			}
			return AmbushManager.instance;
		}
	}

	// Token: 0x06001067 RID: 4199 RVA: 0x001D4824 File Offset: 0x001D2A24
	~AmbushManager()
	{
		if (this.m_AmbushPlayerName != null)
		{
			StringManager.Instance.DeSpawnString(this.m_AmbushPlayerName);
		}
		if (this.m_Str != null)
		{
			StringManager.Instance.DeSpawnString(this.m_Str);
		}
	}

	// Token: 0x06001068 RID: 4200 RVA: 0x001D4894 File Offset: 0x001D2A94
	public void RecvAmbushInfo(MessagePacket MP)
	{
		this.ClearAmbushData();
		byte b = MP.ReadByte(-1);
		MP.ReadStringPlus(13, this.m_AmbushPlayerName, -1);
		this.m_AmbushPlayerCapitalPos.zoneID = MP.ReadUShort(-1);
		this.m_AmbushPlayerCapitalPos.pointID = MP.ReadByte(-1);
		this.m_AmbushPlayerHead = MP.ReadUShort(-1);
		for (int i = 0; i < this.m_HeroInfo.Length; i++)
		{
			this.m_HeroInfo[i].HeroID = MP.ReadUShort(-1);
			this.m_HeroInfo[i].Rank = MP.ReadByte(-1);
			this.m_HeroInfo[i].Star = MP.ReadByte(-1);
		}
		this.m_TroopFlag = MP.ReadUShort(-1);
		for (int j = 0; j < this.m_TroopData.Length; j++)
		{
			if ((this.m_TroopFlag >> j & 1) == 1)
			{
				this.m_TroopData[j] = MP.ReadUInt(-1);
			}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Ambush, 0, 0);
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
		if (b == 0)
		{
			this.m_Str.ClearString();
			this.m_Str.StringToFormat(this.m_AmbushPlayerName);
			this.m_Str.AppendFormat(this.DM.mStringTable.GetStringByID(9742u));
			this.GM.AddHUDMessage(this.m_Str.ToString(), 29, true);
		}
	}

	// Token: 0x06001069 RID: 4201 RVA: 0x001D4A18 File Offset: 0x001D2C18
	public void RecvAmbushUpdate(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		switch (b)
		{
		case 0:
		case 1:
			if (b == 0)
			{
				this.m_Str.ClearString();
				this.m_Str.StringToFormat(this.m_AmbushPlayerName);
				this.m_Str.AppendFormat(this.DM.mStringTable.GetStringByID(9738u));
				this.GM.AddHUDMessage(this.m_Str.ToString(), 29, true);
			}
			this.ClearAmbushData();
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Ambush, 1, 0);
			break;
		case 2:
			this.m_TroopFlag = MP.ReadUShort(-1);
			Array.Clear(this.m_TroopData, 0, this.m_TroopData.Length);
			for (int i = 0; i < this.m_TroopData.Length; i++)
			{
				if ((this.m_TroopFlag >> i & 1) == 1)
				{
					this.m_TroopData[i] = MP.ReadUInt(-1);
				}
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Ambush, 0, 0);
			break;
		case 3:
			this.m_AmbushPlayerCapitalPos.zoneID = MP.ReadUShort(-1);
			this.m_AmbushPlayerCapitalPos.pointID = MP.ReadByte(-1);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Ambush, 0, 0);
			break;
		case 4:
			this.m_AmbushPlayerHead = MP.ReadUShort(-1);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Ambush, 2, 0);
			break;
		case 5:
			MP.ReadStringPlus(13, this.m_AmbushPlayerName, -1);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Ambush, 3, 0);
			break;
		}
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
	}

	// Token: 0x0600106A RID: 4202 RVA: 0x001D4BC4 File Offset: 0x001D2DC4
	public void SendDismissAmbush()
	{
		if (GUIManager.Instance.ShowUILock(EUILock.Ambush))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_DISMISS_AMBUSH;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
		}
	}

	// Token: 0x0600106B RID: 4203 RVA: 0x001D4C08 File Offset: 0x001D2E08
	public void RecvDismissAmbush(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			this.ClearAmbushData();
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Ambush, 1, 0);
			GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(9732u), 29, true);
		}
		GUIManager.Instance.HideUILock(EUILock.Ambush);
		GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
	}

	// Token: 0x0600106C RID: 4204 RVA: 0x001D4C7C File Offset: 0x001D2E7C
	public void RecvAmbushDismisReturn(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b >= 8)
		{
			return;
		}
		this.DM.MarchEventTime[(int)b].BeginTime = MP.ReadLong(-1);
		this.DM.MarchEventTime[(int)b].RequireTime = MP.ReadUInt(-1);
		this.DM.SetQueueBarData(EQueueBarIndex.MarchingBegin + (int)b, true, this.DM.MarchEventTime[(int)b].BeginTime, this.DM.MarchEventTime[(int)b].RequireTime);
		GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(9730u), 14, true);
	}

	// Token: 0x0600106D RID: 4205 RVA: 0x001D4D30 File Offset: 0x001D2F30
	public void SendAllyAmbushInfo(string name)
	{
		if (GUIManager.Instance.ShowUILock(EUILock.Ambush))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLY_AMBUSH_INFO;
			messagePacket.AddSeqId();
			messagePacket.Add(name, 13);
			messagePacket.Send(false);
		}
	}

	// Token: 0x0600106E RID: 4206 RVA: 0x001D4D7C File Offset: 0x001D2F7C
	public void RecvAllyAmbushInfo(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			this.ObjPoint.zoneID = MP.ReadUShort(-1);
			this.ObjPoint.pointID = MP.ReadByte(-1);
			if (MP.ReadByte(-1) == 0)
			{
				if (DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyPointCode(this.ObjPoint.zoneID, this.ObjPoint.pointID)) == 0f)
				{
					GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(4829u), this.DM.mStringTable.GetStringByID(119u), null, null, 0, 0, false, false, false, false, false);
				}
				else
				{
					this.m_Door = this.GetDoor();
					if (this.m_Door != null)
					{
						this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, 0, 5, true);
					}
				}
			}
			else
			{
				this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(4826u), this.DM.mStringTable.GetStringByID(9724u), this.DM.mStringTable.GetStringByID(4828u), null, 0, 0, false, false, false, false, false);
				this.m_Door = this.GetDoor();
				if (this.m_Door != null)
				{
					this.m_Door.m_GroundInfo.Close();
				}
			}
		}
		else
		{
			this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(4826u), this.DM.mStringTable.GetStringByID(9725u), this.DM.mStringTable.GetStringByID(4828u), null, 0, 0, false, false, false, false, false);
		}
		GUIManager.Instance.HideUILock(EUILock.Ambush);
	}

	// Token: 0x0600106F RID: 4207 RVA: 0x001D4F50 File Offset: 0x001D3150
	public void SendAmbush(ushort[] Leader, uint[] TroopData)
	{
		if (GUIManager.Instance.ShowUILock(EUILock.Ambush))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_SEND_AMBUSH;
			messagePacket.AddSeqId();
			for (int i = 0; i < Leader.Length; i++)
			{
				messagePacket.Add(Leader[i]);
			}
			for (int j = 0; j < TroopData.Length; j++)
			{
				messagePacket.Add(TroopData[j]);
			}
			messagePacket.Add(this.ObjPoint.zoneID);
			messagePacket.Add(this.ObjPoint.pointID);
			messagePacket.Send(false);
		}
	}

	// Token: 0x06001070 RID: 4208 RVA: 0x001D4FF0 File Offset: 0x001D31F0
	public void RecvAmbush(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b == 0)
		{
			byte b2 = MP.ReadByte(-1);
			if (b2 >= 8)
			{
				return;
			}
			this.DM.MarchEventData[(int)b2].Point.zoneID = MP.ReadUShort(-1);
			this.DM.MarchEventData[(int)b2].Point.pointID = MP.ReadByte(-1);
			this.DM.MarchEventTime[(int)b2].BeginTime = MP.ReadLong(-1);
			this.DM.MarchEventTime[(int)b2].RequireTime = MP.ReadUInt(-1);
			this.DM.MarchEventData[(int)b2].Type = EMarchEventType.EMET_CampMarching;
			this.DM.MarchEventData[(int)b2].bRallyHost = 1;
			this.DM.SetQueueBarData(EQueueBarIndex.MarchingBegin + (int)b2, true, this.DM.MarchEventTime[(int)b2].BeginTime, this.DM.MarchEventTime[(int)b2].RequireTime);
			this.DM.MarchEventData[(int)b2].PointKind = (POINT_KIND)MP.ReadByte(-1);
			this.DM.MarchEventData[(int)b2].DesPointLevel = MP.ReadByte(-1);
			this.DM.MarchEventData[(int)b2].DesPlayerName = MP.ReadString(13, -1);
			for (int i = 0; i < 5; i++)
			{
				this.DM.MarchEventData[(int)b2].HeroID[i] = MP.ReadUShort(-1);
				if ((int)this.DM.MarchEventData[(int)b2].HeroID[i] < this.DM.TempFightHeroID.Length)
				{
					this.DM.TempFightHeroID[(int)this.DM.MarchEventData[(int)b2].HeroID[i]] = 1;
				}
			}
			ushort num = MP.ReadUShort(-1);
			for (int j = 0; j < 16; j++)
			{
				if ((num >> j & 1) == 1)
				{
					this.DM.MarchEventData[(int)b2].TroopData[j / 4][j % 4] = MP.ReadUInt(-1);
					this.DM.RoleAttr.m_Soldier[j] -= this.DM.MarchEventData[(int)b2].TroopData[j / 4][j % 4];
					this.DM.SoldierTotal -= (long)((ulong)this.DM.MarchEventData[(int)b2].TroopData[j / 4][j % 4]);
				}
			}
			this.DM.CancelShieldItemBuff();
			this.DM.CheckTroolCount();
			GameManager.OnRefresh(NetworkNews.Refresh_Hero, null);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_DevelopmentDetails, 2, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0, 0);
			this.m_Door = this.GetDoor();
			if (this.m_Door != null)
			{
				this.m_Door.m_GroundInfo.UpdateUI(0, 0);
			}
			this.DM.SetFightHeroData();
			if (this.m_Door != null)
			{
				if (this.m_Door.m_eMapMode == EUIOriginMapMode.OriginMap)
				{
					this.m_Door.CloseMenu(false);
				}
				else
				{
					DataManager.msgBuffer[0] = 81;
					GameConstants.GetBytes((ushort)b2, DataManager.msgBuffer, 1);
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
			}
			GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(9740u), 29, true);
			DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Inner, byte.MaxValue);
			DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Outer, b2);
		}
		else
		{
			switch (b)
			{
			case 1:
				this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(5715u), this.DM.mStringTable.GetStringByID(5716u), this.DM.mStringTable.GetStringByID(5717u), null, 0, 0, false, false, false, false, false);
				break;
			case 2:
				this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(4826u), this.DM.mStringTable.GetStringByID(9725u), this.DM.mStringTable.GetStringByID(4828u), null, 0, 0, false, false, false, false, false);
				break;
			case 3:
				this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(4829u), this.DM.mStringTable.GetStringByID(119u), null, null, 0, 0, false, false, false, false, false);
				break;
			case 5:
				this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(4826u), this.DM.mStringTable.GetStringByID(9724u), this.DM.mStringTable.GetStringByID(4828u), null, 0, 0, false, false, false, false, false);
				this.m_Door = this.GetDoor();
				if (this.m_Door != null)
				{
					this.m_Door.m_GroundInfo.Close();
				}
				break;
			}
		}
		GUIManager.Instance.HideUILock(EUILock.Ambush);
	}

	// Token: 0x06001071 RID: 4209 RVA: 0x001D555C File Offset: 0x001D375C
	public void RecvAmbushArrived(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b >= 8)
		{
			return;
		}
		this.DM.MarchEventData[(int)b].Point.zoneID = MP.ReadUShort(-1);
		this.DM.MarchEventData[(int)b].Point.pointID = MP.ReadByte(-1);
		this.DM.MarchEventData[(int)b].Type = EMarchEventType.EMET_Camp;
		this.DM.SetQueueBarData(EQueueBarIndex.MarchingBegin + (int)b, false, this.DM.MarchEventTime[(int)b].BeginTime, this.DM.MarchEventTime[(int)b].RequireTime);
		this.DM.CheckTroolCount();
		GameManager.OnRefresh(NetworkNews.Refresh_Hero, null);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_DevelopmentDetails, 2, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0, 0);
		this.m_Door = this.GetDoor();
		if (this.m_Door != null)
		{
			this.m_Door.m_GroundInfo.UpdateUI(0, 0);
		}
		this.DM.SetFightHeroData();
		GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(9741u), 29, true);
	}

	// Token: 0x06001072 RID: 4210 RVA: 0x001D569C File Offset: 0x001D389C
	public void SendAmbushReturn(byte TroopIndex)
	{
		if (GUIManager.Instance.ShowUILock(EUILock.Ambush))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_AMBUSH_RETURN;
			messagePacket.AddSeqId();
			messagePacket.Add(TroopIndex);
			messagePacket.Send(false);
		}
	}

	// Token: 0x06001073 RID: 4211 RVA: 0x001D56E8 File Offset: 0x001D38E8
	public void RecvAmbushReturn(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = MP.ReadByte(-1);
		if (b2 >= 8)
		{
			return;
		}
		this.DM.MarchEventData[(int)b2].Point.zoneID = MP.ReadUShort(-1);
		this.DM.MarchEventData[(int)b2].Point.pointID = MP.ReadByte(-1);
		this.DM.MarchEventTime[(int)b2].BeginTime = MP.ReadLong(-1);
		this.DM.MarchEventTime[(int)b2].RequireTime = MP.ReadUInt(-1);
		this.DM.MarchEventData[(int)b2].PointKind = POINT_KIND.PK_CITY;
		this.DM.MarchEventData[(int)b2].bRallyHost = 1;
		this.DM.SetQueueBarData(EQueueBarIndex.MarchingBegin + (int)b2, true, this.DM.MarchEventTime[(int)b2].BeginTime, this.DM.MarchEventTime[(int)b2].RequireTime);
		switch (b)
		{
		case 0:
			this.DM.MarchEventData[(int)b2].Type = EMarchEventType.EMET_CampReturn;
			break;
		case 1:
			this.DM.MarchEventData[(int)b2].Type = EMarchEventType.EMET_CampReturn;
			GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(9730u), 14, true);
			break;
		case 2:
			this.DM.MarchEventData[(int)b2].Type = EMarchEventType.EMET_CampRetreat;
			break;
		}
		GUIManager.Instance.HideUILock(EUILock.Ambush);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0, 0);
	}

	// Token: 0x06001074 RID: 4212 RVA: 0x001D58A4 File Offset: 0x001D3AA4
	public uint GetMaxTroop()
	{
		uint num = 0u;
		for (int i = 0; i < this.m_TroopData.Length; i++)
		{
			num += this.m_TroopData[i];
		}
		return num;
	}

	// Token: 0x06001075 RID: 4213 RVA: 0x001D58D8 File Offset: 0x001D3AD8
	public void ClearAmbushData()
	{
		this.m_AmbushPlayerName.ClearString();
		this.m_AmbushPlayerHead = 0;
		Array.Clear(this.m_HeroInfo, 0, this.m_HeroInfo.Length);
		this.m_TroopFlag = 0;
		Array.Clear(this.m_TroopData, 0, this.m_TroopData.Length);
	}

	// Token: 0x06001076 RID: 4214 RVA: 0x001D5928 File Offset: 0x001D3B28
	private Door GetDoor()
	{
		if (this.m_Door == null)
		{
			this.m_Door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		}
		return this.m_Door;
	}

	// Token: 0x040035D8 RID: 13784
	private static AmbushManager instance;

	// Token: 0x040035D9 RID: 13785
	private DataManager DM;

	// Token: 0x040035DA RID: 13786
	private GUIManager GM;

	// Token: 0x040035DB RID: 13787
	private Door m_Door;

	// Token: 0x040035DC RID: 13788
	public CString m_AmbushPlayerName;

	// Token: 0x040035DD RID: 13789
	public PointCode m_AmbushPlayerCapitalPos;

	// Token: 0x040035DE RID: 13790
	public ushort m_AmbushPlayerHead;

	// Token: 0x040035DF RID: 13791
	public TroopLeaderType[] m_HeroInfo;

	// Token: 0x040035E0 RID: 13792
	public ushort m_TroopFlag;

	// Token: 0x040035E1 RID: 13793
	public uint[] m_TroopData;

	// Token: 0x040035E2 RID: 13794
	public PointCode ObjPoint;

	// Token: 0x040035E3 RID: 13795
	public CString m_Str;
}
