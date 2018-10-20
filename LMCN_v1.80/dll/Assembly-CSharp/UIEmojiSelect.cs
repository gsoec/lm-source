using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000549 RID: 1353
public class UIEmojiSelect : GUIWindow, UILoadImageHander, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001ADF RID: 6879 RVA: 0x002D92A8 File Offset: 0x002D74A8
	public override void OnOpen(int arg1, int arg2)
	{
		this.m_transform = base.transform;
		Font ttffont = this.GM.GetTTFFont();
		this.m_transform.GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(0).GetChild(1).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(0).GetChild(2).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(0).GetChild(4).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(0).GetChild(4).GetComponent<UIButton>().m_BtnID1 = 7;
		this.m_transform.GetChild(0).GetChild(8).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(0).GetChild(8).GetComponent<UIButton>().m_BtnID1 = 8;
		Transform child = this.m_transform.GetChild(0).GetChild(0);
		for (int i = 0; i < 8; i++)
		{
			child.GetChild(i).GetComponent<UIButton>().m_Handler = this;
			child.GetChild(i).GetComponent<CustomImage>().hander = this;
			this.PicRT[i] = child.GetChild(i).GetComponent<RectTransform>();
			if (this.GM.IsArabic)
			{
				this.PicRT[i].localScale = new Vector3(-1f, 1f, 1f);
			}
		}
		this.SelectRT = child.GetChild(8).GetComponent<RectTransform>();
		child.GetChild(8).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetComponent<CustomImage>().hander = this;
		child = this.m_transform.GetChild(0);
		child.GetComponent<CustomImage>().hander = this;
		child.GetChild(1).GetComponent<CustomImage>().hander = this;
		child.GetChild(1).GetChild(2).GetComponent<CustomImage>().hander = this;
		child.GetChild(2).GetComponent<CustomImage>().hander = this;
		child.GetChild(3).GetChild(1).GetComponent<CustomImage>().hander = this;
		child.GetChild(4).GetComponent<CustomImage>().hander = this;
		child.GetChild(4).GetChild(2).GetComponent<CustomImage>().hander = this;
		child.GetChild(5).GetComponent<CustomImage>().hander = this;
		child.GetChild(6).GetComponent<CustomImage>().hander = this;
		child = this.m_transform.GetChild(1);
		child.GetComponent<CustomImage>().hander = this;
		child.GetChild(2).GetComponent<CustomImage>().hander = this;
		this.PointImg[0] = child.GetChild(3).GetComponent<Image>();
		this.PointImg[1] = child.GetChild(4).GetComponent<Image>();
		this.PointImg[2] = child.GetChild(5).GetComponent<Image>();
		this.MoveBtnGO = this.m_transform.GetChild(0).GetChild(8).gameObject;
		this.MoveBtnGO.transform.GetComponent<CustomImage>().hander = this;
		this.MoveBtnGO.transform.GetChild(0).GetComponent<CustomImage>().hander = this;
		this.MoveBtnGO.transform.GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.MoveBtnGO.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			((RectTransform)this.m_transform).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0f);
			((RectTransform)this.m_transform).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0f);
		}
		this.OpenType = (byte)arg1;
		this.GM.EmojiOpenType = this.OpenType;
		child = this.m_transform.GetChild(0);
		if (this.OpenType == 2)
		{
			RectTransform component = child.GetChild(2).GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(0f, component.anchoredPosition.y);
			component.sizeDelta = new Vector2(146f, 77f);
		}
		child = this.m_transform.GetChild(0).GetChild(4);
		this.BuyBtn = child.gameObject;
		if (this.bThirdParty)
		{
			child.GetChild(0).gameObject.SetActive(false);
			child.GetChild(2).gameObject.SetActive(true);
			child.GetChild(3).gameObject.SetActive(true);
			this.PriceText = child.GetChild(3).GetComponent<Text>();
			this.PriceText.font = ttffont;
		}
		else
		{
			this.PriceText = child.GetChild(0).GetComponent<Text>();
			this.PriceText.font = ttffont;
		}
		if (this.GM.IsArabic)
		{
			this.PriceText.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		UIText component2 = child.GetChild(1).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = this.DM.mStringTable.GetStringByID(284u);
		if (this.GM.IsArabic)
		{
			component2.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		this.RBText[(int)this.RBTextIndex] = component2;
		this.RBTextIndex += 1;
		this.GiftItem = this.m_transform.GetChild(1).gameObject;
		this.GiftBtn = this.m_transform.GetChild(1).GetChild(1).GetComponent<UIHIBtn>();
		this.GiftBtn.gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UIHIBtn;
		this.GM.InitianHeroItemImg(this.GiftBtn.transform, eHeroOrItem.Item, this.ItemID, 0, 0, 0, false, false, true, false);
		child = this.m_transform.GetChild(1);
		component2 = child.GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = this.DM.mStringTable.GetStringByID(12069u);
		this.RBText[(int)this.RBTextIndex] = component2;
		this.RBTextIndex += 1;
		this.UseBtn = this.m_transform.GetChild(0).GetChild(2).gameObject;
		component2 = this.m_transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = this.DM.mStringTable.GetStringByID(94u);
		this.RBText[(int)this.RBTextIndex] = component2;
		this.RBTextIndex += 1;
		this.SpendBtn = this.m_transform.GetChild(0).GetChild(1).gameObject;
		child = this.m_transform.GetChild(0).GetChild(1);
		component2 = child.GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = this.DM.mStringTable.GetStringByID(4062u);
		this.RBText[(int)this.RBTextIndex] = component2;
		this.RBTextIndex += 1;
		ushort inKey = this.DM.TotalShopItemData.Find(this.ItemID);
		this.price = this.DM.StoreData.GetRecordByKey(inKey).Price;
		this.m_OKString = this.SM.SpawnString(30);
		this.m_OKString.IntToFormat((long)((ulong)this.price), 1, true);
		this.m_OKString.AppendFormat("{0}");
		component2 = child.GetChild(1).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = this.m_OKString.ToString();
		this.RBText[(int)this.RBTextIndex] = component2;
		this.RBTextIndex += 1;
		this.ItemInfoObj = this.m_transform.GetChild(0).GetChild(3).gameObject;
		Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.ItemID);
		child = this.m_transform.GetChild(0).GetChild(3);
		component2 = child.GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.EquipName);
		this.RBText[(int)this.RBTextIndex] = component2;
		this.RBTextIndex += 1;
		this.ItemCountText = child.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.ItemCountText.font = ttffont;
		child.GetChild(2).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UIHIBtn;
		this.GM.InitianHeroItemImg(child.GetChild(2), eHeroOrItem.Item, this.ItemID, 0, 0, 0, false, false, true, false);
		child = this.m_transform.GetChild(0);
		this.GM.SortEmojiData();
		this.Scroll = child.GetChild(6).GetComponent<ScrollPanel_Horizontal>();
		this.UnitObjectT = child.GetChild(7);
		for (int j = 0; j < 8; j++)
		{
			this.bFindScrollComp[j] = false;
		}
		this.EmojiCount = this.GM.EmojiIndex.Count + 1;
		this.NowHeightList.Clear();
		for (int k = 0; k < this.EmojiCount; k++)
		{
			if (k == 0)
			{
				this.NowHeightList.Add(88f);
			}
			else
			{
				this.NowHeightList.Add(82f);
			}
		}
		this.Scroll.IntiScrollPanel(462f, 1f, 0f, this.NowHeightList, 8, this);
		this.cScrollRect = this.Scroll.GetComponent<CScrollRect>();
		UIButtonHint.scrollRect = this.cScrollRect;
		if (this.GM.EmojiIndex.Count > 4)
		{
			this.bNeedCheckMove = true;
		}
		this.NoKeyText = this.m_transform.GetChild(2).GetComponent<UIText>();
		this.NoKeyText.font = ttffont;
		this.NoKeyText.text = this.DM.mStringTable.GetStringByID(12071u);
		this.m_transform.GetChild(2).gameObject.SetActive(true);
		this.NoKeyText.enabled = false;
		this.SetIndex(this.GM.EmojiNowPackageIndex, true);
		if (this.GM.EmojiNowScrollIndex != -1)
		{
			this.Scroll.GoTo(this.GM.EmojiNowScrollIndex, this.GM.EmojiNowContentPos);
		}
	}

	// Token: 0x06001AE0 RID: 6880 RVA: 0x002D9D54 File Offset: 0x002D7F54
	public override void OnClose()
	{
		this.SM.DeSpawnString(this.m_OKString);
		this.SM.DeSpawnString(this.m_OKString_ItemCount);
		this.SM.DeSpawnString(this.PriceStr);
		int num = 0;
		while (num < (int)this.ECount && num < this.EUnit.Length)
		{
			if (this.EUnit[num] != null)
			{
				this.GM.pushEmojiIcon(this.EUnit[num]);
				this.EUnit[num] = null;
			}
			num++;
		}
		for (int i = 0; i < 8; i++)
		{
			if (this.Scroll_Comp[i].EUnit != null)
			{
				this.Scroll_Comp[i].EUnit.EmojiImage.color = Color.white;
				this.GM.pushEmojiIcon(this.Scroll_Comp[i].EUnit);
				this.Scroll_Comp[i].EUnit = null;
			}
		}
		this.GM.CloseCheckCrystalBox();
		this.GM.EmojiNowScrollIndex = this.Scroll.GetTopIdx();
		this.GM.EmojiNowContentPos = this.cScrollRect.content.anchoredPosition.x;
		if (this.GM.EmojiNowScrollIndex == -1 && this.EmojiCount > 0)
		{
			this.GM.EmojiNowScrollIndex = 0;
			this.GM.EmojiNowContentPos = 0f;
		}
	}

	// Token: 0x06001AE1 RID: 6881 RVA: 0x002D9ED8 File Offset: 0x002D80D8
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001AE2 RID: 6882 RVA: 0x002D9EDC File Offset: 0x002D80DC
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			this.GM.CloseMenu(EGUIWindow.UIEmojiSelect);
		}
		else if (sender.m_BtnID1 == 2)
		{
			this.SendPackage();
		}
		else if (sender.m_BtnID1 == 3)
		{
			if (this.DM.RoleAttr.Diamond >= this.price)
			{
				if (!GUIManager.Instance.OpenCheckCrystal(this.price, 9, -1, -1))
				{
					this.SendPackage();
				}
			}
			else
			{
				this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966u), this.DM.mStringTable.GetStringByID(646u), this.DM.mStringTable.GetStringByID(3968u), this, 1, 0, true, false, false, false, false);
			}
		}
		else if (sender.m_BtnID1 == 4)
		{
			this.GM.EmojiNowPicIndex = (ushort)(sender.m_BtnID2 - 1);
			this.SetSelect();
		}
		else if (sender.m_BtnID1 == 5)
		{
			this.SetIndex(ushort.MaxValue, false);
		}
		else if (sender.m_BtnID1 == 6)
		{
			this.SetIndex((ushort)sender.m_BtnID2, false);
		}
		else if (sender.m_BtnID1 == 7)
		{
			if (MallManager.Instance.CheckbWaitBuy_Emoji(true))
			{
				return;
			}
			Emote recordByKey = DataManager.MapDataController.EmoteTable.GetRecordByKey(this.GM.EmojiNowPackageIndex + 1);
			MallManager.Instance.SendCheckEmojiID = this.GM.EmojiNowPackageIndex + 1;
			MallManager.Instance.Send_SPTREASURE_PREBUY_CHECK(ESpcialTreasureType.ESTST_Emote, recordByKey.ProductID, true);
		}
		else if (sender.m_BtnID1 == 8 && this.FindMoveIndex != -1)
		{
			this.Scroll.GoTo(this.FindMoveIndex);
			this.CheckShowMoveBtn();
		}
	}

	// Token: 0x06001AE3 RID: 6883 RVA: 0x002DA0C4 File Offset: 0x002D82C4
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK && arg1 == 1)
		{
			MallManager.Instance.Send_Mall_Info();
			this.GM.CloseMenu(EGUIWindow.UIEmojiSelect);
		}
	}

	// Token: 0x06001AE4 RID: 6884 RVA: 0x002DA0F0 File Offset: 0x002D82F0
	public void SetIndex(ushort SelectIndex, bool OpenForce = false)
	{
		bool flag = this.GM.EmojiNowPackageIndex == SelectIndex;
		this.GM.EmojiNowPackageIndex = SelectIndex;
		if (!flag || OpenForce)
		{
			int num = 0;
			while (num < (int)this.ECount && num < this.EUnit.Length)
			{
				if (this.EUnit[num] != null)
				{
					this.GM.pushEmojiIcon(this.EUnit[num]);
					this.EUnit[num] = null;
				}
				num++;
			}
			this.ECount = this.GM.GetMapEmojiCount(SelectIndex);
			int num2 = 0;
			while (num2 < (int)this.ECount && num2 < this.PicRT.Length)
			{
				EmojiData recordByKey = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(this.GetEmojiKey(SelectIndex, num2));
				this.EUnit[num2] = this.GM.pullEmojiIcon(recordByKey.IconID, recordByKey.KeyFrame, false);
				this.EUnit[num2].EmojiTransform.SetParent(this.PicRT[num2], false);
				((RectTransform)this.EUnit[num2].EmojiTransform).anchoredPosition = Vector2.zero;
				num2++;
			}
			if (!OpenForce)
			{
				this.GM.EmojiNowPicIndex = 0;
			}
			this.SetSelect();
			this.DM.SetEmojiSave(SelectIndex + 1);
			for (int i = 0; i < 8; i++)
			{
				if (this.bFindScrollComp[i])
				{
					this.Scroll_Comp[i].SelectImage1.enabled = false;
					this.Scroll_Comp[i].SelectImage2.enabled = false;
					if (this.Scroll_Comp[i].Btn2.m_BtnID2 == (int)SelectIndex)
					{
						if (SelectIndex == 65535)
						{
							this.Scroll_Comp[i].SelectImage1.enabled = true;
						}
						else
						{
							this.Scroll_Comp[i].SelectImage2.enabled = true;
							this.Scroll_Comp[i].FlasfGO.SetActive(false);
						}
					}
				}
			}
		}
		this.SpendBtn.SetActive(false);
		this.ItemInfoObj.SetActive(false);
		this.UseBtn.SetActive(false);
		this.BuyBtn.SetActive(false);
		this.GiftItem.SetActive(false);
		if (SelectIndex == 65535 || this.GM.HasEmotionPck(SelectIndex + 1))
		{
			if (this.OpenType == 1)
			{
				ushort curItemQuantity = this.DM.GetCurItemQuantity(this.ItemID, 0);
				this.ItemInfoObj.SetActive(true);
				this.SetItemCount(curItemQuantity);
				if (curItemQuantity > 0)
				{
					this.UseBtn.SetActive(true);
				}
				else
				{
					this.SpendBtn.SetActive(true);
				}
			}
			else if (this.OpenType == 2)
			{
				this.UseBtn.SetActive(true);
			}
			if (this.GM.EmojiNowPackageIndex == 65535 && this.GM.SaveEmojiKey.Count == 0)
			{
				this.UseBtn.SetActive(false);
				this.SpendBtn.SetActive(false);
				this.ItemInfoObj.SetActive(false);
			}
		}
		else
		{
			this.BuyBtn.SetActive(true);
			this.GiftItem.SetActive(true);
			Emote recordByKey2 = DataManager.MapDataController.EmoteTable.GetRecordByKey(SelectIndex + 1);
			this.SetPrice(recordByKey2.ProductID);
			this.GM.ChangeHeroItemImg(this.GiftBtn.transform, eHeroOrItem.Item, recordByKey2.GiftID, 0, 0, 0);
			this.PointImg[0].enabled = false;
			this.PointImg[1].enabled = false;
			this.PointImg[2].enabled = false;
			if (this.GM.IsArabic)
			{
				if (recordByKey2.GiftCount >= 100)
				{
					this.GM.SetPointTexture(recordByKey2.GiftCount / 100, this.PointImg[2]);
					this.PointImg[2].enabled = true;
					this.GM.SetPointTexture(recordByKey2.GiftCount % 100 / 10, this.PointImg[1]);
					this.PointImg[1].enabled = true;
					this.GM.SetPointTexture(recordByKey2.GiftCount % 10, this.PointImg[0]);
					this.PointImg[0].enabled = true;
				}
				else if (recordByKey2.GiftCount >= 10 && recordByKey2.GiftCount <= 99)
				{
					this.GM.SetPointTexture(recordByKey2.GiftCount / 10, this.PointImg[1]);
					this.PointImg[1].enabled = true;
					this.GM.SetPointTexture(recordByKey2.GiftCount % 10, this.PointImg[0]);
					this.PointImg[0].enabled = true;
				}
				else
				{
					this.GM.SetPointTexture(recordByKey2.GiftCount, this.PointImg[0]);
					this.PointImg[0].enabled = true;
				}
			}
			else if (recordByKey2.GiftCount >= 100)
			{
				this.GM.SetPointTexture(recordByKey2.GiftCount / 100, this.PointImg[0]);
				this.PointImg[0].enabled = true;
				this.GM.SetPointTexture(recordByKey2.GiftCount % 100 / 10, this.PointImg[1]);
				this.PointImg[1].enabled = true;
				this.GM.SetPointTexture(recordByKey2.GiftCount % 10, this.PointImg[2]);
				this.PointImg[2].enabled = true;
			}
			else if (recordByKey2.GiftCount >= 10 && recordByKey2.GiftCount <= 99)
			{
				this.GM.SetPointTexture(recordByKey2.GiftCount / 10, this.PointImg[0]);
				this.PointImg[0].enabled = true;
				this.GM.SetPointTexture(recordByKey2.GiftCount % 10, this.PointImg[1]);
				this.PointImg[1].enabled = true;
			}
			else
			{
				this.GM.SetPointTexture(recordByKey2.GiftCount, this.PointImg[0]);
				this.PointImg[0].enabled = true;
			}
		}
	}

	// Token: 0x06001AE5 RID: 6885 RVA: 0x002DA740 File Offset: 0x002D8940
	public void SetSelect()
	{
		if (this.SelectRT && (int)this.GM.EmojiNowPicIndex < this.PicRT.Length)
		{
			if (this.GM.EmojiNowPackageIndex == 65535)
			{
				if (this.GM.SaveEmojiKey.Count == 0)
				{
					this.SelectRT.gameObject.SetActive(false);
					this.NoKeyText.enabled = true;
					return;
				}
				if ((int)this.GM.EmojiNowPicIndex >= this.GM.SaveEmojiKey.Count)
				{
					this.GM.EmojiNowPicIndex = 0;
				}
			}
			this.SelectRT.gameObject.SetActive(true);
			this.NoKeyText.enabled = false;
			EmojiData recordByKey = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(this.GetEmojiKey(this.GM.EmojiNowPackageIndex, (int)this.GM.EmojiNowPicIndex));
			this.SelectRT.anchoredPosition = this.PicRT[(int)this.GM.EmojiNowPicIndex].anchoredPosition;
			this.SelectRT.sizeDelta = new Vector2(125f, 125f);
		}
	}

	// Token: 0x06001AE6 RID: 6886 RVA: 0x002DA870 File Offset: 0x002D8A70
	public void SetItemCount(ushort Count)
	{
		if (this.ItemCountText == null)
		{
			return;
		}
		if (this.m_OKString_ItemCount == null)
		{
			this.m_OKString_ItemCount = this.SM.SpawnString(30);
		}
		this.m_OKString_ItemCount.Length = 0;
		this.m_OKString_ItemCount.StringToFormat(this.DM.mStringTable.GetStringByID(281u));
		this.m_OKString_ItemCount.IntToFormat((long)Count, 1, true);
		this.m_OKString_ItemCount.AppendFormat("{0}{1}");
		this.ItemCountText.text = this.m_OKString_ItemCount.ToString();
		this.ItemCountText.SetAllDirty();
		this.ItemCountText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001AE7 RID: 6887 RVA: 0x002DA92C File Offset: 0x002D8B2C
	public void SetPrice(uint TreasureID)
	{
		if (this.PriceText == null)
		{
			return;
		}
		if (this.PriceStr == null)
		{
			this.PriceStr = this.SM.SpawnString(30);
		}
		TreasureID = MallManager.Instance.TreasureIDTransToNew(TreasureID);
		this.PriceStr.Length = 0;
		string productPaltformPriceByID = MallManager.Instance.GetProductPaltformPriceByID((int)TreasureID);
		string productPriceByID = MallManager.Instance.GetProductPriceByID((int)TreasureID);
		if (productPaltformPriceByID != null && productPaltformPriceByID != string.Empty)
		{
			this.PriceStr.Append(productPaltformPriceByID);
		}
		else
		{
			if (productPriceByID == null)
			{
				double f = 0.0;
				this.NeedUpDate = true;
				this.PriceStr.DoubleToFormat(f, 2, true);
			}
			else
			{
				this.PriceStr.StringToFormat(productPriceByID);
			}
			string currency = MallManager.Instance.GetCurrency((int)TreasureID);
			if (currency != null)
			{
				this.PriceStr.StringToFormat(currency);
				if (MallManager.Instance.bChangePosCurrency(currency))
				{
					this.PriceStr.AppendFormat("{0} {1}");
				}
				else
				{
					this.PriceStr.AppendFormat("{1} {0}");
				}
			}
			else
			{
				this.PriceStr.AppendFormat("${0}");
			}
		}
		this.PriceText.text = this.PriceStr.ToString();
		this.PriceText.SetAllDirty();
		this.PriceText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001AE8 RID: 6888 RVA: 0x002DAA94 File Offset: 0x002D8C94
	public void CheckShowMoveBtn()
	{
		if (!this.DM.CheckShowOnGroundInfo())
		{
			this.FindMoveIndex = -1;
			this.bNeedCheckMove = false;
			this.MoveBtnGO.SetActive(false);
			return;
		}
		int beginIdx = this.Scroll.GetBeginIdx();
		for (int i = beginIdx + 4; i < this.EmojiCount; i++)
		{
			ushort num = this.GM.EmojiIndex[i - 1];
			if (!this.DM.CheckEmojiSave(num) && !this.GM.HasEmotionPck(num) && !this.Scroll.CheckInPanel(i, true))
			{
				this.FindMoveIndex = i;
				this.MoveBtnGO.SetActive(true);
				return;
			}
		}
		this.FindMoveIndex = -1;
		this.MoveBtnGO.SetActive(false);
	}

	// Token: 0x06001AE9 RID: 6889 RVA: 0x002DAB64 File Offset: 0x002D8D64
	public ushort GetEmojiKey(ushort PackageIndex, int PicIndex)
	{
		if (PackageIndex != 65535)
		{
			return (ushort)(((int)PackageIndex << 7) + PicIndex + 1);
		}
		if (PicIndex < this.GM.SaveEmojiKey.Count)
		{
			return this.GM.SaveEmojiKey[PicIndex];
		}
		return 0;
	}

	// Token: 0x06001AEA RID: 6890 RVA: 0x002DABB0 File Offset: 0x002D8DB0
	public void SendPackage()
	{
		if (this.OpenType == 1)
		{
			Door door = this.GM.FindMenu(EGUIWindow.Door) as Door;
			if (door && door.m_GroundInfo != null)
			{
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_MAP_EMOTION;
				messagePacket.AddSeqId();
				messagePacket.Add(DataManager.MapDataController.FocusKingdomID);
				if (door.m_GroundInfo.m_TeamPanelGameObject.activeSelf)
				{
					messagePacket.Add(13);
					if (door.m_GroundInfo.m_MapPointID >= 0 && door.m_GroundInfo.m_MapPointID < DataManager.MapDataController.MapLineTable.Count)
					{
						MapLine mapLine = DataManager.MapDataController.MapLineTable[door.m_GroundInfo.m_MapPointID];
						messagePacket.Add(mapLine.lineID);
					}
				}
				else
				{
					if (door.m_GroundInfo.m_MapPointID >= 0 && door.m_GroundInfo.m_MapPointID < DataManager.MapDataController.LayoutMapInfo.Length)
					{
						MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)door.m_GroundInfo.m_MapPointID)];
						messagePacket.Add(mapPoint.pointKind);
					}
					ushort data;
					byte data2;
					GameConstants.MapIDToPointCode(door.m_GroundInfo.m_MapPointID, out data, out data2);
					messagePacket.Add(0);
					messagePacket.Add(data);
					messagePacket.Add(data2);
				}
				messagePacket.Add(this.GetEmojiKey(this.GM.EmojiNowPackageIndex, (int)this.GM.EmojiNowPicIndex));
				messagePacket.Add(this.DM.TotalShopItemData.Find(this.ItemID));
				messagePacket.Send(false);
				this.SendChangeSave(this.GM.EmojiNowPackageIndex);
				if (this.DM.GetCurItemQuantity(this.ItemID, 0) <= 0)
				{
					this.DM.SetBuyAndUse(1);
				}
				if (!door.m_GroundInfo.m_TeamPanelGameObject.activeSelf)
				{
					door.m_GroundInfo.Close();
				}
				this.GM.CloseMenu(EGUIWindow.UIEmojiSelect);
			}
		}
		else if (this.OpenType == 2)
		{
			this.GM.UpdateUI(EGUIWindow.UI_Chat, 15, (int)this.GetEmojiKey(this.GM.EmojiNowPackageIndex, (int)this.GM.EmojiNowPicIndex));
			this.SendChangeSave(this.GM.EmojiNowPackageIndex);
			this.GM.CloseMenu(EGUIWindow.UIEmojiSelect);
		}
	}

	// Token: 0x06001AEB RID: 6891 RVA: 0x002DAE24 File Offset: 0x002D9024
	private void SendChangeSave(ushort Index)
	{
		if (Index != 65535)
		{
			ushort emojiKey = this.GetEmojiKey(this.GM.EmojiNowPackageIndex, (int)this.GM.EmojiNowPicIndex);
			for (int i = 0; i < this.GM.SaveEmojiKey.Count; i++)
			{
				if (this.GM.SaveEmojiKey[i] == emojiKey)
				{
					this.GM.SaveEmojiKey.RemoveAt(i);
					this.GM.SaveEmojiKey.Insert(0, emojiKey);
					return;
				}
			}
			if (this.GM.SaveEmojiKey.Count >= 8)
			{
				this.GM.SaveEmojiKey.RemoveAt(this.GM.SaveEmojiKey.Count - 1);
			}
			this.GM.SaveEmojiKey.Insert(0, emojiKey);
			this.GM.SaveEmojiSelectSave();
		}
	}

	// Token: 0x06001AEC RID: 6892 RVA: 0x002DAF0C File Offset: 0x002D910C
	private void Update()
	{
		if (this.NeedUpDate && IGGGameSDK.Instance.bPaymentReady)
		{
			this.NeedUpDate = false;
			this.SetIndex(this.GM.EmojiNowPackageIndex, false);
		}
		if (this.bNeedCheckMove)
		{
			this.CheckMoveTime -= Time.deltaTime;
			if (this.CheckMoveTime <= 0f)
			{
				this.CheckMoveTime = 0.5f;
				this.CheckShowMoveBtn();
			}
		}
	}

	// Token: 0x06001AED RID: 6893 RVA: 0x002DAF8C File Offset: 0x002D918C
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 1)
		{
			if (arg1 == 2)
			{
				this.SendPackage();
			}
			else if (arg1 == 3)
			{
				this.GM.CloseMenu(EGUIWindow.UIEmojiSelect);
			}
			else if (arg1 == 4)
			{
				int num = DataManager.MapDataController.EmoteTable.TableCount - 1;
				for (int i = 0; i < this.GM.EmojiIndex.Count; i++)
				{
					ushort num2 = this.GM.EmojiIndex[i] - 1;
					if ((int)num2 == num)
					{
						this.SetIndex(num2, false);
						this.Scroll.GoTo(i + 1);
					}
				}
			}
		}
	}

	// Token: 0x06001AEE RID: 6894 RVA: 0x002DB044 File Offset: 0x002D9244
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Refresh_Item)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				for (int i = 0; i < this.RBText.Length; i++)
				{
					if (this.RBText[i] != null && this.RBText[i].enabled)
					{
						this.RBText[i].enabled = false;
						this.RBText[i].enabled = true;
					}
				}
				if (this.PriceText != null && this.PriceText.enabled)
				{
					this.PriceText.enabled = false;
					this.PriceText.enabled = true;
				}
				if (this.ItemCountText != null && this.ItemCountText.enabled)
				{
					this.ItemCountText.enabled = false;
					this.ItemCountText.enabled = true;
				}
				if (this.NoKeyText != null && this.NoKeyText.enabled)
				{
					this.NoKeyText.enabled = false;
					this.NoKeyText.enabled = true;
				}
			}
		}
		else
		{
			this.SetIndex(this.GM.EmojiNowPackageIndex, false);
		}
	}

	// Token: 0x06001AEF RID: 6895 RVA: 0x002DB18C File Offset: 0x002D938C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelId == 0 && panelObjectIdx < 8)
		{
			if (!this.bFindScrollComp[panelObjectIdx])
			{
				this.bFindScrollComp[panelObjectIdx] = true;
				Transform transform = item.transform;
				if (this.GM.IsArabic)
				{
					transform.GetChild(1).GetChild(1).localScale = new Vector3(-1f, 1f, 1f);
				}
				transform.GetComponent<CustomImage>().hander = this;
				transform.GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = this;
				transform.GetChild(0).GetChild(1).GetComponent<CustomImage>().hander = this;
				transform.GetChild(1).GetChild(0).GetComponent<CustomImage>().hander = this;
				transform.GetChild(1).GetChild(1).GetComponent<CustomImage>().hander = this;
				transform.GetChild(1).GetChild(2).GetComponent<CustomImage>().hander = this;
				transform.GetChild(1).GetChild(3).GetComponent<CustomImage>().hander = this;
				transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<CustomImage>().hander = this;
				transform.GetChild(1).GetChild(3).GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = this;
				this.Scroll_Comp[panelObjectIdx].ItemGO1 = transform.GetChild(0).gameObject;
				this.Scroll_Comp[panelObjectIdx].ItemGO2 = transform.GetChild(1).gameObject;
				this.Scroll_Comp[panelObjectIdx].FlasfGO = transform.GetChild(1).GetChild(3).gameObject;
				this.Scroll_Comp[panelObjectIdx].Btn1 = transform.GetChild(0).GetChild(1).GetComponent<UIButton>();
				this.Scroll_Comp[panelObjectIdx].Btn1.m_Handler = this;
				this.Scroll_Comp[panelObjectIdx].Btn2 = transform.GetChild(1).GetChild(1).GetComponent<UIButton>();
				this.Scroll_Comp[panelObjectIdx].Btn2.m_Handler = this;
				this.Scroll_Comp[panelObjectIdx].SelectImage1 = transform.GetChild(0).GetChild(0).GetComponent<Image>();
				this.Scroll_Comp[panelObjectIdx].SelectImage2 = transform.GetChild(1).GetChild(0).GetComponent<Image>();
				this.Scroll_Comp[panelObjectIdx].SelectImage1.gameObject.SetActive(true);
				this.Scroll_Comp[panelObjectIdx].SelectImage2.gameObject.SetActive(true);
				this.Scroll_Comp[panelObjectIdx].SelectImage1.enabled = false;
				this.Scroll_Comp[panelObjectIdx].SelectImage2.enabled = false;
				this.Scroll_Comp[panelObjectIdx].ObjectT = transform.GetChild(1).GetChild(1);
				this.Scroll_Comp[panelObjectIdx].EUnit = null;
			}
			if (dataIdx == 0)
			{
				this.Scroll_Comp[panelObjectIdx].ItemGO1.SetActive(true);
				this.Scroll_Comp[panelObjectIdx].ItemGO2.SetActive(false);
				if (this.GM.EmojiNowPackageIndex == 65535)
				{
					this.Scroll_Comp[panelObjectIdx].SelectImage1.enabled = true;
				}
				else
				{
					this.Scroll_Comp[panelObjectIdx].SelectImage1.enabled = false;
				}
				this.Scroll_Comp[panelObjectIdx].SelectImage2.enabled = false;
				this.Scroll_Comp[panelObjectIdx].Btn2.m_BtnID2 = 65535;
			}
			else
			{
				dataIdx--;
				if (dataIdx < 0 || dataIdx >= this.GM.EmojiIndex.Count)
				{
					return;
				}
				this.Scroll_Comp[panelObjectIdx].ItemGO1.SetActive(false);
				this.Scroll_Comp[panelObjectIdx].ItemGO2.SetActive(true);
				ushort num = this.GM.EmojiIndex[dataIdx];
				this.Scroll_Comp[panelObjectIdx].Btn2.m_BtnID2 = (int)(num - 1);
				if (this.Scroll_Comp[panelObjectIdx].EUnit != null)
				{
					this.Scroll_Comp[panelObjectIdx].EUnit.EmojiImage.color = Color.white;
					this.GM.pushEmojiIcon(this.Scroll_Comp[panelObjectIdx].EUnit);
					this.Scroll_Comp[panelObjectIdx].EUnit = null;
				}
				Emote recordByKey = DataManager.MapDataController.EmoteTable.GetRecordByKey(num);
				EmojiData recordByKey2 = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(this.GetEmojiKey(num - 1, (int)(recordByKey.SelectionPicNo - 1)));
				this.Scroll_Comp[panelObjectIdx].EUnit = this.GM.pullEmojiIcon(recordByKey2.IconID, recordByKey2.KeyFrame, false);
				this.Scroll_Comp[panelObjectIdx].EUnit.DefaultSprite();
				float num2 = (float)recordByKey.TabScale / 100f;
				if ((double)num2 > 0.1)
				{
					this.Scroll_Comp[panelObjectIdx].EUnit.EmojiTransform.localScale = new Vector3(num2, num2, num2);
				}
				this.Scroll_Comp[panelObjectIdx].EUnit.EmojiTransform.SetParent(this.Scroll_Comp[panelObjectIdx].ObjectT, false);
				bool flag = this.GM.HasEmotionPck(num);
				if (flag)
				{
					this.Scroll_Comp[panelObjectIdx].EUnit.EmojiImage.color = Color.white;
				}
				else
				{
					this.Scroll_Comp[panelObjectIdx].EUnit.EmojiImage.color = Color.gray;
				}
				if (!this.DM.CheckEmojiSave(num) && !flag)
				{
					this.Scroll_Comp[panelObjectIdx].FlasfGO.SetActive(true);
				}
				else
				{
					this.Scroll_Comp[panelObjectIdx].FlasfGO.SetActive(false);
				}
				if (this.GM.EmojiNowPackageIndex == num - 1)
				{
					this.Scroll_Comp[panelObjectIdx].SelectImage2.enabled = true;
				}
				else
				{
					this.Scroll_Comp[panelObjectIdx].SelectImage2.enabled = false;
				}
				this.Scroll_Comp[panelObjectIdx].SelectImage1.enabled = false;
			}
		}
	}

	// Token: 0x06001AF0 RID: 6896 RVA: 0x002DB804 File Offset: 0x002D9A04
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		img.sprite = this.GM.LoadFrameSprite(ImageName);
		img.material = this.GM.GetFrameMaterial();
	}

	// Token: 0x04004FAA RID: 20394
	private const int UnitCount = 8;

	// Token: 0x04004FAB RID: 20395
	private Transform m_transform;

	// Token: 0x04004FAC RID: 20396
	private Transform UnitObjectT;

	// Token: 0x04004FAD RID: 20397
	private GUIManager GM = GUIManager.Instance;

	// Token: 0x04004FAE RID: 20398
	private DataManager DM = DataManager.Instance;

	// Token: 0x04004FAF RID: 20399
	private StringManager SM = StringManager.Instance;

	// Token: 0x04004FB0 RID: 20400
	private UIText[] RBText = new UIText[14];

	// Token: 0x04004FB1 RID: 20401
	private byte RBTextIndex;

	// Token: 0x04004FB2 RID: 20402
	private CString m_OKString;

	// Token: 0x04004FB3 RID: 20403
	private CString m_OKString_ItemCount;

	// Token: 0x04004FB4 RID: 20404
	private CString PriceStr;

	// Token: 0x04004FB5 RID: 20405
	private ushort ItemID = 1316;

	// Token: 0x04004FB6 RID: 20406
	private uint price;

	// Token: 0x04004FB7 RID: 20407
	private RectTransform SelectRT;

	// Token: 0x04004FB8 RID: 20408
	private RectTransform[] PicRT = new RectTransform[8];

	// Token: 0x04004FB9 RID: 20409
	private byte ECount;

	// Token: 0x04004FBA RID: 20410
	private EmojiUnit[] EUnit = new EmojiUnit[8];

	// Token: 0x04004FBB RID: 20411
	private bool[] bFindScrollComp = new bool[8];

	// Token: 0x04004FBC RID: 20412
	private EmojiUnitComp[] Scroll_Comp = new EmojiUnitComp[8];

	// Token: 0x04004FBD RID: 20413
	private List<float> NowHeightList = new List<float>();

	// Token: 0x04004FBE RID: 20414
	private ScrollPanel_Horizontal Scroll;

	// Token: 0x04004FBF RID: 20415
	private CScrollRect cScrollRect;

	// Token: 0x04004FC0 RID: 20416
	private byte OpenType;

	// Token: 0x04004FC1 RID: 20417
	private GameObject GiftItem;

	// Token: 0x04004FC2 RID: 20418
	private GameObject BuyBtn;

	// Token: 0x04004FC3 RID: 20419
	private GameObject UseBtn;

	// Token: 0x04004FC4 RID: 20420
	private GameObject SpendBtn;

	// Token: 0x04004FC5 RID: 20421
	private GameObject ItemInfoObj;

	// Token: 0x04004FC6 RID: 20422
	private GameObject MoveBtnGO;

	// Token: 0x04004FC7 RID: 20423
	private Image[] PointImg = new Image[3];

	// Token: 0x04004FC8 RID: 20424
	private UIHIBtn GiftBtn;

	// Token: 0x04004FC9 RID: 20425
	private Text PriceText;

	// Token: 0x04004FCA RID: 20426
	private Text ItemCountText;

	// Token: 0x04004FCB RID: 20427
	private Text NoKeyText;

	// Token: 0x04004FCC RID: 20428
	private bool bThirdParty;

	// Token: 0x04004FCD RID: 20429
	private float CheckMoveTime;

	// Token: 0x04004FCE RID: 20430
	private int EmojiCount;

	// Token: 0x04004FCF RID: 20431
	private int FindMoveIndex = -1;

	// Token: 0x04004FD0 RID: 20432
	private bool NeedUpDate;

	// Token: 0x04004FD1 RID: 20433
	private bool bNeedCheckMove;
}
