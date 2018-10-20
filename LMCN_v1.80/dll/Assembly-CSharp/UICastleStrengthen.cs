using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200051F RID: 1311
public class UICastleStrengthen : UICastleSkinWindow, UILoadImageHander, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUIUnitRSliderHandler
{
	// Token: 0x06001A26 RID: 6694 RVA: 0x002C4750 File Offset: 0x002C2950
	public override void OnOpen(int arg1, int arg2)
	{
		base.OnOpen(arg1, arg2);
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		Material material = this.door.LoadMaterial();
		this.mItemQty = this.DM.GetCurItemQuantity(1326, 1);
		this.MainTitle.text = this.DM.mStringTable.GetStringByID(14561u);
		this.Cstr = StringManager.Instance.SpawnString(1024);
		this.Cstr_Item = StringManager.Instance.SpawnString(100);
		this.Cstr_CheckInfo = StringManager.Instance.SpawnString(200);
		for (int i = 0; i < 2; i++)
		{
			this.Cstr_Value[i] = StringManager.Instance.SpawnString(30);
			this.Cstr_ShowEffect[i] = StringManager.Instance.SpawnString(100);
		}
		for (int j = 0; j < 3; j++)
		{
			this.Cstr_Silder[j] = StringManager.Instance.SpawnString(100);
		}
		this.GameT = base.gameObject.transform;
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.Tmp1 = this.GameT.GetChild(0);
		for (int k = 0; k < 5; k++)
		{
			this.Tmp2 = this.Tmp1.GetChild(k);
			this.Img_Strengthen[k] = this.Tmp2.GetComponent<Image>();
		}
		this.Tmp2 = this.Tmp1.GetChild(5);
		this.Img_CastleHint[0] = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(5).GetChild(0);
		this.Img_CastleHint[1] = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tmp1.GetChild(6);
		this.btn_CastleHint = this.Tmp2.GetComponent<UIButton>();
		this.btn_CastleHint.m_Handler = this;
		this.btn_CastleHint.m_BtnID1 = 1;
		UIButtonHint uibuttonHint = this.Tmp2.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.m_ForcePos = true;
		uibuttonHint.m_HIBtnOffset = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f - 222f, -(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f) + 110f);
		uibuttonHint.ControlFadeOut = this.Hint.ThisTransform.gameObject;
		this.Tmp2 = this.Tmp1.GetChild(7).GetChild(0);
		this.Img_CastleBG = this.Tmp2.GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_CastleBG.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.Tmp2 = this.Tmp1.GetChild(7).GetChild(1);
		this.Img_SkinUse = this.Tmp2.GetComponent<Image>();
		for (int l = 0; l < 2; l++)
		{
			this.Tmp2 = this.Tmp1.GetChild(7).GetChild(2 + l);
			this.text_Effect[l] = this.Tmp2.GetComponent<UIText>();
			this.text_Effect[l].font = this.TTFont;
			this.Tmp2 = this.Tmp1.GetChild(7).GetChild(4 + l);
			this.text_Value[l] = this.Tmp2.GetComponent<UIText>();
			this.text_Value[l].font = this.TTFont;
		}
		this.Tmp2 = this.Tmp1.GetChild(8);
		this.text_Name = this.Tmp2.GetComponent<UIText>();
		this.text_Name.font = this.TTFont;
		this.text_Name.alignment = TextAnchor.MiddleLeft;
		this.text_Name.resizeTextForBestFit = true;
		this.text_Name.resizeTextMaxSize = 26;
		for (int m = 0; m < 2; m++)
		{
			this.Tmp2 = this.Tmp1.GetChild(9 + m);
			this.text_ShowEffect[m] = this.Tmp2.GetComponent<UIText>();
			this.text_ShowEffect[m].font = this.TTFont;
			this.text_ShowEffect[m].fontSize = 20;
			this.text_ShowEffect[m].alignment = TextAnchor.MiddleCenter;
		}
		this.SetCastleData(true, false);
		this.Tmp1 = this.GameT.GetChild(1);
		this.Tf1 = this.Tmp1.GetChild(0);
		this.Tmp2 = this.Tf1.GetChild(0);
		this.btn_Strengthen = this.Tmp2.GetComponent<UIButton>();
		this.btn_Strengthen.m_Handler = this;
		this.btn_Strengthen.m_BtnID1 = 2;
		this.btn_Strengthen.m_EffectType = e_EffectType.e_Scale;
		this.btn_Strengthen.transition = Selectable.Transition.None;
		this.Tmp2 = this.Tf1.GetChild(0).GetChild(0);
		this.text_Strengthen = this.Tmp2.GetComponent<UIText>();
		this.text_Strengthen.font = this.TTFont;
		this.text_Strengthen.text = this.DM.mStringTable.GetStringByID(14563u);
		this.btn_Strengthen.m_Text = this.text_Strengthen;
		this.Tmp2 = this.Tf1.GetChild(1);
		this.m_UnitRS = this.Tmp2.GetComponent<UnitResourcesSlider>();
		this.mMaxValue = 100u;
		if ((uint)this.mItemMax < this.mMaxValue)
		{
			this.bItemQty = true;
			this.mMaxValue = (uint)this.mItemMax;
		}
		else
		{
			this.bItemQty = false;
			this.mMaxValue = 100u;
		}
		this.GUIM.InitUnitResourcesSlider(this.Tmp2, eUnitSlider.CastleStrengthen, 0u, this.mMaxValue, 1f);
		this.m_UnitRS.m_Handler = this;
		this.m_UnitRS.m_ID = 1;
		this.GUIM.SetUnitResourcesSliderSize(this.Tmp2, eUnitSliderSize.BtnLessen, -173f, -20f, 70f, 60f, 0f, 0f);
		this.Tmp2 = this.Tf1.GetChild(2);
		this.text_ItemQty = this.Tmp2.GetComponent<UIText>();
		this.text_ItemQty.font = this.TTFont;
		this.text_ItemQty.text = this.DM.mStringTable.GetStringByID(283u);
		for (int n = 0; n < 2; n++)
		{
			this.Tmp2 = this.Tf1.GetChild(3 + n);
			this.text_Slider[n] = this.Tmp2.GetComponent<UIText>();
			this.text_Slider[n].font = this.TTFont;
		}
		this.Cstr_Silder[0].ClearString();
		this.Cstr_Silder[0].IntToFormat(0L, 1, true);
		this.Cstr_Silder[0].IntToFormat((long)this.mItemMax, 1, true);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_Silder[0].AppendFormat("{1} / {0}");
		}
		else
		{
			this.Cstr_Silder[0].AppendFormat("{0} / {1}");
		}
		this.text_Slider[0].text = this.Cstr_Silder[0].ToString();
		this.text_Slider[0].SetAllDirty();
		this.text_Slider[0].cachedTextGenerator.Invalidate();
		this.Cstr_Silder[1].ClearString();
		this.Cstr_Silder[2].ClearString();
		this.Cstr_Silder[1].IntToFormat(0L, 1, true);
		this.Cstr_Silder[1].AppendFormat("{0}%");
		this.Cstr_Silder[2].StringToFormat(this.Cstr_Silder[1]);
		this.Cstr_Silder[2].AppendFormat(this.DM.mStringTable.GetStringByID(14569u));
		this.text_Slider[1].text = this.Cstr_Silder[2].ToString();
		this.text_Slider[1].SetAllDirty();
		this.text_Slider[1].cachedTextGenerator.Invalidate();
		this.Tf2 = this.Tmp1.GetChild(1);
		this.Tmp2 = this.Tf2.GetChild(0);
		this.Img_CastleMax = this.Tmp2.GetComponent<Image>();
		this.Tmp2 = this.Tf2.GetChild(3);
		this.text_CastleMaxRank = this.Tmp2.GetComponent<UIText>();
		this.text_CastleMaxRank.font = this.TTFont;
		this.text_CastleMaxRank.text = this.DM.mStringTable.GetStringByID(3943u);
		this.Tmp2 = this.Tmp1.GetChild(2).GetChild(0);
		this.Img_BtnLock = this.Tmp2.GetComponent<Image>();
		this.Img_BtnLock.gameObject.SetActive(false);
		this.Tmp2 = this.Tmp1.GetChild(3);
		this.btn_Item = this.Tmp2.GetComponent<UIHIBtn>();
		this.GUIM.InitianHeroItemImg(this.btn_Item.transform, eHeroOrItem.Item, 1326, 0, 0, 0, true, true, true, false);
		for (int num = 0; num < 2; num++)
		{
			this.Tmp2 = this.Tmp1.GetChild(4 + num);
			this.text_Item[num] = this.Tmp2.GetComponent<UIText>();
			this.text_Item[num].font = this.TTFont;
		}
		this.tmpEquip = this.DM.EquipTable.GetRecordByKey(1326);
		this.text_Item[0].text = this.DM.mStringTable.GetStringByID((uint)this.tmpEquip.EquipName);
		this.Cstr_Item.ClearString();
		this.Cstr_Item.IntToFormat((long)this.mItemQty, 1, true);
		this.Cstr_Item.AppendFormat(this.DM.mStringTable.GetStringByID(79u));
		this.text_Item[1].text = this.Cstr_Item.ToString();
		this.text_Item[1].SetAllDirty();
		this.text_Item[1].cachedTextGenerator.Invalidate();
		this.CheckCastleRank();
		this.Tf_Checkbox = this.GameT.GetChild(2);
		this.Tf_Checkbox.GetComponent<CustomImage>().hander = this;
		this.Tf_Checkbox.GetChild(0).GetComponent<CustomImage>().hander = this;
		this.Tf_Checkbox.GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.Tf_Checkbox.GetChild(0).GetChild(1).GetComponent<CustomImage>().hander = this;
		this.Tmp1 = this.Tf_Checkbox.GetChild(0);
		this.Tmp2 = this.Tmp1.GetChild(2);
		this.text_Check_title = this.Tmp2.GetComponent<UIText>();
		this.text_Check_title.font = this.TTFont;
		this.text_Check_title.text = this.DM.mStringTable.GetStringByID(614u);
		this.Tmp2 = this.Tmp1.GetChild(3);
		this.text_Check_Info = this.Tmp2.GetComponent<UIText>();
		this.text_Check_Info.font = this.TTFont;
		this.Cstr_CheckInfo.ClearString();
		this.Cstr_CheckInfo.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpEquip.EquipName));
		this.Cstr_CheckInfo.IntToFormat((long)this.mNeedItemQty, 1, true);
		this.Cstr_CheckInfo.AppendFormat(this.DM.mStringTable.GetStringByID(14566u));
		this.text_Check_Info.text = this.Cstr_CheckInfo.ToString();
		this.text_Check_Info.cachedTextGeneratorForLayout.Invalidate();
		float num2 = this.text_Check_Info.preferredHeight - 86.8f;
		if (num2 > 1f)
		{
			this.Tf_Checkbox.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, num2);
			this.Tf_Checkbox.GetChild(0).GetComponent<RectTransform>().sizeDelta += new Vector2(0f, num2);
			this.text_Check_Info.rectTransform.sizeDelta += new Vector2(0f, num2);
		}
		this.Tmp2 = this.Tmp1.GetChild(4);
		this.Tmp2.GetComponent<CustomImage>().hander = this;
		this.btn_Check_Ok = this.Tmp2.GetComponent<UIButton>();
		this.btn_Check_Ok.m_Handler = this;
		this.btn_Check_Ok.m_BtnID1 = 4;
		this.btn_Check_Ok.m_EffectType = e_EffectType.e_Scale;
		this.btn_Check_Ok.transition = Selectable.Transition.None;
		this.Tmp2 = this.Tmp1.GetChild(4).GetChild(0);
		this.text_Check_btn_Ok = this.Tmp2.GetComponent<UIText>();
		this.text_Check_btn_Ok.font = this.TTFont;
		this.text_Check_btn_Ok.text = this.DM.mStringTable.GetStringByID(189u);
		this.Tmp2 = this.Tmp1.GetChild(5);
		this.Tmp2.GetComponent<CustomImage>().hander = this;
		this.btn_Check_Cancal = this.Tmp2.GetComponent<UIButton>();
		this.btn_Check_Cancal.m_Handler = this;
		this.btn_Check_Cancal.m_BtnID1 = 5;
		this.btn_Check_Cancal.m_EffectType = e_EffectType.e_Scale;
		this.btn_Check_Cancal.transition = Selectable.Transition.None;
		this.Tmp2 = this.Tmp1.GetChild(5).GetChild(0);
		this.text_Check_btn_Cancel = this.Tmp2.GetComponent<UIText>();
		this.text_Check_btn_Cancel.font = this.TTFont;
		this.text_Check_btn_Cancel.text = this.DM.mStringTable.GetStringByID(188u);
		this.Tmp2 = this.Tmp1.GetChild(6);
		this.Tmp2.GetComponent<CustomImage>().hander = this;
		UIButton component = this.Tmp2.GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 5;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		this.Tmp2 = this.Tmp1.GetChild(7);
		this.Tmp2.GetComponent<CustomImage>().hander = this;
		this.btn_Check = this.Tmp2.GetComponent<UIButton>();
		this.btn_Check.m_Handler = this;
		this.btn_Check.m_BtnID1 = 3;
		this.btn_Check.m_EffectType = e_EffectType.e_Scale;
		this.btn_Check.transition = Selectable.Transition.None;
		this.Tmp2 = this.Tmp1.GetChild(8);
		this.Tmp2.GetComponent<CustomImage>().hander = this;
		this.Tmp2 = this.Tmp1.GetChild(9);
		this.CImg_Check = this.Tmp2.GetComponent<CustomImage>();
		this.CImg_Check.hander = this;
		if (this.GUIM.IsArabic)
		{
			this.CImg_Check.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.Tmp2 = this.Tmp1.GetChild(10);
		this.text_Check = this.Tmp2.GetComponent<UIText>();
		this.text_Check.font = this.TTFont;
		this.text_Check.text = this.DM.mStringTable.GetStringByID(967u);
		this.Tf_Checkbox.SetParent(this.GUIM.m_SecWindowLayer, false);
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001A27 RID: 6695 RVA: 0x002C5714 File Offset: 0x002C3914
	public override void Initial()
	{
		this.ListSortType = CastleSkin._SortType.Own;
		base.Initial();
	}

	// Token: 0x06001A28 RID: 6696 RVA: 0x002C5724 File Offset: 0x002C3924
	public void SetCastleData(bool bOpen = true, bool bZero = false)
	{
		if ((ushort)this.GUIM.BuildingData.CastleID == this.SelectedCastleID)
		{
			this.Img_SkinUse.gameObject.SetActive(true);
		}
		else
		{
			this.Img_SkinUse.gameObject.SetActive(false);
		}
		this.tmpCa = this.GUIM.BuildingData.castleSkin.CastleSkinTable.GetRecordByKey(this.SelectedCastleID);
		this.tmpCaE = this.GUIM.BuildingData.castleSkin.GetCastleEnhance((byte)this.tmpCa.ID);
		this.Img_CastleBG.sprite = this.GUIM.BuildingData.castleSkin.GetUISprite(this.tmpCa.Graphic, this.GUIM.BuildingData.GetBuildData(8, 0).Level);
		this.Img_CastleBG.material = this.GUIM.BuildingData.castleSkin.GetUIMaterial(this.tmpCa.Graphic, this.GUIM.BuildingData.GetBuildData(8, 0).Level);
		this.Img_CastleBG.SetNativeSize();
		this.Img_CastleBG.rectTransform.localScale = new Vector3((float)this.tmpCa.EnhancePercentage / 100f, (float)this.tmpCa.EnhancePercentage / 100f, (float)this.tmpCa.EnhancePercentage / 100f);
		this.SetChangCastleRank((int)this.tmpCaE);
		this.text_Name.text = this.DM.mStringTable.GetStringByID((uint)this.tmpCa.Name);
		this.text_Name.cachedTextGeneratorForLayout.Invalidate();
		float num = this.text_Name.preferredWidth;
		if (num > 280f)
		{
			num = 280f;
		}
		this.text_Name.rectTransform.sizeDelta = new Vector2(num + 1f, this.text_Name.rectTransform.sizeDelta.y);
		RectTransform component = this.btn_CastleHint.GetComponent<RectTransform>();
		if (num + 68f > 183f)
		{
			component.sizeDelta = new Vector2(250f + (num + 1f - 183f) + this.Img_CastleHint[0].rectTransform.sizeDelta.x, component.sizeDelta.y);
		}
		else
		{
			component.sizeDelta = new Vector2(250f, component.sizeDelta.y);
		}
		this.Img_CastleHint[0].rectTransform.anchoredPosition = new Vector2(-215f - num / 2f - this.Img_CastleHint[0].rectTransform.sizeDelta.x / 2f, this.Img_CastleHint[0].rectTransform.anchoredPosition.y);
		this.text_Effect[0].text = this.DM.mStringTable.GetStringByID((uint)this.DM.EffectData.GetRecordByKey(this.tmpCa.Effect[0]).InfoID);
		this.text_Effect[1].text = this.DM.mStringTable.GetStringByID((uint)this.DM.EffectData.GetRecordByKey(this.tmpCa.Effect[1]).InfoID);
		this.UpdataCastle(bOpen, bZero);
	}

	// Token: 0x06001A29 RID: 6697 RVA: 0x002C5AB0 File Offset: 0x002C3CB0
	public void UpdataCastle(bool bOpen = true, bool bZero = false)
	{
		this.Cstr_Value[0].ClearString();
		this.Cstr_Value[1].ClearString();
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring2.ClearString();
		this.mItemMax = 0;
		this.tmpCaE = this.GUIM.BuildingData.castleSkin.GetCastleEnhance((byte)this.tmpCa.ID);
		this.tmpCaED = this.GUIM.BuildingData.castleSkin.GetCastleEnhanceData((byte)this.tmpCa.ID, this.tmpCaE);
		if (this.tmpCaE < 5)
		{
			CastleEnhanceTbl castleEnhanceData = this.GUIM.BuildingData.castleSkin.GetCastleEnhanceData((byte)this.tmpCa.ID, this.tmpCaE + 1);
			this.mItemMax = castleEnhanceData.EnhanceTotalNum;
			GameConstants.GetEffectValue(cstring, this.tmpCa.Effect[0], (uint)this.tmpCaED.Value[0], 12, 0f);
			GameConstants.GetEffectValue(cstring2, this.tmpCa.Effect[0], (uint)castleEnhanceData.Value[0], 12, 0f);
			this.Cstr_Value[0].StringToFormat(cstring);
			this.Cstr_Value[0].StringToFormat(cstring2);
			this.Cstr_Value[0].AppendFormat(this.DM.mStringTable.GetStringByID(14574u));
			cstring.ClearString();
			cstring2.ClearString();
			GameConstants.GetEffectValue(cstring, this.tmpCa.Effect[1], (uint)this.tmpCaED.Value[1], 12, 0f);
			GameConstants.GetEffectValue(cstring2, this.tmpCa.Effect[1], (uint)castleEnhanceData.Value[1], 12, 0f);
			this.Cstr_Value[1].StringToFormat(cstring);
			this.Cstr_Value[1].StringToFormat(cstring2);
			this.Cstr_Value[1].AppendFormat(this.DM.mStringTable.GetStringByID(14574u));
		}
		else
		{
			GameConstants.GetEffectValue(this.Cstr_Value[0], this.tmpCa.Effect[0], (uint)this.tmpCaED.Value[0], 12, 0f);
			GameConstants.GetEffectValue(this.Cstr_Value[1], this.tmpCa.Effect[1], (uint)this.tmpCaED.Value[1], 12, 0f);
		}
		this.text_Value[0].text = this.Cstr_Value[0].ToString();
		this.text_Value[0].SetAllDirty();
		this.text_Value[0].cachedTextGenerator.Invalidate();
		this.text_Value[1].text = this.Cstr_Value[1].ToString();
		this.text_Value[1].SetAllDirty();
		this.text_Value[1].cachedTextGenerator.Invalidate();
		if (!bOpen)
		{
			if (bZero)
			{
				this.mNeedItemQty = 0;
			}
			this.mMaxValue = 100u;
			if ((uint)this.mItemMax < this.mMaxValue)
			{
				this.bItemQty = true;
				this.mMaxValue = (uint)this.mItemMax;
			}
			else
			{
				this.bItemQty = false;
				this.mMaxValue = 100u;
			}
			this.m_UnitRS.m_slider.value = (double)this.mNeedItemQty;
			this.m_UnitRS.MaxValue = (long)((ulong)this.mMaxValue);
			this.m_UnitRS.m_slider.maxValue = this.mMaxValue;
			this.Cstr_Silder[0].ClearString();
			this.Cstr_Silder[0].IntToFormat((long)this.mNeedItemQty, 1, true);
			this.Cstr_Silder[0].IntToFormat((long)this.mItemMax, 1, true);
			if (this.mNeedItemQty == 0)
			{
				if (this.GUIM.IsArabic)
				{
					this.Cstr_Silder[0].AppendFormat("{1} / {0}");
				}
				else
				{
					this.Cstr_Silder[0].AppendFormat("{0} / {1}");
				}
			}
			else if (this.GUIM.IsArabic)
			{
				this.Cstr_Silder[0].AppendFormat("{1} / <color=#00FF00>{0}</color>");
			}
			else
			{
				this.Cstr_Silder[0].AppendFormat("<color=#00FF00>{0}</color> / {1}");
			}
			this.text_Slider[0].text = this.Cstr_Silder[0].ToString();
			this.text_Slider[0].SetAllDirty();
			this.text_Slider[0].cachedTextGenerator.Invalidate();
			this.Cstr_Silder[1].ClearString();
			this.Cstr_Silder[2].ClearString();
			this.Cstr_Silder[1].IntToFormat((long)this.mStrengthenrate, 1, true);
			this.Cstr_Silder[1].AppendFormat("{0}%");
			this.Cstr_Silder[2].StringToFormat(this.Cstr_Silder[1]);
			this.Cstr_Silder[2].AppendFormat(this.DM.mStringTable.GetStringByID(14569u));
			this.text_Slider[1].text = this.Cstr_Silder[2].ToString();
			this.text_Slider[1].SetAllDirty();
			this.text_Slider[1].cachedTextGenerator.Invalidate();
			this.CheckCastleRank();
		}
	}

	// Token: 0x06001A2A RID: 6698 RVA: 0x002C5FD0 File Offset: 0x002C41D0
	public void CheckCastleRank()
	{
		if (this.tmpCaE < 5)
		{
			this.Tf1.gameObject.SetActive(true);
			this.Tf2.gameObject.SetActive(false);
		}
		else
		{
			this.Tf1.gameObject.SetActive(false);
			this.Tf2.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001A2B RID: 6699 RVA: 0x002C6034 File Offset: 0x002C4234
	public void SetChangCastleRank(int mRank)
	{
		for (int i = 0; i < mRank; i++)
		{
			this.Img_Strengthen[i].sprite = this.SArray.m_Sprites[0];
		}
		for (int j = mRank; j < 5; j++)
		{
			this.Img_Strengthen[j].sprite = this.SArray.m_Sprites[1];
		}
	}

	// Token: 0x06001A2C RID: 6700 RVA: 0x002C609C File Offset: 0x002C429C
	public void AddShowEffect()
	{
		if (this.mSpeciallyEffect == 1)
		{
			this.Cstr_ShowEffect[0].ClearString();
			this.Cstr_ShowEffect[1].ClearString();
			this.tmpCaE = this.GUIM.BuildingData.castleSkin.GetCastleEnhance((byte)this.tmpCa.ID);
			this.tmpCaED = this.GUIM.BuildingData.castleSkin.GetCastleEnhanceData((byte)this.tmpCa.ID, this.tmpCaE);
			CastleEnhanceTbl castleEnhanceData = this.GUIM.BuildingData.castleSkin.GetCastleEnhanceData((byte)this.tmpCa.ID, this.tmpCaE - 1);
			GameConstants.GetEffectValue(this.Cstr_ShowEffect[0], this.tmpCa.Effect[0], (uint)(this.tmpCaED.Value[0] - castleEnhanceData.Value[0]), 13, 0f);
			GameConstants.GetEffectValue(this.Cstr_ShowEffect[1], this.tmpCa.Effect[1], (uint)(this.tmpCaED.Value[1] - castleEnhanceData.Value[1]), 13, 0f);
			this.text_ShowEffect[0].text = this.Cstr_ShowEffect[0].ToString();
			this.text_ShowEffect[0].SetAllDirty();
			this.text_ShowEffect[0].cachedTextGenerator.Invalidate();
			this.text_ShowEffect[0].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_ShowEffect[0].preferredWidth > this.text_ShowEffect[0].rectTransform.sizeDelta.x)
			{
				this.text_ShowEffect[0].rectTransform.sizeDelta = new Vector2(this.text_ShowEffect[0].preferredWidth + 1f, this.text_ShowEffect[0].rectTransform.sizeDelta.y);
			}
			this.text_ShowEffect[1].text = this.Cstr_ShowEffect[1].ToString();
			this.text_ShowEffect[1].SetAllDirty();
			this.text_ShowEffect[1].cachedTextGenerator.Invalidate();
			this.text_ShowEffect[1].cachedTextGeneratorForLayout.Invalidate();
			if (this.text_ShowEffect[1].preferredWidth > this.text_ShowEffect[1].rectTransform.sizeDelta.x)
			{
				this.text_ShowEffect[1].rectTransform.sizeDelta = new Vector2(this.text_ShowEffect[1].preferredWidth + 1f, this.text_ShowEffect[1].rectTransform.sizeDelta.y);
			}
			if (this.GameT.gameObject.activeSelf)
			{
				float num = 0f;
				if (this.GUIM.bOpenOnIPhoneX)
				{
					num = this.GUIM.IPhoneX_DeltaX;
				}
				this.mV2Start = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
				this.GUIM.m_SpeciallyEffect.UI_bezieEnd = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f - 296f + (float)((this.tmpCaE - 1) * 42) - num, -(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f) + 134f);
				this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.mV2Start, SpeciallyEffect_Kind.CastleStrengrten, 0, 0, true, 1f);
			}
			else
			{
				this.mShowEffectNum += 2;
				this.mShowEffectTime3 = 0.7f;
				this.GUIM.pDVMgr.ShowCastleStrengthenText(14564, false);
			}
		}
	}

	// Token: 0x06001A2D RID: 6701 RVA: 0x002C6490 File Offset: 0x002C4690
	public void ClearShowEffect()
	{
		this.mShowEffectTime2 = 0f;
		if (this.mShowEffectTime3 > 0f)
		{
			GUIManager.Instance.pDVMgr.EndMoveBossText();
		}
		this.mShowEffectTime3 = 0f;
		this.mShowEffectNum = 0;
		for (int i = 0; i < 2; i++)
		{
			this.text_ShowEffect[i].text = string.Empty;
			this.text_ShowEffect[i].SetAllDirty();
			this.text_ShowEffect[i].cachedTextGenerator.Invalidate();
			this.text_ShowEffect[i].gameObject.SetActive(false);
			this.text_ShowEffect[i].rectTransform.anchoredPosition = new Vector2(this.text_ShowEffect[i].rectTransform.anchoredPosition.x, -112f);
			this.text_ShowEffect[i].color = new Color(0.4f, 0.83f, 0.4f, 1f);
		}
	}

	// Token: 0x06001A2E RID: 6702 RVA: 0x002C658C File Offset: 0x002C478C
	public override void OnClose()
	{
		base.OnClose();
		if (this.Tf_Checkbox != null)
		{
			UnityEngine.Object.Destroy(this.Tf_Checkbox.gameObject);
		}
		if (this.Cstr != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr);
		}
		if (this.Cstr_Item != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Item);
		}
		if (this.Cstr_CheckInfo != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_CheckInfo);
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.Cstr_Value[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Value[i]);
			}
			if (this.Cstr_ShowEffect[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ShowEffect[i]);
			}
		}
		for (int j = 0; j < 2; j++)
		{
			if (this.Cstr_Silder[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_Silder[j]);
			}
		}
		if (this.mParticleEffect != null)
		{
			ParticleManager.Instance.DeSpawn(this.mParticleEffect);
			this.mParticleEffect = null;
		}
		if (this.mParticleEffect2 != null && this.mParticleEffect2.activeSelf && ParticleManager.Instance.AllEffectObject != null)
		{
			this.mParticleEffect2.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
			this.mParticleEffect2.gameObject.SetActive(false);
		}
		if (this.mParticleEffect3 != null && this.mParticleEffect3.activeSelf && ParticleManager.Instance.AllEffectObject != null)
		{
			this.mParticleEffect3.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
			this.mParticleEffect3.gameObject.SetActive(false);
		}
		if (this.mParticleEffect4 != null && this.mParticleEffect4.activeSelf && ParticleManager.Instance.AllEffectObject != null)
		{
			this.mParticleEffect4.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
			this.mParticleEffect4.gameObject.SetActive(false);
		}
		if (this.mShowEffectTime3 > 0f)
		{
			GUIManager.Instance.pDVMgr.EndMoveBossText();
		}
	}

	// Token: 0x06001A2F RID: 6703 RVA: 0x002C6818 File Offset: 0x002C4A18
	public override void OnInfoClick(UIButton sender)
	{
		this.Cstr.ClearString();
		this.Cstr.Append(this.DM.mStringTable.GetStringByID(14570u));
		this.Cstr.Append("\n");
		this.Cstr.Append(this.DM.mStringTable.GetStringByID(14571u));
		this.Cstr.Append("\n");
		this.Cstr.Append(this.DM.mStringTable.GetStringByID(14572u));
		this.Cstr.Append("\n");
		this.Cstr.Append(this.DM.mStringTable.GetStringByID(14573u));
		this.Cstr.Append("\n");
		this.Cstr.Append(this.DM.mStringTable.GetStringByID(14575u));
		this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(14561u), this.Cstr.ToString(), null, null, 0, 0, true, true);
	}

	// Token: 0x06001A30 RID: 6704 RVA: 0x002C6944 File Offset: 0x002C4B44
	public override void ClassticalCastleChanged()
	{
		this.Img_CastleBG.sprite = this.GUIM.BuildingData.castleSkin.GetUISprite(0, this.CastleLv);
		this.Img_CastleBG.material = this.GUIM.BuildingData.castleSkin.GetUIMaterial(0, this.CastleLv);
	}

	// Token: 0x06001A31 RID: 6705 RVA: 0x002C69A0 File Offset: 0x002C4BA0
	public override void ReOnOpen()
	{
		base.ReOnOpen();
		this.SetCastleData(false, false);
		if (this.Img_BtnLock != null && this.Img_BtnLock.gameObject.activeSelf)
		{
			this.Img_BtnLock.gameObject.SetActive(false);
		}
		base.UpdateUI(0, 0);
	}

	// Token: 0x06001A32 RID: 6706 RVA: 0x002C69FC File Offset: 0x002C4BFC
	public void OnVauleChang(UnitResourcesSlider sender)
	{
		this.Cstr_Silder[0].ClearString();
		this.Cstr_Silder[1].ClearString();
		this.Cstr_Silder[2].ClearString();
		this.mNeedItemQty = 0;
		this.mStrengthenrate = 0;
		if (!this.bItemQty)
		{
			double num = (double)sender.Value * ((double)this.mItemMax / this.mMaxValue);
			ushort num2 = (ushort)num;
			if (num > (double)num2)
			{
				this.mNeedItemQty = num2 + 1;
			}
			else
			{
				this.mNeedItemQty = num2;
			}
			this.mStrengthenrate = (ushort)sender.Value;
		}
		else
		{
			this.mNeedItemQty = (ushort)sender.Value;
			this.mStrengthenrate = (ushort)((float)sender.Value / (float)this.mItemMax * 100f);
		}
		this.Cstr_Silder[0].IntToFormat((long)this.mNeedItemQty, 1, true);
		this.Cstr_Silder[0].IntToFormat((long)this.mItemMax, 1, true);
		if (this.mNeedItemQty > this.mItemQty)
		{
			if (this.GUIM.IsArabic)
			{
				this.Cstr_Silder[0].AppendFormat("{1} / <color=#FF0000>{0}</color>");
			}
			else
			{
				this.Cstr_Silder[0].AppendFormat("<color=#FF0000>{0}</color> / {1}");
			}
			this.btn_Strengthen.ForTextChange(e_BtnType.e_ChangeText);
		}
		else
		{
			if (this.mNeedItemQty == 0)
			{
				if (this.GUIM.IsArabic)
				{
					this.Cstr_Silder[0].AppendFormat("{1} / {0}");
				}
				else
				{
					this.Cstr_Silder[0].AppendFormat("{0} / {1}");
				}
			}
			else if (this.GUIM.IsArabic)
			{
				this.Cstr_Silder[0].AppendFormat("{1} / <color=#00FF00>{0}</color>");
			}
			else
			{
				this.Cstr_Silder[0].AppendFormat("<color=#00FF00>{0}</color> / {1}");
			}
			this.btn_Strengthen.ForTextChange(e_BtnType.e_Normal);
		}
		this.text_Slider[0].text = this.Cstr_Silder[0].ToString();
		this.text_Slider[0].SetAllDirty();
		this.text_Slider[0].cachedTextGenerator.Invalidate();
		this.Cstr_Silder[1].IntToFormat((long)this.mStrengthenrate, 1, true);
		this.Cstr_Silder[1].AppendFormat("{0}%");
		this.Cstr_Silder[2].StringToFormat(this.Cstr_Silder[1]);
		this.Cstr_Silder[2].AppendFormat(this.DM.mStringTable.GetStringByID(14569u));
		this.text_Slider[1].text = this.Cstr_Silder[2].ToString();
		this.text_Slider[1].SetAllDirty();
		this.text_Slider[1].cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001A33 RID: 6707 RVA: 0x002C6CA8 File Offset: 0x002C4EA8
	public void OnTextChang(UnitResourcesSlider sender)
	{
	}

	// Token: 0x06001A34 RID: 6708 RVA: 0x002C6CAC File Offset: 0x002C4EAC
	public override void OnButtonClick(UIButton sender)
	{
		base.OnButtonClick(sender);
		switch (sender.m_BtnID1)
		{
		case 2:
			if (this.mNeedItemQty == 0 || this.mItemQty < this.mNeedItemQty)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(14568u), 255, true);
				return;
			}
			if (this.GUIM.BuildingData.castleSkin.GetCheckStrengthen())
			{
				this.Cstr_CheckInfo.ClearString();
				this.Cstr_CheckInfo.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpEquip.EquipName));
				this.Cstr_CheckInfo.IntToFormat((long)this.mNeedItemQty, 1, true);
				this.Cstr_CheckInfo.AppendFormat(this.DM.mStringTable.GetStringByID(14566u));
				this.text_Check_Info.text = this.Cstr_CheckInfo.ToString();
				this.text_Check_Info.cachedTextGeneratorForLayout.Invalidate();
				float num = this.text_Check_Info.preferredHeight - 86.8f;
				if (num > 1f)
				{
					this.Tf_Checkbox.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, num);
					this.Tf_Checkbox.GetChild(0).GetComponent<RectTransform>().sizeDelta += new Vector2(0f, num);
					this.text_Check_Info.rectTransform.sizeDelta += new Vector2(0f, num);
				}
				this.Tf_Checkbox.gameObject.SetActive(true);
				return;
			}
			this.DM.UseItem(1326, this.mNeedItemQty, this.tmpCa.ID - 1, 0, 0, 0u, string.Empty, true);
			break;
		case 3:
			this.bCheck = !this.bCheck;
			this.CImg_Check.gameObject.SetActive(this.bCheck);
			break;
		case 4:
			if (this.bCheck && this.GUIM.BuildingData.castleSkin.GetCheckStrengthen())
			{
				this.GUIM.BuildingData.castleSkin.SetCheckStrengthen(!this.bCheck);
			}
			this.Tf_Checkbox.gameObject.SetActive(false);
			this.DM.UseItem(1326, this.mNeedItemQty, this.tmpCa.ID - 1, 0, 0, 0u, string.Empty, true);
			break;
		case 5:
			this.Tf_Checkbox.gameObject.SetActive(false);
			this.bCheck = false;
			this.CImg_Check.gameObject.SetActive(this.bCheck);
			break;
		}
	}

	// Token: 0x06001A35 RID: 6709 RVA: 0x002C6F8C File Offset: 0x002C518C
	public void OnButtonDown(UIButtonHint sender)
	{
		sender.GetTipPosition(this.Hint.ThisTransform, UIButtonHint.ePosition.Original, null);
		this.Hint.Show(this.SelectedCastleID);
	}

	// Token: 0x06001A36 RID: 6710 RVA: 0x002C6FC8 File Offset: 0x002C51C8
	public void OnButtonUp(UIButtonHint sender)
	{
		this.Hint.Hide();
	}

	// Token: 0x06001A37 RID: 6711 RVA: 0x002C6FD8 File Offset: 0x002C51D8
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x06001A38 RID: 6712 RVA: 0x002C6FDC File Offset: 0x002C51DC
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
		img.material = GUIManager.Instance.GetFrameMaterial();
	}

	// Token: 0x06001A39 RID: 6713 RVA: 0x002C700C File Offset: 0x002C520C
	public override bool OnBackButtonClick()
	{
		if (this.Tf_Checkbox.gameObject.activeSelf)
		{
			this.Tf_Checkbox.gameObject.SetActive(false);
			this.bCheck = false;
			this.CImg_Check.gameObject.SetActive(this.bCheck);
			return true;
		}
		return false;
	}

	// Token: 0x06001A3A RID: 6714 RVA: 0x002C7060 File Offset: 0x002C5260
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Item)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else
			{
				this.mItemQty = this.DM.GetCurItemQuantity(1326, 1);
				this.Cstr_Item.ClearString();
				this.Cstr_Item.IntToFormat((long)this.mItemQty, 1, true);
				this.Cstr_Item.AppendFormat(this.DM.mStringTable.GetStringByID(79u));
				this.text_Item[1].text = this.Cstr_Item.ToString();
				this.text_Item[1].SetAllDirty();
				this.text_Item[1].cachedTextGenerator.Invalidate();
				this.Cstr_Silder[0].ClearString();
				this.Cstr_Silder[0].IntToFormat((long)this.mNeedItemQty, 1, true);
				this.Cstr_Silder[0].IntToFormat((long)this.mItemMax, 1, true);
				if (this.mNeedItemQty > this.mItemQty)
				{
					if (this.GUIM.IsArabic)
					{
						this.Cstr_Silder[0].AppendFormat("{1} / <color=#FF0000>{0}</color>");
					}
					else
					{
						this.Cstr_Silder[0].AppendFormat("<color=#FF0000>{0}</color> / {1}");
					}
				}
				else if (this.mNeedItemQty == 0)
				{
					if (this.GUIM.IsArabic)
					{
						this.Cstr_Silder[0].AppendFormat("{1} / {0}");
					}
					else
					{
						this.Cstr_Silder[0].AppendFormat("{0} / {1}");
					}
				}
				else if (this.GUIM.IsArabic)
				{
					this.Cstr_Silder[0].AppendFormat("{1} / <color=#00FF00>{0}</color>");
				}
				else
				{
					this.Cstr_Silder[0].AppendFormat("<color=#00FF00>{0}</color> / {1}");
				}
				this.text_Slider[0].text = this.Cstr_Silder[0].ToString();
				this.text_Slider[0].SetAllDirty();
				this.text_Slider[0].cachedTextGenerator.Invalidate();
			}
		}
		else
		{
			this.SetCastleData(false, false);
			if (this.Img_BtnLock != null && this.mShowEffectTime3 == 0f && !this.bshowText && this.mShowEffectNum == 0)
			{
				this.Img_BtnLock.gameObject.SetActive(false);
			}
			base.UpdateUI(0, 0);
		}
	}

	// Token: 0x06001A3B RID: 6715 RVA: 0x002C72D0 File Offset: 0x002C54D0
	public override void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		if (this.Img_BtnLock != null && !this.Img_BtnLock.gameObject.activeSelf)
		{
			base.ButtonOnClick(gameObject, dataIndex, panelId);
			this.mStrengthenrate = 0;
			this.SetCastleData(false, true);
			if (this.Img_BtnLock != null && this.Img_BtnLock.gameObject.activeSelf)
			{
				this.Img_BtnLock.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001A3C RID: 6716 RVA: 0x002C7354 File Offset: 0x002C5554
	public void Refresh_FontTexture()
	{
		if (this.text_Name != null && this.text_Name.enabled)
		{
			this.text_Name.enabled = false;
			this.text_Name.enabled = true;
		}
		if (this.text_Strengthen != null && this.text_Strengthen.enabled)
		{
			this.text_Strengthen.enabled = false;
			this.text_Strengthen.enabled = true;
		}
		if (this.text_ItemQty != null && this.text_ItemQty.enabled)
		{
			this.text_ItemQty.enabled = false;
			this.text_ItemQty.enabled = true;
		}
		if (this.text_Check_title != null && this.text_Check_title.enabled)
		{
			this.text_Check_title.enabled = false;
			this.text_Check_title.enabled = true;
		}
		if (this.text_Check_Info != null && this.text_Check_Info.enabled)
		{
			this.text_Check_Info.enabled = false;
			this.text_Check_Info.enabled = true;
		}
		if (this.text_Check_btn_Ok != null && this.text_Check_btn_Ok.enabled)
		{
			this.text_Check_btn_Ok.enabled = false;
			this.text_Check_btn_Ok.enabled = true;
		}
		if (this.text_Check_btn_Cancel != null && this.text_Check_btn_Cancel.enabled)
		{
			this.text_Check_btn_Cancel.enabled = false;
			this.text_Check_btn_Cancel.enabled = true;
		}
		if (this.text_Check != null && this.text_Check.enabled)
		{
			this.text_Check.enabled = false;
			this.text_Check.enabled = true;
		}
		if (this.text_CastleMaxRank != null && this.text_CastleMaxRank.enabled)
		{
			this.text_CastleMaxRank.enabled = false;
			this.text_CastleMaxRank.enabled = true;
		}
		if (this.btn_Item != null && this.btn_Item.enabled)
		{
			this.btn_Item.Refresh_FontTexture();
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_Item[i] != null && this.text_Item[i].enabled)
			{
				this.text_Item[i].enabled = false;
				this.text_Item[i].enabled = true;
			}
			if (this.text_Effect[i] != null && this.text_Effect[i].enabled)
			{
				this.text_Effect[i].enabled = false;
				this.text_Effect[i].enabled = true;
			}
			if (this.text_Value[i] != null && this.text_Value[i].enabled)
			{
				this.text_Value[i].enabled = false;
				this.text_Value[i].enabled = true;
			}
			if (this.text_Slider[i] != null && this.text_Slider[i].enabled)
			{
				this.text_Slider[i].enabled = false;
				this.text_Slider[i].enabled = true;
			}
			if (this.text_ShowEffect[i] != null && this.text_ShowEffect[i].enabled)
			{
				this.text_ShowEffect[i].enabled = false;
				this.text_ShowEffect[i].enabled = true;
			}
		}
	}

	// Token: 0x06001A3D RID: 6717 RVA: 0x002C76E8 File Offset: 0x002C58E8
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			this.mParticleEffect4 = ParticleManager.Instance.Spawn(427, this.GameT, new Vector3(0f, 0f, 0f), 1f, true, true, true);
			this.GUIM.SetLayer(this.mParticleEffect4, 5);
			this.mParticleEffect4.transform.localPosition = new Vector3(0f, 0f, -800f);
			this.mParticleEffect4.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			this.bshowText = true;
			this.mShowEffectTime4 = 0.5f;
			this.mShowEffectTime = 0f;
			this.mShowEffectNum = 0;
			this.mSpeciallyEffect = 1;
			this.ClearShowEffect();
			this.GUIM.m_SpeciallyEffect.ClearAllEffect();
			this.Img_BtnLock.gameObject.SetActive(true);
			AudioManager.Instance.PlayMP3SFX(41037, 0f);
			break;
		case 2:
			if (this.mSpeciallyEffect == 1)
			{
				this.mParticleEffect2 = ParticleManager.Instance.Spawn(372, this.Img_CastleBG.transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
				this.GUIM.SetLayer(this.mParticleEffect2, 5);
				this.mParticleEffect2.transform.localPosition = new Vector3(0f, 0f, -800f);
				this.mParticleEffect2.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
				this.mShowEffectTime3 = 0.7f;
				this.mShowEffectNum += 2;
				this.GUIM.pDVMgr.ShowCastleStrengthenText(14564, false);
				this.mStrengthenrate = 0;
				this.UpdataCastle(false, true);
				this.SetChangCastleRank((int)this.tmpCaE);
				base.UpdateUI(arg1, arg2);
				AudioManager.Instance.PlayUISFX(UIKind.CastleStrength);
			}
			break;
		case 3:
			this.mParticleEffect4 = ParticleManager.Instance.Spawn(427, this.GameT, new Vector3(0f, 0f, 0f), 1f, true, true, true);
			this.GUIM.SetLayer(this.mParticleEffect4, 5);
			this.mParticleEffect4.transform.localPosition = new Vector3(0f, 0f, -800f);
			this.mParticleEffect4.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
			this.bshowText = true;
			this.mShowEffectTime4 = 0.5f;
			this.mShowEffectTime = 0f;
			this.mShowEffectNum = 0;
			this.mSpeciallyEffect = 2;
			this.ClearShowEffect();
			this.GUIM.m_SpeciallyEffect.ClearAllEffect();
			this.Img_BtnLock.gameObject.SetActive(true);
			AudioManager.Instance.PlayMP3SFX(41038, 0f);
			break;
		case 4:
			this.SetCastleData(false, false);
			if (this.Img_BtnLock != null && this.mShowEffectTime3 == 0f && !this.bshowText && this.mShowEffectNum == 0)
			{
				this.Img_BtnLock.gameObject.SetActive(false);
			}
			base.UpdateUI(0, 0);
			break;
		}
	}

	// Token: 0x06001A3E RID: 6718 RVA: 0x002C7A84 File Offset: 0x002C5C84
	public override void UpdateTime(bool bOnSecond)
	{
		base.UpdateTime(bOnSecond);
		if (!bOnSecond)
		{
			if (this.Img_CastleHint[1] != null && this.Img_CastleHint[1].IsActive())
			{
				this.Img_HintTime += Time.smoothDeltaTime;
				if (this.Img_HintTime >= 0f)
				{
					if (this.Img_HintTime >= 2f)
					{
						this.Img_HintTime = 0f;
					}
					float a = (this.Img_HintTime <= 1f) ? this.Img_HintTime : (2f - this.Img_HintTime);
					this.Img_CastleHint[1].color = new Color(1f, 1f, 1f, a);
				}
			}
			if (this.Tf2 != null && this.Tf2.gameObject.activeSelf)
			{
				this.Img_CastleMax.transform.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
			}
			if (this.mShowEffectTime4 > 0f)
			{
				this.mShowEffectTime4 -= Time.smoothDeltaTime;
				if (this.mShowEffectTime4 < 0f)
				{
					if (this.mParticleEffect == null)
					{
						this.mParticleEffect = ParticleManager.Instance.Spawn(423, this.GameT, new Vector3(0f, 0f, 0f), 1f, true, true, true);
						this.GUIM.SetLayer(this.mParticleEffect, 5);
						this.mParticleEffect.transform.localPosition = new Vector3(0f, 0f, -800f);
						this.mParticleEffect.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
					}
					else
					{
						this.mParticleEffect.gameObject.SetActive(true);
					}
				}
			}
			if (this.bshowText)
			{
				this.mShowEffectTime += Time.smoothDeltaTime;
				if (this.mShowEffectTime >= 1.5f && this.mShowEffectNum == 0)
				{
					this.AddShowEffect();
					this.bshowText = false;
					if (this.mParticleEffect != null && this.mParticleEffect.gameObject.activeSelf)
					{
						this.mParticleEffect.gameObject.SetActive(false);
					}
					if (this.mSpeciallyEffect == 1)
					{
						this.mParticleEffect3 = ParticleManager.Instance.Spawn(424, this.GameT, new Vector3(0f, 0f, 0f), 1f, true, true, true);
					}
					else if (this.mSpeciallyEffect == 2)
					{
						this.mParticleEffect3 = ParticleManager.Instance.Spawn(425, this.GameT, new Vector3(0f, 0f, 0f), 1f, true, true, true);
						this.GUIM.pDVMgr.ShowCastleStrengthenText(14565, true);
						this.mShowEffectTime3 = 0.7f;
					}
					this.GUIM.SetLayer(this.mParticleEffect3, 5);
					this.mParticleEffect3.transform.localPosition = new Vector3(0f, 0f, -800f);
					this.mParticleEffect3.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
				}
			}
			if (this.mShowEffectNum > 0)
			{
				this.mShowEffectTime2 += Time.smoothDeltaTime;
				for (int i = 0; i < 2; i++)
				{
					if (this.text_ShowEffect[i] != null)
					{
						if (this.text_ShowEffect[i].IsActive())
						{
							if (this.text_ShowEffect[i].rectTransform.anchoredPosition.y >= 70f && this.text_ShowEffect[i].rectTransform.anchoredPosition.y < 100f)
							{
								this.text_ShowEffect[i].color = new Color(0.4f, 0.83f, 0.4f, (100f - this.text_ShowEffect[i].rectTransform.anchoredPosition.y) / 30f);
							}
							else if (this.text_ShowEffect[i].rectTransform.anchoredPosition.y >= 100f)
							{
								this.text_ShowEffect[i].gameObject.SetActive(false);
								this.mShowEffectNum--;
							}
							this.text_ShowEffect[i].rectTransform.anchoredPosition = new Vector2(this.text_ShowEffect[i].rectTransform.anchoredPosition.x, -112f + (this.mShowEffectTime2 - (float)i * 0.2f) * 200f);
						}
						else if (this.mShowEffectTime2 >= (float)i * 0.2f && this.text_ShowEffect[i].rectTransform.anchoredPosition.y == -112f)
						{
							this.text_ShowEffect[i].gameObject.SetActive(true);
						}
					}
				}
			}
			if (this.mShowEffectTime3 > 0f)
			{
				this.mShowEffectTime3 -= Time.smoothDeltaTime;
				if (this.mShowEffectTime3 < 0f)
				{
					if (this.mSpeciallyEffect == 1)
					{
						GUIManager.Instance.pDVMgr.BeginMoveBossText();
					}
					else if (this.mSpeciallyEffect == 2)
					{
						GUIManager.Instance.pDVMgr.BeginMoveBossText(300f);
					}
					if (this.Img_BtnLock != null)
					{
						this.Img_BtnLock.gameObject.SetActive(false);
					}
					this.mSpeciallyEffect = 0;
				}
			}
		}
	}

	// Token: 0x04004D6B RID: 19819
	private DataManager DM;

	// Token: 0x04004D6C RID: 19820
	private GUIManager GUIM;

	// Token: 0x04004D6D RID: 19821
	private Font TTFont;

	// Token: 0x04004D6E RID: 19822
	private Door door;

	// Token: 0x04004D6F RID: 19823
	private UISpritesArray SArray;

	// Token: 0x04004D70 RID: 19824
	private Transform GameT;

	// Token: 0x04004D71 RID: 19825
	private Transform Tf1;

	// Token: 0x04004D72 RID: 19826
	private Transform Tf2;

	// Token: 0x04004D73 RID: 19827
	private Transform Tmp;

	// Token: 0x04004D74 RID: 19828
	private Transform Tmp1;

	// Token: 0x04004D75 RID: 19829
	private Transform Tmp2;

	// Token: 0x04004D76 RID: 19830
	private Transform Tf_Checkbox;

	// Token: 0x04004D77 RID: 19831
	private UnitResourcesSlider m_UnitRS;

	// Token: 0x04004D78 RID: 19832
	private UIButton btn_CastleHint;

	// Token: 0x04004D79 RID: 19833
	private UIButton btn_Strengthen;

	// Token: 0x04004D7A RID: 19834
	private UIButton btn_Check;

	// Token: 0x04004D7B RID: 19835
	private UIButton btn_Check_Ok;

	// Token: 0x04004D7C RID: 19836
	private UIButton btn_Check_Cancal;

	// Token: 0x04004D7D RID: 19837
	private Image Img_CastleBG;

	// Token: 0x04004D7E RID: 19838
	private Image Img_CastleMax;

	// Token: 0x04004D7F RID: 19839
	private Image Img_BtnLock;

	// Token: 0x04004D80 RID: 19840
	private Image Img_SkinUse;

	// Token: 0x04004D81 RID: 19841
	private Image[] Img_CastleHint = new Image[2];

	// Token: 0x04004D82 RID: 19842
	private Image[] Img_Strengthen = new Image[5];

	// Token: 0x04004D83 RID: 19843
	private CustomImage CImg_Check;

	// Token: 0x04004D84 RID: 19844
	private UIText text_Name;

	// Token: 0x04004D85 RID: 19845
	private UIText text_Strengthen;

	// Token: 0x04004D86 RID: 19846
	private UIText text_ItemQty;

	// Token: 0x04004D87 RID: 19847
	private UIText[] text_Item = new UIText[2];

	// Token: 0x04004D88 RID: 19848
	private UIText[] text_Effect = new UIText[2];

	// Token: 0x04004D89 RID: 19849
	private UIText[] text_Value = new UIText[2];

	// Token: 0x04004D8A RID: 19850
	private UIText[] text_Slider = new UIText[2];

	// Token: 0x04004D8B RID: 19851
	private UIText[] text_ShowEffect = new UIText[2];

	// Token: 0x04004D8C RID: 19852
	private UIText text_Check_title;

	// Token: 0x04004D8D RID: 19853
	private UIText text_Check_Info;

	// Token: 0x04004D8E RID: 19854
	private UIText text_Check_btn_Ok;

	// Token: 0x04004D8F RID: 19855
	private UIText text_Check_btn_Cancel;

	// Token: 0x04004D90 RID: 19856
	private UIText text_Check;

	// Token: 0x04004D91 RID: 19857
	private UIText text_CastleMaxRank;

	// Token: 0x04004D92 RID: 19858
	private UIHIBtn btn_Item;

	// Token: 0x04004D93 RID: 19859
	private CString Cstr;

	// Token: 0x04004D94 RID: 19860
	private CString Cstr_Item;

	// Token: 0x04004D95 RID: 19861
	private CString[] Cstr_Value = new CString[2];

	// Token: 0x04004D96 RID: 19862
	private CString[] Cstr_Silder = new CString[3];

	// Token: 0x04004D97 RID: 19863
	private CString[] Cstr_ShowEffect = new CString[2];

	// Token: 0x04004D98 RID: 19864
	private CString Cstr_CheckInfo;

	// Token: 0x04004D99 RID: 19865
	private bool bItemQty = true;

	// Token: 0x04004D9A RID: 19866
	private ushort mItemMax;

	// Token: 0x04004D9B RID: 19867
	private uint mMaxValue = 100u;

	// Token: 0x04004D9C RID: 19868
	private ushort mNeedItemQty;

	// Token: 0x04004D9D RID: 19869
	private ushort mItemQty;

	// Token: 0x04004D9E RID: 19870
	private ushort mStrengthenrate;

	// Token: 0x04004D9F RID: 19871
	private GameObject mParticleEffect;

	// Token: 0x04004DA0 RID: 19872
	private GameObject mParticleEffect2;

	// Token: 0x04004DA1 RID: 19873
	private GameObject mParticleEffect3;

	// Token: 0x04004DA2 RID: 19874
	private GameObject mParticleEffect4;

	// Token: 0x04004DA3 RID: 19875
	public int mShowEffectNum;

	// Token: 0x04004DA4 RID: 19876
	public float mShowEffectTime;

	// Token: 0x04004DA5 RID: 19877
	private bool bCheck;

	// Token: 0x04004DA6 RID: 19878
	private CastleSkinTbl tmpCa;

	// Token: 0x04004DA7 RID: 19879
	private byte tmpCaE;

	// Token: 0x04004DA8 RID: 19880
	private CastleEnhanceTbl tmpCaED;

	// Token: 0x04004DA9 RID: 19881
	private Equip tmpEquip;

	// Token: 0x04004DAA RID: 19882
	private float Img_HintTime;

	// Token: 0x04004DAB RID: 19883
	private byte mSpeciallyEffect;

	// Token: 0x04004DAC RID: 19884
	private Vector2 mV2Start = Vector2.zero;

	// Token: 0x04004DAD RID: 19885
	public float mShowEffectTime2;

	// Token: 0x04004DAE RID: 19886
	public float mShowEffectTime3;

	// Token: 0x04004DAF RID: 19887
	public float mShowEffectTime4;

	// Token: 0x04004DB0 RID: 19888
	private bool bshowText;
}
