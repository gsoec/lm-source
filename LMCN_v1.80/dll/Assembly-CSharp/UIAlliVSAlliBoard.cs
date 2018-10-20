using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000396 RID: 918
public class UIAlliVSAlliBoard : UILeaderBoardBase
{
	// Token: 0x06001306 RID: 4870 RVA: 0x00211C90 File Offset: 0x0020FE90
	public override void OnOpen(int arg1, int arg2)
	{
		base.OnOpen(arg1, arg2);
		this.RankingTable = new List<int>();
		if (LeaderBoardManager.Instance.AllianceWarAlliBoardUpdateTime < DataManager.Instance.ServerTime || LeaderBoardManager.Instance.MobiGroupAllianceID != DataManager.Instance.RoleAlliance.Id)
		{
			UIAlliVSAlliBoard.MemTopIndex = 0;
			ActivityManager.Instance.AllianceWarMgr.SendAllianceWarList();
			this.DataReady = false;
		}
		else
		{
			this.DataReady = true;
		}
	}

	// Token: 0x06001307 RID: 4871 RVA: 0x00211D10 File Offset: 0x0020FF10
	private void CreateAlliVSAlliBoard()
	{
		this.SPHeight.Clear();
		this.SPHeight.Add(38f);
		for (ushort num = 0; num < (ushort)ActivityManager.Instance.AllianceWarMgr.GetRegisterCount(); num += 1)
		{
			this.SPHeight.Add(53f);
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID(17012u);
		this.AGS_Form.GetChild(2).gameObject.SetActive(true);
		this.AGS_Form.GetChild(5).gameObject.SetActive(false);
		this.AGS_Form.GetChild(3).gameObject.SetActive(true);
		this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
		this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(false);
		Transform child = this.AGS_Form.GetChild(3).GetChild(0);
		child.gameObject.SetActive(true);
		GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, 11, 0, 0);
		if (ActivityManager.Instance.AllianceWarMgr.MyRank > 0)
		{
			int num2;
			if (ActivityManager.Instance.AllianceWarMgr.GetRegisterCount() >= ActivityManager.Instance.AW_MemberCount)
			{
				if (ActivityManager.Instance.AllianceWarMgr.MyRank <= ActivityManager.Instance.AW_MemberCount)
				{
					num2 = (int)(ActivityManager.Instance.AW_MemberCount - ActivityManager.Instance.AllianceWarMgr.MyRank + 1);
				}
				else
				{
					num2 = (int)(ActivityManager.Instance.AW_MemberCount - ActivityManager.Instance.AllianceWarMgr.MyRank);
				}
			}
			else
			{
				num2 = ActivityManager.Instance.AllianceWarMgr.getMyRankIndex();
			}
			component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
			this.Ranking.ClearString();
			if (num2 < 0)
			{
				this.Ranking.IntToFormat((long)(num2 * -1), 1, false);
				this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17017u));
			}
			else
			{
				this.Ranking.IntToFormat((long)num2, 1, false);
				this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17036u));
			}
			component.text = this.Ranking.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
			this.RankValue.ClearString();
			AllianceWarManager._RegisterData myDataIdx = ActivityManager.Instance.AllianceWarMgr.GetMyDataIdx((int)ActivityManager.Instance.AllianceWarMgr.MyRank);
			this.RankValue.uLongToFormat(myDataIdx.Power, 1, true);
			this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7061u));
			component.text = this.RankValue.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.AGS_Form.GetChild(3).gameObject.SetActive(false);
			this.AGS_Form.GetChild(5).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
			this.Ranking.ClearString();
			this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(17216u));
			component.text = this.Ranking.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		this.RankingTable.Clear();
		this.RankingTable.Add(UIAlliVSAlliBoard.SPtab);
		for (int i = 0; i < (int)ActivityManager.Instance.AllianceWarMgr.GetRegisterCount(); i++)
		{
			this.RankingTable.Add(i);
		}
		if (ActivityManager.Instance.AllianceWarMgr.GetRegisterCount() == 0)
		{
			this.AGS_Form.GetChild(13).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(17075u);
		}
		else
		{
			this.AGS_Form.GetChild(13).gameObject.SetActive(false);
		}
	}

	// Token: 0x06001308 RID: 4872 RVA: 0x002121A0 File Offset: 0x002103A0
	public void Update()
	{
		if (!this.LoadComplet)
		{
			base.SetDefaultSize();
			this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(10).gameObject.SetActive(true);
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
			this.CreateAlliVSAlliBoard();
			base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
			this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
			if (UIAlliVSAlliBoard.MemTopIndex == 0 && UIAlliVSAlliBoard.NewOpen)
			{
				UIAlliVSAlliBoard.NewOpen = false;
				int myRankIndex = ActivityManager.Instance.AllianceWarMgr.getMyRankIndex();
				if (myRankIndex > 4)
				{
					UIAlliVSAlliBoard.MemTopIndex = myRankIndex - 3;
				}
			}
			this.AGS_Panel2.GoTo(UIAlliVSAlliBoard.MemTopIndex);
		}
	}

	// Token: 0x06001309 RID: 4873 RVA: 0x00212324 File Offset: 0x00210524
	public override void UpdateUI(int arg1, int arg2)
	{
		this.CreateAlliVSAlliBoard();
		if (!this.LoadComplet)
		{
			this.DataReady = true;
		}
		else
		{
			base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
			this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
			if (UIAlliVSAlliBoard.MemTopIndex == 0 && UIAlliVSAlliBoard.NewOpen)
			{
				UIAlliVSAlliBoard.NewOpen = false;
				int myRankIndex = ActivityManager.Instance.AllianceWarMgr.getMyRankIndex();
				if (myRankIndex > 4)
				{
					UIAlliVSAlliBoard.MemTopIndex = myRankIndex - 3;
				}
			}
			this.AGS_Panel2.GoTo(UIAlliVSAlliBoard.MemTopIndex);
		}
	}

	// Token: 0x0600130A RID: 4874 RVA: 0x002123B4 File Offset: 0x002105B4
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

	// Token: 0x0600130B RID: 4875 RVA: 0x00212420 File Offset: 0x00210620
	public override void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (dataIdx == 0)
		{
			item.transform.GetChild(0).gameObject.SetActive(true);
			item.transform.GetChild(1).gameObject.SetActive(false);
			UIText component = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(17013u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(17012u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
			component.text = DataManager.Instance.mStringTable.GetStringByID(1560u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else if (this.RankingTable[dataIdx] == UIAlliVSAlliBoard.SPtab)
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
			this.SortTextArray[1, panelObjectIdx].Append(string.Empty);
			component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
			component.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			this.SortTextArray[2, panelObjectIdx].Append(string.Empty);
			component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
			component.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			UISpritesArray component2 = item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>();
			component2.SetSpriteIndex(0);
			component2 = item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>();
			component2.SetSpriteIndex(0);
			component2 = item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
			component2.SetSpriteIndex(0);
		}
		else
		{
			AllianceWarManager._RegisterData dataIndex = ActivityManager.Instance.AllianceWarMgr.GetDataIndex(this.RankingTable[dataIdx]);
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
			this.SortTextArray[0, panelObjectIdx].ClearString();
			if (dataIdx > (int)ActivityManager.Instance.AW_MemberCount)
			{
				this.SortTextArray[0, panelObjectIdx].IntToFormat((long)(dataIdx - (int)ActivityManager.Instance.AW_MemberCount), 1, false);
				this.SortTextArray[0, panelObjectIdx].AppendFormat("~{0}");
			}
			else
			{
				this.SortTextArray[0, panelObjectIdx].IntToFormat((long)dataIdx, 1, false);
				this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
			}
			UIText component = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
			component.text = this.SortTextArray[0, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[1, panelObjectIdx].ClearString();
			this.SortTextArray[1, panelObjectIdx].Append(dataIndex.Name);
			component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
			component.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			this.SortTextArray[2, panelObjectIdx].uLongToFormat(dataIndex.Power, 1, true);
			this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
			component = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
			component.text = this.SortTextArray[2, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			UIButton component3 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = 6;
			component3.m_BtnID2 = dataIdx;
			if (ActivityManager.Instance.AllianceWarMgr.getMyRankIndex() == dataIdx)
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

	// Token: 0x0600130C RID: 4876 RVA: 0x00212AF0 File Offset: 0x00210CF0
	public override void OnButtonClick(UIButton sender)
	{
		int topIdx = this.AGS_Panel2.GetTopIdx();
		if (topIdx > 0)
		{
			UIAlliVSAlliBoard.MemTopIndex = topIdx;
		}
		else
		{
			UIAlliVSAlliBoard.MemTopIndex = 1;
		}
		int btnID = sender.m_BtnID1;
		if (btnID != 0)
		{
			if (btnID != 6)
			{
				if (btnID == 99)
				{
					GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7028u), DataManager.Instance.mStringTable.GetStringByID(9041u), null, null, 0, 0, true, false);
				}
			}
			else
			{
				AllianceWarManager._RegisterData dataIndex = ActivityManager.Instance.AllianceWarMgr.GetDataIndex(this.RankingTable[sender.m_BtnID2]);
				DataManager.Instance.ShowLordProfile(dataIndex.Name.ToString());
			}
		}
		else
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x04003AFC RID: 15100
	public static int MemTopIndex;

	// Token: 0x04003AFD RID: 15101
	public static bool NewOpen;

	// Token: 0x04003AFE RID: 15102
	public List<int> RankingTable;

	// Token: 0x04003AFF RID: 15103
	private static int SPtab = 10000;
}
