using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x020002BA RID: 698
public class UIAllianceWarBattle : GUIWindow, IActivityWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x06000E14 RID: 3604 RVA: 0x001657B4 File Offset: 0x001639B4
	public override void OnOpen(int arg1, int arg2)
	{
		if (ActivityManager.Instance.AW_FightTime > 0)
		{
			this.FightTimeScale = 5.9f / (float)ActivityManager.Instance.AW_FightTime;
		}
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		if (this.door)
		{
			this.door.UpdateUI(1, 2);
		}
		GUIManager.Instance.InitianHeroItemImg(base.transform.GetChild(7).GetChild(3).GetChild(0).transform, eHeroOrItem.Hero, 0, 0, 0, 0, false, false, true, false);
		if (GUIManager.Instance.InitianHeroItemImg(base.transform.GetChild(8).GetChild(3).GetChild(0).transform, eHeroOrItem.Hero, 0, 0, 0, 0, false, false, true, false))
		{
			base.transform.GetChild(8).GetChild(3).GetChild(0).GetComponent<UIHIBtn>().HIImage.transform.localScale = new Vector3(-1f, 1f, 1f);
		}
		base.transform.GetChild(13).GetChild(1).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(13).GetChild(1).GetChild(1).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(13).GetChild(1).GetChild(2).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(13).GetChild(1).GetChild(3).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(13).GetChild(1).GetChild(4).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(13).GetChild(1).GetChild(5).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(7).GetChild(0).GetChild(0).gameObject.GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(8).GetChild(0).GetChild(0).gameObject.GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(7).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
		base.transform.GetChild(8).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
		base.transform.GetChild(13).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(4).GetComponent<UIButton>().m_Handler = this;
		base.transform.GetChild(5).GetComponent<UIButton>().m_Handler = this;
		this.HeroButt[0].HeroHead = base.transform.GetChild(7).GetChild(3).GetChild(0).gameObject;
		this.HeroButt[0].HeroHint = this.HeroButt[0].HeroHead.GetComponent<UIHIBtn>();
		this.HeroButt[0].HeroHint.m_Handler = this;
		this.HeroButt[0].HeroHint.m_BtnID1 = 1;
		this.HeroButt[1].HeroHead = base.transform.GetChild(8).GetChild(3).GetChild(0).gameObject;
		this.HeroButt[1].HeroHint = this.HeroButt[1].HeroHead.GetComponent<UIHIBtn>();
		this.HeroButt[1].HeroHint.m_Handler = this;
		this.HeroButt[1].HeroHint.m_BtnID1 = 2;
		UIButton component = base.transform.GetChild(12).GetComponent<UIButton>();
		component.m_Handler = this;
		component = base.transform.GetChild(13).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		this.m_title = base.transform.GetChild(11).GetComponent<Text>();
		this.m_title.font = GUIManager.Instance.GetTTFFont();
		this.m_title.text = this.DM.mStringTable.GetStringByID(14611u);
		this.RequestBattleOrder(arg2 > 0);
		this.BattleWait = ActivityManager.Instance.AW_WaitTime;
		this.BattleFight = ActivityManager.Instance.AW_FightTime;
		this.BattleTime = (double)ActivityManager.Instance.AW_RoundBeginTime;
		this.BattlePrepare = ActivityManager.Instance.AW_PrepareTime;
		this.BattleRoundTime = ActivityManager.Instance.AW_OneRoundTime;
		base.transform.GetChild(0).GetChild(0).gameObject.AddComponent<ActivityWindow>().Initial(e_ActivityType.Run, this);
		if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None || this.DM.RoleAlliance.Id == 0u)
		{
			this.bExit = true;
			return;
		}
		if (!ActivityManager.Instance.AW_bcalculateEnd)
		{
			base.transform.GetChild(6).GetChild(0).GetChild(1).gameObject.SetActive(false);
			base.transform.GetChild(6).GetChild(1).GetChild(1).gameObject.SetActive(false);
			this.m_player[2, 12] = base.transform.GetChild(10).GetChild(1).GetComponent<Text>();
			this.m_player[2, 12].text = this.DM.mStringTable.GetStringByID(14613u);
			this.m_player[2, 12].font = GUIManager.Instance.GetTTFFont();
			this.RequestData = this.DM.ServerTime + 180L;
			this.bReturn = true;
			return;
		}
		if (this.BattleReplay)
		{
			this.BattleTime = (double)Time.time;
			if (UIAllianceWarBattle.MatchID == UIAllianceWarBattle.BattleRoyale.MatchID && UIAllianceWarBattle.ReplayTime > 0.0)
			{
				this.BattleTime -= UIAllianceWarBattle.ReplayTime;
			}
			this.BattlePrepare = 2;
			this.ReadyGo = 12f;
		}
		else
		{
			if (ActivityManager.Instance.AW_State != EAllianceWarState.EAWS_Run)
			{
				this.bRequest = true;
				this.bReturn = true;
				return;
			}
			if (ActivityManager.Instance.AW_Round != UIAllianceWarBattle.BattleRoyale.GameRound || ActivityManager.Instance.AW_RoundBeginTime != UIAllianceWarBattle.BattleRoyale.BeginTime)
			{
				if (this.BattleSide > 0)
				{
					this.bRequest = true;
				}
				else
				{
					this.bExit = true;
				}
				this.bReturn = true;
				return;
			}
		}
		this.m_player[0, 0] = base.transform.GetChild(4).GetComponent<Text>();
		this.m_player[0, 0].font = GUIManager.Instance.GetTTFFont();
		int i;
		for (i = 0; i < 20; i++)
		{
			this.AllianceStr[i] = StringManager.Instance.SpawnString(30);
		}
		if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null && UIAllianceWarBattle.BattleRoyale.Autobots > 0)
		{
			this.AllianceStr[0].StringToFormat(UIAllianceWarBattle.BattleRoyale.AutobotTag);
			if (UIAllianceWarBattle.BattleRoyale.CampAutobot > 0)
			{
				this.AllianceStr[0].StringToFormat(this.DM.mStringTable.GetStringByID(11163u));
				this.AllianceStr[0].AppendFormat("[{0}]{1}");
			}
			else
			{
				this.AllianceStr[0].AppendFormat("[{0}]");
			}
			this.m_player[0, 0].text = this.AllianceStr[0].ToString();
			base.transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
			((RectTransform)base.transform.GetChild(4).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[0, 0].preferredWidth, this.m_player[0, 0].rectTransform.sizeDelta.x), 3f);
		}
		else
		{
			this.m_player[0, 0].text = null;
		}
		this.m_player[1, 0] = base.transform.GetChild(5).GetComponent<Text>();
		this.m_player[1, 0].font = GUIManager.Instance.GetTTFFont();
		if (UIAllianceWarBattle.BattleRoyale.DecepticonTag != null && UIAllianceWarBattle.BattleRoyale.Decepticons > 0)
		{
			this.AllianceStr[1].StringToFormat(UIAllianceWarBattle.BattleRoyale.DecepticonTag);
			if (UIAllianceWarBattle.BattleRoyale.CampDecepticon > 0)
			{
				this.AllianceStr[1].StringToFormat(this.DM.mStringTable.GetStringByID(11163u));
				this.AllianceStr[1].AppendFormat("[{0}]{1}");
			}
			else
			{
				this.AllianceStr[1].AppendFormat("[{0}]");
			}
			this.m_player[1, 0].text = this.AllianceStr[1].ToString();
			base.transform.GetChild(5).GetChild(0).gameObject.SetActive(true);
			((RectTransform)base.transform.GetChild(5).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[1, 0].preferredWidth, this.m_player[1, 0].rectTransform.sizeDelta.x), 3f);
		}
		else
		{
			this.m_player[1, 0].text = null;
		}
		if (UIAllianceWarBattle.BattleRoyale.Autobot != null && UIAllianceWarBattle.BattleRoyale.Autobots > 0)
		{
			this.m_player[0, 1] = base.transform.GetChild(6).GetChild(0).GetChild(0).GetComponent<Text>();
			this.m_player[0, 1].font = GUIManager.Instance.GetTTFFont();
			this.m_player[0, 2] = base.transform.GetChild(6).GetChild(0).GetChild(1).GetChild(1).GetComponent<Text>();
			this.m_player[0, 2].font = GUIManager.Instance.GetTTFFont();
			this.m_playerHint[0] = base.transform.GetChild(6).GetChild(0).GetChild(0).gameObject.AddComponent<UIButtonHint>();
			this.m_playerHint[0].m_eHint = EUIButtonHint.DownUpHandler;
			this.m_playerHint[0].m_Handler = this;
			this.m_playerHint[0].Parm1 = 0;
			this.m_playerHint[0].Parm2 = UIAllianceWarBattle.BattleRoyale.Autobots;
			this.m_playerHint[0].ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
			((RectTransform)base.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[0, 1].preferredWidth, this.m_player[0, 1].rectTransform.sizeDelta.x), 3f);
		}
		base.transform.GetChild(6).GetChild(0).GetChild(1).gameObject.SetActive(false);
		for (i = 1; i < 6; i++)
		{
			this.m_player[0, i + 2] = base.transform.GetChild(6).GetChild(0).GetChild(i + 1).GetComponent<Text>();
			this.m_player[0, i + 2].font = GUIManager.Instance.GetTTFFont();
		}
		for (i = 0; i < 6; i++)
		{
			if (i > 0)
			{
				this.m_playerHint[i] = base.transform.GetChild(6).GetChild(0).GetChild(i + 1).gameObject.AddComponent<UIButtonHint>();
				this.m_playerHint[i].m_eHint = EUIButtonHint.DownUpHandler;
				this.m_playerHint[i].m_Handler = this;
				this.m_playerHint[i].Parm1 = 0;
				this.m_playerHint[i].Parm2 = (byte)(i - 1);
				this.m_playerHint[i].ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
			}
			this.m_player[2, i] = base.transform.GetChild(6).GetChild(0).GetChild(7 + i).GetComponent<Text>();
			this.m_player[2, i].font = GUIManager.Instance.GetTTFFont();
		}
		i = 0;
		while (i < (int)UIAllianceWarBattle.BattleRoyale.Autobots && i < 5)
		{
			if (UIAllianceWarBattle.BattleRoyale.Autobot[i].Name != null)
			{
				this.m_player[0, i + 3].text = UIAllianceWarBattle.BattleRoyale.Autobot[i].Name.ToString();
			}
			((RectTransform)base.transform.GetChild(6).GetChild(0).GetChild(i + 2).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[0, i + 3].preferredWidth, this.m_player[0, i + 3].rectTransform.sizeDelta.x), 3f);
			if (this.GM.IsArabic)
			{
				((RectTransform)base.transform.GetChild(6).GetChild(0).GetChild(i + 2).GetChild(0).transform).anchoredPosition = new Vector2(this.m_player[0, i + 3].rectTransform.sizeDelta.x - Math.Min(this.m_player[0, i + 3].preferredWidth, this.m_player[0, i + 3].rectTransform.sizeDelta.x), -12f);
			}
			this.m_player[2, i + 1].text = (i + 1).ToString();
			i++;
		}
		if (UIAllianceWarBattle.BattleRoyale.Decepticon != null && UIAllianceWarBattle.BattleRoyale.Decepticons > 0)
		{
			this.m_playerHint[6] = base.transform.GetChild(6).GetChild(1).GetChild(0).gameObject.AddComponent<UIButtonHint>();
			this.m_playerHint[6].m_eHint = EUIButtonHint.DownUpHandler;
			this.m_playerHint[6].m_Handler = this;
			this.m_playerHint[6].Parm1 = 1;
			this.m_playerHint[6].Parm2 = UIAllianceWarBattle.BattleRoyale.Decepticons;
			this.m_playerHint[6].ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
			this.m_player[1, 1] = base.transform.GetChild(6).GetChild(1).GetChild(0).GetComponent<Text>();
			this.m_player[1, 1].font = GUIManager.Instance.GetTTFFont();
			this.m_player[1, 2] = base.transform.GetChild(6).GetChild(1).GetChild(1).GetChild(1).GetComponent<Text>();
			this.m_player[1, 2].font = GUIManager.Instance.GetTTFFont();
		}
		base.transform.GetChild(6).GetChild(1).GetChild(1).gameObject.SetActive(false);
		for (i = 1; i < 6; i++)
		{
			this.m_player[1, i + 2] = base.transform.GetChild(6).GetChild(1).GetChild(i + 1).GetComponent<Text>();
			this.m_player[1, i + 2].font = GUIManager.Instance.GetTTFFont();
		}
		for (i = 0; i < 6; i++)
		{
			if (i > 0)
			{
				this.m_playerHint[i + 6] = base.transform.GetChild(6).GetChild(1).GetChild(i + 1).gameObject.AddComponent<UIButtonHint>();
				this.m_playerHint[i + 6].m_eHint = EUIButtonHint.DownUpHandler;
				this.m_playerHint[i + 6].m_Handler = this;
				this.m_playerHint[i + 6].Parm1 = 1;
				this.m_playerHint[i + 6].Parm2 = (byte)(i - 1);
				this.m_playerHint[i + 6].ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
			}
			this.m_player[2, i + 6] = base.transform.GetChild(6).GetChild(1).GetChild(7 + i).GetComponent<Text>();
			this.m_player[2, i + 6].font = GUIManager.Instance.GetTTFFont();
		}
		i = 0;
		while (i < (int)UIAllianceWarBattle.BattleRoyale.Decepticons && i < 5)
		{
			if (UIAllianceWarBattle.BattleRoyale.Decepticon[i].Name != null)
			{
				this.m_player[1, i + 3].text = UIAllianceWarBattle.BattleRoyale.Decepticon[i].Name.ToString();
			}
			((RectTransform)base.transform.GetChild(6).GetChild(1).GetChild(i + 2).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[1, i + 3].preferredWidth, this.m_player[1, i + 3].rectTransform.sizeDelta.x), 3f);
			if (this.GM.IsArabic)
			{
				((RectTransform)base.transform.GetChild(6).GetChild(1).GetChild(i + 2).GetChild(0).transform).anchoredPosition = new Vector2(this.m_player[1, i + 3].rectTransform.sizeDelta.x - Math.Min(this.m_player[1, i + 3].preferredWidth, this.m_player[1, i + 3].rectTransform.sizeDelta.x), -12f);
			}
			this.m_player[2, i + 7].text = (i + 1).ToString();
			i++;
		}
		this.m_player[0, 8] = base.transform.GetChild(7).GetChild(1).GetComponent<Text>();
		this.m_player[0, 8].font = GUIManager.Instance.GetTTFFont();
		this.m_Camp[0] = this.m_player[0, 8].color;
		if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null && UIAllianceWarBattle.BattleRoyale.AutobotTag.Length > 0)
		{
			this.AllianceStr[4].StringToFormat(UIAllianceWarBattle.BattleRoyale.AutobotTag);
			this.AllianceStr[4].AppendFormat("[{0}]");
			this.m_player[0, 8].text = this.AllianceStr[4].ToString();
			base.transform.GetChild(6).GetChild(2).GetChild(0).gameObject.SetActive(true);
		}
		else
		{
			this.m_player[0, 8].text = this.DM.mStringTable.GetStringByID(12061u);
		}
		this.m_player[0, 9] = base.transform.GetChild(7).GetChild(2).GetChild(1).GetComponent<Text>();
		this.m_player[0, 9].font = GUIManager.Instance.GetTTFFont();
		if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null && UIAllianceWarBattle.BattleRoyale.AutobotTag.Length > 0)
		{
			this.AllianceStr[5].StringToFormat(UIAllianceWarBattle.BattleRoyale.AutobotTag);
			this.AllianceStr[5].StringToFormat(UIAllianceWarBattle.BattleRoyale.Autobot[0].Name);
			this.AllianceStr[5].AppendFormat("[{0}]{1}");
			this.m_player[0, 9].text = this.AllianceStr[5].ToString();
		}
		this.m_player[0, 10] = base.transform.GetChild(7).GetChild(2).GetChild(0).GetComponent<Text>();
		this.m_player[0, 10].font = GUIManager.Instance.GetTTFFont();
		if (UIAllianceWarBattle.BattleRoyale.Autobots > 0)
		{
			this.AllianceStr[6].uLongToFormat(UIAllianceWarBattle.BattleRoyale.Autobot[0].Power, 1, true);
			this.AllianceStr[6].AppendFormat("{0}");
			this.m_player[0, 10].text = this.AllianceStr[6].ToString();
			if (!this.BattleReplay)
			{
			}
		}
		this.m_player[1, 8] = base.transform.GetChild(8).GetChild(1).GetComponent<Text>();
		this.m_player[1, 8].font = GUIManager.Instance.GetTTFFont();
		this.m_Camp[1] = this.m_player[1, 8].color;
		if (UIAllianceWarBattle.BattleRoyale.DecepticonTag != null && UIAllianceWarBattle.BattleRoyale.DecepticonTag.Length > 0)
		{
			this.AllianceStr[7].StringToFormat(UIAllianceWarBattle.BattleRoyale.DecepticonTag);
			this.AllianceStr[7].AppendFormat("[{0}]");
			this.m_player[1, 8].text = this.AllianceStr[7].ToString();
			base.transform.GetChild(6).GetChild(3).GetChild(0).gameObject.SetActive(true);
		}
		else
		{
			this.m_player[1, 8].text = this.DM.mStringTable.GetStringByID(12061u);
		}
		this.m_player[1, 9] = base.transform.GetChild(8).GetChild(2).GetChild(1).GetComponent<Text>();
		this.m_player[1, 9].font = GUIManager.Instance.GetTTFFont();
		if (UIAllianceWarBattle.BattleRoyale.DecepticonTag != null && UIAllianceWarBattle.BattleRoyale.DecepticonTag.Length > 0)
		{
			this.AllianceStr[8].StringToFormat(UIAllianceWarBattle.BattleRoyale.DecepticonTag);
			this.AllianceStr[8].StringToFormat(UIAllianceWarBattle.BattleRoyale.Decepticon[0].Name);
			this.AllianceStr[8].AppendFormat("[{0}]{1}");
			this.m_player[1, 9].text = this.AllianceStr[8].ToString();
		}
		this.m_player[1, 10] = base.transform.GetChild(8).GetChild(2).GetChild(0).GetComponent<Text>();
		this.m_player[1, 10].font = GUIManager.Instance.GetTTFFont();
		if (UIAllianceWarBattle.BattleRoyale.Decepticons > 0)
		{
			this.AllianceStr[9].uLongToFormat(UIAllianceWarBattle.BattleRoyale.Decepticon[0].Power, 1, true);
			this.AllianceStr[9].AppendFormat("{0}");
			this.m_player[1, 10].text = this.AllianceStr[9].ToString();
			if (!this.BattleReplay)
			{
			}
		}
		this.m_player[0, 11] = base.transform.GetChild(7).GetChild(4).GetComponent<Text>();
		this.m_player[0, 11].font = GUIManager.Instance.GetTTFFont();
		this.m_player[0, 12] = base.transform.GetChild(7).GetChild(4).GetChild(0).GetComponent<Text>();
		this.m_player[0, 12].font = GUIManager.Instance.GetTTFFont();
		this.m_player[1, 11] = base.transform.GetChild(8).GetChild(4).GetComponent<Text>();
		this.m_player[1, 11].font = GUIManager.Instance.GetTTFFont();
		Text text = this.m_player[1, 11];
		string text2 = this.DM.mStringTable.GetStringByID(14621u);
		this.m_player[0, 11].text = text2;
		text.text = text2;
		this.m_player[1, 12] = base.transform.GetChild(8).GetChild(4).GetChild(0).GetComponent<Text>();
		this.m_player[1, 12].font = GUIManager.Instance.GetTTFFont();
		this.m_player[0, 13] = base.transform.GetChild(7).GetChild(5).GetChild(0).GetComponent<Text>();
		this.m_player[0, 13].font = GUIManager.Instance.GetTTFFont();
		this.m_player[1, 13] = base.transform.GetChild(8).GetChild(5).GetChild(0).GetComponent<Text>();
		this.m_player[1, 13].font = GUIManager.Instance.GetTTFFont();
		this.m_player[0, 14] = base.transform.GetChild(7).GetChild(6).GetChild(1).GetComponent<Text>();
		this.m_player[0, 14].font = GUIManager.Instance.GetTTFFont();
		this.m_player[1, 14] = base.transform.GetChild(8).GetChild(6).GetChild(1).GetComponent<Text>();
		this.m_player[1, 14].font = GUIManager.Instance.GetTTFFont();
		this.m_player[2, 12] = base.transform.GetChild(10).GetChild(1).GetComponent<Text>();
		this.m_player[2, 12].font = GUIManager.Instance.GetTTFFont();
		this.m_player[2, 13] = base.transform.GetChild(9).GetChild(1).gameObject.GetComponent<Text>();
		this.m_player[2, 13].font = GUIManager.Instance.GetTTFFont();
		this.m_player[2, 14] = base.transform.GetChild(13).GetChild(1).GetChild(5).GetChild(1).GetComponent<Text>();
		this.m_player[2, 14].font = GUIManager.Instance.GetTTFFont();
		this.m_player[2, 14].text = "x1";
		this.DeadCounts[0] = base.transform.GetChild(7).GetChild(9).GetComponent<UIText>();
		this.DeadCounts[0].font = GUIManager.Instance.GetTTFFont();
		this.DeadCounts[0].color = new Color32(byte.MaxValue, 58, 58, byte.MaxValue);
		this.DeadCounts[0].rectTransform.anchoredPosition = new Vector2(-116f, -92f);
		this.DeadCounts[0].rectTransform.sizeDelta = new Vector2(220f, 60f);
		this.DeadCounts[0].resizeTextForBestFit = false;
		this.DeadCounts[0].fontSize = 36;
		this.DeadCounts[1] = base.transform.GetChild(8).GetChild(9).GetComponent<UIText>();
		this.DeadCounts[1].font = GUIManager.Instance.GetTTFFont();
		this.DeadCounts[1].color = Color.white;
		this.DeadCounts[1].rectTransform.anchoredPosition = new Vector2(116f, -92f);
		this.DeadCounts[1].rectTransform.sizeDelta = new Vector2(220f, 60f);
		this.DeadCounts[1].color = new Color32(byte.MaxValue, 58, 58, byte.MaxValue);
		this.DeadCounts[1].resizeTextForBestFit = false;
		this.DeadCounts[1].fontSize = 36;
		int num = 0;
		int num2 = 0;
		if (UIAllianceWarBattle.BattleRoyale.BattleMatch != null && UIAllianceWarBattle.BattleRoyale.BattleMatch.Length > 0)
		{
			for (i = 0; i < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length; i++)
			{
				if (UIAllianceWarBattle.BattleRoyale.BattleMatch[i].WinnerSide == 1)
				{
					num++;
				}
				else
				{
					num2++;
				}
			}
		}
		else if (UIAllianceWarBattle.BattleRoyale.Decepticons > 0)
		{
			num2 = (int)UIAllianceWarBattle.BattleRoyale.Decepticons;
		}
		else
		{
			num = (int)UIAllianceWarBattle.BattleRoyale.Autobots;
		}
		this.AllianceStr[13].IntToFormat((long)num, 1, false);
		this.AllianceStr[13].IntToFormat((long)num2, 1, false);
		this.AllianceStr[13].AppendFormat("{0} - {1}");
		this.m_player[2, 13].text = this.AllianceStr[13].ToString();
		Text text3 = this.m_player[2, 0];
		text2 = "-";
		this.m_player[2, 6].text = text2;
		text3.text = text2;
		base.transform.GetChild(13).GetChild(0).gameObject.SetActive(false);
		base.transform.GetChild(12).gameObject.SetActive(this.BattleSide > 0 && !this.BattleReplay);
		base.transform.GetChild(7).GetChild(2).GetChild(0).gameObject.SetActive(true);
		base.transform.GetChild(8).GetChild(2).GetChild(0).gameObject.SetActive(true);
		base.transform.GetChild(13).GetChild(1).GetChild(0).gameObject.SetActive(false);
		base.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.SetActive(this.DM.UserLanguage != GameLanguage.GL_Chs);
		base.transform.GetChild(2).GetChild(0).GetChild(1).gameObject.SetActive(this.DM.UserLanguage == GameLanguage.GL_Chs);
		if (UIAllianceWarBattle.BattleRoyale.BattleSide == 1)
		{
			for (i = 2; i <= 20; i += 3)
			{
				base.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(i).gameObject.SetActive(false);
			}
			i = 0;
			while (i <= (int)UIAllianceWarBattle.BattleRoyale.Autobots && UIAllianceWarBattle.BattleRoyale.Autobot != null && i < 6)
			{
				if (UIAllianceWarBattle.BattleRoyale.AutobotPos > 0 && (int)UIAllianceWarBattle.BattleRoyale.AutobotPos == i)
				{
					base.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1 + i * 3).gameObject.SetActive(false);
				}
				i++;
			}
			base.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(21).GetChild(1).gameObject.SetActive(false);
			base.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(21).GetChild(0).gameObject.SetActive(true);
			base.transform.GetChild(7).GetChild(6).GetChild(0).gameObject.SetActive(false);
		}
		else if (UIAllianceWarBattle.BattleRoyale.BattleSide == 2)
		{
			this.m_player[0, 0].color = this.m_Camp[1];
			this.m_player[1, 0].color = this.m_Camp[0];
			this.m_player[0, 8].color = this.m_Camp[1];
			this.m_player[1, 8].color = this.m_Camp[0];
			this.m_player[0, 9].color = this.m_Camp[1];
			this.m_player[1, 9].color = this.m_Camp[0];
			for (i = 2; i <= 20; i += 3)
			{
				base.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(i).gameObject.SetActive(false);
			}
			i = 0;
			while (i <= (int)UIAllianceWarBattle.BattleRoyale.Decepticons && UIAllianceWarBattle.BattleRoyale.Decepticon != null && i < 6)
			{
				if (UIAllianceWarBattle.BattleRoyale.DecepticonPos > 0 && (int)UIAllianceWarBattle.BattleRoyale.DecepticonPos == i)
				{
					base.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(1 + i * 3).gameObject.SetActive(false);
				}
				i++;
			}
			base.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(21).GetChild(1).gameObject.SetActive(false);
			base.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(21).GetChild(0).gameObject.SetActive(true);
			base.transform.GetChild(4).GetChild(0).GetComponent<Image>().color = this.m_Camp[1];
			base.transform.GetChild(5).GetChild(0).GetComponent<Image>().color = this.m_Camp[0];
			base.transform.GetChild(8).GetChild(6).GetChild(0).gameObject.SetActive(false);
		}
		else
		{
			this.m_player[0, 0].color = this.m_Camp[1];
			this.m_player[0, 8].color = this.m_Camp[1];
			this.m_player[0, 9].color = this.m_Camp[1];
			base.transform.GetChild(4).GetChild(0).GetComponent<Image>().color = this.m_Camp[1];
		}
		base.transform.GetChild(12).GetChild(0).gameObject.SetActive(ActivityManager.Instance.AW_PrizeGroupID > 0);
		this.DeadCountsStr[0] = StringManager.Instance.SpawnString(30);
		this.DeadCountsStr[1] = StringManager.Instance.SpawnString(30);
		AudioManager.Instance.PlayMP3SFX(BGMType.LegionWar, true, 0.54f);
		LeftRightFly.Instance.init();
		this.LeftRightInit = true;
		this.Refresh(0);
	}

	// Token: 0x06000E15 RID: 3605 RVA: 0x00167C3C File Offset: 0x00165E3C
	private void Refresh(int arg1 = 0)
	{
		int num = (int)(UIAllianceWarBattle.BattleRoyale.AutobotIcon & 7);
		int num2 = UIAllianceWarBattle.BattleRoyale.AutobotIcon >> 3 & 7;
		int num3 = num2 * 8 + num + 1;
		if (num3 > 64)
		{
			num3 = 64;
		}
		int num4 = (UIAllianceWarBattle.BattleRoyale.AutobotIcon >> 6 & 63) + 1;
		if (num4 > 64)
		{
			num4 = 64;
		}
		GUIManager.Instance.SetBadgeTotemImg(base.transform.GetChild(7).GetChild(0).GetChild(0).GetChild(2).transform, num3, num4);
		num = (int)(UIAllianceWarBattle.BattleRoyale.DecepticonIcon & 7);
		num2 = (UIAllianceWarBattle.BattleRoyale.DecepticonIcon >> 3 & 7);
		num3 = num2 * 8 + num + 1;
		if (num3 > 64)
		{
			num3 = 64;
		}
		num4 = (UIAllianceWarBattle.BattleRoyale.DecepticonIcon >> 6 & 63) + 1;
		if (num4 > 64)
		{
			num4 = 64;
		}
		GUIManager.Instance.SetBadgeTotemImg(base.transform.GetChild(8).GetChild(0).GetChild(0).GetChild(2).transform, num3, num4);
		base.transform.GetChild(7).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(UIAllianceWarBattle.BattleRoyale.Autobots > 0);
		base.transform.GetChild(8).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(UIAllianceWarBattle.BattleRoyale.Decepticons > 0);
		base.transform.GetChild(7).GetChild(2).gameObject.SetActive(false);
		base.transform.GetChild(8).GetChild(2).gameObject.SetActive(false);
		if (UIAllianceWarBattle.BattleRoyale.Autobot != null && UIAllianceWarBattle.BattleRoyale.Autobot.Length > 0)
		{
			GUIManager.Instance.ChangeHeroItemImg(base.transform.GetChild(7).GetChild(3).GetChild(0).transform, eHeroOrItem.Hero, UIAllianceWarBattle.BattleRoyale.Autobot[0].Head, 11, 0, 0);
			global::Hero recordByKey = this.DM.HeroTable.GetRecordByKey(UIAllianceWarBattle.BattleRoyale.Autobot[0].Head);
			this.LeftDyingSfx = recordByKey.DyingSound;
			this.LeftHurtSfx = recordByKey.HurtSound;
		}
		if (UIAllianceWarBattle.BattleRoyale.Decepticon != null && UIAllianceWarBattle.BattleRoyale.Decepticon.Length > 0)
		{
			GUIManager.Instance.ChangeHeroItemImg(base.transform.GetChild(8).GetChild(3).GetChild(0).transform, eHeroOrItem.Hero, UIAllianceWarBattle.BattleRoyale.Decepticon[0].Head, 11, 0, 0);
			global::Hero recordByKey = this.DM.HeroTable.GetRecordByKey(UIAllianceWarBattle.BattleRoyale.Decepticon[0].Head);
			this.RightDyingSfx = recordByKey.DyingSound;
			this.RightHurtSfx = recordByKey.HurtSound;
		}
		for (int i = 1; i <= 2; i++)
		{
			this.EmblemScale[i - 1] = base.transform.GetChild(6 + i).GetChild(0).GetComponent<uTweenScale>();
		}
		if (this.BattleReplay || (this.BattleTime > 0.0 && this.BattleTime >= (double)ActivityManager.Instance._ServerEventDeltaTime + NetworkManager.ServerTime - (double)this.BattlePrepare && !this.Preparing))
		{
			this.SetStage(UIAllianceWarBattle.MoveStage.MS_WAITING);
		}
		else
		{
			this.SetStage(UIAllianceWarBattle.MoveStage.MS_STARTING);
		}
		if (this.BattleReplay && UIAllianceWarBattle.ReplayTime > 0.0)
		{
			if (UIAllianceWarBattle.ReplaySpeed == 3)
			{
				this.m_player[2, 14].text = "x3";
			}
			else if (UIAllianceWarBattle.ReplaySpeed == 2)
			{
				this.m_player[2, 14].text = "x2";
			}
			else
			{
				this.m_player[2, 14].text = "x1";
			}
			base.transform.GetChild(13).GetChild(1).GetChild(4).gameObject.SetActive(false);
			for (UIAllianceWarBattle.MoveStage moveStage = this.MovieStage; moveStage < UIAllianceWarBattle.MoveStage.MS_MAX; moveStage += 1)
			{
				if (!this.bEnd)
				{
					this.Update();
				}
			}
		}
		else
		{
			UIAllianceWarBattle.ReplaySpeed = 1;
			UIAllianceWarBattle.ReplayTime = 0.0;
		}
	}

	// Token: 0x06000E16 RID: 3606 RVA: 0x001680B8 File Offset: 0x001662B8
	protected void SetStage(UIAllianceWarBattle.MoveStage MS)
	{
		this.MovieStage = MS;
		switch (this.MovieStage)
		{
		case UIAllianceWarBattle.MoveStage.MS_WAITING:
			if (this.m_player[2, 12] && !this.BattleReplay)
			{
				this.m_player[2, 12].text = this.DM.mStringTable.GetStringByID(14612u);
			}
			base.transform.GetChild(10).gameObject.SetActive(!this.BattleReplay);
			this.Preparing = true;
			break;
		case UIAllianceWarBattle.MoveStage.MS_STARTING:
			base.transform.GetChild(13).GetChild(0).gameObject.SetActive(UIAllianceWarBattle.BattleRoyale.BattleSide > 0);
			base.transform.GetChild(6).GetChild(0).GetChild(1).gameObject.SetActive(UIAllianceWarBattle.BattleRoyale.Autobot != null && UIAllianceWarBattle.BattleRoyale.Autobots > 0);
			base.transform.GetChild(6).GetChild(1).GetChild(1).gameObject.SetActive(UIAllianceWarBattle.BattleRoyale.Decepticon != null && UIAllianceWarBattle.BattleRoyale.Decepticons > 0);
			base.transform.GetChild(10).gameObject.SetActive(false);
			base.transform.GetChild(8).GetChild(6).gameObject.SetActive(true);
			base.transform.GetChild(7).GetChild(6).gameObject.SetActive(true);
			base.transform.GetChild(6).GetChild(2).GetChild(0).gameObject.SetActive(false);
			base.transform.GetChild(6).GetChild(3).GetChild(0).gameObject.SetActive(false);
			base.transform.GetChild(7).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
			base.transform.GetChild(8).GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
			base.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(21).gameObject.SetActive(false);
			base.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(21).gameObject.SetActive(false);
			base.transform.GetChild(13).GetChild(1).gameObject.SetActive(this.BattleReplay);
			base.transform.GetChild(9).GetChild(1).gameObject.SetActive(false);
			base.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
			if (this.BattleReplay && UIAllianceWarBattle.ReplayTime > 0.0)
			{
				float num = 0f;
				Time.timeScale = num;
				UIAllianceWarBattle.ReplayTime = (double)num;
			}
			this.Offset = 1;
			this.LeftRightSet = false;
			this.SetGo = true;
			this.SetStage(UIAllianceWarBattle.MoveStage.MS_FIGHTING);
			break;
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING:
			if (ActivityManager.Instance.AW_FightTime > 0)
			{
				this.BattleRound = (byte)Mathf.Clamp((int)((double)ActivityManager.Instance._ServerEventDeltaTime + NetworkManager.ServerTime - this.BattleTime - (double)this.BattlePrepare) / (int)ActivityManager.Instance.AW_FightTime, 0, (int)UIAllianceWarBattle.BattleRoyale.BattleMatchs);
				if (this.BattleReplay)
				{
					this.BattleRound = (byte)Mathf.Clamp((int)(this.PassTime - this.BattleTime - (double)this.BattlePrepare) / (int)ActivityManager.Instance.AW_FightTime, 0, (int)UIAllianceWarBattle.BattleRoyale.BattleMatchs);
				}
			}
			if (this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatchs)
			{
				base.transform.GetChild(13).GetChild(0).gameObject.SetActive(UIAllianceWarBattle.BattleRoyale.BattleSide > 0 && UIAllianceWarBattle.BattleRoyale.BattleMatchs > 0 && !this.BattleReplay);
				base.transform.GetChild(13).GetChild(1).GetChild(0).gameObject.SetActive(UIAllianceWarBattle.BattleRoyale.BattleSide > 0 && UIAllianceWarBattle.BattleRoyale.BattleMatchs > 0);
				base.transform.GetChild(13).GetChild(1).gameObject.SetActive(this.BattleReplay);
				base.transform.GetChild(7).GetChild(6).gameObject.SetActive(true);
				base.transform.GetChild(8).GetChild(6).gameObject.SetActive(true);
				base.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
				base.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
			}
			else
			{
				this.UpdateUI(6, 0);
			}
			this.UpdateUI(7, 0);
			if (UIAllianceWarBattle.BattleRoyale.Autobot != null && UIAllianceWarBattle.BattleRoyale.Autobots > 0 && this.BattleRound <= UIAllianceWarBattle.BattleRoyale.BattleMatchs)
			{
				int num2 = 0;
				for (int i = 0; i < (int)this.BattleRound; i++)
				{
					if (UIAllianceWarBattle.BattleRoyale.BattleMatch[i].WinnerSide == 2)
					{
						num2++;
					}
				}
				for (int j = 0; j < 6; j++)
				{
					if (this.m_player[2, j])
					{
						this.m_player[2, j].text = null;
					}
					if (this.m_player[0, j + 2])
					{
						this.m_player[0, j + 2].text = null;
					}
					if (this.m_playerHint[j])
					{
						this.m_playerHint[j].Parm2 = UIAllianceWarBattle.BattleRoyale.Autobots;
					}
					((RectTransform)base.transform.GetChild(6).GetChild(0).GetChild((j <= 0) ? 0 : (j + 1)).GetChild(0).transform).sizeDelta = new Vector2(0f, 3f);
				}
				if (num2 < (int)UIAllianceWarBattle.BattleRoyale.Autobots)
				{
					if (this.m_player[0, 1] && UIAllianceWarBattle.BattleRoyale.Autobot[num2].Name != null)
					{
						this.m_player[0, 1].text = UIAllianceWarBattle.BattleRoyale.Autobot[num2].Name.ToString();
					}
					this.AllianceStr[2].ClearString();
					this.AllianceStr[2].uLongToFormat(UIAllianceWarBattle.BattleRoyale.Autobot[num2].Power, 1, true);
					this.AllianceStr[2].AppendFormat("{0}");
					if (this.m_player[0, 2])
					{
						this.m_player[0, 2].text = this.AllianceStr[2].ToString();
						this.m_player[0, 2].SetAllDirty();
						this.m_player[0, 2].cachedTextGenerator.Invalidate();
					}
					if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null && UIAllianceWarBattle.BattleRoyale.AutobotTag.Length > 0)
					{
						this.AllianceStr[5].ClearString();
						this.AllianceStr[5].StringToFormat(UIAllianceWarBattle.BattleRoyale.AutobotTag);
						this.AllianceStr[5].StringToFormat(UIAllianceWarBattle.BattleRoyale.Autobot[num2].Name);
						this.AllianceStr[5].AppendFormat("[{0}]{1}");
						if (this.m_player[0, 9])
						{
							this.m_player[0, 9].text = this.AllianceStr[5].ToString();
							this.m_player[0, 9].SetAllDirty();
							this.m_player[0, 9].cachedTextGenerator.Invalidate();
						}
					}
					if ((int)this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
					{
						this.AllianceStr[6].ClearString();
						this.AllianceStr[6].uLongToFormat((ulong)(UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftSurvive + UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftDead), 1, true);
						this.AllianceStr[6].AppendFormat("{0}");
						if (this.m_player[0, 10])
						{
							this.m_player[0, 10].text = this.AllianceStr[6].ToString();
							this.m_player[0, 10].SetAllDirty();
							this.m_player[0, 10].cachedTextGenerator.Invalidate();
							this.m_player[0, 10].cachedTextGeneratorForLayout.Invalidate();
						}
					}
					if (UIAllianceWarBattle.BattleRoyale.Autobots > 0)
					{
						this.GM.ChangeHeroItemImg(base.transform.GetChild(7).GetChild(3).GetChild(0).transform, eHeroOrItem.Hero, UIAllianceWarBattle.BattleRoyale.Autobot[num2].Head, 11, 0, 0);
						if (this.HeroButt[0].HeroHint)
						{
							this.HeroButt[0].HeroHint.m_BtnID2 = num2;
						}
						global::Hero recordByKey = this.DM.HeroTable.GetRecordByKey(UIAllianceWarBattle.BattleRoyale.Autobot[num2].Head);
						this.LeftDyingSfx = recordByKey.DyingSound;
						this.LeftHurtSfx = recordByKey.HurtSound;
					}
					base.transform.GetChild(7).GetChild(2).GetChild(0).GetChild(0).transform.localPosition = new Vector3(this.m_player[0, 10].preferredWidth / -2f - 30f, 0f, 0f);
					if (this.m_player[0, 1])
					{
						((RectTransform)base.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[0, 1].preferredWidth, this.m_player[0, 1].rectTransform.sizeDelta.x), 3f);
						if (this.GM.IsArabic)
						{
							((RectTransform)base.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(0).transform).anchoredPosition = new Vector2(this.m_player[0, 1].rectTransform.sizeDelta.x - Math.Min(this.m_player[0, 1].preferredWidth, this.m_player[0, 1].rectTransform.sizeDelta.x), -12f);
						}
					}
				}
				else
				{
					if (this.m_player[0, 1])
					{
						this.m_player[0, 1].text = null;
					}
					base.transform.GetChild(6).GetChild(0).GetChild(1).gameObject.SetActive(false);
				}
				base.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(21).gameObject.SetActive(true);
				int num3 = num2 + 1;
				while (num3 < (int)UIAllianceWarBattle.BattleRoyale.Autobots && num3 < num2 + 6)
				{
					if (this.m_player[0, num3 + 2 - num2] && UIAllianceWarBattle.BattleRoyale.Autobot[num3].Name != null)
					{
						this.m_player[0, num3 + 2 - num2].text = UIAllianceWarBattle.BattleRoyale.Autobot[num3].Name.ToString();
						((RectTransform)base.transform.GetChild(6).GetChild(0).GetChild(num3 + 1 - num2).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[0, num3 + 2 - num2].preferredWidth, this.m_player[0, num3 + 2 - num2].rectTransform.sizeDelta.x), 3f);
						if (this.GM.IsArabic)
						{
							((RectTransform)base.transform.GetChild(6).GetChild(0).GetChild(num3 + 1 - num2).GetChild(0).transform).anchoredPosition = new Vector2(this.m_player[0, num3 + 2 - num2].rectTransform.sizeDelta.x - Math.Min(this.m_player[0, num3 + 2 - num2].preferredWidth, this.m_player[0, num3 + 2 - num2].rectTransform.sizeDelta.x), -12f);
						}
					}
					num3++;
				}
				for (int k = 0; k < 6; k++)
				{
					if (this.m_playerHint[k])
					{
						this.m_playerHint[k].Parm2 = (byte)(k + num2);
					}
					if (this.m_player[2, k] && k + num2 + 1 <= (int)UIAllianceWarBattle.BattleRoyale.Autobots)
					{
						this.m_player[2, k].text = (k + num2 + 1).ToString();
					}
				}
				if (UIAllianceWarBattle.BattleRoyale.AutobotPos > 0)
				{
					for (int l = 0; l < 6; l++)
					{
						base.transform.GetChild(0).GetChild(1).GetChild(1).GetChild(1 + l * 3).gameObject.SetActive((int)UIAllianceWarBattle.BattleRoyale.AutobotPos != num2 + l + 1);
					}
				}
			}
			if (UIAllianceWarBattle.BattleRoyale.Decepticon != null && UIAllianceWarBattle.BattleRoyale.Decepticons > 0 && this.BattleRound <= UIAllianceWarBattle.BattleRoyale.BattleMatchs)
			{
				int num4 = 0;
				for (int m = 0; m < (int)this.BattleRound; m++)
				{
					if (UIAllianceWarBattle.BattleRoyale.BattleMatch[m].WinnerSide == 1)
					{
						num4++;
					}
				}
				for (int n = 0; n < 6; n++)
				{
					if (this.m_player[2, n + 6])
					{
						this.m_player[2, n + 6].text = null;
					}
					if (this.m_player[1, n + 2])
					{
						this.m_player[1, n + 2].text = null;
					}
					if (this.m_playerHint[n + 6])
					{
						this.m_playerHint[n + 6].Parm2 = UIAllianceWarBattle.BattleRoyale.Decepticons;
					}
					((RectTransform)base.transform.GetChild(6).GetChild(1).GetChild((n <= 0) ? 0 : (n + 1)).GetChild(0).transform).sizeDelta = new Vector2(0f, 3f);
				}
				if (num4 < (int)UIAllianceWarBattle.BattleRoyale.Decepticons)
				{
					if (this.m_player[1, 1] && UIAllianceWarBattle.BattleRoyale.Decepticon[num4].Name != null)
					{
						this.m_player[1, 1].text = UIAllianceWarBattle.BattleRoyale.Decepticon[num4].Name.ToString();
					}
					this.AllianceStr[3].ClearString();
					this.AllianceStr[3].uLongToFormat(UIAllianceWarBattle.BattleRoyale.Decepticon[num4].Power, 1, true);
					this.AllianceStr[3].AppendFormat("{0}");
					if (this.m_player[1, 2])
					{
						this.m_player[1, 2].text = this.AllianceStr[3].ToString();
						this.m_player[1, 2].SetAllDirty();
						this.m_player[1, 2].cachedTextGenerator.Invalidate();
					}
					if (UIAllianceWarBattle.BattleRoyale.DecepticonTag != null && UIAllianceWarBattle.BattleRoyale.DecepticonTag.Length > 0)
					{
						this.AllianceStr[8].ClearString();
						this.AllianceStr[8].StringToFormat(UIAllianceWarBattle.BattleRoyale.DecepticonTag);
						this.AllianceStr[8].StringToFormat(UIAllianceWarBattle.BattleRoyale.Decepticon[num4].Name);
						this.AllianceStr[8].AppendFormat("[{0}]{1}");
						if (this.m_player[1, 9])
						{
							this.m_player[1, 9].text = this.AllianceStr[8].ToString();
							this.m_player[1, 9].SetAllDirty();
							this.m_player[1, 9].cachedTextGenerator.Invalidate();
						}
					}
					if ((int)this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
					{
						this.AllianceStr[9].ClearString();
						this.AllianceStr[9].uLongToFormat((ulong)(UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightSurvive + UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightDead), 1, true);
						this.AllianceStr[9].AppendFormat("{0}");
						if (this.m_player[1, 10])
						{
							this.m_player[1, 10].text = this.AllianceStr[9].ToString();
							this.m_player[1, 10].SetAllDirty();
							this.m_player[1, 10].cachedTextGenerator.Invalidate();
							this.m_player[1, 10].cachedTextGeneratorForLayout.Invalidate();
						}
					}
					if (UIAllianceWarBattle.BattleRoyale.Decepticons > 0)
					{
						this.GM.ChangeHeroItemImg(base.transform.GetChild(8).GetChild(3).GetChild(0).transform, eHeroOrItem.Hero, UIAllianceWarBattle.BattleRoyale.Decepticon[num4].Head, 11, 0, 0);
						if (this.HeroButt[1].HeroHint)
						{
							this.HeroButt[1].HeroHint.m_BtnID2 = num4;
						}
						global::Hero recordByKey = this.DM.HeroTable.GetRecordByKey(UIAllianceWarBattle.BattleRoyale.Decepticon[num4].Head);
						this.RightDyingSfx = recordByKey.DyingSound;
						this.RightHurtSfx = recordByKey.HurtSound;
					}
					if (this.m_player[1, 10])
					{
						base.transform.GetChild(8).GetChild(2).GetChild(0).GetChild(0).transform.localPosition = new Vector3(this.m_player[1, 10].preferredWidth / -2f - 30f, 0f, 0f);
					}
					if (this.m_player[1, 1])
					{
						((RectTransform)base.transform.GetChild(6).GetChild(1).GetChild(0).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[1, 1].preferredWidth, this.m_player[1, 1].rectTransform.sizeDelta.x), 3f);
						if (this.GM.IsArabic)
						{
							((RectTransform)base.transform.GetChild(6).GetChild(1).GetChild(0).GetChild(0).transform).anchoredPosition = new Vector2(this.m_player[1, 1].rectTransform.sizeDelta.x - Math.Min(this.m_player[1, 1].preferredWidth, this.m_player[0, 1].rectTransform.sizeDelta.x), -12f);
						}
					}
				}
				else
				{
					if (this.m_player[1, 1])
					{
						this.m_player[1, 1].text = null;
					}
					base.transform.GetChild(6).GetChild(1).GetChild(1).gameObject.SetActive(false);
				}
				base.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(21).gameObject.SetActive(true);
				int num5 = num4 + 1;
				while (num5 < (int)UIAllianceWarBattle.BattleRoyale.Decepticons && num5 < num4 + 6)
				{
					if (this.m_player[1, num5 + 2 - num4] && UIAllianceWarBattle.BattleRoyale.Decepticon[num5].Name != null)
					{
						this.m_player[1, num5 + 2 - num4].text = UIAllianceWarBattle.BattleRoyale.Decepticon[num5].Name.ToString();
						((RectTransform)base.transform.GetChild(6).GetChild(1).GetChild(num5 + 1 - num4).GetChild(0).transform).sizeDelta = new Vector2(Math.Min(this.m_player[1, num5 + 2 - num4].preferredWidth, this.m_player[1, num5 + 2 - num4].rectTransform.sizeDelta.x), 3f);
						if (this.GM.IsArabic)
						{
							((RectTransform)base.transform.GetChild(6).GetChild(1).GetChild(num5 + 1 - num4).GetChild(0).transform).anchoredPosition = new Vector2(this.m_player[1, num5 + 2 - num4].rectTransform.sizeDelta.x - Math.Min(this.m_player[1, num5 + 2 - num4].preferredWidth, this.m_player[1, num5 + 2 - num4].rectTransform.sizeDelta.x), -12f);
						}
					}
					num5++;
				}
				for (int num6 = 0; num6 < 6; num6++)
				{
					if (this.m_playerHint[num6 + 6])
					{
						this.m_playerHint[num6 + 6].Parm2 = (byte)(num6 + num4);
					}
					if (this.m_player[2, num6 + 6] && num6 + num4 + 1 <= (int)UIAllianceWarBattle.BattleRoyale.Decepticons)
					{
						this.m_player[2, num6 + 6].text = (num6 + num4 + 1).ToString();
					}
				}
				if (UIAllianceWarBattle.BattleRoyale.DecepticonPos > 0)
				{
					for (int num7 = 0; num7 < 6; num7++)
					{
						base.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(1 + num7 * 3).gameObject.SetActive((int)UIAllianceWarBattle.BattleRoyale.DecepticonPos != num4 + num7 + 1);
					}
				}
			}
			this.m_player[0, 14].text = this.m_player[2, 0].text;
			this.m_player[1, 14].text = this.m_player[2, 6].text;
			this.SetStage(UIAllianceWarBattle.MoveStage.MS_FIGHTING_START);
			break;
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_START:
			if (this.ParticleEffect_InRight != null && !this.ParticleEffect_InRight.gameObject.activeSelf)
			{
				this.ParticleEffect_InRight = null;
			}
			if (this.ParticleEffect_InLeft != null && !this.ParticleEffect_InLeft.gameObject.activeSelf)
			{
				this.ParticleEffect_InLeft = null;
			}
			this.Rand = this.GetRand();
			break;
		}
	}

	// Token: 0x06000E17 RID: 3607 RVA: 0x00169A48 File Offset: 0x00167C48
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
	}

	// Token: 0x06000E18 RID: 3608 RVA: 0x00169A4C File Offset: 0x00167C4C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (arg1 == 5)
		{
		}
	}

	// Token: 0x06000E19 RID: 3609 RVA: 0x00169A58 File Offset: 0x00167C58
	private void SetterWinner(bool LeftWin)
	{
		base.transform.GetChild(7).GetChild(5).gameObject.SetActive(LeftWin);
		base.transform.GetChild(8).GetChild(5).gameObject.SetActive(!LeftWin);
		if (LeftWin)
		{
			byte b = 0;
			int num = 0;
			while (num <= (int)this.BattleRound && num < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
			{
				if (UIAllianceWarBattle.BattleRoyale.BattleMatch[num].WinnerSide == 1)
				{
					b += 1;
				}
				else
				{
					b = 0;
				}
				num++;
			}
			if (b > 1)
			{
				this.AllianceStr[11].ClearString();
				this.AllianceStr[11].IntToFormat((long)b, 1, false);
				this.AllianceStr[11].AppendFormat(this.DM.mStringTable.GetStringByID(14619u));
				this.m_player[0, 13].text = this.AllianceStr[11].ToString();
				this.m_player[0, 13].SetAllDirty();
				this.m_player[0, 13].cachedTextGenerator.Invalidate();
			}
			else
			{
				this.m_player[0, 13].text = ((b <= 0) ? null : this.DM.mStringTable.GetStringByID(14618u));
			}
		}
		else
		{
			byte b2 = 0;
			int num2 = 0;
			while (num2 <= (int)this.BattleRound && num2 < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
			{
				if (UIAllianceWarBattle.BattleRoyale.BattleMatch[num2].WinnerSide == 2)
				{
					b2 += 1;
				}
				else
				{
					b2 = 0;
				}
				num2++;
			}
			if (b2 > 1)
			{
				this.AllianceStr[12].ClearString();
				this.AllianceStr[12].IntToFormat((long)b2, 1, false);
				this.AllianceStr[12].AppendFormat(this.DM.mStringTable.GetStringByID(14619u));
				this.m_player[1, 13].text = this.AllianceStr[12].ToString();
				this.m_player[1, 13].SetAllDirty();
				this.m_player[1, 13].cachedTextGenerator.Invalidate();
			}
			else
			{
				this.m_player[1, 13].text = ((b2 <= 0) ? null : this.DM.mStringTable.GetStringByID(14618u));
			}
		}
	}

	// Token: 0x06000E1A RID: 3610 RVA: 0x00169CF4 File Offset: 0x00167EF4
	private void CheckWinner()
	{
		if ((int)this.BattleRound >= UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
		{
			return;
		}
		if (UIAllianceWarBattle.BattleRoyale.BattleMatch != null && UIAllianceWarBattle.BattleRoyale.BattleMatch.Length > 0)
		{
			if (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].WinnerSide == 1)
			{
				if (UIAllianceWarBattle.BattleRoyale.BattleSide == 2)
				{
					this.m_player[1, 11].text = this.DM.mStringTable.GetStringByID(14622u);
					base.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
					base.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
				}
				else
				{
					this.m_player[0, 11].text = this.DM.mStringTable.GetStringByID(14621u);
					base.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
					base.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
				}
			}
			else if (UIAllianceWarBattle.BattleRoyale.BattleSide == 1)
			{
				this.m_player[0, 11].text = this.DM.mStringTable.GetStringByID(14622u);
				base.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
				base.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
			}
			else
			{
				this.m_player[1, 11].text = this.DM.mStringTable.GetStringByID(14621u);
				base.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
				base.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
			}
		}
		else if (UIAllianceWarBattle.BattleRoyale.Autobots > 0)
		{
			if (UIAllianceWarBattle.BattleRoyale.BattleSide == 2)
			{
				this.m_player[1, 11].text = this.DM.mStringTable.GetStringByID(14622u);
				base.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
				base.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
			}
			else
			{
				this.m_player[0, 11].text = this.DM.mStringTable.GetStringByID(14621u);
				base.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
				base.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
			}
		}
		else if (UIAllianceWarBattle.BattleRoyale.BattleSide == 1)
		{
			this.m_player[0, 11].text = this.DM.mStringTable.GetStringByID(14622u);
			base.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
			base.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
		}
		else
		{
			this.m_player[1, 11].text = this.DM.mStringTable.GetStringByID(14621u);
			base.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
			base.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
		}
	}

	// Token: 0x06000E1B RID: 3611 RVA: 0x0016A0E0 File Offset: 0x001682E0
	private void SetHeroMove(GameObject Go, int Pos = -1, float time = 0f, float scale = 0f)
	{
		if (Go == null)
		{
			return;
		}
		Go.transform.localScale = Vector3.one;
		Go.transform.localPosition = Vector3.zero;
		Go.transform.localRotation = Quaternion.identity;
		this.Rotation[(Pos >= 1) ? 1 : 0] = uTweenRotation.Begin(Go, Vector3.zero, new Vector3(0f, 0f, (float)(Pos * 25)), 0.2f, 0.5f);
		this.Rotation[(Pos >= 1) ? 1 : 0].loopStyle = LoopStyle.Loop;
		this.Position[(Pos >= 1) ? 1 : 0] = uTweenPosition.Begin(Go, Vector3.zero, new Vector3((float)(Pos * -60), 0f, 0f), 0.5f, 0f);
	}

	// Token: 0x06000E1C RID: 3612 RVA: 0x0016A1C4 File Offset: 0x001683C4
	public void onFinish()
	{
	}

	// Token: 0x06000E1D RID: 3613 RVA: 0x0016A1C8 File Offset: 0x001683C8
	private static void SearchChange(string input)
	{
	}

	// Token: 0x06000E1E RID: 3614 RVA: 0x0016A1CC File Offset: 0x001683CC
	public bool RequestBattleOrder(bool Replay = false)
	{
		if (Replay)
		{
			ActivityManager.Instance.AllianceWarMgr.ReplayGame = AllianceBattle.BattleRoyaleView.GameRound;
			base.transform.GetChild(13).GetChild(0).gameObject.SetActive(false);
		}
		else
		{
			AllianceBattle.BattleRoyale.SetData(ActivityManager.Instance.AllianceWarMgr.RegisterData, ActivityManager.Instance.AllianceWarMgr.WaitData);
		}
		UIAllianceWarBattle.BattleRoyale = ((!Replay) ? AllianceBattle.BattleRoyale : AllianceBattle.BattleRoyaleView);
		ActivityManager.Instance.AllianceWarMgr.bReplaying = (this.BattleReplay = (UIAllianceWarBattle.BattleRoyale.OnLive == 0 && (Replay || ActivityManager.Instance.AW_bcalculateEnd)));
		ActivityManager.Instance.AllianceWarMgr.MyAllySide = (this.BattleSide = UIAllianceWarBattle.BattleRoyale.BattleSide);
		ActivityManager.Instance.AllianceWarMgr.MyPosition = (this.BattlePosition = UIAllianceWarBattle.BattleRoyale.BattlePosition);
		return true;
	}

	// Token: 0x06000E1F RID: 3615 RVA: 0x0016A2E0 File Offset: 0x001684E0
	public static void RecvBattleStation(MessagePacket MP)
	{
	}

	// Token: 0x06000E20 RID: 3616 RVA: 0x0016A2E4 File Offset: 0x001684E4
	public static void RecvBattleStationView(MessagePacket MP)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			door.OpenMenu(EGUIWindow.UI_AllianceWarBattle, 0, 1, false);
		}
	}

	// Token: 0x06000E21 RID: 3617 RVA: 0x0016A31C File Offset: 0x0016851C
	public void OnButtonUp(UIButtonHint sender)
	{
		if (this.m_WorldWarZ)
		{
			sender.ControlFadeOut.SetActive(false);
		}
		if (GUIManager.Instance.m_Arena_Hint != null)
		{
			GUIManager.Instance.m_Arena_Hint.Hide();
		}
	}

	// Token: 0x06000E22 RID: 3618 RVA: 0x0016A364 File Offset: 0x00168564
	public void OnButtonDown(UIButtonHint sender)
	{
		ActivityManager.Instance.AllianceWarMgr.m_AllianceWarHintData.Name.ClearString();
		ActivityManager.Instance.AllianceWarMgr.m_AllianceWarHintData.AllianceTagTag = string.Empty;
		if (sender.Parm1 > 0 && UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
		{
			ActivityManager.Instance.AllianceWarMgr.m_AllianceWarHintData.AllianceTagTag = UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString();
		}
		else if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
		{
			ActivityManager.Instance.AllianceWarMgr.m_AllianceWarHintData.AllianceTagTag = UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString();
		}
		if (sender.Parm1 > 0 && UIAllianceWarBattle.BattleRoyale.Decepticon != null && sender.Parm2 < UIAllianceWarBattle.BattleRoyale.Decepticons)
		{
			ActivityManager.Instance.AllianceWarMgr.m_AllianceWarHintData.Name.Append(UIAllianceWarBattle.BattleRoyale.Decepticon[(int)sender.Parm2].Name);
		}
		else
		{
			if (sender.Parm1 > 0 || UIAllianceWarBattle.BattleRoyale.Autobot == null || sender.Parm2 >= UIAllianceWarBattle.BattleRoyale.Autobots)
			{
				return;
			}
			ActivityManager.Instance.AllianceWarMgr.m_AllianceWarHintData.Name.Append(UIAllianceWarBattle.BattleRoyale.Autobot[(int)sender.Parm2].Name);
		}
		this.HintButt = sender.transform;
		ActivityManager.Instance.AllianceWarMgr.Send_MSG_REQUEST_ALLIANCEWAR_MATCH_PLAYERDATA(UIAllianceWarBattle.BattleRoyale.MatchID - 1, (byte)sender.Parm1, (sender.Parm1 <= 0) ? (UIAllianceWarBattle.BattleRoyale.Autobots - sender.Parm2) : (UIAllianceWarBattle.BattleRoyale.Decepticons - sender.Parm2));
	}

	// Token: 0x06000E23 RID: 3619 RVA: 0x0016A54C File Offset: 0x0016874C
	public static void ResetMatchID()
	{
		UIAllianceWarBattle.MatchID = 0;
		UIAllianceWarBattle.ReplayTime = 0.0;
	}

	// Token: 0x06000E24 RID: 3620 RVA: 0x0016A564 File Offset: 0x00168764
	public override void OnClose()
	{
		if (this.BattleReplay)
		{
			UIAllianceWarBattle.MatchID = UIAllianceWarBattle.BattleRoyale.MatchID;
			UIAllianceWarBattle.ReplayTime = (double)Time.time - this.BattleTime;
		}
		else
		{
			UIAllianceWarBattle.ReplayTime = (double)(UIAllianceWarBattle.MatchID = 0);
		}
		AudioManager.Instance.StopMP3AndPlayBGM();
		if (this.LeftRightInit)
		{
			LeftRightFly.Release();
		}
		UnityEngine.Object.Destroy(this.Duke);
		for (int i = 0; i < 10; i++)
		{
			if (this.m_Str[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.m_Str[i]);
			}
		}
		for (int j = 0; j < 20; j++)
		{
			if (this.AllianceStr[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.AllianceStr[j]);
			}
		}
		if (this.ParticleEffect_Hit != null)
		{
			if (this.ParticleEffect_Hit.activeSelf && ParticleManager.Instance.AllEffectObject != null)
			{
				this.ParticleEffect_Hit.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
			}
			this.ParticleEffect_Hit = null;
		}
		if (this.ParticleEffect_Burst != null)
		{
			if (this.ParticleEffect_Burst.activeSelf && ParticleManager.Instance.AllEffectObject != null)
			{
				this.ParticleEffect_Burst.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
			}
			this.ParticleEffect_Burst = null;
		}
		if (this.ParticleEffect_InRight != null)
		{
			if (this.ParticleEffect_InRight.activeSelf && ParticleManager.Instance.AllEffectObject != null)
			{
				this.ParticleEffect_InRight.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
			}
			this.ParticleEffect_InRight = null;
		}
		if (this.ParticleEffect_InLeft != null)
		{
			if (this.ParticleEffect_InLeft.activeSelf && ParticleManager.Instance.AllEffectObject != null)
			{
				this.ParticleEffect_InLeft.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
			}
			this.ParticleEffect_InLeft = null;
		}
		StringManager.Instance.DeSpawnString(this.DeadCountsStr[0]);
		StringManager.Instance.DeSpawnString(this.DeadCountsStr[1]);
		Time.timeScale = 1f;
		this.Destroy();
	}

	// Token: 0x06000E25 RID: 3621 RVA: 0x0016A7E4 File Offset: 0x001689E4
	public override void UpdateUI(int arg1, int arg2)
	{
		if (!ActivityManager.Instance.AW_bcalculateEnd || this.bReturn)
		{
			return;
		}
		if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None || this.DM.RoleAlliance.Id == 0u)
		{
			this.bExit = true;
			return;
		}
		if (arg1 == 1)
		{
			this.Refresh(0);
		}
		if (arg1 == 6)
		{
			if (this.LeftRightInit)
			{
				if (UIAllianceWarBattle.BattleRoyale.BattleMatch != null && UIAllianceWarBattle.BattleRoyale.BattleMatch.Length > 0)
				{
					if (UIAllianceWarBattle.BattleRoyale.BattleSide == 1 && UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
					{
						LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString(), 0, this.BattleSide == 2, UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].WinnerSide == 1, 0f, true);
					}
					else if (UIAllianceWarBattle.BattleRoyale.BattleSide == 2 && UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
					{
						LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString(), 0, this.BattleSide == 2, UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].WinnerSide == 2, 0f, true);
					}
					else if (UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].WinnerSide == 1 && UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
					{
						LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString(), 0, false, true, 0f, true);
					}
					else if (UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].WinnerSide == 2 && UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
					{
						LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString(), 0, true, true, 0f, true);
					}
				}
				else if (UIAllianceWarBattle.BattleRoyale.BattleSide == 1)
				{
					if (UIAllianceWarBattle.BattleRoyale.Autobots > 0 && UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
					{
						LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString(), 0, this.BattleSide == 2, true, 0f, true);
					}
					else if (UIAllianceWarBattle.BattleRoyale.Decepticons > 0 && UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
					{
						LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString(), 0, this.BattleSide == 2, false, 0f, true);
					}
				}
				else if (UIAllianceWarBattle.BattleRoyale.BattleSide == 2)
				{
					if (UIAllianceWarBattle.BattleRoyale.Autobots > 0 && UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
					{
						LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString(), 0, this.BattleSide == 2, false, 0f, true);
					}
					else if (UIAllianceWarBattle.BattleRoyale.Decepticons > 0 && UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
					{
						LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString(), 0, this.BattleSide == 2, true, 0f, true);
					}
				}
				else if (UIAllianceWarBattle.BattleRoyale.Autobots > 0 && UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
				{
					LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString(), 0, false, true, 0f, true);
				}
				else if (UIAllianceWarBattle.BattleRoyale.Decepticons > 0 && UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
				{
					LeftRightFly.Instance.SetMove(UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString(), 0, true, true, 0f, true);
				}
			}
			this.bEnd = true;
			base.transform.GetChild(13).GetChild(0).gameObject.SetActive(false);
			base.transform.GetChild(13).GetChild(1).GetChild(0).gameObject.SetActive(false);
			base.transform.GetChild(13).GetChild(1).GetChild(3).gameObject.SetActive(false);
			base.transform.GetChild(13).GetChild(1).GetChild(4).gameObject.SetActive(false);
			base.transform.GetChild(7).GetChild(5).gameObject.SetActive(false);
			base.transform.GetChild(8).GetChild(5).gameObject.SetActive(false);
			base.transform.GetChild(8).GetChild(6).gameObject.SetActive(false);
			base.transform.GetChild(7).GetChild(6).gameObject.SetActive(false);
			base.transform.GetChild(9).GetChild(1).gameObject.SetActive(true);
			base.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
			Time.timeScale = 1f;
			if (!this.BattleReplay && this.AllianceStr[10] != null)
			{
				if (UIAllianceWarBattle.BattleRoyale.BattleSide > 0)
				{
					this.AllianceStr[10].ClearString();
					bool flag;
					if (UIAllianceWarBattle.BattleRoyale.BattleMatch != null && UIAllianceWarBattle.BattleRoyale.BattleMatch.Length > 0)
					{
						flag = (UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].WinnerSide == UIAllianceWarBattle.BattleRoyale.BattleSide);
					}
					else
					{
						flag = (UIAllianceWarBattle.BattleRoyale.Autobots > 0 && UIAllianceWarBattle.BattleRoyale.BattleSide == 1);
					}
					if (this.m_player[2, 12] && ActivityManager.Instance.AW_Round > 0)
					{
						base.transform.GetChild(10).gameObject.SetActive(true);
						if (flag)
						{
							switch (ActivityManager.Instance.AW_Round)
							{
							case 1:
								this.AllianceStr[10].StringToFormat(this.DM.mStringTable.GetStringByID(14637u));
								break;
							case 2:
								this.AllianceStr[10].StringToFormat(this.DM.mStringTable.GetStringByID(14638u));
								break;
							case 3:
								this.AllianceStr[10].StringToFormat(this.DM.mStringTable.GetStringByID(14607u));
								break;
							default:
								this.AllianceStr[10].Append(this.DM.mStringTable.GetStringByID(14624u));
								break;
							}
							if (ActivityManager.Instance.AW_Round < 4)
							{
								this.AllianceStr[10].AppendFormat(this.DM.mStringTable.GetStringByID(14623u));
							}
							this.m_player[2, 12].text = this.AllianceStr[10].ToString();
							this.m_player[2, 12].SetAllDirty();
							this.m_player[2, 12].cachedTextGenerator.Invalidate();
						}
						else if (ActivityManager.Instance.AW_Round < 4)
						{
							this.m_player[2, 12].text = this.DM.mStringTable.GetStringByID(14626u);
						}
						else
						{
							this.m_player[2, 12].text = this.DM.mStringTable.GetStringByID(14634u);
						}
					}
				}
				else
				{
					this.AllianceStr[10].ClearString();
					if (UIAllianceWarBattle.BattleRoyale.BattleMatch != null && UIAllianceWarBattle.BattleRoyale.BattleMatch.Length > 0)
					{
						if (UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].WinnerSide == 1)
						{
							if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
							{
								this.AllianceStr[10].StringToFormat(UIAllianceWarBattle.BattleRoyale.AutobotTag);
							}
						}
						else if (UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
						{
							this.AllianceStr[10].StringToFormat(UIAllianceWarBattle.BattleRoyale.DecepticonTag);
						}
					}
					else if (UIAllianceWarBattle.BattleRoyale.Autobots > 0)
					{
						if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
						{
							this.AllianceStr[10].StringToFormat(UIAllianceWarBattle.BattleRoyale.AutobotTag);
						}
					}
					else if (UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
					{
						this.AllianceStr[10].StringToFormat(UIAllianceWarBattle.BattleRoyale.DecepticonTag);
					}
					if (this.m_player[2, 12] && ActivityManager.Instance.AW_Round > 0)
					{
						base.transform.GetChild(10).gameObject.SetActive(true);
						switch (ActivityManager.Instance.AW_Round)
						{
						case 1:
							this.AllianceStr[10].StringToFormat(this.DM.mStringTable.GetStringByID(14637u));
							break;
						case 2:
							this.AllianceStr[10].StringToFormat(this.DM.mStringTable.GetStringByID(14638u));
							break;
						case 3:
							this.AllianceStr[10].StringToFormat(this.DM.mStringTable.GetStringByID(14607u));
							break;
						default:
							this.AllianceStr[10].AppendFormat(this.DM.mStringTable.GetStringByID(14629u));
							break;
						}
						if (ActivityManager.Instance.AW_Round < 4)
						{
							this.AllianceStr[10].AppendFormat(this.DM.mStringTable.GetStringByID(14628u));
						}
						this.m_player[2, 12].text = this.AllianceStr[10].ToString();
						this.m_player[2, 12].SetAllDirty();
						this.m_player[2, 12].cachedTextGenerator.Invalidate();
					}
				}
			}
		}
		else if (arg1 == 7)
		{
			if (UIAllianceWarBattle.BattleRoyale.BattleMatch != null && UIAllianceWarBattle.BattleRoyale.BattleMatch.Length > 0)
			{
				UIAllianceWarBattle.BattleRoyale.BattleWinner = ((UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)((this.BattleRound >= UIAllianceWarBattle.BattleRoyale.BattleMatchs) ? (UIAllianceWarBattle.BattleRoyale.BattleMatchs - 1) : this.BattleRound)].WinnerSide != 1) ? 2 : 1);
				if (this.BattleRound > 0 && (int)this.BattleRound <= UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
				{
					this.LastWinner = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)(this.BattleRound - 1)].WinnerSide;
				}
				base.transform.GetChild(7).GetChild(0).GetChild(0).gameObject.SetActive(this.bEnd);
				base.transform.GetChild(8).GetChild(0).GetChild(0).gameObject.SetActive(this.bEnd);
				base.transform.GetChild(7).GetChild(1).gameObject.SetActive(this.bEnd);
				base.transform.GetChild(8).GetChild(1).gameObject.SetActive(this.bEnd);
				base.transform.GetChild(7).GetChild(2).gameObject.SetActive(!this.bEnd);
				base.transform.GetChild(8).GetChild(2).gameObject.SetActive(!this.bEnd);
				base.transform.GetChild(7).GetChild(3).gameObject.SetActive(!this.bEnd);
				base.transform.GetChild(8).GetChild(3).gameObject.SetActive(!this.bEnd);
				if (this.bEnd)
				{
					this.AllianceStr[6].ClearString();
					this.AllianceStr[6].uLongToFormat((ulong)UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].LeftSurvive, 1, true);
					this.AllianceStr[6].AppendFormat("{0}");
					if (this.m_player[0, 10])
					{
						this.m_player[0, 10].text = this.AllianceStr[6].ToString();
						this.m_player[0, 10].SetAllDirty();
						this.m_player[0, 10].cachedTextGenerator.Invalidate();
					}
					this.AllianceStr[9].ClearString();
					this.AllianceStr[9].uLongToFormat((ulong)UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].RightSurvive, 1, true);
					this.AllianceStr[9].AppendFormat("{0}");
					if (this.m_player[1, 10])
					{
						this.m_player[1, 10].text = this.AllianceStr[9].ToString();
						this.m_player[1, 10].SetAllDirty();
						this.m_player[1, 10].cachedTextGenerator.Invalidate();
					}
				}
			}
			else
			{
				UIAllianceWarBattle.BattleRoyale.BattleWinner = ((UIAllianceWarBattle.BattleRoyale.Autobots <= 0) ? 2 : 1);
			}
			if (this.bEnd)
			{
				if (UIAllianceWarBattle.BattleRoyale.BattleWinner > 0 && this.EmblemScale[(int)(UIAllianceWarBattle.BattleRoyale.BattleWinner - 1)])
				{
					this.EmblemScale[(int)(UIAllianceWarBattle.BattleRoyale.BattleWinner - 1)].enabled = true;
				}
				if (UIAllianceWarBattle.BattleRoyale.BattleMatch != null && UIAllianceWarBattle.BattleRoyale.BattleMatch.Length > 0)
				{
					if (UIAllianceWarBattle.BattleRoyale.BattleMatch[UIAllianceWarBattle.BattleRoyale.BattleMatch.Length - 1].WinnerSide == 1)
					{
						if (UIAllianceWarBattle.BattleRoyale.BattleSide == 2)
						{
							this.m_player[1, 12].enabled = true;
							this.m_player[1, 12].text = this.DM.mStringTable.GetStringByID(14622u);
							base.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
						}
						else
						{
							this.m_player[0, 11].enabled = true;
							base.transform.GetChild(6).GetChild(0).GetChild(13).gameObject.SetActive(true);
							base.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
						}
					}
					else if (UIAllianceWarBattle.BattleRoyale.BattleSide == 1)
					{
						this.m_player[0, 12].enabled = true;
						this.m_player[0, 12].text = this.DM.mStringTable.GetStringByID(14622u);
						base.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
					}
					else
					{
						this.m_player[1, 11].enabled = true;
						base.transform.GetChild(6).GetChild(1).GetChild(13).gameObject.SetActive(true);
						base.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
					}
				}
				else if (UIAllianceWarBattle.BattleRoyale.Autobots > 0)
				{
					if (UIAllianceWarBattle.BattleRoyale.BattleSide == 2)
					{
						this.m_player[1, 12].enabled = true;
						this.m_player[1, 12].text = this.DM.mStringTable.GetStringByID(14622u);
						base.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
					}
					else
					{
						this.m_player[0, 11].enabled = true;
						base.transform.GetChild(6).GetChild(0).GetChild(13).gameObject.SetActive(true);
						base.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
					}
				}
				else if (UIAllianceWarBattle.BattleRoyale.BattleSide == 1)
				{
					this.m_player[0, 12].enabled = true;
					this.m_player[0, 12].text = this.DM.mStringTable.GetStringByID(14622u);
					base.transform.GetChild(7).GetChild(4).gameObject.SetActive(true);
				}
				else
				{
					this.m_player[1, 11].enabled = true;
					base.transform.GetChild(6).GetChild(1).GetChild(13).gameObject.SetActive(true);
					base.transform.GetChild(8).GetChild(4).gameObject.SetActive(true);
				}
			}
		}
		if (arg1 == 10)
		{
			GUIManager.Instance.m_Arena_Hint.ShowHint(1, this.HintButt.GetComponent<RectTransform>());
		}
	}

	// Token: 0x06000E26 RID: 3622 RVA: 0x0016BA18 File Offset: 0x00169C18
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x06000E27 RID: 3623 RVA: 0x0016BA1C File Offset: 0x00169C1C
	public void Destroy()
	{
		if (this.go != null)
		{
			this.go.transform.SetParent(this.Hero_Pos.parent, false);
			UnityEngine.Object.Destroy(this.go);
		}
		if (this.Hero_Model != null)
		{
			UnityEngine.Object.Destroy(this.Hero_Model);
		}
		this.Hero_Model = null;
		this.go = null;
	}

	// Token: 0x06000E28 RID: 3624 RVA: 0x0016BA8C File Offset: 0x00169C8C
	protected void Run(double RoundTime)
	{
		if (RoundTime >= (double)ActivityManager.Instance.AW_FightTime)
		{
			return;
		}
		if ((double)ActivityManager.Instance.AW_FightTime - RoundTime < 2.0)
		{
			for (int i = 0; i < 2; i++)
			{
				if (this.Rotation[i])
				{
					this.Rotation[i].Toggle();
					this.Rotation[i] = null;
					this.CheckWinner();
				}
				if (this.Position[i])
				{
					this.Position[i].Toggle();
					this.Position[i] = null;
					this.CheckWinner();
				}
			}
		}
	}

	// Token: 0x06000E29 RID: 3625 RVA: 0x0016BB34 File Offset: 0x00169D34
	private int GetRand()
	{
		return UnityEngine.Random.Range(0, 3);
	}

	// Token: 0x06000E2A RID: 3626 RVA: 0x0016BB40 File Offset: 0x00169D40
	protected void RunHeroState(GameObject LeftHero, GameObject RightHero, bool LeftHeroWin, double NowRoundTime)
	{
		if (this.MovieStage == UIAllianceWarBattle.MoveStage.MS_FINISH)
		{
			return;
		}
		switch (this.MovieStage)
		{
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_START:
		{
			base.transform.GetChild(7).GetChild(2).gameObject.SetActive(true);
			base.transform.GetChild(7).GetChild(6).gameObject.SetActive(true);
			base.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
			base.transform.GetChild(8).GetChild(2).gameObject.SetActive(true);
			base.transform.GetChild(8).GetChild(6).gameObject.SetActive(true);
			base.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
			base.transform.GetChild(6).GetChild(0).GetChild(13).gameObject.SetActive(false);
			base.transform.GetChild(6).GetChild(1).GetChild(13).gameObject.SetActive(false);
			Transform transform = LeftHero.transform;
			Vector3 vector = Vector3.one;
			RightHero.transform.localScale = vector;
			transform.localScale = vector;
			Transform transform2 = LeftHero.transform;
			vector = Vector3.zero;
			RightHero.transform.localPosition = vector;
			transform2.localPosition = vector;
			Transform transform3 = LeftHero.transform;
			Quaternion identity = Quaternion.identity;
			RightHero.transform.localRotation = identity;
			transform3.localRotation = identity;
			Transform child = LeftHero.transform.GetChild(0);
			vector = Vector3.one;
			RightHero.transform.GetChild(0).localScale = vector;
			child.localScale = vector;
			LeftHero.transform.gameObject.SetActive(true);
			RightHero.transform.gameObject.SetActive(true);
			RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
			for (int i = 0; i < 2; i++)
			{
				this.HeroButt[i].HeroHint.HIImage.color = Color.white;
				this.HeroButt[i].HeroHint.CircleImage.color = Color.white;
				base.transform.GetChild(6).GetChild(i + 4).gameObject.GetComponent<Image>().color = Color.white;
			}
			if (NowRoundTime > 0.5)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_MOVE;
				LeftHero.transform.GetChild(0).localScale = Vector3.one;
				RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				float num = 0f;
				if (NowRoundTime > 0.0)
				{
					num = DamageValueManager.easeOutCubic(4f, 1f, (float)(NowRoundTime / 0.5));
				}
				if (this.LastWinner == 1 || this.LastWinner == 0)
				{
					base.transform.GetChild(6).GetChild(5).gameObject.SetActive(true);
					RightHero.transform.GetChild(0).localScale = new Vector3(num * -1f, num, num);
				}
				if (this.LastWinner == 2 || this.LastWinner == 0)
				{
					base.transform.GetChild(6).GetChild(4).gameObject.SetActive(true);
					LeftHero.transform.GetChild(0).localScale = new Vector3(num, num, num);
				}
				if (NowRoundTime > 0.25)
				{
					if ((this.LastWinner == 1 || this.LastWinner == 0) && this.ParticleEffect_InRight == null)
					{
						if (Time.timeScale > 0f)
						{
							AudioManager.Instance.PlayUISFX(UIKind.CutIn);
						}
						this.ParticleEffect_InRight = ParticleManager.Instance.Spawn(430, base.transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
						this.ParticleEffect_InRight.transform.localPosition = new Vector3(113f, -58f, -800f);
						this.ParticleEffect_InRight.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
						GUIManager.Instance.SetLayer(this.ParticleEffect_InRight, 5);
					}
					if ((this.LastWinner == 2 || this.LastWinner == 0) && this.ParticleEffect_InLeft == null)
					{
						if (Time.timeScale > 0f)
						{
							AudioManager.Instance.PlayUISFX(UIKind.CutIn);
						}
						this.ParticleEffect_InLeft = ParticleManager.Instance.Spawn(430, base.transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
						this.ParticleEffect_InLeft.transform.localPosition = new Vector3(-113f, -58f, -800f);
						this.ParticleEffect_InLeft.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
						GUIManager.Instance.SetLayer(this.ParticleEffect_InLeft, 5);
					}
				}
				if (NowRoundTime > 0.0)
				{
					num = DamageValueManager.easeOutCubic(0f, 1f, (float)(NowRoundTime / 0.5));
					if (this.LastWinner == 1 || this.LastWinner == 0)
					{
						Image component = RightHero.transform.GetChild(0).GetComponent<Image>();
						if (component)
						{
							component.color = new Color(1f, 1f, 1f, num);
						}
						component = RightHero.transform.GetChild(1).GetComponent<Image>();
						if (component)
						{
							component.color = new Color(1f, 1f, 1f, num);
						}
					}
					if (this.LastWinner == 2 || this.LastWinner == 0)
					{
						Image component2 = LeftHero.transform.GetChild(0).GetComponent<Image>();
						if (component2)
						{
							component2.color = new Color(1f, 1f, 1f, num);
						}
						component2 = LeftHero.transform.GetChild(1).GetComponent<Image>();
						if (component2)
						{
							component2.color = new Color(1f, 1f, 1f, num);
						}
					}
					base.transform.GetChild(6).GetChild(4).gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, num);
					base.transform.GetChild(6).GetChild(5).gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, num);
				}
			}
			if (this.ParticleEffect_Hit != null && !this.ParticleEffect_Hit.gameObject.activeSelf)
			{
				this.ParticleEffect_Hit = null;
			}
			break;
		}
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_MOVE:
			if (NowRoundTime > 1.2000000476837158)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_PULL;
				base.transform.GetChild(6).GetChild(4).gameObject.SetActive(false);
				base.transform.GetChild(6).GetChild(5).gameObject.SetActive(false);
				Transform transform4 = LeftHero.transform;
				Vector3 vector = Vector3.one;
				RightHero.transform.localScale = vector;
				transform4.localScale = vector;
				Transform transform5 = LeftHero.transform;
				vector = Vector3.zero;
				RightHero.transform.localPosition = vector;
				transform5.localPosition = vector;
				Transform transform6 = LeftHero.transform;
				Quaternion identity = Quaternion.identity;
				RightHero.transform.localRotation = identity;
				transform6.localRotation = identity;
				RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				float num2;
				if (NowRoundTime > 1.25)
				{
					num2 = DamageValueManager.easeOutCubic(1.2f, 1f, (float)((NowRoundTime - 1.25) / 0.25));
				}
				else if (NowRoundTime > 1.0)
				{
					num2 = DamageValueManager.easeOutCubic(1f, 1.2f, (float)((NowRoundTime - 1.0) / 0.25));
				}
				else if (NowRoundTime > 0.75)
				{
					num2 = DamageValueManager.easeOutCubic(1.5f, 1f, (float)((NowRoundTime - 0.75) / 0.25));
				}
				else
				{
					num2 = DamageValueManager.easeOutCubic(1f, 1.5f, (float)((NowRoundTime - 0.5) / 0.25));
				}
				if (this.LastWinner == 1 || this.LastWinner == 0)
				{
					RightHero.transform.localScale = new Vector3(num2, num2, num2);
				}
				if (this.LastWinner == 2 || this.LastWinner == 0)
				{
					LeftHero.transform.localScale = new Vector3(num2, num2, num2);
				}
			}
			break;
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_PULL:
			if (NowRoundTime >= 2.059999942779541)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_ATTACK;
				LeftHero.transform.localPosition = new Vector3(-53f, -15f, 0f);
				RightHero.transform.localPosition = new Vector3(53f, -15f, 0f);
				LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 15f));
				RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -15f));
			}
			else
			{
				Vector2 zero = Vector2.zero;
				Vector2 zero2 = Vector2.zero;
				if (NowRoundTime < 1.5)
				{
					Vector2 vector2 = new Vector2(0f, 0f);
					Vector2 vector3 = new Vector2(45f, 15f);
					float t = (float)(NowRoundTime - 1.2000000476837158) / 0.3f;
					zero.x = Mathf.Lerp(vector2.x, -vector3.x, t);
					zero.y = Mathf.Lerp(vector2.y, -vector3.y, t);
					zero2.x = Mathf.Lerp(vector2.x, vector3.x, t);
					zero2.y = Mathf.Lerp(vector2.y, -vector3.y, t);
					float num3 = Mathf.Lerp(0f, 15f, t);
					LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, num3));
					RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -num3));
					LeftHero.transform.localPosition = new Vector3(zero.x, zero.y, 0f);
					RightHero.transform.localPosition = new Vector3(zero2.x, zero2.y, 0f);
				}
				else
				{
					float t = (float)(NowRoundTime - 1.5) / 0.56f;
					Vector2 vector2 = new Vector2(45f, 15f);
					Vector2 vector3 = new Vector2(53f, 15f);
					zero.x = Mathf.Lerp(-vector2.x, -vector3.x, t);
					zero.y = Mathf.Lerp(-vector2.y, -vector3.y, t);
					zero2.x = Mathf.Lerp(vector2.x, vector3.x, t);
					zero2.y = Mathf.Lerp(-vector2.y, -vector3.y, t);
					float num4 = Mathf.Lerp(15f, 25f, t);
					LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, num4));
					RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -num4));
					LeftHero.transform.localPosition = new Vector3(zero.x, zero.y, 0f);
					RightHero.transform.localPosition = new Vector3(zero2.x, zero2.y, 0f);
				}
			}
			break;
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_ATTACK:
		{
			float num5 = 2.06f;
			float num6 = 2.19f;
			float num7 = 0.07f;
			if (NowRoundTime >= (double)num6)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_SPLIT;
				LeftHero.transform.localPosition = new Vector3(75f, 35f, 0f);
				RightHero.transform.localPosition = new Vector3(-75f, 35f, 0f);
				RightHero.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
				LeftHero.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
				LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -15f));
				RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 15f));
			}
			else
			{
				Vector2 vector4 = new Vector2(53f, 15f);
				Vector2 vector5 = new Vector2(75f, 35f);
				Vector2 zero3 = Vector2.zero;
				Vector2 zero4 = Vector2.zero;
				if (NowRoundTime - (double)num5 < (double)num7)
				{
					float t2 = (float)(NowRoundTime - (double)num5) / num7;
					zero3.x = Mathf.Lerp(-vector4.x, vector5.x, t2);
					zero3.y = Mathf.Lerp(-vector4.y, vector5.y, t2);
					zero4.x = Mathf.Lerp(vector4.x, -vector5.x, t2);
					zero4.y = Mathf.Lerp(-vector4.y, vector5.y, t2);
					float num8 = Mathf.Lerp(-15f, 15f, t2);
					LeftHero.transform.localPosition = new Vector3(zero3.x, zero3.y, 0f);
					RightHero.transform.localPosition = new Vector3(zero4.x, zero4.y, 0f);
					LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -num8));
					RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, num8));
					if (this.ParticleEffect_Hit == null)
					{
						if (Time.timeScale > 0f)
						{
							AudioManager.Instance.PlayUISFX(UIKind.Score_Hit);
						}
						AudioManager.Instance.PlaySFX(this.LeftHurtSfx, 0f, PitchKind.Hit, null, null);
						AudioManager.Instance.PlaySFX(this.RightHurtSfx, 0f, PitchKind.Hit, null, null);
						this.ParticleEffect_Hit = ParticleManager.Instance.Spawn(431, base.transform.GetChild(9).transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
						this.ParticleEffect_Hit.transform.localPosition = new Vector3(0f, 80f, -800f);
						this.ParticleEffect_Hit.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
						GUIManager.Instance.SetLayer(this.ParticleEffect_Hit, 5);
					}
				}
				else
				{
					float t2 = (float)(NowRoundTime - (double)num5) / (num6 - num5 - num7);
					float num9 = Mathf.Lerp(1f, 1.5f, t2);
					RightHero.transform.localScale = new Vector3(num9, num9, num9);
					LeftHero.transform.localScale = new Vector3(num9, num9, num9);
				}
			}
			break;
		}
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_SPLIT:
		{
			float num10 = 2.19f;
			float num11 = 2.32f;
			if (NowRoundTime > (double)num11)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_DAMAGE;
				LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 15f));
				RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -15f));
				LeftHero.transform.localScale = Vector3.one;
				RightHero.transform.localScale = Vector3.one;
				LeftHero.transform.localPosition = new Vector3(-51f, 27f, 0f);
				RightHero.transform.localPosition = new Vector3(51f, 27f, 0f);
				LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 15f));
				RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -15f));
				if (Time.timeScale > 0f)
				{
					AudioManager.Instance.PlaySFX(40059, 0f, PitchKind.Hit, null, null);
				}
			}
			else
			{
				float num12 = (float)(NowRoundTime - (double)num10) / (num11 - num10);
				float num13 = 0.5f;
				if (num12 < num13)
				{
					float num14 = num12 / num13;
					LeftHero.transform.localPosition = new Vector3(75f - 126f * num12, 35f - 8f * num14, 0f);
					RightHero.transform.localPosition = new Vector3(-75f + 126f * num12, 35f - 8f * num14, 0f);
				}
				else
				{
					LeftHero.transform.localPosition = new Vector3(-51f, 27f, 0f);
					RightHero.transform.localPosition = new Vector3(51f, 27f, 0f);
					float num14 = (num12 - num13) / num13;
					LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -15f + 30f * num14));
					RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 15f - 30f * num14));
					float num15 = 1.4f - 0.4f * num14;
					LeftHero.transform.localScale = new Vector3(num15, num15, num15);
					RightHero.transform.localScale = new Vector3(num15, num15, num15);
				}
			}
			break;
		}
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_DAMAGE:
			if (NowRoundTime > 3.8900001049041748)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_BURST;
				this.burstRotationSpeed = (float)UnityEngine.Random.Range(2, 5);
				this.burstRotationSpeed *= ((UnityEngine.Random.Range(0, 2) != 0) ? 1f : -1f);
				this.burstScaleSpeed = (float)UnityEngine.Random.Range(2, 5);
				this.burstScaleSpeed *= ((UnityEngine.Random.Range(0, 2) != 0) ? 1f : -1f);
				if ((int)this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
				{
					uint rightSurvive = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightSurvive;
					uint leftSurvive = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftSurvive;
					this.AllianceStr[6].ClearString();
					this.AllianceStr[6].uLongToFormat((ulong)leftSurvive, 1, true);
					this.AllianceStr[6].AppendFormat("{0}");
					if (this.m_player[0, 10])
					{
						this.m_player[0, 10].text = this.AllianceStr[6].ToString();
						this.m_player[0, 10].SetAllDirty();
						this.m_player[0, 10].cachedTextGenerator.Invalidate();
					}
					this.AllianceStr[9].ClearString();
					this.AllianceStr[9].uLongToFormat((ulong)rightSurvive, 1, true);
					this.AllianceStr[9].AppendFormat("{0}");
					if (this.m_player[1, 10])
					{
						this.m_player[1, 10].text = this.AllianceStr[9].ToString();
						this.m_player[1, 10].SetAllDirty();
						this.m_player[1, 10].cachedTextGenerator.Invalidate();
					}
				}
				if (this.ParticleEffect_Burst != null && !this.ParticleEffect_Burst.gameObject.activeSelf)
				{
					this.ParticleEffect_Burst = null;
				}
				if (this.GM.IsArabic)
				{
					Transform transform7 = base.transform.GetChild(7).GetChild(2).GetChild(0).transform;
					Vector3 vector = new Vector3(-1f, 1f, 1f);
					base.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector;
					transform7.localScale = vector;
				}
				else
				{
					Transform transform8 = base.transform.GetChild(7).GetChild(2).GetChild(0).transform;
					Vector3 vector = Vector3.one;
					base.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector;
					transform8.localScale = vector;
				}
				if ((int)this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
				{
					if (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftDead > 0u)
					{
						this.DeadCountsStr[0].ClearString();
						this.DeadCountsStr[0].IntToFormat((long)(-(long)((ulong)UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftDead)), 1, true);
						this.DeadCountsStr[0].AppendFormat("{0}");
						this.DeadCounts[0].text = this.DeadCountsStr[0].ToString();
						if (this.GM.IsArabic)
						{
							this.DeadCounts[0].rectTransform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
						}
						else
						{
							this.DeadCounts[0].rectTransform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
						}
					}
					if (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightDead > 0u)
					{
						this.DeadCountsStr[1].ClearString();
						this.DeadCountsStr[1].IntToFormat((long)(-(long)((ulong)UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightDead)), 1, true);
						this.DeadCountsStr[1].AppendFormat("{0}");
						this.DeadCounts[1].text = this.DeadCountsStr[1].ToString();
						if (this.GM.IsArabic)
						{
							this.DeadCounts[1].rectTransform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
						}
						else
						{
							this.DeadCounts[1].rectTransform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
						}
					}
				}
				if (LeftHeroWin)
				{
					AudioManager.Instance.PlaySFX(this.RightDyingSfx, 0f, PitchKind.Hit, null, null);
				}
				else
				{
					AudioManager.Instance.PlaySFX(this.LeftDyingSfx, 0f, PitchKind.Hit, null, null);
				}
			}
			else
			{
				float num16 = 1f;
				if (NowRoundTime > 3.5899999141693115)
				{
					num16 = 6.186663f - 1.33333242f * (float)NowRoundTime;
					if (num16 < 1f)
					{
						num16 = 1f;
					}
				}
				else if (NowRoundTime > 2.4900000095367432)
				{
					num16 = 1.4f;
				}
				else if (NowRoundTime > 2.19)
				{
					num16 = 1.33333349f * (float)NowRoundTime - 1.92000031f;
					if (num16 > 1.4f)
					{
						num16 = 1.4f;
					}
				}
				if (this.GM.IsArabic)
				{
					Transform transform9 = base.transform.GetChild(7).GetChild(2).GetChild(0).transform;
					Vector3 vector = num16 * new Vector3(-1f, 1f, 1f);
					base.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector;
					transform9.localScale = vector;
				}
				else
				{
					Transform transform10 = base.transform.GetChild(7).GetChild(2).GetChild(0).transform;
					Vector3 vector = num16 * Vector3.one;
					base.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector;
					transform10.localScale = vector;
				}
				if ((int)this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
				{
					float num17 = 3.89f - (float)NowRoundTime;
					if (num17 < 0f)
					{
						num17 = 0f;
					}
					num17 /= 1.57f;
					if (num17 > 1f)
					{
						num17 = 1f;
					}
					uint num18 = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightSurvive + (uint)(num17 * UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightDead);
					uint num19 = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftSurvive + (uint)(num17 * UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftDead);
					this.AllianceStr[6].ClearString();
					this.AllianceStr[6].uLongToFormat((ulong)num19, 1, true);
					this.AllianceStr[6].AppendFormat("{0}");
					if (this.m_player[0, 10])
					{
						this.m_player[0, 10].text = this.AllianceStr[6].ToString();
						this.m_player[0, 10].SetAllDirty();
						this.m_player[0, 10].cachedTextGenerator.Invalidate();
					}
					this.AllianceStr[9].ClearString();
					this.AllianceStr[9].uLongToFormat((ulong)num18, 1, true);
					this.AllianceStr[9].AppendFormat("{0}");
					if (this.m_player[1, 10])
					{
						this.m_player[1, 10].text = this.AllianceStr[9].ToString();
						this.m_player[1, 10].SetAllDirty();
						this.m_player[1, 10].cachedTextGenerator.Invalidate();
					}
				}
			}
			break;
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_BURST:
			if (NowRoundTime > 4.96999979019165)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_END;
				this.SetterWinner(LeftHeroWin);
				this.burstScaleSpeed = (this.burstRotationSpeed = 0f);
				GameObject gameObject;
				GameObject gameObject2;
				if (LeftHeroWin)
				{
					gameObject = LeftHero;
					gameObject2 = RightHero;
				}
				else
				{
					gameObject = RightHero;
					gameObject2 = LeftHero;
				}
				if (gameObject != null)
				{
					if (!gameObject.activeSelf)
					{
						gameObject.SetActive(true);
					}
					Transform transform11 = gameObject.transform;
					if (transform11 != null)
					{
						transform11.localPosition = new Vector3((!LeftHeroWin) ? 51f : -51f, 27f, 0f);
						transform11.localRotation = Quaternion.Euler(new Vector3(0f, 0f, (float)((!LeftHeroWin) ? -15 : 15)));
						transform11.localScale = Vector3.one;
						Color color = new Color(1f, 1f, 1f, 1f);
						transform11.GetChild(0).GetComponent<Image>().color = color;
						transform11.GetChild(1).GetComponent<Image>().color = color;
					}
				}
				if (gameObject2 != null && gameObject2.activeSelf)
				{
					gameObject2.SetActive(false);
					Color color2 = new Color(1f, 1f, 1f, 1f);
					gameObject2.transform.GetChild(0).GetComponent<Image>().color = color2;
					gameObject2.transform.GetChild(1).GetComponent<Image>().color = color2;
					base.transform.GetChild((!LeftHeroWin) ? 7 : 8).GetChild(2).gameObject.SetActive(false);
					base.transform.GetChild((!LeftHeroWin) ? 7 : 8).GetChild(6).gameObject.SetActive(false);
				}
				this.DeadCounts[0].text = string.Empty;
				this.DeadCounts[1].text = string.Empty;
			}
			else
			{
				GameObject gameObject3 = (!LeftHeroWin) ? LeftHero : RightHero;
				if (gameObject3 != null)
				{
					Transform transform12 = gameObject3.transform;
					if (transform12 != null)
					{
						transform12.localPosition = new Vector3((!LeftHeroWin) ? -51f : 51f, 27f, 0f);
						if (NowRoundTime > 4.070000171661377)
						{
							if (NowRoundTime > 4.0900001525878906 && this.ParticleEffect_Burst == null)
							{
								if (Time.timeScale > 0f)
								{
									AudioManager.Instance.PlayUISFX(UIKind.Explosion);
								}
								this.ParticleEffect_Burst = ParticleManager.Instance.Spawn(432, transform12, new Vector3(0f, 0f, 0f), 1f, true, true, true);
								this.ParticleEffect_Burst.transform.localPosition = new Vector3(0f, 0f, -800f);
								this.ParticleEffect_Burst.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
								GUIManager.Instance.SetLayer(this.ParticleEffect_Burst, 5);
							}
							float a = 0f;
							Color color3 = new Color(1f, 1f, 1f, a);
							transform12.GetChild(0).GetComponent<Image>().color = color3;
							transform12.GetChild(1).GetComponent<Image>().color = color3;
						}
						else
						{
							float num20 = transform12.localScale.x + this.burstScaleSpeed * 10f * Time.deltaTime * this.FightTimeScale;
							if (num20 > 1.05f)
							{
								num20 = 1.05f;
								this.burstScaleSpeed = -(float)UnityEngine.Random.Range(2, 5);
							}
							else if (num20 < 1f)
							{
								num20 = 1f;
								this.burstScaleSpeed = (float)UnityEngine.Random.Range(2, 5);
							}
							transform12.localScale = num20 * Vector3.one;
							float num21 = transform12.localEulerAngles.z + this.burstRotationSpeed * 300f * Time.deltaTime * this.FightTimeScale;
							if (num21 > 180f)
							{
								num21 -= 360f;
							}
							if (num21 > 0f)
							{
								if (num21 > 21f)
								{
									num21 = 21f;
									this.burstRotationSpeed = -(float)UnityEngine.Random.Range(2, 5);
								}
								else if (num21 < 16f)
								{
									num21 = 16f;
									this.burstRotationSpeed = (float)UnityEngine.Random.Range(2, 5);
								}
							}
							else if (num21 < 0f)
							{
								if (num21 < -21f)
								{
									num21 = -21f;
									this.burstRotationSpeed = (float)UnityEngine.Random.Range(2, 5);
								}
								else if (num21 > -16f)
								{
									num21 = -16f;
									this.burstRotationSpeed = -(float)UnityEngine.Random.Range(2, 5);
								}
							}
							transform12.localRotation = Quaternion.Euler(new Vector3(0f, 0f, num21));
						}
					}
					float num22;
					if (NowRoundTime < 4.070000171661377)
					{
						num22 = EasingEffect.Linear((float)NowRoundTime - 3.89f, 0f, 1.2f, 0.18f);
					}
					else if (NowRoundTime < 4.570000171661377)
					{
						num22 = EasingEffect.InQuadratic((float)NowRoundTime - 4.07f, 1.2f, -0.5f, 0.5f);
					}
					else
					{
						num22 = 0.7f;
					}
					if (this.GM.IsArabic)
					{
						this.DeadCounts[0].rectTransform.localScale = new Vector3(-num22, num22, num22);
					}
					else
					{
						this.DeadCounts[0].rectTransform.localScale = new Vector3(num22, num22, num22);
					}
					this.DeadCounts[1].rectTransform.localScale = this.DeadCounts[0].rectTransform.localScale;
				}
			}
			break;
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_END:
			if (NowRoundTime > 5.9000000953674316)
			{
				Vector3 vector6;
				if (LeftHeroWin)
				{
					base.transform.GetChild(8).GetChild(2).gameObject.SetActive(false);
					base.transform.GetChild(8).GetChild(6).gameObject.SetActive(false);
					Transform transform13 = RightHero.transform;
					vector6 = Vector3.zero;
					RightHero.transform.transform.GetChild(0).localScale = vector6;
					transform13.localScale = vector6;
					RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
				}
				else
				{
					base.transform.GetChild(7).GetChild(2).gameObject.SetActive(false);
					base.transform.GetChild(7).GetChild(6).gameObject.SetActive(false);
					Transform transform14 = LeftHero.transform;
					vector6 = Vector3.zero;
					LeftHero.transform.transform.GetChild(0).localScale = vector6;
					transform14.localScale = vector6;
				}
				Transform transform15 = LeftHero.transform;
				vector6 = Vector3.zero;
				RightHero.transform.localPosition = vector6;
				transform15.localPosition = vector6;
				Transform transform16 = LeftHero.transform;
				Quaternion identity = Quaternion.identity;
				RightHero.transform.localRotation = identity;
				transform16.localRotation = identity;
				if (this.GM.IsArabic)
				{
					Transform transform17 = this.m_player[0, 13].transform;
					vector6 = new Vector3(-1f, 0f, 0f);
					this.m_player[1, 13].transform.localScale = vector6;
					transform17.localScale = vector6;
				}
				else
				{
					Transform transform18 = this.m_player[0, 13].transform;
					vector6 = Vector3.one;
					this.m_player[1, 13].transform.localScale = vector6;
					transform18.localScale = vector6;
				}
				this.SetStage(UIAllianceWarBattle.MoveStage.MS_FIGHTING);
			}
			else
			{
				float num23 = 5.066666f;
				float num24 = 5.2f;
				GameObject gameObject4 = (!LeftHeroWin) ? RightHero : LeftHero;
				if (gameObject4 != null)
				{
					if (!gameObject4.activeSelf)
					{
						gameObject4.SetActive(true);
					}
					Transform transform19 = gameObject4.transform;
					if (transform19 != null)
					{
						float z;
						float y;
						float x;
						if (NowRoundTime > (double)num24)
						{
							x = (y = (z = 0f));
						}
						else if (NowRoundTime > (double)num23)
						{
							float num25 = 74.9998f;
							float num26 = -389.998962f;
							y = num25 * (float)NowRoundTime + num26;
							if (LeftHeroWin)
							{
								num25 = 119.999687f;
								num26 = -623.998352f;
								x = num25 * (float)NowRoundTime + num26;
								num25 = 37.4999f;
								num26 = -194.999481f;
								z = num25 * (float)NowRoundTime + num26;
							}
							else
							{
								num25 = -119.999687f;
								num26 = 623.998352f;
								x = num26 + num25 * (float)NowRoundTime;
								num25 = -37.4999f;
								num26 = 194.999481f;
								z = num26 + num25 * (float)NowRoundTime;
							}
						}
						else
						{
							float num25 = -382.759918f;
							float num26 = 1929.31677f;
							y = num26 + num25 * (float)NowRoundTime;
							if (LeftHeroWin)
							{
								num25 = 362.0702f;
								num26 = -1850.48889f;
								x = num25 * (float)NowRoundTime + num26;
								num25 = -206.897263f;
								num26 = 1043.2793f;
								z = num26 + num25 * (float)NowRoundTime;
							}
							else
							{
								num25 = -362.0702f;
								num26 = 1850.48889f;
								x = num26 + num25 * (float)NowRoundTime;
								num25 = 206.897263f;
								num26 = -1043.2793f;
								z = num25 * (float)NowRoundTime + num26;
							}
						}
						transform19.localPosition = new Vector3(x, y, 0f);
						transform19.localRotation = Quaternion.Euler(new Vector3(0f, 0f, z));
						float num27;
						if (NowRoundTime > 5.086249828338623)
						{
							num27 = 6812.901f - 1290.32214f * (float)NowRoundTime;
						}
						else if (NowRoundTime > 5.2024998664855957)
						{
							num27 = 100f;
						}
						else
						{
							num27 = 1290.32214f * (float)NowRoundTime - 6312.901f;
						}
						if (num27 < 100f)
						{
							num27 = 100f;
						}
						if (num27 > 250f)
						{
							num27 = 250f;
						}
						num27 *= 0.01f;
						if (this.GM.IsArabic)
						{
							Transform transform20 = this.m_player[0, 13].transform;
							Vector3 vector6 = num27 * new Vector3(-1f, 1f, 1f);
							this.m_player[1, 13].transform.localScale = vector6;
							transform20.localScale = vector6;
						}
						else
						{
							Transform transform21 = this.m_player[0, 13].transform;
							Vector3 vector6 = num27 * Vector3.one;
							this.m_player[1, 13].transform.localScale = vector6;
							transform21.localScale = vector6;
						}
					}
				}
			}
			break;
		}
	}

	// Token: 0x06000E2B RID: 3627 RVA: 0x0016E230 File Offset: 0x0016C430
	protected void RunHeroStateA(GameObject LeftHero, GameObject RightHero, bool LeftHeroWin, double NowRoundTime)
	{
		if (this.MovieStage == UIAllianceWarBattle.MoveStage.MS_FINISH)
		{
			return;
		}
		switch (this.MovieStage)
		{
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_START:
		{
			base.transform.GetChild(7).GetChild(6).gameObject.SetActive(true);
			base.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
			base.transform.GetChild(8).GetChild(6).gameObject.SetActive(true);
			base.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
			base.transform.GetChild(6).GetChild(0).GetChild(13).gameObject.SetActive(false);
			base.transform.GetChild(6).GetChild(1).GetChild(13).gameObject.SetActive(false);
			Transform transform = LeftHero.transform;
			Vector3 vector = Vector3.one;
			RightHero.transform.localScale = vector;
			transform.localScale = vector;
			Transform transform2 = LeftHero.transform;
			vector = Vector3.zero;
			RightHero.transform.localPosition = vector;
			transform2.localPosition = vector;
			Transform transform3 = LeftHero.transform;
			Quaternion identity = Quaternion.identity;
			RightHero.transform.localRotation = identity;
			transform3.localRotation = identity;
			Transform child = LeftHero.transform.GetChild(0);
			vector = Vector3.one;
			RightHero.transform.GetChild(0).localScale = vector;
			child.localScale = vector;
			LeftHero.transform.gameObject.SetActive(true);
			RightHero.transform.gameObject.SetActive(true);
			RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
			for (int i = 0; i < 2; i++)
			{
				this.HeroButt[i].HeroHint.HIImage.color = Color.white;
				this.HeroButt[i].HeroHint.CircleImage.color = Color.white;
				base.transform.GetChild(6).GetChild(i + 4).gameObject.GetComponent<Image>().color = Color.white;
			}
			if (NowRoundTime > 0.33000001311302185)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_MOVE;
				LeftHero.transform.GetChild(0).localScale = Vector3.one;
				RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				float num = 0f;
				if (NowRoundTime > 0.0)
				{
					num = DamageValueManager.easeOutCubic(4f, 1f, (float)(NowRoundTime / 0.33000001311302185));
				}
				if (this.LastWinner == 1 || this.LastWinner == 0)
				{
					base.transform.GetChild(6).GetChild(5).gameObject.SetActive(true);
					RightHero.transform.GetChild(0).localScale = new Vector3(num * -1f, num, num);
				}
				if (this.LastWinner == 2 || this.LastWinner == 0)
				{
					base.transform.GetChild(6).GetChild(4).gameObject.SetActive(true);
					LeftHero.transform.GetChild(0).localScale = new Vector3(num, num, num);
				}
				if (NowRoundTime > 0.25)
				{
					if ((this.LastWinner == 1 || this.LastWinner == 0) && this.ParticleEffect_InRight == null)
					{
						if (Time.timeScale > 0f)
						{
							AudioManager.Instance.PlayUISFX(UIKind.CutIn);
						}
						this.ParticleEffect_InRight = ParticleManager.Instance.Spawn(430, base.transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
						this.ParticleEffect_InRight.transform.localPosition = new Vector3(113f, -58f, -800f);
						this.ParticleEffect_InRight.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
						GUIManager.Instance.SetLayer(this.ParticleEffect_InRight, 5);
					}
					if ((this.LastWinner == 2 || this.LastWinner == 0) && this.ParticleEffect_InLeft == null)
					{
						if (Time.timeScale > 0f)
						{
							AudioManager.Instance.PlayUISFX(UIKind.CutIn);
						}
						this.ParticleEffect_InLeft = ParticleManager.Instance.Spawn(430, base.transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
						this.ParticleEffect_InLeft.transform.localPosition = new Vector3(-113f, -58f, -800f);
						this.ParticleEffect_InLeft.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
						GUIManager.Instance.SetLayer(this.ParticleEffect_InLeft, 5);
					}
				}
				if (NowRoundTime > 0.0)
				{
					num = DamageValueManager.easeOutCubic(0f, 1f, (float)(NowRoundTime / 0.33000001311302185));
					if (this.LastWinner == 1 || this.LastWinner == 0)
					{
						Image component = RightHero.transform.GetChild(0).GetComponent<Image>();
						if (component)
						{
							component.color = new Color(1f, 1f, 1f, num);
						}
						component = RightHero.transform.GetChild(1).GetComponent<Image>();
						if (component)
						{
							component.color = new Color(1f, 1f, 1f, num);
						}
					}
					if (this.LastWinner == 2 || this.LastWinner == 0)
					{
						Image component2 = LeftHero.transform.GetChild(0).GetComponent<Image>();
						if (component2)
						{
							component2.color = new Color(1f, 1f, 1f, num);
						}
						component2 = LeftHero.transform.GetChild(1).GetComponent<Image>();
						if (component2)
						{
							component2.color = new Color(1f, 1f, 1f, num);
						}
					}
					base.transform.GetChild(6).GetChild(4).gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, num);
					base.transform.GetChild(6).GetChild(5).gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, num);
				}
			}
			if (this.ParticleEffect_Hit != null && !this.ParticleEffect_Hit.gameObject.activeSelf)
			{
				this.ParticleEffect_Hit = null;
			}
			break;
		}
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_MOVE:
			if (NowRoundTime > 1.5)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_PULL;
				base.transform.GetChild(6).GetChild(4).gameObject.SetActive(false);
				base.transform.GetChild(6).GetChild(5).gameObject.SetActive(false);
				Transform transform4 = LeftHero.transform;
				Vector3 vector = Vector3.one;
				RightHero.transform.localScale = vector;
				transform4.localScale = vector;
				Transform transform5 = LeftHero.transform;
				vector = Vector3.zero;
				RightHero.transform.localPosition = vector;
				transform5.localPosition = vector;
				Transform transform6 = LeftHero.transform;
				Quaternion identity = Quaternion.identity;
				RightHero.transform.localRotation = identity;
				transform6.localRotation = identity;
				RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				float num2;
				if (NowRoundTime > 1.1000000238418579)
				{
					num2 = EasingEffect.Linear((float)((NowRoundTime - 1.1000000238418579) / 0.40000000596046448), 1.1f, -0.1f, 1f);
				}
				else if (NowRoundTime > 0.89999997615814209)
				{
					num2 = EasingEffect.Linear((float)((NowRoundTime - 0.89999997615814209) / 0.20000000298023224), 1f, 0.1f, 1f);
				}
				else if (NowRoundTime > 0.62999999523162842)
				{
					num2 = EasingEffect.Linear((float)((NowRoundTime - 0.62999999523162842) / 0.27000001072883606), 1.2f, -0.2f, 1f);
				}
				else
				{
					num2 = EasingEffect.Linear((float)((NowRoundTime - 0.33000001311302185) / 0.30000001192092896), 1f, 0.2f, 1f);
				}
				if (this.LastWinner == 1 || this.LastWinner == 0)
				{
					RightHero.transform.localScale = new Vector3(num2, num2, num2);
				}
				if (this.LastWinner == 2 || this.LastWinner == 0)
				{
					LeftHero.transform.localScale = new Vector3(num2, num2, num2);
				}
			}
			break;
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_PULL:
			if (NowRoundTime >= 2.059999942779541)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_ATTACK;
				LeftHero.transform.localPosition = new Vector3(-23f, 0f, 0f);
				RightHero.transform.localPosition = new Vector3(23f, 0f, 0f);
				LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 15f));
				RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -15f));
			}
			else
			{
				Vector2 zero = Vector2.zero;
				Vector2 zero2 = Vector2.zero;
				if (NowRoundTime < 1.7899999618530273)
				{
					Vector2 vector2 = new Vector2(0f, 0f);
					Vector2 vector3 = new Vector2(27f, 0f);
					float t = (float)(NowRoundTime - 1.5) / 0.29f;
					zero.x = Mathf.Lerp(vector2.x, -vector3.x, t);
					zero2.x = Mathf.Lerp(vector2.x, vector3.x, t);
					float num3 = Mathf.Lerp(0f, 10f, t);
					LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, num3));
					RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -num3));
					LeftHero.transform.localPosition = new Vector3(zero.x, zero.y, 0f);
					RightHero.transform.localPosition = new Vector3(zero2.x, zero2.y, 0f);
				}
				else
				{
					float t = (float)(NowRoundTime - 1.7899999618530273) / 0.27f;
					Vector2 vector2 = new Vector2(27f, 0f);
					Vector2 vector3 = new Vector2(23f, 0f);
					zero.x = Mathf.Lerp(-vector2.x, -vector3.x, t);
					zero2.x = Mathf.Lerp(vector2.x, vector3.x, t);
					float num4 = Mathf.Lerp(10f, 30f, t);
					LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, num4));
					RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -num4));
					LeftHero.transform.localPosition = new Vector3(zero.x, zero.y, 0f);
					RightHero.transform.localPosition = new Vector3(zero2.x, zero2.y, 0f);
				}
			}
			break;
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_ATTACK:
		{
			float num5 = 2.06f;
			float num6 = 2.3f;
			float num7 = 0.07f;
			if (NowRoundTime >= (double)num6)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_SPLIT;
				LeftHero.transform.localPosition = new Vector3(75f, 97f, 0f);
				RightHero.transform.localPosition = new Vector3(-75f, 97f, 0f);
				RightHero.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
				LeftHero.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
				LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -10f));
				RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 10f));
			}
			else
			{
				Vector2 vector4 = new Vector2(23f, 0f);
				Vector2 vector5 = new Vector2(75f, 0f);
				Vector2 zero3 = Vector2.zero;
				Vector2 zero4 = Vector2.zero;
				if (NowRoundTime - (double)num5 < (double)num7)
				{
					float t2 = (float)(NowRoundTime - (double)num5) / num7;
					zero3.x = Mathf.Lerp(-vector4.x, vector5.x, t2);
					zero4.x = Mathf.Lerp(vector4.x, -vector5.x, t2);
					float num8 = Mathf.Lerp(30f, -10f, t2);
					LeftHero.transform.localPosition = new Vector3(zero3.x, zero3.y, 0f);
					RightHero.transform.localPosition = new Vector3(zero4.x, zero4.y, 0f);
					LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -num8));
					RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, num8));
					float num9 = Mathf.Lerp(1f, 1.3f, t2);
					RightHero.transform.localScale = new Vector3(num9, num9, num9);
					LeftHero.transform.localScale = new Vector3(num9, num9, num9);
				}
				else
				{
					float t2 = (float)(NowRoundTime - (double)num5) / (num6 - num5 - num7);
					vector4.Set(75f, 0f);
					vector5.Set(75f, 97f);
					zero3.y = Mathf.Lerp(vector4.y, vector5.y, t2);
					zero4.y = Mathf.Lerp(vector4.y, vector5.y, t2);
					float num10 = Mathf.Lerp(-10f, 10f, t2);
					LeftHero.transform.localPosition = new Vector3(vector4.x, zero3.y, 0f);
					RightHero.transform.localPosition = new Vector3(-vector4.x, zero4.y, 0f);
					LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -num10));
					RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, num10));
					float num11 = Mathf.Lerp(1.3f, 1.5f, t2);
					RightHero.transform.localScale = new Vector3(num11, num11, num11);
					LeftHero.transform.localScale = new Vector3(num11, num11, num11);
					if (this.ParticleEffect_Hit == null)
					{
						if (Time.timeScale > 0f)
						{
							AudioManager.Instance.PlayUISFX(UIKind.Score_Hit);
						}
						AudioManager.Instance.PlaySFX(this.LeftHurtSfx, 0f, PitchKind.Hit, null, null);
						AudioManager.Instance.PlaySFX(this.RightHurtSfx, 0f, PitchKind.Hit, null, null);
						this.ParticleEffect_Hit = ParticleManager.Instance.Spawn(431, base.transform.GetChild(9).transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
						this.ParticleEffect_Hit.transform.localPosition = new Vector3(0f, 80f, -800f);
						this.ParticleEffect_Hit.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
						GUIManager.Instance.SetLayer(this.ParticleEffect_Hit, 5);
					}
				}
			}
			break;
		}
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_SPLIT:
		{
			float num12 = 2.3f;
			float num13 = 3.1f;
			float num14 = 0.3f;
			if (NowRoundTime > (double)num13)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_DAMAGE;
				LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 20f));
				RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -20f));
				LeftHero.transform.localScale = Vector3.one;
				RightHero.transform.localScale = Vector3.one;
				LeftHero.transform.localPosition = new Vector3(-78f, 0f, 0f);
				RightHero.transform.localPosition = new Vector3(78f, 0f, 0f);
				if (Time.timeScale > 0f)
				{
					AudioManager.Instance.PlaySFX(40059, 0f, PitchKind.Hit, null, null);
				}
			}
			else
			{
				float t3 = (float)(NowRoundTime - (double)num12) / (num13 - num12 - num14);
				float num15 = 0f;
				if (NowRoundTime - (double)num12 <= (double)num14)
				{
					t3 = (float)(NowRoundTime - (double)num12 - (double)num15) / num14;
					LeftHero.transform.localPosition = Vector3.Lerp(new Vector3(75f, 97f, 0f), new Vector3(37f, 117f, 0f), t3);
					RightHero.transform.localPosition = Vector3.Lerp(new Vector3(-75f, 97f, 0f), new Vector3(-37f, 117f, 0f), t3);
					LeftHero.transform.localScale = Vector3.Lerp(new Vector3(1.5f, 1.5f, 1.5f), Vector3.one, t3);
					RightHero.transform.localScale = Vector3.Lerp(new Vector3(1.5f, 1.5f, 1.5f), Vector3.one, t3);
					LeftHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, 10f), new Vector3(0f, 0f, 35f), t3));
					RightHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, -10f), new Vector3(0f, 0f, -35f), t3));
				}
				else if (NowRoundTime - (double)num12 <= (double)(num14 += 0.1f))
				{
					num15 = num14 - 0.1f;
					t3 = (float)(NowRoundTime - (double)num12 - (double)num15) / 0.1f;
					LeftHero.transform.localPosition = Vector3.Lerp(new Vector3(37f, 117f, 0f), new Vector3(0f, 0f, 0f), t3);
					RightHero.transform.localPosition = Vector3.Lerp(new Vector3(-37f, 117f, 0f), new Vector3(0f, 0f, 0f), t3);
					LeftHero.transform.localScale = Vector3.one;
					RightHero.transform.localScale = Vector3.one;
					LeftHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, 35f), new Vector3(0f, 0f, 0f), t3));
					RightHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, -35f), new Vector3(0f, 0f, 0f), t3));
				}
				else if (NowRoundTime - (double)num12 <= (double)(num14 += 0.3f))
				{
					num15 = num14 - 0.3f;
					t3 = (float)(NowRoundTime - (double)num12 - (double)num15) / 0.3f;
					LeftHero.transform.localPosition = Vector3.Lerp(new Vector3(0f, 0f, 0f), new Vector3(-45f, 27f, 0f), t3);
					RightHero.transform.localPosition = Vector3.Lerp(new Vector3(0f, 0f, 0f), new Vector3(45f, 27f, 0f), t3);
					LeftHero.transform.localScale = Vector3.one;
					RightHero.transform.localScale = Vector3.one;
					LeftHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 30f), t3));
					RightHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, -30f), t3));
				}
				else if (NowRoundTime - (double)num12 <= (double)(num14 += 0.1f))
				{
					num15 = num14 - 0.1f;
					t3 = (float)(NowRoundTime - (double)num12 - (double)num15) / 0.1f;
					LeftHero.transform.localPosition = Vector3.Lerp(new Vector3(-45f, 27f, 0f), new Vector3(-78f, 0f, 0f), t3);
					RightHero.transform.localPosition = Vector3.Lerp(new Vector3(45f, 27f, 0f), new Vector3(78f, 0f, 0f), t3);
					LeftHero.transform.localScale = Vector3.one;
					RightHero.transform.localScale = Vector3.one;
					LeftHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, 30f), new Vector3(0f, 0f, 20f), t3));
					RightHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, -30f), new Vector3(0f, 0f, -20f), t3));
				}
			}
			break;
		}
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_DAMAGE:
			if (NowRoundTime > 3.7999999523162842)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_BURST;
				this.burstRotationSpeed = (float)UnityEngine.Random.Range(2, 5);
				this.burstRotationSpeed *= ((UnityEngine.Random.Range(0, 2) != 0) ? 1f : -1f);
				this.burstScaleSpeed = (float)UnityEngine.Random.Range(2, 5);
				this.burstScaleSpeed *= ((UnityEngine.Random.Range(0, 2) != 0) ? 1f : -1f);
				if ((int)this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
				{
					uint rightSurvive = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightSurvive;
					uint leftSurvive = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftSurvive;
					this.AllianceStr[6].ClearString();
					this.AllianceStr[6].uLongToFormat((ulong)leftSurvive, 1, true);
					this.AllianceStr[6].AppendFormat("{0}");
					if (this.m_player[0, 10])
					{
						this.m_player[0, 10].text = this.AllianceStr[6].ToString();
						this.m_player[0, 10].SetAllDirty();
						this.m_player[0, 10].cachedTextGenerator.Invalidate();
					}
					this.AllianceStr[9].ClearString();
					this.AllianceStr[9].uLongToFormat((ulong)rightSurvive, 1, true);
					this.AllianceStr[9].AppendFormat("{0}");
					if (this.m_player[1, 10])
					{
						this.m_player[1, 10].text = this.AllianceStr[9].ToString();
						this.m_player[1, 10].SetAllDirty();
						this.m_player[1, 10].cachedTextGenerator.Invalidate();
					}
				}
				if (this.ParticleEffect_Burst != null && !this.ParticleEffect_Burst.gameObject.activeSelf)
				{
					this.ParticleEffect_Burst = null;
				}
				if (this.GM.IsArabic)
				{
					Transform transform7 = base.transform.GetChild(7).GetChild(2).GetChild(0).transform;
					Vector3 vector = new Vector3(-1f, 1f, 1f);
					base.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector;
					transform7.localScale = vector;
				}
				else
				{
					Transform transform8 = base.transform.GetChild(7).GetChild(2).GetChild(0).transform;
					Vector3 vector = Vector3.one;
					base.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector;
					transform8.localScale = vector;
				}
				if ((int)this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
				{
					if (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftDead > 0u)
					{
						this.DeadCountsStr[0].ClearString();
						this.DeadCountsStr[0].IntToFormat((long)(-(long)((ulong)UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftDead)), 1, true);
						this.DeadCountsStr[0].AppendFormat("{0}");
						this.DeadCounts[0].text = this.DeadCountsStr[0].ToString();
						if (this.GM.IsArabic)
						{
							this.DeadCounts[0].rectTransform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
						}
						else
						{
							this.DeadCounts[0].rectTransform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
						}
					}
					if (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightDead > 0u)
					{
						this.DeadCountsStr[1].ClearString();
						this.DeadCountsStr[1].IntToFormat((long)(-(long)((ulong)UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightDead)), 1, true);
						this.DeadCountsStr[1].AppendFormat("{0}");
						this.DeadCounts[1].text = this.DeadCountsStr[1].ToString();
						if (this.GM.IsArabic)
						{
							this.DeadCounts[1].rectTransform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
						}
						else
						{
							this.DeadCounts[1].rectTransform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
						}
					}
				}
				if (LeftHeroWin)
				{
					AudioManager.Instance.PlaySFX(this.RightDyingSfx, 0f, PitchKind.Hit, null, null);
				}
				else
				{
					AudioManager.Instance.PlaySFX(this.LeftDyingSfx, 0f, PitchKind.Hit, null, null);
				}
			}
			else
			{
				float num16 = 1f;
				if (NowRoundTime > 3.5899999141693115)
				{
					num16 = 6.186663f - 1.33333242f * (float)NowRoundTime;
					if (num16 < 1f)
					{
						num16 = 1f;
					}
				}
				else if (NowRoundTime > 2.4900000095367432)
				{
					num16 = 1.4f;
				}
				else if (NowRoundTime > 2.19)
				{
					num16 = 1.33333349f * (float)NowRoundTime - 1.92000031f;
					if (num16 > 1.4f)
					{
						num16 = 1.4f;
					}
				}
				if (this.GM.IsArabic)
				{
					Transform transform9 = base.transform.GetChild(7).GetChild(2).GetChild(0).transform;
					Vector3 vector = num16 * new Vector3(-1f, 1f, 1f);
					base.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector;
					transform9.localScale = vector;
				}
				else
				{
					Transform transform10 = base.transform.GetChild(7).GetChild(2).GetChild(0).transform;
					Vector3 vector = num16 * Vector3.one;
					base.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector;
					transform10.localScale = vector;
				}
				if ((int)this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
				{
					float num17 = 3.8f - (float)NowRoundTime;
					if (num17 < 0f)
					{
						num17 = 0f;
					}
					num17 /= 1.57f;
					if (num17 > 1f)
					{
						num17 = 1f;
					}
					uint num18 = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightSurvive + (uint)(num17 * UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightDead);
					uint num19 = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftSurvive + (uint)(num17 * UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftDead);
					this.AllianceStr[6].ClearString();
					this.AllianceStr[6].uLongToFormat((ulong)num19, 1, true);
					this.AllianceStr[6].AppendFormat("{0}");
					if (this.m_player[0, 10])
					{
						this.m_player[0, 10].text = this.AllianceStr[6].ToString();
						this.m_player[0, 10].SetAllDirty();
						this.m_player[0, 10].cachedTextGenerator.Invalidate();
					}
					this.AllianceStr[9].ClearString();
					this.AllianceStr[9].uLongToFormat((ulong)num18, 1, true);
					this.AllianceStr[9].AppendFormat("{0}");
					if (this.m_player[1, 10])
					{
						this.m_player[1, 10].text = this.AllianceStr[9].ToString();
						this.m_player[1, 10].SetAllDirty();
						this.m_player[1, 10].cachedTextGenerator.Invalidate();
					}
				}
			}
			break;
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_BURST:
			if (NowRoundTime > 5.619999885559082)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_END;
				this.SetterWinner(LeftHeroWin);
				this.burstScaleSpeed = (this.burstRotationSpeed = 0f);
				GameObject gameObject;
				GameObject gameObject2;
				if (LeftHeroWin)
				{
					gameObject = LeftHero;
					gameObject2 = RightHero;
				}
				else
				{
					gameObject = RightHero;
					gameObject2 = LeftHero;
				}
				if (gameObject != null)
				{
					if (!gameObject.activeSelf)
					{
						gameObject.SetActive(true);
					}
					Transform transform11 = gameObject.transform;
					if (transform11 != null)
					{
						transform11.localPosition = Vector3.zero;
						transform11.localRotation = Quaternion.Euler(Vector3.zero);
						transform11.localScale = Vector3.one;
						Color color = new Color(1f, 1f, 1f, 1f);
						transform11.GetChild(0).GetComponent<Image>().color = color;
						transform11.GetChild(1).GetComponent<Image>().color = color;
					}
				}
				if (gameObject2 != null && gameObject2.activeSelf)
				{
					gameObject2.SetActive(false);
					Color color2 = new Color(1f, 1f, 1f, 1f);
					gameObject2.transform.GetChild(0).GetComponent<Image>().color = color2;
					gameObject2.transform.GetChild(1).GetComponent<Image>().color = color2;
					base.transform.GetChild((!LeftHeroWin) ? 7 : 8).GetChild(2).gameObject.SetActive(false);
					base.transform.GetChild((!LeftHeroWin) ? 7 : 8).GetChild(6).gameObject.SetActive(false);
				}
				this.DeadCounts[0].text = string.Empty;
				this.DeadCounts[1].text = string.Empty;
			}
			else
			{
				GameObject gameObject3 = (!LeftHeroWin) ? LeftHero : RightHero;
				if (gameObject3 != null)
				{
					Transform transform12 = gameObject3.transform;
					if (transform12 != null)
					{
						if (NowRoundTime > 4.1999998092651367)
						{
							bool flag = true;
							if (NowRoundTime <= 4.3299999237060547)
							{
								flag = false;
								float num20 = (float)(NowRoundTime - 4.1999998092651367) / 0.13f;
								transform12.localScale = Vector3.Lerp(new Vector3(1f, 1f, 1f), new Vector3(1.2f, 1.2f, 1.2f), num20);
								if (LeftHeroWin)
								{
									transform12.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, -30f), num20));
								}
								else
								{
									transform12.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 30f), num20));
								}
							}
							else if (NowRoundTime <= 4.4600000381469727)
							{
								flag = false;
								float num20 = (float)(NowRoundTime - 4.3299999237060547) / 0.13f;
								transform12.localScale = Vector3.Lerp(new Vector3(1.2f, 1.2f, 1.2f), new Vector3(1.3f, 1.3f, 1.3f), num20);
								if (LeftHeroWin)
								{
									transform12.localPosition = Vector3.Lerp(new Vector3(78f, 0f, 0f), new Vector3(128f, 107f, 0f), num20);
									transform12.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, -30f), new Vector3(0f, 0f, -60f), num20));
								}
								else
								{
									transform12.localPosition = Vector3.Lerp(new Vector3(-78f, 0f, 0f), new Vector3(-128f, 107f, 0f), num20);
									transform12.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, 30f), new Vector3(0f, 0f, 60f), num20));
								}
							}
							else if (NowRoundTime <= 4.8600001335144043)
							{
								float num20 = (float)(NowRoundTime - 4.4600000381469727) / 0.4f;
								transform12.localScale = Vector3.Lerp(new Vector3(1.3f, 1.3f, 1.3f), new Vector3(1.1f, 1.1f, 1.1f), num20);
								if (LeftHeroWin)
								{
									transform12.localPosition = Vector3.Lerp(new Vector3(128f, 107f, 0f), new Vector3(185f, 84f, 0f), num20);
								}
								else
								{
									transform12.localPosition = Vector3.Lerp(new Vector3(-128f, 107f, 0f), new Vector3(-185f, 84f, 0f), num20);
								}
							}
							else if (NowRoundTime <= 5.2600002288818359)
							{
								float num20 = (float)(NowRoundTime - 4.8600001335144043) / 0.4f;
								transform12.localScale = Vector3.Lerp(new Vector3(1.1f, 1.1f, 1.1f), new Vector3(1f, 1f, 1f), num20);
								if (LeftHeroWin)
								{
									transform12.localPosition = Vector3.Lerp(new Vector3(185f, 84f, 0f), new Vector3(210f, -160f, 0f), num20);
								}
								else
								{
									transform12.localPosition = Vector3.Lerp(new Vector3(-185f, 84f, 0f), new Vector3(-210f, -160f, 0f), num20);
								}
								if (!LeftHeroWin)
								{
									RightHero.transform.localPosition = Vector3.Lerp(new Vector3(78f, 0f, 0f), new Vector3(0f, 0f, 0f), num20);
									RightHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, -20f), new Vector3(0f, 0f, 0f), num20));
								}
								else
								{
									LeftHero.transform.localPosition = Vector3.Lerp(new Vector3(-78f, 0f, 0f), new Vector3(0f, 0f, 0f), num20);
									LeftHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, 20f), new Vector3(0f, 0f, 0f), num20));
								}
							}
							if (this.ParticleEffect_Burst == null)
							{
								if (Time.timeScale > 0f)
								{
									AudioManager.Instance.PlayUISFX(UIKind.Explosion);
								}
								this.ParticleEffect_Burst = ParticleManager.Instance.Spawn(432, transform12.parent, transform12.localPosition, 1f, true, true, true);
								this.ParticleEffect_Burst.transform.localPosition = new Vector3(transform12.localPosition.x, transform12.localPosition.y, -800f);
								this.ParticleEffect_Burst.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
								GUIManager.Instance.SetLayer(this.ParticleEffect_Burst, 5);
							}
							if (flag)
							{
								transform12.Rotate(0f, 0f, ((!LeftHeroWin) ? 494f : -494f) * Time.timeScale * Time.unscaledDeltaTime);
								float num20 = (float)(NowRoundTime - 4.4600000381469727);
								Color color3 = new Color(1f, 1f, 1f, Mathf.Max(1f - num20, 0f));
								transform12.GetChild(0).GetComponent<Image>().color = color3;
								transform12.GetChild(1).GetComponent<Image>().color = color3;
							}
						}
						else
						{
							float num21 = transform12.localScale.x + this.burstScaleSpeed * 10f * Time.deltaTime * this.FightTimeScale;
							if (num21 > 1.2f)
							{
								num21 = 1.2f;
								this.burstScaleSpeed = -(float)UnityEngine.Random.Range(2, 5);
							}
							else if (num21 < 1f)
							{
								num21 = 1f;
								this.burstScaleSpeed = (float)UnityEngine.Random.Range(2, 5);
							}
							transform12.localScale = num21 * Vector3.one;
							float num22 = transform12.localEulerAngles.z + this.burstRotationSpeed * 300f * Time.deltaTime * this.FightTimeScale;
							if (num22 > 180f)
							{
								num22 -= 360f;
							}
							if (num22 > 0f)
							{
								if (num22 > 21f)
								{
									num22 = 21f;
									this.burstRotationSpeed = -(float)UnityEngine.Random.Range(2, 5);
								}
								else if (num22 < 16f)
								{
									num22 = 16f;
									this.burstRotationSpeed = (float)UnityEngine.Random.Range(2, 5);
								}
							}
							else if (num22 < 0f)
							{
								if (num22 < -21f)
								{
									num22 = -21f;
									this.burstRotationSpeed = (float)UnityEngine.Random.Range(2, 5);
								}
								else if (num22 > -16f)
								{
									num22 = -16f;
									this.burstRotationSpeed = -(float)UnityEngine.Random.Range(2, 5);
								}
							}
							transform12.localRotation = Quaternion.Euler(new Vector3(0f, 0f, num22));
						}
					}
					float num23;
					if (NowRoundTime < 4.070000171661377)
					{
						num23 = EasingEffect.Linear((float)NowRoundTime - 3.89f, 0f, 1.2f, 0.18f);
					}
					else if (NowRoundTime < 4.570000171661377)
					{
						num23 = EasingEffect.InQuadratic((float)NowRoundTime - 4.07f, 1.2f, -0.5f, 0.5f);
					}
					else
					{
						num23 = 0.7f;
					}
					if (this.GM.IsArabic)
					{
						this.DeadCounts[0].rectTransform.localScale = new Vector3(-num23, num23, num23);
					}
					else
					{
						this.DeadCounts[0].rectTransform.localScale = new Vector3(num23, num23, num23);
					}
					this.DeadCounts[1].rectTransform.localScale = this.DeadCounts[0].rectTransform.localScale;
				}
			}
			break;
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_END:
			if (NowRoundTime > 5.9000000953674316)
			{
				Vector3 vector6;
				if (LeftHeroWin)
				{
					base.transform.GetChild(8).GetChild(2).gameObject.SetActive(false);
					base.transform.GetChild(8).GetChild(6).gameObject.SetActive(false);
					Transform transform13 = RightHero.transform;
					vector6 = Vector3.zero;
					RightHero.transform.transform.GetChild(0).localScale = vector6;
					transform13.localScale = vector6;
					RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
				}
				else
				{
					base.transform.GetChild(7).GetChild(2).gameObject.SetActive(false);
					base.transform.GetChild(7).GetChild(6).gameObject.SetActive(false);
					Transform transform14 = LeftHero.transform;
					vector6 = Vector3.zero;
					LeftHero.transform.transform.GetChild(0).localScale = vector6;
					transform14.localScale = vector6;
				}
				Transform transform15 = LeftHero.transform;
				vector6 = Vector3.zero;
				RightHero.transform.localPosition = vector6;
				transform15.localPosition = vector6;
				Transform transform16 = LeftHero.transform;
				Quaternion identity = Quaternion.identity;
				RightHero.transform.localRotation = identity;
				transform16.localRotation = identity;
				if (this.GM.IsArabic)
				{
					Transform transform17 = this.m_player[0, 13].transform;
					vector6 = new Vector3(-1f, 0f, 0f);
					this.m_player[1, 13].transform.localScale = vector6;
					transform17.localScale = vector6;
				}
				else
				{
					Transform transform18 = this.m_player[0, 13].transform;
					vector6 = Vector3.one;
					this.m_player[1, 13].transform.localScale = vector6;
					transform18.localScale = vector6;
				}
				this.SetStage(UIAllianceWarBattle.MoveStage.MS_FIGHTING);
			}
			break;
		}
	}

	// Token: 0x06000E2C RID: 3628 RVA: 0x00170F08 File Offset: 0x0016F108
	protected void RunHeroStateB(GameObject LeftHero, GameObject RightHero, bool LeftHeroWin, double NowRoundTime)
	{
		if (this.MovieStage == UIAllianceWarBattle.MoveStage.MS_FINISH)
		{
			return;
		}
		switch (this.MovieStage)
		{
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_START:
		{
			base.transform.GetChild(7).GetChild(2).gameObject.SetActive(true);
			base.transform.GetChild(7).GetChild(6).gameObject.SetActive(true);
			base.transform.GetChild(7).GetChild(4).gameObject.SetActive(false);
			base.transform.GetChild(8).GetChild(2).gameObject.SetActive(true);
			base.transform.GetChild(8).GetChild(6).gameObject.SetActive(true);
			base.transform.GetChild(8).GetChild(4).gameObject.SetActive(false);
			base.transform.GetChild(6).GetChild(0).GetChild(13).gameObject.SetActive(false);
			base.transform.GetChild(6).GetChild(1).GetChild(13).gameObject.SetActive(false);
			Transform transform = LeftHero.transform;
			Vector3 vector = Vector3.one;
			RightHero.transform.localScale = vector;
			transform.localScale = vector;
			Transform transform2 = LeftHero.transform;
			vector = Vector3.zero;
			RightHero.transform.localPosition = vector;
			transform2.localPosition = vector;
			Transform transform3 = LeftHero.transform;
			Quaternion identity = Quaternion.identity;
			RightHero.transform.localRotation = identity;
			transform3.localRotation = identity;
			Transform child = LeftHero.transform.GetChild(0);
			vector = Vector3.one;
			RightHero.transform.GetChild(0).localScale = vector;
			child.localScale = vector;
			LeftHero.transform.gameObject.SetActive(true);
			RightHero.transform.gameObject.SetActive(true);
			RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
			for (int i = 0; i < 2; i++)
			{
				this.HeroButt[i].HeroHint.HIImage.color = Color.white;
				this.HeroButt[i].HeroHint.CircleImage.color = Color.white;
				base.transform.GetChild(6).GetChild(i + 4).gameObject.GetComponent<Image>().color = Color.white;
			}
			if (NowRoundTime > 0.33000001311302185)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_MOVE;
				LeftHero.transform.GetChild(0).localScale = Vector3.one;
				RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				float num = 0f;
				if (NowRoundTime > 0.0)
				{
					num = DamageValueManager.easeOutCubic(4f, 1f, (float)(NowRoundTime / 0.5));
				}
				if (this.LastWinner == 1 || this.LastWinner == 0)
				{
					base.transform.GetChild(6).GetChild(5).gameObject.SetActive(true);
					RightHero.transform.GetChild(0).localScale = new Vector3(num * -1f, num, num);
				}
				if (this.LastWinner == 2 || this.LastWinner == 0)
				{
					base.transform.GetChild(6).GetChild(4).gameObject.SetActive(true);
					LeftHero.transform.GetChild(0).localScale = new Vector3(num, num, num);
				}
				if (NowRoundTime > 0.25)
				{
					if ((this.LastWinner == 1 || this.LastWinner == 0) && this.ParticleEffect_InRight == null)
					{
						if (Time.timeScale > 0f)
						{
							AudioManager.Instance.PlayUISFX(UIKind.CutIn);
						}
						this.ParticleEffect_InRight = ParticleManager.Instance.Spawn(430, base.transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
						this.ParticleEffect_InRight.transform.localPosition = new Vector3(113f, -58f, -800f);
						this.ParticleEffect_InRight.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
						GUIManager.Instance.SetLayer(this.ParticleEffect_InRight, 5);
					}
					if ((this.LastWinner == 2 || this.LastWinner == 0) && this.ParticleEffect_InLeft == null)
					{
						if (Time.timeScale > 0f)
						{
							AudioManager.Instance.PlayUISFX(UIKind.CutIn);
						}
						this.ParticleEffect_InLeft = ParticleManager.Instance.Spawn(430, base.transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
						this.ParticleEffect_InLeft.transform.localPosition = new Vector3(-113f, -58f, -800f);
						this.ParticleEffect_InLeft.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
						GUIManager.Instance.SetLayer(this.ParticleEffect_InLeft, 5);
					}
				}
				if (NowRoundTime > 0.0)
				{
					num = DamageValueManager.easeOutCubic(0f, 1f, (float)(NowRoundTime / 0.33000001311302185));
					if (this.LastWinner == 1 || this.LastWinner == 0)
					{
						Image component = RightHero.transform.GetChild(0).GetComponent<Image>();
						if (component)
						{
							component.color = new Color(1f, 1f, 1f, num);
						}
						component = RightHero.transform.GetChild(1).GetComponent<Image>();
						if (component)
						{
							component.color = new Color(1f, 1f, 1f, num);
						}
					}
					if (this.LastWinner == 2 || this.LastWinner == 0)
					{
						Image component2 = LeftHero.transform.GetChild(0).GetComponent<Image>();
						if (component2)
						{
							component2.color = new Color(1f, 1f, 1f, num);
						}
						component2 = LeftHero.transform.GetChild(1).GetComponent<Image>();
						if (component2)
						{
							component2.color = new Color(1f, 1f, 1f, num);
						}
					}
					base.transform.GetChild(6).GetChild(4).gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, num);
					base.transform.GetChild(6).GetChild(5).gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, num);
				}
			}
			if (this.ParticleEffect_Hit != null && !this.ParticleEffect_Hit.gameObject.activeSelf)
			{
				this.ParticleEffect_Hit = null;
			}
			break;
		}
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_MOVE:
			if (NowRoundTime > 0.88999998569488525)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_PULL;
				base.transform.GetChild(6).GetChild(4).gameObject.SetActive(false);
				base.transform.GetChild(6).GetChild(5).gameObject.SetActive(false);
				Transform transform4 = LeftHero.transform;
				Vector3 vector = Vector3.one;
				RightHero.transform.localScale = vector;
				transform4.localScale = vector;
				Transform transform5 = LeftHero.transform;
				vector = Vector3.zero;
				RightHero.transform.localPosition = vector;
				transform5.localPosition = vector;
				Transform transform6 = LeftHero.transform;
				Quaternion identity = Quaternion.identity;
				RightHero.transform.localRotation = identity;
				transform6.localRotation = identity;
				RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				float num2;
				if (NowRoundTime > 0.75)
				{
					num2 = DamageValueManager.easeOutCubic(1.2f, 1f, (float)((NowRoundTime - 0.75) / 0.14000000059604645));
				}
				else if (NowRoundTime > 0.61000001430511475)
				{
					num2 = DamageValueManager.easeOutCubic(1f, 1.2f, (float)((NowRoundTime - 0.61000001430511475) / 0.14000000059604645));
				}
				else if (NowRoundTime > 0.4699999988079071)
				{
					num2 = DamageValueManager.easeOutCubic(1.5f, 1f, (float)((NowRoundTime - 0.4699999988079071) / 0.14000000059604645));
				}
				else
				{
					num2 = DamageValueManager.easeOutCubic(1f, 1.5f, (float)((NowRoundTime - 0.33) / 0.14000000059604645));
				}
				if (this.LastWinner == 1 || this.LastWinner == 0)
				{
					RightHero.transform.localScale = new Vector3(num2, num2, num2);
				}
				if (this.LastWinner == 2 || this.LastWinner == 0)
				{
					LeftHero.transform.localScale = new Vector3(num2, num2, num2);
				}
			}
			break;
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_PULL:
			if (NowRoundTime >= 1.059999942779541)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_ATTACK;
				LeftHero.transform.localPosition = new Vector3(-53f, -10f, 0f);
				RightHero.transform.localPosition = new Vector3(53f, -10f, 0f);
				LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 15f));
				RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -15f));
			}
			else
			{
				Vector2 zero = Vector2.zero;
				Vector2 zero2 = Vector2.zero;
				Vector2 vector2 = new Vector2(0f, 0f);
				Vector2 vector3 = new Vector2(45f, 10f);
				float t = (float)(NowRoundTime - 0.88999998569488525) / 0.17f;
				zero.x = Mathf.Lerp(vector2.x, -vector3.x, t);
				zero.y = Mathf.Lerp(vector2.y, -vector3.y, t);
				zero2.x = Mathf.Lerp(vector2.x, vector3.x, t);
				zero2.y = Mathf.Lerp(vector2.y, -vector3.y, t);
				float num3 = Mathf.Lerp(0f, 25f, t);
				LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, num3));
				RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -num3));
				LeftHero.transform.localPosition = new Vector3(zero.x, zero.y, 0f);
				RightHero.transform.localPosition = new Vector3(zero2.x, zero2.y, 0f);
			}
			break;
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_ATTACK:
		{
			float num4 = 1.06f;
			float num5 = 2.16f;
			float num6 = 1.16f;
			if (NowRoundTime >= (double)num5)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_SPLIT;
				LeftHero.transform.localPosition = new Vector3(85f, 0f, 0f);
				RightHero.transform.localPosition = new Vector3(-85f, 0f, 0f);
				RightHero.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
				LeftHero.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
				LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -15f));
				RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 15f));
			}
			else
			{
				Vector2 vector4 = new Vector2(53f, 10f);
				Vector2 vector5 = new Vector2(85f, 0f);
				Vector2 zero3 = Vector2.zero;
				Vector2 zero4 = Vector2.zero;
				if (NowRoundTime - (double)num4 < (double)(num6 - num4))
				{
					float num7 = (float)(NowRoundTime - (double)num4) / (num6 - num4);
					float num9;
					float num8 = num9 = Mathf.Lerp(1f, 1.1f, num7);
					zero3.x = Mathf.Lerp(-vector4.x, vector5.x, num7);
					zero3.y = Mathf.Lerp(-vector4.y, vector5.y, num7);
					zero4.x = Mathf.Lerp(vector4.x, -vector5.x, num7);
					zero4.y = Mathf.Lerp(-vector4.y, vector5.y, num7);
					float num10 = Mathf.Lerp(-15f, 15f, num7);
					LeftHero.transform.localPosition = new Vector3(zero3.x, zero3.y, 0f);
					RightHero.transform.localPosition = new Vector3(zero4.x, zero4.y, 0f);
					LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -num10));
					RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, num10));
					RightHero.transform.localScale = new Vector3(num8, num8, num8);
					LeftHero.transform.localScale = new Vector3(num9, num9, num9);
				}
				else
				{
					vector4 = new Vector2(75f, 0f);
					if (NowRoundTime < (double)num5)
					{
						float num7 = (float)(NowRoundTime - (double)num6) / (num5 - num6);
						int num11 = (int)((NowRoundTime - (double)num6) / 0.10000000149011612);
						int num12 = (num11 % 2 != 0) ? -1 : 1;
						float t2 = num7 / 0.1f - (float)num11;
						float num13 = 15f;
						float num9;
						float num8;
						if (num12 == -1)
						{
							zero3.x = Mathf.Lerp(vector4.x + num13, vector4.x - num13, t2);
							zero4.x = Mathf.Lerp(-vector4.x + num13, -vector4.x - num13, t2);
							num8 = Mathf.Lerp(1f, 1.1f, t2);
							num9 = Mathf.Lerp(1.1f, 1f, t2);
						}
						else
						{
							zero3.x = Mathf.Lerp(vector4.x - num13, vector4.x + num13, t2);
							zero4.x = Mathf.Lerp(-vector4.x - num13, -vector4.x + num13, t2);
							num8 = Mathf.Lerp(1.1f, 1f, t2);
							num9 = Mathf.Lerp(1f, 1.1f, t2);
						}
						LeftHero.transform.localPosition = new Vector3(zero3.x, vector4.y, 0f);
						RightHero.transform.localPosition = new Vector3(zero4.x, vector4.y, 0f);
						RightHero.transform.localScale = new Vector3(num8, num8, num8);
						LeftHero.transform.localScale = new Vector3(num9, num9, num9);
					}
					if (NowRoundTime > 2.059999942779541 && this.ParticleEffect_Hit == null)
					{
						if (Time.timeScale > 0f)
						{
							AudioManager.Instance.PlaySFX(40054, 0f, PitchKind.Hit, null, null);
						}
						AudioManager.Instance.PlaySFX(this.LeftHurtSfx, 0f, PitchKind.Hit, null, null);
						AudioManager.Instance.PlaySFX(this.RightHurtSfx, 0f, PitchKind.Hit, null, null);
						this.ParticleEffect_Hit = ParticleManager.Instance.Spawn(431, base.transform.GetChild(9).transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
						this.ParticleEffect_Hit.transform.localPosition = new Vector3(0f, 80f, -800f);
						this.ParticleEffect_Hit.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
						GUIManager.Instance.SetLayer(this.ParticleEffect_Hit, 5);
					}
				}
			}
			break;
		}
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_SPLIT:
		{
			float num14 = 2.19f;
			float num15 = 2.32f;
			if (NowRoundTime > (double)num15)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_DAMAGE;
				LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 15f));
				RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -15f));
				LeftHero.transform.localScale = Vector3.one;
				RightHero.transform.localScale = Vector3.one;
				LeftHero.transform.localPosition = new Vector3(-51f, 0f, 0f);
				RightHero.transform.localPosition = new Vector3(51f, 0f, 0f);
				LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 15f));
				RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -15f));
				if (Time.timeScale > 0f)
				{
					AudioManager.Instance.PlayUISFX(UIKind.Score);
				}
			}
			else
			{
				float num16 = (float)(NowRoundTime - (double)num14) / (num15 - num14);
				float num17 = 0.5f;
				if (num16 < num17)
				{
					float num18 = num16 / num17;
					LeftHero.transform.localPosition = new Vector3(75f - 126f * num16, -8f * num18, 0f);
					RightHero.transform.localPosition = new Vector3(-75f + 126f * num16, -8f * num18, 0f);
					LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -15f + 55f * num18));
					RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 15f - 55f * num18));
				}
				else
				{
					LeftHero.transform.localPosition = new Vector3(-51f, 0f, 0f);
					RightHero.transform.localPosition = new Vector3(51f, 0f, 0f);
					float num18 = (num16 - num17) / num17;
					LeftHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 40f - 25f * num18));
					RightHero.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, -40f + 25f * num18));
					float num19 = 1.4f - 0.4f * num18;
					LeftHero.transform.localScale = new Vector3(num19, num19, num19);
					RightHero.transform.localScale = new Vector3(num19, num19, num19);
				}
			}
			break;
		}
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_DAMAGE:
			if (NowRoundTime > 3.8900001049041748)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_BURST;
				this.burstRotationSpeed = (float)UnityEngine.Random.Range(2, 5);
				this.burstRotationSpeed *= ((UnityEngine.Random.Range(0, 2) != 0) ? 1f : -1f);
				this.burstScaleSpeed = (float)UnityEngine.Random.Range(2, 5);
				this.burstScaleSpeed *= ((UnityEngine.Random.Range(0, 2) != 0) ? 1f : -1f);
				if ((int)this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
				{
					uint rightSurvive = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightSurvive;
					uint leftSurvive = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftSurvive;
					this.AllianceStr[6].ClearString();
					this.AllianceStr[6].uLongToFormat((ulong)leftSurvive, 1, true);
					this.AllianceStr[6].AppendFormat("{0}");
					if (this.m_player[0, 10])
					{
						this.m_player[0, 10].text = this.AllianceStr[6].ToString();
						this.m_player[0, 10].SetAllDirty();
						this.m_player[0, 10].cachedTextGenerator.Invalidate();
					}
					this.AllianceStr[9].ClearString();
					this.AllianceStr[9].uLongToFormat((ulong)rightSurvive, 1, true);
					this.AllianceStr[9].AppendFormat("{0}");
					if (this.m_player[1, 10])
					{
						this.m_player[1, 10].text = this.AllianceStr[9].ToString();
						this.m_player[1, 10].SetAllDirty();
						this.m_player[1, 10].cachedTextGenerator.Invalidate();
					}
				}
				if (this.ParticleEffect_Burst != null && !this.ParticleEffect_Burst.gameObject.activeSelf)
				{
					this.ParticleEffect_Burst = null;
				}
				if (this.GM.IsArabic)
				{
					Transform transform7 = base.transform.GetChild(7).GetChild(2).GetChild(0).transform;
					Vector3 vector = new Vector3(-1f, 1f, 1f);
					base.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector;
					transform7.localScale = vector;
				}
				else
				{
					Transform transform8 = base.transform.GetChild(7).GetChild(2).GetChild(0).transform;
					Vector3 vector = Vector3.one;
					base.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector;
					transform8.localScale = vector;
				}
				if ((int)this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
				{
					if (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftDead > 0u)
					{
						this.DeadCountsStr[0].ClearString();
						this.DeadCountsStr[0].IntToFormat((long)(-(long)((ulong)UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftDead)), 1, true);
						this.DeadCountsStr[0].AppendFormat("{0}");
						this.DeadCounts[0].text = this.DeadCountsStr[0].ToString();
						if (this.GM.IsArabic)
						{
							this.DeadCounts[0].rectTransform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
						}
						else
						{
							this.DeadCounts[0].rectTransform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
						}
					}
					if (UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightDead > 0u)
					{
						this.DeadCountsStr[1].ClearString();
						this.DeadCountsStr[1].IntToFormat((long)(-(long)((ulong)UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightDead)), 1, true);
						this.DeadCountsStr[1].AppendFormat("{0}");
						this.DeadCounts[1].text = this.DeadCountsStr[1].ToString();
						if (this.GM.IsArabic)
						{
							this.DeadCounts[1].rectTransform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
						}
						else
						{
							this.DeadCounts[1].rectTransform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
						}
					}
				}
				if (LeftHeroWin)
				{
					AudioManager.Instance.PlaySFX(this.RightDyingSfx, 0f, PitchKind.Hit, null, null);
				}
				else
				{
					AudioManager.Instance.PlaySFX(this.LeftDyingSfx, 0f, PitchKind.Hit, null, null);
				}
			}
			else
			{
				float num20 = 1f;
				if (NowRoundTime > 3.5899999141693115)
				{
					num20 = 6.186663f - 1.33333242f * (float)NowRoundTime;
					if (num20 < 1f)
					{
						num20 = 1f;
					}
				}
				else if (NowRoundTime > 2.4900000095367432)
				{
					num20 = 1.4f;
				}
				else if (NowRoundTime > 2.19)
				{
					num20 = 1.33333349f * (float)NowRoundTime - 1.92000031f;
					if (num20 > 1.4f)
					{
						num20 = 1.4f;
					}
				}
				if (this.GM.IsArabic)
				{
					Transform transform9 = base.transform.GetChild(7).GetChild(2).GetChild(0).transform;
					Vector3 vector = num20 * new Vector3(-1f, 1f, 1f);
					base.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector;
					transform9.localScale = vector;
				}
				else
				{
					Transform transform10 = base.transform.GetChild(7).GetChild(2).GetChild(0).transform;
					Vector3 vector = num20 * Vector3.one;
					base.transform.GetChild(8).GetChild(2).GetChild(0).transform.localScale = vector;
					transform10.localScale = vector;
				}
				if ((int)this.BattleRound < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
				{
					float num21 = 3.89f - (float)NowRoundTime;
					if (num21 < 0f)
					{
						num21 = 0f;
					}
					num21 /= 1.57f;
					if (num21 > 1f)
					{
						num21 = 1f;
					}
					uint num22 = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightSurvive + (uint)(num21 * UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].RightDead);
					uint num23 = UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftSurvive + (uint)(num21 * UIAllianceWarBattle.BattleRoyale.BattleMatch[(int)this.BattleRound].LeftDead);
					this.AllianceStr[6].ClearString();
					this.AllianceStr[6].uLongToFormat((ulong)num23, 1, true);
					this.AllianceStr[6].AppendFormat("{0}");
					if (this.m_player[0, 10])
					{
						this.m_player[0, 10].text = this.AllianceStr[6].ToString();
						this.m_player[0, 10].SetAllDirty();
						this.m_player[0, 10].cachedTextGenerator.Invalidate();
					}
					this.AllianceStr[9].ClearString();
					this.AllianceStr[9].uLongToFormat((ulong)num22, 1, true);
					this.AllianceStr[9].AppendFormat("{0}");
					if (this.m_player[1, 10])
					{
						this.m_player[1, 10].text = this.AllianceStr[9].ToString();
						this.m_player[1, 10].SetAllDirty();
						this.m_player[1, 10].cachedTextGenerator.Invalidate();
					}
				}
			}
			break;
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_BURST:
			if (NowRoundTime > 4.96999979019165)
			{
				this.MovieStage = UIAllianceWarBattle.MoveStage.MS_FIGHTING_END;
				this.SetterWinner(LeftHeroWin);
				this.burstScaleSpeed = (this.burstRotationSpeed = 0f);
				GameObject gameObject;
				GameObject gameObject2;
				if (LeftHeroWin)
				{
					gameObject = LeftHero;
					gameObject2 = RightHero;
				}
				else
				{
					gameObject = RightHero;
					gameObject2 = LeftHero;
				}
				if (gameObject != null)
				{
					if (!gameObject.activeSelf)
					{
						gameObject.SetActive(true);
					}
					Transform transform11 = gameObject.transform;
					if (transform11 != null)
					{
						transform11.localPosition = new Vector3((!LeftHeroWin) ? 51f : -51f, 27f, 0f);
						transform11.localRotation = Quaternion.Euler(new Vector3(0f, 0f, (float)((!LeftHeroWin) ? -15 : 15)));
						transform11.localScale = Vector3.one;
						Color color = new Color(1f, 1f, 1f, 1f);
						transform11.GetChild(0).GetComponent<Image>().color = color;
						transform11.GetChild(1).GetComponent<Image>().color = color;
					}
				}
				if (gameObject2 != null && gameObject2.activeSelf)
				{
					gameObject2.SetActive(false);
					Color color2 = new Color(1f, 1f, 1f, 1f);
					gameObject2.transform.GetChild(0).GetComponent<Image>().color = color2;
					gameObject2.transform.GetChild(1).GetComponent<Image>().color = color2;
					base.transform.GetChild((!LeftHeroWin) ? 7 : 8).GetChild(2).gameObject.SetActive(false);
					base.transform.GetChild((!LeftHeroWin) ? 7 : 8).GetChild(6).gameObject.SetActive(false);
				}
				this.DeadCounts[0].text = string.Empty;
				this.DeadCounts[1].text = string.Empty;
			}
			else
			{
				GameObject gameObject3 = (!LeftHeroWin) ? LeftHero : RightHero;
				if (gameObject3 != null)
				{
					Transform transform12 = gameObject3.transform;
					if (transform12 != null)
					{
						if (NowRoundTime > 4.1999998092651367)
						{
							bool flag = true;
							if (NowRoundTime <= 4.3299999237060547)
							{
								flag = false;
								float num24 = (float)(NowRoundTime - 4.1999998092651367) / 0.13f;
								transform12.localScale = Vector3.Lerp(new Vector3(1f, 1f, 1f), new Vector3(1.2f, 1.2f, 1.2f), num24);
								if (LeftHeroWin)
								{
									transform12.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, -30f), num24));
								}
								else
								{
									transform12.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 30f), num24));
								}
							}
							else if (NowRoundTime <= 4.4600000381469727)
							{
								flag = false;
								float num24 = (float)(NowRoundTime - 4.3299999237060547) / 0.13f;
								transform12.localScale = Vector3.Lerp(new Vector3(1.2f, 1.2f, 1.2f), new Vector3(1.3f, 1.3f, 1.3f), num24);
								if (LeftHeroWin)
								{
									transform12.localPosition = Vector3.Lerp(new Vector3(78f, 0f, 0f), new Vector3(128f, 107f, 0f), num24);
									transform12.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, -30f), new Vector3(0f, 0f, -60f), num24));
								}
								else
								{
									transform12.localPosition = Vector3.Lerp(new Vector3(-78f, 0f, 0f), new Vector3(-128f, 107f, 0f), num24);
									transform12.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, 30f), new Vector3(0f, 0f, 60f), num24));
								}
							}
							else if (NowRoundTime <= 4.8600001335144043)
							{
								float num24 = (float)(NowRoundTime - 4.4600000381469727) / 0.4f;
								transform12.localScale = Vector3.Lerp(new Vector3(1.3f, 1.3f, 1.3f), new Vector3(1.1f, 1.1f, 1.1f), num24);
								if (LeftHeroWin)
								{
									transform12.localPosition = Vector3.Lerp(new Vector3(128f, 107f, 0f), new Vector3(185f, 84f, 0f), num24);
								}
								else
								{
									transform12.localPosition = Vector3.Lerp(new Vector3(-128f, 107f, 0f), new Vector3(-185f, 84f, 0f), num24);
								}
							}
							else if (NowRoundTime <= 5.2600002288818359)
							{
								float num24 = (float)(NowRoundTime - 4.8600001335144043) / 0.4f;
								transform12.localScale = Vector3.Lerp(new Vector3(1.1f, 1.1f, 1.1f), new Vector3(1f, 1f, 1f), num24);
								if (LeftHeroWin)
								{
									transform12.localPosition = Vector3.Lerp(new Vector3(185f, 84f, 0f), new Vector3(210f, -160f, 0f), num24);
								}
								else
								{
									transform12.localPosition = Vector3.Lerp(new Vector3(-185f, 84f, 0f), new Vector3(-210f, -160f, 0f), num24);
								}
								if (!LeftHeroWin)
								{
									RightHero.transform.localPosition = Vector3.Lerp(new Vector3(78f, 0f, 0f), new Vector3(0f, 0f, 0f), num24);
									RightHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, -20f), new Vector3(0f, 0f, 0f), num24));
								}
								else
								{
									LeftHero.transform.localPosition = Vector3.Lerp(new Vector3(-78f, 0f, 0f), new Vector3(0f, 0f, 0f), num24);
									LeftHero.transform.localRotation = Quaternion.Euler(Vector3.Lerp(new Vector3(0f, 0f, 20f), new Vector3(0f, 0f, 0f), num24));
								}
							}
							if (this.ParticleEffect_Burst == null)
							{
								if (Time.timeScale > 0f)
								{
									AudioManager.Instance.PlayUISFX(UIKind.Explosion);
								}
								this.ParticleEffect_Burst = ParticleManager.Instance.Spawn(432, transform12.parent, transform12.localPosition, 1f, true, true, true);
								this.ParticleEffect_Burst.transform.localPosition = new Vector3(transform12.localPosition.x, transform12.localPosition.y, -800f);
								this.ParticleEffect_Burst.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
								GUIManager.Instance.SetLayer(this.ParticleEffect_Burst, 5);
							}
							if (flag)
							{
								transform12.Rotate(0f, 0f, ((!LeftHeroWin) ? 494f : -494f) * Time.timeScale * Time.unscaledDeltaTime);
								float num24 = (float)(NowRoundTime - 4.4600000381469727);
								Color color3 = new Color(1f, 1f, 1f, Mathf.Max(1f - num24, 0f));
								transform12.GetChild(0).GetComponent<Image>().color = color3;
								transform12.GetChild(1).GetComponent<Image>().color = color3;
							}
						}
						else
						{
							float num25 = transform12.localScale.x + this.burstScaleSpeed * 10f * Time.deltaTime * this.FightTimeScale;
							if (num25 > 1.05f)
							{
								num25 = 1.05f;
								this.burstScaleSpeed = -(float)UnityEngine.Random.Range(2, 5);
							}
							else if (num25 < 1f)
							{
								num25 = 1f;
								this.burstScaleSpeed = (float)UnityEngine.Random.Range(2, 5);
							}
							transform12.localScale = num25 * Vector3.one;
							float num26 = transform12.localEulerAngles.z + this.burstRotationSpeed * 300f * Time.deltaTime * this.FightTimeScale;
							if (num26 > 180f)
							{
								num26 -= 360f;
							}
							if (num26 > 0f)
							{
								if (num26 > 21f)
								{
									num26 = 21f;
									this.burstRotationSpeed = -(float)UnityEngine.Random.Range(2, 5);
								}
								else if (num26 < 16f)
								{
									num26 = 16f;
									this.burstRotationSpeed = (float)UnityEngine.Random.Range(2, 5);
								}
							}
							else if (num26 < 0f)
							{
								if (num26 < -21f)
								{
									num26 = -21f;
									this.burstRotationSpeed = (float)UnityEngine.Random.Range(2, 5);
								}
								else if (num26 > -16f)
								{
									num26 = -16f;
									this.burstRotationSpeed = -(float)UnityEngine.Random.Range(2, 5);
								}
							}
							transform12.localRotation = Quaternion.Euler(new Vector3(0f, 0f, num26));
						}
					}
					float num27;
					if (NowRoundTime < 4.070000171661377)
					{
						num27 = EasingEffect.Linear((float)NowRoundTime - 3.89f, 0f, 1.2f, 0.18f);
					}
					else if (NowRoundTime < 4.570000171661377)
					{
						num27 = EasingEffect.InQuadratic((float)NowRoundTime - 4.07f, 1.2f, -0.5f, 0.5f);
					}
					else
					{
						num27 = 0.7f;
					}
					if (this.GM.IsArabic)
					{
						this.DeadCounts[0].rectTransform.localScale = new Vector3(-num27, num27, num27);
					}
					else
					{
						this.DeadCounts[0].rectTransform.localScale = new Vector3(num27, num27, num27);
					}
					this.DeadCounts[1].rectTransform.localScale = this.DeadCounts[0].rectTransform.localScale;
				}
			}
			break;
		case UIAllianceWarBattle.MoveStage.MS_FIGHTING_END:
			if (NowRoundTime > 5.9000000953674316)
			{
				Vector3 vector6;
				if (LeftHeroWin)
				{
					base.transform.GetChild(8).GetChild(2).gameObject.SetActive(false);
					base.transform.GetChild(8).GetChild(6).gameObject.SetActive(false);
					Transform transform13 = RightHero.transform;
					vector6 = Vector3.zero;
					RightHero.transform.transform.GetChild(0).localScale = vector6;
					transform13.localScale = vector6;
					RightHero.transform.GetChild(0).localScale = new Vector3(-1f, 1f, 1f);
				}
				else
				{
					base.transform.GetChild(7).GetChild(2).gameObject.SetActive(false);
					base.transform.GetChild(7).GetChild(6).gameObject.SetActive(false);
					Transform transform14 = LeftHero.transform;
					vector6 = Vector3.zero;
					LeftHero.transform.transform.GetChild(0).localScale = vector6;
					transform14.localScale = vector6;
				}
				Transform transform15 = LeftHero.transform;
				vector6 = Vector3.zero;
				RightHero.transform.localPosition = vector6;
				transform15.localPosition = vector6;
				Transform transform16 = LeftHero.transform;
				Quaternion identity = Quaternion.identity;
				RightHero.transform.localRotation = identity;
				transform16.localRotation = identity;
				if (this.GM.IsArabic)
				{
					Transform transform17 = this.m_player[0, 13].transform;
					vector6 = new Vector3(-1f, 0f, 0f);
					this.m_player[1, 13].transform.localScale = vector6;
					transform17.localScale = vector6;
				}
				else
				{
					Transform transform18 = this.m_player[0, 13].transform;
					vector6 = Vector3.one;
					this.m_player[1, 13].transform.localScale = vector6;
					transform18.localScale = vector6;
				}
				this.SetStage(UIAllianceWarBattle.MoveStage.MS_FIGHTING);
			}
			else
			{
				float num28 = 5.066666f;
				float num29 = 5.2f;
				GameObject gameObject4 = (!LeftHeroWin) ? RightHero : LeftHero;
				if (gameObject4 != null)
				{
					if (!gameObject4.activeSelf)
					{
						gameObject4.SetActive(true);
					}
					Transform transform19 = gameObject4.transform;
					if (transform19 != null)
					{
						float z;
						float y;
						float x;
						if (NowRoundTime > (double)num29)
						{
							x = (y = (z = 0f));
						}
						else if (NowRoundTime > (double)num28)
						{
							float num30 = 74.9998f;
							float num31 = -389.998962f;
							y = num30 * (float)NowRoundTime + num31;
							if (LeftHeroWin)
							{
								num30 = 119.999687f;
								num31 = -623.998352f;
								x = num30 * (float)NowRoundTime + num31;
								num30 = 37.4999f;
								num31 = -194.999481f;
								z = num30 * (float)NowRoundTime + num31;
							}
							else
							{
								num30 = -119.999687f;
								num31 = 623.998352f;
								x = num31 + num30 * (float)NowRoundTime;
								num30 = -37.4999f;
								num31 = 194.999481f;
								z = num31 + num30 * (float)NowRoundTime;
							}
						}
						else
						{
							float num30 = -382.759918f;
							float num31 = 1929.31677f;
							y = num31 + num30 * (float)NowRoundTime;
							if (LeftHeroWin)
							{
								num30 = 362.0702f;
								num31 = -1850.48889f;
								x = num30 * (float)NowRoundTime + num31;
								num30 = -206.897263f;
								num31 = 1043.2793f;
								z = num31 + num30 * (float)NowRoundTime;
							}
							else
							{
								num30 = -362.0702f;
								num31 = 1850.48889f;
								x = num31 + num30 * (float)NowRoundTime;
								num30 = 206.897263f;
								num31 = -1043.2793f;
								z = num30 * (float)NowRoundTime + num31;
							}
						}
						transform19.localPosition = new Vector3(x, y, 0f);
						transform19.localRotation = Quaternion.Euler(new Vector3(0f, 0f, z));
						float num32;
						if (NowRoundTime > 5.086249828338623)
						{
							num32 = 6812.901f - 1290.32214f * (float)NowRoundTime;
						}
						else if (NowRoundTime > 5.2024998664855957)
						{
							num32 = 100f;
						}
						else
						{
							num32 = 1290.32214f * (float)NowRoundTime - 6312.901f;
						}
						if (num32 < 100f)
						{
							num32 = 100f;
						}
						if (num32 > 250f)
						{
							num32 = 250f;
						}
						num32 *= 0.01f;
						if (this.GM.IsArabic)
						{
							Transform transform20 = this.m_player[0, 13].transform;
							Vector3 vector6 = num32 * new Vector3(-1f, 1f, 1f);
							this.m_player[1, 13].transform.localScale = vector6;
							transform20.localScale = vector6;
						}
						else
						{
							Transform transform21 = this.m_player[0, 13].transform;
							Vector3 vector6 = num32 * Vector3.one;
							this.m_player[1, 13].transform.localScale = vector6;
							transform21.localScale = vector6;
						}
					}
				}
			}
			break;
		}
	}

	// Token: 0x06000E2D RID: 3629 RVA: 0x00173BB0 File Offset: 0x00171DB0
	public void OnDisable()
	{
		if (this.LeftRightInit)
		{
			LeftRightFly.Instance.SetEnable(false);
		}
		if (this.BattleReplay && !this.bEnd)
		{
			base.transform.GetChild(13).GetChild(1).GetChild(4).gameObject.SetActive(false);
			this.PauseTime = (double)Time.time - this.BattleTime;
			Time.timeScale = 1f;
			this.bDisabled = true;
		}
	}

	// Token: 0x06000E2E RID: 3630 RVA: 0x00173C34 File Offset: 0x00171E34
	private void OnEnable()
	{
		if (this.LeftRightInit)
		{
			LeftRightFly.Instance.SetEnable(true);
			if (!this.BattleReplay)
			{
				LeftRightFly.Instance.UpdateCutinStat();
			}
		}
		if (this.BattleReplay && this.bDisabled)
		{
			if (this.SetGo)
			{
				Time.timeScale = 0f;
			}
			UIAllianceWarBattle.ReplayTime = 1.0;
			this.bDisabled = false;
			this.BattleTime = (double)Time.time - this.PauseTime;
		}
	}

	// Token: 0x06000E2F RID: 3631 RVA: 0x00173CC0 File Offset: 0x00171EC0
	protected void Update()
	{
		if (this.LeftRightInit)
		{
			LeftRightFly.Instance.Update(true);
		}
		if (this.bRequest || (this.RequestData > 0L && this.DM.ServerTime > this.RequestData))
		{
			ActivityManager.Instance.AllianceWarSendReOpenMenu();
			this.bRequest = false;
			this.RequestData = 0L;
		}
		if (this.bExit)
		{
			if (this.door)
			{
				this.door.CloseMenu(false);
			}
			return;
		}
		if (this.bEnd || this.bReturn)
		{
			return;
		}
		this.PassTime = ((!this.BattleReplay) ? ((double)ActivityManager.Instance._ServerEventDeltaTime + NetworkManager.ServerTime) : ((double)Time.time));
		double num = (double)ActivityManager.Instance._ServerEventDeltaTime + NetworkManager.ServerTime - this.BattleTime - (double)this.BattlePrepare - (double)(this.BattleRound * ActivityManager.Instance.AW_FightTime);
		if (this.BattleReplay)
		{
			num = (double)Time.time - this.BattleTime - (double)this.BattlePrepare - (double)(this.BattleRound * ActivityManager.Instance.AW_FightTime);
		}
		num *= (double)this.FightTimeScale;
		this.Run(num);
		if (this.MovieStage == UIAllianceWarBattle.MoveStage.MS_WAITING)
		{
			if (this.PassTime - (double)this.BattlePrepare >= this.BattleTime)
			{
				this.SetStage(UIAllianceWarBattle.MoveStage.MS_STARTING);
			}
			else if (this.PassTime - (double)this.BattlePrepare + (double)this.ReadyGo > this.BattleTime)
			{
				if ((double)ActivityManager.Instance._ServerEventDeltaTime + NetworkManager.ServerTime - (double)this.BattlePrepare + 1.7999999523162842 >= this.BattleTime)
				{
					for (int i = 0; i < 2; i++)
					{
						if (this.ParticleEffect[i] != null)
						{
							ParticleManager.Instance.DeSpawn(this.ParticleEffect[i]);
							this.ParticleEffect[i] = null;
						}
					}
				}
				if (!this.LeftRightSet)
				{
					LeftRightFly.Instance.SetCountDown((float)((!this.BattleReplay) ? ((double)ActivityManager.Instance._ServerEventDeltaTime + NetworkManager.ServerTime - this.BattleTime - (double)this.BattlePrepare + (double)this.ReadyGo) : (10.0 + UIAllianceWarBattle.ReplayTime)));
				}
				this.LeftRightSet = true;
			}
		}
		else if (this.MovieStage > UIAllianceWarBattle.MoveStage.MS_FIGHTING)
		{
			switch (this.Rand)
			{
			case 0:
				this.RunHeroState(this.HeroButt[0].HeroHead, this.HeroButt[1].HeroHead, UIAllianceWarBattle.BattleRoyale.BattleWinner == 1, num);
				break;
			case 1:
				this.RunHeroStateA(this.HeroButt[0].HeroHead, this.HeroButt[1].HeroHead, UIAllianceWarBattle.BattleRoyale.BattleWinner == 1, num);
				break;
			case 2:
				this.RunHeroStateB(this.HeroButt[0].HeroHead, this.HeroButt[1].HeroHead, UIAllianceWarBattle.BattleRoyale.BattleWinner == 1, num);
				break;
			}
		}
	}

	// Token: 0x06000E30 RID: 3632 RVA: 0x00174014 File Offset: 0x00172214
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_FontTextureRebuilt:
			if (this.LeftRightInit)
			{
				LeftRightFly.Instance.Refresh_FontTexture();
			}
			for (int i = 0; i < this.m_player.GetLength(0); i++)
			{
				for (int j = 0; j < this.m_player.GetLength(1); j++)
				{
					if (this.m_player[i, j] != null && this.m_player[i, j].enabled)
					{
						this.m_player[i, j].enabled = false;
						this.m_player[i, j].enabled = true;
					}
				}
			}
			if (this.m_title && this.m_title.enabled)
			{
				this.m_title.enabled = !this.m_title.enabled;
				this.m_title.enabled = !this.m_title.enabled;
			}
			for (int k = 0; k < 2; k++)
			{
				if (this.DeadCounts[k] && this.DeadCounts[k].enabled)
				{
					this.DeadCounts[k].enabled = false;
					this.DeadCounts[k].enabled = true;
				}
			}
			break;
		default:
			switch (networkNews)
			{
			case NetworkNews.Login:
				if ((ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None || DataManager.Instance.RoleAlliance.Id == 0u) && this.door)
				{
					this.door.CloseMenu(false);
				}
				else if (!this.BattleReplay)
				{
					LeftRightFly.Instance.UpdateCutinStat();
				}
				break;
			case NetworkNews.Fallout:
				break;
			default:
				if (networkNews != NetworkNews.Refresh_Alliance)
				{
				}
				break;
			case NetworkNews.Refresh_Asset:
				break;
			}
			break;
		case NetworkNews.Refresh_AllianceWarRound:
			if (this.bReturn)
			{
				return;
			}
			if (this.BattleSide > 0)
			{
				this.bRequest = (this.bReturn = true);
			}
			else
			{
				this.bExit = true;
			}
			this.bEnd = true;
			break;
		case NetworkNews.Refresh_RecvAllianceInfo:
			if ((ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None || DataManager.Instance.RoleAlliance.Id == 0u) && this.door)
			{
				this.door.CloseMenu(false);
			}
			else if (!this.BattleReplay && ActivityManager.Instance.AW_State != EAllianceWarState.EAWS_Run)
			{
				this.bRequest = true;
				this.bReturn = true;
			}
			else if (this.bReturn || (!this.BattleReplay && (ActivityManager.Instance.AW_Round != UIAllianceWarBattle.BattleRoyale.GameRound || ActivityManager.Instance.AW_RoundBeginTime != UIAllianceWarBattle.BattleRoyale.BeginTime)))
			{
				if (this.bReturn)
				{
					this.bRequest = true;
				}
				else if (!this.bReturn)
				{
					if (this.BattleSide > 0)
					{
						this.bRequest = (this.bReturn = true);
					}
					else
					{
						this.bExit = true;
					}
				}
			}
			break;
		}
	}

	// Token: 0x06000E31 RID: 3633 RVA: 0x00174374 File Offset: 0x00172574
	public void OnButtonClick(UIButton sender)
	{
		if (this.door)
		{
			if (sender.m_BtnID1 == 1)
			{
				ActivityManager.Instance.Send_REQUEST_ALLIANCEWAR_RANKPRIZE();
			}
			else if (sender.m_BtnID1 == 2)
			{
				if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null)
				{
					ActivityManager.Instance.AllianceWarMgr.m_CombatPlayerData[0].AllianceTag = UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString();
				}
				if (UIAllianceWarBattle.BattleRoyale.DecepticonTag != null)
				{
					ActivityManager.Instance.AllianceWarMgr.m_CombatPlayerData[1].AllianceTag = UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString();
				}
				ActivityManager.Instance.AllianceWarMgr.Send_MSG_REQUEST_ALLIANCEWAR_COMBAT_REPORT(UIAllianceWarBattle.BattleRoyale.MatchID - 1, this.BattleRound);
				this.PauseReplay = this.BattleReplay;
			}
			else if (sender.m_BtnID1 == 3)
			{
				if (UIAllianceWarBattle.BattleRoyale.AutobotTag != null && UIAllianceWarBattle.BattleRoyale.AutobotTag.Length > 2)
				{
					this.PauseReplay = this.BattleReplay;
					this.DM.AllianceView.Id = 0u;
					this.DM.AllianceView.Tag = UIAllianceWarBattle.BattleRoyale.AutobotTag.ToString();
					this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5, 0, false);
				}
			}
			else if (sender.m_BtnID1 == 4)
			{
				if (UIAllianceWarBattle.BattleRoyale.DecepticonTag != null && UIAllianceWarBattle.BattleRoyale.DecepticonTag.Length > 2)
				{
					this.PauseReplay = this.BattleReplay;
					this.DM.AllianceView.Id = 0u;
					this.DM.AllianceView.Tag = UIAllianceWarBattle.BattleRoyale.DecepticonTag.ToString();
					this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5, 0, false);
				}
			}
			else if (sender.m_BtnID1 == 6)
			{
				base.transform.GetChild(13).GetChild(1).GetChild(3).gameObject.SetActive(true);
				base.transform.GetChild(13).GetChild(1).GetChild(4).gameObject.SetActive(true);
				this.BattleTime = (double)(Time.time - (float)this.BattlePrepare);
				this.BattleRound = (this.LastWinner = 0);
				this.bEnd = false;
				Time.timeScale = (float)UIAllianceWarBattle.ReplaySpeed;
				this.SetStage(UIAllianceWarBattle.MoveStage.MS_STARTING);
				AudioManager.Instance.PlayMP3SFX(BGMType.LegionWar, true, 0.54f);
			}
			else if (sender.m_BtnID1 == 7)
			{
				base.transform.GetChild(13).GetChild(1).GetChild(4).gameObject.SetActive(true);
				Time.timeScale = (float)UIAllianceWarBattle.ReplaySpeed;
			}
			else if (sender.m_BtnID1 == 8)
			{
				base.transform.GetChild(13).GetChild(1).GetChild(4).gameObject.SetActive(false);
				Time.timeScale = 0f;
			}
			else if (sender.m_BtnID1 == 9)
			{
				if (UIAllianceWarBattle.ReplaySpeed == 2)
				{
					UIAllianceWarBattle.ReplaySpeed = 3;
					this.m_player[2, 14].text = "x3";
				}
				else if (UIAllianceWarBattle.ReplaySpeed == 1)
				{
					UIAllianceWarBattle.ReplaySpeed = 2;
					this.m_player[2, 14].text = "x2";
				}
				else
				{
					UIAllianceWarBattle.ReplaySpeed = 1;
					this.m_player[2, 14].text = "x1";
				}
				if (Time.timeScale > 0f && !this.bEnd)
				{
					Time.timeScale = (float)UIAllianceWarBattle.ReplaySpeed;
				}
			}
			else if (sender.m_BtnID1 == 5)
			{
				if (this.BattlePosition > 0)
				{
					int i = 0;
					int num = 1;
					if ((int)this.BattlePosition > num)
					{
						while (i < UIAllianceWarBattle.BattleRoyale.BattleMatch.Length)
						{
							if (UIAllianceWarBattle.BattleRoyale.BattleMatch[i].WinnerSide != this.BattleSide && ++num >= (int)this.BattlePosition)
							{
								break;
							}
							i++;
						}
					}
					if (num < (int)this.BattlePosition)
					{
						this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(14632u), 255, true);
						return;
					}
					this.BattleTime = (double)(Time.time - (float)this.BattlePrepare - 0.125f);
					if (this.BattlePosition > 1)
					{
						this.BattleTime -= (double)((i + 1) * (int)ActivityManager.Instance.AW_FightTime);
					}
					this.bEnd = false;
					if (Time.timeScale > 0f)
					{
						Time.timeScale = (float)UIAllianceWarBattle.ReplaySpeed;
						base.transform.GetChild(13).GetChild(1).GetChild(4).gameObject.SetActive(true);
					}
					base.transform.GetChild(13).GetChild(1).GetChild(3).gameObject.SetActive(true);
					base.transform.GetChild(8).GetChild(5).gameObject.SetActive(false);
					base.transform.GetChild(7).GetChild(5).gameObject.SetActive(false);
					this.SetStage(UIAllianceWarBattle.MoveStage.MS_STARTING);
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14630u), 255, true);
					AudioManager.Instance.PlayMP3SFX(BGMType.LegionWar, true, 0.54f);
				}
				else
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14627u), 255, true);
				}
			}
			return;
		}
	}

	// Token: 0x06000E32 RID: 3634 RVA: 0x00174934 File Offset: 0x00172B34
	public void OnHIButtonClick(UIHIBtn sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			if (sender.m_BtnID2 < UIAllianceWarBattle.BattleRoyale.Autobot.Length && UIAllianceWarBattle.BattleRoyale.Autobot[sender.m_BtnID2].Name != null)
			{
				this.PauseReplay = this.BattleReplay;
				this.DM.ShowLordProfile(UIAllianceWarBattle.BattleRoyale.Autobot[sender.m_BtnID2].Name.ToString());
			}
		}
		else if (sender.m_BtnID1 == 2 && sender.m_BtnID2 < UIAllianceWarBattle.BattleRoyale.Decepticon.Length && UIAllianceWarBattle.BattleRoyale.Decepticon[sender.m_BtnID2].Name != null)
		{
			this.PauseReplay = this.BattleReplay;
			this.DM.ShowLordProfile(UIAllianceWarBattle.BattleRoyale.Decepticon[sender.m_BtnID2].Name.ToString());
		}
	}

	// Token: 0x06000E33 RID: 3635 RVA: 0x00174A38 File Offset: 0x00172C38
	public void RequestApplyList()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_APPLYALLIANCELIST;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06000E34 RID: 3636 RVA: 0x00174A6C File Offset: 0x00172C6C
	public void RequestAllianceReplay()
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_REPLAY;
		messagePacket.AddSeqId();
		messagePacket.Send(false);
	}

	// Token: 0x06000E35 RID: 3637 RVA: 0x00174AA0 File Offset: 0x00172CA0
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06000E36 RID: 3638 RVA: 0x00174AA4 File Offset: 0x00172CA4
	public void OnStateChange(EAllianceWarState oldState, EAllianceWarState NewState)
	{
		if (NewState < EAllianceWarState.EAWS_Run)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06000E37 RID: 3639 RVA: 0x00174ABC File Offset: 0x00172CBC
	private void iniFightingBurst(GameObject LeftHero, GameObject RightHero, bool LeftHeroWin, double NowRoundTime)
	{
		GameObject gameObject;
		GameObject gameObject2;
		if (LeftHeroWin)
		{
			gameObject = LeftHero;
			gameObject2 = RightHero;
		}
		else
		{
			gameObject = RightHero;
			gameObject2 = LeftHero;
		}
		if (gameObject != null)
		{
			if (!gameObject.activeSelf)
			{
				gameObject.SetActive(true);
			}
			Transform transform = gameObject.transform;
			if (transform != null)
			{
				transform.localPosition = new Vector3((!LeftHeroWin) ? -51f : 51f, 27f, 0f);
				transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, (float)((!LeftHeroWin) ? -15 : 15)));
				transform.localScale = Vector3.one;
				Color color = new Color(1f, 1f, 1f, 1f);
				transform.GetChild(0).GetComponent<Image>().color = color;
				transform.GetChild(1).GetComponent<Image>().color = color;
			}
		}
		if (gameObject2 != null)
		{
			Transform transform2 = gameObject2.transform;
			if (transform2 != null)
			{
				transform2.localPosition = new Vector3((!LeftHeroWin) ? -51f : 51f, 27f, 0f);
				if (NowRoundTime > 4.070000171661377)
				{
					float a = 5.522222f - 1.111111f * (float)NowRoundTime;
					Color color2 = new Color(1f, 1f, 1f, a);
					transform2.GetChild(0).GetComponent<Image>().color = color2;
					transform2.GetChild(1).GetComponent<Image>().color = color2;
				}
				else
				{
					float num = (float)UnityEngine.Random.Range(16, 22);
					num *= ((UnityEngine.Random.Range(0, 2) != 0) ? 1f : -1f);
					this.burstRotationSpeed = (float)UnityEngine.Random.Range(200, 500);
					this.burstRotationSpeed *= ((UnityEngine.Random.Range(0, 2) != 0) ? 1f : -1f);
					transform2.localRotation = new Quaternion(0f, 0f, num, 0f);
					float num2 = (float)UnityEngine.Random.Range(100, 106);
					num2 /= 100f;
					this.burstScaleSpeed = (float)UnityEngine.Random.Range(200, 500);
					this.burstScaleSpeed *= ((UnityEngine.Random.Range(0, 2) != 0) ? 1f : -1f);
					transform2.localScale = Vector3.one * num2;
					Color color3 = new Color(1f, 1f, 1f, 1f);
					transform2.GetChild(0).GetComponent<Image>().color = color3;
					transform2.GetChild(1).GetComponent<Image>().color = color3;
				}
			}
		}
	}

	// Token: 0x06000E38 RID: 3640 RVA: 0x00174D94 File Offset: 0x00172F94
	private void iniFightingEnd(GameObject LeftHero, GameObject RightHero, bool LeftHeroWin, double NowRoundTime)
	{
		GameObject gameObject;
		GameObject gameObject2;
		if (LeftHeroWin)
		{
			gameObject = LeftHero;
			gameObject2 = RightHero;
		}
		else
		{
			gameObject = RightHero;
			gameObject2 = LeftHero;
		}
		if (gameObject2 != null || gameObject2.activeSelf)
		{
			gameObject2.SetActive(false);
			Color color = new Color(1f, 1f, 1f, 1f);
			gameObject2.transform.GetChild(0).GetComponent<Image>().color = color;
			gameObject2.transform.GetChild(1).GetComponent<Image>().color = color;
		}
		if (gameObject != null)
		{
			if (!gameObject.activeSelf)
			{
				gameObject.SetActive(true);
			}
			Transform transform = gameObject.transform;
			if (transform != null)
			{
				float z;
				if (NowRoundTime > 5.0199999809265137)
				{
					float num = 11.363636f * (float)NowRoundTime - 67.0454559f;
					if (LeftHeroWin)
					{
						float num2 = 234.659088f - 39.772728f * (float)NowRoundTime;
						z = 5.681818f * (float)NowRoundTime + 33.522728f;
					}
					else
					{
						float num2 = 39.772728f * (float)NowRoundTime - 234.659088f;
						z = 33.522728f - 5.681818f * (float)NowRoundTime;
					}
				}
				else
				{
					float num = -3704.8f - 470f * (float)NowRoundTime;
					if (LeftHeroWin)
					{
						float num2 = 1720f * (float)NowRoundTime - 8599.4f;
						z = 2003f - 400f * (float)NowRoundTime;
					}
					else
					{
						float num2 = 8599.4f - 1720f * (float)NowRoundTime;
						z = 400f * (float)NowRoundTime - 2003f;
					}
				}
				transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, z));
				if (NowRoundTime > 5.434999942779541)
				{
					float num3 = 2003.22583f - 322.580658f * (float)NowRoundTime;
				}
				else
				{
					float num3 = 322.580658f * (float)NowRoundTime - 1503.22583f;
				}
			}
		}
	}

	// Token: 0x04002D68 RID: 11624
	private UIAllianceWarBattle.MoveStage MovieStage;

	// Token: 0x04002D69 RID: 11625
	private GameObject go;

	// Token: 0x04002D6A RID: 11626
	private GameObject Duke;

	// Token: 0x04002D6B RID: 11627
	private RectTransform Hero_PosRT;

	// Token: 0x04002D6C RID: 11628
	private Transform Tmp;

	// Token: 0x04002D6D RID: 11629
	private Transform Hero_Model;

	// Token: 0x04002D6E RID: 11630
	private Transform Hero_3D;

	// Token: 0x04002D6F RID: 11631
	private Transform Hero_Pos;

	// Token: 0x04002D70 RID: 11632
	private Transform HintButt;

	// Token: 0x04002D71 RID: 11633
	private Animation tmpAN;

	// Token: 0x04002D72 RID: 11634
	private ActivityWindow AW;

	// Token: 0x04002D73 RID: 11635
	private GameObject Autobot;

	// Token: 0x04002D74 RID: 11636
	private GameObject Decepticon;

	// Token: 0x04002D75 RID: 11637
	private GameObject DefeatEffect;

	// Token: 0x04002D76 RID: 11638
	private GameObject[] ParticleEffect = new GameObject[2];

	// Token: 0x04002D77 RID: 11639
	protected static double ReplayTime;

	// Token: 0x04002D78 RID: 11640
	protected static byte MatchID;

	// Token: 0x04002D79 RID: 11641
	private double PauseTime;

	// Token: 0x04002D7A RID: 11642
	private bool bDisabled;

	// Token: 0x04002D7B RID: 11643
	private bool PauseReplay;

	// Token: 0x04002D7C RID: 11644
	private bool BattleReplay;

	// Token: 0x04002D7D RID: 11645
	private byte BattlePosition;

	// Token: 0x04002D7E RID: 11646
	private byte BattleSide;

	// Token: 0x04002D7F RID: 11647
	private byte BattleFight;

	// Token: 0x04002D80 RID: 11648
	private byte BattleRound;

	// Token: 0x04002D81 RID: 11649
	private byte LastWinner;

	// Token: 0x04002D82 RID: 11650
	private double PassTime;

	// Token: 0x04002D83 RID: 11651
	private double NextTime;

	// Token: 0x04002D84 RID: 11652
	private double BattleTime;

	// Token: 0x04002D85 RID: 11653
	private ushort BattleWait;

	// Token: 0x04002D86 RID: 11654
	private ushort BattlePrepare;

	// Token: 0x04002D87 RID: 11655
	private uint BattleRoundTime;

	// Token: 0x04002D88 RID: 11656
	private uTweener[,] Movement = new uTweener[10, 10];

	// Token: 0x04002D89 RID: 11657
	private uTweenText[] PowerCount = new uTweenText[10];

	// Token: 0x04002D8A RID: 11658
	private uTweenScale[] EmblemScale = new uTweenScale[2];

	// Token: 0x04002D8B RID: 11659
	private uTweenPosition[] Position = new uTweenPosition[10];

	// Token: 0x04002D8C RID: 11660
	private uTweenRotation[] Rotation = new uTweenRotation[10];

	// Token: 0x04002D8D RID: 11661
	private UIButtonHint[] m_playerHint = new UIButtonHint[12];

	// Token: 0x04002D8E RID: 11662
	private CString[] AllianceStr = new CString[20];

	// Token: 0x04002D8F RID: 11663
	protected bool LeftRightInit;

	// Token: 0x04002D90 RID: 11664
	protected bool LeftRightSet;

	// Token: 0x04002D91 RID: 11665
	protected bool Preparing;

	// Token: 0x04002D92 RID: 11666
	protected bool Ready;

	// Token: 0x04002D93 RID: 11667
	protected bool SetGo;

	// Token: 0x04002D94 RID: 11668
	protected bool bRequest;

	// Token: 0x04002D95 RID: 11669
	protected bool bReturn;

	// Token: 0x04002D96 RID: 11670
	protected bool bExit;

	// Token: 0x04002D97 RID: 11671
	protected bool bEnd;

	// Token: 0x04002D98 RID: 11672
	protected Door door;

	// Token: 0x04002D99 RID: 11673
	protected Color[] m_Camp = new Color[2];

	// Token: 0x04002D9A RID: 11674
	protected Text[] m_label = new Text[28];

	// Token: 0x04002D9B RID: 11675
	protected Text m_limit;

	// Token: 0x04002D9C RID: 11676
	protected Text m_title;

	// Token: 0x04002D9D RID: 11677
	protected Text m_error;

	// Token: 0x04002D9E RID: 11678
	protected Text m_filter;

	// Token: 0x04002D9F RID: 11679
	protected Text m_search;

	// Token: 0x04002DA0 RID: 11680
	protected Text m_button;

	// Token: 0x04002DA1 RID: 11681
	protected Text m_content;

	// Token: 0x04002DA2 RID: 11682
	protected Text[] m_default = new Text[3];

	// Token: 0x04002DA3 RID: 11683
	protected Text[,] m_player = new Text[3, 20];

	// Token: 0x04002DA4 RID: 11684
	protected Text m_descript;

	// Token: 0x04002DA5 RID: 11685
	protected Image m_Dukedom;

	// Token: 0x04002DA6 RID: 11686
	protected Image m_Defeater;

	// Token: 0x04002DA7 RID: 11687
	protected Image m_MyEmperor;

	// Token: 0x04002DA8 RID: 11688
	protected Image m_CrownBack;

	// Token: 0x04002DA9 RID: 11689
	protected Image m_WorldWarZ;

	// Token: 0x04002DAA RID: 11690
	protected Image m_WorldPiss;

	// Token: 0x04002DAB RID: 11691
	protected UIAllianceWarBattle.Hero[] HeroButt = new UIAllianceWarBattle.Hero[2];

	// Token: 0x04002DAC RID: 11692
	protected UIText[] DeadCounts = new UIText[2];

	// Token: 0x04002DAD RID: 11693
	protected CString[] DeadCountsStr = new CString[2];

	// Token: 0x04002DAE RID: 11694
	protected UISpritesArray USArray;

	// Token: 0x04002DAF RID: 11695
	protected UIButtonHint m_UIHint;

	// Token: 0x04002DB0 RID: 11696
	protected Transform Transformer;

	// Token: 0x04002DB1 RID: 11697
	public static BattleStation BattleRoyale;

	// Token: 0x04002DB2 RID: 11698
	public GUIManager GM = GUIManager.Instance;

	// Token: 0x04002DB3 RID: 11699
	public DataManager DM = DataManager.Instance;

	// Token: 0x04002DB4 RID: 11700
	public NetworkManager NM = NetworkManager.Instance;

	// Token: 0x04002DB5 RID: 11701
	public Font Font = GUIManager.Instance.GetTTFFont();

	// Token: 0x04002DB6 RID: 11702
	public StringBuilder Path = new StringBuilder();

	// Token: 0x04002DB7 RID: 11703
	private List<float> ItemsHeight = new List<float>();

	// Token: 0x04002DB8 RID: 11704
	private string[] mHeroAct = new string[7];

	// Token: 0x04002DB9 RID: 11705
	private CString[] m_Str = new CString[10];

	// Token: 0x04002DBA RID: 11706
	private Effect effect;

	// Token: 0x04002DBB RID: 11707
	private ushort head;

	// Token: 0x04002DBC RID: 11708
	private uint time;

	// Token: 0x04002DBD RID: 11709
	private int Offset = 1;

	// Token: 0x04002DBE RID: 11710
	private long RequestData;

	// Token: 0x04002DBF RID: 11711
	private float ReadyGo = 10f;

	// Token: 0x04002DC0 RID: 11712
	private float BattleSpeed;

	// Token: 0x04002DC1 RID: 11713
	private static byte ReplaySpeed;

	// Token: 0x04002DC2 RID: 11714
	private static byte RoundPeriod = 10;

	// Token: 0x04002DC3 RID: 11715
	private static byte FinishPeriod = 30;

	// Token: 0x04002DC4 RID: 11716
	private static byte PreparePeriod = 60;

	// Token: 0x04002DC5 RID: 11717
	private float burstScaleSpeed = 1f;

	// Token: 0x04002DC6 RID: 11718
	private float burstRotationSpeed = 1f;

	// Token: 0x04002DC7 RID: 11719
	private float FightTimeScale = 1f;

	// Token: 0x04002DC8 RID: 11720
	private GameObject ParticleEffect_Hit;

	// Token: 0x04002DC9 RID: 11721
	private GameObject ParticleEffect_Burst;

	// Token: 0x04002DCA RID: 11722
	private GameObject ParticleEffect_InRight;

	// Token: 0x04002DCB RID: 11723
	private GameObject ParticleEffect_InLeft;

	// Token: 0x04002DCC RID: 11724
	private ushort LeftHurtSfx;

	// Token: 0x04002DCD RID: 11725
	private ushort RightHurtSfx;

	// Token: 0x04002DCE RID: 11726
	private ushort LeftDyingSfx;

	// Token: 0x04002DCF RID: 11727
	private ushort RightDyingSfx;

	// Token: 0x04002DD0 RID: 11728
	private int Rand;

	// Token: 0x020002BB RID: 699
	protected struct Hero
	{
		// Token: 0x04002DD1 RID: 11729
		public UIHIBtn HeroHint;

		// Token: 0x04002DD2 RID: 11730
		public GameObject HeroHead;

		// Token: 0x04002DD3 RID: 11731
		public uTweenRotation Rotation;

		// Token: 0x04002DD4 RID: 11732
		public uTweenPosition Position;
	}

	// Token: 0x020002BC RID: 700
	protected enum MoveStage : byte
	{
		// Token: 0x04002DD6 RID: 11734
		MS_WAITING,
		// Token: 0x04002DD7 RID: 11735
		MS_STARTING,
		// Token: 0x04002DD8 RID: 11736
		MS_FIGHTING,
		// Token: 0x04002DD9 RID: 11737
		MS_FIGHTING_START,
		// Token: 0x04002DDA RID: 11738
		MS_FIGHTING_MOVE,
		// Token: 0x04002DDB RID: 11739
		MS_FIGHTING_PULL,
		// Token: 0x04002DDC RID: 11740
		MS_FIGHTING_ATTACK,
		// Token: 0x04002DDD RID: 11741
		MS_FIGHTING_HIT,
		// Token: 0x04002DDE RID: 11742
		MS_FIGHTING_SPLIT,
		// Token: 0x04002DDF RID: 11743
		MS_FIGHTING_DAMAGE,
		// Token: 0x04002DE0 RID: 11744
		MS_FIGHTING_BURST,
		// Token: 0x04002DE1 RID: 11745
		MS_FIGHTING_END,
		// Token: 0x04002DE2 RID: 11746
		MS_FINISH,
		// Token: 0x04002DE3 RID: 11747
		MS_MAX
	}
}
