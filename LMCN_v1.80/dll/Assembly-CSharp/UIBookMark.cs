using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000857 RID: 2135
public class UIBookMark : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06002C20 RID: 11296 RVA: 0x00486A1C File Offset: 0x00484C1C
	public override void OnOpen(int arg1, int arg2)
	{
		this.ThisTransfrom = base.transform.GetChild(0);
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		this.PageInfoStr = StringManager.Instance.SpawnString(30);
		DataManager.Instance.RoleBookMark.CheckUpdate(false);
		if (DataManager.Instance.RoleAlliance.Id > 0u)
		{
			DataManager.Instance.RoleBookMark.CheckUpdate_Alliance(false);
		}
		instance2.UpdateUI(EGUIWindow.Door, 1, 2);
		Font ttffont = instance2.GetTTFFont();
		this.MainTitle = this.ThisTransfrom.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.MainTitle.font = ttffont;
		this.AddRefreshText(this.MainTitle);
		this.PageInfo = this.ThisTransfrom.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.PageInfo.font = ttffont;
		this.AddRefreshText(this.PageInfo);
		if (instance2.bOpenOnIPhoneX)
		{
			this.ThisTransfrom.GetChild(7).GetComponent<CustomImage>().enabled = false;
		}
		else
		{
			this.ThisTransfrom.GetChild(7).GetComponent<CustomImage>().hander = instance2.m_ItemInfo;
		}
		this.ThisTransfrom.GetChild(7).GetChild(0).GetComponent<CustomImage>().hander = instance2.m_ItemInfo;
		UIButton component = this.ThisTransfrom.GetChild(7).GetChild(0).GetComponent<UIButton>();
		component.m_BtnID1 = 7;
		component.m_Handler = this;
		this.Type1 = this.ThisTransfrom.GetChild(3);
		this.Type2 = this.ThisTransfrom.GetChild(4);
		component = this.Type2.GetChild(0).GetComponent<UIButton>();
		component.m_BtnID1 = 8;
		component.m_Handler = this;
		UIText component2 = this.Type2.GetChild(0).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = instance.mStringTable.GetStringByID(6089u);
		this.AddRefreshText(component2);
		this.BookSpriteArr = this.ThisTransfrom.GetChild(5).GetComponent<UISpritesArray>();
		byte b = 0;
		while ((int)b < this.BookTag.Length)
		{
			component = this.ThisTransfrom.GetChild(1).GetChild((int)b).GetComponent<UIButton>();
			this.BookTag[(int)b] = this.ThisTransfrom.GetChild(1).GetChild((int)b).GetChild(0).GetComponent<CanvasGroup>();
			this.BookTagText[(int)b] = this.ThisTransfrom.GetChild(1).GetChild((int)b).GetChild(1).GetComponent<UIText>();
			component.m_BtnID1 = (int)b;
			component.m_Handler = this;
			this.BookTagText[(int)b].font = ttffont;
			this.BookTagText[(int)b].text = instance.mStringTable.GetStringByID(4584u + (uint)b);
			this.AddRefreshText(this.BookTagText[(int)b]);
			b += 1;
		}
		this.TabTextColor = this.BookTagText[0].color;
		this.BookTagObj = this.ThisTransfrom.GetChild(1).gameObject;
		for (int i = 0; i < this.AllianceTag.Length; i++)
		{
			component = this.ThisTransfrom.GetChild(2).GetChild(i).GetComponent<UIButton>();
			this.AllianceTag[i] = this.ThisTransfrom.GetChild(2).GetChild(i).GetChild(0).GetComponent<CanvasGroup>();
			component.m_BtnID1 = i + 9;
			component.m_Handler = this;
		}
		this.MessageTrans = this.ThisTransfrom.GetChild(6).GetComponent<RectTransform>();
		this.MessageText = this.MessageTrans.GetChild(0).GetComponent<UIText>();
		this.MessageText.font = ttffont;
		this.AddRefreshText(this.MessageText);
		Vector2 vector = this.MessageTrans.sizeDelta;
		vector.x = component2.preferredWidth + 165f;
		this.MessageTrans.sizeDelta = vector;
		Transform child = this.ThisTransfrom.GetChild(8);
		Image component3 = child.GetChild(1).GetComponent<Image>();
		component3.sprite = instance2.LoadFrameSprite("if001");
		component3.material = instance2.GetFrameMaterial();
		child.GetChild(4).GetComponent<UIText>().font = ttffont;
		child.GetChild(5).GetComponent<UIText>().font = ttffont;
		component2 = child.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = instance.mStringTable.GetStringByID(4589u);
		byte b2 = 7;
		this.BookScrollView = this.ThisTransfrom.GetChild(5).GetChild(0).GetComponent<ScrollPanel>();
		this.BookItem = new UIBookMark.ItemEdit[(int)b2];
		this.CurrentTag = UIBookMark.ClickType.TabAll;
		this.CurrentAllianceTag = (UIBookMark.ClickType)(arg1 >> 16);
		float panelHeight = 472f;
		if (this.CurrentAllianceTag != UIBookMark.ClickType.RoleTag && this.CurrentAllianceTag != UIBookMark.ClickType.AllianceTag)
		{
			this.CurrentAllianceTag = UIBookMark.ClickType.RoleTag;
		}
		arg1 &= 65535;
		if (arg1 >= 5)
		{
			this.CurrentAllianceTag = UIBookMark.ClickType.RoleTag;
			this.Type = UIBookMark.BookMarkType.Type2;
			this.Type1.gameObject.SetActive(false);
			this.Type2.gameObject.SetActive(true);
			RectTransform component4 = this.BookScrollView.GetComponent<RectTransform>();
			vector = component4.anchoredPosition;
			vector.Set(-30f, -36.09f);
			component4.anchoredPosition = vector;
			vector.Set(776f, 392.8f);
			component4.sizeDelta = vector;
			this.BookMarkSel = new byte[100];
		}
		this.BookScrollView.IntiScrollPanel(panelHeight, 0f, 0f, this.ItemsHeight, (int)b2, this);
		this.BookScrollRect = this.ThisTransfrom.GetChild(5).GetChild(0).GetChild(0).GetComponent<RectTransform>();
		if (instance2.BookMarkSaved[0] > 0)
		{
			this.CurrentTag = (UIBookMark.ClickType)instance2.BookMarkSaved[0];
		}
		if (instance2.BookMarkSaved[7] > 0)
		{
			this.CurrentAllianceTag = (UIBookMark.ClickType)instance2.BookMarkSaved[7];
		}
		if (this.CurrentAllianceTag == UIBookMark.ClickType.RoleTag && arg1 > 0 && this.Type == UIBookMark.BookMarkType.Type1)
		{
			if (this.CurrentTag == UIBookMark.ClickType.TabAll)
			{
				arg2 = 0;
			}
			else if (arg1 == 1)
			{
				this.CurrentTag = UIBookMark.ClickType.TabFavor;
			}
			else if (arg1 == 3)
			{
				this.CurrentTag = UIBookMark.ClickType.TabEnemy;
			}
			else
			{
				this.CurrentTag = UIBookMark.ClickType.TabFriend;
			}
		}
		else if (this.CurrentAllianceTag == UIBookMark.ClickType.AllianceTag && instance.RoleAlliance.Id == 0u)
		{
			this.CurrentAllianceTag = UIBookMark.ClickType.RoleTag;
			this.CurrentTag = UIBookMark.ClickType.TabAll;
		}
		this.ChangeAllianceTag(this.CurrentAllianceTag, this.CurrentTag, true, true);
		if (arg2 > 0)
		{
			this.BookScrollView.GoTo(this.getBookMarkIndex((int)this.TypeId[(int)this.CurrentTag], arg2, this.CurrentAllianceTag));
		}
		else
		{
			this.BookScrollView.GoTo((int)GameConstants.ConvertBytesToUShort(GUIManager.Instance.BookMarkSaved, 1), GameConstants.ConvertBytesToFloat(GUIManager.Instance.BookMarkSaved, 3));
		}
		this.AllianceRank = instance.RoleAlliance.Rank;
	}

	// Token: 0x06002C21 RID: 11297 RVA: 0x00487140 File Offset: 0x00485340
	public override void OnClose()
	{
		for (int i = 0; i < this.BookItem.Length; i++)
		{
			this.BookItem[i].Destroy();
		}
		GUIManager.Instance.BookMarkSaved[0] = (byte)this.CurrentTag;
		GUIManager.Instance.BookMarkSaved[7] = (byte)this.CurrentAllianceTag;
		GameConstants.GetBytes((ushort)this.BookScrollView.GetBeginIdx(), GUIManager.Instance.BookMarkSaved, 1);
		GameConstants.GetBytes(this.BookScrollView.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition.y, GUIManager.Instance.BookMarkSaved, 3);
		StringManager.Instance.DeSpawnString(this.PageInfoStr);
	}

	// Token: 0x06002C22 RID: 11298 RVA: 0x00487200 File Offset: 0x00485400
	public void OnButtonClick(UIButton sender)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		switch (sender.m_BtnID1)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			this.ChangeTag((UIBookMark.ClickType)sender.m_BtnID1, false, true);
			break;
		case 4:
			if (this.CurrentAllianceTag == UIBookMark.ClickType.RoleTag)
			{
				door.m_GroundInfo.ModifyBookmarksPanel((ushort)sender.m_BtnID2, UIGroundInfo._BookmarkSwitch.eType.ModifyBookmark);
			}
			else
			{
				door.m_GroundInfo.ModifyBookmarksPanel((ushort)sender.m_BtnID2, UIGroundInfo._BookmarkSwitch.eType.ModifyAlliancemark);
			}
			door.CloseMenu(false);
			break;
		case 5:
			if (this.CurrentAllianceTag == UIBookMark.ClickType.RoleTag)
			{
				DataManager.Instance.RoleBookMark.sendDelBookMark((ushort)sender.m_BtnID2);
			}
			else
			{
				DataManager.Instance.RoleBookMark.sendDelBookMark_Alliance((byte)sender.m_BtnID2);
			}
			break;
		case 6:
		{
			BookMark.eBookType bookType = (BookMark.eBookType)(this.CurrentAllianceTag - 9);
			door.GoToMapID(DataManager.Instance.RoleBookMark.GetKingdomID((ushort)sender.m_BtnID2, bookType), DataManager.Instance.RoleBookMark.GetMapID((ushort)sender.m_BtnID2, bookType), 0, 1, true);
			break;
		}
		case 7:
			door.CloseMenu(false);
			break;
		case 8:
			if (this.Type == UIBookMark.BookMarkType.Type2)
			{
				BookMark roleBookMark = DataManager.Instance.RoleBookMark;
				Array.Clear(roleBookMark.SelectBookMarkIndex, 0, roleBookMark.SelectBookMarkIndex.Length);
				roleBookMark.SelectCount = this.SelectCount;
				int num = 0;
				for (int i = 0; i < this.BookMarkSel.Length; i++)
				{
					if (this.SelectCount == 0)
					{
						break;
					}
					if (this.BookMarkSel[i] > 0)
					{
						roleBookMark.SelectBookMarkIndex[num++] = this.BookMarkSel[i];
						this.SelectCount -= 1;
					}
				}
				door.CloseMenu(false);
			}
			break;
		case 9:
			this.ChangeAllianceTag(UIBookMark.ClickType.RoleTag, this.CurrentTag, false, true);
			break;
		case 10:
			this.ChangeAllianceTag(UIBookMark.ClickType.AllianceTag, this.CurrentTag, false, true);
			break;
		}
	}

	// Token: 0x06002C23 RID: 11299 RVA: 0x0048741C File Offset: 0x0048561C
	private void ChangeTag(UIBookMark.ClickType Tag, bool bForceUpdatge = false, bool bForceMoveBegin = true)
	{
		if (!bForceUpdatge && Tag == this.CurrentTag)
		{
			return;
		}
		if (!bForceUpdatge || Tag != this.CurrentTag)
		{
			UIBookMark.ClickType currentTag = this.CurrentTag;
			this.BookTag[(int)((byte)this.CurrentTag)].alpha = 0f;
			this.CurrentTag = Tag;
			this.BookTagText[(int)((byte)currentTag)].color = this.TabTextColor;
			this.BookTagText[(int)((byte)this.CurrentTag)].color = Color.white;
		}
		else
		{
			this.BookTagText[(int)((byte)this.CurrentTag)].color = Color.white;
		}
		DataManager instance = DataManager.Instance;
		int itemidx = 0;
		Vector2 vector = Vector2.zero;
		if (!bForceMoveBegin)
		{
			itemidx = this.BookScrollView.GetBeginIdx();
			vector = this.BookScrollRect.anchoredPosition;
		}
		this.ItemsHeight.Clear();
		int currentTag2 = (int)this.CurrentTag;
		this.KindData = instance.RoleBookMark.KindDataIDIndex[(int)this.TypeId[currentTag2]];
		if (this.CurrentTag == UIBookMark.ClickType.TabAll)
		{
			this.DataCount = (byte)instance.RoleAttr.BookmarkNum;
		}
		else
		{
			this.DataCount = instance.RoleBookMark.KindDataCount[(int)this.TypeId[currentTag2]];
		}
		for (byte b = 0; b < this.DataCount; b += 1)
		{
			this.ItemsHeight.Add(83f);
		}
		if (this.ItemsHeight.Count == 0)
		{
			this.BookScrollView.gameObject.SetActive(false);
			this.MessageTrans.gameObject.SetActive(true);
		}
		else
		{
			this.MessageTrans.gameObject.SetActive(false);
			this.BookScrollView.gameObject.SetActive(true);
			this.BookScrollView.AddNewDataHeight(this.ItemsHeight, true, true);
		}
		if (!bForceMoveBegin)
		{
			this.BookScrollView.GoTo(itemidx, vector.y);
		}
	}

	// Token: 0x06002C24 RID: 11300 RVA: 0x00487608 File Offset: 0x00485808
	private void ChangeAllianceTag(UIBookMark.ClickType Tag, UIBookMark.ClickType RoleSubTag, bool bForceUpdatge = false, bool bForceMoveBegin = true)
	{
		if (!bForceUpdatge && Tag == this.CurrentAllianceTag)
		{
			return;
		}
		if (DataManager.Instance.RoleAlliance.Id == 0u && Tag == UIBookMark.ClickType.AllianceTag)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			DataManager.Instance.SetSelectRequest = 0;
			door.OpenMenu(EGUIWindow.UI_AllianceHint, 0, 0, false);
			return;
		}
		bool bForceUpdatge2 = false;
		if (!bForceUpdatge || Tag != this.CurrentAllianceTag)
		{
			if (Tag != this.CurrentAllianceTag)
			{
				bForceUpdatge2 = true;
			}
			UIBookMark.ClickType currentAllianceTag = this.CurrentAllianceTag;
			this.AllianceTag[currentAllianceTag - UIBookMark.ClickType.RoleTag].alpha = 0f;
			this.CurrentAllianceTag = Tag;
		}
		else
		{
			bForceUpdatge2 = bForceUpdatge;
		}
		DataManager instance = DataManager.Instance;
		if (this.CurrentAllianceTag == UIBookMark.ClickType.RoleTag)
		{
			this.BookTagObj.SetActive(true);
		}
		else
		{
			this.BookTagObj.SetActive(false);
		}
		this.PageInfoStr.ClearString();
		if (this.CurrentAllianceTag == UIBookMark.ClickType.RoleTag)
		{
			this.MainTitle.text = instance.mStringTable.GetStringByID(4583u);
			this.MessageText.text = instance.mStringTable.GetStringByID(790u);
			this.PageInfoStr.IntToFormat((long)instance.RoleAttr.BookmarkNum, 1, false);
			this.PageInfoStr.IntToFormat((long)instance.RoleAttr.BookmarkLimit, 1, false);
		}
		else
		{
			this.MainTitle.text = instance.mStringTable.GetStringByID(12636u);
			this.MessageText.text = instance.mStringTable.GetStringByID(12630u);
			this.PageInfoStr.IntToFormat((long)instance.RoleBookMark.AllianceBookCount, 1, false);
			this.PageInfoStr.IntToFormat(20L, 1, false);
		}
		if (GUIManager.Instance.IsArabic)
		{
			this.PageInfoStr.AppendFormat("{1} / {0}");
		}
		else
		{
			this.PageInfoStr.AppendFormat("{0} / {1}");
		}
		this.PageInfo.text = this.PageInfoStr.ToString();
		this.PageInfo.SetAllDirty();
		this.PageInfo.cachedTextGenerator.Invalidate();
		if (Tag == UIBookMark.ClickType.RoleTag)
		{
			this.ChangeTag(RoleSubTag, bForceUpdatge2, bForceMoveBegin);
			return;
		}
		int itemidx = 0;
		Vector2 vector = Vector2.zero;
		if (!bForceMoveBegin)
		{
			itemidx = this.BookScrollView.GetBeginIdx();
			vector = this.BookScrollRect.anchoredPosition;
		}
		this.ItemsHeight.Clear();
		this.KindData = instance.RoleBookMark.AllianceIDIndex;
		this.DataCount = instance.RoleBookMark.AllianceBookCount;
		for (byte b = 0; b < this.DataCount; b += 1)
		{
			this.ItemsHeight.Add(83f);
		}
		if (this.ItemsHeight.Count == 0)
		{
			this.BookScrollView.gameObject.SetActive(false);
			this.MessageTrans.gameObject.SetActive(true);
		}
		else
		{
			this.MessageTrans.gameObject.SetActive(false);
			this.BookScrollView.gameObject.SetActive(true);
			this.BookScrollView.AddNewDataHeight(this.ItemsHeight, true, true);
		}
		if (!bForceMoveBegin)
		{
			this.BookScrollView.GoTo(itemidx, vector.y);
		}
	}

	// Token: 0x06002C25 RID: 11301 RVA: 0x00487954 File Offset: 0x00485B54
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Alliance)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					for (int i = 0; i < this.RefreshTextList.Count; i++)
					{
						if (this.RefreshTextList[i] != null && this.RefreshTextList[i].gameObject.activeSelf && this.RefreshTextList[i].enabled)
						{
							this.RefreshTextList[i].enabled = false;
							this.RefreshTextList[i].enabled = true;
						}
					}
				}
			}
			else if (this.CurrentAllianceTag == UIBookMark.ClickType.AllianceTag)
			{
				if (DataManager.Instance.RoleAlliance.Id == 0u)
				{
					Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
					if (door != null)
					{
						door.CloseMenu_Alliance(EGUIWindow.UI_BagFilter);
					}
				}
				if (this.AllianceRank != DataManager.Instance.RoleAlliance.Rank)
				{
					this.UpdateAllianceRank(DataManager.Instance.RoleAlliance.Rank);
				}
			}
		}
		else
		{
			DataManager.Instance.RoleBookMark.CheckUpdate(false);
			if (DataManager.Instance.RoleAlliance.Id > 0u)
			{
				DataManager.Instance.RoleBookMark.CheckUpdate_Alliance(false);
			}
		}
	}

	// Token: 0x06002C26 RID: 11302 RVA: 0x00487AC4 File Offset: 0x00485CC4
	public override void UpdateUI(int arge1, int arge2)
	{
		UIBookMark.ClickType clickType = this.CurrentAllianceTag;
		UIBookMark.ClickType roleSubTag = this.CurrentTag;
		if (arge1 > 0)
		{
			clickType = (UIBookMark.ClickType)(arge1 >> 16);
			roleSubTag = (UIBookMark.ClickType)this.TypeId[arge1 & 65535];
		}
		this.ChangeAllianceTag(clickType, roleSubTag, true, false);
		if (arge2 > 0)
		{
			this.BookScrollView.GoTo(this.getBookMarkIndex(arge1, arge2, clickType));
		}
	}

	// Token: 0x06002C27 RID: 11303 RVA: 0x00487B20 File Offset: 0x00485D20
	private void UpdateAllianceRank(AllianceRank rank = AllianceRank.RANK5)
	{
		if (rank != this.AllianceRank)
		{
			bool bEdit = rank == AllianceRank.RANK5 || rank == AllianceRank.RANK4;
			for (int i = 0; i < this.BookItem.Length; i++)
			{
				this.BookItem[i].EditMode(bEdit);
			}
		}
		this.AllianceRank = rank;
	}

	// Token: 0x06002C28 RID: 11304 RVA: 0x00487B84 File Offset: 0x00485D84
	private int getBookMarkIndex(int type, int mapID, UIBookMark.ClickType bookType)
	{
		BookMark roleBookMark = DataManager.Instance.RoleBookMark;
		if (bookType == UIBookMark.ClickType.RoleTag)
		{
			if (roleBookMark.KindDataCount.Length <= type)
			{
				return 0;
			}
			for (int i = (int)(roleBookMark.KindDataCount[type] - 1); i >= 0; i--)
			{
				if (roleBookMark.AllData[(int)roleBookMark.KindDataIDIndex[type][i]].MapID == mapID)
				{
					int num = (int)roleBookMark.KindDataCount[type] - i - 3;
					if (num < 0)
					{
						num = 0;
					}
					if ((int)(roleBookMark.KindDataCount[type] - 6) < num)
					{
						num = (int)(roleBookMark.KindDataCount[type] - 6);
					}
					return num;
				}
			}
		}
		else if (bookType == UIBookMark.ClickType.AllianceTag)
		{
			for (int j = (int)(roleBookMark.AllianceBookCount - 1); j >= 0; j--)
			{
				if (roleBookMark.AllAllianceData[(int)roleBookMark.AllianceIDIndex[j]].MapID == mapID)
				{
					int num2 = (int)roleBookMark.AllianceBookCount - j - 3;
					if (num2 < 0)
					{
						num2 = 0;
					}
					if ((int)(roleBookMark.AllianceBookCount - 6) < num2)
					{
						num2 = (int)(roleBookMark.AllianceBookCount - 6);
					}
					return num2;
				}
			}
		}
		return 0;
	}

	// Token: 0x06002C29 RID: 11305 RVA: 0x00487C9C File Offset: 0x00485E9C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		DataManager instance = DataManager.Instance;
		if (this.BookItem[panelObjectIdx].BookIcon == null)
		{
			Transform child = this.ThisTransfrom.GetChild(5).GetChild(0).GetChild(0).GetChild(panelObjectIdx);
			this.BookItem[panelObjectIdx].BookIcon = child.GetChild(0).GetComponent<Image>();
			this.BookItem[panelObjectIdx].Edit = child.GetChild(2).GetChild(0).GetComponent<UIButton>();
			this.BookItem[panelObjectIdx].Name = child.GetChild(4).GetComponent<UIText>();
			this.BookItem[panelObjectIdx].Name.SetCheckArabic(true);
			this.BookItem[panelObjectIdx].Content = child.GetChild(5).GetComponent<UIText>();
			this.AddRefreshText(this.BookItem[panelObjectIdx].Name);
			this.AddRefreshText(this.BookItem[panelObjectIdx].Content);
			this.BookItem[panelObjectIdx].Trash = child.GetChild(2).GetChild(2).GetComponent<UIButton>();
			this.BookItem[panelObjectIdx].Move = child.GetChild(2).GetChild(1).GetComponent<UIButton>();
			this.BookItem[panelObjectIdx].Type1 = child.GetChild(2);
			this.BookItem[panelObjectIdx].Type2 = child.GetChild(3);
			this.BookItem[panelObjectIdx].SelImage = this.BookItem[panelObjectIdx].Type2.GetChild(0).GetChild(0).GetComponent<Image>();
			this.AddRefreshText(child.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>());
			this.BookItem[panelObjectIdx].Edit.m_BtnID1 = 4;
			this.BookItem[panelObjectIdx].Edit.m_Handler = this;
			this.BookItem[panelObjectIdx].Move.m_BtnID1 = 6;
			this.BookItem[panelObjectIdx].Move.m_Handler = this;
			this.BookItem[panelObjectIdx].Trash.m_BtnID1 = 5;
			this.BookItem[panelObjectIdx].Trash.m_Handler = this;
			this.BookItem[panelObjectIdx].Init();
		}
		if (instance.RoleBookMark.AllData == null)
		{
			return;
		}
		int num = (int)(this.DataCount - 1) - dataIdx;
		if (num < 0)
		{
			return;
		}
		BookMarkData bookMarkData;
		if (this.CurrentAllianceTag == UIBookMark.ClickType.RoleTag)
		{
			bookMarkData = instance.RoleBookMark.AllData[(int)this.KindData[num]];
		}
		else
		{
			bookMarkData = instance.RoleBookMark.AllAllianceData[(int)this.KindData[num]];
		}
		this.BookItem[panelObjectIdx].dataIndex = num;
		this.BookItem[panelObjectIdx].BookIcon.sprite = this.BookSpriteArr.GetSprite((int)bookMarkData.Type);
		this.BookItem[panelObjectIdx].Edit.m_BtnID2 = (int)bookMarkData.ID;
		this.BookItem[panelObjectIdx].Trash.m_BtnID2 = (int)bookMarkData.ID;
		this.BookItem[panelObjectIdx].Move.m_BtnID2 = (int)bookMarkData.ID;
		this.BookItem[panelObjectIdx].SetName(bookMarkData.Name);
		this.BookItem[panelObjectIdx].SetContent(bookMarkData.KingdomID, instance.RoleBookMark.GetMapID(bookMarkData.ID, (BookMark.eBookType)(this.CurrentAllianceTag - 9)));
		this.BookItem[panelObjectIdx].SetType(this.Type);
		if (this.Type == UIBookMark.BookMarkType.Type2)
		{
			this.BookItem[panelObjectIdx].SetSelect(this.BookMarkSel[num] > 0);
		}
		if (this.CurrentAllianceTag == UIBookMark.ClickType.RoleTag || instance.RoleAlliance.Rank >= AllianceRank.RANK4)
		{
			this.BookItem[panelObjectIdx].EditMode(true);
		}
		else
		{
			this.BookItem[panelObjectIdx].EditMode(false);
		}
	}

	// Token: 0x06002C2A RID: 11306 RVA: 0x004880EC File Offset: 0x004862EC
	public void Update()
	{
		this.DeltaTime += Time.deltaTime;
		if (this.DeltaTime >= 2f)
		{
			this.DeltaTime = 0f;
		}
		float alpha = (this.DeltaTime <= 1f) ? this.DeltaTime : (2f - this.DeltaTime);
		this.BookTag[(int)this.CurrentTag].alpha = alpha;
		this.AllianceTag[this.CurrentAllianceTag - UIBookMark.ClickType.RoleTag].alpha = alpha;
	}

	// Token: 0x06002C2B RID: 11307 RVA: 0x00488178 File Offset: 0x00486378
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		if (this.Type == UIBookMark.BookMarkType.Type1)
		{
			return;
		}
		if (this.SelectCount == this.SelectCountMax)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(6088u), 255, true);
			return;
		}
		for (int i = 0; i < this.BookItem.Length; i++)
		{
			if (this.BookItem[i].dataIndex == dataIndex)
			{
				if (!this.BookItem[i].bSelect)
				{
					this.SelectCount += 1;
					this.BookMarkSel[dataIndex] = (byte)this.BookItem[i].Edit.m_BtnID2;
				}
				else
				{
					this.BookMarkSel[dataIndex] = 0;
					this.SelectCount -= 1;
				}
				this.BookItem[i].SetSelect(this.BookMarkSel[dataIndex] > 0);
				break;
			}
		}
	}

	// Token: 0x06002C2C RID: 11308 RVA: 0x00488284 File Offset: 0x00486484
	private void AddRefreshText(UIText text)
	{
		this.RefreshTextList.Add(text);
	}

	// Token: 0x04007895 RID: 30869
	private List<UIText> RefreshTextList = new List<UIText>();

	// Token: 0x04007896 RID: 30870
	private byte[] TypeId = new byte[]
	{
		3,
		0,
		2,
		1
	};

	// Token: 0x04007897 RID: 30871
	private ScrollPanel BookScrollView;

	// Token: 0x04007898 RID: 30872
	protected List<float> ItemsHeight = new List<float>(16);

	// Token: 0x04007899 RID: 30873
	private byte[] KindData;

	// Token: 0x0400789A RID: 30874
	private byte DataCount;

	// Token: 0x0400789B RID: 30875
	private Color TabTextColor;

	// Token: 0x0400789C RID: 30876
	private UISpritesArray BookSpriteArr;

	// Token: 0x0400789D RID: 30877
	private Transform ThisTransfrom;

	// Token: 0x0400789E RID: 30878
	private Transform Type1;

	// Token: 0x0400789F RID: 30879
	private Transform Type2;

	// Token: 0x040078A0 RID: 30880
	private RectTransform MessageTrans;

	// Token: 0x040078A1 RID: 30881
	private RectTransform BookScrollRect;

	// Token: 0x040078A2 RID: 30882
	private UIBookMark.ClickType CurrentTag;

	// Token: 0x040078A3 RID: 30883
	private UIBookMark.ClickType CurrentAllianceTag;

	// Token: 0x040078A4 RID: 30884
	private UIText MainTitle;

	// Token: 0x040078A5 RID: 30885
	private UIText PageInfo;

	// Token: 0x040078A6 RID: 30886
	private UIText MessageText;

	// Token: 0x040078A7 RID: 30887
	private CString PageInfoStr;

	// Token: 0x040078A8 RID: 30888
	private CanvasGroup[] BookTag = new CanvasGroup[4];

	// Token: 0x040078A9 RID: 30889
	private CanvasGroup[] AllianceTag = new CanvasGroup[2];

	// Token: 0x040078AA RID: 30890
	private UIText[] BookTagText = new UIText[4];

	// Token: 0x040078AB RID: 30891
	private GameObject BookTagObj;

	// Token: 0x040078AC RID: 30892
	private byte SelectCount;

	// Token: 0x040078AD RID: 30893
	private byte SelectCountMax = 10;

	// Token: 0x040078AE RID: 30894
	private byte[] BookMarkSel;

	// Token: 0x040078AF RID: 30895
	private float DeltaTime;

	// Token: 0x040078B0 RID: 30896
	private AllianceRank AllianceRank = AllianceRank.RANK5;

	// Token: 0x040078B1 RID: 30897
	protected UIBookMark.ItemEdit[] BookItem;

	// Token: 0x040078B2 RID: 30898
	private UIBookMark.BookMarkType Type = UIBookMark.BookMarkType.Type1;

	// Token: 0x02000858 RID: 2136
	protected struct ItemEdit
	{
		// Token: 0x06002C2D RID: 11309 RVA: 0x00488294 File Offset: 0x00486494
		public void Init()
		{
			this.NameStr = StringManager.Instance.SpawnString(50);
			this.ContentStr = StringManager.Instance.SpawnString(100);
			this.CurType = UIBookMark.BookMarkType.Type2;
			this.bSelect = false;
		}

		// Token: 0x06002C2E RID: 11310 RVA: 0x004882D4 File Offset: 0x004864D4
		public void SetType(UIBookMark.BookMarkType type)
		{
			if (this.CurType == type)
			{
				return;
			}
			this.CurType = type;
			if (this.CurType == UIBookMark.BookMarkType.Type1)
			{
				this.Type2.gameObject.SetActive(false);
				this.Type1.gameObject.SetActive(true);
			}
			else
			{
				this.Type2.gameObject.SetActive(true);
				this.Type1.gameObject.SetActive(false);
			}
		}

		// Token: 0x06002C2F RID: 11311 RVA: 0x0048834C File Offset: 0x0048654C
		public void Destroy()
		{
			StringManager.Instance.DeSpawnString(this.NameStr);
			StringManager.Instance.DeSpawnString(this.ContentStr);
		}

		// Token: 0x06002C30 RID: 11312 RVA: 0x0048837C File Offset: 0x0048657C
		public void SetName(CString bookmarkName)
		{
			this.NameStr.ClearString();
			this.NameStr.Append(bookmarkName);
			this.Name.text = this.NameStr.ToString();
			this.Name.SetAllDirty();
			this.Name.cachedTextGenerator.Invalidate();
		}

		// Token: 0x06002C31 RID: 11313 RVA: 0x004883D4 File Offset: 0x004865D4
		public void SetContent(ushort KingdomID, int MapID)
		{
			StringTable mStringTable = DataManager.Instance.mStringTable;
			this.ContentStr.ClearString();
			this.ContentStr.StringToFormat(mStringTable.GetStringByID(4588u));
			this.ContentStr.StringToFormat(mStringTable.GetStringByID(4504u));
			this.ContentStr.IntToFormat((long)KingdomID, 1, false);
			uint num = DataManager.MapDataController.CheckWonderMapID((uint)MapID, KingdomID);
			Vector2 vector = (num != 40u) ? DataManager.MapDataController.GetYolkPos((ushort)num, KingdomID) : GameConstants.getTileMapPosbyMapID(MapID);
			this.ContentStr.StringToFormat(mStringTable.GetStringByID(4505u));
			this.ContentStr.IntToFormat((long)vector.x, 1, false);
			this.ContentStr.StringToFormat(mStringTable.GetStringByID(4506u));
			this.ContentStr.IntToFormat((long)vector.y, 1, false);
			if (GUIManager.Instance.IsArabic)
			{
				this.ContentStr.AppendFormat("{0} : {2}{1} {4}{3} {6}{5}");
			}
			else
			{
				this.ContentStr.AppendFormat("{0} : {1}{2} {3}{4} {5}{6}");
			}
			this.Content.text = this.ContentStr.ToString();
			this.Content.SetAllDirty();
			this.Content.cachedTextGenerator.Invalidate();
		}

		// Token: 0x06002C32 RID: 11314 RVA: 0x00488524 File Offset: 0x00486724
		public void SetSelect(bool bSelect)
		{
			if (this.bSelect == bSelect)
			{
				return;
			}
			this.bSelect = bSelect;
			this.SelImage.enabled = bSelect;
		}

		// Token: 0x06002C33 RID: 11315 RVA: 0x00488554 File Offset: 0x00486754
		public void EditMode(bool bEdit = true)
		{
			if (this.Edit == null)
			{
				return;
			}
			this.Edit.gameObject.SetActive(bEdit);
			this.Trash.gameObject.SetActive(bEdit);
		}

		// Token: 0x040078B3 RID: 30899
		public int dataIndex;

		// Token: 0x040078B4 RID: 30900
		public Image BookIcon;

		// Token: 0x040078B5 RID: 30901
		public Image SelImage;

		// Token: 0x040078B6 RID: 30902
		public UIButton Edit;

		// Token: 0x040078B7 RID: 30903
		public UIText Name;

		// Token: 0x040078B8 RID: 30904
		public UIText Content;

		// Token: 0x040078B9 RID: 30905
		public UIButton Trash;

		// Token: 0x040078BA RID: 30906
		public UIButton Move;

		// Token: 0x040078BB RID: 30907
		public Transform Type1;

		// Token: 0x040078BC RID: 30908
		public Transform Type2;

		// Token: 0x040078BD RID: 30909
		public bool bSelect;

		// Token: 0x040078BE RID: 30910
		private UIBookMark.BookMarkType CurType;

		// Token: 0x040078BF RID: 30911
		public CString NameStr;

		// Token: 0x040078C0 RID: 30912
		public CString ContentStr;
	}

	// Token: 0x02000859 RID: 2137
	public enum ClickType
	{
		// Token: 0x040078C2 RID: 30914
		TabAll,
		// Token: 0x040078C3 RID: 30915
		TabFavor,
		// Token: 0x040078C4 RID: 30916
		TabEnemy,
		// Token: 0x040078C5 RID: 30917
		TabFriend,
		// Token: 0x040078C6 RID: 30918
		ItemEdit,
		// Token: 0x040078C7 RID: 30919
		ItemDel,
		// Token: 0x040078C8 RID: 30920
		ItemMove,
		// Token: 0x040078C9 RID: 30921
		Close,
		// Token: 0x040078CA RID: 30922
		Import,
		// Token: 0x040078CB RID: 30923
		RoleTag,
		// Token: 0x040078CC RID: 30924
		AllianceTag
	}

	// Token: 0x0200085A RID: 2138
	private enum UIControl
	{
		// Token: 0x040078CE RID: 30926
		BackImage,
		// Token: 0x040078CF RID: 30927
		BookTag,
		// Token: 0x040078D0 RID: 30928
		AllianceTag,
		// Token: 0x040078D1 RID: 30929
		Type1,
		// Token: 0x040078D2 RID: 30930
		Type2,
		// Token: 0x040078D3 RID: 30931
		ScrollCont,
		// Token: 0x040078D4 RID: 30932
		Message,
		// Token: 0x040078D5 RID: 30933
		Close,
		// Token: 0x040078D6 RID: 30934
		Item
	}

	// Token: 0x0200085B RID: 2139
	private enum ItemControl
	{
		// Token: 0x040078D8 RID: 30936
		Icon,
		// Token: 0x040078D9 RID: 30937
		Frame,
		// Token: 0x040078DA RID: 30938
		Type1,
		// Token: 0x040078DB RID: 30939
		Type2,
		// Token: 0x040078DC RID: 30940
		Name,
		// Token: 0x040078DD RID: 30941
		Content
	}

	// Token: 0x0200085C RID: 2140
	public enum BookMarkType
	{
		// Token: 0x040078DF RID: 30943
		Type1 = 5,
		// Token: 0x040078E0 RID: 30944
		Type2
	}

	// Token: 0x0200085D RID: 2141
	private enum SaveHeader
	{
		// Token: 0x040078E2 RID: 30946
		Tag,
		// Token: 0x040078E3 RID: 30947
		ScrollIndex,
		// Token: 0x040078E4 RID: 30948
		ScrollPos = 3,
		// Token: 0x040078E5 RID: 30949
		AllianceTag = 7
	}
}
