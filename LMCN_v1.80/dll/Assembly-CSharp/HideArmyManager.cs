using System;

// Token: 0x02000373 RID: 883
internal class HideArmyManager
{
	// Token: 0x1700008B RID: 139
	// (get) Token: 0x0600126C RID: 4716 RVA: 0x00208DF4 File Offset: 0x00206FF4
	public static HideArmyManager Instance
	{
		get
		{
			if (HideArmyManager.instance == null)
			{
				HideArmyManager.instance = new HideArmyManager();
			}
			return HideArmyManager.instance;
		}
	}

	// Token: 0x0600126D RID: 4717 RVA: 0x00208E10 File Offset: 0x00207010
	public bool IsHideArmy()
	{
		return this.ShelterTime.BeginTime != 0L;
	}

	// Token: 0x0600126E RID: 4718 RVA: 0x00208E24 File Offset: 0x00207024
	public void OpenHideArmyUI()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			if (!this.IsHideArmy())
			{
				door.m_GroundInfo.OpenAttackPanel(true, true);
			}
			else
			{
				door.OpenMenu(EGUIWindow.UI_ArmyInfo, 1, 0, false);
			}
		}
	}

	// Token: 0x0600126F RID: 4719 RVA: 0x00208E78 File Offset: 0x00207078
	public uint[] GetHideTroopData()
	{
		return this.TroopData;
	}

	// Token: 0x06001270 RID: 4720 RVA: 0x00208E80 File Offset: 0x00207080
	public bool IsLordInShelter()
	{
		return this.LordInShelter == 1;
	}

	// Token: 0x06001271 RID: 4721 RVA: 0x00208E8C File Offset: 0x0020708C
	public TimeEventDataType GetShelterTime()
	{
		return this.ShelterTime;
	}

	// Token: 0x06001272 RID: 4722 RVA: 0x00208E94 File Offset: 0x00207094
	public long GetTotalHideArmy()
	{
		long num = 0L;
		for (int i = 0; i < this.TroopData.Length; i++)
		{
			num += (long)((ulong)this.TroopData[i]);
		}
		return num;
	}

	// Token: 0x06001273 RID: 4723 RVA: 0x00208ECC File Offset: 0x002070CC
	public void SendHideTroopInshelter(byte HideLord, byte TimeIndex, ref uint[] _TroopData)
	{
		byte[] array = new byte[64];
		ushort num = 0;
		int num2 = 1;
		int num3 = 0;
		if (GUIManager.Instance.ShowUILock(EUILock.HideArmy))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_HIDETROOPINSHELTER;
			messagePacket.AddSeqId();
			messagePacket.Add(HideLord);
			messagePacket.Add(TimeIndex);
			int num4 = 0;
			while (num4 < _TroopData.Length && num4 < this.TroopData.Length)
			{
				this.LordInShelter = HideLord;
				this.TroopData[num4] = _TroopData[num4];
				if (_TroopData[num4] != 0u)
				{
					num |= (ushort)(num2 << num4);
					GameConstants.GetBytes(_TroopData[num4], array, num3);
					num3 += 4;
				}
				num4++;
			}
			messagePacket.Add(num);
			messagePacket.Add(array, 0, 0);
			messagePacket.Send(false);
		}
	}

	// Token: 0x06001274 RID: 4724 RVA: 0x00208FA8 File Offset: 0x002071A8
	public void SendReleaseShelterTroop()
	{
		if (GUIManager.Instance.ShowUILock(EUILock.HideArmy))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_RELEASESHELTERTROOP;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
		}
	}

	// Token: 0x06001275 RID: 4725 RVA: 0x00208FEC File Offset: 0x002071EC
	public void RecvShelterData(MessagePacket MP)
	{
		this.LordID = MP.ReadUShort(-1);
		if (this.LordID != 0)
		{
			this.LordInShelter = 1;
		}
		else
		{
			this.LordInShelter = 0;
		}
		this.ShelterTime.BeginTime = MP.ReadLong(-1);
		this.ShelterTime.RequireTime = MP.ReadUInt(-1);
		ushort num = MP.ReadUShort(-1);
		Array.Clear(this.TroopData, 0, this.TroopData.Length);
		for (int i = 0; i < 16; i++)
		{
			if ((num >> i & 1) == 1)
			{
				this.TroopData[i] = MP.ReadUInt(-1);
			}
		}
		if (this.LordInShelter == 1)
		{
			if (this.LordID != 0 && (int)this.LordID < DataManager.Instance.TempFightHeroID.Length)
			{
				DataManager.Instance.TempFightHeroID[(int)this.LordID] = 1;
			}
			DataManager.Instance.SetFightHeroData();
			GameManager.OnRefresh(NetworkNews.Refresh_Hero, null);
		}
		if (this.ShelterTime.BeginTime > 0L)
		{
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.HideArmy, true, this.ShelterTime.BeginTime, this.ShelterTime.RequireTime);
		}
		else
		{
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.HideArmy, false, 0L, 0u);
		}
		DataManager.Instance.SetRecvQueueBarData(31);
		DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Hide, byte.MaxValue);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 2, 0);
	}

	// Token: 0x06001276 RID: 4726 RVA: 0x00209160 File Offset: 0x00207360
	public void RecvHideTroopInshelter(MessagePacket MP)
	{
		HideArmyManager.HIDETROOP_RESULT hidetroop_RESULT = (HideArmyManager.HIDETROOP_RESULT)MP.ReadByte(-1);
		if (hidetroop_RESULT == HideArmyManager.HIDETROOP_RESULT.HIDETROOP_SUCCESS)
		{
			this.ShelterTime.BeginTime = MP.ReadLong(-1);
			this.ShelterTime.RequireTime = MP.ReadUInt(-1);
			for (int i = 0; i < 16; i++)
			{
				DataManager.Instance.RoleAttr.m_Soldier[i] -= this.TroopData[i];
				DataManager.Instance.SoldierTotal -= (long)((ulong)this.TroopData[i]);
			}
			DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Hide, byte.MaxValue);
			DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Inner, byte.MaxValue);
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8589u), 13, true);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Expedition, 2, 0);
			if (this.LordInShelter == 1)
			{
				ushort leaderID = DataManager.Instance.GetLeaderID();
				if (leaderID != 0 && (int)leaderID < DataManager.Instance.TempFightHeroID.Length)
				{
					DataManager.Instance.TempFightHeroID[(int)leaderID] = 1;
				}
				DataManager.Instance.SetFightHeroData();
				GameManager.OnRefresh(NetworkNews.Refresh_Hero, null);
			}
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.HideArmy, true, this.ShelterTime.BeginTime, this.ShelterTime.RequireTime);
		}
		else
		{
			this.LordInShelter = 0;
			Array.Clear(this.TroopData, 0, this.TroopData.Length);
			this.ShowHideTroopResultMsg(hidetroop_RESULT);
		}
		GUIManager.Instance.HideUILock(EUILock.HideArmy);
	}

	// Token: 0x06001277 RID: 4727 RVA: 0x002092EC File Offset: 0x002074EC
	public void RecvReleaseShelterTroop(MessagePacket MP)
	{
		HideArmyManager.HIDETROOP_RESULT hidetroop_RESULT = (HideArmyManager.HIDETROOP_RESULT)MP.ReadByte(-1);
		if (hidetroop_RESULT == HideArmyManager.HIDETROOP_RESULT.HIDETROOP_SUCCESS)
		{
			this.ShelterTime.BeginTime = 0L;
			this.ShelterTime.RequireTime = 0u;
			for (int i = 0; i < 16; i++)
			{
				DataManager.Instance.RoleAttr.m_Soldier[i] += this.TroopData[i];
				DataManager.Instance.SoldierTotal += (long)((ulong)this.TroopData[i]);
			}
			DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Hide, 0);
			DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Inner, byte.MaxValue);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 1, 0);
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8592u), 13, true);
			if (this.LordInShelter == 1)
			{
				this.LordInShelter = 0;
				ushort leaderID = DataManager.Instance.GetLeaderID();
				if (leaderID != 0 && (int)leaderID < DataManager.Instance.TempFightHeroID.Length)
				{
					DataManager.Instance.TempFightHeroID[(int)leaderID] = 0;
				}
				DataManager.Instance.SetFightHeroData();
				GameManager.OnRefresh(NetworkNews.Refresh_Hero, null);
			}
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.HideArmy, false, 0L, 0u);
			Array.Clear(this.TroopData, 0, this.TroopData.Length);
		}
		else
		{
			this.ShowHideTroopResultMsg(hidetroop_RESULT);
		}
		GUIManager.Instance.HideUILock(EUILock.HideArmy);
	}

	// Token: 0x06001278 RID: 4728 RVA: 0x00209458 File Offset: 0x00207658
	public void RecvShelterTimesUp()
	{
		this.ShelterTime.BeginTime = 0L;
		this.ShelterTime.RequireTime = 0u;
		if (this.LordInShelter == 1)
		{
			this.LordInShelter = 0;
			ushort leaderID = DataManager.Instance.GetLeaderID();
			if (leaderID != 0 && (int)leaderID < DataManager.Instance.TempFightHeroID.Length)
			{
				DataManager.Instance.TempFightHeroID[(int)leaderID] = 0;
			}
			DataManager.Instance.SetFightHeroData();
			GameManager.OnRefresh(NetworkNews.Refresh_Hero, null);
		}
		DataManager.Instance.SetQueueBarData(EQueueBarIndex.HideArmy, false, 0L, 0u);
		for (int i = 0; i < 16; i++)
		{
			DataManager.Instance.RoleAttr.m_Soldier[i] += this.TroopData[i];
			DataManager.Instance.SoldierTotal += (long)((ulong)this.TroopData[i]);
		}
		GameManager.OnRefresh(NetworkNews.Refresh_Soldier, null);
		Array.Clear(this.TroopData, 0, this.TroopData.Length);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_DevelopmentDetails, 6, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 1, 0);
		GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8592u), 13, true);
		DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Hide, 0);
		DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Inner, byte.MaxValue);
	}

	// Token: 0x06001279 RID: 4729 RVA: 0x002095B4 File Offset: 0x002077B4
	private void ShowHideTroopResultMsg(HideArmyManager.HIDETROOP_RESULT Result)
	{
		switch (Result)
		{
		case HideArmyManager.HIDETROOP_RESULT.HIDETROOP_NOTEMPTY:
		case HideArmyManager.HIDETROOP_RESULT.HIDETROOP_LORDERR:
		case HideArmyManager.HIDETROOP_RESULT.HIDETROOP_TIMEERR:
			GUIManager.Instance.MsgStr.ClearString();
			GUIManager.Instance.MsgStr.IntToFormat((long)Result, 1, false);
			GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12067u));
			GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), 255, true);
			break;
		case HideArmyManager.HIDETROOP_RESULT.HIDETROOP_TROOPERR:
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9769u), 255, true);
			break;
		}
	}

	// Token: 0x040039BD RID: 14781
	private const int TroopDataMax = 16;

	// Token: 0x040039BE RID: 14782
	private static HideArmyManager instance;

	// Token: 0x040039BF RID: 14783
	private uint[] TroopData = new uint[16];

	// Token: 0x040039C0 RID: 14784
	private TimeEventDataType ShelterTime;

	// Token: 0x040039C1 RID: 14785
	private byte LordInShelter;

	// Token: 0x040039C2 RID: 14786
	private ushort LordID;

	// Token: 0x02000374 RID: 884
	private enum HIDETROOP_RESULT : byte
	{
		// Token: 0x040039C4 RID: 14788
		HIDETROOP_SUCCESS,
		// Token: 0x040039C5 RID: 14789
		HIDETROOP_NOTEMPTY,
		// Token: 0x040039C6 RID: 14790
		HIDETROOP_LORDERR,
		// Token: 0x040039C7 RID: 14791
		HIDETROOP_TROOPERR,
		// Token: 0x040039C8 RID: 14792
		HIDETROOP_TIMEERR
	}
}
