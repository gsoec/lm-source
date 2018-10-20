using System;
using UnityEngine;

// Token: 0x020001C5 RID: 453
public class GameManager : MonoBehaviour
{
	// Token: 0x06000783 RID: 1923 RVA: 0x000A2EDC File Offset: 0x000A10DC
	public static void SwitchGameplay(GameplayKind changeGameplay)
	{
		if (GameManager.gameManager != null && GameManager.gameManager.currentGameplay != changeGameplay)
		{
			GameManager.gameManager.nextGameplay = changeGameplay;
		}
	}

	// Token: 0x06000784 RID: 1924 RVA: 0x000A2F0C File Offset: 0x000A110C
	public static bool RegisterObserver(byte in_SubjectStyle, byte in_Subject, IObserver pObserver, int ObserverMax = 1)
	{
		if (GameManager.gameManager != null)
		{
			if (GameManager.gameManager.observers[(int)in_SubjectStyle][(int)in_Subject] == null)
			{
				GameManager.gameManager.observers[(int)in_SubjectStyle][(int)in_Subject] = new IObserver[ObserverMax];
			}
			if (GameManager.gameManager.observerCounts[(int)in_SubjectStyle][(int)in_Subject] < GameManager.gameManager.observers[(int)in_SubjectStyle][(int)in_Subject].Length)
			{
				GameManager.gameManager.observers[(int)in_SubjectStyle][(int)in_Subject][GameManager.gameManager.observerCounts[(int)in_SubjectStyle][(int)in_Subject]++] = pObserver;
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000785 RID: 1925 RVA: 0x000A2FA0 File Offset: 0x000A11A0
	public static void RemoveObserver(byte in_SubjectStyle, byte in_Subject, IObserver pObserver)
	{
		if (GameManager.gameManager != null && GameManager.gameManager.observerCounts[(int)in_SubjectStyle][(int)in_Subject] > 0)
		{
			GameManager.gameManager.observers[(int)in_SubjectStyle][(int)in_Subject][--GameManager.gameManager.observerCounts[(int)in_SubjectStyle][(int)in_Subject]] = null;
		}
	}

	// Token: 0x06000786 RID: 1926 RVA: 0x000A2FFC File Offset: 0x000A11FC
	public static void notifyObservers(byte in_SubjectStyle, byte in_Subject, byte[] meg = null)
	{
		GameManager.gameManager.checkNotifyDelegates[(int)in_SubjectStyle](in_SubjectStyle, in_Subject, meg);
	}

	// Token: 0x06000787 RID: 1927 RVA: 0x000A3014 File Offset: 0x000A1214
	public static void OnRefresh(NetworkNews Flash = NetworkNews.Refresh, byte[] meg = null)
	{
		if (meg != null)
		{
			Array.Copy(meg, 0, DataManager.refreshBuffer, 1, Math.Min(DataManager.refreshBuffer.Length - 1, meg.Length));
			DataManager.refreshBuffer[0] = (byte)Flash;
			GUIManager.Instance.UpdateNetwork(DataManager.refreshBuffer);
			Array.Copy(meg, 0, DataManager.msgBuffer, 2, Math.Min(DataManager.msgBuffer.Length - 2, meg.Length));
			DataManager.msgBuffer[0] = 0;
			DataManager.msgBuffer[1] = (byte)Flash;
		}
		else
		{
			DataManager.refreshBuffer[0] = (byte)Flash;
			GUIManager.Instance.UpdateNetwork(DataManager.refreshBuffer);
			DataManager.msgBuffer[0] = 0;
			DataManager.msgBuffer[1] = (byte)Flash;
		}
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06000788 RID: 1928 RVA: 0x000A30C4 File Offset: 0x000A12C4
	public static void OnLogin()
	{
		if (GameManager.gameManager != null && GameManager.gameManager.currentGameplay != GameplayKind.Origin)
		{
			if (NewbieManager.IsNewbie && NewbieManager.Get().GetStep() == NewbieStep.FRONT_DISPLAY)
			{
				GameManager.SwitchGameplay(GameplayKind.Front);
			}
			else
			{
				DataManager.StageDataController.currentWorldMode = WorldMode.Wild;
				DataManager.StageDataController._stageMode = StageMode.Count;
				GameManager.SwitchGameplay(GameplayKind.Origin);
			}
		}
		else
		{
			GameManager.OnRefresh(NetworkNews.Login, null);
		}
	}

	// Token: 0x06000789 RID: 1929 RVA: 0x000A313C File Offset: 0x000A133C
	public static void OnGuestLogin()
	{
		GameManager.OnRefresh(NetworkNews.GuestLogin, null);
	}

	// Token: 0x0600078A RID: 1930 RVA: 0x000A3148 File Offset: 0x000A1348
	protected void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		GameManager.gameManager = this;
		this.updateDelegates = new GameManager.UpdateDelegate[7];
		this.updateDelegates[0] = new GameManager.UpdateDelegate(this.UpdateSceneReset);
		this.updateDelegates[1] = new GameManager.UpdateDelegate(this.UpdateScenePreload);
		this.updateDelegates[2] = new GameManager.UpdateDelegate(this.UpdateSceneLoad);
		this.updateDelegates[3] = new GameManager.UpdateDelegate(this.UpdateSceneUnload);
		this.updateDelegates[4] = new GameManager.UpdateDelegate(this.UpdateScenePostload);
		this.updateDelegates[5] = new GameManager.UpdateDelegate(this.UpdateSceneReady);
		this.updateDelegates[6] = new GameManager.UpdateDelegate(this.UpdateSceneRun);
		this.observers = new IObserver[2][][];
		Array.Clear(this.observers, 0, this.observers.Length);
		this.observers[0] = new IObserver[4][];
		Array.Clear(this.observers[0], 0, this.observers[0].Length);
		this.observers[1] = new IObserver[1][];
		Array.Clear(this.observers[1], 0, this.observers[1].Length);
		this.observerCounts = new int[2][];
		Array.Clear(this.observerCounts, 0, this.observerCounts.Length);
		this.observerCounts[0] = new int[4];
		Array.Clear(this.observerCounts[0], 0, this.observerCounts[0].Length);
		this.observerCounts[1] = new int[1];
		Array.Clear(this.observerCounts[1], 0, this.observerCounts[1].Length);
		this.checkNotifyDelegates = new GameManager.CheckNotifyDelegate[2];
		this.checkNotifyDelegates[0] = new GameManager.CheckNotifyDelegate(this.CheckTickNotify);
		this.checkNotifyDelegates[1] = new GameManager.CheckNotifyDelegate(this.CheckErraticNotify);
		this.nextGameplay = GameplayKind.Update;
		this.sceneState = GameManager.SceneState.Reset;
		DataManager.Instance.SetUserLanguage();
		GUIManager.Instance.Update();
		Screen.sleepTimeout = -1;
	}

	// Token: 0x0600078B RID: 1931 RVA: 0x000A3334 File Offset: 0x000A1534
	protected void OnDestroy()
	{
		this.ClearObservers();
		for (int i = 0; i < this.observers.Length; i++)
		{
			Array.Clear(this.observers[i], 0, this.observers[i].Length);
			Array.Clear(this.observerCounts[i], 0, this.observerCounts[i].Length);
		}
		this.observers = null;
		this.observerCounts = null;
		if (this.updateDelegates != null)
		{
			Array.Clear(this.updateDelegates, 0, this.updateDelegates.Length);
			this.updateDelegates = null;
		}
		GameManager.ActiveGameplay = null;
		BSInvokeUtil.free();
		AssetManager.FreeAss();
		NetworkManager.Destroy();
		AudioManager.Instance.Destroy();
		GUIManager.Instance.Free();
		if (GameManager.gameManager != null)
		{
			GameManager.gameManager = null;
		}
	}

	// Token: 0x0600078C RID: 1932 RVA: 0x000A3404 File Offset: 0x000A1604
	protected void OnApplicationPause(bool pause)
	{
		NetworkManager.Reload(pause);
		PushManage.Instance.SetPushToSDK(pause);
		GUIManager.Instance.OnUIBattlePause(pause);
		if (!pause)
		{
			IGGSDKPlugin.SetFacebookEventActivateApp();
		}
		else
		{
			IGGSDKPlugin.SetFacebookEventDeactivateApp();
		}
		if (pause)
		{
			AFAdvanceManager.Instance.SaveOnlineTime();
			AFAdvanceManager.Instance.SaveEventData();
		}
	}

	// Token: 0x0600078D RID: 1933 RVA: 0x000A345C File Offset: 0x000A165C
	protected void OnApplicationFocus(bool hasFocus)
	{
		if (hasFocus)
		{
			AFAdvanceManager.Instance.GetOnlineTime();
			AFAdvanceManager.Instance.GetEventData();
		}
	}

	// Token: 0x0600078E RID: 1934 RVA: 0x000A3478 File Offset: 0x000A1678
	protected void OnApplicationQuit()
	{
		GameManager.bQuitGame = true;
		PushManage.Instance.SetPushToSDK(true);
		AFAdvanceManager.Instance.SaveOnlineTime();
		AFAdvanceManager.Instance.SaveEventData();
		LandWalkerManager.Release();
	}

	// Token: 0x0600078F RID: 1935 RVA: 0x000A34B0 File Offset: 0x000A16B0
	protected void Update()
	{
		NetworkManager.Instance.Update();
		this.updateDelegates[(int)this.sceneState]();
	}

	// Token: 0x06000790 RID: 1936 RVA: 0x000A34D0 File Offset: 0x000A16D0
	public void CheckTickNotify(byte checkSubjectStyle, byte checkSubject, byte[] checkMeg)
	{
		for (int i = 0; i < this.observerCounts[(int)checkSubjectStyle][(int)checkSubject]; i++)
		{
			DataManager.DataBuffer[0] = checkSubjectStyle;
			DataManager.DataBuffer[1] = checkSubject;
			this.observers[(int)checkSubjectStyle][(int)checkSubject][i].Renew(DataManager.DataBuffer, checkMeg);
		}
	}

	// Token: 0x06000791 RID: 1937 RVA: 0x000A3520 File Offset: 0x000A1720
	public void CheckErraticNotify(byte checkSubjectStyle, byte checkSubject, byte[] checkMeg)
	{
		if (this.sceneState < GameManager.SceneState.Unload)
		{
			if (this.notifyInfos == null)
			{
				this.notifyInfos = new GameManager.NotifyInfo[128];
			}
			if (this.notifyInfoCount == 128)
			{
				this.notifyInfos[(int)this.notifyInfoStart].Subject = checkSubject;
				if (checkMeg == null)
				{
					Array.Clear(this.notifyInfos[(int)this.notifyInfoStart].Info, 0, 32);
				}
				else
				{
					Array.Copy(checkMeg, this.notifyInfos[(int)this.notifyInfoStart].Info, 32);
				}
				this.notifyInfoStart += 1;
				this.notifyInfoStart &= 127;
			}
			else
			{
				this.notifyInfos[(int)this.notifyInfoCount].Subject = checkSubject;
				if (this.notifyInfos[(int)this.notifyInfoCount].Info == null)
				{
					this.notifyInfos[(int)this.notifyInfoCount].Info = new byte[32];
				}
				if (checkMeg == null)
				{
					Array.Clear(this.notifyInfos[(int)this.notifyInfoCount].Info, 0, 32);
				}
				else
				{
					Array.Copy(checkMeg, this.notifyInfos[(int)this.notifyInfoCount].Info, 32);
				}
				this.notifyInfoCount += 1;
			}
		}
		else
		{
			this.CheckTickNotify(checkSubjectStyle, checkSubject, checkMeg);
		}
	}

	// Token: 0x06000792 RID: 1938 RVA: 0x000A369C File Offset: 0x000A189C
	private void ClearObservers()
	{
		for (int i = 0; i < this.observers.Length; i++)
		{
			for (int j = 0; j < this.observers[i].Length; j++)
			{
				if (this.observers[i][j] != null)
				{
					Array.Clear(this.observers[i][j], 0, this.observers[i][j].Length);
				}
				this.observerCounts[i][j] = 0;
			}
		}
	}

	// Token: 0x06000793 RID: 1939 RVA: 0x000A3714 File Offset: 0x000A1914
	private void UpdateSceneReset()
	{
		this.ClearObservers();
		GameManager.ActiveGameplay = null;
		GC.Collect();
		this.sceneState = GameManager.SceneState.Preload;
	}

	// Token: 0x06000794 RID: 1940 RVA: 0x000A3730 File Offset: 0x000A1930
	private void UpdateScenePreload()
	{
		this.sceneState = GameManager.SceneState.Load;
		AssetManager.Instance.AssetManagerState = AssetState.Preload;
	}

	// Token: 0x06000795 RID: 1941 RVA: 0x000A3744 File Offset: 0x000A1944
	private void UpdateSceneLoad()
	{
		if (AssetManager.Instance.AssetManagerState == AssetState.Preload)
		{
			AssetManager.Instance.AssetManagerState = AssetState.Load;
			GameManager.ActiveGameplay = this.CreateGameplay(this.nextGameplay);
			if (GameManager.ActiveGameplay != null)
			{
				GameManager.RegisterObserver(0, 0, GameManager.ActiveGameplay, 1);
				GameManager.RegisterObserver(0, 1, GameManager.ActiveGameplay, 1);
				GameManager.RegisterObserver(0, 2, GameManager.ActiveGameplay, 1);
				GameManager.RegisterObserver(0, 3, GameManager.ActiveGameplay, 1);
			}
			GameManager.notifyObservers(0, 1, null);
		}
		else if (AssetManager.Instance.AssetManagerState == AssetState.Ready)
		{
			this.sceneState = GameManager.SceneState.Unload;
			this.CheckNotify();
		}
	}

	// Token: 0x06000796 RID: 1942 RVA: 0x000A37EC File Offset: 0x000A19EC
	private void UpdateSceneUnload()
	{
		this.sceneState = GameManager.SceneState.Postload;
	}

	// Token: 0x06000797 RID: 1943 RVA: 0x000A37F8 File Offset: 0x000A19F8
	private void UpdateScenePostload()
	{
		this.currentGameplay = this.nextGameplay;
		this.sceneState = GameManager.SceneState.Ready;
	}

	// Token: 0x06000798 RID: 1944 RVA: 0x000A3810 File Offset: 0x000A1A10
	private void UpdateSceneReady()
	{
		GC.Collect();
		this.sceneState = GameManager.SceneState.Run;
		AssetManager.Instance.AssetManagerState = AssetState.Run;
		GameManager.notifyObservers(0, 2, null);
	}

	// Token: 0x06000799 RID: 1945 RVA: 0x000A3834 File Offset: 0x000A1A34
	private void UpdateSceneRun()
	{
		if (this.currentGameplay != this.nextGameplay)
		{
			this.sceneState = GameManager.SceneState.Reset;
			GameManager.notifyObservers(0, 0, null);
			GUIManager.Instance.UpdateNext();
			return;
		}
		GameManager.notifyObservers(0, 3, null);
		ParticleManager.Instance.Update();
		GUIManager.Instance.Update();
		AudioManager.Instance.Update();
		ActivityManager.Instance.Update();
		MallManager.Instance.Update();
		MobilizationManager.Instance.Update();
		PetManager.Instance.Update();
		ActivityGiftManager.Instance.Update();
	}

	// Token: 0x0600079A RID: 1946 RVA: 0x000A38C4 File Offset: 0x000A1AC4
	private Gameplay CreateGameplay(GameplayKind gp)
	{
		Gameplay result = null;
		switch (gp)
		{
		case GameplayKind.Origin:
			result = new Origin();
			break;
		case GameplayKind.Update:
			result = new UpdateController(this);
			break;
		case GameplayKind.Battle:
			result = new BattleController();
			break;
		case GameplayKind.War:
			result = new WarManager();
			break;
		case GameplayKind.CHAOS:
			result = new CHAOS();
			break;
		case GameplayKind.Front:
			result = new Front();
			break;
		case GameplayKind.Cosmos:
			result = new Cosmos();
			break;
		}
		return result;
	}

	// Token: 0x0600079B RID: 1947 RVA: 0x000A394C File Offset: 0x000A1B4C
	private void CheckNotify()
	{
		if (this.notifyInfoCount != 0)
		{
			byte b = this.notifyInfoStart;
			int i = 0;
			while (i < (int)this.notifyInfoCount)
			{
				b &= 127;
				this.CheckTickNotify(1, this.notifyInfos[(int)b].Subject, this.notifyInfos[(int)b].Info);
				i++;
				b += 1;
			}
			this.notifyInfoStart = (this.notifyInfoCount = 0);
		}
	}

	// Token: 0x04001BAF RID: 7087
	private static GameManager gameManager;

	// Token: 0x04001BB0 RID: 7088
	public static bool bQuitGame;

	// Token: 0x04001BB1 RID: 7089
	public static Gameplay ActiveGameplay;

	// Token: 0x04001BB2 RID: 7090
	private GameplayKind currentGameplay;

	// Token: 0x04001BB3 RID: 7091
	private GameplayKind nextGameplay;

	// Token: 0x04001BB4 RID: 7092
	private int[][] observerCounts;

	// Token: 0x04001BB5 RID: 7093
	private IObserver[][][] observers;

	// Token: 0x04001BB6 RID: 7094
	private GameManager.SceneState sceneState;

	// Token: 0x04001BB7 RID: 7095
	private GameManager.UpdateDelegate[] updateDelegates;

	// Token: 0x04001BB8 RID: 7096
	private GameManager.NotifyInfo[] notifyInfos;

	// Token: 0x04001BB9 RID: 7097
	private byte notifyInfoStart;

	// Token: 0x04001BBA RID: 7098
	private byte notifyInfoCount;

	// Token: 0x04001BBB RID: 7099
	private GameManager.CheckNotifyDelegate[] checkNotifyDelegates;

	// Token: 0x020001C6 RID: 454
	private enum SceneState : byte
	{
		// Token: 0x04001BBD RID: 7101
		Reset,
		// Token: 0x04001BBE RID: 7102
		Preload,
		// Token: 0x04001BBF RID: 7103
		Load,
		// Token: 0x04001BC0 RID: 7104
		Unload,
		// Token: 0x04001BC1 RID: 7105
		Postload,
		// Token: 0x04001BC2 RID: 7106
		Ready,
		// Token: 0x04001BC3 RID: 7107
		Run,
		// Token: 0x04001BC4 RID: 7108
		Count
	}

	// Token: 0x020001C7 RID: 455
	private struct NotifyInfo
	{
		// Token: 0x04001BC5 RID: 7109
		public byte Subject;

		// Token: 0x04001BC6 RID: 7110
		public byte[] Info;
	}

	// Token: 0x0200088F RID: 2191
	// (Invoke) Token: 0x06002D84 RID: 11652
	private delegate void UpdateDelegate();

	// Token: 0x02000890 RID: 2192
	// (Invoke) Token: 0x06002D88 RID: 11656
	private delegate void CheckNotifyDelegate(byte checkSubjectStyle, byte checkSubject, byte[] checkMeg);
}
