using System;
using UnityEngine;

// Token: 0x0200049F RID: 1183
public class PushManage
{
	// Token: 0x06001817 RID: 6167 RVA: 0x0028B400 File Offset: 0x00289600
	private PushManage()
	{
	}

	// Token: 0x170000AD RID: 173
	// (get) Token: 0x06001819 RID: 6169 RVA: 0x0028B40C File Offset: 0x0028960C
	public static PushManage Instance
	{
		get
		{
			if (PushManage._instance == null)
			{
				PushManage._instance = new PushManage();
			}
			return PushManage._instance;
		}
	}

	// Token: 0x0600181A RID: 6170 RVA: 0x0028B428 File Offset: 0x00289628
	public static bool checkOldByteSwitch(int bits)
	{
		int num = 1 << bits;
		return ((int)DataManager.Instance.mSetNotice & num) == num;
	}

	// Token: 0x0600181B RID: 6171 RVA: 0x0028B44C File Offset: 0x0028964C
	public static bool checkNewByteSwitch(int bits)
	{
		ulong num = 1UL << bits;
		return (DataManager.Instance.mNewPushSwitch & num) == 0UL;
	}

	// Token: 0x0600181C RID: 6172 RVA: 0x0028B474 File Offset: 0x00289674
	public static bool checkPushSwitch(int oldBit, int newBit)
	{
		return PushManage.checkNewByteSwitch(newBit) && PushManage.checkOldByteSwitch(oldBit);
	}

