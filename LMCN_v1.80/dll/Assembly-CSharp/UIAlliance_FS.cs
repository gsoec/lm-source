using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002D9 RID: 729
public class UIAlliance_FS : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06000EB8 RID: 3768 RVA: 0x00186054 File Offset: 0x00184254
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.AWM = ActivityManager.Instance.AllianceWarMgr;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.mMaT = this.door.LoadMaterial();
		this.IconMaterial = this.GUIM.m_IconSpriteAsset.GetMaterial();
		this.FrameMaterial = this.GUIM.GetFrameMaterial();
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		CString cstring = StringManager.Instance.StaticString1024();
		this.Cstr_TitleName = StringManager.Instance.SpawnString(30);
		this.Cstr_FightingKind = StringManager.Instance.SpawnString(100);
		this.Cstr_L_Exp = StringManager.Instance.SpawnString(30);
		this.Cstr_BoosHead = StringManager.Instance.SpawnString(30);
		this.Cstr_Text = StringManager.Instance.SpawnString(30);
		this.Cstr_Quanmie[0] = StringManager.Instance.SpawnString(100);
		this.Cstr_NpcTroops = StringManager.Instance.SpawnString(30);
		this.Cstr_QuanmieNpcTroops = StringManager.Instance.SpawnString(30);
		this.Cstr_LF = StringManager.Instance.SpawnString(200);
		this.Cstr_RF = StringManager.Instance.SpawnString(200);
		for (int i = 1; i < 4; i++)
		{
			this.Cstr_Quanmie[i] = StringManager.Instance.SpawnString(30);
		}
		for (int j = 0; j < 30; j++)
		{
			this.Cstr_ItemQty[j] = StringManager.Instance.SpawnString(10);
		}
		for (int k = 0; k < 2; k++)
		{
			this.Cstr_Coordinate[k] = StringManager.Instance.SpawnString(30);
			this.Cstr_Offensive[k] = StringManager.Instance.SpawnString(30);
			this.Cstr_LossValue[k] = StringManager.Instance.SpawnString(30);
			this.Cstr_Strength[k] = StringManager.Instance.SpawnString(30);
			this.Cstr_Country[k] = StringManager.Instance.SpawnString(30);
			this.Cstr_Dominance[k] = StringManager.Instance.SpawnString(30);
			this.Cstr_CoordinateMainHero[k] = StringManager.Instance.SpawnString(30);
			this.Cstr_Name[k] = StringManager.Instance.SpawnString(30);
			this.Cstr_BossR[k] = StringManager.Instance.SpawnString(30);
			this.Cstr_BossFight[k] = StringManager.Instance.SpawnString(100);
			this.Cstr_BossL[k] = StringManager.Instance.SpawnString(30);
		}
		for (int l = 0; l < 8; l++)
		{
			this.Cstr_RA[l] = StringManager.Instance.SpawnString(30);
		}
		for (int m = 0; m < 4; m++)
		{
			this.Cstr_LA[m] = StringManager.Instance.SpawnString(30);
		}
		for (int n = 0; n < 3; n++)
		{
			this.Cstr_DW[n] = StringManager.Instance.SpawnString(30);
		}
		this.Tmp = this.GameT.GetChild(0);
		this.Tmp1 = this.Tmp.GetChild(1);
		this.text_TitleName = this.Tmp1.GetChild(0).GetComponent<UIText>();
		this.text_TitleName.font = this.TTFont;
		this.text_Page = this.Tmp1.GetChild(1).GetComponent<UIText>();
		this.text_Page.font = this.TTFont;
		this.text_Page.gameObject.SetActive(false);
		this.Tmp = this.GameT.GetChild(1);
		this.Mask_T = this.GameT.GetChild(1);
		this.m_Mask = this.Tmp.GetComponent<CScrollRect>();
		this.ContentRT = this.Tmp.GetChild(0).GetComponent<RectTransform>();
		this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
		this.Img_Titlebg = this.Tmp1.GetComponent<Image>();
		this.ReplayerRT = this.Tmp1.GetComponent<RectTransform>();
		this.btn_Replay = this.Tmp1.GetChild(0).GetComponent<UIButton>();
		this.btn_Replay.m_Handler = this;
		this.btn_Replay.m_BtnID1 = 1;
		this.btn_Replay.SoundIndex = byte.MaxValue;
		this.btn_Replay.m_EffectType = e_EffectType.e_Scale;
		this.btn_Replay.transition = Selectable.Transition.None;
		this.Img_RePlay = this.Tmp1.GetChild(0).GetChild(0).GetComponent<Image>();
		this.text_tmpStr[0] = this.Tmp1.GetChild(0).GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(5306u);
		this.LightT1 = this.Tmp1.GetChild(1);
		this.tmpImg = this.Tmp1.GetChild(1).GetComponent<Image>();
		this.text_Summary = this.Tmp1.GetChild(2).GetComponent<UIText>();
		this.text_Summary.font = this.TTFont;
		this.tmpH -= 136f;
		this.Tmp1 = this.Tmp.GetChild(0).GetChild(1);
		this.Img_MainHerobg = this.Tmp1.GetComponent<Image>();
		this.Img_MainHerobg.gameObject.SetActive(false);
		this.text_MainHero = this.Tmp1.GetChild(0).GetComponent<UIText>();
		this.text_MainHero.font = this.TTFont;
		this.Tmp1 = this.Tmp.GetChild(0).GetChild(2);
		this.ItemRT = this.Tmp1.GetComponent<RectTransform>();
		this.ItemRT.gameObject.SetActive(false);
		this.ItemRT.anchoredPosition = new Vector2(this.ItemRT.anchoredPosition.x, this.tmpH);
		this.ItemRT2 = this.Tmp1.GetChild(0).GetComponent<RectTransform>();
		this.text_TitleItem = this.Tmp1.GetChild(1).GetComponent<UIText>();
		this.text_TitleItem.font = this.TTFont;
		this.ItemT[0] = this.Tmp1.GetChild(0).GetChild(0);
		this.ItemBase = this.Tmp1.GetChild(0).GetChild(0);
		this.Tmp2 = this.Tmp1.GetChild(0).GetChild(1);
		this.ResourcesRT = this.Tmp2.GetComponent<RectTransform>();
		for (int num = 0; num < 5; num++)
		{
			this.tmpImg = this.Tmp2.GetChild(num).GetComponent<Image>();
			this.tmpImg.material = this.mMaT;
			this.text_Resources[num] = this.Tmp2.GetChild(num).GetChild(0).GetComponent<UIText>();
			this.text_Resources[num].font = this.TTFont;
		}
		this.Tmp1 = this.Tmp.GetChild(0).GetChild(3);
		this.HeroRT = this.Tmp1.GetComponent<RectTransform>();
		this.HeroRT.gameObject.SetActive(false);
		this.HeroBGRT = this.Tmp1.GetChild(0).GetComponent<RectTransform>();
		this.Img_Exp = this.Tmp1.GetChild(0).GetChild(0).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_Exp.transform.localScale = new Vector3(-1f, this.Img_Exp.transform.localScale.y, this.Img_Exp.transform.localScale.z);
		}
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			this.Img_Exp.sprite = this.SArray.m_Sprites[16];
		}
		for (int num2 = 0; num2 < 5; num2++)
		{
			this.btn_Hero[num2] = this.Tmp1.GetChild(0).GetChild(1).GetChild(num2).GetComponent<UIHIBtn>();
			this.text_HeroExp[num2] = this.Tmp1.GetChild(0).GetChild(1).GetChild(num2 + 5).GetComponent<UIText>();
			this.text_HeroExp[num2].font = this.TTFont;
			this.text_HeroExp2[num2] = this.Tmp1.GetChild(0).GetChild(1).GetChild(num2 + 10).GetComponent<UIText>();
			this.text_HeroExp2[num2].font = this.TTFont;
			this.text_HeroExp2[num2].text = this.DM.mStringTable.GetStringByID(7695u);
		}
		this.text_L_Exp = this.Tmp1.GetChild(0).GetChild(2).GetComponent<UIText>();
		this.text_L_Exp.font = this.TTFont;
		this.text_tmpStr[1] = this.Tmp1.GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(7697u);
		this.tmpH -= 110f;
		this.Tmp1 = this.GameT.GetChild(7);
		this.Img_FormationHint = this.Tmp1.GetComponent<Image>();
		this.text_Formation = this.Tmp1.GetChild(0).GetComponent<UIText>();
		this.text_Formation.font = this.TTFont;
		this.Tmp1 = this.Mask_T.GetChild(0).GetChild(4);
		this.SummaryRT = this.Tmp1.GetComponent<RectTransform>();
		this.SummaryRT.anchoredPosition = new Vector2(this.SummaryRT.anchoredPosition.x, this.tmpH);
		if (!this.bInitFS)
		{
			this.bInitFS = true;
		}
		this.InitFSComponent();
		this.Tmp = this.GameT.GetChild(2);
		this.Tmp1 = this.Tmp.GetChild(0);
		this.btn_Title = this.Tmp1.GetComponent<UIButton>();
		this.btn_Title.gameObject.SetActive(false);
		this.text_Coordinate = this.Tmp1.GetChild(1).GetComponent<UIText>();
		this.text_Coordinate.font = this.TTFont;
		this.Tmp1 = this.Tmp.GetChild(1);
		this.text_Time[0] = this.Tmp1.GetComponent<UIText>();
		this.text_Time[0].font = this.TTFont;
		this.text_Time[0].gameObject.SetActive(false);
		this.Tmp1 = this.Tmp.GetChild(2);
		this.text_Time[1] = this.Tmp1.GetComponent<UIText>();
		this.text_Time[1].font = this.TTFont;
		this.text_Time[1].gameObject.SetActive(false);
		this.Tmp1 = this.GameT.GetChild(3);
		this.btn_Delete = this.Tmp1.GetComponent<UIButton>();
		this.btn_Delete.gameObject.SetActive(false);
		this.Tmp1 = this.GameT.GetChild(4);
		this.btn_Collect = this.Tmp1.GetComponent<UIButton>();
		this.btn_Collect.gameObject.SetActive(false);
		float x = this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x;
		this.tempL = (this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x - 853f) / 2f;
		this.PreviousT = this.GameT.GetChild(5);
		this.btn_Previous = this.PreviousT.GetComponent<UIButton>();
		this.btn_Previous.gameObject.SetActive(false);
		this.NextT = this.GameT.GetChild(6);
		this.btn_Next = this.NextT.GetComponent<UIButton>();
		this.btn_Next.gameObject.SetActive(false);
		this.Tmp = this.GameT.GetChild(8);
		this.tmpImg = this.Tmp.GetComponent<Image>();
		cstring.ClearString();
		cstring.AppendFormat("UI_main_close_base");
		this.tmpImg.sprite = this.door.LoadSprite(cstring);
		this.tmpImg.material = this.mMaT;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.Tmp = this.GameT.GetChild(8).GetChild(0);
		this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
		cstring.ClearString();
		cstring.AppendFormat("UI_main_close");
		this.btn_EXIT.image.sprite = this.door.LoadSprite(cstring);
		this.btn_EXIT.image.material = this.mMaT;
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.SetPageData();
		if (this.DM.mSaveInfo == 3)
		{
			this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, 621f);
		}
		this.DM.mSaveInfo = 0;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06000EB9 RID: 3769 RVA: 0x00186E44 File Offset: 0x00185044
	public void InitFSComponent()
	{
		this.Tmp1 = this.Mask_T.GetChild(0).GetChild(4);
		this.text_Offensive[0] = this.Tmp1.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_Offensive[0].font = this.TTFont;
		this.Cstr_Offensive[0].ClearString();
		this.text_Offensive[1] = this.Tmp1.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_Offensive[1].font = this.TTFont;
		this.Cstr_Offensive[1].ClearString();
		this.tmpH -= 51f;
		this.Tmp2 = this.Tmp1.GetChild(2);
		this.Img_Summarybg[0] = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(3);
		this.Img_Summarybg[1] = this.Tmp2.GetComponent<Image>();
		this.tmpH -= 312f;
		this.Tmp2 = this.Tmp1.GetChild(4);
		this.Img_MainHero[0] = this.Tmp2.GetComponent<Image>();
		this.Img_MainHero[1] = this.Tmp2.GetChild(0).GetChild(0).GetComponent<Image>();
		this.Img_MainHero[1].material = this.IconMaterial;
		this.tmpRC = this.Tmp2.GetChild(0).GetChild(0).GetComponent<RectTransform>();
		this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
		this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		this.Img_MainHero[2] = this.Tmp2.GetChild(0).GetChild(1).GetComponent<Image>();
		this.Img_MainHero[2].sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, 11);
		this.Img_MainHero[2].material = this.FrameMaterial;
		this.tmpRC = this.Tmp2.GetChild(0).GetChild(1).GetComponent<RectTransform>();
		this.tmpRC.anchorMin = Vector2.zero;
		this.tmpRC.anchorMax = new Vector2(1f, 1f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		this.Img_MainTitle[0] = this.Tmp2.GetChild(1).GetComponent<Image>();
		this.text_MainHero_F[0] = this.Tmp2.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_MainHero_F[0].font = this.TTFont;
		this.Img_Muster[0] = this.Tmp2.GetChild(2).GetComponent<Image>();
		this.text_tmpStr[2] = this.Tmp2.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[2].font = this.TTFont;
		this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(5395u);
		this.text_Dominance[0] = this.Tmp2.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.text_Dominance[0].font = this.TTFont;
		this.Cstr_Dominance[0].ClearString();
		this.text_Dominance[0].text = this.DM.mStringTable.GetStringByID(5320u).ToString();
		this.Img_Country[0] = this.Tmp2.GetChild(4).GetComponent<Image>();
		this.text_Country[0] = this.Tmp2.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.text_Country[0].font = this.TTFont;
		this.Cstr_Country[0].ClearString();
		this.text_Country[0].text = this.Cstr_Country[0].ToString();
		this.Img_Rank[0] = this.Tmp2.GetChild(5).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_Rank[0].transform.localScale = new Vector3(-1f, this.Img_Rank[0].transform.localScale.y, this.Img_Rank[0].transform.localScale.z);
		}
		int num = 0;
		this.Img_Vip[0] = this.Tmp2.GetChild(6).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_Vip[0].transform.localScale = new Vector3(-1f, this.Img_Vip[0].transform.localScale.y, this.Img_Vip[0].transform.localScale.z);
		}
		this.btn_Coordinate[0] = this.Tmp2.GetChild(7).GetComponent<UIButton>();
		this.btn_Coordinate[0].gameObject.SetActive(false);
		this.text_CoordinateMainHero[0] = this.Tmp2.GetChild(7).GetChild(1).GetComponent<UIText>();
		this.text_CoordinateMainHero[0].font = this.TTFont;
		this.text_Vip[0] = this.Tmp2.GetChild(8).GetComponent<UIText>();
		this.text_Vip[0].font = this.TTFont;
		this.text_Vip[0].text = num.ToString();
		this.text_Name[0] = this.Tmp2.GetChild(9).GetComponent<UIText>();
		this.text_Name[0].font = this.TTFont;
		this.Cstr_Name[0].ClearString();
		this.Tmp2 = this.Tmp1.GetChild(5);
		this.Img_MainHero[3] = this.Tmp2.GetComponent<Image>();
		this.Img_MainHero[4] = this.Tmp2.GetChild(0).GetChild(0).GetComponent<Image>();
		this.Img_MainHero[4].material = this.IconMaterial;
		this.tmpRC = this.Tmp2.GetChild(0).GetChild(0).GetComponent<RectTransform>();
		this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
		this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		this.Img_MainHero[5] = this.Tmp2.GetChild(0).GetChild(1).GetComponent<Image>();
		this.Img_MainHero[5].sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, 11);
		this.Img_MainHero[5].material = this.FrameMaterial;
		this.tmpRC = this.Tmp2.GetChild(0).GetChild(1).GetComponent<RectTransform>();
		this.tmpRC.anchorMin = Vector2.zero;
		this.tmpRC.anchorMax = new Vector2(1f, 1f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		this.Img_MainTitle[1] = this.Tmp2.GetChild(1).GetComponent<Image>();
		this.text_MainHero_F[1] = this.Tmp2.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_MainHero_F[1].font = this.TTFont;
		this.Img_Muster[1] = this.Tmp2.GetChild(2).GetComponent<Image>();
		this.tmptext = this.Tmp2.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.tmptext.font = this.TTFont;
		this.text_Dominance[1] = this.Tmp2.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.text_Dominance[1].font = this.TTFont;
		this.Cstr_Dominance[1].ClearString();
		this.text_Dominance[1].text = this.Cstr_Dominance[1].ToString();
		this.Img_Country[1] = this.Tmp2.GetChild(4).GetComponent<Image>();
		this.text_Country[1] = this.Tmp2.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.text_Country[1].font = this.TTFont;
		this.Cstr_Country[1].ClearString();
		this.Cstr_Dominance[1].ClearString();
		this.Img_Rank[1] = this.Tmp2.GetChild(5).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_Rank[1].transform.localScale = new Vector3(-1f, this.Img_Rank[1].transform.localScale.y, this.Img_Rank[1].transform.localScale.z);
		}
		int num2 = 0;
		this.Img_Vip[1] = this.Tmp2.GetChild(6).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_Vip[1].transform.localScale = new Vector3(-1f, this.Img_Vip[1].transform.localScale.y, this.Img_Vip[1].transform.localScale.z);
		}
		this.btn_Coordinate[1] = this.Tmp2.GetChild(7).GetComponent<UIButton>();
		this.btn_Coordinate[1].gameObject.SetActive(false);
		this.text_CoordinateMainHero[1] = this.Tmp2.GetChild(7).GetChild(1).GetComponent<UIText>();
		this.text_CoordinateMainHero[1].font = this.TTFont;
		this.text_Vip[1] = this.Tmp2.GetChild(8).GetComponent<UIText>();
		this.text_Vip[1].font = this.TTFont;
		this.text_Vip[1].text = num2.ToString();
		this.text_Name[1] = this.Tmp2.GetChild(9).GetComponent<UIText>();
		this.text_Name[1].font = this.TTFont;
		this.Img_Crown[0] = this.Tmp1.GetChild(6).GetComponent<Image>();
		this.Img_Crown[1] = this.Tmp1.GetChild(6).GetChild(0).GetComponent<Image>();
		this.Img_Crown[2] = this.Tmp1.GetChild(7).GetComponent<Image>();
		this.Img_Crown[3] = this.Tmp1.GetChild(7).GetChild(0).GetComponent<Image>();
		this.LightT2 = this.Tmp1.GetChild(8);
		this.Img_Vs = this.Tmp1.GetChild(9).GetChild(0).GetComponent<Image>();
		this.tmpImg = this.Tmp1.GetChild(9).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.tmpImg.transform.localScale = new Vector3(-1f, this.tmpImg.transform.localScale.y, this.tmpImg.transform.localScale.z);
		}
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			this.tmpImg.sprite = this.SArray.m_Sprites[17];
			this.Img_Vs.sprite = this.SArray.m_Sprites[18];
		}
		this.text_tmpStr[3] = this.Tmp1.GetChild(10).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[3].font = this.TTFont;
		this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(5321u);
		this.text_tmpStr[4] = this.Tmp1.GetChild(11).GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[4].font = this.TTFont;
		this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(5321u);
		this.tmpH -= 41f;
		this.Tmp2 = this.Tmp1.GetChild(12);
		this.Img_Army[0] = this.Tmp2.GetComponent<Image>();
		this.Img_Army2[0] = this.Tmp2.GetChild(0).GetComponent<Image>();
		this.text_LossValue[0] = this.Tmp2.GetChild(1).GetComponent<UIText>();
		this.text_LossValue[0].font = this.TTFont;
		this.text_ArmyTitle[0] = this.Tmp2.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_ArmyTitle[0].font = this.TTFont;
		this.text_Strength[0] = this.Tmp2.GetChild(0).GetChild(1).GetComponent<UIText>();
		this.text_Strength[0].font = this.TTFont;
		for (int i = 0; i < 4; i++)
		{
			this.text_tmpStr[5 + i] = this.Tmp2.GetChild(0).GetChild(2 + i).GetComponent<UIText>();
			this.text_tmpStr[5 + i].font = this.TTFont;
			this.text_tmpStr[5 + i].text = this.DM.mStringTable.GetStringByID((uint)((ushort)(5325 + i)));
			this.text_LA[i] = this.Tmp2.GetChild(0).GetChild(6 + i).GetComponent<UIText>();
			this.text_LA[i].font = this.TTFont;
		}
		this.Tmp = this.Tmp2.GetChild(0).GetChild(10);
		this.btn_LF = this.Tmp.GetComponent<UIButton>();
		this.btn_LF.m_Handler = this;
		this.btn_LF.m_BtnID1 = 5;
		UIButtonHint uibuttonHint = this.btn_LF.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.CountDown;
		uibuttonHint.m_Handler = this;
		uibuttonHint.DelayTime = 0.3f;
		uibuttonHint.ControlFadeOut = this.Img_FormationHint.gameObject;
		this.Tmp = this.Tmp2.GetChild(0).GetChild(10).GetChild(0);
		this.Img_LF = this.Tmp.GetComponent<Image>();
		this.text_LF = this.Tmp2.GetChild(0).GetChild(10).GetChild(1).GetComponent<UIText>();
		this.text_LF.font = this.TTFont;
		this.Tmp = this.Tmp2.GetChild(0).GetChild(11);
		this.text_NpcInfo = this.Tmp.GetComponent<UIText>();
		this.text_NpcInfo.font = this.TTFont;
		this.Cstr_Text.ClearString();
		this.Cstr_Text.StringToFormat(this.DM.mStringTable.GetStringByID(17029u));
		this.Cstr_Text.AppendFormat(this.DM.mStringTable.GetStringByID(11165u));
		this.text_NpcInfo.text = this.Cstr_Text.ToString();
		this.Tmp = this.Tmp2.GetChild(0).GetChild(12);
		this.text_NpcTroops[0] = this.Tmp.GetComponent<UIText>();
		this.text_NpcTroops[0].font = this.TTFont;
		this.text_NpcTroops[0].text = this.DM.mStringTable.GetStringByID(9643u);
		this.Tmp = this.Tmp2.GetChild(0).GetChild(13);
		this.text_NpcTroops[1] = this.Tmp.GetComponent<UIText>();
		this.text_NpcTroops[1].font = this.TTFont;
		this.Tmp2 = this.Tmp1.GetChild(13);
		this.Img_Army[1] = this.Tmp2.GetComponent<Image>();
		this.Img_Army2[1] = this.Tmp2.GetChild(0).GetComponent<Image>();
		this.text_LossValue[1] = this.Tmp2.GetChild(1).GetComponent<UIText>();
		this.text_LossValue[1].font = this.TTFont;
		this.text_ArmyTitle[1] = this.Tmp2.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_ArmyTitle[1].font = this.TTFont;
		this.text_Strength[1] = this.Tmp2.GetChild(0).GetChild(1).GetComponent<UIText>();
		this.text_Strength[1].font = this.TTFont;
		for (int j = 0; j < 4; j++)
		{
			this.text_tmpStr[9 + j] = this.Tmp2.GetChild(0).GetChild(2 + j).GetComponent<UIText>();
			this.text_tmpStr[9 + j].font = this.TTFont;
			this.text_tmpStr[9 + j].text = this.DM.mStringTable.GetStringByID((uint)((ushort)(5325 + j)));
			this.text_RA[j] = this.Tmp2.GetChild(0).GetChild(6 + j).GetComponent<UIText>();
			this.text_RA[j].font = this.TTFont;
			this.text_tmpStr[13 + j] = this.Tmp2.GetChild(0).GetChild(10 + j).GetComponent<UIText>();
			this.text_tmpStr[13 + j].font = this.TTFont;
			this.text_tmpStr[13 + j].text = this.DM.mStringTable.GetStringByID((uint)((ushort)(5329 + j)));
			this.text_RA[4 + j] = this.Tmp2.GetChild(0).GetChild(14 + j).GetComponent<UIText>();
			this.text_RA[4 + j].font = this.TTFont;
		}
		this.Tmp = this.Tmp2.GetChild(0).GetChild(18);
		this.btn_RF = this.Tmp.GetComponent<UIButton>();
		this.btn_RF.m_Handler = this;
		this.btn_RF.m_BtnID1 = 5;
		uibuttonHint = this.btn_RF.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.CountDown;
		uibuttonHint.DelayTime = 0.3f;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = this.Img_FormationHint.gameObject;
		this.Tmp = this.Tmp2.GetChild(0).GetChild(18).GetChild(0);
		this.Img_RF = this.Tmp.GetComponent<Image>();
		this.text_RF = this.Tmp2.GetChild(0).GetChild(18).GetChild(1).GetComponent<UIText>();
		this.text_RF.font = this.TTFont;
		UIButtonHint.scrollRect = this.m_Mask;
		if (this.AWM.MyAllySide == 2)
		{
			this.text_NpcInfo.rectTransform.anchoredPosition = new Vector2(0f, this.text_NpcInfo.rectTransform.anchoredPosition.y);
			this.text_NpcInfo.transform.SetParent(this.Img_Army2[1].transform, false);
		}
		this.text_NpcInfo.gameObject.SetActive(true);
		this.tmpH -= 498f;
		this.Tmp2 = this.Tmp1.GetChild(14);
		this.Img_CWall_P[0] = this.Tmp2.GetComponent<Image>();
		this.Img_CWall_P[0].gameObject.SetActive(false);
		this.Img_CWall[0] = this.Tmp2.GetChild(0).GetComponent<Image>();
		this.text_tmpStr[17] = this.Tmp2.GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[17].font = this.TTFont;
		this.text_tmpStr[17].text = this.DM.mStringTable.GetStringByID(5333u);
		this.text_tmpStr[18] = this.Tmp2.GetChild(2).GetComponent<UIText>();
		this.text_tmpStr[18].font = this.TTFont;
		this.text_tmpStr[18].text = this.DM.mStringTable.GetStringByID(5334u);
		this.Tmp2 = this.Tmp1.GetChild(15);
		this.Img_CWall_P[1] = this.Tmp2.GetComponent<Image>();
		this.Img_CWall_P[1].gameObject.SetActive(false);
		this.Img_CWall[1] = this.Tmp2.GetChild(0).GetComponent<Image>();
		this.text_tmpStr[19] = this.Tmp2.GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[19].font = this.TTFont;
		this.text_tmpStr[19].text = this.DM.mStringTable.GetStringByID(5333u);
		for (int k = 0; k < 3; k++)
		{
			this.text_tmpStr[20 + k] = this.Tmp2.GetChild(2 + k).GetComponent<UIText>();
			this.text_tmpStr[20 + k].font = this.TTFont;
			this.text_tmpStr[20 + k].text = this.DM.mStringTable.GetStringByID((uint)((ushort)(5335 + k)));
			this.text_DW[k] = this.Tmp2.GetChild(5 + k).GetComponent<UIText>();
			this.text_DW[k].font = this.TTFont;
		}
		this.Tmp2 = this.Tmp1.GetChild(19);
		this.btn_Details = this.Tmp2.GetComponent<UIButton>();
		this.btn_Details.m_Handler = this;
		this.btn_Details.m_BtnID1 = 2;
		this.btn_Details.SoundIndex = 64;
		this.btn_Details.m_EffectType = e_EffectType.e_Scale;
		this.btn_Details.transition = Selectable.Transition.None;
		this.text_tmpStr[23] = this.Tmp2.GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[23].font = this.TTFont;
		this.text_tmpStr[23].text = this.DM.mStringTable.GetStringByID(5396u);
		this.tmpH -= 281f;
		this.Tmp1 = this.Mask_T.GetChild(0).GetChild(5);
		this.QuanmieRT = this.Tmp1.GetComponent<RectTransform>();
		this.QuanmieRT.anchoredPosition = new Vector2(this.QuanmieRT.anchoredPosition.x, this.tmpH);
		this.Img_Quanmie = this.Tmp1.GetChild(0).GetComponent<Image>();
		for (int l = 0; l < 8; l++)
		{
			this.text_Quanmie[l] = this.Tmp1.GetChild(0).GetChild(l).GetComponent<UIText>();
			this.text_Quanmie[l].font = this.TTFont;
		}
		this.text_Quanmie[0].text = this.DM.mStringTable.GetStringByID(5323u);
		for (int m = 0; m < 4; m++)
		{
			this.Cstr_Quanmie[m].ClearString();
		}
		this.text_Quanmie[1].text = this.Cstr_Quanmie[0].ToString();
		this.text_Quanmie[2].text = this.DM.mStringTable.GetStringByID(5325u);
		this.text_Quanmie[3].text = this.DM.mStringTable.GetStringByID(5326u);
		this.text_Quanmie[4].text = this.DM.mStringTable.GetStringByID(5327u);
		this.text_FightingKind = this.Tmp1.GetChild(3).GetComponent<UIText>();
		this.text_FightingKind.font = this.TTFont;
		this.text_FightingKind.text = this.DM.mStringTable.GetStringByID(5385u);
		this.SetPorfileBtn();
	}

	// Token: 0x06000EBA RID: 3770 RVA: 0x001886CC File Offset: 0x001868CC
	public override void OnClose()
	{
		if (this.Cstr_TitleName != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_TitleName);
		}
		if (this.Cstr_FightingKind != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_FightingKind);
		}
		if (this.Cstr_L_Exp != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_L_Exp);
		}
		if (this.Cstr_BoosHead != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_BoosHead);
		}
		if (this.Cstr_Text != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Text);
		}
		if (this.Cstr_NpcTroops != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_NpcTroops);
		}
		if (this.Cstr_QuanmieNpcTroops != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_QuanmieNpcTroops);
		}
		if (this.Cstr_LF != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_LF);
		}
		if (this.Cstr_RF != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_RF);
		}
		for (int i = 0; i < 4; i++)
		{
			if (this.Cstr_Quanmie[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Quanmie[i]);
			}
		}
		for (int j = 0; j < 30; j++)
		{
			if (this.Cstr_ItemQty[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemQty[j]);
			}
		}
		for (int k = 0; k < 2; k++)
		{
			if (this.Cstr_Coordinate[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Coordinate[k]);
			}
			if (this.Cstr_Offensive[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Offensive[k]);
			}
			if (this.Cstr_LossValue[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_LossValue[k]);
			}
			if (this.Cstr_Strength[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Strength[k]);
			}
			if (this.Cstr_Country[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Country[k]);
			}
			if (this.Cstr_Dominance[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Dominance[k]);
			}
			if (this.Cstr_CoordinateMainHero[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_CoordinateMainHero[k]);
			}
			if (this.Cstr_Name[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Name[k]);
			}
			if (this.Cstr_BossR[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_BossR[k]);
			}
			if (this.Cstr_BossFight[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_BossFight[k]);
			}
			if (this.Cstr_BossL[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_BossL[k]);
			}
		}
		for (int l = 0; l < 8; l++)
		{
			if (this.Cstr_RA[l] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_RA[l]);
			}
		}
		for (int m = 0; m < 4; m++)
		{
			if (this.Cstr_LA[m] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_LA[m]);
			}
		}
		for (int n = 0; n < 3; n++)
		{
			if (this.Cstr_DW[n] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_DW[n]);
			}
		}
		if (this.DM.mSaveInfo == 1)
		{
			DataManager dm = this.DM;
			dm.mSaveInfo += 1;
		}
		if (this.AssetKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey, false);
		}
		this.AssetKey = 0;
	}

	// Token: 0x06000EBB RID: 3771 RVA: 0x00188A94 File Offset: 0x00186C94
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
		{
			GUIManager.Instance.bClearWindowStack = false;
			AllianceWarManager allianceWarMgr = ActivityManager.Instance.AllianceWarMgr;
			WarManager.StartWar(allianceWarMgr.mReportResult, allianceWarMgr.MyAllySide == 1, allianceWarMgr.mReportRandSeed, allianceWarMgr.mReportRandGap, ref allianceWarMgr.m_CombatPlayerData[0], ref allianceWarMgr.m_CombatPlayerData[1]);
			break;
		}
		case 2:
			if (this.door != null)
			{
				this.DM.mSaveInfo = 1;
				this.door.OpenMenu(EGUIWindow.UI_Alliance_FS_Info, 0, 0, false);
			}
			break;
		case 3:
		case 4:
			this.ShowLordProfile((Alliance_FS_btn)sender.m_BtnID1);
			break;
		}
	}

	// Token: 0x06000EBC RID: 3772 RVA: 0x00188B84 File Offset: 0x00186D84
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		Alliance_FS_btn btnID = (Alliance_FS_btn)uibutton.m_BtnID1;
		if (btnID == Alliance_FS_btn.btn_Formation_Hint)
		{
			sender.GetTipPosition(this.Img_FormationHint.rectTransform, UIButtonHint.ePosition.Original, null);
			this.Img_FormationHint.gameObject.SetActive(true);
		}
	}

	// Token: 0x06000EBD RID: 3773 RVA: 0x00188BE4 File Offset: 0x00186DE4
	public void OnButtonUp(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		Alliance_FS_btn btnID = (Alliance_FS_btn)uibutton.m_BtnID1;
		if (btnID == Alliance_FS_btn.btn_Formation_Hint)
		{
			this.Img_FormationHint.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000EBE RID: 3774 RVA: 0x00188C28 File Offset: 0x00186E28
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

	// Token: 0x06000EBF RID: 3775 RVA: 0x00188C68 File Offset: 0x00186E68
	public void Refresh_FontTexture()
	{
		if (this.text_Coordinate != null && this.text_Coordinate.enabled)
		{
			this.text_Coordinate.enabled = false;
			this.text_Coordinate.enabled = true;
		}
		if (this.text_TitleName != null && this.text_TitleName.enabled)
		{
			this.text_TitleName.enabled = false;
			this.text_TitleName.enabled = true;
		}
		if (this.text_Page != null && this.text_Page.enabled)
		{
			this.text_Page.enabled = false;
			this.text_Page.enabled = true;
		}
		if (this.text_Summary != null && this.text_Summary.enabled)
		{
			this.text_Summary.enabled = false;
			this.text_Summary.enabled = true;
		}
		if (this.text_MainHero != null && this.text_MainHero.enabled)
		{
			this.text_MainHero.enabled = false;
			this.text_MainHero.enabled = true;
		}
		if (this.text_TitleItem != null && this.text_TitleItem.enabled)
		{
			this.text_TitleItem.enabled = false;
			this.text_TitleItem.enabled = true;
		}
		if (this.text_FightingKind != null && this.text_FightingKind.enabled)
		{
			this.text_FightingKind.enabled = false;
			this.text_FightingKind.enabled = true;
		}
		if (this.text_L_Exp != null && this.text_L_Exp.enabled)
		{
			this.text_L_Exp.enabled = false;
			this.text_L_Exp.enabled = true;
		}
		if (this.text_Formation != null && this.text_Formation.enabled)
		{
			this.text_Formation.enabled = false;
			this.text_Formation.enabled = true;
		}
		if (this.text_NpcInfo != null && this.text_NpcInfo.enabled)
		{
			this.text_NpcInfo.enabled = false;
			this.text_NpcInfo.enabled = true;
		}
		if (this.text_QuanmierNpcInfo != null && this.text_QuanmierNpcInfo.enabled)
		{
			this.text_QuanmierNpcInfo.enabled = false;
			this.text_QuanmierNpcInfo.enabled = true;
		}
		if (this.text_NpcCoordinate != null && this.text_NpcCoordinate.enabled)
		{
			this.text_NpcCoordinate.enabled = false;
			this.text_NpcCoordinate.enabled = true;
		}
		if (this.text_NpcName != null && this.text_NpcName.enabled)
		{
			this.text_NpcName.enabled = false;
			this.text_NpcName.enabled = true;
		}
		if (this.text_NpcItemName != null && this.text_NpcItemName.enabled)
		{
			this.text_NpcItemName.enabled = false;
			this.text_NpcItemName.enabled = true;
		}
		if (this.text_NpcItemfull != null && this.text_NpcItemfull.enabled)
		{
			this.text_NpcItemfull.enabled = false;
			this.text_NpcItemfull.enabled = true;
		}
		if (this.text_NpcItemHint != null && this.text_NpcItemHint.enabled)
		{
			this.text_NpcItemHint.enabled = false;
			this.text_NpcItemHint.enabled = true;
		}
		if (this.text_AllianceBossStr != null && this.text_AllianceBossStr.enabled)
		{
			this.text_AllianceBossStr.enabled = false;
			this.text_AllianceBossStr.enabled = true;
		}
		if (this.text_LF != null && this.text_LF.enabled)
		{
			this.text_LF.enabled = false;
			this.text_LF.enabled = true;
		}
		if (this.text_RF != null && this.text_RF.enabled)
		{
			this.text_RF.enabled = false;
			this.text_RF.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_Time[i] != null && this.text_Time[i].enabled)
			{
				this.text_Time[i].enabled = false;
				this.text_Time[i].enabled = true;
			}
			if (this.text_Offensive[i] != null && this.text_Offensive[i].enabled)
			{
				this.text_Offensive[i].enabled = false;
				this.text_Offensive[i].enabled = true;
			}
			if (this.text_LossValue[i] != null && this.text_LossValue[i].enabled)
			{
				this.text_LossValue[i].enabled = false;
				this.text_LossValue[i].enabled = true;
			}
			if (this.text_ArmyTitle[i] != null && this.text_ArmyTitle[i].enabled)
			{
				this.text_ArmyTitle[i].enabled = false;
				this.text_ArmyTitle[i].enabled = true;
			}
			if (this.text_Strength[i] != null && this.text_Strength[i].enabled)
			{
				this.text_Strength[i].enabled = false;
				this.text_Strength[i].enabled = true;
			}
			if (this.text_Country[i] != null && this.text_Country[i].enabled)
			{
				this.text_Country[i].enabled = false;
				this.text_Country[i].enabled = true;
			}
			if (this.text_Dominance[i] != null && this.text_Dominance[i].enabled)
			{
				this.text_Dominance[i].enabled = false;
				this.text_Dominance[i].enabled = true;
			}
			if (this.text_Name[i] != null && this.text_Name[i].enabled)
			{
				this.text_Name[i].enabled = false;
				this.text_Name[i].enabled = true;
			}
			if (this.text_MainHero_F[i] != null && this.text_MainHero_F[i].enabled)
			{
				this.text_MainHero_F[i].enabled = false;
				this.text_MainHero_F[i].enabled = true;
			}
			if (this.text_Vip[i] != null && this.text_Vip[i].enabled)
			{
				this.text_Vip[i].enabled = false;
				this.text_Vip[i].enabled = true;
			}
			if (this.text_CoordinateMainHero[i] != null && this.text_CoordinateMainHero[i].enabled)
			{
				this.text_CoordinateMainHero[i].enabled = false;
				this.text_CoordinateMainHero[i].enabled = true;
			}
			if (this.text_BossTitle[i] != null && this.text_BossTitle[i].enabled)
			{
				this.text_BossTitle[i].enabled = false;
				this.text_BossTitle[i].enabled = true;
			}
			if (this.text_BossL[i] != null && this.text_BossL[i].enabled)
			{
				this.text_BossL[i].enabled = false;
				this.text_BossL[i].enabled = true;
			}
			if (this.text_NpcTroops[i] != null && this.text_NpcTroops[i].enabled)
			{
				this.text_NpcTroops[i].enabled = false;
				this.text_NpcTroops[i].enabled = true;
			}
			if (this.text_QuanmierNpcTroops[i] != null && this.text_QuanmierNpcTroops[i].enabled)
			{
				this.text_QuanmierNpcTroops[i].enabled = false;
				this.text_QuanmierNpcTroops[i].enabled = true;
			}
		}
		for (int j = 0; j < 3; j++)
		{
			if (this.text_DW[j] != null && this.text_DW[j].enabled)
			{
				this.text_DW[j].enabled = false;
				this.text_DW[j].enabled = true;
			}
			if (this.text_BossR[j] != null && this.text_BossR[j].enabled)
			{
				this.text_BossR[j].enabled = false;
				this.text_BossR[j].enabled = true;
			}
			if (this.text_BossFight[j] != null && this.text_BossFight[j].enabled)
			{
				this.text_BossFight[j].enabled = false;
				this.text_BossFight[j].enabled = true;
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (this.text_LA[k] != null && this.text_LA[k].enabled)
			{
				this.text_LA[k].enabled = false;
				this.text_LA[k].enabled = true;
			}
		}
		for (int l = 0; l < 5; l++)
		{
			if (this.text_Resources[l] != null && this.text_Resources[l].enabled)
			{
				this.text_Resources[l].enabled = false;
				this.text_Resources[l].enabled = true;
			}
			if (this.text_HeroExp[l] != null && this.text_HeroExp[l].enabled)
			{
				this.text_HeroExp[l].enabled = false;
				this.text_HeroExp[l].enabled = true;
			}
			if (this.text_HeroExp2[l] != null && this.text_HeroExp2[l].enabled)
			{
				this.text_HeroExp2[l].enabled = false;
				this.text_HeroExp2[l].enabled = true;
			}
			if (this.btn_Hero[l] != null && this.btn_Hero[l].enabled)
			{
				this.btn_Hero[l].Refresh_FontTexture();
			}
		}
		for (int m = 0; m < 8; m++)
		{
			if (this.text_RA[m] != null && this.text_RA[m].enabled)
			{
				this.text_RA[m].enabled = false;
				this.text_RA[m].enabled = true;
			}
			if (this.text_Quanmie[m] != null && this.text_Quanmie[m].enabled)
			{
				this.text_Quanmie[m].enabled = false;
				this.text_Quanmie[m].enabled = true;
			}
		}
		for (int n = 0; n < 25; n++)
		{
			if (this.text_tmpStr[n] != null && this.text_tmpStr[n].enabled)
			{
				this.text_tmpStr[n].enabled = false;
				this.text_tmpStr[n].enabled = true;
			}
		}
		for (int num = 0; num < 30; num++)
		{
			if (this.text_ItemQty[num] != null && this.text_ItemQty[num].enabled)
			{
				this.text_ItemQty[num].enabled = false;
				this.text_ItemQty[num].enabled = true;
			}
			if (this.btn_Itme[num] != null && this.btn_Itme[num].enabled)
			{
				this.btn_Itme[num].Refresh_FontTexture();
			}
		}
	}

	// Token: 0x06000EC0 RID: 3776 RVA: 0x00189850 File Offset: 0x00187A50
	public override void UpdateUI(int arg1, int arg2)
	{
	}

	// Token: 0x06000EC1 RID: 3777 RVA: 0x00189854 File Offset: 0x00187A54
	public void SetPageData()
	{
		if (this.AssetKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey, false);
		}
		if (this.mHead != null)
		{
			UnityEngine.Object.Destroy(this.mHead);
		}
		this.Cstr_TitleName.ClearString();
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		CString cstring3 = StringManager.Instance.StaticString1024();
		CString cstring4 = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring2.ClearString();
		cstring3.ClearString();
		cstring4.ClearString();
		byte b = 0;
		cstring.Append(this.AWM.m_CombatPlayerData[0].Name);
		if (DataManager.CompareStr(cstring, this.DM.RoleAttr.Name) != 0)
		{
			b = 1;
			if (this.AWM.m_CombatPlayerData[0].AllianceTag != string.Empty)
			{
				cstring2.Append(this.AWM.m_CombatPlayerData[0].AllianceTag);
				if (this.DM.IsSameAlliance(cstring2))
				{
					this.GUIM.FormatRoleNameForChat(cstring4, cstring, null, 0, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring4, cstring, cstring2, 0, this.GUIM.IsArabic);
				}
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring4, cstring, null, 0, this.GUIM.IsArabic);
			}
		}
		cstring.ClearString();
		cstring2.ClearString();
		cstring3.ClearString();
		cstring.Append(this.AWM.m_CombatPlayerData[1].Name);
		if (DataManager.CompareStr(cstring, this.DM.RoleAttr.Name) != 0)
		{
			if (b == 0)
			{
				b = 3;
			}
			else
			{
				b = 2;
			}
			if (this.AWM.m_CombatPlayerData[1].AllianceTag != string.Empty)
			{
				cstring2.Append(this.AWM.m_CombatPlayerData[1].AllianceTag);
				if (this.DM.IsSameAlliance(cstring2))
				{
					this.GUIM.FormatRoleNameForChat(cstring3, cstring, null, 0, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring3, cstring, cstring2, 0, this.GUIM.IsArabic);
				}
			}
			else
			{
				this.GUIM.FormatRoleNameForChat(cstring3, cstring, null, 0, this.GUIM.IsArabic);
			}
		}
		if (b == 2)
		{
			this.Cstr_TitleName.StringToFormat(cstring4);
			this.Cstr_TitleName.StringToFormat(cstring3);
			this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(11162u));
		}
		else
		{
			if (b == 1)
			{
				this.Cstr_TitleName.StringToFormat(cstring4);
			}
			else
			{
				this.Cstr_TitleName.StringToFormat(cstring3);
			}
			this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(11168u));
		}
		this.text_TitleName.text = this.Cstr_TitleName.ToString();
		this.text_TitleName.SetAllDirty();
		this.text_TitleName.cachedTextGenerator.Invalidate();
		this.tmpH = -136f;
		int num = 0;
		b = this.AWM.mReportResult;
		if (b == this.AWM.MyAllySide)
		{
			this.Img_Titlebg.sprite = this.SArray.m_Sprites[0];
			this.text_Summary.color = new Color(1f, 0.9255f, 0.5294f);
			this.text_Summary.transform.GetComponent<Outline>().effectColor = new Color(0.8431f, 0f, 0f);
			this.text_Summary.transform.GetComponent<Shadow>().effectColor = new Color(0.2824f, 0f, 0f);
		}
		else
		{
			num = 1;
			this.Img_Titlebg.sprite = this.SArray.m_Sprites[1];
			this.text_Summary.color = new Color(0.6941f, 0.9137f, 1f);
			this.text_Summary.transform.GetComponent<Outline>().effectColor = new Color(0.2471f, 0.451f, 0.7294f);
			this.text_Summary.transform.GetComponent<Shadow>().effectColor = new Color(0f, 0.0471f, 0.2824f);
		}
		this.text_Summary.text = this.DM.mStringTable.GetStringByID((uint)((ushort)(5307 + num)));
		this.text_Summary.SetAllDirty();
		this.text_Summary.cachedTextGenerator.Invalidate();
		this.ItemRT.anchoredPosition = new Vector2(this.ItemRT.anchoredPosition.x, this.tmpH);
		for (int i = 0; i < 5; i++)
		{
			if (this.ItemT[i] != null)
			{
				this.ItemT[i].gameObject.SetActive(false);
			}
		}
		this.text_TitleItem.SetAllDirty();
		this.text_TitleItem.cachedTextGenerator.Invalidate();
		this.HeroRT.anchoredPosition = new Vector2(this.HeroRT.anchoredPosition.x, this.tmpH);
		this.SummaryRT.anchoredPosition = new Vector2(this.SummaryRT.anchoredPosition.x, this.tmpH);
		this.tmpH -= 51f;
		this.tmpH -= 312f;
		this.SetFightData();
	}

	// Token: 0x06000EC2 RID: 3778 RVA: 0x00189E1C File Offset: 0x0018801C
	public void SetFightData()
	{
		this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.AWM.m_CombatPlayerData[0].Head);
		this.Img_MainHero[1].sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
		this.Img_Muster[0].gameObject.SetActive(false);
		this.Cstr_Dominance[0].ClearString();
		this.Cstr_Dominance[0].IntToFormat((long)this.AWM.m_CombatPlayerData[0].Level, 1, false);
		this.Cstr_Dominance[0].AppendFormat(this.DM.mStringTable.GetStringByID(5320u));
		this.text_Dominance[0].text = this.Cstr_Dominance[0].ToString();
		this.text_Dominance[0].SetAllDirty();
		this.text_Dominance[0].cachedTextGenerator.Invalidate();
		this.Cstr_Country[0].ClearString();
		this.Cstr_Country[0].IntToFormat((long)this.AWM.m_CombatPlayerData[0].KingdomID, 1, false);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_Country[0].AppendFormat("{0}#");
		}
		else
		{
			this.Cstr_Country[0].AppendFormat("#{0}");
		}
		this.text_Country[0].text = this.Cstr_Country[0].ToString();
		this.text_Country[0].SetAllDirty();
		this.text_Country[0].cachedTextGenerator.Invalidate();
		this.Img_Country[0].gameObject.SetActive(false);
		int allianceRank = (int)this.AWM.m_CombatPlayerData[0].AllianceRank;
		this.Img_Rank[0].sprite = this.SArray.m_Sprites[7 + allianceRank];
		if (allianceRank < 1)
		{
			this.Img_Rank[0].gameObject.SetActive(false);
		}
		else
		{
			this.Img_Rank[0].gameObject.SetActive(true);
		}
		int viplevel = (int)this.AWM.m_CombatPlayerData[0].VIPLevel;
		this.text_Vip[0].text = viplevel.ToString();
		this.Cstr_Name[0].ClearString();
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring2.ClearString();
		cstring.Append(this.AWM.m_CombatPlayerData[0].Name);
		if (this.AWM.m_CombatPlayerData[0].AllianceTag != string.Empty)
		{
			cstring2.Append(this.AWM.m_CombatPlayerData[0].AllianceTag);
			GameConstants.FormatRoleName(this.Cstr_Name[0], cstring, cstring2, null, 0, 0, null, null, null, null);
		}
		else
		{
			GameConstants.FormatRoleName(this.Cstr_Name[0], cstring, null, null, 0, 0, null, null, null, null);
		}
		this.text_Name[0].text = this.Cstr_Name[0].ToString();
		this.text_Name[0].SetAllDirty();
		this.text_Name[0].cachedTextGenerator.Invalidate();
		this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.AWM.m_CombatPlayerData[1].Head);
		this.Img_MainHero[4].sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
		this.Img_Muster[1].gameObject.SetActive(false);
		this.Cstr_Dominance[1].ClearString();
		this.Cstr_Dominance[1].IntToFormat((long)this.AWM.m_CombatPlayerData[1].Level, 1, false);
		this.Cstr_Dominance[1].AppendFormat(this.DM.mStringTable.GetStringByID(5320u));
		this.text_Dominance[1].text = this.Cstr_Dominance[1].ToString();
		this.text_Dominance[1].SetAllDirty();
		this.text_Dominance[1].cachedTextGenerator.Invalidate();
		this.Cstr_Country[1].ClearString();
		this.Cstr_Country[1].IntToFormat((long)this.AWM.m_CombatPlayerData[1].KingdomID, 1, false);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_Country[1].AppendFormat("{0}#");
		}
		else
		{
			this.Cstr_Country[1].AppendFormat("#{0}");
		}
		this.text_Country[1].text = this.Cstr_Country[1].ToString();
		this.text_Country[1].SetAllDirty();
		this.text_Country[1].cachedTextGenerator.Invalidate();
		this.Img_Country[1].gameObject.SetActive(false);
		int allianceRank2 = (int)this.AWM.m_CombatPlayerData[1].AllianceRank;
		this.Img_Rank[1].sprite = this.SArray.m_Sprites[7 + allianceRank2];
		if (allianceRank2 < 1)
		{
			this.Img_Rank[1].gameObject.SetActive(false);
		}
		else
		{
			this.Img_Rank[1].gameObject.SetActive(true);
		}
		int viplevel2 = (int)this.AWM.m_CombatPlayerData[1].VIPLevel;
		this.text_Vip[1].text = viplevel2.ToString();
		this.Cstr_Name[1].ClearString();
		cstring.ClearString();
		cstring2.ClearString();
		cstring.Append(this.AWM.m_CombatPlayerData[1].Name);
		if (this.AWM.m_CombatPlayerData[1].AllianceTag != string.Empty)
		{
			cstring2.Append(this.AWM.m_CombatPlayerData[1].AllianceTag);
			GameConstants.FormatRoleName(this.Cstr_Name[1], cstring, cstring2, null, 0, 0, null, null, null, null);
		}
		else
		{
			GameConstants.FormatRoleName(this.Cstr_Name[1], cstring, null, null, 0, 0, null, null, null, null);
		}
		this.text_Name[1].text = this.Cstr_Name[1].ToString();
		this.text_Name[1].SetAllDirty();
		this.text_Name[1].cachedTextGenerator.Invalidate();
		if (this.AWM.m_CombatPlayerData[0].KingdomID != this.AWM.m_CombatPlayerData[1].KingdomID)
		{
			this.Img_Country[0].gameObject.SetActive(true);
			this.Img_Country[1].gameObject.SetActive(true);
		}
		else
		{
			this.Img_Country[0].gameObject.SetActive(false);
			this.Img_Country[1].gameObject.SetActive(false);
		}
		if (this.AWM.m_CombatPlayerData[0].bMain)
		{
			this.Img_Crown[0].gameObject.SetActive(true);
			this.Img_MainTitle[0].gameObject.SetActive(true);
		}
		else
		{
			this.Img_Crown[0].gameObject.SetActive(false);
			this.Img_MainTitle[0].gameObject.SetActive(false);
		}
		if (this.AWM.m_CombatPlayerData[1].bMain)
		{
			this.Img_Crown[2].gameObject.SetActive(true);
			this.Img_MainTitle[1].gameObject.SetActive(true);
		}
		else
		{
			this.Img_Crown[2].gameObject.SetActive(false);
			this.Img_MainTitle[1].gameObject.SetActive(false);
		}
		this.text_MainHero_F[0].SetAllDirty();
		this.text_MainHero_F[0].cachedTextGenerator.Invalidate();
		this.text_MainHero_F[1].SetAllDirty();
		this.text_MainHero_F[1].cachedTextGenerator.Invalidate();
		this.tmpH -= 41f;
		uint num = 0u;
		uint num2 = 0u;
		for (int i = 0; i < 16; i++)
		{
			num += this.AWM.m_CombatPlayerData[0].DeadTroop[i];
			num2 += this.AWM.m_CombatPlayerData[0].SurviveTroop[i];
		}
		uint num3 = num2 + num;
		this.Cstr_LossValue[0].ClearString();
		this.Cstr_LossValue[0].IntToFormat((long)((ulong)num), 1, true);
		this.Cstr_LossValue[0].AppendFormat("{0}");
		this.text_LossValue[0].text = this.Cstr_LossValue[0].ToString();
		this.text_LossValue[0].SetAllDirty();
		this.text_LossValue[0].cachedTextGenerator.Invalidate();
		this.Cstr_Strength[0].ClearString();
		this.Cstr_Strength[0].uLongToFormat(this.AWM.m_CombatPlayerData[0].LosePower, 1, true);
		this.Cstr_Strength[0].AppendFormat(this.DM.mStringTable.GetStringByID(5322u));
		this.text_Strength[0].text = this.Cstr_Strength[0].ToString();
		this.text_Strength[0].SetAllDirty();
		this.text_Strength[0].cachedTextGenerator.Invalidate();
		this.Cstr_LA[0].ClearString();
		this.Cstr_LA[0].IntToFormat((long)((ulong)num3), 1, true);
		this.Cstr_LA[0].AppendFormat("{0}");
		this.text_LA[0].text = this.Cstr_LA[0].ToString();
		this.text_LA[0].SetAllDirty();
		this.text_LA[0].cachedTextGenerator.Invalidate();
		this.Cstr_LA[1].ClearString();
		this.Cstr_LA[1].IntToFormat(0L, 1, true);
		this.Cstr_LA[1].AppendFormat("{0}");
		this.text_LA[1].text = this.Cstr_LA[1].ToString();
		this.text_LA[1].SetAllDirty();
		this.text_LA[1].cachedTextGenerator.Invalidate();
		this.Cstr_LA[2].ClearString();
		this.Cstr_LA[2].IntToFormat((long)((ulong)num), 1, true);
		this.Cstr_LA[2].AppendFormat("{0}");
		this.text_LA[2].text = this.Cstr_LA[2].ToString();
		this.text_LA[2].SetAllDirty();
		this.text_LA[2].cachedTextGenerator.Invalidate();
		this.Cstr_LA[3].ClearString();
		this.Cstr_LA[3].IntToFormat((long)((ulong)num2), 1, true);
		this.Cstr_LA[3].AppendFormat("{0}");
		this.text_LA[3].text = this.Cstr_LA[3].ToString();
		this.text_LA[3].SetAllDirty();
		this.text_LA[3].cachedTextGenerator.Invalidate();
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if (this.AWM.m_CombatPlayerData[0].StrongholdLevel >= 17)
		{
			flag = true;
			flag3 = true;
			flag2 = true;
			this.text_Formation.text = this.DM.mStringTable.GetStringByID(9796u);
		}
		else
		{
			this.text_Formation.text = this.DM.mStringTable.GetStringByID(9795u);
		}
		this.text_Formation.SetAllDirty();
		this.text_Formation.cachedTextGenerator.Invalidate();
		this.text_Formation.cachedTextGeneratorForLayout.Invalidate();
		if (this.text_Formation.preferredWidth < 400f)
		{
			this.text_Formation.rectTransform.sizeDelta = new Vector2(this.text_Formation.preferredWidth, this.text_Formation.rectTransform.sizeDelta.y);
			this.Img_FormationHint.rectTransform.sizeDelta = new Vector2(this.text_Formation.preferredWidth + 10f, this.Img_FormationHint.rectTransform.sizeDelta.y);
		}
		else
		{
			this.text_Formation.rectTransform.sizeDelta = new Vector2(400f, this.text_Formation.rectTransform.sizeDelta.y);
			this.Img_FormationHint.rectTransform.sizeDelta = new Vector2(410f, this.Img_FormationHint.rectTransform.sizeDelta.y);
		}
		if (this.text_Formation.preferredHeight > this.text_Formation.rectTransform.sizeDelta.y)
		{
			this.text_Formation.rectTransform.sizeDelta = new Vector2(this.text_Formation.rectTransform.sizeDelta.x, this.text_Formation.preferredHeight + 1f);
			this.Img_FormationHint.rectTransform.sizeDelta = new Vector2(this.Img_FormationHint.rectTransform.sizeDelta.x, this.text_Formation.preferredHeight + 10f);
		}
		if (this.GUIM.IsArabic)
		{
			this.text_Formation.UpdateArabicPos();
		}
		if (flag)
		{
			this.Cstr_LF.ClearString();
			this.Cstr_LF.Append(this.DM.mStringTable.GetStringByID(9788u));
			this.Cstr_LF.Append(this.DM.mStringTable.GetStringByID((uint)((ushort)(9778 + (int)this.AWM.m_CombatPlayerData[0].ArmyCoordIndex))));
			this.text_LF.text = this.Cstr_LF.ToString();
			this.text_LF.SetAllDirty();
			this.text_LF.cachedTextGenerator.Invalidate();
			this.text_LF.cachedTextGeneratorForLayout.Invalidate();
			float x;
			if (this.text_LF.preferredWidth + 1f > 390f)
			{
				x = 390f;
			}
			else
			{
				x = this.text_LF.preferredWidth + 1f;
			}
			this.text_LF.rectTransform.sizeDelta = new Vector2(x, this.text_LF.rectTransform.sizeDelta.y);
			if (this.GUIM.IsArabic)
			{
				this.text_LF.UpdateArabicPos();
			}
			this.tmpRC = this.btn_LF.transform.GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(x, this.tmpRC.sizeDelta.y);
			this.Img_LF.rectTransform.sizeDelta = new Vector2(x, this.Img_LF.rectTransform.sizeDelta.y);
			this.btn_LF.gameObject.SetActive(true);
		}
		else
		{
			this.btn_LF.gameObject.SetActive(false);
		}
		if (flag3)
		{
			for (int j = 0; j < 4; j++)
			{
				this.text_tmpStr[5 + j].rectTransform.anchoredPosition = new Vector2(this.text_tmpStr[5 + j].rectTransform.anchoredPosition.x, -95f - (float)j * 33f - 33f);
				this.text_LA[j].rectTransform.anchoredPosition = new Vector2(this.text_LA[j].rectTransform.anchoredPosition.x, -95f - (float)j * 33f - 33f);
			}
		}
		else
		{
			for (int k = 0; k < 4; k++)
			{
				this.text_tmpStr[5 + k].rectTransform.anchoredPosition = new Vector2(this.text_tmpStr[5 + k].rectTransform.anchoredPosition.x, -95f - (float)k * 33f);
				this.text_LA[k].rectTransform.anchoredPosition = new Vector2(this.text_LA[k].rectTransform.anchoredPosition.x, -95f - (float)k * 33f);
			}
		}
		num = 0u;
		num2 = 0u;
		for (int l = 0; l < 16; l++)
		{
			num += this.AWM.m_CombatPlayerData[1].DeadTroop[l];
			num2 += this.AWM.m_CombatPlayerData[1].SurviveTroop[l];
		}
		num3 = num2 + num;
		this.Cstr_LossValue[1].ClearString();
		this.Cstr_LossValue[1].IntToFormat((long)((ulong)num), 1, true);
		this.Cstr_LossValue[1].AppendFormat("{0}");
		this.text_LossValue[1].text = this.Cstr_LossValue[1].ToString();
		this.text_LossValue[1].SetAllDirty();
		this.text_LossValue[1].cachedTextGenerator.Invalidate();
		this.Cstr_Strength[1].ClearString();
		this.Cstr_Strength[1].uLongToFormat(this.AWM.m_CombatPlayerData[1].LosePower, 1, true);
		this.Cstr_Strength[1].AppendFormat(this.DM.mStringTable.GetStringByID(5322u));
		this.text_Strength[1].text = this.Cstr_Strength[1].ToString();
		this.text_Strength[1].SetAllDirty();
		this.text_Strength[1].cachedTextGenerator.Invalidate();
		this.Cstr_RA[0].ClearString();
		this.Cstr_RA[0].IntToFormat((long)((ulong)num3), 1, true);
		this.Cstr_RA[0].AppendFormat("{0}");
		this.text_RA[0].text = this.Cstr_RA[0].ToString();
		this.Cstr_RA[1].ClearString();
		this.Cstr_RA[1].IntToFormat(0L, 1, true);
		this.Cstr_RA[1].AppendFormat("{0}");
		this.text_RA[1].text = this.Cstr_RA[1].ToString();
		this.Cstr_RA[2].ClearString();
		this.Cstr_RA[2].IntToFormat((long)((ulong)num), 1, true);
		this.Cstr_RA[2].AppendFormat("{0}");
		this.text_RA[2].text = this.Cstr_RA[2].ToString();
		this.Cstr_RA[3].ClearString();
		this.Cstr_RA[3].IntToFormat((long)((ulong)num2), 1, true);
		this.Cstr_RA[3].AppendFormat("{0}");
		this.text_RA[3].text = this.Cstr_RA[3].ToString();
		for (int m = 0; m < 8; m++)
		{
			this.text_RA[m].SetAllDirty();
			this.text_RA[m].cachedTextGenerator.Invalidate();
		}
		if (flag3)
		{
			for (int n = 0; n < 4; n++)
			{
				this.text_tmpStr[9 + n].rectTransform.anchoredPosition = new Vector2(this.text_tmpStr[9 + n].rectTransform.anchoredPosition.x, -95f - (float)n * 33f - 33f);
				this.text_RA[n].rectTransform.anchoredPosition = new Vector2(this.text_RA[n].rectTransform.anchoredPosition.x, -95f - (float)n * 33f - 33f);
				this.text_tmpStr[13 + n].rectTransform.anchoredPosition = new Vector2(this.text_tmpStr[13 + n].rectTransform.anchoredPosition.x, -264f - (float)n * 33f - 33f);
				this.text_RA[n + 4].rectTransform.anchoredPosition = new Vector2(this.text_RA[n + 4].rectTransform.anchoredPosition.x, -264f - (float)n * 33f - 33f);
			}
		}
		else
		{
			for (int num4 = 0; num4 < 4; num4++)
			{
				this.text_tmpStr[9 + num4].rectTransform.anchoredPosition = new Vector2(this.text_tmpStr[9 + num4].rectTransform.anchoredPosition.x, -95f - (float)num4 * 33f);
				this.text_RA[num4].rectTransform.anchoredPosition = new Vector2(this.text_RA[num4].rectTransform.anchoredPosition.x, -95f - (float)num4 * 33f);
				this.text_tmpStr[13 + num4].rectTransform.anchoredPosition = new Vector2(this.text_tmpStr[13 + num4].rectTransform.anchoredPosition.x, -264f - (float)num4 * 33f);
				this.text_RA[num4 + 4].rectTransform.anchoredPosition = new Vector2(this.text_RA[num4 + 4].rectTransform.anchoredPosition.x, -264f - (float)num4 * 33f);
			}
		}
		if (flag2)
		{
			this.Cstr_RF.ClearString();
			this.Cstr_RF.Append(this.DM.mStringTable.GetStringByID(9788u));
			this.Cstr_RF.Append(this.DM.mStringTable.GetStringByID((uint)((ushort)(9778 + (int)this.AWM.m_CombatPlayerData[1].ArmyCoordIndex))));
			this.text_RF.text = this.Cstr_RF.ToString();
			this.text_RF.SetAllDirty();
			this.text_RF.cachedTextGenerator.Invalidate();
			this.text_RF.cachedTextGeneratorForLayout.Invalidate();
			float x2;
			if (this.text_RF.preferredWidth + 1f > 390f)
			{
				x2 = 390f;
			}
			else
			{
				x2 = this.text_RF.preferredWidth + 1f;
			}
			this.text_RF.rectTransform.sizeDelta = new Vector2(x2, this.text_RF.rectTransform.sizeDelta.y);
			if (this.GUIM.IsArabic)
			{
				this.text_RF.UpdateArabicPos();
			}
			this.tmpRC = this.btn_RF.transform.GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(x2, this.tmpRC.sizeDelta.y);
			this.Img_RF.rectTransform.sizeDelta = new Vector2(x2, this.Img_RF.rectTransform.sizeDelta.y);
			this.btn_RF.gameObject.SetActive(true);
		}
		else
		{
			this.btn_RF.gameObject.SetActive(false);
		}
		if (flag3)
		{
			this.tmpH -= 33f;
		}
		this.tmpH -= 498f;
		this.tmpH -= 281f;
		this.Cstr_Offensive[0].ClearString();
		this.Cstr_Offensive[1].ClearString();
		if (this.AWM.MyAllySide == 1)
		{
			this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(11163u));
			this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(11164u));
			this.text_ArmyTitle[0].text = this.DM.mStringTable.GetStringByID(5323u);
			this.text_ArmyTitle[1].text = this.DM.mStringTable.GetStringByID(5324u);
			this.Img_Summarybg[0].sprite = this.SArray.m_Sprites[2];
			this.Img_Summarybg[1].sprite = this.SArray.m_Sprites[3];
			this.Img_MainTitle[0].sprite = this.SArray.m_Sprites[6];
			this.Img_MainTitle[1].sprite = this.SArray.m_Sprites[7];
			this.Img_Army[0].sprite = this.SArray.m_Sprites[4];
			this.Img_Army2[0].sprite = this.SArray.m_Sprites[14];
			this.Img_Army[1].sprite = this.SArray.m_Sprites[5];
			this.Img_Army2[1].sprite = this.SArray.m_Sprites[15];
			this.Img_CWall[0].sprite = this.SArray.m_Sprites[4];
			this.Img_CWall[1].sprite = this.SArray.m_Sprites[5];
		}
		else if (this.AWM.MyAllySide == 2)
		{
			this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(11164u));
			this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(11163u));
			this.text_ArmyTitle[0].text = this.DM.mStringTable.GetStringByID(5324u);
			this.text_ArmyTitle[1].text = this.DM.mStringTable.GetStringByID(5323u);
			this.Img_Summarybg[0].sprite = this.SArray.m_Sprites[3];
			this.Img_Summarybg[1].sprite = this.SArray.m_Sprites[2];
			this.Img_MainTitle[0].sprite = this.SArray.m_Sprites[7];
			this.Img_MainTitle[1].sprite = this.SArray.m_Sprites[6];
			this.Img_Army[0].sprite = this.SArray.m_Sprites[5];
			this.Img_Army2[0].sprite = this.SArray.m_Sprites[15];
			this.Img_Army[1].sprite = this.SArray.m_Sprites[4];
			this.Img_Army2[1].sprite = this.SArray.m_Sprites[14];
			this.Img_CWall[0].sprite = this.SArray.m_Sprites[5];
			this.Img_CWall[1].sprite = this.SArray.m_Sprites[4];
		}
		this.text_Offensive[0].text = this.Cstr_Offensive[0].ToString();
		this.text_Offensive[0].SetAllDirty();
		this.text_Offensive[0].cachedTextGenerator.Invalidate();
		this.text_Offensive[1].text = this.Cstr_Offensive[1].ToString();
		this.text_Offensive[1].SetAllDirty();
		this.text_Offensive[1].cachedTextGenerator.Invalidate();
		this.text_ArmyTitle[0].SetAllDirty();
		this.text_ArmyTitle[0].cachedTextGenerator.Invalidate();
		this.text_ArmyTitle[1].SetAllDirty();
		this.text_ArmyTitle[1].cachedTextGenerator.Invalidate();
		this.QuanmieRT.gameObject.SetActive(false);
		this.tmpRC = this.btn_Details.transform.GetComponent<RectTransform>();
		this.tmpH += 100f;
		this.tmpH += 281f;
		this.tmpH -= this.tmpH2;
		if (flag3)
		{
			this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x, -783.5f - this.tmpH2);
		}
		else
		{
			this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x, -750.5f - this.tmpH2);
		}
		if (flag3)
		{
			this.Img_Army[0].rectTransform.sizeDelta = new Vector2(this.Img_Army[0].rectTransform.sizeDelta.x, 431f + this.tmpH2);
			this.Img_Army[1].rectTransform.sizeDelta = new Vector2(this.Img_Army[1].rectTransform.sizeDelta.x, 431f + this.tmpH2);
			this.text_NpcInfo.rectTransform.anchoredPosition = new Vector2(this.text_NpcInfo.rectTransform.anchoredPosition.x, -310f);
		}
		else
		{
			this.Img_Army[0].rectTransform.sizeDelta = new Vector2(this.Img_Army[0].rectTransform.sizeDelta.x, 398f + this.tmpH2);
			this.Img_Army[1].rectTransform.sizeDelta = new Vector2(this.Img_Army[1].rectTransform.sizeDelta.x, 398f + this.tmpH2);
			this.text_NpcInfo.rectTransform.anchoredPosition = new Vector2(this.text_NpcInfo.rectTransform.anchoredPosition.x, -277f);
		}
		for (int num5 = 0; num5 < 4; num5++)
		{
			this.text_tmpStr[13 + num5].gameObject.SetActive(false);
			this.text_RA[4 + num5].gameObject.SetActive(false);
		}
		this.Img_CWall_P[0].gameObject.SetActive(false);
		this.Img_CWall_P[1].gameObject.SetActive(false);
		for (int num6 = 0; num6 < 6; num6++)
		{
			this.text_tmpStr[17 + num6].gameObject.SetActive(false);
		}
		this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, -this.tmpH);
		this.btn_Replay.gameObject.SetActive(true);
		this.bSetFSShow = false;
		this.LightT1.gameObject.SetActive(true);
		this.text_Summary.gameObject.SetActive(true);
	}

	// Token: 0x06000EC3 RID: 3779 RVA: 0x0018BD44 File Offset: 0x00189F44
	public override void UpdateTime(bool bOnSecond)
	{
		if (!this.bSetFSShow && this.bInitFS && !this.bQuanmier && this.SummaryRT != null && !this.SummaryRT.gameObject.activeSelf)
		{
			this.SummaryRT.gameObject.SetActive(true);
			this.bSetFSShow = true;
		}
		if (this.btn_Replay != null && this.btn_Replay.IsActive())
		{
			this.ShowReplay += Time.smoothDeltaTime;
			if (this.ShowReplay >= 2f)
			{
				this.ShowReplay = 0f;
			}
			float a = (this.ShowReplay <= 1f) ? this.ShowReplay : (2f - this.ShowReplay);
			this.Img_RePlay.color = new Color(1f, 1f, 1f, a);
		}
		this.ShowMainHeroTime1 += Time.smoothDeltaTime;
		if (this.ShowMainHeroTime1 >= 0f)
		{
			if (this.ShowMainHeroTime1 >= 2f)
			{
				this.ShowMainHeroTime1 = 0f;
			}
			float a2 = (this.ShowMainHeroTime1 <= 1f) ? this.ShowMainHeroTime1 : (2f - this.ShowMainHeroTime1);
			if (this.Img_Crown[1] != null)
			{
				this.Img_Crown[1].color = new Color(1f, 1f, 1f, a2);
			}
			if (this.Img_BossHeroCrown[0] != null && this.Img_BossHeroCrown[0].IsActive())
			{
				this.Img_BossHeroCrown[1].color = new Color(1f, 1f, 1f, a2);
			}
		}
		this.ShowMainHeroTime2 += Time.smoothDeltaTime;
		if (this.ShowMainHeroTime2 >= 0f)
		{
			if (this.ShowMainHeroTime2 >= 2f)
			{
				this.ShowMainHeroTime2 = 0f;
			}
			float a3 = (this.ShowMainHeroTime2 <= 1f) ? this.ShowMainHeroTime2 : (2f - this.ShowMainHeroTime2);
			if (this.Img_Crown[3] != null)
			{
				this.Img_Crown[3].color = new Color(1f, 1f, 1f, a3);
			}
		}
		if (this.LightT1 != null)
		{
			this.LightT1.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
		this.ShowVsTime += Time.smoothDeltaTime;
		if (this.ShowVsTime >= 0f)
		{
			if (this.ShowVsTime >= 2f)
			{
				this.ShowVsTime = 0f;
			}
			float a4 = (this.ShowVsTime <= 1f) ? this.ShowVsTime : (2f - this.ShowVsTime);
			if (this.Img_Vs != null)
			{
				this.Img_Vs.color = new Color(1f, 1f, 1f, a4);
			}
		}
		if (this.LightT2 != null)
		{
			this.LightT2.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
	}

	// Token: 0x06000EC4 RID: 3780 RVA: 0x0018C0C4 File Offset: 0x0018A2C4
	private void SetPorfileBtn()
	{
		int num = 0;
		int num2 = 3;
		if (this.Img_MainHero != null && this.Img_MainHero[num] != null && this.Img_MainHero[num].transform.GetChild(0) != null)
		{
			UIButton component = this.Img_MainHero[num].transform.GetChild(0).gameObject.GetComponent<UIButton>();
			if (component != null)
			{
				component.m_Handler = this;
				component.m_BtnID1 = ((num != 0) ? 4 : 3);
				component.m_EffectType = e_EffectType.e_Scale;
				component.transition = Selectable.Transition.None;
			}
		}
		if (this.Img_MainHero != null && this.Img_MainHero[num2] != null && this.Img_MainHero[num2].transform.GetChild(0) != null)
		{
			UIButton component = this.Img_MainHero[num2].transform.GetChild(0).gameObject.GetComponent<UIButton>();
			if (component != null)
			{
				component.m_Handler = this;
				component.m_BtnID1 = ((num2 != 0) ? 4 : 3);
				component.m_EffectType = e_EffectType.e_Scale;
				component.transition = Selectable.Transition.None;
			}
		}
	}

	// Token: 0x06000EC5 RID: 3781 RVA: 0x0018C1F8 File Offset: 0x0018A3F8
	private void ShowLordProfile(Alliance_FS_btn type)
	{
		this.DM.PlayerName_War[0].Append(this.AWM.m_CombatPlayerData[0].Name);
		this.DM.PlayerName_War[1].Append(this.AWM.m_CombatPlayerData[1].Name);
		if (type == Alliance_FS_btn.btn_Porfile_Def)
		{
			if (this.AWM.m_CombatPlayerData[1].Name != string.Empty)
			{
				DataManager.Instance.ShowLordProfile(this.AWM.m_CombatPlayerData[1].Name);
			}
		}
		else if (type == Alliance_FS_btn.btn_Porfile_Atk && this.AWM.m_CombatPlayerData[0].Name != string.Empty)
		{
			DataManager.Instance.ShowLordProfile(this.AWM.m_CombatPlayerData[0].Name);
		}
	}

	// Token: 0x04002F8C RID: 12172
	private Transform GameT;

	// Token: 0x04002F8D RID: 12173
	private Transform Tmp;

	// Token: 0x04002F8E RID: 12174
	private Transform Tmp1;

	// Token: 0x04002F8F RID: 12175
	private Transform Tmp2;

	// Token: 0x04002F90 RID: 12176
	private Transform LightT1;

	// Token: 0x04002F91 RID: 12177
	private Transform LightT2;

	// Token: 0x04002F92 RID: 12178
	private Transform[] ItemT = new Transform[5];

	// Token: 0x04002F93 RID: 12179
	private Transform PreviousT;

	// Token: 0x04002F94 RID: 12180
	private Transform NextT;

	// Token: 0x04002F95 RID: 12181
	private Transform ItemBase;

	// Token: 0x04002F96 RID: 12182
	private Transform Mask_T;

	// Token: 0x04002F97 RID: 12183
	private GameObject mHead;

	// Token: 0x04002F98 RID: 12184
	private RectTransform tmpRC;

	// Token: 0x04002F99 RID: 12185
	private RectTransform ContentRT;

	// Token: 0x04002F9A RID: 12186
	private RectTransform ReplayerRT;

	// Token: 0x04002F9B RID: 12187
	private RectTransform ItemRT;

	// Token: 0x04002F9C RID: 12188
	private RectTransform ItemRT2;

	// Token: 0x04002F9D RID: 12189
	private RectTransform HeroRT;

	// Token: 0x04002F9E RID: 12190
	private RectTransform HeroBGRT;

	// Token: 0x04002F9F RID: 12191
	private RectTransform ResourcesRT;

	// Token: 0x04002FA0 RID: 12192
	private RectTransform SummaryRT;

	// Token: 0x04002FA1 RID: 12193
	private RectTransform QuanmieRT;

	// Token: 0x04002FA2 RID: 12194
	private UIButton btn_EXIT;

	// Token: 0x04002FA3 RID: 12195
	private UIButton btn_Previous;

	// Token: 0x04002FA4 RID: 12196
	private UIButton btn_Next;

	// Token: 0x04002FA5 RID: 12197
	private UIButton btn_Title;

	// Token: 0x04002FA6 RID: 12198
	private UIButton btn_Delete;

	// Token: 0x04002FA7 RID: 12199
	private UIButton btn_Collect;

	// Token: 0x04002FA8 RID: 12200
	private UIButton btn_Replay;

	// Token: 0x04002FA9 RID: 12201
	private UIButton btn_Details;

	// Token: 0x04002FAA RID: 12202
	private UIButton[] btn_Coordinate = new UIButton[2];

	// Token: 0x04002FAB RID: 12203
	private UIButton btn_LF;

	// Token: 0x04002FAC RID: 12204
	private UIButton btn_RF;

	// Token: 0x04002FAD RID: 12205
	private UIHIBtn[] btn_Itme = new UIHIBtn[30];

	// Token: 0x04002FAE RID: 12206
	private UILEBtn[] btn_Item_L = new UILEBtn[30];

	// Token: 0x04002FAF RID: 12207
	private UIHIBtn[] btn_Hero = new UIHIBtn[5];

	// Token: 0x04002FB0 RID: 12208
	private Image tmpImg;

	// Token: 0x04002FB1 RID: 12209
	private Image Img_Titlebg;

	// Token: 0x04002FB2 RID: 12210
	private Image Img_MainHerobg;

	// Token: 0x04002FB3 RID: 12211
	private Image Img_RePlay;

	// Token: 0x04002FB4 RID: 12212
	private Image Img_Vs;

	// Token: 0x04002FB5 RID: 12213
	private Image[] Img_Summarybg = new Image[2];

	// Token: 0x04002FB6 RID: 12214
	private Image[] Img_Crown = new Image[4];

	// Token: 0x04002FB7 RID: 12215
	private Image[] Img_MainHero = new Image[6];

	// Token: 0x04002FB8 RID: 12216
	private Image[] Img_MainTitle = new Image[2];

	// Token: 0x04002FB9 RID: 12217
	private Image[] Img_Muster = new Image[2];

	// Token: 0x04002FBA RID: 12218
	private Image[] Img_Country = new Image[2];

	// Token: 0x04002FBB RID: 12219
	private Image[] Img_Rank = new Image[2];

	// Token: 0x04002FBC RID: 12220
	private Image[] Img_Army = new Image[2];

	// Token: 0x04002FBD RID: 12221
	private Image[] Img_Army2 = new Image[2];

	// Token: 0x04002FBE RID: 12222
	private Image[] Img_CWall = new Image[2];

	// Token: 0x04002FBF RID: 12223
	private Image[] Img_CWall_P = new Image[2];

	// Token: 0x04002FC0 RID: 12224
	private Image[] Img_Vip = new Image[2];

	// Token: 0x04002FC1 RID: 12225
	private Image[] Img_BossHeroCrown = new Image[2];

	// Token: 0x04002FC2 RID: 12226
	private Image[] Img_BossIcon = new Image[2];

	// Token: 0x04002FC3 RID: 12227
	private Image Img_Quanmie;

	// Token: 0x04002FC4 RID: 12228
	private Image Img_Exp;

	// Token: 0x04002FC5 RID: 12229
	private Image Img_LF;

	// Token: 0x04002FC6 RID: 12230
	private Image Img_RF;

	// Token: 0x04002FC7 RID: 12231
	private Image Img_FormationHint;

	// Token: 0x04002FC8 RID: 12232
	private CScrollRect m_Mask;

	// Token: 0x04002FC9 RID: 12233
	private UIText tmptext;

	// Token: 0x04002FCA RID: 12234
	private UIText text_Coordinate;

	// Token: 0x04002FCB RID: 12235
	private UIText text_TitleName;

	// Token: 0x04002FCC RID: 12236
	private UIText text_Page;

	// Token: 0x04002FCD RID: 12237
	private UIText text_Summary;

	// Token: 0x04002FCE RID: 12238
	private UIText text_MainHero;

	// Token: 0x04002FCF RID: 12239
	private UIText text_TitleItem;

	// Token: 0x04002FD0 RID: 12240
	private UIText text_FightingKind;

	// Token: 0x04002FD1 RID: 12241
	private UIText text_L_Exp;

	// Token: 0x04002FD2 RID: 12242
	private UIText[] text_Time = new UIText[2];

	// Token: 0x04002FD3 RID: 12243
	private UIText[] text_ItemQty = new UIText[30];

	// Token: 0x04002FD4 RID: 12244
	private UIText[] text_Offensive = new UIText[2];

	// Token: 0x04002FD5 RID: 12245
	private UIText[] text_LossValue = new UIText[2];

	// Token: 0x04002FD6 RID: 12246
	private UIText[] text_ArmyTitle = new UIText[2];

	// Token: 0x04002FD7 RID: 12247
	private UIText[] text_Strength = new UIText[2];

	// Token: 0x04002FD8 RID: 12248
	private UIText[] text_Country = new UIText[2];

	// Token: 0x04002FD9 RID: 12249
	private UIText[] text_Dominance = new UIText[2];

	// Token: 0x04002FDA RID: 12250
	private UIText[] text_Name = new UIText[2];

	// Token: 0x04002FDB RID: 12251
	private UIText[] text_MainHero_F = new UIText[2];

	// Token: 0x04002FDC RID: 12252
	private UIText[] text_Vip = new UIText[2];

	// Token: 0x04002FDD RID: 12253
	private UIText[] text_LA = new UIText[4];

	// Token: 0x04002FDE RID: 12254
	private UIText[] text_RA = new UIText[8];

	// Token: 0x04002FDF RID: 12255
	private UIText[] text_DW = new UIText[3];

	// Token: 0x04002FE0 RID: 12256
	private UIText[] text_Resources = new UIText[5];

	// Token: 0x04002FE1 RID: 12257
	private UIText[] text_HeroExp = new UIText[5];

	// Token: 0x04002FE2 RID: 12258
	private UIText[] text_HeroExp2 = new UIText[5];

	// Token: 0x04002FE3 RID: 12259
	private UIText[] text_CoordinateMainHero = new UIText[2];

	// Token: 0x04002FE4 RID: 12260
	private UIText[] text_tmpStr = new UIText[25];

	// Token: 0x04002FE5 RID: 12261
	private UIText[] text_Quanmie = new UIText[8];

	// Token: 0x04002FE6 RID: 12262
	private UIText[] text_BossTitle = new UIText[2];

	// Token: 0x04002FE7 RID: 12263
	private UIText[] text_BossL = new UIText[2];

	// Token: 0x04002FE8 RID: 12264
	private UIText[] text_BossR = new UIText[3];

	// Token: 0x04002FE9 RID: 12265
	private UIText[] text_BossFight = new UIText[3];

	// Token: 0x04002FEA RID: 12266
	private UIText text_LF;

	// Token: 0x04002FEB RID: 12267
	private UIText text_RF;

	// Token: 0x04002FEC RID: 12268
	private UIText text_Formation;

	// Token: 0x04002FED RID: 12269
	private CString[] Cstr_Coordinate = new CString[2];

	// Token: 0x04002FEE RID: 12270
	private CString Cstr_TitleName;

	// Token: 0x04002FEF RID: 12271
	private CString Cstr_FightingKind;

	// Token: 0x04002FF0 RID: 12272
	private CString Cstr_L_Exp;

	// Token: 0x04002FF1 RID: 12273
	private CString[] Cstr_ItemQty = new CString[30];

	// Token: 0x04002FF2 RID: 12274
	private CString[] Cstr_Offensive = new CString[2];

	// Token: 0x04002FF3 RID: 12275
	private CString[] Cstr_LossValue = new CString[2];

	// Token: 0x04002FF4 RID: 12276
	private CString[] Cstr_Strength = new CString[2];

	// Token: 0x04002FF5 RID: 12277
	private CString[] Cstr_Country = new CString[2];

	// Token: 0x04002FF6 RID: 12278
	private CString[] Cstr_Dominance = new CString[2];

	// Token: 0x04002FF7 RID: 12279
	private CString[] Cstr_CoordinateMainHero = new CString[2];

	// Token: 0x04002FF8 RID: 12280
	private CString[] Cstr_Name = new CString[2];

	// Token: 0x04002FF9 RID: 12281
	private CString[] Cstr_LA = new CString[4];

	// Token: 0x04002FFA RID: 12282
	private CString[] Cstr_RA = new CString[8];

	// Token: 0x04002FFB RID: 12283
	private CString[] Cstr_DW = new CString[3];

	// Token: 0x04002FFC RID: 12284
	private CString[] Cstr_BossR = new CString[2];

	// Token: 0x04002FFD RID: 12285
	private CString[] Cstr_BossFight = new CString[2];

	// Token: 0x04002FFE RID: 12286
	private CString[] Cstr_BossL = new CString[2];

	// Token: 0x04002FFF RID: 12287
	private CString Cstr_BoosHead;

	// Token: 0x04003000 RID: 12288
	private CString Cstr_Text;

	// Token: 0x04003001 RID: 12289
	private CString[] Cstr_Quanmie = new CString[4];

	// Token: 0x04003002 RID: 12290
	private CString Cstr_NpcTroops;

	// Token: 0x04003003 RID: 12291
	private CString Cstr_QuanmieNpcTroops;

	// Token: 0x04003004 RID: 12292
	private CString Cstr_LF;

	// Token: 0x04003005 RID: 12293
	private CString Cstr_RF;

	// Token: 0x04003006 RID: 12294
	private DataManager DM;

	// Token: 0x04003007 RID: 12295
	private GUIManager GUIM;

	// Token: 0x04003008 RID: 12296
	private AllianceWarManager AWM;

	// Token: 0x04003009 RID: 12297
	private Font TTFont;

	// Token: 0x0400300A RID: 12298
	private Door door;

	// Token: 0x0400300B RID: 12299
	private UISpritesArray SArray;

	// Token: 0x0400300C RID: 12300
	private Material mMaT;

	// Token: 0x0400300D RID: 12301
	private Material IconMaterial;

	// Token: 0x0400300E RID: 12302
	private Material FrameMaterial;

	// Token: 0x0400300F RID: 12303
	private float tmpH;

	// Token: 0x04003010 RID: 12304
	private float tmpH2 = 120f;

	// Token: 0x04003011 RID: 12305
	private bool bQuanmier;

	// Token: 0x04003012 RID: 12306
	private bool IsAttack = true;

	// Token: 0x04003013 RID: 12307
	private float ShowMainHeroTime1;

	// Token: 0x04003014 RID: 12308
	private float ShowMainHeroTime2;

	// Token: 0x04003015 RID: 12309
	private float ShowVsTime;

	// Token: 0x04003016 RID: 12310
	private float ShowReplay;

	// Token: 0x04003017 RID: 12311
	private float tempL;

	// Token: 0x04003018 RID: 12312
	private Hero tmpHero;

	// Token: 0x04003019 RID: 12313
	private uint[] tmpHeroExp = new uint[5];

	// Token: 0x0400301A RID: 12314
	private ushort[] tmpHeroID = new ushort[5];

	// Token: 0x0400301B RID: 12315
	private byte[] tmpHeroStar = new byte[5];

	// Token: 0x0400301C RID: 12316
	private ushort[] ItemID = new ushort[30];

	// Token: 0x0400301D RID: 12317
	private ushort[] ItemNum = new ushort[30];

	// Token: 0x0400301E RID: 12318
	private byte[] ItemRank = new byte[30];

	// Token: 0x0400301F RID: 12319
	private int AssetKey;

	// Token: 0x04003020 RID: 12320
	private bool bInitFS;

	// Token: 0x04003021 RID: 12321
	private bool bSetFSShow;

	// Token: 0x04003022 RID: 12322
	private bool[] bSetHero = new bool[5];

	// Token: 0x04003023 RID: 12323
	private RectTransform NpcItemRT;

	// Token: 0x04003024 RID: 12324
	private UIButton btn_NpcItemIcon;

	// Token: 0x04003025 RID: 12325
	private UIButton btn_NpcItemName;

	// Token: 0x04003026 RID: 12326
	private UIButton btn_NpcCoordinate;

	// Token: 0x04003027 RID: 12327
	private Image[] Img_NpcMainHero = new Image[3];

	// Token: 0x04003028 RID: 12328
	private Image Img_NpcItemHint;

	// Token: 0x04003029 RID: 12329
	private UIText text_NpcInfo;

	// Token: 0x0400302A RID: 12330
	private UIText text_QuanmierNpcInfo;

	// Token: 0x0400302B RID: 12331
	private UIText text_NpcCoordinate;

	// Token: 0x0400302C RID: 12332
	private UIText text_NpcName;

	// Token: 0x0400302D RID: 12333
	private UIText text_NpcItemName;

	// Token: 0x0400302E RID: 12334
	private UIText text_NpcItemfull;

	// Token: 0x0400302F RID: 12335
	private UIText text_NpcItemHint;

	// Token: 0x04003030 RID: 12336
	private UIText[] text_NpcTroops = new UIText[2];

	// Token: 0x04003031 RID: 12337
	private UIText[] text_QuanmierNpcTroops = new UIText[2];

	// Token: 0x04003032 RID: 12338
	private RectTransform AllianceBossItemRT;

	// Token: 0x04003033 RID: 12339
	private UIText text_AllianceBossStr;
}
