using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000839 RID: 2105
public class UIGemRemoveFilter : UIFilterBase
{
	// Token: 0x06002BA3 RID: 11171 RVA: 0x00481488 File Offset: 0x0047F688
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager instance = DataManager.Instance;
		base.OnOpen(arg1, arg2);
		this.ThisTransform = base.SetFunc(this.transform.GetChild(4));
		this.ThisTransform.gameObject.SetActive(true);
		this.Title = this.ThisTransform.GetComponent<UIText>();
		this.Title.font = GUIManager.Instance.GetTTFFont();
		this.itemPos = (byte)arg1;
		this.gemPos = (byte)arg2;
		this.TitleStr = StringManager.Instance.SpawnString(30);
		if (DataManager.Instance.EquipTable.GetRecordByKey(DataManager.Instance.mLordEquip.LordEquip[(int)this.itemPos].Gem[(int)this.gemPos]).NewGem <= 0)
		{
			this.GenRemoveData.Title = 7516u;
			this.GenRemoveData.MainText = 7517u;
			this.GenRemoveData.Itemkind = 10;
			this.GenRemoveData.Effect = 29;
			this.GenRemoveData.FreeRemove = 1161;
			this.GenRemoveData.ConfirmTitle = 7481u;
			this.GenRemoveData.ConfirmMainText = 7482u;
		}
		else
		{
			this.GenRemoveData.Title = 16135u;
			this.GenRemoveData.MainText = 16136u;
			this.GenRemoveData.Itemkind = 10;
			this.GenRemoveData.Effect = 50;
			this.GenRemoveData.FreeRemove = 1352;
			this.GenRemoveData.ConfirmTitle = 16138u;
			this.GenRemoveData.ConfirmMainText = 16139u;
		}
		this.ItemKind = this.GenRemoveData.Itemkind;
		this.EffectVal = this.GenRemoveData.Effect;
		this.MainText.text = instance.mStringTable.GetStringByID(this.GenRemoveData.Title);
		this.Title.text = instance.mStringTable.GetStringByID(this.GenRemoveData.MainText);
		base.AddRefreshText(this.Title);
	}

	// Token: 0x06002BA4 RID: 11172 RVA: 0x004816B0 File Offset: 0x0047F8B0
	public override void Init()
	{
		base.Init();
		this.ChangeItemType(false);
	}

	// Token: 0x06002BA5 RID: 11173 RVA: 0x004816C0 File Offset: 0x0047F8C0
	public override void OnClose()
	{
		base.OnClose();
		StringManager.Instance.DeSpawnString(this.TitleStr);
	}

	// Token: 0x06002BA6 RID: 11174 RVA: 0x004816DC File Offset: 0x0047F8DC
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			DataManager.Instance.mLordEquip.RemoveGameFree(DataManager.Instance.mLordEquip.LordEquip[(int)this.itemPos].SerialNO, this.gemPos);
		}
	}

	// Token: 0x06002BA7 RID: 11175 RVA: 0x00481724 File Offset: 0x0047F924
	private void ChangeItemType(bool bMoveTop = false)
	{
		DataManager instance = DataManager.Instance;
		Vector2 vector = Vector2.zero;
		instance.SortCurItemDataForBag();
		instance.SortStoreData();
		int itemidx = 0;
		this.FilterScrollRect.StopMovement();
		if (!bMoveTop)
		{
			vector = this.ScrollContent.anchoredPosition;
			itemidx = this.FilterScrollView.GetBeginIdx();
		}
		this.BagCount = -1;
		this.ItemsHeight.Clear();
		this.ItemsData.Clear();
		this.ItemsData.Add(this.GenRemoveData.FreeRemove);
		this.ItemsHeight.Add(121f);
		this.SetItemData(instance.sortItemData, instance.sortItemDataStart[(int)(this.ItemKind - 1)], instance.sortItemDataCount[(int)(this.ItemKind - 1)], false, 0, 0);
		this.BagCount = this.ItemsHeight.Count;
		this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[(int)this.ItemKind], instance.SortSotreDataCount[(int)this.ItemKind], false, 0, 0);
		base.UpdateScrollItemsCount();
		if (!bMoveTop)
		{
			this.FilterScrollView.GoTo(itemidx, vector.y);
		}
	}

	// Token: 0x06002BA8 RID: 11176 RVA: 0x00481840 File Offset: 0x0047FA40
	public override bool CheckItemRule(ushort id)
	{
		DataManager instance = DataManager.Instance;
		Equip recordByKey;
		if (this.BagCount == -1)
		{
			recordByKey = instance.EquipTable.GetRecordByKey(id);
		}
		else
		{
			StoreTbl recordByKey2 = instance.StoreData.GetRecordByKey(id);
			if (recordByKey2.AddDiamondBuy == 0 || recordByKey2.Filter == 2 || instance.GetCurItemQuantity(recordByKey2.ItemID, 0) > 0)
			{
				return false;
			}
			recordByKey = instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
		}
		return recordByKey.PropertiesInfo[0].Propertieskey == (ushort)this.EffectVal;
	}

	// Token: 0x06002BA9 RID: 11177 RVA: 0x004818E0 File Offset: 0x0047FAE0
	public override void SendPack(UIButton sender)
	{
		if (sender.m_BtnID2 == (int)this.GenRemoveData.FreeRemove)
		{
			GUIManager.Instance.OpenOKCancelBox(GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), DataManager.Instance.mStringTable.GetStringByID(this.GenRemoveData.ConfirmTitle), DataManager.Instance.mStringTable.GetStringByID(this.GenRemoveData.ConfirmMainText), 0, 0, null, null);
			return;
		}
		switch (sender.m_BtnID1)
		{
		case 1002:
			if (DataManager.Instance.EquipTable.GetRecordByKey((ushort)sender.m_BtnID2).Color < LordEquipData.Instance().LordEquip[(int)this.itemPos].GemColor[(int)this.gemPos])
			{
				return;
			}
			DataManager.Instance.UseItem((ushort)sender.m_BtnID2, 1, (ushort)this.gemPos, 0, 0, DataManager.Instance.mLordEquip.LordEquip[(int)this.itemPos].SerialNO, string.Empty, true);
			break;
		case 1004:
			if (DataManager.Instance.EquipTable.GetRecordByKey((ushort)sender.m_BtnID2).Color < LordEquipData.Instance().LordEquip[(int)this.itemPos].GemColor[(int)this.gemPos])
			{
				return;
			}
			this.CheckBuy(1, (ushort)sender.m_BtnID3, (ushort)sender.m_BtnID2, true, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), (int)this.gemPos, 0, DataManager.Instance.mLordEquip.LordEquip[(int)this.itemPos].SerialNO);
			break;
		}
	}

	// Token: 0x06002BAA RID: 11178 RVA: 0x00481A94 File Offset: 0x0047FC94
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews == NetworkNews.Refresh_Item)
			{
				Door door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
				door.CloseMenu(false);
			}
		}
		else
		{
			this.ChangeItemType(false);
		}
	}

	// Token: 0x06002BAB RID: 11179 RVA: 0x00481AE8 File Offset: 0x0047FCE8
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
		if (this.FilterItem[panelObjectIdx].KeyID == this.GenRemoveData.FreeRemove)
		{
			inKey = this.FilterItem[panelObjectIdx].KeyID;
			base.SetItemType(panelObjectIdx, UIFilterBase.eItemType.Use);
		}
		else if (this.BagCount > dataIdx)
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
		if (this.FilterItem[panelObjectIdx].KeyID != this.GenRemoveData.FreeRemove)
		{
			this.FilterItem[panelObjectIdx].OwnerStr.StringToFormat(this.OwnerStr);
			this.FilterItem[panelObjectIdx].OwnerStr.IntToFormat((long)curItemQuantity, 1, true);
			this.FilterItem[panelObjectIdx].OwnerStr.AppendFormat("{0}{1}");
		}
		this.FilterItem[panelObjectIdx].Owner.text = this.FilterItem[panelObjectIdx].OwnerStr.ToString();
		this.FilterItem[panelObjectIdx].Owner.SetAllDirty();
		this.FilterItem[panelObjectIdx].Owner.cachedTextGenerator.Invalidate();
		this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID2 = (int)recordByKey2.EquipKey;
		if (LordEquipData.Instance().LordEquip[(int)this.itemPos].GemColor[(int)this.gemPos] > recordByKey2.Color && this.FilterItem[panelObjectIdx].KeyID != this.GenRemoveData.FreeRemove)
		{
			this.FilterItem[panelObjectIdx].BuyCaption.color = new Color32(byte.MaxValue, 85, 129, byte.MaxValue);
		}
		else
		{
			this.FilterItem[panelObjectIdx].BuyCaption.color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
		}
	}

	// Token: 0x0400784E RID: 30798
	private int BagCount;

	// Token: 0x0400784F RID: 30799
	private byte ItemKind;

	// Token: 0x04007850 RID: 30800
	private byte EffectVal;

	// Token: 0x04007851 RID: 30801
	private UIText Title;

	// Token: 0x04007852 RID: 30802
	private CString TitleStr;

	// Token: 0x04007853 RID: 30803
	private byte itemPos;

	// Token: 0x04007854 RID: 30804
	private byte gemPos;

	// Token: 0x04007855 RID: 30805
	private UIGemRemoveFilter._GenRemover GenRemoveData;

	// Token: 0x0200083A RID: 2106
	private struct _GenRemover
	{
		// Token: 0x04007856 RID: 30806
		public uint Title;

		// Token: 0x04007857 RID: 30807
		public uint MainText;

		// Token: 0x04007858 RID: 30808
		public uint ConfirmTitle;

		// Token: 0x04007859 RID: 30809
		public uint ConfirmMainText;

		// Token: 0x0400785A RID: 30810
		public byte Itemkind;

		// Token: 0x0400785B RID: 30811
		public byte Effect;

		// Token: 0x0400785C RID: 30812
		public ushort FreeRemove;
	}
}
