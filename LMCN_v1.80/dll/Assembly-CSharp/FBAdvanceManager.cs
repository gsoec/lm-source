using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000195 RID: 405
internal class FBAdvanceManager
{
	// Token: 0x1700003F RID: 63
	// (get) Token: 0x060005CC RID: 1484 RVA: 0x0007FD08 File Offset: 0x0007DF08
	public static FBAdvanceManager Instance
	{
		get
		{
			if (FBAdvanceManager.instance == null)
			{
				FBAdvanceManager.instance = new FBAdvanceManager();
			}
			return FBAdvanceManager.instance;
		}
	}

	// Token: 0x060005CD RID: 1485 RVA: 0x0007FD24 File Offset: 0x0007DF24
	public void TriggerFbEvent(EFBEvent evnet, long beginTime = 0L, ulong point = 0UL)
	{
		switch (evnet)
		{
		case EFBEvent.SUPPLY_CHEST:
			IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID);
			break;
		case EFBEvent.CASTLE_LEVEL:
		{
			int num = 0;
			int.TryParse(PlayerPrefs.GetString("FBCustomEvent_CastleLv"), out num);
			int level = (int)GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level;
			if (level > num)
			{
				PlayerPrefs.SetInt("FBCustomEvent_CastleLv", level);
				KeyValuePair<string, string> parameters = new KeyValuePair<string, string>("CastleLv", level.ToString());
				IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID, parameters);
			}
			break;
		}
		case EFBEvent.FIRST_CONQUER_TURF_BATTLE:
		{
			int num2 = (int)DataManager.StageDataController.StageRecord[2];
			int num3 = 0;
			int.TryParse(PlayerPrefs.GetString("FBCustomEvent_FirstConquerTurfBattle"), out num3);
			if (num2 > num3)
			{
				PlayerPrefs.SetInt("FBCustomEvent_FirstConquerTurfBattle", num2);
				KeyValuePair<string, string> parameters2 = new KeyValuePair<string, string>("BattleId", num2.ToString());
				IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID, parameters2);
			}
			break;
		}
		case EFBEvent.FIRST_UNLOCK_NORMAL_CHAPTER:
		{
			int num4 = (int)DataManager.StageDataController.StageRecord[0];
			int num5 = 0;
			int.TryParse(PlayerPrefs.GetString("FBCustomEvent_FirstUnlockNormalChapter"), out num5);
			if (num4 > num5)
			{
				PlayerPrefs.SetInt("FBCustomEvent_FirstUnlockNormalChapter", num4);
				KeyValuePair<string, string> parameters3 = new KeyValuePair<string, string>("BattleId", num4.ToString());
				IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID, parameters3);
			}
			break;
		}
		case EFBEvent.CREDITS_FOR_KVK:
			if (beginTime > this.kvKBeginTime)
			{
				long num6 = 0L;
				long.TryParse(PlayerPrefs.GetString("FBCustomEvent_KvKBeginTime"), out num6);
				if (beginTime > num6)
				{
					this.kvKBeginTime = beginTime;
					PlayerPrefs.SetString("FBCustomEvent_KvKBeginTime", this.kvKBeginTime.ToString());
					KeyValuePair<string, string> parameters4 = new KeyValuePair<string, string>("FirstPoint", point.ToString());
					IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID, parameters4);
				}
			}
			break;
		case EFBEvent.CREDITS_FOR_GUILD_FEST:
			if (beginTime > this.mobilizationBeginTime)
			{
				long num7 = 0L;
				long.TryParse(PlayerPrefs.GetString("FBCustomEvent_MobilizationBeginTime"), out num7);
				if (beginTime > num7)
				{
					this.mobilizationBeginTime = beginTime;
					PlayerPrefs.SetString("FBCustomEvent_MobilizationBeginTime", this.mobilizationBeginTime.ToString());
					KeyValuePair<string, string> parameters5 = new KeyValuePair<string, string>("FirstPoint", point.ToString());
					IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID, parameters5);
				}
			}
			break;
		case EFBEvent.COLLECT_EXTRA_SUPPLIES:
			IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID);
			break;
		}
	}

	// Token: 0x060005CE RID: 1486 RVA: 0x00080004 File Offset: 0x0007E204
	public void TriggerFbUniqueEvent(EFBEvent evnet)
	{
		if (evnet >= EFBEvent.FIRST_PACT_OPENED && evnet < EFBEvent.MAX && this.CheckRequirement(evnet))
		{
			IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID);
			this.SaveEventData(evnet);
		}
	}

	// Token: 0x060005CF RID: 1487 RVA: 0x00080054 File Offset: 0x0007E254
	private void SaveEventData(EFBEvent evnet)
	{
		int num = (int)(evnet / (EFBEvent)64);
		if (num >= 0 && num < this.m_SaveData.Length)
		{
			this.m_SaveData[num] |= 1L << (int)evnet;
			PlayerPrefs.SetString("FBAdvanceEventData_" + num, this.m_SaveData[num].ToString());
		}
		else
		{
			Debug.Log("FBAdvanceEventData_" + num + " : Index Error");
		}
	}

	// Token: 0x060005D0 RID: 1488 RVA: 0x000800DC File Offset: 0x0007E2DC
	private bool IsRecord(EFBEvent evnet)
	{
		int num = (int)(evnet / (EFBEvent)64);
		if (num >= 0 && num < this.m_SaveData.Length)
		{
			try
			{
				this.m_SaveData[num] = 0L;
				bool flag = long.TryParse(PlayerPrefs.GetString("FBAdvanceEventData_" + num), out this.m_SaveData[num]);
				return (this.m_SaveData[num] & 1L << (int)evnet) != 0L;
			}
			catch (Exception ex)
			{
				Debug.Log(string.Concat(new object[]
				{
					"FBAdvanceEventData_",
					num,
					" Exception : ",
					ex.ToString()
				}));
				return true;
			}
		}
		Debug.Log("FBAdvanceEventData_" + num + " : Index Error");
		return true;
	}

	// Token: 0x060005D1 RID: 1489 RVA: 0x000801D0 File Offset: 0x0007E3D0
	private bool CheckRequirement(EFBEvent evnet)
	{
		bool flag = this.IsRecord(evnet);
		return !flag;
	}

	// Token: 0x060005D2 RID: 1490 RVA: 0x000801EC File Offset: 0x0007E3EC
	public string GetTimeString()
	{
		string result;
		try
		{
			result = GameConstants.GetDateTime(DataManager.Instance.ServerTime).ToUniversalTime().AddHours(-5.0).ToString();
		}
		catch (Exception)
		{
			result = string.Empty;
		}
		return result;
	}

	// Token: 0x040016C3 RID: 5827
	private const string FBvanceEventDataTag = "FBAdvanceEventData";

	// Token: 0x040016C4 RID: 5828
	private const string CastleLv = "FBCustomEvent_CastleLv";

	// Token: 0x040016C5 RID: 5829
	private const string FirstConquerTurfBattle = "FBCustomEvent_FirstConquerTurfBattle";

	// Token: 0x040016C6 RID: 5830
	private const string FirstUnlockNormalChapter = "FBCustomEvent_FirstUnlockNormalChapter";

	// Token: 0x040016C7 RID: 5831
	private const string CreditsForKVK = "FBCustomEvent_CreditsForKVK";

	// Token: 0x040016C8 RID: 5832
	private const string CreditsForGuildFest = "FBCustomEvent_CreditsForGuildFest";

	// Token: 0x040016C9 RID: 5833
	private const string KvKBeginTimeTag = "FBCustomEvent_KvKBeginTime";

	// Token: 0x040016CA RID: 5834
	private const string MobilizationBeginTimeTag = "FBCustomEvent_MobilizationBeginTime";

	// Token: 0x040016CB RID: 5835
	private const string TimeKey = "Time";

	// Token: 0x040016CC RID: 5836
	private const string IGGIDKey = "IGGID";

	// Token: 0x040016CD RID: 5837
	private const string CastleLvKey = "CastleLv";

	// Token: 0x040016CE RID: 5838
	private const string BattleIdKey = "BattleId";

	// Token: 0x040016CF RID: 5839
	private const string FirstPointKey = "FirstPoint";

	// Token: 0x040016D0 RID: 5840
	private const int MAX_LEN = 1;

	// Token: 0x040016D1 RID: 5841
	private long kvKBeginTime;

	// Token: 0x040016D2 RID: 5842
	private long mobilizationBeginTime;

	// Token: 0x040016D3 RID: 5843
	private long[] m_SaveData = new long[1];

	// Token: 0x040016D4 RID: 5844
	private static FBAdvanceManager instance;
}
