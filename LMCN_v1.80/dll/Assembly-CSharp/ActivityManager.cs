using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

// Token: 0x0200001D RID: 29
public class ActivityManager
{
	// Token: 0x0600003C RID: 60 RVA: 0x00003B7C File Offset: 0x00001D7C
	private ActivityManager()
	{
		int num = 2;
		for (int i = 0; i < num; i++)
		{
			ActivityDataType activityDataType = new ActivityDataType();
			this.ActivityData[i] = activityDataType;
		}
		num = 5;
		for (int j = 0; j < num; j++)
		{
			ActivityDataType activityDataType2 = new ActivityDataType();
			this.KvKActivityData[j] = activityDataType2;
		}
		num = 5;
		for (int k = 0; k < num; k++)
		{
			SPActivityDataType spactivityDataType = new SPActivityDataType();
			this.CSActivityData[k] = spactivityDataType;
		}
		num = 5;
		for (int l = 0; l < num; l++)
		{
			SPActivityDataType spactivityDataType2 = new SPActivityDataType();
			this.SPActivityData[l] = spactivityDataType2;
		}
		num = 5;
		for (int m = 0; m < num; m++)
		{
			this.MonstrCStr[m] = new CString(300);
		}
		for (int n = 0; n < 5; n++)
		{
			this.LastCSActivityTime[n] = -1L;
			this.bShowNewCSActivity[n] = false;
			this.CSActivityTime[n] = -1L;
			this.bOpenCSActivity[n] = false;
		}
		for (int num2 = 0; num2 < 5; num2++)
		{
			this.LastSPActivityTime[num2] = -1L;
			this.bShowNewSPActivity[num2] = false;
			this.SPActivityTime[num2] = -1L;
			this.bOpenSPActivity[num2] = false;
			this.SPActivityCStr[num2] = new CString(300);
		}
		num = 3;
		for (int num3 = 0; num3 < num; num3++)
		{
			ActivityDataType activityDataType3 = new ActivityDataType();
			this.FIFAData[num3] = activityDataType3;
		}
		num = 17;
		for (int num4 = 0; num4 < num; num4++)
		{
			MarqueeInfoDataType marqueeInfoDataType = default(MarqueeInfoDataType);
			this.MarqueeInfo[num4] = marqueeInfoDataType;
			this.MarqueeInfo[num4].ActivityStr = new CString(300);
		}
		num = 5;
		for (int num5 = 0; num5 < num; num5++)
		{
			MarqueeInfoDataType marqueeInfoDataType2 = default(MarqueeInfoDataType);
			this.MarqueeInfoCS[num5] = marqueeInfoDataType2;
			this.MarqueeInfoCS[num5].ActivityStr = new CString(300);
		}
		num = 5;
		for (int num6 = 0; num6 < num; num6++)
		{
			MarqueeInfoDataType marqueeInfoDataType3 = default(MarqueeInfoDataType);
			this.MarqueeInfoSP[num6] = marqueeInfoDataType3;
			this.MarqueeInfoSP[num6].ActivityStr = new CString(300);
		}
		this.LoadActivity();
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x0600003D RID: 61 RVA: 0x00004104 File Offset: 0x00002304
	public static ActivityManager Instance
	{
		get
		{
			if (ActivityManager.instance == null)
			{
				ActivityManager.instance = new ActivityManager();
			}
			return ActivityManager.instance;
		}
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x0600003E RID: 62 RVA: 0x00004120 File Offset: 0x00002320
	// (set) Token: 0x0600003F RID: 63 RVA: 0x00004150 File Offset: 0x00002350
	public Door door
	{
		get
		{
			if (this.m_door == null)
			{
				this.m_door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
			}
			return this.m_door;
		}
		set
		{
			this.m_door = value;
		}
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000040 RID: 64 RVA: 0x0000415C File Offset: 0x0000235C
	public uint AW_OneRoundTime
	{
		get
		{
			if (this.AW_Rank == 0)
			{
				return 0u;
			}
			if (this.mAW_OneRoundTime == 0u)
			{
				this.mAW_OneRoundTime = (uint)(this.AW_PrepareTime + this.AW_WaitTime + (ushort)((this.AW_MemberCount * 2 - 1) * this.AW_FightTime));
			}
			return this.mAW_OneRoundTime;
		}
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000041 RID: 65 RVA: 0x000041AC File Offset: 0x000023AC
	public long ServerEventTime
	{
		get
		{
			return DataManager.Instance.ServerTime;
		}
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x06000042 RID: 66 RVA: 0x000041B8 File Offset: 0x000023B8
	public AllianceWarManager AllianceWarMgr
	{
		get
		{
			if (this._AllianceWarMgr == null)
			{
				this._AllianceWarMgr = new AllianceWarManager();
			}
			return this._AllianceWarMgr;
		}
	}

	// Token: 0x06000043 RID: 67 RVA: 0x000041D8 File Offset: 0x000023D8
	~ActivityManager()
	{
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00004210 File Offset: 0x00002410
	public void CheckActivityShow()
	{
		if (this.door)
		{
			bool flag = this.bShowNewCSActivity[0] || this.bShowNewCSActivity[1] || this.bShowNewCSActivity[2] || this.bShowNewCSActivity[3] || this.bShowNewCSActivity[4];
			bool flag2 = this.bShowNewSPActivity[0] || this.bShowNewSPActivity[1] || this.bShowNewSPActivity[2] || this.bShowNewSPActivity[3] || this.bShowNewSPActivity[4];
			this.door.m_ActivityAlert.SetActive(flag || flag2 || this.bShowAMHint || this.bForceNWActivity || this.bShowAWHint || this.ShowNewsNo > 0u || this.bShowFIFAHint || this.bShowFirstBuyHint);
		}
	}

	// Token: 0x06000045 RID: 69 RVA: 0x0000430C File Offset: 0x0000250C
	public void SaveLastActivityTime(int Kind, int bIndex)
	{
		if (Kind == 0)
		{
			switch (bIndex)
			{
			case 0:
				PlayerPrefs.SetString("LastCSActivityTime_1", this.LastCSActivityTime[bIndex].ToString());
				break;
			case 1:
				PlayerPrefs.SetString("LastCSActivityTime_2", this.LastCSActivityTime[bIndex].ToString());
				break;
			case 2:
				PlayerPrefs.SetString("LastCSActivityTime_3", this.LastCSActivityTime[bIndex].ToString());
				break;
			case 3:
				PlayerPrefs.SetString("LastCSActivityTime_4", this.LastCSActivityTime[bIndex].ToString());
				break;
			case 4:
				PlayerPrefs.SetString("LastCSActivityTime_5", this.LastCSActivityTime[bIndex].ToString());
				break;
			}
		}
		else if (Kind == 1)
		{
			switch (bIndex)
			{
			case 0:
				PlayerPrefs.SetString("LastSPActivityTime_1", this.LastSPActivityTime[bIndex].ToString());
				break;
			case 1:
				PlayerPrefs.SetString("LastSPActivityTime_2", this.LastSPActivityTime[bIndex].ToString());
				break;
			case 2:
				PlayerPrefs.SetString("LastSPActivityTime_3", this.LastSPActivityTime[bIndex].ToString());
				break;
			case 3:
				PlayerPrefs.SetString("LastSPActivityTime_4", this.LastSPActivityTime[bIndex].ToString());
				break;
			case 4:
				PlayerPrefs.SetString("LastSPActivityTime_5", this.LastSPActivityTime[bIndex].ToString());
				break;
			}
		}
	}

	// Token: 0x06000046 RID: 70 RVA: 0x000044B0 File Offset: 0x000026B0
	public void SavebShowNewActivity(int Kind, int bIndex)
	{
		if (Kind == 0)
		{
			switch (bIndex)
			{
			case 0:
				PlayerPrefs.SetString("bShowNewCSActivity_1", this.bShowNewCSActivity[bIndex].ToString());
				break;
			case 1:
				PlayerPrefs.SetString("bShowNewCSActivity_2", this.bShowNewCSActivity[bIndex].ToString());
				break;
			case 2:
				PlayerPrefs.SetString("bShowNewCSActivity_3", this.bShowNewCSActivity[bIndex].ToString());
				break;
			case 3:
				PlayerPrefs.SetString("bShowNewCSActivity_4", this.bShowNewCSActivity[bIndex].ToString());
				break;
			case 4:
				PlayerPrefs.SetString("bShowNewCSActivity_5", this.bShowNewCSActivity[bIndex].ToString());
				break;
			}
		}
		else if (Kind == 1)
		{
			switch (bIndex)
			{
			case 0:
				PlayerPrefs.SetString("bShowNewSPActivity_1", this.bShowNewSPActivity[bIndex].ToString());
				break;
			case 1:
				PlayerPrefs.SetString("bShowNewSPActivity_2", this.bShowNewSPActivity[bIndex].ToString());
				break;
			case 2:
				PlayerPrefs.SetString("bShowNewSPActivity_3", this.bShowNewSPActivity[bIndex].ToString());
				break;
			case 3:
				PlayerPrefs.SetString("bShowNewSPActivity_4", this.bShowNewSPActivity[bIndex].ToString());
				break;
			case 4:
				PlayerPrefs.SetString("bShowNewSPActivity_5", this.bShowNewSPActivity[bIndex].ToString());
				break;
			}
		}
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00004654 File Offset: 0x00002854
	public void CheckActivity(int Kind, int bIndex, long sTime)
	{
		if (Kind != 0)
		{
			if (Kind == 1)
			{
				if (sTime == 0L || sTime != this.LastSPActivityTime[bIndex])
				{
					this.LastSPActivityTime[bIndex] = sTime;
					this.SaveLastActivityTime(Kind, bIndex);
					this.SaveActivity(1, bIndex, sTime != 0L);
				}
			}
		}
		else if (sTime == 0L || sTime != this.LastCSActivityTime[bIndex])
		{
			this.LastCSActivityTime[bIndex] = sTime;
			this.SaveLastActivityTime(Kind, bIndex);
			this.SaveActivity(0, bIndex, sTime != 0L);
		}
		this.CheckActivityShow();
	}

	// Token: 0x06000048 RID: 72 RVA: 0x000046F0 File Offset: 0x000028F0
	public void SaveActivity(int Kind, int bIndex, bool bShow)
	{
		if (Kind != 0)
		{
			if (Kind == 1)
			{
				this.bShowNewSPActivity[bIndex] = bShow;
				this.SavebShowNewActivity(Kind, bIndex);
			}
		}
		else
		{
			this.bShowNewCSActivity[bIndex] = bShow;
			this.SavebShowNewActivity(Kind, bIndex);
		}
		this.CheckActivityShow();
	}

	// Token: 0x06000049 RID: 73 RVA: 0x00004744 File Offset: 0x00002944
	public void CheckNewsNo()
	{
		byte b = 0;
		if (this.DailyNewsLen > 0 && this.RcvDailyActNewsTime > this.ReadNewsTime)
		{
			for (int i = 0; i < (int)this.DailyNewsLen; i++)
			{
				for (int j = 0; j < (int)this.NewsDataLen; j++)
				{
					if (this.DailyNews[i] == this.NewsData[j].ID)
					{
						b += 1;
					}
				}
			}
		}
		byte b2 = 0;
		for (int k = 0; k < (int)this.NewsDataLen; k++)
		{
			if (this.NewsData[k].Time > this.ReadNewsTime)
			{
				b2 += 1;
			}
		}
		this.ShowNewsNo = (uint)((b <= b2) ? b2 : b);
		this.CheckActivityShow();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 8, 0);
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00004828 File Offset: 0x00002A28
	public void ClearNewsNo()
	{
		this.ReadNewsTime = DataManager.Instance.ServerTime;
		PlayerPrefs.SetString("ReadNewsTime", this.ReadNewsTime.ToString());
		this.CheckNewsNo();
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00004858 File Offset: 0x00002A58
	public void LoadActivity()
	{
		bool.TryParse(PlayerPrefs.GetString("bShowNewCSActivity_1"), out this.bShowNewCSActivity[0]);
		bool.TryParse(PlayerPrefs.GetString("bShowNewCSActivity_2"), out this.bShowNewCSActivity[1]);
		bool.TryParse(PlayerPrefs.GetString("bShowNewCSActivity_3"), out this.bShowNewCSActivity[2]);
		bool.TryParse(PlayerPrefs.GetString("bShowNewCSActivity_4"), out this.bShowNewCSActivity[3]);
		bool.TryParse(PlayerPrefs.GetString("bShowNewCSActivity_5"), out this.bShowNewCSActivity[4]);
		bool.TryParse(PlayerPrefs.GetString("bShowNewSPActivity_1"), out this.bShowNewSPActivity[0]);
		bool.TryParse(PlayerPrefs.GetString("bShowNewSPActivity_2"), out this.bShowNewSPActivity[1]);
		bool.TryParse(PlayerPrefs.GetString("bShowNewSPActivity_3"), out this.bShowNewSPActivity[2]);
		bool.TryParse(PlayerPrefs.GetString("bShowNewSPActivity_4"), out this.bShowNewSPActivity[3]);
		bool.TryParse(PlayerPrefs.GetString("bShowNewSPActivity_5"), out this.bShowNewSPActivity[4]);
		long.TryParse(PlayerPrefs.GetString("LastCSActivityTime_1"), out this.LastCSActivityTime[0]);
		long.TryParse(PlayerPrefs.GetString("LastCSActivityTime_2"), out this.LastCSActivityTime[1]);
		long.TryParse(PlayerPrefs.GetString("LastCSActivityTime_3"), out this.LastCSActivityTime[2]);
		long.TryParse(PlayerPrefs.GetString("LastCSActivityTime_4"), out this.LastCSActivityTime[3]);
		long.TryParse(PlayerPrefs.GetString("LastCSActivityTime_5"), out this.LastCSActivityTime[4]);
		long.TryParse(PlayerPrefs.GetString("LastSPActivityTime_1"), out this.LastSPActivityTime[0]);
		long.TryParse(PlayerPrefs.GetString("LastSPActivityTime_2"), out this.LastSPActivityTime[1]);
		long.TryParse(PlayerPrefs.GetString("LastSPActivityTime_3"), out this.LastSPActivityTime[2]);
		long.TryParse(PlayerPrefs.GetString("LastSPActivityTime_4"), out this.LastSPActivityTime[3]);
		long.TryParse(PlayerPrefs.GetString("LastSPActivityTime_5"), out this.LastSPActivityTime[4]);
		long.TryParse(PlayerPrefs.GetString("ReadNewsTime"), out this.ReadNewsTime);
		long.TryParse(PlayerPrefs.GetString("AMActivityTime"), out this.AMActivityTime);
		bool.TryParse(PlayerPrefs.GetString("bForceAMActivity"), out this.bForceAMActivity);
		long.TryParse(PlayerPrefs.GetString("NWActivityTime"), out this.NWActivityTime);
		byte.TryParse(PlayerPrefs.GetString("NWWonderID"), out this.NWWonderID);
		bool.TryParse(PlayerPrefs.GetString("bForceNWActivity"), out this.bForceNWActivity);
		long.TryParse(PlayerPrefs.GetString("AWActivityTime"), out this.AWActivityTime);
		byte.TryParse(PlayerPrefs.GetString("AWActivityFlash"), out this.AWActivityFlash);
		long.TryParse(PlayerPrefs.GetString("FIFAActivityTime"), out this.FIFAActivityTime);
		bool.TryParse(PlayerPrefs.GetString("bForceFIFAActivity"), out this.bForceFIFAActivity);
		bool.TryParse(PlayerPrefs.GetString("bClickFirstBuyActivity"), out this.bClickFirstBuyActivity);
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00004B88 File Offset: 0x00002D88
	public void ResetPara()
	{
		this.m_LastServerTime = 0L;
		this.m_ActivityKind = 1;
		this.m_ActivityIndex = 0;
		this.LastTimeIndex = -1;
		this.m_door = null;
		this.bAskFirstData = false;
		this.bAskSecondData = false;
		this.bAskDetailData = false;
		this.bCastleLevel = false;
		this.MonsterCount = 0;
		this.m_ActivityTime = 5f;
		this.Act1arg1 = -1;
		this.Act1Pos = Vector2.zero;
		this.Act2arg1 = -1;
		this.Act2Pos = Vector2.zero;
		this.Act4arg2 = -1;
		this.Act4Pos = Vector2.zero;
		for (int i = 0; i < 5; i++)
		{
			this.CSActivityTime[i] = -1L;
			this.bOpenCSActivity[i] = false;
		}
		for (int j = 0; j < 5; j++)
		{
			this.SPActivityTime[j] = -1L;
			this.bOpenSPActivity[j] = false;
		}
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00004C68 File Offset: 0x00002E68
	public void CheckNWActivityTime()
	{
		if (this.NobilityActivityData.EventState == EActivityState.EAS_None || this.NobilityActivityData.EventBeginTime == 0L || this.NWActivityTime != this.NobilityActivityData.EventBeginTime || this.NWWonderID != this.FederalFightingWonderID)
		{
			if (this.NobilityActivityData.EventState == EActivityState.EAS_None)
			{
				this.NWActivityTime = 0L;
			}
			else
			{
				this.NWActivityTime = this.NobilityActivityData.EventBeginTime;
			}
			PlayerPrefs.SetString("NWActivityTime", this.NWActivityTime.ToString());
			this.NWWonderID = this.FederalFightingWonderID;
			PlayerPrefs.SetString("NWWonderID", this.NWWonderID.ToString());
			this.SavebForceNWActivity(this.NobilityActivityData.EventBeginTime != 0L && this.NobilityActivityData.EventState == EActivityState.EAS_Run && this.FederalFightingWonderID == this.FederalActKingdomWonderID);
		}
		this.CheckNWShowHint();
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00004D60 File Offset: 0x00002F60
	public void SavebForceNWActivity(bool bForce)
	{
		this.bForceNWActivity = bForce;
		PlayerPrefs.SetString("bForceNWActivity", this.bForceNWActivity.ToString());
	}

	// Token: 0x0600004F RID: 79 RVA: 0x00004D80 File Offset: 0x00002F80
	public void CheckNWShowHint()
	{
		this.CheckActivityShow();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 14, 0);
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00004D98 File Offset: 0x00002F98
	public void CheckAMActivityTime()
	{
		if (this.AllyMobilizationData.EventState == EActivityState.EAS_None || this.AllyMobilizationData.EventBeginTime == 0L || this.AMActivityTime != this.AllyMobilizationData.EventBeginTime)
		{
			if (this.AllyMobilizationData.EventState == EActivityState.EAS_None)
			{
				this.AMActivityTime = 0L;
			}
			else
			{
				this.AMActivityTime = this.AllyMobilizationData.EventBeginTime;
			}
			PlayerPrefs.SetString("AMActivityTime", this.AMActivityTime.ToString());
			this.SavebForceAMActivity(this.AllyMobilizationData.EventBeginTime != 0L && this.AllyMobilizationData.EventState != EActivityState.EAS_None);
		}
		this.CheckAMShowHint();
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00004E50 File Offset: 0x00003050
	public void SavebForceAMActivity(bool bForce)
	{
		this.bForceAMActivity = bForce;
		PlayerPrefs.SetString("bForceAMActivity", this.bForceAMActivity.ToString());
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00004E70 File Offset: 0x00003070
	public void CheckAMShowHint()
	{
		if (this.bForceAMActivity)
		{
			this.bShowAMHint = true;
		}
		else
		{
			this.bShowAMHint = false;
			if (DataManager.Instance.RoleAlliance.Id > 0u)
			{
				MobilizationManager mobilizationManager = MobilizationManager.Instance;
				if (mobilizationManager.mMissionID != 0 && (mobilizationManager.mMissionStatus == 1 || mobilizationManager.mMissionStatus == 2))
				{
					this.bShowAMHint = true;
				}
				if (!this.bShowAMHint && this.AllyMobilizationData.EventState == EActivityState.EAS_ReplayRanking && GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 15 && mobilizationManager.AMCompleteDegree != 0 && this.AMAllianceID == DataManager.Instance.RoleAlliance.Id && !mobilizationManager.IsGetPrize())
				{
					this.bShowAMHint = true;
				}
			}
			if (MobilizationManager.Instance.AMGoldState == 2)
			{
				this.bShowAMHint = true;
			}
		}
		this.CheckActivityShow();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 11, 0);
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00004F80 File Offset: 0x00003180
	public void CheckAWActivityTime()
	{
		if (this.AllianceWarData.EventState == EActivityState.EAS_None || this.AllianceWarData.EventBeginTime == 0L || this.AWActivityTime != this.AllianceWarData.EventBeginTime)
		{
			if (this.AllianceWarData.EventState == EActivityState.EAS_None)
			{
				this.AWActivityTime = 0L;
			}
			else
			{
				this.AWActivityTime = this.AllianceWarData.EventBeginTime;
			}
			this.AWActivityFlash = 0;
			PlayerPrefs.SetString("AWActivityFlash", this.AWActivityFlash.ToString());
			PlayerPrefs.SetString("AWActivityTime", this.AWActivityTime.ToString());
		}
		this.CheckAWShowHint();
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00005028 File Offset: 0x00003228
	public void CheckAWActivityFlash()
	{
		if (this.AWActivityFlash == 1 || this.AWActivityFlash == 3)
		{
			this.AWActivityFlash += 1;
			PlayerPrefs.SetString("AWActivityFlash", this.AWActivityFlash.ToString());
			this.CheckAWShowHint();
		}
	}

	// Token: 0x06000055 RID: 85 RVA: 0x00005078 File Offset: 0x00003278
	public void CheckAWShowHint()
	{
		this.bShowAWHint = false;
		if (this.AllianceWarData.EventState == EActivityState.EAS_Prepare)
		{
			if (this.AWActivityFlash == 0)
			{
				this.AWActivityFlash = 1;
			}
		}
		else if (this.AllianceWarData.EventState == EActivityState.EAS_ReplayRanking && this.AW_OneRoundTime != 0u)
		{
			if (this.AW_State == EAllianceWarState.EAWS_Run)
			{
				if (this.AWActivityFlash < 3)
				{
					this.AWActivityFlash = 3;
				}
			}
			else if (this.AW_State == EAllianceWarState.EAWS_Replay && DataManager.Instance.RoleAlliance.Id > 0u && !this.bShowAWHint && this.AllianceWarData.EventState == EActivityState.EAS_ReplayRanking && this.AW_State == EAllianceWarState.EAWS_Replay && this.AW_NowAllianceEnterWar != 0 && this.AW_SignUpAllianceID == DataManager.Instance.RoleAlliance.Id && this.AW_GetGift == 0)
			{
				this.bShowAWHint = true;
			}
		}
		if (this.AWActivityFlash == 1 || this.AWActivityFlash == 3)
		{
			this.bShowAWHint = true;
		}
		this.CheckActivityShow();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 16, 0);
	}

	// Token: 0x06000056 RID: 86 RVA: 0x000051A8 File Offset: 0x000033A8
	public void CheckFIFAActivityTime()
	{
		int num = 2;
		if (this.FIFAData[num].EventState == EActivityState.EAS_None || this.FIFAData[num].EventBeginTime == 0L || this.FIFAActivityTime != this.FIFAData[num].EventBeginTime)
		{
			if (this.FIFAData[num].EventState == EActivityState.EAS_None)
			{
				this.FIFAActivityTime = 0L;
			}
			else
			{
				this.FIFAActivityTime = this.FIFAData[num].EventBeginTime;
			}
			PlayerPrefs.SetString("FIFAActivityTime", this.FIFAActivityTime.ToString());
			this.SavebForceFIFAActivity(this.FIFAData[num].EventBeginTime != 0L && this.FIFAData[num].EventState != EActivityState.EAS_None);
		}
		this.CheckFIFAShowHint();
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00005270 File Offset: 0x00003470
	public void SavebForceFIFAActivity(bool bForce)
	{
		this.bForceFIFAActivity = bForce;
		PlayerPrefs.SetString("bForceFIFAActivity", this.bForceFIFAActivity.ToString());
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00005290 File Offset: 0x00003490
	public void CheckFIFAShowHint()
	{
		if (this.bForceFIFAActivity)
		{
			this.bShowFIFAHint = true;
		}
		else
		{
			this.bShowFIFAHint = false;
		}
		this.CheckActivityShow();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 18, 0);
	}

	// Token: 0x06000059 RID: 89 RVA: 0x000052C8 File Offset: 0x000034C8
	private void CheckCountTime(EActivityCircleEventType eType)
	{
		if (eType != EActivityCircleEventType.EACET_MAX)
		{
			switch (this.ActivityData[(int)eType].EventState)
			{
			case EActivityState.EAS_None:
				this.ActivityData[(int)eType].EventCountTime = 0L;
				break;
			case EActivityState.EAS_Run:
				this.ActivityData[(int)eType].EventCountTime = this.ActivityData[(int)eType].EventBeginTime + (long)((ulong)this.ActivityData[(int)eType].EventReqiureTIme) - DataManager.Instance.ServerTime;
				break;
			case EActivityState.EAS_Prepare:
				this.ActivityData[(int)eType].EventCountTime = this.ActivityData[(int)eType].EventBeginTime - DataManager.Instance.ServerTime;
				break;
			}
			if (this.ActivityData[(int)eType].EventCountTime < 0L)
			{
				this.ActivityData[(int)eType].EventCountTime = 0L;
			}
		}
	}

	// Token: 0x0600005A RID: 90 RVA: 0x000053A0 File Offset: 0x000035A0
	private void CheckKVKCountTime(EKVKActivityType eType)
	{
		if (eType != EKVKActivityType.EKAT_MAX)
		{
			switch (this.KvKActivityData[(int)eType].EventState)
			{
			case EActivityState.EAS_None:
			case EActivityState.EAS_ReplayRanking:
				this.KvKActivityData[(int)eType].EventCountTime = 0L;
				break;
			case EActivityState.EAS_Run:
			case EActivityState.EAS_HomeStart:
			case EActivityState.EAS_HomeEnd:
			case EActivityState.EAS_StartRanking:
				this.KvKActivityData[(int)eType].EventCountTime = this.KvKActivityData[(int)eType].EventBeginTime + (long)((ulong)this.KvKActivityData[(int)eType].EventReqiureTIme) - DataManager.Instance.ServerTime;
				break;
			case EActivityState.EAS_Prepare:
				this.KvKActivityData[(int)eType].EventCountTime = this.KvKActivityData[(int)eType].EventBeginTime - DataManager.Instance.ServerTime;
				break;
			}
			if (this.KvKActivityData[(int)eType].EventCountTime < 0L)
			{
				this.KvKActivityData[(int)eType].EventCountTime = 0L;
			}
		}
	}

	// Token: 0x0600005B RID: 91 RVA: 0x00005488 File Offset: 0x00003688
	private void CheckAMCountTime()
	{
		switch (this.AllyMobilizationData.EventState)
		{
		case EActivityState.EAS_None:
			this.AllyMobilizationData.EventCountTime = 0L;
			break;
		case EActivityState.EAS_Run:
		case EActivityState.EAS_HomeStart:
		case EActivityState.EAS_HomeEnd:
		case EActivityState.EAS_StartRanking:
		case EActivityState.EAS_ReplayRanking:
			this.AllyMobilizationData.EventCountTime = this.AllyMobilizationData.EventBeginTime + (long)((ulong)this.AllyMobilizationData.EventReqiureTIme) - DataManager.Instance.ServerTime;
			break;
		case EActivityState.EAS_Prepare:
			this.AllyMobilizationData.EventCountTime = this.AllyMobilizationData.EventBeginTime - DataManager.Instance.ServerTime;
			break;
		}
		if (this.AllyMobilizationData.EventCountTime < 0L)
		{
			this.AllyMobilizationData.EventCountTime = 0L;
		}
	}

	// Token: 0x0600005C RID: 92 RVA: 0x00005554 File Offset: 0x00003754
	private void CheckKOWCountTime()
	{
		switch (this.KOWData.EventState)
		{
		case EActivityState.EAS_None:
			this.KOWData.EventCountTime = 0L;
			break;
		case EActivityState.EAS_Run:
		case EActivityState.EAS_HomeStart:
		case EActivityState.EAS_HomeEnd:
		case EActivityState.EAS_StartRanking:
		case EActivityState.EAS_ReplayRanking:
			this.KOWData.EventCountTime = this.KOWData.EventBeginTime + (long)((ulong)this.KOWData.EventReqiureTIme) - DataManager.Instance.ServerTime;
			break;
		case EActivityState.EAS_Prepare:
			this.KOWData.EventCountTime = this.KOWData.EventBeginTime - DataManager.Instance.ServerTime;
			break;
		}
		if (this.KOWData.EventCountTime < 0L)
		{
			this.KOWData.EventCountTime = 0L;
		}
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00005620 File Offset: 0x00003820
	private void CheckASCountTime()
	{
		switch (this.AllianceSummonData.EventState)
		{
		case EActivityState.EAS_None:
			this.AllianceSummonData.EventCountTime = 0L;
			break;
		case EActivityState.EAS_Run:
		case EActivityState.EAS_HomeStart:
		case EActivityState.EAS_HomeEnd:
		case EActivityState.EAS_StartRanking:
		case EActivityState.EAS_ReplayRanking:
			this.AllianceSummonData.EventCountTime = this.AllianceSummonData.EventBeginTime + (long)((ulong)this.AllianceSummonData.EventReqiureTIme) - DataManager.Instance.ServerTime;
			break;
		case EActivityState.EAS_Prepare:
			this.AllianceSummonData.EventCountTime = this.AllianceSummonData.EventBeginTime - DataManager.Instance.ServerTime;
			break;
		}
		if (this.AllianceSummonData.EventCountTime < 0L)
		{
			this.AllianceSummonData.EventCountTime = 0L;
		}
	}

	// Token: 0x0600005E RID: 94 RVA: 0x000056EC File Offset: 0x000038EC
	private void CheckNWCountTime()
	{
		switch (this.NobilityActivityData.EventState)
		{
		case EActivityState.EAS_None:
			this.NobilityActivityData.EventCountTime = 0L;
			break;
		case EActivityState.EAS_Run:
		case EActivityState.EAS_HomeStart:
		case EActivityState.EAS_HomeEnd:
		case EActivityState.EAS_StartRanking:
		case EActivityState.EAS_ReplayRanking:
			this.NobilityActivityData.EventCountTime = this.NobilityActivityData.EventBeginTime + (long)((ulong)this.NobilityActivityData.EventReqiureTIme) - DataManager.Instance.ServerTime;
			break;
		case EActivityState.EAS_Prepare:
			this.NobilityActivityData.EventCountTime = this.NobilityActivityData.EventBeginTime - DataManager.Instance.ServerTime;
			break;
		}
		if (this.NobilityActivityData.EventCountTime < 0L)
		{
			this.NobilityActivityData.EventCountTime = 0L;
		}
	}

	// Token: 0x0600005F RID: 95 RVA: 0x000057B8 File Offset: 0x000039B8
	private void CheckAWCountTime(bool bLogin = false)
	{
		switch (this.AllianceWarData.EventState)
		{
		case EActivityState.EAS_None:
			this.AllianceWarData.EventCountTime = 0L;
			break;
		case EActivityState.EAS_Run:
		case EActivityState.EAS_HomeStart:
		case EActivityState.EAS_HomeEnd:
		case EActivityState.EAS_StartRanking:
		case EActivityState.EAS_ReplayRanking:
			this.AllianceWarData.EventCountTime = this.AllianceWarData.EventBeginTime + (long)((ulong)this.AllianceWarData.EventReqiureTIme) - this.ServerEventTime;
			break;
		case EActivityState.EAS_Prepare:
			this.AllianceWarData.EventCountTime = this.AllianceWarData.EventBeginTime - this.ServerEventTime;
			break;
		}
		if (this.AllianceWarData.EventCountTime < 0L)
		{
			this.AllianceWarData.EventCountTime = 0L;
		}
		if (!bLogin && this.AllianceWarData.EventState == EActivityState.EAS_ReplayRanking)
		{
			this.SetNowState(true);
		}
	}

	// Token: 0x06000060 RID: 96 RVA: 0x00005898 File Offset: 0x00003A98
	private void CheckNPCCityCountTime()
	{
		if (this.NPCCityEndTime == 0L)
		{
			this.NPCCityCountTime = 0L;
		}
		else
		{
			this.NPCCityCountTime = this.NPCCityEndTime - DataManager.Instance.ServerTime;
			if (this.NPCCityCountTime < 0L)
			{
				this.NPCCityCountTime = 0L;
			}
		}
	}

	// Token: 0x06000061 RID: 97 RVA: 0x000058EC File Offset: 0x00003AEC
	private void CheckFIFACountTime(EActivityKingdomEventType eType)
	{
		if (eType != EActivityKingdomEventType.EAKET_MAX)
		{
			switch (this.FIFAData[(int)eType].EventState)
			{
			case EActivityState.EAS_None:
			case EActivityState.EAS_ReplayRanking:
				this.FIFAData[(int)eType].EventCountTime = 0L;
				break;
			case EActivityState.EAS_Run:
			case EActivityState.EAS_HomeStart:
			case EActivityState.EAS_HomeEnd:
			case EActivityState.EAS_StartRanking:
				this.FIFAData[(int)eType].EventCountTime = this.FIFAData[(int)eType].EventBeginTime + (long)((ulong)this.FIFAData[(int)eType].EventReqiureTIme) - DataManager.Instance.ServerTime;
				break;
			case EActivityState.EAS_Prepare:
				this.FIFAData[(int)eType].EventCountTime = this.FIFAData[(int)eType].EventBeginTime - DataManager.Instance.ServerTime;
				break;
			}
			if (this.FIFAData[(int)eType].EventCountTime < 0L)
			{
				this.FIFAData[(int)eType].EventCountTime = 0L;
			}
		}
	}

	// Token: 0x06000062 RID: 98 RVA: 0x000059D4 File Offset: 0x00003BD4
	private void SetActivityBtn()
	{
		if (this.door != null)
		{
			this.TimeStr.Length = 0;
			this.door.m_FlashKVKImg.enabled = false;
			if (this.m_ActivityKind == 0)
			{
				this.door.m_ActivityBackSA.SetSpriteIndex(5);
				this.TimeStr.Append(DataManager.Instance.mStringTable.GetStringByID(8168u));
			}
			else if (this.m_ActivityKind == 1)
			{
				this.door.m_ActivityBackSA.SetSpriteIndex(this.m_ActivityIndex);
				this.TimeStr.Append(this.GetActivityName(this.ActivityData[this.m_ActivityIndex].ActiveType, true));
				this.TimeStr.Append(" ");
				GameConstants.GetTimeString(this.TimeStr, (uint)this.ActivityData[this.m_ActivityIndex].EventCountTime, false, true, false, false, true);
			}
			else if (this.m_ActivityKind != 2)
			{
				if (this.m_ActivityKind == 4)
				{
					this.door.m_ActivityBackSA.SetSpriteIndex(6);
					if (this.IsMatchKvk())
					{
						this.TimeStr.Append(DataManager.Instance.mStringTable.GetStringByID(12004u));
					}
					else
					{
						this.TimeStr.Append(DataManager.Instance.mStringTable.GetStringByID(9853u));
					}
					this.door.m_FlashKVKImg.enabled = true;
				}
			}
			this.door.m_ActivityBtnImg.SetNativeSize();
			this.door.m_ActivityTitleText.text = this.TimeStr.ToString();
			this.door.m_ActivityTitleText.SetAllDirty();
			this.door.m_ActivityTitleText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06000063 RID: 99 RVA: 0x00005BAC File Offset: 0x00003DAC
	public void SetActivityBtnToFirst()
	{
		this.m_ActivityKind = 1;
		this.m_ActivityIndex = 0;
		this.m_ActivityTime = 4.7f;
		this.SetActivityBtn();
		if (this.door != null)
		{
			this.door.m_ActivityBtnCG.alpha = 1f;
		}
	}

	// Token: 0x06000064 RID: 100 RVA: 0x00005C00 File Offset: 0x00003E00
	private void UpDateKVKCountTime()
	{
		ActivityDataType activityDataType = this.KvKActivityData[4];
		if (activityDataType.EventState == EActivityState.EAS_Prepare)
		{
			if (!this.bShowRunningP && activityDataType.EventBeginTime != 0L && activityDataType.EventBeginTime - DataManager.Instance.ServerTime == 600L)
			{
				this.bShowRunningP = true;
				CString cstring = StringManager.Instance.SpawnString(300);
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(9375u));
				GUIManager.Instance.WonderCountStr.Add(cstring);
				GUIManager.Instance.SetRunningText(cstring);
			}
		}
		else if (activityDataType.EventState == EActivityState.EAS_Run && !this.bShowRunningE && activityDataType.EventBeginTime != 0L)
		{
			long num = activityDataType.EventBeginTime + (long)((ulong)activityDataType.EventReqiureTIme);
			if (num - DataManager.Instance.ServerTime == 600L)
			{
				this.bShowRunningE = true;
				CString cstring2 = StringManager.Instance.SpawnString(300);
				cstring2.Append(DataManager.Instance.mStringTable.GetStringByID(9377u));
				GUIManager.Instance.WonderCountStr.Add(cstring2);
				GUIManager.Instance.SetRunningText(cstring2);
			}
		}
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00005D3C File Offset: 0x00003F3C
	public void Update()
	{
		if (this.bAskFirstData)
		{
			this.UpDateKVKCountTime();
			this.UpDateFIFARunningtext();
			if (DataManager.Instance.ServerTime != this.m_LastServerTime)
			{
				this.m_LastServerTime = DataManager.Instance.ServerTime;
				this.CheckRunningText();
				int num = 2;
				for (int i = 0; i < num; i++)
				{
					if (this.ActivityData[i] != null)
					{
						this.CheckCountTime((EActivityCircleEventType)i);
					}
				}
				num = 5;
				for (int j = 0; j < num; j++)
				{
					if (this.KvKActivityData[j] != null)
					{
						this.CheckKVKCountTime((EKVKActivityType)j);
					}
				}
				num = 3;
				for (int k = 0; k < num; k++)
				{
					if (this.FIFAData[k] != null)
					{
						this.CheckFIFACountTime((EActivityKingdomEventType)k);
					}
				}
				this.CheckAMCountTime();
				this.CheckKOWCountTime();
				this.CheckNPCCityCountTime();
				this.CheckASCountTime();
				this.CheckNWCountTime();
				this.CheckAWCountTime(false);
				if (this.m_ActivityKind == 1)
				{
					this.SetActivityBtn();
				}
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 1, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 3, 0);
				if (GUIManager.Instance.m_ActivityWindow != null)
				{
					GUIManager.Instance.m_ActivityWindow.UpdateTime();
				}
			}
			if (this.door != null && this.LastTimeIndex == -1)
			{
				byte activityKind = this.m_ActivityKind;
				int activityIndex = this.m_ActivityIndex;
				if (this.IsInKvK(0, false))
				{
					if (this.m_ActivityKind != 4)
					{
						this.m_ActivityKind = 4;
						this.SetActivityBtn();
						this.door.m_ActivityBtnCG.alpha = 1f;
					}
				}
				else if (this.m_ActivityKind == 4)
				{
					this.m_ActivityKind = 1;
					this.m_ActivityIndex = 0;
					this.SetActivityBtn();
				}
				else
				{
					bool flag = false;
					this.m_ActivityTime -= Time.unscaledDeltaTime;
					if (this.m_ActivityTime <= 0f || (this.m_ActivityKind == 1 && this.ActivityData[this.m_ActivityIndex].EventState != EActivityState.EAS_Run))
					{
						if (this.m_ActivityKind == 1)
						{
							this.m_ActivityIndex++;
						}
						for (int l = 0; l <= 3; l++)
						{
							if (this.m_ActivityKind == 1 && this.m_ActivityIndex >= 2)
							{
								this.m_ActivityKind = 1;
								this.m_ActivityIndex = 0;
								flag = true;
								break;
							}
							if (this.m_ActivityKind == 1 && this.ActivityData[this.m_ActivityIndex].EventState == EActivityState.EAS_Run)
							{
								flag = true;
								break;
							}
							this.m_ActivityIndex++;
						}
						if (!flag || (activityKind == this.m_ActivityKind && activityIndex == this.m_ActivityIndex))
						{
							this.m_ActivityIndex = 0;
							this.m_ActivityTime = 4.7f;
						}
						else
						{
							this.m_ActivityTime = 5f;
						}
						this.SetActivityBtn();
					}
					if (this.m_ActivityTime > 4.7f)
					{
						this.door.m_ActivityBtnCG.alpha = Mathf.Lerp(0f, 1f, (5f - this.m_ActivityTime) / 0.3f);
					}
					else
					{
						this.door.m_ActivityBtnCG.alpha = 1f;
					}
				}
			}
		}
		if (!this.bNeedSendUpData)
		{
			this.NeedSendUpDataTime -= Time.unscaledDeltaTime;
			if (this.NeedSendUpDataTime <= 0f)
			{
				this.bNeedSendUpData = true;
				this.NeedSendUpDataTime = 180f;
			}
		}
	}

	// Token: 0x06000066 RID: 102 RVA: 0x000060E0 File Offset: 0x000042E0
	public string GetActivityName(EActivityType type, bool bShort = false)
	{
		switch (type)
		{
		case EActivityType.EAT_SoloEvent:
			return DataManager.Instance.mStringTable.GetStringByID((!bShort) ? 8101u : 8156u);
		case EActivityType.EAT_InfernalEvent:
			return DataManager.Instance.mStringTable.GetStringByID((!bShort) ? 8102u : 8157u);
		case EActivityType.EAT_ComingSoonSpEvent:
			return DataManager.Instance.mStringTable.GetStringByID((!bShort) ? 8106u : 8106u);
		case EActivityType.EAT_SpecialEvent:
			return DataManager.Instance.mStringTable.GetStringByID((!bShort) ? 8105u : 8105u);
		}
		return string.Empty;
	}

	// Token: 0x06000067 RID: 103 RVA: 0x000061AC File Offset: 0x000043AC
	public void ChangeStateReOpenMenu(byte index)
	{
		this.bReOpen = true;
		if (index == 207)
		{
			if (this.KOWData.EventState == EActivityState.EAS_ReplayRanking && !this.KOWData.bAskDetailData)
			{
				this.Send_KINGOFTHEWORLD_KINGINFO();
			}
			else
			{
				this.bReOpen = false;
				if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity2))
				{
					this.door.CloseMenu(false);
				}
				this.door.OpenMenu(EGUIWindow.UI_Activity2, 207, 0, true);
			}
		}
		else if (index == 208)
		{
			this.Send_ACTIVITY_EVENT_LIST_SINGLE(11);
		}
		else if (index == 209)
		{
			this.NobilityActivityData.bAskDetailData = false;
			this.Send_FEDERAL_ORDERLIST();
		}
		else if (index >= 201 && index <= 205)
		{
			this.KvKActivityData[(int)(index - 201)].bAskDetailData = false;
			this.Send_ACTIVITY_KEVENT_LIST_SINGLE(index);
			this.Send_ACTIVITY_KEVENT_DETAIL(index);
		}
		else if (index >= 211 && index <= 213)
		{
			this.FIFAData[(int)(index - 211)].bAskDetailData = false;
			this.Send_FIFA_LIST_SINGLE(index);
			this.Send_FIFA_DETAIL(index);
		}
		else if ((int)index < this.ActivityData.Length)
		{
			this.ActivityData[(int)index].bAskDetailData = false;
			this.Send_ACTIVITY_EVENT_LIST_SINGLE(index);
			this.Send_ACTIVITY_EVENT_DETAIL(index);
		}
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00006318 File Offset: 0x00004518
	public void ChangeStateReOpenPrize(byte index)
	{
		this.bReOpenPrize = true;
		if (index == 206)
		{
			this.Send_ACTIVITY_AM_RANKING_PRIZE();
		}
		else if (index == 210)
		{
			this.Send_REQUEST_ALLIANCEWAR_RANKPRIZE();
		}
		else if (index >= 201 && index <= 205)
		{
			this.KvKActivityData[(int)(index - 201)].bAskDetailData = false;
			this.Send_ACTIVITY_KEVENT_LIST_SINGLE(index);
			this.Send_ACTIVITY_KEVENT_DETAIL(index);
			this.Send_ACTIVITY_KEVENT_RANKING_PRIZE(index);
		}
		else if (index >= 211 && index <= 213)
		{
			this.FIFAData[(int)(index - 211)].bAskDetailData = false;
			this.Send_FIFA_LIST_SINGLE(index);
			this.Send_FIFA_DETAIL(index);
			this.Send_FIFA_RANKING_PRIZE(index);
		}
		else if ((int)index < this.ActivityData.Length)
		{
			this.ActivityData[(int)index].bAskDetailData = false;
			this.Send_ACTIVITY_EVENT_LIST_SINGLE(index);
			this.Send_ACTIVITY_EVENT_DETAIL(index);
			this.Send_ACTIVITY_RANKING_PRIZE(index);
		}
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00006414 File Offset: 0x00004614
	public void CheckCastleLevel()
	{
		GUIManager guimanager = GUIManager.Instance;
		bool flag = this.bCastleLevel;
		if (guimanager.BuildingData.GetBuildData(8, 0).Level >= 5)
		{
			this.bCastleLevel = true;
		}
		if (this.door != null && !flag && this.bCastleLevel)
		{
			this.door.CheckSetShowActivityBtn();
			this.SetActivityBtn();
		}
		this.CheckFirstBuyShowHint();
		guimanager.UpdateUI(EGUIWindow.UI_Chat, 13, 0);
		guimanager.UpdateUI(EGUIWindow.UI_MessageBoard, 5, 0);
		guimanager.UpdateUI(EGUIWindow.UI_Activity1, 19, 0);
		guimanager.UpdateUI(EGUIWindow.UI_Activity3, 4, 0);
		guimanager.UpdateUI(EGUIWindow.Door, 20, 0);
	}

	// Token: 0x0600006A RID: 106 RVA: 0x000064C0 File Offset: 0x000046C0
	public void SetbOpenCSActivity(byte Index, bool value)
	{
		this.bOpenCSActivity[(int)Index] = value;
		if (!value)
		{
			this.Act1Pos = Vector2.zero;
		}
	}

	// Token: 0x0600006B RID: 107 RVA: 0x000064DC File Offset: 0x000046DC
	public void SetbOpenSPActivity(byte Index, bool value)
	{
		this.bOpenSPActivity[(int)Index] = value;
		if (!value)
		{
			this.Act1Pos = Vector2.zero;
		}
	}

	// Token: 0x0600006C RID: 108 RVA: 0x000064F8 File Offset: 0x000046F8
	public void SetbOpenKvKActivity(bool value)
	{
		this.bOpenKvKActivity = value;
	}

	// Token: 0x0600006D RID: 109 RVA: 0x00006504 File Offset: 0x00004704
	public EActivityState GetKvKState()
	{
		return this.KvKActivityData[4].EventState;
	}

	// Token: 0x0600006E RID: 110 RVA: 0x00006514 File Offset: 0x00004714
	public bool IsInKvK(ushort KingdomID = 0, bool bExceptRanking = false)
	{
		if (KingdomID == 0)
		{
			if (this.IsInFIFA_KVK(0, bExceptRanking))
			{
				return true;
			}
			EActivityState eventState = this.KvKActivityData[4].EventState;
			if (bExceptRanking)
			{
				return eventState == EActivityState.EAS_Run;
			}
			return eventState > EActivityState.EAS_None && eventState < EActivityState.EAS_ReplayRanking && eventState != EActivityState.EAS_Prepare;
		}
		else
		{
			if (KingdomID == DataManager.MapDataController.kingdomData.kingdomID)
			{
				return DataManager.MapDataController.kingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK;
			}
			if (KingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
			{
				return DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK;
			}
			if (KingdomID == DataManager.MapDataController.FocusKingdomID)
			{
				return DataManager.MapDataController.FocusKingdomPeriod == KINGDOM_PERIOD.KP_KVK;
			}
			byte b = 0;
			return DataManager.MapDataController.GetWorldKingdomTableID(KingdomID, out b) && DataManager.MapDataController.WorldKingdomTable[(int)b].kingdomPeriod == KINGDOM_PERIOD.KP_KVK;
		}
	}

	// Token: 0x0600006F RID: 111 RVA: 0x00006604 File Offset: 0x00004804
	public bool IsMatchKvk()
	{
		return this.KvKActivityData[4].ActiveType == EActivityType.EAT_KingdomMatchEvent;
	}

	// Token: 0x06000070 RID: 112 RVA: 0x00006618 File Offset: 0x00004818
	public bool CheckIsMatchKingdom(ushort KingdomID)
	{
		int num = 0;
		while (num < (int)this.MatchKingdomIDCount && num < 6)
		{
			if (this.MatchKingdomID[num] == 0)
			{
				return false;
			}
			if (this.MatchKingdomID[num] == KingdomID)
			{
				return true;
			}
			num++;
		}
		return false;
	}

	// Token: 0x06000071 RID: 113 RVA: 0x00006664 File Offset: 0x00004864
	public bool IsMatchKvk_kingdom(ushort KingdomID)
	{
		return this.IsMatchKvk() && this.CheckIsMatchKingdom(KingdomID);
	}

	// Token: 0x06000072 RID: 114 RVA: 0x0000667C File Offset: 0x0000487C
	public bool IsKOWRunning(bool bIncludeRanking = false)
	{
		if (bIncludeRanking)
		{
			return this.KOWData.EventState == EActivityState.EAS_Run || this.KOWData.EventState == EActivityState.EAS_ReplayRanking;
		}
		return this.KOWData.EventState == EActivityState.EAS_Run;
	}

	// Token: 0x06000073 RID: 115 RVA: 0x000066B8 File Offset: 0x000048B8
	public byte GetHuntBonusRate(byte index, EGetScoreFactor tmpFactor)
	{
		if (index == 203 || index == 211)
		{
			index = 0;
		}
		else if (index == 204 || index == 212)
		{
			index = 1;
		}
		else
		{
			if (index != 205 && index != 213)
			{
				return 0;
			}
			index = 2;
		}
		for (int i = 0; i < 6; i++)
		{
			if (this.GetHuntFactor[(int)index][i].Factor == tmpFactor)
			{
				return this.GetHuntFactor[(int)index][i].BonusRate;
			}
		}
		return 0;
	}

	// Token: 0x06000074 RID: 116 RVA: 0x00006764 File Offset: 0x00004964
	public void UpDateKvKState(EActivityState OldState)
	{
		EActivityState eventState = this.KvKActivityData[4].EventState;
		if (eventState > EActivityState.EAS_None && eventState < EActivityState.EAS_ReplayRanking && eventState != EActivityState.EAS_Prepare)
		{
			DataManager.MapDataController.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_KVK;
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.kingdomData.kingdomID)
			{
				DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_KVK;
			}
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
			{
				DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_KVK;
			}
			else if (this.IsMatchKvk())
			{
				for (int i = 0; i < this.MatchKingdomID.Length; i++)
				{
					if (this.MatchKingdomID[i] != 0 && this.MatchKingdomID[i] == DataManager.MapDataController.FocusKingdomID)
					{
						DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_KVK;
						break;
					}
				}
			}
			if (eventState != EActivityState.EAS_Run)
			{
				DataManager.MapDataController.UpdateKingdomPeriod(KINGDOM_PERIOD.KP_KVK);
			}
		}
		else if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
		{
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.kingdomData.kingdomID)
			{
				DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
			}
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
			{
				DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
			}
			else if (this.IsMatchKvk())
			{
				for (int j = 0; j < this.MatchKingdomID.Length; j++)
				{
					if (this.MatchKingdomID[j] != 0 && this.MatchKingdomID[j] == DataManager.MapDataController.FocusKingdomID)
					{
						if (DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_WORLD_WAR)
						{
							DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
						}
						break;
					}
				}
			}
		}
		else
		{
			DataManager.MapDataController.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.kingdomData.kingdomID)
			{
				DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
			}
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
			{
				DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
			}
			else if (this.IsMatchKvk())
			{
				for (int k = 0; k < this.MatchKingdomID.Length; k++)
				{
					if (this.MatchKingdomID[k] != 0 && this.MatchKingdomID[k] == DataManager.MapDataController.FocusKingdomID)
					{
						DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
						break;
					}
				}
			}
		}
		this.reflashKvKKingdomType();
		if (OldState != eventState)
		{
			if (eventState == EActivityState.EAS_Run)
			{
				DataManager.MapDataController.UpdateKingdomPeriod(KINGDOM_PERIOD.KP_KVK);
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 25, 0);
				DataManager.msgBuffer[0] = 53;
				DataManager.msgBuffer[1] = 1;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			else if (eventState == EActivityState.EAS_ReplayRanking)
			{
				DataManager.MapDataController.UpdateKingdomPeriod(KINGDOM_PERIOD.KP_INFIGHTING);
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 25, 0);
				DataManager.msgBuffer[0] = 53;
				DataManager.msgBuffer[1] = 1;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Info, 6, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 6, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena_Info, 2, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 25, 0);
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00006AF4 File Offset: 0x00004CF4
	private void SettmpKvKTypeByIndex(byte index)
	{
		if (index < 201 || index > 205)
		{
			this.tmpActivityType = EActivityType.EAT_MAX;
			this.tmpActivityKingdomEventType = EActivityKingdomEventType.EAKET_MAX;
			return;
		}
		if (index < 203)
		{
			this.tmpActivityType = EActivityType.EAT_KingdomNormalEvent;
		}
		else
		{
			this.tmpActivityType = this.KvKActivityData[4].ActiveType;
		}
		if (index == 201 || index == 203)
		{
			this.tmpActivityKingdomEventType = EActivityKingdomEventType.EAKET_SoloEvent;
		}
		else if (index == 202 || index == 204)
		{
			this.tmpActivityKingdomEventType = EActivityKingdomEventType.EAKET_AllianceEvent;
		}
		else
		{
			this.tmpActivityKingdomEventType = EActivityKingdomEventType.EAKET_KingdomEvent;
		}
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00006B9C File Offset: 0x00004D9C
	public int GetKvkDataIndexByType(EActivityType InType, EActivityKingdomEventType InKvKType)
	{
		if (InType != EActivityType.EAT_KingdomKillEvent)
		{
			if (InType != EActivityType.EAT_KingdomNormalEvent)
			{
				if (InType != EActivityType.EAT_FIFA && InType != EActivityType.EAT_FIFA_KVK)
				{
					if (InType == EActivityType.EAT_KingdomMatchEvent)
					{
						switch (InKvKType)
						{
						case EActivityKingdomEventType.EAKET_SoloEvent:
							return 203;
						case EActivityKingdomEventType.EAKET_AllianceEvent:
							return 204;
						case EActivityKingdomEventType.EAKET_KingdomEvent:
							return 205;
						}
					}
				}
				else
				{
					switch (InKvKType)
					{
					case EActivityKingdomEventType.EAKET_SoloEvent:
						return 211;
					case EActivityKingdomEventType.EAKET_AllianceEvent:
						return 212;
					case EActivityKingdomEventType.EAKET_KingdomEvent:
						return 213;
					}
				}
			}
			else
			{
				if (InKvKType == EActivityKingdomEventType.EAKET_SoloEvent)
				{
					return 201;
				}
				if (InKvKType == EActivityKingdomEventType.EAKET_AllianceEvent)
				{
					return 202;
				}
			}
		}
		else
		{
			switch (InKvKType)
			{
			case EActivityKingdomEventType.EAKET_SoloEvent:
				return 203;
			case EActivityKingdomEventType.EAKET_AllianceEvent:
				return 204;
			case EActivityKingdomEventType.EAKET_KingdomEvent:
				return 205;
			}
		}
		return -1;
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00006C8C File Offset: 0x00004E8C
	public bool IsNobilityWarRunning(bool bCheckMyGroup = false)
	{
		if (bCheckMyGroup)
		{
			return this.NobilityActivityData.EventState == EActivityState.EAS_Run && this.FederalActKingdomWonderID != 0 && this.FederalActKingdomWonderID == this.FederalFullEventTimeWonderID;
		}
		return this.NobilityActivityData.EventState == EActivityState.EAS_Run;
	}

	// Token: 0x06000078 RID: 120 RVA: 0x00006CDC File Offset: 0x00004EDC
	public EKvKKingdomType getKvKKingdomType(ushort checkKingdomID)
	{
		if (this.KVKHuntOrder > 0 && this.KvKActivityData[4].EventState == EActivityState.EAS_Run)
		{
			for (int i = 0; i < (int)this.MatchKingdomIDCount; i++)
			{
				if (this.MatchKingdomID[i] == DataManager.MapDataController.kingdomData.kingdomID)
				{
					int j = 0;
					while (j < (int)this.MatchKingdomIDCount)
					{
						if (this.MatchKingdomID[j] == checkKingdomID)
						{
							if ((j == (int)(this.MatchKingdomIDCount - 1) && i == 0) || j == i - 1)
							{
								return (this.KVKHuntOrder != 1) ? EKvKKingdomType.EKKT_Target : EKvKKingdomType.EKKT_Hunter;
							}
							if ((i == (int)(this.MatchKingdomIDCount - 1) && j == 0) || j == i + 1)
							{
								return (this.KVKHuntOrder != 1) ? EKvKKingdomType.EKKT_Hunter : EKvKKingdomType.EKKT_Target;
							}
							return EKvKKingdomType.EKKT_Normal;
						}
						else
						{
							j++;
						}
					}
					break;
				}
			}
		}
		return EKvKKingdomType.EKKT_None;
	}

	// Token: 0x06000079 RID: 121 RVA: 0x00006DCC File Offset: 0x00004FCC
	public void reflashKvKKingdomType()
	{
		if (this.door != null)
		{
			this.door.ShowKVKTime(false);
		}
		DataManager.msgBuffer[0] = 53;
		DataManager.msgBuffer[1] = 2;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		DataManager.msgBuffer[0] = 130;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x0600007A RID: 122 RVA: 0x00006E2C File Offset: 0x0000502C
	public Sprite LoadActivityListSprite(ushort IconID)
	{
		if (this.m_ActivityListAsset.m_AssetBundleKey == 0)
		{
			return null;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.IntToFormat((long)IconID, 3, false);
		cstring.AppendFormat("A{0:000}");
		Sprite result;
		this.m_ActivityListAsset.m_Dict.TryGetValue(cstring.GetHashCode(false), out result);
		return result;
	}

	// Token: 0x0600007B RID: 123 RVA: 0x00006E88 File Offset: 0x00005088
	public Sprite LoadActivitySprite(ushort IconID)
	{
		if (this.m_ActivityAsset.m_AssetBundleKey == 0)
		{
			return null;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.IntToFormat((long)IconID, 3, false);
		cstring.AppendFormat("A{0:000}_b");
		Sprite result;
		this.m_ActivityAsset.m_Dict.TryGetValue(cstring.GetHashCode(false), out result);
		return result;
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00006EE4 File Offset: 0x000050E4
	public Sprite LoadDoorBoxSprite(ushort IconID, bool bDark = false)
	{
		if (this.m_DoorBoxAsset.m_AssetBundle == null)
		{
			return null;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.IntToFormat((long)IconID, 1, false);
		if (bDark)
		{
			cstring.AppendFormat("UI_chest_{0}a");
		}
		else
		{
			cstring.AppendFormat("UI_chest_{0}b");
		}
		Sprite result;
		this.m_DoorBoxAsset.m_Dict.TryGetValue(cstring.GetHashCode(false), out result);
		return result;
	}

	// Token: 0x0600007D RID: 125 RVA: 0x00006F5C File Offset: 0x0000515C
	public Material GetActivityListMaterial()
	{
		if (this.m_ActivityListAsset.m_AssetBundleKey == 0)
		{
			return null;
		}
		return this.m_ActivityListAsset.m_Material;
	}

	// Token: 0x0600007E RID: 126 RVA: 0x00006F7C File Offset: 0x0000517C
	public Material GetActivityMaterial()
	{
		if (this.m_ActivityAsset.m_AssetBundleKey == 0)
		{
			return null;
		}
		return this.m_ActivityAsset.m_Material;
	}

	// Token: 0x0600007F RID: 127 RVA: 0x00006F9C File Offset: 0x0000519C
	public Material GetDoorBoxMaterial()
	{
		if (this.m_DoorBoxAsset.m_AssetBundleKey == 0)
		{
			return null;
		}
		return this.m_DoorBoxAsset.m_Material;
	}

	// Token: 0x06000080 RID: 128 RVA: 0x00006FBC File Offset: 0x000051BC
	private ushort ActivityFactorIDToSN(byte Factor, byte Level)
	{
		return (ushort)((int)Factor << 8 | (int)Level);
	}

	// Token: 0x06000081 RID: 129 RVA: 0x00006FC4 File Offset: 0x000051C4
	public void InitKVKActivityScoreTable()
	{
		this.m_ActivityFactorIDMap_KVK.Clear();
		int tableCount = this.KVKScoreData.TableCount;
		for (int i = 0; i < tableCount; i++)
		{
			KVKActivityScoreData recordByIndex = this.KVKScoreData.GetRecordByIndex(i);
			ushort key = this.ActivityFactorIDToSN(recordByIndex.ScoreFactor, recordByIndex.Level);
			if (this.m_ActivityFactorIDMap_KVK.ContainsKey(key))
			{
				return;
			}
			this.m_ActivityFactorIDMap_KVK.Add(key, i);
		}
	}

	// Token: 0x06000082 RID: 130 RVA: 0x00007040 File Offset: 0x00005240
	public KVKActivityScoreData GetKVKActivityScore_SDataByFactor(byte facotr, byte level)
	{
		if (this.KVKScoreData == null)
		{
			this.KVKScoreData = new CExternalTableWithWordKey<KVKActivityScoreData>();
			this.KVKScoreData.LoadTable("KingdomEventFactorScore");
			this.InitKVKActivityScoreTable();
		}
		ushort key = this.ActivityFactorIDToSN(facotr, level);
		if (this.m_ActivityFactorIDMap_KVK.Count <= 0 || !this.m_ActivityFactorIDMap_KVK.ContainsKey(key))
		{
			return this.KVKScoreData.GetRecordByIndex(0);
		}
		return this.KVKScoreData.GetRecordByIndex(this.m_ActivityFactorIDMap_KVK[key]);
	}

	// Token: 0x06000083 RID: 131 RVA: 0x000070CC File Offset: 0x000052CC
	public void InitAllianceSummonScoreTable()
	{
		this.m_ActivityFactorIDMap_AllianceSummon.Clear();
		int tableCount = this.AllianceSummonScoreData.TableCount;
		for (int i = 0; i < tableCount; i++)
		{
			SummonScoreData recordByIndex = this.AllianceSummonScoreData.GetRecordByIndex(i);
			ushort key = this.ActivityFactorIDToSN(recordByIndex.ScoreFactor, recordByIndex.Level);
			if (this.m_ActivityFactorIDMap_AllianceSummon.ContainsKey(key))
			{
				return;
			}
			this.m_ActivityFactorIDMap_AllianceSummon.Add(key, i);
		}
	}

	// Token: 0x06000084 RID: 132 RVA: 0x00007148 File Offset: 0x00005348
	public SummonScoreData GetAllianceSummonScore_SDataByFactor(byte facotr, byte level)
	{
		if (this.AllianceSummonScoreData == null)
		{
			this.AllianceSummonScoreData = new CExternalTableWithWordKey<SummonScoreData>();
			this.AllianceSummonScoreData.LoadTable("AllianceSummonFactorScore");
			this.InitAllianceSummonScoreTable();
		}
		ushort key = this.ActivityFactorIDToSN(facotr, level);
		if (this.m_ActivityFactorIDMap_AllianceSummon.Count <= 0 || !this.m_ActivityFactorIDMap_AllianceSummon.ContainsKey(key))
		{
			return this.AllianceSummonScoreData.GetRecordByIndex(0);
		}
		return this.AllianceSummonScoreData.GetRecordByIndex(this.m_ActivityFactorIDMap_AllianceSummon[key]);
	}

	// Token: 0x06000085 RID: 133 RVA: 0x000071D4 File Offset: 0x000053D4
	public void Send_ACTIVITY_EVENT_LIST()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_EVENT_LIST;
		messagePacket.AddSeqId();
		for (int i = 0; i < 2; i++)
		{
			messagePacket.Add(this.ActivityData[i].EventRank);
		}
		messagePacket.Add(this.KvKActivityData[0].EventRank);
		messagePacket.Add(this.KvKActivityData[2].EventRank);
		messagePacket.Add(this.FIFAData[0].EventRank);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Activity);
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00007270 File Offset: 0x00005470
	public void Send_ACTIVITY_EVENT_LIST_SINGLE(byte index)
	{
		if (index >= 17)
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_EVENT_LIST_SINGLE;
		messagePacket.AddSeqId();
		messagePacket.Add(index + 1);
		if (index <= 1)
		{
			messagePacket.Add(this.ActivityData[(int)index].EventRank);
		}
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Activity);
	}

	// Token: 0x06000087 RID: 135 RVA: 0x000072DC File Offset: 0x000054DC
	public void Send_ACTIVITY_EVENT_DETAIL(byte index)
	{
		if ((int)index >= this.ActivityData.Length)
		{
			return;
		}
		if (this.ActivityData[(int)index].bAskDetailData)
		{
			if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_Activity2, (int)index, 0, false);
			}
		}
		else if (this.ActivityData[(int)index].EventState == EActivityState.EAS_None)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107u), 255, true);
		}
		else
		{
			this.bAskDetailData = true;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_EVENT_DETAIL;
			messagePacket.AddSeqId();
			messagePacket.Add(index);
			if (index < 2)
			{
				messagePacket.Add(this.ActivityData[(int)index].EventRank);
			}
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Activity);
		}
	}

	// Token: 0x06000088 RID: 136 RVA: 0x000073C8 File Offset: 0x000055C8
	public void Send_ACTIVITY_RANKING_PRIZE(byte index)
	{
		if ((int)index >= this.ActivityData.Length)
		{
			return;
		}
		if (this.ActivityData[(int)index].bAskRankPrize)
		{
			if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, (int)index, false);
			}
		}
		else
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_RANKING_PRIZE;
			messagePacket.AddSeqId();
			messagePacket.Add(index);
			if (index < 2)
			{
				messagePacket.Add(this.ActivityData[(int)index].EventRank);
			}
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Activity);
		}
	}

	// Token: 0x06000089 RID: 137 RVA: 0x00007470 File Offset: 0x00005670
	public void Send_ACTIVITY_KEVENT_DETAIL(byte index)
	{
		if (index < 201 || index > 205)
		{
			return;
		}
		this.SettmpKvKTypeByIndex(index);
		if (this.tmpActivityType == EActivityType.EAT_MAX || this.tmpActivityKingdomEventType == EActivityKingdomEventType.EAKET_MAX)
		{
			return;
		}
		int num = (int)(index - 201);
		if (this.KvKActivityData[num].bAskDetailData)
		{
			if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_Activity2, (int)index, 0, false);
			}
		}
		else if (this.KvKActivityData[num].EventState == EActivityState.EAS_None)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107u), 255, true);
		}
		else
		{
			this.bAskDetailData = true;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_KEVENT_DETAIL;
			messagePacket.AddSeqId();
			messagePacket.Add((byte)(this.tmpActivityType + 1));
			messagePacket.Add((byte)this.tmpActivityKingdomEventType);
			messagePacket.Add(this.KvKActivityData[num].EventRank);
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Activity);
		}
	}

	// Token: 0x0600008A RID: 138 RVA: 0x00007598 File Offset: 0x00005798
	public void Send_ACTIVITY_KEVENT_LIST_SINGLE(byte index)
	{
		if (index < 201 || index > 205)
		{
			return;
		}
		this.SettmpKvKTypeByIndex(index);
		if (this.tmpActivityType == EActivityType.EAT_MAX || this.tmpActivityKingdomEventType == EActivityKingdomEventType.EAKET_MAX)
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_KEVENT_LIST_SINGLE;
		messagePacket.AddSeqId();
		messagePacket.Add((byte)(this.tmpActivityType + 1));
		messagePacket.Add((byte)this.tmpActivityKingdomEventType);
		messagePacket.Add(this.KvKActivityData[(int)(index - 201)].EventRank);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Activity);
	}

	// Token: 0x0600008B RID: 139 RVA: 0x00007644 File Offset: 0x00005844
	public void Send_ACTIVITY_KEVENT_RANKING_PRIZE(byte index)
	{
		if (index < 201 || index > 205)
		{
			return;
		}
		int num = (int)(index - 201);
		if (this.KvKActivityData[num].bAskRankPrize)
		{
			if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, (int)index, false);
			}
		}
		else
		{
			this.SettmpKvKTypeByIndex(index);
			if (this.tmpActivityType == EActivityType.EAT_MAX || this.tmpActivityKingdomEventType == EActivityKingdomEventType.EAKET_MAX)
			{
				return;
			}
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_KEVENT_RANKING_PRIZE;
			messagePacket.AddSeqId();
			messagePacket.Add((byte)(this.tmpActivityType + 1));
			messagePacket.Add((byte)this.tmpActivityKingdomEventType);
			messagePacket.Add(this.KvKActivityData[num].EventRank);
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Activity);
		}
	}

