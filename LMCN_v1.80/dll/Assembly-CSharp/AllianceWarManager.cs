using System;
using UnityEngine;

// Token: 0x02000025 RID: 37
public class AllianceWarManager
{
	// Token: 0x060000FA RID: 250 RVA: 0x00011488 File Offset: 0x0000F688
	public AllianceWarManager()
	{
		this.Initial();
	}

	// Token: 0x060000FB RID: 251 RVA: 0x000114C4 File Offset: 0x0000F6C4
	public void Initial()
	{
		if (this.RegisterData != null)
		{
			return;
		}
		this.RegisterData = new AllianceWarManager._RegisterData[100];
		this.WaitData = new AllianceWarManager._RegisterData[100];
		this.m_AllianceWarHintData.HeroData = new HeroDataType[5];
		this.m_AllianceWarHintData.Name = new CString(13);
		this.m_AllianceWarHintData.TroopData = new uint[16];
		for (int i = 0; i < 2; i++)
		{
			this.m_CombatPlayerData[i].HeroInfo = new HeroDataType[5];
			this.m_CombatPlayerData[i].SurviveTroop = new uint[16];
			this.m_CombatPlayerData[i].DeadTroop = new uint[16];
			this.m_CombatPlayerData[i].AttackAttr = new uint[4];
			this.m_CombatPlayerData[i].DefenceAttr = new uint[4];
			this.m_CombatPlayerData[i].HealthAttr = new uint[4];
		}
	}

	// Token: 0x060000FC RID: 252 RVA: 0x000115CC File Offset: 0x0000F7CC
	public byte GetRegisterCount()
	{
		return this.RegisterDataCount;
	}

	// Token: 0x060000FD RID: 253 RVA: 0x000115D4 File Offset: 0x0000F7D4
	public void InsertData(int index, ref AllianceWarManager._RegisterData Data)
	{
		int num = 0;
		AllianceWarManager._RegisterData[] data = this.GetData(index, ref num);
		if (this.RegisterDataCount < this.RegisterMaxCount)
		{
			int num2 = (int)this.RegisterDataCount - num;
			if (num2 > 0)
			{
				Array.Copy(data, num, data, num + 1, (int)this.RegisterDataCount - num);
			}
		}
		else if (index < (int)this.RegisterMaxCount)
		{
			AllianceWarManager._RegisterData registerData = data[(int)(this.RegisterMaxCount - 1)];
			int num2 = (int)this.RegisterMaxCount - num - 1;
			if (num2 > 0)
			{
				Array.Copy(data, num, data, num + 1, num2);
			}
			num2 = (int)(this.RegisterDataCount - this.RegisterMaxCount);
			if (num2 > 0)
			{
				Array.Copy(this.WaitData, 0, this.WaitData, 1, num2);
			}
			this.WaitData[0] = registerData;
		}
		else
		{
			int num2 = (int)(this.RegisterDataCount - this.RegisterMaxCount) - num;
			if (num2 > 0)
			{
				Array.Copy(data, num, data, num + 1, num2);
			}
		}
		data[num] = Data;
		this.RegisterDataCount += 1;
	}

	// Token: 0x060000FE RID: 254 RVA: 0x000116E8 File Offset: 0x0000F8E8
	private void MoveData(int index, int newIndex)
	{
		if (index == newIndex)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		AllianceWarManager._RegisterData[] data = this.GetData(index, ref num);
		AllianceWarManager._RegisterData[] data2 = this.GetData(newIndex, ref num2);
		if (data == data2)
		{
			AllianceWarManager._RegisterData registerData = data[num];
			if (index > newIndex)
			{
				Array.Copy(data, num2, data, num2 + 1, num - num2);
			}
			else
			{
				Array.Copy(data, num + 1, data, num, num2 - num);
			}
			data[num2] = registerData;
		}
		else if (index > newIndex)
		{
			AllianceWarManager._RegisterData registerData2 = data2[(int)(this.RegisterMaxCount - 1)];
			AllianceWarManager._RegisterData registerData = data[num];
			int num3 = (int)(this.RegisterMaxCount - 1) - num2;
			if (num3 > 0)
			{
				Array.Copy(data2, num2, data2, num2 + 1, num3);
			}
			data2[num2] = registerData;
			if (num > 0)
			{
				Array.Copy(data, 0, data, 1, num);
			}
			data[0] = registerData2;
		}
		else
		{
			AllianceWarManager._RegisterData registerData3 = data2[0];
			AllianceWarManager._RegisterData registerData = data[num];
			int num3 = (int)this.RegisterMaxCount - num - 1;
			if (num3 > 0)
			{
				Array.Copy(data, num + 1, data, num, num3);
			}
			data[(int)(this.RegisterMaxCount - 1)] = registerData3;
			if (num2 > 0)
			{
				Array.Copy(data2, 1, data2, 0, num2);
			}
			data2[num2] = registerData;
		}
	}

