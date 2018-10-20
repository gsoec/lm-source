using System;
using UnityEngine;

// Token: 0x02000029 RID: 41
internal class AntiAddictive
{
	// Token: 0x06000117 RID: 279 RVA: 0x00012A34 File Offset: 0x00010C34
	private AntiAddictive()
	{
		this.bInit = false;
		this.m_AntiAddictiveSwitch = 0;
		this.m_RestrictLoginSwitch = 0;
		this.m_FinalRepeat = 0;
		this.m_CrossDaysSecond = 0L;
		this.m_AnitAddicitvDlgStage = NotificationStage.None;
		this.m_DlgStack = new byte[6];
		this.m_StackCount = 0;
		Array.Clear(this.m_DlgStack, 0, this.m_DlgStack.Length);
		if (this.m_CStr == null)
		{
			this.m_CStr = StringManager.Instance.SpawnString(200);
		}
		try
		{
			byte saveStage = 0;
			byte.TryParse(PlayerPrefs.GetString(this.AntiAddictiveSatge), out saveStage);
			DateTime d = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			string @string = PlayerPrefs.GetString(this.AntiAddictiveDate);
			DateTime d2 = Convert.ToDateTime(@string);
			if ((d - d2).Days <= 0)
			{
				this.m_SaveStage = (NotificationStage)saveStage;
			}
			else
			{
				this.m_SaveStage = NotificationStage.None;
			}
		}
		catch (Exception ex)
		{
			this.m_SaveStage = NotificationStage.None;
			Debug.Log("AntiAddictive() Exception");
		}
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x06000118 RID: 280 RVA: 0x00012BA4 File Offset: 0x00010DA4
	public static AntiAddictive Instance
	{
		get
		{
			if (AntiAddictive.instance == null)
			{
				AntiAddictive.instance = new AntiAddictive();
			}
			return AntiAddictive.instance;
		}
	}

	// Token: 0x06000119 RID: 281 RVA: 0x00012BC0 File Offset: 0x00010DC0
	public void Start(byte AddictiveSwitch, byte RestrictLoginSwitch, RealNameState realNameState, AgeState ageState)
	{
		this.m_AntiAddictiveSwitch = AddictiveSwitch;
		this.m_RestrictLoginSwitch = RestrictLoginSwitch;
		this.m_RealNameState = realNameState;
		this.m_AgeState = ageState;
		this.GetStage();
		this.SetCrossDaysSecond();
		this.SetFinalRepeat();
		this.bInit = true;
	}

	// Token: 0x0600011A RID: 282 RVA: 0x00012C04 File Offset: 0x00010E04
	public void SetCumulativeTime(long time)
	{
		this.m_CumulativeTime = time;
		this.bInit = true;
	}

	// Token: 0x0600011B RID: 283 RVA: 0x00012C14 File Offset: 0x00010E14
	public void Restart()
	{
		this.m_FinalRepeat = 0;
		this.m_CumulativeTime = 0L;
		this.SetCrossDaysSecond();
		this.SaveStage(NotificationStage.None);
		this.SetFinalRepeat();
		if (this.m_AnitAddicitvDlgStage != NotificationStage.None)
		{
			GUIManager.Instance.CloseAntiAddictiveMessageBox();
		}
	}

	// Token: 0x0600011C RID: 284 RVA: 0x00012C58 File Offset: 0x00010E58
	public void Update()
	{
		if (this.bInit && NetworkManager.Connected() && this.m_AntiAddictiveSwitch == 1 && this.m_AgeState == AgeState.Nonage)
		{
			this.m_tickTime += Time.unscaledDeltaTime;
			if (this.m_tickTime >= 1f)
			{
				if ((float)this.m_CrossDaysSecond >= 1f)
				{
					this.m_CumulativeTime += 1L;
					this.m_tickTime -= 1f;
					this.m_CrossDaysSecond -= 1L;
					if (this.m_RestrictLoginSwitch == 1 && !this.CheckRestrictLoginStage())
					{
						this.CheckNotificationStage();
					}
					if (this.m_StackCount > 0 && this.CheckDlgStack())
					{
						this.ClearDlgStack();
					}
				}
				else
				{
					this.Restart();
				}
			}
		}
	}

	// Token: 0x0600011D RID: 285 RVA: 0x00012D3C File Offset: 0x00010F3C
	public void SetAnitAddicitvDlgStage(NotificationStage stage)
	{
		this.m_AnitAddicitvDlgStage = stage;
	}

	// Token: 0x0600011E RID: 286 RVA: 0x00012D48 File Offset: 0x00010F48
	public NotificationStage GetAnitAddicitvDlgStage()
	{
		return this.m_AnitAddicitvDlgStage;
	}

	// Token: 0x0600011F RID: 287 RVA: 0x00012D50 File Offset: 0x00010F50
	private void CheckNotificationStage()
	{
		if (this.m_CumulativeTime >= 9000L && this.m_SaveStage < NotificationStage.Stage3)
		{
			this.OpeenNotificationDlg(NotificationStage.Stage3);
		}
		else if (this.m_CumulativeTime >= 7200L && this.m_SaveStage < NotificationStage.Stage2)
		{
			this.OpeenNotificationDlg(NotificationStage.Stage2);
		}
		else if (this.m_CumulativeTime >= 3600L && this.m_SaveStage < NotificationStage.Stage1)
		{
			this.OpeenNotificationDlg(NotificationStage.Stage1);
		}
	}

	// Token: 0x06000120 RID: 288 RVA: 0x00012DD8 File Offset: 0x00010FD8
	private bool CheckRestrictLoginStage()
	{
		bool result = false;
		if (this.m_CumulativeTime >= 10800L && (this.m_SaveStage < NotificationStage.Stage5 || (this.m_FinalRepeat == 1 && !RealNameHelp.Instance.IsbDlgOpening())))
		{
			this.OpeenNotificationDlg(NotificationStage.Stage5);
			result = true;
		}
		else if (this.m_CumulativeTime >= 10500L && (this.m_SaveStage < NotificationStage.Stage4 || (this.m_FinalRepeat == 1 && !RealNameHelp.Instance.IsbDlgOpening())))
		{
			this.OpeenNotificationDlg(NotificationStage.Stage4);
			result = true;
		}
		return result;
	}

	// Token: 0x06000121 RID: 289 RVA: 0x00012E74 File Offset: 0x00011074
	private bool CheckDlgStack()
	{
		if (this.GetDlgStack(NotificationStage.Stage3))
		{
			return this.OpeenNotificationDlg(NotificationStage.Stage3);
		}
		if (this.GetDlgStack(NotificationStage.Stage2))
		{
			return this.OpeenNotificationDlg(NotificationStage.Stage2);
		}
		return this.GetDlgStack(NotificationStage.Stage1) && this.OpeenNotificationDlg(NotificationStage.Stage1);
	}

	// Token: 0x06000122 RID: 290 RVA: 0x00012EC8 File Offset: 0x000110C8
	private bool OpeenNotificationDlg(NotificationStage stage)
	{
		bool result = false;
		bool bShowCloseBtn = true;
		bool flag = BattleController.IsGambleMode || BattleController.IsActive || WarManager.IsActive;
		this.m_CStr.ClearString();
		switch (stage)
		{
		case NotificationStage.Stage1:
			if (!flag)
			{
				if (this.m_RealNameState != RealNameState.Authorized)
				{
					bool bShowRealNameBtn = true;
					this.m_CStr.IntToFormat(1L, 1, false);
					this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10140u));
					GUIManager.Instance.CloseAntiAddictiveMessageBox();
					GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147u), this.m_CStr.ToString(), null, bShowRealNameBtn, bShowCloseBtn, 21, 0);
				}
				else if (this.m_RealNameState == RealNameState.Authorized)
				{
					bool bShowRealNameBtn = false;
					this.m_CStr.IntToFormat(1L, 1, false);
					this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10141u));
					GUIManager.Instance.CloseAntiAddictiveMessageBox();
					GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147u), this.m_CStr.ToString(), null, bShowRealNameBtn, bShowCloseBtn, 21, 0);
				}
				result = true;
				this.SaveStage(NotificationStage.Stage1);
			}
			else
			{
				this.SetDlgStack(NotificationStage.Stage1, true);
			}
			break;
		case NotificationStage.Stage2:
			if (!flag)
			{
				if (this.m_RealNameState != RealNameState.Authorized)
				{
					bool bShowRealNameBtn = true;
					this.m_CStr.IntToFormat(2L, 1, false);
					this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10140u));
					GUIManager.Instance.CloseAntiAddictiveMessageBox();
					GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147u), this.m_CStr.ToString(), null, bShowRealNameBtn, bShowCloseBtn, 21, 0);
				}
				else if (this.m_RealNameState == RealNameState.Authorized)
				{
					bool bShowRealNameBtn = false;
					this.m_CStr.IntToFormat(2L, 1, false);
					this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10141u));
					GUIManager.Instance.CloseAntiAddictiveMessageBox();
					GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147u), this.m_CStr.ToString(), null, bShowRealNameBtn, bShowCloseBtn, 21, 0);
				}
				result = true;
				this.SaveStage(NotificationStage.Stage2);
			}
			else
			{
				this.SetDlgStack(NotificationStage.Stage2, true);
			}
			break;
		case NotificationStage.Stage3:
			if (!flag)
			{
				if (this.m_RealNameState != RealNameState.Authorized)
				{
					bool bShowRealNameBtn = true;
					this.m_CStr.FloatToFormat(2.5f, -1, true);
					this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10140u));
					GUIManager.Instance.CloseAntiAddictiveMessageBox();
					GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147u), this.m_CStr.ToString(), null, bShowRealNameBtn, bShowCloseBtn, 21, 0);
				}
				else if (this.m_RealNameState == RealNameState.Authorized)
				{
					bool bShowRealNameBtn = false;
					this.m_CStr.FloatToFormat(2.5f, -1, true);
					this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10141u));
					GUIManager.Instance.CloseAntiAddictiveMessageBox();
					GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147u), this.m_CStr.ToString(), null, bShowRealNameBtn, bShowCloseBtn, 21, 0);
				}
				result = true;
				this.SaveStage(NotificationStage.Stage3);
			}
			else
			{
				this.SetDlgStack(NotificationStage.Stage3, true);
			}
			break;
		case NotificationStage.Stage4:
			if (!flag)
			{
				GUIManager.Instance.CloseAntiAddictiveMessageBox();
				long num = 0L;
				if (10800L >= this.m_CumulativeTime)
				{
					long num2 = 10800L - this.m_CumulativeTime;
					num = ((num2 % 60L != 0L) ? (num2 / 60L + 1L) : (num2 / 60L));
				}
				num = (long)Mathf.Clamp((float)num, 1f, 5f);
				if (this.m_RealNameState != RealNameState.Authorized)
				{
					bool bShowRealNameBtn = true;
					this.m_CStr.IntToFormat(num, 1, false);
					this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10142u));
					GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147u), this.m_CStr.ToString(), null, bShowRealNameBtn, bShowCloseBtn, 21, 0);
				}
				else if (this.m_RealNameState == RealNameState.Authorized)
				{
					bool bShowRealNameBtn = false;
					this.m_CStr.IntToFormat(num, 1, false);
					this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10143u));
					GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147u), this.m_CStr.ToString(), null, bShowRealNameBtn, bShowCloseBtn, 21, 0);
				}
				this.m_FinalRepeat = 0;
				result = true;
				this.SaveStage(NotificationStage.Stage4);
			}
			else
			{
				this.SetDlgStack(NotificationStage.Stage4, true);
			}
			break;
		case NotificationStage.Stage5:
		{
			bShowCloseBtn = false;
			GUIManager.Instance.CloseAntiAddictiveMessageBox();
			DateTime tomorrow = this.GetTomorrow();
			this.m_CStr.IntToFormat((long)tomorrow.Year, 1, false);
			this.m_CStr.IntToFormat((long)tomorrow.Month, 1, false);
			this.m_CStr.IntToFormat((long)tomorrow.Day, 1, false);
			this.m_CStr.IntToFormat((long)tomorrow.Hour, 1, false);
			if (this.m_RealNameState != RealNameState.Authorized)
			{
				bool bShowRealNameBtn = true;
				this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10144u));
				GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147u), this.m_CStr.ToString(), null, bShowRealNameBtn, bShowCloseBtn, 21, 0);
			}
			else
			{
				bool bShowRealNameBtn = false;
				this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10145u));
				GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147u), this.m_CStr.ToString(), null, bShowRealNameBtn, bShowCloseBtn, 21, 0);
			}
			this.m_FinalRepeat = 0;
			result = true;
			this.SaveStage(NotificationStage.Stage5);
			break;
		}
		}
		return result;
	}

	// Token: 0x06000123 RID: 291 RVA: 0x00013510 File Offset: 0x00011710
	private void SaveStage(NotificationStage stage)
	{
		if (stage >= NotificationStage.None && stage <= NotificationStage.Stage5)
		{
			try
			{
				long userId = DataManager.Instance.RoleAttr.UserId;
				this.m_SaveStage = stage;
				this.m_Data = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
				PlayerPrefs.SetInt(this.AntiAddictiveSatge + userId, (int)this.m_SaveStage);
				PlayerPrefs.SetString(this.AntiAddictiveDate + userId, this.m_Data.ToString());
			}
			catch (Exception ex)
			{
				Debug.Log("AntiAddictive SaveStage Exception");
			}
		}
	}

	// Token: 0x06000124 RID: 292 RVA: 0x000135E4 File Offset: 0x000117E4
	private void GetStage()
	{
		try
		{
			long userId = DataManager.Instance.RoleAttr.UserId;
			string @string = PlayerPrefs.GetString(this.AntiAddictiveDate + userId);
			if (@string != null && @string != string.Empty)
			{
				this.m_Data = Convert.ToDateTime(@string);
			}
			else
			{
				this.m_Data = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			}
			DateTime d = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			if ((this.m_Data - d).Days > 0)
			{
				this.m_SaveStage = NotificationStage.None;
			}
			else
			{
				int num = PlayerPrefs.GetInt(this.AntiAddictiveSatge + userId);
				num = Mathf.Clamp(num, 0, 5);
				this.m_SaveStage = (NotificationStage)num;
			}
		}
		catch (Exception ex)
		{
			Debug.Log("AntiAddictive GetStage Exception");
		}
	}

	// Token: 0x06000125 RID: 293 RVA: 0x00013728 File Offset: 0x00011928
	private void SetDlgStack(NotificationStage stage, bool enable)
	{
		if (stage < (NotificationStage)this.m_DlgStack.Length && stage > NotificationStage.None)
		{
			if (enable)
			{
				if (this.m_DlgStack[(int)stage] != 1)
				{
					this.m_DlgStack[(int)stage] = 1;
					this.m_StackCount += 1;
				}
			}
			else if (this.m_DlgStack[(int)stage] != 0)
			{
				this.m_DlgStack[(int)stage] = 0;
				this.m_StackCount -= 1;
			}
		}
	}

	// Token: 0x06000126 RID: 294 RVA: 0x000137A0 File Offset: 0x000119A0
	private bool GetDlgStack(NotificationStage stage)
	{
		return stage < (NotificationStage)this.m_DlgStack.Length && stage > NotificationStage.None && this.m_DlgStack[(int)stage] == 1;
	}

	// Token: 0x06000127 RID: 295 RVA: 0x000137D0 File Offset: 0x000119D0
	private void ClearDlgStack()
	{
		this.m_StackCount = 0;
		Array.Clear(this.m_DlgStack, 0, this.m_DlgStack.Length);
	}

	// Token: 0x06000128 RID: 296 RVA: 0x000137F0 File Offset: 0x000119F0
	private void SetCrossDaysSecond()
	{
		try
		{
			DateTime d = DateTime.UtcNow.AddHours(8.0);
			DateTime dateTime = new DateTime(d.Year, d.Month, d.Day);
			DateTime d2 = dateTime.AddDays(1.0);
			this.m_CrossDaysSecond = (long)(d2 - d).TotalSeconds;
		}
		catch (Exception ex)
		{
			this.m_CrossDaysSecond = 86400L;
			Debug.Log("SetCrossDaysSecond  Exception " + ex.ToString());
		}
	}

	// Token: 0x06000129 RID: 297 RVA: 0x000138A4 File Offset: 0x00011AA4
	private DateTime GetTomorrow()
	{
		DateTime result;
		try
		{
			DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			result = dateTime.AddDays(1.0);
		}
		catch (Exception)
		{
			result = default(DateTime);
		}
		return result;
	}

	// Token: 0x0600012A RID: 298 RVA: 0x00013930 File Offset: 0x00011B30
	public void SetFinalRepeat()
	{
		if (this.m_CumulativeTime >= 10500L)
		{
			this.m_FinalRepeat = 1;
		}
		else
		{
			this.m_FinalRepeat = 0;
		}
	}

	// Token: 0x0600012B RID: 299 RVA: 0x00013964 File Offset: 0x00011B64
	~AntiAddictive()
	{
		if (this.m_CStr != null)
		{
			StringManager.Instance.DeSpawnString(this.m_CStr);
			this.m_CStr = null;
		}
	}

	// Token: 0x0600012C RID: 300 RVA: 0x000139BC File Offset: 0x00011BBC
	public string GetDebugStr()
	{
		AntiAddictive.str = string.Empty;
		string text = AntiAddictive.str;
		AntiAddictive.str = string.Concat(new object[]
		{
			text,
			"[",
			3600L,
			",",
			7200L,
			",",
			9000L,
			",",
			10500L,
			",",
			10800L,
			"]\n"
		});
		AntiAddictive.str = AntiAddictive.str + "日期 = " + this.m_Data.ToShortDateString() + "\n";
		text = AntiAddictive.str;
		AntiAddictive.str = string.Concat(new object[]
		{
			text,
			"重置秒數 = ",
			this.m_CrossDaysSecond,
			"\n"
		});
		text = AntiAddictive.str;
		AntiAddictive.str = string.Concat(new object[]
		{
			text,
			"DeltaTime = ",
			Time.unscaledDeltaTime,
			"\n"
		});
		text = AntiAddictive.str;
		AntiAddictive.str = string.Concat(new object[]
		{
			text,
			"實名認證開關 = ",
			IGGGameSDK.Instance.GetRealNameSW(),
			"\n"
		});
		text = AntiAddictive.str;
		AntiAddictive.str = string.Concat(new object[]
		{
			text,
			"購買限制金額 = ",
			IGGGameSDK.Instance.GetMinorsDailySpendAmount(),
			"\n"
		});
		text = AntiAddictive.str;
		AntiAddictive.str = string.Concat(new object[]
		{
			text,
			"防沉迷提醒開關 = ",
			this.m_AntiAddictiveSwitch,
			"\n"
		});
		text = AntiAddictive.str;
		AntiAddictive.str = string.Concat(new object[]
		{
			text,
			"限制登入開關 = ",
			this.m_RestrictLoginSwitch,
			"\n"
		});
		text = AntiAddictive.str;
		AntiAddictive.str = string.Concat(new object[]
		{
			text,
			"累加上線時間 = ",
			this.m_CumulativeTime,
			"\n"
		});
		text = AntiAddictive.str;
		AntiAddictive.str = string.Concat(new object[]
		{
			text,
			"階段 = ",
			this.m_SaveStage,
			"\n"
		});
		text = AntiAddictive.str;
		AntiAddictive.str = string.Concat(new object[]
		{
			text,
			"堆疊數量 = ",
			this.m_StackCount,
			"\n"
		});
		text = AntiAddictive.str;
		AntiAddictive.str = string.Concat(new object[]
		{
			text,
			"開啟對話視窗類型 = ",
			this.m_AnitAddicitvDlgStage,
			"\n"
		});
		text = AntiAddictive.str;
		AntiAddictive.str = string.Concat(new object[]
		{
			text,
			"是否成年 = ",
			this.m_AgeState,
			"\n"
		});
		text = AntiAddictive.str;
		AntiAddictive.str = string.Concat(new object[]
		{
			text,
			"是否實名認證 = ",
			this.m_RealNameState,
			"\n"
		});
		return AntiAddictive.str;
	}

	// Token: 0x0600012D RID: 301 RVA: 0x00013D38 File Offset: 0x00011F38
	public void ClearSave()
	{
		PlayerPrefs.DeleteAll();
	}

	// Token: 0x0600012E RID: 302 RVA: 0x00013D40 File Offset: 0x00011F40
	public void SetNameType(RealNameState nameState)
	{
		this.m_RealNameState = nameState;
	}

	// Token: 0x0600012F RID: 303 RVA: 0x00013D4C File Offset: 0x00011F4C
	public void SetAgeType(AgeState ageState)
	{
		this.m_AgeState = ageState;
	}

	// Token: 0x06000130 RID: 304 RVA: 0x00013D58 File Offset: 0x00011F58
	public bool IsNonage()
	{
		return this.m_AgeState == AgeState.Nonage;
	}

	// Token: 0x0400024B RID: 587
	private const long TimeStage1 = 3600L;

	// Token: 0x0400024C RID: 588
	private const long TimeStage2 = 7200L;

	// Token: 0x0400024D RID: 589
	private const long TimeStage3 = 9000L;

	// Token: 0x0400024E RID: 590
	private const long TimeStage4 = 10500L;

	// Token: 0x0400024F RID: 591
	private const long TimeStage5 = 10800L;

	// Token: 0x04000250 RID: 592
	private const float CheckPetSecond = 1f;

	// Token: 0x04000251 RID: 593
	private string AntiAddictiveSatge = "AntiAddictiveStage";

	// Token: 0x04000252 RID: 594
	private string AntiAddictiveDate = "AntiAddictiveDate";

	// Token: 0x04000253 RID: 595
	private static AntiAddictive instance;

	// Token: 0x04000254 RID: 596
	private float m_tickTime = 1f;

	// Token: 0x04000255 RID: 597
	private bool bInit;

	// Token: 0x04000256 RID: 598
	private byte m_AntiAddictiveSwitch;

	// Token: 0x04000257 RID: 599
	private byte m_RestrictLoginSwitch;

	// Token: 0x04000258 RID: 600
	private byte m_FinalRepeat;

	// Token: 0x04000259 RID: 601
	private NotificationStage m_AnitAddicitvDlgStage;

	// Token: 0x0400025A RID: 602
	private RealNameState m_RealNameState = RealNameState.UnAuthorized;

	// Token: 0x0400025B RID: 603
	private AgeState m_AgeState = AgeState.Nonage;

	// Token: 0x0400025C RID: 604
	private long m_CumulativeTime;

	// Token: 0x0400025D RID: 605
	public NotificationStage m_SaveStage;

	// Token: 0x0400025E RID: 606
	private DateTime m_Data;

	// Token: 0x0400025F RID: 607
	private long m_CrossDaysSecond;

	// Token: 0x04000260 RID: 608
	private byte m_StackCount;

	// Token: 0x04000261 RID: 609
	private byte[] m_DlgStack;

	// Token: 0x04000262 RID: 610
	private CString m_CStr;

	// Token: 0x04000263 RID: 611
	private static string str;
}
