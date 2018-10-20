using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000551 RID: 1361
public class UIFightingSummary : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUILEBtnClickHandler
{
	// Token: 0x06001B19 RID: 6937 RVA: 0x002EBD60 File Offset: 0x002E9F60
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.PM = PetManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.mMaT = this.door.LoadMaterial();
		this.IconMaterial = this.GUIM.m_IconSpriteAsset.GetMaterial();
		this.FrameMaterial = this.GUIM.GetFrameMaterial();
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		if (this.GUIM.BattleSerialNo > 0u)
		{
			this.door.CloseMenu(false);
			return;
		}
		if (this.DM.mSaveInfo == 3)
		{
			this.mOpenKind = 0;
		}
		else
		{
			this.mOpenKind = arg1;
		}
		this.Favor.Serial = this.DM.OpenMail.Serial;
		this.Favor.Type = this.DM.OpenMail.Type;
		this.Favor.Kind = this.DM.OpenMail.Kind;
		if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
		{
			this.Report = this.Favor.Combat;
			if (!this.Report.BeRead)
			{
				if (this.Favor.Kind == MailType.EMAIL_BATTLE)
				{
					this.DM.BattleReportRead(this.Report.SerialID, false);
				}
				else
				{
					this.DM.FavorReportRead(this.Report.SerialID, false);
				}
			}
			if (this.Report.Type == CombatCollectReport.CCR_NPCCOMBAT)
			{
				this.bNpcMode = true;
			}
			if (this.Report.Type == CombatCollectReport.CCR_MONSTER)
			{
				this.mOpenKind = 1;
			}
			else
			{
				this.mOpenKind = 0;
			}
			if (this.mOpenKind == 0)
			{
				Array.Clear(this.m_A_Skill_ID, 0, this.m_A_Skill_ID.Length);
				Array.Clear(this.m_A_Skill_LV, 0, this.m_A_Skill_LV.Length);
				Array.Clear(this.m_A_DeBf_Skill_ID, 0, this.m_A_DeBf_Skill_ID.Length);
				Array.Clear(this.m_A_DeBf_Skill_LV, 0, this.m_A_DeBf_Skill_LV.Length);
				Array.Clear(this.m_D_Skill_ID, 0, this.m_D_Skill_ID.Length);
				Array.Clear(this.m_D_Skill_LV, 0, this.m_A_Skill_ID.Length);
				Array.Clear(this.m_D_DeBf_Skill_ID, 0, this.m_D_DeBf_Skill_ID.Length);
				Array.Clear(this.m_D_DeBf_Skill_LV, 0, this.m_D_DeBf_Skill_LV.Length);
				this.mA_Skill_L = 0;
				this.mDeBf_A_L = 0;
				this.mD_Skill_R = 0;
				this.mDeBf_D_R = 0;
				if (!this.bNpcMode)
				{
					if (this.Report.Combat.Result == CombatReportResultType.ECRR_COMBATVICTORY || this.Report.Combat.Result == CombatReportResultType.ECRR_DEFENDVICTORY || this.Report.Combat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER || this.Report.Combat.Result == CombatReportResultType.ECRR_WONDERVICTORY)
					{
						this.bWin = true;
					}
					else
					{
						this.bWin = false;
					}
					this.IsAttack = (this.Report.Combat.Side == 0 || this.Report.Combat.Side == 2 || this.Report.Combat.Side == 4 || this.Report.Combat.Side == 6);
					this.mType = (int)this.Report.Combat.Result;
					if (this.mType >= 4 && this.mType <= 7)
					{
						this.bQuanmier = true;
					}
					if (this.Report.Combat.PetSkillPatchNo != this.DM.PetVersionNo)
					{
						this.bDoNotShow = true;
					}
					for (int i = 0; i < 20; i++)
					{
						if (this.Report.Combat.m_AssaultPetSkill_ID[i] > 0)
						{
							if (this.mA_Skill_L < this.m_A_Skill_ID.Length && this.PM.PetSkillTable.GetRecordByKey(this.Report.Combat.m_AssaultPetSkill_ID[i]).Subject == 1)
							{
								this.m_A_Skill_ID[this.mA_Skill_L] = this.Report.Combat.m_AssaultPetSkill_ID[i];
								this.m_A_Skill_LV[this.mA_Skill_L] = this.Report.Combat.m_AssaultPetSkill_LV[i];
								this.mA_Skill_L++;
							}
							else if (this.mDeBf_A_L < this.m_A_DeBf_Skill_ID.Length)
							{
								this.m_A_DeBf_Skill_ID[this.mDeBf_A_L] = this.Report.Combat.m_AssaultPetSkill_ID[i];
								this.m_A_DeBf_Skill_LV[this.mDeBf_A_L] = this.Report.Combat.m_AssaultPetSkill_LV[i];
								this.mDeBf_A_L++;
							}
						}
						if (this.Report.Combat.m_DefencePetSkill_ID[i] > 0)
						{
							if (this.mD_Skill_R < this.m_D_Skill_ID.Length && this.PM.PetSkillTable.GetRecordByKey(this.Report.Combat.m_DefencePetSkill_ID[i]).Subject == 1)
							{
								this.m_D_Skill_ID[this.mD_Skill_R] = this.Report.Combat.m_DefencePetSkill_ID[i];
								this.m_D_Skill_LV[this.mD_Skill_R] = this.Report.Combat.m_DefencePetSkill_LV[i];
								this.mD_Skill_R++;
							}
							else if (this.mDeBf_D_R < this.m_D_DeBf_Skill_ID.Length)
							{
								this.m_D_DeBf_Skill_ID[this.mDeBf_D_R] = this.Report.Combat.m_DefencePetSkill_ID[i];
								this.m_D_DeBf_Skill_LV[this.mDeBf_D_R] = this.Report.Combat.m_DefencePetSkill_LV[i];
								this.mDeBf_D_R++;
							}
						}
					}
				}
				else
				{
					if (this.Report.NPCCombat.Result == CombatReportResultType.ECRR_COMBATVICTORY || this.Report.NPCCombat.Result == CombatReportResultType.ECRR_DEFENDVICTORY || this.Report.NPCCombat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER || this.Report.NPCCombat.Result == CombatReportResultType.ECRR_WONDERVICTORY)
					{
						this.bWin = true;
					}
					else
					{
						this.bWin = false;
					}
					this.IsAttack = (this.Report.NPCCombat.Side == 0 || this.Report.NPCCombat.Side == 2 || this.Report.NPCCombat.Side == 4 || this.Report.NPCCombat.Side == 6);
					this.mType = (int)this.Report.NPCCombat.Result;
					if (this.mType >= 4 && this.mType <= 7)
					{
						this.bQuanmier = true;
					}
					if (this.Report.NPCCombat.PetSkillPatchNo != this.DM.PetVersionNo)
					{
						this.bDoNotShow = true;
					}
					for (int j = 0; j < 20; j++)
					{
						if (this.Report.NPCCombat.m_AssaultPetSkill_ID[j] > 0)
						{
							if (this.mA_Skill_L < this.m_A_Skill_ID.Length && this.PM.PetSkillTable.GetRecordByKey(this.Report.NPCCombat.m_AssaultPetSkill_ID[j]).Subject == 1)
							{
								this.m_A_Skill_ID[this.mA_Skill_L] = this.Report.NPCCombat.m_AssaultPetSkill_ID[j];
								this.m_A_Skill_LV[this.mA_Skill_L] = this.Report.NPCCombat.m_AssaultPetSkill_LV[j];
								this.mA_Skill_L++;
							}
							else if (this.mDeBf_A_L < this.m_A_DeBf_Skill_ID.Length)
							{
								this.m_A_DeBf_Skill_ID[this.mDeBf_A_L] = this.Report.NPCCombat.m_AssaultPetSkill_ID[j];
								this.m_A_DeBf_Skill_LV[this.mDeBf_A_L] = this.Report.NPCCombat.m_AssaultPetSkill_LV[j];
								this.mDeBf_A_L++;
							}
						}
					}
				}
			}
			else if (this.mOpenKind == 1)
			{
			}
			this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_MAX);
			CString cstring = StringManager.Instance.StaticString1024();
			this.Cstr_TitleName = StringManager.Instance.SpawnString(200);
			this.Cstr_Page = StringManager.Instance.SpawnString(30);
			this.Cstr_FightingKind = StringManager.Instance.SpawnString(100);
			this.Cstr_L_Exp = StringManager.Instance.SpawnString(30);
			this.Cstr_BoosHead = StringManager.Instance.SpawnString(30);
			this.Cstr_Text = StringManager.Instance.SpawnString(30);
			this.Cstr_Quanmie[0] = StringManager.Instance.SpawnString(100);
			this.Cstr_NpcTroops = StringManager.Instance.SpawnString(30);
			this.Cstr_QuanmieNpcTroops = StringManager.Instance.SpawnString(30);
			this.Cstr_LF = StringManager.Instance.SpawnString(200);
			this.Cstr_RF = StringManager.Instance.SpawnString(200);
			for (int k = 1; k < 4; k++)
			{
				this.Cstr_Quanmie[k] = StringManager.Instance.SpawnString(30);
			}
			for (int l = 0; l < 30; l++)
			{
				this.Cstr_ItemQty[l] = StringManager.Instance.SpawnString(10);
			}
			for (int m = 0; m < 2; m++)
			{
				this.Cstr_Coordinate[m] = StringManager.Instance.SpawnString(30);
				this.Cstr_Offensive[m] = StringManager.Instance.SpawnString(30);
				this.Cstr_LossValue[m] = StringManager.Instance.SpawnString(30);
				this.Cstr_Strength[m] = StringManager.Instance.SpawnString(30);
				this.Cstr_Country[m] = StringManager.Instance.SpawnString(30);
				this.Cstr_Dominance[m] = StringManager.Instance.SpawnString(30);
				this.Cstr_CoordinateMainHero[m] = StringManager.Instance.SpawnString(30);
				this.Cstr_Name[m] = StringManager.Instance.SpawnString(30);
				this.Cstr_BossR[m] = StringManager.Instance.SpawnString(30);
				this.Cstr_BossFight[m] = StringManager.Instance.SpawnString(100);
				this.Cstr_BossL[m] = StringManager.Instance.SpawnString(30);
			}
			for (int n = 0; n < 5; n++)
			{
				this.Cstr_Resources[n] = StringManager.Instance.SpawnString(30);
				this.StrResources[n] = StringManager.Instance.SpawnString(30);
				this.StrResources[n].ClearString();
				this.Cstr_HeroExp[n] = StringManager.Instance.SpawnString(30);
			}
			for (int num = 0; num < 8; num++)
			{
				this.Cstr_RA[num] = StringManager.Instance.SpawnString(30);
			}
			for (int num2 = 0; num2 < 4; num2++)
			{
				this.Cstr_LA[num2] = StringManager.Instance.SpawnString(30);
			}
			for (int num3 = 0; num3 < 3; num3++)
			{
				this.Cstr_DW[num3] = StringManager.Instance.SpawnString(30);
			}
			this.StrResources[0].Append("UI_main_res_food");
			this.StrResources[1].Append("UI_main_res_stone");
			this.StrResources[2].Append("UI_main_res_wood");
			this.StrResources[3].Append("UI_main_res_iron");
			this.StrResources[4].Append("UI_main_money_01");
			this.Tmp = this.GameT.GetChild(0);
			this.Tmp1 = this.Tmp.GetChild(1);
			this.text_TitleName = this.Tmp1.GetChild(0).GetComponent<UIText>();
			this.text_TitleName.font = this.TTFont;
			this.text_Page = this.Tmp1.GetChild(1).GetComponent<UIText>();
			this.text_Page.font = this.TTFont;
			this.Tmp = this.GameT.GetChild(1);
			this.Mask_T = this.GameT.GetChild(1);
			this.m_Mask = this.Tmp.GetComponent<CScrollRect>();
			this.ContentRT = this.Tmp.GetChild(0).GetComponent<RectTransform>();
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
			this.Img_Titlebg = this.Tmp1.GetComponent<Image>();
			this.ReplayerRT = this.Tmp1.GetComponent<RectTransform>();
			this.btn_Replay = this.Tmp1.GetChild(0).GetComponent<UIButton>();
			this.btn_Replay.m_Handler = this;
			this.btn_Replay.m_BtnID1 = 6;
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
			this.text_MainHero = this.Tmp1.GetChild(0).GetComponent<UIText>();
			this.text_MainHero.font = this.TTFont;
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(2);
			this.ItemRT = this.Tmp1.GetComponent<RectTransform>();
			this.ItemRT.anchoredPosition = new Vector2(this.ItemRT.anchoredPosition.x, this.tmpH);
			this.ItemRT2 = this.Tmp1.GetChild(0).GetComponent<RectTransform>();
			this.text_TitleItem = this.Tmp1.GetChild(1).GetComponent<UIText>();
			this.text_TitleItem.font = this.TTFont;
			this.ItemT[0] = this.Tmp1.GetChild(0).GetChild(0);
			this.ItemBase = this.Tmp1.GetChild(0).GetChild(0);
			this.Tmp2 = this.Tmp1.GetChild(0).GetChild(1);
			this.ResourcesRT = this.Tmp2.GetComponent<RectTransform>();
			for (int num4 = 0; num4 < 5; num4++)
			{
				this.tmpImg = this.Tmp2.GetChild(num4).GetComponent<Image>();
				this.tmpImg.sprite = this.door.LoadSprite(this.StrResources[num4]);
				this.tmpImg.material = this.mMaT;
				this.text_Resources[num4] = this.Tmp2.GetChild(num4).GetChild(0).GetComponent<UIText>();
				this.text_Resources[num4].font = this.TTFont;
			}
			this.Tmp2 = this.Tmp1.GetChild(0).GetChild(2);
			this.NpcItemRT = this.Tmp2.GetComponent<RectTransform>();
			this.Img_NpcItemHint = this.Tmp1.GetChild(0).GetChild(3).GetComponent<Image>();
			this.text_NpcItemHint = this.Tmp1.GetChild(0).GetChild(3).GetChild(0).GetComponent<UIText>();
			this.text_NpcItemHint.font = this.TTFont;
			this.text_NpcItemHint.text = this.DM.mStringTable.GetStringByID(9633u);
			this.text_NpcItemHint.fontSize = 22;
			this.text_NpcItemHint.resizeTextMaxSize = 22;
			this.text_NpcItemHint.alignment = TextAnchor.MiddleLeft;
			if (this.text_NpcItemHint.preferredWidth < 380f)
			{
				this.Img_NpcItemHint.rectTransform.sizeDelta = new Vector2(this.text_NpcItemHint.preferredWidth + 21f, this.Img_NpcItemHint.rectTransform.sizeDelta.y);
				this.text_NpcItemHint.rectTransform.sizeDelta = new Vector2(this.text_NpcItemHint.preferredWidth + 1f, this.text_NpcItemHint.rectTransform.sizeDelta.y);
			}
			else if (this.text_NpcItemHint.preferredHeight > 40f)
			{
				this.text_NpcItemHint.rectTransform.sizeDelta = new Vector2(380f, this.text_NpcItemHint.preferredHeight + 1f);
				this.Img_NpcItemHint.rectTransform.sizeDelta = new Vector2(400f, this.text_NpcItemHint.preferredHeight + 11f);
			}
			this.btn_NpcItemIcon = this.Tmp2.GetChild(0).GetComponent<UIButton>();
			this.btn_NpcItemIcon.m_Handler = this;
			this.btn_NpcItemIcon.m_BtnID1 = 14;
			this.tmpbtnHint = this.btn_NpcItemIcon.gameObject.AddComponent<UIButtonHint>();
			this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
			this.tmpbtnHint.m_Handler = this;
			this.tmpbtnHint.DelayTime = 0.3f;
			this.tmpbtnHint.ControlFadeOut = this.Img_NpcItemHint.gameObject;
			this.btn_NpcItemName = this.Tmp2.GetChild(1).GetComponent<UIButton>();
			this.btn_NpcItemName.m_Handler = this;
			this.btn_NpcItemName.m_BtnID1 = 14;
			this.tmpbtnHint = this.btn_NpcItemName.gameObject.AddComponent<UIButtonHint>();
			this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
			this.tmpbtnHint.m_Handler = this;
			this.tmpbtnHint.DelayTime = 0.3f;
			this.tmpbtnHint.ControlFadeOut = this.Img_NpcItemHint.gameObject;
			this.text_NpcItemName = this.Tmp2.GetChild(1).GetChild(1).GetComponent<UIText>();
			this.text_NpcItemName.font = this.TTFont;
			Equip recordByKey = this.DM.EquipTable.GetRecordByKey(1001);
			this.text_NpcItemName.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.EquipName);
			this.text_NpcItemName.SetAllDirty();
			this.text_NpcItemName.cachedTextGenerator.Invalidate();
			this.text_NpcItemName.cachedTextGeneratorForLayout.Invalidate();
			this.tmpRC = this.btn_NpcItemName.transform.GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.text_NpcItemName.preferredWidth, this.tmpRC.sizeDelta.y);
			this.tmpRC = this.btn_NpcItemName.transform.GetChild(0).GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.text_NpcItemName.preferredWidth, this.tmpRC.sizeDelta.y);
			this.tmpRC = this.btn_NpcItemName.transform.GetChild(1).GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.text_NpcItemName.preferredWidth, this.tmpRC.sizeDelta.y);
			this.text_NpcItemfull = this.Tmp2.GetChild(2).GetComponent<UIText>();
			this.text_NpcItemfull.font = this.TTFont;
			this.text_NpcItemfull.text = this.DM.mStringTable.GetStringByID(9593u);
			this.Tmp2 = this.Tmp1.GetChild(0).GetChild(4);
			this.AllianceBossItemRT = this.Tmp2.GetComponent<RectTransform>();
			this.text_AllianceBossStr = this.Tmp1.GetChild(0).GetChild(4).GetChild(0).GetComponent<UIText>();
			this.text_AllianceBossStr.font = this.TTFont;
			this.Tmp1 = this.Tmp.GetChild(0).GetChild(3);
			this.HeroRT = this.Tmp1.GetComponent<RectTransform>();
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
			for (int num5 = 0; num5 < 5; num5++)
			{
				this.btn_Hero[num5] = this.Tmp1.GetChild(0).GetChild(1).GetChild(num5).GetComponent<UIHIBtn>();
				this.text_HeroExp[num5] = this.Tmp1.GetChild(0).GetChild(1).GetChild(num5 + 5).GetComponent<UIText>();
				this.text_HeroExp[num5].font = this.TTFont;
				this.text_HeroExp2[num5] = this.Tmp1.GetChild(0).GetChild(1).GetChild(num5 + 10).GetComponent<UIText>();
				this.text_HeroExp2[num5].font = this.TTFont;
				this.text_HeroExp2[num5].text = this.DM.mStringTable.GetStringByID(7695u);
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
			if (this.mOpenKind == 0)
			{
				if (!this.bInitFS)
				{
					this.bInitFS = true;
				}
				this.InitFSComponent();
			}
			if (this.mOpenKind == 1)
			{
				if (!this.bInitBoss)
				{
					this.bInitBoss = true;
				}
				this.InitBossComponent();
			}
			this.Tmp = this.GameT.GetChild(2);
			this.Tmp1 = this.Tmp.GetChild(0);
			this.btn_Title = this.Tmp1.GetComponent<UIButton>();
			this.btn_Title.m_Handler = this;
			this.btn_Title.m_BtnID1 = 3;
			this.text_Coordinate = this.Tmp1.GetChild(1).GetComponent<UIText>();
			this.text_Coordinate.font = this.TTFont;
			this.Tmp1 = this.Tmp.GetChild(1);
			this.text_Time[0] = this.Tmp1.GetComponent<UIText>();
			this.text_Time[0].font = this.TTFont;
			this.Tmp1 = this.Tmp.GetChild(2);
			this.text_Time[1] = this.Tmp1.GetComponent<UIText>();
			this.text_Time[1].font = this.TTFont;
			this.Tmp1 = this.GameT.GetChild(3);
			this.btn_Delete = this.Tmp1.GetComponent<UIButton>();
			this.btn_Delete.m_Handler = this;
			this.btn_Delete.m_BtnID1 = 4;
			this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
			this.btn_Delete.transition = Selectable.Transition.None;
			this.Tmp1 = this.GameT.GetChild(4);
			this.btn_Collect = this.Tmp1.GetComponent<UIButton>();
			this.btn_Collect.m_Handler = this;
			this.btn_Collect.m_BtnID1 = 5;
			this.btn_Collect.m_EffectType = e_EffectType.e_Scale;
			this.btn_Collect.transition = Selectable.Transition.None;
			float x = this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x;
			this.tempL = (this.GUIM.m_UICanvas.transform.GetComponent<RectTransform>().sizeDelta.x - 853f) / 2f;
			this.PreviousT = this.GameT.GetChild(5);
			this.btn_Previous = this.PreviousT.GetComponent<UIButton>();
			this.btn_Previous.m_Handler = this;
			this.btn_Previous.m_BtnID1 = 1;
			this.btn_Previous.m_EffectType = e_EffectType.e_Scale;
			this.btn_Previous.transition = Selectable.Transition.None;
			this.NextT = this.GameT.GetChild(6);
			this.btn_Next = this.NextT.GetComponent<UIButton>();
			this.btn_Next.m_Handler = this;
			this.btn_Next.m_BtnID1 = 2;
			this.btn_Next.m_EffectType = e_EffectType.e_Scale;
			this.btn_Next.transition = Selectable.Transition.None;
			if (this.tempL > 0f && this.NextT.localPosition.x + this.tempL > x / 2f)
			{
				this.tempL = x / 2f - this.NextT.localPosition.x;
			}
			this.MoveTime1 = this.NextT.localPosition.x + this.tempL;
			this.MoveTime2 = this.PreviousT.localPosition.x - this.tempL;
			if (this.GUIM.bOpenOnIPhoneX)
			{
				this.MoveTime1 -= this.GUIM.IPhoneX_DeltaX;
				this.MoveTime2 += this.GUIM.IPhoneX_DeltaX;
			}
			this.Vec3Instance.Set(this.MoveTime1, this.NextT.localPosition.y, this.NextT.localPosition.z);
			this.NextT.localPosition = this.Vec3Instance;
			this.Vec3Instance.Set(this.MoveTime2, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
			this.PreviousT.localPosition = this.Vec3Instance;
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
				if (!this.bNpcMode)
				{
					if (this.Report.Combat.CombatPointKind == POINT_KIND.PK_CITY && this.Report.Combat.Side < 4)
					{
						this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, 742f - this.SummaryRT.anchoredPosition.y);
					}
					else
					{
						this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, 365f - this.SummaryRT.anchoredPosition.y);
					}
				}
				else if (this.Report.NPCCombat.CombatPointKind == POINT_KIND.PK_CITY && this.Report.NPCCombat.Side < 4)
				{
					this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, 742f - this.SummaryRT.anchoredPosition.y);
				}
				else
				{
					this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, 365f - this.SummaryRT.anchoredPosition.y);
				}
			}
			this.DM.mSaveInfo = 0;
			if (this.DM.BossOpen_Y != 0f && (this.mOpenKind == 1 || this.bNpcMode))
			{
				this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, this.DM.BossOpen_Y);
			}
			this.DM.BossOpen_Y = 0f;
			this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
			if (this.DM.mFs_Serial == this.Favor.Serial && this.DM.LetterFs_Y > -1f)
			{
				this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, this.DM.LetterFs_Y);
			}
			else
			{
				this.DM.LetterFs_Y = -1f;
			}
			return;
		}
		this.door.CloseMenu(false);
	}

	// Token: 0x06001B1A RID: 6938 RVA: 0x002EDD00 File Offset: 0x002EBF00
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
		this.btn_Coordinate[0].m_Handler = this;
		this.btn_Coordinate[0].m_BtnID1 = 8;
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
		this.btn_Coordinate[1].m_Handler = this;
		this.btn_Coordinate[1].m_BtnID1 = 9;
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
		this.Tmp2 = this.Tmp1.GetChild(16);
		this.Img_NpcMainHero[0] = this.Tmp2.GetComponent<Image>();
		this.Img_NpcMainHero[1] = this.Tmp2.GetChild(0).GetChild(0).GetComponent<Image>();
		this.Img_NpcMainHero[1].material = this.IconMaterial;
		this.tmpRC = this.Tmp2.GetChild(0).GetChild(0).GetComponent<RectTransform>();
		this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
		this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		this.Img_NpcMainHero[2] = this.Tmp2.GetChild(0).GetChild(1).GetComponent<Image>();
		this.Img_NpcMainHero[2].sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, 11);
		this.Img_NpcMainHero[2].material = this.FrameMaterial;
		this.tmpRC = this.Tmp2.GetChild(0).GetChild(1).GetComponent<RectTransform>();
		this.tmpRC.anchorMin = Vector2.zero;
		this.tmpRC.anchorMax = new Vector2(1f, 1f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		this.btn_NpcCoordinate = this.Tmp2.GetChild(1).GetComponent<UIButton>();
		this.btn_NpcCoordinate.m_Handler = this;
		this.btn_NpcCoordinate.m_BtnID1 = 13;
		this.text_NpcCoordinate = this.Tmp2.GetChild(1).GetChild(1).GetComponent<UIText>();
		this.text_NpcCoordinate.font = this.TTFont;
		this.text_NpcName = this.Tmp2.GetChild(2).GetComponent<UIText>();
		this.text_NpcName.font = this.TTFont;
		this.text_NpcName.fontSize = 30;
		this.text_NpcName.resizeTextMaxSize = 30;
		this.text_NpcName.rectTransform.anchoredPosition = new Vector2(this.text_NpcName.rectTransform.anchoredPosition.x, -143.5f);
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
		this.btn_LF.m_BtnID1 = 12;
		this.tmpbtnHint = this.btn_LF.gameObject.AddComponent<UIButtonHint>();
		this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
		this.tmpbtnHint.m_Handler = this;
		this.tmpbtnHint.DelayTime = 0.3f;
		this.tmpbtnHint.ControlFadeOut = this.Img_FormationHint.gameObject;
		this.Tmp = this.Tmp2.GetChild(0).GetChild(10).GetChild(0);
		this.Img_LF = this.Tmp.GetComponent<Image>();
		this.text_LF = this.Tmp2.GetChild(0).GetChild(10).GetChild(1).GetComponent<UIText>();
		this.text_LF.font = this.TTFont;
		this.Tmp = this.Tmp2.GetChild(0).GetChild(11);
		this.text_NpcInfo = this.Tmp.GetComponent<UIText>();
		this.text_NpcInfo.font = this.TTFont;
		this.text_NpcInfo.text = this.DM.mStringTable.GetStringByID(9594u);
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
		this.btn_RF.m_BtnID1 = 12;
		this.tmpbtnHint = this.btn_RF.gameObject.AddComponent<UIButtonHint>();
		this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
		this.tmpbtnHint.DelayTime = 0.3f;
		this.tmpbtnHint.m_Handler = this;
		this.tmpbtnHint.ControlFadeOut = this.Img_FormationHint.gameObject;
		this.Tmp = this.Tmp2.GetChild(0).GetChild(18).GetChild(0);
		this.Img_RF = this.Tmp.GetComponent<Image>();
		this.text_RF = this.Tmp2.GetChild(0).GetChild(18).GetChild(1).GetComponent<UIText>();
		this.text_RF.font = this.TTFont;
		UIButtonHint.scrollRect = this.m_Mask;
		this.tmpH -= 498f;
		this.Tmp2 = this.Tmp1.GetChild(14);
		this.Img_CWall_P[0] = this.Tmp2.GetComponent<Image>();
		this.Img_CWall[0] = this.Tmp2.GetChild(0).GetComponent<Image>();
		this.text_tmpStr[17] = this.Tmp2.GetChild(1).GetComponent<UIText>();
		this.text_tmpStr[17].font = this.TTFont;
		this.text_tmpStr[17].text = this.DM.mStringTable.GetStringByID(5333u);
		this.text_tmpStr[18] = this.Tmp2.GetChild(2).GetComponent<UIText>();
		this.text_tmpStr[18].font = this.TTFont;
		this.text_tmpStr[18].text = this.DM.mStringTable.GetStringByID(5334u);
		this.Tmp2 = this.Tmp1.GetChild(15);
		this.Img_CWall_P[1] = this.Tmp2.GetComponent<Image>();
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
		this.btn_Details.m_BtnID1 = 7;
		this.btn_Details.SoundIndex = 64;
		this.btn_Details.m_EffectType = e_EffectType.e_Scale;
		this.btn_Details.transition = Selectable.Transition.None;
		this.text_tmpStr[23] = this.Tmp2.GetChild(0).GetComponent<UIText>();
		this.text_tmpStr[23].font = this.TTFont;
		this.text_tmpStr[23].text = this.DM.mStringTable.GetStringByID(5396u);
		this.tmpH -= 281f;
		this.Tmp2 = this.Tmp1.GetChild(17);
		this.PetSkillRT_L = this.Tmp2.GetComponent<RectTransform>();
		Transform child = this.Tmp2.GetChild(0);
		this.Img_Bf_BG_L[0] = child.GetComponent<Image>();
		child = this.Tmp2.GetChild(1);
		this.Img_Bf_BG_L[1] = child.GetComponent<Image>();
		child = this.Tmp2.GetChild(1).GetChild(0);
		this.Img_Bf_BG_L[2] = child.GetComponent<Image>();
		for (int l = 0; l < 2; l++)
		{
			child = this.Tmp2.GetChild(0).GetChild(l);
			this.PetSkill_BfIcon_RT_L[l] = child.GetComponent<RectTransform>();
			for (int m = 0; m < 5; m++)
			{
				child = this.Tmp2.GetChild(0).GetChild(l).GetChild(m);
				this.btn_PetSkill_L[l * 5 + m] = child.GetComponent<UIButton>();
				this.btn_PetSkill_L[l * 5 + m].m_BtnID1 = 15;
				this.btn_PetSkill_L[l * 5 + m].m_BtnID2 = l * 5 + m;
				this.btn_PetSkill_L[l * 5 + m].m_Handler = this;
				this.tmpbtnHint = this.btn_PetSkill_L[l * 5 + m].gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.Parm1 = 3;
				child = this.Tmp2.GetChild(0).GetChild(l).GetChild(m).GetChild(0);
				this.Img_PetSkill_L[l * 5 + m] = child.GetComponent<Image>();
				this.Img_PetSkill_L[l * 5 + m].material = this.GUIM.GetSkillMaterial();
				child = this.Tmp2.GetChild(0).GetChild(l).GetChild(m).GetChild(1);
				this.tmpImg = child.GetComponent<Image>();
				this.tmpImg.sprite = this.GUIM.LoadFrameSprite("sk");
				this.tmpImg.material = this.GUIM.GetFrameMaterial();
			}
		}
		for (int n = 0; n < 2; n++)
		{
			child = this.Tmp2.GetChild(1).GetChild(1 + n);
			this.DeBuff_BfIcon_RT_L[n] = child.GetComponent<RectTransform>();
			for (int num3 = 0; num3 < 5; num3++)
			{
				child = this.Tmp2.GetChild(1).GetChild(1 + n).GetChild(num3);
				this.btn_DeBuff_L[n * 5 + num3] = child.GetComponent<UIButton>();
				this.btn_DeBuff_L[n * 5 + num3].m_BtnID1 = 15;
				this.btn_DeBuff_L[n * 5 + num3].m_BtnID2 = n * 5 + num3 + 10;
				this.btn_DeBuff_L[n * 5 + num3].m_Handler = this;
				this.tmpbtnHint = this.btn_DeBuff_L[n * 5 + num3].gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.Parm1 = 3;
				child = this.Tmp2.GetChild(1).GetChild(1 + n).GetChild(num3).GetChild(0);
				this.Img_DeBuff_L[n * 5 + num3] = child.GetComponent<Image>();
				this.Img_DeBuff_L[n * 5 + num3].material = this.GUIM.GetSkillMaterial();
				child = this.Tmp2.GetChild(1).GetChild(1 + n).GetChild(num3).GetChild(1);
				this.tmpImg = child.GetComponent<Image>();
				this.tmpImg.sprite = this.GUIM.LoadFrameSprite("sk");
				this.tmpImg.material = this.GUIM.GetFrameMaterial();
			}
		}
		this.text_Buff[0] = this.Tmp2.GetChild(1).GetChild(3).GetComponent<UIText>();
		this.text_Buff[0].font = this.TTFont;
		this.text_Buff[0].text = this.DM.mStringTable.GetStringByID(12553u);
		this.text_Buff[1] = this.Tmp2.GetChild(1).GetChild(4).GetComponent<UIText>();
		this.text_Buff[1].font = this.TTFont;
		this.text_Buff[1].text = this.DM.mStringTable.GetStringByID(5334u);
		this.text_Buff[2] = this.Tmp2.GetChild(2).GetComponent<UIText>();
		this.text_Buff[2].font = this.TTFont;
		this.text_Buff[2].text = this.DM.mStringTable.GetStringByID(10118u);
		this.text_Buff[3] = this.Tmp2.GetChild(3).GetComponent<UIText>();
		this.text_Buff[3].font = this.TTFont;
		this.text_Buff[3].text = this.DM.mStringTable.GetStringByID(5334u);
		this.Tmp2 = this.Tmp1.GetChild(18);
		this.PetSkillRT_R = this.Tmp2.GetComponent<RectTransform>();
		child = this.Tmp2.GetChild(0);
		this.Img_Bf_BG_R[0] = child.GetComponent<Image>();
		child = this.Tmp2.GetChild(1);
		this.Img_Bf_BG_R[1] = child.GetComponent<Image>();
		child = this.Tmp2.GetChild(1).GetChild(0);
		this.Img_Bf_BG_R[2] = child.GetComponent<Image>();
		for (int num4 = 0; num4 < 2; num4++)
		{
			child = this.Tmp2.GetChild(0).GetChild(num4);
			this.PetSkill_BfIcon_RT_R[num4] = child.GetComponent<RectTransform>();
			for (int num5 = 0; num5 < 5; num5++)
			{
				child = this.Tmp2.GetChild(0).GetChild(num4).GetChild(num5);
				this.btn_PetSkill_R[num4 * 5 + num5] = child.GetComponent<UIButton>();
				this.btn_PetSkill_R[num4 * 5 + num5].m_BtnID1 = 16;
				this.btn_PetSkill_R[num4 * 5 + num5].m_BtnID2 = num4 * 5 + num5;
				this.btn_PetSkill_R[num4 * 5 + num5].m_Handler = this;
				this.tmpbtnHint = this.btn_PetSkill_R[num4 * 5 + num5].gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.Parm1 = 4;
				child = this.Tmp2.GetChild(0).GetChild(num4).GetChild(num5).GetChild(0);
				this.Img_PetSkill_R[num4 * 5 + num5] = child.GetComponent<Image>();
				this.Img_PetSkill_R[num4 * 5 + num5].material = this.GUIM.GetSkillMaterial();
				child = this.Tmp2.GetChild(0).GetChild(num4).GetChild(num5).GetChild(1);
				this.tmpImg = child.GetComponent<Image>();
				this.tmpImg.sprite = this.GUIM.LoadFrameSprite("sk");
				this.tmpImg.material = this.GUIM.GetFrameMaterial();
			}
		}
		for (int num6 = 0; num6 < 2; num6++)
		{
			child = this.Tmp2.GetChild(1).GetChild(1 + num6);
			this.DeBuff_BfIcon_RT_R[num6] = child.GetComponent<RectTransform>();
			for (int num7 = 0; num7 < 5; num7++)
			{
				child = this.Tmp2.GetChild(1).GetChild(1 + num6).GetChild(num7);
				this.btn_DeBuff_R[num6 * 5 + num7] = child.GetComponent<UIButton>();
				this.btn_DeBuff_R[num6 * 5 + num7].m_BtnID1 = 16;
				this.btn_DeBuff_R[num6 * 5 + num7].m_BtnID2 = num6 * 5 + num7 + 10;
				this.btn_DeBuff_R[num6 * 5 + num7].m_Handler = this;
				this.tmpbtnHint = this.btn_DeBuff_R[num6 * 5 + num7].gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.Parm1 = 4;
				child = this.Tmp2.GetChild(1).GetChild(1 + num6).GetChild(num7).GetChild(0);
				this.Img_DeBuff_R[num6 * 5 + num7] = child.GetComponent<Image>();
				this.Img_DeBuff_R[num6 * 5 + num7].material = this.GUIM.GetSkillMaterial();
				child = this.Tmp2.GetChild(1).GetChild(1 + num6).GetChild(num7).GetChild(1);
				this.tmpImg = child.GetComponent<Image>();
				this.tmpImg.sprite = this.GUIM.LoadFrameSprite("sk");
				this.tmpImg.material = this.GUIM.GetFrameMaterial();
			}
		}
		this.text_Buff[4] = this.Tmp2.GetChild(1).GetChild(3).GetComponent<UIText>();
		this.text_Buff[4].font = this.TTFont;
		this.text_Buff[4].text = this.DM.mStringTable.GetStringByID(12553u);
		this.text_Buff[5] = this.Tmp2.GetChild(1).GetChild(4).GetComponent<UIText>();
		this.text_Buff[5].font = this.TTFont;
		this.text_Buff[5].text = this.DM.mStringTable.GetStringByID(5334u);
		this.text_Buff[6] = this.Tmp2.GetChild(2).GetComponent<UIText>();
		this.text_Buff[6].font = this.TTFont;
		this.text_Buff[6].text = this.DM.mStringTable.GetStringByID(10118u);
		this.text_Buff[7] = this.Tmp2.GetChild(3).GetComponent<UIText>();
		this.text_Buff[7].font = this.TTFont;
		this.text_Buff[7].text = this.DM.mStringTable.GetStringByID(5334u);
		this.text_Buff[8] = this.Tmp2.GetChild(4).GetComponent<UIText>();
		this.text_Buff[8].font = this.TTFont;
		this.text_Buff[8].text = this.DM.mStringTable.GetStringByID(10100u);
		this.Tmp1 = this.Mask_T.GetChild(0).GetChild(5);
		this.QuanmieRT = this.Tmp1.GetComponent<RectTransform>();
		this.QuanmieRT.anchoredPosition = new Vector2(this.QuanmieRT.anchoredPosition.x, this.tmpH);
		this.Img_Quanmie = this.Tmp1.GetChild(0).GetComponent<Image>();
		for (int num8 = 0; num8 < 8; num8++)
		{
			this.text_Quanmie[num8] = this.Tmp1.GetChild(0).GetChild(num8).GetComponent<UIText>();
			this.text_Quanmie[num8].font = this.TTFont;
		}
		this.text_Quanmie[0].text = this.DM.mStringTable.GetStringByID(5323u);
		this.text_QuanmierNpcInfo = this.Tmp1.GetChild(0).GetChild(8).GetComponent<UIText>();
		this.text_QuanmierNpcInfo.font = this.TTFont;
		this.text_QuanmierNpcInfo.text = this.DM.mStringTable.GetStringByID(9594u);
		this.text_QuanmierNpcTroops[0] = this.Tmp1.GetChild(0).GetChild(9).GetComponent<UIText>();
		this.text_QuanmierNpcTroops[0].font = this.TTFont;
		this.text_QuanmierNpcTroops[0].text = this.DM.mStringTable.GetStringByID(9643u);
		this.text_QuanmierNpcTroops[1] = this.Tmp1.GetChild(0).GetChild(10).GetComponent<UIText>();
		this.text_QuanmierNpcTroops[1].font = this.TTFont;
		for (int num9 = 0; num9 < 4; num9++)
		{
			this.Cstr_Quanmie[num9].ClearString();
		}
		if (this.IsAttack)
		{
			if (!this.bNpcMode)
			{
				this.Cstr_Quanmie[0].uLongToFormat(this.Report.Combat.Summary.AssaultLosePower, 1, true);
				StringManager.IntToStr(this.Cstr_Quanmie[1], (long)((ulong)this.Report.Combat.Summary.AssaultTroopForce), 1, true);
				this.text_Quanmie[5].text = this.Cstr_Quanmie[1].ToString();
				StringManager.IntToStr(this.Cstr_Quanmie[2], (long)((ulong)this.Report.Combat.Summary.AssaultTroopInjure), 1, true);
				this.text_Quanmie[6].text = this.Cstr_Quanmie[2].ToString();
				StringManager.IntToStr(this.Cstr_Quanmie[3], (long)((ulong)this.Report.Combat.Summary.AssaultTroopDeath), 1, true);
				this.text_Quanmie[7].text = this.Cstr_Quanmie[3].ToString();
			}
			else
			{
				this.Cstr_Quanmie[0].uLongToFormat(this.Report.NPCCombat.SummaryHead.AssaultLosePower, 1, true);
				StringManager.IntToStr(this.Cstr_Quanmie[1], (long)((ulong)this.Report.NPCCombat.SummaryHead.AssaultTroopForce), 1, true);
				this.text_Quanmie[5].text = this.Cstr_Quanmie[1].ToString();
				StringManager.IntToStr(this.Cstr_Quanmie[2], (long)((ulong)this.Report.NPCCombat.SummaryHead.AssaultTroopInjure), 1, true);
				this.text_Quanmie[6].text = this.Cstr_Quanmie[2].ToString();
				StringManager.IntToStr(this.Cstr_Quanmie[3], (long)((ulong)this.Report.NPCCombat.SummaryHead.AssaultTroopDeath), 1, true);
				this.text_Quanmie[7].text = this.Cstr_Quanmie[3].ToString();
			}
		}
		else if (!this.bNpcMode)
		{
			this.Cstr_Quanmie[0].uLongToFormat(this.Report.Combat.Summary.DefenceLosePower, 1, true);
			StringManager.IntToStr(this.Cstr_Quanmie[1], (long)((ulong)this.Report.Combat.Summary.DefenceTroopForce), 1, true);
			this.text_Quanmie[5].text = this.Cstr_Quanmie[1].ToString();
			StringManager.IntToStr(this.Cstr_Quanmie[2], (long)((ulong)this.Report.Combat.Summary.DefenceTroopInjure), 1, true);
			this.text_Quanmie[6].text = this.Cstr_Quanmie[2].ToString();
			StringManager.IntToStr(this.Cstr_Quanmie[3], (long)((ulong)this.Report.Combat.Summary.DefenceTroopDeath), 1, true);
			this.text_Quanmie[7].text = this.Cstr_Quanmie[3].ToString();
		}
		this.Cstr_Quanmie[0].AppendFormat(this.DM.mStringTable.GetStringByID(5322u));
		this.text_Quanmie[1].text = this.Cstr_Quanmie[0].ToString();
		this.text_Quanmie[2].text = this.DM.mStringTable.GetStringByID(5325u);
		this.text_Quanmie[3].text = this.DM.mStringTable.GetStringByID(5326u);
		this.text_Quanmie[4].text = this.DM.mStringTable.GetStringByID(5327u);
		for (int num10 = 0; num10 < 2; num10++)
		{
			this.Failure_Buff_RT[num10] = this.Tmp1.GetChild(num10 + 1).GetComponent<RectTransform>();
		}
		for (int num11 = 0; num11 < 2; num11++)
		{
			this.Failure_Skill_RT[num11] = this.Tmp1.GetChild(1).GetChild(num11).GetComponent<RectTransform>();
			for (int num12 = 0; num12 < 5; num12++)
			{
				this.btn_Failure_Skill[num11 * 5 + num12] = this.Tmp1.GetChild(1).GetChild(num11).GetChild(num12).GetComponent<UIButton>();
				this.btn_Failure_Skill[num11 * 5 + num12].m_BtnID1 = 17;
				this.btn_Failure_Skill[num11 * 5 + num12].m_BtnID2 = num11 * 5 + num12;
				this.btn_Failure_Skill[num11 * 5 + num12].m_Handler = this;
				this.tmpbtnHint = this.btn_Failure_Skill[num11 * 5 + num12].gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.Parm1 = 5;
				child = this.Tmp1.GetChild(1).GetChild(num11).GetChild(num12).GetChild(0);
				this.Img_Failure_Skill[num11 * 5 + num12] = child.GetComponent<Image>();
				this.Img_Failure_Skill[num11 * 5 + num12].material = this.GUIM.GetSkillMaterial();
				child = this.Tmp1.GetChild(1).GetChild(num11).GetChild(num12).GetChild(1);
				this.tmpImg = child.GetComponent<Image>();
				this.tmpImg.sprite = this.GUIM.LoadFrameSprite("sk");
				this.tmpImg.material = this.GUIM.GetFrameMaterial();
			}
			this.text_FailureBuff[num11] = this.Tmp1.GetChild(1).GetChild(2 + num11).GetComponent<UIText>();
			this.text_FailureBuff[num11].font = this.TTFont;
		}
		this.text_FailureBuff[1].text = this.DM.mStringTable.GetStringByID(10118u);
		for (int num13 = 0; num13 < 2; num13++)
		{
			this.Failure_DeBuff_RT[num13] = this.Tmp1.GetChild(2).GetChild(num13).GetComponent<RectTransform>();
			for (int num14 = 0; num14 < 5; num14++)
			{
				this.btn_Failure_DeBuff[num13 * 5 + num14] = this.Tmp1.GetChild(2).GetChild(num13).GetChild(num14).GetComponent<UIButton>();
				this.btn_Failure_DeBuff[num13 * 5 + num14].m_BtnID1 = 17;
				this.btn_Failure_DeBuff[num13 * 5 + num14].m_BtnID2 = num13 * 5 + num14 + 10;
				this.btn_Failure_DeBuff[num13 * 5 + num14].m_Handler = this;
				this.tmpbtnHint = this.btn_Failure_DeBuff[num13 * 5 + num14].gameObject.AddComponent<UIButtonHint>();
				this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
				this.tmpbtnHint.m_Handler = this;
				this.tmpbtnHint.Parm1 = 5;
				child = this.Tmp1.GetChild(2).GetChild(num13).GetChild(num14).GetChild(0);
				this.Img_Failure_DeBuff[num13 * 5 + num14] = child.GetComponent<Image>();
				this.Img_Failure_DeBuff[num13 * 5 + num14].material = this.GUIM.GetSkillMaterial();
				child = this.Tmp1.GetChild(2).GetChild(num13).GetChild(num14).GetChild(1);
				this.tmpImg = child.GetComponent<Image>();
				this.tmpImg.sprite = this.GUIM.LoadFrameSprite("sk");
				this.tmpImg.material = this.GUIM.GetFrameMaterial();
			}
		}
		this.text_FailureBuff[2] = this.Tmp1.GetChild(2).GetChild(2).GetComponent<UIText>();
		this.text_FailureBuff[2].font = this.TTFont;
		this.text_FailureBuff[2].text = this.DM.mStringTable.GetStringByID(12553u);
		this.text_FightingKind = this.Tmp1.GetChild(3).GetComponent<UIText>();
		this.text_FightingKind.font = this.TTFont;
		this.text_FightingKind.text = this.DM.mStringTable.GetStringByID(5385u);
		this.SetPorfileBtn();
	}

	// Token: 0x06001B1B RID: 6939 RVA: 0x002F0A2C File Offset: 0x002EEC2C
	public void InitBossComponent()
	{
		UIButtonHint.scrollRect = this.m_Mask;
		this.Tmp1 = this.Mask_T.GetChild(0).GetChild(6);
		this.BossRT = this.Tmp1.GetComponent<RectTransform>();
		this.Tmp2 = this.Tmp1.GetChild(0).GetChild(0);
		this.text_BossTitle[0] = this.Tmp2.GetComponent<UIText>();
		this.text_BossTitle[0].font = this.TTFont;
		this.text_BossTitle[0].text = this.DM.mStringTable.GetStringByID(8229u);
		this.Tmp2 = this.Tmp1.GetChild(1).GetChild(0);
		this.text_BossTitle[1] = this.Tmp2.GetComponent<UIText>();
		this.text_BossTitle[1].font = this.TTFont;
		this.Tmp2 = this.Tmp1.GetChild(2).GetChild(1);
		this.btn_Boss_Hero = this.Tmp2.GetComponent<UIHIBtn>();
		this.GUIM.InitianHeroItemImg(this.btn_Boss_Hero.transform, eHeroOrItem.Hero, 1, 11, 0, 0, true, true, true, false);
		this.Tmp2 = this.Tmp1.GetChild(2).GetChild(2);
		this.Img_BossHeroCrown[0] = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(2).GetChild(2).GetChild(0);
		this.Img_BossHeroCrown[1] = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(2).GetChild(3);
		this.text_BossL[0] = this.Tmp2.GetComponent<UIText>();
		this.text_BossL[0].font = this.TTFont;
		this.Tmp2 = this.Tmp1.GetChild(2).GetChild(4);
		this.text_BossL[1] = this.Tmp2.GetComponent<UIText>();
		this.text_BossL[1].font = this.TTFont;
		this.BossIconT = this.Tmp1.GetChild(3).GetChild(1);
		this.BossIconT.gameObject.SetActive(true);
		this.Img_BossIcon[0] = this.BossIconT.GetChild(0).GetComponent<Image>();
		this.Img_BossIcon[0].material = this.FrameMaterial;
		this.tmpRC = this.BossIconT.GetChild(0).GetComponent<RectTransform>();
		this.tmpRC.anchorMin = new Vector2(0.0703125f, 0.0703125f);
		this.tmpRC.anchorMax = new Vector2(0.9296875f, 0.9296875f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		this.Img_BossIcon[1] = this.BossIconT.GetChild(1).GetComponent<Image>();
		this.Img_BossIcon[1].sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, 11);
		this.Img_BossIcon[1].material = this.FrameMaterial;
		this.tmpRC = this.BossIconT.GetChild(1).GetComponent<RectTransform>();
		this.tmpRC.anchorMin = Vector2.zero;
		this.tmpRC.anchorMax = new Vector2(1f, 1f);
		this.tmpRC.offsetMin = Vector2.zero;
		this.tmpRC.offsetMax = Vector2.zero;
		this.Tmp2 = this.Tmp1.GetChild(3).GetChild(2).GetChild(0);
		this.text_BossR[0] = this.Tmp2.GetComponent<UIText>();
		this.text_BossR[0].font = this.TTFont;
		this.Tmp2 = this.Tmp1.GetChild(3).GetChild(3).GetChild(0);
		this.BossBloodRT = this.Tmp2.GetComponent<RectTransform>();
		this.Tmp2 = this.Tmp1.GetChild(3).GetChild(3).GetChild(1);
		this.text_BossR[1] = this.Tmp2.GetComponent<UIText>();
		this.text_BossR[1].font = this.TTFont;
		this.Tmp2 = this.Tmp1.GetChild(3).GetChild(4);
		this.text_BossR[2] = this.Tmp2.GetComponent<UIText>();
		this.text_BossR[2].font = this.TTFont;
		this.LightBossT = this.Tmp1.GetChild(4);
		this.Tmp2 = this.Tmp1.GetChild(5).GetChild(0);
		this.Img_BossVs = this.Tmp2.GetComponent<Image>();
		if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
		{
			this.tmpImg = this.Tmp1.GetChild(5).GetComponent<Image>();
			this.tmpImg.sprite = this.SArray.m_Sprites[17];
			this.Img_BossVs.sprite = this.SArray.m_Sprites[18];
		}
		if (this.GUIM.IsArabic)
		{
			this.tmpImg = this.Tmp1.GetChild(5).GetComponent<Image>();
			this.tmpImg.rectTransform.localScale = new Vector3(-this.tmpImg.rectTransform.localScale.x, this.tmpImg.rectTransform.localScale.y, this.tmpImg.rectTransform.localScale.z);
		}
		this.Tmp2 = this.Tmp1.GetChild(6).GetChild(0);
		this.text_tmpStr[24] = this.Tmp2.GetComponent<UIText>();
		this.text_tmpStr[24].font = this.TTFont;
		this.text_tmpStr[24].text = this.DM.mStringTable.GetStringByID(8227u);
		this.Tmp2 = this.Tmp1.GetChild(7).GetChild(0);
		this.text_BossFight[0] = this.Tmp2.GetComponent<UIText>();
		this.text_BossFight[0].font = this.TTFont;
		this.text_BossFight[0].text = this.DM.mStringTable.GetStringByID(8222u);
		this.Tmp2 = this.Tmp1.GetChild(7).GetChild(1);
		this.text_BossFight[1] = this.Tmp2.GetComponent<UIText>();
		this.text_BossFight[1].font = this.TTFont;
		this.Tmp2 = this.Tmp1.GetChild(7).GetChild(2);
		this.text_BossFight[2] = this.Tmp2.GetComponent<UIText>();
		this.text_BossFight[2].font = this.TTFont;
	}

	// Token: 0x06001B1C RID: 6940 RVA: 0x002F10E4 File Offset: 0x002EF2E4
	public override void OnClose()
	{
		if (this.Cstr_TitleName != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_TitleName);
		}
		if (this.Cstr_Page != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Page);
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
		for (int num = 0; num < 5; num++)
		{
			if (this.Cstr_Resources[num] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Resources[num]);
			}
			if (this.StrResources[num] != null)
			{
				StringManager.Instance.DeSpawnString(this.StrResources[num]);
			}
			if (this.Cstr_HeroExp[num] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_HeroExp[num]);
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
		if (this.bSaveY)
		{
			this.DM.LetterFs_Y = this.ContentRT.anchoredPosition.y;
			this.DM.mFs_Serial = this.Favor.Serial;
		}
		else
		{
			this.DM.LetterFs_Y = -1f;
		}
	}

	// Token: 0x06001B1D RID: 6941 RVA: 0x002F1598 File Offset: 0x002EF798
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
			this.Open_NP_Mail(false);
			break;
		case 2:
			this.Open_NP_Mail(true);
			break;
		case 3:
			if (this.mOpenKind == 0)
			{
				if (!this.bNpcMode)
				{
					if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
					{
						this.door.GoToPointCode(this.Report.Combat.KingdomID, this.Report.Combat.CombatlZone, this.Report.Combat.CombatPoint, 0);
					}
					else
					{
						this.door.GoToWonder(this.Report.Combat.KingdomID, this.Report.Combat.CombatPoint);
					}
				}
				else if (this.Report.NPCCombat.CombatPointKind != POINT_KIND.PK_YOLK)
				{
					this.door.GoToPointCode(this.Report.NPCCombat.KingdomID, this.Report.NPCCombat.CombatlZone, this.Report.NPCCombat.CombatPoint, 0);
				}
				else
				{
					this.door.GoToWonder(this.Report.NPCCombat.KingdomID, this.Report.NPCCombat.CombatPoint);
				}
			}
			else
			{
				this.door.GoToPointCode(this.Report.Monster.KindgomID, this.Report.Monster.Zone, this.Report.Monster.Point, 0);
			}
			break;
		case 4:
			if (this.DM.BattleReportDelete(this.Report.SerialID))
			{
				this.door.CloseMenu(false);
			}
			break;
		case 5:
			if (this.Favor.Kind == MailType.EMAIL_FAVORY)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(6100u), 255, true);
				return;
			}
			this.DM.BattleReportSave(this.Report.SerialID);
			break;
		case 6:
			if (this.bQuanmier)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5385u), 255, true);
				return;
			}
			if (this.mOpenKind == 0)
			{
				if ((!this.bNpcMode && !WarManager.CheckVersion(this.Report.Combat.Version, this.Report.Combat.PatchNo, true)) || (this.bNpcMode && !WarManager.CheckVersion(this.Report.NPCCombat.Version, this.Report.NPCCombat.PatchNo, true)))
				{
					return;
				}
				if (!this.bNpcMode)
				{
					this.GUIM.bClearWindowStack = false;
					this.DM.bWarAttacker = this.IsAttack;
					this.DM.KindomID_War[0] = this.Report.Combat.AssaultKingdomID;
					this.DM.KindomID_War[1] = this.Report.Combat.DefenceKingdomID;
					this.DM.PlayerName_War[0].ClearString();
					this.DM.PlayerName_War[0].Append(this.Report.Combat.AssaultName);
					this.DM.PlayerName_War[1].ClearString();
					this.DM.PlayerName_War[1].Append(this.Report.Combat.DefenceName);
					this.DM.AllianceTag_War[0].ClearString();
					this.DM.AllianceTag_War[0].Append(this.Report.Combat.AssaultAllianceTag);
					this.DM.AllianceTag_War[1].ClearString();
					this.DM.AllianceTag_War[1].Append(this.Report.Combat.DefenceAllianceTag);
					WarManager.CurrentPointKind = this.Report.Combat.CombatPointKind;
					WarManager.UpdateLocalTimeToTheme(this.Report.Times);
					WarManager.CheckMorale(this.Report);
					this.DM.CombatReplay(this.Report.Combat.DetailAutoID, this.Report.Combat.DetailDbServerID, this.Report.Combat.AccessKey, false);
				}
				else
				{
					this.GUIM.bClearWindowStack = false;
					this.DM.bWarAttacker = this.IsAttack;
					this.DM.KindomID_War[0] = this.Report.NPCCombat.AssaultKingdomID;
					this.DM.KindomID_War[1] = this.Report.NPCCombat.KingdomID;
					this.DM.PlayerName_War[0].ClearString();
					this.DM.PlayerName_War[0].Append(this.Report.NPCCombat.AssaultName);
					this.DM.PlayerName_War[1].ClearString();
					this.DM.PlayerName_War[1].IntToFormat((long)this.Report.NPCCombat.NPCLevel, 1, false);
					this.DM.PlayerName_War[1].AppendFormat(this.DM.mStringTable.GetStringByID(12021u));
					this.DM.AllianceTag_War[0].ClearString();
					this.DM.AllianceTag_War[0].Append(this.Report.NPCCombat.AssaultAllianceTag);
					this.DM.AllianceTag_War[1].ClearString();
					WarManager.CurrentPointKind = this.Report.NPCCombat.CombatPointKind;
					WarManager.UpdateLocalTimeToTheme(this.Report.Times);
					WarManager.CheckNPCMorale(this.Report);
					this.DM.CombatReplay(this.Report.NPCCombat.DetailAutoID, this.Report.NPCCombat.DetailDbServerID, this.Report.NPCCombat.AccessKey, true);
				}
			}
			else if (this.mOpenKind == 1)
			{
				if (!WarManager.CheckVersion(this.Report.Monster.Version, this.Report.Monster.PatchNo, true))
				{
					return;
				}
				if (!this.DM.CheckMonsterResourceReady(this.Report.Monster.MonsterID))
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8350u), 255, true);
					return;
				}
				if (!this.DM.CheckHeroBattleResourceReady(HeroFightType.MonsterBattle, this.Report.Monster.HeroID))
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(8350u), 255, true);
					return;
				}
				GUIManager instance = GUIManager.Instance;
				instance.bClearWindowStack = false;
				instance.WM_RandomSeed = this.Report.Monster.RandomSeed;
				instance.WM_RandomGap = this.Report.Monster.RandomGap;
				instance.WM_HeroCount = 0;
				for (int i = 0; i < 5; i++)
				{
					instance.WM_HeroData[i].HeroID = this.Report.Monster.HeroID[i];
					if (instance.WM_HeroData[i].HeroID != 0)
					{
						GUIManager guimanager = instance;
						guimanager.WM_HeroCount += 1;
					}
				}
				for (int j = 0; j < 5; j++)
				{
					instance.WM_HeroData[j].AttrData.SkillLV1 = this.Report.Monster.HeroData[j].SkillLV1;
					instance.WM_HeroData[j].AttrData.SkillLV2 = this.Report.Monster.HeroData[j].SkillLV2;
					instance.WM_HeroData[j].AttrData.SkillLV3 = this.Report.Monster.HeroData[j].SkillLV3;
					instance.WM_HeroData[j].AttrData.SkillLV4 = this.Report.Monster.HeroData[j].SkillLV4;
					instance.WM_HeroData[j].AttrData.LV = this.Report.Monster.HeroData[j].LV;
					instance.WM_HeroData[j].AttrData.Star = this.Report.Monster.HeroData[j].Star;
					instance.WM_HeroData[j].AttrData.Enhance = this.Report.Monster.HeroData[j].Enhance;
					instance.WM_HeroData[j].AttrData.Equip = this.Report.Monster.HeroData[j].Equip;
				}
				instance.WM_MonsterID = this.Report.Monster.MonsterID;
				instance.WM_MonsterLv = this.Report.Monster.MonsterLv;
				instance.WM_MonsterNowHP = this.Report.Monster.BeginHPPercent;
				instance.WM_MonsterMaxHP = this.Report.Monster.MonsterMaxHP;
				instance.WM_MonsterAttr.ActionTimes = this.Report.Monster.AttrScale.ActionTimes;
				instance.WM_MonsterAttr.SequentialDamageScale = this.Report.Monster.AttrScale.SequentialDamageScale;
				instance.WM_MonsterAttr.DamageScale = this.Report.Monster.AttrScale.DamageScale;
				instance.WM_MonsterAttr.MaxHPScale = this.Report.Monster.AttrScale.MaxHPScale;
				instance.WM_MonsterAttr.HealingScale = this.Report.Monster.AttrScale.HealingScale;
				instance.WM_MonsterAttr.InitMP = this.Report.Monster.AttrScale.InitMP;
				BattleController.BattleMode = EBattleMode.Monster;
				instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MonsterBattle);
			}
			AudioManager.Instance.PlayMP3SFX(41032, 0f);
			break;
		case 7:
		{
			GUIManager.Instance.ShowUILock(EUILock.Mailing_Battle);
			MessagePacket messagePacket = new MessagePacket(1024);
			if (!this.bNpcMode)
			{
				messagePacket.Protocol = Protocol._MSG_REQUEST_COMBATDETAIL;
				messagePacket.AddSeqId();
				messagePacket.Add(this.Report.Combat.DetailAutoID);
				messagePacket.Add(this.Report.Combat.DetailDbServerID);
				messagePacket.Add(this.Report.Combat.AccessKey);
				messagePacket.Send(false);
				this.DM.mFs_Main[0] = this.Report.Combat.Summary.AssaultLordInCombat;
				this.DM.mFs_Main[1] = this.Report.Combat.Summary.DefenceLordInCombat;
				this.DM.mFs_Side = this.Report.Combat.Side;
			}
			else
			{
				messagePacket.Protocol = Protocol._MSG_REQUEST_COMBATDETAIL_NPCCITY;
				messagePacket.AddSeqId();
				messagePacket.Add(this.Report.NPCCombat.DetailAutoID);
				messagePacket.Add(this.Report.NPCCombat.DetailDbServerID);
				messagePacket.Add(this.Report.NPCCombat.AccessKey);
				messagePacket.Send(false);
				this.DM.mFs_Main[0] = this.Report.NPCCombat.Summary.AssaultLordInCombat;
				this.DM.mFs_Main[1] = 1;
				this.DM.mFs_D_MHIdx = 0;
				this.DM.mFs_Side = this.Report.NPCCombat.Side;
			}
			this.bSaveY = true;
			this.DM.mSaveInfo = 1;
			break;
		}
		case 8:
			if (!this.bNpcMode)
			{
				this.door.GoToPointCode(this.Report.Combat.KingdomID, this.Report.Combat.Summary.AssaultCapitalZone, this.Report.Combat.Summary.AssaultCapitalPoint, 0);
			}
			else
			{
				this.door.GoToPointCode(this.Report.NPCCombat.KingdomID, this.Report.NPCCombat.SummaryHead.AssaultCapitalZone, this.Report.NPCCombat.SummaryHead.AssaultCapitalPoint, 0);
			}
			break;
		case 9:
			if (!this.bNpcMode)
			{
				if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
				{
					this.door.GoToPointCode(this.Report.Combat.KingdomID, this.Report.Combat.Summary.DefenceCapitalZone, this.Report.Combat.Summary.DefenceCapitalPoint, 0);
				}
				else
				{
					this.door.GoToWonder(this.Report.Combat.KingdomID, this.Report.Combat.CombatPoint);
				}
			}
			else if (this.Report.NPCCombat.CombatPointKind != POINT_KIND.PK_YOLK)
			{
				this.door.GoToPointCode(this.Report.NPCCombat.KingdomID, this.Report.NPCCombat.SummaryHead.DefenceCapitalZone, this.Report.NPCCombat.SummaryHead.DefenceCapitalPoint, 0);
			}
			else
			{
				this.door.GoToWonder(this.Report.NPCCombat.KingdomID, this.Report.NPCCombat.CombatPoint);
			}
			break;
		case 10:
		case 11:
			this.ShowLordProfile((FightingSummary_btn)sender.m_BtnID1);
			break;
		case 13:
			this.door.GoToPointCode(this.Report.NPCCombat.KingdomID, this.Report.NPCCombat.SummaryHead.DefenceCapitalZone, this.Report.NPCCombat.SummaryHead.DefenceCapitalPoint, 0);
			break;
		}
	}

	// Token: 0x06001B1E RID: 6942 RVA: 0x002F23F8 File Offset: 0x002F05F8
	public void OnLEButtonClick(UILEBtn sender)
	{
	}

	// Token: 0x06001B1F RID: 6943 RVA: 0x002F23FC File Offset: 0x002F05FC
	public void Open_NP_Mail(bool bNext)
	{
		if (this.DM.MailReportGet(ref this.Favor, bNext))
		{
			switch (this.Favor.Type)
			{
			case MailType.EMAIL_SYSTEM:
				this.DM.OpenMail.Serial = this.Favor.Serial;
				this.DM.OpenMail.Type = this.Favor.Type;
				this.DM.OpenMail.Kind = this.Favor.Kind;
				this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
				break;
			case MailType.EMAIL_BATTLE:
				this.DM.OpenMail.Serial = this.Favor.Serial;
				this.DM.OpenMail.Type = this.Favor.Type;
				this.DM.OpenMail.Kind = this.Favor.Kind;
				switch (this.Favor.Combat.Type)
				{
				case CombatCollectReport.CCR_BATTLE:
				case CombatCollectReport.CCR_NPCCOMBAT:
					this.m_Mask.StopMovement();
					this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, 0f);
					this.Favor.Serial = this.DM.OpenMail.Serial;
					this.Favor.Type = this.DM.OpenMail.Type;
					this.Favor.Kind = this.DM.OpenMail.Kind;
					if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
					{
						this.Report = this.Favor.Combat;
						if (!this.Report.BeRead)
						{
							if (this.Favor.Kind == MailType.EMAIL_BATTLE)
							{
								this.DM.BattleReportRead(this.Report.SerialID, true);
							}
							else
							{
								this.DM.FavorReportRead(this.Report.SerialID, true);
							}
						}
						if (this.Report.Type == CombatCollectReport.CCR_NPCCOMBAT)
						{
							this.bNpcMode = true;
						}
						else
						{
							this.bNpcMode = false;
						}
						Array.Clear(this.m_A_Skill_ID, 0, this.m_A_Skill_ID.Length);
						Array.Clear(this.m_A_Skill_LV, 0, this.m_A_Skill_LV.Length);
						Array.Clear(this.m_A_DeBf_Skill_ID, 0, this.m_A_DeBf_Skill_ID.Length);
						Array.Clear(this.m_A_DeBf_Skill_LV, 0, this.m_A_DeBf_Skill_LV.Length);
						Array.Clear(this.m_D_Skill_ID, 0, this.m_D_Skill_ID.Length);
						Array.Clear(this.m_D_Skill_LV, 0, this.m_A_Skill_ID.Length);
						Array.Clear(this.m_D_DeBf_Skill_ID, 0, this.m_D_DeBf_Skill_ID.Length);
						Array.Clear(this.m_D_DeBf_Skill_LV, 0, this.m_D_DeBf_Skill_LV.Length);
						this.mA_Skill_L = 0;
						this.mDeBf_A_L = 0;
						this.mD_Skill_R = 0;
						this.mDeBf_D_R = 0;
						if (!this.bNpcMode)
						{
							if (this.Report.Combat.Result == CombatReportResultType.ECRR_COMBATVICTORY || this.Report.Combat.Result == CombatReportResultType.ECRR_DEFENDVICTORY || this.Report.Combat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER || this.Report.Combat.Result == CombatReportResultType.ECRR_WONDERVICTORY)
							{
								this.bWin = true;
							}
							else
							{
								this.bWin = false;
							}
							this.IsAttack = (this.Report.Combat.Side == 0 || this.Report.Combat.Side == 2 || this.Report.Combat.Side == 4 || this.Report.Combat.Side == 6);
							this.mType = (int)this.Report.Combat.Result;
							if (this.mType >= 4 && this.mType <= 7)
							{
								this.bQuanmier = true;
							}
							else
							{
								this.bQuanmier = false;
							}
							this.bDoNotShow = false;
							if (this.Report.Combat.PetSkillPatchNo != this.DM.PetVersionNo)
							{
								this.bDoNotShow = true;
							}
							for (int i = 0; i < 20; i++)
							{
								if (this.Report.Combat.m_AssaultPetSkill_ID[i] > 0)
								{
									if (this.mA_Skill_L < this.m_A_Skill_ID.Length && this.PM.PetSkillTable.GetRecordByKey(this.Report.Combat.m_AssaultPetSkill_ID[i]).Subject == 1)
									{
										this.m_A_Skill_ID[this.mA_Skill_L] = this.Report.Combat.m_AssaultPetSkill_ID[i];
										this.m_A_Skill_LV[this.mA_Skill_L] = this.Report.Combat.m_AssaultPetSkill_LV[i];
										this.mA_Skill_L++;
									}
									else if (this.mDeBf_A_L < this.m_A_DeBf_Skill_ID.Length)
									{
										this.m_A_DeBf_Skill_ID[this.mDeBf_A_L] = this.Report.Combat.m_AssaultPetSkill_ID[i];
										this.m_A_DeBf_Skill_LV[this.mDeBf_A_L] = this.Report.Combat.m_AssaultPetSkill_LV[i];
										this.mDeBf_A_L++;
									}
								}
								if (this.Report.Combat.m_DefencePetSkill_ID[i] > 0)
								{
									if (this.mD_Skill_R < this.m_D_Skill_ID.Length && this.PM.PetSkillTable.GetRecordByKey(this.Report.Combat.m_AssaultPetSkill_ID[i]).Subject == 1)
									{
										this.m_D_Skill_ID[this.mD_Skill_R] = this.Report.Combat.m_DefencePetSkill_ID[i];
										this.m_D_Skill_LV[this.mD_Skill_R] = this.Report.Combat.m_DefencePetSkill_LV[i];
										this.mD_Skill_R++;
									}
									else if (this.mDeBf_D_R < this.m_D_DeBf_Skill_ID.Length)
									{
										this.m_D_DeBf_Skill_ID[this.mDeBf_D_R] = this.Report.Combat.m_DefencePetSkill_ID[i];
										this.m_D_DeBf_Skill_LV[this.mDeBf_D_R] = this.Report.Combat.m_DefencePetSkill_LV[i];
										this.mDeBf_D_R++;
									}
								}
							}
						}
						else
						{
							if (this.Report.NPCCombat.Result == CombatReportResultType.ECRR_COMBATVICTORY || this.Report.NPCCombat.Result == CombatReportResultType.ECRR_DEFENDVICTORY || this.Report.NPCCombat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER || this.Report.NPCCombat.Result == CombatReportResultType.ECRR_WONDERVICTORY)
							{
								this.bWin = true;
							}
							else
							{
								this.bWin = false;
							}
							this.IsAttack = (this.Report.NPCCombat.Side == 0 || this.Report.NPCCombat.Side == 2 || this.Report.NPCCombat.Side == 4 || this.Report.NPCCombat.Side == 6);
							this.mType = (int)this.Report.NPCCombat.Result;
							if (this.mType >= 4 && this.mType <= 7)
							{
								this.bQuanmier = true;
							}
							else
							{
								this.bQuanmier = false;
							}
							this.bDoNotShow = false;
							if (this.Report.NPCCombat.PetSkillPatchNo != this.DM.PetVersionNo)
							{
								this.bDoNotShow = true;
							}
							for (int j = 0; j < 20; j++)
							{
								if (this.Report.NPCCombat.m_AssaultPetSkill_ID[j] > 0)
								{
									if (this.mA_Skill_L < this.m_A_Skill_ID.Length && this.PM.PetSkillTable.GetRecordByKey(this.Report.NPCCombat.m_AssaultPetSkill_ID[j]).Subject == 1)
									{
										this.m_A_Skill_ID[this.mA_Skill_L] = this.Report.NPCCombat.m_AssaultPetSkill_ID[j];
										this.m_A_Skill_LV[this.mA_Skill_L] = this.Report.NPCCombat.m_AssaultPetSkill_LV[j];
										this.mA_Skill_L++;
									}
									else if (this.mDeBf_A_L < this.m_A_DeBf_Skill_ID.Length)
									{
										this.m_A_DeBf_Skill_ID[this.mDeBf_A_L] = this.Report.NPCCombat.m_AssaultPetSkill_ID[j];
										this.m_A_DeBf_Skill_LV[this.mDeBf_A_L] = this.Report.NPCCombat.m_AssaultPetSkill_LV[j];
										this.mDeBf_A_L++;
									}
								}
							}
						}
					}
					this.mOpenKind = 0;
					if (!this.bInitFS)
					{
						this.bInitFS = true;
						this.InitFSComponent();
					}
					this.DM.LetterFs_Y = -1f;
					this.SetPageData();
					break;
				case CombatCollectReport.CCR_RESOURCE:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Resources, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
					break;
				case CombatCollectReport.CCR_COLLECT:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Collection, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
					break;
				case CombatCollectReport.CCR_SCOUT:
					if (this.Favor.Combat.Scout.ScoutLevel != 0)
					{
						this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 0, 0, false);
					}
					else
					{
						this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 1, 0, false);
					}
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
					break;
				case CombatCollectReport.CCR_RECON:
					this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
					break;
				case CombatCollectReport.CCR_MONSTER:
					this.bNpcMode = false;
					if (this.Favor.Combat.Monster.Result < 2 || this.Favor.Combat.Monster.Result > 3)
					{
						this.m_Mask.StopMovement();
						this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, 0f);
						if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
						{
							this.Report = this.Favor.Combat;
							if (!this.Report.BeRead)
							{
								if (this.Favor.Kind == MailType.EMAIL_BATTLE)
								{
									this.DM.BattleReportRead(this.Report.SerialID, true);
								}
								else
								{
									this.DM.FavorReportRead(this.Report.SerialID, true);
								}
							}
						}
						this.Favor.Serial = this.DM.OpenMail.Serial;
						this.Favor.Type = this.DM.OpenMail.Type;
						this.Favor.Kind = this.DM.OpenMail.Kind;
						if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
						{
							this.Report = this.Favor.Combat;
						}
						this.mOpenKind = 1;
						this.bQuanmier = false;
						if (!this.bInitBoss)
						{
							this.bInitBoss = true;
							this.InitBossComponent();
						}
						this.SetPageData();
					}
					else
					{
						this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
						this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
					}
					break;
				case CombatCollectReport.CCR_NPCSCOUT:
					this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
					break;
				case CombatCollectReport.CCR_PETREPORT:
					this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS, 0, 0, false);
					this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
					break;
				}
				break;
			case MailType.EMAIL_LETTER:
				this.DM.OpenMail.Serial = this.Favor.Serial;
				this.DM.OpenMail.Type = this.Favor.Type;
				this.DM.OpenMail.Kind = this.Favor.Kind;
				this.door.OpenMenu(EGUIWindow.UI_LetterDetail, 0, 0, false);
				this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
				break;
			}
		}
	}

	// Token: 0x06001B20 RID: 6944 RVA: 0x002F3098 File Offset: 0x002F1298
	public void OnHIButtonClick(UIHIBtn sender)
	{
		if (this.door != null)
		{
			bool flag = false;
			Equip recordByKey = this.DM.EquipTable.GetRecordByKey((ushort)sender.m_BtnID2);
			if (recordByKey.EquipKind == 19)
			{
				flag = true;
			}
			else if (recordByKey.EquipKind == 18 && recordByKey.PropertiesInfo[0].Propertieskey == 4)
			{
				flag = true;
			}
			else if (recordByKey.EquipKind == 18 && (recordByKey.PropertiesInfo[2].Propertieskey < 1 || recordByKey.PropertiesInfo[2].Propertieskey > 3))
			{
				flag = true;
			}
			if (flag)
			{
				this.DM.BossOpen_Y = this.ContentRT.anchoredPosition.y;
				this.door.OpenMenu(EGUIWindow.UI_OpenBox, 1, sender.m_BtnID2, false);
			}
		}
	}

	// Token: 0x06001B21 RID: 6945 RVA: 0x002F318C File Offset: 0x002F138C
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		switch (uibutton.m_BtnID1)
		{
		case 12:
			sender.GetTipPosition(this.Img_FormationHint.rectTransform, UIButtonHint.ePosition.Original, null);
			this.Img_FormationHint.gameObject.SetActive(true);
			break;
		case 14:
			this.Img_NpcItemHint.gameObject.SetActive(true);
			break;
		}
		if (sender.Parm1 == 3)
		{
			if (uibutton.m_BtnID2 < 10)
			{
				this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Mail, 0, this.m_A_Skill_ID[uibutton.m_BtnID2], this.m_A_Skill_LV[uibutton.m_BtnID2], Vector2.zero, UIButtonHint.ePosition.Original);
			}
			else if (uibutton.m_BtnID2 - 10 >= 0 && uibutton.m_BtnID2 - 10 < this.m_A_DeBf_Skill_ID.Length)
			{
				this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Mail, 0, this.m_A_DeBf_Skill_ID[uibutton.m_BtnID2 - 10], this.m_A_DeBf_Skill_LV[uibutton.m_BtnID2 - 10], Vector2.zero, UIButtonHint.ePosition.Original);
			}
		}
		else if (sender.Parm1 == 4)
		{
			if (uibutton.m_BtnID2 < 10)
			{
				this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Mail, 0, this.m_D_Skill_ID[uibutton.m_BtnID2], this.m_D_Skill_LV[uibutton.m_BtnID2], Vector2.zero, UIButtonHint.ePosition.Original);
			}
			else if (uibutton.m_BtnID2 - 10 >= 0 && uibutton.m_BtnID2 - 10 < this.m_D_DeBf_Skill_ID.Length)
			{
				this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Mail, 0, this.m_D_DeBf_Skill_ID[uibutton.m_BtnID2 - 10], this.m_D_DeBf_Skill_LV[uibutton.m_BtnID2 - 10], Vector2.zero, UIButtonHint.ePosition.Original);
			}
		}
		else if (sender.Parm1 == 5)
		{
			if (this.IsAttack)
			{
				if (uibutton.m_BtnID2 < 10)
				{
					this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Mail, 0, this.m_A_Skill_ID[uibutton.m_BtnID2], this.m_A_Skill_LV[uibutton.m_BtnID2], Vector2.zero, UIButtonHint.ePosition.Original);
				}
				else if (uibutton.m_BtnID2 - 10 >= 0 && uibutton.m_BtnID2 - 10 < this.m_A_DeBf_Skill_ID.Length)
				{
					this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Mail, 0, this.m_A_DeBf_Skill_ID[uibutton.m_BtnID2 - 10], this.m_A_DeBf_Skill_LV[uibutton.m_BtnID2 - 10], Vector2.zero, UIButtonHint.ePosition.Original);
				}
			}
			else if (uibutton.m_BtnID2 < 10)
			{
				this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Normal, 0, this.m_D_Skill_ID[uibutton.m_BtnID2], this.m_D_Skill_LV[uibutton.m_BtnID2], Vector2.zero, UIButtonHint.ePosition.Original);
			}
			else if (uibutton.m_BtnID2 - 10 >= 0 && uibutton.m_BtnID2 - 10 < this.m_D_DeBf_Skill_ID.Length)
			{
				this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Normal, 0, this.m_D_DeBf_Skill_ID[uibutton.m_BtnID2 - 10], this.m_D_DeBf_Skill_LV[uibutton.m_BtnID2 - 10], Vector2.zero, UIButtonHint.ePosition.Original);
			}
		}
	}

	// Token: 0x06001B22 RID: 6946 RVA: 0x002F34D8 File Offset: 0x002F16D8
	public void OnButtonUp(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		switch (uibutton.m_BtnID1)
		{
		case 12:
			this.Img_FormationHint.gameObject.SetActive(false);
			break;
		case 14:
			this.Img_NpcItemHint.gameObject.SetActive(false);
			break;
		}
		this.GUIM.m_Hint.Hide(true);
	}

	// Token: 0x06001B23 RID: 6947 RVA: 0x002F3550 File Offset: 0x002F1750
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews != NetworkNews.Refresh_Mailing)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else
			{
				if (!this.DM.MailReportGet(ref this.Favor))
				{
					this.door.CloseMenu(false);
					return;
				}
				this.MaxLetterNum = (int)this.DM.GetMailboxSize(MailType.EMAIL_MAX);
				this.Cstr_Page.ClearString();
				switch (this.DM.OpenMail.Kind)
				{
				case MailType.EMAIL_BATTLE:
					this.Cstr_Page.IntToFormat((long)(this.Report.Index + 1), 1, false);
					this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
					break;
				case MailType.EMAIL_FAVORY:
					this.Cstr_Page.IntToFormat((long)(this.Report.Index + 1), 1, false);
					this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
					break;
				}
				if (this.GUIM.IsArabic)
				{
					this.Cstr_Page.AppendFormat("{1}/{0}");
				}
				else
				{
					this.Cstr_Page.AppendFormat("{0}/{1}");
				}
				this.text_Page.text = this.Cstr_Page.ToString();
				this.text_Page.SetAllDirty();
				this.text_Page.cachedTextGenerator.Invalidate();
				if (this.MaxLetterNum > 1)
				{
					if (this.Report.Index + 1 == 1)
					{
						this.btn_Previous.gameObject.SetActive(false);
					}
					else
					{
						this.btn_Previous.gameObject.SetActive(true);
					}
					if ((int)(this.Report.Index + 1) == this.MaxLetterNum)
					{
						this.btn_Next.gameObject.SetActive(false);
					}
					else
					{
						this.btn_Next.gameObject.SetActive(true);
					}
				}
				else
				{
					this.btn_Previous.gameObject.SetActive(false);
					this.btn_Next.gameObject.SetActive(false);
				}
			}
			break;
		case NetworkNews.Refresh_Asset:
			if (meg[1] == 0 && meg[2] == 1 && GameConstants.ConvertBytesToUShort(meg, 3) == this.mBossHead)
			{
				AssetBundle assetBundle = AssetManager.GetAssetBundle(this.Cstr_BoosHead, out this.AssetKey);
				if (assetBundle != null)
				{
					this.mHead = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
				}
				if (this.mHead != null)
				{
					this.mHead.transform.SetParent(this.Img_BossIcon[0].transform);
					this.mHead.gameObject.SetActive(true);
					this.mHead.transform.localPosition = new Vector3(0f, 0f, 0f);
					this.mHead.transform.localScale = new Vector3(1f, 1f, 1f);
				}
			}
			break;
		}
	}

	// Token: 0x06001B24 RID: 6948 RVA: 0x002F386C File Offset: 0x002F1A6C
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
		if (this.btn_Boss_Hero != null && this.btn_Boss_Hero.enabled)
		{
			this.btn_Boss_Hero.Refresh_FontTexture();
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
			if (this.text_FailureBuff[j] != null && this.text_FailureBuff[j].enabled)
			{
				this.text_FailureBuff[j].enabled = false;
				this.text_FailureBuff[j].enabled = true;
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
		for (int n = 0; n < 9; n++)
		{
			if (this.text_Buff[n] != null && this.text_Buff[n].enabled)
			{
				this.text_Buff[n].enabled = false;
				this.text_Buff[n].enabled = true;
			}
		}
		for (int num = 0; num < 25; num++)
		{
			if (this.text_tmpStr[num] != null && this.text_tmpStr[num].enabled)
			{
				this.text_tmpStr[num].enabled = false;
				this.text_tmpStr[num].enabled = true;
			}
		}
		for (int num2 = 0; num2 < 30; num2++)
		{
			if (this.text_ItemQty[num2] != null && this.text_ItemQty[num2].enabled)
			{
				this.text_ItemQty[num2].enabled = false;
				this.text_ItemQty[num2].enabled = true;
			}
			if (this.btn_Itme[num2] != null && this.btn_Itme[num2].enabled)
			{
				this.btn_Itme[num2].Refresh_FontTexture();
			}
		}
	}

	// Token: 0x06001B25 RID: 6949 RVA: 0x002F451C File Offset: 0x002F271C
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 1)
		{
			if (arg1 == 2)
			{
				if (!this.DM.MailReportGet(ref this.Favor))
				{
					this.door.CloseMenu(false);
				}
			}
		}
		else
		{
			this.door.OpenMenu(EGUIWindow.UI_FightingSummary_Info, 0, 0, false);
		}
	}

	// Token: 0x06001B26 RID: 6950 RVA: 0x002F457C File Offset: 0x002F277C
	private void Start()
	{
	}

	// Token: 0x06001B27 RID: 6951 RVA: 0x002F4580 File Offset: 0x002F2780
	public void GetTitleNameStr()
	{
		this.Cstr_TitleName.ClearString();
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		CString cstring3 = StringManager.Instance.StaticString1024();
		if (this.mOpenKind == 0)
		{
			if (!this.bNpcMode)
			{
				switch (this.Report.Combat.Side)
				{
				case 0:
					this.Cstr_TitleName.Append(this.DM.mStringTable.GetStringByID(6021u));
					cstring.ClearString();
					cstring2.ClearString();
					cstring3.ClearString();
					cstring2.Append(this.Report.Combat.DefenceName);
					if (this.Report.Combat.DefenceAllianceTag != string.Empty)
					{
						cstring3.Append(this.Report.Combat.DefenceAllianceTag);
						if (this.Report.Combat.AssaultKingdomID != this.Report.Combat.DefenceKingdomID)
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, this.Report.Combat.DefenceKingdomID, this.GUIM.IsArabic);
						}
						else
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
						}
					}
					else if (this.Report.Combat.AssaultKingdomID != this.Report.Combat.DefenceKingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, this.Report.Combat.DefenceKingdomID, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
					}
					if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
					{
						if (this.DM.UserLanguage != GameLanguage.GL_Jpn)
						{
							if (this.GUIM.IsArabic)
							{
								this.Cstr_TitleName.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Combat.CombatPointKind));
								this.Cstr_TitleName.StringToFormat(cstring);
							}
							else
							{
								this.Cstr_TitleName.StringToFormat(cstring);
								this.Cstr_TitleName.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Combat.CombatPointKind));
							}
							this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(6022u));
						}
						else
						{
							this.Cstr_TitleName.ClearString();
							this.Cstr_TitleName.StringToFormat(cstring);
							this.Cstr_TitleName.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Combat.CombatPointKind));
							this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(6022u));
							this.Cstr_TitleName.Append(this.DM.mStringTable.GetStringByID(6021u));
						}
					}
					else if (this.Report.Combat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER)
					{
						this.Cstr_TitleName.Append(DataManager.MapDataController.GetYolkName((ushort)this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
					}
					else
					{
						this.Cstr_TitleName.Append(cstring);
						this.Cstr_TitleName.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
						this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(9304u));
					}
					break;
				case 1:
					cstring.ClearString();
					cstring2.ClearString();
					cstring3.ClearString();
					cstring2.Append(this.Report.Combat.AssaultName);
					if (this.Report.Combat.AssaultAllianceTag != string.Empty)
					{
						cstring3.Append(this.Report.Combat.AssaultAllianceTag);
						if (this.Report.Combat.AssaultKingdomID != this.Report.Combat.DefenceKingdomID)
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, this.Report.Combat.AssaultKingdomID, this.GUIM.IsArabic);
						}
						else
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
						}
					}
					else if (this.Report.Combat.AssaultKingdomID != this.Report.Combat.DefenceKingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, this.Report.Combat.AssaultKingdomID, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
					}
					if (this.GUIM.IsArabic)
					{
						if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
						{
							this.Cstr_TitleName.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Combat.CombatPointKind));
						}
						else
						{
							this.Cstr_TitleName.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
						}
						this.Cstr_TitleName.StringToFormat(cstring);
					}
					else
					{
						this.Cstr_TitleName.StringToFormat(cstring);
						if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
						{
							this.Cstr_TitleName.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Combat.CombatPointKind));
						}
						else
						{
							this.Cstr_TitleName.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
						}
					}
					this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(6020u));
					break;
				case 2:
					if (this.Report.Combat.Result != CombatReportResultType.ECRR_TAKEOVERWONDER)
					{
						cstring.ClearString();
						cstring2.ClearString();
						cstring3.ClearString();
						CString cstring4 = StringManager.Instance.StaticString1024();
						CString cstring5 = StringManager.Instance.StaticString1024();
						cstring4.ClearString();
						cstring5.ClearString();
						cstring4.Append(this.DM.mStringTable.GetStringByID(6023u));
						cstring2.Append(this.Report.Combat.AssaultName);
						cstring3.Append(this.Report.Combat.AssaultAllianceTag);
						if (this.Report.Combat.AssaultKingdomID != this.Report.Combat.DefenceKingdomID)
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, this.Report.Combat.AssaultKingdomID, this.GUIM.IsArabic);
						}
						else
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
						}
						cstring4.StringToFormat(cstring);
						cstring4.AppendFormat(this.DM.mStringTable.GetStringByID(6024u));
						cstring.ClearString();
						cstring2.ClearString();
						cstring3.ClearString();
						cstring2.Append(this.Report.Combat.DefenceName);
						if (this.Report.Combat.DefenceAllianceTag != string.Empty)
						{
							cstring3.Append(this.Report.Combat.DefenceAllianceTag);
							if (this.Report.Combat.AssaultKingdomID != this.Report.Combat.DefenceKingdomID)
							{
								this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, this.Report.Combat.DefenceKingdomID, this.GUIM.IsArabic);
							}
							else
							{
								this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
							}
						}
						else if (this.Report.Combat.AssaultKingdomID != this.Report.Combat.DefenceKingdomID)
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, this.Report.Combat.DefenceKingdomID, this.GUIM.IsArabic);
						}
						else
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
						}
						if (this.GUIM.IsArabic)
						{
							if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
							{
								cstring5.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Combat.CombatPointKind));
							}
							else
							{
								cstring5.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
							}
							cstring5.StringToFormat(cstring);
						}
						else
						{
							cstring5.StringToFormat(cstring);
							if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
							{
								cstring5.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Combat.CombatPointKind));
							}
							else
							{
								cstring5.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
							}
						}
						cstring5.AppendFormat(this.DM.mStringTable.GetStringByID(6022u));
						this.Cstr_TitleName.Append(cstring4);
						this.Cstr_TitleName.Append(cstring5);
					}
					else
					{
						this.Cstr_TitleName.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
						this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(4987u));
					}
					break;
				case 3:
				{
					cstring.ClearString();
					cstring2.ClearString();
					cstring3.ClearString();
					CString cstring6 = StringManager.Instance.StaticString1024();
					CString cstring7 = StringManager.Instance.StaticString1024();
					cstring6.ClearString();
					cstring7.ClearString();
					cstring2.Append(this.Report.Combat.AssaultName);
					cstring3.Append(this.Report.Combat.AssaultAllianceTag);
					if (this.Report.Combat.AssaultKingdomID != this.Report.Combat.DefenceKingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, this.Report.Combat.AssaultKingdomID, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
					}
					cstring6.StringToFormat(cstring);
					cstring6.AppendFormat(this.DM.mStringTable.GetStringByID(6025u));
					cstring.ClearString();
					cstring2.ClearString();
					cstring3.ClearString();
					cstring2.Append(this.Report.Combat.DefenceName);
					cstring3.Append(this.Report.Combat.DefenceAllianceTag);
					if (this.Report.Combat.AssaultKingdomID != this.Report.Combat.DefenceKingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, this.Report.Combat.DefenceKingdomID, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
					}
					cstring7.StringToFormat(cstring);
					cstring7.AppendFormat(this.DM.mStringTable.GetStringByID(6026u));
					this.Cstr_TitleName.Append(cstring6);
					this.Cstr_TitleName.Append(cstring7);
					break;
				}
				case 4:
				case 6:
					cstring.ClearString();
					cstring2.ClearString();
					cstring3.ClearString();
					cstring2.Append(this.Report.Combat.DefenceName);
					if (this.Report.Combat.DefenceAllianceTag != string.Empty)
					{
						cstring3.Append(this.Report.Combat.DefenceAllianceTag);
						if (this.Report.Combat.AssaultKingdomID != this.Report.Combat.DefenceKingdomID)
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, this.Report.Combat.DefenceKingdomID, this.GUIM.IsArabic);
						}
						else
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
						}
					}
					else if (this.Report.Combat.AssaultKingdomID != this.Report.Combat.DefenceKingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, this.Report.Combat.DefenceKingdomID, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
					}
					this.Cstr_TitleName.StringToFormat(cstring);
					this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(9751u));
					break;
				case 5:
					cstring.ClearString();
					cstring2.ClearString();
					cstring3.ClearString();
					cstring2.Append(this.Report.Combat.AssaultName);
					if (this.Report.Combat.AssaultAllianceTag != string.Empty)
					{
						cstring3.Append(this.Report.Combat.AssaultAllianceTag);
						if (this.Report.Combat.AssaultKingdomID != this.Report.Combat.DefenceKingdomID)
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, this.Report.Combat.AssaultKingdomID, this.GUIM.IsArabic);
						}
						else
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
						}
					}
					else if (this.Report.Combat.AssaultKingdomID != this.Report.Combat.DefenceKingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, this.Report.Combat.DefenceKingdomID, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
					}
					this.Cstr_TitleName.StringToFormat(cstring);
					this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(9752u));
					break;
				}
			}
			else
			{
				cstring.ClearString();
				cstring2.ClearString();
				cstring3.ClearString();
				CString cstring8 = StringManager.Instance.StaticString1024();
				CString cstring9 = StringManager.Instance.StaticString1024();
				cstring8.ClearString();
				cstring9.ClearString();
				cstring8.Append(this.DM.mStringTable.GetStringByID(6023u));
				cstring2.Append(this.Report.NPCCombat.AssaultName);
				cstring3.Append(this.Report.NPCCombat.AssaultAllianceTag);
				if (this.Report.NPCCombat.AssaultKingdomID != this.Report.NPCCombat.KingdomID)
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, this.Report.NPCCombat.AssaultKingdomID, this.GUIM.IsArabic);
				}
				else
				{
					this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
				}
				cstring8.StringToFormat(cstring);
				cstring8.AppendFormat(this.DM.mStringTable.GetStringByID(6024u));
				cstring.ClearString();
				cstring2.ClearString();
				cstring3.ClearString();
				cstring2.IntToFormat((long)this.Report.NPCCombat.NPCLevel, 1, false);
				cstring2.AppendFormat(this.DM.mStringTable.GetStringByID(12021u));
				cstring9.Append(cstring);
				cstring9.Append(cstring2);
				this.Cstr_TitleName.Append(cstring8);
				this.Cstr_TitleName.Append(cstring9);
			}
		}
		else if (this.mOpenKind == 1)
		{
			if (this.Report.Monster.Result < 2)
			{
				this.Cstr_TitleName.IntToFormat((long)this.Report.Monster.MonsterLv, 1, false);
				this.Cstr_TitleName.StringToFormat(this.DM.mStringTable.GetStringByID((uint)DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.Report.Monster.MonsterID).NameID));
				if (this.Report.Monster.Result == 0)
				{
					this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(8221u));
				}
				else
				{
					this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(8223u));
				}
			}
			else
			{
				cstring.StringToFormat(this.Report.Monster.AllianceTag);
				cstring.StringToFormat(this.DM.mStringTable.GetStringByID((uint)DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.Report.Monster.MonsterID).NameID));
				cstring.AppendFormat("[{0}]{1}");
				this.Cstr_TitleName.IntToFormat((long)this.Report.Monster.MonsterLv, 1, false);
				this.Cstr_TitleName.StringToFormat(cstring);
				if (this.Report.Monster.Result == 4)
				{
					this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(8221u));
				}
				else
				{
					this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(8223u));
				}
				this.bAllianceBossMode = true;
			}
		}
	}

	// Token: 0x06001B28 RID: 6952 RVA: 0x002F5828 File Offset: 0x002F3A28
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
		this.bAllianceBossMode = false;
		this.GetTitleNameStr();
		this.text_TitleName.text = this.Cstr_TitleName.ToString();
		this.text_TitleName.SetAllDirty();
		this.text_TitleName.cachedTextGenerator.Invalidate();
		this.Cstr_Page.ClearString();
		switch (this.DM.OpenMail.Kind)
		{
		case MailType.EMAIL_BATTLE:
			this.Cstr_Page.IntToFormat((long)(this.Report.Index + 1), 1, false);
			this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
			break;
		case MailType.EMAIL_FAVORY:
			this.Cstr_Page.IntToFormat((long)(this.Report.Index + 1), 1, false);
			this.Cstr_Page.IntToFormat((long)this.MaxLetterNum, 1, false);
			break;
		}
		if (this.GUIM.IsArabic)
		{
			this.Cstr_Page.AppendFormat("{1}/{0}");
		}
		else
		{
			this.Cstr_Page.AppendFormat("{0}/{1}");
		}
		this.text_Page.text = this.Cstr_Page.ToString();
		this.text_Page.SetAllDirty();
		this.text_Page.cachedTextGenerator.Invalidate();
		this.btn_Previous.gameObject.SetActive(true);
		this.btn_Next.gameObject.SetActive(true);
		if (this.MaxLetterNum > 1)
		{
			if (this.Report.Index + 1 == 1)
			{
				this.btn_Previous.gameObject.SetActive(false);
				if (!this.btn_Next.IsActive())
				{
					this.btn_Next.gameObject.SetActive(true);
				}
			}
			if ((int)(this.Report.Index + 1) == this.MaxLetterNum)
			{
				this.btn_Next.gameObject.SetActive(false);
				if (!this.btn_Previous.IsActive())
				{
					this.btn_Previous.gameObject.SetActive(true);
				}
			}
		}
		else
		{
			this.btn_Previous.gameObject.SetActive(false);
			this.btn_Next.gameObject.SetActive(false);
		}
		this.tmpH = -136f;
		this.text_Summary.SetAllDirty();
		this.text_Summary.cachedTextGenerator.Invalidate();
		this.tmpH = -136f;
		if (this.bWin)
		{
			this.Img_Titlebg.sprite = this.SArray.m_Sprites[0];
			this.text_Summary.color = new Color(1f, 0.9255f, 0.5294f);
			this.text_Summary.transform.GetComponent<Outline>().effectColor = new Color(0.8431f, 0f, 0f);
			this.text_Summary.transform.GetComponent<Shadow>().effectColor = new Color(0.2824f, 0f, 0f);
		}
		else
		{
			this.Img_Titlebg.sprite = this.SArray.m_Sprites[1];
			this.text_Summary.color = new Color(0.6941f, 0.9137f, 1f);
			this.text_Summary.transform.GetComponent<Outline>().effectColor = new Color(0.2471f, 0.451f, 0.7294f);
			this.text_Summary.transform.GetComponent<Shadow>().effectColor = new Color(0f, 0.0471f, 0.2824f);
		}
		if (this.mOpenKind == 0)
		{
			int num;
			if (this.mType >= 4)
			{
				num = 1;
			}
			else
			{
				num = this.mType;
			}
			if (!this.bNpcMode)
			{
				if (this.Report.Combat.CombatPointKind == POINT_KIND.PK_YOLK)
				{
					if (this.bWin)
					{
						if (this.IsAttack)
						{
							this.Cstr_Text.ClearString();
							if (this.Report.Combat.CombatPoint == 0 || this.Report.Combat.KingdomID == ActivityManager.Instance.KOWKingdomID)
							{
								this.Cstr_Text.StringToFormat(this.DM.mStringTable.GetStringByID(9308u));
							}
							else
							{
								this.Cstr_Text.StringToFormat(this.DM.mStringTable.GetStringByID(9309u));
							}
							this.Cstr_Text.AppendFormat(this.DM.mStringTable.GetStringByID(7265u));
							this.text_Summary.text = this.Cstr_Text.ToString();
						}
						else
						{
							this.text_Summary.text = this.DM.mStringTable.GetStringByID(5307u);
						}
					}
					else
					{
						this.text_Summary.text = this.DM.mStringTable.GetStringByID(5308u);
					}
				}
				else
				{
					this.text_Summary.text = this.DM.mStringTable.GetStringByID((uint)((ushort)(5307 + num)));
				}
				if (!this.bQuanmier && this.Report.Combat.CaptureResult != ECombatReportCaptureResultType.ECRCR_NONE)
				{
					if (this.Report.Combat.CaptureResult == ECombatReportCaptureResultType.ECRCR_CAPTURE_LORD)
					{
						this.text_MainHero.text = this.DM.mStringTable.GetStringByID(5312u);
					}
					else
					{
						this.text_MainHero.text = this.DM.mStringTable.GetStringByID(5311u);
					}
					this.tmpH -= 98f;
					this.Img_MainHerobg.gameObject.SetActive(true);
				}
				else
				{
					this.Img_MainHerobg.gameObject.SetActive(false);
				}
			}
			else if (this.bWin)
			{
				this.text_Summary.text = this.DM.mStringTable.GetStringByID(5307u);
			}
			else
			{
				this.text_Summary.text = this.DM.mStringTable.GetStringByID(5308u);
			}
		}
		this.ItemRT.anchoredPosition = new Vector2(this.ItemRT.anchoredPosition.x, this.tmpH);
		float num2 = 0f;
		this.mItemCount = 0;
		for (int i = 0; i < 5; i++)
		{
			if (this.ItemT[i] != null)
			{
				this.ItemT[i].gameObject.SetActive(false);
			}
		}
		if (!this.bAllianceBossMode)
		{
			for (int j = 0; j < 30; j++)
			{
				if (this.mOpenKind == 0)
				{
					if (this.bNpcMode && this.bWin)
					{
						this.mItemCount = 1;
						break;
					}
				}
				else if (this.mOpenKind == 1 && this.Report.Monster.Item[j] != null && this.Report.Monster.Item[j].ItemID != 0)
				{
					this.ItemID[j] = this.Report.Monster.Item[j].ItemID;
					this.ItemNum[j] = this.Report.Monster.Item[j].Num;
					this.ItemRank[j] = this.Report.Monster.Item[j].ItemRank;
					this.mItemCount++;
				}
			}
		}
		else
		{
			this.mItemCount = 1;
		}
		this.text_TitleItem.text = this.DM.mStringTable.GetStringByID(7696u);
		this.tmpNum = this.mItemCount / 6;
		if (this.mItemCount % 6 > 0)
		{
			this.tmpNum++;
		}
		this.NpcItemRT.gameObject.SetActive(false);
		this.AllianceBossItemRT.gameObject.SetActive(false);
		if (this.mItemCount > 0)
		{
			this.tmpH -= 41f;
			this.tmpH -= (float)(89 * this.tmpNum);
			num2 -= (float)(89 * this.tmpNum);
			if (!this.bInitItemBase && !this.bNpcMode)
			{
				this.bInitItemBase = true;
				for (int k = 0; k < 6; k++)
				{
					this.btn_Itme[k] = this.ItemT[0].GetChild(k).GetComponent<UIHIBtn>();
					this.btn_Itme[k].m_Handler = this;
					this.GUIM.InitianHeroItemImg(this.btn_Itme[k].transform, eHeroOrItem.Item, 0, 0, 0, 0, true, true, true, false);
					this.btn_Item_L[k] = this.ItemT[0].GetChild(6 + k).GetComponent<UILEBtn>();
					this.GUIM.InitLordEquipImg(this.btn_Item_L[k].transform, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
					this.btn_Item_L[k].gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
					this.text_ItemQty[k] = this.ItemT[0].GetChild(12 + k).GetComponent<UIText>();
					this.text_ItemQty[k].font = this.TTFont;
				}
			}
			if (this.bNpcMode)
			{
				this.NpcItemRT.gameObject.SetActive(true);
				Image component = this.btn_NpcItemIcon.GetComponent<Image>();
				component.sprite = GUIManager.Instance.m_LeadItemIconSpriteAsset.LoadSprite(this.DM.NPCPrize.GetRecordByKey(this.Report.NPCCombat.Reward).PicNo);
				component.material = GUIManager.Instance.m_LeadItemIconSpriteAsset.GetMaterial();
				this.text_NpcItemName.text = this.DM.mStringTable.GetStringByID((uint)this.DM.NPCPrize.GetRecordByKey(this.Report.NPCCombat.Reward).Element);
				this.tmpRC = this.btn_NpcItemName.transform.GetComponent<RectTransform>();
				this.tmpRC.sizeDelta = new Vector2(this.text_NpcItemName.preferredWidth, this.tmpRC.sizeDelta.y);
				this.tmpRC = this.btn_NpcItemName.transform.GetChild(0).GetComponent<RectTransform>();
				this.tmpRC.sizeDelta = new Vector2(this.text_NpcItemName.preferredWidth, this.tmpRC.sizeDelta.y);
				this.tmpRC = this.btn_NpcItemName.transform.GetChild(1).GetComponent<RectTransform>();
				this.tmpRC.sizeDelta = new Vector2(this.text_NpcItemName.preferredWidth, this.tmpRC.sizeDelta.y);
				if (this.Report.NPCCombat.Reward > 0)
				{
					this.btn_NpcItemIcon.gameObject.SetActive(true);
					this.btn_NpcItemName.gameObject.SetActive(true);
					this.text_NpcItemName.gameObject.SetActive(true);
					this.text_NpcItemfull.gameObject.SetActive(false);
				}
				else
				{
					this.btn_NpcItemIcon.gameObject.SetActive(false);
					this.btn_NpcItemName.gameObject.SetActive(false);
					this.text_NpcItemName.gameObject.SetActive(false);
					this.text_NpcItemfull.gameObject.SetActive(true);
				}
			}
			if (this.bAllianceBossMode)
			{
				this.AllianceBossItemRT.gameObject.SetActive(true);
				this.text_TitleItem.text = this.DM.mStringTable.GetStringByID(14516u);
			}
		}
		this.bSetItemData = 0;
		this.ResourcesRT.anchoredPosition = new Vector2(this.ResourcesRT.anchoredPosition.x, num2);
		bool flag = false;
		if (this.mOpenKind == 0 && !this.bNpcMode)
		{
			for (int l = 0; l < 5; l++)
			{
				this.Cstr_Resources[l].ClearString();
				if (this.Report.Combat.Resource[l] != 0)
				{
					GameConstants.FormatResourceValue_Int(this.Cstr_Resources[l], this.Report.Combat.Resource[l]);
					if (!flag)
					{
						flag = true;
					}
				}
				else
				{
					this.Cstr_Resources[l].Append("-");
				}
				this.text_Resources[l].text = this.Cstr_Resources[l].ToString();
				this.text_Resources[l].SetAllDirty();
				this.text_Resources[l].cachedTextGenerator.Invalidate();
			}
		}
		if (this.mItemCount < 1 && !flag)
		{
			this.ItemRT.gameObject.SetActive(false);
		}
		else
		{
			this.ItemRT.gameObject.SetActive(true);
			if (flag)
			{
				this.ResourcesRT.gameObject.SetActive(true);
				if (this.mItemCount < 1)
				{
					this.tmpH -= 110f;
				}
				else
				{
					this.tmpH -= 70f;
				}
				this.ItemRT2.sizeDelta = new Vector2(this.ItemRT2.sizeDelta.x, -num2 + 70f);
			}
			else
			{
				this.ResourcesRT.gameObject.SetActive(false);
				this.ItemRT2.sizeDelta = new Vector2(this.ItemRT2.sizeDelta.x, -num2);
			}
		}
		this.text_TitleItem.SetAllDirty();
		this.text_TitleItem.cachedTextGenerator.Invalidate();
		this.HeroRT.anchoredPosition = new Vector2(this.HeroRT.anchoredPosition.x, this.tmpH);
		int num3 = 0;
		Array.Clear(this.tmpHeroExp, 0, this.tmpHeroExp.Length);
		Array.Clear(this.tmpHeroID, 0, this.tmpHeroID.Length);
		Array.Clear(this.tmpHeroStar, 0, this.tmpHeroStar.Length);
		if (!this.bNpcMode)
		{
			for (int m = 0; m < 5; m++)
			{
				if (this.mOpenKind == 0 && this.Report.Combat.HeroData[m].HeroID != 0)
				{
					this.tmpHeroExp[m] = this.Report.Combat.EarnHeroExp;
					this.tmpHeroID[m] = this.Report.Combat.HeroData[m].HeroID;
					this.tmpHeroStar[m] = this.Report.Combat.HeroData[m].Star;
					num3++;
				}
				else if (this.mOpenKind == 1 && this.Report.Monster.HeroID[m] != 0)
				{
					this.tmpHeroExp[m] = this.Report.Monster.HeroExp[m];
					this.tmpHeroID[m] = this.Report.Monster.HeroID[m];
					this.tmpHeroStar[m] = this.Report.Monster.HeroData[m].Star;
					num3++;
				}
			}
		}
		else
		{
			for (int n = 0; n < 5; n++)
			{
				if (this.mOpenKind == 0 && this.Report.NPCCombat.HeroData[n].HeroID != 0)
				{
					this.tmpHeroExp[n] = this.Report.NPCCombat.EarnHeroExp;
					this.tmpHeroID[n] = this.Report.NPCCombat.HeroData[n].HeroID;
					this.tmpHeroStar[n] = this.Report.NPCCombat.HeroData[n].Star;
					num3++;
				}
			}
		}
		uint num4;
		if (this.mOpenKind == 0)
		{
			if (!this.bNpcMode)
			{
				num4 = this.Report.Combat.EarnLordExp;
			}
			else
			{
				num4 = this.Report.NPCCombat.EarnLordExp;
			}
		}
		else
		{
			num4 = this.Report.Monster.Exp;
		}
		if (!this.bNpcMode && (num4 > 0u || num3 > 0))
		{
			this.HeroRT.gameObject.SetActive(true);
			this.tmpH -= 41f;
			this.Cstr_L_Exp.ClearString();
			this.Cstr_L_Exp.Append(this.DM.mStringTable.GetStringByID(7698u));
			this.Cstr_L_Exp.IntToFormat((long)((ulong)num4), 1, true);
			this.Cstr_L_Exp.AppendFormat("+{0}");
			this.text_L_Exp.text = this.Cstr_L_Exp.ToString();
			this.text_L_Exp.SetAllDirty();
			this.text_L_Exp.cachedTextGenerator.Invalidate();
			if (num3 > 0)
			{
				this.HeroBGRT.sizeDelta = new Vector2(this.HeroBGRT.sizeDelta.x, 196f);
				for (int num5 = 0; num5 < num3; num5++)
				{
					this.Cstr_HeroExp[num5].ClearString();
					this.Cstr_HeroExp[num5].IntToFormat((long)((ulong)this.tmpHeroExp[num5]), 1, true);
					if (this.GUIM.IsArabic)
					{
						this.Cstr_HeroExp[num5].AppendFormat("{0}+");
					}
					else
					{
						this.Cstr_HeroExp[num5].AppendFormat("+{0}");
					}
					this.text_HeroExp[num5].text = this.Cstr_HeroExp[num5].ToString();
					this.text_HeroExp[num5].SetAllDirty();
					this.text_HeroExp[num5].cachedTextGenerator.Invalidate();
					this.text_HeroExp[num5].gameObject.SetActive(true);
					this.text_HeroExp2[num5].gameObject.SetActive(true);
					this.btn_Hero[num5].gameObject.SetActive(true);
					if (!this.bSetHero[num5])
					{
						this.GUIM.InitianHeroItemImg(this.btn_Hero[num5].transform, eHeroOrItem.Hero, this.tmpHeroID[num5], this.tmpHeroStar[num5], 0, 0, true, true, true, false);
						this.bSetHero[num5] = true;
					}
					else
					{
						this.GUIM.ChangeHeroItemImg(this.btn_Hero[num5].transform, eHeroOrItem.Hero, this.tmpHeroID[num5], this.tmpHeroStar[num5], 0, 0);
					}
				}
				this.tmpH -= 196f;
			}
			else
			{
				this.HeroBGRT.sizeDelta = new Vector2(this.HeroBGRT.sizeDelta.x, 86f);
				this.tmpH -= 86f;
			}
			for (int num6 = num3; num6 < 5; num6++)
			{
				this.Cstr_HeroExp[num6].ClearString();
				this.text_HeroExp[num6].gameObject.SetActive(false);
				this.text_HeroExp2[num6].gameObject.SetActive(false);
				this.btn_Hero[num6].gameObject.SetActive(false);
			}
		}
		else
		{
			this.HeroRT.gameObject.SetActive(false);
		}
		this.SummaryRT.anchoredPosition = new Vector2(this.SummaryRT.anchoredPosition.x, this.tmpH);
		this.tmpH -= 51f;
		this.tmpH -= 312f;
		if (this.mOpenKind == 0 && this.Img_MainHero[1] != null)
		{
			this.SetFightData();
		}
		else if (this.mOpenKind == 1)
		{
			this.SetBossData();
		}
		this.Cstr_Coordinate[0].ClearString();
		this.Cstr_Coordinate[1].ClearString();
		if (this.mOpenKind == 0)
		{
			if (!this.bNpcMode)
			{
				if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
				{
					this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Combat.CombatlZone, this.Report.Combat.CombatPoint));
				}
				else
				{
					this.tmpV = DataManager.MapDataController.GetYolkPos((ushort)this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID);
				}
				this.Cstr_Coordinate[0].IntToFormat((long)this.Report.Combat.KingdomID, 1, false);
				this.Cstr_Coordinate[0].IntToFormat((long)((int)this.tmpV.x), 1, false);
				this.Cstr_Coordinate[0].IntToFormat((long)((int)this.tmpV.y), 1, false);
				if (this.GUIM.IsArabic)
				{
					this.Cstr_Coordinate[0].AppendFormat("{0}:K {1}:X {2}:Y");
				}
				else
				{
					this.Cstr_Coordinate[0].AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
				}
				this.Cstr_Coordinate[1].StringToFormat(this.Cstr_Coordinate[0]);
				this.Cstr_Coordinate[1].AppendFormat(this.DM.mStringTable.GetStringByID(5305u));
			}
			else
			{
				this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.NPCCombat.CombatlZone, this.Report.NPCCombat.CombatPoint));
				this.Cstr_Coordinate[0].IntToFormat((long)this.Report.NPCCombat.KingdomID, 1, false);
				this.Cstr_Coordinate[0].IntToFormat((long)((int)this.tmpV.x), 1, false);
				this.Cstr_Coordinate[0].IntToFormat((long)((int)this.tmpV.y), 1, false);
				if (this.GUIM.IsArabic)
				{
					this.Cstr_Coordinate[0].AppendFormat("{0}:K {1}:X {2}:Y");
				}
				else
				{
					this.Cstr_Coordinate[0].AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
				}
				this.Cstr_Coordinate[1].StringToFormat(this.Cstr_Coordinate[0]);
				this.Cstr_Coordinate[1].AppendFormat(this.DM.mStringTable.GetStringByID(5305u));
			}
		}
		else
		{
			this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Monster.Zone, this.Report.Monster.Point));
			this.Cstr_Coordinate[0].IntToFormat((long)this.Report.Monster.KindgomID, 1, false);
			this.Cstr_Coordinate[0].IntToFormat((long)((int)this.tmpV.x), 1, false);
			this.Cstr_Coordinate[0].IntToFormat((long)((int)this.tmpV.y), 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Coordinate[0].AppendFormat("{0}:K {1}:X {2}:Y");
			}
			else
			{
				this.Cstr_Coordinate[0].AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
			}
			this.Cstr_Coordinate[1].StringToFormat(this.Cstr_Coordinate[0]);
			this.Cstr_Coordinate[1].AppendFormat(this.DM.mStringTable.GetStringByID(8218u));
		}
		this.text_Coordinate.text = this.Cstr_Coordinate[1].ToString();
		this.text_Coordinate.SetAllDirty();
		this.text_Coordinate.cachedTextGenerator.Invalidate();
		this.text_Coordinate.cachedTextGeneratorForLayout.Invalidate();
		this.tmpRC = this.btn_Title.transform.GetComponent<RectTransform>();
		this.tmpRC.sizeDelta = new Vector2(this.text_Coordinate.preferredWidth, this.tmpRC.sizeDelta.y);
		this.tmpRC = this.btn_Title.transform.GetChild(0).GetComponent<RectTransform>();
		this.tmpRC.sizeDelta = new Vector2(this.text_Coordinate.preferredWidth, this.tmpRC.sizeDelta.y);
		this.tmpRC = this.btn_Title.transform.GetChild(1).GetComponent<RectTransform>();
		this.tmpRC.sizeDelta = new Vector2(this.text_Coordinate.preferredWidth, this.tmpRC.sizeDelta.y);
		this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Times).ToString("MM/dd/yy");
		this.text_Time[0].SetAllDirty();
		this.text_Time[0].cachedTextGenerator.Invalidate();
		this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Times).ToString("HH:mm:ss");
		this.text_Time[1].SetAllDirty();
		this.text_Time[1].cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001B29 RID: 6953 RVA: 0x002F71E0 File Offset: 0x002F53E0
	public void SetFightData()
	{
		if (!this.bNpcMode)
		{
			this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.Report.Combat.Summary.AssaultHead);
		}
		else
		{
			this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.Report.NPCCombat.Summary.AssaultHead);
		}
		this.Img_MainHero[1].sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
		if ((!this.bNpcMode && this.Report.Combat.Summary.IsLeader == 0) || (this.bNpcMode && this.Report.NPCCombat.Summary.IsLeader == 0))
		{
			this.Img_Muster[0].gameObject.SetActive(false);
		}
		this.Cstr_Dominance[0].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_Dominance[0].IntToFormat((long)this.Report.Combat.Summary.AssaultLevel, 1, false);
		}
		else
		{
			this.Cstr_Dominance[0].IntToFormat((long)this.Report.NPCCombat.Summary.AssaultLevel, 1, false);
		}
		this.Cstr_Dominance[0].AppendFormat(this.DM.mStringTable.GetStringByID(5320u));
		this.text_Dominance[0].text = this.Cstr_Dominance[0].ToString();
		this.text_Dominance[0].SetAllDirty();
		this.text_Dominance[0].cachedTextGenerator.Invalidate();
		this.Cstr_Country[0].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_Country[0].IntToFormat((long)this.Report.Combat.AssaultKingdomID, 1, false);
		}
		else
		{
			this.Cstr_Country[0].IntToFormat((long)this.Report.NPCCombat.AssaultKingdomID, 1, false);
		}
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
		if (!false)
		{
			this.Img_Country[0].gameObject.SetActive(false);
		}
		int assaultAllianceRank;
		if (!this.bNpcMode)
		{
			assaultAllianceRank = (int)this.Report.Combat.Summary.AssaultAllianceRank;
		}
		else
		{
			assaultAllianceRank = (int)this.Report.NPCCombat.Summary.AssaultAllianceRank;
		}
		this.Img_Rank[0].sprite = this.SArray.m_Sprites[7 + assaultAllianceRank];
		if (assaultAllianceRank < 1)
		{
			this.Img_Rank[0].gameObject.SetActive(false);
		}
		else
		{
			this.Img_Rank[0].gameObject.SetActive(true);
		}
		int assaultVIPLevel;
		if (!this.bNpcMode)
		{
			assaultVIPLevel = (int)this.Report.Combat.Summary.AssaultVIPLevel;
		}
		else
		{
			assaultVIPLevel = (int)this.Report.NPCCombat.Summary.AssaultVIPLevel;
		}
		this.text_Vip[0].text = assaultVIPLevel.ToString();
		this.Cstr_CoordinateMainHero[0].ClearString();
		if (!this.bNpcMode)
		{
			this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Combat.Summary.AssaultCapitalZone, this.Report.Combat.Summary.AssaultCapitalPoint));
			this.Cstr_CoordinateMainHero[0].IntToFormat((long)this.Report.Combat.KingdomID, 1, false);
		}
		else
		{
			this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.NPCCombat.SummaryHead.AssaultCapitalZone, this.Report.NPCCombat.SummaryHead.AssaultCapitalPoint));
			this.Cstr_CoordinateMainHero[0].IntToFormat((long)this.Report.NPCCombat.KingdomID, 1, false);
		}
		this.Cstr_CoordinateMainHero[0].IntToFormat((long)((int)this.tmpV.x), 1, false);
		this.Cstr_CoordinateMainHero[0].IntToFormat((long)((int)this.tmpV.y), 1, false);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_CoordinateMainHero[0].AppendFormat("{2}:Y {1}:X {0}:K");
		}
		else
		{
			this.Cstr_CoordinateMainHero[0].AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
		}
		this.text_CoordinateMainHero[0].text = this.Cstr_CoordinateMainHero[0].ToString();
		this.text_CoordinateMainHero[0].SetAllDirty();
		this.text_CoordinateMainHero[0].cachedTextGenerator.Invalidate();
		this.text_CoordinateMainHero[0].cachedTextGeneratorForLayout.Invalidate();
		this.tmpRC = this.btn_Coordinate[0].transform.GetComponent<RectTransform>();
		this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[0].preferredWidth, this.tmpRC.sizeDelta.y);
		this.tmpRC = this.btn_Coordinate[0].transform.GetChild(0).GetComponent<RectTransform>();
		this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[0].preferredWidth, this.tmpRC.sizeDelta.y);
		this.tmpRC = this.btn_Coordinate[0].transform.GetChild(1).GetComponent<RectTransform>();
		this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[0].preferredWidth, this.tmpRC.sizeDelta.y);
		this.Cstr_Name[0].ClearString();
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring2.ClearString();
		if (!this.bNpcMode)
		{
			cstring.Append(this.Report.Combat.AssaultName);
			if (this.Report.Combat.AssaultAllianceTag != string.Empty)
			{
				cstring2.Append(this.Report.Combat.AssaultAllianceTag);
				GameConstants.FormatRoleName(this.Cstr_Name[0], cstring, cstring2, null, 0, 0, null, null, null, null);
			}
			else
			{
				GameConstants.FormatRoleName(this.Cstr_Name[0], cstring, null, null, 0, 0, null, null, null, null);
			}
		}
		else
		{
			cstring.Append(this.Report.NPCCombat.AssaultName);
			if (this.Report.NPCCombat.AssaultAllianceTag != string.Empty)
			{
				cstring2.Append(this.Report.NPCCombat.AssaultAllianceTag);
				GameConstants.FormatRoleName(this.Cstr_Name[0], cstring, cstring2, null, 0, 0, null, null, null, null);
			}
			else
			{
				GameConstants.FormatRoleName(this.Cstr_Name[0], cstring, null, null, 0, 0, null, null, null, null);
			}
		}
		this.text_Name[0].text = this.Cstr_Name[0].ToString();
		this.text_Name[0].SetAllDirty();
		this.text_Name[0].cachedTextGenerator.Invalidate();
		if (!this.bNpcMode)
		{
			this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.Report.Combat.Summary.DefenceHead);
		}
		this.Img_MainHero[4].sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
		if (!false)
		{
			this.Img_Muster[1].gameObject.SetActive(false);
		}
		this.Cstr_Dominance[1].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_Dominance[1].IntToFormat((long)this.Report.Combat.Summary.DefenceLevel, 1, false);
			this.Cstr_Dominance[1].AppendFormat(this.DM.mStringTable.GetStringByID(5320u));
		}
		this.text_Dominance[1].text = this.Cstr_Dominance[1].ToString();
		this.text_Dominance[1].SetAllDirty();
		this.text_Dominance[1].cachedTextGenerator.Invalidate();
		this.Cstr_Country[1].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_Country[1].IntToFormat((long)this.Report.Combat.DefenceKingdomID, 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Country[1].AppendFormat("{0}#");
			}
			else
			{
				this.Cstr_Country[1].AppendFormat("#{0}");
			}
			this.text_Country[1].text = this.Cstr_Country[1].ToString();
		}
		this.text_Country[1].SetAllDirty();
		this.text_Country[1].cachedTextGenerator.Invalidate();
		if (!false)
		{
			this.Img_Country[1].gameObject.SetActive(false);
		}
		int num = 0;
		if (!this.bNpcMode)
		{
			num = (int)this.Report.Combat.Summary.DefenceAllianceRank;
		}
		this.Img_Rank[1].sprite = this.SArray.m_Sprites[7 + num];
		if (num < 1)
		{
			this.Img_Rank[1].gameObject.SetActive(false);
		}
		else
		{
			this.Img_Rank[1].gameObject.SetActive(true);
		}
		int num2 = 0;
		if (!this.bNpcMode)
		{
			num2 = (int)this.Report.Combat.Summary.DefenceVIPLevel;
		}
		this.text_Vip[1].text = num2.ToString();
		this.Cstr_CoordinateMainHero[1].ClearString();
		if (!this.bNpcMode)
		{
			if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
			{
				this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Combat.Summary.DefenceCapitalZone, this.Report.Combat.Summary.DefenceCapitalPoint));
			}
			else
			{
				this.tmpV = DataManager.MapDataController.GetYolkPos((ushort)this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID);
			}
			this.Cstr_CoordinateMainHero[1].IntToFormat((long)this.Report.Combat.KingdomID, 1, false);
		}
		else
		{
			if (this.Report.NPCCombat.CombatPointKind != POINT_KIND.PK_YOLK)
			{
				this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.NPCCombat.CombatlZone, this.Report.NPCCombat.CombatPoint));
			}
			this.Cstr_CoordinateMainHero[1].IntToFormat((long)this.Report.NPCCombat.KingdomID, 1, false);
		}
		this.Cstr_CoordinateMainHero[1].IntToFormat((long)((int)this.tmpV.x), 1, false);
		this.Cstr_CoordinateMainHero[1].IntToFormat((long)((int)this.tmpV.y), 1, false);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_CoordinateMainHero[1].AppendFormat("{2}:Y {1}:X {0}:K");
		}
		else
		{
			this.Cstr_CoordinateMainHero[1].AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
		}
		this.text_CoordinateMainHero[1].text = this.Cstr_CoordinateMainHero[1].ToString();
		this.text_CoordinateMainHero[1].SetAllDirty();
		this.text_CoordinateMainHero[1].cachedTextGenerator.Invalidate();
		this.text_CoordinateMainHero[1].cachedTextGeneratorForLayout.Invalidate();
		this.tmpRC = this.btn_Coordinate[1].transform.GetComponent<RectTransform>();
		this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[1].preferredWidth, this.tmpRC.sizeDelta.y);
		this.tmpRC = this.btn_Coordinate[1].transform.GetChild(0).GetComponent<RectTransform>();
		this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[1].preferredWidth, this.tmpRC.sizeDelta.y);
		this.tmpRC = this.btn_Coordinate[1].transform.GetChild(1).GetComponent<RectTransform>();
		this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[1].preferredWidth, this.tmpRC.sizeDelta.y);
		this.Cstr_Name[1].ClearString();
		cstring.ClearString();
		cstring2.ClearString();
		if (!this.bNpcMode)
		{
			cstring.Append(this.Report.Combat.DefenceName);
			if (this.Report.Combat.DefenceAllianceTag != string.Empty)
			{
				cstring2.Append(this.Report.Combat.DefenceAllianceTag);
				GameConstants.FormatRoleName(this.Cstr_Name[1], cstring, cstring2, null, 0, 0, null, null, null, null);
			}
			else
			{
				GameConstants.FormatRoleName(this.Cstr_Name[1], cstring, null, null, 0, 0, null, null, null, null);
			}
		}
		else
		{
			this.Cstr_Name[1].IntToFormat((long)this.Report.NPCCombat.NPCLevel, 1, false);
			this.Cstr_Name[1].AppendFormat(this.DM.mStringTable.GetStringByID(12021u));
		}
		this.text_Name[1].text = this.Cstr_Name[1].ToString();
		this.text_Name[1].SetAllDirty();
		this.text_Name[1].cachedTextGenerator.Invalidate();
		if (!this.bNpcMode)
		{
			if (this.Report.Combat.Summary.AssaultLordInCombat == 1)
			{
				this.Img_Crown[0].gameObject.SetActive(true);
				this.Img_MainTitle[0].gameObject.SetActive(true);
			}
			else
			{
				this.Img_Crown[0].gameObject.SetActive(false);
				this.Img_MainTitle[0].gameObject.SetActive(false);
			}
			if (this.Report.Combat.Summary.DefenceLordInCombat == 1)
			{
				if (this.Report.Combat.CombatPointKind == POINT_KIND.PK_CITY)
				{
					this.Img_Crown[2].gameObject.SetActive(true);
					this.Img_MainTitle[1].gameObject.SetActive(true);
				}
				else
				{
					this.Img_Crown[2].gameObject.SetActive(true);
					this.Img_MainTitle[1].gameObject.SetActive(true);
				}
			}
			else
			{
				this.Img_Crown[2].gameObject.SetActive(false);
				this.Img_MainTitle[1].gameObject.SetActive(false);
			}
		}
		else if (this.Report.NPCCombat.Summary.AssaultLordInCombat == 1)
		{
			this.Img_Crown[0].gameObject.SetActive(true);
			this.Img_MainTitle[0].gameObject.SetActive(true);
		}
		else
		{
			this.Img_Crown[0].gameObject.SetActive(false);
			this.Img_MainTitle[0].gameObject.SetActive(false);
		}
		if (this.bNpcMode)
		{
			this.Img_NpcMainHero[0].gameObject.SetActive(true);
			this.text_NpcInfo.gameObject.SetActive(true);
			this.text_NpcTroops[0].gameObject.SetActive(true);
			this.text_NpcTroops[1].gameObject.SetActive(true);
			this.Cstr_NpcTroops.ClearString();
			this.Cstr_NpcTroops.IntToFormat((long)((ulong)this.Report.NPCCombat.ResurrextTotal), 1, true);
			this.Cstr_NpcTroops.AppendFormat("{0}");
			this.text_NpcTroops[1].text = this.Cstr_NpcTroops.ToString();
			this.text_NpcTroops[1].SetAllDirty();
			this.text_NpcTroops[1].cachedTextGenerator.Invalidate();
			this.Img_MainHero[3].gameObject.SetActive(false);
			this.Img_Crown[2].gameObject.SetActive(false);
			this.Img_MainTitle[1].gameObject.SetActive(false);
			this.Img_NpcMainHero[1].sprite = this.GUIM.NpcHead;
			this.Img_NpcMainHero[1].material = this.GUIM.m_WonderMaterial;
			this.Cstr_CoordinateMainHero[1].ClearString();
			this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.NPCCombat.CombatlZone, this.Report.NPCCombat.CombatPoint));
			this.Cstr_CoordinateMainHero[1].IntToFormat((long)this.Report.NPCCombat.KingdomID, 1, false);
			this.Cstr_CoordinateMainHero[1].IntToFormat((long)((int)this.tmpV.x), 1, false);
			this.Cstr_CoordinateMainHero[1].IntToFormat((long)((int)this.tmpV.y), 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_CoordinateMainHero[1].AppendFormat("{2}:Y {1}:X {0}:K");
			}
			else
			{
				this.Cstr_CoordinateMainHero[1].AppendFormat(this.DM.mStringTable.GetStringByID(4633u));
			}
			this.text_NpcCoordinate.text = this.Cstr_CoordinateMainHero[1].ToString();
			this.text_NpcCoordinate.SetAllDirty();
			this.text_NpcCoordinate.cachedTextGenerator.Invalidate();
			this.text_NpcCoordinate.cachedTextGeneratorForLayout.Invalidate();
			this.tmpRC = this.btn_NpcCoordinate.transform.GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.text_NpcCoordinate.preferredWidth, this.tmpRC.sizeDelta.y);
			this.tmpRC = this.btn_NpcCoordinate.transform.GetChild(0).GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.text_NpcCoordinate.preferredWidth, this.tmpRC.sizeDelta.y);
			this.tmpRC = this.btn_NpcCoordinate.transform.GetChild(1).GetComponent<RectTransform>();
			this.tmpRC.sizeDelta = new Vector2(this.text_NpcCoordinate.preferredWidth, this.tmpRC.sizeDelta.y);
			this.Cstr_Name[1].ClearString();
			cstring.ClearString();
			cstring2.ClearString();
			this.Cstr_Name[1].IntToFormat((long)this.Report.NPCCombat.NPCLevel, 1, false);
			this.Cstr_Name[1].AppendFormat(this.DM.mStringTable.GetStringByID(12021u));
			this.text_NpcName.text = this.Cstr_Name[1].ToString();
			this.text_NpcName.SetAllDirty();
			this.text_NpcName.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.Img_NpcMainHero[0].gameObject.SetActive(false);
			this.text_NpcInfo.gameObject.SetActive(false);
			this.text_NpcTroops[0].gameObject.SetActive(false);
			this.text_NpcTroops[1].gameObject.SetActive(false);
			this.Img_MainHero[3].gameObject.SetActive(true);
			this.Img_Crown[2].gameObject.SetActive(true);
			this.Img_MainTitle[1].gameObject.SetActive(true);
		}
		this.text_MainHero_F[0].SetAllDirty();
		this.text_MainHero_F[0].cachedTextGenerator.Invalidate();
		this.text_MainHero_F[1].SetAllDirty();
		this.text_MainHero_F[1].cachedTextGenerator.Invalidate();
		this.tmpH -= 41f;
		this.Cstr_LossValue[0].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_LossValue[0].IntToFormat((long)((ulong)(this.Report.Combat.Summary.AssaultTroopInjure + this.Report.Combat.Summary.AssaultTroopDeath)), 1, true);
		}
		else
		{
			this.Cstr_LossValue[0].IntToFormat((long)((ulong)(this.Report.NPCCombat.SummaryHead.AssaultTroopInjure + this.Report.NPCCombat.SummaryHead.AssaultTroopDeath)), 1, true);
		}
		this.Cstr_LossValue[0].AppendFormat("{0}");
		this.text_LossValue[0].text = this.Cstr_LossValue[0].ToString();
		this.text_LossValue[0].SetAllDirty();
		this.text_LossValue[0].cachedTextGenerator.Invalidate();
		this.Cstr_Strength[0].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_Strength[0].uLongToFormat(this.Report.Combat.Summary.AssaultLosePower, 1, true);
		}
		else
		{
			this.Cstr_Strength[0].uLongToFormat(this.Report.NPCCombat.SummaryHead.AssaultLosePower, 1, true);
		}
		this.Cstr_Strength[0].AppendFormat(this.DM.mStringTable.GetStringByID(5322u));
		this.text_Strength[0].text = this.Cstr_Strength[0].ToString();
		this.text_Strength[0].SetAllDirty();
		this.text_Strength[0].cachedTextGenerator.Invalidate();
		this.Cstr_LA[0].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_LA[0].IntToFormat((long)((ulong)this.Report.Combat.Summary.AssaultTroopForce), 1, true);
			this.tmpValue = this.Report.Combat.Summary.AssaultTroopForce;
		}
		else
		{
			this.Cstr_LA[0].IntToFormat((long)((ulong)this.Report.NPCCombat.SummaryHead.AssaultTroopForce), 1, true);
			this.tmpValue = this.Report.NPCCombat.SummaryHead.AssaultTroopForce;
		}
		this.Cstr_LA[0].AppendFormat("{0}");
		this.text_LA[0].text = this.Cstr_LA[0].ToString();
		this.text_LA[0].SetAllDirty();
		this.text_LA[0].cachedTextGenerator.Invalidate();
		this.Cstr_LA[1].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_LA[1].IntToFormat((long)((ulong)this.Report.Combat.Summary.AssaultTroopInjure), 1, true);
			this.tmpValue -= this.Report.Combat.Summary.AssaultTroopInjure;
		}
		else
		{
			this.Cstr_LA[1].IntToFormat((long)((ulong)this.Report.NPCCombat.SummaryHead.AssaultTroopInjure), 1, true);
			this.tmpValue -= this.Report.NPCCombat.SummaryHead.AssaultTroopInjure;
		}
		this.Cstr_LA[1].AppendFormat("{0}");
		this.text_LA[1].text = this.Cstr_LA[1].ToString();
		this.text_LA[1].SetAllDirty();
		this.text_LA[1].cachedTextGenerator.Invalidate();
		this.Cstr_LA[2].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_LA[2].IntToFormat((long)((ulong)this.Report.Combat.Summary.AssaultTroopDeath), 1, true);
			this.tmpValue -= this.Report.Combat.Summary.AssaultTroopDeath;
		}
		else
		{
			this.Cstr_LA[2].IntToFormat((long)((ulong)this.Report.NPCCombat.SummaryHead.AssaultTroopDeath), 1, true);
			this.tmpValue -= this.Report.NPCCombat.SummaryHead.AssaultTroopDeath;
		}
		this.Cstr_LA[2].AppendFormat("{0}");
		this.text_LA[2].text = this.Cstr_LA[2].ToString();
		this.text_LA[2].SetAllDirty();
		this.text_LA[2].cachedTextGenerator.Invalidate();
		this.Cstr_LA[3].ClearString();
		this.Cstr_LA[3].IntToFormat((long)((ulong)this.tmpValue), 1, true);
		this.Cstr_LA[3].AppendFormat("{0}");
		this.text_LA[3].text = this.Cstr_LA[3].ToString();
		this.text_LA[3].SetAllDirty();
		this.text_LA[3].cachedTextGenerator.Invalidate();
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 17 || (!this.bNpcMode && this.Report.Combat.Defcoord != 0) || (this.bNpcMode && this.Report.NPCCombat.DefenceArmyCoord != 0))
		{
			flag3 = true;
			flag2 = true;
		}
		if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 17)
		{
			flag = true;
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
			if (!this.bNpcMode)
			{
				this.Cstr_LF.Append(this.DM.mStringTable.GetStringByID((uint)((ushort)(9778 + (int)this.Report.Combat.Atkcoord))));
			}
			else
			{
				this.Cstr_LF.Append(this.DM.mStringTable.GetStringByID((uint)((ushort)(9778 + (int)this.Report.NPCCombat.AssaultArmyCoord))));
			}
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
			for (int i = 0; i < 4; i++)
			{
				this.text_tmpStr[5 + i].rectTransform.anchoredPosition = new Vector2(this.text_tmpStr[5 + i].rectTransform.anchoredPosition.x, -95f - (float)i * 33f - 33f);
				this.text_LA[i].rectTransform.anchoredPosition = new Vector2(this.text_LA[i].rectTransform.anchoredPosition.x, -95f - (float)i * 33f - 33f);
			}
			if (this.bNpcMode)
			{
				this.text_NpcInfo.rectTransform.anchoredPosition = new Vector2(this.text_NpcInfo.rectTransform.anchoredPosition.x, -310f);
				this.text_NpcTroops[0].rectTransform.anchoredPosition = new Vector2(this.text_NpcTroops[0].rectTransform.anchoredPosition.x, -396f);
				this.text_NpcTroops[1].rectTransform.anchoredPosition = new Vector2(this.text_NpcTroops[1].rectTransform.anchoredPosition.x, -396f);
			}
		}
		else
		{
			for (int j = 0; j < 4; j++)
			{
				this.text_tmpStr[5 + j].rectTransform.anchoredPosition = new Vector2(this.text_tmpStr[5 + j].rectTransform.anchoredPosition.x, -95f - (float)j * 33f);
				this.text_LA[j].rectTransform.anchoredPosition = new Vector2(this.text_LA[j].rectTransform.anchoredPosition.x, -95f - (float)j * 33f);
			}
			if (this.bNpcMode)
			{
				this.text_NpcInfo.rectTransform.anchoredPosition = new Vector2(this.text_NpcInfo.rectTransform.anchoredPosition.x, -277f);
				this.text_NpcTroops[0].rectTransform.anchoredPosition = new Vector2(this.text_NpcTroops[0].rectTransform.anchoredPosition.x, -363f);
				this.text_NpcTroops[1].rectTransform.anchoredPosition = new Vector2(this.text_NpcTroops[1].rectTransform.anchoredPosition.x, -363f);
			}
		}
		this.Cstr_LossValue[1].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_LossValue[1].IntToFormat((long)((ulong)(this.Report.Combat.Summary.DefenceTroopInjure + this.Report.Combat.Summary.DefenceTroopDeath + this.Report.Combat.Summary.LoseTrapNumber + this.Report.Combat.Summary.SaveTrapNumber)), 1, true);
		}
		else
		{
			this.Cstr_LossValue[1].IntToFormat((long)((ulong)(this.Report.NPCCombat.SummaryHead.DefenceTroopInjure + this.Report.NPCCombat.SummaryHead.DefenceTroopDeath + this.Report.NPCCombat.Summary.LoseTrapNumber + this.Report.NPCCombat.Summary.SaveTrapNumber)), 1, true);
		}
		this.Cstr_LossValue[1].AppendFormat("{0}");
		this.text_LossValue[1].text = this.Cstr_LossValue[1].ToString();
		this.text_LossValue[1].SetAllDirty();
		this.text_LossValue[1].cachedTextGenerator.Invalidate();
		this.Cstr_Strength[1].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_Strength[1].uLongToFormat(this.Report.Combat.Summary.DefenceLosePower, 1, true);
		}
		else
		{
			this.Cstr_Strength[1].uLongToFormat(this.Report.NPCCombat.SummaryHead.DefenceLosePower, 1, true);
		}
		this.Cstr_Strength[1].AppendFormat(this.DM.mStringTable.GetStringByID(5322u));
		this.text_Strength[1].text = this.Cstr_Strength[1].ToString();
		this.text_Strength[1].SetAllDirty();
		this.text_Strength[1].cachedTextGenerator.Invalidate();
		this.Cstr_RA[0].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_RA[0].IntToFormat((long)((ulong)this.Report.Combat.Summary.DefenceTroopForce), 1, true);
			this.tmpValue = this.Report.Combat.Summary.DefenceTroopForce;
		}
		else
		{
			this.Cstr_RA[0].IntToFormat((long)((ulong)this.Report.NPCCombat.SummaryHead.DefenceTroopForce), 1, true);
			this.tmpValue = this.Report.NPCCombat.SummaryHead.DefenceTroopForce;
		}
		this.Cstr_RA[0].AppendFormat("{0}");
		this.text_RA[0].text = this.Cstr_RA[0].ToString();
		this.Cstr_RA[1].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_RA[1].IntToFormat((long)((ulong)this.Report.Combat.Summary.DefenceTroopInjure), 1, true);
			this.tmpValue -= this.Report.Combat.Summary.DefenceTroopInjure;
		}
		else
		{
			this.Cstr_RA[1].IntToFormat((long)((ulong)this.Report.NPCCombat.SummaryHead.DefenceTroopInjure), 1, true);
			this.tmpValue -= this.Report.NPCCombat.SummaryHead.DefenceTroopInjure;
		}
		this.Cstr_RA[1].AppendFormat("{0}");
		this.text_RA[1].text = this.Cstr_RA[1].ToString();
		this.Cstr_RA[2].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_RA[2].IntToFormat((long)((ulong)this.Report.Combat.Summary.DefenceTroopDeath), 1, true);
			this.tmpValue -= this.Report.Combat.Summary.DefenceTroopDeath;
		}
		else
		{
			this.Cstr_RA[2].IntToFormat((long)((ulong)this.Report.NPCCombat.SummaryHead.DefenceTroopDeath), 1, true);
			this.tmpValue -= this.Report.NPCCombat.SummaryHead.DefenceTroopDeath;
		}
		this.Cstr_RA[2].AppendFormat("{0}");
		this.text_RA[2].text = this.Cstr_RA[2].ToString();
		this.Cstr_RA[3].ClearString();
		this.Cstr_RA[3].IntToFormat((long)((ulong)this.tmpValue), 1, true);
		this.Cstr_RA[3].AppendFormat("{0}");
		this.text_RA[3].text = this.Cstr_RA[3].ToString();
		this.Cstr_RA[4].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_RA[4].IntToFormat((long)((ulong)this.Report.Combat.Summary.TrapNumber), 1, true);
			this.tmpValue = this.Report.Combat.Summary.TrapNumber;
		}
		else
		{
			this.Cstr_RA[4].IntToFormat((long)((ulong)this.Report.NPCCombat.Summary.TrapNumber), 1, true);
			this.tmpValue = this.Report.NPCCombat.Summary.TrapNumber;
		}
		this.Cstr_RA[4].AppendFormat("{0}");
		this.text_RA[4].text = this.Cstr_RA[4].ToString();
		this.Cstr_RA[5].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_RA[5].IntToFormat((long)((ulong)this.Report.Combat.Summary.SaveTrapNumber), 1, true);
			this.tmpValue -= this.Report.Combat.Summary.SaveTrapNumber;
		}
		else
		{
			this.Cstr_RA[5].IntToFormat((long)((ulong)this.Report.NPCCombat.Summary.SaveTrapNumber), 1, true);
			this.tmpValue -= this.Report.NPCCombat.Summary.SaveTrapNumber;
		}
		this.Cstr_RA[5].AppendFormat("{0}");
		this.text_RA[5].text = this.Cstr_RA[5].ToString();
		this.Cstr_RA[6].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_RA[6].IntToFormat((long)((ulong)this.Report.Combat.Summary.LoseTrapNumber), 1, true);
			this.tmpValue -= this.Report.Combat.Summary.LoseTrapNumber;
		}
		else
		{
			this.Cstr_RA[6].IntToFormat((long)((ulong)this.Report.NPCCombat.Summary.LoseTrapNumber), 1, true);
			this.tmpValue -= this.Report.NPCCombat.Summary.LoseTrapNumber;
		}
		this.Cstr_RA[6].AppendFormat("{0}");
		this.text_RA[6].text = this.Cstr_RA[6].ToString();
		this.Cstr_RA[7].ClearString();
		this.Cstr_RA[7].IntToFormat((long)((ulong)this.tmpValue), 1, true);
		this.Cstr_RA[7].AppendFormat("{0}");
		this.text_RA[7].text = this.Cstr_RA[7].ToString();
		if (this.bNpcMode)
		{
			this.Cstr_NpcTroops.ClearString();
			this.Cstr_NpcTroops.IntToFormat((long)((ulong)this.Report.NPCCombat.ResurrextTotal), 1, true);
			this.Cstr_NpcTroops.AppendFormat("{0}");
			this.text_NpcTroops[1].text = this.Cstr_NpcTroops.ToString();
			this.text_NpcTroops[1].SetAllDirty();
			this.text_NpcTroops[1].cachedTextGenerator.Invalidate();
		}
		for (int k = 0; k < 8; k++)
		{
			this.text_RA[k].SetAllDirty();
			this.text_RA[k].cachedTextGenerator.Invalidate();
		}
		if (flag3)
		{
			for (int l = 0; l < 4; l++)
			{
				this.text_tmpStr[9 + l].rectTransform.anchoredPosition = new Vector2(this.text_tmpStr[9 + l].rectTransform.anchoredPosition.x, -95f - (float)l * 33f - 33f);
				this.text_RA[l].rectTransform.anchoredPosition = new Vector2(this.text_RA[l].rectTransform.anchoredPosition.x, -95f - (float)l * 33f - 33f);
				this.text_tmpStr[13 + l].rectTransform.anchoredPosition = new Vector2(this.text_tmpStr[13 + l].rectTransform.anchoredPosition.x, -264f - (float)l * 33f - 33f);
				this.text_RA[l + 4].rectTransform.anchoredPosition = new Vector2(this.text_RA[l + 4].rectTransform.anchoredPosition.x, -264f - (float)l * 33f - 33f);
			}
		}
		else
		{
			for (int m = 0; m < 4; m++)
			{
				this.text_tmpStr[9 + m].rectTransform.anchoredPosition = new Vector2(this.text_tmpStr[9 + m].rectTransform.anchoredPosition.x, -95f - (float)m * 33f);
				this.text_RA[m].rectTransform.anchoredPosition = new Vector2(this.text_RA[m].rectTransform.anchoredPosition.x, -95f - (float)m * 33f);
				this.text_tmpStr[13 + m].rectTransform.anchoredPosition = new Vector2(this.text_tmpStr[13 + m].rectTransform.anchoredPosition.x, -264f - (float)m * 33f);
				this.text_RA[m + 4].rectTransform.anchoredPosition = new Vector2(this.text_RA[m + 4].rectTransform.anchoredPosition.x, -264f - (float)m * 33f);
			}
		}
		if (flag2)
		{
			this.Cstr_RF.ClearString();
			this.Cstr_RF.Append(this.DM.mStringTable.GetStringByID(9788u));
			if (!this.bNpcMode)
			{
				this.Cstr_RF.Append(this.DM.mStringTable.GetStringByID((uint)((ushort)(9778 + (int)this.Report.Combat.Defcoord))));
			}
			else
			{
				this.Cstr_RF.Append(this.DM.mStringTable.GetStringByID((uint)((ushort)(9778 + (int)this.Report.NPCCombat.DefenceArmyCoord))));
			}
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
		this.Cstr_DW[0].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_DW[0].IntToFormat((long)((ulong)this.Report.Combat.Summary.WallDefence), 1, true);
			this.tmpValue = this.Report.Combat.Summary.WallDefence;
		}
		else
		{
			this.Cstr_DW[0].IntToFormat((long)((ulong)this.Report.NPCCombat.Summary.WallDefence), 1, true);
			this.tmpValue = this.Report.NPCCombat.Summary.WallDefence;
		}
		this.Cstr_DW[0].AppendFormat("{0}");
		this.text_DW[0].text = this.Cstr_DW[0].ToString();
		this.Cstr_DW[1].ClearString();
		if (!this.bNpcMode)
		{
			this.Cstr_DW[1].IntToFormat((long)((ulong)this.Report.Combat.Summary.WallDamage), 1, true);
			this.tmpValue -= this.Report.Combat.Summary.WallDamage;
		}
		else
		{
			this.Cstr_DW[1].IntToFormat((long)((ulong)this.Report.NPCCombat.Summary.WallDamage), 1, true);
			this.tmpValue -= this.Report.NPCCombat.Summary.WallDamage;
		}
		this.Cstr_DW[1].AppendFormat("{0}");
		this.text_DW[1].text = this.Cstr_DW[1].ToString();
		this.Cstr_DW[2].ClearString();
		this.Cstr_DW[2].IntToFormat((long)((ulong)this.tmpValue), 1, true);
		this.Cstr_DW[2].AppendFormat("{0}");
		this.text_DW[2].text = this.Cstr_DW[2].ToString();
		for (int n = 0; n < 3; n++)
		{
			this.text_DW[n].SetAllDirty();
			this.text_DW[n].cachedTextGenerator.Invalidate();
		}
		if (!this.bNpcMode && this.Report.Combat.AssaultKingdomID != this.Report.Combat.DefenceKingdomID)
		{
			this.Img_Country[0].gameObject.SetActive(true);
			this.Img_Country[1].gameObject.SetActive(true);
		}
		else
		{
			this.Img_Country[0].gameObject.SetActive(false);
			this.Img_Country[1].gameObject.SetActive(false);
		}
		this.tmpH -= 281f;
		this.Cstr_Offensive[0].ClearString();
		this.Cstr_Offensive[1].ClearString();
		if (this.IsAttack)
		{
			this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(5315u));
			this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(5317u));
			this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(5316u));
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
			if (!this.bNpcMode && this.Report.Combat.Summary.IsLeader == 1)
			{
				this.Img_Muster[0].gameObject.SetActive(true);
			}
			else if (this.bNpcMode && this.Report.NPCCombat.Summary.IsLeader == 1)
			{
				this.Img_Muster[0].gameObject.SetActive(true);
			}
			this.Img_Bf_BG_L[0].sprite = this.SArray.m_Sprites[19];
			this.Img_Bf_BG_L[1].sprite = this.SArray.m_Sprites[20];
			this.Img_Bf_BG_L[2].sprite = this.SArray.m_Sprites[19];
			this.Img_Bf_BG_R[0].sprite = this.SArray.m_Sprites[21];
			this.Img_Bf_BG_R[1].sprite = this.SArray.m_Sprites[22];
			this.Img_Bf_BG_R[2].sprite = this.SArray.m_Sprites[21];
		}
		else
		{
			this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(5315u));
			this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(5316u));
			this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(5317u));
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
			this.Img_Bf_BG_L[0].sprite = this.SArray.m_Sprites[21];
			this.Img_Bf_BG_L[1].sprite = this.SArray.m_Sprites[22];
			this.Img_Bf_BG_L[2].sprite = this.SArray.m_Sprites[21];
			this.Img_Bf_BG_R[0].sprite = this.SArray.m_Sprites[19];
			this.Img_Bf_BG_R[1].sprite = this.SArray.m_Sprites[20];
			this.Img_Bf_BG_R[2].sprite = this.SArray.m_Sprites[19];
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
		if (this.bQuanmier)
		{
			this.tmpH = 0f;
			this.text_QuanmierNpcInfo.gameObject.SetActive(false);
			this.text_QuanmierNpcTroops[0].gameObject.SetActive(false);
			this.text_QuanmierNpcTroops[1].gameObject.SetActive(false);
			this.Cstr_FightingKind.ClearString();
			if (!this.bNpcMode)
			{
				switch (this.Report.Combat.Result)
				{
				case CombatReportResultType.ECRR_COMBATMASSIVEDEFEAT:
					this.Cstr_FightingKind.Append(this.DM.mStringTable.GetStringByID(5385u));
					this.Cstr_Quanmie[0].ClearString();
					this.Cstr_Quanmie[1].ClearString();
					this.Cstr_Quanmie[2].ClearString();
					this.Cstr_Quanmie[3].ClearString();
					if (this.IsAttack)
					{
						this.Cstr_Quanmie[0].uLongToFormat(this.Report.Combat.Summary.AssaultLosePower, 1, true);
						StringManager.IntToStr(this.Cstr_Quanmie[1], (long)((ulong)this.Report.Combat.Summary.AssaultTroopForce), 1, true);
						this.text_Quanmie[5].text = this.Cstr_Quanmie[1].ToString();
						StringManager.IntToStr(this.Cstr_Quanmie[2], (long)((ulong)this.Report.Combat.Summary.AssaultTroopInjure), 1, true);
						this.text_Quanmie[6].text = this.Cstr_Quanmie[2].ToString();
						StringManager.IntToStr(this.Cstr_Quanmie[3], (long)((ulong)this.Report.Combat.Summary.AssaultTroopDeath), 1, true);
						this.text_Quanmie[7].text = this.Cstr_Quanmie[3].ToString();
					}
					else
					{
						this.Cstr_Quanmie[0].uLongToFormat(this.Report.Combat.Summary.DefenceLosePower, 1, true);
						StringManager.IntToStr(this.Cstr_Quanmie[1], (long)((ulong)this.Report.Combat.Summary.DefenceTroopForce), 1, true);
						this.text_Quanmie[5].text = this.Cstr_Quanmie[1].ToString();
						StringManager.IntToStr(this.Cstr_Quanmie[2], (long)((ulong)this.Report.Combat.Summary.DefenceTroopInjure), 1, true);
						this.text_Quanmie[6].text = this.Cstr_Quanmie[2].ToString();
						StringManager.IntToStr(this.Cstr_Quanmie[3], (long)((ulong)this.Report.Combat.Summary.DefenceTroopDeath), 1, true);
						this.text_Quanmie[7].text = this.Cstr_Quanmie[3].ToString();
					}
					this.Cstr_Quanmie[0].AppendFormat(this.DM.mStringTable.GetStringByID(5322u));
					this.text_Quanmie[1].text = this.Cstr_Quanmie[0].ToString();
					this.text_Quanmie[1].SetAllDirty();
					this.text_Quanmie[1].cachedTextGenerator.Invalidate();
					this.text_Quanmie[5].SetAllDirty();
					this.text_Quanmie[5].cachedTextGenerator.Invalidate();
					this.text_Quanmie[6].SetAllDirty();
					this.text_Quanmie[6].cachedTextGenerator.Invalidate();
					this.text_Quanmie[7].SetAllDirty();
					this.text_Quanmie[7].cachedTextGenerator.Invalidate();
					break;
				case CombatReportResultType.ECRR_DEFENDERSHIELDUP:
				{
					CString cstring3 = StringManager.Instance.StaticString1024();
					cstring.ClearString();
					cstring2.ClearString();
					cstring3.ClearString();
					cstring2.Append(this.Report.Combat.DefenceName);
					if (this.Report.Combat.DefenceAllianceTag.Length != 0)
					{
						cstring3.Append(this.Report.Combat.DefenceAllianceTag);
						if (this.Report.Combat.KingdomID != this.Report.Combat.DefenceKingdomID)
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, this.Report.Combat.DefenceKingdomID, this.GUIM.IsArabic);
						}
						else
						{
							this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring3, 0, this.GUIM.IsArabic);
						}
					}
					else if (this.Report.Combat.KingdomID != this.Report.Combat.DefenceKingdomID)
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, this.Report.Combat.DefenceKingdomID, this.GUIM.IsArabic);
					}
					else
					{
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, null, 0, this.GUIM.IsArabic);
					}
					this.Cstr_FightingKind.Append(cstring);
					this.Cstr_FightingKind.Append(this.DM.mStringTable.GetStringByID(626u));
					break;
				}
				case CombatReportResultType.ECRR_ALLYDEFENDER:
					this.Cstr_FightingKind.Append(this.DM.mStringTable.GetStringByID(652u));
					break;
				case CombatReportResultType.ECRR_TAKEOVERWONDER:
					if (this.Report.Combat.Side == 0)
					{
						this.Cstr_FightingKind.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
						this.Cstr_FightingKind.AppendFormat(this.DM.mStringTable.GetStringByID(7264u));
						this.Cstr_Text.ClearString();
						if (this.Report.Combat.CombatPoint == 0 || this.Report.Combat.KingdomID == ActivityManager.Instance.KOWKingdomID)
						{
							this.Cstr_Text.StringToFormat(this.DM.mStringTable.GetStringByID(9308u));
						}
						else
						{
							this.Cstr_Text.StringToFormat(this.DM.mStringTable.GetStringByID(9309u));
						}
						this.Cstr_Text.AppendFormat(this.DM.mStringTable.GetStringByID(7265u));
						this.text_Summary.text = this.Cstr_Text.ToString();
					}
					else
					{
						CString cstring4 = StringManager.Instance.StaticString1024();
						cstring.ClearString();
						cstring2.ClearString();
						cstring4.ClearString();
						cstring4.Append(this.Report.Combat.AssaultAllianceTag);
						cstring2.Append(this.Report.Combat.AssaultName);
						this.GUIM.FormatRoleNameForChat(cstring, cstring2, cstring4, 0, this.GUIM.IsArabic);
						if (this.GUIM.IsArabic)
						{
							this.Cstr_FightingKind.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
							this.Cstr_FightingKind.StringToFormat(cstring);
						}
						else
						{
							this.Cstr_FightingKind.StringToFormat(cstring);
							this.Cstr_FightingKind.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
						}
						this.Cstr_FightingKind.AppendFormat(this.DM.mStringTable.GetStringByID(7261u));
						this.Cstr_Text.ClearString();
						if (this.Report.Combat.CombatPoint == 0 || this.Report.Combat.KingdomID == ActivityManager.Instance.KOWKingdomID)
						{
							this.Cstr_Text.StringToFormat(this.DM.mStringTable.GetStringByID(9308u));
						}
						else
						{
							this.Cstr_Text.StringToFormat(this.DM.mStringTable.GetStringByID(9309u));
						}
						this.Cstr_Text.AppendFormat(this.DM.mStringTable.GetStringByID(7265u));
						this.text_Summary.text = this.Cstr_Text.ToString();
					}
					break;
				}
			}
			else if (this.bNpcMode)
			{
				this.Cstr_Quanmie[0].ClearString();
				this.Cstr_Quanmie[1].ClearString();
				this.Cstr_Quanmie[2].ClearString();
				this.Cstr_Quanmie[3].ClearString();
				StringManager.IntToStr(this.Cstr_Quanmie[1], (long)((ulong)this.Report.NPCCombat.SummaryHead.AssaultTroopForce), 1, true);
				this.text_Quanmie[5].text = this.Cstr_Quanmie[1].ToString();
				StringManager.IntToStr(this.Cstr_Quanmie[2], (long)((ulong)this.Report.NPCCombat.SummaryHead.AssaultTroopInjure), 1, true);
				this.text_Quanmie[6].text = this.Cstr_Quanmie[2].ToString();
				StringManager.IntToStr(this.Cstr_Quanmie[3], (long)((ulong)this.Report.NPCCombat.SummaryHead.AssaultTroopDeath), 1, true);
				this.text_Quanmie[7].text = this.Cstr_Quanmie[3].ToString();
				this.Cstr_Quanmie[0].uLongToFormat(this.Report.NPCCombat.SummaryHead.AssaultLosePower, 1, true);
				this.Cstr_Quanmie[0].AppendFormat(this.DM.mStringTable.GetStringByID(5322u));
				this.text_Quanmie[1].text = this.Cstr_Quanmie[0].ToString();
				this.text_Quanmie[1].SetAllDirty();
				this.text_Quanmie[1].cachedTextGenerator.Invalidate();
				this.text_Quanmie[5].SetAllDirty();
				this.text_Quanmie[5].cachedTextGenerator.Invalidate();
				this.text_Quanmie[6].SetAllDirty();
				this.text_Quanmie[6].cachedTextGenerator.Invalidate();
				this.text_Quanmie[7].SetAllDirty();
				this.text_Quanmie[7].cachedTextGenerator.Invalidate();
				this.text_QuanmierNpcInfo.gameObject.SetActive(true);
				this.text_QuanmierNpcTroops[0].gameObject.SetActive(true);
				this.text_QuanmierNpcTroops[1].gameObject.SetActive(true);
				this.Cstr_FightingKind.Append(this.DM.mStringTable.GetStringByID(5385u));
				if (this.bNpcMode)
				{
					this.Cstr_QuanmieNpcTroops.ClearString();
					this.Cstr_QuanmieNpcTroops.IntToFormat((long)((ulong)this.Report.NPCCombat.ResurrextTotal), 1, true);
					this.Cstr_QuanmieNpcTroops.AppendFormat("{0}");
					this.text_QuanmierNpcTroops[1].text = this.Cstr_QuanmieNpcTroops.ToString();
					this.text_QuanmierNpcTroops[1].SetAllDirty();
					this.text_QuanmierNpcTroops[1].cachedTextGenerator.Invalidate();
				}
			}
			this.text_Summary.SetAllDirty();
			this.text_Summary.cachedTextGenerator.Invalidate();
			this.text_FightingKind.text = this.Cstr_FightingKind.ToString();
			this.text_FightingKind.SetAllDirty();
			this.text_FightingKind.cachedTextGenerator.Invalidate();
			this.Img_Quanmie.gameObject.SetActive(true);
			this.text_FightingKind.rectTransform.anchoredPosition = new Vector2(this.text_FightingKind.rectTransform.anchoredPosition.x, -36f);
			if (!this.bNpcMode && ((this.IsAttack && this.Report.Combat.Summary.AssaultLosePower == 0UL) || (!this.IsAttack && this.Report.Combat.Summary.DefenceLosePower == 0UL)))
			{
				this.text_FightingKind.rectTransform.anchoredPosition = new Vector2(this.text_FightingKind.rectTransform.anchoredPosition.x, -152f);
				this.Img_Quanmie.gameObject.SetActive(false);
			}
			else if (this.bNpcMode)
			{
				if (this.text_QuanmierNpcInfo.gameObject.activeSelf)
				{
					this.text_FightingKind.rectTransform.anchoredPosition = new Vector2(this.text_FightingKind.rectTransform.anchoredPosition.x, -36f);
				}
				else
				{
					this.text_FightingKind.rectTransform.anchoredPosition = new Vector2(this.text_FightingKind.rectTransform.anchoredPosition.x, -36f);
				}
			}
			if (this.text_FightingKind.preferredHeight > 68f)
			{
				this.text_FightingKind.rectTransform.sizeDelta = new Vector2(this.text_FightingKind.rectTransform.sizeDelta.x, this.text_FightingKind.preferredHeight);
				this.text_FightingKind.alignment = TextAnchor.UpperCenter;
			}
			else
			{
				this.text_FightingKind.rectTransform.sizeDelta = new Vector2(this.text_FightingKind.rectTransform.sizeDelta.x, 68f);
				this.text_FightingKind.alignment = TextAnchor.MiddleCenter;
			}
			this.HeroRT.gameObject.SetActive(false);
			this.SummaryRT.transform.gameObject.SetActive(false);
			this.QuanmieRT.gameObject.SetActive(true);
			this.tmpH1 = this.ReplayerRT.anchoredPosition.y - this.ReplayerRT.sizeDelta.y;
			this.QuanmieRT.anchoredPosition = new Vector2(this.QuanmieRT.anchoredPosition.x, this.tmpH1);
			this.tmpH1 = 441f + (this.ReplayerRT.anchoredPosition.y - this.ReplayerRT.sizeDelta.y);
			this.CheckQuanmieBuff();
			if (this.text_QuanmierNpcInfo.gameObject.activeSelf)
			{
				this.QuanmieRT.sizeDelta = new Vector2(this.QuanmieRT.sizeDelta.x, this.tmpH1 + 65f);
				this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 506f + this.tmpH2);
			}
			else
			{
				this.QuanmieRT.sizeDelta = new Vector2(this.QuanmieRT.sizeDelta.x, this.tmpH1);
				this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 441f + this.tmpH2);
			}
			this.btn_Replay.gameObject.SetActive(false);
		}
		else
		{
			this.tmpH1 = 0f;
			this.QuanmieRT.gameObject.SetActive(false);
			this.CheckPetSkillShow();
			this.tmpRC = this.btn_Details.transform.GetComponent<RectTransform>();
			if ((!this.bNpcMode && this.Report.Combat.CombatPointKind == POINT_KIND.PK_CITY && this.Report.Combat.Side < 4) || (this.bNpcMode && this.Report.NPCCombat.CombatPointKind == POINT_KIND.PK_CITY && this.Report.NPCCombat.Side < 4))
			{
				if (flag3)
				{
					this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x, -1154.5f + this.tmpH1);
					this.Img_CWall_P[0].rectTransform.anchoredPosition = new Vector2(this.Img_CWall_P[0].rectTransform.anchoredPosition.x, -935f);
					this.Img_CWall_P[1].rectTransform.anchoredPosition = new Vector2(this.Img_CWall_P[1].rectTransform.anchoredPosition.x, -935f);
					this.PetSkillRT_L.anchoredPosition = new Vector2(this.PetSkillRT_L.anchoredPosition.x, -1119f);
					this.PetSkillRT_R.anchoredPosition = new Vector2(this.PetSkillRT_R.anchoredPosition.x, -1119f);
				}
				else
				{
					this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x, -1121.5f + this.tmpH1);
					this.Img_CWall_P[0].rectTransform.anchoredPosition = new Vector2(this.Img_CWall_P[0].rectTransform.anchoredPosition.x, -902f);
					this.Img_CWall_P[1].rectTransform.anchoredPosition = new Vector2(this.Img_CWall_P[1].rectTransform.anchoredPosition.x, -902f);
					this.PetSkillRT_L.anchoredPosition = new Vector2(this.PetSkillRT_L.anchoredPosition.x, -1086f);
					this.PetSkillRT_R.anchoredPosition = new Vector2(this.PetSkillRT_R.anchoredPosition.x, -1086f);
				}
				if (flag3)
				{
					this.Img_Army[0].rectTransform.sizeDelta = new Vector2(this.Img_Army[0].rectTransform.sizeDelta.x, 531f);
					this.Img_Army[1].rectTransform.sizeDelta = new Vector2(this.Img_Army[1].rectTransform.sizeDelta.x, 531f);
				}
				else
				{
					this.Img_Army[0].rectTransform.sizeDelta = new Vector2(this.Img_Army[0].rectTransform.sizeDelta.x, 498f);
					this.Img_Army[1].rectTransform.sizeDelta = new Vector2(this.Img_Army[1].rectTransform.sizeDelta.x, 498f);
				}
				for (int num3 = 0; num3 < 4; num3++)
				{
					this.text_tmpStr[13 + num3].gameObject.SetActive(true);
					this.text_RA[4 + num3].gameObject.SetActive(true);
				}
				this.Img_CWall_P[0].gameObject.SetActive(true);
				this.Img_CWall_P[1].gameObject.SetActive(true);
				for (int num4 = 0; num4 < 6; num4++)
				{
					this.text_tmpStr[17 + num4].gameObject.SetActive(true);
				}
				this.text_Dominance[1].gameObject.SetActive(true);
				this.Img_Vip[1].gameObject.SetActive(true);
			}
			else
			{
				this.tmpH += 100f;
				this.tmpH += 281f;
				this.tmpH -= 33f;
				if (flag3)
				{
					this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x, -806.5f + this.tmpH1);
				}
				else
				{
					this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x, -773.5f + this.tmpH1);
				}
				if (flag3)
				{
					this.Img_Army[0].rectTransform.sizeDelta = new Vector2(this.Img_Army[0].rectTransform.sizeDelta.x, 431f);
					this.Img_Army[1].rectTransform.sizeDelta = new Vector2(this.Img_Army[1].rectTransform.sizeDelta.x, 431f);
					this.PetSkillRT_L.anchoredPosition = new Vector2(this.PetSkillRT_L.anchoredPosition.x, -769f);
					this.PetSkillRT_R.anchoredPosition = new Vector2(this.PetSkillRT_R.anchoredPosition.x, -769f);
				}
				else
				{
					this.Img_Army[0].rectTransform.sizeDelta = new Vector2(this.Img_Army[0].rectTransform.sizeDelta.x, 398f);
					this.Img_Army[1].rectTransform.sizeDelta = new Vector2(this.Img_Army[1].rectTransform.sizeDelta.x, 398f);
					this.PetSkillRT_L.anchoredPosition = new Vector2(this.PetSkillRT_L.anchoredPosition.x, -736f);
					this.PetSkillRT_R.anchoredPosition = new Vector2(this.PetSkillRT_R.anchoredPosition.x, -736f);
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
				if (!this.bNpcMode && this.Report.Combat.CombatPointKind == POINT_KIND.PK_YOLK && this.IsAttack && this.Report.Combat.DefenceAllianceTag.Length == 0)
				{
					this.text_Dominance[1].gameObject.SetActive(false);
					this.Img_Vip[1].gameObject.SetActive(false);
				}
				else
				{
					this.text_Dominance[1].gameObject.SetActive(true);
					this.Img_Vip[1].gameObject.SetActive(true);
				}
			}
			this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, -this.tmpH);
			this.btn_Replay.gameObject.SetActive(true);
		}
		if (this.BossRT != null)
		{
			this.BossRT.gameObject.SetActive(false);
		}
		this.bSetFSShow = false;
		this.LightT1.gameObject.SetActive(true);
		this.text_Summary.gameObject.SetActive(true);
	}

	// Token: 0x06001B2A RID: 6954 RVA: 0x002FBF50 File Offset: 0x002FA150
	public void CheckPetSkillShow()
	{
		for (int i = 0; i < 10; i++)
		{
			this.btn_PetSkill_L[i].gameObject.SetActive(false);
		}
		for (int j = 0; j < 10; j++)
		{
			this.btn_PetSkill_R[j].gameObject.SetActive(false);
		}
		this.text_Buff[8].gameObject.SetActive(false);
		this.text_Buff[3].gameObject.SetActive(false);
		this.text_Buff[7].gameObject.SetActive(false);
		if (this.bDoNotShow)
		{
			if (this.mA_Skill_L > 0 || this.mD_Skill_R > 0 || this.mDeBf_A_L > 0 || this.mDeBf_D_R > 0)
			{
				this.PetSkillRT_L.gameObject.SetActive(true);
				this.PetSkillRT_R.gameObject.SetActive(true);
				this.tmpH += 97f;
				this.tmpH -= 41f;
				this.tmpH -= 166f;
				this.tmpH1 -= 106f;
				this.text_Buff[8].gameObject.SetActive(true);
				this.Img_Bf_BG_L[0].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_L[0].rectTransform.sizeDelta.x, 169f);
				this.Img_Bf_BG_R[0].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_R[0].rectTransform.sizeDelta.x, 169f);
				this.Img_Bf_BG_L[1].gameObject.SetActive(false);
				this.Img_Bf_BG_R[1].gameObject.SetActive(false);
			}
			else
			{
				this.PetSkillRT_L.gameObject.SetActive(false);
				this.PetSkillRT_R.gameObject.SetActive(false);
			}
		}
		else
		{
			CString cstring = StringManager.Instance.StaticString1024();
			for (int k = 0; k < this.mA_Skill_L; k++)
			{
				this.btn_PetSkill_L[k].gameObject.SetActive(true);
				this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_A_Skill_ID[k]);
				cstring.ClearString();
				cstring.Append('s');
				cstring.IntToFormat((long)this.skill.Icon, 5, false);
				cstring.AppendFormat("{0}");
				this.Img_PetSkill_L[k].sprite = this.GUIM.LoadSkillSprite(cstring);
			}
			for (int l = 0; l < this.mD_Skill_R; l++)
			{
				this.btn_PetSkill_R[l].gameObject.SetActive(true);
				this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_D_Skill_ID[l]);
				cstring.ClearString();
				cstring.Append('s');
				cstring.IntToFormat((long)this.skill.Icon, 5, false);
				cstring.AppendFormat("{0}");
				this.Img_PetSkill_R[l].sprite = this.GUIM.LoadSkillSprite(cstring);
			}
			if (this.mA_Skill_L == 0)
			{
				this.text_Buff[3].gameObject.SetActive(true);
			}
			else
			{
				this.text_Buff[3].gameObject.SetActive(false);
			}
			if (this.mDeBf_A_L == 0)
			{
				this.text_Buff[1].gameObject.SetActive(true);
			}
			else
			{
				this.text_Buff[1].gameObject.SetActive(false);
			}
			if (this.mD_Skill_R == 0)
			{
				this.text_Buff[7].gameObject.SetActive(true);
			}
			else
			{
				this.text_Buff[7].gameObject.SetActive(false);
			}
			if (this.mDeBf_D_R == 0)
			{
				this.text_Buff[5].gameObject.SetActive(true);
			}
			else
			{
				this.text_Buff[5].gameObject.SetActive(false);
			}
			this.text_Buff[0].gameObject.SetActive(false);
			this.text_Buff[4].gameObject.SetActive(false);
			if (this.mDeBf_A_L > 0 || this.mDeBf_D_R > 0)
			{
				this.PetSkillRT_L.gameObject.SetActive(true);
				this.PetSkillRT_R.gameObject.SetActive(true);
				this.text_Buff[0].gameObject.SetActive(true);
				this.text_Buff[4].gameObject.SetActive(true);
				this.tmpH += 97f;
				this.tmpH -= 41f;
				this.tmpH1 = 56f;
				this.Img_Bf_BG_L[0].gameObject.SetActive(true);
				if (this.mA_Skill_L > 5 || this.mD_Skill_R > 5)
				{
					this.tmpH -= 197f;
					this.tmpH1 -= 197f;
					this.Img_Bf_BG_L[0].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_L[0].rectTransform.sizeDelta.x, 197f);
					this.Img_Bf_BG_R[0].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_R[0].rectTransform.sizeDelta.x, 197f);
					this.Img_Bf_BG_L[1].rectTransform.anchoredPosition = new Vector2(this.Img_Bf_BG_L[1].rectTransform.anchoredPosition.x, -238f);
					this.Img_Bf_BG_R[1].rectTransform.anchoredPosition = new Vector2(this.Img_Bf_BG_R[1].rectTransform.anchoredPosition.x, -238f);
				}
				else if (this.mA_Skill_L > 0 || this.mD_Skill_R > 0)
				{
					this.tmpH -= 125f;
					this.tmpH1 -= 125f;
					this.Img_Bf_BG_L[0].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_L[0].rectTransform.sizeDelta.x, 125f);
					this.Img_Bf_BG_R[0].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_R[0].rectTransform.sizeDelta.x, 125f);
					this.Img_Bf_BG_L[1].rectTransform.anchoredPosition = new Vector2(this.Img_Bf_BG_L[1].rectTransform.anchoredPosition.x, -166f);
					this.Img_Bf_BG_R[1].rectTransform.anchoredPosition = new Vector2(this.Img_Bf_BG_R[1].rectTransform.anchoredPosition.x, -166f);
				}
				else
				{
					this.tmpH -= 50f;
					this.tmpH1 -= 50f;
					this.Img_Bf_BG_L[0].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_L[0].rectTransform.sizeDelta.x, 50f);
					this.Img_Bf_BG_R[0].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_R[0].rectTransform.sizeDelta.x, 50f);
					this.Img_Bf_BG_L[1].rectTransform.anchoredPosition = new Vector2(this.Img_Bf_BG_L[1].rectTransform.anchoredPosition.x, -91f);
					this.Img_Bf_BG_R[1].rectTransform.anchoredPosition = new Vector2(this.Img_Bf_BG_R[1].rectTransform.anchoredPosition.x, -91f);
				}
				this.PetSkill_BfIcon_RT_L[0].gameObject.SetActive(false);
				this.PetSkill_BfIcon_RT_L[1].gameObject.SetActive(false);
				if (this.mA_Skill_L < 5)
				{
					this.PetSkill_BfIcon_RT_L[0].gameObject.SetActive(true);
					this.PetSkill_BfIcon_RT_L[1].gameObject.SetActive(false);
					this.PetSkill_BfIcon_RT_L[0].anchoredPosition = new Vector2(35f, this.PetSkill_BfIcon_RT_L[0].anchoredPosition.y);
				}
				else
				{
					this.PetSkill_BfIcon_RT_L[0].gameObject.SetActive(true);
					this.PetSkill_BfIcon_RT_L[1].gameObject.SetActive(true);
					this.PetSkill_BfIcon_RT_L[0].anchoredPosition = new Vector2(0f, this.PetSkill_BfIcon_RT_L[0].anchoredPosition.y);
				}
				this.Img_Bf_BG_R[0].gameObject.SetActive(true);
				this.PetSkill_BfIcon_RT_R[0].gameObject.SetActive(false);
				this.PetSkill_BfIcon_RT_R[1].gameObject.SetActive(false);
				if (this.mD_Skill_R < 5)
				{
					this.PetSkill_BfIcon_RT_R[0].gameObject.SetActive(true);
					this.PetSkill_BfIcon_RT_R[1].gameObject.SetActive(false);
					this.PetSkill_BfIcon_RT_R[0].anchoredPosition = new Vector2(35f, this.PetSkill_BfIcon_RT_R[0].anchoredPosition.y);
				}
				else
				{
					this.PetSkill_BfIcon_RT_R[0].gameObject.SetActive(true);
					this.PetSkill_BfIcon_RT_R[1].gameObject.SetActive(true);
					this.PetSkill_BfIcon_RT_R[0].anchoredPosition = new Vector2(0f, this.PetSkill_BfIcon_RT_R[0].anchoredPosition.y);
				}
				this.Img_Bf_BG_L[1].gameObject.SetActive(true);
				this.Img_Bf_BG_R[1].gameObject.SetActive(true);
				this.tmpH -= 50f;
				this.tmpH1 -= 50f;
				this.DeBuff_BfIcon_RT_L[0].gameObject.SetActive(true);
				this.DeBuff_BfIcon_RT_R[0].gameObject.SetActive(true);
				if (this.mDeBf_A_L > 5 || this.mDeBf_D_R > 5)
				{
					this.tmpH -= 313f;
					this.tmpH1 -= 313f;
					this.Img_Bf_BG_L[2].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_L[2].rectTransform.sizeDelta.x, 313f);
					this.Img_Bf_BG_R[2].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_L[2].rectTransform.sizeDelta.x, 313f);
				}
				else
				{
					this.tmpH -= 241f;
					this.tmpH1 -= 241f;
					this.Img_Bf_BG_L[2].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_L[2].rectTransform.sizeDelta.x, 241f);
					this.Img_Bf_BG_R[2].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_L[2].rectTransform.sizeDelta.x, 241f);
				}
				for (int m = 0; m < 10; m++)
				{
					this.btn_DeBuff_L[m].gameObject.SetActive(false);
				}
				if (this.mDeBf_A_L < 5)
				{
					this.DeBuff_BfIcon_RT_L[0].gameObject.SetActive(true);
					this.DeBuff_BfIcon_RT_L[1].gameObject.SetActive(false);
					this.DeBuff_BfIcon_RT_L[0].anchoredPosition = new Vector2(35f, this.DeBuff_BfIcon_RT_L[0].anchoredPosition.y);
				}
				else
				{
					this.DeBuff_BfIcon_RT_L[0].gameObject.SetActive(true);
					this.DeBuff_BfIcon_RT_L[1].gameObject.SetActive(true);
					this.DeBuff_BfIcon_RT_L[0].anchoredPosition = new Vector2(0f, this.DeBuff_BfIcon_RT_L[0].anchoredPosition.y);
				}
				for (int n = 0; n < this.mDeBf_A_L; n++)
				{
					this.btn_DeBuff_L[n].gameObject.SetActive(true);
					this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_A_DeBf_Skill_ID[n]);
					cstring.ClearString();
					cstring.Append('s');
					cstring.IntToFormat((long)this.skill.Icon, 5, false);
					cstring.AppendFormat("{0}");
					this.Img_DeBuff_L[n].sprite = this.GUIM.LoadSkillSprite(cstring);
				}
				for (int num = 0; num < 10; num++)
				{
					this.btn_DeBuff_R[num].gameObject.SetActive(false);
				}
				if (this.mDeBf_D_R < 5)
				{
					this.DeBuff_BfIcon_RT_R[0].gameObject.SetActive(true);
					this.DeBuff_BfIcon_RT_R[1].gameObject.SetActive(false);
					this.DeBuff_BfIcon_RT_R[0].anchoredPosition = new Vector2(35f, this.DeBuff_BfIcon_RT_R[0].anchoredPosition.y);
				}
				else
				{
					this.DeBuff_BfIcon_RT_R[0].gameObject.SetActive(true);
					this.DeBuff_BfIcon_RT_R[1].gameObject.SetActive(true);
					this.DeBuff_BfIcon_RT_R[0].anchoredPosition = new Vector2(0f, this.DeBuff_BfIcon_RT_R[0].anchoredPosition.y);
				}
				for (int num2 = 0; num2 < this.mDeBf_D_R; num2++)
				{
					this.btn_DeBuff_R[num2].gameObject.SetActive(true);
					this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_D_DeBf_Skill_ID[num2]);
					cstring.ClearString();
					cstring.Append('s');
					cstring.IntToFormat((long)this.skill.Icon, 5, false);
					cstring.AppendFormat("{0}");
					this.Img_DeBuff_R[num2].sprite = this.GUIM.LoadSkillSprite(cstring);
				}
			}
			else
			{
				this.Img_Bf_BG_L[1].gameObject.SetActive(false);
				this.Img_Bf_BG_R[1].gameObject.SetActive(false);
				if (this.mA_Skill_L > 0 || this.mD_Skill_R > 0)
				{
					this.PetSkillRT_L.gameObject.SetActive(true);
					this.PetSkillRT_R.gameObject.SetActive(true);
					this.tmpH -= 41f;
					this.tmpH += 97f;
					this.tmpH1 += 56f;
					this.Img_Bf_BG_L[0].gameObject.SetActive(true);
					if (this.mA_Skill_L >= 5 || this.mD_Skill_R >= 5)
					{
						this.tmpH -= 313f;
						this.tmpH1 -= 313f;
						this.Img_Bf_BG_L[0].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_L[0].rectTransform.sizeDelta.x, 313f);
						this.Img_Bf_BG_R[0].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_R[0].rectTransform.sizeDelta.x, 313f);
					}
					else if (this.mA_Skill_L > 0 || this.mD_Skill_R > 0)
					{
						this.tmpH -= 241f;
						this.tmpH1 -= 241f;
						this.Img_Bf_BG_L[0].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_L[0].rectTransform.sizeDelta.x, 241f);
						this.Img_Bf_BG_R[0].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_R[0].rectTransform.sizeDelta.x, 241f);
					}
					else
					{
						this.tmpH -= 166f;
						this.tmpH1 -= 166f;
						this.Img_Bf_BG_L[0].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_L[0].rectTransform.sizeDelta.x, 166f);
						this.Img_Bf_BG_R[0].rectTransform.sizeDelta = new Vector2(this.Img_Bf_BG_R[0].rectTransform.sizeDelta.x, 166f);
					}
					if (this.mA_Skill_L == 0)
					{
						this.PetSkill_BfIcon_RT_L[0].gameObject.SetActive(false);
						this.PetSkill_BfIcon_RT_L[1].gameObject.SetActive(false);
					}
					else if (this.mA_Skill_L < 5)
					{
						this.PetSkill_BfIcon_RT_L[0].gameObject.SetActive(true);
						this.PetSkill_BfIcon_RT_L[1].gameObject.SetActive(false);
						this.PetSkill_BfIcon_RT_L[0].anchoredPosition = new Vector2(35f, this.PetSkill_BfIcon_RT_L[0].anchoredPosition.y);
					}
					else
					{
						this.PetSkill_BfIcon_RT_L[0].gameObject.SetActive(true);
						this.PetSkill_BfIcon_RT_L[1].gameObject.SetActive(true);
						this.PetSkill_BfIcon_RT_L[0].anchoredPosition = new Vector2(0f, this.PetSkill_BfIcon_RT_L[0].anchoredPosition.y);
					}
					this.Img_Bf_BG_R[0].gameObject.SetActive(true);
					if (this.mD_Skill_R == 0)
					{
						this.PetSkill_BfIcon_RT_R[0].gameObject.SetActive(false);
						this.PetSkill_BfIcon_RT_R[1].gameObject.SetActive(false);
					}
					else if (this.mD_Skill_R < 5)
					{
						this.PetSkill_BfIcon_RT_R[0].gameObject.SetActive(true);
						this.PetSkill_BfIcon_RT_R[1].gameObject.SetActive(false);
						this.PetSkill_BfIcon_RT_R[0].anchoredPosition = new Vector2(35f, this.PetSkill_BfIcon_RT_R[0].anchoredPosition.y);
					}
					else
					{
						this.PetSkill_BfIcon_RT_R[0].gameObject.SetActive(true);
						this.PetSkill_BfIcon_RT_R[1].gameObject.SetActive(true);
						this.PetSkill_BfIcon_RT_R[0].anchoredPosition = new Vector2(0f, this.PetSkill_BfIcon_RT_R[0].anchoredPosition.y);
					}
				}
				else
				{
					this.PetSkillRT_L.gameObject.SetActive(false);
					this.PetSkillRT_R.gameObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x06001B2B RID: 6955 RVA: 0x002FD284 File Offset: 0x002FB484
	public void CheckQuanmieBuff()
	{
		for (int i = 0; i < 10; i++)
		{
			this.btn_Failure_Skill[i].gameObject.SetActive(false);
		}
		for (int j = 0; j < 10; j++)
		{
			this.btn_Failure_DeBuff[j].gameObject.SetActive(false);
		}
		this.Failure_Buff_RT[0].gameObject.SetActive(false);
		this.Failure_Buff_RT[1].gameObject.SetActive(false);
		this.Failure_DeBuff_RT[0].gameObject.SetActive(false);
		this.Failure_DeBuff_RT[1].gameObject.SetActive(false);
		float num = 0f;
		if (this.bNpcMode)
		{
			num = 65f;
		}
		this.Failure_Buff_RT[0].anchoredPosition = new Vector2(this.Failure_Buff_RT[0].anchoredPosition.x, -282f - num);
		if (this.bDoNotShow)
		{
			if (this.mA_Skill_L > 0 || this.mD_Skill_R > 0 || this.mDeBf_A_L > 0 || this.mDeBf_D_R > 0)
			{
				this.tmpH1 -= 23f;
				this.tmpH2 = -23f;
				this.Failure_Buff_RT[0].gameObject.SetActive(true);
				this.tmpH -= 49f;
				this.tmpH -= 50f;
				this.tmpH1 += 129f;
				this.tmpH2 += 129f;
				this.text_FailureBuff[0].gameObject.SetActive(true);
				this.text_FailureBuff[0].text = this.DM.mStringTable.GetStringByID(10100u);
				this.text_FailureBuff[0].SetAllDirty();
				this.text_FailureBuff[0].cachedTextGenerator.Invalidate();
			}
		}
		else
		{
			CString cstring = StringManager.Instance.StaticString1024();
			if ((this.IsAttack && this.mDeBf_A_L > 0) || (!this.IsAttack && this.mDeBf_D_R > 0))
			{
				this.tmpH1 -= 23f;
				this.tmpH2 = -23f;
				this.Failure_Buff_RT[0].gameObject.SetActive(true);
				this.Failure_Buff_RT[1].gameObject.SetActive(true);
				if (this.IsAttack)
				{
					for (int k = 0; k < this.mA_Skill_L; k++)
					{
						this.btn_Failure_Skill[k].gameObject.SetActive(true);
						this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_A_Skill_ID[k]);
						cstring.ClearString();
						cstring.Append('s');
						cstring.IntToFormat((long)this.skill.Icon, 5, false);
						cstring.AppendFormat("{0}");
						this.Img_Failure_Skill[k].sprite = this.GUIM.LoadSkillSprite(cstring);
					}
					this.tmpH -= 49f;
					this.tmpH1 += 49f;
					this.tmpH2 += 49f;
					this.Failure_Skill_RT[0].gameObject.SetActive(false);
					this.Failure_Skill_RT[1].gameObject.SetActive(false);
					if (this.mA_Skill_L > 5)
					{
						this.tmpH -= 192f;
						this.tmpH1 += 192f;
						this.tmpH2 += 192f;
						this.Failure_Skill_RT[0].gameObject.SetActive(true);
						this.Failure_Skill_RT[1].gameObject.SetActive(true);
						this.Failure_Buff_RT[1].anchoredPosition = new Vector2(this.Failure_Buff_RT[1].anchoredPosition.x, -523f - num);
					}
					else if (this.mA_Skill_L > 0)
					{
						this.tmpH -= 120f;
						this.tmpH1 += 120f;
						this.tmpH2 += 120f;
						this.Failure_Skill_RT[0].gameObject.SetActive(true);
						this.Failure_Buff_RT[1].anchoredPosition = new Vector2(this.Failure_Buff_RT[1].anchoredPosition.x, -451f - num);
					}
					else
					{
						this.tmpH -= 69f;
						this.tmpH1 += 69f;
						this.tmpH2 += 69f;
						this.Failure_Buff_RT[1].anchoredPosition = new Vector2(this.Failure_Buff_RT[1].anchoredPosition.x, -400f - num);
						this.text_FailureBuff[0].gameObject.SetActive(true);
						this.text_FailureBuff[0].text = this.DM.mStringTable.GetStringByID(5334u);
						this.text_FailureBuff[0].SetAllDirty();
						this.text_FailureBuff[0].cachedTextGenerator.Invalidate();
					}
					this.Failure_DeBuff_RT[0].gameObject.SetActive(true);
					this.Failure_DeBuff_RT[1].gameObject.SetActive(false);
					this.tmpH -= 42f;
					this.tmpH1 += 42f;
					this.tmpH2 += 42f;
					if (this.mDeBf_A_L > 5)
					{
						this.tmpH -= 192f;
						this.tmpH1 += 192f;
						this.tmpH2 += 192f;
						this.Failure_DeBuff_RT[1].gameObject.SetActive(true);
					}
					else
					{
						this.tmpH -= 120f;
						this.tmpH1 += 120f;
						this.tmpH2 += 120f;
					}
					for (int l = 0; l < 10; l++)
					{
						this.btn_Failure_DeBuff[l].gameObject.SetActive(false);
					}
					for (int m = 0; m < this.mDeBf_A_L; m++)
					{
						this.btn_Failure_DeBuff[m].gameObject.SetActive(true);
						this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_A_DeBf_Skill_ID[m]);
						cstring.ClearString();
						cstring.Append('s');
						cstring.IntToFormat((long)this.skill.Icon, 5, false);
						cstring.AppendFormat("{0}");
						this.Img_Failure_DeBuff[m].sprite = this.GUIM.LoadSkillSprite(cstring);
					}
				}
				else
				{
					for (int n = 0; n < this.mD_Skill_R; n++)
					{
						this.btn_Failure_Skill[n].gameObject.SetActive(true);
						this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_D_Skill_ID[n]);
						cstring.ClearString();
						cstring.Append('s');
						cstring.IntToFormat((long)this.skill.Icon, 5, false);
						cstring.AppendFormat("{0}");
						this.Img_Failure_Skill[n].sprite = this.GUIM.LoadSkillSprite(cstring);
					}
					this.tmpH -= 49f;
					this.tmpH1 += 49f;
					this.tmpH2 += 49f;
					this.Failure_Skill_RT[0].gameObject.SetActive(false);
					this.Failure_Skill_RT[1].gameObject.SetActive(false);
					if (this.mD_Skill_R > 5)
					{
						this.tmpH -= 192f;
						this.tmpH1 += 192f;
						this.tmpH2 += 192f;
						this.Failure_Skill_RT[0].gameObject.SetActive(true);
						this.Failure_Skill_RT[1].gameObject.SetActive(true);
						this.Failure_Buff_RT[1].anchoredPosition = new Vector2(this.Failure_Buff_RT[1].anchoredPosition.x, -523f - num);
					}
					else if (this.mD_Skill_R > 0)
					{
						this.tmpH -= 120f;
						this.tmpH1 += 120f;
						this.tmpH2 += 120f;
						this.Failure_Skill_RT[0].gameObject.SetActive(true);
						this.Failure_Buff_RT[1].anchoredPosition = new Vector2(this.Failure_Buff_RT[1].anchoredPosition.x, -451f - num);
					}
					else
					{
						this.tmpH -= 69f;
						this.tmpH1 += 69f;
						this.tmpH2 += 69f;
						this.text_FailureBuff[0].gameObject.SetActive(true);
						this.text_FailureBuff[0].text = this.DM.mStringTable.GetStringByID(5334u);
						this.text_FailureBuff[0].SetAllDirty();
						this.text_FailureBuff[0].cachedTextGenerator.Invalidate();
						this.Failure_Buff_RT[1].anchoredPosition = new Vector2(this.Failure_Buff_RT[1].anchoredPosition.x, -400f - num);
					}
					this.Failure_DeBuff_RT[0].gameObject.SetActive(true);
					this.Failure_DeBuff_RT[1].gameObject.SetActive(false);
					this.tmpH -= 42f;
					this.tmpH1 += 42f;
					this.tmpH2 += 42f;
					if (this.mDeBf_D_R > 5)
					{
						this.tmpH -= 192f;
						this.tmpH1 += 192f;
						this.tmpH2 += 192f;
						this.Failure_DeBuff_RT[1].gameObject.SetActive(true);
					}
					else
					{
						this.tmpH -= 120f;
						this.tmpH1 += 120f;
						this.tmpH2 += 120f;
					}
					for (int num2 = 0; num2 < 10; num2++)
					{
						this.btn_Failure_DeBuff[num2].gameObject.SetActive(false);
					}
					for (int num3 = 0; num3 < this.mDeBf_A_L; num3++)
					{
						this.btn_Failure_DeBuff[num3].gameObject.SetActive(true);
						this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_D_DeBf_Skill_ID[num3]);
						cstring.ClearString();
						cstring.Append('s');
						cstring.IntToFormat((long)this.skill.Icon, 5, false);
						cstring.AppendFormat("{0}");
						this.Img_Failure_DeBuff[num3].sprite = this.GUIM.LoadSkillSprite(cstring);
					}
				}
			}
			else if ((this.IsAttack && this.mA_Skill_L > 0) || (!this.IsAttack && this.mD_Skill_R > 0))
			{
				this.tmpH1 -= 23f;
				this.tmpH2 = -23f;
				this.Failure_Buff_RT[0].gameObject.SetActive(true);
				if (this.IsAttack)
				{
					for (int num4 = 0; num4 < this.mA_Skill_L; num4++)
					{
						this.btn_Failure_Skill[num4].gameObject.SetActive(true);
						this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_A_Skill_ID[num4]);
						cstring.ClearString();
						cstring.Append('s');
						cstring.IntToFormat((long)this.skill.Icon, 5, false);
						cstring.AppendFormat("{0}");
						this.Img_Failure_Skill[num4].sprite = this.GUIM.LoadSkillSprite(cstring);
					}
					this.tmpH -= 49f;
					this.tmpH1 += 49f;
					this.tmpH2 += 49f;
					this.Failure_Skill_RT[0].gameObject.SetActive(false);
					this.Failure_Skill_RT[1].gameObject.SetActive(false);
					if (this.mA_Skill_L > 5)
					{
						this.tmpH -= 192f;
						this.tmpH1 += 192f;
						this.tmpH2 += 192f;
						this.Failure_Skill_RT[0].gameObject.SetActive(true);
						this.Failure_Skill_RT[1].gameObject.SetActive(true);
					}
					else if (this.mA_Skill_L > 0)
					{
						this.tmpH -= 120f;
						this.tmpH1 += 120f;
						this.tmpH2 += 120f;
						this.Failure_Skill_RT[0].gameObject.SetActive(true);
					}
					else
					{
						this.tmpH -= 50f;
						this.tmpH1 += 50f;
						this.tmpH2 += 50f;
						this.text_FailureBuff[0].gameObject.SetActive(true);
						this.text_FailureBuff[0].text = this.DM.mStringTable.GetStringByID(5334u);
						this.text_FailureBuff[0].SetAllDirty();
						this.text_FailureBuff[0].cachedTextGenerator.Invalidate();
					}
				}
				else
				{
					for (int num5 = 0; num5 < this.mD_Skill_R; num5++)
					{
						this.btn_Failure_Skill[num5].gameObject.SetActive(true);
						this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_D_Skill_ID[num5]);
						cstring.ClearString();
						cstring.Append('s');
						cstring.IntToFormat((long)this.skill.Icon, 5, false);
						cstring.AppendFormat("{0}");
						this.Img_Failure_Skill[num5].sprite = this.GUIM.LoadSkillSprite(cstring);
					}
					this.tmpH -= 49f;
					this.tmpH1 += 49f;
					this.tmpH2 += 49f;
					this.Failure_Skill_RT[0].gameObject.SetActive(false);
					this.Failure_Skill_RT[1].gameObject.SetActive(false);
					if (this.mD_Skill_R > 5)
					{
						this.tmpH -= 192f;
						this.tmpH1 += 192f;
						this.tmpH2 += 192f;
						this.Failure_Skill_RT[0].gameObject.SetActive(true);
						this.Failure_Skill_RT[1].gameObject.SetActive(true);
					}
					else if (this.mD_Skill_R > 0)
					{
						this.tmpH -= 120f;
						this.tmpH1 += 120f;
						this.tmpH2 += 120f;
						this.Failure_Skill_RT[0].gameObject.SetActive(true);
					}
					else
					{
						this.tmpH -= 50f;
						this.tmpH1 += 50f;
						this.tmpH2 += 50f;
						this.text_FailureBuff[0].gameObject.SetActive(true);
						this.text_FailureBuff[0].text = this.DM.mStringTable.GetStringByID(5334u);
						this.text_FailureBuff[0].SetAllDirty();
						this.text_FailureBuff[0].cachedTextGenerator.Invalidate();
					}
				}
			}
		}
	}

	// Token: 0x06001B2C RID: 6956 RVA: 0x002FE2FC File Offset: 0x002FC4FC
	public void SetBossData()
	{
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		this.Img_Titlebg.sprite = this.SArray.m_Sprites[13];
		if (this.SummaryRT != null)
		{
			this.SummaryRT.gameObject.SetActive(false);
			this.bSetFSShow = true;
		}
		if (this.QuanmieRT != null)
		{
			this.QuanmieRT.gameObject.SetActive(false);
		}
		if (this.LightT1 != null)
		{
			this.LightT1.gameObject.SetActive(false);
		}
		this.BossRT.gameObject.SetActive(true);
		this.btn_Replay.gameObject.SetActive(true);
		if (this.Report.Monster.Result == 1 || this.Report.Monster.Result == 5)
		{
			this.text_Summary.gameObject.SetActive(true);
		}
		else
		{
			this.text_Summary.gameObject.SetActive(false);
		}
		this.text_Summary.text = this.DM.mStringTable.GetStringByID(8224u);
		this.text_Summary.color = new Color(1f, 0.9255f, 0.5294f);
		this.text_Summary.SetAllDirty();
		this.text_Summary.cachedTextGenerator.Invalidate();
		if (this.Report.Monster.Result == 4)
		{
			this.text_AllianceBossStr.text = this.DM.mStringTable.GetStringByID(14517u);
		}
		else if (this.Report.Monster.Result == 5)
		{
			this.text_AllianceBossStr.text = this.DM.mStringTable.GetStringByID(14518u);
		}
		this.text_AllianceBossStr.SetAllDirty();
		this.text_AllianceBossStr.cachedTextGenerator.Invalidate();
		this.BossRT.anchoredPosition = new Vector2(this.BossRT.anchoredPosition.x, this.SummaryRT.anchoredPosition.y);
		MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.Report.Monster.MonsterID);
		this.text_BossTitle[1].text = this.DM.mStringTable.GetStringByID((uint)recordByKey.NameID);
		Hero recordByKey2 = this.DM.HeroTable.GetRecordByKey(recordByKey.ModelID);
		this.mBossHead = recordByKey2.Graph;
		this.Cstr_BoosHead.ClearString();
		this.Cstr_BoosHead.IntToFormat((long)this.mBossHead, 1, false);
		this.Cstr_BoosHead.AppendFormat("UI/MapNPCHead_{0}");
		if (AssetManager.GetAssetBundleDownload(this.Cstr_BoosHead, AssetPath.UI, AssetType.NPCHead, recordByKey2.Graph, false))
		{
			AssetBundle assetBundle = AssetManager.GetAssetBundle(this.Cstr_BoosHead, out this.AssetKey);
			if (assetBundle != null)
			{
				this.mHead = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
			}
			if (this.mHead != null)
			{
				this.mHead.transform.SetParent(this.Img_BossIcon[0].transform);
				this.mHead.gameObject.SetActive(true);
				this.mHead.transform.localPosition = new Vector3(0f, 0f, 0f);
				this.mHead.transform.localScale = new Vector3(1f, 1f, 1f);
			}
		}
		this.Img_BossIcon[1].sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, this.Report.Monster.MonsterLv);
		if (this.Report.Monster.SequentialDamageTimes > 0)
		{
			this.text_BossFight[0].gameObject.SetActive(false);
			this.text_BossFight[1].gameObject.SetActive(true);
			this.text_BossFight[2].gameObject.SetActive(true);
			this.Cstr_BossFight[0].ClearString();
			this.Cstr_BossFight[0].IntToFormat((long)this.Report.Monster.SequentialDamageTimes, 1, false);
			this.Cstr_BossFight[0].AppendFormat(this.DM.mStringTable.GetStringByID(8225u));
			this.text_BossFight[1].text = this.Cstr_BossFight[0].ToString();
			this.text_BossFight[1].SetAllDirty();
			this.text_BossFight[1].cachedTextGenerator.Invalidate();
			cstring.ClearString();
			cstring.FloatToFormat(this.Report.Monster.AttrScale.SequentialDamageScale / 100f, 2, false);
			cstring.AppendFormat("+{0}%");
			this.Cstr_BossFight[1].ClearString();
			this.Cstr_BossFight[1].StringToFormat(cstring);
			this.Cstr_BossFight[1].AppendFormat(this.DM.mStringTable.GetStringByID(8226u));
			this.text_BossFight[2].text = this.Cstr_BossFight[1].ToString();
			this.text_BossFight[2].SetAllDirty();
			this.text_BossFight[2].cachedTextGenerator.Invalidate();
		}
		else
		{
			this.text_BossFight[0].gameObject.SetActive(true);
			this.text_BossFight[1].gameObject.SetActive(false);
			this.text_BossFight[2].gameObject.SetActive(false);
		}
		if (this.Report.Monster.AttrScale.ActionTimes > 1)
		{
			this.Cstr_BossL[0].ClearString();
			this.Cstr_BossL[0].IntToFormat((long)this.Report.Monster.AttrScale.ActionTimes, 1, false);
			this.Cstr_BossL[0].AppendFormat(this.DM.mStringTable.GetStringByID(8231u));
			this.text_BossL[0].text = this.Cstr_BossL[0].ToString();
			this.text_BossL[0].SetAllDirty();
			this.text_BossL[0].cachedTextGenerator.Invalidate();
			this.text_BossL[0].gameObject.SetActive(true);
			this.Cstr_BossL[1].ClearString();
			this.Cstr_BossL[1].IntToFormat((long)this.Report.Monster.EffectiveDamageTimes, 1, false);
			this.Cstr_BossL[1].AppendFormat(this.DM.mStringTable.GetStringByID(8349u));
			this.text_BossL[1].text = this.Cstr_BossL[1].ToString();
			this.text_BossL[1].SetAllDirty();
			this.text_BossL[1].cachedTextGenerator.Invalidate();
			this.text_BossL[1].gameObject.SetActive(true);
		}
		else
		{
			this.text_BossL[0].gameObject.SetActive(false);
			this.text_BossL[1].gameObject.SetActive(false);
		}
		if (this.tmpHeroID[0] != 0)
		{
			this.GUIM.ChangeHeroItemImg(this.btn_Boss_Hero.transform, eHeroOrItem.Hero, this.tmpHeroID[0], this.tmpHeroStar[0], 0, 0);
		}
		bool flag = false;
		if (flag)
		{
			this.Img_BossHeroCrown[0].gameObject.SetActive(true);
		}
		else
		{
			this.Img_BossHeroCrown[0].gameObject.SetActive(false);
		}
		float num = this.Report.Monster.EndHPPercent / this.Report.Monster.MonsterMaxHP;
		this.BossBloodRT.sizeDelta = new Vector2(274f * num, this.BossBloodRT.sizeDelta.y);
		this.text_BossR[0].text = this.Report.Monster.MonsterLv.ToString();
		this.Cstr_BossR[0].ClearString();
		if (num > 0f)
		{
			if (num * 100f >= 0.01f)
			{
				this.Cstr_BossR[0].FloatToFormat(num * 100f, 2, false);
			}
			else
			{
				this.Cstr_BossR[0].FloatToFormat(0.01f, -1, true);
			}
		}
		else
		{
			this.Cstr_BossR[0].FloatToFormat(0f, -1, true);
		}
		if (this.GUIM.IsArabic)
		{
			this.Cstr_BossR[0].AppendFormat("%{0}");
		}
		else
		{
			this.Cstr_BossR[0].AppendFormat("{0}%");
		}
		this.text_BossR[1].text = this.Cstr_BossR[0].ToString();
		this.text_BossR[1].SetAllDirty();
		this.text_BossR[1].cachedTextGenerator.Invalidate();
		this.Cstr_BossR[1].ClearString();
		this.Cstr_BossR[1].FloatToFormat((this.Report.Monster.BeginHPPercent - this.Report.Monster.EndHPPercent) * 100f / this.Report.Monster.MonsterMaxHP, 2, false);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_BossR[1].AppendFormat("%{0}-");
		}
		else
		{
			this.Cstr_BossR[1].AppendFormat("-{0}%");
		}
		this.text_BossR[2].text = this.Cstr_BossR[1].ToString();
		this.text_BossR[2].SetAllDirty();
		this.text_BossR[2].cachedTextGenerator.Invalidate();
		this.tmpH -= 41f;
		this.tmpH -= 132f;
		this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, -this.tmpH);
	}

	// Token: 0x06001B2D RID: 6957 RVA: 0x002FECF4 File Offset: 0x002FCEF4
	public void SetItemData()
	{
		if (!this.bAllianceBossMode)
		{
			for (int i = 0; i < 5; i++)
			{
				if (this.tmpNum > i)
				{
					this.ItemT[i].gameObject.SetActive(true);
				}
				else
				{
					this.ItemT[i].gameObject.SetActive(false);
				}
				for (int j = 0; j < 6; j++)
				{
					if (this.mItemCount > i * 6 + j)
					{
						this.text_ItemQty[i * 6 + j].gameObject.SetActive(true);
						this.Cstr_ItemQty[i * 6 + j].ClearString();
						this.Cstr_ItemQty[i * 6 + j].IntToFormat((long)this.ItemNum[i * 6 + j], 1, true);
						if (this.GUIM.IsArabic)
						{
							this.Cstr_ItemQty[i * 6 + j].AppendFormat("{0}x");
						}
						else
						{
							this.Cstr_ItemQty[i * 6 + j].AppendFormat("x{0}");
						}
						this.text_ItemQty[i * 6 + j].text = this.Cstr_ItemQty[i * 6 + j].ToString();
						this.text_ItemQty[i * 6 + j].SetAllDirty();
						this.text_ItemQty[i * 6 + j].cachedTextGenerator.Invalidate();
						byte equipKind = this.DM.EquipTable.GetRecordByKey(this.ItemID[i * 6 + j]).EquipKind;
						bool flag = this.GUIM.IsLeadItem(equipKind);
						if (flag)
						{
							this.GUIM.ChangeLordEquipImg(this.btn_Item_L[i * 6 + j].transform, this.ItemID[i * 6 + j], this.ItemRank[i * 6 + j], eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
							this.btn_Item_L[i * 6 + j].gameObject.SetActive(true);
							this.btn_Itme[i * 6 + j].gameObject.SetActive(false);
						}
						else
						{
							this.GUIM.ChangeHeroItemImg(this.btn_Itme[i * 6 + j].transform, eHeroOrItem.Item, this.ItemID[i * 6 + j], 0, this.ItemRank[i * 6 + j], 0);
							this.btn_Item_L[i * 6 + j].gameObject.SetActive(false);
							this.btn_Itme[i * 6 + j].gameObject.SetActive(true);
							this.btn_Itme[i * 6 + j].m_BtnID2 = (int)this.ItemID[i * 6 + j];
							bool flag2 = false;
							Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.ItemID[i * 6 + j]);
							if (recordByKey.EquipKind == 19)
							{
								flag2 = true;
							}
							else if (recordByKey.EquipKind == 18 && recordByKey.PropertiesInfo[0].Propertieskey == 4)
							{
								flag2 = true;
							}
							else if (recordByKey.EquipKind == 18 && (recordByKey.PropertiesInfo[2].Propertieskey < 1 || recordByKey.PropertiesInfo[2].Propertieskey > 3))
							{
								flag2 = true;
							}
							if (flag2)
							{
								this.btn_Itme[i * 6 + j].transform.GetComponent<UIButtonHint>().enabled = false;
								if (this.btn_Itme[i * 6 + j].transform.GetComponent<EventPatchery>() == null)
								{
									this.btn_Itme[i * 6 + j].gameObject.AddComponent<EventPatchery>().SetEvnetObj(this.m_Mask);
								}
							}
							else
							{
								this.btn_Itme[i * 6 + j].transform.GetComponent<UIButtonHint>().enabled = true;
							}
						}
					}
					else
					{
						this.btn_Item_L[i * 6 + j].gameObject.SetActive(false);
						this.btn_Itme[i * 6 + j].gameObject.SetActive(false);
						this.text_ItemQty[i * 6 + j].gameObject.SetActive(false);
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < 5; k++)
			{
				this.ItemT[k].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001B2E RID: 6958 RVA: 0x002FF11C File Offset: 0x002FD31C
	private void Update()
	{
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
		if (this.NextT != null)
		{
			this.Vec3Instance.Set(this.MoveTime1 - num, this.NextT.localPosition.y, this.NextT.localPosition.z);
			this.NextT.localPosition = this.Vec3Instance;
		}
		if (this.PreviousT != null)
		{
			this.Vec3Instance.Set(this.MoveTime2 + num, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
			this.PreviousT.localPosition = this.Vec3Instance;
		}
		if (!this.bSetFSShow && this.bInitFS && !this.bQuanmier && this.SummaryRT != null && !this.SummaryRT.gameObject.activeSelf)
		{
			this.SummaryRT.gameObject.SetActive(true);
			this.bSetFSShow = true;
		}
		if (!this.bCreateItem && this.bInitItemBase && this.ItemBase != null && this.ItemRT2 != null && !this.bNpcMode)
		{
			this.bCreateItem = true;
			float num2 = 89f;
			for (int i = 1; i < 5; i++)
			{
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.ItemBase.gameObject);
				gameObject.transform.SetParent(this.ItemRT2.transform, false);
				gameObject.transform.SetSiblingIndex(i);
				this.tmpRC = gameObject.GetComponent<RectTransform>();
				this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x, -num2);
				num2 += 89f;
				gameObject.SetActive(true);
				this.ItemT[i] = gameObject.transform;
				for (int j = 0; j < 6; j++)
				{
					this.btn_Itme[i * 6 + j] = this.ItemT[i].GetChild(j).GetComponent<UIHIBtn>();
					this.btn_Itme[i * 6 + j].m_Handler = this;
					this.btn_Item_L[i * 6 + j] = this.ItemT[i].GetChild(6 + j).GetComponent<UILEBtn>();
					this.text_ItemQty[i * 6 + j] = this.ItemT[i].GetChild(12 + j).GetComponent<UIText>();
					this.text_ItemQty[i * 6 + j].font = this.TTFont;
				}
			}
		}
		if (!this.bNpcMode && this.bSetItemData < 2 && this.bCreateItem)
		{
			if (this.bSetItemData == 0)
			{
				this.bSetItemData = 1;
			}
			else
			{
				this.SetItemData();
				this.bSetItemData = 2;
			}
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
		if (this.LightBossT != null)
		{
			this.LightBossT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
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

	// Token: 0x06001B2F RID: 6959 RVA: 0x002FF7D8 File Offset: 0x002FD9D8
	private void SetPorfileBtn()
	{
		int num;
		int num2;
		if (this.IsAttack)
		{
			num = 0;
			num2 = 3;
		}
		else
		{
			num = 3;
			num2 = 0;
		}
		if (this.Img_MainHero != null && this.Img_MainHero[num] != null && this.Img_MainHero[num].transform.GetChild(0) != null)
		{
			UIButton component = this.Img_MainHero[num].transform.GetChild(0).gameObject.GetComponent<UIButton>();
			if (component != null)
			{
				component.m_Handler = this;
				component.m_BtnID1 = ((num != 0) ? 11 : 10);
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
				component.m_BtnID1 = ((num2 != 0) ? 11 : 10);
				component.m_EffectType = e_EffectType.e_Scale;
				component.transition = Selectable.Transition.None;
			}
		}
	}

	// Token: 0x06001B30 RID: 6960 RVA: 0x002FF924 File Offset: 0x002FDB24
	private void ShowLordProfile(FightingSummary_btn type)
	{
		if (!this.bNpcMode)
		{
			this.DM.PlayerName_War[0].Append(this.Report.Combat.AssaultName);
			this.DM.PlayerName_War[1].Append(this.Report.Combat.DefenceName);
			if (type == FightingSummary_btn.btn_Porfile_Def)
			{
				if (this.Report != null && this.Report.Combat != null && this.Report.Combat.DefenceName != null && this.Report.Combat.DefenceName != string.Empty)
				{
					this.bSaveY = true;
					DataManager.Instance.ShowLordProfile(this.Report.Combat.DefenceName);
				}
			}
			else if (type == FightingSummary_btn.btn_Porfile_Atk && this.Report != null && this.Report.Combat != null && this.Report.Combat.AssaultName != null && this.Report.Combat.AssaultName != string.Empty)
			{
				this.bSaveY = true;
				DataManager.Instance.ShowLordProfile(this.Report.Combat.AssaultName);
			}
		}
		else
		{
			this.DM.PlayerName_War[0].Append(this.Report.NPCCombat.AssaultName);
			if (type != FightingSummary_btn.btn_Porfile_Def)
			{
				if (type == FightingSummary_btn.btn_Porfile_Atk && this.Report != null && this.Report.NPCCombat != null && this.Report.NPCCombat.AssaultName != null && this.Report.NPCCombat.AssaultName != string.Empty)
				{
					this.bSaveY = true;
					DataManager.Instance.ShowLordProfile(this.Report.NPCCombat.AssaultName);
				}
			}
		}
	}

	// Token: 0x040050F7 RID: 20727
	private Transform GameT;

	// Token: 0x040050F8 RID: 20728
	private Transform Tmp;

	// Token: 0x040050F9 RID: 20729
	private Transform Tmp1;

	// Token: 0x040050FA RID: 20730
	private Transform Tmp2;

	// Token: 0x040050FB RID: 20731
	private Transform LightT1;

	// Token: 0x040050FC RID: 20732
	private Transform LightT2;

	// Token: 0x040050FD RID: 20733
	private Transform[] ItemT = new Transform[5];

	// Token: 0x040050FE RID: 20734
	private Transform PreviousT;

	// Token: 0x040050FF RID: 20735
	private Transform NextT;

	// Token: 0x04005100 RID: 20736
	private Transform LightBossT;

	// Token: 0x04005101 RID: 20737
	private Transform BossIconT;

	// Token: 0x04005102 RID: 20738
	private Transform ItemBase;

	// Token: 0x04005103 RID: 20739
	private Transform Mask_T;

	// Token: 0x04005104 RID: 20740
	private GameObject mHead;

	// Token: 0x04005105 RID: 20741
	private RectTransform tmpRC;

	// Token: 0x04005106 RID: 20742
	private RectTransform ContentRT;

	// Token: 0x04005107 RID: 20743
	private RectTransform ReplayerRT;

	// Token: 0x04005108 RID: 20744
	private RectTransform ItemRT;

	// Token: 0x04005109 RID: 20745
	private RectTransform ItemRT2;

	// Token: 0x0400510A RID: 20746
	private RectTransform HeroRT;

	// Token: 0x0400510B RID: 20747
	private RectTransform HeroBGRT;

	// Token: 0x0400510C RID: 20748
	private RectTransform ResourcesRT;

	// Token: 0x0400510D RID: 20749
	private RectTransform SummaryRT;

	// Token: 0x0400510E RID: 20750
	private RectTransform QuanmieRT;

	// Token: 0x0400510F RID: 20751
	private RectTransform BossRT;

	// Token: 0x04005110 RID: 20752
	private RectTransform BossBloodRT;

	// Token: 0x04005111 RID: 20753
	private RectTransform PetSkillRT_L;

	// Token: 0x04005112 RID: 20754
	private RectTransform PetSkillRT_R;

	// Token: 0x04005113 RID: 20755
	private RectTransform[] PetSkill_BfIcon_RT_L = new RectTransform[2];

	// Token: 0x04005114 RID: 20756
	private RectTransform[] PetSkill_BfIcon_RT_R = new RectTransform[2];

	// Token: 0x04005115 RID: 20757
	private RectTransform[] DeBuff_BfIcon_RT_L = new RectTransform[2];

	// Token: 0x04005116 RID: 20758
	private RectTransform[] DeBuff_BfIcon_RT_R = new RectTransform[2];

	// Token: 0x04005117 RID: 20759
	private RectTransform[] Failure_Buff_RT = new RectTransform[2];

	// Token: 0x04005118 RID: 20760
	private RectTransform[] Failure_Skill_RT = new RectTransform[2];

	// Token: 0x04005119 RID: 20761
	private RectTransform[] Failure_DeBuff_RT = new RectTransform[2];

	// Token: 0x0400511A RID: 20762
	private UIButton btn_EXIT;

	// Token: 0x0400511B RID: 20763
	private UIButton btn_Previous;

	// Token: 0x0400511C RID: 20764
	private UIButton btn_Next;

	// Token: 0x0400511D RID: 20765
	private UIButton btn_Title;

	// Token: 0x0400511E RID: 20766
	private UIButton btn_Delete;

	// Token: 0x0400511F RID: 20767
	private UIButton btn_Collect;

	// Token: 0x04005120 RID: 20768
	private UIButton btn_Replay;

	// Token: 0x04005121 RID: 20769
	private UIButton btn_Details;

	// Token: 0x04005122 RID: 20770
	private UIButton[] btn_Coordinate = new UIButton[2];

	// Token: 0x04005123 RID: 20771
	private UIButton btn_LF;

	// Token: 0x04005124 RID: 20772
	private UIButton btn_RF;

	// Token: 0x04005125 RID: 20773
	private UIButton[] btn_PetSkill_L = new UIButton[10];

	// Token: 0x04005126 RID: 20774
	private UIButton[] btn_PetSkill_R = new UIButton[10];

	// Token: 0x04005127 RID: 20775
	private UIButton[] btn_DeBuff_L = new UIButton[10];

	// Token: 0x04005128 RID: 20776
	private UIButton[] btn_DeBuff_R = new UIButton[10];

	// Token: 0x04005129 RID: 20777
	private UIButton[] btn_Failure_Skill = new UIButton[10];

	// Token: 0x0400512A RID: 20778
	private UIButton[] btn_Failure_DeBuff = new UIButton[10];

	// Token: 0x0400512B RID: 20779
	private UIHIBtn[] btn_Itme = new UIHIBtn[30];

	// Token: 0x0400512C RID: 20780
	private UILEBtn[] btn_Item_L = new UILEBtn[30];

	// Token: 0x0400512D RID: 20781
	private UIHIBtn[] btn_Hero = new UIHIBtn[5];

	// Token: 0x0400512E RID: 20782
	private UIHIBtn btn_Boss_Hero;

	// Token: 0x0400512F RID: 20783
	private Image tmpImg;

	// Token: 0x04005130 RID: 20784
	private Image Img_Titlebg;

	// Token: 0x04005131 RID: 20785
	private Image Img_MainHerobg;

	// Token: 0x04005132 RID: 20786
	private Image Img_RePlay;

	// Token: 0x04005133 RID: 20787
	private Image Img_Vs;

	// Token: 0x04005134 RID: 20788
	private Image[] Img_Summarybg = new Image[2];

	// Token: 0x04005135 RID: 20789
	private Image[] Img_Crown = new Image[4];

	// Token: 0x04005136 RID: 20790
	private Image[] Img_MainHero = new Image[6];

	// Token: 0x04005137 RID: 20791
	private Image[] Img_MainTitle = new Image[2];

	// Token: 0x04005138 RID: 20792
	private Image[] Img_Muster = new Image[2];

	// Token: 0x04005139 RID: 20793
	private Image[] Img_Country = new Image[2];

	// Token: 0x0400513A RID: 20794
	private Image[] Img_Rank = new Image[2];

	// Token: 0x0400513B RID: 20795
	private Image[] Img_Army = new Image[2];

	// Token: 0x0400513C RID: 20796
	private Image[] Img_Army2 = new Image[2];

	// Token: 0x0400513D RID: 20797
	private Image[] Img_CWall = new Image[2];

	// Token: 0x0400513E RID: 20798
	private Image[] Img_CWall_P = new Image[2];

	// Token: 0x0400513F RID: 20799
	private Image[] Img_Vip = new Image[2];

	// Token: 0x04005140 RID: 20800
	private Image[] Img_BossHeroCrown = new Image[2];

	// Token: 0x04005141 RID: 20801
	private Image[] Img_BossIcon = new Image[2];

	// Token: 0x04005142 RID: 20802
	private Image Img_BossVs;

	// Token: 0x04005143 RID: 20803
	private Image Img_Quanmie;

	// Token: 0x04005144 RID: 20804
	private Image Img_Exp;

	// Token: 0x04005145 RID: 20805
	private Image Img_LF;

	// Token: 0x04005146 RID: 20806
	private Image Img_RF;

	// Token: 0x04005147 RID: 20807
	private Image Img_FormationHint;

	// Token: 0x04005148 RID: 20808
	private Image[] Img_Bf_BG_L = new Image[3];

	// Token: 0x04005149 RID: 20809
	private Image[] Img_Bf_BG_R = new Image[3];

	// Token: 0x0400514A RID: 20810
	private Image[] Img_PetSkill_L = new Image[10];

	// Token: 0x0400514B RID: 20811
	private Image[] Img_PetSkill_R = new Image[10];

	// Token: 0x0400514C RID: 20812
	private Image[] Img_DeBuff_L = new Image[10];

	// Token: 0x0400514D RID: 20813
	private Image[] Img_DeBuff_R = new Image[10];

	// Token: 0x0400514E RID: 20814
	private Image[] Img_Failure_Skill = new Image[10];

	// Token: 0x0400514F RID: 20815
	private Image[] Img_Failure_DeBuff = new Image[10];

	// Token: 0x04005150 RID: 20816
	private CScrollRect m_Mask;

	// Token: 0x04005151 RID: 20817
	private UIText tmptext;

	// Token: 0x04005152 RID: 20818
	private UIText text_Coordinate;

	// Token: 0x04005153 RID: 20819
	private UIText text_TitleName;

	// Token: 0x04005154 RID: 20820
	private UIText text_Page;

	// Token: 0x04005155 RID: 20821
	private UIText text_Summary;

	// Token: 0x04005156 RID: 20822
	private UIText text_MainHero;

	// Token: 0x04005157 RID: 20823
	private UIText text_TitleItem;

	// Token: 0x04005158 RID: 20824
	private UIText text_FightingKind;

	// Token: 0x04005159 RID: 20825
	private UIText text_L_Exp;

	// Token: 0x0400515A RID: 20826
	private UIText[] text_Time = new UIText[2];

	// Token: 0x0400515B RID: 20827
	private UIText[] text_ItemQty = new UIText[30];

	// Token: 0x0400515C RID: 20828
	private UIText[] text_Offensive = new UIText[2];

	// Token: 0x0400515D RID: 20829
	private UIText[] text_LossValue = new UIText[2];

	// Token: 0x0400515E RID: 20830
	private UIText[] text_ArmyTitle = new UIText[2];

	// Token: 0x0400515F RID: 20831
	private UIText[] text_Strength = new UIText[2];

	// Token: 0x04005160 RID: 20832
	private UIText[] text_Country = new UIText[2];

	// Token: 0x04005161 RID: 20833
	private UIText[] text_Dominance = new UIText[2];

	// Token: 0x04005162 RID: 20834
	private UIText[] text_Name = new UIText[2];

	// Token: 0x04005163 RID: 20835
	private UIText[] text_MainHero_F = new UIText[2];

	// Token: 0x04005164 RID: 20836
	private UIText[] text_Vip = new UIText[2];

	// Token: 0x04005165 RID: 20837
	private UIText[] text_LA = new UIText[4];

	// Token: 0x04005166 RID: 20838
	private UIText[] text_RA = new UIText[8];

	// Token: 0x04005167 RID: 20839
	private UIText[] text_DW = new UIText[3];

	// Token: 0x04005168 RID: 20840
	private UIText[] text_Resources = new UIText[5];

	// Token: 0x04005169 RID: 20841
	private UIText[] text_HeroExp = new UIText[5];

	// Token: 0x0400516A RID: 20842
	private UIText[] text_HeroExp2 = new UIText[5];

	// Token: 0x0400516B RID: 20843
	private UIText[] text_CoordinateMainHero = new UIText[2];

	// Token: 0x0400516C RID: 20844
	private UIText[] text_tmpStr = new UIText[25];

	// Token: 0x0400516D RID: 20845
	private UIText[] text_Quanmie = new UIText[8];

	// Token: 0x0400516E RID: 20846
	private UIText[] text_BossTitle = new UIText[2];

	// Token: 0x0400516F RID: 20847
	private UIText[] text_BossL = new UIText[2];

	// Token: 0x04005170 RID: 20848
	private UIText[] text_BossR = new UIText[3];

	// Token: 0x04005171 RID: 20849
	private UIText[] text_BossFight = new UIText[3];

	// Token: 0x04005172 RID: 20850
	private UIText text_LF;

	// Token: 0x04005173 RID: 20851
	private UIText text_RF;

	// Token: 0x04005174 RID: 20852
	private UIText text_Formation;

	// Token: 0x04005175 RID: 20853
	private UIText[] text_Buff = new UIText[9];

	// Token: 0x04005176 RID: 20854
	private UIText[] text_FailureBuff = new UIText[3];

	// Token: 0x04005177 RID: 20855
	private CString[] Cstr_Coordinate = new CString[2];

	// Token: 0x04005178 RID: 20856
	private CString Cstr_TitleName;

	// Token: 0x04005179 RID: 20857
	private CString Cstr_Page;

	// Token: 0x0400517A RID: 20858
	private CString Cstr_FightingKind;

	// Token: 0x0400517B RID: 20859
	private CString Cstr_L_Exp;

	// Token: 0x0400517C RID: 20860
	private CString[] Cstr_ItemQty = new CString[30];

	// Token: 0x0400517D RID: 20861
	private CString[] Cstr_Offensive = new CString[2];

	// Token: 0x0400517E RID: 20862
	private CString[] Cstr_LossValue = new CString[2];

	// Token: 0x0400517F RID: 20863
	private CString[] Cstr_Strength = new CString[2];

	// Token: 0x04005180 RID: 20864
	private CString[] Cstr_Resources = new CString[5];

	// Token: 0x04005181 RID: 20865
	private CString[] Cstr_Country = new CString[2];

	// Token: 0x04005182 RID: 20866
	private CString[] Cstr_Dominance = new CString[2];

	// Token: 0x04005183 RID: 20867
	private CString[] Cstr_CoordinateMainHero = new CString[2];

	// Token: 0x04005184 RID: 20868
	private CString[] Cstr_Name = new CString[2];

	// Token: 0x04005185 RID: 20869
	private CString[] Cstr_LA = new CString[4];

	// Token: 0x04005186 RID: 20870
	private CString[] Cstr_RA = new CString[8];

	// Token: 0x04005187 RID: 20871
	private CString[] Cstr_DW = new CString[3];

	// Token: 0x04005188 RID: 20872
	private CString[] Cstr_HeroExp = new CString[5];

	// Token: 0x04005189 RID: 20873
	private CString[] Cstr_BossR = new CString[2];

	// Token: 0x0400518A RID: 20874
	private CString[] Cstr_BossFight = new CString[2];

	// Token: 0x0400518B RID: 20875
	private CString[] Cstr_BossL = new CString[2];

	// Token: 0x0400518C RID: 20876
	private CString Cstr_BoosHead;

	// Token: 0x0400518D RID: 20877
	private CString Cstr_Text;

	// Token: 0x0400518E RID: 20878
	private CString[] Cstr_Quanmie = new CString[4];

	// Token: 0x0400518F RID: 20879
	private CString Cstr_NpcTroops;

	// Token: 0x04005190 RID: 20880
	private CString Cstr_QuanmieNpcTroops;

	// Token: 0x04005191 RID: 20881
	private CString Cstr_LF;

	// Token: 0x04005192 RID: 20882
	private CString Cstr_RF;

	// Token: 0x04005193 RID: 20883
	private DataManager DM;

	// Token: 0x04005194 RID: 20884
	private GUIManager GUIM;

	// Token: 0x04005195 RID: 20885
	private PetManager PM;

	// Token: 0x04005196 RID: 20886
	private Font TTFont;

	// Token: 0x04005197 RID: 20887
	private Door door;

	// Token: 0x04005198 RID: 20888
	private UISpritesArray SArray;

	// Token: 0x04005199 RID: 20889
	private Material mMaT;

	// Token: 0x0400519A RID: 20890
	private Material IconMaterial;

	// Token: 0x0400519B RID: 20891
	private Material FrameMaterial;

	// Token: 0x0400519C RID: 20892
	private float tmpH;

	// Token: 0x0400519D RID: 20893
	private int mItemCount;

	// Token: 0x0400519E RID: 20894
	private int tmpNum;

	// Token: 0x0400519F RID: 20895
	private bool bQuanmier;

	// Token: 0x040051A0 RID: 20896
	private bool bWin = true;

	// Token: 0x040051A1 RID: 20897
	private bool IsAttack = true;

	// Token: 0x040051A2 RID: 20898
	private int mType;

	// Token: 0x040051A3 RID: 20899
	private float ShowMainHeroTime1;

	// Token: 0x040051A4 RID: 20900
	private float ShowMainHeroTime2;

	// Token: 0x040051A5 RID: 20901
	private float ShowVsTime;

	// Token: 0x040051A6 RID: 20902
	private float ShowReplay;

	// Token: 0x040051A7 RID: 20903
	private float tempL;

	// Token: 0x040051A8 RID: 20904
	private float MoveTime1;

	// Token: 0x040051A9 RID: 20905
	private float MoveTime2;

	// Token: 0x040051AA RID: 20906
	private float TmpTime;

	// Token: 0x040051AB RID: 20907
	private CString[] StrResources = new CString[5];

	// Token: 0x040051AC RID: 20908
	private CombatReport Report;

	// Token: 0x040051AD RID: 20909
	private MyFavorite Favor = new MyFavorite(MailType.EMAIL_MAX, 0u);

	// Token: 0x040051AE RID: 20910
	private int MaxLetterNum;

	// Token: 0x040051AF RID: 20911
	private Hero tmpHero;

	// Token: 0x040051B0 RID: 20912
	private Vector3 Vec3Instance;

	// Token: 0x040051B1 RID: 20913
	private uint tmpValue;

	// Token: 0x040051B2 RID: 20914
	private Vector2 tmpV;

	// Token: 0x040051B3 RID: 20915
	private int mOpenKind;

	// Token: 0x040051B4 RID: 20916
	private uint[] tmpHeroExp = new uint[5];

	// Token: 0x040051B5 RID: 20917
	private ushort[] tmpHeroID = new ushort[5];

	// Token: 0x040051B6 RID: 20918
	private byte[] tmpHeroStar = new byte[5];

	// Token: 0x040051B7 RID: 20919
	private ushort[] ItemID = new ushort[30];

	// Token: 0x040051B8 RID: 20920
	private ushort[] ItemNum = new ushort[30];

	// Token: 0x040051B9 RID: 20921
	private byte[] ItemRank = new byte[30];

	// Token: 0x040051BA RID: 20922
	private int AssetKey;

	// Token: 0x040051BB RID: 20923
	private ushort mBossHead;

	// Token: 0x040051BC RID: 20924
	private bool bInitFS;

	// Token: 0x040051BD RID: 20925
	private bool bInitBoss;

	// Token: 0x040051BE RID: 20926
	private bool bSetFSShow;

	// Token: 0x040051BF RID: 20927
	private bool[] bSetHero = new bool[5];

	// Token: 0x040051C0 RID: 20928
	private bool bCreateItem;

	// Token: 0x040051C1 RID: 20929
	private bool bInitItemBase;

	// Token: 0x040051C2 RID: 20930
	private byte bSetItemData;

	// Token: 0x040051C3 RID: 20931
	private RectTransform NpcItemRT;

	// Token: 0x040051C4 RID: 20932
	private UIButton btn_NpcItemIcon;

	// Token: 0x040051C5 RID: 20933
	private UIButton btn_NpcItemName;

	// Token: 0x040051C6 RID: 20934
	private UIButton btn_NpcCoordinate;

	// Token: 0x040051C7 RID: 20935
	private Image[] Img_NpcMainHero = new Image[3];

	// Token: 0x040051C8 RID: 20936
	private Image Img_NpcItemHint;

	// Token: 0x040051C9 RID: 20937
	private UIText text_NpcInfo;

	// Token: 0x040051CA RID: 20938
	private UIText text_QuanmierNpcInfo;

	// Token: 0x040051CB RID: 20939
	private UIText text_NpcCoordinate;

	// Token: 0x040051CC RID: 20940
	private UIText text_NpcName;

	// Token: 0x040051CD RID: 20941
	private UIText text_NpcItemName;

	// Token: 0x040051CE RID: 20942
	private UIText text_NpcItemfull;

	// Token: 0x040051CF RID: 20943
	private UIText text_NpcItemHint;

	// Token: 0x040051D0 RID: 20944
	private UIText[] text_NpcTroops = new UIText[2];

	// Token: 0x040051D1 RID: 20945
	private UIText[] text_QuanmierNpcTroops = new UIText[2];

	// Token: 0x040051D2 RID: 20946
	private bool bNpcMode;

	// Token: 0x040051D3 RID: 20947
	private RectTransform AllianceBossItemRT;

	// Token: 0x040051D4 RID: 20948
	private UIText text_AllianceBossStr;

	// Token: 0x040051D5 RID: 20949
	private bool bAllianceBossMode;

	// Token: 0x040051D6 RID: 20950
	private int tmpAllianceBosstest;

	// Token: 0x040051D7 RID: 20951
	private bool bSaveY;

	// Token: 0x040051D8 RID: 20952
	public ushort[] m_A_Skill_ID = new ushort[10];

	// Token: 0x040051D9 RID: 20953
	public ushort[] m_A_DeBf_Skill_ID = new ushort[10];

	// Token: 0x040051DA RID: 20954
	public byte[] m_A_Skill_LV = new byte[10];

	// Token: 0x040051DB RID: 20955
	public byte[] m_A_DeBf_Skill_LV = new byte[10];

	// Token: 0x040051DC RID: 20956
	public ushort[] m_D_Skill_ID = new ushort[10];

	// Token: 0x040051DD RID: 20957
	public ushort[] m_D_DeBf_Skill_ID = new ushort[10];

	// Token: 0x040051DE RID: 20958
	public byte[] m_D_Skill_LV = new byte[10];

	// Token: 0x040051DF RID: 20959
	public byte[] m_D_DeBf_Skill_LV = new byte[10];

	// Token: 0x040051E0 RID: 20960
	private int mA_Skill_L;

	// Token: 0x040051E1 RID: 20961
	private int mD_Skill_R;

	// Token: 0x040051E2 RID: 20962
	private int mDeBf_A_L;

	// Token: 0x040051E3 RID: 20963
	private int mDeBf_D_R;

	// Token: 0x040051E4 RID: 20964
	private bool bDoNotShow;

	// Token: 0x040051E5 RID: 20965
	private UIButtonHint tmpbtnHint;

	// Token: 0x040051E6 RID: 20966
	private CString S1024 = StringManager.Instance.StaticString1024();

	// Token: 0x040051E7 RID: 20967
	private PetSkillTbl skill;

	// Token: 0x040051E8 RID: 20968
	private float tmpH1;

	// Token: 0x040051E9 RID: 20969
	private float tmpH2;
}
