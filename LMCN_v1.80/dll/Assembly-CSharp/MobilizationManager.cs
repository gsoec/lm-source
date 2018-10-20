using System;
using UnityEngine;

// Token: 0x020002B6 RID: 694
public class MobilizationManager
{
	// Token: 0x06000DEA RID: 3562 RVA: 0x00163694 File Offset: 0x00161894
	private MobilizationManager()
	{
		this.InitRewardsSelect();
	}

	// Token: 0x1700007A RID: 122
	// (get) Token: 0x06000DEB RID: 3563 RVA: 0x001636F4 File Offset: 0x001618F4
	public static MobilizationManager Instance
	{
		get
		{
			if (MobilizationManager.instance == null)
			{
				MobilizationManager.instance = new MobilizationManager();
			}
			return MobilizationManager.instance;
		}
	}

	// Token: 0x1700007B RID: 123
	// (get) Token: 0x06000DEC RID: 3564 RVA: 0x00163710 File Offset: 0x00161910
	public byte[] DegreeRanges
	{
		get
		{
			if (this._DegreeRanges == null)
			{
				int tableCount = DataManager.Instance.AllianceMobilizationDegreeRange.TableCount;
				this._DegreeRanges = new byte[tableCount + 1];
				for (int i = 0; i < tableCount; i++)
				{
					this._DegreeRanges[i + 1] = DataManager.Instance.AllianceMobilizationDegreeRange.GetRecordByIndex(i).Range;
				}
			}
			return this._DegreeRanges;
		}
	}

