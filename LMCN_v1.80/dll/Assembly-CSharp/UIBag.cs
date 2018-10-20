using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x02000817 RID: 2071
public class UIBag : UIBagFilterBase, IUIHIBtnClickHandler
{
	// Token: 0x06002B23 RID: 11043 RVA: 0x00471BAC File Offset: 0x0046FDAC
	public UIBag()
	{
		byte[][][] array = new byte[2][][];
		int num = 0;
		byte[][] array2 = new byte[5][];
		array2[0] = new byte[]
		{
			5,
			12,
			9,
			byte.MaxValue
		};
		int num2 = 1;
		byte[] array3 = new byte[4];
		array3[0] = 10;
		array3[1] = 15;
		array3[2] = byte.MaxValue;
		array2[num2] = array3;
		int num3 = 2;
		byte[] array4 = new byte[4];
		array4[0] = 11;
		array4[1] = byte.MaxValue;
		array2[num3] = array4;
		int num4 = 3;
		byte[] array5 = new byte[4];
		array5[0] = 13;
		array5[1] = 14;
		array5[2] = byte.MaxValue;
		array2[num4] = array5;
		array2[4] = new byte[]
		{
			17,
			18,
			16,
			byte.MaxValue
		};
		array[num] = array2;
		int num5 = 1;
		byte[][] array6 = new byte[5][];
		array6[0] = new byte[]
		{
			6,
			10,
			13,
			byte.MaxValue
		};
		int num6 = 1;
		byte[] array7 = new byte[4];
		array7[0] = 11;
		array7[1] = 16;
		array7[2] = byte.MaxValue;
		array6[num6] = array7;
		int num7 = 2;
		byte[] array8 = new byte[4];
		array8[0] = 12;
		array8[1] = byte.MaxValue;
		array6[num7] = array8;
		int num8 = 3;
		byte[] array9 = new byte[4];
		array9[0] = 14;
		array9[1] = 15;
		array9[2] = byte.MaxValue;
		array6[num8] = array9;
		array6[4] = new byte[]
		{
			18,
			19,
			17,
			byte.MaxValue
		};
		array[num5] = array6;
		this.ItemKind = array;
		this.BagTag = new UIBag._BagTag[3];
		this.ObjectTag = new UIBag._ObjTag[5];
		this.BagTextColor = new Color[3];
		this.CurrentTag = UIBag.ClickType.None;
		this.CurrentObjTag = UIBag.ClickType.Tab1;
		this.DelayInit = 2;
		base();
	}

	// Token: 0x06002B24 RID: 11044 RVA: 0x00471D4C File Offset: 0x0046FF4C
	public override void OnOpen(int arg1, int arg2)
	{
		if (this.ThisTransform)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		base.OnOpen(arg1, arg2);
		instance2.UpdateUI(EGUIWindow.Door, 1, 2);
		this.ThisTransform = this.transform.GetChild(0);
		this.ThisTransform.gameObject.SetActive(true);
		Font ttffont = instance2.GetTTFFont();
		this.TitleBkImg = this.ThisTransform.GetChild(0).GetChild(1).GetComponent<Image>();
		this.MainTitle = this.ThisTransform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.MainTitle.font = ttffont;
		base.AddRefreshText(this.MainTitle);
		UIButton component = this.ThisTransform.GetChild(2).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 0;
		component = this.ThisTransform.GetChild(2).GetChild(1).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 1;
		component = this.ThisTransform.GetChild(2).GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 2;
		component = this.ThisTransform.GetChild(7).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 3;
		if (instance2.bOpenOnIPhoneX)
		{
			this.ThisTransform.GetChild(7).GetComponent<Image>().enabled = false;
		}
		this.CurrencyStock = this.ThisTransform.GetChild(1).gameObject;
		this.StockIcon = this.ThisTransform.GetChild(1).GetChild(0).GetComponent<Image>();
		this.StockNum = this.ThisTransform.GetChild(1).GetChild(2).GetComponent<UIText>();
		this.StockNum.font = ttffont;
		base.AddRefreshText(this.StockNum);
		this.ThisTransform.GetChild(1).GetChild(1).GetComponent<CustomImage>().hander = instance2.m_ItemInfo;
		component = this.ThisTransform.GetChild(1).GetChild(1).GetComponent<UIButton>();
		component.m_BtnID1 = 12;
		component.m_Handler = this;
		this.StockNumStr = StringManager.Instance.SpawnString(30);
		this.MessageTrans = this.ThisTransform.GetChild(5).GetComponent<RectTransform>();
		UIText component2 = this.MessageTrans.GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2.text = instance.mStringTable.GetStringByID(744u);
		base.AddRefreshText(component2);
		Vector2 sizeDelta = this.MessageTrans.sizeDelta;
		sizeDelta.x = component2.preferredWidth + 165f;
		this.MessageTrans.sizeDelta = sizeDelta;
		for (int i = 0; i < this.ObjectTag.Length; i++)
		{
			component = this.ThisTransform.GetChild(3).GetChild(i).GetComponent<UIButton>();
			component.m_Handler = this;
			component.m_BtnID1 = 4 + i;
			this.ObjectTag[i].Title = component.gameObject.transform.GetChild(1).GetComponent<UIText>();
			this.ObjectTag[i].Title.text = instance.mStringTable.GetStringByID((uint)(276 + i));
			this.ObjectTag[i].Title.font = ttffont;
			base.AddRefreshText(this.ObjectTag[i].Title);
			this.ObjectTag[i].Background = this.ThisTransform.GetChild(3).GetChild(i).GetComponent<Image>();
			this.ObjectTag[i].AlphaImage = this.ThisTransform.GetChild(3).GetChild(i).GetChild(0).GetComponent<Image>();
			this.ObjectTag[i].Alpha = this.ThisTransform.GetChild(3).GetChild(i).GetChild(0).GetComponent<CanvasGroup>();
		}
		this.BagTextColor[0] = this.ObjectTag[0].Title.color;
		this.BagTextColor[1] = this.ObjectTag[1].Title.color;
		this.BagTextColor[2] = this.ObjectTag[2].Title.color;
		this.BagSpriteArr = this.ThisTransform.GetChild(9).GetComponent<UISpritesArray>();
		Transform child = this.ThisTransform.GetChild(8);
		component2 = child.GetChild(1).GetChild(0).GetComponent<UIText>();
		component2.font = ttffont;
		component2 = child.GetChild(1).GetChild(1).GetComponent<UIText>();
		component2.text = instance.mStringTable.GetStringByID(94u);
		component2.font = ttffont;
		component2 = child.GetChild(2).GetChild(1).GetComponent<UIText>();
		component2.font = ttffont;
		component2 = child.GetChild(2).GetChild(2).GetComponent<UIText>();
		component2.font = ttffont;
		component2 = child.GetChild(3).GetComponent<UIText>();
		component2.font = ttffont;
		component2 = child.GetChild(4).GetComponent<UIText>();
		component2.font = ttffont;
		component2 = child.GetChild(5).GetChild(0).GetComponent<UIText>();
		component2.text = instance.mStringTable.GetStringByID(282u);
		component2.font = ttffont;
		this.OwnerStr = new CString[5];
		this.PriceStr = new CString[5];
		this.NameStr = new CString[5];
		this.ScrollItem = new UIBag.ItemEdit[5];
		for (byte b = 0; b < 5; b += 1)
		{
			this.OwnerStr[(int)b] = StringManager.Instance.SpawnString(30);
			this.PriceStr[(int)b] = StringManager.Instance.SpawnString(30);
			this.NameStr[(int)b] = StringManager.Instance.SpawnString(100);
			this.ItemsHeight.Add(128f);
		}
		this.BagScrollView = this.ThisTransform.GetChild(6).GetChild(0).GetComponent<ScrollPanel>();
		for (int j = 0; j < this.BagTag.Length; j++)
		{
			this.BagTag[j].Alpha = this.ThisTransform.GetChild(2).GetChild(j).GetChild(0).GetComponent<CanvasGroup>();
			this.BagTag[j].Icon = this.ThisTransform.GetChild(2).GetChild(j).GetChild(1).GetComponent<Image>();
		}
		if (arg2 > 0)
		{
			instance2.BagTagSaved[0] = (byte)(((int)GUIManager.Instance.BagTagSaved[0] & -4) | arg2 - 1);
		}
		UIBag.ClickType clickType = (UIBag.ClickType)(GUIManager.Instance.BagTagSaved[0] & 3);
		Sprite sprite = null;
		if (clickType == UIBag.ClickType.AllianceTag && instance.RoleAlliance.Id == 0u)
		{
			clickType = UIBag.ClickType.BagTag;
			GUIManager.Instance.BagTagSaved[0] = (byte)(((UIBag.ClickType)GUIManager.Instance.BagTagSaved[0] & (UIBag.ClickType)(-4)) | clickType);
		}
		switch (clickType)
		{
		case UIBag.ClickType.BagTag:
			this.MainTitle.text = instance.mStringTable.GetStringByID(285u);
			this.CurrencyStock.SetActive(false);
			this.TitleBkImg.sprite = this.BagSpriteArr.GetSprite(21);
			sprite = this.BagSpriteArr.GetSprite(5);
			break;
		case UIBag.ClickType.ShopTag:
			this.MainTitle.text = instance.mStringTable.GetStringByID(286u);
			this.CurrencyStock.SetActive(true);
			this.TitleBkImg.sprite = this.BagSpriteArr.GetSprite(22);
			this.StockIcon.sprite = this.BagSpriteArr.GetSprite(24);
			this.StockIcon.SetNativeSize();
			this.StockIcon.rectTransform.anchoredPosition = Vector2.zero;
			sprite = this.BagSpriteArr.GetSprite(7);
			break;
		case UIBag.ClickType.AllianceTag:
			this.MainTitle.text = instance.mStringTable.GetStringByID(647u);
			this.CurrencyStock.SetActive(true);
			this.TitleBkImg.sprite = this.BagSpriteArr.GetSprite(23);
			sprite = this.BagSpriteArr.GetSprite(9);
			break;
		}
		for (byte b2 = 0; b2 < 5; b2 += 1)
		{
			this.ObjectTag[(int)b2].Background.sprite = sprite;
			this.ObjectTag[(int)b2].Title.color = this.BagTextColor[(int)((byte)clickType)];
		}
		this.CurrentObjTag = UIBag.ClickType.Tab1 + (GUIManager.Instance.BagTagSaved[0] >> 2);
	}

