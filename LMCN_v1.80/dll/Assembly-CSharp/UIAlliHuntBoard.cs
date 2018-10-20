using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000394 RID: 916
public class UIAlliHuntBoard : UILeaderBoardBase
{
	// Token: 0x060012F1 RID: 4849 RVA: 0x0020FC14 File Offset: 0x0020DE14
	public override void OnOpen(int arg1, int arg2)
	{
		base.OnOpen(arg1, arg2);
		if (LeaderBoardManager.Instance.AlliHuntBoardUpdateTime < DataManager.Instance.ServerTime || LeaderBoardManager.Instance.MobiGroupAllianceID != DataManager.Instance.RoleAlliance.Id)
		{
			UILeaderBoardBase.TopIndex[3] = 0;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AS_PERSONAL_RANK;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			this.DataReady = false;
		}
		else
		{
			this.DataReady = true;
		}
	}

	// Token: 0x060012F2 RID: 4850 RVA: 0x0020FCA0 File Offset: 0x0020DEA0
	private void CreateAlliHuntBoard()
	{
		this.SPHeight.Clear();
		this.SPHeight.Add(38f);
		ushort num = 0;
		while ((int)num < LeaderBoardManager.Instance.AlliHuntBoard.Count)
		{
			this.SPHeight.Add(53f);
			num += 1;
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
		if (LeaderBoardManager.Instance.AlliHuntRank > 0)
		{
			component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
			this.Ranking.ClearString();
			this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.AlliHuntRank, 1, false);
			this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7060u));
			component.text = this.Ranking.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
			this.RankValue.ClearString();
			this.RankValue.uLongToFormat(LeaderBoardManager.Instance.AlliHuntBoard[LeaderBoardManager.Instance.AlliHuntRank - 1].Value, 1, false);
			this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8121u));
			component.text = this.RankValue.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x060012F3 RID: 4851 RVA: 0x0020FF08 File Offset: 0x0020E108
	public void Update()
	{
		if (!this.LoadComplet)
		{
			base.SetDefaultSize();
			this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(10).gameObject.SetActive(false);
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
			this.CreateAlliHuntBoard();
			base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
			this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
			this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[16]);
		}
	}

	// Token: 0x060012F4 RID: 4852 RVA: 0x00210054 File Offset: 0x0020E254
	public override void UpdateUI(int arg1, int arg2)
	{
		if ((byte)arg1 == 5)
		{
			this.door.CloseMenu(false);
		}
		if ((byte)arg1 == 11)
		{
			this.CreateAlliHuntBoard();
			if (!this.LoadComplet)
			{
				this.DataReady = true;
			}
			else
			{
				base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
				this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
				if (UILeaderBoardBase.TopIndex[16] == 0 && UIAlliHuntBoard.NewOpen)
				{
					UIAlliHuntBoard.NewOpen = false;
					UILeaderBoardBase.TopIndex[16] = LeaderBoardManager.Instance.AlliHuntRank;
				}
				this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[16]);
			}
		}
	}

	// Token: 0x060012F5 RID: 4853 RVA: 0x002100F8 File Offset: 0x0020E2F8
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

	// Token: 0x060012F6 RID: 4854 RVA: 0x00210164 File Offset: 0x0020E364
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
			component.text = DataManager.Instance.mStringTable.GetStringByID(4717u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(9858u);
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
			this.SortTextArray[1, panelObjectIdx].Append(LeaderBoardManager.Instance.AlliHuntBoard[dataIdx - 1].Name);
			component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
			component.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.AlliHuntBoard[dataIdx - 1].Value, 1, true);
			this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
			component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
			component.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			if (dataIdx == LeaderBoardManager.Instance.AlliHuntRank)
			{
				UISpritesArray component2 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(2);
				component2 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
				component2.SetSpriteIndex(2);
				component2 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
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
		}
	}

	// Token: 0x060012F7 RID: 4855 RVA: 0x0021058C File Offset: 0x0020E78C
	public override void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID != 0)
		{
			if (btnID == 99)
			{
				UILeaderBoardBase.TopIndex[14] = this.AGS_Panel2.GetTopIdx();
				GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7028u), DataManager.Instance.mStringTable.GetStringByID(9041u), null, null, 0, 0, true, false);
			}
		}
		else
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x04003AF7 RID: 15095
	public static bool NewOpen;
}