	// Token: 0x0600008C RID: 140 RVA: 0x0000772C File Offset: 0x0000592C
	public void Send_ACTIVITY_SPEVENT_LIST_SINGLE(EActivityType Type, byte index)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_EVENT_LIST_SINGLE;
		messagePacket.AddSeqId();
		messagePacket.Add((byte)Type + 1);
		messagePacket.Add(index);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Activity);
	}

	// Token: 0x0600008D RID: 141 RVA: 0x0000777C File Offset: 0x0000597C
	public void Send_ACTIVITY_AM_RANKING_PRIZE()
	{
		if (this.AllyMobilizationData.bAskRankPrize)
		{
			if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, 206, false);
			}
		}
		else
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AM_RANKING_PRIZE;
			messagePacket.AddSeqId();
			messagePacket.Add(DataManager.Instance.RoleAlliance.AMRank);
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Activity);
		}
	}

	// Token: 0x0600008E RID: 142 RVA: 0x0000780C File Offset: 0x00005A0C
	public void Send_KINGOFTHEWORLD_KINGINFO()
	{
		this.bAskDetailData = true;
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_KINGOFTHEWORLD_KINGINFO;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Activity);
	}

	// Token: 0x0600008F RID: 143 RVA: 0x00007854 File Offset: 0x00005A54
	public void RecvEventPoint(byte DataTypeIndex, MessagePacket MP)
	{
		if ((int)DataTypeIndex < this.ActivityData.Length)
		{
			this.ActivityData[(int)DataTypeIndex].EventScore = MP.ReadULong(-1);
		}
		DataManager.MissionDataManager.CheckChanged(eMissionKind.Mark, 103, (ushort)DataTypeIndex);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 2, (int)DataTypeIndex);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 1, 0);
	}

	// Token: 0x06000090 RID: 144 RVA: 0x000078B0 File Offset: 0x00005AB0
	public void RecvKVKEventPoint(byte DataTypeIndex, MessagePacket MP)
	{
		this.SetKVKEventPoint(DataTypeIndex, MP.ReadULong(-1));
	}

	// Token: 0x06000091 RID: 145 RVA: 0x000078C0 File Offset: 0x00005AC0
	public void SetKVKEventPoint(byte DataTypeIndex, ulong Score)
	{
		if ((int)DataTypeIndex < this.KvKActivityData.Length)
		{
			this.KvKActivityData[(int)DataTypeIndex].EventScore = Score;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 2, (int)(DataTypeIndex + 201));
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 1, 0);
		DataManager.MissionDataManager.CheckChanged(eMissionKind.Mark, 136, (ushort)DataTypeIndex);
		if (Score != 0UL && DataTypeIndex == 2 && this.KvKActivityData[4].EventState == EActivityState.EAS_Run)
		{
			FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.CREDITS_FOR_KVK, this.KvKActivityData[4].EventBeginTime, this.KvKActivityData[(int)DataTypeIndex].EventScore);
		}
	}

	// Token: 0x06000092 RID: 146 RVA: 0x00007964 File Offset: 0x00005B64
	public void RecvActivity_Info(MessagePacket MP)
	{
		EActivityState eventState = this.KvKActivityData[4].EventState;
		int num = 2;
		for (int i = 0; i < num; i++)
		{
			this.ActivityData[i].Initial();
			this.ActivityData[i].ActiveType = (EActivityType)i;
			this.ActivityData[i].EventState = (EActivityState)MP.ReadByte(-1);
			this.ActivityData[i].EventBeginTime = MP.ReadLong(-1);
			this.ActivityData[i].EventReqiureTIme = MP.ReadUInt(-1);
			this.ActivityData[i].EventScore = MP.ReadULong(-1);
			if (this.ActivityData[i].EventState == EActivityState.EAS_Prepare)
			{
				this.ActivityData[i].EventScore = 0UL;
			}
			this.ActivityData[i].EventRank = MP.ReadByte(-1);
			this.CheckCountTime((EActivityCircleEventType)i);
			DataManager.MissionDataManager.CheckChanged(eMissionKind.Mark, 103, (ushort)i);
		}
		this.SetActivityBtnToFirst();
		this.bAskFirstData = true;
		this.bAskSecondData = false;
		this.CheckMonster(MP, true);
		this.CheckMonsterType(MP, true);
		this.CheckShowNpcMessage();
		this.SetCSData(MP, -1);
		this.SetSPData(MP, -1);
		this.SetTreasureBoxID(MP.ReadUShort(-1));
		for (byte b = 0; b < 5; b += 1)
		{
			if (this.SPActivityData[(int)b].EventBeginTime != this.SPActivityTime[(int)b])
			{
				this.SPActivityTime[(int)b] = this.SPActivityData[(int)b].EventBeginTime;
				this.SetbOpenSPActivity(b, false);
			}
		}
		for (byte b2 = 0; b2 < 5; b2 += 1)
		{
			if (this.CSActivityData[(int)b2].EventBeginTime != this.CSActivityTime[(int)b2])
			{
				this.CSActivityTime[(int)b2] = this.CSActivityData[(int)b2].EventBeginTime;
				this.SetbOpenCSActivity(b2, false);
			}
		}
		this.SendAskDownLoad();
		this.KvKActivityData[0].Initial();
		this.KvKActivityData[0].ActiveType = EActivityType.EAT_KingdomNormalEvent;
		this.KvKActivityData[0].KVKActiveType = EKVKActivityType.EKAT_KNormalSoloEvent;
		this.KvKActivityData[0].EventState = (EActivityState)MP.ReadByte(-1);
		this.KvKActivityData[0].EventBeginTime = MP.ReadLong(-1);
		this.KvKActivityData[0].EventReqiureTIme = MP.ReadUInt(-1);
		this.KvKActivityData[0].EventScore = MP.ReadULong(-1);
		if (this.KvKActivityData[0].EventState == EActivityState.EAS_Prepare)
		{
			this.KvKActivityData[0].EventScore = 0UL;
		}
		this.KvKActivityData[0].EventRank = MP.ReadByte(-1);
		this.CheckKVKCountTime(EKVKActivityType.EKAT_KNormalSoloEvent);
		this.KvKActivityData[1].Initial();
		this.KvKActivityData[1].ActiveType = EActivityType.EAT_KingdomNormalEvent;
		this.KvKActivityData[1].KVKActiveType = EKVKActivityType.EKAT_KNormalAllianceEvent;
		this.AllyMobilizationData.Initial();
		this.AllyMobilizationData.ActiveType = EActivityType.EAT_AllianceMobilization;
		this.AllyMobilizationData.EventState = (EActivityState)MP.ReadByte(-1);
		this.AllyMobilizationData.EventBeginTime = MP.ReadLong(-1);
		this.AllyMobilizationData.EventReqiureTIme = MP.ReadUInt(-1);
		this.AllyMobilizationData.EventScore = MP.ReadULong(-1);
		if (this.AllyMobilizationData.EventState == EActivityState.EAS_Prepare)
		{
			this.AllyMobilizationData.EventScore = 0UL;
		}
		this.AllyMobilizationData.EventRank = MP.ReadByte(-1);
		MobilizationManager.Instance.SetAllyMobilizationBeginTime(this.AllyMobilizationData.EventBeginTime);
		this.CheckAMCountTime();
		this.CheckAMActivityTime();
		EActivityState eventState2 = (EActivityState)MP.ReadByte(-1);
		long num2 = MP.ReadLong(-1);
		uint eventReqiureTIme = MP.ReadUInt(-1);
		ulong eventScore = MP.ReadULong(-1);
		byte eventRank = MP.ReadByte(-1);
		for (int j = 2; j < 5; j++)
		{
			this.KvKActivityData[j].Initial();
			this.KvKActivityData[j].ActiveType = EActivityType.EAT_KingdomKillEvent;
			this.KvKActivityData[j].KVKActiveType = (EKVKActivityType)j;
			this.KvKActivityData[j].EventState = eventState2;
			this.KvKActivityData[j].EventBeginTime = num2;
			this.KvKActivityData[j].EventReqiureTIme = eventReqiureTIme;
			this.KvKActivityData[j].EventScore = eventScore;
			if (this.KvKActivityData[j].EventState == EActivityState.EAS_Prepare)
			{
				this.KvKActivityData[j].EventScore = 0UL;
			}
			this.KvKActivityData[j].EventRank = eventRank;
			this.CheckKVKCountTime((EKVKActivityType)j);
		}
		this.KOWData.ActiveType = EActivityType.EAT_KingOfTheWorld;
		this.KOWData.EventState = (EActivityState)MP.ReadByte(-1);
		this.KOWData.EventBeginTime = MP.ReadLong(-1);
		this.KOWData.EventReqiureTIme = MP.ReadUInt(-1);
		this.KOWData.EventPrizeID = MP.ReadUShort(-1);
		if (this.KOWData.EventState == EActivityState.EAS_ReplayRanking)
		{
			this.KOWData.bAskDetailData = false;
		}
		else
		{
			this.KOWData.bAskDetailData = true;
		}
		this.CheckKOWCountTime();
		this.SetLastGetDailyGiftTime(MP.ReadLong(-1));
		this.KOWKingdomID = MP.ReadUShort(-1);
		if (DataManager.MapDataController.FocusKingdomID == this.KOWKingdomID)
		{
			DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
		}
		if (DataManager.MapDataController.kingdomData.kingdomID == this.KOWKingdomID)
		{
			DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
		}
		if (DataManager.MapDataController.OtherKingdomData.kingdomID == this.KOWKingdomID)
		{
			DataManager.MapDataController.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
		}
		this.AMAllianceID = MP.ReadUInt(-1);
		this.CheckAMShowHint();
		eventState2 = (EActivityState)MP.ReadByte(-1);
		num2 = MP.ReadLong(-1);
		eventReqiureTIme = MP.ReadUInt(-1);
		eventScore = MP.ReadULong(-1);
		eventRank = MP.ReadByte(-1);
		if (this.KvKActivityData[2].EventBeginTime == 0L && num2 > 0L)
		{
			for (int k = 2; k < 5; k++)
			{
				this.KvKActivityData[k].Initial();
				this.KvKActivityData[k].ActiveType = EActivityType.EAT_KingdomMatchEvent;
				this.KvKActivityData[k].KVKActiveType = (EKVKActivityType)k;
				this.KvKActivityData[k].EventState = eventState2;
				this.KvKActivityData[k].EventBeginTime = num2;
				this.KvKActivityData[k].EventReqiureTIme = eventReqiureTIme;
				this.KvKActivityData[k].EventScore = eventScore;
				if (this.KvKActivityData[k].EventState == EActivityState.EAS_Prepare)
				{
					this.KvKActivityData[k].EventScore = 0UL;
				}
				this.KvKActivityData[k].EventRank = eventRank;
				this.CheckKVKCountTime((EKVKActivityType)k);
			}
		}
		if (this.KvKActivityData[4].EventState != EActivityState.EAS_Run && !this.IsInFIFA_KVK(0, true))
		{
			this.KVKHuntOrder = 0;
			this.KVKReTime = 0L;
		}
		this.KOWData.EventPrizeID2 = MP.ReadUShort(-1);
		this.KOWData.EventPrizeID3 = MP.ReadUShort(-1);
		this.AllianceSummonData.Initial();
		this.AllianceSummonData.ActiveType = EActivityType.EAT_AllianceSummon;
		this.AllianceSummonData.EventState = (EActivityState)MP.ReadByte(-1);
		this.AllianceSummonData.EventBeginTime = MP.ReadLong(-1);
		this.AllianceSummonData.EventReqiureTIme = MP.ReadUInt(-1);
		this.AllianceSummonAllianceID = MP.ReadUInt(-1);
		this.AllianceSummonEventInfoID = MP.ReadUShort(-1);
		this.SetAllianceSummonDate();
		this.CheckASCountTime();
		this.NobilityActivityData.Initial();
		this.NobilityActivityData.InitialNobility();
		this.NobilityActivityData.ActiveType = EActivityType.EAT_FederalEvent;
		this.NobilityActivityData.EventState = (EActivityState)MP.ReadByte(-1);
		this.NobilityActivityData.EventBeginTime = MP.ReadLong(-1);
		this.NobilityActivityData.EventReqiureTIme = MP.ReadUInt(-1);
		this.FederalActKingdomWonderID = MP.ReadByte(-1);
		this.FederalHomeKingdomWonderID = MP.ReadByte(-1);
		this.FederalFightingWonderID = MP.ReadByte(-1);
		this.FederalFullEventTimeWonderID = MP.ReadByte(-1);
		this.CheckNWCountTime();
		this.CheckNWActivityTime();
		this.AllianceWarData.Initial();
		this.AllianceWarData.ActiveType = EActivityType.EAT_AllianceWar;
		this.AllianceWarData.EventState = (EActivityState)MP.ReadByte(-1);
		this.AllianceWarData.EventBeginTime = MP.ReadLong(-1);
		this.AllianceWarData.EventReqiureTIme = MP.ReadUInt(-1);
		this.CheckAWCountTime(true);
		this.SetNowState(false);
		if (this.AW_EventBeginTime == 0L)
		{
			this.AW_EventBeginTime = this.AllianceWarData.EventBeginTime;
		}
		else if (this.AW_EventBeginTime != this.AllianceWarData.EventBeginTime)
		{
			this.ClearAllianceWarData();
		}
		this.CheckAWActivityTime();
		if (this.KvKActivityData[4].EventBeginTime != this.KvKActivityTime)
		{
			this.KvKActivityTime = this.KvKActivityData[4].EventBeginTime;
			this.SetbOpenKvKActivity(false);
		}
		if (this.KvKActivityData[4].EventState == EActivityState.EAS_Run && this.NowBeginTime != this.KvKActivityData[4].EventBeginTime)
		{
			this.bShowRunningP = false;
			this.bShowRunningE = false;
			this.NowBeginTime = this.KvKActivityData[4].EventBeginTime;
			this.ShowRunningTime = DataManager.Instance.ServerTime;
			CString cstring = StringManager.Instance.SpawnString(300);
			cstring.Append(DataManager.Instance.mStringTable.GetStringByID(9376u));
			GUIManager.Instance.WonderCountStr.Add(cstring);
			GUIManager.Instance.SetRunningText(cstring);
		}
		this.UpDateKVKCountTime();
		this.UpDateKvKState(eventState);
		if (this.KvKActivityData[4].EventState == EActivityState.EAS_Run && this.KvKActivityData[0].EventScore > 0UL)
		{
			FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.CREDITS_FOR_KVK, this.KvKActivityData[4].EventBeginTime, this.KvKActivityData[0].EventScore);
		}
		int num3 = 2;
		if (!this.bRecvFIFAData)
		{
			this.ClearFIFAData();
		}
		else if (this.FIFAData[num3].ActiveType == EActivityType.EAT_FIFA_KVK)
		{
			this.CopyFIFAKVKToKVK(eventState);
			if (this.KvKActivityData[4].EventState == EActivityState.EAS_Run && this.NowBeginTime != this.KvKActivityData[4].EventBeginTime)
			{
				this.bShowRunningP = false;
				this.bShowRunningE = false;
				this.NowBeginTime = this.KvKActivityData[4].EventBeginTime;
				this.ShowRunningTime = DataManager.Instance.ServerTime;
				CString cstring2 = StringManager.Instance.SpawnString(300);
				cstring2.Append(DataManager.Instance.mStringTable.GetStringByID(9376u));
				GUIManager.Instance.WonderCountStr.Add(cstring2);
				GUIManager.Instance.SetRunningText(cstring2);
			}
			if (this.NowWaveEndTime != 0L && this.NowWaveEndTime != this.FIFA_NowEndTime)
			{
				this.FIFA_bShowRunningE = false;
				this.FIFA_NowEndTime = this.NowWaveEndTime;
				CString cstring3 = StringManager.Instance.SpawnString(300);
				cstring3.Append(DataManager.Instance.mStringTable.GetStringByID(14727u));
				GUIManager.Instance.WonderCountStr.Add(cstring3);
				GUIManager.Instance.SetRunningText(cstring3);
			}
			this.UpDateKVKCountTime();
		}
		if (this.FIFAData[num3].EventBeginTime != this.FIFAActivityTime)
		{
			this.FIFAActivityTime = this.FIFAData[num3].EventBeginTime;
			this.SetbOpenFIFAActivity(false);
		}
	}

	// Token: 0x06000093 RID: 147 RVA: 0x0000849C File Offset: 0x0000669C
	public void RecvActivity_Prepare(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if ((int)b < this.ActivityData.Length)
		{
			this.ActivityData[(int)b].EventState = EActivityState.EAS_Prepare;
			this.ActivityData[(int)b].EventBeginTime = MP.ReadLong(-1);
			this.ActivityData[(int)b].EventReqiureTIme = MP.ReadUInt(-1);
			this.ActivityData[(int)b].EventRank = MP.ReadByte(-1);
			this.ActivityData[(int)b].EventScore = 0UL;
			this.ActivityData[(int)b].bAskDetailData = false;
			this.ActivityData[(int)b].bAskRankPrize = false;
			this.CheckCountTime((EActivityCircleEventType)b);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, (int)b);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, (int)b);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity4, 1, (int)b);
		}
		this.CheckMonster(MP, b == 0);
		this.CheckMonsterType(MP, b == 0);
	}

	// Token: 0x06000094 RID: 148 RVA: 0x0000857C File Offset: 0x0000677C
	public void RecvActivity_Run(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if ((int)b < this.ActivityData.Length)
		{
			this.ActivityData[(int)b].EventState = EActivityState.EAS_Run;
			this.ActivityData[(int)b].EventScore = 0UL;
			this.CheckCountTime((EActivityCircleEventType)b);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, (int)b);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, (int)b);
		}
		if (b == 0)
		{
			this.CheckShowNpcMessage();
		}
	}

	// Token: 0x06000095 RID: 149 RVA: 0x000085EC File Offset: 0x000067EC
	public void RecvActivity_End(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		if ((int)b < this.ActivityData.Length)
		{
			this.ActivityData[(int)b].EventState = EActivityState.EAS_None;
			this.ActivityData[(int)b].EventScore = 0UL;
			this.ActivityData[(int)b].bAskDetailData = false;
			this.ActivityData[(int)b].bAskRankPrize = false;
			this.CheckCountTime((EActivityCircleEventType)b);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, (int)b);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, (int)b);
		}
	}

	// Token: 0x06000096 RID: 150 RVA: 0x0000866C File Offset: 0x0000686C
	public void RecvActivity_EventList(MessagePacket MP)
	{
		int num = 2;
		for (int i = 0; i < num; i++)
		{
			this.ActivityData[i].ActiveType = (EActivityType)i;
			this.ActivityData[i].Name = MP.ReadUShort(-1);
			this.ActivityData[i].Pic = MP.ReadUShort(-1);
			this.ActivityData[i].PicStr = MP.ReadUShort(-1);
			this.ActivityData[i].DetailContentStrID = MP.ReadUShort(-1);
			for (int j = 0; j < 3; j++)
			{
				this.ActivityData[i].RequireScore[j] = MP.ReadUInt(-1);
			}
			this.ActivityData[i].EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt(-1);
			this.ActivityData[i].EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt(-1);
			this.ActivityData[i].EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort(-1);
		}
		for (int k = 0; k < 5; k++)
		{
			this.CSActivityData[k].Name = MP.ReadUShort(-1);
			this.CSActivityData[k].Pic = MP.ReadUShort(-1);
			this.CSActivityData[k].PicStr = MP.ReadUShort(-1);
		}
		for (int l = 0; l < 5; l++)
		{
			this.SPActivityData[l].Name = MP.ReadUShort(-1);
			this.SPActivityData[l].Pic = MP.ReadUShort(-1);
			this.SPActivityData[l].PicStr = MP.ReadUShort(-1);
		}
		this.KvKActivityData[0].KVKActiveType = EKVKActivityType.EKAT_KNormalSoloEvent;
		this.KvKActivityData[0].Name = MP.ReadUShort(-1);
		this.KvKActivityData[0].Pic = MP.ReadUShort(-1);
		this.KvKActivityData[0].PicStr = MP.ReadUShort(-1);
		this.KvKActivityData[0].DetailContentStrID = MP.ReadUShort(-1);
		for (int m = 0; m < 3; m++)
		{
			this.KvKActivityData[0].RequireScore[m] = MP.ReadUInt(-1);
		}
		this.KvKActivityData[0].EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt(-1);
		this.KvKActivityData[0].EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt(-1);
		this.KvKActivityData[0].EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort(-1);
		this.AllyMobilizationData.Name = MP.ReadUShort(-1);
		this.AllyMobilizationData.Pic = MP.ReadUShort(-1);
		this.AllyMobilizationData.PicStr = MP.ReadUShort(-1);
		this.AllyMobilizationData.DetailContentStrID = MP.ReadUShort(-1);
		for (int n = 0; n < 3; n++)
		{
			this.AllyMobilizationData.RequireScore[n] = MP.ReadUInt(-1);
		}
		this.AllyMobilizationData.EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt(-1);
		this.AllyMobilizationData.EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt(-1);
		this.AllyMobilizationData.EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort(-1);
		num = 5;
		for (int num2 = 2; num2 < num; num2++)
		{
			this.KvKActivityData[num2].KVKActiveType = (EKVKActivityType)num2;
			this.KvKActivityData[num2].Name = MP.ReadUShort(-1);
			this.KvKActivityData[num2].Pic = MP.ReadUShort(-1);
			this.KvKActivityData[num2].PicStr = MP.ReadUShort(-1);
			this.KvKActivityData[num2].DetailContentStrID = MP.ReadUShort(-1);
			for (int num3 = 0; num3 < 3; num3++)
			{
				this.KvKActivityData[num2].RequireScore[num3] = MP.ReadUInt(-1);
			}
			this.KvKActivityData[num2].EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt(-1);
			this.KvKActivityData[num2].EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt(-1);
			this.KvKActivityData[num2].EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort(-1);
		}
		this.KOWData.Name = MP.ReadUShort(-1);
		this.KOWData.Pic = MP.ReadUShort(-1);
		this.KOWData.PicStr = MP.ReadUShort(-1);
		this.KOWData.DetailContentStrID = MP.ReadUShort(-1);
		this.ActivityData[0].SpDegreePrizeFlag = MP.ReadByte(-1);
		this.ActivityData[1].SpDegreePrizeFlag = MP.ReadByte(-1);
		this.KvKActivityData[0].SpDegreePrizeFlag = MP.ReadByte(-1);
		this.KvKActivityData[2].SpDegreePrizeFlag = MP.ReadByte(-1);
		this.KvKActivityData[3].SpDegreePrizeFlag = MP.ReadByte(-1);
		this.ActivityData[0].EventBonusType = (EActEventBonusType)MP.ReadByte(-1);
		this.ActivityData[1].EventBonusType = (EActEventBonusType)MP.ReadByte(-1);
		this.KvKActivityData[0].EventBonusType = (EActEventBonusType)MP.ReadByte(-1);
		this.AllianceSummonData.Name = MP.ReadUShort(-1);
		this.AllianceSummonData.Pic = MP.ReadUShort(-1);
		this.AllianceSummonData.PicStr = MP.ReadUShort(-1);
		this.AllianceSummonData.DetailContentStrID = MP.ReadUShort(-1);
		this.AllianceSummonEventInfoID = MP.ReadUShort(-1);
		this.SetAllianceSummonDate();
		this.NobilityActivityData.Name = MP.ReadUShort(-1);
		this.NobilityActivityData.Pic = MP.ReadUShort(-1);
		this.NobilityActivityData.PicStr = MP.ReadUShort(-1);
		this.NobilityActivityData.DetailContentStrID = MP.ReadUShort(-1);
		this.AllianceWarData.Name = MP.ReadUShort(-1);
		this.AllianceWarData.Pic = MP.ReadUShort(-1);
		this.AllianceWarData.PicStr = MP.ReadUShort(-1);
		this.AllianceWarData.DetailContentStrID = MP.ReadUShort(-1);
		this.AW_PrepareTime = MP.ReadUShort(-1);
		this.AW_FightTime = MP.ReadByte(-1);
		this.AW_WaitTime = MP.ReadUShort(-1);
		this.AW_PrizeGroupID = MP.ReadByte(-1);
		this.SetNowState(true);
		num = 3;
		for (int num4 = 0; num4 < num; num4++)
		{
			this.FIFAData[num4].Name = MP.ReadUShort(-1);
			this.FIFAData[num4].Pic = MP.ReadUShort(-1);
			this.FIFAData[num4].PicStr = MP.ReadUShort(-1);
			this.FIFAData[num4].DetailContentStrID = MP.ReadUShort(-1);
			for (int num5 = 0; num5 < 3; num5++)
			{
				this.FIFAData[num4].RequireScore[num5] = MP.ReadUInt(-1);
			}
			this.FIFAData[num4].EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt(-1);
			this.FIFAData[num4].EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt(-1);
			this.FIFAData[num4].EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort(-1);
		}
		this.FIFAData[0].SpDegreePrizeFlag = MP.ReadByte(-1);
		this.FIFAData[1].SpDegreePrizeFlag = MP.ReadByte(-1);
		this.bAskSecondData = true;
		GUIManager.Instance.HideUILock(EUILock.Activity);
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity1))
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5, 0);
		}
		else if (this.door != null)
		{
			this.door.OpenMenu(EGUIWindow.UI_Activity1, 0, 0, false);
		}
		for (int num6 = this.door.m_WindowStack.Count - 1; num6 >= 0; num6--)
		{
			if (this.door.m_WindowStack[num6].m_eWindow == EGUIWindow.UI_LetterDetail || this.door.m_WindowStack[num6].m_eWindow == EGUIWindow.UI_Letter)
			{
				this.door.m_WindowStack.RemoveAt(num6);
			}
		}
	}

	// Token: 0x06000097 RID: 151 RVA: 0x00008E84 File Offset: 0x00007084
	public void RecvActivity_EventListSingle(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Activity);
		byte b = MP.ReadByte(-1);
		if (b != 0)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107u), 255, true);
			return;
		}
		byte b2 = MP.ReadByte(-1);
		b2 -= 1;
		switch (b2)
		{
		case 0:
		case 1:
			this.ActivityData[(int)b2].Name = MP.ReadUShort(-1);
			this.ActivityData[(int)b2].Pic = MP.ReadUShort(-1);
			this.ActivityData[(int)b2].PicStr = MP.ReadUShort(-1);
			this.ActivityData[(int)b2].DetailContentStrID = MP.ReadUShort(-1);
			for (int i = 0; i < 3; i++)
			{
				this.ActivityData[(int)b2].RequireScore[i] = MP.ReadUInt(-1);
			}
			this.ActivityData[(int)b2].EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt(-1);
			this.ActivityData[(int)b2].EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt(-1);
			this.ActivityData[(int)b2].EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort(-1);
			this.ActivityData[(int)b2].SpDegreePrizeFlag = MP.ReadByte(-1);
			this.ActivityData[(int)b2].EventBonusType = (EActEventBonusType)MP.ReadByte(-1);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 4, (int)b2);
			break;
		case 6:
			this.AllyMobilizationData.Name = MP.ReadUShort(-1);
			this.AllyMobilizationData.Pic = MP.ReadUShort(-1);
			this.AllyMobilizationData.PicStr = MP.ReadUShort(-1);
			this.AllyMobilizationData.DetailContentStrID = MP.ReadUShort(-1);
			for (int j = 0; j < 3; j++)
			{
				this.AllyMobilizationData.RequireScore[j] = MP.ReadUInt(-1);
			}
			this.AllyMobilizationData.EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt(-1);
			this.AllyMobilizationData.EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt(-1);
			this.AllyMobilizationData.EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort(-1);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 4, 206);
			break;
		case 7:
			this.KOWData.Name = MP.ReadUShort(-1);
			this.KOWData.Pic = MP.ReadUShort(-1);
			this.KOWData.PicStr = MP.ReadUShort(-1);
			this.KOWData.DetailContentStrID = MP.ReadUShort(-1);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 4, 207);
			break;
		case 11:
			this.AllianceSummonData.Name = MP.ReadUShort(-1);
			this.AllianceSummonData.Pic = MP.ReadUShort(-1);
			this.AllianceSummonData.PicStr = MP.ReadUShort(-1);
			this.AllianceSummonData.DetailContentStrID = MP.ReadUShort(-1);
			this.AllianceSummonEventInfoID = MP.ReadUShort(-1);
			this.SetAllianceSummonDate();
			if (this.bReOpen)
			{
				if (this.door != null)
				{
					if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity2))
					{
						this.door.CloseMenu(false);
					}
					this.bReOpen = false;
					this.door.OpenMenu(EGUIWindow.UI_Activity2, 208, 0, false);
				}
			}
			else
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 4, 208);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, 208);
				GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 3, 0);
			}
			break;
		case 12:
			this.NobilityActivityData.Name = MP.ReadUShort(-1);
			this.NobilityActivityData.Pic = MP.ReadUShort(-1);
			this.NobilityActivityData.PicStr = MP.ReadUShort(-1);
			this.NobilityActivityData.DetailContentStrID = MP.ReadUShort(-1);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 4, 209);
			break;
		case 13:
			this.AllianceWarData.Name = MP.ReadUShort(-1);
			this.AllianceWarData.Pic = MP.ReadUShort(-1);
			this.AllianceWarData.PicStr = MP.ReadUShort(-1);
			this.AllianceWarData.DetailContentStrID = MP.ReadUShort(-1);
			this.AW_PrepareTime = MP.ReadUShort(-1);
			this.AW_FightTime = MP.ReadByte(-1);
			this.AW_WaitTime = MP.ReadUShort(-1);
			this.AW_PrizeGroupID = MP.ReadByte(-1);
			this.SetNowState(true);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 4, 210);
			break;
		}
	}

	// Token: 0x06000098 RID: 152 RVA: 0x0000933C File Offset: 0x0000753C
	public void RecvActivity_EventDetail(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Activity);
		byte b = MP.ReadByte(-1);
		if (b != 0)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107u), 255, true);
			return;
		}
		byte b2 = MP.ReadByte(-1);
		if ((int)b2 < this.ActivityData.Length)
		{
			for (int i = 0; i < 6; i++)
			{
				this.ActivityData[(int)b2].GetScoreFactor[i].Factor = (EGetScoreFactor)MP.ReadByte(-1);
				this.ActivityData[(int)b2].GetScoreFactor[i].BonusRate = MP.ReadByte(-1);
			}
			for (int j = 0; j < 3; j++)
			{
				this.ActivityData[(int)b2].EventPrizeWorthData[j].Crystal = MP.ReadUInt(-1);
				this.ActivityData[(int)b2].EventPrizeWorthData[j].CrystalPrice = MP.ReadUInt(-1);
				this.ActivityData[(int)b2].EventPrizeWorthData[j].Priceless = MP.ReadUShort(-1);
			}
			int num = 0;
			for (int k = 0; k < 3; k++)
			{
				this.ActivityData[(int)b2].DataLen[k] = MP.ReadByte(-1);
				num += (int)this.ActivityData[(int)b2].DataLen[k];
			}
			for (int l = 0; l < num; l++)
			{
				this.ActivityData[(int)b2].DegreePrize[l].Rank = MP.ReadByte(-1);
				this.ActivityData[(int)b2].DegreePrize[l].ItemID = MP.ReadUShort(-1);
				this.ActivityData[(int)b2].DegreePrize[l].Num = MP.ReadByte(-1);
			}
			this.ActivityData[(int)b2].bAskDetailData = true;
		}
		if (this.bAskDetailData && !this.bReOpenPrize && this.door != null)
		{
			if (this.bReOpen)
			{
				if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity2))
				{
					this.door.CloseMenu(false);
				}
				this.bReOpen = false;
			}
			this.door.OpenMenu(EGUIWindow.UI_Activity2, (int)b2, 0, false);
		}
	}

	// Token: 0x06000099 RID: 153 RVA: 0x00009594 File Offset: 0x00007794
	public void RecvActivity_RankingPrize(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Activity);
		byte b = MP.ReadByte(-1);
		if (b != 0)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107u), 255, true);
			return;
		}
		byte b2 = MP.ReadByte(-1);
		if ((int)b2 < this.ActivityData.Length)
		{
			for (int i = 0; i < 7; i++)
			{
				this.ActivityData[(int)b2].RankPrizeWorthData[i].Crystal = MP.ReadUInt(-1);
				this.ActivityData[(int)b2].RankPrizeWorthData[i].CrystalPrice = MP.ReadUInt(-1);
				this.ActivityData[(int)b2].RankPrizeWorthData[i].Priceless = MP.ReadUShort(-1);
			}
			int num = 0;
			for (int j = 0; j < 7; j++)
			{
				this.ActivityData[(int)b2].RankingPrizeDataLen[j] = MP.ReadByte(-1);
				num += (int)this.ActivityData[(int)b2].RankingPrizeDataLen[j];
			}
			for (int k = 0; k < num; k++)
			{
				this.ActivityData[(int)b2].RankingPrize[k].Rank = MP.ReadByte(-1);
				this.ActivityData[(int)b2].RankingPrize[k].ItemID = MP.ReadUShort(-1);
				this.ActivityData[(int)b2].RankingPrize[k].Num = MP.ReadByte(-1);
			}
			this.ActivityData[(int)b2].bAskRankPrize = true;
		}
		if (this.door != null)
		{
			if (this.bReOpenPrize)
			{
				if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity4))
				{
					this.door.CloseMenu(false);
				}
				this.bReOpenPrize = false;
			}
			this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, (int)b2, false);
		}
	}

	// Token: 0x0600009A RID: 154 RVA: 0x00009784 File Offset: 0x00007984
	public void RecvActivity_GetPrize(MessagePacket MP)
	{
		DataManager dataManager = DataManager.Instance;
		GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(-1), 0, eSpentCredits.eMax);
		dataManager.RoleAlliance.Money = MP.ReadUInt(-1);
		byte b = MP.ReadByte(-1);
		bool flag = false;
		for (int i = 0; i < (int)b; i++)
		{
			ushort itemID = MP.ReadUShort(-1);
			ushort quantity = MP.ReadUShort(-1);
			byte b2 = MP.ReadByte(-1);
			dataManager.SetCurItemQuantity(itemID, quantity, b2, 0L);
			if (b2 > 0)
			{
				flag = true;
			}
		}
		if (flag)
		{
			LordEquipData.Instance().Scan_MaterialOrEquipIncreace();
		}
		GameManager.OnRefresh(NetworkNews.Refresh, null);
	}

	// Token: 0x0600009B RID: 155 RVA: 0x0000982C File Offset: 0x00007A2C
	public void RecvActivity_Close(MessagePacket MP)
	{
	}

	// Token: 0x0600009C RID: 156 RVA: 0x00009830 File Offset: 0x00007A30
	public void RecvActivity_SpEvent_List_Single(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Activity);
		byte b = MP.ReadByte(-1);
		EActivityType eactivityType = (EActivityType)(MP.ReadByte(-1) - 1);
		byte b2 = MP.ReadByte(-1);
		if (b == 0)
		{
			EActivityType eactivityType2 = eactivityType;
			if (eactivityType2 != EActivityType.EAT_ComingSoonSpEvent)
			{
				if (eactivityType2 == EActivityType.EAT_SpecialEvent)
				{
					if (b2 >= 5)
					{
						return;
					}
					this.SPActivityData[(int)b2].Name = MP.ReadUShort(-1);
					this.SPActivityData[(int)b2].Pic = MP.ReadUShort(-1);
					this.SPActivityData[(int)b2].PicStr = MP.ReadUShort(-1);
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 10, (int)b2);
				}
			}
			else
			{
				if (b2 >= 5)
				{
					return;
				}
				this.CSActivityData[(int)b2].Name = MP.ReadUShort(-1);
				this.CSActivityData[(int)b2].Pic = MP.ReadUShort(-1);
				this.CSActivityData[(int)b2].PicStr = MP.ReadUShort(-1);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 9, (int)b2);
			}
		}
	}

	// Token: 0x0600009D RID: 157 RVA: 0x0000993C File Offset: 0x00007B3C
	public void RecvActivity_UpDateInfo(MessagePacket MP)
	{
		EActivityType eactivityType = (EActivityType)(MP.ReadByte(-1) - 1);
		byte b = MP.ReadByte(-1);
		EActivityType eactivityType2 = eactivityType;
		if (eactivityType2 != EActivityType.EAT_ComingSoonSpEvent)
		{
			if (eactivityType2 == EActivityType.EAT_SpecialEvent)
			{
				if (b >= 5)
				{
					return;
				}
				this.SetSPData(MP, (int)b);
				if (this.SPActivityData[(int)b].EventBeginTime != 0L)
				{
					this.SendAskDownLoad();
				}
				if (this.SPActivityData[(int)b].EventBeginTime != this.SPActivityTime[(int)b])
				{
					this.SPActivityTime[(int)b] = this.SPActivityData[(int)b].EventBeginTime;
				}
				this.SetbOpenSPActivity(b, false);
				if (this.SPActivityData[(int)b].EventBeginTime != 0L && GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity1))
				{
					ActivityManager.Instance.Send_ACTIVITY_SPEVENT_LIST_SINGLE(eactivityType, b);
				}
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5, 0);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity3, 3, (int)eactivityType);
			}
		}
		else
		{
			if (b >= 5)
			{
				return;
			}
			this.SetCSData(MP, (int)b);
			if (this.CSActivityData[(int)b].EventBeginTime != 0L)
			{
				this.SendAskDownLoad();
			}
			if (this.CSActivityData[(int)b].EventBeginTime != this.CSActivityTime[(int)b])
			{
				this.CSActivityTime[(int)b] = this.CSActivityData[(int)b].EventBeginTime;
			}
			this.SetbOpenCSActivity(b, false);
			if (this.CSActivityData[(int)b].EventBeginTime != 0L && GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity1))
			{
				ActivityManager.Instance.Send_ACTIVITY_SPEVENT_LIST_SINGLE(eactivityType, b);
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity3, 3, (int)eactivityType);
		}
		this.SetTreasureBoxID(MP.ReadUShort(-1));
	}

	// Token: 0x0600009E RID: 158 RVA: 0x00009AEC File Offset: 0x00007CEC
	public void RecvActivity_KEventListSingle(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Activity);
		byte b = MP.ReadByte(-1);
		if (b != 0)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107u), 255, true);
			return;
		}
		EActivityType eactivityType = (EActivityType)(MP.ReadByte(-1) - 1);
		EActivityKingdomEventType inKvKType = (EActivityKingdomEventType)MP.ReadByte(-1);
		int kvkDataIndexByType = this.GetKvkDataIndexByType(eactivityType, inKvKType);
		if (kvkDataIndexByType == -1)
		{
			return;
		}
		if (eactivityType == EActivityType.EAT_FIFA)
		{
			int num = kvkDataIndexByType - 211;
			if (num >= this.FIFAData.Length)
			{
				return;
			}
			this.FIFAData[num].Name = MP.ReadUShort(-1);
			this.FIFAData[num].Pic = MP.ReadUShort(-1);
			this.FIFAData[num].PicStr = MP.ReadUShort(-1);
			this.FIFAData[num].DetailContentStrID = MP.ReadUShort(-1);
			for (int i = 0; i < 3; i++)
			{
				this.FIFAData[num].RequireScore[i] = MP.ReadUInt(-1);
			}
			this.FIFAData[num].EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt(-1);
			this.FIFAData[num].EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt(-1);
			this.FIFAData[num].EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort(-1);
			this.FIFAData[num].SpDegreePrizeFlag = MP.ReadByte(-1);
			this.FIFAData[num].EventBonusType = (EActEventBonusType)MP.ReadByte(-1);
		}
		else if (eactivityType == EActivityType.EAT_FIFA_KVK)
		{
			int num2 = kvkDataIndexByType - 211;
			if (num2 >= this.FIFAData.Length)
			{
				return;
			}
			this.FIFAData[num2].Name = MP.ReadUShort(-1);
			this.FIFAData[num2].Pic = MP.ReadUShort(-1);
			this.FIFAData[num2].PicStr = MP.ReadUShort(-1);
			this.FIFAData[num2].DetailContentStrID = MP.ReadUShort(-1);
			for (int j = 0; j < 3; j++)
			{
				this.FIFAData[num2].RequireScore[j] = MP.ReadUInt(-1);
			}
			this.FIFAData[num2].EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt(-1);
			this.FIFAData[num2].EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt(-1);
			this.FIFAData[num2].EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort(-1);
			this.FIFAData[num2].SpDegreePrizeFlag = MP.ReadByte(-1);
			this.FIFAData[num2].EventBonusType = (EActEventBonusType)MP.ReadByte(-1);
		}
		else
		{
			int num3 = kvkDataIndexByType - 201;
			if (num3 >= this.KvKActivityData.Length)
			{
				return;
			}
			this.KvKActivityData[num3].Name = MP.ReadUShort(-1);
			this.KvKActivityData[num3].Pic = MP.ReadUShort(-1);
			this.KvKActivityData[num3].PicStr = MP.ReadUShort(-1);
			this.KvKActivityData[num3].DetailContentStrID = MP.ReadUShort(-1);
			for (int k = 0; k < 3; k++)
			{
				this.KvKActivityData[num3].RequireScore[k] = MP.ReadUInt(-1);
			}
			this.KvKActivityData[num3].EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt(-1);
			this.KvKActivityData[num3].EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt(-1);
			this.KvKActivityData[num3].EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort(-1);
			this.KvKActivityData[num3].SpDegreePrizeFlag = MP.ReadByte(-1);
			this.KvKActivityData[num3].EventBonusType = (EActEventBonusType)MP.ReadByte(-1);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 4, kvkDataIndexByType);
	}

	// Token: 0x0600009F RID: 159 RVA: 0x00009EC0 File Offset: 0x000080C0
	public void RecvActivity_KEventDetail(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Activity);
		byte b = MP.ReadByte(-1);
		if (b != 0)
		{
			return;
		}
		EActivityType inType = (EActivityType)(MP.ReadByte(-1) - 1);
		EActivityKingdomEventType eactivityKingdomEventType = (EActivityKingdomEventType)MP.ReadByte(-1);
		int kvkDataIndexByType = this.GetKvkDataIndexByType(inType, eactivityKingdomEventType);
		if (kvkDataIndexByType == -1)
		{
			return;
		}
		int num = kvkDataIndexByType - 201;
		if (num >= this.KvKActivityData.Length)
		{
			return;
		}
		for (int i = 0; i < 6; i++)
		{
			this.KvKActivityData[num].GetScoreFactor[i].Factor = (EGetScoreFactor)MP.ReadByte(-1);
			this.KvKActivityData[num].GetScoreFactor[i].BonusRate = MP.ReadByte(-1);
		}
		for (int j = 0; j < 3; j++)
		{
			this.KvKActivityData[num].EventPrizeWorthData[j].Crystal = MP.ReadUInt(-1);
			this.KvKActivityData[num].EventPrizeWorthData[j].CrystalPrice = MP.ReadUInt(-1);
			this.KvKActivityData[num].EventPrizeWorthData[j].Priceless = MP.ReadUShort(-1);
		}
		double kingdomKvKRank = MP.ReadDouble(-1);
		if (eactivityKingdomEventType == EActivityKingdomEventType.EAKET_KingdomEvent)
		{
			this.KingdomKvKRank = kingdomKvKRank;
		}
		int num2 = 0;
		for (int k = 0; k < 3; k++)
		{
			this.KvKActivityData[num].DataLen[k] = MP.ReadByte(-1);
			num2 += (int)this.KvKActivityData[num].DataLen[k];
		}
		for (int l = 0; l < num2; l++)
		{
			this.KvKActivityData[num].DegreePrize[l].Rank = MP.ReadByte(-1);
			this.KvKActivityData[num].DegreePrize[l].ItemID = MP.ReadUShort(-1);
			this.KvKActivityData[num].DegreePrize[l].Num = MP.ReadByte(-1);
		}
		this.KvKActivityData[num].bAskDetailData = true;
		if (this.bAskDetailData && !this.bReOpenPrize && this.door != null)
		{
			if (this.bReOpen)
			{
				if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity2))
				{
					this.door.CloseMenu(false);
				}
				this.bReOpen = false;
			}
			this.door.OpenMenu(EGUIWindow.UI_Activity2, kvkDataIndexByType, 0, false);
		}
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x0000A14C File Offset: 0x0000834C
	public void RecvActivity_Kevent_UpdateStateE(MessagePacket MP)
	{
		EActivityState eventState = this.KvKActivityData[4].EventState;
		EActivityType eactivityType = (EActivityType)(MP.ReadByte(-1) - 1);
		EActivityKingdomEventType inKvKType = (EActivityKingdomEventType)MP.ReadByte(-1);
		EActivityState eactivityState = (EActivityState)MP.ReadByte(-1);
		long num = MP.ReadLong(-1);
		uint eventReqiureTIme = MP.ReadUInt(-1);
		byte eventRank = MP.ReadByte(-1);
		if (eactivityType == EActivityType.EAT_AllianceMobilization)
		{
			MobilizationManager.Instance.SetAllyMobilizationBeginTime(num);
			this.AllyMobilizationData.EventState = eactivityState;
			this.AllyMobilizationData.EventBeginTime = num;
			this.AllyMobilizationData.EventReqiureTIme = eventReqiureTIme;
			if (eactivityState == EActivityState.EAS_Prepare || eactivityState == EActivityState.EAS_None)
			{
				this.AllyMobilizationData.EventScore = 0UL;
				this.AllyMobilizationData.bAskDetailData = false;
				this.AllyMobilizationData.bAskRankPrize = false;
				if (eactivityState == EActivityState.EAS_Prepare)
				{
					this.Send_ACTIVITY_EVENT_LIST_SINGLE((byte)eactivityType);
				}
				this.AMAllianceID = 0u;
			}
			else if (eactivityState == EActivityState.EAS_ReplayRanking)
			{
				this.AllyMobilizationData.bAskDetailData = false;
			}
			else if (eactivityState == EActivityState.EAS_Run)
			{
				this.AllyMobilizationData.EventScore = 0UL;
				this.AMAllianceID = DataManager.Instance.RoleAlliance.Id;
			}
			this.CheckAMActivityTime();
			this.CheckAMCountTime();
			if (eactivityState == EActivityState.EAS_Prepare || eactivityState == EActivityState.EAS_None)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5, 0);
			}
			else
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, 206);
			}
			if (eactivityState == EActivityState.EAS_ReplayRanking || eactivityState == EActivityState.EAS_Prepare)
			{
				MobilizationManager.Instance.bFirstOpen = true;
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 6, 0);
			if (eactivityState == EActivityState.EAS_ReplayRanking)
			{
				MobilizationManager.Instance.mMissionID = 0;
				DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, false, 0L, 0u);
				this.CheckAMShowHint();
			}
			else if (eactivityState == EActivityState.EAS_None)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_RewardsSelect, 2, 0);
			}
		}
		else if (eactivityType == EActivityType.EAT_KingdomKillEvent || eactivityType == EActivityType.EAT_KingdomNormalEvent || eactivityType == EActivityType.EAT_KingdomMatchEvent)
		{
			int kvkDataIndexByType = this.GetKvkDataIndexByType(eactivityType, inKvKType);
			if (kvkDataIndexByType == -1)
			{
				return;
			}
			int num2 = kvkDataIndexByType - 201;
			if (num2 >= this.KvKActivityData.Length)
			{
				return;
			}
			this.KvKActivityData[num2].ActiveType = eactivityType;
			EActivityState eventState2 = this.KvKActivityData[num2].EventState;
			this.SetKVKState(num2, eactivityState);
			this.KvKActivityData[num2].EventBeginTime = num;
			this.KvKActivityData[num2].EventReqiureTIme = eventReqiureTIme;
			if ((num2 == 0 && eactivityState == EActivityState.EAS_Prepare) || (num2 == 4 && eactivityState == EActivityState.EAS_Run))
			{
				this.KvKActivityData[num2].EventRank = eventRank;
			}
			this.CheckKVKCountTime((EKVKActivityType)num2);
			if (num2 == 4)
			{
				for (int i = 2; i <= 3; i++)
				{
					this.SetKVKState(i, eactivityState);
					this.KvKActivityData[i].ActiveType = this.KvKActivityData[4].ActiveType;
					this.KvKActivityData[i].EventBeginTime = num;
					this.KvKActivityData[i].EventReqiureTIme = eventReqiureTIme;
					if (eactivityState == EActivityState.EAS_Run)
					{
						this.KvKActivityData[i].EventRank = eventRank;
					}
					this.CheckKVKCountTime((EKVKActivityType)i);
				}
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, 203);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, 204);
				if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity1))
				{
					if (eactivityState == EActivityState.EAS_Prepare)
					{
						ActivityManager.Instance.Send_ACTIVITY_KEVENT_LIST_SINGLE(205);
					}
					else if (eactivityState == EActivityState.EAS_Run)
					{
						ActivityManager.Instance.Send_ACTIVITY_KEVENT_LIST_SINGLE(203);
						ActivityManager.Instance.Send_ACTIVITY_KEVENT_LIST_SINGLE(204);
					}
				}
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5, 0);
				if (eventState2 == EActivityState.EAS_Prepare && this.KvKActivityData[4].EventState == EActivityState.EAS_Run)
				{
					this.bShowRunningP = false;
					this.bShowRunningE = false;
					CString cstring = StringManager.Instance.SpawnString(300);
					cstring.Append(DataManager.Instance.mStringTable.GetStringByID(9376u));
					GUIManager.Instance.WonderCountStr.Add(cstring);
					GUIManager.Instance.SetRunningText(cstring);
				}
				else if (eventState2 == EActivityState.EAS_Run && this.KvKActivityData[4].EventState == EActivityState.EAS_HomeStart)
				{
					this.bShowRunningP = false;
					this.bShowRunningE = false;
					CString cstring2 = StringManager.Instance.SpawnString(300);
					cstring2.Append(DataManager.Instance.mStringTable.GetStringByID(9811u));
					GUIManager.Instance.WonderCountStr.Add(cstring2);
					GUIManager.Instance.SetRunningText(cstring2);
				}
				if (eactivityState == EActivityState.EAS_HomeStart)
				{
					this.KVKHuntOrder = 0;
					this.KVKReTime = 0L;
				}
			}
			else if (num2 == 0 && eactivityState == EActivityState.EAS_Prepare && GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity1))
			{
				ActivityManager.Instance.Send_ACTIVITY_KEVENT_LIST_SINGLE(201);
			}
			if (eactivityState == EActivityState.EAS_None || eventState2 == EActivityState.EAS_None)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5, 0);
			}
			else
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, kvkDataIndexByType);
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, kvkDataIndexByType);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity4, 1, kvkDataIndexByType);
			GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
			this.UpDateKvKState(eventState);
		}
		else if (eactivityType == EActivityType.EAT_KingOfTheWorld)
		{
			if (this.KOWData.EventState != eactivityState)
			{
				this.KOWData.EventState = eactivityState;
				byte kingdomtableid = 0;
				if (DataManager.MapDataController.GetWorldKingdomTableID(this.KOWKingdomID, out kingdomtableid))
				{
					DataManager.MapDataController.KingdomNotifyObserver(kingdomtableid, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_OWNERKINGDOMID);
				}
			}
			this.KOWData.EventBeginTime = num;
			this.KOWData.EventReqiureTIme = eventReqiureTIme;
			this.KOWData.EventPrizeID = MP.ReadUShort(-1);
			this.KOWData.EventPrizeID2 = MP.ReadUShort(-1);
			this.KOWData.EventPrizeID3 = MP.ReadUShort(-1);
			if (this.KOWData.EventState == EActivityState.EAS_ReplayRanking)
			{
				this.KOWData.bAskDetailData = false;
			}
			else
			{
				this.KOWData.bAskDetailData = true;
			}
			if ((eactivityState == EActivityState.EAS_Prepare || eactivityState == EActivityState.EAS_None) && eactivityState == EActivityState.EAS_Prepare)
			{
				this.Send_ACTIVITY_EVENT_LIST_SINGLE((byte)eactivityType);
			}
			this.CheckKOWCountTime();
			if (eactivityState == EActivityState.EAS_Prepare || eactivityState == EActivityState.EAS_None)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5, 0);
			}
			else
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, 207);
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, 207);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderReward, 0, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 6, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 9, 1);
			DataManager.Instance.UpdateItemBuffIcon();
			GameManager.OnRefresh(NetworkNews.Refresh_BuffList, null);
		}
		else if (eactivityType == EActivityType.EAT_FIFA)
		{
			EActivityState eventState3 = this.FIFAData[2].EventState;
			this.NowFIFAEventType = eactivityType;
			int num3 = 3;
			for (int j = 0; j < num3; j++)
			{
				this.FIFAData[j].ActiveType = eactivityType;
				this.FIFAData[j].EventState = eactivityState;
				this.FIFAData[j].EventBeginTime = num;
				this.FIFAData[j].EventReqiureTIme = eventReqiureTIme;
				if (eactivityState == EActivityState.EAS_Run)
				{
					this.FIFAData[j].EventRank = eventRank;
				}
				this.CheckFIFACountTime((EActivityKingdomEventType)j);
			}
			if (eactivityState == EActivityState.EAS_Prepare || eactivityState == EActivityState.EAS_None)
			{
				for (int k = 0; k < num3; k++)
				{
					this.FIFAData[k].EventScore = 0UL;
					this.FIFAData[k].bAskDetailData = false;
					this.FIFAData[k].bAskRankPrize = false;
				}
				if (eactivityState == EActivityState.EAS_Prepare)
				{
					CString cstring3 = StringManager.Instance.SpawnString(300);
					cstring3.Append(DataManager.Instance.mStringTable.GetStringByID(14726u));
					GUIManager.Instance.WonderCountStr.Add(cstring3);
					GUIManager.Instance.SetRunningText(cstring3);
					CString cstring4 = StringManager.Instance.SpawnString(30);
					cstring4.Append("UI/NPC_1002");
					AssetManager.GetAssetBundleDownload(cstring4, AssetPath.UI, AssetType.NPC, 1002, false);
					StringManager.Instance.DeSpawnString(cstring4);
				}
			}
			else if (eactivityState == EActivityState.EAS_ReplayRanking)
			{
				for (int l = 0; l < num3; l++)
				{
					this.FIFAData[l].bAskDetailData = false;
				}
			}
			else if (eactivityState == EActivityState.EAS_Run)
			{
				for (int m = 0; m < num3; m++)
				{
					this.FIFAData[m].EventScore = 0UL;
				}
			}
			GUIManager guimanager = GUIManager.Instance;
			if (guimanager.FindMenu(EGUIWindow.UI_Activity1))
			{
				if (eactivityState == EActivityState.EAS_Prepare)
				{
					this.Send_FIFA_LIST_SINGLE(213);
				}
				else if (eactivityState == EActivityState.EAS_Run)
				{
					this.Send_FIFA_LIST_SINGLE(211);
					this.Send_FIFA_LIST_SINGLE(212);
				}
				guimanager.UpdateUI(EGUIWindow.UI_Activity1, 5, 0);
			}
			else
			{
				guimanager.UpdateUI(EGUIWindow.UI_Activity2, 10, 0);
				guimanager.UpdateUI(EGUIWindow.UI_Activity4, 3, 0);
			}
			this.UpDateFIFAState(eventState3);
		}
		else if (eactivityType == EActivityType.EAT_FIFA_KVK)
		{
			EActivityState eventState4 = this.FIFAData[2].EventState;
			this.NowFIFAEventType = eactivityType;
			int num4 = 3;
			for (int n = 0; n < num4; n++)
			{
				this.FIFAData[n].ActiveType = eactivityType;
				this.FIFAData[n].EventState = eactivityState;
				this.FIFAData[n].EventBeginTime = num;
				this.FIFAData[n].EventReqiureTIme = eventReqiureTIme;
				if (eactivityState == EActivityState.EAS_Run)
				{
					this.FIFAData[n].EventRank = eventRank;
				}
				this.CheckFIFACountTime((EActivityKingdomEventType)n);
			}
			if (eactivityState == EActivityState.EAS_Prepare || eactivityState == EActivityState.EAS_None)
			{
				for (int num5 = 0; num5 < num4; num5++)
				{
					this.FIFAData[num5].EventScore = 0UL;
					this.FIFAData[num5].bAskDetailData = false;
					this.FIFAData[num5].bAskRankPrize = false;
				}
				if (eactivityState == EActivityState.EAS_Prepare)
				{
					CString cstring5 = StringManager.Instance.SpawnString(30);
					cstring5.Append("UI/NPC_1002");
					AssetManager.GetAssetBundleDownload(cstring5, AssetPath.UI, AssetType.NPC, 1002, false);
					StringManager.Instance.DeSpawnString(cstring5);
				}
			}
			else if (eactivityState == EActivityState.EAS_ReplayRanking)
			{
				for (int num6 = 0; num6 < num4; num6++)
				{
					this.FIFAData[num6].bAskDetailData = false;
				}
			}
			else if (eactivityState == EActivityState.EAS_Run)
			{
				for (int num7 = 0; num7 < num4; num7++)
				{
					this.FIFAData[num7].EventScore = 0UL;
				}
			}
			this.CopyFIFAKVKToKVK(eventState);
			GUIManager guimanager2 = GUIManager.Instance;
			if (guimanager2.FindMenu(EGUIWindow.UI_Activity1))
			{
				if (eactivityState == EActivityState.EAS_Prepare)
				{
					this.Send_FIFA_LIST_SINGLE(213);
				}
				else if (eactivityState == EActivityState.EAS_Run)
				{
					this.Send_FIFA_LIST_SINGLE(211);
					this.Send_FIFA_LIST_SINGLE(212);
				}
				guimanager2.UpdateUI(EGUIWindow.UI_Activity1, 5, 0);
			}
			else
			{
				guimanager2.UpdateUI(EGUIWindow.UI_Activity2, 10, 0);
				guimanager2.UpdateUI(EGUIWindow.UI_Activity4, 3, 0);
			}
			if (eventState4 == EActivityState.EAS_Prepare && this.KvKActivityData[4].EventState == EActivityState.EAS_Run)
			{
				this.bShowRunningP = false;
				this.bShowRunningE = false;
				CString cstring6 = StringManager.Instance.SpawnString(300);
				cstring6.Append(DataManager.Instance.mStringTable.GetStringByID(9376u));
				GUIManager.Instance.WonderCountStr.Add(cstring6);
				GUIManager.Instance.SetRunningText(cstring6);
			}
			this.UpDateFIFAState(eventState4);
			Debug.Log("UpDateFIFAState -----------------------------------------");
			Debug.Log("NowFIFAEventType = " + this.NowFIFAEventType);
			Debug.Log("EventState " + this.FIFAData[2].EventState);
			Debug.Log("EventBeginTime " + GameConstants.GetDateTime(this.FIFAData[2].EventBeginTime).ToString("MM/dd/yy HH:mm:ss"));
			Debug.Log("EventEndTime " + GameConstants.GetDateTime(this.FIFAData[2].EventBeginTime + (long)((ulong)this.FIFAData[2].EventReqiureTIme)).ToString("MM/dd/yy HH:mm:ss"));
			Debug.Log("----------------------------------------- UpDateFIFAState");
		}
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x0000AD88 File Offset: 0x00008F88
	public void RecvActivity_Kevent_RankingPrize(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Activity);
		byte b = MP.ReadByte(-1);
		if (b != 0)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107u), 255, true);
			return;
		}
		EActivityType eactivityType = (EActivityType)(MP.ReadByte(-1) - 1);
		EActivityKingdomEventType inKvKType = (EActivityKingdomEventType)MP.ReadByte(-1);
		int kvkDataIndexByType = this.GetKvkDataIndexByType(eactivityType, inKvKType);
		if (kvkDataIndexByType == -1)
		{
			return;
		}
		if (eactivityType == EActivityType.EAT_FIFA || eactivityType == EActivityType.EAT_FIFA_KVK)
		{
			int num = kvkDataIndexByType - 211;
			if (num >= this.FIFAData.Length)
			{
				return;
			}
			for (int i = 0; i < 7; i++)
			{
				this.FIFAData[num].RankPrizeWorthData[i].Crystal = MP.ReadUInt(-1);
				this.FIFAData[num].RankPrizeWorthData[i].CrystalPrice = MP.ReadUInt(-1);
				this.FIFAData[num].RankPrizeWorthData[i].Priceless = MP.ReadUShort(-1);
			}
			int num2 = 0;
			for (int j = 0; j < 7; j++)
			{
				this.FIFAData[num].RankingPrizeDataLen[j] = MP.ReadByte(-1);
				num2 += (int)this.FIFAData[num].RankingPrizeDataLen[j];
			}
			for (int k = 0; k < num2; k++)
			{
				this.FIFAData[num].RankingPrize[k].Rank = MP.ReadByte(-1);
				this.FIFAData[num].RankingPrize[k].ItemID = MP.ReadUShort(-1);
				this.FIFAData[num].RankingPrize[k].Num = MP.ReadByte(-1);
			}
			this.FIFAData[num].bAskRankPrize = true;
		}
		else
		{
			int num3 = kvkDataIndexByType - 201;
			if (num3 >= this.KvKActivityData.Length)
			{
				return;
			}
			for (int l = 0; l < 7; l++)
			{
				this.KvKActivityData[num3].RankPrizeWorthData[l].Crystal = MP.ReadUInt(-1);
				this.KvKActivityData[num3].RankPrizeWorthData[l].CrystalPrice = MP.ReadUInt(-1);
				this.KvKActivityData[num3].RankPrizeWorthData[l].Priceless = MP.ReadUShort(-1);
			}
			int num4 = 0;
			for (int m = 0; m < 7; m++)
			{
				this.KvKActivityData[num3].RankingPrizeDataLen[m] = MP.ReadByte(-1);
				num4 += (int)this.KvKActivityData[num3].RankingPrizeDataLen[m];
			}
			for (int n = 0; n < num4; n++)
			{
				this.KvKActivityData[num3].RankingPrize[n].Rank = MP.ReadByte(-1);
				this.KvKActivityData[num3].RankingPrize[n].ItemID = MP.ReadUShort(-1);
				this.KvKActivityData[num3].RankingPrize[n].Num = MP.ReadByte(-1);
			}
			this.KvKActivityData[num3].bAskRankPrize = true;
		}
		if (this.door != null)
		{
			if (this.bReOpenPrize)
			{
				if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity4))
				{
					this.door.CloseMenu(false);
				}
				this.bReOpenPrize = false;
			}
			this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, kvkDataIndexByType, false);
		}
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x0000B128 File Offset: 0x00009328
	public void RecvActivity_AM_RankingPrize(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Activity);
		byte b = MP.ReadByte(-1);
		if (b != 0)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107u), 255, true);
			return;
		}
		for (int i = 0; i < 5; i++)
		{
			this.AllyMobilizationData.RankPrizeWorthData[i].Crystal = MP.ReadUInt(-1);
			this.AllyMobilizationData.RankPrizeWorthData[i].CrystalPrice = MP.ReadUInt(-1);
			this.AllyMobilizationData.RankPrizeWorthData[i].Priceless = MP.ReadUShort(-1);
		}
		int num = 0;
		for (int j = 0; j < 5; j++)
		{
			this.AllyMobilizationData.RankingPrizeDataLen[j] = MP.ReadByte(-1);
			num += (int)this.AllyMobilizationData.RankingPrizeDataLen[j];
		}
		for (int k = 0; k < num; k++)
		{
			this.AllyMobilizationData.RankingPrize[k].Rank = MP.ReadByte(-1);
			this.AllyMobilizationData.RankingPrize[k].ItemID = MP.ReadUShort(-1);
			this.AllyMobilizationData.RankingPrize[k].Num = MP.ReadByte(-1);
		}
		this.AllyMobilizationData.bAskRankPrize = true;
		if (this.door != null)
		{
			if (this.bReOpenPrize)
			{
				if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity4))
				{
					this.door.CloseMenu(false);
				}
				this.bReOpenPrize = false;
			}
			this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, 206, false);
		}
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x0000B2EC File Offset: 0x000094EC
	public void RecvActivity_KOW_KingInfo(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Activity);
		this.WKKingdom = MP.ReadUShort(-1);
		this.WKTag.Length = 0;
		MP.ReadStringPlus(3, this.WKTag, -1);
		this.WKName.Length = 0;
		MP.ReadStringPlus(13, this.WKName, -1);
		this.WKIcon = MP.ReadUShort(-1);
		this.KOWData.bAskDetailData = true;
		if (this.bAskDetailData && this.door != null)
		{
			if (this.bReOpen)
			{
				if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity2))
				{
					this.door.CloseMenu(false);
				}
				this.bReOpen = false;
			}
			this.door.OpenMenu(EGUIWindow.UI_Activity2, 207, 0, true);
		}
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x0000B3C8 File Offset: 0x000095C8
	public void RecvActivity_AllianceSummon_UpdateState(MessagePacket MP)
	{
		EActivityState eactivityState = (EActivityState)MP.ReadByte(-1);
		long eventBeginTime = MP.ReadLong(-1);
		uint eventReqiureTIme = MP.ReadUInt(-1);
		this.AllianceSummonData.EventState = eactivityState;
		this.AllianceSummonData.EventBeginTime = eventBeginTime;
		this.AllianceSummonData.EventReqiureTIme = eventReqiureTIme;
		if (eactivityState == EActivityState.EAS_Prepare || eactivityState == EActivityState.EAS_None)
		{
			this.AllianceSummonAllianceID = 0u;
			this.AllianceSummonEventInfoID = 0;
			this.SetAllianceSummon_Score(0u);
			this.ClearAllianceSummonData();
			this.AllianceSummonData.bAskRankPrize = false;
			if (eactivityState == EActivityState.EAS_Prepare)
			{
				this.Send_ACTIVITY_EVENT_LIST_SINGLE(11);
			}
		}
		else if (eactivityState == EActivityState.EAS_ReplayRanking)
		{
			this.AllianceSummonData.bAskDetailData = false;
		}
		else if (eactivityState == EActivityState.EAS_Run)
		{
			this.AllianceSummonData.EventScore = 0UL;
			this.AllianceSummonAllianceID = DataManager.Instance.RoleAlliance.Id;
		}
		this.CheckASCountTime();
		if (eactivityState == EActivityState.EAS_Prepare || eactivityState == EActivityState.EAS_None)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5, 0);
		}
		else
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, 208);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, 208);
		if (eactivityState != EActivityState.EAS_Run)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 5, 0);
		}
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x0000B4FC File Offset: 0x000096FC
	public void RecvActivity_AllianceSummon_KMSG(MessagePacket MP)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		CString cstring3 = StringManager.Instance.StaticString1024();
		MP.ReadStringPlus(3, cstring2, -1);
		MP.ReadStringPlus(20, cstring3, -1);
		ushort inKey = MP.ReadUShort(-1);
		uint nameID = (uint)DataManager.MapDataController.MapMonsterTable.GetRecordByKey(inKey).NameID;
		cstring.ClearString();
		cstring.StringToFormat(cstring2);
		cstring.StringToFormat(cstring3);
		cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(nameID));
		cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(14513u));
		DataManager.Instance.AddSystemMessage(cstring, 8, -1L);
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x0000B5B8 File Offset: 0x000097B8
	public void RecvActivity_UPDATESTATE(MessagePacket MP)
	{
		EActivityType eactivityType = (EActivityType)(MP.ReadByte(-1) - 1);
		EActivityState eactivityState = (EActivityState)MP.ReadByte(-1);
		long eventBeginTime = MP.ReadLong(-1);
		uint eventReqiureTIme = MP.ReadUInt(-1);
		if (eactivityType == EActivityType.EAT_FederalEvent)
		{
			this.NobilityActivityData.EventState = eactivityState;
			this.NobilityActivityData.EventBeginTime = eventBeginTime;
			this.NobilityActivityData.EventReqiureTIme = eventReqiureTIme;
			if (eactivityState == EActivityState.EAS_None)
			{
				this.FederalHomeKingdomWonderID = 0;
				this.FederalFightingWonderID = 0;
				this.FederalFullEventTimeWonderID = 0;
			}
			else if (eactivityState == EActivityState.EAS_Prepare)
			{
				this.Send_ACTIVITY_EVENT_LIST_SINGLE(12);
			}
			else if (eactivityState != EActivityState.EAS_ReplayRanking)
			{
				if (eactivityState == EActivityState.EAS_Run)
				{
				}
			}
			this.CheckNWActivityTime();
			this.CheckNWCountTime();
			if (eactivityState == EActivityState.EAS_Prepare || eactivityState == EActivityState.EAS_None)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5, 0);
			}
			else
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, 209);
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, 209);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_MiniMap, 1, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 6, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena_Info, 2, 0);
		}
		else if (eactivityType == EActivityType.EAT_AllianceWar)
		{
			this.AllianceWarData.EventState = eactivityState;
			this.AllianceWarData.EventBeginTime = eventBeginTime;
			this.AllianceWarData.EventReqiureTIme = eventReqiureTIme;
			this.AW_EventBeginTime = this.AllianceWarData.EventBeginTime;
			if (eactivityState == EActivityState.EAS_Prepare || eactivityState == EActivityState.EAS_None)
			{
				this.AllianceWarData.bAskRankPrize = false;
				if (eactivityState == EActivityState.EAS_Prepare)
				{
					this.Send_ACTIVITY_EVENT_LIST_SINGLE((byte)eactivityType);
				}
			}
			this.CheckAWCountTime(false);
			this.SetNowState(true);
			this.CheckAWActivityTime();
			this.UpDateAllianceWarTop();
			if (eactivityState == EActivityState.EAS_Prepare || eactivityState == EActivityState.EAS_None)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5, 0);
			}
			else
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 17, 0);
			}
		}
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x0000B788 File Offset: 0x00009988
	private void SetKVKState(int DataTypeIndex, EActivityState State)
	{
		if (DataTypeIndex >= this.KvKActivityData.Length)
		{
			return;
		}
		this.KvKActivityData[DataTypeIndex].EventState = State;
		if (State == EActivityState.EAS_Prepare || State == EActivityState.EAS_None)
		{
			this.KvKActivityData[DataTypeIndex].EventScore = 0UL;
			this.KvKActivityData[DataTypeIndex].bAskDetailData = false;
			this.KvKActivityData[DataTypeIndex].bAskRankPrize = false;
		}
		else if (State == EActivityState.EAS_ReplayRanking)
		{
			this.KvKActivityData[DataTypeIndex].bAskDetailData = false;
		}
		else if (State == EActivityState.EAS_Run)
		{
			this.KvKActivityData[DataTypeIndex].EventScore = 0UL;
		}
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x0000B820 File Offset: 0x00009A20
	public void SetTreasureBoxID(ushort ID)
	{
		this.TreasureBoxID = ID;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.Append("UI/UIActivityBack_3");
		if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Activity, AssetType.ActivityBack, 3, false))
		{
			this.bDownLoadPic3 = true;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 23, 0);
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x0000B870 File Offset: 0x00009A70
	public void SendAskDownLoad()
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.Append("UI/UIActivityBack_1");
		if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Activity, AssetType.ActivityBack, 1, false))
		{
			this.bDownLoadPic1 = true;
		}
		cstring = StringManager.Instance.StaticString1024();
		cstring.Append("UI/UIActivityBack_2");
		if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Activity, AssetType.ActivityBack, 2, false))
		{
			this.bDownLoadPic2 = true;
		}
		for (int i = 0; i < this.CSActivityData.Length; i++)
		{
			if (this.CSActivityData[i].EventBeginTime != 0L)
			{
				cstring = StringManager.Instance.StaticString1024();
				cstring.IntToFormat((long)this.CSActivityData[i].DetailStr, 1, false);
				cstring.AppendFormat("UI/UIActivityPackage_{0}");
				if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Activity, AssetType.ActivityPackage, this.CSActivityData[i].DetailStr, false))
				{
					this.CSActivityData[i].bDownLoadStr = true;
				}
			}
		}
		for (int j = 0; j < this.SPActivityData.Length; j++)
		{
			if (this.SPActivityData[j].EventBeginTime != 0L)
			{
				cstring = StringManager.Instance.StaticString1024();
				cstring.IntToFormat((long)this.SPActivityData[j].DetailStr, 1, false);
				cstring.AppendFormat("UI/UIActivityPackage_{0}");
				if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Activity, AssetType.ActivityPackage, this.SPActivityData[j].DetailStr, false))
				{
					this.SPActivityData[j].bDownLoadStr = true;
				}
			}
		}
	}

	// Token: 0x060000AA RID: 170 RVA: 0x0000B9D8 File Offset: 0x00009BD8
	public void UpDateDownLoad(byte[] meg)
	{
		byte b = meg[2];
		ushort num = GameConstants.ConvertBytesToUShort(meg, 3);
		if (meg[5] == 1)
		{
			if (b == 0)
			{
				AssetManager.RequestActivityBundle(num, true);
			}
			else
			{
				AssetManager.RequestActivityPackage(num, true);
			}
			return;
		}
		if (meg[5] == 2)
		{
			return;
		}
		if (b == 0)
		{
			if (num == 1)
			{
				if (this.bDownLoadPic1)
				{
					this.bUpDatePic1 = true;
				}
				else
				{
					this.bDownLoadPic1 = true;
				}
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 6, 0);
			}
			else if (num == 2)
			{
				if (this.bDownLoadPic2)
				{
					this.bUpDatePic2 = true;
				}
				else
				{
					this.bDownLoadPic2 = true;
				}
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity3, 1, 0);
			}
			else if (num == 3)
			{
				if (this.bDownLoadPic3)
				{
					this.bUpDatePic3 = true;
				}
				else
				{
					this.bDownLoadPic3 = true;
				}
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 23, 0);
			}
		}
		else
		{
			for (int i = 0; i < this.CSActivityData.Length; i++)
			{
				if (this.CSActivityData[i].EventBeginTime != 0L && this.CSActivityData[i].DetailStr == num)
				{
					if (this.CSActivityData[i].bDownLoadStr)
					{
						this.CSActivityData[i].bUpDateStr = true;
					}
					else
					{
						this.CSActivityData[i].bDownLoadStr = true;
					}
				}
			}
			for (int j = 0; j < this.SPActivityData.Length; j++)
			{
				if (this.SPActivityData[j].EventBeginTime != 0L && this.SPActivityData[j].DetailStr == num)
				{
					if (this.SPActivityData[j].bDownLoadStr)
					{
						this.SPActivityData[j].bUpDateStr = true;
					}
					else
					{
						this.SPActivityData[j].bDownLoadStr = true;
					}
				}
			}
			if (this.FBActivityData.Name != 0 && this.FBActivityData.DetailStr == num)
			{
				if (this.FBActivityData.bDownLoadStr)
				{
					this.FBActivityData.bUpDateStr = true;
				}
				else
				{
					this.FBActivityData.bDownLoadStr = true;
				}
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 7, 0);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity3, 2, 0);
		}
	}

	// Token: 0x060000AB RID: 171 RVA: 0x0000BC18 File Offset: 0x00009E18
	public void SetCSData(MessagePacket MP, int tmpIndex = -1)
	{
		if (tmpIndex == -1)
		{
			for (int i = 0; i < 5; i++)
			{
				this.CSActivityData[i].Initial();
				this.CSActivityData[i].DetailPic = MP.ReadUShort(-1);
				this.CSActivityData[i].HeadStr = MP.ReadUShort(-1);
				this.CSActivityData[i].DetailStr = MP.ReadUShort(-1);
				this.CSActivityData[i].GoToButton = MP.ReadUShort(-1);
				this.CSActivityData[i].Marquee = MP.ReadUShort(-1);
				this.CSActivityData[i].EventBeginTime = MP.ReadLong(-1);
				this.CSActivityData[i].EventEndTime = MP.ReadLong(-1);
				if (this.CSActivityData[i].EventBeginTime == 0L)
				{
					this.CSActivityData[i].Initial();
				}
				this.CheckActivity(0, i, this.CSActivityData[i].EventBeginTime);
			}
		}
		else
		{
			if (tmpIndex >= 5)
			{
				return;
			}
			this.CSActivityData[tmpIndex].Initial();
			this.CSActivityData[tmpIndex].DetailPic = MP.ReadUShort(-1);
			this.CSActivityData[tmpIndex].HeadStr = MP.ReadUShort(-1);
			this.CSActivityData[tmpIndex].DetailStr = MP.ReadUShort(-1);
			this.CSActivityData[tmpIndex].GoToButton = MP.ReadUShort(-1);
			this.CSActivityData[tmpIndex].Marquee = MP.ReadUShort(-1);
			this.CSActivityData[tmpIndex].EventBeginTime = MP.ReadLong(-1);
			this.CSActivityData[tmpIndex].EventEndTime = MP.ReadLong(-1);
			if (this.CSActivityData[tmpIndex].EventBeginTime == 0L)
			{
				this.CSActivityData[tmpIndex].Initial();
			}
			this.CheckActivity(0, tmpIndex, this.CSActivityData[tmpIndex].EventBeginTime);
		}
	}

	// Token: 0x060000AC RID: 172 RVA: 0x0000BDE8 File Offset: 0x00009FE8
	public void SetSPData(MessagePacket MP, int tmpIndex = -1)
	{
		if (tmpIndex == -1)
		{
			for (int i = 0; i < 5; i++)
			{
				this.SPActivityData[i].Initial();
				this.SPActivityData[i].DetailPic = MP.ReadUShort(-1);
				this.SPActivityData[i].HeadStr = MP.ReadUShort(-1);
				this.SPActivityData[i].DetailStr = MP.ReadUShort(-1);
				this.SPActivityData[i].GoToButton = MP.ReadUShort(-1);
				this.SPActivityData[i].Marquee = MP.ReadUShort(-1);
				this.SPActivityData[i].EventBeginTime = MP.ReadLong(-1);
				this.SPActivityData[i].EventEndTime = MP.ReadLong(-1);
				if (this.SPActivityData[i].EventBeginTime == 0L)
				{
					this.SPActivityData[i].Initial();
				}
				this.CheckActivity(1, i, this.SPActivityData[i].EventBeginTime);
				this.CheckShowSPMessage(i);
			}
		}
		else
		{
			if (tmpIndex >= 5)
			{
				return;
			}
			this.SPActivityData[tmpIndex].Initial();
			this.SPActivityData[tmpIndex].DetailPic = MP.ReadUShort(-1);
			this.SPActivityData[tmpIndex].HeadStr = MP.ReadUShort(-1);
			this.SPActivityData[tmpIndex].DetailStr = MP.ReadUShort(-1);
			this.SPActivityData[tmpIndex].GoToButton = MP.ReadUShort(-1);
			this.SPActivityData[tmpIndex].Marquee = MP.ReadUShort(-1);
			this.SPActivityData[tmpIndex].EventBeginTime = MP.ReadLong(-1);
			this.SPActivityData[tmpIndex].EventEndTime = MP.ReadLong(-1);
			if (this.SPActivityData[tmpIndex].EventBeginTime == 0L)
			{
				this.SPActivityData[tmpIndex].Initial();
			}
			this.CheckActivity(1, tmpIndex, this.SPActivityData[tmpIndex].EventBeginTime);
			this.CheckShowSPMessage(tmpIndex);
		}
	}

	// Token: 0x060000AD RID: 173 RVA: 0x0000BFC4 File Offset: 0x0000A1C4
	public void CheckMonster(MessagePacket MP, bool bSolo = true)
	{
		if (!bSolo)
		{
			for (int i = 0; i < 5; i++)
			{
				MP.ReadUShort(-1);
			}
			return;
		}
		this.MonsterCount = 0;
		for (int j = 0; j < 5; j++)
		{
			this.Monster[j] = MP.ReadUShort(-1);
			if (this.Monster[j] != 0)
			{
				this.MonsterCount += 1;
				MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.Monster[j]);
				CString cstring = StringManager.Instance.SpawnString(128);
				cstring.ClearString();
				cstring.IntToFormat((long)recordByKey.MapNPCNO, 3, false);
				cstring.AppendFormat("UI/NPC_{0}");
				AssetManager.GetAssetBundleDownload(cstring, AssetPath.UI, AssetType.NPC, this.Monster[j], false);
				Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(recordByKey.ModelID);
				cstring.ClearString();
				cstring.IntToFormat((long)recordByKey2.Graph, 1, false);
				cstring.AppendFormat("UI/MapNPCHead_{0}");
				if (recordByKey2.Graph > 0)
				{
					AssetManager.GetAssetBundleDownload(cstring, AssetPath.UI, AssetType.NPCHead, recordByKey2.Graph, false);
				}
				cstring.ClearString();
				cstring.IntToFormat((long)recordByKey2.Modle, 5, false);
				cstring.AppendFormat("Role/hero_{0}");
				if (recordByKey2.Modle > 0)
				{
					AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, recordByKey2.Modle, false);
				}
				if (recordByKey.SoundPackNO != 0)
				{
					cstring.ClearString();
					cstring.IntToFormat((long)recordByKey.SoundPackNO, 3, false);
					cstring.AppendFormat("Role/{0}");
					AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.HeroSFX, recordByKey.SoundPackNO, false);
				}
				if (recordByKey.ParticlePackNO != 0)
				{
					cstring.ClearString();
					cstring.IntToFormat((long)recordByKey.ParticlePackNO, 3, false);
					cstring.AppendFormat("Particle/Monster_Effects_{0}");
					AssetManager.GetAssetBundleDownload(cstring, AssetPath.Particle, AssetType.Effects, recordByKey.ParticlePackNO, false);
				}
				StringManager.Instance.DeSpawnString(cstring);
			}
			else
			{
				this.MonsterType[j] = 0;
			}
		}
	}

	// Token: 0x060000AE RID: 174 RVA: 0x0000C1C4 File Offset: 0x0000A3C4
	public void CheckMonsterType(MessagePacket MP, bool bSolo = true)
	{
		if (!bSolo)
		{
			for (int i = 0; i < 5; i++)
			{
				MP.ReadUShort(-1);
			}
			return;
		}
		for (int j = 0; j < 5; j++)
		{
			this.MonsterType[j] = MP.ReadUShort(-1);
		}
	}

	// Token: 0x060000AF RID: 175 RVA: 0x0000C214 File Offset: 0x0000A414
	private void CheckShowNpcMessage()
	{
		if (this.ActivityData[0].EventState == EActivityState.EAS_Run && DataManager.Instance.ServerTime - this.ActivityData[0].EventBeginTime <= 600L)
		{
			for (int i = 0; i < 5; i++)
			{
				if (this.MonsterType[i] == 1 && this.Monster[i] != 0)
				{
					uint num;
					if (this.Monster[i] == 22)
					{
						num = 9071u;
					}
					else if (this.Monster[i] == 23)
					{
						num = 9087u;
					}
					else if (this.Monster[i] == 24)
					{
						num = 9501u;
					}
					else if (this.Monster[i] == 25)
					{
						num = 9502u;
					}
					else if (this.Monster[i] == 26)
					{
						num = 9503u;
					}
					else if (this.Monster[i] == 14)
					{
						num = 9561u;
					}
					else if (this.Monster[i] >= 32 && this.Monster[i] <= 35)
					{
						num = (uint)(9562 + this.Monster[i] - 32);
					}
					else if (this.Monster[i] >= 41 && this.Monster[i] <= 50)
					{
						num = (uint)(10150 + this.Monster[i] - 41);
					}
					else
					{
						num = 9076u;
					}
					if (num > 0u)
					{
						this.MonstrCStr[i].Length = 0;
						this.MonstrCStr[i].Append(DataManager.Instance.mStringTable.GetStringByID(num));
						GUIManager.Instance.SetRunningText(this.MonstrCStr[i]);
					}
				}
			}
		}
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x0000C3D8 File Offset: 0x0000A5D8
	private void CheckShowSPMessage(int tmpIndex)
	{
		if (tmpIndex >= 5)
		{
			return;
		}
		if (this.SPActivityData[tmpIndex].Marquee > 0 && this.SPActivityData[tmpIndex].EventBeginTime > 0L && DataManager.Instance.ServerTime - this.SPActivityData[tmpIndex].EventBeginTime <= 600L)
		{
			this.MonstrCStr[tmpIndex].Length = 0;
			this.MonstrCStr[tmpIndex].Append(DataManager.Instance.mStringTable.GetStringByID((uint)this.SPActivityData[tmpIndex].Marquee));
			GUIManager.Instance.SetRunningText(this.MonstrCStr[tmpIndex]);
		}
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x0000C480 File Offset: 0x0000A680
	public void RecvActNews(MessagePacket MP)
	{
		this.NewsDataLen = MP.ReadByte(-1);
		if (this.NewsDataLen > 30)
		{
			this.NewsDataLen = 30;
		}
		for (int i = 0; i < (int)this.NewsDataLen; i++)
		{
			this.NewsData[i].ID = MP.ReadUInt(-1);
			this.NewsData[i].Time = MP.ReadLong(-1);
		}
		this.CheckNewsNo();
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x0000C4FC File Offset: 0x0000A6FC
	public void RecvDailyActNews(MessagePacket MP)
	{
		this.RcvDailyActNewsTime = MP.ReadLong(-1);
		this.DailyNewsLen = MP.ReadByte(-1);
		if (this.DailyNewsLen > 30)
		{
			this.DailyNewsLen = 30;
		}
		for (int i = 0; i < (int)this.DailyNewsLen; i++)
		{
			this.DailyNews[i] = MP.ReadUInt(-1);
		}
		this.CheckNewsNo();
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x0000C564 File Offset: 0x0000A764
	public void SetLastGetDailyGiftTime(long lTime)
	{
		this.SPLastGetDailyGiftTime = lTime;
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 23, 0);
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x0000C57C File Offset: 0x0000A77C
	public void RecvRunningText(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1) - 1;
		if (b >= 17)
		{
			return;
		}
		byte b2 = MP.ReadByte(-1);
		EActivityType eactivityType = (EActivityType)b;
		if (eactivityType != EActivityType.EAT_ComingSoonSpEvent)
		{
			if (eactivityType != EActivityType.EAT_SpecialEvent)
			{
				this.MarqueeInfo[(int)b].StrID = MP.ReadUShort(-1);
				this.MarqueeInfo[(int)b].BeginTime = MP.ReadLong(-1);
				this.MarqueeInfo[(int)b].RequireTime = MP.ReadUInt(-1);
				this.MarqueeInfo[(int)b].CircleHour = (uint)MP.ReadByte(-1);
				this.MarqueeInfo[(int)b].PlayMin = (uint)MP.ReadUShort(-1);
				this.MarqueeInfo[(int)b].NowTimes = 0L;
				this.MarqueeInfo[(int)b].EndTime = this.MarqueeInfo[(int)b].BeginTime + (long)((ulong)this.MarqueeInfo[(int)b].RequireTime);
				MarqueeInfoDataType[] marqueeInfo = this.MarqueeInfo;
				byte b3 = b;
				marqueeInfo[(int)b3].CircleHour = marqueeInfo[(int)b3].CircleHour * 3600u;
				MarqueeInfoDataType[] marqueeInfo2 = this.MarqueeInfo;
				byte b4 = b;
				marqueeInfo2[(int)b4].PlayMin = marqueeInfo2[(int)b4].PlayMin * 60u;
				this.MarqueeInfo[(int)b].NowTimes = 0L;
				if (this.MarqueeInfo[(int)b].StrID > 0)
				{
					this.CheckOne(ref this.MarqueeInfo[(int)b]);
				}
			}
			else
			{
				if (b2 >= 5)
				{
					return;
				}
				this.MarqueeInfoSP[(int)b2].StrID = MP.ReadUShort(-1);
				this.MarqueeInfoSP[(int)b2].BeginTime = MP.ReadLong(-1);
				this.MarqueeInfoSP[(int)b2].RequireTime = MP.ReadUInt(-1);
				this.MarqueeInfoSP[(int)b2].CircleHour = (uint)MP.ReadByte(-1);
				this.MarqueeInfoSP[(int)b2].PlayMin = (uint)MP.ReadUShort(-1);
				this.MarqueeInfoSP[(int)b2].EndTime = this.MarqueeInfoSP[(int)b2].BeginTime + (long)((ulong)this.MarqueeInfoSP[(int)b2].RequireTime);
				MarqueeInfoDataType[] marqueeInfoSP = this.MarqueeInfoSP;
				byte b5 = b2;
				marqueeInfoSP[(int)b5].CircleHour = marqueeInfoSP[(int)b5].CircleHour * 3600u;
				MarqueeInfoDataType[] marqueeInfoSP2 = this.MarqueeInfoSP;
				byte b6 = b2;
				marqueeInfoSP2[(int)b6].PlayMin = marqueeInfoSP2[(int)b6].PlayMin * 60u;
				this.MarqueeInfoSP[(int)b2].NowTimes = 0L;
				if (this.MarqueeInfoSP[(int)b2].StrID > 0)
				{
					this.CheckOne(ref this.MarqueeInfoSP[(int)b2]);
				}
			}
		}
		else
		{
			if (b2 >= 5)
			{
				return;
			}
			this.MarqueeInfoCS[(int)b2].StrID = MP.ReadUShort(-1);
			this.MarqueeInfoCS[(int)b2].BeginTime = MP.ReadLong(-1);
			this.MarqueeInfoCS[(int)b2].RequireTime = MP.ReadUInt(-1);
			this.MarqueeInfoCS[(int)b2].CircleHour = (uint)MP.ReadByte(-1);
			this.MarqueeInfoCS[(int)b2].PlayMin = (uint)MP.ReadUShort(-1);
			this.MarqueeInfoCS[(int)b2].EndTime = this.MarqueeInfoCS[(int)b2].BeginTime + (long)((ulong)this.MarqueeInfoCS[(int)b2].RequireTime);
			MarqueeInfoDataType[] marqueeInfoCS = this.MarqueeInfoCS;
			byte b7 = b2;
			marqueeInfoCS[(int)b7].CircleHour = marqueeInfoCS[(int)b7].CircleHour * 3600u;
			MarqueeInfoDataType[] marqueeInfoCS2 = this.MarqueeInfoCS;
			byte b8 = b2;
			marqueeInfoCS2[(int)b8].PlayMin = marqueeInfoCS2[(int)b8].PlayMin * 60u;
			this.MarqueeInfoCS[(int)b2].NowTimes = 0L;
			if (this.MarqueeInfoCS[(int)b2].StrID > 0)
			{
				this.CheckOne(ref this.MarqueeInfoCS[(int)b2]);
			}
		}
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x0000C94C File Offset: 0x0000AB4C
	private void CheckOne(ref MarqueeInfoDataType tmp)
	{
		long serverTime = DataManager.Instance.ServerTime;
		if (serverTime >= tmp.BeginTime && serverTime < tmp.EndTime)
		{
			bool flag = false;
			if (tmp.CircleHour == 0u)
			{
				if (tmp.NowTimes == 0L && serverTime - tmp.BeginTime < (long)((ulong)tmp.PlayMin))
				{
					flag = true;
					tmp.NowTimes = 1L;
				}
			}
			else
			{
				long num = serverTime - tmp.BeginTime;
				long num2 = num / (long)((ulong)tmp.CircleHour);
				long num3 = num - (long)((ulong)tmp.CircleHour * (ulong)num2);
				if (num3 < (long)((ulong)tmp.PlayMin) && num2 >= tmp.NowTimes)
				{
					flag = true;
					tmp.NowTimes = num2 + 1L;
				}
			}
			if (flag)
			{
				tmp.ActivityStr.Length = 0;
				tmp.ActivityStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint)tmp.StrID));
				GUIManager.Instance.SetRunningText(tmp.ActivityStr);
			}
		}
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x0000CA40 File Offset: 0x0000AC40
	private void CheckRunningText()
	{
		for (int i = 0; i < 5; i++)
		{
			if (this.MarqueeInfoCS[i].StrID > 0)
			{
				this.CheckOne(ref this.MarqueeInfoCS[i]);
			}
		}
		for (int j = 0; j < 5; j++)
		{
			if (this.MarqueeInfoSP[j].StrID > 0)
			{
				this.CheckOne(ref this.MarqueeInfoSP[j]);
			}
		}
		for (int k = 0; k < this.MarqueeInfo.Length; k++)
		{
			if (k != 4 && k != 5)
			{
				if (this.MarqueeInfo[k].StrID > 0)
				{
					this.CheckOne(ref this.MarqueeInfo[k]);
				}
			}
		}
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x0000CB18 File Offset: 0x0000AD18
	public void RecvSPExtraData(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1) - 1;
		if (b >= 17)
		{
			return;
		}
		byte b2 = MP.ReadByte(-1);
		byte b3 = MP.ReadByte(-1);
		EActivityType eactivityType = (EActivityType)b;
		if (eactivityType != EActivityType.EAT_ComingSoonSpEvent)
		{
			if (eactivityType == EActivityType.EAT_SpecialEvent)
			{
				if (b2 >= 5)
				{
					return;
				}
				int num = 0;
				while (num < (int)b3 && num < 4)
				{
					this.SPActivityData[(int)b2].ContentTimeData[num].BeginTime = MP.ReadLong(-1);
					this.SPActivityData[(int)b2].ContentTimeData[num].RequireTime = MP.ReadUInt(-1);
					num++;
				}
			}
		}
		else
		{
			if (b2 >= 5)
			{
				return;
			}
			int num2 = 0;
			while (num2 < (int)b3 && num2 < 4)
			{
				this.CSActivityData[(int)b2].ContentTimeData[num2].BeginTime = MP.ReadLong(-1);
				this.CSActivityData[(int)b2].ContentTimeData[num2].RequireTime = MP.ReadUInt(-1);
				num2++;
			}
		}
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x0000CC30 File Offset: 0x0000AE30
	public void RecvKvKMatchInfo(MessagePacket MP)
	{
		this.MatchKingdomIDCount = MP.ReadUShort(-1);
		for (int i = 0; i < 6; i++)
		{
			this.MatchKingdomID[i] = MP.ReadUShort(-1);
		}
		this.MatchKingdomCount = MP.ReadByte(-1);
		this.KVKHuntCircleMin = MP.ReadUShort(-1);
		for (int j = 0; j < 3; j++)
		{
			this.GetHuntFactor[j] = new ActGetScoreFactorDataType[6];
			for (int k = 0; k < 6; k++)
			{
				this.GetHuntFactor[j][k].Factor = (EGetScoreFactor)MP.ReadByte(-1);
				this.GetHuntFactor[j][k].BonusRate = MP.ReadByte(-1);
			}
		}
		if (this.MatchKingdomCount == 4)
		{
			Array.Clear(this.MatchKingdomID_4, 0, this.MatchKingdomID_4.Length);
			for (int l = 0; l < 4; l++)
			{
				if (this.MatchKingdomID[l] != 0 && this.MatchKingdomID[l] == DataManager.MapDataController.kingdomData.kingdomID)
				{
					int num = l;
					int num2 = 0;
					while (num2 < this.MatchKingdomID_4.Length && num2 < (int)this.MatchKingdomIDCount)
					{
						this.MatchKingdomID_4[num2] = this.MatchKingdomID[num];
						num2++;
						num++;
						if (num >= 4 || this.MatchKingdomID[num] == 0)
						{
							num = 0;
						}
					}
					if (this.MatchKingdomIDCount == 4)
					{
						ushort num3 = this.MatchKingdomID_4[2];
						this.MatchKingdomID_4[2] = this.MatchKingdomID_4[3];
						this.MatchKingdomID_4[3] = num3;
					}
					break;
				}
			}
		}
		bool flag = false;
		EActivityState eventState = this.KvKActivityData[4].EventState;
		if (eventState > EActivityState.EAS_None && eventState < EActivityState.EAS_ReplayRanking && eventState != EActivityState.EAS_Prepare)
		{
			if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod != KINGDOM_PERIOD.KP_KVK)
			{
				DataManager.MapDataController.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_KVK;
				flag = true;
			}
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.kingdomData.kingdomID && DataManager.MapDataController.kingdomData.kingdomPeriod != KINGDOM_PERIOD.KP_KVK)
			{
				DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_KVK;
				flag = true;
			}
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
			{
				if (DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_KVK)
				{
					DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_KVK;
					flag = true;
				}
			}
			else if (this.IsMatchKvk())
			{
				for (int m = 0; m < this.MatchKingdomID.Length; m++)
				{
					if (this.MatchKingdomID[m] != 0 && this.MatchKingdomID[m] == DataManager.MapDataController.FocusKingdomID)
					{
						if (DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_KVK)
						{
							DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_KVK;
							flag = true;
						}
						break;
					}
				}
			}
			if (eventState != EActivityState.EAS_Run)
			{
				DataManager.MapDataController.UpdateKingdomPeriod(KINGDOM_PERIOD.KP_KVK);
			}
		}
		else if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
		{
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.kingdomData.kingdomID)
			{
				DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
			}
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
			{
				DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
			}
			else if (this.IsMatchKvk())
			{
				for (int n = 0; n < this.MatchKingdomID.Length; n++)
				{
					if (this.MatchKingdomID[n] != 0 && this.MatchKingdomID[n] == DataManager.MapDataController.FocusKingdomID)
					{
						if (DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_INFIGHTING && DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_WORLD_WAR)
						{
							DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
							flag = true;
						}
						break;
					}
				}
			}
		}
		else
		{
			if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod != KINGDOM_PERIOD.KP_INFIGHTING)
			{
				DataManager.MapDataController.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
				flag = true;
			}
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.kingdomData.kingdomID && DataManager.MapDataController.kingdomData.kingdomPeriod != KINGDOM_PERIOD.KP_INFIGHTING)
			{
				DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
				flag = true;
			}
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
			{
				if (DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_INFIGHTING)
				{
					DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
					flag = true;
				}
			}
			else if (this.IsMatchKvk())
			{
				for (int num4 = 0; num4 < this.MatchKingdomID.Length; num4++)
				{
					if (this.MatchKingdomID[num4] != 0 && this.MatchKingdomID[num4] == DataManager.MapDataController.FocusKingdomID)
					{
						if (DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_INFIGHTING)
						{
							DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
							flag = true;
						}
						break;
					}
				}
			}
		}
		if (flag)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 25, 0);
			DataManager.msgBuffer[0] = 53;
			DataManager.msgBuffer[1] = 1;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x0000D194 File Offset: 0x0000B394
	public void RecvKvKHuntInfo(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		this.KVKReTime = MP.ReadLong(-1);
		if (this.KVKHuntOrder != b)
		{
			this.KVKHuntOrder = b;
			this.reflashKvKKingdomType();
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 25, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 9, 0);
	}

	// Token: 0x060000BA RID: 186 RVA: 0x0000D1EC File Offset: 0x0000B3EC
	public void RecvNPCCITY_UPDATEINFO(MessagePacket MP)
	{
		this.NPCCityEndTime = MP.ReadLong(-1);
	}

	// Token: 0x060000BB RID: 187 RVA: 0x0000D1FC File Offset: 0x0000B3FC
	private void SetAllianceSummonDate()
	{
		if (this.AllianceSummonEventInfoID == 0)
		{
			return;
		}
		DataManager dataManager = DataManager.Instance;
		SummonInfo recordByKey = dataManager.SummonInfoData.GetRecordByKey(this.AllianceSummonEventInfoID);
		if (recordByKey.ID == this.AllianceSummonEventInfoID)
		{
			for (int i = 0; i < 3; i++)
			{
				this.AllianceSummonData.RequireScore[i] = recordByKey.PointData[i].Score;
			}
			int num = 0;
			while (num < 6 && num < recordByKey.FactorKey.Length)
			{
				this.AllianceSummonData.GetScoreFactor[num].Factor = (EGetScoreFactor)recordByKey.FactorKey[num];
				if (this.AllianceSummonData.GetScoreFactor[num].Factor != (EGetScoreFactor)0)
				{
					this.AllianceSummonData.GetScoreFactor[num].BonusRate = 1;
				}
				num++;
			}
			this.AllianceSummonData.bAskDetailData = true;
		}
	}

	// Token: 0x060000BC RID: 188 RVA: 0x0000D2F0 File Offset: 0x0000B4F0
	public void SetAllianceSummon_Score(uint score)
	{
		this.AllianceSummon_Score = score;
		this.AllianceSummonData.EventScore = (ulong)score;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 2, 208);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 1, 208);
		if (this.mAllianceDonation_Score < score)
		{
			this.mAllianceDonation_Score = score;
			GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 3, 0);
		}
	}

	// Token: 0x060000BD RID: 189 RVA: 0x0000D35C File Offset: 0x0000B55C
	public void SetAllianceSummon_NPCCityCombatTimes(byte Index, byte Times)
	{
		if (Index > 0 && Index <= 5)
		{
			ActivityManager.Instance.NPCCityCombatTimes[(int)(Index - 1)] = Times;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 5, 208);
		}
	}

	// Token: 0x060000BE RID: 190 RVA: 0x0000D390 File Offset: 0x0000B590
	public void ClearAllianceSummonData()
	{
		this.AllianceSummon_SummonData.SummonPoint = 0;
		this.AllianceSummon_SummonData.MonsterID = 0;
		this.AllianceSummon_SummonData.MonsterPos.KingdomID = 0;
		this.AllianceSummon_SummonData.MonsterPos.CombatPoint.zoneID = 0;
		this.AllianceSummon_SummonData.MonsterPos.CombatPoint.pointID = 0;
		this.AllianceSummon_SummonData.MonsterEndTime = 0L;
		for (int i = 0; i < 5; i++)
		{
			this.NPCCityCombatTimes[i] = 0;
		}
	}

	// Token: 0x060000BF RID: 191 RVA: 0x0000D41C File Offset: 0x0000B61C
	public void Send_FEDERAL_ORDERLIST()
	{
		if (this.NobilityActivityData.bAskDetailData)
		{
			if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_Activity2, 209, 0, true);
			}
		}
		else if (this.NobilityActivityData.EventState == EActivityState.EAS_None)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107u), 255, true);
		}
		else
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_FEDERAL_ORDERLIST;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Activity);
		}
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x0000D4D0 File Offset: 0x0000B6D0
	public void Recv_FEDERAL_ORDERLIST(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		this.NobilityActivityData.InitGroupData(b);
		for (int i = 0; i < (int)b; i++)
		{
			this.NobilityActivityData.NobilityGroupData[i].KingdomID = MP.ReadUShort(-1);
			this.NobilityActivityData.NobilityGroupData[i].WonderID = MP.ReadByte(-1);
			this.NobilityActivityData.NobilityGroupData[i].EventState = (EActivityState)MP.ReadByte(-1);
			this.NobilityActivityData.NobilityGroupData[i].EventBeginTime = MP.ReadLong(-1);
			this.NobilityActivityData.NobilityGroupData[i].EventRequireTime = MP.ReadUInt(-1);
			this.NobilityActivityData.NobilityGroupDataIndex[(int)this.NobilityActivityData.NobilityGroupData[i].WonderID] = (byte)i;
		}
		this.NobilityActivityData.SetGroupEventTime();
		this.NobilityActivityData.NobilityGroupDataSortIndex.Sort(this.NW_Comparer);
		this.NobilityActivityData.bAskDetailData = true;
		if (this.door != null)
		{
			if (this.bReOpen)
			{
				if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity2))
				{
					this.door.CloseMenu(false);
				}
				this.bReOpen = false;
			}
			this.door.OpenMenu(EGUIWindow.UI_Activity2, 209, 0, true);
		}
		GUIManager.Instance.HideUILock(EUILock.Activity);
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x0000D64C File Offset: 0x0000B84C
	public void Send_FEDERAL_ORDERDETAIL(byte WonderID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_FEDERAL_ORDERDETAIL;
		messagePacket.AddSeqId();
		messagePacket.Add(WonderID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Activity);
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x0000D694 File Offset: 0x0000B894
	public void Recv_FEDERAL_ORDERDETAIL(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = this.NobilityActivityData.NobilityGroupDataIndex[(int)b];
		EActivityState eactivityState = (EActivityState)MP.ReadByte(-1);
		if (eactivityState == EActivityState.EAS_Prepare)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					this.NobilityActivityData.NobilityGroupData[(int)b2].PreparePrize[i][j].Rank = MP.ReadByte(-1);
					this.NobilityActivityData.NobilityGroupData[(int)b2].PreparePrize[i][j].ItemID = MP.ReadUShort(-1);
					this.NobilityActivityData.NobilityGroupData[(int)b2].PreparePrize[i][j].Num = MP.ReadByte(-1);
				}
			}
			this.NobilityActivityData.NobilityGroupData[(int)b2].bAskPrizeData = true;
		}
		else if (eactivityState == EActivityState.EAS_Run)
		{
			for (int k = 0; k < 3; k++)
			{
				for (int l = 0; l < 3; l++)
				{
					this.NobilityActivityData.NobilityGroupData[(int)b2].PreparePrize[k][l].Rank = MP.ReadByte(-1);
					this.NobilityActivityData.NobilityGroupData[(int)b2].PreparePrize[k][l].ItemID = MP.ReadUShort(-1);
					this.NobilityActivityData.NobilityGroupData[(int)b2].PreparePrize[k][l].Num = MP.ReadByte(-1);
				}
			}
			byte b3 = MP.ReadByte(-1);
			this.NobilityActivityData.NobilityGroupData[(int)b2].FightKingdomCount = b3;
			this.NobilityActivityData.NobilityGroupData[(int)b2].FightKingdomID = new ushort[(int)b3];
			for (int m = 0; m < (int)b3; m++)
			{
				this.NobilityActivityData.NobilityGroupData[(int)b2].FightKingdomID[m] = MP.ReadUShort(-1);
			}
			this.NobilityActivityData.NobilityGroupData[(int)b2].bAskPrizeData = true;
			this.NobilityActivityData.NobilityGroupData[(int)b2].bAskKingdomData = true;
		}
		else
		{
			this.NobilityActivityData.NobilityGroupData[(int)b2].NobilityKingdomID = MP.ReadUShort(-1);
			CString outString = StringManager.Instance.StaticString1024();
			CString cstring = StringManager.Instance.StaticString1024();
			MP.ReadStringPlus(3, outString, -1);
			MP.ReadStringPlus(13, cstring, -1);
			this.NobilityActivityData.NobilityGroupData[(int)b2].NobilityName.Length = 0;
			this.NobilityActivityData.NobilityGroupData[(int)b2].NobilityName.Append(cstring);
			this.NobilityActivityData.NobilityGroupData[(int)b2].NobilityHeroID = MP.ReadUShort(-1);
			this.NobilityActivityData.NobilityGroupData[(int)b2].bAskNobilityData = true;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 7, 209);
		GUIManager.Instance.HideUILock(EUILock.Activity);
	}

	// Token: 0x060000C3 RID: 195 RVA: 0x0000D9C0 File Offset: 0x0000BBC0
	public void Recv_FEDERAL_UPDATE_ORDERLIST(MessagePacket MP)
	{
		ushort num = MP.ReadUShort(-1);
		byte b = MP.ReadByte(-1);
		EActivityState eactivityState = (EActivityState)MP.ReadByte(-1);
		long eventBeginTime = MP.ReadLong(-1);
		uint eventRequireTime = MP.ReadUInt(-1);
		bool flag = b == this.FederalActKingdomWonderID;
		if (eactivityState != EActivityState.EAS_None)
		{
			if (eactivityState != EActivityState.EAS_Prepare)
			{
				if (eactivityState == EActivityState.EAS_Run)
				{
					this.FederalFightingWonderID = b;
					this.FederalFullEventTimeWonderID = b;
				}
				else if (eactivityState == EActivityState.EAS_ReplayRanking)
				{
					this.FederalFightingWonderID = 0;
				}
			}
		}
		if (this.NobilityActivityData.GroupCount > 0)
		{
			byte b2 = this.NobilityActivityData.NobilityGroupDataIndex[(int)b];
			this.NobilityActivityData.NobilityGroupData[(int)b2].EventState = eactivityState;
			this.NobilityActivityData.NobilityGroupData[(int)b2].EventBeginTime = eventBeginTime;
			this.NobilityActivityData.NobilityGroupData[(int)b2].EventRequireTime = eventRequireTime;
			if (eactivityState == EActivityState.EAS_ReplayRanking)
			{
				this.NobilityActivityData.NobilityGroupData[(int)b2].bAskNobilityData = (MP.ReadByte(-1) == 0);
			}
			this.NobilityActivityData.NobilityGroupDataSortIndex.Sort(this.NW_Comparer);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 6, 209);
		}
		this.CheckNWActivityTime();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_MiniMap, 1, 0);
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x0000DB10 File Offset: 0x0000BD10
	public void Recv_FEDERAL_ORDERKINGDOMS(MessagePacket MP)
	{
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_WonderLand))
		{
			DukeNukem.FederalOrderKingdom(MP);
		}
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x0000DB30 File Offset: 0x0000BD30
	public void Recv_FEDERAL_RESETEVENT(MessagePacket MP)
	{
		long eventBeginTime = MP.ReadLong(-1);
		uint eventReqiureTIme = MP.ReadUInt(-1);
		this.NobilityActivityData.EventBeginTime = eventBeginTime;
		this.NobilityActivityData.EventReqiureTIme = eventReqiureTIme;
		this.NobilityActivityData.bAskDetailData = false;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 8, 209);
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x0000DB84 File Offset: 0x0000BD84
	public void Send_REQUEST_ALLIANCEWAR_RANKPRIZE()
	{
		if (this.AllianceWarData.bAskRankPrize)
		{
			if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, 210, false);
			}
		}
		else
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_RANKPRIZE;
			messagePacket.AddSeqId();
			messagePacket.Add(this.AW_Rank);
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Activity);
		}
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x0000DC0C File Offset: 0x0000BE0C
	public void Recv_RESP_ALLIANCEWAR_RANKPRIZE(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Activity);
		byte b = MP.ReadByte(-1);
		if (b != 0)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107u), 255, true);
			return;
		}
		int num = 0;
		int num2 = 0;
		while (num2 < 7 && num2 < 5)
		{
			this.AllianceWarData.RankingPrizeDataLen[num2] = 4;
			num += (int)this.AllianceWarData.RankingPrizeDataLen[num2];
			num2++;
		}
		for (int i = 0; i < num; i++)
		{
			this.AllianceWarData.RankingPrize[i].Rank = MP.ReadByte(-1);
			this.AllianceWarData.RankingPrize[i].ItemID = MP.ReadUShort(-1);
			this.AllianceWarData.RankingPrize[i].Num = MP.ReadByte(-1);
		}
		this.AllianceWarData.bAskRankPrize = true;
		if (this.door != null)
		{
			if (this.bReOpenPrize)
			{
				if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity4))
				{
					this.door.CloseMenu(false);
				}
				this.bReOpenPrize = false;
			}
			this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, 210, false);
		}
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x0000DD64 File Offset: 0x0000BF64
	public void ClearAllianceWarData()
	{
		this.AW_EventBeginTime = this.AllianceWarData.EventBeginTime;
		UIAllianceWar_Rank.isDataReady = false;
		this.AW_NextRank = 0;
		this.AW_MinRank = 1;
		this.AW_MaxRank = 5;
		LeaderBoardManager.Instance.AllianceWarGroupBoardUpdateTime = 0L;
		LeaderBoardManager.Instance.AllianceWarAlliBoardUpdateTime = 0L;
		this.AW_bcalculateEnd = false;
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x0000DDBC File Offset: 0x0000BFBC
	public void ClearAWPara()
	{
		this.AW_SignUpAllianceID = 0u;
		this.AW_GetGift = 0;
		this.AW_PrepareTime = 0;
		this.AW_FightTime = 0;
		this.AW_WaitTime = 0;
		this.AW_State = EAllianceWarState.EAWS_None;
		this.AW_Round = 0;
		this.AW_RoundBeginTime = 0L;
		this.AW_RoundEndTime = 0L;
		this.AllianceWarMgr.Clear();
	}

	// Token: 0x060000CA RID: 202 RVA: 0x0000DE18 File Offset: 0x0000C018
	public void SetNowState(bool bNeedUpDate = true)
	{
		this.AW_StateOld = this.AW_State;
		if (this.AllianceWarData.EventState == EActivityState.EAS_Prepare)
		{
			this.AW_Round = 0;
			this.AW_RoundBeginTime = 0L;
			this.AW_RoundEndTime = 0L;
			this.AW_State = EAllianceWarState.EAWS_SignUp;
		}
		else if (this.AllianceWarData.EventState == EActivityState.EAS_Run)
		{
			this.AW_State = EAllianceWarState.EAWS_Prepare;
		}
		else if (this.AllianceWarData.EventState == EActivityState.EAS_ReplayRanking)
		{
			if (DataManager.Instance.RoleAlliance.Id == 0u)
			{
				this.AW_State = EAllianceWarState.EAWS_Replay;
			}
			else
			{
				if (this.AW_OneRoundTime == 0u)
				{
					this.AW_State = EAllianceWarState.EAWS_Run;
					return;
				}
				byte aw_Round = this.AW_Round;
				long num = this.ServerEventTime - this.AllianceWarData.EventBeginTime;
				if (num < 0L)
				{
					return;
				}
				long num2 = num / (long)((ulong)this.AW_OneRoundTime) + 1L;
				if (num2 <= 0L || num2 > 4L)
				{
					this.AW_Round = 0;
					this.AW_RoundBeginTime = 0L;
					this.AW_RoundEndTime = 0L;
					this.AW_State = EAllianceWarState.EAWS_Replay;
				}
				else
				{
					this.AW_Round = (byte)num2;
					this.AW_RoundBeginTime = this.AllianceWarData.EventBeginTime + (long)(this.AW_Round - 1) * (long)((ulong)this.AW_OneRoundTime);
					this.AW_RoundEndTime = this.AW_RoundBeginTime + (long)((ulong)this.AW_OneRoundTime);
					this.AW_State = EAllianceWarState.EAWS_Run;
				}
				if (aw_Round != this.AW_Round)
				{
					GameManager.OnRefresh(NetworkNews.Refresh_AllianceWarRound, DataManager.msgBuffer);
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 17, 0);
				}
			}
		}
		else
		{
			this.ClearAWPara();
			this.ClearAllianceWarData();
		}
		if (bNeedUpDate && this.AW_StateOld != this.AW_State)
		{
			this.CheckAWShowHint();
			if (!this.OpenNextStateUI())
			{
				GameManager.OnRefresh(NetworkNews.Refresh_AllianceWarState, DataManager.msgBuffer);
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 17, 0);
		}
	}

	// Token: 0x060000CB RID: 203 RVA: 0x0000DFEC File Offset: 0x0000C1EC
	public void OpenAllianceWarDetail()
	{
		byte b = 0;
		if (DataManager.Instance.RoleAlliance.Id == 0u || this.AW_NowAllianceEnterWar == 0)
		{
			if (this.AW_State == EAllianceWarState.EAWS_Replay)
			{
				b = 3;
			}
			else
			{
				b = 1;
			}
		}
		else
		{
			if (this.AW_OneRoundTime == 0u)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8459u), 255, true);
				return;
			}
			if (this.AW_State == EAllianceWarState.EAWS_SignUp || this.AW_State == EAllianceWarState.EAWS_Prepare)
			{
				b = 1;
			}
			else if (this.AW_State == EAllianceWarState.EAWS_Run)
			{
				b = 2;
			}
			else if (this.AW_State == EAllianceWarState.EAWS_Replay)
			{
				b = 3;
			}
		}
		if (b == 1)
		{
			this.AllianceWarReopenCheck();
			this.door.OpenMenu(EGUIWindow.UI_AllianceWarRegister, 0, 0, false);
		}
		else if (b == 2)
		{
			this.Send_ALLIANCEWAR_REPLAY();
		}
		else if (b == 3)
		{
			UIAllianceWar_Rank.OpenUI();
		}
	}

	// Token: 0x060000CC RID: 204 RVA: 0x0000E0E8 File Offset: 0x0000C2E8
	public void UpDateAllianceWarTop()
	{
		if (GUIManager.Instance.m_ActivityWindow != null)
		{
			GUIManager.Instance.m_ActivityWindow.RefreshTop();
		}
	}

	// Token: 0x060000CD RID: 205 RVA: 0x0000E11C File Offset: 0x0000C31C
	public void SetActivityWindowTimeVisible(bool bVisible)
	{
		if (GUIManager.Instance.m_ActivityWindow != null)
		{
			GUIManager.Instance.m_ActivityWindow.SetTopTimeVivsible(bVisible);
		}
	}

	// Token: 0x060000CE RID: 206 RVA: 0x0000E144 File Offset: 0x0000C344
	public bool OpenNextStateUI()
	{
		if ((GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarRegister) && this.AW_State >= EAllianceWarState.EAWS_Run) || (GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarOver) && this.AW_State >= EAllianceWarState.EAWS_Replay))
		{
			this.AllianceWarSendReOpenMenu();
			return true;
		}
		return false;
	}

	// Token: 0x060000CF RID: 207 RVA: 0x0000E1A4 File Offset: 0x0000C3A4
	public void AllianceWarSendReOpenMenu()
	{
		this.AW_bWaitOpenNext = true;
		this.OpenAllianceWarDetail();
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x0000E1B4 File Offset: 0x0000C3B4
	public void AllianceWarReopenCheck()
	{
		if (this.AW_bWaitOpenNext)
		{
			if (this.door != null && (GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarRegister) || GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWar_Rank) || GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarOver) || GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarBattle)))
			{
				this.door.CloseMenu(false);
			}
			this.AW_bWaitOpenNext = false;
		}
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x0000E254 File Offset: 0x0000C454
	private void UpDateFIFARunningtext()
	{
		ActivityDataType activityDataType = this.FIFAData[2];
		if (activityDataType.EventState == EActivityState.EAS_Run && !this.FIFA_bShowRunningE && this.NowWaveEndTime != 0L && this.NowWaveEndTime - this.ServerEventTime == 600L)
		{
			this.FIFA_bShowRunningE = true;
			CString cstring = StringManager.Instance.SpawnString(300);
			if (activityDataType.ActiveType == EActivityType.EAT_FIFA_KVK)
			{
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(14730u));
			}
			else
			{
				cstring.Append(DataManager.Instance.mStringTable.GetStringByID(14728u));
			}
			GUIManager.Instance.WonderCountStr.Add(cstring);
			GUIManager.Instance.SetRunningText(cstring);
		}
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x0000E31C File Offset: 0x0000C51C
	private void ClearFIFAData()
	{
		EActivityState eventState = this.FIFAData[2].EventState;
		this.NowFIFAEventType = EActivityType.EAT_MAX;
		int num = 3;
		for (int i = 0; i < num; i++)
		{
			this.FIFAData[i].Initial();
			this.FIFAData[i].ActiveType = EActivityType.EAT_FIFA;
			this.FIFAData[i].FIFAActiveType = (EActivityKingdomEventType)i;
		}
		this.CheckFIFAActivityTime();
		this.UpDateFIFAState(eventState);
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x0000E38C File Offset: 0x0000C58C
	private void SetbOpenFIFAActivity(bool value)
	{
		this.bOpenFIFAActivity = value;
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x0000E398 File Offset: 0x0000C598
	private void SettmpFIFATypeByIndex(byte index)
	{
		if (index < 211 || index > 213)
		{
			this.FIFA_tmpActType = EActivityType.EAT_MAX;
			this.FIFA_tmpFIFAType = EActivityKingdomEventType.EAKET_MAX;
			return;
		}
		this.FIFA_tmpActType = this.NowFIFAEventType;
		if (index == 211)
		{
			this.FIFA_tmpFIFAType = EActivityKingdomEventType.EAKET_SoloEvent;
		}
		else if (index == 212)
		{
			this.FIFA_tmpFIFAType = EActivityKingdomEventType.EAKET_AllianceEvent;
		}
		else
		{
			this.FIFA_tmpFIFAType = EActivityKingdomEventType.EAKET_KingdomEvent;
		}
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x0000E40C File Offset: 0x0000C60C
	public byte GetNowWave()
	{
		EActivityState fifastate = this.GetFIFAState();
		if (fifastate == EActivityState.EAS_None)
		{
			return 0;
		}
		byte result = 0;
		if (fifastate == EActivityState.EAS_Prepare)
		{
			result = 1;
		}
		else if (fifastate == EActivityState.EAS_Run)
		{
			long num = this.FIFAData[2].EventBeginTime;
			long num2 = num + (long)((ulong)this.FIFAData[2].EventReqiureTIme);
			long num3 = (long)(this.WaveRequireMin * 60);
			long num4 = (long)((this.WaveIntervalMin - this.WaveRequireMin) * 60);
			if (num4 <= 0L)
			{
				return 0;
			}
			if (this.ServerEventTime < num)
			{
				result = 1;
			}
			else if (this.ServerEventTime >= num2)
			{
				result = this.WaveNum;
			}
			else
			{
				num2 = num + num3;
				for (byte b = 0; b < this.WaveNum; b += 1)
				{
					if (this.ServerEventTime >= num && this.ServerEventTime < num2)
					{
						result = b + 1;
						break;
					}
					num = num2;
					num2 += num4;
					if (this.ServerEventTime >= num && this.ServerEventTime < num2)
					{
						result = b + 2;
						break;
					}
					num = num2;
					num2 += num3;
				}
			}
		}
		return result;
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x0000E52C File Offset: 0x0000C72C
	public EActivityState GetFIFAState()
	{
		return this.FIFAData[2].EventState;
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x0000E53C File Offset: 0x0000C73C
	public bool IsInFIFA(ushort KingdomID = 0, bool bExceptRanking = false)
	{
		EActivityState eventState = this.FIFAData[2].EventState;
		if (KingdomID != 0)
		{
			return false;
		}
		if (bExceptRanking)
		{
			return eventState == EActivityState.EAS_Run;
		}
		return eventState > EActivityState.EAS_None && eventState < EActivityState.EAS_ReplayRanking && eventState != EActivityState.EAS_Prepare;
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x0000E584 File Offset: 0x0000C784
	public bool IsInFIFA_KVK(ushort KingdomID = 0, bool bExceptRanking = false)
	{
		return this.IsInFIFA(KingdomID, bExceptRanking) && this.FIFAData[2].ActiveType == EActivityType.EAT_FIFA_KVK;
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x0000E5A8 File Offset: 0x0000C7A8
	public void UpDateFIFAState(EActivityState OldState)
	{
		EActivityState eventState = this.FIFAData[2].EventState;
		if (eventState > EActivityState.EAS_None && eventState < EActivityState.EAS_ReplayRanking && eventState != EActivityState.EAS_Prepare)
		{
			DataManager.MapDataController.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_KVK;
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.kingdomData.kingdomID)
			{
				DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_KVK;
			}
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
			{
				DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_KVK;
			}
			else
			{
				for (int i = 0; i < this.MatchKingdomID.Length; i++)
				{
					if (this.MatchKingdomID[i] != 0 && this.MatchKingdomID[i] == DataManager.MapDataController.FocusKingdomID)
					{
						DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_KVK;
						break;
					}
				}
			}
			if (eventState != EActivityState.EAS_Run)
			{
				DataManager.MapDataController.UpdateKingdomPeriod(KINGDOM_PERIOD.KP_KVK);
			}
		}
		else if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
		{
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.kingdomData.kingdomID)
			{
				DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
			}
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
			{
				DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
			}
			else
			{
				for (int j = 0; j < this.MatchKingdomID.Length; j++)
				{
					if (this.MatchKingdomID[j] != 0 && this.MatchKingdomID[j] == DataManager.MapDataController.FocusKingdomID)
					{
						if (DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_WORLD_WAR)
						{
							DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
						}
						break;
					}
				}
			}
		}
		else
		{
			DataManager.MapDataController.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.kingdomData.kingdomID)
			{
				DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
			}
			if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
			{
				DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
			}
			else
			{
				for (int k = 0; k < this.MatchKingdomID.Length; k++)
				{
					if (this.MatchKingdomID[k] != 0 && this.MatchKingdomID[k] == DataManager.MapDataController.FocusKingdomID)
					{
						DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
						break;
					}
				}
			}
		}
		if (OldState != eventState && eventState == EActivityState.EAS_None)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBallBoard, 5, 0);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 28, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_MiniMap, 2, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBall, 3, 3);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 29, 0);
	}

	// Token: 0x060000DA RID: 218 RVA: 0x0000E89C File Offset: 0x0000CA9C
	public void SetFIFAEventPoint(byte DataTypeIndex, ulong Score)
	{
		if ((int)DataTypeIndex < this.FIFAData.Length)
		{
			this.FIFAData[(int)DataTypeIndex].EventScore = Score;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 2, (int)(DataTypeIndex + 211));
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 1, 0);
		DataManager.MissionDataManager.CheckChanged(eMissionKind.Mark, 186, (ushort)DataTypeIndex);
		if (Score != 0UL && DataTypeIndex == 0 && this.FIFAData[2].EventState == EActivityState.EAS_Run && this.FIFAData[2].ActiveType == EActivityType.EAT_FIFA_KVK)
		{
			FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.CREDITS_FOR_KVK, this.FIFAData[2].EventBeginTime, this.FIFAData[(int)DataTypeIndex].EventScore);
		}
	}

	// Token: 0x060000DB RID: 219 RVA: 0x0000E954 File Offset: 0x0000CB54
	public void SetNowWaveEndTime(long WaveEnd, bool bCheckRunningText = true)
	{
		this.NowWaveEndTime = WaveEnd;
		if (bCheckRunningText && this.NowWaveEndTime != 0L && this.NowWaveEndTime != this.FIFA_NowEndTime)
		{
			this.FIFA_bShowRunningE = false;
			this.FIFA_NowEndTime = this.NowWaveEndTime;
			CString cstring = StringManager.Instance.SpawnString(300);
			cstring.Append(DataManager.Instance.mStringTable.GetStringByID(14727u));
			GUIManager.Instance.WonderCountStr.Add(cstring);
			GUIManager.Instance.SetRunningText(cstring);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 11, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 28, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBall, 3, 3);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_MiniMap, 2, 0);
		if (this.NowWaveEndTime == 0L)
		{
			FootballManager.Instance.CheckFootBallIDHitClose(2);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 29, 0);
	}

	// Token: 0x060000DC RID: 220 RVA: 0x0000EA44 File Offset: 0x0000CC44
	public void Recv_FIFA_Info(MessagePacket MP)
	{
		this.NowFIFAEventType = (EActivityType)(MP.ReadByte(-1) - 1);
		if (this.NowFIFAEventType == EActivityType.EAT_FIFA)
		{
			this.bRecvFIFAData = true;
			int num = 2;
			EActivityState eventState = this.FIFAData[num].EventState;
			EActivityState eventState2 = (EActivityState)MP.ReadByte(-1);
			long eventBeginTime = MP.ReadLong(-1);
			uint eventReqiureTIme = MP.ReadUInt(-1);
			this.SetNowWaveEndTime(MP.ReadLong(-1), true);
			int num2 = 3;
			for (int i = 0; i < num2; i++)
			{
				this.FIFAData[i].Initial();
				this.FIFAData[i].ActiveType = EActivityType.EAT_FIFA;
				this.FIFAData[i].FIFAActiveType = (EActivityKingdomEventType)i;
				this.FIFAData[i].EventState = eventState2;
				this.FIFAData[i].EventBeginTime = eventBeginTime;
				this.FIFAData[i].EventReqiureTIme = eventReqiureTIme;
				this.CheckFIFACountTime((EActivityKingdomEventType)i);
			}
			num = 0;
			this.FIFAData[num].EventRank = MP.ReadByte(-1);
			this.FIFAData[num].EventScore = MP.ReadULong(-1);
			this.CheckFIFAActivityTime();
			this.UpDateFIFAState(eventState);
			this.UpDateFIFARunningtext();
			CString cstring = StringManager.Instance.SpawnString(30);
			cstring.Append("UI/NPC_1002");
			AssetManager.GetAssetBundleDownload(cstring, AssetPath.UI, AssetType.NPC, 1002, false);
			StringManager.Instance.DeSpawnString(cstring);
		}
		else if (this.NowFIFAEventType == EActivityType.EAT_FIFA_KVK)
		{
			this.bRecvFIFAData = true;
			int num3 = 2;
			EActivityState eventState3 = this.FIFAData[num3].EventState;
			EActivityState eventState4 = (EActivityState)MP.ReadByte(-1);
			long eventBeginTime2 = MP.ReadLong(-1);
			uint eventReqiureTIme2 = MP.ReadUInt(-1);
			long waveEnd = MP.ReadLong(-1);
			int num4 = 3;
			for (int j = 0; j < num4; j++)
			{
				this.FIFAData[j].Initial();
				this.FIFAData[j].ActiveType = EActivityType.EAT_FIFA_KVK;
				this.FIFAData[j].FIFAActiveType = (EActivityKingdomEventType)j;
				this.FIFAData[j].EventState = eventState4;
				this.FIFAData[j].EventBeginTime = eventBeginTime2;
				this.FIFAData[j].EventReqiureTIme = eventReqiureTIme2;
				this.CheckFIFACountTime((EActivityKingdomEventType)j);
			}
			num3 = 0;
			this.FIFAData[num3].EventRank = MP.ReadByte(-1);
			this.FIFAData[num3].EventScore = MP.ReadULong(-1);
			this.bPassLastWave = (MP.ReadByte(-1) == 1);
			this.SetNowWaveEndTime(waveEnd, false);
			this.CheckFIFAActivityTime();
			this.UpDateFIFAState(eventState3);
			this.UpDateFIFARunningtext();
			if (this.FIFAData[2].EventState == EActivityState.EAS_Run && this.FIFAData[2].EventScore > 0UL)
			{
				FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.CREDITS_FOR_KVK, this.FIFAData[2].EventBeginTime, this.FIFAData[0].EventScore);
			}
			CString cstring2 = StringManager.Instance.SpawnString(30);
			cstring2.Append("UI/NPC_1002");
			AssetManager.GetAssetBundleDownload(cstring2, AssetPath.UI, AssetType.NPC, 1002, false);
			StringManager.Instance.DeSpawnString(cstring2);
		}
	}

	// Token: 0x060000DD RID: 221 RVA: 0x0000ED4C File Offset: 0x0000CF4C
	public void Send_FIFA_LIST_SINGLE(byte index)
	{
		if (index < 211 || index > 213)
		{
			return;
		}
		this.SettmpFIFATypeByIndex(index);
		if (this.FIFA_tmpActType == EActivityType.EAT_MAX || this.FIFA_tmpFIFAType == EActivityKingdomEventType.EAKET_MAX)
		{
			return;
		}
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_KEVENT_LIST_SINGLE;
		messagePacket.AddSeqId();
		messagePacket.Add((byte)(this.FIFA_tmpActType + 1));
		messagePacket.Add((byte)this.FIFA_tmpFIFAType);
		messagePacket.Add(this.FIFAData[(int)(index - 211)].EventRank);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.Activity);
	}

	// Token: 0x060000DE RID: 222 RVA: 0x0000EDF8 File Offset: 0x0000CFF8
	public void Send_FIFA_DETAIL(byte index)
	{
		if (index < 211 || index > 213)
		{
			return;
		}
		this.SettmpFIFATypeByIndex(index);
		if (this.FIFA_tmpActType == EActivityType.EAT_MAX || this.FIFA_tmpFIFAType == EActivityKingdomEventType.EAKET_MAX)
		{
			return;
		}
		int num = (int)(index - 211);
		if (this.FIFAData[num].bAskDetailData)
		{
			if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_Activity2, (int)index, 0, false);
			}
		}
		else if (this.FIFAData[num].EventState == EActivityState.EAS_None)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107u), 255, true);
		}
		else
		{
			this.bAskDetailData = true;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_FOOTBALL_EVENTDETAIL;
			messagePacket.AddSeqId();
			messagePacket.Add((byte)(this.FIFA_tmpActType + 1));
			messagePacket.Add((byte)this.FIFA_tmpFIFAType);
			messagePacket.Add(this.FIFAData[num].EventRank);
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Activity);
		}
	}

	// Token: 0x060000DF RID: 223 RVA: 0x0000EF20 File Offset: 0x0000D120
	public void Send_FIFA_RANKING_PRIZE(byte index)
	{
		if (index < 211 || index > 213)
		{
			return;
		}
		int num = (int)(index - 211);
		if (this.FIFAData[num].bAskRankPrize)
		{
			if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, (int)index, false);
			}
		}
		else
		{
			this.SettmpFIFATypeByIndex(index);
			if (this.FIFA_tmpActType == EActivityType.EAT_MAX || this.FIFA_tmpFIFAType == EActivityKingdomEventType.EAKET_MAX)
			{
				return;
			}
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_KEVENT_RANKING_PRIZE;
			messagePacket.AddSeqId();
			messagePacket.Add((byte)(this.FIFA_tmpActType + 1));
			messagePacket.Add((byte)this.FIFA_tmpFIFAType);
			messagePacket.Add(this.FIFAData[num].EventRank);
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Activity);
		}
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x0000F008 File Offset: 0x0000D208
	public void Recv_FIFA_DETAIL(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Activity);
		byte b = MP.ReadByte(-1);
		if (b != 0)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107u), 255, true);
			return;
		}
		EActivityType eactivityType = (EActivityType)(MP.ReadByte(-1) - 1);
		EActivityKingdomEventType eactivityKingdomEventType = (EActivityKingdomEventType)MP.ReadByte(-1);
		EActivityState eactivityState = (EActivityState)MP.ReadByte(-1);
		int kvkDataIndexByType = this.GetKvkDataIndexByType(eactivityType, eactivityKingdomEventType);
		if (kvkDataIndexByType == -1)
		{
			return;
		}
		if (eactivityType == EActivityType.EAT_FIFA)
		{
			int num = kvkDataIndexByType - 211;
			if (num >= this.FIFAData.Length)
			{
				return;
			}
			for (int i = 0; i < 6; i++)
			{
				this.FIFAData[num].GetScoreFactor[i].Factor = (EGetScoreFactor)MP.ReadByte(-1);
				this.FIFAData[num].GetScoreFactor[i].BonusRate = MP.ReadByte(-1);
			}
			if (eactivityKingdomEventType == EActivityKingdomEventType.EAKET_KingdomEvent)
			{
				if (eactivityState == EActivityState.EAS_ReplayRanking)
				{
					this.FIFA_AlliancePlace = MP.ReadByte(-1);
					this.FIFA_AllianceEmblem = MP.ReadUShort(-1);
					MP.ReadStringPlus(3, this.FIFA_AllianceTag, -1);
					MP.ReadStringPlus(20, this.FIFA_AllianceName, -1);
					this.FIFA_PlayerHead = MP.ReadUShort(-1);
					MP.ReadStringPlus(13, this.FIFA_PlayerName, -1);
					MP.ReadStringPlus(3, this.FIFA_PlayerAllianceTag, -1);
					this.FIFA_bGetChampion = (MP.ReadByte(-1) == 1);
				}
				else
				{
					this.WaveNum = MP.ReadByte(-1);
					this.WaveRequireMin = MP.ReadUShort(-1);
					this.WaveIntervalMin = MP.ReadUShort(-1);
				}
			}
			else
			{
				for (int j = 0; j < 3; j++)
				{
					this.FIFAData[num].EventPrizeWorthData[j].Crystal = MP.ReadUInt(-1);
					this.FIFAData[num].EventPrizeWorthData[j].CrystalPrice = MP.ReadUInt(-1);
					this.FIFAData[num].EventPrizeWorthData[j].Priceless = MP.ReadUShort(-1);
				}
				int num2 = 0;
				for (int k = 0; k < 3; k++)
				{
					this.FIFAData[num].DataLen[k] = MP.ReadByte(-1);
					num2 += (int)this.FIFAData[num].DataLen[k];
				}
				for (int l = 0; l < num2; l++)
				{
					this.FIFAData[num].DegreePrize[l].Rank = MP.ReadByte(-1);
					this.FIFAData[num].DegreePrize[l].ItemID = MP.ReadUShort(-1);
					this.FIFAData[num].DegreePrize[l].Num = MP.ReadByte(-1);
				}
			}
			this.FIFAData[num].bAskDetailData = true;
		}
		else if (eactivityType == EActivityType.EAT_FIFA_KVK)
		{
			int num3 = kvkDataIndexByType - 211;
			if (num3 >= this.FIFAData.Length)
			{
				return;
			}
			for (int m = 0; m < 6; m++)
			{
				this.FIFAData[num3].GetScoreFactor[m].Factor = (EGetScoreFactor)MP.ReadByte(-1);
				this.FIFAData[num3].GetScoreFactor[m].BonusRate = MP.ReadByte(-1);
			}
			if (eactivityKingdomEventType == EActivityKingdomEventType.EAKET_KingdomEvent)
			{
				if (eactivityState == EActivityState.EAS_ReplayRanking)
				{
					this.KingdomKvKRank = MP.ReadDouble(-1);
					this.FIFA_bGetChampion = (MP.ReadByte(-1) == 1);
				}
				else
				{
					this.WaveNum = MP.ReadByte(-1);
					this.WaveRequireMin = MP.ReadUShort(-1);
					this.WaveIntervalMin = MP.ReadUShort(-1);
				}
			}
			else
			{
				for (int n = 0; n < 3; n++)
				{
					this.FIFAData[num3].EventPrizeWorthData[n].Crystal = MP.ReadUInt(-1);
					this.FIFAData[num3].EventPrizeWorthData[n].CrystalPrice = MP.ReadUInt(-1);
					this.FIFAData[num3].EventPrizeWorthData[n].Priceless = MP.ReadUShort(-1);
				}
				int num4 = 0;
				for (int num5 = 0; num5 < 3; num5++)
				{
					this.FIFAData[num3].DataLen[num5] = MP.ReadByte(-1);
					num4 += (int)this.FIFAData[num3].DataLen[num5];
				}
				for (int num6 = 0; num6 < num4; num6++)
				{
					this.FIFAData[num3].DegreePrize[num6].Rank = MP.ReadByte(-1);
					this.FIFAData[num3].DegreePrize[num6].ItemID = MP.ReadUShort(-1);
					this.FIFAData[num3].DegreePrize[num6].Num = MP.ReadByte(-1);
				}
			}
			this.FIFAData[num3].bAskDetailData = true;
		}
		if (this.bAskDetailData && !this.bReOpenPrize && this.door != null)
		{
			if (this.bReOpen)
			{
				if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity2))
				{
					this.door.CloseMenu(false);
				}
				this.bReOpen = false;
			}
			this.door.OpenMenu(EGUIWindow.UI_Activity2, kvkDataIndexByType, 0, false);
		}
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x0000F588 File Offset: 0x0000D788
	public void Recv_FIFA_CHAMPION_MARQUEE(MessagePacket MP)
	{
		StringManager stringManager = StringManager.Instance;
		CString cstring = stringManager.SpawnString(1024);
		CString cstring2 = stringManager.SpawnString(30);
		CString cstring3 = stringManager.SpawnString(30);
		CString cstring4 = stringManager.SpawnString(30);
		CString cstring5 = stringManager.SpawnString(30);
		CString cstring6 = stringManager.SpawnString(30);
		bool flag = false;
		bool flag2 = false;
		MP.ReadStringPlus(3, cstring2, -1);
		MP.ReadStringPlus(20, cstring3, -1);
		MP.ReadStringPlus(3, cstring4, -1);
		MP.ReadStringPlus(13, cstring5, -1);
		if (cstring5.Length > 0)
		{
			flag2 = true;
			GameConstants.FormatRoleName(cstring6, cstring5, cstring4, null, 0, 0, null, null, null, null);
		}
		if (cstring2.Length > 0)
		{
			flag = true;
			cstring.StringToFormat(cstring2);
			cstring.StringToFormat(cstring3);
		}
		if (flag2)
		{
			cstring.StringToFormat(cstring6);
		}
		if (flag && flag2)
		{
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(14729u));
		}
		else if (!flag && flag2)
		{
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(14740u));
		}
		else
		{
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(14741u));
		}
		GUIManager.Instance.WonderCountStr.Add(cstring);
		GUIManager.Instance.SetRunningText(cstring);
		stringManager.DeSpawnString(cstring2);
		stringManager.DeSpawnString(cstring3);
		stringManager.DeSpawnString(cstring4);
		stringManager.DeSpawnString(cstring5);
		stringManager.DeSpawnString(cstring6);
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x0000F714 File Offset: 0x0000D914
	public void Recv_FIFA_GOAL(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		byte b2 = MP.ReadByte(-1);
		ulong score = MP.ReadULong(-1);
		this.SetFIFAEventPoint(0, score);
		DataManager dataManager = DataManager.Instance;
		GUIManager guimanager = GUIManager.Instance;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		if (b == 0)
		{
			cstring.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)b2, DataManager.MapDataController.OtherKingdomData.kingdomID));
			cstring.AppendFormat(dataManager.mStringTable.GetStringByID(14735u));
			guimanager.AddHUDMessage(cstring.ToString(), 255, true);
		}
		else if (b == 1)
		{
			cstring.IntToFormat((long)b2, 1, false);
			cstring.AppendFormat(dataManager.mStringTable.GetStringByID(14736u));
			guimanager.AddHUDMessage(cstring.ToString(), 255, true);
		}
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x0000F7F8 File Offset: 0x0000D9F8
	private void CopyFIFAKVKToKVK(EActivityState OldKvKState)
	{
		int num = 2;
		int num2 = 4;
		this.KvKActivityData[num2].Initial();
		this.KvKActivityData[num2].ActiveType = EActivityType.EAT_KingdomMatchEvent;
		this.KvKActivityData[num2].KVKActiveType = EKVKActivityType.EKAT_KvKEvent;
		this.KvKActivityData[num2].EventState = this.FIFAData[num].EventState;
		this.KvKActivityData[num2].EventBeginTime = this.FIFAData[num].EventBeginTime;
		this.KvKActivityData[num2].EventReqiureTIme = this.FIFAData[num].EventReqiureTIme;
		this.KvKActivityData[num2].EventScore = this.FIFAData[num].EventScore;
		if (this.KvKActivityData[num2].EventState == EActivityState.EAS_Prepare)
		{
			this.KvKActivityData[num2].EventScore = 0UL;
		}
		this.KvKActivityData[num2].EventRank = this.FIFAData[num].EventRank;
		this.UpDateKVKCountTime();
		this.UpDateKvKState(OldKvKState);
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x0000F8E4 File Offset: 0x0000DAE4
	public void CheckFirstBuyShowHint()
	{
		this.bShowFirstBuyHint = (!this.bClickFirstBuyActivity && MallManager.Instance.PaidDollar == 0L && GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 17);
		this.CheckActivityShow();
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x0000F938 File Offset: 0x0000DB38
	public void SavebClickFirstBuyActivity()
	{
		this.bClickFirstBuyActivity = true;
		PlayerPrefs.SetString("bClickFirstBuyActivity", this.bClickFirstBuyActivity.ToString());
		this.CheckFirstBuyShowHint();
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x0000F968 File Offset: 0x0000DB68
	public void Send_ACTIVITY_AS_DONATE_BOARD()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AS_DONATE_BOARD;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.UIDonation);
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x0000F9A8 File Offset: 0x0000DBA8
	public void Recv_Alliance_Donate(MessagePacket MP)
	{
		for (int i = 0; i < 4; i++)
		{
			this.mAllianceDonationData[i].itemRank = MP.ReadByte(-1);
			this.mAllianceDonationData[i].itemID = MP.ReadUShort(-1);
			this.mAllianceDonationData[i].RequireIdx = MP.ReadUShort(-1);
		}
		this.mAllianceDonation_EndTime = MP.ReadLong(-1);
		this.mAllianceDonation_RandomSeed = MP.ReadUShort(-1);
		this.mAllianceDonation_Gap = MP.ReadByte(-1);
		for (int j = 0; j < 4; j++)
		{
			this.mAllianceDonationData[j].DonateNumber = MP.ReadUShort(-1);
			byte b = MP.ReadByte(-1);
			if (b == 0)
			{
				this.mAllianceDonationData[j].Multiple = 1;
			}
			else
			{
				b = (byte)Mathf.Clamp((int)b, 1, 9);
				this.mAllianceDonationData[j].Multiple = b;
			}
		}
		byte b2 = MP.ReadByte(-1);
		this.mDonateChanceData.Clear();
		for (int k = 0; k < (int)b2; k++)
		{
			ushort item = MP.ReadUShort(-1);
			this.mDonateChanceData.Add(item);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1, 0);
		GUIManager.Instance.HideUILock(EUILock.UIDonation);
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x0000FB04 File Offset: 0x0000DD04
	public void Send_ACTIVITY_AS_DONATE_DATA(ushort startTotalDonate, byte Len, byte[] DonateData)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AS_DONATE_DATA;
		messagePacket.AddSeqId();
		messagePacket.Add(startTotalDonate);
		messagePacket.Add(Len);
		messagePacket.Add(DonateData, 0, 0);
		messagePacket.Send(false);
		this.mSendAddCount += 1;
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x0000FB5C File Offset: 0x0000DD5C
	public void Recv_Alliance_Donate_Data(MessagePacket MP)
	{
		byte b = MP.ReadByte(-1);
		this.mPointIncreased = MP.ReadUInt(-1);
		if (b == 0)
		{
			this.mAllianceDonation_Score = MP.ReadUInt(-1);
		}
		else if (b == 1)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14548u), 255, true);
			this.mAllianceDonation_Score = this.AllianceSummon_Score;
			MP.ReadUInt(-1);
		}
		if (b < 2)
		{
			for (int i = 0; i < 4; i++)
			{
				this.mAllianceDonationData[i].DonateNumber = MP.ReadUShort(-1);
				byte b2 = MP.ReadByte(-1);
				if (b2 == 0)
				{
					this.mAllianceDonationData[i].Multiple = 1;
				}
				else
				{
					b2 = (byte)Mathf.Clamp((int)b2, 1, 9);
					this.mAllianceDonationData[i].Multiple = b2;
				}
			}
			for (int j = 0; j < 4; j++)
			{
				ushort num = MP.ReadUShort(-1);
				byte b3 = MP.ReadByte(-1);
				ushort quantity = MP.ReadUShort(-1);
				if (num == this.mAllianceDonationData[j].itemID)
				{
					DataManager.Instance.SetCurItemQuantity(this.mAllianceDonationData[j].itemID, quantity, this.mAllianceDonationData[j].itemRank, 0L);
				}
			}
			GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 2, (int)b);
			GameManager.OnRefresh(NetworkNews.Refresh_Item, null);
		}
		else if (b != 2)
		{
			GUIManager.Instance.MsgStr.ClearString();
			GUIManager.Instance.MsgStr.IntToFormat((long)b, 1, false);
			GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(14555u));
			GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), 255, true);
		}
		if (b < 3)
		{
			this.mSendAddCount -= 1;
		}
		if (this.mSendAddCount < 0)
		{
			this.mSendAddCount = 0;
		}
		if (this.mSendAddCount == 0)
		{
			GUIManager.Instance.HideUILock(EUILock.UIDonation);
		}
	}

	// Token: 0x060000EA RID: 234 RVA: 0x0000FD94 File Offset: 0x0000DF94
	public void Recv_Alliancesummon_DonateBoardChange(MessagePacket MP)
	{
		this.mAllianceDonation_EndTime = MP.ReadLong(-1);
		byte b = MP.ReadByte(-1);
		if (b != 1)
		{
			if (DataManager.Instance.RoleAlliance.Id != 0u && this.AllianceSummonAllianceID != 0u && DataManager.Instance.RoleAlliance.Id == this.AllianceSummonAllianceID)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14550u), 255, true);
				GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 4, 0);
			}
		}
	}

	// Token: 0x060000EB RID: 235 RVA: 0x0000FE30 File Offset: 0x0000E030
	public void Send_ACTIVITY_REQUEST_FEDERAL_PRIZE(byte WonderID)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_FEDERAL_PRIZE;
		messagePacket.AddSeqId();
		messagePacket.Add(WonderID);
		messagePacket.Send(false);
		GUIManager.Instance.ShowUILock(EUILock.WonderReward);
	}

	// Token: 0x060000EC RID: 236 RVA: 0x0000FE78 File Offset: 0x0000E078
	public void Recv_ACTIVITY_MSG_RESP_FEDERAL_PRIZE(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			this.RewardWonderID = MP.ReadByte(-1);
			for (int i = 0; i < 9; i++)
			{
				this.RewardRankingPrize[i].Rank = MP.ReadByte(-1);
				this.RewardRankingPrize[i].ItemID = MP.ReadUShort(-1);
				this.RewardRankingPrize[i].Num = MP.ReadByte(-1);
			}
			if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_WonderReward, 1, (int)this.RewardWonderID, false);
			}
		}
		else
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(11155u), 255, true);
		}
		GUIManager.Instance.HideUILock(EUILock.WonderReward);
	}

	// Token: 0x060000ED RID: 237 RVA: 0x0000FF5C File Offset: 0x0000E15C
	public void Recv_RESP_FEDERAL_KINGKINGDOMS(MessagePacket MP)
	{
		Array.Clear(this.NobilityKingdomID, 0, this.NobilityKingdomID.Length);
		this.NobilityKingdomNum = 0;
		this.NobilityKingdomNum = MP.ReadByte(-1);
		int num = 0;
		while (num < this.NobilityKingdomID.Length && num < (int)this.NobilityKingdomNum)
		{
			this.NobilityKingdomID[num] = MP.ReadUShort(-1);
			num++;
		}
	}

	// Token: 0x060000EE RID: 238 RVA: 0x0000FFC8 File Offset: 0x0000E1C8
	public bool CheckCanonizationNoility(ushort kingdomID)
	{
		if (kingdomID > 0)
		{
			int num = 0;
			while (num < (int)this.NobilityKingdomNum && num < this.NobilityKingdomID.Length)
			{
				if (this.NobilityKingdomID[num] == kingdomID)
				{
					return true;
				}
				num++;
			}
		}
		return false;
	}

	// Token: 0x060000EF RID: 239 RVA: 0x00010014 File Offset: 0x0000E214
	public void Send_ALLIANCEWAR_REPLAY()
	{
		if (this.door && AllianceBattle.Check())
		{
			ActivityManager.Instance.AllianceWarReopenCheck();
			if (GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarBattle))
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarBattle, 4, 0);
			}
			else
			{
				this.door.OpenMenu(EGUIWindow.UI_AllianceWarBattle, 0, 0, true);
			}
			return;
		}
		GUIManager.Instance.ShowUILock(EUILock.Activity);
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_REPLAY;
		messagePacket.AddSeqId();
		messagePacket.Add(1);
		messagePacket.Add(ActivityManager.instance.AW_Round);
		messagePacket.Send(false);
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x000100D4 File Offset: 0x0000E2D4
	public string TransToLocalTime(string Content)
	{
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		int num4 = -1;
		int num5 = -1;
		int hours = 0;
		CString cstring = StringManager.Instance.SpawnString(30);
		CString cstring2 = StringManager.Instance.SpawnString(30);
		CString cstring3 = StringManager.Instance.SpawnString(30);
		string result;
		try
		{
			int num6 = 0;
			for (int i = 0; i < Content.Length; i++)
			{
				num6++;
				if (num6 > Content.Length)
				{
					Debug.Log("TotalCount > Content.Length");
					StringManager.Instance.DeSpawnString(cstring);
					StringManager.Instance.DeSpawnString(cstring2);
					StringManager.Instance.DeSpawnString(cstring3);
					return Content;
				}
				if (Content[i] == '\0')
				{
					break;
				}
				if (Content[i] == '[')
				{
					num = i;
				}
				else if (num != -1)
				{
					if (num4 == -1 && Content[i] == '(' && i + 1 < Content.Length && Content[i + 1] == 'G' && i + 2 < Content.Length && Content[i + 2] == 'M' && i + 3 < Content.Length && Content[i + 3] == 'T')
					{
						num4 = i;
						int num7 = num4;
						int num8 = 0;
						while (num7 < Content.Length && num5 == -1)
						{
							if (Content[num7] == ')')
							{
								num5 = num7;
							}
							num7++;
							num8++;
							if (num8 >= 10)
							{
								Debug.Log("Not Find GMT End");
								StringManager.Instance.DeSpawnString(cstring);
								StringManager.Instance.DeSpawnString(cstring2);
								StringManager.Instance.DeSpawnString(cstring3);
								return Content;
							}
						}
						if (i + 4 >= Content.Length)
						{
							Debug.Log(i + 4 + " > StrLen");
							StringManager.Instance.DeSpawnString(cstring);
							StringManager.Instance.DeSpawnString(cstring2);
							StringManager.Instance.DeSpawnString(cstring3);
							return Content;
						}
						int index = i + 4;
						bool flag;
						if (Content[index] == '+')
						{
							flag = true;
						}
						else
						{
							if (Content[index] != '-')
							{
								Debug.Log("GMT Error");
								StringManager.Instance.DeSpawnString(cstring);
								StringManager.Instance.DeSpawnString(cstring2);
								StringManager.Instance.DeSpawnString(cstring3);
								return Content;
							}
							flag = false;
						}
						if (i + 5 < Content.Length)
						{
							num7 = i + 5;
							num8 = 0;
							char c = Content[num7];
							while (c >= '0' && c <= '9' && num7 < num5 && num8 < 24)
							{
								num8 = num8 * 10 + (int)c - 48;
								num7++;
								c = Content[num7];
								if (c == '.')
								{
									StringManager.Instance.DeSpawnString(cstring);
									StringManager.Instance.DeSpawnString(cstring2);
									StringManager.Instance.DeSpawnString(cstring3);
									return Content;
								}
							}
						}
						hours = ((!flag) ? (-num8) : num8);
						i = num5;
					}
					else if (Content[i] == '-' || Content[i] == '～')
					{
						num2 = i;
					}
					else if (num != -1 && num2 == -1 && num4 == -1)
					{
						cstring.Append(Content[i]);
					}
					else if (num2 != -1 && num4 == -1)
					{
						cstring2.Append(Content[i]);
					}
					else if (Content[i] == ']')
					{
						num3 = i;
						break;
					}
				}
			}
			if (num == -1 || num3 == -1 || num4 == -1 || num5 == -1)
			{
				if (num == -1)
				{
					Debug.Log(" Can't Find BeginIndex");
				}
				if (num3 == -1)
				{
					Debug.Log(" Can't Find EndIndex");
				}
				if (num4 == -1)
				{
					Debug.Log(" Can't Find GMTBegin");
				}
				if (num5 == -1)
				{
					Debug.Log(" Can't Find GMTEnd");
				}
				StringManager.Instance.DeSpawnString(cstring);
				StringManager.Instance.DeSpawnString(cstring2);
				StringManager.Instance.DeSpawnString(cstring3);
				result = Content;
			}
			else
			{
				GameLanguage userLanguage = DataManager.Instance.UserLanguage;
				string format;
				if (userLanguage != GameLanguage.GL_Cht && userLanguage != GameLanguage.GL_Chs && userLanguage != GameLanguage.GL_Jpn)
				{
					format = "MM/dd/yyyy HH:mm";
				}
				else
				{
					format = "yyyy/MM/dd HH:mm";
				}
				string text = null;
				TimeSpan offset = new TimeSpan(hours, 0, 0);
				cstring.SetLength(cstring.Length);
				DateTime dateTime = DateTime.ParseExact(cstring.ToString(), format, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
				cstring.SetLength(cstring.MaxLength);
				DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, offset);
				string text2 = dateTimeOffset.UtcDateTime.ToLocalTime().ToString(format);
				if (cstring2.Length > 0)
				{
					cstring2.SetLength(cstring2.Length);
					DateTime dateTime2 = DateTime.ParseExact(cstring2.ToString(), format, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
					cstring2.SetLength(cstring2.MaxLength);
					DateTimeOffset dateTimeOffset2 = new DateTimeOffset(dateTime2, offset);
					text = dateTimeOffset2.UtcDateTime.ToLocalTime().ToString(format);
				}
				if (text != null)
				{
					cstring3.StringToFormat(text2);
					cstring3.StringToFormat(text);
					cstring3.AppendFormat("{0} - {1}");
				}
				else
				{
					cstring3.Append(text2);
				}
				StringBuilder stringBuilder = new StringBuilder();
				for (int j = 0; j < num; j++)
				{
					stringBuilder.Append(Content[j]);
				}
				for (int k = 0; k < cstring3.Length; k++)
				{
					stringBuilder.Append(cstring3[k]);
				}
				for (int l = num3 + 1; l < Content.Length; l++)
				{
					stringBuilder.Append(Content[l]);
				}
				StringManager.Instance.DeSpawnString(cstring);
				StringManager.Instance.DeSpawnString(cstring2);
				StringManager.Instance.DeSpawnString(cstring3);
				result = stringBuilder.ToString();
			}
		}
		catch
		{
			Debug.Log("ParseExact Error");
			cstring.SetLength(cstring.MaxLength);
			cstring2.SetLength(cstring2.MaxLength);
			StringManager.Instance.DeSpawnString(cstring);
			StringManager.Instance.DeSpawnString(cstring2);
			StringManager.Instance.DeSpawnString(cstring3);
			result = Content;
		}
		return result;
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x000107D8 File Offset: 0x0000E9D8
	public unsafe bool TransToLocalTime(CString Content)
	{
		int num = -1;
		int num2 = -1;
		int num3 = -1;
		int num4 = -1;
		int num5 = -1;
		int hours = 0;
		CString cstring = StringManager.Instance.SpawnString(30);
		CString cstring2 = StringManager.Instance.SpawnString(30);
		CString cstring3 = StringManager.Instance.SpawnString(30);
		bool result;
		try
		{
			int num6 = 0;
			for (int i = 0; i < Content.Length; i++)
			{
				num6++;
				if (num6 > Content.Length)
				{
					Debug.Log("TotalCount > Content.Length");
					StringManager.Instance.DeSpawnString(cstring);
					StringManager.Instance.DeSpawnString(cstring2);
					StringManager.Instance.DeSpawnString(cstring3);
					return false;
				}
				if (Content[i] == '\0')
				{
					break;
				}
				if (Content[i] == '[')
				{
					num = i;
				}
				else if (num != -1)
				{
					if (num4 == -1 && Content[i] == '(' && i + 1 < Content.Length && Content[i + 1] == 'G' && i + 2 < Content.Length && Content[i + 2] == 'M' && i + 3 < Content.Length && Content[i + 3] == 'T')
					{
						num4 = i;
						int num7 = num4;
						int num8 = 0;
						while (num7 < Content.Length && num5 == -1)
						{
							if (Content[num7] == ')')
							{
								num5 = num7;
							}
							num7++;
							num8++;
							if (num8 >= 10)
							{
								Debug.Log("Not Find GMT End");
								StringManager.Instance.DeSpawnString(cstring);
								StringManager.Instance.DeSpawnString(cstring2);
								StringManager.Instance.DeSpawnString(cstring3);
								return false;
							}
						}
						if (i + 4 >= Content.Length)
						{
							Debug.Log(i + 4 + " > StrLen");
							StringManager.Instance.DeSpawnString(cstring);
							StringManager.Instance.DeSpawnString(cstring2);
							StringManager.Instance.DeSpawnString(cstring3);
							return false;
						}
						int index = i + 4;
						bool flag;
						if (Content[index] == '+')
						{
							flag = true;
						}
						else
						{
							if (Content[index] != '-')
							{
								Debug.Log("GMT Error");
								StringManager.Instance.DeSpawnString(cstring);
								StringManager.Instance.DeSpawnString(cstring2);
								StringManager.Instance.DeSpawnString(cstring3);
								return false;
							}
							flag = false;
						}
						if (i + 5 < Content.Length)
						{
							num7 = i + 5;
							num8 = 0;
							char c = Content[num7];
							while (c >= '0' && c <= '9' && num7 < num5 && num8 < 24)
							{
								num8 = num8 * 10 + (int)c - 48;
								num7++;
								c = Content[num7];
								if (c == '.')
								{
									StringManager.Instance.DeSpawnString(cstring);
									StringManager.Instance.DeSpawnString(cstring2);
									StringManager.Instance.DeSpawnString(cstring3);
									return false;
								}
							}
						}
						hours = ((!flag) ? (-num8) : num8);
						i = num5;
					}
					else if (Content[i] == '-' || Content[i] == '～')
					{
						num2 = i;
					}
					else if (num != -1 && num2 == -1 && num4 == -1)
					{
						cstring.Append(Content[i]);
					}
					else if (num2 != -1 && num4 == -1)
					{
						cstring2.Append(Content[i]);
					}
					else if (Content[i] == ']')
					{
						num3 = i;
						break;
					}
				}
			}
			if (num == -1 || num3 == -1 || num4 == -1 || num5 == -1)
			{
				if (num == -1)
				{
					Debug.Log(" Can't Find BeginIndex");
				}
				if (num3 == -1)
				{
					Debug.Log(" Can't Find EndIndex");
				}
				if (num4 == -1)
				{
					Debug.Log(" Can't Find GMTBegin");
				}
				if (num5 == -1)
				{
					Debug.Log(" Can't Find GMTEnd");
				}
				StringManager.Instance.DeSpawnString(cstring);
				StringManager.Instance.DeSpawnString(cstring2);
				StringManager.Instance.DeSpawnString(cstring3);
				result = false;
			}
			else
			{
				GameLanguage userLanguage = DataManager.Instance.UserLanguage;
				string format;
				if (userLanguage != GameLanguage.GL_Cht && userLanguage != GameLanguage.GL_Chs && userLanguage != GameLanguage.GL_Jpn)
				{
					format = "MM/dd/yyyy HH:mm";
				}
				else
				{
					format = "yyyy/MM/dd HH:mm";
				}
				string text = null;
				TimeSpan offset = new TimeSpan(hours, 0, 0);
				cstring.SetLength(cstring.Length);
				DateTime dateTime = DateTime.ParseExact(cstring.ToString(), format, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
				cstring.SetLength(cstring.MaxLength);
				DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, offset);
				string text2 = dateTimeOffset.UtcDateTime.ToLocalTime().ToString(format);
				if (cstring2.Length > 0)
				{
					cstring2.SetLength(cstring2.Length);
					DateTime dateTime2 = DateTime.ParseExact(cstring2.ToString(), format, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
					cstring2.SetLength(cstring2.MaxLength);
					DateTimeOffset dateTimeOffset2 = new DateTimeOffset(dateTime2, offset);
					text = dateTimeOffset2.UtcDateTime.ToLocalTime().ToString(format);
				}
				if (text != null)
				{
					cstring3.StringToFormat(text2);
					cstring3.StringToFormat(text);
					cstring3.AppendFormat("{0} - {1}");
				}
				else
				{
					cstring3.Append(text2);
				}
				fixed (string text3 = Content.ToString())
				{
					fixed (char* ptr = text3 + RuntimeHelpers.OffsetToStringData / 2)
					{
						int num9 = num;
						int num10 = 0;
						while (num9 < Content.MaxLength && num10 < cstring3.Length)
						{
							ptr[num9] = cstring3[num10];
							num9++;
							num10++;
						}
						int num11 = num3 + 1;
						while (num9 < Content.MaxLength && num11 < Content.Length)
						{
							ptr[num9] = Content[num11];
							num9++;
							num11++;
						}
						if (num9 < Content.MaxLength)
						{
							Content.Length = num9;
							ptr[num9] = '\0';
						}
						else
						{
							Content.Length = Content.MaxLength - 1;
							ptr[Content.MaxLength - 1] = '\0';
						}
						text3 = null;
						StringManager.Instance.DeSpawnString(cstring);
						StringManager.Instance.DeSpawnString(cstring2);
						StringManager.Instance.DeSpawnString(cstring3);
						result = true;
					}
				}
			}
		}
		catch
		{
			Debug.Log("ParseExact Error");
			cstring.SetLength(cstring.MaxLength);
			cstring2.SetLength(cstring2.MaxLength);
			StringManager.Instance.DeSpawnString(cstring);
			StringManager.Instance.DeSpawnString(cstring2);
			StringManager.Instance.DeSpawnString(cstring3);
			result = false;
		}
		return result;
	}

	// Token: 0x04000139 RID: 313
	public const byte MAX_ACTIVITY_COMING_SOON_SPEVENT = 5;

	// Token: 0x0400013A RID: 314
	public const byte MAX_ACTIVITY_SPECIAL_EVENT = 5;

	// Token: 0x0400013B RID: 315
	private const float ActivityFadeTime = 0.3f;

	// Token: 0x0400013C RID: 316
	private const float ActivityLastTime = 3f;

	// Token: 0x0400013D RID: 317
	private const float ActivityBtnChangeTime = 5f;

	// Token: 0x0400013E RID: 318
	public const byte ACTNEWS_MAX = 30;

	// Token: 0x0400013F RID: 319
	public const byte MAX_NPC_CITY_LEVEL = 5;

	// Token: 0x04000140 RID: 320
	public const byte MAX_NOBILITY_KINGDOM = 50;

	// Token: 0x04000141 RID: 321
	public const ushort MAX_ACTIVITY_MKEVENT_MATCH = 6;

	// Token: 0x04000142 RID: 322
	private static ActivityManager instance;

	// Token: 0x04000143 RID: 323
	private Door m_door;

	// Token: 0x04000144 RID: 324
	public ActivityDataType[] ActivityData = new ActivityDataType[2];

	// Token: 0x04000145 RID: 325
	public SPActivityDataType[] CSActivityData = new SPActivityDataType[5];

	// Token: 0x04000146 RID: 326
	public SPActivityDataType[] SPActivityData = new SPActivityDataType[5];

	// Token: 0x04000147 RID: 327
	public ActivityDataType[] KvKActivityData = new ActivityDataType[5];

	// Token: 0x04000148 RID: 328
	public ActivityDataType AllyMobilizationData = new ActivityDataType();

	// Token: 0x04000149 RID: 329
	public ActivityDataType KOWData = new ActivityDataType();

	// Token: 0x0400014A RID: 330
	public ActivityDataType AllianceSummonData = new ActivityDataType();

	// Token: 0x0400014B RID: 331
	public ActivityDataType NobilityActivityData = new ActivityDataType();

	// Token: 0x0400014C RID: 332
	public ActivityDataType AllianceWarData = new ActivityDataType();

	// Token: 0x0400014D RID: 333
	public ActivityDataType[] FIFAData = new ActivityDataType[3];

	// Token: 0x0400014E RID: 334
	public bool bAskFirstData;

	// Token: 0x0400014F RID: 335
	public bool bAskSecondData;

	// Token: 0x04000150 RID: 336
	public bool bAskDetailData;

	// Token: 0x04000151 RID: 337
	public bool bCastleLevel;

	// Token: 0x04000152 RID: 338
	public bool bReOpen;

	// Token: 0x04000153 RID: 339
	public bool bReOpenPrize;

	// Token: 0x04000154 RID: 340
	public bool bRecvFIFAData;

	// Token: 0x04000155 RID: 341
	private byte m_ActivityKind = 1;

	// Token: 0x04000156 RID: 342
	private int m_ActivityIndex;

	// Token: 0x04000157 RID: 343
	private float m_ActivityTime = 5f;

	// Token: 0x04000158 RID: 344
	private int LastTimeIndex = -1;

	// Token: 0x04000159 RID: 345
	public long[] LastCSActivityTime = new long[5];

	// Token: 0x0400015A RID: 346
	public bool[] bShowNewCSActivity = new bool[5];

	// Token: 0x0400015B RID: 347
	public long[] LastSPActivityTime = new long[5];

	// Token: 0x0400015C RID: 348
	public bool[] bShowNewSPActivity = new bool[5];

	// Token: 0x0400015D RID: 349
	public long AMActivityTime = -1L;

	// Token: 0x0400015E RID: 350
	public bool bForceAMActivity;

	// Token: 0x0400015F RID: 351
	public long NWActivityTime = -1L;

	// Token: 0x04000160 RID: 352
	public byte NWWonderID;

	// Token: 0x04000161 RID: 353
	public bool bForceNWActivity;

	// Token: 0x04000162 RID: 354
	public long AWActivityTime = -1L;

	// Token: 0x04000163 RID: 355
	public byte AWActivityFlash;

	// Token: 0x04000164 RID: 356
	public byte MonsterCount;

	// Token: 0x04000165 RID: 357
	public ushort[] Monster = new ushort[5];

	// Token: 0x04000166 RID: 358
	public ushort[] MonsterType = new ushort[5];

	// Token: 0x04000167 RID: 359
	public CString[] MonstrCStr = new CString[5];

	// Token: 0x04000168 RID: 360
	public ulong bSpecialMonsterTreasureEvent;

	// Token: 0x04000169 RID: 361
	public CString[] SPActivityCStr = new CString[5];

	// Token: 0x0400016A RID: 362
	public int Act1arg1 = -1;

	// Token: 0x0400016B RID: 363
	public Vector2 Act1Pos = Vector2.zero;

	// Token: 0x0400016C RID: 364
	public int Act2arg1 = -1;

	// Token: 0x0400016D RID: 365
	public Vector2 Act2Pos = Vector2.zero;

	// Token: 0x0400016E RID: 366
	public int Act4arg2 = -1;

	// Token: 0x0400016F RID: 367
	public Vector2 Act4Pos = Vector2.zero;

	// Token: 0x04000170 RID: 368
	public long[] CSActivityTime = new long[5];

	// Token: 0x04000171 RID: 369
	public bool[] bOpenCSActivity = new bool[5];

	// Token: 0x04000172 RID: 370
	public long[] SPActivityTime = new long[5];

	// Token: 0x04000173 RID: 371
	public bool[] bOpenSPActivity = new bool[5];

	// Token: 0x04000174 RID: 372
	public long KvKActivityTime = -1L;

	// Token: 0x04000175 RID: 373
	public bool bOpenKvKActivity;

	// Token: 0x04000176 RID: 374
	public bool bShowAMHint;

	// Token: 0x04000177 RID: 375
	public bool bShowAWHint;

	// Token: 0x04000178 RID: 376
	public uint ShowNewsNo;

	// Token: 0x04000179 RID: 377
	public long ReadNewsTime;

	// Token: 0x0400017A RID: 378
	public long RcvDailyActNewsTime;

	// Token: 0x0400017B RID: 379
	public byte DailyNewsLen;

	// Token: 0x0400017C RID: 380
	public uint[] DailyNews = new uint[30];

	// Token: 0x0400017D RID: 381
	public byte NewsDataLen;

	// Token: 0x0400017E RID: 382
	public ActNewsDataType[] NewsData = new ActNewsDataType[30];

	// Token: 0x0400017F RID: 383
	public SpriteAsset m_ActivityListAsset;

	// Token: 0x04000180 RID: 384
	public SpriteAsset m_ActivityAsset;

	// Token: 0x04000181 RID: 385
	public SpriteAsset m_DoorBoxAsset;

	// Token: 0x04000182 RID: 386
	public bool bDownLoadPic1;

	// Token: 0x04000183 RID: 387
	public bool bDownLoadPic2;

	// Token: 0x04000184 RID: 388
	public bool bDownLoadPic3;

	// Token: 0x04000185 RID: 389
	public bool bUpDatePic1;

	// Token: 0x04000186 RID: 390
	public bool bUpDatePic2;

	// Token: 0x04000187 RID: 391
	public bool bUpDatePic3;

	// Token: 0x04000188 RID: 392
	private bool bShowRunningP;

	// Token: 0x04000189 RID: 393
	private bool bShowRunningE;

	// Token: 0x0400018A RID: 394
	private long NowBeginTime;

	// Token: 0x0400018B RID: 395
	private long ShowRunningTime;

	// Token: 0x0400018C RID: 396
	public MarqueeInfoDataType[] MarqueeInfo = new MarqueeInfoDataType[17];

	// Token: 0x0400018D RID: 397
	public MarqueeInfoDataType[] MarqueeInfoCS = new MarqueeInfoDataType[5];

	// Token: 0x0400018E RID: 398
	public MarqueeInfoDataType[] MarqueeInfoSP = new MarqueeInfoDataType[5];

	// Token: 0x0400018F RID: 399
	public uint AllianceSummonAllianceID;

	// Token: 0x04000190 RID: 400
	public ushort AllianceSummonEventInfoID;

	// Token: 0x04000191 RID: 401
	public uint AllianceSummon_Score;

	// Token: 0x04000192 RID: 402
	public AllianceSummonDataType AllianceSummon_SummonData;

	// Token: 0x04000193 RID: 403
	public byte[] NPCCityCombatTimes = new byte[5];

	// Token: 0x04000194 RID: 404
	public byte FederalActKingdomWonderID;

	// Token: 0x04000195 RID: 405
	public byte FederalHomeKingdomWonderID;

	// Token: 0x04000196 RID: 406
	public byte FederalFightingWonderID;

	// Token: 0x04000197 RID: 407
	public byte FederalFullEventTimeWonderID;

	// Token: 0x04000198 RID: 408
	public ushort FederalActKingdomID;

	// Token: 0x04000199 RID: 409
	public byte NW_UI_SelectIndex;

	// Token: 0x0400019A RID: 410
	public int NW_UI_SelectWonderID = -1;

	// Token: 0x0400019B RID: 411
	public NWComparer NW_Comparer = new NWComparer();

	// Token: 0x0400019C RID: 412
	public byte NobilityKingdomNum;

	// Token: 0x0400019D RID: 413
	public ushort[] NobilityKingdomID = new ushort[50];

	// Token: 0x0400019E RID: 414
	public long AW_EventBeginTime;

	// Token: 0x0400019F RID: 415
	public uint AW_SignUpAllianceID;

	// Token: 0x040001A0 RID: 416
	public byte AW_NowAllianceEnterWar;

	// Token: 0x040001A1 RID: 417
	public byte AW_GetGift;

	// Token: 0x040001A2 RID: 418
	public byte AW_Rank;

	// Token: 0x040001A3 RID: 419
	public byte AW_MemberCount;

	// Token: 0x040001A4 RID: 420
	public ushort AW_PrepareTime;

	// Token: 0x040001A5 RID: 421
	public byte AW_FightTime;

	// Token: 0x040001A6 RID: 422
	public ushort AW_WaitTime;

	// Token: 0x040001A7 RID: 423
	public byte AW_PrizeGroupID;

	// Token: 0x040001A8 RID: 424
	public EAllianceWarState AW_State;

	// Token: 0x040001A9 RID: 425
	public EAllianceWarState AW_StateOld;

	// Token: 0x040001AA RID: 426
	public bool AW_bWaitOpenNext;

	// Token: 0x040001AB RID: 427
	public bool AW_bcalculateEnd;

	// Token: 0x040001AC RID: 428
	public byte AW_Round;

	// Token: 0x040001AD RID: 429
	public long AW_RoundBeginTime;

	// Token: 0x040001AE RID: 430
	public long AW_RoundEndTime;

	// Token: 0x040001AF RID: 431
	public uint mAW_OneRoundTime;

	// Token: 0x040001B0 RID: 432
	public byte AW_NextRank;

	// Token: 0x040001B1 RID: 433
	public byte AW_MaxRank = 5;

	// Token: 0x040001B2 RID: 434
	public byte AW_MinRank = 1;

	// Token: 0x040001B3 RID: 435
	public bool bOpenFIFAActivity;

	// Token: 0x040001B4 RID: 436
	public long FIFAActivityTime = -1L;

	// Token: 0x040001B5 RID: 437
	public bool bForceFIFAActivity;

	// Token: 0x040001B6 RID: 438
	public bool bShowFIFAHint;

	// Token: 0x040001B7 RID: 439
	public bool FIFA_bGetChampion = true;

	// Token: 0x040001B8 RID: 440
	private bool FIFA_bShowRunningE;

	// Token: 0x040001B9 RID: 441
	private long FIFA_NowEndTime;

	// Token: 0x040001BA RID: 442
	public EActivityType NowFIFAEventType = EActivityType.EAT_MAX;

	// Token: 0x040001BB RID: 443
	private EActivityType FIFA_tmpActType = EActivityType.EAT_MAX;

	// Token: 0x040001BC RID: 444
	private EActivityKingdomEventType FIFA_tmpFIFAType = EActivityKingdomEventType.EAKET_MAX;

	// Token: 0x040001BD RID: 445
	public byte WaveNum;

	// Token: 0x040001BE RID: 446
	public ushort WaveRequireMin;

	// Token: 0x040001BF RID: 447
	public ushort WaveIntervalMin;

	// Token: 0x040001C0 RID: 448
	public long NowWaveEndTime;

	// Token: 0x040001C1 RID: 449
	public bool bPassLastWave;

	// Token: 0x040001C2 RID: 450
	public CString FIFA_AllianceTag = new CString(4);

	// Token: 0x040001C3 RID: 451
	public CString FIFA_AllianceName = new CString(21);

	// Token: 0x040001C4 RID: 452
	public byte FIFA_AlliancePlace;

	// Token: 0x040001C5 RID: 453
	public ushort FIFA_AllianceEmblem;

	// Token: 0x040001C6 RID: 454
	public ushort FIFA_PlayerHead;

	// Token: 0x040001C7 RID: 455
	public CString FIFA_PlayerAllianceTag = new CString(4);

	// Token: 0x040001C8 RID: 456
	public CString FIFA_PlayerName = new CString(14);

	// Token: 0x040001C9 RID: 457
	public SPActivityDataType FBActivityData = new SPActivityDataType();

	// Token: 0x040001CA RID: 458
	public bool bShowFirstBuyHint;

	// Token: 0x040001CB RID: 459
	public bool bClickFirstBuyActivity;

	// Token: 0x040001CC RID: 460
	public bool bOpenFirstBuyActivity;

	// Token: 0x040001CD RID: 461
	public long _ServerEventDeltaTime;

	// Token: 0x040001CE RID: 462
	private long m_LastServerTime;

	// Token: 0x040001CF RID: 463
	private CString TimeStr = new CString(100);

	// Token: 0x040001D0 RID: 464
	public ushort TreasureBoxID;

	// Token: 0x040001D1 RID: 465
	private EActivityType tmpActivityType = EActivityType.EAT_MAX;

	// Token: 0x040001D2 RID: 466
	private EActivityKingdomEventType tmpActivityKingdomEventType = EActivityKingdomEventType.EAKET_MAX;

	// Token: 0x040001D3 RID: 467
	public Dictionary<ushort, int> m_ActivityFactorIDMap_KVK = new Dictionary<ushort, int>();

	// Token: 0x040001D4 RID: 468
	public Dictionary<ushort, int> m_ActivityFactorIDMap_AllianceSummon = new Dictionary<ushort, int>();

	// Token: 0x040001D5 RID: 469
	public CExternalTableWithWordKey<KVKActivityScoreData> KVKScoreData;

	// Token: 0x040001D6 RID: 470
	public CExternalTableWithWordKey<SummonScoreData> AllianceSummonScoreData;

	// Token: 0x040001D7 RID: 471
	public double KingdomKvKRank;

	// Token: 0x040001D8 RID: 472
	public long SPLastGetDailyGiftTime;

	// Token: 0x040001D9 RID: 473
	public ushort KOWKingdomID;

	// Token: 0x040001DA RID: 474
	public CString WKTag = new CString(4);

	// Token: 0x040001DB RID: 475
	public CString WKName = new CString(14);

	// Token: 0x040001DC RID: 476
	public ushort WKIcon;

	// Token: 0x040001DD RID: 477
	public ushort WKKingdom;

	// Token: 0x040001DE RID: 478
	public uint AMAllianceID;

	// Token: 0x040001DF RID: 479
	public byte MatchKingdomCount;

	// Token: 0x040001E0 RID: 480
	public ushort MatchKingdomIDCount;

	// Token: 0x040001E1 RID: 481
	public ushort[] MatchKingdomID = new ushort[6];

	// Token: 0x040001E2 RID: 482
	public ushort[] MatchKingdomID_4 = new ushort[4];

	// Token: 0x040001E3 RID: 483
	public long NPCCityEndTime;

	// Token: 0x040001E4 RID: 484
	public long NPCCityCountTime;

	// Token: 0x040001E5 RID: 485
	public ActGetScoreFactorDataType[][] GetHuntFactor = new ActGetScoreFactorDataType[3][];

	// Token: 0x040001E6 RID: 486
	public ushort KVKHuntCircleMin;

	// Token: 0x040001E7 RID: 487
	public byte KVKHuntOrder;

	// Token: 0x040001E8 RID: 488
	public long KVKReTime;

	// Token: 0x040001E9 RID: 489
	public bool bNeedSendUpData = true;

	// Token: 0x040001EA RID: 490
	public float NeedSendUpDataTime = 180f;

	// Token: 0x040001EB RID: 491
	public BoardData[] mAllianceDonationData = new BoardData[4];

	// Token: 0x040001EC RID: 492
	public ushort mAllianceDonation_RandomSeed = 1;

	// Token: 0x040001ED RID: 493
	public byte mAllianceDonation_Gap;

	// Token: 0x040001EE RID: 494
	public uint mAllianceDonation_Score;

	// Token: 0x040001EF RID: 495
	public uint mPointIncreased;

	// Token: 0x040001F0 RID: 496
	public long mAllianceDonation_EndTime;

	// Token: 0x040001F1 RID: 497
	public ushort mSendAddCount;

	// Token: 0x040001F2 RID: 498
	public List<ushort> mDonateChanceData = new List<ushort>();

	// Token: 0x040001F3 RID: 499
	public byte RewardWonderID;

	// Token: 0x040001F4 RID: 500
	public ActPrizeDataType[] RewardRankingPrize = new ActPrizeDataType[9];

	// Token: 0x040001F5 RID: 501
	private AllianceWarManager _AllianceWarMgr;
}
