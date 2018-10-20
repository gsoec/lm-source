using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x020005DA RID: 1498
public class UILordEquip : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUILEBtnClickHandler
{
	// Token: 0x06001DC5 RID: 7621 RVA: 0x003780A8 File Offset: 0x003762A8
	public override void OnOpen(int arg1, int arg2)
	{
		this.door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
		this.DM = DataManager.Instance;
		if (this.DM.mLordEquip == null)
		{
			this.DM.mLordEquip = LordEquipData.Instance();
		}
		this.OpenKind = (eUI_LordEquipOpenKind)arg1;
		this.EquipSolt = (byte)arg2;
		this.CollectType = UILordEquip.eCollectType.Equip;
		this.PopupKind = UILordEquip.eUIOpenStat.None;
		eUI_LordEquipOpenKind openKind = this.OpenKind;
		if (openKind == eUI_LordEquipOpenKind.CombineSelect)
		{
			UILordEquip.waitForReturn = eUI_LordEquipReturnKind.None;
		}
		this.TitleText = StringManager.Instance.SpawnString(100);
		this.NoContentText = StringManager.Instance.SpawnString(100);
		this.ItemNameText = StringManager.Instance.SpawnString(100);
		this.ItemLevelText = StringManager.Instance.SpawnString(50);
		this.PopUpHeaderText = StringManager.Instance.SpawnString(100);
		this.TimedItemCountText = StringManager.Instance.SpawnString(100);
		for (int i = 0; i < this.GemBtnText.Length; i++)
		{
			this.GemBtnText[i] = StringManager.Instance.SpawnString(100);
		}
		for (int j = 0; j < this.EffDescText.Length; j++)
		{
			this.EffDescText[j] = StringManager.Instance.SpawnString(500);
		}
		for (int k = 0; k < this.PopupEffectText.Length; k++)
		{
			this.PopupEffectText[k] = StringManager.Instance.SpawnString(500);
		}
		for (int l = 0; l < this.PopupAmountText.Length; l++)
		{
			this.PopupAmountText[l] = StringManager.Instance.SpawnString(50);
		}
		this.effectList = new List<LordEquipEffectSet>();
		this.SPHeight = new List<float>();
		this.SideSPHeight = new List<float>();
		this.FilterItem = new List<ushort>();
		this.PopSPHeight = new List<float>();
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7404u);
		this.AllTextObject[0] = component;
		UIButton component2 = this.AGS_Form.GetChild(2).GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_EffectType = e_EffectType.e_Scale;
		Image component3 = this.AGS_Form.GetChild(2).GetComponent<Image>();
		component3.enabled = !GUIManager.Instance.bOpenOnIPhoneX;
		component2 = this.AGS_Form.GetChild(3).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 99;
		component2.m_EffectType = e_EffectType.e_Scale;
		component2.gameObject.SetActive(false);
		RectTransform component4;
		if (GUIManager.Instance.IsArabic)
		{
			component4 = component2.gameObject.GetComponent<RectTransform>();
			component4.localScale = new Vector3(-1f, 1f, 1f);
		}
		component = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[1] = component;
		component2 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 8;
		component = this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7440u);
		this.AllTextObject[2] = component;
		component3 = this.AGS_Form.GetChild(6).GetChild(0).GetChild(1).GetComponent<Image>();
		component3.sprite = this.door.LoadSprite("UI_main_redbox_01");
		component3.material = this.door.LoadMaterial();
		component3.type = Image.Type.Sliced;
		component3 = this.AGS_Form.GetChild(6).GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
		component3.sprite = this.door.LoadSprite("UI_main_mess_ex");
		component3.material = this.door.LoadMaterial();
		component2 = this.AGS_Form.GetChild(6).GetChild(1).GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component = this.AGS_Form.GetChild(6).GetChild(1).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7456u);
		this.AllTextObject[3] = component;
		component2 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 6;
		component2.m_BtnID2 = 1;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7457u);
		component3 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>();
		component3.sprite = this.door.LoadSprite("UI_main_redbox_01");
		component3.material = this.door.LoadMaterial();
		component3.type = Image.Type.Sliced;
		this.AllTextObject[4] = component;
		component3 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>();
		component3.sprite = this.door.LoadSprite("UI_main_mess_ex");
		component3.material = this.door.LoadMaterial();
		component2 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(1).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 6;
		component2.m_BtnID2 = 2;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(8).GetChild(0).GetChild(1).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7458u);
		this.AllTextObject[5] = component;
		component2 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(2).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 6;
		component2.m_BtnID2 = 4;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(8).GetChild(0).GetChild(2).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(16127u);
		this.AllTextObject[6] = component;
		component2 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(3).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 6;
		component2.m_BtnID2 = 3;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(8).GetChild(0).GetChild(3).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7459u);
		this.AllTextObject[7] = component;
		this.Light1 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
		this.Light2 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
		this.Light3 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(3).GetChild(0).GetComponent<Image>();
		this.Light4 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>();
		component = this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[8] = component;
		component2 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 6;
		component2.m_BtnID2 = 101;
		component = this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[9] = component;
		component2 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).GetChild(1).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 6;
		component2.m_BtnID2 = 101;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7464u);
		this.AllTextObject[10] = component;
		component2 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(7).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 6;
		component2.m_BtnID2 = 102;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[11] = component;
		this.AGS_RareImg = this.AGS_Form.GetChild(8).GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
		component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component.alignment = TextAnchor.MiddleLeft;
		component.text = string.Empty;
		this.AllTextObject[12] = component;
		component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component.alignment = TextAnchor.UpperLeft;
		component4 = component.GetComponent<RectTransform>();
		component4.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 34f);
		component.resizeTextMaxSize = 22;
		this.AllTextObject[13] = component;
		this.AGS_ScrollPanel = this.AGS_Form.GetChild(8).GetChild(1).GetChild(7).GetComponent<ScrollPanel>();
		component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(8).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[14] = component;
		component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(8).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.resizeTextMaxSize = 18;
		component.text = string.Empty;
		this.AllTextObject[15] = component;
		component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(8).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.fontSize = 16;
		component.text = string.Empty;
		this.AllTextObject[16] = component;
		component2 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 1;
		component2.m_BtnID2 = 1;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7468u);
		this.AllTextObject[17] = component;
		component3 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetChild(2).GetComponent<Image>();
		component3.sprite = this.door.LoadSprite("UI_main_redbox_01");
		component3.material = this.door.LoadMaterial();
		component3.type = Image.Type.Sliced;
		component3 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetChild(2).GetChild(0).GetComponent<Image>();
		component3.sprite = this.door.LoadSprite("UI_main_mess_ex");
		component3.material = this.door.LoadMaterial();
		component2 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 1;
		component2.m_BtnID2 = 2;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7469u);
		this.AllTextObject[18] = component;
		component2 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 1;
		component2.m_BtnID2 = 3;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7475u);
		this.AllTextObject[19] = component;
		component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[21] = component;
		component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[22] = component;
		component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[23] = component;
		component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[24] = component;
		component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[25] = component;
		component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[26] = component;
		component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(5).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[27] = component;
		component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(7).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7479u);
		this.AllTextObject[28] = component;
		component2 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(8).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 4;
		component2.m_BtnID2 = 2;
		component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(8).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[29] = component;
		component2 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(8).GetChild(1).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 4;
		component2.m_BtnID2 = 2;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(8).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7464u);
		this.AllTextObject[30] = component;
		component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(3).GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.resizeTextMaxSize = 18;
		component.text = string.Empty;
		this.AllTextObject[31] = component;
		component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(3).GetChild(1).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.fontSize = 16;
		component.text = string.Empty;
		this.AllTextObject[32] = component;
		component2 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(4).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 4;
		component2.m_BtnID2 = 1;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(4).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7471u);
		this.AllTextObject[34] = component;
		UILEBtn component5 = this.AGS_Form.GetChild(9).GetChild(1).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		GUIManager.Instance.InitLordEquipImg(component5.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		component5.OnEquip.rectTransform.anchorMin = new Vector2(0.63f, 0.63f);
		component5.OnEquip.rectTransform.anchorMax = new Vector2(1f, 1f);
		component5.OnEquip.rectTransform.offsetMin = Vector2.zero;
		component5.OnEquip.rectTransform.offsetMax = Vector2.zero;
		component5.transition = Selectable.Transition.None;
		component2 = this.AGS_Form.GetChild(9).GetChild(2).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 3;
		component2.m_BtnID2 = 1;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(9).GetChild(2).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7534u);
		this.AllTextObject[35] = component;
		component = this.AGS_Form.GetChild(9).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[36] = component;
		this.AGS_ItemRare = this.AGS_Form.GetChild(9).GetChild(5).GetComponent<UISpritesArray>();
		component = this.AGS_Form.GetChild(9).GetChild(6).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[37] = component;
		component5 = this.AGS_Form.GetChild(9).GetChild(7).GetChild(0).GetChild(0).GetComponent<UILEBtn>();
		component5.m_Handler = this;
		component2 = this.AGS_Form.GetChild(9).GetChild(7).GetChild(0).GetChild(2).GetComponent<UIButton>();
		component2.m_Handler = this;
		component = this.AGS_Form.GetChild(9).GetChild(7).GetChild(0).GetChild(3).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[38] = component;
		component2 = this.AGS_Form.GetChild(9).GetChild(8).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 3;
		component2.m_BtnID2 = 2;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(9).GetChild(8).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7475u);
		this.AllTextObject[39] = component;
		component3 = this.AGS_Form.GetChild(9).GetChild(8).GetChild(2).GetComponent<Image>();
		component3.sprite = this.door.LoadSprite("UI_main_redbox_01");
		component3.material = this.door.LoadMaterial();
		component3.type = Image.Type.Sliced;
		component3 = this.AGS_Form.GetChild(9).GetChild(8).GetChild(2).GetChild(0).GetComponent<Image>();
		component3.sprite = this.door.LoadSprite("UI_main_mess_ex");
		component3.material = this.door.LoadMaterial();
		component2 = this.AGS_Form.GetChild(9).GetChild(9).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 3;
		component2.m_BtnID2 = 3;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(9).GetChild(9).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7474u);
		this.AllTextObject[40] = component;
		this.AGS_ScrollPanel2 = this.AGS_Form.GetChild(9).GetChild(10).GetComponent<ScrollPanel>();
		component = this.AGS_Form.GetChild(9).GetChild(11).GetChild(0).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[41] = component;
		component = this.AGS_Form.GetChild(9).GetChild(11).GetChild(0).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[42] = component;
		component = this.AGS_Form.GetChild(9).GetChild(11).GetChild(1).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[43] = component;
		component2 = this.AGS_Form.GetChild(9).GetChild(11).GetChild(1).GetChild(2).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 100;
		component2.transition = Selectable.Transition.None;
		UIButtonHint uibuttonHint = component2.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		component = this.AGS_Form.GetChild(9).GetChild(12).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7476u);
		this.AllTextObject[44] = component;
		component2 = this.AGS_Form.GetChild(10).GetComponent<UIButton>();
		UnityEngine.Object.Destroy(component2);
		HelperUIButton helperUIButton = this.AGS_Form.GetChild(10).gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID1 = 0;
		helperUIButton.m_BtnID2 = 1;
		IgnoreRaycast component6 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(0).GetComponent<IgnoreRaycast>();
		UnityEngine.Object.Destroy(component6);
		component2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(1).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 0;
		component2.m_BtnID2 = 1;
		component2.m_EffectType = e_EffectType.e_Scale;
		component5 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(2).GetComponent<UILEBtn>();
		GUIManager.Instance.InitLordEquipImg(component5.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		component5.m_Handler = this;
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[45] = component;
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(4).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[46] = component;
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(8).GetChild(0).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.resizeTextMaxSize = 18;
		component.text = string.Empty;
		this.AllTextObject[47] = component;
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(8).GetChild(0).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.resizeTextMaxSize = 18;
		component.text = string.Empty;
		this.AllTextObject[48] = component;
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(8).GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.fontSize = 16;
		component.text = string.Empty;
		this.AllTextObject[49] = component;
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7465u);
		this.AllTextObject[50] = component;
		component5 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(2).GetComponent<UILEBtn>();
		GUIManager.Instance.InitLordEquipImg(component5.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, true, true, 0, 0, 0, 0, 0, false);
		component5.m_Handler = this;
		component5.m_BtnID1 = 3;
		component5.m_BtnID2 = 1;
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(2).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[51] = component;
		component5 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(3).GetComponent<UILEBtn>();
		GUIManager.Instance.InitLordEquipImg(component5.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, true, true, 0, 0, 0, 0, 0, false);
		component5.m_Handler = this;
		component5.m_BtnID1 = 3;
		component5.m_BtnID2 = 2;
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(3).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[52] = component;
		component5 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(4).GetComponent<UILEBtn>();
		GUIManager.Instance.InitLordEquipImg(component5.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, true, true, 0, 0, 0, 0, 0, false);
		component5.m_Handler = this;
		component5.m_BtnID1 = 3;
		component5.m_BtnID2 = 3;
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(4).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[53] = component;
		component5 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(5).GetComponent<UILEBtn>();
		GUIManager.Instance.InitLordEquipImg(component5.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, true, true, 0, 0, 0, 0, 0, false);
		component5.m_Handler = this;
		component5.m_BtnID1 = 3;
		component5.m_BtnID2 = 4;
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(5).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[54] = component;
		component5 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(6).GetComponent<UILEBtn>();
		GUIManager.Instance.InitLordEquipImg(component5.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, true, true, 0, 0, 0, 0, 0, false);
		component5.m_Handler = this;
		component5.m_BtnID1 = 3;
		component5.m_BtnID2 = 5;
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(6).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[55] = component;
		this.LightBox1 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(7).GetChild(0).GetComponent<Image>();
		this.LightBox2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(7).GetChild(1).GetComponent<Image>();
		this.Flash = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(7).GetChild(3).GetComponent<Image>();
		this.MaterialLight = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(7).GetComponent<Image>();
		this.arrowPos = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(7).GetChild(2).GetComponent<RectTransform>();
		component2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(10).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(10).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(7450u);
		this.AllTextObject[56] = component;
		component2.m_BtnID1 = 5;
		component2.m_BtnID2 = 2;
		component2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(11).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(11).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[57] = component;
		component2.m_BtnID1 = 5;
		component2.m_BtnID2 = 1;
		component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(12).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[58] = component;
		component2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(14).GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 9;
		component2.m_BtnID2 = 1;
		component2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(14).GetChild(4).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 9;
		component2.m_BtnID2 = 2;
		component = this.AGS_Form.GetChild(12).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[59] = component;
		this.BestHeight = component;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			component4 = this.AGS_Form.GetChild(10).GetComponent<RectTransform>();
			component4.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			component4.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		component3 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(14).GetChild(8).GetComponent<Image>();
		component3.sprite = this.door.LoadSprite("UI_main_redbox_01");
		component3.material = this.door.LoadMaterial();
		component3.type = Image.Type.Sliced;
		component3 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(14).GetChild(8).GetChild(0).GetComponent<Image>();
		component3.sprite = this.door.LoadSprite("UI_main_mess_ex");
		component3.material = this.door.LoadMaterial();
		this.AGS_Form.GetChild(10).GetChild(0).GetChild(14).GetChild(8).gameObject.SetActive(false);
		this.POPLight1 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(14).GetChild(1).GetComponent<Image>();
		this.POPLight3 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(14).GetChild(5).GetComponent<Image>();
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.AGS_Form.GetChild(7).gameObject);
		this.Select = gameObject.GetComponent<RectTransform>();
		this.Select.gameObject.SetActive(false);
		gameObject = (GameObject)UnityEngine.Object.Instantiate(this.AGS_Form.GetChild(11).gameObject);
		this.Forging = gameObject.GetComponent<RectTransform>();
		this.Forging.gameObject.SetActive(false);
		this.Forging.GetComponent<Image>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 120);
		this.AGS_Forging = this.Forging.GetChild(0).GetComponent<UISpritesArray>();
		this.LightBox1.color = new Color(1f, 1f, 1f, 0f);
		this.LightBox2.color = new Color(1f, 1f, 1f, 0f);
		this.Flash.color = new Color(1f, 1f, 1f, 0f);
		this.SetOpenStat(UILordEquip.eUIOpenStat.None, UILordEquip.eCollectType.None);
		LordEquipData.CheckEquipExpired();
	}

	// Token: 0x06001DC6 RID: 7622 RVA: 0x0037A584 File Offset: 0x00378784
	public void Refresh_FontTexture()
	{
		for (int i = 0; i < this.AllTextObject.Length; i++)
		{
			if (this.AllTextObject[i] != null && this.AllTextObject[i].gameObject.activeInHierarchy)
			{
				this.AllTextObject[i].enabled = false;
				this.AllTextObject[i].enabled = true;
			}
		}
		if (this.AGS_ScrollArea != null && this.AGS_ScrollArea.gameObject.activeInHierarchy && this.AGS_ScrollArea.transform.childCount > 1)
		{
			Transform child = this.AGS_ScrollArea.transform.GetChild(0);
			int num = 0;
			while (num < child.childCount && num < 6)
			{
				Transform child2 = child.GetChild(num);
				if (child2.gameObject.activeInHierarchy)
				{
					if (child2.GetChild(0).gameObject.activeInHierarchy)
					{
						for (int j = 0; j < 4; j++)
						{
							LordEquipData.ResetLordEquipFont(child2.GetChild(0).GetChild(j));
						}
					}
					if (child2.GetChild(1).gameObject.activeInHierarchy)
					{
						UIText component = child2.GetChild(1).GetChild(2).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
					}
				}
				num++;
			}
		}
		if (this.AGS_ScrollPanel != null && this.AGS_ScrollPanel.gameObject.activeInHierarchy && this.AGS_ScrollPanel.transform.childCount > 1)
		{
			Transform child3 = this.AGS_ScrollPanel.transform.GetChild(0);
			for (int k = 0; k < child3.childCount; k++)
			{
				Transform child4 = child3.GetChild(k);
				if (child4.gameObject.activeInHierarchy)
				{
					if (child4.GetChild(0).gameObject.activeInHierarchy)
					{
						UIText component = child4.GetChild(0).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
					}
					if (child4.GetChild(1).gameObject.activeInHierarchy)
					{
						UIText component = child4.GetChild(1).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
					}
				}
			}
		}
		if (this.AGS_ScrollPanel2 != null && this.AGS_ScrollPanel2.gameObject.activeInHierarchy && this.AGS_ScrollPanel2.transform.childCount > 1)
		{
			Transform child5 = this.AGS_ScrollPanel2.transform.GetChild(0);
			for (int l = 0; l < child5.childCount; l++)
			{
				Transform child6 = child5.GetChild(l);
				if (child6.gameObject.activeInHierarchy)
				{
					if (child6.GetChild(0).GetChild(1).gameObject.activeInHierarchy)
					{
						UIText component = child6.GetChild(0).GetChild(1).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
					}
					if (child6.GetChild(0).GetChild(2).gameObject.activeInHierarchy)
					{
						UIText component = child6.GetChild(0).GetChild(2).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
					}
					if (child6.GetChild(1).GetChild(2).gameObject.activeInHierarchy)
					{
						UIText component = child6.GetChild(1).GetChild(2).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
					}
				}
			}
		}
		if (this.POPScrollPanel != null && this.POPScrollPanel.gameObject.activeInHierarchy && this.POPScrollPanel.transform.childCount > 1)
		{
			Transform child7 = this.POPScrollPanel.transform.GetChild(0);
			for (int m = 0; m < child7.childCount; m++)
			{
				Transform child8 = child7.GetChild(m);
				if (child8.gameObject.activeInHierarchy)
				{
					if (child8.GetChild(0).GetChild(0).gameObject.activeInHierarchy)
					{
						UIText component = child8.GetChild(0).GetChild(0).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
					}
					if (child8.GetChild(0).GetChild(1).gameObject.activeInHierarchy)
					{
						UIText component = child8.GetChild(0).GetChild(1).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
					}
					if (child8.GetChild(1).GetChild(0).gameObject.activeInHierarchy)
					{
						UIText component = child8.GetChild(1).GetChild(0).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
					}
				}
			}
		}
		if (this.NewGemPanel != null && this.NewGemPanel.gameObject.activeInHierarchy && this.NewGemPanel.transform.childCount > 1)
		{
			Transform child9 = this.NewGemPanel.transform.GetChild(0);
			for (int n = 0; n < child9.childCount; n++)
			{
				Transform child10 = child9.GetChild(n);
				if (child10.gameObject.activeInHierarchy)
				{
					if (child10.GetChild(0).gameObject.activeInHierarchy)
					{
						UIText component = child10.GetChild(0).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
					}
					if (child10.GetChild(1).gameObject.activeInHierarchy)
					{
						UIText component = child10.GetChild(1).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
					}
				}
			}
		}
	}

	// Token: 0x06001DC7 RID: 7623 RVA: 0x0037AC50 File Offset: 0x00378E50
	private void AfterLoader()
	{
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_ScrollArea = this.AGS_Form.GetChild(5).GetComponent<ScrollPanel>();
		UILEBtn component = this.AGS_Form.GetChild(6).GetChild(0).GetChild(0).GetComponent<UILEBtn>();
		component.m_Handler = this;
		GUIManager.Instance.InitLordEquipImg(component.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, this.OpenKind == eUI_LordEquipOpenKind.Collection, true, 0, 0, 0, 0, 0, false);
		component.transition = Selectable.Transition.None;
		Vector2 anchoredPosition = component.GetComponent<RectTransform>().anchoredPosition;
		RectTransform component2;
		for (int i = 1; i < 4; i++)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(component.gameObject);
			component2 = gameObject.GetComponent<RectTransform>();
			component2.SetParent(component.transform.parent, false);
			component2.anchoredPosition = new Vector2(anchoredPosition.x + (float)(i * 117), anchoredPosition.y);
		}
		Transform child = this.AGS_Form.GetChild(6).GetChild(0).GetChild(1);
		child.SetAsLastSibling();
		component2 = child.GetComponent<RectTransform>();
		component2.localScale = new Vector3(0.8f, 0.8f);
		component2.anchoredPosition = new Vector2(60f, 26f);
		anchoredPosition = component2.anchoredPosition;
		for (int j = 1; j < 4; j++)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(child.gameObject);
			component2 = gameObject.GetComponent<RectTransform>();
			component2.SetParent(component.transform.parent, false);
			component2.anchoredPosition = new Vector2(anchoredPosition.x + (float)(j * 117), anchoredPosition.y);
		}
		component.ReLinkScale();
		component = this.AGS_Form.GetChild(9).GetChild(7).GetChild(0).GetChild(0).GetComponent<UILEBtn>();
		component.m_Handler = this;
		component.m_BtnID1 = 2;
		component.m_BtnID2 = 1;
		UIButton component3 = this.AGS_Form.GetChild(9).GetChild(7).GetChild(0).GetChild(2).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 2;
		component3.m_BtnID2 = 1;
		component3.m_EffectType = e_EffectType.e_Scale;
		UISpritesArray component4 = this.AGS_Form.GetChild(9).GetChild(7).GetChild(0).GetChild(2).GetComponent<UISpritesArray>();
		component4.m_Image = component3.image;
		UIText component5 = this.AGS_Form.GetChild(9).GetChild(7).GetChild(0).GetChild(3).GetComponent<UIText>();
		component5.font = ttffont;
		component5.text = this.DM.mStringTable.GetStringByID(7481u);
		GUIManager.Instance.InitLordEquipImg(component.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, true, true, 0, 0, 0, 0, 0, false);
		anchoredPosition = component.transform.parent.GetComponent<RectTransform>().anchoredPosition;
		for (int k = 1; k < 4; k++)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(component.transform.parent.gameObject);
			component2 = gameObject.transform.GetComponent<RectTransform>();
			component2.SetParent(component.transform.parent.parent, false);
			component2.anchoredPosition = new Vector2(anchoredPosition.x + (float)(k * 151), anchoredPosition.y);
			component = component2.GetChild(0).GetComponent<UILEBtn>();
			component.m_Handler = this;
			component.m_BtnID1 = 2;
			component.m_BtnID2 = k + 1;
			component3 = component2.GetChild(2).GetComponent<UIButton>();
			component3.m_Handler = this;
			component3.m_BtnID1 = 2;
			component3.m_BtnID2 = k + 1;
			component4 = component2.GetChild(2).GetComponent<UISpritesArray>();
			component4.m_Image = component3.image;
		}
		component2 = component.GetComponent<RectTransform>();
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 124f);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 124f);
		component2.anchoredPosition = new Vector2(component2.anchoredPosition.x, 22f);
		this.AGS_ScrollArea.IntiScrollPanel(488f, 0f, 0f, this.SPHeight, 6, this);
		this.ScrollArea_RT = this.AGS_ScrollArea.transform.GetChild(0).GetComponent<RectTransform>();
		this.Select.SetParent(this.AGS_ScrollArea.transform.GetChild(0), false);
		this.Forging.SetParent(this.AGS_ScrollArea.transform.GetChild(0), false);
		this.SelectLight = this.Select.GetComponent<Image>();
		this.AGS_ScrollPanel.IntiScrollPanel(273f, 0f, 0f, this.SPHeight, 10, this);
		this.AGS_ScrollPanel2.IntiScrollPanel(228f, 0f, 0f, this.SPHeight, 10, this);
		this.POPScrollPanel = this.AGS_Form.GetChild(10).GetChild(0).GetChild(7).GetComponent<ScrollPanel>();
		this.POPScrollPanel.IntiScrollPanel(180f, 0f, 0f, this.SPHeight, 7, this);
		this.NewGemPanel = this.AGS_Form.GetChild(8).GetChild(2).GetChild(3).GetChild(0).GetComponent<ScrollPanel>();
		this.NewGemPanel.IntiScrollPanel(300f, 0f, 0f, this.SPHeight, 11, this);
		switch (UILordEquip.waitForReturn)
		{
		case eUI_LordEquipReturnKind.CollectionFilter:
			UILordEquip.EquipFilter = (int)UIEffectFilter.SeletedFilter;
			this.isFocused = false;
			UILordEquip.EquipFocus = 0;
			UILordEquip.EquipFocusSub = 0;
			this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.None);
			break;
		case eUI_LordEquipReturnKind.GemEffectFilter:
			if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO != 0u)
			{
				this.SetOpenStat(UILordEquip.eUIOpenStat.GemSelect, UILordEquip.eCollectType.None);
				component2 = this.AGS_Form.GetChild(9).GetChild(1).GetComponent<RectTransform>();
				GUIManager.Instance.ChangeLordEquipImg(component2, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus], eLordEquipDisplayKind.OnlyItem, this.DM.mLordEquip.isRoleEquipThis(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO));
				UILEBtn component6 = component2.GetComponent<UILEBtn>();
				if (component6 != null)
				{
					component6.SetCountdown(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ExpireTime, false);
				}
			}
			else
			{
				this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.None);
			}
			break;
		case eUI_LordEquipReturnKind.ItemInfo:
			this.SetOpenStat(UILordEquip.eUIOpenStat.ItemInfo, UILordEquip.eCollectType.None);
			break;
		case eUI_LordEquipReturnKind.Collection_Gem:
			this.isFocused = false;
			UILordEquip.EquipFocus = 0;
			UILordEquip.EquipFocusSub = 0;
			this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.Gem);
			break;
		case eUI_LordEquipReturnKind.Collection_Mat:
			this.isFocused = false;
			UILordEquip.EquipFocus = 0;
			UILordEquip.EquipFocusSub = 0;
			this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.Material);
			break;
		case eUI_LordEquipReturnKind.Collection_NewGem:
			this.isFocused = false;
			UILordEquip.EquipFocus = 0;
			UILordEquip.EquipFocusSub = 0;
			this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.newGem);
			break;
		default:
			this.isFocused = false;
			UILordEquip.EquipFocus = 0;
			UILordEquip.EquipFocusSub = 0;
			this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.None);
			break;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001DC8 RID: 7624 RVA: 0x0037B3A0 File Offset: 0x003795A0
	public override void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.TitleText);
		StringManager.Instance.DeSpawnString(this.NoContentText);
		StringManager.Instance.DeSpawnString(this.ItemNameText);
		StringManager.Instance.DeSpawnString(this.ItemLevelText);
		StringManager.Instance.DeSpawnString(this.PopUpHeaderText);
		StringManager.Instance.DeSpawnString(this.TimedItemCountText);
		for (int i = 0; i < this.GemBtnText.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.GemBtnText[i]);
		}
		for (int j = 0; j < this.EffDescText.Length; j++)
		{
			StringManager.Instance.DeSpawnString(this.EffDescText[j]);
		}
		for (int k = 0; k < this.PopupEffectText.Length; k++)
		{
			StringManager.Instance.DeSpawnString(this.PopupEffectText[k]);
		}
		for (int l = 0; l < this.PopupAmountText.Length; l++)
		{
			StringManager.Instance.DeSpawnString(this.PopupAmountText[l]);
		}
		UILordEquip.waitForReturn = eUI_LordEquipReturnKind.None;
	}

	// Token: 0x06001DC9 RID: 7625 RVA: 0x0037B4CC File Offset: 0x003796CC
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (this.OpenStat)
		{
		case UILordEquip.eUIOpenStat.None:
		case UILordEquip.eUIOpenStat.PostSetStat:
			this.OpenStat = UILordEquip.eUIOpenStat.PostSetStat;
			return;
		case UILordEquip.eUIOpenStat.Normal:
			if (this.OpenKind == eUI_LordEquipOpenKind.Collection)
			{
				switch (this.CollectType)
				{
				case UILordEquip.eCollectType.Equip:
					UILordEquip.EquipTopIdx = this.AGS_ScrollArea.GetTopIdx();
					UILordEquip.EquipTopPos = this.ScrollArea_RT.anchoredPosition.y;
					break;
				case UILordEquip.eCollectType.Gem:
					UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
					UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
					break;
				case UILordEquip.eCollectType.Material:
					UILordEquip.MatTopIdx = this.AGS_ScrollArea.GetTopIdx();
					UILordEquip.MatTopPos = this.ScrollArea_RT.anchoredPosition.y;
					break;
				case UILordEquip.eCollectType.newGem:
					UILordEquip.NewGemTopIdx = this.AGS_ScrollArea.GetTopIdx();
					UILordEquip.NewGemTopPos = this.ScrollArea_RT.anchoredPosition.y;
					break;
				}
			}
			if ((this.OpenKind == eUI_LordEquipOpenKind.SelectSolt || this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt) && arg2 == 1)
			{
				this.OnStartSelect = true;
				if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ItemID == 0)
				{
					this.Select.gameObject.SetActive(false);
				}
			}
			this.SetMainFilter(this.FilterKind);
			break;
		case UILordEquip.eUIOpenStat.ItemInfo:
			if (arg1 == 1)
			{
				this.SetOpenStat(this.OpenStat, UILordEquip.eCollectType.None);
			}
			break;
		case UILordEquip.eUIOpenStat.GemSelect:
			if (arg1 == 2)
			{
				this.SetMainFilter(this.FilterKind);
			}
			if (arg1 == 1 && this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ItemID == 0)
			{
				this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.None);
			}
			break;
		case UILordEquip.eUIOpenStat.GemCombine:
			if (arg1 == 2)
			{
				this.SetMainFilter(this.FilterKind);
			}
			break;
		case UILordEquip.eUIOpenStat.MaterialCombine:
			if (arg1 == 3)
			{
				this.SetMainFilter(this.FilterKind);
			}
			break;
		}
		if (this.AGS_Form.GetChild(10).gameObject.activeInHierarchy)
		{
			this.SetPopup(this.PopupKind, this.PopUpColor, this.combineColor);
			if (arg2 == 1)
			{
				this.MaterialFlash = true;
			}
		}
		this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(this.DM.mLordEquip.isEquipEvoReady);
	}

	// Token: 0x06001DCA RID: 7626 RVA: 0x0037B774 File Offset: 0x00379974
	public override void UpdateNetwork(byte[] meg)
	{
		if (this.OpenStat == UILordEquip.eUIOpenStat.None)
		{
			return;
		}
		if (this.OpenStat == UILordEquip.eUIOpenStat.PostSetStat)
		{
			return;
		}
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
			switch (this.OpenKind)
			{
			case eUI_LordEquipOpenKind.SelectSolt:
			case eUI_LordEquipOpenKind.SelectSetSolt:
				this.door.CloseMenu(false);
				break;
			case eUI_LordEquipOpenKind.Collection:
				switch (this.CollectType)
				{
				case UILordEquip.eCollectType.Equip:
					UILordEquip.EquipTopIdx = this.AGS_ScrollArea.GetTopIdx();
					UILordEquip.EquipTopPos = this.ScrollArea_RT.anchoredPosition.y;
					this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.None);
					break;
				case UILordEquip.eCollectType.Gem:
					UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
					UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
					this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.Gem);
					break;
				case UILordEquip.eCollectType.Material:
					UILordEquip.MatTopIdx = this.AGS_ScrollArea.GetTopIdx();
					UILordEquip.MatTopPos = this.ScrollArea_RT.anchoredPosition.y;
					this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.Material);
					break;
				case UILordEquip.eCollectType.newGem:
					UILordEquip.NewGemTopIdx = this.AGS_ScrollArea.GetTopIdx();
					UILordEquip.NewGemTopPos = this.ScrollArea_RT.anchoredPosition.y;
					this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.newGem);
					break;
				}
				break;
			case eUI_LordEquipOpenKind.CombineSelect:
				this.door.CloseMenu(false);
				break;
			}
		}
	}

	// Token: 0x06001DCB RID: 7627 RVA: 0x0037B90C File Offset: 0x00379B0C
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		switch (btnID)
		{
		case 0:
		{
			int btnID2 = sender.m_BtnID2;
			if (btnID2 != 0)
			{
				if (btnID2 == 1)
				{
					this.AGS_Form.GetChild(10).gameObject.SetActive(false);
					this.PopupKind = UILordEquip.eUIOpenStat.None;
				}
			}
			else
			{
				switch (this.OpenStat)
				{
				case UILordEquip.eUIOpenStat.Normal:
					if (this.OpenKind == eUI_LordEquipOpenKind.Collection)
					{
						switch (this.CollectType)
						{
						case UILordEquip.eCollectType.Equip:
							UILordEquip.EquipTopIdx = this.AGS_ScrollArea.GetTopIdx();
							UILordEquip.EquipTopPos = this.ScrollArea_RT.anchoredPosition.y;
							break;
						case UILordEquip.eCollectType.Gem:
							UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
							UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
							break;
						case UILordEquip.eCollectType.Material:
							UILordEquip.MatTopIdx = this.AGS_ScrollArea.GetTopIdx();
							UILordEquip.MatTopPos = this.ScrollArea_RT.anchoredPosition.y;
							break;
						}
					}
					this.door.CloseMenu(false);
					break;
				case UILordEquip.eUIOpenStat.ItemInfo:
					this.isCollectChange = true;
					this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.None);
					break;
				case UILordEquip.eUIOpenStat.GemSelect:
				case UILordEquip.eUIOpenStat.newGemSelect:
					this.Select.gameObject.SetActive(false);
					UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
					UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
					this.SetOpenStat(UILordEquip.eUIOpenStat.ItemInfo, UILordEquip.eCollectType.None);
					break;
				}
			}
			break;
		}
		case 1:
			switch (sender.m_BtnID2)
			{
			case 1:
				if (!this.isFocused)
				{
					return;
				}
				if (this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt && this.DM.RoleAttr.LordEquipEventData.ItemID != 0 && this.DM.RoleAttr.LordEquipEventData.SerialNO != 0u && this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO == this.DM.RoleAttr.LordEquipEventData.SerialNO)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(261u), 255, true);
					return;
				}
				this.SetOpenStat(UILordEquip.eUIOpenStat.ItemInfo, UILordEquip.eCollectType.None);
				break;
			case 2:
				if (!this.isFocused)
				{
					return;
				}
				if (this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt)
				{
					if (UILordEquipSetEdit.showingSet.SerialNO[UILordEquipSetEdit.ChangingIdx] == this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO)
					{
						UILordEquipSetEdit.showingSet.SerialNO[UILordEquipSetEdit.ChangingIdx] = 0u;
					}
					else
					{
						if (this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ItemID).NeedLv > this.DM.RoleAttr.Level)
						{
							GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7504u), 255, true);
							return;
						}
						UILordEquipSetEdit.showingSet.SerialNO[UILordEquipSetEdit.ChangingIdx] = this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO;
					}
					this.door.CloseMenu(false);
				}
				else if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO == LordEquipData.RoleEquipSerial[(int)(this.EquipSolt - 1)])
				{
					this.DM.mLordEquip.ChangeEquip(this.EquipSolt - 1, 0u);
				}
				else
				{
					if (this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ItemID).NeedLv > this.DM.RoleAttr.Level)
					{
						GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7504u), 255, true);
						return;
					}
					this.DM.mLordEquip.ChangeEquip(this.EquipSolt - 1, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO);
				}
				break;
			case 3:
				if (!this.isFocused)
				{
					return;
				}
				UIAnvil.OpenKind = eUI_Anvil_OpenKind.UpgradeItem;
				UIAnvil.preSetIndex = UILordEquip.EquipFocus;
				this.door.CloseMenu(false);
				break;
			}
			break;
		case 2:
			if (sender.m_BtnID2 == 4)
			{
				this.InlayNewGem();
			}
			else if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Gem[sender.m_BtnID2 - 1] == 0)
			{
				UILordEquip.EquipFocusSub = (ushort)((byte)(sender.m_BtnID2 - 1));
				this.isCollectChange = true;
				this.SetOpenStat(UILordEquip.eUIOpenStat.GemSelect, UILordEquip.eCollectType.None);
			}
			else
			{
				GUIManager.Instance.OpenGemRemoveUI(UILordEquip.EquipFocus, (byte)(sender.m_BtnID2 - 1));
				UILordEquip.waitForReturn = eUI_LordEquipReturnKind.ItemInfo;
			}
			break;
		case 3:
			switch (sender.m_BtnID2)
			{
			case 1:
				if (this.EquipOrTakeDown())
				{
					this.door.ClearWindowStack();
					this.door.OpenMenu(EGUIWindow.UI_LordInfo, 1, 0, true);
				}
				break;
			case 2:
				UIAnvil.preSetIndex = UILordEquip.EquipFocus;
				UIAnvil.SetOpen(eUI_Anvil_OpenKind.UpgradeItem, 0, 0);
				break;
			case 3:
				if (!this.isAbleDecompose((int)UILordEquip.EquipFocus, true))
				{
					return;
				}
				GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(7490u), this.DM.mStringTable.GetStringByID(7491u), 1, 0, null, null);
				break;
			case 4:
			{
				this.OpenTechTree = 227;
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.ClearString();
				TechDataTbl recordByKey = DataManager.Instance.TechData.GetRecordByKey(this.OpenTechTree);
				cstring.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.TechName));
				cstring.AppendFormat(this.DM.mStringTable.GetStringByID(16129u));
				GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(7475u), cstring.ToString(), this.DM.mStringTable.GetStringByID(156u), this, 2, 0, true, false, false, false, false);
				break;
			}
			}
			break;
		case 4:
			switch (sender.m_BtnID2)
			{
			case 1:
				if (!this.Select.gameObject.activeInHierarchy)
				{
					return;
				}
				UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
				UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
				if (this.isAbleToImbueGame((int)UILordEquip.EquipFocus, this.DM.mLordEquip.LEGem[(int)this.MaterialFocus].ItemID, (byte)UILordEquip.EquipFocusSub))
				{
					this.DM.mLordEquip.InlayGem(this.DM.mLordEquip.LEGem[(int)this.MaterialFocus].ItemID, this.DM.mLordEquip.LEGem[(int)this.MaterialFocus].Color, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO, (byte)UILordEquip.EquipFocusSub);
					this.Select.gameObject.SetActive(false);
					this.SetOpenStat(UILordEquip.eUIOpenStat.ItemInfo, UILordEquip.eCollectType.None);
				}
				else
				{
					this.SetOpenStat(UILordEquip.eUIOpenStat.ItemInfo, UILordEquip.eCollectType.None);
				}
				break;
			case 2:
				this.door.OpenMenu(EGUIWindow.UI_EffectFilter, 1, (int)UIEffectFilter.SeletedFilter, false);
				UILordEquip.waitForReturn = eUI_LordEquipReturnKind.GemEffectFilter;
				break;
			case 3:
				if (!this.Select.gameObject.activeInHierarchy)
				{
					return;
				}
				UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
				UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
				if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Gem[3] == 0)
				{
					Equip recordByKey2 = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LEGem[(int)this.MaterialFocus].ItemID);
					for (int i = 0; i < 3; i++)
					{
						if (recordByKey2.NewGemEffect[i] != 0)
						{
							SpecialEffect recordByKey3 = this.DM.SpecialEffectTable.GetRecordByKey(recordByKey2.NewGemEffect[i]);
							byte newGemEffectID = recordByKey3.NewGemEffectID;
							if (newGemEffectID == 1)
							{
								if (recordByKey3.ColorEffect[(int)(this.DM.mLordEquip.LEGem[(int)this.MaterialFocus].Color - 1)] < (ushort)this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Color)
								{
									GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(614u), this.DM.mStringTable.GetStringByID(16132u), 3, 0, null, null);
									return;
								}
							}
						}
					}
					this.DM.mLordEquip.InlayGem(this.DM.mLordEquip.LEGem[(int)this.MaterialFocus].ItemID, this.DM.mLordEquip.LEGem[(int)this.MaterialFocus].Color, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO, (byte)UILordEquip.EquipFocusSub);
					this.Select.gameObject.SetActive(false);
					this.SetOpenStat(UILordEquip.eUIOpenStat.ItemInfo, UILordEquip.eCollectType.None);
				}
				else
				{
					this.SetOpenStat(UILordEquip.eUIOpenStat.ItemInfo, UILordEquip.eCollectType.None);
				}
				break;
			}
			break;
		case 5:
		{
			int btnID2 = sender.m_BtnID2;
			if (btnID2 != 1)
			{
				if (btnID2 != 2)
				{
					this.AGS_Form.GetChild(10).gameObject.SetActive(false);
					this.PopupKind = UILordEquip.eUIOpenStat.None;
				}
				else if (this.isCombine)
				{
					int num = (int)LordEquipData.getItemQuantity(this.combineItemID, this.combineColor - 1);
					if (num < 4)
					{
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455u), 255, true);
						return;
					}
					num = (int)((ushort)(num / 4));
					if ((int)this.MaterCount[(int)(this.combineColor - 1)] + num > 65535)
					{
						num = (int)(ushort.MaxValue - this.MaterCount[(int)(this.combineColor - 1)]);
						if (num < 1)
						{
							GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7524u), 255, true);
							return;
						}
					}
					this.DM.mLordEquip.upgradeMaterial(this.combineItemID, this.combineColor, (ushort)num);
				}
				else
				{
					int num = (int)LordEquipData.getItemQuantity(this.combineItemID, this.combineColor + 1);
					if (num < 1)
					{
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455u), 255, true);
						return;
					}
					if ((int)this.MaterCount[(int)(this.combineColor - 1)] + num * 4 > 65535)
					{
						num = (int)((ushort.MaxValue - this.MaterCount[(int)(this.combineColor - 1)]) / 4);
						if (num < 1)
						{
							GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7509u), 255, true);
							return;
						}
					}
					this.DM.mLordEquip.DeComposeMaterial(this.combineItemID, this.combineColor + 1, (ushort)num);
				}
			}
			else
			{
				UILordEquip.eUIOpenStat popupKind = this.PopupKind;
				if (popupKind != UILordEquip.eUIOpenStat.GemCombine && popupKind != UILordEquip.eUIOpenStat.MaterialCombine)
				{
					this.AGS_Form.GetChild(10).gameObject.SetActive(false);
					this.PopupKind = UILordEquip.eUIOpenStat.None;
				}
				else if (this.isCombine)
				{
					int num = (int)LordEquipData.getItemQuantity(this.combineItemID, this.combineColor - 1);
					if (num < 4)
					{
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455u), 255, true);
						return;
					}
					if (this.MaterCount[(int)(this.combineColor - 1)] + 1 > 65535)
					{
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7524u), 255, true);
						return;
					}
					this.DM.mLordEquip.upgradeMaterial(this.combineItemID, this.combineColor, 1);
				}
				else
				{
					int num = (int)LordEquipData.getItemQuantity(this.combineItemID, this.combineColor + 1);
					if (num < 1)
					{
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455u), 255, true);
						return;
					}
					if (this.MaterCount[(int)(this.combineColor - 1)] + 4 > 65535)
					{
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7509u), 255, true);
						return;
					}
					this.DM.mLordEquip.DeComposeMaterial(this.combineItemID, this.combineColor + 1, 1);
				}
			}
			break;
		}
		case 6:
		{
			int btnID2 = sender.m_BtnID2;
			switch (btnID2)
			{
			case 1:
			case 2:
			case 3:
			case 4:
				switch (this.CollectType)
				{
				case UILordEquip.eCollectType.Equip:
					UILordEquip.EquipTopIdx = this.AGS_ScrollArea.GetTopIdx();
					UILordEquip.EquipTopPos = this.ScrollArea_RT.anchoredPosition.y;
					break;
				case UILordEquip.eCollectType.Gem:
					UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
					UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
					break;
				case UILordEquip.eCollectType.Material:
					UILordEquip.MatTopIdx = this.AGS_ScrollArea.GetTopIdx();
					UILordEquip.MatTopPos = this.ScrollArea_RT.anchoredPosition.y;
					break;
				case UILordEquip.eCollectType.newGem:
					UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
					UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
					break;
				}
				this.SetCollectType((UILordEquip.eCollectType)sender.m_BtnID2);
				break;
			default:
				if (btnID2 != 101)
				{
					if (btnID2 == 102)
					{
						switch (this.CollectType)
						{
						case UILordEquip.eCollectType.Equip:
							UILordEquip.EquipTopIdx = this.AGS_ScrollArea.GetTopIdx();
							UILordEquip.EquipTopPos = this.ScrollArea_RT.anchoredPosition.y;
							break;
						case UILordEquip.eCollectType.Gem:
							UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
							UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
							break;
						case UILordEquip.eCollectType.Material:
							UILordEquip.MatTopIdx = this.AGS_ScrollArea.GetTopIdx();
							UILordEquip.MatTopPos = this.ScrollArea_RT.anchoredPosition.y;
							break;
						}
						if (this.CollectType == UILordEquip.eCollectType.Gem)
						{
							GUIManager.Instance.OpenItemKindFilterUI(18, 2, 0);
							UILordEquip.waitForReturn = eUI_LordEquipReturnKind.Collection_Gem;
						}
						else if (this.CollectType == UILordEquip.eCollectType.newGem)
						{
							GUIManager.Instance.OpenItemKindFilterUI(18, 3, 0);
							UILordEquip.waitForReturn = eUI_LordEquipReturnKind.Collection_NewGem;
						}
						else
						{
							GUIManager.Instance.OpenItemKindFilterUI(18, 1, 0);
							UILordEquip.waitForReturn = eUI_LordEquipReturnKind.Collection_Mat;
						}
					}
				}
				else
				{
					this.door.OpenMenu(EGUIWindow.UI_EffectFilter, 0, (int)this.FilterKind, false);
					UILordEquip.waitForReturn = eUI_LordEquipReturnKind.CollectionFilter;
				}
				break;
			}
			break;
		}
		case 7:
			GUIManager.Instance.UseOrSpend(2010, this.DM.mStringTable.GetStringByID(4957u), 0, 0, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
			break;
		case 8:
			if (GUIManager.Instance.BuildingData.GetBuildData(15, 0).Level < 1)
			{
				GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7533u), 255, true);
				return;
			}
			if (this.EquipSolt != 0)
			{
				this.DM.mLordEquip.ForgeItem_mEquip = (byte)Mathf.Clamp((int)this.EquipSolt, 1, 6);
				this.DM.mLordEquip.ForgeItem_mColor = 4;
				this.door.OpenMenu(EGUIWindow.UI_Forge_Item, 0, 0, false);
			}
			else
			{
				this.DM.mLordEquip.ForgeItem_mEquip = (byte)Mathf.Clamp((int)((byte)this.FilterKind), 1, 6);
				this.DM.mLordEquip.ForgeItem_mColor = 4;
				this.door.OpenMenu(EGUIWindow.UI_Forge_Item, 0, 0, false);
			}
			break;
		case 9:
		{
			int btnID2 = sender.m_BtnID2;
			if (btnID2 != 1)
			{
				if (btnID2 == 2)
				{
					this.isCombine = false;
					this.SetPopup(this.PopupKind, this.PopUpColor, this.combineColor);
				}
			}
			else
			{
				this.isCombine = true;
				this.SetPopup(this.PopupKind, this.PopUpColor, this.combineColor);
			}
			break;
		}
		default:
			if (btnID == 99)
			{
				switch (this.OpenKind)
				{
				case eUI_LordEquipOpenKind.SelectSolt:
					GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7505u), DataManager.Instance.mStringTable.GetStringByID(7527u), null, null, 0, 0, true, false);
					break;
				case eUI_LordEquipOpenKind.Collection:
					GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7404u), DataManager.Instance.mStringTable.GetStringByID(7526u), null, null, 0, 0, true, true);
					break;
				case eUI_LordEquipOpenKind.CombineSelect:
					GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7430u), DataManager.Instance.mStringTable.GetStringByID(7527u), null, null, 0, 0, true, false);
					break;
				}
			}
			break;
		}
	}

	// Token: 0x06001DCC RID: 7628 RVA: 0x0037CBD8 File Offset: 0x0037ADD8
	public void OnButtonDown(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 320f, 20, (int)sender.Parm1, 0, Vector2.zero, UIButtonHint.ePosition.Original);
	}

	// Token: 0x06001DCD RID: 7629 RVA: 0x0037CC0C File Offset: 0x0037AE0C
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(true);
	}

	// Token: 0x06001DCE RID: 7630 RVA: 0x0037CC20 File Offset: 0x0037AE20
	public void OnLEButtonClick(UILEBtn sender)
	{
		switch (sender.m_BtnID1)
		{
		case 1:
		{
			UILordEquip.eUIOpenStat openStat = this.OpenStat;
			switch (openStat)
			{
			case UILordEquip.eUIOpenStat.Normal:
				switch (this.OpenKind)
				{
				case eUI_LordEquipOpenKind.SelectSolt:
					if (this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO != LordEquipData.RoleEquipSerial[(int)(this.EquipSolt - 1)] && this.DM.mLordEquip.isRoleEquipThis(this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO))
					{
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7444u), 255, true);
						return;
					}
					if (this.DM.RoleAttr.LordEquipEventData.ItemID != 0 && this.DM.RoleAttr.LordEquipEventData.SerialNO == this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO)
					{
						return;
					}
					if (this.DM.mLordEquip.isRoleEquipThis(this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO))
					{
						GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7444u), 255, true);
					}
					this.Select.position = sender.transform.position;
					this.Select.gameObject.SetActive(true);
					UILordEquip.EquipFocus = (ushort)sender.m_BtnID2;
					this.isFocused = true;
					this.SetSideInfo();
					break;
				case eUI_LordEquipOpenKind.Collection:
					switch (this.FilterKind)
					{
					case UILordEquip.eItemFilterByKind.Gem:
					case UILordEquip.eItemFilterByKind.NewGem:
						this.MaterialFocus = (ushort)sender.m_BtnID2;
						this.combineItemID = this.DM.mLordEquip.LEGem[(int)this.MaterialFocus].ItemID;
						this.combineColor = this.DM.mLordEquip.LEGem[(int)this.MaterialFocus].Color;
						UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
						UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
						this.isCombine = true;
						this.SetOpenStat(UILordEquip.eUIOpenStat.GemCombine, UILordEquip.eCollectType.None);
						goto IL_40E;
					case UILordEquip.eItemFilterByKind.Material:
						this.MaterialFocus = (ushort)sender.m_BtnID2;
						this.combineItemID = this.DM.mLordEquip.LEMaterial[(int)this.MaterialFocus].ItemID;
						this.combineColor = this.DM.mLordEquip.LEMaterial[(int)this.MaterialFocus].Color;
						UILordEquip.MatTopIdx = this.AGS_ScrollArea.GetTopIdx();
						UILordEquip.MatTopPos = this.ScrollArea_RT.anchoredPosition.y;
						this.isCombine = true;
						this.SetOpenStat(UILordEquip.eUIOpenStat.MaterialCombine, UILordEquip.eCollectType.None);
						goto IL_40E;
					}
					if (this.DM.mLordEquip.LordEquip[sender.m_BtnID2].ItemID != 0)
					{
						UILordEquip.EquipTopIdx = this.AGS_ScrollArea.GetTopIdx();
						UILordEquip.EquipTopPos = this.ScrollArea_RT.anchoredPosition.y;
						if (this.DM.RoleAttr.LordEquipEventData.ItemID != 0 && this.DM.RoleAttr.LordEquipEventData.SerialNO == this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO)
						{
							UIAnvil.SetOpen(eUI_Anvil_OpenKind.NowForging, 0, 0);
						}
						UILordEquip.EquipFocus = (ushort)sender.m_BtnID2;
						this.isFocused = true;
						this.SetOpenStat(UILordEquip.eUIOpenStat.ItemInfo, UILordEquip.eCollectType.None);
					}
					IL_40E:
					break;
				case eUI_LordEquipOpenKind.CombineSelect:
					if (this.DM.RoleAttr.LordEquipEventData.ItemID != 0 && this.DM.RoleAttr.LordEquipEventData.SerialNO == this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO)
					{
						return;
					}
					this.Select.position = sender.transform.position;
					this.Select.gameObject.SetActive(true);
					UILordEquip.EquipFocus = (ushort)sender.m_BtnID2;
					this.isFocused = true;
					this.SetSideInfo();
					break;
				case eUI_LordEquipOpenKind.SelectSetSolt:
					if (UILordEquipSetEdit.showingSet.isInSet(this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO) && UILordEquipSetEdit.showingSet.SerialNO[UILordEquipSetEdit.ChangingIdx] != this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO)
					{
						return;
					}
					this.Select.position = sender.transform.position;
					this.Select.gameObject.SetActive(true);
					UILordEquip.EquipFocus = (ushort)sender.m_BtnID2;
					this.isFocused = true;
					this.SetSideInfo();
					break;
				}
				goto IL_5A2;
			default:
				if (openStat != UILordEquip.eUIOpenStat.newGemSelect)
				{
					goto IL_5A2;
				}
				break;
			case UILordEquip.eUIOpenStat.GemSelect:
				break;
			}
			this.isFocused = true;
			this.Select.position = sender.transform.position;
			this.MaterialFocus = (ushort)sender.m_BtnID2;
			this.Select.gameObject.SetActive(true);
			this.SetGemInfo();
			IL_5A2:
			break;
		}
		case 2:
			UILordEquip.EquipFocusSub = (ushort)sender.m_BtnID2;
			UILordEquip.EquipFocusSub -= 1;
			if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Gem[(int)UILordEquip.EquipFocusSub] == 0)
			{
				return;
			}
			this.SetOpenStat(UILordEquip.eUIOpenStat.GemInfo, UILordEquip.eCollectType.None);
			break;
		case 3:
			switch (this.CollectType)
			{
			case UILordEquip.eCollectType.Equip:
				UILordEquip.EquipTopIdx = this.AGS_ScrollArea.GetTopIdx();
				UILordEquip.EquipTopPos = this.ScrollArea_RT.anchoredPosition.y;
				break;
			case UILordEquip.eCollectType.Gem:
				UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
				UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
				break;
			case UILordEquip.eCollectType.Material:
				UILordEquip.MatTopIdx = this.AGS_ScrollArea.GetTopIdx();
				UILordEquip.MatTopPos = this.ScrollArea_RT.anchoredPosition.y;
				break;
			}
			this.SetPopup(this.PopupKind, this.PopUpColor, (byte)sender.m_BtnID2);
			break;
		}
	}

	// Token: 0x06001DCF RID: 7631 RVA: 0x0037D2F0 File Offset: 0x0037B4F0
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			switch (arg1)
			{
			case 1:
				this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.None);
				this.DM.mLordEquip.DeleteEquip(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO);
				break;
			case 2:
				GUIManager.Instance.OpenTechTree(this.OpenTechTree, true);
				break;
			case 3:
				this.DM.mLordEquip.InlayGem(this.DM.mLordEquip.LEGem[(int)this.MaterialFocus].ItemID, this.DM.mLordEquip.LEGem[(int)this.MaterialFocus].Color, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO, (byte)UILordEquip.EquipFocusSub);
				this.Select.gameObject.SetActive(false);
				this.SetOpenStat(UILordEquip.eUIOpenStat.ItemInfo, UILordEquip.eCollectType.None);
				break;
			}
		}
	}

	// Token: 0x06001DD0 RID: 7632 RVA: 0x0037D404 File Offset: 0x0037B604
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		switch (panelId)
		{
		case 0:
			this.UpdateInvRow(item, dataIdx, panelObjectIdx);
			break;
		case 1:
			this.UpdateSideCompareRow(item, dataIdx, panelObjectIdx);
			break;
		case 2:
			this.UpdateEqInfoRow(item, dataIdx, panelObjectIdx);
			break;
		case 3:
			this.UpdatePopUpRow(item, dataIdx, panelObjectIdx);
			break;
		case 4:
			this.UpdateNewGemRow(item, dataIdx, panelObjectIdx);
			break;
		}
	}

	// Token: 0x06001DD1 RID: 7633 RVA: 0x0037D47C File Offset: 0x0037B67C
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001DD2 RID: 7634 RVA: 0x0037D480 File Offset: 0x0037B680
	private void SetOpenStat(UILordEquip.eUIOpenStat opStat, UILordEquip.eCollectType collect = UILordEquip.eCollectType.None)
	{
		switch (opStat)
		{
		case UILordEquip.eUIOpenStat.None:
			switch (this.OpenKind)
			{
			case eUI_LordEquipOpenKind.SelectSolt:
			{
				int num = (int)this.EquipSolt;
				if (num > 6)
				{
					num = 6;
				}
				this.TitleText.ClearString();
				this.TitleText.StringToFormat(this.DM.mStringTable.GetStringByID((uint)(num + 7430)));
				this.TitleText.AppendFormat(this.DM.mStringTable.GetStringByID(7467u));
				UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
				component.text = this.TitleText.ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				break;
			}
			case eUI_LordEquipOpenKind.Collection:
			{
				this.TitleText.ClearString();
				this.TitleText.Append(this.DM.mStringTable.GetStringByID(7404u));
				UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
				component.text = this.TitleText.ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				break;
			}
			case eUI_LordEquipOpenKind.CombineSelect:
			{
				this.TitleText.ClearString();
				this.TitleText.Append(this.DM.mStringTable.GetStringByID(7505u));
				UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
				component.text = this.TitleText.ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				break;
			}
			}
			break;
		case UILordEquip.eUIOpenStat.Normal:
			switch (this.OpenKind)
			{
			case eUI_LordEquipOpenKind.SelectSolt:
			{
				this.AGS_Form.GetChild(4).gameObject.SetActive(true);
				this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
				this.AGS_Form.GetChild(5).gameObject.SetActive(true);
				this.AGS_Form.GetChild(8).gameObject.SetActive(true);
				this.AGS_Form.GetChild(9).gameObject.SetActive(false);
				this.AGS_Form.GetChild(10).gameObject.SetActive(false);
				this.AGS_Form.GetChild(8).GetChild(0).gameObject.SetActive(false);
				this.AGS_Form.GetChild(8).GetChild(1).gameObject.SetActive(true);
				this.AGS_Form.GetChild(8).GetChild(2).gameObject.SetActive(false);
				this.AGS_Form.GetChild(3).gameObject.SetActive(false);
				this.Select.gameObject.SetActive(false);
				this.Forging.gameObject.SetActive(false);
				int num2 = (int)this.EquipSolt;
				if (num2 > 6)
				{
					num2 = 6;
				}
				this.TitleText.ClearString();
				this.TitleText.StringToFormat(this.DM.mStringTable.GetStringByID((uint)(num2 + 7430)));
				this.TitleText.AppendFormat(this.DM.mStringTable.GetStringByID(7467u));
				UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
				component.text = this.TitleText.ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.OpenStat = opStat;
				this.SetMainFilter((UILordEquip.eItemFilterByKind)num2);
				break;
			}
			case eUI_LordEquipOpenKind.Collection:
			{
				this.AGS_Form.GetChild(4).gameObject.SetActive(true);
				this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
				this.AGS_Form.GetChild(5).gameObject.SetActive(true);
				this.AGS_Form.GetChild(8).gameObject.SetActive(true);
				this.AGS_Form.GetChild(9).gameObject.SetActive(false);
				this.AGS_Form.GetChild(10).gameObject.SetActive(false);
				this.AGS_Form.GetChild(8).GetChild(0).gameObject.SetActive(true);
				this.AGS_Form.GetChild(8).GetChild(1).gameObject.SetActive(false);
				this.AGS_Form.GetChild(8).GetChild(2).gameObject.SetActive(false);
				this.AGS_Form.GetChild(3).gameObject.SetActive(true);
				this.AGS_Form.GetChild(8).GetChild(0).GetChild(7).gameObject.SetActive(false);
				this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(this.DM.mLordEquip.isEquipEvoReady);
				this.Select.gameObject.SetActive(false);
				this.Forging.gameObject.SetActive(false);
				this.OpenStat = opStat;
				if (collect == UILordEquip.eCollectType.None)
				{
					this.SetCollectType(UILordEquip.eCollectType.Equip);
				}
				else
				{
					this.SetCollectType(collect);
				}
				this.TitleText.ClearString();
				this.TitleText.Append(this.DM.mStringTable.GetStringByID(7404u));
				UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
				component.text = this.TitleText.ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				break;
			}
			case eUI_LordEquipOpenKind.CombineSelect:
			{
				this.AGS_Form.GetChild(4).gameObject.SetActive(true);
				this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
				this.AGS_Form.GetChild(5).gameObject.SetActive(true);
				this.AGS_Form.GetChild(8).gameObject.SetActive(true);
				this.AGS_Form.GetChild(9).gameObject.SetActive(false);
				this.AGS_Form.GetChild(10).gameObject.SetActive(false);
				this.AGS_Form.GetChild(8).GetChild(0).gameObject.SetActive(false);
				this.AGS_Form.GetChild(8).GetChild(1).gameObject.SetActive(true);
				this.AGS_Form.GetChild(8).GetChild(2).gameObject.SetActive(false);
				this.AGS_Form.GetChild(3).gameObject.SetActive(true);
				this.Select.gameObject.SetActive(false);
				this.Forging.gameObject.SetActive(false);
				this.TitleText.ClearString();
				this.TitleText.Append(this.DM.mStringTable.GetStringByID(7505u));
				UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
				component.text = this.TitleText.ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.OpenStat = opStat;
				this.SetMainFilter(UILordEquip.eItemFilterByKind.IDFilter);
				break;
			}
			case eUI_LordEquipOpenKind.SelectSetSolt:
			{
				this.AGS_Form.GetChild(4).gameObject.SetActive(true);
				this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
				this.AGS_Form.GetChild(5).gameObject.SetActive(true);
				this.AGS_Form.GetChild(8).gameObject.SetActive(true);
				this.AGS_Form.GetChild(9).gameObject.SetActive(false);
				this.AGS_Form.GetChild(10).gameObject.SetActive(false);
				this.AGS_Form.GetChild(8).GetChild(0).gameObject.SetActive(false);
				this.AGS_Form.GetChild(8).GetChild(1).gameObject.SetActive(true);
				this.AGS_Form.GetChild(8).GetChild(2).gameObject.SetActive(false);
				this.AGS_Form.GetChild(3).gameObject.SetActive(false);
				this.Select.gameObject.SetActive(false);
				this.Forging.gameObject.SetActive(false);
				int num3 = (int)this.EquipSolt;
				if (num3 > 6)
				{
					num3 = 6;
				}
				this.TitleText.ClearString();
				this.TitleText.StringToFormat(this.DM.mStringTable.GetStringByID((uint)(num3 + 7430)));
				this.TitleText.AppendFormat(this.DM.mStringTable.GetStringByID(7467u));
				UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
				component.text = this.TitleText.ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.OpenStat = opStat;
				this.SetMainFilter((UILordEquip.eItemFilterByKind)num3);
				break;
			}
			}
			break;
		case UILordEquip.eUIOpenStat.ItemInfo:
		{
			if ((this.OpenKind == eUI_LordEquipOpenKind.SelectSolt || this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt) && opStat == UILordEquip.eUIOpenStat.Normal && !this.Select.gameObject.activeInHierarchy)
			{
				this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.None);
				return;
			}
			if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ItemID == 0)
			{
				this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.None);
				return;
			}
			this.DM.mLordEquip.LoadLEMaterial(false);
			this.MaterialFocus = 0;
			this.AGS_Form.GetChild(4).gameObject.SetActive(false);
			this.AGS_Form.GetChild(5).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).gameObject.SetActive(false);
			this.AGS_Form.GetChild(9).gameObject.SetActive(true);
			this.AGS_Form.GetChild(10).gameObject.SetActive(false);
			this.AGS_Form.GetChild(3).gameObject.SetActive(false);
			this.TitleText.ClearString();
			this.TitleText.Append(this.DM.mStringTable.GetStringByID(7470u));
			UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
			component.text = this.TitleText.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SetItemGemDetail();
			break;
		}
		case UILordEquip.eUIOpenStat.GemSelect:
		{
			this.AGS_Form.GetChild(4).gameObject.SetActive(true);
			this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
			this.AGS_Form.GetChild(5).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).gameObject.SetActive(true);
			this.AGS_Form.GetChild(9).gameObject.SetActive(false);
			this.AGS_Form.GetChild(10).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(1).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(2).gameObject.SetActive(true);
			this.AGS_Form.GetChild(3).gameObject.SetActive(false);
			this.Select.gameObject.SetActive(false);
			this.Forging.gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(2).GetChild(3).gameObject.SetActive(true);
			this.TitleText.ClearString();
			this.TitleText.Append(this.DM.mStringTable.GetStringByID(7478u));
			UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
			component.text = this.TitleText.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(8).GetChild(0).GetComponent<UIText>();
			if (UILordEquip.waitForReturn == eUI_LordEquipReturnKind.GemEffectFilter && UIEffectFilter.SeletedFilter != 0)
			{
				component.text = this.DM.mStringTable.GetStringByID((uint)this.DM.EffectData.GetRecordByKey(this.DM.LordEquipEffectFilter.GetRecordByIndex((int)(UIEffectFilter.SeletedFilter - 1)).effectID).InfoID);
				component.color = new Color32(0, byte.MaxValue, 0, byte.MaxValue);
				this.SetMainFilter(UILordEquip.eItemFilterByKind.GemFilter);
				this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(8).GetChild(2).gameObject.SetActive(true);
				this.OpenStat = opStat;
				this.SetGemInfo();
			}
			else
			{
				component.text = this.DM.mStringTable.GetStringByID(7427u);
				component.color = Color.white;
				this.SetMainFilter(UILordEquip.eItemFilterByKind.Gem);
				this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(8).GetChild(2).gameObject.SetActive(false);
				this.OpenStat = opStat;
				this.SetGemInfo();
				component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(1).GetComponent<UIText>();
				this.ItemNameText.ClearString();
				component.text = this.ItemNameText.ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				for (int i = 0; i < 6; i++)
				{
					component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(0 + i).GetComponent<UIText>();
					this.EffDescText[i].ClearString();
					component.text = this.EffDescText[i].ToString();
					component.SetAllDirty();
					component.cachedTextGenerator.Invalidate();
				}
			}
			break;
		}
		case UILordEquip.eUIOpenStat.GemInfo:
			this.AGS_Form.GetChild(10).gameObject.SetActive(true);
			this.SetPopup(opStat, 0, 0);
			opStat = this.OpenStat;
			break;
		case UILordEquip.eUIOpenStat.GemCombine:
			this.AGS_Form.GetChild(10).gameObject.SetActive(true);
			this.SetPopup(opStat, 0, this.combineColor);
			opStat = this.OpenStat;
			break;
		case UILordEquip.eUIOpenStat.MaterialCombine:
			this.AGS_Form.GetChild(10).gameObject.SetActive(true);
			this.SetPopup(opStat, 0, this.combineColor);
			opStat = this.OpenStat;
			break;
		case UILordEquip.eUIOpenStat.newGemSelect:
		{
			this.AGS_Form.GetChild(4).gameObject.SetActive(true);
			this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
			this.AGS_Form.GetChild(5).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).gameObject.SetActive(true);
			this.AGS_Form.GetChild(9).gameObject.SetActive(false);
			this.AGS_Form.GetChild(10).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(1).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(2).gameObject.SetActive(true);
			this.AGS_Form.GetChild(3).gameObject.SetActive(false);
			this.Select.gameObject.SetActive(false);
			this.Forging.gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(2).GetChild(3).gameObject.SetActive(true);
			this.TitleText.ClearString();
			this.TitleText.Append(this.DM.mStringTable.GetStringByID(16130u));
			UIText component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
			component.text = this.TitleText.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.SetMainFilter(UILordEquip.eItemFilterByKind.NewGem);
			this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(8).GetChild(2).gameObject.SetActive(false);
			this.OpenStat = opStat;
			this.SetGemInfo();
			component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(1).GetComponent<UIText>();
			this.ItemNameText.ClearString();
			component.text = this.ItemNameText.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			for (int j = 0; j < 6; j++)
			{
				component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(2).GetChild(0 + j).GetComponent<UIText>();
				this.PopupEffectText[j].ClearString();
				component.text = this.PopupEffectText[j].ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
			}
			break;
		}
		}
		this.OpenStat = opStat;
	}

	// Token: 0x06001DD3 RID: 7635 RVA: 0x0037E6B4 File Offset: 0x0037C8B4
	private void SetCollectType(UILordEquip.eCollectType type)
	{
		UIText component = this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).GetComponent<UIText>();
		this.isCollectChange = (this.CollectType != type);
		this.CollectType = type;
		switch (type)
		{
		case UILordEquip.eCollectType.Equip:
			this.Forging.gameObject.SetActive(false);
			this.SetMainFilter((UILordEquip.eItemFilterByKind)UILordEquip.EquipFilter);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(7).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(4).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(3).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(2).GetChild(0).gameObject.SetActive(false);
			component.text = this.DM.mStringTable.GetStringByID(7460u);
			component = this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).GetChild(0).GetComponent<UIText>();
			if (GameConstants.IsBetween(UILordEquip.EquipFilter, 1, 6))
			{
				component.text = this.DM.mStringTable.GetStringByID((uint)(UILordEquip.EquipFilter + 7430));
				component.color = new Color32(0, byte.MaxValue, 0, byte.MaxValue);
				this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).GetChild(2).gameObject.SetActive(true);
			}
			else
			{
				component.text = this.DM.mStringTable.GetStringByID(7427u);
				component.color = Color.white;
				this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).GetChild(2).gameObject.SetActive(false);
			}
			break;
		case UILordEquip.eCollectType.Gem:
			this.Forging.gameObject.SetActive(false);
			this.SetMainFilter(UILordEquip.eItemFilterByKind.Gem);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(7).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(4).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(3).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(2).GetChild(0).gameObject.SetActive(false);
			component.text = this.DM.mStringTable.GetStringByID(7438u);
			UIEffectFilter.SeletedFilter = 0;
			break;
		case UILordEquip.eCollectType.Material:
			this.Forging.gameObject.SetActive(false);
			this.SetMainFilter(UILordEquip.eItemFilterByKind.Material);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(7).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(4).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(3).GetChild(0).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(2).GetChild(0).gameObject.SetActive(false);
			component.text = this.DM.mStringTable.GetStringByID(7438u);
			UIEffectFilter.SeletedFilter = 0;
			break;
		case UILordEquip.eCollectType.newGem:
			this.Forging.gameObject.SetActive(false);
			this.SetMainFilter(UILordEquip.eItemFilterByKind.NewGem);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(7).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(4).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(3).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(0).GetChild(2).GetChild(0).gameObject.SetActive(true);
			component.text = this.DM.mStringTable.GetStringByID(7438u);
			UIEffectFilter.SeletedFilter = 0;
			break;
		}
	}

	// Token: 0x06001DD4 RID: 7636 RVA: 0x0037EDC0 File Offset: 0x0037CFC0
	private void SetSideInfo()
	{
		if (this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt)
		{
			this.SetSideInfoForQuickChange();
			return;
		}
		UIText component;
		if (!this.isFocused || this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ItemID == 0)
		{
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(0).gameObject.SetActive(false);
			component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(1).GetComponent<UIText>();
			this.ItemNameText.ClearString();
			component.text = this.ItemNameText.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(3).GetComponent<UIText>();
			this.ItemLevelText.ClearString();
			component.text = this.ItemLevelText.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.AGS_RareImg.gameObject.SetActive(false);
			this.SideSPHeight.Clear();
			this.AGS_ScrollPanel.AddNewDataHeight(this.SideSPHeight, 282f, true);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetChild(2).gameObject.SetActive(false);
			if (this.OpenKind == eUI_LordEquipOpenKind.CombineSelect && this.OpenStat == UILordEquip.eUIOpenStat.Normal)
			{
				this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).gameObject.SetActive(true);
				this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).gameObject.SetActive(false);
				this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).gameObject.SetActive(false);
			}
			else
			{
				this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).gameObject.SetActive(false);
				this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).gameObject.SetActive(true);
				this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).gameObject.SetActive(true);
			}
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(4).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).gameObject.SetActive(false);
			this.selectedTimed = false;
			return;
		}
		this.AGS_Form.GetChild(8).GetChild(1).GetChild(0).gameObject.SetActive(true);
		this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetChild(2).gameObject.SetActive(this.DM.mLordEquip.CheckItemUpgradeReady(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus]));
		Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ItemID);
		component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(1).GetComponent<UIText>();
		this.ItemNameText.ClearString();
		GameConstants.GetColoredLordEquipString(this.ItemNameText, ref recordByKey, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Color);
		component.text = this.ItemNameText.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(3).GetComponent<UIText>();
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
		if (GameConstants.IsBetween((int)this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Color, 0, 6))
		{
			this.AGS_RareImg.SetSpriteIndex((int)(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Color - 1));
		}
		if (this.EquipSolt == 0 || LordEquipData.RoleEquipSerial[(int)(this.EquipSolt - 1)] == 0u)
		{
			LordEquipData.GetEffectCompareList(default(ItemLordEquip), this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus], out this.effectCompareList);
		}
		else
		{
			int num = 0;
			int num2 = (int)(this.EquipSolt - 1);
			for (int i = 0; i < 200; i++)
			{
				if (LordEquipData.RoleEquipSerial[num2] == this.DM.mLordEquip.LordEquip[i].SerialNO)
				{
					num = i;
					break;
				}
			}
			LordEquipData.GetEffectCompareList(this.DM.mLordEquip.LordEquip[num], this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus], out this.effectCompareList);
		}
		LordEquipData.EffectTitleListCreater(this.effectCompareList);
		if (this.OpenKind == eUI_LordEquipOpenKind.CombineSelect && this.OpenStat == UILordEquip.eUIOpenStat.Normal)
		{
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).gameObject.SetActive(false);
		}
		else
		{
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).gameObject.SetActive(true);
			if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO == 0u || this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO != LordEquipData.RoleEquipSerial[(int)(this.EquipSolt - 1)])
			{
				this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetComponent<UISpritesArray>().SetSpriteIndex(0);
				component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetChild(1).GetComponent<UIText>();
				component.text = this.DM.mStringTable.GetStringByID(7469u);
			}
			else
			{
				this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetComponent<UISpritesArray>().SetSpriteIndex(1);
				component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetChild(1).GetComponent<UIText>();
				component.text = this.DM.mStringTable.GetStringByID(7494u);
			}
		}
		CString cstring2 = StringManager.Instance.StaticString1024();
		this.SideSPHeight.Clear();
		for (int j = 0; j < this.effectCompareList.Count; j++)
		{
			if (this.effectCompareList[j].isTitel)
			{
				this.SideSPHeight.Add(35f);
			}
			else if (this.effectCompareList[j].isNewGemEffect == 1)
			{
				cstring2.ClearString();
				LordEquipData.GetNewGemEffectString(cstring2, (byte)this.effectCompareList[j].EffectID, this.effectCompareList[j].EffectValue, this.effectCompareList[j].isEven, this.effectCompareList[j].useForceColor);
				this.SideSPHeight.Add(this.GetTextHeight(260f, cstring2, 18));
			}
			else
			{
				this.SideSPHeight.Add(32f);
			}
		}
		if (this.SideSPHeight.Count > 1)
		{
			float num3 = this.SideSPHeight[this.SideSPHeight.Count - 1];
			this.SideSPHeight.RemoveAt(this.SideSPHeight.Count - 1);
			this.SideSPHeight.Add(num3 + 6f);
		}
		this.AGS_ScrollPanel.AddNewDataHeight(this.SideSPHeight, true, true);
		if (recordByKey.TimedType > 0)
		{
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(4).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).GetComponent<UIText>();
			RectTransform component2 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(7).GetComponent<RectTransform>();
			component2.localPosition = new Vector3(-1f, -1.5f, 0f);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 250f);
			if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ExpireTime == 0L)
			{
				component.color = new Color32(53, 247, 108, byte.MaxValue);
				this.TimedItemCountText.ClearString();
				GameConstants.GetTimeString(this.TimedItemCountText, recordByKey.TimedTime, false, false, true, false, true);
				component.text = this.TimedItemCountText.ToString();
				component.cachedTextGenerator.Invalidate();
				component.SetAllDirty();
				this.selectedTimed = false;
			}
			else
			{
				component.color = new Color32(byte.MaxValue, 101, 110, byte.MaxValue);
				this.TimedItemCountText.ClearString();
				GameConstants.GetTimeString(this.TimedItemCountText, (uint)Math.Max(0L, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ExpireTime - this.DM.ServerTime), false, false, true, false, true);
				component.text = this.TimedItemCountText.ToString();
				component.cachedTextGenerator.Invalidate();
				component.SetAllDirty();
				this.selectedTimed = true;
			}
		}
		else
		{
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(4).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).gameObject.SetActive(false);
			RectTransform component3 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(7).GetComponent<RectTransform>();
			component3.localPosition = new Vector3(-1f, 22.5f, 0f);
			component3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 282f);
			this.selectedTimed = false;
		}
	}

	// Token: 0x06001DD5 RID: 7637 RVA: 0x0037F9F0 File Offset: 0x0037DBF0
	private void SetSideInfoForQuickChange()
	{
		UIText component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetChild(1).GetComponent<UIText>();
		component.text = this.DM.mStringTable.GetStringByID(3u);
		if (!this.isFocused || this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ItemID == 0)
		{
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(0).gameObject.SetActive(false);
			component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(1).GetComponent<UIText>();
			this.ItemNameText.ClearString();
			component.text = this.ItemNameText.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(3).GetComponent<UIText>();
			this.ItemLevelText.ClearString();
			component.text = this.ItemLevelText.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.AGS_RareImg.gameObject.SetActive(false);
			this.SideSPHeight.Clear();
			this.AGS_ScrollPanel.AddNewDataHeight(this.SideSPHeight, 282f, true);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetChild(2).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(4).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).gameObject.SetActive(false);
			this.selectedTimed = false;
			return;
		}
		this.AGS_Form.GetChild(8).GetChild(1).GetChild(0).gameObject.SetActive(true);
		this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetChild(2).gameObject.SetActive(this.DM.mLordEquip.CheckItemUpgradeReady(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus]));
		Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ItemID);
		component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(1).GetComponent<UIText>();
		this.ItemNameText.ClearString();
		GameConstants.GetColoredLordEquipString(this.ItemNameText, ref recordByKey, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Color);
		component.text = this.ItemNameText.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(3).GetComponent<UIText>();
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
		if (GameConstants.IsBetween((int)this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Color, 0, 6))
		{
			this.AGS_RareImg.SetSpriteIndex((int)(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Color - 1));
		}
		if (UILordEquipSetEdit.showingSet.SerialNO[UILordEquipSetEdit.ChangingIdx] == 0u)
		{
			LordEquipData.GetEffectCompareList(default(ItemLordEquip), this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus], out this.effectCompareList);
		}
		else
		{
			LordEquipData.GetEffectCompareList(this.DM.mLordEquip.LordEquip[UILordEquipSetEdit.SetDataIndex[UILordEquipSetEdit.ChangingIdx]], this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus], out this.effectCompareList);
		}
		LordEquipData.EffectTitleListCreater(this.effectCompareList);
		this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).gameObject.SetActive(false);
		this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).gameObject.SetActive(true);
		this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).gameObject.SetActive(true);
		if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO == 0u || this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO != UILordEquipSetEdit.showingSet.SerialNO[UILordEquipSetEdit.ChangingIdx])
		{
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetComponent<UISpritesArray>().SetSpriteIndex(0);
		}
		else
		{
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetComponent<UISpritesArray>().SetSpriteIndex(1);
			component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetChild(1).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7494u);
		}
		this.SideSPHeight.Clear();
		CString cstring2 = StringManager.Instance.StaticString1024();
		for (int i = 0; i < this.effectCompareList.Count; i++)
		{
			if (this.effectCompareList[i].isTitel)
			{
				this.SideSPHeight.Add(35f);
			}
			else if (this.effectCompareList[i].isNewGemEffect == 1)
			{
				cstring2.ClearString();
				LordEquipData.GetNewGemEffectString(cstring2, (byte)this.effectCompareList[i].EffectID, this.effectCompareList[i].EffectValue, this.effectCompareList[i].isEven, this.effectCompareList[i].useForceColor);
				this.SideSPHeight.Add(this.GetTextHeight(260f, cstring2, 18));
			}
			else
			{
				this.SideSPHeight.Add(32f);
			}
		}
		if (this.SideSPHeight.Count > 1)
		{
			float num = this.SideSPHeight[this.SideSPHeight.Count - 1];
			this.SideSPHeight.RemoveAt(this.SideSPHeight.Count - 1);
			this.SideSPHeight.Add(num + 6f);
		}
		this.AGS_ScrollPanel.AddNewDataHeight(this.SideSPHeight, true, true);
		if (recordByKey.TimedType > 0)
		{
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(4).gameObject.SetActive(true);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).GetComponent<UIText>();
			RectTransform component2 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(7).GetComponent<RectTransform>();
			component2.localPosition = new Vector3(-1f, -1.5f, 0f);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 250f);
			if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ExpireTime == 0L)
			{
				component.color = new Color32(53, 247, 108, byte.MaxValue);
				this.TimedItemCountText.ClearString();
				GameConstants.GetTimeString(this.TimedItemCountText, recordByKey.TimedTime, false, false, true, false, true);
				component.text = this.TimedItemCountText.ToString();
				component.cachedTextGenerator.Invalidate();
				component.SetAllDirty();
				this.selectedTimed = false;
			}
			else
			{
				component.color = new Color32(byte.MaxValue, 101, 110, byte.MaxValue);
				this.TimedItemCountText.ClearString();
				GameConstants.GetTimeString(this.TimedItemCountText, (uint)Math.Max(0L, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ExpireTime - this.DM.ServerTime), false, false, true, false, true);
				component.text = this.TimedItemCountText.ToString();
				component.cachedTextGenerator.Invalidate();
				component.SetAllDirty();
				this.selectedTimed = true;
			}
		}
		else
		{
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(4).gameObject.SetActive(false);
			this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).gameObject.SetActive(false);
			RectTransform component3 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(7).GetComponent<RectTransform>();
			component3.localPosition = new Vector3(-1f, 22.5f, 0f);
			component3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 282f);
			this.selectedTimed = false;
		}
	}

	// Token: 0x06001DD6 RID: 7638 RVA: 0x003804A0 File Offset: 0x0037E6A0
	private void SetGemInfo()
	{
		UIText component;
		if (!this.isFocused || this.DM.mLordEquip.LEGem[(int)this.MaterialFocus].ItemID == 0)
		{
			component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(1).GetComponent<UIText>();
			this.ItemNameText.ClearString();
			component.text = this.ItemNameText.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			this.AGS_RareImg.gameObject.SetActive(false);
			this.SPHeight.Clear();
			UIButton component2 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(4).GetComponent<UIButton>();
			if (this.OpenStat != UILordEquip.eUIOpenStat.newGemSelect)
			{
				RectTransform component3 = this.NewGemPanel.GetComponent<RectTransform>();
				component3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 180f);
				this.NewGemPanel.AddNewDataHeight(this.SPHeight, 180f, true);
				this.AGS_Form.GetChild(8).GetChild(2).GetChild(4).GetChild(1).gameObject.SetActive(true);
				this.AGS_Form.GetChild(8).GetChild(2).GetChild(4).GetChild(2).gameObject.SetActive(false);
				component2.m_BtnID2 = 1;
			}
			else
			{
				RectTransform component4 = this.NewGemPanel.GetComponent<RectTransform>();
				component4.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 300f);
				this.NewGemPanel.AddNewDataHeight(this.SPHeight, 300f, true);
				this.AGS_Form.GetChild(8).GetChild(2).GetChild(4).GetChild(1).gameObject.SetActive(false);
				this.AGS_Form.GetChild(8).GetChild(2).GetChild(4).GetChild(2).gameObject.SetActive(true);
				component2.m_BtnID2 = 3;
			}
			return;
		}
		Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LEGem[(int)this.MaterialFocus].ItemID);
		component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(1).GetComponent<UIText>();
		this.ItemNameText.ClearString();
		GameConstants.GetColoredLordEquipString(this.ItemNameText, ref recordByKey, this.DM.mLordEquip.LEGem[(int)this.MaterialFocus].Color);
		component.text = this.ItemNameText.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		this.effectList.Clear();
		LordEquipData.GetEffectList(this.DM.mLordEquip.LEGem[(int)this.MaterialFocus], this.effectList);
		this.SPHeight.Clear();
		if (this.effectList.Count > 0)
		{
			for (int i = 0; i < this.effectList.Count; i++)
			{
				if (this.effectList[i].isNewGemEffect == 1)
				{
					CString cstring = StringManager.Instance.StaticString1024();
					cstring.ClearString();
					LordEquipData.GetNewGemEffectString(cstring, (byte)this.effectList[i].EffectID, (int)this.effectList[i].EffectValue, true, 0);
					this.SPHeight.Add(this.GetTextHeight(295f, cstring, 18));
				}
				else if (this.effectList[i].isNewGemEffect == 2)
				{
					CString cstring2 = StringManager.Instance.StaticString1024();
					cstring2.ClearString();
					cstring2.Append(this.DM.mStringTable.GetStringByID((uint)this.effectList[i].EffectID).ToString());
					this.SPHeight.Add(this.GetTextHeight(295f, cstring2, 16));
				}
				else
				{
					this.SPHeight.Add(30f);
				}
			}
		}
		if (this.OpenStat != UILordEquip.eUIOpenStat.newGemSelect)
		{
			this.NewGemPanel.AddNewDataHeight(this.SPHeight, 180f, true);
		}
		else
		{
			this.NewGemPanel.AddNewDataHeight(this.SPHeight, 300f, true);
		}
	}

	// Token: 0x06001DD7 RID: 7639 RVA: 0x003808E0 File Offset: 0x0037EAE0
	private void SetPopup(UILordEquip.eUIOpenStat opStat, byte selectColor, byte SetSelect = 0)
	{
		switch (opStat)
		{
		case UILordEquip.eUIOpenStat.GemInfo:
		{
			this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).gameObject.SetActive(false);
			this.AGS_Form.GetChild(10).GetChild(0).GetChild(12).gameObject.SetActive(false);
			this.AGS_Form.GetChild(10).GetChild(0).GetChild(14).gameObject.SetActive(false);
			Transform child = this.AGS_Form.GetChild(10).GetChild(0).GetChild(2);
			Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Gem[(int)UILordEquip.EquipFocusSub]);
			GUIManager.Instance.ChangeLordEquipImg(child, recordByKey.EquipKey, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].GemColor[(int)UILordEquip.EquipFocusSub], eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
			UIText component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(4).GetComponent<UIText>();
			this.PopUpHeaderText.ClearString();
			GameConstants.GetColoredLordEquipString(this.PopUpHeaderText, ref recordByKey, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].GemColor[(int)UILordEquip.EquipFocusSub]);
			component.text = this.PopUpHeaderText.ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			RectTransform component2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(11).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2(0f, -65f);
			component = component2.GetChild(0).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(5026u);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(0).GetComponent<RectTransform>();
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 360f);
			component2 = this.AGS_Form.GetChild(10).GetChild(0).GetComponent<RectTransform>();
			component2.anchoredPosition = new Vector2(0f, -100f);
			this.AGS_Form.GetChild(10).GetChild(0).GetChild(10).gameObject.SetActive(false);
			if (GameConstants.IsBetween((int)this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].GemColor[(int)UILordEquip.EquipFocusSub], 1, 5))
			{
				this.AGS_Form.GetChild(10).GetChild(0).GetChild(5).GetComponent<UISpritesArray>().SetSpriteIndex((int)(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].GemColor[(int)UILordEquip.EquipFocusSub] - 1));
			}
			this.effectList.Clear();
			this.PopSPHeight.Clear();
			LordEquipData.GetEffectList(recordByKey.EquipKey, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].GemColor[(int)UILordEquip.EquipFocusSub], this.effectList);
			CString cstring = StringManager.Instance.StaticString1024();
			for (int i = 0; i < this.effectList.Count; i++)
			{
				if (this.effectList[i].isNewGemEffect == 1)
				{
					cstring.ClearString();
					LordEquipData.GetNewGemEffectString(cstring, (byte)this.effectList[i].EffectID, (int)this.effectList[i].EffectValue, true, 0);
					this.PopSPHeight.Add(this.GetTextHeight(300f, cstring, 18));
				}
				else if (this.effectList[i].isNewGemEffect == 2)
				{
					cstring.ClearString();
					cstring.Append(this.DM.mStringTable.GetStringByID((uint)this.effectList[i].EffectID));
					this.PopSPHeight.Add(this.GetTextHeight(300f, cstring, 16));
				}
				else
				{
					this.PopSPHeight.Add(30f);
				}
			}
			this.POPScrollPanel.gameObject.SetActive(true);
			this.POPScrollPanel.AddNewDataHeight(this.PopSPHeight, true, true);
			UIText component3 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(11).GetChild(0).GetComponent<UIText>();
			component3.color = Color.white;
			break;
		}
		case UILordEquip.eUIOpenStat.GemCombine:
		{
			this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).gameObject.SetActive(true);
			this.AGS_Form.GetChild(10).GetChild(0).GetChild(12).gameObject.SetActive(false);
			this.SetPopupFunction(this.isCombine);
			Transform child2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(2);
			if (this.combineItemID != 0)
			{
				GUIManager.Instance.ChangeLordEquipImg(child2, this.combineItemID, SetSelect, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(this.combineItemID);
				UIText component4 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(4).GetComponent<UIText>();
				this.PopUpHeaderText.ClearString();
				GameConstants.GetColoredLordEquipString(this.PopUpHeaderText, ref recordByKey2, SetSelect);
				component4.text = this.PopUpHeaderText.ToString();
				component4.SetAllDirty();
				component4.cachedTextGenerator.Invalidate();
				if (GameConstants.IsBetween((int)SetSelect, 1, 5))
				{
					this.AGS_Form.GetChild(10).GetChild(0).GetChild(5).GetComponent<UISpritesArray>().SetSpriteIndex((int)(SetSelect - 1));
				}
				this.effectList.Clear();
				this.PopSPHeight.Clear();
				LordEquipData.GetEffectList(this.combineItemID, SetSelect, this.effectList);
				CString cstring2 = StringManager.Instance.StaticString1024();
				for (int j = 0; j < this.effectList.Count; j++)
				{
					if (this.effectList[j].isNewGemEffect == 1)
					{
						cstring2.ClearString();
						LordEquipData.GetNewGemEffectString(cstring2, (byte)this.effectList[j].EffectID, (int)this.effectList[j].EffectValue, true, 0);
						this.PopSPHeight.Add(this.GetTextHeight(300f, cstring2, 18));
					}
					else if (this.effectList[j].isNewGemEffect == 2)
					{
						cstring2.ClearString();
						cstring2.Append(this.DM.mStringTable.GetStringByID((uint)this.effectList[j].EffectID));
						this.PopSPHeight.Add(this.GetTextHeight(300f, cstring2, 16));
					}
					else
					{
						this.PopSPHeight.Add(30f);
					}
				}
				this.POPScrollPanel.gameObject.SetActive(true);
				this.POPScrollPanel.AddNewDataHeight(this.PopSPHeight, true, true);
				this.PopUpColor = selectColor;
			}
			if (SetSelect == 0)
			{
				SetSelect = this.PopUpColor;
			}
			if (this.isCombine)
			{
				if (!GameConstants.IsBetween((int)SetSelect, 2, 5))
				{
					SetSelect = 2;
				}
			}
			else if (!GameConstants.IsBetween((int)SetSelect, 1, 4))
			{
				SetSelect = 4;
			}
			this.combineColor = SetSelect;
			this.GetMaterialRareCount(false, this.combineItemID);
			if (this.isCombine)
			{
				for (int k = 0; k < 5; k++)
				{
					child2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(2 + k);
					GUIManager.Instance.ChangeLordEquipImg(child2, this.combineItemID, (byte)(k + 1), eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
					UIText component4 = child2.GetChild(0).GetComponent<UIText>();
					this.PopupAmountText[k].ClearString();
					if (k + 2 != (int)SetSelect)
					{
						this.PopupAmountText[k].IntToFormat((long)this.MaterCount[k], 1, true);
						this.PopupAmountText[k].AppendFormat("{0:N}");
					}
					else
					{
						UIText component5 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(11).GetChild(0).GetComponent<UIText>();
						ushort num = this.MaterCount[k];
						if (num < 4)
						{
							this.PopupAmountText[k].StringToFormat("<color=#FF5581FF>");
							component5.color = new Color32(byte.MaxValue, 85, 129, byte.MaxValue);
						}
						else
						{
							this.PopupAmountText[k].StringToFormat("<color=#FFFFFFFF>");
							component5.color = Color.white;
						}
						this.PopupAmountText[k].IntToFormat((long)num, 1, true);
						if (!GUIManager.Instance.IsArabic)
						{
							this.PopupAmountText[k].AppendFormat("{0}{1}</color> / 4");
						}
						else
						{
							this.PopupAmountText[k].AppendFormat("4 / {0}{1}</color>");
						}
					}
					component4.text = this.PopupAmountText[k].ToString();
					component4.SetAllDirty();
					component4.cachedTextGenerator.Invalidate();
				}
			}
			else
			{
				for (int l = 0; l < 5; l++)
				{
					child2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(2 + l);
					GUIManager.Instance.ChangeLordEquipImg(child2, this.combineItemID, (byte)(l + 1), eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
					UIText component4 = child2.GetChild(0).GetComponent<UIText>();
					this.PopupAmountText[l].ClearString();
					if (l != (int)SetSelect)
					{
						this.PopupAmountText[l].IntToFormat((long)this.MaterCount[l], 1, true);
						this.PopupAmountText[l].AppendFormat("{0:N}");
					}
					else
					{
						UIText component6 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(11).GetChild(0).GetComponent<UIText>();
						ushort num2 = this.MaterCount[l];
						if (num2 < 1)
						{
							this.PopupAmountText[l].StringToFormat("<color=#FF5581FF>");
							component6.color = new Color32(byte.MaxValue, 85, 129, byte.MaxValue);
						}
						else
						{
							this.PopupAmountText[l].StringToFormat("<color=#FFFFFFFF>");
							component6.color = Color.white;
						}
						this.PopupAmountText[l].IntToFormat((long)num2, 1, true);
						if (!GUIManager.Instance.IsArabic)
						{
							this.PopupAmountText[l].AppendFormat("{0}{1}</color> / 4");
						}
						else
						{
							this.PopupAmountText[l].AppendFormat("4 / {0}{1}</color>");
						}
					}
					component4.text = this.PopupAmountText[l].ToString();
					component4.SetAllDirty();
					component4.cachedTextGenerator.Invalidate();
				}
			}
			RectTransform component7 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(0).GetComponent<RectTransform>();
			component7.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 528f);
			component7 = this.AGS_Form.GetChild(10).GetChild(0).GetComponent<RectTransform>();
			component7.anchoredPosition = Vector2.zero;
			component7 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(11).GetComponent<RectTransform>();
			if ((!this.isCombine) ? (this.MaterCount[(int)SetSelect] >= 2) : (this.MaterCount[(int)(SetSelect - 2)] >= 8))
			{
				this.AGS_Form.GetChild(10).GetChild(0).GetChild(10).gameObject.SetActive(true);
				component7.anchoredPosition = new Vector2(115f, -230.5f);
			}
			else
			{
				this.AGS_Form.GetChild(10).GetChild(0).GetChild(10).gameObject.SetActive(false);
				component7.anchoredPosition = new Vector2(0f, -230.5f);
			}
			component7 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(7).GetComponent<RectTransform>();
			Vector2 anchoredPosition;
			if (this.isCombine)
			{
				anchoredPosition = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild((int)(2 + SetSelect - 1)).GetComponent<RectTransform>().anchoredPosition;
			}
			else
			{
				anchoredPosition = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild((int)(2 + SetSelect)).GetComponent<RectTransform>().anchoredPosition;
			}
			anchoredPosition.x -= 152f;
			anchoredPosition.y = component7.anchoredPosition.y;
			component7.anchoredPosition = anchoredPosition;
			break;
		}
		case UILordEquip.eUIOpenStat.MaterialCombine:
		{
			this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).gameObject.SetActive(true);
			this.AGS_Form.GetChild(10).GetChild(0).GetChild(12).gameObject.SetActive(true);
			this.SetPopupFunction(this.isCombine);
			Transform child3 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(2);
			if (this.combineItemID != 0)
			{
				Equip recordByKey3 = DataManager.Instance.EquipTable.GetRecordByKey(this.combineItemID);
				GUIManager.Instance.ChangeLordEquipImg(child3, this.combineItemID, SetSelect, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				UIText component8 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(4).GetComponent<UIText>();
				this.PopUpHeaderText.ClearString();
				GameConstants.GetColoredLordEquipString(this.PopUpHeaderText, ref recordByKey3, SetSelect);
				component8.text = this.PopUpHeaderText.ToString();
				component8.SetAllDirty();
				component8.cachedTextGenerator.Invalidate();
				if (GameConstants.IsBetween((int)SetSelect, 1, 5))
				{
					this.AGS_Form.GetChild(10).GetChild(0).GetChild(5).GetComponent<UISpritesArray>().SetSpriteIndex((int)(SetSelect - 1));
				}
				component8 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(12).GetComponent<UIText>();
				component8.text = this.DM.mStringTable.GetStringByID((uint)recordByKey3.EquipInfo);
				this.PopUpColor = selectColor;
			}
			if (SetSelect == 0)
			{
				SetSelect = this.PopUpColor;
			}
			if (this.isCombine)
			{
				if (!GameConstants.IsBetween((int)SetSelect, 2, 5))
				{
					SetSelect = 2;
				}
			}
			else if (!GameConstants.IsBetween((int)SetSelect, 1, 4))
			{
				SetSelect = 4;
			}
			this.combineColor = SetSelect;
			this.POPScrollPanel.gameObject.SetActive(false);
			this.GetMaterialRareCount(true, this.combineItemID);
			if (this.isCombine)
			{
				for (int m = 0; m < 5; m++)
				{
					child3 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(2 + m);
					GUIManager.Instance.ChangeLordEquipImg(child3, this.combineItemID, (byte)(m + 1), eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
					UIText component8 = child3.GetChild(0).GetComponent<UIText>();
					this.PopupAmountText[m].ClearString();
					if (m + 2 != (int)SetSelect)
					{
						this.PopupAmountText[m].IntToFormat((long)this.MaterCount[m], 1, true);
						this.PopupAmountText[m].AppendFormat("{0:N}");
					}
					else
					{
						UIText component9 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(11).GetChild(0).GetComponent<UIText>();
						ushort num3 = this.MaterCount[m];
						if (num3 < 4)
						{
							this.PopupAmountText[m].StringToFormat("<color=#FF5581FF>");
							component9.color = new Color32(byte.MaxValue, 85, 129, byte.MaxValue);
						}
						else
						{
							this.PopupAmountText[m].StringToFormat("<color=#FFFFFFFF>");
							component9.color = Color.white;
						}
						this.PopupAmountText[m].IntToFormat((long)num3, 1, true);
						if (!GUIManager.Instance.IsArabic)
						{
							this.PopupAmountText[m].AppendFormat("{0}{1}</color> / 4");
						}
						else
						{
							this.PopupAmountText[m].AppendFormat("4 / {0}{1}</color>");
						}
					}
					component8.text = this.PopupAmountText[m].ToString();
					component8.SetAllDirty();
					component8.cachedTextGenerator.Invalidate();
				}
			}
			else
			{
				for (int n = 0; n < 5; n++)
				{
					child3 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(2 + n);
					GUIManager.Instance.ChangeLordEquipImg(child3, this.combineItemID, (byte)(n + 1), eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
					UIText component8 = child3.GetChild(0).GetComponent<UIText>();
					this.PopupAmountText[n].ClearString();
					if (n != (int)SetSelect)
					{
						this.PopupAmountText[n].IntToFormat((long)this.MaterCount[n], 1, true);
						this.PopupAmountText[n].AppendFormat("{0:N}");
					}
					else
					{
						UIText component10 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(11).GetChild(0).GetComponent<UIText>();
						ushort num4 = this.MaterCount[n];
						if (num4 < 1)
						{
							this.PopupAmountText[n].StringToFormat("<color=#FF5581FF>");
							component10.color = new Color32(byte.MaxValue, 85, 129, byte.MaxValue);
						}
						else
						{
							this.PopupAmountText[n].StringToFormat("<color=#FFFFFFFF>");
							component10.color = Color.white;
						}
						this.PopupAmountText[n].IntToFormat((long)num4, 1, true);
						if (!GUIManager.Instance.IsArabic)
						{
							this.PopupAmountText[n].AppendFormat("{0}{1}</color> / 1");
						}
						else
						{
							this.PopupAmountText[n].AppendFormat("1 / {0}{1}</color>");
						}
					}
					component8.text = this.PopupAmountText[n].ToString();
					component8.SetAllDirty();
					component8.cachedTextGenerator.Invalidate();
				}
			}
			RectTransform component11 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(0).GetComponent<RectTransform>();
			component11.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 528f);
			component11 = this.AGS_Form.GetChild(10).GetChild(0).GetComponent<RectTransform>();
			component11.anchoredPosition = Vector2.zero;
			component11 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(11).GetComponent<RectTransform>();
			if ((!this.isCombine) ? (this.MaterCount[(int)SetSelect] >= 2) : (this.MaterCount[(int)(SetSelect - 2)] >= 8))
			{
				this.AGS_Form.GetChild(10).GetChild(0).GetChild(10).gameObject.SetActive(true);
				component11.anchoredPosition = new Vector2(115f, -230.5f);
			}
			else
			{
				this.AGS_Form.GetChild(10).GetChild(0).GetChild(10).gameObject.SetActive(false);
				component11.anchoredPosition = new Vector2(0f, -230.5f);
			}
			component11 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(7).GetComponent<RectTransform>();
			Vector2 anchoredPosition2;
			if (this.isCombine)
			{
				anchoredPosition2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild((int)(2 + SetSelect - 1)).GetComponent<RectTransform>().anchoredPosition;
			}
			else
			{
				anchoredPosition2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild((int)(2 + SetSelect)).GetComponent<RectTransform>().anchoredPosition;
			}
			anchoredPosition2.x -= 152f;
			anchoredPosition2.y = component11.anchoredPosition.y;
			component11.anchoredPosition = anchoredPosition2;
			break;
		}
		}
		this.PopupKind = opStat;
	}

	// Token: 0x06001DD8 RID: 7640 RVA: 0x00381D78 File Offset: 0x0037FF78
	private void SetPopupFunction(bool isCombine)
	{
		this.AGS_Form.GetChild(10).GetChild(0).GetChild(14).gameObject.SetActive(true);
		this.isCombine = isCombine;
		if (isCombine)
		{
			this.AGS_Form.GetChild(10).GetChild(0).GetChild(14).GetChild(1).gameObject.SetActive(true);
			this.AGS_Form.GetChild(10).GetChild(0).GetChild(14).GetChild(5).gameObject.SetActive(false);
			UIText component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(11).GetChild(0).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7451u);
			component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(10).GetChild(0).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7450u);
			component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(1).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7466u);
			RectTransform component2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(7).GetChild(2).GetComponent<RectTransform>();
			component2.localScale = Vector3.one;
			component2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(7).GetChild(3).GetComponent<RectTransform>();
			component2.localScale = Vector3.one;
		}
		else
		{
			this.AGS_Form.GetChild(10).GetChild(0).GetChild(14).GetChild(1).gameObject.SetActive(false);
			this.AGS_Form.GetChild(10).GetChild(0).GetChild(14).GetChild(5).gameObject.SetActive(true);
			UIText component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(11).GetChild(0).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(9547u);
			component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(10).GetChild(0).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7530u);
			component = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(1).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID(7532u);
			RectTransform component2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(7).GetChild(2).GetComponent<RectTransform>();
			component2.localScale = new Vector3(-1f, 1f, 1f);
			component2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetChild(7).GetChild(3).GetComponent<RectTransform>();
			component2.localScale = new Vector3(-1f, 1f, 1f);
		}
	}

	// Token: 0x06001DD9 RID: 7641 RVA: 0x003820E8 File Offset: 0x003802E8
	private void SetItemGemDetail()
	{
		RectTransform component = this.AGS_Form.GetChild(9).GetChild(1).GetComponent<RectTransform>();
		UILEBtn component2 = component.GetComponent<UILEBtn>();
		component2.SetCountdown(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ExpireTime, false);
		bool flag = this.DM.mLordEquip.isRoleEquipThis(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO);
		GUIManager.Instance.ChangeLordEquipImg(component, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus], eLordEquipDisplayKind.OnlyItem, flag);
		UIText component3 = this.AGS_Form.GetChild(9).GetChild(2).GetChild(0).GetComponent<UIText>();
		if (flag)
		{
			this.AGS_Form.GetChild(9).GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(1);
			component3.text = this.DM.mStringTable.GetStringByID(7494u);
		}
		else
		{
			this.AGS_Form.GetChild(9).GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(0);
			component3.text = this.DM.mStringTable.GetStringByID(7469u);
		}
		component3.SetAllDirty();
		component3.cachedTextGenerator.Invalidate();
		Equip recordByKey;
		for (int i = 0; i < 4; i++)
		{
			component = this.AGS_Form.GetChild(9).GetChild(7).GetChild(i).GetComponent<RectTransform>();
			component3 = component.GetChild(3).GetComponent<UIText>();
			if (i == 3)
			{
				recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ItemID);
				if (!this.newGemTechReady(recordByKey.EquipKind))
				{
					GUIManager.Instance.ChangeLordEquipImg(component.GetChild(0), 0, 0, eLordEquipDisplayKind.Item_NewGem, 0, 0, 0, 0, 0, false);
					this.GemBtnText[i].ClearString();
					this.GemBtnText[i].Append(this.DM.mStringTable.GetStringByID(7473u));
					component.GetChild(1).gameObject.SetActive(true);
					component.GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(3);
					component.GetChild(0).GetComponent<uButtonScale>().enabled = false;
				}
				else if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Gem[i] == 0)
				{
					GUIManager.Instance.ChangeLordEquipImg(component.GetChild(0), 0, 0, eLordEquipDisplayKind.Item_NewGem, 0, 0, 0, 0, 0, false);
					this.GemBtnText[i].ClearString();
					this.GemBtnText[i].Append(this.DM.mStringTable.GetStringByID(7471u));
					component.GetChild(1).gameObject.SetActive(false);
					component.GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(2);
					component.GetChild(0).GetComponent<uButtonScale>().enabled = false;
				}
				else
				{
					recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Gem[i]);
					GUIManager.Instance.ChangeLordEquipImg(component.GetChild(0), this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Gem[i], this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].GemColor[i], eLordEquipDisplayKind.Gems_Name, 0, 0, 0, 0, 0, false);
					this.GemBtnText[i].ClearString();
					this.GemBtnText[i].Append(this.DM.mStringTable.GetStringByID(7472u));
					component.GetChild(1).gameObject.SetActive(false);
					component.GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(0);
					component.GetChild(0).GetComponent<uButtonScale>().enabled = true;
				}
			}
			else if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Gem[i] == 0)
			{
				GUIManager.Instance.ChangeLordEquipImg(component.GetChild(0), 0, 0, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				this.GemBtnText[i].ClearString();
				this.GemBtnText[i].Append(this.DM.mStringTable.GetStringByID(7471u));
				component.GetChild(1).gameObject.SetActive(false);
				component.GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(2);
				component.GetChild(0).GetComponent<uButtonScale>().enabled = false;
			}
			else
			{
				recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Gem[i]);
				GUIManager.Instance.ChangeLordEquipImg(component.GetChild(0), this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Gem[i], this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].GemColor[i], eLordEquipDisplayKind.Gems_Name, 0, 0, 0, 0, 0, false);
				this.GemBtnText[i].ClearString();
				this.GemBtnText[i].Append(this.DM.mStringTable.GetStringByID(7472u));
				component.GetChild(1).gameObject.SetActive(false);
				component.GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(0);
				component.GetChild(0).GetComponent<uButtonScale>().enabled = true;
			}
			component3.text = this.GemBtnText[i].ToString();
			component3.SetAllDirty();
			component3.cachedTextGenerator.Invalidate();
		}
		recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ItemID);
		component3 = this.AGS_Form.GetChild(9).GetChild(4).GetComponent<UIText>();
		this.ItemNameText.ClearString();
		GameConstants.GetColoredLordEquipString(this.ItemNameText, ref recordByKey, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Color);
		component3.text = this.ItemNameText.ToString();
		component3.SetAllDirty();
		component3.cachedTextGenerator.Invalidate();
		if (GameConstants.IsBetween((int)this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Color, 0, 6))
		{
			this.AGS_ItemRare.SetSpriteIndex((int)(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Color - 1));
		}
		component3 = this.AGS_Form.GetChild(9).GetChild(6).GetComponent<UIText>();
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
		component3.text = this.ItemLevelText.ToString();
		component3.SetAllDirty();
		component3.cachedTextGenerator.Invalidate();
		this.effectList.Clear();
		LordEquipData.GetEffectList(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus], this.effectList, 0, 0, false);
		int num = this.effectList.Count - 1;
		for (int j = 0; j < this.effectList.Count; j++)
		{
			if (this.effectList[num].isNewGemEffect == 1)
			{
				LordEquipEffectSet item = this.effectList[num];
				this.effectList.RemoveAt(num);
				this.effectList.Insert(0, item);
			}
			else
			{
				num--;
			}
		}
		recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ItemID);
		if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Color == 5 && recordByKey.NewGemEffect[0] > 0)
		{
			this.AGS_Form.GetChild(9).GetChild(8).gameObject.SetActive(true);
			this.AGS_Form.GetChild(9).GetChild(12).gameObject.SetActive(false);
			if (this.DM.GetTechLevel(227) > 0)
			{
				this.AGS_Form.GetChild(9).GetChild(8).GetComponent<Image>().color = Color.white;
				this.AGS_Form.GetChild(9).GetChild(8).GetChild(0).GetComponent<Image>().color = Color.white;
				this.AGS_Form.GetChild(9).GetChild(8).GetChild(3).gameObject.SetActive(false);
				this.AGS_Form.GetChild(9).GetChild(8).GetComponent<UIButton>().m_BtnID2 = 2;
			}
			else
			{
				this.AGS_Form.GetChild(9).GetChild(8).GetComponent<Image>().color = Color.gray;
				this.AGS_Form.GetChild(9).GetChild(8).GetChild(0).GetComponent<Image>().color = Color.gray;
				this.AGS_Form.GetChild(9).GetChild(8).GetChild(3).gameObject.SetActive(true);
				this.AGS_Form.GetChild(9).GetChild(8).GetComponent<UIButton>().m_BtnID2 = 4;
			}
		}
		else if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Color >= 5)
		{
			this.AGS_Form.GetChild(9).GetChild(8).gameObject.SetActive(false);
			this.AGS_Form.GetChild(9).GetChild(12).gameObject.SetActive(true);
		}
		else
		{
			this.AGS_Form.GetChild(9).GetChild(8).gameObject.SetActive(true);
			this.AGS_Form.GetChild(9).GetChild(12).gameObject.SetActive(false);
			this.AGS_Form.GetChild(9).GetChild(8).GetComponent<Image>().color = Color.white;
			this.AGS_Form.GetChild(9).GetChild(8).GetChild(0).GetComponent<Image>().color = Color.white;
			this.AGS_Form.GetChild(9).GetChild(8).GetChild(3).gameObject.SetActive(false);
			this.AGS_Form.GetChild(9).GetChild(8).GetComponent<UIButton>().m_BtnID2 = 2;
		}
		this.AGS_Form.GetChild(9).GetChild(8).GetChild(2).gameObject.SetActive(this.DM.mLordEquip.CheckItemUpgradeReady(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus]));
		this.SPHeight.Clear();
		if (this.effectList.Count > 0)
		{
			for (int k = 0; k < this.effectList.Count; k++)
			{
				if (this.effectList[k].isNewGemEffect == 1)
				{
					CString cstring2 = StringManager.Instance.StaticString1024();
					cstring2.ClearString();
					LordEquipData.GetNewGemEffectString(cstring2, (byte)this.effectList[k].EffectID, (int)this.effectList[k].EffectValue, true, 0);
					this.SPHeight.Add(this.GetTextHeight(420f, cstring2, 18));
				}
				else
				{
					this.SPHeight.Add(26f);
				}
			}
		}
		this.AGS_ScrollPanel2.AddNewDataHeight(this.SPHeight, 228f, true);
	}

	// Token: 0x06001DDA RID: 7642 RVA: 0x00382DB4 File Offset: 0x00380FB4
	private void UpdateInvRow(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (dataIdx + 1 == this.SPHeight.Count && this.ShowUnlockPanel)
		{
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			UIButton component = item.transform.GetChild(1).GetChild(0).GetComponent<UIButton>();
			component.m_Handler = this;
			component.m_BtnID1 = 7;
		}
		else
		{
			for (int i = 0; i < 4; i++)
			{
				ushort num = (ushort)(dataIdx * 4 + i);
				UILEBtn component2 = item.transform.GetChild(0).GetChild(i).GetComponent<UILEBtn>();
				component2.m_Handler = this;
				component2.m_BtnID1 = 1;
				component2.m_BtnID2 = 0;
				if (this.OpenKind == eUI_LordEquipOpenKind.Collection)
				{
					component2.ReLinkScale();
					if (this.OpenStat == UILordEquip.eUIOpenStat.ItemInfo)
					{
						component2.SetEffectType(e_EffectType.e_Normal);
						component2.transform.GetComponent<uButtonScale>().enabled = false;
					}
					else
					{
						component2.SetEffectType(e_EffectType.e_Scale);
						component2.transform.GetComponent<uButtonScale>().enabled = true;
					}
				}
				Transform child = item.transform.GetChild(0).GetChild(i + 4);
				if ((int)num < this.FilterItem.Count)
				{
					component2.m_BtnID2 = (int)this.FilterItem[(int)num];
					switch (this.FilterKind)
					{
					case UILordEquip.eItemFilterByKind.Gem:
					case UILordEquip.eItemFilterByKind.GemFilter:
					case UILordEquip.eItemFilterByKind.NewGem:
						GUIManager.Instance.ChangeLordEquipImg(component2.transform, this.DM.mLordEquip.LEGem[(int)this.FilterItem[(int)num]], eLordEquipDisplayKind.Gems_Name_Quantity);
						child.gameObject.SetActive(false);
						goto IL_4D6;
					case UILordEquip.eItemFilterByKind.Material:
						GUIManager.Instance.ChangeLordEquipImg(component2.transform, this.DM.mLordEquip.LEMaterial[(int)this.FilterItem[(int)num]], eLordEquipDisplayKind.Gems_Name_Quantity);
						child.gameObject.SetActive(false);
						goto IL_4D6;
					}
					if (this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt)
					{
						GUIManager.Instance.ChangeLordEquipImg(component2.transform, this.DM.mLordEquip.LordEquip[(int)this.FilterItem[(int)num]], eLordEquipDisplayKind.Item_Gems, UILordEquipSetEdit.showingSet.isInSet(this.DM.mLordEquip.LordEquip[(int)this.FilterItem[(int)num]].SerialNO));
					}
					else
					{
						GUIManager.Instance.ChangeLordEquipImg(component2.transform, this.DM.mLordEquip.LordEquip[(int)this.FilterItem[(int)num]], eLordEquipDisplayKind.Item_Gems, this.DM.mLordEquip.isRoleEquipThis(this.DM.mLordEquip.LordEquip[(int)this.FilterItem[(int)num]].SerialNO));
					}
					component2.SetCountdown(this.DM.mLordEquip.LordEquip[(int)this.FilterItem[(int)num]].ExpireTime, false);
					child.gameObject.SetActive(this.OpenKind == eUI_LordEquipOpenKind.Collection && this.DM.mLordEquip.CheckItemUpgradeReady(this.DM.mLordEquip.LordEquip[(int)this.FilterItem[(int)num]]));
					UILordEquip.eUIOpenStat openStat = this.OpenStat;
					if (openStat == UILordEquip.eUIOpenStat.Normal)
					{
						if (this.OpenKind != eUI_LordEquipOpenKind.Collection && this.FilterItem[(int)num] == UILordEquip.EquipFocus && this.isFocused)
						{
							this.Select.position = component2.transform.position;
							this.Select.gameObject.SetActive(true);
						}
						if (this.DM.RoleAttr.LordEquipEventData.ItemID != 0 && this.DM.RoleAttr.LordEquipEventData.SerialNO != 0u && this.DM.mLordEquip.LordEquip[(int)this.FilterItem[(int)num]].SerialNO == this.DM.RoleAttr.LordEquipEventData.SerialNO)
						{
							this.Forging.position = component2.transform.position;
							this.Forging.gameObject.SetActive(true);
						}
						if (this.lockEmptyForge && (int)this.FilterItem[(int)num] == this.lockedIdx)
						{
							GUIManager.Instance.ChangeLordEquipImg(component2.transform, this.DM.RoleAttr.LordEquipEventData, eLordEquipDisplayKind.Item_Gems, false);
							this.Forging.position = component2.transform.position;
							this.Forging.gameObject.SetActive(true);
						}
					}
				}
				IL_4D6:
				component2.gameObject.SetActive((int)num < this.FilterItem.Count);
				if (this.OpenKind != eUI_LordEquipOpenKind.Collection || (int)num >= this.FilterItem.Count)
				{
					child.gameObject.SetActive(false);
				}
			}
			item.transform.GetChild(0).gameObject.SetActive(true);
			item.transform.GetChild(1).gameObject.SetActive(false);
		}
	}

	// Token: 0x06001DDB RID: 7643 RVA: 0x00383318 File Offset: 0x00381518
	private void UpdateSideCompareRow(GameObject item, int dataIdx, int panelObjectIdx)
	{
		Effect recordByKey = this.DM.EffectData.GetRecordByKey(this.effectCompareList[dataIdx].EffectID);
		if (this.effectCompareList[dataIdx].isTitel)
		{
			UIText component = item.transform.GetChild(0).GetComponent<UIText>();
			item.transform.GetChild(0).gameObject.SetActive(true);
			item.transform.GetChild(1).gameObject.SetActive(false);
			item.transform.GetChild(2).gameObject.SetActive(false);
			if (this.effectCompareList[dataIdx].group == 255)
			{
				component.text = this.DM.mStringTable.GetStringByID(16141u);
			}
			else
			{
				component.text = this.DM.mStringTable.GetStringByID((uint)((ushort)(8484 + (int)this.effectCompareList[dataIdx].group)));
			}
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else if (this.effectCompareList[dataIdx].isNewGemEffect == 0)
		{
			UIText component = item.transform.GetChild(1).GetComponent<UIText>();
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			item.transform.GetChild(2).gameObject.SetActive(false);
			this.EffDescText[panelObjectIdx].ClearString();
			this.EffDescText[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.InfoID));
			if (this.effectCompareList[dataIdx].isEven)
			{
				this.EffDescText[panelObjectIdx].StringToFormat("<color=#FFFFFF>");
			}
			else if (this.effectCompareList[dataIdx].EffectValue < 0)
			{
				this.EffDescText[panelObjectIdx].StringToFormat("<color=#FF656EFF>");
			}
			else
			{
				this.EffDescText[panelObjectIdx].StringToFormat("<color=#35F76CFF>+");
			}
			if (recordByKey.ValueID == 0)
			{
				this.EffDescText[panelObjectIdx].IntToFormat((long)this.effectCompareList[dataIdx].EffectValue, 1, false);
				this.EffDescText[panelObjectIdx].AppendFormat("<color=#FFEC87FF>{0}</color> {1} {2}</color>");
			}
			else
			{
				float f = (float)this.effectCompareList[dataIdx].EffectValue / 100f;
				this.EffDescText[panelObjectIdx].FloatToFormat(f, 2, false);
				this.EffDescText[panelObjectIdx].AppendFormat("<color=#FFEC87FF>{0}</color> {1} {2}%</color>");
			}
			component.text = this.EffDescText[panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			if (!GameConstants.IsBigStyle())
			{
				component.resizeTextMaxSize = 16;
			}
		}
		else
		{
			UIText component = item.transform.GetChild(2).GetComponent<UIText>();
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(false);
			item.transform.GetChild(2).gameObject.SetActive(true);
			this.EffDescText[panelObjectIdx].ClearString();
			LordEquipData.GetNewGemEffectString(this.EffDescText[panelObjectIdx], (byte)this.effectCompareList[dataIdx].EffectID, this.effectCompareList[dataIdx].EffectValue, this.effectCompareList[dataIdx].isEven, this.effectCompareList[dataIdx].useForceColor);
			if (this.effectCompareList[dataIdx].isNewGemEffect == 1)
			{
				component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, this.GetTextHeight(260f, this.EffDescText[panelObjectIdx], 18));
				component.fontSize = 18;
			}
			else
			{
				component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, this.GetTextHeight(260f, this.EffDescText[panelObjectIdx], 16));
				component.fontSize = 16;
			}
			component.text = this.EffDescText[panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06001DDC RID: 7644 RVA: 0x00383748 File Offset: 0x00381948
	private void UpdateEqInfoRow(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (this.effectList[dataIdx].isNewGemEffect == 1)
		{
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			item.transform.GetChild(1).GetChild(0).gameObject.SetActive(dataIdx % 2 == 0);
			UIText component = item.transform.GetChild(1).GetChild(1).GetComponent<UIText>();
			this.EffDescText[panelObjectIdx].ClearString();
			LordEquipData.GetNewGemEffectString(this.EffDescText[panelObjectIdx], (byte)this.effectList[dataIdx].EffectID, (int)this.effectList[dataIdx].EffectValue, true, 0);
			float textHeight = this.GetTextHeight(420f, this.EffDescText[panelObjectIdx], 18);
			component.fontSize = 18;
			component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, textHeight);
			component.text = this.EffDescText[panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			if (dataIdx % 2 == 0)
			{
				RectTransform component2 = item.transform.GetChild(1).GetChild(0).GetComponent<RectTransform>();
				component2.localPosition = new Vector3(0f, -2f);
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, textHeight);
			}
			ushort effectID = this.effectList[dataIdx].EffectID;
			if (effectID != 1)
			{
				item.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
			}
			else
			{
				item.transform.GetChild(1).GetChild(2).gameObject.SetActive((ushort)this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Color > this.effectList[dataIdx].EffectValue);
				UIButtonHint component3 = item.transform.GetChild(1).GetChild(2).GetComponent<UIButtonHint>();
				component3.Parm1 = 16134;
				component3.m_Handler = this;
			}
		}
		else
		{
			item.transform.GetChild(0).gameObject.SetActive(true);
			item.transform.GetChild(0).GetChild(0).gameObject.SetActive(dataIdx % 2 == 0);
			item.transform.GetChild(1).gameObject.SetActive(false);
			Effect recordByKey = this.DM.EffectData.GetRecordByKey(this.effectList[dataIdx].EffectID);
			UIText component4 = item.transform.GetChild(0).GetChild(1).GetComponent<UIText>();
			component4.color = new Color32(233, 207, 167, byte.MaxValue);
			component4.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.InfoID);
			component4 = item.transform.GetChild(0).GetChild(2).GetComponent<UIText>();
			component4.color = new Color32(233, 207, 167, byte.MaxValue);
			this.EffDescText[panelObjectIdx].ClearString();
			if (recordByKey.ValueID == 0)
			{
				this.EffDescText[panelObjectIdx].IntToFormat((long)this.effectList[dataIdx].EffectValue, 1, false);
				this.EffDescText[panelObjectIdx].AppendFormat("{0}");
			}
			else
			{
				this.EffDescText[panelObjectIdx].FloatToFormat((float)this.effectList[dataIdx].EffectValue / 100f, 2, false);
				if (!GUIManager.Instance.IsArabic)
				{
					this.EffDescText[panelObjectIdx].AppendFormat("{0}%");
				}
				else
				{
					this.EffDescText[panelObjectIdx].AppendFormat("%{0}");
				}
			}
			component4.text = this.EffDescText[panelObjectIdx].ToString();
			component4.SetAllDirty();
			component4.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06001DDD RID: 7645 RVA: 0x00383B4C File Offset: 0x00381D4C
	private void UpdatePopUpRow(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (dataIdx >= this.effectList.Count)
		{
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(false);
			return;
		}
		if (this.effectList[dataIdx].isNewGemEffect == 0)
		{
			Effect recordByKey = this.DM.EffectData.GetRecordByKey(this.effectList[dataIdx].EffectID);
			UIText component = item.transform.GetChild(0).GetChild(0).GetComponent<UIText>();
			component.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.InfoID);
			component = item.transform.GetChild(0).GetChild(1).GetComponent<UIText>();
			item.transform.GetChild(0).gameObject.SetActive(true);
			item.transform.GetChild(1).gameObject.SetActive(false);
			this.PopupEffectText[panelObjectIdx].ClearString();
			if (recordByKey.ValueID == 0)
			{
				this.PopupEffectText[panelObjectIdx].IntToFormat((long)this.effectList[dataIdx].EffectValue, 1, false);
				this.PopupEffectText[panelObjectIdx].AppendFormat("{0}");
			}
			else
			{
				this.PopupEffectText[panelObjectIdx].FloatToFormat((float)this.effectList[dataIdx].EffectValue / 100f, 2, false);
				if (!GUIManager.Instance.IsArabic)
				{
					this.PopupEffectText[panelObjectIdx].AppendFormat("{0}%");
				}
				else
				{
					this.PopupEffectText[panelObjectIdx].AppendFormat("%{0}");
				}
			}
			component.text = this.PopupEffectText[panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			UIText component = item.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			this.PopupEffectText[panelObjectIdx].ClearString();
			if (this.effectList[dataIdx].isNewGemEffect == 1)
			{
				LordEquipData.GetNewGemEffectString(this.PopupEffectText[panelObjectIdx], (byte)this.effectList[dataIdx].EffectID, (int)this.effectList[dataIdx].EffectValue, true, 0);
				component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, this.GetTextHeight(300f, this.PopupEffectText[panelObjectIdx], 18));
				component.fontSize = 18;
				component.color = Color.white;
			}
			else
			{
				this.PopupEffectText[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID((uint)this.effectList[dataIdx].EffectID));
				component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, this.GetTextHeight(300f, this.PopupEffectText[panelObjectIdx], 16));
				component.fontSize = 16;
				component.color = new Color32(byte.MaxValue, 247, 153, byte.MaxValue);
			}
			component.text = this.PopupEffectText[panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component.cachedTextGeneratorForLayout.Invalidate();
		}
	}

	// Token: 0x06001DDE RID: 7646 RVA: 0x00383EA8 File Offset: 0x003820A8
	private void UpdateNewGemRow(GameObject item, int dataIdx, int panelObjectIdx)
	{
		if (dataIdx >= this.effectList.Count)
		{
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(false);
			return;
		}
		if (this.effectList[dataIdx].isNewGemEffect == 0)
		{
			Effect recordByKey = this.DM.EffectData.GetRecordByKey(this.effectList[dataIdx].EffectID);
			item.transform.GetChild(0).gameObject.SetActive(true);
			item.transform.GetChild(1).gameObject.SetActive(false);
			UIText component = item.transform.GetChild(0).GetComponent<UIText>();
			component.color = new Color32(233, 207, 167, byte.MaxValue);
			this.EffDescText[panelObjectIdx].ClearString();
			this.EffDescText[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.InfoID));
			this.EffDescText[panelObjectIdx].StringToFormat("<color=#35F76CFF>");
			if (recordByKey.ValueID == 0)
			{
				this.EffDescText[panelObjectIdx].IntToFormat((long)this.effectList[dataIdx].EffectValue, 1, false);
				this.EffDescText[panelObjectIdx].AppendFormat("<color=#FFEC87FF>{0}</color> {1} +{2}</color>");
			}
			else
			{
				float f = (float)this.effectList[dataIdx].EffectValue / 100f;
				this.EffDescText[panelObjectIdx].FloatToFormat(f, 2, false);
				this.EffDescText[panelObjectIdx].AppendFormat("<color=#FFEC87FF>{0}</color> {1} +{2}%</color>");
			}
			component.text = this.EffDescText[panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			UIText component = item.transform.GetChild(1).GetComponent<UIText>();
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			this.EffDescText[panelObjectIdx].ClearString();
			if (this.effectList[dataIdx].isNewGemEffect == 1)
			{
				LordEquipData.GetNewGemEffectString(this.EffDescText[panelObjectIdx], (byte)this.effectList[dataIdx].EffectID, (int)this.effectList[dataIdx].EffectValue, true, 0);
				component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, this.GetTextHeight(295f, this.EffDescText[panelObjectIdx], 18));
				component.fontSize = 18;
				component.color = Color.white;
			}
			else
			{
				this.EffDescText[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID((uint)this.effectList[dataIdx].EffectID));
				component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, this.GetTextHeight(295f, this.EffDescText[panelObjectIdx], 16));
				component.fontSize = 16;
				component.color = new Color32(byte.MaxValue, 247, 153, byte.MaxValue);
			}
			component.text = this.EffDescText[panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06001DDF RID: 7647 RVA: 0x003841F0 File Offset: 0x003823F0
	private void SetMainFilter(UILordEquip.eItemFilterByKind filter)
	{
		this.ShowUnlockPanel = false;
		this.FilterKind = filter;
		this.lockEmptyForge = false;
		switch (filter)
		{
		case UILordEquip.eItemFilterByKind.AllEquip:
		{
			if (this.DM.mLordEquip.LoadLordEquip(false))
			{
				return;
			}
			this.FilterItem.Clear();
			for (ushort num = 0; num < (ushort)this.DM.RoleAttr.LordEquipBagSize; num += 1)
			{
				if (this.DM.mLordEquip.LordEquip[(int)num].ItemID != 0)
				{
					this.FilterItem.Add(num);
				}
			}
			LordEquipData.Instance().SetDictionary(false);
			this.FilterItem.Sort(new Comparison<ushort>(LordEquipData.ItemSort));
			bool flag = this.DM.RoleAttr.LordEquipEventData.ItemID != 0 && this.DM.RoleAttr.LordEquipEventData.SerialNO == 0u;
			for (ushort num2 = 0; num2 < (ushort)this.DM.RoleAttr.LordEquipBagSize; num2 += 1)
			{
				if (this.DM.mLordEquip.LordEquip[(int)num2].ItemID == 0)
				{
					if (flag)
					{
						flag = false;
						this.lockEmptyForge = true;
						this.lockedIdx = (int)num2;
					}
					this.FilterItem.Add(num2);
				}
			}
			int num3 = this.FilterItem.Count / 4;
			if (this.FilterItem.Count % 4 != 0)
			{
				num3++;
			}
			this.SPHeight.Clear();
			for (int i = 0; i < num3; i++)
			{
				this.SPHeight.Add(117f);
			}
			if (this.DM.RoleAttr.LordEquipBagSize < 200 && this.OpenKind == eUI_LordEquipOpenKind.Collection)
			{
				this.SPHeight.Add(160f);
				this.ShowUnlockPanel = true;
			}
			if (this.SPHeight.Count >= 4 && this.SPHeight[this.SPHeight.Count - 1] < 130f)
			{
				this.SPHeight.RemoveAt(this.SPHeight.Count - 1);
				this.SPHeight.Add(130f);
			}
			this.Forging.gameObject.SetActive(false);
			this.AGS_ScrollArea.gameObject.SetActive(true);
			this.AGS_ScrollArea.AddNewDataHeight(this.SPHeight, 488f, true);
			this.AGS_ScrollArea.GoTo(UILordEquip.EquipTopIdx, UILordEquip.EquipTopPos);
			this.AGS_Form.GetChild(4).GetChild(0).gameObject.SetActive(false);
			break;
		}
		case UILordEquip.eItemFilterByKind.Head:
		case UILordEquip.eItemFilterByKind.Body:
		case UILordEquip.eItemFilterByKind.Lag:
		case UILordEquip.eItemFilterByKind.Weapon:
		case UILordEquip.eItemFilterByKind.OffHand:
		case UILordEquip.eItemFilterByKind.Accessories:
		{
			if (this.DM.mLordEquip.LoadLordEquip(false))
			{
				return;
			}
			this.FilterItem.Clear();
			for (ushort num4 = 0; num4 < (ushort)this.DM.RoleAttr.LordEquipBagSize; num4 += 1)
			{
				if (this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int)num4].ItemID).EquipKind == (byte)filter + 20)
				{
					this.FilterItem.Add(num4);
				}
			}
			LordEquipData.Instance().SetDictionary(true);
			this.FilterItem.Sort(new Comparison<ushort>(LordEquipData.ItemSort));
			int num5 = 0;
			if (this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt)
			{
				if (filter == UILordEquip.eItemFilterByKind.Accessories)
				{
					for (int j = 0; j < this.FilterItem.Count; j++)
					{
						if (UILordEquipSetEdit.showingSet.SerialNO[(int)((byte)filter - 1)] == this.DM.mLordEquip.LordEquip[(int)this.FilterItem[j]].SerialNO)
						{
							ushort item = this.FilterItem[j];
							this.FilterItem.RemoveAt(j);
							this.FilterItem.Insert(num5, item);
							num5++;
						}
					}
					for (int k = 0; k < this.FilterItem.Count; k++)
					{
						if (UILordEquipSetEdit.showingSet.SerialNO[(int)((byte)filter)] == this.DM.mLordEquip.LordEquip[(int)this.FilterItem[k]].SerialNO)
						{
							ushort item2 = this.FilterItem[k];
							this.FilterItem.RemoveAt(k);
							this.FilterItem.Insert(num5, item2);
							num5++;
						}
					}
					for (int l = 0; l < this.FilterItem.Count; l++)
					{
						if (UILordEquipSetEdit.showingSet.SerialNO[(int)((byte)filter + 1)] == this.DM.mLordEquip.LordEquip[(int)this.FilterItem[l]].SerialNO)
						{
							ushort item3 = this.FilterItem[l];
							this.FilterItem.RemoveAt(l);
							this.FilterItem.Insert(num5, item3);
							num5++;
						}
					}
				}
				else
				{
					for (int m = 0; m < this.FilterItem.Count; m++)
					{
						if (UILordEquipSetEdit.showingSet.SerialNO[(int)((byte)filter - 1)] == this.DM.mLordEquip.LordEquip[(int)this.FilterItem[m]].SerialNO)
						{
							ushort item4 = this.FilterItem[m];
							this.FilterItem.RemoveAt(m);
							this.FilterItem.Insert(num5, item4);
							num5++;
						}
					}
				}
			}
			else if (filter == UILordEquip.eItemFilterByKind.Accessories)
			{
				for (int n = 0; n < this.FilterItem.Count; n++)
				{
					if (LordEquipData.RoleEquipSerial[(int)((byte)filter - 1)] == this.DM.mLordEquip.LordEquip[(int)this.FilterItem[n]].SerialNO)
					{
						ushort item5 = this.FilterItem[n];
						this.FilterItem.RemoveAt(n);
						this.FilterItem.Insert(num5, item5);
						num5++;
					}
				}
				for (int num6 = 0; num6 < this.FilterItem.Count; num6++)
				{
					if (LordEquipData.RoleEquipSerial[(int)((byte)filter)] == this.DM.mLordEquip.LordEquip[(int)this.FilterItem[num6]].SerialNO)
					{
						ushort item6 = this.FilterItem[num6];
						this.FilterItem.RemoveAt(num6);
						this.FilterItem.Insert(num5, item6);
						num5++;
					}
				}
				for (int num7 = 0; num7 < this.FilterItem.Count; num7++)
				{
					if (LordEquipData.RoleEquipSerial[(int)((byte)filter + 1)] == this.DM.mLordEquip.LordEquip[(int)this.FilterItem[num7]].SerialNO)
					{
						ushort item7 = this.FilterItem[num7];
						this.FilterItem.RemoveAt(num7);
						this.FilterItem.Insert(num5, item7);
						num5++;
					}
				}
			}
			else
			{
				for (int num8 = 0; num8 < this.FilterItem.Count; num8++)
				{
					if (LordEquipData.RoleEquipSerial[(int)((byte)filter - 1)] == this.DM.mLordEquip.LordEquip[(int)this.FilterItem[num8]].SerialNO)
					{
						ushort item8 = this.FilterItem[num8];
						this.FilterItem.RemoveAt(num8);
						this.FilterItem.Insert(num5, item8);
						num5++;
					}
				}
			}
			int num9 = this.FilterItem.Count / 4;
			if (this.FilterItem.Count % 4 != 0)
			{
				num9++;
			}
			this.SPHeight.Clear();
			for (int num10 = 0; num10 < num9; num10++)
			{
				this.SPHeight.Add(117f);
			}
			if (this.SPHeight.Count >= 4 && this.SPHeight[this.SPHeight.Count - 1] < 130f)
			{
				this.SPHeight.RemoveAt(this.SPHeight.Count - 1);
				this.SPHeight.Add(130f);
			}
			this.AGS_Form.GetChild(4).GetChild(0).gameObject.SetActive(this.FilterItem.Count == 0);
			if (this.FilterItem.Count == 0)
			{
				UIText component = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
				this.NoContentText.ClearString();
				this.NoContentText.Append(this.DM.mStringTable.GetStringByID(744u));
				component.text = this.NoContentText.ToString();
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				this.AGS_Form.GetChild(5).gameObject.SetActive(false);
				this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(true);
				if (this.Select != null)
				{
					this.Select.gameObject.SetActive(false);
					this.isFocused = false;
				}
			}
			else if (this.OnStartSelect && this.OpenKind == eUI_LordEquipOpenKind.SelectSolt)
			{
				for (int num11 = 0; num11 < this.FilterItem.Count; num11++)
				{
					if (LordEquipData.RoleEquipSerial[(int)(this.EquipSolt - 1)] == this.DM.mLordEquip.LordEquip[(int)this.FilterItem[num11]].SerialNO)
					{
						UILordEquip.EquipFocus = this.FilterItem[num11];
						this.isFocused = true;
					}
				}
				if (!this.isFocused)
				{
					for (int num12 = 0; num12 < this.FilterItem.Count; num12++)
					{
						if (this.DM.RoleAttr.LordEquipEventData.SerialNO != this.DM.mLordEquip.LordEquip[(int)this.FilterItem[num12]].SerialNO && !this.DM.mLordEquip.isRoleEquipThis(this.DM.mLordEquip.LordEquip[(int)this.FilterItem[num12]].SerialNO))
						{
							UILordEquip.EquipFocus = this.FilterItem[num12];
							this.isFocused = true;
							break;
						}
					}
				}
				this.OnStartSelect = false;
			}
			else if (this.OnStartSelect && this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt)
			{
				for (int num13 = 0; num13 < this.FilterItem.Count; num13++)
				{
					if (UILordEquipSetEdit.showingSet.SerialNO[UILordEquipSetEdit.ChangingIdx] == this.DM.mLordEquip.LordEquip[(int)this.FilterItem[num13]].SerialNO)
					{
						UILordEquip.EquipFocus = this.FilterItem[num13];
						this.isFocused = true;
					}
				}
				if (!this.isFocused)
				{
					for (int num14 = 0; num14 < this.FilterItem.Count; num14++)
					{
						if (!UILordEquipSetEdit.showingSet.isInSet(this.DM.mLordEquip.LordEquip[(int)this.FilterItem[num14]].SerialNO))
						{
							UILordEquip.EquipFocus = this.FilterItem[num14];
							this.isFocused = true;
							break;
						}
					}
				}
				this.OnStartSelect = false;
			}
			this.Forging.gameObject.SetActive(false);
			this.AGS_ScrollArea.AddNewDataHeight(this.SPHeight, 488f, true);
			if (this.FilterItem.Count > 0)
			{
				this.AGS_Form.GetChild(5).gameObject.SetActive(true);
				this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
			}
			if (this.OpenKind == eUI_LordEquipOpenKind.SelectSolt || this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt)
			{
				this.SetSideInfo();
			}
			break;
		}
		case UILordEquip.eItemFilterByKind.Gem:
		{
			if (this.DM.mLordEquip.LoadLEGem(false))
			{
				return;
			}
			this.isFocused = false;
			this.FilterItem.Clear();
			ushort num15 = 0;
			while ((int)num15 < this.DM.mLordEquip.LEGem.Length)
			{
				if (this.DM.mLordEquip.LEGem[(int)num15].ItemID != 0 && this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LEGem[(int)num15].ItemID).NewGem == 0)
				{
					this.FilterItem.Add(num15);
				}
				num15 += 1;
			}
			this.FilterItem.Sort(new Comparison<ushort>(LordEquipData.GemSort));
			int num16 = this.FilterItem.Count / 4;
			if (this.FilterItem.Count % 4 != 0)
			{
				num16++;
			}
			this.SPHeight.Clear();
			for (int num17 = 0; num17 < num16; num17++)
			{
				this.SPHeight.Add(117f);
			}
			if (this.SPHeight.Count >= 4 && this.SPHeight[this.SPHeight.Count - 1] < 130f)
			{
				this.SPHeight.RemoveAt(this.SPHeight.Count - 1);
				this.SPHeight.Add(130f);
			}
			this.AGS_ScrollArea.AddNewDataHeight(this.SPHeight, 488f, this.isCollectChange);
			this.isCollectChange = false;
			this.AGS_ScrollArea.gameObject.SetActive(this.FilterItem.Count != 0);
			this.AGS_ScrollArea.GoTo(UILordEquip.GemTopIdx, UILordEquip.GemTopPos);
			this.AGS_Form.GetChild(4).GetChild(0).gameObject.SetActive(this.FilterItem.Count == 0);
			if (this.FilterItem.Count == 0)
			{
				this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
				UIText component2 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
				this.NoContentText.ClearString();
				this.NoContentText.Append(this.DM.mStringTable.GetStringByID(744u));
				component2.text = this.NoContentText.ToString();
				component2.SetAllDirty();
				component2.cachedTextGenerator.Invalidate();
			}
			break;
		}
		case UILordEquip.eItemFilterByKind.Material:
		{
			if (this.DM.mLordEquip.LoadLEMaterial(false))
			{
				return;
			}
			this.FilterItem.Clear();
			ushort num18 = 0;
			while ((int)num18 < this.DM.mLordEquip.LEMaterial.Length)
			{
				if (this.DM.mLordEquip.LEMaterial[(int)num18].ItemID != 0)
				{
					this.FilterItem.Add(num18);
				}
				num18 += 1;
			}
			this.FilterItem.Sort(new Comparison<ushort>(LordEquipData.MatSort));
			int num19 = this.FilterItem.Count / 4;
			if (this.FilterItem.Count % 4 != 0)
			{
				num19++;
			}
			this.SPHeight.Clear();
			for (int num20 = 0; num20 < num19; num20++)
			{
				this.SPHeight.Add(117f);
			}
			if (this.SPHeight.Count >= 4 && this.SPHeight[this.SPHeight.Count - 1] < 130f)
			{
				this.SPHeight.RemoveAt(this.SPHeight.Count - 1);
				this.SPHeight.Add(130f);
			}
			this.AGS_ScrollArea.AddNewDataHeight(this.SPHeight, 488f, this.isCollectChange);
			this.isCollectChange = false;
			this.AGS_ScrollArea.gameObject.SetActive(this.FilterItem.Count != 0);
			this.AGS_ScrollArea.GoTo(UILordEquip.MatTopIdx, UILordEquip.MatTopPos);
			this.AGS_Form.GetChild(4).GetChild(0).gameObject.SetActive(this.FilterItem.Count == 0);
			if (this.FilterItem.Count == 0)
			{
				this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
				UIText component3 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
				this.NoContentText.ClearString();
				this.NoContentText.Append(this.DM.mStringTable.GetStringByID(744u));
				component3.text = this.NoContentText.ToString();
				component3.SetAllDirty();
				component3.cachedTextGenerator.Invalidate();
			}
			break;
		}
		case UILordEquip.eItemFilterByKind.GemFilter:
		{
			if (UIEffectFilter.SeletedFilter == 0)
			{
				this.SetMainFilter(UILordEquip.eItemFilterByKind.Gem);
				return;
			}
			this.isFocused = false;
			this.FilterItem.Clear();
			ushort effectID = this.DM.LordEquipEffectFilter.GetRecordByIndex((int)(UIEffectFilter.SeletedFilter - 1)).effectID;
			ushort num21 = 0;
			while ((int)num21 < this.DM.mLordEquip.LEGem.Length)
			{
				if (this.DM.mLordEquip.LEGem[(int)num21].ItemID != 0)
				{
					Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LEGem[(int)num21].ItemID);
					if (recordByKey.NewGem == 0)
					{
						for (int num22 = 0; num22 < 6; num22++)
						{
							if (recordByKey.PropertiesInfo[num22].Propertieskey != 0 && this.DM.LordEquipEffectTable.GetRecordByKey(recordByKey.PropertiesInfo[num22].Propertieskey).EffectID == effectID)
							{
								this.FilterItem.Add(num21);
								break;
							}
						}
					}
				}
				num21 += 1;
			}
			this.FilterItem.Sort(new Comparison<ushort>(LordEquipData.GemSort));
			int num23 = this.FilterItem.Count / 4;
			if (this.FilterItem.Count % 4 != 0)
			{
				num23++;
			}
			this.SPHeight.Clear();
			for (int num24 = 0; num24 < num23; num24++)
			{
				this.SPHeight.Add(117f);
			}
			if (this.SPHeight.Count >= 4 && this.SPHeight[this.SPHeight.Count - 1] < 130f)
			{
				this.SPHeight.RemoveAt(this.SPHeight.Count - 1);
				this.SPHeight.Add(130f);
			}
			this.AGS_ScrollArea.AddNewDataHeight(this.SPHeight, 488f, true);
			this.AGS_Form.GetChild(4).GetChild(0).gameObject.SetActive(this.FilterItem.Count == 0);
			if (this.FilterItem.Count == 0)
			{
				this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
				UIText component4 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
				this.NoContentText.ClearString();
				this.NoContentText.Append(this.DM.mStringTable.GetStringByID(744u));
				component4.text = this.NoContentText.ToString();
				component4.SetAllDirty();
				component4.cachedTextGenerator.Invalidate();
			}
			break;
		}
		case UILordEquip.eItemFilterByKind.IDFilter:
		{
			this.FilterItem.Clear();
			for (ushort num25 = 0; num25 < (ushort)this.DM.RoleAttr.LordEquipBagSize; num25 += 1)
			{
				if (this.DM.mLordEquip.LordEquip[(int)num25].ItemID == UILordEquip.itemIDFilter && (ushort)this.DM.mLordEquip.LordEquip[(int)num25].Color == UILordEquip.itemColorFilter)
				{
					this.FilterItem.Add(num25);
				}
			}
			if (!this.isFocused)
			{
				UILordEquip.EquipFocus = this.FilterItem[0];
				this.isFocused = true;
			}
			int num26 = this.FilterItem.Count / 4;
			if (this.FilterItem.Count % 4 != 0)
			{
				num26++;
			}
			this.SPHeight.Clear();
			for (int num27 = 0; num27 < num26; num27++)
			{
				this.SPHeight.Add(117f);
			}
			if (this.SPHeight.Count >= 4 && this.SPHeight[this.SPHeight.Count - 1] < 130f)
			{
				this.SPHeight.RemoveAt(this.SPHeight.Count - 1);
				this.SPHeight.Add(130f);
			}
			this.Forging.gameObject.SetActive(false);
			this.AGS_ScrollArea.AddNewDataHeight(this.SPHeight, 488f, true);
			this.AGS_Form.GetChild(4).GetChild(0).gameObject.SetActive(this.FilterItem.Count == 0);
			if (this.FilterItem.Count == 0)
			{
				UIText component5 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
				this.NoContentText.ClearString();
				this.NoContentText.Append(this.DM.mStringTable.GetStringByID(744u));
				component5.text = this.NoContentText.ToString();
				component5.SetAllDirty();
				component5.cachedTextGenerator.Invalidate();
			}
			this.SetSideInfo();
			break;
		}
		case UILordEquip.eItemFilterByKind.NewGem:
		{
			if (this.DM.mLordEquip.LoadLEGem(false))
			{
				return;
			}
			this.isFocused = false;
			this.FilterItem.Clear();
			ushort num28 = 0;
			while ((int)num28 < this.DM.mLordEquip.LEGem.Length)
			{
				if (this.DM.mLordEquip.LEGem[(int)num28].ItemID != 0 && this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LEGem[(int)num28].ItemID).NewGem == 1)
				{
					this.FilterItem.Add(num28);
				}
				num28 += 1;
			}
			this.FilterItem.Sort(new Comparison<ushort>(LordEquipData.GemSort));
			int num29 = this.FilterItem.Count / 4;
			if (this.FilterItem.Count % 4 != 0)
			{
				num29++;
			}
			this.SPHeight.Clear();
			for (int num30 = 0; num30 < num29; num30++)
			{
				this.SPHeight.Add(117f);
			}
			if (this.SPHeight.Count >= 4 && this.SPHeight[this.SPHeight.Count - 1] < 130f)
			{
				this.SPHeight.RemoveAt(this.SPHeight.Count - 1);
				this.SPHeight.Add(130f);
			}
			this.AGS_ScrollArea.AddNewDataHeight(this.SPHeight, 488f, this.isCollectChange);
			this.isCollectChange = false;
			this.AGS_ScrollArea.gameObject.SetActive(this.FilterItem.Count != 0);
			this.AGS_ScrollArea.GoTo(UILordEquip.NewGemTopIdx, UILordEquip.NewGemTopPos);
			this.AGS_Form.GetChild(4).GetChild(0).gameObject.SetActive(this.FilterItem.Count == 0);
			if (this.FilterItem.Count == 0)
			{
				this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
				UIText component6 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
				component6.text = this.DM.mStringTable.GetStringByID(744u);
				component6.SetAllDirty();
				component6.cachedTextGenerator.Invalidate();
			}
			break;
		}
		}
	}

	// Token: 0x06001DE0 RID: 7648 RVA: 0x00385BA0 File Offset: 0x00383DA0
	private void GetMaterialRareCount(bool material, ushort itemID)
	{
		for (int i = 0; i < this.MaterCount.Length; i++)
		{
			this.MaterCount[i] = 0;
		}
		if (material)
		{
			for (int j = 0; j < this.DM.mLordEquip.LEMaterial.Length; j++)
			{
				if (this.DM.mLordEquip.LEMaterial[j].ItemID == itemID)
				{
					this.MaterCount[(int)(this.DM.mLordEquip.LEMaterial[j].Color - 1)] = this.DM.mLordEquip.LEMaterial[j].Quantity;
				}
			}
		}
		else
		{
			for (int k = 0; k < this.DM.mLordEquip.LEGem.Length; k++)
			{
				if (this.DM.mLordEquip.LEGem[k].ItemID == itemID)
				{
					this.MaterCount[(int)(this.DM.mLordEquip.LEGem[k].Color - 1)] = this.DM.mLordEquip.LEGem[k].Quantity;
				}
			}
		}
	}

	// Token: 0x06001DE1 RID: 7649 RVA: 0x00385CE0 File Offset: 0x00383EE0
	private bool isAbleDecompose(int selectItem, bool PopMessage = true)
	{
		if (this.DM.mLordEquip.isRoleEquipThis(this.DM.mLordEquip.LordEquip[selectItem].SerialNO))
		{
			GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(7490u), DataManager.Instance.mStringTable.GetStringByID(7511u), null, null, 0, 0, false, false, false, false, false);
			return false;
		}
		Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[selectItem].ItemID);
		bool flag = false;
		for (int i = 0; i < 4; i++)
		{
			ushort syntheticItem = recordByKey.SyntheticParts[i].SyntheticItem;
			if (syntheticItem > 0)
			{
				flag = true;
			}
			if (LordEquipData.getItemQuantity(syntheticItem, this.DM.mLordEquip.LordEquip[selectItem].Color) + (ushort)recordByKey.SyntheticParts[i].SyntheticItemNum > 65535)
			{
				GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(7490u), DataManager.Instance.mStringTable.GetStringByID(7509u), null, null, 0, 0, false, false, false, false, false);
				return false;
			}
		}
		if (!flag)
		{
			if (PopMessage)
			{
				GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(7490u), DataManager.Instance.mStringTable.GetStringByID(9575u), null, null, 0, 0, false, false, false, false, false);
			}
			return false;
		}
		return true;
	}

	// Token: 0x06001DE2 RID: 7650 RVA: 0x00385E7C File Offset: 0x0038407C
	private bool isAbleToImbueGame(int selectItem, ushort GemID, byte solt)
	{
		for (int i = 0; i < 4; i++)
		{
			if (i != (int)solt && this.DM.mLordEquip.LordEquip[selectItem].Gem[i] == GemID)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7512u), 255, true);
				return false;
			}
		}
		return true;
	}

	// Token: 0x06001DE3 RID: 7651 RVA: 0x00385EEC File Offset: 0x003840EC
	private bool EquipOrTakeDown()
	{
		if (this.DM.beCaptured.nowCaptureStat != LoadCaptureState.None)
		{
			GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(9696u), 255, true);
			return false;
		}
		for (int i = 0; i < LordEquipData.RoleEquipSerial.Length; i++)
		{
			if (LordEquipData.RoleEquipSerial[i] == this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO)
			{
				this.DM.mLordEquip.ChangeEquip((byte)i, 0u);
				return true;
			}
		}
		if (this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ItemID).NeedLv > this.DM.RoleAttr.Level)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7504u), 255, true);
			return false;
		}
		int equipPos = this.DM.mLordEquip.GetEquipPos(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ItemID);
		if (equipPos < 0)
		{
			return false;
		}
		if (equipPos < 5)
		{
			this.DM.mLordEquip.ChangeEquip((byte)equipPos, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO);
			return true;
		}
		if (LordEquipData.RoleEquipSerial[5] == 0u)
		{
			this.DM.mLordEquip.ChangeEquip((byte)equipPos, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO);
			return true;
		}
		RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(15, 0);
		if (buildData.Level >= 17 && LordEquipData.RoleEquipSerial[6] == 0u)
		{
			this.DM.mLordEquip.ChangeEquip(6, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO);
			return true;
		}
		if (buildData.Level >= 25 && LordEquipData.RoleEquipSerial[7] == 0u)
		{
			this.DM.mLordEquip.ChangeEquip(7, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO);
			return true;
		}
		this.DM.mLordEquip.ChangeEquip((byte)equipPos, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].SerialNO);
		return true;
	}

	// Token: 0x06001DE4 RID: 7652 RVA: 0x00386190 File Offset: 0x00384390
	private float GetTextHeight(float wide, CString str, int fontsize = 16)
	{
		this.BestHeight.gameObject.SetActive(true);
		this.BestHeight.fontSize = fontsize;
		this.BestHeight.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, wide);
		this.BestHeight.text = str.ToString();
		this.BestHeight.cachedTextGeneratorForLayout.Invalidate();
		this.BestHeight.gameObject.SetActive(false);
		float num = Math.Max(30f, this.BestHeight.preferredHeight);
		if (num > 30f)
		{
			num += 2f;
		}
		return num;
	}

	// Token: 0x06001DE5 RID: 7653 RVA: 0x00386228 File Offset: 0x00384428
	public bool newGemTechReady(byte equipPos)
	{
		ushort techID;
		switch (equipPos)
		{
		case 21:
			techID = 198;
			break;
		case 22:
			techID = 199;
			break;
		case 23:
			techID = 200;
			break;
		case 24:
			techID = 197;
			break;
		case 25:
			techID = 201;
			break;
		case 26:
			techID = 202;
			break;
		default:
			return false;
		}
		byte techLevel = DataManager.Instance.GetTechLevel(techID);
		return techLevel > 0;
	}

	// Token: 0x06001DE6 RID: 7654 RVA: 0x003862B4 File Offset: 0x003844B4
	public void InlayNewGem()
	{
		switch (DataManager.Instance.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ItemID).EquipKind)
		{
		case 21:
			this.OpenTechTree = 198;
			break;
		case 22:
			this.OpenTechTree = 199;
			break;
		case 23:
			this.OpenTechTree = 200;
			break;
		case 24:
			this.OpenTechTree = 197;
			break;
		case 25:
			this.OpenTechTree = 201;
			break;
		case 26:
			this.OpenTechTree = 202;
			break;
		default:
			GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(7523u), this.DM.mStringTable.GetStringByID(7520u), null, null, 0, 0, false, false, false, false, false);
			return;
		}
		byte techLevel = DataManager.Instance.GetTechLevel(this.OpenTechTree);
		if (techLevel > 0)
		{
			if (this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].Gem[3] == 0)
			{
				UILordEquip.EquipFocusSub = 3;
				this.isCollectChange = true;
				this.SetOpenStat(UILordEquip.eUIOpenStat.newGemSelect, UILordEquip.eCollectType.None);
			}
			else
			{
				GUIManager.Instance.OpenGemRemoveUI(UILordEquip.EquipFocus, 3);
				UILordEquip.waitForReturn = eUI_LordEquipReturnKind.ItemInfo;
			}
		}
		else
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			TechDataTbl recordByKey = DataManager.Instance.TechData.GetRecordByKey(this.OpenTechTree);
			cstring.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.TechName));
			cstring.AppendFormat(this.DM.mStringTable.GetStringByID(16129u));
			GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(16128u), cstring.ToString(), this.DM.mStringTable.GetStringByID(156u), this, 2, 0, true, false, false, false, false);
		}
	}

	// Token: 0x06001DE7 RID: 7655 RVA: 0x003864D4 File Offset: 0x003846D4
	public void Update()
	{
		UILordEquip.eUIOpenStat openStat = this.OpenStat;
		if (openStat != UILordEquip.eUIOpenStat.None && openStat != UILordEquip.eUIOpenStat.PostSetStat)
		{
			this.GetPointTime += Time.smoothDeltaTime / 2f;
			if (this.GetPointTime >= 1.7f)
			{
				this.GetPointTime = 0.3f;
			}
			float a = (this.GetPointTime <= 1f) ? this.GetPointTime : (2f - this.GetPointTime);
			Color color = new Color(1f, 1f, 1f, a);
			this.Light1.color = color;
			this.Light2.color = color;
			this.Light3.color = color;
			this.Light4.color = color;
			this.SelectLight.color = color;
			this.MaterialLight.color = color;
			this.POPLight1.color = color;
			this.POPLight3.color = color;
			this.arrowTime += Time.smoothDeltaTime * 40f;
			if (this.arrowTime >= 40f)
			{
				this.arrowTime = 0f;
			}
			float num = (this.arrowTime <= 20f) ? this.arrowTime : (40f - this.arrowTime);
			if (num < 0f)
			{
				num = 0f;
			}
			this.arrowPos.anchoredPosition = new Vector2(10f - num, this.arrowPos.anchoredPosition.y);
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
					float a2 = (0.3f - this.MoveTime) / 0.3f;
					this.LightBox1.color = new Color(1f, 1f, 1f, a2);
					this.LightBox2.color = new Color(1f, 1f, 1f, a2);
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
			if (this.AGS_Forging.gameObject.activeInHierarchy)
			{
				this.AnimeTime += Time.smoothDeltaTime;
				if (this.AnimeTime < 0.3f)
				{
					this.AGS_Forging.SetSpriteIndex(0);
				}
				else if (this.AnimeTime < 0.4f)
				{
					this.AGS_Forging.SetSpriteIndex(1);
				}
				else if (this.AnimeTime < 0.8f)
				{
					this.AGS_Forging.SetSpriteIndex(2);
				}
				else
				{
					this.AnimeTime = 0f;
				}
			}
			return;
		}
		this.AfterLoader();
	}

	// Token: 0x06001DE8 RID: 7656 RVA: 0x00386874 File Offset: 0x00384A74
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond && this.selectedTimed)
		{
			this.TimedItemCountText.ClearString();
			GameConstants.GetTimeString(this.TimedItemCountText, (uint)Math.Max(0L, this.DM.mLordEquip.LordEquip[(int)UILordEquip.EquipFocus].ExpireTime - this.DM.ServerTime), false, false, true, false, true);
			UIText component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).GetComponent<UIText>();
			component.text = this.TimedItemCountText.ToString();
			component.cachedTextGenerator.Invalidate();
			component.SetAllDirty();
		}
	}

	// Token: 0x04005C61 RID: 23649
	private const int fontSizeEff = 18;

	// Token: 0x04005C62 RID: 23650
	private const int fontSizeNewEff = 18;

	// Token: 0x04005C63 RID: 23651
	private const int fontSizeDesc = 16;

	// Token: 0x04005C64 RID: 23652
	private Door door;

	// Token: 0x04005C65 RID: 23653
	private DataManager DM;

	// Token: 0x04005C66 RID: 23654
	private eUI_LordEquipOpenKind OpenKind;

	// Token: 0x04005C67 RID: 23655
	private UILordEquip.eUIOpenStat OpenStat;

	// Token: 0x04005C68 RID: 23656
	private UILordEquip.eUIOpenStat PopupKind;

	// Token: 0x04005C69 RID: 23657
	private byte PopUpColor;

	// Token: 0x04005C6A RID: 23658
	private UILordEquip.eItemFilterByKind FilterKind;

	// Token: 0x04005C6B RID: 23659
	private UILordEquip.eCollectType CollectType;

	// Token: 0x04005C6C RID: 23660
	private bool isCollectChange;

	// Token: 0x04005C6D RID: 23661
	private byte EquipSolt;

	// Token: 0x04005C6E RID: 23662
	private CString TitleText;

	// Token: 0x04005C6F RID: 23663
	private CString NoContentText;

	// Token: 0x04005C70 RID: 23664
	private CString ItemNameText;

	// Token: 0x04005C71 RID: 23665
	private CString ItemLevelText;

	// Token: 0x04005C72 RID: 23666
	private CString PopUpHeaderText;

	// Token: 0x04005C73 RID: 23667
	private CString TimedItemCountText;

	// Token: 0x04005C74 RID: 23668
	private CString[] GemBtnText = new CString[4];

	// Token: 0x04005C75 RID: 23669
	private CString[] EffDescText = new CString[11];

	// Token: 0x04005C76 RID: 23670
	private CString[] PopupEffectText = new CString[11];

	// Token: 0x04005C77 RID: 23671
	private CString[] PopupAmountText = new CString[5];

	// Token: 0x04005C78 RID: 23672
	private List<LordEquipEffectSet> effectList;

	// Token: 0x04005C79 RID: 23673
	private List<LordEquipEffectCompareSet> effectCompareList;

	// Token: 0x04005C7A RID: 23674
	private bool OnStartSelect = true;

	// Token: 0x04005C7B RID: 23675
	private bool ShowUnlockPanel;

	// Token: 0x04005C7C RID: 23676
	private bool isCombine = true;

	// Token: 0x04005C7D RID: 23677
	private List<float> SPHeight;

	// Token: 0x04005C7E RID: 23678
	private List<float> SideSPHeight;

	// Token: 0x04005C7F RID: 23679
	private List<float> PopSPHeight;

	// Token: 0x04005C80 RID: 23680
	private List<ushort> FilterItem;

	// Token: 0x04005C81 RID: 23681
	private RectTransform Select;

	// Token: 0x04005C82 RID: 23682
	private RectTransform Forging;

	// Token: 0x04005C83 RID: 23683
	private UIText BestHeight;

	// Token: 0x04005C84 RID: 23684
	private bool isFocused;

	// Token: 0x04005C85 RID: 23685
	private static ushort EquipFocus;

	// Token: 0x04005C86 RID: 23686
	private static ushort EquipFocusSub;

	// Token: 0x04005C87 RID: 23687
	private ushort MaterialFocus;

	// Token: 0x04005C88 RID: 23688
	public static ushort itemIDFilter;

	// Token: 0x04005C89 RID: 23689
	public static ushort itemColorFilter;

	// Token: 0x04005C8A RID: 23690
	private bool lockEmptyForge;

	// Token: 0x04005C8B RID: 23691
	private int lockedIdx;

	// Token: 0x04005C8C RID: 23692
	private static int EquipTopIdx;

	// Token: 0x04005C8D RID: 23693
	private static int GemTopIdx;

	// Token: 0x04005C8E RID: 23694
	private static int MatTopIdx;

	// Token: 0x04005C8F RID: 23695
	private static int NewGemTopIdx;

	// Token: 0x04005C90 RID: 23696
	private static float EquipTopPos;

	// Token: 0x04005C91 RID: 23697
	private static float GemTopPos;

	// Token: 0x04005C92 RID: 23698
	private static float MatTopPos;

	// Token: 0x04005C93 RID: 23699
	private static float NewGemTopPos;

	// Token: 0x04005C94 RID: 23700
	private ushort OpenTechTree;

	// Token: 0x04005C95 RID: 23701
	private ushort combineItemID;

	// Token: 0x04005C96 RID: 23702
	private byte combineColor;

	// Token: 0x04005C97 RID: 23703
	private ushort[] MaterCount = new ushort[5];

	// Token: 0x04005C98 RID: 23704
	public static eUI_LordEquipReturnKind waitForReturn;

	// Token: 0x04005C99 RID: 23705
	private static int EquipFilter;

	// Token: 0x04005C9A RID: 23706
	private bool MaterialFlash;

	// Token: 0x04005C9B RID: 23707
	private Image Light1;

	// Token: 0x04005C9C RID: 23708
	private Image Light2;

	// Token: 0x04005C9D RID: 23709
	private Image Light3;

	// Token: 0x04005C9E RID: 23710
	private Image Light4;

	// Token: 0x04005C9F RID: 23711
	private Image SelectLight;

	// Token: 0x04005CA0 RID: 23712
	private Image Flash;

	// Token: 0x04005CA1 RID: 23713
	private Image LightBox1;

	// Token: 0x04005CA2 RID: 23714
	private Image LightBox2;

	// Token: 0x04005CA3 RID: 23715
	private Image MaterialLight;

	// Token: 0x04005CA4 RID: 23716
	private RectTransform arrowPos;

	// Token: 0x04005CA5 RID: 23717
	private Image POPLight1;

	// Token: 0x04005CA6 RID: 23718
	private Image POPLight3;

	// Token: 0x04005CA7 RID: 23719
	private bool selectedTimed;

	// Token: 0x04005CA8 RID: 23720
	private Transform AGS_Form;

	// Token: 0x04005CA9 RID: 23721
	private UIText[] AllTextObject = new UIText[60];

	// Token: 0x04005CAA RID: 23722
	private ScrollPanel AGS_ScrollArea;

	// Token: 0x04005CAB RID: 23723
	private RectTransform ScrollArea_RT;

	// Token: 0x04005CAC RID: 23724
	private UISpritesArray AGS_RareImg;

	// Token: 0x04005CAD RID: 23725
	private ScrollPanel AGS_ScrollPanel;

	// Token: 0x04005CAE RID: 23726
	private UISpritesArray AGS_ItemRare;

	// Token: 0x04005CAF RID: 23727
	private ScrollPanel AGS_ScrollPanel2;

	// Token: 0x04005CB0 RID: 23728
	private UISpritesArray AGS_Forging;

	// Token: 0x04005CB1 RID: 23729
	private ScrollPanel POPScrollPanel;

	// Token: 0x04005CB2 RID: 23730
	private ScrollPanel NewGemPanel;

	// Token: 0x04005CB3 RID: 23731
	private float MoveTime;

	// Token: 0x04005CB4 RID: 23732
	private float GetPointTime;

	// Token: 0x04005CB5 RID: 23733
	private float AnimeTime;

	// Token: 0x04005CB6 RID: 23734
	private float arrowTime;

	// Token: 0x020005DB RID: 1499
	private enum eUIOpenStat
	{
		// Token: 0x04005CB8 RID: 23736
		None,
		// Token: 0x04005CB9 RID: 23737
		Normal,
		// Token: 0x04005CBA RID: 23738
		ItemInfo,
		// Token: 0x04005CBB RID: 23739
		GemSelect,
		// Token: 0x04005CBC RID: 23740
		GemInfo,
		// Token: 0x04005CBD RID: 23741
		GemCombine,
		// Token: 0x04005CBE RID: 23742
		MaterialCombine,
		// Token: 0x04005CBF RID: 23743
		PostSetStat,
		// Token: 0x04005CC0 RID: 23744
		newGemSelect
	}

	// Token: 0x020005DC RID: 1500
	private enum eItemFilterByKind
	{
		// Token: 0x04005CC2 RID: 23746
		AllEquip,
		// Token: 0x04005CC3 RID: 23747
		Head,
		// Token: 0x04005CC4 RID: 23748
		Body,
		// Token: 0x04005CC5 RID: 23749
		Lag,
		// Token: 0x04005CC6 RID: 23750
		Weapon,
		// Token: 0x04005CC7 RID: 23751
		OffHand,
		// Token: 0x04005CC8 RID: 23752
		Accessories,
		// Token: 0x04005CC9 RID: 23753
		Gem,
		// Token: 0x04005CCA RID: 23754
		Material,
		// Token: 0x04005CCB RID: 23755
		GemFilter,
		// Token: 0x04005CCC RID: 23756
		IDFilter,
		// Token: 0x04005CCD RID: 23757
		NewGem
	}

	// Token: 0x020005DD RID: 1501
	private enum eCollectType
	{
		// Token: 0x04005CCF RID: 23759
		None,
		// Token: 0x04005CD0 RID: 23760
		Equip,
		// Token: 0x04005CD1 RID: 23761
		Gem,
		// Token: 0x04005CD2 RID: 23762
		Material,
		// Token: 0x04005CD3 RID: 23763
		newGem
	}

	// Token: 0x020005DE RID: 1502
	private enum e_AGS_UI_LordEquip_Editor
	{
		// Token: 0x04005CD5 RID: 23765
		BGFrame,
		// Token: 0x04005CD6 RID: 23766
		BGFrameTitle,
		// Token: 0x04005CD7 RID: 23767
		exitImage,
		// Token: 0x04005CD8 RID: 23768
		Infobtn,
		// Token: 0x04005CD9 RID: 23769
		ScrollBg,
		// Token: 0x04005CDA RID: 23770
		ScrollArea,
		// Token: 0x04005CDB RID: 23771
		ScrollItem,
		// Token: 0x04005CDC RID: 23772
		Select,
		// Token: 0x04005CDD RID: 23773
		SideBg,
		// Token: 0x04005CDE RID: 23774
		GemDetail,
		// Token: 0x04005CDF RID: 23775
		Cover,
		// Token: 0x04005CE0 RID: 23776
		Forging,
		// Token: 0x04005CE1 RID: 23777
		GetBestHeightText
	}

	// Token: 0x020005DF RID: 1503
	private enum e_AGS_ScrollItem
	{
		// Token: 0x04005CE3 RID: 23779
		BlockHold,
		// Token: 0x04005CE4 RID: 23780
		lockedHolder
	}

	// Token: 0x020005E0 RID: 1504
	private enum e_AGS_lockedHolder
	{
		// Token: 0x04005CE6 RID: 23782
		LockBtn,
		// Token: 0x04005CE7 RID: 23783
		Lock,
		// Token: 0x04005CE8 RID: 23784
		LockText
	}

	// Token: 0x020005E1 RID: 1505
	private enum e_AGS_SideBg
	{
		// Token: 0x04005CEA RID: 23786
		Collection,
		// Token: 0x04005CEB RID: 23787
		Exchange,
		// Token: 0x04005CEC RID: 23788
		GemMosaic,
		// Token: 0x04005CED RID: 23789
		VDivider
	}

	// Token: 0x020005E2 RID: 1506
	private enum e_AGS_Collection
	{
		// Token: 0x04005CEF RID: 23791
		EquipmentBtn,
		// Token: 0x04005CF0 RID: 23792
		GemBtn,
		// Token: 0x04005CF1 RID: 23793
		NewGemBtn,
		// Token: 0x04005CF2 RID: 23794
		MaterialBtn,
		// Token: 0x04005CF3 RID: 23795
		FilterBg,
		// Token: 0x04005CF4 RID: 23796
		FilterText,
		// Token: 0x04005CF5 RID: 23797
		FilterBtn,
		// Token: 0x04005CF6 RID: 23798
		Acquire
	}

	// Token: 0x020005E3 RID: 1507
	private enum e_AGS_Acquire
	{
		// Token: 0x04005CF8 RID: 23800
		AcquireImage
	}

	// Token: 0x020005E4 RID: 1508
	private enum e_AGS_Exchange
	{
		// Token: 0x04005CFA RID: 23802
		NameBg,
		// Token: 0x04005CFB RID: 23803
		NameText,
		// Token: 0x04005CFC RID: 23804
		RareImg,
		// Token: 0x04005CFD RID: 23805
		LevelText,
		// Token: 0x04005CFE RID: 23806
		ClockImg,
		// Token: 0x04005CFF RID: 23807
		ClockText,
		// Token: 0x04005D00 RID: 23808
		ScrollPanelBg,
		// Token: 0x04005D01 RID: 23809
		ScrollPanel,
		// Token: 0x04005D02 RID: 23810
		ScrollItem,
		// Token: 0x04005D03 RID: 23811
		InspectBtn,
		// Token: 0x04005D04 RID: 23812
		EquipBtn,
		// Token: 0x04005D05 RID: 23813
		EvoBtn,
		// Token: 0x04005D06 RID: 23814
		NewGemInlayBtn
	}

	// Token: 0x020005E5 RID: 1509
	private enum e_AGS_ScrollItem2
	{
		// Token: 0x04005D08 RID: 23816
		Text,
		// Token: 0x04005D09 RID: 23817
		Text2,
		// Token: 0x04005D0A RID: 23818
		Text3
	}

	// Token: 0x020005E6 RID: 1510
	private enum e_AGS_InspectBtn
	{
		// Token: 0x04005D0C RID: 23820
		Image,
		// Token: 0x04005D0D RID: 23821
		Text,
		// Token: 0x04005D0E RID: 23822
		Mark
	}

	// Token: 0x020005E7 RID: 1511
	private enum e_AGS_EquipBtn
	{
		// Token: 0x04005D10 RID: 23824
		Image,
		// Token: 0x04005D11 RID: 23825
		Text
	}

	// Token: 0x020005E8 RID: 1512
	private enum e_AGS_GemMosaic
	{
		// Token: 0x04005D13 RID: 23827
		ItemBg,
		// Token: 0x04005D14 RID: 23828
		ItemName,
		// Token: 0x04005D15 RID: 23829
		OldGemEffect,
		// Token: 0x04005D16 RID: 23830
		NewGemEffect,
		// Token: 0x04005D17 RID: 23831
		EquipBtn
	}

	// Token: 0x020005E9 RID: 1513
	private enum e_AGS_OldGemEffect
	{
		// Token: 0x04005D19 RID: 23833
		EffText1,
		// Token: 0x04005D1A RID: 23834
		EffText2,
		// Token: 0x04005D1B RID: 23835
		EffText3,
		// Token: 0x04005D1C RID: 23836
		EffText4,
		// Token: 0x04005D1D RID: 23837
		EffText5,
		// Token: 0x04005D1E RID: 23838
		EffText6,
		// Token: 0x04005D1F RID: 23839
		FilterBg,
		// Token: 0x04005D20 RID: 23840
		FilterText,
		// Token: 0x04005D21 RID: 23841
		FilterBtn
	}

	// Token: 0x020005EA RID: 1514
	private enum e_AGS_FilterBtn
	{
		// Token: 0x04005D23 RID: 23843
		FilterBtnText,
		// Token: 0x04005D24 RID: 23844
		FilterBtn2,
		// Token: 0x04005D25 RID: 23845
		FilterExtText
	}

	// Token: 0x020005EB RID: 1515
	private enum e_AGS_GemDetail
	{
		// Token: 0x04005D27 RID: 23847
		UpperBg,
		// Token: 0x04005D28 RID: 23848
		UILEBtn,
		// Token: 0x04005D29 RID: 23849
		SourceBtn,
		// Token: 0x04005D2A RID: 23850
		ItemBg,
		// Token: 0x04005D2B RID: 23851
		ItemName,
		// Token: 0x04005D2C RID: 23852
		ItemRare,
		// Token: 0x04005D2D RID: 23853
		LevelText,
		// Token: 0x04005D2E RID: 23854
		Gems,
		// Token: 0x04005D2F RID: 23855
		EvoBtn,
		// Token: 0x04005D30 RID: 23856
		RecycleBtn,
		// Token: 0x04005D31 RID: 23857
		ScrollPanel2,
		// Token: 0x04005D32 RID: 23858
		ScrollPanelItem,
		// Token: 0x04005D33 RID: 23859
		FullLevel,
		// Token: 0x04005D34 RID: 23860
		Image
	}

	// Token: 0x020005EC RID: 1516
	private enum e_AGS_GemHolder
	{
		// Token: 0x04005D36 RID: 23862
		Gem1,
		// Token: 0x04005D37 RID: 23863
		lockImg,
		// Token: 0x04005D38 RID: 23864
		UIButton,
		// Token: 0x04005D39 RID: 23865
		BtnText
	}

	// Token: 0x020005ED RID: 1517
	private enum e_AGS_EvoBtn
	{
		// Token: 0x04005D3B RID: 23867
		Image,
		// Token: 0x04005D3C RID: 23868
		Text,
		// Token: 0x04005D3D RID: 23869
		Mark
	}

	// Token: 0x020005EE RID: 1518
	private enum e_AGS_RecycleBtn
	{
		// Token: 0x04005D3F RID: 23871
		Text,
		// Token: 0x04005D40 RID: 23872
		Image
	}

	// Token: 0x020005EF RID: 1519
	private enum e_AGS_OrgEffect
	{
		// Token: 0x04005D42 RID: 23874
		Image,
		// Token: 0x04005D43 RID: 23875
		EffName,
		// Token: 0x04005D44 RID: 23876
		EffText
	}

	// Token: 0x020005F0 RID: 1520
	private enum e_AGS_FullLevel
	{
		// Token: 0x04005D46 RID: 23878
		Light,
		// Token: 0x04005D47 RID: 23879
		Star,
		// Token: 0x04005D48 RID: 23880
		Text
	}

	// Token: 0x020005F1 RID: 1521
	private enum e_AGS_PopUp
	{
		// Token: 0x04005D4A RID: 23882
		PopBg,
		// Token: 0x04005D4B RID: 23883
		CloseBtn,
		// Token: 0x04005D4C RID: 23884
		UILEBtn,
		// Token: 0x04005D4D RID: 23885
		TitleBg,
		// Token: 0x04005D4E RID: 23886
		ItemName,
		// Token: 0x04005D4F RID: 23887
		ItemRare,
		// Token: 0x04005D50 RID: 23888
		EffBg,
		// Token: 0x04005D51 RID: 23889
		ScrollPanel,
		// Token: 0x04005D52 RID: 23890
		ScrollItem,
		// Token: 0x04005D53 RID: 23891
		Upgrade,
		// Token: 0x04005D54 RID: 23892
		CombineAll,
		// Token: 0x04005D55 RID: 23893
		CombineBtn,
		// Token: 0x04005D56 RID: 23894
		TextArea,
		// Token: 0x04005D57 RID: 23895
		Image,
		// Token: 0x04005D58 RID: 23896
		MaterialPanel
	}

	// Token: 0x020005F2 RID: 1522
	private enum e_AGS_Upgrade
	{
		// Token: 0x04005D5A RID: 23898
		Desc,
		// Token: 0x04005D5B RID: 23899
		DescText,
		// Token: 0x04005D5C RID: 23900
		Mat1,
		// Token: 0x04005D5D RID: 23901
		Mat2,
		// Token: 0x04005D5E RID: 23902
		Mat3,
		// Token: 0x04005D5F RID: 23903
		Mat4,
		// Token: 0x04005D60 RID: 23904
		Mat5,
		// Token: 0x04005D61 RID: 23905
		Select
	}

	// Token: 0x020005F3 RID: 1523
	private enum e_AGS_MaterialPanel
	{
		// Token: 0x04005D63 RID: 23907
		combinebg,
		// Token: 0x04005D64 RID: 23908
		combine,
		// Token: 0x04005D65 RID: 23909
		Image1bg,
		// Token: 0x04005D66 RID: 23910
		Image1,
		// Token: 0x04005D67 RID: 23911
		breakDownbg,
		// Token: 0x04005D68 RID: 23912
		breakDown,
		// Token: 0x04005D69 RID: 23913
		Image2bg,
		// Token: 0x04005D6A RID: 23914
		Image2,
		// Token: 0x04005D6B RID: 23915
		Mark
	}
}
