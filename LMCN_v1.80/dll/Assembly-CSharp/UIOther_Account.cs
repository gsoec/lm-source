using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000442 RID: 1090
public class UIOther_Account : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x060015D6 RID: 5590 RVA: 0x0025241C File Offset: 0x0025061C
	public override void OnOpen(int arg1, int arg2)
	{
		this.GM = GUIManager.Instance;
		this.DM = DataManager.Instance;
		this.TTF = this.GM.GetTTFFont();
		this.SDK = IGGGameSDK.Instance;
		this.m_Door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.SetFakeDate();
		HelperUIButton helperUIButton = base.gameObject.AddComponent<HelperUIButton>();
		helperUIButton.m_Handler = this;
		helperUIButton.m_BtnID1 = 5;
		for (int i = 0; i < base.transform.childCount; i++)
		{
			UnityEngine.Object.Destroy(base.transform.GetChild(i).GetChild(0).GetComponent<IgnoreRaycast>());
		}
		this.m_Str = new CString[this.MaxStr];
		for (int j = 0; j < this.MaxStr; j++)
		{
			this.m_Str[j] = StringManager.Instance.SpawnString(30);
		}
		this.m_Data = new List<sAccount>();
		this.m_ItemObject = new AccItemObject[5];
		for (int k = 0; k < 5; k++)
		{
			this.m_ItemObject[k].Str = StringManager.Instance.SpawnString(30);
		}
		this.GM.AddSpriteAsset(this.AssName);
		this.mat = this.GM.LoadMaterial(this.AssName, "UI_other_m");
		Image component = base.transform.GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_con_black_02");
		component.material = this.mat;
		if (this.GM.bOpenOnIPhoneX)
		{
			((RectTransform)base.transform).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0f);
			((RectTransform)base.transform).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0f);
		}
		Transform child = base.transform.GetChild(0);
		this.m_SettingPanel = child;
		component = child.GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
		component.material = this.mat;
		this.m_SettingPanel = child;
		component = child.GetChild(0).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
		component.material = this.mat;
		component.type = Image.Type.Sliced;
		this.m_GIcon = child.GetChild(1).GetComponent<Image>();
		this.SetLoginIcon();
		this.m_RotImage[0] = this.m_GIcon;
		this.m_SettingAccImage = child.GetChild(2).GetComponent<Image>();
		this.m_SettingAccImage.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_10");
		this.m_SettingAccImage.material = this.mat;
		this.m_SettingTitleText = child.GetChild(3).GetComponent<UIText>();
		this.m_SettingTitleText.font = this.TTF;
		this.m_SettingIGGIDText = child.GetChild(4).GetComponent<UIText>();
		this.m_SettingIGGIDText.font = this.TTF;
		this.m_SettingAccText = child.GetChild(5).GetComponent<UIText>();
		this.m_SettingAccText.font = this.TTF;
		this.m_BindAccountText = child.GetChild(6).GetComponent<UIText>();
		this.m_BindAccountText.font = this.TTF;
		this.m_BindAccountText.text = this.DM.mStringTable.GetStringByID(7080u);
		this.m_BindGiftTf = child.GetChild(7);
		component = this.m_BindGiftTf.GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_14");
		component.material = this.mat;
		component = this.m_BindGiftTf.GetChild(1).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_09");
		component.material = this.mat;
		UIText component2 = this.m_BindGiftTf.GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = this.DM.mStringTable.GetStringByID(9541u);
		this.SetCenterText(component, component2, 600f);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_BindBtn = child.GetChild(8).GetComponent<UIButton>();
		this.m_BindBtn.m_Handler = this;
		this.m_BindBtn.m_BtnID1 = 0;
		this.m_BindBtn.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_02");
		this.m_BindBtn.image.material = this.mat;
		component2 = child.GetChild(8).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = this.DM.mStringTable.GetStringByID(7074u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_LogoutBtn = child.GetChild(9).GetComponent<UIButton>();
		this.m_LogoutBtn.m_Handler = this;
		this.m_LogoutBtn.m_BtnID1 = 1;
		this.m_LogoutBtn.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		this.m_LogoutBtn.image.material = this.mat;
		component2 = child.GetChild(9).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = this.DM.mStringTable.GetStringByID(9015u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_SwitchBtn = child.GetChild(10).GetComponent<UIButton>();
		this.m_SwitchBtn.m_Handler = this;
		this.m_SwitchBtn.m_BtnID1 = 2;
		this.m_SwitchBtn.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		this.m_SwitchBtn.image.material = this.mat;
		component2 = child.GetChild(10).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = this.DM.mStringTable.GetStringByID(7075u);
		component = child.GetChild(10).GetChild(1).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_19");
		component.rectTransform.sizeDelta = new Vector2(47f, 48f);
		component.rectTransform.anchoredPosition = new Vector2(15f, -1f);
		component.gameObject.SetActive(false);
		component2.rectTransform.anchoredPosition = new Vector2(35.5f, 0f);
		component.material = this.mat;
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_SwitchPlatform = child.GetChild(11).GetComponent<UIButton>();
		this.m_SwitchPlatform.m_Handler = this;
		this.m_SwitchPlatform.m_BtnID1 = 3;
		this.m_SwitchPlatform.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		this.m_SwitchPlatform.image.material = this.mat;
		this.m_SwitchPlatform.image.type = Image.Type.Sliced;
		component2 = child.GetChild(11).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = this.DM.mStringTable.GetStringByID(9001u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_RealName = child.GetChild(13).GetComponent<UIButton>();
		this.m_RealName.m_Handler = this;
		this.m_RealName.m_BtnID1 = 4;
		this.m_RealName.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		this.m_RealName.image.material = this.mat;
		this.m_RealName.image.type = Image.Type.Sliced;
		component2 = child.GetChild(13).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = this.DM.mStringTable.GetStringByID(9677u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_SwitchPlatform.gameObject.SetActive(true);
		UIButton component3 = child.GetChild(12).GetComponent<UIButton>();
		component3.image.sprite = this.m_Door.LoadSprite("UI_main_close");
		component3.image.material = this.m_Door.LoadMaterial();
		component3.image.SetNativeSize();
		component3.m_Handler = this;
		component3.m_BtnID1 = 5;
		child = base.transform.GetChild(1);
		this.m_SwitchPanel = child;
		component = child.GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
		component.material = this.mat;
		component = child.GetChild(0).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
		component.material = this.mat;
		component.type = Image.Type.Sliced;
		this.m_SwitchTitleText = child.GetChild(1).GetComponent<UIText>();
		this.m_SwitchTitleText.font = this.TTF;
		this.m_SwitchTitleText.text = this.DM.mStringTable.GetStringByID(7076u);
		component = child.GetChild(2).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_alpha");
		component.material = this.mat;
		this.m_ScrollPanel = child.GetChild(2).GetComponent<ScrollPanel>();
		this.m_YesBtn = child.GetChild(3).GetComponent<UIButton>();
		this.m_YesBtn.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		this.m_YesBtn.image.material = this.mat;
		component2 = child.GetChild(3).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = this.DM.mStringTable.GetStringByID(7077u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_YesBtn.m_Handler = this;
		this.m_YesBtn.m_BtnID1 = 7;
		this.m_NoBtn = child.GetChild(4).GetComponent<UIButton>();
		this.m_NoBtn.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_02");
		this.m_NoBtn.image.material = this.mat;
		this.m_NoBtn.m_Handler = this;
		this.m_NoBtn.m_BtnID1 = 8;
		component2 = child.GetChild(4).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = this.DM.mStringTable.GetStringByID(7078u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component3 = child.GetChild(5).GetComponent<UIButton>();
		component3.image.sprite = this.m_Door.LoadSprite("UI_main_close");
		component3.image.material = this.m_Door.LoadMaterial();
		component3.image.SetNativeSize();
		component3.m_Handler = this;
		component3.m_BtnID1 = 6;
		child.GetChild(6).GetComponent<Image>().material = this.mat;
		component = child.GetChild(6).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_12_a");
		component.material = this.mat;
		component = child.GetChild(6).GetChild(1).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_12_b");
		component.material = this.mat;
		component = child.GetChild(6).GetChild(2).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_03");
		component.material = this.mat;
		component = child.GetChild(6).GetChild(2).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_select");
		component.material = this.mat;
		component2 = child.GetChild(6).GetChild(3).GetComponent<UIText>();
		component2.font = this.TTF;
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_SwitchEmpty = child.GetChild(7).GetComponent<Image>();
		this.m_SwitchEmpty.sprite = this.GM.LoadSprite(this.AssName, "UI_market_bar_01");
		this.m_SwitchEmpty.material = this.mat;
		component2 = child.GetChild(7).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = this.DM.mStringTable.GetStringByID(7087u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		child = base.transform.GetChild(2);
		this.m_CrossPlatformPanel = child;
		component = child.GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
		component.material = this.mat;
		component = child.GetChild(0).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
		component.material = this.mat;
		component.type = Image.Type.Sliced;
		component2 = child.GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9001u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component3 = child.GetChild(2).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 9;
		component3.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		component3.image.material = this.mat;
		component3 = child.GetChild(3).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 10;
		component3.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		component3.image.material = this.mat;
		component3 = child.GetChild(4).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 11;
		component3.image.sprite = this.m_Door.LoadSprite("UI_main_close");
		component3.image.material = this.m_Door.LoadMaterial();
		component3.image.SetNativeSize();
		component = child.GetChild(2).GetChild(2).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
		if (GUIManager.Instance.IsArabic)
		{
			component.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		component.material = this.mat;
		component.SetNativeSize();
		this.CrossPlatformSetup.BindImg = component;
		this.m_RotImage[2] = component;
		component2 = child.GetChild(2).GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9002u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = child.GetChild(2).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(7074u);
		this.SetCenterText(component, component2, 576f);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component = child.GetChild(3).GetChild(2).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
		if (GUIManager.Instance.IsArabic)
		{
			component.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		component.material = this.mat;
		component.SetNativeSize();
		this.CrossPlatformSetup.LoginImg = component;
		this.m_RotImage[3] = component;
		component2 = child.GetChild(3).GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9003u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = child.GetChild(3).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(8428u);
		this.SetCenterText(component, component2, 576f);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		child = base.transform.GetChild(3);
		this.m_PlatformBindPanel = child;
		component = child.GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
		component.material = this.mat;
		component.type = Image.Type.Sliced;
		component = child.GetChild(0).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
		component.material = this.mat;
		component.type = Image.Type.Sliced;
		component2 = child.GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9004u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.CrossPlatformSetup.BindTitle = component2;
		component2 = child.GetChild(2).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(7067u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.m_Str[3].ClearString();
		this.m_Str[3].StringToFormat(this.SDK.m_IGGID);
		this.m_Str[3].AppendFormat(this.DM.mStringTable.GetStringByID(7067u));
		component2.text = this.m_Str[3].ToString();
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = child.GetChild(3).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9005u);
		this.CrossPlatformSetup.Tip = component2;
		component2.resizeTextForBestFit = true;
		component2.resizeTextMaxSize = 24;
		component2.resizeTextMinSize = 10;
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component3 = child.GetChild(4).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 12;
		component3.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		component3.image.material = this.mat;
		component = child.GetChild(4).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
		if (GUIManager.Instance.IsArabic)
		{
			ArabicItemTextureRot component4 = component.gameObject.GetComponent<ArabicItemTextureRot>();
			if (component4 == null)
			{
				component.gameObject.AddComponent<ArabicItemTextureRot>();
			}
		}
		component.material = this.mat;
		component.SetNativeSize();
		this.CrossPlatformSetup.BindPanelImg = component;
		this.m_RotImage[4] = component;
		component2 = child.GetChild(4).GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(7074u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component3 = child.GetChild(5).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 13;
		component3.image.sprite = this.m_Door.LoadSprite("UI_main_close");
		component3.image.material = this.m_Door.LoadMaterial();
		component3.image.SetNativeSize();
		this.SetCenterText(component, component2, 576f);
		child = base.transform.GetChild(4);
		this.m_PlatformLoginPanel = child;
		component = child.GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
		component.material = this.mat;
		component.type = Image.Type.Sliced;
		component = child.GetChild(0).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
		component.material = this.mat;
		component.type = Image.Type.Sliced;
		component2 = child.GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9009u);
		this.CrossPlatformSetup.LoginTitle = component2;
		component2 = child.GetChild(2).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9010u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.CrossPlatformSetup.Title = component2;
		component3 = child.GetChild(3).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 14;
		component3.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		component3.image.material = this.mat;
		component3 = child.GetChild(4).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 15;
		component3.image.sprite = this.m_Door.LoadSprite("UI_main_close");
		component3.image.material = this.m_Door.LoadMaterial();
		component3.image.SetNativeSize();
		component = child.GetChild(3).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
		if (GUIManager.Instance.IsArabic)
		{
			ArabicItemTextureRot component5 = component.gameObject.GetComponent<ArabicItemTextureRot>();
			if (component5 == null)
			{
				component.gameObject.AddComponent<ArabicItemTextureRot>();
			}
		}
		component.material = this.mat;
		component.SetNativeSize();
		this.CrossPlatformSetup.LoginPanelImg = component;
		this.m_RotImage[5] = component;
		component2 = child.GetChild(3).GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = this.DM.mStringTable.GetStringByID(8428u);
		this.SetCenterText(component, component2, 576f);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		child = base.transform.GetChild(5);
		this.m_SwitchGoogleAccountPanel = child;
		component = child.GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
		component.material = this.mat;
		component = child.GetChild(0).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
		component.material = this.mat;
		component.type = Image.Type.Sliced;
		component2 = child.GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(7075u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component3 = child.GetChild(2).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 16;
		component3.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		component3.image.material = this.mat;
		component3 = child.GetChild(3).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 17;
		component3.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		component3.image.material = this.mat;
		component2 = child.GetChild(2).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(7069u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component3 = child.GetChild(4).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 18;
		component3.image.sprite = this.m_Door.LoadSprite("UI_main_close");
		component3.image.material = this.m_Door.LoadMaterial();
		component3.image.SetNativeSize();
		component2 = child.GetChild(3).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(7075u);
		component2.text = DataManager.Instance.mStringTable.GetStringByID(16016u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component = child.GetChild(3).GetChild(1).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_19");
		component.SetNativeSize();
		component.material = this.mat;
		this.m_RotImage[6] = component;
		this.SetCenterText(component, component2, 576f);
		child = base.transform.GetChild(6);
		this.m_CrossPlatformList = child;
		component = child.GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
		component.material = this.mat;
		component = child.GetChild(0).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
		component.material = this.mat;
		component.type = Image.Type.Sliced;
		component2 = child.GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9001u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component3 = child.GetChild(2).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 19;
		component3.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		component3.image.material = this.mat;
		component3 = child.GetChild(3).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 20;
		component3.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		component3.image.material = this.mat;
		component2 = child.GetChild(2).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = this.DM.mStringTable.GetStringByID(8427u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component = child.GetChild(2).GetChild(1).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
		this.CrossPlatformIcons[0] = component.sprite;
		component.material = this.mat;
		component.SetNativeSize();
		this.m_RotImage[7] = component;
		component = child.GetChild(3).GetChild(1).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_19");
		this.CrossPlatformIcons[1] = component.sprite;
		component.material = this.mat;
		component.SetNativeSize();
		this.m_RotImage[8] = component;
		component2 = child.GetChild(3).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9514u);
		component3 = child.GetChild(4).GetComponent<UIButton>();
		component3.image.sprite = this.m_Door.LoadSprite("UI_main_close");
		component3.image.material = this.m_Door.LoadMaterial();
		component3.image.SetNativeSize();
		component3.m_Handler = this;
		component3.m_BtnID1 = 21;
		child = base.transform.GetChild(7);
		this.m_SwitchWechatFacebookPlatform = child;
		component = child.GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
		component.material = this.mat;
		component = child.GetChild(0).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
		component.material = this.mat;
		component.type = Image.Type.Sliced;
		component2 = child.GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(7075u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component3 = child.GetChild(2).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 26;
		component3.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		component3.image.material = this.mat;
		component3 = child.GetChild(3).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 28;
		component3.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		component3.image.material = this.mat;
		component3 = child.GetChild(4).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 25;
		component3.image.sprite = this.m_Door.LoadSprite("UI_main_close");
		component3.image.material = this.m_Door.LoadMaterial();
		component3.image.SetNativeSize();
		component = child.GetChild(2).GetChild(2).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_19");
		component.material = this.mat;
		component.SetNativeSize();
		this.m_RotImage[2] = component;
		component2 = child.GetChild(2).GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9003u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = child.GetChild(2).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(8428u);
		this.SetCenterText(component, component2, 576f);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component = child.GetChild(3).GetChild(2).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
		component.material = this.mat;
		component.SetNativeSize();
		this.m_RotImage[3] = component;
		component2 = child.GetChild(3).GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9003u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		component2 = child.GetChild(3).GetChild(0).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(8428u);
		this.SetCenterText(component, component2, 576f);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		child = base.transform.GetChild(8);
		this.m_WeChatPlatformLogin = child;
		component = child.GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
		component.material = this.mat;
		component.type = Image.Type.Sliced;
		component = child.GetChild(0).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
		component.material = this.mat;
		component.type = Image.Type.Sliced;
		component2 = child.GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9516u);
		this.CrossPlatformSetup.LoginTitle = component2;
		component2 = child.GetChild(2).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9517u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.CrossPlatformSetup.Title = component2;
		component3 = child.GetChild(3).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 14;
		component3.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		component3.image.material = this.mat;
		component3 = child.GetChild(4).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 27;
		component3.image.sprite = this.m_Door.LoadSprite("UI_main_close");
		component3.image.material = this.m_Door.LoadMaterial();
		component3.image.SetNativeSize();
		component = child.GetChild(3).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_19");
		component.material = this.mat;
		component.SetNativeSize();
		this.CrossPlatformSetup.LoginPanelImg = component;
		this.m_RotImage[5] = component;
		component2 = child.GetChild(3).GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = this.DM.mStringTable.GetStringByID(8428u);
		this.SetCenterText(component, component2, 576f);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		child = base.transform.GetChild(9);
		this.m_FBPlatformLogin = child;
		component = child.GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
		component.material = this.mat;
		component.type = Image.Type.Sliced;
		component = child.GetChild(0).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
		component.material = this.mat;
		component.type = Image.Type.Sliced;
		component2 = child.GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9516u);
		this.CrossPlatformSetup.LoginTitle = component2;
		component2 = child.GetChild(2).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = DataManager.Instance.mStringTable.GetStringByID(9517u);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.CrossPlatformSetup.Title = component2;
		component3 = child.GetChild(3).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 14;
		component3.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
		component3.image.material = this.mat;
		component3 = child.GetChild(4).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 29;
		component3.image.sprite = this.m_Door.LoadSprite("UI_main_close");
		component3.image.material = this.m_Door.LoadMaterial();
		component3.image.SetNativeSize();
		component = child.GetChild(3).GetChild(0).GetComponent<Image>();
		component.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_19");
		component.material = this.mat;
		component.SetNativeSize();
		this.CrossPlatformSetup.LoginPanelImg = component;
		this.m_RotImage[5] = component;
		component2 = child.GetChild(3).GetChild(1).GetComponent<UIText>();
		component2.font = this.TTF;
		component2.text = this.DM.mStringTable.GetStringByID(8428u);
		this.SetCenterText(component, component2, 576f);
		this.m_TempText[this.m_TempTextIdx++] = component2;
		this.UseWechat = 1;
		if (this.GM.IsArabic)
		{
			for (int l = 0; l < this.m_RotImage.Length; l++)
			{
				if (this.m_RotImage[l] != null)
				{
					ArabicItemTextureRot component6 = this.m_RotImage[l].gameObject.GetComponent<ArabicItemTextureRot>();
					if (component6 == null)
					{
						this.m_RotImage[l].gameObject.AddComponent<ArabicItemTextureRot>();
					}
				}
			}
		}
		this.SetMailData(eUIAccountType.AccountSetting);
		this.SetPanelType(this.m_UIType);
		if (!this.CheckReceive() && IGGGameSDK.Instance.bBindingGoogle)
		{
			DataManager.Instance.SendAccountBind();
		}
		this.CheckBind();
		this.IosExamine();
		GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
	}

	// Token: 0x060015D7 RID: 5591 RVA: 0x00254C54 File Offset: 0x00252E54
	public override void OnClose()
	{
		for (int i = 0; i < this.MaxStr; i++)
		{
			StringManager.Instance.DeSpawnString(this.m_Str[i]);
		}
		for (int j = 0; j < 5; j++)
		{
			StringManager.Instance.DeSpawnString(this.m_ItemObject[j].Str);
		}
		this.GM.RemoveSpriteAsset(this.AssName);
	}

	// Token: 0x060015D8 RID: 5592 RVA: 0x00254CCC File Offset: 0x00252ECC
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 100)
		{
			this.GM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(7077u), this.DM.mStringTable.GetStringByID(7079u), 2, 0, null, null);
			return;
		}
		if (arg1 == 200)
		{
			this.GM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(7077u), this.DM.mStringTable.GetStringByID(7088u), 1, 0, null, null);
			return;
		}
		if (arg1 == 1)
		{
			this.SetPanelType(eUIAccountType.AccountSetting);
		}
		else if (arg1 == 2)
		{
			GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_TreasureBox, 2, 1, false, 0);
		}
		else if (arg1 == 3)
		{
			this.SetPanelType(eUIAccountType.AccountSetting);
		}
		else
		{
			this.SetPanelType(this.m_UIType);
		}
		this.SetMailData(this.m_UIType);
		this.UpdateScrollPanel(false);
		this.CheckBind();
	}

	// Token: 0x060015D9 RID: 5593 RVA: 0x00254DCC File Offset: 0x00252FCC
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x060015DA RID: 5594 RVA: 0x00254DF8 File Offset: 0x00252FF8
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 == 2)
			{
				if (this.GM.ShowUILock(EUILock.SwitchingGoogleAccount))
				{
					IGGSDKPlugin.GoogleAccountLogin(this.SDK.SelectAccount);
				}
			}
			else if (arg1 == 1)
			{
				IGGSDKPlugin.LinkingGoogleAccount(this.SDK.SelectAccount);
			}
			else if (arg1 == 5)
			{
				if (this.CrossType == UIOther_Account.eCrossType.Facebook)
				{
					this.SwitchFacebook();
				}
				else
				{
					this.SwitchWeChat();
				}
			}
		}
	}

	// Token: 0x060015DB RID: 5595 RVA: 0x00254E78 File Offset: 0x00253078
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		int mailIdx = this.m_Data[dataIdx].MailIdx;
		if (this.m_ItemObject[panelObjectIdx].AccText == null)
		{
			this.m_ItemObject[panelObjectIdx].Img1 = item.transform.GetChild(0).GetComponent<Image>();
			this.m_ItemObject[panelObjectIdx].Img2 = item.transform.GetChild(1).GetComponent<Image>();
			this.m_ItemObject[panelObjectIdx].Select = item.transform.GetChild(2).GetChild(0).GetComponent<Image>();
			this.m_ItemObject[panelObjectIdx].AccText = item.transform.GetChild(3).GetComponent<UIText>();
		}
		this.m_ItemObject[panelObjectIdx].Select.enabled = this.m_Data[dataIdx].bSelect;
		this.m_ItemObject[panelObjectIdx].Img2.enabled = this.m_Data[dataIdx].bSelect;
		if (this.m_Data[dataIdx].AccountType == eAccountType.DeviceLogin)
		{
			if (mailIdx < this.SDK.m_MailList.Count)
			{
				this.m_ItemObject[panelObjectIdx].AccText.text = this.DM.mStringTable.GetStringByID(7069u);
			}
		}
		else if (mailIdx < this.SDK.m_MailList.Count)
		{
			this.m_ItemObject[panelObjectIdx].AccText.text = this.SDK.m_MailList[mailIdx];
		}
		this.m_ItemObject[panelObjectIdx].AccText.SetAllDirty();
		this.m_ItemObject[panelObjectIdx].AccText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x060015DC RID: 5596 RVA: 0x00255068 File Offset: 0x00253268
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		if (this.NowSelectDataIdx < this.m_Data.Count && !this.m_Data[dataIndex].bSelect)
		{
			sAccount value;
			if (this.NowSelectDataIdx >= 0 && this.NowSelectDataIdx < this.m_Data.Count)
			{
				value = this.m_Data[this.NowSelectDataIdx];
				value.bSelect = false;
				this.m_Data[this.NowSelectDataIdx] = value;
			}
			this.NowSelectDataIdx = dataIndex;
			value = this.m_Data[dataIndex];
			value.bSelect = !this.m_Data[dataIndex].bSelect;
			this.m_Data[dataIndex] = value;
			this.UpdateScrollPanel(false);
		}
	}

	// Token: 0x060015DD RID: 5597 RVA: 0x00255138 File Offset: 0x00253338
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			this.SetPanelType(eUIAccountType.AccountBind);
			break;
		case 1:
			IGGSDKPlugin.ClearFacebookSession();
			break;
		case 2:
			this.SetPanelType(eUIAccountType.SwitchGoogleAccountPlatform);
			break;
		case 3:
			if (this.UseWechat == 1)
			{
				this.SetPanelType(eUIAccountType.CrossPlatformList);
			}
			else
			{
				this.CrossType = UIOther_Account.eCrossType.Facebook;
				this.CrossPlatformSetup.SetPlatform(this.CrossType, this.CrossPlatformIcons[(int)this.CrossType]);
				this.m_CrossPlatformPanel.gameObject.SetActive(true);
				this.m_CrossPlatformList.gameObject.SetActive(false);
			}
			break;
		case 4:
			RealNameHelp.Instance.OpenRealNameAsyncByWebView();
			break;
		case 5:
			GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
			this.GM.CloseMenu(EGUIWindow.UI_Other_Account);
			break;
		case 6:
			this.SetPanelType(eUIAccountType.AccountSetting);
			break;
		case 7:
			if (this.m_UIType == eUIAccountType.AccountBind)
			{
				if (this.NowSelectDataIdx >= 0)
				{
					this.GM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(7077u), this.DM.mStringTable.GetStringByID(7088u), 1, 0, null, null);
				}
			}
			else if (this.m_UIType == eUIAccountType.SwitchAccount && this.NowSelectDataIdx >= 0)
			{
				if (this.m_Data[this.NowSelectDataIdx].AccountType != eAccountType.DeviceLogin)
				{
					this.GM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(7077u), this.DM.mStringTable.GetStringByID(7079u), 2, 0, null, null);
				}
				else
				{
					this.OnOKCancelBoxClick(true, 2, 0);
				}
			}
			break;
		case 8:
			this.SetPanelType(eUIAccountType.AccountSetting);
			break;
		case 9:
			this.SetPanelType(eUIAccountType.PlatformBind);
			break;
		case 10:
			this.SetPanelType(eUIAccountType.PlatformLogin);
			break;
		case 11:
			if (this.UseWechat == 1)
			{
				this.SetPanelType(eUIAccountType.CrossPlatformList);
			}
			else
			{
				this.SetPanelType(eUIAccountType.AccountSetting);
			}
			break;
		case 12:
			if (this.CrossType == UIOther_Account.eCrossType.Facebook)
			{
				this.BindFacebook();
			}
			else
			{
				this.BindWechat();
			}
			break;
		case 13:
			this.SetPanelType(eUIAccountType.CrossPlatform);
			break;
		case 14:
			this.GM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(7077u), this.CrossPlatformSetup.MsgStr, 5, 0, null, null);
			break;
		case 15:
			this.SetPanelType(eUIAccountType.CrossPlatform);
			break;
		case 16:
			if (this.GM.ShowUILock(EUILock.SwitchAccount))
			{
				IGGSDKPlugin.GeustLogin();
			}
			break;
		case 17:
			this.SetPanelType(eUIAccountType.SwitchAccount);
			break;
		case 18:
			this.SetPanelType(eUIAccountType.AccountSetting);
			break;
		case 19:
			this.CrossType = UIOther_Account.eCrossType.Facebook;
			this.CrossPlatformSetup.SetPlatform(this.CrossType, this.CrossPlatformIcons[(int)this.CrossType]);
			this.m_CrossPlatformPanel.gameObject.SetActive(true);
			this.m_CrossPlatformList.gameObject.SetActive(false);
			break;
		case 20:
			if (!IGGSDKPlugin.isWXAppInstalled())
			{
				GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(614u), this.DM.mStringTable.GetStringByID(9525u), null, null, 0, 0, false, false, false, false, false);
			}
			else
			{
				this.CrossType = UIOther_Account.eCrossType.WeChat;
				this.CrossPlatformSetup.SetPlatform(this.CrossType, this.CrossPlatformIcons[(int)this.CrossType]);
				this.m_CrossPlatformPanel.gameObject.SetActive(true);
				this.m_CrossPlatformList.gameObject.SetActive(false);
			}
			break;
		case 21:
			this.SetPanelType(eUIAccountType.AccountSetting);
			break;
		case 22:
			this.BindWechat();
			break;
		case 23:
			this.SwitchWeChat();
			break;
		case 24:
			this.SetPanelType(eUIAccountType.SwitchWechatFacebookPlatform);
			break;
		case 25:
			this.SetPanelType(eUIAccountType.AccountSetting);
			break;
		case 26:
			this.CrossType = UIOther_Account.eCrossType.WeChat;
			this.CrossPlatformSetup.SetPlatform(this.CrossType, this.CrossPlatformIcons[(int)this.CrossType]);
			this.m_WeChatPlatformLogin.gameObject.SetActive(true);
			break;
		case 27:
			this.SetPanelType(eUIAccountType.SwitchWechatFacebookPlatform);
			break;
		case 28:
			this.CrossType = UIOther_Account.eCrossType.Facebook;
			this.CrossPlatformSetup.SetPlatform(this.CrossType, this.CrossPlatformIcons[(int)this.CrossType]);
			this.m_FBPlatformLogin.gameObject.SetActive(true);
			break;
		case 29:
			this.SetPanelType(eUIAccountType.SwitchWechatFacebookPlatform);
			break;
		}
	}

	// Token: 0x060015DE RID: 5598 RVA: 0x00255600 File Offset: 0x00253800
	private void SetPanelType(eUIAccountType type)
	{
		if (type != eUIAccountType.SwitchAccount && type != eUIAccountType.AccountBind)
		{
			this.Close();
		}
		this.m_UIType = type;
		if (type == eUIAccountType.AccountSetting)
		{
			this.SetLoginIcon();
			this.m_SettingPanel.gameObject.SetActive(true);
			this.m_SwitchPanel.gameObject.SetActive(false);
			this.m_CrossPlatformList.gameObject.SetActive(false);
			this.m_SettingTitleText.text = this.DM.mStringTable.GetStringByID(7071u);
			this.m_Str[0].ClearString();
			this.m_Str[0].StringToFormat(this.SDK.m_IGGID);
			this.m_Str[0].AppendFormat(this.DM.mStringTable.GetStringByID(7067u));
			this.m_SettingIGGIDText.text = this.m_Str[0].ToString();
			this.SetSetttingPos();
		}
		else if (type == eUIAccountType.AccountBind)
		{
			IGGSDKPlugin.ShowAccount(true);
			this.SDK.bShowAccountState = true;
		}
		else if (type == eUIAccountType.SwitchAccount)
		{
			IGGSDKPlugin.ShowAccount(false);
			this.SDK.bShowAccountState = true;
		}
		else if (type == eUIAccountType.CrossPlatform)
		{
			if (this.UseWechat == 1)
			{
				this.m_CrossPlatformList.gameObject.SetActive(true);
			}
			else
			{
				this.m_CrossPlatformPanel.gameObject.SetActive(true);
			}
		}
		else if (type == eUIAccountType.PlatformBind)
		{
			this.m_PlatformBindPanel.gameObject.SetActive(true);
		}
		else if (type == eUIAccountType.PlatformLogin)
		{
			this.m_PlatformLoginPanel.gameObject.SetActive(true);
		}
		else if (type == eUIAccountType.SwitchGoogleAccountPlatform)
		{
			this.m_SwitchGoogleAccountPanel.gameObject.SetActive(true);
		}
		else if (type == eUIAccountType.CrossPlatformList)
		{
			this.m_CrossPlatformList.gameObject.SetActive(true);
		}
		else if (type == eUIAccountType.SwitchWechatFacebookPlatform)
		{
			this.m_SwitchWechatFacebookPlatform.gameObject.SetActive(true);
		}
		else if (type == eUIAccountType.WeChatPlatformLogin)
		{
			this.m_WeChatPlatformLogin.gameObject.SetActive(true);
		}
		this.IosExamine();
	}

	// Token: 0x060015DF RID: 5599 RVA: 0x00255820 File Offset: 0x00253A20
	private void UpdateScrollPanel(bool bSetToTop = false)
	{
		List<float> list = new List<float>();
		for (int i = 0; i < this.m_Data.Count; i++)
		{
			list.Add(54f);
		}
		this.m_ScrollPanel.AddNewDataHeight(list, bSetToTop, true);
	}

	// Token: 0x060015E0 RID: 5600 RVA: 0x00255868 File Offset: 0x00253A68
	private void SetMailData(eUIAccountType type)
	{
		List<float> list = new List<float>();
		this.m_Data.Clear();
		this.NowSelectDataIdx = -1;
		this.m_SwitchEmpty.gameObject.SetActive(false);
		if (type == eUIAccountType.AccountSetting)
		{
			list.Clear();
			if (!this.bScrollPanelInit)
			{
				this.m_ScrollPanel.IntiScrollPanel(202f, 10f, 0f, list, 5, this);
				this.bScrollPanelInit = true;
			}
			else
			{
				this.UpdateScrollPanel(false);
			}
		}
		else if (type == eUIAccountType.AccountBind)
		{
			for (int i = 0; i < this.SDK.m_MailList.Count; i++)
			{
				sAccount item = default(sAccount);
				item.AccountType = eAccountType.BindGoogle;
				item.MailIdx = i;
				this.m_Data.Add(item);
				if (this.NowSelectDataIdx == -1)
				{
					this.NowSelectDataIdx = 0;
				}
			}
			this.UpdateScrollPanel(false);
			if (this.NowSelectDataIdx == -1)
			{
				this.m_SwitchEmpty.gameObject.SetActive(true);
			}
			else
			{
				this.m_SwitchEmpty.gameObject.SetActive(false);
			}
		}
		else if (type == eUIAccountType.SwitchAccount)
		{
			sAccount item = default(sAccount);
			item.AccountType = eAccountType.DeviceLogin;
			item.MailIdx = -1;
			if (!this.SDK.bBindingGoogle)
			{
				this.NowSelectDataIdx = -1;
			}
			else if (this.SDK.m_BindGoogleAccount == string.Empty)
			{
				this.NowSelectDataIdx = 0;
				item.bSelect = true;
			}
			this.m_Data.Add(item);
			for (int j = 0; j < this.SDK.m_MailList.Count; j++)
			{
				item = default(sAccount);
				if (this.SDK.bBindingGoogle && this.SDK.m_MailList[j] == this.SDK.m_BindGoogleAccount)
				{
					this.NowSelectDataIdx = j + 1;
					item.bSelect = true;
				}
				item.AccountType = eAccountType.BindGoogle;
				item.MailIdx = j;
				this.m_Data.Add(item);
			}
			for (int k = 0; k < this.m_Data.Count; k++)
			{
				list.Add(54f);
			}
			this.m_ScrollPanel.AddNewDataHeight(list, false, true);
		}
	}

	// Token: 0x060015E1 RID: 5601 RVA: 0x00255AC0 File Offset: 0x00253CC0
	private void CheckBind()
	{
		if (IGGGameSDK.Instance.bBindingGoogle || this.SDK.m_IGGLoginType == IGGLoginType.WeChat || this.SDK.m_IGGLoginType == IGGLoginType.Facebook)
		{
			this.m_BindGiftTf.gameObject.SetActive(false);
		}
		else
		{
			this.m_BindGiftTf.gameObject.SetActive(true);
		}
	}

	// Token: 0x060015E2 RID: 5602 RVA: 0x00255B28 File Offset: 0x00253D28
	private bool CheckReceive()
	{
		return DataManager.Instance.CheckPrizeFlag(2);
	}

	// Token: 0x060015E3 RID: 5603 RVA: 0x00255B38 File Offset: 0x00253D38
	private void SetFakeDate()
	{
	}

	// Token: 0x060015E4 RID: 5604 RVA: 0x00255B3C File Offset: 0x00253D3C
	private void BindFacebook()
	{
		IGGSDKPlugin.GetToken();
	}

	// Token: 0x060015E5 RID: 5605 RVA: 0x00255B44 File Offset: 0x00253D44
	private void BindWechat()
	{
		if (!IGGSDKPlugin.isWXAppInstalled())
		{
			GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(614u), this.DM.mStringTable.GetStringByID(9525u), null, null, 0, 0, false, false, false, false, false);
			return;
		}
		IGGSDKPlugin.BindWeChat();
	}

	// Token: 0x060015E6 RID: 5606 RVA: 0x00255BA0 File Offset: 0x00253DA0
	private void SwitchFacebook()
	{
		IGGSDKPlugin.SwitchFacebook();
	}

	// Token: 0x060015E7 RID: 5607 RVA: 0x00255BA8 File Offset: 0x00253DA8
	private void SwitchWeChat()
	{
		if (!IGGSDKPlugin.isWXAppInstalled())
		{
			GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(614u), this.DM.mStringTable.GetStringByID(9525u), null, null, 0, 0, false, false, false, false, false);
			return;
		}
		IGGSDKPlugin.LoginWeChat();
	}

	// Token: 0x060015E8 RID: 5608 RVA: 0x00255C04 File Offset: 0x00253E04
	private void BindAmazon()
	{
	}

	// Token: 0x060015E9 RID: 5609 RVA: 0x00255C08 File Offset: 0x00253E08
	private void LoginAmazon()
	{
	}

	// Token: 0x060015EA RID: 5610 RVA: 0x00255C0C File Offset: 0x00253E0C
	private void Close()
	{
		this.m_SettingPanel.gameObject.SetActive(false);
		this.m_PlatformBindPanel.gameObject.SetActive(false);
		this.m_PlatformLoginPanel.gameObject.SetActive(false);
		this.m_SwitchPanel.gameObject.SetActive(false);
		this.m_CrossPlatformPanel.gameObject.SetActive(false);
		this.m_SwitchGoogleAccountPanel.gameObject.SetActive(false);
		this.m_SwitchWechatFacebookPlatform.gameObject.SetActive(false);
		this.m_WeChatPlatformLogin.gameObject.SetActive(false);
		this.m_FBPlatformLogin.gameObject.SetActive(false);
	}

	// Token: 0x060015EB RID: 5611 RVA: 0x00255CB4 File Offset: 0x00253EB4
	private void SetCenterText(Image image, UIText text, float width)
	{
		float num = 10f;
		float x = (width - (image.rectTransform.sizeDelta.x + text.preferredWidth + num)) / 2f;
		image.rectTransform.anchoredPosition = new Vector2(x, image.rectTransform.anchoredPosition.y);
		text.rectTransform.anchoredPosition = new Vector2(image.rectTransform.anchoredPosition.x + image.rectTransform.sizeDelta.x + num, text.rectTransform.anchoredPosition.y);
	}

	// Token: 0x060015EC RID: 5612 RVA: 0x00255D60 File Offset: 0x00253F60
	private void SetLoginIcon()
	{
		if (this.m_GIcon != null && this.mat != null)
		{
			if (IGGGameSDK.Instance.m_IGGLoginType == IGGLoginType.Facebook)
			{
				this.m_GIcon.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
			}
			else if (IGGGameSDK.Instance.m_IGGLoginType == IGGLoginType.WeChat)
			{
				this.m_GIcon.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_19");
			}
			else
			{
				this.m_GIcon.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_19");
				this.m_GIcon.SetNativeSize();
			}
			this.m_GIcon.material = this.mat;
		}
	}

	// Token: 0x060015ED RID: 5613 RVA: 0x00255E38 File Offset: 0x00254038
	private void SetSetttingPos()
	{
		UIText component2;
		if (this.SDK.m_IGGLoginType == IGGLoginType.WeChat || this.SDK.m_IGGLoginType == IGGLoginType.Facebook)
		{
			this.m_BindAccountText.enabled = false;
			this.m_BindBtn.gameObject.SetActive(false);
			this.m_GIcon.gameObject.SetActive(true);
			this.m_LogoutBtn.gameObject.SetActive(true);
			this.m_SwitchBtn.gameObject.SetActive(false);
			this.m_SettingAccImage.rectTransform.sizeDelta = new Vector2(367f, 47f);
			this.m_SettingAccImage.rectTransform.anchoredPosition = new Vector2(-48.5f, -11.5f);
			this.m_SettingAccText.text = this.SDK.m_BindGoogleAccount;
			this.m_BindBtn.m_BtnID1 = 22;
			this.m_SwitchBtn.m_BtnID1 = 23;
		}
		else
		{
			if (this.SDK.bBindingGoogle)
			{
				this.m_BindAccountText.enabled = true;
				this.m_BindBtn.gameObject.SetActive(false);
				this.m_GIcon.gameObject.SetActive(false);
				this.m_LogoutBtn.gameObject.SetActive(false);
				this.m_SwitchBtn.gameObject.SetActive(true);
				this.m_SettingAccImage.rectTransform.sizeDelta = new Vector2(514f, 47f);
				this.m_SettingAccImage.rectTransform.anchoredPosition = new Vector2(0f, -11.5f);
				if (this.SDK.m_BindGoogleAccount == string.Empty)
				{
					this.m_SettingAccText.text = this.DM.mStringTable.GetStringByID(7085u);
				}
				this.m_SettingAccText.rectTransform.anchoredPosition = new Vector2(-67f, -10f);
				this.m_BindAccountText.rectTransform.anchoredPosition = new Vector2(-5f, -10f);
			}
			else
			{
				this.m_BindAccountText.enabled = false;
				this.m_LogoutBtn.gameObject.SetActive(false);
				this.m_BindBtn.gameObject.SetActive(true);
				this.m_BindBtn.m_BtnID1 = 22;
				RectTransform component = this.m_BindBtn.gameObject.GetComponent<RectTransform>();
				component.sizeDelta = new Vector2(204f, 73f);
				Vector2 anchoredPosition = component.anchoredPosition;
				anchoredPosition.x = 200f;
				component.anchoredPosition = anchoredPosition;
				this.m_GIcon.transform.SetParent(this.m_BindBtn.transform, false);
				this.m_GIcon.rectTransform.anchorMax = new Vector2(0f, 0.5f);
				this.m_GIcon.rectTransform.anchorMin = new Vector2(0f, 0.5f);
				this.m_GIcon.rectTransform.pivot = new Vector2(0f, 0.5f);
				this.m_GIcon.rectTransform.anchoredPosition = new Vector2(15f, -2f);
				component2 = this.m_BindBtn.transform.GetChild(0).GetComponent<UIText>();
				if (component2 != null)
				{
					component2.rectTransform.anchorMax = new Vector2(0f, 0.5f);
					component2.rectTransform.anchorMin = new Vector2(0f, 0.5f);
					component2.rectTransform.pivot = new Vector2(0f, 0.5f);
					component2.rectTransform.anchoredPosition = new Vector2(69f, 0f);
				}
				this.m_SettingAccImage.rectTransform.sizeDelta = new Vector2(367f, 47f);
				if (this.SDK.m_BindGoogleAccount == string.Empty)
				{
					this.m_SettingAccText.text = this.DM.mStringTable.GetStringByID(7085u);
				}
				this.m_SettingAccImage.rectTransform.anchoredPosition = new Vector2(-108f, -11.5f);
				this.m_SettingAccText.rectTransform.anchoredPosition = new Vector2(-108f, -10f);
			}
			this.m_SettingIGGIDText.rectTransform.anchoredPosition = new Vector2(25f, 43f);
		}
		this.m_SwitchPlatform.gameObject.SetActive(false);
		this.m_SwitchBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, -137.5f);
		this.m_SwitchBtn.m_BtnID1 = 24;
		component2 = this.m_SwitchBtn.transform.GetChild(0).GetComponent<UIText>();
		component2.text = this.DM.mStringTable.GetStringByID(7075u);
		Vector2 anchoredPosition2;
		anchoredPosition2.x = -140f;
		anchoredPosition2.y = -137.5f;
		this.m_RealName.gameObject.transform.GetComponent<RectTransform>().anchoredPosition = anchoredPosition2;
		anchoredPosition2.x = 140f;
		this.m_SwitchBtn.GetComponent<RectTransform>().anchoredPosition = anchoredPosition2;
		this.m_RealName.gameObject.SetActive(true);
	}

	// Token: 0x060015EE RID: 5614 RVA: 0x0025636C File Offset: 0x0025456C
	private void SetSetttingPos_Amazon()
	{
		if (this.SDK.m_IGGLoginType == IGGLoginType.AMAZON)
		{
			this.m_BindAccountText.enabled = false;
			this.m_BindBtn.gameObject.SetActive(false);
			this.m_GIcon.gameObject.SetActive(true);
			this.m_GIcon.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_24");
			this.m_LogoutBtn.gameObject.SetActive(true);
			this.m_SwitchBtn.gameObject.SetActive(false);
			this.m_SwitchPlatform.gameObject.SetActive(false);
			this.m_SettingAccImage.rectTransform.sizeDelta = new Vector2(367f, 47f);
			this.m_SettingAccImage.rectTransform.anchoredPosition = new Vector2(-48.5f, -11.5f);
			this.m_SettingAccText.text = this.SDK.m_BindGoogleAccount;
			this.m_BindBtn.m_BtnID1 = 22;
			this.m_SwitchBtn.m_BtnID1 = 23;
		}
		else if (this.SDK.m_IGGLoginType == IGGLoginType.Facebook)
		{
			this.m_BindAccountText.enabled = false;
			this.m_BindBtn.gameObject.SetActive(false);
			this.m_GIcon.gameObject.SetActive(true);
			this.m_GIcon.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
			this.m_LogoutBtn.gameObject.SetActive(true);
			this.m_SwitchBtn.gameObject.SetActive(false);
			this.m_SwitchPlatform.gameObject.SetActive(false);
			this.m_SettingAccImage.rectTransform.sizeDelta = new Vector2(367f, 47f);
			this.m_SettingAccImage.rectTransform.anchoredPosition = new Vector2(-48.5f, -11.5f);
			this.m_SettingAccText.text = this.SDK.m_BindGoogleAccount;
			this.m_BindBtn.m_BtnID1 = 22;
			this.m_SwitchBtn.m_BtnID1 = 23;
		}
		else
		{
			if (this.SDK.bBindingGoogle)
			{
				this.m_BindAccountText.enabled = true;
				this.m_BindBtn.gameObject.SetActive(false);
				this.m_GIcon.gameObject.SetActive(false);
				this.m_LogoutBtn.gameObject.SetActive(false);
				this.m_SwitchBtn.gameObject.SetActive(true);
				this.m_SettingAccImage.rectTransform.sizeDelta = new Vector2(514f, 47f);
				this.m_SettingAccImage.rectTransform.anchoredPosition = new Vector2(0f, -11.5f);
				if (this.SDK.m_BindGoogleAccount == string.Empty)
				{
					this.m_SettingAccText.text = this.DM.mStringTable.GetStringByID(7085u);
				}
				this.m_SettingAccText.rectTransform.anchoredPosition = new Vector2(-67f, -10f);
				this.m_BindAccountText.rectTransform.anchoredPosition = new Vector2(-5f, -10f);
			}
			else
			{
				this.m_BindAccountText.enabled = false;
				this.m_LogoutBtn.gameObject.SetActive(false);
				this.m_BindBtn.gameObject.SetActive(true);
				this.m_BindBtn.m_BtnID1 = 22;
				this.m_LogoutBtn.gameObject.SetActive(false);
				if (this.SDK.m_BindGoogleAccount == string.Empty)
				{
					this.m_SettingAccText.text = this.DM.mStringTable.GetStringByID(7085u);
				}
			}
			this.m_SettingIGGIDText.rectTransform.anchoredPosition = new Vector2(25f, 43f);
			this.m_SwitchPlatform.gameObject.SetActive(true);
		}
		this.m_SwitchBtn.m_BtnID1 = 23;
		UIText component = this.m_SwitchBtn.transform.GetChild(0).GetComponent<UIText>();
		component.text = this.DM.mStringTable.GetStringByID(8428u);
	}

	// Token: 0x060015EF RID: 5615 RVA: 0x00256798 File Offset: 0x00254998
	private void IosExamine()
	{
	}

	// Token: 0x060015F0 RID: 5616 RVA: 0x0025679C File Offset: 0x0025499C
	private void SetIosCnUI()
	{
		if (this.m_SettingPanel == null)
		{
			return;
		}
		RectTransform component = this.m_SettingPanel.GetChild(0).GetComponent<RectTransform>();
		Vector2 sizeDelta = component.sizeDelta;
		sizeDelta.y = 407f;
		component.sizeDelta = sizeDelta;
		Vector2 anchoredPosition;
		for (int i = 1; i < this.m_SettingPanel.childCount; i++)
		{
			Transform child = this.m_SettingPanel.GetChild(i);
			if (child != null)
			{
				component = this.m_SettingPanel.GetChild(i).GetComponent<RectTransform>();
				if (component != null)
				{
					anchoredPosition = component.anchoredPosition;
					anchoredPosition.y += 40.5f;
					component.anchoredPosition = anchoredPosition;
				}
			}
		}
		component = this.m_RealName.gameObject.transform.GetComponent<RectTransform>();
		anchoredPosition = component.anchoredPosition;
		anchoredPosition.y = -175f;
		component.anchoredPosition = anchoredPosition;
		this.m_RealName.gameObject.SetActive(true);
	}

	// Token: 0x060015F1 RID: 5617 RVA: 0x002568A4 File Offset: 0x00254AA4
	private void SetAndroidCnUI()
	{
		if (this.m_SettingPanel == null)
		{
			return;
		}
		RectTransform component = this.m_RealName.gameObject.transform.GetComponent<RectTransform>();
		Vector2 anchoredPosition = component.anchoredPosition;
		anchoredPosition.x = 140f;
		anchoredPosition.y = -137.5f;
		component.anchoredPosition = anchoredPosition;
		this.m_RealName.gameObject.SetActive(true);
	}

	// Token: 0x060015F2 RID: 5618 RVA: 0x00256910 File Offset: 0x00254B10
	public void Refresh_FontTexture()
	{
		if (this.m_SettingTitleText != null && this.m_SettingTitleText.enabled)
		{
			this.m_SettingTitleText.enabled = false;
			this.m_SettingTitleText.enabled = true;
		}
		if (this.m_SettingIGGIDText != null && this.m_SettingIGGIDText.enabled)
		{
			this.m_SettingIGGIDText.enabled = false;
			this.m_SettingIGGIDText.enabled = true;
		}
		if (this.m_SettingAccText != null && this.m_SettingAccText.enabled)
		{
			this.m_SettingAccText.enabled = false;
			this.m_SettingAccText.enabled = true;
		}
		if (this.m_BindAccountText != null && this.m_BindAccountText.enabled)
		{
			this.m_BindAccountText.enabled = false;
			this.m_BindAccountText.enabled = true;
		}
		if (this.m_SwitchTitleText != null && this.m_SwitchTitleText.enabled)
		{
			this.m_SwitchTitleText.enabled = false;
			this.m_SwitchTitleText.enabled = true;
		}
		if (this.m_ItemObject != null)
		{
			for (int i = 0; i < this.m_ItemObject.Length; i++)
			{
				if (this.m_ItemObject[i].AccText != null && this.m_ItemObject[i].AccText.enabled)
				{
					this.m_ItemObject[i].AccText.enabled = false;
					this.m_ItemObject[i].AccText.enabled = true;
				}
			}
		}
		if (this.m_TempText != null)
		{
			for (int j = 0; j < this.m_TempText.Length; j++)
			{
				if (this.m_TempText[j] != null && this.m_TempText[j].enabled)
				{
					this.m_TempText[j].enabled = false;
					this.m_TempText[j].enabled = true;
				}
			}
		}
	}

	// Token: 0x040040CD RID: 16589
	private const int MaxScrollCount = 5;

	// Token: 0x040040CE RID: 16590
	private const float ScrollItemHeight = 54f;

	// Token: 0x040040CF RID: 16591
	private const int MaxTempTextNum = 36;

	// Token: 0x040040D0 RID: 16592
	private Font TTF;

	// Token: 0x040040D1 RID: 16593
	private GUIManager GM;

	// Token: 0x040040D2 RID: 16594
	private DataManager DM;

	// Token: 0x040040D3 RID: 16595
	private IGGGameSDK SDK;

	// Token: 0x040040D4 RID: 16596
	private Door m_Door;

	// Token: 0x040040D5 RID: 16597
	private string AssName = "UIOther";

	// Token: 0x040040D6 RID: 16598
	private int MaxStr = 4;

	// Token: 0x040040D7 RID: 16599
	private AccItemObject[] m_ItemObject;

	// Token: 0x040040D8 RID: 16600
	private Image m_GIcon;

	// Token: 0x040040D9 RID: 16601
	private Image m_SettingAccImage;

	// Token: 0x040040DA RID: 16602
	private UIText m_SettingTitleText;

	// Token: 0x040040DB RID: 16603
	private UIText m_SettingIGGIDText;

	// Token: 0x040040DC RID: 16604
	private UIText m_SettingAccText;

	// Token: 0x040040DD RID: 16605
	private UIText m_BindAccountText;

	// Token: 0x040040DE RID: 16606
	private Transform m_BindGiftTf;

	// Token: 0x040040DF RID: 16607
	private Image m_SwitchEmpty;

	// Token: 0x040040E0 RID: 16608
	private UIText m_SwitchTitleText;

	// Token: 0x040040E1 RID: 16609
	private UIButton m_BindBtn;

	// Token: 0x040040E2 RID: 16610
	private UIButton m_LogoutBtn;

	// Token: 0x040040E3 RID: 16611
	private UIButton m_SwitchBtn;

	// Token: 0x040040E4 RID: 16612
	private UIButton m_SwitchPlatform;

	// Token: 0x040040E5 RID: 16613
	private UIButton m_RealName;

	// Token: 0x040040E6 RID: 16614
	private UIButton m_YesBtn;

	// Token: 0x040040E7 RID: 16615
	private UIButton m_NoBtn;

	// Token: 0x040040E8 RID: 16616
	private Transform m_SettingPanel;

	// Token: 0x040040E9 RID: 16617
	private Transform m_SwitchPanel;

	// Token: 0x040040EA RID: 16618
	private Transform m_CrossPlatformPanel;

	// Token: 0x040040EB RID: 16619
	private Transform m_PlatformBindPanel;

	// Token: 0x040040EC RID: 16620
	private Transform m_PlatformLoginPanel;

	// Token: 0x040040ED RID: 16621
	private Transform m_SwitchGoogleAccountPanel;

	// Token: 0x040040EE RID: 16622
	private Transform m_CrossPlatformList;

	// Token: 0x040040EF RID: 16623
	private Transform m_SwitchWechatFacebookPlatform;

	// Token: 0x040040F0 RID: 16624
	private Transform m_WeChatPlatformLogin;

	// Token: 0x040040F1 RID: 16625
	private Transform m_FBPlatformLogin;

	// Token: 0x040040F2 RID: 16626
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040040F3 RID: 16627
	private CString[] m_Str;

	// Token: 0x040040F4 RID: 16628
	private List<sAccount> m_Data;

	// Token: 0x040040F5 RID: 16629
	private eUIAccountType m_UIType;

	// Token: 0x040040F6 RID: 16630
	private int NowSelectDataIdx;

	// Token: 0x040040F7 RID: 16631
	private bool bScrollPanelInit;

	// Token: 0x040040F8 RID: 16632
	private UIText[] m_TempText = new UIText[36];

	// Token: 0x040040F9 RID: 16633
	private int m_TempTextIdx;

	// Token: 0x040040FA RID: 16634
	private Material mat;

	// Token: 0x040040FB RID: 16635
	private Image[] m_RotImage = new Image[9];

	// Token: 0x040040FC RID: 16636
	private byte UseWechat;

	// Token: 0x040040FD RID: 16637
	private UIOther_Account.eCrossType CrossType;

	// Token: 0x040040FE RID: 16638
	private Sprite[] CrossPlatformIcons = new Sprite[2];

	// Token: 0x040040FF RID: 16639
	private UIOther_Account._CrossPlatformSetup CrossPlatformSetup;

	// Token: 0x02000443 RID: 1091
	private enum eCrossType
	{
		// Token: 0x04004101 RID: 16641
		Facebook,
		// Token: 0x04004102 RID: 16642
		WeChat
	}

	// Token: 0x02000444 RID: 1092
	private struct _CrossPlatformSetup
	{
		// Token: 0x060015F3 RID: 5619 RVA: 0x00256B28 File Offset: 0x00254D28
		public void SetPlatform(UIOther_Account.eCrossType type, Sprite sprite)
		{
			Image bindImg = this.BindImg;
			this.LoginPanelImg.sprite = sprite;
			this.BindPanelImg.sprite = sprite;
			this.LoginImg.sprite = sprite;
			bindImg.sprite = sprite;
			StringTable mStringTable = DataManager.Instance.mStringTable;
			if (type == UIOther_Account.eCrossType.Facebook)
			{
				this.Title.text = mStringTable.GetStringByID(9010u);
				this.Tip.text = mStringTable.GetStringByID(9005u);
				this.MsgStr = mStringTable.GetStringByID(9011u);
				this.LoginTitle.text = mStringTable.GetStringByID(9009u);
				this.BindTitle.text = mStringTable.GetStringByID(9004u);
			}
			else
			{
				this.Title.text = mStringTable.GetStringByID(9517u);
				this.Tip.text = mStringTable.GetStringByID(9512u);
				this.MsgStr = mStringTable.GetStringByID(9518u);
				this.LoginTitle.text = mStringTable.GetStringByID(9516u);
				this.BindTitle.text = mStringTable.GetStringByID(9511u);
			}
		}

		// Token: 0x04004103 RID: 16643
		public Image BindImg;

		// Token: 0x04004104 RID: 16644
		public Image LoginImg;

		// Token: 0x04004105 RID: 16645
		public Image BindPanelImg;

		// Token: 0x04004106 RID: 16646
		public Image LoginPanelImg;

		// Token: 0x04004107 RID: 16647
		public UIText Title;

		// Token: 0x04004108 RID: 16648
		public UIText Tip;

		// Token: 0x04004109 RID: 16649
		public UIText LoginTitle;

		// Token: 0x0400410A RID: 16650
		public UIText BindTitle;

		// Token: 0x0400410B RID: 16651
		public string MsgStr;
	}
}
