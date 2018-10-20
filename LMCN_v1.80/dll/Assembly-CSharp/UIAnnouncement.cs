using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004D0 RID: 1232
public class UIAnnouncement : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x060018D2 RID: 6354 RVA: 0x00299A9C File Offset: 0x00297C9C
	public override void OnOpen(int arg1, int arg2)
	{
		this.bReConfig = false;
		this.SDK = IGGGameSDK.Instance;
		this.GM = GUIManager.Instance;
		this.DM = DataManager.Instance;
		this.m_Str = new CString[this.MAX_STR];
		this.SpawnStr();
		this.InitUI();
		this.UpdateUI(0, 0);
	}

	// Token: 0x060018D3 RID: 6355 RVA: 0x00299AF8 File Offset: 0x00297CF8
	public override void OnClose()
	{
		this.DeSpawn();
	}

	// Token: 0x060018D4 RID: 6356 RVA: 0x00299B00 File Offset: 0x00297D00
	public override void UpdateUI(int arg1, int arg2)
	{
		if (this.SDK.GameMaintanceDataReady)
		{
			switch (arg1)
			{
			case 0:
				if (this.m_MaintanceType == GameMaintanceType.IsMaintain)
				{
					if (this.SDK.IsGameMaintanceType(GameMaintanceType.IsMaintain))
					{
						this.m_MaintanceType = GameMaintanceType.IsMaintain;
					}
					else
					{
						this.bReConfig = true;
						this.SDK.CanLogIn();
					}
				}
				else
				{
					this.m_MaintanceType = this.SDK.GetGameMaintanceType();
				}
				break;
			case 1:
				this.m_MaintanceType = GameMaintanceType.IsMaintain;
				break;
			case 2:
				this.m_MaintanceType = GameMaintanceType.HaveLoginInfo;
				break;
			}
			this.UpdateBtnText(this.m_MaintanceType);
			this.SetMaintainMsg(this.m_MaintanceType);
			this.SetMaintainTime(this.m_MaintanceType);
		}
	}

	// Token: 0x060018D5 RID: 6357 RVA: 0x00299BC8 File Offset: 0x00297DC8
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x060018D6 RID: 6358 RVA: 0x00299BF4 File Offset: 0x00297DF4
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (arg1 == 0 && bOK)
		{
			Application.Quit();
		}
	}

	// Token: 0x060018D7 RID: 6359 RVA: 0x00299C08 File Offset: 0x00297E08
	public override bool OnBackButtonClick()
	{
		GUIManager.Instance.OpenOKCancelBox(this, string.Empty, this.DM.mStringTable.GetStringByID(242u), 0, 0, null, null);
		return false;
	}

	// Token: 0x060018D8 RID: 6360 RVA: 0x00299C40 File Offset: 0x00297E40
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID != 0)
		{
			if (btnID != 1)
			{
				if (btnID == 999)
				{
					this.OnBackButtonClick();
				}
			}
			else if (this.m_MaintanceType == GameMaintanceType.IsMaintain)
			{
				if (IGGGameSDK.Instance.GameMaintanceDataReady)
				{
					IGGGameSDK.Instance.GameMaintanceDataReady = false;
					IGGSDKPlugin.LoadGameConfig();
				}
			}
			else if (this.m_MaintanceType == GameMaintanceType.HaveLoginInfo)
			{
				IGGGameSDK.Instance.CanLogIn();
			}
			else if (this.m_MaintanceType == GameMaintanceType.ForciblyUpdate)
			{
				if (UpdateController.CheckNewApk(IGGGameSDK.Instance.MaintanceData.URL))
				{
					GUIManager.Instance.CloseMenu(EGUIWindow.UI_Announcement);
				}
			}
			else if (this.m_MaintanceType == GameMaintanceType.ProposalUpdate && UpdateController.CheckNewApk(IGGGameSDK.Instance.MaintanceData.URL))
			{
				GUIManager.Instance.CloseMenu(EGUIWindow.UI_Announcement);
			}
		}
		else if (this.m_MaintanceType == GameMaintanceType.IsMaintain)
		{
			if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
			{
				IGGSDKPlugin.OpenFbByUrl(GameConstants.Url176);
			}
			else
			{
				this.OpneURLByLanguage(GameConstants.GlobalEditionFUrl);
			}
		}
		else if (this.m_MaintanceType == GameMaintanceType.ForciblyUpdate)
		{
			this.OnBackButtonClick();
		}
		else if (this.m_MaintanceType == GameMaintanceType.ProposalUpdate)
		{
			if (this.SDK.IsGameMaintanceType(GameMaintanceType.IsMaintain))
			{
				this.UpdateUI(1, 0);
			}
			else if (this.SDK.IsGameMaintanceType(GameMaintanceType.HaveLoginInfo))
			{
				this.UpdateUI(2, 0);
			}
			else
			{
				this.SDK.CanLogIn();
			}
		}
	}

	// Token: 0x060018D9 RID: 6361 RVA: 0x00299DE8 File Offset: 0x00297FE8
	private void OpenThirdPartyUpadteURL()
	{
		int num = Mathf.Clamp((int)DataManager.Instance.UserLanguage, 1, GameConstants.GlobalEditionGameID.Length - 1);
		IGGSDKPlugin.OpenFbByUrl(GameConstants.ThirdPartyUpadteURL + GameConstants.GlobalEditionGameID[num]);
	}

	// Token: 0x060018DA RID: 6362 RVA: 0x00299E28 File Offset: 0x00298028
	private void OpneURLByLanguage(string url)
	{
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			IGGSDKPlugin.OpenFbByUrl(GameConstants.CommunityCN);
		}
		else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn)
		{
			IGGSDKPlugin.OpenFbByUrl(GameConstants.CommunityJP);
		}
		else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Kor)
		{
			IGGSDKPlugin.OpenFbByUrl(GameConstants.CommunityKR);
		}
		else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Rus)
		{
			IGGSDKPlugin.OpenFbByUrl(GameConstants.CommunityRU);
		}
		else
		{
			IGGSDKPlugin.OpenFbByUrl(url);
		}
	}

	// Token: 0x060018DB RID: 6363 RVA: 0x00299EBC File Offset: 0x002980BC
	private void Update()
	{
		this.tickTime += Time.deltaTime;
		if (this.tickTime >= 1f)
		{
			if (this.CheckNeedCountDown())
			{
				this.DateDiff(this.m_EndTime, DateTime.Now);
			}
			this.tickTime = 0f;
		}
	}

	// Token: 0x060018DC RID: 6364 RVA: 0x00299F14 File Offset: 0x00298114
	private void InitUI()
	{
		this.m_SpArry = base.transform.GetComponent<UISpritesArray>();
		this.m_TitleText = base.transform.GetChild(1).GetComponent<UIText>();
		this.m_TitleText.font = this.GM.GetTTFFont();
		this.m_Content = base.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>();
		this.m_ScrollViewRect = base.transform.GetChild(2).GetComponent<RectTransform>();
		this.m_Msg = base.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.m_Msg.font = this.GM.GetTTFFont();
		this.m_TimeText = base.transform.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.m_TimeText.font = this.GM.GetTTFFont();
		this.m_BtnRect[0] = (RectTransform)base.transform.GetChild(4);
		this.m_Btn[0] = base.transform.GetChild(4).GetComponent<UIButton>();
		this.m_Btn[0].m_Handler = this;
		this.m_Btn[0].m_BtnID1 = 0;
		this.m_BtnFBImage = base.transform.GetChild(4).GetChild(0).GetComponent<Image>();
		if (GUIManager.Instance.IsArabic)
		{
			base.transform.GetChild(4).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			this.m_BtnFBImage.sprite = this.m_SpArry.GetSprite(4);
		}
		else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn)
		{
			this.m_BtnFBImage.sprite = this.m_SpArry.GetSprite(5);
		}
		else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Kor)
		{
			this.m_BtnFBImage.sprite = this.m_SpArry.GetSprite(6);
		}
		else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Rus)
		{
			this.m_BtnFBImage.sprite = this.m_SpArry.GetSprite(7);
		}
		this.m_BtnText[0] = base.transform.GetChild(4).GetChild(1).GetComponent<UIText>();
		this.m_BtnText[0].font = this.GM.GetTTFFont();
		this.m_BtnRect[1] = (RectTransform)base.transform.GetChild(5);
		this.m_Btn[1] = base.transform.GetChild(5).GetComponent<UIButton>();
		this.m_Btn[1].m_Handler = this;
		this.m_Btn[1].m_BtnID1 = 1;
		this.m_BtnText[1] = base.transform.GetChild(5).GetChild(0).GetComponent<UIText>();
		this.m_BtnText[1].font = this.GM.GetTTFFont();
		this.m_Exit = base.transform.GetChild(6).GetComponent<UIButton>();
		this.m_Exit.m_BtnID1 = 999;
		this.m_Exit.m_Handler = this;
	}

	// Token: 0x060018DD RID: 6365 RVA: 0x0029A234 File Offset: 0x00298434
	private void UpdateBtnText(GameMaintanceType type)
	{
		this.m_BtnText[0].gameObject.SetActive(true);
		this.m_Btn[0].gameObject.SetActive(true);
		this.m_Btn[0].image.sprite = this.m_SpArry.GetSprite(0);
		this.m_BtnText[0].rectTransform.anchoredPosition = new Vector2(34.8f, 0f);
		this.m_BtnFBImage.enabled = true;
		this.m_Btn[1].image.sprite = this.m_SpArry.GetSprite(0);
		this.m_BtnRect[1].anchoredPosition = new Vector2(151.5f, -219.5f);
		if (type == GameMaintanceType.IsMaintain)
		{
			this.m_TitleText.text = DataManager.Instance.mStringTable.GetStringByID(8425u);
			if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
			{
				this.m_BtnText[0].text = DataManager.Instance.mStringTable.GetStringByID(9578u);
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn)
			{
				this.m_BtnText[0].text = DataManager.Instance.mStringTable.GetStringByID(9579u);
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Kor)
			{
				this.m_BtnText[0].text = DataManager.Instance.mStringTable.GetStringByID(9577u);
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Rus)
			{
				this.m_BtnText[0].text = DataManager.Instance.mStringTable.GetStringByID(9576u);
			}
			else
			{
				this.m_BtnText[0].text = DataManager.Instance.mStringTable.GetStringByID(8427u);
			}
			this.m_Btn[0].image.sprite = this.m_SpArry.GetSprite(0);
			this.m_BtnFBImage.enabled = true;
			this.m_BtnText[1].text = DataManager.Instance.mStringTable.GetStringByID(8470u);
			this.m_BtnText[1].rectTransform.anchoredPosition = new Vector2(0f, 0f);
			this.m_Btn[1].image.sprite = this.m_SpArry.GetSprite(0);
		}
		else if (type == GameMaintanceType.HaveLoginInfo)
		{
			this.m_TitleText.text = DataManager.Instance.mStringTable.GetStringByID(8420u);
			this.m_Btn[0].gameObject.SetActive(false);
			this.m_BtnText[1].text = DataManager.Instance.mStringTable.GetStringByID(8428u);
			this.m_Btn[1].image.sprite = this.m_SpArry.GetSprite(1);
			this.m_BtnRect[1].anchoredPosition = new Vector2(0f, -219.5f);
		}
		else if (type == GameMaintanceType.ProposalUpdate)
		{
			this.m_TitleText.text = DataManager.Instance.mStringTable.GetStringByID(8421u);
			this.m_BtnText[0].text = DataManager.Instance.mStringTable.GetStringByID(8423u);
			this.m_BtnText[0].rectTransform.anchoredPosition = new Vector2(0f, 0f);
			this.m_Btn[0].image.sprite = this.m_SpArry.GetSprite(0);
			this.m_BtnFBImage.enabled = false;
			this.m_BtnText[1].text = DataManager.Instance.mStringTable.GetStringByID(8422u);
			this.m_BtnText[1].rectTransform.anchoredPosition = new Vector2(0f, 0f);
			this.m_Btn[1].image.sprite = this.m_SpArry.GetSprite(1);
		}
		else if (type == GameMaintanceType.ForciblyUpdate)
		{
			this.m_TitleText.text = DataManager.Instance.mStringTable.GetStringByID(8421u);
			this.m_BtnText[0].text = DataManager.Instance.mStringTable.GetStringByID(8424u);
			this.m_BtnText[0].rectTransform.anchoredPosition = new Vector2(0f, 0f);
			this.m_Btn[0].image.sprite = this.m_SpArry.GetSprite(0);
			this.m_BtnFBImage.enabled = false;
			this.m_BtnText[1].text = DataManager.Instance.mStringTable.GetStringByID(8422u);
			this.m_BtnText[1].rectTransform.anchoredPosition = new Vector2(0f, 0f);
			this.m_Btn[1].image.sprite = this.m_SpArry.GetSprite(1);
		}
	}

	// Token: 0x060018DE RID: 6366 RVA: 0x0029A720 File Offset: 0x00298920
	private void SpawnStr()
	{
		for (int i = 0; i < this.MAX_STR; i++)
		{
			this.m_Str[i] = StringManager.Instance.SpawnString(200);
		}
	}

	// Token: 0x060018DF RID: 6367 RVA: 0x0029A75C File Offset: 0x0029895C
	private void DeSpawn()
	{
		for (int i = 0; i < this.MAX_STR; i++)
		{
			if (this.m_Str[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.m_Str[i]);
				this.m_Str[i] = null;
			}
		}
	}

	// Token: 0x060018E0 RID: 6368 RVA: 0x0029A7AC File Offset: 0x002989AC
	private void SetMaintainMsg(GameMaintanceType type)
	{
		this.m_Str[0].ClearString();
		if (type == GameMaintanceType.IsMaintain)
		{
			DateTime dateTime = Convert.ToDateTime(this.SDK.MaintanceData.StartTime);
			DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, new TimeSpan(-5, 0, 0));
			string text = ActivityManager.Instance.TransToLocalTime(this.GetMaintanceDataMessage(DataManager.Instance.UserLanguage));
			this.m_Msg.text = text;
		}
		else if (type == GameMaintanceType.HaveLoginInfo)
		{
			string text2 = ActivityManager.Instance.TransToLocalTime(this.GetLoginBoxMsg(DataManager.Instance.UserLanguage));
			this.m_Msg.text = text2;
		}
		else if (type == GameMaintanceType.ProposalUpdate)
		{
			string text3 = ActivityManager.Instance.TransToLocalTime(this.GetUpdateInfo(DataManager.Instance.UserLanguage));
			this.m_Msg.text = text3;
		}
		else if (type == GameMaintanceType.ForciblyUpdate)
		{
			string text4 = ActivityManager.Instance.TransToLocalTime(this.GetUpdateInfo(DataManager.Instance.UserLanguage));
			this.m_Msg.text = text4;
		}
		this.m_Msg.rectTransform.sizeDelta = new Vector2(564f, this.m_Msg.preferredHeight);
		this.m_Content.sizeDelta = new Vector2(564f, this.m_Msg.preferredHeight);
		this.UpdateScrollRect();
	}

	// Token: 0x060018E1 RID: 6369 RVA: 0x0029A908 File Offset: 0x00298B08
	private void SetMaintainTime(GameMaintanceType type)
	{
		if (type == GameMaintanceType.IsMaintain)
		{
			DateTime dateTime = Convert.ToDateTime(this.SDK.MaintanceData.StartTime);
			DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime, new TimeSpan(-5, 0, 0));
			this.m_BeginTime = dateTimeOffset.UtcDateTime.ToLocalTime();
			dateTime = Convert.ToDateTime(this.SDK.MaintanceData.EndTime);
			dateTimeOffset = new DateTimeOffset(dateTime, new TimeSpan(-5, 0, 0));
			this.m_EndTime = dateTimeOffset.UtcDateTime.ToLocalTime();
		}
	}

	// Token: 0x060018E2 RID: 6370 RVA: 0x0029A99C File Offset: 0x00298B9C
	private bool CheckNeedCountDown()
	{
		bool result = false;
		bool flag = false;
		if (this.m_MaintanceType == GameMaintanceType.IsMaintain && DateTime.Compare(this.m_EndTime, DateTime.Now) >= 0)
		{
			result = true;
			flag = true;
		}
		if (base.transform.GetChild(3).gameObject.activeSelf != flag)
		{
			base.transform.GetChild(3).gameObject.SetActive(flag);
		}
		if (!this.bReConfig && this.m_MaintanceType == GameMaintanceType.IsMaintain && !flag && IGGGameSDK.Instance.GameMaintanceDataReady)
		{
			this.bReConfig = true;
			IGGGameSDK.Instance.GameMaintanceDataReady = false;
			IGGSDKPlugin.LoadGameConfig();
		}
		return result;
	}

	// Token: 0x060018E3 RID: 6371 RVA: 0x0029AA4C File Offset: 0x00298C4C
	private void DateDiff(DateTime DateTime1, DateTime DateTime2)
	{
		this.m_Str[1].ClearString();
		TimeSpan timeSpan = new TimeSpan(DateTime1.Ticks);
		TimeSpan ts = new TimeSpan(DateTime2.Ticks);
		TimeSpan timeSpan2 = timeSpan.Subtract(ts).Duration();
		if (timeSpan2.Days >= 1)
		{
			this.m_Str[1].IntToFormat((long)timeSpan2.Days, 1, false);
			this.m_Str[1].IntToFormat((long)timeSpan2.Hours, 2, true);
			this.m_Str[1].IntToFormat((long)timeSpan2.Minutes, 2, true);
			this.m_Str[1].IntToFormat((long)timeSpan2.Seconds, 2, true);
			this.m_Str[1].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8456u));
		}
		else
		{
			this.m_Str[1].IntToFormat((long)timeSpan2.Hours, 2, true);
			this.m_Str[1].IntToFormat((long)timeSpan2.Minutes, 2, true);
			this.m_Str[1].IntToFormat((long)timeSpan2.Seconds, 2, true);
			this.m_Str[1].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8426u));
		}
		this.m_TimeText.text = this.m_Str[1].ToString();
		this.m_TimeText.SetAllDirty();
		this.m_TimeText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x060018E4 RID: 6372 RVA: 0x0029ABC4 File Offset: 0x00298DC4
	private void UpdateScrollRect()
	{
		Vector2 sizeDelta = this.m_ScrollViewRect.sizeDelta;
		Vector2 anchoredPosition = this.m_ScrollViewRect.anchoredPosition;
		if (this.m_Msg.text.Length > 1500)
		{
			this.m_Msg.GetComponent<Shadow>().enabled = false;
			if (this.m_Msg.text.Length > 3000)
			{
				this.m_Msg.GetComponent<Outline>().enabled = false;
			}
		}
		if (this.m_MaintanceType != GameMaintanceType.IsMaintain)
		{
			this.m_ScrollViewRect.anchoredPosition = new Vector2(anchoredPosition.x, -120f);
			this.m_ScrollViewRect.sizeDelta = new Vector2(sizeDelta.x, 365f);
		}
		else
		{
			this.m_ScrollViewRect.anchoredPosition = new Vector2(anchoredPosition.x, -103f);
			this.m_ScrollViewRect.sizeDelta = new Vector2(sizeDelta.x, 330f);
		}
	}

	// Token: 0x060018E5 RID: 6373 RVA: 0x0029ACC0 File Offset: 0x00298EC0
	public string GetMaintanceDataMessage(GameLanguage language)
	{
		switch (language)
		{
		case GameLanguage.GL_Eng:
			return this.SDK.MaintanceData.Message_Eg;
		case GameLanguage.GL_Cht:
			return this.SDK.MaintanceData.Message_Tw;
		case GameLanguage.GL_Fre:
			return this.SDK.MaintanceData.Message_FR;
		case GameLanguage.GL_Gem:
			return this.SDK.MaintanceData.Message_DE;
		case GameLanguage.GL_Spa:
			return this.SDK.MaintanceData.Message_ES;
		case GameLanguage.GL_Rus:
			return this.SDK.MaintanceData.Message_RU;
		case GameLanguage.GL_Chs:
			return (!(this.SDK.MaintanceData.Message_CN.Trim() == string.Empty)) ? this.SDK.MaintanceData.Message_CN : this.SDK.MaintanceData.Message_Tw;
		case GameLanguage.GL_Idn:
			return this.SDK.MaintanceData.Message_ID;
		case GameLanguage.GL_Vet:
			return this.SDK.MaintanceData.Message_VI;
		case GameLanguage.GL_Tur:
			return this.SDK.MaintanceData.Message_TR;
		case GameLanguage.GL_Tha:
			return this.SDK.MaintanceData.Message_TH;
		case GameLanguage.GL_Ita:
			return this.SDK.MaintanceData.Message_IT;
		case GameLanguage.GL_Pot:
			return this.SDK.MaintanceData.Message_PT;
		case GameLanguage.GL_Kor:
			return this.SDK.MaintanceData.Message_KO;
		case GameLanguage.GL_Jpn:
			return this.SDK.MaintanceData.Message_JP;
		case GameLanguage.GL_Ukr:
			return this.SDK.MaintanceData.Message_UA;
		case GameLanguage.GL_Mys:
			return this.SDK.MaintanceData.Message_MY;
		case GameLanguage.GL_Arb:
			return this.SDK.MaintanceData.Message_ARB;
		default:
			return this.SDK.MaintanceData.Message_Eg;
		}
	}

	// Token: 0x060018E6 RID: 6374 RVA: 0x0029AEF0 File Offset: 0x002990F0
	public string GetLoginBoxMsg(GameLanguage language)
	{
		switch (language)
		{
		case GameLanguage.GL_Eng:
			return this.SDK.MaintanceData.LoginBoxMsg_Eg;
		case GameLanguage.GL_Cht:
			return this.SDK.MaintanceData.LoginBoxMsg_Tw;
		case GameLanguage.GL_Fre:
			return this.SDK.MaintanceData.LoginBoxMsg_FR;
		case GameLanguage.GL_Gem:
			return this.SDK.MaintanceData.LoginBoxMsg_DE;
		case GameLanguage.GL_Spa:
			return this.SDK.MaintanceData.LoginBoxMsg_ES;
		case GameLanguage.GL_Rus:
			return this.SDK.MaintanceData.LoginBoxMsg_RU;
		case GameLanguage.GL_Chs:
			return (!(this.SDK.MaintanceData.LoginBoxMsg_CN.Trim() == string.Empty)) ? this.SDK.MaintanceData.LoginBoxMsg_CN : this.SDK.MaintanceData.LoginBoxMsg_Tw;
		case GameLanguage.GL_Idn:
			return this.SDK.MaintanceData.LoginBoxMsg_ID;
		case GameLanguage.GL_Vet:
			return this.SDK.MaintanceData.LoginBoxMsg_VI;
		case GameLanguage.GL_Tur:
			return this.SDK.MaintanceData.LoginBoxMsg_TR;
		case GameLanguage.GL_Tha:
			return this.SDK.MaintanceData.LoginBoxMsg_TH;
		case GameLanguage.GL_Ita:
			return this.SDK.MaintanceData.LoginBoxMsg_IT;
		case GameLanguage.GL_Pot:
			return this.SDK.MaintanceData.LoginBoxMsg_PT;
		case GameLanguage.GL_Kor:
			return this.SDK.MaintanceData.LoginBoxMsg_KO;
		case GameLanguage.GL_Jpn:
			return this.SDK.MaintanceData.LoginBoxMsg_JP;
		case GameLanguage.GL_Ukr:
			return this.SDK.MaintanceData.LoginBoxMsg_UA;
		case GameLanguage.GL_Mys:
			return this.SDK.MaintanceData.LoginBoxMsg_MY;
		case GameLanguage.GL_Arb:
			return this.SDK.MaintanceData.LoginBoxMsg_ARB;
		default:
			return this.SDK.MaintanceData.LoginBoxMsg_Eg;
		}
	}

	// Token: 0x060018E7 RID: 6375 RVA: 0x0029B120 File Offset: 0x00299320
	public string GetUpdateInfo(GameLanguage language)
	{
		switch (language)
		{
		case GameLanguage.GL_Eng:
			return this.SDK.MaintanceData.UpdateInfo_Eg;
		case GameLanguage.GL_Cht:
			return this.SDK.MaintanceData.UpdateInfo_Tw;
		case GameLanguage.GL_Fre:
			return this.SDK.MaintanceData.UpdateInfo_FR;
		case GameLanguage.GL_Gem:
			return this.SDK.MaintanceData.UpdateInfo_DE;
		case GameLanguage.GL_Spa:
			return this.SDK.MaintanceData.UpdateInfo_ES;
		case GameLanguage.GL_Rus:
			return this.SDK.MaintanceData.UpdateInfo_RU;
		case GameLanguage.GL_Chs:
			return (!(this.SDK.MaintanceData.UpdateInfo_CN.Trim() == string.Empty)) ? this.SDK.MaintanceData.UpdateInfo_CN : this.SDK.MaintanceData.UpdateInfo_Tw;
		case GameLanguage.GL_Idn:
			return this.SDK.MaintanceData.UpdateInfo_ID;
		case GameLanguage.GL_Vet:
			return this.SDK.MaintanceData.UpdateInfo_VI;
		case GameLanguage.GL_Tur:
			return this.SDK.MaintanceData.UpdateInfo_TR;
		case GameLanguage.GL_Tha:
			return this.SDK.MaintanceData.UpdateInfo_TH;
		case GameLanguage.GL_Ita:
			return this.SDK.MaintanceData.UpdateInfo_IT;
		case GameLanguage.GL_Pot:
			return this.SDK.MaintanceData.UpdateInfo_PT;
		case GameLanguage.GL_Kor:
			return this.SDK.MaintanceData.UpdateInfo_KO;
		case GameLanguage.GL_Jpn:
			return this.SDK.MaintanceData.UpdateInfo_JP;
		case GameLanguage.GL_Ukr:
			return this.SDK.MaintanceData.UpdateInfo_UA;
		case GameLanguage.GL_Mys:
			return this.SDK.MaintanceData.UpdateInfo_MY;
		case GameLanguage.GL_Arb:
			return this.SDK.MaintanceData.UpdateInfo_ARB;
		default:
			return this.SDK.MaintanceData.UpdateInfo_Eg;
		}
	}

	// Token: 0x060018E8 RID: 6376 RVA: 0x0029B350 File Offset: 0x00299550
	public void Refresh_FontTexture()
	{
		if (this.m_TitleText != null && this.m_TitleText.enabled)
		{
			this.m_TitleText.enabled = false;
			this.m_TitleText.enabled = true;
		}
		if (this.m_Msg != null && this.m_Msg.enabled)
		{
			this.m_Msg.enabled = false;
			this.m_Msg.enabled = true;
		}
		if (this.m_TimeText != null && this.m_TimeText.enabled)
		{
			this.m_TimeText.enabled = false;
			this.m_TimeText.enabled = true;
		}
		if (this.m_BtnText != null)
		{
			for (int i = 0; i < this.m_BtnText.Length; i++)
			{
				if (this.m_BtnText[i] != null && this.m_BtnText[i].enabled)
				{
					this.m_BtnText[i].enabled = false;
					this.m_BtnText[i].enabled = true;
				}
			}
		}
	}

	// Token: 0x04004945 RID: 18757
	private IGGGameSDK SDK;

	// Token: 0x04004946 RID: 18758
	private GUIManager GM;

	// Token: 0x04004947 RID: 18759
	private DataManager DM;

	// Token: 0x04004948 RID: 18760
	private CString[] m_Str;

	// Token: 0x04004949 RID: 18761
	private int MAX_STR = 2;

	// Token: 0x0400494A RID: 18762
	private DateTime m_BeginTime;

	// Token: 0x0400494B RID: 18763
	private DateTime m_EndTime;

	// Token: 0x0400494C RID: 18764
	private UIText m_TitleText;

	// Token: 0x0400494D RID: 18765
	private RectTransform m_ScrollViewRect;

	// Token: 0x0400494E RID: 18766
	private UIText m_Msg;

	// Token: 0x0400494F RID: 18767
	private RectTransform m_Content;

	// Token: 0x04004950 RID: 18768
	private UIText m_TimeText;

	// Token: 0x04004951 RID: 18769
	private float tickTime = 1f;

	// Token: 0x04004952 RID: 18770
	private UISpritesArray m_SpArry;

	// Token: 0x04004953 RID: 18771
	private Image m_BtnFBImage;

	// Token: 0x04004954 RID: 18772
	private UIButton m_Exit;

	// Token: 0x04004955 RID: 18773
	private UIButton[] m_Btn = new UIButton[2];

	// Token: 0x04004956 RID: 18774
	private RectTransform[] m_BtnRect = new RectTransform[2];

	// Token: 0x04004957 RID: 18775
	private UIText[] m_BtnText = new UIText[2];

	// Token: 0x04004958 RID: 18776
	private GameMaintanceType m_MaintanceType;

	// Token: 0x04004959 RID: 18777
	private bool bReConfig;
}
