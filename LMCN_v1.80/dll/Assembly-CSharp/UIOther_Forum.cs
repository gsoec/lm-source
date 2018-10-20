using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000446 RID: 1094
public class UIOther_Forum : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x060015F5 RID: 5621 RVA: 0x00256CCC File Offset: 0x00254ECC
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.mType = arg1;
		Transform child = this.GameT.GetChild(0).GetChild(0).GetChild(0);
		this.textTitle = child.GetComponent<UIText>();
		this.textTitle.font = this.TTFont;
		this.P1_T = this.GameT.GetChild(1);
		this.P2_T = this.GameT.GetChild(2);
		for (int i = 0; i < 5; i++)
		{
			this.btn_Function_P1[i] = this.P1_T.GetChild(i).GetComponent<UIButton>();
			this.btn_Function_P1[i].m_Handler = this;
			this.btn_Function_P1[i].m_EffectType = e_EffectType.e_Scale;
			this.btn_Function_P1[i].transition = Selectable.Transition.None;
			this.Img_P1Icon[i] = this.P1_T.GetChild(i).GetChild(0).GetComponent<Image>();
			this.Img_P1Icon[i].SetNativeSize();
			this.text_btn_P1[i] = this.P1_T.GetChild(i).GetChild(1).GetComponent<UIText>();
			this.text_btn_P1[i].font = this.TTFont;
		}
		this.btn_Function_P1[0].m_BtnID1 = 2;
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			this.btn_Function_P1[1].m_BtnID1 = 22;
			this.Img_P1Icon[1].sprite = this.SArray.m_Sprites[7];
			this.Img_P1Icon[1].SetNativeSize();
			this.text_btn_P1[1].text = this.DM.mStringTable.GetStringByID(9578u);
			this.btn_Function_P1[1].gameObject.SetActive(true);
		}
		for (int j = 0; j < 5; j++)
		{
			this.btn_Function_P2[j] = this.P2_T.GetChild(j).GetComponent<UIButton>();
			this.btn_Function_P2[j].m_Handler = this;
			this.btn_Function_P2[j].m_BtnID1 = 3 + j;
			this.btn_Function_P2[j].m_EffectType = e_EffectType.e_Scale;
			this.btn_Function_P2[j].transition = Selectable.Transition.None;
			this.text_btn_P2[j] = this.P2_T.GetChild(j).GetChild(1).GetComponent<UIText>();
			this.text_btn_P2[j].font = this.TTFont;
			if (j == 2 && this.GUIM.IsArabic)
			{
				this.tmpImg = this.P2_T.GetChild(j).GetChild(0).GetComponent<Image>();
				this.tmpImg.transform.localScale = new Vector3(-1f, this.tmpImg.transform.localScale.y, this.tmpImg.transform.localScale.z);
			}
		}
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Ukr || DataManager.Instance.UserLanguage == GameLanguage.GL_Mys)
		{
			this.btn_Function_P2[3].gameObject.SetActive(false);
			RectTransform component = this.btn_Function_P2[3].transform.GetComponent<RectTransform>();
			RectTransform component2 = this.btn_Function_P2[4].transform.GetComponent<RectTransform>();
			component2.localPosition = component.localPosition;
		}
		this.btn_Function_P2[1].gameObject.SetActive(false);
		this.btn_Function_P2[3].gameObject.SetActive(false);
		RectTransform component3 = this.btn_Function_P2[1].transform.GetComponent<RectTransform>();
		RectTransform component4 = this.btn_Function_P2[4].transform.GetComponent<RectTransform>();
		component4.localPosition = component3.localPosition;
		this.btn_LiveChat = this.P2_T.GetChild(5).GetComponent<UIButton>();
		this.btn_LiveChat.m_Handler = this;
		this.btn_LiveChat.m_BtnID1 = 13;
		this.btn_LiveChat.m_EffectType = e_EffectType.e_Scale;
		this.btn_LiveChat.transition = Selectable.Transition.None;
		this.text_LiveChat = this.P2_T.GetChild(5).GetChild(1).GetComponent<UIText>();
		this.text_LiveChat.font = this.TTFont;
		this.btn_Email_Exit = this.GameT.GetChild(3).GetComponent<UIButton>();
		this.btn_Email_Exit.m_Handler = this;
		this.btn_Email_Exit.m_BtnID1 = 12;
		this.btn_Email_Exit.image.color = new Color(1f, 1f, 1f, 0.475f);
		child = this.GameT.GetChild(3);
		for (int k = 0; k < 4; k++)
		{
			this.btn_Email[k] = child.GetChild(1 + k).GetComponent<UIButton>();
			this.btn_Email[k].m_Handler = this;
			this.btn_Email[k].m_BtnID1 = 8 + k;
			this.btn_Email[k].m_EffectType = e_EffectType.e_Scale;
			this.btn_Email[k].transition = Selectable.Transition.None;
			this.text_Email[k] = child.GetChild(1 + k).GetChild(0).GetComponent<UIText>();
			this.text_Email[k].font = this.TTFont;
		}
		if (this.mType == 0)
		{
			this.P1_T.gameObject.SetActive(true);
			this.textTitle.text = this.DM.mStringTable.GetStringByID(7030u);
			this.text_btn_P1[0].text = this.DM.mStringTable.GetStringByID(7044u);
		}
		else
		{
			this.P2_T.gameObject.SetActive(true);
			this.textTitle.text = this.DM.mStringTable.GetStringByID(7031u);
			for (int l = 0; l < 2; l++)
			{
				this.text_btn_P2[l].text = this.DM.mStringTable.GetStringByID((uint)(7045 + l));
			}
			if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
			{
				this.text_btn_P2[0].text = this.DM.mStringTable.GetStringByID(16032u);
			}
			this.text_btn_P2[2].text = this.DM.mStringTable.GetStringByID(7098u);
			this.text_btn_P2[3].text = this.DM.mStringTable.GetStringByID(7099u);
			this.text_btn_P2[4].text = this.DM.mStringTable.GetStringByID(7100u);
			this.text_Email[0].text = this.DM.mStringTable.GetStringByID(8401u);
			this.text_Email[1].text = this.DM.mStringTable.GetStringByID(8402u);
			this.text_Email[2].text = this.DM.mStringTable.GetStringByID(8403u);
			this.text_Email[3].text = this.DM.mStringTable.GetStringByID(8404u);
		}
		this.m_Mat = this.door.LoadMaterial();
		this.tmpImg = this.GameT.GetChild(4).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
		this.tmpImg.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(4).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.m_Mat;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x060015F6 RID: 5622 RVA: 0x00257510 File Offset: 0x00255710
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 1:
			IGGSDKPlugin.OpenFbByUrl(GameConstants.GlobalEditionFUrl);
			break;
		case 2:
			IGGSDKPlugin.VisitForum();
			break;
		case 3:
			IGGSDKPlugin.LoadWebView("https://lm.176.com/agreement.php");
			break;
		case 4:
			if (DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn)
			{
				IGGSDKPlugin.LoadWebView("http://www.igg.com/about/privacy_policy.php?lang=jp");
			}
			else
			{
				IGGSDKPlugin.LoadWebView("http://www.igg.com/about/privacy_policy.php");
			}
			break;
		case 5:
			IGGSDKPlugin.SubmitQuestion();
			break;
		case 6:
			this.btn_Email_Exit.transform.SetParent(this.GUIM.m_SecWindowLayer, false);
			this.btn_Email_Exit.gameObject.SetActive(true);
			break;
		case 7:
			IGGSDKPlugin.Guide(GameConstants.GlobalEditionGuideURL);
			break;
		case 8:
		case 9:
		case 10:
		case 11:
		{
			this.btn_Email_Exit.transform.SetParent(this.GameT, false);
			this.btn_Email_Exit.transform.SetSiblingIndex(3);
			this.btn_Email_Exit.gameObject.SetActive(false);
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			string utctime = GameConstants.GetDateTime(DataManager.Instance.ServerTime).ToString();
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring2.ClearString();
			cstring2.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9025u));
			cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8468u));
			string gameName = cstring2.ToString();
			cstring.StringToFormat(this.DM.mStringTable.GetStringByID(9025u));
			cstring.AppendFormat(this.DM.mStringTable.GetStringByID((uint)((ushort)(8410 + sender.m_BtnID1 - 8))));
			string gameVersion = string.Format("{0}.{1}.{2}", GameConstants.Version[0], GameConstants.Version[1], GameConstants.Version[2]);
			string iggid = IGGGameSDK.Instance.m_IGGID;
			string language;
			if (DataManager.Instance.UserLanguage > (GameLanguage)0 && DataManager.Instance.UserLanguage < GameLanguage.GL_MAX)
			{
				language = GameConstants.GameLanguageName[(int)DataManager.Instance.UserLanguage];
			}
			else
			{
				language = GameConstants.GameLanguageName[1];
			}
			string deviceType = SystemInfo.deviceModel.ToString();
			string operatingSystem = SystemInfo.operatingSystem;
			int num = Mathf.Clamp((int)DataManager.Instance.UserLanguage, 1, GameConstants.GlobalEditionGameID.Length - 1);
			IGGSDKPlugin.SendMail(GameConstants.GlobalEditionMailTo[num], cstring.ToString(), utctime, gameName, gameVersion, iggid, language, deviceType, operatingSystem);
			break;
		}
		case 12:
			this.btn_Email_Exit.transform.SetParent(this.GameT, false);
			this.btn_Email_Exit.transform.SetSiblingIndex(3);
			this.btn_Email_Exit.gameObject.SetActive(false);
			break;
		case 13:
			if (DataManager.Instance.UserLanguage == GameLanguage.GL_Eng || DataManager.Instance.UserLanguage == GameLanguage.GL_Idn || DataManager.Instance.UserLanguage == GameLanguage.GL_Tha || DataManager.Instance.UserLanguage == GameLanguage.GL_Vet)
			{
				IGGSDKPlugin.SupportLiveOnLogin_GlobalEdition((byte)DataManager.Instance.UserLanguage);
			}
			break;
		case 14:
			IGGSDKPlugin.OpenFbByUrl("http://lm20160316.pixnet.net/blog");
			break;
		case 15:
			if (DataManager.Instance.UserLanguage == GameLanguage.GL_Cht)
			{
				IGGSDKPlugin.OpenFbByUrl("https://www.youtube.com/channel/UC26f7wSibaVbLWT06ApRjqQ");
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Eng)
			{
				IGGSDKPlugin.OpenFbByUrl("https://www.youtube.com/c/LordsMobile");
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Rus)
			{
				IGGSDKPlugin.OpenFbByUrl("https://www.youtube.com/channel/UCyI75MkDMPsuBcFJSkaxRXg");
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Spa)
			{
				IGGSDKPlugin.OpenFbByUrl("https://www.youtube.com/channel/UCmh_PyukAR1mInQonCHd6rQ?view_as=subscriber");
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Vet)
			{
				IGGSDKPlugin.OpenFbByUrl("https://www.youtube.com/channel/UCV2C44HNEkhTWJR7Ls5zC7w?view_as=subscriber");
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Ita)
			{
				IGGSDKPlugin.OpenFbByUrl("http://www.youtube.com/c/LordsMobileItaliano");
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Kor)
			{
				IGGSDKPlugin.OpenFbByUrl("https://www.youtube.com/channel/UCdarRfwPZOmLUxR66PGGnjA");
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Arb)
			{
				IGGSDKPlugin.OpenFbByUrl("https://www.youtube.com/channel/UCfmFAotvhwVs-Aqmjcyl37g");
			}
			break;
		case 16:
			IGGSDKPlugin.OpenFbByUrl("https://twitter.com/LordsMobileJP");
			break;
		case 17:
			IGGSDKPlugin.LoadWebView("http://lordsmobile.176.com/agreement.php");
			break;
		case 18:
			IGGSDKPlugin.OpenFbByUrl("https://web.lobi.co/game/wang_guo_ji_yuan_lords_mobile_zh_tw");
			break;
		case 19:
			IGGSDKPlugin.OpenFbByUrl("https://forum.gamer.com.tw/B.php?bsn=30034");
			break;
		case 20:
			if (DataManager.Instance.UserLanguage == GameLanguage.GL_Eng)
			{
				IGGSDKPlugin.OpenFbByUrl("https://twitter.com/LordsMobile");
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Rus)
			{
				IGGSDKPlugin.OpenFbByUrl("https://twitter.com/LordsMobileRU");
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Ita)
			{
				IGGSDKPlugin.OpenFbByUrl("https://twitter.com/LordsITALIA");
			}
			break;
		case 21:
			if (DataManager.Instance.UserLanguage == GameLanguage.GL_Eng)
			{
				IGGSDKPlugin.OpenFbByUrl("https://www.instagram.com/lordsmobile/");
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Fre)
			{
				IGGSDKPlugin.OpenFbByUrl("https://www.instagram.com/lordsmobilefr/");
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Gem)
			{
				IGGSDKPlugin.OpenFbByUrl("https://www.instagram.com/lordsmobilede");
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Rus)
			{
				IGGSDKPlugin.OpenFbByUrl("https://www.instagram.com/lordsmobileru/");
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Spa)
			{
				IGGSDKPlugin.OpenFbByUrl("https://www.instagram.com/lordsmobile_es/");
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Ita)
			{
				IGGSDKPlugin.OpenFbByUrl("https://www.instagram.com/lordsmobileita/");
			}
			break;
		case 22:
			IGGSDKPlugin.OpenFbByUrl("https://lm.176.com");
			break;
		case 23:
			IGGSDKPlugin.OpenFbByUrl("https://www.facebook.com/pg/LordsMobileRU/posts/");
			break;
		}
	}

	// Token: 0x060015F7 RID: 5623 RVA: 0x00257B2C File Offset: 0x00255D2C
	public override bool OnBackButtonClick()
	{
		if (this.btn_Email_Exit.IsActive())
		{
			this.btn_Email_Exit.transform.SetParent(this.GameT, false);
			this.btn_Email_Exit.transform.SetSiblingIndex(3);
			this.btn_Email_Exit.gameObject.SetActive(false);
		}
		return false;
	}

	// Token: 0x060015F8 RID: 5624 RVA: 0x00257B84 File Offset: 0x00255D84
	public override void OnClose()
	{
	}

	// Token: 0x060015F9 RID: 5625 RVA: 0x00257B88 File Offset: 0x00255D88
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
			break;
		}
	}

	// Token: 0x060015FA RID: 5626 RVA: 0x00257BC8 File Offset: 0x00255DC8
	public void Refresh_FontTexture()
	{
		if (this.textTitle != null && this.textTitle.enabled)
		{
			this.textTitle.enabled = false;
			this.textTitle.enabled = true;
		}
		if (this.text_LiveChat != null && this.text_LiveChat.enabled)
		{
			this.text_LiveChat.enabled = false;
			this.text_LiveChat.enabled = true;
		}
		for (int i = 0; i < 5; i++)
		{
			if (this.text_btn_P1[i] != null && this.text_btn_P1[i].enabled)
			{
				this.text_btn_P1[i].enabled = false;
				this.text_btn_P1[i].enabled = true;
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (this.text_Email[j] != null && this.text_Email[j].enabled)
			{
				this.text_Email[j].enabled = false;
				this.text_Email[j].enabled = true;
			}
		}
		for (int k = 0; k < 5; k++)
		{
			if (this.text_btn_P2[k] != null && this.text_btn_P2[k].enabled)
			{
				this.text_btn_P2[k].enabled = false;
				this.text_btn_P2[k].enabled = true;
			}
		}
	}

	// Token: 0x060015FB RID: 5627 RVA: 0x00257D40 File Offset: 0x00255F40
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 1)
		{
		}
	}

	// Token: 0x060015FC RID: 5628 RVA: 0x00257D60 File Offset: 0x00255F60
	private void Start()
	{
	}

	// Token: 0x060015FD RID: 5629 RVA: 0x00257D64 File Offset: 0x00255F64
	private void Update()
	{
	}

	// Token: 0x04004125 RID: 16677
	private DataManager DM;

	// Token: 0x04004126 RID: 16678
	private GUIManager GUIM;

	// Token: 0x04004127 RID: 16679
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x04004128 RID: 16680
	private Door door;

	// Token: 0x04004129 RID: 16681
	private Transform GameT;

	// Token: 0x0400412A RID: 16682
	private Transform P1_T;

	// Token: 0x0400412B RID: 16683
	private Transform P2_T;

	// Token: 0x0400412C RID: 16684
	private UIButton btn_EXIT;

	// Token: 0x0400412D RID: 16685
	private UIButton[] btn_Function_P1 = new UIButton[5];

	// Token: 0x0400412E RID: 16686
	private UIButton[] btn_Function_P2 = new UIButton[5];

	// Token: 0x0400412F RID: 16687
	private UIButton[] btn_Email = new UIButton[4];

	// Token: 0x04004130 RID: 16688
	private UIButton btn_Email_Exit;

	// Token: 0x04004131 RID: 16689
	private UIButton btn_LiveChat;

	// Token: 0x04004132 RID: 16690
	private Image tmpImg;

	// Token: 0x04004133 RID: 16691
	private Image[] Img_P1Icon = new Image[5];

	// Token: 0x04004134 RID: 16692
	private UIText textTitle;

	// Token: 0x04004135 RID: 16693
	private UIText[] text_btn_P1 = new UIText[5];

	// Token: 0x04004136 RID: 16694
	private UIText[] text_btn_P2 = new UIText[5];

	// Token: 0x04004137 RID: 16695
	private UIText[] text_Email = new UIText[4];

	// Token: 0x04004138 RID: 16696
	private UIText text_LiveChat;

	// Token: 0x04004139 RID: 16697
	private Material m_Mat;

	// Token: 0x0400413A RID: 16698
	private UISpritesArray SArray;

	// Token: 0x0400413B RID: 16699
	private int mType;
}
