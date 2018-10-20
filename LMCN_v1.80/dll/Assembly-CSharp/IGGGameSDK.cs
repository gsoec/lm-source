using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using MiniJSON;
using UnityEngine;

// Token: 0x02000762 RID: 1890
public class IGGGameSDK : MonoBehaviour
{
	// Token: 0x170000E6 RID: 230
	// (get) Token: 0x0600242D RID: 9261 RVA: 0x0041EEC4 File Offset: 0x0041D0C4
	public bool IGGIdIsReady
	{
		get
		{
			return this.bIGGIdIsReady;
		}
	}

	// Token: 0x170000E7 RID: 231
	// (get) Token: 0x0600242E RID: 9262 RVA: 0x0041EECC File Offset: 0x0041D0CC
	// (set) Token: 0x0600242F RID: 9263 RVA: 0x0041EED4 File Offset: 0x0041D0D4
	public string SaveBindGoogleAccount
	{
		get
		{
			return this.m_SaveBindGoogleAccount;
		}
		set
		{
			this.m_SaveBindGoogleAccount = value;
		}
	}

	// Token: 0x170000E8 RID: 232
	// (get) Token: 0x06002430 RID: 9264 RVA: 0x0041EEE0 File Offset: 0x0041D0E0
	public string SessionKey
	{
		get
		{
			return this.m_SessionKey;
		}
	}

	// Token: 0x170000E9 RID: 233
	// (get) Token: 0x06002432 RID: 9266 RVA: 0x0041EEF4 File Offset: 0x0041D0F4
	// (set) Token: 0x06002431 RID: 9265 RVA: 0x0041EEE8 File Offset: 0x0041D0E8
	public bool GameMaintanceDataReady
	{
		get
		{
			return this.bGameMaintanceDataReady;
		}
		set
		{
			this.bGameMaintanceDataReady = value;
		}
	}

	// Token: 0x170000EA RID: 234
	// (get) Token: 0x06002433 RID: 9267 RVA: 0x0041EEFC File Offset: 0x0041D0FC
	// (set) Token: 0x06002434 RID: 9268 RVA: 0x0041EF04 File Offset: 0x0041D104
	public bool NotConnect
	{
		get
		{
			return this.bNotConnect;
		}
		set
		{
			this.bNotConnect = value;
		}
	}

	// Token: 0x170000EB RID: 235
	// (get) Token: 0x06002435 RID: 9269 RVA: 0x0041EF10 File Offset: 0x0041D110
	public GameMaintanceData MaintanceData
	{
		get
		{
			return this.m_MaintanceData;
		}
	}

	// Token: 0x170000EC RID: 236
	// (get) Token: 0x06002436 RID: 9270 RVA: 0x0041EF18 File Offset: 0x0041D118
	public byte UserLanguageMapToTranslateLanguageIdx
	{
		get
		{
			return this._UserLanguageMapToTranslateLanguageIdx;
		}
	}

	// Token: 0x170000ED RID: 237
	// (get) Token: 0x06002437 RID: 9271 RVA: 0x0041EF20 File Offset: 0x0041D120
	public string SelectAccount
	{
		get
		{
			return this.m_SelectAccount;
		}
	}

	// Token: 0x170000EE RID: 238
	// (get) Token: 0x06002438 RID: 9272 RVA: 0x0041EF28 File Offset: 0x0041D128
	public static IGGGameSDK Instance
	{
		get
		{
			return IGGGameSDK.instance;
		}
	}

	// Token: 0x06002439 RID: 9273 RVA: 0x0041EF30 File Offset: 0x0041D130
	protected void Awake()
	{
		if (IGGGameSDK.instance == null)
		{
			IGGGameSDK.instance = this;
		}
		int num = Mathf.Clamp((int)DataManager.Instance.UserLanguage, 1, GameConstants.GlobalEditionGameID.Length - 1);
		IGGSDKPlugin.SetupIGGPlatform(GameConstants.CNGameID, GameConstants.CNSecretKey, GameConstants.CNPaymentKey, GameConstants.CNGCMSenderId);
		num = Mathf.Clamp((int)DataManager.Instance.UserLanguage, 1, GameConstants.TranslateTragetLanguage.Length - 1);
		IGGSDKPlugin.SetTragetLanguage(GameConstants.TranslateTragetLanguage[num]);
		this._UserLanguageMapToTranslateLanguageIdx = this.GetTranslateLanguageIdxByUseLanguage((byte)num);
		IGGSDKPlugin.SetAppsFlyerKey();
		PushManage.ClearPush();
		for (int i = 0; i < this.TranslateString.Length; i++)
		{
			if (this.TranslateString[i] == null)
			{
				this.TranslateString[i] = new CString(1024);
			}
		}
		if (this.TranslateBatchString == null)
		{
			this.TranslateBatchString = new CString(4100);
		}
		for (int j = 0; j < this.TranslateString_Mail.Length; j++)
		{
			if (this.TranslateString_Mail[j] == null)
			{
				this.TranslateString_Mail[j] = new CString(1100);
			}
		}
		if (this.TranslateBatchString_Mail == null)
		{
			this.TranslateBatchString_Mail = new CString(4500);
		}
		for (int k = 0; k < this.TranslateString_Diplomatic.Length; k++)
		{
			if (this.TranslateString_Diplomatic[k] == null)
			{
				this.TranslateString_Diplomatic[k] = new CString(1024);
			}
		}
		if (this.TranslateBatchString_Diplomatic == null)
		{
			this.TranslateBatchString_Diplomatic = new CString(8200);
		}
		if (this.TranslateStringOut_KA == null)
		{
			this.TranslateStringOut_KA = new CString(1400);
		}
		if (this.TranslateStringOut_AA_Info == null)
		{
			this.TranslateStringOut_AA_Info = new CString(1400);
		}
		if (this.TranslateStringOut_AA_Public == null)
		{
			this.TranslateStringOut_AA_Public = new CString(1400);
		}
	}

	// Token: 0x0600243A RID: 9274 RVA: 0x0041F110 File Offset: 0x0041D310
	private void DebugLog(string pMessage)
	{
	}

	// Token: 0x0600243B RID: 9275 RVA: 0x0041F114 File Offset: 0x0041D314
	private void NotifyIggIdIsReadyNow()
	{
		this.m_MailList = new List<string>();
		this.m_IGGProductItem.Clear();
		this.bPaymentReady = false;
		IGGSDKPlugin.GetWeChatProductList();
		IGGSDKPlugin.OpenGeTuiNotification();
		IGGSDKPlugin.SetFacebookEventActivateApp();
		IGGSDKPlugin.SetFacebookSdkInitialize();
		IGGSDKPlugin.RegisterCallback();
		IGGSDKPlugin.FacebookCheckInvites();
		IGGSDKPlugin.AppsFlyerSignUp();
		IGGSDKPlugin.ShowFacebookDebug();
		IGGSDKPlugin.CompleteRegistration("IGGSDK");
		IGGSDKPlugin.SetFacebookEventLaunched();
		if (NetworkManager.OnContinue())
		{
			this.SetLoginMsg(IGGLoginCode.IggReady);
		}
		else
		{
			this.bGameMaintanceDataReady = false;
			IGGSDKPlugin.LoadGameConfig();
		}
	}

	// Token: 0x0600243C RID: 9276 RVA: 0x0041F198 File Offset: 0x0041D398
	private void GameConfigIsReady()
	{
		if (this.m_RealNameState != RealNameState.Authorized && this.GetRealNameSW() == 1)
		{
			IGGSDKPlugin.CheckRealNameState();
		}
		this.LoginOrOpenAnnouncement();
	}

	// Token: 0x0600243D RID: 9277 RVA: 0x0041F1C0 File Offset: 0x0041D3C0
	private void LoginOrOpenAnnouncement()
	{
		if (this.GetGameMaintanceType() == GameMaintanceType.None)
		{
			this.SetLoginMsg(IGGLoginCode.IggReady);
		}
		else
		{
			this.bNeedOpenAnnouncement = true;
		}
	}

	// Token: 0x0600243E RID: 9278 RVA: 0x0041F1F0 File Offset: 0x0041D3F0
	private bool SetLoginMsg(IGGLoginCode code)
	{
		if (!this.bNeedShowCheckBox)
		{
			this.iggLoginCode = code;
			return this.bNeedShowCheckBox = true;
		}
		return false;
	}

	// Token: 0x0600243F RID: 9279 RVA: 0x0041F21C File Offset: 0x0041D41C
	private bool SetLoginMsg(string code)
	{
		IGGLoginCode iggloginCode = IGGLoginCode.Paranormal;
		int num;
		if (int.TryParse(code, out num))
		{
			iggloginCode = (IGGLoginCode)((num <= (int)iggloginCode) ? (num + 400000) : num);
		}
		return this.SetLoginMsg(iggloginCode);
	}

	// Token: 0x06002440 RID: 9280 RVA: 0x0041F258 File Offset: 0x0041D458
	public void CanLogIn()
	{
		NetworkManager.LogmeIn(this.m_IGGID, this.SessionKey);
	}