	// Token: 0x060000FF RID: 255 RVA: 0x00011854 File Offset: 0x0000FA54
	private AllianceWarManager._RegisterData[] GetData(int index, ref int arrayIdx)
	{
		if ((int)this.RegisterMaxCount > index)
		{
			arrayIdx = index;
			if (arrayIdx >= this.RegisterData.Length)
			{
				arrayIdx = 0;
			}
			return this.RegisterData;
		}
		arrayIdx = index - (int)this.RegisterMaxCount;
		if (arrayIdx >= this.WaitData.Length)
		{
			arrayIdx = 0;
		}
		return this.WaitData;
	}

	// Token: 0x06000100 RID: 256 RVA: 0x000118AC File Offset: 0x0000FAAC
	public void Clear()
	{
		for (int i = 0; i < this.RegisterData.Length; i++)
		{
			if (this.RegisterData[i].Name == null)
			{
				break;
			}
			this.RegisterData[i].Clear();
		}
		for (int j = 0; j < this.WaitData.Length; j++)
		{
			if (this.WaitData[j].Name == null)
			{
				break;
			}
			this.WaitData[j].Clear();
		}
		this.RegisterDataCount = 0;
	}

	// Token: 0x06000101 RID: 257 RVA: 0x00011954 File Offset: 0x0000FB54
	public byte GetRegisterMaxCount()
	{
		return this.RegisterMaxCount;
	}

	// Token: 0x06000102 RID: 258 RVA: 0x0001195C File Offset: 0x0000FB5C
	public void SetRegisterMaxCount(byte memberCount)
	{
		this.RegisterMaxCount = memberCount;
	}

	// Token: 0x06000103 RID: 259 RVA: 0x00011968 File Offset: 0x0000FB68
	public void SendAllianceWarList()
	{
		this.RecvCount = 0;
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.AddSeqId();
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_MEMBERLIST;
		messagePacket.Send(false);
		this.SetRegisterMaxCount(ActivityManager.Instance.AW_MemberCount);
	}

