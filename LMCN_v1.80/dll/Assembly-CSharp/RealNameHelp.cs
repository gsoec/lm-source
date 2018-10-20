using System;
using UnityEngine;

// Token: 0x020007B0 RID: 1968
internal class RealNameHelp
{
	// Token: 0x06002855 RID: 10325 RVA: 0x004467B0 File Offset: 0x004449B0
	private RealNameHelp()
	{
		this.m_State = RealNameState.None;
		this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.None;
		this.m_NowRepeatCont = 0;
		this.bFromQuitGameDlg = false;
		this.bIsDlgOpening = false;
	}

	// Token: 0x1700010B RID: 267
	// (get) Token: 0x06002856 RID: 10326 RVA: 0x004467F4 File Offset: 0x004449F4
	public static RealNameHelp Instance
	{
		get
		{
			if (RealNameHelp.instance == null)
			{
				RealNameHelp.instance = new RealNameHelp();
			}
			return RealNameHelp.instance;
		}
	}

	// Token: 0x06002857 RID: 10327 RVA: 0x00446810 File Offset: 0x00444A10
	public void SetRealNameState(RealNameState state)
	{
		this.m_State = state;
	}

	// Token: 0x06002858 RID: 10328 RVA: 0x0044681C File Offset: 0x00444A1C
	public bool CheckOpenRealNameDlg()
	{
		if (this.m_State == RealNameState.Authorized)
		{
			return false;
		}
		this.OpenAuthenticateDlg(RealNameState.None);
		return true;
	}

	// Token: 0x06002859 RID: 10329 RVA: 0x00446834 File Offset: 0x00444A34
	public void OpenAuthenticateDlg(RealNameState state)
	{
		GUIManager.Instance.OpenRealNameMessageBox(RealNameState.None);
	}

	// Token: 0x0600285A RID: 10330 RVA: 0x00446844 File Offset: 0x00444A44
	public void OpenRealNameByWebView()
	{
		if (!IGGGameSDK.Instance.MaintanceData.RealNameCheck.Equals("0"))
		{
			IGGSDKPlugin.OpenRealNameUrlByWebView(IGGGameSDK.Instance.MaintanceData.RealNameCheck);
		}
		else
		{
			IGGSDKPlugin.OpenRealNameUrlByWebView("2");
		}
		this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.CheckRealNameState;
	}

	// Token: 0x0600285B RID: 10331 RVA: 0x004468A0 File Offset: 0x00444AA0
	public void OpenQuitGameRealNameByWebView()
	{
		if (!IGGGameSDK.Instance.MaintanceData.RealNameCheck.Equals("0"))
		{
			IGGSDKPlugin.OpenRealNameUrlByWebView(IGGGameSDK.Instance.MaintanceData.RealNameCheck);
		}
		else
		{
			IGGSDKPlugin.OpenRealNameUrlByWebView("2");
		}
		this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.CheckRealNameState;
		this.bFromQuitGameDlg = true;
		this.m_NowRepeatCont = 0;
	}

	// Token: 0x0600285C RID: 10332 RVA: 0x0044690C File Offset: 0x00444B0C
	public void OpenRealNameAsyncByWebView()
	{
		IGGSDKPlugin.OpenRealNameUrlByWebView("2");
		this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.CheckRealNameState;
		this.m_NowRepeatCont = 0;
	}

	// Token: 0x0600285D RID: 10333 RVA: 0x00446928 File Offset: 0x00444B28
	public void CheckRealNameState()
	{
		IGGSDKPlugin.CheckRealNameState();
		this.m_PreState = this.m_State;
	}

