using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000837 RID: 2103
public class UIKingBufferFilter : UIFilterBase
{
	// Token: 0x06002B89 RID: 11145 RVA: 0x0047F00C File Offset: 0x0047D20C
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager instance = DataManager.Instance;
		this.TitleStr = StringManager.Instance.SpawnString(200);
		Image component = this.transform.GetChild(1).GetChild(5).GetComponent<Image>();
		base.OnOpen(arg1, arg2);
		this.ThisTransform = base.SetFunc(this.transform.GetChild(4));
		this.ThisTransform.gameObject.SetActive(true);
		this.MainText.text = instance.mStringTable.GetStringByID(1453u);
		component.sprite = this.FilterSpriteArr.GetSprite(4);
		this.Title = this.ThisTransform.GetChild(1).GetComponent<UIText>();
		this.Title.font = GUIManager.Instance.GetTTFFont();
		this.Title.gameObject.SetActive(true);
		base.AddRefreshText(this.Title);
		RectTransform component2 = this.ThisTransform.GetChild(4).GetComponent<RectTransform>();
		component2.SetParent(component.transform);
		component2.anchoredPosition = Vector2.zero;
		component2.GetChild(1).GetComponent<UIText>().font = this.Title.font;
		ItemBuff recordByIndex = instance.ItemBuffTable.GetRecordByIndex(arg2);
		Equip recordByKey = instance.EquipTable.GetRecordByKey(recordByIndex.BuffItemID);
		this.ItemKind = (ushort)recordByKey.EquipKind;
		this.PropKey = recordByKey.PropertiesInfo[0].Propertieskey;
		this.Title.text = instance.mStringTable.GetStringByID(1454u);
		this.Title.alignment = TextAnchor.MiddleCenter;
		component2 = this.Title.gameObject.GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2(1f, 0f);
		component2.sizeDelta = new Vector2(738f, 26f);
		if (GUIManager.Instance.IsArabic)
		{
			this.Title.rectTransform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
		}
		this.IsKing = DataManager.MapDataController.IsKing();
	}

	// Token: 0x06002B8A RID: 11146 RVA: 0x0047F228 File Offset: 0x0047D428
	public override void Init()
	{
		base.Init();
		this.RemainTimeText = new UIText[this.FilterItem.Length];
		this.RemainTimeStr = new CString[this.FilterItem.Length];
		this.TimeObj = new GameObject[this.FilterItem.Length];
		string stringByID = DataManager.Instance.mStringTable.GetStringByID(1456u);
		for (int i = 0; i < this.FilterItem.Length; i++)
		{
			base.SetItemType(i, UIFilterBase.eItemType.BuyAndUse);
			this.TimeObj[i] = this.FilterItem[i].BkImage.transform.GetChild(this.FilterItem[i].BkImage.transform.childCount - 1).gameObject;
			this.RemainTimeText[i] = this.TimeObj[i].transform.GetChild(1).GetComponent<UIText>();
			this.RemainTimeStr[i] = StringManager.Instance.SpawnString(30);
			base.AddRefreshText(this.RemainTimeText[i]);
			if (!this.IsKing)
			{
				this.FilterItem[i].BuyCaption.text = stringByID;
				this.FilterItem[i].BuyCaption.color = Color.red;
			}
		}
		this.ChangeItemType(false);
	}

	// Token: 0x06002B8B RID: 11147 RVA: 0x0047F378 File Offset: 0x0047D578
	public override void OnClose()
	{
		base.OnClose();
		StringManager.Instance.DeSpawnString(this.TitleStr);
		for (int i = 0; i < this.RemainTimeStr.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.RemainTimeStr[i]);
		}
	}

	// Token: 0x06002B8C RID: 11148 RVA: 0x0047F3C8 File Offset: 0x0047D5C8
	private void ChangeItemType(bool bMoveTop = false)
	{
		if (this.ItemKind == 0)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		Vector2 vector = Vector2.zero;
		instance.SortResourceFilterData();
		int itemidx = 0;
		instance.SortCurItemDataForBag();
		instance.SortStoreData();
		this.FilterScrollRect.StopMovement();
		if (!bMoveTop)
		{
			vector = this.ScrollContent.anchoredPosition;
			itemidx = this.FilterScrollView.GetBeginIdx();
		}
		this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[(int)this.ItemKind], instance.SortSotreDataCount[(int)this.ItemKind], true, 0, 0);
		base.UpdateScrollItemsCount();
		if (!bMoveTop)
		{
			this.FilterScrollView.GoTo(itemidx, vector.y);
		}
	}

	// Token: 0x06002B8D RID: 11149 RVA: 0x0047F474 File Offset: 0x0047D674
	public override bool CheckItemRule(ushort id)
	{
		StoreTbl recordByKey = DataManager.Instance.StoreData.GetRecordByKey(id);
		return DataManager.Instance.EquipTable.GetRecordByKey(recordByKey.ItemID).PropertiesInfo[0].Propertieskey == this.PropKey;
	}

	// Token: 0x06002B8E RID: 11150 RVA: 0x0047F4CC File Offset: 0x0047D6CC
	public override void SendPack(UIButton sender)
	{
		DataManager instance = DataManager.Instance;
		if (!this.IsKing)
		{
			GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(1456u), 255, true);
			return;
		}
		if (!DataManager.MapDataController.CheckKingFunction(eKingFunction.eStrengthen))
		{
			return;
		}
		this.Sender = sender;
		if (this.Sender.m_BtnID1 == 1004)
		{
			if (instance.KingCoolEndTime > instance.ServerTime)
			{
				GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(1457u), 255, true);
				return;
			}
			if (instance.StoreData.GetRecordByKey((ushort)this.Sender.m_BtnID3).Price > instance.RoleAttr.Diamond)
			{
				GUIManager.Instance.OpenMessageBox(instance.mStringTable.GetStringByID(3966u), instance.mStringTable.GetStringByID(646u), 4, instance.mStringTable.GetStringByID(4507u), 0, 0, true, false, false, false, false);
			}
			else
			{
				base.CheckMessage((ushort)this.Sender.m_BtnID2);
			}
		}
		else
		{
			base.CheckMessage((ushort)this.Sender.m_BtnID2);
		}
	}

	// Token: 0x06002B8F RID: 11151 RVA: 0x0047F60C File Offset: 0x0047D80C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			switch (this.Sender.m_BtnID1)
			{
			case 1002:
				DataManager.Instance.UseItem((ushort)this.Sender.m_BtnID2, 1, 0, 0, 0, 0u, string.Empty, true);
				break;
			case 1004:
				this.CheckBuy(1, (ushort)this.Sender.m_BtnID3, (ushort)this.Sender.m_BtnID2, true, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), 0, 0, 0u);
				break;
			}
		}
	}

	// Token: 0x06002B90 RID: 11152 RVA: 0x0047F6A4 File Offset: 0x0047D8A4
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews == NetworkNews.Refresh_Item)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door != null)
				{
					door.CloseMenu(false);
				}
			}
		}
		else
		{
			this.ChangeItemType(false);
		}
	}

	// Token: 0x06002B91 RID: 11153 RVA: 0x0047F704 File Offset: 0x0047D904
	public override void UpdateTime(bool bOnSecond)
	{
		if (!bOnSecond)
		{
			return;
		}
		if (this.FilterItem == null)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		uint num = 0u;
		if (instance.KingCoolEndTime > instance.ServerTime)
		{
			num = (uint)(instance.KingCoolEndTime - instance.ServerTime);
		}
		CString value = DataManager.MissionDataManager.FormatMissionTime(num);
		for (int i = 0; i < this.RemainTimeText.Length; i++)
		{
			if (this.FilterItem[i].BkImage.gameObject.activeSelf)
			{
				this.RemainTimeStr[i].ClearString();
				if (num > 0u)
				{
					if (!this.TimeObj[i].activeSelf)
					{
						this.TimeObj[i].SetActive(true);
					}
					this.RemainTimeStr[i].Append(value);
					this.RemainTimeText[i].text = this.RemainTimeStr[i].ToString();
					this.RemainTimeText[i].SetAllDirty();
					this.RemainTimeText[i].cachedTextGenerator.Invalidate();
				}
				else if (this.TimeObj[i].activeSelf)
				{
					this.TimeObj[i].SetActive(false);
				}
			}
		}
	}

	// Token: 0x06002B92 RID: 11154 RVA: 0x0047F838 File Offset: 0x0047DA38
	public override void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		base.UpDateRowItem(item, dataIdx, panelObjectIdx, panelId);
		if (this.ItemsData.Count <= dataIdx)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		this.FilterItem[panelObjectIdx].KeyID = this.ItemsData[dataIdx];
		StoreTbl recordByKey = instance.StoreData.GetRecordByKey(this.FilterItem[panelObjectIdx].KeyID);
		ushort itemID = recordByKey.ItemID;
		ushort num = recordByKey.Num;
		this.FilterItem[panelObjectIdx].BuyPriceStr.ClearString();
		this.FilterItem[panelObjectIdx].BuyPriceStr.IntToFormat((long)((ulong)recordByKey.Price), 1, true);
		this.FilterItem[panelObjectIdx].BuyPriceStr.AppendFormat("{0}");
		this.FilterItem[panelObjectIdx].BuyPrice.text = this.FilterItem[panelObjectIdx].BuyPriceStr.ToString();
		this.FilterItem[panelObjectIdx].BuyPrice.SetAllDirty();
		this.FilterItem[panelObjectIdx].BuyPrice.cachedTextGenerator.Invalidate();
		this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID3 = (int)recordByKey.ID;
		Equip recordByKey2 = instance.EquipTable.GetRecordByKey(itemID);
		this.FilterItem[panelObjectIdx].AutouseBtnTrans.gameObject.SetActive(false);
		GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[panelObjectIdx].ItemTrans, eHeroOrItem.Item, recordByKey2.EquipKey, 0, 0, 0);
		if (num == 1)
		{
			this.FilterItem[panelObjectIdx].Name.text = instance.mStringTable.GetStringByID((uint)recordByKey2.EquipName);
		}
		else
		{
			this.FilterItem[panelObjectIdx].NameStr.ClearString();
			this.FilterItem[panelObjectIdx].NameStr.StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey2.EquipName));
			this.FilterItem[panelObjectIdx].NameStr.IntToFormat((long)num, 1, false);
			this.FilterItem[panelObjectIdx].NameStr.AppendFormat("{0} x {1}");
			this.FilterItem[panelObjectIdx].Name.text = this.FilterItem[panelObjectIdx].NameStr.ToString();
			this.FilterItem[panelObjectIdx].Name.SetAllDirty();
			this.FilterItem[panelObjectIdx].Name.cachedTextGenerator.Invalidate();
		}
		this.FilterItem[panelObjectIdx].Content.text = instance.mStringTable.GetStringByID((uint)recordByKey2.EquipInfo);
		this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID2 = (int)recordByKey2.EquipKey;
	}

	// Token: 0x04007833 RID: 30771
	private ushort ItemKind;

	// Token: 0x04007834 RID: 30772
	private ushort PropKey;

	// Token: 0x04007835 RID: 30773
	private UIText Title;

	// Token: 0x04007836 RID: 30774
	private CString TitleStr;

	// Token: 0x04007837 RID: 30775
	private UIButton Sender;

	// Token: 0x04007838 RID: 30776
	private bool IsKing;

	// Token: 0x04007839 RID: 30777
	private UIText[] RemainTimeText;

	// Token: 0x0400783A RID: 30778
	private CString[] RemainTimeStr;

	// Token: 0x0400783B RID: 30779
	private GameObject[] TimeObj;
}
