using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020003B5 RID: 949
internal class UINobilityBoard : UILeaderBoardBase
{
	// Token: 0x06001388 RID: 5000 RVA: 0x0022CC68 File Offset: 0x0022AE68
	public override void OnOpen(int arg1, int arg2)
	{
		base.OnOpen(arg1, arg2);
		this.m_WonderID = arg2;
		LeaderBoardManager.Instance.Send_MSG_REQUEST_FEDERAL_HISTORYKINGDATA((byte)this.m_WonderID);
	}

	// Token: 0x06001389 RID: 5001 RVA: 0x0022CC98 File Offset: 0x0022AE98
	private void CreateNobilityBoard()
	{
		this.SPHeight.Clear();
		this.SPHeight.Add(38f);
		ushort num = 0;
		while ((int)num < LeaderBoardManager.Instance.MobiWorldKingBoard.Count)
		{
			this.SPHeight.Add(53f);
			num += 1;
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID(11061u);
		this.AGS_Form.GetChild(2).gameObject.SetActive(true);
		this.AGS_Form.GetChild(5).gameObject.SetActive(false);
		this.AGS_Form.GetChild(3).gameObject.SetActive(true);
		this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
		this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(false);
		this.SetHiBtnAndText();
		component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
		if (this.Ranking != null)
		{
			this.Ranking.ClearString();
			component.text = DataManager.Instance.mStringTable.GetStringByID(11088u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		this.AGS_Form.GetChild(9).gameObject.SetActive(true);
		component = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
		if (component != null)
		{
			if (this.SendResult == 0)
			{
				component.text = DataManager.Instance.mStringTable.GetStringByID(11090u);
			}
			else
			{
				component.text = DataManager.Instance.mStringTable.GetStringByID(11155u);
			}
		}
		if (LeaderBoardManager.Instance.MobiWorldKingBoard.Count <= 0)
		{
			this.AGS_Form.GetChild(13).gameObject.SetActive(true);
		}
		else
		{
			this.AGS_Form.GetChild(13).gameObject.SetActive(false);
		}
	}

	// Token: 0x0600138A RID: 5002 RVA: 0x0022CECC File Offset: 0x0022B0CC
	private void SetHiBtnAndText()
	{
		Transform child = this.AGS_Form.GetChild(3).GetChild(0);
		GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, LeaderBoardManager.Instance.KingHead, 11, 0, 0);
		UIText component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
		if (LeaderBoardManager.Instance.MobiWorldKingBoard.Count > 0 && LeaderBoardManager.Instance.KingHead != 0)
		{
			GameConstants.FormatRoleName(this.RankValue, LeaderBoardManager.Instance.MobiWorldKingBoard[0].Name, LeaderBoardManager.Instance.MobiWorldKingBoard[0].AllianceTag, null, 0, LeaderBoardManager.Instance.MobiWorldKingBoard[0].HomeKingdomID, null, null, null, null);
			component.text = this.RankValue.ToString();
		}
		if (this.m_WonderID >= 0 && this.m_WonderID < DataManager.MapDataController.YolkPointTable.Length)
		{
			MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[this.m_WonderID];
			bool flag = mapYolk.WonderLeader != null && mapYolk.WonderLeader.Length > 0;
			if (mapYolk.WonderState == 0 && flag && LeaderBoardManager.Instance.KingHead > 0)
			{
				child.gameObject.SetActive(true);
				component.gameObject.SetActive(true);
			}
			else
			{
				child.gameObject.SetActive(false);
				component.gameObject.SetActive(false);
			}
		}
		else
		{
			child.gameObject.SetActive(false);
			component.gameObject.SetActive(false);
		}
	}

	// Token: 0x0600138B RID: 5003 RVA: 0x0022D078 File Offset: 0x0022B278
	public void Update()
	{
		if (!this.LoadComplet)
		{
			RectTransform component = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<RectTransform>();
			int num = 0;
			component.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
			component.transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
			component.transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
			component.transform.GetChild(1).GetChild(7).gameObject.SetActive(true);
			RectTransform component2 = component.GetChild(0).GetChild(0).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UINobilityBoard.MobiWorldKingBoardSize[0]);
			component2 = component.GetChild(0).GetChild(4).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)(num + UINobilityBoard.MobiWorldKingBoardSize[0] / 2), component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UINobilityBoard.MobiWorldKingBoardSize[0]);
			num = UINobilityBoard.MobiWorldKingBoardSize[0];
			component2 = component.GetChild(0).GetChild(1).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UINobilityBoard.MobiWorldKingBoardSize[1]);
			component2 = component.GetChild(0).GetChild(5).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)(num + UINobilityBoard.MobiWorldKingBoardSize[1] / 2), component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UINobilityBoard.MobiWorldKingBoardSize[1]);
			num = UINobilityBoard.MobiWorldKingBoardSize[0] + UINobilityBoard.MobiWorldKingBoardSize[1];
			component2 = component.GetChild(0).GetChild(2).GetComponent<RectTransform>();
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UINobilityBoard.MobiWorldKingBoardSize[2]);
			component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
			component2 = component.GetChild(0).GetChild(6).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)(num + UINobilityBoard.MobiWorldKingBoardSize[2] / 2), component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UINobilityBoard.MobiWorldKingBoardSize[2]);
			component2 = component.GetChild(0).GetChild(3).GetComponent<RectTransform>();
			component2.gameObject.SetActive(false);
			component2 = component.GetChild(0).GetChild(7).GetComponent<RectTransform>();
			component2.gameObject.SetActive(false);
			num = 0;
			component2 = component.GetChild(1).GetChild(0).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UINobilityBoard.MobiWorldKingBoardSize[0]);
			num = 10;
			component2 = component.GetChild(1).GetChild(4).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)(num + UINobilityBoard.MobiWorldKingBoardSize[0] / 2), component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)(UINobilityBoard.MobiWorldKingBoardSize[0] - 20));
			UIText component3 = component.GetChild(1).GetChild(4).GetComponent<UIText>();
			component3.alignment = TextAnchor.MiddleLeft;
			num = UINobilityBoard.MobiWorldKingBoardSize[0];
			component2 = component.GetChild(1).GetChild(1).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UINobilityBoard.MobiWorldKingBoardSize[1]);
			component2 = component.GetChild(1).GetChild(5).GetComponent<RectTransform>();
			component3 = component.GetChild(1).GetChild(5).GetComponent<UIText>();
			component3.alignment = TextAnchor.MiddleCenter;
			component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UINobilityBoard.MobiWorldKingBoardSize[1]);
			num = UINobilityBoard.MobiWorldKingBoardSize[0] + UINobilityBoard.MobiWorldKingBoardSize[1];
			component2 = component.GetChild(1).GetChild(2).GetComponent<RectTransform>();
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UINobilityBoard.MobiWorldKingBoardSize[2]);
			component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
			component2 = component.GetChild(1).GetChild(6).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (float)UINobilityBoard.MobiWorldKingBoardSize[3]);
			component2 = component.GetChild(1).GetChild(3).GetComponent<RectTransform>();
			component2.gameObject.SetActive(false);
			component2 = component.GetChild(1).GetChild(7).GetComponent<RectTransform>();
			component2.gameObject.SetActive(false);
			component2 = component.transform.GetChild(1).GetChild(10).GetComponent<RectTransform>();
			component2.gameObject.SetActive(false);
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
		}
		if (this.DataReady && this.LoadComplet)
		{
			this.DataReady = false;
			this.CreateNobilityBoard();
			base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
			this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
			this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[15]);
		}
	}

	// Token: 0x0600138C RID: 5004 RVA: 0x0022D66C File Offset: 0x0022B86C
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg2 == 0 || arg2 == 2)
		{
			if (arg2 == 2)
			{
				this.SendResult = 1;
			}
			this.CreateNobilityBoard();
			if (!this.LoadComplet)
			{
				this.DataReady = true;
			}
			else
			{
				base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
				this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
				this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[15]);
			}
		}
		else if (arg2 == 1)
		{
			this.DataReady = false;
			LeaderBoardManager.Instance.Send_MSG_REQUEST_FEDERAL_HISTORYKINGDATA((byte)this.m_WonderID);
		}
	}

	// Token: 0x0600138D RID: 5005 RVA: 0x0022D704 File Offset: 0x0022B904
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Refresh)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				base.Refresh_FontTexture();
			}
		}
		else
		{
			this.DataReady = false;
			LeaderBoardManager.Instance.Send_MSG_REQUEST_FEDERAL_HISTORYKINGDATA((byte)this.m_WonderID);
		}
	}

	// Token: 0x0600138E RID: 5006 RVA: 0x0022D754 File Offset: 0x0022B954
	public override void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
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

	// Token: 0x0600138F RID: 5007 RVA: 0x0022DC00 File Offset: 0x0022BE00
	public override void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID != 0)
		{
			if (btnID == 99)
			{
				GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(11061u), DataManager.Instance.mStringTable.GetStringByID(11089u), null, null, 0, 0, false, true);
			}
		}
		else
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x04003C10 RID: 15376
	private byte SendResult;

	// Token: 0x04003C11 RID: 15377
	private static readonly int[] MobiWorldKingBoardSize = new int[]
	{
		330,
		189,
		257,
		257
	};

	// Token: 0x04003C12 RID: 15378
	private int m_WonderID;
}
