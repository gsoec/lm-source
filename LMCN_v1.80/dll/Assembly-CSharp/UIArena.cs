using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000336 RID: 822
public class UIArena : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x060010B6 RID: 4278 RVA: 0x001D9510 File Offset: 0x001D7710
	public override void OnOpen(int arg1, int arg2)
	{
		this.Cstr_ReplayNum = StringManager.Instance.SpawnString(30);
		this.Cstr_Propaganda = StringManager.Instance.SpawnString(200);
		this.Cstr_Strength = StringManager.Instance.SpawnString(30);
		this.Cstr_Rank = StringManager.Instance.SpawnString(30);
		this.Cstr_Count = StringManager.Instance.SpawnString(30);
		this.Cstr_CD = StringManager.Instance.SpawnString(100);
		this.Cstr_CDTime = StringManager.Instance.SpawnString(30);
		for (int i = 0; i < 3; i++)
		{
			this.Cstr_TargetName[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_TargetRank[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_TargetStrength[i] = StringManager.Instance.SpawnString(30);
		}
		this.DM = DataManager.Instance;
		this.AM = ArenaManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.ActM = ActivityManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.AM.bArenaKVK = this.ActM.IsInKvK(0, false);
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		Material material = this.door.LoadMaterial();
		Transform child = this.GameT.GetChild(0);
		Transform child2 = child.GetChild(3).GetChild(0);
		this.text_Title = child2.GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.text = this.DM.mStringTable.GetStringByID(9102u);
		child2 = child.GetChild(4);
		this.btn_Astrology = child2.GetComponent<UIButton>();
		this.btn_Astrology.m_Handler = this;
		this.btn_Astrology.m_BtnID1 = 13;
		this.btn_Astrology.m_EffectType = e_EffectType.e_Scale;
		this.btn_Astrology.transition = Selectable.Transition.None;
		child2 = child.GetChild(5);
		this.btn_Rank = child2.GetComponent<UIButton>();
		this.btn_Rank.m_Handler = this;
		this.btn_Rank.m_BtnID1 = 11;
		this.btn_Rank.m_EffectType = e_EffectType.e_Scale;
		this.btn_Rank.transition = Selectable.Transition.None;
		child.GetChild(5).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
		child2 = child.GetChild(6);
		this.btn_Replay = child2.GetComponent<UIButton>();
		this.btn_Replay.m_Handler = this;
		this.btn_Replay.m_BtnID1 = 10;
		this.btn_Replay.m_EffectType = e_EffectType.e_Scale;
		this.btn_Replay.transition = Selectable.Transition.None;
		child.GetChild(6).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
		child2 = child.GetChild(6).GetChild(1);
		this.Img_ReplayNum = child2.GetComponent<Image>();
		child2 = child.GetChild(6).GetChild(1).GetChild(0);
		this.text_ReplayNum = child2.GetComponent<UIText>();
		this.text_ReplayNum.font = this.TTFont;
		this.Cstr_ReplayNum.ClearString();
		this.Cstr_ReplayNum.IntToFormat((long)this.AM.m_ArenaNewReportNum, 1, false);
		this.Cstr_ReplayNum.AppendFormat("{0}");
		this.text_ReplayNum.text = this.Cstr_ReplayNum.ToString();
		this.Img_ReplayNum.rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_ReplayNum.preferredWidth), this.Img_ReplayNum.rectTransform.sizeDelta.y);
		if (this.AM.m_ArenaNewReportNum > 0)
		{
			this.Img_ReplayNum.gameObject.SetActive(true);
		}
		else
		{
			this.Img_ReplayNum.gameObject.SetActive(false);
		}
		child2 = child.GetChild(7);
		this.img_text = child2.GetComponent<UIRunningText>();
		this.img_text.tmpLength = 453f;
		child2 = child.GetChild(7).GetChild(0);
		this.text_Propaganda[0] = child2.GetComponent<UIText>();
		RectTransform component = child2.GetComponent<RectTransform>();
		this.text_Propaganda[0].font = this.TTFont;
		this.Cstr_Propaganda.ClearString();
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		CString cstring3 = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring2.ClearString();
		cstring3.ClearString();
		this.AM.GetHeroAstrology(cstring, cstring2);
		if (this.AM.m_NowArenaTopicID[0] != 0 && this.AM.m_NowArenaTopicID[1] != 0)
		{
			cstring3.StringToFormat(cstring);
			cstring3.StringToFormat(cstring2);
			cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9118u));
		}
		else
		{
			if (this.AM.m_NowArenaTopicID[0] != 0)
			{
				cstring3.StringToFormat(cstring);
			}
			else
			{
				cstring3.StringToFormat(cstring2);
			}
			cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9154u));
		}
		this.Cstr_Propaganda.Append(cstring3);
		this.Cstr_Propaganda.Append("     ");
		cstring.ClearString();
		cstring2.ClearString();
		cstring3.ClearString();
		if (this.AM.m_NowTopicEffect[0].Effect != 0 && this.AM.m_NowTopicEffect[1].Effect != 0)
		{
			GameConstants.GetEffectValue(cstring, this.AM.m_NowTopicEffect[0].Effect, (uint)this.AM.m_NowTopicEffect[0].Value, 10, 0f);
			GameConstants.GetEffectValue(cstring2, this.AM.m_NowTopicEffect[1].Effect, (uint)this.AM.m_NowTopicEffect[1].Value, 10, 0f);
			cstring3.StringToFormat(cstring);
			cstring3.StringToFormat(cstring2);
			cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9119u));
			cstring3.Append(" ");
		}
		else
		{
			if (this.AM.m_NowTopicEffect[0].Effect != 0)
			{
				GameConstants.GetEffectValue(cstring, this.AM.m_NowTopicEffect[0].Effect, (uint)this.AM.m_NowTopicEffect[0].Value, 10, 0f);
			}
			else
			{
				GameConstants.GetEffectValue(cstring, this.AM.m_NowTopicEffect[1].Effect, (uint)this.AM.m_NowTopicEffect[1].Value, 10, 0f);
			}
			cstring3.StringToFormat(cstring);
			cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9155u));
			cstring3.Append(" ");
		}
		this.Cstr_Propaganda.Append(cstring3);
		this.text_Propaganda[0].text = this.Cstr_Propaganda.ToString();
		child2 = child.GetChild(7).GetChild(1);
		this.text_Propaganda[1] = child2.GetComponent<UIText>();
		RectTransform component2 = child2.GetComponent<RectTransform>();
		this.text_Propaganda[1].font = this.TTFont;
		this.text_Propaganda[1].text = this.Cstr_Propaganda.ToString();
		component.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth + 160f, component.sizeDelta.y);
		component2.anchoredPosition = new Vector2(this.text_Propaganda[0].preferredWidth + 160f, component2.anchoredPosition.y);
		component2.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth + 160f, component2.sizeDelta.y);
		this.img_text.tmpLength = this.text_Propaganda[0].preferredWidth + 160f;
		Image component3;
		for (int j = 0; j < 5; j++)
		{
			this.btn_Hero[j] = child.GetChild(8 + j).GetChild(0).GetComponent<UIHIBtn>();
			this.btn_DefendHero[j] = child.GetChild(13 + j).GetComponent<UIButton>();
			this.btn_DefendHero[j].m_Handler = this;
			this.btn_DefendHero[j].m_BtnID1 = 9;
			this.Img_Hero[j] = child.GetChild(13 + j).GetChild(0).GetComponent<Image>();
			this.Img_Hero[j].sprite = this.GUIM.LoadFrameSprite("hf000");
			this.Img_Hero[j].material = this.GUIM.GetFrameMaterial();
			component3 = child.GetChild(13 + j).GetChild(0).GetChild(0).GetComponent<Image>();
			component3.gameObject.SetActive(false);
			this.Img_HeroStar[j] = child.GetChild(13 + j).GetChild(1).GetComponent<Image>();
			if (DataManager.Instance.curHeroData.ContainsKey((uint)this.AM.m_ArenaDefHero[j]))
			{
				this.mcurHeroData = DataManager.Instance.curHeroData[(uint)this.AM.m_ArenaDefHero[j]];
				this.btn_Hero[j].gameObject.SetActive(true);
				this.GUIM.InitianHeroItemImg(this.btn_Hero[j].transform, eHeroOrItem.Hero, this.AM.m_ArenaDefHero[j], this.mcurHeroData.Star, this.mcurHeroData.Enhance, (int)this.mcurHeroData.Level, true, true, true, false);
				if (this.AM.CheckHeroAstrology(this.AM.m_ArenaDefHero[j]))
				{
					this.Img_HeroStar[j].gameObject.SetActive(true);
				}
				this.bSetHero = true;
			}
			else
			{
				this.GUIM.InitianHeroItemImg(this.btn_Hero[j].transform, eHeroOrItem.Hero, 1, 0, 0, 0, true, true, true, false);
				this.btn_Hero[j].gameObject.SetActive(false);
				this.Img_Hero[j].gameObject.SetActive(true);
			}
		}
		this.btn_Defend = child.GetChild(18).GetComponent<UIButton>();
		this.btn_Defend.m_Handler = this;
		this.btn_Defend.m_BtnID1 = 1;
		this.btn_Defend.m_EffectType = e_EffectType.e_Scale;
		this.btn_Defend.transition = Selectable.Transition.None;
		child2 = child.GetChild(18).GetChild(0);
		this.text_Defend = child2.GetComponent<UIText>();
		this.text_Defend.font = this.TTFont;
		this.text_Defend.text = this.DM.mStringTable.GetStringByID(9103u);
		this.btn_I = child.GetChild(19).GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_I.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_I.m_Handler = this;
		this.btn_I.m_BtnID1 = 2;
		this.btn_I.m_EffectType = e_EffectType.e_Scale;
		this.btn_I.transition = Selectable.Transition.None;
		child2 = child.GetChild(20).GetChild(0);
		this.text_Strength = child2.GetComponent<UIText>();
		this.text_Strength.font = this.TTFont;
		this.Cstr_Strength.ClearString();
		this.Cstr_Strength.IntToFormat((long)((ulong)this.GetAllPower()), 1, true);
		this.Cstr_Strength.AppendFormat("{0}");
		this.text_Strength.text = this.Cstr_Strength.ToString();
		child = this.GameT.GetChild(1);
		this.K1_T = child.GetChild(1);
		this.K2_T = child.GetChild(2);
		this.K1_T.gameObject.SetActive(true);
		CString cstring4 = StringManager.Instance.StaticString1024();
		CString cstring5 = StringManager.Instance.StaticString1024();
		UIButtonHint uibuttonHint;
		for (int k = 0; k < 3; k++)
		{
			this.btn_Opponent[k] = this.K1_T.GetChild(2 + k).GetChild(0).GetComponent<UIHIBtn>();
			this.GUIM.InitianHeroItemImg(this.btn_Opponent[k].transform, eHeroOrItem.Hero, this.AM.m_ArenaTarget[k].Head, 11, 0, 0, true, true, true, false);
			this.Img_Rank[k] = this.K1_T.GetChild(5 + k).GetComponent<Image>();
			if (this.GUIM.IsArabic)
			{
				this.Img_Rank[k].gameObject.AddComponent<ArabicItemTextureRot>();
			}
			this.text_Rank[k] = this.K1_T.GetChild(5 + k).GetChild(0).GetComponent<UIText>();
			this.text_Rank[k].font = this.TTFont;
			this.Cstr_TargetRank[k].ClearString();
			this.Cstr_TargetRank[k].IntToFormat((long)((ulong)this.AM.m_ArenaTarget[k].Place), 1, true);
			this.Cstr_TargetRank[k].AppendFormat("{0}");
			this.text_Rank[k].text = this.Cstr_TargetRank[k].ToString();
			this.Img_OS[k] = this.K1_T.GetChild(8 + k).GetComponent<Image>();
			this.text_OS[k] = this.K1_T.GetChild(8 + k).GetChild(0).GetComponent<UIText>();
			this.text_OS[k].font = this.TTFont;
			this.Cstr_TargetStrength[k].ClearString();
			this.Cstr_TargetStrength[k].IntToFormat((long)((ulong)this.AM.GetAllPower(1, k)), 1, true);
			this.Cstr_TargetStrength[k].AppendFormat("{0}");
			this.text_OS[k].text = this.Cstr_TargetStrength[k].ToString();
			this.btn_Hint[k] = this.K1_T.GetChild(11 + k).GetComponent<UIButton>();
			this.btn_Hint[k].m_Handler = this;
			this.btn_Hint[k].m_BtnID1 = 12;
			this.btn_Hint[k].m_BtnID2 = k;
			uibuttonHint = this.btn_Hint[k].gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.UIArena_Hint;
			uibuttonHint.Parm2 = (byte)k;
			uibuttonHint.m_Handler = this;
			uibuttonHint.ControlFadeOut = this.GUIM.m_Arena_Hint.m_RectTransform.gameObject;
			this.btn_Challenge[k] = this.K1_T.GetChild(14 + k).GetComponent<UIButton>();
			this.btn_Challenge[k].m_Handler = this;
			this.btn_Challenge[k].m_BtnID1 = 3 + k;
			this.btn_Challenge[k].m_EffectType = e_EffectType.e_Scale;
			this.btn_Challenge[k].transition = Selectable.Transition.None;
			this.text_Challenge[k] = this.K1_T.GetChild(14 + k).GetChild(0).GetComponent<UIText>();
			this.text_Challenge[k].font = this.TTFont;
			this.text_Challenge[k].text = this.DM.mStringTable.GetStringByID(9108u);
			this.btn_Challenge[k].m_Text = this.text_Challenge[k];
			this.text_Challenge_Name[k] = this.K1_T.GetChild(17 + k).GetComponent<UIText>();
			this.text_Challenge_Name[k].font = this.TTFont;
			this.Cstr_TargetName[k].ClearString();
			cstring4.ClearString();
			cstring5.ClearString();
			cstring4.Append(this.AM.m_ArenaTarget[k].Name);
			if (this.AM.m_ArenaTarget[k].AllianceTagTag != string.Empty)
			{
				cstring5.Append(this.AM.m_ArenaTarget[k].AllianceTagTag);
				GameConstants.FormatRoleName(this.Cstr_TargetName[k], cstring4, cstring5, null, 0, 0, null, null, null, null);
			}
			else
			{
				GameConstants.FormatRoleName(this.Cstr_TargetName[k], cstring4, null, null, 0, 0, null, null, null, null);
			}
			this.text_Challenge_Name[k].text = this.Cstr_TargetName[k].ToString();
		}
		for (int l = 0; l < 3; l++)
		{
			this.text_Close[l] = this.K2_T.GetChild(1 + l).GetComponent<UIText>();
			this.text_Close[l].font = this.TTFont;
		}
		if (this.AM.CheckArenaClose() > 0)
		{
			this.text_Close[0].text = this.DM.mStringTable.GetStringByID((uint)this.AM.CheckArenaClose());
		}
		this.Cstr_CD.ClearString();
		this.Cstr_CDTime.ClearString();
		if (this.AM.bArenaKVK)
		{
			long num = this.ActM.KvKActivityData[4].EventBeginTime + (long)((ulong)this.ActM.KvKActivityData[4].EventReqiureTIme) - this.DM.ServerTime;
			if (num <= 0L || num / 86400L > 0L)
			{
				num = 0L;
			}
			this.Cstr_CDTime.IntToFormat(num / 3600L, 2, false);
			num %= 3600L;
			this.Cstr_CDTime.IntToFormat(num / 60L, 2, false);
			num %= 60L;
			this.Cstr_CDTime.IntToFormat(num, 2, false);
			this.Cstr_CDTime.AppendFormat("{0}:{1}:{2}");
			this.Cstr_CD.StringToFormat(this.Cstr_CDTime);
			this.Cstr_CD.AppendFormat(this.DM.mStringTable.GetStringByID(9110u));
		}
		else if (this.AM.CheckArenaClose() > 0)
		{
			long num2 = this.CheckKOWCountTime();
			if (num2 / 86400L > 0L)
			{
				this.Cstr_CDTime.IntToFormat(num2 / 86400L, 1, false);
				num2 %= 86400L;
				this.Cstr_CDTime.IntToFormat(num2 / 3600L, 2, false);
				num2 %= 3600L;
				this.Cstr_CDTime.IntToFormat(num2 / 60L, 2, false);
				num2 %= 60L;
				this.Cstr_CDTime.IntToFormat(num2, 2, false);
				if (this.GUIM.IsArabic)
				{
					this.Cstr_CDTime.AppendFormat("{1}:{2}:{3} {0}d");
				}
				else
				{
					this.Cstr_CDTime.AppendFormat("{0}d {1}:{2}:{3}");
				}
			}
			else
			{
				this.Cstr_CDTime.IntToFormat(num2 / 3600L, 2, false);
				num2 %= 3600L;
				this.Cstr_CDTime.IntToFormat(num2 / 60L, 2, false);
				num2 %= 60L;
				this.Cstr_CDTime.IntToFormat(num2, 2, false);
				this.Cstr_CDTime.AppendFormat("{0}:{1}:{2}");
			}
			this.Cstr_CD.StringToFormat(this.Cstr_CDTime);
			this.Cstr_CD.AppendFormat(this.DM.mStringTable.GetStringByID(9110u));
		}
		this.text_Close[1].text = this.Cstr_CD.ToString();
		this.text_Close[1].SetAllDirty();
		this.text_Close[1].cachedTextGenerator.Invalidate();
		this.text_Close[2].text = this.DM.mStringTable.GetStringByID(9120u);
		if (this.AM.CheckArenaClose() > 0)
		{
			this.K1_T.gameObject.SetActive(false);
			this.K2_T.gameObject.SetActive(true);
			this.text_Close[0].gameObject.SetActive(true);
			this.text_Close[1].gameObject.SetActive(true);
			this.text_Close[2].gameObject.SetActive(false);
			this.img_text.gameObject.SetActive(false);
		}
		else
		{
			this.img_text.gameObject.SetActive(true);
			if (this.bSetHero)
			{
				this.K1_T.gameObject.SetActive(true);
				this.K2_T.gameObject.SetActive(false);
			}
			else
			{
				this.K1_T.gameObject.SetActive(false);
				this.K2_T.gameObject.SetActive(true);
				this.text_Close[0].gameObject.SetActive(false);
				this.text_Close[1].gameObject.SetActive(false);
				this.text_Close[2].gameObject.SetActive(true);
			}
		}
		this.btn_Award = child.GetChild(3).GetComponent<UIButton>();
		this.btn_Award.m_Handler = this;
		this.btn_Award.m_BtnID1 = 6;
		this.btn_Award.m_EffectType = e_EffectType.e_Scale;
		this.btn_Award.transition = Selectable.Transition.None;
		this.btn_Count = child.GetChild(4).GetComponent<UIButton>();
		this.btn_Count.m_Handler = this;
		this.btn_Count.m_BtnID1 = 7;
		this.btn_Count.m_EffectType = e_EffectType.e_Scale;
		this.btn_Count.transition = Selectable.Transition.None;
		this.btn_ReSet = child.GetChild(6).GetComponent<UIButton>();
		this.btn_ReSet.m_Handler = this;
		this.btn_ReSet.m_BtnID1 = 8;
		this.btn_ReSet.m_EffectType = e_EffectType.e_Scale;
		this.btn_ReSet.transition = Selectable.Transition.None;
		this.text_ReSet = child.GetChild(6).GetChild(0).GetComponent<UIText>();
		this.text_ReSet.font = this.TTFont;
		this.text_ReSet.text = this.DM.mStringTable.GetStringByID(9106u);
		this.btn_ReSet.m_Text = this.text_ReSet;
		if (this.bSetHero)
		{
			this.btn_ReSet.ForTextChange(e_BtnType.e_Normal);
		}
		else
		{
			this.btn_ReSet.ForTextChange(e_BtnType.e_ChangeText);
		}
		for (int m = 0; m < 2; m++)
		{
			this.text_Award[m] = child.GetChild(7).GetChild(m + 1).GetComponent<UIText>();
			this.text_Award[m].font = this.TTFont;
		}
		this.text_Award[0].text = this.DM.mStringTable.GetStringByID(9104u);
		this.Cstr_Rank.ClearString();
		this.Cstr_Rank.IntToFormat((long)((ulong)this.AM.m_ArenaPlace), 1, true);
		this.Cstr_Rank.AppendFormat("{0}");
		this.text_Award[1].text = this.Cstr_Rank.ToString();
		this.text_Award[1].SetAllDirty();
		this.text_Award[1].cachedTextGenerator.Invalidate();
		this.text_Award[1].cachedTextGeneratorForLayout.Invalidate();
		this.Img_ArenaPlacedrop = child.GetChild(7).GetChild(0).GetComponent<Image>();
		this.mArenaPlacedropX = 90f;
		if (this.text_Award[1].preferredWidth < 110f)
		{
			this.mArenaPlacedropX = this.text_Award[1].preferredWidth / 2f + 35f;
		}
		this.Img_ArenaPlacedrop.rectTransform.anchoredPosition = new Vector2(-this.mArenaPlacedropX, this.Img_ArenaPlacedrop.rectTransform.anchoredPosition.y);
		if (this.DM.CheckPrizeFlag(20))
		{
			this.Img_ArenaPlacedrop.gameObject.SetActive(true);
			this.AM.m_ArenaPlacedropTime = 4f;
			this.AM.bShowArenaPlacedrop = true;
			this.AM.SendArena_UIClear();
		}
		for (int n = 0; n < 2; n++)
		{
			this.text_Count[n] = child.GetChild(8).GetChild(n).GetComponent<UIText>();
			this.text_Count[n].font = this.TTFont;
		}
		this.text_Count[0].text = this.DM.mStringTable.GetStringByID(9105u);
		this.Cstr_Count.ClearString();
		if (5 - this.AM.m_ArenaTodayChallenge + this.AM.m_ArenaExtraChallenge == 0)
		{
			CString cstring6 = StringManager.Instance.StaticString1024();
			cstring6.ClearString();
			cstring6.IntToFormat(0L, 1, false);
			cstring6.AppendFormat("<color=#9F1C1C>{0}</color>");
			this.Cstr_Count.StringToFormat(cstring6);
			this.btn_Count.gameObject.SetActive(true);
		}
		else
		{
			this.Cstr_Count.IntToFormat((long)(5 - this.AM.m_ArenaTodayChallenge + this.AM.m_ArenaExtraChallenge), 1, false);
			this.btn_Count.gameObject.SetActive(false);
		}
		if (this.GUIM.IsArabic)
		{
			this.Cstr_Count.AppendFormat("5/{0}");
		}
		else
		{
			this.Cstr_Count.AppendFormat("{0}/5");
		}
		this.text_Count[1].text = this.Cstr_Count.ToString();
		this.btn_ReSet.gameObject.SetActive(true);
		child2 = child.GetChild(10);
		this.Img_Award = child2.GetComponent<Image>();
		if (this.AM.m_ArenaCrystalPrize > 0u)
		{
			this.Img_Award.gameObject.SetActive(true);
		}
		else
		{
			this.Img_Award.gameObject.SetActive(false);
		}
		child2 = child.GetChild(11);
		this.btn_StrengthHint = child2.GetComponent<UIButton>();
		this.btn_StrengthHint.m_Handler = this;
		this.btn_StrengthHint.m_BtnID1 = 14;
		uibuttonHint = this.btn_StrengthHint.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		this.Img_StrengthHint = child2.GetChild(0).GetComponent<Image>();
		uibuttonHint.ControlFadeOut = this.Img_StrengthHint.gameObject;
		this.text_StrengthHint = child2.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_StrengthHint.font = this.TTFont;
		this.text_StrengthHint.text = this.DM.mStringTable.GetStringByID(19u);
		if (this.text_StrengthHint.preferredWidth > 343f)
		{
			this.text_StrengthHint.rectTransform.sizeDelta = new Vector2(this.text_StrengthHint.rectTransform.sizeDelta.x, this.text_StrengthHint.preferredHeight + 1f);
			this.Img_StrengthHint.rectTransform.sizeDelta = new Vector2(this.Img_StrengthHint.rectTransform.sizeDelta.x, this.text_StrengthHint.preferredHeight + 5f);
		}
		child = this.GameT.GetChild(2);
		component3 = child.GetComponent<Image>();
		component3.sprite = this.door.LoadSprite("UI_main_close_base");
		component3.material = material;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			component3.enabled = false;
		}
		child = this.GameT.GetChild(2).GetChild(0);
		this.btn_EXIT = child.GetComponent<UIButton>();
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = material;
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
		if (NewbieManager.IsTeachWorking(ETeachKind.ARENA))
		{
			NewbieManager.CheckTeach(ETeachKind.ARENA, this, false);
		}
		if (this.bSetHero)
		{
			this.AM.SendArena_Refresh_Target(2);
		}
	}

	// Token: 0x060010B7 RID: 4279 RVA: 0x001DB10C File Offset: 0x001D930C
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.K1_T.gameObject.activeSelf)
		{
			this.btn_ReSet.gameObject.SetActive(true);
			if (this.bCDReSet)
			{
				if (this.CDReSetTime > 0)
				{
					this.CDReSetTime -= 1;
				}
				else
				{
					this.bCDReSet = false;
				}
			}
		}
		if (bOnSecond && this.text_Close[1].gameObject.activeSelf)
		{
			this.Cstr_CD.ClearString();
			this.Cstr_CDTime.ClearString();
			if (this.AM.bArenaKVK)
			{
				long num = this.ActM.KvKActivityData[4].EventBeginTime + (long)((ulong)this.ActM.KvKActivityData[4].EventReqiureTIme) - this.DM.ServerTime;
				if (num <= 0L || num / 86400L > 0L)
				{
					num = 0L;
				}
				this.Cstr_CDTime.IntToFormat(num / 3600L, 2, false);
				num %= 3600L;
				this.Cstr_CDTime.IntToFormat(num / 60L, 2, false);
				num %= 60L;
				this.Cstr_CDTime.IntToFormat(num, 2, false);
				this.Cstr_CDTime.AppendFormat("{0}:{1}:{2}");
				this.Cstr_CD.StringToFormat(this.Cstr_CDTime);
				this.Cstr_CD.AppendFormat(this.DM.mStringTable.GetStringByID(9110u));
			}
			else if (this.AM.CheckArenaClose() > 0)
			{
				long num2 = this.CheckKOWCountTime();
				long num3 = num2;
				if (num2 / 86400L > 0L)
				{
					this.Cstr_CDTime.IntToFormat(num2 / 86400L, 1, false);
					num2 %= 86400L;
					this.Cstr_CDTime.IntToFormat(num2 / 3600L, 2, false);
					num2 %= 3600L;
					this.Cstr_CDTime.IntToFormat(num2 / 60L, 2, false);
					num2 %= 60L;
					this.Cstr_CDTime.IntToFormat(num2, 2, false);
					if (this.GUIM.IsArabic)
					{
						this.Cstr_CDTime.AppendFormat("{1}:{2}:{3} {0}d");
					}
					else
					{
						this.Cstr_CDTime.AppendFormat("{0}d {1}:{2}:{3}");
					}
				}
				else
				{
					this.Cstr_CDTime.IntToFormat(num2 / 3600L, 2, false);
					num2 %= 3600L;
					this.Cstr_CDTime.IntToFormat(num2 / 60L, 2, false);
					num2 %= 60L;
					this.Cstr_CDTime.IntToFormat(num2, 2, false);
					this.Cstr_CDTime.AppendFormat("{0}:{1}:{2}");
				}
				if (num3 == 0L)
				{
					this.AM.SendArena_Refresh_Target(2);
					this.SetK1_Data();
				}
				this.Cstr_CD.StringToFormat(this.Cstr_CDTime);
				this.Cstr_CD.AppendFormat(this.DM.mStringTable.GetStringByID(9110u));
			}
			this.text_Close[1].text = this.Cstr_CD.ToString();
			this.text_Close[1].SetAllDirty();
			this.text_Close[1].cachedTextGenerator.Invalidate();
		}
		if (this.GameT.gameObject.activeSelf && this.Img_ArenaPlacedrop != null && this.Img_ArenaPlacedrop.IsActive() && this.AM.bShowArenaPlacedrop)
		{
			this.mArenaPlacedropCD += Time.smoothDeltaTime;
			if (this.mArenaPlacedropCD >= 1f)
			{
				this.AM.m_ArenaPlacedropTime -= this.mArenaPlacedropCD;
				if (this.AM.m_ArenaPlacedropTime < 0f)
				{
					this.AM.bShowArenaPlacedrop = false;
				}
				this.mArenaPlacedropCD = 0f;
			}
			float a = (this.mArenaPlacedropCD <= 0.5f) ? (this.mArenaPlacedropCD * 2f) : (2f - this.mArenaPlacedropCD * 2f);
			this.Img_ArenaPlacedrop.color = new Color(1f, 1f, 1f, a);
			this.Img_ArenaPlacedrop.rectTransform.anchoredPosition = new Vector2(this.Img_ArenaPlacedrop.rectTransform.anchoredPosition.x, -44f - this.mArenaPlacedropCD / 1f * 20f);
		}
	}

	// Token: 0x060010B8 RID: 4280 RVA: 0x001DB578 File Offset: 0x001D9778
	private uint GetAllPower()
	{
		int num = this.AM.m_ArenaDefHero.Length;
		uint num2 = 0u;
		for (int i = 0; i < num; i++)
		{
			num2 += this.GetPower(this.AM.m_ArenaDefHero[i]);
		}
		return num2;
	}

	// Token: 0x060010B9 RID: 4281 RVA: 0x001DB5C0 File Offset: 0x001D97C0
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

	// Token: 0x060010BA RID: 4282 RVA: 0x001DB718 File Offset: 0x001D9918
	public override void OnClose()
	{
		if (this.Cstr_ReplayNum != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_ReplayNum);
		}
		if (this.Cstr_Propaganda != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Propaganda);
		}
		if (this.Cstr_Strength != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Strength);
		}
		if (this.Cstr_Rank != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Rank);
		}
		if (this.Cstr_Count != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Count);
		}
		if (this.Cstr_CD != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_CD);
		}
		if (this.Cstr_CDTime != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_CDTime);
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.Cstr_TargetName[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_TargetName[i]);
			}
			if (this.Cstr_TargetRank[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_TargetRank[i]);
			}
			if (this.Cstr_TargetStrength[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_TargetStrength[i]);
			}
		}
		if (this.AM.m_ArenaPlacedropTime > 0f)
		{
			this.AM.m_ArenaPlacedropTime = 0f;
		}
		if (this.AM.bShowArenaPlacedrop)
		{
			this.AM.bShowArenaPlacedrop = false;
		}
	}

	// Token: 0x060010BB RID: 4283 RVA: 0x001DB89C File Offset: 0x001D9A9C
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
			if (this.AM.CheckArenaClose() > 0)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID((uint)this.AM.CheckArenaClose()), 255, true);
			}
			else
			{
				this.door.OpenMenu(EGUIWindow.UI_BattleHeroSelect, 0, -1, true);
			}
			break;
		case 2:
			this.door.OpenMenu(EGUIWindow.UI_Arena_I, 0, 0, false);
			break;
		case 3:
		case 4:
		case 5:
			this.AM.m_ArenaTargetIdx = (byte)(sender.m_BtnID1 - 3);
			if (5 - this.AM.m_ArenaTodayChallenge + this.AM.m_ArenaExtraChallenge == 0)
			{
				int cost;
				if ((int)this.AM.m_ArenaTodayResetChallenge >= this.AM.m_TodayChallengeCost.Length)
				{
					cost = (int)this.AM.m_TodayChallengeCost[11];
				}
				else
				{
					cost = (int)this.AM.m_TodayChallengeCost[(int)this.AM.m_ArenaTodayResetChallenge];
				}
				GUIManager.Instance.OpenSpendWindow_Normal(this, this.DM.mStringTable.GetStringByID(9144u), this.DM.mStringTable.GetStringByID(9145u), cost, 3, 0, this.DM.mStringTable.GetStringByID(9146u), false);
			}
			else
			{
				this.door.OpenMenu(EGUIWindow.UI_BattleHeroSelect, (int)this.AM.m_ArenaTargetIdx, -2, true);
			}
			break;
		case 6:
			GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_TreasureBox, 9, 0, false, 0);
			break;
		case 7:
			if (this.AM.CheckArenaClose() > 0)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID((uint)this.AM.CheckArenaClose()), 255, true);
			}
			else
			{
				int cost2;
				if ((int)this.AM.m_ArenaTodayResetChallenge >= this.AM.m_TodayChallengeCost.Length)
				{
					cost2 = (int)this.AM.m_TodayChallengeCost[11];
				}
				else
				{
					cost2 = (int)this.AM.m_TodayChallengeCost[(int)this.AM.m_ArenaTodayResetChallenge];
				}
				GUIManager.Instance.OpenSpendWindow_Normal(this, this.DM.mStringTable.GetStringByID(9144u), this.DM.mStringTable.GetStringByID(9145u), cost2, 1, 0, this.DM.mStringTable.GetStringByID(9146u), false);
			}
			break;
		case 8:
			if (this.AM.CheckArenaClose() > 0)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID((uint)this.AM.CheckArenaClose()), 255, true);
			}
			else if (!this.bCDReSet)
			{
				if (this.bSetHero)
				{
					this.bCDReSet = true;
					this.CDReSetTime = 1;
					this.AM.SendArena_Refresh_Target(1);
				}
				else
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9120u), 255, true);
				}
			}
			break;
		case 9:
			if (this.AM.CheckArenaClose() > 0)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID((uint)this.AM.CheckArenaClose()), 255, true);
			}
			else
			{
				this.door.OpenMenu(EGUIWindow.UI_BattleHeroSelect, 0, -1, true);
			}
			break;
		case 10:
			if (this.bSetHero)
			{
				this.door.OpenMenu(EGUIWindow.UI_Arena_Replay, 0, 0, false);
			}
			break;
		case 11:
			if (this.AM.CheckArenaClose() > 0)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID((uint)this.AM.CheckArenaClose()), 255, true);
			}
			else
			{
				UILeaderBoard.NewOpen = true;
				this.door.OpenMenu(EGUIWindow.UI_LeaderBoard, 3, 0, false);
			}
			break;
		case 13:
			this.door.OpenMenu(EGUIWindow.UI_Arena_Info, 0, 0, false);
			break;
		}
	}

	// Token: 0x060010BC RID: 4284 RVA: 0x001DBCF8 File Offset: 0x001D9EF8
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton component = sender.transform.GetComponent<UIButton>();
		switch (component.m_BtnID1)
		{
		case 12:
			sender.m_ForcePos = true;
			sender.GetTipPosition(this.GUIM.m_Arena_Hint.m_RectTransform, UIButtonHint.ePosition.Original, null);
			this.AM.m_ArenaTargetHint = this.AM.m_ArenaTarget[(int)((byte)component.m_BtnID2)];
			this.GUIM.m_Arena_Hint.Show(sender.transform.GetComponent<UIButtonHint>(), 120f, (float)(50 - 100 * component.m_BtnID2), 0);
			break;
		case 14:
			this.Img_StrengthHint.gameObject.SetActive(true);
			break;
		}
	}

	// Token: 0x060010BD RID: 4285 RVA: 0x001DBDCC File Offset: 0x001D9FCC
	public void OnButtonUp(UIButtonHint sender)
	{
		UIButton component = sender.transform.GetComponent<UIButton>();
		switch (component.m_BtnID1)
		{
		case 12:
			this.GUIM.m_Arena_Hint.Hide(sender);
			break;
		case 14:
			this.Img_StrengthHint.gameObject.SetActive(false);
			break;
		}
	}

	// Token: 0x060010BE RID: 4286 RVA: 0x001DBE34 File Offset: 0x001DA034
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			switch (arg1)
			{
			case 1:
			{
				int num;
				if ((int)this.AM.m_ArenaTodayResetChallenge >= this.AM.m_TodayChallengeCost.Length)
				{
					num = (int)this.AM.m_TodayChallengeCost[11];
				}
				else
				{
					num = (int)this.AM.m_TodayChallengeCost[(int)this.AM.m_ArenaTodayResetChallenge];
				}
				if ((ulong)this.DM.RoleAttr.Diamond >= (ulong)((long)num))
				{
					if (!GUIManager.Instance.OpenCheckCrystal((uint)num, 2, -1, -1))
					{
						this.AM.SendArena_ReSet_TodayChallenge();
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
			}
			case 2:
				if (this.DM.RoleAttr.Diamond >= 120u)
				{
					this.AM.SendArena_ReSet_Challenge_CD();
				}
				else
				{
					CString cstring2 = StringManager.Instance.StaticString1024();
					cstring2.ClearString();
					cstring2.StringToFormat(this.DM.mStringTable.GetStringByID(9147u));
					cstring2.AppendFormat(this.DM.mStringTable.GetStringByID(3857u));
					this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966u), cstring2.ToString(), this.DM.mStringTable.GetStringByID(3968u), this, 5, 0, true, false, false, false, false);
				}
				break;
			case 3:
			{
				int num2;
				if ((int)this.AM.m_ArenaTodayResetChallenge >= this.AM.m_TodayChallengeCost.Length)
				{
					num2 = (int)this.AM.m_TodayChallengeCost[11];
				}
				else
				{
					num2 = (int)this.AM.m_TodayChallengeCost[(int)this.AM.m_ArenaTodayResetChallenge];
				}
				if ((ulong)this.DM.RoleAttr.Diamond >= (ulong)((long)num2))
				{
					if (!GUIManager.Instance.OpenCheckCrystal((uint)num2, 2, -1, -1))
					{
						this.AM.SendArena_ReSet_TodayChallenge();
					}
					this.bChallengeCount = true;
				}
				else
				{
					CString cstring3 = StringManager.Instance.StaticString1024();
					cstring3.ClearString();
					cstring3.StringToFormat(this.DM.mStringTable.GetStringByID(9144u));
					cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(3857u));
					this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966u), cstring3.ToString(), this.DM.mStringTable.GetStringByID(3968u), this, 5, 0, true, false, false, false, false);
				}
				break;
			}
			case 4:
				if (this.DM.RoleAttr.Diamond >= 120u)
				{
					this.AM.SendArena_ReSet_Challenge_CD();
					this.bChallengeCD = true;
				}
				else
				{
					CString cstring4 = StringManager.Instance.StaticString1024();
					cstring4.ClearString();
					cstring4.StringToFormat(this.DM.mStringTable.GetStringByID(9147u));
					cstring4.AppendFormat(this.DM.mStringTable.GetStringByID(3857u));
					this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966u), cstring4.ToString(), this.DM.mStringTable.GetStringByID(3968u), this, 5, 0, true, false, false, false, false);
				}
				break;
			case 5:
				MallManager.Instance.Send_Mall_Info();
				break;
			}
		}
	}

	// Token: 0x060010BF RID: 4287 RVA: 0x001DC230 File Offset: 0x001DA430
	public void SetTodayChallenge()
	{
		CString cstring = StringManager.Instance.StaticString1024();
		this.Cstr_Count.ClearString();
		if (5 - this.AM.m_ArenaTodayChallenge + this.AM.m_ArenaExtraChallenge == 0)
		{
			cstring.ClearString();
			cstring.IntToFormat(0L, 1, false);
			cstring.AppendFormat("<color=#9F1C1C>{0}</color>");
			this.Cstr_Count.StringToFormat(cstring);
			this.btn_Count.gameObject.SetActive(true);
		}
		else
		{
			this.Cstr_Count.IntToFormat((long)(5 - this.AM.m_ArenaTodayChallenge + this.AM.m_ArenaExtraChallenge), 1, false);
			this.btn_Count.gameObject.SetActive(false);
		}
		if (this.GUIM.IsArabic)
		{
			this.Cstr_Count.AppendFormat("5/{0}");
		}
		else
		{
			this.Cstr_Count.AppendFormat("{0}/5");
		}
		this.text_Count[1].text = this.Cstr_Count.ToString();
		this.text_Count[1].SetAllDirty();
		this.text_Count[1].cachedTextGenerator.Invalidate();
	}

	// Token: 0x060010C0 RID: 4288 RVA: 0x001DC358 File Offset: 0x001DA558
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			this.SetTodayChallenge();
			if (this.bChallengeCount)
			{
				this.bChallengeCount = false;
				this.door.OpenMenu(EGUIWindow.UI_BattleHeroSelect, (int)this.AM.m_ArenaTargetIdx, -2, true);
			}
			break;
		case 2:
			this.SetTodayChallenge();
			this.btn_ReSet.gameObject.SetActive(true);
			if (this.bChallengeCD)
			{
				this.bChallengeCD = false;
				if (5 - this.AM.m_ArenaTodayChallenge + this.AM.m_ArenaExtraChallenge != 0)
				{
					this.door.OpenMenu(EGUIWindow.UI_BattleHeroSelect, (int)this.AM.m_ArenaTargetIdx, -2, true);
				}
			}
			break;
		case 3:
			this.Cstr_Rank.ClearString();
			this.Cstr_Rank.IntToFormat((long)((ulong)this.AM.m_ArenaPlace), 1, true);
			this.Cstr_Rank.AppendFormat("{0}");
			this.text_Award[1].text = this.Cstr_Rank.ToString();
			this.text_Award[1].SetAllDirty();
			this.text_Award[1].cachedTextGenerator.Invalidate();
			this.text_Award[1].cachedTextGeneratorForLayout.Invalidate();
			this.mArenaPlacedropX = 90f;
			if (this.text_Award[1].preferredWidth < 110f)
			{
				this.mArenaPlacedropX = this.text_Award[1].preferredWidth / 2f + 35f;
			}
			this.Img_ArenaPlacedrop.rectTransform.anchoredPosition = new Vector2(-this.mArenaPlacedropX, this.Img_ArenaPlacedrop.rectTransform.anchoredPosition.y);
			break;
		case 4:
		{
			CString cstring = StringManager.Instance.StaticString1024();
			CString cstring2 = StringManager.Instance.StaticString1024();
			for (int i = 0; i < 3; i++)
			{
				this.GUIM.ChangeHeroItemImg(this.btn_Opponent[i].transform, eHeroOrItem.Hero, this.AM.m_ArenaTarget[i].Head, 11, 0, 0);
				this.Cstr_TargetRank[i].ClearString();
				this.Cstr_TargetRank[i].IntToFormat((long)((ulong)this.AM.m_ArenaTarget[i].Place), 1, true);
				this.Cstr_TargetRank[i].AppendFormat("{0}");
				this.text_Rank[i].text = this.Cstr_TargetRank[i].ToString();
				this.text_Rank[i].SetAllDirty();
				this.text_Rank[i].cachedTextGenerator.Invalidate();
				this.Cstr_TargetStrength[i].ClearString();
				this.Cstr_TargetStrength[i].IntToFormat((long)((ulong)this.AM.GetAllPower(1, i)), 1, true);
				this.Cstr_TargetStrength[i].AppendFormat("{0}");
				this.text_OS[i].text = this.Cstr_TargetStrength[i].ToString();
				this.text_OS[i].SetAllDirty();
				this.text_OS[i].cachedTextGenerator.Invalidate();
				this.Cstr_TargetName[i].ClearString();
				cstring.ClearString();
				cstring2.ClearString();
				cstring.Append(this.AM.m_ArenaTarget[i].Name);
				if (this.AM.m_ArenaTarget[i].AllianceTagTag != string.Empty)
				{
					cstring2.Append(this.AM.m_ArenaTarget[i].AllianceTagTag);
					GameConstants.FormatRoleName(this.Cstr_TargetName[i], cstring, cstring2, null, 0, 0, null, null, null, null);
				}
				else
				{
					GameConstants.FormatRoleName(this.Cstr_TargetName[i], cstring, null, null, 0, 0, null, null, null, null);
				}
				this.text_Challenge_Name[i].text = this.Cstr_TargetName[i].ToString();
				this.text_Challenge_Name[i].SetAllDirty();
				this.text_Challenge_Name[i].cachedTextGenerator.Invalidate();
			}
			break;
		}
		case 5:
			this.Cstr_ReplayNum.ClearString();
			this.Cstr_ReplayNum.IntToFormat((long)this.AM.m_ArenaNewReportNum, 1, false);
			this.Cstr_ReplayNum.AppendFormat("{0}");
			this.text_ReplayNum.text = this.Cstr_ReplayNum.ToString();
			this.text_ReplayNum.SetAllDirty();
			this.text_ReplayNum.cachedTextGenerator.Invalidate();
			this.text_ReplayNum.cachedTextGeneratorForLayout.Invalidate();
			this.Img_ReplayNum.rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_ReplayNum.preferredWidth), this.Img_ReplayNum.rectTransform.sizeDelta.y);
			if (this.AM.m_ArenaNewReportNum > 0)
			{
				this.Img_ReplayNum.gameObject.SetActive(true);
			}
			else
			{
				this.Img_ReplayNum.gameObject.SetActive(false);
			}
			this.Cstr_Rank.ClearString();
			this.Cstr_Rank.IntToFormat((long)((ulong)this.AM.m_ArenaPlace), 1, true);
			this.Cstr_Rank.AppendFormat("{0}");
			this.text_Award[1].text = this.Cstr_Rank.ToString();
			this.text_Award[1].SetAllDirty();
			this.text_Award[1].cachedTextGenerator.Invalidate();
			this.text_Award[1].cachedTextGeneratorForLayout.Invalidate();
			this.mArenaPlacedropX = 90f;
			if (this.text_Award[1].preferredWidth < 110f)
			{
				this.mArenaPlacedropX = this.text_Award[1].preferredWidth / 2f + 35f;
			}
			this.Img_ArenaPlacedrop.rectTransform.anchoredPosition = new Vector2(-this.mArenaPlacedropX, this.Img_ArenaPlacedrop.rectTransform.anchoredPosition.y);
			break;
		case 6:
			this.AM.bArenaKVK = this.ActM.IsInKvK(0, false);
			if (this.AM.CheckArenaClose() > 0)
			{
				this.K1_T.gameObject.SetActive(false);
				this.K2_T.gameObject.SetActive(true);
				this.text_Close[0].text = this.DM.mStringTable.GetStringByID((uint)this.AM.CheckArenaClose());
				this.text_Close[0].SetAllDirty();
				this.text_Close[0].cachedTextGenerator.Invalidate();
				this.text_Close[0].gameObject.SetActive(true);
				this.text_Close[1].gameObject.SetActive(true);
				this.text_Close[2].gameObject.SetActive(false);
			}
			else
			{
				this.SetK1_Data();
			}
			break;
		case 7:
			this.bSetHero = false;
			for (int j = 0; j < 5; j++)
			{
				this.Img_HeroStar[j].gameObject.SetActive(false);
				if (DataManager.Instance.curHeroData.ContainsKey((uint)this.AM.m_ArenaDefHero[j]))
				{
					this.mcurHeroData = DataManager.Instance.curHeroData[(uint)this.AM.m_ArenaDefHero[j]];
					this.btn_Hero[j].gameObject.SetActive(true);
					this.GUIM.InitianHeroItemImg(this.btn_Hero[j].transform, eHeroOrItem.Hero, this.AM.m_ArenaDefHero[j], this.mcurHeroData.Star, this.mcurHeroData.Enhance, (int)this.mcurHeroData.Level, true, true, true, false);
					if (this.AM.CheckHeroAstrology(this.AM.m_ArenaDefHero[j]))
					{
						this.Img_HeroStar[j].gameObject.SetActive(true);
					}
					this.bSetHero = true;
					this.Img_Hero[j].gameObject.SetActive(false);
				}
				else
				{
					this.btn_Hero[j].gameObject.SetActive(false);
					this.Img_Hero[j].gameObject.SetActive(true);
				}
			}
			break;
		case 8:
		{
			this.GUIM.ChangeHeroItemImg(this.btn_Opponent[arg2].transform, eHeroOrItem.Hero, this.AM.m_ArenaTarget[arg2].Head, 11, 0, 0);
			this.Cstr_TargetRank[arg2].ClearString();
			this.Cstr_TargetRank[arg2].IntToFormat((long)((ulong)this.AM.m_ArenaTarget[arg2].Place), 1, true);
			this.Cstr_TargetRank[arg2].AppendFormat("{0}");
			this.text_Rank[arg2].text = this.Cstr_TargetRank[arg2].ToString();
			this.text_Rank[arg2].SetAllDirty();
			this.text_Rank[arg2].cachedTextGenerator.Invalidate();
			this.Cstr_TargetStrength[arg2].ClearString();
			this.Cstr_TargetStrength[arg2].IntToFormat((long)((ulong)this.AM.GetAllPower(1, arg2)), 1, true);
			this.Cstr_TargetStrength[arg2].AppendFormat("{0}");
			this.text_OS[arg2].text = this.Cstr_TargetStrength[arg2].ToString();
			this.text_OS[arg2].SetAllDirty();
			this.text_OS[arg2].cachedTextGenerator.Invalidate();
			this.Cstr_TargetName[arg2].ClearString();
			CString cstring3 = StringManager.Instance.StaticString1024();
			CString cstring4 = StringManager.Instance.StaticString1024();
			cstring3.ClearString();
			cstring4.ClearString();
			cstring3.Append(this.AM.m_ArenaTarget[arg2].Name);
			if (this.AM.m_ArenaTarget[arg2].AllianceTagTag != string.Empty)
			{
				cstring4.Append(this.AM.m_ArenaTarget[arg2].AllianceTagTag);
				GameConstants.FormatRoleName(this.Cstr_TargetName[arg2], cstring3, cstring4, null, 0, 0, null, null, null, null);
			}
			else
			{
				GameConstants.FormatRoleName(this.Cstr_TargetName[arg2], cstring3, null, null, 0, 0, null, null, null, null);
			}
			this.text_Challenge_Name[arg2].text = this.Cstr_TargetName[arg2].ToString();
			this.text_Challenge_Name[arg2].SetAllDirty();
			this.text_Challenge_Name[arg2].cachedTextGenerator.Invalidate();
			break;
		}
		case 9:
			if (this.AM.m_ArenaCrystalPrize > 0u)
			{
				this.Img_Award.gameObject.SetActive(true);
			}
			else
			{
				this.Img_Award.gameObject.SetActive(false);
			}
			break;
		case 10:
			this.AM.bArenaKVK = this.ActM.IsInKvK(0, false);
			if (this.AM.CheckArenaClose() > 0)
			{
				this.K1_T.gameObject.SetActive(false);
				this.K2_T.gameObject.SetActive(true);
				this.text_Close[0].text = this.DM.mStringTable.GetStringByID((uint)this.AM.CheckArenaClose());
				this.text_Close[0].SetAllDirty();
				this.text_Close[0].cachedTextGenerator.Invalidate();
				this.text_Close[0].gameObject.SetActive(true);
				this.text_Close[1].gameObject.SetActive(true);
				this.text_Close[2].gameObject.SetActive(false);
			}
			else
			{
				this.SetK1_Data();
			}
			this.GUIM.m_Arena_Hint.m_RectTransform.gameObject.SetActive(false);
			this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9162u), 255, true);
			break;
		case 11:
			if (this.Img_ArenaPlacedrop != null && this.DM.CheckPrizeFlag(20))
			{
				this.Img_ArenaPlacedrop.gameObject.SetActive(true);
				this.AM.SendArena_UIClear();
			}
			break;
		}
	}

	// Token: 0x060010C1 RID: 4289 RVA: 0x001DCF44 File Offset: 0x001DB144
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
		else
		{
			this.AM.bArenaKVK = this.ActM.IsInKvK(0, false);
			if (this.AM.CheckArenaClose() > 0)
			{
				this.K1_T.gameObject.SetActive(false);
				this.K2_T.gameObject.SetActive(true);
			}
			else
			{
				this.SetK1_Data();
			}
		}
	}

	// Token: 0x060010C2 RID: 4290 RVA: 0x001DCFD0 File Offset: 0x001DB1D0
	public void SetK1_Data()
	{
		this.Cstr_Propaganda.ClearString();
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		CString cstring3 = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring2.ClearString();
		cstring3.ClearString();
		this.AM.GetHeroAstrology(cstring, cstring2);
		if (this.AM.m_NowArenaTopicID[0] != 0 && this.AM.m_NowArenaTopicID[1] != 0)
		{
			cstring3.StringToFormat(cstring);
			cstring3.StringToFormat(cstring2);
			cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9118u));
		}
		else
		{
			if (this.AM.m_NowArenaTopicID[0] != 0)
			{
				cstring3.StringToFormat(cstring);
			}
			else
			{
				cstring3.StringToFormat(cstring2);
			}
			cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9154u));
		}
		this.Cstr_Propaganda.Append(cstring3);
		this.Cstr_Propaganda.Append("     ");
		cstring.ClearString();
		cstring2.ClearString();
		cstring3.ClearString();
		if (this.AM.m_NowTopicEffect[0].Effect != 0 && this.AM.m_NowTopicEffect[1].Effect != 0)
		{
			GameConstants.GetEffectValue(cstring, this.AM.m_NowTopicEffect[0].Effect, (uint)this.AM.m_NowTopicEffect[0].Value, 10, 0f);
			GameConstants.GetEffectValue(cstring2, this.AM.m_NowTopicEffect[1].Effect, (uint)this.AM.m_NowTopicEffect[1].Value, 10, 0f);
			cstring3.StringToFormat(cstring);
			cstring3.StringToFormat(cstring2);
			cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9119u));
			cstring3.Append(" ");
		}
		else
		{
			if (this.AM.m_NowTopicEffect[0].Effect != 0)
			{
				GameConstants.GetEffectValue(cstring, this.AM.m_NowTopicEffect[0].Effect, (uint)this.AM.m_NowTopicEffect[0].Value, 10, 0f);
			}
			else
			{
				GameConstants.GetEffectValue(cstring, this.AM.m_NowTopicEffect[1].Effect, (uint)this.AM.m_NowTopicEffect[1].Value, 10, 0f);
			}
			cstring3.StringToFormat(cstring);
			cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9155u));
			cstring3.Append(" ");
		}
		this.Cstr_Propaganda.Append(cstring3);
		this.text_Propaganda[0].text = this.Cstr_Propaganda.ToString();
		this.text_Propaganda[1].font = this.TTFont;
		this.text_Propaganda[1].text = this.Cstr_Propaganda.ToString();
		this.text_Propaganda[0].rectTransform.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth + 160f, this.text_Propaganda[0].rectTransform.sizeDelta.y);
		this.text_Propaganda[1].rectTransform.anchoredPosition = new Vector2(this.text_Propaganda[0].preferredWidth + 160f, this.text_Propaganda[1].rectTransform.anchoredPosition.y);
		this.text_Propaganda[1].rectTransform.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth + 160f, this.text_Propaganda[1].rectTransform.sizeDelta.y);
		this.img_text.tmpLength = this.text_Propaganda[0].preferredWidth + 160f;
		for (int i = 0; i < 2; i++)
		{
			this.text_Propaganda[i].SetAllDirty();
			this.text_Propaganda[i].cachedTextGenerator.Invalidate();
		}
		this.bSetHero = false;
		for (int j = 0; j < 5; j++)
		{
			this.Img_HeroStar[j].gameObject.SetActive(false);
			if (DataManager.Instance.curHeroData.ContainsKey((uint)this.AM.m_ArenaDefHero[j]))
			{
				this.mcurHeroData = DataManager.Instance.curHeroData[(uint)this.AM.m_ArenaDefHero[j]];
				this.btn_Hero[j].gameObject.SetActive(true);
				this.GUIM.ChangeHeroItemImg(this.btn_Hero[j].transform, eHeroOrItem.Hero, this.AM.m_ArenaDefHero[j], this.mcurHeroData.Star, this.mcurHeroData.Enhance, (int)this.mcurHeroData.Level);
				if (this.AM.CheckHeroAstrology(this.AM.m_ArenaDefHero[j]))
				{
					this.Img_HeroStar[j].gameObject.SetActive(true);
				}
				this.bSetHero = true;
				this.Img_Hero[j].gameObject.SetActive(false);
			}
			else
			{
				this.btn_Hero[j].gameObject.SetActive(false);
				this.Img_Hero[j].gameObject.SetActive(true);
			}
		}
		this.Cstr_Count.ClearString();
		if (5 - this.AM.m_ArenaTodayChallenge + this.AM.m_ArenaExtraChallenge == 0)
		{
			cstring.ClearString();
			cstring.IntToFormat(0L, 1, false);
			cstring.AppendFormat("<color=#9F1C1C>{0}</color>");
			this.Cstr_Count.StringToFormat(cstring);
			this.btn_Count.gameObject.SetActive(true);
		}
		else
		{
			this.Cstr_Count.IntToFormat((long)(5 - this.AM.m_ArenaTodayChallenge + this.AM.m_ArenaExtraChallenge), 1, false);
			this.btn_Count.gameObject.SetActive(false);
		}
		if (this.GUIM.IsArabic)
		{
			this.Cstr_Count.AppendFormat("5/{0}");
		}
		else
		{
			this.Cstr_Count.AppendFormat("{0}/5");
		}
		this.text_Count[1].text = this.Cstr_Count.ToString();
		this.text_Count[1].SetAllDirty();
		this.text_Count[1].cachedTextGenerator.Invalidate();
		this.Cstr_Rank.ClearString();
		this.Cstr_Rank.IntToFormat((long)((ulong)this.AM.m_ArenaPlace), 1, true);
		this.Cstr_Rank.AppendFormat("{0}");
		this.text_Award[1].text = this.Cstr_Rank.ToString();
		this.text_Award[1].SetAllDirty();
		this.text_Award[1].cachedTextGenerator.Invalidate();
		this.text_Award[1].cachedTextGeneratorForLayout.Invalidate();
		this.mArenaPlacedropX = 90f;
		if (this.text_Award[1].preferredWidth < 110f)
		{
			this.mArenaPlacedropX = this.text_Award[1].preferredWidth / 2f + 35f;
		}
		this.Img_ArenaPlacedrop.rectTransform.anchoredPosition = new Vector2(-this.mArenaPlacedropX, this.Img_ArenaPlacedrop.rectTransform.anchoredPosition.y);
		CString cstring4 = StringManager.Instance.StaticString1024();
		CString cstring5 = StringManager.Instance.StaticString1024();
		for (int k = 0; k < 3; k++)
		{
			this.GUIM.ChangeHeroItemImg(this.btn_Opponent[k].transform, eHeroOrItem.Hero, this.AM.m_ArenaTarget[k].Head, 11, 0, 0);
			this.Cstr_TargetRank[k].ClearString();
			this.Cstr_TargetRank[k].IntToFormat((long)((ulong)this.AM.m_ArenaTarget[k].Place), 1, true);
			this.Cstr_TargetRank[k].AppendFormat("{0}");
			this.text_Rank[k].text = this.Cstr_TargetRank[k].ToString();
			this.text_Rank[k].SetAllDirty();
			this.text_Rank[k].cachedTextGenerator.Invalidate();
			this.Cstr_TargetStrength[k].ClearString();
			this.Cstr_TargetStrength[k].IntToFormat((long)((ulong)this.AM.GetAllPower(1, k)), 1, true);
			this.Cstr_TargetStrength[k].AppendFormat("{0}");
			this.text_OS[k].text = this.Cstr_TargetStrength[k].ToString();
			this.text_OS[k].SetAllDirty();
			this.text_OS[k].cachedTextGenerator.Invalidate();
			this.Cstr_TargetName[k].ClearString();
			cstring4.ClearString();
			cstring5.ClearString();
			cstring4.Append(this.AM.m_ArenaTarget[k].Name);
			if (this.AM.m_ArenaTarget[k].AllianceTagTag != string.Empty)
			{
				cstring5.Append(this.AM.m_ArenaTarget[k].AllianceTagTag);
				GameConstants.FormatRoleName(this.Cstr_TargetName[k], cstring4, cstring5, null, 0, 0, null, null, null, null);
			}
			else
			{
				GameConstants.FormatRoleName(this.Cstr_TargetName[k], cstring4, null, null, 0, 0, null, null, null, null);
			}
			this.text_Challenge_Name[k].text = this.Cstr_TargetName[k].ToString();
			this.text_Challenge_Name[k].SetAllDirty();
			this.text_Challenge_Name[k].cachedTextGenerator.Invalidate();
		}
		this.Cstr_ReplayNum.ClearString();
		this.Cstr_ReplayNum.IntToFormat((long)this.AM.m_ArenaNewReportNum, 1, false);
		this.Cstr_ReplayNum.AppendFormat("{0}");
		this.text_ReplayNum.text = this.Cstr_ReplayNum.ToString();
		this.text_ReplayNum.SetAllDirty();
		this.text_ReplayNum.cachedTextGenerator.Invalidate();
		this.text_ReplayNum.cachedTextGeneratorForLayout.Invalidate();
		this.Img_ReplayNum.rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_ReplayNum.preferredWidth), this.Img_ReplayNum.rectTransform.sizeDelta.y);
		if (this.AM.m_ArenaNewReportNum > 0)
		{
			this.Img_ReplayNum.gameObject.SetActive(true);
		}
		else
		{
			this.Img_ReplayNum.gameObject.SetActive(false);
		}
		if (this.bSetHero)
		{
			this.K1_T.gameObject.SetActive(true);
			this.K2_T.gameObject.SetActive(false);
			this.btn_ReSet.ForTextChange(e_BtnType.e_Normal);
		}
		else
		{
			this.K1_T.gameObject.SetActive(false);
			this.K2_T.gameObject.SetActive(true);
			this.text_Close[0].gameObject.SetActive(false);
			this.text_Close[1].gameObject.SetActive(false);
			this.text_Close[2].gameObject.SetActive(true);
			this.btn_ReSet.ForTextChange(e_BtnType.e_ChangeText);
		}
		if (this.AM.m_ArenaCrystalPrize > 0u)
		{
			this.Img_Award.gameObject.SetActive(true);
		}
		else
		{
			this.Img_Award.gameObject.SetActive(false);
		}
	}

	// Token: 0x060010C3 RID: 4291 RVA: 0x001DDB70 File Offset: 0x001DBD70
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_ReplayNum != null && this.text_ReplayNum.enabled)
		{
			this.text_ReplayNum.enabled = false;
			this.text_ReplayNum.enabled = true;
		}
		if (this.img_text != null)
		{
			if (this.img_text.m_RunningText1 != null && this.img_text.m_RunningText1.enabled)
			{
				this.img_text.m_RunningText1.enabled = false;
				this.img_text.m_RunningText1.enabled = true;
			}
			if (this.img_text.m_RunningText2 != null && this.img_text.m_RunningText2.enabled)
			{
				this.img_text.m_RunningText2.enabled = false;
				this.img_text.m_RunningText2.enabled = true;
			}
		}
		if (this.text_Defend != null && this.text_Defend.enabled)
		{
			this.text_Defend.enabled = false;
			this.text_Defend.enabled = true;
		}
		if (this.text_Strength != null && this.text_Strength.enabled)
		{
			this.text_Strength.enabled = false;
			this.text_Strength.enabled = true;
		}
		if (this.text_ReSet != null && this.text_ReSet.enabled)
		{
			this.text_ReSet.enabled = false;
			this.text_ReSet.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_Propaganda[i] != null && this.text_Propaganda[i].enabled)
			{
				this.text_Propaganda[i].enabled = false;
				this.text_Propaganda[i].enabled = true;
			}
			if (this.text_Award[i] != null && this.text_Award[i].enabled)
			{
				this.text_Award[i].enabled = false;
				this.text_Award[i].enabled = true;
			}
			if (this.text_Count[i] != null && this.text_Count[i].enabled)
			{
				this.text_Count[i].enabled = false;
				this.text_Count[i].enabled = true;
			}
			if (this.text_CD[i] != null && this.text_CD[i].enabled)
			{
				this.text_CD[i].enabled = false;
				this.text_CD[i].enabled = true;
			}
		}
		for (int j = 0; j < 3; j++)
		{
			if (this.text_Rank[j] != null && this.text_Rank[j].enabled)
			{
				this.text_Rank[j].enabled = false;
				this.text_Rank[j].enabled = true;
			}
			if (this.text_OS[j] != null && this.text_OS[j].enabled)
			{
				this.text_OS[j].enabled = false;
				this.text_OS[j].enabled = true;
			}
			if (this.text_Close[j] != null && this.text_Close[j].enabled)
			{
				this.text_Close[j].enabled = false;
				this.text_Close[j].enabled = true;
			}
			if (this.text_Challenge[j] != null && this.text_Challenge[j].enabled)
			{
				this.text_Challenge[j].enabled = false;
				this.text_Challenge[j].enabled = true;
			}
			if (this.text_Challenge_Name[j] != null && this.text_Challenge_Name[j].enabled)
			{
				this.text_Challenge_Name[j].enabled = false;
				this.text_Challenge_Name[j].enabled = true;
			}
			if (this.btn_Opponent[j] != null && this.btn_Opponent[j].enabled)
			{
				this.btn_Opponent[j].Refresh_FontTexture();
			}
		}
		for (int k = 0; k < 5; k++)
		{
			if (this.btn_Hero[k] != null && this.btn_Hero[k].enabled)
			{
				this.btn_Hero[k].Refresh_FontTexture();
			}
		}
	}

	// Token: 0x060010C4 RID: 4292 RVA: 0x001DE028 File Offset: 0x001DC228
	public long CheckKOWCountTime()
	{
		long num = 0L;
		if (this.AM.m_ArenaClose_CDTime != 0L && (this.AM.m_ArenaClose_ActivityType == EActivityType.EAT_KingOfTheWorld || this.AM.m_ArenaClose_ActivityType == EActivityType.EAT_FederalEvent))
		{
			num = this.AM.m_ArenaClose_CDTime - DataManager.Instance.ServerTime;
		}
		if (num < 0L)
		{
			num = 0L;
		}
		return num;
	}

	// Token: 0x060010C5 RID: 4293 RVA: 0x001DE090 File Offset: 0x001DC290
	private void Start()
	{
	}

	// Token: 0x060010C6 RID: 4294 RVA: 0x001DE094 File Offset: 0x001DC294
	private void Update()
	{
	}

	// Token: 0x04003682 RID: 13954
	private DataManager DM;

	// Token: 0x04003683 RID: 13955
	private GUIManager GUIM;

	// Token: 0x04003684 RID: 13956
	private ArenaManager AM;

	// Token: 0x04003685 RID: 13957
	private ActivityManager ActM;

	// Token: 0x04003686 RID: 13958
	private Transform GameT;

	// Token: 0x04003687 RID: 13959
	private Transform K1_T;

	// Token: 0x04003688 RID: 13960
	private Transform K2_T;

	// Token: 0x04003689 RID: 13961
	private Door door;

	// Token: 0x0400368A RID: 13962
	private Font TTFont;

	// Token: 0x0400368B RID: 13963
	private UIButton btn_EXIT;

	// Token: 0x0400368C RID: 13964
	public UIButton btn_Defend;

	// Token: 0x0400368D RID: 13965
	private UIButton btn_I;

	// Token: 0x0400368E RID: 13966
	private UIButton btn_Award;

	// Token: 0x0400368F RID: 13967
	private UIButton btn_Count;

	// Token: 0x04003690 RID: 13968
	private UIButton btn_ReSet;

	// Token: 0x04003691 RID: 13969
	private UIButton btn_Replay;

	// Token: 0x04003692 RID: 13970
	private UIButton btn_Rank;

	// Token: 0x04003693 RID: 13971
	private UIButton btn_Astrology;

	// Token: 0x04003694 RID: 13972
	private UIButton btn_StrengthHint;

	// Token: 0x04003695 RID: 13973
	private UIButton[] btn_Challenge = new UIButton[3];

	// Token: 0x04003696 RID: 13974
	private UIButton[] btn_Hint = new UIButton[3];

	// Token: 0x04003697 RID: 13975
	private UIButton[] btn_DefendHero = new UIButton[5];

	// Token: 0x04003698 RID: 13976
	private UIHIBtn[] btn_Hero = new UIHIBtn[5];

	// Token: 0x04003699 RID: 13977
	private UIHIBtn[] btn_Opponent = new UIHIBtn[3];

	// Token: 0x0400369A RID: 13978
	private Image Img_ReplayNum;

	// Token: 0x0400369B RID: 13979
	private Image Img_StrengthHint;

	// Token: 0x0400369C RID: 13980
	private Image Img_Award;

	// Token: 0x0400369D RID: 13981
	private Image Img_ArenaPlacedrop;

	// Token: 0x0400369E RID: 13982
	private Image[] Img_Hero = new Image[5];

	// Token: 0x0400369F RID: 13983
	private Image[] Img_HeroStar = new Image[5];

	// Token: 0x040036A0 RID: 13984
	private Image[] Img_Rank = new Image[3];

	// Token: 0x040036A1 RID: 13985
	private Image[] Img_OS = new Image[3];

	// Token: 0x040036A2 RID: 13986
	private UIText text_Title;

	// Token: 0x040036A3 RID: 13987
	private UIText text_ReplayNum;

	// Token: 0x040036A4 RID: 13988
	private UIText text_Defend;

	// Token: 0x040036A5 RID: 13989
	private UIText text_Strength;

	// Token: 0x040036A6 RID: 13990
	private UIText text_StrengthHint;

	// Token: 0x040036A7 RID: 13991
	private UIText text_ReSet;

	// Token: 0x040036A8 RID: 13992
	private UIText[] text_Propaganda = new UIText[2];

	// Token: 0x040036A9 RID: 13993
	private UIText[] text_Award = new UIText[2];

	// Token: 0x040036AA RID: 13994
	private UIText[] text_Count = new UIText[2];

	// Token: 0x040036AB RID: 13995
	private UIText[] text_CD = new UIText[2];

	// Token: 0x040036AC RID: 13996
	private UIText[] text_Rank = new UIText[3];

	// Token: 0x040036AD RID: 13997
	private UIText[] text_OS = new UIText[3];

	// Token: 0x040036AE RID: 13998
	private UIText[] text_Challenge = new UIText[3];

	// Token: 0x040036AF RID: 13999
	private UIText[] text_Challenge_Name = new UIText[3];

	// Token: 0x040036B0 RID: 14000
	private UIText[] text_Close = new UIText[3];

	// Token: 0x040036B1 RID: 14001
	private CString Cstr_ReplayNum;

	// Token: 0x040036B2 RID: 14002
	private CString Cstr_Propaganda;

	// Token: 0x040036B3 RID: 14003
	private CString Cstr_Strength;

	// Token: 0x040036B4 RID: 14004
	private CString Cstr_Rank;

	// Token: 0x040036B5 RID: 14005
	private CString Cstr_Count;

	// Token: 0x040036B6 RID: 14006
	private CString Cstr_CD;

	// Token: 0x040036B7 RID: 14007
	private CString Cstr_CDTime;

	// Token: 0x040036B8 RID: 14008
	private CString[] Cstr_TargetName = new CString[3];

	// Token: 0x040036B9 RID: 14009
	private CString[] Cstr_TargetRank = new CString[3];

	// Token: 0x040036BA RID: 14010
	private CString[] Cstr_TargetStrength = new CString[3];

	// Token: 0x040036BB RID: 14011
	private UIRunningText img_text;

	// Token: 0x040036BC RID: 14012
	private bool bSetHero;

	// Token: 0x040036BD RID: 14013
	private CurHeroData mcurHeroData;

	// Token: 0x040036BE RID: 14014
	private bool bCDReSet;

	// Token: 0x040036BF RID: 14015
	private byte CDReSetTime;

	// Token: 0x040036C0 RID: 14016
	private bool bChallengeCD;

	// Token: 0x040036C1 RID: 14017
	private bool bChallengeCount;

	// Token: 0x040036C2 RID: 14018
	private float mArenaPlacedropX = 90f;

	// Token: 0x040036C3 RID: 14019
	private float mArenaPlacedropCD;
}
