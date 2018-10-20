using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020003B6 RID: 950
internal class UINobilityOccupyBoard : UILeaderBoardBase
{
	// Token: 0x06001391 RID: 5009 RVA: 0x0022DC80 File Offset: 0x0022BE80
	public override void OnOpen(int arg1, int arg2)
	{
		base.OnOpen(0, 0);
		if (LeaderBoardManager.Instance.NobileTime < DataManager.Instance.ServerTime | arg1 != (int)LeaderBoardManager.Instance.NobileWonderId)
		{
			this.CurrentWonderId = (byte)arg1;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_FEDERAL_RANKDATA;
			messagePacket.AddSeqId();
			messagePacket.Add((byte)arg1);
			messagePacket.Send(false);
		}
		else
		{
			this.CurrentWonderId = (byte)arg1;
			this.DataReady = true;
		}
	}

	// Token: 0x06001392 RID: 5010 RVA: 0x0022DD0C File Offset: 0x0022BF0C
	private void CreateNobilityOccupyBoard()
	{
		if (LeaderBoardManager.Instance.NobileWonderId != (ushort)this.CurrentWonderId)
		{
			return;
		}
		this.SPHeight.Clear();
		this.SPHeight.Add(38f);
		int num = Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
		ushort num2 = 0;
		while ((int)num2 < LeaderBoardManager.Instance.NobileBoard.Count)
		{
			if (LeaderBoardManager.Instance.NobileBoard[(int)num2].HomeKingdomID <= 0)
			{
				break;
			}
			this.SPHeight.Add(53f);
			num2 += 1;
		}
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID(11153u);
		this.AGS_Form.GetChild(2).gameObject.SetActive(true);
		this.AGS_Form.GetChild(5).gameObject.SetActive(false);
		this.AGS_Form.GetChild(3).gameObject.SetActive(true);
		this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
		this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(false);
		Transform child = this.AGS_Form.GetChild(3).GetChild(0);
		child.gameObject.SetActive(true);
		GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, LeaderBoardManager.Instance.NobileHead, 11, 0, 0);
		component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
		this.Ranking.ClearString();
		this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(11154u));
		component.text = this.Ranking.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
		this.RankValue.ClearString();
		if (LeaderBoardManager.Instance.NobileBoard.Count > 0)
		{
			GameConstants.GetNameString(this.RankValue, LeaderBoardManager.Instance.NobileBoard[0].HomeKingdomID, LeaderBoardManager.Instance.NobileBoard[0].Name, LeaderBoardManager.Instance.NobileBoard[0].AllianceTag, true);
		}
		component.text = this.RankValue.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001393 RID: 5011 RVA: 0x0022DFA8 File Offset: 0x0022C1A8
	public void Update()
	{
		if (!this.LoadComplet)
		{
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
			this.CreateNobilityOccupyBoard();
			base.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
			this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false, true);
			this.AGS_Panel2.GoTo(0);
		}
	}

	// Token: 0x06001394 RID: 5012 RVA: 0x0022E0C0 File Offset: 0x0022C2C0
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == (int)this.CurrentWonderId)
		{
			this.CreateNobilityOccupyBoard();
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
	}

	// Token: 0x06001395 RID: 5013 RVA: 0x0022E110 File Offset: 0x0022C310
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
		else
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001396 RID: 5014 RVA: 0x0022E154 File Offset: 0x0022C354
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
			GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.NobileBoard[dataIdx - 1].HomeKingdomID, LeaderBoardManager.Instance.NobileBoard[dataIdx - 1].Name, LeaderBoardManager.Instance.NobileBoard[dataIdx - 1].AllianceTag, true);
			component = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
			component.text = this.SortTextArray[1, panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SortTextArray[2, panelObjectIdx].ClearString();
			GameConstants.GetTimeString(this.SortTextArray[2, panelObjectIdx], LeaderBoardManager.Instance.NobileBoard[dataIdx - 1].OccupyTime, false, false, true, false, true);
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

	// Token: 0x06001397 RID: 5015 RVA: 0x0022E57C File Offset: 0x0022C77C
	public override void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID != 0)
		{
			if (btnID != 10)
			{
				if (btnID != 99)
				{
				}
			}
			else if (sender.m_BtnID2 < LeaderBoardManager.Instance.NobileBoard.Count && sender.m_BtnID2 >= 0)
			{
				DataManager.Instance.ShowLordProfile(LeaderBoardManager.Instance.NobileBoard[sender.m_BtnID2].Name.ToString());
			}
		}
		else
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x04003C13 RID: 15379
	public byte CurrentWonderId;
}
