using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x020005AA RID: 1450
public class UIHero_Info : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUTimeBarOnTimer
{
	// Token: 0x06001CA0 RID: 7328 RVA: 0x00329B20 File Offset: 0x00327D20
	public override void OnOpen(int arg1, int arg2)
	{
		this.mOpenKind = (byte)arg1;
		this.mOpenType = (byte)arg2;
		this.Cstr_RankTimeBar = StringManager.Instance.SpawnString(30);
		this.Cstr_Rank = StringManager.Instance.SpawnString(30);
		this.Cstr_NextRank = StringManager.Instance.SpawnString(30);
		this.Cstr_HeroStarLv = StringManager.Instance.SpawnString(30);
		this.Cstr_HeroEXP = StringManager.Instance.SpawnString(30);
		this.Cstr_HeroPower = StringManager.Instance.SpawnString(30);
		this.Cstr_Leader = StringManager.Instance.SpawnString(30);
		for (int i = 0; i < 4; i++)
		{
			this.Cstr_Skill_Lv[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_Skill_Cost[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_Skill_Info[i] = StringManager.Instance.SpawnString(100);
		}
		for (int j = 0; j < 6; j++)
		{
			this.Cstr_ShowEffect[j] = StringManager.Instance.SpawnString(30);
		}
		this.Cstr_Hint = StringManager.Instance.SpawnString(300);
		this.Cstr_NextRS = StringManager.Instance.SpawnString(30);
		for (int k = 0; k < 3; k++)
		{
			this.Cstr_Property[k] = StringManager.Instance.SpawnString(30);
		}
		for (int l = 0; l < 10; l++)
		{
			this.Cstr_ItemPropertyValue[l] = StringManager.Instance.SpawnString(30);
		}
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.GameT = base.gameObject.transform;
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.TopText[0] = this.DM.mStringTable.GetStringByID(370u);
		this.TopText[1] = this.DM.mStringTable.GetStringByID(372u);
		if (!NewbieManager.IsTeachWorking(ETeachKind.PUTON_EQUIP))
		{
			uint num = this.DM.sortHeroData[(int)this.mOpenKind];
			if (this.mOpenType != 1)
			{
				DataManager.SortHeroData();
				if (num == this.DM.sortHeroData[(int)this.mOpenKind] && !this.GUIM.m_IsOpenedUISynthesis)
				{
					this.GUIM.UIHero_Index = -1;
				}
			}
			else
			{
				DataManager.SortConditionHeroData();
				if (num == this.DM.sortHeroData[(int)this.mOpenKind])
				{
					this.GUIM.UIHero_Index = -1;
				}
				else
				{
					this.GUIM.UIPreviewHero_Index = -1;
				}
			}
		}
		else
		{
			this.GUIM.UIHero_Index = -1;
		}
		this.mHeroEquip = 0;
		this.bEnchantments = false;
		this.bStarEvolution = false;
		this.mNowpage = ((!NewbieManager.IsTeachWorking(ETeachKind.PUTON_EQUIP)) ? this.DM.Hero_Info_Page : 0);
		if (this.mOpenType != 1)
		{
			if (this.mNowpage == 1 && this.DM.Hero_Info_bHeroSkill)
			{
				this.mSkillpage = 1;
			}
			else
			{
				this.mSkillpage = 0;
			}
			if (this.mNowpage == 2 && !this.DM.Hero_Info_bHeroInfo)
			{
				this.bHeroInfo = false;
			}
		}
		else
		{
			this.mNowpage = 1;
			this.mSkillpage = 1;
		}
		this.TmpChildCount = 0;
		this.SkillLimit[0] = 0;
		this.SkillLimit[1] = 0;
		this.SkillLimit[2] = 20;
		this.SkillLimit[3] = 40;
		this.StarValue[0] = 0f;
		this.StarValue[1] = 1f;
		this.StarValue[2] = 1.5f;
		this.StarValue[3] = 2f;
		this.StarValue[4] = 2.5f;
		this.StarValue[5] = 3f;
		this.TmpTime = 0f;
		this.HP = 0u;
		this.EquipEffect_HP = 0u;
		this.Power = 0u;
		this.mHeroAct[0] = "idle";
		this.mHeroAct[1] = "moving";
		this.mHeroAct[2] = "attack";
		this.mHeroAct[3] = "skill_1";
		this.mHeroAct[4] = "skill_2";
		this.mHeroAct[5] = "skill_3";
		this.mHeroAct[6] = "victory";
		this.Vec3Instance = Vector3.zero;
		this.TTFont = this.GUIM.GetTTFFont();
		this.FrameMaterial = this.GUIM.GetFrameMaterial();
		this.IconMaterial = this.GUIM.m_IconSpriteAsset.GetMaterial();
		this.SkillMaterial = this.GUIM.GetSkillMaterial();
		Image component = this.GameT.GetChild(0).GetComponent<Image>();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			component.enabled = false;
		}
		this.Tmp = this.GameT.GetChild(0).GetChild(0);
		this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 1;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.Tmp = this.GameT.GetChild(2);
		this.btnPage[0] = this.Tmp.GetComponent<UIButton>();
		this.btnPage[0].m_Handler = this;
		this.btnPage[0].m_BtnID1 = 2;
		this.btnPage[0].SoundIndex = 3;
		this.Tmp2 = this.Tmp.GetChild(0);
		this.img_PageBG[0] = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp.GetChild(1);
		this.img_Pageicon[0] = this.Tmp2.GetComponent<Image>();
		this.Tmp = this.GameT.GetChild(3);
		this.btnPage[1] = this.Tmp.GetComponent<UIButton>();
		this.btnPage[1].m_Handler = this;
		this.btnPage[1].m_BtnID1 = 3;
		this.btnPage[1].SoundIndex = 3;
		this.Tmp2 = this.Tmp.GetChild(0);
		this.img_PageBG[1] = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp.GetChild(1);
		this.img_Pageicon[1] = this.Tmp2.GetComponent<Image>();
		this.Tmp = this.GameT.GetChild(4);
		this.btnPage[2] = this.Tmp.GetComponent<UIButton>();
		this.btnPage[2].m_Handler = this;
		this.btnPage[2].m_BtnID1 = 4;
		this.btnPage[2].SoundIndex = 3;
		this.Tmp2 = this.Tmp.GetChild(0);
		this.img_PageBG[2] = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp.GetChild(1);
		this.img_Pageicon[2] = this.Tmp2.GetComponent<Image>();
		this.PageT = this.GameT.GetChild(5);
		this.Tmp = this.GameT.GetChild(6);
		this.Hero_3D = this.GameT.GetChild(7);
		this.Tmp = this.Hero_3D.GetChild(0);
		this.btn_HeroPowerHint = this.Tmp.GetComponent<UIButton>();
		this.btn_HeroPowerHint.m_Handler = this;
		this.btn_HeroPowerHint.m_BtnID1 = 45;
		this.tmpbtnHint = this.btn_HeroPowerHint.gameObject.AddComponent<UIButtonHint>();
		this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.tmpbtnHint.m_Handler = this;
		this.Tmp = this.Hero_3D.GetChild(0).GetChild(1);
		this.text_HeroPower = this.Tmp.GetComponent<UIText>();
		this.text_HeroPower.font = this.TTFont;
		this.text_HeroPower.text = this.DM.mStringTable.GetStringByID(11u);
		this.Tmp = this.Hero_3D.GetChild(1).GetChild(0);
		this.img_Lv = this.Tmp.GetComponent<Image>();
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			this.img_Lv.sprite = this.SArray.m_Sprites[35];
		}
		if (this.GUIM.IsArabic)
		{
			this.img_Lv.transform.localScale = new Vector3(-1f, this.img_Lv.transform.localScale.y, this.img_Lv.transform.localScale.z);
		}
		this.Tmp = this.Hero_3D.GetChild(1).GetChild(1);
		this.text_Lv = this.Tmp.GetComponent<UIText>();
		this.text_Lv.font = this.TTFont;
		this.TmpChildCount = 2;
		this.Tmp = this.Hero_3D.GetChild(this.TmpChildCount);
		this.btn_Property = this.Tmp.GetComponent<UIButton>();
		this.btn_Property.m_Handler = this;
		this.btn_Property.m_BtnID1 = 38;
		this.tmpbtnHint = this.btn_Property.gameObject.AddComponent<UIButtonHint>();
		this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.tmpbtnHint.m_Handler = this;
		this.Tmp1 = this.Tmp.GetChild(0);
		this.Property_Hint = this.Tmp1.GetComponent<Image>();
		this.Property_Hint.sprite = this.door.LoadSprite("UI_main_box_012");
		this.Property_Hint.material = this.door.LoadMaterial();
		this.text_Hint[1] = this.Tmp1.GetChild(0).GetComponent<UIText>();
		this.text_Hint[1].font = this.TTFont;
		this.tmpbtnHint.ControlFadeOut = this.Property_Hint.gameObject;
		this.Tmp = this.Hero_3D.GetChild(this.TmpChildCount + 1).GetChild(0);
		this.img_HeroExp = this.Tmp.GetComponent<Image>();
		this.mExpLength = this.Tmp.GetComponent<RectTransform>().sizeDelta.x;
		this.Tmp = this.Hero_3D.GetChild(this.TmpChildCount + 1).GetChild(1);
		this.text_HeroEXP = this.Tmp.GetComponent<UIText>();
		this.text_HeroEXP.font = this.TTFont;
		this.Tmp = this.Hero_3D.GetChild(this.TmpChildCount + 2).GetChild(0);
		this.text_HeroTitle = this.Tmp.GetComponent<UIText>();
		this.text_HeroTitle.font = this.TTFont;
		this.Tmp = this.Hero_3D.GetChild(this.TmpChildCount + 2).GetChild(1);
		this.text_HeroName = this.Tmp.GetComponent<UIText>();
		this.text_HeroName.font = this.TTFont;
		this.Tmp = this.Hero_3D.GetChild(this.TmpChildCount + 3);
		this.btn_Fragment = this.Tmp.GetComponent<UIButton>();
		this.btn_Fragment.m_Handler = this;
		this.btn_Fragment.m_BtnID1 = 39;
		this.tmpbtnHint = this.btn_Fragment.gameObject.AddComponent<UIButtonHint>();
		this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.tmpbtnHint.m_Handler = this;
		this.Tmp1 = this.Tmp.GetChild(0);
		this.Fragment_Hint = this.Tmp1.GetComponent<Image>();
		this.Fragment_Hint.sprite = this.door.LoadSprite("UI_main_box_012");
		this.Fragment_Hint.material = this.door.LoadMaterial();
		this.text_Hint[0] = this.Tmp1.GetChild(0).GetComponent<UIText>();
		this.text_Hint[0].font = this.TTFont;
		this.tmpbtnHint.ControlFadeOut = this.Fragment_Hint.gameObject;
		this.Hero_Pos = this.GameT.GetChild(8);
		this.Hero_PosRT = this.Hero_Pos.GetComponent<RectTransform>();
		float x = this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x;
		this.tempL = (this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x - 853f) / 2f;
		this.btn_NextT = this.GameT.GetChild(9);
		this.btn_Next = this.btn_NextT.GetComponent<UIButton>();
		this.btn_Next.m_Handler = this;
		this.btn_Next.m_BtnID1 = 19;
		this.btn_Next.SoundIndex = 1;
		this.btn_Next.m_EffectType = e_EffectType.e_Scale;
		this.btn_Next.transition = Selectable.Transition.None;
		if (this.tempL > 0f && this.btn_NextT.localPosition.x + this.tempL > x / 2f)
		{
			this.tempL = x / 2f - this.btn_NextT.localPosition.x;
		}
		this.MoveTime1 = this.btn_NextT.localPosition.x + this.tempL;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.MoveTime1 -= this.GUIM.IPhoneX_DeltaX;
		}
		this.btn_BackT = this.GameT.GetChild(10);
		this.btn_Back = this.btn_BackT.GetComponent<UIButton>();
		this.btn_Back.m_Handler = this;
		this.btn_Back.m_BtnID1 = 20;
		this.btn_Back.SoundIndex = 1;
		this.btn_Back.m_EffectType = e_EffectType.e_Scale;
		this.btn_Back.transition = Selectable.Transition.None;
		this.MoveTime2 = this.btn_BackT.localPosition.x - this.tempL;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.MoveTime2 += this.GUIM.IPhoneX_DeltaX;
		}
		if (this.mOpenType == 1 && this.mOpenKind == 0)
		{
			this.btn_Next.gameObject.SetActive(false);
			this.btn_Back.gameObject.SetActive(false);
			this.OpenUISynthesis = false;
		}
		else
		{
			this.btn_Next.gameObject.SetActive(true);
			this.btn_Back.gameObject.SetActive(true);
		}
		this.Tmp = this.GameT.GetChild(11);
		this.btn_HeroAction = this.Tmp.GetComponent<UIButton>();
		this.btn_HeroAction.m_Handler = this;
		this.btn_HeroAction.m_BtnID1 = 21;
		this.btn_HeroAction.m_BtnID2 = 30006;
		this.btn_HeroActionD = this.Tmp.gameObject.AddComponent<UIBtnDrag>();
		this.btn_HeroActionD.mHero = this.Hero_PosRT;
		this.img_HeroState = this.Tmp.GetChild(0).GetComponent<Image>();
		this.img_HeroState.rectTransform.anchoredPosition3D = new Vector3(this.img_HeroState.rectTransform.anchoredPosition3D.x, this.img_HeroState.rectTransform.anchoredPosition3D.y, -1000f);
		this.btn_HeroState = this.Tmp.GetChild(0).GetComponent<UIButton>();
		this.btn_HeroState.m_Handler = this;
		this.btn_HeroState.m_BtnID1 = 44;
		this.tmpbtnHint = this.btn_HeroState.gameObject.AddComponent<UIButtonHint>();
		this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.tmpbtnHint.m_Handler = this;
		this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
		this.HeroState_Hint = this.Tmp1.GetComponent<Image>();
		this.HeroState_Hint.sprite = this.door.LoadSprite("UI_main_box_012");
		this.HeroState_Hint.material = this.door.LoadMaterial();
		this.HeroState_Hint.rectTransform.anchoredPosition3D = new Vector3(this.HeroState_Hint.rectTransform.anchoredPosition3D.x, this.HeroState_Hint.rectTransform.anchoredPosition3D.y, 0f);
		this.text_HeroStateHint = this.Tmp1.GetChild(0).GetComponent<UIText>();
		this.text_HeroStateHint.font = this.TTFont;
		this.text_HeroStateHint.text = string.Empty;
		this.tmpbtnHint.ControlFadeOut = this.Fragment_Hint.gameObject;
		this.Tmp = this.GameT.GetChild(12);
		this.btn_Rank_Exit = this.Tmp.GetComponent<UIButton>();
		this.btn_Rank_Exit.m_Handler = this;
		this.btn_Rank_Exit.m_BtnID1 = 28;
		this.btn_Rank_Exit.image.sprite = this.door.LoadSprite("UI_main_black");
		this.btn_Rank_Exit.image.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.Tmp.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.Tmp.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.Tmp1 = this.Tmp.GetChild(0).GetChild(0).GetChild(0);
		this.text_NextRankTiTle = this.Tmp1.GetComponent<UIText>();
		this.text_NextRankTiTle.font = this.TTFont;
		this.text_NextRankTiTle.text = this.DM.mStringTable.GetStringByID(365u);
		this.Tmp1 = this.Tmp.GetChild(1).GetChild(0);
		this.text_NextRank = this.Tmp1.GetComponent<UIText>();
		this.text_NextRank.font = this.TTFont;
		this.Rank_ImgT = this.Tmp.GetChild(2);
		this.Tmp1 = this.Tmp.GetChild(3);
		this.imgRank_Rank = this.Tmp1.GetComponent<Image>();
		for (int m = 0; m < 6; m++)
		{
			this.Tmp1 = this.Tmp.GetChild(10 + m);
			this.btn_RankEquip[m] = this.Tmp1.GetComponent<UIHIBtn>();
			this.btn_RankEquip[m].m_Handler = this;
			this.btn_RankEquip[m].m_BtnID1 = 22 + m;
			this.btn_RankEquip[m].image.material = this.IconMaterial;
			this.GUIM.InitianHeroItemImg(this.btn_RankEquip[m].transform, eHeroOrItem.Item, 0, 0, 0, 0, true, true, true, false);
		}
		this.text_Next_RankSoldier = this.Tmp.GetChild(16).GetComponent<UIText>();
		this.text_Next_RankSoldier.font = this.TTFont;
		this.Tmp = this.GameT.GetChild(13).GetChild(0);
		this.PropertyInfo_Hint = this.Tmp.GetComponent<Image>();
		this.PropertyInfo_Hint.sprite = this.door.LoadSprite("UI_main_box_012");
		this.PropertyInfo_Hint.material = this.door.LoadMaterial();
		this.PropertyInfo_HintRT[0] = this.Tmp.GetComponent<RectTransform>();
		this.text_Hint[2] = this.Tmp.GetChild(0).GetComponent<UIText>();
		this.text_Hint[2].font = this.TTFont;
		this.PropertyInfo_HintRT[1] = this.Tmp.GetChild(0).GetComponent<RectTransform>();
		this.Tmp = this.GameT.GetChild(13).GetChild(1);
		this.HeroPower_Hint = this.Tmp.GetComponent<Image>();
		this.Tmp = this.GameT.GetChild(13).GetChild(1).GetChild(0);
		this.text_HeroPowerHint = this.Tmp.GetComponent<UIText>();
		this.text_HeroPowerHint.font = this.TTFont;
		this.text_HeroPowerHint.text = this.DM.mStringTable.GetStringByID(19u);
		this.text_HeroPowerHint.rectTransform.sizeDelta = new Vector2(303f, this.text_HeroPowerHint.rectTransform.sizeDelta.y);
		this.HeroPower_Hint.rectTransform.sizeDelta = new Vector2(323f, this.HeroPower_Hint.rectTransform.sizeDelta.y);
		this.text_HeroPowerHint.SetAllDirty();
		this.text_HeroPowerHint.cachedTextGenerator.Invalidate();
		this.text_HeroPowerHint.cachedTextGeneratorForLayout.Invalidate();
		if (this.text_HeroPowerHint.preferredWidth > 303f)
		{
			this.text_HeroPowerHint.rectTransform.sizeDelta = new Vector2(this.text_HeroPowerHint.rectTransform.sizeDelta.x, this.text_HeroPowerHint.preferredHeight + 1f);
			this.HeroPower_Hint.rectTransform.sizeDelta = new Vector2(this.HeroPower_Hint.rectTransform.sizeDelta.x, this.text_HeroPowerHint.preferredHeight + 5f);
		}
		this.btn_HeroPowerHint.GetComponent<UIButtonHint>().ControlFadeOut = this.HeroPower_Hint.gameObject;
		for (int n = 0; n < 6; n++)
		{
			this.text_ShowEffect[n] = this.GameT.GetChild(13).GetChild(2 + n).GetComponent<UIText>();
			this.text_ShowEffect[n].font = this.TTFont;
		}
		this.Tmp = this.GameT.GetChild(14);
		this.img_PreviewBG = this.Tmp.GetComponent<Image>();
		this.Tmp = this.GameT.GetChild(14).GetChild(0);
		this.text_PreviewHero = this.Tmp.GetComponent<UIText>();
		this.text_PreviewHero.font = this.TTFont;
		if (this.mOpenType == 1)
		{
			if (this.mOpenKind == 0)
			{
				this.text_PreviewHero.text = this.DM.mStringTable.GetStringByID(10046u);
			}
			else
			{
				this.text_PreviewHero.text = this.DM.mStringTable.GetStringByID(10045u);
			}
			this.img_PreviewBG.gameObject.SetActive(true);
			this.Hero_3D.GetChild(this.TmpChildCount + 1).gameObject.SetActive(false);
			this.btn_HeroPowerHint.gameObject.SetActive(false);
		}
		else
		{
			this.img_PreviewBG.gameObject.SetActive(false);
			this.Hero_3D.GetChild(this.TmpChildCount + 1).gameObject.SetActive(true);
			this.btn_HeroPowerHint.gameObject.SetActive(true);
		}
		this.SetHeroData((int)this.mOpenKind, true, true);
		NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, this, false);
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001CA1 RID: 7329 RVA: 0x0032B27C File Offset: 0x0032947C
	public void LoadPage(int nowpage)
	{
		if (nowpage == 0)
		{
			this.go = (GameObject)UnityEngine.Object.Instantiate(this.m_AssetBundle.Load("Page1data"));
			this.Pagedata[0] = this.go.GetComponent<Transform>();
			this.Pagedata[0].SetParent(this.PageT, false);
			this.TmpChildCount = 0;
			this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount);
			this.btn_EquipStratum = this.Tmp.GetComponent<UIButton>();
			this.btn_EquipStratum.m_Handler = this;
			this.btn_EquipStratum.m_BtnID1 = 12;
			this.btn_EquipStratum.m_EffectType = e_EffectType.e_Scale;
			this.btn_EquipStratum.transition = Selectable.Transition.None;
			this.btn_NextRankRT = this.Tmp.GetComponent<RectTransform>();
			this.text_tmpStr[0] = this.Pagedata[0].GetChild(this.TmpChildCount + 1).GetChild(0).GetComponent<UIText>();
			this.text_tmpStr[0].font = this.TTFont;
			this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7u);
			this.TmpChildCount += 2;
			for (int i = 0; i < 6; i++)
			{
				this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount + i);
				this.Img_EquipRT[i] = this.Tmp.GetComponent<RectTransform>();
			}
			this.TmpChildCount += 6;
			this.Equip_ImgT = this.Pagedata[0].GetChild(this.TmpChildCount);
			this.RankLightBG = this.Equip_ImgT.GetComponent<Image>();
			this.TmpChildCount++;
			this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount);
			this.Tmp1 = this.Tmp.GetChild(2).GetChild(0);
			this.text_Medal = this.Tmp1.GetComponent<UIText>();
			this.text_Medal.font = this.TTFont;
			this.text_Medal.text = this.DM.mStringTable.GetStringByID(8u);
			this.Star_ImgT = this.Tmp.GetChild(3);
			this.StarStratumLightBG = this.Star_ImgT.GetComponent<Image>();
			this.Img_StarStratumLightRT = this.Star_ImgT.GetComponent<RectTransform>();
			this.Tmp1 = this.Tmp.GetChild(4);
			this.btn_DETAIL = this.Tmp1.GetComponent<UIButton>();
			this.btn_DETAIL.m_Handler = this;
			this.btn_DETAIL.m_BtnID1 = 14;
			this.btn_DETAIL.m_EffectType = e_EffectType.e_Scale;
			this.btn_DETAIL.transition = Selectable.Transition.None;
			if (this.mOpenType == 1)
			{
				this.btn_DETAIL.gameObject.SetActive(false);
			}
			else
			{
				this.btn_DETAIL.gameObject.SetActive(true);
			}
			this.btn_StarDetailRT = this.Tmp1.GetComponent<RectTransform>();
			this.Tmp1 = this.Tmp.GetChild(5);
			this.btn_StarEvolution = this.Tmp1.GetComponent<UIButton>();
			this.btn_StarEvolution.m_Handler = this;
			this.btn_StarEvolution.m_BtnID1 = 13;
			this.btn_StarEvolutionRT = this.Tmp1.GetComponent<RectTransform>();
			this.btn_StarEvolution.m_EffectType = e_EffectType.e_Scale;
			this.btn_StarEvolution.transition = Selectable.Transition.None;
			this.uToolStar = this.Tmp1.GetComponent<uTweenScale>();
			this.uToolStar.enabled = false;
			this.Img_StarEvolution = this.Tmp1.GetChild(0).GetComponent<Image>();
			this.text_HeroStarLv = this.Tmp1.GetChild(1).GetComponent<UIText>();
			this.text_HeroStarLv.font = this.TTFont;
			this.text_HeroStarLv.text = this.DM.mStringTable.GetStringByID(21u);
			this.StarLightT = this.Tmp.GetChild(6);
			this.mParticleStar = ParticleManager.Instance.Spawn(7, this.StarLightT, new Vector3(0f, 0f, 0f), 1f, true, true, true);
			this.GUIM.SetLayer(this.mParticleStar, 5);
			this.StarLightT.gameObject.SetActive(false);
			this.mParticleStar.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			this.Tmp1 = this.Tmp.GetChild(7);
			this.timeBarStar = this.Tmp1.GetComponent<UITimeBar>();
			this.GUIM.CreateTimerBar(this.timeBarStar, 0L, 0L, 0L, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(408u), this.DM.mStringTable.GetStringByID((uint)this.sHero.HeroTitle));
			this.GUIM.SetTimerSpriteType(this.timeBarStar, eTimerSpriteType.Speed);
			this.timeBarStar.m_Handler = this;
			this.timeBarStar.m_TimeBarID = 2;
			this.text_timeBarStar[0] = this.Tmp1.GetChild(2).GetComponent<UIText>();
			this.text_timeBarStar[1] = this.Tmp1.GetChild(3).GetComponent<UIText>();
			this.Tmp1 = this.Tmp.GetChild(8);
			this.StarEvolutionRT = this.Tmp1.GetComponent<RectTransform>();
			this.CheckStarTimeBar();
			this.TmpChildCount++;
			this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount);
			this.btn_Evolution = this.Tmp.GetComponent<UIButton>();
			this.btn_Evolution.m_Handler = this;
			this.btn_Evolution.m_BtnID1 = 5;
			this.btn_EvolutionRT = this.Tmp.GetComponent<RectTransform>();
			this.btn_Evolution.m_EffectType = e_EffectType.e_Scale;
			this.btn_Evolution.transition = Selectable.Transition.None;
			this.uToolRank = this.Tmp.GetComponent<uTweenScale>();
			this.uToolRank.enabled = false;
			this.Tmp1 = this.Tmp.GetChild(1);
			this.text_Rank = this.Tmp1.GetComponent<UIText>();
			this.text_Rank.font = this.TTFont;
			this.mParticleRank = ParticleManager.Instance.Spawn(6, this.Tmp, new Vector3(0f, 0f, 0f), 1f, true, true, true);
			this.GUIM.SetLayer(this.mParticleRank, 5);
			this.RankLightT = this.mParticleRank.transform;
			this.RankLightT.gameObject.SetActive(false);
			this.TmpChildCount++;
			this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount);
			this.Img_EvolutionUp = this.Tmp.GetComponent<Image>();
			this.Img_EvolutionUpRT = this.Tmp.GetComponent<RectTransform>();
			this.EvolutionRT = this.Tmp.GetChild(0).GetComponent<RectTransform>();
			this.TmpChildCount++;
			this.uToolRankPos = this.Pagedata[0].GetChild(this.TmpChildCount).GetComponent<uTweenPosition>();
			this.uTool_RankPosRT = this.Pagedata[0].GetChild(this.TmpChildCount).GetComponent<RectTransform>();
			this.TmpChildCount++;
			this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount);
			this.timeBarRank = this.Tmp.GetComponent<UITimeBar>();
			this.Cstr_RankTimeBar.ClearString();
			this.Cstr_RankTimeBar.IntToFormat((long)(this.mHeroData.Enhance + 1), 1, false);
			this.Cstr_RankTimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(409u));
			this.GUIM.CreateTimerBar(this.timeBarRank, 0L, 0L, 0L, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(407u), this.Cstr_RankTimeBar.ToString());
			this.GUIM.SetTimerSpriteType(this.timeBarRank, eTimerSpriteType.Speed);
			this.timeBarRank.m_Handler = this;
			this.timeBarRank.m_TimeBarID = 1;
			this.text_timeBarRank[0] = this.Tmp.GetChild(2).GetComponent<UIText>();
			this.text_timeBarRank[1] = this.Tmp.GetChild(3).GetComponent<UIText>();
			this.TmpChildCount++;
			for (int j = 0; j < 6; j++)
			{
				this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount + j);
				this.btn_Equip[j] = this.Tmp.GetComponent<UIHIBtn>();
				this.btn_Equip[j].m_Handler = this;
				this.btn_Equip[j].m_BtnID1 = 6 + j;
				this.btn_Equip[j].image.material = this.IconMaterial;
				this.btn_EquipRT[j] = this.Tmp.GetComponent<RectTransform>();
				this.GUIM.InitianHeroItemImg(this.btn_Equip[j].transform, eHeroOrItem.Item, 0, 0, 0, 0, false, false, true, true);
				this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount + j + 6);
				this.img_EquipHave_Light[j] = this.Tmp.GetComponent<Image>();
				this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount + j + 12);
				this.img_EquipLight[j] = this.Tmp.GetComponent<Image>();
				this.Img_EquipLightRT[j] = this.Tmp.GetComponent<RectTransform>();
				this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount + j + 18);
				this.img_EquipHave[j] = this.Tmp.GetComponent<Image>();
				this.Img_HaveRT[j] = this.Tmp.GetComponent<RectTransform>();
				this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount + j + 24);
				this.text_Equip[j] = this.Tmp.GetComponent<UIText>();
				this.text_Equip[j].font = this.TTFont;
				this.text_RT[j] = this.Tmp.GetComponent<RectTransform>();
			}
			this.CheckRankTimeBar();
			if (this.OpenPage == 0)
			{
				this.SetStratum(this.mHeroStratum);
				this.ReSetBtnState();
				if (this.mHeroData.Star < 5)
				{
					this.MaxStar = (float)this.DM.Medal[(int)this.mHeroData.Star];
				}
				this.SetStarStratum((int)this.DM.GetCurItemQuantity(this.sHero.SoulStone, 0), (int)this.mHeroData.Star);
			}
		}
		if (nowpage == 1)
		{
			this.go = (GameObject)UnityEngine.Object.Instantiate(this.m_AssetBundle.Load("Page2data"));
			this.go.transform.SetParent(this.PageT, false);
			this.Pagedata[1] = this.go.GetComponent<Transform>();
			this.TmpChildCount = 0;
			this.btn_SkillPage[0] = this.Pagedata[1].GetChild(1).GetComponent<UIButton>();
			this.btn_SkillPage[0].m_Handler = this;
			this.btn_SkillPage[0].m_BtnID1 = 32;
			this.img_SkillPage[0] = this.Pagedata[1].GetChild(1).GetChild(0).GetComponent<Image>();
			this.text_SkillPage[0] = this.Pagedata[1].GetChild(1).GetChild(1).GetComponent<UIText>();
			this.text_SkillPage[0].font = this.TTFont;
			this.text_SkillPage[0].text = this.DM.mStringTable.GetStringByID(369u);
			this.btn_SkillPage[1] = this.Pagedata[1].GetChild(2).GetComponent<UIButton>();
			this.btn_SkillPage[1].m_Handler = this;
			this.btn_SkillPage[1].m_BtnID1 = 33;
			this.img_SkillPage[1] = this.Pagedata[1].GetChild(2).GetChild(0).GetComponent<Image>();
			this.text_SkillPage[1] = this.Pagedata[1].GetChild(2).GetChild(1).GetComponent<UIText>();
			this.text_SkillPage[1].font = this.TTFont;
			this.text_SkillPage[1].text = this.DM.mStringTable.GetStringByID(33u);
			this.SkillPageT[0] = this.Pagedata[1].GetChild(3);
			this.Tmp = this.SkillPageT[0].GetChild(0);
			this.Tmp1 = this.Tmp.GetChild(2).GetChild(0);
			this.text_tmpStr[1] = this.Tmp1.GetComponent<UIText>();
			this.text_tmpStr[1].font = this.TTFont;
			this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(364u);
			this.Tmp1 = this.Tmp.GetChild(3);
			this.text_tmpStr[2] = this.Tmp1.GetChild(1).GetComponent<UIText>();
			this.text_tmpStr[2].font = this.TTFont;
			this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(343u);
			this.Tmp2 = this.Tmp1.GetChild(2);
			this.text_Leader[0] = this.Tmp2.GetComponent<UIText>();
			this.text_Leader[0].font = this.TTFont;
			this.Tmp1 = this.Tmp.GetChild(4);
			this.text_tmpStr[3] = this.Tmp1.GetChild(1).GetComponent<UIText>();
			this.text_tmpStr[3].font = this.TTFont;
			this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(367u);
			this.Tmp2 = this.Tmp1.GetChild(2);
			this.text_Leader[1] = this.Tmp2.GetComponent<UIText>();
			this.text_Leader[1].font = this.TTFont;
			for (int k = 0; k < 8; k++)
			{
				this.Tmp = this.SkillPageT[0].GetChild(1).GetChild(k);
				this.text_Skill2_[k] = this.Tmp.GetComponent<UIText>();
				this.text_Skill2_[k].font = this.TTFont;
			}
			for (int l = 0; l < 4; l++)
			{
				this.Tmp = this.SkillPageT[0].GetChild(4 + l);
				this.btn_Skill[l + 4] = this.Tmp.GetComponent<UIButton>();
				this.btn_Skill[l + 4].m_Handler = this;
				this.btn_Skill[l + 4].image.sprite = this.GUIM.LoadFrameSprite("sk");
				this.btn_Skill[l + 4].image.material = this.FrameMaterial;
				this.Tmp1 = this.Tmp.GetChild(2);
				this.tmpbtn = this.Tmp1.GetComponent<UIButton>();
				this.tmpbtn.m_Handler = this;
				this.tmpbtn.m_BtnID1 = 34 + l;
				this.tmpbtnHint = this.Tmp1.gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.ControlFadeOut = this.GUIM.m_SkillInfo.m_RectTransform.gameObject;
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.img_Skill[l + 4] = this.Tmp.GetChild(0).GetComponent<Image>();
				this.img_Skill[l + 4].material = this.SkillMaterial;
				this.tmpRC = this.Tmp.GetChild(0).GetComponent<RectTransform>();
				this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
				this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
				this.tmpRC.offsetMin = Vector2.zero;
				this.tmpRC.offsetMax = Vector2.zero;
				this.Tmp = this.SkillPageT[0].GetChild(4 + l).GetChild(1);
				this.img_SkillFrame[l + 4] = this.Tmp.GetComponent<Image>();
				this.img_SkillFrame[l + 4].sprite = this.GUIM.LoadFrameSprite("sk");
				this.img_SkillFrame[l + 4].material = this.FrameMaterial;
				this.tmpRC = this.Tmp.GetComponent<RectTransform>();
				this.tmpRC.anchorMin = Vector2.zero;
				this.tmpRC.anchorMax = new Vector2(1f, 1f);
				this.tmpRC.offsetMin = Vector2.zero;
				this.tmpRC.offsetMax = Vector2.zero;
			}
			for (int m = 0; m < 3; m++)
			{
				this.Tmp = this.SkillPageT[0].GetChild(8 + m);
				this.img_Lock[m + 3] = this.Tmp.GetComponent<Image>();
			}
			this.Cstr_Leader.ClearString();
			this.Cstr_Leader.IntToFormat((long)this.DM.RankSoldiers[(int)this.mHeroData.Enhance], 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Leader.AppendFormat("{0}+");
			}
			else
			{
				this.Cstr_Leader.AppendFormat("+{0}");
			}
			this.text_Leader[0].text = this.Cstr_Leader.ToString();
			this.text_Leader[0].SetAllDirty();
			this.text_Leader[0].cachedTextGenerator.Invalidate();
			this.text_Leader[1].text = this.DM.mStringTable.GetStringByID(3841u + (uint)this.sHero.SoldierKind);
			this.SkillPageT[1] = this.Pagedata[1].GetChild(4);
			this.Tmp = this.SkillPageT[1].GetChild(0);
			this.Skill_ImgT = this.Tmp.GetChild(0);
			this.Tmp1 = this.Tmp.GetChild(2).GetChild(0);
			this.text_Skill_Lv[0] = this.Tmp1.GetComponent<UIText>();
			this.text_Skill_Lv[0].font = this.TTFont;
			this.Tmp1 = this.Tmp.GetChild(3);
			this.text_Skill_Name = this.Tmp1.GetComponent<UIText>();
			this.text_Skill_Name.font = this.TTFont;
			this.Tmp = this.SkillPageT[1].GetChild(1);
			this.img_SkillBook[0] = this.Tmp.GetComponent<Image>();
			this.Tmp1 = this.Tmp.GetChild(0);
			this.img_Skill_Lv[0] = this.Tmp1.GetComponent<Image>();
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
			this.text_Skill_Lv[1] = this.Tmp1.GetComponent<UIText>();
			this.text_Skill_Lv[1].font = this.TTFont;
			this.Tmp = this.SkillPageT[1].GetChild(2);
			this.img_SkillBook[1] = this.Tmp.GetComponent<Image>();
			this.Tmp1 = this.Tmp.GetChild(0);
			this.img_Skill_Lv[1] = this.Tmp1.GetComponent<Image>();
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
			this.text_Skill_Lv[2] = this.Tmp1.GetComponent<UIText>();
			this.text_Skill_Lv[2].font = this.TTFont;
			this.Tmp = this.SkillPageT[1].GetChild(3);
			this.img_SkillBook[2] = this.Tmp.GetComponent<Image>();
			this.Tmp1 = this.Tmp.GetChild(0);
			this.img_Skill_Lv[2] = this.Tmp1.GetComponent<Image>();
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
			this.text_Skill_Lv[3] = this.Tmp1.GetComponent<UIText>();
			this.text_Skill_Lv[3].font = this.TTFont;
			for (int n = 0; n < 4; n++)
			{
				this.Tmp = this.SkillPageT[1].GetChild(4 + n);
				this.btn_Skill[n] = this.Tmp.GetComponent<UIButton>();
				this.tmpbtnHint = this.btn_Skill[n].gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.ControlFadeOut = this.GUIM.m_SkillInfo.m_RectTransform.gameObject;
				this.btn_Skill[n].m_Handler = this;
				this.btn_Skill[n].m_BtnID1 = 15 + n;
				this.btn_Skill[n].image.sprite = this.GUIM.LoadFrameSprite("sk");
				this.btn_Skill[n].image.material = this.FrameMaterial;
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.img_Skill[n] = this.Tmp.GetChild(0).GetComponent<Image>();
				this.img_Skill[n].material = this.SkillMaterial;
				this.tmpRC = this.Tmp.GetChild(0).GetComponent<RectTransform>();
				this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
				this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
				this.tmpRC.offsetMin = Vector2.zero;
				this.tmpRC.offsetMax = Vector2.zero;
				this.Tmp = this.SkillPageT[1].GetChild(4 + n).GetChild(1);
				this.img_SkillFrame[n] = this.Tmp.GetComponent<Image>();
				this.img_SkillFrame[n].sprite = this.GUIM.LoadFrameSprite("sk");
				this.img_SkillFrame[n].material = this.FrameMaterial;
				this.tmpRC = this.Tmp.GetComponent<RectTransform>();
				this.tmpRC.anchorMin = Vector2.zero;
				this.tmpRC.anchorMax = new Vector2(1f, 1f);
				this.tmpRC.offsetMin = Vector2.zero;
				this.tmpRC.offsetMax = Vector2.zero;
			}
			for (int num = 0; num < 3; num++)
			{
				this.Tmp = this.SkillPageT[1].GetChild(8 + num);
				this.img_Lock[num] = this.Tmp.GetComponent<Image>();
				this.Tmp1 = this.Tmp.GetChild(0);
				this.text_Skill_Lock[num] = this.Tmp1.GetComponent<UIText>();
				this.text_Skill_Lock[num].font = this.TTFont;
				this.text_Skill_Lock[num].text = this.DM.mStringTable.GetStringByID((uint)(26 + num));
			}
			if (this.OpenPage == 0)
			{
				this.ReSetSkill();
				if (this.mOpenType == 1)
				{
					this.SetSkillPage(true);
				}
				else
				{
					this.SetSkillPage(this.DM.Hero_Info_bHeroSkill);
				}
				Array.Clear(this.SendSkillLv, 0, this.SendSkillLv.Length);
			}
		}
		if (nowpage == 2)
		{
			this.go = (GameObject)UnityEngine.Object.Instantiate(this.m_AssetBundle.Load("Page3data"));
			this.go.transform.SetParent(this.PageT, false);
			this.Pagedata[2] = this.go.GetComponent<Transform>();
			this.Tmp = this.Pagedata[2].GetChild(0);
			this.btn_P3Info = this.Tmp.GetChild(0).GetComponent<UIButton>();
			this.btn_P3Info.m_Handler = this;
			this.btn_P3Info.m_BtnID1 = 31;
			this.btn_P3Info.m_EffectType = e_EffectType.e_Scale;
			this.btn_P3Info.transition = Selectable.Transition.None;
			this.text_P3Title = this.Tmp.GetChild(1).GetComponent<UIText>();
			this.text_P3Title.font = this.TTFont;
			this.text_P3Title.text = this.TopText[0];
			this.P3_p1 = this.Pagedata[2].GetChild(1);
			this.P3_p2 = this.Pagedata[2].GetChild(2);
			this.P3_p2.gameObject.SetActive(false);
			this.Tmp = this.P3_p1.GetChild(0).GetChild(0);
			this.text_tmpStr[4] = this.Tmp.GetComponent<UIText>();
			this.text_tmpStr[4].font = this.TTFont;
			this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(373u);
			this.Tmp = this.P3_p1.GetChild(1).GetChild(0);
			this.text_tmpStr[5] = this.Tmp.GetComponent<UIText>();
			this.text_tmpStr[5].font = this.TTFont;
			this.text_tmpStr[5].text = this.DM.mStringTable.GetStringByID(374u);
			for (int num2 = 0; num2 < 3; num2++)
			{
				this.btn_P3_Property[num2] = this.P3_p1.GetChild(2 + num2).GetComponent<UIButton>();
				this.btn_P3_Property[num2].m_Handler = this;
				this.btn_P3_Property[num2].m_BtnID1 = 40 + num2;
				this.tmpbtnHint = this.btn_P3_Property[num2].gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.ControlFadeOut = this.PropertyInfo_Hint.gameObject;
			}
			this.Tmp = this.P3_p1.GetChild(2).GetChild(1);
			this.text_tmpStr[6] = this.Tmp.GetComponent<UIText>();
			this.text_tmpStr[6].font = this.TTFont;
			this.text_tmpStr[6].text = this.DM.mStringTable.GetStringByID(122u);
			this.Tmp = this.P3_p1.GetChild(2).GetChild(2);
			this.text_Property[0] = this.Tmp.GetComponent<UIText>();
			this.text_Property[0].font = this.TTFont;
			this.Tmp = this.P3_p1.GetChild(2).GetChild(3);
			this.text_Property[1] = this.Tmp.GetComponent<UIText>();
			this.text_Property[1].font = this.TTFont;
			this.Tmp = this.P3_p1.GetChild(3).GetChild(1);
			this.text_tmpStr[7] = this.Tmp.GetComponent<UIText>();
			this.text_tmpStr[7].font = this.TTFont;
			this.text_tmpStr[7].text = this.DM.mStringTable.GetStringByID(123u);
			this.Tmp = this.P3_p1.GetChild(3).GetChild(2);
			this.text_Property[2] = this.Tmp.GetComponent<UIText>();
			this.text_Property[2].font = this.TTFont;
			this.Tmp = this.P3_p1.GetChild(3).GetChild(3);
			this.text_Property[3] = this.Tmp.GetComponent<UIText>();
			this.text_Property[3].font = this.TTFont;
			this.Tmp = this.P3_p1.GetChild(4).GetChild(1);
			this.text_tmpStr[8] = this.Tmp.GetComponent<UIText>();
			this.text_tmpStr[8].font = this.TTFont;
			this.text_tmpStr[8].text = this.DM.mStringTable.GetStringByID(124u);
			this.Tmp = this.P3_p1.GetChild(4).GetChild(2);
			this.text_Property[4] = this.Tmp.GetComponent<UIText>();
			this.text_Property[4].font = this.TTFont;
			this.Tmp = this.P3_p1.GetChild(4).GetChild(3);
			this.text_Property[5] = this.Tmp.GetComponent<UIText>();
			this.text_Property[5].font = this.TTFont;
			this.Tmp = this.P3_p1.GetChild(5).GetChild(0).GetChild(0);
			this.text_tmpStr[9] = this.Tmp.GetComponent<UIText>();
			this.text_tmpStr[9].font = this.TTFont;
			this.text_tmpStr[9].text = this.DM.mStringTable.GetStringByID(371u);
			this.m_Mask = this.P3_p1.GetChild(5).GetChild(1).GetComponent<ScrollRect>();
			this.Tmp = this.P3_p1.GetChild(5).GetChild(1).GetChild(0);
			this.ContentRT = this.Tmp.GetComponent<RectTransform>();
			this.Tmp1 = this.Tmp.GetChild(0);
			this.text_HeroInfo = this.Tmp1.GetComponent<UIText>();
			this.text_HeroInfo.font = this.TTFont;
			this.Tmp = this.P3_p2.GetChild(0);
			this.m_itemView = this.Tmp.GetComponent<ScrollPanel>();
			this.Tmp = this.P3_p2.GetChild(1).GetChild(0).GetChild(0);
			this.tmptext = this.Tmp.GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			this.Tmp = this.P3_p2.GetChild(1).GetChild(1).GetChild(0);
			this.tmptext = this.Tmp.GetComponent<UIText>();
			this.tmptext.font = this.TTFont;
			this.tmpbtn = this.P3_p2.GetChild(1).GetChild(3).GetComponent<UIButton>();
			this.tmpbtn.m_Handler = this;
			this.tmpbtn.m_BtnID1 = 0;
			this.tmpbtnHint = this.tmpbtn.gameObject.AddComponent<UIButtonHint>();
			this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
			this.tmpbtnHint.m_Handler = this;
			this.tmpbtnHint.ControlFadeOut = this.PropertyInfo_Hint.gameObject;
			int num3 = 10;
			for (int num4 = 0; num4 < num3; num4++)
			{
				this.tmplist.Add(45f);
			}
			this.m_itemView.IntiScrollPanel(385f, 3f, 0f, this.tmplist, num3, this);
			this.m_ScrollRect = this.m_itemView.GetComponent<CScrollRect>();
			UIButtonHint.scrollRect = this.m_ScrollRect;
			if (this.OpenPage == 0)
			{
				this.SetPage3InfoData();
				if (this.mOpenType == 1)
				{
					this.SetPage3Info(true);
				}
				else
				{
					this.SetPage3Info(this.DM.Hero_Info_bHeroInfo);
				}
			}
		}
	}

	// Token: 0x06001CA2 RID: 7330 RVA: 0x0032D16C File Offset: 0x0032B36C
	public void SetPage(int nowpage)
	{
		if (this.Pagedata[nowpage] == null && this.OpenPage != 0)
		{
			this.LoadPage(nowpage);
		}
		for (int i = 0; i < 3; i++)
		{
			this.btnPage[i].image.sprite = this.SArray.m_Sprites[1];
			this.img_PageBG[i].color = new Color(1f, 1f, 1f, 0f);
			if (this.Pagedata[i])
			{
				this.Pagedata[i].gameObject.SetActive(false);
				if (i == 2 && this.PropertyInfo_Hint.IsActive())
				{
					this.PropertyInfo_Hint.gameObject.SetActive(false);
				}
			}
		}
		this.mNowpage = nowpage;
		if (this.mOpenType != 1)
		{
			this.DM.Hero_Info_Page = this.mNowpage;
		}
		this.img_PageBG[nowpage].color = new Color(1f, 1f, 1f, 1f);
		this.PageBGTime = 0f;
		if (this.Pagedata[this.mNowpage])
		{
			this.Pagedata[this.mNowpage].gameObject.SetActive(true);
		}
		this.btn_Fragment.image.sprite = this.SArray.m_Sprites[9 + this.mHeroStratum];
		if (this.mNowpage == 0 && this.Pagedata[0] != null)
		{
			if (!this.bEquip)
			{
				this.bEquip = true;
				this.SetStratum(this.mHeroStratum);
				this.ReSetBtnState();
			}
			this.CheckRankTimeBar();
			if (this.mHeroData.Star < 5)
			{
				this.MaxStar = (float)this.DM.Medal[(int)this.mHeroData.Star];
			}
			this.SetStarStratum((int)this.DM.GetCurItemQuantity(this.sHero.SoulStone, 0), (int)this.mHeroData.Star);
			this.CheckStarTimeBar();
			for (int j = 0; j < 6; j++)
			{
				this.img_EquipLight[j].gameObject.SetActive(false);
			}
		}
		if (this.mNowpage == 1 && !this.bSkill && this.Pagedata[1] != null)
		{
			this.bSkill = true;
			this.ReSetSkill();
			Array.Clear(this.SendSkillLv, 0, this.SendSkillLv.Length);
			this.Cstr_Leader.ClearString();
			this.Cstr_Leader.IntToFormat((long)this.DM.RankSoldiers[(int)this.mHeroData.Enhance], 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Leader.AppendFormat("{0}+");
			}
			else
			{
				this.Cstr_Leader.AppendFormat("+{0}");
			}
			this.text_Leader[0].text = this.Cstr_Leader.ToString();
			this.text_Leader[0].SetAllDirty();
			this.text_Leader[0].cachedTextGenerator.Invalidate();
			this.text_Leader[1].text = this.DM.mStringTable.GetStringByID(3841u + (uint)this.sHero.SoldierKind);
		}
		if (this.mNowpage == 2 && !this.bInfo && this.Pagedata[2] != null)
		{
			this.bInfo = true;
			this.SetPage3InfoData();
		}
	}

	// Token: 0x06001CA3 RID: 7331 RVA: 0x0032D504 File Offset: 0x0032B704
	public void CheckRankTimeBar()
	{
		if (this.mHeroData.ID == this.DM.RoleAttr.EnhanceEventHeroID && this.DM.queueBarData[11].bActive && this.mOpenType != 1)
		{
			if (this.bFSetRankTimeBar)
			{
				this.begin = this.DM.queueBarData[11].StartTime;
				this.target = this.begin + (long)((ulong)this.DM.queueBarData[11].TotalTime);
				eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.HeroEnhance);
				if (queueBarSpriteType == eTimerSpriteType.Free)
				{
					this.notify = 0L;
				}
				else
				{
					this.notify = this.target - (long)this.DM.FreeCompletePeriod;
				}
				this.Cstr_RankTimeBar.ClearString();
				this.Cstr_RankTimeBar.IntToFormat((long)(this.mHeroData.Enhance + 1), 1, false);
				this.Cstr_RankTimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(409u));
				this.GUIM.SetTimerBar(this.timeBarRank, this.begin, this.target, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(407u), this.Cstr_RankTimeBar.ToString());
				this.GUIM.SetTimerSpriteType(this.timeBarRank, queueBarSpriteType);
				this.bFSetRankTimeBar = false;
			}
			this.RankLightT.gameObject.SetActive(true);
			this.btn_EvolutionRT.anchoredPosition = new Vector2(this.btn_EvolutionRT.anchoredPosition.x, -245f);
			this.Img_EvolutionUpRT.anchoredPosition = new Vector2(this.Img_EvolutionUpRT.anchoredPosition.x, -266f);
			this.btn_NextRankRT.anchoredPosition = new Vector2(this.btn_NextRankRT.anchoredPosition.x, -149f);
			this.uTool_RankPosRT.anchoredPosition = new Vector2(this.uTool_RankPosRT.anchoredPosition.x, -186f);
			this.btn_EquipRT[0].anchoredPosition = new Vector2(this.btn_EquipRT[0].anchoredPosition.x, -167f);
			this.btn_EquipRT[5].anchoredPosition = new Vector2(this.btn_EquipRT[5].anchoredPosition.x, -167f);
			this.btn_EquipRT[1].anchoredPosition = new Vector2(this.btn_EquipRT[1].anchoredPosition.x, -249f);
			this.btn_EquipRT[4].anchoredPosition = new Vector2(this.btn_EquipRT[4].anchoredPosition.x, -249f);
			this.btn_EquipRT[2].anchoredPosition = new Vector2(this.btn_EquipRT[2].anchoredPosition.x, -331f);
			this.btn_EquipRT[3].anchoredPosition = new Vector2(this.btn_EquipRT[3].anchoredPosition.x, -331f);
			this.Img_EquipRT[0].anchoredPosition = new Vector2(this.Img_EquipRT[0].anchoredPosition.x, -167f);
			this.Img_EquipRT[5].anchoredPosition = new Vector2(this.Img_EquipRT[5].anchoredPosition.x, -167f);
			this.Img_EquipRT[1].anchoredPosition = new Vector2(this.Img_EquipRT[1].anchoredPosition.x, -249f);
			this.Img_EquipRT[4].anchoredPosition = new Vector2(this.Img_EquipRT[4].anchoredPosition.x, -249f);
			this.Img_EquipRT[2].anchoredPosition = new Vector2(this.Img_EquipRT[2].anchoredPosition.x, -331f);
			this.Img_EquipRT[3].anchoredPosition = new Vector2(this.Img_EquipRT[3].anchoredPosition.x, -331f);
			this.Img_HaveRT[0].anchoredPosition = new Vector2(this.Img_HaveRT[0].anchoredPosition.x, -149f);
			this.Img_HaveRT[5].anchoredPosition = new Vector2(this.Img_HaveRT[5].anchoredPosition.x, -149f);
			this.Img_HaveRT[1].anchoredPosition = new Vector2(this.Img_HaveRT[1].anchoredPosition.x, -231f);
			this.Img_HaveRT[4].anchoredPosition = new Vector2(this.Img_HaveRT[4].anchoredPosition.x, -231f);
			this.Img_HaveRT[2].anchoredPosition = new Vector2(this.Img_HaveRT[2].anchoredPosition.x, -313f);
			this.Img_HaveRT[3].anchoredPosition = new Vector2(this.Img_HaveRT[3].anchoredPosition.x, -313f);
			this.text_RT[0].anchoredPosition = new Vector2(this.text_RT[0].anchoredPosition.x, -188f);
			this.text_RT[5].anchoredPosition = new Vector2(this.text_RT[5].anchoredPosition.x, -188f);
			this.text_RT[1].anchoredPosition = new Vector2(this.text_RT[1].anchoredPosition.x, -270f);
			this.text_RT[4].anchoredPosition = new Vector2(this.text_RT[4].anchoredPosition.x, -270f);
			this.text_RT[2].anchoredPosition = new Vector2(this.text_RT[2].anchoredPosition.x, -352f);
			this.text_RT[3].anchoredPosition = new Vector2(this.text_RT[3].anchoredPosition.x, -352f);
			this.timeBarRank.gameObject.SetActive(true);
			this.EvolutionRT.gameObject.SetActive(false);
		}
		else
		{
			this.RankLightT.gameObject.SetActive(false);
			this.btn_EvolutionRT.anchoredPosition = new Vector2(this.btn_EvolutionRT.anchoredPosition.x, -275f);
			this.Img_EvolutionUpRT.anchoredPosition = new Vector2(this.Img_EvolutionUpRT.anchoredPosition.x, -296f);
			this.btn_NextRankRT.anchoredPosition = new Vector2(this.btn_NextRankRT.anchoredPosition.x, -175f);
			this.uTool_RankPosRT.anchoredPosition = new Vector2(this.uTool_RankPosRT.anchoredPosition.x, -213f);
			this.btn_EquipRT[0].anchoredPosition = new Vector2(this.btn_EquipRT[0].anchoredPosition.x, -182f);
			this.btn_EquipRT[5].anchoredPosition = new Vector2(this.btn_EquipRT[5].anchoredPosition.x, -182f);
			this.btn_EquipRT[1].anchoredPosition = new Vector2(this.btn_EquipRT[1].anchoredPosition.x, -279f);
			this.btn_EquipRT[4].anchoredPosition = new Vector2(this.btn_EquipRT[4].anchoredPosition.x, -279f);
			this.btn_EquipRT[2].anchoredPosition = new Vector2(this.btn_EquipRT[2].anchoredPosition.x, -370f);
			this.btn_EquipRT[3].anchoredPosition = new Vector2(this.btn_EquipRT[3].anchoredPosition.x, -370f);
			this.Img_EquipRT[0].anchoredPosition = new Vector2(this.Img_EquipRT[0].anchoredPosition.x, -182f);
			this.Img_EquipRT[5].anchoredPosition = new Vector2(this.Img_EquipRT[5].anchoredPosition.x, -182f);
			this.Img_EquipRT[1].anchoredPosition = new Vector2(this.Img_EquipRT[1].anchoredPosition.x, -279f);
			this.Img_EquipRT[4].anchoredPosition = new Vector2(this.Img_EquipRT[4].anchoredPosition.x, -279f);
			this.Img_EquipRT[2].anchoredPosition = new Vector2(this.Img_EquipRT[2].anchoredPosition.x, -370f);
			this.Img_EquipRT[3].anchoredPosition = new Vector2(this.Img_EquipRT[3].anchoredPosition.x, -370f);
			this.Img_HaveRT[0].anchoredPosition = new Vector2(this.Img_HaveRT[0].anchoredPosition.x, -164f);
			this.Img_HaveRT[5].anchoredPosition = new Vector2(this.Img_HaveRT[5].anchoredPosition.x, -164f);
			this.Img_HaveRT[1].anchoredPosition = new Vector2(this.Img_HaveRT[1].anchoredPosition.x, -261f);
			this.Img_HaveRT[4].anchoredPosition = new Vector2(this.Img_HaveRT[4].anchoredPosition.x, -261f);
			this.Img_HaveRT[2].anchoredPosition = new Vector2(this.Img_HaveRT[2].anchoredPosition.x, -352f);
			this.Img_HaveRT[3].anchoredPosition = new Vector2(this.Img_HaveRT[3].anchoredPosition.x, -352f);
			this.text_RT[0].anchoredPosition = new Vector2(this.text_RT[0].anchoredPosition.x, -203f);
			this.text_RT[5].anchoredPosition = new Vector2(this.text_RT[5].anchoredPosition.x, -203f);
			this.text_RT[1].anchoredPosition = new Vector2(this.text_RT[1].anchoredPosition.x, -300f);
			this.text_RT[4].anchoredPosition = new Vector2(this.text_RT[4].anchoredPosition.x, -300f);
			this.text_RT[2].anchoredPosition = new Vector2(this.text_RT[2].anchoredPosition.x, -391f);
			this.text_RT[3].anchoredPosition = new Vector2(this.text_RT[3].anchoredPosition.x, -391f);
			this.timeBarRank.gameObject.SetActive(false);
			this.bFSetRankTimeBar = true;
			this.EvolutionRT.gameObject.SetActive(true);
		}
		this.uToolRankPos.from = new Vector3(this.uTool_RankPosRT.anchoredPosition.x, this.uTool_RankPosRT.anchoredPosition.y - 3f, 0f);
		this.uToolRankPos.to = new Vector3(this.uTool_RankPosRT.anchoredPosition.x, this.uTool_RankPosRT.anchoredPosition.y + 3f, 0f);
	}

	// Token: 0x06001CA4 RID: 7332 RVA: 0x0032E134 File Offset: 0x0032C334
	public void CheckStarTimeBar()
	{
		if (this.mHeroData.ID == this.DM.RoleAttr.StarUpEventHeroID && this.DM.queueBarData[12].bActive && this.mOpenType != 1)
		{
			if (this.bFSetStarTimeBar)
			{
				this.begin = this.DM.queueBarData[12].StartTime;
				this.target = this.begin + (long)((ulong)this.DM.queueBarData[12].TotalTime);
				eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.HeroEvolution);
				if (queueBarSpriteType == eTimerSpriteType.Free)
				{
					this.notify = 0L;
				}
				else
				{
					this.notify = this.target - (long)this.DM.FreeCompletePeriod;
				}
				this.GUIM.SetTimerBar(this.timeBarStar, this.begin, this.target, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(408u), this.DM.mStringTable.GetStringByID((uint)this.sHero.HeroTitle));
				this.GUIM.SetTimerSpriteType(this.timeBarStar, queueBarSpriteType);
				this.bFSetStarTimeBar = false;
			}
			this.StarLightT.gameObject.SetActive(true);
			this.Img_StarStratumLightRT.anchoredPosition = new Vector2(this.Img_StarStratumLightRT.anchoredPosition.x, -95.5f);
			this.btn_StarDetailRT.anchoredPosition = new Vector2(this.btn_StarDetailRT.anchoredPosition.x, -95.5f);
			this.btn_StarEvolutionRT.anchoredPosition = new Vector2(this.btn_StarEvolutionRT.anchoredPosition.x, -95.5f);
			this.timeBarStar.gameObject.SetActive(true);
			this.StarEvolutionRT.gameObject.SetActive(false);
			this.StarEvolutionRT.anchoredPosition = new Vector2(this.StarEvolutionRT.anchoredPosition.x, -60f);
		}
		else
		{
			this.StarLightT.gameObject.SetActive(false);
			this.Img_StarStratumLightRT.anchoredPosition = new Vector2(this.Img_StarStratumLightRT.anchoredPosition.x, -119.5f);
			this.btn_StarDetailRT.anchoredPosition = new Vector2(this.btn_StarDetailRT.anchoredPosition.x, -119.5f);
			this.btn_StarEvolutionRT.anchoredPosition = new Vector2(this.btn_StarEvolutionRT.anchoredPosition.x, -119.5f);
			this.GUIM.SetTimerBar(this.timeBarStar, 0L, 0L, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(408u), this.DM.mStringTable.GetStringByID((uint)this.sHero.HeroTitle));
			this.GUIM.SetTimerSpriteType(this.timeBarStar, eTimerSpriteType.Speed);
			this.timeBarStar.gameObject.SetActive(false);
			this.StarEvolutionRT.anchoredPosition = new Vector2(this.StarEvolutionRT.anchoredPosition.x, -80f);
		}
	}

	// Token: 0x06001CA5 RID: 7333 RVA: 0x0032E47C File Offset: 0x0032C67C
	public void SetPage3Info(bool bInfo)
	{
		this.PropertyInfo_Hint.gameObject.SetActive(false);
		this.bHeroInfo = bInfo;
		if (this.mOpenType != 1)
		{
			this.DM.Hero_Info_bHeroInfo = this.bHeroInfo;
		}
		if (this.bHeroInfo)
		{
			this.P3_p1.gameObject.SetActive(true);
			this.P3_p2.gameObject.SetActive(false);
			this.text_P3Title.text = this.TopText[0];
		}
		else
		{
			this.P3_p1.gameObject.SetActive(false);
			this.P3_p2.gameObject.SetActive(true);
			this.text_P3Title.text = this.TopText[1];
		}
	}

	// Token: 0x06001CA6 RID: 7334 RVA: 0x0032E538 File Offset: 0x0032C738
	public void SetHeroData(int sortIndex = 0, bool Load3d = true, bool bOpen = true)
	{
		if (this.mOpenType == 1 && this.mOpenKind == 1 && this.GUIM.UIPreviewHero_Index != -1)
		{
			sortIndex = this.GUIM.UIPreviewHero_Index;
			this.GUIM.UIPreviewHero_Index = -1;
		}
		if (this.GUIM.UIHero_Index > -1)
		{
			for (int i = 0; i < this.DM.sortHeroData.Length; i++)
			{
				if ((long)this.GUIM.UIHero_Index == (long)((ulong)this.DM.sortHeroData[i]))
				{
					this.mHeroDataIndex = i;
					this.GUIM.UIHero_Index = -1;
					break;
				}
			}
		}
		else
		{
			this.mHeroDataIndex = sortIndex;
		}
		if (this.mHeroDataIndex == -1)
		{
			this.mHeroDataIndex = 0;
		}
		if (this.mOpenType == 1 && this.mOpenKind == 0)
		{
			this.mHeroData = this.DM.PreviewHeroData;
		}
		else
		{
			uint num = this.DM.sortHeroData[this.mHeroDataIndex];
			if (this.DM.curHeroData.ContainsKey(num))
			{
				this.mHeroData = this.DM.curHeroData[num];
			}
			this.mHeroData = this.DM.curHeroData[num];
			if (this.mOpenType == 1)
			{
				this.DM.PreviewHeroData.ID = this.mHeroData.ID;
				this.mHeroData = this.DM.PreviewHeroData;
			}
		}
		this.sHero = this.DM.HeroTable.GetRecordByKey(this.mHeroData.ID);
		this.mEnhance = this.DM.EnhanceTable.GetRecordByKey(this.sHero.HeroKey);
		this.mHeroState = this.DM.GetHeroState(this.mHeroData.ID);
		if (this.mHeroState == eHeroState.None)
		{
			this.img_HeroState.gameObject.SetActive(false);
		}
		else
		{
			if (this.mOpenType == 1)
			{
				this.img_HeroState.rectTransform.anchoredPosition = new Vector2(this.img_HeroState.rectTransform.anchoredPosition.x, -50f);
			}
			else
			{
				this.img_HeroState.rectTransform.anchoredPosition = new Vector2(this.img_HeroState.rectTransform.anchoredPosition.x, -121f);
			}
			this.img_HeroState.gameObject.SetActive(true);
			switch (this.mHeroState)
			{
			case eHeroState.IsFighting:
				this.img_HeroState.sprite = this.SArray.m_Sprites[32];
				this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(901u);
				break;
			case eHeroState.Captured:
				this.img_HeroState.sprite = this.SArray.m_Sprites[33];
				this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(902u);
				break;
			case eHeroState.Dead:
				this.img_HeroState.sprite = this.SArray.m_Sprites[34];
				this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(903u);
				break;
			}
		}
		this.text_HeroName.text = this.DM.mStringTable.GetStringByID((uint)this.sHero.HeroName);
		this.text_HeroTitle.text = this.DM.mStringTable.GetStringByID((uint)this.sHero.HeroTitle);
		this.text_Lv.text = this.mHeroData.Level.ToString();
		if (this.sHero.HeroType == 1)
		{
			this.btn_Property.image.sprite = this.SArray.m_Sprites[24];
		}
		else if (this.sHero.HeroType == 2)
		{
			this.btn_Property.image.sprite = this.SArray.m_Sprites[23];
		}
		else
		{
			this.btn_Property.image.sprite = this.SArray.m_Sprites[22];
		}
		this.SetHeroEXP(this.mHeroData.Exp);
		this.mHeroStratum = (int)this.mHeroData.Enhance;
		this.Cstr_Rank.ClearString();
		this.Cstr_Rank.Append(this.DM.mStringTable.GetStringByID(15u));
		this.Cstr_Rank.IntToFormat((long)this.mHeroStratum, 1, false);
		this.Cstr_Rank.AppendFormat("{0}");
		this.text_Hint[0].text = this.Cstr_Rank.ToString();
		this.text_Hint[0].SetAllDirty();
		this.text_Hint[0].cachedTextGenerator.Invalidate();
		this.text_Hint[1].text = this.DM.mStringTable.GetStringByID((uint)((ushort)((int)this.sHero.HeroType + 377)));
		if (this.OpenPage == 0)
		{
			RectTransform component = this.Property_Hint.transform.GetComponent<RectTransform>();
			RectTransform component2 = this.text_Hint[1].transform.GetComponent<RectTransform>();
			float num2 = Mathf.Clamp(this.text_Hint[1].preferredWidth, 0f, component2.sizeDelta.x);
			component.sizeDelta = new Vector2(num2 + 20f, component.sizeDelta.y);
			component = this.text_Hint[1].transform.GetComponent<RectTransform>();
			component.sizeDelta = new Vector2(num2 + 20f, component.sizeDelta.y);
			component = this.Fragment_Hint.transform.GetComponent<RectTransform>();
			component2 = this.text_Hint[0].transform.GetComponent<RectTransform>();
			num2 = Mathf.Clamp(this.text_Hint[0].preferredWidth, 0f, component2.sizeDelta.x);
			component.sizeDelta = new Vector2(num2 + 20f, component.sizeDelta.y);
			component = this.text_Hint[0].transform.GetComponent<RectTransform>();
			component.sizeDelta = new Vector2(num2 + 20f, component.sizeDelta.y);
		}
		this.Cstr_NextRS.ClearString();
		if ((int)this.mHeroData.Enhance < this.TopRank)
		{
			this.Cstr_NextRS.IntToFormat((long)this.DM.RankSoldiers[(int)(this.mHeroData.Enhance + 1)], 1, false);
			this.Cstr_NextRS.AppendFormat(this.DM.mStringTable.GetStringByID(581u));
			this.text_Next_RankSoldier.text = this.Cstr_NextRS.ToString();
		}
		if (Load3d)
		{
			this.bEquip = false;
			this.bSkill = false;
			this.bInfo = false;
			this.SetPage(this.mNowpage);
			this.Hero3D_Destroy();
			this.LoadHero3D();
		}
		if (this.GUIM.m_IsOpenedUISynthesis && this.mOpenType != 1)
		{
			this.GUIM.OpenUISynthesis((int)this.sHero.SoulStone);
			this.GUIM.m_IsOpenedUISynthesis = false;
		}
	}

	// Token: 0x06001CA7 RID: 7335 RVA: 0x0032ECB0 File Offset: 0x0032CEB0
	public void SetBtnState(int index)
	{
		ushort num = 0;
		this.img_EquipHave[index].gameObject.SetActive(false);
		this.text_Equip[index].gameObject.SetActive(false);
		this.img_EquipHave_Light[index].gameObject.SetActive(false);
		if (this.mEnhance.EnhanceNumber != null)
		{
			num = this.mEnhance.EnhanceNumber[(this.mHeroStratum - 1) * 6 + index];
		}
		this.mEquip = this.DM.EquipTable.GetRecordByKey(num);
		this.GUIM.ChangeHeroItemImg(this.btn_Equip[index].transform, eHeroOrItem.Item, num, 0, 0, 0);
		this.mHeroEquip = (int)this.mHeroData.Equip;
		int num2 = this.mHeroData.Equip >> index & 1;
		if (num2 == 1)
		{
			this.btn_Equip[index].HIImage.color = this.Color_White;
		}
		else
		{
			this.btn_Equip[index].HIImage.color = this.Color_Equip;
			this.btn_Equip[index].CircleImage.sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Item, 1);
			if (this.DM.GetCurItemQuantity(num, 0) < 1)
			{
				this.text_Equip[index].gameObject.SetActive(true);
				if (this.DM.FindItemComposite(num, 1))
				{
					if (this.mEquip.NeedLv > this.mHeroData.Level)
					{
						this.text_Equip[index].gameObject.SetActive(true);
						this.img_EquipHave[index].gameObject.SetActive(true);
						this.img_EquipHave[index].sprite = this.SArray.m_Sprites[9];
						this.text_Equip[index].text = this.DM.mStringTable.GetStringByID(12u);
						this.text_Equip[index].color = this.Text_Color;
					}
					else
					{
						this.img_EquipHave[index].gameObject.SetActive(true);
						this.img_EquipHave[index].sprite = this.SArray.m_Sprites[8];
						this.text_Equip[index].text = this.DM.mStringTable.GetStringByID(13u);
						this.text_Equip[index].color = this.Color_Green;
						this.img_EquipHave_Light[index].gameObject.SetActive(true);
					}
				}
				else
				{
					this.text_Equip[index].text = this.DM.mStringTable.GetStringByID(14u);
					this.text_Equip[index].color = this.Text_Color;
				}
			}
			else if (this.mEquip.NeedLv > this.mHeroData.Level)
			{
				this.text_Equip[index].gameObject.SetActive(true);
				this.img_EquipHave[index].gameObject.SetActive(true);
				this.img_EquipHave[index].sprite = this.SArray.m_Sprites[9];
				this.text_Equip[index].text = this.DM.mStringTable.GetStringByID(12u);
				this.text_Equip[index].color = this.Text_Color;
			}
			else
			{
				this.text_Equip[index].gameObject.SetActive(true);
				this.img_EquipHave[index].gameObject.SetActive(true);
				this.img_EquipHave[index].sprite = this.SArray.m_Sprites[8];
				this.text_Equip[index].text = this.DM.mStringTable.GetStringByID(13u);
				this.text_Equip[index].color = this.Color_Green;
				this.img_EquipHave_Light[index].gameObject.SetActive(true);
			}
		}
		if (!this.bEnchantments)
		{
		}
	}

	// Token: 0x06001CA8 RID: 7336 RVA: 0x0032F074 File Offset: 0x0032D274
	public void ReSetBtnState()
	{
		this.bEnchantments = false;
		this.EvolutionRT.gameObject.SetActive(false);
		if (this.mHeroStratum < 13)
		{
			for (int i = 0; i < 6; i++)
			{
				this.SetBtnState(i);
				if (!this.bShowEquipLight && this.img_EquipHave_Light[i].IsActive())
				{
					this.bShowEquipLight = true;
				}
			}
		}
		if (this.mOpenType != 1)
		{
			if (this.mHeroEquip < 63)
			{
				this.RankLightBG.gameObject.SetActive(false);
				this.Img_EvolutionUp.gameObject.SetActive(false);
				this.uToolRankPos.enabled = false;
				this.uToolRank.enabled = false;
			}
			else
			{
				if (!this.DM.queueBarData[11].bActive)
				{
					this.RankLightBG.gameObject.SetActive(true);
				}
				if (this.mHeroStratum == this.TopRank)
				{
					this.Img_EvolutionUp.gameObject.SetActive(false);
					this.uToolRankPos.enabled = false;
					this.uToolRank.enabled = false;
				}
				else
				{
					this.Img_EvolutionUp.gameObject.SetActive(true);
					this.uToolRankPos.enabled = true;
					this.uToolRank.enabled = true;
					if (!this.DM.queueBarData[11].bActive || this.mHeroId != this.DM.RoleAttr.EnhanceEventHeroID)
					{
						this.EvolutionRT.gameObject.SetActive(true);
					}
				}
			}
		}
		else
		{
			this.RankLightBG.gameObject.SetActive(false);
			this.Img_EvolutionUp.gameObject.SetActive(false);
			this.uToolRankPos.enabled = false;
			this.uToolRank.enabled = false;
		}
	}

	// Token: 0x06001CA9 RID: 7337 RVA: 0x0032F258 File Offset: 0x0032D458
	public void SetStratum(int mStratum)
	{
		if (this.mHeroStratum != mStratum)
		{
			this.mHeroStratum = mStratum;
		}
		if (this.mHeroStratum == this.TopRank)
		{
			this.btn_EquipStratum.gameObject.SetActive(false);
			this.uToolRankPos.gameObject.SetActive(false);
		}
		else if (!this.btn_EquipStratum.IsActive())
		{
			this.btn_EquipStratum.gameObject.SetActive(true);
			this.uToolRankPos.gameObject.SetActive(true);
		}
		this.btn_Evolution.image.sprite = this.SArray.m_Sprites[9 + this.mHeroStratum];
		this.btn_EquipStratum.image.sprite = this.SArray.m_Sprites[10 + this.mHeroStratum];
		this.Cstr_Rank.ClearString();
		this.Cstr_Rank.Append(this.DM.mStringTable.GetStringByID(15u));
		this.Cstr_Rank.IntToFormat((long)this.mHeroStratum, 1, false);
		this.Cstr_Rank.AppendFormat("{0}");
		this.text_Rank.text = this.Cstr_Rank.ToString();
		this.text_Rank.SetAllDirty();
		this.text_Rank.cachedTextGenerator.Invalidate();
		this.text_Hint[0].text = this.Cstr_Rank.ToString();
		this.text_Hint[0].SetAllDirty();
		this.text_Hint[0].cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001CAA RID: 7338 RVA: 0x0032F3E4 File Offset: 0x0032D5E4
	public void SetStarStratum(int mValue, int StarLv = 0)
	{
		this.bStarEvolution = ((float)mValue >= this.MaxStar);
		this.StarEvolutionRT.gameObject.SetActive(false);
		if (StarLv == 5)
		{
			this.text_HeroStarLv.text = this.DM.mStringTable.GetStringByID(21u);
			this.btn_StarEvolution.interactable = false;
			this.uToolStar.enabled = true;
			this.StarStratumLightBG.gameObject.SetActive(true);
		}
		else
		{
			this.Cstr_HeroStarLv.ClearString();
			if (this.GUIM.IsArabic)
			{
				this.Cstr_HeroStarLv.FloatToFormat(this.MaxStar, -1, true);
				this.Cstr_HeroStarLv.IntToFormat((long)mValue, 1, false);
			}
			else
			{
				this.Cstr_HeroStarLv.IntToFormat((long)mValue, 1, false);
				this.Cstr_HeroStarLv.FloatToFormat(this.MaxStar, -1, true);
			}
			this.Cstr_HeroStarLv.AppendFormat("{0} / {1}");
			this.text_HeroStarLv.text = this.Cstr_HeroStarLv.ToString();
			this.text_HeroStarLv.SetAllDirty();
			this.text_HeroStarLv.cachedTextGenerator.Invalidate();
			this.btn_StarEvolution.interactable = true;
			if (this.bStarEvolution)
			{
				this.Img_StarEvolution.gameObject.SetActive(true);
				if (!this.DM.queueBarData[12].bActive)
				{
					this.StarStratumLightBG.gameObject.SetActive(true);
					this.StarEvolutionRT.gameObject.SetActive(true);
				}
				else if (this.mHeroId != this.DM.RoleAttr.StarUpEventHeroID)
				{
					this.StarEvolutionRT.gameObject.SetActive(true);
				}
				this.uToolStar.enabled = true;
			}
			else
			{
				this.Img_StarEvolution.gameObject.SetActive(false);
				this.StarStratumLightBG.gameObject.SetActive(false);
				this.uToolStar.enabled = false;
			}
		}
		this.btn_StarEvolution.image.sprite = this.SArray.m_Sprites[24 + StarLv];
	}

	// Token: 0x06001CAB RID: 7339 RVA: 0x0032F610 File Offset: 0x0032D810
	public void SetHeroEXP(uint Exp)
	{
		uint heroExp = this.DM.LevelUpTable.GetRecordByKey((ushort)this.mHeroData.Level).HeroExp;
		RectTransform component = this.img_HeroExp.GetComponent<RectTransform>();
		float num = Exp / heroExp;
		if (num >= 1f)
		{
			num = 1f;
		}
		float new_x = this.mExpLength * num;
		this.TmpV.Set(new_x, component.sizeDelta.y);
		component.sizeDelta = this.TmpV;
		this.Cstr_HeroEXP.ClearString();
		if (this.GUIM.IsArabic)
		{
			this.Cstr_HeroEXP.IntToFormat((long)((ulong)heroExp), 1, true);
			this.Cstr_HeroEXP.IntToFormat((long)((ulong)Exp), 1, true);
		}
		else
		{
			this.Cstr_HeroEXP.IntToFormat((long)((ulong)Exp), 1, true);
			this.Cstr_HeroEXP.IntToFormat((long)((ulong)heroExp), 1, true);
		}
		this.Cstr_HeroEXP.AppendFormat("{0} / {1} ");
		this.Cstr_HeroEXP.Append(this.DM.mStringTable.GetStringByID(9u));
		this.text_HeroEXP.text = this.Cstr_HeroEXP.ToString();
		this.text_HeroEXP.SetAllDirty();
		this.text_HeroEXP.cachedTextGenerator.Invalidate();
		this.UpdatePower();
		this.text_Lv.text = this.mHeroData.Level.ToString();
	}

	// Token: 0x06001CAC RID: 7340 RVA: 0x0032F778 File Offset: 0x0032D978
	public void UpdatePower()
	{
		this.mHeroId = this.mHeroData.ID;
		this.mCalcAttrData.SkillLV1 = this.mHeroData.SkillLV[0];
		this.mCalcAttrData.SkillLV2 = this.mHeroData.SkillLV[1];
		this.mCalcAttrData.SkillLV3 = this.mHeroData.SkillLV[2];
		this.mCalcAttrData.SkillLV4 = this.mHeroData.SkillLV[3];
		for (int i = 0; i < 4; i++)
		{
			this.SkillLv[i] = this.mHeroData.SkillLV[i];
		}
		this.mCalcAttrData.LV = this.mHeroData.Level;
		this.mCalcAttrData.Star = this.mHeroData.Star;
		this.mCalcAttrData.Enhance = this.mHeroData.Enhance;
		this.mCalcAttrData.Equip = this.mHeroData.Equip;
		this.EquipEffect_HP = 0u;
		Array.Clear(this.EquipEffect_pAttr, 0, this.EquipEffect_pAttr.Length);
		this.mBs.setCalculateHeroEquipEffect(this.mHeroId, this.mHeroData.Enhance, this.mHeroData.Equip, ref this.EquipEffect_HP, this.EquipEffect_pAttr);
		this.HP = 0u;
		Array.Clear(this.pAttr, 0, this.pAttr.Length);
		this.mBs.setCalculateAttribute(this.mHeroId, ref this.mCalcAttrData, ref this.HP, this.pAttr);
		this.Power = this.mBs.updateFightScore(this.mHeroId, this.HP, this.pAttr, this.SkillLv);
		this.Cstr_HeroPower.ClearString();
		this.Cstr_HeroPower.Append(this.DM.mStringTable.GetStringByID(11u));
		this.Cstr_HeroPower.IntToFormat((long)((ulong)this.Power), 1, true);
		this.Cstr_HeroPower.AppendFormat(" : {0}");
		this.text_HeroPower.text = this.Cstr_HeroPower.ToString();
		this.text_HeroPower.SetAllDirty();
		this.text_HeroPower.cachedTextGenerator.Invalidate();
		this.bInfo = false;
	}

	// Token: 0x06001CAD RID: 7341 RVA: 0x0032F9B0 File Offset: 0x0032DBB0
	public void SetSkilldata(byte idx)
	{
		if (this.sHero.AttackPower != null)
		{
			this.mSkill = this.DM.SkillTable.GetRecordByKey(this.sHero.AttackPower[(int)(idx + 1)]);
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.IntToFormat((long)this.mSkill.SkillIcon, 5, false);
		cstring.AppendFormat("s{0}");
		this.img_Skill[(int)idx].sprite = this.GUIM.LoadSkillSprite(cstring);
		if (idx == 0)
		{
			this.text_Skill_Name.text = this.DM.mStringTable.GetStringByID((uint)this.mSkill.SkillName);
		}
		this.mSkill = this.DM.SkillTable.GetRecordByKey(this.sHero.GroupSkill1 + (ushort)idx);
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring2.ClearString();
		cstring2.IntToFormat((long)this.mSkill.SkillIcon, 5, false);
		cstring2.AppendFormat("s{0}");
		this.img_Skill[(int)(idx + 4)].sprite = this.GUIM.LoadSkillSprite(cstring2);
		if (this.SkillLv[(int)idx] == 0)
		{
			this.img_Skill[(int)idx].color = this.Color_Gray;
			this.img_Skill[(int)(4 + idx)].color = this.Color_Gray;
			this.img_SkillFrame[(int)idx].color = this.Color_Gray;
			this.img_SkillFrame[(int)(4 + idx)].color = this.Color_Gray;
			this.img_Lock[(int)(idx - 1)].gameObject.SetActive(true);
			this.img_Lock[(int)(idx + 2)].gameObject.SetActive(true);
			this.img_SkillBook[(int)(idx - 1)].color = this.Color_Gray;
			this.img_Skill_Lv[(int)(idx - 1)].gameObject.SetActive(false);
			if (idx != 0)
			{
				this.text_Skill2_[(int)(idx * 2)].color = this.Color_Gray;
				this.text_Skill2_[(int)(idx * 2 + 1)].color = this.Color_Gray;
			}
		}
		else
		{
			this.img_Skill[(int)idx].color = this.Color_White;
			this.img_Skill[(int)(4 + idx)].color = this.Color_White;
			this.img_SkillFrame[(int)idx].color = this.Color_White;
			this.img_SkillFrame[(int)(4 + idx)].color = this.Color_White;
			if (idx != 0)
			{
				this.text_Skill2_[(int)(idx * 2)].color = this.Color_White;
				this.text_Skill2_[(int)(idx * 2 + 1)].color = this.Color_White;
			}
			if (idx > 0)
			{
				this.img_Lock[(int)(idx - 1)].gameObject.SetActive(false);
				this.img_Lock[(int)(idx + 2)].gameObject.SetActive(false);
				this.img_SkillBook[(int)(idx - 1)].color = this.Color_White;
				this.img_Skill_Lv[(int)(idx - 1)].gameObject.SetActive(true);
			}
			this.Cstr_Skill_Lv[(int)idx].ClearString();
			this.Cstr_Skill_Lv[(int)idx].IntToFormat((long)this.SkillLv[(int)idx], 1, false);
			this.Cstr_Skill_Lv[(int)idx].AppendFormat(this.DM.mStringTable.GetStringByID(52u));
			this.text_Skill_Lv[(int)idx].text = this.Cstr_Skill_Lv[(int)idx].ToString();
			this.text_Skill_Lv[(int)idx].SetAllDirty();
			this.text_Skill_Lv[(int)idx].cachedTextGenerator.Invalidate();
			this.text_Skill_Lv[(int)idx].color = this.Color_White;
		}
	}

	// Token: 0x06001CAE RID: 7342 RVA: 0x0032FD30 File Offset: 0x0032DF30
	public void ReSetSkill()
	{
		for (int i = 0; i < 4; i++)
		{
			this.SkillLv[i] = this.mHeroData.SkillLV[i];
			this.SetSkilldata((byte)i);
			this.Cstr_Skill_Info[i].ClearString();
			this.key[0] = this.sHero.GroupSkill1;
			this.key[1] = this.sHero.GroupSkill2;
			this.key[2] = this.sHero.GroupSkill3;
			this.key[3] = this.sHero.GroupSkill4;
			this.mSkill = this.DM.SkillTable.GetRecordByKey(this.key[i]);
			float num = (float)this.mSkill.HurtValue + (float)((ushort)this.LegionRankMagnifation[(int)(this.mHeroData.Star - 1)] * this.mSkill.HurtIncreaseValue) / 1000f;
			if (this.mSkill.SkillType == 10)
			{
				GameConstants.GetEffectValue(this.Cstr_Skill_Info[i], this.mSkill.HurtAddition, (uint)num, 1, 0f);
			}
			else if (this.mSkill.HurtKind == 1)
			{
				GameConstants.GetEffectValue(this.Cstr_Skill_Info[i], this.mSkill.HurtAddition, (uint)(this.mSkill.HurtValue + this.mSkill.HurtIncreaseValue * (ushort)this.LegionRankMagnifation[(int)(this.mHeroData.Star - 1)]), 9, 0f);
			}
			else
			{
				GameConstants.GetEffectValue(this.Cstr_Skill_Info[i], this.mSkill.HurtAddition, 0u, 6, num * 100f);
			}
		}
		this.mSkill = this.DM.SkillTable.GetRecordByKey(this.sHero.GroupSkill1);
		this.text_Skill2_[0].text = this.DM.mStringTable.GetStringByID((uint)this.mSkill.SkillName);
		this.text_Skill2_[1].text = this.Cstr_Skill_Info[0].ToString();
		this.text_Skill2_[1].SetAllDirty();
		this.text_Skill2_[1].cachedTextGenerator.Invalidate();
		this.mSkill = this.DM.SkillTable.GetRecordByKey(this.sHero.GroupSkill2);
		this.text_Skill2_[2].text = this.DM.mStringTable.GetStringByID((uint)this.mSkill.SkillName);
		this.text_Skill2_[3].text = this.Cstr_Skill_Info[1].ToString();
		this.text_Skill2_[3].SetAllDirty();
		this.text_Skill2_[3].cachedTextGenerator.Invalidate();
		this.mSkill = this.DM.SkillTable.GetRecordByKey(this.sHero.GroupSkill3);
		this.text_Skill2_[4].text = this.DM.mStringTable.GetStringByID((uint)this.mSkill.SkillName);
		this.text_Skill2_[5].text = this.Cstr_Skill_Info[2].ToString();
		this.text_Skill2_[5].SetAllDirty();
		this.text_Skill2_[5].cachedTextGenerator.Invalidate();
		this.mSkill = this.DM.SkillTable.GetRecordByKey(this.sHero.GroupSkill4);
		this.text_Skill2_[6].text = this.DM.mStringTable.GetStringByID((uint)this.mSkill.SkillName);
		this.text_Skill2_[7].text = this.Cstr_Skill_Info[3].ToString();
		this.text_Skill2_[7].SetAllDirty();
		this.text_Skill2_[7].cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001CAF RID: 7343 RVA: 0x003300E0 File Offset: 0x0032E2E0
	public void SetPage3InfoData()
	{
		this.m_Mask.StopMovement();
		this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, 0f);
		this.text_HeroInfo.text = this.DM.mStringTable.GetStringByID((uint)this.sHero.Description);
		if (this.text_HeroInfo.preferredHeight > 190f)
		{
			this.TmpV.Set(this.ContentRT.sizeDelta.x, this.text_HeroInfo.preferredHeight);
			this.ContentRT.sizeDelta = this.TmpV;
		}
		for (int i = 0; i < 3; i++)
		{
			this.Cstr_Property[i].ClearString();
			StringManager.IntToStr(this.Cstr_Property[i], (long)this.pAttr[i], 1, true);
			this.text_Property[i * 2].text = this.Cstr_Property[i].ToString();
			this.text_Property[i * 2].SetAllDirty();
			this.text_Property[i * 2].cachedTextGenerator.Invalidate();
		}
		this.text_Property[1].text = ((float)this.sHero.StarUp.Strength / 100f * this.StarValue[(int)this.mHeroData.Star]).ToString();
		this.text_Property[3].text = ((float)this.sHero.StarUp.Dexterity / 100f * this.StarValue[(int)this.mHeroData.Star]).ToString();
		this.text_Property[5].text = ((float)this.sHero.StarUp.Intelligence / 100f * this.StarValue[(int)this.mHeroData.Star]).ToString();
		this.tmplist.Clear();
		int num = 1;
		for (int j = 3; j < 20; j++)
		{
			if (this.pAttr[j] != 0)
			{
				this.pAttrIdx[num] = (ushort)j;
				this.EquipEffect_pAttrIdx[num] = (ushort)j;
				num++;
			}
		}
		for (int k = 23; k < 28; k++)
		{
			if (this.pAttr[k] != 0)
			{
				this.pAttrIdx[num] = (ushort)k;
				this.EquipEffect_pAttrIdx[num] = (ushort)k;
				num++;
			}
		}
		for (int l = 0; l < num; l++)
		{
			this.tmplist.Add(45f);
		}
		this.m_itemView.AddNewDataHeight(this.tmplist, true, true);
	}

	// Token: 0x06001CB0 RID: 7344 RVA: 0x00330388 File Offset: 0x0032E588
	public void Hero3D_Destroy()
	{
		if (this.go2 != null)
		{
			this.go2.transform.SetParent(this.Hero_Pos.parent, false);
			UnityEngine.Object.Destroy(this.go2);
		}
		if (this.Hero_Model != null)
		{
			UnityEngine.Object.Destroy(this.Hero_Model);
		}
		this.Hero_Model = null;
		this.go2 = null;
		AssetManager.UnloadAssetBundle(this.AssetKey, false);
	}

	// Token: 0x06001CB1 RID: 7345 RVA: 0x00330404 File Offset: 0x0032E604
	public void LoadHero3D()
	{
		this.ActionTime = 0f;
		this.ActionTimeRandom = 2f;
		this.btn_HeroActionD.ReSetHero();
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.IntToFormat((long)this.sHero.Modle, 5, false);
		cstring.AppendFormat("Role/hero_{0}");
		if (this.sHero.Modle > 0 && AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, this.sHero.Modle, false))
		{
			this.AB = AssetManager.GetAssetBundle(cstring, out this.AssetKey);
			if (this.AB != null)
			{
				this.AR = this.AB.LoadAsync("m", typeof(GameObject));
				this.ABIsDone = false;
			}
		}
		else
		{
			this.AR = null;
		}
	}

	// Token: 0x06001CB2 RID: 7346 RVA: 0x003304E0 File Offset: 0x0032E6E0
	public void HeroActionChang(bool bAddShowEffect = false)
	{
		if (this.ABIsDone && this.Hero_Model != null)
		{
			this.tmpAN = this.Hero_Model.GetComponent<Animation>();
			this.tmpAN.wrapMode = WrapMode.Loop;
			if (this.HeroAct == this.mHeroAct[1])
			{
				this.tmpAN.CrossFade("idle");
			}
			if (this.tmpAN.GetClip(this.mHeroAct[2]) != null)
			{
				this.HeroAct = this.mHeroAct[2];
				this.tmpAN[this.mHeroAct[2]].layer = 1;
				this.tmpAN[this.mHeroAct[2]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(this.mHeroAct[3]) != null)
			{
				this.HeroAct = this.mHeroAct[3];
				this.tmpAN[this.mHeroAct[3]].layer = 1;
				this.tmpAN[this.mHeroAct[3]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[4]) != null)
			{
				this.HeroAct = this.mHeroAct[4];
				this.tmpAN[this.mHeroAct[4]].layer = 1;
				this.tmpAN[this.mHeroAct[4]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(this.mHeroAct[5]) != null)
			{
				this.HeroAct = this.mHeroAct[5];
				this.tmpAN[this.mHeroAct[5]].layer = 1;
				this.tmpAN[this.mHeroAct[5]].wrapMode = WrapMode.Once;
			}
			if (this.tmpAN.GetClip(this.mHeroAct[6]) != null)
			{
				this.HeroAct = this.mHeroAct[6];
				this.tmpAN[this.mHeroAct[6]].layer = 1;
				this.tmpAN[this.mHeroAct[6]].wrapMode = WrapMode.Once;
			}
			int num;
			if (!bAddShowEffect)
			{
				num = UnityEngine.Random.Range(1, 7);
			}
			else
			{
				num = 6;
			}
			AnimationClip animationClip = this.tmpAN.GetClip(this.mHeroAct[(int)((byte)num)]);
			this.HeroAct = this.mHeroAct[(int)((byte)num)];
			if (num == 3)
			{
				AnimationClip clip = this.tmpAN.GetClip(this.HeroAct + "_ch");
				if (clip != null)
				{
					animationClip = null;
				}
			}
			if (animationClip != null)
			{
				this.tmpAN.CrossFade(animationClip.name);
				this.MovingTimer = 0f;
				if (num == 1)
				{
					this.MovingTimer = 2f;
				}
			}
			this.ActionTimeRandom = 0f;
			this.ActionTime = 0f;
		}
	}

	// Token: 0x06001CB3 RID: 7347 RVA: 0x003307E0 File Offset: 0x0032E9E0
	public void OpenRankEquip(bool bOpen)
	{
		if (bOpen)
		{
			ushort hiid = 0;
			for (int i = 0; i < 6; i++)
			{
				if (this.mEnhance.EnhanceNumber != null && this.mHeroStratum * 6 + i < this.mEnhance.EnhanceNumber.Length)
				{
					hiid = this.mEnhance.EnhanceNumber[this.mHeroStratum * 6 + i];
				}
				this.GUIM.ChangeHeroItemImg(this.btn_RankEquip[i].transform, eHeroOrItem.Item, hiid, 0, 0, 0);
			}
			this.imgRank_Rank.sprite = this.SArray.m_Sprites[10 + this.mHeroStratum];
			this.Cstr_NextRank.ClearString();
			this.Cstr_NextRank.Append(this.DM.mStringTable.GetStringByID(15u));
			this.Cstr_NextRank.IntToFormat((long)(this.mHeroStratum + 1), 1, false);
			this.Cstr_NextRank.AppendFormat("{0}");
			this.text_NextRank.text = this.Cstr_NextRank.ToString();
			this.text_NextRank.SetAllDirty();
			this.text_NextRank.cachedTextGenerator.Invalidate();
			this.btn_Rank_Exit.transform.SetParent(this.GUIM.m_SecWindowLayer, false);
			this.btn_Rank_Exit.gameObject.SetActive(true);
		}
		else
		{
			this.btn_Rank_Exit.transform.SetParent(this.GameT, false);
			this.btn_Rank_Exit.transform.SetSiblingIndex(12);
			this.btn_Rank_Exit.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001CB4 RID: 7348 RVA: 0x00330974 File Offset: 0x0032EB74
	public override void OnClose()
	{
		if (this.timeBarRank)
		{
			this.GUIM.RemoverTimeBaarToList(this.timeBarRank);
		}
		if (this.timeBarStar)
		{
			this.GUIM.RemoverTimeBaarToList(this.timeBarStar);
		}
		this.tmplist = null;
		this.GUIM.UIPreviewHero_Index = -1;
		this.GUIM.UIHero_Index = -1;
		if (this.mHeroDataIndex != -1)
		{
			if (this.mOpenType != 1)
			{
				if (this.GUIM.m_WindowStack.Count > 0 && this.GUIM.m_WindowStack[this.GUIM.m_WindowStack.Count - 1].m_eWindow == EGUIWindow.UI_Hero_Info)
				{
					GUIWindowStackData value = this.GUIM.m_WindowStack[this.GUIM.m_WindowStack.Count - 1];
					value.m_Arg1 = this.mHeroDataIndex;
					this.GUIM.m_WindowStack[this.GUIM.m_WindowStack.Count - 1] = value;
				}
			}
			else
			{
				this.GUIM.UIPreviewHero_Index = this.mHeroDataIndex;
			}
			this.GUIM.UIHero_Index = (int)this.mHeroId;
		}
		this.Hero3D_Destroy();
		if (this.Cstr_RankTimeBar != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_RankTimeBar);
		}
		if (this.Cstr_Rank != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Rank);
		}
		if (this.Cstr_NextRank != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_NextRank);
		}
		if (this.Cstr_HeroStarLv != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_HeroStarLv);
		}
		if (this.Cstr_HeroEXP != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_HeroEXP);
		}
		if (this.Cstr_HeroPower != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_HeroPower);
		}
		if (this.Cstr_Leader != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Leader);
		}
		for (int i = 0; i < 4; i++)
		{
			if (this.Cstr_Skill_Lv[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Skill_Lv[i]);
			}
			if (this.Cstr_Skill_Cost[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Skill_Cost[i]);
			}
			if (this.Cstr_Skill_Info[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Skill_Info[i]);
			}
		}
		for (int j = 0; j < 6; j++)
		{
			if (this.Cstr_ShowEffect[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ShowEffect[j]);
			}
		}
		for (int k = 0; k < 3; k++)
		{
			if (this.Cstr_Property[k] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Property[k]);
			}
		}
		for (int l = 0; l < 10; l++)
		{
			if (this.Cstr_ItemPropertyValue[l] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemPropertyValue[l]);
			}
		}
		if (this.Cstr_Hint != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Hint);
		}
		if (this.Cstr_NextRS != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_NextRS);
		}
		if (this.mParticleRank != null)
		{
			ParticleManager.Instance.DeSpawn(this.mParticleRank);
			this.mParticleRank = null;
		}
		if (this.mParticleStar != null)
		{
			ParticleManager.Instance.DeSpawn(this.mParticleStar);
			this.mParticleStar = null;
		}
		if (this.mParticleEffectpAttr != null && this.mParticleEffectpAttr.activeSelf && ParticleManager.Instance.AllEffectObject != null)
		{
			this.mParticleEffectpAttr.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
		}
	}

	// Token: 0x06001CB5 RID: 7349 RVA: 0x00330D78 File Offset: 0x0032EF78
	public void SetSkillPage(bool bHeroSkill)
	{
		if (!bHeroSkill)
		{
			if (this.mOpenType != 1)
			{
				this.DM.Hero_Info_bHeroSkill = false;
			}
			this.mSkillpage = 0;
			this.SkillPageTime = 0f;
			this.btn_SkillPage[0].image.sprite = this.SArray.m_Sprites[30];
			this.btn_SkillPage[1].image.sprite = this.SArray.m_Sprites[31];
			this.img_SkillPage[0].color = new Color(1f, 1f, 1f, 0f);
			this.img_SkillPage[1].color = new Color(1f, 1f, 1f, 0f);
			this.SkillPageT[0].gameObject.SetActive(true);
			this.SkillPageT[1].gameObject.SetActive(false);
			this.text_SkillPage[0].color = this.Color_Target;
			this.text_SkillPage[1].color = this.Color_NoTarget;
		}
		else
		{
			if (this.mOpenType != 1)
			{
				this.DM.Hero_Info_bHeroSkill = true;
			}
			this.mSkillpage = 1;
			this.SkillPageTime = 0f;
			this.btn_SkillPage[0].image.sprite = this.SArray.m_Sprites[31];
			this.btn_SkillPage[1].image.sprite = this.SArray.m_Sprites[30];
			this.img_SkillPage[0].color = new Color(1f, 1f, 1f, 0f);
			this.img_SkillPage[1].color = new Color(1f, 1f, 1f, 0f);
			this.SkillPageT[0].gameObject.SetActive(false);
			this.SkillPageT[1].gameObject.SetActive(true);
			this.text_SkillPage[0].color = this.Color_NoTarget;
			this.text_SkillPage[1].color = this.Color_Target;
		}
	}

	// Token: 0x06001CB6 RID: 7350 RVA: 0x00330F94 File Offset: 0x0032F194
	public void OnButtonClick(UIButton sender)
	{
		Btn_Count btnID = (Btn_Count)sender.m_BtnID1;
		switch (btnID)
		{
		case Btn_Count.btn_EXIT:
			this.mHeroDataIndex = -1;
			this.OpenUISynthesis = false;
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case Btn_Count.btn_Page1:
		case Btn_Count.btn_Page2:
		case Btn_Count.btn_Page3:
			this.SetPage(sender.m_BtnID1 - 2);
			break;
		case Btn_Count.btn_Evolution:
			if (this.mOpenType == 1)
			{
				return;
			}
			if (this.mHeroStratum == this.TopRank)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(16u), 255, true);
				return;
			}
			if (this.mHeroEquip < 63)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(18u), 255, true);
				return;
			}
			if (this.DM.queueBarData[11].bActive)
			{
				if (this.mHeroData.ID == this.DM.RoleAttr.EnhanceEventHeroID)
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(659u), 255, true);
				}
				else
				{
					this.GUIM.OpenOKCancelBox(this, null, this.DM.mStringTable.GetStringByID(490u), 3, 0, null, null);
				}
			}
			else
			{
				if (this.DM.GetLeaderID() == this.mHeroData.ID && (this.mHeroState == eHeroState.Dead || this.mHeroState == eHeroState.Captured))
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(890u), 255, true);
					return;
				}
				uint num = (uint)(this.DM.Hero_RankCost[this.mHeroStratum] * 60);
				float num2 = 0f;
				float num3 = num / 3600u;
				num2 += num3 * 3600f;
				float num4 = (num - num2) / 60f;
				num2 += num4 * 60f;
				float num5 = num - num2;
				float num6 = 0f;
				if (num3 >= 24f)
				{
					num6 = num3 / 24f;
					num3 -= (float)((int)num6 * 24);
				}
				this.needDiamond = this.DM.GetResourceExchange(PriceListType.Time, num);
				this.GUIM.OpenSpendWindow_ItemID2(this, this.DM.mStringTable.GetStringByID(20u), 1077, 1078, this.needDiamond, (ushort)((byte)num6), (byte)num3, (byte)num4, (byte)num5, false, 1, 0, this.DM.mStringTable.GetStringByID(2910u), this.DM.mStringTable.GetStringByID(2910u), this.DM.mStringTable.GetStringByID(2911u));
				NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, this, false);
			}
			break;
		default:
			switch (btnID)
			{
			case Btn_Count.btn_Rank_Exit:
				this.OpenRankEquip(false);
				break;
			case Btn_Count.btn_P3Info:
				this.SetPage3Info(!this.bHeroInfo);
				break;
			case Btn_Count.btn_SkillPage1:
				this.SetSkillPage(false);
				break;
			case Btn_Count.btn_SkillPage2:
				this.SetSkillPage(true);
				break;
			}
			break;
		case Btn_Count.btn_EquipStratum:
			if (this.mHeroStratum == this.TopRank)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(16u), 255, true);
			}
			else
			{
				this.OpenRankEquip(true);
			}
			break;
		case Btn_Count.btn_StarEvolution:
			if (this.mOpenType == 1)
			{
				return;
			}
			if ((float)this.DM.GetCurItemQuantity(this.sHero.SoulStone, 0) < this.MaxStar)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(24u), 255, true);
			}
			else
			{
				if (this.DM.queueBarData[12].bActive)
				{
					if (this.mHeroData.ID == this.DM.RoleAttr.StarUpEventHeroID)
					{
						this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(660u), 255, true);
					}
					else
					{
						this.GUIM.OpenOKCancelBox(this, null, this.DM.mStringTable.GetStringByID(491u), 4, 0, null, null);
					}
					return;
				}
				if (this.DM.GetLeaderID() == this.mHeroData.ID && (this.mHeroState == eHeroState.Dead || this.mHeroState == eHeroState.Captured))
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(891u), 255, true);
					return;
				}
				byte star = this.mHeroData.Star;
				uint num7 = (uint)(this.DM.Hero_StarCost[(int)this.mHeroData.Star] * 60);
				float num8 = 0f;
				float num9 = num7 / 3600u;
				num8 += num9 * 3600f;
				float num10 = (num7 - num8) / 60f;
				num8 += num10 * 60f;
				float num11 = num7 - num8;
				float num12 = 0f;
				if (num9 >= 24f)
				{
					num12 = num9 / 24f;
					num9 -= (float)((int)num12 * 24);
				}
				this.needDiamond = this.DM.GetResourceExchange(PriceListType.Time, num7);
				this.GUIM.OpenSpendWindow_ItemID2(this, this.DM.mStringTable.GetStringByID(25u), 1079, 1080, this.needDiamond, (ushort)((byte)num12), (byte)num9, (byte)num10, (byte)num11, false, 5, 0, this.DM.mStringTable.GetStringByID(2912u), this.DM.mStringTable.GetStringByID(2912u), this.DM.mStringTable.GetStringByID(2913u));
			}
			break;
		case Btn_Count.btn_DETAIL:
			if (this.mOpenType == 1)
			{
				return;
			}
			this.GUIM.OpenUISynthesis((int)this.sHero.SoulStone);
			break;
		case Btn_Count.NextBtn:
			if (this.mOpenType == 1 && this.mOpenKind == 0)
			{
				return;
			}
			if ((long)this.mHeroDataIndex < (long)((ulong)(this.DM.CurHeroDataCount - 1u)))
			{
				this.mHeroDataIndex++;
				this.mHeroDataIndex = this.CheckHeroIndex(false, this.mHeroDataIndex);
			}
			else
			{
				this.mHeroDataIndex = 0;
			}
			this.SetHeroData(this.mHeroDataIndex, true, false);
			break;
		case Btn_Count.BackBtn:
			if (this.mOpenType == 1 && this.mOpenKind == 0)
			{
				return;
			}
			if (this.mHeroDataIndex == 0)
			{
				this.mHeroDataIndex = (int)(this.DM.CurHeroDataCount - 1u);
				this.mHeroDataIndex = this.CheckHeroIndex(true, this.mHeroDataIndex);
			}
			else
			{
				this.mHeroDataIndex--;
			}
			this.SetHeroData(this.mHeroDataIndex, true, false);
			break;
		case Btn_Count.btn_HeroAction:
			if ((this.tmpAN != null && !this.tmpAN.IsPlaying(this.HeroAct)) || this.HeroAct == "idle")
			{
				this.HeroActionChang(false);
			}
			break;
		}
	}

	// Token: 0x06001CB7 RID: 7351 RVA: 0x00331718 File Offset: 0x0032F918
	public int CheckHeroIndex(bool bBack, int mHeroIdx)
	{
		if (mHeroIdx < 0 || (long)mHeroIdx > (long)((ulong)(this.DM.CurHeroDataCount - 1u)))
		{
			mHeroIdx = 0;
		}
		int num = mHeroIdx;
		if (this.mOpenType == 1 && this.mOpenKind == 1)
		{
			uint num2 = this.DM.sortHeroData[num];
			if (this.DM.curHeroData.ContainsKey(num2) && !this.CheckTopicHero(this.DM.curHeroData[num2].ID))
			{
				if (bBack)
				{
					num--;
					num = this.CheckHeroIndex(true, num);
				}
				else
				{
					num++;
					num = this.CheckHeroIndex(false, num);
				}
			}
		}
		return num;
	}

	// Token: 0x06001CB8 RID: 7352 RVA: 0x003317D0 File Offset: 0x0032F9D0
	public bool CheckTopicHero(ushort HeroID)
	{
		bool result = false;
		byte b = 0;
		byte b2 = 0;
		LevelEX levelEXBycurrentPointID = DataManager.StageDataController.GetLevelEXBycurrentPointID(0);
		StageConditionData recordByKey;
		if (DataManager.StageDataController.StageDareMode(DataManager.StageDataController.currentPointID) == StageMode.Lean)
		{
			recordByKey = DataManager.StageDataController.StageConditionDataTable.GetRecordByKey(levelEXBycurrentPointID.NodusOneID + (ushort)DataManager.StageDataController.currentNodus - 1);
		}
		else
		{
			recordByKey = DataManager.StageDataController.StageConditionDataTable.GetRecordByKey(levelEXBycurrentPointID.NodusTwoID);
		}
		for (int i = 0; i < recordByKey.ConditionArray.Length; i++)
		{
			if (recordByKey.ConditionArray[i].ConditionID == 1)
			{
				if ((recordByKey.ConditionArray[i].FactorA == 0 && !ArenaManager.Instance.CheckHeroAstrology(HeroID, recordByKey.ConditionArray[i].FactorB)) || (recordByKey.ConditionArray[i].FactorA == 1 && ArenaManager.Instance.CheckHeroAstrology(HeroID, recordByKey.ConditionArray[i].FactorB)))
				{
					b2 += 1;
				}
				b += 1;
			}
		}
		if (b == b2)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x06001CB9 RID: 7353 RVA: 0x00331910 File Offset: 0x0032FB10
	public void OnHIButtonClick(UIHIBtn sender)
	{
		switch (sender.m_BtnID1)
		{
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
			if (this.mOpenType == 1)
			{
				return;
			}
			if (this.mEnhance.EnhanceNumber != null)
			{
				ushort itemID = this.mEnhance.EnhanceNumber[(this.mHeroStratum - 1) * 6 + sender.m_BtnID1 - 6];
				this.GUIM.m_ItemInfo.Show(EUIItemInfo.HeroEquip, itemID, this.mHeroData.ID, (byte)(sender.m_BtnID1 - 6 + 1));
			}
			break;
		}
	}

	// Token: 0x06001CBA RID: 7354 RVA: 0x003319B4 File Offset: 0x0032FBB4
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			switch (arg1)
			{
			case 1:
			{
				if (this.DM.RoleAttr.Diamond < this.needDiamond)
				{
					this.needDiamond = 0u;
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(3966u), 255, true);
					return;
				}
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_HEROENHANCE_INSTANT;
				messagePacket.AddSeqId();
				messagePacket.Add(this.mHeroData.ID);
				messagePacket.Send(false);
				this.GUIM.ShowUILock(EUILock.Hero_Info);
				break;
			}
			case 3:
				this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 11, false);
				break;
			case 4:
				this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 12, false);
				break;
			case 5:
			{
				if (this.DM.RoleAttr.Diamond < this.needDiamond)
				{
					this.needDiamond = 0u;
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(3966u), 255, true);
					return;
				}
				MessagePacket messagePacket2 = new MessagePacket(1024);
				messagePacket2.Protocol = Protocol._MSG_REQUEST_HEROSTARUP_INSTANT;
				messagePacket2.AddSeqId();
				messagePacket2.Add(this.mHeroData.ID);
				messagePacket2.Send(false);
				this.GUIM.ShowUILock(EUILock.Hero_Info);
				break;
			}
			case 6:
				this.door.OpenMenu(EGUIWindow.UI_VIP, 0, 0, false);
				break;
			}
		}
		else if (arg1 != 1)
		{
			if (arg1 == 5)
			{
				MessagePacket messagePacket3 = new MessagePacket(1024);
				messagePacket3.Protocol = Protocol._MSG_REQUEST_HEROSTARUP;
				messagePacket3.AddSeqId();
				messagePacket3.Add(this.mHeroData.ID);
				messagePacket3.Send(false);
				this.GUIM.ShowUILock(EUILock.Hero_Info);
			}
		}
		else
		{
			MessagePacket messagePacket4 = new MessagePacket(1024);
			messagePacket4.Protocol = Protocol._MSG_REQUEST_HEROENHANCE;
			messagePacket4.AddSeqId();
			messagePacket4.Add(this.mHeroData.ID);
			messagePacket4.Send(false);
			this.GUIM.ShowUILock(EUILock.Hero_Info);
		}
	}

	// Token: 0x06001CBB RID: 7355 RVA: 0x00331C00 File Offset: 0x0032FE00
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
			if (!NewbieManager.IsTeachWorking(ETeachKind.PUTON_EQUIP))
			{
				if (this.mOpenType != 1)
				{
					this.GUIM.UIHero_Index = (int)this.mHeroData.ID;
					DataManager.SortHeroData();
				}
				else if (this.mOpenKind == 1)
				{
					DataManager.SortConditionHeroData();
					if ((uint)this.mHeroData.ID == this.DM.sortHeroData[this.mHeroDataIndex])
					{
						this.GUIM.UIPreviewHero_Index = this.mHeroDataIndex;
					}
					else
					{
						this.GUIM.UIHero_Index = (int)this.mHeroData.ID;
					}
				}
				this.SetHeroData(this.mHeroDataIndex, true, true);
				this.mHeroState = this.DM.GetHeroState(this.mHeroData.ID);
				if (this.mHeroState == eHeroState.None)
				{
					this.img_HeroState.gameObject.SetActive(false);
				}
				else
				{
					if (this.mOpenType == 1)
					{
						this.img_HeroState.rectTransform.anchoredPosition = new Vector2(this.img_HeroState.rectTransform.anchoredPosition.x, -50f);
					}
					else
					{
						this.img_HeroState.rectTransform.anchoredPosition = new Vector2(this.img_HeroState.rectTransform.anchoredPosition.x, -121f);
					}
					this.img_HeroState.gameObject.SetActive(true);
					switch (this.mHeroState)
					{
					case eHeroState.IsFighting:
						this.img_HeroState.sprite = this.SArray.m_Sprites[32];
						this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(901u);
						break;
					case eHeroState.Captured:
						this.img_HeroState.sprite = this.SArray.m_Sprites[33];
						this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(902u);
						break;
					case eHeroState.Dead:
						this.img_HeroState.sprite = this.SArray.m_Sprites[34];
						this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(903u);
						break;
					}
				}
			}
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
				if (this.timeBarRank != null && this.timeBarRank.enabled)
				{
					this.timeBarRank.Refresh_FontTexture();
				}
				if (this.timeBarStar != null && this.timeBarStar.enabled)
				{
					this.timeBarStar.Refresh_FontTexture();
				}
			}
			break;
		case NetworkNews.Refresh_Asset:
			if (meg[1] == 1 && meg[2] == 2 && GameConstants.ConvertBytesToUShort(meg, 3) == this.sHero.Modle)
			{
				this.Hero3D_Destroy();
				this.LoadHero3D();
			}
			break;
		case NetworkNews.Refresh_Hero:
			if (!NewbieManager.IsTeachWorking(ETeachKind.PUTON_EQUIP))
			{
				this.mHeroState = this.DM.GetHeroState(this.mHeroData.ID);
				if (this.mHeroState == eHeroState.None)
				{
					this.img_HeroState.gameObject.SetActive(false);
				}
				else
				{
					if (this.mOpenType == 1)
					{
						this.img_HeroState.rectTransform.anchoredPosition = new Vector2(this.img_HeroState.rectTransform.anchoredPosition.x, -50f);
					}
					else
					{
						this.img_HeroState.rectTransform.anchoredPosition = new Vector2(this.img_HeroState.rectTransform.anchoredPosition.x, -121f);
					}
					this.img_HeroState.gameObject.SetActive(true);
					switch (this.mHeroState)
					{
					case eHeroState.IsFighting:
						this.img_HeroState.sprite = this.SArray.m_Sprites[32];
						this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(901u);
						break;
					case eHeroState.Captured:
						this.img_HeroState.sprite = this.SArray.m_Sprites[33];
						this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(902u);
						break;
					case eHeroState.Dead:
						this.img_HeroState.sprite = this.SArray.m_Sprites[34];
						this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(903u);
						break;
					}
				}
			}
			break;
		}
	}

	// Token: 0x06001CBC RID: 7356 RVA: 0x003320DC File Offset: 0x003302DC
	public void Refresh_FontTexture()
	{
		if (this.text_Rank != null && this.text_Rank.enabled)
		{
			this.text_Rank.enabled = false;
			this.text_Rank.enabled = true;
		}
		if (this.text_HeroEXP != null && this.text_HeroEXP.enabled)
		{
			this.text_HeroEXP.enabled = false;
			this.text_HeroEXP.enabled = true;
		}
		if (this.text_HeroPower != null && this.text_HeroPower.enabled)
		{
			this.text_HeroPower.enabled = false;
			this.text_HeroPower.enabled = true;
		}
		if (this.text_Lv != null && this.text_Lv.enabled)
		{
			this.text_Lv.enabled = false;
			this.text_Lv.enabled = true;
		}
		if (this.text_HeroName != null && this.text_HeroName.enabled)
		{
			this.text_HeroName.enabled = false;
			this.text_HeroName.enabled = true;
		}
		if (this.text_HeroTitle != null && this.text_HeroTitle.enabled)
		{
			this.text_HeroTitle.enabled = false;
			this.text_HeroTitle.enabled = true;
		}
		if (this.text_NextRankTiTle != null && this.text_NextRankTiTle.enabled)
		{
			this.text_NextRankTiTle.enabled = false;
			this.text_NextRankTiTle.enabled = true;
		}
		if (this.text_NextRank != null && this.text_NextRank.enabled)
		{
			this.text_NextRank.enabled = false;
			this.text_NextRank.enabled = true;
		}
		if (this.text_HeroInfo != null && this.text_HeroInfo.enabled)
		{
			this.text_HeroInfo.enabled = false;
			this.text_HeroInfo.enabled = true;
		}
		if (this.text_Medal != null && this.text_Medal.enabled)
		{
			this.text_Medal.enabled = false;
			this.text_Medal.enabled = true;
		}
		if (this.text_HeroStarLv != null && this.text_HeroStarLv.enabled)
		{
			this.text_HeroStarLv.enabled = false;
			this.text_HeroStarLv.enabled = true;
		}
		if (this.text_P3Title != null && this.text_P3Title.enabled)
		{
			this.text_P3Title.enabled = false;
			this.text_P3Title.enabled = true;
		}
		if (this.text_Skill_Name != null && this.text_Skill_Name.enabled)
		{
			this.text_Skill_Name.enabled = false;
			this.text_Skill_Name.enabled = true;
		}
		if (this.text_Next_RankSoldier != null && this.text_Next_RankSoldier.enabled)
		{
			this.text_Next_RankSoldier.enabled = false;
			this.text_Next_RankSoldier.enabled = true;
		}
		if (this.text_HeroStateHint != null && this.text_HeroStateHint.enabled)
		{
			this.text_HeroStateHint.enabled = false;
			this.text_HeroStateHint.enabled = true;
		}
		if (this.text_HeroPowerHint != null && this.text_HeroPowerHint.enabled)
		{
			this.text_HeroPowerHint.enabled = false;
			this.text_HeroPowerHint.enabled = true;
		}
		if (this.text_PreviewHero != null && this.text_PreviewHero.enabled)
		{
			this.text_PreviewHero.enabled = false;
			this.text_PreviewHero.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_Leader[i] != null && this.text_Leader[i].enabled)
			{
				this.text_Leader[i].enabled = false;
				this.text_Leader[i].enabled = true;
			}
			if (this.text_SkillPage[i] != null && this.text_SkillPage[i].enabled)
			{
				this.text_SkillPage[i].enabled = false;
				this.text_SkillPage[i].enabled = true;
			}
			if (this.text_timeBarRank[i] != null && this.text_timeBarRank[i].enabled)
			{
				this.text_timeBarRank[i].enabled = false;
				this.text_timeBarRank[i].enabled = true;
			}
			if (this.text_timeBarStar[i] != null && this.text_timeBarStar[i].enabled)
			{
				this.text_timeBarStar[i].enabled = false;
				this.text_timeBarStar[i].enabled = true;
			}
		}
		for (int j = 0; j < 3; j++)
		{
			if (this.text_Skill_Lock[j] != null && this.text_Skill_Lock[j].enabled)
			{
				this.text_Skill_Lock[j].enabled = false;
				this.text_Skill_Lock[j].enabled = true;
			}
			if (this.text_Hint[j] != null && this.text_Hint[j].enabled)
			{
				this.text_Hint[j].enabled = false;
				this.text_Hint[j].enabled = true;
			}
		}
		for (int k = 0; k < 4; k++)
		{
			if (this.text_Skill_Lv[k] != null && this.text_Skill_Lv[k].enabled)
			{
				this.text_Skill_Lv[k].enabled = false;
				this.text_Skill_Lv[k].enabled = true;
			}
		}
		for (int l = 0; l < 6; l++)
		{
			if (this.text_Equip[l] != null && this.text_Equip[l].enabled)
			{
				this.text_Equip[l].enabled = false;
				this.text_Equip[l].enabled = true;
			}
			if (this.text_Property[l] != null && this.text_Property[l].enabled)
			{
				this.text_Property[l].enabled = false;
				this.text_Property[l].enabled = true;
			}
			if (this.text_ShowEffect[l] != null && this.text_ShowEffect[l].enabled)
			{
				this.text_ShowEffect[l].enabled = false;
				this.text_ShowEffect[l].enabled = true;
			}
			if (this.btn_Equip[l] != null && this.btn_Equip[l].enabled)
			{
				this.btn_Equip[l].Refresh_FontTexture();
			}
		}
		for (int m = 0; m < 8; m++)
		{
			if (this.text_Skill2_[m] != null && this.text_Skill2_[m].enabled)
			{
				this.text_Skill2_[m].enabled = false;
				this.text_Skill2_[m].enabled = true;
			}
		}
		for (int n = 0; n < 10; n++)
		{
			if (this.text_P3p2_Property[n] != null && this.text_P3p2_Property[n].enabled)
			{
				this.text_P3p2_Property[n].enabled = false;
				this.text_P3p2_Property[n].enabled = true;
			}
			if (this.text_P3p2_PropertyValue[n] != null && this.text_P3p2_PropertyValue[n].enabled)
			{
				this.text_P3p2_PropertyValue[n].enabled = false;
				this.text_P3p2_PropertyValue[n].enabled = true;
			}
			if (this.text_tmpStr[n] != null && this.text_tmpStr[n].enabled)
			{
				this.text_tmpStr[n].enabled = false;
				this.text_tmpStr[n].enabled = true;
			}
		}
	}

	// Token: 0x06001CBD RID: 7357 RVA: 0x003328F8 File Offset: 0x00330AF8
	public float SelectTween(float t, float b, float c, float d)
	{
		t /= d;
		return b + c * t;
	}

	// Token: 0x06001CBE RID: 7358 RVA: 0x00332908 File Offset: 0x00330B08
	private void Update()
	{
		if (this.OpenPage == 0)
		{
			if (this.Pagedata[this.mNowpage] == null)
			{
				this.LoadPage(this.mNowpage);
				this.Pagedata[this.mNowpage].gameObject.SetActive(true);
			}
			this.OpenPage = 1;
		}
		this.PageBGTime += Time.smoothDeltaTime;
		if (this.PageBGTime >= 0f)
		{
			if (this.PageBGTime >= 2f)
			{
				this.PageBGTime = 0f;
			}
			float a = (this.PageBGTime <= 1f) ? this.PageBGTime : (2f - this.PageBGTime);
			this.img_PageBG[this.mNowpage].color = new Color(1f, 1f, 1f, a);
		}
		if (!this.ABIsDone && this.AR != null && this.AR.isDone)
		{
			this.go2 = (GameObject)UnityEngine.Object.Instantiate(this.AR.asset);
			this.go2.transform.SetParent(this.Hero_Pos, false);
			Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
			localRotation.eulerAngles = new Vector3(0f, (float)this.sHero.Camera_Horizontal, 0f);
			this.go2.transform.localRotation = localRotation;
			this.go2.transform.localScale = new Vector3((float)this.sHero.CameraScaleRate, (float)this.sHero.CameraScaleRate, (float)this.sHero.CameraScaleRate);
			this.go2.transform.localPosition = Vector3.zero;
			this.GUIM.SetLayer(this.go2, 5);
			this.Hero_PosRT.anchoredPosition = new Vector2(this.Hero_PosRT.anchoredPosition.x, (float)(-180 - (int)(1000 - this.sHero.CameraDistance)));
			this.Tmp = this.Hero_Pos.GetChild(0);
			this.Hero_Model = this.Tmp.GetComponent<Transform>();
			if (this.Hero_Model != null)
			{
				this.tmpAN = this.Hero_Model.GetComponent<Animation>();
				this.tmpAN.wrapMode = WrapMode.Loop;
				this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
				this.tmpAN.Play(this.mHeroAct[0]);
				this.tmpAN.clip = this.tmpAN.GetClip(this.mHeroAct[0]);
				if (this.Hero_Pos.gameObject.activeSelf)
				{
					SkinnedMeshRenderer componentInChildren = this.Hero_Model.GetComponentInChildren<SkinnedMeshRenderer>();
					componentInChildren.useLightProbes = false;
					componentInChildren.updateWhenOffscreen = true;
				}
			}
			this.ABIsDone = true;
		}
		if (this.ABIsDone && this.Hero_Model != null && (!this.tmpAN.IsPlaying(this.HeroAct) || this.HeroAct == "idle") && (double)this.ActionTimeRandom < 0.0001)
		{
			this.ActionTimeRandom = (float)UnityEngine.Random.Range(3, 7);
			this.ActionTime = 0f;
		}
		if ((double)this.ActionTimeRandom > 0.0001)
		{
			this.ActionTime += Time.smoothDeltaTime;
			if (this.ActionTime >= this.ActionTimeRandom)
			{
				this.HeroActionChang(false);
			}
		}
		if (this.ABIsDone && this.Hero_Model != null && this.MovingTimer > 0f)
		{
			this.MovingTimer -= Time.deltaTime;
			if (this.MovingTimer <= 0f)
			{
				this.tmpAN.CrossFade("idle");
				this.HeroAct = "idle";
			}
		}
		if (this.mNowpage == 0 && this.Pagedata[0])
		{
			if (this.btn_Rank_Exit.IsActive())
			{
				this.Rank_ImgT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
			}
			if (this.RankLightBG.IsActive())
			{
				this.Equip_ImgT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
			}
			if (this.StarStratumLightBG.IsActive())
			{
				this.Star_ImgT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
			}
			if (this.Img_StarEvolution.IsActive())
			{
				this.ShowStarEvolution += Time.smoothDeltaTime;
				if (this.ShowStarEvolution >= 0f)
				{
					if (this.ShowStarEvolution >= 2f)
					{
						this.ShowStarEvolution = 0f;
					}
					float a2 = (this.ShowStarEvolution <= 1f) ? this.ShowStarEvolution : (2f - this.ShowStarEvolution);
					this.Img_StarEvolution.color = new Color(1f, 1f, 1f, a2);
				}
			}
			if (this.bShowEquipLight)
			{
				this.ShowEquipLight += Time.smoothDeltaTime;
			}
			for (int i = 0; i < 6; i++)
			{
				if (this.img_EquipHave_Light[i].IsActive() && this.ShowEquipLight >= 0f)
				{
					if (this.ShowEquipLight >= 2f)
					{
						this.ShowEquipLight = 0f;
					}
					float a3 = (this.ShowEquipLight <= 1f) ? this.ShowEquipLight : (2f - this.ShowEquipLight);
					this.img_EquipHave_Light[i].color = new Color(1f, 1f, 1f, a3);
				}
				if (this.img_EquipLight[i].IsActive())
				{
					this.EquipShow[i] += Time.smoothDeltaTime;
					if (this.Btn_Eq[i])
					{
						if (this.EquipShow[i] > 0.2f)
						{
							this.btn_EquipRT[i].sizeDelta = new Vector2(70f, 70f);
							this.Btn_Eq[i] = false;
						}
						else
						{
							this.EquipShowSCale[i] = this.SelectTween(this.EquipShow[i], 70f, 14f, 0.2f);
							this.btn_EquipRT[i].sizeDelta = new Vector2(this.EquipShowSCale[i], this.EquipShowSCale[i]);
						}
					}
					if (this.EquipShow[i] > 0.4f)
					{
						this.img_EquipLight[i].gameObject.SetActive(false);
						this.img_EquipLight[i].color = new Color(1f, 1f, 1f, 1f);
						this.Img_EquipLightRT[i].sizeDelta = new Vector2(106f, 106f);
					}
					else
					{
						this.EquipShowSCale[i] = this.SelectTween(this.EquipShow[i], 106f, 106f, 0.4f);
						this.Img_EquipLightRT[i].sizeDelta = new Vector2(this.EquipShowSCale[i], this.EquipShowSCale[i]);
						this.EquipShowSCale[i] = this.SelectTween(this.EquipShow[i], 1f, -1f, 0.4f);
						this.img_EquipLight[i].color = new Color(1f, 1f, 1f, this.EquipShowSCale[i]);
					}
				}
			}
		}
		if (this.mNowpage == 1 && this.Pagedata[1])
		{
			this.Skill_ImgT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
			this.SkillPageTime += Time.smoothDeltaTime;
			if (this.SkillPageTime >= 0f)
			{
				if (this.SkillPageTime >= 2f)
				{
					this.SkillPageTime = 0f;
				}
				float a4 = (this.SkillPageTime <= 1f) ? this.SkillPageTime : (2f - this.SkillPageTime);
				this.img_SkillPage[this.mSkillpage].color = new Color(1f, 1f, 1f, a4);
			}
		}
		this.TmpTime += Time.smoothDeltaTime * 40f;
		if (this.TmpTime >= 40f)
		{
			this.TmpTime = 0f;
		}
		float num = (this.TmpTime <= 20f) ? this.TmpTime : (40f - this.TmpTime);
		if (num < 0f)
		{
			num = 0f;
		}
		this.Vec3Instance.Set(this.MoveTime1 - num, this.btn_NextT.localPosition.y, this.btn_NextT.localPosition.z);
		this.btn_NextT.localPosition = this.Vec3Instance;
		this.Vec3Instance.Set(this.MoveTime2 + num, this.btn_BackT.localPosition.y, this.btn_BackT.localPosition.z);
		this.btn_BackT.localPosition = this.Vec3Instance;
		if (this.mShowEffectNum > 0)
		{
			this.mShowEffectTime += Time.smoothDeltaTime;
			for (int j = 0; j < 6; j++)
			{
				if (this.text_ShowEffect[j].IsActive())
				{
					if (this.text_ShowEffect[j].rectTransform.anchoredPosition.y >= -50f && this.text_ShowEffect[j].rectTransform.anchoredPosition.y < -20f)
					{
						this.text_ShowEffect[j].color = new Color(0.4f, 0.83f, 0.4f, (-20f - this.text_ShowEffect[j].rectTransform.anchoredPosition.y) / 30f);
					}
					else if (this.text_ShowEffect[j].rectTransform.anchoredPosition.y >= -20f)
					{
						this.text_ShowEffect[j].gameObject.SetActive(false);
						this.mShowEffectNum--;
					}
					this.text_ShowEffect[j].rectTransform.anchoredPosition = new Vector2(this.text_ShowEffect[j].rectTransform.anchoredPosition.x, -200f + (this.mShowEffectTime - (float)j * 0.2f) * 200f);
				}
				else if (this.mShowEffectTime >= (float)j * 0.2f && this.text_ShowEffect[j].rectTransform.anchoredPosition.y == -200f)
				{
					this.text_ShowEffect[j].gameObject.SetActive(true);
				}
			}
		}
		if (this.text_PreviewHero != null && this.img_PreviewBG != null && this.img_PreviewBG.gameObject.activeSelf)
		{
			this.PreviewTime += Time.smoothDeltaTime;
			if (this.PreviewTime >= 0f)
			{
				if (this.PreviewTime >= 3.1f)
				{
					this.PreviewTime = 0f;
				}
				float num2 = 1f;
				if (this.PreviewTime > 0.5f)
				{
					num2 = ((this.PreviewTime <= 1.8f) ? (0.25f + (1.3f - (this.PreviewTime - 0.5f)) / 1.3f * 0.75f) : (0.25f + (this.PreviewTime - 0.5f - 1.3f) / 1.3f * 0.75f));
				}
				num2 = Mathf.Clamp(num2, 0.25f, 1f);
				this.img_PreviewBG.color = new Color(1f, 1f, 0.518f, num2);
				this.text_PreviewHero.color = new Color(1f, 1f, 0.518f, num2);
			}
		}
	}

	// Token: 0x06001CBF RID: 7359 RVA: 0x003335D4 File Offset: 0x003317D4
	public void OnTimer(UITimeBar sender)
	{
		if (sender.m_TimeBarID == 1)
		{
			this.bFSetRankTimeBar = true;
			this.timeBarRank.gameObject.SetActive(false);
		}
		else
		{
			this.bFSetStarTimeBar = true;
			this.timeBarStar.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001CC0 RID: 7360 RVA: 0x00333624 File Offset: 0x00331824
	public void OnNotify(UITimeBar sender)
	{
		if (sender.m_TimeBarID == 1)
		{
			eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.HeroEnhance);
			this.GUIM.SetTimerSpriteType(this.timeBarRank, queueBarSpriteType);
		}
		else
		{
			eTimerSpriteType queueBarSpriteType2 = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.HeroEvolution);
			this.GUIM.SetTimerSpriteType(this.timeBarStar, queueBarSpriteType2);
		}
	}

	// Token: 0x06001CC1 RID: 7361 RVA: 0x00333680 File Offset: 0x00331880
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.ScrollItemT[panelObjectIdx] == null)
		{
			this.ScrollItemT[panelObjectIdx] = item.GetComponent<Transform>();
			this.text_P3p2_Property[panelObjectIdx] = this.ScrollItemT[panelObjectIdx].GetChild(0).GetChild(0).GetComponent<UIText>();
			this.text_P3p2_Property[panelObjectIdx].font = this.TTFont;
			this.text_P3p2_PropertyValue[panelObjectIdx] = this.ScrollItemT[panelObjectIdx].GetChild(1).GetChild(0).GetComponent<UIText>();
			this.text_P3p2_PropertyValue[panelObjectIdx].font = this.TTFont;
			this.mbtn_Item[panelObjectIdx] = this.ScrollItemT[panelObjectIdx].GetChild(3).GetComponent<UIButton>();
			this.mbtn_Item[panelObjectIdx].m_Handler = this;
			this.mbtn_Item[panelObjectIdx].m_BtnID1 = 43;
			this.mbtn_Item[panelObjectIdx].m_BtnID2 = 43 + dataIdx;
			this.mbtnH_Item[panelObjectIdx] = this.ScrollItemT[panelObjectIdx].GetChild(3).GetComponent<UIButtonHint>();
			this.mbtnH_Item[panelObjectIdx].m_Handler = this;
			this.mbtnH_Item[panelObjectIdx].ControlFadeOut = this.PropertyInfo_Hint.gameObject;
		}
		if (this.text_P3p2_Property[panelObjectIdx] != null)
		{
			this.Cstr_ItemPropertyValue[panelObjectIdx].ClearString();
			this.mbtn_Item[panelObjectIdx].m_BtnID2 = 43 + dataIdx;
			if (dataIdx == 0)
			{
				this.text_P3p2_Property[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(125u);
				StringManager.IntToStr(this.Cstr_ItemPropertyValue[panelObjectIdx], (long)((ulong)this.HP), 1, true);
				this.text_P3p2_PropertyValue[panelObjectIdx].text = this.Cstr_ItemPropertyValue[panelObjectIdx].ToString();
			}
			else
			{
				ushort num = this.pAttrIdx[dataIdx];
				if (this.pAttrIdx[dataIdx] >= 23)
				{
					num -= 3;
				}
				this.text_P3p2_Property[panelObjectIdx].text = this.DM.mStringTable.GetStringByID((uint)(123 + num));
				StringManager.IntToStr(this.Cstr_ItemPropertyValue[panelObjectIdx], (long)this.pAttr[(int)this.pAttrIdx[dataIdx]], 1, true);
				this.text_P3p2_PropertyValue[panelObjectIdx].text = this.Cstr_ItemPropertyValue[panelObjectIdx].ToString();
			}
			this.text_P3p2_PropertyValue[panelObjectIdx].SetAllDirty();
			this.text_P3p2_PropertyValue[panelObjectIdx].cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06001CC2 RID: 7362 RVA: 0x003338C4 File Offset: 0x00331AC4
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001CC3 RID: 7363 RVA: 0x003338C8 File Offset: 0x00331AC8
	public void ClearShowEffect()
	{
		this.mShowEffectTime = 0f;
		this.mShowEffectNum = 0;
		for (int i = 0; i < 6; i++)
		{
			this.text_ShowEffect[i].text = string.Empty;
			this.text_ShowEffect[i].SetAllDirty();
			this.text_ShowEffect[i].cachedTextGenerator.Invalidate();
			this.text_ShowEffect[i].gameObject.SetActive(false);
			this.text_ShowEffect[i].rectTransform.anchoredPosition = new Vector2(this.text_ShowEffect[i].rectTransform.anchoredPosition.x, -200f);
			this.text_ShowEffect[i].color = new Color(0.4f, 0.83f, 0.4f, 1f);
		}
	}

	// Token: 0x06001CC4 RID: 7364 RVA: 0x0033399C File Offset: 0x00331B9C
	public void AddShowEffect(byte Kind, int ItemIdx = 0)
	{
		this.ClearShowEffect();
		this.HeroActionChang(true);
		switch (Kind)
		{
		case 0:
		{
			ushort inKey = this.mEnhance.EnhanceNumber[(this.mHeroStratum - 1) * 6 + ItemIdx];
			this.mEquip = this.DM.EquipTable.GetRecordByKey(inKey);
			int num = 0;
			for (int i = 0; i < this.mEquip.PropertiesInfo.Length; i++)
			{
				if (this.mEquip.PropertiesInfo[i].Propertieskey != 0)
				{
					int propertiesValue = (int)this.mEquip.PropertiesInfo[i].PropertiesValue;
					this.Cstr_ShowEffect[i].ClearString();
					this.meffect = this.DM.EffectData.GetRecordByKey(this.mEquip.PropertiesInfo[i].Propertieskey);
					this.Cstr_ShowEffect[i].IntToFormat((long)propertiesValue, 1, false);
					this.Cstr_ShowEffect[i].AppendFormat(this.DM.mStringTable.GetStringByID((uint)this.meffect.String_infoID));
					this.text_ShowEffect[num].text = this.Cstr_ShowEffect[i].ToString();
					this.text_ShowEffect[num].SetAllDirty();
					this.text_ShowEffect[num].cachedTextGenerator.Invalidate();
					num++;
					this.mShowEffectNum++;
				}
			}
			break;
		}
		case 1:
			for (int j = 0; j < 3; j++)
			{
				this.Cstr_ShowEffect[j].ClearString();
				this.Cstr_ShowEffect[j].Append(this.DM.mStringTable.GetStringByID((uint)(122 + j)));
				this.Cstr_ShowEffect[j].IntToFormat(2L, 1, false);
				this.Cstr_ShowEffect[j].AppendFormat("+{0}");
				this.text_ShowEffect[j].text = this.Cstr_ShowEffect[j].ToString();
				this.text_ShowEffect[j].SetAllDirty();
				this.text_ShowEffect[j].cachedTextGenerator.Invalidate();
				this.mShowEffectNum++;
			}
			this.Cstr_ShowEffect[3].ClearString();
			this.Cstr_ShowEffect[3].Append(this.DM.mStringTable.GetStringByID(343u));
			this.Cstr_ShowEffect[3].IntToFormat((long)(this.DM.RankSoldiers[(int)this.mHeroData.Enhance] - this.DM.RankSoldiers[(int)(this.mHeroData.Enhance - 1)]), 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_ShowEffect[3].AppendFormat("{0}+");
			}
			else
			{
				this.Cstr_ShowEffect[3].AppendFormat("+{0}");
			}
			this.text_ShowEffect[3].text = this.Cstr_ShowEffect[3].ToString();
			this.text_ShowEffect[3].SetAllDirty();
			this.text_ShowEffect[3].cachedTextGenerator.Invalidate();
			this.mShowEffectNum++;
			break;
		case 2:
			for (int k = 0; k < 3; k++)
			{
				if (this.pAttr[k] - this.ShowEffectpAttr[k] != 0)
				{
					this.Cstr_ShowEffect[this.mShowEffectNum].ClearString();
					this.Cstr_ShowEffect[this.mShowEffectNum].Append(this.DM.mStringTable.GetStringByID((uint)(122 + k)));
					this.Cstr_ShowEffect[this.mShowEffectNum].IntToFormat((long)(this.pAttr[k] - this.ShowEffectpAttr[k]), 1, false);
					this.Cstr_ShowEffect[this.mShowEffectNum].AppendFormat("+{0}");
					this.text_ShowEffect[this.mShowEffectNum].text = this.Cstr_ShowEffect[this.mShowEffectNum].ToString();
					this.text_ShowEffect[this.mShowEffectNum].SetAllDirty();
					this.text_ShowEffect[this.mShowEffectNum].cachedTextGenerator.Invalidate();
					this.mShowEffectNum++;
				}
			}
			break;
		}
		this.mParticleEffectpAttr = ParticleManager.Instance.Spawn(372, this.GameT.GetChild(13), new Vector3(0f, 0f, 0f), 1f, true, true, true);
		this.GUIM.SetLayer(this.mParticleEffectpAttr, 5);
		this.mParticleEffectpAttr.transform.localPosition = new Vector3(0f, -230f, 1000f);
		Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
		localRotation.eulerAngles = new Vector3(0f, 0f, 0f);
		this.mParticleEffectpAttr.transform.localRotation = localRotation;
		this.mParticleEffectpAttr.gameObject.SetActive(true);
		AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
	}

	// Token: 0x06001CC5 RID: 7365 RVA: 0x00333EB4 File Offset: 0x003320B4
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
		{
			uint num = this.DM.sortHeroData[this.mHeroDataIndex];
			this.mHeroData = this.DM.curHeroData[num];
			if (this.mOpenType == 1)
			{
				this.mHeroData.Level = this.DM.PreviewHeroData.Level;
				this.mHeroData.Enhance = this.DM.PreviewHeroData.Enhance;
				this.mHeroData.Star = this.DM.PreviewHeroData.Star;
				this.mHeroData.Equip = this.DM.PreviewHeroData.Equip;
				this.mHeroData.SkillLV[0] = this.DM.PreviewHeroData.SkillLV[0];
				this.mHeroData.SkillLV[1] = this.DM.PreviewHeroData.SkillLV[1];
				this.mHeroData.SkillLV[2] = this.DM.PreviewHeroData.SkillLV[2];
				this.mHeroData.SkillLV[3] = this.DM.PreviewHeroData.SkillLV[3];
			}
			this.mHeroStratum = (int)this.mHeroData.Enhance;
			this.AddShowEffect(0, arg2);
			this.SetStratum(this.mHeroStratum);
			this.ReSetBtnState();
			this.UpdatePower();
			this.img_EquipLight[arg2].gameObject.SetActive(true);
			this.EquipShow[arg2] = 0f;
			this.Btn_Eq[arg2] = true;
			AudioManager.Instance.PlayUISFX(UIKind.EquipTake);
			NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, this, false);
			break;
		}
		case 2:
			this.CheckRankTimeBar();
			this.RankLightBG.gameObject.SetActive(false);
			NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, this, false);
			break;
		case 3:
			if (this.mOpenType == 1)
			{
				return;
			}
			this.mHeroData = this.DM.curHeroData[(uint)this.mHeroData.ID];
			this.mHeroStratum = (int)this.mHeroData.Enhance;
			this.btn_Fragment.image.sprite = this.SArray.m_Sprites[9 + this.mHeroStratum];
			if (this.mHeroData.ID == this.DM.RoleAttr.EnhanceEventHeroID || (int)this.mHeroData.ID == arg2)
			{
				this.AddShowEffect(1, 0);
				if (this.Pagedata[0] != null)
				{
					this.SetStratum(this.mHeroStratum);
					this.ReSetBtnState();
					this.CheckRankTimeBar();
				}
				this.UpdatePower();
				if (this.Pagedata[1] != null)
				{
					this.ReSetSkill();
					this.Cstr_Leader.ClearString();
					this.Cstr_Leader.IntToFormat((long)this.DM.RankSoldiers[(int)this.mHeroData.Enhance], 1, false);
					if (this.GUIM.IsArabic)
					{
						this.Cstr_Leader.AppendFormat("{0}+");
					}
					else
					{
						this.Cstr_Leader.AppendFormat("+{0}");
					}
					this.text_Leader[0].text = this.Cstr_Leader.ToString();
					this.text_Leader[0].SetAllDirty();
					this.text_Leader[0].cachedTextGenerator.Invalidate();
				}
			}
			break;
		case 4:
			this.CheckStarTimeBar();
			this.StarStratumLightBG.gameObject.SetActive(false);
			this.Cstr_HeroStarLv.ClearString();
			if (this.GUIM.IsArabic)
			{
				this.Cstr_HeroStarLv.FloatToFormat(this.MaxStar, -1, true);
				this.Cstr_HeroStarLv.IntToFormat((long)this.DM.GetCurItemQuantity(this.sHero.SoulStone, 0), 1, false);
			}
			else
			{
				this.Cstr_HeroStarLv.IntToFormat((long)this.DM.GetCurItemQuantity(this.sHero.SoulStone, 0), 1, false);
				this.Cstr_HeroStarLv.FloatToFormat(this.MaxStar, -1, true);
			}
			this.Cstr_HeroStarLv.AppendFormat("{0} / {1}");
			this.text_HeroStarLv.text = this.Cstr_HeroStarLv.ToString();
			this.text_HeroStarLv.SetAllDirty();
			this.text_HeroStarLv.cachedTextGenerator.Invalidate();
			break;
		case 5:
			if (this.mOpenType == 1)
			{
				return;
			}
			this.mHeroData = this.DM.curHeroData[(uint)this.mHeroData.ID];
			this.mHeroStratum = (int)this.mHeroData.Enhance;
			if (this.mHeroData.ID == this.DM.RoleAttr.StarUpEventHeroID || (int)this.mHeroData.ID == arg2)
			{
				if (this.Pagedata[0] != null)
				{
					if (this.mHeroData.Star < 5)
					{
						this.MaxStar = (float)this.DM.Medal[(int)this.mHeroData.Star];
					}
					this.SetStarStratum((int)this.DM.GetCurItemQuantity(this.sHero.SoulStone, 0), (int)this.mHeroData.Star);
					this.CheckStarTimeBar();
				}
				this.mHeroId = this.mHeroData.ID;
				this.mCalcAttrData.SkillLV1 = this.mHeroData.SkillLV[0];
				this.mCalcAttrData.SkillLV2 = this.mHeroData.SkillLV[1];
				this.mCalcAttrData.SkillLV3 = this.mHeroData.SkillLV[2];
				this.mCalcAttrData.SkillLV4 = this.mHeroData.SkillLV[3];
				for (int i = 0; i < 4; i++)
				{
					this.SkillLv[i] = this.mHeroData.SkillLV[i];
				}
				this.mCalcAttrData.LV = this.mHeroData.Level;
				this.mCalcAttrData.Star = this.mHeroData.Star - 1;
				this.mCalcAttrData.Enhance = this.mHeroData.Enhance;
				this.mCalcAttrData.Equip = this.mHeroData.Equip;
				uint num2 = 0u;
				Array.Clear(this.EquipEffect_pAttr, 0, this.EquipEffect_pAttr.Length);
				this.mBs.setCalculateHeroEquipEffect(this.mHeroId, this.mHeroData.Enhance, this.mHeroData.Equip, ref num2, this.EquipEffect_pAttr);
				uint num3 = 0u;
				Array.Clear(this.pAttr, 0, this.pAttr.Length);
				this.mBs.setCalculateAttribute(this.mHeroId, ref this.mCalcAttrData, ref num3, this.pAttr);
				for (int j = 0; j < 3; j++)
				{
					this.ShowEffectpAttr[j] = this.pAttr[j];
				}
				this.UpdatePower();
				this.AddShowEffect(2, 0);
			}
			break;
		case 6:
			if ((int)this.mHeroData.ID == arg2)
			{
				this.mHeroData = this.DM.curHeroData[(uint)arg2];
				if (this.mOpenType == 1)
				{
					this.mHeroData.Level = this.DM.PreviewHeroData.Level;
					this.mHeroData.Enhance = this.DM.PreviewHeroData.Enhance;
					this.mHeroData.Star = this.DM.PreviewHeroData.Star;
					this.mHeroData.Equip = this.DM.PreviewHeroData.Equip;
					this.mHeroData.SkillLV[0] = this.DM.PreviewHeroData.SkillLV[0];
					this.mHeroData.SkillLV[1] = this.DM.PreviewHeroData.SkillLV[1];
					this.mHeroData.SkillLV[2] = this.DM.PreviewHeroData.SkillLV[2];
					this.mHeroData.SkillLV[3] = this.DM.PreviewHeroData.SkillLV[3];
				}
				this.SetHeroEXP(this.mHeroData.Exp);
				this.UpdatePower();
				if (this.Pagedata[1] != null)
				{
					this.ReSetSkill();
				}
			}
			break;
		case 7:
			if (arg2 == (int)this.mHeroId)
			{
				this.bFSetRankTimeBar = true;
				this.GUIM.RemoverTimeBaarToList(this.timeBarRank);
				this.CheckRankTimeBar();
				this.RankLightBG.gameObject.SetActive(true);
				this.timeBarRank.gameObject.SetActive(false);
			}
			break;
		case 8:
			if (arg2 == (int)this.mHeroId)
			{
				this.bFSetStarTimeBar = true;
				this.GUIM.RemoverTimeBaarToList(this.timeBarStar);
				this.CheckStarTimeBar();
				this.StarStratumLightBG.gameObject.SetActive(true);
				this.StarEvolutionRT.gameObject.SetActive(true);
				this.Cstr_HeroStarLv.ClearString();
				if (this.GUIM.IsArabic)
				{
					this.Cstr_HeroStarLv.FloatToFormat(this.MaxStar, -1, true);
					this.Cstr_HeroStarLv.IntToFormat((long)this.DM.GetCurItemQuantity(this.sHero.SoulStone, 0), 1, false);
				}
				else
				{
					this.Cstr_HeroStarLv.IntToFormat((long)this.DM.GetCurItemQuantity(this.sHero.SoulStone, 0), 1, false);
					this.Cstr_HeroStarLv.FloatToFormat(this.MaxStar, -1, true);
				}
				this.Cstr_HeroStarLv.AppendFormat("{0} / {1}");
				this.text_HeroStarLv.text = this.Cstr_HeroStarLv.ToString();
				this.text_HeroStarLv.SetAllDirty();
				this.text_HeroStarLv.cachedTextGenerator.Invalidate();
			}
			break;
		case 9:
			this.OpenUISynthesis = true;
			break;
		}
	}

	// Token: 0x06001CC6 RID: 7366 RVA: 0x0033488C File Offset: 0x00332A8C
	public override bool OnBackButtonClick()
	{
		if (this.btn_Rank_Exit.IsActive())
		{
			this.OpenRankEquip(false);
		}
		this.OpenUISynthesis = false;
		this.mHeroDataIndex = -1;
		return false;
	}

	// Token: 0x06001CC7 RID: 7367 RVA: 0x003348C0 File Offset: 0x00332AC0
	public void Onfunc(UITimeBar sender)
	{
		if (sender.m_TimeBarID == 1)
		{
			if (sender.m_TimerSpriteType == eTimerSpriteType.Speed)
			{
				this.OpenUISynthesis = true;
				this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 11, false);
			}
			else if (sender.m_TimerSpriteType == eTimerSpriteType.Free)
			{
				this.DM.SendHeroEnhance_Free();
			}
		}
		else if (sender.m_TimerSpriteType == eTimerSpriteType.Speed)
		{
			this.OpenUISynthesis = true;
			this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 12, false);
		}
		else if (sender.m_TimerSpriteType == eTimerSpriteType.Free)
		{
			this.DM.SendHeroStarUp_Free();
		}
	}

	// Token: 0x06001CC8 RID: 7368 RVA: 0x00334960 File Offset: 0x00332B60
	public void OnCancel(UITimeBar sender)
	{
		if (sender.m_TimeBarID == 1)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_HEROENHANCE_CANCEL;
			messagePacket.AddSeqId();
			messagePacket.Add(this.mHeroData.ID);
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Hero_Info);
		}
		else
		{
			MessagePacket messagePacket2 = new MessagePacket(1024);
			messagePacket2.Protocol = Protocol._MSG_REQUEST_HEROSTARUP_CANCEL;
			messagePacket2.AddSeqId();
			messagePacket2.Add(this.mHeroData.ID);
			messagePacket2.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Hero_Info);
		}
	}

	// Token: 0x06001CC9 RID: 7369 RVA: 0x00334A00 File Offset: 0x00332C00
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		switch (uibutton.m_BtnID1)
		{
		case 15:
		case 16:
		case 17:
		case 18:
		{
			if (this.sHero.AttackPower != null)
			{
				this.mSkill = this.DM.SkillTable.GetRecordByKey(this.sHero.AttackPower[uibutton.m_BtnID1 - 15 + 1]);
			}
			ushort heroAttrValA = GameConstants.SetHintValue(this.pAttr, this.mSkill.HurtKind, true);
			ushort heroAttrValB = GameConstants.SetHintValue(this.pAttr, this.mSkill.HurtKind, false);
			if (this.mOpenType == 1)
			{
				this.GUIM.m_SkillInfo.Show(sender, (uint)this.mHeroData.ID, (byte)(uibutton.m_BtnID1 - 15), heroAttrValA, heroAttrValB, true);
			}
			else
			{
				this.GUIM.m_SkillInfo.Show(sender, (uint)this.mHeroData.ID, (byte)(uibutton.m_BtnID1 - 15), heroAttrValA, heroAttrValB, false);
			}
			break;
		}
		case 34:
		case 35:
		case 36:
		case 37:
			if (this.mOpenType == 1)
			{
				this.GUIM.m_SkillInfo.Show(sender, (uint)this.mHeroData.ID, (byte)(uibutton.m_BtnID1 - 34 + 4), 0, 0, true);
			}
			else
			{
				this.GUIM.m_SkillInfo.Show(sender, (uint)this.mHeroData.ID, (byte)(uibutton.m_BtnID1 - 34 + 4), 0, 0, false);
			}
			break;
		case 38:
			if (!this.Property_Hint.IsActive())
			{
				this.Property_Hint.gameObject.SetActive(true);
				if (this.Fragment_Hint.IsActive())
				{
					this.Fragment_Hint.gameObject.SetActive(false);
				}
				if (this.HeroState_Hint.IsActive())
				{
					this.HeroState_Hint.gameObject.SetActive(false);
				}
				if (this.HeroPower_Hint.IsActive())
				{
					this.HeroPower_Hint.gameObject.SetActive(false);
				}
			}
			break;
		case 39:
			if (!this.Fragment_Hint.IsActive())
			{
				this.Fragment_Hint.gameObject.SetActive(true);
				if (this.Property_Hint.IsActive())
				{
					this.Property_Hint.gameObject.SetActive(false);
				}
				if (this.HeroState_Hint.IsActive())
				{
					this.HeroState_Hint.gameObject.SetActive(false);
				}
				if (this.HeroPower_Hint.IsActive())
				{
					this.HeroPower_Hint.gameObject.SetActive(false);
				}
			}
			break;
		case 40:
		case 41:
		case 42:
			if (!this.PropertyInfo_Hint.IsActive())
			{
				this.PropertyInfo_Hint.gameObject.SetActive(true);
			}
			this.Cstr_Hint.ClearString();
			this.Cstr_Hint.StringToFormat(this.DM.mStringTable.GetStringByID((uint)((ushort)(122 + uibutton.m_BtnID1 - 40))));
			this.Cstr_Hint.IntToFormat((long)(this.pAttr[uibutton.m_BtnID1 - 40] - this.EquipEffect_pAttr[uibutton.m_BtnID1 - 40]), 1, true);
			if (this.EquipEffect_pAttr[uibutton.m_BtnID1 - 40] > 0)
			{
				this.Cstr_Hint.IntToFormat((long)this.EquipEffect_pAttr[uibutton.m_BtnID1 - 40], 1, false);
				this.Cstr_Hint.AppendFormat("<color=#FFF799>{0}</color> {1}<color=#33EB67>+{2}</color>\n");
			}
			else
			{
				this.Cstr_Hint.AppendFormat("<color=#FFF799>{0}</color> {1}\n");
			}
			this.Cstr_Hint.StringToFormat(this.DM.mStringTable.GetStringByID((uint)((ushort)(381 + uibutton.m_BtnID1 - 40))));
			this.Cstr_Hint.AppendFormat("{0}");
			this.text_Hint[2].text = this.Cstr_Hint.ToString();
			this.text_Hint[2].SetAllDirty();
			this.text_Hint[2].cachedTextGenerator.Invalidate();
			this.text_Hint[2].cachedTextGeneratorForLayout.Invalidate();
			this.PropertyInfo_HintRT[1].sizeDelta = new Vector2(this.PropertyInfo_HintRT[1].sizeDelta.x, this.text_Hint[2].preferredHeight);
			this.PropertyInfo_HintRT[0].sizeDelta = new Vector2(this.PropertyInfo_HintRT[0].sizeDelta.x, this.text_Hint[2].preferredHeight / 25f * 30f);
			break;
		case 43:
		{
			if (!this.PropertyInfo_Hint.IsActive())
			{
				this.PropertyInfo_Hint.gameObject.SetActive(true);
			}
			ushort num = this.pAttrIdx[uibutton.m_BtnID2 - 43];
			if (this.pAttrIdx[uibutton.m_BtnID2 - 43] >= 23)
			{
				num -= 3;
			}
			if (uibutton.m_BtnID2 - 43 == 0)
			{
				num = 2;
			}
			this.Cstr_Hint.ClearString();
			this.Cstr_Hint.StringToFormat(this.DM.mStringTable.GetStringByID((uint)(123 + num)));
			bool flag = false;
			if (num == 2)
			{
				this.Cstr_Hint.IntToFormat((long)((ulong)(this.HP - this.EquipEffect_HP)), 1, true);
				if (this.EquipEffect_HP > 0u)
				{
					this.Cstr_Hint.IntToFormat((long)((ulong)this.EquipEffect_HP), 1, true);
					flag = true;
				}
			}
			else
			{
				this.Cstr_Hint.IntToFormat((long)(this.pAttr[(int)this.pAttrIdx[uibutton.m_BtnID2 - 43]] - this.EquipEffect_pAttr[(int)this.EquipEffect_pAttrIdx[uibutton.m_BtnID2 - 43]]), 1, true);
				if (this.EquipEffect_pAttr[(int)this.EquipEffect_pAttrIdx[uibutton.m_BtnID2 - 43]] > 0)
				{
					this.Cstr_Hint.IntToFormat((long)this.EquipEffect_pAttr[(int)this.EquipEffect_pAttrIdx[uibutton.m_BtnID2 - 43]], 1, true);
					flag = true;
				}
			}
			if (flag)
			{
				this.Cstr_Hint.AppendFormat("<color=#FFF799>{0}</color> {1}<color=#33EB67>+{2}</color>\n");
			}
			else
			{
				this.Cstr_Hint.AppendFormat("<color=#FFF799>{0}</color> {1}\n");
			}
			this.Cstr_Hint.StringToFormat(this.DM.mStringTable.GetStringByID((uint)(382 + num)));
			this.Cstr_Hint.AppendFormat("{0}");
			this.text_Hint[2].text = this.Cstr_Hint.ToString();
			this.text_Hint[2].SetAllDirty();
			this.text_Hint[2].cachedTextGenerator.Invalidate();
			this.text_Hint[2].cachedTextGeneratorForLayout.Invalidate();
			this.PropertyInfo_HintRT[1].sizeDelta = new Vector2(this.PropertyInfo_HintRT[1].sizeDelta.x, this.text_Hint[2].preferredHeight);
			this.PropertyInfo_HintRT[0].sizeDelta = new Vector2(this.PropertyInfo_HintRT[0].sizeDelta.x, this.text_Hint[2].preferredHeight / 25f * 30f);
			break;
		}
		case 44:
			if (!this.HeroState_Hint.IsActive())
			{
				this.HeroState_Hint.gameObject.SetActive(true);
				if (this.Property_Hint.IsActive())
				{
					this.Property_Hint.gameObject.SetActive(false);
				}
				if (this.Fragment_Hint.IsActive())
				{
					this.Fragment_Hint.gameObject.SetActive(false);
				}
				if (this.HeroPower_Hint.IsActive())
				{
					this.HeroPower_Hint.gameObject.SetActive(false);
				}
			}
			break;
		case 45:
			if (!this.HeroPower_Hint.IsActive())
			{
				this.HeroPower_Hint.gameObject.SetActive(true);
				if (this.Property_Hint.IsActive())
				{
					this.Property_Hint.gameObject.SetActive(false);
				}
				if (this.Fragment_Hint.IsActive())
				{
					this.Fragment_Hint.gameObject.SetActive(false);
				}
				if (this.HeroState_Hint.IsActive())
				{
					this.HeroState_Hint.gameObject.SetActive(false);
				}
			}
			break;
		}
	}

	// Token: 0x06001CCA RID: 7370 RVA: 0x00335278 File Offset: 0x00333478
	public void OnButtonUp(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		switch (uibutton.m_BtnID1)
		{
		case 15:
		case 16:
		case 17:
		case 18:
		case 34:
		case 35:
		case 36:
		case 37:
			this.GUIM.m_SkillInfo.Hide(sender);
			break;
		case 38:
			if (this.Property_Hint.IsActive())
			{
				this.Property_Hint.gameObject.SetActive(false);
			}
			break;
		case 39:
			if (this.Fragment_Hint.IsActive())
			{
				this.Fragment_Hint.gameObject.SetActive(false);
			}
			break;
		case 40:
		case 41:
		case 42:
			if (this.PropertyInfo_Hint.IsActive())
			{
				this.PropertyInfo_Hint.gameObject.SetActive(false);
			}
			break;
		case 43:
			if (this.PropertyInfo_Hint.IsActive())
			{
				if (this.m_ScrollRect.Get_Dragging())
				{
					this.PropertyInfo_Hint.gameObject.SetActive(false);
				}
				else
				{
					this.PropertyInfo_Hint.gameObject.SetActive(false);
				}
			}
			break;
		case 44:
			if (this.HeroState_Hint.IsActive())
			{
				this.HeroState_Hint.gameObject.SetActive(false);
			}
			break;
		case 45:
			if (this.HeroPower_Hint.IsActive())
			{
				this.HeroPower_Hint.gameObject.SetActive(false);
			}
			break;
		}
	}

	// Token: 0x040056E0 RID: 22240
	private Transform GameT;

	// Token: 0x040056E1 RID: 22241
	private Transform Tmp;

	// Token: 0x040056E2 RID: 22242
	private Transform Tmp1;

	// Token: 0x040056E3 RID: 22243
	private Transform Tmp2;

	// Token: 0x040056E4 RID: 22244
	private Transform PageT;

	// Token: 0x040056E5 RID: 22245
	private Transform[] Pagedata = new Transform[3];

	// Token: 0x040056E6 RID: 22246
	private Transform P3_p1;

	// Token: 0x040056E7 RID: 22247
	private Transform P3_p2;

	// Token: 0x040056E8 RID: 22248
	private Transform Hero_3D;

	// Token: 0x040056E9 RID: 22249
	private Transform Hero_Pos;

	// Token: 0x040056EA RID: 22250
	private Transform Equip_ImgT;

	// Token: 0x040056EB RID: 22251
	private Transform Star_ImgT;

	// Token: 0x040056EC RID: 22252
	private Transform Rank_ImgT;

	// Token: 0x040056ED RID: 22253
	private Transform Skill_ImgT;

	// Token: 0x040056EE RID: 22254
	private Transform btn_NextT;

	// Token: 0x040056EF RID: 22255
	private Transform btn_BackT;

	// Token: 0x040056F0 RID: 22256
	private Transform RankLightT;

	// Token: 0x040056F1 RID: 22257
	private Transform StarLightT;

	// Token: 0x040056F2 RID: 22258
	private Transform Hero_Model;

	// Token: 0x040056F3 RID: 22259
	private Transform[] ScrollItemT = new Transform[10];

	// Token: 0x040056F4 RID: 22260
	private Transform[] SkillPageT = new Transform[2];

	// Token: 0x040056F5 RID: 22261
	private RectTransform ContentRT;

	// Token: 0x040056F6 RID: 22262
	private RectTransform Hero_PosRT;

	// Token: 0x040056F7 RID: 22263
	private RectTransform[] PropertyInfo_HintRT = new RectTransform[2];

	// Token: 0x040056F8 RID: 22264
	private RectTransform[] btn_EquipRT = new RectTransform[6];

	// Token: 0x040056F9 RID: 22265
	private RectTransform[] Img_EquipRT = new RectTransform[6];

	// Token: 0x040056FA RID: 22266
	private RectTransform[] Img_HaveRT = new RectTransform[6];

	// Token: 0x040056FB RID: 22267
	private RectTransform[] text_RT = new RectTransform[6];

	// Token: 0x040056FC RID: 22268
	private RectTransform btn_EvolutionRT;

	// Token: 0x040056FD RID: 22269
	private RectTransform Img_EvolutionUpRT;

	// Token: 0x040056FE RID: 22270
	private RectTransform btn_StarEvolutionRT;

	// Token: 0x040056FF RID: 22271
	private RectTransform btn_NextRankRT;

	// Token: 0x04005700 RID: 22272
	private RectTransform btn_StarDetailRT;

	// Token: 0x04005701 RID: 22273
	private RectTransform Img_StarStratumLightRT;

	// Token: 0x04005702 RID: 22274
	private RectTransform uTool_RankPosRT;

	// Token: 0x04005703 RID: 22275
	private RectTransform[] Img_EquipLightRT = new RectTransform[6];

	// Token: 0x04005704 RID: 22276
	private RectTransform EvolutionRT;

	// Token: 0x04005705 RID: 22277
	private RectTransform StarEvolutionRT;

	// Token: 0x04005706 RID: 22278
	private RectTransform tmpRC;

	// Token: 0x04005707 RID: 22279
	public UIButton btn_EXIT;

	// Token: 0x04005708 RID: 22280
	private UIButton[] btnPage = new UIButton[3];

	// Token: 0x04005709 RID: 22281
	public UIButton btn_Evolution;

	// Token: 0x0400570A RID: 22282
	public UIHIBtn[] btn_Equip = new UIHIBtn[6];

	// Token: 0x0400570B RID: 22283
	private UIButton btn_EquipStratum;

	// Token: 0x0400570C RID: 22284
	private UIButton btn_StarEvolution;

	// Token: 0x0400570D RID: 22285
	private UIButton btn_DETAIL;

	// Token: 0x0400570E RID: 22286
	private UIButton[] btn_SkillPage = new UIButton[2];

	// Token: 0x0400570F RID: 22287
	private UIButton[] btn_Skill = new UIButton[8];

	// Token: 0x04005710 RID: 22288
	private UIButton btn_Next;

	// Token: 0x04005711 RID: 22289
	private UIButton btn_Back;

	// Token: 0x04005712 RID: 22290
	private UIButton btn_HeroAction;

	// Token: 0x04005713 RID: 22291
	private UIButton btn_Rank_Exit;

	// Token: 0x04005714 RID: 22292
	private UIHIBtn[] btn_RankEquip = new UIHIBtn[6];

	// Token: 0x04005715 RID: 22293
	private UIButton btn_P3Info;

	// Token: 0x04005716 RID: 22294
	private UIButton btn_Property;

	// Token: 0x04005717 RID: 22295
	private UIButton btn_Fragment;

	// Token: 0x04005718 RID: 22296
	private UIButton btn_HeroState;

	// Token: 0x04005719 RID: 22297
	private UIButton[] btn_P3_Property = new UIButton[3];

	// Token: 0x0400571A RID: 22298
	private UIButton tmpbtn;

	// Token: 0x0400571B RID: 22299
	private UIButton[] mbtn_Item = new UIButton[10];

	// Token: 0x0400571C RID: 22300
	private UIButton btn_HeroPowerHint;

	// Token: 0x0400571D RID: 22301
	private UIButtonHint tmpbtnHint;

	// Token: 0x0400571E RID: 22302
	private UIButtonHint[] mbtnH_Item = new UIButtonHint[10];

	// Token: 0x0400571F RID: 22303
	private UIBtnDrag btn_HeroActionD;

	// Token: 0x04005720 RID: 22304
	private Image Property_Hint;

	// Token: 0x04005721 RID: 22305
	private Image img_HeroExp;

	// Token: 0x04005722 RID: 22306
	private Image Fragment_Hint;

	// Token: 0x04005723 RID: 22307
	private Image imgRank_Rank;

	// Token: 0x04005724 RID: 22308
	private Image RankLightBG;

	// Token: 0x04005725 RID: 22309
	private Image StarStratumLightBG;

	// Token: 0x04005726 RID: 22310
	private Image PropertyInfo_Hint;

	// Token: 0x04005727 RID: 22311
	private Image Img_EvolutionUp;

	// Token: 0x04005728 RID: 22312
	private Image Img_StarEvolution;

	// Token: 0x04005729 RID: 22313
	private Image[] img_EquipLight = new Image[6];

	// Token: 0x0400572A RID: 22314
	private Image[] img_EquipHave = new Image[6];

	// Token: 0x0400572B RID: 22315
	private Image[] img_EquipHave_Light = new Image[6];

	// Token: 0x0400572C RID: 22316
	private Image[] img_SkillPage = new Image[2];

	// Token: 0x0400572D RID: 22317
	private Image[] img_Skill = new Image[8];

	// Token: 0x0400572E RID: 22318
	private Image[] img_SkillFrame = new Image[8];

	// Token: 0x0400572F RID: 22319
	private Image[] img_Lock = new Image[6];

	// Token: 0x04005730 RID: 22320
	private Image[] img_Pageicon = new Image[3];

	// Token: 0x04005731 RID: 22321
	private Image[] img_PageBG = new Image[3];

	// Token: 0x04005732 RID: 22322
	private Image[] img_SkillBook = new Image[3];

	// Token: 0x04005733 RID: 22323
	private Image[] img_Skill_Lv = new Image[3];

	// Token: 0x04005734 RID: 22324
	private Image img_HeroState;

	// Token: 0x04005735 RID: 22325
	private Image HeroState_Hint;

	// Token: 0x04005736 RID: 22326
	private Image HeroPower_Hint;

	// Token: 0x04005737 RID: 22327
	private Image img_Lv;

	// Token: 0x04005738 RID: 22328
	private Image img_PreviewBG;

	// Token: 0x04005739 RID: 22329
	private UIText text_Rank;

	// Token: 0x0400573A RID: 22330
	private UIText text_HeroEXP;

	// Token: 0x0400573B RID: 22331
	private UIText text_HeroPower;

	// Token: 0x0400573C RID: 22332
	private UIText text_Lv;

	// Token: 0x0400573D RID: 22333
	private UIText text_HeroName;

	// Token: 0x0400573E RID: 22334
	private UIText text_HeroTitle;

	// Token: 0x0400573F RID: 22335
	private UIText text_NextRankTiTle;

	// Token: 0x04005740 RID: 22336
	private UIText text_NextRank;

	// Token: 0x04005741 RID: 22337
	private UIText text_HeroInfo;

	// Token: 0x04005742 RID: 22338
	private UIText text_Medal;

	// Token: 0x04005743 RID: 22339
	private UIText text_HeroStarLv;

	// Token: 0x04005744 RID: 22340
	private UIText text_P3Title;

	// Token: 0x04005745 RID: 22341
	private UIText text_Skill_Name;

	// Token: 0x04005746 RID: 22342
	private UIText text_Next_RankSoldier;

	// Token: 0x04005747 RID: 22343
	private UIText[] text_Leader = new UIText[2];

	// Token: 0x04005748 RID: 22344
	private UIText[] text_Equip = new UIText[6];

	// Token: 0x04005749 RID: 22345
	private UIText[] text_Property = new UIText[6];

	// Token: 0x0400574A RID: 22346
	private UIText[] text_Skill2_ = new UIText[8];

	// Token: 0x0400574B RID: 22347
	private UIText[] text_Skill_Lv = new UIText[4];

	// Token: 0x0400574C RID: 22348
	private UIText[] text_Skill_Lock = new UIText[3];

	// Token: 0x0400574D RID: 22349
	private UIText[] text_P3p2_Property = new UIText[10];

	// Token: 0x0400574E RID: 22350
	private UIText[] text_P3p2_PropertyValue = new UIText[10];

	// Token: 0x0400574F RID: 22351
	private UIText[] text_SkillPage = new UIText[2];

	// Token: 0x04005750 RID: 22352
	private UIText[] text_Hint = new UIText[3];

	// Token: 0x04005751 RID: 22353
	private UIText text_HeroStateHint;

	// Token: 0x04005752 RID: 22354
	private UIText text_HeroPowerHint;

	// Token: 0x04005753 RID: 22355
	private UIText[] text_tmpStr = new UIText[10];

	// Token: 0x04005754 RID: 22356
	private UIText[] text_timeBarRank = new UIText[2];

	// Token: 0x04005755 RID: 22357
	private UIText[] text_timeBarStar = new UIText[2];

	// Token: 0x04005756 RID: 22358
	private UIText[] text_ShowEffect = new UIText[6];

	// Token: 0x04005757 RID: 22359
	private UIText text_PreviewHero;

	// Token: 0x04005758 RID: 22360
	private UIText tmptext;

	// Token: 0x04005759 RID: 22361
	private Font TTFont;

	// Token: 0x0400575A RID: 22362
	private CString Cstr_RankTimeBar;

	// Token: 0x0400575B RID: 22363
	private CString Cstr_Rank;

	// Token: 0x0400575C RID: 22364
	private CString Cstr_NextRank;

	// Token: 0x0400575D RID: 22365
	private CString Cstr_HeroStarLv;

	// Token: 0x0400575E RID: 22366
	private CString Cstr_HeroEXP;

	// Token: 0x0400575F RID: 22367
	private CString Cstr_HeroPower;

	// Token: 0x04005760 RID: 22368
	private CString Cstr_Leader;

	// Token: 0x04005761 RID: 22369
	private CString[] Cstr_Skill_Lv = new CString[4];

	// Token: 0x04005762 RID: 22370
	private CString[] Cstr_Skill_Cost = new CString[4];

	// Token: 0x04005763 RID: 22371
	private CString[] Cstr_Skill_Info = new CString[4];

	// Token: 0x04005764 RID: 22372
	private CString Cstr_Hint;

	// Token: 0x04005765 RID: 22373
	private CString Cstr_NextRS;

	// Token: 0x04005766 RID: 22374
	private CString[] Cstr_ShowEffect = new CString[6];

	// Token: 0x04005767 RID: 22375
	private CString[] Cstr_Property = new CString[3];

	// Token: 0x04005768 RID: 22376
	private CString[] Cstr_ItemPropertyValue = new CString[10];

	// Token: 0x04005769 RID: 22377
	public UITimeBar timeBarRank;

	// Token: 0x0400576A RID: 22378
	private UITimeBar timeBarStar;

	// Token: 0x0400576B RID: 22379
	private Vector2 TmpV;

	// Token: 0x0400576C RID: 22380
	private Vector3 Vec3Instance;

	// Token: 0x0400576D RID: 22381
	private Color Text_Color = new Color(1f, 1f, 0f, 1f);

	// Token: 0x0400576E RID: 22382
	private Color Color_White = Color.white;

	// Token: 0x0400576F RID: 22383
	private Color Color_Gray = Color.gray;

	// Token: 0x04005770 RID: 22384
	private Color Color_Green = Color.green;

	// Token: 0x04005771 RID: 22385
	private Color Color_Target = new Color(1f, 0.988f, 0.8196f, 1f);

	// Token: 0x04005772 RID: 22386
	private Color Color_NoTarget = new Color(0.5255f, 0.8235f, 0.902f, 1f);

	// Token: 0x04005773 RID: 22387
	private Color Color_Equip = new Color(0.2471f, 0.4784f, 0.9333f, 1f);

	// Token: 0x04005774 RID: 22388
	private DataManager DM;

	// Token: 0x04005775 RID: 22389
	private GUIManager GUIM;

	// Token: 0x04005776 RID: 22390
	private Hero sHero;

	// Token: 0x04005777 RID: 22391
	private Enhance mEnhance;

	// Token: 0x04005778 RID: 22392
	private Equip mEquip;

	// Token: 0x04005779 RID: 22393
	private Skill mSkill;

	// Token: 0x0400577A RID: 22394
	private CurHeroData mHeroData;

	// Token: 0x0400577B RID: 22395
	private Effect meffect;

	// Token: 0x0400577C RID: 22396
	private byte[] SkillLv = new byte[4];

	// Token: 0x0400577D RID: 22397
	private byte[] SendSkillLv = new byte[4];

	// Token: 0x0400577E RID: 22398
	private ushort mHeroId;

	// Token: 0x0400577F RID: 22399
	private ushort[] pAttr = new ushort[28];

	// Token: 0x04005780 RID: 22400
	private ushort[] pAttrIdx = new ushort[23];

	// Token: 0x04005781 RID: 22401
	private ushort[] EquipEffect_pAttr = new ushort[28];

	// Token: 0x04005782 RID: 22402
	private ushort[] EquipEffect_pAttrIdx = new ushort[23];

	// Token: 0x04005783 RID: 22403
	private int mNowpage;

	// Token: 0x04005784 RID: 22404
	private int mSkillpage;

	// Token: 0x04005785 RID: 22405
	private int TmpChildCount;

	// Token: 0x04005786 RID: 22406
	private int mHeroStratum;

	// Token: 0x04005787 RID: 22407
	private int mHeroEquip;

	// Token: 0x04005788 RID: 22408
	private int AssetKey;

	// Token: 0x04005789 RID: 22409
	private int mHeroDataIndex = -1;

	// Token: 0x0400578A RID: 22410
	private int[] SkillLimit = new int[4];

	// Token: 0x0400578B RID: 22411
	private float[] StarValue = new float[6];

	// Token: 0x0400578C RID: 22412
	private float mExpLength;

	// Token: 0x0400578D RID: 22413
	private bool bHeroInfo = true;

	// Token: 0x0400578E RID: 22414
	private bool bEnchantments;

	// Token: 0x0400578F RID: 22415
	private bool bStarEvolution;

	// Token: 0x04005790 RID: 22416
	private bool bEquip;

	// Token: 0x04005791 RID: 22417
	private bool bSkill;

	// Token: 0x04005792 RID: 22418
	private bool bInfo;

	// Token: 0x04005793 RID: 22419
	private bool bFSetRankTimeBar = true;

	// Token: 0x04005794 RID: 22420
	private bool bFSetStarTimeBar = true;

	// Token: 0x04005795 RID: 22421
	private bool OpenUISynthesis;

	// Token: 0x04005796 RID: 22422
	private float TmpTime;

	// Token: 0x04005797 RID: 22423
	private float ActionTime;

	// Token: 0x04005798 RID: 22424
	private float ActionTimeRandom;

	// Token: 0x04005799 RID: 22425
	private float MovingTimer;

	// Token: 0x0400579A RID: 22426
	private float MaxStar;

	// Token: 0x0400579B RID: 22427
	private float MoveTime1;

	// Token: 0x0400579C RID: 22428
	private float MoveTime2;

	// Token: 0x0400579D RID: 22429
	private float SkillPageTime;

	// Token: 0x0400579E RID: 22430
	private float ShowStarEvolution;

	// Token: 0x0400579F RID: 22431
	private float tempL;

	// Token: 0x040057A0 RID: 22432
	private float[] EquipShow = new float[6];

	// Token: 0x040057A1 RID: 22433
	private float[] EquipShowSCale = new float[6];

	// Token: 0x040057A2 RID: 22434
	private float ShowEquipLight;

	// Token: 0x040057A3 RID: 22435
	private float PageBGTime;

	// Token: 0x040057A4 RID: 22436
	private bool bShowEquipLight;

	// Token: 0x040057A5 RID: 22437
	private bool[] Btn_Eq = new bool[6];

	// Token: 0x040057A6 RID: 22438
	private uint HP;

	// Token: 0x040057A7 RID: 22439
	private uint EquipEffect_HP;

	// Token: 0x040057A8 RID: 22440
	private uint Power;

	// Token: 0x040057A9 RID: 22441
	private long begin;

	// Token: 0x040057AA RID: 22442
	private long target;

	// Token: 0x040057AB RID: 22443
	private long notify;

	// Token: 0x040057AC RID: 22444
	private byte OpenPage;

	// Token: 0x040057AD RID: 22445
	private int TopRank = 8;

	// Token: 0x040057AE RID: 22446
	private uint needDiamond;

	// Token: 0x040057AF RID: 22447
	private ushort[] key = new ushort[4];

	// Token: 0x040057B0 RID: 22448
	private float PreviewTime;

	// Token: 0x040057B1 RID: 22449
	private CalcAttrDataType mCalcAttrData = default(CalcAttrDataType);

	// Token: 0x040057B2 RID: 22450
	private BSInvokeUtil mBs = BSInvokeUtil.getInstance;

	// Token: 0x040057B3 RID: 22451
	private GameObject go;

	// Token: 0x040057B4 RID: 22452
	private GameObject go2;

	// Token: 0x040057B5 RID: 22453
	private GameObject mParticleRank;

	// Token: 0x040057B6 RID: 22454
	private GameObject mParticleStar;

	// Token: 0x040057B7 RID: 22455
	private GameObject mParticleEffectpAttr;

	// Token: 0x040057B8 RID: 22456
	private UISpritesArray SArray;

	// Token: 0x040057B9 RID: 22457
	private string[] TopText = new string[2];

	// Token: 0x040057BA RID: 22458
	private ScrollPanel m_itemView;

	// Token: 0x040057BB RID: 22459
	private CScrollRect m_ScrollRect;

	// Token: 0x040057BC RID: 22460
	private ScrollRect m_Mask;

	// Token: 0x040057BD RID: 22461
	private List<float> tmplist = new List<float>();

	// Token: 0x040057BE RID: 22462
	private Material IconMaterial;

	// Token: 0x040057BF RID: 22463
	private Material FrameMaterial;

	// Token: 0x040057C0 RID: 22464
	private Material SkillMaterial;

	// Token: 0x040057C1 RID: 22465
	private Door door;

	// Token: 0x040057C2 RID: 22466
	private AssetBundle AB;

	// Token: 0x040057C3 RID: 22467
	private AssetBundleRequest AR;

	// Token: 0x040057C4 RID: 22468
	private bool ABIsDone;

	// Token: 0x040057C5 RID: 22469
	public byte[] LegionRankMagnifation = new byte[]
	{
		1,
		2,
		4,
		8,
		20
	};

	// Token: 0x040057C6 RID: 22470
	private uTweenScale uToolStar;

	// Token: 0x040057C7 RID: 22471
	private uTweenScale uToolRank;

	// Token: 0x040057C8 RID: 22472
	private uTweenPosition uToolRankPos;

	// Token: 0x040057C9 RID: 22473
	private string HeroAct;

	// Token: 0x040057CA RID: 22474
	private Animation tmpAN;

	// Token: 0x040057CB RID: 22475
	public string[] mHeroAct = new string[7];

	// Token: 0x040057CC RID: 22476
	private eHeroState mHeroState;

	// Token: 0x040057CD RID: 22477
	public float mShowEffectTime;

	// Token: 0x040057CE RID: 22478
	public int mShowEffectNum;

	// Token: 0x040057CF RID: 22479
	private ushort[] ShowEffectpAttr = new ushort[3];

	// Token: 0x040057D0 RID: 22480
	public byte mOpenType;

	// Token: 0x040057D1 RID: 22481
	public byte mOpenKind;
}