	// Token: 0x06002B25 RID: 11045 RVA: 0x0047263C File Offset: 0x0047083C
	private void Init()
	{
		Transform child = this.ThisTransform.GetChild(8);
		GUIManager.Instance.InitianHeroItemImg(child.GetChild(0), eHeroOrItem.Item, 0, 0, 0, 0, false, false, true, false);
		this.BagScrollView.IntiScrollPanel(472f, 0f, 0f, this.ItemsHeight, 5, this);
		this.BagScrollRect = this.ThisTransform.GetChild(6).GetChild(0).GetComponent<CScrollRect>();
		this.ContentRect = this.ThisTransform.GetChild(6).GetChild(0).GetChild(0).GetComponent<RectTransform>();
		this.ThisTransform.GetChild(6).gameObject.SetActive(true);
		this.ChangeBagTag((UIBag.ClickType)(GUIManager.Instance.BagTagSaved[0] & 3));
		this.CurrentObjTag = UIBag.ClickType.Tab1 + (GUIManager.Instance.BagTagSaved[0] >> 2);
		this.ChangeObjTag(this.CurrentObjTag, true, true);
		if ((UIBag.ClickType)(GUIManager.Instance.BagTagSaved[1] & 3) == this.CurrentTag && (GUIManager.Instance.BagTagSaved[1] >> 2) + UIBag.ClickType.Tab1 == this.CurrentObjTag)
		{
			this.BagScrollView.GoTo((int)GameConstants.ConvertBytesToUShort(GUIManager.Instance.BagTagSaved, 2), GameConstants.ConvertBytesToFloat(GUIManager.Instance.BagTagSaved, 4));
		}
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		GUIWindowStackData value = door.m_WindowStack[door.m_WindowStack.Count - 1];
		if (value.m_Arg2 > 0)
		{
			value.m_Arg2 = 0;
			door.m_WindowStack[door.m_WindowStack.Count - 1] = value;
		}
	}

