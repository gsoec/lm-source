using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000397 RID: 919
public class UIAlliVSGroupBoard : UILeaderBoardBase
{
	// Token: 0x0600130F RID: 4879 RVA: 0x00212BEC File Offset: 0x00210DEC
	public override void OnOpen(int arg1, int arg2)
	{
		base.OnOpen(arg1, arg2);
		UIButton component = this.AGS_Form.GetChild(10).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Normal;
		component.transition = Selectable.Transition.None;
		component.m_BtnID1 = 12;
		UIButtonHint uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.UIArena_Hint;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
		uibuttonHint.ScrollID = 1;
		this.HintStr = StringManager.Instance.SpawnString(300);
		if (LeaderBoardManager.Instance.AllianceWarGroupBoardUpdateTime < DataManager.Instance.ServerTime || LeaderBoardManager.Instance.MobiGroupAllianceID != DataManager.Instance.RoleAlliance.Id)
		{
			UILeaderBoardBase.TopIndex[19] = 0;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_RANK;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			this.DataReady = false;
		}
		else
		{
			this.DataReady = true;
		}
		GameObject gameObject = new GameObject("Text1");
		gameObject.transform.SetParent(this.AGS_Form.GetChild(10).transform, false);
		RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
		rectTransform.anchoredPosition = new Vector2(0f, 0f);
		rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 44f);
		rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 44f);
		UIText uitext = gameObject.AddComponent<UIText>();
		uitext.font = GUIManager.Instance.GetTTFFont();
		uitext.resizeTextForBestFit = true;
		uitext.resizeTextMinSize = 24;
		uitext.resizeTextMaxSize = 30;
		uitext.alignment = TextAnchor.LowerCenter;
		uitext.text = string.Empty;
		this.Text1 = uitext;
		gameObject.AddComponent<Outline>();
		gameObject.AddComponent<Shadow>();
	}

	// Token: 0x06001310 RID: 4880 RVA: 0x00212DB8 File Offset: 0x00210FB8
	public override void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.HintStr);
		base.OnClose();
	}

	// Token: 0x06001311 RID: 4881 RVA: 0x00212DD4 File Offset: 0x00210FD4
	private void CreateAlliVSBoard()
	{
		this.SPHeight.Clear();
		this.SPHeight.Add(38f);
		ushort num = 0;
		while ((int)num < LeaderBoardManager.Instance.AllianceWarGroupBoard.Count)
		{
			this.SPHeight.Add(53f);
			num += 1;
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID(7091u);
		this.AGS_Form.GetChild(2).gameObject.SetActive(true);
		this.AGS_Form.GetChild(5).gameObject.SetActive(true);
		component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
		this.Ranking.ClearString();
		this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.AllianceWarGroupRank, 1, false);
		this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9856u));
		component.text = this.Ranking.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		Image component2 = this.AGS_Form.GetChild(10).GetComponent<Image>();
		component2.gameObject.SetActive(true);
		GUIManager.Instance.SetAllyWarRankImage(component2, ActivityManager.Instance.AW_Rank);
		this.Text1.text = ActivityManager.Instance.AW_Rank.ToString();
		RectTransform component3 = this.Text1.gameObject.GetComponent<RectTransform>();
		if (ActivityManager.Instance.AW_Rank > 20)
		{
			component3.anchoredPosition = Vector2.zero;
		}
		else
		{
			component3.anchoredPosition = new Vector2(0f, 5f);
		}
		UIButton component4 = this.AGS_Form.GetChild(10).GetComponent<UIButton>();
		component4.m_Handler = this;
		component4.m_EffectType = e_EffectType.e_Normal;
		component4.transition = Selectable.Transition.None;
		component4.m_BtnID1 = 12;
		UIButtonHint uibuttonHint = component4.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.UIArena_Hint;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
		uibuttonHint.ScrollID = 1;
	}

	// Token: 0x06001312 RID: 4882 RVA: 0x00213010 File Offset: 0x00211210
	public void Update()
	{
		if (!this.LoadComplet)
		{
			this.UpdateScrollSize();
			this.LoadComplet = true;
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
		}
		if (this.DataReady && this.LoadComplet)
		{
			this.DataReady = false;
			this.CreateAlliVSBoard();
			base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
			this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
			if (UILeaderBoardBase.TopIndex[19] == 0 && UIAlliVSGroupBoard.NewOpen)
			{
				UIAlliVSGroupBoard.NewOpen = false;
				if (LeaderBoardManager.Instance.AllianceWarGroupRank > 4)
				{
					UILeaderBoardBase.TopIndex[19] = LeaderBoardManager.Instance.AllianceWarGroupRank - 3;
				}
			}
			this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[19]);
		}
	}

	// Token: 0x06001313 RID: 4883 RVA: 0x00213174 File Offset: 0x00211374
	public override void UpdateUI(int arg1, int arg2)
	{
		this.CreateAlliVSBoard();
		if (!this.LoadComplet)
		{
			this.DataReady = true;
		}
		else
		{
			base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
			this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
			if (UILeaderBoardBase.TopIndex[19] == 0 && UIAlliVSGroupBoard.NewOpen)
			{
				UIAlliVSGroupBoard.NewOpen = false;
				if (LeaderBoardManager.Instance.AllianceWarGroupRank > 4)
				{
					UILeaderBoardBase.TopIndex[19] = LeaderBoardManager.Instance.AllianceWarGroupRank - 3;
				}
			}
			this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[19]);
		}
	}

	// Token: 0x06001314 RID: 4884 RVA: 0x0021320C File Offset: 0x0021140C
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				base.Refresh_FontTexture();
			}
		}
		else if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Chat) != null)
		{
			this.door.CloseMenu_Alliance(EGUIWindow.UI_LeaderBoard);
		}
		else
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001315 RID: 4885 RVA: 0x00213278 File Offset: 0x00211478
	public override void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
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
			component.text = DataManager.Instance.mStringTable.GetStringByID(17034u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(7094u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(7).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(17039u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			item.transform.GetChild(1).GetChild(10).gameObject.SetActive(true);
			item.transform.GetChild(1).GetChild(12).gameObject.SetActive(true);
			this.SortTextArray[0, panelObjectIdx].ClearString();
			this.SortTextArray[0, panelObjectIdx].IntToFormat((long)dataIdx, 1, false);
			this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
			UIText component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
			component.text = this.SortTextArray[0, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[1, panelObjectIdx].ClearString();
			GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], 0, LeaderBoardManager.Instance.AllianceWarGroupBoard[dataIdx - 1].Name, LeaderBoardManager.Instance.AllianceWarGroupBoard[dataIdx - 1].AllianceTag, false);
			component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
			component.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.AllianceWarGroupBoard[dataIdx - 1].Power, 1, true);
			this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
			component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
			component.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[3, panelObjectIdx].ClearString();
			this.SortTextArray[3, panelObjectIdx].IntToFormat((long)LeaderBoardManager.Instance.AllianceWarGroupBoard[dataIdx - 1].Score, 1, true);
			this.SortTextArray[3, panelObjectIdx].AppendFormat("{0}");
			component = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
			component.text = this.SortTextArray[3, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			if (dataIdx == LeaderBoardManager.Instance.AllianceWarGroupRank)
			{
				UISpritesArray component2 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(2);
				component2 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(2);
				component2 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(2);
				component2 = item.transform.GetChild(1).GetChild(3).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(2);
			}
			else if (dataIdx % 2 == 0)
			{
				UISpritesArray component2 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(1);
				component2 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(1);
				component2 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(1);
				component2 = item.transform.GetChild(1).GetChild(3).GetComponent<UISpritesArray>();
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
				component2 = item.transform.GetChild(1).GetChild(3).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(0);
			}
			UIButton component3 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = 6;
			component3.m_BtnID2 = dataIdx - 1;
			component3 = item.transform.GetChild(1).GetChild(12).GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = 11;
			component3.m_BtnID2 = dataIdx;
			component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
			if (dataIdx <= (int)LeaderBoardManager.Instance.AllianceWarGroupRankUpNum)
			{
				component3.m_BtnID3 = 1;
				component.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
			}
			else if (dataIdx >= (int)LeaderBoardManager.Instance.AllianceWarGroupRankDownNum)
			{
				component3.m_BtnID3 = 2;
				component.color = new Color32(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
			else
			{
				component3.m_BtnID3 = 3;
				component.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
			}
			UIButtonHint component4 = item.transform.GetChild(1).GetChild(12).GetComponent<UIButtonHint>();
			component4.Parm1 = (ushort)dataIdx;
			component4.m_eHint = EUIButtonHint.DownUpHandler;
			component4.m_Handler = this;
			component4.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
		}
	}

	// Token: 0x06001316 RID: 4886 RVA: 0x00213970 File Offset: 0x00211B70
	public override void OnButtonClick(UIButton sender)
	{
		int topIdx = this.AGS_Panel2.GetTopIdx();
		if (topIdx > 0)
		{
			UILeaderBoardBase.TopIndex[19] = topIdx;
		}
		else
		{
			UILeaderBoardBase.TopIndex[19] = 1;
		}
		int btnID = sender.m_BtnID1;
		if (btnID != 0)
		{
			if (btnID == 6)
			{
				this.door.AllianceInfo(LeaderBoardManager.Instance.AllianceWarGroupBoard[sender.m_BtnID2].AlliacneID);
			}
		}
		else
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001317 RID: 4887 RVA: 0x002139FC File Offset: 0x00211BFC
	public override void OnButtonDown(UIButtonHint sender)
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
				this.HintStr.ClearString();
				this.HintStr.IntToFormat((long)ActivityManager.Instance.AW_Rank, 1, false);
				this.HintStr.IntToFormat((long)ActivityManager.Instance.AW_MemberCount, 1, false);
				this.HintStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17074u));
				GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.HintStr, new Vector2(70f, -50f));
			}
		}
		else
		{
			this.HintStr.ClearString();
			switch (uibutton.m_BtnID3)
			{
			case 1:
				this.HintStr.IntToFormat((long)uibutton.m_BtnID2, 1, false);
				this.HintStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17025u));
				break;
			case 2:
				this.HintStr.IntToFormat((long)uibutton.m_BtnID2, 1, false);
				this.HintStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17026u));
				break;
			case 3:
				this.HintStr.IntToFormat((long)uibutton.m_BtnID2, 1, false);
				this.HintStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17027u));
				break;
			}
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.HintStr, new Vector2(70f, -50f));
		}
	}

	// Token: 0x06001318 RID: 4888 RVA: 0x00213BD8 File Offset: 0x00211DD8
	public override void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(false);
	}

	// Token: 0x06001319 RID: 4889 RVA: 0x00213BEC File Offset: 0x00211DEC
	private void UpdateScrollSize()
	{
		int num = 0;
		RectTransform component = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<RectTransform>();
		RectTransform component2 = component.GetChild(0).GetChild(4).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)(num + UIAlliVSGroupBoard.VSBoardSize[0] / 2), component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)(UIAlliVSGroupBoard.VSBoardSize[0] - 2));
		component2 = component.transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliVSGroupBoard.VSBoardSize[0]);
		component2 = component.transform.GetChild(1).GetChild(0).GetComponent<RectTransform>();
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliVSGroupBoard.VSBoardSize[0]);
		component2 = component.transform.GetChild(1).GetChild(4).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)(num + UIAlliVSGroupBoard.VSBoardSize[0] / 2), component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)(UIAlliVSGroupBoard.VSBoardSize[0] - 20));
		num = UIAlliVSGroupBoard.VSBoardSize[0];
		component.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
		component.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
		component.transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
		component.transform.GetChild(1).GetChild(7).gameObject.SetActive(true);
		component2 = component.GetChild(0).GetChild(5).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)(num + UIAlliVSGroupBoard.VSBoardSize[1] / 2), component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliVSGroupBoard.VSBoardSize[1]);
		component2 = component.transform.GetChild(0).GetChild(1).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliVSGroupBoard.VSBoardSize[1]);
		component2 = component.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliVSGroupBoard.VSBoardSize[1]);
		component2 = component.transform.GetChild(1).GetChild(7).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)(num + 10), component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)(UIAlliVSGroupBoard.VSBoardSize[1] - 20));
		component2.GetComponent<UIText>().alignment = TextAnchor.MiddleCenter;
		num += UIAlliVSGroupBoard.VSBoardSize[1];
		component2 = component.transform.GetChild(0).GetChild(6).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)(num + UIAlliVSGroupBoard.VSBoardSize[2] / 2), component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliVSGroupBoard.VSBoardSize[2]);
		component2 = component.transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliVSGroupBoard.VSBoardSize[2]);
		component2 = component.GetChild(1).GetChild(5).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)(num + 10), component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)(UIAlliVSGroupBoard.VSBoardSize[2] - 20));
		component2 = component.transform.GetChild(1).GetChild(3).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliVSGroupBoard.VSBoardSize[2]);
		component2.gameObject.SetActive(true);
		num += UIAlliVSGroupBoard.VSBoardSize[2];
		component2 = component.transform.GetChild(0).GetChild(7).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)(num + UIAlliVSGroupBoard.VSBoardSize[3] / 2), component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliVSGroupBoard.VSBoardSize[3]);
		component2 = component.transform.GetChild(0).GetChild(3).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliVSGroupBoard.VSBoardSize[3]);
		component2 = component.transform.GetChild(1).GetChild(6).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)(num + 10), component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)(UIAlliVSGroupBoard.VSBoardSize[3] - 96));
		component2.GetComponent<UIText>().alignment = TextAnchor.MiddleRight;
		component2 = component.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliVSGroupBoard.VSBoardSize[3]);
		UIButton component3 = component.transform.GetChild(1).GetChild(12).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.gameObject.SetActive(true);
		UIButtonHint uibuttonHint = component3.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
		component2 = component3.GetComponent<RectTransform>();
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliVSGroupBoard.VSBoardSize[1]);
		component.transform.GetChild(1).GetChild(10).gameObject.SetActive(true);
	}

	// Token: 0x04003B00 RID: 15104
	private static readonly int[] VSBoardSize = new int[]
	{
		92,
		90,
		307,
		287
	};

	// Token: 0x04003B01 RID: 15105
	public static bool NewOpen;

	// Token: 0x04003B02 RID: 15106
	private CString HintStr;

	// Token: 0x04003B03 RID: 15107
	private UIText Text1;
}
