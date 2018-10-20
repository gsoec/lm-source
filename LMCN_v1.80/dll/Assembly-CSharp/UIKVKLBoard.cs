using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200039A RID: 922
public class UIKVKLBoard : UILeaderBoardBase
{
	// Token: 0x06001338 RID: 4920 RVA: 0x00219DAC File Offset: 0x00217FAC
	public override void OnOpen(int arg1, int arg2)
	{
		base.OnOpen(arg1, arg2);
		if (UIKVKLBoard.NewOpen)
		{
			UIKVKLBoard.isTopBoard = true;
			UIKVKLBoard.isPersonBoard = true;
			UIKVKLBoard.NewOpen = false;
		}
		if (LeaderBoardManager.Instance.KvKTopBoard.AllianceID != (ulong)DataManager.Instance.RoleAlliance.Id)
		{
			LeaderBoardManager.Instance.KingdomBoardNextTime = 0L;
			LeaderBoardManager.Instance.BoardUpdateTime[7] = 0L;
		}
		if (LeaderBoardManager.Instance.KingdomBoardNextTime < DataManager.Instance.ServerTime)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_KVK_TOPBOARD;
			messagePacket.AddSeqId();
			ushort data;
			byte data2;
			GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out data, out data2);
			messagePacket.Add(data);
			messagePacket.Add(data2);
			messagePacket.Send(false);
			UIKVKLBoard.isTopBoard = true;
			this.DataReady = false;
		}
		else
		{
			this.DataReady = true;
		}
		this.KingdomImg = this.AGS_Form.GetChild(6).GetChild(2).GetComponent<RectTransform>();
		this.KingdomImg.gameObject.SetActive(false);
	}

	// Token: 0x06001339 RID: 4921 RVA: 0x00219EC8 File Offset: 0x002180C8
	public void CreateTopBoard()
	{
		this.SPHeight.Clear();
		this.SPHeight.Add(118f);
		this.SPHeight.Add(118f);
		this.SPHeight.Add(118f);
		this.SPHeight.Add(118f);
		this.AGS_Form.GetChild(3).gameObject.SetActive(false);
		RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(8, 0);
		this.AGS_Form.GetChild(12).gameObject.SetActive(false);
		UIKVKLBoard.isTopBoard = true;
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID(9848u);
		this.AGS_Form.GetChild(2).gameObject.SetActive(true);
		this.AGS_Form.GetChild(5).gameObject.SetActive(true);
		component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.Append(GameConstants.GetDateTime(LeaderBoardManager.Instance.KvKTopBoard.SortTime).ToString("MM/dd/yy HH:mm"));
		cstring2.ClearString();
		cstring2.Append(GameConstants.GetDateTime(LeaderBoardManager.Instance.KvKTopBoard.SortTime + (long)((ulong)LeaderBoardManager.Instance.KvKTopBoard.KingdomEventRequireTime)).ToString("MM/dd/yy HH:mm"));
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

	// Token: 0x0600133A RID: 4922 RVA: 0x0021A0E0 File Offset: 0x002182E0
	public void CreateSubBoard()
	{
		this.AGS_Form.GetChild(5).gameObject.SetActive(false);
		this.AGS_Form.GetChild(12).gameObject.SetActive(false);
		this.SPHeight.Clear();
		this.SPHeight.Add(38f);
		byte subBoardID = UIKVKLBoard.SubBoardID;
		switch (subBoardID)
		{
		case 5:
			for (int i = 0; i < LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID].Count; i++)
			{
				if (((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][i]).KingdomID > 0)
				{
					this.SPHeight.Add(53f);
				}
			}
			goto IL_16D;
		case 6:
			break;
		case 7:
			for (int j = 0; j < LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID].Count; j++)
			{
				this.SPHeight.Add(53f);
			}
			goto IL_16D;
		default:
			if (subBoardID != 15)
			{
				goto IL_16D;
			}
			break;
		}
		for (int k = 0; k < LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID].Count; k++)
		{
			if (LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][k].Value > 0UL)
			{
				this.SPHeight.Add(53f);
			}
		}
		IL_16D:
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		LeaderBoardSubBoardID subBoardID2 = (LeaderBoardSubBoardID)UIKVKLBoard.SubBoardID;
		switch (subBoardID2)
		{
		case LeaderBoardSubBoardID.KVKKingdom:
			component.text = DataManager.Instance.mStringTable.GetStringByID(9588u);
			break;
		case LeaderBoardSubBoardID.KVKAllianceRank:
			component.text = DataManager.Instance.mStringTable.GetStringByID(9589u);
			break;
		case LeaderBoardSubBoardID.KVKAllianceMemberRank:
			component.text = DataManager.Instance.mStringTable.GetStringByID(9855u);
			break;
		default:
			if (subBoardID2 == LeaderBoardSubBoardID.KVKPersonRank)
			{
				component.text = DataManager.Instance.mStringTable.GetStringByID(9590u);
			}
			break;
		}
		this.AGS_Form.GetChild(3).gameObject.SetActive(true);
		if (UIKVKLBoard.isPersonBoard)
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
		if (UIKVKLBoard.SubBoardID == 5 && LeaderBoardManager.Instance.MyRank[(int)UIKVKLBoard.SubBoardID] != 0)
		{
			this.AGS_Form.GetChild(3).gameObject.SetActive(false);
			this.AGS_Form.GetChild(5).gameObject.SetActive(true);
			this.AGS_Form.GetChild(2).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
			this.Ranking.ClearString();
			this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.MyRank[(int)UIKVKLBoard.SubBoardID], 1, true);
			this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9849u));
			component.text = this.Ranking.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		if (UIKVKLBoard.SubBoardID == 7)
		{
			this.Ranking.ClearString();
			if (LeaderBoardManager.Instance.MyRank[(int)UIKVKLBoard.SubBoardID] != 0)
			{
				component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
				this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.MyRank[(int)UIKVKLBoard.SubBoardID], 1, true);
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
		else if (UIKVKLBoard.isPersonBoard)
		{
			this.Ranking.ClearString();
			if (LeaderBoardManager.Instance.MyRank[(int)UIKVKLBoard.SubBoardID] != 0)
			{
				component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
				this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.MyRank[(int)UIKVKLBoard.SubBoardID], 1, true);
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
			if (LeaderBoardManager.Instance.MyRank[(int)UIKVKLBoard.SubBoardID] != 0)
			{
				this.Ranking.IntToFormat((long)LeaderBoardManager.Instance.MyRank[(int)UIKVKLBoard.SubBoardID], 1, false);
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
		if (UIKVKLBoard.SubBoardID == 7 && LeaderBoardManager.Instance.MyRank[(int)UIKVKLBoard.SubBoardID] != 0 && (int)LeaderBoardManager.Instance.MyRank[(int)UIKVKLBoard.SubBoardID] <= LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID].Count)
		{
			component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
			this.RankValue.ClearString();
			this.RankValue.uLongToFormat(LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][(int)(LeaderBoardManager.Instance.MyRank[(int)UIKVKLBoard.SubBoardID] - 1)].Value, 1, true);
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

	// Token: 0x0600133B RID: 4923 RVA: 0x0021A994 File Offset: 0x00218B94
	private void MainBoardChange()
	{
		if (LeaderBoardManager.Instance.KingdomBoardNextTime < DataManager.Instance.ServerTime || LeaderBoardManager.Instance.KvKTopBoard.AllianceID != (ulong)DataManager.Instance.RoleAlliance.Id)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_KVK_TOPBOARD;
			messagePacket.AddSeqId();
			ushort data;
			byte data2;
			GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out data, out data2);
			messagePacket.Add(data);
			messagePacket.Add(data2);
			messagePacket.Send(false);
			UIKVKLBoard.isTopBoard = true;
			return;
		}
		this.CreateTopBoard();
		base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardTypes);
		this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false, true);
		this.AGS_Panel1.GoTo(0);
	}

	// Token: 0x0600133C RID: 4924 RVA: 0x0021AA5C File Offset: 0x00218C5C
	private void SubBoardChange(byte newSubID)
	{
		UIKVKLBoard.SubBoardID = newSubID;
		UIKVKLBoard.isTopBoard = false;
		if (UIKVKLBoard.SubBoardID == 7 && LeaderBoardManager.Instance.BoardUpdateTime[(int)UIKVKLBoard.SubBoardID] < DataManager.Instance.ServerTime)
		{
			UILeaderBoardBase.TopIndex[(int)UIKVKLBoard.SubBoardID] = 0;
			LeaderBoardManager.Instance.ClearBoard(7);
			LeaderBoardManager.Instance.MyRank[(int)UIKVKLBoard.SubBoardID] = 0;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.AddSeqId();
			messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AEVENT_PERSONAL_RANK;
			messagePacket.Send(false);
		}
		else if (UIKVKLBoard.SubBoardID >= 5 && LeaderBoardManager.Instance.BoardUpdateTime[(int)UIKVKLBoard.SubBoardID] < DataManager.Instance.ServerTime)
		{
			UILeaderBoardBase.TopIndex[(int)UIKVKLBoard.SubBoardID] = 0;
			MessagePacket messagePacket2 = new MessagePacket(1024);
			messagePacket2.AddSeqId();
			messagePacket2.Protocol = Protocol._MSG_REQUEST_LEADERBOARD_CONTENT;
			ushort data;
			byte data2;
			GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out data, out data2);
			messagePacket2.Add(data);
			messagePacket2.Add(data2);
			messagePacket2.Add(UIKVKLBoard.SubBoardID);
			byte data3 = 0;
			messagePacket2.Add(data3);
			messagePacket2.Add(LeaderBoardManager.Instance.KvKTopBoard.SortTime);
			if (UIKVKLBoard.SubBoardID == 6)
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
			this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[(int)UIKVKLBoard.SubBoardID]);
		}
	}

	// Token: 0x0600133D RID: 4925 RVA: 0x0021ABF8 File Offset: 0x00218DF8
	public void UpdateRow_FunctionList(GameObject item, int dataIdx, int panelObjectIdx)
	{
		switch (dataIdx)
		{
		case 0:
		{
			item.transform.GetChild(2).gameObject.SetActive(false);
			item.transform.GetChild(3).gameObject.SetActive(false);
			UIText component = item.transform.GetChild(4).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(9588u);
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			DataManager.MapDataController.GetKingdomName(LeaderBoardManager.Instance.KvKTopBoard.TopKingdom, ref cstring);
			this.SortTextArray[1, panelObjectIdx].ClearString();
			this.SortTextArray[1, panelObjectIdx].IntToFormat((long)LeaderBoardManager.Instance.KvKTopBoard.TopKingdom, 1, false);
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
			component2.m_BtnID2 = 5;
			this.KingdomImg.SetParent(item.transform, false);
			this.KingdomImg.gameObject.SetActive(true);
			this.KingdomImg.anchoredPosition = new Vector2(-323f, -20f);
			break;
		}
		case 1:
		{
			item.transform.GetChild(2).gameObject.SetActive(LeaderBoardManager.Instance.KvKTopBoard.KvKTopAlliEmblem != 0);
			item.transform.GetChild(3).gameObject.SetActive(false);
			if (item.transform.GetChild(2).GetChild(0).childCount < 1)
			{
				GUIManager.Instance.InitBadgeTotem(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.KvKTopBoard.KvKTopAlliEmblem);
			}
			else
			{
				GUIManager.Instance.SetBadgeTotemImg(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.KvKTopBoard.KvKTopAlliEmblem);
			}
			UIText component = item.transform.GetChild(4).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(9589u);
			this.SortTextArray[1, panelObjectIdx].ClearString();
			if (LeaderBoardManager.Instance.KvKTopBoard.KvKTopAlliScore == 0UL)
			{
				this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8477u));
			}
			else
			{
				GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.KvKTopBoard.KvKTopAlliKingdomID, LeaderBoardManager.Instance.KvKTopBoard.KvKTopAlliName, LeaderBoardManager.Instance.KvKTopBoard.KvKTopAlliTag, false);
			}
			component = item.transform.GetChild(5).GetComponent<UIText>();
			component.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			if (LeaderBoardManager.Instance.KvKTopBoard.KvKTopAlliScore > 0UL)
			{
				this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.KvKTopBoard.KvKTopAlliScore, 1, true);
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
			item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.KvKTopBoard.KvKPlayerValue != 0UL);
			if (item.transform.GetChild(3).childCount < 1)
			{
				GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.KvKTopBoard.KvKPlayerHead, 11, 0, 0, false, false, true, false);
			}
			else
			{
				GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.KvKTopBoard.KvKPlayerHead, 11, 0, 0);
			}
			UIText component = item.transform.GetChild(4).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(9590u);
			this.SortTextArray[1, panelObjectIdx].ClearString();
			if (LeaderBoardManager.Instance.KvKTopBoard.KvKPlayerValue == 0UL)
			{
				this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475u));
			}
			else
			{
				GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.KvKTopBoard.KvKTopPlayerKingdomID, LeaderBoardManager.Instance.KvKTopBoard.KvKTopPlayerName, LeaderBoardManager.Instance.KvKTopBoard.KvKTopPlayerTag, false);
			}
			component = item.transform.GetChild(5).GetComponent<UIText>();
			component.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			if (LeaderBoardManager.Instance.KvKTopBoard.KvKPlayerValue > 0UL)
			{
				this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.KvKTopBoard.KvKPlayerValue, 1, true);
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
		case 3:
		{
			item.transform.GetChild(2).gameObject.SetActive(false);
			item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.KvKTopBoard.KvKAlliTopPlayerName.Length > 0 && DataManager.Instance.RoleAlliance.Id != 0u);
			if (item.transform.GetChild(3).childCount < 1)
			{
				GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.KvKTopBoard.KvKAlliTopPlayerHead, 11, 0, 0, false, false, true, false);
			}
			else
			{
				GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.KvKTopBoard.KvKAlliTopPlayerHead, 11, 0, 0);
			}
			UIText component = item.transform.GetChild(4).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(9855u);
			this.SortTextArray[1, panelObjectIdx].ClearString();
			if (DataManager.Instance.RoleAlliance.Id == 0u || LeaderBoardManager.Instance.KvKTopBoard.KvKAlliTopPlayerName.Length == 0)
			{
				this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475u));
			}
			else
			{
				GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], 0, LeaderBoardManager.Instance.KvKTopBoard.KvKAlliTopPlayerName, DataManager.Instance.RoleAlliance.Tag, false);
			}
			component = item.transform.GetChild(5).GetComponent<UIText>();
			component.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			if (DataManager.Instance.RoleAlliance.Id > 0u && LeaderBoardManager.Instance.KvKTopBoard.KvKAlliTopPlayerName.Length > 0)
			{
				this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.KvKTopBoard.KvKAlliTopPlayerValue, 1, true);
				this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
			}
			component = item.transform.GetChild(6).GetComponent<UIText>();
			component.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			UIButton component2 = item.transform.GetChild(1).GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 3;
			component2.m_BtnID2 = 7;
			break;
		}
		}
	}

	// Token: 0x0600133E RID: 4926 RVA: 0x0021B5AC File Offset: 0x002197AC
	public void UpdatRow_Boards(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (dataIdx == 0)
		{
			byte subBoardID = UIKVKLBoard.SubBoardID;
			switch (subBoardID)
			{
			case 5:
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
			case 7:
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
			default:
				if (subBoardID == 15)
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
				}
				break;
			}
		}
		else
		{
			LeaderBoardManager.Instance.CheckNextPart(UIKVKLBoard.SubBoardID, (byte)dataIdx);
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			this.SortTextArray[0, panelObjectIdx].ClearString();
			this.SortTextArray[0, panelObjectIdx].IntToFormat((long)dataIdx, 1, false);
			this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
			UIText component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
			component.text = this.SortTextArray[0, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			byte subBoardID = UIKVKLBoard.SubBoardID;
			switch (subBoardID)
			{
			case 5:
			{
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.ClearString();
				DataManager.MapDataController.GetKingdomName(((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1]).KingdomID, ref cstring);
				this.SortTextArray[1, panelObjectIdx].ClearString();
				this.SortTextArray[1, panelObjectIdx].IntToFormat((long)((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1]).KingdomID, 1, false);
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
				GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], ((BoardUnitKingdomWarAlliance)LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1]).KingdomID, LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1].AlliaceTag, false);
				component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				break;
			case 7:
				this.SortTextArray[1, panelObjectIdx].ClearString();
				GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], 0, LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1].AlliaceTag, false);
				component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
				component.text = this.SortTextArray[1, panelObjectIdx].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				break;
			default:
				if (subBoardID == 15)
				{
					this.SortTextArray[1, panelObjectIdx].ClearString();
					GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], ((WorldRankingBoardUnit)LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1]).KingdomID, LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1].AlliaceTag, false);
					component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
					component.text = this.SortTextArray[1, panelObjectIdx].ToString();
					component.SetAllDirty();
					component.cachedTextGenerator.Invalidate();
				}
				break;
			}
			this.SortTextArray[2, panelObjectIdx].ClearString();
			if (UIKVKLBoard.SubBoardID == 5)
			{
				item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
				item.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);
				item.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
				if (((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1]).KingKingdomID != 0)
				{
					if (((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1]).KingKingdomID == ((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1]).KingdomID)
					{
						GameConstants.GetNameString(this.SortTextArray[2, panelObjectIdx], ((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1]).KingKingdomID, LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1].AlliaceTag, true);
					}
					else
					{
						GameConstants.GetNameString(this.SortTextArray[2, panelObjectIdx], ((BoardUnitKingdom)LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1]).KingKingdomID, LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1].AlliaceTag, true);
						this.SortTextArray[2, panelObjectIdx].Insert(0, "<color=#FFD74CFF>", -1);
						this.SortTextArray[2, panelObjectIdx].Append("</color>");
					}
				}
			}
			else
			{
				item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
				item.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);
				item.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
				this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1].Value, 1, true);
				this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
			}
			component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
			component.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			UIButton component2 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 4;
			component2.m_BtnID2 = dataIdx - 1;
			if (UIKVKLBoard.SubBoardID == 5 && LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][dataIdx - 1].Name.Length == 0)
			{
				component2.gameObject.SetActive(false);
			}
			else
			{
				component2.gameObject.SetActive(true);
			}
			if (dataIdx == (int)LeaderBoardManager.Instance.MyRank[(int)UIKVKLBoard.SubBoardID])
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

	// Token: 0x0600133F RID: 4927 RVA: 0x0021C2A8 File Offset: 0x0021A4A8
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

	// Token: 0x06001340 RID: 4928 RVA: 0x0021C2E8 File Offset: 0x0021A4E8
	public override void UpdateUI(int arg1, int arg2)
	{
		if ((byte)arg1 == 5)
		{
			this.door.CloseMenu(false);
		}
		switch ((byte)arg1)
		{
		case 2:
			if (UIKVKLBoard.isTopBoard)
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
			if (!UIKVKLBoard.isTopBoard && arg2 == (int)UIKVKLBoard.SubBoardID)
			{
				this.CreateSubBoard();
				base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
				this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
			}
			break;
		case 4:
			if (!UIKVKLBoard.isTopBoard && arg2 == (int)UIKVKLBoard.SubBoardID)
			{
				UILeaderBoardBase.TopIndex[(int)UIKVKLBoard.SubBoardID] = 0;
				this.CreateSubBoard();
				base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
				this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
				this.AGS_Panel2.GoTo(0);
			}
			break;
		}
	}

	// Token: 0x06001341 RID: 4929 RVA: 0x0021C404 File Offset: 0x0021A604
	public void Update()
	{
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
			if (UIKVKLBoard.isTopBoard)
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
				this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[(int)UIKVKLBoard.SubBoardID]);
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

	// Token: 0x06001342 RID: 4930 RVA: 0x0021C610 File Offset: 0x0021A810
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

	// Token: 0x06001343 RID: 4931 RVA: 0x0021C67C File Offset: 0x0021A87C
	public override void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		switch (btnID)
		{
		case 0:
			if (UIKVKLBoard.isTopBoard)
			{
				this.door.CloseMenu(false);
				UIKVKLBoard.NewOpen = true;
			}
			else
			{
				UILeaderBoardBase.TopIndex[(int)UIKVKLBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
				this.MainBoardChange();
			}
			break;
		default:
			if (btnID == 99)
			{
				GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7028u), DataManager.Instance.mStringTable.GetStringByID(9041u), null, null, 0, 0, true, false);
			}
			break;
		case 3:
		{
			LeaderBoardSubBoardID leaderBoardSubBoardID = (LeaderBoardSubBoardID)sender.m_BtnID2;
			switch (leaderBoardSubBoardID)
			{
			case LeaderBoardSubBoardID.KVKKingdom:
				UIKVKLBoard.isPersonBoard = true;
				break;
			case LeaderBoardSubBoardID.KVKAllianceRank:
				UIKVKLBoard.isPersonBoard = false;
				break;
			case LeaderBoardSubBoardID.KVKAllianceMemberRank:
				if (DataManager.Instance.RoleAlliance.Id == 0u || LeaderBoardManager.Instance.KvKTopBoard.KvKAlliTopPlayerName.Length == 0)
				{
					return;
				}
				UIKVKLBoard.isPersonBoard = true;
				break;
			default:
				if (leaderBoardSubBoardID == LeaderBoardSubBoardID.KVKPersonRank)
				{
					UIKVKLBoard.isPersonBoard = true;
				}
				break;
			}
			this.SubBoardChange((byte)sender.m_BtnID2);
			break;
		}
		case 4:
			if (UIKVKLBoard.isPersonBoard)
			{
				UILeaderBoardBase.TopIndex[(int)UIKVKLBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
				DataManager.Instance.ShowLordProfile(LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][sender.m_BtnID2].Name.ToString());
			}
			else
			{
				UILeaderBoardBase.TopIndex[(int)UIKVKLBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
				DataManager.Instance.AllianceView.Id = ((BoardUnitAlliance)LeaderBoardManager.Instance.Boards[(int)UIKVKLBoard.SubBoardID][sender.m_BtnID2]).AllianceID;
				this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5, 0, false);
			}
			break;
		}
	}

	// Token: 0x04003B12 RID: 15122
	public static byte SubBoardID;

	// Token: 0x04003B13 RID: 15123
	public static bool isTopBoard = true;

	// Token: 0x04003B14 RID: 15124
	public static bool isPersonBoard = true;

	// Token: 0x04003B15 RID: 15125
	public static bool NewOpen;

	// Token: 0x04003B16 RID: 15126
	private RectTransform KingdomImg;
}
