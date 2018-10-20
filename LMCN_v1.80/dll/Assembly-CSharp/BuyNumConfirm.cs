using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200081F RID: 2079
public class BuyNumConfirm : UIBagFilterBase, IUICalculatorHandler, IUIUnitRSliderHandler
{
	// Token: 0x06002B32 RID: 11058 RVA: 0x00474ED8 File Offset: 0x004730D8
	void IUIUnitRSliderHandler.OnVauleChang(UnitResourcesSlider sender)
	{
		this.Cstr.ClearString();
		StringManager.IntToStr(this.Cstr, sender.Value, 1, true);
		sender.m_inputText.text = this.Cstr.ToString();
		sender.m_inputText.SetAllDirty();
		sender.m_inputText.cachedTextGenerator.Invalidate();
		this.UpdatePrice();
	}

	// Token: 0x06002B33 RID: 11059 RVA: 0x00474F3C File Offset: 0x0047313C
	void IUIUnitRSliderHandler.OnTextChang(UnitResourcesSlider sender)
	{
		this.Cstr.ClearString();
		StringManager.IntToStr(this.Cstr, sender.Value, 1, true);
		sender.m_inputText.text = this.Cstr.ToString();
		sender.m_inputText.SetAllDirty();
		sender.m_inputText.cachedTextGenerator.Invalidate();
		this.UpdatePrice();
	}

	// Token: 0x06002B34 RID: 11060 RVA: 0x00474FA0 File Offset: 0x004731A0
	void IUICalculatorHandler.OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
	{
		URS.m_slider.value = (double)mValue;
		URS.Value = (long)URS.m_slider.value;
	}

