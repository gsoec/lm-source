using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200082F RID: 2095
public class UIResourceFilter : UIFilterBase
{
	// Token: 0x06002B66 RID: 11110 RVA: 0x0047C2B4 File Offset: 0x0047A4B4
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		this.CurFilterTag = UIResourceFilter.ClickType.None;
		base.OnOpen(arg1, arg2);
		this.ThisTransform = base.SetFunc(this.transform.GetChild(2));
		Font ttffont = instance2.GetTTFFont();
		this.CastleLv = instance2.BuildingData.GetBuildData(8, 0).Level;
		this.ThisTransform.gameObject.SetActive(true);
		this.CurFilterTag = UIResourceFilter.ClickType.Grain;
		if (arg1 >= 5)
		{
			this.ResourceStr = new CString[1];
			this.ResourceStr[0] = StringManager.Instance.SpawnString(100);
			this.Type = UIResourceFilter.ResourceFilterType.Single;
			this.RequireResource = arg2;
			this.ThisTransform.GetChild(0).gameObject.SetActive(false);
			this.ResourceNum = this.ThisTransform.GetChild(1).GetComponent<UIText>();
			this.ResourceNum.font = ttffont;
			base.AddRefreshText(this.ResourceNum);
			this.SingleResourceImg = this.ThisTransform.GetChild(1).GetChild(0).GetComponent<Image>();
			Door door = instance2.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				switch (arg1)
				{
				case 5:
					this.SingleResource = door.LoadSprite("UI_main_res_food");
					this.MainText.text = instance.mStringTable.GetStringByID(299u);
					break;
				case 6:
					this.SingleResource = door.LoadSprite("UI_main_res_stone");
					this.MainText.text = instance.mStringTable.GetStringByID(300u);
					break;
				case 7:
					this.SingleResource = door.LoadSprite("UI_main_res_wood");
					this.MainText.text = instance.mStringTable.GetStringByID(301u);
					break;
				case 8:
					this.SingleResource = door.LoadSprite("UI_main_res_iron");
					this.MainText.text = instance.mStringTable.GetStringByID(302u);
					break;
				case 9:
					this.SingleResource = door.LoadSprite("UI_main_money_01");
					this.MainText.text = instance.mStringTable.GetStringByID(303u);
					break;
				case 10:
					this.SingleResource = door.LoadSprite("UI_main_Force");
					this.MainText.text = instance.mStringTable.GetStringByID(14670u);
					instance2.UpdateUI(EGUIWindow.Door, 1, 4);
					break;
				default:
					arg1 = 5;
					this.SingleResource = door.LoadSprite("UI_main_res_food");
					this.MainText.text = instance.mStringTable.GetStringByID(299u);
					break;
				}
				this.SingleResourceImg.sprite = this.SingleResource;
				this.SingleResourceImg.material = door.LoadMaterial();
			}
			this.CurFilterTag = (UIResourceFilter.ClickType)(arg1 - 5);
		}
		else
		{
			this.ThisTransform.GetChild(1).gameObject.SetActive(false);
			this.MainText.text = instance.mStringTable.GetStringByID(287u);
			this.Type = UIResourceFilter.ResourceFilterType.Mutile;
			int childCount = this.ThisTransform.GetChild(0).childCount;
			this.ResourceStr = new CString[childCount];
			for (int i = 0; i < childCount; i++)
			{
				this.ResourceStr[i] = StringManager.Instance.SpawnString(30);
				this.ResourceTag[i] = this.ThisTransform.GetChild(0).GetChild(i).GetChild(0).GetComponent<CanvasGroup>();
				UIButton component = this.ThisTransform.GetChild(0).GetChild(i).GetComponent<UIButton>();
				component.m_Handler = this;
				component.m_BtnID1 = 0 + i;
				this.ResourceText[i] = this.ThisTransform.GetChild(0).GetChild(i).GetChild(2).GetComponent<UIText>();
				this.ResourceText[i].font = ttffont;
				base.AddRefreshText(this.ResourceText[i]);
			}
			this.TabTextColor = this.ResourceText[0].color;
			if (arg2 == 0)
			{
				this.CurFilterTag = (UIResourceFilter.ClickType)arg1;
			}
			else
			{
				this.CurFilterTag = (UIResourceFilter.ClickType)instance2.ResourceFilterSaved[36];
			}
		}
		for (int j = 0; j < this.TageSave.Length; j++)
		{
			this.TageSave[j].BeginIndex = GameConstants.ConvertBytesToUShort(instance2.ResourceFilterSaved, j * 6);
			this.TageSave[j].Position = GameConstants.ConvertBytesToFloat(instance2.ResourceFilterSaved, j * 6 + 2);
		}
		this.SortObj.SetActive(true);
	}

	// Token: 0x06002B67 RID: 11111 RVA: 0x0047C764 File Offset: 0x0047A964
	public override void OnClose()
	{
		base.OnClose();
		for (int i = 0; i < this.ResourceStr.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.ResourceStr[i]);
		}
		if (this.FilterScrollView != null)
		{
			this.SaveCurScrollPosition();
		}
		for (int j = 0; j < this.TageSave.Length; j++)
		{
			GameConstants.GetBytes(this.TageSave[j].BeginIndex, GUIManager.Instance.ResourceFilterSaved, j * 6);
			GameConstants.GetBytes(this.TageSave[j].Position, GUIManager.Instance.ResourceFilterSaved, j * 6 + 2);
		}
		GUIManager.Instance.ResourceFilterSaved[36] = (byte)this.CurFilterTag;
		if (this.Type == UIResourceFilter.ResourceFilterType.Mutile)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null && door.m_WindowStack.Count > 0)
			{
				GUIWindowStackData value = door.m_WindowStack[door.m_WindowStack.Count - 1];
				value.m_Arg2 = 1;
				door.m_WindowStack[door.m_WindowStack.Count - 1] = value;
			}
		}
	}

	// Token: 0x06002B68 RID: 11112 RVA: 0x0047C8A4 File Offset: 0x0047AAA4
	public override void Init()
	{
		base.Init();
		this.ChangeFilterType(this.CurFilterTag, true);
		this.UpdateResourceData();
		this.bFirstInit = 1;
	}

	// Token: 0x06002B69 RID: 11113 RVA: 0x0047C8D4 File Offset: 0x0047AAD4
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			DataManager.Instance.OpenBagFilterByBuildingWindow = 0;
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.GoToGroup(-1, 0, true);
		}
	}

	// Token: 0x06002B6A RID: 11114 RVA: 0x0047C90C File Offset: 0x0047AB0C
	public override void OnButtonClick(UIButton sender)
	{
		if (this.FilterScrollRect == null)
		{
			return;
		}
		this.BuyAndUse = 0;
		switch (sender.m_BtnID1)
		{
		case 0:
			this.ChangeFilterType(UIResourceFilter.ClickType.Grain, false);
			break;
		case 1:
			this.ChangeFilterType(UIResourceFilter.ClickType.Rock, false);
			break;
		case 2:
			this.ChangeFilterType(UIResourceFilter.ClickType.Wood, false);
			break;
		case 3:
			this.ChangeFilterType(UIResourceFilter.ClickType.Steel, false);
			break;
		case 4:
			this.ChangeFilterType(UIResourceFilter.ClickType.Money, false);
			break;
		default:
			this.SaveCurScrollPosition();
			base.OnButtonClick(sender);
			if (this.Type == UIResourceFilter.ResourceFilterType.Single && sender.m_BtnID1 == 1003)
			{
				NumberConfirm numberConfirm = (GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter) as UIBagFilter).ActivateWindow as NumberConfirm;
				numberConfirm.SetNeedItemQty(this.CurResource, (uint)this.RequireResource);
			}
			break;
		}
	}

	// Token: 0x06002B6B RID: 11115 RVA: 0x0047C9F8 File Offset: 0x0047ABF8
	private void ChangeFilterType(UIResourceFilter.ClickType FilterType, bool bForceUpdate = false)
	{
		if (!bForceUpdate && this.CurFilterTag == FilterType)
		{
			return;
		}
		if (this.Type == UIResourceFilter.ResourceFilterType.Mutile)
		{
			if (this.bFirstInit == 1)
			{
				this.SaveCurScrollPosition();
			}
			this.ResourceText[(int)((byte)this.CurFilterTag)].color = this.TabTextColor;
			this.ResourceTag[(int)((byte)this.CurFilterTag)].alpha = 0f;
			this.CurFilterTag = FilterType;
			this.ResourceText[(int)((byte)this.CurFilterTag)].color = Color.white;
		}
		else
		{
			this.SingleResourceImg.gameObject.SetActive(true);
			this.CurFilterTag = FilterType;
		}
		DataManager instance = DataManager.Instance;
		this.BagCount = -1;
		instance.SortResourceFilterData();
		int num = 0;
		switch (this.CurFilterTag)
		{
		case UIResourceFilter.ClickType.Grain:
			this.SetItemData(instance.sortItemData, instance.sortItemDataStart[1], instance.sortItemDataCount[1], true, this.SortType, num);
			this.BagCount = this.ItemsHeight.Count;
			num += this.BagCount;
			this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[1], instance.SortSotreDataCount[1], false, this.SortType, num);
			break;
		case UIResourceFilter.ClickType.Rock:
			this.SetItemData(instance.sortItemData, instance.sortItemDataStart[2], instance.sortItemDataCount[2], true, this.SortType, num);
			this.BagCount = this.ItemsHeight.Count;
			num += this.BagCount;
			this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[2], instance.SortSotreDataCount[2], false, this.SortType, num);
			break;
		case UIResourceFilter.ClickType.Wood:
			this.SetItemData(instance.sortItemData, instance.sortItemDataStart[3], instance.sortItemDataCount[3], true, this.SortType, num);
			this.BagCount = this.ItemsHeight.Count;
			num += this.BagCount;
			this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[3], instance.SortSotreDataCount[3], false, this.SortType, num);
			break;
		case UIResourceFilter.ClickType.Steel:
			this.SetItemData(instance.sortItemData, instance.sortItemDataStart[4], instance.sortItemDataCount[4], true, this.SortType, num);
			this.BagCount = this.ItemsHeight.Count;
			num += this.BagCount;
			this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[4], instance.SortSotreDataCount[4], false, this.SortType, num);
			break;
		case UIResourceFilter.ClickType.Money:
			this.SetItemData(instance.sortItemData, instance.sortItemDataStart[5], instance.sortItemDataCount[5], true, this.SortType, num);
			this.BagCount = this.ItemsHeight.Count;
			num += this.BagCount;
			this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[5], instance.SortSotreDataCount[5], false, this.SortType, num);
			break;
		case UIResourceFilter.ClickType.PetResource:
			this.SetItemData(instance.sortItemData, instance.sortItemDataStart[8], instance.sortItemDataCount[8], true, this.SortType, num);
			this.BagCount = this.ItemsHeight.Count;
			num += this.BagCount;
			this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[8], instance.SortSotreDataCount[8], false, this.SortType, num);
			break;
		}
		if (this.CastleLv < 9 && (instance.RoleAttr.Guide & 32UL) != 0UL && this.CurFilterTag != UIResourceFilter.ClickType.PetResource)
		{
			this.BagCount++;
			this.ItemsHeight.Insert(0, 109f);
			this.ItemsData.Insert(0, 0);
			base.UpdateScrollItemsCount();
			if (this.ItemsData.Count == 1)
			{
				this.MessageTrans.gameObject.SetActive(true);
			}
		}
		else
		{
			base.UpdateScrollItemsCount();
		}
		this.FilterScrollRect.StopMovement();
		this.FilterScrollView.GoTo((int)this.TageSave[(int)this.CurFilterTag].BeginIndex, this.TageSave[(int)this.CurFilterTag].Position);
	}

	// Token: 0x06002B6C RID: 11116 RVA: 0x0047CE1C File Offset: 0x0047B01C
	private void SaveCurScrollPosition()
	{
		this.TageSave[(int)this.CurFilterTag].BeginIndex = (ushort)this.FilterScrollView.GetBeginIdx();
		this.TageSave[(int)this.CurFilterTag].Position = this.ScrollContent.anchoredPosition.y;
	}

	// Token: 0x06002B6D RID: 11117 RVA: 0x0047CE74 File Offset: 0x0047B074
	public override bool CheckItemRule(ushort id)
	{
		DataManager instance = DataManager.Instance;
		if (this.BagCount == -1)
		{
			return instance.GetCurItemQuantity(id, 0) != 0;
		}
		StoreTbl recordByKey = instance.StoreData.GetRecordByKey(id);
		return recordByKey.AddDiamondBuy != 0 && recordByKey.Filter != 2 && instance.GetCurItemQuantity(recordByKey.ItemID, 0) <= 0;
	}

	// Token: 0x06002B6E RID: 11118 RVA: 0x0047CEE4 File Offset: 0x0047B0E4
	public override void SendPack(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 1002:
			this.BuyAndUse = 0;
			DataManager.Instance.UseItem((ushort)sender.m_BtnID2, 1, 0, 0, 0, 0u, string.Empty, true);
			break;
		case 1003:
			Debug.Log("FilterBaseClickType.AutoUse");
			break;
		case 1004:
			this.BuyAndUse = 1;
			this.CheckBuy(1, (ushort)sender.m_BtnID3, (ushort)sender.m_BtnID2, true, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), 0, 0, 0u);
			break;
		case 1005:
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door.m_eMapMode == EUIOriginMapMode.OriginMap)
			{
				if (!NewbieManager.CheckRename(true))
				{
					StringTable mStringTable = DataManager.Instance.mStringTable;
					GUIManager.Instance.OpenOKCancelBox(GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), mStringTable.GetStringByID(614u), mStringTable.GetStringByID(14595u), 0, 0, mStringTable.GetStringByID(3968u), null);
				}
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14580u), 255, true);
			}
			break;
		}
		case 1006:
			this.ChangeFilterType(this.CurFilterTag, true);
			return;
		}
	}

	// Token: 0x06002B6F RID: 11119 RVA: 0x0047D030 File Offset: 0x0047B230
	public override void UpdateUI(int arge1, int arge2)
	{
		base.UpdateUI(arge1, arge2);
		if (arge1 == 0)
		{
			this.UpdateResourceData();
		}
	}

	// Token: 0x06002B70 RID: 11120 RVA: 0x0047D048 File Offset: 0x0047B248
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Refresh_Item)
		{
			if (networkNews != NetworkNews.Refresh_Resource)
			{
				if (networkNews == NetworkNews.Login)
				{
					this.ChangeFilterType(this.CurFilterTag, true);
					return;
				}
				if (networkNews != NetworkNews.Refresh_BuildBase)
				{
					if (networkNews != NetworkNews.Refresh_PetResource)
					{
						return;
					}
				}
				else
				{
					byte level = GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level;
					if (level == this.CastleLv)
					{
						return;
					}
					this.CastleLv = level;
					this.ChangeFilterType(this.CurFilterTag, true);
					return;
				}
			}
			this.UpdateResourceData();
		}
		else if (this.BuyAndUse == 0)
		{
			this.ChangeFilterType(this.CurFilterTag, true);
		}
	}

	// Token: 0x06002B71 RID: 11121 RVA: 0x0047D108 File Offset: 0x0047B308
	public void UpdateResourceData()
	{
		DataManager instance = DataManager.Instance;
		if (this.Type == UIResourceFilter.ResourceFilterType.Single)
		{
			this.ResourceStr[0].ClearString();
			if (this.CurFilterTag == UIResourceFilter.ClickType.PetResource)
			{
				if ((long)this.RequireResource > (long)((ulong)instance.PetResource.Stock))
				{
					this.ResourceStr[0].StringToFormat("<color=#e5004fff>");
				}
				else
				{
					this.ResourceStr[0].StringToFormat("<color=#ffffffff>");
				}
			}
			else if ((long)this.RequireResource > (long)((ulong)instance.Resource[(int)this.CurFilterTag].Stock))
			{
				this.ResourceStr[0].StringToFormat("<color=#e5004fff>");
			}
			else
			{
				this.ResourceStr[0].StringToFormat("<color=#ffffffff>");
			}
			switch (this.CurFilterTag)
			{
			case UIResourceFilter.ClickType.Grain:
				this.CurResource = instance.Resource[0].Stock;
				break;
			case UIResourceFilter.ClickType.Rock:
				this.CurResource = instance.Resource[1].Stock;
				break;
			case UIResourceFilter.ClickType.Wood:
				this.CurResource = instance.Resource[2].Stock;
				break;
			case UIResourceFilter.ClickType.Steel:
				this.CurResource = instance.Resource[3].Stock;
				break;
			case UIResourceFilter.ClickType.Money:
				this.CurResource = instance.Resource[4].Stock;
				break;
			case UIResourceFilter.ClickType.PetResource:
				this.CurResource = instance.PetResource.Stock;
				break;
			}
			this.ResourceStr[0].IntToFormat((long)((ulong)this.CurResource), 1, true);
			this.ResourceStr[0].IntToFormat((long)this.RequireResource, 1, true);
			this.ResourceStr[0].StringToFormat("</color>");
			if (GUIManager.Instance.IsArabic)
			{
				this.ResourceStr[0].AppendFormat("{2}/{0}{1}{3}");
			}
			else
			{
				this.ResourceStr[0].AppendFormat("{0}{1}{3}/{2}");
			}
			this.ResourceNum.text = this.ResourceStr[0].ToString();
			this.ResourceNum.SetAllDirty();
			this.ResourceNum.cachedTextGenerator.Invalidate();
			this.ResourceNum.cachedTextGeneratorForLayout.Invalidate();
			Vector2 anchoredPosition = this.SingleResourceImg.rectTransform.anchoredPosition;
			anchoredPosition.Set(-this.ResourceNum.preferredWidth * 0.5f - this.SingleResource.rect.size.x * 0.5f, 0f);
			this.SingleResourceImg.rectTransform.anchoredPosition = anchoredPosition;
		}
		else
		{
			this.ResourceStr[0].ClearString();
			if (instance.Resource[0].Stock < 10000u)
			{
				this.ResourceStr[0].IntToFormat((long)((ulong)instance.Resource[0].Stock), 1, true);
				this.ResourceStr[0].AppendFormat("{0}");
			}
			else
			{
				GameConstants.FormatResourceValue(this.ResourceStr[0], instance.Resource[0].Stock);
			}
			this.ResourceText[0].text = this.ResourceStr[0].ToString();
			this.ResourceStr[1].ClearString();
			if (instance.Resource[2].Stock < 10000u)
			{
				this.ResourceStr[1].IntToFormat((long)((ulong)instance.Resource[2].Stock), 1, true);
				this.ResourceStr[1].AppendFormat("{0}");
			}
			else
			{
				GameConstants.FormatResourceValue(this.ResourceStr[1], instance.Resource[2].Stock);
			}
			this.ResourceText[2].text = this.ResourceStr[1].ToString();
			this.ResourceStr[2].ClearString();
			if (instance.Resource[1].Stock < 10000u)
			{
				this.ResourceStr[2].IntToFormat((long)((ulong)instance.Resource[1].Stock), 1, true);
				this.ResourceStr[2].AppendFormat("{0}");
			}
			else
			{
				GameConstants.FormatResourceValue(this.ResourceStr[2], instance.Resource[1].Stock);
			}
			this.ResourceText[1].text = this.ResourceStr[2].ToString();
			this.ResourceStr[3].ClearString();
			if (instance.Resource[3].Stock < 10000u)
			{
				this.ResourceStr[3].IntToFormat((long)((ulong)instance.Resource[3].Stock), 1, true);
				this.ResourceStr[3].AppendFormat("{0}");
			}
			else
			{
				GameConstants.FormatResourceValue(this.ResourceStr[3], instance.Resource[3].Stock);
			}
			this.ResourceText[3].text = this.ResourceStr[3].ToString();
			this.ResourceStr[4].ClearString();
			if (instance.Resource[4].Stock < 10000u)
			{
				this.ResourceStr[4].IntToFormat((long)((ulong)instance.Resource[4].Stock), 1, true);
				this.ResourceStr[4].AppendFormat("{0}");
			}
			else
			{
				GameConstants.FormatResourceValue(this.ResourceStr[4], instance.Resource[4].Stock);
			}
			this.ResourceText[4].text = this.ResourceStr[4].ToString();
			for (int i = 0; i < this.ResourceText.Length; i++)
			{
				this.ResourceText[i].SetAllDirty();
				this.ResourceText[i].cachedTextGenerator.Invalidate();
			}
		}
	}

	// Token: 0x06002B72 RID: 11122 RVA: 0x0047D6A8 File Offset: 0x0047B8A8
	public override void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		base.UpDateRowItem(item, dataIdx, panelObjectIdx, panelId);
		if (this.ItemsData.Count <= dataIdx)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		this.FilterItem[panelObjectIdx].KeyID = this.ItemsData[dataIdx];
		Equip recordByKey;
		ushort curItemQuantity;
		if (this.BagCount > dataIdx)
		{
			if (this.FilterItem[panelObjectIdx].KeyID == 0)
			{
				base.SetItemType(panelObjectIdx, UIFilterBase.eItemType.Grain + (int)this.CurFilterTag);
				return;
			}
			recordByKey = instance.EquipTable.GetRecordByKey(this.FilterItem[panelObjectIdx].KeyID);
			curItemQuantity = instance.GetCurItemQuantity(recordByKey.EquipKey, 0);
			base.SetItemType(panelObjectIdx, UIFilterBase.eItemType.Use);
			if (curItemQuantity <= 1)
			{
				this.FilterItem[panelObjectIdx].AutouseBtnTrans.gameObject.SetActive(false);
			}
			else
			{
				this.FilterItem[panelObjectIdx].AutouseBtnTrans.gameObject.SetActive(true);
			}
		}
		else
		{
			StoreTbl recordByKey2 = instance.StoreData.GetRecordByKey(this.FilterItem[panelObjectIdx].KeyID);
			recordByKey = instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
			curItemQuantity = instance.GetCurItemQuantity(recordByKey.EquipKey, 0);
			base.SetItemType(panelObjectIdx, UIFilterBase.eItemType.BuyAndUse);
			this.FilterItem[panelObjectIdx].BuyPriceStr.ClearString();
			this.FilterItem[panelObjectIdx].BuyPriceStr.IntToFormat((long)((ulong)recordByKey2.Price), 1, true);
			this.FilterItem[panelObjectIdx].BuyPriceStr.AppendFormat("{0}");
			this.FilterItem[panelObjectIdx].BuyPrice.text = this.FilterItem[panelObjectIdx].BuyPriceStr.ToString();
			this.FilterItem[panelObjectIdx].BuyPrice.SetAllDirty();
			this.FilterItem[panelObjectIdx].BuyPrice.cachedTextGenerator.Invalidate();
			this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID3 = (int)recordByKey2.ID;
		}
		GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[panelObjectIdx].ItemTrans, eHeroOrItem.Item, recordByKey.EquipKey, 0, 0, 0);
		this.FilterItem[panelObjectIdx].Name.text = instance.mStringTable.GetStringByID((uint)recordByKey.EquipName);
		this.FilterItem[panelObjectIdx].Content.text = instance.mStringTable.GetStringByID((uint)recordByKey.EquipInfo);
		this.FilterItem[panelObjectIdx].OwnerStr.ClearString();
		this.FilterItem[panelObjectIdx].OwnerStr.StringToFormat(this.OwnerStr);
		this.FilterItem[panelObjectIdx].OwnerStr.IntToFormat((long)curItemQuantity, 1, true);
		this.FilterItem[panelObjectIdx].OwnerStr.AppendFormat("{0}{1}");
		this.FilterItem[panelObjectIdx].Owner.text = this.FilterItem[panelObjectIdx].OwnerStr.ToString();
		this.FilterItem[panelObjectIdx].Owner.SetAllDirty();
		this.FilterItem[panelObjectIdx].Owner.cachedTextGenerator.Invalidate();
		this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID2 = (int)recordByKey.EquipKey;
	}

	// Token: 0x06002B73 RID: 11123 RVA: 0x0047DA10 File Offset: 0x0047BC10
	public override void Update()
	{
		base.Update();
		if (this.PassInit > 0)
		{
			return;
		}
		if (this.Type == UIResourceFilter.ResourceFilterType.Mutile)
		{
			this.DeltaTime += Time.deltaTime;
			if (this.DeltaTime >= 2f)
			{
				this.DeltaTime = 0f;
			}
			float alpha = (this.DeltaTime <= 1f) ? this.DeltaTime : (2f - this.DeltaTime);
			this.ResourceTag[(int)this.CurFilterTag].alpha = alpha;
		}
	}

	// Token: 0x04007800 RID: 30720
	private UIText[] ResourceText = new UIText[5];

	// Token: 0x04007801 RID: 30721
	private CString[] ResourceStr;

	// Token: 0x04007802 RID: 30722
	private Color TabTextColor;

	// Token: 0x04007803 RID: 30723
	private float DeltaTime;

	// Token: 0x04007804 RID: 30724
	private byte CastleLv;

	// Token: 0x04007805 RID: 30725
	private UIResourceFilter.ClickType CurFilterTag;

	// Token: 0x04007806 RID: 30726
	private UIResourceFilter.ResourceFilterType Type;

	// Token: 0x04007807 RID: 30727
	protected int BagCount;

	// Token: 0x04007808 RID: 30728
	private CanvasGroup[] ResourceTag = new CanvasGroup[5];

	// Token: 0x04007809 RID: 30729
	private UIText ResourceNum;

	// Token: 0x0400780A RID: 30730
	private Image SingleResourceImg;

	// Token: 0x0400780B RID: 30731
	private Sprite SingleResource;

	// Token: 0x0400780C RID: 30732
	private int RequireResource;

	// Token: 0x0400780D RID: 30733
	private uint CurResource;

	// Token: 0x0400780E RID: 30734
	private UIResourceFilter._TageSave[] TageSave = new UIResourceFilter._TageSave[6];

	// Token: 0x0400780F RID: 30735
	private byte bFirstInit;

	// Token: 0x04007810 RID: 30736
	private byte BuyAndUse;

	// Token: 0x02000830 RID: 2096
	private enum ClickType
	{
		// Token: 0x04007812 RID: 30738
		Grain,
		// Token: 0x04007813 RID: 30739
		Rock,
		// Token: 0x04007814 RID: 30740
		Wood,
		// Token: 0x04007815 RID: 30741
		Steel,
		// Token: 0x04007816 RID: 30742
		Money,
		// Token: 0x04007817 RID: 30743
		PetResource,
		// Token: 0x04007818 RID: 30744
		None
	}

	// Token: 0x02000831 RID: 2097
	private enum ResourceFilterType
	{
		// Token: 0x0400781A RID: 30746
		Mutile,
		// Token: 0x0400781B RID: 30747
		Single
	}

	// Token: 0x02000832 RID: 2098
	private struct _TageSave
	{
		// Token: 0x0400781C RID: 30748
		public ushort BeginIndex;

		// Token: 0x0400781D RID: 30749
		public float Position;
	}
}
