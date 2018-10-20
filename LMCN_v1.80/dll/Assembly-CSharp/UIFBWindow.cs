using System;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x02000411 RID: 1041
public class UIFBWindow : GUIWindow, IAERunnerEndHandler, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x06001537 RID: 5431 RVA: 0x002422E4 File Offset: 0x002404E4
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.GameT = base.gameObject.transform;
		this.m_Mat = this.door.LoadMaterial();
		this.FrameMaterial = this.GUIM.GetFrameMaterial();
		this.IconMaterial = this.GUIM.m_IconSpriteAsset.GetMaterial();
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.Tmp = this.GameT.GetChild(0).GetChild(6).GetChild(0);
		this.text_Title = this.Tmp.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.text = this.DM.mStringTable.GetStringByID(12178u);
		this.Tmp = this.GameT.GetChild(1).GetChild(0).GetChild(0);
		this.text_HelpTitle = this.Tmp.GetComponent<UIText>();
		this.text_HelpTitle.text = this.DM.mStringTable.GetStringByID(12187u);
		this.text_HelpTitle.font = this.TTFont;
		this.Tmp = this.GameT.GetChild(1).GetChild(1).GetChild(0);
		this.ContentRT = this.Tmp.GetComponent<RectTransform>();
		float num = 0f;
		for (int i = 0; i < 3; i++)
		{
			this.text_HelpText[i] = this.Tmp.GetChild(i).GetComponent<UIText>();
			this.text_HelpText[i].font = this.TTFont;
			if (i == 0)
			{
				this.text_HelpText[i].text = this.DM.mStringTable.GetStringByID(12181u);
			}
			else if (i == 1)
			{
				this.text_HelpText[i].text = this.DM.mStringTable.GetStringByID(12199u);
			}
			else
			{
				this.text_HelpText[i].text = this.DM.mStringTable.GetStringByID(12200u);
			}
			this.text_HelpText[i].SetAllDirty();
			this.text_HelpText[i].cachedTextGenerator.Invalidate();
			this.text_HelpText[i].cachedTextGeneratorForLayout.Invalidate();
			if (i > 0)
			{
				this.text_HelpText[i].rectTransform.anchoredPosition = new Vector2(this.text_HelpText[i].rectTransform.anchoredPosition.x, -num);
			}
			this.text_HelpText[i].rectTransform.sizeDelta = new Vector2(this.text_HelpText[i].rectTransform.sizeDelta.x, this.text_HelpText[i].preferredHeight + 1f);
			num += this.text_HelpText[i].rectTransform.sizeDelta.y;
		}
		this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, num);
		this.Tmp = this.GameT.GetChild(0).GetChild(7);
		this.btn_I = this.Tmp.GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_I.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_I.m_BtnID1 = 1;
		this.btn_I.m_EffectType = e_EffectType.e_Scale;
		this.btn_I.transition = Selectable.Transition.None;
		this.btn_I.m_Handler = this;
		this.GifeT = this.GameT.GetChild(0).GetChild(8);
		this.Light1_T = this.GifeT.GetChild(0);
		this.Light2_T = this.GifeT.GetChild(1);
		this.Tmp = this.GifeT.GetChild(2);
		this.btnBondGift = this.Tmp.GetComponent<UIButton>();
		this.btnBondGift.m_BtnID1 = 11;
		this.btnBondGift.m_EffectType = e_EffectType.e_Scale;
		this.btnBondGift.transition = Selectable.Transition.None;
		this.btnBondGift.m_Handler = this;
		this.Tmp = this.GifeT.GetChild(3);
		this.btnFB = this.Tmp.GetComponent<UIButton>();
		this.btnFB.m_Handler = this;
		this.btnFB.m_BtnID1 = 7;
		this.btnFB.m_EffectType = e_EffectType.e_Scale;
		this.btnFB.transition = Selectable.Transition.None;
		this.text_FB_Gift = this.Tmp.GetChild(1).GetComponent<UIText>();
		this.text_FB_Gift.font = this.TTFont;
		this.text_FB_Gift.text = this.DM.mStringTable.GetStringByID(12146u);
		if (this.text_FB_Gift.preferredWidth > 140f)
		{
			this.text_FB_Gift.rectTransform.sizeDelta = new Vector2(this.text_FB_Gift.rectTransform.sizeDelta.x, 60f);
		}
		this.Tmp = this.GifeT.GetChild(4);
		this.btnReceive = this.Tmp.GetComponent<UIButton>();
		this.btnReceive.m_BtnID1 = 8;
		this.btnReceive.m_EffectType = e_EffectType.e_Scale;
		this.btnReceive.transition = Selectable.Transition.None;
		RectTransform component = this.btnFB.GetComponent<RectTransform>();
		Vector2 vector = this.btnReceive.GetComponent<RectTransform>().pivot;
		this.btnFB.GetComponent<RectTransform>().pivot = vector;
		vector = vector;
		this.btnFB.GetComponent<RectTransform>().anchorMin = vector;
		component.anchorMax = vector;
		this.btnFB.transform.localPosition = this.btnReceive.transform.localPosition;
		this.btnReceive.m_Handler = this;
		this.text_FB_btnReceive = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.text_FB_btnReceive.font = this.TTFont;
		this.text_FB_btnReceive.text = this.DM.mStringTable.GetStringByID(12149u);
		this.Tmp = this.GifeT.GetChild(5);
		this.ImgFBGiftReceive = this.Tmp.GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.ImgFBGiftReceive.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.text_FB_Receive = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.text_FB_Receive.font = this.TTFont;
		this.text_FB_Receive.text = this.DM.mStringTable.GetStringByID(12151u);
		this.Tmp = this.GameT.GetChild(0).GetChild(10);
		Image component2 = this.Tmp.GetComponent<Image>();
		component2.sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, 11);
		component2.material = this.FrameMaterial;
		this.Tmp.gameObject.SetActive(false);
		this.PiggyHead = this.Tmp.GetChild(0).gameObject.AddComponent<UIHIBtn>();
		this.Tmp.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(86f, 86f);
		GUIManager.Instance.InitianHeroItemImg(this.Tmp.GetChild(0), eHeroOrItem.Hero, 0, 0, 0, 0, false, false, true, false);
		this.Img_Head = this.Tmp.GetChild(0).GetComponent<Image>();
		this.PiggyHead.HIImage.material = this.IconMaterial;
		this.Img_Head.material = this.IconMaterial;
		this.Img_PigHead = this.PiggyHead.HIImage;
		this.Img_Headload = this.Tmp.GetChild(1).GetComponent<Image>();
		this.Img_Headloading = this.Tmp.GetChild(1).GetChild(0).GetComponent<Image>();
		this.Tmp = this.GameT.GetChild(0).GetChild(11);
		this.Img_Recommend = this.Tmp.GetComponent<Image>();
		this.text_Recommend = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.text_Recommend.font = this.TTFont;
		this.text_Recommend.text = this.DM.mStringTable.GetStringByID(12147u);
		this.Tmp = this.GameT.GetChild(0).GetChild(12);
		this.ImgDialogbox1 = this.Tmp.GetComponent<Image>();
		this.text_Dialogbox1 = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.text_Dialogbox1.font = this.TTFont;
		this.Tmp = this.GameT.GetChild(0).GetChild(13);
		this.ImgDialogbox2 = this.Tmp.GetComponent<Image>();
		for (int j = 0; j < 4; j++)
		{
			this.text_Dialogbox2_Mission[j] = this.Tmp.GetChild(j).GetComponent<UIText>();
			this.text_Dialogbox2_Mission[j].rectTransform.sizeDelta = new Vector2((float)((j <= 1) ? 420 : 318), this.text_Dialogbox2_Mission[j].rectTransform.sizeDelta.y);
			this.text_Dialogbox2_Mission[j].font = this.TTFont;
			this.text_Dialogbox2_Mission[j].AdjuestUI();
		}
		for (int k = 0; k < 2; k++)
		{
			this.ImgDialogbox2_Degree[k] = this.Tmp.GetChild(4 + k).GetComponent<Image>();
			this.ImgDialogbox2_Degree[k].gameObject.SetActive(true);
			if (this.GUIM.IsArabic)
			{
				this.ImgDialogbox2_Degree[k].gameObject.AddComponent<ArabicItemTextureRot>();
			}
			this.text_Dialogbox2_Degree[k] = this.Tmp.GetChild(6 + k).GetComponent<UIText>();
			this.text_Dialogbox2_Degree[k].alignment = TextAnchor.MiddleCenter;
			this.text_Dialogbox2_Degree[k].rectTransform.sizeDelta = new Vector2(110f, 21f);
			this.text_Dialogbox2_Degree[k].resizeTextMaxSize = 16;
			this.text_Dialogbox2_Degree[k].font = this.TTFont;
			this.text_Dialogbox2_Degree[k].AdjuestUI();
		}
		this.Tmp = this.GameT.GetChild(0).GetChild(14);
		this.ImgDialogboxEnd = this.Tmp.GetComponent<Image>();
		for (int l = 0; l < 2; l++)
		{
			this.text_DialogboxEnd[l] = this.Tmp.GetChild(l).GetComponent<UIText>();
			this.text_DialogboxEnd[l].font = this.TTFont;
		}
		this.FB_T = this.GameT.GetChild(0).GetChild(15);
		this.text_FB_Name = this.FB_T.GetChild(0).GetComponent<UIText>();
		this.text_FB_Name.font = this.TTFont;
		this.text_FB_Name.alignment = TextAnchor.MiddleCenter;
		this.btn_FB_Tag = this.FB_T.GetChild(1).GetComponent<UIButton>();
		this.btn_FB_Tag.m_BtnID1 = 2;
		this.btn_FB_TagRT = this.FB_T.GetChild(1).GetComponent<RectTransform>();
		this.btn_FB_Tag.m_Handler = this;
		this.ImgFB_Tag_Line = this.FB_T.GetChild(1).GetChild(0).GetComponent<Image>();
		this.text_FB_Tag = this.FB_T.GetChild(1).GetChild(1).GetComponent<UIText>();
		this.text_FB_Tag.font = this.TTFont;
		this.text_FB_Tag.resizeTextForBestFit = false;
		this.text_FB_Tag.rectTransform.sizeDelta = new Vector2(this.text_FB_Tag.rectTransform.sizeDelta.x, 28f);
		this.NPC_T = this.GameT.GetChild(0).GetChild(16);
		this.text_Npc_Name = this.NPC_T.GetChild(0).GetComponent<UIText>();
		this.text_Npc_Name.alignment = TextAnchor.MiddleCenter;
		this.text_Npc_Name.font = this.TTFont;
		this.text_Npc_Tag = this.NPC_T.GetChild(1).GetComponent<UIText>();
		this.text_Npc_Tag.rectTransform.sizeDelta = this.text_Npc_Name.rectTransform.sizeDelta;
		this.text_Npc_Tag.font = this.TTFont;
		this.Tmp = this.GameT.GetChild(0).GetChild(17);
		this.btnMissionGift = this.Tmp.GetComponent<UIButton>();
		this.btnMissionGift.m_BtnID1 = 3;
		this.btnMissionGift.m_EffectType = e_EffectType.e_Scale;
		this.btnMissionGift.transition = Selectable.Transition.None;
		this.btnMissionGift.m_Handler = this;
		this.ImgMissionGift_Info = this.Tmp.GetChild(1).GetChild(0).GetComponent<Image>();
		this.Tmp.GetChild(0).GetComponent<UIButton>().enabled = false;
		this.Tmp = this.GameT.GetChild(0).GetChild(18);
		this.btnMissionGiftFinal = this.Tmp.GetComponent<UIButton>();
		this.btnMissionGiftFinal.m_BtnID1 = 4;
		this.btnMissionGiftFinal.m_EffectType = e_EffectType.e_Scale;
		this.btnMissionGiftFinal.transition = Selectable.Transition.None;
		this.btnMissionGiftFinal.m_Handler = this;
		this.Tmp = this.GameT.GetChild(0).GetChild(19);
		this.btnMissionReceive1 = this.Tmp.GetComponent<UIButton>();
		this.btnMissionReceive1.m_BtnID1 = 5;
		this.btnMissionReceive1.m_EffectType = e_EffectType.e_Scale;
		this.btnMissionReceive1.transition = Selectable.Transition.None;
		this.btnMissionReceive1.m_Handler = this;
		this.btnMissionReceive1.GetComponent<RectTransform>().anchoredPosition = new Vector2(315f, -245f);
		this.text_btnMissionReceive1 = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.text_btnMissionReceive1.font = this.TTFont;
		this.text_btnMissionReceive1.text = this.DM.mStringTable.GetStringByID(12149u);
		this.Tmp = this.GameT.GetChild(0).GetChild(20);
		this.btnMissionReceive2 = this.Tmp.GetComponent<UIButton>();
		this.btnMissionReceive2.m_BtnID1 = 6;
		this.btnMissionReceive2.m_EffectType = e_EffectType.e_Scale;
		this.btnMissionReceive2.transition = Selectable.Transition.None;
		this.btnMissionReceive2.m_Handler = this;
		this.btnMissionReceive2.GetComponent<RectTransform>().anchoredPosition = new Vector2(315f, -245f);
		this.text_btnMissionReceive2 = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.text_btnMissionReceive2.font = this.TTFont;
		this.text_btnMissionReceive2.text = this.DM.mStringTable.GetStringByID(12149u);
		this.Img_GiftNum = this.Tmp.GetChild(1).GetComponent<Image>();
		this.text_GiftNum = this.Tmp.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_GiftNum.font = this.TTFont;
		this.ImgMissionGiftFinal_Info = this.Tmp.GetChild(1).GetChild(0).GetComponent<Image>();
		this.MissionMap_T = this.GameT.GetChild(0).GetChild(21);
		this.Tmp = this.MissionMap_T.GetChild(0);
		this.Img_TimeCD = this.Tmp.GetComponent<Image>();
		this.text_Time[0] = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.text_Time[0].font = this.TTFont;
		this.text_Time[0].text = this.DM.mStringTable.GetStringByID(546u);
		this.text_Time[1] = this.Tmp.GetChild(1).GetComponent<UIText>();
		this.text_Time[1].font = this.TTFont;
		this.Tmp = this.MissionMap_T.GetChild(1);
		this.Img_TimeOut = this.Tmp.GetComponent<Image>();
		this.text_TimeOut = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.text_TimeOut.font = this.TTFont;
		this.text_TimeOut.text = this.DM.mStringTable.GetStringByID(12179u);
		this.TimeStr = StringManager.Instance.SpawnString(30);
		this.NameStr = StringManager.Instance.SpawnString(100);
		this.Goal1Str = StringManager.Instance.SpawnString(30);
		this.Goal2Str = StringManager.Instance.SpawnString(30);
		this.Node1Str = StringManager.Instance.SpawnString(150);
		this.Node2Str = StringManager.Instance.SpawnString(150);
		this.FinishStr = StringManager.Instance.SpawnString(250);
		this.HintStr = StringManager.Instance.SpawnString(150);
		this.HelpStr = StringManager.Instance.SpawnString(150);
		this.HourStr = StringManager.Instance.SpawnString(150);
		this.FBUIHint = new UIFBHint();
		this.MissionLine_T = this.MissionMap_T.GetChild(2);
		Color effectColor = new Color(0f, 0f, 0f, 0.75f);
		Outline outline;
		for (int m = 0; m < 10; m++)
		{
			this.Remaining[m] = StringManager.Instance.SpawnString(30);
			this.Tmp = this.MissionLine_T.GetChild(31 + m);
			this.Tmp.GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
			this.Img_MissionInfo[m] = this.Tmp.GetComponent<Image>();
			this.Hint = this.Tmp.gameObject.AddComponent<UIButtonHint>();
			this.Hint.m_eHint = EUIButtonHint.DownUpHandler;
			this.Hint.m_Handler = this;
			this.Hint.Parm1 = (ushort)(m + 1);
			this.Hint.ControlFadeOut = this.FBUIHint.gameobject;
			this.Tmp = this.MissionLine_T.GetChild(41 + m);
			this.Tmp.gameObject.SetActive(true);
			this.Tmp.localPosition -= new Vector3(0f, 0f, 700f);
			this.Tmp = this.MissionLine_T.GetChild(41 + m).GetChild(0);
			this.Tmp.GetChild(0).gameObject.AddComponent<UIHIBtn>().enabled = false;
			this.Tmp.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(54f, 54f);
			GUIManager.Instance.InitianHeroItemImg(this.Tmp.GetChild(0), eHeroOrItem.Hero, 0, 0, 0, 0, false, false, true, false);
			this.Hint = this.Tmp.gameObject.AddComponent<UIButtonHint>();
			this.Hint.m_eHint = EUIButtonHint.DownUpHandler;
			this.Hint.m_Handler = this;
			this.Hint.Parm1 = (ushort)(m + 1);
			this.Hint.Parm2 = 1;
			this.Hint.ControlFadeOut = this.FBUIHint.gameobject;
			this.mMissionHead[m].BG = this.Tmp.GetComponent<Image>();
			this.mMissionHead[m].Head = this.Tmp.GetChild(0).GetComponent<Image>();
			this.mMissionHead[m].Time = this.Tmp.GetChild(1).GetComponent<Image>();
			this.mMissionHead[m].text_MH_Time = this.Tmp.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.mMissionHead[m].text_MH_Time.font = this.TTFont;
			outline = this.Tmp.GetChild(1).GetChild(0).gameObject.AddComponent<Outline>();
			outline.effectColor = effectColor;
			this.mMissionHead[m].Load = this.Tmp.GetChild(2).GetComponent<Image>();
			this.mMissionHead[m].Runner = new AERunner[3];
			this.mMissionHead[m].HeadImages = new Image[2];
			this.mMissionHead[m].HeadImages[0] = this.mMissionHead[m].BG;
			this.mMissionHead[m].HeadImages[1] = this.mMissionHead[m].Time;
			this.mMissionHead[m].TickImages = new Image[1];
			this.mMissionHead[m].TickImages[0] = this.Img_MissionInfo[m].transform.GetChild(0).GetComponent<Image>();
			this.mPosition[m] = this.MissionLine_T.GetChild(31 + m).GetChild(2).gameObject;
			this.mPosition[m].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>().font = this.TTFont;
			this.mPosition[m].transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
			this.mPosition[m].transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
			this.mPosition[m].transform.localPosition -= new Vector3(0f, 0f, 700f);
			this.mPosition[m].gameObject.SetActive(true);
			this.Hint = this.mPosition[m].gameObject.AddComponent<UIButtonHint>();
			this.Hint.m_Handler = this;
			this.Hint.m_eHint = EUIButtonHint.DownUpHandler;
			this.Hint.ControlFadeOut = this.FBUIHint.gameobject;
			this.Hint.Parm1 = (ushort)(m + 1);
			this.Hint.Parm2 = 2;
			this.mFriendsHead[m].Canvas = this.mPosition[m].AddComponent<CanvasGroup>();
			this.mFriendsHead[m].Time = this.mPosition[m].transform.GetChild(0).GetChild(1).GetComponent<Image>();
			this.mFriendsHead[m].text_MH_Time = this.mPosition[m].transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
			this.mFriendsHead[m].Canvas.alpha = 0f;
		}
		this.Tmp = this.MissionMap_T.GetChild(3);
		this.Img_Castle = this.Tmp.GetComponent<Image>();
		this.Tmp = this.MissionMap_T.GetChild(4);
		this.btnMissionMapinal = this.Tmp.GetComponent<UIButton>();
		this.btnMissionMapinal.m_BtnID1 = 9;
		this.btnMissionMapinal.transition = Selectable.Transition.None;
		this.Hint = this.Tmp.gameObject.AddComponent<UIButtonHint>();
		this.Hint.ControlFadeOut = this.FBUIHint.gameobject;
		this.Hint.m_eHint = EUIButtonHint.DownUpHandler;
		this.Hint.m_Handler = this;
		this.Hint.Parm1 = 11;
		this.Tmp = this.MissionMap_T.GetChild(11);
		this.btnInviteGift = this.Tmp.GetComponent<UIButton>();
		this.btnInviteGift.m_BtnID1 = 12;
		this.btnInviteGift.m_Handler = this;
		this.btnInviteGift.m_EffectType = e_EffectType.e_Scale;
		this.btnInviteGift.transition = Selectable.Transition.None;
		this.Tmp = this.MissionMap_T.GetChild(5);
		this.btnInvite = this.Tmp.GetComponent<UIButton>();
		this.btnInvite.m_BtnID1 = 10;
		this.btnInvite.m_Handler = this;
		this.btnInvite.m_EffectType = e_EffectType.e_Scale;
		this.btnInvite.transition = Selectable.Transition.None;
		this.btnInvite.gameObject.SetActive(SocialManager.Instance.CanShowInvite());
		this.text_Invite = this.Tmp.GetChild(1).GetComponent<UIText>();
		this.text_Invite.font = this.TTFont;
		this.text_Invite.text = this.DM.mStringTable.GetStringByID(12154u);
		this.Tmp = this.MissionMap_T.GetChild(6);
		this.Tmp.localPosition -= new Vector3(0f, 0f, 700f);
		this.Tmp.gameObject.SetActive(true);
		this.Tmp = this.MissionMap_T.GetChild(6).GetChild(0);
		this.Img_MissionFinalHeadBG = this.Tmp.GetComponent<Image>();
		this.Img_MissionFinalHeadBG.type = Image.Type.Tiled;
		this.Img_MissionFinalHeadBG.rectTransform.sizeDelta = this.mMissionHead[0].BG.rectTransform.sizeDelta;
		this.Img_MissionFinalHeadBG.rectTransform.localPosition -= new Vector3(-4f, 6f, 0f);
		this.Img_MissionFinalHead = this.Tmp.GetChild(0).GetComponent<Image>();
		this.Img_MissionFinalHead.rectTransform.anchoredPosition += new Vector2(4f, 3f);
		this.Tmp.GetComponent<Image>().sprite = this.SArray.GetSprite(0);
		this.Hint = this.Tmp.gameObject.AddComponent<UIButtonHint>();
		this.Hint.ControlFadeOut = this.FBUIHint.gameobject;
		this.Hint.m_eHint = EUIButtonHint.DownUpHandler;
		this.Hint.m_Handler = this;
		this.Hint.Parm2 = 1;
		this.Tmp.GetChild(1).gameObject.SetActive(false);
		this.Tmp.GetChild(0).gameObject.SetActive(false);
		this.mFriendsHead[10].Canvas = this.Tmp.gameObject.AddComponent<CanvasGroup>();
		this.mFriends[10] = this.Tmp.gameObject;
		this.mFriendHead = this.Tmp.localPosition;
		this.Tmp = this.MissionMap_T.GetChild(6).GetChild(1);
		this.Img_MissionFinalHeadBG = this.Tmp.GetComponent<Image>();
		this.Img_MissionFinalHeadBG.type = Image.Type.Tiled;
		this.Img_MissionFinalHeadBG.rectTransform.sizeDelta = this.mMissionHead[0].BG.rectTransform.sizeDelta;
		this.Img_MissionFinalHeadBG.rectTransform.localPosition -= new Vector3(-4f, 6f, 0f);
		this.Img_MissionFinalHead = this.Tmp.GetChild(0).GetComponent<Image>();
		this.Img_MissionFinalHead.rectTransform.anchoredPosition += new Vector2(4f, 3f);
		this.Tmp.GetComponent<Image>().sprite = this.SArray.GetSprite(0);
		this.Tmp.GetChild(1).gameObject.SetActive(false);
		this.Tmp.GetChild(0).gameObject.SetActive(false);
		this.mPosition[10] = this.Tmp.gameObject;
		this.Tmp = this.MissionMap_T.GetChild(7);
		this.Tmp.localPosition -= new Vector3(0f, 0f, 700f);
		this.Tmp.gameObject.SetActive(true);
		this.Tmp = this.MissionMap_T.GetChild(7).GetChild(0);
		this.Img_MissionFinalHeadBG = this.Tmp.GetComponent<Image>();
		this.Img_MissionFinalHeadBG.type = Image.Type.Tiled;
		this.Img_MissionFinalHeadBG.rectTransform.sizeDelta -= new Vector2(8f, 6f);
		this.Img_MissionFinalHeadBG.rectTransform.localPosition -= new Vector3(0f, 6f, 0f);
		this.Img_MissionFinalHead = this.Tmp.GetChild(0).GetComponent<Image>();
		this.Img_MissionFinalHead.rectTransform.anchoredPosition += new Vector2(4f, 3f);
		this.mMissionHead[10].Runner = new AERunner[1];
		this.mMissionHead[10].BG = this.Tmp.GetComponent<Image>();
		this.mMissionHead[10].HeadImages = new Image[1];
		this.mMissionHead[10].HeadImages[0] = this.mMissionHead[10].BG;
		this.Img_MissionFinalTimeCD = this.Tmp.GetChild(1).GetComponent<Image>();
		this.text_MF_TimeCD = this.Tmp.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_MF_TimeCD.font = this.TTFont;
		outline = this.Tmp.GetChild(1).GetChild(0).gameObject.AddComponent<Outline>();
		outline.effectColor = effectColor;
		this.Img_MissionFinalHeadLoad = this.Tmp.GetChild(2).GetComponent<Image>();
		this.Tmp.GetChild(0).gameObject.AddComponent<UIHIBtn>().enabled = false;
		this.Tmp.GetChild(0).GetComponent<RectTransform>().sizeDelta = this.mMissionHead[0].Head.rectTransform.sizeDelta;
		GUIManager.Instance.InitianHeroItemImg(this.Tmp.GetChild(0), eHeroOrItem.Hero, 0, 0, 0, 0, false, false, true, false);
		this.Hint = this.Tmp.gameObject.AddComponent<UIButtonHint>();
		this.Hint.ControlFadeOut = this.FBUIHint.gameobject;
		this.Hint.m_eHint = EUIButtonHint.DownUpHandler;
		this.Hint.m_Handler = this;
		this.Hint.Parm1 = 11;
		this.Hint.Parm2 = 1;
		this.Tmp = this.MissionMap_T.GetChild(8);
		this.text_TopInfo[0] = this.Tmp.GetComponent<UIText>();
		this.text_TopInfo[0].font = this.TTFont;
		this.Tmp = this.MissionMap_T.GetChild(9);
		this.text_TopInfo[1] = this.Tmp.GetComponent<UIText>();
		this.text_TopInfo[1].font = this.TTFont;
		this.text_TopInfo[1].text = this.DM.mStringTable.GetStringByID(12156u);
		this.text_TopInfo[1].SetAllDirty();
		this.text_TopInfo[1].cachedTextGenerator.Invalidate();
		this.text_TopInfo[1].cachedTextGeneratorForLayout.Invalidate();
		if (this.text_TopInfo[1].preferredWidth > 420f)
		{
			this.text_TopInfo[1].rectTransform.anchoredPosition = new Vector2(this.text_TopInfo[1].rectTransform.anchoredPosition.x, 183f);
			this.text_TopInfo[1].rectTransform.sizeDelta = new Vector2(420f, 44f);
			this.text_TopInfo[1].alignment = TextAnchor.MiddleLeft;
		}
		this.Tmp = this.MissionMap_T.GetChild(10);
		this.text_Full = this.Tmp.GetComponent<UIText>();
		this.text_Full.font = this.TTFont;
		this.text_Full.text = this.DM.mStringTable.GetStringByID(12162u);
		component2 = this.GameT.GetChild(2).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close_base");
		component2.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			component2.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(2).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.m_Mat;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
		if (DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex == 0 && !SocialManager.Instance.CheckSocialBind() && !DataManager.Instance.CheckPrizeFlag(27) && !DataManager.FBMissionDataManager.m_FBBindEnd && GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 4)
		{
			GUIManager.Instance.ShowUILock(EUILock.Mission);
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_FB_MISSION_START;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
		}
		else if (DataManager.Instance.RoleAttr.Inviter.Invited > 0 && !SocialManager.Instance.CheckBonding(false) && !DataManager.Instance.CheckPrizeFlag(30))
		{
			SocialManager.Instance.BindingPlatform(true);
		}
		this.bMission = (DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex <= 11);
		this.bTimeEnd = (DataManager.FBMissionDataManager.GetRemainTime() == 0u);
		this.bOpenEnd = true;
		this.UpdateUI(0, 10);
		NewbieManager.CheckSocialInvite();
	}

	// Token: 0x06001538 RID: 5432 RVA: 0x0024453C File Offset: 0x0024273C
	public override void OnClose()
	{
		if (this.Particle != null)
		{
			if (this.Particle.activeSelf && ParticleManager.Instance.AllEffectObject != null)
			{
				this.Particle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
			}
			this.Particle = null;
		}
		if ((DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex > 11 || !DataManager.FBMissionDataManager.IsInTime()) && (DataManager.FBMissionDataManager.GetRewardCount() == 0 || DataManager.FBMissionDataManager.GetRewardSerial() != DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo) && !this.DM.CheckPrizeFlag(29) && this.DM.CheckPrizeFlag(27))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_SET_MISSION_FINISH;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			DataManager instance = DataManager.Instance;
			instance.RoleAttr.PrizeFlag = (instance.RoleAttr.PrizeFlag | 536870912u);
			DataManager.FBMissionDataManager.ReSetFB_CDTime(null);
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27, 0);
		}
		for (int i = 0; i < this.Emoji.Length; i++)
		{
			if (this.Emoji[i] != null)
			{
				this.GUIM.pushEmojiIcon(this.Emoji[i]);
			}
		}
		for (int j = 0; j < this.Remaining.Length; j++)
		{
			StringManager.Instance.DeSpawnString(this.Remaining[j]);
		}
		StringManager.Instance.DeSpawnString(this.NameStr);
		StringManager.Instance.DeSpawnString(this.TimeStr);
		StringManager.Instance.DeSpawnString(this.HintStr);
		StringManager.Instance.DeSpawnString(this.HelpStr);
		StringManager.Instance.DeSpawnString(this.HourStr);
		StringManager.Instance.DeSpawnString(this.Goal1Str);
		StringManager.Instance.DeSpawnString(this.Goal2Str);
		StringManager.Instance.DeSpawnString(this.Node1Str);
		StringManager.Instance.DeSpawnString(this.Node2Str);
		StringManager.Instance.DeSpawnString(this.FinishStr);
		if (this.FBUIHint != null)
		{
			this.FBUIHint.Destroy();
		}
	}

	// Token: 0x06001539 RID: 5433 RVA: 0x0024479C File Offset: 0x0024299C
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x0600153A RID: 5434 RVA: 0x002447A0 File Offset: 0x002429A0
	public void OnAERunnerEnd(int ID1, int ID2)
	{
		if (ID2 > 0 && ID1 == 0)
		{
			if (this.Particle != null && this.Particle.activeSelf && ParticleManager.Instance.AllEffectObject != null)
			{
				this.Particle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
			}
			if (ID2 > 10)
			{
				this.Particle = ParticleManager.Instance.Spawn(447, this.MissionMap_T.GetChild(7).gameObject.transform, Vector3.zero, 1f, true, true, true);
			}
			else
			{
				this.Particle = ParticleManager.Instance.Spawn(447, this.MissionLine_T.GetChild(41 + ID2 - 1).gameObject.transform, Vector3.zero, 1f, true, true, true);
				this.Img_MissionInfo[ID2 - 1].transform.GetChild(1).gameObject.SetActive(true);
				this.mPosition[ID2 - 1].transform.GetChild(0).GetComponent<Image>().sprite = this.SArray.GetSprite(((!this.mMissionHead[ID2 - 1].BG.gameObject.activeSelf || this.mMissionHead[ID2 - 1].Runner[1] != null) && DataManager.FBMissionDataManager.GetFriendCountByProgress((byte)ID2) <= 1) ? 0 : 1);
			}
			this.mMissionHead[ID2 - 1].Runner[0] = null;
			this.Particle.transform.localPosition = new Vector3(0f, 0f, 0f);
			this.Particle.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			GUIManager.Instance.SetLayer(this.Particle, 5);
		}
	}

	// Token: 0x0600153B RID: 5435 RVA: 0x002449A8 File Offset: 0x00242BA8
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.text_HelpTitle.gameObject.activeInHierarchy)
			{
				this.text_HelpTitle.transform.parent.parent.gameObject.SetActive(false);
				this.text_Title.transform.parent.parent.gameObject.SetActive(true);
				this.UpdateTime(this.bOpenEnd);
			}
			else if (this.door != null)
			{
				DataManager.FBMissionDataManager.m_FBBindEnd = false;
				this.door.CloseMenu(false);
			}
			break;
		case 1:
			if (this.text_Title.gameObject.activeInHierarchy)
			{
				this.text_HelpTitle.transform.parent.parent.gameObject.SetActive(true);
				this.text_Title.transform.parent.parent.gameObject.SetActive(false);
			}
			break;
		case 2:
			if (this.ProFileStr != null)
			{
				this.DM.ShowLordProfile(this.ProFileStr.ToString());
			}
			break;
		case 3:
		case 4:
			if (this.door != null)
			{
				if (this.Price > 0)
				{
					this.door.OpenMenu(EGUIWindow.UI_OpenBox, 1, (int)this.Price, false);
				}
				else
				{
					FBMissionTbl recordByKey = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(this.Reward);
					this.door.OpenMenu(EGUIWindow.UI_OpenBox, 1, (int)recordByKey.FriendPrice, false);
				}
			}
			break;
		case 5:
			GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(12163u), 255, true);
			break;
		case 6:
			DataManager.FBMissionDataManager.SendFBGetReward();
			break;
		case 7:
			GUIManager.Instance.OpenMenu(EGUIWindow.UI_Other_Account, 0, 0, false, true, false);
			break;
		case 8:
			DataManager.FBMissionDataManager.SendFBGetReward();
			break;
		case 9:
		{
			FBMissionTbl recordByKey2 = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(11);
			if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_OpenBox, 1, (int)recordByKey2.OwnPrice, false);
			}
			break;
		}
		case 10:
		{
			if (DataManager.Instance.RoleAttr.Invitation == 0)
			{
				GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(1594u), 255, true);
				return;
			}
			string text = string.Empty;
			uint id = 12202u;
			uint id2 = 12201u;
			text = "http://lordsmobile.igg.com/project/share/?i=" + IGGGameSDK.Instance.Encode(IGGGameSDK.Instance.m_IGGID);
			text = text + "&language=" + (byte)DataManager.Instance.UserLanguage;
			if (IGGGameSDK.Instance.m_PlatformLoginName != string.Empty || IGGGameSDK.Instance.m_PlatformLoginName != string.Empty)
			{
				text = text + "&n=" + IGGGameSDK.Instance.Encode(IGGGameSDK.Instance.m_PlatformLoginName);
			}
			else
			{
				text += "&n= ";
			}
			IGGSDKPlugin.IntentIM(DataManager.Instance.mStringTable.GetStringByID(id), DataManager.Instance.mStringTable.GetStringByID(id2) + "\n" + text);
			Debug.Log("IntentIM = " + text);
			break;
		}
		case 11:
		{
			FBMissionTbl recordByKey3 = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(255);
			if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_OpenBox, 1, (int)recordByKey3.OwnPrice, false);
			}
			break;
		}
		case 12:
			if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_OpenBox, 4, 255, false);
			}
			break;
		}
	}

	// Token: 0x0600153C RID: 5436 RVA: 0x00244DB8 File Offset: 0x00242FB8
	public override bool OnBackButtonClick()
	{
		if (this.text_HelpTitle != null && this.text_HelpTitle.gameObject.activeInHierarchy)
		{
			this.text_HelpTitle.transform.parent.parent.gameObject.SetActive(false);
			this.text_Title.transform.parent.parent.gameObject.SetActive(true);
			this.UpdateTime(this.bOpenEnd);
			return true;
		}
		DataManager.FBMissionDataManager.m_FBBindEnd = false;
		return false;
	}

	// Token: 0x0600153D RID: 5437 RVA: 0x00244E48 File Offset: 0x00243048
	public void OnButtonDown(UIButtonHint sender)
	{
		if (sender.Parm2 > 0)
		{
			this.FBUIHint.ShowFriend(sender.Parm1, sender.transform);
		}
		else
		{
			this.FBUIHint.Show(sender.Parm1, sender.transform);
		}
	}

	// Token: 0x0600153E RID: 5438 RVA: 0x00244E94 File Offset: 0x00243094
	public void OnButtonUp(UIButtonHint sender)
	{
		if (this.FBUIHint != null)
		{
			this.FBUIHint.Hide(sender.transform);
		}
	}

	// Token: 0x0600153F RID: 5439 RVA: 0x00244EB4 File Offset: 0x002430B4
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 0)
		{
			if (arg1 == 1)
			{
				if (DataManager.FBMissionDataManager.GetRewardSerial() == DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo)
				{
					this.fPrize = 0.5f;
				}
				else
				{
					int friendIndex = DataManager.FBMissionDataManager.GetFriendIndex(DataManager.FBMissionDataManager.GetRewardSerial(), byte.MaxValue);
					if (friendIndex >= 0)
					{
						if (this.Emoji[12] != null)
						{
							this.GUIM.pushEmojiIcon(this.Emoji[12]);
							this.Emoji[12] = null;
						}
						if ((this.Emoji[12] = DataManager.FBMissionDataManager.GetFriendEmoji((ushort)DataManager.FBMissionDataManager.FBFriends[friendIndex].IconNo)) != null)
						{
							Rect rect = this.Emoji[12].EmojiImage.rectTransform.rect;
							float num = (rect.width >= rect.height) ? rect.width : rect.height;
							float num2 = 46f / num;
							this.Emoji[12].EmojiTransform.SetParent(this.mPosition[10].transform, false);
							this.Emoji[12].EmojiTransform.localPosition = Vector3.zero;
							((RectTransform)this.Emoji[12].EmojiTransform).anchoredPosition = new Vector2(-5f, 5f);
							((RectTransform)this.Emoji[12].EmojiTransform).localScale = new Vector3(num2, num2, num2);
							this.mPosition[10].transform.gameObject.SetActive(true);
							uTweenPosition.Begin(this.mPosition[10], this.mFriendHead, this.mFriendHead + new Vector3(0f, 300f, 0f), 0.5f, 0f).easeType = EaseType.easeInExpo;
							this.fFinish = 0.5f;
						}
					}
				}
			}
		}
		else
		{
			this.btnInviteGift.gameObject.SetActive(this.btnInvite.gameObject.activeSelf);
			this.Img_Castle.gameObject.SetActive(!this.btnInvite.gameObject.activeSelf);
			if (((DataManager.FBMissionDataManager.GetRewardCount() > 0 && DataManager.FBMissionDataManager.GetRewardIndex() == 0 && DataManager.FBMissionDataManager.GetRewardSerial() == DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo) || (DataManager.Instance.RoleAttr.Inviter.Invited > 0 && !DataManager.Instance.CheckPrizeFlag(30)) || DataManager.FBMissionDataManager.m_FBBindEnd || !this.MissionLine_T.parent.gameObject.activeSelf) && this.bOpenEnd)
			{
				this.GifeT.gameObject.SetActive(true);
				this.ImgDialogbox1.gameObject.SetActive(true);
				this.MissionLine_T.parent.gameObject.SetActive(false);
				this.btnFB.gameObject.SetActive(SocialManager.Instance.CheckBonding(true));
				this.btnReceive.gameObject.SetActive(((DataManager.FBMissionDataManager.GetRewardCount() > 0 && DataManager.FBMissionDataManager.GetRewardIndex() == 0 && DataManager.FBMissionDataManager.GetRewardSerial() == DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo) || !this.DM.CheckPrizeFlag(30)) && !SocialManager.Instance.CheckBonding(true));
				DataManager.FBMissionDataManager.m_FBBindEnd = (!this.btnReceive.gameObject.activeSelf && !this.btnFB.gameObject.activeSelf);
				this.ImgFBGiftReceive.gameObject.SetActive(DataManager.FBMissionDataManager.m_FBBindEnd);
				this.Img_Head.transform.parent.gameObject.SetActive(true);
				if (this.DM.RoleAttr.Inviter.Invited > 0 && this.DM.RoleAttr.Inviter.Result == 0)
				{
					if (this.DM.RoleAttr.Inviter.Name.Length > 0)
					{
						GUIManager.Instance.ChangeHeroItemImg(this.PiggyHead.transform, eHeroOrItem.Hero, this.DM.RoleAttr.Inviter.Head, 0, 0, 0);
						this.Img_Recommend.gameObject.SetActive(true);
						this.Img_Head.gameObject.SetActive(true);
						this.UpdateFriendName(byte.MaxValue, false);
					}
					else
					{
						DataManager.FBMissionDataManager.SendFriend_SocialInfo(0);
					}
				}
				else
				{
					this.Img_PigHead.sprite = GUIManager.Instance.m_IconSpriteAsset.LoadSprite(1000);
					this.Img_Recommend.gameObject.SetActive(false);
					this.Img_Head.gameObject.SetActive(true);
					this.UpdateNPCName();
				}
				this.text_Dialogbox1.text = this.DM.mStringTable.GetStringByID((!this.btnFB.isActiveAndEnabled) ? ((!this.btnReceive.isActiveAndEnabled) ? 12152u : 12150u) : 12148u);
				this.text_Dialogbox1.rectTransform.sizeDelta = new Vector2(this.text_Dialogbox1.rectTransform.sizeDelta.x, this.text_Dialogbox1.preferredHeight);
			}
			else if (DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex >= 1 && DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex <= 12 && this.bOpenEnd)
			{
				if (DataManager.FBMissionDataManager.GetRewardCount() == 0 && (DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex > 11 || DataManager.FBMissionDataManager.GetRemainTime() == 0u))
				{
					FBMissionTbl recordByKey = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(this.Reward = (ushort)DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex);
					this.FinishStr.ClearString();
					this.FinishStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.Name));
					this.FinishStr.AppendFormat(this.DM.mStringTable.GetStringByID((!SocialManager.Instance.CanShowInvite()) ? ((DataManager.Instance.RoleAttr.Inviter.Invited <= 0) ? 12186u : 12172u) : 12173u));
					this.text_Dialogbox1.text = this.FinishStr.ToString();
					this.text_Dialogbox1.SetAllDirty();
					this.text_Dialogbox1.cachedTextGenerator.Invalidate();
					this.text_Dialogbox1.cachedTextGeneratorForLayout.Invalidate();
					this.text_Dialogbox1.rectTransform.sizeDelta = new Vector2(this.text_Dialogbox1.rectTransform.sizeDelta.x, this.text_Dialogbox1.preferredHeight);
					GUIManager.Instance.ChangeHeroItemImg(this.MissionMap_T.GetChild(7).GetChild(0).GetChild(0), eHeroOrItem.Hero, this.DM.RoleAttr.Head, 0, 0, 0);
					uTweenPosition.Begin(this.Img_MissionFinalHeadBG.gameObject, this.Img_MissionFinalHeadBG.transform.localPosition, this.Img_MissionFinalHeadBG.transform.localPosition + new Vector3(0f, 300f, 0f), 0.5f, 0f).easeType = EaseType.easeInExpo;
					this.btnMissionGiftFinal.gameObject.SetActive(false);
					this.btnMissionReceive1.gameObject.SetActive(false);
					this.btnMissionReceive2.gameObject.SetActive(false);
					this.btnMissionGift.gameObject.SetActive(false);
					this.ImgDialogbox2.gameObject.SetActive(false);
					this.ImgDialogbox1.gameObject.SetActive(true);
					if (this.mMissionHead[10].Runner[0] != null)
					{
						this.mMissionHead[10].Runner[0].SetEndRecall(null);
						this.mMissionHead[10].Runner[0].SetTime(10f, true);
					}
					this.Price = recordByKey.OwnPrice;
					this.fFinal = (this.fFirst = 0f);
				}
				else if (DataManager.FBMissionDataManager.GetRewardCount() > 0 || DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex >= 11)
				{
					this.FinishStr.ClearString();
					if (DataManager.FBMissionDataManager.GetRewardCount() > 0 && DataManager.FBMissionDataManager.GetRewardSerial() != DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo)
					{
						this.Award = DataManager.FBMissionDataManager.GetAwardSocialInfo();
						FBMissionTbl recordByKey2 = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(this.Reward = (ushort)((this.Award.AwardIndex <= 0) ? byte.MaxValue : this.Award.AwardIndex));
						int friendIndex2 = DataManager.FBMissionDataManager.GetFriendIndex(DataManager.FBMissionDataManager.GetRewardSerial(), byte.MaxValue);
						if (friendIndex2 >= 0 && DataManager.FBMissionDataManager.FBFriends[friendIndex2].Result == 0)
						{
							if (this.Award.AwardIndex > 0)
							{
								this.FinishStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey2.Name));
								this.FinishStr.AppendFormat(this.DM.mStringTable.GetStringByID((this.Award.AwardIndex < 11) ? 12170u : 12171u));
							}
							else
							{
								this.FinishStr.Append(this.DM.mStringTable.GetStringByID(12194u));
							}
						}
						else
						{
							Equip recordByKey3 = this.DM.EquipTable.GetRecordByKey(recordByKey2.FriendPrice);
							this.FinishStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey3.EquipName));
							this.FinishStr.AppendFormat(this.DM.mStringTable.GetStringByID(12182u));
						}
						this.Price = 0;
					}
					else
					{
						FBMissionTbl recordByKey4 = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(this.Reward = ((DataManager.FBMissionDataManager.GetRewardCount() <= 0) ? 11 : DataManager.FBMissionDataManager.GetRewardIndex()));
						this.FinishStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey4.Name));
						this.FinishStr.AppendFormat(this.DM.mStringTable.GetStringByID((this.Reward < 11) ? 12168u : 12169u));
						this.Price = recordByKey4.OwnPrice;
					}
					this.text_Dialogbox2_Mission[0].text = this.FinishStr.ToString();
					this.text_Dialogbox2_Mission[0].SetAllDirty();
					this.text_Dialogbox2_Mission[0].cachedTextGenerator.Invalidate();
					this.text_Dialogbox2_Mission[0].cachedTextGeneratorForLayout.Invalidate();
					this.text_Dialogbox2_Mission[0].rectTransform.sizeDelta = new Vector2(this.text_Dialogbox2_Mission[0].rectTransform.sizeDelta.x, this.text_Dialogbox2_Mission[0].preferredHeight);
					UIText uitext = this.text_Dialogbox2_Mission[1];
					string text = string.Empty;
					this.text_Dialogbox2_Mission[3].text = text;
					text = text;
					this.text_Dialogbox2_Mission[2].text = text;
					uitext.text = text;
					UIText uitext2 = this.text_Dialogbox2_Degree[0];
					text = string.Empty;
					this.text_Dialogbox2_Degree[1].text = text;
					uitext2.text = text;
					Behaviour behaviour = this.ImgDialogbox2_Degree[0];
					bool flag = false;
					this.ImgDialogbox2_Degree[1].enabled = flag;
					behaviour.enabled = flag;
					this.ImgDialogbox2.gameObject.SetActive(true);
					this.ImgDialogbox1.gameObject.SetActive(false);
					if (DataManager.FBMissionDataManager.GetRewardCount() > 0 && DataManager.FBMissionDataManager.GetRewardSerial() == DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo)
					{
						this.bGiftEnd = !DataManager.FBMissionDataManager.IsInTime();
					}
					if (DataManager.FBMissionDataManager.GetRewardSerial() == DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo && DataManager.FBMissionDataManager.GetRewardIndex() == 11 && arg2 < 10 && this.mMissionHead[10].Runner[0] == null)
					{
						this.mMissionHead[10].Runner[0] = AERunnerSetter.SetFunctionAppear(this.mMissionHead[10].BG.rectTransform, this.mMissionHead[10].HeadImages);
						this.mMissionHead[10].Runner[0].SetEndRecall(this);
						this.mMissionHead[10].Runner[0].mRunner_ID2 = 11;
						this.mMissionHead[10].Runner[0].SetTime(0f, true);
						this.mMissionHead[10].BG.transform.localScale = Vector3.forward;
						this.fFirst = 1.16f;
					}
				}
				else
				{
					FBMissionTbl recordByKey5 = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(this.Reward = (ushort)DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex);
					UIText uitext3 = this.text_Dialogbox2_Mission[0];
					string text = this.DM.mStringTable.GetStringByID((uint)recordByKey5.Name);
					this.text_Dialogbox2_Mission[3].text = text;
					text = text;
					this.text_Dialogbox2_Mission[2].text = text;
					uitext3.text = text;
					float num3 = this.text_Dialogbox2_Mission[0].preferredHeight;
					CString hintStr = this.HintStr;
					int num4 = 0;
					this.Node2Str.Length = num4;
					num4 = num4;
					this.Node1Str.Length = num4;
					hintStr.Length = num4;
					this.text_Dialogbox2_Mission[0].rectTransform.sizeDelta = new Vector2(this.text_Dialogbox2_Mission[0].rectTransform.sizeDelta.x, num3);
					DataManager.FBMissionDataManager.GetNarrative(this.HintStr, ref recordByKey5, 0, true);
					num3 = this.text_Dialogbox2_Mission[2].preferredHeight;
					this.Node1Str.StringToFormat(this.HintStr);
					this.Node1Str.AppendFormat((!this.GUIM.IsArabic) ? "> {0}" : "－ {0}");
					this.text_Dialogbox2_Mission[2].text = this.Node1Str.ToString();
					this.text_Dialogbox2_Mission[2].SetAllDirty();
					this.text_Dialogbox2_Mission[2].cachedTextGenerator.Invalidate();
					this.text_Dialogbox2_Mission[2].cachedTextGeneratorForLayout.Invalidate();
					CString hintStr2 = this.HintStr;
					num4 = 0;
					this.Node2Str.Length = num4;
					hintStr2.Length = num4;
					DataManager.FBMissionDataManager.GetNarrative(this.HintStr, ref recordByKey5, 1, true);
					num3 = this.text_Dialogbox2_Mission[3].preferredHeight;
					this.Node2Str.StringToFormat(this.HintStr);
					this.Node2Str.AppendFormat((!this.GUIM.IsArabic) ? "> {0}" : "－ {0}");
					this.text_Dialogbox2_Mission[3].text = this.Node2Str.ToString();
					this.text_Dialogbox2_Mission[3].SetAllDirty();
					this.text_Dialogbox2_Mission[3].cachedTextGenerator.Invalidate();
					this.text_Dialogbox2_Mission[3].cachedTextGeneratorForLayout.Invalidate();
					this.ImgDialogbox2.gameObject.SetActive(true);
					this.Price = recordByKey5.OwnPrice;
					this.HintStr.ClearString();
					DataManager.FBMissionDataManager.GetMissionState(ref this.State[0], recordByKey5.ID, 0);
					this.HintStr.IntToFormat((long)((ulong)this.State[0].GoalNum), 1, true);
					this.HintStr.IntToFormat((long)((ulong)this.State[0].GoalNum), 1, true);
					this.HintStr.AppendFormat((!this.GUIM.IsArabic) ? "{0} / {1}" : "{1} / {0}");
					this.text_Dialogbox2_Degree[0].text = this.HintStr.ToString();
					this.text_Dialogbox2_Degree[0].SetAllDirty();
					this.text_Dialogbox2_Degree[0].cachedTextGenerator.Invalidate();
					this.text_Dialogbox2_Degree[0].cachedTextGeneratorForLayout.Invalidate();
					num3 = this.text_Dialogbox2_Degree[0].preferredWidth;
					this.Goal1Str.ClearString();
					this.Goal1Str.IntToFormat((long)((ulong)this.State[0].CurNum), 1, true);
					this.Goal1Str.IntToFormat((long)((ulong)this.State[0].GoalNum), 1, true);
					this.Goal1Str.AppendFormat((!this.GUIM.IsArabic) ? "{0} / {1}" : "{1} / {0}");
					this.text_Dialogbox2_Degree[0].text = this.Goal1Str.ToString();
					this.text_Dialogbox2_Degree[0].SetAllDirty();
					this.text_Dialogbox2_Degree[0].cachedTextGenerator.Invalidate();
					this.text_Dialogbox2_Degree[0].cachedTextGeneratorForLayout.Invalidate();
					GameObject gameObject = this.text_Dialogbox2_Degree[0].gameObject;
					bool flag = this.State[0].CurNum == this.State[0].GoalNum;
					this.ImgDialogbox2_Degree[0].enabled = flag;
					gameObject.SetActive(!flag && this.State[0].bCount > 0);
					this.text_Dialogbox2_Degree[0].transform.localPosition = new Vector3(0.5f * (num3 - this.text_Dialogbox2_Degree[0].preferredWidth) + 370f + ((!this.GUIM.IsArabic) ? 0f : this.text_Dialogbox2_Degree[0].rectTransform.sizeDelta.x), this.text_Dialogbox2_Degree[0].transform.localPosition.y, 0f);
					DataManager.FBMissionDataManager.GetMissionState(ref this.State[1], recordByKey5.ID, 1);
					this.HintStr.ClearString();
					this.HintStr.IntToFormat((long)((ulong)this.State[1].GoalNum), 1, true);
					this.HintStr.IntToFormat((long)((ulong)this.State[1].GoalNum), 1, true);
					this.HintStr.AppendFormat((!this.GUIM.IsArabic) ? "{0} / {1}" : "{1} / {0}");
					this.text_Dialogbox2_Degree[1].text = this.HintStr.ToString();
					this.text_Dialogbox2_Degree[1].SetAllDirty();
					this.text_Dialogbox2_Degree[1].cachedTextGenerator.Invalidate();
					this.text_Dialogbox2_Degree[1].cachedTextGeneratorForLayout.Invalidate();
					num3 = this.text_Dialogbox2_Degree[1].preferredWidth;
					this.Goal2Str.ClearString();
					this.Goal2Str.IntToFormat((long)((ulong)this.State[1].CurNum), 1, true);
					this.Goal2Str.IntToFormat((long)((ulong)this.State[1].GoalNum), 1, true);
					this.Goal2Str.AppendFormat((!this.GUIM.IsArabic) ? "{0} / {1}" : "{1} / {0}");
					this.text_Dialogbox2_Degree[1].text = this.Goal2Str.ToString();
					this.text_Dialogbox2_Degree[1].SetAllDirty();
					this.text_Dialogbox2_Degree[1].cachedTextGenerator.Invalidate();
					this.text_Dialogbox2_Degree[1].cachedTextGeneratorForLayout.Invalidate();
					GameObject gameObject2 = this.text_Dialogbox2_Degree[1].gameObject;
					flag = (this.State[1].CurNum == this.State[1].GoalNum);
					this.ImgDialogbox2_Degree[1].enabled = flag;
					gameObject2.SetActive(!flag && this.State[1].bCount > 0);
					this.text_Dialogbox2_Degree[1].transform.localPosition = new Vector3(0.5f * (num3 - this.text_Dialogbox2_Degree[1].preferredWidth) + 370f + ((!this.GUIM.IsArabic) ? 0f : this.text_Dialogbox2_Degree[1].rectTransform.sizeDelta.x), this.text_Dialogbox2_Degree[1].transform.localPosition.y, 0f);
					this.text_Dialogbox2_Mission[1].text = this.DM.mStringTable.GetStringByID(12167u);
				}
				for (int i = 2; i < this.text_Dialogbox2_Mission.Length; i++)
				{
					this.text_Dialogbox2_Mission[i].rectTransform.sizeDelta = new Vector2((float)((i <= 1) ? 420 : 318), this.text_Dialogbox2_Mission[i].preferredHeight);
					this.text_Dialogbox2_Mission[i].rectTransform.anchoredPosition = this.text_Dialogbox2_Mission[i - 1].rectTransform.anchoredPosition - new Vector2((float)((!this.GUIM.IsArabic) ? 0 : ((i != 2) ? 0 : 102)), this.text_Dialogbox2_Mission[i - 1].rectTransform.sizeDelta.y + 1f);
				}
				for (int j = 0; j < this.text_Dialogbox2_Degree.Length; j++)
				{
					Graphic graphic = this.text_Dialogbox2_Mission[j + 2];
					Color color = (!this.ImgDialogbox2_Degree[j].enabled) ? this.mMissionGray : this.mMissionGreen;
					this.text_Dialogbox2_Degree[j].color = color;
					graphic.color = color;
					this.text_Dialogbox2_Degree[j].rectTransform.anchoredPosition = new Vector2(this.text_Dialogbox2_Degree[j].rectTransform.anchoredPosition.x, this.text_Dialogbox2_Mission[j + 2].rectTransform.anchoredPosition.y);
					this.ImgDialogbox2_Degree[j].rectTransform.anchoredPosition = new Vector2(this.ImgDialogbox2_Degree[j].rectTransform.anchoredPosition.x, this.text_Dialogbox2_Mission[j + 2].rectTransform.anchoredPosition.y);
				}
				bool flag2 = DataManager.Instance.CheckPrizeFlag(29);
				if (this.fPrize > 0f)
				{
					uTweenPosition.Begin(this.Img_MissionFinalHeadBG.gameObject, this.Img_MissionFinalHeadBG.transform.localPosition, this.Img_MissionFinalHeadBG.transform.localPosition + new Vector3(0f, 300f, 0f), 0.5f, 0f).easeType = EaseType.easeInExpo;
				}
				this.text_GiftNum.text = DataManager.FBMissionDataManager.GetRewardCount().ToString();
				this.Img_GiftNum.gameObject.SetActive(DataManager.FBMissionDataManager.GetRewardCount() > 0);
				this.Img_GiftNum.rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_GiftNum.preferredWidth), this.Img_GiftNum.rectTransform.sizeDelta.y);
				this.Img_MissionFinalHeadBG.gameObject.SetActive(DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex >= 11 && (this.bMission || !this.DM.CheckPrizeFlag(29)) && this.fFinal == 0f);
				this.Img_MissionFinalHeadBG.transform.GetChild(1).gameObject.SetActive(false);
				for (int k = 1; k < this.mMissionHead.Length; k++)
				{
					if ((DataManager.FBMissionDataManager.GetRewardCount() > 0 && (int)DataManager.FBMissionDataManager.GetRewardIndex() == k && DataManager.FBMissionDataManager.GetRewardSerial() == DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo) || ((DataManager.FBMissionDataManager.IsInTime() || (!flag2 && !this.bGiftEnd)) && (int)DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex == k))
					{
						GUIManager.Instance.ChangeHeroItemImg(this.MissionLine_T.GetChild(41 + k - 1).GetChild(0).GetChild(0), eHeroOrItem.Hero, this.DM.RoleAttr.Head, 11, 0, 0);
						if (!this.MissionLine_T.GetChild(41 + k - 1).GetChild(0).gameObject.activeSelf && arg2 < 10 && this.mMissionHead[k - 1].Runner[0] == null)
						{
							if (k == 1)
							{
								this.mMissionHead[k - 1].Runner[0] = AERunnerSetter.SetFunctionFirst(this.mMissionHead[k - 1].BG.rectTransform, this.mMissionHead[k - 1].HeadImages);
								this.fFirst = 0.4f;
							}
							else
							{
								this.mMissionHead[k - 1].Runner[0] = AERunnerSetter.SetFunctionAppear(this.mMissionHead[k - 1].BG.rectTransform, this.mMissionHead[k - 1].HeadImages);
								this.fFirst = 1.1f;
							}
							this.mMissionHead[k - 1].BG.transform.localScale = Vector3.forward;
							this.mMissionHead[k - 1].Runner[0].SetEndRecall(this);
							this.mMissionHead[k - 1].Runner[0].mRunner_ID2 = k;
							this.mMissionHead[k - 1].Runner[0].SetTime(0f, true);
						}
						this.MissionLine_T.GetChild(41 + k - 1).GetChild(0).gameObject.SetActive(true);
					}
					else if (this.MissionLine_T.GetChild(41 + k - 1).GetChild(0).gameObject.activeSelf)
					{
						if (this.mMissionHead[k - 1].Runner[1] == null && (DataManager.FBMissionDataManager.IsInTime() || arg2 == 1))
						{
							this.mMissionHead[k - 1].Runner[1] = AERunnerSetter.SetFunctionDisappear(this.mMissionHead[k - 1].BG.rectTransform, this.mMissionHead[k - 1].HeadImages);
							this.mMissionHead[k - 1].Runner[1].mRunner_ID1 = 1;
							this.mMissionHead[k - 1].Runner[1].SetEndRecall(this);
							this.mMissionHead[k - 1].Runner[1].SetTime(0f, true);
							this.fHide = 0.33f;
						}
						this.mMissionHead[k - 1].Runner[0] = null;
					}
					else
					{
						this.MissionLine_T.GetChild(41 + k - 1).GetChild(0).gameObject.SetActive(false);
					}
					this.mMissionHead[k - 1].Head.transform.GetChild(1).gameObject.SetActive(false);
					this.mMissionHead[k - 1].Time.gameObject.SetActive(false);
				}
				for (int l = 1; l <= this.Img_MissionInfo.Length; l++)
				{
					if (((DataManager.FBMissionDataManager.GetRewardCount() > 0 && (int)DataManager.FBMissionDataManager.GetRewardIndex() > l && DataManager.FBMissionDataManager.GetRewardSerial() == DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo) || (int)DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex > l) && !flag2)
					{
						if (arg2 == 10)
						{
							this.Img_MissionInfo[l - 1].transform.GetChild(0).gameObject.SetActive(true);
						}
						if (!this.Img_MissionInfo[l - 1].transform.GetChild(0).gameObject.activeSelf && (DataManager.FBMissionDataManager.GetRewardCount() == 0 || DataManager.FBMissionDataManager.GetRewardSerial() != DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo || (int)(DataManager.FBMissionDataManager.GetRewardIndex() - 1) == l) && this.mMissionHead[l - 1].Runner[2] == null && arg2 < 10)
						{
							this.Img_MissionInfo[l - 1].transform.GetChild(0).gameObject.SetActive(true);
							this.mMissionHead[l - 1].Runner[2] = AERunnerSetter.SetFunctionTick(this.mMissionHead[l - 1].TickImages[0].rectTransform, this.mMissionHead[l - 1].TickImages);
							this.mMissionHead[l - 1].Runner[2].SetEndRecall(this);
							this.mMissionHead[l - 1].Runner[2].mRunner_ID1 = 2;
							this.mMissionHead[l - 1].Runner[2].SetTime(0f, true);
						}
					}
					if (l == (int)DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex && ((DataManager.FBMissionDataManager.GetRewardCount() > 0 && DataManager.FBMissionDataManager.GetRewardSerial() == DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo) || DataManager.FBMissionDataManager.IsInTime() || (this.mMissionHead[l - 1].Runner[1] == null && this.mMissionHead[l - 1].BG.gameObject.activeSelf)) && this.mMissionHead[l - 1].Runner[0] == null && !flag2)
					{
						this.Img_MissionInfo[l - 1].transform.GetChild(1).gameObject.SetActive(true);
					}
					else
					{
						this.Img_MissionInfo[l - 1].transform.GetChild(1).gameObject.SetActive(false);
					}
				}
				if (!this.ImgDialogbox1.gameObject.activeSelf)
				{
					this.btnMissionGiftFinal.gameObject.SetActive(DataManager.FBMissionDataManager.GetRewardIndex() == 11);
					this.btnMissionGift.gameObject.SetActive(DataManager.FBMissionDataManager.GetRewardIndex() != 11);
					if (this.Img_MissionFinalHeadBG.gameObject.activeSelf && this.fFinal == 0f)
					{
						GUIManager.Instance.ChangeHeroItemImg(this.MissionMap_T.GetChild(7).GetChild(0).GetChild(0), eHeroOrItem.Hero, this.DM.RoleAttr.Head, 11, 0, 0);
						this.Img_MissionFinalHead.transform.GetChild(1).gameObject.SetActive(false);
					}
					this.btnMissionReceive1.gameObject.SetActive(DataManager.FBMissionDataManager.GetRewardCount() == 0);
					this.btnMissionReceive2.gameObject.SetActive(DataManager.FBMissionDataManager.GetRewardCount() > 0);
				}
				if (this.btnInvite.gameObject.activeSelf)
				{
					this.HintStr.ClearString();
					this.HintStr.IntToFormat((long)SocialManager.Instance.GetFriendNumber(), 1, false);
					this.HintStr.IntToFormat((long)SocialManager.Instance.MaxConcurrentFriend, 1, false);
					this.HintStr.AppendFormat(this.DM.mStringTable.GetStringByID(12155u));
					this.text_TopInfo[0].text = this.HintStr.ToString();
					this.text_TopInfo[0].SetAllDirty();
					this.text_TopInfo[0].cachedTextGenerator.Invalidate();
					this.text_TopInfo[0].cachedTextGeneratorForLayout.Invalidate();
					this.text_TopInfo[0].gameObject.SetActive(SocialManager.Instance.MaxConcurrentFriend > 0);
					this.text_TopInfo[1].gameObject.SetActive(SocialManager.Instance.MaxConcurrentFriend > 0);
					this.text_Full.gameObject.SetActive(SocialManager.Instance.MaxConcurrentFriend == 0);
				}
				else
				{
					this.text_TopInfo[0].gameObject.SetActive(false);
					this.text_TopInfo[1].gameObject.SetActive(false);
					this.text_Full.gameObject.SetActive(false);
				}
				this.ImgDialogbox2.color = ((DataManager.FBMissionDataManager.GetRewardCount() <= 0 || DataManager.FBMissionDataManager.GetRewardSerial() == DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo) ? this.mDialogSelf : this.mDialogFriend);
				for (int m = 0; m < 10; m++)
				{
					int friendCountByProgress = (int)DataManager.FBMissionDataManager.GetFriendCountByProgress((byte)(m + 1));
					this.mPosition[m].transform.GetChild(0).gameObject.SetActive(true);
					this.mFriendsHead[m].Show = (float)friendCountByProgress;
					if (arg2 == 10)
					{
						this.mFriendsHead[m].Canvas.alpha = (float)((friendCountByProgress <= 0) ? 0 : 1);
					}
					if (friendCountByProgress > 0)
					{
						this.mPosition[m].transform.GetChild(0).GetComponent<Image>().sprite = this.SArray.GetSprite(((!this.mMissionHead[m].BG.gameObject.activeSelf || this.mMissionHead[m].Runner[0] != null || this.mMissionHead[m].Runner[1] != null) && friendCountByProgress <= 1) ? 0 : 1);
						if (this.Emoji[m] != null)
						{
							this.GUIM.pushEmojiIcon(this.Emoji[m]);
							this.Emoji[m] = null;
						}
						if ((this.Emoji[m] = DataManager.FBMissionDataManager.GetFriendEmoji((byte)(m + 1), 0)) != null)
						{
							Rect rect2 = this.Emoji[m].EmojiImage.rectTransform.rect;
							float num5 = (rect2.width >= rect2.height) ? rect2.width : rect2.height;
							float num6 = 46f / num5;
							this.Emoji[m].EmojiTransform.SetParent(this.mPosition[m].transform.GetChild(0), false);
							this.Emoji[m].EmojiTransform.SetSiblingIndex(1);
							this.Emoji[m].EmojiTransform.localPosition = Vector3.zero;
							((RectTransform)this.Emoji[m].EmojiTransform).anchoredPosition = new Vector2(-5f, 5f);
							((RectTransform)this.Emoji[m].EmojiTransform).localScale = new Vector3(num6, num6, num6);
						}
					}
				}
				this.UpdateTime(this.bOpenEnd);
				int friendCountByProgress2 = (int)DataManager.FBMissionDataManager.GetFriendCountByProgress(11);
				int friendCountByProgress3 = (int)DataManager.FBMissionDataManager.GetFriendCountByProgress(12);
				this.mFriendsHead[10].Show = (float)(friendCountByProgress2 + friendCountByProgress3);
				this.mFriends[10].transform.GetChild(0).gameObject.SetActive(false);
				this.mFriends[10].transform.gameObject.SetActive(true);
				if (arg2 == 10 || this.mFriendsHead[10].Show == 0f)
				{
					this.mFriendsHead[10].Canvas.alpha = (float)((this.mFriendsHead[10].Show <= 0f) ? 0 : 1);
				}
				this.mFriends[10].GetComponent<Image>().sprite = this.SArray.GetSprite((friendCountByProgress2 + friendCountByProgress3 + ((DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex != 11) ? 0 : 1) <= 1) ? 0 : 1);
				this.mPosition[10].transform.GetChild(0).gameObject.SetActive(false);
				if (this.Emoji[11] != null)
				{
					this.GUIM.pushEmojiIcon(this.Emoji[11]);
					this.Emoji[11] = null;
				}
				if (this.mFriends[10].activeSelf)
				{
					SocialFriend socialFriend;
					DataManager.FBMissionDataManager.GetFriendSocialInfo((friendCountByProgress3 <= 0) ? 11 : 12, 0, out socialFriend, false);
					if (socialFriend != null && (this.Emoji[11] = DataManager.FBMissionDataManager.GetFriendEmoji((ushort)socialFriend.IconNo)) != null)
					{
						Rect rect3 = this.Emoji[11].EmojiImage.rectTransform.rect;
						float num7 = (rect3.width >= rect3.height) ? rect3.width : rect3.height;
						float num8 = 46f / num7;
						this.Emoji[11].EmojiTransform.SetParent(this.mFriends[10].transform, false);
						this.Emoji[11].EmojiTransform.localPosition = Vector3.zero;
						((RectTransform)this.Emoji[11].EmojiTransform).anchoredPosition = new Vector2(-5f, 5f);
						((RectTransform)this.Emoji[11].EmojiTransform).localScale = new Vector3(num8, num8, num8);
						this.mFriends[10].GetComponent<UIButtonHint>().Parm1 = (ushort)socialFriend.NodeIndex;
					}
				}
				if (this.DM.RoleAttr.Inviter.Invited > 0 && this.DM.RoleAttr.Inviter.Result == 0)
				{
					GUIManager.Instance.ChangeHeroItemImg(this.PiggyHead.transform, eHeroOrItem.Hero, this.DM.RoleAttr.Inviter.Head, 0, 0, 0);
				}
				else
				{
					this.Img_PigHead.sprite = GUIManager.Instance.m_IconSpriteAsset.LoadSprite(1000);
				}
				if (this.Emoji[10] != null)
				{
					this.GUIM.pushEmojiIcon(this.Emoji[10]);
					this.Emoji[10] = null;
				}
				if (DataManager.FBMissionDataManager.GetRewardCount() > 0 && DataManager.FBMissionDataManager.GetRewardSerial() != DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo)
				{
					int friendIndex3 = DataManager.FBMissionDataManager.GetFriendIndex(DataManager.FBMissionDataManager.GetRewardSerial(), byte.MaxValue);
					if (friendIndex3 >= 0 && DataManager.FBMissionDataManager.FBFriends[friendIndex3].Result == 0)
					{
						if (DataManager.FBMissionDataManager.FBFriends[friendIndex3].Name.Length == 0)
						{
							DataManager.FBMissionDataManager.SendFriend_SocialInfo(DataManager.FBMissionDataManager.FBFriends[friendIndex3].UserSerialNo);
						}
						if ((this.Emoji[10] = DataManager.FBMissionDataManager.GetFriendEmoji((ushort)DataManager.FBMissionDataManager.FBFriends[friendIndex3].IconNo)) != null)
						{
							this.Emoji[10].EmojiTransform.SetParent(this.Img_Head.transform, false);
							((RectTransform)this.Emoji[10].EmojiTransform).anchorMax = 0.5f * Vector2.one;
							((RectTransform)this.Emoji[10].EmojiTransform).anchorMin = 0.5f * Vector2.one;
							((RectTransform)this.Emoji[10].EmojiTransform).anchoredPosition = Vector2.zero;
						}
						this.ImgDialogbox2.color = this.mDialogFriend;
						this.UpdateFriendName((byte)friendIndex3, false);
					}
					else
					{
						this.UpdateNPCName();
						this.ImgDialogbox2.color = this.mDialogSelf;
						this.Img_PigHead.sprite = GUIManager.Instance.m_IconSpriteAsset.LoadSprite(1000);
					}
					this.Img_Head.gameObject.SetActive(true);
					this.Img_Head.transform.GetChild(0).gameObject.SetActive(friendIndex3 < 0 || DataManager.FBMissionDataManager.FBFriends[friendIndex3].Result > 0);
					this.Img_Recommend.gameObject.SetActive(false);
				}
				else
				{
					this.Img_Head.transform.GetChild(0).gameObject.SetActive(true);
					this.ImgDialogbox2.color = this.mDialogSelf;
					if (this.DM.RoleAttr.Inviter.Invited > 0 && this.DM.RoleAttr.Inviter.Result == 0)
					{
						if (this.DM.RoleAttr.Inviter.Name.Length > 0)
						{
							this.Img_Recommend.gameObject.SetActive(true);
							this.Img_Head.gameObject.SetActive(true);
							this.UpdateFriendName(byte.MaxValue, false);
						}
						else
						{
							DataManager.FBMissionDataManager.SendFriend_SocialInfo(0);
						}
					}
					else
					{
						this.Img_Recommend.gameObject.SetActive(false);
						this.Img_Head.gameObject.SetActive(true);
						this.UpdateNPCName();
					}
				}
				this.text_Npc_Tag.SetAllDirty();
				this.text_Npc_Tag.cachedTextGenerator.Invalidate();
				this.text_Npc_Tag.cachedTextGeneratorForLayout.Invalidate();
				this.text_Npc_Name.SetAllDirty();
				this.text_Npc_Name.cachedTextGenerator.Invalidate();
				this.text_Npc_Name.cachedTextGeneratorForLayout.Invalidate();
				this.Img_Head.transform.parent.gameObject.SetActive(true);
				this.FBUIHint.UpdateData();
			}
		}
	}

	// Token: 0x06001540 RID: 5440 RVA: 0x00247A4C File Offset: 0x00245C4C
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
		}
	}

	// Token: 0x06001541 RID: 5441 RVA: 0x00247A84 File Offset: 0x00245C84
	public void Refresh_FontTexture()
	{
		if (this.bCloseExit)
		{
			return;
		}
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_FB_Tag != null && this.text_FB_Tag.enabled)
		{
			this.text_FB_Tag.enabled = false;
			this.text_FB_Tag.enabled = true;
		}
		if (this.text_FB_Name != null && this.text_FB_Name.enabled)
		{
			this.text_FB_Name.enabled = false;
			this.text_FB_Name.enabled = true;
		}
		if (this.text_TimeOut != null && this.text_TimeOut.enabled)
		{
			this.text_TimeOut.enabled = false;
			this.text_TimeOut.enabled = true;
		}
		if (this.text_GiftNum != null && this.text_GiftNum.enabled)
		{
			this.text_GiftNum.enabled = false;
			this.text_GiftNum.enabled = true;
		}
		if (this.text_Npc_Tag != null && this.text_Npc_Tag.enabled)
		{
			this.text_Npc_Tag.enabled = false;
			this.text_Npc_Tag.enabled = true;
		}
		if (this.text_Npc_Name != null && this.text_Npc_Name.enabled)
		{
			this.text_Npc_Name.enabled = false;
			this.text_Npc_Name.enabled = true;
		}
		if (this.text_HelpTitle != null && this.text_HelpTitle.enabled)
		{
			this.text_HelpTitle.enabled = false;
			this.text_HelpTitle.enabled = true;
		}
		if (this.text_Recommend != null && this.text_Recommend.enabled)
		{
			this.text_Recommend.enabled = false;
			this.text_Recommend.enabled = true;
		}
		if (this.text_Dialogbox1 != null && this.text_Dialogbox1.enabled)
		{
			this.text_Dialogbox1.enabled = false;
			this.text_Dialogbox1.enabled = true;
		}
		if (this.text_MF_TimeCD != null && this.text_MF_TimeCD.enabled)
		{
			this.text_MF_TimeCD.enabled = false;
			this.text_MF_TimeCD.enabled = true;
		}
		if (this.text_Invite != null && this.text_Invite.enabled)
		{
			this.text_Invite.enabled = false;
			this.text_Invite.enabled = true;
		}
		if (this.text_Full != null && this.text_Full.enabled)
		{
			this.text_Full.enabled = false;
			this.text_Full.enabled = true;
		}
		if (this.text_FB_Gift != null && this.text_FB_Gift.enabled)
		{
			this.text_FB_Gift.enabled = false;
			this.text_FB_Gift.enabled = true;
		}
		if (this.text_FB_Receive != null && this.text_FB_Receive.enabled)
		{
			this.text_FB_Receive.enabled = false;
			this.text_FB_Receive.enabled = true;
		}
		if (this.text_FB_btnReceive != null && this.text_FB_btnReceive.enabled)
		{
			this.text_FB_btnReceive.enabled = false;
			this.text_FB_btnReceive.enabled = true;
		}
		if (this.text_btnMissionReceive1 != null && this.text_btnMissionReceive1.enabled)
		{
			this.text_btnMissionReceive1.enabled = false;
			this.text_btnMissionReceive1.enabled = true;
		}
		if (this.text_btnMissionReceive2 != null && this.text_btnMissionReceive2.enabled)
		{
			this.text_btnMissionReceive2.enabled = false;
			this.text_btnMissionReceive2.enabled = true;
		}
		for (int i = 0; i < 10; i++)
		{
			if (this.mMissionHead[i].text_MH_Time != null && this.mMissionHead[i].text_MH_Time.enabled)
			{
				this.mMissionHead[i].text_MH_Time.enabled = false;
				this.mMissionHead[i].text_MH_Time.enabled = true;
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (this.text_Dialogbox2_Mission[j] != null && this.text_Dialogbox2_Mission[j].enabled)
			{
				this.text_Dialogbox2_Mission[j].enabled = false;
				this.text_Dialogbox2_Mission[j].enabled = true;
			}
		}
		for (int k = 0; k < 3; k++)
		{
			if (this.text_HelpText[k] != null && this.text_HelpText[k].enabled)
			{
				this.text_HelpText[k].enabled = false;
				this.text_HelpText[k].enabled = true;
			}
		}
		for (int l = 0; l < 2; l++)
		{
			if (this.text_Time[l] != null && this.text_Time[l].enabled)
			{
				this.text_Time[l].enabled = false;
				this.text_Time[l].enabled = true;
			}
			if (this.text_TopInfo[l] != null && this.text_TopInfo[l].enabled)
			{
				this.text_TopInfo[l].enabled = false;
				this.text_TopInfo[l].enabled = true;
			}
			if (this.text_Dialogbox2_Degree[l] != null && this.text_Dialogbox2_Degree[l].enabled)
			{
				this.text_Dialogbox2_Degree[l].enabled = false;
				this.text_Dialogbox2_Degree[l].enabled = true;
			}
			if (this.text_DialogboxEnd[l] != null && this.text_DialogboxEnd[l].enabled)
			{
				this.text_DialogboxEnd[l].enabled = false;
				this.text_DialogboxEnd[l].enabled = true;
			}
		}
		if (this.FBUIHint != null)
		{
			this.FBUIHint.TextRefresh();
		}
	}

	// Token: 0x06001542 RID: 5442 RVA: 0x002480EC File Offset: 0x002462EC
	public override void UpdateTime(bool bOnSecond)
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		if (bOnSecond)
		{
			this.FBUIHint.UpdateTime();
			uint num = (DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex <= 11) ? DataManager.FBMissionDataManager.GetRemainTime() : 0u;
			this.MissionMap_T.GetChild(1).gameObject.SetActive(!this.DM.CheckPrizeFlag(29) && num == 0u);
			this.MissionMap_T.GetChild(0).gameObject.SetActive(!this.DM.CheckPrizeFlag(29) && num > 0u);
			for (int i = 0; i < 10; i++)
			{
				if (DataManager.FBMissionDataManager.GetFriendCountByProgress((byte)(i + 1)) > 0)
				{
					this.Remaining[i].Length = 0;
					SocialFriend socialFriend;
					DataManager.FBMissionDataManager.GetFriendSocialInfo((byte)(i + 1), 0, out socialFriend, false);
					if (socialFriend != null)
					{
						long num2 = socialFriend.MissionTime.BeginTime + (long)((ulong)socialFriend.MissionTime.RequireTime) - DataManager.Instance.ServerTime;
						if (((num2 < -5L && socialFriend.TimeRemain) || (num2 <= 0L && this.bUpdates)) && socialFriend.MissionTime.BeginTime > 0L && (DataManager.FBMissionDataManager.GetRewardCount() == 0 || DataManager.FBMissionDataManager.GetRewardSerial() != socialFriend.UserSerialNo))
						{
							socialFriend.TimeRemain = false;
							this.bRefresh = true;
						}
						if (num2 < 0L)
						{
							num2 = 0L;
						}
						if (socialFriend.MissionTime.BeginTime != 0L)
						{
							if (num2 < 3600L)
							{
								GameConstants.GetTimeString(this.Remaining[i], (uint)num2, false, true, false, false, true);
							}
							else if (num2 < 259200L)
							{
								this.Remaining[i].IntToFormat((num2 >= 86400L) ? (num2 / 86400L) : (num2 / 3600L), 1, false);
								this.Remaining[i].AppendFormat((num2 >= 86400L) ? "{0}d" : "{0}h");
							}
						}
						this.mFriendsHead[i].text_MH_Time.text = this.Remaining[i].ToString();
						this.mFriendsHead[i].text_MH_Time.cachedTextGenerator.Invalidate();
						this.mFriendsHead[i].text_MH_Time.SetAllDirty();
						this.mFriendsHead[i].Time.gameObject.SetActive(this.Remaining[i].Length > 0);
					}
				}
			}
			if (num > 0u)
			{
				CString timeStr = this.TimeStr;
				int length = 0;
				this.HourStr.Length = length;
				timeStr.Length = length;
				GameConstants.GetTimeString(this.TimeStr, num, false, true, false, false, true);
				this.text_Time[1].text = this.TimeStr.ToString();
				this.text_Time[1].cachedTextGenerator.Invalidate();
				this.text_Time[1].SetAllDirty();
				for (int j = 1; j < this.mMissionHead.Length; j++)
				{
					if ((DataManager.FBMissionDataManager.GetRewardCount() > 0 && (int)DataManager.FBMissionDataManager.GetRewardIndex() == j && DataManager.FBMissionDataManager.GetRewardSerial() == DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo) || (DataManager.FBMissionDataManager.IsInTime() && (int)DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex == j))
					{
						if (num < 3600u)
						{
							GameConstants.GetTimeString(this.HourStr, num, false, true, false, false, true);
						}
						else if (num < 259200u)
						{
							this.HourStr.IntToFormat((long)((ulong)((num >= 86400u) ? (num / 86400u) : (num / 3600u))), 1, false);
							this.HourStr.AppendFormat((num >= 86400u) ? "{0}d" : "{0}h");
						}
						this.mMissionHead[j - 1].Time.gameObject.SetActive(this.HourStr.Length > 0);
						this.mMissionHead[j - 1].text_MH_Time.text = this.HourStr.ToString();
						this.mMissionHead[j - 1].text_MH_Time.cachedTextGenerator.Invalidate();
						this.mMissionHead[j - 1].text_MH_Time.SetAllDirty();
						break;
					}
				}
			}
			else if (this.TimeStr.Length > 0)
			{
				this.TimeStr.ClearString();
				this.UpdateUI(0, 20);
			}
		}
		for (int k = 0; k < this.mFriendsHead.Length; k++)
		{
			if (this.mFriendsHead[k].Show > 0f)
			{
				if (this.mFriendsHead[k].Canvas.alpha < 1f)
				{
					this.mFriendsHead[k].Canvas.alpha += Time.smoothDeltaTime;
				}
				if (this.mFriendsHead[k].Canvas.alpha > 1f)
				{
					this.mFriendsHead[k].Canvas.alpha = 1f;
				}
			}
			else
			{
				if (this.mFriendsHead[k].Canvas.alpha > 0f)
				{
					this.mFriendsHead[k].Canvas.alpha -= Time.smoothDeltaTime;
				}
				if (this.mFriendsHead[k].Canvas.alpha < 0f)
				{
					this.mFriendsHead[k].Canvas.alpha = 0f;
				}
			}
		}
	}

	// Token: 0x06001543 RID: 5443 RVA: 0x00248704 File Offset: 0x00246904
	private void UpdateNPCName()
	{
		this.FB_T.gameObject.SetActive(false);
		this.NPC_T.gameObject.SetActive(true);
		Hero recordByKey = this.DM.HeroTable.GetRecordByKey(101);
		this.text_Npc_Tag.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.HeroTitle);
		this.text_Npc_Name.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.HeroName);
	}

	// Token: 0x06001544 RID: 5444 RVA: 0x0024878C File Offset: 0x0024698C
	private void UpdateFriendName(byte idx = 255, bool ShowReward = false)
	{
		this.FB_T.gameObject.SetActive(true);
		this.NPC_T.gameObject.SetActive(false);
		if (idx == 255)
		{
			this.ProFileStr = this.DM.RoleAttr.Inviter.Name;
			GameConstants.FormatRoleName(this.NameStr, this.ProFileStr, this.DM.RoleAttr.Inviter.AllianceTag, null, 0, 0, null, null, null, null);
			this.text_FB_Name.text = this.DM.RoleAttr.Inviter.SocialName.ToString();
			this.text_FB_Name.SetAllDirty();
			this.text_FB_Name.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.ProFileStr = DataManager.FBMissionDataManager.FBFriends[(int)idx].Name;
			GameConstants.FormatRoleName(this.NameStr, this.ProFileStr, DataManager.FBMissionDataManager.FBFriends[(int)idx].AllianceTag, null, 0, 0, null, null, null, null);
			this.text_FB_Name.text = DataManager.FBMissionDataManager.FBFriends[(int)idx].SocialName.ToString();
			this.text_FB_Name.SetAllDirty();
			this.text_FB_Name.cachedTextGenerator.Invalidate();
		}
		this.text_FB_Tag.fontSize = 16;
		this.text_FB_Tag.text = this.NameStr.ToString();
		this.text_FB_Tag.SetAllDirty();
		this.text_FB_Tag.cachedTextGenerator.Invalidate();
		this.text_FB_Tag.cachedTextGeneratorForLayout.Invalidate();
		float preferredWidth = this.text_FB_Tag.preferredWidth;
		if (preferredWidth > 160f)
		{
			for (int i = 1; i <= 2; i++)
			{
				this.text_FB_Tag.fontSize = 16 - i;
				this.text_FB_Tag.SetLayoutDirty();
				this.text_FB_Tag.cachedTextGeneratorForLayout.Invalidate();
				preferredWidth = this.text_FB_Tag.preferredWidth;
				if (preferredWidth <= 160f)
				{
					break;
				}
			}
			while (preferredWidth > 160f)
			{
				this.NameStr.Substring(this.NameStr.ToString(), 0, this.NameStr.Length - 2);
				this.text_FB_Tag.text = this.NameStr.ToString();
				this.text_FB_Tag.SetLayoutDirty();
				this.text_FB_Tag.cachedTextGeneratorForLayout.Invalidate();
				preferredWidth = this.text_FB_Tag.preferredWidth;
			}
			this.NameStr.Append("...");
			this.text_FB_Tag.text = this.NameStr.ToString();
			this.text_FB_Tag.SetAllDirty();
			this.text_FB_Tag.cachedTextGenerator.Invalidate();
			this.text_FB_Tag.cachedTextGeneratorForLayout.Invalidate();
			preferredWidth = this.text_FB_Tag.preferredWidth;
		}
		this.text_FB_Tag.rectTransform.sizeDelta = new Vector2(preferredWidth, this.text_FB_Tag.rectTransform.sizeDelta.y);
		this.ImgFB_Tag_Line.rectTransform.sizeDelta = new Vector2(preferredWidth, this.ImgFB_Tag_Line.rectTransform.sizeDelta.y);
		RectTransform rectTransform = this.btn_FB_Tag.transform as RectTransform;
		rectTransform.sizeDelta = new Vector2(160f, 48f);
	}

	// Token: 0x06001545 RID: 5445 RVA: 0x00248AE4 File Offset: 0x00246CE4
	private void Update()
	{
		if (this.bCloseExit)
		{
			if (this.door)
			{
				this.door.CloseMenu(false);
			}
			return;
		}
		if (!this.bOpenEnd)
		{
			return;
		}
		for (int i = 0; i < this.mMissionHead.Length; i++)
		{
			for (int j = 0; j < this.mMissionHead[i].Runner.Length; j++)
			{
				if (this.mMissionHead[i].Runner[j] != null)
				{
					this.mMissionHead[i].Runner[j].Update();
				}
			}
		}
		if (!this.bFinish && this.fPrize > 0f && (this.fPrize -= Time.deltaTime) <= 0f)
		{
			AudioManager.Instance.PlayMP3SFX(41011, 0f);
			this.bFinish = true;
		}
		if (this.fFinish > 0f && (this.fFinish -= Time.deltaTime) <= 0f)
		{
			AudioManager.Instance.PlayMP3SFX(41011, 0f);
			this.fFinish = 0f;
		}
		if ((this.fTime -= Time.deltaTime) <= 0f)
		{
			this.bUpdates = true;
			this.fTime = 10f;
		}
		if (this.fHide > 0f && (this.fHide -= Time.deltaTime) <= 0f)
		{
			AudioManager.Instance.PlayUISFX(UIKind.FBHide);
			this.fHide = 0f;
		}
		if (this.fFirst > 0f && (this.fFirst -= Time.deltaTime) <= 0f)
		{
			AudioManager.Instance.PlayUISFX(UIKind.FBShow);
			this.fFirst = 0f;
		}
		if (this.fFinal > 0f && (this.fFinal -= Time.deltaTime) <= 0f)
		{
			this.Img_MissionFinalHeadBG.gameObject.SetActive(true);
			this.fFinal = 0f;
		}
		if (this.bRefresh)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUESP_SOCIAL_REFRESH;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			this.bRefresh = (this.bUpdates = false);
		}
	}

	// Token: 0x04003E91 RID: 16017
	private DataManager DM;

	// Token: 0x04003E92 RID: 16018
	private GUIManager GUIM;

	// Token: 0x04003E93 RID: 16019
	private Transform GameT;

	// Token: 0x04003E94 RID: 16020
	private Transform Tmp;

	// Token: 0x04003E95 RID: 16021
	private Transform GifeT;

	// Token: 0x04003E96 RID: 16022
	private Transform FB_T;

	// Token: 0x04003E97 RID: 16023
	private Transform NPC_T;

	// Token: 0x04003E98 RID: 16024
	private Transform MissionMap_T;

	// Token: 0x04003E99 RID: 16025
	private Transform MissionLine_T;

	// Token: 0x04003E9A RID: 16026
	private Transform Light1_T;

	// Token: 0x04003E9B RID: 16027
	private Transform Light2_T;

	// Token: 0x04003E9C RID: 16028
	private RectTransform btn_FB_TagRT;

	// Token: 0x04003E9D RID: 16029
	private RectTransform ContentRT;

	// Token: 0x04003E9E RID: 16030
	private FBMissionManager.FBAward Award;

	// Token: 0x04003E9F RID: 16031
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x04003EA0 RID: 16032
	private Door door;

	// Token: 0x04003EA1 RID: 16033
	private UIButton btn_EXIT;

	// Token: 0x04003EA2 RID: 16034
	private UIButton btn_I;

	// Token: 0x04003EA3 RID: 16035
	private UIButton btn_FB_Tag;

	// Token: 0x04003EA4 RID: 16036
	private UIButton btnMissionGift;

	// Token: 0x04003EA5 RID: 16037
	private UIButton btnMissionReceive1;

	// Token: 0x04003EA6 RID: 16038
	private UIButton btnMissionReceive2;

	// Token: 0x04003EA7 RID: 16039
	private UIButton btnMissionGiftFinal;

	// Token: 0x04003EA8 RID: 16040
	private UIButton btnFB;

	// Token: 0x04003EA9 RID: 16041
	private UIButton btnReceive;

	// Token: 0x04003EAA RID: 16042
	private UIButton btnMissionMapinal;

	// Token: 0x04003EAB RID: 16043
	private UIButton btnInviteGift;

	// Token: 0x04003EAC RID: 16044
	public UIButton btnInvite;

	// Token: 0x04003EAD RID: 16045
	private UIButton btnBondGift;

	// Token: 0x04003EAE RID: 16046
	private Image Img_Head;

	// Token: 0x04003EAF RID: 16047
	private Image Img_PigHead;

	// Token: 0x04003EB0 RID: 16048
	private Image Img_Headload;

	// Token: 0x04003EB1 RID: 16049
	private Image Img_Headloading;

	// Token: 0x04003EB2 RID: 16050
	private Image Img_Recommend;

	// Token: 0x04003EB3 RID: 16051
	private Image ImgDialogbox1;

	// Token: 0x04003EB4 RID: 16052
	private Image ImgDialogbox2;

	// Token: 0x04003EB5 RID: 16053
	private Image[] ImgDialogbox2_Degree = new Image[2];

	// Token: 0x04003EB6 RID: 16054
	private Image ImgDialogboxEnd;

	// Token: 0x04003EB7 RID: 16055
	private Image ImgFB_Tag_Line;

	// Token: 0x04003EB8 RID: 16056
	private Image ImgMissionGift_Info;

	// Token: 0x04003EB9 RID: 16057
	private Image ImgMissionGiftFinal_Info;

	// Token: 0x04003EBA RID: 16058
	private Image ImgFBGiftReceive;

	// Token: 0x04003EBB RID: 16059
	private Image Img_TimeCD;

	// Token: 0x04003EBC RID: 16060
	private Image Img_TimeOut;

	// Token: 0x04003EBD RID: 16061
	private Image Img_Castle;

	// Token: 0x04003EBE RID: 16062
	private Image Img_MissionFinalHeadBG;

	// Token: 0x04003EBF RID: 16063
	private Image Img_MissionFinalHead;

	// Token: 0x04003EC0 RID: 16064
	private Image Img_MissionFinalTimeCD;

	// Token: 0x04003EC1 RID: 16065
	private Image Img_MissionFinalHeadLoad;

	// Token: 0x04003EC2 RID: 16066
	private Image[] Img_MissionInfo = new Image[10];

	// Token: 0x04003EC3 RID: 16067
	private Image Img_GiftNum;

	// Token: 0x04003EC4 RID: 16068
	private UIText text_Title;

	// Token: 0x04003EC5 RID: 16069
	private UIText[] text_HelpText = new UIText[3];

	// Token: 0x04003EC6 RID: 16070
	private UIText text_HelpTitle;

	// Token: 0x04003EC7 RID: 16071
	private UIText text_Recommend;

	// Token: 0x04003EC8 RID: 16072
	private UIText text_Dialogbox1;

	// Token: 0x04003EC9 RID: 16073
	private UIText[] text_Dialogbox2_Mission = new UIText[4];

	// Token: 0x04003ECA RID: 16074
	private UIText[] text_Dialogbox2_Degree = new UIText[2];

	// Token: 0x04003ECB RID: 16075
	private UIText[] text_DialogboxEnd = new UIText[2];

	// Token: 0x04003ECC RID: 16076
	private UIText text_FB_Name;

	// Token: 0x04003ECD RID: 16077
	private UIText text_FB_Tag;

	// Token: 0x04003ECE RID: 16078
	private UIText text_Npc_Name;

	// Token: 0x04003ECF RID: 16079
	private UIText text_Npc_Tag;

	// Token: 0x04003ED0 RID: 16080
	private UIText text_btnMissionReceive1;

	// Token: 0x04003ED1 RID: 16081
	private UIText text_btnMissionReceive2;

	// Token: 0x04003ED2 RID: 16082
	private UIText text_FB_Gift;

	// Token: 0x04003ED3 RID: 16083
	private UIText text_FB_btnReceive;

	// Token: 0x04003ED4 RID: 16084
	private UIText text_FB_Receive;

	// Token: 0x04003ED5 RID: 16085
	private UIText[] text_Time = new UIText[2];

	// Token: 0x04003ED6 RID: 16086
	private UIText text_TimeOut;

	// Token: 0x04003ED7 RID: 16087
	private UIText text_Invite;

	// Token: 0x04003ED8 RID: 16088
	private UIText[] text_TopInfo = new UIText[2];

	// Token: 0x04003ED9 RID: 16089
	private UIText text_Full;

	// Token: 0x04003EDA RID: 16090
	private UIText text_MF_TimeCD;

	// Token: 0x04003EDB RID: 16091
	private UIText text_GiftNum;

	// Token: 0x04003EDC RID: 16092
	private CString ProFileStr;

	// Token: 0x04003EDD RID: 16093
	private CString TimeStr;

	// Token: 0x04003EDE RID: 16094
	private CString NameStr;

	// Token: 0x04003EDF RID: 16095
	private CString HintStr;

	// Token: 0x04003EE0 RID: 16096
	private CString HelpStr;

	// Token: 0x04003EE1 RID: 16097
	private CString HourStr;

	// Token: 0x04003EE2 RID: 16098
	private CString Goal1Str;

	// Token: 0x04003EE3 RID: 16099
	private CString Goal2Str;

	// Token: 0x04003EE4 RID: 16100
	private CString Node1Str;

	// Token: 0x04003EE5 RID: 16101
	private CString Node2Str;

	// Token: 0x04003EE6 RID: 16102
	private CString FinishStr;

	// Token: 0x04003EE7 RID: 16103
	private UIHIBtn PiggyHead;

	// Token: 0x04003EE8 RID: 16104
	private UIFBHint FBUIHint;

	// Token: 0x04003EE9 RID: 16105
	private UIButtonHint Hint;

	// Token: 0x04003EEA RID: 16106
	private GameObject Particle;

	// Token: 0x04003EEB RID: 16107
	private Material m_Mat;

	// Token: 0x04003EEC RID: 16108
	private Material FrameMaterial;

	// Token: 0x04003EED RID: 16109
	private Material IconMaterial;

	// Token: 0x04003EEE RID: 16110
	private UISpritesArray SArray;

	// Token: 0x04003EEF RID: 16111
	private ushort Reward;

	// Token: 0x04003EF0 RID: 16112
	private ushort Price;

	// Token: 0x04003EF1 RID: 16113
	private float fPrize;

	// Token: 0x04003EF2 RID: 16114
	private float fFirst;

	// Token: 0x04003EF3 RID: 16115
	private float fTime;

	// Token: 0x04003EF4 RID: 16116
	private float fHide;

	// Token: 0x04003EF5 RID: 16117
	private float fFinal;

	// Token: 0x04003EF6 RID: 16118
	private float fFinish;

	// Token: 0x04003EF7 RID: 16119
	private bool bFinish;

	// Token: 0x04003EF8 RID: 16120
	private bool bMission;

	// Token: 0x04003EF9 RID: 16121
	private bool bRefresh;

	// Token: 0x04003EFA RID: 16122
	private bool bUpdates;

	// Token: 0x04003EFB RID: 16123
	private bool bOpenEnd;

	// Token: 0x04003EFC RID: 16124
	private bool bTimeEnd;

	// Token: 0x04003EFD RID: 16125
	private bool bGiftEnd;

	// Token: 0x04003EFE RID: 16126
	private bool bCloseExit;

	// Token: 0x04003EFF RID: 16127
	private FBMissionManager.FBMissionState[] State = new FBMissionManager.FBMissionState[2];

	// Token: 0x04003F00 RID: 16128
	private Color mMissionGray = new Color(0.447f, 0.3098f, 0.251f);

	// Token: 0x04003F01 RID: 16129
	private Color mMissionGreen = new Color(0f, 0.6f, 0.267f);

	// Token: 0x04003F02 RID: 16130
	private Color mDialogSelf = new Color(0.87f, 0.89f, 0.9f);

	// Token: 0x04003F03 RID: 16131
	private Color mDialogFriend = new Color(0.663f, 0.831f, 0.953f);

	// Token: 0x04003F04 RID: 16132
	private Vector3 mFriendHead;

	// Token: 0x04003F05 RID: 16133
	private MissionHeadUnit[] mMissionHead = new MissionHeadUnit[11];

	// Token: 0x04003F06 RID: 16134
	private MissionHeadUnit[] mFriendsHead = new MissionHeadUnit[11];

	// Token: 0x04003F07 RID: 16135
	private GameObject[] mPosition = new GameObject[11];

	// Token: 0x04003F08 RID: 16136
	private GameObject[] mFriends = new GameObject[11];

	// Token: 0x04003F09 RID: 16137
	private EmojiUnit[] Emoji = new EmojiUnit[13];

	// Token: 0x04003F0A RID: 16138
	private CString[] Remaining = new CString[10];
}