	// Token: 0x06002B35 RID: 11061 RVA: 0x00474FC4 File Offset: 0x004731C4
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager instance = GUIManager.Instance;
		DataManager instance2 = DataManager.Instance;
		Font ttffont = instance.GetTTFFont();
		this.ThisTransform = this.transform.GetChild(5);
		RectTransform component = this.ThisTransform.GetChild(1).GetChild(0).GetComponent<RectTransform>();
		component.sizeDelta = new Vector2(507f, 447f);
		component = this.ThisTransform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(-204f, 131f);
		this.NumText = this.ThisTransform.GetChild(2).GetChild(2).GetComponent<UIText>();
		this.NumText.font = ttffont;
		this.NumText.color = Color.white;
		base.AddRefreshText(this.NumText);
		if (instance.bOpenOnIPhoneX)
		{
			RectTransform component2 = this.ThisTransform.GetChild(0).GetComponent<RectTransform>();
			component2.offsetMin = new Vector2(component2.offsetMin.x - instance.IPhoneX_DeltaX, component2.offsetMin.y);
			component2.offsetMax = new Vector2(component2.offsetMax.x + instance.IPhoneX_DeltaX, component2.offsetMax.y);
		}
		this.NumStr = StringManager.Instance.SpawnString(30);
		this.TipStr = StringManager.Instance.SpawnString(30);
		this.Cstr = StringManager.Instance.SpawnString(30);
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null)
		{
			Image component3 = this.ThisTransform.GetChild(0).GetComponent<Image>();
			component3.material = door.LoadMaterial();
			component3.sprite = door.LoadSprite("UI_main_black");
			component3.type = Image.Type.Sliced;
		}
		this.ThisTransform.GetChild(2).GetChild(2).gameObject.SetActive(true);
		this.MsgIcon = this.ThisTransform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>();
		UIButton component4 = this.ThisTransform.GetChild(0).GetComponent<UIButton>();
		component4.m_BtnID1 = 1;
		component4.m_Handler = this;
		this.ItemRect = this.ThisTransform.GetChild(4).GetComponent<RectTransform>();
		this.ItemRect.anchoredPosition = new Vector2(-148f, 83f);
		instance.InitianHeroItemImg(this.ItemRect, eHeroOrItem.Item, this.ItemID, 0, 0, 0, false, true, true, false);
		base.AddRefreshText(this.ItemRect.GetChild(4).GetComponent<UIText>());
		this.ItemNameText = this.ThisTransform.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.ItemNameText.rectTransform.anchoredPosition = new Vector2(51f, 337f);
		this.ItemNameText.font = ttffont;
		base.AddRefreshText(this.ItemNameText);
		this.TitleText = this.ThisTransform.GetChild(2).GetChild(1).GetComponent<UIText>();
		this.TitleText.font = ttffont;
		base.AddRefreshText(this.TitleText);
		this.TitleText.rectTransform.anchoredPosition = new Vector2(3f, 32.5f);
		this.TitleText.text = instance2.mStringTable.GetStringByID(283u);
		int num = 0;
		this.slider = this.ThisTransform.GetChild(5).gameObject.AddComponent<UnitResourcesSlider>();
		instance.InitUnitResourcesSlider(this.slider.transform, eUnitSlider.AutoUse, 0u, 0u, 1f);
		instance.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnLessen, 210.5f, -322.2f, 70f, 60f, 0f, 0f);
		instance.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 384.5f, -322.2f, 257f, 19f, 0f, (float)num);
		instance.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnIncrease, 541.2f, -322.2f, 70f, 60f, 0f, 0f);
		instance.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.Input, 328f, -272.6f, 94f, 35f, 0f, 0f);
		component = this.slider.transform.GetChild(3).GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(328f, -272.6f);
		component.sizeDelta = new Vector2(94f, 35f);
		this.slider.transform.GetChild(1).GetComponent<Image>().preserveAspect = true;
		this.slider.transform.GetChild(0).GetComponent<Image>().preserveAspect = true;
		this.slider.BtnInputText.m_Handler = this;
		this.slider.BtnInputText.m_BtnID1 = 2;
		Text component5 = this.ThisTransform.GetChild(5).GetChild(3).GetChild(0).GetComponent<UIText>();
		component5.fontSize = 24;
		component5.alignment = TextAnchor.MiddleRight;
		base.AddRefreshText(component5);
		this.slider.m_Handler = this;
		this.AutouseSlider = this.ThisTransform.GetChild(5).GetChild(2).GetComponent<CSlider>();
		this.ThisTransform.GetChild(7).GetChild(0).GetComponent<RectTransform>().gameObject.SetActive(false);
		this.ThisTransform.GetChild(8).GetChild(0).gameObject.SetActive(false);
		this.TipText = this.ThisTransform.GetChild(8).GetComponent<UIText>();
		this.TipText.font = ttffont;
		this.TipText.rectTransform.anchoredPosition = new Vector2(1.8f, -100f);
		this.TipText.fontSize = 18;
		base.AddRefreshText(this.TipText);
		this.ThisTransform.GetChild(6).gameObject.SetActive(false);
		component = this.ThisTransform.GetChild(9).GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(115.5f, -163f);
		component4 = component.GetComponent<UIButton>();
		component4.m_BtnID1 = 0;
		component4.m_Handler = this;
		component = this.ThisTransform.GetChild(10).GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(-111.5f, -163f);
		component4 = this.ThisTransform.GetChild(10).GetComponent<UIButton>();
		component4.m_Handler = this;
		component4.m_BtnID1 = 1;
		component5 = this.ThisTransform.GetChild(9).GetChild(0).GetComponent<UIText>();
		component5.text = instance2.mStringTable.GetStringByID(284u);
		component5.font = ttffont;
		base.AddRefreshText(component5);
		component5 = this.ThisTransform.GetChild(10).GetChild(0).GetComponent<UIText>();
		component5.text = instance2.mStringTable.GetStringByID(4u);
		component5.font = ttffont;
		base.AddRefreshText(component5);
		this.SpriteArray = this.ThisTransform.GetChild(11).GetComponent<UISpritesArray>();
		this.UpdateData(arg1);
	}

	// Token: 0x06002B36 RID: 11062 RVA: 0x00475704 File Offset: 0x00473904
	public override void OnClose()
	{
		if (this.NumStr == null)
		{
			return;
		}
		StringManager.Instance.DeSpawnString(this.NumStr);
		StringManager.Instance.DeSpawnString(this.TipStr);
		StringManager.Instance.DeSpawnString(this.Cstr);
		this.NumStr = null;
		UnityEngine.Object.Destroy(this.ThisTransform.gameObject);
		GUIManager.Instance.ClearCalculator();
	}

	// Token: 0x06002B37 RID: 11063 RVA: 0x00475774 File Offset: 0x00473974
	public override void UpdateUI(int arge1, int arge2)
	{
		int num = arge1 >> 16;
		if (num != 1)
		{
			return;
		}
		if (arge1 == 65537)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0, -1);
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 65537, (int)(this.slider.Value << 16 | (long)this.ItemID));
		}
	}

	// Token: 0x06002B38 RID: 11064 RVA: 0x004757DC File Offset: 0x004739DC
	public void UpdateData(int parm1)
	{
		if (parm1 == -1)
		{
			return;
		}
		GUIManager instance = GUIManager.Instance;
		DataManager instance2 = DataManager.Instance;
		this.ItemSN = (ushort)(parm1 >> 16);
		this.StoreType = (byte)(65535 & parm1);
		bool flag = true;
		if (this.StoreType >> 4 == 1)
		{
			this.StoreType = (15 & this.StoreType);
			flag = false;
		}
		StoreTbl recordByKey = instance2.StoreData.GetRecordByKey(this.ItemSN);
		this.ItemID = recordByKey.ItemID;
		Equip recordByKey2 = instance2.EquipTable.GetRecordByKey(this.ItemID);
		this.ItemNameText.text = instance2.mStringTable.GetStringByID((uint)recordByKey2.EquipName);
		int num;
		if (this.StoreType == 1)
		{
			num = (int)(instance2.RoleAttr.Diamond / recordByKey.Price);
		}
		else
		{
			num = (int)(instance2.RoleAlliance.Money / recordByKey.AlliancePoint);
		}
		if (flag)
		{
			if (num + (int)instance2.GetCurItemQuantity(this.ItemID, 0) >= 65535)
			{
				num = (int)(ushort.MaxValue - instance2.GetCurItemQuantity(this.ItemID, 0));
			}
		}
		else if (num > 65535)
		{
			num = 65535;
		}
		this.MsgIcon.sprite = this.SpriteArray.GetSprite((int)(this.StoreType + 9));
		this.MsgIcon.SetNativeSize();
		instance.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 384.5f, -322.2f, 257f, 19f, 0f, (float)num);
		instance.ChangeHeroItemImg(this.ItemRect, eHeroOrItem.Item, this.ItemID, 0, 0, 0);
		this.slider.m_slider.value = 1.0;
		this.AutouseSlider.value = this.slider.m_slider.value;
		this.slider.Value = (long)this.slider.m_slider.value;
		this.Cstr.ClearString();
		StringManager.IntToStr(this.Cstr, this.slider.Value, 1, true);
		this.slider.m_inputText.text = this.Cstr.ToString();
		this.slider.m_inputText.SetAllDirty();
		this.slider.m_inputText.cachedTextGenerator.Invalidate();
		this.UpdatePrice();
	}

	// Token: 0x06002B39 RID: 11065 RVA: 0x00475A3C File Offset: 0x00473C3C
	private void UpdatePrice()
	{
		if (this.slider.Value <= 0L)
		{
			this.slider.Value = 1L;
			this.slider.m_slider.value = (double)this.slider.Value;
		}
		this.NumStr.ClearString();
		StoreTbl recordByKey = DataManager.Instance.StoreData.GetRecordByKey(this.ItemSN);
		int num;
		if (this.StoreType == 1)
		{
			num = (int)((ulong)recordByKey.Price * (ulong)this.slider.Value);
			this.NumStr.IntToFormat((long)num, 1, true);
			this.NumStr.IntToFormat((long)((ulong)DataManager.Instance.RoleAttr.Diamond), 1, true);
		}
		else
		{
			num = (int)((ulong)recordByKey.AlliancePoint * (ulong)this.slider.Value);
			this.NumStr.IntToFormat((long)num, 1, true);
			this.NumStr.IntToFormat((long)((ulong)DataManager.Instance.RoleAlliance.Money), 1, true);
		}
		if (GUIManager.Instance.IsArabic)
		{
			this.NumStr.AppendFormat("{1}/{0}");
		}
		else
		{
			this.NumStr.AppendFormat("{0}/{1}");
		}
		this.NumText.text = this.NumStr.ToString();
		this.NumText.SetAllDirty();
		this.NumText.cachedTextGenerator.Invalidate();
		this.NumText.cachedTextGeneratorForLayout.Invalidate();
		Vector2 anchoredPosition = this.MsgIcon.rectTransform.anchoredPosition;
		anchoredPosition.x = -this.NumText.preferredWidth * 0.5f - this.MsgIcon.rectTransform.sizeDelta.x * 0.5f;
		this.MsgIcon.rectTransform.anchoredPosition = anchoredPosition;
		this.TipStr.ClearString();
		this.TipStr.IntToFormat((long)num, 1, true);
		this.TipStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(231u));
		this.TipText.text = this.TipStr.ToString();
		this.TipText.SetAllDirty();
		this.TipText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06002B3A RID: 11066 RVA: 0x00475C7C File Offset: 0x00473E7C
	public override void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.StoreType == 1)
			{
				StoreTbl recordByKey = DataManager.Instance.StoreData.GetRecordByKey(this.ItemSN);
				if (!GUIManager.Instance.OpenCheckCrystal((uint)((ulong)recordByKey.Price * (ulong)this.slider.Value), 1, 65537, -1))
				{
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0, -1);
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 65537, (int)(this.slider.Value << 16 | (long)this.ItemID));
				}
			}
			else
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0, -1);
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 65537, (int)(this.slider.Value << 16 | (long)this.ItemID));
			}
			break;
		case 1:
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0, -1);
			break;
		case 2:
			GUIManager.Instance.m_UICalculator.m_CalculatorHandler = this;
			GUIManager.Instance.m_UICalculator.OpenCalculator(this.slider.MaxValue, this.slider.Value, 290.22f, -25.96f, this.slider, 0L);
			break;
		}
	}

	// Token: 0x0400773B RID: 30523
	private UIText NumText;

	// Token: 0x0400773C RID: 30524
	private UIText ItemNameText;

	// Token: 0x0400773D RID: 30525
	private UIText TitleText;

	// Token: 0x0400773E RID: 30526
	private UIText TipText;

	// Token: 0x0400773F RID: 30527
	private CString NumStr;

	// Token: 0x04007740 RID: 30528
	private CString TipStr;

	// Token: 0x04007741 RID: 30529
	private CString Cstr;

	// Token: 0x04007742 RID: 30530
	private UnitResourcesSlider slider;

	// Token: 0x04007743 RID: 30531
	private CSlider AutouseSlider;

	// Token: 0x04007744 RID: 30532
	private Image MsgIcon;

	// Token: 0x04007745 RID: 30533
	private UISpritesArray SpriteArray;

	// Token: 0x04007746 RID: 30534
	private RectTransform ItemRect;

	// Token: 0x04007747 RID: 30535
	private ushort ItemID;

	// Token: 0x04007748 RID: 30536
	private ushort ItemSN;

	// Token: 0x04007749 RID: 30537
	private byte StoreType;

	// Token: 0x02000820 RID: 2080
	private enum UIControl : byte
	{
		// Token: 0x0400774B RID: 30539
		MaskImage,
		// Token: 0x0400774C RID: 30540
		Background,
		// Token: 0x0400774D RID: 30541
		Title,
		// Token: 0x0400774E RID: 30542
		Hero,
		// Token: 0x0400774F RID: 30543
		HiBtn,
		// Token: 0x04007750 RID: 30544
		Slider,
		// Token: 0x04007751 RID: 30545
		MaxQty,
		// Token: 0x04007752 RID: 30546
		ArabicRot,
		// Token: 0x04007753 RID: 30547
		Tip,
		// Token: 0x04007754 RID: 30548
		Confirm,
		// Token: 0x04007755 RID: 30549
		Cancel,
		// Token: 0x04007756 RID: 30550
		SpriteArray
	}

	// Token: 0x02000821 RID: 2081
	private enum UISliderControl
	{
		// Token: 0x04007758 RID: 30552
		Increase,
		// Token: 0x04007759 RID: 30553
		Decrease,
		// Token: 0x0400775A RID: 30554
		Slider,
		// Token: 0x0400775B RID: 30555
		Input
	}

	// Token: 0x02000822 RID: 2082
	private enum ClickType
	{
		// Token: 0x0400775D RID: 30557
		Confirm,
		// Token: 0x0400775E RID: 30558
		Cancel,
		// Token: 0x0400775F RID: 30559
		InputText
	}
}
