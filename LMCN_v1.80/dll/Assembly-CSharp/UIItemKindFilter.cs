using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000838 RID: 2104
public class UIItemKindFilter : UIFilterBase
{
	// Token: 0x06002B94 RID: 11156 RVA: 0x0047FB30 File Offset: 0x0047DD30
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager instance = DataManager.Instance;
		base.OnOpen(arg1, arg2);
		this.ThisTransform = base.SetFunc(this.transform.GetChild(4));
		this.ThisTransform.gameObject.SetActive(true);
		this.Title = this.ThisTransform.GetComponent<UIText>();
		this.Title.font = GUIManager.Instance.GetTTFFont();
		base.AddRefreshText(this.Title);
		this.ItemKind = (byte)arg1;
		this.EffectVal = (byte)arg2;
		this.SuitId = (byte)(arg2 >> 16);
		this.TitleStr = StringManager.Instance.SpawnString(30);
		EItemType eitemType = (EItemType)(this.ItemKind - 1);
		switch (eitemType)
		{
		case EItemType.EIT_CaseByCase:
			if (this.EffectVal == 30)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 3);
				this.MainText.text = instance.mStringTable.GetStringByID(8330u);
				this.EnergyImgRect = this.ThisTransform.GetChild(3).GetChild(0).GetComponent<RectTransform>();
				this.EnergyImgRect.GetComponent<UISpritesArray>().SetSpriteIndex(0);
				this.EnergyText = this.ThisTransform.GetChild(3).GetChild(1).GetComponent<Text>();
				this.EnergyText.font = GUIManager.Instance.GetTTFFont();
				base.AddRefreshText(this.EnergyText);
				this.VipLvStr = StringManager.Instance.SpawnString(30);
			}
			else if (this.EffectVal == 40)
			{
				this.MainText.text = instance.mStringTable.GetStringByID(9642u);
				this.GamebleRect = this.ThisTransform.GetChild(3).GetChild(0).GetComponent<RectTransform>();
				this.GamebleRect.GetComponent<UISpritesArray>().SetSpriteIndex(1);
				this.GamebleRect.GetComponent<Image>().SetNativeSize();
				this.EnergyText = this.ThisTransform.GetChild(3).GetChild(1).GetComponent<Text>();
				this.EnergyText.font = GUIManager.Instance.GetTTFFont();
				base.AddRefreshText(this.EnergyText);
				this.VipLvStr = StringManager.Instance.SpawnString(30);
			}
			else if (this.EffectVal == 33)
			{
				this.MainText.text = instance.mStringTable.GetStringByID(894u);
				this.VIPTrans = this.ThisTransform.GetChild(2);
				this.VIPTrans.gameObject.SetActive(true);
				if (GUIManager.Instance.IsArabic)
				{
					this.VIPTrans.localScale = new Vector3(-1f, 1f, 1f);
				}
				this.Degree = this.VIPTrans.GetChild(0).GetChild(0).GetComponent<RectTransform>();
				this.BarText = this.VIPTrans.GetChild(0).GetChild(1).GetComponent<UIText>();
				this.BarText.font = GUIManager.Instance.GetTTFFont();
				base.AddRefreshText(this.BarText);
				this.VipLvText = this.VIPTrans.GetChild(1).GetComponent<UIText>();
				this.VipLvText.font = this.BarText.font;
				base.AddRefreshText(this.VipLvText);
				this.VipBarStr = StringManager.Instance.SpawnString(150);
				this.VipLvStr = StringManager.Instance.SpawnString(30);
				this.ShowSopItem = 0;
			}
			break;
		default:
			if (eitemType == EItemType.EIT_MaterialTreasureBox)
			{
				switch (this.EffectVal)
				{
				case 1:
					this.MainText.text = instance.mStringTable.GetStringByID(7518u);
					this.Title.text = instance.mStringTable.GetStringByID(7519u);
					break;
				case 2:
					this.MainText.text = instance.mStringTable.GetStringByID(7521u);
					this.Title.text = instance.mStringTable.GetStringByID(7522u);
					break;
				case 3:
					this.MainText.text = instance.mStringTable.GetStringByID(16144u);
					this.Title.text = instance.mStringTable.GetStringByID(16145u);
					break;
				}
				if (this.SuitId != 0)
				{
					UIText component = this.MessageTrans.GetChild(0).GetComponent<UIText>();
					component.text = instance.mStringTable.GetStringByID(8405u);
					base.AddRefreshText(component);
					Vector2 sizeDelta = this.MessageTrans.sizeDelta;
					sizeDelta.x = component.preferredWidth + 165f;
					this.MessageTrans.sizeDelta = sizeDelta;
				}
			}
			break;
		case EItemType.EIT_VIP:
			this.MainText.text = instance.mStringTable.GetStringByID(7709u);
			this.VIPTrans = this.ThisTransform.GetChild(2);
			this.VIPTrans.gameObject.SetActive(true);
			if (GUIManager.Instance.IsArabic)
			{
				this.VIPTrans.localScale = new Vector3(-1f, 1f, 1f);
			}
			this.Degree = this.VIPTrans.GetChild(0).GetChild(0).GetComponent<RectTransform>();
			this.BarText = this.VIPTrans.GetChild(0).GetChild(1).GetComponent<UIText>();
			this.BarText.font = GUIManager.Instance.GetTTFFont();
			base.AddRefreshText(this.BarText);
			this.VipLvText = this.VIPTrans.GetChild(1).GetComponent<UIText>();
			this.VipLvText.font = this.BarText.font;
			base.AddRefreshText(this.VipLvText);
			this.VipBarStr = StringManager.Instance.SpawnString(150);
			this.VipLvStr = StringManager.Instance.SpawnString(30);
			break;
		}
	}

	// Token: 0x06002B95 RID: 11157 RVA: 0x00480120 File Offset: 0x0047E320
	public override void Init()
	{
		base.Init();
		this.ChangeItemType(false);
		switch (this.ItemKind - 1)
		{
		case 9:
			if (this.EffectVal == 30)
			{
				this.UpdateMonsterPoint();
			}
			else if (this.EffectVal == 40)
			{
				this.UpdateGameblePoint();
			}
			else
			{
				this.UpdateExp();
			}
			break;
		case 12:
			this.UpdateVip();
			break;
		}
	}

	// Token: 0x06002B96 RID: 11158 RVA: 0x004801A8 File Offset: 0x0047E3A8
	public override void OnHIButtonClick(UIHIBtn sender)
	{
		if (sender.m_BtnID2 == 0)
		{
			return;
		}
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		door.OpenMenu(EGUIWindow.UI_OpenBox, 1, sender.m_BtnID2, false);
	}

	// Token: 0x06002B97 RID: 11159 RVA: 0x004801E4 File Offset: 0x0047E3E4
	public override void OnClose()
	{
		base.OnClose();
		StringManager.Instance.DeSpawnString(this.TitleStr);
		StringManager.Instance.DeSpawnString(this.VipBarStr);
		StringManager.Instance.DeSpawnString(this.VipLvStr);
	}

	// Token: 0x06002B98 RID: 11160 RVA: 0x0048022C File Offset: 0x0047E42C
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
		if ((int)this.ItemKind <= instance.sortItemDataStart.Length)
		{
			this.SetItemData(instance.sortItemData, instance.sortItemDataStart[(int)(this.ItemKind - 1)], instance.sortItemDataCount[(int)(this.ItemKind - 1)], true, 0, 0);
		}
		this.BagCount = this.ItemsHeight.Count;
		if (this.ShowSopItem == 1)
		{
			this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[(int)this.ItemKind], instance.SortSotreDataCount[(int)this.ItemKind], false, 0, 0);
		}
		base.UpdateScrollItemsCount();
		if (!bMoveTop)
		{
			this.FilterScrollView.GoTo(itemidx, vector.y);
		}
	}

	// Token: 0x06002B99 RID: 11161 RVA: 0x00480328 File Offset: 0x0047E528
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
		EItemType eitemType = (EItemType)(this.ItemKind - 1);
		if (eitemType != EItemType.EIT_MaterialTreasureBox)
		{
			if (recordByKey.PropertiesInfo[0].Propertieskey == (ushort)this.EffectVal)
			{
				return true;
			}
		}
		else if (this.SuitId > 0)
		{
			if (recordByKey.PropertiesInfo[3].Propertieskey == (ushort)this.EffectVal && recordByKey.ActivitySuitIndex == this.SuitId)
			{
				return true;
			}
		}
		else if (recordByKey.PropertiesInfo[3].Propertieskey == (ushort)this.EffectVal)
		{
			return true;
		}
		return false;
	}

	// Token: 0x06002B9A RID: 11162 RVA: 0x0048044C File Offset: 0x0047E64C
	public override void SendPack(UIButton sender)
	{
		if (this.ItemKind - 1 == 12)
		{
			GUIManager.Instance.m_SpeciallyEffect.mAddVIP = true;
			RectTransform component = sender.transform.parent.GetChild(0).GetComponent<RectTransform>();
			RectTransform component2 = sender.transform.parent.GetComponent<RectTransform>();
			RectTransform component3 = sender.transform.parent.parent.GetComponent<RectTransform>();
			RectTransform component4 = sender.transform.parent.parent.parent.GetComponent<RectTransform>();
			RectTransform component5 = sender.transform.parent.parent.parent.parent.GetComponent<RectTransform>();
			GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + component5.anchoredPosition.x + 52f + component.anchoredPosition.x + component3.anchoredPosition.x + component4.anchoredPosition.x, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f + 50f - component5.anchoredPosition.y - component4.anchoredPosition.y - component3.anchoredPosition.y - component2.anchoredPosition.y - component.anchoredPosition.y);
			RectTransform component6 = this.VIPTrans.GetChild(0).GetComponent<RectTransform>();
			RectTransform component7 = this.VIPTrans.parent.GetComponent<RectTransform>();
			GUIManager.Instance.m_SpeciallyEffect.UI_bezieEnd = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f - component6.anchoredPosition.x, -(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - component7.anchoredPosition.y - component6.anchoredPosition.y));
		}
		this.ClickSender = sender;
		switch (this.ClickSender.m_BtnID1)
		{
		case 1002:
			this.BuyAndUse = 0;
			if (!base.CheckItemEnergy((ushort)this.ClickSender.m_BtnID2, 1))
			{
				DataManager.Instance.UseItem((ushort)this.ClickSender.m_BtnID2, 1, 0, 0, 0, 0u, string.Empty, true);
			}
			break;
		case 1004:
			this.BuyAndUse = 1;
			if (!base.CheckItemEnergy((ushort)this.ClickSender.m_BtnID2, 2))
			{
				this.CheckBuy(1, (ushort)this.ClickSender.m_BtnID3, (ushort)this.ClickSender.m_BtnID2, true, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), 0, 0, 0u);
			}
			break;
		}
	}

	// Token: 0x06002B9B RID: 11163 RVA: 0x00480764 File Offset: 0x0047E964
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (!bOK)
		{
			return;
		}
		if (arg2 != 1)
		{
			if (arg2 == 2)
			{
				this.CheckBuy(1, (ushort)this.ClickSender.m_BtnID3, (ushort)this.ClickSender.m_BtnID2, true, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), 0, 0, 0u);
			}
		}
		else
		{
			DataManager.Instance.UseItem((ushort)this.ClickSender.m_BtnID2, 1, 0, 0, 0, 0u, string.Empty, true);
		}
	}

	// Token: 0x06002B9C RID: 11164 RVA: 0x004807E8 File Offset: 0x0047E9E8
	public void UpdateVip()
	{
		if (this.ItemKind - 1 != 12)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		VIP_DataTbl recordByKey = instance.VIPLevelTable.GetRecordByKey((ushort)instance.RoleAttr.VIPLevel);
		float num = 424.47f / recordByKey.VIPPoint;
		Vector2 sizeDelta = this.Degree.sizeDelta;
		sizeDelta.x = num * instance.RoleAttr.VipPoint;
		this.Degree.sizeDelta = sizeDelta;
		this.VipBarStr.ClearString();
		if (instance.RoleAttr.VIPLevel < instance.RoleAttr.VIPLevelMax)
		{
			this.VipBarStr.StringToFormat(instance.mStringTable.GetStringByID(7703u));
			this.VipBarStr.IntToFormat((long)((ulong)instance.RoleAttr.VipPoint), 1, true);
			this.VipBarStr.IntToFormat((long)((ulong)recordByKey.VIPPoint), 1, true);
			this.VipBarStr.AppendFormat("{0}{1} / {2}");
		}
		else
		{
			this.VipBarStr.Append(instance.mStringTable.GetStringByID(7725u));
		}
		this.BarText.text = this.VipBarStr.ToString();
		this.BarText.SetAllDirty();
		this.BarText.cachedTextGenerator.Invalidate();
		this.VipLvStr.ClearString();
		this.VipLvStr.IntToFormat((long)instance.RoleAttr.VIPLevel, 1, false);
		this.VipLvStr.AppendFormat(instance.mStringTable.GetStringByID(7723u));
		this.VipLvText.text = this.VipLvStr.ToString();
		this.VipLvText.SetAllDirty();
		this.VipLvText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06002B9D RID: 11165 RVA: 0x004809A8 File Offset: 0x0047EBA8
	public void UpdateMonsterPoint()
	{
		if (this.EnergyImgRect == null)
		{
			return;
		}
		this.ThisTransform.GetChild(3).gameObject.SetActive(true);
		DataManager instance = DataManager.Instance;
		this.VipLvStr.ClearString();
		this.VipLvStr.IntToFormat((long)((ulong)instance.RoleAttr.MonsterPoint), 1, true);
		this.VipLvStr.IntToFormat((long)((ulong)instance.GetMaxMonsterPoint()), 1, true);
		if (GUIManager.Instance.IsArabic)
		{
			this.VipLvStr.AppendFormat("{1} / {0}");
		}
		else
		{
			this.VipLvStr.AppendFormat("{0} / {1}");
		}
		this.EnergyText.text = this.VipLvStr.ToString();
		this.EnergyText.SetAllDirty();
		this.EnergyText.cachedTextGenerator.Invalidate();
		this.EnergyText.cachedTextGeneratorForLayout.Invalidate();
		float x = this.EnergyText.preferredWidth * -0.5f - 17.5f;
		this.EnergyImgRect.anchoredPosition = new Vector2(x, this.EnergyImgRect.anchoredPosition.y);
	}

	// Token: 0x06002B9E RID: 11166 RVA: 0x00480AD0 File Offset: 0x0047ECD0
	private void UpdateGameblePoint()
	{
		if (this.GamebleRect == null)
		{
			return;
		}
		this.ThisTransform.GetChild(3).gameObject.SetActive(true);
		DataManager instance = DataManager.Instance;
		this.VipLvStr.ClearString();
		this.VipLvStr.IntToFormat((long)((ulong)instance.RoleAttr.ScardStar), 1, true);
		this.VipLvStr.AppendFormat("{0}");
		this.EnergyText.text = this.VipLvStr.ToString();
		this.EnergyText.SetAllDirty();
		this.EnergyText.cachedTextGenerator.Invalidate();
		this.EnergyText.cachedTextGeneratorForLayout.Invalidate();
		float x = this.EnergyText.preferredWidth * -0.5f - 24.5f;
		this.GamebleRect.anchoredPosition = new Vector2(x, this.GamebleRect.anchoredPosition.y);
	}

	// Token: 0x06002B9F RID: 11167 RVA: 0x00480BC0 File Offset: 0x0047EDC0
	public void UpdateExp()
	{
		if (this.ItemKind - 1 != 9 || this.EffectVal != 33)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		LevelUp recordByKey = instance.LevelUpTable.GetRecordByKey((ushort)instance.RoleAttr.Level);
		float num = 424.47f / recordByKey.KingdomExp;
		Vector2 sizeDelta = this.Degree.sizeDelta;
		this.VipBarStr.ClearString();
		if (instance.RoleAttr.Level < 60)
		{
			this.VipBarStr.IntToFormat((long)((ulong)instance.RoleAttr.Exp), 1, true);
			this.VipBarStr.IntToFormat((long)((ulong)recordByKey.KingdomExp), 1, true);
			this.VipBarStr.AppendFormat(instance.mStringTable.GetStringByID(896u));
			sizeDelta.x = num * instance.RoleAttr.Exp;
		}
		else
		{
			this.VipBarStr.Append(instance.mStringTable.GetStringByID(898u));
			sizeDelta.x = 424.7f;
		}
		this.Degree.sizeDelta = sizeDelta;
		this.BarText.text = this.VipBarStr.ToString();
		this.BarText.SetAllDirty();
		this.BarText.cachedTextGenerator.Invalidate();
		this.VipLvStr.ClearString();
		this.VipLvStr.IntToFormat((long)instance.RoleAttr.Level, 1, false);
		this.VipLvStr.AppendFormat(instance.mStringTable.GetStringByID(895u));
		this.VipLvText.text = this.VipLvStr.ToString();
		this.VipLvText.SetAllDirty();
		this.VipLvText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06002BA0 RID: 11168 RVA: 0x00480D7C File Offset: 0x0047EF7C
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Refresh_VIP)
		{
			if (networkNews != NetworkNews.Refresh_MonsterPoint)
			{
				if (networkNews != NetworkNews.Login)
				{
					if (networkNews == NetworkNews.Refresh_Item)
					{
						if (this.BuyAndUse == 0)
						{
							this.ChangeItemType(false);
						}
						this.BuyAndUse = 0;
						this.UpdateVip();
						this.UpdateMonsterPoint();
						this.UpdateGameblePoint();
						this.UpdateExp();
					}
				}
				else
				{
					GUIManager.Instance.m_SpeciallyEffect.mAddVIP = false;
					this.ChangeItemType(false);
					this.UpdateVip();
					this.UpdateExp();
				}
			}
			else
			{
				this.UpdateMonsterPoint();
			}
		}
		else
		{
			this.UpdateVip();
		}
	}

	// Token: 0x06002BA1 RID: 11169 RVA: 0x00480E2C File Offset: 0x0047F02C
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
		if (recordByKey2.EquipKind == 18 && (recordByKey2.PropertiesInfo[2].Propertieskey < 1 || recordByKey2.PropertiesInfo[2].Propertieskey > 3 || recordByKey2.PropertiesInfo[0].Propertieskey == 4))
		{
			this.FilterItem[panelObjectIdx].NameStr.ClearString();
			this.FilterItem[panelObjectIdx].NameStr.StringToFormat(instance.mStringTable.GetStringByID(7732u + (uint)recordByKey2.Color));
			this.FilterItem[panelObjectIdx].NameStr.AppendFormat(instance.mStringTable.GetStringByID(7739u));
			this.FilterItem[panelObjectIdx].NameStr.Append(instance.mStringTable.GetStringByID((uint)recordByKey2.EquipName));
			this.FilterItem[panelObjectIdx].Name.text = this.FilterItem[panelObjectIdx].NameStr.ToString();
			this.FilterItem[panelObjectIdx].Name.SetAllDirty();
			this.FilterItem[panelObjectIdx].Name.cachedTextGenerator.Invalidate();
			this.FilterItem[panelObjectIdx].InfoTrans.gameObject.SetActive(true);
			this.FilterItem[panelObjectIdx].ItemBtn.m_BtnID2 = (int)recordByKey2.EquipKey;
			GUIManager.Instance.SetItemScaleClickSound(this.FilterItem[panelObjectIdx].ItemBtn, true, true);
		}
		else if (num == 1)
		{
			this.FilterItem[panelObjectIdx].Name.text = instance.mStringTable.GetStringByID((uint)recordByKey2.EquipName);
			this.FilterItem[panelObjectIdx].InfoTrans.gameObject.SetActive(false);
			this.FilterItem[panelObjectIdx].ItemBtn.m_BtnID2 = 0;
			GUIManager.Instance.SetItemScaleClickSound(this.FilterItem[panelObjectIdx].ItemBtn, false, false);
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
			this.FilterItem[panelObjectIdx].InfoTrans.gameObject.SetActive(false);
			this.FilterItem[panelObjectIdx].ItemBtn.m_BtnID2 = 0;
			GUIManager.Instance.SetItemScaleClickSound(this.FilterItem[panelObjectIdx].ItemBtn, false, false);
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
		this.FilterItem[panelObjectIdx].AutouseBtnTrans.gameObject.SetActive(curItemQuantity > 1);
	}

	// Token: 0x0400783C RID: 30780
	private int BagCount;

	// Token: 0x0400783D RID: 30781
	private byte ItemKind;

	// Token: 0x0400783E RID: 30782
	private byte EffectVal;

	// Token: 0x0400783F RID: 30783
	private byte SuitId;

	// Token: 0x04007840 RID: 30784
	private UIText Title;

	// Token: 0x04007841 RID: 30785
	private UIText BarText;

	// Token: 0x04007842 RID: 30786
	private UIText VipLvText;

	// Token: 0x04007843 RID: 30787
	private Text EnergyText;

	// Token: 0x04007844 RID: 30788
	private RectTransform EnergyImgRect;

	// Token: 0x04007845 RID: 30789
	private RectTransform GamebleRect;

	// Token: 0x04007846 RID: 30790
	private CString TitleStr;

	// Token: 0x04007847 RID: 30791
	private CString VipBarStr;

	// Token: 0x04007848 RID: 30792
	private CString VipLvStr;

	// Token: 0x04007849 RID: 30793
	private byte BuyAndUse;

	// Token: 0x0400784A RID: 30794
	private byte ShowSopItem = 1;

	// Token: 0x0400784B RID: 30795
	private UIButton ClickSender;

	// Token: 0x0400784C RID: 30796
	private Transform VIPTrans;

	// Token: 0x0400784D RID: 30797
	private RectTransform Degree;
}
