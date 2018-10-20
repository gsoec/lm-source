using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
internal class AFAdvanceManager
{
	// Token: 0x0600000B RID: 11 RVA: 0x000024B8 File Offset: 0x000006B8
	private AFAdvanceManager()
	{
		for (int i = 0; i < this.ExtraObjectData.Length; i++)
		{
			if (i >= 51 && i <= 62)
			{
				this.ExtraObjectData[i] = new ExtraObject(i);
			}
		}
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x0600000C RID: 12 RVA: 0x00002564 File Offset: 0x00000764
	public static AFAdvanceManager Instance
	{
		get
		{
			if (AFAdvanceManager.instance == null)
			{
				AFAdvanceManager.instance = new AFAdvanceManager();
			}
			return AFAdvanceManager.instance;
		}
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002580 File Offset: 0x00000780
	public bool TriggerAfAdvEvent(EAppsFlayerEvent eventType)
	{
		if (!this.bNeedCheckEvent)
		{
			this.DebugMsg("ALL EVENT Allready Trigger", EAppsFlayerEvent.eMax);
			return false;
		}
		if (eventType >= EAppsFlayerEvent.eMax)
		{
			this.DebugMsg("eventType >= EAppsFlayerEvent.eMax", EAppsFlayerEvent.eMax);
			return false;
		}
		if (this.CheckRequirement(eventType))
		{
			if (eventType == EAppsFlayerEvent.HEROSTAGE1_3_COMPLETION)
			{
				IGGSDKPlugin.HeroStageCompletion();
			}
			else if (eventType == EAppsFlayerEvent.TUTORIAL_COMPLETION)
			{
				IGGSDKPlugin.AppsFlyerTutorialCompletion();
			}
			else
			{
				IGGSDKPlugin.AppsFlyerAdvance(eventType.ToString());
			}
			if (eventType <= EAppsFlayerEvent.BUY_SUPPLYCHEST)
			{
				this.m_SaveData |= 1L << (int)eventType;
			}
			else
			{
				this.m_SaveData2 |= 1L << eventType - EAppsFlayerEvent.BUY_SUPPLYCHEST - 1;
			}
			this.SaveEventData(eventType);
			return true;
		}
		return false;
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002648 File Offset: 0x00000848
	public void CheckTriggerEvent_Time(float dt)
	{
		this.m_TickTime += dt;
		if (this.m_TickTime >= 10f)
		{
			if (this.bNeedCheckTimeEvent && this.m_OnlineTime >= 600L)
			{
				this.TriggerAfAdvEvent(EAppsFlayerEvent.NEWBIE_PLAYS10M);
				if (this.m_OnlineTime >= 1200L)
				{
					this.TriggerAfAdvEvent(EAppsFlayerEvent.NEWBIE_PLAYS20M);
					if (this.m_OnlineTime >= 1800L)
					{
						this.TriggerAfAdvEvent(EAppsFlayerEvent.NEWBIE_PLAYS30M);
						this.bNeedCheckTimeEvent = false;
					}
				}
			}
			this.m_OnlineTime += 10L;
			this.m_TickTime -= 10f;
		}
	}

	// Token: 0x0600000F RID: 15 RVA: 0x000026F4 File Offset: 0x000008F4
	public void CheckTriggerEvent_LoginFinish()
	{
		this.CheckCharacterLvEvent(DataManager.Instance.RoleAttr.Level);
		this.CheckCastleLvEvent(GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level);
		this.CheckPower(DataManager.Instance.RoleAttr.Power);
		this.TriggerAfAdvEvent(EAppsFlayerEvent.IGG_LAUNCH);
		this.CheckLoginUnbroken();
		if (IGGSDKPlugin.GetAPILevel() >= 23)
		{
			this.TriggerAfAdvEvent(EAppsFlayerEvent.LOGIN_IPHONE_OS6);
		}
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00002770 File Offset: 0x00000970
	public void SaveOnlineTime()
	{
		this.DebugMsg("SaveOnlineTime =" + this.m_OnlineTime, EAppsFlayerEvent.eMax);
		PlayerPrefs.SetString("AFOnlineTime", this.m_OnlineTime.ToString());
	}

	// Token: 0x06000011 RID: 17 RVA: 0x000027B0 File Offset: 0x000009B0
	public void GetOnlineTime()
	{
		long.TryParse(PlayerPrefs.GetString("AFOnlineTime"), out this.m_OnlineTime);
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000027C8 File Offset: 0x000009C8
	public void SaveEventData()
	{
		PlayerPrefs.SetString("AFAdvanceEventData", this.m_SaveData.ToString());
		PlayerPrefs.SetString("AFAdvanceEventData2", this.m_SaveData2.ToString());
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00002800 File Offset: 0x00000A00
	public void SaveExtraData()
	{
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002804 File Offset: 0x00000A04
	public void SaveEventData(EAppsFlayerEvent eventType)
	{
		this.SaveEventData();
		if (eventType == EAppsFlayerEvent.IGG_LAUNCH)
		{
			this.SaveIggLaunchDay();
		}
	}

	// Token: 0x06000015 RID: 21 RVA: 0x0000281C File Offset: 0x00000A1C
	public void GetEventData()
	{
		long.TryParse(PlayerPrefs.GetString("AFAdvanceEventData"), out this.m_SaveData);
		long.TryParse(PlayerPrefs.GetString("AFAdvanceEventData2"), out this.m_SaveData2);
		if (this.CheckIsRecord(EAppsFlayerEvent.NEWBIE_PLAYS10M) && this.CheckIsRecord(EAppsFlayerEvent.NEWBIE_PLAYS20M) && this.CheckIsRecord(EAppsFlayerEvent.NEWBIE_PLAYS30M))
		{
			this.bNeedCheckTimeEvent = false;
		}
		if (this.CheckIsRecord(EAppsFlayerEvent.REACH_MIGHT50K) && this.CheckIsRecord(EAppsFlayerEvent.REACH_MIGHT500K) && this.CheckIsRecord(EAppsFlayerEvent.REACH_MIGHT1M) && this.CheckIsRecord(EAppsFlayerEvent.REACH_MIGHT5M))
		{
			this.bNeedCheckPower = false;
		}
		if (this.CheckIsRecord(EAppsFlayerEvent.FIRST_4_99PURCHASE))
		{
			this.bNeedCheckPURCHASE4_99 = false;
		}
		if (this.CheckIsRecord(EAppsFlayerEvent.FIRST_19_99PURCHASE))
		{
			this.bNeedCheckPURCHASE19_99 = false;
		}
	}

	// Token: 0x06000016 RID: 22 RVA: 0x000028E4 File Offset: 0x00000AE4
	public void GetExtraData()
	{
	}

	// Token: 0x06000017 RID: 23 RVA: 0x000028E8 File Offset: 0x00000AE8
	public void SaveFirstLoginTime()
	{
		PlayerPrefs.SetString("AFFirstLoginServerTime", DataManager.Instance.ServerTime.ToString());
		this.m_FirstLoginServerTime = DataManager.Instance.ServerTime;
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002924 File Offset: 0x00000B24
	public void GetFirstLoginTime()
	{
		if (this.m_FirstLoginServerTime == 0L)
		{
			long.TryParse(PlayerPrefs.GetString("AFFirstLoginServerTime"), out this.m_FirstLoginServerTime);
		}
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002948 File Offset: 0x00000B48
	private bool CheckIsRecord(EAppsFlayerEvent eventType)
	{
		if (eventType <= EAppsFlayerEvent.BUY_SUPPLYCHEST)
		{
			return (this.m_SaveData & 1L << (int)eventType) != 0L;
		}
		return (this.m_SaveData2 & 1L << eventType - EAppsFlayerEvent.BUY_SUPPLYCHEST - 1) != 0L;
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00002990 File Offset: 0x00000B90
	private bool CheckRequirement(EAppsFlayerEvent eventType)
	{
		bool flag = this.CheckIsRecord(eventType);
		if (eventType == EAppsFlayerEvent.IGG_LAUNCH)
		{
			return !flag || this.CheckCanSendLaunch();
		}
		return !flag;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x000029C4 File Offset: 0x00000BC4
	~AFAdvanceManager()
	{
	}

	// Token: 0x0600001C RID: 28 RVA: 0x000029FC File Offset: 0x00000BFC
	private void DebugMsg(string msg, EAppsFlayerEvent eventType)
	{
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00002A00 File Offset: 0x00000C00
	public void Clean()
	{
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00002A04 File Offset: 0x00000C04
	public void CheckCharacterLvEvent(byte lv)
	{
		EAppsFlayerEvent[] array = new EAppsFlayerEvent[]
		{
			EAppsFlayerEvent.REACH_CHARACTERLV5,
			EAppsFlayerEvent.REACH_CHARACTERLV10,
			EAppsFlayerEvent.REACH_CHARACTERLV15,
			EAppsFlayerEvent.REACH_CHARACTERLV20,
			EAppsFlayerEvent.REACH_CHARACTERLV25,
			EAppsFlayerEvent.REACH_CHARACTERLV28,
			EAppsFlayerEvent.REACH_CHARACTERLV30,
			EAppsFlayerEvent.REACH_CHARACTERLV33,
			EAppsFlayerEvent.REACH_CHARACTERLV38
		};
		ulong[] array2 = new ulong[]
		{
			5UL,
			10UL,
			15UL,
			20UL,
			25UL,
			28UL,
			30UL,
			33UL,
			38UL
		};
		int num = 0;
		int num2 = 0;
		while (num2 < array.Length && num2 < array2.Length)
		{
			if ((ulong)lv < array2[num2])
			{
				break;
			}
			this.TriggerAfAdvEvent(array[num++]);
			num2++;
		}
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00002A9C File Offset: 0x00000C9C
	public void CheckCastleLvEvent(byte lv)
	{
		EAppsFlayerEvent[] array = new EAppsFlayerEvent[]
		{
			EAppsFlayerEvent.REACH_CASTLELV3,
			EAppsFlayerEvent.REACH_CASTLELV4,
			EAppsFlayerEvent.REACH_CASTLELV5,
			EAppsFlayerEvent.REACH_CASTLELV6,
			EAppsFlayerEvent.REACH_CASTLELV7,
			EAppsFlayerEvent.REACH_CASTLELV8,
			EAppsFlayerEvent.REACH_CASTLELV9,
			EAppsFlayerEvent.REACH_CASTLELV10,
			EAppsFlayerEvent.REACH_CASTLELV11,
			EAppsFlayerEvent.REACH_CASTLELV12,
			EAppsFlayerEvent.REACH_CASTLELV13,
			EAppsFlayerEvent.REACH_CASTLELV14,
			EAppsFlayerEvent.REACH_CASTLELV15
		};
		int num = 0;
		for (int i = 3; i < 16; i++)
		{
			if ((int)lv < i)
			{
				break;
			}
			this.TriggerAfAdvEvent(array[num++]);
		}
	}

	// Token: 0x06000020 RID: 32 RVA: 0x00002B2C File Offset: 0x00000D2C
	public void CheckPower(ulong might)
	{
		if (this.bNeedCheckPower)
		{
			EAppsFlayerEvent[] array = new EAppsFlayerEvent[]
			{
				EAppsFlayerEvent.REACH_MIGHT50K,
				EAppsFlayerEvent.REACH_MIGHT500K,
				EAppsFlayerEvent.REACH_MIGHT1M,
				EAppsFlayerEvent.REACH_MIGHT5M
			};
			ulong[] array2 = new ulong[]
			{
				50000UL,
				500000UL,
				1000000UL,
				5000000UL
			};
			int num = 0;
			byte b = 0;
			for (int i = 0; i < array2.Length; i++)
			{
				if (might < array2[i])
				{
					break;
				}
				b += 1;
				this.TriggerAfAdvEvent(array[num++]);
			}
			this.bNeedCheckPower = (b != 4);
		}
	}

	// Token: 0x06000021 RID: 33 RVA: 0x00002BCC File Offset: 0x00000DCC
	public void CheckTrainTroop()
	{
		ulong num = 0UL;
		for (byte b = 1; b <= 16; b += 1)
		{
			num += (ulong)DataManager.MissionDataManager.CheckDynaMark(b);
		}
		EAppsFlayerEvent[] array = new EAppsFlayerEvent[]
		{
			EAppsFlayerEvent.TRAIN_TROOPS500,
			EAppsFlayerEvent.TRAIN_TROOPS2000,
			EAppsFlayerEvent.TRAIN_TROOPS10K,
			EAppsFlayerEvent.TRAIN_TROOPS50K
		};
		ulong[] array2 = new ulong[]
		{
			500UL,
			2000UL,
			10000UL,
			50000UL
		};
		int num2 = 0;
		for (int i = 0; i < array2.Length; i++)
		{
			if (num < array2[i])
			{
				break;
			}
			this.TriggerAfAdvEvent(array[num2++]);
		}
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00002C6C File Offset: 0x00000E6C
	public void CheckHeroCount(ulong count)
	{
		EAppsFlayerEvent[] array = new EAppsFlayerEvent[]
		{
			EAppsFlayerEvent.HIRE_HEROES3,
			EAppsFlayerEvent.HIRE_HEROES5,
			EAppsFlayerEvent.HIRE_HEROES10,
			EAppsFlayerEvent.HIRE_HEROES15
		};
		ulong[] array2 = new ulong[]
		{
			3UL,
			5UL,
			10UL,
			15UL
		};
		int num = 0;
		for (int i = 0; i < array2.Length; i++)
		{
			if (count < array2[i])
			{
				break;
			}
			this.TriggerAfAdvEvent(array[num++]);
		}
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00002CE0 File Offset: 0x00000EE0
	public void CheckCompleteQuest()
	{
		ushort num = DataManager.MissionDataManager.CheckDynaMark(101);
		EAppsFlayerEvent[] array = new EAppsFlayerEvent[]
		{
			EAppsFlayerEvent.COMPLETE_TURFQUESTS10,
			EAppsFlayerEvent.COMPLETE_TURFQUESTS20,
			EAppsFlayerEvent.COMPLETE_TURFQUESTS100
		};
		ushort[] array2 = new ushort[]
		{
			10,
			20,
			100
		};
		int num2 = 0;
		for (int i = 0; i < array2.Length; i++)
		{
			if (num < array2[i])
			{
				break;
			}
			this.TriggerAfAdvEvent(array[num2++]);
		}
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00002D64 File Offset: 0x00000F64
	public void CheckHitMonster()
	{
		if (DataManager.MissionDataManager.CheckDynaMark(145) > 0)
		{
			this.TriggerAfAdvEvent(EAppsFlayerEvent.HIT_MONSTERLV1);
		}
		if (DataManager.MissionDataManager.CheckDynaMark(146) > 0)
		{
			this.TriggerAfAdvEvent(EAppsFlayerEvent.HIT_MONSTERLV2);
		}
		if (DataManager.MissionDataManager.CheckDynaMark(147) > 0)
		{
			this.TriggerAfAdvEvent(EAppsFlayerEvent.HIT_MONSTERLV3);
		}
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00002DCC File Offset: 0x00000FCC
	public void CheckGatherTimber()
	{
		ushort num = DataManager.MissionDataManager.CheckDynaMark(126);
		if (num > 50000)
		{
			this.TriggerAfAdvEvent(EAppsFlayerEvent.GATHER_TIMBER50K);
		}
	}

	// Token: 0x06000026 RID: 38 RVA: 0x00002DFC File Offset: 0x00000FFC
	public void CheckPurchase(uint id)
	{
		this.TriggerAfAdvEvent(EAppsFlayerEvent.FIRST_PURCHASE);
		if (this.bNeedCheckPURCHASE4_99)
		{
			for (int i = 0; i < this.PURCHASE4_99.Length; i++)
			{
				if (this.PURCHASE4_99[i] == id)
				{
					if (this.TriggerAfAdvEvent(EAppsFlayerEvent.FIRST_4_99PURCHASE))
					{
						this.bNeedCheckPURCHASE4_99 = false;
					}
					break;
				}
			}
		}
		if (this.bNeedCheckPURCHASE19_99)
		{
			for (int j = 0; j < this.PURCHASE19_99.Length; j++)
			{
				if (this.PURCHASE19_99[j] == id)
				{
					if (this.TriggerAfAdvEvent(EAppsFlayerEvent.FIRST_19_99PURCHASE))
					{
						this.bNeedCheckPURCHASE19_99 = false;
					}
					break;
				}
			}
		}
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00002EA8 File Offset: 0x000010A8
	private void SaveIggLaunchDay()
	{
		DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
		PlayerPrefs.SetString("AF_IGG_LAUNCH", dateTime.Ticks.ToString());
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00002F00 File Offset: 0x00001100
	private long GetIggLaunchDay()
	{
		long result = 0L;
		bool flag = long.TryParse(PlayerPrefs.GetString("AF_IGG_LAUNCH"), out result);
		if (flag)
		{
			return result;
		}
		return 0L;
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00002F2C File Offset: 0x0000112C
	public bool CheckCanSendLaunch()
	{
		long iggLaunchDay = this.GetIggLaunchDay();
		if (iggLaunchDay == 0L)
		{
			return true;
		}
		bool result;
		try
		{
			DateTime d = new DateTime(iggLaunchDay);
			DateTime now = DateTime.Now;
			int days = (now - d).Days;
			result = (days >= 1);
		}
		catch (Exception ex)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00002FA8 File Offset: 0x000011A8
	public void CheckLoginUnbroken()
	{
		EAppsFlayerEvent[] array = new EAppsFlayerEvent[]
		{
			EAppsFlayerEvent.LOGIN_3DAYS,
			EAppsFlayerEvent.LOGIN_7DAYS
		};
		int[] array2 = new int[]
		{
			3,
			7
		};
		for (int i = 0; i < array2.Length; i++)
		{
			this.ExtraObjectData[(int)array[i]].SetUnbrokenDay();
			if ((int)this.ExtraObjectData[(int)array[i]].UnbrokenDay >= array2[i])
			{
				this.TriggerAfAdvEvent(array[i]);
			}
			if ((int)this.ExtraObjectData[(int)array[i]].UnbrokenDay >= array2[i])
			{
				this.TriggerAfAdvEvent(array[i]);
			}
		}
	}

	// Token: 0x0600002B RID: 43 RVA: 0x0000303C File Offset: 0x0000123C
	public void CheckOpenTreasureUnbroken()
	{
		EAppsFlayerEvent[] array = new EAppsFlayerEvent[]
		{
			EAppsFlayerEvent.MYSTERYBOX_3DAYS,
			EAppsFlayerEvent.MYSTERYBOX_7DAYS
		};
		int[] array2 = new int[]
		{
			3,
			7
		};
		for (int i = 0; i < array2.Length; i++)
		{
			this.ExtraObjectData[(int)array[i]].SetUnbrokenDay();
			if ((int)this.ExtraObjectData[(int)array[i]].UnbrokenDay >= array2[i])
			{
				this.TriggerAfAdvEvent(array[i]);
			}
			if ((int)this.ExtraObjectData[(int)array[i]].UnbrokenDay >= array2[i])
			{
				this.TriggerAfAdvEvent(array[i]);
			}
		}
	}

	// Token: 0x0600002C RID: 44 RVA: 0x000030D0 File Offset: 0x000012D0
	public void CheckGuildHelpUnbroken()
	{
		EAppsFlayerEvent[] array = new EAppsFlayerEvent[]
		{
			EAppsFlayerEvent.GUILDHELP_3DAYS,
			EAppsFlayerEvent.GUILDHELP_7DAYS
		};
		int[] array2 = new int[]
		{
			3,
			7
		};
		for (int i = 0; i < array2.Length; i++)
		{
			this.ExtraObjectData[(int)array[i]].SetUnbrokenDay();
			if ((int)this.ExtraObjectData[(int)array[i]].UnbrokenDay >= array2[i])
			{
				this.TriggerAfAdvEvent(array[i]);
			}
			if ((int)this.ExtraObjectData[(int)array[i]].UnbrokenDay >= array2[i])
			{
				this.TriggerAfAdvEvent(array[i]);
			}
		}
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00003164 File Offset: 0x00001364
	public void CheckGatherTimberUnbroken()
	{
		EAppsFlayerEvent[] array = new EAppsFlayerEvent[]
		{
			EAppsFlayerEvent.GATHERTIMBER_3DAYS,
			EAppsFlayerEvent.GATHERTIMBER_7DAYS
		};
		int[] array2 = new int[]
		{
			3,
			7
		};
		for (int i = 0; i < array2.Length; i++)
		{
			this.ExtraObjectData[(int)array[i]].SetUnbrokenDay();
			if ((int)this.ExtraObjectData[(int)array[i]].UnbrokenDay >= array2[i])
			{
				this.TriggerAfAdvEvent(array[i]);
			}
			if ((int)this.ExtraObjectData[(int)array[i]].UnbrokenDay >= array2[i])
			{
				this.TriggerAfAdvEvent(array[i]);
			}
		}
	}

	// Token: 0x0600002E RID: 46 RVA: 0x000031F8 File Offset: 0x000013F8
	public void CheckHeroStageUnbroken()
	{
		EAppsFlayerEvent[] array = new EAppsFlayerEvent[]
		{
			EAppsFlayerEvent.HEROSTAGE_3DAYS,
			EAppsFlayerEvent.HEROSTAGE_7DAYS
		};
		int[] array2 = new int[]
		{
			3,
			7
		};
		for (int i = 0; i < array2.Length; i++)
		{
			this.ExtraObjectData[(int)array[i]].SetUnbrokenDay();
			if ((int)this.ExtraObjectData[(int)array[i]].UnbrokenDay >= array2[i])
			{
				this.TriggerAfAdvEvent(array[i]);
			}
			if ((int)this.ExtraObjectData[(int)array[i]].UnbrokenDay >= array2[i])
			{
				this.TriggerAfAdvEvent(array[i]);
			}
		}
	}

	// Token: 0x0600002F RID: 47 RVA: 0x0000328C File Offset: 0x0000148C
	public void CheckTurfQuestUnbroken()
	{
		EAppsFlayerEvent[] array = new EAppsFlayerEvent[]
		{
			EAppsFlayerEvent.TURFQUEST_3DAYS,
			EAppsFlayerEvent.TURFQUEST_7DAYS
		};
		int[] array2 = new int[]
		{
			3,
			7
		};
		for (int i = 0; i < array2.Length; i++)
		{
			this.ExtraObjectData[(int)array[i]].SetUnbrokenDay();
			if ((int)this.ExtraObjectData[(int)array[i]].UnbrokenDay >= array2[i])
			{
				this.TriggerAfAdvEvent(array[i]);
			}
			if ((int)this.ExtraObjectData[(int)array[i]].UnbrokenDay >= array2[i])
			{
				this.TriggerAfAdvEvent(array[i]);
			}
		}
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00003320 File Offset: 0x00001520
	public void SupplyHest(uint id)
	{
		if (id == 12378u)
		{
			this.TriggerAfAdvEvent(EAppsFlayerEvent.BUY_SUPPLYCHEST);
		}
	}

	// Token: 0x0400005D RID: 93
	private const string OnlineTimeTag = "AFOnlineTime";

	// Token: 0x0400005E RID: 94
	private const string AdvanceEventDataTag = "AFAdvanceEventData";

	// Token: 0x0400005F RID: 95
	private const string AdvanceEventDataTag2 = "AFAdvanceEventData2";

	// Token: 0x04000060 RID: 96
	private const string FirstLoginServerTime = "AFFirstLoginServerTime";

	// Token: 0x04000061 RID: 97
	private const string IGG_LAUNCH = "AF_IGG_LAUNCH";

	// Token: 0x04000062 RID: 98
	private const long Minute_30 = 1800L;

	// Token: 0x04000063 RID: 99
	private const long Minute_20 = 1200L;

	// Token: 0x04000064 RID: 100
	private const long Minute_10 = 600L;

	// Token: 0x04000065 RID: 101
	private const long Sec_3Day = 259200L;

	// Token: 0x04000066 RID: 102
	private const byte TriggerChearacterLv5 = 5;

	// Token: 0x04000067 RID: 103
	private const byte TriggerCastleLv5 = 5;

	// Token: 0x04000068 RID: 104
	private static AFAdvanceManager instance;

	// Token: 0x04000069 RID: 105
	private float m_TickTime;

	// Token: 0x0400006A RID: 106
	private ExtraObject[] ExtraObjectData = new ExtraObject[85];

	// Token: 0x0400006B RID: 107
	private long m_SaveData;

	// Token: 0x0400006C RID: 108
	private long m_SaveData2;

	// Token: 0x0400006D RID: 109
	private long m_OnlineTime;

	// Token: 0x0400006E RID: 110
	private bool bNeedCheckTimeEvent = true;

	// Token: 0x0400006F RID: 111
	private bool bNeedCheckEvent = true;

	// Token: 0x04000070 RID: 112
	private bool bNeedCheckPower = true;

	// Token: 0x04000071 RID: 113
	private long m_FirstLoginServerTime;

	// Token: 0x04000072 RID: 114
	private bool bNeedCheckPURCHASE4_99 = true;

	// Token: 0x04000073 RID: 115
	private bool bNeedCheckPURCHASE19_99 = true;

	// Token: 0x04000074 RID: 116
	private uint[] PURCHASE4_99 = new uint[]
	{
		11660u,
		11617u,
		11616u,
		11615u,
		11614u,
		11601u,
		11613u,
		11600u,
		11612u,
		11618u,
		11611u,
		11610u,
		11596u,
		11619u,
		14140u,
		14141u,
		14142u,
		14238u,
		14239u,
		14240u,
		11571u,
		14216u,
		13881u,
		13882u
	};

	// Token: 0x04000075 RID: 117
	private uint[] PURCHASE19_99 = new uint[]
	{
		11635u,
		11634u,
		11605u,
		11633u,
		11604u,
		11632u,
		11636u,
		11631u,
		11630u,
		11661u,
		11639u,
		11597u,
		11638u,
		11637u,
		14143u,
		14144u,
		14145u,
		14241u,
		14242u,
		14243u,
		11573u,
		14037u,
		14038u,
		14039u,
		14040u,
		14041u,
		14042u,
		14043u,
		14044u,
		14045u,
		14046u,
		13883u,
		13884u
	};
}
