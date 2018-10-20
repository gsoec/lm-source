using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000823 RID: 2083
public class NumberConfirm : UIBagFilterBase, IUICalculatorHandler, IUIUnitRSliderHandler
{
	// Token: 0x06002B3C RID: 11068 RVA: 0x00475DF8 File Offset: 0x00473FF8
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager instance = GUIManager.Instance;
		DataManager instance2 = DataManager.Instance;
		Font ttffont = instance.GetTTFFont();
		this.ThisTransform = this.transform.GetChild(this.transform.childCount - 1);
		this.ItemID = (ushort)arg1;
		if (instance.bOpenOnIPhoneX)
		{
			RectTransform component = this.ThisTransform.GetChild(0).GetComponent<RectTransform>();
			component.offsetMin = new Vector2(component.offsetMin.x - instance.IPhoneX_DeltaX, component.offsetMin.y);
			component.offsetMax = new Vector2(component.offsetMax.x + instance.IPhoneX_DeltaX, component.offsetMax.y);
		}
		this.BackgroundRect = this.ThisTransform.GetChild(1).GetChild(0).GetComponent<RectTransform>();
		this.LineImageRect = this.ThisTransform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
		this.MsgIcon = this.ThisTransform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>();
		this.UseType = NumberConfirm._UseType.Normal;
		this.QtyStr = StringManager.Instance.SpawnString(30);
		this.TimeStr = StringManager.Instance.SpawnString(100);
		this.NameTitle = StringManager.Instance.SpawnString(30);
		this.Cstr = StringManager.Instance.SpawnString(30);
		this.TimeMsgStr = StringManager.Instance.SpawnString(100);
		this.ItemNameStr = StringManager.Instance.SpawnString(100);
		this.TipStr = StringManager.Instance.SpawnString(150);
		UIButton component2 = this.ThisTransform.GetChild(0).GetComponent<UIButton>();
		component2.m_BtnID1 = 1;
		component2.m_Handler = this;
		this.SlashRect = this.ThisTransform.GetChild(7).GetChild(0).GetComponent<RectTransform>();
		this.ItemRect = this.ThisTransform.GetChild(4).GetComponent<UIHIBtn>().GetComponent<RectTransform>();
		instance.InitianHeroItemImg(this.ItemRect, eHeroOrItem.Item, this.ItemID, 0, 0, 0, false, true, true, false);
		base.AddRefreshText(this.ItemRect.GetChild(4).GetComponent<UIText>());
		Equip recordByKey = instance2.EquipTable.GetRecordByKey(this.ItemID);
		this.eType = (EItemType)(recordByKey.EquipKind - 1);
		bool flag = this.eType >= EItemType.EIT_AllianceTreasureBox && this.eType <= EItemType.EIT_ComboTreasureBox;
		int num = (int)instance2.GetCurItemQuantity(this.ItemID, 0);
		int num2 = 1;
		component2 = this.ThisTransform.GetChild(9).GetComponent<UIButton>();
		component2.m_BtnID1 = 0;
		component2.m_Handler = this;
		this.OkRect = component2.GetComponent<RectTransform>();
		component2 = this.ThisTransform.GetChild(10).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 1;
		this.CancelRect = component2.GetComponent<RectTransform>();
		this.ItemNameText = this.ThisTransform.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.ItemNameText.font = ttffont;
		this.ItemNameText.text = instance2.mStringTable.GetStringByID((uint)recordByKey.EquipName);
		base.AddRefreshText(this.ItemNameText);
		if (this.eType == EItemType.EIT_MaterialTreasureBox && recordByKey.PropertiesInfo[0].Propertieskey == 4)
		{
			num2 = Mathf.Clamp(num, 1, 100);
		}
		else if (this.eType == EItemType.EIT_MaterialTreasureBox && (recordByKey.PropertiesInfo[2].Propertieskey < 1 || recordByKey.PropertiesInfo[2].Propertieskey > 3))
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(instance2.mStringTable.GetStringByID((uint)(7734 + recordByKey.PropertiesInfo[0].Propertieskey)));
			cstring.AppendFormat(instance2.mStringTable.GetStringByID(7739u));
			cstring.Append(instance2.mStringTable.GetStringByID((uint)recordByKey.EquipName));
			this.ItemNameStr.ClearString();
			this.ItemNameStr.Append(cstring);
			this.ItemNameText.text = this.ItemNameStr.ToString();
			this.ItemNameText.SetAllDirty();
			this.ItemNameText.cachedTextGenerator.Invalidate();
			num2 = Mathf.Clamp(num, 1, 100);
		}
		this.TitleText = this.ThisTransform.GetChild(2).GetChild(1).GetComponent<UIText>();
		if (flag)
		{
			this.TitleText.text = instance2.mStringTable.GetStringByID(234u);
		}
		else
		{
			this.TitleText.text = instance2.mStringTable.GetStringByID(283u);
		}
		this.TitleText.font = ttffont;
		base.AddRefreshText(this.TitleText);
		this.TipText = this.ThisTransform.GetChild(8).GetComponent<UIText>();
		this.TipText.font = ttffont;
		base.AddRefreshText(this.TipText);
		this.TipImageRect = this.ThisTransform.GetChild(8).GetChild(0).GetComponent<RectTransform>();
		this.TipImage = this.TipImageRect.GetComponent<Image>();
		this.TimeMsgText = this.ThisTransform.GetChild(2).GetChild(2).GetComponent<UIText>();
		this.TimeMsgText.font = ttffont;
		base.AddRefreshText(this.TimeMsgText);
		UIText component3 = this.ThisTransform.GetChild(9).GetChild(0).GetComponent<UIText>();
		component3.text = instance2.mStringTable.GetStringByID(94u);
		component3.font = ttffont;
		base.AddRefreshText(component3);
		component3 = this.ThisTransform.GetChild(10).GetChild(0).GetComponent<UIText>();
		component3.text = instance2.mStringTable.GetStringByID(4u);
		component3.font = ttffont;
		base.AddRefreshText(component3);
		this.MaxQtyStr = this.ThisTransform.GetChild(6).GetComponent<UIText>();
		this.MaxQtyStr.font = ttffont;
		base.AddRefreshText(this.MaxQtyStr);
		this.UseTargetID = (ushort)arg2;
		this.SpriteArray = this.ThisTransform.GetChild(11).GetComponent<UISpritesArray>();
		byte b = recordByKey.EquipKind;
		byte b2 = 0;
		b -= 1;
		this.QuequIndex = instance.BagTagSaved[9];
		if (b == 10)
		{
			this.ThisTransform.GetChild(8).GetChild(0).gameObject.SetActive(true);
			if (recordByKey.PropertiesInfo[0].Propertieskey <= 7)
			{
				this.TipImage.sprite = this.SpriteArray.GetSprite((int)(4 + recordByKey.PropertiesInfo[0].Propertieskey));
				this.MsgIcon.sprite = this.SpriteArray.GetSprite((int)(4 + recordByKey.PropertiesInfo[0].Propertieskey));
			}
			else
			{
				this.TipImage.sprite = this.SpriteArray.GetSprite(13);
				this.MsgIcon.sprite = this.SpriteArray.GetSprite(13);
			}
			this.TipImage.SetNativeSize();
			this.MsgIcon.SetNativeSize();
			this.NeedResourceType = (ResourceType)(recordByKey.PropertiesInfo[0].Propertieskey - 1);
			this.TipText.color = new Color(0f, 1f, 0.8f);
			this.TipText.rectTransform.sizeDelta = new Vector2(this.TipText.rectTransform.sizeDelta.x - 32f, this.TipText.rectTransform.sizeDelta.y);
			this.TipText.rectTransform.anchoredPosition = new Vector2(this.TipText.rectTransform.anchoredPosition.x + 16f, this.TipText.rectTransform.anchoredPosition.y);
		}
		else if (b == 5)
		{
			this.ItemAddVal = (uint)recordByKey.PropertiesInfo[0].PropertiesValue;
			int num3;
			string stringByID;
			if (PetManager.Instance.IsPetItem(this.ItemID))
			{
				PetData petData = PetManager.Instance.FindPetData(this.UseTargetID);
				if (petData == null)
				{
					this.slider = this.ThisTransform.GetChild(5).gameObject.AddComponent<UnitResourcesSlider>();
					this.slider.gameObject.SetActive(false);
					return;
				}
				this.petRare = petData.Rare;
				if (this.petRare > 0 && this.petRare <= 5)
				{
					this.petRare -= 1;
				}
				else
				{
					this.petRare = 0;
				}
				PetExpTbl recordByKey2 = PetManager.Instance.PetExpTable.GetRecordByKey((ushort)petData.Level);
				if (petData.Level >= 60)
				{
					this.OriginExpRatio = 0;
				}
				else if (recordByKey2.ExpValue[(int)this.petRare] > 0u)
				{
					this.OriginExpRatio = (ushort)(petData.Exp * 100u / recordByKey2.ExpValue[(int)this.petRare]);
				}
				if (recordByKey2.ExpValue[(int)this.petRare] - petData.Exp == 1u)
				{
					this.OriginExpRatio = 99;
				}
				num3 = Mathf.Clamp(this.GetMaxPetExpItems(), 0, num);
				this.UseType = NumberConfirm._UseType.PetExp;
				stringByID = instance2.mStringTable.GetStringByID((uint)PetManager.Instance.PetTable.GetRecordByKey(petData.ID).Name);
				instance.InitianHeroItemImg(this.ThisTransform.GetChild(3).GetChild(0), eHeroOrItem.Pet, 0, 0, 0, 0, true, false, true, false);
				instance.ChangeHeroItemImg(this.ThisTransform.GetChild(3).GetChild(0), eHeroOrItem.Pet, petData.ID, petData.Enhance, 0, 0);
			}
			else
			{
				CurHeroData curHeroData = instance2.curHeroData.Find((uint)this.UseTargetID);
				LevelUp recordByKey3 = instance2.LevelUpTable.GetRecordByKey((ushort)curHeroData.Level);
				this.OriginExpRatio = (ushort)(curHeroData.Exp * 100u / recordByKey3.HeroExp);
				if (recordByKey3.HeroExp - curHeroData.Exp == 1u)
				{
					this.OriginExpRatio = 99;
				}
				num3 = Mathf.Clamp(this.GetMaxHerExpItems(), 0, num);
				this.UseType = NumberConfirm._UseType.Hero;
				stringByID = instance2.mStringTable.GetStringByID((uint)instance2.HeroTable.GetRecordByKey(curHeroData.ID).HeroTitle);
				instance.InitianHeroItemImg(this.ThisTransform.GetChild(3).GetChild(0), eHeroOrItem.Hero, 0, 0, 0, 0, true, false, true, false);
				instance.ChangeHeroItemImg(this.ThisTransform.GetChild(3).GetChild(0), eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, 0, 0);
			}
			if (num3 == 0 && num > 0)
			{
				b2 = 1;
			}
			num = num3;
			this.ThisTransform.GetChild(3).gameObject.SetActive(true);
			this.ThisTransform.GetChild(8).GetChild(0).gameObject.SetActive(false);
			this.ThisTransform.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(true);
			RectTransform component4 = this.ThisTransform.GetChild(4).GetComponent<RectTransform>();
			Vector2 anchoredPosition = component4.anchoredPosition;
			anchoredPosition.Set(-148f, 74.5f);
			component4.anchoredPosition = anchoredPosition;
			anchoredPosition = this.ItemNameText.rectTransform.anchoredPosition;
			anchoredPosition.Set(50.3f, 339.21f);
			this.ItemNameText.rectTransform.anchoredPosition = anchoredPosition;
			this.TipText = this.ThisTransform.GetChild(2).GetChild(1).GetComponent<UIText>();
			anchoredPosition = this.TipText.rectTransform.anchoredPosition;
			anchoredPosition.Set(0.8f, -66.5f);
			this.TipText.rectTransform.anchoredPosition = anchoredPosition;
			this.NameTitle.ClearString();
			this.NameTitle.StringToFormat(stringByID);
			this.NameTitle.AppendFormat(instance2.mStringTable.GetStringByID(246u));
			component3 = this.ThisTransform.GetChild(3).GetChild(1).GetComponent<UIText>();
			component3.text = this.NameTitle.ToString();
			component3.font = ttffont;
			base.AddRefreshText(component3);
			this.ExpChange = this.ThisTransform.GetChild(3).GetChild(2).GetComponent<UIText>();
			this.ExpChange.text = instance2.mStringTable.GetStringByID(4u);
			this.ExpChange.font = ttffont;
			base.AddRefreshText(this.ExpChange);
		}
		else
		{
			this.ThisTransform.GetChild(8).GetChild(0).gameObject.SetActive(false);
		}
		if (b == 11)
		{
			this.SetTimeUI();
			int num4 = (int)(instance2.queueBarData[(int)this.QuequIndex].StartTime + (long)((ulong)instance2.queueBarData[(int)this.QuequIndex].TotalTime) - instance2.ServerTime - (long)this.GetFreeCompleteTime());
			if (num4 < 0)
			{
				num4 = 0;
			}
			int num5 = (int)(60 * recordByKey.PropertiesInfo[1].Propertieskey);
			int num6 = num4 / num5 + Mathf.Clamp(num4 % num5, 0, 1);
			if (num6 <= num)
			{
				num = num6;
				num2 = num4 / num5;
				if (num2 == 0)
				{
					num2++;
				}
			}
			else
			{
				num2 = num;
			}
		}
		else if (b == 12)
		{
			num2 = num;
		}
		else if (b == 16 || b == 17 || b == 18)
		{
			num2 = Mathf.Clamp(num, 1, 100);
			if (recordByKey.PropertiesInfo[0].Propertieskey == 5)
			{
				if (this.InfoHint == null)
				{
					this.InfoHint = this.ThisTransform.GetChild(4).GetComponent<UIButtonHint>();
				}
				if (this.InfoImgObj == null)
				{
					this.InfoImgObj = this.ThisTransform.GetChild(4).GetChild(0).gameObject;
					this.InfoCanvasGroup = this.ThisTransform.GetChild(4).GetChild(0).GetChild(0).GetComponent<CanvasGroup>();
					this.InfoImgObj.transform.SetAsLastSibling();
				}
				this.InfoHint.GetComponent<UIHIBtn>().m_Handler = this;
				instance.SetItemScaleClickSound(this.InfoHint.GetComponent<UIHIBtn>(), true, true);
				this.InfoHint.enabled = false;
				this.InfoImgObj.SetActive(true);
				this.UseType = NumberConfirm._UseType.Pet;
			}
		}
		else if (b == 9)
		{
			if (recordByKey.PropertiesInfo[0].Propertieskey == 30)
			{
				this.bFreeSpeedup = 3;
				this.SetTimeUI();
				this.TimeMsgText.color = Color.white;
				this.ItemAddVal = (uint)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue);
				num2 = (int)Mathf.Clamp((instance2.GetMaxMonsterPoint() - instance2.RoleAttr.MonsterPoint) / this.ItemAddVal, 1f, (float)num);
				if (num > num2)
				{
					num = num2 + 1;
				}
			}
			else if (recordByKey.PropertiesInfo[0].Propertieskey == 40)
			{
				this.TipImageRect.gameObject.SetActive(true);
				this.TipImage.sprite = this.SpriteArray.GetSprite(12);
				this.TipImageRect.GetComponent<Image>().SetNativeSize();
				if (instance2.RoleAttr.ScardStar < 100000000u)
				{
					uint num7 = 100000000u - instance2.RoleAttr.ScardStar;
					int num8 = (int)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue);
					num8 = (int)Mathf.Min((float)((ulong)num7 / (ulong)((long)num8)) + Mathf.Clamp((float)((ulong)num7 % (ulong)((long)num8)), 0f, 1f), 65535f);
					if (num > num8)
					{
						num = num8;
					}
					num2 = num;
				}
				else
				{
					num = (num2 = 0);
				}
			}
			else if (recordByKey.PropertiesInfo[0].Propertieskey == 49)
			{
				this.ThisTransform.GetChild(8).GetChild(0).gameObject.SetActive(true);
				this.TipImage.sprite = this.SpriteArray.GetSprite(13);
				this.MsgIcon.sprite = this.SpriteArray.GetSprite(13);
				this.TipImage.SetNativeSize();
				this.MsgIcon.SetNativeSize();
				this.NeedResourceType = (ResourceType)recordByKey.PropertiesInfo[0].Propertieskey;
				this.TipText.color = new Color(0f, 1f, 0.8f);
				this.TipText.rectTransform.sizeDelta = new Vector2(this.TipText.rectTransform.sizeDelta.x - 32f, this.TipText.rectTransform.sizeDelta.y);
				this.TipText.rectTransform.anchoredPosition = new Vector2(this.TipText.rectTransform.anchoredPosition.x + 16f, this.TipText.rectTransform.anchoredPosition.y);
			}
		}
		if ((this.UseType == NumberConfirm._UseType.Hero || this.UseType == NumberConfirm._UseType.PetExp) && num == 0 && b2 == 0)
		{
			instance.AddHUDMessage(instance2.mStringTable.GetStringByID(744u), 255, true);
			this.OnClose();
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0, 0);
			return;
		}
		this.slider = this.ThisTransform.GetChild(5).gameObject.AddComponent<UnitResourcesSlider>();
		instance.InitUnitResourcesSlider(this.slider.transform, eUnitSlider.AutoUse, 0u, 0u, 1f);
		instance.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnLessen, 210.5f, this.SliderTop, 70f, 60f, 0f, 0f);
		if (flag)
		{
			instance.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 384.5f, this.SliderTop, 257f, 19f, 0f, (float)Mathf.Clamp(num, 1, 100));
		}
		else
		{
			instance.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 384.5f, this.SliderTop, 257f, 19f, 0f, (float)num);
		}
		instance.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnIncrease, 541.2f, this.SliderTop, 70f, 60f, 0f, 0f);
		instance.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.Input, 328f, this.SliderInputTop, 94f, 35f, 0f, 0f);
		this.InputRect = this.slider.transform.GetChild(3).GetComponent<RectTransform>();
		this.slider.transform.GetChild(1).GetComponent<Image>().preserveAspect = true;
		this.slider.transform.GetChild(0).GetComponent<Image>().preserveAspect = true;
		this.slider.BtnInputText.m_Handler = this;
		this.slider.BtnInputText.m_BtnID1 = 2;
		component3 = this.ThisTransform.GetChild(5).GetChild(3).GetChild(0).GetComponent<UIText>();
		component3.fontSize = 24;
		component3.alignment = TextAnchor.MiddleRight;
		base.AddRefreshText(component3);
		this.slider.m_Handler = this;
		this.QtyStr.ClearString();
		this.QtyStr.IntToFormat((long)num, 1, true);
		this.QtyStr.AppendFormat("{0}");
		this.MaxQtyStr.text = this.QtyStr.ToString();
		Material material = this.ThisTransform.GetChild(1).GetChild(0).GetComponent<Image>().material;
		Image component5 = this.ThisTransform.GetChild(5).GetChild(3).GetComponent<Image>();
		component5.material = material;
		component5.sprite = this.SpriteArray.GetSprite(0);
		component5 = this.ThisTransform.GetChild(5).GetChild(0).GetComponent<Image>();
		component5.material = material;
		component5.sprite = this.SpriteArray.GetSprite(1);
		component5 = this.ThisTransform.GetChild(5).GetChild(0).GetChild(0).GetComponent<Image>();
		component5.material = material;
		component5.sprite = this.SpriteArray.GetSprite(1);
		component5 = this.ThisTransform.GetChild(5).GetChild(1).GetComponent<Image>();
		component5.material = material;
		component5.sprite = this.SpriteArray.GetSprite(2);
		component5 = this.ThisTransform.GetChild(5).GetChild(1).GetChild(0).GetComponent<Image>();
		component5.material = material;
		component5.sprite = this.SpriteArray.GetSprite(2);
		component5 = this.ThisTransform.GetChild(5).GetChild(2).GetChild(0).GetComponent<Image>();
		component5.material = material;
		component5.sprite = this.SpriteArray.GetSprite(3);
		component5 = this.ThisTransform.GetChild(5).GetChild(2).GetChild(1).GetChild(0).GetComponent<Image>();
		component5.material = material;
		component5.sprite = this.SpriteArray.GetSprite(3);
		component5 = this.ThisTransform.GetChild(5).GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>();
		component5.material = material;
		component5.sprite = this.SpriteArray.GetSprite(4);
		if (instance.IsArabic)
		{
			this.SlashRect.localScale = new Vector3(-1f, 1f, 1f);
		}
		this.AutouseSlider = this.ThisTransform.GetChild(5).GetChild(2).GetComponent<CSlider>();
		this.AutouseSlider.value = (double)num2;
		this.slider.Value = (long)num2;
		this.UpdateHeroExpText();
		this.UpdatePetExpText();
		this.UpdateResource();
		this.UpdateExp();
		this.UpdateVip();
		this.OnTextChang(this.slider);
		this.UpdateTipText();
	}

	// Token: 0x06002B3D RID: 11069 RVA: 0x004774AC File Offset: 0x004756AC
	private void SetTimeUI()
	{
		this.BackgroundRect.sizeDelta = new Vector2(507f, 447f);
		this.LineImageRect.anchoredPosition = new Vector2(-204f, 131f);
		this.TimeMsgText.gameObject.SetActive(true);
		this.ItemRect.anchoredPosition = new Vector2(-148f, 83f);
		this.ItemNameText.rectTransform.anchoredPosition = new Vector2(51f, 337f);
		this.SliderTop = -322.2f;
		this.SliderInputTop = -272.6f;
		if (this.TipImageRect.gameObject.activeSelf)
		{
			this.TipText.rectTransform.anchoredPosition = new Vector2(17.8f, -100f);
		}
		else
		{
			this.TipText.rectTransform.anchoredPosition = new Vector2(1.8f, -100f);
		}
		this.TipText.fontSize = 18;
		this.TitleText.rectTransform.anchoredPosition = new Vector2(3f, 32.5f);
		this.MaxQtyStr.rectTransform.anchoredPosition = new Vector2(101f, -5f);
		this.OkRect.anchoredPosition = new Vector2(115.5f, -163f);
		this.CancelRect.anchoredPosition = new Vector2(-111.5f, -163f);
		this.MsgIcon.gameObject.SetActive(false);
		this.SlashRect.anchoredPosition = new Vector2(11.6f, -2.8f);
	}

	// Token: 0x06002B3E RID: 11070 RVA: 0x00477650 File Offset: 0x00475850
	public override void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.slider.Value > 0L)
			{
				if (this.UseType == NumberConfirm._UseType.Normal)
				{
					GUIManager.Instance.bContinuousUse = true;
					DataManager.Instance.UseItem(this.ItemID, (ushort)this.slider.Value, this.UseTargetID, 0, 0, 0u, string.Empty, true);
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0, 0);
				}
				else if (this.UseType == NumberConfirm._UseType.Pet)
				{
					if (!GUIManager.Instance.ShowUILock(EUILock.UseItem))
					{
						return;
					}
					MessagePacket messagePacket = new MessagePacket(1024);
					messagePacket.Protocol = Protocol._MSG_REQUEST_PET_OPENPETBOX;
					messagePacket.AddSeqId();
					messagePacket.Add(this.ItemID);
					messagePacket.Add(this.slider.Value);
					messagePacket.Send(false);
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetList, 16, 0);
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0, 0);
				}
				else
				{
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroUse, 0, 0);
					DataManager.Instance.UseItem(this.ItemID, (ushort)this.slider.Value, this.UseTargetID, 0, 0, 0u, string.Empty, true);
				}
			}
			else if (this.MaxUseCount == 0u)
			{
				if (this.UseType == NumberConfirm._UseType.Hero)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(533u), 255, true);
				}
				else if (this.UseType == NumberConfirm._UseType.PetExp)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(16041u), 255, true);
				}
			}
			break;
		case 1:
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0, 0);
			break;
		case 2:
			GUIManager.Instance.m_UICalculator.m_CalculatorHandler = this;
			GUIManager.Instance.m_UICalculator.OpenCalculator(this.slider.MaxValue, this.slider.Value, 290.22f, -25.96f, this.slider, 0L);
			break;
		}
	}

	// Token: 0x06002B3F RID: 11071 RVA: 0x00477878 File Offset: 0x00475A78
	public override void OnHIButtonClick(UIHIBtn sender)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		door.OpenMenu(EGUIWindow.UI_OpenBox, 1, (int)this.ItemID, false);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0, 0);
	}

	// Token: 0x06002B40 RID: 11072 RVA: 0x004778B8 File Offset: 0x00475AB8
	public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
	{
		URS.m_slider.value = (double)mValue;
		URS.Value = (long)URS.m_slider.value;
		this.UpdateResource();
		this.UpdateExp();
		this.UpdateVip();
		this.UpdateHeroExpText();
		this.UpdatePetExpText();
		this.UpdateTipText();
	}

	// Token: 0x06002B41 RID: 11073 RVA: 0x00477908 File Offset: 0x00475B08
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		if (meg[0] == 35 && this.slider != null)
		{
			this.slider.Refresh_FontTexture();
		}
		if ((this.bFreeSpeedup == 2 && meg[0] == 7) || meg[0] == 40)
		{
			int needResourceType = (int)this.NeedResourceType;
			if (needResourceType < DataManager.Instance.Resource.Length)
			{
				this.RemainRss = DataManager.Instance.Resource[needResourceType].Stock;
			}
			else
			{
				if (needResourceType != 49)
				{
					return;
				}
				this.RemainRss = DataManager.Instance.PetResource.Stock;
			}
			this.UpdateResource();
		}
		else if (this.bFreeSpeedup == 3 && meg[0] == 34)
		{
			this.UpdateTipText();
		}
	}

	// Token: 0x06002B42 RID: 11074 RVA: 0x004779E0 File Offset: 0x00475BE0
	public override void UpdateUI(int arge1, int arge2)
	{
		if (arge1 == -1)
		{
			return;
		}
		if ((arge1 & 1073741824) > 0)
		{
			this.bFreeSpeedup = (byte)(arge1 & -1073741825);
			if (this.bFreeSpeedup == 0)
			{
				this.TimeMsgColor = new Color(0f, 1f, 0.8f);
			}
			else
			{
				this.TimeMsgColor = new Color(0.773f, 0.447f, 1f);
			}
			this.ItemUIUpdate((int)this.ItemID, (int)this.UseTargetID);
			this.UpdateFreeTimeStr();
			this.OnTextChang(this.slider);
			return;
		}
		if (this.UseType == NumberConfirm._UseType.Normal)
		{
			this.ItemUIUpdate(arge1, arge2);
		}
	}

	// Token: 0x06002B43 RID: 11075 RVA: 0x00477A8C File Offset: 0x00475C8C
	public void ItemUIUpdate(int arge1, int arge2)
	{
		GUIManager instance = GUIManager.Instance;
		DataManager instance2 = DataManager.Instance;
		this.UseType = NumberConfirm._UseType.Normal;
		this.ItemID = (ushort)arge1;
		instance.ChangeHeroItemImg(this.ItemRect, eHeroOrItem.Item, this.ItemID, 0, 0, 0);
		this.QtyStr.ClearString();
		this.QuequIndex = instance.BagTagSaved[9];
		this.TipImageRect.gameObject.SetActive(false);
		int num = (int)instance2.GetCurItemQuantity(this.ItemID, 0);
		int num2 = 1;
		Equip recordByKey = instance2.EquipTable.GetRecordByKey(this.ItemID);
		this.eType = (EItemType)(recordByKey.EquipKind - 1);
		bool flag = this.eType >= EItemType.EIT_AllianceTreasureBox && this.eType <= EItemType.EIT_ComboTreasureBox;
		if (flag)
		{
			this.TitleText.text = instance2.mStringTable.GetStringByID(234u);
		}
		else
		{
			this.TitleText.text = instance2.mStringTable.GetStringByID(283u);
		}
		this.ItemNameText.text = instance2.mStringTable.GetStringByID((uint)recordByKey.EquipName);
		if (this.eType == EItemType.EIT_MaterialTreasureBox && recordByKey.PropertiesInfo[0].Propertieskey == 4)
		{
			num2 = Mathf.Clamp(num, 1, 100);
		}
		else if (recordByKey.EquipKind == 18 && (recordByKey.PropertiesInfo[2].Propertieskey < 1 || recordByKey.PropertiesInfo[2].Propertieskey > 3))
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.StringToFormat(instance2.mStringTable.GetStringByID((uint)(7734 + recordByKey.PropertiesInfo[0].Propertieskey)));
			cstring.AppendFormat(instance2.mStringTable.GetStringByID(7739u));
			cstring.Append(instance2.mStringTable.GetStringByID((uint)recordByKey.EquipName));
			this.ItemNameStr.ClearString();
			this.ItemNameStr.Append(cstring);
			this.ItemNameText.text = this.ItemNameStr.ToString();
			this.ItemNameText.SetAllDirty();
			this.ItemNameText.cachedTextGenerator.Invalidate();
			num2 = Mathf.Clamp(num, 1, 100);
		}
		else if (recordByKey.EquipKind == 12)
		{
			int num3 = (int)(instance2.queueBarData[(int)this.QuequIndex].StartTime + (long)((ulong)instance2.queueBarData[(int)this.QuequIndex].TotalTime) - instance2.ServerTime - (long)this.GetFreeCompleteTime());
			if (num3 < 0)
			{
				num3 = 0;
			}
			int num4 = (int)(60 * recordByKey.PropertiesInfo[1].Propertieskey);
			int num5 = num3 / num4 + Mathf.Clamp(num3 % num4, 0, 1);
			if (num5 <= num)
			{
				num = num5;
				num2 = num3 / num4;
				if (num2 == 0)
				{
					num2++;
				}
			}
			else
			{
				num2 = num;
			}
		}
		else if (recordByKey.EquipKind == 13)
		{
			num2 = num;
		}
		else if (recordByKey.EquipKind == 17 || recordByKey.EquipKind == 18 || recordByKey.EquipKind == 19)
		{
			num2 = Mathf.Clamp(num, 1, 100);
		}
		else if (recordByKey.EquipKind == 10)
		{
			if (recordByKey.PropertiesInfo[0].Propertieskey == 30)
			{
				this.ItemAddVal = (uint)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue);
				num2 = (int)Mathf.Clamp((instance2.GetMaxMonsterPoint() - instance2.RoleAttr.MonsterPoint) / this.ItemAddVal, 1f, (float)num);
				if (num > num2)
				{
					num = num2 + 1;
				}
			}
			else if (recordByKey.PropertiesInfo[0].Propertieskey == 40)
			{
				this.TipImageRect.gameObject.SetActive(true);
				this.TipImage.sprite = this.SpriteArray.GetSprite(12);
				this.TipImage.SetNativeSize();
				if (instance2.RoleAttr.ScardStar < 100000000u)
				{
					uint num6 = 100000000u - instance2.RoleAttr.ScardStar;
					int num7 = (int)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue);
					num7 = (int)Mathf.Min((float)((ulong)num6 / (ulong)((long)num7)) + Mathf.Clamp((float)((ulong)num6 % (ulong)((long)num7)), 0f, 1f), 65535f);
					if (num > num7)
					{
						num = num7;
					}
					num2 = num;
				}
				else
				{
					num = (num2 = 0);
				}
			}
		}
		if (flag)
		{
			instance.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 384.5f, this.SliderTop, 257f, 19f, 0f, (float)Mathf.Clamp(num, 1, 100));
		}
		else
		{
			instance.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 384.5f, this.SliderTop, 257f, 19f, 0f, (float)num);
		}
		this.slider.m_slider.value = (double)num2;
		this.AutouseSlider.value = this.slider.m_slider.value;
		this.slider.Value = (long)this.slider.m_slider.value;
		if (recordByKey.EquipKind == 11)
		{
			this.TipImageRect.gameObject.SetActive(true);
			if (recordByKey.PropertiesInfo[0].Propertieskey <= 7)
			{
				this.TipImage.sprite = this.SpriteArray.GetSprite((int)(4 + recordByKey.PropertiesInfo[0].Propertieskey));
				this.MsgIcon.sprite = this.SpriteArray.GetSprite((int)(4 + recordByKey.PropertiesInfo[0].Propertieskey));
			}
			else
			{
				this.TipImage.sprite = this.SpriteArray.GetSprite(13);
				this.MsgIcon.sprite = this.SpriteArray.GetSprite(13);
			}
			this.TipImage.SetNativeSize();
			this.MsgIcon.SetNativeSize();
			this.NeedResourceType = (ResourceType)(recordByKey.PropertiesInfo[0].Propertieskey - 1);
		}
		this.QtyStr.IntToFormat((long)num, 1, true);
		this.QtyStr.AppendFormat("{0}");
		this.MaxQtyStr.text = this.QtyStr.ToString();
		this.UpdateResource();
		this.UpdateExp();
		this.UpdateVip();
		this.UpdateTipText();
	}

	// Token: 0x06002B44 RID: 11076 RVA: 0x00478138 File Offset: 0x00476338
	public void SetNeedItemQty(uint Remain, uint Need)
	{
		DataManager instance = DataManager.Instance;
		GUIManager instance2 = GUIManager.Instance;
		Equip recordByKey = instance.EquipTable.GetRecordByKey(this.ItemID);
		this.ItemAddVal = (uint)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue);
		if (Remain >= Need)
		{
			return;
		}
		int curItemQuantity = (int)instance.GetCurItemQuantity(this.ItemID, 0);
		this.RemainRss = Remain;
		this.NeedRss = Need;
		this.slider.m_slider.value = (double)Mathf.Clamp((this.NeedRss - this.RemainRss) / this.ItemAddVal, 1f, (float)curItemQuantity);
		this.AutouseSlider.value = this.slider.m_slider.value;
		this.slider.Value = (long)this.slider.m_slider.value;
		this.bFreeSpeedup = 2;
		this.SetTimeUI();
		this.MsgIcon.gameObject.SetActive(true);
		instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnLessen, 210.5f, this.SliderTop, 70f, 60f, 0f, 0f);
		instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 384.5f, this.SliderTop, 257f, 19f, 0f, (float)curItemQuantity);
		instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnIncrease, 541.2f, this.SliderTop, 70f, 60f, 0f, 0f);
		this.InputRect.anchoredPosition = new Vector2(328f, this.SliderInputTop);
		this.InputRect.sizeDelta = new Vector2(94f, 35f);
		this.OnTextChang(this.slider);
	}

	// Token: 0x06002B45 RID: 11077 RVA: 0x00478310 File Offset: 0x00476510
	public void OnVauleChang(UnitResourcesSlider sender)
	{
		this.Cstr.ClearString();
		StringManager.IntToStr(this.Cstr, sender.Value, 1, true);
		sender.m_inputText.text = this.Cstr.ToString();
		sender.m_inputText.SetAllDirty();
		sender.m_inputText.cachedTextGenerator.Invalidate();
		this.UpdateResource();
		this.UpdateExp();
		this.UpdateVip();
		this.UpdateHeroExpText();
		this.UpdatePetExpText();
		this.UpdateTipText();
	}

	// Token: 0x06002B46 RID: 11078 RVA: 0x00478394 File Offset: 0x00476594
	public void OnTextChang(UnitResourcesSlider sender)
	{
		this.Cstr.ClearString();
		StringManager.IntToStr(this.Cstr, sender.Value, 1, true);
		sender.m_inputText.text = this.Cstr.ToString();
		sender.m_inputText.SetAllDirty();
		sender.m_inputText.cachedTextGenerator.Invalidate();
		this.UpdateHeroExpText();
		this.UpdatePetExpText();
		this.UpdateResource();
		this.UpdateExp();
		this.UpdateVip();
		this.UpdateTipText();
	}

	// Token: 0x06002B47 RID: 11079 RVA: 0x00478418 File Offset: 0x00476618
	public override void OnClose()
	{
		if (this.QtyStr == null)
		{
			return;
		}
		StringManager.Instance.DeSpawnString(this.QtyStr);
		StringManager.Instance.DeSpawnString(this.TimeStr);
		StringManager.Instance.DeSpawnString(this.NameTitle);
		StringManager.Instance.DeSpawnString(this.Cstr);
		StringManager.Instance.DeSpawnString(this.ItemNameStr);
		StringManager.Instance.DeSpawnString(this.TimeMsgStr);
		StringManager.Instance.DeSpawnString(this.TipStr);
		this.QtyStr = null;
		UnityEngine.Object.Destroy(this.ThisTransform.gameObject);
		GUIManager.Instance.ClearCalculator();
	}

	// Token: 0x06002B48 RID: 11080 RVA: 0x004784CC File Offset: 0x004766CC
	public void UpdateTipText()
	{
		if (this.UseType == NumberConfirm._UseType.Hero || this.UseType == NumberConfirm._UseType.PetExp)
		{
			return;
		}
		float num = 0f;
		DataManager instance = DataManager.Instance;
		Equip recordByKey = instance.EquipTable.GetRecordByKey(this.ItemID);
		CString cstring = StringManager.Instance.StaticString1024();
		this.TipStr.ClearString();
		this.TipText.color = new Color(0f, 1f, 0.8f);
		if (recordByKey.EquipKind == 11)
		{
			if (this.slider.Value == (long)((ulong)this.MaxUseCount))
			{
				this.TipText.color = new Color(1f, 0.29f, 0.459f);
				this.TipStr.Append(instance.mStringTable.GetStringByID(898u));
			}
			else
			{
				this.TipText.color = Color.white;
				cstring.IntToFormat((long)((ulong)((uint)((long)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue) * this.slider.Value))), 1, true);
				cstring.AppendFormat("{0}");
				this.TipStr.StringToFormat(cstring);
				this.TipStr.AppendFormat(instance.mStringTable.GetStringByID(231u));
				if (this.bFreeSpeedup == 2 && (ulong)this.NeedRss < (ulong)this.RemainRss + (ulong)this.ItemAddVal * (ulong)this.slider.Value)
				{
					this.TipText.color = new Color(1f, 0.53f, 0.56f);
					this.TipStr.Append(" ");
					this.TipStr.Append(instance.mStringTable.GetStringByID(973u));
				}
			}
		}
		else if (recordByKey.EquipKind == 12 && ((byte)recordByKey.PropertiesInfo[0].Propertieskey == 1 || (byte)recordByKey.PropertiesInfo[0].Propertieskey == 12 || (byte)recordByKey.PropertiesInfo[0].Propertieskey == 17 || (byte)recordByKey.PropertiesInfo[0].Propertieskey == 18 || (byte)recordByKey.PropertiesInfo[0].Propertieskey == 21 || (byte)recordByKey.PropertiesInfo[0].Propertieskey == 22))
		{
			this.TipText.color = Color.white;
			this.ItemAddVal = (uint)recordByKey.PropertiesInfo[1].Propertieskey;
			TimeSpan timeSpan = new TimeSpan((long)((ulong)(60u * this.ItemAddVal) * (ulong)this.slider.Value * 10000000UL));
			this.TimeStr.ClearString();
			if (timeSpan.Days > 0)
			{
				this.TimeStr.IntToFormat((long)timeSpan.Days, 1, false);
				this.TimeStr.IntToFormat((long)timeSpan.Hours, 2, false);
				this.TimeStr.IntToFormat((long)timeSpan.Minutes, 2, false);
				this.TimeStr.IntToFormat((long)timeSpan.Seconds, 2, false);
				this.TimeStr.AppendFormat("{0}d:{1}:{2}:{3}");
			}
			else if (timeSpan.Ticks > 0L)
			{
				if (timeSpan.Hours > 0)
				{
					this.TimeStr.IntToFormat((long)timeSpan.Hours, 2, false);
					this.TimeStr.IntToFormat((long)timeSpan.Minutes, 2, false);
					this.TimeStr.IntToFormat((long)timeSpan.Seconds, 2, false);
					this.TimeStr.AppendFormat("{0}:{1}:{2}");
				}
				else if (timeSpan.Minutes > 0)
				{
					this.TimeStr.IntToFormat((long)timeSpan.Minutes, 2, false);
					this.TimeStr.IntToFormat((long)timeSpan.Seconds, 2, false);
					this.TimeStr.AppendFormat("{0}:{1}");
				}
			}
			else
			{
				this.TimeStr.SetChar(0, '0');
				this.TimeStr.SetChar(1, '\0');
			}
			this.TipStr.StringToFormat(this.TimeStr);
			this.TipStr.AppendFormat(instance.mStringTable.GetStringByID(232u));
			if (instance.queueBarData[(int)this.QuequIndex].StartTime + (long)((ulong)instance.queueBarData[(int)this.QuequIndex].TotalTime) - instance.ServerTime < timeSpan.Ticks / 10000000L)
			{
				this.TipText.color = new Color(1f, 0.53f, 0.56f);
				this.TipStr.Append(" ");
				this.TipStr.Append(instance.mStringTable.GetStringByID(233u));
			}
			this.UpdateFreeTimeStr();
		}
		else if (recordByKey.EquipKind == 10)
		{
			if (recordByKey.PropertiesInfo[0].Propertieskey == 33)
			{
				cstring.Append("<color=#FFFFFFFF>");
				cstring.IntToFormat((long)instance.RoleAttr.Level, 1, false);
				cstring.IntToFormat((long)Mathf.Clamp((int)this.OriginExpRatio, 0, 99), 1, false);
				cstring.IntToFormat((long)this.saveRoleLv, 1, false);
				cstring.IntToFormat((long)Mathf.Clamp((int)this.RoleExpRatio, 0, 99), 1, false);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(531u));
				cstring.Append("</color>");
				if (this.saveRoleLv == 60)
				{
					cstring.StringToFormat(" <color=#ff4a75ff>");
					cstring.StringToFormat(instance.mStringTable.GetStringByID(898u));
					cstring.StringToFormat("</color>");
					cstring.AppendFormat("{0}{1}{2}");
				}
				this.TipStr.Append(cstring);
			}
			else if (recordByKey.PropertiesInfo[0].Propertieskey == 30)
			{
				string text = null;
				this.TimeMsgStr.ClearString();
				uint num2 = (uint)((long)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue) * this.slider.Value);
				GameConstants.FormatResourceValue(cstring, num2);
				uint num3 = instance.RoleAttr.MonsterPoint + num2;
				if (num3 > instance.GetMaxMonsterPoint())
				{
					this.TipText.color = new Color(1f, 0.29f, 0.459f);
					text = instance.mStringTable.GetStringByID(906u);
					this.TimeMsgStr.Append("<color=#ff4a75ff>");
				}
				else
				{
					this.TipText.color = Color.white;
					this.TimeMsgStr.Append("<color=#ffffffff>");
				}
				this.TipStr.StringToFormat(cstring);
				this.TipStr.AppendFormat(instance.mStringTable.GetStringByID(905u));
				if (text != null)
				{
					this.TipStr.Append(" ");
					this.TipStr.Append(text);
				}
				if (GUIManager.Instance.IsArabic)
				{
					this.TimeMsgStr.ClearString();
					this.TimeMsgStr.IntToFormat((long)((ulong)num3), 1, true);
					this.TimeMsgStr.IntToFormat((long)((ulong)instance.GetMaxMonsterPoint()), 1, true);
					this.TimeMsgStr.StringToFormat("</color>");
					if (num3 > instance.GetMaxMonsterPoint())
					{
						this.TimeMsgStr.StringToFormat("<color=#ff4a75ff>");
					}
					else
					{
						this.TimeMsgStr.StringToFormat("<color=#ffffffff>");
					}
					this.TimeMsgStr.AppendFormat("{1}/{3}{0}{2}");
				}
				else
				{
					this.TimeMsgStr.IntToFormat((long)((ulong)num3), 1, true);
					this.TimeMsgStr.StringToFormat("</color>");
					this.TimeMsgStr.IntToFormat((long)((ulong)instance.GetMaxMonsterPoint()), 1, true);
					this.TimeMsgStr.AppendFormat("{0}{1}/{2}");
				}
				this.TimeMsgText.text = this.TimeMsgStr.ToString();
				this.TimeMsgText.SetAllDirty();
				this.TimeMsgText.cachedTextGenerator.Invalidate();
			}
			else if (recordByKey.PropertiesInfo[0].Propertieskey == 40)
			{
				int num4 = (int)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue);
				cstring.Append("<color=#FFFFFFFF>");
				cstring.IntToFormat(this.slider.Value * (long)num4, 1, true);
				cstring.AppendFormat(instance.mStringTable.GetStringByID(231u));
				cstring.Append("</color>");
				this.TipStr.Append(cstring);
				num = -4f;
			}
			else if (recordByKey.PropertiesInfo[0].Propertieskey == 49)
			{
				if (this.slider.Value == (long)((ulong)this.MaxUseCount))
				{
					this.TipText.color = new Color(1f, 0.29f, 0.459f);
					this.TipStr.Append(instance.mStringTable.GetStringByID(898u));
				}
				else
				{
					this.TipText.color = Color.white;
					cstring.IntToFormat((long)((ulong)((uint)((long)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue) * this.slider.Value))), 1, true);
					cstring.AppendFormat("{0}");
					this.TipStr.StringToFormat(cstring);
					this.TipStr.AppendFormat(instance.mStringTable.GetStringByID(231u));
					if (this.bFreeSpeedup == 2 && (ulong)this.NeedRss < (ulong)this.RemainRss + (ulong)this.ItemAddVal * (ulong)this.slider.Value)
					{
						this.TipText.color = new Color(1f, 0.53f, 0.56f);
						this.TipStr.Append(" ");
						this.TipStr.Append(instance.mStringTable.GetStringByID(973u));
					}
				}
			}
		}
		else if (recordByKey.EquipKind == 13)
		{
			cstring.Append("<color=#FFFFFFFF>");
			cstring.IntToFormat((long)instance.RoleAttr.VIPLevel, 1, false);
			cstring.IntToFormat((long)Mathf.Clamp((int)this.OriginExpRatio, 0, 99), 1, false);
			cstring.IntToFormat((long)this.saveRoleLv, 1, false);
			cstring.IntToFormat((long)this.RoleExpRatio, 1, false);
			cstring.AppendFormat(instance.mStringTable.GetStringByID(620u));
			cstring.Append("</color>");
			if (this.saveRoleLv == instance.RoleAttr.VIPLevelMax)
			{
				cstring.StringToFormat(" <color=#ff4a75ff>");
				cstring.StringToFormat(instance.mStringTable.GetStringByID(898u));
				cstring.StringToFormat("</color>");
				cstring.AppendFormat("{0}{1}{2}");
			}
			this.TipStr.Append(cstring);
		}
		this.TipText.text = this.TipStr.ToString();
		this.TipText.SetAllDirty();
		this.TipText.cachedTextGenerator.Invalidate();
		this.TipText.cachedTextGeneratorForLayout.Invalidate();
		Vector2 anchoredPosition = this.TipImageRect.anchoredPosition;
		anchoredPosition.x = -this.TipText.preferredWidth * 0.5f - this.TipImageRect.sizeDelta.x * 0.5f;
		anchoredPosition.x += num;
		if (anchoredPosition.x < -239f)
		{
			anchoredPosition.x = -239f;
		}
		this.TipImageRect.anchoredPosition = anchoredPosition;
	}

	// Token: 0x06002B49 RID: 11081 RVA: 0x004790C0 File Offset: 0x004772C0
	private void UpdateFreeTimeStr()
	{
		DataManager instance = DataManager.Instance;
		TimeSpan timeSpan = new TimeSpan((long)((ulong)(60u * this.ItemAddVal) * (ulong)this.slider.Value * 10000000UL));
		if (instance.queueBarData[(int)this.QuequIndex].StartTime + (long)((ulong)instance.queueBarData[(int)this.QuequIndex].TotalTime) - instance.ServerTime < timeSpan.Ticks / 10000000L)
		{
			this.TimeMsgText.color = new Color(1f, 0.53f, 0.56f);
			this.TimeMsgText.text = instance.mStringTable.GetStringByID(971u);
		}
		else if (this.bFreeSpeedup == 1 && instance.queueBarData[(int)this.QuequIndex].StartTime + (long)((ulong)instance.queueBarData[(int)this.QuequIndex].TotalTime) - instance.ServerTime - (long)this.GetFreeCompleteTime() <= timeSpan.Ticks / 10000000L)
		{
			this.TimeMsgText.color = this.TimeMsgColor;
			this.TimeMsgText.text = instance.mStringTable.GetStringByID(970u);
		}
		else
		{
			this.TimeMsgText.color = this.TimeMsgColor;
			long ticks = (instance.queueBarData[(int)this.QuequIndex].StartTime + (long)((ulong)instance.queueBarData[(int)this.QuequIndex].TotalTime) - instance.ServerTime - (long)this.GetFreeCompleteTime() - (long)((ulong)(60u * this.ItemAddVal) * (ulong)this.slider.Value)) * 10000000L;
			timeSpan = new TimeSpan(ticks);
			CString cstring = StringManager.Instance.StaticString1024();
			if (timeSpan.Days > 0)
			{
				cstring.IntToFormat((long)timeSpan.Days, 1, false);
				cstring.IntToFormat((long)timeSpan.Hours, 2, false);
				cstring.IntToFormat((long)timeSpan.Minutes, 2, false);
				cstring.IntToFormat((long)timeSpan.Seconds, 2, false);
				cstring.AppendFormat("{0}d:{1}:{2}:{3}");
			}
			else if (timeSpan.Ticks > 0L)
			{
				if (timeSpan.Hours > 0)
				{
					cstring.IntToFormat((long)timeSpan.Hours, 2, false);
					cstring.IntToFormat((long)timeSpan.Minutes, 2, false);
					cstring.IntToFormat((long)timeSpan.Seconds, 2, false);
					cstring.AppendFormat("{0}:{1}:{2}");
				}
				else if (timeSpan.Minutes > 0)
				{
					cstring.IntToFormat((long)timeSpan.Minutes, 2, false);
					cstring.IntToFormat((long)timeSpan.Seconds, 2, false);
					cstring.AppendFormat("{0}:{1}");
				}
				else
				{
					cstring.IntToFormat((long)timeSpan.Seconds, 2, false);
					cstring.AppendFormat("00:{0}");
				}
			}
			else
			{
				cstring.SetChar(0, '0');
				cstring.SetChar(1, '\0');
			}
			this.TimeMsgStr.ClearString();
			this.TimeMsgStr.StringToFormat(cstring);
			if (this.bFreeSpeedup == 1)
			{
				this.TimeMsgStr.AppendFormat(instance.mStringTable.GetStringByID(969u));
			}
			else
			{
				this.TimeMsgStr.AppendFormat(instance.mStringTable.GetStringByID(972u));
			}
			this.TimeMsgText.text = this.TimeMsgStr.ToString();
			this.TimeMsgText.SetAllDirty();
			this.TimeMsgText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06002B4A RID: 11082 RVA: 0x0047944C File Offset: 0x0047764C
	private ushort GetFreeCompleteTime()
	{
		if (this.bFreeSpeedup == 0)
		{
			return 0;
		}
		return DataManager.Instance.GetFreeCompleteTime();
	}

	// Token: 0x06002B4B RID: 11083 RVA: 0x00479468 File Offset: 0x00477668
	public override void UpdateTime(bool bOnSecond)
	{
		if (!this.ThisTransform.gameObject.activeSelf)
		{
			return;
		}
		if (bOnSecond && this.bFreeSpeedup < 2 && this.TimeMsgText.gameObject.activeSelf)
		{
			this.UpdateFreeTimeStr();
		}
		if (this.InfoImgObj != null && this.InfoImgObj.activeSelf)
		{
			this.DeltaTime += Time.deltaTime;
			if (this.DeltaTime >= 2f)
			{
				this.DeltaTime = 0f;
			}
			float alpha = (this.DeltaTime <= 1f) ? this.DeltaTime : (2f - this.DeltaTime);
			this.InfoCanvasGroup.alpha = alpha;
		}
	}

	// Token: 0x06002B4C RID: 11084 RVA: 0x0047953C File Offset: 0x0047773C
	public void UpdateResource()
	{
		EItemType eitemType = this.eType;
		if (eitemType != EItemType.EIT_CaseByCase)
		{
			if (eitemType != EItemType.EIT_Resource)
			{
				return;
			}
		}
		else if ((byte)DataManager.Instance.EquipTable.GetRecordByKey(this.ItemID).PropertiesInfo[0].Propertieskey != 49)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		Equip recordByKey = instance.EquipTable.GetRecordByKey(this.ItemID);
		this.MaxUseCount = 0u;
		this.ItemAddVal = (uint)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue);
		uint num = 0u;
		if ((int)recordByKey.PropertiesInfo[0].Propertieskey <= instance.Resource.Length)
		{
			num = uint.MaxValue - instance.Resource[(int)(recordByKey.PropertiesInfo[0].Propertieskey - 1)].Stock;
		}
		else if (recordByKey.PropertiesInfo[0].Propertieskey == 6)
		{
			num = uint.MaxValue - instance.RoleAttr.Diamond;
		}
		else if ((byte)recordByKey.PropertiesInfo[0].Propertieskey == 49)
		{
			num = uint.MaxValue - instance.PetResource.Stock;
		}
		if (num >= this.ItemAddVal)
		{
			this.MaxUseCount = num / this.ItemAddVal + (uint)Mathf.Clamp(num % this.ItemAddVal, 0f, 1f);
			if (this.slider.Value > (long)((ulong)this.MaxUseCount))
			{
				this.slider.Value = (long)((ulong)this.MaxUseCount);
			}
		}
		else
		{
			this.slider.Value = 0L;
		}
		this.slider.m_slider.value = (double)this.slider.Value;
		if (this.bFreeSpeedup == 2)
		{
			this.TimeMsgStr.ClearString();
			this.TimeMsgText.color = Color.white;
			if ((ulong)this.NeedRss > (ulong)this.RemainRss + (ulong)this.ItemAddVal * (ulong)this.slider.Value)
			{
				this.TimeMsgStr.StringToFormat("<color=#ef3a54ff>");
				this.TimeMsgStr.IntToFormat((long)((ulong)this.RemainRss + (ulong)this.ItemAddVal * (ulong)this.slider.Value), 1, true);
				this.TimeMsgStr.StringToFormat("</color>");
				this.TimeMsgStr.IntToFormat((long)((ulong)this.NeedRss), 1, true);
				if (GUIManager.Instance.IsArabic)
				{
					this.TimeMsgStr.AppendFormat("{3}/{0}{1}{2}");
				}
				else
				{
					this.TimeMsgStr.AppendFormat("{0}{1}{2}/{3}");
				}
			}
			else
			{
				this.TimeMsgStr.IntToFormat((long)((ulong)this.RemainRss + (ulong)this.ItemAddVal * (ulong)this.slider.Value), 1, true);
				this.TimeMsgStr.IntToFormat((long)((ulong)this.NeedRss), 1, true);
				if (GUIManager.Instance.IsArabic)
				{
					this.TimeMsgStr.AppendFormat("{1}/{0}");
				}
				else
				{
					this.TimeMsgStr.AppendFormat("{0}/{1}");
				}
			}
			this.TimeMsgText.text = this.TimeMsgStr.ToString();
			this.TimeMsgText.SetAllDirty();
			this.TimeMsgText.cachedTextGenerator.Invalidate();
			this.TimeMsgText.cachedTextGeneratorForLayout.Invalidate();
			Vector2 anchoredPosition = this.MsgIcon.rectTransform.anchoredPosition;
			anchoredPosition.x = -this.TimeMsgText.preferredWidth * 0.5f - this.MsgIcon.rectTransform.sizeDelta.x * 0.5f;
			this.MsgIcon.rectTransform.anchoredPosition = anchoredPosition;
		}
	}

	// Token: 0x06002B4D RID: 11085 RVA: 0x00479910 File Offset: 0x00477B10
	public void UpdateExp()
	{
		if (this.eType != EItemType.EIT_CaseByCase)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		Equip recordByKey = instance.EquipTable.GetRecordByKey(this.ItemID);
		switch ((byte)recordByKey.PropertiesInfo[0].Propertieskey)
		{
		case 30:
		{
			int num = (int)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue);
			this.MaxUseCount = 0u;
			if (instance.RoleAttr.MonsterPoint < instance.GetMaxMonsterPoint())
			{
				uint num2 = instance.GetMaxMonsterPoint() - instance.RoleAttr.MonsterPoint;
				this.MaxUseCount = (uint)((ulong)num2 / (ulong)((long)num) + (ulong)((long)Mathf.Clamp((int)(num2 % (uint)num), 1, 0)));
			}
			break;
		}
		case 33:
		{
			int num3 = (int)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue);
			long num4 = (long)num3 * this.slider.Value;
			this.MaxUseCount = 0u;
			this.saveRoleLv = instance.RoleAttr.Level;
			if (this.saveRoleLv < 60)
			{
				LevelUp recordByKey2 = instance.LevelUpTable.GetRecordByKey((ushort)this.saveRoleLv);
				this.OriginExpRatio = (ushort)(instance.RoleAttr.Exp * 100u / recordByKey2.KingdomExp);
				uint num5 = recordByKey2.KingdomExp;
				num5 -= instance.RoleAttr.Exp;
				while (num4 > 0L)
				{
					if (this.saveRoleLv == 60)
					{
						break;
					}
					if (num4 >= (long)((ulong)num5))
					{
						num4 -= (long)((ulong)num5);
						recordByKey2 = instance.LevelUpTable.GetRecordByKey((ushort)(this.saveRoleLv += 1));
						num5 = recordByKey2.KingdomExp;
					}
					else
					{
						num5 -= (uint)num4;
						num4 = 0L;
					}
				}
				if (num4 > 0L)
				{
					this.slider.Value -= num4 / (long)num3;
				}
				if (this.saveRoleLv < 60)
				{
					if (this.slider.Value > 0L)
					{
						this.RoleExpRatio = (byte)(100u - num5 * 100u / recordByKey2.KingdomExp - Mathf.Clamp(num5 * 100u % recordByKey2.KingdomExp, 0f, 1f));
					}
					else
					{
						this.RoleExpRatio = (byte)this.OriginExpRatio;
					}
				}
				else
				{
					this.RoleExpRatio = 0;
				}
			}
			else
			{
				this.slider.Value = 0L;
				this.RoleExpRatio = 0;
				this.OriginExpRatio = 0;
			}
			this.slider.m_slider.value = (double)this.slider.Value;
			break;
		}
		}
	}

	// Token: 0x06002B4E RID: 11086 RVA: 0x00479BD8 File Offset: 0x00477DD8
	private int GetMaxHerExpItems()
	{
		DataManager instance = DataManager.Instance;
		CurHeroData curHeroData = instance.curHeroData.Find((uint)this.UseTargetID);
		byte b = (byte)Mathf.Clamp((int)instance.RoleAttr.Level, 15, 60);
		LevelUp recordByKey = instance.LevelUpTable.GetRecordByKey((ushort)curHeroData.Level);
		if (curHeroData.Level == b && curHeroData.Exp == recordByKey.HeroExp - 1u)
		{
			return 0;
		}
		byte b2 = curHeroData.Level;
		uint num = recordByKey.HeroExp - curHeroData.Exp;
		while (b2 < b)
		{
			num += instance.LevelUpTable.GetRecordByKey((ushort)(b2 += 1)).HeroExp;
		}
		return (int)(num / this.ItemAddVal + (uint)Mathf.Clamp((int)(num % this.ItemAddVal), 0, 1));
	}

	// Token: 0x06002B4F RID: 11087 RVA: 0x00479CAC File Offset: 0x00477EAC
	private int GetMaxPetExpItems()
	{
		PetManager instance = PetManager.Instance;
		PetData petData = instance.FindPetData(this.UseTargetID);
		if (petData == null)
		{
			return 0;
		}
		byte maxLevel = petData.GetMaxLevel(true);
		if (petData.Level == 60)
		{
			return 0;
		}
		PetExpTbl recordByKey = instance.PetExpTable.GetRecordByKey((ushort)petData.Level);
		byte b = petData.Level;
		uint num = recordByKey.ExpValue[(int)this.petRare] - petData.Exp;
		while (b < maxLevel)
		{
			recordByKey = instance.PetExpTable.GetRecordByKey((ushort)(b += 1));
			if (b == 60)
			{
				break;
			}
			num += recordByKey.ExpValue[(int)this.petRare];
		}
		return (int)(num / this.ItemAddVal + (uint)Mathf.Clamp((int)(num % this.ItemAddVal), 0, 1));
	}

	// Token: 0x06002B50 RID: 11088 RVA: 0x00479D78 File Offset: 0x00477F78
	public void UpdateHeroExpText()
	{
		if (this.UseType != NumberConfirm._UseType.Hero)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		CurHeroData curHeroData = instance.curHeroData.Find((uint)this.UseTargetID);
		byte b = (byte)Mathf.Clamp((int)instance.RoleAttr.Level, 15, 60);
		LevelUp recordByKey = instance.LevelUpTable.GetRecordByKey((ushort)curHeroData.Level);
		uint num = (uint)((ulong)curHeroData.Exp + (ulong)this.ItemAddVal * (ulong)this.slider.Value);
		byte b2 = 0;
		if (num < recordByKey.HeroExp)
		{
			b2 = curHeroData.Level;
		}
		else
		{
			while (num >= recordByKey.HeroExp)
			{
				if (curHeroData.Level + b2 + 1 > b)
				{
					break;
				}
				b2 += 1;
				num -= recordByKey.HeroExp;
				byte b3 = curHeroData.Level + b2;
				recordByKey = instance.LevelUpTable.GetRecordByKey((ushort)b3);
				if (b3 >= b)
				{
					break;
				}
			}
			b2 += curHeroData.Level;
		}
		float num2 = num / recordByKey.HeroExp * 100f;
		if (b2 == b && num2 > 100f)
		{
			this.TipText.text = instance.mStringTable.GetStringByID(533u);
			this.TipText.color = new Color(1f, 0.29f, 0.459f);
			long num3 = 1L;
			float num5;
			float num6;
			long num7;
			for (float num4 = num2; num4 >= 100f; num4 = (num5 - (float)((long)num6 * num7)) / (recordByKey.HeroExp - 1f) * 100f)
			{
				num2 = num4;
				num5 = num;
				num6 = (float)((ulong)this.ItemAddVal);
				num7 = num3;
				num3 = num7 + 1L;
			}
			this.slider.Value = this.slider.Value - num3 + 2L;
			num2 = Mathf.Clamp(num2, 0f, 99.999f);
			this.MaxUseCount = (uint)this.slider.Value;
			this.slider.m_slider.value = (double)this.slider.Value;
		}
		else if (this.slider.Value != (long)((ulong)this.MaxUseCount))
		{
			this.TipText.text = instance.mStringTable.GetStringByID(283u);
			this.TipText.color = new Color(1f, 1f, 1f);
		}
		else
		{
			this.TipText.text = instance.mStringTable.GetStringByID(533u);
			this.TipText.color = new Color(1f, 0.29f, 0.459f);
		}
		if (recordByKey.HeroExp - num == 1u && b == curHeroData.Level)
		{
			num2 = 99f;
		}
		this.TimeStr.ClearString();
		this.TimeStr.IntToFormat((long)curHeroData.Level, 1, false);
		this.TimeStr.IntToFormat((long)this.OriginExpRatio, 1, false);
		this.TimeStr.IntToFormat((long)b2, 1, false);
		this.TimeStr.IntToFormat((long)((int)num2), 1, false);
		this.TimeStr.AppendFormat(instance.mStringTable.GetStringByID(531u));
		this.ExpChange.text = this.TimeStr.ToString();
		this.ExpChange.SetAllDirty();
		this.ExpChange.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06002B51 RID: 11089 RVA: 0x0047A0FC File Offset: 0x004782FC
	public void UpdatePetExpText()
	{
		if (this.UseType != NumberConfirm._UseType.PetExp)
		{
			return;
		}
		PetManager instance = PetManager.Instance;
		DataManager instance2 = DataManager.Instance;
		PetData petData = instance.FindPetData(this.UseTargetID);
		if (petData == null)
		{
			return;
		}
		byte maxLevel = petData.GetMaxLevel(true);
		PetExpTbl recordByKey = instance.PetExpTable.GetRecordByKey((ushort)petData.Level);
		uint num = (uint)((ulong)petData.Exp + (ulong)this.ItemAddVal * (ulong)this.slider.Value);
		byte b = 0;
		if (num < recordByKey.ExpValue[(int)this.petRare])
		{
			b = petData.Level;
		}
		else
		{
			while (num >= recordByKey.ExpValue[(int)this.petRare])
			{
				if (petData.Level + b + 1 > maxLevel)
				{
					break;
				}
				b += 1;
				num -= recordByKey.ExpValue[(int)this.petRare];
				byte b2 = petData.Level + b;
				recordByKey = instance.PetExpTable.GetRecordByKey((ushort)b2);
				if (b2 >= maxLevel)
				{
					break;
				}
			}
			b += petData.Level;
		}
		float num2 = num / recordByKey.ExpValue[(int)this.petRare] * 100f;
		if (petData.Level == 60)
		{
			this.slider.Value = 0L;
			this.MaxUseCount = 0u;
		}
		if (b == 60)
		{
			this.TipText.text = instance2.mStringTable.GetStringByID(16041u);
			this.TipText.color = new Color(1f, 0.29f, 0.459f);
			num2 = 0f;
		}
		else if (b == maxLevel && num2 >= 100f)
		{
			if ((b == 20 && petData.Enhance == 0) || (b == 50 && petData.Enhance == 1))
			{
				this.TipText.text = instance2.mStringTable.GetStringByID(17099u);
			}
			else
			{
				this.TipText.text = instance2.mStringTable.GetStringByID(17140u);
			}
			this.TipText.color = new Color(1f, 0.29f, 0.459f);
			long num3 = 1L;
			float num5;
			float num6;
			long num7;
			for (float num4 = num2; num4 >= 100f; num4 = (num5 - (float)((long)num6 * num7)) / (recordByKey.ExpValue[(int)this.petRare] - 1f) * 100f)
			{
				num2 = num4;
				num5 = num;
				num6 = (float)((ulong)this.ItemAddVal);
				num7 = num3;
				num3 = num7 + 1L;
			}
			this.slider.Value = this.slider.Value - num3 + 2L;
			num2 = Mathf.Clamp(num2, 0f, 99.999f);
			this.MaxUseCount = (uint)this.slider.Value;
			this.slider.m_slider.value = (double)this.slider.Value;
		}
		else if (this.slider.Value != (long)((ulong)this.MaxUseCount))
		{
			this.TipText.text = instance2.mStringTable.GetStringByID(283u);
			this.TipText.color = new Color(1f, 1f, 1f);
		}
		if (recordByKey.ExpValue[(int)this.petRare] - num == 1u && maxLevel == petData.Level)
		{
			num2 = 99f;
		}
		this.TimeStr.ClearString();
		this.TimeStr.IntToFormat((long)petData.Level, 1, false);
		this.TimeStr.IntToFormat((long)this.OriginExpRatio, 1, false);
		this.TimeStr.IntToFormat((long)b, 1, false);
		this.TimeStr.IntToFormat((long)((int)num2), 1, false);
		this.TimeStr.AppendFormat(instance2.mStringTable.GetStringByID(531u));
		this.ExpChange.text = this.TimeStr.ToString();
		this.ExpChange.SetAllDirty();
		this.ExpChange.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06002B52 RID: 11090 RVA: 0x0047A518 File Offset: 0x00478718
	public void UpdateVip()
	{
		if (this.eType != EItemType.EIT_VIP)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		Equip recordByKey = instance.EquipTable.GetRecordByKey(this.ItemID);
		this.saveRoleLv = instance.RoleAttr.VIPLevel;
		uint vippoint = instance.VIPLevelTable.GetRecordByKey((ushort)(this.saveRoleLv -= 1)).VIPPoint;
		VIP_DataTbl recordByKey2 = instance.VIPLevelTable.GetRecordByKey((ushort)(this.saveRoleLv += 1));
		if (instance.RoleAttr.VIPLevel < instance.RoleAttr.VIPLevelMax)
		{
			this.OriginExpRatio = (ushort)((instance.RoleAttr.VipPoint - vippoint) * 100u / (recordByKey2.VIPPoint - vippoint));
		}
		else
		{
			this.OriginExpRatio = 0;
		}
		this.RoleExpRatio = (byte)this.OriginExpRatio;
		int propertieskey = (int)recordByKey.PropertiesInfo[1].Propertieskey;
		if (instance.RoleAttr.VIPLevel < instance.RoleAttr.VIPLevelMax)
		{
			while ((ulong)instance.RoleAttr.VipPoint + (ulong)(this.slider.Value * (long)propertieskey) >= (ulong)recordByKey2.VIPPoint)
			{
				vippoint = recordByKey2.VIPPoint;
				recordByKey2 = instance.VIPLevelTable.GetRecordByKey((ushort)(this.saveRoleLv += 1));
				if (this.saveRoleLv >= instance.RoleAttr.VIPLevelMax)
				{
					IL_1AA:
					if (this.saveRoleLv == instance.RoleAttr.VIPLevelMax)
					{
						this.RoleExpRatio = 0;
						this.MaxUseCount = (uint)((ulong)(recordByKey2.VIPPoint - instance.RoleAttr.VipPoint) / (ulong)((long)propertieskey) + (ulong)((long)Mathf.Clamp((int)((recordByKey2.VIPPoint - instance.RoleAttr.VipPoint) % (uint)propertieskey), 0, 1)));
						if ((ulong)this.MaxUseCount < (ulong)this.slider.Value)
						{
							this.slider.Value = (long)((ulong)this.MaxUseCount);
						}
					}
					goto IL_240;
				}
			}
			this.RoleExpRatio = (byte)(((ulong)instance.RoleAttr.VipPoint + (ulong)(this.slider.Value * (long)propertieskey) - (ulong)vippoint) * 100UL / (ulong)(recordByKey2.VIPPoint - vippoint));
			goto IL_1AA;
		}
		this.slider.Value = 0L;
		IL_240:
		this.slider.m_slider.value = (double)this.slider.Value;
	}

	// Token: 0x04007760 RID: 30560
	private ushort ItemID;

	// Token: 0x04007761 RID: 30561
	private EItemType eType;

	// Token: 0x04007762 RID: 30562
	private UnitResourcesSlider slider;

	// Token: 0x04007763 RID: 30563
	private UISpritesArray SpriteArray;

	// Token: 0x04007764 RID: 30564
	private UIText MaxQtyStr;

	// Token: 0x04007765 RID: 30565
	private UIText TipText;

	// Token: 0x04007766 RID: 30566
	private UIText ExpChange;

	// Token: 0x04007767 RID: 30567
	private UIText TitleText;

	// Token: 0x04007768 RID: 30568
	private UIText TimeMsgText;

	// Token: 0x04007769 RID: 30569
	private UIText ItemNameText;

	// Token: 0x0400776A RID: 30570
	private RectTransform TipImageRect;

	// Token: 0x0400776B RID: 30571
	private RectTransform InputRect;

	// Token: 0x0400776C RID: 30572
	private RectTransform SlashRect;

	// Token: 0x0400776D RID: 30573
	private CSlider AutouseSlider;

	// Token: 0x0400776E RID: 30574
	private CString QtyStr;

	// Token: 0x0400776F RID: 30575
	private CString TimeStr;

	// Token: 0x04007770 RID: 30576
	private CString NameTitle;

	// Token: 0x04007771 RID: 30577
	private CString ItemNameStr;

	// Token: 0x04007772 RID: 30578
	private CString Cstr;

	// Token: 0x04007773 RID: 30579
	private CString TimeMsgStr;

	// Token: 0x04007774 RID: 30580
	private CString TipStr;

	// Token: 0x04007775 RID: 30581
	private byte QuequIndex;

	// Token: 0x04007776 RID: 30582
	private byte saveRoleLv;

	// Token: 0x04007777 RID: 30583
	private byte RoleExpRatio;

	// Token: 0x04007778 RID: 30584
	private byte bFreeSpeedup;

	// Token: 0x04007779 RID: 30585
	private byte petRare;

	// Token: 0x0400777A RID: 30586
	private UIButtonHint InfoHint;

	// Token: 0x0400777B RID: 30587
	private GameObject InfoImgObj;

	// Token: 0x0400777C RID: 30588
	private CanvasGroup InfoCanvasGroup;

	// Token: 0x0400777D RID: 30589
	private float DeltaTime;

	// Token: 0x0400777E RID: 30590
	private NumberConfirm._UseType UseType;

	// Token: 0x0400777F RID: 30591
	private ushort OriginExpRatio;

	// Token: 0x04007780 RID: 30592
	private uint MaxUseCount = 65535u;

	// Token: 0x04007781 RID: 30593
	private uint ItemAddVal;

	// Token: 0x04007782 RID: 30594
	private Color TimeMsgColor;

	// Token: 0x04007783 RID: 30595
	private RectTransform BackgroundRect;

	// Token: 0x04007784 RID: 30596
	private RectTransform LineImageRect;

	// Token: 0x04007785 RID: 30597
	private RectTransform ItemRect;

	// Token: 0x04007786 RID: 30598
	private RectTransform OkRect;

	// Token: 0x04007787 RID: 30599
	private RectTransform CancelRect;

	// Token: 0x04007788 RID: 30600
	private float SliderTop = -287.2f;

	// Token: 0x04007789 RID: 30601
	private float SliderInputTop = -237.6f;

	// Token: 0x0400778A RID: 30602
	private uint RemainRss;

	// Token: 0x0400778B RID: 30603
	private uint NeedRss;

	// Token: 0x0400778C RID: 30604
	private Image MsgIcon;

	// Token: 0x0400778D RID: 30605
	private Image TipImage;

	// Token: 0x0400778E RID: 30606
	private ResourceType NeedResourceType;

	// Token: 0x02000824 RID: 2084
	private enum UIControl : byte
	{
		// Token: 0x04007790 RID: 30608
		MaskImage,
		// Token: 0x04007791 RID: 30609
		Background,
		// Token: 0x04007792 RID: 30610
		Title,
		// Token: 0x04007793 RID: 30611
		Hero,
		// Token: 0x04007794 RID: 30612
		HiBtn,
		// Token: 0x04007795 RID: 30613
		Slider,
		// Token: 0x04007796 RID: 30614
		MaxQty,
		// Token: 0x04007797 RID: 30615
		ArabicRot,
		// Token: 0x04007798 RID: 30616
		Tip,
		// Token: 0x04007799 RID: 30617
		Confirm,
		// Token: 0x0400779A RID: 30618
		Cancel,
		// Token: 0x0400779B RID: 30619
		SpriteArray
	}

	// Token: 0x02000825 RID: 2085
	private enum UISliderControl
	{
		// Token: 0x0400779D RID: 30621
		Increase,
		// Token: 0x0400779E RID: 30622
		Decrease,
		// Token: 0x0400779F RID: 30623
		Slider,
		// Token: 0x040077A0 RID: 30624
		Input
	}

	// Token: 0x02000826 RID: 2086
	private enum ClickType
	{
		// Token: 0x040077A2 RID: 30626
		Confirm,
		// Token: 0x040077A3 RID: 30627
		Cancel,
		// Token: 0x040077A4 RID: 30628
		InputText
	}

	// Token: 0x02000827 RID: 2087
	private enum _UseType
	{
		// Token: 0x040077A6 RID: 30630
		Normal,
		// Token: 0x040077A7 RID: 30631
		Hero,
		// Token: 0x040077A8 RID: 30632
		Pet,
		// Token: 0x040077A9 RID: 30633
		PetExp = 4
	}
}