	// Token: 0x06000104 RID: 260 RVA: 0x000119B0 File Offset: 0x0000FBB0
	public void RecvAllianceWarMemberListBegin(MessagePacket MP)
	{
		this.MyRank = MP.ReadByte(-1);
		this.RegisterDataCount = MP.ReadByte(-1);
		if (this.RegisterDataCount > 100)
		{
			this.RegisterDataCount = 100;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarRegister, 1, (int)this.RegisterDataCount);
		if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_Replay)
		{
			LeaderBoardManager.Instance.AllianceWarAlliBoardUpdateTime = DataManager.Instance.ServerTime + 180L;
			LeaderBoardManager.Instance.MobiGroupAllianceID = DataManager.Instance.RoleAlliance.Id;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_AlliVSAlliBoard, 0, 0);
		}
	}

	// Token: 0x06000105 RID: 261 RVA: 0x00011A58 File Offset: 0x0000FC58
	public void RecvAllianceWarMemberList(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		int num = 0;
		for (byte b2 = 0; b2 < b; b2 += 1)
		{
			if (this.RecvCount == 100)
			{
				break;
			}
			AllianceWarManager._RegisterData[] data = this.GetData((int)this.RecvCount, ref num);
			if (num >= data.Length)
			{
				break;
			}
			data[num].Initial();
			MP.ReadStringPlus(13, data[num].Name, -1);
			data[num].Power = MP.ReadULong(-1);
			this.RecvCount += 1;
		}
	}

	// Token: 0x06000106 RID: 262 RVA: 0x00011AFC File Offset: 0x0000FCFC
	public void RecvUpdateAllianceWarMemberList(MessagePacket MP)
	{
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarRegister) == null)
		{
			return;
		}
		byte b = MP.ReadByte(-1);
		byte b2 = MP.ReadByte(-1);
		if (b == 0 || b2 == 0 || b > 100 || b2 > 100)
		{
			this.SendAllianceWarList();
			return;
		}
		if (this.MyRank > 0)
		{
			if (b == this.MyRank)
			{
				this.MyRank = b2;
			}
			else if (b > b2)
			{
				if (b > this.MyRank && b2 <= this.MyRank)
				{
					this.MyRank += 1;
				}
			}
			else if (b < b2 && b2 >= this.MyRank && b < this.MyRank)
			{
				this.MyRank -= 1;
			}
		}
		b -= 1;
		b2 -= 1;
		int num = 0;
		AllianceWarManager._RegisterData[] data = this.GetData((int)b, ref num);
		if (data[num].Name == null)
		{
			return;
		}
		MP.ReadStringPlus(13, data[num].Name, -1);
		data[num].Power = MP.ReadULong(-1);
		if (b != b2)
		{
			this.MoveData((int)b, (int)b2);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarRegister, 2, 0);
	}

	// Token: 0x06000107 RID: 263 RVA: 0x00011C4C File Offset: 0x0000FE4C
	public void RecvInsertAllianceWarMemberList(MessagePacket MP)
	{
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarRegister) == null)
		{
			return;
		}
		byte b = MP.ReadByte(-1);
		if (b == 0 || b >= 100)
		{
			this.SendAllianceWarList();
			return;
		}
		if (this.MyRank > 0 && this.MyRank >= b)
		{
			this.MyRank += 1;
		}
		b -= 1;
		AllianceWarManager._RegisterData registerData = default(AllianceWarManager._RegisterData);
		registerData.Initial();
		MP.ReadStringPlus(13, registerData.Name, -1);
		registerData.Power = MP.ReadULong(-1);
		if (this.RegisterDataCount < 100)
		{
			this.InsertData((int)b, ref registerData);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarRegister, 1, (int)this.RegisterDataCount);
		}
		else
		{
			registerData.Clear();
		}
	}

	// Token: 0x06000108 RID: 264 RVA: 0x00011D24 File Offset: 0x0000FF24
	public ulong GetEnrollPower()
	{
		if (this.RegisterDataCount == 0)
		{
			return 0UL;
		}
		if (this.RegisterDataCount < this.RegisterMaxCount)
		{
			return this.RegisterData[(int)(this.RegisterDataCount - 1)].Power;
		}
		if (this.RegisterMaxCount > 0)
		{
			return this.RegisterData[(int)(this.RegisterMaxCount - 1)].Power;
		}
		return this.RegisterData[(int)this.RegisterMaxCount].Power;
	}

	// Token: 0x06000109 RID: 265 RVA: 0x00011DA4 File Offset: 0x0000FFA4
	public AllianceWarManager._RegisterData GetDataIndex(int index)
	{
		int num = 0;
		if (index < 0 || (int)this.RegisterDataCount <= index)
		{
			AllianceWarManager._RegisterData[] data = this.GetData(0, ref num);
			data[num].Initial();
			return data[num];
		}
		if ((int)this.RegisterMaxCount <= index)
		{
			return this.GetData(index, ref num)[num];
		}
		if (this.RegisterDataCount < this.RegisterMaxCount)
		{
			return this.GetData(index, ref num)[(int)this.RegisterDataCount - num - 1];
		}
		return this.GetData(index, ref num)[(int)this.RegisterMaxCount - num - 1];
	}

	// Token: 0x0600010A RID: 266 RVA: 0x00011E58 File Offset: 0x00010058
	public AllianceWarManager._RegisterData GetMyDataIdx(int index)
	{
		if (index <= 0)
		{
			return default(AllianceWarManager._RegisterData);
		}
		int num = 0;
		return this.GetData(index - 1, ref num)[num];
	}

	// Token: 0x0600010B RID: 267 RVA: 0x00011E90 File Offset: 0x00010090
	public int getMyRankIndex()
	{
		if (this.MyRank <= 0)
		{
			return -1;
		}
		if (this.RegisterDataCount < this.RegisterMaxCount)
		{
			return (int)(this.RegisterDataCount - this.MyRank + 1);
		}
		if (this.RegisterMaxCount > this.MyRank - 1)
		{
			return (int)(this.RegisterMaxCount - this.MyRank + 1);
		}
		return (int)this.MyRank;
	}

	// Token: 0x0600010C RID: 268 RVA: 0x00011EF8 File Offset: 0x000100F8
	public void FormatRank(int index, ref CString Str)
	{
		Str.ClearString();
		int num = 0;
		AllianceWarManager._RegisterData[] data = this.GetData(index, ref num);
		if (this.RegisterData == data)
		{
			Str.IntToFormat((long)(num + 1), 1, false);
			Str.AppendFormat("{0}");
		}
		else
		{
			Str.StringToFormat("~");
			Str.IntToFormat((long)(num + 1), 1, false);
			Str.AppendFormat("{0}{1}");
		}
	}

	// Token: 0x0600010D RID: 269 RVA: 0x00011F6C File Offset: 0x0001016C
	public void Recv_MSG_RESP_SIGNUP_ALLIANCEWAR(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Expedition);
		GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Expedition);
		ERESP_SIGNUP_ALLIANCEWAR_RESULT eresp_SIGNUP_ALLIANCEWAR_RESULT = (ERESP_SIGNUP_ALLIANCEWAR_RESULT)MP.ReadByte(-1);
		if (eresp_SIGNUP_ALLIANCEWAR_RESULT == ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_SUCCESS)
		{
			byte myRank = MP.ReadByte(-1);
			ActivityManager.Instance.AW_SignUpAllianceID = DataManager.Instance.RoleAlliance.Id;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Expedition, 2, 0);
			if (this.MyRank > 0)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17006u), 255, true);
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17018u), 255, true);
				FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_GUILD_SHOWDOWN_REGISTRATION);
			}
			this.MyRank = myRank;
		}
		else
		{
			switch (eresp_SIGNUP_ALLIANCEWAR_RESULT)
			{
			case ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_TROOPERR:
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7226u), 255, true);
				break;
			case ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_LATE:
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17035u), 255, true);
				break;
			case ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_OTHERALLY:
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17010u), 255, true);
				break;
			case ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_NOALLY:
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17020u), 255, true);
				break;
			case ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_STRONGHOLD:
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17037u), 255, true);
				break;
			case ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_FULL:
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17011u), 255, true);
				break;
			case ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_UNKNOWNERR:
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9771u), 255, true);
				break;
			}
		}
	}

	// Token: 0x0600010E RID: 270 RVA: 0x0001218C File Offset: 0x0001038C
	public void Recv_MSG_RESP_ALLIANCEWAR_REPLAY_FAILED(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Activity);
		this.MyFinalGame = MP.ReadByte(-1);
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			ActivityManager.Instance.AllianceWarReopenCheck();
			if (this.MyFinalGame < 1 || this.MyFinalGame > 4)
			{
				door.OpenMenu(EGUIWindow.UI_AllianceWarBattle, 0, 0, true);
			}
			else
			{
				ActivityManager.Instance.AW_bcalculateEnd = true;
				door.OpenMenu(EGUIWindow.UI_AllianceWarOver, 0, 0, false);
			}
		}
		if (this.MyFinalGame < 1 || this.MyFinalGame > 4)
		{
			Debug.LogError("ErrCode " + this.MyFinalGame);
		}
	}

	// Token: 0x0600010F RID: 271 RVA: 0x00012254 File Offset: 0x00010454
	public void Send_MSG_REQUEST_ALLIANCEWAR_MEMBER_DATA(byte Position)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_MEMBER_DATA;
		messagePacket.AddSeqId();
		messagePacket.Add(Position);
		messagePacket.Send(false);
		int num = 0;
		this.m_AllianceWarHintData.Name.ClearString();
		this.m_AllianceWarHintData.Name.Append(this.GetData((int)(Position - 1), ref num)[num].Name);
		this.m_AllianceWarHintData.AllianceTagTag = DataManager.Instance.RoleAlliance.Tag.ToString();
		Array.Clear(this.m_AllianceWarHintData.HeroData, 0, this.m_AllianceWarHintData.HeroData.Length);
		Array.Clear(this.m_AllianceWarHintData.TroopData, 0, this.m_AllianceWarHintData.TroopData.Length);
	}

	// Token: 0x06000110 RID: 272 RVA: 0x00012320 File Offset: 0x00010520
	public void Recv_MSG_RESP_ALLIANCEWAR_MEMBER_DATA(MessagePacket MP)
	{
		this.m_AllianceWarHintData.bMain = false;
		this.m_AllianceWarHintData.Head = MP.ReadUShort(-1);
		for (int i = 0; i < 5; i++)
		{
			this.m_AllianceWarHintData.HeroData[i].ID = MP.ReadUShort(-1);
			this.m_AllianceWarHintData.HeroData[i].Rank = MP.ReadByte(-1);
			this.m_AllianceWarHintData.HeroData[i].Star = MP.ReadByte(-1);
		}
		if (this.m_AllianceWarHintData.HeroData[0].ID != 0)
		{
			this.m_AllianceWarHintData.bMain = (this.m_AllianceWarHintData.Head == this.m_AllianceWarHintData.HeroData[0].ID);
		}
		else
		{
			this.m_AllianceWarHintData.bMain = false;
		}
		for (int j = 0; j < 16; j++)
		{
			this.m_AllianceWarHintData.TroopData[j] = MP.ReadUInt(-1);
		}
		this.m_AllianceWarHintData.ArmyCoordIndex = MP.ReadByte(-1);
		this.m_AllianceWarHintData.ArmyCoordIndex = (byte)Mathf.Clamp((int)this.m_AllianceWarHintData.ArmyCoordIndex, 0, 5);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarRegister, 4, 0);
	}

	// Token: 0x06000111 RID: 273 RVA: 0x00012480 File Offset: 0x00010680
	public void Send_MSG_REQUEST_ALLIANCEWAR_MATCH_PLAYERDATA(byte MatchID, byte Side, byte Position)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_MATCH_PLAYERDATA;
		messagePacket.AddSeqId();
		messagePacket.Add(MatchID);
		messagePacket.Add(Side);
		messagePacket.Add(Position);
		messagePacket.Send(false);
		Array.Clear(this.m_AllianceWarHintData.HeroData, 0, this.m_AllianceWarHintData.HeroData.Length);
		Array.Clear(this.m_AllianceWarHintData.TroopData, 0, this.m_AllianceWarHintData.TroopData.Length);
	}

	// Token: 0x06000112 RID: 274 RVA: 0x00012504 File Offset: 0x00010704
	public void Recv_MSG_RESP_ALLIANCEWAR_MATCH_PLAYERDATA(MessagePacket MP)
	{
		this.m_AllianceWarHintData.bMain = false;
		this.m_AllianceWarHintData.Head = MP.ReadUShort(-1);
		for (int i = 0; i < 5; i++)
		{
			this.m_AllianceWarHintData.HeroData[i].ID = MP.ReadUShort(-1);
			this.m_AllianceWarHintData.HeroData[i].Rank = MP.ReadByte(-1);
			this.m_AllianceWarHintData.HeroData[i].Star = MP.ReadByte(-1);
		}
		this.m_AllianceWarHintData.bMain = (this.m_AllianceWarHintData.Head == this.m_AllianceWarHintData.HeroData[0].ID);
		for (int j = 0; j < 16; j++)
		{
			this.m_AllianceWarHintData.TroopData[j] = MP.ReadUInt(-1);
		}
		this.m_AllianceWarHintData.ArmyCoordIndex = MP.ReadByte(-1);
		this.m_AllianceWarHintData.ArmyCoordIndex = (byte)Mathf.Clamp((int)this.m_AllianceWarHintData.ArmyCoordIndex, 0, 5);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarBattle, 10, 0);
	}

	// Token: 0x06000113 RID: 275 RVA: 0x0001263C File Offset: 0x0001083C
	public void Send_MSG_REQUEST_ALLIANCEWAR_COMBAT_REPORT(byte MatchID, byte CombatID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_COMBAT_REPORT;
		messagePacket.AddSeqId();
		messagePacket.Add(MatchID);
		messagePacket.Add(CombatID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.AllianceWar_Fs);
	}

	// Token: 0x06000114 RID: 276 RVA: 0x00012688 File Offset: 0x00010888
	public void Recv_MSG_RESP_ALLIANCEWAR_COMBAT_REPORT(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.AllianceWar_Fs);
		this.mReportRandSeed = MP.ReadUShort(-1);
		this.mReportRandGap = MP.ReadByte(-1);
		this.mReportResult = MP.ReadByte(-1);
		for (int i = 0; i < 2; i++)
		{
			this.m_CombatPlayerData[i].Name = MP.ReadString(13, -1);
			this.m_CombatPlayerData[i].KingdomID = MP.ReadUShort(-1);
			this.m_CombatPlayerData[i].StrongholdLevel = MP.ReadByte(-1);
			this.m_CombatPlayerData[i].Level = MP.ReadByte(-1);
			this.m_CombatPlayerData[i].Head = MP.ReadUShort(-1);
			this.m_CombatPlayerData[i].VIPLevel = MP.ReadByte(-1);
			this.m_CombatPlayerData[i].AllianceRank = MP.ReadByte(-1);
			for (int j = 0; j < 5; j++)
			{
				this.m_CombatPlayerData[i].HeroInfo[j].ID = MP.ReadUShort(-1);
				this.m_CombatPlayerData[i].HeroInfo[j].Rank = MP.ReadByte(-1);
				this.m_CombatPlayerData[i].HeroInfo[j].Star = MP.ReadByte(-1);
			}
			if (this.m_CombatPlayerData[i].HeroInfo[0].ID != 0)
			{
				this.m_CombatPlayerData[i].bMain = (this.m_CombatPlayerData[i].Head == this.m_CombatPlayerData[i].HeroInfo[0].ID);
			}
			else
			{
				this.m_CombatPlayerData[i].bMain = false;
			}
			this.m_CombatPlayerData[i].LosePower = MP.ReadULong(-1);
			for (int k = 0; k < 16; k++)
			{
				this.m_CombatPlayerData[i].SurviveTroop[k] = MP.ReadUInt(-1);
			}
			for (int l = 0; l < 16; l++)
			{
				this.m_CombatPlayerData[i].DeadTroop[l] = MP.ReadUInt(-1);
			}
			for (int m = 0; m < 4; m++)
			{
				this.m_CombatPlayerData[i].AttackAttr[m] = MP.ReadUInt(-1);
			}
			for (int n = 0; n < 4; n++)
			{
				this.m_CombatPlayerData[i].DefenceAttr[n] = MP.ReadUInt(-1);
			}
			for (int num = 0; num < 4; num++)
			{
				this.m_CombatPlayerData[i].HealthAttr[num] = MP.ReadUInt(-1);
			}
			this.m_CombatPlayerData[i].ArmyCoordIndex = MP.ReadByte(-1);
			this.m_CombatPlayerData[i].ArmyCoordIndex = (byte)Mathf.Clamp((int)this.m_CombatPlayerData[i].ArmyCoordIndex, 0, 5);
		}
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.OpenMenu(EGUIWindow.UI_Alliance_FS, 0, 0, false);
		}
	}

	// Token: 0x0400022B RID: 555
	public const byte MemberCountMax = 100;

	// Token: 0x0400022C RID: 556
	public AllianceWarManager._RegisterData[] RegisterData;

	// Token: 0x0400022D RID: 557
	public AllianceWarManager._RegisterData[] WaitData;

	// Token: 0x0400022E RID: 558
	private byte RegisterDataCount;

	// Token: 0x0400022F RID: 559
	private byte RecvCount;

	// Token: 0x04000230 RID: 560
	public bool bReplaying;

	// Token: 0x04000231 RID: 561
	public byte ReplayGame;

	// Token: 0x04000232 RID: 562
	public byte MyPosition;

	// Token: 0x04000233 RID: 563
	public byte MyAllySide;

	// Token: 0x04000234 RID: 564
	public byte MyFinalGame;

	// Token: 0x04000235 RID: 565
	public byte MyRank;

	// Token: 0x04000236 RID: 566
	public byte UpdateSort;

	// Token: 0x04000237 RID: 567
	private byte RegisterMaxCount = 80;

	// Token: 0x04000238 RID: 568
	public AllianceWartHintDataType m_AllianceWarHintData = default(AllianceWartHintDataType);

	// Token: 0x04000239 RID: 569
	public CombatPlayerData[] m_CombatPlayerData = new CombatPlayerData[2];

	// Token: 0x0400023A RID: 570
	public ushort mReportRandSeed;

	// Token: 0x0400023B RID: 571
	public byte mReportRandGap;

	// Token: 0x0400023C RID: 572
	public byte mReportResult;

	// Token: 0x02000026 RID: 38
	public struct _RegisterData
	{
		// Token: 0x06000115 RID: 277 RVA: 0x000129F8 File Offset: 0x00010BF8
		public void Initial()
		{
			if (this.Name == null)
			{
				this.Name = StringManager.Instance.SpawnString(30);
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00012A18 File Offset: 0x00010C18
		public void Clear()
		{
			StringManager.Instance.DeSpawnString(this.Name);
			this.Name = null;
		}

		// Token: 0x0400023D RID: 573
		public CString Name;

		// Token: 0x0400023E RID: 574
		public ushort Head;

		// Token: 0x0400023F RID: 575
		public ulong Power;
	}
}