	// Token: 0x06002441 RID: 9281 RVA: 0x0041F26C File Offset: 0x0041D46C
	private void Update()
	{
		if (this.bNeedShowCheckBox)
		{
			this.bNeedShowCheckBox = UpdateController.OnIGGLogin(this.iggLoginCode);
		}
		if (this.bNeedUpdateAccountUI)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other_Account, 1, 0);
			this.bNeedUpdateAccountUI = false;
			this.bNeedSendAccountBind = true;
			SocialManager.Instance.BindingPlatform(true);
		}
		if (this.bNeedOpenAnnouncement)
		{
			this.bNeedOpenAnnouncement = false;
			if (UpdateController.OnIGGLoginBBS(false))
			{
				if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Announcement))
				{
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Announcement, 0, 0);
				}
				else
				{
					GUIManager.Instance.OpenMenu(EGUIWindow.UI_Announcement, 0, 0, false, false, false);
				}
			}
		}
		if (this.bNeedSendAccountBind && NetworkManager.Connected())
		{
			DataManager.Instance.SendAccountBind();
			this.bNeedSendAccountBind = false;
		}
		if (this.bRateSucceeded)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_TreasureBox, 1, 0);
			this.bRateSucceeded = false;
		}
		if (this.bBuyPackageSucceed != 0 && NetworkManager.Connected())
		{
			if (this.bBuyPackageSucceed == 1)
			{
				GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(899u), DataManager.Instance.mStringTable.GetStringByID(900u), DataManager.Instance.mStringTable.GetStringByID(3u), null, 0, 0, false, false, false, false, false);
				ushort num = (ushort)MallManager.Instance.SendCheckBuySN;
				if (num != 0 && MallManager.Instance.FindIndexBySN(num) != -1)
				{
					MallManager.Instance.bLockBuy = true;
				}
				ushort num2 = MallManager.Instance.SendCheckEmojiID;
				if (num2 != 0 && !GUIManager.Instance.HasEmotionPck(num2))
				{
					MallManager.Instance.bLockBuyEmojiID = true;
				}
				num2 = MallManager.Instance.SendCheckCastleID;
				if (num2 != 0 && !GUIManager.Instance.BuildingData.castleSkin.CheckUnlock((byte)num2))
				{
					MallManager.Instance.bLockBuyCastleID = true;
				}
				num2 = MallManager.Instance.SendCheckRedPocketID;
				if (num2 != 0)
				{
					MallManager.Instance.bLockBuyRedPocket = true;
				}
				if (MerchantmanManager.Instance.SendCheckBuy != 0)
				{
					MerchantmanManager.Instance.bLockBuy = true;
				}
			}
			this.bBuyPackageSucceed = 0;
		}
		if (this.bSprinklesSucceed == 1)
		{
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(11231u), DataManager.Instance.mStringTable.GetStringByID(11232u), DataManager.Instance.mStringTable.GetStringByID(3u), null, 0, 0, false, false, false, false, false);
			this.bSprinklesSucceed = 0;
		}
		if (this.bFacebookBindSuccessful)
		{
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(614u), DataManager.Instance.mStringTable.GetStringByID(9006u), null, null, 0, 0, false, false, false, false, false);
			this.bFacebookBindSuccessful = false;
			SocialManager.Instance.BindingPlatform(true);
		}
		if (this.bBindingNameSuccessful)
		{
			SocialManager.Instance.BindingPlatform(true);
			this.bBindingNameSuccessful = false;
		}
		if (this.bWeChatBindSuccessful)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other_Account, 1, 0);
			this.bWeChatBindSuccessful = false;
			this.bNeedSendAccountBind = true;
			SocialManager.Instance.BindingPlatform(true);
		}
		if (this.bNeedUpdateIOSAccountUI)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other_Account, 3, 0);
			this.bNeedUpdateIOSAccountUI = false;
		}
		if (this.bNeedShowSwitchCheckBox)
		{
			this.bNeedShowSwitchCheckBox = false;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other_Account, 100, 0);
		}
		if (this.bNeedShowBindAccountCheckBox)
		{
			this.bNeedShowBindAccountCheckBox = false;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other_Account, 200, 0);
		}
		if (this.bGuestLoginFailedCallBackNeedUpdate)
		{
			this.bGuestLoginFailedCallBackNeedUpdate = false;
			GUIManager.Instance.HideUILock(EUILock.SwitchAccount);
		}
		if (this.bAmazonBindSuccessful)
		{
			SocialManager.Instance.BindingPlatform(true);
		}
		if (this.PurchaseLimitType > 0)
		{
			if (this.PurchaseLimitType == 1)
			{
				GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(614u), DataManager.Instance.mStringTable.GetStringByID(10044u), DataManager.Instance.mStringTable.GetStringByID(3u), null, 0, 0, false, false, false, false, false);
			}
			else if (this.PurchaseLimitType == 2 || this.PurchaseLimitType == 3)
			{
				GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(614u), DataManager.Instance.mStringTable.GetStringByID(10043u), DataManager.Instance.mStringTable.GetStringByID(3u), null, 0, 0, false, false, false, false, false);
			}
			else if (this.PurchaseLimitType == 4)
			{
				GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(614u), DataManager.Instance.mStringTable.GetStringByID(14557u), DataManager.Instance.mStringTable.GetStringByID(3u), null, 0, 0, false, false, false, false, false);
			}
			this.PurchaseLimitType = 0;
		}
		if (this.payErrorCode != PayErrorCode.None)
		{
			GUIManager.Instance.MsgStr.ClearString();
			GUIManager.Instance.MsgStr.IntToFormat((long)this.payErrorCode, 1, false);
			if (this.payErrorCode == PayErrorCode.ErrorPaymentIsNotReady)
			{
				GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10178u));
			}
			else
			{
				GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10050u));
			}
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(614u), GUIManager.Instance.MsgStr.ToString(), DataManager.Instance.mStringTable.GetStringByID(3u), null, 0, 0, false, false, false, false, false);
			this.payErrorCode = PayErrorCode.None;
		}
		if (this.bPayErrorNoCode)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(10069u), 255, true);
			this.bPayErrorNoCode = false;
		}
		if (this.bNeedUpdateRealNameState)
		{
			RealNameHelp.Instance.SetRealNameState(this.m_RealNameState);
			RealNameHelp.Instance.CheckRealNameCallBack(this.m_RealNameState);
			AntiAddictive.Instance.Start(IGGGameSDK.Instance.GetAddictedCheckNoticeSW(), IGGGameSDK.Instance.GetAddictedCheckLimitLoginSW(), IGGGameSDK.Instance.m_RealNameState, IGGGameSDK.Instance.m_AgeState);
			this.bNeedUpdateRealNameState = false;
		}
		if (this.bOpenTermsService)
		{
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_Announcement);
			if (UpdateController.OnIGGLoginBBS(true))
			{
				GUIManager.Instance.OpenMenu(EGUIWindow.UI_TermOfService, 0, 0, false, false, false);
			}
			this.bOpenTermsService = false;
		}
		AntiAddictive.Instance.Update();
		RealNameHelp.Instance.Update();
	}

	// Token: 0x06002442 RID: 9282 RVA: 0x0041F930 File Offset: 0x0041DB30
	public void AutoLoginSuccessfulCallBack(string pString)
	{
		this.m_LoginState = IGGLoginState.IGGID_READY;
		this.CallBackWords = pString.Split(new char[]
		{
			';'
		});
		this.m_IGGID = this.CallBackWords[0];
		this.m_SessionKey = this.CallBackWords[1];
		this.bBindingGoogle = (this.CallBackWords[3] == "1");
		this.m_BindGoogleAccount = ((this.CallBackWords.Length <= 4 || !(this.CallBackWords[4] != "0")) ? string.Empty : this.CallBackWords[4]);
		if (this.CallBackWords.Length > 5)
		{
			if (this.CallBackWords[5] == "GOOGLE_PLAY")
			{
				this.m_IGGLoginType = IGGLoginType.GOOGLE_PLAY;
				this.SetBindingName(string.Empty);
			}
			else if (this.CallBackWords[5] == "gameCenter")
			{
				this.m_IGGLoginType = IGGLoginType.GameCenter;
				this.SetBindingName(string.Empty);
			}
			else if (this.CallBackWords[5] == "Facebook" || this.CallBackWords[5] == "facebook" || this.CallBackWords[5] == "FACEBOOK")
			{
				this.m_IGGLoginType = IGGLoginType.Facebook;
				this.m_BindGoogleAccount = this.CallBackWords[4];
				if (this.CallBackWords.Length > 6 && this.CallBackWords[6] != null)
				{
					this.m_PlatformLoginName = this.CallBackWords[6];
				}
			}
			else if (this.CallBackWords[5] == "wechat" || this.CallBackWords[5] == "WECHAT")
			{
				this.m_IGGLoginType = IGGLoginType.WeChat;
				if (this.CallBackWords.Length > 6 && this.CallBackWords[6] != null)
				{
					this.m_PlatformLoginName = this.CallBackWords[6];
				}
				if (this.CallBackWords.Length > 7 && this.CallBackWords[7] != null)
				{
					this.SetBindingName(this.CallBackWords[7]);
				}
			}
			else if (this.CallBackWords[5] == "AMAZON")
			{
				this.m_IGGLoginType = IGGLoginType.AMAZON;
				this.m_BindGoogleAccount = this.CallBackWords[4];
				if (this.CallBackWords.Length > 7 && this.CallBackWords[7] != null)
				{
					this.SetBindingName(this.CallBackWords[7]);
				}
			}
			else
			{
				this.m_IGGLoginType = IGGLoginType.GUEST;
				if (this.CallBackWords.Length > 7 && this.CallBackWords[7] != null)
				{
					this.SetBindingName(this.CallBackWords[7]);
				}
			}
		}
		if (this.bBindingGoogle && this.m_BindGoogleAccount == string.Empty)
		{
			this.m_BindGoogleAccount = DataManager.Instance.LoadBindMail();
		}
		this.bIGGIdIsReady = true;
		this.NotifyIggIdIsReadyNow();
	}

	// Token: 0x06002443 RID: 9283 RVA: 0x0041FC14 File Offset: 0x0041DE14
	public void AutoLoginFailedCallBack(string pString)
	{
		this.SetLoginMsg(pString);
	}

	// Token: 0x06002444 RID: 9284 RVA: 0x0041FC20 File Offset: 0x0041DE20
	public void GuestLoginSuccessfulCallBack(string pString)
	{
		if (GUIManager.Instance.GetUILock() == EUILock.SwitchAccount)
		{
			IGGSDKPlugin.NotificationUninitialize();
			this.SetLoginMsg(IGGLoginCode.SwitchOk);
		}
		else
		{
			this.CallBackWords = pString.Split(new char[]
			{
				';'
			});
			this.m_IGGID = this.CallBackWords[0];
			this.m_SessionKey = this.CallBackWords[1];
			if (this.CallBackWords[2] == "1")
			{
				this.bBindingGoogle = true;
				this.SetBindingName(string.Empty);
			}
			else
			{
				this.bBindingGoogle = false;
			}
			this.m_BindGoogleAccount = string.Empty;
			if (this.bBindingGoogle && this.m_BindGoogleAccount == string.Empty)
			{
				this.m_BindGoogleAccount = DataManager.Instance.LoadBindMail();
			}
			this.bIGGIdIsReady = true;
			this.NotifyIggIdIsReadyNow();
		}
	}

	// Token: 0x06002445 RID: 9285 RVA: 0x0041FD04 File Offset: 0x0041DF04
	public void GuestLoginFailedCallBack(string pString)
	{
		this.bGuestLoginFailedCallBackNeedUpdate = true;
		this.SetLoginMsg(pString);
	}

	// Token: 0x06002446 RID: 9286 RVA: 0x0041FD18 File Offset: 0x0041DF18
	public void FacebookLoginSuccessfulCallBack(string pString)
	{
		IGGSDKPlugin.UninitializeGeTu();
		this.SetLoginMsg(IGGLoginCode.SwitchOk);
	}

	// Token: 0x06002447 RID: 9287 RVA: 0x0041FD2C File Offset: 0x0041DF2C
	public void ClearFacebookSessionCallBack(string pString)
	{
		IGGSDKPlugin.UninitializeGeTu();
		this.SetLoginMsg(IGGLoginCode.SwitchOk);
	}

	// Token: 0x06002448 RID: 9288 RVA: 0x0041FD40 File Offset: 0x0041DF40
	public void FacebookLoginFailedCallBack(string pString)
	{
		GUIManager.Instance.AddHUDMessage(string.Format("{0}:{1}", DataManager.Instance.mStringTable.GetStringByID(7081u), pString), 255, true);
	}

	// Token: 0x06002449 RID: 9289 RVA: 0x0041FD7C File Offset: 0x0041DF7C
	public void FacebookBindSuccessfulCallBack(string pString)
	{
		this.bFacebookBindSuccessful = true;
		this.SetBindingNameByJSON(pString);
	}

	// Token: 0x0600244A RID: 9290 RVA: 0x0041FD8C File Offset: 0x0041DF8C
	public void FacebookBindFailedCallBack(string pString)
	{
		if (pString == "10023")
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9544u), 255, true);
		}
		else if (pString == "10024")
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9008u), 255, true);
		}
		else
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9007u), 255, true);
		}
	}

	// Token: 0x0600244B RID: 9291 RVA: 0x0041FE30 File Offset: 0x0041E030
	public void WechatLoginCallBackSuccessful(string pString)
	{
		IGGSDKPlugin.UninitializeGeTu();
		this.SetLoginMsg(IGGLoginCode.SwitchOk);
	}

	// Token: 0x0600244C RID: 9292 RVA: 0x0041FE44 File Offset: 0x0041E044
	public void WeChatLoginCallBackFailed(string pString)
	{
		GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7081u), 255, true);
	}

	// Token: 0x0600244D RID: 9293 RVA: 0x0041FE78 File Offset: 0x0041E078
	public void BindWeChatCallBackFailed(string pString)
	{
		GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID((!(pString == "2")) ? ((!(pString == "3")) ? 9007u : 9545u) : 9515u), 255, true);
	}

	// Token: 0x0600244E RID: 9294 RVA: 0x0041FEE0 File Offset: 0x0041E0E0
	public void BindWeChatCallBackSuccessful(string pString)
	{
		this.bBindingGoogle = true;
		this.bWeChatBindSuccessful = true;
		this.SetBindingNameByJSON(pString);
	}

	// Token: 0x0600244F RID: 9295 RVA: 0x0041FEF8 File Offset: 0x0041E0F8
	public void GameCenterLoginSuccessfulCallBack(string pString)
	{
		MonoBehaviour.print("GameCenterLoginSuccessfulCallBack:" + pString);
	}

	// Token: 0x06002450 RID: 9296 RVA: 0x0041FF0C File Offset: 0x0041E10C
	public void SwitchAccountCallBack(string pString)
	{
		this.m_SelectAccount = pString;
		this.bShowAccountState = false;
		this.bNeedShowSwitchCheckBox = true;
	}

	// Token: 0x06002451 RID: 9297 RVA: 0x0041FF24 File Offset: 0x0041E124
	public void SwitchingGoogleAccountSuccessfulCallBack(string pString)
	{
		GUIManager.Instance.HideUILock(EUILock.SwitchingGoogleAccount);
		this.SetLoginMsg(IGGLoginCode.SwitchOk);
	}

	// Token: 0x06002452 RID: 9298 RVA: 0x0041FF40 File Offset: 0x0041E140
	public void SwitchingGoogleAccountCancelCallBack(string pString)
	{
		GUIManager.Instance.HideUILock(EUILock.SwitchAccount);
		this.bNotConnect = false;
		NetworkManager.TimeOut();
	}

	// Token: 0x06002453 RID: 9299 RVA: 0x0041FF5C File Offset: 0x0041E15C
	public void SwitchingGoogleAccountFailedCallBack(string pString)
	{
		GUIManager.Instance.HideUILock(EUILock.SwitchAccount);
		GUIManager.Instance.AddHUDMessage(string.Format("{0}:{1}", DataManager.Instance.mStringTable.GetStringByID(7081u), pString), 255, true);
		this.bNotConnect = false;
		NetworkManager.TimeOut();
	}

	// Token: 0x06002454 RID: 9300 RVA: 0x0041FFB4 File Offset: 0x0041E1B4
	public void setFailedCallBack(string pString)
	{
		this.payErrorCode = PayErrorCode.ErrorPaymentFailed;
	}

	// Token: 0x06002455 RID: 9301 RVA: 0x0041FFC4 File Offset: 0x0041E1C4
	public void preparingPaymentFailedCallBack(string pString)
	{
		this.payErrorCode = PayErrorCode.ErrorPaymentIsNotReady;
	}

	// Token: 0x06002456 RID: 9302 RVA: 0x0041FFD4 File Offset: 0x0041E1D4
	public void paySuccessCallBack(string pString)
	{
		uint id = 0u;
		if (uint.TryParse(pString, out id))
		{
			AFAdvanceManager.Instance.CheckPurchase(id);
			AFAdvanceManager.Instance.SupplyHest(id);
		}
		this.bBuyPackageSucceed = 1;
	}

	// Token: 0x06002457 RID: 9303 RVA: 0x00420010 File Offset: 0x0041E210
	public void SprinklesSuccessCallBack(string pString)
	{
		this.bSprinklesSucceed = 1;
	}

	// Token: 0x06002458 RID: 9304 RVA: 0x0042001C File Offset: 0x0041E21C
	public void payGatewayFailedCallBack(string pString)
	{
		this.payErrorCode = PayErrorCode.ErrorPaymentGetway;
	}

	// Token: 0x06002459 RID: 9305 RVA: 0x0042002C File Offset: 0x0041E22C
	public void payFailedCallBack(string pString)
	{
		this.payErrorCode = PayErrorCode.ErrorPaymentFailed;
		MallManager.Instance.ClearSendCheckBuySN();
	}

	// Token: 0x0600245A RID: 9306 RVA: 0x00420044 File Offset: 0x0041E244
	public void payCancelCallBack(string pString)
	{
		MallManager.Instance.ClearSendCheckBuySN();
	}

	// Token: 0x0600245B RID: 9307 RVA: 0x00420050 File Offset: 0x0041E250
	public void payErrorNoCode(string pString)
	{
		this.bPayErrorNoCode = true;
	}

	// Token: 0x0600245C RID: 9308 RVA: 0x0042005C File Offset: 0x0041E25C
	public void getProductCallBack(string pString)
	{
		MallManager mallManager = MallManager.Instance;
		this.m_IGGProductItem.Clear();
		if (pString == null || string.Empty == pString || pString.Length <= 0)
		{
			IGGSDKPlugin.GetProductList();
			return;
		}
		string[] array = pString.Split(new char[]
		{
			'}'
		});
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != string.Empty)
			{
				string[] array2 = array[i].Split(new char[]
				{
					';'
				});
				IGGGameItem value = default(IGGGameItem);
				value.Id = int.Parse(array2[0]);
				value.Title = array2[1];
				value.Price = array2[2];
				value.Currency = array2[3];
				value.Flag = (IGGGameItemFlag)int.Parse(array2[4]);
				value.FreePoint = int.Parse(array2[5]);
				value.Point = int.Parse(array2[6]);
				value.Memo = array2[7];
				value.PlatformPrice = array2[8];
				this.m_IGGProductItem.Add(value.Id, value);
				if (!mallManager.m_MallItemPrice.ContainsKey(value.Id))
				{
					MallItemPrice value2 = default(MallItemPrice);
					value2.Id = value.Id;
					value2.Price = value.Price;
					value2.Currency = value.Currency;
					value2.Point = value.Point;
					value2.PaltformPrice = value.PlatformPrice;
					mallManager.m_MallItemPrice.Add(value2.Id, value2);
				}
				else if (mallManager.m_MallItemPrice[value.Id].Price != value.Price || mallManager.m_MallItemPrice[value.Id].Point != value.Point)
				{
					MallItemPrice value2 = mallManager.m_MallItemPrice[value.Id];
					value2.Id = value.Id;
					value2.Price = value.Price;
					value2.Currency = value.Currency;
					value2.Point = value.Point;
					value2.PaltformPrice = value.PlatformPrice;
					mallManager.m_MallItemPrice[value.Id] = value2;
					mallManager.bNeedUpDateItemPtice = true;
				}
			}
		}
		this.bPaymentReady = true;
	}

	// Token: 0x0600245D RID: 9309 RVA: 0x004202D4 File Offset: 0x0041E4D4
	public void GCMRegisterSuccessfulCallBack(string pString)
	{
	}

	// Token: 0x0600245E RID: 9310 RVA: 0x004202D8 File Offset: 0x0041E4D8
	public void GCMRegisterFailedCallBack(string pString)
	{
	}

	// Token: 0x0600245F RID: 9311 RVA: 0x004202DC File Offset: 0x0041E4DC
	public void BindAccountCallBack(string pString)
	{
		this.m_SelectAccount = pString;
		this.bShowAccountState = false;
		this.bNeedShowBindAccountCheckBox = true;
	}

	// Token: 0x06002460 RID: 9312 RVA: 0x004202F4 File Offset: 0x0041E4F4
	public void BindingGoogleSuccessfulCallBack(string pString)
	{
		GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7086u), 255, true);
		GUIManager.Instance.HideUILock(EUILock.Normal);
		DataManager.Instance.SaveBindMail(this.SaveBindGoogleAccount);
		this.m_BindGoogleAccount = this.SaveBindGoogleAccount;
		this.bBindingGoogle = true;
		this.bNeedUpdateAccountUI = true;
		this.SetBindingNameByJSON(string.Empty);
	}

	// Token: 0x06002461 RID: 9313 RVA: 0x00420368 File Offset: 0x0041E568
	public void BindingGoogleFailedCallBack(string pString)
	{
		if (pString == "1")
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8478u), 255, true);
		}
		else
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7082u), 255, true);
		}
		this.SaveBindGoogleAccount = string.Empty;
		GUIManager.Instance.HideUILock(EUILock.Normal);
	}

	// Token: 0x06002462 RID: 9314 RVA: 0x004203EC File Offset: 0x0041E5EC
	public void TapcashViewSuccessfulCallBack(string pString)
	{
	}

	// Token: 0x06002463 RID: 9315 RVA: 0x004203F0 File Offset: 0x0041E5F0
	public void TapcashViewFailedCallBack(string pString)
	{
	}

	// Token: 0x06002464 RID: 9316 RVA: 0x004203F4 File Offset: 0x0041E5F4
	public void RateUsSuccessfulCallBack(string pString)
	{
	}

	// Token: 0x06002465 RID: 9317 RVA: 0x004203F8 File Offset: 0x0041E5F8
	public void RateUsFailedCallBack(string pString)
	{
	}

	// Token: 0x06002466 RID: 9318 RVA: 0x004203FC File Offset: 0x0041E5FC
	public void FacebookLikeCallBack(string pString)
	{
	}

	// Token: 0x06002467 RID: 9319 RVA: 0x00420400 File Offset: 0x0041E600
	public void EventCarnivalCallBackSuccessful(string pString)
	{
	}

	// Token: 0x06002468 RID: 9320 RVA: 0x00420404 File Offset: 0x0041E604
	public void EventCarnivalCallBackFailed(string pString)
	{
	}

	// Token: 0x06002469 RID: 9321 RVA: 0x00420408 File Offset: 0x0041E608
	public void GameMaintanceCallBackSuccessful(string pString)
	{
		Dictionary<string, object> dictionary = Json.Deserialize(pString) as Dictionary<string, object>;
		if (dictionary == null)
		{
			return;
		}
		this.m_MaintanceData = default(GameMaintanceData);
		if (dictionary.ContainsKey("Update"))
		{
			Dictionary<string, object> dictionary2 = dictionary["Update"] as Dictionary<string, object>;
			if (dictionary2 == null)
			{
				return;
			}
			if (dictionary2.ContainsKey("isMaintain"))
			{
				this.m_MaintanceData.IsMaintain = dictionary2["isMaintain"].ToString();
			}
			if (dictionary2.ContainsKey("message_tw"))
			{
				this.m_MaintanceData.Message_Tw = dictionary2["message_tw"].ToString();
			}
			if (dictionary2.ContainsKey("message_Eg"))
			{
				this.m_MaintanceData.Message_Eg = dictionary2["message_Eg"].ToString();
			}
			if (dictionary2.ContainsKey("message_de"))
			{
				this.m_MaintanceData.Message_DE = dictionary2["message_de"].ToString();
			}
			if (dictionary2.ContainsKey("message_fr"))
			{
				this.m_MaintanceData.Message_FR = dictionary2["message_fr"].ToString();
			}
			if (dictionary2.ContainsKey("message_es"))
			{
				this.m_MaintanceData.Message_ES = dictionary2["message_es"].ToString();
			}
			if (dictionary2.ContainsKey("message_ru"))
			{
				this.m_MaintanceData.Message_RU = dictionary2["message_ru"].ToString();
			}
			if (dictionary2.ContainsKey("message_cn"))
			{
				this.m_MaintanceData.Message_CN = dictionary2["message_cn"].ToString();
			}
			if (dictionary2.ContainsKey("message_id"))
			{
				this.m_MaintanceData.Message_ID = dictionary2["message_id"].ToString();
			}
			if (dictionary2.ContainsKey("message_vi"))
			{
				this.m_MaintanceData.Message_VI = dictionary2["message_vi"].ToString();
			}
			if (dictionary2.ContainsKey("message_tr"))
			{
				this.m_MaintanceData.Message_TR = dictionary2["message_tr"].ToString();
			}
			if (dictionary2.ContainsKey("message_th"))
			{
				this.m_MaintanceData.Message_TH = dictionary2["message_th"].ToString();
			}
			if (dictionary2.ContainsKey("message_it"))
			{
				this.m_MaintanceData.Message_IT = dictionary2["message_it"].ToString();
			}
			if (dictionary2.ContainsKey("message_pt"))
			{
				this.m_MaintanceData.Message_PT = dictionary2["message_pt"].ToString();
			}
			if (dictionary2.ContainsKey("message_ko"))
			{
				this.m_MaintanceData.Message_KO = dictionary2["message_ko"].ToString();
			}
			if (dictionary2.ContainsKey("message_jp"))
			{
				this.m_MaintanceData.Message_JP = dictionary2["message_jp"].ToString();
			}
			if (dictionary2.ContainsKey("message_ua"))
			{
				this.m_MaintanceData.Message_UA = dictionary2["message_ua"].ToString();
			}
			if (dictionary2.ContainsKey("message_my"))
			{
				this.m_MaintanceData.Message_MY = dictionary2["message_my"].ToString();
			}
			if (dictionary2.ContainsKey("message_arb"))
			{
				this.m_MaintanceData.Message_ARB = dictionary2["message_arb"].ToString();
			}
			if (dictionary2.ContainsKey("startTime"))
			{
				this.m_MaintanceData.StartTime = dictionary2["startTime"].ToString();
			}
			if (dictionary2.ContainsKey("endTime"))
			{
				this.m_MaintanceData.EndTime = dictionary2["endTime"].ToString();
			}
		}
		if (dictionary.ContainsKey("loginBox"))
		{
			Dictionary<string, object> dictionary2 = dictionary["loginBox"] as Dictionary<string, object>;
			if (dictionary2 == null)
			{
				return;
			}
			if (dictionary2.ContainsKey("msg_tw"))
			{
				this.m_MaintanceData.LoginBoxMsg_Tw = dictionary2["msg_tw"].ToString();
			}
			if (dictionary2.ContainsKey("msg_Eg"))
			{
				this.m_MaintanceData.LoginBoxMsg_Eg = dictionary2["msg_Eg"].ToString();
			}
			if (dictionary2.ContainsKey("msg_de"))
			{
				this.m_MaintanceData.LoginBoxMsg_DE = dictionary2["msg_de"].ToString();
			}
			if (dictionary2.ContainsKey("msg_fr"))
			{
				this.m_MaintanceData.LoginBoxMsg_FR = dictionary2["msg_fr"].ToString();
			}
			if (dictionary2.ContainsKey("msg_es"))
			{
				this.m_MaintanceData.LoginBoxMsg_ES = dictionary2["msg_es"].ToString();
			}
			if (dictionary2.ContainsKey("msg_ru"))
			{
				this.m_MaintanceData.LoginBoxMsg_RU = dictionary2["msg_ru"].ToString();
			}
			if (dictionary2.ContainsKey("msg_cn"))
			{
				this.m_MaintanceData.LoginBoxMsg_CN = dictionary2["msg_cn"].ToString();
			}
			if (dictionary2.ContainsKey("msg_id"))
			{
				this.m_MaintanceData.LoginBoxMsg_ID = dictionary2["msg_id"].ToString();
			}
			if (dictionary2.ContainsKey("msg_vi"))
			{
				this.m_MaintanceData.LoginBoxMsg_VI = dictionary2["msg_vi"].ToString();
			}
			if (dictionary2.ContainsKey("msg_tr"))
			{
				this.m_MaintanceData.LoginBoxMsg_TR = dictionary2["msg_tr"].ToString();
			}
			if (dictionary2.ContainsKey("msg_th"))
			{
				this.m_MaintanceData.LoginBoxMsg_TH = dictionary2["msg_th"].ToString();
			}
			if (dictionary2.ContainsKey("msg_it"))
			{
				this.m_MaintanceData.LoginBoxMsg_IT = dictionary2["msg_it"].ToString();
			}
			if (dictionary2.ContainsKey("msg_pt"))
			{
				this.m_MaintanceData.LoginBoxMsg_PT = dictionary2["msg_pt"].ToString();
			}
			if (dictionary2.ContainsKey("msg_ko"))
			{
				this.m_MaintanceData.LoginBoxMsg_KO = dictionary2["msg_ko"].ToString();
			}
			if (dictionary2.ContainsKey("msg_jp"))
			{
				this.m_MaintanceData.LoginBoxMsg_JP = dictionary2["msg_jp"].ToString();
			}
			if (dictionary2.ContainsKey("msg_ua"))
			{
				this.m_MaintanceData.LoginBoxMsg_UA = dictionary2["msg_ua"].ToString();
			}
			if (dictionary2.ContainsKey("msg_my"))
			{
				this.m_MaintanceData.LoginBoxMsg_MY = dictionary2["msg_my"].ToString();
			}
			if (dictionary2.ContainsKey("msg_arb"))
			{
				this.m_MaintanceData.LoginBoxMsg_ARB = dictionary2["msg_arb"].ToString();
			}
			if (dictionary2.ContainsKey("startTime"))
			{
				this.m_MaintanceData.LoginBoxStartTime = dictionary2["startTime"].ToString();
			}
			if (dictionary2.ContainsKey("endTime"))
			{
				this.m_MaintanceData.LoginBoxEndTime = dictionary2["endTime"].ToString();
			}
		}
		if (dictionary.ContainsKey("clientUpdate"))
		{
			Dictionary<string, object> dictionary2 = dictionary["clientUpdate"] as Dictionary<string, object>;
			if (dictionary2 == null)
			{
				return;
			}
			if (dictionary2.ContainsKey("versionCode"))
			{
				this.m_MaintanceData.VersionCode = dictionary2["versionCode"].ToString();
			}
			if (dictionary2.ContainsKey("minVersion"))
			{
				this.m_MaintanceData.MinVersion = dictionary2["minVersion"].ToString();
			}
			if (dictionary2.ContainsKey("url"))
			{
				this.m_MaintanceData.URL = dictionary2["url"].ToString();
			}
			if (dictionary2.ContainsKey("version"))
			{
				this.m_MaintanceData.Version = dictionary2["version"].ToString();
			}
			if (dictionary2.ContainsKey("package"))
			{
				this.m_MaintanceData.Package = dictionary2["package"].ToString();
			}
			if (dictionary2.ContainsKey("size"))
			{
				this.m_MaintanceData.Size = dictionary2["size"].ToString();
			}
			if (dictionary2.ContainsKey("loginInfo_tw"))
			{
				this.m_MaintanceData.loginInfo_Tw = dictionary2["loginInfo_tw"].ToString();
			}
			if (dictionary2.ContainsKey("loginInfo_Eg"))
			{
				this.m_MaintanceData.loginInfo_Eg = dictionary2["loginInfo_Eg"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_tw"))
			{
				this.m_MaintanceData.UpdateInfo_Tw = dictionary2["updateInfo_tw"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_Eg"))
			{
				this.m_MaintanceData.UpdateInfo_Eg = dictionary2["updateInfo_Eg"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_de"))
			{
				this.m_MaintanceData.UpdateInfo_DE = dictionary2["updateInfo_de"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_fr"))
			{
				this.m_MaintanceData.UpdateInfo_FR = dictionary2["updateInfo_fr"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_es"))
			{
				this.m_MaintanceData.UpdateInfo_ES = dictionary2["updateInfo_es"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_ru"))
			{
				this.m_MaintanceData.UpdateInfo_RU = dictionary2["updateInfo_ru"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_cn"))
			{
				this.m_MaintanceData.UpdateInfo_CN = dictionary2["updateInfo_cn"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_id"))
			{
				this.m_MaintanceData.UpdateInfo_ID = dictionary2["updateInfo_id"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_vi"))
			{
				this.m_MaintanceData.UpdateInfo_VI = dictionary2["updateInfo_vi"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_tr"))
			{
				this.m_MaintanceData.UpdateInfo_TR = dictionary2["updateInfo_tr"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_th"))
			{
				this.m_MaintanceData.UpdateInfo_TH = dictionary2["updateInfo_th"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_it"))
			{
				this.m_MaintanceData.UpdateInfo_IT = dictionary2["updateInfo_it"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_pt"))
			{
				this.m_MaintanceData.UpdateInfo_PT = dictionary2["updateInfo_pt"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_ko"))
			{
				this.m_MaintanceData.UpdateInfo_KO = dictionary2["updateInfo_ko"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_jp"))
			{
				this.m_MaintanceData.UpdateInfo_JP = dictionary2["updateInfo_jp"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_ua"))
			{
				this.m_MaintanceData.UpdateInfo_UA = dictionary2["updateInfo_ua"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_my"))
			{
				this.m_MaintanceData.UpdateInfo_MY = dictionary2["updateInfo_my"].ToString();
			}
			if (dictionary2.ContainsKey("updateInfo_arb"))
			{
				this.m_MaintanceData.UpdateInfo_ARB = dictionary2["updateInfo_arb"].ToString();
			}
			if (dictionary2.ContainsKey("starStatus"))
			{
				this.m_MaintanceData.StarStatus = dictionary2["starStatus"].ToString();
			}
			if (dictionary2.ContainsKey("translate"))
			{
				this.m_MaintanceData.TranslateStatus = dictionary2["translate"].ToString();
			}
			if (dictionary2.ContainsKey("realNamePayCheck"))
			{
				this.m_MaintanceData.RealNameCheck = dictionary2["realNamePayCheck"].ToString();
			}
			if (dictionary2.ContainsKey("minorsDailySpendAmount"))
			{
				this.m_MaintanceData.MinorsDailySpendAmount = dictionary2["minorsDailySpendAmount"].ToString();
			}
			if (dictionary2.ContainsKey("addictedCheckNotice"))
			{
				this.m_MaintanceData.AddictedCheckNotice = dictionary2["addictedCheckNotice"].ToString();
			}
			if (dictionary2.ContainsKey("addictedCheckLimitLogin"))
			{
				this.m_MaintanceData.AddictedCheckLimitLogin = dictionary2["addictedCheckLimitLogin"].ToString();
			}
			if (dictionary2.ContainsKey("otherDownloadUrl"))
			{
				this.m_MaintanceData.OtherDownloadUrl = dictionary2["otherDownloadUrl"].ToString();
			}
		}
		if (dictionary.ContainsKey("loginServer"))
		{
			List<object> list = dictionary["loginServer"] as List<object>;
			this.m_MaintanceData.LoginServer = new LoginServerData[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				Dictionary<string, object> dictionary2 = list[i] as Dictionary<string, object>;
				if (dictionary2.ContainsKey("isOpen"))
				{
					this.m_MaintanceData.LoginServer[i].IsOpen = dictionary2["isOpen"].ToString();
				}
				if (dictionary2.ContainsKey("host"))
				{
					this.m_MaintanceData.LoginServer[i].Host = dictionary2["host"].ToString();
				}
			}
		}
		this.HiVersion = new int[3];
		this.LowVersion = new int[3];
		string[] array = this.m_MaintanceData.VersionCode.Split(new char[]
		{
			'.'
		});
		int num = 0;
		for (int j = 0; j < array.Length; j++)
		{
			if (int.TryParse(array[j], out num))
			{
				this.HiVersion[j] = num;
			}
		}
		array = this.m_MaintanceData.MinVersion.Split(new char[]
		{
			'.'
		});
		for (int k = 0; k < array.Length; k++)
		{
			if (int.TryParse(array[k], out num))
			{
				this.LowVersion[k] = num;
			}
		}
		this.bGameMaintanceDataReady = true;
		this.GameConfigIsReady();
	}

	// Token: 0x0600246A RID: 9322 RVA: 0x004212B4 File Offset: 0x0041F4B4
	public void GameMaintanceCallBackFailed(string pString)
	{
		this.SetLoginMsg(IGGLoginCode.IggReady);
	}

	// Token: 0x0600246B RID: 9323 RVA: 0x004212C0 File Offset: 0x0041F4C0
	public void RateGooglePlayApplicationSucceeded(string pString)
	{
		if (pString == "true")
		{
			this.bRateSucceeded = true;
		}
	}

	// Token: 0x0600246C RID: 9324 RVA: 0x004212DC File Offset: 0x0041F4DC
	public void TranslateSuccessfulCallBack(string pString)
	{
		this.bUsingTranslate = false;
		GUIManager.Instance.TranslateStr = pString;
		GUIManager.Instance.bBackTranslate = true;
		Debug.Log("TranslateSuccessfulCallBack");
	}

	// Token: 0x0600246D RID: 9325 RVA: 0x00421308 File Offset: 0x0041F508
	public void TranslateFailedCallBack(string pString)
	{
		this.bUsingTranslate = false;
		GUIManager.Instance.bBackTranslateFail = 1;
		Debug.Log("TranslateFailedCallBack");
	}

	// Token: 0x0600246E RID: 9326 RVA: 0x00421328 File Offset: 0x0041F528
	public void TranslateBatchSuccessfulCallBack(string pString)
	{
		this.bUsingTranslate = false;
		this.Split(pString);
		GUIManager.Instance.bBackTranslateBatch = true;
		Debug.Log("TranslateBatchSuccessfulCallBack");
	}

	// Token: 0x0600246F RID: 9327 RVA: 0x00421350 File Offset: 0x0041F550
	public void TranslateBatchFailedCallBack(string pString)
	{
		this.bUsingTranslate = false;
		GUIManager.Instance.bBackTranslateFail = 2;
		Debug.Log("TranslateBatchFailedCallBack");
	}

	// Token: 0x06002470 RID: 9328 RVA: 0x00421370 File Offset: 0x0041F570
	public void Translate_MailSuccessfulCallBack(string pString)
	{
	}

	// Token: 0x06002471 RID: 9329 RVA: 0x00421374 File Offset: 0x0041F574
	public void Translate_MailFailedCallBack(string pString)
	{
		Debug.Log("Translate_MailFailedCallBack");
	}

	// Token: 0x06002472 RID: 9330 RVA: 0x00421380 File Offset: 0x0041F580
	public void TranslateBatch_MailSuccessfulCallBack(string pString)
	{
		this.Split_Mail(pString);
		DataManager.Instance.MIB.Read = true;
		DataManager.Instance.MIB.Change = true;
	}

	// Token: 0x06002473 RID: 9331 RVA: 0x004213AC File Offset: 0x0041F5AC
	public void TranslateBatch_MailFailedCallBack(string pString)
	{
		DataManager.Instance.MIB.Change = true;
		DataManager.Instance.MIB.Read = false;
	}

	// Token: 0x06002474 RID: 9332 RVA: 0x004213DC File Offset: 0x0041F5DC
	public void TranslateBatch_DiplomaticSuccessfulCallBack(string pString)
	{
		this.Split_Diplomatic(pString);
		GUIManager.Instance.bBackTranslateBatch_MB = true;
	}

	// Token: 0x06002475 RID: 9333 RVA: 0x004213F0 File Offset: 0x0041F5F0
	public void Translate_KASuccessfulCallBack(string pString)
	{
		DataManager.Instance.mKingdomClassifieds_L = this.GetTranslateSplite(pString);
		DataManager.Instance.bTranslateClassifieds = true;
		DataManager.Instance.bWaitTranslateClassifieds = false;
	}

	// Token: 0x06002476 RID: 9334 RVA: 0x0042141C File Offset: 0x0041F61C
	public void Translate_KAFailedCallBack(string pString)
	{
		DataManager.Instance.bTranslateClassifiedsFailed = true;
		DataManager.Instance.bWaitTranslateClassifieds = false;
	}

	// Token: 0x06002477 RID: 9335 RVA: 0x00421434 File Offset: 0x0041F634
	public void TranslateBatch_DiplomaticFailedCallBack(string pString)
	{
		GUIManager.Instance.bBackTranslateFail_MB = 1;
	}

	// Token: 0x06002478 RID: 9336 RVA: 0x00421444 File Offset: 0x0041F644
	public void TranslateBatchByList(List<CString> list)
	{
		char value = '\u001f';
		this.TranslateBatchString.ClearString();
		int num = (10 <= list.Count) ? 9 : (list.Count - 1);
		int num2 = 0;
		while (num2 < 10 && num2 < list.Count)
		{
			this.TranslateBatchString.Append(list[num2].ToString());
			if (num2 != num)
			{
				this.TranslateBatchString.Append(value);
			}
			num2++;
		}
		this.TranslateBatchString.SetLength(this.TranslateBatchString.Length);
		IGGSDKPlugin.TranslateBatch(this.TranslateBatchString.ToString());
		this.TranslateBatchString.SetLength(this.TranslateBatchString.MaxLength);
	}

	// Token: 0x06002479 RID: 9337 RVA: 0x00421504 File Offset: 0x0041F704
	public void TranslateBatchByList_Mail(List<CString> list)
	{
		char value = '\u001f';
		this.TranslateBatchString_Mail.ClearString();
		int num = (5 <= list.Count) ? 4 : (list.Count - 1);
		int num2 = 0;
		while (num2 < 5 && num2 < list.Count)
		{
			this.TranslateBatchString_Mail.Append(list[num2].ToString());
			if (num2 != num)
			{
				this.TranslateBatchString_Mail.Append(value);
			}
			num2++;
		}
		this.TranslateBatchString_Mail.SetLength(this.TranslateBatchString_Mail.Length);
		IGGSDKPlugin.TranslateBatch_Mail(this.TranslateBatchString_Mail.ToString());
		this.TranslateBatchString_Mail.SetLength(this.TranslateBatchString_Mail.MaxLength);
	}

	// Token: 0x0600247A RID: 9338 RVA: 0x004215C0 File Offset: 0x0041F7C0
	public void TranslateBatchByList_Diplomatic(List<CString> list)
	{
		char value = '\u001f';
		this.TranslateBatchString_Diplomatic.ClearString();
		int num = (20 <= list.Count) ? 19 : (list.Count - 1);
		int num2 = 0;
		while (num2 < 20 && num2 < list.Count)
		{
			this.TranslateBatchString_Diplomatic.Append(list[num2].ToString());
			if (num2 != num)
			{
				this.TranslateBatchString_Diplomatic.Append(value);
			}
			num2++;
		}
		this.TranslateBatchString_Diplomatic.SetLength(this.TranslateBatchString_Diplomatic.Length);
		IGGSDKPlugin.TranslateBatch_Diplomatic(this.TranslateBatchString_Diplomatic.ToString());
		this.TranslateBatchString_Diplomatic.SetLength(this.TranslateBatchString_Diplomatic.MaxLength);
	}

	// Token: 0x0600247B RID: 9339 RVA: 0x00421680 File Offset: 0x0041F880
	public void Translate_AASuccessfulCallBack(string pString)
	{
		DataManager dataManager = DataManager.Instance;
		if (dataManager.bTransAA)
		{
			DataManager.Instance.mAA_Info_L = this.GetTranslateSplite_AA_Info(pString);
			DataManager.Instance.bTranslate_AA_Info = true;
		}
		else
		{
			DataManager.Instance.mAA_P_L = this.GetTranslateSplite_AA_Public(pString);
			DataManager.Instance.bTranslate_AA_P = true;
		}
		DataManager.Instance.bWaitTranslate_AA = false;
	}

	// Token: 0x0600247C RID: 9340 RVA: 0x004216E8 File Offset: 0x0041F8E8
	public void Translate_AAFailedCallBack(string pString)
	{
		DataManager dataManager = DataManager.Instance;
		if (dataManager.bTransAA)
		{
			DataManager.Instance.bTranslate_AA_InfoFailed = true;
		}
		else
		{
			DataManager.Instance.bTranslate_AA_PFailed = true;
		}
		DataManager.Instance.bWaitTranslate_AA = false;
	}

	// Token: 0x0600247D RID: 9341 RVA: 0x0042172C File Offset: 0x0041F92C
	public unsafe void Split(string pString)
	{
		char c = '\u001f';
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < this.TranslateString.Length; i++)
		{
			this.TranslateString[i].Length = 0;
		}
		int j = 0;
		while (j < pString.Length)
		{
			fixed (string text = pString.ToString())
			{
				fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
				{
					if (ptr[j] == c)
					{
						num++;
						if (num >= this.TranslateString.Length)
						{
							break;
						}
						fixed (string text2 = this.TranslateString[num].ToString())
						{
							fixed (char* ptr2 = text2 + RuntimeHelpers.OffsetToStringData / 2)
							{
								ptr2[num2] = '\0';
								text2 = null;
								num2 = 0;
							}
						}
					}
					else
					{
						text = null;
						if (num < this.TranslateString.Length)
						{
							fixed (string text3 = this.TranslateString[num].ToString())
							{
								fixed (char* ptr3 = text3 + RuntimeHelpers.OffsetToStringData / 2)
								{
									ptr3[num2++ * 2] = pString[j];
									text3 = null;
									this.TranslateString[num].Length++;
								}
							}
						}
					}
					j++;
				}
			}
		}
	}

	// Token: 0x0600247E RID: 9342 RVA: 0x00421844 File Offset: 0x0041FA44
	public unsafe void Split_Mail(string pString)
	{
		char c = '\u001f';
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < this.TranslateString_Mail.Length; i++)
		{
			this.TranslateString_Mail[i].Length = 0;
		}
		int j = 0;
		while (j < pString.Length)
		{
			fixed (string text = pString.ToString())
			{
				fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
				{
					if (ptr[j] == c)
					{
						num++;
						if (num >= this.TranslateString_Mail.Length)
						{
							break;
						}
						fixed (string text2 = this.TranslateString_Mail[num].ToString())
						{
							fixed (char* ptr2 = text2 + RuntimeHelpers.OffsetToStringData / 2)
							{
								ptr2[num2] = '\0';
								text2 = null;
								num2 = 0;
							}
						}
					}
					else
					{
						text = null;
						if (num < this.TranslateString_Mail.Length)
						{
							fixed (string text3 = this.TranslateString_Mail[num].ToString())
							{
								fixed (char* ptr3 = text3 + RuntimeHelpers.OffsetToStringData / 2)
								{
									ptr3[num2++ * 2] = pString[j];
									text3 = null;
									this.TranslateString_Mail[num].Length++;
								}
							}
						}
					}
					j++;
				}
			}
		}
	}

	// Token: 0x0600247F RID: 9343 RVA: 0x0042195C File Offset: 0x0041FB5C
	public unsafe void Split_Diplomatic(string pString)
	{
		char c = '\u001f';
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < this.TranslateString_Diplomatic.Length; i++)
		{
			this.TranslateString_Diplomatic[i].Length = 0;
		}
		int j = 0;
		while (j < pString.Length)
		{
			fixed (string text = pString.ToString())
			{
				fixed (char* ptr = text + RuntimeHelpers.OffsetToStringData / 2)
				{
					if (ptr[j] == c)
					{
						num++;
						if (num >= this.TranslateString_Diplomatic.Length)
						{
							break;
						}
						fixed (string text2 = this.TranslateString_Diplomatic[num].ToString())
						{
							fixed (char* ptr2 = text2 + RuntimeHelpers.OffsetToStringData / 2)
							{
								ptr2[num2] = '\0';
								text2 = null;
								num2 = 0;
							}
						}
					}
					else
					{
						text = null;
						if (num < this.TranslateString_Diplomatic.Length)
						{
							fixed (string text3 = this.TranslateString_Diplomatic[num].ToString())
							{
								fixed (char* ptr3 = text3 + RuntimeHelpers.OffsetToStringData / 2)
								{
									ptr3[num2++ * 2] = pString[j];
									text3 = null;
									this.TranslateString_Diplomatic[num].Length++;
								}
							}
						}
					}
					j++;
				}
			}
		}
	}

	// Token: 0x06002480 RID: 9344 RVA: 0x00421A74 File Offset: 0x0041FC74
	public ushort GetTranslateSplite(string pString)
	{
		if (pString == null)
		{
			return 0;
		}
		char c = '\u007f';
		CString cstring = StringManager.Instance.StaticString1024();
		int i;
		for (i = 0; i < pString.Length; i++)
		{
			if (pString[i] == c)
			{
				break;
			}
			cstring.Append(pString[i]);
		}
		cstring.SetLength(cstring.Length);
		ushort translateLanguageStringId = (ushort)this.GetTranslateLanguageStringId(cstring.ToString());
		cstring.SetLength(cstring.MaxLength);
		this.TranslateStringOut_KA.Length = 0;
		this.TranslateStringOut_KA.Substring(pString, i + 1);
		this.TranslateStringOut_KA.CheckBannedWord();
		return translateLanguageStringId;
	}

	// Token: 0x06002481 RID: 9345 RVA: 0x00421B1C File Offset: 0x0041FD1C
	public ushort GetTranslateSplite_AA_Info(string pString)
	{
		if (pString == null)
		{
			return 0;
		}
		char c = '\u007f';
		CString cstring = StringManager.Instance.StaticString1024();
		int i;
		for (i = 0; i < pString.Length; i++)
		{
			if (pString[i] == c)
			{
				break;
			}
			cstring.Append(pString[i]);
		}
		cstring.SetLength(cstring.Length);
		ushort translateLanguageStringId = (ushort)this.GetTranslateLanguageStringId(cstring.ToString());
		cstring.SetLength(cstring.MaxLength);
		this.TranslateStringOut_AA_Info.Length = 0;
		this.TranslateStringOut_AA_Info.Substring(pString, i + 1);
		this.TranslateStringOut_AA_Info.CheckBannedWord();
		return translateLanguageStringId;
	}

	// Token: 0x06002482 RID: 9346 RVA: 0x00421BC4 File Offset: 0x0041FDC4
	public ushort GetTranslateSplite_AA_Public(string pString)
	{
		if (pString == null)
		{
			return 0;
		}
		char c = '\u007f';
		CString cstring = StringManager.Instance.StaticString1024();
		int i;
		for (i = 0; i < pString.Length; i++)
		{
			if (pString[i] == c)
			{
				break;
			}
			cstring.Append(pString[i]);
		}
		cstring.SetLength(cstring.Length);
		ushort translateLanguageStringId = (ushort)this.GetTranslateLanguageStringId(cstring.ToString());
		cstring.SetLength(cstring.MaxLength);
		this.TranslateStringOut_AA_Public.Length = 0;
		this.TranslateStringOut_AA_Public.Substring(pString, i + 1);
		this.TranslateStringOut_AA_Public.CheckBannedWord();
		return translateLanguageStringId;
	}

	// Token: 0x06002483 RID: 9347 RVA: 0x00421C6C File Offset: 0x0041FE6C
	public void AliPayCallBackSuccessful(string pString)
	{
		this.bBuyPackageSucceed = 1;
		GUIManager.Instance.HideUILock(EUILock.AliPay);
	}

	// Token: 0x06002484 RID: 9348 RVA: 0x00421C84 File Offset: 0x0041FE84
	public void AliPayCallBackFailed(string pString)
	{
		MallManager.Instance.ClearSendCheckBuySN();
		GUIManager.Instance.HideUILock(EUILock.AliPay);
	}

	// Token: 0x06002485 RID: 9349 RVA: 0x00421CA0 File Offset: 0x0041FEA0
	public void AliPayConfirming(string pString)
	{
		MallManager.Instance.ClearSendCheckBuySN();
		GUIManager.Instance.HideUILock(EUILock.AliPay);
	}

	// Token: 0x06002486 RID: 9350 RVA: 0x00421CBC File Offset: 0x0041FEBC
	public void WeChatPayCallBackSuccessful(string pString)
	{
		this.bBuyPackageSucceed = 1;
		GUIManager.Instance.HideUILock(EUILock.WeChatPay);
	}

	// Token: 0x06002487 RID: 9351 RVA: 0x00421CD4 File Offset: 0x0041FED4
	public void WeChatPayCallBackFailed(string pString)
	{
		MallManager.Instance.ClearSendCheckBuySN();
		GUIManager.Instance.HideUILock(EUILock.WeChatPay);
	}

	// Token: 0x06002488 RID: 9352 RVA: 0x00421CF0 File Offset: 0x0041FEF0
	public void WeChatPatCallBackCencel(string pString)
	{
		MallManager.Instance.ClearSendCheckBuySN();
		GUIManager.Instance.HideUILock(EUILock.WeChatPay);
	}

	// Token: 0x06002489 RID: 9353 RVA: 0x00421D0C File Offset: 0x0041FF0C
	public void AmoutOfLimitFailed(string pString)
	{
		this.PurchaseLimitType = 4;
		GUIManager.Instance.HideUILock(EUILock.AliPay);
		GUIManager.Instance.HideUILock(EUILock.WeChatPay);
	}

	// Token: 0x0600248A RID: 9354 RVA: 0x00421D30 File Offset: 0x0041FF30
	public void AmoutOfLimitErrorFailed(string pString)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat(pString);
		cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(16018u));
		GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
		GUIManager.Instance.HideUILock(EUILock.AliPay);
		GUIManager.Instance.HideUILock(EUILock.WeChatPay);
	}

	// Token: 0x0600248B RID: 9355 RVA: 0x00421D9C File Offset: 0x0041FF9C
	public void BindingAmazonSuccessfulCallBack()
	{
		this.bBindingGoogle = true;
		this.bAmazonBindSuccessful = true;
		this.SetBindingName(string.Empty);
	}

	// Token: 0x0600248C RID: 9356 RVA: 0x00421DB8 File Offset: 0x0041FFB8
	public void BindingAmazonFailedCallBack()
	{
		GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9007u), 255, true);
	}

	// Token: 0x0600248D RID: 9357 RVA: 0x00421DEC File Offset: 0x0041FFEC
	public void AmazonLoginCallBackSuccessful()
	{
		this.SetLoginMsg(IGGLoginCode.SwitchOk);
	}

	// Token: 0x0600248E RID: 9358 RVA: 0x00421DFC File Offset: 0x0041FFFC
	public void AmazonLoginCallBackFailed()
	{
		GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7081u), 255, true);
	}

	// Token: 0x0600248F RID: 9359 RVA: 0x00421E30 File Offset: 0x00420030
	public void PurchaseLimitCallBack(string type)
	{
		if (type == "1")
		{
			this.PurchaseLimitType = 1;
		}
		else if (type == "2")
		{
			this.PurchaseLimitType = 2;
		}
		else if (type == "3")
		{
			this.PurchaseLimitType = 3;
		}
		GUIManager.Instance.HideUILock(EUILock.WeChatPay);
		GUIManager.Instance.HideUILock(EUILock.AliPay);
	}

	// Token: 0x06002490 RID: 9360 RVA: 0x00421EA8 File Offset: 0x004200A8
	public void RealNameCallBackFailed(string errorcode)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.StringToFormat(errorcode);
		cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(16018u));
		GUIManager.Instance.AddHUDMessage(cstring.ToString(), 255, true);
	}

	// Token: 0x06002491 RID: 9361 RVA: 0x00421EF8 File Offset: 0x004200F8
	public void RealNameCheckCallBack(string state)
	{
		this.m_RealNameState = RealNameState.UnAuthorized;
		this.m_AgeState = AgeState.Nonage;
		if (state.Equals("1"))
		{
			this.m_RealNameState = RealNameState.Sumbitted;
			this.m_AgeState = AgeState.Nonage;
		}
		else if (state.Equals("2"))
		{
			this.m_RealNameState = RealNameState.Authorized;
			this.m_AgeState = AgeState.GrownUp;
		}
		else if (state.Equals("3"))
		{
			this.m_RealNameState = RealNameState.Authorized;
			this.m_AgeState = AgeState.Nonage;
		}
		else if (state.Equals("4"))
		{
			this.m_RealNameState = RealNameState.UnAuthorized;
			this.m_AgeState = AgeState.Nonage;
		}
		this.bNeedUpdateRealNameState = true;
	}

	// Token: 0x06002492 RID: 9362 RVA: 0x00421FA4 File Offset: 0x004201A4
	public void OnInstallConversionDataLoaded(string pData)
	{
		Debug.LogError(pData);
		SocialManager.Instance.InviterIGGId = 0L;
		SocialManager.Instance.InviterName = string.Empty;
		Dictionary<string, object> dictionary = Json.Deserialize(pData) as Dictionary<string, object>;
		if (dictionary == null)
		{
			return;
		}
		if (dictionary.ContainsKey("media_source"))
		{
			string text = dictionary["media_source"].ToString();
			if (text.Equals("friend-recommendation"))
			{
				if (dictionary.ContainsKey("af_sub1"))
				{
					long.TryParse(dictionary["af_sub1"].ToString(), out SocialManager.Instance.InviterIGGId);
				}
				if (dictionary.ContainsKey("af_sub2"))
				{
					SocialManager.Instance.InviterName = dictionary["af_sub2"].ToString();
					if (SocialManager.Instance.InviterName.Equals("null"))
					{
						SocialManager.Instance.InviterName = string.Empty;
					}
				}
			}
		}
	}

	// Token: 0x06002493 RID: 9363 RVA: 0x00422098 File Offset: 0x00420298
	public void OnInstallConversionFailure(string pData)
	{
		Debug.LogError(pData);
		SocialManager.Instance.InviterIGGId = 0L;
		SocialManager.Instance.InviterName = string.Empty;
	}

	// Token: 0x06002494 RID: 9364 RVA: 0x004220BC File Offset: 0x004202BC
	public void OnAppOpenAttribution(string pData)
	{
		Debug.LogError(pData);
	}

	// Token: 0x06002495 RID: 9365 RVA: 0x004220C4 File Offset: 0x004202C4
	public void OnAttributionFailure(string pData)
	{
		Debug.LogError(pData);
	}

	// Token: 0x06002496 RID: 9366 RVA: 0x004220CC File Offset: 0x004202CC
	public static void OpenSuggestUrl()
	{
		int num = Mathf.Clamp((int)DataManager.Instance.UserLanguage, 1, GameConstants.GlobalEditionGameID.Length - 1);
		string suggestUrl = IGGGameSDK.GetSuggestUrl(GameConstants.GlobalEditionGameID[num], IGGGameSDK.instance.m_SessionKey, GameConstants.GlobalEditionNewsUrlKey);
		if (suggestUrl != null)
		{
			IGGSDKPlugin.LoadWebView(suggestUrl);
		}
	}

	// Token: 0x06002497 RID: 9367 RVA: 0x00422120 File Offset: 0x00420320
	public static string GetSuggestUrl(string gameid, string sessionKey, string sigKey)
	{
		string str = "http://lordsmobile.igg.com/project/suggest/";
		string text = "game_id={0}&signed_key={1}{2}";
		text = string.Format(text, gameid, sessionKey, sigKey);
		text = IGGGameSDK.Md5Sum(text);
		return string.Format(str + "?game_id={0}&signed_key={1}&sig={2}", gameid, sessionKey, text);
	}

	// Token: 0x06002498 RID: 9368 RVA: 0x00422160 File Offset: 0x00420360
	public static string Md5Sum(string strToEncrypt)
	{
		UTF8Encoding utf8Encoding = new UTF8Encoding();
		byte[] bytes = utf8Encoding.GetBytes(strToEncrypt);
		MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] array = md5CryptoServiceProvider.ComputeHash(bytes);
		string text = string.Empty;
		for (int i = 0; i < array.Length; i++)
		{
			text += Convert.ToString(array[i], 16).PadLeft(2, '0');
		}
		return text.PadLeft(32, '0');
	}

	// Token: 0x06002499 RID: 9369 RVA: 0x004221D0 File Offset: 0x004203D0
	public string GetProductPriceByID(int id)
	{
		if (this.bPaymentReady && this.m_IGGProductItem.ContainsKey(id))
		{
			return this.m_IGGProductItem[id].Price;
		}
		return null;
	}

	// Token: 0x0600249A RID: 9370 RVA: 0x00422210 File Offset: 0x00420410
	public bool GetProductPointByID(int id, out int point)
	{
		bool result = false;
		point = 0;
		if (this.bPaymentReady && this.m_IGGProductItem.ContainsKey(id))
		{
			point = this.m_IGGProductItem[id].Point;
			result = true;
		}
		return result;
	}

	// Token: 0x0600249B RID: 9371 RVA: 0x00422258 File Offset: 0x00420458
	public string GetCurrency(int id)
	{
		if (this.bPaymentReady && this.m_IGGProductItem.ContainsKey(id))
		{
			return this.m_IGGProductItem[id].Currency;
		}
		return null;
	}

	// Token: 0x0600249C RID: 9372 RVA: 0x00422298 File Offset: 0x00420498
	public string GetProductTitleByID(int id)
	{
		if (this.bPaymentReady && this.m_IGGProductItem.ContainsKey(id))
		{
			return this.m_IGGProductItem[id].Title;
		}
		return null;
	}

	// Token: 0x0600249D RID: 9373 RVA: 0x004222D8 File Offset: 0x004204D8
	public GameMaintanceType GetGameMaintanceType()
	{
		DateTime t;
		if (this.MaintanceData.StartTime != string.Empty && this.MaintanceData.StartTime != "0")
		{
			DateTime dateTime = Convert.ToDateTime(this.MaintanceData.StartTime);
			DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, new TimeSpan(-5, 0, 0));
			t = dateTimeOffset.UtcDateTime.ToLocalTime();
		}
		else
		{
			t = default(DateTime);
		}
		DateTime t2;
		if (this.MaintanceData.EndTime != string.Empty && this.MaintanceData.EndTime != "0")
		{
			DateTime dateTime = Convert.ToDateTime(this.MaintanceData.EndTime);
			DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, new TimeSpan(-5, 0, 0));
			t2 = dateTimeOffset.UtcDateTime.ToLocalTime();
		}
		else
		{
			t2 = default(DateTime);
		}
		DateTime t3;
		if (this.MaintanceData.LoginBoxEndTime != string.Empty && this.MaintanceData.LoginBoxEndTime != "0")
		{
			DateTime dateTime = Convert.ToDateTime(this.MaintanceData.LoginBoxEndTime);
			DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, new TimeSpan(-5, 0, 0));
			t3 = dateTimeOffset.UtcDateTime.ToLocalTime();
		}
		else
		{
			t3 = default(DateTime);
		}
		DateTime t4;
		if (this.MaintanceData.LoginBoxStartTime != string.Empty && this.MaintanceData.LoginBoxStartTime != "0")
		{
			DateTime dateTime = Convert.ToDateTime(this.MaintanceData.LoginBoxStartTime);
			DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, new TimeSpan(-5, 0, 0));
			t4 = dateTimeOffset.UtcDateTime.ToLocalTime();
		}
		else
		{
			t4 = default(DateTime);
		}
		GameMaintanceType gameMaintanceType = this.NeedUpdateVession();
		GameMaintanceType result;
		if (gameMaintanceType != GameMaintanceType.None)
		{
			result = gameMaintanceType;
		}
		else if (this.m_MaintanceData.IsMaintain == "1" && DateTime.Compare(DateTime.Now, t) >= 0 && DateTime.Compare(t2, DateTime.Now) >= 0)
		{
			result = GameMaintanceType.IsMaintain;
		}
		else if (this.m_MaintanceData.LoginBoxMsg_Tw != string.Empty && DateTime.Compare(DateTime.Now, t4) >= 0 && DateTime.Compare(t3, DateTime.Now) >= 0)
		{
			result = GameMaintanceType.HaveLoginInfo;
		}
		else
		{
			result = GameMaintanceType.None;
		}
		return result;
	}

	// Token: 0x0600249E RID: 9374 RVA: 0x00422590 File Offset: 0x00420790
	public GameMaintanceType NeedUpdateVession()
	{
		ushort num = (ushort)(this.LowVersion[0] << 8);
		ushort num2 = (ushort)((int)num | this.LowVersion[1]);
		ushort num3 = (ushort)(this.HiVersion[0] << 8);
		ushort num4 = (ushort)((int)num3 | this.HiVersion[1]);
		ushort num5 = (ushort)(GameConstants.Version[0] << 8);
		ushort num6 = num5 | GameConstants.Version[1];
		if (num6 >= num4)
		{
			return GameMaintanceType.None;
		}
		if (num6 >= num2)
		{
			return GameMaintanceType.ProposalUpdate;
		}
		return GameMaintanceType.ForciblyUpdate;
	}

	// Token: 0x0600249F RID: 9375 RVA: 0x00422608 File Offset: 0x00420808
	public bool IsGameMaintanceType(GameMaintanceType _GameMaintanceType)
	{
		bool result = false;
		DateTime t;
		if (this.MaintanceData.StartTime != string.Empty && this.MaintanceData.StartTime != "0")
		{
			DateTime dateTime = Convert.ToDateTime(this.MaintanceData.StartTime);
			DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, new TimeSpan(-5, 0, 0));
			t = dateTimeOffset.UtcDateTime.ToLocalTime();
		}
		else
		{
			t = default(DateTime);
		}
		DateTime t2;
		if (this.MaintanceData.EndTime != string.Empty && this.MaintanceData.EndTime != "0")
		{
			DateTime dateTime = Convert.ToDateTime(this.MaintanceData.EndTime);
			DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, new TimeSpan(-5, 0, 0));
			t2 = dateTimeOffset.UtcDateTime.ToLocalTime();
		}
		else
		{
			t2 = default(DateTime);
		}
		DateTime t3;
		if (this.MaintanceData.LoginBoxEndTime != string.Empty && this.MaintanceData.LoginBoxEndTime != "0")
		{
			DateTime dateTime = Convert.ToDateTime(this.MaintanceData.LoginBoxEndTime);
			DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, new TimeSpan(-5, 0, 0));
			t3 = dateTimeOffset.UtcDateTime.ToLocalTime();
		}
		else
		{
			t3 = default(DateTime);
		}
		DateTime t4;
		if (this.MaintanceData.LoginBoxStartTime != string.Empty && this.MaintanceData.LoginBoxStartTime != "0")
		{
			DateTime dateTime = Convert.ToDateTime(this.MaintanceData.LoginBoxStartTime);
			DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, new TimeSpan(-5, 0, 0));
			t4 = dateTimeOffset.UtcDateTime.ToLocalTime();
		}
		else
		{
			t4 = default(DateTime);
		}
		if (_GameMaintanceType == GameMaintanceType.IsMaintain)
		{
			if (this.m_MaintanceData.IsMaintain == "1" && DateTime.Compare(DateTime.Now, t) >= 0 && DateTime.Compare(t2, DateTime.Now) >= 0)
			{
				result = true;
			}
		}
		else if (_GameMaintanceType == GameMaintanceType.HaveLoginInfo && this.m_MaintanceData.LoginBoxMsg_Tw != string.Empty && DateTime.Compare(DateTime.Now, t4) >= 0 && DateTime.Compare(t3, DateTime.Now) >= 0)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x060024A0 RID: 9376 RVA: 0x004228B0 File Offset: 0x00420AB0
	public bool GetStarStatus()
	{
		return this.m_MaintanceData.StarStatus != null && !(this.m_MaintanceData.StarStatus == string.Empty) && this.m_MaintanceData.StarStatus == "1";
	}

	// Token: 0x060024A1 RID: 9377 RVA: 0x00422900 File Offset: 0x00420B00
	public bool GetTranslateStatus()
	{
		return this.m_MaintanceData.TranslateStatus != null && !(this.m_MaintanceData.TranslateStatus == string.Empty) && this.m_MaintanceData.TranslateStatus == "1";
	}

	// Token: 0x060024A2 RID: 9378 RVA: 0x00422950 File Offset: 0x00420B50
	public byte GetTranslateLanguageStringId(string str)
	{
		byte b = 0;
		while ((int)b < GameConstants.TranslateLanguage.Length)
		{
			if (str.Equals(GameConstants.TranslateLanguage[(int)b]))
			{
				return b + 1;
			}
			b += 1;
		}
		return 0;
	}

	// Token: 0x060024A3 RID: 9379 RVA: 0x00422990 File Offset: 0x00420B90
	public string GetLanguageStringID(byte idx)
	{
		if (idx == 0)
		{
			return DataManager.Instance.mStringTable.GetStringByID(9053u);
		}
		if (idx == 6)
		{
			return DataManager.Instance.mStringTable.GetStringByID(9075u);
		}
		if (idx == 42)
		{
			return DataManager.Instance.mStringTable.GetStringByID(9074u);
		}
		return DataManager.Instance.mStringTable.GetStringByID((uint)((ushort)(4651 + (int)idx)));
	}

	// Token: 0x060024A4 RID: 9380 RVA: 0x00422A08 File Offset: 0x00420C08
	public byte GetTranslateLanguageIdxByUseLanguage(byte UseLanguage)
	{
		byte result = 0;
		if ((int)UseLanguage < GameConstants.TranslateTragetLanguage.Length)
		{
			for (int i = 0; i < GameConstants.TranslateLanguage.Length; i++)
			{
				if (GameConstants.TranslateLanguage[i] == GameConstants.TranslateTragetLanguage[(int)UseLanguage])
				{
					result = (byte)(i + 1);
				}
			}
		}
		return result;
	}

	// Token: 0x060024A5 RID: 9381 RVA: 0x00422A5C File Offset: 0x00420C5C
	public byte GetRealNameSW()
	{
		if (this.m_MaintanceData.RealNameCheck == null)
		{
			return 0;
		}
		if (this.m_MaintanceData.RealNameCheck.Equals("0"))
		{
			return 0;
		}
		if (this.m_MaintanceData.RealNameCheck.Equals("1"))
		{
			return 1;
		}
		if (this.m_MaintanceData.RealNameCheck.Equals("2"))
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x060024A6 RID: 9382 RVA: 0x00422AD0 File Offset: 0x00420CD0
	public byte GetAddictedCheckNoticeSW()
	{
		if (this.m_MaintanceData.AddictedCheckNotice == null)
		{
			return 0;
		}
		if (this.m_MaintanceData.AddictedCheckNotice.Equals("1"))
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x060024A7 RID: 9383 RVA: 0x00422B04 File Offset: 0x00420D04
	public byte GetAddictedCheckLimitLoginSW()
	{
		if (this.m_MaintanceData.AddictedCheckLimitLogin == null)
		{
			return 0;
		}
		if (this.m_MaintanceData.AddictedCheckLimitLogin.Equals("1"))
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x060024A8 RID: 9384 RVA: 0x00422B38 File Offset: 0x00420D38
	public float GetMinorsDailySpendAmount()
	{
		float num = 0f;
		float result;
		try
		{
			bool flag = float.TryParse(this.m_MaintanceData.MinorsDailySpendAmount, out num);
			if (flag)
			{
				result = num;
			}
			else
			{
				result = 0f;
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("GetMinorsDailySpendAmount Exception =" + this.m_MaintanceData.MinorsDailySpendAmount);
			result = 0f;
		}
		return result;
	}

	// Token: 0x060024A9 RID: 9385 RVA: 0x00422BC4 File Offset: 0x00420DC4
	public string Encode(string source)
	{
		string result;
		try
		{
			string s = "abcdefgh";
			StringBuilder stringBuilder = new StringBuilder();
			using (DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider())
			{
				byte[] bytes = Encoding.ASCII.GetBytes(s);
				byte[] bytes2 = Encoding.ASCII.GetBytes(s);
				byte[] bytes3 = Encoding.UTF8.GetBytes(source);
				descryptoServiceProvider.Mode = CipherMode.CBC;
				descryptoServiceProvider.Key = bytes;
				descryptoServiceProvider.IV = bytes2;
				string s2 = string.Empty;
				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, descryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write))
					{
						cryptoStream.Write(bytes3, 0, bytes3.Length);
						cryptoStream.FlushFinalBlock();
						s2 = Convert.ToBase64String(memoryStream.ToArray());
					}
				}
				result = WWW.EscapeURL(s2);
			}
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
			result = source;
		}
		return result;
	}

	// Token: 0x060024AA RID: 9386 RVA: 0x00422D30 File Offset: 0x00420F30
	public void SetBindingNameByJSON(string pString)
	{
		try
		{
			SocialManager.Instance.BindingName = string.Empty;
			Dictionary<string, object> dictionary = Json.Deserialize(pString) as Dictionary<string, object>;
			if (dictionary != null)
			{
				if (dictionary.ContainsKey("name"))
				{
					SocialManager.Instance.BindingName = dictionary["name"].ToString();
				}
				if (SocialManager.Instance.BindingName.Equals("null"))
				{
					SocialManager.Instance.BindingName = string.Empty;
				}
			}
		}
		catch (Exception ex)
		{
			SocialManager.Instance.BindingName = string.Empty;
			Debug.Log(ex.StackTrace);
		}
	}

	// Token: 0x060024AB RID: 9387 RVA: 0x00422DF4 File Offset: 0x00420FF4
	public void SetBindingName(string pName)
	{
		try
		{
			SocialManager.Instance.BindingName = pName;
			if (SocialManager.Instance.BindingName.Equals("null"))
			{
				SocialManager.Instance.BindingName = string.Empty;
			}
		}
		catch (Exception ex)
		{
			SocialManager.Instance.BindingName = string.Empty;
			Debug.Log(ex.StackTrace);
		}
	}

	// Token: 0x04006EC5 RID: 28357
	private const int MaxTransString = 10;

	// Token: 0x04006EC6 RID: 28358
	private const int MaxTransStringLen = 1024;

	// Token: 0x04006EC7 RID: 28359
	private const int MaxTranslateBatchStringLen = 4100;

	// Token: 0x04006EC8 RID: 28360
	private const int MaxTransString_Mail = 5;

	// Token: 0x04006EC9 RID: 28361
	private const int MaxTransStringLen_Mail = 1100;

	// Token: 0x04006ECA RID: 28362
	private const int MaxTranslateBatchStringLen_Mail = 4500;

	// Token: 0x04006ECB RID: 28363
	private const int MaxTransString_Diplomatic = 20;

	// Token: 0x04006ECC RID: 28364
	private const int MaxTransStringLen_Diplomatic = 1024;

	// Token: 0x04006ECD RID: 28365
	private const int MaxTranslateBatchStringLen_Diplomatic = 8200;

	// Token: 0x04006ECE RID: 28366
	private const int MaxTransStringLen_KA = 1400;

	// Token: 0x04006ECF RID: 28367
	private const int MaxTransStringLen_AA = 1400;

	// Token: 0x04006ED0 RID: 28368
	private static IGGGameSDK instance;

	// Token: 0x04006ED1 RID: 28369
	private string[] CallBackWords;

	// Token: 0x04006ED2 RID: 28370
	private IGGLoginState m_LoginState;

	// Token: 0x04006ED3 RID: 28371
	private bool bNeedShowCheckBox;

	// Token: 0x04006ED4 RID: 28372
	private bool bNeedUpdateAccountUI;

	// Token: 0x04006ED5 RID: 28373
	private bool bNeedOpenAnnouncement;

	// Token: 0x04006ED6 RID: 28374
	private bool bNeedSendAccountBind;

	// Token: 0x04006ED7 RID: 28375
	private bool bFacebookBindSuccessful;

	// Token: 0x04006ED8 RID: 28376
	private bool bWeChatBindSuccessful;

	// Token: 0x04006ED9 RID: 28377
	private bool bBindingNameSuccessful;

	// Token: 0x04006EDA RID: 28378
	private bool bNeedUpdateIOSAccountUI;

	// Token: 0x04006EDB RID: 28379
	private bool bNeedShowSwitchCheckBox;

	// Token: 0x04006EDC RID: 28380
	private bool bNeedShowBindAccountCheckBox;

	// Token: 0x04006EDD RID: 28381
	private bool bGuestLoginFailedCallBackNeedUpdate;

	// Token: 0x04006EDE RID: 28382
	private bool bAmazonBindSuccessful;

	// Token: 0x04006EDF RID: 28383
	private bool bIGGIdIsReady;

	// Token: 0x04006EE0 RID: 28384
	private bool bRateSucceeded;

	// Token: 0x04006EE1 RID: 28385
	private byte bBuyPackageSucceed;

	// Token: 0x04006EE2 RID: 28386
	private byte bSprinklesSucceed;

	// Token: 0x04006EE3 RID: 28387
	private int PurchaseLimitType;

	// Token: 0x04006EE4 RID: 28388
	private PayErrorCode payErrorCode;

	// Token: 0x04006EE5 RID: 28389
	private bool bPayErrorNoCode;

	// Token: 0x04006EE6 RID: 28390
	private IGGLoginCode iggLoginCode;

	// Token: 0x04006EE7 RID: 28391
	private bool bNeedUpdateRealNameState;

	// Token: 0x04006EE8 RID: 28392
	public bool bBindingGoogle;

	// Token: 0x04006EE9 RID: 28393
	public string m_IGGID = string.Empty;

	// Token: 0x04006EEA RID: 28394
	public string m_SessionKey = string.Empty;

	// Token: 0x04006EEB RID: 28395
	private string m_SaveBindGoogleAccount = string.Empty;

	// Token: 0x04006EEC RID: 28396
	public IGGLoginType m_IGGLoginType;

	// Token: 0x04006EED RID: 28397
	public string m_PlatformLoginName = string.Empty;

	// Token: 0x04006EEE RID: 28398
	public bool bUsingTranslate;

	// Token: 0x04006EEF RID: 28399
	public string m_BindGoogleAccount = string.Empty;

	// Token: 0x04006EF0 RID: 28400
	public List<string> m_MailList;

	// Token: 0x04006EF1 RID: 28401
	public bool bPaymentReady;

	// Token: 0x04006EF2 RID: 28402
	private Dictionary<int, IGGGameItem> m_IGGProductItem = new Dictionary<int, IGGGameItem>();

	// Token: 0x04006EF3 RID: 28403
	private bool bGameMaintanceDataReady;

	// Token: 0x04006EF4 RID: 28404
	private GameMaintanceData m_MaintanceData;

	// Token: 0x04006EF5 RID: 28405
	private bool bNotConnect;

	// Token: 0x04006EF6 RID: 28406
	public int[] HiVersion;

	// Token: 0x04006EF7 RID: 28407
	public int[] LowVersion;

	// Token: 0x04006EF8 RID: 28408
	public string MinVersion;

	// Token: 0x04006EF9 RID: 28409
	public CString[] TranslateString = new CString[10];

	// Token: 0x04006EFA RID: 28410
	private CString TranslateBatchString;

	// Token: 0x04006EFB RID: 28411
	public CString[] TranslateString_Mail = new CString[5];

	// Token: 0x04006EFC RID: 28412
	private CString TranslateBatchString_Mail;

	// Token: 0x04006EFD RID: 28413
	public CString[] TranslateString_Diplomatic = new CString[20];

	// Token: 0x04006EFE RID: 28414
	private CString TranslateBatchString_Diplomatic;

	// Token: 0x04006EFF RID: 28415
	public CString TranslateStringOut_KA;

	// Token: 0x04006F00 RID: 28416
	public CString TranslateStringOut_AA_Info;

	// Token: 0x04006F01 RID: 28417
	public CString TranslateStringOut_AA_Public;

	// Token: 0x04006F02 RID: 28418
	private byte _UserLanguageMapToTranslateLanguageIdx;

	// Token: 0x04006F03 RID: 28419
	private string m_SelectAccount = string.Empty;

	// Token: 0x04006F04 RID: 28420
	public bool bShowAccountState;

	// Token: 0x04006F05 RID: 28421
	public bool bOpenTermsService;

	// Token: 0x04006F06 RID: 28422
	public RealNameState m_RealNameState;

	// Token: 0x04006F07 RID: 28423
	public AgeState m_AgeState;

	// Token: 0x04006F08 RID: 28424
	private float m_RealNameTickTime;
}
