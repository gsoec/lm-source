using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020003C6 RID: 966
public class UIMerchantman : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x06001422 RID: 5154 RVA: 0x00235028 File Offset: 0x00233228
	public override void OnOpen(int arg1, int arg2)
	{
		this.Cstr_Time = StringManager.Instance.SpawnString(30);
		for (int i = 0; i < 5; i++)
		{
			this.Cstr_Resources[i] = StringManager.Instance.SpawnString(30);
		}
		for (int j = 0; j < 5; j++)
		{
			this.Cstr_ItemNum[j] = StringManager.Instance.SpawnString(30);
			this.Cstr_ItemExchangeValue[j] = StringManager.Instance.SpawnString(30);
			this.Cstr_ItemResourcesValue[j] = StringManager.Instance.SpawnString(30);
		}
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.MM = MerchantmanManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		Material material = this.door.LoadMaterial();
		Transform child = this.GameT.GetChild(0);
		Image[] array = new Image[5];
		Transform child2;
		for (int k = 0; k < 5; k++)
		{
			child2 = child.GetChild(0).GetChild(1 + k);
			this.btn_Res[k] = child2.GetComponent<UIButton>();
			this.btn_Res[k].m_Handler = this;
			this.btn_Res[k].m_BtnID1 = 5;
			this.btn_Res[k].m_BtnID2 = k;
			this.btn_Res[k].m_EffectType = e_EffectType.e_Scale;
			this.btn_Res[k].transition = Selectable.Transition.None;
			child2 = child.GetChild(0).GetChild(1 + k).GetChild(0);
			array[k] = child2.GetComponent<Image>();
			array[k].sprite = this.SArray.m_Sprites[k];
			array[k].SetNativeSize();
			child2 = child.GetChild(0).GetChild(1 + k).GetChild(1);
			this.text_Resources[k] = child2.GetComponent<UIText>();
			this.text_Resources[k].font = this.TTFont;
			this.Cstr_Resources[k].ClearString();
			StringManager.IntToStr(this.Cstr_Resources[k], (long)((ulong)this.DM.Resource[k].Stock), 1, true);
			this.text_Resources[k].text = this.Cstr_Resources[k].ToString();
		}
		child2 = child.GetChild(0).GetChild(6);
		this.btn_I = child2.GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_I.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_I.m_Handler = this;
		this.btn_I.m_BtnID1 = 1;
		this.btn_I.m_EffectType = e_EffectType.e_Scale;
		this.btn_I.transition = Selectable.Transition.None;
		this.text_Title = child.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.text = this.DM.mStringTable.GetStringByID(1479u);
		child2 = child.GetChild(8);
		this.Img_Hint = child2.GetComponent<Image>();
		child2 = child.GetChild(8).GetChild(0);
		this.text_Hint = child2.GetComponent<UIText>();
		this.text_Hint.font = this.TTFont;
		this.text_Hint.text = this.DM.mStringTable.GetStringByID(1480u);
		this.text_Hint.cachedTextGeneratorForLayout.Invalidate();
		if (this.text_Hint.preferredHeight > this.text_Hint.rectTransform.sizeDelta.y)
		{
			this.Img_Hint.rectTransform.sizeDelta = new Vector2(this.Img_Hint.rectTransform.sizeDelta.x, this.text_Hint.preferredHeight + 10f);
		}
		child2 = child.GetChild(2).GetChild(0);
		this.btn_CDTime = child2.GetComponent<UIButton>();
		this.btn_CDTime.m_Handler = this;
		this.btn_CDTime.m_BtnID1 = 2;
		UIButtonHint uibuttonHint = this.btn_CDTime.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = this.Img_Hint.gameObject;
		child2 = child.GetChild(2).GetChild(2);
		this.text_Time = child2.GetComponent<UIText>();
		this.text_Time.font = this.TTFont;
		this.Data = DataManager.MissionDataManager.GetTimerMissionData(_eMissionType.Affair);
		this.Cstr_Time.ClearString();
		this.Cstr_Time.Append(DataManager.MissionDataManager.FormatMissionTime((uint)Math.Max(this.Data.ResetTime - DataManager.Instance.ServerTime, 0L)));
		this.text_Time.text = this.Cstr_Time.ToString();
		for (int l = 0; l < 4; l++)
		{
			this.Img_Exchange_Star[l] = new Image[3];
			child2 = child.GetChild(3 + l);
			this.PGO[l] = child2.gameObject;
			this.Img_ItemBG[l] = child2.GetChild(0).GetComponent<Image>();
			this.btn_Lock[l] = child2.GetChild(0).GetChild(0).GetComponent<UIButton>();
			this.btn_Lock[l].m_Handler = this;
			this.btn_Lock[l].m_BtnID1 = 3;
			this.btn_Lock[l].m_BtnID2 = l;
			this.btn_Lock[l].m_EffectType = e_EffectType.e_Scale;
			this.btn_Lock[l].transition = Selectable.Transition.None;
			if ((this.MM.TradeLocks >> l & 1) == 0)
			{
				this.Img_ItemBG[l].sprite = this.SArray.m_Sprites[5];
				this.btn_Lock[l].image.sprite = this.SArray.m_Sprites[7];
			}
			else
			{
				this.Img_ItemBG[l].sprite = this.SArray.m_Sprites[6];
				this.btn_Lock[l].image.sprite = this.SArray.m_Sprites[8];
			}
			this.btn_Item[l] = child2.GetChild(1).GetComponent<UIHIBtn>();
			this.GUIM.InitianHeroItemImg(this.btn_Item[l].transform, eHeroOrItem.Item, this.MM.MerchantmanData[l].itemID, 0, 0, (int)this.MM.MerchantmanData[l].itemCount, true, true, true, false);
			this.btn_Exchange[l] = child2.GetChild(2).GetComponent<UIButton>();
			this.btn_Exchange[l].m_Handler = this;
			this.btn_Exchange[l].m_BtnID1 = 4;
			this.btn_Exchange[l].m_BtnID2 = l;
			this.btn_Exchange[l].m_EffectType = e_EffectType.e_Scale;
			this.btn_Exchange[l].transition = Selectable.Transition.None;
			this.Img_Exchange_Res[l] = child2.GetChild(2).GetChild(0).GetComponent<Image>();
			this.Img_Exchange_Res[l].sprite = this.SArray.m_Sprites[(int)this.MM.MerchantmanData[l].ResourceKind];
			this.Img_Exchange_Res[l].SetNativeSize();
			this.text_ItemExchangeValue[l] = child2.GetChild(2).GetChild(1).GetComponent<UIText>();
			this.text_ItemExchangeValue[l].font = this.TTFont;
			this.Cstr_ItemExchangeValue[l].ClearString();
			StringManager.IntToStr(this.Cstr_ItemExchangeValue[l], (long)((ulong)this.MM.MerchantmanData[l].ResourceCount), 1, true);
			this.text_ItemExchangeValue[l].text = this.Cstr_ItemExchangeValue[l].ToString();
			this.text_ItemExchange[l] = child2.GetChild(2).GetChild(2).GetComponent<UIText>();
			this.text_ItemExchange[l].font = this.TTFont;
			this.text_ItemExchange[l].text = this.DM.mStringTable.GetStringByID(1485u);
			this.btn_Exchange[l].m_Text = this.text_ItemExchange[l];
			if (this.MM.MerchantmanData[l].ResourceCount > this.DM.Resource[(int)this.MM.MerchantmanData[l].ResourceKind].Stock)
			{
				this.btn_Exchange[l].ForTextChange(e_BtnType.e_ChangeText);
			}
			else
			{
				this.btn_Exchange[l].ForTextChange(e_BtnType.e_Normal);
			}
			this.text_ItemNum[l] = child2.GetChild(3).GetComponent<UIText>();
			this.text_ItemNum[l].font = this.TTFont;
			this.Cstr_ItemNum[l].ClearString();
			this.Cstr_ItemNum[l].IntToFormat((long)this.MM.MerchantmanData[l].itemCount, 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_ItemNum[l].AppendFormat("{0}x");
			}
			else
			{
				this.Cstr_ItemNum[l].AppendFormat("x{0}");
			}
			this.text_ItemNum[l].text = this.Cstr_ItemNum[l].ToString();
			this.text_ItemName[l] = child2.GetChild(4).GetComponent<UIText>();
			this.text_ItemName[l].font = this.TTFont;
			this.Img_Resources[l] = child2.GetChild(5).GetComponent<Image>();
			this.text_ItemResourcesValue[l] = child2.GetChild(5).GetChild(0).GetComponent<UIText>();
			this.text_ItemResourcesValue[l].font = this.TTFont;
			this.Img_Exchange[l] = child2.GetChild(6).GetChild(0).GetComponent<Image>();
			if (this.GUIM.IsArabic)
			{
				this.Img_Exchange[l].transform.localScale = new Vector3(-1f, this.Img_Exchange[l].transform.localScale.y, this.Img_Exchange[l].transform.localScale.z);
			}
			this.text_Item[l] = child2.GetChild(6).GetChild(1).GetComponent<UIText>();
			this.text_Item[l].font = this.TTFont;
			this.text_Item[l].text = this.DM.mStringTable.GetStringByID(1486u);
			this.tmpEq = this.DM.EquipTable.GetRecordByKey(this.MM.MerchantmanData[l].itemID);
			this.text_ItemName[l].text = this.DM.mStringTable.GetStringByID((uint)this.tmpEq.EquipName);
			if (this.tmpEq.EquipKind == 11)
			{
				this.text_ItemName[l].gameObject.SetActive(false);
				this.Img_Resources[l].gameObject.SetActive(true);
				if (this.tmpEq.PropertiesInfo[0].Propertieskey > 0 && this.tmpEq.PropertiesInfo[0].Propertieskey < 6)
				{
					this.Img_Resources[l].sprite = this.SArray.m_Sprites[(int)(this.tmpEq.PropertiesInfo[0].Propertieskey - 1)];
				}
				else
				{
					this.Img_Resources[l].sprite = this.SArray.m_Sprites[0];
				}
				this.Img_Resources[l].SetNativeSize();
				this.Cstr_ItemResourcesValue[l].ClearString();
				StringManager.IntToStr(this.Cstr_ItemResourcesValue[l], (long)(this.MM.MerchantmanData[l].itemCount * this.tmpEq.PropertiesInfo[1].Propertieskey * this.tmpEq.PropertiesInfo[1].PropertiesValue), 1, true);
				this.text_ItemResourcesValue[l].text = this.Cstr_ItemResourcesValue[l].ToString();
			}
			this.Img_Star_Hint[l] = child2.GetChild(8).GetComponent<Image>();
			this.text_Star_Hint[l] = child2.GetChild(8).GetChild(0).GetComponent<UIText>();
			this.text_Star_Hint[l].font = this.TTFont;
			this.text_Star_Hint[l].text = this.DM.mStringTable.GetStringByID(1040u);
			this.text_Star_Hint[l].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_Star_Hint[l].preferredWidth > this.text_Star_Hint[l].rectTransform.sizeDelta.y)
			{
				this.Img_Star_Hint[l].rectTransform.sizeDelta = new Vector2(this.text_Star_Hint[l].preferredWidth + 16f, this.Img_Star_Hint[l].rectTransform.sizeDelta.y);
			}
			this.btn_Star_Hint[l] = child2.GetChild(7).GetComponent<UIButton>();
			this.btn_Star_Hint[l].m_Handler = this;
			this.btn_Star_Hint[l].m_BtnID1 = 6;
			this.btn_Star_Hint[l].m_BtnID2 = l;
			uibuttonHint = this.btn_Star_Hint[l].gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.ControlFadeOut = this.Img_Star_Hint[l].gameObject;
			this.Img_Exchange_Star[l][0] = child2.GetChild(7).GetChild(0).GetComponent<Image>();
			this.Img_Exchange_Star[l][1] = child2.GetChild(7).GetChild(1).GetComponent<Image>();
			this.Img_Exchange_Star[l][2] = child2.GetChild(7).GetChild(2).GetComponent<Image>();
			int num = 1;
			if (this.MM.MerchantmanData[l].Rare < 2)
			{
				num = 1;
			}
			else if (this.MM.MerchantmanData[l].Rare < 3)
			{
				num = 2;
			}
			else if (this.MM.MerchantmanData[l].Rare >= 3)
			{
				num = 3;
			}
			for (int m = 0; m < num; m++)
			{
				this.Img_Exchange_Star[l][m].gameObject.SetActive(true);
			}
			if ((this.MM.TradeStatus >> l & 1) == 0)
			{
				this.btn_Exchange[l].gameObject.SetActive(true);
				this.Img_Exchange[l].transform.parent.gameObject.SetActive(false);
			}
			else
			{
				this.btn_Exchange[l].gameObject.SetActive(false);
				this.Img_Exchange[l].transform.parent.gameObject.SetActive(true);
				this.btn_Lock[l].gameObject.SetActive(false);
				this.Img_ItemBG[l].sprite = this.SArray.m_Sprites[5];
				this.btn_Lock[l].image.sprite = this.SArray.m_Sprites[7];
			}
		}
		this.InitialP5();
		this.CheckExtraData();
		child = this.GameT.GetChild(1);
		Image component = child.GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close_base");
		component.material = material;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			component.enabled = false;
		}
		child = this.GameT.GetChild(1).GetChild(0);
		this.btn_EXIT = child.GetComponent<UIButton>();
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = material;
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
		if (this.MM.bNeedUpDateExtra)
		{
			this.MM.SendReQusetBlackMarket_Data();
		}
	}

	// Token: 0x06001423 RID: 5155 RVA: 0x002360AC File Offset: 0x002342AC
	private void InitialP5()
	{
		int num = 4;
		Transform child = this.GameT.GetChild(0).GetChild(3 + num);
		this.PGO[num] = child.gameObject;
		this.Img_ItemBG[num] = child.GetChild(0).GetComponent<Image>();
		this.Img_ItemBG[num].sprite = this.SArray.m_Sprites[9];
		this.btn_Lock[num] = child.GetChild(0).GetChild(0).GetComponent<UIButton>();
		this.btn_Lock[num].m_Handler = this;
		this.btn_Lock[num].m_BtnID1 = 8;
		this.btn_Lock[num].m_BtnID2 = num;
		this.btn_Lock[num].m_EffectType = e_EffectType.e_Scale;
		this.btn_Lock[num].transition = Selectable.Transition.None;
		this.btn_Lock[num].image.sprite = this.SArray.m_Sprites[7];
		this.btn_Item[num] = child.GetChild(1).GetComponent<UIHIBtn>();
		this.btn_Item[num].m_Handler = this;
		this.btn_Item[num].transition = Selectable.Transition.None;
		this.GUIM.InitianHeroItemImg(this.btn_Item[num].transform, eHeroOrItem.Item, 0, 0, 0, 0, true, true, true, false);
		this.GUIM.SetItemScaleClickSound(this.btn_Item[num], true, true);
		child.GetChild(1).GetComponent<UIButtonHint>().enabled = false;
		child.GetChild(8).SetParent(child.GetChild(1));
		this.btn_Exchange[num] = child.GetChild(2).GetComponent<UIButton>();
		this.btn_Exchange[num].m_Handler = this;
		this.btn_Exchange[num].m_BtnID1 = 7;
		this.btn_Exchange[num].m_BtnID2 = num;
		this.btn_Exchange[num].m_EffectType = e_EffectType.e_Scale;
		this.btn_Exchange[num].transition = Selectable.Transition.None;
		this.Img_Exchange_Res[num] = child.GetChild(2).GetChild(0).GetComponent<Image>();
		this.extra_text_ItemExchangeValue = child.GetChild(2).GetChild(1).GetComponent<Text>();
		this.extra_text_ItemExchangeValue.font = this.TTFont;
		if (this.GUIM.IsArabic)
		{
			this.extra_text_ItemExchangeValue.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
			this.extra_text_ItemExchangeValue.rectTransform.anchoredPosition += new Vector2(this.extra_text_ItemExchangeValue.rectTransform.sizeDelta.x, 0f);
		}
		this.extra_Price = child.GetChild(2).GetChild(2).GetComponent<Text>();
		this.extra_Price.font = this.TTFont;
		this.extra_PriceStr = StringManager.Instance.SpawnString(30);
		if (this.GUIM.IsArabic)
		{
			this.extra_Price.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		this.text_ItemExchange[num] = child.GetChild(2).GetChild(3).GetComponent<UIText>();
		this.text_ItemExchange[num].font = this.TTFont;
		this.text_ItemExchange[num].text = this.DM.mStringTable.GetStringByID(284u);
		this.btn_Exchange[num].m_Text = this.text_ItemExchange[num];
		this.text_ItemNum[num] = child.GetChild(3).GetComponent<UIText>();
		this.text_ItemNum[num].font = this.TTFont;
		this.Cstr_ItemNum[num].ClearString();
		this.Cstr_ItemNum[num].IntToFormat(1L, 1, false);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_ItemNum[num].AppendFormat("{0}x");
		}
		else
		{
			this.Cstr_ItemNum[num].AppendFormat("x{0}");
		}
		this.text_ItemNum[num].text = this.Cstr_ItemNum[num].ToString();
		this.text_ItemName[num] = child.GetChild(4).GetComponent<UIText>();
		this.text_ItemName[num].font = this.TTFont;
		this.Img_Exchange[num] = child.GetChild(5).GetChild(0).GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_Exchange[num].transform.localScale = new Vector3(-1f, this.Img_Exchange[num].transform.localScale.y, this.Img_Exchange[num].transform.localScale.z);
		}
		this.text_Item[num] = child.GetChild(5).GetChild(1).GetComponent<UIText>();
		this.text_Item[num].font = this.TTFont;
		this.text_Item[num].text = this.DM.mStringTable.GetStringByID(9775u);
		this.Img_Star_Hint[num] = child.GetChild(7).GetComponent<Image>();
		this.text_Star_Hint[num] = child.GetChild(7).GetChild(0).GetComponent<UIText>();
		this.text_Star_Hint[num].font = this.TTFont;
		this.text_Star_Hint[num].text = this.DM.mStringTable.GetStringByID(1040u);
		this.text_Star_Hint[num].cachedTextGeneratorForLayout.Invalidate();
		if (this.text_Star_Hint[num].preferredWidth > this.text_Star_Hint[num].rectTransform.sizeDelta.y)
		{
			this.Img_Star_Hint[num].rectTransform.sizeDelta = new Vector2(this.text_Star_Hint[num].preferredWidth + 16f, this.Img_Star_Hint[num].rectTransform.sizeDelta.y);
		}
		this.btn_Star_Hint[num] = child.GetChild(6).GetComponent<UIButton>();
		this.btn_Star_Hint[num].m_Handler = this;
		this.btn_Star_Hint[num].m_BtnID1 = 6;
		this.btn_Star_Hint[num].m_BtnID2 = num;
		UIButtonHint uibuttonHint = this.btn_Star_Hint[num].gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ControlFadeOut = this.Img_Star_Hint[num].gameObject;
		this.Img_Exchange_Star[num] = new Image[3];
		this.Img_Exchange_Star[num][0] = child.GetChild(6).GetChild(0).GetComponent<Image>();
		this.Img_Exchange_Star[num][1] = child.GetChild(6).GetChild(1).GetComponent<Image>();
		this.Img_Exchange_Star[num][2] = child.GetChild(6).GetChild(2).GetComponent<Image>();
	}

	// Token: 0x06001424 RID: 5156 RVA: 0x00236740 File Offset: 0x00234940
	public override void OnClose()
	{
		if (this.Cstr_Time != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Time);
		}
		for (int i = 0; i < 5; i++)
		{
			if (this.Cstr_Resources[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Resources[i]);
			}
		}
		for (int j = 0; j < 5; j++)
		{
			if (this.Cstr_ItemNum[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemNum[j]);
			}
			if (this.Cstr_ItemExchangeValue[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemExchangeValue[j]);
			}
			if (this.Cstr_ItemResourcesValue[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemResourcesValue[j]);
			}
		}
	}

	// Token: 0x06001425 RID: 5157 RVA: 0x00236810 File Offset: 0x00234A10
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond)
		{
			this.Cstr_Time.ClearString();
			this.Cstr_Time.Append(DataManager.MissionDataManager.FormatMissionTime((uint)Math.Max(this.Data.ResetTime - DataManager.Instance.ServerTime, 0L)));
			this.text_Time.text = this.Cstr_Time.ToString();
			this.text_Time.SetAllDirty();
			this.text_Time.cachedTextGenerator.Invalidate();
			if (this.NeedUpDate && IGGGameSDK.Instance.bPaymentReady)
			{
				this.NeedUpDate = false;
				this.CheckExtraData();
			}
		}
	}

	// Token: 0x06001426 RID: 5158 RVA: 0x002368BC File Offset: 0x00234ABC
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 1:
			this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(1041u), this.DM.mStringTable.GetStringByID(1042u), null, null, 0, 0, true, true);
			break;
		case 3:
			if ((this.MM.TradeLocks >> sender.m_BtnID2 & 1) == 0)
			{
				this.tmpLock = (byte)sender.m_BtnID2;
				if (!this.DM.MySysSetting.bMerchantman)
				{
					this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(1481u), this.DM.mStringTable.GetStringByID(1482u), 1, 0, this.DM.mStringTable.GetStringByID(3737u), this.DM.mStringTable.GetStringByID(3736u));
				}
				else
				{
					this.MM.TradeLocks = (byte)((int)this.MM.TradeLocks + (1 << (int)this.tmpLock));
					this.MM.SendReQusetBlackMarket_Lock(this.MM.TradeLocks);
				}
			}
			else
			{
				this.tmpLock = (byte)sender.m_BtnID2;
				this.MM.TradeLocks = (byte)((int)this.MM.TradeLocks - (1 << sender.m_BtnID2));
				this.MM.SendReQusetBlackMarket_Lock(this.MM.TradeLocks);
			}
			break;
		case 4:
			if (this.DM.Resource[(int)this.MM.MerchantmanData[sender.m_BtnID2].ResourceKind].Stock < this.MM.MerchantmanData[sender.m_BtnID2].ResourceCount)
			{
				this.mExchange = (byte)sender.m_BtnID2;
				CString cstring = StringManager.Instance.StaticString1024();
				CString cstring2 = StringManager.Instance.StaticString1024();
				cstring.StringToFormat(this.DM.mStringTable.GetStringByID(3952u + (uint)this.MM.MerchantmanData[sender.m_BtnID2].ResourceKind));
				cstring.AppendFormat(this.DM.mStringTable.GetStringByID(1545u));
				cstring2.StringToFormat(this.DM.mStringTable.GetStringByID(3952u + (uint)this.MM.MerchantmanData[sender.m_BtnID2].ResourceKind));
				cstring2.AppendFormat(this.DM.mStringTable.GetStringByID(1546u));
				this.GUIM.OpenMessageBox(cstring.ToString(), cstring2.ToString(), this.DM.mStringTable.GetStringByID(5723u), this, 2, 0, true, false, false, false, false);
			}
			else
			{
				RectTransform component = sender.transform.parent.GetComponent<RectTransform>();
				RectTransform component2 = sender.transform.parent.parent.GetComponent<RectTransform>();
				this.GUIM.mStartV2 = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + component.anchoredPosition.x + component2.anchoredPosition.x - component2.sizeDelta.x / 2f + 71.5f, this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - component.anchoredPosition.y - component2.anchoredPosition.y - component2.sizeDelta.y / 2f + 53f);
				this.mExchange = (byte)sender.m_BtnID2;
				this.MM.SendReQusetBlackMarket_Buy((byte)sender.m_BtnID2, true, false);
			}
			break;
		case 5:
			if (this.door != null)
			{
				this.door.OpenMenu(EGUIWindow.UI_BagFilter, 1 + (sender.m_BtnID2 << 16), 0, false);
			}
			break;
		case 7:
			if (this.MM.CheckbWaitBuy(true))
			{
				return;
			}
			this.MM.SendReQusetBlackMarket_Buy(this.MM.MerchantmanExtraData.TradePos, true, true);
			break;
		case 8:
			if (this.MM.CheckbWaitBuy(true))
			{
				return;
			}
			if ((this.MM.MerchantmanExtraData.LocksBought & 1) == 0)
			{
				this.tmpLock = 4;
				if (!this.DM.MySysSetting.bMerchantman)
				{
					this.GUIM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(1481u), this.DM.mStringTable.GetStringByID(1482u), 1, 0, this.DM.mStringTable.GetStringByID(3737u), this.DM.mStringTable.GetStringByID(3736u));
				}
				else
				{
					this.MM.SendReQusetBlackMarket_ExtraLock(1);
				}
			}
			else
			{
				this.tmpLock = 4;
				this.MM.SendReQusetBlackMarket_ExtraLock(0);
			}
			break;
		}
	}

	// Token: 0x06001427 RID: 5159 RVA: 0x00236E38 File Offset: 0x00235038
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		GUIMerchantman btnID = (GUIMerchantman)uibutton.m_BtnID1;
		if (btnID != GUIMerchantman.btn_CDTime)
		{
			if (btnID == GUIMerchantman.btn_Star_Hint)
			{
				this.Img_Star_Hint[uibutton.m_BtnID2].gameObject.SetActive(true);
			}
		}
		else
		{
			this.Img_Hint.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001428 RID: 5160 RVA: 0x00236EA0 File Offset: 0x002350A0
	public void OnButtonUp(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		GUIMerchantman btnID = (GUIMerchantman)uibutton.m_BtnID1;
		if (btnID != GUIMerchantman.btn_CDTime)
		{
			if (btnID == GUIMerchantman.btn_Star_Hint)
			{
				this.Img_Star_Hint[uibutton.m_BtnID2].gameObject.SetActive(false);
			}
		}
		else
		{
			this.Img_Hint.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001429 RID: 5161 RVA: 0x00236F08 File Offset: 0x00235108
	public void OnHIButtonClick(UIHIBtn sender)
	{
		this.door.OpenMenu(EGUIWindow.UI_OpenBox, 3, (int)sender.HIID, false);
		AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
	}

	// Token: 0x0600142A RID: 5162 RVA: 0x00236F2C File Offset: 0x0023512C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 != 1)
			{
				if (arg1 == 2)
				{
					if (this.door != null)
					{
						this.door.OpenMenu(EGUIWindow.UI_BagFilter, 1 + ((int)(5 + this.MM.MerchantmanData[(int)this.mExchange].ResourceKind) << 16), (int)this.MM.MerchantmanData[(int)this.mExchange].ResourceCount, false);
					}
				}
			}
			else
			{
				if (this.tmpLock >= 4)
				{
					this.MM.SendReQusetBlackMarket_ExtraLock(1);
				}
				else
				{
					this.MM.TradeLocks = (byte)((int)this.MM.TradeLocks + (1 << (int)this.tmpLock));
					this.MM.SendReQusetBlackMarket_Lock(this.MM.TradeLocks);
				}
				this.DM.MySysSetting.bMerchantman = true;
				PlayerPrefs.SetString("Other_bMerchantman", this.DM.MySysSetting.bMerchantman.ToString());
			}
		}
	}

	// Token: 0x0600142B RID: 5163 RVA: 0x00237044 File Offset: 0x00235244
	public void ReSetData()
	{
		for (int i = 0; i < 4; i++)
		{
			this.PGO[i].SetActive(true);
			this.GUIM.ChangeHeroItemImg(this.btn_Item[i].transform, eHeroOrItem.Item, this.MM.MerchantmanData[i].itemID, 0, 0, (int)this.MM.MerchantmanData[i].itemCount);
			int num = 1;
			if (this.MM.MerchantmanData[i].Rare < 2)
			{
				num = 1;
			}
			else if (this.MM.MerchantmanData[i].Rare < 3)
			{
				num = 2;
			}
			else if (this.MM.MerchantmanData[i].Rare >= 3)
			{
				num = 3;
			}
			for (int j = 0; j < num; j++)
			{
				this.Img_Exchange_Star[i][j].gameObject.SetActive(true);
			}
			for (int k = num; k < 3; k++)
			{
				this.Img_Exchange_Star[i][k].gameObject.SetActive(false);
			}
			if ((this.MM.TradeLocks >> i & 1) == 0)
			{
				this.Img_ItemBG[i].sprite = this.SArray.m_Sprites[5];
				this.btn_Lock[i].image.sprite = this.SArray.m_Sprites[7];
			}
			else
			{
				this.Img_ItemBG[i].sprite = this.SArray.m_Sprites[6];
				this.btn_Lock[i].image.sprite = this.SArray.m_Sprites[8];
			}
			if ((this.MM.TradeStatus >> i & 1) == 0)
			{
				this.btn_Exchange[i].gameObject.SetActive(true);
				this.Img_Exchange[i].transform.parent.gameObject.SetActive(false);
				this.btn_Lock[i].gameObject.SetActive(true);
				if (this.MM.MerchantmanData[i].ResourceCount > this.DM.Resource[(int)this.MM.MerchantmanData[i].ResourceKind].Stock)
				{
					this.btn_Exchange[i].ForTextChange(e_BtnType.e_ChangeText);
				}
				else
				{
					this.btn_Exchange[i].ForTextChange(e_BtnType.e_Normal);
				}
			}
			else
			{
				this.btn_Exchange[i].gameObject.SetActive(false);
				this.Img_Exchange[i].transform.parent.gameObject.SetActive(true);
				this.btn_Lock[i].gameObject.SetActive(false);
				this.Img_ItemBG[i].sprite = this.SArray.m_Sprites[5];
				this.btn_Lock[i].image.sprite = this.SArray.m_Sprites[7];
			}
			this.tmpEq = this.DM.EquipTable.GetRecordByKey(this.MM.MerchantmanData[i].itemID);
			this.text_ItemName[i].text = this.DM.mStringTable.GetStringByID((uint)this.tmpEq.EquipName);
			this.text_ItemName[i].SetAllDirty();
			this.text_ItemName[i].cachedTextGenerator.Invalidate();
			if (this.tmpEq.EquipKind != 11)
			{
				this.text_ItemName[i].gameObject.SetActive(true);
				this.Img_Resources[i].gameObject.SetActive(false);
			}
			else
			{
				this.text_ItemName[i].gameObject.SetActive(false);
				this.Img_Resources[i].gameObject.SetActive(true);
				if (this.tmpEq.PropertiesInfo[0].Propertieskey > 0 && this.tmpEq.PropertiesInfo[0].Propertieskey < 6)
				{
					this.Img_Resources[i].sprite = this.SArray.m_Sprites[(int)(this.tmpEq.PropertiesInfo[0].Propertieskey - 1)];
				}
				else
				{
					this.Img_Resources[i].sprite = this.SArray.m_Sprites[0];
				}
				this.Img_Resources[i].SetNativeSize();
				this.Cstr_ItemResourcesValue[i].ClearString();
				StringManager.IntToStr(this.Cstr_ItemResourcesValue[i], (long)(this.MM.MerchantmanData[i].itemCount * this.tmpEq.PropertiesInfo[1].Propertieskey * this.tmpEq.PropertiesInfo[1].PropertiesValue), 1, true);
				this.text_ItemResourcesValue[i].text = this.Cstr_ItemResourcesValue[i].ToString();
				this.text_ItemResourcesValue[i].SetAllDirty();
				this.text_ItemResourcesValue[i].cachedTextGenerator.Invalidate();
			}
			this.Img_Exchange_Res[i].sprite = this.SArray.m_Sprites[(int)this.MM.MerchantmanData[i].ResourceKind];
			this.Img_Exchange_Res[i].SetNativeSize();
			this.Cstr_ItemExchangeValue[i].ClearString();
			StringManager.IntToStr(this.Cstr_ItemExchangeValue[i], (long)((ulong)this.MM.MerchantmanData[i].ResourceCount), 1, true);
			this.text_ItemExchangeValue[i].text = this.Cstr_ItemExchangeValue[i].ToString();
			this.text_ItemExchangeValue[i].SetAllDirty();
			this.text_ItemExchangeValue[i].cachedTextGenerator.Invalidate();
			this.Cstr_ItemNum[i].ClearString();
			this.Cstr_ItemNum[i].IntToFormat((long)this.MM.MerchantmanData[i].itemCount, 1, false);
			if (this.GUIM.IsArabic)
			{
				this.Cstr_ItemNum[i].AppendFormat("{0}x");
			}
			else
			{
				this.Cstr_ItemNum[i].AppendFormat("x{0}");
			}
			this.text_ItemNum[i].text = this.Cstr_ItemNum[i].ToString();
			this.text_ItemNum[i].SetAllDirty();
			this.text_ItemNum[i].cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x0600142C RID: 5164 RVA: 0x00237690 File Offset: 0x00235890
	public void CheckExtraData()
	{
		if (this.btn_Item[0] == null || this.MM.ExtraData != 1 || this.MM.MerchantmanExtraData.TradePos >= 4)
		{
			this.PGO[4].SetActive(false);
			return;
		}
		int num = 4;
		this.PGO[num].SetActive(true);
		this.PGO[(int)this.MM.MerchantmanExtraData.TradePos].SetActive(false);
		((RectTransform)this.PGO[num].transform).anchoredPosition = ((RectTransform)this.PGO[(int)this.MM.MerchantmanExtraData.TradePos].transform).anchoredPosition;
		this.GUIM.ChangeHeroItemImg(this.btn_Item[num].transform, eHeroOrItem.Item, this.MM.MerchantmanExtraData.itemID, 0, 0, 0);
		int discount = (int)this.MM.MerchantmanExtraData.Discount;
		for (int i = 0; i < discount; i++)
		{
			this.Img_Exchange_Star[num][i].gameObject.SetActive(true);
		}
		for (int j = discount; j < 3; j++)
		{
			this.Img_Exchange_Star[num][j].gameObject.SetActive(false);
		}
		if ((this.MM.MerchantmanExtraData.LocksBought & 1) == 0)
		{
			this.Img_ItemBG[num].sprite = this.SArray.m_Sprites[9];
			this.btn_Lock[num].image.sprite = this.SArray.m_Sprites[7];
		}
		else
		{
			this.Img_ItemBG[num].sprite = this.SArray.m_Sprites[10];
			this.btn_Lock[num].image.sprite = this.SArray.m_Sprites[8];
		}
		if ((this.MM.MerchantmanExtraData.LocksBought >> 1 & 1) == 0)
		{
			this.btn_Exchange[num].gameObject.SetActive(true);
			this.Img_Exchange[num].transform.parent.gameObject.SetActive(false);
			this.btn_Lock[num].gameObject.SetActive(true);
		}
		else
		{
			this.btn_Exchange[num].gameObject.SetActive(false);
			this.Img_Exchange[num].transform.parent.gameObject.SetActive(true);
			this.btn_Lock[num].gameObject.SetActive(false);
			this.Img_ItemBG[num].sprite = this.SArray.m_Sprites[9];
			this.btn_Lock[num].image.sprite = this.SArray.m_Sprites[7];
		}
		this.tmpEq = this.DM.EquipTable.GetRecordByKey(this.MM.MerchantmanExtraData.itemID);
		this.text_ItemName[num].text = this.DM.mStringTable.GetStringByID((uint)this.tmpEq.EquipName);
		this.text_ItemName[num].SetAllDirty();
		this.text_ItemName[num].cachedTextGenerator.Invalidate();
		this.Cstr_ItemNum[num].ClearString();
		this.Cstr_ItemNum[num].IntToFormat(1L, 1, false);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_ItemNum[num].AppendFormat("{0}x");
		}
		else
		{
			this.Cstr_ItemNum[num].AppendFormat("x{0}");
		}
		this.text_ItemNum[num].text = this.Cstr_ItemNum[num].ToString();
		this.text_ItemNum[num].SetAllDirty();
		this.text_ItemNum[num].cachedTextGenerator.Invalidate();
		MallManager instance = MallManager.Instance;
		string productPaltformPriceByID = instance.GetProductPaltformPriceByID((int)instance.SmallID);
		string productPriceByID = instance.GetProductPriceByID((int)instance.SmallID);
		this.extra_PriceStr.Length = 0;
		if (productPaltformPriceByID != null && productPaltformPriceByID != string.Empty)
		{
			this.extra_PriceStr.Append(productPaltformPriceByID);
		}
		else
		{
			if (productPriceByID != null)
			{
				this.extra_PriceStr.StringToFormat(productPriceByID);
			}
			else
			{
				this.extra_PriceStr.StringToFormat(string.Empty);
				this.NeedUpDate = true;
			}
			string currency = instance.GetCurrency((int)instance.SmallID);
			if (currency != null)
			{
				this.extra_PriceStr.StringToFormat(currency);
				if (instance.bChangePosCurrency(currency))
				{
					this.extra_PriceStr.AppendFormat("{0} {1}");
				}
				else
				{
					this.extra_PriceStr.AppendFormat("{1} {0}");
				}
			}
		}
		this.extra_Price.text = this.extra_PriceStr.ToString();
		this.extra_Price.SetAllDirty();
		this.extra_Price.cachedTextGenerator.Invalidate();
	}

	// Token: 0x0600142D RID: 5165 RVA: 0x00237B60 File Offset: 0x00235D60
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			this.ReSetData();
			this.CheckExtraData();
			break;
		case 2:
		{
			this.btn_Exchange[(int)this.mExchange].gameObject.SetActive(false);
			this.Img_Exchange[(int)this.mExchange].transform.parent.gameObject.SetActive(true);
			this.btn_Lock[(int)this.mExchange].gameObject.SetActive(false);
			this.Img_ItemBG[(int)this.mExchange].sprite = this.SArray.m_Sprites[5];
			this.btn_Lock[(int)this.mExchange].image.sprite = this.SArray.m_Sprites[7];
			ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(this.MM.MerchantmanData[(int)this.mExchange].itemID, 0);
			if (curItemQuantity < 65535)
			{
				DataManager.Instance.SetCurItemQuantity(this.MM.MerchantmanData[(int)this.mExchange].itemID, curItemQuantity + this.MM.MerchantmanData[(int)this.mExchange].itemCount, 0, 0L);
			}
			AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
			GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Item, 0, this.MM.MerchantmanData[(int)this.mExchange].itemID, true, 2f);
			break;
		}
		case 3:
			if ((this.MM.TradeLocks >> (int)this.tmpLock & 1) == 0)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1484u), 255, true);
				this.Img_ItemBG[(int)this.tmpLock].sprite = this.SArray.m_Sprites[5];
				this.btn_Lock[(int)this.tmpLock].image.sprite = this.SArray.m_Sprites[7];
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1483u), 255, true);
				this.Img_ItemBG[(int)this.tmpLock].sprite = this.SArray.m_Sprites[6];
				this.btn_Lock[(int)this.tmpLock].image.sprite = this.SArray.m_Sprites[8];
			}
			break;
		case 4:
		{
			CString cstring = StringManager.Instance.StaticString1024();
			CString cstring2 = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(this.DM.mStringTable.GetStringByID(3952u + (uint)this.MM.MerchantmanData[(int)this.mExchange].ResourceKind));
			cstring.AppendFormat(this.DM.mStringTable.GetStringByID(1545u));
			cstring2.StringToFormat(this.DM.mStringTable.GetStringByID(3952u + (uint)this.MM.MerchantmanData[(int)this.mExchange].ResourceKind));
			cstring2.AppendFormat(this.DM.mStringTable.GetStringByID(1546u));
			this.GUIM.OpenMessageBox(cstring.ToString(), cstring2.ToString(), this.DM.mStringTable.GetStringByID(5723u), this, 2, 0, true, false, false, false, false);
			break;
		}
		case 5:
			AudioManager.Instance.PlayMP3SFX(41011, 0f);
			break;
		case 6:
			this.MM.SendReQusetBlackMarket_Data();
			break;
		}
	}

	// Token: 0x0600142E RID: 5166 RVA: 0x00237F18 File Offset: 0x00236118
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Resource)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else
			{
				for (int i = 0; i < 5; i++)
				{
					this.Cstr_Resources[i].ClearString();
					StringManager.IntToStr(this.Cstr_Resources[i], (long)((ulong)this.DM.Resource[i].Stock), 1, true);
					this.text_Resources[i].text = this.Cstr_Resources[i].ToString();
					this.text_Resources[i].SetAllDirty();
					this.text_Resources[i].cachedTextGenerator.Invalidate();
				}
				for (int j = 0; j < 4; j++)
				{
					if (this.btn_Exchange[j] != null)
					{
						if (this.MM.MerchantmanData[j].ResourceCount > this.DM.Resource[(int)this.MM.MerchantmanData[j].ResourceKind].Stock)
						{
							this.btn_Exchange[j].ForTextChange(e_BtnType.e_ChangeText);
						}
						else
						{
							this.btn_Exchange[j].ForTextChange(e_BtnType.e_Normal);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600142F RID: 5167 RVA: 0x0023805C File Offset: 0x0023625C
	public void Refresh_FontTexture()
	{
		if (this.extra_Price != null && this.extra_Price.enabled)
		{
			this.extra_Price.enabled = false;
			this.extra_Price.enabled = true;
		}
		if (this.extra_text_ItemExchangeValue != null && this.extra_text_ItemExchangeValue.enabled)
		{
			this.extra_text_ItemExchangeValue.enabled = false;
			this.extra_text_ItemExchangeValue.enabled = true;
		}
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_Time != null && this.text_Time.enabled)
		{
			this.text_Time.enabled = false;
			this.text_Time.enabled = true;
		}
		if (this.text_Hint != null && this.text_Hint.enabled)
		{
			this.text_Hint.enabled = false;
			this.text_Hint.enabled = true;
		}
		for (int i = 0; i < 5; i++)
		{
			if (this.text_Resources[i] != null && this.text_Resources[i].enabled)
			{
				this.text_Resources[i].enabled = false;
				this.text_Resources[i].enabled = true;
			}
		}
		for (int j = 0; j < 5; j++)
		{
			if (this.text_ItemNum[j] != null && this.text_ItemNum[j].enabled)
			{
				this.text_ItemNum[j].enabled = false;
				this.text_ItemNum[j].enabled = true;
			}
			if (this.text_ItemName[j] != null && this.text_ItemName[j].enabled)
			{
				this.text_ItemName[j].enabled = false;
				this.text_ItemName[j].enabled = true;
			}
			if (this.text_ItemResourcesValue[j] != null && this.text_ItemResourcesValue[j].enabled)
			{
				this.text_ItemResourcesValue[j].enabled = false;
				this.text_ItemResourcesValue[j].enabled = true;
			}
			if (this.text_ItemExchange[j] != null && this.text_ItemExchange[j].enabled)
			{
				this.text_ItemExchange[j].enabled = false;
				this.text_ItemExchange[j].enabled = true;
			}
			if (this.text_ItemExchangeValue[j] != null && this.text_ItemExchangeValue[j].enabled)
			{
				this.text_ItemExchangeValue[j].enabled = false;
				this.text_ItemExchangeValue[j].enabled = true;
			}
			if (this.text_Item[j] != null && this.text_Item[j].enabled)
			{
				this.text_Item[j].enabled = false;
				this.text_Item[j].enabled = true;
			}
			if (this.text_Star_Hint[j] != null && this.text_Star_Hint[j].enabled)
			{
				this.text_Star_Hint[j].enabled = false;
				this.text_Star_Hint[j].enabled = true;
			}
			if (this.btn_Item[j] != null && this.btn_Item[j].enabled)
			{
				this.btn_Item[j].Refresh_FontTexture();
			}
		}
	}

	// Token: 0x06001430 RID: 5168 RVA: 0x002383E4 File Offset: 0x002365E4
	private void Start()
	{
	}

	// Token: 0x06001431 RID: 5169 RVA: 0x002383E8 File Offset: 0x002365E8
	private void Update()
	{
	}

	// Token: 0x04003C8F RID: 15503
	private const int PCount = 5;

	// Token: 0x04003C90 RID: 15504
	private const int ResourceCount = 5;

	// Token: 0x04003C91 RID: 15505
	private DataManager DM;

	// Token: 0x04003C92 RID: 15506
	private GUIManager GUIM;

	// Token: 0x04003C93 RID: 15507
	private MerchantmanManager MM;

	// Token: 0x04003C94 RID: 15508
	private Transform GameT;

	// Token: 0x04003C95 RID: 15509
	private Door door;

	// Token: 0x04003C96 RID: 15510
	private Font TTFont;

	// Token: 0x04003C97 RID: 15511
	private UIButton btn_EXIT;

	// Token: 0x04003C98 RID: 15512
	private UIButton btn_I;

	// Token: 0x04003C99 RID: 15513
	private UIButton btn_CDTime;

	// Token: 0x04003C9A RID: 15514
	private UIButton[] btn_Lock = new UIButton[5];

	// Token: 0x04003C9B RID: 15515
	private UIButton[] btn_Exchange = new UIButton[5];

	// Token: 0x04003C9C RID: 15516
	private UIButton[] btn_Star_Hint = new UIButton[5];

	// Token: 0x04003C9D RID: 15517
	private UIButton[] btn_Res = new UIButton[5];

	// Token: 0x04003C9E RID: 15518
	private UIHIBtn[] btn_Item = new UIHIBtn[5];

	// Token: 0x04003C9F RID: 15519
	private Image Img_Hint;

	// Token: 0x04003CA0 RID: 15520
	private Image[] Img_ItemBG = new Image[5];

	// Token: 0x04003CA1 RID: 15521
	private Image[] Img_Exchange_Res = new Image[5];

	// Token: 0x04003CA2 RID: 15522
	private Image[] Img_Resources = new Image[5];

	// Token: 0x04003CA3 RID: 15523
	private Image[] Img_Exchange = new Image[5];

	// Token: 0x04003CA4 RID: 15524
	private Image[][] Img_Exchange_Star = new Image[5][];

	// Token: 0x04003CA5 RID: 15525
	private Image[] Img_Star_Hint = new Image[5];

	// Token: 0x04003CA6 RID: 15526
	private UIText text_Title;

	// Token: 0x04003CA7 RID: 15527
	private UIText text_Time;

	// Token: 0x04003CA8 RID: 15528
	private UIText text_Hint;

	// Token: 0x04003CA9 RID: 15529
	private UIText[] text_Resources = new UIText[5];

	// Token: 0x04003CAA RID: 15530
	private UIText[] text_ItemNum = new UIText[5];

	// Token: 0x04003CAB RID: 15531
	private UIText[] text_ItemName = new UIText[5];

	// Token: 0x04003CAC RID: 15532
	private UIText[] text_ItemResourcesValue = new UIText[5];

	// Token: 0x04003CAD RID: 15533
	private UIText[] text_ItemExchange = new UIText[5];

	// Token: 0x04003CAE RID: 15534
	private UIText[] text_ItemExchangeValue = new UIText[5];

	// Token: 0x04003CAF RID: 15535
	private UIText[] text_Item = new UIText[5];

	// Token: 0x04003CB0 RID: 15536
	private UIText[] text_Star_Hint = new UIText[5];

	// Token: 0x04003CB1 RID: 15537
	private CString Cstr_Time;

	// Token: 0x04003CB2 RID: 15538
	private CString[] Cstr_Resources = new CString[5];

	// Token: 0x04003CB3 RID: 15539
	private CString[] Cstr_ItemNum = new CString[5];

	// Token: 0x04003CB4 RID: 15540
	private CString[] Cstr_ItemExchangeValue = new CString[5];

	// Token: 0x04003CB5 RID: 15541
	private CString[] Cstr_ItemResourcesValue = new CString[5];

	// Token: 0x04003CB6 RID: 15542
	private Text extra_Price;

	// Token: 0x04003CB7 RID: 15543
	private Text extra_text_ItemExchangeValue;

	// Token: 0x04003CB8 RID: 15544
	private CString extra_PriceStr;

	// Token: 0x04003CB9 RID: 15545
	private GameObject[] PGO = new GameObject[5];

	// Token: 0x04003CBA RID: 15546
	private bool NeedUpDate;

	// Token: 0x04003CBB RID: 15547
	private int tmpT = 45;

	// Token: 0x04003CBC RID: 15548
	private byte tmpLock;

	// Token: 0x04003CBD RID: 15549
	private byte mExchange;

	// Token: 0x04003CBE RID: 15550
	private Equip tmpEq;

	// Token: 0x04003CBF RID: 15551
	private TimerTypeMission Data;

	// Token: 0x04003CC0 RID: 15552
	private UISpritesArray SArray;
}
