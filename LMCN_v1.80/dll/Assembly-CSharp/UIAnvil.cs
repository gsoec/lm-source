using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x020004D3 RID: 1235
public class UIAnvil : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUILEBtnClickHandler
{
	// Token: 0x060018EB RID: 6379 RVA: 0x0029B4D4 File Offset: 0x002996D4
	public override void OnOpen(int arg1, int arg2)
	{
		this.door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
		this.DM = DataManager.Instance;
		if (this.DM.mLordEquip == null)
		{
			this.DM.mLordEquip = LordEquipData.Instance();
		}
		this.OpenOrange = (this.DM.GetTechLevel(227) > 0);
		this.ItemNameText = StringManager.Instance.SpawnString(100);
		this.ItemLevelText = StringManager.Instance.SpawnString(50);
		this.goldCost = StringManager.Instance.SpawnString(100);
		this.moneyCost = StringManager.Instance.SpawnString(100);
		this.timeCost = StringManager.Instance.SpawnString(30);
		this.timeRemain = StringManager.Instance.SpawnString(30);
		this.focusName = StringManager.Instance.SpawnString(50);
		this.forgingItemName = StringManager.Instance.SpawnString(50);
		this.PopString = StringManager.Instance.SpawnString(300);
		this.PopUpHeaderText = StringManager.Instance.SpawnString(50);
		for (int i = 0; i < this.RequestCount.Length; i++)
		{
			this.RequestCount[i] = StringManager.Instance.SpawnString(30);
		}
		for (int j = 0; j < this.EffDescText.Length; j++)
		{
			this.EffDescText[j] = StringManager.Instance.SpawnString(200);
		}
		for (int k = 0; k < this.CombineCount.Length; k++)
		{
			this.CombineCount[k] = StringManager.Instance.SpawnString(30);
		}
		this.SPHeight = new List<float>();
		this.effectList = new List<LordEquipEffectSet>();
		eUI_Anvil_OpenKind openKind = UIAnvil.OpenKind;
		if (openKind == eUI_Anvil_OpenKind.ForgeNewItem)
		{
			UIAnvil.preSetID = (ushort)arg1;
			this.preSetColor = (byte)arg2;
		}
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7430u);
		Image component2 = this.AGS_Form.GetChild(2).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close_base");
		component2.material = this.door.LoadMaterial();
		component2.enabled = !GUIManager.Instance.bOpenOnIPhoneX;
		component2 = this.AGS_Form.GetChild(2).GetChild(0).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close");
		component2.material = this.door.LoadMaterial();
		UIButton component3 = this.AGS_Form.GetChild(2).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_EffectType = e_EffectType.e_Scale;
		component3 = this.AGS_Form.GetChild(3).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 99;
		component3.m_EffectType = e_EffectType.e_Scale;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component4 = component3.gameObject.GetComponent<RectTransform>();
			component4.localScale = new Vector3(-1f, 1f, 1f);
			component4.anchoredPosition = new Vector2(component4.anchoredPosition.x + 44f, component4.anchoredPosition.y);
		}
		component = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AGS_RareImg = this.AGS_Form.GetChild(6).GetChild(2).GetComponent<UISpritesArray>();
		component = this.AGS_Form.GetChild(6).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AGS_ScrollPanel = this.AGS_Form.GetChild(6).GetChild(4).GetComponent<ScrollPanel>();
		component = this.AGS_Form.GetChild(6).GetChild(5).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(6).GetChild(6).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7438u);
		component3 = this.AGS_Form.GetChild(6).GetChild(7).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 0;
		component3.m_BtnID2 = 1;
		component3.m_EffectType = e_EffectType.e_Scale;
		UILEBtn component5 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component5 = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component5 = this.AGS_Form.GetChild(7).GetChild(2).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component5 = this.AGS_Form.GetChild(7).GetChild(3).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component5 = this.AGS_Form.GetChild(7).GetChild(4).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component5 = this.AGS_Form.GetChild(7).GetChild(5).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component3 = this.AGS_Form.GetChild(7).GetChild(7).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 0;
		component3.m_BtnID2 = 2;
		component3.m_EffectType = e_EffectType.e_Scale;
		this.SelectLight = this.AGS_Form.GetChild(7).GetChild(6).GetComponent<Image>();
		component5 = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component5.transition = Selectable.Transition.None;
		this.ForgeLight = this.AGS_Form.GetChild(8).GetChild(2).GetComponent<Image>();
		this.BigForgeLight = this.AGS_Form.GetChild(8).GetChild(4).GetComponent<RectTransform>();
		this.SmallForgeLight = this.AGS_Form.GetChild(8).GetChild(3).GetComponent<Image>();
		component = this.AGS_Form.GetChild(8).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(9).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(9).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(261u);
		component = this.AGS_Form.GetChild(9).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component3 = this.AGS_Form.GetChild(9).GetChild(5).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 3;
		component3.m_BtnID2 = 2;
		component3.m_EffectType = e_EffectType.e_Scale;
		component3 = this.AGS_Form.GetChild(9).GetChild(6).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 3;
		component3.m_BtnID2 = 1;
		component3.m_EffectType = e_EffectType.e_Scale;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component6 = component3.transform.GetComponent<RectTransform>();
			component6.localScale = new Vector3(-1f, 1f, 1f);
		}
		component5 = this.AGS_Form.GetChild(10).GetChild(0).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component5 = this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component = this.AGS_Form.GetChild(10).GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component5 = this.AGS_Form.GetChild(10).GetChild(2).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component = this.AGS_Form.GetChild(10).GetChild(2).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component5 = this.AGS_Form.GetChild(10).GetChild(3).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component = this.AGS_Form.GetChild(10).GetChild(3).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component5 = this.AGS_Form.GetChild(10).GetChild(4).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component = this.AGS_Form.GetChild(10).GetChild(4).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component3 = this.AGS_Form.GetChild(10).GetChild(10).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_EffectType = e_EffectType.e_Scale;
		component3.m_BtnID1 = 7;
		component = this.AGS_Form.GetChild(10).GetChild(10).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component2 = this.AGS_Form.GetChild(10).GetChild(10).GetChild(2).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_con_icon_05");
		component2.material = this.door.LoadMaterial();
		component2.SetNativeSize();
		component2.gameObject.SetActive(true);
		for (int l = 0; l < 5; l++)
		{
			this.ItemLight[l] = this.AGS_Form.GetChild(10).GetChild(5 + l).GetComponent<Image>();
		}
		component3 = this.AGS_Form.GetChild(11).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 1;
		component3.m_BtnID2 = 2;
		component3.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(11).GetChild(0).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(11).GetChild(0).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7439u);
		component3 = this.AGS_Form.GetChild(11).GetChild(1).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 1;
		component3.m_BtnID2 = 1;
		component3.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(11).GetChild(1).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7440u);
		component = this.AGS_Form.GetChild(11).GetChild(1).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component3 = this.AGS_Form.GetChild(12).GetComponent<UIButton>();
		UnityEngine.Object.Destroy(component3);
		HelperUIButton helperUIButton = this.AGS_Form.GetChild(12).gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID1 = 4;
		IgnoreRaycast component7 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(0).GetComponent<IgnoreRaycast>();
		UnityEngine.Object.Destroy(component7);
		this.Flash = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(3).GetComponent<Image>();
		this.LightBox1 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(0).GetComponent<Image>();
		this.LightBox2 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(1).GetComponent<Image>();
		this.MaterialLight = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetComponent<Image>();
		this.arrowPos = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(2).GetComponent<RectTransform>();
		component3 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(1).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 4;
		component3.m_EffectType = e_EffectType.e_Scale;
		component2 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(1).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close");
		component2.material = this.door.LoadMaterial();
		component5 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(2).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component5.transition = Selectable.Transition.None;
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component5 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(2).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component3.m_BtnID1 = 4;
		component3.m_BtnID2 = 1;
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(2).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component5 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(3).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component3.m_BtnID1 = 4;
		component3.m_BtnID2 = 2;
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(3).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component5 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(4).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component3.m_BtnID1 = 4;
		component3.m_BtnID2 = 3;
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(4).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component5 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(5).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component3.m_BtnID1 = 4;
		component3.m_BtnID2 = 4;
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(5).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component5 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(6).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component3.m_BtnID1 = 4;
		component3.m_BtnID2 = 5;
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(6).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component3 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 5;
		component3.m_BtnID2 = 2;
		component3.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component3 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 5;
		component3.m_BtnID2 = 1;
		component3.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(10).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component3 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 6;
		component3.m_BtnID2 = 1;
		component3 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(4).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 6;
		component3.m_BtnID2 = 2;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			RectTransform component8 = this.AGS_Form.GetChild(12).GetComponent<RectTransform>();
			component8.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			component8.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		component2 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(8).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_redbox_01");
		component2.material = this.door.LoadMaterial();
		component2.type = Image.Type.Sliced;
		component2 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(8).GetChild(0).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_mess_ex");
		component2.material = this.door.LoadMaterial();
		this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(8).gameObject.SetActive(false);
		this.DM.mLordEquip.LoadLordEquip(true);
		this.AGS_Form.GetChild(6).gameObject.SetActive(true);
		this.AGS_Form.GetChild(12).gameObject.SetActive(false);
		this.POPLight1 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(1).GetComponent<Image>();
		this.POPLight3 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(5).GetComponent<Image>();
		this.LightBox1.color = new Color(1f, 1f, 1f, 0f);
		this.LightBox2.color = new Color(1f, 1f, 1f, 0f);
		this.Flash.color = new Color(1f, 1f, 1f, 0f);
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		switch (UIAnvil.OpenKind)
		{
		case eUI_Anvil_OpenKind.ForgeNewItem:
		case eUI_Anvil_OpenKind.NowForging:
			component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7430u);
			component = this.AGS_Form.GetChild(11).GetChild(0).GetChild(3).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7439u);
			component = this.AGS_Form.GetChild(11).GetChild(1).GetChild(1).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7440u);
			break;
		case eUI_Anvil_OpenKind.UpgradeItem:
			component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7537u);
			component = this.AGS_Form.GetChild(11).GetChild(0).GetChild(3).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7535u);
			component = this.AGS_Form.GetChild(11).GetChild(1).GetChild(1).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7475u);
			break;
		}
	}

	// Token: 0x060018EC RID: 6380 RVA: 0x0029CAF0 File Offset: 0x0029ACF0
	public override void OnClose()
	{
		UIAnvil.returnColor = 0;
		UIAnvil.returnID = 0;
		StringManager.Instance.DeSpawnString(this.ItemNameText);
		StringManager.Instance.DeSpawnString(this.ItemLevelText);
		StringManager.Instance.DeSpawnString(this.goldCost);
		StringManager.Instance.DeSpawnString(this.moneyCost);
		StringManager.Instance.DeSpawnString(this.timeCost);
		StringManager.Instance.DeSpawnString(this.timeRemain);
		StringManager.Instance.DeSpawnString(this.focusName);
		StringManager.Instance.DeSpawnString(this.forgingItemName);
		StringManager.Instance.DeSpawnString(this.PopString);
		StringManager.Instance.DeSpawnString(this.PopUpHeaderText);
		for (int i = 0; i < this.RequestCount.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.RequestCount[i]);
		}
		for (int j = 0; j < this.EffDescText.Length; j++)
		{
			StringManager.Instance.DeSpawnString(this.EffDescText[j]);
		}
		for (int k = 0; k < this.CombineCount.Length; k++)
		{
			StringManager.Instance.DeSpawnString(this.CombineCount[k]);
		}
	}

	// Token: 0x060018ED RID: 6381 RVA: 0x0029CC38 File Offset: 0x0029AE38
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond)
		{
			this.SetForgingTimeBar();
			this.ShowMoney();
		}
	}

	// Token: 0x060018EE RID: 6382 RVA: 0x0029CC4C File Offset: 0x0029AE4C
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			this.SetPopUp(this.currentColor);
			this.MaterialFlash = true;
			break;
		case 2:
			UIAnvil.OpenKind = eUI_Anvil_OpenKind.NowForging;
			this.SetOpenKind(UIAnvil.OpenKind);
			this.SetView(this.DM.RoleAttr.LordEquipEventData.ItemID, this.DM.RoleAttr.LordEquipEventData.Color);
			this.StartForge(true);
			break;
		case 3:
			if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.NowForging)
			{
				if (arg2 >= 0)
				{
					UIAnvil.OpenKind = eUI_Anvil_OpenKind.UpgradeItem;
					UIAnvil.preSetIndex = (ushort)arg2;
					UIAnvil.preSetID = this.DM.mLordEquip.LordEquip[(int)UIAnvil.preSetIndex].ItemID;
					this.preSetColor = this.DM.mLordEquip.LordEquip[(int)UIAnvil.preSetIndex].Color;
					this.preSetColor += 1;
					this.currentColor = this.preSetColor;
				}
				else
				{
					UIAnvil.OpenKind = eUI_Anvil_OpenKind.ForgeNewItem;
					this.currentColor = 1;
				}
			}
			if (!this.isLoading)
			{
				this.SetOpenKind(UIAnvil.OpenKind);
				this.SetView(UIAnvil.preSetID, this.currentColor);
				this.SetSideItem();
			}
			this.StartForge(false);
			break;
		case 5:
			if (arg2 >= 0)
			{
				UIAnvil.OpenKind = eUI_Anvil_OpenKind.UpgradeItem;
				UIAnvil.preSetIndex = (ushort)arg2;
				UIAnvil.preSetID = this.DM.mLordEquip.LordEquip[(int)UIAnvil.preSetIndex].ItemID;
				this.preSetColor = this.DM.mLordEquip.LordEquip[(int)UIAnvil.preSetIndex].Color;
				this.preSetColor += 1;
				this.currentColor = this.preSetColor;
			}
			else
			{
				UIAnvil.OpenKind = eUI_Anvil_OpenKind.ForgeNewItem;
			}
			this.SetOpenKind(UIAnvil.OpenKind);
			this.SetView(UIAnvil.preSetID, this.currentColor);
			this.SetSideItem();
			this.StartForge(true);
			this.ForgeStop = true;
			break;
		}
	}

	// Token: 0x060018EF RID: 6383 RVA: 0x0029CE68 File Offset: 0x0029B068
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
		}
		else
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x060018F0 RID: 6384 RVA: 0x0029CEAC File Offset: 0x0029B0AC
	public void Refresh_FontTexture()
	{
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(6).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(8).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(9).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(9).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(9).GetChild(4).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(10).GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(10).GetChild(2).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(10).GetChild(3).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(10).GetChild(4).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(10).GetChild(10).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(11).GetChild(0).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(11).GetChild(0).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(11).GetChild(1).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(11).GetChild(1).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(4).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(2).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(3).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(4).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(5).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(6).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(10).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		if (this.AGS_ScrollPanel != null && this.AGS_ScrollPanel.gameObject.activeInHierarchy && this.AGS_ScrollPanel.transform.childCount > 1)
		{
			Transform child = this.AGS_ScrollPanel.transform.GetChild(0);
			for (int i = 0; i < child.childCount; i++)
			{
				Transform child2 = child.GetChild(i);
				if (child2 != null && child2.gameObject.activeInHierarchy && child2.childCount > 1)
				{
					component = child2.GetChild(0).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
				}
			}
		}
	}

	// Token: 0x060018F1 RID: 6385 RVA: 0x0029D714 File Offset: 0x0029B914
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			switch (arg1)
			{
			case 1:
			{
				uint serial = 0u;
				if (this.currentColor > 1)
				{
					serial = this.DM.mLordEquip.LordEquip[(int)UIAnvil.preSetIndex].SerialNO;
				}
				this.DM.mLordEquip.CombineEquip(UIAnvil.preSetID, serial);
				break;
			}
			case 2:
			{
				uint num = 0u;
				if (this.currentColor > 1)
				{
					num = this.DM.mLordEquip.LordEquip[(int)UIAnvil.preSetIndex].SerialNO;
				}
				if (!GUIManager.Instance.OpenCheckCrystal(this.NeedDiamon, 6, (int)UIAnvil.preSetID, (int)num))
				{
					this.DM.mLordEquip.QuickCombine(UIAnvil.preSetID, num);
				}
				break;
			}
			case 3:
				MallManager.Instance.Send_Mall_Info();
				break;
			case 4:
			{
				ushort num2 = LordEquipData.getItemQuantity(this.SelectMatID, this.SelectMatColor - 1);
				if (num2 < 4)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7455u), 255, true);
					return;
				}
				num2 /= 4;
				this.DM.mLordEquip.upgradeMaterial(this.SelectMatID, this.SelectMatColor, num2);
				break;
			}
			case 5:
				LordEquipData.CancelCombine();
				break;
			}
		}
	}

	// Token: 0x060018F2 RID: 6386 RVA: 0x0029D87C File Offset: 0x0029BA7C
	private void AfterLoader()
	{
		this.isLoading = this.DM.mLordEquip.LoadLEMaterial(false);
		if (this.isLoading)
		{
			return;
		}
		UILEBtn component = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UILEBtn>();
		GUIManager.Instance.InitLordEquipImg(component.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		for (int i = 0; i < 6; i++)
		{
			component = this.AGS_Form.GetChild(7).GetChild(0 + i).GetComponent<UILEBtn>();
			GUIManager.Instance.InitLordEquipImg(component.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, true, true, 0, 0, 0, 0, 0, false);
			component.m_Handler = this;
		}
		for (int j = 0; j < 5; j++)
		{
			component = this.AGS_Form.GetChild(10).GetChild(0 + j).GetComponent<UILEBtn>();
			GUIManager.Instance.InitLordEquipImg(component.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, true, true, 0, 0, 0, 0, 0, false);
			component.m_Handler = this;
		}
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(2).GetComponent<UILEBtn>();
		GUIManager.Instance.InitLordEquipImg(component.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		component.m_Handler = this;
		for (int k = 0; k < 5; k++)
		{
			component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(2 + k).GetComponent<UILEBtn>();
			GUIManager.Instance.InitLordEquipImg(component.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, true, true, 0, 0, 0, 0, 0, false);
			component.m_Handler = this;
		}
		this.AGS_ScrollPanel.IntiScrollPanel(274f, 0f, 0f, this.SPHeight, 6, this);
		this.SetOpenKind(UIAnvil.OpenKind);
		switch (UIAnvil.OpenKind)
		{
		case eUI_Anvil_OpenKind.ForgeNewItem:
			if (UIAnvil.returnColor == 0)
			{
				this.currentColor = this.preSetColor;
				this.SetView(UIAnvil.preSetID, this.currentColor);
			}
			else
			{
				this.currentColor = UIAnvil.returnColor;
				UIAnvil.preSetID = UIAnvil.returnID;
				this.SetView(UIAnvil.returnID, this.currentColor);
			}
			this.SetSideItem();
			break;
		case eUI_Anvil_OpenKind.UpgradeItem:
			UIAnvil.preSetID = this.DM.mLordEquip.LordEquip[(int)UIAnvil.preSetIndex].ItemID;
			this.preSetColor = this.DM.mLordEquip.LordEquip[(int)UIAnvil.preSetIndex].Color + 1;
			this.currentColor = this.preSetColor;
			this.SetView(UIAnvil.preSetID, this.preSetColor);
			this.SetSideItem();
			break;
		case eUI_Anvil_OpenKind.NowForging:
			UIAnvil.preSetID = this.DM.RoleAttr.LordEquipEventData.ItemID;
			this.preSetColor = this.DM.RoleAttr.LordEquipEventData.Color;
			this.currentColor = this.DM.RoleAttr.LordEquipEventData.Color;
			if (UIAnvil.preSetID == 0)
			{
				this.door.CloseMenu(false);
			}
			if (this.DM.RoleAttr.LordEquipEventData.SerialNO != 0u && this.DM.mLordEquip.LordEquip[(int)UIAnvil.preSetIndex].SerialNO != this.DM.RoleAttr.LordEquipEventData.SerialNO)
			{
				for (ushort num = 0; num < (ushort)this.DM.RoleAttr.LordEquipBagSize; num += 1)
				{
					if (this.DM.mLordEquip.LordEquip[(int)num].SerialNO == this.DM.RoleAttr.LordEquipEventData.SerialNO)
					{
						UIAnvil.preSetIndex = num;
					}
				}
			}
			this.SetView(this.DM.RoleAttr.LordEquipEventData.ItemID, this.DM.RoleAttr.LordEquipEventData.Color);
			this.SetSideItem();
			this.StartForge(true);
			break;
		}
	}

	// Token: 0x060018F3 RID: 6387 RVA: 0x0029DC9C File Offset: 0x0029BE9C
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		switch (btnID)
		{
		case 0:
			switch (sender.m_BtnID2)
			{
			case 0:
				this.door.CloseMenu(false);
				break;
			case 1:
				LordEquipData.OpenItemSource(UIAnvil.preSetID);
				UIAnvil.returnColor = this.currentColor;
				UIAnvil.returnID = UIAnvil.preSetID;
				break;
			case 2:
				this.SetView(UIAnvil.preSetID, this.currentColor);
				break;
			}
			break;
		case 1:
		{
			uint serial = 0u;
			if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.ForgeNewItem && this.currentColor > 1)
			{
				int firstIndex = this.GetFirstIndex(UIAnvil.preSetID, this.currentColor - 1);
				if (firstIndex < 0)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7443u), 255, true);
					return;
				}
				UIAnvil.preSetIndex = (ushort)firstIndex;
			}
			if (this.currentColor > 1)
			{
				serial = this.DM.mLordEquip.LordEquip[(int)UIAnvil.preSetIndex].SerialNO;
			}
			int btnID2 = sender.m_BtnID2;
			if (btnID2 != 1)
			{
				if (btnID2 == 2)
				{
					if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.UpgradeItem && this.currentColor != this.preSetColor)
					{
						GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7536u), 255, true);
						return;
					}
					if (this.isCombineReady((int)UIAnvil.preSetIndex, UIAnvil.preSetID, this.currentColor, true, true))
					{
						this.PopString.ClearString();
						this.PopString.StringToFormat(this.moneyCost);
						if (this.DM.mLordEquip.isRoleEquipThis(serial))
						{
							this.PopString.AppendFormat(this.DM.mStringTable.GetStringByID(7500u));
							GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(7502u), this.PopString.ToString(), 2, 0, null, null);
						}
						else
						{
							this.PopString.AppendFormat(this.DM.mStringTable.GetStringByID(7499u));
							GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(7502u), this.PopString.ToString(), 2, 0, null, null);
						}
					}
				}
			}
			else
			{
				if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.UpgradeItem && this.currentColor != this.preSetColor)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7536u), 255, true);
					return;
				}
				if (this.isCombineReady((int)UIAnvil.preSetIndex, UIAnvil.preSetID, this.currentColor, false, true))
				{
					if (this.DM.mLordEquip.isRoleEquipThis(serial))
					{
						GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(7475u), this.DM.mStringTable.GetStringByID(7498u), 1, 0, null, null);
					}
					else
					{
						this.DM.mLordEquip.CombineEquip(UIAnvil.preSetID, serial);
					}
				}
			}
			break;
		}
		case 2:
		{
			int btnID2 = sender.m_BtnID2;
			if (btnID2 != 1)
			{
				if (btnID2 == 2)
				{
					GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(7450u), this.DM.mStringTable.GetStringByID(7452u), 4, 0, null, null);
				}
			}
			else
			{
				ushort itemQuantity = LordEquipData.getItemQuantity(this.SelectMatID, this.SelectMatColor - 1);
				if (itemQuantity < 4)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7455u), 255, true);
					return;
				}
				this.DM.mLordEquip.upgradeMaterial(this.SelectMatID, this.SelectMatColor, 1);
			}
			break;
		}
		case 3:
		{
			int btnID2 = sender.m_BtnID2;
			if (btnID2 != 1)
			{
				if (btnID2 == 2)
				{
					GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(7514u), this.DM.mStringTable.GetStringByID(7513u), 5, 0, null, null);
				}
			}
			else
			{
				this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 18, false);
				UIAnvil.returnColor = this.currentColor;
				UIAnvil.returnID = UIAnvil.preSetID;
			}
			break;
		}
		case 4:
			this.AGS_Form.GetChild(12).gameObject.SetActive(false);
			this.SetView(UIAnvil.preSetID, this.currentColor);
			break;
		case 5:
		{
			int btnID2 = sender.m_BtnID2;
			if (btnID2 != 1)
			{
				if (btnID2 == 2)
				{
					if (this.isCombine)
					{
						int num = (int)LordEquipData.getItemQuantity(this.SelectMatID, this.SelectMatColor - 1);
						if (num < 4)
						{
							GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455u), 255, true);
							return;
						}
						num = (int)((ushort)(num / 4));
						if ((int)this.MaterCount[(int)(this.SelectMatColor - 1)] + num > 65535)
						{
							num = (int)(ushort.MaxValue - this.MaterCount[(int)(this.SelectMatColor - 1)]);
							if (num < 1)
							{
								GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7524u), 255, true);
								return;
							}
						}
						this.DM.mLordEquip.upgradeMaterial(this.SelectMatID, this.SelectMatColor, (ushort)num);
					}
					else
					{
						int num = (int)LordEquipData.getItemQuantity(this.SelectMatID, this.SelectMatColor + 1);
						if (num < 1)
						{
							GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455u), 255, true);
							return;
						}
						if ((int)this.MaterCount[(int)(this.SelectMatColor - 1)] + num * 4 > 65535)
						{
							num = (int)((ushort.MaxValue - this.MaterCount[(int)(this.SelectMatColor - 1)]) / 4);
							if (num < 1)
							{
								GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7509u), 255, true);
								return;
							}
						}
						this.DM.mLordEquip.DeComposeMaterial(this.SelectMatID, this.SelectMatColor + 1, (ushort)num);
					}
				}
			}
			else if (this.isCombine)
			{
				int num = (int)LordEquipData.getItemQuantity(this.SelectMatID, this.SelectMatColor - 1);
				if (num < 4)
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455u), 255, true);
					return;
				}
				if (this.MaterCount[(int)(this.SelectMatColor - 1)] + 1 > 65535)
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7524u), 255, true);
					return;
				}
				this.DM.mLordEquip.upgradeMaterial(this.SelectMatID, this.SelectMatColor, 1);
			}
			else
			{
				int num = (int)LordEquipData.getItemQuantity(this.SelectMatID, this.SelectMatColor + 1);
				if (num < 1)
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455u), 255, true);
					return;
				}
				if (this.MaterCount[(int)(this.SelectMatColor - 1)] + 4 > 65535)
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7509u), 255, true);
					return;
				}
				this.DM.mLordEquip.DeComposeMaterial(this.SelectMatID, this.SelectMatColor + 1, 1);
			}
			break;
		}
		case 6:
		{
			int btnID2 = sender.m_BtnID2;
			if (btnID2 != 1)
			{
				if (btnID2 == 2)
				{
					this.isCombine = false;
					this.SetPopUp(this.SelectMatColor);
				}
			}
			else
			{
				this.isCombine = true;
				this.SetPopUp(this.SelectMatColor);
			}
			break;
		}
		case 7:
		{
			Equip recordByKey = this.DM.EquipTable.GetRecordByKey(UIAnvil.preSetID);
			uint num2 = Math.Max(100u, 10000u - this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_CRIFTING_COST_MONEY_REDUCTION));
			uint arg = (uint)Math.Ceiling(recordByKey.MixPrice * this.DM.mLordEquip.forgeGold[(int)this.currentColor] * num2 / 10000.0);
			this.door.OpenMenu(EGUIWindow.UI_BagFilter, 589825, (int)arg, false);
			UIAnvil.returnColor = this.currentColor;
			UIAnvil.returnID = UIAnvil.preSetID;
			break;
		}
		default:
			if (btnID == 99)
			{
				GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7430u), DataManager.Instance.mStringTable.GetStringByID(7527u), null, null, 0, 0, true, false);
			}
			break;
		}
	}

	// Token: 0x060018F4 RID: 6388 RVA: 0x0029E5D8 File Offset: 0x0029C7D8
	public void OnLEButtonClick(UILEBtn sender)
	{
		if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.NowForging)
		{
			return;
		}
		switch (sender.m_BtnID1)
		{
		case 1:
			this.SelectMatColor = (byte)sender.m_BtnID4;
			this.SetView((ushort)sender.m_BtnID3, (byte)sender.m_BtnID4);
			break;
		case 2:
			this.isCombine = true;
			this.SelectMatID = (ushort)sender.m_BtnID3;
			this.SelectMatColor = (byte)sender.m_BtnID4;
			this.SelectMatReqNum = (ushort)sender.m_BtnID2;
			this.popBackColor = (byte)sender.m_BtnID4;
			this.SetPopUp((byte)sender.m_BtnID4);
			break;
		case 3:
			UILordEquip.itemIDFilter = (ushort)sender.m_BtnID3;
			UILordEquip.itemColorFilter = (ushort)sender.m_BtnID4;
			this.door.OpenMenu(EGUIWindow.UI_LordEquip, 2, 0, false);
			UIAnvil.returnColor = this.currentColor;
			UIAnvil.returnID = UIAnvil.preSetID;
			break;
		case 4:
			this.SelectMatColor = (byte)sender.m_BtnID4;
			this.SetPopUp((byte)sender.m_BtnID4);
			break;
		}
	}

	// Token: 0x060018F5 RID: 6389 RVA: 0x0029E6EC File Offset: 0x0029C8EC
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		Effect recordByKey = this.DM.EffectData.GetRecordByKey(this.effectList[dataIdx].EffectID);
		UIText component = item.transform.GetChild(0).GetComponent<UIText>();
		this.EffDescText[panelObjectIdx].ClearString();
		this.EffDescText[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.InfoID));
		this.EffDescText[panelObjectIdx].StringToFormat("<color=#35F76CFF>+");
		if (recordByKey.ValueID == 0)
		{
			this.EffDescText[panelObjectIdx].IntToFormat((long)this.effectList[dataIdx].EffectValue, 1, false);
			this.EffDescText[panelObjectIdx].AppendFormat("<color=#FFEC87FF>{0}</color> {1}{2}</color>");
		}
		else
		{
			float f = (float)this.effectList[dataIdx].EffectValue / 100f;
			this.EffDescText[panelObjectIdx].FloatToFormat(f, 2, false);
			this.EffDescText[panelObjectIdx].AppendFormat("<color=#FFEC87FF>{0}</color> {1}{2}%</color>");
		}
		component.text = this.EffDescText[panelObjectIdx].ToString();
		if (!GameConstants.IsBigStyle())
		{
			component.resizeTextMaxSize = 16;
		}
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
	}

	// Token: 0x060018F6 RID: 6390 RVA: 0x0029E82C File Offset: 0x0029CA2C
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x060018F7 RID: 6391 RVA: 0x0029E830 File Offset: 0x0029CA30
	public void SetView(ushort ItemID, byte color)
	{
		bool flag = false;
		Equip recordByKey = this.DM.EquipTable.GetRecordByKey(ItemID);
		if (color > 5)
		{
			if (recordByKey.NewGemEffect[0] > 0 && this.OpenOrange)
			{
				if (color > 6)
				{
					color = 6;
					flag = true;
				}
			}
			else
			{
				color = 5;
				flag = true;
			}
		}
		UILEBtn component = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UILEBtn>();
		GUIManager.Instance.ChangeLordEquipImg(component.transform, ItemID, color, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
		UIText component2 = this.AGS_Form.GetChild(8).GetChild(1).GetComponent<UIText>();
		this.focusName.ClearString();
		GameConstants.GetColoredLordEquipString(this.focusName, ref recordByKey, color);
		component2.text = this.focusName.ToString();
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		this.currentColor = color;
		if (flag)
		{
			this.AGS_Form.GetChild(10).gameObject.SetActive(false);
			this.AGS_Form.GetChild(11).gameObject.SetActive(false);
			this.AGS_Form.GetChild(9).gameObject.SetActive(true);
			this.AGS_Form.GetChild(7).gameObject.SetActive(false);
			this.AGS_Form.GetChild(9).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7477u);
			for (int i = 1; i < this.AGS_Form.GetChild(9).childCount; i++)
			{
				this.AGS_Form.GetChild(9).gameObject.SetActive(false);
			}
			return;
		}
		if (recordByKey.EquipKind != 20)
		{
			this.SetSideItem();
			if (this.DM.RoleAttr.LordEquipEventData.ItemID != 0)
			{
				this.AGS_Form.GetChild(10).gameObject.SetActive(true);
				this.AGS_Form.GetChild(11).gameObject.SetActive(false);
				this.AGS_Form.GetChild(9).gameObject.SetActive(true);
				this.SetForgingTimeBar();
			}
			else
			{
				this.AGS_Form.GetChild(10).gameObject.SetActive(true);
				this.AGS_Form.GetChild(11).gameObject.SetActive(true);
				this.AGS_Form.GetChild(9).gameObject.SetActive(false);
			}
			this.AGS_Form.GetChild(7).gameObject.SetActive(UIAnvil.OpenKind != eUI_Anvil_OpenKind.NowForging);
			if (GameConstants.IsBetween((int)color, 1, 5))
			{
				for (int j = 0; j < 4; j++)
				{
					component = this.AGS_Form.GetChild(10).GetChild(0 + j).GetComponent<UILEBtn>();
					if (recordByKey.SyntheticParts[j].SyntheticItem == 0)
					{
						component.gameObject.SetActive(false);
						GUIManager.Instance.ChangeLordEquipImg(component.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
						component.m_BtnID1 = 0;
						component2 = component.transform.GetChild(0).GetComponent<UIText>();
						component2.text = string.Empty;
						this.AGS_Form.GetChild(10).GetChild(5 + j).gameObject.SetActive(false);
					}
					else
					{
						component.gameObject.SetActive(true);
						GUIManager.Instance.ChangeLordEquipImg(component.transform, recordByKey.SyntheticParts[j].SyntheticItem, color, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
						component.m_BtnID1 = 2;
						component.m_BtnID2 = (int)recordByKey.SyntheticParts[j].SyntheticItemNum;
						component.m_BtnID3 = (int)recordByKey.SyntheticParts[j].SyntheticItem;
						component.m_BtnID4 = (int)color;
						component2 = component.transform.GetChild(0).GetComponent<UIText>();
						this.RequestCount[j].ClearString();
						ushort itemQuantity = LordEquipData.getItemQuantity(recordByKey.SyntheticParts[j].SyntheticItem, color);
						if (UIAnvil.OpenKind != eUI_Anvil_OpenKind.NowForging)
						{
							if (itemQuantity < (ushort)recordByKey.SyntheticParts[j].SyntheticItemNum)
							{
								this.RequestCount[j].StringToFormat("<color=#FF5581FF>");
								if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.UpgradeItem && color != this.preSetColor)
								{
									this.AGS_Form.GetChild(10).GetChild(5 + j).gameObject.SetActive(false);
								}
								else
								{
									this.AGS_Form.GetChild(10).GetChild(5 + j).gameObject.SetActive(true);
								}
							}
							else
							{
								this.RequestCount[j].StringToFormat("<color=#FFFFFFFF>");
								this.AGS_Form.GetChild(10).GetChild(5 + j).gameObject.SetActive(false);
							}
							this.RequestCount[j].IntToFormat((long)itemQuantity, 1, true);
							this.RequestCount[j].IntToFormat((long)recordByKey.SyntheticParts[j].SyntheticItemNum, 1, false);
							if (!GUIManager.Instance.IsArabic)
							{
								this.RequestCount[j].AppendFormat("{0}{1}</color> / {2}");
							}
							else
							{
								this.RequestCount[j].AppendFormat("{2} / {0}{1}</color>");
							}
							component2.text = this.RequestCount[j].ToString();
							component.GetComponent<uButtonScale>().enabled = true;
						}
						else
						{
							this.AGS_Form.GetChild(10).GetChild(5 + j).gameObject.SetActive(false);
							component2.text = string.Empty;
							component.GetComponent<uButtonScale>().enabled = false;
						}
						component2.SetAllDirty();
						component2.cachedTextGenerator.Invalidate();
					}
				}
			}
			else if (color == 6)
			{
				LordEquipExtendData recordByKey2 = DataManager.Instance.LordEquipExtendTable.GetRecordByKey(recordByKey.NewGemEffect[0]);
				if (recordByKey.NewGemEffect[0] == recordByKey2.ID)
				{
					for (int k = 0; k < 4; k++)
					{
						component = this.AGS_Form.GetChild(10).GetChild(0 + k).GetComponent<UILEBtn>();
						if (recordByKey2.SyntheticParts[k].ItemId == 0)
						{
							component.gameObject.SetActive(false);
							GUIManager.Instance.ChangeLordEquipImg(component.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
							component.m_BtnID1 = 0;
							component2 = component.transform.GetChild(0).GetComponent<UIText>();
							component2.text = string.Empty;
							this.AGS_Form.GetChild(10).GetChild(5 + k).gameObject.SetActive(false);
						}
						else
						{
							component.gameObject.SetActive(true);
							GUIManager.Instance.ChangeLordEquipImg(component.transform, recordByKey2.SyntheticParts[k].ItemId, recordByKey2.SyntheticParts[k].Color, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
							component.m_BtnID1 = 2;
							component.m_BtnID2 = (int)recordByKey2.SyntheticParts[k].Num;
							component.m_BtnID3 = (int)recordByKey2.SyntheticParts[k].ItemId;
							component.m_BtnID4 = (int)recordByKey2.SyntheticParts[k].Color;
							component2 = component.transform.GetChild(0).GetComponent<UIText>();
							this.RequestCount[k].ClearString();
							ushort itemQuantity2 = LordEquipData.getItemQuantity(recordByKey2.SyntheticParts[k].ItemId, recordByKey2.SyntheticParts[k].Color);
							if (UIAnvil.OpenKind != eUI_Anvil_OpenKind.NowForging)
							{
								if (itemQuantity2 < (ushort)recordByKey2.SyntheticParts[k].Num)
								{
									this.RequestCount[k].StringToFormat("<color=#FF5581FF>");
									if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.UpgradeItem && recordByKey2.SyntheticParts[k].Color != this.preSetColor)
									{
										this.AGS_Form.GetChild(10).GetChild(5 + k).gameObject.SetActive(false);
									}
									else
									{
										this.AGS_Form.GetChild(10).GetChild(5 + k).gameObject.SetActive(true);
									}
								}
								else
								{
									this.RequestCount[k].StringToFormat("<color=#FFFFFFFF>");
									this.AGS_Form.GetChild(10).GetChild(5 + k).gameObject.SetActive(false);
								}
								this.RequestCount[k].IntToFormat((long)itemQuantity2, 1, true);
								this.RequestCount[k].IntToFormat((long)recordByKey2.SyntheticParts[k].Num, 1, false);
								if (!GUIManager.Instance.IsArabic)
								{
									this.RequestCount[k].AppendFormat("{0}{1}</color> / {2}");
								}
								else
								{
									this.RequestCount[k].AppendFormat("{2} / {0}{1}</color>");
								}
								component2.text = this.RequestCount[k].ToString();
								component.GetComponent<uButtonScale>().enabled = true;
							}
							else
							{
								this.AGS_Form.GetChild(10).GetChild(5 + k).gameObject.SetActive(false);
								component2.text = string.Empty;
								component.GetComponent<uButtonScale>().enabled = false;
							}
							component2.SetAllDirty();
							component2.cachedTextGenerator.Invalidate();
						}
					}
				}
			}
			component = this.AGS_Form.GetChild(10).GetChild(4).GetComponent<UILEBtn>();
			component2 = component.transform.GetChild(0).GetComponent<UIText>();
			if ((UIAnvil.OpenKind == eUI_Anvil_OpenKind.NowForging && color > 1) || (UIAnvil.OpenKind == eUI_Anvil_OpenKind.UpgradeItem && color == this.preSetColor))
			{
				component.gameObject.SetActive(true);
				if (this.DM.mLordEquip.LordEquip[(int)UIAnvil.preSetIndex].haveGem())
				{
					GUIManager.Instance.ChangeLordEquipImg(component.transform, this.DM.mLordEquip.LordEquip[(int)UIAnvil.preSetIndex], eLordEquipDisplayKind.Item_Gems, false);
				}
				else
				{
					GUIManager.Instance.ChangeLordEquipImg(component.transform, this.DM.mLordEquip.LordEquip[(int)UIAnvil.preSetIndex], eLordEquipDisplayKind.OnlyItem, false);
				}
				component.m_BtnID1 = 0;
				component.m_BtnID3 = (int)ItemID;
				component.m_BtnID4 = (int)(color - 1);
				this.RequestCount[4].ClearString();
				this.AGS_Form.GetChild(10).GetChild(9).gameObject.SetActive(false);
				component2.text = string.Empty;
			}
			else if (color > 1)
			{
				component.gameObject.SetActive(true);
				GUIManager.Instance.ChangeLordEquipImg(component.transform, ItemID, color - 1, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				component.m_BtnID1 = 1;
				component.m_BtnID3 = (int)ItemID;
				component.m_BtnID4 = (int)(color - 1);
				this.RequestCount[4].ClearString();
				ushort itemQuantity3 = LordEquipData.getItemQuantity(ItemID, color - 1);
				if (itemQuantity3 < 1)
				{
					this.RequestCount[4].StringToFormat("<color=#FF5581FF>");
					this.AGS_Form.GetChild(10).GetChild(9).gameObject.SetActive(false);
				}
				else
				{
					this.RequestCount[4].StringToFormat("<color=#FFFFFFFF>");
					int firstIndex = this.GetFirstIndex(ItemID, color - 1);
					if (this.DM.mLordEquip.LordEquip[firstIndex].haveGem())
					{
						GUIManager.Instance.ChangeLordEquipImg(component.transform, this.DM.mLordEquip.LordEquip[firstIndex], eLordEquipDisplayKind.Item_Gems, false);
					}
					else
					{
						GUIManager.Instance.ChangeLordEquipImg(component.transform, this.DM.mLordEquip.LordEquip[firstIndex], eLordEquipDisplayKind.OnlyItem, false);
					}
					if (itemQuantity3 > 1 && UIAnvil.OpenKind != eUI_Anvil_OpenKind.UpgradeItem)
					{
						this.AGS_Form.GetChild(10).GetChild(9).gameObject.SetActive(true);
						component.m_BtnID1 = 3;
					}
					else
					{
						this.AGS_Form.GetChild(10).GetChild(9).gameObject.SetActive(false);
					}
				}
				this.RequestCount[4].IntToFormat((long)itemQuantity3, 1, true);
				if (!GUIManager.Instance.IsArabic)
				{
					this.RequestCount[4].AppendFormat("{0}{1}</color> / 1");
				}
				else
				{
					this.RequestCount[4].AppendFormat("1 / {0}{1}</color>");
				}
				component2.text = this.RequestCount[4].ToString();
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
			}
			else
			{
				component2.text = string.Empty;
				component.gameObject.SetActive(false);
				this.AGS_Form.GetChild(10).GetChild(9).gameObject.SetActive(false);
			}
			if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.NowForging)
			{
				this.AGS_Form.GetChild(10).GetChild(10).gameObject.SetActive(false);
			}
			else
			{
				this.AGS_Form.GetChild(10).GetChild(10).gameObject.SetActive(true);
			}
			this.ShowMoney();
		}
		else
		{
			this.SelectMatID = ItemID;
			this.isCombine = true;
			this.SetPopUp(color);
		}
		int num = 5;
		float num2 = -284f;
		if (recordByKey.NewGemEffect[0] > 0 && this.OpenOrange && GameConstants.IsBetween((int)recordByKey.EquipKind, 21, 26))
		{
			num = 6;
			num2 = -324f;
			this.AGS_Form.GetChild(7).GetChild(4).GetChild(0).gameObject.SetActive(true);
		}
		else
		{
			this.AGS_Form.GetChild(7).GetChild(5).gameObject.SetActive(false);
			this.AGS_Form.GetChild(7).GetChild(4).GetChild(0).gameObject.SetActive(false);
		}
		for (int l = 0; l < num; l++)
		{
			component = this.AGS_Form.GetChild(7).GetChild(0 + l).GetComponent<UILEBtn>();
			eUI_Anvil_OpenKind openKind = UIAnvil.OpenKind;
			if (openKind != eUI_Anvil_OpenKind.ForgeNewItem)
			{
				if (openKind == eUI_Anvil_OpenKind.UpgradeItem)
				{
					if (l + 1 < (int)this.preSetColor)
					{
						component.gameObject.SetActive(false);
						component.m_BtnID1 = 0;
					}
					else
					{
						component.gameObject.SetActive(true);
						GUIManager.Instance.ChangeLordEquipImg(component.transform, UIAnvil.preSetID, (byte)(l + 1), eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
						component.m_BtnID1 = 1;
						component.m_BtnID3 = (int)UIAnvil.preSetID;
						component.m_BtnID4 = l + 1;
						component.GetComponent<RectTransform>().anchoredPosition = new Vector2(num2 + (float)(l * 85), 160f);
					}
				}
			}
			else if (recordByKey.EquipKind == 20 && l + 1 < (int)color)
			{
				component.gameObject.SetActive(false);
				component.m_BtnID1 = 0;
			}
			else
			{
				component.gameObject.SetActive(true);
				GUIManager.Instance.ChangeLordEquipImg(component.transform, UIAnvil.preSetID, (byte)(l + 1), eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				component.m_BtnID1 = 1;
				component.m_BtnID3 = (int)UIAnvil.preSetID;
				component.m_BtnID4 = l + 1;
				component.GetComponent<RectTransform>().anchoredPosition = new Vector2(num2 + (float)(l * 85), 160f);
			}
		}
		if (recordByKey.EquipKind == 20)
		{
			this.AGS_Form.GetChild(7).GetChild(7).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(7).GetChild((int)(0 + color - 2)).GetComponent<UILEBtn>();
			component.gameObject.SetActive(true);
			GUIManager.Instance.ChangeLordEquipImg(component.transform, ItemID, color, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
			component.m_BtnID1 = 1;
			component.m_BtnID3 = (int)ItemID;
			component.m_BtnID4 = (int)color;
			RectTransform component3 = this.AGS_Form.GetChild(7).GetChild(6).GetComponent<RectTransform>();
			Vector2 anchoredPosition = component.transform.GetComponent<RectTransform>().anchoredPosition;
			component3.anchoredPosition = anchoredPosition;
		}
		else
		{
			this.AGS_Form.GetChild(7).GetChild(7).gameObject.SetActive(false);
			RectTransform component4 = this.AGS_Form.GetChild(7).GetChild(6).GetComponent<RectTransform>();
			Vector2 anchoredPosition2 = this.AGS_Form.GetChild(7).GetChild((int)(0 + color - 1)).GetComponent<RectTransform>().anchoredPosition;
			component4.anchoredPosition = anchoredPosition2;
		}
	}

	// Token: 0x060018F8 RID: 6392 RVA: 0x0029F8D4 File Offset: 0x0029DAD4
	public void SetPopUp(byte color)
	{
		this.SetPopupFunction(this.isCombine);
		this.GetMaterialRareCount(this.SelectMatID);
		if (this.isCombine)
		{
			if (!GameConstants.IsBetween((int)this.SelectMatColor, 2, 5))
			{
				this.SelectMatColor = 2;
			}
		}
		else if (!GameConstants.IsBetween((int)this.SelectMatColor, 1, 4))
		{
			this.SelectMatColor = 4;
		}
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(this.SelectMatID);
		RectTransform component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(2).GetComponent<RectTransform>();
		GUIManager.Instance.ChangeLordEquipImg(component, this.SelectMatID, this.popBackColor, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
		UIText component2 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(10).GetComponent<UIText>();
		component2.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.EquipInfo);
		component2 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(4).GetComponent<UIText>();
		this.PopUpHeaderText.ClearString();
		GameConstants.GetColoredLordEquipString(this.PopUpHeaderText, ref recordByKey, this.popBackColor);
		component2.text = this.PopUpHeaderText.ToString();
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		if (GameConstants.IsBetween((int)this.popBackColor, 0, 6))
		{
			this.AGS_Form.GetChild(12).GetChild(0).GetChild(5).GetComponent<UISpritesArray>().SetSpriteIndex((int)(this.popBackColor - 1));
		}
		if (this.isCombine)
		{
			for (int i = 0; i < 5; i++)
			{
				UILEBtn component3 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(2 + i).GetComponent<UILEBtn>();
				component2 = component3.transform.GetChild(0).GetComponent<UIText>();
				component3.gameObject.SetActive(true);
				GUIManager.Instance.ChangeLordEquipImg(component3.transform, this.SelectMatID, (byte)(i + 1), eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				component3.m_BtnID1 = 4;
				component3.m_BtnID3 = (int)this.SelectMatID;
				component3.m_BtnID4 = i + 1;
				this.CombineCount[i].ClearString();
				if (i + 2 != (int)this.SelectMatColor)
				{
					this.CombineCount[i].IntToFormat((long)this.MaterCount[i], 1, true);
					this.CombineCount[i].AppendFormat("{0:N}");
				}
				else
				{
					UIText component4 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetChild(0).GetComponent<UIText>();
					component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetComponent<RectTransform>();
					ushort num = this.MaterCount[i];
					if (num < 4)
					{
						this.CombineCount[i].StringToFormat("<color=#FF5581FF>");
						component4.color = new Color32(byte.MaxValue, 85, 129, byte.MaxValue);
					}
					else
					{
						this.CombineCount[i].StringToFormat("<color=#FFFFFFFF>");
						component4.color = Color.white;
					}
					this.CombineCount[i].IntToFormat((long)num, 1, true);
					if (!GUIManager.Instance.IsArabic)
					{
						this.CombineCount[i].AppendFormat("{0}{1}</color> / 4");
					}
					else
					{
						this.CombineCount[i].AppendFormat("4 / {0}{1}</color>");
					}
					if (this.MaterCount[i] >= 8)
					{
						this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).gameObject.SetActive(true);
						component.anchoredPosition = new Vector2(115f, -230.5f);
					}
					else
					{
						this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).gameObject.SetActive(false);
						component.anchoredPosition = new Vector2(0f, -230.5f);
					}
				}
				component2.text = this.CombineCount[i].ToString();
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
			}
		}
		else
		{
			for (int j = 0; j < 5; j++)
			{
				UILEBtn component3 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(2 + j).GetComponent<UILEBtn>();
				component2 = component3.transform.GetChild(0).GetComponent<UIText>();
				component3.gameObject.SetActive(true);
				GUIManager.Instance.ChangeLordEquipImg(component3.transform, this.SelectMatID, (byte)(j + 1), eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				component3.m_BtnID1 = 4;
				component3.m_BtnID3 = (int)this.SelectMatID;
				component3.m_BtnID4 = j + 1;
				this.CombineCount[j].ClearString();
				if (j != (int)this.SelectMatColor)
				{
					this.CombineCount[j].IntToFormat((long)this.MaterCount[j], 1, true);
					this.CombineCount[j].AppendFormat("{0:N}");
				}
				else
				{
					UIText component5 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetChild(0).GetComponent<UIText>();
					component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetComponent<RectTransform>();
					ushort num2 = this.MaterCount[j];
					if (num2 < 1)
					{
						this.CombineCount[j].StringToFormat("<color=#FF5581FF>");
						component5.color = new Color32(byte.MaxValue, 85, 129, byte.MaxValue);
					}
					else
					{
						this.CombineCount[j].StringToFormat("<color=#FFFFFFFF>");
						component5.color = Color.white;
					}
					this.CombineCount[j].IntToFormat((long)num2, 1, true);
					if (!GUIManager.Instance.IsArabic)
					{
						this.CombineCount[j].AppendFormat("{0}{1}</color> / 1");
					}
					else
					{
						this.CombineCount[j].AppendFormat("1 / {0}{1}</color>");
					}
					if (this.MaterCount[j] >= 2)
					{
						this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).gameObject.SetActive(true);
						component.anchoredPosition = new Vector2(115f, -230.5f);
					}
					else
					{
						this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).gameObject.SetActive(false);
						component.anchoredPosition = new Vector2(0f, -230.5f);
					}
				}
				component2.text = this.CombineCount[j].ToString();
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
			}
		}
		component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetComponent<RectTransform>();
		Vector2 anchoredPosition;
		if (this.isCombine)
		{
			anchoredPosition = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild((int)(2 + this.SelectMatColor - 1)).GetComponent<RectTransform>().anchoredPosition;
		}
		else
		{
			anchoredPosition = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild((int)(2 + this.SelectMatColor)).GetComponent<RectTransform>().anchoredPosition;
		}
		anchoredPosition.x -= 152f;
		anchoredPosition.y = component.anchoredPosition.y;
		component.anchoredPosition = anchoredPosition;
		if (!this.isLowerMaterialEnough(this.popBackColor, this.SelectMatReqNum) && this.isHigherMaterialEnough(this.popBackColor, this.SelectMatReqNum))
		{
			this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(8).gameObject.SetActive(true);
		}
		else
		{
			this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(8).gameObject.SetActive(false);
		}
		this.AGS_Form.GetChild(12).gameObject.SetActive(true);
	}

	// Token: 0x060018F9 RID: 6393 RVA: 0x002A0114 File Offset: 0x0029E314
	private void SetPopupFunction(bool isCombine)
	{
		this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).gameObject.SetActive(true);
		this.isCombine = isCombine;
		if (isCombine)
		{
			this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(1).gameObject.SetActive(true);
			this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(5).gameObject.SetActive(false);
			UIText component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetChild(0).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7451u);
			component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).GetChild(0).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7450u);
			component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(1).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7466u);
			RectTransform component2 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(2).GetComponent<RectTransform>();
			component2.localScale = Vector3.one;
			component2 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(3).GetComponent<RectTransform>();
			component2.localScale = Vector3.one;
		}
		else
		{
			this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(1).gameObject.SetActive(false);
			this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(5).gameObject.SetActive(true);
			UIText component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetChild(0).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(9547u);
			component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).GetChild(0).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7530u);
			component = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(1).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7532u);
			RectTransform component2 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(2).GetComponent<RectTransform>();
			component2.localScale = new Vector3(-1f, 1f, 1f);
			component2 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(3).GetComponent<RectTransform>();
			component2.localScale = new Vector3(-1f, 1f, 1f);
		}
	}

	// Token: 0x060018FA RID: 6394 RVA: 0x002A047C File Offset: 0x0029E67C
	public void SetSideItem()
	{
		Equip recordByKey = this.DM.EquipTable.GetRecordByKey(UIAnvil.preSetID);
		UIText component = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UIText>();
		this.ItemNameText.ClearString();
		GameConstants.GetColoredLordEquipString(this.ItemNameText, ref recordByKey, this.currentColor);
		component.text = this.ItemNameText.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(6).GetChild(3).GetComponent<UIText>();
		this.ItemLevelText.ClearString();
		if (recordByKey.NeedLv > this.DM.RoleAttr.Level)
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.Append("<color=#FF0000FF>");
			cstring.IntToFormat((long)recordByKey.NeedLv, 1, false);
			cstring.AppendFormat("{0}");
			cstring.Append("</color>");
			this.ItemLevelText.StringToFormat(cstring);
		}
		else
		{
			this.ItemLevelText.IntToFormat((long)recordByKey.NeedLv, 1, false);
		}
		this.ItemLevelText.StringToFormat(LordEquipData.GetItemKindTalkID(recordByKey.EquipKind));
		this.ItemLevelText.AppendFormat(this.DM.mStringTable.GetStringByID(7437u));
		component.text = this.ItemLevelText.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		this.AGS_RareImg.gameObject.SetActive(true);
		if (GameConstants.IsBetween((int)this.currentColor, 0, 6))
		{
			this.AGS_RareImg.SetSpriteIndex((int)(this.currentColor - 1));
		}
		this.effectList.Clear();
		LordEquipData.GetEffectList(UIAnvil.preSetID, this.currentColor, this.effectList);
		this.SPHeight.Clear();
		for (int i = 0; i < this.effectList.Count; i++)
		{
			this.SPHeight.Add(28f);
		}
		this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeight, 274f, true);
		component = this.AGS_Form.GetChild(9).GetChild(0).GetComponent<UIText>();
		if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.NowForging)
		{
			this.AGS_Form.GetChild(9).GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
			component.text = string.Empty;
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			this.AGS_Form.GetChild(9).GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -10f);
			recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.RoleAttr.LordEquipEventData.ItemID);
			this.forgingItemName.ClearString();
			GameConstants.GetColoredLordEquipString(this.forgingItemName, ref recordByKey, this.DM.RoleAttr.LordEquipEventData.Color);
			component.text = this.forgingItemName.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x060018FB RID: 6395 RVA: 0x002A0798 File Offset: 0x0029E998
	public void SetForgingTimeBar()
	{
		RectTransform component = this.AGS_Form.GetChild(9).GetChild(2).GetComponent<RectTransform>();
		UIText component2 = this.AGS_Form.GetChild(9).GetChild(4).GetComponent<UIText>();
		long num = this.DM.RoleAttr.LordEquipEventTime.BeginTime + (long)((ulong)this.DM.RoleAttr.LordEquipEventTime.RequireTime) - this.DM.ServerTime;
		if (num < 0L)
		{
			num = 0L;
		}
		float num2 = Mathf.Min(1f - (float)num / this.DM.RoleAttr.LordEquipEventTime.RequireTime, 1f) * 210f;
		this.timeRemain.ClearString();
		GameConstants.GetTimeString(this.timeRemain, (uint)num, false, true, true, true, true);
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2);
		component2.text = this.timeRemain.ToString();
		component2.SetAllDirty();
		component2.cachedTextGenerator.Invalidate();
		num2 = component2.preferredWidth;
		component = this.AGS_Form.GetChild(9).GetChild(3).GetComponent<RectTransform>();
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200f - num2);
	}

	// Token: 0x060018FC RID: 6396 RVA: 0x002A08C4 File Offset: 0x0029EAC4
	public void SetOpenKind(eUI_Anvil_OpenKind OpenKind)
	{
		UIAnvil.OpenKind = OpenKind;
		switch (OpenKind)
		{
		case eUI_Anvil_OpenKind.ForgeNewItem:
		case eUI_Anvil_OpenKind.UpgradeItem:
			this.AGS_Form.GetChild(8).gameObject.SetActive(true);
			this.AGS_Form.GetChild(9).gameObject.SetActive(false);
			this.AGS_Form.GetChild(10).gameObject.SetActive(true);
			this.AGS_Form.GetChild(11).gameObject.SetActive(true);
			break;
		case eUI_Anvil_OpenKind.NowForging:
			this.AGS_Form.GetChild(8).gameObject.SetActive(true);
			this.AGS_Form.GetChild(9).gameObject.SetActive(true);
			this.AGS_Form.GetChild(10).gameObject.SetActive(true);
			this.AGS_Form.GetChild(11).gameObject.SetActive(false);
			break;
		}
		switch (OpenKind)
		{
		case eUI_Anvil_OpenKind.ForgeNewItem:
		case eUI_Anvil_OpenKind.NowForging:
		{
			UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7430u);
			component = this.AGS_Form.GetChild(11).GetChild(0).GetChild(3).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7439u);
			component = this.AGS_Form.GetChild(11).GetChild(1).GetChild(1).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7440u);
			break;
		}
		case eUI_Anvil_OpenKind.UpgradeItem:
		{
			UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7537u);
			component = this.AGS_Form.GetChild(11).GetChild(0).GetChild(3).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7535u);
			component = this.AGS_Form.GetChild(11).GetChild(1).GetChild(1).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7475u);
			break;
		}
		}
	}

	// Token: 0x060018FD RID: 6397 RVA: 0x002A0B30 File Offset: 0x0029ED30
	private void GetMaterialRareCount(ushort itemID)
	{
		for (int i = 0; i < this.MaterCount.Length; i++)
		{
			this.MaterCount[i] = 0;
		}
		for (int j = 0; j < this.DM.mLordEquip.LEMaterial.Length; j++)
		{
			if (this.DM.mLordEquip.LEMaterial[j].ItemID == itemID)
			{
				this.MaterCount[(int)(this.DM.mLordEquip.LEMaterial[j].Color - 1)] = this.DM.mLordEquip.LEMaterial[j].Quantity;
			}
		}
	}

	// Token: 0x060018FE RID: 6398 RVA: 0x002A0BE4 File Offset: 0x0029EDE4
	private bool isLowerMaterialEnough(byte color, ushort reqNum)
	{
		color -= 1;
		if (GameConstants.IsBetween((int)color, 0, 4))
		{
			if (this.MaterCount[(int)color] >= reqNum)
			{
				return true;
			}
			int num = 0;
			for (int i = (int)color; i >= 0; i--)
			{
				num = num * 4 + (int)this.MaterCount[i];
			}
			if (Math.Pow(4.0, (double)color) * (double)reqNum <= (double)num)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060018FF RID: 6399 RVA: 0x002A0C54 File Offset: 0x0029EE54
	private bool isHigherMaterialEnough(byte color, ushort reqNum)
	{
		color -= 1;
		if (GameConstants.IsBetween((int)color, 0, 4))
		{
			if (this.MaterCount[(int)color] >= reqNum)
			{
				return true;
			}
			int num = 0;
			for (int i = 4; i >= (int)color; i--)
			{
				num = num * 4 + (int)this.MaterCount[i];
			}
			if ((int)reqNum <= num)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001900 RID: 6400 RVA: 0x002A0CB0 File Offset: 0x0029EEB0
	private int GetFirstIndex(ushort itemID, byte color)
	{
		uint num = 0u;
		if (color > 0)
		{
			for (int i = 0; i < 8; i++)
			{
				if (LordEquipData.RoleEquip[i].ItemID == UIAnvil.preSetID && LordEquipData.RoleEquip[i].Color == color)
				{
					num = LordEquipData.RoleEquipSerial[i];
					break;
				}
			}
			for (ushort num2 = 0; num2 < (ushort)this.DM.RoleAttr.LordEquipBagSize; num2 += 1)
			{
				if (this.DM.mLordEquip.LordEquip[(int)num2].ItemID == UIAnvil.preSetID && this.DM.mLordEquip.LordEquip[(int)num2].Color == color && (num == 0u || num == this.DM.mLordEquip.LordEquip[(int)num2].SerialNO))
				{
					return (int)num2;
				}
			}
		}
		return -1;
	}

	// Token: 0x06001901 RID: 6401 RVA: 0x002A0DA8 File Offset: 0x0029EFA8
	private bool isCombineReady(int selectIdx, ushort itemID, byte color, bool MoneyCombine, bool PopMessage = false)
	{
		eUI_Anvil_OpenKind openKind = UIAnvil.OpenKind;
		if (openKind != eUI_Anvil_OpenKind.ForgeNewItem)
		{
			if (openKind == eUI_Anvil_OpenKind.UpgradeItem)
			{
				if (this.DM.mLordEquip.LordEquip[selectIdx].Color + 1 != color)
				{
					return false;
				}
			}
		}
		else
		{
			if (color > 1 && LordEquipData.getItemQuantity(itemID, color - 1) == 0)
			{
				if (PopMessage)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7443u), 255, true);
				}
				return false;
			}
			if (color == 1 && !this.DM.mLordEquip.HaveEquipSpace())
			{
				if (PopMessage)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7497u), 255, true);
				}
				return false;
			}
		}
		if (this.DM.RoleAttr.LordEquipEventData.ItemID != 0)
		{
			return false;
		}
		Equip recordByKey = this.DM.EquipTable.GetRecordByKey(itemID);
		if (!this.DM.mLordEquip.isItemCombineReady(itemID, color))
		{
			if (PopMessage)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7442u), 255, true);
			}
			return false;
		}
		if (MoneyCombine)
		{
			if (this.NeedDiamon > this.DM.RoleAttr.Diamond)
			{
				if (PopMessage)
				{
					GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3966u), DataManager.Instance.mStringTable.GetStringByID(646u), DataManager.Instance.mStringTable.GetStringByID(3968u), this, 3, 0, true, false, false, false, false);
				}
				return false;
			}
		}
		else
		{
			uint num = Math.Max(100u, 10000u - this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_CRIFTING_COST_MONEY_REDUCTION));
			uint num2 = (uint)Math.Ceiling(recordByKey.MixPrice * this.DM.mLordEquip.forgeGold[(int)this.currentColor] * num / 10000.0);
			if (num2 > this.DM.Resource[4].CurrentStock)
			{
				if (PopMessage)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7446u), 255, true);
				}
				return false;
			}
		}
		return true;
	}

	// Token: 0x06001902 RID: 6402 RVA: 0x002A1018 File Offset: 0x0029F218
	private void ShowMoney()
	{
		Equip recordByKey = this.DM.EquipTable.GetRecordByKey(UIAnvil.preSetID);
		if (this.currentColor > 6)
		{
			return;
		}
		uint num = Math.Max(100u, 10000u - this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_CRIFTING_COST_MONEY_REDUCTION));
		uint num2 = (uint)Math.Ceiling(recordByKey.MixPrice * this.DM.mLordEquip.forgeGold[(int)this.currentColor] * num / 10000.0);
		UIText component = this.AGS_Form.GetChild(10).GetChild(10).GetChild(1).GetComponent<UIText>();
		this.goldCost.ClearString();
		this.goldCost.IntToFormat((long)((ulong)this.DM.Resource[4].Stock), 1, true);
		this.goldCost.IntToFormat((long)((ulong)num2), 1, true);
		if (this.DM.Resource[4].Stock < num2)
		{
			this.goldCost.StringToFormat("<color=#FF5581FF>");
		}
		else
		{
			this.goldCost.StringToFormat("<color=#FFFFFFFF>");
		}
		if (!GUIManager.Instance.IsArabic)
		{
			this.goldCost.AppendFormat("{2}{0}</color> / {1}");
		}
		else
		{
			this.goldCost.AppendFormat("{1} / {2}{0}</color>");
		}
		component.text = this.goldCost.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component.cachedTextGeneratorForLayout.Invalidate();
		RectTransform component2 = this.AGS_Form.GetChild(10).GetChild(10).GetChild(0).GetComponent<RectTransform>();
		Vector2 anchoredPosition = component.rectTransform.anchoredPosition;
		anchoredPosition.x -= component.preferredWidth / 2f + 20f;
		component2.anchoredPosition = anchoredPosition;
		component2 = this.AGS_Form.GetChild(10).GetChild(10).GetChild(2).GetComponent<RectTransform>();
		anchoredPosition = component.rectTransform.anchoredPosition;
		anchoredPosition.x += component.preferredWidth / 2f + 24f;
		component2.anchoredPosition = anchoredPosition;
		component2.gameObject.SetActive(this.DM.Resource[4].Stock < num2);
		this.NeedDiamon = (uint)Math.Ceiling(recordByKey.MixTime * this.DM.mLordEquip.forgeTime[(int)this.currentColor] * 10000.0 / (10000.0 + this.DM.AttribVal.GetEffectBaseValByEffectID(250)));
		component = this.AGS_Form.GetChild(11).GetChild(1).GetChild(2).GetComponent<UIText>();
		this.timeCost.ClearString();
		this.timeCost.Append(this.DM.mStringTable.GetStringByID(7441u));
		this.timeCost.Append(" ");
		GameConstants.GetTimeString(this.timeCost, this.NeedDiamon, false, false, true, true, true);
		component.text = this.timeCost.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		if (this.DM.Resource[4].Stock > num2)
		{
			num2 = 0u;
		}
		else
		{
			num2 -= this.DM.Resource[4].Stock;
		}
		this.NeedDiamon = this.DM.GetResourceExchange(PriceListType.Time, this.NeedDiamon) + this.DM.GetResourceExchange(PriceListType.Money, num2);
		component = this.AGS_Form.GetChild(11).GetChild(0).GetChild(2).GetComponent<UIText>();
		this.moneyCost.ClearString();
		this.moneyCost.IntToFormat((long)((ulong)this.NeedDiamon), 1, true);
		this.moneyCost.AppendFormat("{0}");
		component.text = this.moneyCost.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(11).GetChild(1).GetChild(1).GetComponent<UIText>();
		if (this.isCombineReady((int)UIAnvil.preSetIndex, UIAnvil.preSetID, this.currentColor, false, false))
		{
			component.color = new Color32(byte.MaxValue, 247, 153, byte.MaxValue);
		}
		else
		{
			component.color = new Color32(byte.MaxValue, 85, 129, byte.MaxValue);
		}
		component = this.AGS_Form.GetChild(11).GetChild(0).GetChild(3).GetComponent<UIText>();
		if (this.isCombineReady((int)UIAnvil.preSetIndex, UIAnvil.preSetID, this.currentColor, true, false))
		{
			component.color = new Color32(byte.MaxValue, 247, 153, byte.MaxValue);
		}
		else
		{
			component.color = new Color32(byte.MaxValue, 85, 129, byte.MaxValue);
		}
	}

	// Token: 0x06001903 RID: 6403 RVA: 0x002A1528 File Offset: 0x0029F728
	private void StartForge(bool Start)
	{
		if (Start)
		{
			this.ItemMagnet = true;
			this.ForgeStart = true;
			this.SmallForgeLight.gameObject.SetActive(true);
		}
		else
		{
			this.ForgeStop = true;
		}
	}

	// Token: 0x06001904 RID: 6404 RVA: 0x002A155C File Offset: 0x0029F75C
	private void resetItemPos()
	{
		for (int i = 0; i < 5; i++)
		{
			Color color = new Color(1f, 1f, 1f, 1f);
			UILEBtn component = this.AGS_Form.GetChild(10).GetChild(0 + i).GetComponent<UILEBtn>();
			component.LEImage.transform.localPosition = Vector3.zero;
			component.LEImage.color = color;
		}
	}

	// Token: 0x06001905 RID: 6405 RVA: 0x002A15D4 File Offset: 0x0029F7D4
	public static void SetOpen(eUI_Anvil_OpenKind iOpenKind, int ItemId, int ItemColor)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		UIAnvil.OpenKind = iOpenKind;
		UIAnvil.returnID = 0;
		UIAnvil.returnColor = 0;
		door.OpenMenu(EGUIWindow.UI_Anvil, ItemId, ItemColor, false);
	}

	// Token: 0x06001906 RID: 6406 RVA: 0x002A1610 File Offset: 0x0029F810
	public void Update()
	{
		if (this.isLoading)
		{
			this.isLoading = false;
			this.AfterLoader();
		}
		this.ForgeLightTime += Time.smoothDeltaTime / 2f;
		if (this.ForgeLightTime >= 1.5f)
		{
			this.ForgeLightTime = 0.5f;
		}
		float num = (this.ForgeLightTime <= 1f) ? this.ForgeLightTime : (2f - this.ForgeLightTime);
		Color color = new Color(1f, 1f, 1f, num);
		this.ForgeLight.color = color;
		this.SelectLight.color = color;
		this.MaterialLight.color = color;
		this.POPLight1.color = color;
		this.POPLight3.color = color;
		this.arrowTime += Time.smoothDeltaTime * 40f;
		if (this.arrowTime >= 40f)
		{
			this.arrowTime = 0f;
		}
		float num2 = (this.arrowTime <= 20f) ? this.arrowTime : (40f - this.arrowTime);
		if (num2 < 0f)
		{
			num2 = 0f;
		}
		this.arrowPos.anchoredPosition = new Vector2(10f - num2, this.arrowPos.anchoredPosition.y);
		this.HintTime += Time.smoothDeltaTime / 2f;
		if (this.HintTime >= 2f)
		{
			this.HintTime = 0f;
		}
		num = ((this.HintTime <= 1f) ? this.HintTime : (2f - this.HintTime));
		color = new Color(1f, 1f, 1f, num);
		for (int i = 0; i < 5; i++)
		{
			this.ItemLight[i].color = color;
		}
		if (this.ForgintLightEff)
		{
			this.ForgingLightTime += Time.smoothDeltaTime * 1.5f;
			if (this.ForgingLightTime >= 1f)
			{
				this.ForgingLightTime = 0f;
			}
			num = 1f - this.ForgingLightTime;
			Vector3 localScale = Vector3.one * num;
			this.BigForgeLight.localScale = localScale;
		}
		if (this.ForgeStart)
		{
			this.ForgeStartTime += Time.smoothDeltaTime * 1.5f;
			if (this.ForgeStartTime >= 2f)
			{
				this.ForgeStartTime = 0f;
				this.ItemMagnet = false;
				this.resetItemPos();
				if (this.ForgeStop)
				{
					this.ForgeStart = false;
					this.ForgeStop = false;
					this.ForgintLightEff = false;
					this.BigForgeLight.gameObject.SetActive(false);
				}
			}
			if (this.ItemMagnet)
			{
				Vector3 position = this.SmallForgeLight.transform.position;
				for (int j = 0; j < 5; j++)
				{
					UILEBtn component = this.AGS_Form.GetChild(10).GetChild(0 + j).GetComponent<UILEBtn>();
					Vector3 position2 = Vector3.Lerp(component.image.transform.position, position, this.ForgeStartTime);
					component.LEImage.transform.position = position2;
				}
				if (this.ForgeStartTime > 1f)
				{
					color = new Color(1f, 1f, 1f, 0f);
					for (int k = 0; k < 5; k++)
					{
						UILEBtn component = this.AGS_Form.GetChild(10).GetChild(0 + k).GetComponent<UILEBtn>();
						component.LEImage.transform.localPosition = Vector3.zero;
						component.LEImage.color = color;
					}
					this.ItemMagnet = false;
				}
			}
			if (this.ForgeStartTime >= 1f)
			{
				this.ForgintLightEff = true;
				this.BigForgeLight.gameObject.SetActive(true);
			}
			num = ((this.ForgeStartTime <= 1f) ? this.ForgeStartTime : (2f - this.ForgeStartTime));
			color = new Color(1f, 1f, 1f, num);
			this.SmallForgeLight.color = color;
		}
		if (this.MaterialFlash)
		{
			this.MoveTime += Time.smoothDeltaTime;
			if (this.MoveTime < 0.3f)
			{
				if (this.isCombine)
				{
					this.Flash.rectTransform.anchoredPosition = new Vector2(Mathf.Lerp(-50f, 100f, this.MoveTime / 0.3f), 5f);
				}
				else
				{
					this.Flash.rectTransform.anchoredPosition = new Vector2(Mathf.Lerp(50f, -100f, this.MoveTime / 0.3f), 5f);
				}
				this.Flash.color = Color.white;
				float a = (0.3f - this.MoveTime) / 0.3f;
				this.LightBox1.color = new Color(1f, 1f, 1f, a);
				this.LightBox2.color = new Color(1f, 1f, 1f, a);
			}
			if ((double)this.MoveTime > 0.2)
			{
				this.Flash.color = new Color(1f, 1f, 1f, (0.3f - this.MoveTime) * 10f);
			}
			if (this.MoveTime >= 0.4f)
			{
				this.MoveTime = 0f;
				this.MaterialFlash = false;
			}
		}
	}

	// Token: 0x04004966 RID: 18790
	private Transform AGS_Form;

	// Token: 0x04004967 RID: 18791
	private UISpritesArray AGS_RareImg;

	// Token: 0x04004968 RID: 18792
	private ScrollPanel AGS_ScrollPanel;

	// Token: 0x04004969 RID: 18793
	private Door door;

	// Token: 0x0400496A RID: 18794
	private DataManager DM;

	// Token: 0x0400496B RID: 18795
	private Image ForgeLight;

	// Token: 0x0400496C RID: 18796
	private Image SelectLight;

	// Token: 0x0400496D RID: 18797
	private Image MaterialLight;

	// Token: 0x0400496E RID: 18798
	private RectTransform arrowPos;

	// Token: 0x0400496F RID: 18799
	private Image SmallForgeLight;

	// Token: 0x04004970 RID: 18800
	private RectTransform BigForgeLight;

	// Token: 0x04004971 RID: 18801
	private Image Flash;

	// Token: 0x04004972 RID: 18802
	private Image LightBox1;

	// Token: 0x04004973 RID: 18803
	private Image LightBox2;

	// Token: 0x04004974 RID: 18804
	private Image[] ItemLight = new Image[5];

	// Token: 0x04004975 RID: 18805
	private Image POPLight1;

	// Token: 0x04004976 RID: 18806
	private Image POPLight3;

	// Token: 0x04004977 RID: 18807
	private bool MaterialFlash;

	// Token: 0x04004978 RID: 18808
	private bool ForgintLightEff;

	// Token: 0x04004979 RID: 18809
	private bool ForgeStart;

	// Token: 0x0400497A RID: 18810
	private bool ForgeStop;

	// Token: 0x0400497B RID: 18811
	private bool ItemMagnet;

	// Token: 0x0400497C RID: 18812
	private bool isLoading = true;

	// Token: 0x0400497D RID: 18813
	private bool isCombine;

	// Token: 0x0400497E RID: 18814
	private ushort[] MaterCount = new ushort[5];

	// Token: 0x0400497F RID: 18815
	public static eUI_Anvil_OpenKind OpenKind;

	// Token: 0x04004980 RID: 18816
	public static ushort preSetIndex;

	// Token: 0x04004981 RID: 18817
	public static ushort preSetID;

	// Token: 0x04004982 RID: 18818
	public static ushort returnID;

	// Token: 0x04004983 RID: 18819
	public static byte returnColor;

	// Token: 0x04004984 RID: 18820
	private byte preSetColor;

	// Token: 0x04004985 RID: 18821
	private byte currentColor;

	// Token: 0x04004986 RID: 18822
	private byte popBackColor;

	// Token: 0x04004987 RID: 18823
	private ushort SelectMatID;

	// Token: 0x04004988 RID: 18824
	private byte SelectMatColor;

	// Token: 0x04004989 RID: 18825
	private ushort SelectMatReqNum;

	// Token: 0x0400498A RID: 18826
	private bool OpenOrange = true;

	// Token: 0x0400498B RID: 18827
	private CString ItemNameText;

	// Token: 0x0400498C RID: 18828
	private CString ItemLevelText;

	// Token: 0x0400498D RID: 18829
	private CString goldCost;

	// Token: 0x0400498E RID: 18830
	private CString moneyCost;

	// Token: 0x0400498F RID: 18831
	private CString timeCost;

	// Token: 0x04004990 RID: 18832
	private CString timeRemain;

	// Token: 0x04004991 RID: 18833
	private CString focusName;

	// Token: 0x04004992 RID: 18834
	private CString forgingItemName;

	// Token: 0x04004993 RID: 18835
	private CString PopString;

	// Token: 0x04004994 RID: 18836
	private CString[] RequestCount = new CString[5];

	// Token: 0x04004995 RID: 18837
	private CString[] EffDescText = new CString[6];

	// Token: 0x04004996 RID: 18838
	private CString[] CombineCount = new CString[5];

	// Token: 0x04004997 RID: 18839
	private CString PopUpHeaderText;

	// Token: 0x04004998 RID: 18840
	private List<LordEquipEffectSet> effectList;

	// Token: 0x04004999 RID: 18841
	private List<float> SPHeight;

	// Token: 0x0400499A RID: 18842
	private uint NeedDiamon;

	// Token: 0x0400499B RID: 18843
	private float MoveTime;

	// Token: 0x0400499C RID: 18844
	private float ForgeLightTime;

	// Token: 0x0400499D RID: 18845
	private float HintTime;

	// Token: 0x0400499E RID: 18846
	private float ForgingLightTime;

	// Token: 0x0400499F RID: 18847
	private float ForgeStartTime;

	// Token: 0x040049A0 RID: 18848
	private float arrowTime;

	// Token: 0x020004D4 RID: 1236
	private enum e_AGS_UI_ForgeAnvil_Editor
	{
		// Token: 0x040049A2 RID: 18850
		BGFrame,
		// Token: 0x040049A3 RID: 18851
		BGFrameTitle,
		// Token: 0x040049A4 RID: 18852
		exitImage,
		// Token: 0x040049A5 RID: 18853
		Infobtn,
		// Token: 0x040049A6 RID: 18854
		Image,
		// Token: 0x040049A7 RID: 18855
		BGImage,
		// Token: 0x040049A8 RID: 18856
		ItemInfo,
		// Token: 0x040049A9 RID: 18857
		ItemLine,
		// Token: 0x040049AA RID: 18858
		ForgingItem,
		// Token: 0x040049AB RID: 18859
		ForgingPanel,
		// Token: 0x040049AC RID: 18860
		ItemCombine,
		// Token: 0x040049AD RID: 18861
		ItemCombinePanel,
		// Token: 0x040049AE RID: 18862
		Cover
	}

	// Token: 0x020004D5 RID: 1237
	private enum e_AGS_ItemInfo
	{
		// Token: 0x040049B0 RID: 18864
		NameBg,
		// Token: 0x040049B1 RID: 18865
		NameText,
		// Token: 0x040049B2 RID: 18866
		RareImg,
		// Token: 0x040049B3 RID: 18867
		LevelText,
		// Token: 0x040049B4 RID: 18868
		ScrollPanel,
		// Token: 0x040049B5 RID: 18869
		ScrollItem,
		// Token: 0x040049B6 RID: 18870
		Image,
		// Token: 0x040049B7 RID: 18871
		EquipBtn
	}

	// Token: 0x020004D6 RID: 1238
	private enum e_AGS_EquipBtn
	{
		// Token: 0x040049B9 RID: 18873
		Image
	}

	// Token: 0x020004D7 RID: 1239
	private enum e_AGS_ItemLine
	{
		// Token: 0x040049BB RID: 18875
		UILEBtn1,
		// Token: 0x040049BC RID: 18876
		UILEBtn2,
		// Token: 0x040049BD RID: 18877
		UILEBtn3,
		// Token: 0x040049BE RID: 18878
		UILEBtn4,
		// Token: 0x040049BF RID: 18879
		UILEBtn5,
		// Token: 0x040049C0 RID: 18880
		UILEBtn6,
		// Token: 0x040049C1 RID: 18881
		Light,
		// Token: 0x040049C2 RID: 18882
		BackBtn
	}

	// Token: 0x020004D8 RID: 1240
	private enum e_AGS_ForgingItem
	{
		// Token: 0x040049C4 RID: 18884
		TargetItem,
		// Token: 0x040049C5 RID: 18885
		TargetName,
		// Token: 0x040049C6 RID: 18886
		Light,
		// Token: 0x040049C7 RID: 18887
		Light2,
		// Token: 0x040049C8 RID: 18888
		Light3
	}

	// Token: 0x020004D9 RID: 1241
	private enum e_AGS_ForgingPanel
	{
		// Token: 0x040049CA RID: 18890
		ItemName,
		// Token: 0x040049CB RID: 18891
		BarBg,
		// Token: 0x040049CC RID: 18892
		Bar,
		// Token: 0x040049CD RID: 18893
		BarDesc,
		// Token: 0x040049CE RID: 18894
		BarTime,
		// Token: 0x040049CF RID: 18895
		CancelBtn,
		// Token: 0x040049D0 RID: 18896
		FastBtn
	}

	// Token: 0x020004DA RID: 1242
	private enum e_AGS_ItemCombine
	{
		// Token: 0x040049D2 RID: 18898
		Mat1,
		// Token: 0x040049D3 RID: 18899
		Mat2,
		// Token: 0x040049D4 RID: 18900
		Mat3,
		// Token: 0x040049D5 RID: 18901
		Mat4,
		// Token: 0x040049D6 RID: 18902
		oldItem,
		// Token: 0x040049D7 RID: 18903
		Light1,
		// Token: 0x040049D8 RID: 18904
		Light2,
		// Token: 0x040049D9 RID: 18905
		Light3,
		// Token: 0x040049DA RID: 18906
		Light4,
		// Token: 0x040049DB RID: 18907
		Light5,
		// Token: 0x040049DC RID: 18908
		AddMoney
	}

	// Token: 0x020004DB RID: 1243
	private enum e_AGS_AddMoney
	{
		// Token: 0x040049DE RID: 18910
		Icon,
		// Token: 0x040049DF RID: 18911
		Money,
		// Token: 0x040049E0 RID: 18912
		Plus
	}

	// Token: 0x020004DC RID: 1244
	private enum e_AGS_ItemCombinePanel
	{
		// Token: 0x040049E2 RID: 18914
		QuickBtn,
		// Token: 0x040049E3 RID: 18915
		ForgeBtn
	}

	// Token: 0x020004DD RID: 1245
	private enum e_AGS_QuickBtn
	{
		// Token: 0x040049E5 RID: 18917
		Icon,
		// Token: 0x040049E6 RID: 18918
		cover,
		// Token: 0x040049E7 RID: 18919
		Money,
		// Token: 0x040049E8 RID: 18920
		Name
	}

	// Token: 0x020004DE RID: 1246
	private enum e_AGS_ForgeBtn
	{
		// Token: 0x040049EA RID: 18922
		cover,
		// Token: 0x040049EB RID: 18923
		Name,
		// Token: 0x040049EC RID: 18924
		TimeText
	}

	// Token: 0x020004DF RID: 1247
	private enum e_AGS_PopUp
	{
		// Token: 0x040049EE RID: 18926
		PopBg,
		// Token: 0x040049EF RID: 18927
		CloseBtn,
		// Token: 0x040049F0 RID: 18928
		UILEBtn,
		// Token: 0x040049F1 RID: 18929
		TitleBg,
		// Token: 0x040049F2 RID: 18930
		ItemName,
		// Token: 0x040049F3 RID: 18931
		ItemRare,
		// Token: 0x040049F4 RID: 18932
		EffBg,
		// Token: 0x040049F5 RID: 18933
		Upgrade,
		// Token: 0x040049F6 RID: 18934
		CombineAll,
		// Token: 0x040049F7 RID: 18935
		CombineBtn,
		// Token: 0x040049F8 RID: 18936
		TextArea,
		// Token: 0x040049F9 RID: 18937
		Image,
		// Token: 0x040049FA RID: 18938
		MaterialPanel
	}

	// Token: 0x020004E0 RID: 1248
	private enum e_AGS_Upgrade
	{
		// Token: 0x040049FC RID: 18940
		Desc,
		// Token: 0x040049FD RID: 18941
		DescText,
		// Token: 0x040049FE RID: 18942
		Mat1,
		// Token: 0x040049FF RID: 18943
		Mat2,
		// Token: 0x04004A00 RID: 18944
		Mat3,
		// Token: 0x04004A01 RID: 18945
		Mat4,
		// Token: 0x04004A02 RID: 18946
		Mat5,
		// Token: 0x04004A03 RID: 18947
		Select
	}

	// Token: 0x020004E1 RID: 1249
	private enum e_AGS_Select
	{
		// Token: 0x04004A05 RID: 18949
		Flash1,
		// Token: 0x04004A06 RID: 18950
		Flash2,
		// Token: 0x04004A07 RID: 18951
		Image,
		// Token: 0x04004A08 RID: 18952
		LightEff
	}

	// Token: 0x020004E2 RID: 1250
	private enum e_AGS_MaterialPanel
	{
		// Token: 0x04004A0A RID: 18954
		combinebg,
		// Token: 0x04004A0B RID: 18955
		combine,
		// Token: 0x04004A0C RID: 18956
		Image1bg,
		// Token: 0x04004A0D RID: 18957
		Image1,
		// Token: 0x04004A0E RID: 18958
		breakDownbg,
		// Token: 0x04004A0F RID: 18959
		breakDown,
		// Token: 0x04004A10 RID: 18960
		Image2bg,
		// Token: 0x04004A11 RID: 18961
		Image2,
		// Token: 0x04004A12 RID: 18962
		Mark
	}
}
