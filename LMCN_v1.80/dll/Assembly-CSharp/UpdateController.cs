using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SevenZip.Compression.LZMA;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000701 RID: 1793
public class UpdateController : Gameplay, IUIButtonClickHandler
{
	// Token: 0x06002255 RID: 8789 RVA: 0x00406A54 File Offset: 0x00404C54
	public UpdateController(GameManager Gm)
	{
		UpdateController.Updater = this;
		this.GameMan = Gm;
		DownloadController.Init(Gm);
		UpdateController.CheckController = NetworkManager.RealTime;
		AssetManager.Instance.AssetManagerState = AssetState.Ready;
		Directory.CreateDirectory(AssetManager.persistentDataPath + "/Scene");
		Directory.CreateDirectory(AssetManager.persistentDataPath + "/Store");
		Directory.CreateDirectory(AssetManager.persistentDataPath + "/Role");
		Directory.CreateDirectory(AssetManager.persistentDataPath + "/Data");
		Directory.CreateDirectory(AssetManager.persistentDataPath + "/Loading");
		Directory.CreateDirectory(AssetManager.persistentDataPath + "/Particle");
		Directory.CreateDirectory(AssetManager.persistentDataPath + "/Sound");
		Directory.CreateDirectory(AssetManager.persistentDataPath + "/Music");
		Directory.CreateDirectory(AssetManager.persistentDataPath + "/Misc");
		Directory.CreateDirectory(AssetManager.persistentDataPath + "/UI");
	}

	// Token: 0x06002256 RID: 8790 RVA: 0x00406B9C File Offset: 0x00404D9C
	~UpdateController()
	{
	}

	// Token: 0x06002257 RID: 8791 RVA: 0x00406BD4 File Offset: 0x00404DD4
	protected override void UpdateNews(byte[] meg)
	{
		if (meg[0] == 0 && meg[1] == 35)
		{
			this.RefreshFontRebuilt();
		}
		else if (meg[0] == 1)
		{
			if (meg[1] == 27)
			{
				this.OnUpdateFail(meg[2]);
			}
			else if (meg[1] == 28)
			{
				this.LoadIGGData();
			}
		}
	}

