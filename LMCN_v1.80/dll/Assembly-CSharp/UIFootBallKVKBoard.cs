using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000399 RID: 921
public class UIFootBallKVKBoard : UILeaderBoardBase
{
	// Token: 0x0600132A RID: 4906 RVA: 0x002167A8 File Offset: 0x002149A8
	public override void OnOpen(int arg1, int arg2)
	{
		base.OnOpen(arg1, arg2);
		if (UIFootBallKVKBoard.NewOpen)
		{
			UIFootBallKVKBoard.isTopBoard = true;
			UIFootBallKVKBoard.isPersonBoard = true;
			UIFootBallKVKBoard.NewOpen = false;
			UIFootBallKVKBoard.WorldBoard = false;
		}
		if (ActivityManager.Instance.GetFIFAState() != EActivityState.EAS_ReplayRanking)
		{
			this.bClose = true;
			return;
		}
		if (LeaderBoardManager.Instance.FootBallTopBoard.AllianceID != (ulong)DataManager.Instance.RoleAlliance.Id)
		{
			LeaderBoardManager.Instance.FootBallBoardTime = 0L;
			LeaderBoardManager.Instance.BoardUpdateTime[18] = 0L;
		}
		if (LeaderBoardManager.Instance.FootBallBoardTime < ActivityManager.Instance.ServerEventTime)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_FOOTBALL_TOPBOARD;
			messagePacket.AddSeqId();
			ushort data;
			byte data2;
			GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out data, out data2);
			messagePacket.Add(data);
			messagePacket.Add(data2);
			messagePacket.Send(false);
			UIFootBallKVKBoard.isTopBoard = true;
			this.DataReady = false;
		}
		else
		{
			this.DataReady = true;
		}
		this.KingdomImg = this.AGS_Form.GetChild(6).GetChild(2).GetComponent<RectTransform>();
		this.KingdomImg.gameObject.SetActive(false);
	}

	// Token: 0x0600132B RID: 4907 RVA: 0x002168E0 File Offset: 0x00214AE0
	public void CreateTopBoard()
	{
		this.SPHeight.Clear();
		this.SPHeight.Add(118f);
		this.SPHeight.Add(118f);
		this.SPHeight.Add(118f);
		this.AGS_Form.GetChild(3).gameObject.SetActive(false);
		RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(8, 0);
		this.AGS_Form.GetChild(12).gameObject.SetActive(true);
		this.AGS_Form.GetChild(12).GetComponent<UISpritesArray>().SetSpriteIndex(0);
		UIFootBallKVKBoard.isTopBoard = true;
		if (!UIFootBallKVKBoard.WorldBoard)
		{
			this.AGS_Form.GetChild(12).GetComponent<UISpritesArray>().SetSpriteIndex(0);
			this.SPHeight.Add(118f);
			UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(9585u);
			this.AGS_Form.GetChild(2).gameObject.SetActive(true);
			this.AGS_Form.GetChild(5).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
			CString cstring = StringManager.Instance.StaticString1024();
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring.Append(GameConstants.GetDateTime(LeaderBoardManager.Instance.FootBallTopBoard.SortTime).ToString("MM/dd/yy HH:mm"));
			cstring2.ClearString();
			cstring2.Append(GameConstants.GetDateTime(LeaderBoardManager.Instance.FootBallTopBoard.SortTime + (long)((ulong)LeaderBoardManager.Instance.FootBallTopBoard.EventRequireTime)).ToString("MM/dd/yy HH:mm"));
			this.Ranking.ClearString();
			this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8153u));
			this.Ranking.Append(" ");
			this.Ranking.Append(cstring);
			this.Ranking.Append(" ~ ");
			this.Ranking.Append(cstring2);
			component.text = this.Ranking.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.AGS_Form.GetChild(12).GetComponent<UISpritesArray>().SetSpriteIndex(1);
			UIText component2 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
			component2.text = DataManager.Instance.mStringTable.GetStringByID(9566u);
			this.AGS_Form.GetChild(2).gameObject.SetActive(true);
			this.AGS_Form.GetChild(5).gameObject.SetActive(true);
			component2 = this.AGS_Form.GetChild(5).GetComponent<UIText>();
			CString cstring3 = StringManager.Instance.StaticString1024();
			CString cstring4 = StringManager.Instance.StaticString1024();
			cstring3.ClearString();
			cstring3.Append(GameConstants.GetDateTime(LeaderBoardManager.Instance.FootBallTopBoard.SortTime).ToString("MM/dd/yy HH:mm"));
			cstring4.ClearString();
			cstring4.Append(GameConstants.GetDateTime(LeaderBoardManager.Instance.FootBallTopBoard.SortTime + (long)((ulong)LeaderBoardManager.Instance.FootBallTopBoard.EventRequireTime)).ToString("MM/dd/yy HH:mm"));
			this.Ranking.ClearString();
			this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8153u));
			this.Ranking.Append(" ");
			this.Ranking.Append(cstring3);
			this.Ranking.Append(" ~ ");
			this.Ranking.Append(cstring4);
			component2.text = this.Ranking.ToString();
			component2.SetAllDirty();
			component2.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x0600132C RID: 4908 RVA: 0x00216CD8 File Offset: 0x00214ED8
	public void CreateSubBoard()
	{
		this.AGS_Form.GetChild(5).gameObject.SetActive(false);
		this.AGS_Form.GetChild(12).gameObject.SetActive(false);
		this.SPHeight.Clear();
		this.SPHeight.Add(38f);
		switch (UIFootBallKVKBoard.SubBoardID)
		{
		case 5:
		case 12:
			for (int i = 0; i < LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID].Count; i++)
			{
				if (((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][i]).KingdomID > 0)
				{
					this.SPHeight.Add(53f);
				}
			}
			break;
		case 6:
		case 15:
		case 16:
		case 17:
			for (int j = 0; j < LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID].Count; j++)
			{
				if (LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][j].Value > 0UL)
				{
					this.SPHeight.Add(53f);
				}
			}
			break;
		case 18:
			for (int k = 0; k < LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID].Count; k++)
			{
				this.SPHeight.Add(53f);
			}
			break;
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		switch (UIFootBallKVKBoard.SubBoardID)
		{
		case 5:
			component.text = DataManager.Instance.mStringTable.GetStringByID(9588u);
			break;
		case 6:
			component.text = DataManager.Instance.mStringTable.GetStringByID(9589u);
			break;
		case 12:
			component.text = DataManager.Instance.mStringTable.GetStringByID(9587u);
			break;
		case 15:
			component.text = DataManager.Instance.mStringTable.GetStringByID(9590u);
			break;
		case 16:
			component.text = DataManager.Instance.mStringTable.GetStringByID(9854u);
			break;
		case 17:
			component.text = DataManager.Instance.mStringTable.GetStringByID(9586u);
			break;
		case 18:
			component.text = DataManager.Instance.mStringTable.GetStringByID(9855u);
			break;
		}
		this.AGS_Form.GetChild(3).gameObject.SetActive(true);
		if (UIFootBallKVKBoard.isPersonBoard)
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
		if ((UIFootBallKVKBoard.SubBoardID == 5 || UIFootBallKVKBoard.SubBoardID == 12) && LeaderBoardManager.Instance.MyRank[(int)UIFootBallKVKBoard.SubBoardID] != 0)
		{
			this.AGS_Form.GetChild(3).gameObject.SetActive(false);
			this.AGS_Form.GetChild(5).gameObject.SetActive(true);
			this.AGS_Form.GetChild(2).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
			this.Ranking.ClearString();
			this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.MyRank[(int)UIFootBallKVKBoard.SubBoardID], 1, true);
			this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9849u));
			component.text = this.Ranking.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		if (UIFootBallKVKBoard.SubBoardID == 18)
		{
			this.Ranking.ClearString();
			if (LeaderBoardManager.Instance.MyRank[(int)UIFootBallKVKBoard.SubBoardID] != 0)
			{
				component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
				this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.MyRank[(int)UIFootBallKVKBoard.SubBoardID], 1, true);
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
		else if (UIFootBallKVKBoard.isPersonBoard)
		{
			this.Ranking.ClearString();
			if (LeaderBoardManager.Instance.MyRank[(int)UIFootBallKVKBoard.SubBoardID] != 0)
			{
				component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
				this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.MyRank[(int)UIFootBallKVKBoard.SubBoardID], 1, true);
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
			if (LeaderBoardManager.Instance.MyRank[(int)UIFootBallKVKBoard.SubBoardID] != 0)
			{
				this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.MyRank[(int)UIFootBallKVKBoard.SubBoardID], 1, false);
				this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9856u));
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
		if (UIFootBallKVKBoard.SubBoardID == 18 && LeaderBoardManager.Instance.MyRank[(int)UIFootBallKVKBoard.SubBoardID] != 0 && (int)LeaderBoardManager.Instance.MyRank[(int)UIFootBallKVKBoard.SubBoardID] <= LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID].Count)
		{
			component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
			this.RankValue.ClearString();
			this.RankValue.uLongToFormat(LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][(int)(LeaderBoardManager.Instance.MyRank[(int)UIFootBallKVKBoard.SubBoardID] - 1)].Value, 1, true);
			this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8121u));
			component.text = this.RankValue.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
			component.text = string.Empty;
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x0600132D RID: 4909 RVA: 0x0021763C File Offset: 0x0021583C
	private void MainBoardChange()
	{
		if (LeaderBoardManager.Instance.FootBallBoardTime < ActivityManager.Instance.ServerEventTime || LeaderBoardManager.Instance.FootBallTopBoard.AllianceID != (ulong)DataManager.Instance.RoleAlliance.Id)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_RESP_FOOTBALL_TOPBOARD;
			messagePacket.AddSeqId();
			ushort data;
			byte data2;
			GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out data, out data2);
			messagePacket.Add(data);
			messagePacket.Add(data2);
			messagePacket.Send(false);
			UIFootBallKVKBoard.isTopBoard = true;
			return;
		}
		this.CreateTopBoard();
		base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardTypes);
		this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false, true);
		this.AGS_Panel1.GoTo(0);
	}

	// Token: 0x0600132E RID: 4910 RVA: 0x00217704 File Offset: 0x00215904
	private void SubBoardChange(byte newSubID)
	{
		UIFootBallKVKBoard.SubBoardID = newSubID;
		UIFootBallKVKBoard.isTopBoard = false;
		if (UIFootBallKVKBoard.SubBoardID == 18 && LeaderBoardManager.Instance.BoardUpdateTime[(int)UIFootBallKVKBoard.SubBoardID] < ActivityManager.Instance.ServerEventTime)
		{
			UILeaderBoardBase.TopIndex[(int)UIFootBallKVKBoard.SubBoardID] = 0;
			LeaderBoardManager.Instance.ClearBoard(18);
			LeaderBoardManager.Instance.MyRank[(int)UIFootBallKVKBoard.SubBoardID] = 0;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.AddSeqId();
			messagePacket.Protocol = Protocol._MSG_REQUEST_FOOTBALL_ASOLO_RANK;
			messagePacket.Send(false);
		}
		else if (LeaderBoardManager.Instance.BoardUpdateTime[(int)UIFootBallKVKBoard.SubBoardID] < ActivityManager.Instance.ServerEventTime)
		{
			UILeaderBoardBase.TopIndex[(int)UIFootBallKVKBoard.SubBoardID] = 0;
			MessagePacket messagePacket2 = new MessagePacket(1024);
			messagePacket2.AddSeqId();
			messagePacket2.Protocol = Protocol._MSG_REQUEST_LEADERBOARD_CONTENT;
			ushort data;
			byte data2;
			GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out data, out data2);
			messagePacket2.Add(data);
			messagePacket2.Add(data2);
			messagePacket2.Add(UIFootBallKVKBoard.SubBoardID);
			byte data3 = 0;
			messagePacket2.Add(data3);
			messagePacket2.Add(LeaderBoardManager.Instance.FootBallTopBoard.SortTime);
			if (UIFootBallKVKBoard.SubBoardID == 6)
			{
				messagePacket2.Add(DataManager.Instance.RoleAlliance.Id);
			}
			messagePacket2.Send(false);
		}
		else
		{
			this.CreateSubBoard();
			base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
			this.AGS_Panel2.AddNewDataHeight(this.SPHeight, true, true);
			this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[(int)UIFootBallKVKBoard.SubBoardID]);
		}
	}

	// Token: 0x0600132F RID: 4911 RVA: 0x00217898 File Offset: 0x00215A98
	public void UpdateRow_FunctionList(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (!UIFootBallKVKBoard.WorldBoard)
		{
			switch (dataIdx)
			{
			case 0:
			{
				item.transform.GetChild(2).gameObject.SetActive(false);
				item.transform.GetChild(3).gameObject.SetActive(false);
				UIText component = item.transform.GetChild(4).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(9587u);
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.ClearString();
				DataManager.MapDataController.GetKingdomName(LeaderBoardManager.Instance.FootBallTopBoard.TopKingdom, ref cstring);
				this.SortTextArray[1, panelObjectIdx].ClearString();
				this.SortTextArray[1, panelObjectIdx].IntToFormat((long)LeaderBoardManager.Instance.FootBallTopBoard.TopKingdom, 1, false);
				this.SortTextArray[1, panelObjectIdx].StringToFormat(cstring);
				this.SortTextArray[1, panelObjectIdx].AppendFormat("#{0} {1}");
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
				component2.m_BtnID2 = 12;
				this.KingdomImg.SetParent(item.transform, false);
				this.KingdomImg.gameObject.SetActive(true);
				this.KingdomImg.anchoredPosition = new Vector2(-323f, -20f);
				break;
			}
			case 1:
			{
				item.transform.GetChild(2).gameObject.SetActive(LeaderBoardManager.Instance.FootBallTopBoard.KingdomAllianceTopEmblem != 0);
				item.transform.GetChild(3).gameObject.SetActive(false);
				if (item.transform.GetChild(2).GetChild(0).childCount < 1)
				{
					GUIManager.Instance.InitBadgeTotem(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.FootBallTopBoard.KingdomAllianceTopEmblem);
				}
				else
				{
					GUIManager.Instance.SetBadgeTotemImg(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.FootBallTopBoard.KingdomAllianceTopEmblem);
				}
				UIText component = item.transform.GetChild(4).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(9854u);
				this.SortTextArray[1, panelObjectIdx].ClearString();
				if (LeaderBoardManager.Instance.FootBallTopBoard.KingdomAlliance.Value == 0UL)
				{
					this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8477u));
				}
				else
				{
					GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.FootBallTopBoard.KingdomAlliance.KingdomID, LeaderBoardManager.Instance.FootBallTopBoard.KingdomAlliance.Name, LeaderBoardManager.Instance.FootBallTopBoard.KingdomAlliance.AlliaceTag, false);
				}
				component = item.transform.GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.SortTextArray[2, panelObjectIdx].ClearString();
				if (LeaderBoardManager.Instance.FootBallTopBoard.KingdomAlliance.Value > 0UL)
				{
					this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.FootBallTopBoard.KingdomAlliance.Value, 1, true);
					this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
				}
				component = item.transform.GetChild(6).GetComponent<UIText>();
				component.text = this.SortTextArray[2, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				UIButton component2 = item.transform.GetChild(1).GetComponent<UIButton>();
				component2.m_Handler = this;
				component2.m_BtnID1 = 3;
				component2.m_BtnID2 = 16;
				break;
			}
			case 2:
			{
				item.transform.GetChild(2).gameObject.SetActive(false);
				item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.FootBallTopBoard.KingdomPlayer.Value != 0UL);
				if (item.transform.GetChild(3).childCount < 1)
				{
					GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.FootBallTopBoard.KingdomPlayerTopHead, 11, 0, 0, false, false, true, false);
				}
				else
				{
					GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.FootBallTopBoard.KingdomPlayerTopHead, 11, 0, 0);
				}
				UIText component = item.transform.GetChild(4).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(9586u);
				this.SortTextArray[1, panelObjectIdx].ClearString();
				if (LeaderBoardManager.Instance.FootBallTopBoard.KingdomPlayer.Value == 0UL)
				{
					this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475u));
				}
				else
				{
					GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.FootBallTopBoard.KingdomPlayer.KingdomID, LeaderBoardManager.Instance.FootBallTopBoard.KingdomPlayer.Name, LeaderBoardManager.Instance.FootBallTopBoard.KingdomPlayer.AlliaceTag, false);
				}
				component = item.transform.GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.SortTextArray[2, panelObjectIdx].ClearString();
				if (LeaderBoardManager.Instance.FootBallTopBoard.KingdomPlayer.Value > 0UL)
				{
					this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.FootBallTopBoard.KingdomPlayer.Value, 1, true);
					this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
				}
				component = item.transform.GetChild(6).GetComponent<UIText>();
				component.text = this.SortTextArray[2, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				UIButton component2 = item.transform.GetChild(1).GetComponent<UIButton>();
				component2.m_Handler = this;
				component2.m_BtnID1 = 3;
				component2.m_BtnID2 = 17;
				break;
			}
			case 3:
			{
				item.transform.GetChild(2).gameObject.SetActive(false);
				item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.FootBallTopBoard.AlliancePlayer.Name.Length > 0 && DataManager.Instance.RoleAlliance.Id != 0u);
				if (item.transform.GetChild(3).childCount < 1)
				{
					GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.FootBallTopBoard.AlliancePlayerTopHead, 11, 0, 0, false, false, true, false);
				}
				else
				{
					GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.FootBallTopBoard.AlliancePlayerTopHead, 11, 0, 0);
				}
				UIText component = item.transform.GetChild(4).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(9855u);
				this.SortTextArray[1, panelObjectIdx].ClearString();
				if (DataManager.Instance.RoleAlliance.Id == 0u || LeaderBoardManager.Instance.FootBallTopBoard.AlliancePlayer.Name.Length == 0)
				{
					this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475u));
				}
				else
				{
					GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], 0, LeaderBoardManager.Instance.FootBallTopBoard.AlliancePlayer.Name, DataManager.Instance.RoleAlliance.Tag, false);
				}
				component = item.transform.GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.SortTextArray[2, panelObjectIdx].ClearString();
				if (DataManager.Instance.RoleAlliance.Id > 0u && LeaderBoardManager.Instance.FootBallTopBoard.AlliancePlayer.Name.Length > 0)
				{
					this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.FootBallTopBoard.AlliancePlayer.Value, 1, true);
					this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
				}
				component = item.transform.GetChild(6).GetComponent<UIText>();
				component.text = this.SortTextArray[2, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				UIButton component2 = item.transform.GetChild(1).GetComponent<UIButton>();
				component2.m_Handler = this;
				component2.m_BtnID1 = 3;
				component2.m_BtnID2 = 18;
				break;
			}
			}
		}
		else
		{
			switch (dataIdx)
			{
			case 0:
			{
				item.transform.GetChild(2).gameObject.SetActive(false);
				item.transform.GetChild(3).gameObject.SetActive(false);
				UIText component = item.transform.GetChild(4).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(9588u);
				CString cstring2 = StringManager.Instance.StaticString1024();
				cstring2.ClearString();
				DataManager.MapDataController.GetKingdomName(LeaderBoardManager.Instance.FootBallTopBoard.TopWorldKingdom, ref cstring2);
				this.SortTextArray[1, panelObjectIdx].ClearString();
				this.SortTextArray[1, panelObjectIdx].IntToFormat((long)LeaderBoardManager.Instance.FootBallTopBoard.TopWorldKingdom, 1, false);
				this.SortTextArray[1, panelObjectIdx].StringToFormat(cstring2);
				this.SortTextArray[1, panelObjectIdx].AppendFormat("#{0} {1}");
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
				component2.m_BtnID2 = 5;
				this.KingdomImg.SetParent(item.transform, false);
				this.KingdomImg.gameObject.SetActive(true);
				this.KingdomImg.anchoredPosition = new Vector2(-323f, -20f);
				break;
			}
			case 1:
			{
				item.transform.GetChild(2).gameObject.SetActive(LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomAllianceEmblem != 0);
				item.transform.GetChild(3).gameObject.SetActive(false);
				if (item.transform.GetChild(2).GetChild(0).childCount < 1)
				{
					GUIManager.Instance.InitBadgeTotem(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomAllianceEmblem);
				}
				else
				{
					GUIManager.Instance.SetBadgeTotemImg(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomAllianceEmblem);
				}
				UIText component = item.transform.GetChild(4).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(9589u);
				this.SortTextArray[1, panelObjectIdx].ClearString();
				if (LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomAlliance.Value == 0UL)
				{
					this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8477u));
				}
				else
				{
					GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomAlliance.KingdomID, LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomAlliance.Name, LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomAlliance.AlliaceTag, false);
				}
				component = item.transform.GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.SortTextArray[2, panelObjectIdx].ClearString();
				if (LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomAlliance.Value > 0UL)
				{
					this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomAlliance.Value, 1, true);
					this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
				}
				component = item.transform.GetChild(6).GetComponent<UIText>();
				component.text = this.SortTextArray[2, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				UIButton component2 = item.transform.GetChild(1).GetComponent<UIButton>();
				component2.m_Handler = this;
				component2.m_BtnID1 = 3;
				component2.m_BtnID2 = 6;
				break;
			}
			case 2:
			{
				item.transform.GetChild(2).gameObject.SetActive(false);
				item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomPlayer.Value != 0UL);
				if (item.transform.GetChild(3).childCount < 1)
				{
					GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomPlayerHead, 11, 0, 0, false, false, true, false);
				}
				else
				{
					GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomPlayerHead, 11, 0, 0);
				}
				UIText component = item.transform.GetChild(4).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(9590u);
				this.SortTextArray[1, panelObjectIdx].ClearString();
				if (LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomPlayer.Value == 0UL)
				{
					this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475u));
				}
				else
				{
					GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomPlayer.KingdomID, LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomPlayer.Name, LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomPlayer.AlliaceTag, false);
				}
				component = item.transform.GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.SortTextArray[2, panelObjectIdx].ClearString();
				if (LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomPlayer.Value > 0UL)
				{
					this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.FootBallTopBoard.WorldKingdomPlayer.Value, 1, true);
					this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
				}
				component = item.transform.GetChild(6).GetComponent<UIText>();
				component.text = this.SortTextArray[2, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				UIButton component2 = item.transform.GetChild(1).GetComponent<UIButton>();
				component2.m_Handler = this;
				component2.m_BtnID1 = 3;
				component2.m_BtnID2 = 15;
				break;
			}
			}
		}
	}

	// Token: 0x06001330 RID: 4912 RVA: 0x002189E8 File Offset: 0x00216BE8
	public void UpdatRow_Boards(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (dataIdx == 0)
		{
			switch (UIFootBallKVKBoard.SubBoardID)
			{
			case 5:
			case 12:
			{
				item.transform.GetChild(0).gameObject.SetActive(true);
				item.transform.GetChild(1).gameObject.SetActive(false);
				UIText component = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				component = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(9850u);
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				component = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(9851u);
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				break;
			}
			case 6:
			case 16:
			{
				item.transform.GetChild(0).gameObject.SetActive(true);
				item.transform.GetChild(1).gameObject.SetActive(false);
				UIText component = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(7062u);
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				component = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(7094u);
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				component = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
				component.text = DataManager.Instance.mStringTable.GetStringByID(9857u);
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				break;
			}
			case 15:
			case 17:
			case 18:
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
				component.text = DataManager.Instance.mStringTable.GetStringByID(9858u);
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				break;
			}
			}
		}
		else
		{
			LeaderBoardManager.Instance.CheckNextPart(UIFootBallKVKBoard.SubBoardID, (byte)dataIdx);
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			this.SortTextArray[0, panelObjectIdx].ClearString();
			this.SortTextArray[0, panelObjectIdx].IntToFormat((long)dataIdx, 1, false);
			this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
			UIText component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
			component.text = this.SortTextArray[0, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			switch (UIFootBallKVKBoard.SubBoardID)
			{
			case 5:
			case 12:
			{
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.ClearString();
				DataManager.MapDataController.GetKingdomName(((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1]).KingdomID, ref cstring);
				this.SortTextArray[1, panelObjectIdx].ClearString();
				this.SortTextArray[1, panelObjectIdx].IntToFormat((long)((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1]).KingdomID, 1, false);
				this.SortTextArray[1, panelObjectIdx].StringToFormat(cstring);
				this.SortTextArray[1, panelObjectIdx].AppendFormat("#{0} {1}");
				component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				break;
			}
			case 6:
				this.SortTextArray[1, panelObjectIdx].ClearString();
				GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], ((BoardUnitKingdomWarAlliance)LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1]).KingdomID, LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1].AlliaceTag, false);
				component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				break;
			case 7:
				this.SortTextArray[1, panelObjectIdx].ClearString();
				GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], 0, LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1].AlliaceTag, false);
				component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				break;
			case 15:
			case 17:
				this.SortTextArray[1, panelObjectIdx].ClearString();
				GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], ((WorldRankingBoardUnit)LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1]).KingdomID, LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1].AlliaceTag, false);
				component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				break;
			case 16:
				this.SortTextArray[1, panelObjectIdx].ClearString();
				GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], ((WorldRankingBoardUnitAlliance)LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1]).KingdomID, LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1].AlliaceTag, false);
				component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				break;
			case 18:
				this.SortTextArray[1, panelObjectIdx].ClearString();
				GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], 0, LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1].AlliaceTag, false);
				component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				break;
			}
			this.SortTextArray[2, panelObjectIdx].ClearString();
			item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
			item.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);
			item.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
			byte subBoardID = UIFootBallKVKBoard.SubBoardID;
			if (subBoardID != 5 && subBoardID != 12)
			{
				this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1].Value, 1, true);
				this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
			}
			else if (((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1]).KingKingdomID != 0)
			{
				if (((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1]).KingKingdomID == ((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1]).KingdomID)
				{
					GameConstants.GetNameString(this.SortTextArray[2, panelObjectIdx], ((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1]).KingKingdomID, LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1].AlliaceTag, true);
				}
				else
				{
					GameConstants.GetNameString(this.SortTextArray[2, panelObjectIdx], ((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1]).KingKingdomID, LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][dataIdx - 1].AlliaceTag, true);
					this.SortTextArray[2, panelObjectIdx].Insert(0, "<color=#FFD74CFF>", -1);
					this.SortTextArray[2, panelObjectIdx].Append("</color>");
				}
			}
			component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
			component.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			UIButton component2 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 4;
			component2.m_BtnID2 = dataIdx - 1;
			if (dataIdx == (int)LeaderBoardManager.Instance.MyRank[(int)UIFootBallKVKBoard.SubBoardID])
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

	// Token: 0x06001331 RID: 4913 RVA: 0x002196F8 File Offset: 0x002178F8
	public override void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelId != 1)
		{
			if (panelId == 2)
			{
				this.UpdatRow_Boards(item, dataIdx, panelObjectIdx);
			}
		}
		else
		{
			this.UpdateRow_FunctionList(item, dataIdx, panelObjectIdx);
		}
	}

	// Token: 0x06001332 RID: 4914 RVA: 0x00219738 File Offset: 0x00217938
	public override void UpdateUI(int arg1, int arg2)
	{
		if ((byte)arg1 == 5)
		{
			this.door.CloseMenu(false);
		}
		switch ((byte)arg1)
		{
		case 2:
			if (UIFootBallKVKBoard.isTopBoard)
			{
				this.CreateTopBoard();
				if (!this.LoadComplet)
				{
					this.DataReady = true;
				}
				else
				{
					base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardTypes);
					this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false, true);
					this.AGS_Panel1.GoTo(0);
				}
			}
			break;
		case 3:
			if (!UIFootBallKVKBoard.isTopBoard && arg2 == (int)UIFootBallKVKBoard.SubBoardID)
			{
				this.CreateSubBoard();
				base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
				this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
			}
			break;
		case 4:
			if (!UIFootBallKVKBoard.isTopBoard && arg2 == (int)UIFootBallKVKBoard.SubBoardID)
			{
				UILeaderBoardBase.TopIndex[(int)UIFootBallKVKBoard.SubBoardID] = 0;
				this.CreateSubBoard();
				base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
				this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
				this.AGS_Panel2.GoTo(0);
			}
			break;
		}
	}

	// Token: 0x06001333 RID: 4915 RVA: 0x00219854 File Offset: 0x00217A54
	public void Update()
	{
		if (this.bClose)
		{
			this.door.CloseMenu(false);
			return;
		}
		if (!this.LoadComplet)
		{
			base.SetDefaultSize();
			this.LoadComplet = true;
			this.AGS_Panel1.IntiScrollPanel(447f, 0f, 0f, this.SPHeight, 4, this);
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
			if (UIFootBallKVKBoard.isTopBoard)
			{
				this.CreateTopBoard();
				base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardTypes);
				this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false, true);
				this.AGS_Panel1.GoTo(0);
			}
			else
			{
				this.CreateSubBoard();
				base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
				this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
				this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[(int)UIFootBallKVKBoard.SubBoardID]);
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
	}

	// Token: 0x06001334 RID: 4916 RVA: 0x00219A78 File Offset: 0x00217C78
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
			this.door.CloseMenu_Alliance(EGUIWindow.UI_FootBallBoard);
		}
		else
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001335 RID: 4917 RVA: 0x00219AE8 File Offset: 0x00217CE8
	public override void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		switch (btnID)
		{
		case 0:
			if (UIFootBallKVKBoard.isTopBoard)
			{
				this.door.CloseMenu(false);
				UIFootBallKVKBoard.NewOpen = true;
			}
			else
			{
				UILeaderBoardBase.TopIndex[(int)UIFootBallKVKBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
				this.MainBoardChange();
			}
			break;
		default:
			if (btnID != 9)
			{
				if (btnID == 99)
				{
					GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7028u), DataManager.Instance.mStringTable.GetStringByID(9041u), null, null, 0, 0, true, false);
				}
			}
			else if (!UIFootBallKVKBoard.WorldBoard)
			{
				UIFootBallKVKBoard.WorldBoard = true;
				this.MainBoardChange();
			}
			else
			{
				UIFootBallKVKBoard.WorldBoard = false;
				this.MainBoardChange();
			}
			break;
		case 3:
			switch ((byte)sender.m_BtnID2)
			{
			case 5:
			case 12:
				UIFootBallKVKBoard.isPersonBoard = true;
				break;
			case 6:
				UIFootBallKVKBoard.isPersonBoard = false;
				break;
			case 15:
				UIFootBallKVKBoard.isPersonBoard = true;
				break;
			case 16:
				if (LeaderBoardManager.Instance.FootBallTopBoard.KingdomAlliance.Value == 0UL)
				{
					return;
				}
				UIFootBallKVKBoard.isPersonBoard = false;
				break;
			case 17:
				if (LeaderBoardManager.Instance.FootBallTopBoard.KingdomPlayer.Value == 0UL)
				{
					return;
				}
				UIFootBallKVKBoard.isPersonBoard = true;
				break;
			case 18:
				if (DataManager.Instance.RoleAlliance.Id == 0u || LeaderBoardManager.Instance.FootBallTopBoard.AlliancePlayer.Name.Length == 0)
				{
					return;
				}
				UIFootBallKVKBoard.isPersonBoard = true;
				break;
			}
			this.SubBoardChange((byte)sender.m_BtnID2);
			break;
		case 4:
			if (UIFootBallKVKBoard.isPersonBoard)
			{
				UILeaderBoardBase.TopIndex[(int)UIFootBallKVKBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
				DataManager.Instance.ShowLordProfile(LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][sender.m_BtnID2].Name.ToString());
			}
			else
			{
				UILeaderBoardBase.TopIndex[(int)UIFootBallKVKBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
				DataManager.Instance.AllianceView.Id = ((BoardUnitAlliance)LeaderBoardManager.Instance.Boards[(int)UIFootBallKVKBoard.SubBoardID][sender.m_BtnID2]).AllianceID;
				this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5, 0, false);
			}
			break;
		}
	}

	// Token: 0x04003B0B RID: 15115
	public static byte SubBoardID;

	// Token: 0x04003B0C RID: 15116
	public static bool isTopBoard = true;

	// Token: 0x04003B0D RID: 15117
	public static bool isPersonBoard = true;

	// Token: 0x04003B0E RID: 15118
	public static bool NewOpen;

	// Token: 0x04003B0F RID: 15119
	public static bool WorldBoard;

	// Token: 0x04003B10 RID: 15120
	private RectTransform KingdomImg;

	// Token: 0x04003B11 RID: 15121
	private bool bClose;
}
