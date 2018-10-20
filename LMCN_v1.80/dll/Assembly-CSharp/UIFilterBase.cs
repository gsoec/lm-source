using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000828 RID: 2088
public class UIFilterBase : UIBagFilterBase
{
	// Token: 0x06002B54 RID: 11092 RVA: 0x0047A7BC File Offset: 0x004789BC
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager instance = GUIManager.Instance;
		DataManager instance2 = DataManager.Instance;
		Font ttffont = instance.GetTTFFont();
		base.OnOpen(arg1, arg2);
		this.ThisTransform = this.transform.GetChild(1);
		this.ThisTransform.gameObject.SetActive(true);
		this.FilterSpriteArr = this.ThisTransform.GetChild(6).GetComponent<UISpritesArray>();
		this.ResourceSpriteArr = this.ThisTransform.GetChild(6).GetChild(0).GetComponent<UISpritesArray>();
		this.ResourceMat = this.ThisTransform.GetChild(6).GetChild(0).GetComponent<Image>().material;
		UIButton component = this.ThisTransform.GetChild(4).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 1001;
		if (instance.bOpenOnIPhoneX)
		{
			this.ThisTransform.GetChild(4).GetComponent<Image>().enabled = false;
		}
		instance.UpdateUI(EGUIWindow.Door, 1, 2);
		this.MainText = this.ThisTransform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.MainText.font = ttffont;
		base.AddRefreshText(this.MainText);
		this.OwnerStr = instance2.mStringTable.GetStringByID(281u);
		this.MessageTrans = this.ThisTransform.GetChild(2).GetComponent<RectTransform>();
		UIText component2 = this.MessageTrans.GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = instance2.mStringTable.GetStringByID(744u);
		base.AddRefreshText(component2);
		Vector2 sizeDelta = this.MessageTrans.sizeDelta;
		sizeDelta.x = component2.preferredWidth + 165f;
		this.MessageTrans.sizeDelta = sizeDelta;
		this.SortObj = this.ThisTransform.GetChild(7).gameObject;
		this.SortSpriteArray = this.ThisTransform.GetChild(7).GetComponent<UISpritesArray>();
		component = this.ThisTransform.GetChild(7).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 1006;
		Transform child = this.ThisTransform.GetChild(5);
		instance.InitianHeroItemImg(child.GetChild(0), eHeroOrItem.Item, 0, 0, 0, 0, false, false, false, false);
		child.GetChild(2).GetComponent<UIText>().font = ttffont;
		this.Crystal = child.GetChild(3).GetChild(0).GetComponent<Image>();
		instance.m_ItemInfo.LoadCustomImage(this.Crystal, "UI_main_money_02", null);
		this.Crystal.SetNativeSize();
		child.GetChild(3).GetChild(1).GetComponent<UIText>().font = ttffont;
		child.GetChild(3).GetChild(2).GetComponent<UIText>().font = ttffont;
		child.GetChild(4).GetComponent<UIText>().font = ttffont;
		child.GetChild(5).GetComponent<UIText>().font = ttffont;
		child.GetChild(6).GetChild(0).GetComponent<UIText>().font = ttffont;
	}

	// Token: 0x06002B55 RID: 11093 RVA: 0x0047AABC File Offset: 0x00478CBC
	public virtual void Init()
	{
		this.FilterScrollView = this.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<ScrollPanel>();
		byte b = 0;
		while ((int)b < this.ScrollItemCount)
		{
			this.ItemsHeight.Add(128f);
			b += 1;
		}
		this.FilterItem = new UIFilterBase.ItemEdit[5];
		this.FilterScrollView.IntiScrollPanel(452f, 0f, 0f, this.ItemsHeight, this.ScrollItemCount, this);
		this.FilterScrollRect = this.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<CScrollRect>();
		this.ScrollContent = this.transform.GetChild(1).GetChild(3).GetChild(0).GetChild(0).GetComponent<RectTransform>();
		this.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
		if (this.SortObj.activeSelf)
		{
			this.SortSpriteArray.m_Image.enabled = true;
			if (!byte.TryParse(PlayerPrefs.GetString("SpeedUp_Sort"), out this.SortType))
			{
				this.SortType = 0;
				PlayerPrefs.SetString("SpeedUp_Sort", this.SortType.ToString());
			}
			if (this.SortType > 1)
			{
				this.SortType = 1;
			}
			this.SortSpriteArray.SetSpriteIndex((int)this.SortType);
		}
	}

	// Token: 0x06002B56 RID: 11094 RVA: 0x0047AC2C File Offset: 0x00478E2C
	public Transform SetFunc(Transform func)
	{
		func.SetParent(this.ThisTransform.GetChild(1));
		return this.ThisTransform.GetChild(1).GetChild(0);
	}

	// Token: 0x06002B57 RID: 11095 RVA: 0x0047AC60 File Offset: 0x00478E60
	protected void SetItemType(int ItemArrayIndex, UIFilterBase.eItemType UseType)
	{
		switch (UseType)
		{
		case UIFilterBase.eItemType.Use:
		{
			this.FilterItem[ItemArrayIndex].ItemTrans.gameObject.SetActive(true);
			this.FilterItem[ItemArrayIndex].OtherImgRect.gameObject.SetActive(false);
			this.FilterItem[ItemArrayIndex].recttransform.sizeDelta = new Vector2(776f, 128f);
			this.FilterItem[ItemArrayIndex].Content.rectTransform.sizeDelta = new Vector2(420f, 77f);
			this.FilterItem[ItemArrayIndex].BuyImage.sprite = this.FilterSpriteArr.GetSprite(0);
			Vector2 vector = this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition;
			vector.Set(669f, -35.5f);
			this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition = vector;
			vector.Set(131f, 57f);
			this.FilterItem[ItemArrayIndex].BuyTrans.sizeDelta = vector;
			this.FilterItem[ItemArrayIndex].BuyCrystalTrans.gameObject.SetActive(false);
			this.FilterItem[ItemArrayIndex].BuyPrice.enabled = false;
			this.FilterItem[ItemArrayIndex].BuyCaption.text = DataManager.Instance.mStringTable.GetStringByID(94u);
			this.FilterItem[ItemArrayIndex].BuyBtn.m_BtnID1 = 1002;
			vector.Set(65.5f, -28.5f);
			this.FilterItem[ItemArrayIndex].BuyCaptionTrans.anchoredPosition = vector;
			vector.Set(131f, 57f);
			this.FilterItem[ItemArrayIndex].BuyCaptionTrans.sizeDelta = vector;
			this.FilterItem[ItemArrayIndex].AutouseBtnTrans.gameObject.SetActive(true);
			if (this.FilterItem[ItemArrayIndex].Lock.gameObject.activeSelf)
			{
				this.FilterItem[ItemArrayIndex].Lock.gameObject.SetActive(false);
			}
			break;
		}
		case UIFilterBase.eItemType.BuyAndUse:
		{
			this.FilterItem[ItemArrayIndex].ItemTrans.gameObject.SetActive(true);
			this.FilterItem[ItemArrayIndex].OtherImgRect.gameObject.SetActive(false);
			this.FilterItem[ItemArrayIndex].recttransform.sizeDelta = new Vector2(776f, 128f);
			this.FilterItem[ItemArrayIndex].Content.rectTransform.sizeDelta = new Vector2(420f, 77f);
			this.FilterItem[ItemArrayIndex].BuyImage.sprite = this.FilterSpriteArr.GetSprite(1);
			Vector2 vector = this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition;
			vector.Set(655f, -49.5f);
			this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition = vector;
			vector.Set(160f, 77f);
			this.FilterItem[ItemArrayIndex].BuyTrans.sizeDelta = vector;
			this.FilterItem[ItemArrayIndex].BuyCrystalTrans.gameObject.SetActive(true);
			this.FilterItem[ItemArrayIndex].BuyPrice.enabled = true;
			this.FilterItem[ItemArrayIndex].BuyCaption.text = DataManager.Instance.mStringTable.GetStringByID(4516u);
			this.FilterItem[ItemArrayIndex].BuyBtn.m_BtnID1 = 1004;
			vector.Set(79f, -56.1f);
			this.FilterItem[ItemArrayIndex].BuyCaptionTrans.anchoredPosition = vector;
			vector = this.FilterItem[ItemArrayIndex].BuyCaptionTrans.sizeDelta;
			vector.Set(160f, 32f);
			this.FilterItem[ItemArrayIndex].BuyCaptionTrans.sizeDelta = vector;
			this.FilterItem[ItemArrayIndex].AutouseBtnTrans.gameObject.SetActive(false);
			if (this.FilterItem[ItemArrayIndex].Lock.gameObject.activeSelf)
			{
				this.FilterItem[ItemArrayIndex].Lock.gameObject.SetActive(false);
			}
			break;
		}
		case UIFilterBase.eItemType.PetTraining:
		{
			this.FilterItem[ItemArrayIndex].ItemTrans.gameObject.SetActive(false);
			this.FilterItem[ItemArrayIndex].OtherImgRect.gameObject.SetActive(true);
			this.FilterItem[ItemArrayIndex].recttransform.sizeDelta = new Vector2(776f, 128f);
			this.FilterItem[ItemArrayIndex].Content.rectTransform.sizeDelta = new Vector2(420f, 77f);
			this.FilterItem[ItemArrayIndex].BuyImage.sprite = this.FilterSpriteArr.GetSprite(0);
			Vector2 vector = this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition;
			vector.Set(669f, -64.3f);
			this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition = vector;
			vector.Set(131f, 57f);
			this.FilterItem[ItemArrayIndex].BuyTrans.sizeDelta = vector;
			this.FilterItem[ItemArrayIndex].BuyCrystalTrans.gameObject.SetActive(false);
			this.FilterItem[ItemArrayIndex].Name.text = string.Empty;
			this.FilterItem[ItemArrayIndex].Owner.text = string.Empty;
			this.FilterItem[ItemArrayIndex].BuyPrice.enabled = false;
			this.FilterItem[ItemArrayIndex].BuyCaption.text = DataManager.Instance.mStringTable.GetStringByID(156u);
			this.FilterItem[ItemArrayIndex].BuyBtn.m_BtnID1 = 1005;
			this.FilterItem[ItemArrayIndex].BuyBtn.m_BtnID2 = 23;
			vector.Set(65.5f, -28.5f);
			this.FilterItem[ItemArrayIndex].BuyCaptionTrans.anchoredPosition = vector;
			vector.Set(131f, 57f);
			this.FilterItem[ItemArrayIndex].BuyCaptionTrans.sizeDelta = vector;
			this.FilterItem[ItemArrayIndex].AutouseBtnTrans.gameObject.SetActive(false);
			if (this.FilterItem[ItemArrayIndex].Lock.gameObject.activeSelf)
			{
				this.FilterItem[ItemArrayIndex].Lock.gameObject.SetActive(false);
			}
			this.FilterItem[ItemArrayIndex].OtherImg.sprite = GUIManager.Instance.BuildingData.GetBuildSprite(23, 25);
			this.FilterItem[ItemArrayIndex].OtherImg.material = GUIManager.Instance.MapSpriteUIMaterial;
			this.FilterItem[ItemArrayIndex].OtherImg.SetNativeSize();
			this.FilterItem[ItemArrayIndex].OtherImgRect.localScale = new Vector3(0.54f, 0.54f, 0.54f);
			this.FilterItem[ItemArrayIndex].OtherImgRect.anchoredPosition = new Vector2(-298f, -1.4f);
			this.FilterItem[ItemArrayIndex].Content.text = DataManager.Instance.mStringTable.GetStringByID(16092u);
			break;
		}
		case UIFilterBase.eItemType.Grain:
		case UIFilterBase.eItemType.Rock:
		case UIFilterBase.eItemType.Wood:
		case UIFilterBase.eItemType.Iron:
		case UIFilterBase.eItemType.Gold:
		{
			this.FilterItem[ItemArrayIndex].ItemTrans.gameObject.SetActive(false);
			this.FilterItem[ItemArrayIndex].OtherImgRect.gameObject.SetActive(true);
			this.FilterItem[ItemArrayIndex].BuyImage.sprite = this.FilterSpriteArr.GetSprite(0);
			this.FilterItem[ItemArrayIndex].recttransform.sizeDelta = new Vector2(776f, 109f);
			this.FilterItem[ItemArrayIndex].Content.rectTransform.sizeDelta = new Vector2(420f, 66f);
			Vector2 vector = this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition;
			vector.Set(667.5f, -51.5f);
			this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition = vector;
			vector.Set(109f, 47f);
			this.FilterItem[ItemArrayIndex].BuyTrans.sizeDelta = vector;
			this.FilterItem[ItemArrayIndex].BuyCrystalTrans.gameObject.SetActive(false);
			this.FilterItem[ItemArrayIndex].Name.text = string.Empty;
			this.FilterItem[ItemArrayIndex].Owner.text = string.Empty;
			this.FilterItem[ItemArrayIndex].BuyPrice.enabled = false;
			this.FilterItem[ItemArrayIndex].BuyCaption.text = DataManager.Instance.mStringTable.GetStringByID(156u);
			this.FilterItem[ItemArrayIndex].BuyBtn.m_BtnID1 = 1005;
			vector.Set(54.5f, -24f);
			this.FilterItem[ItemArrayIndex].BuyCaptionTrans.anchoredPosition = vector;
			vector.Set(109f, 47f);
			this.FilterItem[ItemArrayIndex].BuyCaptionTrans.sizeDelta = vector;
			this.FilterItem[ItemArrayIndex].AutouseBtnTrans.gameObject.SetActive(false);
			if (this.FilterItem[ItemArrayIndex].Lock.gameObject.activeSelf)
			{
				this.FilterItem[ItemArrayIndex].Lock.gameObject.SetActive(false);
			}
			int num = UseType - UIFilterBase.eItemType.Grain;
			this.FilterItem[ItemArrayIndex].OtherImg.sprite = this.ResourceSpriteArr.GetSprite(num);
			this.FilterItem[ItemArrayIndex].OtherImg.material = this.ResourceMat;
			this.FilterItem[ItemArrayIndex].OtherImg.SetNativeSize();
			if (GUIManager.Instance.IsArabic)
			{
				this.FilterItem[ItemArrayIndex].OtherImgRect.localScale = new Vector3(-1f, 1f, 1f);
			}
			else
			{
				this.FilterItem[ItemArrayIndex].OtherImgRect.localScale = Vector3.one;
			}
			this.FilterItem[ItemArrayIndex].OtherImgRect.anchoredPosition = new Vector2(-305.5f, 0f);
			this.FilterItem[ItemArrayIndex].Name.text = string.Empty;
			this.FilterItem[ItemArrayIndex].Content.text = DataManager.Instance.mStringTable.GetStringByID((uint)(14596 + num));
			break;
		}
		}
	}

	// Token: 0x06002B58 RID: 11096 RVA: 0x0047B7FC File Offset: 0x004799FC
	public override void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 1001:
			if (BattleController.IsGambleMode)
			{
				GamblingManager.Instance.CloseMenu(false);
			}
			else
			{
				if (DataManager.Instance.OpenBagFilterByBuildingWindow == 2)
				{
					DataManager.Instance.OpenBagFilterByBuildingWindow = 1;
				}
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door != null)
				{
					door.CloseMenu(false);
				}
			}
			break;
		case 1002:
		case 1004:
			if (DataManager.Instance.OpenBagFilterByBuildingWindow == 2)
			{
				DataManager.Instance.OpenBagFilterByBuildingWindow = 1;
			}
			this.SendPack(sender);
			break;
		case 1003:
		{
			int btnID = sender.m_BtnID2;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 3, (int)this.FilterItem[btnID].KeyID);
			break;
		}
		case 1005:
			this.SendPack(sender);
			break;
		case 1006:
			this.SortType = ((this.SortType += 1) & 1);
			this.SortSpriteArray.SetSpriteIndex((int)this.SortType);
			PlayerPrefs.SetString("SpeedUp_Sort", this.SortType.ToString());
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14707u + (uint)this.SortType), 255, true);
			this.SendPack(sender);
			break;
		}
	}

	// Token: 0x06002B59 RID: 11097 RVA: 0x0047B96C File Offset: 0x00479B6C
	public virtual void SendPack(UIButton sender)
	{
	}

	// Token: 0x06002B5A RID: 11098 RVA: 0x0047B970 File Offset: 0x00479B70
	public virtual void CheckBuy(byte Type, ushort Key, ushort ItemID, bool BuyAndUse = false, GUIWindow win = null, int arg1 = 0, int arg2 = 0, uint Parameter3 = 0u)
	{
		if (GUIManager.Instance.OpenCheckCrystal(DataManager.Instance.StoreData.GetRecordByKey(Key).Price, 1, 65537, -1))
		{
			this.SendItemData.Type = Type;
			this.SendItemData.Key = Key;
			this.SendItemData.ItemID = ItemID;
			this.SendItemData.BuyAndUse = BuyAndUse;
			this.SendItemData.win = win;
			this.SendItemData.arg1 = arg1;
			this.SendItemData.arg2 = arg2;
			this.SendItemData.arg3 = Parameter3;
		}
		else
		{
			DataManager.Instance.sendBuyItem(Type, Key, ItemID, BuyAndUse, win, arg1, arg2, Parameter3, string.Empty, true, 1);
		}
	}

	// Token: 0x06002B5B RID: 11099 RVA: 0x0047BA34 File Offset: 0x00479C34
	public override void UpdateNetwork(byte[] meg)
	{
		if (this.PassInit > 0)
		{
			this.Init();
			this.PassInit = 0;
		}
		if (meg[0] == 35)
		{
			for (int i = 0; i < this.FilterItem.Length; i++)
			{
				if (this.FilterItem[i].ItemBtn == null)
				{
					break;
				}
				if (this.FilterItem[i].ItemBtn.gameObject.activeSelf)
				{
					this.FilterItem[i].ItemBtn.Refresh_FontTexture();
				}
			}
		}
		base.UpdateNetwork(meg);
	}

	// Token: 0x06002B5C RID: 11100 RVA: 0x0047BADC File Offset: 0x00479CDC
	public override void UpdateUI(int arge1, int arge2)
	{
		if (arge1 == 65537)
		{
			DataManager.Instance.sendBuyItem(this.SendItemData.Type, this.SendItemData.Key, this.SendItemData.ItemID, this.SendItemData.BuyAndUse, this.SendItemData.win, this.SendItemData.arg1, this.SendItemData.arg2, this.SendItemData.arg3, string.Empty, true, 1);
		}
	}

	// Token: 0x06002B5D RID: 11101 RVA: 0x0047BB60 File Offset: 0x00479D60
	public override void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.FilterItem[panelObjectIdx].ItemTrans == null)
		{
			this.FilterItem[panelObjectIdx].recttransform = (item.transform as RectTransform);
			this.FilterItem[panelObjectIdx].BkImage = item.GetComponent<Image>();
			this.FilterItem[panelObjectIdx].ItemTrans = item.transform.GetChild(0).GetComponent<RectTransform>();
			this.FilterItem[panelObjectIdx].OtherImgRect = item.transform.GetChild(1).GetComponent<RectTransform>();
			this.FilterItem[panelObjectIdx].OtherImg = this.FilterItem[panelObjectIdx].OtherImgRect.GetComponent<Image>();
			base.AddRefreshText(this.FilterItem[panelObjectIdx].ItemTrans.GetChild(5).GetComponent<UIText>());
			this.FilterItem[panelObjectIdx].ItemBtn = this.FilterItem[panelObjectIdx].ItemTrans.GetComponent<UIHIBtn>();
			this.FilterItem[panelObjectIdx].ItemBtn.m_Handler = this;
			this.FilterItem[panelObjectIdx].InfoTrans = this.FilterItem[panelObjectIdx].ItemTrans.GetChild(0);
			this.FilterItem[panelObjectIdx].InfoTrans.SetAsLastSibling();
			this.FilterItem[panelObjectIdx].Owner = item.transform.GetChild(2).GetComponent<UIText>();
			this.FilterItem[panelObjectIdx].Name = item.transform.GetChild(4).GetComponent<UIText>();
			this.FilterItem[panelObjectIdx].Content = item.transform.GetChild(5).GetComponent<UIText>();
			base.AddRefreshText(this.FilterItem[panelObjectIdx].Owner);
			base.AddRefreshText(this.FilterItem[panelObjectIdx].Name);
			base.AddRefreshText(this.FilterItem[panelObjectIdx].Content);
			this.FilterItem[panelObjectIdx].BuyTrans = item.transform.GetChild(3).GetComponent<RectTransform>();
			this.FilterItem[panelObjectIdx].BuyBtn = item.transform.GetChild(3).GetComponent<UIButton>();
			this.FilterItem[panelObjectIdx].BuyBtn.m_Handler = this;
			this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID2 = panelObjectIdx;
			this.FilterItem[panelObjectIdx].BuyImage = item.transform.GetChild(3).GetComponent<Image>();
			this.FilterItem[panelObjectIdx].PriceImg = item.transform.GetChild(3).GetChild(0).GetComponent<Image>();
			this.FilterItem[panelObjectIdx].BuyCrystalTrans = item.transform.GetChild(3).GetChild(0).GetComponent<RectTransform>();
			this.FilterItem[panelObjectIdx].BuyPrice = item.transform.GetChild(3).GetChild(1).GetComponent<UIText>();
			base.AddRefreshText(this.FilterItem[panelObjectIdx].BuyPrice);
			this.FilterItem[panelObjectIdx].BuyCaptionTrans = item.transform.GetChild(3).GetChild(2).GetComponent<RectTransform>();
			this.FilterItem[panelObjectIdx].BuyCaption = item.transform.GetChild(3).GetChild(2).GetComponent<UIText>();
			base.AddRefreshText(this.FilterItem[panelObjectIdx].BuyCaption);
			this.FilterItem[panelObjectIdx].Lock = item.transform.GetChild(3).GetChild(3).GetComponent<Image>();
			this.FilterItem[panelObjectIdx].OwnerStr = StringManager.Instance.SpawnString(30);
			this.FilterItem[panelObjectIdx].BuyPriceStr = StringManager.Instance.SpawnString(30);
			this.FilterItem[panelObjectIdx].NameStr = StringManager.Instance.SpawnString(100);
			UIText component = item.transform.GetChild(6).GetChild(0).GetComponent<UIText>();
			base.AddRefreshText(component);
			component.text = DataManager.Instance.mStringTable.GetStringByID(282u);
			this.FilterItem[panelObjectIdx].AutouseBtnTrans = item.transform.GetChild(6).GetComponent<RectTransform>();
			UIButton component2 = this.FilterItem[panelObjectIdx].AutouseBtnTrans.GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.m_BtnID1 = 1003;
			component2.m_BtnID2 = panelObjectIdx;
		}
	}

	// Token: 0x06002B5E RID: 11102 RVA: 0x0047C004 File Offset: 0x0047A204
	public override void OnClose()
	{
		base.OnClose();
		if (this.FilterItem != null)
		{
			for (int i = 0; i < this.FilterItem.Length; i++)
			{
				StringManager.Instance.DeSpawnString(this.FilterItem[i].OwnerStr);
				StringManager.Instance.DeSpawnString(this.FilterItem[i].BuyPriceStr);
				StringManager.Instance.DeSpawnString(this.FilterItem[i].NameStr);
			}
		}
		if (DataManager.Instance.OpenBagFilterByBuildingWindow == 2)
		{
			DataManager.Instance.OpenBagFilterByBuildingWindow = 0;
		}
	}

	// Token: 0x06002B5F RID: 11103 RVA: 0x0047C0AC File Offset: 0x0047A2AC
	public override void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06002B60 RID: 11104 RVA: 0x0047C0B0 File Offset: 0x0047A2B0
	public virtual void SetItemData(ushort[] ItemData, ushort Start, ushort Count, bool Replace = false, byte sort = 0, int sortbeginIdx = 0)
	{
		if (Replace)
		{
			this.ItemsHeight.Clear();
			this.ItemsData.Clear();
		}
		for (ushort num = Start; num != Start + Count; num += 1)
		{
			if (this.CheckItemRule(ItemData[(int)num]))
			{
				this.ItemsHeight.Add(128f);
				if (sort == 0)
				{
					this.ItemsData.Add(ItemData[(int)num]);
				}
				else
				{
					this.ItemsData.Insert(sortbeginIdx, ItemData[(int)num]);
				}
			}
		}
	}

	// Token: 0x06002B61 RID: 11105 RVA: 0x0047C138 File Offset: 0x0047A338
	public virtual void SetItemData(PetItem[] ItemData, ushort Start, ushort Count, bool Replace = false)
	{
		if (Replace)
		{
			this.ItemsHeight.Clear();
			this.ItemsData.Clear();
		}
		PetManager instance = PetManager.Instance;
		for (ushort num = Start; num != Start + Count; num += 1)
		{
			ushort num2 = instance.sortPetItemData[(int)num];
			if (ItemData[(int)num2] != null)
			{
				if (this.CheckItemRule(ItemData[(int)num2].ItemID))
				{
					this.ItemsHeight.Add(128f);
					this.ItemsData.Add(ItemData[(int)num2].ItemID);
				}
			}
		}
	}

	// Token: 0x06002B62 RID: 11106 RVA: 0x0047C1CC File Offset: 0x0047A3CC
	public virtual bool CheckItemRule(ushort id)
	{
		return true;
	}

	// Token: 0x06002B63 RID: 11107 RVA: 0x0047C1D0 File Offset: 0x0047A3D0
	public void UpdateScrollItemsCount()
	{
		if (!this.FilterScrollView.gameObject.activeSelf)
		{
			return;
		}
		this.FilterScrollView.AddNewDataHeight(this.ItemsHeight, true, true);
		if (this.ItemsHeight.Count == 0)
		{
			this.MessageTrans.gameObject.SetActive(true);
		}
		else
		{
			this.MessageTrans.gameObject.SetActive(false);
		}
	}

	// Token: 0x06002B64 RID: 11108 RVA: 0x0047C240 File Offset: 0x0047A440
	public override void Update()
	{
		if (this.PassInit > 0)
		{
			this.PassInit -= 1;
			if (this.PassInit == 0)
			{
				this.Init();
			}
		}
	}

	// Token: 0x040077AA RID: 30634
	protected ScrollPanel FilterScrollView;

	// Token: 0x040077AB RID: 30635
	protected CScrollRect FilterScrollRect;

	// Token: 0x040077AC RID: 30636
	protected RectTransform ScrollContent;

	// Token: 0x040077AD RID: 30637
	protected List<float> ItemsHeight = new List<float>();

	// Token: 0x040077AE RID: 30638
	protected List<ushort> ItemsData = new List<ushort>();

	// Token: 0x040077AF RID: 30639
	protected UISpritesArray FilterSpriteArr;

	// Token: 0x040077B0 RID: 30640
	protected UISpritesArray ResourceSpriteArr;

	// Token: 0x040077B1 RID: 30641
	protected Material ResourceMat;

	// Token: 0x040077B2 RID: 30642
	protected string OwnerStr;

	// Token: 0x040077B3 RID: 30643
	protected Image Crystal;

	// Token: 0x040077B4 RID: 30644
	protected Material BagMaterial;

	// Token: 0x040077B5 RID: 30645
	protected RectTransform MessageTrans;

	// Token: 0x040077B6 RID: 30646
	protected int ScrollItemCount = 5;

	// Token: 0x040077B7 RID: 30647
	protected GameObject SortObj;

	// Token: 0x040077B8 RID: 30648
	protected byte SortType;

	// Token: 0x040077B9 RID: 30649
	protected UISpritesArray SortSpriteArray;

	// Token: 0x040077BA RID: 30650
	protected UIFilterBase.ItemEdit[] FilterItem;

	// Token: 0x040077BB RID: 30651
	public UIText MainText;

	// Token: 0x040077BC RID: 30652
	protected UIFilterBase._SendItemData SendItemData;

	// Token: 0x040077BD RID: 30653
	protected byte PassInit = 2;

	// Token: 0x02000829 RID: 2089
	protected enum eItemType
	{
		// Token: 0x040077BF RID: 30655
		Use,
		// Token: 0x040077C0 RID: 30656
		BuyAndUse,
		// Token: 0x040077C1 RID: 30657
		PetTraining,
		// Token: 0x040077C2 RID: 30658
		Grain,
		// Token: 0x040077C3 RID: 30659
		Rock,
		// Token: 0x040077C4 RID: 30660
		Wood,
		// Token: 0x040077C5 RID: 30661
		Iron,
		// Token: 0x040077C6 RID: 30662
		Gold
	}

	// Token: 0x0200082A RID: 2090
	protected struct ItemEdit
	{
		// Token: 0x040077C7 RID: 30663
		public ushort KeyID;

		// Token: 0x040077C8 RID: 30664
		public Transform ItemTrans;

		// Token: 0x040077C9 RID: 30665
		public Transform InfoTrans;

		// Token: 0x040077CA RID: 30666
		public UIHIBtn ItemBtn;

		// Token: 0x040077CB RID: 30667
		public UIText Owner;

		// Token: 0x040077CC RID: 30668
		public UIText Name;

		// Token: 0x040077CD RID: 30669
		public UIText Content;

		// Token: 0x040077CE RID: 30670
		public Image BkImage;

		// Token: 0x040077CF RID: 30671
		public Image BuyImage;

		// Token: 0x040077D0 RID: 30672
		public Image PriceImg;

		// Token: 0x040077D1 RID: 30673
		public Image OtherImg;

		// Token: 0x040077D2 RID: 30674
		public RectTransform BuyCrystalTrans;

		// Token: 0x040077D3 RID: 30675
		public RectTransform OtherImgRect;

		// Token: 0x040077D4 RID: 30676
		public RectTransform recttransform;

		// Token: 0x040077D5 RID: 30677
		public UIButton BuyBtn;

		// Token: 0x040077D6 RID: 30678
		public RectTransform BuyTrans;

		// Token: 0x040077D7 RID: 30679
		public RectTransform BuyCaptionTrans;

		// Token: 0x040077D8 RID: 30680
		public UIText BuyCaption;

		// Token: 0x040077D9 RID: 30681
		public UIText BuyPrice;

		// Token: 0x040077DA RID: 30682
		public Image Lock;

		// Token: 0x040077DB RID: 30683
		public RectTransform AutouseBtnTrans;

		// Token: 0x040077DC RID: 30684
		public CString NameStr;

		// Token: 0x040077DD RID: 30685
		public CString OwnerStr;

		// Token: 0x040077DE RID: 30686
		public CString BuyPriceStr;
	}

	// Token: 0x0200082B RID: 2091
	protected struct _SendItemData
	{
		// Token: 0x040077DF RID: 30687
		public byte Type;

		// Token: 0x040077E0 RID: 30688
		public byte Check;

		// Token: 0x040077E1 RID: 30689
		public ushort Key;

		// Token: 0x040077E2 RID: 30690
		public ushort ItemID;

		// Token: 0x040077E3 RID: 30691
		public bool BuyAndUse;

		// Token: 0x040077E4 RID: 30692
		public GUIWindow win;

		// Token: 0x040077E5 RID: 30693
		public int arg1;

		// Token: 0x040077E6 RID: 30694
		public int arg2;

		// Token: 0x040077E7 RID: 30695
		public uint arg3;
	}

	// Token: 0x0200082C RID: 2092
	protected enum FilterBaseClickType
	{
		// Token: 0x040077E9 RID: 30697
		Exit = 1001,
		// Token: 0x040077EA RID: 30698
		Use,
		// Token: 0x040077EB RID: 30699
		AutoUse,
		// Token: 0x040077EC RID: 30700
		Buy,
		// Token: 0x040077ED RID: 30701
		Goto,
		// Token: 0x040077EE RID: 30702
		Sort
	}

	// Token: 0x0200082D RID: 2093
	protected enum UIControl
	{
		// Token: 0x040077F0 RID: 30704
		Background,
		// Token: 0x040077F1 RID: 30705
		Func,
		// Token: 0x040077F2 RID: 30706
		Message,
		// Token: 0x040077F3 RID: 30707
		ScrollContent,
		// Token: 0x040077F4 RID: 30708
		Close,
		// Token: 0x040077F5 RID: 30709
		FilterItem,
		// Token: 0x040077F6 RID: 30710
		SpriteArray,
		// Token: 0x040077F7 RID: 30711
		Sort
	}

	// Token: 0x0200082E RID: 2094
	protected enum FilterItemControl
	{
		// Token: 0x040077F9 RID: 30713
		ObjPic,
		// Token: 0x040077FA RID: 30714
		OtherPic,
		// Token: 0x040077FB RID: 30715
		Owner,
		// Token: 0x040077FC RID: 30716
		Buy,
		// Token: 0x040077FD RID: 30717
		Name,
		// Token: 0x040077FE RID: 30718
		Content,
		// Token: 0x040077FF RID: 30719
		AutoUse
	}
}