	// Token: 0x06000DED RID: 3565 RVA: 0x00163780 File Offset: 0x00161980
	public void Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DATA()
	{
		GUIManager.Instance.ShowUILock(EUILock.AllianceMobilization);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DATA;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06000DEE RID: 3566 RVA: 0x001637C0 File Offset: 0x001619C0
	public void Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_DATA(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.AllianceMobilization);
		this.availableMission = MP.ReadByte(-1);
		this.extraMission = MP.ReadByte(-1);
		this.involvedMember = MP.ReadByte(-1);
		this.AllianceError = MP.ReadByte(-1);
		if (this.mMissionID != 0 && this.AllianceError != 0)
		{
			this.mMissionID = 0;
			this.mMissionStatus = 0;
			ActivityManager.Instance.CheckAMShowHint();
		}
		Array.Clear(this.mMobilizationMission, 0, this.mMobilizationMission.Length);
		for (int i = 1; i < 21; i++)
		{
			this.mMobilizationMission[i].MissionType = MP.ReadUShort(-1);
			if (this.mMobilizationMission[i].MissionType == 1001)
			{
				this.mMobilizationMission[i].CDTime = MP.ReadLong(-1);
			}
			else
			{
				this.mMobilizationMission[i].Difficulty = MP.ReadByte(-1);
				this.mMobilizationMission[i].Difficulty = (byte)Mathf.Clamp((int)this.mMobilizationMission[i].Difficulty, 0, 3);
				for (int j = 0; j < 7; j++)
				{
					MP.ReadByte(-1);
				}
			}
		}
		this.mMoreRewards = MP.ReadByte(-1);
		this.mextraMissionBuyLimit = MP.ReadByte(-1);
		this.mextraMissionPrize = MP.ReadUShort(-1);
		this.mMobilizationFutureRank = MP.ReadByte(-1);
		this.mMobilizationFutureRank = (byte)Mathf.Clamp((int)this.mMobilizationFutureRank, 0, 5);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 0, 0);
	}

	// Token: 0x06000DEF RID: 3567 RVA: 0x00163968 File Offset: 0x00161B68
	public void Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_REFLASH()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_REFLASH;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06000DF0 RID: 3568 RVA: 0x0016399C File Offset: 0x00161B9C
	public void Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_BUY()
	{
		GUIManager.Instance.ShowUILock(EUILock.AllianceMobilization);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_BUY;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06000DF1 RID: 3569 RVA: 0x001639DC File Offset: 0x00161BDC
	public void Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_BUY(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.AllianceMobilization);
		byte b = MP.ReadByte(-1);
		byte b2 = b;
		if (b2 == 0)
		{
			this.availableMission = MP.ReadByte(-1);
			this.extraMission = MP.ReadByte(-1);
			GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eHeroEnhance);
			this.mextraMissionPrize = MP.ReadUShort(-1);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 10, 0);
		}
	}

	// Token: 0x06000DF2 RID: 3570 RVA: 0x00163A60 File Offset: 0x00161C60
	public void Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_GET(byte MissionPos)
	{
		GUIManager.Instance.ShowUILock(EUILock.AllianceMobilization);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_GET;
		messagePacket.AddSeqId();
		messagePacket.Add(MissionPos);
		messagePacket.Send(false);
	}

	// Token: 0x06000DF3 RID: 3571 RVA: 0x00163AA8 File Offset: 0x00161CA8
	public void Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_GET(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if (b != 255)
		{
			GUIManager.Instance.HideUILock(EUILock.AllianceMobilization);
		}
		byte b2 = b;
		if (b2 != 0)
		{
			if (b2 != 4)
			{
				if (b2 == 255)
				{
					this.mMissionID = MP.ReadUShort(-1);
					this.mMissionDifficulty = MP.ReadByte(-1);
					this.mMissionDifficulty = (byte)Mathf.Clamp((int)this.mMissionDifficulty, 0, 3);
					this.availableMission = MP.ReadByte(-1);
					this.mMissionTime = MP.ReadLong(-1);
					this.mMissionTarget = MP.ReadUInt(-1);
					this.mMissionStart = MP.ReadLong(-1);
					if (this.mMissionID != 0)
					{
						DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, true, this.mMissionStart, (uint)(this.mMissionTime - this.mMissionStart));
						DataManager.Instance.SetRecvQueueBarData(32);
					}
					else
					{
						DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, false, 0L, 0u);
					}
					this.mMissionStatus = 0;
					MobilizationMissionData recordByKey = DataManager.Instance.AllianceMobilizationMission.GetRecordByKey(this.mMissionID);
					if (recordByKey.MissionMaxValue != null && this.mMissionTarget == recordByKey.MissionMaxValue[(int)this.mMissionDifficulty])
					{
						this.mMissionStatus = 1;
						GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 8, 0);
						ActivityManager.Instance.CheckAMShowHint();
					}
					else if (this.mMissionID != 0 && this.mMissionStatus == 0 && this.mMissionTime - DataManager.Instance.ServerTime < 0L)
					{
						this.mMissionStatus = 2;
						GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 8, 0);
						ActivityManager.Instance.CheckAMShowHint();
					}
				}
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1344u), 255, true);
			}
		}
		else
		{
			AudioManager.Instance.PlayUISFX(UIKind.ItemUse);
			this.mMissionID = MP.ReadUShort(-1);
			this.mMissionDifficulty = MP.ReadByte(-1);
			this.mMissionDifficulty = (byte)Mathf.Clamp((int)this.mMissionDifficulty, 0, 3);
			this.availableMission = MP.ReadByte(-1);
			this.mMissionStatus = 0;
			this.mMissionTime = MP.ReadLong(-1);
			this.mMissionTarget = MP.ReadUInt(-1);
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, true, DataManager.Instance.ServerTime, (uint)(this.mMissionTime - DataManager.Instance.ServerTime));
			DataManager.Instance.SetRecvQueueBarData(32);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 9, 0);
			FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_GUILD_FEST_QUEST);
		}
	}

	// Token: 0x06000DF4 RID: 3572 RVA: 0x00163D50 File Offset: 0x00161F50
	public void Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DEL(byte MissionPos)
	{
		GUIManager.Instance.ShowUILock(EUILock.AllianceMobilization);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DEL;
		messagePacket.AddSeqId();
		messagePacket.Add(MissionPos);
		messagePacket.Send(false);
	}

	// Token: 0x06000DF5 RID: 3573 RVA: 0x00163D98 File Offset: 0x00161F98
	public void Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_DEL(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.AllianceMobilization);
		byte b = MP.ReadByte(-1);
		byte b2 = b;
		if (b2 != 0)
		{
			if (b2 != 4)
			{
				if (b2 == 255)
				{
					AudioManager.Instance.PlayUISFX(UIKind.Research);
					this.mMissionID = 0;
					this.mMissionStatus = 0;
					DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, false, 0L, 0u);
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 9, 0);
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(3669u), 255, true);
					ActivityManager.Instance.CheckAMShowHint();
				}
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1344u), 255, true);
			}
		}
		else
		{
			AudioManager.Instance.PlayUISFX(UIKind.Research);
		}
	}

	// Token: 0x06000DF6 RID: 3574 RVA: 0x00163E8C File Offset: 0x0016208C
	public void Send_MSG_REQUEST_ALLIANVEMOBLIZATION_MISSION_FINISH()
	{
		GUIManager.Instance.ShowUILock(EUILock.AllianceMobilization);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_FINISH;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06000DF7 RID: 3575 RVA: 0x00163ECC File Offset: 0x001620CC
	public void Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_FINISH(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.AllianceMobilization);
		byte b = MP.ReadByte(-1);
		byte b2 = b;
		if (b2 == 0)
		{
			AudioManager.Instance.PlayUISFX(UIKind.MissionReward);
			this.mMissionID = 0;
			this.mMissionStatus = 0;
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, false, 0L, 0u);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 9, 1);
			ActivityManager.Instance.CheckAMShowHint();
			FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.CREDITS_FOR_GUILD_FEST, ActivityManager.Instance.AllyMobilizationData.EventBeginTime, 0UL);
		}
	}

	// Token: 0x06000DF8 RID: 3576 RVA: 0x00163F68 File Offset: 0x00162168
	public void Recv_MSG_RESP_ALLIANCEMOBILIZATION_MISSION_UPDATE(MessagePacket MP)
	{
		this.mMissionTarget = MP.ReadUInt(-1);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 7, 0);
		MobilizationMissionData recordByKey = DataManager.Instance.AllianceMobilizationMission.GetRecordByKey(this.mMissionID);
		if (this.mMissionTarget == recordByKey.MissionMaxValue[(int)this.mMissionDifficulty])
		{
			this.mMissionStatus = 1;
			DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, true, 0L, 0u);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 8, 0);
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1361u), 255, true);
			ActivityManager.Instance.CheckAMShowHint();
		}
	}

	// Token: 0x06000DF9 RID: 3577 RVA: 0x00164018 File Offset: 0x00162218
	public void Recv_MSG_RESP_ALLIANCEMOBILIZATION_MISSION_DONE(MessagePacket MP)
	{
		this.mMissionStatus = 1;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 8, 0);
		GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1361u), 255, true);
		ActivityManager.Instance.CheckAMShowHint();
	}

	// Token: 0x06000DFA RID: 3578 RVA: 0x0016406C File Offset: 0x0016226C
	public void Recv_MSG_UPDATE_ALLIANCE_MOBILIZATION_LEGEND_MISSION_DATA(MessagePacket MP)
	{
		this.AMGoldState = MP.ReadByte(-1);
		for (int i = 0; i < 3; i++)
		{
			this.AMGoldID[i] = MP.ReadUShort(-1);
			this.AMGoldRecord[i] = MP.ReadUInt(-1);
		}
		this.AMGoldHUD = (MP.ReadByte(-1) == 1);
		if (this.AMGoldHUD)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17252u), 255, true);
		}
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Alliance_Mobilization))
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 12, 0);
		}
		ActivityManager.Instance.CheckAMShowHint();
	}

	// Token: 0x06000DFB RID: 3579 RVA: 0x0016412C File Offset: 0x0016232C
	public void Send_MSG_REQUEST_ALLIANCE_MOBILIZATION_LEGEND_MISSION_GET_SCORE()
	{
		GUIManager.Instance.ShowUILock(EUILock.AllianceMobilizationGold);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MOBILIZATION_LEGEND_MISSION_GET_SCORE;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06000DFC RID: 3580 RVA: 0x0016416C File Offset: 0x0016236C
	public void Recv_MSG_RESP_ALLIANCE_MOBILIZATION_LEGEND_MISSION_GET_SCORE(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.AllianceMobilizationGold);
		byte arg = MP.ReadByte(-1);
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Alliance_Mobilization))
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 13, (int)arg);
		}
	}

	// Token: 0x06000DFD RID: 3581 RVA: 0x001641BC File Offset: 0x001623BC
	public int CheckBonusDone()
	{
		for (int i = 0; i < 3; i++)
		{
			if (DataManager.Instance.AllianceMobilizationGoldMissionTable.GetRecordByKey(this.AMGoldID[i]).par1 <= this.AMGoldRecord[i])
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x06000DFE RID: 3582 RVA: 0x0016420C File Offset: 0x0016240C
	public void SetAllyMobilizationBeginTime(long time)
	{
		this.AllyMobilizationBeginTime = time;
	}

	// Token: 0x06000DFF RID: 3583 RVA: 0x00164218 File Offset: 0x00162418
	public void InitRewardsSelect()
	{
		for (int i = 0; i < this.m_RecvRewardsSelect.Length; i++)
		{
			this.m_RecvRewardsSelect[i].Init();
		}
	}

	// Token: 0x06000E00 RID: 3584 RVA: 0x00164250 File Offset: 0x00162450
	public void ClearRewardsSelectData()
	{
		this.bFirstRequestActivityAmDegeePrize = false;
		this.UIRewardsSelectIndex = 0;
		this.RewardsSelectPosY = 0f;
		Array.Clear(this.m_RecvRewardsSelect, 0, this.m_RecvRewardsSelect.Length);
		Array.Clear(this.RSAnimationItemID, 0, this.RSAnimationItemID.Length);
	}

	// Token: 0x06000E01 RID: 3585 RVA: 0x001642A0 File Offset: 0x001624A0
	public void SendActivityAmDegeePrize()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AM_DEGREEPRIZE;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06000E02 RID: 3586 RVA: 0x001642D4 File Offset: 0x001624D4
	public void RecvActivityAmDegeePrize(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			for (int i = 0; i < this.m_RecvRewardsSelect.Length; i++)
			{
				if (i >= (int)this.AMCompleteDegree)
				{
					this.m_RecvRewardsSelect[i].SelectIndex = 4;
				}
				else
				{
					this.m_RecvRewardsSelect[i].SelectIndex = 0;
				}
				if (i < 20)
				{
					for (int j = 0; j < this.m_RecvRewardsSelect[i].ItemIndex.Length; j++)
					{
						this.m_RecvRewardsSelect[i].ItemIndex[j] = (int)MP.ReadByte(-1);
					}
				}
			}
			this.SpecialPrize = MP.ReadByte(-1);
			this.bFirstRequestActivityAmDegeePrize = true;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_RewardsSelect, 1, 0);
		}
	}

	// Token: 0x06000E03 RID: 3587 RVA: 0x001643A8 File Offset: 0x001625A8
	public void RecvActivityAmDegeePrize_New(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			this.SpecialPrize = MP.ReadByte(-1);
			for (int i = 0; i < this.m_RecvRewardsSelect.Length; i++)
			{
				if (i >= (int)this.AMCompleteDegree)
				{
					this.m_RecvRewardsSelect[i].SelectIndex = 4;
				}
				else
				{
					this.m_RecvRewardsSelect[i].SelectIndex = 0;
				}
				for (int j = 0; j < this.m_RecvRewardsSelect[i].ItemIndex.Length; j++)
				{
					if (j < (int)DataManager.Instance.RoleAlliance.AMMaxDegree)
					{
						this.m_RecvRewardsSelect[i].ItemIndex[j] = (int)MP.ReadByte(-1);
					}
					else
					{
						this.m_RecvRewardsSelect[i].ItemIndex[j] = 0;
					}
				}
			}
			this.bFirstRequestActivityAmDegeePrize = true;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_RewardsSelect, 1, 0);
		}
	}

	// Token: 0x06000E04 RID: 3588 RVA: 0x001644A4 File Offset: 0x001626A4
	public void SendActivityAmGetDegreePrize()
	{
		GUIManager.Instance.ShowUILock(EUILock.AllianceMobilization);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AM_GET_DEGREEPRIZE;
		messagePacket.AddSeqId();
		for (int i = 0; i < this.m_RecvRewardsSelect.Length; i++)
		{
			messagePacket.Add(this.m_RecvRewardsSelect[i].SelectIndex);
		}
		messagePacket.Send(false);
	}

	// Token: 0x06000E05 RID: 3589 RVA: 0x00164514 File Offset: 0x00162714
	public void RecvActivityAmGetDegreePrize(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.AllianceMobilization);
		if (MP.ReadByte(-1) == 0)
		{
			Array.Clear(this.RSAnimationItemID, 0, this.RSAnimationItemID.Length);
			this.PrizeCrystal = 0u;
			this.PrizeAllianceMoney = 0u;
			uint num = MP.ReadUInt(-1);
			uint num2 = MP.ReadUInt(-1);
			if (num > DataManager.Instance.RoleAttr.Diamond)
			{
				this.PrizeCrystal = num - DataManager.Instance.RoleAttr.Diamond;
			}
			if (num2 > DataManager.Instance.RoleAlliance.Money)
			{
				this.PrizeAllianceMoney = num2 - DataManager.Instance.RoleAlliance.Money;
			}
			DataManager.Instance.RoleAttr.Diamond = num;
			DataManager.Instance.RoleAlliance.Money = num2;
			byte b = MP.ReadByte(-1);
			for (int i = 0; i < (int)b; i++)
			{
				ushort num3 = MP.ReadUShort(-1);
				ushort quantity = MP.ReadUShort(-1);
				byte rare = MP.ReadByte(-1);
				DataManager.Instance.SetCurItemQuantity(num3, quantity, rare, 0L);
				if (i < this.RSAnimationItemID.Length)
				{
					this.RSAnimationItemID[i] = num3;
				}
				DataManager.Instance.RoleAttr.bAllianceMobilizationGetPrize = 1;
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_RewardsSelect, 0, 0);
			GameManager.OnRefresh(NetworkNews.Refresh_Alliance, null);
			GameManager.OnRefresh(NetworkNews.Refresh, null);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 99, 0);
			ActivityManager.Instance.CheckAMShowHint();
		}
	}

	// Token: 0x06000E06 RID: 3590 RVA: 0x0016469C File Offset: 0x0016289C
	public bool IsGetPrize()
	{
		return DataManager.Instance.RoleAttr.bAllianceMobilizationGetPrize == 1;
	}

	// Token: 0x06000E07 RID: 3591 RVA: 0x001646BC File Offset: 0x001628BC
	public void OnAMCompleteDegreeChange()
	{
		for (int i = 0; i < this.m_RecvRewardsSelect.Length; i++)
		{
			if (i >= (int)this.AMCompleteDegree)
			{
				this.m_RecvRewardsSelect[i].SelectIndex = 4;
			}
			else
			{
				this.m_RecvRewardsSelect[i].SelectIndex = 0;
			}
		}
	}

	// Token: 0x06000E08 RID: 3592 RVA: 0x00164718 File Offset: 0x00162918
	public void SetRewardsSelectDataSave()
	{
		PlayerPrefs.SetString("RewardsSelectFirstClickItem", this.bRewardsSelectFirstClickItem.ToString());
	}

	// Token: 0x06000E09 RID: 3593 RVA: 0x00164730 File Offset: 0x00162930
	public void GetRewardsSelecteDataSave()
	{
		bool.TryParse(PlayerPrefs.GetString("RewardsSelectFirstClickItem"), out this.bRewardsSelectFirstClickItem);
	}

	// Token: 0x06000E0A RID: 3594 RVA: 0x00164748 File Offset: 0x00162948
	~MobilizationManager()
	{
	}

	// Token: 0x06000E0B RID: 3595 RVA: 0x00164780 File Offset: 0x00162980
	public void Update()
	{
		this.CheckTime -= Time.unscaledDeltaTime;
		if (this.CheckTime <= 0f)
		{
			this.CheckTime = 1f;
			if (this.mMissionID != 0 && this.mMissionStatus == 0 && this.mMissionTime - DataManager.Instance.ServerTime < 0L)
			{
				this.mMissionStatus = 2;
				DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, true, 0L, 0u);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 8, 0);
				ActivityManager.Instance.CheckAMShowHint();
			}
		}
	}

	// Token: 0x04002D20 RID: 11552
	private static MobilizationManager instance;

	// Token: 0x04002D21 RID: 11553
	public bool bFirstOpen = true;

	// Token: 0x04002D22 RID: 11554
	public int mMobilizationScroll;

	// Token: 0x04002D23 RID: 11555
	public float mMobilizationScroll_Y;

	// Token: 0x04002D24 RID: 11556
	public byte availableMission;

	// Token: 0x04002D25 RID: 11557
	public byte extraMission;

	// Token: 0x04002D26 RID: 11558
	public byte involvedMember;

	// Token: 0x04002D27 RID: 11559
	public byte AllianceError;

	// Token: 0x04002D28 RID: 11560
	public byte mActivityLv;

	// Token: 0x04002D29 RID: 11561
	public byte mMissionStatus;

	// Token: 0x04002D2A RID: 11562
	public ushort mMissionID;

	// Token: 0x04002D2B RID: 11563
	public byte mMissionDifficulty;

	// Token: 0x04002D2C RID: 11564
	public long mMissionTime;

	// Token: 0x04002D2D RID: 11565
	public uint mMissionTarget;

	// Token: 0x04002D2E RID: 11566
	public long mMissionStart;

	// Token: 0x04002D2F RID: 11567
	public int mScrollFrame;

	// Token: 0x04002D30 RID: 11568
	public uint CompleteScore;

	// Token: 0x04002D31 RID: 11569
	public uint AMScore;

	// Token: 0x04002D32 RID: 11570
	public byte AMCompleteDegree;

	// Token: 0x04002D33 RID: 11571
	private float CheckTime;

	// Token: 0x04002D34 RID: 11572
	public MobilizationData[] mMobilizationMission = new MobilizationData[21];

	// Token: 0x04002D35 RID: 11573
	public byte mextraMissionBuyLimit;

	// Token: 0x04002D36 RID: 11574
	public ushort mextraMissionPrize;

	// Token: 0x04002D37 RID: 11575
	public byte mMobilizationFutureRank;

	// Token: 0x04002D38 RID: 11576
	public bool bFirstRequestActivityAmDegeePrize;

	// Token: 0x04002D39 RID: 11577
	public long AllyMobilizationBeginTime;

	// Token: 0x04002D3A RID: 11578
	public sRecvRewardsSelect[] m_RecvRewardsSelect = new sRecvRewardsSelect[35];

	// Token: 0x04002D3B RID: 11579
	public ushort[] RSAnimationItemID = new ushort[35];

	// Token: 0x04002D3C RID: 11580
	public uint PrizeCrystal;

	// Token: 0x04002D3D RID: 11581
	public uint PrizeAllianceMoney;

	// Token: 0x04002D3E RID: 11582
	public int UIRewardsSelectIndex;

	// Token: 0x04002D3F RID: 11583
	public float RewardsSelectPosY;

	// Token: 0x04002D40 RID: 11584
	public bool bRewardsSelectFirstClickItem;

	// Token: 0x04002D41 RID: 11585
	public byte SpecialPrize;

	// Token: 0x04002D42 RID: 11586
	private byte[] _DegreeRanges;

	// Token: 0x04002D43 RID: 11587
	public byte AMGoldState;

	// Token: 0x04002D44 RID: 11588
	public ushort[] AMGoldID = new ushort[3];

	// Token: 0x04002D45 RID: 11589
	public uint[] AMGoldRecord = new uint[3];

	// Token: 0x04002D46 RID: 11590
	public bool AMGoldHUD;

	// Token: 0x04002D47 RID: 11591
	public byte mMoreRewards;
}
