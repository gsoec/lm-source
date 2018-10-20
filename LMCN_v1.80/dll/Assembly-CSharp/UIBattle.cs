using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x020001F1 RID: 497
public class UIBattle : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnUpDownHandler, IUIHIBtnDrag
{
	// Token: 0x06000908 RID: 2312 RVA: 0x000B8098 File Offset: 0x000B6298
	private void Start()
	{
	}

	// Token: 0x06000909 RID: 2313 RVA: 0x000B809C File Offset: 0x000B629C
	public override void OnOpen(int arg1, int arg2)
	{
		this.m_Str = new CString[this.MaxStr];
		for (int i = 0; i < this.MaxStr; i++)
		{
			int stringLength;
			if (i < this.MaxStrLen.Length)
			{
				stringLength = this.MaxStrLen[i];
			}
			else
			{
				stringLength = 30;
			}
			this.m_Str[i] = StringManager.Instance.SpawnString(stringLength);
		}
		this.m_transform = base.transform;
		this.bc = (GameManager.ActiveGameplay as BattleController);
		this.iconMat = GUIManager.Instance.m_IconSpriteAsset.GetMaterial();
		if (this.bc.BattleType == EBattleType.PLAYBACK)
		{
			this.bNpcBossMod = true;
		}
		if (this.bc.BattleType == EBattleType.PVP)
		{
			this.bArenaMod = true;
		}
		this.alertBlock = this.m_transform.GetChild(0);
		this.alertBlock_T = this.m_transform.GetChild(0).GetChild(0).GetComponent<Image>();
		this.alertBlock_B = this.m_transform.GetChild(0).GetChild(1).GetComponent<Image>();
		this.alertBlock_R = this.m_transform.GetChild(0).GetChild(2).GetComponent<Image>();
		this.alertBlock_L = this.m_transform.GetChild(0).GetChild(3).GetComponent<Image>();
		this.InitChallegeMode();
		this.InitIcon();
		if (this.bNpcBossMod)
		{
			this.bossLv = (byte)(arg1 >> 16);
			this.bossID = (ushort)(arg1 & 65535);
			this.bossDataIdx = arg2;
			MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.bossID);
			this.m_Str[3].ClearString();
			this.m_Str[3].IntToFormat((long)this.bossLv, 1, false);
			this.m_Str[3].StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.NameID));
			this.m_Str[3].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(883u));
			this.npcBossID.text = this.m_Str[3].ToString();
			this.npcBossID.SetAllDirty();
			this.npcBossID.cachedTextGenerator.Invalidate();
			if (this.bc != null && this.bossDataIdx < 20)
			{
				this.bossCurHp = this.bc.enemyAttr[this.bossDataIdx].CUR_HP;
				this.bossMaxHp = this.bc.enemyAttr[this.bossDataIdx].MAX_HP;
			}
			this.SetNpcBossHP(this.bossCurHp, this.bossMaxHp);
			this.itemTextTf.gameObject.SetActive(false);
			this.checkpointTextTf.gameObject.SetActive(false);
			this.infoImg0.gameObject.SetActive(false);
			this.infoImg2.gameObject.SetActive(false);
			this.infoImg3.gameObject.SetActive(false);
			this.autoButtonUp.image.sprite = this.spriteArray.GetSprite(1);
		}
		if (this.bArenaMod)
		{
			this.itemTextTf.gameObject.SetActive(false);
			this.checkpointTextTf.gameObject.SetActive(false);
			this.infoImg0.gameObject.SetActive(false);
			this.infoImg2.gameObject.SetActive(false);
			this.infoImg3.gameObject.SetActive(false);
			this.autoButtonUp.image.sprite = this.spriteArray.GetSprite(1);
		}
		this.npcHpTf.gameObject.SetActive(this.bNpcBossMod);
		GUIManager.Instance.BattleOpenChatBox();
		this.CheckAutoBattleStatus();
		if (BattleController.IsDareMode)
		{
			this.SetBattleChallengeIcons();
		}
		GUIManager.Instance.CheckBattleAttackState();
	}

	// Token: 0x0600090A RID: 2314 RVA: 0x000B8470 File Offset: 0x000B6670
	private void InitChallegeMode()
	{
		if (!BattleController.IsDareMode)
		{
			return;
		}
		StageManager stageDataController = DataManager.StageDataController;
		this.bChallegeMode = true;
		byte currentNodus = stageDataController.currentNodus;
		LevelEX levelEXBycurrentPointID = stageDataController.GetLevelEXBycurrentPointID(0);
		ushort inKey;
		if (currentNodus == 1)
		{
			inKey = levelEXBycurrentPointID.NodusOneID;
		}
		else if (currentNodus == 2)
		{
			inKey = levelEXBycurrentPointID.NodusTwoID;
		}
		else
		{
			inKey = levelEXBycurrentPointID.NodusThrID;
		}
		StageConditionData recordByKey = stageDataController.StageConditionDataTable.GetRecordByKey(inKey);
		int num = recordByKey.ConditionArray.Length;
		for (int i = 0; i < num; i++)
		{
			if (recordByKey.ConditionArray[i].ConditionID == 4)
			{
				this.RestrictBlood = recordByKey.ConditionArray[i].FactorA;
			}
			else if (recordByKey.ConditionArray[i].ConditionID == 7 && recordByKey.ConditionArray[i].FactorA >= 1 && recordByKey.ConditionArray[i].FactorA <= 3)
			{
				this.ChallegeCheckPointTimeRule[(int)(recordByKey.ConditionArray[i].FactorA - 1)] = recordByKey.ConditionArray[i].FactorB;
			}
		}
	}

	// Token: 0x0600090B RID: 2315 RVA: 0x000B85B8 File Offset: 0x000B67B8
	public override void OnClose()
	{
		for (int i = 0; i < this.MaxStr; i++)
		{
			StringManager.Instance.DeSpawnString(this.m_Str[i]);
			this.m_Str[i] = null;
		}
		Time.timeScale = 1f;
	}

	// Token: 0x0600090C RID: 2316 RVA: 0x000B8604 File Offset: 0x000B6804
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x0600090D RID: 2317 RVA: 0x000B8630 File Offset: 0x000B6830
	public void Refresh_FontTexture()
	{
		UIText component = base.transform.GetChild(27).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(28).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(29).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(36).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(37).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(37).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(38).GetChild(0).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(38).GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(38).GetChild(2).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = base.transform.GetChild(40).GetChild(0).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		if (this.text_ChallengeContinuance != null && this.text_ChallengeContinuance.enabled)
		{
			this.text_ChallengeContinuance.enabled = false;
			this.text_ChallengeContinuance.enabled = true;
		}
		if (this.text_ChallengeExit != null && this.text_ChallengeExit.enabled)
		{
			this.text_ChallengeExit.enabled = false;
			this.text_ChallengeExit.enabled = true;
		}
		if (this.text_ChallengeGgain != null && this.text_ChallengeGgain.enabled)
		{
			this.text_ChallengeGgain.enabled = false;
			this.text_ChallengeGgain.enabled = true;
		}
		if (this.text_ChallengeTitle != null && this.text_ChallengeTitle.enabled)
		{
			this.text_ChallengeTitle.enabled = false;
			this.text_ChallengeTitle.enabled = true;
		}
		if (this.text_ChallengeHint != null && this.text_ChallengeHint.enabled)
		{
			this.text_ChallengeHint.enabled = false;
			this.text_ChallengeHint.enabled = true;
		}
		this.RefreshUIHIBtnText();
	}

	// Token: 0x0600090E RID: 2318 RVA: 0x000B89CC File Offset: 0x000B6BCC
	private void RefreshUIHIBtnText()
	{
		if (this.buttons != null)
		{
			for (int i = 0; i < this.buttons.Length; i++)
			{
				if (this.buttons[i] != null)
				{
					this.buttons[i].Refresh_FontTexture();
				}
			}
		}
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x000B8A20 File Offset: 0x000B6C20
	private void InitIcon()
	{
		byte b;
		HeroBattleData[] array;
		if (this.bc.BattleType == EBattleType.PLAYBACK)
		{
			b = GUIManager.Instance.WM_HeroCount;
			array = GUIManager.Instance.WM_HeroData;
		}
		else if (this.bc.BattleType == EBattleType.PVP)
		{
			array = new HeroBattleData[5];
			b = 0;
			for (int i = 0; i < 5; i++)
			{
				array[i] = ArenaManager.Instance.ArenaPlayingData.MyHeroData[i];
				if (array[i].HeroID != 0)
				{
					b += 1;
				}
			}
		}
		else
		{
			b = DataManager.Instance.heroCount;
			array = DataManager.Instance.heroBattleData;
		}
		Transform child;
		for (int j = 0; j < 5; j++)
		{
			int battlePosID = this.GetBattlePosID(j);
			bool active = battlePosID < (int)b;
			ushort heroID = array[battlePosID].HeroID;
			child = this.m_transform.GetChild(13 + j).GetChild(0);
			this.btnRt[j] = child.GetComponent<RectTransform>();
			this.buttons[j] = child.GetComponent<UIHIBtn>();
			child = child.GetChild(0);
			this.selectImageRt[j] = child.GetComponent<RectTransform>();
			this.selectImage[j] = child.GetComponent<Image>();
			this.selectImage[j].gameObject.AddComponent<IgnoreRaycast>();
			this.selectImage[j].gameObject.SetActive(false);
			this.selectTween[j] = child.GetComponent<uTweenAlpha>();
			child = this.m_transform.GetChild(13 + j).GetChild(0);
			child = child.GetChild(1);
			this.deadImages[j] = child.GetComponent<Image>();
			this.deadImages[j].gameObject.SetActive(false);
			this.buttons[j].image.material = this.iconMat;
			this.buttons[j].interactable = true;
			this.buttons[j].m_UpDownHandler = this;
			this.buttons[j].m_DHandler = this;
			this.buttons[j].m_BtnID1 = j;
			this.buttons[j].transform.parent.gameObject.SetActive(active);
			GUIManager.Instance.InitianHeroItemImg(this.buttons[j].transform, eHeroOrItem.Hero, 0, 0, 0, 0, true, false, true, false);
			if (DataManager.Instance.curHeroData.ContainsKey((uint)heroID))
			{
				CurHeroData curHeroData = DataManager.Instance.curHeroData[(uint)heroID];
				this.CheckChalleneHeroRule(ref curHeroData);
				GUIManager.Instance.ChangeHeroItemImg(this.buttons[j].transform, eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
			}
			else
			{
				CurHeroData curHeroData = default(CurHeroData);
				bool flag = false;
				for (int k = 0; k < DataManager.Instance.curTempHeroData.Length; k++)
				{
					if (DataManager.Instance.curTempHeroData[k].ID == heroID)
					{
						curHeroData = DataManager.Instance.curTempHeroData[k];
						this.CheckChalleneHeroRule(ref curHeroData);
						flag = true;
						break;
					}
				}
				if (flag)
				{
					GUIManager.Instance.ChangeHeroItemImg(this.buttons[j].transform, eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
				}
			}
			this.deadImages[j].transform.SetSiblingIndex(3);
			this.selectImageRt[j].SetAsLastSibling();
			child = this.m_transform.transform.GetChild(3 + j);
			this.hpSlidersRt[j] = child.GetComponent<RectTransform>();
			this.hpSliders[j] = child.GetComponent<Slider>();
			this.hpSliders[j].gameObject.SetActive(active);
			this.weekHpSlider[j] = child.GetChild(0).GetChild(0).GetChild(0);
			this.hpImage[j] = child.GetChild(0).GetChild(0).GetComponent<Image>();
			this.ChallegeBloodRestrictSL[j] = child.GetChild(0).GetChild(1).GetComponent<Slider>();
			if (this.bChallegeMode && this.RestrictBlood > 0)
			{
				this.ChallegeBloodRestrictSL[j].value = (float)this.RestrictBlood;
				this.ChallegeBloodRestrictSL[j].gameObject.SetActive(true);
			}
			child = this.m_transform.transform.GetChild(8 + j);
			this.mpSlidersRt[j] = child.GetComponent<RectTransform>();
			this.mpSliders[j] = child.GetComponent<Slider>();
			this.mpSliders[j].gameObject.SetActive(active);
			this.maxMpSlider[j] = child.GetChild(0).GetChild(0).GetChild(0);
			this.iconScaleValue[j].NowType = 1;
			this.IconSliserTime[j].bShowIconEffect = 0;
		}
		child = this.m_transform.transform.GetChild(18);
		this.kingBtn = child.GetComponent<UIButton>();
		this.kingBtn.m_BtnID1 = 5;
		this.kingBtn.m_Handler = this;
		child = this.m_transform.transform.GetChild(19);
		this.kingBar = child.GetComponent<Image>();
		child = this.m_transform.transform.GetChild(20);
		this.nextButton1 = child.GetComponent<UIButton>();
		this.nextButton1.m_BtnID1 = 6;
		this.nextButton1.m_Handler = this;
		child = this.m_transform.transform.GetChild(21);
		this.nextButton2 = child.GetComponent<UIButton>();
		this.nextButton2.m_BtnID1 = 6;
		this.nextButton2.m_Handler = this;
		this.infoImg0 = this.m_transform.transform.GetChild(22);
		this.infoImg2 = this.m_transform.transform.GetChild(24);
		this.infoImg3 = this.m_transform.transform.GetChild(25);
		if (GUIManager.Instance.IsArabic)
		{
			this.m_transform.transform.GetChild(26).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		child = this.m_transform.transform.GetChild(27);
		this.timeText = child.GetComponent<UIText>();
		this.timeText.font = GUIManager.Instance.GetTTFFont();
		this.itemTextTf = this.m_transform.transform.GetChild(28);
		this.itemText = this.itemTextTf.GetComponent<UIText>();
		this.itemText.font = GUIManager.Instance.GetTTFFont();
		this.itemText.text = "0";
		this.checkpointTextTf = this.m_transform.transform.GetChild(29);
		this.checkpointText = this.checkpointTextTf.GetComponent<UIText>();
		this.checkpointText.font = GUIManager.Instance.GetTTFFont();
		this.SetKingBar(0f);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			Image component = this.m_transform.transform.GetChild(30).GetComponent<Image>();
			if (component)
			{
				component.enabled = false;
			}
		}
		child = this.m_transform.transform.GetChild(31);
		this.pauseButton = child.GetComponent<UIButton>();
		this.pauseButton.m_BtnID1 = 7;
		this.pauseButton.m_Handler = this;
		child = this.m_transform.transform.GetChild(33);
		this.autoButtonUp = child.GetComponent<UIButton>();
		this.autoButtonUp.m_BtnID1 = 8;
		this.autoButtonUp.m_Handler = this;
		if (this.bNpcBossMod || this.bArenaMod)
		{
			child.gameObject.AddComponent<IgnoreRaycast>();
			child.GetChild(0).gameObject.SetActive(true);
		}
		if (this.CheckShowAutoBtn())
		{
			this.autoButtonUp.gameObject.SetActive(true);
		}
		else
		{
			this.autoButtonUp.gameObject.SetActive(false);
			Transform child2 = this.m_transform.transform.GetChild(32);
			child2.gameObject.SetActive(false);
		}
		if (GUIManager.Instance.IsArabic)
		{
			this.autoButtonUp.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.spriteArray = child.GetComponent<UISpritesArray>();
		child = this.m_transform.transform.GetChild(34);
		this.debugButton = child.GetComponent<UIButton>();
		this.debugButton.m_BtnID1 = 10;
		this.debugButton.m_Handler = this;
		this.debugButton.gameObject.SetActive(false);
		child = this.m_transform.transform.GetChild(35);
		this.CameraBtn = child.GetComponent<UIButton>();
		this.CameraBtn.m_BtnID1 = 11;
		this.CameraBtn.m_Handler = this;
		this.CameraBtn.gameObject.SetActive(true);
		this.PausePanel = this.m_transform.GetChild(38);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			((RectTransform)this.PausePanel).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			((RectTransform)this.PausePanel).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		UIButton component2 = this.PausePanel.GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 12;
		UIText component3 = this.PausePanel.GetChild(0).GetChild(0).GetComponent<UIText>();
		component3.font = GUIManager.Instance.GetTTFFont();
		component3.text = DataManager.Instance.mStringTable.GetStringByID(241u);
		UIButton component4 = this.PausePanel.GetChild(1).GetComponent<UIButton>();
		component4.m_Handler = this;
		component4.m_BtnID1 = 13;
		if (GUIManager.Instance.IsArabic)
		{
			component4.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		component3 = this.PausePanel.GetChild(1).GetChild(0).GetComponent<UIText>();
		component3.font = GUIManager.Instance.GetTTFFont();
		component3.text = DataManager.Instance.mStringTable.GetStringByID(240u);
		UIButton component5 = this.PausePanel.GetChild(2).GetComponent<UIButton>();
		component5.m_Handler = this;
		component5.m_BtnID1 = 14;
		component3 = this.PausePanel.GetChild(2).GetChild(0).GetComponent<UIText>();
		component3.font = GUIManager.Instance.GetTTFFont();
		component3.text = DataManager.Instance.mStringTable.GetStringByID(801u);
		this.challengePausePanel = this.m_transform.GetChild(39);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			((RectTransform)this.challengePausePanel).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			((RectTransform)this.challengePausePanel).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		this.text_ChallengeTitle = this.challengePausePanel.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_ChallengeTitle.font = GUIManager.Instance.GetTTFFont();
		this.text_ChallengeTitle.text = DataManager.Instance.mStringTable.GetStringByID(10005u);
		UIButton component6 = this.challengePausePanel.GetChild(2).GetComponent<UIButton>();
		component6.m_Handler = this;
		component6.m_BtnID1 = 12;
		this.text_ChallengeExit = this.challengePausePanel.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.text_ChallengeExit.font = GUIManager.Instance.GetTTFFont();
		this.text_ChallengeExit.text = DataManager.Instance.mStringTable.GetStringByID(241u);
		UIButton component7 = this.challengePausePanel.GetChild(3).GetComponent<UIButton>();
		component7.m_Handler = this;
		component7.m_BtnID1 = 13;
		if (GUIManager.Instance.IsArabic)
		{
			component4.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.text_ChallengeContinuance = this.challengePausePanel.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.text_ChallengeContinuance.font = GUIManager.Instance.GetTTFFont();
		this.text_ChallengeContinuance.text = DataManager.Instance.mStringTable.GetStringByID(240u);
		UIButton component8 = this.challengePausePanel.GetChild(4).GetComponent<UIButton>();
		component8.m_Handler = this;
		component8.m_BtnID1 = 14;
		this.text_ChallengeGgain = this.challengePausePanel.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.text_ChallengeGgain.font = GUIManager.Instance.GetTTFFont();
		this.text_ChallengeGgain.text = DataManager.Instance.mStringTable.GetStringByID(801u);
		this.text_ChallengeHint = this.challengePausePanel.GetChild(5).GetChild(0).GetComponent<UIText>();
		this.text_ChallengeHint.font = GUIManager.Instance.GetTTFFont();
		Transform child3 = this.challengePausePanel.GetChild(1);
		for (int l = 0; l < this.battleChallengeIcons.Length; l++)
		{
			this.battleChallengeIcons[l].Init();
			this.battleChallengeIcons[l].gameObj = child3.GetChild(l).gameObject;
			this.battleChallengeIcons[l].Btn = child3.GetChild(l).GetChild(0).GetComponent<UIButton>();
			UIButtonHint uibuttonHint = this.battleChallengeIcons[l].Btn.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.Parm1 = (ushort)l;
			uibuttonHint.m_Handler = this;
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			this.battleChallengeIcons[l].Background = child3.GetChild(l).GetChild(0).GetComponent<Image>();
			this.battleChallengeIcons[l].Frame = child3.GetChild(l).GetChild(1).GetComponent<Image>();
			this.battleChallengeIcons[l].Item = child3.GetChild(l).GetChild(2).GetComponent<Image>();
		}
		if (this.bNpcBossMod || this.bArenaMod)
		{
			((RectTransform)component2.transform).anchoredPosition = new Vector2(-101f, 25f);
			((RectTransform)component4.transform).anchoredPosition = new Vector2(103f, 25f);
			component5.gameObject.SetActive(false);
		}
		this.m_CenterMsgTf = this.m_transform.GetChild(40).GetChild(0);
		this.m_CenterMsgBg = this.m_CenterMsgTf.GetComponent<Image>();
		this.m_CenterMsgText = this.m_CenterMsgTf.GetChild(0).GetComponent<UIText>();
		this.m_CenterMsgText.font = GUIManager.Instance.GetTTFFont();
		this.m_IPhoneXPPanel = this.m_transform.GetChild(41);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			this.m_IPhoneXPPanel.gameObject.SetActive(true);
		}
		this.m_CountDownRect = this.m_transform.GetChild(36).GetComponent<RectTransform>();
		this.m_CountDownText = this.m_transform.GetChild(36).GetComponent<UIText>();
		this.m_CountDownText.font = GUIManager.Instance.GetTTFFont();
		this.npcHpTf = this.m_transform.GetChild(37);
		this.npcHpImg = this.npcHpTf.GetChild(0).GetChild(0).GetComponent<Image>();
		this.npcBossID = this.npcHpTf.GetChild(1).GetComponent<UIText>();
		this.npcBossHpValue = this.npcHpTf.GetChild(2).GetComponent<UIText>();
		this.npcBossID.font = GUIManager.Instance.GetTTFFont();
		this.npcBossHpValue.font = GUIManager.Instance.GetTTFFont();
		if (GUIManager.Instance.IsArabic)
		{
			this.SwapBtn(this.buttons[0], this.buttons[4]);
			this.SwapBtn(this.buttons[1], this.buttons[3]);
			this.SwapSlider(this.hpSlidersRt[0], this.hpSlidersRt[4]);
			this.SwapSlider(this.hpSlidersRt[1], this.hpSlidersRt[3]);
			this.SwapSlider(this.mpSlidersRt[0], this.mpSlidersRt[4]);
			this.SwapSlider(this.mpSlidersRt[1], this.mpSlidersRt[3]);
			Vector3 localScale = this.nextButton1.GetComponent<RectTransform>().localScale;
			localScale.x *= -1f;
			this.nextButton1.GetComponent<RectTransform>().localScale = localScale;
			uTweenPosition component9 = this.nextButton1.GetComponent<uTweenPosition>();
			uTweenPosition uTweenPosition = component9;
			uTweenPosition.from.x = uTweenPosition.from.x * -1f;
			uTweenPosition uTweenPosition2 = component9;
			uTweenPosition2.to.x = uTweenPosition2.to.x * -1f;
			localScale = this.nextButton2.GetComponent<RectTransform>().localScale;
			localScale.x *= -1f;
			this.nextButton2.GetComponent<RectTransform>().localScale = localScale;
			component9 = this.nextButton2.GetComponent<uTweenPosition>();
			uTweenPosition uTweenPosition3 = component9;
			uTweenPosition3.from.x = uTweenPosition3.from.x * -1f;
			uTweenPosition uTweenPosition4 = component9;
			uTweenPosition4.to.x = uTweenPosition4.to.x * -1f;
		}
	}

	// Token: 0x06000910 RID: 2320 RVA: 0x000B9BC4 File Offset: 0x000B7DC4
	private void CheckChalleneHeroRule(ref CurHeroData data)
	{
		if (!this.bChallegeMode)
		{
			return;
		}
		LevelEX levelEXBycurrentPointID = DataManager.StageDataController.GetLevelEXBycurrentPointID(0);
		data.Level = levelEXBycurrentPointID.LV;
		data.Enhance = levelEXBycurrentPointID.Rank;
		data.Star = levelEXBycurrentPointID.Star;
	}

	// Token: 0x06000911 RID: 2321 RVA: 0x000B9C10 File Offset: 0x000B7E10
	private void SwapBtn(UIHIBtn btn1, UIHIBtn btn2)
	{
		Vector2 anchoredPosition = btn1.gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition;
		btn1.gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition = btn2.gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition;
		btn2.gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
	}

	// Token: 0x06000912 RID: 2322 RVA: 0x000B9C88 File Offset: 0x000B7E88
	private void SwapSlider(RectTransform rt1, RectTransform rt2)
	{
		Vector2 anchoredPosition = rt1.anchoredPosition;
		rt1.anchoredPosition = rt2.anchoredPosition;
		rt2.anchoredPosition = anchoredPosition;
	}

	// Token: 0x06000913 RID: 2323 RVA: 0x000B9CB0 File Offset: 0x000B7EB0
	public void OnHIButtonDragExit(UIHIBtn sender)
	{
		if (this.projectorTrans == null && this.ultraSkillWorking)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			Vector3? vector = BattleController.Tracing(ray.direction, ray.origin);
			if (vector != null)
			{
				this.projectorTrans = this.bc.setupProjector(true, ref this.projectorType);
				if (this.projectorType == 1)
				{
					this.projectorTrans.localPosition = vector.Value;
				}
				else if (this.projectorType == 3 || this.projectorType == 4)
				{
					this.projectorTrans.localPosition = Vector3.forward * this.bc.PJ_FireRadius * 0.5f;
				}
			}
			this.bProjectorMode = true;
		}
	}

	// Token: 0x06000914 RID: 2324 RVA: 0x000B9D9C File Offset: 0x000B7F9C
	public void OnHIButtonDrag(UIHIBtn sender)
	{
	}

	// Token: 0x06000915 RID: 2325 RVA: 0x000B9DA0 File Offset: 0x000B7FA0
	public void OnHIButtonDragEnd(UIHIBtn sender)
	{
	}

	// Token: 0x06000916 RID: 2326 RVA: 0x000B9DA4 File Offset: 0x000B7FA4
	public void InterruptInput()
	{
		if (this.ultraSkillWorking)
		{
			this.OnHIButtonUp(this.buttons[0]);
		}
	}

	// Token: 0x06000917 RID: 2327 RVA: 0x000B9DC0 File Offset: 0x000B7FC0
	public void OnHIButtonUp(UIHIBtn sender)
	{
		if (this.projectorTrans == null && this.ultraSkillWorking)
		{
			this.bc.inputUltra(false, null);
			this.ultraSkillWorking = false;
		}
		else if (this.projectorTrans != null)
		{
			this.bc.setupProjector(false, ref this.projectorType);
			this.bc.inputUltra(true, new Ray?(this.rayCache));
			this.ultraSkillWorking = false;
			this.projectorTrans = null;
			this.bProjectorMode = false;
		}
	}

	// Token: 0x06000918 RID: 2328 RVA: 0x000B9E5C File Offset: 0x000B805C
	public void OnButtonClick(UIButton sender)
	{
		this.UseSkill(sender.m_BtnID1);
	}

	// Token: 0x06000919 RID: 2329 RVA: 0x000B9E6C File Offset: 0x000B806C
	public void OnHIButtonDown(UIHIBtn sender)
	{
		if (this.bNpcBossMod || this.bArenaMod)
		{
			return;
		}
		if (this.bc.StartAutoBattle)
		{
			return;
		}
		int btnID = sender.m_BtnID1;
		if (btnID < 5 && btnID >= 0 && this.selectImage[btnID].gameObject.activeSelf)
		{
			int battlePosID = this.GetBattlePosID(btnID);
			if (!this.ultraSkillWorking && this.bc.checkInitUltra(battlePosID))
			{
				this.curUltraSkillerPos = this.bc.playerUnit[battlePosID].Position;
				this.ultraSkillWorking = true;
				this.rayCache = default(Ray);
			}
		}
	}

	// Token: 0x0600091A RID: 2330 RVA: 0x000B9F20 File Offset: 0x000B8120
	private void UseSkill(int tag)
	{
		if ((this.bNpcBossMod || this.bArenaMod) && (tag == 6 || tag == 8 || tag == 9))
		{
			return;
		}
		switch (tag)
		{
		case 6:
			this.NextTransitions();
			break;
		case 7:
			if (!this.bc.IsBattleEnd)
			{
				this.OnBackButtonClick();
			}
			break;
		case 8:
		case 9:
			if (this.bc != null)
			{
				this.bc.StartAutoBattle = !this.bc.StartAutoBattle;
				if (this.bc.StartAutoBattle)
				{
					this.autoButtonUp.image.sprite = this.spriteArray.GetSprite(1);
					if (BattleController.CameraModel == 0)
					{
						this.nextButton1.gameObject.SetActive(false);
					}
					else
					{
						this.nextButton2.gameObject.SetActive(false);
					}
				}
				else
				{
					this.autoButtonUp.image.sprite = this.spriteArray.GetSprite(0);
				}
			}
			break;
		case 10:
			if (this.bc != null)
			{
				this.bc.ReturnFirstStage();
			}
			break;
		case 11:
			if (this.bc != null)
			{
				this.bc.SetBattleCameraModel();
			}
			if (this.nextButton1.gameObject.activeSelf || this.nextButton2.gameObject.activeSelf)
			{
				if (BattleController.CameraModel == 0)
				{
					this.nextButton1.gameObject.SetActive(true);
					this.nextButton2.gameObject.SetActive(false);
				}
				else
				{
					this.nextButton2.gameObject.SetActive(true);
					this.nextButton1.gameObject.SetActive(false);
				}
			}
			break;
		case 12:
			if (this.bNpcBossMod)
			{
				GUIManager.Instance.CheckSynIsOpned();
				DataManager.Instance.SendExitBattle();
			}
			else if (this.bArenaMod)
			{
				if (this.bc.IsReplay_PVP)
				{
					GUIManager.Instance.CheckSynIsOpned();
					DataManager.Instance.SendExitBattle();
				}
				else
				{
					this.bc.m_BattleState = BattleController.BattleState.BATTLE_STOP;
					GUIManager.Instance.OpenMenu(EGUIWindow.UI_Settlement, 1, 0, true, false, false);
				}
				GUIManager.Instance.ClosePvPUI();
			}
			else
			{
				Time.timeScale = 0f;
				GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(685u), DataManager.Instance.mStringTable.GetStringByID(596u), 1, 0, null, null);
			}
			break;
		case 13:
			this.OnBackButtonClick();
			break;
		case 14:
			this.OnBackButtonClick();
			this.bc.m_BattleState = BattleController.BattleState.BATTLE_STOP;
			GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleReplay_Force);
			break;
		}
	}

	// Token: 0x0600091B RID: 2331 RVA: 0x000BA210 File Offset: 0x000B8410
	private void NextTransitions()
	{
		if (this.bc != null && this.bc.CheckNextLevel() && this.bc.movePlayerOutside(EMovePlayerOutside.Default))
		{
			GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.Battle);
		}
		this.deltaTime = 90f;
		this.nextButton1.gameObject.SetActive(false);
		this.nextButton2.gameObject.SetActive(false);
	}

	// Token: 0x0600091C RID: 2332 RVA: 0x000BA288 File Offset: 0x000B8488
	private void OverGame()
	{
		if (this.bc != null && this.bc.CheckNextLevel() && this.bc.movePlayerOutside(EMovePlayerOutside.Default))
		{
			GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
		}
	}

	// Token: 0x0600091D RID: 2333 RVA: 0x000BA2D4 File Offset: 0x000B84D4
	private void Pause()
	{
		this.isPause = !this.isPause;
		if (this.isPause)
		{
			Time.timeScale = 0f;
		}
		else
		{
			Time.timeScale = 1f;
		}
	}

	// Token: 0x0600091E RID: 2334 RVA: 0x000BA30C File Offset: 0x000B850C
	private int GetBattlePosID(int i)
	{
		int result = 0;
		switch (i)
		{
		case 0:
			result = 3;
			break;
		case 1:
			result = 1;
			break;
		case 2:
			result = 0;
			break;
		case 3:
			result = 2;
			break;
		case 4:
			result = 4;
			break;
		}
		return result;
	}

	// Token: 0x0600091F RID: 2335 RVA: 0x000BA360 File Offset: 0x000B8560
	private void SetSliderHP(int Index, float val)
	{
		if (Index < 5 && Index >= 0)
		{
			this.hpSliders[Index].value = val;
			if (val == 0f)
			{
				this.selectImage[Index].gameObject.SetActive(false);
				this.buttons[Index].interactable = false;
				this.buttons[Index].HIImage.color = new Color(0.168f, 0.168f, 0.168f, 1f);
				if (this.weekHpSlider[Index].gameObject.activeSelf)
				{
					this.weekHpSlider[Index].gameObject.SetActive(false);
					this.deadImages[Index].gameObject.SetActive(false);
				}
			}
			else if (this.hpSliders[Index].value / this.hpSliders[Index].maxValue <= 0.35f)
			{
				if (!this.weekHpSlider[Index].gameObject.activeSelf)
				{
					this.weekHpSlider[Index].gameObject.SetActive(true);
					this.deadImages[Index].gameObject.SetActive(true);
					this.hpImage[Index].enabled = false;
				}
			}
			else
			{
				if (!this.hpImage[Index].enabled)
				{
					this.hpImage[Index].enabled = true;
				}
				if (this.weekHpSlider[Index].gameObject.activeSelf)
				{
					this.weekHpSlider[Index].gameObject.SetActive(false);
					this.deadImages[Index].gameObject.SetActive(false);
				}
				if (this.buttons[Index].HIImage.color != Color.white)
				{
					this.buttons[Index].HIImage.color = Color.white;
				}
			}
		}
	}

	// Token: 0x06000920 RID: 2336 RVA: 0x000BA52C File Offset: 0x000B872C
	private void SetSliderMP(int Index, float val)
	{
		if (Index < 5 && Index >= 0)
		{
			if (val > 0f)
			{
				if (val >= this.mpSliders[Index].maxValue && this.mpSliders[Index].value != this.mpSliders[Index].maxValue)
				{
					this.buttons[Index].interactable = true;
					if (!this.maxMpSlider[Index].gameObject.activeSelf)
					{
						this.maxMpSlider[Index].gameObject.SetActive(true);
					}
					NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, this, false);
				}
				this.mpSliders[Index].value = val;
			}
			else if (val == this.mpSliders[Index].minValue || val == 0f)
			{
				if (this.mpSliders[Index].value == this.mpSliders[Index].maxValue && val == 0f)
				{
					this.mpSliders[Index].value = val;
				}
				else
				{
					this.mpSliders[Index].value = val;
				}
				this.buttons[Index].interactable = false;
				if (this.iconScaleValue[Index].NowType == 2)
				{
					this.SetBtnTween(Index, 2);
				}
				if (this.maxMpSlider[Index].gameObject.activeSelf)
				{
					this.maxMpSlider[Index].gameObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x06000921 RID: 2337 RVA: 0x000BA698 File Offset: 0x000B8898
	private void SetSliderMPMax(int Index, float val)
	{
		if (Index < 5 && Index >= 0)
		{
			this.mpSliders[Index].maxValue = val;
			this.mpSliders[Index].minValue = 0f;
		}
	}

	// Token: 0x06000922 RID: 2338 RVA: 0x000BA6D4 File Offset: 0x000B88D4
	private void SetSliderHPMax(int Index, float val)
	{
		if (Index < 5 && Index >= 0)
		{
			this.hpSliders[Index].maxValue = val;
			this.mpSliders[Index].minValue = 0f;
		}
	}

	// Token: 0x06000923 RID: 2339 RVA: 0x000BA710 File Offset: 0x000B8910
	private void SetKingBar(float val)
	{
		this.kingBar.fillAmount = val;
	}

	// Token: 0x06000924 RID: 2340 RVA: 0x000BA720 File Offset: 0x000B8920
	public void SetTeachProjector(bool bShow)
	{
		if (bShow)
		{
			Transform transform = this.bc.setupTeachProjector(true, this.projectorType);
			Vector2 vector = Camera.main.WorldToScreenPoint(this.bc.enemyUnit[0].Position);
			float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
			vector /= scaleFactor;
			Ray ray = Camera.main.ScreenPointToRay(vector);
			if (BattleController.Tracing(ray.direction, ray.origin) != null)
			{
				Vector3 position = this.bc.enemyUnit[0].Position;
				position.x = Mathf.Clamp(position.x, 0f, 23.8f);
				position.z = Mathf.Clamp(position.z, 0f, 11f);
				if (this.projectorType == 3)
				{
					Transform newbie_projector_parent = this.bc.newbie_projector_parent;
					newbie_projector_parent.rotation = Quaternion.LookRotation(position - this.curUltraSkillerPos);
					transform.localPosition = Vector3.forward * this.bc.PJ_FireRadius * 0.5f;
				}
				else if (this.projectorType == 5)
				{
					Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.bc.enemyUnit[0].NpcID);
					this.bc.newbie_projector.ShadowSize = (float)recordByKey.Radius * 0.002f;
					this.bc.newbie_projector.transform.position = this.bc.enemyUnit[0].Position;
					float num = Vector3.Distance(this.bc.enemyUnit[0].Position, this.curUltraSkillerPos);
					float num2 = num - (float)recordByKey.Radius * 0.02f;
					num2 = ((num2 <= 1f) ? num2 : (num2 - 0.5f));
					this.bc.newbie_projector_line_transform.localScale = new Vector3(0.006f, num2 * 0.05f, 0.006f);
					Vector3 vector2 = this.bc.enemyUnit[0].Position - this.curUltraSkillerPos;
					vector2.Normalize();
					this.bc.newbie_projector_line.transform.rotation = Quaternion.LookRotation(vector2);
					this.bc.newbie_projector_line.transform.Rotate(270f, 0f, 0f);
					this.bc.newbie_projector_line.transform.position = this.curUltraSkillerPos + vector2 * num2 * 0.5f;
				}
			}
		}
		else
		{
			this.bc.setupTeachProjector(false, 0);
		}
	}

	// Token: 0x06000925 RID: 2341 RVA: 0x000BA9F4 File Offset: 0x000B8BF4
	public void UpdateProjector(bool useRayCache = false, bool bNewbieSpecial = false)
	{
		if (this.bProjectorMode)
		{
			if (this.projectorTrans != null)
			{
				bool flag = true;
				if (!useRayCache)
				{
					if (Input.touchCount > 0)
					{
						this.rayCache = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
					}
					else
					{
						this.OnHIButtonUp(this.buttons[0]);
						flag = false;
					}
				}
				if (flag)
				{
					Vector3? vector = BattleController.Tracing(this.rayCache.direction, this.rayCache.origin);
					if (vector != null)
					{
						Vector3 vector2 = vector.Value;
						if (bNewbieSpecial)
						{
							vector2 = this.bc.enemyUnit[0].Position;
						}
						vector2.x = Mathf.Clamp(vector2.x, 0f, 23.8f);
						vector2.z = Mathf.Clamp(vector2.z, 0f, 11f);
						if (this.projectorType == 1)
						{
							if (GameConstants.DistanceSquare(vector2, this.curUltraSkillerPos) > this.bc.PJ_FireRange * this.bc.PJ_FireRange)
							{
								Vector3 a = vector2 - this.curUltraSkillerPos;
								a.Normalize();
								vector2 = this.curUltraSkillerPos + a * this.bc.PJ_FireRange;
								vector2.y = 0f;
							}
							this.projectorTrans.transform.localPosition = vector2;
							this.bc.getUltraTargets((byte)(vector2.x * 10f), (byte)(vector2.z * 10f));
						}
						else if (this.projectorType == 3 || this.projectorType == 4)
						{
							Transform projectorParent = this.bc.getProjectorParent();
							projectorParent.rotation = Quaternion.LookRotation(vector2 - this.curUltraSkillerPos);
							this.bc.getUltraTargets((byte)(vector2.x * 10f), (byte)(vector2.z * 10f));
						}
						else if (this.projectorType == 5)
						{
							this.bc.updateNearestTargetHightlight(vector.Value);
						}
						if (this.projectorType != 6 && this.projectorType != 5 && this.projectorType != 2)
						{
							this.bc.getUltraSkiller().updateDirection(vector2);
						}
					}
				}
			}
			else
			{
				this.bProjectorMode = false;
			}
		}
		else if (this.ultraSkillWorking && !NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE) && !NewbieManager.IsTeachWorking(ETeachKind.AUTO_BATTLE) && Input.touchCount <= 0)
		{
			this.OnHIButtonUp(this.buttons[0]);
		}
	}

	// Token: 0x06000926 RID: 2342 RVA: 0x000BACA8 File Offset: 0x000B8EA8
	private void Update()
	{
		this.UpdateProjector(false, false);
		if (this.deltaTime != 0f)
		{
			this.tempDeltaTime += Time.deltaTime;
		}
		this.tempDeltaTime = 0f;
		if (this.bc != null)
		{
			if (this.bNpcBossMod)
			{
				this.MaxTime = 40;
			}
			else if (this.bChallegeMode && this.ChallegeCheckPointTimeRule[this.CheckPoint - 1] > 0)
			{
				this.MaxTime = this.ChallegeCheckPointTimeRule[this.CheckPoint - 1];
			}
			else
			{
				this.MaxTime = 90;
			}
			this.deltaTime = (uint)this.MaxTime - this.bc.m_ui32Tcik / 10u;
		}
		this.m_Str[0].ClearString();
		this.m_Str[0].IntToFormat((long)((int)this.deltaTime / 60), 1, false);
		this.m_Str[0].IntToFormat((long)((int)this.deltaTime % 60), 2, false);
		this.m_Str[0].AppendFormat("{0} : {1}");
		this.timeText.text = this.m_Str[0].ToString();
		this.timeText.SetAllDirty();
		this.timeText.cachedTextGenerator.Invalidate();
		if (this.deltaTime < 11f)
		{
			this.bShowCountDownText = true;
			if (this.deltaTime != this.m_PreCountDownNum)
			{
				this.bShowCountDownText = true;
				this.m_PreCountDownNum = this.deltaTime;
				this.m_Str[1].ClearString();
				this.m_Str[1].IntToFormat((long)((int)this.deltaTime), 1, false);
				this.m_Str[1].AppendFormat("{0}");
				this.m_CountDownText.text = this.m_Str[1].ToString();
				this.m_CountDownText.SetAllDirty();
				this.m_CountDownText.cachedTextGenerator.Invalidate();
				this.m_CounDownTick = 0f;
			}
		}
		else
		{
			this.bShowCountDownText = false;
		}
		for (int i = 0; i < 5; i++)
		{
			if (this.iconScaleValue[i].bShowIconEffect == 2)
			{
				if (this.iconScaleValue[i].time <= this.effectTime)
				{
					this.iconScaleValue[i].iconSize = this.IconTween(this.iconScaleValue[i].time, 68f, 30f, this.effectTime);
					this.iconScaleValue[i].sliderSize = this.IconTween(this.iconScaleValue[i].time, 82f, 30f, this.effectTime);
					this.btnRt[i].sizeDelta = new Vector2(this.iconScaleValue[i].iconSize, this.iconScaleValue[i].iconSize);
					this.hpSlidersRt[i].sizeDelta = new Vector2(this.iconScaleValue[i].sliderSize, 22f);
					this.mpSlidersRt[i].sizeDelta = new Vector2(this.iconScaleValue[i].sliderSize, 22f);
				}
				if (this.iconScaleValue[i].time > this.effectTime - this.delay)
				{
					if (!this.selectImage[i].gameObject.activeSelf)
					{
						this.selectTween[i].enabled = false;
						this.selectImage[i].gameObject.SetActive(true);
					}
					this.iconScaleValue[i].selectSize = this.SelectTween(this.iconScaleValue[i].time, 400f, -250f, this.effectTime + this.effectTime2);
					this.selectImageRt[i].sizeDelta = new Vector2(this.iconScaleValue[i].selectSize, this.iconScaleValue[i].selectSize);
					this.iconScaleValue[i].colorA = this.ATween(this.iconScaleValue[i].time, 1f, -0.8f, this.effectTime + this.effectTime2);
					this.selectImage[i].color = new Color(1f, 1f, 1f, this.iconScaleValue[i].colorA);
				}
				if (this.iconScaleValue[i].time >= this.effectTime + this.effectTime2)
				{
					this.selectTween[i].enabled = true;
					this.iconScaleValue[i].bShowIconEffect = 0;
				}
				IconScaleValue[] array = this.iconScaleValue;
				int num = i;
				array[num].time = array[num].time + Time.deltaTime;
			}
			else if (this.iconScaleValue[i].bShowIconEffect == 1)
			{
				if (this.iconScaleValue[i].time <= 0.2f)
				{
					if (this.selectTween[i].enabled)
					{
						this.selectTween[i].enabled = false;
					}
					if (!this.selectImage[i].gameObject.activeSelf)
					{
						this.selectImage[i].gameObject.SetActive(true);
					}
					this.iconScaleValue[i].selectSize = this.SelectTween(this.iconScaleValue[i].time, 110f, 100f, 0.2f);
					this.selectImageRt[i].sizeDelta = new Vector2(this.iconScaleValue[i].selectSize, this.iconScaleValue[i].selectSize);
					this.iconScaleValue[i].colorA = this.ATween(this.iconScaleValue[i].time, 1f, -1f, 0.2f);
					this.selectImage[i].color = new Color(1f, 1f, 1f, this.iconScaleValue[i].colorA);
				}
				if (this.iconScaleValue[i].time >= 0.2f)
				{
					this.selectTween[i].enabled = false;
					this.selectImage[i].gameObject.SetActive(false);
					this.iconScaleValue[i].bShowIconEffect = 0;
				}
				IconScaleValue[] array2 = this.iconScaleValue;
				int num2 = i;
				array2[num2].time = array2[num2].time + Time.deltaTime;
			}
		}
		for (int j = 0; j < 5; j++)
		{
			if (this.IconSliserTime[j].bShowIconEffect == 1)
			{
				if (this.IconSliserTime[j].time <= this.mpValueTime)
				{
					this.IconSliserTime[j].mpSliderValue = this.ATween(this.IconSliserTime[j].time, this.mpSliders[j].maxValue, -this.mpSliders[j].maxValue, this.mpValueTime);
					this.mpSliders[j].value = this.IconSliserTime[j].mpSliderValue;
				}
				if (this.IconSliserTime[j].time >= this.mpValueTime)
				{
					this.IconSliserTime[j].bShowIconEffect = 0;
					this.mpSliders[j].value = this.bc.playerAttr[this.GetBattlePosID(j)].CUR_MP;
				}
				SliserTime[] iconSliserTime = this.IconSliserTime;
				int num3 = j;
				iconSliserTime[num3].time = iconSliserTime[num3].time + Time.deltaTime;
			}
		}
		if (this.bShowCenterMsg)
		{
			Color color = this.m_CenterMsgText.color;
			this.m_CenterMsgTime += Time.deltaTime;
			if (this.m_CenterMsgTime > this.m_CenterCountDownTime)
			{
				this.m_CenterMsgColorA = this.ATween(this.m_CenterMsgTime - this.m_CenterCountDownTime, 1f, -1f, 0.5f);
			}
			this.m_CenterMsgBg.color = new Color(1f, 1f, 1f, this.m_CenterMsgColorA);
			this.m_CenterMsgText.color = new Color(color.r, color.g, color.b, this.m_CenterMsgColorA);
			if (this.m_CenterMsgTime >= this.m_CenterCountDownTime + 0.5f)
			{
				this.m_CenterMsgTf.gameObject.SetActive(false);
				this.bShowCenterMsg = false;
			}
		}
		if (this.bShowCountDownText)
		{
			this.m_CounDownTick += Time.deltaTime;
			if (this.m_CounDownTick <= 1f)
			{
				this.m_CountDownScale = this.ATween(this.m_CounDownTick, 0f, 1f, 1f);
				this.m_CountDownAColor = this.ATween(this.m_CounDownTick, 1f, -1f, 1f);
				if (GUIManager.Instance.IsArabic)
				{
					this.m_CountDownRect.localScale = new Vector3(-1f - this.m_CountDownScale * 1.3f, 1f + this.m_CountDownScale, 1f + this.m_CountDownScale);
				}
				else
				{
					this.m_CountDownRect.localScale = new Vector3(1f + this.m_CountDownScale * 1.3f, 1f + this.m_CountDownScale, 1f + this.m_CountDownScale);
				}
				this.m_CountDownText.color = new Color(this.m_CountDownText.color.r, this.m_CountDownText.color.g, this.m_CountDownText.color.b, this.m_CountDownAColor);
				this.m_CountDownText.enabled = true;
			}
			else
			{
				this.m_CountDownText.enabled = false;
			}
		}
		if (this.bNpcBossMod && this.bc != null && this.bossDataIdx < 20)
		{
			this.bossCurHp = this.bc.enemyAttr[this.bossDataIdx].CUR_HP;
			this.bossMaxHp = this.bc.enemyAttr[this.bossDataIdx].MAX_HP;
			this.SetNpcBossHP(this.bossCurHp, this.bossMaxHp);
		}
	}

	// Token: 0x06000927 RID: 2343 RVA: 0x000BB72C File Offset: 0x000B992C
	public float IconTween(float t, float b, float c, float d)
	{
		float num = (t /= d) * t;
		float num2 = num * t;
		return (float)((double)b + (double)c * (-13.4 * (double)num2 * (double)num + 48.895 * (double)num * (double)num + -56.39 * (double)num2 + 20.895 * (double)num + (double)t));
	}

	// Token: 0x06000928 RID: 2344 RVA: 0x000BB78C File Offset: 0x000B998C
	public float SelectTween(float t, float b, float c, float d)
	{
		t /= d;
		return b + c * t;
	}

	// Token: 0x06000929 RID: 2345 RVA: 0x000BB79C File Offset: 0x000B999C
	public float ATween(float t, float b, float c, float d)
	{
		float num = (t /= d) * t;
		float num2 = num * t;
		return b + c * (num2 * num);
	}

	// Token: 0x0600092A RID: 2346 RVA: 0x000BB7C0 File Offset: 0x000B99C0
	public override void UpdateUI(int arg1, int arg2)
	{
		int num = this.bc.playerAttr.Length;
		switch (arg1)
		{
		case 0:
			for (int i = 0; i < num; i++)
			{
				int battlePosID = this.GetBattlePosID(i);
				uint num2 = this.bc.playerAttr[battlePosID].MAX_MP;
				this.SetSliderMPMax(i, num2);
				num2 = this.bc.playerAttr[battlePosID].MAX_HP;
				this.SetSliderHPMax(i, num2);
			}
			break;
		case 1:
			for (int j = 0; j < num; j++)
			{
				int battlePosID = this.GetBattlePosID(j);
				uint num2 = this.bc.playerAttr[battlePosID].CUR_MP;
				this.SetSliderMP(j, num2);
				num2 = this.bc.playerAttr[battlePosID].CUR_HP;
				this.SetSliderHP(j, num2);
			}
			break;
		case 2:
			this.SetKingBar((float)arg2);
			break;
		case 6:
			if (arg2 == 1)
			{
				if (BattleController.CameraModel == 0)
				{
					this.nextButton1.gameObject.SetActive(true);
				}
				else
				{
					this.nextButton2.gameObject.SetActive(true);
				}
				this.bCountDown = false;
			}
			break;
		case 7:
			this.AddItemCount();
			break;
		case 8:
			this.ClearItemCount();
			break;
		case 9:
		{
			Time.timeScale = 1f;
			DataManager instance = DataManager.Instance;
			instance.lastBattleResult = 0;
			instance.BattleSeqID = 0UL;
			this.bc.m_BattleState = BattleController.BattleState.BATTLE_STOP;
			GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
			break;
		}
		case 10:
			this.CheckPoint = Mathf.Clamp(arg2, 1, 3);
			this.m_Str[2].ClearString();
			this.m_Str[2].IntToFormat((long)arg2, 1, false);
			if (GUIManager.Instance.IsArabic)
			{
				this.m_Str[2].AppendFormat("3/{0}");
			}
			else
			{
				this.m_Str[2].AppendFormat("{0}/3");
			}
			this.checkpointText.text = this.m_Str[2].ToString();
			this.checkpointText.SetAllDirty();
			this.checkpointText.cachedTextGenerator.Invalidate();
			this.deltaTime = 90f;
			this.bShowCountDownText = false;
			this.m_CountDownText.text = string.Empty;
			if (BattleController.CameraModel == 0)
			{
				this.nextButton1.gameObject.SetActive(false);
			}
			else
			{
				this.nextButton2.gameObject.SetActive(false);
			}
			this.bCountDown = true;
			break;
		case 11:
			this.RefreshData();
			break;
		case 12:
			this.nextButton1.gameObject.SetActive(false);
			this.nextButton2.gameObject.SetActive(false);
			break;
		case 13:
		{
			int num3 = (int)this.indexPosMap[arg2 >> 8];
			bool flag = (arg2 & 255) != 0;
			this.selectImage[num3].gameObject.SetActive(flag);
			this.buttons[num3].interactable = flag;
			break;
		}
		case 14:
			for (int k = 0; k < 5; k++)
			{
				if (this.buttons[k].gameObject.activeSelf)
				{
					this.selectImage[k].gameObject.SetActive(false);
					this.buttons[k].interactable = false;
				}
			}
			break;
		}
	}

	// Token: 0x0600092B RID: 2347 RVA: 0x000BBB68 File Offset: 0x000B9D68
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			GUIManager.Instance.CheckSynIsOpned();
			DataManager.Instance.SendExitBattle();
		}
	}

	// Token: 0x0600092C RID: 2348 RVA: 0x000BBB84 File Offset: 0x000B9D84
	public override bool OnBackButtonClick()
	{
		if (this.bc != null && !BattleController.IsGambleMode)
		{
			if (DataManager.StageDataController._stageMode == StageMode.Dare && this.bc.IsType(EBattleType.NORMAL))
			{
				this.challengePausePanel.gameObject.SetActive(!this.challengePausePanel.gameObject.activeSelf);
				Time.timeScale = (float)((!this.challengePausePanel.gameObject.activeSelf) ? 1 : 0);
			}
			else
			{
				this.PausePanel.gameObject.SetActive(!this.PausePanel.gameObject.activeSelf);
				Time.timeScale = (float)((!this.PausePanel.gameObject.activeSelf) ? 1 : 0);
			}
		}
		return true;
	}

	// Token: 0x0600092D RID: 2349 RVA: 0x000BBC58 File Offset: 0x000B9E58
	public void OnBattlePause()
	{
		if (!NewbieManager.IsWorking() && !GUIManager.Instance.FindMenu(EGUIWindow.UI_Settlement))
		{
			this.OnBackButtonClick();
		}
	}

	// Token: 0x0600092E RID: 2350 RVA: 0x000BBC8C File Offset: 0x000B9E8C
	public void AddItemCount()
	{
		this.itemCount++;
		this.itemText.text = this.itemCount.ToString();
	}

	// Token: 0x0600092F RID: 2351 RVA: 0x000BBCC0 File Offset: 0x000B9EC0
	public void ClearItemCount()
	{
		this.itemCount = 0;
		this.itemText.text = this.itemCount.ToString();
	}

	// Token: 0x06000930 RID: 2352 RVA: 0x000BBCE0 File Offset: 0x000B9EE0
	public bool CheckShowAutoBtn()
	{
		if (this.bNpcBossMod || this.bArenaMod)
		{
			return true;
		}
		StageManager stageDataController = DataManager.StageDataController;
		int num = 0;
		if (stageDataController._stageMode != StageMode.Full || BattleNetwork.battlePointID % 3 == 0)
		{
			num = (int)((byte)DataManager.StageDataController.GetStagePoint(BattleNetwork.battlePointID, 0));
		}
		DataManager instance = DataManager.Instance;
		VIP_DataTbl recordByKey = instance.VIPLevelTable.GetRecordByKey((ushort)instance.GetVIPLevel(instance.RoleAttr.VipPoint));
		return num > 0 || recordByKey.AutoFightMission != 0;
	}

	// Token: 0x06000931 RID: 2353 RVA: 0x000BBD70 File Offset: 0x000B9F70
	public void CheckAutoBattleStatus()
	{
		if (!this.autoButtonUp.gameObject.activeSelf)
		{
			return;
		}
		if (this.bc != null && this.bc.IsType(EBattleType.NORMAL) && BattleController.AutoBattleFlag && !this.bc.StartAutoBattle)
		{
			this.UseSkill(9);
		}
	}

	// Token: 0x06000932 RID: 2354 RVA: 0x000BBDD4 File Offset: 0x000B9FD4
	public void RefreshData()
	{
		DataManager instance = DataManager.Instance;
		Transform child = this.m_transform.transform.GetChild(32);
		if (this.CheckShowAutoBtn())
		{
			this.autoButtonUp.gameObject.SetActive(true);
			child.gameObject.SetActive(true);
		}
		else
		{
			this.autoButtonUp.gameObject.SetActive(false);
			child.gameObject.SetActive(false);
		}
		this.CheckAutoBattleStatus();
		for (int i = 0; i < (int)instance.heroCount; i++)
		{
			ushort heroID = instance.heroBattleData[this.GetBattlePosID(i)].HeroID;
			if (instance.curHeroData.ContainsKey((uint)heroID))
			{
				CurHeroData curHeroData = instance.curHeroData[(uint)heroID];
				this.CheckChalleneHeroRule(ref curHeroData);
				GUIManager.Instance.ChangeHeroItemImg(this.buttons[i].transform, eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
			}
		}
		for (int j = 0; j < 5; j++)
		{
			this.SetBtnTween(j, 0);
			this.buttons[j].HIImage.color = new Color(1f, 1f, 1f, 1f);
			this.weekHpSlider[j].gameObject.SetActive(false);
			this.deadImages[j].gameObject.SetActive(false);
			this.hpImage[j].enabled = true;
		}
	}

	// Token: 0x06000933 RID: 2355 RVA: 0x000BBF58 File Offset: 0x000BA158
	public void SetBtnTween(int btnIdx, int setType)
	{
		if (setType == 0)
		{
			btnIdx = (int)this.indexPosMap[btnIdx];
			this.selectImage[btnIdx].gameObject.SetActive(false);
			this.SetBtnTween(btnIdx, 2);
		}
		else if (setType == 1)
		{
			btnIdx = (int)this.indexPosMap[btnIdx];
			this.selectImage[btnIdx].gameObject.SetActive(true);
			if (base.gameObject.activeSelf)
			{
				AudioManager.Instance.PlayUISFX(UIKind.HeroSkill);
			}
			this.SetBtnTween(btnIdx, 3);
		}
		if (setType == 2)
		{
			this.iconScaleValue[btnIdx].NowType = 1;
			this.iconScaleValue[btnIdx].bShowIconEffect = 1;
			this.iconScaleValue[btnIdx].iconSize = 68f;
			this.iconScaleValue[btnIdx].selectSize = 400f;
			this.iconScaleValue[btnIdx].time = 0f;
			this.iconScaleValue[btnIdx].sliderSize = 82f;
			this.selectTween[btnIdx].enabled = false;
			this.btnRt[btnIdx].sizeDelta = new Vector2(this.iconScaleValue[btnIdx].iconSize, this.iconScaleValue[btnIdx].iconSize);
			this.hpSlidersRt[btnIdx].sizeDelta = new Vector2(this.iconScaleValue[btnIdx].sliderSize, 22f);
			this.mpSlidersRt[btnIdx].sizeDelta = new Vector2(this.iconScaleValue[btnIdx].sliderSize, 22f);
			this.selectImageRt[btnIdx].sizeDelta = new Vector2(this.iconScaleValue[btnIdx].selectSize, this.iconScaleValue[btnIdx].selectSize);
			this.selectImage[btnIdx].color = new Color(1f, 1f, 1f, this.iconScaleValue[btnIdx].colorA);
			this.selectImage[btnIdx].gameObject.SetActive(false);
			this.buttons[btnIdx].interactable = false;
		}
		else if (setType == 3)
		{
			this.iconScaleValue[btnIdx].NowType = 2;
			this.iconScaleValue[btnIdx].bShowIconEffect = 2;
			this.iconScaleValue[btnIdx].iconSize = 68f;
			this.iconScaleValue[btnIdx].selectSize = 150f;
			this.iconScaleValue[btnIdx].time = 0f;
			this.btnRt[btnIdx].localScale = new Vector2(1f, 1f);
			this.hpSlidersRt[btnIdx].sizeDelta = new Vector2(this.iconScaleValue[btnIdx].sliderSize, 22f);
			this.mpSlidersRt[btnIdx].sizeDelta = new Vector2(this.iconScaleValue[btnIdx].sliderSize, 22f);
			this.selectImageRt[btnIdx].sizeDelta = new Vector2(this.iconScaleValue[btnIdx].selectSize, this.iconScaleValue[btnIdx].selectSize);
			this.selectImage[btnIdx].color = new Color(1f, 1f, 1f, this.iconScaleValue[btnIdx].colorA);
			this.buttons[btnIdx].interactable = true;
		}
		else if (setType == 4)
		{
			this.IconSliserTime[btnIdx].bShowIconEffect = 1;
			this.IconSliserTime[btnIdx].time = 0f;
		}
	}

	// Token: 0x06000934 RID: 2356 RVA: 0x000BC308 File Offset: 0x000BA508
	public void UpdateSetSliderHP(int idx)
	{
		float val = this.bc.playerAttr[idx].CUR_MP;
		this.SetSliderMP((int)this.indexPosMap[idx], val);
		val = this.bc.playerAttr[idx].CUR_HP;
		this.SetSliderHP((int)this.indexPosMap[idx], val);
	}

	// Token: 0x06000935 RID: 2357 RVA: 0x000BC368 File Offset: 0x000BA568
	public void AddCenterMsg()
	{
		this.bShowCenterMsg = true;
		this.m_CenterMsgTf.gameObject.SetActive(true);
		this.m_CenterMsgColorA = 1f;
		this.m_CenterMsgTime = 0f;
		this.m_CenterMsgText.text = DataManager.Instance.mStringTable.GetStringByID(743u);
		this.m_CenterMsgText.SetAllDirty();
		this.m_CenterMsgText.cachedTextGenerator.Invalidate();
		this.m_CenterMsgText.cachedTextGeneratorForLayout.Invalidate();
		this.m_CenterMsgTf.GetComponent<RectTransform>().sizeDelta = new Vector2(this.m_CenterMsgText.preferredWidth + 89f, 47f);
		this.m_CenterMsgText.rectTransform.anchoredPosition = new Vector2(69f, this.m_CenterMsgText.rectTransform.anchoredPosition.y);
		this.m_CenterMsgText.UpdateArabicPos();
	}

	// Token: 0x06000936 RID: 2358 RVA: 0x000BC458 File Offset: 0x000BA658
	public void SetNpcBossHP(uint curHp, uint maxHp)
	{
		if (maxHp != 0u)
		{
			this.m_Str[4].ClearString();
			float num = curHp / maxHp;
			if (num >= 0.0001f)
			{
				this.m_Str[4].FloatToFormat(num * 100f, 2, true);
			}
			else if (num <= 0f)
			{
				this.m_Str[4].FloatToFormat(0f, -1, true);
			}
			else
			{
				this.m_Str[4].FloatToFormat(0.01f, -1, true);
			}
			this.m_Str[4].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(884u));
			this.npcHpImg.rectTransform.sizeDelta = new Vector2(338f * num, 16f);
			this.npcBossHpValue.text = this.m_Str[4].ToString();
			this.npcBossHpValue.SetAllDirty();
			this.npcBossHpValue.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06000937 RID: 2359 RVA: 0x000BC55C File Offset: 0x000BA75C
	private void SetBattleChallengeIcons()
	{
		StageManager stageDataController = DataManager.StageDataController;
		byte currentNodus = stageDataController.currentNodus;
		bool flag = stageDataController.StageDareMode(stageDataController.currentPointID) == StageMode.Lean;
		LevelEX levelEXBycurrentPointID = stageDataController.GetLevelEXBycurrentPointID(0);
		if (flag)
		{
			if (currentNodus == 1)
			{
				this.ConditionKey = levelEXBycurrentPointID.NodusOneID;
			}
			else if (currentNodus == 2)
			{
				this.ConditionKey = levelEXBycurrentPointID.NodusTwoID;
			}
			else if (currentNodus == 3)
			{
				this.ConditionKey = levelEXBycurrentPointID.NodusThrID;
			}
		}
		else
		{
			this.ConditionKey = levelEXBycurrentPointID.NodusTwoID;
		}
		StageConditionData recordByKey = stageDataController.StageConditionDataTable.GetRecordByKey(this.ConditionKey);
		int num = 0;
		for (int i = 0; i < 8; i++)
		{
			StageConditionInfo recordByKey2 = stageDataController.StageConditionInfoTable.GetRecordByKey((ushort)recordByKey.ConditionArray[i].ConditionID);
			if (recordByKey.ConditionArray[i].ConditionID > 0)
			{
				this.battleChallengeIcons[i].Btn.m_BtnID2 = (int)recordByKey.ConditionArray[i].ConditionID;
				this.battleChallengeIcons[i].Btn.m_BtnID3 = (int)recordByKey.ConditionArray[i].FactorA;
				this.battleChallengeIcons[i].Btn.m_BtnID4 = (int)recordByKey.ConditionArray[i].FactorB;
				if (recordByKey2.Type != 1)
				{
					this.battleChallengeIcons[i].gameObj.SetActive(true);
				}
				else
				{
					this.battleChallengeIcons[i].gameObj.SetActive(false);
				}
				num++;
			}
		}
		if (num < this.battleChallengeIcons.Length)
		{
			this.battleChallengeIcons[num].Btn.m_BtnID2 = 255;
			this.battleChallengeIcons[num].Btn.m_BtnID3 = 255;
			this.battleChallengeIcons[num].Btn.m_BtnID4 = 255;
			this.battleChallengeIcons[num].gameObj.SetActive(true);
		}
		for (int j = 0; j < 8; j++)
		{
			if (this.battleChallengeIcons[j].Btn.m_BtnID2 > 0)
			{
				byte conditionID = (byte)this.battleChallengeIcons[j].Btn.m_BtnID2;
				ushort factorA = (ushort)this.battleChallengeIcons[j].Btn.m_BtnID3;
				ushort factorB = (ushort)this.battleChallengeIcons[j].Btn.m_BtnID4;
				this.battleChallengeIcons[j].Item.material = stageDataController.GetStageConditionMaterial((byte)this.battleChallengeIcons[j].Btn.m_BtnID2);
				this.battleChallengeIcons[j].Item.sprite = stageDataController.GetStageConditionSprite(conditionID, factorA, factorB);
			}
		}
	}

	// Token: 0x06000938 RID: 2360 RVA: 0x000BC878 File Offset: 0x000BAA78
	public void OnButtonDown(UIButtonHint sender)
	{
		StageManager stageDataController = DataManager.StageDataController;
		byte conditionID = 0;
		ushort factorA = 0;
		ushort factorB = 0;
		this.m_Str[5].ClearString();
		if (sender.Parm1 >= 0 && (int)sender.Parm1 < this.battleChallengeIcons.Length)
		{
			conditionID = (byte)this.battleChallengeIcons[(int)sender.Parm1].Btn.m_BtnID2;
			factorA = (ushort)this.battleChallengeIcons[(int)sender.Parm1].Btn.m_BtnID3;
			factorB = (ushort)this.battleChallengeIcons[(int)sender.Parm1].Btn.m_BtnID4;
		}
		stageDataController.GetStageConditionString(this.m_Str[5], conditionID, factorA, factorB, this.ConditionKey);
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.m_Str[5], Vector2.zero);
	}

	// Token: 0x06000939 RID: 2361 RVA: 0x000BC954 File Offset: 0x000BAB54
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(false);
	}

	// Token: 0x0600093A RID: 2362 RVA: 0x000BC968 File Offset: 0x000BAB68
	public void SetAlertImageAlpha(float Alpha)
	{
		if (GUIManager.Instance.m_AlertImageIndex == 0 && this.alertBlock != null && this.alertBlock.gameObject.activeSelf)
		{
			Color color = new Color(1f, 1f, 1f, Alpha);
			if (this.alertBlock_T != null)
			{
				this.alertBlock_T.color = color;
			}
			if (this.alertBlock_B != null)
			{
				this.alertBlock_B.color = color;
			}
			if (this.alertBlock_L != null)
			{
				this.alertBlock_L.color = color;
			}
			if (this.alertBlock_R != null)
			{
				this.alertBlock_R.color = color;
			}
		}
	}

	// Token: 0x0600093B RID: 2363 RVA: 0x000BCA38 File Offset: 0x000BAC38
	public void SetAlertBlock(bool bOpenAlertBlock)
	{
		this.alertBlock.gameObject.SetActive(bOpenAlertBlock);
	}

	// Token: 0x04001DE6 RID: 7654
	private const int MaxIcon = 5;

	// Token: 0x04001DE7 RID: 7655
	private const int MaxCheckpoint = 3;

	// Token: 0x04001DE8 RID: 7656
	private const int MaxDeltatime = 90;

	// Token: 0x04001DE9 RID: 7657
	private const int MaxChallengeIcons = 8;

	// Token: 0x04001DEA RID: 7658
	private Transform m_transform;

	// Token: 0x04001DEB RID: 7659
	private StringBuilder sb = new StringBuilder();

	// Token: 0x04001DEC RID: 7660
	private Transform alertBlock;

	// Token: 0x04001DED RID: 7661
	private Image alertBlock_T;

	// Token: 0x04001DEE RID: 7662
	private Image alertBlock_B;

	// Token: 0x04001DEF RID: 7663
	private Image alertBlock_L;

	// Token: 0x04001DF0 RID: 7664
	private Image alertBlock_R;

	// Token: 0x04001DF1 RID: 7665
	public RectTransform[] btnRt = new RectTransform[5];

	// Token: 0x04001DF2 RID: 7666
	private RectTransform[] hpSlidersRt = new RectTransform[5];

	// Token: 0x04001DF3 RID: 7667
	private RectTransform[] mpSlidersRt = new RectTransform[5];

	// Token: 0x04001DF4 RID: 7668
	private RectTransform[] selectImageRt = new RectTransform[5];

	// Token: 0x04001DF5 RID: 7669
	private Transform[] maxMpSlider = new Transform[5];

	// Token: 0x04001DF6 RID: 7670
	private Transform[] weekHpSlider = new Transform[5];

	// Token: 0x04001DF7 RID: 7671
	private Slider[] ChallegeBloodRestrictSL = new Slider[5];

	// Token: 0x04001DF8 RID: 7672
	private Image[] hpImage = new Image[5];

	// Token: 0x04001DF9 RID: 7673
	public UIHIBtn[] buttons = new UIHIBtn[5];

	// Token: 0x04001DFA RID: 7674
	private Image[] deadImages = new Image[5];

	// Token: 0x04001DFB RID: 7675
	private Slider[] hpSliders = new Slider[5];

	// Token: 0x04001DFC RID: 7676
	private Slider[] mpSliders = new Slider[5];

	// Token: 0x04001DFD RID: 7677
	private Image[] selectImage = new Image[5];

	// Token: 0x04001DFE RID: 7678
	private uTweenAlpha[] selectTween = new uTweenAlpha[5];

	// Token: 0x04001DFF RID: 7679
	private UIButton kingBtn;

	// Token: 0x04001E00 RID: 7680
	private Image kingBar;

	// Token: 0x04001E01 RID: 7681
	private UIButton nextButton1;

	// Token: 0x04001E02 RID: 7682
	private UIButton nextButton2;

	// Token: 0x04001E03 RID: 7683
	private Sprite nextSprite;

	// Token: 0x04001E04 RID: 7684
	private Transform itemTextTf;

	// Token: 0x04001E05 RID: 7685
	private Transform checkpointTextTf;

	// Token: 0x04001E06 RID: 7686
	private Transform infoImg0;

	// Token: 0x04001E07 RID: 7687
	private Transform infoImg2;

	// Token: 0x04001E08 RID: 7688
	private Transform infoImg3;

	// Token: 0x04001E09 RID: 7689
	private UIText timeText;

	// Token: 0x04001E0A RID: 7690
	private UIText itemText;

	// Token: 0x04001E0B RID: 7691
	private UIText checkpointText;

	// Token: 0x04001E0C RID: 7692
	private UIButton pauseButton;

	// Token: 0x04001E0D RID: 7693
	public UIButton autoButtonUp;

	// Token: 0x04001E0E RID: 7694
	private Material iconMat;

	// Token: 0x04001E0F RID: 7695
	private UIButton debugButton;

	// Token: 0x04001E10 RID: 7696
	private UISpritesArray spriteArray;

	// Token: 0x04001E11 RID: 7697
	private UIButton CameraBtn;

	// Token: 0x04001E12 RID: 7698
	private Transform PausePanel;

	// Token: 0x04001E13 RID: 7699
	private float deltaTime = 90f;

	// Token: 0x04001E14 RID: 7700
	private float tempDeltaTime;

	// Token: 0x04001E15 RID: 7701
	private bool isPause;

	// Token: 0x04001E16 RID: 7702
	private bool bCountDown = true;

	// Token: 0x04001E17 RID: 7703
	private int itemCount;

	// Token: 0x04001E18 RID: 7704
	public BattleController bc;

	// Token: 0x04001E19 RID: 7705
	public byte[] indexPosMap = new byte[]
	{
		2,
		1,
		3,
		0,
		4
	};

	// Token: 0x04001E1A RID: 7706
	private IconScaleValue[] iconScaleValue = new IconScaleValue[5];

	// Token: 0x04001E1B RID: 7707
	private SliserTime[] IconSliserTime = new SliserTime[5];

	// Token: 0x04001E1C RID: 7708
	private UIText m_CenterMsgText;

	// Token: 0x04001E1D RID: 7709
	private Image m_CenterMsgBg;

	// Token: 0x04001E1E RID: 7710
	private Transform m_CenterMsgTf;

	// Token: 0x04001E1F RID: 7711
	private Transform m_IPhoneXPPanel;

	// Token: 0x04001E20 RID: 7712
	private float m_CenterMsgTime;

	// Token: 0x04001E21 RID: 7713
	private bool bShowCenterMsg;

	// Token: 0x04001E22 RID: 7714
	private float m_CenterMsgColorA;

	// Token: 0x04001E23 RID: 7715
	private float m_CenterCountDownTime = 2f;

	// Token: 0x04001E24 RID: 7716
	private RectTransform m_CountDownRect;

	// Token: 0x04001E25 RID: 7717
	private UIText m_CountDownText;

	// Token: 0x04001E26 RID: 7718
	private float m_CounDownTick;

	// Token: 0x04001E27 RID: 7719
	private float m_CountDownScale;

	// Token: 0x04001E28 RID: 7720
	private float m_CountDownAColor;

	// Token: 0x04001E29 RID: 7721
	private bool bShowCountDownText;

	// Token: 0x04001E2A RID: 7722
	private float m_PreCountDownNum;

	// Token: 0x04001E2B RID: 7723
	private bool bArenaMod;

	// Token: 0x04001E2C RID: 7724
	private bool bNpcBossMod;

	// Token: 0x04001E2D RID: 7725
	private Transform npcHpTf;

	// Token: 0x04001E2E RID: 7726
	private Image npcHpImg;

	// Token: 0x04001E2F RID: 7727
	private UIText npcBossID;

	// Token: 0x04001E30 RID: 7728
	private UIText npcBossHpValue;

	// Token: 0x04001E31 RID: 7729
	private int bossDataIdx;

	// Token: 0x04001E32 RID: 7730
	private byte bossLv;

	// Token: 0x04001E33 RID: 7731
	private ushort bossID;

	// Token: 0x04001E34 RID: 7732
	private uint bossMaxHp;

	// Token: 0x04001E35 RID: 7733
	private uint bossCurHp;

	// Token: 0x04001E36 RID: 7734
	private ushort MaxTime = 90;

	// Token: 0x04001E37 RID: 7735
	private float effectTime = 0.35f;

	// Token: 0x04001E38 RID: 7736
	private float effectTime2 = 0.05f;

	// Token: 0x04001E39 RID: 7737
	private float delay = 0.15f;

	// Token: 0x04001E3A RID: 7738
	private float mpValueTime = 1f;

	// Token: 0x04001E3B RID: 7739
	public Transform projectorTrans;

	// Token: 0x04001E3C RID: 7740
	public bool ultraSkillWorking;

	// Token: 0x04001E3D RID: 7741
	public bool bProjectorMode;

	// Token: 0x04001E3E RID: 7742
	public int projectorType;

	// Token: 0x04001E3F RID: 7743
	private Vector3 curUltraSkillerPos = Vector3.zero;

	// Token: 0x04001E40 RID: 7744
	public Ray rayCache = default(Ray);

	// Token: 0x04001E41 RID: 7745
	private Transform challengePausePanel;

	// Token: 0x04001E42 RID: 7746
	private UIText text_ChallengeTitle;

	// Token: 0x04001E43 RID: 7747
	private UIText text_ChallengeContinuance;

	// Token: 0x04001E44 RID: 7748
	private UIText text_ChallengeExit;

	// Token: 0x04001E45 RID: 7749
	private UIText text_ChallengeGgain;

	// Token: 0x04001E46 RID: 7750
	private UIText text_ChallengeHint;

	// Token: 0x04001E47 RID: 7751
	private BattleChallengeIcon[] battleChallengeIcons = new BattleChallengeIcon[8];

	// Token: 0x04001E48 RID: 7752
	private ushort ConditionKey;

	// Token: 0x04001E49 RID: 7753
	private bool bChallegeMode;

	// Token: 0x04001E4A RID: 7754
	private ushort[] ChallegeCheckPointTimeRule = new ushort[3];

	// Token: 0x04001E4B RID: 7755
	private ushort RestrictBlood;

	// Token: 0x04001E4C RID: 7756
	private int CheckPoint;

	// Token: 0x04001E4D RID: 7757
	private int MaxStr = 6;

	// Token: 0x04001E4E RID: 7758
	private CString[] m_Str;

	// Token: 0x04001E4F RID: 7759
	private int[] MaxStrLen = new int[]
	{
		30,
		30,
		30,
		30,
		30,
		300
	};

	// Token: 0x020001F2 RID: 498
	public enum e_BattleIcon
	{
		// Token: 0x04001E51 RID: 7761
		AlertBlock,
		// Token: 0x04001E52 RID: 7762
		ImageLeft,
		// Token: 0x04001E53 RID: 7763
		ImageRight,
		// Token: 0x04001E54 RID: 7764
		SliderHP0,
		// Token: 0x04001E55 RID: 7765
		SliderHP1,
		// Token: 0x04001E56 RID: 7766
		SliderHP2,
		// Token: 0x04001E57 RID: 7767
		SliderHP3,
		// Token: 0x04001E58 RID: 7768
		SliderHP4,
		// Token: 0x04001E59 RID: 7769
		SliderMP0,
		// Token: 0x04001E5A RID: 7770
		SliderMP1,
		// Token: 0x04001E5B RID: 7771
		SliderMP2,
		// Token: 0x04001E5C RID: 7772
		SliderMP3,
		// Token: 0x04001E5D RID: 7773
		SliderMP4,
		// Token: 0x04001E5E RID: 7774
		Icon0,
		// Token: 0x04001E5F RID: 7775
		Icon1,
		// Token: 0x04001E60 RID: 7776
		Icon2,
		// Token: 0x04001E61 RID: 7777
		Icon3,
		// Token: 0x04001E62 RID: 7778
		Icon4,
		// Token: 0x04001E63 RID: 7779
		KingSkill,
		// Token: 0x04001E64 RID: 7780
		KingBar,
		// Token: 0x04001E65 RID: 7781
		NextButton,
		// Token: 0x04001E66 RID: 7782
		NextButton2,
		// Token: 0x04001E67 RID: 7783
		InfoImage0,
		// Token: 0x04001E68 RID: 7784
		InfoImage1,
		// Token: 0x04001E69 RID: 7785
		InfoImage2,
		// Token: 0x04001E6A RID: 7786
		InfoImage3,
		// Token: 0x04001E6B RID: 7787
		InfoImage4,
		// Token: 0x04001E6C RID: 7788
		TimeText,
		// Token: 0x04001E6D RID: 7789
		ItemText,
		// Token: 0x04001E6E RID: 7790
		Checkpoint,
		// Token: 0x04001E6F RID: 7791
		PauseButtonImage,
		// Token: 0x04001E70 RID: 7792
		PauseButton,
		// Token: 0x04001E71 RID: 7793
		AutoButtonImage,
		// Token: 0x04001E72 RID: 7794
		AutoButton,
		// Token: 0x04001E73 RID: 7795
		DebugSpeep,
		// Token: 0x04001E74 RID: 7796
		CameraBtn,
		// Token: 0x04001E75 RID: 7797
		CountDownText,
		// Token: 0x04001E76 RID: 7798
		NpcHp,
		// Token: 0x04001E77 RID: 7799
		PausePanel,
		// Token: 0x04001E78 RID: 7800
		ChallengePausePanel,
		// Token: 0x04001E79 RID: 7801
		CenterHudPanel,
		// Token: 0x04001E7A RID: 7802
		IPhoneX
	}
}
