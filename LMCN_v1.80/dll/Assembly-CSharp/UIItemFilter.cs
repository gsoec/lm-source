using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000833 RID: 2099
public class UIItemFilter : UIFilterBase
{
	// Token: 0x06002B75 RID: 11125 RVA: 0x0047DAAC File Offset: 0x0047BCAC
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager instance = DataManager.Instance;
		base.OnOpen(arg1, arg2);
		this.ThisTransform = base.SetFunc(this.transform.GetChild(4));
		this.ThisTransform.gameObject.SetActive(true);
		this.Title = this.ThisTransform.GetComponent<UIText>();
		this.Title.font = GUIManager.Instance.GetTTFFont();
		base.AddRefreshText(this.Title);
		this.ItemTrans = this.ThisTransform.GetChild(0).GetComponent<RectTransform>();
		if (arg1 == 0)
		{
			this.SubType = (UIItemFilter._SubType)arg2;
			this.Type = UIItemFilter.ItemFilterType.Experience;
			if (this.SubType == UIItemFilter._SubType.Pet || this.SubType == UIItemFilter._SubType.PetFormDetail)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
			}
			if (this.SubType == UIItemFilter._SubType.Hero)
			{
				this.Title.text = instance.mStringTable.GetStringByID(738u);
				this.MainText.text = instance.mStringTable.GetStringByID(737u);
				UIText component = this.MessageTrans.GetChild(0).GetComponent<UIText>();
				component.text = instance.mStringTable.GetStringByID(745u);
				Vector2 sizeDelta = this.MessageTrans.sizeDelta;
				sizeDelta.x = component.preferredWidth + 165f;
				this.MessageTrans.sizeDelta = sizeDelta;
			}
			else
			{
				this.Title.text = instance.mStringTable.GetStringByID(16043u);
				this.MainText.text = instance.mStringTable.GetStringByID(16042u);
				UIText component2 = this.MessageTrans.GetChild(0).GetComponent<UIText>();
				component2.text = instance.mStringTable.GetStringByID(744u);
				Vector2 sizeDelta2 = this.MessageTrans.sizeDelta;
				sizeDelta2.x = component2.preferredWidth + 165f;
				this.MessageTrans.sizeDelta = sizeDelta2;
			}
		}
		else
		{
			this.Type = UIItemFilter.ItemFilterType.ItemID;
			this.TitleStr = StringManager.Instance.SpawnString(30);
			this.MainText.text = instance.mStringTable.GetStringByID(785u);
			this.Title.text = instance.mStringTable.GetStringByID(785u);
			this.FilterItemID = (ushort)arg1;
			this.NeedCount = (ushort)arg2;
			if (PetManager.Instance.IsPetItem(this.FilterItemID))
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
			}
		}
	}

	// Token: 0x06002B76 RID: 11126 RVA: 0x0047DD1C File Offset: 0x0047BF1C
	public override void Init()
	{
		base.Init();
		this.ChangeItemType(false);
		if (this.Type != UIItemFilter.ItemFilterType.Experience)
		{
			GUIManager.Instance.InitianHeroItemImg(this.ItemTrans, eHeroOrItem.Item, this.FilterItemID, 0, 0, 0, false, false, true, false);
			this.ItemTrans.gameObject.SetActive(true);
			this.UpdateNeedItemCount();
		}
	}

	// Token: 0x06002B77 RID: 11127 RVA: 0x0047DD78 File Offset: 0x0047BF78
	public override void OnClose()
	{
		base.OnClose();
		if (this.TitleStr != null)
		{
			StringManager.Instance.DeSpawnString(this.TitleStr);
		}
	}

	// Token: 0x06002B78 RID: 11128 RVA: 0x0047DDA8 File Offset: 0x0047BFA8
	private void UpdateNeedItemCount()
	{
		if (this.Type == UIItemFilter.ItemFilterType.Experience)
		{
			return;
		}
		ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(this.FilterItemID, 0);
		this.TitleStr.ClearString();
		this.TitleStr.IntToFormat((long)curItemQuantity, 1, false);
		this.TitleStr.IntToFormat((long)this.NeedCount, 1, false);
		if (GUIManager.Instance.IsArabic)
		{
			if (this.NeedCount > curItemQuantity)
			{
				this.TitleStr.AppendFormat("{1} / <color=#ff004fff>{0}</color>");
			}
			else
			{
				this.TitleStr.AppendFormat("{1} / {0}");
			}
		}
		else if (this.NeedCount > curItemQuantity)
		{
			this.TitleStr.AppendFormat("<color=#ff004fff>{0}</color> / {1}");
		}
		else
		{
			this.TitleStr.AppendFormat("{0} / {1}");
		}
		this.Title.text = this.TitleStr.ToString();
		this.Title.SetAllDirty();
		this.Title.cachedTextGenerator.Invalidate();
		this.Title.cachedTextGeneratorForLayout.Invalidate();
		Vector2 anchoredPosition = this.ItemTrans.anchoredPosition;
		anchoredPosition.x = (26f + this.Title.preferredWidth * 0.5f) * -1f;
		this.ItemTrans.anchoredPosition = anchoredPosition;
	}

	// Token: 0x06002B79 RID: 11129 RVA: 0x0047DEF8 File Offset: 0x0047C0F8
	private void ChangeItemType(bool bMoveTop = false)
	{
		DataManager instance = DataManager.Instance;
		Vector2 vector = Vector2.zero;
		if (this.SubType == UIItemFilter._SubType.Pet || this.SubType == UIItemFilter._SubType.PetFormDetail)
		{
			PetManager.Instance.SortPetItemData();
		}
		else
		{
			instance.SortResourceFilterData();
		}
		int itemidx = 0;
		this.FilterScrollRect.StopMovement();
		if (!bMoveTop)
		{
			vector = this.ScrollContent.anchoredPosition;
			itemidx = this.FilterScrollView.GetBeginIdx();
		}
		UIItemFilter.ItemFilterType type = this.Type;
		if (type != UIItemFilter.ItemFilterType.Experience)
		{
			if (type == UIItemFilter.ItemFilterType.ItemID)
			{
				this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[7], instance.SortSotreDataCount[7], true, 0, 0);
			}
		}
		else if (this.SubType == UIItemFilter._SubType.Hero)
		{
			this.SetItemData(instance.sortItemData, instance.sortItemDataStart[15], instance.sortItemDataCount[15], true, 0, 0);
		}
		else
		{
			this.SetItemData(PetManager.Instance.PetItemData, instance.sortItemDataStart[5], instance.sortItemDataCount[5], true);
			this.ItemsHeight.Insert(0, 128f);
			this.ItemsData.Insert(0, 0);
		}
		base.UpdateScrollItemsCount();
		if (this.Type == UIItemFilter.ItemFilterType.Experience && this.SubType == UIItemFilter._SubType.PetFormDetail && this.ItemsData.Count == 1)
		{
			this.MessageTrans.gameObject.SetActive(true);
		}
		if (!bMoveTop)
		{
			this.FilterScrollView.GoTo(itemidx, vector.y);
		}
	}

	// Token: 0x06002B7A RID: 11130 RVA: 0x0047E074 File Offset: 0x0047C274
	public override bool CheckItemRule(ushort id)
	{
		if (this.Type == UIItemFilter.ItemFilterType.ItemID)
		{
			DataManager instance = DataManager.Instance;
			StoreTbl recordByKey = instance.StoreData.GetRecordByKey(id);
			return recordByKey.AddDiamondBuy != 0 && recordByKey.Filter != 2 && recordByKey.ItemID == this.FilterItemID;
		}
		if (this.Type == UIItemFilter.ItemFilterType.Experience && (this.SubType == UIItemFilter._SubType.Pet || this.SubType == UIItemFilter._SubType.PetFormDetail))
		{
			ushort num = 0;
			PetItem petItem = PetManager.Instance.FindItemData(id, ref num);
			return petItem != null && (petItem.EquipKind - 1 == 5 && (petItem.PropertiesInfo[0].Propertieskey == 5 || petItem.PropertiesInfo[0].Propertieskey == 6));
		}
		return true;
	}

	// Token: 0x06002B7B RID: 11131 RVA: 0x0047E150 File Offset: 0x0047C350
	public override void SendPack(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 1002:
			if (this.SubType == UIItemFilter._SubType.PetFormDetail)
			{
				DataManager.Instance.UseItem((ushort)sender.m_BtnID2, 1, 0, PetManager.Instance.PetUI_UseItemPetID, 0, 0u, string.Empty, true);
			}
			else
			{
				DataManager.Instance.UseItem((ushort)sender.m_BtnID2, 1, 0, 0, 0, 0u, string.Empty, true);
			}
			break;
		case 1004:
			if (DataManager.Instance.GetCurItemQuantity((ushort)sender.m_BtnID2, 0) >= 65535)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(887u), 255, true);
			}
			else
			{
				this.CheckBuy(1, (ushort)sender.m_BtnID3, (ushort)sender.m_BtnID2, false, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), 0, 0, 0u);
			}
			break;
		case 1005:
		{
			GUIManager.Instance.BuildingData.ManorGuild((ushort)sender.m_BtnID2, false);
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.CloseMenu(true);
			break;
		}
		}
	}

	// Token: 0x06002B7C RID: 11132 RVA: 0x0047E280 File Offset: 0x0047C480
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login && networkNews != NetworkNews.Refresh_Item)
		{
			if (networkNews == NetworkNews.Refresh_Pet)
			{
				if (this.SubType == UIItemFilter._SubType.Pet || this.SubType == UIItemFilter._SubType.PetFormDetail)
				{
					this.ChangeItemType(false);
				}
			}
		}
		else
		{
			this.UpdateNeedItemCount();
			this.ChangeItemType(false);
		}
	}

	// Token: 0x06002B7D RID: 11133 RVA: 0x0047E2EC File Offset: 0x0047C4EC
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
		if (this.Type == UIItemFilter.ItemFilterType.Experience)
		{
			inKey = this.FilterItem[panelObjectIdx].KeyID;
			if (this.SubType == UIItemFilter._SubType.PetFormDetail && dataIdx == 0)
			{
				base.SetItemType(panelObjectIdx, UIFilterBase.eItemType.PetTraining);
				return;
			}
			base.SetItemType(panelObjectIdx, UIFilterBase.eItemType.Use);
		}
		else
		{
			StoreTbl recordByKey = instance.StoreData.GetRecordByKey(this.FilterItem[panelObjectIdx].KeyID);
			inKey = recordByKey.ItemID;
			num = recordByKey.Num;
			base.SetItemType(panelObjectIdx, UIFilterBase.eItemType.BuyAndUse);
			this.FilterItem[panelObjectIdx].BuyCaption.text = instance.mStringTable.GetStringByID(284u);
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

	// Token: 0x0400781E RID: 30750
	private UIItemFilter._SubType SubType;

	// Token: 0x0400781F RID: 30751
	private UIItemFilter.ItemFilterType Type;

	// Token: 0x04007820 RID: 30752
	private ushort FilterItemID;

	// Token: 0x04007821 RID: 30753
	private ushort NeedCount;

	// Token: 0x04007822 RID: 30754
	private RectTransform ItemTrans;

	// Token: 0x04007823 RID: 30755
	private UIText Title;

	// Token: 0x04007824 RID: 30756
	private CString TitleStr;

	// Token: 0x02000834 RID: 2100
	private enum ItemFilterType
	{
		// Token: 0x04007826 RID: 30758
		Experience,
		// Token: 0x04007827 RID: 30759
		ItemID,
		// Token: 0x04007828 RID: 30760
		ItemKind
	}

	// Token: 0x02000835 RID: 2101
	public enum _SubType
	{
		// Token: 0x0400782A RID: 30762
		Hero,
		// Token: 0x0400782B RID: 30763
		Pet,
		// Token: 0x0400782C RID: 30764
		PetFormDetail
	}
}
