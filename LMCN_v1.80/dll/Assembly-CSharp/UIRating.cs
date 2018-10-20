using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000649 RID: 1609
public class UIRating : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06001F00 RID: 7936 RVA: 0x003B73D0 File Offset: 0x003B55D0
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.TTFont = this.GUIM.GetTTFFont();
		this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
		this.GameT = base.gameObject.transform;
		this.nowPage = GUIRating_Page.page_Select;
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.GameT.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.GameT.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.Tmp = this.GameT.GetChild(0);
		this.img_TitleBG = this.GameT.GetChild(0).GetComponent<Image>();
		this.img_TitleBG2 = this.GameT.GetChild(1).GetComponent<Image>();
		this.btn_Dislike = this.GameT.GetChild(4).GetComponent<UIButton>();
		this.btn_Dislike.m_Handler = this;
		this.btn_Dislike.m_BtnID1 = 1;
		this.btn_Dislike.m_EffectType = e_EffectType.e_Scale;
		this.btn_Dislike.transition = Selectable.Transition.None;
		this.text_Dislike = this.GameT.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.text_Dislike.font = this.TTFont;
		this.text_Dislike.text = this.DM.mStringTable.GetStringByID(11255u);
		this.btn_Like = this.GameT.GetChild(5).GetComponent<UIButton>();
		this.btn_Like.m_Handler = this;
		this.btn_Like.m_BtnID1 = 2;
		this.btn_Like.m_EffectType = e_EffectType.e_Scale;
		this.btn_Like.transition = Selectable.Transition.None;
		this.text_Like = this.GameT.GetChild(5).GetChild(0).GetComponent<UIText>();
		this.text_Like.font = this.TTFont;
		this.text_Like.text = this.DM.mStringTable.GetStringByID(11254u);
		this.btn_Like_Rating = this.GameT.GetChild(6).GetComponent<UIButton>();
		this.btn_Like_Rating.m_Handler = this;
		this.btn_Like_Rating.m_BtnID1 = 3;
		this.btn_Like_Rating.m_EffectType = e_EffectType.e_Scale;
		this.btn_Like_Rating.transition = Selectable.Transition.None;
		this.text_Like_Rating = this.GameT.GetChild(6).GetChild(0).GetComponent<UIText>();
		this.text_Like_Rating.font = this.TTFont;
		this.text_Like_Rating.text = this.DM.mStringTable.GetStringByID(7400u);
		this.btn_Dislike_Suggest = this.GameT.GetChild(7).GetComponent<UIButton>();
		this.btn_Dislike_Suggest.m_Handler = this;
		this.btn_Dislike_Suggest.m_BtnID1 = 4;
		this.btn_Dislike_Suggest.m_EffectType = e_EffectType.e_Scale;
		this.btn_Dislike_Suggest.transition = Selectable.Transition.None;
		this.text_Dislike_Suggest = this.GameT.GetChild(7).GetChild(0).GetComponent<UIText>();
		this.text_Dislike_Suggest.font = this.TTFont;
		this.text_Dislike_Suggest.text = this.DM.mStringTable.GetStringByID(11258u);
		this.Tmp = this.GameT.GetChild(2);
		this.btn_Exit = this.Tmp.GetComponent<UIButton>();
		this.btn_Exit.m_Handler = this;
		this.btn_Exit.m_BtnID1 = 0;
		this.btn_Exit.m_EffectType = e_EffectType.e_Scale;
		this.btn_Exit.transition = Selectable.Transition.None;
		this.Tmp = this.GameT.GetChild(3);
		this.text_Title = this.Tmp.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.SetScore();
		this.UpdateUI(0, 0);
	}

	// Token: 0x06001F01 RID: 7937 RVA: 0x003B77C0 File Offset: 0x003B59C0
	public void SetScore()
	{
		bool flag = false;
		long num = 0L;
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.IntToFormat(NetworkManager.UserID, 1, false);
		cstring.AppendFormat("{0}_Score_UseID");
		long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out num);
		if (num != 0L)
		{
			cstring.ClearString();
			cstring.IntToFormat(num, 1, false);
			cstring.AppendFormat("{0}_Score_bScoreFirst");
			bool.TryParse(PlayerPrefs.GetString(cstring.ToString()), out flag);
			if (flag)
			{
				byte b = 0;
				cstring.ClearString();
				cstring.IntToFormat(num, 1, false);
				cstring.AppendFormat("{0}_Score_Count");
				byte.TryParse(PlayerPrefs.GetString(cstring.ToString()), out b);
				b += 1;
				PlayerPrefs.SetString(cstring.ToString(), b.ToString());
			}
			else
			{
				flag = true;
				cstring.ClearString();
				cstring.IntToFormat(num, 1, false);
				cstring.AppendFormat("{0}_Score_bScoreFirst");
				PlayerPrefs.SetString(cstring.ToString(), flag.ToString());
			}
			cstring.ClearString();
			cstring.IntToFormat(num, 1, false);
			cstring.AppendFormat("{0}_Score_CD");
			PlayerPrefs.SetString(cstring.ToString(), this.DM.ServerTime.ToString());
		}
		else
		{
			PlayerPrefs.SetString(cstring.ToString(), NetworkManager.UserID.ToString());
			long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out num);
			flag = true;
			cstring.ClearString();
			cstring.IntToFormat(num, 1, false);
			cstring.AppendFormat("{0}_Score_bScoreFirst");
			PlayerPrefs.SetString(cstring.ToString(), flag.ToString());
			bool.TryParse(PlayerPrefs.GetString(cstring.ToString()), out flag);
			cstring.ClearString();
			cstring.IntToFormat(num, 1, false);
			cstring.AppendFormat("{0}_Score_CD");
			PlayerPrefs.SetString(cstring.ToString(), this.DM.ServerTime.ToString());
		}
	}

	// Token: 0x06001F02 RID: 7938 RVA: 0x003B79A8 File Offset: 0x003B5BA8
	public override void UpdateTime(bool bOnSecond)
	{
	}

	// Token: 0x06001F03 RID: 7939 RVA: 0x003B79AC File Offset: 0x003B5BAC
	public override void OnClose()
	{
	}

	// Token: 0x06001F04 RID: 7940 RVA: 0x003B79B0 File Offset: 0x003B5BB0
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			this.GUIM.CloseMenu(EGUIWindow.UI_Rating);
			this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			break;
		case 1:
		{
			bool flag = true;
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring.IntToFormat(NetworkManager.UserID, 1, false);
			cstring.AppendFormat("{0}_Score_bScoreEnd");
			PlayerPrefs.SetString(cstring.ToString(), flag.ToString());
			this.UpdateUI(1, 0);
			break;
		}
		case 2:
			this.UpdateUI(2, 0);
			break;
		case 3:
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_GOOGLESTAR_PRIZE;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			bool flag = true;
			long num = 0L;
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring.IntToFormat(NetworkManager.UserID, 1, false);
			cstring.AppendFormat("{0}");
			long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out num);
			if (num != 0L)
			{
				cstring.ClearString();
				cstring.IntToFormat(num, 1, false);
				cstring.AppendFormat("{0}_Score_bScoreEnd");
				PlayerPrefs.SetString(cstring.ToString(), flag.ToString());
			}
			IGGSDKPlugin.RateGooglePlayApplication(GameConstants.GlobalEditionClassNames);
			this.GUIM.CloseMenu(EGUIWindow.UI_Rating);
			this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			break;
		}
		case 4:
			this.GUIM.CloseMenu(EGUIWindow.UI_Rating);
			this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			IGGGameSDK.OpenSuggestUrl();
			break;
		}
	}

	// Token: 0x06001F05 RID: 7941 RVA: 0x003B7B48 File Offset: 0x003B5D48
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Fallout)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
		}
		else
		{
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001F06 RID: 7942 RVA: 0x003B7B8C File Offset: 0x003B5D8C
	public void Refresh_FontTexture()
	{
		if (this.text_Dislike != null && this.text_Dislike.enabled)
		{
			this.text_Dislike.enabled = false;
			this.text_Dislike.enabled = true;
		}
		if (this.text_Dislike_Suggest != null && this.text_Dislike_Suggest.enabled)
		{
			this.text_Dislike_Suggest.enabled = false;
			this.text_Dislike_Suggest.enabled = true;
		}
		if (this.text_Like != null && this.text_Like.enabled)
		{
			this.text_Like.enabled = false;
			this.text_Like.enabled = true;
		}
		if (this.text_Like_Rating != null && this.text_Like_Rating.enabled)
		{
			this.text_Like_Rating.enabled = false;
			this.text_Like_Rating.enabled = true;
		}
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
	}

	// Token: 0x06001F07 RID: 7943 RVA: 0x003B7CB8 File Offset: 0x003B5EB8
	public override void UpdateUI(int arg1, int arg2)
	{
		this.btn_Like.gameObject.SetActive(arg1 == 0);
		this.btn_Dislike.gameObject.SetActive(arg1 == 0);
		this.btn_Like_Rating.gameObject.SetActive(arg1 == 2);
		this.btn_Dislike_Suggest.gameObject.SetActive(arg1 == 1);
		switch (arg1)
		{
		case 0:
			this.img_TitleBG.gameObject.SetActive(true);
			this.img_TitleBG2.gameObject.SetActive(false);
			this.img_TitleBG.sprite = this.SArray.m_Sprites[0];
			this.text_Title.text = this.DM.mStringTable.GetStringByID(11253u);
			break;
		case 1:
			this.img_TitleBG.gameObject.SetActive(false);
			this.img_TitleBG2.gameObject.SetActive(true);
			this.img_TitleBG.sprite = this.SArray.m_Sprites[2];
			this.text_Title.text = this.DM.mStringTable.GetStringByID(11257u);
			break;
		case 2:
			this.img_TitleBG.gameObject.SetActive(true);
			this.img_TitleBG2.gameObject.SetActive(false);
			this.img_TitleBG.sprite = this.SArray.m_Sprites[1];
			this.text_Title.text = this.DM.mStringTable.GetStringByID(11256u);
			break;
		}
		this.text_Title.SetAllDirty();
		this.text_Title.cachedTextGenerator.Invalidate();
	}

	// Token: 0x04006276 RID: 25206
	private Transform GameT;

	// Token: 0x04006277 RID: 25207
	private Transform Tmp;

	// Token: 0x04006278 RID: 25208
	private UISpritesArray SArray;

	// Token: 0x04006279 RID: 25209
	private GUIRating_Page nowPage;

	// Token: 0x0400627A RID: 25210
	private DataManager DM;

	// Token: 0x0400627B RID: 25211
	private GUIManager GUIM;

	// Token: 0x0400627C RID: 25212
	private Font TTFont;

	// Token: 0x0400627D RID: 25213
	private UIButton btn_Dislike;

	// Token: 0x0400627E RID: 25214
	private UIButton btn_Dislike_Suggest;

	// Token: 0x0400627F RID: 25215
	private UIButton btn_Like;

	// Token: 0x04006280 RID: 25216
	private UIButton btn_Like_Rating;

	// Token: 0x04006281 RID: 25217
	private UIButton btn_Exit;

	// Token: 0x04006282 RID: 25218
	private UIText text_Dislike;

	// Token: 0x04006283 RID: 25219
	private UIText text_Dislike_Suggest;

	// Token: 0x04006284 RID: 25220
	private UIText text_Like;

	// Token: 0x04006285 RID: 25221
	private UIText text_Like_Rating;

	// Token: 0x04006286 RID: 25222
	private UIText text_Title;

	// Token: 0x04006287 RID: 25223
	private Image img_TitleBG;

	// Token: 0x04006288 RID: 25224
	private Image img_TitleBG2;
}
