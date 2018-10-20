using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000395 RID: 917
public class UIAlliMobiWorldBoard : UILeaderBoardBase
{
	// Token: 0x060012FA RID: 4858 RVA: 0x00210634 File Offset: 0x0020E834
	public override void OnOpen(int arg1, int arg2)
	{
		base.OnOpen(arg1, arg2);
		RectTransform component = this.AGS_Form.GetChild(1).GetComponent<RectTransform>();
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 450f);
		component = component.GetChild(0).GetComponent<RectTransform>();
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 360f);
		this.Ranking = StringManager.Instance.SpawnString(300);
		UIButton component2 = this.AGS_Form.GetChild(10).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_EffectType = e_EffectType.e_Normal;
		component2.transition = Selectable.Transition.None;
		component2.m_BtnID1 = 12;
		UIButtonHint uibuttonHint = component2.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.UIArena_Hint;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = GUIManager.Instance.m_Arena_Hint.m_RectTransform.gameObject;
		uibuttonHint.ScrollID = 1;
		if (ActivityManager.Instance.AllyMobilizationData.EventState != EActivityState.EAS_ReplayRanking)
		{
			this.closeAfter = true;
			return;
		}
		this.closeAfter = false;
		if (LeaderBoardManager.Instance.MobilizationAlliWorldBoardTime < DataManager.Instance.ServerTime || LeaderBoardManager.Instance.MobiAlliWorldAllianceID != DataManager.Instance.RoleAlliance.Id)
		{
			UILeaderBoardBase.TopIndex[20] = 0;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEMOBILIZATION_LEGENDRANK;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
		}
		else
		{
			this.DataReady = true;
		}
	}

	// Token: 0x060012FB RID: 4859 RVA: 0x00210794 File Offset: 0x0020E994
	public override void OnClose()
	{
		base.OnClose();
		StringManager.Instance.DeSpawnString(this.HintStr);
	}

	// Token: 0x060012FC RID: 4860 RVA: 0x002107B0 File Offset: 0x0020E9B0
	public void Update()
	{
		if (this.closeAfter)
		{
			this.door.CloseMenu(false);
			return;
		}
		if (!this.LoadComplet)
		{
			base.SetDefaultSize();
			RectTransform component = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<RectTransform>();
			int num = UIAlliMobiWorldBoard.MobiGroupBoardSize[0];
			component.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
			component.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
			component.transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
			component.transform.GetChild(1).GetChild(9).gameObject.SetActive(true);
			RectTransform component2 = component.GetChild(0).GetChild(5).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)(num + UIAlliMobiWorldBoard.MobiGroupBoardSize[1] / 2), component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliMobiWorldBoard.MobiGroupBoardSize[1]);
			component2 = component.transform.GetChild(0).GetChild(1).GetComponent<RectTransform>();
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliMobiWorldBoard.MobiGroupBoardSize[1]);
			component2 = component.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliMobiWorldBoard.MobiGroupBoardSize[1]);
			num += UIAlliMobiWorldBoard.MobiGroupBoardSize[1];
			component2 = component.transform.GetChild(0).GetChild(6).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)(num + UIAlliMobiWorldBoard.MobiGroupBoardSize[2] / 2), component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliMobiWorldBoard.MobiGroupBoardSize[2]);
			component2 = component.transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliMobiWorldBoard.MobiGroupBoardSize[2]);
			component2 = component.GetChild(1).GetChild(5).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)(num + 10), component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)(UIAlliMobiWorldBoard.MobiGroupBoardSize[2] - 20));
			component2 = component.transform.GetChild(1).GetChild(3).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliMobiWorldBoard.MobiGroupBoardSize[2]);
			component2.gameObject.SetActive(true);
			num += UIAlliMobiWorldBoard.MobiGroupBoardSize[2];
			component2 = component.transform.GetChild(0).GetChild(7).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)(num + UIAlliMobiWorldBoard.MobiGroupBoardSize[3] / 2), component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliMobiWorldBoard.MobiGroupBoardSize[3]);
			component2 = component.transform.GetChild(0).GetChild(3).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliMobiWorldBoard.MobiGroupBoardSize[3]);
			component2 = component.transform.GetChild(1).GetChild(6).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)(num + 10), component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)(UIAlliMobiWorldBoard.MobiGroupBoardSize[3] - 116));
			component2.GetComponent<UIText>().alignment = TextAnchor.MiddleRight;
			component2 = component.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliMobiWorldBoard.MobiGroupBoardSize[3]);
			component2 = component.transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2(92.5f, component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 75f);
			Outline component3 = component2.GetComponent<Outline>();
			component3.effectColor = Color.black;
			UIButton component4 = component.transform.GetChild(1).GetChild(12).GetComponent<UIButton>();
			component4.gameObject.SetActive(false);
			component2 = component4.GetComponent<RectTransform>();
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UIAlliMobiWorldBoard.MobiGroupBoardSize[1]);
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
			this.RankValue = StringManager.Instance.SpawnString(30);
			this.HintStr = StringManager.Instance.SpawnString(500);
			Font ttffont = GUIManager.Instance.GetTTFFont();
			UIText component5 = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
			component5.font = ttffont;
			component5.text = DataManager.Instance.mStringTable.GetStringByID(11025u);
			Transform child = this.AGS_Form.GetChild(13).GetChild(1);
			if (child != null)
			{
				child.gameObject.SetActive(false);
			}
		}
		if (this.DataReady && this.LoadComplet)
		{
			this.DataReady = false;
			this.CreateMobilizationAlliWorldBoard(false);
			base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
			this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
			if (UILeaderBoardBase.TopIndex[20] == 0 && UIAlliMobiWorldBoard.NewOpen)
			{
				UIAlliMobiWorldBoard.NewOpen = false;
				if (LeaderBoardManager.Instance.MobilizationAlliWorldRank > 4)
				{
					UILeaderBoardBase.TopIndex[20] = LeaderBoardManager.Instance.MobilizationAlliWorldRank - 3;
				}
			}
			this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[20]);
		}
	}

	// Token: 0x060012FD RID: 4861 RVA: 0x00210DE4 File Offset: 0x0020EFE4
	public override void UpdateUI(int arg1, int arg2)
	{
		if ((byte)arg1 == 5)
		{
			this.door.CloseMenu(false);
			return;
		}
		if (arg1 == 2)
		{
			this.CreateMobilizationAlliWorldBoard(true);
			return;
		}
		this.CreateMobilizationAlliWorldBoard(false);
		if (!this.LoadComplet)
		{
			this.DataReady = true;
		}
		else
		{
			base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
			this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
		}
	}

	// Token: 0x060012FE RID: 4862 RVA: 0x00210E50 File Offset: 0x0020F050
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

	// Token: 0x060012FF RID: 4863 RVA: 0x00210EBC File Offset: 0x0020F0BC
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
			GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.MobilizationAlliWorldBoard[dataIdx - 1].KingdomID, LeaderBoardManager.Instance.MobilizationAlliWorldBoard[dataIdx - 1].Name, LeaderBoardManager.Instance.MobilizationAlliWorldBoard[dataIdx - 1].AllianceTag, false);
			component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
			component.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			this.SortTextArray[2, panelObjectIdx].uLongToFormat((ulong)LeaderBoardManager.Instance.MobilizationAlliWorldBoard[dataIdx - 1].Score, 1, true);
			this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
			component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
			component.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			UIButton component2 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 1;
			component2.m_BtnID2 = dataIdx - 1;
			this.SortTextArray[3, panelObjectIdx].ClearString();
			component = item.transform.GetChild(1).GetChild(9).GetComponent<UIText>();
			UISpritesArray component3 = item.transform.GetChild(1).GetChild(8).GetComponent<UISpritesArray>();
			if (LeaderBoardManager.Instance.MobilizationAlliWorldBoard[dataIdx - 1].State == 1)
			{
				this.SortTextArray[3, panelObjectIdx].IntToFormat((long)LeaderBoardManager.Instance.MobilizationAlliWorldBoard[dataIdx - 1].ChangeRank, 1, true);
				this.SortTextArray[3, panelObjectIdx].AppendFormat("{0}");
				component3.SetSpriteIndex(0);
				component3.gameObject.SetActive(true);
				component.gameObject.SetActive(true);
				component.color = Color.white;
				component.rectTransform.anchoredPosition = new Vector2(component.rectTransform.anchoredPosition.x, -19.5f);
			}
			else if (LeaderBoardManager.Instance.MobilizationAlliWorldBoard[dataIdx - 1].State == 2)
			{
				this.SortTextArray[3, panelObjectIdx].IntToFormat((long)LeaderBoardManager.Instance.MobilizationAlliWorldBoard[dataIdx - 1].ChangeRank, 1, true);
				this.SortTextArray[3, panelObjectIdx].AppendFormat("{0}");
				component3.SetSpriteIndex(1);
				component3.gameObject.SetActive(true);
				component.gameObject.SetActive(true);
				component.color = Color.white;
				component.rectTransform.anchoredPosition = new Vector2(component.rectTransform.anchoredPosition.x, -19.5f);
			}
			else if (LeaderBoardManager.Instance.MobilizationAlliWorldBoard[dataIdx - 1].State == 3)
			{
				this.SortTextArray[3, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(17250u));
				component3.gameObject.SetActive(false);
				component.gameObject.SetActive(true);
				component.color = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);
				component.rectTransform.anchoredPosition = new Vector2(component.rectTransform.anchoredPosition.x, -10f);
			}
			else
			{
				component3.gameObject.SetActive(false);
				component.gameObject.SetActive(false);
			}
			component.text = this.SortTextArray[3, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			if (dataIdx == LeaderBoardManager.Instance.MobilizationAlliWorldRank)
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
		}
	}

	// Token: 0x06001300 RID: 4864 RVA: 0x00211690 File Offset: 0x0020F890
	public override void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID != 0)
		{
			if (btnID != 1)
			{
				if (btnID != 7)
				{
					if (btnID == 99)
					{
						UILeaderBoardBase.TopIndex[20] = this.AGS_Panel2.GetTopIdx();
						GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7028u), DataManager.Instance.mStringTable.GetStringByID(9041u), null, null, 0, 0, true, false);
					}
				}
				else
				{
					UILeaderBoardBase.TopIndex[20] = this.AGS_Panel2.GetTopIdx();
					this.door.OpenMenu(EGUIWindow.UI_LeaderboardReward, 0, 0, false);
				}
			}
			else
			{
				UILeaderBoardBase.TopIndex[20] = this.AGS_Panel2.GetTopIdx();
				DataManager.Instance.AllianceView.Id = LeaderBoardManager.Instance.MobilizationAlliWorldBoard[sender.m_BtnID2].AlliacneID;
				this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5, 0, false);
			}
		}
		else
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001301 RID: 4865 RVA: 0x002117A4 File Offset: 0x0020F9A4
	public override void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		if (uibutton == null)
		{
			return;
		}
		int btnID = uibutton.m_BtnID1;
		if (btnID == 12)
		{
			uint id = 1028u - (uint)DataManager.Instance.RoleAlliance.AMRank;
			this.HintStr.ClearString();
			this.HintStr.Append(DataManager.Instance.mStringTable.GetStringByID(id));
			GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 300f, 20, this.HintStr, Vector2.zero);
		}
	}

	// Token: 0x06001302 RID: 4866 RVA: 0x00211844 File Offset: 0x0020FA44
	public override void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(false);
	}

	// Token: 0x06001303 RID: 4867 RVA: 0x00211858 File Offset: 0x0020FA58
	private void CreateMobilizationAlliWorldBoard(bool showNotReady = false)
	{
		this.SPHeight.Clear();
		this.SPHeight.Add(38f);
		int num = Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
		ushort num2 = 0;
		while ((int)num2 < LeaderBoardManager.Instance.MobilizationAlliWorldBoard.Count)
		{
			if (LeaderBoardManager.Instance.MobilizationAlliWorldBoard[(int)num2].Score > 0u)
			{
				this.SPHeight.Add(53f);
			}
			num2 += 1;
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID(17222u);
		this.AGS_Form.GetChild(2).gameObject.SetActive(true);
		this.AGS_Form.GetChild(11).gameObject.SetActive(true);
		Image component2 = this.AGS_Form.GetChild(10).GetComponent<Image>();
		component2.gameObject.SetActive(true);
		GUIManager.Instance.SetAllyRankImage(component2, 4);
		if (showNotReady)
		{
			this.AGS_Panel2.gameObject.SetActive(false);
			this.AGS_Form.GetChild(13).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(14613u);
			component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
			component.gameObject.SetActive(true);
			this.Ranking.ClearString();
			this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(9580u));
			component.text = this.Ranking.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			return;
		}
		this.AGS_Panel2.gameObject.SetActive(true);
		this.AGS_Form.GetChild(13).gameObject.SetActive(false);
		this.AGS_Form.GetChild(5).gameObject.SetActive(true);
		component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
		this.Ranking.ClearString();
		if (LeaderBoardManager.Instance.MobilizationAlliWorldRank == 0)
		{
			this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8414u));
		}
		else
		{
			this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.MobilizationAlliWorldRank, 1, false);
			this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9856u));
		}
		component.text = this.Ranking.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		RectTransform component3 = this.AGS_Form.GetChild(15).GetComponent<RectTransform>();
		if (LeaderBoardManager.Instance.MobilizationAlliWorldLastRank != 0 && LeaderBoardManager.Instance.MobilizationAlliWorldLastRank != LeaderBoardManager.Instance.MobilizationAlliWorldRank)
		{
			if (LeaderBoardManager.Instance.MobilizationAlliWorldLastRank > LeaderBoardManager.Instance.MobilizationAlliWorldRank)
			{
				component3.GetComponent<UISpritesArray>().SetSpriteIndex(0);
			}
			else
			{
				component3.GetComponent<UISpritesArray>().SetSpriteIndex(1);
			}
			component3.gameObject.SetActive(true);
			float x = Mathf.Min(173f, component.rectTransform.anchoredPosition.x + component.preferredWidth / 2f + 15f);
			component3.anchoredPosition = new Vector2(x, component3.anchoredPosition.y);
			this.RankValue.ClearString();
			this.RankValue.IntToFormat((long)Math.Abs(LeaderBoardManager.Instance.MobilizationAlliWorldLastRank - LeaderBoardManager.Instance.MobilizationAlliWorldRank), 1, false);
			this.RankValue.AppendFormat("{0}");
			component = component3.GetChild(0).GetComponent<UIText>();
			component.text = this.RankValue.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			component3.gameObject.SetActive(false);
		}
	}

	// Token: 0x04003AF8 RID: 15096
	public static bool NewOpen;

	// Token: 0x04003AF9 RID: 15097
	private static readonly int[] MobiGroupBoardSize = new int[]
	{
		102,
		80,
		307,
		287
	};

	// Token: 0x04003AFA RID: 15098
	public bool closeAfter;

	// Token: 0x04003AFB RID: 15099
	private CString HintStr;
}