	// Token: 0x0600285E RID: 10334 RVA: 0x0044693C File Offset: 0x00444B3C
	public void CheckRealNameCallBack(RealNameState state)
	{
		this.m_State = state;
		if (this.m_UpdateCheckState == RealNameHelp.UpdateCheckState.UpdateCheckLoopWaitResult)
		{
			if (this.m_State == RealNameState.Authorized)
			{
				if (this.bIsDlgOpening)
				{
					GUIManager.Instance.CloseOKCancelBox();
					this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.None;
					this.bIsDlgOpening = false;
				}
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14578u), 255, true);
				this.m_NowRepeatCont = 0;
				if (AntiAddictive.Instance.m_SaveStage == NotificationStage.Stage5)
				{
					this.CheckFromQuitGameDlgFlag();
				}
			}
			else if (this.m_NowRepeatCont == 0)
			{
				if (this.bIsDlgOpening)
				{
					GUIManager.Instance.CloseOKCancelBox();
					this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.None;
					this.bIsDlgOpening = false;
				}
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14579u), 255, true);
				this.m_NowRepeatCont = 0;
				if (AntiAddictive.Instance.m_SaveStage == NotificationStage.Stage5)
				{
					this.CheckFromQuitGameDlgFlag();
				}
			}
			else
			{
				this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.UpdateCheckLoop;
			}
		}
		else if (this.m_UpdateCheckState == RealNameHelp.UpdateCheckState.WaitResult)
		{
			if (this.m_State == RealNameState.Sumbitted)
			{
				this.OpenSumbittedDlg();
				this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.UpdateCheckLoop;
				this.m_NowRepeatCont = 3;
				this.m_tickTime = 15f;
			}
			else if (this.m_State == RealNameState.Authorized)
			{
				this.OpenAuthorizedDlg();
				this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.Result;
			}
			else if (this.m_State == RealNameState.UnAuthorized)
			{
				this.OpenUnAuthorizedDlg();
				this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.Result;
			}
		}
	}

	// Token: 0x0600285F RID: 10335 RVA: 0x00446AC4 File Offset: 0x00444CC4
	public void OpenSumbittedDlg()
	{
		this.bIsDlgOpening = true;
		GUIManager.Instance.CloseOKCancelBox();
		GUIManager.Instance.OpenRealNameMessageBox(RealNameState.Sumbitted);
	}

	// Token: 0x06002860 RID: 10336 RVA: 0x00446AE4 File Offset: 0x00444CE4
	public void OpenUnAuthorizedDlg()
	{
		this.bIsDlgOpening = true;
		GUIManager.Instance.CloseOKCancelBox();
		GUIManager.Instance.OpenRealNameMessageBox(RealNameState.UnAuthorized);
	}

	// Token: 0x06002861 RID: 10337 RVA: 0x00446B04 File Offset: 0x00444D04
	public void OpenAuthorizedDlg()
	{
		this.bIsDlgOpening = true;
		GUIManager.Instance.CloseOKCancelBox();
		GUIManager.Instance.OpenRealNameMessageBox(RealNameState.Authorized);
	}

	// Token: 0x06002862 RID: 10338 RVA: 0x00446B24 File Offset: 0x00444D24
	public bool IsbDlgOpening()
	{
		return this.bIsDlgOpening;
	}

	// Token: 0x06002863 RID: 10339 RVA: 0x00446B2C File Offset: 0x00444D2C
	public void Update()
	{
		if (this.m_UpdateCheckState == RealNameHelp.UpdateCheckState.CheckRealNameState)
		{
			this.CheckRealNameState();
			this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.WaitResult;
		}
		else if (this.m_UpdateCheckState == RealNameHelp.UpdateCheckState.UpdateCheckLoop && this.m_NowRepeatCont > 0)
		{
			this.m_tickTime += Time.deltaTime;
			if (this.m_tickTime >= 15f)
			{
				this.m_tickTime -= 15f;
				this.CheckRealNameState();
				this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.UpdateCheckLoopWaitResult;
				this.m_NowRepeatCont--;
			}
		}
	}

	// Token: 0x06002864 RID: 10340 RVA: 0x00446BC0 File Offset: 0x00444DC0
	public bool IsUpdateCheckState()
	{
		return this.m_UpdateCheckState != RealNameHelp.UpdateCheckState.None;
	}

	// Token: 0x06002865 RID: 10341 RVA: 0x00446BD0 File Offset: 0x00444DD0
	public void ClearUpdateCheckState()
	{
		if (this.m_UpdateCheckState != RealNameHelp.UpdateCheckState.UpdateCheckLoop)
		{
			this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.None;
		}
		this.bIsDlgOpening = false;
	}

	// Token: 0x06002866 RID: 10342 RVA: 0x00446BEC File Offset: 0x00444DEC
	public void CheckFromQuitGameDlgFlag()
	{
		if (this.bFromQuitGameDlg)
		{
			AntiAddictive.Instance.SetFinalRepeat();
			this.bFromQuitGameDlg = false;
		}
	}

	// Token: 0x06002867 RID: 10343 RVA: 0x00446C0C File Offset: 0x00444E0C
	~RealNameHelp()
	{
	}

	// Token: 0x040072A1 RID: 29345
	private const int MaxRepeatCount = 3;

	// Token: 0x040072A2 RID: 29346
	private const float CheckPetSecond = 15f;

	// Token: 0x040072A3 RID: 29347
	private const float testTime = 3f;

	// Token: 0x040072A4 RID: 29348
	private static RealNameHelp instance;

	// Token: 0x040072A5 RID: 29349
	private RealNameState m_State;

	// Token: 0x040072A6 RID: 29350
	private RealNameState m_PreState;

	// Token: 0x040072A7 RID: 29351
	private RealNameHelp.UpdateCheckState m_UpdateCheckState;

	// Token: 0x040072A8 RID: 29352
	private bool bIsDlgOpening;

	// Token: 0x040072A9 RID: 29353
	private float m_tickTime = 15f;

	// Token: 0x040072AA RID: 29354
	private int m_NowRepeatCont;

	// Token: 0x040072AB RID: 29355
	private bool bFromQuitGameDlg;

	// Token: 0x040072AC RID: 29356
	private float testTick;

	// Token: 0x040072AD RID: 29357
	private int bBeginTest;

	// Token: 0x040072AE RID: 29358
	private RealNameState testState;

	// Token: 0x020007B1 RID: 1969
	private enum UpdateCheckState
	{
		// Token: 0x040072B0 RID: 29360
		None,
		// Token: 0x040072B1 RID: 29361
		CheckRealNameState,
		// Token: 0x040072B2 RID: 29362
		WaitResult,
		// Token: 0x040072B3 RID: 29363
		Result,
		// Token: 0x040072B4 RID: 29364
		UpdateCheckLoop,
		// Token: 0x040072B5 RID: 29365
		UpdateCheckLoopWaitResult,
		// Token: 0x040072B6 RID: 29366
		UpdateCheckLoopResult
	}
}
