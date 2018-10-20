using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200039D RID: 925
public class UILeaderBoard : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06001354 RID: 4948 RVA: 0x0021FEC0 File Offset: 0x0021E0C0
	public override void OnOpen(int arg1, int arg2)
	{
		this.door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
		this.SPHeight = new List<float>();
		this.OpenKind = (UI_LeaderBoardOpenKind)arg1;
		this.m_targetAllianceID = (uint)arg2;
		this.DataReady = false;
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		Image component2 = this.AGS_Form.GetChild(8).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close_base");
		component2.material = this.door.LoadMaterial();
		component2.enabled = !GUIManager.Instance.bOpenOnIPhoneX;
		component2 = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close");
		component2.material = this.door.LoadMaterial();
		UIButton component3 = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_EffectType = e_EffectType.e_Scale;
		UIHIBtn component4 = this.AGS_Form.GetChild(3).GetChild(0).GetComponent<UIHIBtn>();
		component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component3 = this.AGS_Form.GetChild(11).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 7;
		component3.gameObject.SetActive(false);
		this.SPBG = this.AGS_Form.GetChild(14).GetComponent<Image>();
		this.SPRankUpDown = this.AGS_Form.GetChild(14).GetChild(3).GetComponent<Image>();
		this.SPBG.gameObject.SetActive(false);
		component3 = this.AGS_Form.GetChild(12).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 9;
		component3.gameObject.SetActive(false);
		component3 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 2;
		component3.m_BtnID2 = 1;
		this.POPLight1 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<Image>();
		component3 = this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 2;
		component3.m_BtnID2 = 2;
		this.POPLight3 = this.AGS_Form.GetChild(4).GetChild(1).GetChild(0).GetComponent<Image>();
		component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AGS_Panel1 = this.AGS_Form.GetChild(6).GetChild(0).GetComponent<ScrollPanel>();
		this.AGS_Panel1.m_ScrollPanelID = 1;
		component3 = this.AGS_Form.GetChild(6).GetChild(1).GetChild(1).GetComponent<UIButton>();
		component3.m_Handler = this;
		this.AGS_Form.GetChild(6).GetChild(1).GetChild(1).GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
		component4 = this.AGS_Form.GetChild(6).GetChild(1).GetChild(3).GetComponent<UIHIBtn>();
		component = this.AGS_Form.GetChild(6).GetChild(1).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(6).GetChild(1).GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(6).GetChild(1).GetChild(6).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AGS_Panel2 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<ScrollPanel>();
		this.AGS_Panel2.m_ScrollPanelID = 2;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetChild(6).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetChild(7).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(6).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(7).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component.gameObject.SetActive(false);
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(9).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component.gameObject.SetActive(false);
		component3 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(10).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_EffectType = e_EffectType.e_Scale;
		component3 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(11).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_EffectType = e_EffectType.e_Scale;
		UIButtonHint uibuttonHint = component3.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.UIArena_Hint;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
		this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(3).gameObject.SetActive(false);
		this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(8).gameObject.SetActive(false);
		component3 = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3 = this.AGS_Form.GetChild(9).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_EffectType = e_EffectType.e_Scale;
		component3.m_BtnID1 = 99;
		component3.gameObject.SetActive(this.OpenKind == UI_LeaderBoardOpenKind.BoardMenu);
		component = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(11025u);
		this.SPBG = this.AGS_Form.GetChild(14).GetComponent<Image>();
		this.SPRankUpDown = this.AGS_Form.GetChild(14).GetChild(3).GetComponent<Image>();
		this.SPBG.gameObject.SetActive(false);
		component = this.AGS_Form.GetChild(14).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.SPName = component;
		component = this.AGS_Form.GetChild(14).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.SPScore = component;
		component = this.AGS_Form.GetChild(14).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.SPScoreFly = component;
		this.SPFly = component.rectTransform;
		component = this.AGS_Form.GetChild(14).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.SPRank = component;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component5 = component3.gameObject.GetComponent<RectTransform>();
			component5.localScale = new Vector3(-1f, 1f, 1f);
			component5.anchoredPosition = new Vector2(component5.anchoredPosition.x + 44f, component5.anchoredPosition.y);
			component5 = this.AGS_Form.GetChild(12).gameObject.GetComponent<RectTransform>();
			component5.localScale = new Vector3(-1f, 1f, 1f);
			component5 = this.AGS_Form.GetChild(11).GetComponent<RectTransform>();
			component5.localScale = new Vector3(-1f, 1f, 1f);
		}
		Transform child = this.AGS_Form.GetChild(3).GetChild(0);
		GUIManager.Instance.InitianHeroItemImg(child, eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, 11, 0, 0, false, false, true, false);
		child.gameObject.SetActive(false);
		child = this.AGS_Form.GetChild(3).GetChild(1);
		GUIManager.Instance.InitBadgeTotem(child, DataManager.Instance.RoleAlliance.Emblem);
		child.gameObject.SetActive(false);
		this.KingdomImg = this.AGS_Form.GetChild(6).GetChild(2).GetComponent<RectTransform>();
		this.KingdomImg.gameObject.SetActive(false);
		switch (this.OpenKind)
		{
		case UI_LeaderBoardOpenKind.Alli_Inter:
			if (DataManager.Instance.RoleAlliance.Id == 0u)
			{
				this.door.CloseMenu(false);
				return;
			}
			if (UILeaderBoard.NewOpen)
			{
				UILeaderBoard.TopIndex[12] = 0;
				DataManager.Instance.SendAllianceMember();
			}
			else
			{
				this.DataReady = true;
			}
			break;
		case UI_LeaderBoardOpenKind.OtherAlli_inter:
			if (UILeaderBoard.NewOpen)
			{
				UILeaderBoard.TopIndex[12] = 0;
				DataManager.Instance.SendAllianceOthorMemberInfo(this.m_targetAllianceID);
			}
			else
			{
				this.DataReady = true;
			}
			break;
		case UI_LeaderBoardOpenKind.BoardMenu:
			this.AGS_Form.GetChild(4).gameObject.SetActive(true);
			if (UILeaderBoard.NewOpen)
			{
				UILeaderBoard.isTopBoard = true;
				UILeaderBoard.isPersonBoard = true;
				UILeaderBoard.SubBoardID = 0;
				UILeaderBoard.NewOpen = false;
			}
			if (UILeaderBoard.WorldBoard)
			{
				if (LeaderBoardManager.Instance.TopBoard.SortTime + 600L < DataManager.Instance.ServerTime && UILeaderBoard.isTopBoard)
				{
					MessagePacket messagePacket = new MessagePacket(1024);
					messagePacket.Protocol = Protocol._MSG_REQUEST_LEADERBOARDS_CLIENT;
					messagePacket.AddSeqId();
					messagePacket.Send(false);
					this.DataReady = false;
				}
				else
				{
					this.DataReady = true;
				}
			}
			else if (LeaderBoardManager.Instance.TopBoard.SortTime + 600L < DataManager.Instance.ServerTime && UILeaderBoard.isTopBoard)
			{
				MessagePacket messagePacket2 = new MessagePacket(1024);
				messagePacket2.Protocol = Protocol._MSG_REQUEST_LEADERBOARDS_CLIENT;
				messagePacket2.AddSeqId();
				messagePacket2.Send(false);
				this.DataReady = false;
			}
			else
			{
				this.DataReady = true;
			}
			break;
		case UI_LeaderBoardOpenKind.ArenaBoard:
			if (UILeaderBoard.NewOpen)
			{
				UILeaderBoard.isTopBoard = false;
				UILeaderBoard.isPersonBoard = true;
				UILeaderBoard.SubBoardID = 4;
				UILeaderBoard.NewOpen = false;
			}
			this.DataReady = true;
			break;
		case UI_LeaderBoardOpenKind.MobilizationGroupBoard:
			if (LeaderBoardManager.Instance.MobiGroupBoardUpdateTime < DataManager.Instance.ServerTime || LeaderBoardManager.Instance.MobiGroupAllianceID != DataManager.Instance.RoleAlliance.Id)
			{
				UILeaderBoard.TopIndex[13] = 0;
				MessagePacket messagePacket3 = new MessagePacket(1024);
				messagePacket3.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AM_ALLIANCE_RANK;
				messagePacket3.AddSeqId();
				messagePacket3.Send(false);
			}
			else
			{
				this.DataReady = true;
			}
			component2 = this.AGS_Form.GetChild(10).GetComponent<Image>();
			component2.gameObject.SetActive(true);
			GUIManager.Instance.SetAllyRankImage(component2, DataManager.Instance.RoleAlliance.AMRank);
			component3 = this.AGS_Form.GetChild(10).GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_EffectType = e_EffectType.e_Normal;
			component3.transition = Selectable.Transition.None;
			component3.m_BtnID1 = 12;
			uibuttonHint = component3.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.UIArena_Hint;
			uibuttonHint.m_Handler = this;
			uibuttonHint.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
			uibuttonHint.ScrollID = 1;
			break;
		case UI_LeaderBoardOpenKind.MobilizationAlliBoard:
			if (LeaderBoardManager.Instance.MobiAlliBoardUpdateTime < DataManager.Instance.ServerTime || LeaderBoardManager.Instance.MobiGroupAllianceID != DataManager.Instance.RoleAlliance.Id)
			{
				UILeaderBoard.TopIndex[14] = 0;
				MessagePacket messagePacket4 = new MessagePacket(1024);
				messagePacket4.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AM_MEMBER_RANK;
				messagePacket4.AddSeqId();
				messagePacket4.Send(false);
			}
			else
			{
				this.DataReady = true;
			}
			break;
		case UI_LeaderBoardOpenKind.WorldKingHistory:
			LeaderBoardManager.Instance.Send_MSG_REQUEST_KINGOFTHEWORLD_HISTORYKINGDATA();
			break;
		case UI_LeaderBoardOpenKind.KingofWorldRankingBoard:
			if (LeaderBoardManager.Instance.KingofWorldTime < DataManager.Instance.ServerTime)
			{
				MessagePacket messagePacket5 = new MessagePacket(1024);
				messagePacket5.Protocol = Protocol._MSG_REQUEST_KINGOFTHEWORLD_RANKDATA;
				messagePacket5.AddSeqId();
				messagePacket5.Send(false);
			}
			else
			{
				this.DataReady = true;
			}
			break;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001355 RID: 4949 RVA: 0x00220D5C File Offset: 0x0021EF5C
	public override void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.Ranking);
		StringManager.Instance.DeSpawnString(this.RankValue);
		StringManager.Instance.DeSpawnString(this.HintStr);
		for (int i = 0; i < this.SortTextArray.GetLength(0); i++)
		{
			for (int j = 0; j < this.SortTextArray.GetLength(1); j++)
			{
				StringManager.Instance.DeSpawnString(this.SortTextArray[i, j]);
			}
		}
		for (int k = 0; k < this.SPStrings.Length; k++)
		{
			StringManager.Instance.DeSpawnString(this.SPStrings[k]);
		}
		UILeaderBoard.ShowSP = false;
	}

	// Token: 0x06001356 RID: 4950 RVA: 0x00220E20 File Offset: 0x0021F020
	public void OnButtonDown(UIButtonHint sender)
	{
		if (this.OpenKind == UI_LeaderBoardOpenKind.MobilizationGroupBoard)
		{
			UIButton uibutton = sender.m_Button as UIButton;
			if (uibutton == null)
			{
				return;
			}
			int btnID = uibutton.m_BtnID1;
			if (btnID != 11)
			{
				if (btnID == 12)
				{
					uint id = 1028u - (uint)DataManager.Instance.RoleAlliance.AMRank;
					this.HintStr.ClearString();
					this.HintStr.Append(DataManager.Instance.mStringTable.GetStringByID(id));
					GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.HintStr, Vector2.zero);
				}
			}
			else
			{
				switch (uibutton.m_BtnID3)
				{
				case 1:
					this.HintStr.Append(DataManager.Instance.mStringTable.GetStringByID(3703u));
					break;
				case 2:
					this.HintStr.Append(DataManager.Instance.mStringTable.GetStringByID(3704u));
					break;
				case 3:
					this.HintStr.IntToFormat((long)uibutton.m_BtnID2, 1, false);
					this.HintStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3712u));
					break;
				case 4:
					this.HintStr.Append(DataManager.Instance.mStringTable.GetStringByID(17217u));
					break;
				case 5:
					this.HintStr.Append(DataManager.Instance.mStringTable.GetStringByID(17218u));
					break;
				}
				GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.HintStr, new Vector2(70f, -50f));
			}
			this.HintStr.ClearString();
		}
		if (this.OpenKind == UI_LeaderBoardOpenKind.MobilizationAlliBoard)
		{
			this.HintStr.ClearString();
			this.HintStr.Append(DataManager.Instance.mStringTable.GetStringByID(17253u));
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.HintStr, new Vector2(10f, -10f));
		}
	}

	// Token: 0x06001357 RID: 4951 RVA: 0x00221068 File Offset: 0x0021F268
	public void OnButtonUp(UIButtonHint sender)
	{
		if (this.OpenKind == UI_LeaderBoardOpenKind.MobilizationGroupBoard || this.OpenKind == UI_LeaderBoardOpenKind.MobilizationAlliBoard)
		{
			GUIManager.Instance.m_Hint.Hide(false);
		}
		else
		{
			GUIManager.Instance.m_Arena_Hint.Hide(sender);
		}
	}

	// Token: 0x06001358 RID: 4952 RVA: 0x002210A8 File Offset: 0x0021F2A8
	private void SetOpenType(UILeaderBoard.e_OpenType openType)
	{
		if (openType != UILeaderBoard.e_OpenType.BoardTypes)
		{
			if (openType == UILeaderBoard.e_OpenType.BoardContent)
			{
				this.AGS_Form.GetChild(6).gameObject.SetActive(false);
				this.AGS_Form.GetChild(7).gameObject.SetActive(true);
			}
		}
		else
		{
			this.AGS_Form.GetChild(6).gameObject.SetActive(true);
			this.AGS_Form.GetChild(7).gameObject.SetActive(false);
		}
	}

	// Token: 0x06001359 RID: 4953 RVA: 0x00221130 File Offset: 0x0021F330
	private void CreateAlliInterBoard()
	{
		this.MyRank = 0;
		if (UILeaderBoard.NewOpen)
		{
			UILeaderBoard.NewOpen = false;
			if (UILeaderBoard.SortedAlliInterList == null)
			{
				UILeaderBoard.SortedAlliInterList = new List<AllianceBoardData>();
			}
			UILeaderBoard.SortedAlliInterList.Clear();
			this.SPHeight.Clear();
			this.SPHeight.Add(38f);
			int num = Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
			ushort num2 = 0;
			while ((int)num2 < num)
			{
				if (DataManager.Instance.AllianceMember[(int)num2].UserId != 0L)
				{
					if (DataManager.Instance.RoleAttr.UserId == DataManager.Instance.AllianceMember[(int)num2].UserId)
					{
						this.MyRank = num2 + 1;
					}
					AllianceBoardData item = default(AllianceBoardData);
					item.Name = StringManager.Instance.SpawnString(30);
					item.Name.Append(DataManager.Instance.AllianceMember[(int)num2].Name);
					item.Power = DataManager.Instance.AllianceMember[(int)num2].Power;
					item.isMe = (DataManager.Instance.AllianceMember[(int)num2].UserId == DataManager.Instance.RoleAttr.UserId);
					UILeaderBoard.SortedAlliInterList.Add(item);
					this.SPHeight.Add(53f);
				}
				num2 += 1;
			}
			UILeaderBoard.SortedAlliInterList.Sort(new Comparison<AllianceBoardData>(UILeaderBoard.AlliInterPowerSort));
			ushort num3 = 0;
			while ((int)num3 < UILeaderBoard.SortedAlliInterList.Count)
			{
				if (UILeaderBoard.SortedAlliInterList[(int)num3].isMe)
				{
					this.MyRank = num3 + 1;
				}
				num3 += 1;
			}
			UILeaderBoard.SortedAlliInterList.Insert(0, UILeaderBoard.SortedAlliInterList[0]);
		}
		else
		{
			this.SPHeight.Clear();
			this.SPHeight.Add(38f);
			ushort num4 = 1;
			while ((int)num4 < UILeaderBoard.SortedAlliInterList.Count)
			{
				if (UILeaderBoard.SortedAlliInterList[(int)num4].isMe)
				{
					this.MyRank = num4;
				}
				this.SPHeight.Add(53f);
				num4 += 1;
			}
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID(7059u);
		this.AGS_Form.GetChild(3).gameObject.SetActive(true);
		Transform child = this.AGS_Form.GetChild(3).GetChild(0);
		child.gameObject.SetActive(true);
		GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, 11, 0, 0);
		component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
		this.Ranking.ClearString();
		this.Ranking.IntToFormat((long)this.MyRank, 1, false);
		this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7060u));
		component.text = this.Ranking.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
		this.RankValue.ClearString();
		this.RankValue.uLongToFormat(DataManager.Instance.RoleAttr.Power, 1, true);
		this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7061u));
		component.text = this.RankValue.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
	}

	// Token: 0x0600135A RID: 4954 RVA: 0x0022150C File Offset: 0x0021F70C
	private void CreateOtherAlliInterBoard()
	{
		if (UILeaderBoard.NewOpen)
		{
			UILeaderBoard.NewOpen = false;
			if (UILeaderBoard.SortedAlliInterList == null)
			{
				UILeaderBoard.SortedAlliInterList = new List<AllianceBoardData>();
			}
			UILeaderBoard.SortedAlliInterList.Clear();
			this.SPHeight.Clear();
			this.SPHeight.Add(38f);
			int num = Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
			ushort num2 = 0;
			while ((int)num2 < num)
			{
				AllianceBoardData item = default(AllianceBoardData);
				item.Name = StringManager.Instance.SpawnString(30);
				item.Name.Append(DataManager.Instance.AllianceMember[(int)num2].Name);
				item.Power = DataManager.Instance.AllianceMember[(int)num2].Power;
				item.isMe = false;
				UILeaderBoard.SortedAlliInterList.Add(item);
				this.SPHeight.Add(53f);
				num2 += 1;
			}
			UILeaderBoard.SortedAlliInterList.Sort(new Comparison<AllianceBoardData>(UILeaderBoard.AlliInterPowerSort));
			UILeaderBoard.SortedAlliInterList.Insert(0, UILeaderBoard.SortedAlliInterList[0]);
		}
		else
		{
			this.SPHeight.Clear();
			this.SPHeight.Add(38f);
			ushort num3 = 1;
			while ((int)num3 < UILeaderBoard.SortedAlliInterList.Count)
			{
				this.SPHeight.Add(53f);
				num3 += 1;
			}
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID(7059u);
		this.AGS_Form.GetChild(2).gameObject.SetActive(true);
		this.AGS_Form.GetChild(5).gameObject.SetActive(true);
		component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
		this.Ranking.ClearString();
		this.Ranking.StringToFormat(DataManager.Instance.AllianceView.Tag);
		this.Ranking.StringToFormat(DataManager.Instance.AllianceView.Name);
		this.Ranking.AppendFormat("[{0}]{1}");
		component.text = this.Ranking.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
	}

	// Token: 0x0600135B RID: 4955 RVA: 0x00221768 File Offset: 0x0021F968
	private void CreateMobilizationGroupBoard()
	{
		this.SPHeight.Clear();
		this.SPHeight.Add(38f);
		int num = Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
		ushort num2 = 0;
		while ((int)num2 < LeaderBoardManager.Instance.MobiGroupBoard.Count)
		{
			this.SPHeight.Add(53f);
			num2 += 1;
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID(7091u);
		this.AGS_Form.GetChild(2).gameObject.SetActive(true);
		this.AGS_Form.GetChild(5).gameObject.SetActive(true);
		component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
		this.Ranking.ClearString();
		this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.MobiGroupRank, 1, false);
		this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9856u));
		component.text = this.Ranking.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		this.AGS_Form.GetChild(11).gameObject.SetActive(true);
	}

	// Token: 0x0600135C RID: 4956 RVA: 0x002218C4 File Offset: 0x0021FAC4
	private void CreateMobilizationAlliBoard()
	{
		this.SPHeight.Clear();
		this.SPHeight.Add(38f);
		int num = Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
		ushort num2 = 0;
		while ((int)num2 < LeaderBoardManager.Instance.MobiAlliBoard.Count)
		{
			this.SPHeight.Add(53f);
			num2 += 1;
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID(1362u);
		this.AGS_Form.GetChild(2).gameObject.SetActive(true);
		this.AGS_Form.GetChild(5).gameObject.SetActive(false);
		this.AGS_Form.GetChild(3).gameObject.SetActive(true);
		this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
		this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(false);
		Transform child = this.AGS_Form.GetChild(3).GetChild(0);
		child.gameObject.SetActive(true);
		GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, 11, 0, 0);
		component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
		this.Ranking.ClearString();
		this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.MobiAlliRank, 1, false);
		this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7060u));
		component.text = this.Ranking.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
		this.RankValue.ClearString();
		this.RankValue.IntToFormat((long)LeaderBoardManager.Instance.MobiAlliBoard[LeaderBoardManager.Instance.MobiAlliRank - 1].Score, 1, false);
		this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8121u));
		component.text = this.RankValue.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
	}

	// Token: 0x0600135D RID: 4957 RVA: 0x00221B30 File Offset: 0x0021FD30
	private void CreateWorldKingHistoryBoard()
	{
		UILeaderBoard.NewOpen = false;
		this.SPHeight.Clear();
		this.SPHeight.Add(38f);
		ushort num = 0;
		while ((int)num < LeaderBoardManager.Instance.MobiWorldKingBoard.Count)
		{
			this.SPHeight.Add(53f);
			num += 1;
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID(11030u);
		this.AGS_Form.GetChild(2).gameObject.SetActive(true);
		this.AGS_Form.GetChild(5).gameObject.SetActive(false);
		this.AGS_Form.GetChild(3).gameObject.SetActive(true);
		this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
		this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(false);
		this.SetHiBtnAndText();
		component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID(11010u);
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		this.AGS_Form.GetChild(9).gameObject.SetActive(true);
		if (LeaderBoardManager.Instance.MobiWorldKingBoard.Count <= 0)
		{
			this.AGS_Form.GetChild(13).gameObject.SetActive(true);
		}
		else
		{
			this.AGS_Form.GetChild(13).gameObject.SetActive(false);
		}
	}

	// Token: 0x0600135E RID: 4958 RVA: 0x00221CEC File Offset: 0x0021FEEC
	private void CreateKingofWorldRankingBoard()
	{
		UILeaderBoard.NewOpen = false;
		this.SPHeight.Clear();
		this.SPHeight.Add(38f);
		int num = Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
		ushort num2 = 0;
		while ((int)num2 < LeaderBoardManager.Instance.KingofWorldBoard.Count)
		{
			if (LeaderBoardManager.Instance.KingofWorldBoard[(int)num2].HomeKingdomID <= 0)
			{
				break;
			}
			this.SPHeight.Add(53f);
			num2 += 1;
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID(10016u);
		this.AGS_Form.GetChild(2).gameObject.SetActive(true);
		this.AGS_Form.GetChild(5).gameObject.SetActive(false);
		this.AGS_Form.GetChild(3).gameObject.SetActive(true);
		this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
		this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(false);
		Transform child = this.AGS_Form.GetChild(3).GetChild(0);
		child.gameObject.SetActive(true);
		GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, LeaderBoardManager.Instance.KingofWorldHead, 11, 0, 0);
		component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
		this.Ranking.ClearString();
		this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(11010u));
		component.text = this.Ranking.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
		this.RankValue.ClearString();
		if (LeaderBoardManager.Instance.KingofWorldBoard.Count > 0)
		{
			GameConstants.GetNameString(this.RankValue, LeaderBoardManager.Instance.KingofWorldBoard[0].HomeKingdomID, LeaderBoardManager.Instance.KingofWorldBoard[0].Name, LeaderBoardManager.Instance.KingofWorldBoard[0].AllianceTag, true);
		}
		component.text = this.RankValue.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
	}

	// Token: 0x0600135F RID: 4959 RVA: 0x00221F78 File Offset: 0x00220178
	private static int AlliInterPowerSort(AllianceBoardData x, AllianceBoardData y)
	{
		if (x.Power > y.Power)
		{
			return -1;
		}
		if (x.Power < y.Power)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06001360 RID: 4960 RVA: 0x00221FA8 File Offset: 0x002201A8
	public void UpdatRow_Alli(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (dataIdx == 0)
		{
			item.transform.GetChild(0).gameObject.SetActive(true);
			item.transform.GetChild(1).gameObject.SetActive(false);
			UIText component = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(7063u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(7064u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
			item.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);
			this.SortTextArray[0, panelObjectIdx].ClearString();
			this.SortTextArray[0, panelObjectIdx].IntToFormat((long)dataIdx, 1, false);
			this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
			UIText component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
			component.text = this.SortTextArray[0, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[1, panelObjectIdx].ClearString();
			this.SortTextArray[1, panelObjectIdx].Append(UILeaderBoard.SortedAlliInterList[dataIdx].Name);
			component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
			component.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			this.SortTextArray[2, panelObjectIdx].uLongToFormat(UILeaderBoard.SortedAlliInterList[dataIdx].Power, 1, true);
			this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
			component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
			component.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			UIButton component2 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 1;
			component2.m_BtnID2 = dataIdx;
			if (dataIdx == (int)this.MyRank)
			{
				UISpritesArray component3 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(2);
				component3 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(2);
				component3 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(2);
			}
			else if (dataIdx % 2 == 0)
			{
				UISpritesArray component3 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(1);
				component3 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(1);
				component3 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(1);
			}
			else
			{
				UISpritesArray component3 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(0);
				component3 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(0);
				component3 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(0);
			}
		}
	}

	// Token: 0x06001361 RID: 4961 RVA: 0x00222410 File Offset: 0x00220610
	public void UpdatRow_MobiGroup(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (dataIdx == 0)
		{
			item.transform.GetChild(0).gameObject.SetActive(true);
			item.transform.GetChild(1).gameObject.SetActive(false);
			UIText component = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(1364u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(4612u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(7).GetComponent<UIText>();
			component.gameObject.SetActive(true);
			component.text = DataManager.Instance.mStringTable.GetStringByID(9857u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
			this.SortTextArray[0, panelObjectIdx].ClearString();
			this.SortTextArray[0, panelObjectIdx].IntToFormat((long)dataIdx, 1, false);
			this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
			UIText component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
			component.text = this.SortTextArray[0, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[1, panelObjectIdx].ClearString();
			GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], 0, LeaderBoardManager.Instance.MobiGroupBoard[dataIdx - 1].Name, LeaderBoardManager.Instance.MobiGroupBoard[dataIdx - 1].AllianceTag, false);
			component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
			component.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			this.SortTextArray[2, panelObjectIdx].uLongToFormat((ulong)LeaderBoardManager.Instance.MobiGroupBoard[dataIdx - 1].Score, 1, true);
			this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
			component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
			component.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			UIButton component2 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 6;
			component2.m_BtnID2 = dataIdx - 1;
			this.SortTextArray[3, panelObjectIdx].ClearString();
			this.SortTextArray[3, panelObjectIdx].IntToFormat((long)Math.Abs(LeaderBoardManager.Instance.MobiGroupBoard[dataIdx - 1].ChangeRank), 1, true);
			this.SortTextArray[3, panelObjectIdx].AppendFormat("{0}");
			component = item.transform.GetChild(1).GetChild(9).GetComponent<UIText>();
			component.text = this.SortTextArray[3, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			UISpritesArray component3 = item.transform.GetChild(1).GetChild(8).GetComponent<UISpritesArray>();
			if (LeaderBoardManager.Instance.MobiGroupBoard[dataIdx - 1].ChangeRank > 0)
			{
				component3.SetSpriteIndex(0);
				component3.gameObject.SetActive(true);
				component.gameObject.SetActive(true);
			}
			else if (LeaderBoardManager.Instance.MobiGroupBoard[dataIdx - 1].ChangeRank < 0)
			{
				component3.SetSpriteIndex(1);
				component3.gameObject.SetActive(true);
				component.gameObject.SetActive(true);
			}
			else
			{
				component3.gameObject.SetActive(false);
				component.gameObject.SetActive(false);
			}
			if (dataIdx == LeaderBoardManager.Instance.MobiGroupRank)
			{
				component3 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(2);
				component3 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(2);
				component3 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(2);
				component3 = item.transform.GetChild(1).GetChild(3).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(2);
			}
			else if (dataIdx % 2 == 0)
			{
				component3 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(1);
				component3 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(1);
				component3 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(1);
				component3 = item.transform.GetChild(1).GetChild(3).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(1);
			}
			else
			{
				component3 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(0);
				component3 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(0);
				component3 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(0);
				component3 = item.transform.GetChild(1).GetChild(3).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(0);
			}
			component2 = item.transform.GetChild(1).GetChild(12).GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 11;
			component2.m_BtnID2 = dataIdx;
			component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
			if (DataManager.Instance.RoleAlliance.AMRank == 4)
			{
				if (dataIdx > 14)
				{
					component2.m_BtnID3 = 5;
					component.color = new Color32(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				}
				else
				{
					component2.m_BtnID3 = 3;
					component.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				}
			}
			else if (DataManager.Instance.RoleAlliance.AMRank == 3)
			{
				if (dataIdx < 4)
				{
					component2.m_BtnID3 = 4;
					component.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
				}
				else if (dataIdx > 15)
				{
					component2.m_BtnID3 = 2;
					component.color = new Color32(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				}
				else
				{
					component2.m_BtnID3 = 3;
					component.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
				}
			}
			else if (dataIdx < 6 && DataManager.Instance.RoleAlliance.AMRank < 3)
			{
				component2.m_BtnID3 = 1;
				component.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
			}
			else if (dataIdx > 15 && DataManager.Instance.RoleAlliance.AMRank != 0)
			{
				component2.m_BtnID3 = 2;
				component.color = new Color32(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
			else
			{
				component2.m_BtnID3 = 3;
				component.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
			UIButtonHint component4 = item.transform.GetChild(1).GetChild(12).GetComponent<UIButtonHint>();
			component4.Parm1 = (ushort)dataIdx;
			component4.m_eHint = EUIButtonHint.DownUpHandler;
			component4.m_Handler = this;
			component4.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
		}
	}

	// Token: 0x06001362 RID: 4962 RVA: 0x00222CEC File Offset: 0x00220EEC
	public void UpdatRow_MobiAlli(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (dataIdx == 0)
		{
			item.transform.GetChild(0).gameObject.SetActive(true);
			item.transform.GetChild(1).gameObject.SetActive(false);
			UIText component = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(4717u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(9858u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(7).GetComponent<UIText>();
			component.gameObject.SetActive(true);
			component.text = DataManager.Instance.mStringTable.GetStringByID(1363u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
			this.SortTextArray[0, panelObjectIdx].ClearString();
			this.SortTextArray[0, panelObjectIdx].IntToFormat((long)dataIdx, 1, false);
			this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
			UIText component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
			component.text = this.SortTextArray[0, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[1, panelObjectIdx].ClearString();
			this.SortTextArray[1, panelObjectIdx].Append(LeaderBoardManager.Instance.MobiAlliBoard[dataIdx - 1].Name);
			component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
			component.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
			UIButton component2 = item.transform.GetChild(1).GetChild(12).GetComponent<UIButton>();
			component2.m_BtnID1 = 13;
			component2.m_Handler = this;
			UIButtonHint component3 = component2.transform.GetComponent<UIButtonHint>();
			component3.m_Handler = this;
			if (LeaderBoardManager.Instance.MobiAlliBoard[dataIdx - 1].finishBonus)
			{
				component2.gameObject.SetActive(true);
				component.color = new Color32(81, 227, 105, byte.MaxValue);
			}
			else
			{
				component2.gameObject.SetActive(false);
				component.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
			this.SortTextArray[2, panelObjectIdx].ClearString();
			this.SortTextArray[2, panelObjectIdx].uLongToFormat((ulong)LeaderBoardManager.Instance.MobiAlliBoard[dataIdx - 1].Score, 1, true);
			this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
			component.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component.alignment = TextAnchor.MiddleCenter;
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[3, panelObjectIdx].ClearString();
			this.SortTextArray[3, panelObjectIdx].IntToFormat((long)Math.Abs((short)LeaderBoardManager.Instance.MobiAlliBoard[dataIdx - 1].FinishedMission), 1, true);
			this.SortTextArray[3, panelObjectIdx].IntToFormat((long)Math.Abs((short)LeaderBoardManager.Instance.MobiAlliBoard[dataIdx - 1].AquiredMission), 1, true);
			if (!GUIManager.Instance.IsArabic)
			{
				this.SortTextArray[3, panelObjectIdx].AppendFormat("{0} / {1}");
			}
			else
			{
				this.SortTextArray[3, panelObjectIdx].AppendFormat("{1} / {0}");
			}
			component = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
			component.text = this.SortTextArray[3, panelObjectIdx].ToString();
			component.alignment = TextAnchor.MiddleCenter;
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			if (dataIdx == LeaderBoardManager.Instance.MobiAlliRank)
			{
				UISpritesArray component4 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(2);
				component4 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(2);
				component4 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(2);
				component4 = item.transform.GetChild(1).GetChild(3).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(2);
			}
			else if (dataIdx % 2 == 0)
			{
				UISpritesArray component4 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(1);
				component4 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(1);
				component4 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(1);
				component4 = item.transform.GetChild(1).GetChild(3).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(1);
			}
			else
			{
				UISpritesArray component4 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(0);
				component4 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(0);
				component4 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(0);
				component4 = item.transform.GetChild(1).GetChild(3).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(0);
			}
		}
	}

	// Token: 0x06001363 RID: 4963 RVA: 0x00223380 File Offset: 0x00221580
	public void UpdatRow_MobilizationWorldKing(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (dataIdx == 0)
		{
			item.transform.GetChild(0).gameObject.SetActive(true);
			item.transform.GetChild(1).gameObject.SetActive(false);
			UIText component = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(7063u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(11011u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(11012u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			if (dataIdx > 0 && dataIdx <= LeaderBoardManager.Instance.MobiWorldKingBoard.Count)
			{
				item.transform.GetChild(0).gameObject.SetActive(false);
				item.transform.GetChild(1).gameObject.SetActive(true);
				item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
				item.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);
				this.SortTextArray[0, panelObjectIdx].ClearString();
				GameConstants.FormatRoleName(this.SortTextArray[0, panelObjectIdx], LeaderBoardManager.Instance.MobiWorldKingBoard[dataIdx - 1].Name, LeaderBoardManager.Instance.MobiWorldKingBoard[dataIdx - 1].AllianceTag, null, 0, LeaderBoardManager.Instance.MobiWorldKingBoard[dataIdx - 1].HomeKingdomID, null, null, null, null);
				UIText component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
				component.text = this.SortTextArray[0, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.SortTextArray[1, panelObjectIdx].ClearString();
				GameConstants.GetTimeString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.MobiWorldKingBoard[dataIdx - 1].OccupyTime, false, false, true, false, true);
				component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.SortTextArray[2, panelObjectIdx].ClearString();
				DateTime dateTime = GameConstants.GetDateTime(LeaderBoardManager.Instance.MobiWorldKingBoard[dataIdx - 1].TakeOfficeTime);
				this.SortTextArray[2, panelObjectIdx].StringToFormat(dateTime.ToString("MM/dd/yy"));
				this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
				component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
				component.text = this.SortTextArray[2, panelObjectIdx].ToString();
				component.alignment = TextAnchor.MiddleCenter;
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				UIButton component2 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
				component2.m_Handler = this;
				component2.m_BtnID1 = 8;
				component2.m_BtnID2 = dataIdx - 1;
			}
			if (dataIdx % 2 == 0)
			{
				UISpritesArray component3 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(1);
				component3 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(1);
				component3 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(1);
				component3 = item.transform.GetChild(1).GetChild(3).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(1);
			}
			else
			{
				UISpritesArray component3 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(0);
				component3 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(0);
				component3 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(0);
				component3 = item.transform.GetChild(1).GetChild(3).GetComponent<UISpritesArray>();
				component3.SetSpriteIndex(0);
			}
		}
	}

	// Token: 0x06001364 RID: 4964 RVA: 0x0022382C File Offset: 0x00221A2C
	public void UpdatRow_KingofWorld(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (dataIdx == 0)
		{
			item.transform.GetChild(0).gameObject.SetActive(true);
			item.transform.GetChild(1).gameObject.SetActive(false);
			UIText component = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(4717u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(11011u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
			item.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);
			this.SortTextArray[0, panelObjectIdx].ClearString();
			this.SortTextArray[0, panelObjectIdx].IntToFormat((long)dataIdx, 1, false);
			this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
			UIText component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
			component.text = this.SortTextArray[0, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[1, panelObjectIdx].ClearString();
			GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.KingofWorldBoard[dataIdx - 1].HomeKingdomID, LeaderBoardManager.Instance.KingofWorldBoard[dataIdx - 1].Name, LeaderBoardManager.Instance.KingofWorldBoard[dataIdx - 1].AllianceTag, true);
			component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
			component.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			GameConstants.GetTimeString(this.SortTextArray[2, panelObjectIdx], LeaderBoardManager.Instance.KingofWorldBoard[dataIdx - 1].OccupyTime, false, false, true, false, true);
			component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
			component.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component.alignment = TextAnchor.MiddleCenter;
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			if (dataIdx % 2 == 0)
			{
				UISpritesArray component2 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(1);
				component2 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(1);
				component2 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(1);
			}
			else
			{
				UISpritesArray component2 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(0);
				component2 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(0);
				component2 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(0);
			}
			UIButton component3 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = 10;
			component3.m_BtnID2 = dataIdx - 1;
		}
	}

	// Token: 0x06001365 RID: 4965 RVA: 0x00223C54 File Offset: 0x00221E54
	public void CreateTopBoard()
	{
		this.SPHeight.Clear();
		this.SPHeight.Add(118f);
		this.SPHeight.Add(118f);
		this.AGS_Form.GetChild(3).gameObject.SetActive(false);
		RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(8, 0);
		if (this.OpenKind != UI_LeaderBoardOpenKind.BoardMenu)
		{
			this.AGS_Form.GetChild(12).gameObject.SetActive(false);
		}
		else
		{
			this.AGS_Form.GetChild(12).gameObject.SetActive(true);
			this.AGS_Form.GetChild(12).GetComponent<UISpritesArray>().SetSpriteIndex(0);
		}
		UILeaderBoard.isTopBoard = true;
		if (UILeaderBoard.isPersonBoard)
		{
			this.SPHeight.Add(118f);
			UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(7089u);
			this.AGS_Form.GetChild(2).gameObject.SetActive(true);
			this.AGS_Form.GetChild(5).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(7090u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.POPLight1.gameObject.SetActive(true);
			this.POPLight3.gameObject.SetActive(false);
		}
		else
		{
			UIText component2 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
			component2.text = DataManager.Instance.mStringTable.GetStringByID(7091u);
			this.AGS_Form.GetChild(2).gameObject.SetActive(true);
			this.AGS_Form.GetChild(5).gameObject.SetActive(true);
			component2 = this.AGS_Form.GetChild(5).GetComponent<UIText>();
			component2.text = DataManager.Instance.mStringTable.GetStringByID(7090u);
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			this.POPLight1.gameObject.SetActive(false);
			this.POPLight3.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001366 RID: 4966 RVA: 0x00223EB4 File Offset: 0x002220B4
	public void CreateSubBoard()
	{
		this.AGS_Form.GetChild(5).gameObject.SetActive(false);
		this.AGS_Form.GetChild(12).gameObject.SetActive(false);
		this.SPHeight.Clear();
		this.SPHeight.Add(38f);
		if (UILeaderBoard.SubBoardID == 4)
		{
			for (int i = 0; i < LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID].Count; i++)
			{
				this.SPHeight.Add(53f);
			}
		}
		else
		{
			for (int j = 0; j < LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID].Count; j++)
			{
				if (LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][j].Value > 0UL)
				{
					this.SPHeight.Add(53f);
				}
			}
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		if (UILeaderBoard.isPersonBoard)
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(7089u);
		}
		else
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(7091u);
		}
		this.AGS_Form.GetChild(3).gameObject.SetActive(true);
		if (UILeaderBoard.isPersonBoard)
		{
			this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
			this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(false);
			Transform child = this.AGS_Form.GetChild(3).GetChild(0);
			child.gameObject.SetActive(true);
			GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, 11, 0, 0);
		}
		else
		{
			this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(true);
			Transform child = this.AGS_Form.GetChild(3).GetChild(1);
			GUIManager.Instance.SetBadgeTotemImg(child, DataManager.Instance.RoleAlliance.Emblem);
		}
		if (UILeaderBoard.isPersonBoard)
		{
			this.Ranking.ClearString();
			if (LeaderBoardManager.Instance.MyRank[(int)UILeaderBoard.SubBoardID] != 0)
			{
				component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
				this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.MyRank[(int)UILeaderBoard.SubBoardID], 1, true);
				this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7060u));
			}
			else if (UILeaderBoard.SubBoardID == 4 && ArenaManager.Instance.m_ArenaHistoryPlace != 0u)
			{
				component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
				this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8414u));
			}
			else
			{
				this.AGS_Form.GetChild(3).gameObject.SetActive(false);
				this.AGS_Form.GetChild(5).gameObject.SetActive(true);
				component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
				this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8414u));
			}
			component.text = this.Ranking.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else if (DataManager.Instance.RoleAlliance.Id != 0u)
		{
			this.AGS_Form.GetChild(3).gameObject.SetActive(false);
			this.AGS_Form.GetChild(5).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
			this.Ranking.ClearString();
			if (LeaderBoardManager.Instance.MyRank[(int)UILeaderBoard.SubBoardID] != 0)
			{
				this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.MyRank[(int)UILeaderBoard.SubBoardID], 1, false);
				this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7092u));
			}
			else
			{
				this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8414u));
			}
			component.text = this.Ranking.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.AGS_Form.GetChild(3).gameObject.SetActive(false);
			this.AGS_Form.GetChild(5).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(7095u);
		}
		switch (UILeaderBoard.SubBoardID)
		{
		case 0:
			component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
			this.RankValue.ClearString();
			this.RankValue.uLongToFormat(DataManager.Instance.RoleAttr.Power, 1, true);
			this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7061u));
			component.text = this.RankValue.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			break;
		case 1:
			component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
			this.RankValue.ClearString();
			this.RankValue.uLongToFormat(DataManager.Instance.RoleAttr.Kills, 1, true);
			this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8415u));
			component.text = this.RankValue.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			break;
		case 4:
			component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
			this.RankValue.ClearString();
			this.RankValue.Append(DataManager.Instance.mStringTable.GetStringByID(9126u));
			this.RankValue.uLongToFormat((ulong)ArenaManager.Instance.m_ArenaHistoryPlace, 1, true);
			this.RankValue.AppendFormat("{0}");
			component.text = this.RankValue.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			break;
		case 7:
			if (LeaderBoardManager.Instance.MyRank[(int)UILeaderBoard.SubBoardID] != 0)
			{
				component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
				this.RankValue.ClearString();
				this.RankValue.uLongToFormat(LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][(int)(LeaderBoardManager.Instance.MyRank[(int)UILeaderBoard.SubBoardID] - 1)].Value, 1, true);
				this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8121u));
				component.text = this.RankValue.ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
			}
			break;
		}
		if (UILeaderBoard.isPersonBoard)
		{
			this.POPLight1.gameObject.SetActive(true);
			this.POPLight3.gameObject.SetActive(false);
		}
		else
		{
			this.POPLight1.gameObject.SetActive(false);
			this.POPLight3.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001367 RID: 4967 RVA: 0x002246A4 File Offset: 0x002228A4
	public void CreateWorldRankingTopBoard()
	{
		this.SPHeight.Clear();
		this.SPHeight.Add(118f);
		this.SPHeight.Add(118f);
		this.AGS_Form.GetChild(3).gameObject.SetActive(false);
		this.AGS_Form.GetChild(12).gameObject.SetActive(true);
		this.AGS_Form.GetChild(12).GetComponent<UISpritesArray>().SetSpriteIndex(1);
		UILeaderBoard.isTopBoard = true;
		if (UILeaderBoard.isPersonBoard)
		{
			UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(9581u);
			this.AGS_Form.GetChild(2).gameObject.SetActive(true);
			this.AGS_Form.GetChild(5).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(9574u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.POPLight1.gameObject.SetActive(true);
			this.POPLight3.gameObject.SetActive(false);
		}
		else
		{
			UIText component2 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
			component2.text = DataManager.Instance.mStringTable.GetStringByID(9582u);
			this.AGS_Form.GetChild(2).gameObject.SetActive(true);
			this.AGS_Form.GetChild(5).gameObject.SetActive(true);
			component2 = this.AGS_Form.GetChild(5).GetComponent<UIText>();
			component2.text = DataManager.Instance.mStringTable.GetStringByID(9574u);
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			this.POPLight1.gameObject.SetActive(false);
			this.POPLight3.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001368 RID: 4968 RVA: 0x002248B8 File Offset: 0x00222AB8
	public void CreateWorldRankingSubBoard()
	{
		this.AGS_Form.GetChild(5).gameObject.SetActive(false);
		this.AGS_Form.GetChild(12).gameObject.SetActive(false);
		this.SPHeight.Clear();
		this.SPHeight.Add(38f);
		for (int i = 0; i < LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID].Count; i++)
		{
			if (LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][i].Value > 0UL)
			{
				this.SPHeight.Add(53f);
			}
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		if (UILeaderBoard.isPersonBoard)
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(9581u);
		}
		else
		{
			component.text = DataManager.Instance.mStringTable.GetStringByID(9582u);
		}
		this.AGS_Form.GetChild(3).gameObject.SetActive(true);
		if (UILeaderBoard.isPersonBoard)
		{
			this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
			this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(false);
			Transform child = this.AGS_Form.GetChild(3).GetChild(0);
			child.gameObject.SetActive(true);
			GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, 11, 0, 0);
		}
		else
		{
			this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(true);
			Transform child = this.AGS_Form.GetChild(3).GetChild(1);
			GUIManager.Instance.SetBadgeTotemImg(child, DataManager.Instance.RoleAlliance.Emblem);
		}
		if (UILeaderBoard.isPersonBoard)
		{
			this.Ranking.ClearString();
			if (LeaderBoardManager.Instance.MyRank[(int)UILeaderBoard.SubBoardID] != 0)
			{
				component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
				this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.MyRank[(int)UILeaderBoard.SubBoardID], 1, true);
				this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7060u));
			}
			else
			{
				this.AGS_Form.GetChild(3).gameObject.SetActive(false);
				this.AGS_Form.GetChild(5).gameObject.SetActive(true);
				component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
				this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8414u));
			}
			component.text = this.Ranking.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else if (DataManager.Instance.RoleAlliance.Id != 0u)
		{
			this.AGS_Form.GetChild(3).gameObject.SetActive(false);
			this.AGS_Form.GetChild(5).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
			this.Ranking.ClearString();
			if (LeaderBoardManager.Instance.MyRank[(int)UILeaderBoard.SubBoardID] != 0)
			{
				this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.MyRank[(int)UILeaderBoard.SubBoardID], 1, false);
				this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7092u));
			}
			else
			{
				this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8414u));
			}
			component.text = this.Ranking.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.AGS_Form.GetChild(3).gameObject.SetActive(false);
			this.AGS_Form.GetChild(5).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(7095u);
		}
		byte subBoardID = UILeaderBoard.SubBoardID;
		if (subBoardID != 8)
		{
			if (subBoardID == 9)
			{
				component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
				this.RankValue.ClearString();
				this.RankValue.uLongToFormat(DataManager.Instance.RoleAttr.Kills, 1, true);
				this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8415u));
				component.text = this.RankValue.ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
			}
		}
		else
		{
			component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
			this.RankValue.ClearString();
			this.RankValue.uLongToFormat(DataManager.Instance.RoleAttr.Power, 1, true);
			this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7061u));
			component.text = this.RankValue.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		if (UILeaderBoard.isPersonBoard)
		{
			this.POPLight1.gameObject.SetActive(true);
			this.POPLight3.gameObject.SetActive(false);
		}
		else
		{
			this.POPLight1.gameObject.SetActive(false);
			this.POPLight3.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001369 RID: 4969 RVA: 0x00224EA4 File Offset: 0x002230A4
	private void MainBoardChange()
	{
		if (this.OpenKind == UI_LeaderBoardOpenKind.BoardMenu && LeaderBoardManager.Instance.TopBoard.SortTime + 600L < DataManager.Instance.ServerTime)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_LEADERBOARDS_CLIENT;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			UILeaderBoard.isTopBoard = true;
			return;
		}
		this.CreateTopBoard();
		this.SetOpenType(UILeaderBoard.e_OpenType.BoardTypes);
		this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false, true);
		this.AGS_Panel1.GoTo(0);
	}

	// Token: 0x0600136A RID: 4970 RVA: 0x00224F3C File Offset: 0x0022313C
	private void SubBoardChange(byte newSubID)
	{
		UILeaderBoard.SubBoardID = newSubID;
		UILeaderBoard.isTopBoard = false;
		if (UILeaderBoard.SubBoardID < 5 && LeaderBoardManager.Instance.BoardUpdateTime[(int)UILeaderBoard.SubBoardID] + 600L < DataManager.Instance.ServerTime)
		{
			UILeaderBoard.TopIndex[(int)UILeaderBoard.SubBoardID] = 0;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.AddSeqId();
			messagePacket.Protocol = Protocol._MSG_REQUEST_LEADERBOARD_CONTENT;
			ushort data;
			byte data2;
			GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out data, out data2);
			messagePacket.Add(data);
			messagePacket.Add(data2);
			messagePacket.Add(UILeaderBoard.SubBoardID);
			byte data3 = 0;
			messagePacket.Add(data3);
			long data4 = 0L;
			messagePacket.Add(data4);
			messagePacket.Send(false);
		}
		else if (UILeaderBoard.SubBoardID >= 5 && LeaderBoardManager.Instance.BoardUpdateTime[(int)UILeaderBoard.SubBoardID] < DataManager.Instance.ServerTime)
		{
			UILeaderBoard.TopIndex[(int)UILeaderBoard.SubBoardID] = 0;
			MessagePacket messagePacket2 = new MessagePacket(1024);
			messagePacket2.AddSeqId();
			messagePacket2.Protocol = Protocol._MSG_REQUEST_LEADERBOARD_CONTENT;
			ushort data5;
			byte data6;
			GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out data5, out data6);
			messagePacket2.Add(data5);
			messagePacket2.Add(data6);
			messagePacket2.Add(UILeaderBoard.SubBoardID);
			byte data7 = 0;
			messagePacket2.Add(data7);
			messagePacket2.Add(LeaderBoardManager.Instance.KvKTopBoard.SortTime);
			if (UILeaderBoard.SubBoardID == 6)
			{
				messagePacket2.Add(DataManager.Instance.RoleAlliance.Id);
			}
			messagePacket2.Send(false);
		}
		else
		{
			this.CreateSubBoard();
			this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
			this.AGS_Panel2.AddNewDataHeight(this.SPHeight, true, true);
			this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[(int)UILeaderBoard.SubBoardID]);
		}
	}

	// Token: 0x0600136B RID: 4971 RVA: 0x00225114 File Offset: 0x00223314
	private void WorldRankingMainBoardChange()
	{
		if (UILeaderBoard.WorldBoard && LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.SortTime + 600L < DataManager.Instance.ServerTime)
		{
			UILeaderBoard.TopIndex[(int)UILeaderBoard.SubBoardID] = 0;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_WORLDRANKING_LEADERBOARDS_CLIENT;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			UILeaderBoard.isTopBoard = true;
			return;
		}
		this.CreateWorldRankingTopBoard();
		this.SetOpenType(UILeaderBoard.e_OpenType.BoardTypes);
		this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false, true);
		this.AGS_Panel1.GoTo(UILeaderBoard.TopIndex[(int)UILeaderBoard.SubBoardID]);
	}

	// Token: 0x0600136C RID: 4972 RVA: 0x002251C0 File Offset: 0x002233C0
	private void WorldRankingSubBoardChange(byte newSubID)
	{
		UILeaderBoard.SubBoardID = newSubID;
		UILeaderBoard.isTopBoard = false;
		if (LeaderBoardManager.Instance.BoardUpdateTime[(int)UILeaderBoard.SubBoardID] + 600L < DataManager.Instance.ServerTime)
		{
			UILeaderBoard.TopIndex[(int)UILeaderBoard.SubBoardID] = 0;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.AddSeqId();
			messagePacket.Protocol = Protocol._MSG_REQUEST_LEADERBOARD_CONTENT;
			ushort data;
			byte data2;
			GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out data, out data2);
			messagePacket.Add(data);
			messagePacket.Add(data2);
			messagePacket.Add(UILeaderBoard.SubBoardID);
			byte data3 = 0;
			messagePacket.Add(data3);
			long data4 = 0L;
			messagePacket.Add(data4);
			messagePacket.Send(false);
		}
		else
		{
			this.CreateWorldRankingSubBoard();
			this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
			this.AGS_Panel2.AddNewDataHeight(this.SPHeight, true, true);
			this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[(int)UILeaderBoard.SubBoardID]);
		}
	}

	// Token: 0x0600136D RID: 4973 RVA: 0x002252B0 File Offset: 0x002234B0
	public void UpdateRow_FunctionList(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (UILeaderBoard.isPersonBoard)
		{
			switch (dataIdx)
			{
			case 0:
			{
				item.transform.GetChild(2).gameObject.SetActive(false);
				item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.TopBoard.PowerTop.Value != 0UL);
				if (item.transform.GetChild(3).childCount < 1)
				{
					GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.TopBoard.PowerTopHead, 11, 0, 0, false, false, true, false);
				}
				else
				{
					GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.TopBoard.PowerTopHead, 11, 0, 0);
				}
				UIText component = item.transform.GetChild(4).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(7064u);
				this.SortTextArray[1, panelObjectIdx].ClearString();
				if (LeaderBoardManager.Instance.TopBoard.PowerTop.Value == 0UL)
				{
					this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475u));
				}
				else
				{
					GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], 0, LeaderBoardManager.Instance.TopBoard.PowerTop.Name, LeaderBoardManager.Instance.TopBoard.PowerTop.AlliaceTag, false);
				}
				component = item.transform.GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.SortTextArray[2, panelObjectIdx].ClearString();
				this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.TopBoard.PowerTop.Value, 1, true);
				this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
				component = item.transform.GetChild(6).GetComponent<UIText>();
				component.text = this.SortTextArray[2, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				UIButton component2 = item.transform.GetChild(1).GetComponent<UIButton>();
				component2.m_Handler = this;
				component2.m_BtnID1 = 3;
				component2.m_BtnID2 = 0;
				break;
			}
			case 1:
			{
				item.transform.GetChild(2).gameObject.SetActive(false);
				item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.TopBoard.KillsTop.Value != 0UL);
				if (item.transform.GetChild(3).childCount < 1)
				{
					GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.TopBoard.KillTopHead, 11, 0, 0, false, false, true, false);
				}
				else
				{
					GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.TopBoard.KillTopHead, 11, 0, 0);
				}
				UIText component = item.transform.GetChild(4).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(7312u);
				this.SortTextArray[1, panelObjectIdx].ClearString();
				if (LeaderBoardManager.Instance.TopBoard.KillsTop.Value == 0UL)
				{
					this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475u));
				}
				else
				{
					GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], 0, LeaderBoardManager.Instance.TopBoard.KillsTop.Name, LeaderBoardManager.Instance.TopBoard.KillsTop.AlliaceTag, false);
				}
				component = item.transform.GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.SortTextArray[2, panelObjectIdx].ClearString();
				this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.TopBoard.KillsTop.Value, 1, true);
				this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
				component = item.transform.GetChild(6).GetComponent<UIText>();
				component.text = this.SortTextArray[2, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				UIButton component2 = item.transform.GetChild(1).GetComponent<UIButton>();
				component2.m_Handler = this;
				component2.m_BtnID1 = 3;
				component2.m_BtnID2 = 1;
				break;
			}
			case 2:
			{
				item.transform.GetChild(2).gameObject.SetActive(false);
				item.transform.GetChild(3).gameObject.SetActive(true);
				if (item.transform.GetChild(3).childCount < 1)
				{
					GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.TopBoard.ArenaTopHead, 11, 0, 0, false, false, true, false);
				}
				else
				{
					GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.TopBoard.ArenaTopHead, 11, 0, 0);
				}
				UIText component = item.transform.GetChild(4).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(9125u);
				this.SortTextArray[1, panelObjectIdx].ClearString();
				switch (LeaderBoardManager.isOpenArena())
				{
				case 0:
					GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], 0, LeaderBoardManager.Instance.TopBoard.ArenaTop.Name, LeaderBoardManager.Instance.TopBoard.ArenaTop.AlliaceTag, false);
					break;
				case 1:
					this.SortTextArray[1, panelObjectIdx].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(977u));
					this.SortTextArray[1, panelObjectIdx].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9584u));
					item.transform.GetChild(3).gameObject.SetActive(false);
					break;
				case 2:
					this.SortTextArray[1, panelObjectIdx].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(10003u));
					this.SortTextArray[1, panelObjectIdx].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9584u));
					item.transform.GetChild(3).gameObject.SetActive(false);
					break;
				case 3:
					this.SortTextArray[1, panelObjectIdx].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(11095u));
					this.SortTextArray[1, panelObjectIdx].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9584u));
					item.transform.GetChild(3).gameObject.SetActive(false);
					break;
				}
				component = item.transform.GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.SortTextArray[2, panelObjectIdx].ClearString();
				component = item.transform.GetChild(6).GetComponent<UIText>();
				component.text = this.SortTextArray[2, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				UIButton component2 = item.transform.GetChild(1).GetComponent<UIButton>();
				component2.m_Handler = this;
				component2.m_BtnID1 = 3;
				component2.m_BtnID2 = 4;
				break;
			}
			}
		}
		else if (dataIdx != 0)
		{
			if (dataIdx == 1)
			{
				item.transform.GetChild(2).gameObject.SetActive(LeaderBoardManager.Instance.TopBoard.KillsTopEmblem != 0);
				item.transform.GetChild(3).gameObject.SetActive(false);
				if (item.transform.GetChild(2).GetChild(0).childCount < 1)
				{
					GUIManager.Instance.InitBadgeTotem(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.TopBoard.KillsTopEmblem);
				}
				else
				{
					GUIManager.Instance.SetBadgeTotemImg(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.TopBoard.KillsTopEmblem);
				}
				UIText component = item.transform.GetChild(4).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(7312u);
				this.SortTextArray[1, panelObjectIdx].ClearString();
				if (LeaderBoardManager.Instance.TopBoard.AlliKillsTop.Value == 0UL)
				{
					this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8477u));
				}
				else
				{
					GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], 0, LeaderBoardManager.Instance.TopBoard.AlliKillsTop.Name, LeaderBoardManager.Instance.TopBoard.AlliKillsTop.AlliaceTag, false);
				}
				component = item.transform.GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.SortTextArray[2, panelObjectIdx].ClearString();
				this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.TopBoard.AlliKillsTop.Value, 1, true);
				this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
				component = item.transform.GetChild(6).GetComponent<UIText>();
				component.text = this.SortTextArray[2, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				UIButton component2 = item.transform.GetChild(1).GetComponent<UIButton>();
				component2.m_Handler = this;
				component2.m_BtnID1 = 3;
				component2.m_BtnID2 = 3;
			}
		}
		else
		{
			item.transform.GetChild(2).gameObject.SetActive(LeaderBoardManager.Instance.TopBoard.PowerTopEmblem != 0);
			item.transform.GetChild(3).gameObject.SetActive(false);
			if (item.transform.GetChild(2).GetChild(0).childCount < 1)
			{
				GUIManager.Instance.InitBadgeTotem(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.TopBoard.PowerTopEmblem);
			}
			else
			{
				GUIManager.Instance.SetBadgeTotemImg(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.TopBoard.PowerTopEmblem);
			}
			UIText component = item.transform.GetChild(4).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(7064u);
			this.SortTextArray[1, panelObjectIdx].ClearString();
			if (LeaderBoardManager.Instance.TopBoard.AlliPowerTop.Value == 0UL)
			{
				this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8477u));
			}
			else
			{
				GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], 0, LeaderBoardManager.Instance.TopBoard.AlliPowerTop.Name, LeaderBoardManager.Instance.TopBoard.AlliPowerTop.AlliaceTag, false);
			}
			component = item.transform.GetChild(5).GetComponent<UIText>();
			component.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.TopBoard.AlliPowerTop.Value, 1, true);
			this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
			component = item.transform.GetChild(6).GetComponent<UIText>();
			component.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			UIButton component2 = item.transform.GetChild(1).GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 3;
			component2.m_BtnID2 = 2;
		}
	}

	// Token: 0x0600136E RID: 4974 RVA: 0x00225FE4 File Offset: 0x002241E4
	public void UpdatRow_Boards(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (dataIdx == 0)
		{
			RectTransform component = item.transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
			if (UILeaderBoard.SubBoardID != 4)
			{
				item.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
				component.anchoredPosition = new Vector2((float)(UILeaderBoard.CommonBoardSize[0] + UILeaderBoard.CommonBoardSize[1]), component.anchoredPosition.y);
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.CommonBoardSize[2]);
				component = item.transform.GetChild(0).GetChild(5).GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2((float)(UILeaderBoard.CommonBoardSize[0] + UILeaderBoard.CommonBoardSize[1] / 2), component.anchoredPosition.y);
			}
			else
			{
				item.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
				component.anchoredPosition = new Vector2(102f, -3f);
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 674f);
				component = item.transform.GetChild(0).GetChild(5).GetComponent<RectTransform>();
				component.anchoredPosition = new Vector2(368f, -18f);
			}
			switch (UILeaderBoard.SubBoardID)
			{
			case 0:
			{
				item.transform.GetChild(0).gameObject.SetActive(true);
				item.transform.GetChild(1).gameObject.SetActive(false);
				UIText component2 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7063u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7064u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				break;
			}
			case 1:
			{
				item.transform.GetChild(0).gameObject.SetActive(true);
				item.transform.GetChild(1).gameObject.SetActive(false);
				UIText component2 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7063u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7312u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				break;
			}
			case 2:
			{
				item.transform.GetChild(0).gameObject.SetActive(true);
				item.transform.GetChild(1).gameObject.SetActive(false);
				UIText component2 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7094u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7064u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				break;
			}
			case 3:
			{
				item.transform.GetChild(0).gameObject.SetActive(true);
				item.transform.GetChild(1).gameObject.SetActive(false);
				UIText component2 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7094u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7312u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				break;
			}
			case 4:
			{
				item.transform.GetChild(0).gameObject.SetActive(true);
				item.transform.GetChild(1).gameObject.SetActive(false);
				UIText component2 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7063u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
				component2.text = string.Empty;
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				break;
			}
			case 5:
			{
				item.transform.GetChild(0).gameObject.SetActive(true);
				item.transform.GetChild(1).gameObject.SetActive(false);
				UIText component2 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(9850u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(9851u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				break;
			}
			case 6:
			{
				item.transform.GetChild(0).gameObject.SetActive(true);
				item.transform.GetChild(1).gameObject.SetActive(false);
				UIText component2 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7094u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(9857u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				break;
			}
			case 7:
			{
				item.transform.GetChild(0).gameObject.SetActive(true);
				item.transform.GetChild(1).gameObject.SetActive(false);
				UIText component2 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7063u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(9858u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				break;
			}
			}
		}
		else
		{
			LeaderBoardManager.Instance.CheckNextPart(UILeaderBoard.SubBoardID, (byte)dataIdx);
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			this.SortTextArray[0, panelObjectIdx].ClearString();
			this.SortTextArray[0, panelObjectIdx].IntToFormat((long)dataIdx, 1, false);
			this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
			UIText component2 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
			component2.text = this.SortTextArray[0, panelObjectIdx].ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			this.SortTextArray[1, panelObjectIdx].ClearString();
			GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], 0, LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][dataIdx - 1].AlliaceTag, false);
			component2 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
			component2.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			RectTransform component = item.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
			if (UILeaderBoard.SubBoardID == 4)
			{
				component.anchoredPosition = new Vector2(102f, 0f);
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 674f);
				UIButtonHint component3 = item.transform.GetChild(1).GetChild(11).GetComponent<UIButtonHint>();
				component3.Parm1 = (ushort)(dataIdx - 1);
				component3.m_eHint = EUIButtonHint.UIArena_Hint;
				component3.m_Handler = this;
				component3.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
				UIButton component4 = item.transform.GetChild(1).GetChild(11).GetComponent<UIButton>();
				component4.gameObject.SetActive(true);
				component4.m_Handler = this;
				component4.m_BtnID1 = 5;
				component4.m_BtnID2 = dataIdx - 1;
				item.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
			}
			else
			{
				component.anchoredPosition = new Vector2((float)(UILeaderBoard.CommonBoardSize[0] + UILeaderBoard.CommonBoardSize[1]), component.anchoredPosition.y);
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.CommonBoardSize[2]);
				item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
				item.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);
				item.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
				this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][dataIdx - 1].Value, 1, true);
				this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
			}
			component2 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
			component2.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			if (UILeaderBoard.SubBoardID != 4)
			{
				UIButton component4 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
				component4.m_Handler = this;
				component4.m_BtnID1 = 4;
				component4.m_BtnID2 = dataIdx - 1;
				component4.gameObject.SetActive(true);
			}
			else
			{
				UIButton component4 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
				component4.m_Handler = this;
				component4.m_BtnID1 = 4;
				component4.m_BtnID2 = dataIdx - 1;
				component4.gameObject.SetActive(LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][dataIdx - 1].Value == 0UL);
			}
			if (dataIdx == (int)LeaderBoardManager.Instance.MyRank[(int)UILeaderBoard.SubBoardID])
			{
				UISpritesArray component5 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component5.SetSpriteIndex(2);
				component5 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component5.SetSpriteIndex(2);
				component5 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component5.SetSpriteIndex(2);
			}
			else if (dataIdx % 2 == 0)
			{
				UISpritesArray component5 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component5.SetSpriteIndex(1);
				component5 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component5.SetSpriteIndex(1);
				component5 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component5.SetSpriteIndex(1);
			}
			else
			{
				UISpritesArray component5 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component5.SetSpriteIndex(0);
				component5 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component5.SetSpriteIndex(0);
				component5 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component5.SetSpriteIndex(0);
			}
		}
	}

	// Token: 0x0600136F RID: 4975 RVA: 0x00226EA4 File Offset: 0x002250A4
	public void UpdateRow_WorldRanking_FunctionList(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (UILeaderBoard.isPersonBoard)
		{
			if (dataIdx != 0)
			{
				if (dataIdx == 1)
				{
					item.transform.GetChild(2).gameObject.SetActive(false);
					item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTop.Value != 0UL);
					if (item.transform.GetChild(3).childCount < 1)
					{
						GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTopHead, 11, 0, 0, false, false, true, false);
					}
					else
					{
						GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTopHead, 11, 0, 0);
					}
					UIText component = item.transform.GetChild(4).GetComponent<UIText>();
					component.text = DataManager.Instance.mStringTable.GetStringByID(7312u);
					this.SortTextArray[1, panelObjectIdx].ClearString();
					if (LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTop.Value == 0UL)
					{
						this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475u));
					}
					else
					{
						GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTop.KingdomID, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTop.Name, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTop.AlliaceTag, false);
					}
					component = item.transform.GetChild(5).GetComponent<UIText>();
					component.text = this.SortTextArray[1, panelObjectIdx].ToString();
					component.SetAllDirty();
					component.cachedTextGenerator.Invalidate();
					this.SortTextArray[2, panelObjectIdx].ClearString();
					this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTop.Value, 1, true);
					this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
					component = item.transform.GetChild(6).GetComponent<UIText>();
					component.text = this.SortTextArray[2, panelObjectIdx].ToString();
					component.SetAllDirty();
					component.cachedTextGenerator.Invalidate();
					UIButton component2 = item.transform.GetChild(1).GetComponent<UIButton>();
					component2.m_Handler = this;
					component2.m_BtnID1 = 3;
					component2.m_BtnID2 = 9;
				}
			}
			else
			{
				item.transform.GetChild(2).gameObject.SetActive(false);
				item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTop.Value != 0UL);
				if (item.transform.GetChild(3).childCount < 1)
				{
					GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTopHead, 11, 0, 0, false, false, true, false);
				}
				else
				{
					GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTopHead, 11, 0, 0);
				}
				UIText component = item.transform.GetChild(4).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(7064u);
				this.SortTextArray[1, panelObjectIdx].ClearString();
				if (LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTop.Value == 0UL)
				{
					this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475u));
				}
				else
				{
					GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTop.KingdomID, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTop.Name, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTop.AlliaceTag, false);
				}
				component = item.transform.GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.SortTextArray[2, panelObjectIdx].ClearString();
				this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTop.Value, 1, true);
				this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
				component = item.transform.GetChild(6).GetComponent<UIText>();
				component.text = this.SortTextArray[2, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				UIButton component2 = item.transform.GetChild(1).GetComponent<UIButton>();
				component2.m_Handler = this;
				component2.m_BtnID1 = 3;
				component2.m_BtnID2 = 8;
			}
		}
		else if (dataIdx != 0)
		{
			if (dataIdx == 1)
			{
				item.transform.GetChild(2).gameObject.SetActive(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTopEmblem != 0);
				item.transform.GetChild(3).gameObject.SetActive(false);
				if (item.transform.GetChild(2).GetChild(0).childCount < 1)
				{
					GUIManager.Instance.InitBadgeTotem(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTopEmblem);
				}
				else
				{
					GUIManager.Instance.SetBadgeTotemImg(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTopEmblem);
				}
				UIText component = item.transform.GetChild(4).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(7312u);
				this.SortTextArray[1, panelObjectIdx].ClearString();
				if (LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliKillsTop.Value == 0UL)
				{
					this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8477u));
				}
				else
				{
					GameConstants.GetAllianceNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliKillsTop.KingdomID, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliKillsTop.Name, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliKillsTop.AlliaceTag, false);
				}
				component = item.transform.GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.SortTextArray[2, panelObjectIdx].ClearString();
				this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliKillsTop.Value, 1, true);
				this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
				component = item.transform.GetChild(6).GetComponent<UIText>();
				component.text = this.SortTextArray[2, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				UIButton component2 = item.transform.GetChild(1).GetComponent<UIButton>();
				component2.m_Handler = this;
				component2.m_BtnID1 = 3;
				component2.m_BtnID2 = 11;
			}
		}
		else
		{
			item.transform.GetChild(2).gameObject.SetActive(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTopEmblem != 0);
			item.transform.GetChild(3).gameObject.SetActive(false);
			if (item.transform.GetChild(2).GetChild(0).childCount < 1)
			{
				GUIManager.Instance.InitBadgeTotem(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTopEmblem);
			}
			else
			{
				GUIManager.Instance.SetBadgeTotemImg(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTopEmblem);
			}
			UIText component = item.transform.GetChild(4).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(7064u);
			this.SortTextArray[1, panelObjectIdx].ClearString();
			if (LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliPowerTop.Value == 0UL)
			{
				this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8477u));
			}
			else
			{
				GameConstants.GetAllianceNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliPowerTop.KingdomID, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliPowerTop.Name, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliPowerTop.AlliaceTag, false);
			}
			component = item.transform.GetChild(5).GetComponent<UIText>();
			component.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliPowerTop.Value, 1, true);
			this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
			component = item.transform.GetChild(6).GetComponent<UIText>();
			component.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			UIButton component2 = item.transform.GetChild(1).GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 3;
			component2.m_BtnID2 = 10;
		}
	}

	// Token: 0x06001370 RID: 4976 RVA: 0x002278F0 File Offset: 0x00225AF0
	public void UpdatRow_WorldRanking_Boards(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (dataIdx == 0)
		{
			RectTransform component = item.transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
			item.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
			component.anchoredPosition = new Vector2((float)(UILeaderBoard.CommonBoardSize[0] + UILeaderBoard.CommonBoardSize[1]), component.anchoredPosition.y);
			component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.CommonBoardSize[2]);
			component = item.transform.GetChild(0).GetChild(5).GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2((float)(UILeaderBoard.CommonBoardSize[0] + UILeaderBoard.CommonBoardSize[1] / 2), component.anchoredPosition.y);
			switch (UILeaderBoard.SubBoardID)
			{
			case 8:
			{
				item.transform.GetChild(0).gameObject.SetActive(true);
				item.transform.GetChild(1).gameObject.SetActive(false);
				UIText component2 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7063u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7064u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				break;
			}
			case 9:
			{
				item.transform.GetChild(0).gameObject.SetActive(true);
				item.transform.GetChild(1).gameObject.SetActive(false);
				UIText component2 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7063u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7312u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				break;
			}
			case 10:
			{
				item.transform.GetChild(0).gameObject.SetActive(true);
				item.transform.GetChild(1).gameObject.SetActive(false);
				UIText component2 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7094u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7064u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				break;
			}
			case 11:
			{
				item.transform.GetChild(0).gameObject.SetActive(true);
				item.transform.GetChild(1).gameObject.SetActive(false);
				UIText component2 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7094u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				component2 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
				component2.text = DataManager.Instance.mStringTable.GetStringByID(7312u);
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
				break;
			}
			}
		}
		else
		{
			LeaderBoardManager.Instance.CheckNextPart(UILeaderBoard.SubBoardID, (byte)dataIdx);
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			this.SortTextArray[0, panelObjectIdx].ClearString();
			this.SortTextArray[0, panelObjectIdx].IntToFormat((long)dataIdx, 1, false);
			this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
			UIText component2 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
			component2.text = this.SortTextArray[0, panelObjectIdx].ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			this.SortTextArray[1, panelObjectIdx].ClearString();
			if (UILeaderBoard.isPersonBoard)
			{
				GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], ((WorldRankingBoardUnit)LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][dataIdx - 1]).KingdomID, LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][dataIdx - 1].AlliaceTag, false);
			}
			else
			{
				GameConstants.GetAllianceNameString(this.SortTextArray[1, panelObjectIdx], ((WorldRankingBoardUnitAlliance)LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][dataIdx - 1]).KingdomID, LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][dataIdx - 1].AlliaceTag, false);
			}
			component2 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
			component2.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			RectTransform component = item.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2((float)(UILeaderBoard.CommonBoardSize[0] + UILeaderBoard.CommonBoardSize[1]), component.anchoredPosition.y);
			component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.CommonBoardSize[2]);
			item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
			item.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);
			item.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
			this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][dataIdx - 1].Value, 1, true);
			this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
			component2 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
			component2.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
			UIButton component3 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = 4;
			component3.m_BtnID2 = dataIdx - 1;
			component3.gameObject.SetActive(true);
			if (dataIdx == (int)LeaderBoardManager.Instance.MyRank[(int)UILeaderBoard.SubBoardID])
			{
				UISpritesArray component4 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(2);
				component4 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(2);
				component4 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(2);
			}
			else if (dataIdx % 2 == 0)
			{
				UISpritesArray component4 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(1);
				component4 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(1);
				component4 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(1);
			}
			else
			{
				UISpritesArray component4 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(0);
				component4 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(0);
				component4 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component4.SetSpriteIndex(0);
			}
		}
	}

	// Token: 0x06001371 RID: 4977 RVA: 0x00228290 File Offset: 0x00226490
	public override void UpdateUI(int arg1, int arg2)
	{
		if ((byte)arg1 == 5)
		{
			this.door.CloseMenu(false);
		}
		switch (this.OpenKind)
		{
		case UI_LeaderBoardOpenKind.Alli_Inter:
			if ((byte)arg1 == 0)
			{
				this.CreateAlliInterBoard();
				if (!this.LoadComplet)
				{
					this.DataReady = true;
				}
				else
				{
					this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
					this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
					this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[12]);
				}
			}
			break;
		case UI_LeaderBoardOpenKind.OtherAlli_inter:
			if ((byte)arg1 == 1)
			{
				this.CreateOtherAlliInterBoard();
				if (!this.LoadComplet)
				{
					this.DataReady = true;
				}
				else
				{
					this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
					this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
					this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[12]);
				}
			}
			break;
		case UI_LeaderBoardOpenKind.BoardMenu:
			if (UILeaderBoard.WorldBoard)
			{
				switch ((byte)arg1)
				{
				case 2:
					if (UILeaderBoard.isTopBoard)
					{
						this.CreateWorldRankingTopBoard();
						if (!this.LoadComplet)
						{
							this.DataReady = true;
						}
						else
						{
							this.SetOpenType(UILeaderBoard.e_OpenType.BoardTypes);
							this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false, true);
							this.AGS_Panel1.GoTo(0);
						}
					}
					break;
				case 3:
					if (!UILeaderBoard.isTopBoard && arg2 == (int)UILeaderBoard.SubBoardID)
					{
						this.CreateWorldRankingSubBoard();
						this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
						this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
					}
					break;
				case 4:
					if (!UILeaderBoard.isTopBoard && arg2 == (int)UILeaderBoard.SubBoardID)
					{
						UILeaderBoard.TopIndex[(int)UILeaderBoard.SubBoardID] = 0;
						this.CreateWorldRankingSubBoard();
						this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
						this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
						this.AGS_Panel2.GoTo(0);
					}
					break;
				}
			}
			else
			{
				switch ((byte)arg1)
				{
				case 2:
					if (UILeaderBoard.isTopBoard)
					{
						this.CreateTopBoard();
						if (!this.LoadComplet)
						{
							this.DataReady = true;
						}
						else
						{
							this.SetOpenType(UILeaderBoard.e_OpenType.BoardTypes);
							this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false, true);
							this.AGS_Panel1.GoTo(0);
						}
					}
					break;
				case 3:
					if (!UILeaderBoard.isTopBoard && arg2 == (int)UILeaderBoard.SubBoardID)
					{
						this.CreateSubBoard();
						this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
						this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
					}
					break;
				case 4:
					if (!UILeaderBoard.isTopBoard && arg2 == (int)UILeaderBoard.SubBoardID)
					{
						UILeaderBoard.TopIndex[(int)UILeaderBoard.SubBoardID] = 0;
						this.CreateSubBoard();
						this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
						this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
						this.AGS_Panel2.GoTo(0);
					}
					break;
				}
			}
			break;
		case UI_LeaderBoardOpenKind.ArenaBoard:
		{
			UI_LeaderBoardUpdateKind ui_LeaderBoardUpdateKind = (UI_LeaderBoardUpdateKind)arg1;
			if (ui_LeaderBoardUpdateKind != UI_LeaderBoardUpdateKind.BoardData)
			{
				if (ui_LeaderBoardUpdateKind == UI_LeaderBoardUpdateKind.BoardDataReset)
				{
					if (arg2 == 4)
					{
						UILeaderBoard.TopIndex[4] = 0;
						this.CreateSubBoard();
						this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
						this.AGS_Panel2.GoTo(0);
					}
				}
			}
			else if (arg2 == 4)
			{
				this.CreateSubBoard();
				this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
			}
			break;
		}
		case UI_LeaderBoardOpenKind.MobilizationGroupBoard:
			if ((byte)arg1 == 6)
			{
				this.CreateMobilizationGroupBoard();
				if (!this.LoadComplet)
				{
					this.DataReady = true;
				}
				else
				{
					this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
					this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
					if (UILeaderBoard.TopIndex[13] == 0 && UILeaderBoard.NewOpen)
					{
						UILeaderBoard.NewOpen = false;
						if (LeaderBoardManager.Instance.MobiGroupRank > 4)
						{
							UILeaderBoard.TopIndex[13] = LeaderBoardManager.Instance.MobiGroupRank - 3;
						}
					}
					this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[13]);
				}
			}
			break;
		case UI_LeaderBoardOpenKind.MobilizationAlliBoard:
			if ((byte)arg1 == 7)
			{
				this.CreateMobilizationAlliBoard();
				if (!this.LoadComplet)
				{
					this.DataReady = true;
				}
				else
				{
					this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
					this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
					if (UILeaderBoard.TopIndex[14] == 0 && UILeaderBoard.NewOpen)
					{
						UILeaderBoard.NewOpen = false;
						if (LeaderBoardManager.Instance.MobiAlliRank > 4)
						{
							UILeaderBoard.TopIndex[14] = LeaderBoardManager.Instance.MobiAlliRank - 3;
						}
					}
					this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[14]);
				}
			}
			break;
		case UI_LeaderBoardOpenKind.WorldKingHistory:
			if ((byte)arg1 == 9)
			{
				if (arg2 == 0)
				{
					this.CreateWorldKingHistoryBoard();
					if (!this.LoadComplet)
					{
						this.DataReady = true;
					}
					else
					{
						this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
						this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
						this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[15]);
					}
				}
				else if (arg2 == 1)
				{
					this.DataReady = false;
					LeaderBoardManager.Instance.Send_MSG_REQUEST_KINGOFTHEWORLD_HISTORYKINGDATA();
				}
			}
			break;
		case UI_LeaderBoardOpenKind.KingofWorldRankingBoard:
			if ((byte)arg1 == 10)
			{
				this.CreateKingofWorldRankingBoard();
				if (!this.LoadComplet)
				{
					this.DataReady = true;
				}
				else
				{
					this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
					this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
					this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[15]);
				}
			}
			break;
		}
	}

	// Token: 0x06001372 RID: 4978 RVA: 0x00228814 File Offset: 0x00226A14
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
			if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Chat) != null)
			{
				this.door.CloseMenu_Alliance(EGUIWindow.UI_LeaderBoard);
			}
			else
			{
				this.door.CloseMenu(false);
			}
			break;
		default:
			if (networkNews != NetworkNews.Refresh_Alliance)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else if (DataManager.Instance.RoleAlliance.Id == 0u && this.OpenKind == UI_LeaderBoardOpenKind.Alli_Inter)
			{
				this.door.CloseMenu_Alliance(EGUIWindow.UI_LeaderBoard);
			}
			break;
		case NetworkNews.Refresh:
			if (this.OpenKind == UI_LeaderBoardOpenKind.WorldKingHistory)
			{
				this.DataReady = false;
				LeaderBoardManager.Instance.Send_MSG_REQUEST_KINGOFTHEWORLD_HISTORYKINGDATA();
			}
			if (DataManager.Instance.RoleAlliance.Id == 0u && this.OpenKind == UI_LeaderBoardOpenKind.Alli_Inter)
			{
				this.door.CloseMenu_Alliance(EGUIWindow.UI_LeaderBoard);
			}
			break;
		}
	}

	// Token: 0x06001373 RID: 4979 RVA: 0x00228910 File Offset: 0x00226B10
	public void Update()
	{
		if (!this.LoadComplet)
		{
			switch (this.OpenKind)
			{
			case UI_LeaderBoardOpenKind.MobilizationGroupBoard:
			{
				RectTransform component = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<RectTransform>();
				int num = UILeaderBoard.MobiGroupBoardSize[0];
				component.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
				component.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
				component.transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
				component.transform.GetChild(1).GetChild(9).gameObject.SetActive(true);
				RectTransform component2 = component.GetChild(0).GetChild(5).GetComponent<RectTransform>();
				component2.anchoredPosition = new Vector2((float)(num + UILeaderBoard.MobiGroupBoardSize[1] / 2), component2.anchoredPosition.y);
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiGroupBoardSize[1]);
				component2 = component.transform.GetChild(0).GetChild(1).GetComponent<RectTransform>();
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiGroupBoardSize[1]);
				component2 = component.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiGroupBoardSize[1]);
				num += UILeaderBoard.MobiGroupBoardSize[1];
				component2 = component.transform.GetChild(0).GetChild(6).GetComponent<RectTransform>();
				component2.anchoredPosition = new Vector2((float)(num + UILeaderBoard.MobiGroupBoardSize[2] / 2), component2.anchoredPosition.y);
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiGroupBoardSize[2]);
				component2 = component.transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
				component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiGroupBoardSize[2]);
				component2 = component.GetChild(1).GetChild(5).GetComponent<RectTransform>();
				component2.anchoredPosition = new Vector2((float)(num + 10), component2.anchoredPosition.y);
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)(UILeaderBoard.MobiGroupBoardSize[2] - 20));
				component2 = component.transform.GetChild(1).GetChild(3).GetComponent<RectTransform>();
				component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiGroupBoardSize[2]);
				component2.gameObject.SetActive(true);
				num += UILeaderBoard.MobiGroupBoardSize[2];
				component2 = component.transform.GetChild(0).GetChild(7).GetComponent<RectTransform>();
				component2.anchoredPosition = new Vector2((float)(num + UILeaderBoard.MobiGroupBoardSize[3] / 2), component2.anchoredPosition.y);
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiGroupBoardSize[3]);
				component2 = component.transform.GetChild(0).GetChild(3).GetComponent<RectTransform>();
				component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiGroupBoardSize[3]);
				component2 = component.transform.GetChild(1).GetChild(6).GetComponent<RectTransform>();
				component2.anchoredPosition = new Vector2((float)(num + 10), component2.anchoredPosition.y);
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)(UILeaderBoard.MobiGroupBoardSize[3] - 116));
				component2.GetComponent<UIText>().alignment = TextAnchor.MiddleRight;
				component2 = component.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
				component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiGroupBoardSize[3]);
				component2 = component.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
				component2.anchoredPosition = new Vector2(92.5f, component2.anchoredPosition.y);
				UIButton component3 = component.transform.GetChild(1).GetChild(12).GetComponent<UIButton>();
				component3.m_Handler = this;
				component3.gameObject.SetActive(true);
				UIButtonHint uibuttonHint = component3.gameObject.AddComponent<UIButtonHint>();
				uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
				uibuttonHint.m_Handler = this;
				uibuttonHint.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
				component2 = component3.GetComponent<RectTransform>();
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiGroupBoardSize[1]);
				break;
			}
			case UI_LeaderBoardOpenKind.MobilizationAlliBoard:
			{
				RectTransform component4 = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<RectTransform>();
				int num2 = UILeaderBoard.MobiAlliBoardSize[0];
				component4.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
				component4.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
				component4.transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
				component4.transform.GetChild(1).GetChild(7).gameObject.SetActive(true);
				RectTransform component5 = component4.GetChild(0).GetChild(5).GetComponent<RectTransform>();
				component5.anchoredPosition = new Vector2((float)(num2 + UILeaderBoard.MobiAlliBoardSize[1] / 2), component5.anchoredPosition.y);
				component5.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiAlliBoardSize[1]);
				component5 = component4.transform.GetChild(0).GetChild(1).GetComponent<RectTransform>();
				component5.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiAlliBoardSize[1]);
				component5 = component4.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
				component5.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiAlliBoardSize[1]);
				component5 = component4.GetChild(1).GetChild(5).GetComponent<RectTransform>();
				component5.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiAlliBoardSize[1]);
				num2 += UILeaderBoard.MobiAlliBoardSize[1];
				component5 = component4.transform.GetChild(0).GetChild(6).GetComponent<RectTransform>();
				component5.anchoredPosition = new Vector2((float)(num2 + UILeaderBoard.MobiAlliBoardSize[2] / 2), component5.anchoredPosition.y);
				component5.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiAlliBoardSize[2]);
				component5 = component4.transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
				component5.anchoredPosition = new Vector2((float)num2, component5.anchoredPosition.y);
				component5.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiAlliBoardSize[2]);
				component5 = component4.transform.GetChild(1).GetChild(6).GetComponent<RectTransform>();
				component5.anchoredPosition = new Vector2((float)num2, component5.anchoredPosition.y);
				component5.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiAlliBoardSize[2]);
				component5 = component4.transform.GetChild(1).GetChild(3).GetComponent<RectTransform>();
				component5.anchoredPosition = new Vector2((float)num2, component5.anchoredPosition.y);
				component5.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiAlliBoardSize[2]);
				component5.gameObject.SetActive(true);
				component5 = component4.transform.GetChild(1).GetChild(12).GetComponent<RectTransform>();
				component5.anchoredPosition = new Vector2((float)num2, component5.anchoredPosition.y);
				component5.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiAlliBoardSize[2]);
				num2 += UILeaderBoard.MobiAlliBoardSize[2];
				component5 = component4.transform.GetChild(0).GetChild(7).GetComponent<RectTransform>();
				component5.anchoredPosition = new Vector2((float)(num2 + UILeaderBoard.MobiAlliBoardSize[3] / 2), component5.anchoredPosition.y);
				component5.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiAlliBoardSize[3]);
				component5 = component4.transform.GetChild(0).GetChild(3).GetComponent<RectTransform>();
				component5.anchoredPosition = new Vector2((float)num2, component5.anchoredPosition.y);
				component5.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiAlliBoardSize[3]);
				component5 = component4.transform.GetChild(1).GetChild(7).GetComponent<RectTransform>();
				component5.anchoredPosition = new Vector2((float)num2, component5.anchoredPosition.y);
				component5.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiAlliBoardSize[3]);
				component5.gameObject.SetActive(true);
				component5 = component4.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
				component5.anchoredPosition = new Vector2((float)num2, component5.anchoredPosition.y);
				component5.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiAlliBoardSize[3]);
				component5 = component4.transform.GetChild(1).GetChild(10).GetComponent<RectTransform>();
				component5.gameObject.SetActive(false);
				UIButton component6 = component4.transform.GetChild(1).GetChild(12).GetComponent<UIButton>();
				component6.m_Handler = this;
				component6.gameObject.SetActive(true);
				UIButtonHint uibuttonHint2 = component6.gameObject.AddComponent<UIButtonHint>();
				uibuttonHint2.m_eHint = EUIButtonHint.DownUpHandler;
				uibuttonHint2.m_Handler = this;
				uibuttonHint2.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
				break;
			}
			case UI_LeaderBoardOpenKind.WorldKingHistory:
			{
				RectTransform component7 = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<RectTransform>();
				int num3 = 0;
				component7.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
				component7.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
				component7.transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
				component7.transform.GetChild(1).GetChild(7).gameObject.SetActive(true);
				RectTransform component8 = component7.GetChild(0).GetChild(0).GetComponent<RectTransform>();
				component8.anchoredPosition = new Vector2((float)num3, component8.anchoredPosition.y);
				component8.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiWorldKingBoardSize[0]);
				component8 = component7.GetChild(0).GetChild(4).GetComponent<RectTransform>();
				component8.anchoredPosition = new Vector2((float)(num3 + UILeaderBoard.MobiWorldKingBoardSize[0] / 2), component8.anchoredPosition.y);
				component8.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiWorldKingBoardSize[0]);
				num3 = UILeaderBoard.MobiWorldKingBoardSize[0];
				component8 = component7.GetChild(0).GetChild(1).GetComponent<RectTransform>();
				component8.anchoredPosition = new Vector2((float)num3, component8.anchoredPosition.y);
				component8.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiWorldKingBoardSize[1]);
				component8 = component7.GetChild(0).GetChild(5).GetComponent<RectTransform>();
				component8.anchoredPosition = new Vector2((float)(num3 + UILeaderBoard.MobiWorldKingBoardSize[1] / 2), component8.anchoredPosition.y);
				component8.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiWorldKingBoardSize[1]);
				num3 = UILeaderBoard.MobiWorldKingBoardSize[0] + UILeaderBoard.MobiWorldKingBoardSize[1];
				component8 = component7.GetChild(0).GetChild(2).GetComponent<RectTransform>();
				component8.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiWorldKingBoardSize[2]);
				component8.anchoredPosition = new Vector2((float)num3, component8.anchoredPosition.y);
				component8 = component7.GetChild(0).GetChild(6).GetComponent<RectTransform>();
				component8.anchoredPosition = new Vector2((float)(num3 + UILeaderBoard.MobiWorldKingBoardSize[2] / 2), component8.anchoredPosition.y);
				component8.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiWorldKingBoardSize[2]);
				component8 = component7.GetChild(0).GetChild(3).GetComponent<RectTransform>();
				component8.gameObject.SetActive(false);
				component8 = component7.GetChild(0).GetChild(7).GetComponent<RectTransform>();
				component8.gameObject.SetActive(false);
				num3 = 0;
				component8 = component7.GetChild(1).GetChild(0).GetComponent<RectTransform>();
				component8.anchoredPosition = new Vector2((float)num3, component8.anchoredPosition.y);
				component8.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiWorldKingBoardSize[0]);
				num3 = 10;
				component8 = component7.GetChild(1).GetChild(4).GetComponent<RectTransform>();
				component8.anchoredPosition = new Vector2((float)(num3 + UILeaderBoard.MobiWorldKingBoardSize[0] / 2), component8.anchoredPosition.y);
				component8.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)(UILeaderBoard.MobiWorldKingBoardSize[0] - 20));
				UIText component9 = component7.GetChild(1).GetChild(4).GetComponent<UIText>();
				component9.alignment = TextAnchor.MiddleLeft;
				num3 = UILeaderBoard.MobiWorldKingBoardSize[0];
				component8 = component7.GetChild(1).GetChild(1).GetComponent<RectTransform>();
				component8.anchoredPosition = new Vector2((float)num3, component8.anchoredPosition.y);
				component8.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiWorldKingBoardSize[1]);
				component8 = component7.GetChild(1).GetChild(5).GetComponent<RectTransform>();
				component9 = component7.GetChild(1).GetChild(5).GetComponent<UIText>();
				component9.alignment = TextAnchor.MiddleCenter;
				component8.anchoredPosition = new Vector2((float)num3, component8.anchoredPosition.y);
				component8.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiWorldKingBoardSize[1]);
				num3 = UILeaderBoard.MobiWorldKingBoardSize[0] + UILeaderBoard.MobiWorldKingBoardSize[1];
				component8 = component7.GetChild(1).GetChild(2).GetComponent<RectTransform>();
				component8.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiWorldKingBoardSize[2]);
				component8.anchoredPosition = new Vector2((float)num3, component8.anchoredPosition.y);
				component8 = component7.GetChild(1).GetChild(6).GetComponent<RectTransform>();
				component8.anchoredPosition = new Vector2((float)num3, component8.anchoredPosition.y);
				component8.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.MobiWorldKingBoardSize[3]);
				component8 = component7.GetChild(1).GetChild(3).GetComponent<RectTransform>();
				component8.gameObject.SetActive(false);
				component8 = component7.GetChild(1).GetChild(7).GetComponent<RectTransform>();
				component8.gameObject.SetActive(false);
				component8 = component7.transform.GetChild(1).GetChild(10).GetComponent<RectTransform>();
				component8.gameObject.SetActive(false);
				break;
			}
			default:
			{
				RectTransform component10 = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<RectTransform>();
				int num4 = UILeaderBoard.CommonBoardSize[0];
				RectTransform component11 = component10.GetChild(0).GetChild(5).GetComponent<RectTransform>();
				component11.anchoredPosition = new Vector2((float)(num4 + UILeaderBoard.CommonBoardSize[1] / 2), component11.anchoredPosition.y);
				component11.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.CommonBoardSize[1]);
				component11 = component10.GetChild(0).GetChild(1).GetComponent<RectTransform>();
				component11.anchoredPosition = new Vector2((float)num4, component11.anchoredPosition.y);
				component11.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.CommonBoardSize[1]);
				component11 = component10.GetChild(1).GetChild(5).GetComponent<RectTransform>();
				component11.anchoredPosition = new Vector2((float)(num4 + 10), component11.anchoredPosition.y);
				component11.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)(UILeaderBoard.CommonBoardSize[1] - 20));
				component11 = component10.GetChild(1).GetChild(1).GetComponent<RectTransform>();
				component11.anchoredPosition = new Vector2((float)num4, component11.anchoredPosition.y);
				component11.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.CommonBoardSize[1]);
				num4 += UILeaderBoard.CommonBoardSize[1];
				component11 = component10.GetChild(0).GetChild(6).GetComponent<RectTransform>();
				component11.anchoredPosition = new Vector2((float)(num4 + UILeaderBoard.CommonBoardSize[2] / 2), component11.anchoredPosition.y);
				component11.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.CommonBoardSize[2]);
				component11 = component10.GetChild(0).GetChild(2).GetComponent<RectTransform>();
				component11.anchoredPosition = new Vector2((float)num4, component11.anchoredPosition.y);
				component11.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.CommonBoardSize[2]);
				component11 = component10.GetChild(1).GetChild(6).GetComponent<RectTransform>();
				component11.anchoredPosition = new Vector2((float)(num4 + 10), component11.anchoredPosition.y);
				component11.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)(UILeaderBoard.CommonBoardSize[2] - 96));
				component11.GetComponent<UIText>().alignment = TextAnchor.MiddleRight;
				component11 = component10.GetChild(1).GetChild(2).GetComponent<RectTransform>();
				component11.anchoredPosition = new Vector2((float)num4, component11.anchoredPosition.y);
				component11.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UILeaderBoard.CommonBoardSize[2]);
				break;
			}
			}
			this.LoadComplet = true;
			this.AGS_Panel1.IntiScrollPanel(447f, 0f, 0f, this.SPHeight, 3, this);
			this.AGS_Panel2.IntiScrollPanel(447f, 0f, 0f, this.SPHeight, 12, this);
			UIButtonHint.scrollRect = this.AGS_Panel2.GetComponent<CScrollRect>();
			for (int i = 0; i < this.SortTextArray.GetLength(0); i++)
			{
				for (int j = 0; j < this.SortTextArray.GetLength(1); j++)
				{
					this.SortTextArray[i, j] = StringManager.Instance.SpawnString(50);
				}
			}
			this.Ranking = StringManager.Instance.SpawnString(300);
			this.RankValue = StringManager.Instance.SpawnString(100);
			this.HintStr = StringManager.Instance.SpawnString(300);
		}
		if (this.DataReady && this.LoadComplet)
		{
			this.DataReady = false;
			switch (this.OpenKind)
			{
			case UI_LeaderBoardOpenKind.Alli_Inter:
				this.CreateAlliInterBoard();
				this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
				this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
				this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[12]);
				break;
			case UI_LeaderBoardOpenKind.OtherAlli_inter:
				this.CreateOtherAlliInterBoard();
				this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
				this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
				this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[12]);
				break;
			case UI_LeaderBoardOpenKind.BoardMenu:
				if (UILeaderBoard.WorldBoard)
				{
					if (UILeaderBoard.isTopBoard)
					{
						this.CreateWorldRankingTopBoard();
						this.SetOpenType(UILeaderBoard.e_OpenType.BoardTypes);
						this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false, true);
						this.AGS_Panel1.GoTo(0);
					}
					else
					{
						this.CreateWorldRankingSubBoard();
						this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
						this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
						this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[(int)UILeaderBoard.SubBoardID]);
					}
				}
				else if (UILeaderBoard.isTopBoard)
				{
					this.CreateTopBoard();
					this.SetOpenType(UILeaderBoard.e_OpenType.BoardTypes);
					this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false, true);
					this.AGS_Panel1.GoTo(0);
				}
				else
				{
					this.CreateSubBoard();
					this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
					this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
					this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[(int)UILeaderBoard.SubBoardID]);
				}
				break;
			case UI_LeaderBoardOpenKind.ArenaBoard:
			{
				int itemidx = UILeaderBoard.TopIndex[4];
				this.SubBoardChange(4);
				this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
				this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
				this.AGS_Panel2.GoTo(itemidx);
				break;
			}
			case UI_LeaderBoardOpenKind.MobilizationGroupBoard:
				this.CreateMobilizationGroupBoard();
				this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
				this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
				if (UILeaderBoard.TopIndex[13] == 0 && UILeaderBoard.NewOpen)
				{
					UILeaderBoard.NewOpen = false;
					if (LeaderBoardManager.Instance.MobiGroupRank > 4)
					{
						UILeaderBoard.TopIndex[13] = LeaderBoardManager.Instance.MobiGroupRank - 3;
					}
				}
				this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[13]);
				break;
			case UI_LeaderBoardOpenKind.MobilizationAlliBoard:
				this.CreateMobilizationAlliBoard();
				this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
				this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
				if (UILeaderBoard.TopIndex[14] == 0 && UILeaderBoard.NewOpen)
				{
					UILeaderBoard.NewOpen = false;
					if (LeaderBoardManager.Instance.MobiAlliRank > 4)
					{
						UILeaderBoard.TopIndex[14] = LeaderBoardManager.Instance.MobiAlliRank - 3;
					}
				}
				this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[14]);
				break;
			case UI_LeaderBoardOpenKind.WorldKingHistory:
				this.CreateWorldKingHistoryBoard();
				this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
				this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
				this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[15]);
				break;
			case UI_LeaderBoardOpenKind.KingofWorldRankingBoard:
				this.CreateKingofWorldRankingBoard();
				this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
				this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
				this.AGS_Panel2.GoTo(0);
				break;
			}
		}
		this.GetPointTime += Time.smoothDeltaTime / 2f;
		if (this.GetPointTime >= 1.7f)
		{
			this.GetPointTime = 0.3f;
		}
		float a = (this.GetPointTime <= 1f) ? this.GetPointTime : (2f - this.GetPointTime);
		Color color = new Color(1f, 1f, 1f, a);
		this.POPLight1.color = color;
		this.POPLight3.color = color;
		if (UILeaderBoard.ShowSP && !this.SPReady)
		{
			float num5 = 0f;
			for (int k = 0; k < this.SPShowTiming.Length; k++)
			{
				num5 += this.SPShowTiming[k];
				this.SPShowTiming[k] = num5;
			}
			for (int l = 0; l < this.SPStrings.Length; l++)
			{
				this.SPStrings[l] = StringManager.Instance.SpawnString(30);
			}
			GameConstants.GetNameString(this.SPStrings[0], 0, DataManager.Instance.RoleAlliance.Name, DataManager.Instance.RoleAlliance.Tag, false);
			this.SPName.text = this.SPStrings[0].ToString();
			this.SPName.SetAllDirty();
			this.SPName.cachedTextGenerator.Invalidate();
			this.SPStrings[1].IntToFormat((long)UILeaderBoard.SPScoreValue, 1, true);
			this.SPStrings[1].AppendFormat("{0}");
			this.SPScore.text = this.SPStrings[1].ToString();
			this.SPScore.SetAllDirty();
			this.SPScore.cachedTextGenerator.Invalidate();
			this.SPStrings[2].IntToFormat((long)UILeaderBoard.SPScoreFlyValue, 1, true);
			this.SPStrings[2].AppendFormat("{0}");
			this.SPScoreFly.text = this.SPStrings[2].ToString();
			this.SPScoreFly.SetAllDirty();
			this.SPScoreFly.cachedTextGenerator.Invalidate();
			this.SPReady = true;
			this.SPShowTime = 0f;
			if (this.OpenKind != UI_LeaderBoardOpenKind.MobilizationGroupBoard)
			{
				UILeaderBoard.ShowSP = false;
			}
		}
		if (UILeaderBoard.ShowSP)
		{
			this.SPShowTime += Time.smoothDeltaTime;
			if (this.SPShowTime < this.SPShowTiming[0])
			{
				if (this.SPShowPhase < 1f)
				{
					this.SPShowPhase = 1f;
					this.SPScoreFly.gameObject.SetActive(false);
					this.SPRankUpDown.gameObject.SetActive(false);
					this.SPBG.gameObject.SetActive(true);
					if (!GUIManager.Instance.IsArabic)
					{
						this.SPScore.rectTransform.localScale = Vector2.one * 0.6f;
					}
					else
					{
						this.SPScore.rectTransform.localScale = new Vector2(-1f, 1f) * 0.6f;
					}
				}
				float num6 = Mathf.InverseLerp(0f, this.SPShowTiming[0], this.SPShowTime);
				Color color2 = this.SPBG.color;
				color2.a = num6 * 0.8f;
				this.SPBG.color = color2;
				color2 = this.SPName.color;
				color2.a = num6;
				this.SPName.color = color2;
				color2 = Color.white;
				color2.a = num6;
				this.SPScore.color = color2;
			}
			else if (this.SPShowTime < this.SPShowTiming[2])
			{
				Color color3;
				if (this.SPShowPhase < 2f)
				{
					this.SPShowPhase = 2f;
					this.SPScoreFly.gameObject.SetActive(true);
					this.SPStrings[3].ClearString();
					this.SPStrings[3].IntToFormat((long)Math.Abs(UILeaderBoard.SPRankChange), 1, true);
					this.SPStrings[3].AppendFormat("{0}");
					this.SPRank.text = this.SPStrings[3].ToString();
					this.SPRank.SetAllDirty();
					this.SPRank.cachedTextGenerator.Invalidate();
					if (UILeaderBoard.SPRankChange > 0)
					{
						this.SPRank.gameObject.SetActive(true);
						this.SPRankUpDown.GetComponent<UISpritesArray>().SetSpriteIndex(0);
						this.SPRankUpDown.gameObject.SetActive(true);
					}
					else if (UILeaderBoard.SPRankChange < 0)
					{
						this.SPRank.gameObject.SetActive(true);
						this.SPRankUpDown.GetComponent<UISpritesArray>().SetSpriteIndex(1);
						this.SPRankUpDown.gameObject.SetActive(true);
					}
					else
					{
						this.SPRank.gameObject.SetActive(false);
					}
					color3 = Color.white;
					color3.a = 0f;
					this.SPRank.color = color3;
					this.SPRankUpDown.color = color3;
				}
				float num7 = Mathf.InverseLerp(this.SPShowTiming[2], this.SPShowTiming[1], this.SPShowTime);
				color3 = this.SPScoreFly.color;
				color3.a = num7;
				this.SPScoreFly.color = color3;
				num7 = Mathf.InverseLerp(this.SPShowTiming[0], this.SPShowTiming[2], this.SPShowTime);
				this.SPScoreFly.rectTransform.anchoredPosition = Vector2.Lerp(new Vector2(0f, -265f), this.SPScore.rectTransform.anchoredPosition, num7);
			}
			else if (this.SPShowTime < this.SPShowTiming[3])
			{
				if (this.SPShowPhase < 3f)
				{
					this.SPShowPhase = 3f;
					this.SPScoreFly.gameObject.SetActive(false);
					this.SPScore.color = Color.yellow;
				}
				if (!GUIManager.Instance.IsArabic)
				{
					this.SPScore.rectTransform.localScale = Vector2.one * Mathf.Lerp(0.5f, 0.8f, Mathf.InverseLerp(this.SPShowTiming[2], this.SPShowTiming[3], this.SPShowTime));
				}
				else
				{
					this.SPScore.rectTransform.localScale = new Vector2(-1f, 1f) * Mathf.Lerp(0.5f, 0.8f, Mathf.InverseLerp(this.SPShowTiming[2], this.SPShowTiming[3], this.SPShowTime));
				}
			}
			else if (this.SPShowTime < this.SPShowTiming[4])
			{
				if (this.SPShowPhase < 4f)
				{
					this.SPShowPhase = 4f;
					AudioManager.Instance.PlaySFX(40044, 0f, PitchKind.NoPitch, null, null);
				}
				this.SPStrings[1].ClearString();
				this.SPStrings[1].IntToFormat((long)((int)Mathf.Lerp((float)UILeaderBoard.SPScoreValue, (float)(UILeaderBoard.SPScoreValue + UILeaderBoard.SPScoreFlyValue), Mathf.InverseLerp(this.SPShowTiming[3], this.SPShowTiming[4], this.SPShowTime))), 1, true);
				this.SPStrings[1].AppendFormat("{0}");
				this.SPScore.text = this.SPStrings[1].ToString();
				this.SPScore.SetAllDirty();
				this.SPScore.cachedTextGenerator.Invalidate();
			}
			else if (this.SPShowTime < this.SPShowTiming[5])
			{
				if (this.SPShowPhase < 5f)
				{
					this.SPShowPhase = 5f;
					this.SPStrings[1].ClearString();
					this.SPStrings[1].IntToFormat((long)(UILeaderBoard.SPScoreValue + UILeaderBoard.SPScoreFlyValue), 1, true);
					this.SPStrings[1].AppendFormat("{0}");
					this.SPScore.text = this.SPStrings[1].ToString();
					this.SPScore.SetAllDirty();
					this.SPScore.cachedTextGenerator.Invalidate();
					AudioManager.Instance.PlaySFX(40045, 0f, PitchKind.NoPitch, null, null);
				}
				float a2 = Mathf.InverseLerp(this.SPShowTiming[4], this.SPShowTiming[5], this.SPShowTime);
				Color white = Color.white;
				white.a = a2;
				this.SPRank.color = white;
				this.SPRankUpDown.color = white;
				if (!GUIManager.Instance.IsArabic)
				{
					this.SPScore.rectTransform.localScale = Vector2.one * Mathf.Lerp(0.6f, 2f, Mathf.InverseLerp(this.SPShowTiming[4], this.SPShowTiming[5], this.SPShowTime));
				}
				else
				{
					this.SPScore.rectTransform.localScale = new Vector2(-1f, 1f) * Mathf.Lerp(0.6f, 2f, Mathf.InverseLerp(this.SPShowTiming[4], this.SPShowTiming[5], this.SPShowTime));
				}
			}
			else if (this.SPShowTime < this.SPShowTiming[6])
			{
				if (!GUIManager.Instance.IsArabic)
				{
					this.SPScore.rectTransform.localScale = Vector2.one * Mathf.Lerp(2f, 1f, Mathf.InverseLerp(this.SPShowTiming[5], this.SPShowTiming[6], this.SPShowTime));
				}
				else
				{
					this.SPScore.rectTransform.localScale = new Vector2(-1f, 1f) * Mathf.Lerp(2f, 1f, Mathf.InverseLerp(this.SPShowTiming[5], this.SPShowTiming[6], this.SPShowTime));
				}
			}
			else if (this.SPShowTime < this.SPShowTiming[7])
			{
				if (!GUIManager.Instance.IsArabic)
				{
					this.SPScore.rectTransform.localScale = Vector2.one;
				}
				else
				{
					this.SPScore.rectTransform.localScale = new Vector2(-1f, 1f);
				}
			}
			else if (this.SPShowTime < this.SPShowTiming[8])
			{
				float num8 = Mathf.InverseLerp(this.SPShowTiming[8], this.SPShowTiming[7], this.SPShowTime);
				Color color4 = Color.white;
				color4.a = num8 * 0.8f;
				this.SPBG.color = color4;
				color4 = Color.white;
				color4.a = num8;
				this.SPRank.color = color4;
				this.SPRankUpDown.color = color4;
				this.SPScore.color = color4;
				color4 = this.SPName.color;
				color4.a = num8;
				this.SPName.color = color4;
			}
			else if (this.SPShowTime > this.SPShowTiming[8])
			{
				this.SPBG.gameObject.SetActive(false);
				UILeaderBoard.ShowSP = false;
				this.SPShowTime = 0f;
			}
		}
	}

	// Token: 0x06001374 RID: 4980 RVA: 0x0022A9B4 File Offset: 0x00228BB4
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelId != 1)
		{
			if (panelId == 2)
			{
				switch (this.OpenKind)
				{
				case UI_LeaderBoardOpenKind.Alli_Inter:
				case UI_LeaderBoardOpenKind.OtherAlli_inter:
					this.UpdatRow_Alli(item, dataIdx, panelObjectIdx);
					break;
				case UI_LeaderBoardOpenKind.BoardMenu:
					if (UILeaderBoard.WorldBoard)
					{
						this.UpdatRow_WorldRanking_Boards(item, dataIdx, panelObjectIdx);
					}
					else
					{
						this.UpdatRow_Boards(item, dataIdx, panelObjectIdx);
					}
					break;
				case UI_LeaderBoardOpenKind.ArenaBoard:
					this.UpdatRow_Boards(item, dataIdx, panelObjectIdx);
					break;
				case UI_LeaderBoardOpenKind.MobilizationGroupBoard:
					this.UpdatRow_MobiGroup(item, dataIdx, panelObjectIdx);
					break;
				case UI_LeaderBoardOpenKind.MobilizationAlliBoard:
					this.UpdatRow_MobiAlli(item, dataIdx, panelObjectIdx);
					break;
				case UI_LeaderBoardOpenKind.WorldKingHistory:
					this.UpdatRow_MobilizationWorldKing(item, dataIdx, panelObjectIdx);
					break;
				case UI_LeaderBoardOpenKind.KingofWorldRankingBoard:
					this.UpdatRow_KingofWorld(item, dataIdx, panelObjectIdx);
					break;
				}
			}
		}
		else if (UILeaderBoard.WorldBoard)
		{
			this.UpdateRow_WorldRanking_FunctionList(item, dataIdx, panelObjectIdx);
		}
		else
		{
			this.UpdateRow_FunctionList(item, dataIdx, panelObjectIdx);
		}
	}

	// Token: 0x06001375 RID: 4981 RVA: 0x0022AAB4 File Offset: 0x00228CB4
	public void SetHiBtnAndText()
	{
		Transform child = this.AGS_Form.GetChild(3).GetChild(0);
		GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, LeaderBoardManager.Instance.KingHead, 11, 0, 0);
		UIText component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
		if (LeaderBoardManager.Instance.MobiWorldKingBoard.Count > 0)
		{
			GameConstants.FormatRoleName(this.RankValue, LeaderBoardManager.Instance.MobiWorldKingBoard[0].Name, LeaderBoardManager.Instance.MobiWorldKingBoard[0].AllianceTag, null, 0, LeaderBoardManager.Instance.MobiWorldKingBoard[0].HomeKingdomID, null, null, null, null);
			component.text = this.RankValue.ToString();
		}
		if (ActivityManager.Instance.KOWData.EventState == EActivityState.EAS_Run || ActivityManager.Instance.KOWData.EventState == EActivityState.EAS_Prepare)
		{
			child.gameObject.SetActive(false);
			component.gameObject.SetActive(false);
		}
		else
		{
			child.gameObject.SetActive(true);
			component.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001376 RID: 4982 RVA: 0x0022ABDC File Offset: 0x00228DDC
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001377 RID: 4983 RVA: 0x0022ABE0 File Offset: 0x00228DE0
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		switch (btnID)
		{
		case 0:
			if (UILeaderBoard.isTopBoard || this.OpenKind != UI_LeaderBoardOpenKind.BoardMenu)
			{
				this.door.CloseMenu(false);
				UILeaderBoard.NewOpen = true;
			}
			else
			{
				UILeaderBoard.TopIndex[(int)UILeaderBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
				if (UILeaderBoard.WorldBoard)
				{
					this.WorldRankingMainBoardChange();
				}
				else
				{
					this.MainBoardChange();
				}
			}
			break;
		case 1:
			DataManager.Instance.ShowLordProfile(UILeaderBoard.SortedAlliInterList[sender.m_BtnID2].Name.ToString());
			UILeaderBoard.TopIndex[12] = this.AGS_Panel2.GetTopIdx();
			break;
		case 2:
			UILeaderBoard.isPersonBoard = (sender.m_BtnID2 == 1);
			UILeaderBoard.TopIndex[(int)UILeaderBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
			if (UILeaderBoard.WorldBoard)
			{
				this.WorldRankingMainBoardChange();
			}
			else
			{
				this.MainBoardChange();
			}
			break;
		case 3:
			switch (sender.m_BtnID2)
			{
			case 0:
				if (LeaderBoardManager.Instance.TopBoard.PowerTop.Value == 0UL)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8476u), 255, true);
					return;
				}
				break;
			case 1:
				if (LeaderBoardManager.Instance.TopBoard.KillsTop.Value == 0UL)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8476u), 255, true);
					return;
				}
				break;
			case 2:
				if (LeaderBoardManager.Instance.TopBoard.AlliPowerTop.Value == 0UL)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8476u), 255, true);
					return;
				}
				break;
			case 3:
				if (LeaderBoardManager.Instance.TopBoard.AlliKillsTop.Value == 0UL)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8476u), 255, true);
					return;
				}
				break;
			case 4:
				if (LeaderBoardManager.isOpenArena() != 0)
				{
					return;
				}
				break;
			case 8:
			case 9:
			case 10:
			case 11:
				this.WorldRankingSubBoardChange((byte)sender.m_BtnID2);
				return;
			}
			this.SubBoardChange((byte)sender.m_BtnID2);
			break;
		case 4:
			if (UILeaderBoard.isPersonBoard)
			{
				if (UILeaderBoard.SubBoardID != 4 || LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][sender.m_BtnID2].Value != 1UL)
				{
					DataManager.Instance.ShowLordProfile(LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][sender.m_BtnID2].Name.ToString());
					UILeaderBoard.TopIndex[(int)UILeaderBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
				}
			}
			else
			{
				UILeaderBoard.TopIndex[(int)UILeaderBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
				DataManager.Instance.AllianceView.Id = ((BoardUnitAlliance)LeaderBoardManager.Instance.Boards[(int)UILeaderBoard.SubBoardID][sender.m_BtnID2]).AllianceID;
				this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5, 0, false);
			}
			break;
		case 5:
		{
			LeaderBoardManager.Instance.hintTarget = sender.GetComponent<UIButtonHint>();
			LeaderBoardManager.Instance.hintCenter = this.AGS_Form;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_BOARDDATA;
			messagePacket.AddSeqId();
			messagePacket.Add((byte)sender.m_BtnID2);
			messagePacket.Send(false);
			break;
		}
		case 6:
		{
			this.door.AllianceInfo(LeaderBoardManager.Instance.MobiGroupBoard[sender.m_BtnID2].AllianceTag.ToString());
			int topIdx = this.AGS_Panel2.GetTopIdx();
			if (topIdx > 0)
			{
				UILeaderBoard.TopIndex[13] = topIdx;
			}
			else
			{
				UILeaderBoard.TopIndex[13] = 1;
			}
			break;
		}
		case 7:
		{
			ActivityManager.Instance.Send_ACTIVITY_AM_RANKING_PRIZE();
			int topIdx2 = this.AGS_Panel2.GetTopIdx();
			if (topIdx2 > 0)
			{
				UILeaderBoard.TopIndex[13] = topIdx2;
			}
			else
			{
				UILeaderBoard.TopIndex[13] = 1;
			}
			break;
		}
		case 8:
			if (sender.m_BtnID2 <= LeaderBoardManager.Instance.MobiWorldKingBoard.Count && sender.m_BtnID2 >= 0)
			{
				UILeaderBoard.TopIndex[15] = this.AGS_Panel2.GetTopIdx();
				DataManager.Instance.ShowLordProfile(LeaderBoardManager.Instance.MobiWorldKingBoard[sender.m_BtnID2].Name.ToString());
			}
			break;
		case 9:
			if (!UILeaderBoard.WorldBoard)
			{
				if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 25)
				{
					GUIManager.Instance.MsgStr.ClearString();
					GUIManager.Instance.MsgStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9566u));
					GUIManager.Instance.MsgStr.IntToFormat(25L, 1, false);
					GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9749u));
					GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), 255, true);
					return;
				}
				UILeaderBoard.WorldBoard = true;
				this.WorldRankingMainBoardChange();
			}
			else
			{
				UILeaderBoard.WorldBoard = false;
				this.MainBoardChange();
			}
			break;
		case 10:
			if (sender.m_BtnID2 < LeaderBoardManager.Instance.KingofWorldBoard.Count && sender.m_BtnID2 >= 0)
			{
				DataManager.Instance.ShowLordProfile(LeaderBoardManager.Instance.KingofWorldBoard[sender.m_BtnID2].Name.ToString());
			}
			break;
		default:
			if (btnID == 99)
			{
				if (this.OpenKind == UI_LeaderBoardOpenKind.WorldKingHistory)
				{
					GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(11030u), DataManager.Instance.mStringTable.GetStringByID(11013u), null, null, 0, 0, false, true);
				}
				else
				{
					GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7028u), DataManager.Instance.mStringTable.GetStringByID(9041u), null, null, 0, 0, true, false);
				}
			}
			break;
		}
	}

	// Token: 0x06001378 RID: 4984 RVA: 0x0022B288 File Offset: 0x00229488
	public void Refresh_FontTexture()
	{
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		if (this.SPName != null && this.SPName.enabled)
		{
			this.SPName.enabled = false;
			this.SPName.enabled = true;
		}
		if (this.SPScore != null && this.SPScore.enabled)
		{
			this.SPScore.enabled = false;
			this.SPScore.enabled = true;
		}
		if (this.SPScoreFly != null && this.SPScoreFly.enabled)
		{
			this.SPScoreFly.enabled = false;
			this.SPScoreFly.enabled = true;
		}
		if (this.SPRank != null && this.SPRank.enabled)
		{
			this.SPRank.enabled = false;
			this.SPRank.enabled = true;
		}
		if (this.AGS_Panel1 != null && this.AGS_Panel1.gameObject.activeInHierarchy)
		{
			Transform child = this.AGS_Panel1.transform.GetChild(0);
			for (int i = 0; i < child.childCount; i++)
			{
				Transform child2 = child.GetChild(i);
				if (child2.gameObject.activeInHierarchy)
				{
					component = child2.GetChild(4).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child2.GetChild(5).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child2.GetChild(6).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
				}
			}
		}
		if (this.AGS_Panel2 != null && this.AGS_Panel2.gameObject.activeInHierarchy)
		{
			Transform child3 = this.AGS_Panel2.transform.GetChild(0);
			for (int j = 0; j < child3.childCount; j++)
			{
				Transform child4 = child3.GetChild(j);
				if (child4.GetChild(0).gameObject.activeInHierarchy)
				{
					component = child4.GetChild(0).GetChild(4).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child4.GetChild(0).GetChild(5).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child4.GetChild(0).GetChild(6).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child4.GetChild(0).GetChild(7).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
				}
				if (child4.GetChild(1).gameObject.activeInHierarchy)
				{
					component = child4.GetChild(1).GetChild(4).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child4.GetChild(1).GetChild(5).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child4.GetChild(1).GetChild(6).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child4.GetChild(1).GetChild(7).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child4.GetChild(1).GetChild(9).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
				}
			}
		}
		component = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(14).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(14).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(14).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(14).GetChild(4).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
	}

	// Token: 0x04003B26 RID: 15142
	private Transform AGS_Form;

	// Token: 0x04003B27 RID: 15143
	private ScrollPanel AGS_Panel1;

	// Token: 0x04003B28 RID: 15144
	private ScrollPanel AGS_Panel2;

	// Token: 0x04003B29 RID: 15145
	private Door door;

	// Token: 0x04003B2A RID: 15146
	private float GetPointTime;

	// Token: 0x04003B2B RID: 15147
	private Image POPLight1;

	// Token: 0x04003B2C RID: 15148
	private Image POPLight3;

	// Token: 0x04003B2D RID: 15149
	private RectTransform KingdomImg;

	// Token: 0x04003B2E RID: 15150
	private bool LoadComplet;

	// Token: 0x04003B2F RID: 15151
	private bool DataReady;

	// Token: 0x04003B30 RID: 15152
	private List<float> SPHeight;

	// Token: 0x04003B31 RID: 15153
	private UI_LeaderBoardOpenKind OpenKind;

	// Token: 0x04003B32 RID: 15154
	private static List<AllianceBoardData> SortedAlliInterList;

	// Token: 0x04003B33 RID: 15155
	private CString[,] SortTextArray = new CString[4, 12];

	// Token: 0x04003B34 RID: 15156
	private CString Ranking;

	// Token: 0x04003B35 RID: 15157
	private CString RankValue;

	// Token: 0x04003B36 RID: 15158
	private CString HintStr;

	// Token: 0x04003B37 RID: 15159
	private ushort MyRank;

	// Token: 0x04003B38 RID: 15160
	public static int[] TopIndex = new int[16];

	// Token: 0x04003B39 RID: 15161
	private uint m_targetAllianceID;

	// Token: 0x04003B3A RID: 15162
	public static byte SubBoardID;

	// Token: 0x04003B3B RID: 15163
	public static bool isTopBoard = true;

	// Token: 0x04003B3C RID: 15164
	public static bool isPersonBoard = true;

	// Token: 0x04003B3D RID: 15165
	public static bool NewOpen;

	// Token: 0x04003B3E RID: 15166
	public static bool WorldBoard = false;

	// Token: 0x04003B3F RID: 15167
	private static readonly int[] MobiGroupBoardSize = new int[]
	{
		102,
		80,
		307,
		287
	};

	// Token: 0x04003B40 RID: 15168
	private static readonly int[] MobiAlliBoardSize = new int[]
	{
		102,
		307,
		184,
		183
	};

	// Token: 0x04003B41 RID: 15169
	private static readonly int[] MobiWorldKingBoardSize = new int[]
	{
		330,
		189,
		257,
		257
	};

	// Token: 0x04003B42 RID: 15170
	private static readonly int[] CommonBoardSize = new int[]
	{
		102,
		385,
		289
	};

	// Token: 0x04003B43 RID: 15171
	private bool SPReady;

	// Token: 0x04003B44 RID: 15172
	private Image SPBG;

	// Token: 0x04003B45 RID: 15173
	private Image SPRankUpDown;

	// Token: 0x04003B46 RID: 15174
	private UIText SPName;

	// Token: 0x04003B47 RID: 15175
	private UIText SPScore;

	// Token: 0x04003B48 RID: 15176
	private UIText SPScoreFly;

	// Token: 0x04003B49 RID: 15177
	private UIText SPRank;

	// Token: 0x04003B4A RID: 15178
	private CString[] SPStrings = new CString[4];

	// Token: 0x04003B4B RID: 15179
	private RectTransform SPFly;

	// Token: 0x04003B4C RID: 15180
	private float SPShowTime;

	// Token: 0x04003B4D RID: 15181
	private float SPShowPhase;

	// Token: 0x04003B4E RID: 15182
	private float[] SPShowTiming = new float[]
	{
		0.4f,
		0.2f,
		0.05f,
		0.1f,
		0.4f,
		0.1f,
		0.1f,
		0.8f,
		0.4f
	};

	// Token: 0x04003B4F RID: 15183
	public static bool ShowSP = false;

	// Token: 0x04003B50 RID: 15184
	public static int SPScoreValue = 0;

	// Token: 0x04003B51 RID: 15185
	public static int SPScoreFlyValue = 0;

	// Token: 0x04003B52 RID: 15186
	public static int SPRankChange = 0;

	// Token: 0x0200039E RID: 926
	private enum e_AGS_UI_LeaderBoard_Editor
	{
		// Token: 0x04003B54 RID: 15188
		BGFrame,
		// Token: 0x04003B55 RID: 15189
		BGFrameTitle,
		// Token: 0x04003B56 RID: 15190
		Laurel,
		// Token: 0x04003B57 RID: 15191
		PlayerSelf,
		// Token: 0x04003B58 RID: 15192
		SwitchTags,
		// Token: 0x04003B59 RID: 15193
		CenterText,
		// Token: 0x04003B5A RID: 15194
		FunctionlPanel,
		// Token: 0x04003B5B RID: 15195
		LeaderBoardPanel,
		// Token: 0x04003B5C RID: 15196
		exitImage,
		// Token: 0x04003B5D RID: 15197
		iButton,
		// Token: 0x04003B5E RID: 15198
		AMRank,
		// Token: 0x04003B5F RID: 15199
		RankReward,
		// Token: 0x04003B60 RID: 15200
		BoardSwitch,
		// Token: 0x04003B61 RID: 15201
		EmptyDial,
		// Token: 0x04003B62 RID: 15202
		ScoreChange
	}

	// Token: 0x0200039F RID: 927
	private enum e_AGS_PlayerSelf
	{
		// Token: 0x04003B64 RID: 15204
		UIHIBtn,
		// Token: 0x04003B65 RID: 15205
		Alliance,
		// Token: 0x04003B66 RID: 15206
		Position,
		// Token: 0x04003B67 RID: 15207
		Power
	}

	// Token: 0x020003A0 RID: 928
	private enum e_AGS_SwitchTags
	{
		// Token: 0x04003B69 RID: 15209
		Players,
		// Token: 0x04003B6A RID: 15210
		Alliance
	}

	// Token: 0x020003A1 RID: 929
	private enum e_AGS_FunctionlPanel
	{
		// Token: 0x04003B6C RID: 15212
		Panel1,
		// Token: 0x04003B6D RID: 15213
		Panel1Item,
		// Token: 0x04003B6E RID: 15214
		KingdomIcon
	}

	// Token: 0x020003A2 RID: 930
	private enum e_AGS_Panel1Item
	{
		// Token: 0x04003B70 RID: 15216
		TitleBG,
		// Token: 0x04003B71 RID: 15217
		ColBG,
		// Token: 0x04003B72 RID: 15218
		Alliance,
		// Token: 0x04003B73 RID: 15219
		UIHIBtn,
		// Token: 0x04003B74 RID: 15220
		Title,
		// Token: 0x04003B75 RID: 15221
		Name,
		// Token: 0x04003B76 RID: 15222
		Value,
		// Token: 0x04003B77 RID: 15223
		Arrow
	}

	// Token: 0x020003A3 RID: 931
	private enum e_AGS_LeaderBoardPanel
	{
		// Token: 0x04003B79 RID: 15225
		Panel2,
		// Token: 0x04003B7A RID: 15226
		Panel2Item
	}

	// Token: 0x020003A4 RID: 932
	private enum e_AGS_Panel2Item
	{
		// Token: 0x04003B7C RID: 15228
		Title,
		// Token: 0x04003B7D RID: 15229
		Block
	}

	// Token: 0x020003A5 RID: 933
	public enum e_AGS_Block
	{
		// Token: 0x04003B7F RID: 15231
		BG1,
		// Token: 0x04003B80 RID: 15232
		BG2,
		// Token: 0x04003B81 RID: 15233
		BG3,
		// Token: 0x04003B82 RID: 15234
		BG4,
		// Token: 0x04003B83 RID: 15235
		Rank,
		// Token: 0x04003B84 RID: 15236
		Name,
		// Token: 0x04003B85 RID: 15237
		KindVar,
		// Token: 0x04003B86 RID: 15238
		change,
		// Token: 0x04003B87 RID: 15239
		updown,
		// Token: 0x04003B88 RID: 15240
		updowntext,
		// Token: 0x04003B89 RID: 15241
		SearchBtn,
		// Token: 0x04003B8A RID: 15242
		ArenaBtn,
		// Token: 0x04003B8B RID: 15243
		ArenaBGBtn
	}

	// Token: 0x020003A6 RID: 934
	private enum e_AGS_ScoreChange
	{
		// Token: 0x04003B8D RID: 15245
		name,
		// Token: 0x04003B8E RID: 15246
		score,
		// Token: 0x04003B8F RID: 15247
		scorefly,
		// Token: 0x04003B90 RID: 15248
		updown,
		// Token: 0x04003B91 RID: 15249
		updownRanking
	}

	// Token: 0x020003A7 RID: 935
	private enum e_OpenType
	{
		// Token: 0x04003B93 RID: 15251
		BoardTypes,
		// Token: 0x04003B94 RID: 15252
		BoardContent
	}

	// Token: 0x020003A8 RID: 936
	private enum UIRecallMemoryPos
	{
		// Token: 0x04003B96 RID: 15254
		PlayerPower,
		// Token: 0x04003B97 RID: 15255
		PlayerKills,
		// Token: 0x04003B98 RID: 15256
		AlliancePower,
		// Token: 0x04003B99 RID: 15257
		ALLianceKill,
		// Token: 0x04003B9A RID: 15258
		Arena,
		// Token: 0x04003B9B RID: 15259
		KVKKingdom,
		// Token: 0x04003B9C RID: 15260
		KVKAllianceRank,
		// Token: 0x04003B9D RID: 15261
		KVKAllianceMemberRank,
		// Token: 0x04003B9E RID: 15262
		World_PlayerPower,
		// Token: 0x04003B9F RID: 15263
		World_PlayerKills,
		// Token: 0x04003BA0 RID: 15264
		World_AlliancePower,
		// Token: 0x04003BA1 RID: 15265
		World_ALLianceKill,
		// Token: 0x04003BA2 RID: 15266
		AlliancePublic,
		// Token: 0x04003BA3 RID: 15267
		MobilizationGroupBoard,
		// Token: 0x04003BA4 RID: 15268
		MobilizationAllianceBoard,
		// Token: 0x04003BA5 RID: 15269
		KingOfWorldHistoryBoard,
		// Token: 0x04003BA6 RID: 15270
		Max
	}
}
