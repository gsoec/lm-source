using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200030D RID: 781
public class UIAlliance_Mobilization : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06000FE3 RID: 4067 RVA: 0x001BC8FC File Offset: 0x001BAAFC
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.MM = MobilizationManager.Instance;
		this.AM = ActivityManager.Instance;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.GameT = base.gameObject.transform;
		this.m_Mat = this.door.LoadMaterial();
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.tmpAddCount = this.MM.RSAnimationItemID.Length / 3 + 1;
		this.Cstr_Lv = StringManager.Instance.SpawnString(30);
		this.Cstr_LvValue = StringManager.Instance.SpawnString(30);
		this.Cstr_ActivityTime = StringManager.Instance.SpawnString(30);
		this.Cstr_NowScore = StringManager.Instance.SpawnString(30);
		this.Cstr_NextScore = StringManager.Instance.SpawnString(30);
		this.Cstr_MobilizationNum = StringManager.Instance.SpawnString(30);
		this.Cstr_MissionTime = StringManager.Instance.SpawnString(30);
		this.Cstr_MissionCDTime = StringManager.Instance.SpawnString(30);
		this.Cstr_MissionCount = StringManager.Instance.SpawnString(100);
		this.Cstr_Hint = StringManager.Instance.SpawnString(200);
		this.Cstr_TimeBar = StringManager.Instance.SpawnString(30);
		this.Cstr_RewardNum = StringManager.Instance.SpawnString(200);
		this.Cstr_RankHint = StringManager.Instance.SpawnString(200);
		this.Cstr_Result = StringManager.Instance.SpawnString(200);
		this.Cstr_RankResult = StringManager.Instance.SpawnString(300);
		this.Cstr_GetRewardTime = StringManager.Instance.SpawnString(30);
		this.Cstr_Info[0] = StringManager.Instance.SpawnString(100);
		this.Cstr_Info[1] = StringManager.Instance.SpawnString(30);
		this.Cstr_BonusReward = StringManager.Instance.SpawnString(30);
		this.Cstr_BonusRewardDone = StringManager.Instance.SpawnString(100);
		this.Cstr_BonusHint = StringManager.Instance.SpawnString(200);
		this.Cstr_BonusRecord[0] = StringManager.Instance.SpawnString(200);
		this.Cstr_BonusRecord[1] = StringManager.Instance.SpawnString(200);
		this.Cstr_BonusRecord[2] = StringManager.Instance.SpawnString(200);
		for (int i = 0; i < 3; i++)
		{
			this.ItemKind_T[i] = new Transform[9];
			this.btn_ItemSelect[i] = new UIButton[3];
			this.btn_Delete[i] = new UIButton[3];
			this.Img_ItemFrame[i] = new Image[3];
			this.Img_ItemIcon[i] = new Image[3];
			this.Img_ItemP1Icon[i] = new Image[3];
			this.Img_ItemP1Mission[i] = new Image[3];
			this.Img_ItemP1Score[i] = new Image[3];
			this.Img_ItemP1OK[i] = new Image[3];
			this.text_ItemTime[i] = new UIText[3];
			this.text_ItemValue[i] = new UIText[3];
			this.text_ItemP1Score[i] = new UIText[3];
			this.text_ItemNoMission[i] = new UIText[3];
			this.Cstr_ItemTime[i] = new CString[3];
			this.Cstr_ItemValue[i] = new CString[3];
			for (int j = 0; j < 3; j++)
			{
				this.Cstr_ItemTime[i][j] = StringManager.Instance.SpawnString(30);
				this.Cstr_ItemValue[i][j] = StringManager.Instance.SpawnString(30);
			}
		}
		this.Tmp = this.GameT.GetChild(0);
		Transform child = this.Tmp.GetChild(0).GetChild(3);
		this.Img_TitleBG = child.GetComponent<Image>();
		if (this.DM.RoleAlliance.AMRank > 0 && (int)(this.DM.RoleAlliance.AMRank + 3) < this.SArray.m_Sprites.Length)
		{
			this.Img_TitleBG.sprite = this.SArray.m_Sprites[(int)(this.DM.RoleAlliance.AMRank + 3)];
		}
		this.Img_TitleBG.gameObject.SetActive(true);
		child = this.Tmp.GetChild(0).GetChild(3).GetChild(0);
		this.text_Title = child.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.text = this.DM.mStringTable.GetStringByID(1339u);
		child = this.Tmp.GetChild(0).GetChild(4);
		this.btn_I = child.GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_I.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_I.m_Handler = this;
		this.btn_I.m_BtnID1 = 1;
		this.btn_I.m_EffectType = e_EffectType.e_Scale;
		this.btn_I.transition = Selectable.Transition.None;
		child = this.Tmp.GetChild(0).GetChild(5);
		this.Img_LBG = child.GetComponent<Image>();
		child = this.Tmp.GetChild(0).GetChild(6);
		this.Img_AllianceRankBG = child.GetComponent<Image>();
		this.GUIM.SetAllyRankImage(this.Img_AllianceRankBG, this.DM.RoleAlliance.AMRank);
		this.Img_AllianceRankBG.gameObject.SetActive(true);
		child = this.Tmp.GetChild(0).GetChild(6).GetChild(0);
		this.btn_RankHint = child.GetComponent<UIButton>();
		this.btn_RankHint.m_Handler = this;
		this.btn_RankHint.m_BtnID1 = 13;
		UIButtonHint uibuttonHint = this.btn_RankHint.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		child = this.Tmp.GetChild(1);
		this.Img_ActivityTime = child.GetComponent<Image>();
		this.Img_ActivityTime.gameObject.SetActive(false);
		child = this.Tmp.GetChild(1).GetChild(0);
		this.Img_HintBG = child.GetComponent<Image>();
		child = this.Tmp.GetChild(1).GetChild(0).GetChild(0);
		this.btn_Hint = child.GetComponent<UIButton>();
		this.btn_Hint.m_Handler = this;
		this.btn_Hint.m_BtnID1 = 4;
		this.btn_Hint.m_EffectType = e_EffectType.e_Scale;
		this.btn_Hint.transition = Selectable.Transition.None;
		UIButtonHint uibuttonHint2 = this.btn_Hint.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint2.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint2.m_Handler = this;
		child = this.Tmp.GetChild(8);
		this.Img_Hint = child.GetComponent<Image>();
		child = this.Tmp.GetChild(8).GetChild(0);
		this.text_Hint = child.GetComponent<UIText>();
		this.text_Hint.font = this.TTFont;
		uibuttonHint2.ControlFadeOut = this.Img_Hint.gameObject;
		this.Cstr_Hint.ClearString();
		this.Cstr_Hint.IntToFormat((long)this.MM.involvedMember, 1, false);
		this.Cstr_Hint.AppendFormat(this.DM.mStringTable.GetStringByID(1341u));
		this.text_Hint.text = this.Cstr_Hint.ToString();
		this.text_Hint.SetAllDirty();
		this.text_Hint.cachedTextGenerator.Invalidate();
		this.text_Hint.cachedTextGeneratorForLayout.Invalidate();
		this.text_Hint.rectTransform.sizeDelta = new Vector2(this.text_Hint.rectTransform.sizeDelta.x, this.text_Hint.preferredHeight + 1f);
		this.Img_Hint.rectTransform.sizeDelta = new Vector2(this.Img_Hint.rectTransform.sizeDelta.x, this.text_Hint.preferredHeight + 11f);
		child = this.Tmp.GetChild(1).GetChild(0).GetChild(1);
		this.text_MobilizationNum = child.GetComponent<UIText>();
		this.text_MobilizationNum.font = this.TTFont;
		this.Cstr_MobilizationNum.ClearString();
		this.Cstr_MobilizationNum.IntToFormat((long)this.MM.involvedMember, 1, false);
		this.Cstr_MobilizationNum.AppendFormat(this.DM.mStringTable.GetStringByID(1340u));
		this.text_MobilizationNum.text = this.Cstr_MobilizationNum.ToString();
		this.text_MobilizationNum.SetAllDirty();
		this.text_MobilizationNum.cachedTextGenerator.Invalidate();
		child = this.Tmp.GetChild(1).GetChild(1).GetChild(0);
		this.Img_LvBar_RT = child.GetComponent<RectTransform>();
		this.Img_LvBar_RT.sizeDelta = new Vector2(214f, this.Img_LvBar_RT.sizeDelta.y);
		child = this.Tmp.GetChild(1).GetChild(1).GetChild(1);
		this.Img_LVMax = child.GetComponent<Image>();
		child = this.Tmp.GetChild(1).GetChild(1).GetChild(2);
		this.Img_Bar[0] = child.GetComponent<Image>();
		child = this.Tmp.GetChild(1).GetChild(1).GetChild(3);
		this.Img_Bar[1] = child.GetComponent<Image>();
		child = this.Tmp.GetChild(1).GetChild(1).GetChild(4);
		this.text_LvValue = child.GetComponent<UIText>();
		this.text_LvValue.font = this.TTFont;
		child = this.Tmp.GetChild(1).GetChild(2);
		child = this.Tmp.GetChild(1).GetChild(2).GetChild(0);
		this.text_Lv = child.GetComponent<UIText>();
		this.text_Lv.font = this.TTFont;
		this.Cstr_Lv.ClearString();
		this.text_Lv.text = this.Cstr_Lv.ToString();
		this.text_Lv.SetAllDirty();
		this.text_Lv.cachedTextGenerator.Invalidate();
		child = this.Tmp.GetChild(1).GetChild(3);
		this.btn_Reward = child.GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_Reward.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_Reward.m_Handler = this;
		this.btn_Reward.m_BtnID1 = 10;
		this.btn_Reward.m_EffectType = e_EffectType.e_Scale;
		this.btn_Reward.transition = Selectable.Transition.None;
		child = this.Tmp.GetChild(1).GetChild(4);
		this.btn_Reward2 = child.GetComponent<UIButton>();
		this.btn_Reward2.m_Handler = this;
		this.btn_Reward2.m_BtnID1 = 10;
		for (int k = 0; k < 2; k++)
		{
			child = this.Tmp.GetChild(1).GetChild(k + 5);
			this.text_Time[k] = child.GetComponent<UIText>();
			this.text_Time[k].font = this.TTFont;
			child = this.Tmp.GetChild(1).GetChild(k + 7);
			this.text_NowScore[k] = child.GetComponent<UIText>();
			this.text_NowScore[k].font = this.TTFont;
			child = this.Tmp.GetChild(1).GetChild(k + 9);
			this.text_NextScore[k] = child.GetComponent<UIText>();
			this.text_NextScore[k].font = this.TTFont;
		}
		this.text_Time[0].text = this.DM.mStringTable.GetStringByID(8110u);
		this.Cstr_ActivityTime.ClearString();
		if (this.AM.AllyMobilizationData.EventCountTime > 86400L)
		{
			this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime / 86400L, 1, false);
			this.Cstr_ActivityTime.AppendFormat("{0}d");
		}
		else
		{
			this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime / 3600L, 2, false);
			this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime % 3600L / 60L, 2, false);
			this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime % 60L, 2, false);
			this.Cstr_ActivityTime.AppendFormat("{0}:{1}:{2}");
		}
		this.text_Time[1].text = this.Cstr_ActivityTime.ToString();
		this.text_Time[1].SetAllDirty();
		this.text_Time[1].cachedTextGenerator.Invalidate();
		this.text_NowScore[0].text = this.DM.mStringTable.GetStringByID(8116u);
		this.Cstr_NowScore.ClearString();
		StringManager.IntToStr(this.Cstr_NowScore, (long)((ulong)this.MM.AMScore), 1, true);
		this.text_NowScore[1].text = this.Cstr_NowScore.ToString();
		this.text_NowScore[1].SetAllDirty();
		this.text_NowScore[1].cachedTextGenerator.Invalidate();
		this.text_NextScore[0].text = this.DM.mStringTable.GetStringByID(8117u);
		this.Cstr_NextScore.ClearString();
		this.tmpItemNum = (int)this.DM.RoleAlliance.AMMaxDegree;
		if ((int)this.MM.AMCompleteDegree < this.tmpItemNum)
		{
			StringManager.IntToStr(this.Cstr_NextScore, (long)((ulong)(this.MM.CompleteScore - this.MM.AMScore)), 1, true);
		}
		else
		{
			StringManager.IntToStr(this.Cstr_NextScore, 0L, 1, true);
		}
		this.text_NextScore[1].text = this.Cstr_NextScore.ToString();
		this.text_NextScore[1].SetAllDirty();
		this.text_NextScore[1].cachedTextGenerator.Invalidate();
		this.Cstr_Lv.ClearString();
		StringManager.IntToStr(this.Cstr_Lv, (long)this.MM.AMCompleteDegree, 1, false);
		this.text_Lv.text = this.Cstr_Lv.ToString();
		this.text_Lv.SetAllDirty();
		this.text_Lv.cachedTextGenerator.Invalidate();
		this.Cstr_LvValue.ClearString();
		if ((int)this.MM.AMCompleteDegree == this.tmpItemNum)
		{
			this.mMDData = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex((int)(this.MM.AMCompleteDegree - 1));
			StringManager.IntToStr(this.Cstr_LvValue, (long)((ulong)this.mMDData.MissionDegreeScore), 1, true);
			this.text_LvValue.color = new Color(1f, 0.945f, 0.204f);
		}
		else
		{
			StringManager.IntToStr(this.Cstr_LvValue, (long)((ulong)this.MM.CompleteScore), 1, true);
		}
		this.text_LvValue.text = this.Cstr_LvValue.ToString();
		this.text_LvValue.SetAllDirty();
		this.text_LvValue.cachedTextGenerator.Invalidate();
		if (this.MM.CompleteScore != 0u)
		{
			if (this.MM.AMCompleteDegree == 0)
			{
				this.Img_LvBar_RT.sizeDelta = new Vector2((float)(214.0 * (this.MM.AMScore / this.MM.CompleteScore)), this.Img_LvBar_RT.sizeDelta.y);
				this.Img_Bar[0].rectTransform.anchoredPosition = new Vector2(11.5f + (float)(214.0 * (this.MM.AMScore / this.MM.CompleteScore)), this.Img_Bar[0].rectTransform.anchoredPosition.y);
			}
			else
			{
				this.mMDData = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex((int)(this.MM.AMCompleteDegree - 1));
				if (this.mMDData.MissionDegreeScore == this.MM.AMScore)
				{
					this.Img_LvBar_RT.sizeDelta = new Vector2(0f, this.Img_LvBar_RT.sizeDelta.y);
					this.Img_Bar[0].rectTransform.anchoredPosition = new Vector2(11.5f, this.Img_Bar[0].rectTransform.anchoredPosition.y);
				}
				else
				{
					this.Img_LvBar_RT.sizeDelta = new Vector2((float)(214.0 * ((this.MM.AMScore - this.mMDData.MissionDegreeScore) / (this.MM.CompleteScore - this.mMDData.MissionDegreeScore))), this.Img_LvBar_RT.sizeDelta.y);
					this.Img_Bar[0].rectTransform.anchoredPosition = new Vector2(11.5f + 214f * (float)((this.MM.AMScore - this.mMDData.MissionDegreeScore) / (this.MM.CompleteScore - this.mMDData.MissionDegreeScore)), this.Img_Bar[0].rectTransform.anchoredPosition.y);
				}
			}
		}
		else
		{
			this.Img_LvBar_RT.sizeDelta = new Vector2(0f, this.Img_LvBar_RT.sizeDelta.y);
		}
		if ((int)this.MM.AMCompleteDegree == this.tmpItemNum)
		{
			this.Img_LVMax.gameObject.SetActive(true);
			this.Img_LvBar_RT.sizeDelta = new Vector2(214f, this.Img_LvBar_RT.sizeDelta.y);
			this.Img_Bar[0].rectTransform.anchoredPosition = new Vector2(225.5f, this.Img_Bar[0].rectTransform.anchoredPosition.y);
		}
		child = this.Tmp.GetChild(2);
		this.Img_ActivityEnd = child.GetComponent<Image>();
		child = this.Tmp.GetChild(2).GetChild(0);
		this.Img_RewardBG[0] = child.GetComponent<Image>();
		child = this.Tmp.GetChild(2).GetChild(1);
		this.Img_RewardBG[1] = child.GetComponent<Image>();
		child = this.Tmp.GetChild(2).GetChild(2);
		this.btn_GetReward = child.GetComponent<UIButton>();
		this.btn_GetReward.m_Handler = this;
		this.btn_GetReward.m_BtnID1 = 11;
		this.btn_GetReward.m_EffectType = e_EffectType.e_Scale;
		this.btn_GetReward.transition = Selectable.Transition.None;
		child = this.Tmp.GetChild(2).GetChild(2).GetChild(0);
		this.Img_GetReward = child.GetComponent<Image>();
		child = this.Tmp.GetChild(2).GetChild(2).GetChild(1);
		this.text_GetReward = child.GetComponent<UIText>();
		this.text_GetReward.font = this.TTFont;
		this.text_GetReward.text = this.DM.mStringTable.GetStringByID(776u);
		child = this.Tmp.GetChild(2).GetChild(3);
		this.Img_GetRewardTime = child.GetComponent<Image>();
		child = this.Tmp.GetChild(2).GetChild(3).GetChild(0);
		this.text_GetRewardTime = child.GetComponent<UIText>();
		this.text_GetRewardTime.font = this.TTFont;
		this.Cstr_GetRewardTime.ClearString();
		long num = 0L;
		if (this.AM.AllyMobilizationData.EventState == EActivityState.EAS_ReplayRanking)
		{
			num = this.AM.AllyMobilizationData.EventCountTime;
		}
		if (num < 0L)
		{
			num = 0L;
		}
		if (num > 86400L)
		{
			this.Cstr_GetRewardTime.IntToFormat(num / 86400L, 1, false);
			this.Cstr_GetRewardTime.AppendFormat("{0}d");
		}
		else
		{
			this.Cstr_GetRewardTime.IntToFormat(num / 3600L, 2, false);
			this.Cstr_GetRewardTime.IntToFormat(num % 3600L / 60L, 2, false);
			this.Cstr_GetRewardTime.IntToFormat(num % 60L, 2, false);
			this.Cstr_GetRewardTime.AppendFormat("{0}:{1}:{2}");
		}
		this.text_GetRewardTime.text = this.Cstr_GetRewardTime.ToString();
		this.text_GetRewardTime.SetAllDirty();
		this.text_GetRewardTime.cachedTextGenerator.Invalidate();
		child = this.Tmp.GetChild(2).GetChild(4);
		this.Img_RewardOK = child.GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_RewardOK.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		child = this.Tmp.GetChild(2).GetChild(4).GetChild(0);
		this.text_RewardOK = child.GetComponent<UIText>();
		this.text_RewardOK.font = this.TTFont;
		this.text_RewardOK.text = this.DM.mStringTable.GetStringByID(7012u);
		child = this.Tmp.GetChild(2).GetChild(5);
		this.text_AllianceReward = child.GetComponent<UIText>();
		this.text_AllianceReward.font = this.TTFont;
		this.text_AllianceReward.text = this.DM.mStringTable.GetStringByID(747u);
		child = this.Tmp.GetChild(2).GetChild(6);
		this.text_RewardTitle = child.GetComponent<UIText>();
		this.text_RewardTitle.font = this.TTFont;
		this.text_RewardTitle.text = this.DM.mStringTable.GetStringByID(1371u);
		child = this.Tmp.GetChild(2).GetChild(7);
		this.text_RewardNum = child.GetComponent<UIText>();
		this.text_RewardNum.font = this.TTFont;
		this.text_RewardNum.text = this.DM.mStringTable.GetStringByID(1594u);
		child = this.Tmp.GetChild(2).GetChild(8);
		this.text_Result = child.GetComponent<UIText>();
		this.text_Result.font = this.TTFont;
		child = this.Tmp.GetChild(2).GetChild(9);
		this.btn_Rank_World = child.GetComponent<UIButton>();
		this.btn_Rank_World.m_Handler = this;
		this.btn_Rank_World.m_BtnID1 = 20;
		this.btn_Rank_World.m_EffectType = e_EffectType.e_Scale;
		this.btn_Rank_World.transition = Selectable.Transition.None;
		if (this.GUIM.IsArabic)
		{
			this.btn_Rank_World.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		if (this.DM.RoleAlliance.AMRank == 4)
		{
			this.btn_Rank_World.gameObject.SetActive(true);
		}
		child = this.Tmp.GetChild(3);
		this.Img_MissionBG = child.GetComponent<Image>();
		this.Kind_T[0] = this.Tmp.GetChild(3).GetChild(0);
		child = this.Kind_T[0].GetChild(0);
		this.text_Kind = child.GetComponent<UIText>();
		this.text_Kind.font = this.TTFont;
		child = this.Kind_T[0].GetChild(1);
		this.text_Kind1 = child.GetComponent<UIText>();
		this.text_Kind1.font = this.TTFont;
		this.Kind_T[1] = this.Tmp.GetChild(3).GetChild(1);
		child = this.Kind_T[1].GetChild(0).GetChild(0);
		this.Img_Mission = child.GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_Mission.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.Img_Mission.material = this.GUIM.GetLeagueGO_iconMaterial();
		child = this.Kind_T[1].GetChild(1);
		this.Img_MissionKind = child.GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_MissionKind.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.Img_MissionKind.material = this.GUIM.GetFrameMaterial();
		child = this.Kind_T[1].GetChild(2);
		this.Img_MissionScore = child.GetComponent<Image>();
		child = this.Kind_T[1].GetChild(2).GetChild(0);
		this.text_Info[2] = child.GetComponent<UIText>();
		this.text_Info[2].font = this.TTFont;
		child = this.Kind_T[1].GetChild(3);
		this.Img_MissionTime = child.GetComponent<Image>();
		child = this.Kind_T[1].GetChild(3).GetChild(0);
		this.text_MissionTime = child.GetComponent<UIText>();
		this.text_MissionTime.font = this.TTFont;
		child = this.Kind_T[1].GetChild(4);
		this.btn_Start = child.GetComponent<UIButton>();
		this.btn_Start.m_Handler = this;
		this.btn_Start.m_BtnID1 = 6;
		this.btn_Start.m_EffectType = e_EffectType.e_Scale;
		this.btn_Start.transition = Selectable.Transition.None;
		child = this.Kind_T[1].GetChild(4).GetChild(0);
		this.text_Start = child.GetComponent<UIText>();
		this.text_Start.font = this.TTFont;
		this.text_Start.text = this.DM.mStringTable.GetStringByID(1541u);
		child = this.Kind_T[1].GetChild(5);
		this.btn_Report = child.GetComponent<UIButton>();
		this.btn_Report.m_Handler = this;
		this.btn_Report.m_BtnID1 = 7;
		this.btn_Report.m_EffectType = e_EffectType.e_Scale;
		this.btn_Report.transition = Selectable.Transition.None;
		child = this.Kind_T[1].GetChild(5).GetChild(0);
		this.Img_Report = child.GetComponent<Image>();
		child = this.Kind_T[1].GetChild(5).GetChild(1);
		this.text_Report = child.GetComponent<UIText>();
		this.text_Report.font = this.TTFont;
		this.text_Report.text = this.DM.mStringTable.GetStringByID(1377u);
		child = this.Kind_T[1].GetChild(6);
		this.btn_GiveUp = child.GetComponent<UIButton>();
		this.btn_GiveUp.m_Handler = this;
		this.btn_GiveUp.m_BtnID1 = 12;
		this.btn_GiveUp.m_EffectType = e_EffectType.e_Scale;
		this.btn_GiveUp.transition = Selectable.Transition.None;
		child = this.Kind_T[1].GetChild(6).GetChild(0);
		this.text_GiveUp = child.GetComponent<UIText>();
		this.text_GiveUp.font = this.TTFont;
		this.text_GiveUp.text = this.DM.mStringTable.GetStringByID(5880u);
		child = this.Kind_T[1].GetChild(7);
		this.Img_Missionstatus = child.GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_Missionstatus.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		child = this.Kind_T[1].GetChild(7).GetChild(0);
		this.text_Missionstatus = child.GetComponent<UIText>();
		this.text_Missionstatus.font = this.TTFont;
		child = this.Kind_T[1].GetChild(8).GetChild(0);
		this.Img_MissionBar_RT = child.GetComponent<RectTransform>();
		this.Img_MissionBar_RT.sizeDelta = new Vector2(0f, this.Img_MissionBar_RT.sizeDelta.y);
		child = this.Kind_T[1].GetChild(8).GetChild(1);
		this.text_TimeBar = child.GetComponent<UIText>();
		this.text_TimeBar.font = this.TTFont;
		child = this.Kind_T[1].GetChild(9);
		this.Img_MissionCDTime = child.GetComponent<Image>();
		for (int l = 0; l < 2; l++)
		{
			child = this.Kind_T[1].GetChild(9).GetChild(l);
			this.text_MissionCDTime[l] = child.GetComponent<UIText>();
			this.text_MissionCDTime[l].font = this.TTFont;
		}
		this.text_MissionCDTime[0].text = this.DM.mStringTable.GetStringByID(1347u);
		for (int m = 0; m < 2; m++)
		{
			child = this.Kind_T[1].GetChild(10 + m);
			this.text_Info[m] = child.GetComponent<UIText>();
			this.text_Info[m].font = this.TTFont;
		}
		child = this.Tmp.GetChild(3).GetChild(2);
		this.m_ScrollPanel = child.GetComponent<ScrollPanel>();
		child = this.Tmp.GetChild(3).GetChild(3);
		Image component2;
		UIText component3;
		for (int n = 0; n < 3; n++)
		{
			Transform child2 = child.GetChild(n);
			UIButton component = child2.GetComponent<UIButton>();
			component.m_Handler = this;
			component.m_BtnID1 = 3;
			child2 = child.GetChild(n).GetChild(0).GetChild(0).GetChild(0).GetChild(0);
			component2 = child2.GetComponent<Image>();
			if (this.GUIM.IsArabic)
			{
				component2.gameObject.AddComponent<ArabicItemTextureRot>();
			}
			component2.material = this.GUIM.GetLeagueGO_iconMaterial();
			child2 = child.GetChild(n).GetChild(0).GetChild(0).GetChild(2).GetChild(0);
			component3 = child2.GetComponent<UIText>();
			component3.font = this.TTFont;
			child2 = child.GetChild(n).GetChild(0).GetChild(0).GetChild(3);
			component2 = child2.GetComponent<Image>();
			if (this.GUIM.IsArabic)
			{
				component2.gameObject.AddComponent<ArabicItemTextureRot>();
			}
			child2 = child.GetChild(n).GetChild(0).GetChild(1);
			component3 = child2.GetComponent<UIText>();
			component3.font = this.TTFont;
			component3.text = this.DM.mStringTable.GetStringByID(1343u);
			child2 = child.GetChild(n).GetChild(0).GetChild(2);
			component3 = child2.GetComponent<UIText>();
			component3.font = this.TTFont;
			component3.text = this.DM.mStringTable.GetStringByID(1342u);
			child2 = child.GetChild(n).GetChild(1).GetChild(1);
			component = child2.GetComponent<UIButton>();
			component.m_Handler = this;
			component.m_BtnID1 = 2;
			component.m_EffectType = e_EffectType.e_Scale;
			component.transition = Selectable.Transition.None;
			child2 = child.GetChild(n).GetChild(1).GetChild(2).GetChild(0);
			component2 = child2.GetComponent<Image>();
			if (this.GUIM.IsArabic)
			{
				component2.gameObject.AddComponent<ArabicItemTextureRot>();
			}
			component2.material = this.GUIM.GetLeagueGO_iconMaterial();
			child2 = child.GetChild(n).GetChild(1).GetChild(3).GetChild(0);
			component3 = child2.GetComponent<UIText>();
			component3.font = this.TTFont;
			child2 = child.GetChild(n).GetChild(2);
			component2 = child2.GetComponent<Image>();
			component2.color = Color.gray;
			child2 = child.GetChild(n).GetChild(2).GetChild(1);
			component3 = child2.GetComponent<UIText>();
			component3.font = this.TTFont;
		}
		this.tmplist.Clear();
		for (int num2 = 0; num2 < 7; num2++)
		{
			this.tmplist.Add(224f);
		}
		this.m_ScrollPanel.IntiScrollPanel(365f, 0f, 0f, this.tmplist, 3, this);
		this.m_ItemConet = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
		this.m_ScrollPanel.GoTo(this.MM.mMobilizationScroll, this.MM.mMobilizationScroll_Y);
		child = this.Tmp.GetChild(4).GetChild(2);
		this.btn_Add = child.GetComponent<UIButton>();
		this.btn_Add.m_Handler = this;
		this.btn_Add.m_BtnID1 = 5;
		this.btn_Add.m_EffectType = e_EffectType.e_Scale;
		this.btn_Add.transition = Selectable.Transition.None;
		child = this.Tmp.GetChild(4).GetChild(3);
		this.text_MissionCount = child.GetComponent<UIText>();
		this.text_MissionCount.font = this.TTFont;
		this.Cstr_MissionCount.ClearString();
		this.Cstr_MissionCount.IntToFormat((long)this.MM.availableMission, 1, true);
		this.Cstr_MissionCount.AppendFormat(this.DM.mStringTable.GetStringByID(1345u));
		this.text_MissionCount.text = this.Cstr_MissionCount.ToString();
		this.text_MissionCount.gameObject.SetActive(false);
		child = this.Tmp.GetChild(4).GetChild(4);
		this.text_Empty = child.GetComponent<UIText>();
		this.text_Empty.font = this.TTFont;
		child = this.Tmp.GetChild(4).GetChild(5);
		this.text_Rewardstr = child.GetComponent<UIText>();
		this.text_Rewardstr.font = this.TTFont;
		this.text_Rewardstr.text = this.DM.mStringTable.GetStringByID(8119u);
		child = this.Tmp.GetChild(4).GetChild(6);
		this.text_Resultstr = child.GetComponent<UIText>();
		this.text_Resultstr.font = this.TTFont;
		this.text_Resultstr.text = this.DM.mStringTable.GetStringByID(1021u);
		child = this.Tmp.GetChild(5);
		this.btn_Rank1 = child.GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_Rank1.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_Rank1.m_Handler = this;
		this.btn_Rank1.m_BtnID1 = 8;
		this.btn_Rank1.m_EffectType = e_EffectType.e_Scale;
		this.btn_Rank1.transition = Selectable.Transition.None;
		child = this.Tmp.GetChild(6);
		this.btn_Rank2 = child.GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_Rank2.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_Rank2.m_Handler = this;
		this.btn_Rank2.m_BtnID1 = 9;
		this.btn_Rank2.m_EffectType = e_EffectType.e_Scale;
		this.btn_Rank2.transition = Selectable.Transition.None;
		this.Img_MoreRewards = this.Tmp.GetChild(7).GetComponent<Image>();
		this.Img_Bouns_Light = this.Tmp.GetChild(11).GetChild(0).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_Bouns_Light.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		component2 = this.GameT.GetChild(1).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close_base");
		component2.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			component2.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(1).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.m_Mat;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.btn_Bonus = this.Tmp.GetChild(10).GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_Bonus.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_Bonus.m_Handler = this;
		this.btn_Bonus.m_BtnID1 = 14;
		this.btn_Bonus.m_EffectType = e_EffectType.e_Scale;
		this.btn_Bonus.transition = Selectable.Transition.None;
		this.Img_BonusAlert = this.Tmp.GetChild(10).GetChild(0).GetComponent<Image>();
		this.btn_Bonus2 = this.Tmp.GetChild(11).GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_Bonus2.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_Bonus2.m_Handler = this;
		this.btn_Bonus2.m_BtnID1 = 14;
		this.btn_Bonus2.m_EffectType = e_EffectType.e_Scale;
		this.btn_Bonus2.transition = Selectable.Transition.None;
		this.Tmp_Bonus = this.GameT.GetChild(2);
		this.Img_BounsBG = this.GameT.GetChild(2).GetComponent<Image>();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.Img_BounsBG.rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, this.Img_BounsBG.rectTransform.offsetMin.y);
			this.Img_BounsBG.rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, this.Img_BounsBG.rectTransform.offsetMax.y);
		}
		HelperUIButton helperUIButton = this.Tmp_Bonus.GetChild(0).gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID1 = 15;
		this.btn_BonusReward = this.Tmp_Bonus.GetChild(1).GetChild(0).GetComponent<UIButton>();
		this.btn_BonusReward.m_Handler = this;
		this.btn_BonusReward.m_BtnID1 = 16;
		this.btn_BonusReward.m_EffectType = e_EffectType.e_Scale;
		this.btn_BonusReward.transition = Selectable.Transition.None;
		this.btn_BonusReward2 = this.Tmp_Bonus.GetChild(1).GetChild(7).GetComponent<UIButton>();
		this.btn_BonusReward2.m_Handler = this;
		this.btn_BonusReward2.m_BtnID1 = 16;
		this.btn_BonusReward2.m_EffectType = e_EffectType.e_Scale;
		this.btn_BonusReward2.transition = Selectable.Transition.None;
		this.Img_BonusBtn_Light = this.Tmp_Bonus.GetChild(1).GetChild(7).GetChild(0).GetComponent<Image>();
		this.text_BonusGet = this.Tmp_Bonus.GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_BonusGet.font = this.TTFont;
		this.text_BonusGet.text = this.DM.mStringTable.GetStringByID(7671u);
		this.text_BonusGet2 = this.Tmp_Bonus.GetChild(1).GetChild(7).GetChild(1).GetComponent<UIText>();
		this.text_BonusGet2.font = this.TTFont;
		this.text_BonusGet2.text = this.DM.mStringTable.GetStringByID(1520u);
		this.text_BonusDone = this.Tmp_Bonus.GetChild(1).GetChild(6).GetComponent<UIText>();
		this.text_BonusDone.font = this.TTFont;
		this.Cstr_BonusRewardDone.ClearString();
		this.Cstr_BonusRewardDone.StringToFormat(this.DM.mStringTable.GetStringByID(7012u));
		this.Cstr_BonusRewardDone.AppendFormat("<color=#4DDA65FF>{0}</color>");
		this.text_BonusDone.text = this.Cstr_BonusRewardDone.ToString();
		this.text_BonusDone.SetAllDirty();
		this.text_BonusDone.cachedTextGenerator.Invalidate();
		this.Img_BonusHint = this.Tmp_Bonus.GetChild(3).GetComponent<Image>();
		this.text_BonusHint = this.Tmp_Bonus.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.text_BonusHint.font = this.TTFont;
		this.text_BonusHint.text = string.Empty;
		this.text_BonusHint.SetAllDirty();
		this.text_BonusHint.cachedTextGenerator.Invalidate();
		for (int num3 = 0; num3 < 3; num3++)
		{
			this.bonusHint[num3] = new BonusHint();
		}
		this.bonusHint[0].btn_Bonus = this.Tmp_Bonus.GetChild(1).GetChild(1).GetChild(0).GetComponent<UIButton>();
		this.bonusHint[0].btn_Bonus.m_Handler = this;
		this.bonusHint[0].btn_Bonus.m_BtnID1 = 17;
		if (this.GUIM.IsArabic)
		{
			this.bonusHint[0].btn_Bonus.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.bonusHint[0].btn_Bonus.image.material = this.GUIM.GetLeagueGO_iconMaterial();
		this.bonusHint[0].btn_Bonus.m_EffectType = e_EffectType.e_Normal;
		this.bonusHint[0].btn_Bonus.transition = Selectable.Transition.None;
		uibuttonHint2 = this.bonusHint[0].btn_Bonus.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint2.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint2.m_Handler = this;
		uibuttonHint2.ControlFadeOut = this.Img_BonusHint.gameObject;
		this.bonusHint[0].Img_Done = this.Tmp_Bonus.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.bonusHint[0].Img_Done.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		else
		{
			this.bonusHint[0].Img_Done.rectTransform.localScale = new Vector3(1f, 1f, 1f);
		}
		this.bonusHint[0].Img_Done.gameObject.SetActive(false);
		this.bonusHint[0].text_Record = this.Tmp_Bonus.GetChild(1).GetChild(1).GetChild(2).GetComponent<UIText>();
		this.bonusHint[0].text_Record.font = this.TTFont;
		this.bonusHint[0].text_Record.SetAllDirty();
		this.bonusHint[0].text_Record.cachedTextGenerator.Invalidate();
		this.bonusHint[1].btn_Bonus = this.Tmp_Bonus.GetChild(1).GetChild(2).GetChild(0).GetComponent<UIButton>();
		this.bonusHint[1].btn_Bonus.m_Handler = this;
		this.bonusHint[1].btn_Bonus.m_BtnID1 = 18;
		if (this.GUIM.IsArabic)
		{
			this.bonusHint[1].btn_Bonus.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.bonusHint[1].btn_Bonus.image.material = this.GUIM.GetLeagueGO_iconMaterial();
		this.bonusHint[1].btn_Bonus.m_EffectType = e_EffectType.e_Normal;
		this.bonusHint[1].btn_Bonus.transition = Selectable.Transition.None;
		uibuttonHint2 = this.bonusHint[1].btn_Bonus.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint2.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint2.m_Handler = this;
		uibuttonHint2.ControlFadeOut = this.Img_BonusHint.gameObject;
		this.bonusHint[1].Img_Done = this.Tmp_Bonus.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.bonusHint[1].Img_Done.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		else
		{
			this.bonusHint[1].Img_Done.rectTransform.localScale = new Vector3(1f, 1f, 1f);
		}
		this.bonusHint[1].Img_Done.gameObject.SetActive(false);
		this.bonusHint[1].text_Record = this.Tmp_Bonus.GetChild(1).GetChild(2).GetChild(2).GetComponent<UIText>();
		this.bonusHint[1].text_Record.font = this.TTFont;
		this.bonusHint[1].text_Record.SetAllDirty();
		this.bonusHint[1].text_Record.cachedTextGenerator.Invalidate();
		this.bonusHint[2].btn_Bonus = this.Tmp_Bonus.GetChild(1).GetChild(3).GetChild(0).GetComponent<UIButton>();
		this.bonusHint[2].btn_Bonus.m_Handler = this;
		this.bonusHint[2].btn_Bonus.m_BtnID1 = 19;
		if (this.GUIM.IsArabic)
		{
			this.bonusHint[2].btn_Bonus.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.bonusHint[2].btn_Bonus.image.material = this.GUIM.GetLeagueGO_iconMaterial();
		this.bonusHint[2].btn_Bonus.m_EffectType = e_EffectType.e_Normal;
		this.bonusHint[2].btn_Bonus.transition = Selectable.Transition.None;
		uibuttonHint2 = this.bonusHint[2].btn_Bonus.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint2.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint2.m_Handler = this;
		uibuttonHint2.ControlFadeOut = this.Img_BonusHint.gameObject;
		this.bonusHint[2].Img_Done = this.Tmp_Bonus.GetChild(1).GetChild(3).GetChild(1).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.bonusHint[2].Img_Done.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		else
		{
			this.bonusHint[2].Img_Done.rectTransform.localScale = new Vector3(1f, 1f, 1f);
		}
		this.bonusHint[2].Img_Done.gameObject.SetActive(false);
		this.bonusHint[2].text_Record = this.Tmp_Bonus.GetChild(1).GetChild(3).GetChild(2).GetComponent<UIText>();
		this.bonusHint[2].text_Record.font = this.TTFont;
		this.bonusHint[2].text_Record.SetAllDirty();
		this.bonusHint[2].text_Record.cachedTextGenerator.Invalidate();
		this.text_BonusReward = this.Tmp_Bonus.GetChild(1).GetChild(4).GetChild(0).GetComponent<UIText>();
		this.text_BonusReward.font = this.TTFont;
		this.Cstr_BonusReward.ClearString();
		this.text_BonusReward.text = this.Cstr_BonusReward.ToString();
		component3 = this.Tmp_Bonus.GetChild(1).GetChild(5).GetComponent<UIText>();
		component3.font = this.TTFont;
		component3.text = this.DM.mStringTable.GetStringByID(17220u);
		this.btn_BonusExit = this.Tmp_Bonus.GetChild(2).GetChild(0).GetComponent<UIButton>();
		this.btn_BonusExit.m_Handler = this;
		this.btn_BonusExit.m_BtnID1 = 15;
		this.btn_BonusExit.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_BonusExit.image.material = this.m_Mat;
		this.btn_BonusExit.m_EffectType = e_EffectType.e_Scale;
		this.btn_BonusExit.transition = Selectable.Transition.None;
		component3 = this.Tmp_Bonus.GetChild(2).GetChild(1).GetComponent<UIText>();
		component3.font = this.TTFont;
		component3.text = this.DM.mStringTable.GetStringByID(17219u);
		this.RankObj.OnOpen(base.transform.GetChild(0).GetChild(9).GetChild(0));
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
		this.Tmp_Bonus.transform.SetParent(this.GUIM.m_SecWindowLayer, false);
		this.bOpenEnd = true;
		if (this.AM.AllyMobilizationData.EventState == EActivityState.EAS_None)
		{
			this.door.CloseMenu(false);
			return;
		}
		if ((this.AM.AllyMobilizationData.EventState == EActivityState.EAS_Run || this.AM.AllyMobilizationData.EventState == EActivityState.EAS_ReplayRanking) && this.MM.bFirstOpen && this.DM.RoleAlliance.Id != 0u)
		{
			this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DATA();
			this.MM.bFirstOpen = false;
		}
		else
		{
			this.CheckMissionCD();
			this.CheckInfo();
			if (this.AM.AllyMobilizationData.EventState != EActivityState.EAS_Prepare)
			{
				this.UpdateBonusData(false);
			}
		}
	}

	// Token: 0x06000FE4 RID: 4068 RVA: 0x001BF9B4 File Offset: 0x001BDBB4
	public void CheckInfo()
	{
		this.text_Empty.gameObject.SetActive(false);
		this.Img_HintBG.gameObject.SetActive(false);
		this.text_MissionCount.gameObject.SetActive(false);
		this.Img_MoreRewards.gameObject.SetActive(false);
		this.text_Result.gameObject.SetActive(false);
		this.text_Resultstr.gameObject.SetActive(false);
		switch (this.AM.AllyMobilizationData.EventState)
		{
		case EActivityState.EAS_None:
			this.door.CloseMenu(false);
			break;
		case EActivityState.EAS_Run:
			this.Img_ActivityTime.sprite = this.SArray.m_Sprites[3];
			this.Img_ActivityTime.gameObject.SetActive(true);
			if (this.DM.RoleAlliance.Id != 0u)
			{
				if (this.MM.involvedMember == 255)
				{
					this.text_Empty.text = this.DM.mStringTable.GetStringByID(1373u);
				}
				else if (this.GUIM.BuildingData.GetBuildData(8, 0).Level < 15)
				{
					this.text_Empty.text = this.DM.mStringTable.GetStringByID(1367u);
				}
			}
			else
			{
				this.text_Empty.text = this.DM.mStringTable.GetStringByID(1374u);
			}
			if (this.MM.involvedMember == 255 || this.DM.RoleAlliance.Id == 0u || this.GUIM.BuildingData.GetBuildData(8, 0).Level < 15)
			{
				this.text_Empty.gameObject.SetActive(true);
				this.text_Empty.SetAllDirty();
				this.text_Empty.cachedTextGenerator.Invalidate();
				this.btn_Rank1.image.color = Color.gray;
				this.btn_Rank2.image.color = Color.gray;
				return;
			}
			this.text_Time[0].text = this.DM.mStringTable.GetStringByID(8110u);
			this.text_Time[0].SetAllDirty();
			this.text_Time[0].cachedTextGenerator.Invalidate();
			this.Img_MissionBG.gameObject.SetActive(true);
			if (this.btn_Rank1.image.color != Color.white)
			{
				this.btn_Rank1.image.color = Color.white;
				this.btn_Rank2.image.color = Color.white;
			}
			this.Img_HintBG.gameObject.SetActive(true);
			this.btn_Reward.gameObject.SetActive(true);
			if (this.MM.mMoreRewards > 1)
			{
				this.Img_MoreRewards.gameObject.SetActive(true);
			}
			this.btn_Reward2.gameObject.SetActive(true);
			this.text_MissionCount.gameObject.SetActive(true);
			if (this.MM.mMissionID == 0 && this.MM.AllianceError != 0)
			{
				this.Img_LBG.gameObject.SetActive(true);
			}
			else
			{
				this.Img_LBG.gameObject.SetActive(false);
			}
			this.CheckMissionInfo();
			break;
		case EActivityState.EAS_Prepare:
			this.Img_ActivityTime.sprite = this.SArray.m_Sprites[2];
			this.Img_ActivityTime.gameObject.SetActive(true);
			this.text_Empty.gameObject.SetActive(true);
			this.text_Time[0].text = this.DM.mStringTable.GetStringByID(8111u);
			this.text_Time[0].SetAllDirty();
			this.text_Time[0].cachedTextGenerator.Invalidate();
			if (this.DM.RoleAlliance.Id != 0u)
			{
				if (this.GUIM.BuildingData.GetBuildData(8, 0).Level >= 15)
				{
					if (this.DM.RoleAlliance.Member < 25)
					{
						this.text_Empty.text = this.DM.mStringTable.GetStringByID(1373u);
					}
					else
					{
						this.text_Empty.text = this.DM.mStringTable.GetStringByID(1378u);
					}
				}
				else
				{
					this.text_Empty.text = this.DM.mStringTable.GetStringByID(1367u);
				}
			}
			else
			{
				this.text_Empty.text = this.DM.mStringTable.GetStringByID(1374u);
			}
			this.text_Empty.SetAllDirty();
			this.text_Empty.cachedTextGenerator.Invalidate();
			this.btn_Rank1.image.color = Color.gray;
			this.btn_Rank2.image.color = Color.gray;
			break;
		case EActivityState.EAS_ReplayRanking:
		{
			this.Img_ActivityTime.gameObject.SetActive(false);
			this.Img_MissionBG.gameObject.SetActive(false);
			this.Img_ActivityEnd.gameObject.SetActive(true);
			this.Img_LBG.gameObject.SetActive(true);
			this.text_Rewardstr.gameObject.SetActive(true);
			this.text_Resultstr.gameObject.SetActive(true);
			this.RankObj.SetActive(true);
			this.btn_Bonus.gameObject.SetActive(false);
			this.btn_Bonus2.gameObject.SetActive(false);
			this.AM.SavebForceAMActivity(false);
			this.AM.CheckAMShowHint();
			if (this.MM.involvedMember == 255 || this.DM.RoleAlliance.Id == 0u || this.GUIM.BuildingData.GetBuildData(8, 0).Level < 15)
			{
				if (this.MM.involvedMember == 255 || this.DM.RoleAlliance.Id == 0u)
				{
					this.RankObj.SetAnimVisible = false;
				}
				this.Img_RewardBG[0].gameObject.SetActive(false);
				this.Img_RewardBG[1].color = Color.gray;
				this.btn_Rank1.image.color = Color.gray;
				this.btn_Rank2.image.color = Color.gray;
				this.btn_GetReward.gameObject.SetActive(false);
				this.Img_GetRewardTime.gameObject.SetActive(false);
				this.text_RewardTitle.gameObject.SetActive(false);
				return;
			}
			if (this.MM.AMCompleteDegree == 0 || this.MM.AllianceError == 1)
			{
				this.Img_RewardBG[0].gameObject.SetActive(false);
				this.Img_RewardBG[1].color = Color.gray;
				this.btn_Rank1.image.color = Color.white;
				this.btn_Rank2.image.color = Color.white;
				this.btn_GetReward.gameObject.SetActive(false);
				this.Img_GetRewardTime.gameObject.SetActive(false);
				this.text_RewardTitle.gameObject.SetActive(false);
				return;
			}
			this.Cstr_RewardNum.ClearString();
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.IntToFormat((long)this.MM.AMCompleteDegree, 1, false);
			cstring.AppendFormat("<color=#FFFF00>{0}</color>");
			this.Cstr_RewardNum.StringToFormat(cstring);
			this.Cstr_RewardNum.AppendFormat(this.DM.mStringTable.GetStringByID(1370u));
			this.text_RewardNum.text = this.Cstr_RewardNum.ToString();
			this.text_RewardNum.SetAllDirty();
			this.text_RewardNum.cachedTextGenerator.Invalidate();
			this.SetFutureRankStr();
			this.text_Result.text = this.Cstr_RankResult.ToString();
			this.text_Result.SetAllDirty();
			this.text_Result.cachedTextGenerator.Invalidate();
			this.text_Result.gameObject.SetActive(true);
			this.Img_RewardBG[1].color = Color.white;
			this.btn_Rank1.image.color = Color.white;
			this.btn_Rank2.image.color = Color.white;
			if (this.MM.IsGetPrize())
			{
				this.Img_RewardOK.gameObject.SetActive(true);
				this.Img_RewardBG[0].gameObject.SetActive(false);
				this.btn_GetReward.gameObject.SetActive(false);
				this.Img_GetRewardTime.gameObject.SetActive(false);
				this.text_RewardTitle.gameObject.SetActive(false);
			}
			break;
		}
		}
	}

	// Token: 0x06000FE5 RID: 4069 RVA: 0x001C02C0 File Offset: 0x001BE4C0
	public void SetFutureRankStr()
	{
		this.Cstr_RankResult.ClearString();
		this.Cstr_Result.ClearString();
		this.Cstr_Result.StringToFormat(this.DM.mStringTable.GetStringByID(1033u - (uint)this.MM.mMobilizationFutureRank));
		switch (this.MM.mMobilizationFutureRank)
		{
		case 1:
			this.Cstr_Result.AppendFormat("<color=#14F855>{0}</color>");
			break;
		case 2:
			this.Cstr_Result.AppendFormat("<color=#00DEFF>{0}</color>");
			break;
		case 3:
			this.Cstr_Result.AppendFormat("<color=#7600B0>{0}</color>");
			break;
		case 4:
			this.Cstr_Result.AppendFormat("<color=#FFF100>{0}</color>");
			break;
		default:
			this.Cstr_Result.AppendFormat("<color=#E5E5E5>{0}</color>");
			break;
		}
		this.Cstr_RankResult.StringToFormat(this.Cstr_Result);
		if (this.MM.mMobilizationFutureRank > this.DM.RoleAlliance.AMRank)
		{
			this.Cstr_RankResult.AppendFormat(this.DM.mStringTable.GetStringByID(1015u));
		}
		else if (this.MM.mMobilizationFutureRank < this.DM.RoleAlliance.AMRank)
		{
			this.Cstr_RankResult.AppendFormat(this.DM.mStringTable.GetStringByID(1018u));
		}
		else
		{
			this.Cstr_RankResult.AppendFormat(this.DM.mStringTable.GetStringByID(1376u));
		}
	}

	// Token: 0x06000FE6 RID: 4070 RVA: 0x001C0460 File Offset: 0x001BE660
	public void CheckMissionInfo()
	{
		this.text_Kind.gameObject.SetActive(false);
		this.text_Kind1.gameObject.SetActive(false);
		this.Img_MissionTime.gameObject.SetActive(false);
		this.Img_MissionCDTime.gameObject.SetActive(false);
		this.btn_Start.gameObject.SetActive(false);
		this.btn_GiveUp.gameObject.SetActive(false);
		this.btn_Report.gameObject.SetActive(false);
		this.Img_MissionBar_RT.parent.gameObject.SetActive(false);
		this.Img_Missionstatus.gameObject.SetActive(false);
		if (this.MM.mScrollFrame == 0)
		{
			if (this.MM.mMissionID != 0)
			{
				this.btn_GiveUp.gameObject.SetActive(true);
				this.SetMissionInfo(this.MM.mMissionID, (int)this.MM.mMissionDifficulty, false);
				if (this.MM.mMissionStatus == 2)
				{
					this.Img_Missionstatus.gameObject.SetActive(true);
					this.Img_Missionstatus.sprite = this.SArray.m_Sprites[1];
					this.text_Missionstatus.color = this.mColor_R;
					this.text_Missionstatus.text = this.DM.mStringTable.GetStringByID(1360u);
					this.text_Missionstatus.SetAllDirty();
					this.text_Missionstatus.cachedTextGenerator.Invalidate();
				}
				else if (this.MM.mMissionStatus == 1)
				{
					this.btn_GiveUp.gameObject.SetActive(false);
					this.Img_Missionstatus.gameObject.SetActive(true);
					this.Img_Missionstatus.sprite = this.SArray.m_Sprites[0];
					this.btn_Report.gameObject.SetActive(true);
					this.text_Missionstatus.color = this.mColor_G;
					this.text_Missionstatus.text = this.DM.mStringTable.GetStringByID(8114u);
					this.text_Missionstatus.SetAllDirty();
					this.text_Missionstatus.cachedTextGenerator.Invalidate();
				}
				else
				{
					this.Img_Missionstatus.gameObject.SetActive(false);
					this.Img_MissionBar_RT.parent.gameObject.SetActive(true);
					long num = this.MM.mMissionTime - this.DM.ServerTime;
					this.mMMissionData = this.DM.AllianceMobilizationMission.GetRecordByKey(this.MM.mMissionID);
					double num2 = (double)(this.mMMissionData.MissionTime[(int)this.MM.mMissionDifficulty] * 3600);
					this.Img_MissionBar_RT.sizeDelta = new Vector2(259f * (float)((num2 - (double)num) / num2), this.Img_MissionBar_RT.sizeDelta.y);
					this.Cstr_TimeBar.ClearString();
					if (num > 86400L)
					{
						this.Cstr_TimeBar.IntToFormat(num / 86400L, 1, false);
						num %= 86400L;
						this.Cstr_TimeBar.IntToFormat(num / 3600L, 2, false);
						num %= 3600L;
						this.Cstr_TimeBar.IntToFormat(num / 60L, 2, false);
						num %= 60L;
						this.Cstr_TimeBar.IntToFormat(num, 2, false);
						this.Cstr_TimeBar.AppendFormat("{0}d {1}:{2}:{3}");
					}
					else
					{
						this.Cstr_TimeBar.IntToFormat(num / 3600L, 2, false);
						num %= 3600L;
						this.Cstr_TimeBar.IntToFormat(num / 60L, 2, false);
						num %= 60L;
						this.Cstr_TimeBar.IntToFormat(num, 2, false);
						this.Cstr_TimeBar.AppendFormat("{0}:{1}:{2}");
					}
					this.text_TimeBar.text = this.Cstr_TimeBar.ToString();
					this.text_TimeBar.SetAllDirty();
					this.text_TimeBar.cachedTextGenerator.Invalidate();
				}
			}
			else
			{
				this.text_Kind.gameObject.SetActive(true);
				this.Img_LBG.gameObject.SetActive(true);
				this.text_Info[0].gameObject.SetActive(false);
				this.text_Info[1].gameObject.SetActive(false);
				this.Img_Mission.transform.parent.gameObject.SetActive(false);
				this.Img_MissionKind.gameObject.SetActive(false);
				this.Img_MissionScore.gameObject.SetActive(false);
				if (this.MM.availableMission != 0 && this.MM.AllianceError == 0)
				{
					this.text_Kind.text = this.DM.mStringTable.GetStringByID(1346u);
					this.text_Kind.color = this.mColor_Info;
				}
				else
				{
					this.text_Kind.color = this.mColor_R;
					if (this.MM.AllianceError != 0)
					{
						this.text_Kind.gameObject.SetActive(true);
						this.text_Kind1.gameObject.SetActive(true);
						this.text_Kind.color = this.mColor_R;
						this.text_Kind.text = this.DM.mStringTable.GetStringByID(1353u);
						this.text_Kind1.text = this.DM.mStringTable.GetStringByID(1354u);
						this.text_Kind1.SetAllDirty();
						this.text_Kind1.cachedTextGenerator.Invalidate();
					}
					else if (this.MM.extraMission == 0 || (this.MM.extraMission > 0 && this.MM.extraMission < this.MM.mextraMissionBuyLimit))
					{
						if (this.MM.AllianceError == 0)
						{
							this.btn_Add.gameObject.SetActive(true);
						}
						this.text_Kind.text = this.DM.mStringTable.GetStringByID(1348u);
					}
					else
					{
						this.text_Kind.text = this.DM.mStringTable.GetStringByID(1352u);
					}
				}
			}
		}
		else
		{
			this.Img_Mission.transform.parent.gameObject.SetActive(false);
			this.Img_MissionKind.gameObject.SetActive(false);
			this.Img_MissionScore.gameObject.SetActive(false);
			if (this.MM.mMobilizationMission[this.MM.mScrollFrame].MissionType != 1001)
			{
				this.Img_MissionTime.gameObject.SetActive(true);
				if (this.MM.mMissionID == 0)
				{
					this.btn_Start.gameObject.SetActive(true);
				}
				this.SetMissionInfo(this.MM.mMobilizationMission[this.MM.mScrollFrame].MissionType, (int)this.MM.mMobilizationMission[this.MM.mScrollFrame].Difficulty, true);
			}
			else
			{
				for (int i = 0; i < 2; i++)
				{
					this.text_Info[i].gameObject.SetActive(false);
				}
				this.Img_MissionCDTime.gameObject.SetActive(true);
				this.Cstr_MissionCDTime.ClearString();
				long num3 = this.MM.mMobilizationMission[this.MM.mScrollFrame].CDTime - this.DM.ServerTime;
				if (num3 < 0L)
				{
					num3 = 0L;
				}
				this.Cstr_MissionCDTime.IntToFormat(num3 / 60L, 2, false);
				this.Cstr_MissionCDTime.IntToFormat(num3 % 60L, 2, false);
				this.Cstr_MissionCDTime.AppendFormat("{0}:{1}");
				this.text_MissionCDTime[1].text = this.Cstr_MissionCDTime.ToString();
				this.text_MissionCDTime[1].SetAllDirty();
				this.text_MissionCDTime[1].cachedTextGenerator.Invalidate();
			}
		}
		this.text_Kind.SetAllDirty();
		this.text_Kind.cachedTextGenerator.Invalidate();
		this.text_Kind.cachedTextGeneratorForLayout.Invalidate();
		if (this.text_Kind.preferredHeight > this.text_Kind.rectTransform.sizeDelta.y)
		{
			this.text_Kind.rectTransform.sizeDelta = new Vector2(this.text_Kind.rectTransform.sizeDelta.x, this.text_Kind.preferredHeight + 1f);
			if (this.text_Kind1.IsActive())
			{
				this.text_Kind1.rectTransform.anchoredPosition = new Vector2(this.text_Kind1.rectTransform.anchoredPosition.x, this.text_Kind.rectTransform.anchoredPosition.y - (this.text_Kind.preferredHeight + 1f) - 10f);
			}
		}
		this.text_Kind1.SetAllDirty();
		this.text_Kind1.cachedTextGenerator.Invalidate();
		this.text_Kind1.cachedTextGeneratorForLayout.Invalidate();
		if (this.text_Kind1.preferredHeight > this.text_Kind1.rectTransform.sizeDelta.y)
		{
			this.text_Kind1.rectTransform.sizeDelta = new Vector2(this.text_Kind1.rectTransform.sizeDelta.x, this.text_Kind1.preferredHeight + 1f);
		}
		this.CheckMissionCount();
	}

	// Token: 0x06000FE7 RID: 4071 RVA: 0x001C0DFC File Offset: 0x001BEFFC
	public void CheckMissionCount()
	{
		this.Cstr_MissionCount.ClearString();
		if (this.MM.availableMission != 0)
		{
			this.Cstr_MissionCount.IntToFormat((long)this.MM.availableMission, 1, false);
			if (this.btn_Add.gameObject.activeSelf)
			{
				this.btn_Add.gameObject.SetActive(false);
			}
		}
		else
		{
			this.Cstr_MissionCount.StringToFormat("<color=#FF5E70>0</color>");
			if (this.MM.AllianceError == 0 && (this.MM.extraMission == 0 || (this.MM.extraMission > 0 && this.MM.extraMission < this.MM.mextraMissionBuyLimit)))
			{
				this.btn_Add.gameObject.SetActive(true);
			}
		}
		this.Cstr_MissionCount.AppendFormat(this.DM.mStringTable.GetStringByID(1345u));
		this.text_MissionCount.text = this.Cstr_MissionCount.ToString();
		this.text_MissionCount.SetAllDirty();
		this.text_MissionCount.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000FE8 RID: 4072 RVA: 0x001C0F28 File Offset: 0x001BF128
	public void UpdateBonusData(bool open = false)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		int num = this.MM.CheckBonusDone();
		for (int i = 0; i < 3; i++)
		{
			this.Cstr_BonusRecord[i].ClearString();
			AllianceMobilizationGoldMission recordByKey = this.DM.AllianceMobilizationGoldMissionTable.GetRecordByKey(this.MM.AMGoldID[i]);
			this.bonusHint[i].text_Record.gameObject.SetActive(false);
			cstring.ClearString();
			cstring.IntToFormat((long)recordByKey.pic_Main, 3, false);
			cstring.AppendFormat("{0}");
			this.bonusHint[i].btn_Bonus.image.sprite = this.GUIM.LoadLeagueGO_iconSprite(cstring);
			if (this.GUIM.IsArabic)
			{
				if (recordByKey.pic_Main == 24 || recordByKey.pic_Main == 30)
				{
					this.bonusHint[i].btn_Bonus.image.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
				}
				else
				{
					this.bonusHint[i].btn_Bonus.image.rectTransform.localScale = new Vector3(1f, 1f, 1f);
				}
			}
			this.bonusHint[i].Img_Done.gameObject.SetActive(num == i);
			if (this.MM.AMGoldRecord[i] > 0u && num == -1)
			{
				if (recordByKey.par1 >= 1000u)
				{
					int num2 = (int)(this.MM.AMGoldRecord[i] / recordByKey.par1 * 100f);
					if (num2 == 100)
					{
						num2 = 99;
					}
					if (this.GUIM.IsArabic)
					{
						this.Cstr_BonusRecord[i].Append("% " + num2.ToString());
					}
					else
					{
						this.Cstr_BonusRecord[i].Append(num2.ToString() + " %");
					}
				}
				else
				{
					this.Cstr_BonusRecord[i].IntToFormat((long)((ulong)this.MM.AMGoldRecord[i]), 1, true);
					this.Cstr_BonusRecord[i].IntToFormat((long)((ulong)recordByKey.par1), 1, true);
					if (this.GUIM.IsArabic)
					{
						this.Cstr_BonusRecord[i].AppendFormat("{1} / {0}");
					}
					else
					{
						this.Cstr_BonusRecord[i].AppendFormat("{0} / {1}");
					}
				}
				this.bonusHint[i].text_Record.text = this.Cstr_BonusRecord[i].ToString();
				this.bonusHint[i].text_Record.SetAllDirty();
				this.bonusHint[i].text_Record.cachedTextGenerator.Invalidate();
				this.bonusHint[i].text_Record.gameObject.SetActive(true);
			}
			else
			{
				this.bonusHint[i].text_Record.text = string.Empty;
				this.bonusHint[i].text_Record.SetAllDirty();
				this.bonusHint[i].text_Record.cachedTextGenerator.Invalidate();
				this.bonusHint[i].text_Record.gameObject.SetActive(false);
			}
			if (i == 0)
			{
				this.Cstr_BonusReward.ClearString();
				if (this.GUIM.IsArabic)
				{
					this.Cstr_BonusReward.Append(recordByKey.rewardPoint.ToString());
					this.Cstr_BonusReward.Append(" +");
				}
				else
				{
					this.Cstr_BonusReward.Append("+ ");
					this.Cstr_BonusReward.Append(recordByKey.rewardPoint.ToString());
				}
				this.text_BonusReward.text = this.Cstr_BonusReward.ToString();
				this.text_BonusReward.SetAllDirty();
				this.text_BonusReward.cachedTextGenerator.Invalidate();
			}
		}
		switch (this.MM.AMGoldState)
		{
		case 0:
		case 4:
			this.btn_Bonus.gameObject.SetActive(false);
			this.btn_Bonus2.gameObject.SetActive(false);
			return;
		case 1:
			this.btn_Bonus.gameObject.SetActive(false);
			this.btn_Bonus2.gameObject.SetActive(this.DM.RoleAlliance.Id > 0u);
			this.btn_BonusReward.gameObject.SetActive(true);
			this.btn_BonusReward2.gameObject.SetActive(false);
			this.text_BonusDone.gameObject.SetActive(false);
			this.Img_BonusAlert.gameObject.SetActive(false);
			break;
		case 2:
		{
			this.btn_Bonus.gameObject.SetActive(this.DM.RoleAlliance.Id > 0u);
			this.btn_Bonus2.gameObject.SetActive(false);
			this.AM.SavebForceAMActivity(true);
			this.AM.CheckAMShowHint();
			this.Img_BonusAlert.gameObject.SetActive(true);
			this.btn_BonusReward.gameObject.SetActive(false);
			this.btn_BonusReward2.gameObject.SetActive(true);
			this.text_BonusDone.gameObject.SetActive(false);
			AllianceMobilizationGoldMission recordByKey2 = this.DM.AllianceMobilizationGoldMissionTable.GetRecordByKey(this.MM.AMGoldID[0]);
			this.Cstr_BonusReward.ClearString();
			if (this.GUIM.IsArabic)
			{
				this.Cstr_BonusReward.StringToFormat(recordByKey2.rewardPoint.ToString() + " +");
			}
			else
			{
				this.Cstr_BonusReward.StringToFormat("+ " + recordByKey2.rewardPoint.ToString());
			}
			this.Cstr_BonusReward.AppendFormat("<color=#4DDA65FF>{0}</color>");
			this.text_BonusReward.text = this.Cstr_BonusReward.ToString();
			break;
		}
		case 3:
		{
			this.btn_Bonus.gameObject.SetActive(this.DM.RoleAlliance.Id > 0u);
			this.btn_Bonus2.gameObject.SetActive(false);
			this.AM.SavebForceAMActivity(false);
			this.AM.CheckAMShowHint();
			this.Img_BonusAlert.gameObject.SetActive(false);
			this.btn_BonusReward.gameObject.SetActive(false);
			this.btn_BonusReward2.gameObject.SetActive(false);
			this.text_BonusDone.gameObject.SetActive(true);
			AllianceMobilizationGoldMission recordByKey3 = this.DM.AllianceMobilizationGoldMissionTable.GetRecordByKey(this.MM.AMGoldID[0]);
			this.Cstr_BonusReward.ClearString();
			if (this.GUIM.IsArabic)
			{
				this.Cstr_BonusReward.StringToFormat(recordByKey3.rewardPoint.ToString() + " +");
			}
			else
			{
				this.Cstr_BonusReward.StringToFormat("+ " + recordByKey3.rewardPoint.ToString());
			}
			this.Cstr_BonusReward.AppendFormat("<color=#4DDA65FF>{0}</color>");
			this.text_BonusReward.text = this.Cstr_BonusReward.ToString();
			break;
		}
		}
		if (!this.Tmp_Bonus.gameObject.activeSelf)
		{
			this.Tmp_Bonus.gameObject.SetActive(open);
		}
	}

	// Token: 0x06000FE9 RID: 4073 RVA: 0x001C1684 File Offset: 0x001BF884
	public void GetBonusHintString(AllianceMobilizationGoldMission data, int index)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		this.Cstr_BonusHint.Append(this.DM.mStringTable.GetStringByID(17221u) + "\n");
		cstring.ClearString();
		ushort missionKind = data.missionKind;
		if (missionKind != 3)
		{
			cstring.IntToFormat((long)((ulong)data.par1), 1, true);
			cstring.AppendFormat(this.DM.mStringTable.GetStringByID((uint)data.info));
			this.Cstr_BonusHint.Append(cstring.ToString());
			if (this.MM.CheckBonusDone() == -1)
			{
				this.Cstr_BonusHint.Append("\n");
				cstring.ClearString();
				cstring.IntToFormat((long)((ulong)this.MM.AMGoldRecord[index]), 1, true);
				cstring.IntToFormat((long)((ulong)data.par1), 1, true);
				cstring.AppendFormat("{0} / {1}");
				this.Cstr_BonusHint.Append(cstring.ToString());
			}
		}
		else
		{
			cstring.IntToFormat((long)((ulong)data.par1), 1, true);
			cstring.IntToFormat((long)((ulong)data.par2), 1, true);
			cstring.AppendFormat(this.DM.mStringTable.GetStringByID((uint)data.info));
			this.Cstr_BonusHint.Append(cstring.ToString());
			if (this.MM.CheckBonusDone() == -1)
			{
				this.Cstr_BonusHint.Append("\n");
				cstring.ClearString();
				cstring.IntToFormat((long)((ulong)this.MM.AMGoldRecord[index]), 1, true);
				cstring.IntToFormat((long)((ulong)data.par1), 1, true);
				cstring.AppendFormat("{0} / {1}");
				this.Cstr_BonusHint.Append(cstring.ToString());
			}
		}
	}

	// Token: 0x06000FEA RID: 4074 RVA: 0x001C1850 File Offset: 0x001BFA50
	public void SetBonusHint(UIButton btn, UIButtonHint sender)
	{
		this.Cstr_BonusHint.ClearString();
		switch (btn.m_BtnID1)
		{
		case 17:
		{
			AllianceMobilizationGoldMission recordByKey = this.DM.AllianceMobilizationGoldMissionTable.GetRecordByKey(this.MM.AMGoldID[0]);
			this.GetBonusHintString(recordByKey, 0);
			break;
		}
		case 18:
		{
			AllianceMobilizationGoldMission recordByKey = this.DM.AllianceMobilizationGoldMissionTable.GetRecordByKey(this.MM.AMGoldID[1]);
			this.GetBonusHintString(recordByKey, 1);
			break;
		}
		case 19:
		{
			AllianceMobilizationGoldMission recordByKey = this.DM.AllianceMobilizationGoldMissionTable.GetRecordByKey(this.MM.AMGoldID[2]);
			this.GetBonusHintString(recordByKey, 2);
			break;
		}
		}
		this.text_BonusHint.text = this.Cstr_BonusHint.ToString();
		this.text_BonusHint.SetAllDirty();
		this.text_BonusHint.SetLayoutDirty();
		this.text_BonusHint.SetVerticesDirty();
		this.text_BonusHint.cachedTextGenerator.Invalidate();
		this.text_BonusHint.cachedTextGeneratorForLayout.Invalidate();
		Vector2 sizeDelta = this.Img_BonusHint.rectTransform.sizeDelta;
		sizeDelta.y = this.text_BonusHint.preferredHeight + 16f;
		this.Img_BonusHint.rectTransform.sizeDelta = sizeDelta;
		sender.GetTipPosition(this.Img_BonusHint.rectTransform, UIButtonHint.ePosition.Original, null);
		this.Img_BonusHint.gameObject.SetActive(true);
	}

	// Token: 0x06000FEB RID: 4075 RVA: 0x001C19C8 File Offset: 0x001BFBC8
	public void SetMissionInfo(ushort mKey, int Difficulty, bool bother = true)
	{
		this.Img_Mission.transform.parent.gameObject.SetActive(true);
		this.Img_MissionKind.gameObject.SetActive(true);
		this.Img_MissionScore.gameObject.SetActive(true);
		this.text_Info[0].gameObject.SetActive(true);
		this.text_Info[1].gameObject.SetActive(true);
		this.mMMissionData = this.DM.AllianceMobilizationMission.GetRecordByKey(mKey);
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.IntToFormat((long)this.mMMissionData.MissionIcon, 3, false);
		cstring.AppendFormat("{0}");
		this.Img_Mission.sprite = this.GUIM.LoadLeagueGO_iconSprite(cstring);
		if (this.GUIM.IsArabic)
		{
			if (this.mMMissionData.MissionIcon == 24 || this.mMMissionData.MissionIcon == 30)
			{
				this.Img_Mission.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				this.Img_Mission.rectTransform.localScale = new Vector3(1f, 1f, 1f);
			}
		}
		cstring.ClearString();
		cstring.IntToFormat((long)this.mMMissionData.MissionIcon2, 3, false);
		cstring.AppendFormat("icon{0}");
		this.Img_MissionKind.sprite = this.GUIM.LoadFrameSprite(cstring);
		if (this.Img_MissionKind.sprite == null)
		{
			cstring.ClearString();
			cstring.Append("icon014");
			this.Img_MissionKind.sprite = this.GUIM.LoadFrameSprite(cstring);
		}
		if (this.GUIM.IsArabic)
		{
			if (this.mMMissionData.MissionIcon2 == 44 || this.mMMissionData.MissionIcon2 == 58)
			{
				this.Img_MissionKind.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				this.Img_MissionKind.rectTransform.localScale = new Vector3(1f, 1f, 1f);
			}
		}
		this.Img_MissionKind.SetNativeSize();
		this.text_Info[0].text = this.DM.mStringTable.GetStringByID((uint)this.mMMissionData.MissionInfo);
		this.text_Info[0].SetAllDirty();
		this.text_Info[0].cachedTextGenerator.Invalidate();
		this.Cstr_Info[0].ClearString();
		if (this.mMMissionData.MissionType == 41 || this.mMMissionData.MissionType == 71)
		{
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring2.ClearString();
			if (!bother)
			{
				if (this.MM.mMissionTarget / 1440u > 0u)
				{
					cstring2.IntToFormat((long)((ulong)(this.MM.mMissionTarget / 1440u)), 1, false);
					cstring2.IntToFormat((long)((ulong)(this.MM.mMissionTarget % 1440u / 60u)), 2, false);
					cstring2.IntToFormat((long)((ulong)(this.MM.mMissionTarget % 60u)), 2, false);
					cstring2.IntToFormat(0L, 2, false);
					cstring2.AppendFormat("{0}d {1}:{2}:{3}");
				}
				else
				{
					cstring2.IntToFormat((long)((ulong)(this.MM.mMissionTarget / 60u)), 2, false);
					cstring2.IntToFormat((long)((ulong)(this.MM.mMissionTarget % 60u)), 2, false);
					cstring2.IntToFormat(0L, 2, false);
					cstring2.AppendFormat("{0}:{1}:{2}");
				}
			}
			CString cstring3 = StringManager.Instance.StaticString1024();
			cstring3.ClearString();
			if (this.mMMissionData.MissionMaxValue[Difficulty] / 1440u > 0u)
			{
				cstring3.IntToFormat((long)((ulong)(this.mMMissionData.MissionMaxValue[Difficulty] / 1440u)), 1, false);
				if (this.mMMissionData.MissionMaxValue[Difficulty] % 1440u == 0u)
				{
					cstring3.AppendFormat("{0}d");
				}
				else
				{
					cstring3.IntToFormat((long)((ulong)(this.mMMissionData.MissionMaxValue[Difficulty] % 1440u / 60u)), 2, false);
					cstring3.IntToFormat((long)((ulong)(this.mMMissionData.MissionMaxValue[Difficulty] % 60u)), 2, false);
					cstring3.IntToFormat(0L, 2, false);
					cstring3.AppendFormat("{0}d {1}:{2}:{3}");
				}
			}
			else
			{
				cstring3.IntToFormat((long)((ulong)(this.mMMissionData.MissionMaxValue[Difficulty] / 60u)), 2, false);
				cstring3.IntToFormat((long)((ulong)(this.mMMissionData.MissionMaxValue[Difficulty] % 60u)), 2, false);
				cstring3.IntToFormat(0L, 2, false);
				cstring3.AppendFormat("{0}:{1}:{2}");
			}
			if (!bother)
			{
				this.Cstr_Info[0].StringToFormat(cstring2);
			}
			else
			{
				this.Cstr_Info[0].IntToFormat(0L, 1, true);
			}
			this.Cstr_Info[0].StringToFormat(cstring3);
		}
		else
		{
			if (!bother)
			{
				this.Cstr_Info[0].IntToFormat((long)((ulong)this.MM.mMissionTarget), 1, true);
			}
			else
			{
				this.Cstr_Info[0].IntToFormat(0L, 1, true);
			}
			this.Cstr_Info[0].IntToFormat((long)((ulong)this.mMMissionData.MissionMaxValue[Difficulty]), 1, true);
		}
		if (this.GUIM.IsArabic)
		{
			this.Cstr_Info[0].AppendFormat("{1} / {0}");
		}
		else
		{
			this.Cstr_Info[0].AppendFormat("{0} / {1}");
		}
		this.text_Info[1].text = this.Cstr_Info[0].ToString();
		this.text_Info[1].SetAllDirty();
		this.text_Info[1].cachedTextGenerator.Invalidate();
		this.Cstr_Info[1].ClearString();
		this.Cstr_Info[1].IntToFormat((long)this.mMMissionData.MissionScore[Difficulty], 1, true);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_Info[1].AppendFormat("{0}+");
		}
		else
		{
			this.Cstr_Info[1].AppendFormat("+{0}");
		}
		this.text_Info[2].text = this.Cstr_Info[1].ToString();
		this.text_Info[2].SetAllDirty();
		this.text_Info[2].cachedTextGenerator.Invalidate();
		this.Cstr_MissionTime.ClearString();
		if (this.mMMissionData.MissionTime[Difficulty] / 24 >= 1)
		{
			this.Cstr_MissionTime.IntToFormat((long)(this.mMMissionData.MissionTime[Difficulty] / 24), 1, false);
			this.Cstr_MissionTime.IntToFormat((long)(this.mMMissionData.MissionTime[Difficulty] % 24), 2, false);
			this.Cstr_MissionTime.IntToFormat(0L, 2, false);
			this.Cstr_MissionTime.IntToFormat(0L, 2, false);
			this.Cstr_MissionTime.AppendFormat("{0}d {1}:{2}:{3}");
		}
		else
		{
			this.Cstr_MissionTime.IntToFormat((long)this.mMMissionData.MissionTime[Difficulty], 2, false);
			this.Cstr_MissionTime.IntToFormat(0L, 2, false);
			this.Cstr_MissionTime.IntToFormat(0L, 2, false);
			this.Cstr_MissionTime.AppendFormat("{0}:{1}:{2}");
		}
		this.text_MissionTime.text = this.Cstr_MissionTime.ToString();
		this.text_MissionTime.SetAllDirty();
		this.text_MissionTime.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000FEC RID: 4076 RVA: 0x001C213C File Offset: 0x001C033C
	public override void OnClose()
	{
		if (this.m_ScrollPanel != null)
		{
			this.MM.mMobilizationScroll = this.m_ScrollPanel.GetTopIdx();
			this.MM.mMobilizationScroll_Y = this.m_ItemConet.anchoredPosition.y;
		}
		if (this.Cstr_Lv != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Lv);
		}
		if (this.Cstr_Lv != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_LvValue);
		}
		if (this.Cstr_ActivityTime != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_ActivityTime);
		}
		if (this.Cstr_NowScore != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_NowScore);
		}
		if (this.Cstr_NextScore != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_NextScore);
		}
		if (this.Cstr_MobilizationNum != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_MobilizationNum);
		}
		if (this.Cstr_MissionTime != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_MissionTime);
		}
		if (this.Cstr_MissionCDTime != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_MissionCDTime);
		}
		if (this.Cstr_MissionCount != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_MissionCount);
		}
		if (this.Cstr_Hint != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Hint);
		}
		if (this.Cstr_TimeBar != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_TimeBar);
		}
		if (this.Cstr_GetRewardTime != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_GetRewardTime);
		}
		if (this.Cstr_RewardNum != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_RewardNum);
		}
		if (this.Cstr_RankHint != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_RankHint);
		}
		if (this.Cstr_Result != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Result);
		}
		if (this.Cstr_RankResult != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_RankResult);
		}
		if (this.Cstr_BonusReward != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_BonusReward);
		}
		if (this.Cstr_BonusRewardDone != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_BonusRewardDone);
		}
		if (this.Cstr_BonusHint != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_BonusHint);
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.Cstr_BonusRecord[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_BonusRecord[i]);
			}
		}
		for (int j = 0; j < 2; j++)
		{
			if (this.Cstr_Info[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Info[j]);
			}
		}
		for (int k = 0; k < 3; k++)
		{
			for (int l = 0; l < 3; l++)
			{
				if (this.Cstr_ItemTime[k] != null && this.Cstr_ItemTime[k][l] != null)
				{
					StringManager.Instance.DeSpawnString(this.Cstr_ItemTime[k][l]);
				}
				if (this.Cstr_ItemValue[k] != null && this.Cstr_ItemValue[k][l] != null)
				{
					StringManager.Instance.DeSpawnString(this.Cstr_ItemValue[k][l]);
				}
			}
		}
		this.Tmp_Bonus.transform.SetParent(this.GameT, false);
		this.RankObj.OnClose();
		this.tmpAddCount = 10;
	}

	// Token: 0x06000FED RID: 4077 RVA: 0x001C24B8 File Offset: 0x001C06B8
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.tmpItem[panelObjectIdx] == null)
		{
			this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			for (int i = 0; i < 3; i++)
			{
				this.btn_ItemSelect[panelObjectIdx][i] = item.transform.GetChild(i).GetComponent<UIButton>();
				this.btn_ItemSelect[panelObjectIdx][i].m_Handler = this;
				this.btn_ItemSelect[panelObjectIdx][i].m_BtnID2 = panelObjectIdx;
				this.btn_ItemSelect[panelObjectIdx][i].m_BtnID3 = i;
				for (int j = 0; j < 3; j++)
				{
					this.ItemKind_T[panelObjectIdx][i * 3 + j] = item.transform.GetChild(i).GetChild(j);
				}
				this.Img_ItemP1Mission[panelObjectIdx][i] = item.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<Image>();
				this.Img_ItemP1Icon[panelObjectIdx][i] = item.transform.GetChild(i).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
				this.Img_ItemP1Score[panelObjectIdx][i] = item.transform.GetChild(i).GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>();
				this.text_ItemP1Score[panelObjectIdx][i] = item.transform.GetChild(i).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
				this.Img_ItemP1OK[panelObjectIdx][i] = item.transform.GetChild(i).GetChild(0).GetChild(0).GetChild(3).GetComponent<Image>();
				this.text_ItemNoMission[panelObjectIdx][i] = item.transform.GetChild(i).GetChild(0).GetChild(1).GetComponent<UIText>();
				this.btn_Delete[panelObjectIdx][i] = item.transform.GetChild(i).GetChild(1).GetChild(1).GetComponent<UIButton>();
				this.btn_Delete[panelObjectIdx][i].m_Handler = this;
				this.btn_Delete[panelObjectIdx][i].m_BtnID2 = panelObjectIdx;
				this.btn_Delete[panelObjectIdx][i].m_BtnID3 = i;
				this.Img_ItemIcon[panelObjectIdx][i] = item.transform.GetChild(i).GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>();
				this.text_ItemValue[panelObjectIdx][i] = item.transform.GetChild(i).GetChild(1).GetChild(3).GetChild(0).GetComponent<UIText>();
				this.text_ItemTime[panelObjectIdx][i] = item.transform.GetChild(i).GetChild(2).GetChild(1).GetComponent<UIText>();
				this.Img_ItemFrame[panelObjectIdx][i] = item.transform.GetChild(i).GetChild(3).GetComponent<Image>();
			}
		}
		for (int k = 0; k < 3; k++)
		{
			if (this.btn_Delete[panelObjectIdx][k].gameObject.activeSelf)
			{
				this.btn_Delete[panelObjectIdx][k].gameObject.SetActive(false);
			}
			if (dataIdx * 3 + k == this.MM.mScrollFrame)
			{
				this.Img_ItemFrame[panelObjectIdx][k].gameObject.SetActive(true);
				if (dataIdx != 0 && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4 && this.MM.mMobilizationMission[dataIdx * 3 + k].MissionType != 1001)
				{
					this.btn_Delete[panelObjectIdx][k].gameObject.SetActive(true);
				}
			}
			else
			{
				this.Img_ItemFrame[panelObjectIdx][k].gameObject.SetActive(false);
			}
			if (dataIdx * 3 + k == 0)
			{
				if (this.MM.mMissionID == 0)
				{
					this.ItemKind_T[panelObjectIdx][0].gameObject.SetActive(true);
					this.ItemKind_T[panelObjectIdx][1].gameObject.SetActive(false);
					this.ItemKind_T[panelObjectIdx][2].gameObject.SetActive(false);
					this.Img_ItemP1Score[panelObjectIdx][k].gameObject.SetActive(false);
					this.Img_ItemP1OK[panelObjectIdx][k].gameObject.SetActive(false);
					this.text_ItemNoMission[panelObjectIdx][k].gameObject.SetActive(true);
					this.Img_ItemP1Mission[panelObjectIdx][k].gameObject.SetActive(false);
				}
				else
				{
					this.ItemKind_T[panelObjectIdx][0].gameObject.SetActive(true);
					this.ItemKind_T[panelObjectIdx][1].gameObject.SetActive(false);
					this.ItemKind_T[panelObjectIdx][2].gameObject.SetActive(false);
					this.text_ItemNoMission[panelObjectIdx][k].gameObject.SetActive(false);
					this.Img_ItemP1Mission[panelObjectIdx][k].gameObject.SetActive(true);
					this.mMMissionData = this.DM.AllianceMobilizationMission.GetRecordByKey(this.MM.mMissionID);
					CString cstring = StringManager.Instance.StaticString1024();
					cstring.ClearString();
					cstring.IntToFormat((long)this.mMMissionData.MissionIcon, 3, false);
					cstring.AppendFormat("{0}");
					this.Img_ItemP1Icon[panelObjectIdx][k].sprite = this.GUIM.LoadLeagueGO_iconSprite(cstring);
					if (this.GUIM.IsArabic)
					{
						if (this.mMMissionData.MissionIcon == 24 || this.mMMissionData.MissionIcon == 30)
						{
							this.Img_ItemP1Icon[panelObjectIdx][k].rectTransform.localScale = new Vector3(-1f, 1f, 1f);
						}
						else
						{
							this.Img_ItemP1Icon[panelObjectIdx][k].rectTransform.localScale = new Vector3(1f, 1f, 1f);
						}
					}
					if (this.MM.mMissionStatus == 0)
					{
						this.Img_ItemP1Score[panelObjectIdx][k].gameObject.SetActive(true);
						this.Cstr_ItemValue[panelObjectIdx][k].ClearString();
						this.Cstr_ItemValue[panelObjectIdx][k].IntToFormat((long)this.mMMissionData.MissionScore[(int)this.MM.mMissionDifficulty], 1, true);
						if (this.GUIM.IsArabic)
						{
							this.Cstr_ItemValue[panelObjectIdx][k].AppendFormat("{0}+");
						}
						else
						{
							this.Cstr_ItemValue[panelObjectIdx][k].AppendFormat("+{0}");
						}
						this.text_ItemP1Score[panelObjectIdx][k].text = this.Cstr_ItemValue[panelObjectIdx][k].ToString();
						this.text_ItemP1Score[panelObjectIdx][k].SetAllDirty();
						this.text_ItemP1Score[panelObjectIdx][k].cachedTextGenerator.Invalidate();
					}
					else
					{
						this.Img_ItemP1OK[panelObjectIdx][k].gameObject.SetActive(true);
						this.Img_ItemP1Score[panelObjectIdx][k].gameObject.SetActive(false);
						if (this.MM.mMissionStatus == 1)
						{
							this.Img_ItemP1OK[panelObjectIdx][k].sprite = this.SArray.m_Sprites[0];
						}
						else
						{
							this.Img_ItemP1OK[panelObjectIdx][k].sprite = this.SArray.m_Sprites[1];
						}
					}
				}
			}
			else
			{
				this.ItemKind_T[panelObjectIdx][0 + k * 3].gameObject.SetActive(false);
				if (this.MM.mMobilizationMission[dataIdx * 3 + k].MissionType != 1001)
				{
					if (dataIdx * 3 + k == this.MM.mScrollFrame && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
					{
						this.btn_Delete[panelObjectIdx][k].gameObject.SetActive(true);
					}
					this.ItemKind_T[panelObjectIdx][1 + k * 3].gameObject.SetActive(true);
					this.ItemKind_T[panelObjectIdx][2 + k * 3].gameObject.SetActive(false);
					this.mMMissionData = this.DM.AllianceMobilizationMission.GetRecordByKey(this.MM.mMobilizationMission[dataIdx * 3 + k].MissionType);
					CString cstring2 = StringManager.Instance.StaticString1024();
					cstring2.ClearString();
					cstring2.IntToFormat((long)this.mMMissionData.MissionIcon, 3, false);
					cstring2.AppendFormat("{0}");
					this.Img_ItemIcon[panelObjectIdx][k].sprite = this.GUIM.LoadLeagueGO_iconSprite(cstring2);
					if (this.GUIM.IsArabic)
					{
						if (this.mMMissionData.MissionIcon == 24 || this.mMMissionData.MissionIcon == 30)
						{
							this.Img_ItemIcon[panelObjectIdx][k].rectTransform.localScale = new Vector3(-1f, 1f, 1f);
						}
						else
						{
							this.Img_ItemIcon[panelObjectIdx][k].rectTransform.localScale = new Vector3(1f, 1f, 1f);
						}
					}
					this.Cstr_ItemValue[panelObjectIdx][k].ClearString();
					this.Cstr_ItemValue[panelObjectIdx][k].IntToFormat((long)this.mMMissionData.MissionScore[(int)this.MM.mMobilizationMission[dataIdx * 3 + k].Difficulty], 1, true);
					if (this.GUIM.IsArabic)
					{
						this.Cstr_ItemValue[panelObjectIdx][k].AppendFormat("{0}+");
					}
					else
					{
						this.Cstr_ItemValue[panelObjectIdx][k].AppendFormat("+{0}");
					}
					this.text_ItemValue[panelObjectIdx][k].text = this.Cstr_ItemValue[panelObjectIdx][k].ToString();
					this.text_ItemValue[panelObjectIdx][k].SetAllDirty();
					this.text_ItemValue[panelObjectIdx][k].cachedTextGenerator.Invalidate();
				}
				else
				{
					this.ItemKind_T[panelObjectIdx][1 + k * 3].gameObject.SetActive(false);
					this.ItemKind_T[panelObjectIdx][2 + k * 3].gameObject.SetActive(true);
					this.Cstr_ItemTime[panelObjectIdx][k].ClearString();
					this.tmpTime = this.MM.mMobilizationMission[dataIdx * 3 + k].CDTime - this.DM.ServerTime;
					this.Cstr_ItemTime[panelObjectIdx][k].IntToFormat(this.tmpTime / 60L % 60L, 2, false);
					this.Cstr_ItemTime[panelObjectIdx][k].IntToFormat(this.tmpTime % 60L, 2, false);
					this.Cstr_ItemTime[panelObjectIdx][k].AppendFormat("{0}:{1}");
					this.text_ItemTime[panelObjectIdx][k].text = this.Cstr_ItemTime[panelObjectIdx][k].ToString();
					this.text_ItemTime[panelObjectIdx][k].SetAllDirty();
					this.text_ItemTime[panelObjectIdx][k].cachedTextGenerator.Invalidate();
				}
			}
		}
	}

	// Token: 0x06000FEE RID: 4078 RVA: 0x001C2F48 File Offset: 0x001C1148
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06000FEF RID: 4079 RVA: 0x001C2F4C File Offset: 0x001C114C
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
			this.door.OpenMenu(EGUIWindow.UI_Alliance_Mobilization_Info, 0, 0, false);
			break;
		case 2:
			if (this.MM.AllianceError != 0)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1357u), 255, true);
				return;
			}
			this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(1355u), this.DM.mStringTable.GetStringByID(1356u), 2, this.tmpItem[sender.m_BtnID2].m_BtnID1 * 3 + sender.m_BtnID3 - 1, this.DM.mStringTable.GetStringByID(3737u), this.DM.mStringTable.GetStringByID(3736u));
			break;
		case 3:
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (this.tmpItem[i].m_BtnID1 * 3 + j == this.MM.mScrollFrame)
					{
						this.Img_ItemFrame[i][j].gameObject.SetActive(false);
						if (this.btn_Delete[i][j].gameObject.activeSelf)
						{
							this.btn_Delete[i][j].gameObject.SetActive(false);
						}
						break;
					}
				}
			}
			this.MM.mScrollFrame = this.tmpItem[sender.m_BtnID2].m_BtnID1 * 3 + sender.m_BtnID3;
			this.Img_ItemFrame[sender.m_BtnID2][sender.m_BtnID3].gameObject.SetActive(true);
			this.ShowItemF = 0f;
			if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4 && this.MM.mMobilizationMission[this.MM.mScrollFrame].MissionType != 1001)
			{
				this.btn_Delete[sender.m_BtnID2][sender.m_BtnID3].gameObject.SetActive(true);
			}
			this.CheckMissionInfo();
			break;
		case 5:
			this.GUIM.MsgStr.ClearString();
			this.GUIM.MsgStr.IntToFormat((long)this.MM.extraMission, 1, false);
			this.GUIM.MsgStr.IntToFormat((long)this.MM.mextraMissionBuyLimit, 1, false);
			this.GUIM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(1009u));
			GUIManager.Instance.OpenSpendWindow_Normal(this, this.DM.mStringTable.GetStringByID(1349u), this.GUIM.MsgStr.ToString(), (int)this.MM.mextraMissionPrize, 1, 0, this.DM.mStringTable.GetStringByID(1351u), false);
			break;
		case 6:
			if (this.MM.availableMission > 0 && this.MM.AllianceError == 0)
			{
				this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_GET((byte)(this.MM.mScrollFrame - 1));
			}
			else
			{
				if (this.MM.AllianceError != 0)
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1353u), 255, true);
					this.MM.mScrollFrame = 0;
					this.ShowItemF = 0f;
					this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
					this.CheckMissionInfo();
					return;
				}
				if (this.MM.extraMission != 0 && (this.MM.extraMission <= 0 || this.MM.extraMission >= this.MM.mextraMissionBuyLimit))
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1352u), 255, true);
					return;
				}
				this.GUIM.MsgStr.ClearString();
				this.GUIM.MsgStr.IntToFormat((long)this.MM.extraMission, 1, false);
				this.GUIM.MsgStr.IntToFormat((long)this.MM.mextraMissionBuyLimit, 1, false);
				this.GUIM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(1012u));
				this.GUIM.OpenSpendWindow_Normal(this, this.DM.mStringTable.GetStringByID(1349u), this.GUIM.MsgStr.ToString(), (int)this.MM.mextraMissionPrize, 4, 0, this.DM.mStringTable.GetStringByID(1351u), false);
			}
			break;
		case 7:
			this.MM.Send_MSG_REQUEST_ALLIANVEMOBLIZATION_MISSION_FINISH();
			break;
		case 8:
			if (sender.image.color != Color.gray)
			{
				UILeaderBoard.NewOpen = true;
				this.door.OpenMenu(EGUIWindow.UI_LeaderBoard, 5, 0, false);
			}
			break;
		case 9:
			if (sender.image.color != Color.gray)
			{
				UILeaderBoard.NewOpen = true;
				this.door.OpenMenu(EGUIWindow.UI_LeaderBoard, 4, 0, false);
			}
			break;
		case 10:
			if (this.MM.AllianceError != 0)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1595u), 255, true);
			}
			else
			{
				this.door.OpenMenu(EGUIWindow.UI_RewardsSelect, 1, 0, false);
			}
			break;
		case 11:
			this.door.OpenMenu(EGUIWindow.UI_RewardsSelect, 0, 0, false);
			break;
		case 12:
			this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5880u), this.DM.mStringTable.GetStringByID(3668u), 3, 0, this.DM.mStringTable.GetStringByID(3737u), this.DM.mStringTable.GetStringByID(3736u));
			break;
		case 14:
			this.UpdateBonusData(true);
			break;
		case 15:
			this.Tmp_Bonus.gameObject.SetActive(false);
			break;
		case 16:
			if (this.MM.CheckBonusDone() >= 0 && this.MM.AMGoldState == 2)
			{
				this.MM.Send_MSG_REQUEST_ALLIANCE_MOBILIZATION_LEGEND_MISSION_GET_SCORE();
			}
			else
			{
				this.Tmp_Bonus.gameObject.SetActive(false);
			}
			break;
		case 20:
			this.door.OpenMenu(EGUIWindow.UI_AlliMobi_WorldBoard, 0, 0, false);
			break;
		}
	}

	// Token: 0x06000FF0 RID: 4080 RVA: 0x001C3674 File Offset: 0x001C1874
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			switch (arg1)
			{
			case 1:
				if (this.DM.RoleAttr.Diamond >= (uint)this.MM.mextraMissionPrize)
				{
					if (!this.GUIM.OpenCheckCrystal((uint)this.MM.mextraMissionPrize, 8, -1, -1))
					{
						this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_BUY();
					}
				}
				else
				{
					CString cstring = StringManager.Instance.StaticString1024();
					cstring.ClearString();
					cstring.StringToFormat(this.DM.mStringTable.GetStringByID(9144u));
					cstring.AppendFormat(this.DM.mStringTable.GetStringByID(3857u));
					this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966u), cstring.ToString(), this.DM.mStringTable.GetStringByID(3968u), this, 5, 0, true, false, false, false, false);
				}
				break;
			case 2:
				if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
				{
					this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DEL((byte)arg2);
				}
				else
				{
					this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9793u), 255, true);
				}
				break;
			case 3:
				this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DEL(byte.MaxValue);
				break;
			case 4:
				if (this.DM.RoleAttr.Diamond >= (uint)this.MM.mextraMissionPrize)
				{
					if (!this.GUIM.OpenCheckCrystal((uint)this.MM.mextraMissionPrize, 8, -1, -1))
					{
						this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_BUY();
					}
					this.bStartAddSend = true;
				}
				else
				{
					CString cstring2 = StringManager.Instance.StaticString1024();
					cstring2.ClearString();
					cstring2.StringToFormat(this.DM.mStringTable.GetStringByID(9144u));
					cstring2.AppendFormat(this.DM.mStringTable.GetStringByID(3857u));
					this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966u), cstring2.ToString(), this.DM.mStringTable.GetStringByID(3968u), this, 5, 0, true, false, false, false, false);
				}
				break;
			}
		}
	}

	// Token: 0x06000FF1 RID: 4081 RVA: 0x001C38E4 File Offset: 0x001C1AE4
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		Mobilization_btn btnID = (Mobilization_btn)uibutton.m_BtnID1;
		switch (btnID)
		{
		case Mobilization_btn.btn_RankHint:
		{
			uint id = 1028u - (uint)this.DM.RoleAlliance.AMRank;
			this.Cstr_RankHint.ClearString();
			this.Cstr_RankHint.Append(this.DM.mStringTable.GetStringByID(id));
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.Cstr_RankHint, Vector2.zero);
			break;
		}
		default:
			if (btnID == Mobilization_btn.btn_Hint)
			{
				this.Img_Hint.gameObject.SetActive(true);
			}
			break;
		case Mobilization_btn.btn_BonusHint1:
		case Mobilization_btn.btn_BonusHint2:
		case Mobilization_btn.btn_BonusHint3:
			this.SetBonusHint(uibutton, sender);
			break;
		}
	}

	// Token: 0x06000FF2 RID: 4082 RVA: 0x001C39C0 File Offset: 0x001C1BC0
	public void OnButtonUp(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		Mobilization_btn btnID = (Mobilization_btn)uibutton.m_BtnID1;
		switch (btnID)
		{
		case Mobilization_btn.btn_RankHint:
			GUIManager.Instance.m_Hint.Hide(true);
			break;
		default:
			if (btnID == Mobilization_btn.btn_Hint)
			{
				if (this.Img_Hint.IsActive())
				{
					this.Img_Hint.gameObject.SetActive(false);
				}
			}
			break;
		case Mobilization_btn.btn_BonusHint1:
		case Mobilization_btn.btn_BonusHint2:
		case Mobilization_btn.btn_BonusHint3:
			if (this.Img_BonusHint.IsActive())
			{
				this.Img_BonusHint.gameObject.SetActive(false);
			}
			break;
		}
	}

	// Token: 0x06000FF3 RID: 4083 RVA: 0x001C3A74 File Offset: 0x001C1C74
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 0:
			this.CheckInfo();
			if (this.MM.involvedMember != 255)
			{
				this.Cstr_NowScore.ClearString();
				StringManager.IntToStr(this.Cstr_NowScore, (long)((ulong)this.MM.AMScore), 1, true);
				this.text_NowScore[1].text = this.Cstr_NowScore.ToString();
				this.text_NowScore[1].SetAllDirty();
				this.text_NowScore[1].cachedTextGenerator.Invalidate();
				this.Cstr_NextScore.ClearString();
				if ((int)this.MM.AMCompleteDegree < this.tmpItemNum)
				{
					StringManager.IntToStr(this.Cstr_NextScore, (long)((ulong)(this.MM.CompleteScore - this.MM.AMScore)), 1, true);
				}
				else
				{
					StringManager.IntToStr(this.Cstr_NextScore, 0L, 1, true);
				}
				this.text_NextScore[1].text = this.Cstr_NextScore.ToString();
				this.text_NextScore[1].SetAllDirty();
				this.text_NextScore[1].cachedTextGenerator.Invalidate();
				this.Cstr_Lv.ClearString();
				StringManager.IntToStr(this.Cstr_Lv, (long)this.MM.AMCompleteDegree, 1, false);
				this.text_Lv.text = this.Cstr_Lv.ToString();
				this.text_Lv.SetAllDirty();
				this.text_Lv.cachedTextGenerator.Invalidate();
				this.Cstr_LvValue.ClearString();
				if ((int)this.MM.AMCompleteDegree == this.tmpItemNum)
				{
					this.mMDData = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex((int)(this.MM.AMCompleteDegree - 1));
					StringManager.IntToStr(this.Cstr_LvValue, (long)((ulong)this.mMDData.MissionDegreeScore), 1, true);
					this.text_LvValue.color = new Color(1f, 0.945f, 0.204f);
				}
				else
				{
					StringManager.IntToStr(this.Cstr_LvValue, (long)((ulong)this.MM.CompleteScore), 1, true);
				}
				this.text_LvValue.text = this.Cstr_LvValue.ToString();
				this.text_LvValue.SetAllDirty();
				this.text_LvValue.cachedTextGenerator.Invalidate();
				if (this.MM.CompleteScore != 0u)
				{
					if (this.MM.AMCompleteDegree == 0)
					{
						this.Img_LvBar_RT.sizeDelta = new Vector2((float)(214.0 * (this.MM.AMScore / this.MM.CompleteScore)), this.Img_LvBar_RT.sizeDelta.y);
						this.Img_Bar[0].rectTransform.anchoredPosition = new Vector2(11.5f + (float)(214.0 * (this.MM.AMScore / this.MM.CompleteScore)), this.Img_Bar[0].rectTransform.anchoredPosition.y);
					}
					else
					{
						this.mMDData = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex((int)(this.MM.AMCompleteDegree - 1));
						if (this.mMDData.MissionDegreeScore == this.MM.AMScore)
						{
							this.Img_LvBar_RT.sizeDelta = new Vector2(0f, this.Img_LvBar_RT.sizeDelta.y);
							this.Img_Bar[0].rectTransform.anchoredPosition = new Vector2(11.5f, this.Img_Bar[0].rectTransform.anchoredPosition.y);
						}
						else
						{
							this.Img_LvBar_RT.sizeDelta = new Vector2((float)(214.0 * ((this.MM.AMScore - this.mMDData.MissionDegreeScore) / (this.MM.CompleteScore - this.mMDData.MissionDegreeScore))), this.Img_LvBar_RT.sizeDelta.y);
							this.Img_Bar[0].rectTransform.anchoredPosition = new Vector2(11.5f + 214f * (float)((this.MM.AMScore - this.mMDData.MissionDegreeScore) / (this.MM.CompleteScore - this.mMDData.MissionDegreeScore)), this.Img_Bar[0].rectTransform.anchoredPosition.y);
						}
					}
				}
				else
				{
					this.Img_LvBar_RT.sizeDelta = new Vector2(0f, this.Img_LvBar_RT.sizeDelta.y);
				}
				if ((int)this.MM.AMCompleteDegree == this.tmpItemNum)
				{
					this.Img_LVMax.gameObject.SetActive(true);
					this.Img_LvBar_RT.sizeDelta = new Vector2(214f, this.Img_LvBar_RT.sizeDelta.y);
					this.Img_Bar[0].rectTransform.anchoredPosition = new Vector2(225.5f, this.Img_Bar[0].rectTransform.anchoredPosition.y);
				}
				this.Cstr_MobilizationNum.ClearString();
				this.Cstr_MobilizationNum.IntToFormat((long)this.MM.involvedMember, 1, false);
				this.Cstr_MobilizationNum.AppendFormat(this.DM.mStringTable.GetStringByID(1340u));
				this.text_MobilizationNum.text = this.Cstr_MobilizationNum.ToString();
				this.text_MobilizationNum.SetAllDirty();
				this.text_MobilizationNum.cachedTextGenerator.Invalidate();
				this.Cstr_Hint.ClearString();
				this.Cstr_Hint.IntToFormat((long)this.MM.involvedMember, 1, false);
				this.Cstr_Hint.AppendFormat(this.DM.mStringTable.GetStringByID(1341u));
				this.text_Hint.text = this.Cstr_Hint.ToString();
				this.text_Hint.SetAllDirty();
				this.text_Hint.cachedTextGenerator.Invalidate();
				this.text_Hint.cachedTextGeneratorForLayout.Invalidate();
				if (this.text_Hint.preferredHeight > this.text_Hint.rectTransform.sizeDelta.y)
				{
					this.text_Hint.rectTransform.sizeDelta = new Vector2(this.text_Hint.rectTransform.sizeDelta.x, this.text_Hint.preferredHeight + 1f);
					this.Img_Hint.rectTransform.sizeDelta = new Vector2(this.Img_Hint.rectTransform.sizeDelta.x, this.text_Hint.preferredHeight + 11f);
				}
				this.tmplist.Clear();
				for (int i = 0; i < 7; i++)
				{
					this.tmplist.Add(224f);
				}
				this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
				this.Cstr_TimeBar.ClearString();
				long num = this.MM.mMissionTime - this.DM.ServerTime;
				this.mMMissionData = this.DM.AllianceMobilizationMission.GetRecordByKey(this.MM.mMissionID);
				double num2 = (double)(this.mMMissionData.MissionTime[(int)this.MM.mMissionDifficulty] * 3600);
				this.Img_MissionBar_RT.sizeDelta = new Vector2(259f * (float)((num2 - (double)num) / num2), this.Img_MissionBar_RT.sizeDelta.y);
				if (num > 86400L)
				{
					this.Cstr_TimeBar.IntToFormat(num / 86400L, 1, false);
					num %= 86400L;
					this.Cstr_TimeBar.IntToFormat(num / 3600L, 2, false);
					num %= 3600L;
					this.Cstr_TimeBar.IntToFormat(num / 60L, 2, false);
					num %= 60L;
					this.Cstr_TimeBar.IntToFormat(num, 2, false);
					this.Cstr_TimeBar.AppendFormat("{0}d {1}:{2}:{3}");
				}
				else
				{
					this.Cstr_TimeBar.IntToFormat(num / 3600L, 2, false);
					num %= 3600L;
					this.Cstr_TimeBar.IntToFormat(num / 60L, 2, false);
					num %= 60L;
					this.Cstr_TimeBar.IntToFormat(num, 2, false);
					this.Cstr_TimeBar.AppendFormat("{0}:{1}:{2}");
				}
				this.text_TimeBar.text = this.Cstr_TimeBar.ToString();
				this.text_TimeBar.SetAllDirty();
				this.text_TimeBar.cachedTextGenerator.Invalidate();
			}
			break;
		default:
			if (arg1 == 99)
			{
				Array.Clear(this.GUIM.SE_Kind, 0, this.GUIM.SE_Kind.Length);
				Array.Clear(this.GUIM.m_SpeciallyEffect.mResValue, 0, this.GUIM.m_SpeciallyEffect.mResValue.Length);
				Array.Clear(this.GUIM.SE_ItemID, 0, this.GUIM.SE_ItemID.Length);
				for (int j = 0; j < 3; j++)
				{
					if (this.MM.RSAnimationItemID[j] != 0)
					{
						this.GUIM.SE_ItemID[j] = this.MM.RSAnimationItemID[j];
					}
				}
				int num3 = 0;
				if (this.MM.PrizeCrystal != 0u)
				{
					this.GUIM.m_SpeciallyEffect.mDiamondValue = this.MM.PrizeCrystal;
					this.GUIM.SE_Kind[num3] = SpeciallyEffect_Kind.Diamond;
					num3++;
				}
				if (this.MM.PrizeAllianceMoney != 0u)
				{
					this.GUIM.SE_Kind[num3] = SpeciallyEffect_Kind.AllianceMoney;
				}
				this.GUIM.mStartV2 = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + 259.5f, this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f + 101f);
				this.GUIM.m_SpeciallyEffect.AddIconShow(this.GUIM.mStartV2, this.GUIM.SE_Kind, this.GUIM.SE_ItemID, true);
				this.tmpAddTime = 0.6f;
				this.tmpAddCount = 1;
			}
			break;
		case 2:
			this.Cstr_NowScore.ClearString();
			StringManager.IntToStr(this.Cstr_NowScore, (long)((ulong)this.MM.AMScore), 1, true);
			this.text_NowScore[1].text = this.Cstr_NowScore.ToString();
			this.text_NowScore[1].SetAllDirty();
			this.text_NowScore[1].cachedTextGenerator.Invalidate();
			this.Cstr_NextScore.ClearString();
			if ((int)this.MM.AMCompleteDegree < this.tmpItemNum)
			{
				StringManager.IntToStr(this.Cstr_NextScore, (long)((ulong)(this.MM.CompleteScore - this.MM.AMScore)), 1, true);
			}
			else
			{
				StringManager.IntToStr(this.Cstr_NextScore, 0L, 1, true);
			}
			this.text_NextScore[1].text = this.Cstr_NextScore.ToString();
			this.text_NextScore[1].SetAllDirty();
			this.text_NextScore[1].cachedTextGenerator.Invalidate();
			this.Cstr_Lv.ClearString();
			StringManager.IntToStr(this.Cstr_Lv, (long)this.MM.AMCompleteDegree, 1, false);
			this.text_Lv.text = this.Cstr_Lv.ToString();
			this.text_Lv.SetAllDirty();
			this.text_Lv.cachedTextGenerator.Invalidate();
			this.Cstr_LvValue.ClearString();
			if ((int)this.MM.AMCompleteDegree == this.tmpItemNum)
			{
				this.mMDData = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex((int)(this.MM.AMCompleteDegree - 1));
				StringManager.IntToStr(this.Cstr_LvValue, (long)((ulong)this.mMDData.MissionDegreeScore), 1, true);
				this.text_LvValue.color = new Color(1f, 0.945f, 0.204f);
			}
			else
			{
				StringManager.IntToStr(this.Cstr_LvValue, (long)((ulong)this.MM.CompleteScore), 1, true);
			}
			this.text_LvValue.text = this.Cstr_LvValue.ToString();
			this.text_LvValue.SetAllDirty();
			this.text_LvValue.cachedTextGenerator.Invalidate();
			if (this.MM.CompleteScore != 0u)
			{
				if (this.MM.AMCompleteDegree == 0)
				{
					this.Img_LvBar_RT.sizeDelta = new Vector2((float)(214.0 * (this.MM.AMScore / this.MM.CompleteScore)), this.Img_LvBar_RT.sizeDelta.y);
					this.Img_Bar[0].rectTransform.anchoredPosition = new Vector2(11.5f + (float)(214.0 * (this.MM.AMScore / this.MM.CompleteScore)), this.Img_Bar[0].rectTransform.anchoredPosition.y);
				}
				else
				{
					this.mMDData = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex((int)(this.MM.AMCompleteDegree - 1));
					if (this.mMDData.MissionDegreeScore == this.MM.AMScore)
					{
						this.Img_LvBar_RT.sizeDelta = new Vector2(0f, this.Img_LvBar_RT.sizeDelta.y);
						this.Img_Bar[0].rectTransform.anchoredPosition = new Vector2(11.5f, this.Img_Bar[0].rectTransform.anchoredPosition.y);
					}
					else
					{
						this.Img_LvBar_RT.sizeDelta = new Vector2((float)(214.0 * ((this.MM.AMScore - this.mMDData.MissionDegreeScore) / (this.MM.CompleteScore - this.mMDData.MissionDegreeScore))), this.Img_LvBar_RT.sizeDelta.y);
						this.Img_Bar[0].rectTransform.anchoredPosition = new Vector2(11.5f + 214f * (float)((this.MM.AMScore - this.mMDData.MissionDegreeScore) / (this.MM.CompleteScore - this.mMDData.MissionDegreeScore)), this.Img_Bar[0].rectTransform.anchoredPosition.y);
					}
				}
			}
			else
			{
				this.Img_LvBar_RT.sizeDelta = new Vector2(0f, this.Img_LvBar_RT.sizeDelta.y);
			}
			if ((int)this.MM.AMCompleteDegree == this.tmpItemNum)
			{
				this.Img_LVMax.gameObject.SetActive(true);
				this.Img_LvBar_RT.sizeDelta = new Vector2(214f, this.Img_LvBar_RT.sizeDelta.y);
				this.Img_Bar[0].rectTransform.anchoredPosition = new Vector2(225.5f, this.Img_Bar[0].rectTransform.anchoredPosition.y);
			}
			break;
		case 3:
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			if (arg2 == this.MM.mScrollFrame)
			{
				this.CheckMissionInfo();
			}
			break;
		case 4:
			if (this.MM.involvedMember != 255)
			{
				this.Cstr_MobilizationNum.ClearString();
				this.Cstr_MobilizationNum.IntToFormat((long)this.MM.involvedMember, 1, false);
				this.Cstr_MobilizationNum.AppendFormat(this.DM.mStringTable.GetStringByID(1340u));
				this.text_MobilizationNum.text = this.Cstr_MobilizationNum.ToString();
				this.text_MobilizationNum.SetAllDirty();
				this.text_MobilizationNum.cachedTextGenerator.Invalidate();
				this.Cstr_Hint.ClearString();
				this.Cstr_Hint.IntToFormat((long)this.MM.involvedMember, 1, false);
				this.Cstr_Hint.AppendFormat(this.DM.mStringTable.GetStringByID(1341u));
				this.text_Hint.text = this.Cstr_Hint.ToString();
				this.text_Hint.SetAllDirty();
				this.text_Hint.cachedTextGenerator.Invalidate();
				this.text_Hint.cachedTextGeneratorForLayout.Invalidate();
				if (this.text_Hint.preferredHeight > this.text_Hint.rectTransform.sizeDelta.y)
				{
					this.text_Hint.rectTransform.sizeDelta = new Vector2(this.text_Hint.rectTransform.sizeDelta.x, this.text_Hint.preferredHeight + 1f);
					this.Img_Hint.rectTransform.sizeDelta = new Vector2(this.Img_Hint.rectTransform.sizeDelta.x, this.Img_Hint.preferredHeight + 11f);
				}
			}
			break;
		case 5:
			if (this.AM.AllyMobilizationData.EventState == EActivityState.EAS_Prepare)
			{
				this.CheckInfo();
			}
			break;
		case 6:
			if ((this.AM.AllyMobilizationData.EventState == EActivityState.EAS_Run || this.AM.AllyMobilizationData.EventState == EActivityState.EAS_ReplayRanking) && this.MM.bFirstOpen && this.DM.RoleAlliance.Id != 0u)
			{
				this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DATA();
				this.MM.bFirstOpen = false;
			}
			else
			{
				this.CheckInfo();
			}
			break;
		case 7:
			if (this.MM.mScrollFrame == 0)
			{
				this.mMMissionData = this.DM.AllianceMobilizationMission.GetRecordByKey(this.MM.mMissionID);
				this.Cstr_Info[0].ClearString();
				if (this.mMMissionData.MissionType == 41 || this.mMMissionData.MissionType == 71)
				{
					CString cstring = StringManager.Instance.StaticString1024();
					cstring.ClearString();
					if (this.MM.mMissionTarget / 1440u > 0u)
					{
						cstring.IntToFormat((long)((ulong)(this.MM.mMissionTarget / 1440u)), 1, false);
						cstring.IntToFormat((long)((ulong)(this.MM.mMissionTarget % 1440u / 60u)), 2, false);
						cstring.IntToFormat((long)((ulong)(this.MM.mMissionTarget % 60u)), 2, false);
						cstring.IntToFormat(0L, 2, false);
						cstring.AppendFormat("{0}d {1}:{2}:{3}");
					}
					else
					{
						cstring.IntToFormat((long)((ulong)(this.MM.mMissionTarget / 60u)), 2, false);
						cstring.IntToFormat((long)((ulong)(this.MM.mMissionTarget % 60u)), 2, false);
						cstring.IntToFormat(0L, 2, false);
						cstring.AppendFormat("{0}:{1}:{2}");
					}
					CString cstring2 = StringManager.Instance.StaticString1024();
					cstring2.ClearString();
					if (this.mMMissionData.MissionMaxValue[(int)this.MM.mMissionDifficulty] / 1440u > 0u)
					{
						cstring2.IntToFormat((long)((ulong)(this.mMMissionData.MissionMaxValue[(int)this.MM.mMissionDifficulty] / 1440u)), 1, false);
						if (this.mMMissionData.MissionMaxValue[(int)this.MM.mMissionDifficulty] % 1440u == 0u)
						{
							cstring2.AppendFormat("{0}d");
						}
						else
						{
							cstring2.IntToFormat((long)((ulong)(this.mMMissionData.MissionMaxValue[(int)this.MM.mMissionDifficulty] % 1440u / 60u)), 2, false);
							cstring2.IntToFormat((long)((ulong)(this.mMMissionData.MissionMaxValue[(int)this.MM.mMissionDifficulty] % 60u)), 2, false);
							cstring2.IntToFormat(0L, 2, false);
							cstring2.AppendFormat("{0}d {1}:{2}:{3}");
						}
					}
					else
					{
						cstring2.IntToFormat((long)((ulong)(this.mMMissionData.MissionMaxValue[(int)this.MM.mMissionDifficulty] / 60u)), 2, false);
						cstring2.IntToFormat((long)((ulong)(this.mMMissionData.MissionMaxValue[(int)this.MM.mMissionDifficulty] % 60u)), 2, false);
						cstring2.IntToFormat(0L, 2, false);
						cstring2.AppendFormat("{0}:{1}:{2}");
					}
					this.Cstr_Info[0].StringToFormat(cstring);
					this.Cstr_Info[0].StringToFormat(cstring2);
				}
				else
				{
					this.Cstr_Info[0].IntToFormat((long)((ulong)this.MM.mMissionTarget), 1, true);
					this.Cstr_Info[0].IntToFormat((long)((ulong)this.mMMissionData.MissionMaxValue[(int)this.MM.mMissionDifficulty]), 1, true);
				}
				if (this.GUIM.IsArabic)
				{
					this.Cstr_Info[0].AppendFormat("{1} / {0}");
				}
				else
				{
					this.Cstr_Info[0].AppendFormat("{0} / {1}");
				}
				this.text_Info[1].text = this.Cstr_Info[0].ToString();
				this.text_Info[1].SetAllDirty();
				this.text_Info[1].cachedTextGenerator.Invalidate();
			}
			break;
		case 8:
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			this.CheckMissionInfo();
			break;
		case 9:
			this.MM.mScrollFrame = 0;
			this.ShowItemF = 0f;
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, true, true);
			this.CheckMissionInfo();
			if (arg2 == 1)
			{
				float num4 = 0f;
				if (this.GUIM.bOpenOnIPhoneX)
				{
					num4 = this.GUIM.IPhoneX_DeltaX;
				}
				this.GUIM.mStartV2 = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + 217.5f, this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - 21f);
				this.GUIM.m_SpeciallyEffect.UI_bezieEnd = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + 125f - num4, -(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - 150f));
				this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.MobilizationMission, 0, 0, true, 2f);
			}
			break;
		case 10:
			this.CheckMissionInfo();
			if (this.bStartAddSend)
			{
				this.OnButtonClick(this.btn_Start);
			}
			this.bStartAddSend = false;
			break;
		case 11:
			if (this.DM.RoleAlliance.AMRank > 0 && (int)(this.DM.RoleAlliance.AMRank + 3) < this.SArray.m_Sprites.Length)
			{
				this.Img_TitleBG.sprite = this.SArray.m_Sprites[(int)(this.DM.RoleAlliance.AMRank + 3)];
			}
			this.GUIM.SetAllyRankImage(this.Img_AllianceRankBG, this.DM.RoleAlliance.AMRank);
			this.CheckInfo();
			break;
		case 12:
			this.UpdateBonusData(false);
			break;
		case 13:
			if (arg2 == 0)
			{
				float num5 = 0f;
				if (this.GUIM.bOpenOnIPhoneX)
				{
					num5 = this.GUIM.IPhoneX_DeltaX;
				}
				this.GUIM.mStartV2 = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f - 30f, this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f + 90f);
				this.GUIM.m_SpeciallyEffect.UI_bezieEnd = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + 125f - num5, -(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - 150f));
				this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.MobilizationMission, 0, 0, true, 2f);
			}
			this.UpdateBonusData(false);
			break;
		}
	}

	// Token: 0x06000FF4 RID: 4084 RVA: 0x001C53B4 File Offset: 0x001C35B4
	public override bool OnBackButtonClick()
	{
		if (this.Tmp_Bonus.gameObject.activeSelf)
		{
			this.Tmp_Bonus.gameObject.SetActive(false);
			return true;
		}
		return false;
	}

	// Token: 0x06000FF5 RID: 4085 RVA: 0x001C53EC File Offset: 0x001C35EC
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Alliance)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else if (this.DM.RoleAlliance.Id == 0u)
			{
				this.door.CloseMenu(false);
				return;
			}
		}
		else if ((this.AM.AllyMobilizationData.EventState == EActivityState.EAS_Run || this.AM.AllyMobilizationData.EventState == EActivityState.EAS_ReplayRanking) && this.DM.RoleAlliance.Id != 0u)
		{
			this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DATA();
		}
		else if (this.AM.AllyMobilizationData.EventState == EActivityState.EAS_None)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06000FF6 RID: 4086 RVA: 0x001C54C4 File Offset: 0x001C36C4
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_MobilizationNum != null && this.text_MobilizationNum.enabled)
		{
			this.text_MobilizationNum.enabled = false;
			this.text_MobilizationNum.enabled = true;
		}
		if (this.text_MissionCount != null && this.text_MissionCount.enabled)
		{
			this.text_MissionCount.enabled = false;
			this.text_MissionCount.enabled = true;
		}
		if (this.text_Lv != null && this.text_Lv.enabled)
		{
			this.text_Lv.enabled = false;
			this.text_Lv.enabled = true;
		}
		if (this.text_LvValue != null && this.text_LvValue.enabled)
		{
			this.text_LvValue.enabled = false;
			this.text_LvValue.enabled = true;
		}
		if (this.text_Kind != null && this.text_Kind.enabled)
		{
			this.text_Kind.enabled = false;
			this.text_Kind.enabled = true;
		}
		if (this.text_Kind1 != null && this.text_Kind1.enabled)
		{
			this.text_Kind1.enabled = false;
			this.text_Kind1.enabled = true;
		}
		if (this.text_MissionTime != null && this.text_MissionTime.enabled)
		{
			this.text_MissionTime.enabled = false;
			this.text_MissionTime.enabled = true;
		}
		if (this.text_Missionstatus != null && this.text_Missionstatus.enabled)
		{
			this.text_Missionstatus.enabled = false;
			this.text_Missionstatus.enabled = true;
		}
		if (this.text_Empty != null && this.text_Empty.enabled)
		{
			this.text_Empty.enabled = false;
			this.text_Empty.enabled = true;
		}
		if (this.text_Hint != null && this.text_Hint.enabled)
		{
			this.text_Hint.enabled = false;
			this.text_Hint.enabled = true;
		}
		if (this.text_Start != null && this.text_Start.enabled)
		{
			this.text_Start.enabled = false;
			this.text_Start.enabled = true;
		}
		if (this.text_Report != null && this.text_Report.enabled)
		{
			this.text_Report.enabled = false;
			this.text_Report.enabled = true;
		}
		if (this.text_GiveUp != null && this.text_GiveUp.enabled)
		{
			this.text_GiveUp.enabled = false;
			this.text_GiveUp.enabled = true;
		}
		if (this.text_RewardTitle != null && this.text_RewardTitle.enabled)
		{
			this.text_RewardTitle.enabled = false;
			this.text_RewardTitle.enabled = true;
		}
		if (this.text_GetRewardTime != null && this.text_GetRewardTime.enabled)
		{
			this.text_GetRewardTime.enabled = false;
			this.text_GetRewardTime.enabled = true;
		}
		if (this.text_AllianceReward != null && this.text_AllianceReward.enabled)
		{
			this.text_AllianceReward.enabled = false;
			this.text_AllianceReward.enabled = true;
		}
		if (this.text_RewardNum != null && this.text_RewardNum.enabled)
		{
			this.text_RewardNum.enabled = false;
			this.text_RewardNum.enabled = true;
		}
		if (this.text_Rewardstr != null && this.text_Rewardstr.enabled)
		{
			this.text_Rewardstr.enabled = false;
			this.text_Rewardstr.enabled = true;
		}
		if (this.text_RewardOK != null && this.text_RewardOK.enabled)
		{
			this.text_RewardOK.enabled = false;
			this.text_RewardOK.enabled = true;
		}
		if (this.text_TimeBar != null && this.text_TimeBar.enabled)
		{
			this.text_TimeBar.enabled = false;
			this.text_TimeBar.enabled = true;
		}
		if (this.text_Resultstr != null && this.text_Resultstr.enabled)
		{
			this.text_Resultstr.enabled = false;
			this.text_Resultstr.enabled = true;
		}
		if (this.text_Result != null && this.text_Result.enabled)
		{
			this.text_Result.enabled = false;
			this.text_Result.enabled = true;
		}
		if (this.text_BonusReward != null && this.text_BonusReward.enabled)
		{
			this.text_BonusReward.enabled = false;
			this.text_BonusReward.enabled = true;
		}
		if (this.text_BonusHint != null && this.text_BonusHint.enabled)
		{
			this.text_BonusHint.enabled = false;
			this.text_BonusHint.enabled = true;
		}
		if (this.text_BonusGet != null && this.text_BonusGet.enabled)
		{
			this.text_BonusGet.enabled = false;
			this.text_BonusGet.enabled = true;
		}
		if (this.text_BonusGet2 != null && this.text_BonusGet2.enabled)
		{
			this.text_BonusGet2.enabled = false;
			this.text_BonusGet2.enabled = true;
		}
		if (this.text_BonusDone != null && this.text_BonusDone.enabled)
		{
			this.text_BonusDone.enabled = false;
			this.text_BonusDone.enabled = true;
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.bonusHint[i].text_Record != null && this.bonusHint[i].text_Record.enabled)
			{
				this.bonusHint[i].text_Record.enabled = false;
				this.bonusHint[i].text_Record.enabled = true;
			}
		}
		for (int j = 0; j < 2; j++)
		{
			if (this.text_Time[j] != null && this.text_Time[j].enabled)
			{
				this.text_Time[j].enabled = false;
				this.text_Time[j].enabled = true;
			}
			if (this.text_NowScore[j] != null && this.text_NowScore[j].enabled)
			{
				this.text_NowScore[j].enabled = false;
				this.text_NowScore[j].enabled = true;
			}
			if (this.text_NextScore[j] != null && this.text_NextScore[j].enabled)
			{
				this.text_NextScore[j].enabled = false;
				this.text_NextScore[j].enabled = true;
			}
			if (this.text_MissionCDTime[j] != null && this.text_MissionCDTime[j].enabled)
			{
				this.text_MissionCDTime[j].enabled = false;
				this.text_MissionCDTime[j].enabled = true;
			}
		}
		for (int k = 0; k < 3; k++)
		{
			if (this.text_Info[k] != null && this.text_Info[k].enabled)
			{
				this.text_Info[k].enabled = false;
				this.text_Info[k].enabled = true;
			}
			for (int l = 0; l < 3; l++)
			{
				if (this.text_ItemTime[k][l] != null && this.text_ItemTime[k][l].enabled)
				{
					this.text_ItemTime[k][l].enabled = false;
					this.text_ItemTime[k][l].enabled = true;
				}
				if (this.text_ItemValue[k][l] != null && this.text_ItemValue[k][l].enabled)
				{
					this.text_ItemValue[k][l].enabled = false;
					this.text_ItemValue[k][l].enabled = true;
				}
				if (this.text_ItemP1Score[k][l] != null && this.text_ItemP1Score[k][l].enabled)
				{
					this.text_ItemP1Score[k][l].enabled = false;
					this.text_ItemP1Score[k][l].enabled = true;
				}
				if (this.text_ItemNoMission[k][l] != null && this.text_ItemNoMission[k][l].enabled)
				{
					this.text_ItemNoMission[k][l].enabled = false;
					this.text_ItemNoMission[k][l].enabled = true;
				}
			}
		}
	}

	// Token: 0x06000FF7 RID: 4087 RVA: 0x001C5E14 File Offset: 0x001C4014
	public override void UpdateTime(bool bOnSecond)
	{
		if (!this.bOpenEnd)
		{
			return;
		}
		this.RankObj.UpdateTime(bOnSecond);
		if (bOnSecond)
		{
			this.CheckMissionCD();
			if (this.text_Time[1] != null && this.text_Time[1].gameObject.activeSelf)
			{
				this.Cstr_ActivityTime.ClearString();
				if (this.AM.AllyMobilizationData.EventCountTime > 86400L)
				{
					this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime / 86400L, 1, false);
					this.Cstr_ActivityTime.AppendFormat("{0}d");
				}
				else
				{
					this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime / 3600L, 2, false);
					this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime % 3600L / 60L, 2, false);
					this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime % 60L, 2, false);
					this.Cstr_ActivityTime.AppendFormat("{0}:{1}:{2}");
				}
				this.text_Time[1].text = this.Cstr_ActivityTime.ToString();
				this.text_Time[1].SetAllDirty();
				this.text_Time[1].cachedTextGenerator.Invalidate();
			}
			if (this.Img_MissionCDTime != null && this.text_MissionCDTime[1] != null && this.Img_MissionCDTime.gameObject.activeSelf)
			{
				this.Cstr_MissionCDTime.ClearString();
				long num = this.MM.mMobilizationMission[this.MM.mScrollFrame].CDTime - this.DM.ServerTime;
				if (num < 0L)
				{
					num = 0L;
				}
				this.Cstr_MissionCDTime.IntToFormat(num / 60L, 2, false);
				this.Cstr_MissionCDTime.IntToFormat(num % 60L, 2, false);
				this.Cstr_MissionCDTime.AppendFormat("{0}:{1}");
				this.text_MissionCDTime[1].text = this.Cstr_MissionCDTime.ToString();
				this.text_MissionCDTime[1].SetAllDirty();
				this.text_MissionCDTime[1].cachedTextGenerator.Invalidate();
			}
			if (this.Img_MissionBar_RT != null && this.Img_MissionBar_RT.parent != null && this.text_TimeBar != null && this.Img_MissionBar_RT.parent.gameObject.activeSelf)
			{
				this.Cstr_TimeBar.ClearString();
				long num = this.MM.mMissionTime - this.DM.ServerTime;
				this.mMMissionData = this.DM.AllianceMobilizationMission.GetRecordByKey(this.MM.mMissionID);
				double num2 = (double)(this.mMMissionData.MissionTime[(int)this.MM.mMissionDifficulty] * 3600);
				this.Img_MissionBar_RT.sizeDelta = new Vector2(259f * (float)((num2 - (double)num) / num2), this.Img_MissionBar_RT.sizeDelta.y);
				if (num > 86400L)
				{
					this.Cstr_TimeBar.IntToFormat(num / 86400L, 1, false);
					num %= 86400L;
					this.Cstr_TimeBar.IntToFormat(num / 3600L, 2, false);
					num %= 3600L;
					this.Cstr_TimeBar.IntToFormat(num / 60L, 2, false);
					num %= 60L;
					this.Cstr_TimeBar.IntToFormat(num, 2, false);
					this.Cstr_TimeBar.AppendFormat("{0}d {1}:{2}:{3}");
				}
				else
				{
					if (num < 0L)
					{
						num = 0L;
					}
					this.Cstr_TimeBar.IntToFormat(num / 3600L, 2, false);
					num %= 3600L;
					this.Cstr_TimeBar.IntToFormat(num / 60L, 2, false);
					num %= 60L;
					this.Cstr_TimeBar.IntToFormat(num, 2, false);
					this.Cstr_TimeBar.AppendFormat("{0}:{1}:{2}");
				}
				this.text_TimeBar.text = this.Cstr_TimeBar.ToString();
				this.text_TimeBar.SetAllDirty();
				this.text_TimeBar.cachedTextGenerator.Invalidate();
			}
			if (this.Img_ActivityEnd != null && this.Img_ActivityEnd.gameObject.activeSelf && this.text_GetRewardTime != null)
			{
				this.Cstr_GetRewardTime.ClearString();
				long num = this.AM.AllyMobilizationData.EventCountTime;
				if (num < 0L)
				{
					num = 0L;
				}
				if (num > 86400L)
				{
					this.Cstr_GetRewardTime.IntToFormat(num / 86400L, 1, false);
					this.Cstr_GetRewardTime.AppendFormat("{0}d");
				}
				else
				{
					this.Cstr_GetRewardTime.IntToFormat(num / 3600L, 2, false);
					this.Cstr_GetRewardTime.IntToFormat(num % 3600L / 60L, 2, false);
					this.Cstr_GetRewardTime.IntToFormat(num % 60L, 2, false);
					this.Cstr_GetRewardTime.AppendFormat("{0}:{1}:{2}");
				}
				this.text_GetRewardTime.text = this.Cstr_GetRewardTime.ToString();
				this.text_GetRewardTime.SetAllDirty();
				this.text_GetRewardTime.cachedTextGenerator.Invalidate();
			}
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (this.tmpItem[i] != null && this.tmpItem[i].m_BtnID1 >= 0 && this.tmpItem[i].m_BtnID1 < 7 && 2 + j * 3 < 9 && this.ItemKind_T[i][2 + j * 3] != null && this.ItemKind_T[i][2 + j * 3].gameObject.activeSelf && this.text_ItemTime[i][j] != null)
					{
						long num = this.MM.mMobilizationMission[this.tmpItem[i].m_BtnID1 * 3 + j].CDTime - this.DM.ServerTime;
						this.Cstr_ItemTime[i][j].ClearString();
						if (num < 0L)
						{
							num = 0L;
						}
						this.Cstr_ItemTime[i][j].IntToFormat(num / 60L, 2, false);
						this.Cstr_ItemTime[i][j].IntToFormat(num % 60L, 2, false);
						this.Cstr_ItemTime[i][j].AppendFormat("{0}:{1}");
						this.text_ItemTime[i][j].text = this.Cstr_ItemTime[i][j].ToString();
						this.text_ItemTime[i][j].SetAllDirty();
						this.text_ItemTime[i][j].cachedTextGenerator.Invalidate();
					}
				}
			}
		}
	}

	// Token: 0x06000FF8 RID: 4088 RVA: 0x001C6510 File Offset: 0x001C4710
	public void CheckMissionCD()
	{
		for (int i = 0; i < this.MM.mMobilizationMission.Length; i++)
		{
			if (this.MM.mMobilizationMission[i].MissionType == 1001 && this.MM.mMobilizationMission[i].CDTime - DataManager.Instance.ServerTime <= 0L)
			{
				this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_REFLASH();
				break;
			}
		}
	}

	// Token: 0x06000FF9 RID: 4089 RVA: 0x001C6594 File Offset: 0x001C4794
	private void Start()
	{
	}

	// Token: 0x06000FFA RID: 4090 RVA: 0x001C6598 File Offset: 0x001C4798
	private void Update()
	{
		if (this.btn_GetReward != null && this.btn_GetReward.IsActive())
		{
			this.ShowGetReward += Time.smoothDeltaTime;
			if (this.ShowGetReward >= 2f)
			{
				this.ShowGetReward = 0f;
			}
			float a = (this.ShowGetReward <= 1f) ? this.ShowGetReward : (2f - this.ShowGetReward);
			this.Img_GetReward.color = new Color(1f, 1f, 1f, a);
		}
		if (this.btn_Report != null && this.btn_Report.IsActive())
		{
			this.ShowReport += Time.smoothDeltaTime;
			if (this.ShowReport >= 2f)
			{
				this.ShowReport = 0f;
			}
			float a2 = (this.ShowReport <= 1f) ? this.ShowReport : (2f - this.ShowReport);
			this.Img_Report.color = new Color(1f, 1f, 1f, a2);
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (this.Img_ItemFrame[i][j] != null && this.Img_ItemFrame[i][j].IsActive())
				{
					this.ShowItemF += Time.smoothDeltaTime;
					if (this.ShowItemF >= 2f)
					{
						this.ShowItemF = 0f;
					}
					float a3 = (this.ShowItemF <= 1f) ? (1f - this.ShowItemF * 0.7f) : (0.7f * this.ShowItemF - 0.4f);
					this.Img_ItemFrame[i][j].color = new Color(1f, 1f, 1f, a3);
				}
			}
		}
		if (this.Img_RewardBG[0] != null && this.Img_RewardBG[0].IsActive())
		{
			if (this.GUIM.IsArabic)
			{
				this.Img_RewardBG[0].transform.Rotate(Vector3.forward * Time.smoothDeltaTime * 50f);
			}
			else
			{
				this.Img_RewardBG[0].transform.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
			}
		}
		if (this.MM.AMCompleteDegree > 0 && this.tmpAddCount < (int)((this.MM.AMCompleteDegree - 1) / 3 + 1))
		{
			this.tmpAddTime -= Time.unscaledDeltaTime;
			if (this.tmpAddTime < 0f)
			{
				Array.Clear(this.GUIM.SE_Kind, 0, this.GUIM.SE_Kind.Length);
				Array.Clear(this.GUIM.m_SpeciallyEffect.mResValue, 0, this.GUIM.m_SpeciallyEffect.mResValue.Length);
				Array.Clear(this.GUIM.SE_ItemID, 0, this.GUIM.SE_ItemID.Length);
				for (int k = 0; k < 3; k++)
				{
					if (k + this.tmpAddCount * 3 < this.MM.RSAnimationItemID.Length && this.MM.RSAnimationItemID[k + this.tmpAddCount * 3] != 0)
					{
						this.GUIM.SE_ItemID[k] = this.MM.RSAnimationItemID[k + this.tmpAddCount * 3];
					}
				}
				this.GUIM.mStartV2 = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + 259.5f, this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f + 101f);
				this.GUIM.m_SpeciallyEffect.AddIconShow(this.GUIM.mStartV2, this.GUIM.SE_Kind, this.GUIM.SE_ItemID, true);
				this.tmpAddCount++;
				this.tmpAddTime = 0.6f;
			}
		}
		if (this.Img_Bouns_Light != null && this.Img_BonusBtn_Light != null && MobilizationManager.Instance.AMGoldState != 3)
		{
			this.Bouns_LightTime += Time.smoothDeltaTime;
			if (this.Bouns_LightTime >= 0f)
			{
				if (this.Bouns_LightTime >= 2f)
				{
					this.Bouns_LightTime = 0f;
				}
				float a4 = (this.Bouns_LightTime <= 1f) ? this.Bouns_LightTime : (2f - this.Bouns_LightTime);
				this.Img_Bouns_Light.color = new Color(1f, 1f, 1f, a4);
				this.Img_BonusBtn_Light.color = new Color(1f, 1f, 1f, a4);
			}
		}
	}

	// Token: 0x040033ED RID: 13293
	private DataManager DM;

	// Token: 0x040033EE RID: 13294
	private GUIManager GUIM;

	// Token: 0x040033EF RID: 13295
	private MobilizationManager MM;

	// Token: 0x040033F0 RID: 13296
	private ActivityManager AM;

	// Token: 0x040033F1 RID: 13297
	private Transform GameT;

	// Token: 0x040033F2 RID: 13298
	private Transform Tmp;

	// Token: 0x040033F3 RID: 13299
	private Transform Tmp_Bonus;

	// Token: 0x040033F4 RID: 13300
	private Transform[] Kind_T = new Transform[2];

	// Token: 0x040033F5 RID: 13301
	private Transform[][] ItemKind_T = new Transform[3][];

	// Token: 0x040033F6 RID: 13302
	private RectTransform Img_LvBar_RT;

	// Token: 0x040033F7 RID: 13303
	private RectTransform Img_MissionBar_RT;

	// Token: 0x040033F8 RID: 13304
	private RectTransform m_ItemConet;

	// Token: 0x040033F9 RID: 13305
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040033FA RID: 13306
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[3];

	// Token: 0x040033FB RID: 13307
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x040033FC RID: 13308
	private Door door;

	// Token: 0x040033FD RID: 13309
	private UIButton btn_EXIT;

	// Token: 0x040033FE RID: 13310
	private UIButton btn_I;

	// Token: 0x040033FF RID: 13311
	private UIButton btn_Hint;

	// Token: 0x04003400 RID: 13312
	private UIButton btn_Add;

	// Token: 0x04003401 RID: 13313
	private UIButton btn_Start;

	// Token: 0x04003402 RID: 13314
	private UIButton btn_Report;

	// Token: 0x04003403 RID: 13315
	private UIButton btn_Rank1;

	// Token: 0x04003404 RID: 13316
	private UIButton btn_Rank2;

	// Token: 0x04003405 RID: 13317
	private UIButton btn_Reward;

	// Token: 0x04003406 RID: 13318
	private UIButton btn_Reward2;

	// Token: 0x04003407 RID: 13319
	private UIButton btn_GetReward;

	// Token: 0x04003408 RID: 13320
	private UIButton btn_GiveUp;

	// Token: 0x04003409 RID: 13321
	private UIButton btn_RankHint;

	// Token: 0x0400340A RID: 13322
	private UIButton btn_Bonus;

	// Token: 0x0400340B RID: 13323
	private UIButton btn_Bonus2;

	// Token: 0x0400340C RID: 13324
	private UIButton btn_BonusExit;

	// Token: 0x0400340D RID: 13325
	private UIButton btn_BonusReward;

	// Token: 0x0400340E RID: 13326
	private UIButton btn_BonusReward2;

	// Token: 0x0400340F RID: 13327
	private UIButton btn_Rank_World;

	// Token: 0x04003410 RID: 13328
	private UIButton[][] btn_Delete = new UIButton[3][];

	// Token: 0x04003411 RID: 13329
	private UIButton[][] btn_ItemSelect = new UIButton[3][];

	// Token: 0x04003412 RID: 13330
	private Image Img_Mission;

	// Token: 0x04003413 RID: 13331
	private Image Img_MissionKind;

	// Token: 0x04003414 RID: 13332
	private Image Img_MissionScore;

	// Token: 0x04003415 RID: 13333
	private Image Img_Missionstatus;

	// Token: 0x04003416 RID: 13334
	private Image Img_MissionTime;

	// Token: 0x04003417 RID: 13335
	private Image Img_MissionCDTime;

	// Token: 0x04003418 RID: 13336
	private Image Img_LVMax;

	// Token: 0x04003419 RID: 13337
	private Image Img_HintBG;

	// Token: 0x0400341A RID: 13338
	private Image Img_Hint;

	// Token: 0x0400341B RID: 13339
	private Image Img_ActivityTime;

	// Token: 0x0400341C RID: 13340
	private Image Img_ActivityEnd;

	// Token: 0x0400341D RID: 13341
	private Image Img_MissionBG;

	// Token: 0x0400341E RID: 13342
	private Image Img_GetRewardTime;

	// Token: 0x0400341F RID: 13343
	private Image Img_LBG;

	// Token: 0x04003420 RID: 13344
	private Image Img_BonusHint;

	// Token: 0x04003421 RID: 13345
	private Image Img_BonusAlert;

	// Token: 0x04003422 RID: 13346
	private Image Img_Bouns_Light;

	// Token: 0x04003423 RID: 13347
	private Image Img_BonusBtn_Light;

	// Token: 0x04003424 RID: 13348
	private Image Img_BounsBG;

	// Token: 0x04003425 RID: 13349
	private Image Img_RewardOK;

	// Token: 0x04003426 RID: 13350
	private Image Img_GetReward;

	// Token: 0x04003427 RID: 13351
	private Image Img_Report;

	// Token: 0x04003428 RID: 13352
	private Image[] Img_Bar = new Image[2];

	// Token: 0x04003429 RID: 13353
	private Image[] Img_RewardBG = new Image[2];

	// Token: 0x0400342A RID: 13354
	private Image[][] Img_ItemFrame = new Image[3][];

	// Token: 0x0400342B RID: 13355
	private Image[][] Img_ItemIcon = new Image[3][];

	// Token: 0x0400342C RID: 13356
	private Image[][] Img_ItemP1Icon = new Image[3][];

	// Token: 0x0400342D RID: 13357
	private Image[][] Img_ItemP1Mission = new Image[3][];

	// Token: 0x0400342E RID: 13358
	private Image[][] Img_ItemP1Score = new Image[3][];

	// Token: 0x0400342F RID: 13359
	private Image[][] Img_ItemP1OK = new Image[3][];

	// Token: 0x04003430 RID: 13360
	private Image Img_MoreRewards;

	// Token: 0x04003431 RID: 13361
	private Image Img_AllianceRankBG;

	// Token: 0x04003432 RID: 13362
	private Image Img_TitleBG;

	// Token: 0x04003433 RID: 13363
	private UIText text_Title;

	// Token: 0x04003434 RID: 13364
	private UIText text_MobilizationNum;

	// Token: 0x04003435 RID: 13365
	private UIText text_MissionCount;

	// Token: 0x04003436 RID: 13366
	private UIText text_Lv;

	// Token: 0x04003437 RID: 13367
	private UIText text_LvValue;

	// Token: 0x04003438 RID: 13368
	private UIText text_Kind;

	// Token: 0x04003439 RID: 13369
	private UIText text_Kind1;

	// Token: 0x0400343A RID: 13370
	private UIText text_MissionTime;

	// Token: 0x0400343B RID: 13371
	private UIText text_Missionstatus;

	// Token: 0x0400343C RID: 13372
	private UIText text_Empty;

	// Token: 0x0400343D RID: 13373
	private UIText text_Hint;

	// Token: 0x0400343E RID: 13374
	private UIText text_Start;

	// Token: 0x0400343F RID: 13375
	private UIText text_Report;

	// Token: 0x04003440 RID: 13376
	private UIText text_GiveUp;

	// Token: 0x04003441 RID: 13377
	private UIText text_RewardTitle;

	// Token: 0x04003442 RID: 13378
	private UIText text_GetRewardTime;

	// Token: 0x04003443 RID: 13379
	private UIText text_AllianceReward;

	// Token: 0x04003444 RID: 13380
	private UIText text_RewardNum;

	// Token: 0x04003445 RID: 13381
	private UIText text_Rewardstr;

	// Token: 0x04003446 RID: 13382
	private UIText text_RewardOK;

	// Token: 0x04003447 RID: 13383
	private UIText text_GetReward;

	// Token: 0x04003448 RID: 13384
	private UIText text_TimeBar;

	// Token: 0x04003449 RID: 13385
	private UIText[] text_Time = new UIText[2];

	// Token: 0x0400344A RID: 13386
	private UIText[] text_NowScore = new UIText[2];

	// Token: 0x0400344B RID: 13387
	private UIText[] text_NextScore = new UIText[2];

	// Token: 0x0400344C RID: 13388
	private UIText[] text_MissionCDTime = new UIText[2];

	// Token: 0x0400344D RID: 13389
	private UIText[] text_Info = new UIText[3];

	// Token: 0x0400344E RID: 13390
	private UIText[][] text_ItemTime = new UIText[3][];

	// Token: 0x0400344F RID: 13391
	private UIText[][] text_ItemValue = new UIText[3][];

	// Token: 0x04003450 RID: 13392
	private UIText[][] text_ItemP1Score = new UIText[3][];

	// Token: 0x04003451 RID: 13393
	private UIText[][] text_ItemNoMission = new UIText[3][];

	// Token: 0x04003452 RID: 13394
	private UIText text_Resultstr;

	// Token: 0x04003453 RID: 13395
	private UIText text_Result;

	// Token: 0x04003454 RID: 13396
	private UIText text_BonusReward;

	// Token: 0x04003455 RID: 13397
	private UIText text_BonusHint;

	// Token: 0x04003456 RID: 13398
	private UIText text_BonusGet;

	// Token: 0x04003457 RID: 13399
	private UIText text_BonusGet2;

	// Token: 0x04003458 RID: 13400
	private UIText text_BonusDone;

	// Token: 0x04003459 RID: 13401
	private CString Cstr_Lv;

	// Token: 0x0400345A RID: 13402
	private CString Cstr_LvValue;

	// Token: 0x0400345B RID: 13403
	private CString Cstr_ActivityTime;

	// Token: 0x0400345C RID: 13404
	private CString Cstr_NowScore;

	// Token: 0x0400345D RID: 13405
	private CString Cstr_NextScore;

	// Token: 0x0400345E RID: 13406
	private CString Cstr_MobilizationNum;

	// Token: 0x0400345F RID: 13407
	private CString Cstr_MissionTime;

	// Token: 0x04003460 RID: 13408
	private CString Cstr_MissionCDTime;

	// Token: 0x04003461 RID: 13409
	private CString Cstr_MissionCount;

	// Token: 0x04003462 RID: 13410
	private CString Cstr_Hint;

	// Token: 0x04003463 RID: 13411
	private CString Cstr_TimeBar;

	// Token: 0x04003464 RID: 13412
	private CString Cstr_GetRewardTime;

	// Token: 0x04003465 RID: 13413
	private CString Cstr_RewardNum;

	// Token: 0x04003466 RID: 13414
	private CString Cstr_RankHint;

	// Token: 0x04003467 RID: 13415
	private CString Cstr_Result;

	// Token: 0x04003468 RID: 13416
	private CString Cstr_RankResult;

	// Token: 0x04003469 RID: 13417
	private CString Cstr_BonusReward;

	// Token: 0x0400346A RID: 13418
	private CString Cstr_BonusRewardDone;

	// Token: 0x0400346B RID: 13419
	private CString Cstr_BonusHint;

	// Token: 0x0400346C RID: 13420
	private CString[] Cstr_BonusRecord = new CString[3];

	// Token: 0x0400346D RID: 13421
	private CString[] Cstr_Info = new CString[2];

	// Token: 0x0400346E RID: 13422
	private CString[][] Cstr_ItemTime = new CString[3][];

	// Token: 0x0400346F RID: 13423
	private CString[][] Cstr_ItemValue = new CString[3][];

	// Token: 0x04003470 RID: 13424
	private BonusHint[] bonusHint = new BonusHint[3];

	// Token: 0x04003471 RID: 13425
	private Material m_Mat;

	// Token: 0x04003472 RID: 13426
	private UISpritesArray SArray;

	// Token: 0x04003473 RID: 13427
	private List<float> tmplist = new List<float>();

	// Token: 0x04003474 RID: 13428
	private bool bOpenEnd;

	// Token: 0x04003475 RID: 13429
	private long tmpTime;

	// Token: 0x04003476 RID: 13430
	private MobilizationMissionData mMMissionData;

	// Token: 0x04003477 RID: 13431
	private MobilizationDegreeData mMDData;

	// Token: 0x04003478 RID: 13432
	private float tmpAddTime;

	// Token: 0x04003479 RID: 13433
	private int tmpAddCount = 10;

	// Token: 0x0400347A RID: 13434
	private float ShowGetReward;

	// Token: 0x0400347B RID: 13435
	private float ShowReport;

	// Token: 0x0400347C RID: 13436
	private float ShowItemF;

	// Token: 0x0400347D RID: 13437
	private Color mColor_G = new Color(0.361f, 0.953f, 0.325f);

	// Token: 0x0400347E RID: 13438
	private Color mColor_R = new Color(1f, 0.369f, 0.439f);

	// Token: 0x0400347F RID: 13439
	private Color mColor_Info = new Color(1f, 0.968f, 0.6f);

	// Token: 0x04003480 RID: 13440
	private int tmpItemNum;

	// Token: 0x04003481 RID: 13441
	private bool bStartAddSend;

	// Token: 0x04003482 RID: 13442
	private UIAlliance_Rank RankObj = new UIAlliance_Rank();

	// Token: 0x04003483 RID: 13443
	private float Bouns_LightTime;
}