	// Token: 0x06002258 RID: 8792 RVA: 0x00406C30 File Offset: 0x00404E30
	protected override void UpdateRun(byte[] meg)
	{
		if (!this.GSpot)
		{
			return;
		}
		if (NetworkManager.Instance.CheckTime > 0f)
		{
			this.Loading(0.4f * Time.deltaTime);
		}
		if (IGGGameSDK.Instance.IGGIdIsReady)
		{
			this.OnIGGReady();
		}
		if (UpdateController.UpdatePuller != null && this.Runner != null)
		{
			this.Runner.sizeDelta = new Vector2(376f * UpdateController.WebClient.Progressing, this.Runner.sizeDelta.y);
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(99u));
			cstring.FloatToFormat((1f - UpdateController.WebClient.Progressing) * 100f, 1, true);
			cstring.FloatToFormat(UpdateController.WebClient.SpeedTicket * 10f, 2, true);
			cstring.AppendFormat("\n{0} {1}%\n{2}MB/s");
			this.Booster.text = cstring.ToString();
		}
		if (UpdateController.WebClient.Processed)
		{
			if (UpdateController.WebClient.FileReady)
			{
				if ((IGGSDKPlugin.CheckWifi() || UpdateController.WebClient.Consented) && UpdateController.WebClient.FileLength > 0L && !UpdateController.WebClient.FileError)
				{
					UpdateController.WebClient.Processed = (UpdateController.WebClient.FileError = UpdateController.DownloadNewApk(UpdateController.WebClient.Url));
				}
				else if (!UpdateController.WebClient.FileError)
				{
					if (UpdateController.WebClient.FileLength == 0L || UpdateController.WebClient.FileError)
					{
						NetworkManager.LetmeIn(string.Format("{0}:{1}", DataManager.Instance.mStringTable.GetStringByID(8474u), (UpdateController.WebClient.FileLength != 0L) ? 1 : 0), 0);
						UpdateController.WebClient.FileReady = false;
					}
					else
					{
						GUIManager.Instance.CloseOKCancelBox();
						NetworkManager.LastStage = LoginPhase.LP_Disconnect;
						CString cstring2 = StringManager.Instance.StaticString1024();
						cstring2.FloatToFormat((float)UpdateController.WebClient.FileLength / 1000000f, 2, true);
						cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(16108u));
						GUIManager.Instance.OpenOKCancelBox(2, DataManager.Instance.mStringTable.GetStringByID(3967u), cstring2.ToString(), 0, 0, null, null);
					}
					UpdateController.WebClient.FileError = true;
				}
				return;
			}
			if (UpdateController.UpdatePuller != null)
			{
				UpdateController.DownloadReset(false);
				return;
			}
			try
			{
				FileInfo fileInfo = new FileInfo(AssetManager.persistentDataPath + System.IO.Path.AltDirectorySeparatorChar + "Download.apk");
				UpdateController.WebClient.FileError = (!fileInfo.Exists || fileInfo.Length == 0L || fileInfo.Length != UpdateController.WebClient.FileLength || UpdateController.WebClient.FileError);
				if (!UpdateController.WebClient.FileError)
				{
					using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
					{
						AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
						AndroidJavaObject androidJavaObject = new AndroidJavaObject("android.content.Intent", new object[]
						{
							"android.intent.action.VIEW"
						});
						AndroidJavaObject androidJavaObject2 = new AndroidJavaClass("android.net.Uri").CallStatic<AndroidJavaObject>("fromFile", new object[]
						{
							new AndroidJavaObject("java.io.File", new object[]
							{
								fileInfo.FullName
							})
						});
						androidJavaObject.Call<AndroidJavaObject>("setDataAndType", new object[]
						{
							androidJavaObject2,
							"application/vnd.android.package-archive"
						}).Call<AndroidJavaObject>("addFlags", new object[]
						{
							268500992
						});
						@static.Call("startActivity", new object[]
						{
							androidJavaObject
						});
					}
				}
			}
			catch
			{
				UpdateController.WebClient.FileError = true;
				UpdateController.DownloadReset(false);
			}
			NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID((!UpdateController.WebClient.FileError) ? 99u : 8474u), 0);
			UpdateController.WebClient.Processed = false;
		}
	}

	// Token: 0x06002259 RID: 8793 RVA: 0x00407030 File Offset: 0x00405230
	protected override void UpdateNext(byte[] meg)
	{
		UpdateController.Updater = null;
		this.ClearUpdateDelegates();
		DownloadController.Reset(true);
		DownloadController.Refresh();
		UnityEngine.Object.Destroy(this.Loader);
		UnityEngine.Object.Destroy(this.Player);
		UnityEngine.Object.Destroy(this.Chatter);
		UnityEngine.Object.Destroy(Camera.main.GetComponent<GUILayer>());
	}

	// Token: 0x0600225A RID: 8794 RVA: 0x00407084 File Offset: 0x00405284
	protected override void UpdateLoad(byte[] meg)
	{
		GameManager.RegisterObserver(1, 0, this, 1);
		AssetManager.UnloadAsses();
		GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Update);
		GUIManager.Instance.m_UICanvas.renderMode = RenderMode.ScreenSpaceCamera;
		GUIManager.Instance.SetCameraorthOgraphic(true);
		AssetManager.Instance.AssetManagerState = AssetState.Ready;
		NetworkManager.Instance.SetStage(LoginPhase.LP_Pending, 0L, false);
		this.GameMan.gameObject.AddComponent<ImmersiveModeEnabler>();
	}

	// Token: 0x0600225B RID: 8795 RVA: 0x004070F4 File Offset: 0x004052F4
	protected override void UpdateReady(byte[] meg)
	{
		this.Router = this.GameMan.StartCoroutine(this.LoadStreamAssToPersistent());
	}

	// Token: 0x0600225C RID: 8796 RVA: 0x00407110 File Offset: 0x00405310
	public static void ReturnToBase()
	{
		if (UpdateController.Updater == null)
		{
			GameManager.SwitchGameplay(GameplayKind.Update);
		}
	}

	// Token: 0x0600225D RID: 8797 RVA: 0x00407124 File Offset: 0x00405324
	private IEnumerator LoadStreamAssToPersistent()
	{
		yield return this.GameMan.StartCoroutine(this.LoadStreamTableData());
		yield return this.GameMan.StartCoroutine(this.LoadStreamAssData());
		yield break;
	}

	// Token: 0x0600225E RID: 8798 RVA: 0x00407140 File Offset: 0x00405340
	public void OnGameLogin()
	{
		this.Loader.SetActive(true);
		this.Server.SetActive(false);
		this.Starter.GetComponent<InputField>().text = this.Prefix;
	}

	// Token: 0x0600225F RID: 8799 RVA: 0x0040717C File Offset: 0x0040537C
	public void OnUpdateFail(byte Fatal)
	{
		this.bundle = null;
		if (Fatal > 0)
		{
			this.Failure = false;
			this.GameMan.StopAllCoroutines();
			if (DataManager.Instance.mStringTable == null)
			{
				this.Path.Length = 0;
				DataManager.Instance.mStringTable = new StringTable();
				UpdateController.UserLanguageId = (byte)((DataManager.Instance.UserLanguage < GameLanguage.GL_Eng || DataManager.Instance.UserLanguage >= GameLanguage.GL_MAX) ? GameLanguage.GL_Eng : DataManager.Instance.UserLanguage);
				if (!File.Exists(this.Path.AppendFormat("{0}/{1}/{2}.unity3d", AssetManager.persistentDataPath, "Loading", AssetManager.StringAsset[(int)(UpdateController.UserLanguageId - 1)]).ToString()) || !DataManager.Instance.mStringTable.LoadStringTable("Loading/" + AssetManager.StringAsset[(int)(UpdateController.UserLanguageId - 1)], true))
				{
					DataManager.Instance.mStringTable.LoadStringTable("Loading/String", false);
				}
			}
			this.Path.Length = 0;
			this.Teller.text = ((this.Patching <= GameConstants.Version[2]) ? this.Path.AppendFormat("v{0}.{1}", GameConstants.Version[0], GameConstants.Version[1]).ToString() : this.Path.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7049u), GameConstants.Version[0], GameConstants.Version[1], this.Patching).ToString());
			GUIManager.Instance.InitialMessageBox();
			GUIManager.Instance.LoadFont();
		}
	}

	// Token: 0x06002260 RID: 8800 RVA: 0x00407338 File Offset: 0x00405538
	public static void BuildStreamAssData(bool Rebuild = false)
	{
		new UpdateController(null).Initialing(Rebuild);
	}

	// Token: 0x06002261 RID: 8801 RVA: 0x00407348 File Offset: 0x00405548
	public void RefreshFontRebuilt()
	{
		if (this.Chatter)
		{
			this.Chatter.transform.GetChild(1).GetComponent<Text>().enabled = false;
			this.Chatter.transform.GetChild(1).GetComponent<Text>().enabled = true;
		}
		if (this.Booster)
		{
			this.Booster.enabled = false;
			this.Booster.enabled = true;
		}
		if (this.Teller)
		{
			this.Teller.enabled = false;
			this.Teller.enabled = true;
		}
		if (this.Hint)
		{
			this.Hint.enabled = false;
			this.Hint.enabled = true;
		}
	}

	// Token: 0x06002262 RID: 8802 RVA: 0x00407418 File Offset: 0x00405618
	public void OnIGGReady()
	{
		if (!this.Chatter.activeSelf)
		{
			this.Chatter.SetActive(true);
		}
	}

	// Token: 0x06002263 RID: 8803 RVA: 0x00407438 File Offset: 0x00405638
	public static void OnIGGLogin(bool Force = false)
	{
		if (UpdateController.Updater != null && UpdateController.Updater.GSpot)
		{
			UpdateController.Updater.GSpot.SetActive(false);
		}
		NetworkManager.Instance.SetStage(LoginPhase.LP_Auto, 0L, false);
		if (Force)
		{
			IGGSDKPlugin.GeustLogin();
		}
		else if (NetworkManager.OnReady())
		{
			if (IGGGameSDK.Instance.IGGIdIsReady && !UpdateController.WebClient.FileError)
			{
				IGGGameSDK.Instance.CanLogIn();
			}
			else
			{
				IGGSDKPlugin.AutoLogin();
			}
		}
	}

	// Token: 0x06002264 RID: 8804 RVA: 0x004074CC File Offset: 0x004056CC
	public static bool OnIGGLogin(IGGLoginCode Code)
	{
		if (UpdateController.UpdateCritical || UpdateController.StageController < 3)
		{
			return !UpdateController.UpdateCritical;
		}
		if (Code == IGGLoginCode.IggReady)
		{
			IGGGameSDK.Instance.CanLogIn();
		}
		else if (Code < IGGLoginCode.Paranormal || Code == IGGLoginCode.None)
		{
			NetworkManager.Instance.SetStage(LoginPhase.LP_KissAss, (Code <= IGGLoginCode.None) ? 104L : ((long)Code), true);
		}
		else
		{
			NetworkManager.Instance.SetStage(LoginPhase.LP_GG, (long)Code, true);
		}
		return false;
	}

	// Token: 0x06002265 RID: 8805 RVA: 0x00407554 File Offset: 0x00405754
	public static bool OnIGGLoginBBS(bool Consent = false)
	{
		NetworkManager.Instance.SetStage(LoginPhase.LP_BBS, 0L, Consent);
		return !UpdateController.UpdateCritical;
	}

	// Token: 0x06002266 RID: 8806 RVA: 0x00407570 File Offset: 0x00405770
	public static void OnIGGLoginBind()
	{
		NetworkManager.Instance.SetStage(LoginPhase.LP_Fail, 0L, false);
	}

	// Token: 0x06002267 RID: 8807 RVA: 0x00407584 File Offset: 0x00405784
	public static void OnIGGLoginFail()
	{
		NetworkManager.Instance.SetStage(LoginPhase.LP_GG, 119L, false);
	}

	// Token: 0x06002268 RID: 8808 RVA: 0x00407598 File Offset: 0x00405798
	public static void OnFail(bool Fatal = true)
	{
		if (UpdateController.UpdateCritical)
		{
			return;
		}
		UpdateController.UpdateCritical = Fatal;
		NetworkManager.Instance.SetStage(LoginPhase.LP_EpicFail, 1L, true);
		NetworkManager.Instance.SetStage(LoginPhase.LP_KissAss, 826L, Fatal);
	}

	// Token: 0x06002269 RID: 8809 RVA: 0x004075D8 File Offset: 0x004057D8
	public static void OnExit(uint Unknown, bool Fatal = true)
	{
		if (UpdateController.UpdateCritical)
		{
			return;
		}
		UpdateController.UpdateCritical = Fatal;
		NetworkManager.Instance.SetStage(LoginPhase.LP_KissAss, (long)((ulong)Unknown), Fatal);
	}

	// Token: 0x0600226A RID: 8810 RVA: 0x00407608 File Offset: 0x00405808
	public static void OnExit(string Uknowhy, bool Fatal = true)
	{
		if (UpdateController.UpdateCritical)
		{
			return;
		}
		UpdateController.MessageReturner = Uknowhy;
		NetworkManager.Instance.SetStage(LoginPhase.LP_KissAss, 0L, Fatal);
	}

	// Token: 0x0600226B RID: 8811 RVA: 0x00407638 File Offset: 0x00405838
	public static void OnOpenTermsOfService()
	{
		IGGGameSDK.Instance.bOpenTermsService = true;
	}

	// Token: 0x0600226C RID: 8812 RVA: 0x00407648 File Offset: 0x00405848
	public static void OnToSAgreement()
	{
		if (UpdateController.UpdateCritical)
		{
			return;
		}
		NetworkManager.Instance.SetStage(LoginPhase.LP_Logging, 1L, false);
	}

	// Token: 0x0600226D RID: 8813 RVA: 0x00407664 File Offset: 0x00405864
	private void OnReady()
	{
		if (this.Reload)
		{
			DataManager.LoadTableData();
		}
		DataManager.MissionDataManager.AchievementMgr.Signin();
		AssetManager.Instance.LoadShader("Shader");
		GUIManager.Instance.InitialAssets();
		Camera.main.backgroundColor = Color.black;
		Resources.UnloadUnusedAssets();
		Shader.WarmupAllShaders();
		AudioManager.Instance.LoadSFXObj();
		GC.Collect();
		AssetManager.Instance.AssetManagerState = AssetState.Run;
		this.Runner.sizeDelta = new Vector2(378f, UpdateController.Updater.Runner.sizeDelta.y);
		this.Booster.text = DataManager.Instance.mStringTable.GetStringByID(38u);
	}

	// Token: 0x0600226E RID: 8814 RVA: 0x00407728 File Offset: 0x00405928
	private bool Inception()
	{
		if (PlayerPrefs.HasKey("Inception"))
		{
			return true;
		}
		this.Server.SetActive(true);
		this.Server.GetComponent<UIButton>().m_Handler = this;
		this.Teller = this.Server.transform.GetChild(0).gameObject.GetComponent<Text>();
		this.Teller.text = DataManager.Instance.mStringTable.GetStringByID(7096u);
		this.Teller.font = GUIManager.Instance.GetTTFFont();
		return false;
	}

	// Token: 0x0600226F RID: 8815 RVA: 0x004077BC File Offset: 0x004059BC
	public void Loading(float value)
	{
		if (this.Loader && value > 0f)
		{
			this.Loader.transform.localScale += Vector3.left * value;
			this.Runner.sizeDelta = new Vector2(376f * (1f - this.Loader.transform.localScale.magnitude / 2f), this.Runner.sizeDelta.y);
		}
		else if (value != 0f)
		{
			this.Loader = new GameObject("Loader");
			this.Loader.AddComponent<GUITexture>();
			this.Loader.guiTexture.color = Color.green;
			this.Loader.guiTexture.texture = new Texture2D(1, 1);
			this.Loader.transform.localScale = new Vector3(0f, 0f, 0.1f);
			float num = Mathf.Max((float)Screen.height / 480f, 1f);
			this.Loader.AddComponent<GUIText>();
			this.Loader.guiText.fontSize = (int)(17f * num);
			Camera.main.gameObject.AddComponent<GUILayer>();
			this.Runner.sizeDelta = new Vector2(376f, this.Runner.sizeDelta.y);
			Text booster = this.Booster;
			Font font = this.Loader.guiText.font;
			this.Hint.font = font;
			font = font;
			this.Teller.font = font;
			booster.font = font;
			this.Loader.guiTexture.border = new RectOffset(Screen.width, 0, 0, 0);
			this.GSpot.transform.parent.parent.GetChild(2).GetComponent<UIButton>().m_Handler = this;
			this.GSpot.transform.parent.parent.GetChild(2).GetChild(1).GetComponent<Text>().font = this.Booster.font;
		}
		else if (this.Loader)
		{
			this.Loader.transform.localScale = new Vector3(0f, 0f, 0.1f);
			this.Runner.sizeDelta = new Vector2(376f, this.Runner.sizeDelta.y);
		}
	}

	// Token: 0x06002270 RID: 8816 RVA: 0x00407A60 File Offset: 0x00405C60
	private void PromptLogin()
	{
		this.Reload = false;
		UpdateController.StageController += 1;
		AssetManager.SetAssetMap(0);
		GUIManager.Instance.LoadFont();
		GUIManager.Instance.CloseLoadingTalk();
		UnityEngine.Object.Destroy(this.Loader);
		this.Loader = new GameObject("Logger");
		this.Server = this.GSpot.transform.parent.parent.GetChild(1).GetChild(0).gameObject;
		this.Loader.transform.SetParent(GUIManager.Instance.m_WindowsTransform.transform, false);
		this.Loader.transform.localScale = this.Player.transform.localScale;
		UpdateController.OnIGGLogin(false);
	}

	// Token: 0x06002271 RID: 8817 RVA: 0x00407B28 File Offset: 0x00405D28
	public void OnButtonClick(UIButton Sender)
	{
		if (Sender.m_BtnID2 > 0)
		{
			DataManager.AchievementMgr.OpenAchievementUI();
		}
		else if (Sender.m_BtnID1 > 0)
		{
			IGGSDKPlugin.SubmitQuestion();
		}
		else if (this.Starter)
		{
			this.OnGameLogin();
		}
		else
		{
			UpdateController.OnIGGLogin(false);
		}
	}

	// Token: 0x06002272 RID: 8818 RVA: 0x00407B88 File Offset: 0x00405D88
	public static void Consent(bool YesIdo)
	{
		UpdateController.WebClient.FileError = false;
		if (YesIdo)
		{
			UpdateController.WebClient.Consented = true;
		}
		else
		{
			UpdateController.WebClient.FileLength = 0L;
			UpdateController.WebClient.FileReady = (UpdateController.WebClient.Processed = false);
			NetworkManager.LastStage = LoginPhase.LP_IGG;
			NetworkManager.Resume(true);
			UpdateController.WebClient.FileError = true;
		}
	}

	// Token: 0x06002273 RID: 8819 RVA: 0x00407BC8 File Offset: 0x00405DC8
	public static bool DownloadNewApk(Uri url)
	{
		UpdateController.WebClient.FileReady = false;
		if (url == null || url.ToString().Trim().Length == 0 || UpdateController.UpdatePuller != null)
		{
			return true;
		}
		try
		{
			UpdateController.WebClient webClient = UpdateController.UpdatePuller = new UpdateController.WebClient();
			webClient.Clear();
			webClient.DownloadFileCompleted += UpdateController.AsyncCompletedEventHandler;
			webClient.DownloadProgressChanged += UpdateController.DownloadProgressChangedEventHandler;
			webClient.DownloadFileAsync(url, AssetManager.persistentDataPath + System.IO.Path.AltDirectorySeparatorChar + "Download.apk", null);
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_Announcement);
		}
		catch
		{
			return true;
		}
		return false;
	}

	// Token: 0x06002274 RID: 8820 RVA: 0x00407C9C File Offset: 0x00405E9C
	public static bool CertificateMyass(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
	{
		try
		{
			if (sslPolicyErrors != SslPolicyErrors.None)
			{
				for (int i = 0; i < chain.ChainStatus.Length; i++)
				{
					if (chain.ChainStatus[i].Status != X509ChainStatusFlags.RevocationStatusUnknown)
					{
						chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
						chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
						chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
						chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
						if (!chain.Build((X509Certificate2)certificate))
						{
							return false;
						}
					}
				}
			}
		}
		catch
		{
		}
		return true;
	}

	// Token: 0x06002275 RID: 8821 RVA: 0x00407D60 File Offset: 0x00405F60
	public static bool CheckNewApk(string url)
	{
		if (url == null || url.Trim().Length == 0 || UpdateController.UpdatePuller != null)
		{
			return false;
		}
		if (ServicePointManager.ServerCertificateValidationCallback == null)
		{
			ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(UpdateController.CertificateMyass);
		}
		Text booster = UpdateController.Updater.Booster;
		string empty = string.Empty;
		UpdateController.Updater.Hint.text = empty;
		booster.text = empty;
		UpdateController.Updater.GSpot.SetActive(true);
		try
		{
			UpdateController.UpdatePuller = new UpdateController.WebClient();
			UpdateController.WebClient.FileLength = 0L;
			UpdateController.UpdatePuller.Clear();
			UpdateController.UpdatePuller.OpenReadAsync(new Uri(url), null);
		}
		catch
		{
			UpdateController.WebClient.Processed = (UpdateController.WebClient.FileError = true);
		}
		return true;
	}

	// Token: 0x06002276 RID: 8822 RVA: 0x00407E40 File Offset: 0x00406040
	public static void test()
	{
	}

	// Token: 0x06002277 RID: 8823 RVA: 0x00407E44 File Offset: 0x00406044
	public static void AsyncCompletedEventHandler(object sender, AsyncCompletedEventArgs e)
	{
		if (e.Cancelled || e.Error != null)
		{
			((UpdateController.WebClient)sender).Dispose();
			UpdateController.WebClient.FileError = true;
		}
		UpdateController.WebClient.Processed = true;
	}

	// Token: 0x06002278 RID: 8824 RVA: 0x00407E74 File Offset: 0x00406074
	public static void DownloadProgressChangedEventHandler(object sender, DownloadProgressChangedEventArgs e)
	{
		if ((UpdateController.WebClient.Progressing > 0.9f && DateTime.Now.Ticks - UpdateController.WebClient.FileGauger > 10000000L) || DateTime.Now.Ticks - UpdateController.WebClient.FileGauger > 40000000L)
		{
			UpdateController.WebClient.SpeedTicket = ((UpdateController.WebClient.FileReceive <= 0L) ? 0f : ((float)(e.BytesReceived - UpdateController.WebClient.FileReceive) / (float)(DateTime.Now.Ticks - UpdateController.WebClient.FileGauger)));
			UpdateController.WebClient.FileGauger = DateTime.Now.Ticks;
			UpdateController.WebClient.FileReceive = e.BytesReceived;
		}
		UpdateController.WebClient.Progressing = 1f - ((e.TotalBytesToReceive <= 0L) ? 0f : ((float)e.BytesReceived / (float)e.TotalBytesToReceive));
	}

	// Token: 0x06002279 RID: 8825 RVA: 0x00407F58 File Offset: 0x00406158
	public static void DownloadReset(bool Clear = false)
	{
		try
		{
			if (UpdateController.UpdatePuller != null)
			{
				UpdateController.UpdatePuller.CancelAsync();
				UpdateController.UpdatePuller.Close();
			}
		}
		catch
		{
		}
		finally
		{
			if (Clear)
			{
				UpdateController.WebClient.Processed = false;
				UpdateController.WebClient.FileError = false;
				UpdateController.WebClient.FileLength = 0L;
				UpdateController.WebClient.Url = null;
			}
			UpdateController.UpdatePuller = null;
		}
	}

	// Token: 0x0600227A RID: 8826 RVA: 0x00407FE8 File Offset: 0x004061E8
	public void SetPremature(string GString)
	{
		if (this.Loader)
		{
			this.Loader.guiText.text = GString;
		}
		if (this.Booster)
		{
			this.Booster.text = GString;
		}
		DataManager.Instance.mStringTable = new StringTable();
		DataManager.Instance.mStringTable.LoadStringTable("Loading/String", false);
		GameConstants.Version[2] = this.Patching;
		DownloadController.Reset(true);
		UpdateController.UpdateCritical = false;
		UpdateController.StageController = 123;
		Caching.CleanCache();
		this.Reload = true;
		this.OnReady();
	}

	// Token: 0x0600227B RID: 8827 RVA: 0x0040808C File Offset: 0x0040628C
	private void Initialing(bool Force = false)
	{
		UpdateController.ReadStreamAssData();
		IEnumerator enumerator = this.ParseStreamingAsset(Force);
		while (enumerator.MoveNext())
		{
		}
	}

	// Token: 0x0600227C RID: 8828 RVA: 0x004080B8 File Offset: 0x004062B8
	private IEnumerator LoadStreamTableData()
	{
		NetworkManager.Instance.SetStage(LoginPhase.LP_Checking, 0L, false);
		this.Path.Length = 0;
		yield return null;
		UpdateController.InitialInstall = true;
		UpdateController.UserLanguageId = (byte)((DataManager.Instance.UserLanguage < GameLanguage.GL_Eng || DataManager.Instance.UserLanguage >= GameLanguage.GL_MAX) ? GameLanguage.GL_Eng : DataManager.Instance.UserLanguage);
		if (!File.Exists(AssetManager.persistentDataPath + "/Data/Patch") || !ushort.TryParse(File.ReadAllText(AssetManager.persistentDataPath + "/Data/Patch"), out this.Patching) || this.Patching < GameConstants.Version[2])
		{
			this.Patching = GameConstants.Version[2];
		}
		this.bundle = new WWW(this.Path.AppendFormat("{0}{1}/Data/Assetver", this.Prefix, Application.streamingAssetsPath).ToString());
		yield return this.bundle;
		if (this.bundle.isDone)
		{
			this.AV = Encoding.ASCII.GetString(this.bundle.bytes);
		}
		this.Extraction = 120000u;
		this.Path.Length = 0;
		this.bundle.Dispose();
		this.Path.Length = 0;
		this.bundle = new WWW(this.Path.AppendFormat("{0}{1}/Data/Asset.plist", this.Prefix, Application.streamingAssetsPath).ToString());
		yield return this.bundle;
		if (this.bundle.isDone)
		{
			this.AssList = Encoding.ASCII.GetString(this.bundle.bytes).Split(new string[]
			{
				"/",
				"\\",
				"\r",
				"\n"
			}, StringSplitOptions.RemoveEmptyEntries);
			this.AssSheet = new Dictionary<string, long>(this.AssList.Length >> 2);
			AssetManager.SetAssetMap(this.AssList.Length >> 2);
			AssetManager.Instance.LoadShader("Shader");
			long stamper;
			long.TryParse(this.AssList[2], out stamper);
			this.Initiator = AssetManager.GetAssetBundle("Loading/Loader", stamper);
			this.GSpot = (GameObject)UnityEngine.Object.Instantiate(this.Initiator.mainAsset);
			this.GSpot.transform.SetParent(GUIManager.Instance.m_WindowsTransform.transform, false);
			this.Runner = (RectTransform)this.GSpot.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(0);
			this.Teller = this.GSpot.transform.GetChild(0).GetChild(1).GetComponent<Text>();
			this.Booster = this.GSpot.transform.GetChild(0).GetChild(2).GetChild(3).GetComponent<Text>();
			this.Booster.rectTransform.sizeDelta = new Vector2(this.Booster.rectTransform.sizeDelta.x, 109f);
			this.Chatter = this.GSpot.transform.GetChild(2).gameObject;
			this.Player = this.GSpot.transform.GetChild(3).gameObject;
			this.Hint = this.GSpot.transform.GetChild(0).GetChild(2).GetChild(4).GetComponent<Text>();
			this.GSpot = this.GSpot.transform.GetChild(0).GetChild(2).gameObject;
			this.Loading(1f);
			bool bPlay = true;
			byte bFirst;
			byte.TryParse(PlayerPrefs.GetString("SysSetting_First"), out bFirst);
			if (bFirst == 1)
			{
				bool.TryParse(PlayerPrefs.GetString("Other_bMusic"), out bPlay);
			}
			if (UpdateController.UpdateCritical)
			{
				this.Chatter.transform.SetParent(GUIManager.Instance.m_TopLayer, false);
				this.Chatter.AddComponent<ArabicItemTextureRot>();
				this.GSpot.GetComponent<Image>().enabled = false;
				this.SetPremature("Resource error");
				UpdateController.OnIGGLogin(false);
				yield break;
			}
			AudioManager.Instance.LoadAndPlayBGM(BGMType.Login, 1, bPlay);
			this.Chatter.AddComponent<ArabicItemTextureRot>();
			this.GSpot.GetComponent<Image>().enabled = false;
			this.GSpot.transform.localPosition -= 38f * Vector3.up;
			this.Hint.transform.localPosition += 10f * Vector3.up;
			this.Initiator.Unload(false);
		}
		if (this.bundle != null)
		{
			this.bundle.Dispose();
		}
		UpdateController.StageController = 0;
		if (GUIManager.Instance.IsArabic)
		{
			Transform child = this.Chatter.transform.parent.GetChild(0).GetChild(0);
			Vector3 localScale = new Vector3(-1f, this.Player.transform.localScale.y, this.Player.transform.localScale.z);
			this.Player.transform.localScale = localScale;
			child.localScale = localScale;
		}
		yield break;
	}

	// Token: 0x0600227D RID: 8829 RVA: 0x004080D4 File Offset: 0x004062D4
	private void LoadIGGData()
	{
		this.Loading(0f);
		GUIManager.Instance.UnloadMessageBox();
		this.GameMan.StartCoroutine(this.LoadStreamAssData());
	}

	// Token: 0x0600227E RID: 8830 RVA: 0x00408108 File Offset: 0x00406308
	private IEnumerator LoadStreamAssData()
	{
		if (UpdateController.StageController == 0)
		{
			NetworkManager.Instance.CheckTime = 5f;
			DataManager.Instance.mStringTable = null;
			NetworkManager.Instance.SetStage(LoginPhase.LP_Updating, 0L, false);
			this.CDNRoot = "http://static-lo.igg.com/Global/android";
			this.bundle = new WWW("http://download-lo-snd.igg.com/android/UpdateString.plist?v=" + DateTime.UtcNow.Ticks);
			while (this.bundle != null && !this.bundle.isDone)
			{
				yield return false;
			}
			if (this.bundle != null && this.bundle.isDone && this.bundle.error == null && this.bundle.responseHeaders != null && this.bundle.responseHeaders.ContainsKey("LOCATION"))
			{
				NetworkManager.Instance.SetStage(LoginPhase.LP_Updating, 0L, false);
				this.bundle = new WWW(this.bundle.responseHeaders["LOCATION"]);
				this.Loading(0f);
				while (this.bundle != null && !this.bundle.isDone)
				{
					yield return false;
				}
			}
			this.Failure = true;
			if (this.bundle == null || !this.bundle.isDone || this.bundle.error != null)
			{
				NetworkManager.Instance.SetStage(LoginPhase.LP_Updating, 0L, false);
				this.bundle = new WWW(this.CDNRoot + "/UpdateString.plist?v=" + DateTime.UtcNow.Ticks);
				this.Loading(0f);
				while (this.bundle != null && !this.bundle.isDone)
				{
					yield return false;
				}
			}
			NetworkManager.Instance.SetStage(LoginPhase.LP_Preparing, 0L, false);
			if (this.AssSheet != null && this.bundle != null && this.bundle.isDone && this.bundle.error == null)
			{
				string[] AssUpdates = Encoding.ASCII.GetString(this.bundle.bytes).Split(new string[]
				{
					"/",
					"\\",
					"\r",
					"\n"
				}, StringSplitOptions.RemoveEmptyEntries);
				if (AssUpdates.Length > 5 && AssUpdates[4].Equals("Updates"))
				{
					this.Loading(2f);
					yield return false;
					for (int i = 5; i < AssUpdates.Length - 5; i += 6)
					{
						if (AssetManager.StringAsset[(int)(UpdateController.UserLanguageId - 1)].Equals(AssUpdates[i + 1]))
						{
							this.Failure = false;
							long stamper = Convert.ToInt64(AssUpdates[i + 2]);
							this.Path.Length = 0;
							Directory.CreateDirectory(this.Path.AppendFormat("{0}/{1}/", AssetManager.persistentDataPath, AssUpdates[i]).ToString());
							using (FileStream fs = new FileStream(this.Path.Append(AssUpdates[i + 1]).ToString(), FileMode.OpenOrCreate))
							{
								using (StreamReader sr = new StreamReader(fs))
								{
									long insider;
									if (long.TryParse(sr.ReadLine(), out insider) && stamper <= insider)
									{
										break;
									}
								}
							}
							yield return this.GameMan.StartCoroutine(this.LoadStreamAssToPersistent(this.CDNRoot, AssUpdates[i], "String", false, int.Parse(AssUpdates[i + 5]), UpdateController.UserLanguageId, true));
							break;
						}
					}
				}
			}
			if (this.bundle != null)
			{
				this.bundle.Dispose();
			}
			if (this.Failure)
			{
				this.Loading(2f);
				NetworkManager.Instance.SetStage(LoginPhase.LP_EpicFail, 1L, true);
				yield return false;
			}
			UpdateController.StageController += 1;
		}
		if (this.AssList != null && UpdateController.StageController == 1)
		{
			this.Loading(0f);
			NetworkManager.Instance.CheckTime = 5f;
			AssetManager.SetAssetMap((this.AssSheet == null) ? 0 : this.AssSheet.Count);
			if (DataManager.Instance.mStringTable == null)
			{
				DataManager.Instance.mStringTable = new StringTable();
				if (!this.Reload && !DataManager.Instance.mStringTable.LoadStringTable("Loading/" + AssetManager.StringAsset[(int)(UpdateController.UserLanguageId - 1)], true))
				{
					DataManager.Instance.mStringTable.LoadStringTable("Loading/String", false);
				}
				this.Reload = true;
			}
			if (DataManager.Instance.UserLanguage != GameLanguage.GL_Jpn)
			{
				string text = DataManager.Instance.mStringTable.GetStringByID(38u);
				this.Loader.guiText.text = text;
				text = text;
				this.Booster.text = text;
				yield return text;
			}
			UpdateController.InitialInstall = !File.Exists(AssetManager.persistentDataPath + "/Data/Assetver");
			if (UpdateController.InitialInstall && this.Reload)
			{
				this.Loading(2f);
				yield return true;
			}
			GUIManager.Instance.LoadFont();
			NetworkManager.Instance.UpdateTime = (NetworkManager.Instance.CheckTime = 0f);
			this.Loading(2f);
			this.Hint.fontSize = 12;
			this.Hint.lineSpacing = 0.95f;
			this.Hint.resizeTextForBestFit = false;
			this.Hint.text = GameConstants.HealthGameCN;
			this.Hint.gameObject.AddComponent<Outline>();
			this.Hint.alignment = TextAnchor.UpperCenter;
			this.Hint.color = new Color(0.6666667f, 0.6666667f, 0.6666667f);
			this.Hint.font = GUIManager.Instance.GetTTFFont();
			this.Hint.rectTransform.sizeDelta = new Vector2(750f, 90f);
			this.Hint.rectTransform.anchoredPosition -= new Vector2(169f, 0f);
			this.Teller.alignment = TextAnchor.LowerRight;
			this.Teller.resizeTextForBestFit = false;
			this.Teller.fontSize = 13;
			if (DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn)
			{
				this.Booster.text = DataManager.Instance.mStringTable.GetStringByID(38u);
				this.Booster.font = GUIManager.Instance.GetTTFFont();
				this.Hint.rectTransform.anchoredPosition -= new Vector2(50f, 0f);
				this.Hint.rectTransform.sizeDelta = new Vector2(550f, 100f);
			}
			yield return true;
			UpdateController.StageController += 1;
		}
		if (this.AssList.Length > 7 && (this.Reload || !File.Exists(AssetManager.persistentDataPath + "/Data/Assetver") || !File.ReadAllText(AssetManager.persistentDataPath + "/Data/Assetver").Equals(this.AV)))
		{
			this.Loading(0f);
			float iteration = 8f / (float)this.AssList.Length;
			ushort j = 0;
			while ((int)j < this.AssList.Length - 3)
			{
				this.Path.Length = 0;
				this.Loading(iteration);
				long stamper;
				long.TryParse(this.AssList[(int)(j + 2)], out stamper);
				int Key = (this.AssList[(int)j] + "/" + this.AssList[(int)(j + 1)]).ToUpperInvariant().GetHashCode();
				using (FileStream fs2 = new FileStream(this.Path.AppendFormat("{0}/{1}/{2}", AssetManager.persistentDataPath, this.AssList[(int)j], this.AssList[(int)(j + 1)]).ToString(), FileMode.OpenOrCreate))
				{
					using (StreamReader sr2 = new StreamReader(fs2))
					{
						long insider;
						if (long.TryParse(sr2.ReadLine(), out insider) && stamper <= insider)
						{
							AssetManager.SetAssetBundle(Key, insider, true);
							goto IL_C71;
						}
					}
				}
				goto IL_C07;
				IL_C71:
				j += 4;
				continue;
				IL_C07:
				this.Loader.guiText.text = DataManager.Instance.mStringTable.GetStringByID((!UpdateController.InitialInstall) ? 99u : 37u);
				this.Booster.text = DataManager.Instance.mStringTable.GetStringByID(99u);
				AssetManager.SetAssetBundle(Key, stamper, false);
				goto IL_C71;
			}
			if (!File.Exists(AssetManager.persistentDataPath + "/Data/Mailver") || !File.ReadAllText(AssetManager.persistentDataPath + "/Data/Mailver").Equals(7.ToString()))
			{
				File.Delete(string.Format("{0}/Data/Mail", AssetManager.persistentDataPath));
				DataManager.Instance.InitialMail();
			}
			if (!File.Exists(AssetManager.persistentDataPath + "/Data/Assetver") || !File.ReadAllText(AssetManager.persistentDataPath + "/Data/Assetver").Equals(this.AV))
			{
				File.WriteAllText(AssetManager.persistentDataPath + "/Data/Mailver", 7.ToString());
				File.WriteAllText(AssetManager.persistentDataPath + "/Data/Assetver", this.AV);
			}
		}
		this.Loading(0f);
		UpdateController.UpdateFallback = 0;
		NetworkManager.Instance.SetStage(LoginPhase.LP_Updating, 0L, false);
		this.Booster.text = DataManager.Instance.mStringTable.GetStringByID(100u);
		yield return true;
		this.CDNRoot = "http://static-lo.igg.com/Global/android";
		this.bundle = new WWW("http://download-lo-snd.igg.com/android/Update.plist?v=" + DateTime.UtcNow.Ticks);
		while (this.bundle != null && !this.bundle.isDone)
		{
			yield return false;
		}
		if (this.bundle != null && this.bundle.isDone && this.bundle.error == null && this.bundle.responseHeaders != null && this.bundle.responseHeaders.ContainsKey("LOCATION"))
		{
			NetworkManager.Instance.SetStage(LoginPhase.LP_Updating, 0L, false);
			this.bundle = new WWW(this.bundle.responseHeaders["LOCATION"]);
			this.Loading(0f);
			while (this.bundle != null && !this.bundle.isDone)
			{
				yield return false;
			}
		}
		if (this.bundle == null || !this.bundle.isDone || this.bundle.error != null)
		{
			NetworkManager.Instance.SetStage(LoginPhase.LP_Updating, 0L, false);
			this.bundle = new WWW(this.CDNRoot + "/Update.plist?v=" + DateTime.UtcNow.Ticks);
			this.Loading(0f);
			UpdateController.UpdateFallback = 110;
			while (this.bundle != null && !this.bundle.isDone)
			{
				yield return false;
			}
		}
		NetworkManager.Instance.SetStage(LoginPhase.LP_Preparing, 0L, false);
		if (this.AssSheet != null && this.bundle != null && this.bundle.isDone && this.bundle.error == null)
		{
			string[] AssUpdates2 = Encoding.ASCII.GetString(this.bundle.bytes).Split(new string[]
			{
				"/",
				"\\",
				"\r",
				"\n"
			}, StringSplitOptions.RemoveEmptyEntries);
			if (AssUpdates2.Length > 5 && AssUpdates2[4].Equals("Updates"))
			{
				this.Loading(2f);
				yield return false;
				uint.TryParse(AssUpdates2[1], out DataManager.Instance.BattleEngine);
				Text booster = this.Booster;
				string text = DataManager.Instance.mStringTable.GetStringByID(594u);
				this.Loader.guiText.text = text;
				booster.text = text;
				this.Loading(0f);
				float iteration = 12f / (float)(AssUpdates2.Length - 5);
				ushort k = 5;
				while ((int)k < AssUpdates2.Length - 5)
				{
					this.Path.Length = 0;
					this.Loading(iteration);
					long stamper = Convert.ToInt64(AssUpdates2[(int)(k + 2)]);
					long insider;
					int Key;
					if ((insider = AssetManager.GetAssetStamp(Key = (AssUpdates2[(int)k] + "/" + AssUpdates2[(int)(k + 1)]).ToUpperInvariant().GetHashCode())) < stamper)
					{
						Directory.CreateDirectory(this.Path.AppendFormat("{0}/{1}/", AssetManager.persistentDataPath, AssUpdates2[(int)k]).ToString());
						if (insider == 0L)
						{
							using (FileStream fs3 = new FileStream(this.Path.Append(AssUpdates2[(int)(k + 1)]).ToString(), FileMode.OpenOrCreate))
							{
								using (StreamReader sr3 = new StreamReader(fs3))
								{
									if (long.TryParse(sr3.ReadLine(), out insider) && stamper <= insider)
									{
										AssetManager.SetAssetBundle(Key, insider, true);
										goto IL_13C8;
									}
								}
							}
						}
						yield return this.GameMan.StartCoroutine(this.LoadStreamAssToPersistent(this.CDNRoot, AssUpdates2[(int)k], AssUpdates2[(int)(k + 1)], false, int.Parse(AssUpdates2[(int)(k + 5)]), 0, true));
						if (this.Failure)
						{
							break;
						}
						AssetManager.SetAssetBundle(Key, stamper, true);
					}
					IL_13C8:
					k += 6;
				}
				Text booster2 = this.Booster;
				GUIText guiText = this.Loader.guiText;
				booster2.text = (guiText.text += " OK");
				this.Loading(iteration);
				if (ushort.TryParse(AssUpdates2[2], out GameConstants.Version[2]) && GameConstants.Version[2] != this.Patching)
				{
					File.WriteAllText(AssetManager.persistentDataPath + "/Data/Patch", AssUpdates2[2]);
					this.Patching = GameConstants.Version[2];
				}
			}
			else
			{
				this.Failure = true;
			}
		}
		else
		{
			this.Failure = true;
		}
		if (this.Failure)
		{
			this.Loading(2f);
			NetworkManager.Instance.SetStage(LoginPhase.LP_EpicFail, 1L, true);
			yield return false;
		}
		GameConstants.Version[2] = this.Patching;
		NetworkManager.Instance.SetStage(LoginPhase.LP_Preparing, 0L, false);
		if (this.bundle != null)
		{
			this.bundle.Dispose();
		}
		this.bundle = null;
		if (this.GSpot.transform.parent.parent.childCount > 2)
		{
			if (IGGGameSDK.Instance.IGGIdIsReady)
			{
				this.GSpot.transform.parent.parent.GetChild(2).gameObject.SetActive(true);
			}
			this.GSpot.transform.parent.parent.GetChild(2).GetChild(1).GetComponent<Text>().font = GUIManager.Instance.GetTTFFont();
			this.GSpot.transform.parent.parent.GetChild(2).GetChild(1).GetComponent<Text>().text = DataManager.Instance.mStringTable.GetStringByID(7098u);
			this.Path.Length = 0;
			this.Teller.text = this.Path.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7049u), GameConstants.Version[0], GameConstants.Version[1], GameConstants.Version[2]).ToString();
			this.Chatter.transform.SetParent(GUIManager.Instance.m_TopLayer, false);
			yield return this.Reload;
		}
		if (this.AssList.Length > 0)
		{
			if (!File.Exists(AssetManager.persistentDataPath + "/Data/Assetver") || !File.ReadAllText(AssetManager.persistentDataPath + "/Data/Assetver").Equals(this.AV))
			{
				float iteration = 8f / (float)this.AssList.Length;
				ushort l = 0;
				while ((int)l < this.AssList.Length - 3)
				{
					this.Path.Length = 0;
					this.Loading(iteration);
					if (this.AssSheet[this.AssList[(int)l] + this.AssList[(int)(l + 1)]] == 0L)
					{
						yield return false;
					}
					else
					{
						using (FileStream fs4 = new FileStream(this.Path.AppendFormat("{0}/{1}/{2}", Application.persistentDataPath, this.AssList[(int)l], this.AssList[(int)(l + 1)]).ToString(), FileMode.OpenOrCreate))
						{
							using (StreamReader sr4 = new StreamReader(fs4))
							{
								long insider;
								if (long.TryParse(sr4.ReadLine(), out insider) && this.AssSheet[this.AssList[(int)l] + this.AssList[(int)(l + 1)]] <= insider)
								{
									yield return true;
									goto IL_19E0;
								}
							}
						}
						this.Loader.guiText.text = DataManager.Instance.mStringTable.GetStringByID((!UpdateController.InitialInstall) ? 99u : 37u);
						this.Booster.text = DataManager.Instance.mStringTable.GetStringByID(99u);
						yield return this.GameMan.StartCoroutine(this.LoadStreamAssToPersistent(this.Prefix + Application.streamingAssetsPath, this.AssList[(int)l], this.AssList[(int)(l + 1)], true, 0, 0, true));
					}
					IL_19E0:
					l += 4;
				}
				if (!File.Exists(Application.persistentDataPath + "/Data/Mailver") || !File.ReadAllText(Application.persistentDataPath + "/Data/Mailver").Equals(7.ToString()))
				{
					File.Delete(string.Format("{0}/Data/Mail", Application.persistentDataPath));
					DataManager.Instance.InitialMail();
				}
				File.WriteAllText(Application.persistentDataPath + "/Data/Mailver", 7.ToString());
				File.WriteAllText(Application.persistentDataPath + "/Data/Assetver", this.AV);
			}
			else
			{
				this.Loading(2f);
			}
			string text = DataManager.Instance.mStringTable.GetStringByID(593u);
			this.Loader.guiText.text = text;
			text = text;
			this.Booster.text = text;
			yield return text;
		}
		else
		{
			UnityEngine.Object.Destroy(this.Loader.GetComponent<GUIText>());
		}
		this.OnReady();
		this.GSpot.SetActive(false);
		GUIManager.Instance.HideUILock(EUILock.All);
		NetworkManager.Instance.SetStage(LoginPhase.LP_Disconnect, 0L, false);
		NetworkManager.LastStage = LoginPhase.LP_Disconnect;
		yield return true;
		this.PromptLogin();
		yield break;
	}

	// Token: 0x0600227F RID: 8831 RVA: 0x00408124 File Offset: 0x00406324
	private IEnumerator ParseStreamingAsset(bool clear)
	{
		string RootDir = "Android";
		NetworkManager.Instance.SetStage(LoginPhase.LP_Preparing, 0L, false);
		string[] DList = Directory.GetFileSystemEntries(Application.streamingAssetsPath);
		if (this.Reload || !File.Exists(AssetManager.persistentDataPath + "/Data/Assetver") || !File.ReadAllText(AssetManager.persistentDataPath + "/Data/Assetver").Equals(this.AV))
		{
			this.bundle = new WWW(this.Path.AppendFormat("{0}{1}/Data/Asset.plist", this.Prefix, Application.streamingAssetsPath).ToString());
			yield return this.bundle;
			this.AssList = Encoding.ASCII.GetString(this.bundle.bytes).Split(new string[]
			{
				"/",
				"\\",
				"\r",
				"\n"
			}, StringSplitOptions.RemoveEmptyEntries);
			this.Path.Length = 0;
			this.bundle = new WWW(this.Path.AppendFormat("{0}{1}/Data/Assetidx", this.Prefix, Application.streamingAssetsPath).ToString());
			this.AssSheet = new Dictionary<string, long>(this.AssList.Length >> 2);
			yield return this.bundle;
			if (this.bundle.error == null && !clear)
			{
				this.RoyalHost = Encoding.ASCII.GetString(this.bundle.bytes).Split(new string[]
				{
					"/",
					"\\",
					"\r",
					"\n"
				}, StringSplitOptions.RemoveEmptyEntries);
				ushort i = 0;
				while ((int)i < this.RoyalHost.Length - 3)
				{
					long stamper;
					long.TryParse(this.RoyalHost[(int)(i + 2)], out stamper);
					ushort j = 0;
					while ((int)j < this.AssList.Length - 3)
					{
						if (this.RoyalHost[(int)i].Equals(this.AssList[(int)j]) && this.RoyalHost[(int)(i + 1)].Equals(this.AssList[(int)(j + 1)]))
						{
							if (File.Exists(string.Concat(new string[]
							{
								Application.streamingAssetsPath,
								"/",
								this.AssList[(int)j],
								"/",
								this.AssList[(int)(j + 1)],
								".unity3d"
							})) && this.RoyalHost[(int)(i + 3)].Equals(new FileInfo(string.Format("{0}/{1}/{2}.unity3d", Application.streamingAssetsPath, this.RoyalHost[(int)i], this.RoyalHost[(int)(i + 1)])).Length.ToString()))
							{
								this.AssSheet[this.RoyalHost[(int)i] + "/" + this.RoyalHost[(int)(i + 1)]] = stamper;
							}
							break;
						}
						j += 4;
					}
					i += 4;
				}
			}
			float iteration = 8f / (float)this.AssList.Length;
			ushort k = 0;
			while ((int)k < this.AssList.Length - 3)
			{
				this.Path.Length = 0;
				long stamper;
				long.TryParse(this.AssList[(int)(k + 2)], out stamper);
				long insider;
				if (!this.AssSheet.TryGetValue(this.AssList[(int)k] + ("/" + this.AssList[(int)(k + 1)]), out insider) || stamper > insider)
				{
					Directory.CreateDirectory(Application.streamingAssetsPath + System.IO.Path.DirectorySeparatorChar + this.AssList[(int)k]);
					IEnumerator Parsing = this.LoadStreamAssToPersistent(this.Prefix + Application.streamingAssetsPath + RootDir, this.AssList[(int)k], this.AssList[(int)(k + 1)], true, 0, 0, false);
					while (Parsing.MoveNext())
					{
					}
					this.AssSheet[this.AssList[(int)k] + "/" + this.AssList[(int)(k + 1)]] = stamper;
				}
				k += 4;
			}
		}
		if (this.Failure)
		{
			NetworkManager.Instance.SetStage(LoginPhase.LP_EpicFail, 1L, true);
			NetworkManager.Instance.SetStage(LoginPhase.LP_Login, 110L, false);
			yield break;
		}
		using (StreamWriter AList = new StreamWriter(Application.streamingAssetsPath + "/Data/Assetidx"))
		{
			foreach (string key in this.AssSheet.Keys)
			{
				AList.WriteLine("{0}/{1}/{2}", key, this.AssSheet[key], new FileInfo(string.Format("{0}/{1}.unity3d", Application.streamingAssetsPath, key)).Length);
			}
		}
		for (int l = 0; l < DList.Length; l++)
		{
			if (Directory.Exists(DList[l]) && !System.IO.Path.GetFileName(DList[l]).Equals("Data"))
			{
				this.RoyalHost = Directory.GetDirectories(DList[l]);
				for (int m = 0; m < this.RoyalHost.Length; m++)
				{
					foreach (string List in Directory.GetFiles(this.RoyalHost[m], "*", SearchOption.AllDirectories))
					{
						File.SetAttributes(List, FileAttributes.Normal);
					}
					Directory.Delete(this.RoyalHost[m], true);
					File.Delete(this.RoyalHost[m] + ".meta");
				}
				this.RoyalHost = Directory.GetFiles(DList[l]);
				for (int n = 0; n < this.RoyalHost.Length; n++)
				{
					long insider;
					if (System.IO.Path.GetExtension(this.RoyalHost[n]).Equals(string.Empty) || (!this.RoyalHost[n].EndsWith("meta") && !this.AssSheet.TryGetValue(this.RoyalHost[n].Substring(Application.streamingAssetsPath.Length + 1).Replace(".unity3d", string.Empty).Replace("\\", "/"), out insider)))
					{
						File.SetAttributes(this.RoyalHost[n], FileAttributes.Normal);
						File.Delete(this.RoyalHost[n] + ".meta");
						File.Delete(this.RoyalHost[n]);
					}
				}
			}
			else if (!Directory.Exists(DList[l]) && !DList[l].EndsWith("meta"))
			{
				File.SetAttributes(DList[l], FileAttributes.Normal);
				File.Delete(DList[l] + ".meta");
				File.Delete(DList[l]);
			}
		}
		yield break;
	}

	// Token: 0x06002280 RID: 8832 RVA: 0x00408150 File Offset: 0x00406350
	public static void ReadStreamAssData()
	{
		StringBuilder stringBuilder = new StringBuilder();
		Directory.CreateDirectory(Application.streamingAssetsPath + "/Data");
		string text = "Android";
		string[] directories = Directory.GetDirectories(Application.streamingAssetsPath + text);
		using (StreamWriter streamWriter = new StreamWriter(Application.streamingAssetsPath + "/Data/Asset.plist"))
		{
			for (int i = 0; i < directories.Length; i++)
			{
				if (Directory.Exists(directories[i]))
				{
					string[] files = Directory.GetFiles(directories[i]);
					for (int j = 0; j < files.Length; j++)
					{
						AssetBundle assetBundle;
						if (files[j].Substring(files[j].Length - 11).Equals("assetbundle") && (assetBundle = AssetBundle.CreateFromFile(files[j])))
						{
							stringBuilder.Length = 0;
							DateTime dateTime;
							if (DateTime.TryParse((assetBundle.Load(System.IO.Path.GetFileNameWithoutExtension(files[j]) + "crc") as TextAsset).text, out dateTime))
							{
								streamWriter.WriteLine(stringBuilder.AppendFormat("{0}/{1}/{2}", files[j].Substring(Application.streamingAssetsPath.Length + 1, files[j].Length - 13 - Application.streamingAssetsPath.Length).Replace("iOS", string.Empty), DateTime.Parse((assetBundle.Load(System.IO.Path.GetFileNameWithoutExtension(files[j]) + "crc") as TextAsset).text).Ticks).ToString(), new FileInfo(files[j]).Length);
							}
							else
							{
								streamWriter.WriteLine(stringBuilder.AppendFormat("{0}/{1}/{2}", files[j].Substring(Application.streamingAssetsPath.Length + text.Length + 1, files[j].Length - 13 - Application.streamingAssetsPath.Length - text.Length).Replace("iOS", string.Empty), (assetBundle.Load(System.IO.Path.GetFileNameWithoutExtension(files[j]) + "crc") as TextAsset).text, new FileInfo(files[j]).Length));
							}
							assetBundle.Unload(true);
						}
					}
				}
			}
		}
		File.WriteAllText(Application.streamingAssetsPath + "/Data/Assetver", DateTime.UtcNow.Ticks.ToString());
		AssetManager.Instance.AssetManagerState = AssetState.Ready;
	}

	// Token: 0x06002281 RID: 8833 RVA: 0x0040840C File Offset: 0x0040660C
	private IEnumerator LoadStreamAssToPersistent(string data, string path, string file, bool notify = true, int revision = 0, byte lang = 0, bool unpack = true)
	{
		int num = 0;
		this.Path.Length = num;
		this.Buffer = (this.Terminator = (float)num);
		string localfile = this.Path.AppendFormat("{0}/{1}/{2}.unity3d", (!unpack) ? Application.streamingAssetsPath : AssetManager.persistentDataPath, path, (lang <= 0) ? file : AssetManager.StringAsset[(int)(lang - 1)]).ToString();
		Caching.CleanCache();
		WWW bundle;
		if (lang > 0)
		{
			bundle = WWW.LoadFromCacheOrDownload(string.Format("{0}/{1}/{2}@{3}.assetbundle", new object[]
			{
				data,
				path,
				AssetManager.StringAsset[(int)(lang - 1)],
				revision
			}), 0, 0u);
		}
		else if (revision > 0)
		{
			bundle = WWW.LoadFromCacheOrDownload(string.Format("{0}/{1}/{2}@{3}.assetbundle", new object[]
			{
				data,
				path,
				file,
				revision
			}), 0, 0u);
		}
		else
		{
			bundle = ((!unpack) ? null : WWW.LoadFromCacheOrDownload(string.Format("{0}/{1}/{2}.assetbundle", data, path, file), 0));
		}
		if (!unpack)
		{
			bundle = new WWW(string.Format("{0}/{1}/{2}.assetbundle", data, path, file));
		}
		else
		{
			while (bundle != null && !bundle.isDone)
			{
				yield return bundle;
				if (!notify)
				{
					if (this.Buffer != bundle.progress)
					{
						this.Buffer = bundle.progress;
						this.Terminator = 0f;
					}
					else if ((this.Terminator += NetworkManager.DeltaTime) > 15f)
					{
						break;
					}
				}
			}
		}
		if ((bundle != null && bundle.isDone && bundle.error == null && bundle.assetBundle) || !unpack)
		{
			Stream input = new MemoryStream((bundle.assetBundle.Load(file) as TextAsset).bytes);
			FileStream output = new FileStream(localfile, FileMode.Create);
			input.Read(this.Properties, 0, 5);
			this.coder.SetDecoderProperties(this.Properties);
			input.Read(this.Properties, 0, 8);
			if (unpack)
			{
				yield return this.GameMan.StartCoroutine(this.coder.Decode(input, output, input.Length, BitConverter.ToInt64(this.Properties, 0), this.Extraction, null));
			}
			else
			{
				IEnumerator Parsing = this.coder.Decode(input, output, input.Length, BitConverter.ToInt64(this.Properties, 0), this.Extraction, null);
				while (Parsing.MoveNext())
				{
				}
			}
			if (lang > 0)
			{
				this.NoStringAttached = true;
			}
			output.Flush();
			output.Close();
			input.Close();
			if (unpack)
			{
				File.WriteAllText(localfile.Remove(localfile.Length - 8, 8), (bundle.assetBundle.Load(file + "crc") as TextAsset).text);
			}
			bundle.assetBundle.Unload(true);
			bundle.Dispose();
			Resources.UnloadUnusedAssets();
			GC.Collect();
		}
		else
		{
			this.Failure = true;
			if (bundle != null)
			{
				bundle.Dispose();
			}
		}
		if (this.Loader && DataManager.Instance.mStringTable != null && notify && !UpdateController.InitialInstall)
		{
			Text booster = this.Booster;
			string stringByID = DataManager.Instance.mStringTable.GetStringByID(38u);
			this.Loader.guiText.text = stringByID;
			booster.text = stringByID;
		}
		yield break;
	}

	// Token: 0x04006B39 RID: 27449
	public static bool InitialInstall;

	// Token: 0x04006B3A RID: 27450
	public static bool UpdateCritical;

	// Token: 0x04006B3B RID: 27451
	public static byte UpdateFallback;

	// Token: 0x04006B3C RID: 27452
	public static byte UserLanguageId;

	// Token: 0x04006B3D RID: 27453
	public static byte StageController;

	// Token: 0x04006B3E RID: 27454
	public static float CheckController;

	// Token: 0x04006B3F RID: 27455
	public static string MessageReturner;

	// Token: 0x04006B40 RID: 27456
	public static UpdateController.WebClient UpdatePuller;

	// Token: 0x04006B41 RID: 27457
	public static UpdateController Updater;

	// Token: 0x04006B42 RID: 27458
	private SevenZip.Compression.LZMA.Decoder coder = new SevenZip.Compression.LZMA.Decoder();

	// Token: 0x04006B43 RID: 27459
	private StringBuilder Path = new StringBuilder();

	// Token: 0x04006B44 RID: 27460
	private string OSPath = string.Empty;

	// Token: 0x04006B45 RID: 27461
	private string Prefix = string.Empty;

	// Token: 0x04006B46 RID: 27462
	private string CDNRoot;

	// Token: 0x04006B47 RID: 27463
	private string[] RoyalHost;

	// Token: 0x04006B48 RID: 27464
	private string[] AssList;

	// Token: 0x04006B49 RID: 27465
	private Coroutine Router;

	// Token: 0x04006B4A RID: 27466
	private GameObject GSpot;

	// Token: 0x04006B4B RID: 27467
	private GameObject Loader;

	// Token: 0x04006B4C RID: 27468
	private GameObject Player;

	// Token: 0x04006B4D RID: 27469
	private GameObject Server;

	// Token: 0x04006B4E RID: 27470
	private GameObject Starter;

	// Token: 0x04006B4F RID: 27471
	private GameObject Chatter;

	// Token: 0x04006B50 RID: 27472
	private GameManager GameMan;

	// Token: 0x04006B51 RID: 27473
	private RectTransform Runner;

	// Token: 0x04006B52 RID: 27474
	private AssetBundle Initiator;

	// Token: 0x04006B53 RID: 27475
	private bool RequestDirector;

	// Token: 0x04006B54 RID: 27476
	private float Buffer;

	// Token: 0x04006B55 RID: 27477
	private float Terminator;

	// Token: 0x04006B56 RID: 27478
	private Text Booster;

	// Token: 0x04006B57 RID: 27479
	private Text Teller;

	// Token: 0x04006B58 RID: 27480
	private Text Hint;

	// Token: 0x04006B59 RID: 27481
	private bool Failure;

	// Token: 0x04006B5A RID: 27482
	private bool BufferUnderrun;

	// Token: 0x04006B5B RID: 27483
	private bool NoStringAttached;

	// Token: 0x04006B5C RID: 27484
	private bool Reload;

	// Token: 0x04006B5D RID: 27485
	private byte[] Properties = new byte[8];

	// Token: 0x04006B5E RID: 27486
	private Dictionary<string, long> AssSheet;

	// Token: 0x04006B5F RID: 27487
	private UIButton Selection;

	// Token: 0x04006B60 RID: 27488
	private uint Extraction;

	// Token: 0x04006B61 RID: 27489
	private ushort Patching;

	// Token: 0x04006B62 RID: 27490
	private string UAV;

	// Token: 0x04006B63 RID: 27491
	private string AV;

	// Token: 0x04006B64 RID: 27492
	private string Status;

	// Token: 0x04006B65 RID: 27493
	private WWW bundle;

	// Token: 0x02000702 RID: 1794
	public class WebClient : System.Net.WebClient
	{
		// Token: 0x06002283 RID: 8835 RVA: 0x0040849C File Offset: 0x0040669C
		protected override WebRequest GetWebRequest(Uri uri)
		{
			UpdateController.WebClient.Url = uri;
			this.Request = base.GetWebRequest(uri);
			try
			{
				this.Request.Timeout = 15000;
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
			return this.Request;
		}

		// Token: 0x06002284 RID: 8836 RVA: 0x00408500 File Offset: 0x00406700
		public void Close()
		{
			try
			{
				if (this.Request != null)
				{
					this.Request.Abort();
				}
				this.Dispose();
			}
			catch
			{
			}
		}

		// Token: 0x06002285 RID: 8837 RVA: 0x00408550 File Offset: 0x00406750
		public void Clear()
		{
			UpdateController.WebClient.Consented = (UpdateController.WebClient.Processed = false);
			UpdateController.WebClient.FileReady = (UpdateController.WebClient.FileError = false);
			UpdateController.WebClient.FileResume = (UpdateController.WebClient.FileTotal = 0L);
			UpdateController.WebClient.FileReceive = (UpdateController.WebClient.FileGauger = 0L);
			UpdateController.WebClient.SpeedTicket = 0f;
			UpdateController.WebClient.Progressing = 1f;
		}

		// Token: 0x06002286 RID: 8838 RVA: 0x004085A4 File Offset: 0x004067A4
		protected override void OnOpenReadCompleted(OpenReadCompletedEventArgs e)
		{
			base.OnOpenReadCompleted(e);
			try
			{
				if (!(UpdateController.WebClient.FileError = (e.Cancelled || e.Error != null)))
				{
					using (e.Result)
					{
						UpdateController.WebClient.FileLength = Convert.ToInt64(base.ResponseHeaders.Get("Content-Length"));
						UpdateController.WebClient.FileReady = true;
					}
				}
			}
			catch
			{
				UpdateController.WebClient.FileError = true;
			}
			finally
			{
				this.Close();
				UpdateController.UpdatePuller = null;
			}
			UpdateController.WebClient.Processed = true;
		}

		// Token: 0x04006B66 RID: 27494
		public static float SpeedTicket;

		// Token: 0x04006B67 RID: 27495
		public static float PendingTime;

		// Token: 0x04006B68 RID: 27496
		public static float Progressing;

		// Token: 0x04006B69 RID: 27497
		public static long FileReceive;

		// Token: 0x04006B6A RID: 27498
		public static long FileResume;

		// Token: 0x04006B6B RID: 27499
		public static long FileLength;

		// Token: 0x04006B6C RID: 27500
		public static long FileGauger;

		// Token: 0x04006B6D RID: 27501
		public static bool FileError;

		// Token: 0x04006B6E RID: 27502
		public static long FileTotal;

		// Token: 0x04006B6F RID: 27503
		public static bool FileReady;

		// Token: 0x04006B70 RID: 27504
		public static bool Processed;

		// Token: 0x04006B71 RID: 27505
		public static bool Consented;

		// Token: 0x04006B72 RID: 27506
		public static string Finish;

		// Token: 0x04006B73 RID: 27507
		public static Uri Url;

		// Token: 0x04006B74 RID: 27508
		private WebRequest Request;
	}
}
