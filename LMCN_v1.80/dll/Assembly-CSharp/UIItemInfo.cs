using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200056C RID: 1388
public class UIItemInfo : IMotionUpdate, UILoadImageHander, IUIButtonClickHandler, IUICalculatorHandler, IUIUnitRSliderHandler
{
	// Token: 0x06001BA9 RID: 7081 RVA: 0x00310724 File Offset: 0x0030E924
	public void Load()
	{
		UnityEngine.Object @object = GUIManager.Instance.m_ManagerAssetBundle.Load("UIItemInfo");
		if (@object == null)
		{
			return;
		}
		Font ttffont = GUIManager.Instance.GetTTFFont();
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(@object);
		gameObject.transform.SetParent(GUIManager.Instance.m_WindowTopLayer, false);
		gameObject.SetActive(false);
		this.m_RectTransform = (RectTransform)gameObject.transform;
		Transform child = gameObject.transform.GetChild(0);
		this.m_Background = child.GetComponent<UIButton>();
		this.m_Background.SoundIndex = byte.MaxValue;
		this.m_Background.m_Handler = this;
		child.GetComponent<CustomImage>().hander = this;
		RectTransform component;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			component = child.GetComponent<RectTransform>();
			component.offsetMin = new Vector2(component.offsetMin.x - GUIManager.Instance.IPhoneX_DeltaX, component.offsetMin.y);
			component.offsetMax = new Vector2(component.offsetMax.x + GUIManager.Instance.IPhoneX_DeltaX, component.offsetMax.y);
		}
		this.m_InfoPanel = (RectTransform)gameObject.transform.GetChild(1);
		this.m_InfoPanel.GetComponent<CustomImage>().hander = this;
		child = this.m_InfoPanel.GetChild(0);
		child.GetChild(0).GetComponent<CustomImage>().hander = this;
		child.GetChild(1).GetComponent<CustomImage>().hander = this;
		child.GetChild(2).GetComponent<CustomImage>().hander = this;
		child = this.m_InfoPanel.GetChild(1);
		this.m_ItemBtn = child.GetComponent<UIHIBtn>();
		GUIManager.Instance.InitianHeroItemImg(child, eHeroOrItem.Item, 0, 0, 0, 0, false, false, true, false);
		child = this.m_InfoPanel.GetChild(2);
		this.m_Name = child.GetComponent<UIText>();
		this.m_Name.font = ttffont;
		child = this.m_InfoPanel.GetChild(3);
		this.m_OwnedText = child.GetComponent<UIText>();
		this.m_OwnedText.font = ttffont;
		child = this.m_InfoPanel.GetChild(4);
		this.KindText = child.GetComponent<UIText>();
		this.KindText.font = ttffont;
		child = this.m_InfoPanel.GetChild(5);
		this.m_Properties = child.GetComponent<UIText>();
		this.m_Properties.font = ttffont;
		child = this.m_InfoPanel.GetChild(6);
		this.m_Info = child.GetComponent<UIText>();
		this.m_Info.font = ttffont;
		child = this.m_InfoPanel.GetChild(7);
		this.m_Button1 = child.GetComponent<UIButton>();
		this.m_Button1.m_Handler = this;
		child.GetComponent<CustomImage>().hander = this;
		this.Gleam = child.GetChild(0).GetComponent<CanvasGroup>();
		child.GetChild(0).GetComponent<CustomImage>().hander = this;
		child.GetChild(1).GetComponent<CustomImage>().hander = this;
		component = child.GetComponent<RectTransform>();
		Vector2 vector = component.anchoredPosition;
		this.OriginBtnRect[0].x = vector.x;
		this.OriginBtnRect[0].y = vector.y;
		vector = component.sizeDelta;
		this.OriginBtnRect[0].width = vector.x;
		this.OriginBtnRect[0].height = vector.y;
		for (int i = 1; i < child.childCount; i++)
		{
			component = child.GetChild(i).GetComponent<RectTransform>();
			vector = component.anchoredPosition;
			this.OriginBtnRect[i].x = vector.x;
			this.OriginBtnRect[i].y = vector.y;
			vector = component.sizeDelta;
			this.OriginBtnRect[i].width = vector.x;
			this.OriginBtnRect[i].height = vector.y;
		}
		child = this.m_InfoPanel.GetChild(8);
		this.m_Button2 = child.GetComponent<UIButton>();
		this.m_Button2.m_Handler = this;
		child.GetComponent<CustomImage>().hander = this;
		component = child.GetComponent<RectTransform>();
		vector = component.anchoredPosition;
		this.OriginBtnRect[5].x = vector.x;
		this.OriginBtnRect[5].y = vector.y;
		vector = component.sizeDelta;
		this.OriginBtnRect[5].width = vector.x;
		this.OriginBtnRect[5].height = vector.y;
		for (int j = 0; j < child.childCount; j++)
		{
			component = child.GetChild(j).GetComponent<RectTransform>();
			vector = component.anchoredPosition;
			this.OriginBtnRect[j + 6].x = vector.x;
			this.OriginBtnRect[j + 6].y = vector.y;
			vector = component.sizeDelta;
			this.OriginBtnRect[j + 6].width = vector.x;
			this.OriginBtnRect[j + 6].height = vector.y;
		}
		if (GUIManager.Instance.m_UICanvas.GetComponent<RectTransform>().sizeDelta.x / GUIManager.Instance.m_UICanvas.scaleFactor <= 853f)
		{
			Vector2 anchoredPosition = this.m_InfoPanel.anchoredPosition;
			anchoredPosition.x = -32.5f;
			this.m_InfoPanel.anchoredPosition = anchoredPosition;
		}
		this.OriginBtnRect[8].x = this.m_InfoPanel.anchoredPosition.x;
		this.OriginBtnRect[8].y = this.m_InfoPanel.anchoredPosition.y;
		child = this.m_Button1.transform.GetChild(1);
		this.m_CoinIcon = child.GetComponent<Image>();
		child = this.m_Button1.transform.GetChild(2);
		this.m_TotalText = child.GetComponent<UIText>();
		this.m_TotalText.font = ttffont;
		child = this.m_Button1.transform.GetChild(3);
		this.m_Price = child.GetComponent<UIText>();
		this.m_Price.font = ttffont;
		child = this.m_Button1.transform.GetChild(4);
		this.m_ButtonText1 = child.GetComponent<UIText>();
		this.m_ButtonText1.font = ttffont;
		child = this.m_Button2.transform.GetChild(0);
		this.m_UseIcon = child.GetComponent<Image>();
		child = this.m_Button2.transform.GetChild(1);
		this.m_ButtonText2 = child.GetComponent<UIText>();
		this.m_ButtonText2.font = ttffont;
		this.m_QuantityPanel = (RectTransform)this.m_InfoPanel.GetChild(9);
		this.m_MaxQtyText = this.m_InfoPanel.GetChild(9).GetChild(0).GetChild(0).GetComponent<UIText>();
		this.m_SlashRect = this.m_InfoPanel.GetChild(9).GetChild(0).GetChild(1).GetComponent<RectTransform>();
		this.m_SlashRect.GetComponent<CustomImage>().hander = this;
		this.m_MaxQtyText.font = ttffont;
		this.synthesisInst = null;
		this.Cstr = StringManager.Instance.SpawnString(30);
		this.NameStr = StringManager.Instance.SpawnString(80);
		this.PropertiesStr = StringManager.Instance.SpawnString(200);
		this.OwnedStr = StringManager.Instance.SpawnString(30);
		this.MaxQtyStr = StringManager.Instance.SpawnString(30);
		this.PriceStr = StringManager.Instance.SpawnString(30);
		this.ItemInfoMotion = new EasingEffect();
		this.ItemInfoMotion.Motion = this;
	}

	// Token: 0x06001BAA RID: 7082 RVA: 0x00310F1C File Offset: 0x0030F11C
	public void Unload()
	{
		if (this.m_RectTransform == null)
		{
			return;
		}
		UnityEngine.Object.Destroy(this.m_RectTransform.gameObject);
		this.m_RectTransform = null;
		this.m_Background = null;
		this.m_InfoPanel = null;
		this.m_ItemBtn = null;
		this.m_Name = null;
		this.m_OwnedText = null;
		this.m_Properties = null;
		this.m_Info = null;
		this.m_Button1 = null;
		this.m_Button2 = null;
		this.m_CoinIcon = null;
		this.m_TotalText = null;
		this.m_Price = null;
		this.m_ButtonText1 = null;
		this.m_ButtonText2 = null;
		this.m_QuantityPanel = null;
		StringManager.Instance.DeSpawnString(this.Cstr);
		StringManager.Instance.DeSpawnString(this.NameStr);
		StringManager.Instance.DeSpawnString(this.PropertiesStr);
		StringManager.Instance.DeSpawnString(this.PriceStr);
		StringManager.Instance.DeSpawnString(this.MaxQtyStr);
		StringManager.Instance.DeSpawnString(this.OwnedStr);
		GUIManager.Instance.ClearCalculator();
	}

	// Token: 0x06001BAB RID: 7083 RVA: 0x0031102C File Offset: 0x0030F22C
	public void OnButtonClick(UIButton sender)
	{
		DataManager instance = DataManager.Instance;
		switch (sender.m_BtnID1)
		{
		case 1:
			this.Hide();
			break;
		case 2:
			switch (this.m_eItemInfo)
			{
			case EUIItemInfo.ItemList:
				if (sender.m_BtnID2 == 0)
				{
					GUIManager.Instance.m_ItemInfo.Show(EUIItemInfo.SellItem, this.m_ItemBtn.HIID, 0, 0);
				}
				else if (sender.m_BtnID2 == 1)
				{
					instance.UseItem(this.m_ItemID, 1, 0, 0, 0, 0u, string.Empty, true);
					this.Hide();
				}
				else if (sender.m_BtnID2 == 2)
				{
					GUIManager.Instance.OpenMenu(EGUIWindow.UI_PetStoneTrans, (int)this.m_ItemID, 0, false, true, false);
					this.Hide();
				}
				else
				{
					DataManager.Instance.UseItem(this.m_ItemID, 1, 0, 0, 0, 0u, string.Empty, true);
					this.Hide();
				}
				break;
			case EUIItemInfo.SellItem:
				if (this.m_Quantity > 0)
				{
					instance.SendSellItem(this.m_ItemBtn.HIID, this.m_Quantity);
				}
				this.Hide();
				break;
			case EUIItemInfo.HeroEquip:
			{
				CurHeroData curHeroData = instance.curHeroData.Find((uint)this.m_HeroID);
				int curItemQuantity = (int)instance.GetCurItemQuantity(this.m_ItemBtn.HIID, 0);
				if (this.m_EquipPos == 0 || (curHeroData.Equip >> (int)(this.m_EquipPos - 1) & 1) != 0)
				{
					this.Hide();
				}
				else if (curItemQuantity > 0)
				{
					Equip recordByKey = instance.EquipTable.GetRecordByKey(this.m_ItemBtn.HIID);
					if (curHeroData.Level >= recordByKey.NeedLv)
					{
						eHeroState heroState = instance.GetHeroState(this.m_HeroID);
						if (instance.GetLeaderID() == this.m_HeroID && (heroState == eHeroState.Dead || heroState == eHeroState.Captured))
						{
							GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(889u), 255, true);
						}
						else
						{
							instance.SendHeroPutOnEq(this.m_HeroID, this.m_EquipPos);
						}
						this.synthesisInst = (GUIManager.Instance.FindMenu(EGUIWindow.UI_Synthesis) as UISynthesis);
						if (this.synthesisInst != null)
						{
							this.synthesisInst.OnButtonClick(this.synthesisInst.m_ExiteBtn);
							this.synthesisInst = null;
						}
						this.Hide();
					}
				}
				else if (curItemQuantity == 0)
				{
					this.m_Background.gameObject.SetActive(false);
					this.m_ButtonText1.text = instance.mStringTable.GetStringByID(150u);
					this.UpdateSynthesis();
					Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
					door.OpenMenu(EGUIWindow.UI_Synthesis, (int)this.m_ItemBtn.HIID, 0, false);
				}
				break;
			}
			}
			break;
		case 3:
			GUIManager.Instance.m_UICalculator.m_CalculatorHandler = this;
			GUIManager.Instance.m_UICalculator.OpenCalculator(this.slider.MaxValue, this.slider.Value, 290.22f, -132.9f, this.slider, 0L);
			break;
		}
	}

	// Token: 0x06001BAC RID: 7084 RVA: 0x00311360 File Offset: 0x0030F560
	public void UpdateSynthesis()
	{
		DataManager instance = DataManager.Instance;
		CurHeroData curHeroData = instance.curHeroData.Find((uint)this.m_HeroID);
		Equip recordByKey = instance.EquipTable.GetRecordByKey(this.m_ItemBtn.HIID);
		int curItemQuantity = (int)instance.GetCurItemQuantity(this.m_ItemBtn.HIID, 0);
		if (curItemQuantity > 0)
		{
			if (curHeroData.Level >= recordByKey.NeedLv)
			{
				this.m_Button1.interactable = true;
				this.m_ButtonText1.color = Color.white;
				this.Gleam.gameObject.SetActive(true);
				MotionEffect.SetStack(this.ItemInfoMotion);
				this.GleamTime = 0f;
			}
			else
			{
				this.m_Button1.interactable = false;
				this.m_ButtonText1.color = Color.gray;
			}
			this.m_ButtonText1.text = instance.mStringTable.GetStringByID(150u);
			if (this.m_SynthesisKind == 1)
			{
				Vector2 startPos = this.StartPos;
				this.StartPos = this.DestPos;
				this.DestPos = startPos;
				UISynthesis uisynthesis = GUIManager.Instance.FindMenu(EGUIWindow.UI_Synthesis) as UISynthesis;
				if (uisynthesis != null)
				{
					uisynthesis.m_MovingExit = true;
				}
			}
			else
			{
				this.DelayCloseSynthesis = 1;
			}
		}
		else
		{
			this.m_Button1.interactable = false;
			this.m_ButtonText1.color = Color.red;
			if (recordByKey.SyntheticParts[0].SyntheticItem == 0)
			{
				this.m_ButtonText1.text = instance.mStringTable.GetStringByID(236u);
			}
			else
			{
				this.m_ButtonText1.text = instance.mStringTable.GetStringByID(235u);
			}
		}
		this.OwnedStr.ClearString();
		this.OwnedStr.IntToFormat((long)curItemQuantity, 1, true);
		this.OwnedStr.AppendFormat(instance.mStringTable.GetStringByID(79u));
		this.m_OwnedText.text = this.OwnedStr.ToString();
		this.m_OwnedText.SetAllDirty();
		this.m_OwnedText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001BAD RID: 7085 RVA: 0x0031157C File Offset: 0x0030F77C
	public void Show(EUIItemInfo eItemInfo, ushort ItemID, ushort HeroID = 0, byte EquipPos = 0)
	{
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		Equip recordByKey = instance.EquipTable.GetRecordByKey(ItemID);
		this.m_eItemInfo = eItemInfo;
		this.m_ItemID = ItemID;
		if (instance2.FindMenu(EGUIWindow.UI_Synthesis) == null)
		{
			this.m_HeroID = HeroID;
			this.m_EquipPos = EquipPos;
		}
		if (recordByKey.EquipKey == ItemID)
		{
			ushort curItemQuantity = instance.GetCurItemQuantity(ItemID, 0);
			Vector2 vector = Vector2.zero;
			Color color = Color.white;
			this.m_RectTransform.SetSiblingIndex(2);
			this.m_RectTransform.gameObject.SetActive(true);
			instance2.ChangeHeroItemImg(this.m_ItemBtn.transform, eHeroOrItem.Item, ItemID, 0, 0, 0);
			UIItemInfo.SetNameProperties(this.m_Name, this.m_Properties, this.NameStr, this.PropertiesStr, ref recordByKey, null);
			EItemType eitemType = (EItemType)(recordByKey.EquipKind - 1);
			switch (eitemType)
			{
			case EItemType.EIT_SingleNumSynEquip:
			case EItemType.EIT_MultiNumSynEquip:
				this.KindText.text = instance.mStringTable.GetStringByID(886u);
				break;
			case EItemType.EIT_SynBook:
				this.KindText.text = instance.mStringTable.GetStringByID(255u);
				break;
			case EItemType.EIT_SynBaseEquip:
				this.KindText.text = instance.mStringTable.GetStringByID(254u);
				break;
			case EItemType.EIT_HeroStone:
				this.KindText.text = instance.mStringTable.GetStringByID(256u);
				break;
			case EItemType.EIT_Consumables:
				this.KindText.text = instance.mStringTable.GetStringByID(253u);
				break;
			default:
				if (eitemType != EItemType.EIT_EnhanceStone)
				{
					this.KindText.text = string.Empty;
				}
				else
				{
					this.KindText.text = instance.mStringTable.GetStringByID(16050u);
				}
				break;
			case EItemType.EIT_CaseByCase:
			{
				ECaseByCaseType ecaseByCaseType = (ECaseByCaseType)recordByKey.PropertiesInfo[0].Propertieskey;
				if (ecaseByCaseType == ECaseByCaseType.ECBCT_PetCore)
				{
					this.KindText.text = instance.mStringTable.GetStringByID(14654u);
				}
				else if (ecaseByCaseType == ECaseByCaseType.ECBCT_PetMaterial)
				{
					this.KindText.text = instance.mStringTable.GetStringByID(879u);
				}
				else
				{
					this.KindText.text = string.Empty;
				}
				break;
			}
			}
			this.OwnedStr.ClearString();
			this.OwnedStr.IntToFormat((long)curItemQuantity, 1, true);
			this.OwnedStr.AppendFormat(instance.mStringTable.GetStringByID(79u));
			this.m_OwnedText.text = this.OwnedStr.ToString();
			this.m_OwnedText.SetAllDirty();
			this.m_OwnedText.cachedTextGenerator.Invalidate();
			if (eItemInfo == EUIItemInfo.SellItem || (recordByKey.EquipKind == 6 && (recordByKey.PropertiesInfo[0].Propertieskey == 9 || recordByKey.PropertiesInfo[0].Propertieskey == 5 || recordByKey.PropertiesInfo[0].Propertieskey == 6)) || (recordByKey.EquipKind == 10 && (recordByKey.PropertiesInfo[0].Propertieskey == 45 || recordByKey.PropertiesInfo[0].Propertieskey == 46)) || recordByKey.EquipKind == 29)
			{
				this.m_Info.text = string.Empty;
			}
			else
			{
				this.m_Info.text = instance.mStringTable.GetStringByID((uint)recordByKey.EquipInfo);
			}
			this.m_Button1.interactable = true;
			if (instance2.IsArabic && this.m_Price.rectTransform.localScale.x < 0f)
			{
				this.m_Price.alignment = TextAnchor.MiddleRight;
			}
			else
			{
				this.m_Price.alignment = TextAnchor.MiddleLeft;
			}
			switch (eItemInfo)
			{
			case EUIItemInfo.ItemList:
				if (recordByKey.RecoverPrice == 0u)
				{
					this.m_Button1.gameObject.SetActive(false);
					if (recordByKey.EquipKind - 1 == 5 && (byte)recordByKey.PropertiesInfo[0].Propertieskey == 4)
					{
						this.m_Button2.gameObject.SetActive(true);
						this.m_ButtonText2.text = instance.mStringTable.GetStringByID(94u);
						this.LoadCustomImage(this.m_UseIcon, "UI_main_icon_001", null);
						this.m_Button2.m_BtnID2 = 1;
					}
					else
					{
						ushort propertieskey = recordByKey.PropertiesInfo[0].Propertieskey;
						if (recordByKey.EquipKind - 1 == 5 && propertieskey == 6)
						{
							this.m_Button2.gameObject.SetActive(true);
							this.m_ButtonText2.text = instance.mStringTable.GetStringByID(94u);
							this.LoadCustomImage(this.m_UseIcon, "UI_main_icon_001", null);
							this.m_Button2.m_BtnID2 = 1;
						}
						else
						{
							this.m_Button2.gameObject.SetActive(false);
						}
					}
				}
				else
				{
					this.m_Button1.gameObject.SetActive(true);
					this.m_Button2.gameObject.SetActive(false);
					eitemType = (EItemType)(recordByKey.EquipKind - 1);
					switch (eitemType)
					{
					case EItemType.EIT_SynBaseEquip:
					{
						RectTransform rectTransform = this.m_Button2.transform as RectTransform;
						vector = rectTransform.anchoredPosition;
						rectTransform = (this.m_Button1.transform as RectTransform);
						rectTransform.anchoredPosition = vector;
						break;
					}
					default:
						if (eitemType == EItemType.EIT_EnhanceStone)
						{
							this.m_Button2.m_BtnID2 = 2;
							this.m_Button2.gameObject.SetActive(true);
							this.m_ButtonText2.text = instance.mStringTable.GetStringByID(14586u);
							this.LoadCustomImage(this.m_UseIcon, "UI_main_icon_001", null);
						}
						break;
					case EItemType.EIT_Consumables:
					{
						ushort propertieskey2 = recordByKey.PropertiesInfo[0].Propertieskey;
						this.m_Button2.gameObject.SetActive(propertieskey2 == 2 || (propertieskey2 >= 4 && propertieskey2 <= 8));
						this.m_ButtonText2.text = instance.mStringTable.GetStringByID(94u);
						this.LoadCustomImage(this.m_UseIcon, "UI_main_icon_001", null);
						this.m_Button2.m_BtnID2 = 1;
						break;
					}
					}
					this.m_CoinIcon.gameObject.SetActive(true);
					this.m_TotalText.gameObject.SetActive(false);
					this.PriceStr.ClearString();
					this.PriceStr.IntToFormat((long)((ulong)recordByKey.RecoverPrice), 1, true);
					this.PriceStr.AppendFormat("{0}");
					this.m_Price.text = this.PriceStr.ToString();
					this.m_Price.SetAllDirty();
					this.m_Price.cachedTextGenerator.Invalidate();
					this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(80u);
					if (!this.m_Button2.gameObject.activeSelf)
					{
						RectTransform rectTransform = this.m_Button2.transform as RectTransform;
						vector = rectTransform.anchoredPosition;
						rectTransform = (this.m_Button1.transform as RectTransform);
						rectTransform.anchoredPosition = vector;
					}
				}
				this.m_QuantityPanel.gameObject.SetActive(false);
				break;
			case EUIItemInfo.SellItem:
			{
				if (this.slider == null)
				{
					RectTransform rectTransform2 = this.m_QuantityPanel.GetChild(0) as RectTransform;
					Transform child = this.m_QuantityPanel.GetChild(0);
					this.slider = this.m_QuantityPanel.gameObject.AddComponent<UnitResourcesSlider>();
					instance2.InitUnitResourcesSlider(this.slider.transform, eUnitSlider.AutoUse, 0u, 0u, 1f);
					child.SetParent(this.m_InfoPanel.transform);
					instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnLessen, -110f, 22f, 70f, 60f, 0f, 0f);
					instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 29.5f, 22f, 172f, 19f, 1f, (float)curItemQuantity);
					instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnIncrease, 158f, 22f, 70f, 60f, 0f, 0f);
					instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.Input, -17.7f, 64.7f, 81f, 32f, 0f, 0f);
					this.slider.m_Handler = this;
					this.slider.m_inputText.fontSize = 22;
					this.slider.m_inputText.alignment = TextAnchor.MiddleRight;
					this.slider.BtnInputText.m_Handler = this;
					this.slider.BtnInputText.m_BtnID1 = 3;
					child.SetParent(this.m_QuantityPanel.transform);
					if (instance2.IsArabic)
					{
						this.m_SlashRect.localScale = new Vector3(-1f, 1f, 1f);
					}
				}
				else
				{
					instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 29.5f, 22f, 172f, 19f, 0f, (float)curItemQuantity);
				}
				this.m_Info.enabled = false;
				this.Cstr.ClearString();
				this.slider.m_slider.value = 1.0;
				StringManager.IntToStr(this.Cstr, 1L, 1, true);
				this.slider.m_inputText.text = this.Cstr.ToString();
				this.MaxQtyStr.ClearString();
				this.MaxQtyStr.IntToFormat((long)curItemQuantity, 1, true);
				this.MaxQtyStr.AppendFormat("{0}");
				this.m_MaxQtyText.text = this.MaxQtyStr.ToString();
				this.m_MaxQtyText.SetAllDirty();
				this.m_MaxQtyText.cachedTextGenerator.Invalidate();
				this.m_Button1.gameObject.SetActive(true);
				this.m_Button2.gameObject.SetActive(false);
				RectTransform rectTransform = (RectTransform)this.m_Button1.transform;
				vector.Set(187f, -93.5f);
				rectTransform.anchoredPosition = vector;
				vector.Set(290f, 81f);
				rectTransform.sizeDelta = vector;
				this.m_CoinIcon.gameObject.SetActive(true);
				this.m_TotalText.gameObject.SetActive(true);
				this.m_TotalText.text = DataManager.Instance.mStringTable.GetStringByID(81u);
				this.PriceStr.ClearString();
				this.PriceStr.IntToFormat((long)((ulong)recordByKey.RecoverPrice), 1, true);
				this.PriceStr.AppendFormat("{0}");
				this.m_Price.text = this.PriceStr.ToString();
				this.m_Price.SetAllDirty();
				this.m_Price.cachedTextGenerator.Invalidate();
				this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(82u);
				vector.Set(123f, -8f);
				this.m_CoinIcon.rectTransform.anchoredPosition = vector;
				vector.x = 163f;
				vector = this.m_Price.ArabicFixPos(vector);
				this.m_Price.rectTransform.anchoredPosition = vector;
				this.m_QuantityPanel.gameObject.SetActive(true);
				break;
			}
			case EUIItemInfo.HeroEquip:
			{
				CurHeroData curHeroData = instance.curHeroData.Find((uint)this.m_HeroID);
				this.m_Button1.gameObject.SetActive(true);
				this.m_Button2.gameObject.SetActive(false);
				this.m_CoinIcon.gameObject.SetActive(false);
				this.m_TotalText.gameObject.SetActive(false);
				this.m_QuantityPanel.gameObject.SetActive(false);
				this.PriceStr.ClearString();
				if (this.m_EquipPos == 0 || (curHeroData.Equip >> (int)(this.m_EquipPos - 1) & 1) != 0)
				{
					this.PriceStr.IntToFormat((long)recordByKey.NeedLv, 1, false);
					this.PriceStr.AppendFormat(instance.mStringTable.GetStringByID(86u));
					this.m_ButtonText1.text = instance.mStringTable.GetStringByID(3u);
				}
				else if (instance.GetCurItemQuantity(ItemID, 0) > 0)
				{
					if (curHeroData.Level >= recordByKey.NeedLv)
					{
						this.PriceStr.Append(instance.mStringTable.GetStringByID(149u));
						this.Gleam.gameObject.SetActive(true);
						MotionEffect.SetStack(this.ItemInfoMotion);
						this.GleamTime = 0f;
					}
					else
					{
						this.m_Button1.interactable = false;
						this.PriceStr.IntToFormat((long)recordByKey.NeedLv, 1, false);
						this.PriceStr.AppendFormat(instance.mStringTable.GetStringByID(86u));
						this.m_ButtonText1.color = Color.gray;
					}
					this.m_ButtonText1.text = instance.mStringTable.GetStringByID(150u);
				}
				else
				{
					this.PriceStr.IntToFormat((long)recordByKey.NeedLv, 1, false);
					this.PriceStr.AppendFormat(instance.mStringTable.GetStringByID(86u));
					if (recordByKey.SyntheticParts[0].SyntheticItem == 0)
					{
						this.m_ButtonText1.text = instance.mStringTable.GetStringByID(199u);
					}
					else
					{
						this.m_ButtonText1.text = instance.mStringTable.GetStringByID(87u);
						this.m_SynthesisKind = 1;
					}
				}
				this.m_Price.text = this.PriceStr.ToString();
				this.m_Price.SetAllDirty();
				this.m_Price.cachedTextGenerator.Invalidate();
				RectTransform rectTransform = (RectTransform)this.m_Button1.transform;
				vector.Set(187f, -93.5f);
				rectTransform.anchoredPosition = vector;
				vector.Set(290f, 81f);
				rectTransform.sizeDelta = vector;
				vector.Set(0f, -6.9f);
				vector = this.m_Price.ArabicFixPos(vector);
				this.m_Price.rectTransform.anchoredPosition = vector;
				vector = this.m_Price.rectTransform.sizeDelta;
				vector.x = 290f;
				this.m_Price.rectTransform.sizeDelta = vector;
				this.m_Price.UpdateArabicPos();
				this.m_Price.alignment = TextAnchor.MiddleCenter;
				if (curHeroData.Level >= recordByKey.NeedLv)
				{
					color = Color.yellow;
				}
				else
				{
					color = Color.red;
				}
				this.m_Price.color = color;
				this.DestPos = this.m_InfoPanel.anchoredPosition;
				this.DestPos.y = 166f;
				this.StartPos = this.m_InfoPanel.anchoredPosition;
				if (instance2.FindMenu(EGUIWindow.UI_Synthesis))
				{
					this.m_Background.gameObject.SetActive(false);
					this.UpdateSynthesis();
				}
				NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, this, false);
				break;
			}
			}
		}
		else
		{
			this.Hide();
		}
	}

	// Token: 0x06001BAE RID: 7086 RVA: 0x00312518 File Offset: 0x00310718
	public void DestroySlider()
	{
		if (this.slider == null)
		{
			return;
		}
		for (int i = this.m_QuantityPanel.transform.childCount - 2; i >= 0; i--)
		{
			UnityEngine.Object.Destroy(this.m_QuantityPanel.GetChild(i).gameObject);
		}
		UnityEngine.Object.Destroy(this.slider);
		this.slider = null;
	}

	// Token: 0x06001BAF RID: 7087 RVA: 0x00312584 File Offset: 0x00310784
	public void Hide()
	{
		if (!this.m_Background.gameObject.activeSelf)
		{
			this.m_Background.gameObject.SetActive(true);
		}
		if (!this.m_RectTransform.gameObject.activeSelf)
		{
			return;
		}
		this.m_RectTransform.gameObject.SetActive(false);
		this.m_Name.text = string.Empty;
		this.m_OwnedText.text = string.Empty;
		this.m_Properties.text = string.Empty;
		this.m_Info.text = string.Empty;
		RectTransform component = this.m_Button1.transform.GetComponent<RectTransform>();
		Vector2 vector = component.anchoredPosition;
		vector.Set(this.OriginBtnRect[0].x, this.OriginBtnRect[0].y);
		component.anchoredPosition = vector;
		vector = component.sizeDelta;
		vector.Set(this.OriginBtnRect[0].width, this.OriginBtnRect[0].height);
		component.sizeDelta = vector;
		for (int i = 1; i < this.m_Button1.transform.childCount; i++)
		{
			component = this.m_Button1.transform.GetChild(i).GetComponent<RectTransform>();
			vector = component.anchoredPosition;
			vector.Set(this.OriginBtnRect[i].x, this.OriginBtnRect[i].y);
			component.anchoredPosition = vector;
			vector = component.sizeDelta;
			vector.Set(this.OriginBtnRect[i].width, this.OriginBtnRect[i].height);
			component.sizeDelta = vector;
		}
		component = this.m_Button2.transform.GetComponent<RectTransform>();
		vector = component.anchoredPosition;
		vector.Set(this.OriginBtnRect[5].x, this.OriginBtnRect[5].y);
		component.anchoredPosition = vector;
		vector = component.sizeDelta;
		vector.Set(this.OriginBtnRect[5].width, this.OriginBtnRect[5].height);
		component.sizeDelta = vector;
		for (int j = 0; j < this.m_Button2.transform.childCount; j++)
		{
			component = this.m_Button2.transform.GetChild(j).GetComponent<RectTransform>();
			vector = component.anchoredPosition;
			vector.Set(this.OriginBtnRect[j + 6].x, this.OriginBtnRect[j + 6].y);
			component.anchoredPosition = vector;
			vector = component.sizeDelta;
			vector.Set(this.OriginBtnRect[j + 6].width, this.OriginBtnRect[j + 6].height);
			component.sizeDelta = vector;
		}
		vector = this.m_InfoPanel.anchoredPosition;
		vector.Set(this.OriginBtnRect[8].x, this.OriginBtnRect[8].y);
		this.m_InfoPanel.anchoredPosition = vector;
		if (GUIManager.Instance.IsArabic)
		{
			Vector2 vector2 = this.m_Price.rectTransform.anchoredPosition;
			vector2 = this.m_Price.ArabicFixPos(vector2);
			this.m_Price.rectTransform.anchoredPosition = vector2;
			this.m_Price.alignment = TextAnchor.MiddleRight;
			vector2 = this.m_TotalText.rectTransform.anchoredPosition;
			vector2 = this.m_TotalText.ArabicFixPos(vector2);
			this.m_TotalText.rectTransform.anchoredPosition = vector2;
		}
		else
		{
			this.m_Price.alignment = TextAnchor.MiddleLeft;
		}
		this.m_Price.color = Color.white;
		this.m_ButtonText1.color = new Color32(byte.MaxValue, 247, 153, byte.MaxValue);
		this.m_Info.enabled = true;
		this.Gleam.gameObject.SetActive(false);
		this.m_Button1.interactable = false;
		this.m_SynthesisKind = 0;
		this.DelayCloseSynthesis = 0;
		this.m_Button2.m_BtnID2 = 0;
	}

	// Token: 0x06001BB0 RID: 7088 RVA: 0x003129C0 File Offset: 0x00310BC0
	public void TextRefresh()
	{
		if (this.m_RectTransform == null || !this.m_RectTransform.gameObject.activeSelf)
		{
			return;
		}
		this.m_Name.enabled = false;
		this.m_Name.enabled = true;
		this.m_OwnedText.enabled = false;
		this.m_OwnedText.enabled = true;
		this.KindText.enabled = false;
		this.KindText.enabled = true;
		this.m_Properties.enabled = false;
		this.m_Properties.enabled = true;
		this.m_Info.enabled = false;
		this.m_Info.enabled = true;
		this.m_TotalText.enabled = false;
		this.m_TotalText.enabled = true;
		this.m_Price.enabled = false;
		this.m_Price.enabled = true;
		this.m_ButtonText1.enabled = false;
		this.m_ButtonText1.enabled = true;
		this.m_MaxQtyText.enabled = false;
		this.m_MaxQtyText.enabled = true;
		this.m_ButtonText2.enabled = false;
		this.m_ButtonText2.enabled = true;
		if (this.slider != null)
		{
			this.slider.Refresh_FontTexture();
		}
	}

	// Token: 0x06001BB1 RID: 7089 RVA: 0x00312B00 File Offset: 0x00310D00
	public static void SetNameProperties(UIText name, UIText properties, CString nameStr, CString propertiesStr, ref Equip record, CString AddionalStr = null)
	{
		DataManager instance = DataManager.Instance;
		nameStr.ClearString();
		if (propertiesStr != null)
		{
			propertiesStr.ClearString();
		}
		if (AddionalStr != null)
		{
			AddionalStr.ClearString();
		}
		bool flag = GameConstants.IsBigStyle();
		bool flag2 = false;
		EItemType eitemType = (EItemType)(record.EquipKind - 1);
		switch (eitemType)
		{
		case EItemType.EIT_SingleNumSynEquip:
		case EItemType.EIT_MultiNumSynEquip:
			nameStr.Append(instance.mStringTable.GetStringByID((uint)record.EquipName));
			if (propertiesStr != null)
			{
				CString cstring = StringManager.Instance.StaticString1024();
				for (int i = 0; i < record.PropertiesInfo.Length; i++)
				{
					if (record.PropertiesInfo[i].Propertieskey != 0)
					{
						if (i > 0)
						{
							propertiesStr.Append("\n");
						}
						int propertiesValue = (int)record.PropertiesInfo[i].PropertiesValue;
						cstring.ClearString();
						Effect recordByKey = instance.EffectData.GetRecordByKey(record.PropertiesInfo[i].Propertieskey);
						cstring.IntToFormat((long)propertiesValue, 1, false);
						cstring.AppendFormat(instance.mStringTable.GetStringByID((uint)recordByKey.String_infoID));
						propertiesStr.Append(cstring);
					}
				}
			}
			break;
		case EItemType.EIT_SynBook:
			nameStr.StringToFormat(instance.mStringTable.GetStringByID((uint)record.EquipName));
			nameStr.StringToFormat(instance.mStringTable.GetStringByID(88u));
			if (flag)
			{
				nameStr.AppendFormat("{0}{1}");
			}
			else
			{
				nameStr.AppendFormat("{0} {1}");
			}
			if (propertiesStr != null)
			{
				propertiesStr.StringToFormat(instance.mStringTable.GetStringByID(89u));
				propertiesStr.StringToFormat(instance.mStringTable.GetStringByID((uint)record.EquipName));
				propertiesStr.AppendFormat("{0}{1}");
			}
			break;
		case EItemType.EIT_SynBaseEquip:
			nameStr.StringToFormat(instance.mStringTable.GetStringByID((uint)record.EquipName));
			if (record.SyntheticParts[1].SyntheticItemNum == 1)
			{
				nameStr.StringToFormat(instance.mStringTable.GetStringByID(88u));
				nameStr.StringToFormat(instance.mStringTable.GetStringByID(90u));
				if (flag)
				{
					nameStr.AppendFormat("{0}{1}{2}");
				}
				else
				{
					nameStr.AppendFormat("{0} {1} {2}");
				}
			}
			else
			{
				nameStr.StringToFormat(instance.mStringTable.GetStringByID(90u));
				if (flag)
				{
					nameStr.AppendFormat("{0}{1}");
				}
				else
				{
					nameStr.AppendFormat("{0} {1}");
				}
			}
			if (propertiesStr != null)
			{
				propertiesStr.IntToFormat((long)record.SyntheticParts[0].SyntheticItemNum, 1, false);
				propertiesStr.AppendFormat(instance.mStringTable.GetStringByID(91u));
				propertiesStr.StringToFormat(instance.mStringTable.GetStringByID(89u));
				propertiesStr.StringToFormat(instance.mStringTable.GetStringByID((uint)record.EquipName));
				if (record.SyntheticParts[1].SyntheticItemNum == 1)
				{
					propertiesStr.StringToFormat(instance.mStringTable.GetStringByID(88u));
					propertiesStr.AppendFormat("{0}{1}{2}");
				}
				else
				{
					propertiesStr.AppendFormat("{0}{1}");
				}
			}
			break;
		case EItemType.EIT_HeroStone:
		{
			nameStr.StringToFormat(instance.mStringTable.GetStringByID((uint)record.EquipName));
			nameStr.StringToFormat(instance.mStringTable.GetStringByID(92u));
			if (flag)
			{
				nameStr.AppendFormat("{0}{1}");
			}
			else
			{
				nameStr.AppendFormat("{0} {1}");
			}
			Hero recordByKey2 = instance.HeroTable.GetRecordByKey(record.SyntheticParts[0].SyntheticItem);
			if (recordByKey2.HeroKey == record.SyntheticParts[0].SyntheticItem)
			{
				if (propertiesStr != null)
				{
					int num = 0;
					int num2 = ((int)recordByKey2.defaultStar >= instance.Medal.Length) ? instance.Medal.Length : ((int)recordByKey2.defaultStar);
					for (int j = 0; j < num2; j++)
					{
						num += (int)instance.Medal[j];
					}
					propertiesStr.IntToFormat((long)num, 1, false);
					propertiesStr.StringToFormat(instance.mStringTable.GetStringByID((uint)record.EquipName));
					propertiesStr.AppendFormat(instance.mStringTable.GetStringByID(93u));
				}
				if (AddionalStr != null)
				{
					AddionalStr.Append("\n");
					AddionalStr.StringToFormat(instance.mStringTable.GetStringByID(367u));
					AddionalStr.StringToFormat(instance.mStringTable.GetStringByID(3841u + (uint)recordByKey2.SoldierKind));
					AddionalStr.AppendFormat("{0} : <color=#FFC961FF>{1}</color>\n");
					AddionalStr.StringToFormat(instance.mStringTable.GetStringByID(369u));
					AddionalStr.AppendFormat("{0}:\n");
					CString cstring2 = StringManager.Instance.StaticString1024();
					for (int k = 0; k < 3; k++)
					{
						ushort inKey;
						byte rankStr;
						if (k == 0)
						{
							inKey = recordByKey2.GroupSkill2;
							rankStr = 2;
						}
						else if (k == 1)
						{
							inKey = recordByKey2.GroupSkill3;
							rankStr = 4;
						}
						else
						{
							inKey = recordByKey2.GroupSkill4;
							rankStr = 7;
						}
						Skill recordByKey3 = instance.SkillTable.GetRecordByKey(inKey);
						cstring2.ClearString();
						GUIManager.Instance.m_SkillInfo.GetLegionHintStr(5, ref recordByKey3, ref cstring2, rankStr);
						cstring2.Append("\n");
						AddionalStr.Append(cstring2);
					}
					AddionalStr.StringToFormat(instance.mStringTable.GetStringByID(61u));
					AddionalStr.AppendFormat("<color=#FFFF00FF>{0}</color>");
				}
			}
			break;
		}
		case EItemType.EIT_Consumables:
			nameStr.Append(instance.mStringTable.GetStringByID((uint)record.EquipName));
			if (propertiesStr != null)
			{
				propertiesStr.Append(instance.mStringTable.GetStringByID((uint)record.EquipInfo));
			}
			break;
		case EItemType.EIT_SellItem:
			nameStr.Append(instance.mStringTable.GetStringByID((uint)record.EquipName));
			if (propertiesStr != null)
			{
				propertiesStr.IntToFormat((long)((ulong)record.RecoverPrice), 1, false);
				propertiesStr.AppendFormat(instance.mStringTable.GetStringByID(118u));
			}
			break;
		default:
			if (eitemType != EItemType.EIT_EnhanceStone)
			{
				nameStr.Append(instance.mStringTable.GetStringByID((uint)record.EquipName));
			}
			else
			{
				nameStr.StringToFormat(instance.mStringTable.GetStringByID((uint)record.EquipName));
				nameStr.StringToFormat(instance.mStringTable.GetStringByID(16072u));
				if (flag)
				{
					nameStr.AppendFormat("{0}{1}");
				}
				else
				{
					nameStr.AppendFormat("{0} {1}");
				}
				if (propertiesStr != null)
				{
					propertiesStr.Append(instance.mStringTable.GetStringByID((uint)record.EquipInfo));
				}
			}
			break;
		case EItemType.EIT_CaseByCase:
			if ((byte)record.PropertiesInfo[0].Propertieskey == 45)
			{
				flag2 = true;
				nameStr.StringToFormat(instance.mStringTable.GetStringByID((uint)record.EquipName));
				nameStr.StringToFormat(instance.mStringTable.GetStringByID(14669u));
				if (flag)
				{
					nameStr.AppendFormat("{0}{1}");
				}
				else
				{
					nameStr.AppendFormat("{0} {1}");
				}
				if (propertiesStr != null)
				{
					propertiesStr.StringToFormat(instance.mStringTable.GetStringByID((uint)record.SyntheticParts[1].SyntheticItem));
					propertiesStr.AppendFormat(instance.mStringTable.GetStringByID(11692u));
				}
			}
			else
			{
				nameStr.Append(instance.mStringTable.GetStringByID((uint)record.EquipName));
			}
			break;
		case EItemType.EIT_MaterialTreasureBox:
			if (record.PropertiesInfo[0].Propertieskey != 4 && record.PropertiesInfo[2].Propertieskey > 3)
			{
				nameStr.StringToFormat(instance.mStringTable.GetStringByID((uint)(7734 + record.PropertiesInfo[0].Propertieskey)));
				nameStr.AppendFormat(instance.mStringTable.GetStringByID(7739u));
			}
			nameStr.Append(instance.mStringTable.GetStringByID((uint)record.EquipName));
			break;
		}
		if (!flag2 && propertiesStr != null && record.EquipKind >= 10 && record.EquipKind <= 19)
		{
			propertiesStr.Append(instance.mStringTable.GetStringByID((uint)record.EquipInfo));
		}
		if (properties)
		{
			properties.text = propertiesStr.ToString();
			properties.SetAllDirty();
			properties.cachedTextGenerator.Invalidate();
			properties.cachedTextGeneratorForLayout.Invalidate();
		}
		if (name)
		{
			name.text = nameStr.ToString();
			name.SetAllDirty();
			name.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06001BB2 RID: 7090 RVA: 0x00313408 File Offset: 0x00311608
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
			if (img.sprite == null)
			{
				img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
				img.material = GUIManager.Instance.GetFrameMaterial();
			}
		}
		else
		{
			img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
			img.material = GUIManager.Instance.GetFrameMaterial();
		}
	}

	// Token: 0x06001BB3 RID: 7091 RVA: 0x003134A4 File Offset: 0x003116A4
	public void OnVauleChang(UnitResourcesSlider sender)
	{
		this.Cstr.ClearString();
		StringManager.IntToStr(this.Cstr, sender.Value, 1, true);
		sender.m_inputText.text = this.Cstr.ToString();
		sender.m_inputText.SetAllDirty();
		sender.m_inputText.cachedTextGenerator.Invalidate();
		this.m_Quantity = (ushort)sender.Value;
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(this.m_ItemBtn.HIID);
		this.PriceStr.ClearString();
		this.PriceStr.IntToFormat((long)((ulong)(recordByKey.RecoverPrice * (uint)this.m_Quantity)), 1, true);
		this.PriceStr.AppendFormat("{0}");
		this.m_Price.text = this.PriceStr.ToString();
		this.m_Price.SetAllDirty();
		this.m_Price.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001BB4 RID: 7092 RVA: 0x00313594 File Offset: 0x00311794
	public bool UpdateRun(float delta)
	{
		if (!this.m_RectTransform.gameObject.activeSelf)
		{
			return false;
		}
		if (this.DelayCloseSynthesis > 0)
		{
			this.DelayCloseSynthesis -= 1;
			if (this.DelayCloseSynthesis == 0)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door.CloseMenu(false);
				this.Show(this.m_eItemInfo, this.m_ItemID, this.m_HeroID, this.m_EquipPos);
			}
		}
		if (this.Gleam.gameObject.activeSelf)
		{
			float num = this.GleamTime / 1f;
			if (num <= 1f)
			{
				this.Gleam.alpha = 1f - num;
			}
			else if (num <= 2f)
			{
				this.Gleam.alpha = num - 1f;
			}
			else
			{
				this.GleamTime = 0f;
			}
			this.GleamTime += Time.deltaTime;
		}
		return true;
	}

	// Token: 0x06001BB5 RID: 7093 RVA: 0x00313698 File Offset: 0x00311898
	public void UpdatePosition(float delta)
	{
		if (!this.m_RectTransform.gameObject.activeSelf)
		{
			return;
		}
		float d = 0.3f;
		Vector2 anchoredPosition = this.m_InfoPanel.anchoredPosition;
		anchoredPosition.y = EasingEffect.Linear(delta, this.StartPos.y, this.DestPos.y - this.StartPos.y, d);
		this.m_InfoPanel.anchoredPosition = anchoredPosition;
	}

	// Token: 0x06001BB6 RID: 7094 RVA: 0x0031370C File Offset: 0x0031190C
	public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
	{
		URS.Value = mValue;
		URS.m_slider.value = (double)this.slider.Value;
	}

	// Token: 0x06001BB7 RID: 7095 RVA: 0x0031372C File Offset: 0x0031192C
	public void OnTextChang(UnitResourcesSlider sender)
	{
		this.Cstr.ClearString();
		StringManager.IntToStr(this.Cstr, sender.Value, 1, true);
		sender.m_inputText.text = this.Cstr.ToString();
		sender.m_inputText.SetAllDirty();
		sender.m_inputText.cachedTextGenerator.Invalidate();
		this.m_Quantity = (ushort)sender.Value;
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(this.m_ItemBtn.HIID);
		this.PriceStr.ClearString();
		this.PriceStr.IntToFormat((long)((ulong)(recordByKey.RecoverPrice * (uint)this.m_Quantity)), 1, true);
		this.PriceStr.AppendFormat("{0}");
		this.m_Price.text = this.PriceStr.ToString();
		this.m_Price.SetAllDirty();
		this.m_Price.cachedTextGenerator.Invalidate();
	}

	// Token: 0x040053D9 RID: 21465
	public RectTransform m_RectTransform;

	// Token: 0x040053DA RID: 21466
	public UIButton m_Background;

	// Token: 0x040053DB RID: 21467
	public RectTransform m_InfoPanel;

	// Token: 0x040053DC RID: 21468
	public RectTransform m_SlashRect;

	// Token: 0x040053DD RID: 21469
	public UIHIBtn m_ItemBtn;

	// Token: 0x040053DE RID: 21470
	public UIText m_Name;

	// Token: 0x040053DF RID: 21471
	public UIText m_OwnedText;

	// Token: 0x040053E0 RID: 21472
	public UIText KindText;

	// Token: 0x040053E1 RID: 21473
	public UIText m_Properties;

	// Token: 0x040053E2 RID: 21474
	public UIText m_Info;

	// Token: 0x040053E3 RID: 21475
	public UIButton m_Button1;

	// Token: 0x040053E4 RID: 21476
	public UIButton m_Button2;

	// Token: 0x040053E5 RID: 21477
	public Image m_CoinIcon;

	// Token: 0x040053E6 RID: 21478
	public Image m_UseIcon;

	// Token: 0x040053E7 RID: 21479
	public UIText m_TotalText;

	// Token: 0x040053E8 RID: 21480
	public UIText m_Price;

	// Token: 0x040053E9 RID: 21481
	public UIText m_ButtonText1;

	// Token: 0x040053EA RID: 21482
	public UIText m_MaxQtyText;

	// Token: 0x040053EB RID: 21483
	public UIText m_ButtonText2;

	// Token: 0x040053EC RID: 21484
	public RectTransform m_QuantityPanel;

	// Token: 0x040053ED RID: 21485
	public EUIItemInfo m_eItemInfo;

	// Token: 0x040053EE RID: 21486
	public ushort m_Quantity = 1;

	// Token: 0x040053EF RID: 21487
	public ushort m_HeroID;

	// Token: 0x040053F0 RID: 21488
	public byte m_EquipPos;

	// Token: 0x040053F1 RID: 21489
	private UnitResourcesSlider slider;

	// Token: 0x040053F2 RID: 21490
	private EasingEffect ItemInfoMotion;

	// Token: 0x040053F3 RID: 21491
	private CString Cstr;

	// Token: 0x040053F4 RID: 21492
	private CString NameStr;

	// Token: 0x040053F5 RID: 21493
	private CString PropertiesStr;

	// Token: 0x040053F6 RID: 21494
	private CString OwnedStr;

	// Token: 0x040053F7 RID: 21495
	private CString MaxQtyStr;

	// Token: 0x040053F8 RID: 21496
	private CString PriceStr;

	// Token: 0x040053F9 RID: 21497
	private Vector2 DestPos;

	// Token: 0x040053FA RID: 21498
	private Vector2 StartPos;

	// Token: 0x040053FB RID: 21499
	private UISynthesis synthesisInst;

	// Token: 0x040053FC RID: 21500
	private CanvasGroup Gleam;

	// Token: 0x040053FD RID: 21501
	private float GleamTime;

	// Token: 0x040053FE RID: 21502
	private byte m_SynthesisKind;

	// Token: 0x040053FF RID: 21503
	public ushort m_ItemID;

	// Token: 0x04005400 RID: 21504
	private byte DelayCloseSynthesis;

	// Token: 0x04005401 RID: 21505
	private Rect[] OriginBtnRect = new Rect[9];

	// Token: 0x0200056D RID: 1389
	private enum UIController
	{
		// Token: 0x04005403 RID: 21507
		Background,
		// Token: 0x04005404 RID: 21508
		InfoPanel
	}

	// Token: 0x0200056E RID: 1390
	private enum InfoPanel
	{
		// Token: 0x04005406 RID: 21510
		Background,
		// Token: 0x04005407 RID: 21511
		Obj,
		// Token: 0x04005408 RID: 21512
		Name,
		// Token: 0x04005409 RID: 21513
		Owner,
		// Token: 0x0400540A RID: 21514
		Kind,
		// Token: 0x0400540B RID: 21515
		Properties,
		// Token: 0x0400540C RID: 21516
		Info,
		// Token: 0x0400540D RID: 21517
		Sell,
		// Token: 0x0400540E RID: 21518
		Make,
		// Token: 0x0400540F RID: 21519
		Quantity
	}
}