	// Token: 0x06002B26 RID: 11046 RVA: 0x004727DC File Offset: 0x004709DC
	public override void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		DataManager instance = DataManager.Instance;
		if (this.CurrentTag == UIBag.ClickType.None)
		{
			Transform transform = item.transform;
			this.ScrollItem[panelObjectIdx].m_Rect = transform.GetComponent<RectTransform>();
			this.ScrollItem[panelObjectIdx].BkImage = transform.GetComponent<Image>();
			this.ScrollItem[panelObjectIdx].ItemTrans = transform.GetChild(0);
			this.ScrollItem[panelObjectIdx].Info = this.ScrollItem[panelObjectIdx].ItemTrans.GetChild(0).GetComponent<Image>();
			this.ScrollItem[panelObjectIdx].Info.transform.SetAsLastSibling();
			this.ScrollItem[panelObjectIdx].ItemBtn = this.ScrollItem[panelObjectIdx].ItemTrans.GetComponent<UIHIBtn>();
			this.ScrollItem[panelObjectIdx].ItemBtn.m_BtnID1 = 13;
			this.ScrollItem[panelObjectIdx].ItemBtn.m_Handler = this;
			base.AddRefreshText(this.ScrollItem[panelObjectIdx].ItemTrans.GetChild(4).GetComponent<UIText>());
			this.ScrollItem[panelObjectIdx].OwnBtnScale = transform.GetChild(1).GetComponent<uButtonScale>();
			this.ScrollItem[panelObjectIdx].Owner = transform.GetChild(1).GetChild(0).GetComponent<UIText>();
			base.AddRefreshText(this.ScrollItem[panelObjectIdx].Owner);
			this.ScrollItem[panelObjectIdx].OwnerUse = transform.GetChild(1).GetChild(1).GetComponent<UIText>();
			base.AddRefreshText(this.ScrollItem[panelObjectIdx].OwnerUse);
			this.ScrollItem[panelObjectIdx].OwnerTextRect = transform.GetChild(1).GetChild(0).GetComponent<RectTransform>();
			this.ScrollItem[panelObjectIdx].Name = transform.GetChild(3).GetComponent<UIText>();
			base.AddRefreshText(this.ScrollItem[panelObjectIdx].Name);
			this.ScrollItem[panelObjectIdx].NameRect = transform.GetChild(3).GetComponent<RectTransform>();
			this.ScrollItem[panelObjectIdx].Content = transform.GetChild(4).GetComponent<UIText>();
			base.AddRefreshText(this.ScrollItem[panelObjectIdx].Content);
			this.ScrollItem[panelObjectIdx].ContentRect = transform.GetChild(4).GetComponent<RectTransform>();
			this.ScrollItem[panelObjectIdx].OwnImg = transform.GetChild(1).GetComponent<Image>();
			this.ScrollItem[panelObjectIdx].Currency = transform.GetChild(2).GetChild(0).GetComponent<Image>();
			this.ScrollItem[panelObjectIdx].Price = transform.GetChild(2).GetChild(1).GetComponent<UIText>();
			base.AddRefreshText(this.ScrollItem[panelObjectIdx].Price);
			this.ScrollItem[panelObjectIdx].BuyUseText = transform.GetChild(2).GetChild(2).GetComponent<UIText>();
			base.AddRefreshText(this.ScrollItem[panelObjectIdx].BuyUseText);
			this.ScrollItem[panelObjectIdx].BuyUseTextTrans = transform.GetChild(2).GetChild(2).GetComponent<RectTransform>();
			this.ScrollItem[panelObjectIdx].Ownbtn = transform.GetChild(1).GetComponent<UIButton>();
			this.ScrollItem[panelObjectIdx].Ownbtn.m_Handler = this;
			this.ScrollItem[panelObjectIdx].Ownbtn.m_BtnID1 = 9;
			this.ScrollItem[panelObjectIdx].Ownbtn.m_BtnID2 = panelObjectIdx;
			this.ScrollItem[panelObjectIdx].BuyTrans = transform.GetChild(2).GetComponent<RectTransform>();
			this.ScrollItem[panelObjectIdx].BuyUseImage = this.ScrollItem[panelObjectIdx].BuyTrans.GetComponent<Image>();
			this.ScrollItem[panelObjectIdx].BuyUseBtn = this.ScrollItem[panelObjectIdx].BuyTrans.GetComponent<UIButton>();
			this.ScrollItem[panelObjectIdx].BuyUseBtn.m_Handler = this;
			this.ScrollItem[panelObjectIdx].BuyUseBtn.m_BtnID2 = panelObjectIdx;
			this.ScrollItem[panelObjectIdx].AutouseTrans = transform.GetChild(5);
			base.AddRefreshText(this.ScrollItem[panelObjectIdx].AutouseTrans.GetChild(0).GetComponent<UIText>());
			UIButton component = this.ScrollItem[panelObjectIdx].AutouseTrans.GetComponent<UIButton>();
			component.m_Handler = this;
			component.m_BtnID1 = 11;
		}
		if (this.ItemIDList.Count <= dataIdx)
		{
			return;
		}
		ushort num = 1;
		Equip recordByKey2;
		ushort curItemQuantity;
		if (this.CurrentTag == UIBag.ClickType.ShopTag || this.CurrentTag == UIBag.ClickType.AllianceTag)
		{
			StoreTbl recordByKey = instance.StoreData.GetRecordByKey(this.ItemIDList[dataIdx]);
			recordByKey2 = instance.EquipTable.GetRecordByKey(recordByKey.ItemID);
			num = recordByKey.Num;
			curItemQuantity = instance.GetCurItemQuantity(recordByKey2.EquipKey, 0);
			this.ScrollItem[panelObjectIdx].OwnImg.sprite = this.BagSpriteArr.GetSprite((curItemQuantity <= 0) ? 11 : 12);
			this.ScrollItem[panelObjectIdx].Ownbtn.enabled = (curItemQuantity > 0);
			this.ScrollItem[panelObjectIdx].OwnBtnScale.enabled = this.ScrollItem[panelObjectIdx].Ownbtn.enabled;
			this.PriceStr[panelObjectIdx].ClearString();
			if (this.CurrentTag == UIBag.ClickType.AllianceTag)
			{
				this.PriceStr[panelObjectIdx].IntToFormat((long)((ulong)recordByKey.AlliancePoint), 1, true);
				this.ScrollItem[panelObjectIdx].ItemPrice = recordByKey.AlliancePoint;
			}
			else
			{
				this.PriceStr[panelObjectIdx].IntToFormat((long)((ulong)recordByKey.Price), 1, true);
				this.ScrollItem[panelObjectIdx].ItemPrice = recordByKey.Price;
			}
			this.PriceStr[panelObjectIdx].AppendFormat("{0}");
			this.ScrollItem[panelObjectIdx].Price.text = this.PriceStr[panelObjectIdx].ToString();
			this.ScrollItem[panelObjectIdx].Price.SetAllDirty();
			this.ScrollItem[panelObjectIdx].Price.cachedTextGenerator.Invalidate();
			this.ScrollItem[panelObjectIdx].ItemSN = recordByKey.ID;
			if (recordByKey2.Hide == 1)
			{
				this.ScrollItem[panelObjectIdx].Ownbtn.enabled = false;
				this.ScrollItem[panelObjectIdx].OwnImg.enabled = false;
				this.ScrollItem[panelObjectIdx].OwnerUse.enabled = false;
			}
			else
			{
				this.ScrollItem[panelObjectIdx].OwnImg.enabled = true;
				this.ScrollItem[panelObjectIdx].OwnerUse.enabled = true;
			}
			if (!this.ScrollItem[panelObjectIdx].BuyTrans.gameObject.activeSelf)
			{
				this.ScrollItem[panelObjectIdx].BuyTrans.gameObject.SetActive(true);
			}
		}
		else
		{
			recordByKey2 = instance.EquipTable.GetRecordByKey(this.ItemIDList[dataIdx]);
			curItemQuantity = instance.GetCurItemQuantity(this.ItemIDList[dataIdx], 0);
			if (recordByKey2.Hide == 1)
			{
				this.ScrollItem[panelObjectIdx].AutouseTrans.gameObject.SetActive(false);
				this.ScrollItem[panelObjectIdx].BuyTrans.gameObject.SetActive(false);
			}
			else
			{
				if (!this.ScrollItem[panelObjectIdx].BuyTrans.gameObject.activeSelf)
				{
					this.ScrollItem[panelObjectIdx].BuyTrans.gameObject.SetActive(true);
				}
				if (recordByKey2.EquipKind == 11 || recordByKey2.EquipKind == 19 || recordByKey2.EquipKind == 18 || recordByKey2.EquipKind == 13 || (recordByKey2.EquipKind == 10 && (recordByKey2.PropertiesInfo[0].Propertieskey == 33 || recordByKey2.PropertiesInfo[0].Propertieskey == 49 || recordByKey2.PropertiesInfo[0].Propertieskey == 40)))
				{
					if (curItemQuantity >= 2 && recordByKey2.Hide != 2)
					{
						this.ScrollItem[panelObjectIdx].AutouseTrans.gameObject.SetActive(true);
					}
					else
					{
						this.ScrollItem[panelObjectIdx].AutouseTrans.gameObject.SetActive(false);
					}
				}
				else
				{
					this.ScrollItem[panelObjectIdx].AutouseTrans.gameObject.SetActive(false);
				}
			}
		}
		if (num == 1)
		{
			this.ScrollItem[panelObjectIdx].Name.text = instance.mStringTable.GetStringByID((uint)recordByKey2.EquipName);
		}
		else
		{
			this.NameStr[panelObjectIdx].ClearString();
			this.NameStr[panelObjectIdx].StringToFormat(instance.mStringTable.GetStringByID((uint)recordByKey2.EquipName));
			this.NameStr[panelObjectIdx].IntToFormat((long)num, 1, false);
			this.NameStr[panelObjectIdx].AppendFormat("{0} x {1}");
			this.ScrollItem[panelObjectIdx].Name.text = this.NameStr[panelObjectIdx].ToString();
			this.ScrollItem[panelObjectIdx].Name.SetAllDirty();
			this.ScrollItem[panelObjectIdx].Name.cachedTextGenerator.Invalidate();
		}
		if (recordByKey2.EquipKind == 19)
		{
			this.ScrollItem[panelObjectIdx].Info.gameObject.SetActive(true);
			this.ScrollItem[panelObjectIdx].ItemBtn.m_BtnID2 = (int)recordByKey2.EquipKey;
			GUIManager.Instance.SetItemScaleClickSound(this.ScrollItem[panelObjectIdx].ItemBtn, true, true);
		}
		else if (recordByKey2.EquipKind == 18 && recordByKey2.PropertiesInfo[0].Propertieskey == 4)
		{
			this.ScrollItem[panelObjectIdx].Info.gameObject.SetActive(true);
			this.ScrollItem[panelObjectIdx].ItemBtn.m_BtnID2 = (int)recordByKey2.EquipKey;
			GUIManager.Instance.SetItemScaleClickSound(this.ScrollItem[panelObjectIdx].ItemBtn, true, true);
		}
		else if (recordByKey2.EquipKind == 18 && (recordByKey2.PropertiesInfo[2].Propertieskey < 1 || recordByKey2.PropertiesInfo[2].Propertieskey > 3))
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(instance.mStringTable.GetStringByID((uint)(7734 + recordByKey2.PropertiesInfo[0].Propertieskey)));
			cstring.AppendFormat(instance.mStringTable.GetStringByID(7739u));
			cstring.Append(instance.mStringTable.GetStringByID((uint)recordByKey2.EquipName));
			this.NameStr[panelObjectIdx].ClearString();
			this.NameStr[panelObjectIdx].Append(cstring);
			this.ScrollItem[panelObjectIdx].Name.text = this.NameStr[panelObjectIdx].ToString();
			this.ScrollItem[panelObjectIdx].Name.SetAllDirty();
			this.ScrollItem[panelObjectIdx].Name.cachedTextGenerator.Invalidate();
			this.ScrollItem[panelObjectIdx].Info.gameObject.SetActive(true);
			this.ScrollItem[panelObjectIdx].ItemBtn.m_BtnID2 = (int)recordByKey2.EquipKey;
			GUIManager.Instance.SetItemScaleClickSound(this.ScrollItem[panelObjectIdx].ItemBtn, true, true);
		}
		else
		{
			this.ScrollItem[panelObjectIdx].ItemBtn.m_BtnID2 = 0;
			this.ScrollItem[panelObjectIdx].Info.gameObject.SetActive(false);
			GUIManager.Instance.SetItemScaleClickSound(this.ScrollItem[panelObjectIdx].ItemBtn, false, false);
		}
		this.ScrollItem[panelObjectIdx].Content.text = instance.mStringTable.GetStringByID((uint)recordByKey2.EquipInfo);
		CString cstring2 = StringManager.Instance.StaticString1024();
		this.OwnerStr[panelObjectIdx].ClearString();
		if (curItemQuantity < 10000)
		{
			cstring2.IntToFormat((long)curItemQuantity, 1, true);
			cstring2.AppendFormat("{0}");
		}
		else
		{
			GameConstants.FormatResourceValue(cstring2, (uint)curItemQuantity);
		}
		this.OwnerStr[panelObjectIdx].StringToFormat(instance.mStringTable.GetStringByID(281u));
		this.OwnerStr[panelObjectIdx].StringToFormat(cstring2);
		this.OwnerStr[panelObjectIdx].AppendFormat("{0}{1}");
		this.ScrollItem[panelObjectIdx].Owner.text = this.OwnerStr[panelObjectIdx].ToString();
		this.ScrollItem[panelObjectIdx].Owner.SetAllDirty();
		this.ScrollItem[panelObjectIdx].Owner.cachedTextGenerator.Invalidate();
		GUIManager.Instance.ChangeHeroItemImg(this.ScrollItem[panelObjectIdx].ItemTrans, eHeroOrItem.Item, recordByKey2.EquipKey, 0, 0, 0);
		this.ScrollItem[panelObjectIdx].ItemID = recordByKey2.EquipKey;
	}

	// Token: 0x06002B27 RID: 11047 RVA: 0x00473618 File Offset: 0x00471818
	public override void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06002B28 RID: 11048 RVA: 0x0047361C File Offset: 0x0047181C
	public override void OnButtonClick(UIButton sender)
	{
		if (this.DelayInit > 0)
		{
			return;
		}
		switch (sender.m_BtnID1)
		{
		case 0:
		case 1:
		case 2:
			this.ChangeBagTag((UIBag.ClickType)sender.m_BtnID1);
			if ((sender.m_BtnID1 == 2 && DataManager.Instance.RoleAlliance.Id > 0u) || sender.m_BtnID1 != 2)
			{
				this.ChangeObjTag(this.CurrentObjTag, true, true);
			}
			break;
		case 3:
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				door.CloseMenu(false);
			}
			break;
		}
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
			this.ChangeObjTag((UIBag.ClickType)sender.m_BtnID1, false, true);
			break;
		case 9:
			if (!base.CheckItemEnergy(this.ScrollItem[sender.m_BtnID2].ItemID, 1))
			{
				base.CheckMessage(this.ScrollItem[sender.m_BtnID2].ItemID);
			}
			break;
		case 10:
			if (DataManager.Instance.GetCurItemQuantity(this.ScrollItem[sender.m_BtnID2].ItemID, 0) >= 65535)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(887u), 255, true);
			}
			else
			{
				StringTable mStringTable = DataManager.Instance.mStringTable;
				if (this.ShopType == 2 && this.ScrollItem[sender.m_BtnID2].ItemPrice > DataManager.Instance.RoleAlliance.Money)
				{
					GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(614u), mStringTable.GetStringByID(649u), mStringTable.GetStringByID(650u), null, 0, 0, false, false, false, false, false);
				}
				else if (this.ShopType == 1 && this.ScrollItem[sender.m_BtnID2].ItemPrice > DataManager.Instance.RoleAttr.Diamond)
				{
					GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(3966u), mStringTable.GetStringByID(646u), 4, mStringTable.GetStringByID(4507u), 0, 0, true, false, false, false, false);
				}
				else
				{
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 10, (int)this.ScrollItem[sender.m_BtnID2].ItemSN << 16 | (int)this.ShopType);
					this.SelBuyIndex = (byte)sender.m_BtnID2;
				}
			}
			break;
		case 11:
		{
			Debug.Log("AutoUse");
			int btnID = sender.transform.parent.GetChild(2).GetComponent<UIButton>().m_BtnID2;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 3, (int)this.ScrollItem[btnID].ItemID);
			break;
		}
		case 12:
			if (this.CurrentTag == UIBag.ClickType.AllianceTag)
			{
				GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(647u), DataManager.Instance.mStringTable.GetStringByID(700u), DataManager.Instance.mStringTable.GetStringByID(650u), null, 0, 0, false, false, false, false, false);
			}
			else
			{
				Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door2 != null)
				{
					door2.ClearWindowStack(EGUIWindow.UI_BagFilter, EGUIWindow.MAX);
				}
				MallManager.Instance.Send_Mall_Info();
			}
			break;
		}
	}

	// Token: 0x06002B29 RID: 11049 RVA: 0x004739A8 File Offset: 0x00471BA8
	public override void OnHIButtonClick(UIHIBtn sender)
	{
		base.OnHIButtonClick(sender);
		if (sender.m_BtnID2 == 0)
		{
			return;
		}
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		door.OpenMenu(EGUIWindow.UI_OpenBox, 1, sender.m_BtnID2, false);
	}

	// Token: 0x06002B2A RID: 11050 RVA: 0x004739EC File Offset: 0x00471BEC
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK && !DataManager.Instance.UseItemNote((ushort)arg1, 0, 0, 0))
		{
			DataManager.Instance.UseItem((ushort)arg1, 1, 0, 0, 0, 0u, string.Empty, true);
		}
	}

	// Token: 0x06002B2B RID: 11051 RVA: 0x00473A2C File Offset: 0x00471C2C
	protected unsafe void ChangeObjTag(UIBag.ClickType Tag, bool bForceUpdate = false, bool bForceMoveBegin = true)
	{
		if (!bForceUpdate && Tag == this.CurrentObjTag)
		{
			return;
		}
		if (this.CurrentObjTag != UIBag.ClickType.None)
		{
			this.ObjectTag[this.CurrentObjTag - UIBag.ClickType.Tab1].Alpha.alpha = 0f;
			this.ObjectTag[this.CurrentObjTag - UIBag.ClickType.Tab1].Title.color = this.BagTextColor[(int)((byte)this.CurrentTag)];
		}
		this.CurrentObjTag = Tag;
		this.ObjectTag[this.CurrentObjTag - UIBag.ClickType.Tab1].Title.color = Color.white;
		DataManager instance = DataManager.Instance;
		if (this.CurrentTag == UIBag.ClickType.BagTag)
		{
			instance.SortCurItemDataForBag();
		}
		else
		{
			instance.SortStoreData();
		}
		ushort[] array = (this.CurrentTag != UIBag.ClickType.BagTag) ? instance.SortSotreData : instance.sortItemData;
		ushort[] array2;
		ushort[] array3;
		if (this.CurrentTag == UIBag.ClickType.BagTag)
		{
			array2 = instance.sortItemDataStart;
			array3 = instance.sortItemDataCount;
		}
		else
		{
			this.StockNumStr.ClearString();
			if (this.CurrentTag == UIBag.ClickType.ShopTag)
			{
				this.StockNumStr.IntToFormat((long)((ulong)instance.RoleAttr.Diamond), 1, true);
			}
			else
			{
				this.StockNumStr.IntToFormat((long)((ulong)instance.RoleAlliance.Money), 1, true);
			}
			this.StockNumStr.AppendFormat("{0}");
			this.StockNum.text = this.StockNumStr.ToString();
			this.StockNum.SetAllDirty();
			this.StockNum.cachedTextGenerator.Invalidate();
			array2 = instance.SortSotreDataStart;
			array3 = instance.SortSotreDataCount;
		}
		this.ItemIDList.Clear();
		this.ItemsHeight.Clear();
		int num = Mathf.Clamp((int)this.CurrentTag, 0, 1);
		fixed (byte* ptr = ref (this.ItemKind[num][(int)((byte)(this.CurrentObjTag - UIBag.ClickType.Tab1))] != null && this.ItemKind[num][(int)((byte)(this.CurrentObjTag - UIBag.ClickType.Tab1))].Length != 0) ? ref this.ItemKind[num][(int)((byte)(this.CurrentObjTag - UIBag.ClickType.Tab1))][0] : ref *null)
		{
			for (byte b = 0; b < 4; b += 1)
			{
				if (ptr[b] == 255)
				{
					break;
				}
				int num2 = (int)array2[(int)ptr[b]];
				int num3 = num2 + (int)array3[(int)ptr[b]];
				int i = num2;
				while (i < num3)
				{
					if (this.CurrentTag == UIBag.ClickType.BagTag)
					{
						if (instance.GetCurItemQuantity(array[i], 0) != 0)
						{
							Equip recordByKey = instance.EquipTable.GetRecordByKey(array[i]);
							if (recordByKey.EquipKind - 1 != 16 || recordByKey.PropertiesInfo[0].Propertieskey == 3)
							{
								this.ItemsHeight.Add(128f);
								goto IL_371;
							}
						}
					}
					else
					{
						StoreTbl recordByKey2 = instance.StoreData.GetRecordByKey(array[i]);
						if (this.ShopType != 1 || (recordByKey2.AddDiamondBuy != 0 && recordByKey2.Filter == 0))
						{
							if (this.ShopType != 2 || recordByKey2.AddAllianceBuy != 0)
							{
								Equip recordByKey = instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
								if (recordByKey.EquipKind - 1 != 16 || recordByKey.PropertiesInfo[0].Propertieskey == 3)
								{
									this.ItemsHeight.Add(157f);
									goto IL_371;
								}
							}
						}
					}
					IL_380:
					i++;
					continue;
					IL_371:
					this.ItemIDList.Add(array[i]);
					goto IL_380;
				}
			}
		}
		int beginIdx = this.BagScrollView.GetBeginIdx();
		Vector2 anchoredPosition = this.ContentRect.anchoredPosition;
		this.BagScrollView.gameObject.SetActive(this.ItemsHeight.Count != 0);
		this.BagScrollView.AddNewDataHeight(this.ItemsHeight, true, true);
		if (bForceMoveBegin)
		{
			this.BagScrollRect.StopMovement();
			this.BagScrollView.GoTo(0);
		}
		else
		{
			this.BagScrollView.GoTo(beginIdx, anchoredPosition.y);
		}
		if (this.ItemsHeight.Count == 0)
		{
			this.MessageTrans.gameObject.SetActive(true);
		}
		else
		{
			this.MessageTrans.gameObject.SetActive(false);
		}
	}

	// Token: 0x06002B2C RID: 11052 RVA: 0x00473E9C File Offset: 0x0047209C
	protected virtual void ChangeBagTag(UIBag.ClickType Tag)
	{
		if (Tag == this.CurrentTag)
		{
			return;
		}
		if (DataManager.Instance.RoleAlliance.Id == 0u && Tag == UIBag.ClickType.AllianceTag)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			DataManager.Instance.SetSelectRequest = 0;
			door.OpenMenu(EGUIWindow.UI_AllianceHint, 0, 0, false);
			return;
		}
		if (this.CurrentTag >= UIBag.ClickType.BagTag && this.CurrentTag <= UIBag.ClickType.AllianceTag)
		{
			this.BagTag[(int)((byte)this.CurrentTag)].Alpha.alpha = 0f;
		}
		this.CurrentTag = Tag;
		DataManager instance = DataManager.Instance;
		if (this.CurrentTag == UIBag.ClickType.BagTag)
		{
			instance.SortCurItemDataForBag();
		}
		else
		{
			this.ShopType = (byte)(1 + (this.CurrentTag - UIBag.ClickType.ShopTag));
			instance.SortStoreData();
		}
		byte b = 0;
		while ((int)b < this.ScrollItem.Length)
		{
			Vector2 vector = this.ScrollItem[(int)b].m_Rect.sizeDelta;
			if (this.CurrentTag == UIBag.ClickType.BagTag)
			{
				vector.y = 128f;
				this.ScrollItem[(int)b].m_Rect.sizeDelta = vector;
				this.ScrollItem[(int)b].Ownbtn.enabled = false;
				this.ScrollItem[(int)b].OwnImg.enabled = false;
				this.ScrollItem[(int)b].OwnerUse.enabled = false;
				vector.Set(this.ScrollItem[(int)b].OwnerTextRect.anchoredPosition.x, 18f);
				this.ScrollItem[(int)b].OwnerTextRect.anchoredPosition = vector;
				this.ScrollItem[(int)b].Owner.color = this.BagOwnColor;
				vector.Set(131f, 47f);
				this.ScrollItem[(int)b].BuyTrans.sizeDelta = vector;
				vector.Set(669f, -35.5f);
				this.ScrollItem[(int)b].BuyTrans.anchoredPosition = vector;
				this.ScrollItem[(int)b].BuyUseBtn.m_BtnID1 = 9;
				this.ScrollItem[(int)b].BuyUseImage.sprite = this.BagSpriteArr.GetSprite(13);
				this.ScrollItem[(int)b].Currency.enabled = false;
				this.ScrollItem[(int)b].Price.enabled = false;
				this.ScrollItem[(int)b].BuyUseText.text = instance.mStringTable.GetStringByID(94u);
				vector.Set(131f, 57f);
				this.ScrollItem[(int)b].BuyUseTextTrans.sizeDelta = vector;
				this.ScrollItem[(int)b].BuyTrans.sizeDelta = vector;
				vector.Set(65.5f, -28.5f);
				this.ScrollItem[(int)b].BuyUseTextTrans.anchoredPosition = vector;
				vector.Set(455f, this.ScrollItem[(int)b].NameRect.sizeDelta.y);
				this.ScrollItem[(int)b].NameRect.sizeDelta = vector;
				this.ScrollItem[(int)b].Name.UpdateArabicPos();
				vector.Set(455f, this.ScrollItem[(int)b].ContentRect.sizeDelta.y);
				this.ScrollItem[(int)b].ContentRect.sizeDelta = vector;
				this.ScrollItem[(int)b].Content.UpdateArabicPos();
				this.ScrollItem[(int)b].AutouseTrans.gameObject.SetActive(true);
				this.TitleBkImg.sprite = this.BagSpriteArr.GetSprite(21);
				this.CurrencyStock.SetActive(false);
				this.ScrollItem[(int)b].BkImage.sprite = this.BagSpriteArr.GetSprite(15);
				this.MainTitle.text = instance.mStringTable.GetStringByID(285u);
			}
			else
			{
				vector.y = 157f;
				this.ScrollItem[(int)b].m_Rect.sizeDelta = vector;
				this.ScrollItem[(int)b].Ownbtn.enabled = true;
				this.ScrollItem[(int)b].OwnImg.enabled = true;
				this.ScrollItem[(int)b].OwnerUse.enabled = true;
				vector.Set(this.ScrollItem[(int)b].OwnerTextRect.anchoredPosition.x, 10.4f);
				this.ScrollItem[(int)b].OwnerTextRect.anchoredPosition = vector;
				this.ScrollItem[(int)b].Owner.color = this.ShopOwnColor;
				vector.Set(158f, 77f);
				this.ScrollItem[(int)b].BuyTrans.sizeDelta = vector;
				vector.Set(655f, -49.5f);
				this.ScrollItem[(int)b].BuyTrans.anchoredPosition = vector;
				this.ScrollItem[(int)b].BuyUseBtn.m_BtnID1 = 10;
				this.ScrollItem[(int)b].BuyUseImage.sprite = this.BagSpriteArr.GetSprite(14);
				this.ScrollItem[(int)b].Currency.enabled = true;
				this.ScrollItem[(int)b].Price.enabled = true;
				this.ScrollItem[(int)b].BuyUseText.text = instance.mStringTable.GetStringByID(284u);
				vector.Set(158f, 32f);
				this.ScrollItem[(int)b].BuyUseTextTrans.sizeDelta = vector;
				vector.Set(79f, -56.1f);
				this.ScrollItem[(int)b].BuyUseTextTrans.anchoredPosition = vector;
				vector.Set(420f, this.ScrollItem[(int)b].NameRect.sizeDelta.y);
				this.ScrollItem[(int)b].NameRect.sizeDelta = vector;
				this.ScrollItem[(int)b].Name.UpdateArabicPos();
				vector.Set(420f, this.ScrollItem[(int)b].ContentRect.sizeDelta.y);
				this.ScrollItem[(int)b].ContentRect.sizeDelta = vector;
				this.ScrollItem[(int)b].Content.UpdateArabicPos();
				this.ScrollItem[(int)b].AutouseTrans.gameObject.SetActive(false);
				if (this.CurrentTag == UIBag.ClickType.ShopTag)
				{
					this.TitleBkImg.sprite = this.BagSpriteArr.GetSprite(22);
					this.CurrencyStock.SetActive(true);
					this.StockIcon.sprite = this.BagSpriteArr.GetSprite(24);
					this.StockIcon.SetNativeSize();
					vector = this.StockIcon.rectTransform.anchoredPosition;
					vector.Set(3.5f, 5f);
					this.StockIcon.rectTransform.anchoredPosition = vector;
					this.ScrollItem[(int)b].BkImage.sprite = this.BagSpriteArr.GetSprite(16);
					this.ScrollItem[(int)b].Currency.sprite = this.BagSpriteArr.GetSprite(19);
					this.ScrollItem[(int)b].Currency.SetNativeSize();
					this.ScrollItem[(int)b].Currency.rectTransform.localScale = Vector3.one;
					this.MainTitle.text = instance.mStringTable.GetStringByID(286u);
				}
				else
				{
					this.TitleBkImg.sprite = this.BagSpriteArr.GetSprite(23);
					this.CurrencyStock.SetActive(true);
					this.StockIcon.sprite = this.BagSpriteArr.GetSprite(20);
					this.StockIcon.SetNativeSize();
					vector = this.StockIcon.rectTransform.anchoredPosition;
					vector.Set(7f, 1f);
					this.StockIcon.rectTransform.anchoredPosition = vector;
					this.ScrollItem[(int)b].BkImage.sprite = this.BagSpriteArr.GetSprite(17);
					this.ScrollItem[(int)b].Currency.sprite = this.BagSpriteArr.GetSprite(20);
					this.ScrollItem[(int)b].Currency.SetNativeSize();
					this.ScrollItem[(int)b].Currency.rectTransform.localScale = Vector3.one * 0.8f;
					this.MainTitle.text = instance.mStringTable.GetStringByID(647u);
				}
			}
			b += 1;
		}
		int num;
		if (this.CurrentTag == UIBag.ClickType.BagTag)
		{
			num = 5;
		}
		else if (this.CurrentTag == UIBag.ClickType.ShopTag)
		{
			num = 7;
		}
		else
		{
			num = 9;
		}
		Sprite sprite = this.BagSpriteArr.GetSprite(num);
		Sprite sprite2 = this.BagSpriteArr.GetSprite(num + 1);
		for (byte b2 = 0; b2 < 5; b2 += 1)
		{
			this.ObjectTag[(int)b2].Title.color = this.BagTextColor[(int)((byte)this.CurrentTag)];
			this.ObjectTag[(int)b2].Background.sprite = sprite;
			this.ObjectTag[(int)b2].AlphaImage.sprite = sprite2;
			this.ObjectTag[(int)b2].AlphaImage.type = Image.Type.Sliced;
		}
	}

	// Token: 0x06002B2D RID: 11053 RVA: 0x004748C0 File Offset: 0x00472AC0
	public override void Update()
	{
		if (this.DelayInit > 0)
		{
			this.DelayInit -= 1;
			if (this.DelayInit == 0)
			{
				this.Init();
			}
		}
		else
		{
			this.DeltaTime += Time.deltaTime;
			if (this.DeltaTime >= 2f)
			{
				this.DeltaTime = 0f;
			}
			float alpha = (this.DeltaTime <= 1f) ? this.DeltaTime : (2f - this.DeltaTime);
			this.BagTag[(int)this.CurrentTag].Alpha.alpha = alpha;
			this.ObjectTag[this.CurrentObjTag - UIBag.ClickType.Tab1].Alpha.alpha = alpha;
		}
	}

	// Token: 0x06002B2E RID: 11054 RVA: 0x00474990 File Offset: 0x00472B90
	public override void UpdateUI(int arge1, int arge2)
	{
		int num = arge1 >> 16;
		if (num != 1)
		{
			return;
		}
		if (arge1 != 65536)
		{
			if (arge1 == 65537)
			{
				ushort b = (ushort)(arge2 >> 16);
				ushort num2 = (ushort)(arge2 & 65535);
				if (this.ScrollItem[(int)this.SelBuyIndex].ItemID != num2)
				{
					byte b2 = 0;
					while ((int)b2 < this.ScrollItem.Length)
					{
						if (this.ScrollItem[(int)b2].ItemID == num2)
						{
							this.SelBuyIndex = b2;
							break;
						}
						b2 += 1;
					}
				}
				DataManager.Instance.sendBuyItem(this.ShopType, this.ScrollItem[(int)this.SelBuyIndex].ItemSN, this.ScrollItem[(int)this.SelBuyIndex].ItemID, false, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), 0, 0, 0u, string.Empty, true, (ushort)Mathf.Max(1, (int)b));
			}
		}
		else
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint)DataManager.Instance.EquipTable.GetRecordByKey((ushort)arge2).EquipName));
			cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(835u));
			GUIManager.Instance.AddHUDMessage(cstring.ToString(), 18, true);
		}
	}

	// Token: 0x06002B2F RID: 11055 RVA: 0x00474B08 File Offset: 0x00472D08
	public override void OnClose()
	{
		base.OnClose();
		for (int i = 0; i < this.OwnerStr.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.OwnerStr[i]);
			StringManager.Instance.DeSpawnString(this.PriceStr[i]);
			StringManager.Instance.DeSpawnString(this.NameStr[i]);
		}
		StringManager.Instance.DeSpawnString(this.StockNumStr);
		if (this.CurrentTag != UIBag.ClickType.None)
		{
			GUIManager.Instance.BagTagSaved[0] = (byte)(this.CurrentTag + ((int)((byte)(this.CurrentObjTag - UIBag.ClickType.Tab1)) << 2));
			GUIManager.Instance.BagTagSaved[1] = GUIManager.Instance.BagTagSaved[0];
			GameConstants.GetBytes((ushort)this.BagScrollView.GetBeginIdx(), GUIManager.Instance.BagTagSaved, 2);
			GameConstants.GetBytes(this.ContentRect.anchoredPosition.y, GUIManager.Instance.BagTagSaved, 4);
		}
	}

	// Token: 0x06002B30 RID: 11056 RVA: 0x00474C04 File Offset: 0x00472E04
	public override void UpdateNetwork(byte[] meg)
	{
		if (this.DelayInit > 0)
		{
			this.Init();
			this.DelayInit = 0;
		}
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_Item:
			if (this.CurrentTag == UIBag.ClickType.BagTag)
			{
				DataManager.Instance.SortCurItemDataForBag();
			}
			else
			{
				DataManager.Instance.SortStoreData();
			}
			this.ChangeObjTag(this.CurrentObjTag, true, false);
			break;
		default:
			switch (networkNews)
			{
			case NetworkNews.Login:
				if (this.CurrentTag == UIBag.ClickType.AllianceTag && DataManager.Instance.RoleAlliance.Id == 0u)
				{
					Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
					if (door != null)
					{
						door.CloseMenu_Alliance(EGUIWindow.UI_BagFilter);
					}
				}
				else
				{
					if (this.CurrentTag == UIBag.ClickType.BagTag)
					{
						DataManager.Instance.SortCurItemDataForBag();
					}
					else
					{
						DataManager.Instance.SortStoreData();
					}
					this.ChangeObjTag(this.CurrentObjTag, true, false);
				}
				break;
			default:
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					for (int i = 0; i < this.ScrollItem.Length; i++)
					{
						if (this.ScrollItem[i].ItemBtn == null)
						{
							break;
						}
						this.ScrollItem[i].ItemBtn.Refresh_FontTexture();
					}
				}
				break;
			case NetworkNews.Refresh:
				this.StockNumStr.ClearString();
				if (this.CurrentTag == UIBag.ClickType.ShopTag)
				{
					this.StockNumStr.IntToFormat((long)((ulong)DataManager.Instance.RoleAttr.Diamond), 1, true);
				}
				else
				{
					this.StockNumStr.IntToFormat((long)((ulong)DataManager.Instance.RoleAlliance.Money), 1, true);
				}
				this.StockNumStr.AppendFormat("{0}");
				this.StockNum.text = this.StockNumStr.ToString();
				this.StockNum.SetAllDirty();
				this.StockNum.cachedTextGenerator.Invalidate();
				break;
			}
			break;
		case NetworkNews.Refresh_Alliance:
			if (this.CurrentTag == UIBag.ClickType.AllianceTag)
			{
				if (DataManager.Instance.RoleAlliance.Id == 0u)
				{
					Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
					if (door2 != null)
					{
						door2.CloseMenu_Alliance(EGUIWindow.UI_BagFilter);
					}
				}
				else
				{
					this.StockNumStr.ClearString();
					this.StockNumStr.IntToFormat((long)((ulong)DataManager.Instance.RoleAlliance.Money), 1, true);
					this.StockNumStr.AppendFormat("{0}");
					this.StockNum.text = this.StockNumStr.ToString();
					this.StockNum.SetAllDirty();
					this.StockNum.cachedTextGenerator.Invalidate();
				}
			}
			break;
		}
	}

	// Token: 0x040076C0 RID: 30400
	private const byte ItemCount = 5;

	// Token: 0x040076C1 RID: 30401
	private CString[] OwnerStr;

	// Token: 0x040076C2 RID: 30402
	private CString[] PriceStr;

	// Token: 0x040076C3 RID: 30403
	private CString[] NameStr;

	// Token: 0x040076C4 RID: 30404
	private ScrollPanel BagScrollView;

	// Token: 0x040076C5 RID: 30405
	private CScrollRect BagScrollRect;

	// Token: 0x040076C6 RID: 30406
	private RectTransform ContentRect;

	// Token: 0x040076C7 RID: 30407
	private List<float> ItemsHeight = new List<float>();

	// Token: 0x040076C8 RID: 30408
	private List<ushort> ItemIDList = new List<ushort>();

	// Token: 0x040076C9 RID: 30409
	protected UIBag.ItemEdit[] ScrollItem;

	// Token: 0x040076CA RID: 30410
	private Image StockIcon;

	// Token: 0x040076CB RID: 30411
	private Image TitleBkImg;

	// Token: 0x040076CC RID: 30412
	private UIText StockNum;

	// Token: 0x040076CD RID: 30413
	private GameObject CurrencyStock;

	// Token: 0x040076CE RID: 30414
	private CString StockNumStr;

	// Token: 0x040076CF RID: 30415
	private RectTransform MessageTrans;

	// Token: 0x040076D0 RID: 30416
	private Color BagOwnColor = new Color(0.541f, 0.835f, 0.886f);

	// Token: 0x040076D1 RID: 30417
	private Color ShopOwnColor = new Color(0.902f, 0.886f, 0.667f);

	// Token: 0x040076D2 RID: 30418
	private UISpritesArray BagSpriteArr;

	// Token: 0x040076D3 RID: 30419
	protected UIText MainTitle;

	// Token: 0x040076D4 RID: 30420
	protected byte ShopType;

	// Token: 0x040076D5 RID: 30421
	protected byte SelBuyIndex;

	// Token: 0x040076D6 RID: 30422
	private float DeltaTime;

	// Token: 0x040076D7 RID: 30423
	private readonly byte[][][] ItemKind;

	// Token: 0x040076D8 RID: 30424
	private UIBag._BagTag[] BagTag;

	// Token: 0x040076D9 RID: 30425
	private UIBag._ObjTag[] ObjectTag;

	// Token: 0x040076DA RID: 30426
	private Color[] BagTextColor;

	// Token: 0x040076DB RID: 30427
	private UIBag.ClickType CurrentTag;

	// Token: 0x040076DC RID: 30428
	protected UIBag.ClickType CurrentObjTag;

	// Token: 0x040076DD RID: 30429
	private byte DelayInit;

	// Token: 0x02000818 RID: 2072
	protected struct ItemEdit
	{
		// Token: 0x040076DE RID: 30430
		public RectTransform m_Rect;

		// Token: 0x040076DF RID: 30431
		public Image BkImage;

		// Token: 0x040076E0 RID: 30432
		public Image Info;

		// Token: 0x040076E1 RID: 30433
		public Transform ItemTrans;

		// Token: 0x040076E2 RID: 30434
		public UIText Name;

		// Token: 0x040076E3 RID: 30435
		public UIText Content;

		// Token: 0x040076E4 RID: 30436
		public Image OwnImg;

		// Token: 0x040076E5 RID: 30437
		public UIHIBtn ItemBtn;

		// Token: 0x040076E6 RID: 30438
		public UIButton Ownbtn;

		// Token: 0x040076E7 RID: 30439
		public UIButton BuyUseBtn;

		// Token: 0x040076E8 RID: 30440
		public uButtonScale OwnBtnScale;

		// Token: 0x040076E9 RID: 30441
		public RectTransform BuyTrans;

		// Token: 0x040076EA RID: 30442
		public RectTransform BuyUseTextTrans;

		// Token: 0x040076EB RID: 30443
		public RectTransform NameRect;

		// Token: 0x040076EC RID: 30444
		public RectTransform ContentRect;

		// Token: 0x040076ED RID: 30445
		public RectTransform OwnerTextRect;

		// Token: 0x040076EE RID: 30446
		public Transform AutouseTrans;

		// Token: 0x040076EF RID: 30447
		public Image Currency;

		// Token: 0x040076F0 RID: 30448
		public Image BuyUseImage;

		// Token: 0x040076F1 RID: 30449
		public UIText Owner;

		// Token: 0x040076F2 RID: 30450
		public UIText OwnerUse;

		// Token: 0x040076F3 RID: 30451
		public UIText Price;

		// Token: 0x040076F4 RID: 30452
		public UIText BuyUseText;

		// Token: 0x040076F5 RID: 30453
		public ushort ItemID;

		// Token: 0x040076F6 RID: 30454
		public ushort ItemSN;

		// Token: 0x040076F7 RID: 30455
		public uint ItemPrice;
	}

	// Token: 0x02000819 RID: 2073
	private struct _BagTag
	{
		// Token: 0x040076F8 RID: 30456
		public CanvasGroup Alpha;

		// Token: 0x040076F9 RID: 30457
		public Image Icon;
	}

	// Token: 0x0200081A RID: 2074
	private struct _ObjTag
	{
		// Token: 0x040076FA RID: 30458
		public Image Background;

		// Token: 0x040076FB RID: 30459
		public Image AlphaImage;

		// Token: 0x040076FC RID: 30460
		public CanvasGroup Alpha;

		// Token: 0x040076FD RID: 30461
		public UIText Title;
	}

	// Token: 0x0200081B RID: 2075
	private enum eBagSprite
	{
		// Token: 0x040076FF RID: 30463
		BageOn,
		// Token: 0x04007700 RID: 30464
		DiamondOn,
		// Token: 0x04007701 RID: 30465
		AllianceOn,
		// Token: 0x04007702 RID: 30466
		BageTagOff,
		// Token: 0x04007703 RID: 30467
		BageTagOn,
		// Token: 0x04007704 RID: 30468
		ObjectBagOff,
		// Token: 0x04007705 RID: 30469
		ObjectBagOn,
		// Token: 0x04007706 RID: 30470
		ObjectDiamondOff,
		// Token: 0x04007707 RID: 30471
		ObjectDiamondOn,
		// Token: 0x04007708 RID: 30472
		ObjectAllianceOff,
		// Token: 0x04007709 RID: 30473
		ObjectAllianceOn,
		// Token: 0x0400770A RID: 30474
		OwnerDisableBtn,
		// Token: 0x0400770B RID: 30475
		OwnerBtn,
		// Token: 0x0400770C RID: 30476
		UseBtn,
		// Token: 0x0400770D RID: 30477
		BuyBtn,
		// Token: 0x0400770E RID: 30478
		BageBack,
		// Token: 0x0400770F RID: 30479
		DiamondBack,
		// Token: 0x04007710 RID: 30480
		AllianceBack,
		// Token: 0x04007711 RID: 30481
		BageTitleIcon,
		// Token: 0x04007712 RID: 30482
		DiamondTitleIcon,
		// Token: 0x04007713 RID: 30483
		AllianceTitleIcon,
		// Token: 0x04007714 RID: 30484
		BageTitleBack,
		// Token: 0x04007715 RID: 30485
		DiamondTitleBack,
		// Token: 0x04007716 RID: 30486
		AllianceTitleBack,
		// Token: 0x04007717 RID: 30487
		StockDiamond
	}

	// Token: 0x0200081C RID: 2076
	protected enum ClickType
	{
		// Token: 0x04007719 RID: 30489
		BagTag,
		// Token: 0x0400771A RID: 30490
		ShopTag,
		// Token: 0x0400771B RID: 30491
		AllianceTag,
		// Token: 0x0400771C RID: 30492
		Close,
		// Token: 0x0400771D RID: 30493
		Tab1,
		// Token: 0x0400771E RID: 30494
		Tab2,
		// Token: 0x0400771F RID: 30495
		Tab3,
		// Token: 0x04007720 RID: 30496
		Tab4,
		// Token: 0x04007721 RID: 30497
		Tab5,
		// Token: 0x04007722 RID: 30498
		Use,
		// Token: 0x04007723 RID: 30499
		Buy,
		// Token: 0x04007724 RID: 30500
		AutoUse,
		// Token: 0x04007725 RID: 30501
		AddStock,
		// Token: 0x04007726 RID: 30502
		ItemInfo,
		// Token: 0x04007727 RID: 30503
		Gift,
		// Token: 0x04007728 RID: 30504
		None
	}

	// Token: 0x0200081D RID: 2077
	protected enum UIControl
	{
		// Token: 0x0400772A RID: 30506
		BackImage,
		// Token: 0x0400772B RID: 30507
		Stock,
		// Token: 0x0400772C RID: 30508
		BagTag,
		// Token: 0x0400772D RID: 30509
		ObjTag,
		// Token: 0x0400772E RID: 30510
		Image,
		// Token: 0x0400772F RID: 30511
		Message,
		// Token: 0x04007730 RID: 30512
		ScrollContent,
		// Token: 0x04007731 RID: 30513
		Close,
		// Token: 0x04007732 RID: 30514
		Item,
		// Token: 0x04007733 RID: 30515
		SpriteArray
	}

	// Token: 0x0200081E RID: 2078
	protected enum ItemSubControl
	{
		// Token: 0x04007735 RID: 30517
		ObjPic,
		// Token: 0x04007736 RID: 30518
		Own,
		// Token: 0x04007737 RID: 30519
		Buy,
		// Token: 0x04007738 RID: 30520
		Name,
		// Token: 0x04007739 RID: 30521
		Content,
		// Token: 0x0400773A RID: 30522
		AutoUse
	}
}
