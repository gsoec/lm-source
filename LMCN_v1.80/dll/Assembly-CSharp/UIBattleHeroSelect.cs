using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004F8 RID: 1272
public class UIBattleHeroSelect : GUIWindow, IUpDateRowItem, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x0600196D RID: 6509 RVA: 0x002B29F0 File Offset: 0x002B0BF0
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager.SortHeroData();
		DataManager.Instance.SetFightHeroData();
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (arg2 < 0)
		{
			if (arg2 == -1)
			{
				this.SelectMode = UIBattleHeroSelect._SelectMode.ArenaDefense;
			}
			if (arg2 == -2)
			{
				this.m_ArenaTargetIdx = arg1;
				this.SelectMode = UIBattleHeroSelect._SelectMode.ArenaAttack;
			}
		}
		else if (arg2 > 0)
		{
			this.SelectMode = UIBattleHeroSelect._SelectMode.Monster;
			this.MonsterMapID = arg1;
			this.AttackTimes = arg2;
			MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.MonsterMapID];
			if (mapPoint.pointKind == 10)
			{
				NPCPoint npcpoint = DataManager.MapDataController.NPCPointTable[(int)mapPoint.tableID];
				this.MonsterID = npcpoint.NPCNum;
			}
		}
		Array.Clear(this.tmpTopicIdx, 0, this.tmpTopicIdx.Length);
		Array.Clear(this.tmpHeroIdx, 0, this.tmpHeroIdx.Length);
		this.mCondition_CountIdx = 0;
		this.bConditionTopic = false;
		this.bConditionCount = false;
		this.bConditionHeroID = false;
		if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero && DataManager.StageDataController._stageMode == StageMode.Dare)
		{
			this.SelectMode = UIBattleHeroSelect._SelectMode.Condition;
			this.LevelexDate = DataManager.StageDataController.GetLevelEXBycurrentPointID(0);
			DataManager.SortConditionHeroData();
			this.CheckCondition();
		}
		this.m_SpArray = base.transform.GetComponent<UISpritesArray>();
		Vector2 vector = new Vector2(1384f, 640f);
		if (((RectTransform)base.transform).rect.width > vector.x)
		{
			vector.x = ((RectTransform)base.transform).rect.width + ((!GUIManager.Instance.bOpenOnIPhoneX) ? 0f : (GUIManager.Instance.IPhoneX_DeltaX * 2f));
			RectTransform rectTransform = (RectTransform)base.transform.GetChild(0);
			RectTransform rectTransform2 = (RectTransform)base.transform.GetChild(1);
			vector = new Vector2(vector.x * 0.5f, vector.y);
			rectTransform.sizeDelta = vector;
			rectTransform2.sizeDelta = vector;
			vector = new Vector2(vector.x * 0.25f, 0f);
			rectTransform.anchoredPosition = -vector;
			rectTransform2.anchoredPosition = vector;
		}
		Image component = base.transform.GetChild(4).GetComponent<Image>();
		component.sprite = door.LoadSprite("UI_main_close_base");
		component.material = door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX && component)
		{
			component.enabled = false;
		}
		this.m_TheEnemyPanel = base.transform.GetChild(3);
		UIButtonHint uibuttonHint = this.m_TheEnemyPanel.GetChild(6).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 2;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.m_EnemyPowerIcon = this.m_TheEnemyPanel.GetChild(6).GetChild(0).GetComponent<Image>();
		this.m_EnemyPower = this.m_TheEnemyPanel.GetChild(6).GetChild(1).GetComponent<UIText>();
		this.m_EnemyPower.font = GUIManager.Instance.GetTTFFont();
		this.m_EnemyText = this.m_TheEnemyPanel.GetChild(7).GetComponent<UIText>();
		this.m_EnemyText.font = GUIManager.Instance.GetTTFFont();
		this.m_EnemyText.text = DataManager.Instance.mStringTable.GetStringByID(9149u);
		for (int i = 0; i < this.m_BattleHeroEnemy.Length; i++)
		{
			this.m_BattleHeroEnemy[i] = this.m_TheEnemyPanel.GetChild(i + 1).GetChild(1).GetComponent<UIHIBtn>();
			GUIManager.Instance.InitianHeroItemImg(this.m_BattleHeroEnemy[i].transform, eHeroOrItem.Hero, 0, 0, 0, 0, true, false, true, false);
			this.m_BattleHeroEnemy[i].transition = Selectable.Transition.None;
			this.m_EnemyAstrology[i] = this.m_TheEnemyPanel.GetChild(i + 1).GetChild(2).GetComponent<Image>();
			this.m_EnemyBg[i] = this.m_TheEnemyPanel.GetChild(i + 1).GetChild(0).GetComponent<Image>();
		}
		Transform child = base.transform.GetChild(4).GetChild(0);
		UIButton component2 = child.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 1;
		component2.image.sprite = door.LoadSprite("UI_main_close");
		component2.image.material = door.LoadMaterial();
		this.m_Str = StringManager.Instance.SpawnString(30);
		this.m_Str2 = StringManager.Instance.SpawnString(30);
		this.m_Str3 = StringManager.Instance.SpawnString(30);
		this.m_ConditionHint = StringManager.Instance.SpawnString(1024);
		Transform child2 = base.transform.GetChild(5);
		this.m_BattleHeroPanel = child2;
		this.m_BattleHeroBg[0] = child2.GetChild(0);
		this.m_BattleHeroBg[1] = child2.GetChild(1);
		this.tempSprite = child2.GetChild(6).GetComponent<Image>().sprite;
		for (int j = 0; j < this.m_BattleHero.Length; j++)
		{
			this.m_BattleHeroTf[j] = child2.GetChild(j + 6);
			this.m_BattleHeroStartImage[j] = child2.GetChild(j + 6).GetChild(3).GetComponent<Image>();
			this.mConditionLock[j] = child2.GetChild(j + 6).GetChild(4);
			child = child2.GetChild(j + 6).GetChild(1);
			this.m_BattleHero[j] = child.GetComponent<UIHIBtn>();
			this.m_BattleHero[j].m_Handler = this;
			this.m_BattleHero[j].m_BtnID1 = 2;
			GUIManager.Instance.InitianHeroItemImg(this.m_BattleHero[j].transform, eHeroOrItem.Hero, 0, 0, 0, 0, true, false, true, false);
			this.m_BattleHero[j].SoundIndex = 64;
			this.m_BattleHero[j].HIImage.sprite = this.tempSprite;
			this.m_BattleHero[j].gameObject.SetActive(false);
			this.frameMat = GUIManager.Instance.GetFrameMaterial();
			this.lightSprite = GUIManager.Instance.LoadFrameSprite("UI_super_light");
			child = child2.GetChild(j + 6).GetChild(2);
			this.effectImages[j] = child.GetComponent<Image>();
			this.effectImages[j].sprite = this.lightSprite;
			this.effectImages[j].material = this.frameMat;
			child = child2.GetChild(j + 12);
			this.m_MoveBattleHeroTf[j] = child;
			this.m_MoveBattleHero[j] = child.GetComponent<UIHIBtn>();
			this.m_MoveBattleHero[j].gameObject.SetActive(false);
			GUIManager.Instance.InitianHeroItemImg(this.m_MoveBattleHero[j].transform, eHeroOrItem.Hero, 0, 0, 0, 0, true, false, true, false);
			child = child2.GetChild(j + 6).GetChild(2);
			this.m_BattleHeroAmins[j] = child.GetComponent<Animator>();
			this.m_BattleHeroAmins[j].gameObject.SetActive(false);
		}
		this.m_ScoreBG = child2.GetChild(11);
		this.m_ScoreBG2 = base.transform.GetChild(14);
		uibuttonHint = child2.GetChild(11).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 1;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint = base.transform.GetChild(14).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_DownUpHandler = this;
		uibuttonHint.Parm1 = 3;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		this.m_ScorePowerImage = child2.GetChild(11).GetChild(0).GetComponent<Image>();
		child = child2.GetChild(11).GetChild(1);
		this.m_ScoreText = child.GetComponent<UIText>();
		this.m_ScoreText.font = GUIManager.Instance.GetTTFFont();
		this.m_ScoreText2 = base.transform.GetChild(14).GetChild(1).GetComponent<UIText>();
		this.m_ScoreText2.font = GUIManager.Instance.GetTTFFont();
		this.m_ScorePowerImage2 = base.transform.GetChild(14).GetChild(0).GetComponent<Image>();
		child2 = base.transform.GetChild(6);
		this.m_KingSkill = child2.GetComponent<UIButton>();
		this.m_KingSkill.m_Handler = this;
		this.m_KingSkill.m_BtnID1 = 3;
		child = child2.GetChild(0);
		this.m_tmptext[this.mTextCount] = child.GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = GUIManager.Instance.GetTTFFont();
		this.mTextCount++;
		child2 = base.transform.GetChild(23);
		this.m_KingSkillPanel = child2.GetComponent<UIButton>();
		this.m_KingSkillPanel.m_Handler = this;
		this.m_KingSkillPanel.m_BtnID1 = 4;
		this.m_Hint = base.transform.GetChild(24);
		this.m_HintImage = base.transform.GetChild(24).gameObject.GetComponent<Image>();
		this.m_HintText = base.transform.GetChild(24).GetChild(0).GetComponent<UIText>();
		this.m_HintText.font = GUIManager.Instance.GetTTFFont();
		for (int k = 0; k < 8; k++)
		{
			child = child2.GetChild(k);
			component2 = child.GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 4;
			component2.m_BtnID2 = k + 1;
			child = child.GetChild(1);
			this.m_tmptext[this.mTextCount] = child.GetComponent<UIText>();
			this.m_tmptext[this.mTextCount].font = GUIManager.Instance.GetTTFFont();
			this.mTextCount++;
		}
		child = base.transform.GetChild(15);
		component2 = child.GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 5;
		if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaDefense)
		{
			component2.SoundIndex = 0;
		}
		else
		{
			component2.SoundIndex = byte.MaxValue;
		}
		this.m_BattleButtonImage = child.GetChild(0).GetComponent<Image>();
		this.m_FightButtonText = child.GetChild(1).GetComponent<UIText>();
		this.m_FightButtonText.font = GUIManager.Instance.GetTTFFont();
		this.m_FightButtonText.text = DataManager.Instance.mStringTable.GetStringByID(9127u);
		this.m_FightButtonText.enabled = false;
		this.m_FightButtonPosition = component2.gameObject.GetComponent<RectTransform>().localPosition;
		child = base.transform.GetChild(18);
		this.m_HerosView = child.GetComponent<ScrollView>();
		Transform child3 = this.m_HerosView.customItem.transform.GetChild(0);
		this.m_HerosView.customItem.GetComponent<ScrollItem>().SoundIndex = 64;
		this.m_HerosView.customItem.transform.GetChild(2).GetComponent<Image>().sprite = this.lightSprite;
		this.m_HerosView.customItem.transform.GetChild(2).GetComponent<Image>().material = this.frameMat;
		GUIManager.Instance.InitianHeroItemImg(child3, eHeroOrItem.Hero, 0, 0, 0, 0, true, false, true, false);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component3 = base.transform.GetChild(22).GetChild(1).GetComponent<RectTransform>();
			Vector3 localScale = component3.localScale;
			localScale.x = -1f;
			component3.localScale = localScale;
		}
		for (int l = 0; l < 3; l++)
		{
			child = base.transform.GetChild(19 + l);
			this.scrollBlack[l] = child.GetComponent<Image>();
		}
		for (int m = 1; m < 3; m++)
		{
			this.scrollBlack[m].sprite = GUIManager.Instance.LoadFrameSprite("UI_shared_black");
			this.scrollBlack[m].material = this.frameMat;
		}
		child2 = base.transform.GetChild(25);
		this.m_Preview = child2.GetComponent<UIButton>();
		this.m_Preview.m_Handler = this;
		this.m_Preview.m_BtnID1 = 6;
		this.m_Previewicon[0] = child2.GetChild(0).GetComponent<Image>();
		this.m_Previewicon[1] = child2.GetChild(1).GetComponent<Image>();
		this.m_PreviewPanel = base.transform.GetChild(26);
		this.m_ConditionText[1] = this.m_PreviewPanel.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_ConditionText[1].font = GUIManager.Instance.GetTTFFont();
		this.m_ConditionText[1].text = DataManager.Instance.mStringTable.GetStringByID(10005u);
		this.m_ConditioniconPanel = this.m_PreviewPanel.GetChild(2);
		for (int n = 0; n < 8; n++)
		{
			this.m_ConditioniconItem[n] = this.m_ConditioniconPanel.GetChild(n);
			component2 = this.m_ConditioniconPanel.GetChild(n).GetChild(0).GetComponent<UIButton>();
			uibuttonHint = component2.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 4;
			uibuttonHint.Parm2 = (byte)n;
			this.m_ConditionBG[n] = this.m_ConditioniconPanel.GetChild(n).GetChild(1).GetComponent<Image>();
			this.m_ConditionBG[n].gameObject.SetActive(false);
			this.m_ConditionF[n] = this.m_ConditioniconPanel.GetChild(n).GetChild(2).GetComponent<Image>();
			this.m_ConditionF[n].gameObject.SetActive(false);
		}
		int num = 0;
		if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
		{
			for (int num2 = 0; num2 < this.tmpSCD.ConditionArray.Length; num2++)
			{
				this.m_ConditionBG[num2].gameObject.SetActive(false);
				if (this.tmpSCD.ConditionArray[num2].ConditionID != 0)
				{
					this.m_ConditioniconItem[num2].gameObject.SetActive(true);
					this.m_ConditionBG[num2].gameObject.SetActive(true);
					this.m_ConditionBG[num2].sprite = DataManager.StageDataController.GetStageConditionSprite(this.tmpSCD.ConditionArray[num2].ConditionID, this.tmpSCD.ConditionArray[num2].FactorA, this.tmpSCD.ConditionArray[num2].FactorB);
					this.m_ConditionBG[num2].material = DataManager.StageDataController.GetStageConditionMaterial(this.tmpSCD.ConditionArray[num2].ConditionID);
					num++;
				}
			}
			if (this.tmp_C_Count > 0)
			{
				for (int num3 = (int)this.tmp_C_Count; num3 < this.mConditionLock.Length; num3++)
				{
					this.mConditionLock[num3].gameObject.SetActive(true);
				}
			}
		}
		this.m_ConditioniconItem[num].gameObject.SetActive(true);
		this.m_ConditionBG[num].gameObject.SetActive(true);
		this.m_ConditionBG[num].sprite = DataManager.StageDataController.GetStageConditionSprite(byte.MaxValue, 0, 0);
		this.m_ConditionBG[num].material = DataManager.StageDataController.GetStageConditionMaterial(byte.MaxValue);
		this.mChallengeTitle = base.transform.GetChild(27);
		this.m_ConditionText[0] = this.mChallengeTitle.GetChild(0).GetComponent<UIText>();
		this.m_ConditionText[0].font = GUIManager.Instance.GetTTFFont();
		this.m_ConditionText[0].text = DataManager.Instance.mStringTable.GetStringByID(10048u);
		int num4 = 0;
		ushort num5 = 0;
		if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero)
		{
			DataManager.Instance.GetHeroBattleDataSave();
		}
		if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition && !GUIManager.Instance.bBackInPreviewModel)
		{
			DataManager.Instance.GetHero_Condition_BattleDataSave();
			for (int num6 = 0; num6 < DataManager.Instance.heroBattleConditionData.Length; num6++)
			{
				DataManager.Instance.heroBattleData[num6].HeroID = DataManager.Instance.heroBattleConditionData[num6].HeroID;
			}
		}
		if (NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE))
		{
			DataManager instance = DataManager.Instance;
			Array.Clear(instance.heroBattleData, 0, 5);
			this.NewbieSort();
		}
		for (int num7 = 0; num7 < 5; num7++)
		{
			if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero)
			{
				num5 = DataManager.Instance.heroBattleData[num7].HeroID;
			}
			else if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaDefense)
			{
				num5 = ArenaManager.Instance.m_ArenaDefHero[num7];
			}
			else if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaAttack)
			{
				this.SetEnemyHero();
				num5 = ArenaManager.Instance.m_ArenaTargetHero[num7];
			}
			else if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
			{
				if (!this.CheckCondition_HeroNum((ushort)(num7 + 1)))
				{
					num5 = DataManager.Instance.heroBattleData[num7].HeroID;
				}
				else
				{
					num5 = 0;
				}
			}
			else if (DataManager.Instance.m_FightNpcData.ContainsKey(this.MonsterID))
			{
				num5 = DataManager.Instance.m_FightNpcData[this.MonsterID].HeroID[num7];
			}
			if (this.CheckCanSelectById(num5) == e_SelecBtnState.None)
			{
				this.m_BattleHeroID[num4] = num5;
				if (DataManager.Instance.curHeroData.ContainsKey((uint)this.m_BattleHeroID[num4]))
				{
					this.m_BattleHero[num4].gameObject.SetActive(true);
					CurHeroData curHeroData = DataManager.Instance.curHeroData[(uint)this.m_BattleHeroID[num4]];
					this.m_BattleHero[num4].m_BtnID2 = (int)this.m_BattleHeroID[num4];
					if (this.SelectMode != UIBattleHeroSelect._SelectMode.Condition)
					{
						GUIManager.Instance.ChangeHeroItemImg(this.m_BattleHero[num4].transform, eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
					}
					else
					{
						GUIManager.Instance.ChangeHeroItemImg(this.m_BattleHero[num4].transform, eHeroOrItem.Hero, curHeroData.ID, this.LevelexDate.Star, this.LevelexDate.Rank, (int)this.LevelexDate.LV);
					}
					if (num4 < this.m_BattleHeroStartImage.Length)
					{
						this.m_BattleHeroStartImage[num4].gameObject.SetActive(this.CheckAstrology(curHeroData.ID));
					}
					this.m_BattleHeroNum += 1;
					num4++;
				}
			}
		}
		this.m_HerosView.AddHender(this, true, 0, 0, 0f, null, 0f, null, default(ScrollViewIndexValue));
		Mask component4 = this.m_HerosView.GetComponent<Mask>();
		component4.showMaskGraphic = false;
		this.itemScrollRect = this.m_HerosView.transform.GetComponent<CScrollRect>();
		this.itemCont = this.m_HerosView.transform.GetChild(0).GetComponent<RectTransform>();
		if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
		{
			this.mChallengeTitle.gameObject.SetActive(true);
			this.m_Preview.gameObject.SetActive(true);
			if (GUIManager.Instance.bBackInPreviewModel)
			{
				this.OnButtonClick(this.m_Preview);
				this.itemScrollRect.StopMovement();
				Vector2 anchoredPosition = this.itemCont.anchoredPosition;
				anchoredPosition.y = GUIManager.Instance.BackInPreviewHight;
				this.itemCont.anchoredPosition = anchoredPosition;
				this.m_HerosView.SetContentSize((int)DataManager.Instance.CurHeroDataCount);
				this.m_HerosView.UpDateAllItem();
				GUIManager.Instance.bBackInPreviewModel = false;
			}
			this.m_ScoreBG.gameObject.SetActive(false);
		}
		this.m_Str.ClearString();
		StringManager.Instance.IntToFormat((long)((ulong)this.GetAllPower()), 1, true);
		this.m_Str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(53u));
		this.m_ScoreText.text = this.m_Str.ToString();
		this.m_ScoreText.SetAllDirty();
		this.m_ScoreText.cachedTextGenerator.Invalidate();
		this.m_ScoreText.cachedTextGeneratorForLayout.Invalidate();
		this.m_ScoreText2.text = this.m_Str.ToString();
		this.m_ScoreText2.SetAllDirty();
		this.m_ScoreText2.cachedTextGenerator.Invalidate();
		this.m_ScoreText2.cachedTextGeneratorForLayout.Invalidate();
		this.SetCenterText(this.m_ScorePowerImage, this.m_ScoreText, 371f);
		this.SetCenterText(this.m_ScorePowerImage2, this.m_ScoreText2, 292f);
		this.m_HerosView.SetContentSize((int)DataManager.Instance.CurHeroDataCount);
		for (int num8 = 0; num8 < 5; num8++)
		{
			this.moveStack[num8] = new MoveObject();
		}
		if (door != null && this.SelectMode != UIBattleHeroSelect._SelectMode.ArenaDefense)
		{
			GUIManager.Instance.pDVMgr.FightBeginPos = base.transform.GetChild(15).localPosition;
			door.ShowFightButton(this.m_FightButtonPosition + this.m_AddPositio, 250f, false, E3DButtonKind.BK_Big);
		}
		this.SetUIBySelectMode(this.SelectMode);
		NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, this, false);
		if (GUIManager.Instance.IsArabic)
		{
			this.Swap(this.m_BattleHeroTf[1], this.m_BattleHeroTf[2]);
			this.Swap(this.m_BattleHeroTf[3], this.m_BattleHeroTf[4]);
			RectTransform component5 = base.transform.GetChild(22).GetChild(1).GetComponent<RectTransform>();
			Vector3 localScale2 = component5.localScale;
			localScale2.x = -1f;
			component5.localScale = localScale2;
		}
	}

	// Token: 0x0600196E RID: 6510 RVA: 0x002B4004 File Offset: 0x002B2204
	private void Swap(Transform t1, Transform t2)
	{
		Vector2 anchoredPosition = t1.gameObject.GetComponent<RectTransform>().anchoredPosition;
		t1.gameObject.GetComponent<RectTransform>().anchoredPosition = t2.gameObject.GetComponent<RectTransform>().anchoredPosition;
		t2.gameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
	}

	// Token: 0x0600196F RID: 6511 RVA: 0x002B4054 File Offset: 0x002B2254
	public void NewbieSort()
	{
		DataManager instance = DataManager.Instance;
		int num = Array.IndexOf<uint>(instance.sortHeroData, 1u);
		if (num != -1)
		{
			instance.sortHeroData[num] = instance.sortHeroData[0];
			instance.sortHeroData[0] = 1u;
		}
		num = Array.IndexOf<uint>(instance.sortHeroData, 9u);
		if (num != -1)
		{
			instance.sortHeroData[num] = instance.sortHeroData[1];
			instance.sortHeroData[1] = 9u;
		}
	}

	// Token: 0x06001970 RID: 6512 RVA: 0x002B40C4 File Offset: 0x002B22C4
	public void OnButtonClick(UIButton sender)
	{
		if (this.fightButtonTime > 0f)
		{
			return;
		}
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		switch (sender.m_BtnID1)
		{
		case 1:
			if (door != null)
			{
				GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_ArenaBattle);
				door.CloseMenu(false);
			}
			break;
		case 3:
			this.m_KingSkillPanel.gameObject.SetActive(true);
			break;
		case 4:
			if (sender.m_BtnID2 > 0)
			{
				Transform child = this.m_KingSkillPanel.transform.GetChild((int)this.m_KingSkillIndex);
				child = child.GetChild(0);
				child.gameObject.SetActive(false);
				child = sender.transform.GetChild(0);
				child.gameObject.SetActive(true);
				child = this.m_KingSkill.transform.GetChild(0);
				UIText component = child.GetComponent<UIText>();
				component.text = sender.m_BtnID2.ToString();
				this.m_KingSkillIndex = (byte)(sender.m_BtnID2 - 1);
			}
			this.m_KingSkillPanel.gameObject.SetActive(false);
			break;
		case 5:
		{
			DataManager instance = DataManager.Instance;
			if (this.m_BattleHeroNum > 0)
			{
				if (!this.CheckHeroRes())
				{
					GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8350u), 255, true);
					return;
				}
				if ((this.SelectMode == UIBattleHeroSelect._SelectMode.Hero || this.SelectMode == UIBattleHeroSelect._SelectMode.Condition) && !WarManager.CheckVersion(true))
				{
					return;
				}
				if (this.CheckCondition_HeroID())
				{
					return;
				}
				if (!NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE))
				{
					uint nonFightHeroCount = instance.NonFightHeroCount;
					if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition && this.bConditionCount)
					{
						nonFightHeroCount = (uint)this.tmp_C_Count;
					}
					if ((int)this.m_BattleHeroNum < instance.heroBattleData.Length && (uint)this.m_BattleHeroNum < nonFightHeroCount)
					{
						GUIManager.Instance.OpenOKCancelBox(this, null, instance.mStringTable.GetStringByID(35u), 0, 0, null, null);
						this.bCanClickbtn = true;
						return;
					}
				}
				Array.Clear(instance.heroBattleData, 0, instance.heroBattleData.Length);
				for (int i = 0; i < 5; i++)
				{
					instance.heroBattleData[i].HeroID = this.m_BattleHeroID[i];
				}
				instance.heroCount = this.m_BattleHeroNum;
				if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero || this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
				{
					BattleNetwork.sendInitBattle();
				}
				else if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaDefense)
				{
					ArenaManager.Instance.SendArena_Set_DefHero(this.m_BattleHeroID);
				}
				else if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaAttack)
				{
					GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_ArenaBattle);
					for (int j = 0; j < 5; j++)
					{
						ArenaManager.Instance.m_ArenaTargetHero[j] = this.m_BattleHeroID[j];
					}
					ArenaManager.Instance.SendArena_Challenge((byte)this.m_ArenaTargetIdx);
				}
				else if (this.CheckMonsterRule())
				{
					this.UpdateUI(0, 0);
				}
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(39u), 255, true);
			}
			break;
		}
		case 6:
			this.bPreviewHeroModel = !this.bPreviewHeroModel;
			this.m_Previewicon[0].gameObject.SetActive(!this.bPreviewHeroModel);
			this.m_Previewicon[1].gameObject.SetActive(this.bPreviewHeroModel);
			this.m_BattleHeroPanel.gameObject.SetActive(!this.bPreviewHeroModel);
			this.m_PreviewPanel.gameObject.SetActive(this.bPreviewHeroModel);
			this.m_ConditioniconPanel.gameObject.SetActive(true);
			this.mChallengeTitle.gameObject.SetActive(!this.bPreviewHeroModel);
			if (this.itemCont != null)
			{
				for (int k = 0; k < this.itemCont.childCount; k++)
				{
					UIHIBtn component2 = this.itemCont.GetChild(k).GetChild(0).GetComponent<UIHIBtn>();
					if (component2 != null)
					{
						if (component2.m_BtnID4 == 1 && this.bPreviewHeroModel)
						{
							this.itemCont.GetChild(k).GetChild(5).gameObject.SetActive(true);
						}
						else
						{
							this.itemCont.GetChild(k).GetChild(5).gameObject.SetActive(false);
						}
					}
				}
			}
			break;
		}
	}

	// Token: 0x06001971 RID: 6513 RVA: 0x002B4560 File Offset: 0x002B2760
	public void OnHIButtonClick(UIHIBtn sender)
	{
		if (this.fightButtonTime > 0f)
		{
			return;
		}
		int btnID = sender.m_BtnID1;
		if (btnID != 2)
		{
			if (btnID == 6)
			{
				ScrollItem component = sender.transform.parent.GetComponent<ScrollItem>();
				this.ButtonOnClick(component.gameObject, component.m_BtnID1);
			}
		}
		else
		{
			int num = sender.transform.parent.GetSiblingIndex() - 6;
			if (num < (int)this.m_BattleHeroNum)
			{
				this.NeedShowFlashID = this.m_BattleHeroID[num];
				this.RemoveBattleHero(num);
				this.m_HerosView.UpDateAllItem();
				this.NeedShowFlashID = 0;
			}
		}
	}

	// Token: 0x06001972 RID: 6514 RVA: 0x002B460C File Offset: 0x002B280C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			DataManager instance = DataManager.Instance;
			for (int i = 0; i < 5; i++)
			{
				instance.heroBattleData[i].HeroID = this.m_BattleHeroID[i];
			}
			instance.heroCount = this.m_BattleHeroNum;
			if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero || this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
			{
				BattleNetwork.sendInitBattle();
			}
			else if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaDefense)
			{
				ArenaManager.Instance.SendArena_Set_DefHero(this.m_BattleHeroID);
			}
			else if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaAttack)
			{
				for (int j = 0; j < 5; j++)
				{
					ArenaManager.Instance.m_ArenaTargetHero[j] = this.m_BattleHeroID[j];
				}
				ArenaManager.Instance.SendArena_Challenge((byte)this.m_ArenaTargetIdx);
			}
			else if (this.SelectMode == UIBattleHeroSelect._SelectMode.Monster && this.CheckMonsterRule())
			{
				this.UpdateUI(0, 0);
			}
		}
		this.bCanClickbtn = false;
	}

	// Token: 0x06001973 RID: 6515 RVA: 0x002B4710 File Offset: 0x002B2910
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 0:
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				this.fightButtonTime = door.PlayFight(0f);
				this.SaveTempHeroData();
				GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Expedition);
				GUIManager.Instance.ShowUILock(EUILock.Normal);
			}
			break;
		}
		case 2:
			this.m_HerosView.SetContentSize((int)DataManager.Instance.CurHeroDataCount);
			this.m_HerosView.UpDateAllItem();
			break;
		case 3:
			this.CheckSelectHero();
			this.m_HerosView.SetContentSize((int)DataManager.Instance.CurHeroDataCount);
			this.m_HerosView.UpDateAllItem();
			break;
		case 4:
		{
			DataManager.Instance.SaveNpcBattleHeroID(this.MonsterID, this.m_BattleHeroID);
			Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (arg2 > 0)
			{
				door2.CloseMenu(true);
			}
			else
			{
				door2.CloseMenu(false);
			}
			break;
		}
		case 5:
		{
			Door door3 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door3)
			{
				door3.CloseMenu(false);
			}
			break;
		}
		case 6:
		{
			GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_ArenaBattle);
			Door door4 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door4)
			{
				door4.CloseMenu(false);
			}
			break;
		}
		case 7:
			this.SetEnemyHero();
			break;
		}
	}

	// Token: 0x06001974 RID: 6516 RVA: 0x002B48A8 File Offset: 0x002B2AA8
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
		case NetworkNews.Refresh_Hero:
			if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
			{
				DataManager.SortConditionHeroData();
			}
			else
			{
				DataManager.SortHeroData();
			}
			if (NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE))
			{
				this.NewbieSort();
			}
			this.m_HerosView.SetContentSize((int)DataManager.Instance.CurHeroDataCount);
			this.m_HerosView.UpDateAllItem();
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
			break;
		}
	}

	// Token: 0x06001975 RID: 6517 RVA: 0x002B4940 File Offset: 0x002B2B40
	public void Refresh_FontTexture()
	{
		if (this.m_ScoreText != null && this.m_ScoreText.enabled)
		{
			this.m_ScoreText.enabled = false;
			this.m_ScoreText.enabled = true;
		}
		if (this.m_ScoreText2 != null && this.m_ScoreText2.enabled)
		{
			this.m_ScoreText2.enabled = false;
			this.m_ScoreText2.enabled = true;
		}
		for (int i = 0; i < 9; i++)
		{
			if (this.m_tmptext[i] != null && this.m_tmptext[i].enabled)
			{
				this.m_tmptext[i].enabled = false;
				this.m_tmptext[i].enabled = true;
			}
		}
		if (this.m_BattleHero != null)
		{
			for (int j = 0; j < this.m_BattleHero.Length; j++)
			{
				if (this.m_BattleHero[j] != null && this.m_BattleHero[j].enabled)
				{
					this.m_BattleHero[j].Refresh_FontTexture();
				}
			}
		}
		if (this.m_MoveBattleHero != null)
		{
			for (int k = 0; k < this.m_MoveBattleHero.Length; k++)
			{
				if (this.m_MoveBattleHero[k] != null && this.m_MoveBattleHero[k].enabled)
				{
					this.m_MoveBattleHero[k].Refresh_FontTexture();
				}
			}
		}
		if (this.m_FightButtonText != null && this.m_FightButtonText.enabled)
		{
			this.m_FightButtonText.enabled = false;
			this.m_FightButtonText.enabled = true;
		}
		if (this.m_HintText != null && this.m_HintText.enabled)
		{
			this.m_HintText.enabled = false;
			this.m_HintText.enabled = true;
		}
		if (this.m_EnemyPower != null && this.m_EnemyPower.enabled)
		{
			this.m_EnemyPower.enabled = false;
			this.m_EnemyPower.enabled = true;
		}
	}

	// Token: 0x06001976 RID: 6518 RVA: 0x002B4B6C File Offset: 0x002B2D6C
	public override void OnClose()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (this.m_Str != null)
		{
			StringManager.Instance.DeSpawnString(this.m_Str);
		}
		if (this.m_Str2 != null)
		{
			StringManager.Instance.DeSpawnString(this.m_Str2);
		}
		if (this.m_Str3 != null)
		{
			StringManager.Instance.DeSpawnString(this.m_Str3);
		}
		if (this.m_ConditionHint != null)
		{
			StringManager.Instance.DeSpawnString(this.m_ConditionHint);
		}
		if (door)
		{
			door.HideFightButton();
		}
	}

	// Token: 0x06001977 RID: 6519 RVA: 0x002B4C0C File Offset: 0x002B2E0C
	public void Initialized()
	{
	}

	// Token: 0x06001978 RID: 6520 RVA: 0x002B4C10 File Offset: 0x002B2E10
	public void UpDateRowItem(GameObject[] gameObjs, int[] btnIndexs)
	{
		uint curHeroDataCount = DataManager.Instance.CurHeroDataCount;
		for (int i = 0; i < gameObjs.Length; i++)
		{
			if ((long)btnIndexs[i] < (long)((ulong)curHeroDataCount))
			{
				uint key = DataManager.Instance.sortHeroData[btnIndexs[i]];
				if (DataManager.Instance.curHeroData.ContainsKey(key))
				{
					CurHeroData curHeroData = DataManager.Instance.curHeroData[key];
					Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(curHeroData.ID);
					gameObjs[i].transform.GetChild(2).GetComponent<Image>().gameObject.SetActive(false);
					if (this.NeedShowFlashID == curHeroData.ID)
					{
						gameObjs[i].transform.GetChild(2).GetComponent<Image>().gameObject.SetActive(true);
					}
					Color color = Color.white;
					gameObjs[i].transform.GetChild(1).GetComponent<Image>().gameObject.SetActive(false);
					for (int j = 0; j < (int)this.m_BattleHeroNum; j++)
					{
						if (recordByKey.HeroKey == this.m_BattleHeroID[j])
						{
							color = Color.gray;
							gameObjs[i].transform.GetChild(1).GetComponent<Image>().gameObject.SetActive(true);
							break;
						}
					}
					Transform child = gameObjs[i].transform.GetChild(0);
					UIHIBtn component = child.GetComponent<UIHIBtn>();
					component.m_BtnID1 = 6;
					if (this.SelectMode != UIBattleHeroSelect._SelectMode.Condition)
					{
						GUIManager.Instance.ChangeHeroItemImg(component.transform, eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
					}
					else
					{
						GUIManager.Instance.ChangeHeroItemImg(component.transform, eHeroOrItem.Hero, curHeroData.ID, this.LevelexDate.Star, this.LevelexDate.Rank, (int)this.LevelexDate.LV);
					}
					gameObjs[i].transform.GetChild(3).gameObject.SetActive(false);
					e_SelecBtnState e_SelecBtnState = this.CheckCanSelectById(curHeroData.ID);
					Image component2;
					if (e_SelecBtnState != e_SelecBtnState.None)
					{
						component2 = gameObjs[i].transform.GetChild(3).GetComponent<Image>();
						color = Color.gray;
						gameObjs[i].transform.GetChild(3).gameObject.SetActive(true);
						if (e_SelecBtnState == e_SelecBtnState.Fighting)
						{
							component2.sprite = this.m_SpArray.GetSprite(0);
						}
						else if (e_SelecBtnState == e_SelecBtnState.LordJail)
						{
							component2.sprite = this.m_SpArray.GetSprite(1);
						}
						else if (e_SelecBtnState == e_SelecBtnState.LordKilled)
						{
							component2.sprite = this.m_SpArray.GetSprite(2);
						}
						else if (e_SelecBtnState == e_SelecBtnState.Condition)
						{
							component2.sprite = this.m_SpArray.GetSprite(3);
						}
					}
					component2 = gameObjs[i].transform.GetChild(4).GetComponent<Image>();
					component2.gameObject.SetActive(this.CheckAstrology(curHeroData.ID));
					if (e_SelecBtnState != e_SelecBtnState.Condition)
					{
						gameObjs[i].transform.GetChild(0).GetComponent<UIHIBtn>().m_BtnID4 = 1;
					}
					else
					{
						gameObjs[i].transform.GetChild(0).GetComponent<UIHIBtn>().m_BtnID4 = 2;
					}
					if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition && this.bPreviewHeroModel && gameObjs[i].transform.GetChild(0).GetComponent<UIHIBtn>().m_BtnID4 == 1)
					{
						gameObjs[i].transform.GetChild(5).gameObject.SetActive(true);
					}
					else
					{
						gameObjs[i].transform.GetChild(5).gameObject.SetActive(false);
					}
					if (e_SelecBtnState == e_SelecBtnState.Fighting || e_SelecBtnState == e_SelecBtnState.LordJail || e_SelecBtnState == e_SelecBtnState.LordJail)
					{
						color = Color.gray;
						gameObjs[i].transform.GetChild(3).gameObject.SetActive(true);
					}
					component.HIImage.color = color;
					component.CircleImage.color = color;
					component.LvOrNum.color = color;
				}
			}
		}
	}

	// Token: 0x06001979 RID: 6521 RVA: 0x002B5020 File Offset: 0x002B3220
	public void ButtonOnClick(GameObject gameObject, int dataIndex)
	{
		if (this.bMoving || this.fightButtonTime > 0f || this.MoveBtnCount > 0 || this.bCanClickbtn)
		{
			return;
		}
		uint num = DataManager.Instance.sortHeroData[dataIndex];
		if (this.CheckPreviewHeroModel(num, dataIndex))
		{
			return;
		}
		if (!DataManager.Instance.curHeroData.ContainsKey(num))
		{
			return;
		}
		if (this.CheckCanSelectById((ushort)num) != e_SelecBtnState.None)
		{
			if (this.CheckCondition_HeroTopic((ushort)num, true))
			{
				return;
			}
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(708u), 255, true);
			return;
		}
		else
		{
			CurHeroData curHeroData = DataManager.Instance.curHeroData[num];
			Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(curHeroData.ID);
			Transform child = gameObject.transform.GetChild(0);
			UIHIBtn component = child.GetComponent<UIHIBtn>();
			for (int i = 0; i < (int)this.m_BattleHeroNum; i++)
			{
				if (recordByKey.HeroKey == this.m_BattleHeroID[i])
				{
					this.RemoveBattleHero(i);
					component.HIImage.color = Color.white;
					component.CircleImage.color = Color.white;
					component.LvOrNum.color = Color.white;
					gameObject.transform.GetChild(1).GetComponent<Image>().gameObject.SetActive(false);
					return;
				}
			}
			if (this.CheckCondition_HeroNum((ushort)(this.m_BattleHeroNum + 1)))
			{
				GUIManager.Instance.MsgStr.ClearString();
				DataManager.StageDataController.GetStageConditionString(GUIManager.Instance.MsgStr, this.tmpSCD.ConditionArray[this.mCondition_CountIdx].ConditionID, this.tmpSCD.ConditionArray[this.mCondition_CountIdx].FactorA, this.ConditionKey, 0);
				GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), 255, true);
				return;
			}
			if ((int)this.m_BattleHeroNum >= this.m_BattleHero.Length)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(36u), 255, true);
				return;
			}
			int j;
			for (j = 0; j < (int)this.m_BattleHeroNum; j++)
			{
				Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(this.m_BattleHeroID[j]);
				if (recordByKey.Pos < recordByKey2.Pos)
				{
					break;
				}
			}
			this.m_BattleHero[(int)this.m_BattleHeroNum].gameObject.SetActive(true);
			this.m_BattleHero[(int)this.m_BattleHeroNum].m_BtnID2 = (int)curHeroData.ID;
			for (int k = (int)this.m_BattleHeroNum; k > j; k--)
			{
				int num2 = k - 1;
				int num3 = k;
				Vector2 anchoredPosition = this.m_BattleHero[k - 1].transform.parent.GetComponent<RectTransform>().anchoredPosition;
				Vector2 anchoredPosition2 = this.m_BattleHero[k].transform.parent.GetComponent<RectTransform>().anchoredPosition;
				this.AddToMoveStack(num2, this.m_BattleHeroID[num2], anchoredPosition, anchoredPosition2, num3);
				this.m_BattleHeroID[num3] = this.m_BattleHeroID[num2];
			}
			this.m_BattleHeroID[j] = recordByKey.HeroKey;
			if (this.SelectMode != UIBattleHeroSelect._SelectMode.Condition)
			{
				GUIManager.Instance.ChangeHeroItemImg(this.m_BattleHero[j].transform, eHeroOrItem.Hero, this.m_BattleHeroID[j], curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
			}
			else
			{
				GUIManager.Instance.ChangeHeroItemImg(this.m_BattleHero[j].transform, eHeroOrItem.Hero, this.m_BattleHeroID[j], this.LevelexDate.Star, this.LevelexDate.Rank, (int)this.LevelexDate.LV);
			}
			for (int l = 0; l < this.m_BattleHeroAmins.Length; l++)
			{
				this.m_BattleHeroAmins[l].gameObject.SetActive(false);
			}
			this.m_BattleHeroAmins[j].gameObject.SetActive(true);
			this.m_BattleHero[j].gameObject.SetActive(true);
			this.m_BattleHeroNum += 1;
			this.m_Str.ClearString();
			StringManager.Instance.IntToFormat((long)((ulong)this.GetAllPower()), 1, true);
			this.m_Str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(53u));
			this.m_ScoreText.text = this.m_Str.ToString();
			this.m_ScoreText.SetAllDirty();
			this.m_ScoreText.cachedTextGenerator.Invalidate();
			this.m_ScoreText.cachedTextGeneratorForLayout.Invalidate();
			this.SetCenterText(this.m_ScorePowerImage, this.m_ScoreText, 371f);
			this.m_ScoreText2.text = this.m_Str.ToString();
			this.m_ScoreText2.SetAllDirty();
			this.m_ScoreText2.cachedTextGenerator.Invalidate();
			this.m_ScoreText2.cachedTextGeneratorForLayout.Invalidate();
			this.SetCenterText(this.m_ScorePowerImage2, this.m_ScoreText2, 292f);
			component.HIImage.color = Color.gray;
			component.CircleImage.color = Color.gray;
			component.LvOrNum.color = Color.gray;
			gameObject.transform.GetChild(1).GetComponent<Image>().gameObject.SetActive(true);
			this.bNeedCheckAstrology = true;
			return;
		}
	}

	// Token: 0x0600197A RID: 6522 RVA: 0x002B55B4 File Offset: 0x002B37B4
	private uint GetAllPower()
	{
		int num = this.m_BattleHeroID.Length;
		uint num2 = 0u;
		for (int i = 0; i < num; i++)
		{
			num2 += this.GetPower(this.m_BattleHeroID[i]);
		}
		return num2;
	}

	// Token: 0x0600197B RID: 6523 RVA: 0x002B55F0 File Offset: 0x002B37F0
	private uint GetPower(ushort heroId)
	{
		uint result = 0u;
		if (!DataManager.Instance.curHeroData.ContainsKey((uint)heroId))
		{
			return result;
		}
		CurHeroData curHeroData = DataManager.Instance.curHeroData[(uint)heroId];
		CalcAttrDataType calcAttrDataType = default(CalcAttrDataType);
		byte[] array = new byte[4];
		uint num = 0u;
		ushort[] array2 = new ushort[28];
		ushort[] array3 = new ushort[28];
		uint hp = 0u;
		calcAttrDataType.SkillLV1 = curHeroData.SkillLV[0];
		calcAttrDataType.SkillLV2 = curHeroData.SkillLV[1];
		calcAttrDataType.SkillLV3 = curHeroData.SkillLV[2];
		calcAttrDataType.SkillLV4 = curHeroData.SkillLV[3];
		for (int i = 0; i < 4; i++)
		{
			array[i] = curHeroData.SkillLV[i];
		}
		calcAttrDataType.LV = curHeroData.Level;
		calcAttrDataType.Star = curHeroData.Star;
		calcAttrDataType.Enhance = curHeroData.Enhance;
		calcAttrDataType.Equip = curHeroData.Equip;
		num = 0u;
		Array.Clear(array2, 0, array2.Length);
		BSInvokeUtil.getInstance.setCalculateHeroEquipEffect(heroId, curHeroData.Enhance, curHeroData.Equip, ref num, array2);
		Array.Clear(array3, 0, array3.Length);
		BSInvokeUtil.getInstance.setCalculateAttribute(heroId, ref calcAttrDataType, ref hp, array3);
		return BSInvokeUtil.getInstance.updateFightScore(heroId, hp, array3, array);
	}

	// Token: 0x0600197C RID: 6524 RVA: 0x002B5748 File Offset: 0x002B3948
	private void RemoveBattleHero(int index)
	{
		if (this.fightButtonTime > 0f || this.MoveBtnCount > 0)
		{
			return;
		}
		for (int i = index; i < (int)(this.m_BattleHeroNum - 1); i++)
		{
			Vector2 anchoredPosition = this.m_BattleHero[i + 1].transform.parent.GetComponent<RectTransform>().anchoredPosition;
			Vector2 anchoredPosition2 = this.m_BattleHero[i].transform.parent.GetComponent<RectTransform>().anchoredPosition;
			this.AddToMoveStack(i + 1, this.m_BattleHeroID[i + 1], anchoredPosition, anchoredPosition2, i);
			this.m_BattleHeroID[i] = this.m_BattleHeroID[i + 1];
		}
		this.m_BattleHeroNum -= 1;
		if ((int)this.m_BattleHeroNum < this.m_BattleHero.Length)
		{
			this.m_BattleHeroID[(int)this.m_BattleHeroNum] = 0;
			this.m_BattleHero[(int)this.m_BattleHeroNum].gameObject.SetActive(false);
		}
		this.m_Str.ClearString();
		StringManager.Instance.IntToFormat((long)((ulong)this.GetAllPower()), 1, true);
		this.m_Str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(53u));
		this.m_ScoreText.text = this.m_Str.ToString();
		this.m_ScoreText.SetAllDirty();
		this.m_ScoreText.cachedTextGenerator.Invalidate();
		this.m_ScoreText.cachedTextGeneratorForLayout.Invalidate();
		this.SetCenterText(this.m_ScorePowerImage, this.m_ScoreText, 371f);
		this.m_ScoreText2.text = this.m_Str.ToString();
		this.m_ScoreText2.SetAllDirty();
		this.m_ScoreText2.cachedTextGeneratorForLayout.Invalidate();
		this.m_ScoreText2.cachedTextGenerator.Invalidate();
		this.SetCenterText(this.m_ScorePowerImage2, this.m_ScoreText2, 292f);
		this.SetCenterText(this.m_ScorePowerImage, this.m_ScoreText, 371f);
		this.bNeedCheckAstrology = true;
	}

	// Token: 0x0600197D RID: 6525 RVA: 0x002B5940 File Offset: 0x002B3B40
	private void AddToMoveStack(int beginIdx, ushort heroID, Vector2 begin, Vector2 end, int endBtnIdx)
	{
		if (endBtnIdx >= 0 && endBtnIdx < 5 && beginIdx >= 0 && beginIdx < 5)
		{
			if (this.moveStack[beginIdx].bMoving)
			{
				GUIManager.Instance.AddHUDMessage("moveStack[{0}].bMoving", 255, true);
				return;
			}
			this.m_MoveBattleHero[beginIdx].gameObject.SetActive(true);
			this.m_BattleHero[beginIdx].gameObject.SetActive(false);
			CurHeroData curHeroData = DataManager.Instance.curHeroData[(uint)heroID];
			if (this.SelectMode != UIBattleHeroSelect._SelectMode.Condition)
			{
				GUIManager.Instance.ChangeHeroItemImg(this.m_MoveBattleHero[beginIdx].transform, eHeroOrItem.Hero, heroID, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
				GUIManager.Instance.ChangeHeroItemImg(this.m_BattleHero[endBtnIdx].transform, eHeroOrItem.Hero, heroID, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
			}
			else
			{
				GUIManager.Instance.ChangeHeroItemImg(this.m_MoveBattleHero[beginIdx].transform, eHeroOrItem.Hero, heroID, this.LevelexDate.Star, this.LevelexDate.Rank, (int)this.LevelexDate.LV);
				GUIManager.Instance.ChangeHeroItemImg(this.m_BattleHero[endBtnIdx].transform, eHeroOrItem.Hero, heroID, this.LevelexDate.Star, this.LevelexDate.Rank, (int)this.LevelexDate.LV);
			}
			this.m_MoveBattleHero[beginIdx].gameObject.GetComponent<RectTransform>().anchoredPosition = begin;
			this.m_BattleHero[endBtnIdx].gameObject.SetActive(false);
			this.moveStack[beginIdx].heroID = heroID;
			this.moveStack[beginIdx].begin = begin;
			this.moveStack[beginIdx].end = end;
			this.moveStack[beginIdx].battleBtnIdx = endBtnIdx;
			this.moveStack[beginIdx].bMoving = true;
			this.MoveBtnCount++;
		}
	}

	// Token: 0x0600197E RID: 6526 RVA: 0x002B5B30 File Offset: 0x002B3D30
	private void Update()
	{
		this.bMoving = false;
		for (int i = 0; i < this.moveStack.Length; i++)
		{
			if (this.moveStack[i].bMoving)
			{
				this.bMoving = true;
				Vector2 vector = Vector2.MoveTowards(this.moveStack[i].begin, this.moveStack[i].end, 2000f * Time.deltaTime);
				this.m_MoveBattleHero[i].GetComponent<RectTransform>().anchoredPosition = vector;
				this.moveStack[i].begin = vector;
				if (this.moveStack[i].begin == this.moveStack[i].end)
				{
					this.m_BattleHero[this.moveStack[i].battleBtnIdx].gameObject.SetActive(true);
					this.m_MoveBattleHero[i].gameObject.SetActive(false);
					this.moveStack[i].bMoving = false;
					this.MoveBtnCount--;
					this.bNeedCheckAstrology = true;
				}
			}
		}
		if (this.bNeedCheckAstrology)
		{
			for (int j = 0; j < this.m_BattleHeroStartImage.Length; j++)
			{
				this.m_BattleHeroStartImage[j].gameObject.SetActive(this.CheckAstrology(this.m_BattleHeroID[j]));
			}
			this.bNeedCheckAstrology = false;
		}
		if (this.fightButtonTime > 0f)
		{
			this.fightButtonTime -= Time.deltaTime;
			if (this.fightButtonTime <= 0f)
			{
				if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero || this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaAttack || this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaDefense || this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
				{
					if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero || this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
					{
						DataManager.Instance.updateBattleData();
					}
					AudioManager.Instance.LoadAndPlayBGM(BGMType.War, 1, false);
					GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MapToBattle);
					GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Expedition);
					GUIManager.Instance.HideUILock(EUILock.Normal);
					if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero)
					{
						DataManager.Instance.SetHeroBattleDataSave();
					}
					if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
					{
						DataManager.Instance.SetHero_Condition_BattleDataSave();
					}
				}
				else
				{
					if (!GUIManager.Instance.ShowUILock(EUILock.Battle))
					{
						return;
					}
					ushort data;
					byte data2;
					GameConstants.MapIDToPointCode(this.MonsterMapID, out data, out data2);
					GUIManager.Instance.HideUILock(EUILock.Normal);
					MessagePacket messagePacket = new MessagePacket(1024);
					messagePacket.Protocol = Protocol._MSG_REQUEST_SENDMONSTER;
					messagePacket.AddSeqId();
					messagePacket.Add(data);
					messagePacket.Add(data2);
					messagePacket.Add((byte)this.AttackTimes);
					for (byte b = 0; b < 5; b += 1)
					{
						messagePacket.Add(this.m_BattleHeroID[(int)b]);
					}
					messagePacket.Send(false);
				}
			}
		}
	}

	// Token: 0x0600197F RID: 6527 RVA: 0x002B5E0C File Offset: 0x002B400C
	private bool CheckMonsterRule()
	{
		DataManager instance = DataManager.Instance;
		if (DataManager.Instance.RoleAlliance.Id == 0u)
		{
			GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8341u), 255, true);
			return false;
		}
		int num = 0;
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
		for (int i = 0; i < 8; i++)
		{
			if (DataManager.Instance.MarchEventData[i].Type != EMarchEventType.EMET_Standby)
			{
				num++;
				if ((long)num == (long)((ulong)effectBaseVal))
				{
					this.m_Str2.ClearString();
					this.m_Str2.IntToFormat((long)((ulong)effectBaseVal), 1, false);
					this.m_Str2.AppendFormat(instance.mStringTable.GetStringByID(8351u));
					GUIManager.Instance.AddHUDMessage(this.m_Str2.ToString(), 255, true);
					return false;
				}
			}
		}
		Vector2 tileMapPosbySpriteID = GameConstants.getTileMapPosbySpriteID(this.MonsterMapID);
		if (DataManager.MapDataController.CheckLenght(tileMapPosbySpriteID) == 0f)
		{
			GUIManager.Instance.OpenMessageBox(instance.mStringTable.GetStringByID(3967u), instance.mStringTable.GetStringByID(119u), instance.mStringTable.GetStringByID(4034u), null, 0, 0, false, false, false, false, false);
			return false;
		}
		return true;
	}

	// Token: 0x06001980 RID: 6528 RVA: 0x002B5F5C File Offset: 0x002B415C
	public void OnScroll(RectTransform rt)
	{
	}

	// Token: 0x06001981 RID: 6529 RVA: 0x002B5F60 File Offset: 0x002B4160
	public override void ReOnOpen()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			door.ShowFightButton(this.m_FightButtonPosition + this.m_AddPositio, 200f, false, E3DButtonKind.BK_Big);
		}
	}

	// Token: 0x06001982 RID: 6530 RVA: 0x002B5FA8 File Offset: 0x002B41A8
	private e_SelecBtnState CheckCanSelectById(ushort id)
	{
		if (NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE))
		{
			return e_SelecBtnState.None;
		}
		if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaAttack || this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaDefense)
		{
			return e_SelecBtnState.None;
		}
		e_SelecBtnState result = e_SelecBtnState.None;
		DataManager instance = DataManager.Instance;
		if (this.CheckCondition_HeroTopic(id, false))
		{
			return e_SelecBtnState.Condition;
		}
		int num = 0;
		while ((long)num < (long)((ulong)instance.FightHeroCount))
		{
			if (instance.GetLeaderID() == id)
			{
				if (instance.beCaptured.nowCaptureStat == LoadCaptureState.Captured)
				{
					return e_SelecBtnState.LordJail;
				}
				if (instance.beCaptured.nowCaptureStat == LoadCaptureState.Dead)
				{
					return e_SelecBtnState.LordKilled;
				}
			}
			if (instance.FightHeroID[num] == (uint)id)
			{
				return e_SelecBtnState.Fighting;
			}
			num++;
		}
		return result;
	}

	// Token: 0x06001983 RID: 6531 RVA: 0x002B6054 File Offset: 0x002B4254
	private bool CheckAstrology(ushort heroID)
	{
		return (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaDefense || this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaAttack) && heroID != 0 && ArenaManager.Instance.CheckHeroAstrology(heroID);
	}

	// Token: 0x06001984 RID: 6532 RVA: 0x002B6084 File Offset: 0x002B4284
	private void CheckSelectHero()
	{
		for (int i = 0; i < this.m_BattleHero.Length; i++)
		{
			if (this.CheckCanSelectById(this.m_BattleHeroID[i]) == e_SelecBtnState.LordJail)
			{
				this.OnHIButtonClick(this.m_BattleHero[i]);
			}
		}
	}

	// Token: 0x06001985 RID: 6533 RVA: 0x002B60CC File Offset: 0x002B42CC
	private void SetEnemyHero()
	{
		ArenaManager instance = ArenaManager.Instance;
		if (this.m_ArenaTargetIdx >= 0 && this.m_ArenaTargetIdx < instance.m_ArenaTarget.Length)
		{
			for (int i = 0; i < instance.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData.Length; i++)
			{
				if (instance.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData[i].ID > 0)
				{
					GUIManager.Instance.ChangeHeroItemImg(this.m_BattleHeroEnemy[i].transform, eHeroOrItem.Hero, instance.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData[i].ID, instance.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData[i].Star, instance.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData[i].Rank, (int)instance.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData[i].Level);
					this.m_BattleHeroEnemy[i].gameObject.SetActive(true);
					this.m_EnemyAstrology[i].gameObject.SetActive(this.CheckAstrology(instance.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData[i].ID));
					this.m_EnemyBg[i].gameObject.SetActive(false);
				}
				else
				{
					this.m_EnemyAstrology[i].gameObject.SetActive(false);
					this.m_BattleHeroEnemy[i].gameObject.SetActive(false);
					this.m_EnemyBg[i].gameObject.SetActive(true);
				}
			}
			this.m_Str3.ClearString();
			this.m_Str3.IntToFormat((long)((ulong)instance.GetAllPower(1, (int)((byte)this.m_ArenaTargetIdx))), 1, true);
			this.m_Str3.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(53u));
			this.m_EnemyPower.text = this.m_Str3.ToString();
			this.m_EnemyPower.SetAllDirty();
			this.m_EnemyPower.cachedTextGenerator.Invalidate();
			this.m_EnemyPower.cachedTextGeneratorForLayout.Invalidate();
			this.SetCenterText(this.m_EnemyPowerIcon, this.m_EnemyPower, 195f);
		}
	}

	// Token: 0x06001986 RID: 6534 RVA: 0x002B6324 File Offset: 0x002B4524
	private void SetCenterText(Image image, UIText text, float width)
	{
		float num = 5f;
		float x = (width - (image.rectTransform.sizeDelta.x + text.preferredWidth + num)) / 2f;
		image.rectTransform.anchoredPosition = new Vector2(x, image.rectTransform.anchoredPosition.y);
		Vector2 anchoredPosition = text.ArabicFixPos(new Vector2(image.rectTransform.anchoredPosition.x + image.rectTransform.sizeDelta.x + num, text.rectTransform.anchoredPosition.y));
		text.rectTransform.anchoredPosition = anchoredPosition;
	}

	// Token: 0x06001987 RID: 6535 RVA: 0x002B63D8 File Offset: 0x002B45D8
	private void SetUIBySelectMode(UIBattleHeroSelect._SelectMode mode)
	{
		if (mode == UIBattleHeroSelect._SelectMode.ArenaDefense)
		{
			for (int i = 0; i < this.m_BattleHero.Length; i++)
			{
				Vector2 anchoredPosition = this.m_BattleHeroTf[i].GetComponent<RectTransform>().anchoredPosition;
				anchoredPosition.y -= 25f;
				this.m_BattleHeroTf[i].GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
			}
			for (int j = 0; j < this.m_BattleHeroBg.Length; j++)
			{
				Vector2 anchoredPosition = this.m_BattleHeroBg[j].GetComponent<RectTransform>().anchoredPosition;
				anchoredPosition.y -= 25f;
				this.m_BattleHeroBg[j].GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
			}
			this.m_BattleButtonImage.enabled = false;
			this.m_FightButtonText.enabled = true;
		}
		else if (mode == UIBattleHeroSelect._SelectMode.ArenaAttack)
		{
			for (int k = 0; k < this.m_BattleHeroTf.Length; k++)
			{
				this.m_BattleHeroTf[k].localScale = new Vector3(0.812f, 0.812f, 1f);
				this.m_MoveBattleHeroTf[k].localScale = new Vector3(0.812f, 0.812f, 1f);
			}
			this.m_BattleHeroTf[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(2f, 116f);
			this.m_BattleHeroTf[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-109.5f, 97f);
			this.m_BattleHeroTf[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(112.5f, 97f);
			this.m_BattleHeroTf[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(-219.5f, 78f);
			this.m_BattleHeroTf[4].GetComponent<RectTransform>().anchoredPosition = new Vector2(223.5f, 78f);
			this.m_TheEnemyPanel.gameObject.SetActive(true);
			this.m_ScoreBG.gameObject.SetActive(false);
			this.m_ScoreBG2.gameObject.SetActive(true);
			this.m_BattleButtonImage.enabled = true;
			this.m_FightButtonText.enabled = false;
			this.m_BattleHeroBg[0].gameObject.SetActive(false);
			this.m_BattleHeroBg[1].gameObject.SetActive(false);
		}
	}

	// Token: 0x06001988 RID: 6536 RVA: 0x002B6628 File Offset: 0x002B4828
	public void OnButtonDown(UIButtonHint sender)
	{
		if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition && sender.Parm1 == 4)
		{
			if (this.tmpSCD.ConditionArray[(int)sender.Parm2].ConditionID != 0)
			{
				DataManager.StageDataController.GetStageConditionString(this.m_ConditionHint, this.tmpSCD.ConditionArray[(int)sender.Parm2].ConditionID, this.tmpSCD.ConditionArray[(int)sender.Parm2].FactorA, this.tmpSCD.ConditionArray[(int)sender.Parm2].FactorB, this.ConditionKey);
			}
			else
			{
				DataManager.StageDataController.GetStageConditionString(this.m_ConditionHint, byte.MaxValue, 0, 0, 0);
			}
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.m_ConditionHint, Vector2.zero);
		}
		else
		{
			this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(19u);
			Vector2 sizeDelta;
			sizeDelta.x = this.m_HintText.rectTransform.sizeDelta.x + 20f;
			sizeDelta.y = this.m_HintText.preferredHeight + 20f;
			this.m_HintImage.rectTransform.sizeDelta = sizeDelta;
			sizeDelta.x = this.m_HintText.rectTransform.sizeDelta.x;
			sizeDelta.y = this.m_HintText.preferredHeight;
			this.m_HintText.rectTransform.sizeDelta = sizeDelta;
			if (sender.Parm1 == 1)
			{
				this.m_Hint.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 160f);
			}
			if (sender.Parm1 == 2)
			{
				this.m_Hint.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 160f);
			}
			if (sender.Parm1 == 3)
			{
				this.m_Hint.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -80f);
			}
			this.m_Hint.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001989 RID: 6537 RVA: 0x002B685C File Offset: 0x002B4A5C
	public void OnButtonUp(UIButtonHint sender)
	{
		if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition && sender.Parm1 == 4)
		{
			GUIManager.Instance.m_Hint.Hide(true);
		}
		else
		{
			this.m_Hint.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600198A RID: 6538 RVA: 0x002B68A8 File Offset: 0x002B4AA8
	public void SaveTempHeroData()
	{
		DataManager instance = DataManager.Instance;
		if (this.m_BattleHeroID == null)
		{
			return;
		}
		int num = 0;
		while (num < instance.curTempHeroData.Length && num < this.m_BattleHeroID.Length)
		{
			if (instance.curHeroData.ContainsKey((uint)this.m_BattleHeroID[num]))
			{
				instance.curTempHeroData[num] = instance.curHeroData[(uint)this.m_BattleHeroID[num]];
			}
			num++;
		}
	}

	// Token: 0x0600198B RID: 6539 RVA: 0x002B692C File Offset: 0x002B4B2C
	public bool CheckHeroRes()
	{
		bool result = true;
		ushort[] array = new ushort[10];
		DataManager instance = DataManager.Instance;
		ArenaManager instance2 = ArenaManager.Instance;
		if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero || this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
		{
			result = instance.CheckHeroBattleResourceReady(HeroFightType.HeroBattle, this.m_BattleHeroID);
		}
		else if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaAttack)
		{
			for (int i = 0; i < this.m_BattleHeroID.Length; i++)
			{
				array[i] = this.m_BattleHeroID[i];
			}
			for (int j = 0; j < instance2.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData.Length; j++)
			{
				array[j + 5] = instance2.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData[j].ID;
			}
			result = instance.CheckHeroBattleResourceReady(HeroFightType.HeorArena, array);
		}
		else if (this.SelectMode == UIBattleHeroSelect._SelectMode.Monster)
		{
			result = instance.CheckHeroBattleResourceReady(HeroFightType.MonsterBattle, this.m_BattleHeroID);
		}
		return result;
	}

	// Token: 0x0600198C RID: 6540 RVA: 0x002B6A30 File Offset: 0x002B4C30
	public void CheckCondition()
	{
		if (DataManager.StageDataController.StageDareMode(DataManager.StageDataController.currentPointID) == StageMode.Lean)
		{
			this.tmpSCD = DataManager.StageDataController.StageConditionDataTable.GetRecordByKey(this.LevelexDate.NodusOneID + (ushort)DataManager.StageDataController.currentNodus - 1);
		}
		else
		{
			this.tmpSCD = DataManager.StageDataController.StageConditionDataTable.GetRecordByKey(this.LevelexDate.NodusTwoID);
		}
		this.ConditionKey = this.tmpSCD.ConditionKey;
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < this.tmpSCD.ConditionArray.Length; i++)
		{
			if (this.tmpSCD.ConditionArray[i].ConditionID == 1 || this.tmpSCD.ConditionArray[i].ConditionID == 2 || this.tmpSCD.ConditionArray[i].ConditionID == 3)
			{
				if (this.tmpSCD.ConditionArray[i].ConditionID == 1)
				{
					this.bConditionTopic = true;
					this.tmpTopicIdx[num] = (ushort)i;
					num++;
				}
				else if (this.tmpSCD.ConditionArray[i].ConditionID == 2 && !this.bConditionCount)
				{
					this.bConditionCount = true;
					this.mCondition_CountIdx = i;
					this.tmp_C_Count = this.tmpSCD.ConditionArray[i].FactorA;
				}
				else if (this.tmpSCD.ConditionArray[i].ConditionID == 3)
				{
					this.bConditionHeroID = true;
					this.tmpHeroIdx[num2] = (ushort)i;
					num2++;
				}
			}
		}
	}

	// Token: 0x0600198D RID: 6541 RVA: 0x002B6BF0 File Offset: 0x002B4DF0
	public bool CheckCondition_HeroTopic(ushort HeroID, bool bshowmsg = false)
	{
		if (this.SelectMode != UIBattleHeroSelect._SelectMode.Condition || !this.bConditionTopic)
		{
			return false;
		}
		if (this.bConditionHeroID)
		{
			for (int i = 0; i < this.tmpHeroIdx.Length; i++)
			{
				if (this.tmpHeroIdx[i] != 0 && (int)this.tmpHeroIdx[i] < this.tmpSCD.ConditionArray.Length && this.tmpSCD.ConditionArray[(int)this.tmpHeroIdx[i]].ConditionID == 3 && this.tmpSCD.ConditionArray[(int)this.tmpHeroIdx[i]].FactorA == HeroID)
				{
					return false;
				}
			}
		}
		ArenaHeroTopic recordByKey = DataManager.Instance.ArenaHeroTopicData.GetRecordByKey(HeroID);
		for (int j = 0; j < this.tmpTopicIdx.Length; j++)
		{
			if (this.tmpSCD.ConditionArray[(int)this.tmpTopicIdx[j]].ConditionID == 1 && ((this.tmpSCD.ConditionArray[(int)this.tmpTopicIdx[j]].FactorA == 0 && (recordByKey.Value >> (int)(this.tmpSCD.ConditionArray[(int)this.tmpTopicIdx[j]].FactorB - 1) & 1u) == 1u) || (this.tmpSCD.ConditionArray[(int)this.tmpTopicIdx[j]].FactorA == 1 && (recordByKey.Value >> (int)(this.tmpSCD.ConditionArray[(int)this.tmpTopicIdx[j]].FactorB - 1) & 1u) == 0u)))
			{
				if (bshowmsg)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(10047u), 255, true);
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600198E RID: 6542 RVA: 0x002B6DCC File Offset: 0x002B4FCC
	public bool CheckCondition_HeroNum(ushort HeroNum)
	{
		return this.SelectMode == UIBattleHeroSelect._SelectMode.Condition && this.bConditionCount && HeroNum > this.tmpSCD.ConditionArray[this.mCondition_CountIdx].FactorA;
	}

	// Token: 0x0600198F RID: 6543 RVA: 0x002B6E0C File Offset: 0x002B500C
	public bool CheckCondition_HeroID()
	{
		if (this.SelectMode != UIBattleHeroSelect._SelectMode.Condition || !this.bConditionHeroID)
		{
			return false;
		}
		for (int i = 0; i < this.tmpHeroIdx.Length; i++)
		{
			if (this.tmpHeroIdx[i] != 0 && (int)this.tmpHeroIdx[i] < this.tmpSCD.ConditionArray.Length && this.tmpSCD.ConditionArray[(int)this.tmpHeroIdx[i]].ConditionID == 3)
			{
				bool flag = false;
				for (int j = 0; j < 5; j++)
				{
					if (this.m_BattleHeroID[j] != 0 && this.tmpSCD.ConditionArray[(int)this.tmpHeroIdx[i]].FactorA == this.m_BattleHeroID[j])
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					GUIManager.Instance.MsgStr.ClearString();
					DataManager.StageDataController.GetStageConditionString(GUIManager.Instance.MsgStr, this.tmpSCD.ConditionArray[(int)this.tmpHeroIdx[i]].ConditionID, this.tmpSCD.ConditionArray[(int)this.tmpHeroIdx[i]].FactorA, this.ConditionKey, 0);
					GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), 255, true);
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06001990 RID: 6544 RVA: 0x002B6F78 File Offset: 0x002B5178
	public bool CheckPreviewHeroModel(uint key, int mIdx)
	{
		if (this.SelectMode != UIBattleHeroSelect._SelectMode.Condition || !this.bPreviewHeroModel)
		{
			return false;
		}
		if (!this.bPreviewHeroModel)
		{
			return false;
		}
		e_SelecBtnState e_SelecBtnState = this.CheckCanSelectById((ushort)key);
		if (e_SelecBtnState == e_SelecBtnState.Condition)
		{
			return false;
		}
		Array.Clear(DataManager.Instance.heroBattleData, 0, DataManager.Instance.heroBattleData.Length);
		for (int i = 0; i < this.m_BattleHeroID.Length; i++)
		{
			DataManager.Instance.heroBattleData[i].HeroID = this.m_BattleHeroID[i];
		}
		GUIManager.Instance.bBackInPreviewModel = true;
		GUIManager.Instance.BackInPreviewHight = this.itemCont.anchoredPosition.y;
		CurHeroData curHeroData = DataManager.Instance.curHeroData[key];
		byte equip = (byte)((1 << (int)this.LevelexDate.Equip) - 1);
		GUIManager.Instance.OpenPreviewHeroInfo(curHeroData.ID, false, this.LevelexDate.LV, this.LevelexDate.Rank, this.LevelexDate.Star, equip, mIdx);
		return true;
	}

	// Token: 0x04004BAA RID: 19370
	private const int TextMax = 9;

	// Token: 0x04004BAB RID: 19371
	private Transform[] m_BattleHeroBg = new Transform[2];

	// Token: 0x04004BAC RID: 19372
	private Transform[] m_BattleHeroTf = new Transform[5];

	// Token: 0x04004BAD RID: 19373
	private UIHIBtn[] m_BattleHero = new UIHIBtn[5];

	// Token: 0x04004BAE RID: 19374
	private ushort[] m_BattleHeroID = new ushort[5];

	// Token: 0x04004BAF RID: 19375
	private Image[] m_BattleHeroStartImage = new Image[5];

	// Token: 0x04004BB0 RID: 19376
	private Transform[] m_MoveBattleHeroTf = new Transform[5];

	// Token: 0x04004BB1 RID: 19377
	private UIHIBtn[] m_MoveBattleHero = new UIHIBtn[5];

	// Token: 0x04004BB2 RID: 19378
	private MoveObject[] moveStack = new MoveObject[5];

	// Token: 0x04004BB3 RID: 19379
	private Animator[] m_BattleHeroAmins = new Animator[5];

	// Token: 0x04004BB4 RID: 19380
	private Image[] effectImages = new Image[5];

	// Token: 0x04004BB5 RID: 19381
	private Image[] scrollBlack = new Image[3];

	// Token: 0x04004BB6 RID: 19382
	private byte m_BattleHeroNum;

	// Token: 0x04004BB7 RID: 19383
	private UIText m_ScoreText;

	// Token: 0x04004BB8 RID: 19384
	private UIText m_ScoreText2;

	// Token: 0x04004BB9 RID: 19385
	private Image m_ScorePowerImage;

	// Token: 0x04004BBA RID: 19386
	private Image m_ScorePowerImage2;

	// Token: 0x04004BBB RID: 19387
	private UIButton m_KingSkill;

	// Token: 0x04004BBC RID: 19388
	private UIButton m_KingSkillPanel;

	// Token: 0x04004BBD RID: 19389
	private byte m_KingSkillIndex;

	// Token: 0x04004BBE RID: 19390
	public ScrollView m_HerosView;

	// Token: 0x04004BBF RID: 19391
	private UISpritesArray m_SpArray;

	// Token: 0x04004BC0 RID: 19392
	private Material frameMat;

	// Token: 0x04004BC1 RID: 19393
	private Sprite lightSprite;

	// Token: 0x04004BC2 RID: 19394
	private bool bMoving;

	// Token: 0x04004BC3 RID: 19395
	private Sprite tempSprite;

	// Token: 0x04004BC4 RID: 19396
	private ushort NeedShowFlashID;

	// Token: 0x04004BC5 RID: 19397
	private float fightButtonTime;

	// Token: 0x04004BC6 RID: 19398
	private Vector3 m_FightButtonPosition;

	// Token: 0x04004BC7 RID: 19399
	private Vector3 m_AddPositio = new Vector3(0f, -70f, -590f);

	// Token: 0x04004BC8 RID: 19400
	private int MoveBtnCount;

	// Token: 0x04004BC9 RID: 19401
	private bool bCanClickbtn;

	// Token: 0x04004BCA RID: 19402
	private int MonsterMapID;

	// Token: 0x04004BCB RID: 19403
	private int AttackTimes;

	// Token: 0x04004BCC RID: 19404
	private ushort MonsterID;

	// Token: 0x04004BCD RID: 19405
	private UIBattleHeroSelect._SelectMode SelectMode;

	// Token: 0x04004BCE RID: 19406
	private CString m_Str;

	// Token: 0x04004BCF RID: 19407
	private CString m_Str2;

	// Token: 0x04004BD0 RID: 19408
	private CString m_Str3;

	// Token: 0x04004BD1 RID: 19409
	private int mTextCount;

	// Token: 0x04004BD2 RID: 19410
	private UIText[] m_tmptext = new UIText[9];

	// Token: 0x04004BD3 RID: 19411
	private bool bNeedCheckAstrology;

	// Token: 0x04004BD4 RID: 19412
	private UIText m_FightButtonText;

	// Token: 0x04004BD5 RID: 19413
	private Transform m_Hint;

	// Token: 0x04004BD6 RID: 19414
	private Image m_HintImage;

	// Token: 0x04004BD7 RID: 19415
	private UIText m_HintText;

	// Token: 0x04004BD8 RID: 19416
	private UIText m_EnemyPower;

	// Token: 0x04004BD9 RID: 19417
	private Image m_EnemyPowerIcon;

	// Token: 0x04004BDA RID: 19418
	private UIText m_EnemyText;

	// Token: 0x04004BDB RID: 19419
	private Transform m_TheEnemyPanel;

	// Token: 0x04004BDC RID: 19420
	private UIHIBtn[] m_BattleHeroEnemy = new UIHIBtn[5];

	// Token: 0x04004BDD RID: 19421
	private Image[] m_EnemyAstrology = new Image[5];

	// Token: 0x04004BDE RID: 19422
	private Image[] m_EnemyBg = new Image[5];

	// Token: 0x04004BDF RID: 19423
	private Transform m_ScoreBG;

	// Token: 0x04004BE0 RID: 19424
	private Transform m_ScoreBG2;

	// Token: 0x04004BE1 RID: 19425
	private Image m_BattleButtonImage;

	// Token: 0x04004BE2 RID: 19426
	private int m_ArenaTargetIdx;

	// Token: 0x04004BE3 RID: 19427
	private ushort tmp_C_Count;

	// Token: 0x04004BE4 RID: 19428
	private ushort[] tmpTopicIdx = new ushort[8];

	// Token: 0x04004BE5 RID: 19429
	private bool bConditionTopic;

	// Token: 0x04004BE6 RID: 19430
	private bool bConditionCount;

	// Token: 0x04004BE7 RID: 19431
	private bool bConditionHeroID;

	// Token: 0x04004BE8 RID: 19432
	private int mCondition_CountIdx;

	// Token: 0x04004BE9 RID: 19433
	private ushort[] tmpHeroIdx = new ushort[8];

	// Token: 0x04004BEA RID: 19434
	private StageConditionData tmpSCD;

	// Token: 0x04004BEB RID: 19435
	private ushort ConditionKey;

	// Token: 0x04004BEC RID: 19436
	private LevelEX LevelexDate;

	// Token: 0x04004BED RID: 19437
	private bool bPreviewHeroModel;

	// Token: 0x04004BEE RID: 19438
	private Image[] m_Previewicon = new Image[2];

	// Token: 0x04004BEF RID: 19439
	private UIButton m_Preview;

	// Token: 0x04004BF0 RID: 19440
	private Image[] m_ConditionF = new Image[8];

	// Token: 0x04004BF1 RID: 19441
	private Image[] m_ConditionBG = new Image[8];

	// Token: 0x04004BF2 RID: 19442
	private Transform m_BattleHeroPanel;

	// Token: 0x04004BF3 RID: 19443
	private Transform m_PreviewPanel;

	// Token: 0x04004BF4 RID: 19444
	private Transform m_ConditioniconPanel;

	// Token: 0x04004BF5 RID: 19445
	private Transform[] m_ConditioniconItem = new Transform[8];

	// Token: 0x04004BF6 RID: 19446
	private UIText[] m_ConditionText = new UIText[2];

	// Token: 0x04004BF7 RID: 19447
	private Transform mChallengeTitle;

	// Token: 0x04004BF8 RID: 19448
	private Transform[] mConditionLock = new Transform[5];

	// Token: 0x04004BF9 RID: 19449
	private CString m_ConditionHint;

	// Token: 0x04004BFA RID: 19450
	private CScrollRect itemScrollRect;

	// Token: 0x04004BFB RID: 19451
	private RectTransform itemCont;

	// Token: 0x020004F9 RID: 1273
	private enum _SelectMode
	{
		// Token: 0x04004BFD RID: 19453
		Hero,
		// Token: 0x04004BFE RID: 19454
		Monster,
		// Token: 0x04004BFF RID: 19455
		ArenaDefense,
		// Token: 0x04004C00 RID: 19456
		ArenaAttack,
		// Token: 0x04004C01 RID: 19457
		Condition
	}
}
