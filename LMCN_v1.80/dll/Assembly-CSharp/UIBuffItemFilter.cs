using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000836 RID: 2102
public class UIBuffItemFilter : UIFilterBase
{
	// Token: 0x06002B7F RID: 11135 RVA: 0x0047E728 File Offset: 0x0047C928
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager instance = DataManager.Instance;
		this.TitleStr = StringManager.Instance.SpawnString(200);
		base.OnOpen(arg1, arg2);
		this.ThisTransform = base.SetFunc(this.transform.GetChild(4));
		this.ThisTransform.gameObject.SetActive(true);
		this.MainText.text = instance.mStringTable.GetStringByID(6093u);
		this.Title = this.ThisTransform.GetChild(1).GetComponent<UIText>();
		this.Title.font = GUIManager.Instance.GetTTFFont();
		this.Title.gameObject.SetActive(true);
		if (GUIManager.Instance.IsArabic)
		{
			this.Title.rectTransform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
		}
		base.AddRefreshText(this.Title);
		ItemBuff recordByIndex = instance.ItemBuffTable.GetRecordByIndex(arg2);
		Equip recordByKey = instance.EquipTable.GetRecordByKey(recordByIndex.BuffItemID);
		this.ItemKind = (ushort)recordByKey.EquipKind;
		this.PropKey = recordByKey.PropertiesInfo[0].Propertieskey;
		this.Title.text = instance.mStringTable.GetStringByID((uint)recordByIndex.BuffTipID);
	}

	// Token: 0x06002B80 RID: 11136 RVA: 0x0047E880 File Offset: 0x0047CA80
	public override void Init()
	{
		base.Init();
		this.ChangeItemType(false);
	}

	// Token: 0x06002B81 RID: 11137 RVA: 0x0047E890 File Offset: 0x0047CA90
	public override void OnClose()
	{
		base.OnClose();
		StringManager.Instance.DeSpawnString(this.TitleStr);
	}

	// Token: 0x06002B82 RID: 11138 RVA: 0x0047E8AC File Offset: 0x0047CAAC
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
		this.BagCount = -1;
		this.FilterScrollRect.StopMovement();
		if (!bMoveTop)
		{
			vector = this.ScrollContent.anchoredPosition;
			itemidx = this.FilterScrollView.GetBeginIdx();
		}
		this.SetItemData(instance.sortItemData, instance.sortItemDataStart[(int)(this.ItemKind - 1)], instance.sortItemDataCount[(int)(this.ItemKind - 1)], true, 0, 0);
		this.BagCount = this.ItemsHeight.Count;
		this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[(int)this.ItemKind], instance.SortSotreDataCount[(int)this.ItemKind], false, 0, 0);
		base.UpdateScrollItemsCount();
		if (!bMoveTop)
		{
			this.FilterScrollView.GoTo(itemidx, vector.y);
		}
	}

	// Token: 0x06002B83 RID: 11139 RVA: 0x0047E99C File Offset: 0x0047CB9C
	public override bool CheckItemRule(ushort id)
	{
		Equip recordByKey;
		if (this.BagCount == -1)
		{
			recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(id);
		}
		else
		{
			StoreTbl recordByKey2 = DataManager.Instance.StoreData.GetRecordByKey(id);
			if (recordByKey2.AddDiamondBuy == 0 || recordByKey2.Filter == 2)
			{
				return false;
			}
			if (DataManager.Instance.GetCurItemQuantity(recordByKey2.ItemID, 0) > 0)
			{
				return false;
			}
			recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
		}
		return recordByKey.PropertiesInfo[0].Propertieskey == this.PropKey;
	}

	// Token: 0x06002B84 RID: 11140 RVA: 0x0047EA48 File Offset: 0x0047CC48
	public override void SendPack(UIButton sender)
	{
		this.Sender = sender;
		if (this.Sender.m_BtnID1 == 1004)
		{
			DataManager instance = DataManager.Instance;
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

	// Token: 0x06002B85 RID: 11141 RVA: 0x0047EB18 File Offset: 0x0047CD18
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

	// Token: 0x06002B86 RID: 11142 RVA: 0x0047EBB0 File Offset: 0x0047CDB0
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

	// Token: 0x06002B87 RID: 11143 RVA: 0x0047EC10 File Offset: 0x0047CE10
	public override void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		base.UpDateRowItem(item, dataIdx, panelObjectIdx, panelId);
		if (this.ItemsData.Count <= dataIdx)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		this.FilterItem[panelObjectIdx].KeyID = this.ItemsData[dataIdx];
		ushort num = 1;
		ushort inKey;
		if (this.BagCount > dataIdx)
		{
			inKey = this.FilterItem[panelObjectIdx].KeyID;
			base.SetItemType(panelObjectIdx, UIFilterBase.eItemType.Use);
		}
		else
		{
			StoreTbl recordByKey = instance.StoreData.GetRecordByKey(this.FilterItem[panelObjectIdx].KeyID);
			inKey = recordByKey.ItemID;
			num = recordByKey.Num;
			base.SetItemType(panelObjectIdx, UIFilterBase.eItemType.BuyAndUse);
			this.FilterItem[panelObjectIdx].BuyPriceStr.ClearString();
			this.FilterItem[panelObjectIdx].BuyPriceStr.IntToFormat((long)((ulong)recordByKey.Price), 1, true);
			this.FilterItem[panelObjectIdx].BuyPriceStr.AppendFormat("{0}");
			this.FilterItem[panelObjectIdx].BuyPrice.text = this.FilterItem[panelObjectIdx].BuyPriceStr.ToString();
			this.FilterItem[panelObjectIdx].BuyPrice.SetAllDirty();
			this.FilterItem[panelObjectIdx].BuyPrice.cachedTextGenerator.Invalidate();
			this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID3 = (int)recordByKey.ID;
		}
		Equip recordByKey2 = instance.EquipTable.GetRecordByKey(inKey);
		ushort curItemQuantity = instance.GetCurItemQuantity(recordByKey2.EquipKey, 0);
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
		this.FilterItem[panelObjectIdx].OwnerStr.ClearString();
		this.FilterItem[panelObjectIdx].OwnerStr.StringToFormat(this.OwnerStr);
		this.FilterItem[panelObjectIdx].OwnerStr.IntToFormat((long)curItemQuantity, 1, true);
		this.FilterItem[panelObjectIdx].OwnerStr.AppendFormat("{0}{1}");
		this.FilterItem[panelObjectIdx].Owner.text = this.FilterItem[panelObjectIdx].OwnerStr.ToString();
		this.FilterItem[panelObjectIdx].Owner.SetAllDirty();
		this.FilterItem[panelObjectIdx].Owner.cachedTextGenerator.Invalidate();
		this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID2 = (int)recordByKey2.EquipKey;
	}

	// Token: 0x0400782D RID: 30765
	private ushort ItemKind;

	// Token: 0x0400782E RID: 30766
	private ushort PropKey;

	// Token: 0x0400782F RID: 30767
	private int BagCount;

	// Token: 0x04007830 RID: 30768
	private UIText Title;

	// Token: 0x04007831 RID: 30769
	private CString TitleStr;

	// Token: 0x04007832 RID: 30770
	private UIButton Sender;
}