	// Token: 0x0600181D RID: 6173 RVA: 0x0028B48C File Offset: 0x0028968C
	public void SetPushToSDK(bool pause)
	{
		if (!pause)
		{
			PushManage.ClearPush();
			return;
		}
		if (!PushManage.PushStart)
		{
			return;
		}
		if (NewbieManager.IsNewbie)
		{
			return;
		}
		if (PushManage.checkPushSwitch(0, 0))
		{
			long num = DataManager.Instance.queueBarData[0].StartTime + (long)((ulong)DataManager.Instance.queueBarData[0].TotalTime);
			if (num > DataManager.Instance.ServerTime)
			{
				num -= DataManager.Instance.ServerTime;
				this.SetPush(0, DataManager.Instance.mStringTable.GetStringByID(8440u), (int)num);
			}
			num = DataManager.Instance.queueBarData[1].StartTime + (long)((ulong)DataManager.Instance.queueBarData[1].TotalTime);
			if (num > DataManager.Instance.ServerTime)
			{
				num -= DataManager.Instance.ServerTime;
				this.SetPush(1, DataManager.Instance.mStringTable.GetStringByID(8441u), (int)num);
			}
			num = DataManager.Instance.queueBarData[10].StartTime + (long)((ulong)DataManager.Instance.queueBarData[10].TotalTime);
			if (num > DataManager.Instance.ServerTime)
			{
				num -= DataManager.Instance.ServerTime;
				this.SetPush(2, DataManager.Instance.mStringTable.GetStringByID(8445u), (int)num);
			}
			num = DataManager.Instance.queueBarData[14].StartTime + (long)((ulong)DataManager.Instance.queueBarData[14].TotalTime);
			if (num > DataManager.Instance.ServerTime)
			{
				num -= DataManager.Instance.ServerTime;
				this.SetPush(3, DataManager.Instance.mStringTable.GetStringByID(8446u), (int)num);
			}
			num = DataManager.Instance.queueBarData[18].StartTime + (long)((ulong)DataManager.Instance.queueBarData[18].TotalTime);
			if (num > DataManager.Instance.ServerTime)
			{
				num -= DataManager.Instance.ServerTime;
				this.SetPush(4, DataManager.Instance.mStringTable.GetStringByID(8455u), (int)num);
			}
			for (int i = 0; i < PetManager.Instance.m_PetTrainingData.Length; i++)
			{
				num = PetManager.Instance.m_PetTrainingData[i].m_EventTime.BeginTime + (long)((ulong)PetManager.Instance.m_PetTrainingData[i].m_EventTime.RequireTime);
				if (num > DataManager.Instance.ServerTime)
				{
					num -= DataManager.Instance.ServerTime;
					this.SetPush(15 + i, DataManager.Instance.mStringTable.GetStringByID(16077u), (int)num);
				}
			}
			num = DataManager.Instance.queueBarData[34].StartTime + (long)((ulong)DataManager.Instance.queueBarData[34].TotalTime);
			if (num > DataManager.Instance.ServerTime)
			{
				num -= DataManager.Instance.ServerTime;
				if (DataManager.Instance.FusionDataTable.GetRecordByKey(PetManager.Instance.ItemCraftID).Fusion_Kind == 0)
				{
					this.SetPush(23, DataManager.Instance.mStringTable.GetStringByID(16095u), (int)num);
				}
				else
				{
					this.SetPush(23, DataManager.Instance.mStringTable.GetStringByID(16096u), (int)num);
				}
			}
		}
		if (PushManage.checkPushSwitch(3, 15) && GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 3 && DataManager.Instance.RoleAttr.NextOnlineGiftOpenTime > DataManager.Instance.ServerTime)
		{
			long num = DataManager.Instance.RoleAttr.NextOnlineGiftOpenTime - DataManager.Instance.ServerTime;
			this.SetPush(5, DataManager.Instance.mStringTable.GetStringByID(8451u), (int)num);
		}
		if (PushManage.checkPushSwitch(4, 16))
		{
			int num2 = (int)(DataManager.Instance.HeroMaxMorale - DataManager.Instance.RoleAttr.Morale);
			if (num2 > 0)
			{
				long num3 = DataManager.Instance.ServerTime - DataManager.Instance.RoleAttr.LastMoraleRecoverTime;
				int num4 = num2;
				if (num3 % 360L > 0L)
				{
					num4--;
				}
				long num = (long)(num4 * 360) + num3;
				this.SetPush(6, DataManager.Instance.mStringTable.GetStringByID(8453u), (int)num);
			}
			uint maxMonsterPoint = DataManager.Instance.GetMaxMonsterPoint();
			num2 = (int)(DataManager.Instance.GetMaxMonsterPoint() - DataManager.Instance.RoleAttr.MonsterPoint);
			if (num2 > 0)
			{
				long num = (long)((DataManager.Instance.GetMaxMonsterPoint() - DataManager.Instance.RoleAttr.MonsterPoint) * ((double)DataManager.Instance.RoleAttr.MonsterPointRecoverFrequency / 1000.0));
				this.SetPush(7, DataManager.Instance.mStringTable.GetStringByID(8467u), (int)num);
			}
		}
		if (PushManage.checkPushSwitch(5, 17))
		{
			int recvBuffDataIdxByID = DataManager.Instance.GetRecvBuffDataIdxByID(1);
			if (recvBuffDataIdxByID >= 0)
			{
				ItemBuffData itemBuffData = DataManager.Instance.m_RecvItemBuffData[recvBuffDataIdxByID];
				long num = itemBuffData.TargetTime - DataManager.Instance.ServerTime - 600L;
				if (num > 0L)
				{
					this.SetPush(8, DataManager.Instance.mStringTable.GetStringByID(8462u), (int)num);
				}
			}
		}
		if (PushManage.checkPushSwitch(11, 20))
		{
			long num = DataManager.Instance.m_CryptData.startTime + (long)((ulong)GameConstants.CryptSecends[(int)DataManager.Instance.m_CryptData.kind]) - DataManager.Instance.ServerTime;
			if (num > 0L)
			{
				this.SetPush(9, DataManager.Instance.mStringTable.GetStringByID(9040u), (int)num);
			}
		}
		if (PushManage.checkPushSwitch(10, 21))
		{
			TimeEventDataType shelterTime = HideArmyManager.Instance.GetShelterTime();
			long num = shelterTime.BeginTime + (long)((ulong)shelterTime.RequireTime) - DataManager.Instance.ServerTime - 600L;
			if (num > 0L)
			{
				this.SetPush(10, DataManager.Instance.mStringTable.GetStringByID(9048u), (int)num);
			}
		}
		if (PushManage.checkNewByteSwitch(22))
		{
			TimerTypeMission timerMissionData = DataManager.MissionDataManager.GetTimerMissionData(_eMissionType.Affair);
			long num = timerMissionData.ResetTime - DataManager.Instance.ServerTime;
			if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 13 && num > 0L)
			{
				this.SetPush(13, DataManager.Instance.mStringTable.GetStringByID(9632u), (int)num);
			}
		}
		if (PushManage.checkPushSwitch(8, 11))
		{
			TimeEventDataType wonderCountTime = GUIManager.Instance.WonderCountTime;
			long num = wonderCountTime.BeginTime + (long)((ulong)wonderCountTime.RequireTime) - DataManager.Instance.ServerTime - 600L;
			if (ActivityManager.Instance.KvKActivityData[4].EventState == EActivityState.EAS_Prepare)
			{
				long num5 = ActivityManager.Instance.KvKActivityData[4].EventBeginTime - DataManager.Instance.ServerTime - 600L;
				if (num5 > 0L)
				{
					this.SetPush(12, DataManager.Instance.mStringTable.GetStringByID(9548u), (int)num5);
				}
				if (num > 0L && num < num5)
				{
					this.SetPush(11, DataManager.Instance.mStringTable.GetStringByID(9029u), (int)num);
				}
			}
			else if (num > 0L)
			{
				this.SetPush(11, DataManager.Instance.mStringTable.GetStringByID(9029u), (int)num);
			}
		}
		if (PushManage.checkNewByteSwitch(25))
		{
			long num = this.OrderEventBeginTime - DataManager.Instance.ServerTime - 600L;
			if (num > 0L)
			{
				this.SetPush(14, DataManager.Instance.mStringTable.GetStringByID(9694u), (int)num);
			}
		}
		RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(8, 0);
		ushort num6 = 0;
		while ((int)num6 < DataManager.Instance.PushCallBackTable.TableCount)
		{
			PushCallBack recordByIndex = DataManager.Instance.PushCallBackTable.GetRecordByIndex((int)num6);
			if (GameConstants.IsBetween((int)buildData.Level, (int)recordByIndex.LowLevel, (int)recordByIndex.HighLevel))
			{
				int num7 = 10171 + UnityEngine.Random.Range(0, 4);
				if (num7 > 10174)
				{
					num7 = 10174;
				}
				this.SetPush(24, DataManager.Instance.mStringTable.GetStringByID((uint)((ushort)num7)), (int)recordByIndex.Hour * 3600);
				break;
			}
			num6 += 1;
		}
		if (PushManage.checkNewByteSwitch(26))
		{
			if (this.FootBallGameType == 15)
			{
				long num = this.FootBallEventBeginTime - ActivityManager.Instance.ServerEventTime - 600L;
				if (num > 0L)
				{
					this.SetPush(25, DataManager.Instance.mStringTable.GetStringByID(16123u), (int)num);
				}
				int num8 = Math.Min(6, (int)this.FootBallWaveCount);
				for (int j = 1; j < num8; j++)
				{
					num += (long)this.FootBallWaveGap;
					if (num > 0L)
					{
						this.SetPush(25 + j, DataManager.Instance.mStringTable.GetStringByID(16125u), (int)num);
					}
				}
			}
			else if (this.FootBallGameType == 16)
			{
				EActivityState fifastate = ActivityManager.Instance.GetFIFAState();
				if (fifastate == EActivityState.EAS_Prepare || fifastate == EActivityState.EAS_Run)
				{
					long num = this.FootBallEventBeginTime - ActivityManager.Instance.ServerEventTime - 600L;
					int num9 = Math.Min(6, (int)this.FootBallWaveCount);
					for (int k = 1; k < num9; k++)
					{
						num += (long)this.FootBallWaveGap;
						if (num > 0L)
						{
							this.SetPush(25 + k, DataManager.Instance.mStringTable.GetStringByID(16125u), (int)num);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600181E RID: 6174 RVA: 0x0028BEB0 File Offset: 0x0028A0B0
	public void Recv_MSG_RESP_FOOTBALL_PREPUSH_INFO(MessagePacket MP)
	{
		this.FootBallGameType = MP.ReadByte(-1);
		this.FootBallGameType -= 1;
		this.FootBallEventBeginTime = MP.ReadLong(-1);
		this.FootBallWaveCount = MP.ReadByte(-1);
		this.FootBallWaveGap = (int)MP.ReadUShort(-1);
		this.FootBallWaveGap *= 60;
	}

	// Token: 0x0600181F RID: 6175 RVA: 0x0028BF10 File Offset: 0x0028A110
	private void SetPush(int nid, string msg, int sec)
	{
		IGGSDKPlugin.SetLocalNotification(nid, msg, sec);
	}

	// Token: 0x06001820 RID: 6176 RVA: 0x0028BF1C File Offset: 0x0028A11C
	public static void ClearPush()
	{
		for (int i = 0; i < 31; i++)
		{
			IGGSDKPlugin.CancelNotification(i);
		}
	}

	// Token: 0x04004713 RID: 18195
	private const int MaxFootBallWave = 6;

	// Token: 0x04004714 RID: 18196
	private static PushManage _instance;

	// Token: 0x04004715 RID: 18197
	public static bool PushStart;

	// Token: 0x04004716 RID: 18198
	public long OrderEventBeginTime;

	// Token: 0x04004717 RID: 18199
	public byte FootBallGameType;

	// Token: 0x04004718 RID: 18200
	public long FootBallEventBeginTime;

	// Token: 0x04004719 RID: 18201
	public byte FootBallWaveCount;

	// Token: 0x0400471A RID: 18202
	public int FootBallWaveGap;
}
