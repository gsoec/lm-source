using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x02000600 RID: 1536
public class UILordInfo : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUILEBtnClickHandler
{
	// Token: 0x06001E01 RID: 7681 RVA: 0x00388D64 File Offset: 0x00386F64
	public override void OnOpen(int arg1, int arg2)
	{
		this.OpenKind = (EUILordInfoLayout)arg1;
		GUIManager instance = GUIManager.Instance;
		this.DM = DataManager.Instance;
		this.door = (instance.FindMenu(EGUIWindow.Door) as Door);
		for (int i = 0; i < this.tmpString.Length; i++)
		{
			this.tmpString[i] = StringManager.Instance.SpawnString(50);
		}
		for (int j = 0; j < this.tmpLordString.Length; j++)
		{
			this.tmpLordString[j] = StringManager.Instance.SpawnString(100);
		}
		for (int k = 0; k < this.JailerStr.Length; k++)
		{
			this.JailerStr[k] = StringManager.Instance.SpawnString(30);
		}
		this.hintString = StringManager.Instance.SpawnString(300);
		this.countDown = StringManager.Instance.SpawnString(30);
		this.PopStr = StringManager.Instance.SpawnString(30);
		this.EnStr = StringManager.Instance.SpawnString(30);
		this.TitleSPItemText = StringManager.Instance.SpawnString(300);
		this.TitleSPItemText2 = StringManager.Instance.SpawnString(300);
		this.TitleSPItemText3 = StringManager.Instance.SpawnString(300);
		Font ttffont = instance.GetTTFFont();
		this.AGS_Form = base.transform;
		this.AGS_bgPanel = this.AGS_Form.GetChild(0).GetComponent<UISpritesArray>();
		UIButton component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.image.sprite = this.door.LoadSprite("UI_main_close");
		component.image.material = this.door.LoadMaterial();
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		Image component2 = this.AGS_Form.GetChild(1).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close_base");
		component2.material = this.door.LoadMaterial();
		component2.enabled = !GUIManager.Instance.bOpenOnIPhoneX;
		this.headInfoPanel = this.AGS_Form.GetChild(2).GetComponent<RectTransform>();
		this.AGS_btn_BuffInfo = this.AGS_Form.GetChild(2).GetChild(0).GetComponent<UISpritesArray>();
		component = this.AGS_Form.GetChild(2).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		this.AGS_HeadBGImage = this.AGS_Form.GetChild(2).GetChild(1).GetComponent<UISpritesArray>();
		this.AGS_HeadBGImage.gameObject.SetActive(false);
		UIText component3 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3.SetCheckArabic(true);
		component = this.AGS_Form.GetChild(2).GetChild(3).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		component = this.AGS_Form.GetChild(2).GetChild(4).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		component3 = this.AGS_Form.GetChild(2).GetChild(5).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3 = this.AGS_Form.GetChild(2).GetChild(6).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component = this.AGS_Form.GetChild(2).GetChild(7).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		this.AGS_GuildLogo = this.AGS_Form.GetChild(2).GetChild(7).GetChild(0).GetComponent<UISpritesArray>();
		component = this.AGS_Form.GetChild(2).GetChild(8).GetComponent<UIButton>();
		component.m_Handler = this;
		UIButtonHint uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		this.AGS_GuildRank = this.AGS_Form.GetChild(2).GetChild(8).GetComponent<UISpritesArray>();
		component = this.AGS_Form.GetChild(2).GetChild(9).GetComponent<UIButton>();
		component.m_Handler = this;
		uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		component = this.AGS_Form.GetChild(2).GetChild(10).GetComponent<UIButton>();
		component.m_Handler = this;
		uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		component3 = this.AGS_Form.GetChild(2).GetChild(11).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		if (instance.IsArabic)
		{
			RectTransform component4 = component.gameObject.GetComponent<RectTransform>();
			component4.localScale = new Vector3(-1f, 1f, 1f);
			component4.anchoredPosition = new Vector2(component4.anchoredPosition.x + 40f, component4.anchoredPosition.y);
		}
		component = this.AGS_Form.GetChild(2).GetChild(12).GetComponent<UIButton>();
		component.m_Handler = this;
		uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		component = this.AGS_Form.GetChild(2).GetChild(13).GetComponent<UIButton>();
		component.m_Handler = this;
		uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		component.m_BtnID1 = 6;
		component.m_BtnID2 = 7;
		component = this.AGS_Form.GetChild(2).GetChild(14).GetComponent<UIButton>();
		component.m_Handler = this;
		uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		component.m_BtnID1 = 6;
		component.m_BtnID2 = 6;
		component = this.AGS_Form.GetChild(2).GetChild(15).GetComponent<UIButton>();
		component.m_Handler = this;
		uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		component.m_BtnID1 = 6;
		component.m_BtnID2 = 11;
		component.gameObject.SetActive(false);
		component = this.AGS_Form.GetChild(2).GetChild(16).GetComponent<UIButton>();
		component.m_Handler = this;
		this.SideBtnPanel = this.AGS_Form.GetChild(3).GetComponent<RectTransform>();
		component = this.AGS_Form.GetChild(3).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		component2 = this.AGS_Form.GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_redbox_01");
		component2.material = this.door.LoadMaterial();
		component2.type = Image.Type.Sliced;
		component2 = this.AGS_Form.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_mess_ex");
		component2.material = this.door.LoadMaterial();
		component = this.AGS_Form.GetChild(3).GetChild(1).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		component.m_BtnID2 = 9;
		this.CoordBtnRT = (component.transform as RectTransform);
		this.ItemPanel = this.AGS_Form.GetChild(5).GetComponent<RectTransform>();
		this.UILEBtn = new RectTransform[8];
		for (int l = 0; l < 8; l++)
		{
			this.UILEBtn[l] = this.AGS_Form.GetChild(5).GetChild(l + 16).GetComponent<RectTransform>();
			UILEBtn component5 = this.UILEBtn[l].GetComponent<UILEBtn>();
			component5.m_Handler = this;
			instance.InitLordEquipImg(this.UILEBtn[l].transform, 0, 0, eLordEquipDisplayKind.OnlyItem, true, true, 0, 0, 0, 0, 0, false);
			if (this.OpenKind == EUILordInfoLayout.LordOther)
			{
				component5.SetEffectType(e_EffectType.e_Normal);
				this.UILEBtn[l].GetComponent<uButtonScale>().enabled = false;
			}
			component = this.AGS_Form.GetChild(5).GetChild(l + 8).GetComponent<UIButton>();
			component.m_Handler = this;
			if (this.OpenKind == EUILordInfoLayout.LordSelf)
			{
				component.m_EffectType = e_EffectType.e_Scale;
			}
			component.transition = Selectable.Transition.None;
			GameConstants.SetPivot(component.GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
			if (this.OpenKind == EUILordInfoLayout.LordOther)
			{
				uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
				uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
				uibuttonHint.Parm2 = 1;
				uibuttonHint.m_Handler = this;
			}
		}
		if (this.OpenKind != EUILordInfoLayout.LordOther)
		{
			component = this.AGS_Form.GetChild(5).GetChild(14).GetComponent<UIButton>();
			uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			component = this.AGS_Form.GetChild(5).GetChild(15).GetComponent<UIButton>();
			uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
		}
		component = this.AGS_Form.GetChild(6).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 6;
		component.m_BtnID2 = 8;
		uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		component = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 6;
		component.m_BtnID2 = 10;
		uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		component = this.AGS_Form.GetChild(6).GetChild(6).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 6;
		component.m_BtnID2 = 8;
		uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		if (instance.IsArabic)
		{
			RectTransform component6 = component.gameObject.GetComponent<RectTransform>();
			component6.localScale = new Vector3(-1f, 1f, 1f);
			component6.anchoredPosition = new Vector2(component6.anchoredPosition.x + 42f, component6.anchoredPosition.y);
		}
		component = this.AGS_Form.GetChild(6).GetChild(4).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		component.m_BtnID1 = 9;
		component.m_BtnID2 = 1;
		component = this.AGS_Form.GetChild(6).GetChild(5).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		component.m_BtnID1 = 9;
		component.m_BtnID2 = 2;
		component3 = this.AGS_Form.GetChild(6).GetChild(7).GetComponent<UIText>();
		component3.text = string.Empty;
		component3.font = ttffont;
		component3 = this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>();
		component3.text = string.Empty;
		component3.font = ttffont;
		component = this.AGS_Form.GetChild(7).GetComponent<UIButton>();
		component.m_Handler = this;
		uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		if (this.DM.UserLanguage == GameLanguage.GL_Chs)
		{
			this.AGS_Form.GetChild(7).GetComponent<UISpritesArray>().SetSpriteIndex(1);
		}
		if (instance.IsArabic)
		{
			RectTransform component7 = component.gameObject.GetComponent<RectTransform>();
			component7.localScale = new Vector3(-1f, 1f, 1f);
			component7.anchoredPosition = new Vector2(component7.anchoredPosition.x + 59f, component7.anchoredPosition.y);
		}
		component3 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		if (instance.IsArabic)
		{
			RectTransform component8 = component3.gameObject.GetComponent<RectTransform>();
			component8.localEulerAngles = new Vector3(0f, 180f, 0f);
		}
		component = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 6;
		component.m_BtnID2 = 25;
		uibuttonHint = component.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		component3 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		if (instance.IsArabic)
		{
			RectTransform component9 = component3.gameObject.GetComponent<RectTransform>();
			component9.localEulerAngles = new Vector3(0f, 180f, 0f);
		}
		component = this.AGS_Form.GetChild(8).GetComponent<UIButton>();
		component.m_Handler = this;
		component.gameObject.SetActive(false);
		component.transition = Selectable.Transition.None;
		component.m_EffectType = e_EffectType.e_Scale;
		this.HeroRank = this.AGS_Form.GetChild(9).GetComponent<Image>();
		component = this.AGS_Form.GetChild(9).GetComponent<UIButton>();
		uibuttonHint = this.AGS_Form.GetChild(9).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		component.m_Handler = this;
		this.AGS_HeroBadge = this.AGS_Form.GetChild(10).GetComponent<UISpritesArray>();
		component = this.AGS_Form.GetChild(10).GetComponent<UIButton>();
		uibuttonHint = this.AGS_Form.GetChild(10).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		component.m_Handler = this;
		this.Hero_Pos = this.AGS_Form.GetChild(11);
		this.Hero_PosRT = this.Hero_Pos.GetComponent<RectTransform>();
		this.LightRT = this.AGS_Form.GetChild(12).GetComponent<RectTransform>();
		component = this.AGS_Form.GetChild(4).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 10;
		this.HeroRotater = component.gameObject.AddComponent<UIBtnDrag>();
		this.HeroRotater.mHero = this.Hero_PosRT;
		this.TitlePanel = this.AGS_Form.GetChild(13).GetComponent<RectTransform>();
		this.TitlePanel.gameObject.SetActive(false);
		component = this.AGS_Form.GetChild(13).GetChild(0).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 6;
		component.m_BtnID2 = 22;
		uibuttonHint = this.AGS_Form.GetChild(13).GetChild(0).GetChild(0).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		component3 = this.AGS_Form.GetChild(13).GetChild(2).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3.resizeTextForBestFit = true;
		component3.resizeTextMinSize = 10;
		component3.resizeTextMaxSize = 25;
		component = this.AGS_Form.GetChild(13).GetChild(3).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 6;
		component.m_BtnID2 = 21;
		uibuttonHint = this.AGS_Form.GetChild(13).GetChild(3).GetChild(0).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		component3 = this.AGS_Form.GetChild(13).GetChild(5).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3.resizeTextForBestFit = true;
		component3.resizeTextMinSize = 10;
		component3.resizeTextMaxSize = 25;
		component = this.AGS_Form.GetChild(13).GetChild(6).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 6;
		component.m_BtnID2 = 21;
		uibuttonHint = this.AGS_Form.GetChild(13).GetChild(6).GetChild(0).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		component3 = this.AGS_Form.GetChild(13).GetChild(8).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3.resizeTextForBestFit = true;
		component3.resizeTextMinSize = 10;
		component3.resizeTextMaxSize = 25;
		this.ScrollPanel = this.AGS_Form.GetChild(14).GetComponent<RectTransform>();
		this.AGS_ScrollPanel = this.AGS_Form.GetChild(14).GetChild(0).GetComponent<ScrollPanel>();
		component3 = this.AGS_Form.GetChild(14).GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3.gameObject.AddComponent<Outline>();
		component3 = this.AGS_Form.GetChild(14).GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(7370u);
		component3.color = new Color32(byte.MaxValue, byte.MaxValue, 153, byte.MaxValue);
		component3.gameObject.AddComponent<Outline>();
		component3 = this.AGS_Form.GetChild(14).GetChild(1).GetChild(1).GetChild(1).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3 = this.AGS_Form.GetChild(14).GetChild(1).GetChild(1).GetChild(2).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3 = this.AGS_Form.GetChild(14).GetChild(1).GetChild(1).GetChild(3).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3.color = new Color32(0, byte.MaxValue, 49, byte.MaxValue);
		this.AGS_Form.GetChild(14).GetChild(2).gameObject.SetActive(false);
		this.TitleSPItem = this.AGS_Form.GetChild(14).GetChild(2).GetComponent<RectTransform>();
		component = this.AGS_Form.GetChild(14).GetChild(2).GetChild(1).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 6;
		component.m_BtnID2 = 26;
		uibuttonHint = this.AGS_Form.GetChild(14).GetChild(2).GetChild(1).GetChild(0).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ScrollID = 1;
		component3 = this.AGS_Form.GetChild(14).GetChild(2).GetChild(2).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3 = this.AGS_Form.GetChild(14).GetChild(2).GetChild(3).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		this.TitleSPItem2 = this.AGS_Form.GetChild(14).GetChild(3).GetComponent<RectTransform>();
		component = this.AGS_Form.GetChild(14).GetChild(3).GetChild(1).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 6;
		component.m_BtnID2 = 28;
		uibuttonHint = this.AGS_Form.GetChild(14).GetChild(3).GetChild(1).GetChild(0).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ScrollID = 1;
		component3 = this.AGS_Form.GetChild(14).GetChild(3).GetChild(2).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3 = this.AGS_Form.GetChild(14).GetChild(3).GetChild(3).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		this.TitleSPItem3 = this.AGS_Form.GetChild(14).GetChild(4).GetComponent<RectTransform>();
		component = this.AGS_Form.GetChild(14).GetChild(4).GetChild(1).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 6;
		component.m_BtnID2 = 27;
		uibuttonHint = this.AGS_Form.GetChild(14).GetChild(4).GetChild(1).GetChild(0).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.ScrollID = 1;
		component3 = this.AGS_Form.GetChild(14).GetChild(4).GetChild(2).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3 = this.AGS_Form.GetChild(14).GetChild(4).GetChild(3).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		this.PopupPanel = this.AGS_Form.GetChild(18).GetComponent<RectTransform>();
		this.JailerPanel = this.AGS_Form.GetChild(15).GetComponent<RectTransform>();
		UIHIBtn component10 = this.AGS_Form.GetChild(15).GetChild(2).GetComponent<UIHIBtn>();
		component10.m_Handler = this;
		component = this.AGS_Form.GetChild(15).GetChild(3).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		component = this.AGS_Form.GetChild(15).GetChild(4).GetComponent<UIButton>();
		component.m_Handler = this;
		component3 = this.AGS_Form.GetChild(15).GetChild(5).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(7774u);
		component3 = this.AGS_Form.GetChild(15).GetChild(6).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3 = this.AGS_Form.GetChild(15).GetChild(7).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3 = this.AGS_Form.GetChild(15).GetChild(9).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(7775u);
		component3 = this.AGS_Form.GetChild(15).GetChild(10).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component = this.AGS_Form.GetChild(15).GetChild(12).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		component3 = this.AGS_Form.GetChild(15).GetChild(12).GetChild(0).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(7776u);
		component3 = this.AGS_Form.GetChild(15).GetChild(15).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(7764u);
		component3 = this.AGS_Form.GetChild(15).GetChild(17).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component = this.AGS_Form.GetChild(15).GetChild(18).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		component3 = this.AGS_Form.GetChild(15).GetChild(18).GetChild(0).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(7773u);
		this.RescurePanel = this.AGS_Form.GetChild(16).GetComponent<RectTransform>();
		component = this.AGS_Form.GetChild(16).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component3 = this.AGS_Form.GetChild(16).GetChild(0).GetChild(0).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(7785u);
		this.CaptureBar = this.AGS_Form.GetChild(17).GetComponent<RectTransform>();
		component3 = this.AGS_Form.GetChild(17).GetChild(3).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3 = this.AGS_Form.GetChild(17).GetChild(4).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		component3 = this.AGS_Form.GetChild(17).GetChild(5).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(7792u);
		component3.gameObject.SetActive(false);
		component = this.AGS_Form.GetChild(17).GetChild(6).GetComponent<UIButton>();
		component.m_Handler = this;
		component.gameObject.SetActive(false);
		component.m_BtnID1 = 2;
		component.m_BtnID2 = 10;
		component = this.AGS_Form.GetChild(18).GetComponent<UIButton>();
		component.m_Handler = this;
		component = this.AGS_Form.GetChild(18).GetChild(0).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		component3 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(0).GetChild(1).GetComponent<UIText>();
		component3.text = this.DM.mStringTable.GetStringByID(7227u);
		component3.font = ttffont;
		component = this.AGS_Form.GetChild(18).GetChild(0).GetChild(1).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		component.gameObject.SetActive(false);
		component3 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(1).GetChild(1).GetComponent<UIText>();
		component3.text = this.DM.mStringTable.GetStringByID(7228u);
		component3.font = ttffont;
		component = this.AGS_Form.GetChild(18).GetChild(0).GetChild(2).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		component3 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(2).GetChild(1).GetComponent<UIText>();
		component3.text = this.DM.mStringTable.GetStringByID(7229u);
		component3.font = ttffont;
		this.HintPanel = this.AGS_Form.GetChild(19).GetComponent<RectTransform>();
		component = this.AGS_Form.GetChild(18).GetChild(0).GetChild(3).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = 4;
		component3 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(3).GetChild(1).GetComponent<UIText>();
		component3.text = this.DM.mStringTable.GetStringByID(4552u);
		component3.font = ttffont;
		component = this.AGS_Form.GetChild(18).GetChild(0).GetChild(4).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = 5;
		component3 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(4).GetChild(1).GetComponent<UIText>();
		component3.text = this.DM.mStringTable.GetStringByID(4553u);
		component3.font = ttffont;
		component = this.AGS_Form.GetChild(18).GetChild(0).GetChild(5).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = 6;
		component3 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(5).GetChild(1).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(9348u);
		component = this.AGS_Form.GetChild(18).GetChild(0).GetChild(6).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID2 = 7;
		component3 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(6).GetChild(1).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = this.DM.mStringTable.GetStringByID(9739u);
		component3 = this.AGS_Form.GetChild(19).GetChild(1).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = string.Empty;
		this.AGS_Form.GetChild(20).GetComponent<Image>().enabled = false;
		component3 = this.AGS_Form.GetChild(20).GetChild(0).GetComponent<UIText>();
		component3.text = this.DM.mStringTable.GetStringByID(7275u);
		component3.font = ttffont;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			RectTransform component11 = this.AGS_Form.GetChild(18).GetComponent<RectTransform>();
			component11.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
			component11.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
		}
		this.BarLight = this.CaptureBar.GetChild(0).GetComponent<Image>();
		this.Header_NameText = StringManager.Instance.SpawnString(300);
		for (int m = 0; m < 8; m++)
		{
			this.UILEBtn[m].gameObject.SetActive(false);
			this.LEquipLight[m] = this.AGS_Form.GetChild(5).GetChild(m + 8).GetChild(0).GetComponent<Image>();
		}
		Vector3 localPosition;
		for (int n = 3; n < this.AGS_Form.childCount; n++)
		{
			localPosition = this.AGS_Form.GetChild(n).localPosition;
			localPosition.z = -1000f;
			this.AGS_Form.GetChild(n).localPosition = localPosition;
		}
		localPosition = this.AGS_Form.GetChild(11).localPosition;
		localPosition.z = -500f;
		this.AGS_Form.GetChild(11).localPosition = localPosition;
		this.AGS_Form.GetChild(12).localPosition = localPosition;
		this.SetFormLayout(this.OpenKind);
		this.UpdateInfo(0, 0);
		instance.UpdateUI(EGUIWindow.Door, 1, 2);
		EUILordInfoLayout openKind = this.OpenKind;
		if (openKind == EUILordInfoLayout.LordOther)
		{
			GUIManager.Instance.ShowUILock(EUILock.LordInfo);
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_PROFILE;
			messagePacket.AddSeqId();
			messagePacket.Add(this.DM.mLordName.ToString(), 13);
			messagePacket.Send(false);
		}
		LordEquipData.Instance().LoadLordEquip(false);
		LordEquipData.CheckEquipExpired();
		this.NextActionTime = Time.time + 5f;
	}

	// Token: 0x06001E02 RID: 7682 RVA: 0x0038AF60 File Offset: 0x00389160
	public void Refresh_FontTexture()
	{
		Text component = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(5).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(6).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(2).GetChild(11).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(7).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(13).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(13).GetChild(5).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(13).GetChild(8).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(14).GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(14).GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(14).GetChild(1).GetChild(1).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(14).GetChild(1).GetChild(1).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(14).GetChild(1).GetChild(1).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		if (this.TitleSPItem != null)
		{
			this.TitleSPItem.GetChild(2).GetComponent<UIText>();
			if (component != null && component.enabled)
			{
				component.enabled = false;
				component.enabled = true;
			}
			this.TitleSPItem.GetChild(3).GetComponent<UIText>();
			if (component != null && component.enabled)
			{
				component.enabled = false;
				component.enabled = true;
			}
		}
		if (this.TitleSPItem2 != null)
		{
			this.TitleSPItem2.GetChild(2).GetComponent<UIText>();
			if (component != null && component.enabled)
			{
				component.enabled = false;
				component.enabled = true;
			}
			this.TitleSPItem2.GetChild(3).GetComponent<UIText>();
			if (component != null && component.enabled)
			{
				component.enabled = false;
				component.enabled = true;
			}
		}
		if (this.TitleSPItem3 != null)
		{
			this.TitleSPItem3.GetChild(2).GetComponent<UIText>();
			if (component != null && component.enabled)
			{
				component.enabled = false;
				component.enabled = true;
			}
			this.TitleSPItem3.GetChild(3).GetComponent<UIText>();
			if (component != null && component.enabled)
			{
				component.enabled = false;
				component.enabled = true;
			}
		}
		component = this.AGS_Form.GetChild(15).GetChild(5).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(15).GetChild(6).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(15).GetChild(7).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(15).GetChild(9).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(15).GetChild(10).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(15).GetChild(12).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(15).GetChild(15).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(15).GetChild(17).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(15).GetChild(18).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(16).GetChild(0).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(17).GetChild(3).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(17).GetChild(4).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(17).GetChild(5).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(18).GetChild(0).GetChild(0).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(18).GetChild(0).GetChild(1).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(18).GetChild(0).GetChild(2).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(18).GetChild(0).GetChild(3).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(18).GetChild(0).GetChild(4).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(18).GetChild(0).GetChild(5).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(18).GetChild(0).GetChild(6).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(19).GetChild(1).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(20).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		if (this.AGS_ScrollPanel != null && this.AGS_ScrollPanel.gameObject.activeInHierarchy)
		{
			Transform child = this.AGS_ScrollPanel.transform.GetChild(0);
			for (int i = 0; i < child.childCount; i++)
			{
				Transform child2 = child.GetChild(i);
				if (child2.gameObject.activeInHierarchy)
				{
					if (child2.GetChild(0).gameObject.activeInHierarchy)
					{
						component = child2.GetChild(0).GetChild(0).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
						component = child2.GetChild(0).GetChild(1).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
					}
					if (child2.GetChild(1).gameObject.activeInHierarchy)
					{
						component = child2.GetChild(1).GetChild(1).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
						component = child2.GetChild(1).GetChild(2).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
						component = child2.GetChild(1).GetChild(3).GetComponent<UIText>();
						if (component != null && component.enabled)
						{
							component.enabled = false;
							component.enabled = true;
						}
					}
				}
			}
		}
		for (int j = 0; j < 8; j++)
		{
			LordEquipData.ResetLordEquipFont(this.UILEBtn[j]);
		}
	}

	// Token: 0x06001E03 RID: 7683 RVA: 0x0038BC94 File Offset: 0x00389E94
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
		{
			int btnID = sender.m_BtnID2;
			if (btnID != 0)
			{
				if (btnID == 1)
				{
					this.SetPopUp(false);
				}
			}
			else
			{
				switch (this.OpenKind)
				{
				case EUILordInfoLayout.RecordInfo:
				case EUILordInfoLayout.EnhanceInfo:
					this.SetFormLayout(EUILordInfoLayout.LordSelf);
					this.UpdateInfo(0, 0);
					break;
				case EUILordInfoLayout.RecordInfoOther:
					this.SetFormLayout(EUILordInfoLayout.LordOther);
					this.UpdateInfo(1, 0);
					break;
				default:
					this.door.CloseMenu(false);
					break;
				}
			}
			break;
		}
		case 1:
			switch (sender.m_BtnID2)
			{
			case 1:
				switch (this.OpenKind)
				{
				case EUILordInfoLayout.LordSelf:
					if (!this.StatDataReady)
					{
						if (GUIManager.Instance.ShowUILock(EUILock.LordInfo))
						{
							MessagePacket messagePacket = new MessagePacket(1024);
							messagePacket.Protocol = Protocol._MSG_REQUEST_STATISTIC;
							messagePacket.AddSeqId();
							messagePacket.Add(this.DM.RoleAttr.Name.ToString(), 13);
							messagePacket.Send(false);
						}
					}
					else
					{
						if (this.scrollPanelInit && this.HasBeenPage != EUILordInfoLayout.RecordInfo)
						{
							this.AGS_ScrollPanel.GoTo(0);
						}
						this.UpdateInfo(3, 0);
					}
					break;
				case EUILordInfoLayout.LordOther:
					if (!this.StatDataReady)
					{
						if (GUIManager.Instance.ShowUILock(EUILock.LordInfo))
						{
							MessagePacket messagePacket2 = new MessagePacket(1024);
							messagePacket2.Protocol = Protocol._MSG_REQUEST_STATISTIC;
							messagePacket2.AddSeqId();
							messagePacket2.Add(this.DM.mLordProfile.PlayerName.ToString(), 13);
							messagePacket2.Send(false);
						}
					}
					else
					{
						this.UpdateInfo(3, 0);
					}
					break;
				case EUILordInfoLayout.RecordInfo:
					this.SetFormLayout(EUILordInfoLayout.LordSelf);
					this.UpdateInfo(0, 0);
					break;
				case EUILordInfoLayout.RecordInfoOther:
					this.SetFormLayout(EUILordInfoLayout.LordOther);
					this.UpdateInfo(1, 0);
					break;
				}
				break;
			case 2:
				if (!NewbieManager.CheckRename(false))
				{
					GUIManager.Instance.OpenMenu(EGUIWindow.UI_Name, 0, 0, true, true, false);
				}
				break;
			case 3:
				this.AllianceClick();
				break;
			case 4:
				this.SetPopUp(true);
				break;
			}
			break;
		case 2:
			switch (sender.m_BtnID2)
			{
			case 1:
				GameConstants.GetBytes(0, GUIManager.Instance.TalentSaved, 5);
				this.door.OpenMenu(EGUIWindow.UI_Talent, 0, 0, false);
				break;
			case 2:
				if (this.scrollPanelInit && this.HasBeenPage != EUILordInfoLayout.EnhanceInfo)
				{
					this.AGS_ScrollPanel.GoTo(0);
				}
				this.SetFormLayout(EUILordInfoLayout.EnhanceInfo);
				this.UpdateInfo(0, 0);
				break;
			case 3:
				this.door.OpenMenu(EGUIWindow.UI_ReplaceLord, 0, 0, false);
				break;
			case 4:
				this.DM.Letter_ReplyName = this.DM.beCaptured.name.ToString();
				this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 2, 0, false);
				break;
			case 5:
				this.door.GoToMapID(this.DM.beCaptured.KingdomID, this.DM.beCaptured.MapID, 0, 1, true);
				break;
			case 6:
				GUIManager.Instance.OpenMenu(EGUIWindow.UI_JailMoney, 1, 0, false, true, false);
				break;
			case 7:
				if (this.DM.beCaptured.Ransom > this.DM.Resource[4].Stock)
				{
					GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7795u), 255, true);
					return;
				}
				this.PopStr.ClearString();
				this.PopStr.IntToFormat((long)((ulong)this.DM.beCaptured.Ransom), 1, false);
				this.PopStr.AppendFormat(this.DM.mStringTable.GetStringByID(7778u));
				GUIManager.Instance.OpenOKCancelBox(this, DataManager.Instance.mStringTable.GetStringByID(7769u), this.PopStr.ToString(), 1, 0, null, null);
				break;
			case 8:
			{
				long num = this.DM.beCaptured.StartActionTime + (long)((ulong)this.DM.beCaptured.TotalTime) - this.DM.ServerTime;
				if (num <= 0L)
				{
					if (GUIManager.Instance.ShowUILock(EUILock.LordInfo))
					{
						MessagePacket messagePacket3 = new MessagePacket(1024);
						messagePacket3.Protocol = Protocol._MSG_REQUEST_LORD_REVIVE;
						messagePacket3.AddSeqId();
						messagePacket3.Send(false);
						this.NextActionTime = 0f;
					}
				}
				else
				{
					GUIManager.Instance.UseOrSpend(1117, this.DM.mStringTable.GetStringByID(7785u), 0, 0, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
				}
				break;
			}
			case 9:
				UIFormationSelect.ArmyCoordIndexCache = this.DM.RoleAttr.NowArmyCoordIndex;
				this.door.OpenMenu(EGUIWindow.UI_FormationSelect, 0, 0, false);
				break;
			case 10:
			{
				long num2 = this.DM.beCaptured.StartActionTime + (long)((ulong)this.DM.beCaptured.TotalTime) - this.DM.ServerTime;
				if (num2 >= 108000L)
				{
					GUIManager.Instance.ShowUILock(EUILock.LordInfo);
					MessagePacket messagePacket4 = new MessagePacket(1024);
					messagePacket4.Protocol = Protocol._MSG_REQUEST_SUICIDENUM_BY_POWER_BOARD;
					messagePacket4.AddSeqId();
					messagePacket4.Add(this.DM.RoleAttr.Power);
					messagePacket4.Send(false);
				}
				else
				{
					GUIManager.Instance.MsgStr.ClearString();
					GUIManager.Instance.MsgStr.IntToFormat(24L, 1, false);
					GUIManager.Instance.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(15001u));
					GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), 255, true);
				}
				break;
			}
			}
			break;
		case 3:
		{
			int btnID = sender.m_BtnID2;
			if (btnID != 7)
			{
				if (btnID == 8)
				{
					if (GUIManager.Instance.BuildingData.GetBuildData(15, 0).Level < 25)
					{
						return;
					}
				}
			}
			else if (GUIManager.Instance.BuildingData.GetBuildData(15, 0).Level < 17)
			{
				return;
			}
			if (this.OpenKind == EUILordInfoLayout.LordSelf)
			{
				UILordEquip.waitForReturn = eUI_LordEquipReturnKind.None;
				this.door.OpenMenu(EGUIWindow.UI_LordEquip, 0, sender.m_BtnID2, false);
			}
			break;
		}
		case 4:
			this.door.OpenMenu(EGUIWindow.UI_LordEquipSetSelect, 0, 0, false);
			break;
		case 5:
			switch (sender.m_BtnID2)
			{
			case 1:
				this.DM.Letter_ReplyName = this.DM.mLordProfile.PlayerName.ToString();
				this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 2, 0, false);
				break;
			case 2:
				if (this.DM.FindBlackList(this.DM.mLordProfile.PlayerName))
				{
					this.DM.RemoveBlackList(this.DM.mLordProfile.PlayerName);
				}
				else
				{
					this.DM.AddBlackList(this.DM.mLordProfile.PlayerName, this.DM.mLordProfile.Head);
				}
				this.SetPopUp(false);
				break;
			case 3:
				this.DM.SendAllinceInvite(this.DM.mLordProfile.PlayerName.ToString());
				this.SetPopUp(false);
				break;
			case 4:
			{
				bool flag = GUIManager.Instance.CanResourceTransport();
				if (flag && this.door)
				{
					UILordInfo.OpenTransport = true;
					DataManager.Instance.SendAllyPoint(this.DM.mLordProfile.PlayerName.ToString());
				}
				break;
			}
			case 5:
			{
				bool flag2 = this.door.m_GroundInfo.ReinforceCheck();
				if (flag2 && this.door)
				{
					DataManager.Instance.ReinforceCheckType = eReinforceCheck.OpenReinforce_NoLoc;
					DataManager.Instance.m_InForceName = this.DM.mLordProfile.PlayerName.ToString();
					DataManager.Instance.SendAllyInforceInfo(this.DM.mLordProfile.PlayerName.ToString());
				}
				break;
			}
			case 6:
			{
				byte b = 0;
				if ((DataManager.MapDataController.IsKing() || DataManager.MapDataController.IsKingdomChief()) && DataManager.MapDataController.kingdomData.kingdomID == this.DM.mLordProfile.KindomID)
				{
					b += 1;
				}
				if ((DataManager.MapDataController.IsWorldKing() || DataManager.MapDataController.IsWorldChief()) && this.DM.mLordProfile.WorldTitle != 1)
				{
					b += 2;
				}
				if ((DataManager.MapDataController.IsNobilityKing() || DataManager.MapDataController.IsNobilityChief()) && ActivityManager.Instance.CheckCanonizationNoility(this.DM.mLordProfile.KindomID) && this.DM.mLordProfile.NobilityTitle != 1)
				{
					b += 4;
				}
				switch (b)
				{
				case 1:
					TitleManager.Instance.OpenTitleSet(this.DM.mLordProfile.PlayerName);
					break;
				case 2:
					TitleManager.Instance.OpenTitleListW(this.DM.mLordProfile.PlayerName);
					break;
				case 3:
				case 5:
				case 6:
				case 7:
					GUIManager.Instance.OpenCanonizedPanel(this.DM.mLordProfile.PlayerName, 1, (int)b);
					break;
				case 4:
					TitleManager.Instance.OpenNobilityTitleSet(this.DM.mLordProfile.PlayerName);
					break;
				}
				break;
			}
			case 7:
				if (this.door.m_GroundInfo.CheckMarchEventDataCount())
				{
					AmbushManager.Instance.SendAllyAmbushInfo(this.DM.mLordProfile.PlayerName.ToString());
				}
				break;
			}
			break;
		case 9:
		{
			int btnID = sender.m_BtnID2;
			if (btnID != 1)
			{
				if (btnID == 2)
				{
					GUIManager.Instance.OpenItemKindFilterUI(10, 33, 0);
				}
			}
			else
			{
				GUIManager.Instance.OpenItemKindFilterUI(10, 30, 0);
			}
			break;
		}
		}
	}

	// Token: 0x06001E04 RID: 7684 RVA: 0x0038C7A8 File Offset: 0x0038A9A8
	public void OnLEButtonClick(UILEBtn sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID == 3)
		{
			if (this.OpenKind != EUILordInfoLayout.LordSelf)
			{
				return;
			}
			UILordEquip.waitForReturn = eUI_LordEquipReturnKind.None;
			this.door.OpenMenu(EGUIWindow.UI_LordEquip, 0, sender.m_BtnID2, false);
		}
	}

	// Token: 0x06001E05 RID: 7685 RVA: 0x0038C7F8 File Offset: 0x0038A9F8
	public void OnHIButtonClick(UIHIBtn sender)
	{
		this.door.CloseMenu(false);
		GUIWindowStackData item = default(GUIWindowStackData);
		item.bCameraMode = true;
		item.m_eWindow = EGUIWindow.UI_LordInfo;
		item.m_Arg1 = 1;
		item.m_Arg2 = 0;
		this.door.m_WindowStack.Add(item);
		this.DM.ShowLordProfile(this.DM.beCaptured.name.ToString());
	}

	// Token: 0x06001E06 RID: 7686 RVA: 0x0038C86C File Offset: 0x0038AA6C
	private void AllianceClick()
	{
		switch (this.OpenKind)
		{
		case EUILordInfoLayout.LordSelf:
		case EUILordInfoLayout.RecordInfo:
			this.door.AllianceOnClick();
			break;
		case EUILordInfoLayout.LordOther:
		case EUILordInfoLayout.RecordInfoOther:
			if (this.DM.mLordProfile.AlliID == 0u)
			{
				return;
			}
			if (this.isSameAlli)
			{
				if (this.DM.CheckPrizeFlag(9))
				{
					GUIManager.Instance.OpenSendGiftUI(this.DM.mLordProfile.AllianceTag, this.DM.mLordProfile.PlayerName);
				}
				else
				{
					this.door.AllianceOnClick();
				}
				return;
			}
			this.DM.AllianceView.Id = this.DM.mLordProfile.AlliID;
			this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5, 0, false);
			break;
		}
	}

	// Token: 0x06001E07 RID: 7687 RVA: 0x0038C954 File Offset: 0x0038AB54
	public override void UpdateUI(int arg1, int arg2)
	{
		this.UpdateInfo(arg1, arg2);
	}

	// Token: 0x06001E08 RID: 7688 RVA: 0x0038C960 File Offset: 0x0038AB60
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Refresh_ChangeLord:
		case NetworkNews.Refresh_VIP:
			break;
		default:
			switch (networkNews)
			{
			case NetworkNews.Login:
			{
				LordEquipData.Instance().LoadLordEquip(false);
				EUILordInfoLayout openKind = this.OpenKind;
				if (openKind == EUILordInfoLayout.LordSelf || openKind == EUILordInfoLayout.EnhanceInfo)
				{
					this.UpdateInfo(0, 0);
				}
				return;
			}
			default:
				if (networkNews != NetworkNews.Refresh_Building && networkNews != NetworkNews.Refresh_Technology)
				{
					return;
				}
				switch (this.OpenKind)
				{
				case EUILordInfoLayout.RecordInfo:
				case EUILordInfoLayout.EnhanceInfo:
					this.UpdateInfo(0, 0);
					break;
				}
				return;
			case NetworkNews.Refresh_Asset:
				if (meg[2] == 2 && GameConstants.ConvertBytesToUInt(meg, 3) == (uint)this.sHero.HeroKey)
				{
					this.Create3DObjects();
				}
				return;
			case NetworkNews.Refresh_Attr:
				break;
			}
			break;
		case NetworkNews.Refresh_BuffList:
		{
			EUILordInfoLayout openKind = this.OpenKind;
			if (openKind == EUILordInfoLayout.EnhanceInfo)
			{
				this.UpdateInfo(0, 0);
			}
			return;
		}
		case NetworkNews.Refresh_FontTextureRebuilt:
			this.Refresh_FontTexture();
			return;
		}
		switch (this.OpenKind)
		{
		case EUILordInfoLayout.LordSelf:
		case EUILordInfoLayout.RecordInfo:
		case EUILordInfoLayout.EnhanceInfo:
			this.UpdateInfo(0, 0);
			break;
		}
	}

	// Token: 0x06001E09 RID: 7689 RVA: 0x0038CAC8 File Offset: 0x0038ACC8
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond)
		{
			if (this.OpenKind == EUILordInfoLayout.EnhanceInfo && this.AGS_ScrollPanel.GetTopIdx() < this.lastUpdateIdx && this.scrollPanelInit)
			{
				this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeights, 515f, false);
			}
			if (this.OpenKind == EUILordInfoLayout.LordSelf)
			{
				RectTransform component;
				float num2;
				UIText component3;
				if (this.DM.beCaptured.nowCaptureStat != LoadCaptureState.None)
				{
					component = this.CaptureBar.GetChild(2).GetComponent<RectTransform>();
					long num = this.DM.beCaptured.StartActionTime + (long)((ulong)this.DM.beCaptured.TotalTime) - this.DM.ServerTime;
					if (num <= 0L)
					{
						num = 0L;
						if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Dead && !this.CaptureBar.GetChild(5).gameObject.activeInHierarchy && !this.freeRes)
						{
							this.UpdateInfo_MyLord();
							this.freeRes = true;
						}
					}
					else
					{
						this.freeRes = false;
					}
					if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Captured)
					{
						RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(8, 0);
						switch (this.DM.beCaptured.prisonerStat)
						{
						case PrisonerState.WaitForRelease:
						case PrisonerState.Poisoned:
							num2 = (float)num / this.DM.beCaptured.TotalTime;
							num2 = Mathf.Clamp01(1f - num2);
							component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 305f);
							this.AGS_Form.GetChild(17).GetChild(6).gameObject.SetActive(false);
							if (this.DM.beCaptured.prisonerStat == PrisonerState.Poisoned)
							{
								this.poisonUpdated = false;
							}
							this.AGS_Form.GetChild(17).GetChild(6).gameObject.SetActive(false);
							break;
						case PrisonerState.WaitForExecute:
							if (buildData.Level >= 17)
							{
								GameObject gameObject = this.AGS_Form.GetChild(17).GetChild(6).gameObject;
								gameObject.SetActive(true);
								Image component2 = gameObject.GetComponent<Image>();
								if (num >= 108000L)
								{
									component2.color = Color.white;
								}
								else
								{
									component2.color = Color.gray;
								}
							}
							else
							{
								this.AGS_Form.GetChild(17).GetChild(6).gameObject.SetActive(false);
							}
							if (num > 21600L)
							{
								num -= 21600L;
								num2 = (float)num / (this.DM.beCaptured.TotalTime - 21600u);
								num2 = Mathf.Clamp01(1f - num2);
								component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 305f);
								this.executeUpdated = false;
							}
							else
							{
								num2 = (float)num / 21600f;
								num2 = Mathf.Clamp01(1f - num2);
								component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 305f);
								this.AGS_Form.GetChild(17).GetChild(6).gameObject.SetActive(false);
								if (!this.executeUpdated)
								{
									this.UpdateInfo_MyLord();
									this.executeUpdated = true;
								}
							}
							break;
						}
					}
					else
					{
						num2 = (float)num / this.DM.beCaptured.TotalTime;
						num2 = Mathf.Clamp01(1f - num2);
						component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 305f);
						this.AGS_Form.GetChild(17).GetChild(6).gameObject.SetActive(false);
					}
					component3 = this.CaptureBar.GetChild(4).GetComponent<UIText>();
					this.countDown.ClearString();
					GameConstants.GetTimeString(this.countDown, (uint)num, true, true, true, false, true);
					component3.text = this.countDown.ToString();
					component3.SetAllDirty();
					component3.cachedTextGenerator.Invalidate();
					UIText component4 = this.CaptureBar.GetChild(3).GetComponent<UIText>();
					component4.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300f - component3.preferredWidth);
				}
				component = this.AGS_Form.GetChild(6).GetChild(2).GetComponent<RectTransform>();
				num2 = this.DM.RoleAttr.MonsterPoint / this.DM.GetMaxMonsterPoint();
				num2 = Mathf.Clamp01(num2);
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 261f);
				component3 = this.AGS_Form.GetChild(6).GetChild(7).GetComponent<UIText>();
				this.EnStr.ClearString();
				this.EnStr.IntToFormat((long)((ulong)this.DM.RoleAttr.MonsterPoint), 1, true);
				this.EnStr.IntToFormat((long)((ulong)this.DM.GetMaxMonsterPoint()), 1, true);
				if (!GUIManager.Instance.IsArabic)
				{
					this.EnStr.AppendFormat("{0} / {1}");
				}
				else
				{
					this.EnStr.AppendFormat("{1} / {0}");
				}
				component3.text = this.EnStr.ToString();
				component3.SetAllDirty();
				component3.cachedTextGenerator.Invalidate();
			}
			if (this.isMonsterOpen)
			{
				UIText component5 = this.HintPanel.GetChild(1).GetComponent<UIText>();
				this.hintString.ClearString();
				this.hintString.Append(this.DM.mStringTable.GetStringByID(880u));
				this.hintString.Append("\n");
				uint maxMonsterPoint = this.DM.GetMaxMonsterPoint();
				if (maxMonsterPoint > this.DM.RoleAttr.MonsterPoint)
				{
					if (this.MonsterTime == -1L)
					{
						this.MonsterTime = (long)((this.DM.GetMaxMonsterPoint() - this.DM.RoleAttr.MonsterPoint) * ((double)this.DM.RoleAttr.MonsterPointRecoverFrequency / 1000.0));
					}
					else
					{
						this.MonsterTime -= 1L;
					}
					int num3 = (int)this.MonsterTime / 3600;
					int num4 = (int)this.MonsterTime % 3600 / 60;
					int num5 = (int)this.MonsterTime % 60;
					this.hintString.IntToFormat((long)num3, 2, false);
					this.hintString.IntToFormat((long)num4, 2, false);
					this.hintString.IntToFormat((long)num5, 2, false);
					this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(881u));
				}
				else
				{
					this.hintString.Append(this.DM.mStringTable.GetStringByID(882u));
				}
				component5.text = this.hintString.ToString();
				component5.SetAllDirty();
				component5.cachedTextGenerator.Invalidate();
			}
		}
		else if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
		{
			RectTransform component6 = this.CaptureBar.GetChild(2).GetComponent<RectTransform>();
			double num6 = (double)(this.DM.beCaptured.StartActionTime + (long)((ulong)this.DM.beCaptured.TotalTime)) - NetworkManager.ServerTime;
			float num7 = (float)num6 / this.DM.beCaptured.TotalTime;
			num7 = Mathf.Clamp01(1f - num7);
			component6.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num7 * 305f);
		}
	}

	// Token: 0x06001E0A RID: 7690 RVA: 0x0038D20C File Offset: 0x0038B40C
	private void SetFormLayout(EUILordInfoLayout layout)
	{
		this.OpenKind = layout;
		RectTransform[] array = new RectTransform[8];
		for (int i = 0; i < 8; i++)
		{
			array[i] = this.AGS_Form.GetChild(5).GetChild(i).GetComponent<RectTransform>();
		}
		RectTransform[] array2 = new RectTransform[8];
		for (int j = 0; j < 8; j++)
		{
			array2[j] = this.AGS_Form.GetChild(5).GetChild(j + 8).GetComponent<RectTransform>();
		}
		this.PopupPanel.gameObject.SetActive(false);
		this.HintPanel.gameObject.SetActive(false);
		this.JailerPanel.gameObject.SetActive(false);
		this.RescurePanel.gameObject.SetActive(false);
		this.CaptureBar.gameObject.SetActive(false);
		this.AGS_Form.GetChild(8).gameObject.SetActive(false);
		switch (layout)
		{
		case EUILordInfoLayout.LordSelf:
		{
			this.headInfoPanel.gameObject.SetActive(true);
			this.SideBtnPanel.gameObject.SetActive(true);
			this.ItemPanel.gameObject.SetActive(true);
			this.ScrollPanel.gameObject.SetActive(false);
			this.TitlePanel.gameObject.SetActive(false);
			this.AGS_HeroBadge.gameObject.SetActive(false);
			this.HeroRank.gameObject.SetActive(false);
			this.Hero_Pos.gameObject.SetActive(false);
			this.AGS_GuildRank.gameObject.SetActive(false);
			this.AGS_Form.GetChild(20).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(7).gameObject.SetActive(true);
			this.AGS_Form.GetChild(7).gameObject.SetActive(true);
			this.AGS_Form.GetChild(6).gameObject.SetActive(true);
			this.AGS_bgPanel.SetSpriteIndex(0);
			this.AGS_GuildLogo.SetSpriteIndex(0);
			this.AGS_btn_BuffInfo.SetSpriteIndex(0);
			int[,] array3 = new int[,]
			{
				{
					0,
					52
				},
				{
					0,
					-60
				},
				{
					62,
					-172
				},
				{
					62,
					164
				},
				{
					210,
					164
				},
				{
					272,
					52
				},
				{
					272,
					-60
				},
				{
					210,
					-172
				}
			};
			int[,] array4 = new int[,]
			{
				{
					15,
					37
				},
				{
					15,
					-75
				},
				{
					77,
					-187
				},
				{
					77,
					149
				},
				{
					225,
					149
				},
				{
					287,
					37
				},
				{
					287,
					-75
				},
				{
					225,
					-187
				}
			};
			for (int k = 0; k < 8; k++)
			{
				Vector2 anchoredPosition = new Vector2((float)array3[k, 0], (float)array3[k, 1]);
				array[k].anchoredPosition = anchoredPosition;
				anchoredPosition = new Vector2((float)array4[k, 0], (float)array4[k, 1]) - new Vector2(-52.5f, 52.5f);
				array2[k].anchoredPosition = anchoredPosition;
				this.UILEBtn[k].anchoredPosition = anchoredPosition;
			}
			RectTransform component = this.AGS_Form.GetChild(7).GetComponent<RectTransform>();
			if (GUIManager.Instance.IsArabic)
			{
				component.anchoredPosition = new Vector2(-259f, 154f);
			}
			else
			{
				component.anchoredPosition = new Vector2(-318f, 154f);
			}
			this.TitlePanel.anchoredPosition = new Vector2(-150f, 0f);
			this.Hero_PosRT.anchoredPosition = new Vector2(-150f, -280f);
			this.LightRT.anchoredPosition = new Vector2(-150f, -280f);
			break;
		}
		case EUILordInfoLayout.LordOther:
		{
			this.headInfoPanel.gameObject.SetActive(true);
			this.SideBtnPanel.gameObject.SetActive(false);
			this.ItemPanel.gameObject.SetActive(true);
			this.ScrollPanel.gameObject.SetActive(false);
			this.TitlePanel.gameObject.SetActive(false);
			this.HeroRank.gameObject.SetActive(false);
			this.AGS_HeroBadge.gameObject.SetActive(false);
			this.Hero_Pos.gameObject.SetActive(false);
			this.AGS_GuildRank.gameObject.SetActive(false);
			this.AGS_Form.GetChild(20).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(3).gameObject.SetActive(false);
			this.AGS_Form.GetChild(2).GetChild(7).gameObject.SetActive(false);
			this.AGS_Form.GetChild(6).gameObject.SetActive(false);
			this.AGS_Form.GetChild(7).gameObject.SetActive(false);
			this.AGS_Form.GetChild(12).GetChild(0).gameObject.SetActive(true);
			this.AGS_Form.GetChild(12).GetChild(1).gameObject.SetActive(false);
			this.AGS_bgPanel.SetSpriteIndex(1);
			this.AGS_GuildLogo.SetSpriteIndex(0);
			this.AGS_btn_BuffInfo.SetSpriteIndex(0);
			int[,] array5 = new int[,]
			{
				{
					-388,
					52
				},
				{
					-388,
					-60
				},
				{
					-326,
					-172
				},
				{
					-326,
					164
				},
				{
					194,
					164
				},
				{
					256,
					52
				},
				{
					256,
					-60
				},
				{
					194,
					-172
				}
			};
			int[,] array6 = new int[,]
			{
				{
					-373,
					37
				},
				{
					-373,
					-75
				},
				{
					-311,
					-187
				},
				{
					-311,
					149
				},
				{
					209,
					149
				},
				{
					277,
					37
				},
				{
					277,
					-75
				},
				{
					209,
					-187
				}
			};
			for (int l = 0; l < 8; l++)
			{
				Vector2 anchoredPosition2 = new Vector2((float)array5[l, 0], (float)array5[l, 1]);
				array[l].anchoredPosition = anchoredPosition2;
				anchoredPosition2 = new Vector2((float)array6[l, 0], (float)array6[l, 1]) - new Vector2(-52.5f, 52.5f);
				array2[l].anchoredPosition = anchoredPosition2;
				this.UILEBtn[l].anchoredPosition = anchoredPosition2;
			}
			this.HeroRank.material = GUIManager.Instance.GetFrameMaterial();
			RectTransform component = this.AGS_Form.GetChild(7).GetComponent<RectTransform>();
			if (GUIManager.Instance.IsArabic)
			{
				component.anchoredPosition = new Vector2(-130f, 160f);
			}
			else
			{
				component.anchoredPosition = new Vector2(-189f, 160f);
			}
			this.TitlePanel.anchoredPosition = new Vector2(0f, 0f);
			this.Hero_PosRT.anchoredPosition = new Vector2(0f, -280f);
			this.LightRT.anchoredPosition = new Vector2(0f, -280f);
			break;
		}
		case EUILordInfoLayout.RecordInfo:
		{
			this.headInfoPanel.gameObject.SetActive(true);
			this.SideBtnPanel.gameObject.SetActive(false);
			this.ItemPanel.gameObject.SetActive(false);
			this.ScrollPanel.gameObject.SetActive(true);
			this.TitlePanel.gameObject.SetActive(false);
			this.Hero_Pos.gameObject.SetActive(false);
			this.HeroRank.gameObject.SetActive(false);
			this.AGS_HeroBadge.gameObject.SetActive(false);
			this.AGS_Form.GetChild(20).gameObject.SetActive(false);
			this.AGS_Form.GetChild(6).gameObject.SetActive(false);
			this.AGS_Form.GetChild(7).gameObject.SetActive(false);
			this.AGS_bgPanel.SetSpriteIndex(0);
			this.AGS_GuildLogo.SetSpriteIndex(0);
			this.AGS_btn_BuffInfo.SetSpriteIndex(1);
			RectTransform component = this.AGS_ScrollPanel.GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(-363f, 119f);
			this.ScrollPanel.GetChild(0).gameObject.SetActive(false);
			break;
		}
		case EUILordInfoLayout.RecordInfoOther:
		{
			this.headInfoPanel.gameObject.SetActive(true);
			this.SideBtnPanel.gameObject.SetActive(false);
			this.ItemPanel.gameObject.SetActive(false);
			this.ScrollPanel.gameObject.SetActive(true);
			this.TitlePanel.gameObject.SetActive(false);
			this.Hero_Pos.gameObject.SetActive(false);
			this.HeroRank.gameObject.SetActive(false);
			this.AGS_HeroBadge.gameObject.SetActive(false);
			this.AGS_Form.GetChild(20).gameObject.SetActive(false);
			this.AGS_Form.GetChild(6).gameObject.SetActive(false);
			this.AGS_Form.GetChild(7).gameObject.SetActive(false);
			this.AGS_bgPanel.SetSpriteIndex(1);
			this.AGS_btn_BuffInfo.SetSpriteIndex(1);
			RectTransform component = this.AGS_ScrollPanel.GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(-363f, 119f);
			this.Destory3DObject(false);
			break;
		}
		case EUILordInfoLayout.EnhanceInfo:
		{
			this.headInfoPanel.gameObject.SetActive(false);
			this.SideBtnPanel.gameObject.SetActive(false);
			this.ItemPanel.gameObject.SetActive(false);
			this.ScrollPanel.gameObject.SetActive(true);
			this.TitlePanel.gameObject.SetActive(false);
			this.HeroRank.gameObject.SetActive(false);
			this.AGS_HeroBadge.gameObject.SetActive(false);
			this.Hero_Pos.gameObject.SetActive(false);
			this.AGS_Form.GetChild(20).gameObject.SetActive(true);
			this.AGS_Form.GetChild(7).gameObject.SetActive(false);
			this.AGS_Form.GetChild(6).gameObject.SetActive(false);
			this.AGS_bgPanel.SetSpriteIndex(2);
			this.AGS_GuildLogo.SetSpriteIndex(0);
			RectTransform component = this.AGS_ScrollPanel.GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(-342f, 153f);
			break;
		}
		}
	}

	// Token: 0x06001E0B RID: 7691 RVA: 0x0038DBE4 File Offset: 0x0038BDE4
	public void UpdateInfo(int arg1 = 0, int arg2 = 0)
	{
		if (arg1 == 3)
		{
			EUILordInfoLayout openKind = this.OpenKind;
			if (openKind != EUILordInfoLayout.LordSelf)
			{
				if (openKind == EUILordInfoLayout.LordOther)
				{
					this.SetFormLayout(EUILordInfoLayout.RecordInfoOther);
				}
			}
			else
			{
				this.SetFormLayout(EUILordInfoLayout.RecordInfo);
			}
			this.UpdateInfo_Record();
			return;
		}
		switch (this.OpenKind)
		{
		case EUILordInfoLayout.LordSelf:
			this.UpdateInfo_MyLord();
			break;
		case EUILordInfoLayout.LordOther:
			if (arg1 != 0)
			{
				this.UpdateInfo_Other();
			}
			break;
		case EUILordInfoLayout.RecordInfo:
		case EUILordInfoLayout.RecordInfoOther:
			this.UpdateInfo_Record();
			break;
		case EUILordInfoLayout.EnhanceInfo:
			this.UpdateInfo_Enhance();
			break;
		}
	}

	// Token: 0x06001E0C RID: 7692 RVA: 0x0038DC8C File Offset: 0x0038BE8C
	private void UpdateInfo_MyLord()
	{
		if (this.DM.beCaptured.nowCaptureStat != LoadCaptureState.Captured && GUIManager.Instance.FindMenu(EGUIWindow.UI_JailMoney) != null)
		{
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_JailMoney);
		}
		this.UpdateInfo_MyHeader();
		this.AGS_Form.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(this.DM.RoleTalentPoint > 0);
		int heroKey = (int)this.DM.HeroTable.GetRecordByKey(this.DM.RoleAttr.Head).HeroKey;
		if (heroKey != (int)this.sHero.HeroKey)
		{
			this.sHero = this.DM.HeroTable.GetRecordByKey(this.DM.RoleAttr.Head);
			this.Create3DObjects();
		}
		else
		{
			this.Hero_Pos.gameObject.SetActive(true);
			this.SetModelDefaultAction();
			if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Captured)
			{
				if (this.LoadingStep == UILordInfo.eModelLoadingStep.HeroReady)
				{
					CString cstring = StringManager.Instance.StaticString1024();
					cstring.Append("Role/cage");
					this.bundle = AssetManager.GetAssetBundle(cstring, out this.AssetKey1);
					this.bundleRequest = this.bundle.LoadAsync("m", typeof(GameObject));
					this.LoadingStep = UILordInfo.eModelLoadingStep.WaitforCage;
				}
			}
			else if (this.Holder2 != null)
			{
				this.Destory3DObject(true);
			}
		}
		this.AGS_Form.GetChild(8).gameObject.SetActive(false);
		RectTransform component;
		UIText component3;
		switch (this.DM.beCaptured.nowCaptureStat)
		{
		case LoadCaptureState.None:
		{
			RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(8, 0);
			if (buildData.Level >= 20)
			{
				this.AGS_Form.GetChild(8).gameObject.SetActive(true);
			}
			if (buildData.Level >= 17)
			{
				this.AGS_Form.GetChild(3).GetChild(3).gameObject.SetActive(true);
				for (int i = 0; i < 3; i++)
				{
					component = this.AGS_Form.GetChild(3).GetChild(i).GetComponent<RectTransform>();
					component.anchoredPosition = new Vector2(-359f, 51.5f - (float)(i * 99));
				}
			}
			else
			{
				this.AGS_Form.GetChild(3).GetChild(3).gameObject.SetActive(false);
				for (int j = 0; j < 3; j++)
				{
					component = this.AGS_Form.GetChild(3).GetChild(j).GetComponent<RectTransform>();
					component.anchoredPosition = new Vector2(-359f, 9.5f - (float)(j * 118));
				}
			}
			this.ItemPanel.gameObject.SetActive(true);
			this.JailerPanel.gameObject.SetActive(false);
			this.RescurePanel.gameObject.SetActive(false);
			this.CaptureBar.gameObject.SetActive(false);
			this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
			this.AGS_Form.GetChild(3).GetChild(2).gameObject.SetActive(true);
			this.Hero_PosRT.anchoredPosition = new Vector2(-150f, -280f);
			this.Hero_PosRT.localEulerAngles = Vector3.zero;
			this.AGS_Form.GetChild(12).GetChild(0).gameObject.SetActive(true);
			this.AGS_Form.GetChild(12).GetChild(1).gameObject.SetActive(false);
			int num;
			for (int k = 0; k < 8; k++)
			{
				if (LordEquipData.RoleEquipSerial[k] != 0u)
				{
					this.AGS_Form.GetChild(5).GetChild(k + 8).gameObject.SetActive(false);
					this.UILEBtn[k].gameObject.SetActive(true);
					GUIManager.Instance.ChangeLordEquipImg(this.UILEBtn[k].transform, LordEquipData.RoleEquip[k], eLordEquipDisplayKind.Item_Gems, false);
					if (DataManager.Instance.EquipTable.GetRecordByKey(LordEquipData.RoleEquip[k].ItemID).TimedType != 0)
					{
						UILEBtn component2 = this.UILEBtn[k].transform.GetComponent<UILEBtn>();
						component2.SetCountdown(LordEquipData.getEquipTime(LordEquipData.RoleEquipSerial[k]), true);
					}
				}
				else
				{
					this.AGS_Form.GetChild(5).GetChild(k + 8).gameObject.SetActive(true);
					this.UILEBtn[k].gameObject.SetActive(false);
					num = LordEquipData.CheckHaveEquipKind((byte)(k + 21), true);
					if (num > 0)
					{
						this.AGS_Form.GetChild(5).GetChild(k + 8).GetChild(0).gameObject.SetActive(num == 1);
						this.AGS_Form.GetChild(5).GetChild(k + 8).GetChild(1).gameObject.SetActive(true);
						this.AGS_Form.GetChild(5).GetChild(k + 8).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(2 - num);
					}
					else
					{
						this.AGS_Form.GetChild(5).GetChild(k + 8).GetChild(0).gameObject.SetActive(false);
						this.AGS_Form.GetChild(5).GetChild(k + 8).GetChild(1).gameObject.SetActive(false);
					}
				}
			}
			num = LordEquipData.CheckHaveEquipKind(26, true);
			buildData = GUIManager.Instance.BuildingData.GetBuildData(15, 0);
			if (buildData.Level >= 17 && LordEquipData.RoleEquipSerial[6] == 0u)
			{
				this.AGS_Form.GetChild(5).GetChild(24).gameObject.SetActive(buildData.Level < 17);
				this.AGS_Form.GetChild(5).GetChild(14).GetChild(0).gameObject.SetActive(num == 1);
				this.AGS_Form.GetChild(5).GetChild(14).GetChild(1).gameObject.SetActive(num > 0);
				this.AGS_Form.GetChild(5).GetChild(14).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(2 - num);
			}
			else
			{
				this.AGS_Form.GetChild(5).GetChild(24).gameObject.SetActive(buildData.Level < 17);
				this.AGS_Form.GetChild(5).GetChild(14).GetChild(0).gameObject.SetActive(false);
				this.AGS_Form.GetChild(5).GetChild(14).GetChild(1).gameObject.SetActive(false);
			}
			if (buildData.Level >= 25 && LordEquipData.RoleEquipSerial[7] == 0u)
			{
				this.AGS_Form.GetChild(5).GetChild(25).gameObject.SetActive(buildData.Level < 25);
				this.AGS_Form.GetChild(5).GetChild(15).GetChild(0).gameObject.SetActive(num == 1);
				this.AGS_Form.GetChild(5).GetChild(15).GetChild(1).gameObject.SetActive(num > 0);
				this.AGS_Form.GetChild(5).GetChild(15).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(2 - num);
			}
			else
			{
				this.AGS_Form.GetChild(5).GetChild(25).gameObject.SetActive(buildData.Level < 25);
				this.AGS_Form.GetChild(5).GetChild(15).GetChild(0).gameObject.SetActive(false);
				this.AGS_Form.GetChild(5).GetChild(15).GetChild(1).gameObject.SetActive(false);
			}
			int num2 = 0;
			if (this.DM.RoleAttr.KingdomTitle > 1)
			{
				TitleData recordByKey = this.DM.TitleData.GetRecordByKey(this.DM.RoleAttr.KingdomTitle);
				this.TitlePanel.gameObject.SetActive(true);
				component3 = this.TitlePanel.GetChild(2 + num2 * 3).GetComponent<UIText>();
				component = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<RectTransform>();
				component3.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.StringID);
				component3.SetAllDirty();
				component3.cachedTextGenerator.Invalidate();
				component3.cachedTextGeneratorForLayout.Invalidate();
				float num3 = component3.preferredWidth / 2f + 35f;
				if (num3 > 140f)
				{
					num3 = 140f;
				}
				component.anchoredPosition = new Vector2(-num3, component.anchoredPosition.y);
				Image component4 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<Image>();
				component4.material = GUIManager.Instance.GetTitleMaterial();
				component4.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.KvkTitle);
				this.TitlePanel.GetChild(2 + num2 * 3).gameObject.SetActive(true);
				this.TitlePanel.GetChild(0 + num2 * 3).gameObject.SetActive(true);
				this.TitlePanel.GetChild(1 + num2 * 3).gameObject.SetActive(true);
				UIButton component5 = this.TitlePanel.GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>();
				component5.m_BtnID2 = 21;
				num2++;
			}
			if (this.DM.RoleAttr.NobilityTitle > 1)
			{
				TitleData recordByKey2 = this.DM.TitleDataF.GetRecordByKey(this.DM.RoleAttr.NobilityTitle);
				this.TitlePanel.gameObject.SetActive(true);
				component3 = this.TitlePanel.GetChild(2 + num2 * 3).GetComponent<UIText>();
				component = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<RectTransform>();
				component3.text = this.DM.mStringTable.GetStringByID((uint)recordByKey2.StringID);
				component3.SetAllDirty();
				component3.cachedTextGenerator.Invalidate();
				component3.cachedTextGeneratorForLayout.Invalidate();
				float num4 = component3.preferredWidth / 2f + 35f;
				if (num4 > 140f)
				{
					num4 = 140f;
				}
				component.anchoredPosition = new Vector2(-num4, component.anchoredPosition.y);
				Image component6 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<Image>();
				component6.material = GUIManager.Instance.GetTitleMaterial();
				component6.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey2.IconID, eTitleKind.NobilityTitle);
				this.TitlePanel.GetChild(2 + num2 * 3).gameObject.SetActive(true);
				this.TitlePanel.GetChild(0 + num2 * 3).gameObject.SetActive(true);
				this.TitlePanel.GetChild(1 + num2 * 3).gameObject.SetActive(true);
				UIButton component7 = this.TitlePanel.GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>();
				component7.m_BtnID2 = 22;
				num2++;
			}
			if (this.DM.RoleAttr.WorldTitle_Personal > 1)
			{
				TitleData recordByKey3 = this.DM.TitleDataW.GetRecordByKey(this.DM.RoleAttr.WorldTitle_Personal);
				this.TitlePanel.gameObject.SetActive(true);
				component3 = this.TitlePanel.GetChild(2 + num2 * 3).GetComponent<UIText>();
				component = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<RectTransform>();
				component3.text = this.DM.mStringTable.GetStringByID((uint)recordByKey3.StringID);
				component3.SetAllDirty();
				component3.cachedTextGenerator.Invalidate();
				component3.cachedTextGeneratorForLayout.Invalidate();
				float num5 = component3.preferredWidth / 2f + 35f;
				if (num5 > 140f)
				{
					num5 = 140f;
				}
				component.anchoredPosition = new Vector2(-num5, component.anchoredPosition.y);
				Image component8 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<Image>();
				component8.material = GUIManager.Instance.GetTitleMaterial();
				component8.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey3.IconID, eTitleKind.WorldTitle);
				this.TitlePanel.GetChild(2 + num2 * 3).gameObject.SetActive(true);
				this.TitlePanel.GetChild(0 + num2 * 3).gameObject.SetActive(true);
				this.TitlePanel.GetChild(1 + num2 * 3).gameObject.SetActive(true);
				UIButton component9 = this.TitlePanel.GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>();
				component9.m_BtnID2 = 23;
				num2++;
			}
			if (this.DM.RoleAttr.KingdomTitle == 1)
			{
				TitleData recordByKey4 = this.DM.TitleData.GetRecordByKey(this.DM.RoleAttr.KingdomTitle);
				this.TitlePanel.gameObject.SetActive(true);
				component3 = this.TitlePanel.GetChild(2 + num2 * 3).GetComponent<UIText>();
				component = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<RectTransform>();
				component3.text = this.DM.mStringTable.GetStringByID((uint)recordByKey4.StringID);
				component3.SetAllDirty();
				component3.cachedTextGenerator.Invalidate();
				component3.cachedTextGeneratorForLayout.Invalidate();
				float num6 = component3.preferredWidth / 2f + 35f;
				if (num6 > 140f)
				{
					num6 = 140f;
				}
				component.anchoredPosition = new Vector2(-num6, component.anchoredPosition.y);
				Image component10 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<Image>();
				component10.material = GUIManager.Instance.GetTitleMaterial();
				component10.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey4.IconID, eTitleKind.KvkTitle);
				this.TitlePanel.GetChild(2 + num2 * 3).gameObject.SetActive(true);
				this.TitlePanel.GetChild(0 + num2 * 3).gameObject.SetActive(true);
				this.TitlePanel.GetChild(1 + num2 * 3).gameObject.SetActive(true);
				UIButton component11 = this.TitlePanel.GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>();
				component11.m_BtnID2 = 21;
				num2++;
			}
			if (this.DM.RoleAttr.NobilityTitle == 1)
			{
				TitleData recordByKey5 = this.DM.TitleDataF.GetRecordByKey(this.DM.RoleAttr.NobilityTitle);
				this.TitlePanel.gameObject.SetActive(true);
				component3 = this.TitlePanel.GetChild(2 + num2 * 3).GetComponent<UIText>();
				component = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<RectTransform>();
				component3.text = this.DM.mStringTable.GetStringByID((uint)recordByKey5.StringID);
				component3.SetAllDirty();
				component3.cachedTextGenerator.Invalidate();
				component3.cachedTextGeneratorForLayout.Invalidate();
				float num7 = component3.preferredWidth / 2f + 35f;
				if (num7 > 140f)
				{
					num7 = 140f;
				}
				component.anchoredPosition = new Vector2(-num7, component.anchoredPosition.y);
				Image component12 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<Image>();
				component12.material = GUIManager.Instance.GetTitleMaterial();
				component12.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey5.IconID, eTitleKind.NobilityTitle);
				this.TitlePanel.GetChild(2 + num2 * 3).gameObject.SetActive(true);
				this.TitlePanel.GetChild(0 + num2 * 3).gameObject.SetActive(true);
				this.TitlePanel.GetChild(1 + num2 * 3).gameObject.SetActive(true);
				UIButton component13 = this.TitlePanel.GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>();
				component13.m_BtnID2 = 22;
				num2++;
			}
			if (this.DM.RoleAttr.WorldTitle_Personal == 1)
			{
				TitleData recordByKey6 = this.DM.TitleDataW.GetRecordByKey(this.DM.RoleAttr.WorldTitle_Personal);
				this.TitlePanel.gameObject.SetActive(true);
				component3 = this.TitlePanel.GetChild(2 + num2 * 3).GetComponent<UIText>();
				component = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<RectTransform>();
				component3.text = this.DM.mStringTable.GetStringByID((uint)recordByKey6.StringID);
				component3.SetAllDirty();
				component3.cachedTextGenerator.Invalidate();
				component3.cachedTextGeneratorForLayout.Invalidate();
				float num8 = component3.preferredWidth / 2f + 35f;
				if (num8 > 140f)
				{
					num8 = 140f;
				}
				component.anchoredPosition = new Vector2(-num8, component.anchoredPosition.y);
				Image component14 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<Image>();
				component14.material = GUIManager.Instance.GetTitleMaterial();
				component14.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey6.IconID, eTitleKind.WorldTitle);
				this.TitlePanel.GetChild(2 + num2 * 3).gameObject.SetActive(true);
				this.TitlePanel.GetChild(0 + num2 * 3).gameObject.SetActive(true);
				this.TitlePanel.GetChild(1 + num2 * 3).gameObject.SetActive(true);
				UIButton component15 = this.TitlePanel.GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>();
				component15.m_BtnID2 = 23;
				num2++;
			}
			if (this.TitlePanel.gameObject.activeInHierarchy)
			{
				for (int l = num2; l < 3; l++)
				{
					this.TitlePanel.GetChild(2 + l * 3).gameObject.SetActive(false);
					this.TitlePanel.GetChild(0 + l * 3).gameObject.SetActive(false);
					this.TitlePanel.GetChild(1 + l * 3).gameObject.SetActive(false);
				}
			}
			if (num2 == 0)
			{
				this.TitlePanel.gameObject.SetActive(false);
			}
			return;
		}
		case LoadCaptureState.Captured:
		{
			this.ItemPanel.gameObject.SetActive(false);
			this.JailerPanel.gameObject.SetActive(true);
			this.RescurePanel.gameObject.SetActive(false);
			this.CaptureBar.gameObject.SetActive(true);
			this.TitlePanel.gameObject.SetActive(false);
			this.CaptureBar.anchoredPosition = new Vector2(0f, -21f);
			this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(3).GetChild(2).gameObject.SetActive(false);
			this.Hero_PosRT.anchoredPosition = new Vector2(-150f, -280f);
			this.Hero_PosRT.localEulerAngles = Vector3.zero;
			this.LightRT.anchoredPosition = new Vector2(-150f, -280f);
			this.AGS_Form.GetChild(12).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(12).GetChild(1).gameObject.SetActive(true);
			this.JailerStr[0].ClearString();
			GameConstants.GetNameString(this.JailerStr[0], this.DM.beCaptured.HomeKingdomID, this.DM.beCaptured.name, this.DM.beCaptured.AlliTag, false);
			component3 = this.JailerPanel.GetChild(6).GetComponent<UIText>();
			component3.text = this.JailerStr[0].ToString();
			component3.SetAllDirty();
			component3.cachedTextGenerator.Invalidate();
			this.JailerStr[1].ClearString();
			GameConstants.GetKingdomXYString(this.JailerStr[1], this.DM.beCaptured.KingdomID, this.DM.beCaptured.MapID, false);
			component3 = this.JailerPanel.GetChild(7).GetComponent<UIText>();
			component3.text = this.JailerStr[1].ToString();
			component3.SetAllDirty();
			component3.cachedTextGenerator.Invalidate();
			this.JailerStr[2].ClearString();
			component3 = this.JailerPanel.GetChild(12).GetChild(0).GetComponent<UIText>();
			if (this.DM.beCaptured.Bounty > 0u)
			{
				this.JailerStr[2].IntToFormat((long)((ulong)this.DM.beCaptured.Bounty), 1, true);
				this.JailerStr[2].AppendFormat("{0:N}");
				component3.text = this.DM.mStringTable.GetStringByID(7777u);
			}
			else
			{
				this.JailerStr[2].Append(this.DM.mStringTable.GetStringByID(7786u));
				component3.text = this.DM.mStringTable.GetStringByID(7776u);
			}
			component3 = this.JailerPanel.GetChild(10).GetComponent<UIText>();
			component3.text = this.JailerStr[2].ToString();
			component3.SetAllDirty();
			component3.cachedTextGenerator.Invalidate();
			component3.cachedTextGeneratorForLayout.Invalidate();
			component = this.JailerPanel.GetChild(11).GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(component3.rectTransform.anchoredPosition.x - component3.preferredWidth - 40f, component.anchoredPosition.y);
			this.JailerStr[3].ClearString();
			if (this.DM.beCaptured.Ransom > 0u)
			{
				this.JailerStr[3].IntToFormat((long)((ulong)this.DM.beCaptured.Ransom), 1, true);
				this.JailerStr[3].AppendFormat("{0:N}");
				this.JailerPanel.GetChild(18).gameObject.SetActive(true);
				this.JailerPanel.GetChild(14).gameObject.SetActive(true);
				this.JailerPanel.GetChild(15).gameObject.SetActive(true);
				this.JailerPanel.GetChild(17).gameObject.SetActive(true);
				this.JailerPanel.GetChild(16).gameObject.SetActive(true);
			}
			else
			{
				this.JailerPanel.GetChild(18).gameObject.SetActive(false);
				this.JailerPanel.GetChild(14).gameObject.SetActive(false);
				this.JailerPanel.GetChild(15).gameObject.SetActive(false);
				this.JailerPanel.GetChild(17).gameObject.SetActive(false);
				this.JailerPanel.GetChild(16).gameObject.SetActive(false);
			}
			component3 = this.JailerPanel.GetChild(17).GetComponent<UIText>();
			component3.text = this.JailerStr[3].ToString();
			component3.SetAllDirty();
			component3.cachedTextGenerator.Invalidate();
			component3.cachedTextGeneratorForLayout.Invalidate();
			component = this.JailerPanel.GetChild(16).GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(component3.rectTransform.anchoredPosition.x - component3.preferredWidth - 40f, component.anchoredPosition.y);
			Transform child = this.JailerPanel.GetChild(2);
			GUIManager.Instance.InitianHeroItemImg(child, eHeroOrItem.Hero, this.DM.beCaptured.head, 11, 0, 0, false, false, true, false);
			this.DefaultActionLateUpdate = true;
			break;
		}
		case LoadCaptureState.Returning:
			this.ItemPanel.gameObject.SetActive(false);
			this.JailerPanel.gameObject.SetActive(false);
			this.RescurePanel.gameObject.SetActive(false);
			this.CaptureBar.gameObject.SetActive(true);
			this.CaptureBar.anchoredPosition = new Vector2(158f, -338f);
			this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(3).GetChild(2).gameObject.SetActive(false);
			this.Hero_PosRT.anchoredPosition = new Vector2(0f, -280f);
			this.Hero_PosRT.localEulerAngles = Vector3.zero;
			this.LightRT.anchoredPosition = new Vector2(0f, -280f);
			this.AGS_Form.GetChild(12).GetChild(0).gameObject.SetActive(true);
			this.AGS_Form.GetChild(12).GetChild(1).gameObject.SetActive(false);
			break;
		case LoadCaptureState.Dead:
			this.ItemPanel.gameObject.SetActive(false);
			this.JailerPanel.gameObject.SetActive(false);
			this.RescurePanel.gameObject.SetActive(true);
			this.CaptureBar.gameObject.SetActive(true);
			this.CaptureBar.anchoredPosition = new Vector2(80f, -338f);
			this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(3).GetChild(2).gameObject.SetActive(false);
			this.Hero_PosRT.anchoredPosition = new Vector2(0f, -100f);
			this.Hero_PosRT.localEulerAngles = new Vector3(320f, 0f, 0f);
			this.LightRT.anchoredPosition = new Vector2(0f, -100f);
			this.AGS_Form.GetChild(12).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(12).GetChild(1).gameObject.SetActive(true);
			this.DefaultActionLateUpdate = true;
			break;
		}
		this.CaptureBar.GetChild(4).gameObject.SetActive(true);
		this.CaptureBar.GetChild(3).gameObject.SetActive(true);
		this.CaptureBar.GetChild(6).gameObject.SetActive(false);
		UISpritesArray component16 = this.CaptureBar.GetChild(2).GetComponent<UISpritesArray>();
		component3 = this.CaptureBar.GetChild(3).GetComponent<UIText>();
		long num9 = this.DM.beCaptured.StartActionTime + (long)((ulong)this.DM.beCaptured.TotalTime) - this.DM.ServerTime;
		component = this.CaptureBar.GetChild(2).GetComponent<RectTransform>();
		switch (this.DM.beCaptured.nowCaptureStat)
		{
		case LoadCaptureState.Captured:
			switch (this.DM.beCaptured.prisonerStat)
			{
			case PrisonerState.WaitForRelease:
			{
				component16.SetSpriteIndex(0);
				this.CaptureBar.GetChild(0).gameObject.SetActive(false);
				component3.text = this.DM.mStringTable.GetStringByID(7768u);
				float num10 = 1f - (float)num9 / this.DM.beCaptured.TotalTime;
				num10 = Mathf.Clamp01(num10);
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num10 * 305f);
				break;
			}
			case PrisonerState.WaitForExecute:
				if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 17 && num9 > 108000L)
				{
					GameObject gameObject = this.AGS_Form.GetChild(17).GetChild(6).gameObject;
					gameObject.SetActive(true);
					Image component17 = gameObject.GetComponent<Image>();
					if (num9 >= 108000L)
					{
						component17.color = Color.white;
					}
					else
					{
						component17.color = Color.gray;
					}
				}
				else
				{
					this.AGS_Form.GetChild(17).GetChild(6).gameObject.SetActive(false);
				}
				if (num9 > 21600L)
				{
					component16.SetSpriteIndex(0);
					this.CaptureBar.GetChild(0).gameObject.SetActive(false);
					component3.text = this.DM.mStringTable.GetStringByID(7759u);
					float num10 = (float)(num9 - 21600L) / (this.DM.beCaptured.TotalTime - 21600u);
					num10 = Mathf.Clamp01(1f - num10);
					component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num10 * 305f);
					this.executeUpdated = false;
				}
				else
				{
					component16.SetSpriteIndex(0);
					this.CaptureBar.GetChild(0).gameObject.SetActive(true);
					component16 = this.CaptureBar.GetChild(0).GetComponent<UISpritesArray>();
					component16.SetSpriteIndex(0);
					component3.text = this.DM.mStringTable.GetStringByID(7758u);
					float num10 = (float)num9 / 21600f;
					num10 = Mathf.Clamp01(1f - num10);
					component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num10 * 305f);
				}
				break;
			case PrisonerState.Poisoned:
			{
				component16.SetSpriteIndex(1);
				this.CaptureBar.GetChild(0).gameObject.SetActive(true);
				component16 = this.CaptureBar.GetChild(0).GetComponent<UISpritesArray>();
				component16.SetSpriteIndex(1);
				component3.text = this.DM.mStringTable.GetStringByID(15008u);
				float num10 = 1f - (float)num9 / this.DM.beCaptured.TotalTime;
				num10 = Mathf.Clamp01(num10);
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num10 * 305f);
				if (num9 > 108000L)
				{
					this.poisonUpdated = false;
				}
				else if (!this.poisonUpdated)
				{
					this.poisonUpdated = true;
					GUIManager.Instance.CloseMenu(EGUIWindow.UI_SuicideBox);
				}
				break;
			}
			}
			break;
		case LoadCaptureState.Returning:
		{
			component16.SetSpriteIndex(0);
			this.CaptureBar.GetChild(0).gameObject.SetActive(false);
			component3.text = this.DM.mStringTable.GetStringByID(7787u);
			float num10 = (float)num9 / this.DM.beCaptured.TotalTime;
			num10 = Mathf.Clamp01(1f - num10);
			component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num10 * 305f);
			break;
		}
		case LoadCaptureState.Dead:
			component16.SetSpriteIndex(0);
			this.CaptureBar.GetChild(0).gameObject.SetActive(false);
			component3.text = this.DM.mStringTable.GetStringByID(7784u);
			component3 = this.RescurePanel.GetChild(0).GetChild(0).GetComponent<UIText>();
			if (num9 <= 0L)
			{
				component3.text = this.DM.mStringTable.GetStringByID(7788u);
				this.CaptureBar.GetChild(5).gameObject.SetActive(true);
				this.CaptureBar.GetChild(4).gameObject.SetActive(false);
				this.CaptureBar.GetChild(3).gameObject.SetActive(false);
			}
			else
			{
				component3.text = this.DM.mStringTable.GetStringByID(7785u);
				this.CaptureBar.GetChild(5).gameObject.SetActive(false);
				float num10 = (float)num9 / this.DM.beCaptured.TotalTime;
				num10 = Mathf.Clamp01(1f - num10);
				component.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num10 * 305f);
			}
			break;
		}
		component3.SetAllDirty();
		component3.cachedTextGenerator.Invalidate();
		component3 = this.CaptureBar.GetChild(4).GetComponent<UIText>();
		this.countDown.ClearString();
		GameConstants.GetTimeString(this.countDown, (uint)num9, true, true, true, false, true);
		component3.text = this.countDown.ToString();
		component3.SetAllDirty();
		component3.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001E0D RID: 7693 RVA: 0x0038FDC4 File Offset: 0x0038DFC4
	private void UpdateInfo_Other()
	{
		StringBuilder stringBuilder = new StringBuilder();
		this.isSameAlli = false;
		this.AGS_HeroBadge.gameObject.SetActive(true);
		this.AGS_Form.GetChild(7).gameObject.SetActive(true);
		stringBuilder.Length = 0;
		float num = 0f;
		UIText component = this.AGS_Form.GetChild(2).GetChild(11).GetComponent<UIText>();
		stringBuilder.Length = 0;
		stringBuilder.AppendFormat("{0:N0}", this.DM.GetVIPLevel(this.DM.mLordProfile.VipPoint));
		component.text = stringBuilder.ToString();
		component = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
		if (DataManager.MapDataController.kingdomData.kingdomID != this.DM.mLordProfile.KindomID)
		{
			component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 390f);
			num -= 50f;
			this.AGS_Form.GetChild(2).GetChild(15).gameObject.SetActive(true);
		}
		else
		{
			this.AGS_Form.GetChild(2).GetChild(15).gameObject.SetActive(false);
		}
		RectTransform component2;
		Vector2 vector;
		if (this.DM.mLordProfile.AllianceTag != null && this.DM.mLordProfile.AllianceTag.Length > 0 && this.DM.mLordProfile.AlliID != 0u)
		{
			this.AGS_GuildRank.gameObject.SetActive(true);
			this.AGS_GuildRank.SetSpriteIndex((int)this.DM.mLordProfile.AlliRank);
			component2 = this.AGS_GuildRank.GetComponent<RectTransform>();
			vector = component2.anchoredPosition;
			vector.x = -285f;
			component2.anchoredPosition = vector;
			if (this.DM.RoleAlliance.Id == this.DM.mLordProfile.AlliID)
			{
				if (DataManager.CompareStr(this.DM.RoleAttr.Name, this.DM.mLordProfile.PlayerName) != 0)
				{
					this.isSameAlli = true;
				}
				else
				{
					this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(false);
				}
			}
			if (this.isSameAlli && this.DM.CheckPrizeFlag(9))
			{
				this.AGS_GuildLogo.SetSpriteIndex(1);
				component2 = this.AGS_GuildLogo.GetComponent<RectTransform>();
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 55f);
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 59f);
				component2.pivot = new Vector2(0.5f, 0.5f);
				component2.anchoredPosition = Vector2.zero;
			}
			this.AGS_Form.GetChild(2).GetChild(7).gameObject.SetActive(true);
		}
		else
		{
			this.AGS_GuildRank.gameObject.SetActive(false);
			if (DataManager.MapDataController.kingdomData.kingdomID == this.DM.mLordProfile.KindomID)
			{
				num += 45f;
			}
			this.AGS_Form.GetChild(2).GetChild(7).gameObject.SetActive(false);
		}
		this.Header_NameText.ClearString();
		if (DataManager.MapDataController.kingdomData.kingdomID != this.DM.mLordProfile.KindomID)
		{
			GameConstants.FormatRoleName(this.Header_NameText, this.DM.mLordProfile.PlayerName, this.DM.mLordProfile.AllianceTag, null, 0, this.DM.mLordProfile.KindomID, "<color=#B7D963FF>", null, null, null);
		}
		else
		{
			GameConstants.FormatRoleName(this.Header_NameText, this.DM.mLordProfile.PlayerName, this.DM.mLordProfile.AllianceTag, null, 0, 0, null, null, null, null);
		}
		component.text = this.Header_NameText.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component2 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<RectTransform>();
		vector = component2.anchoredPosition;
		vector.x = -240f - num;
		vector = component.ArabicFixPos(vector);
		component2.anchoredPosition = vector;
		component = this.AGS_Form.GetChild(2).GetChild(5).GetComponent<UIText>();
		stringBuilder.Length = 0;
		stringBuilder.AppendFormat("{0:N0}", this.DM.mLordProfile.Power);
		component.text = stringBuilder.ToString();
		component = this.AGS_Form.GetChild(2).GetChild(6).GetComponent<UIText>();
		stringBuilder.Length = 0;
		stringBuilder.AppendFormat("{0:N0}", this.DM.mLordProfile.Kills);
		component.text = stringBuilder.ToString();
		component = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
		stringBuilder.Length = 0;
		stringBuilder.AppendFormat("{0:N0}", this.DM.mLordProfile.Level);
		component.text = stringBuilder.ToString();
		if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 25)
		{
			this.AGS_Form.GetChild(7).GetChild(1).gameObject.SetActive(true);
			component = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetComponent<UIText>();
			stringBuilder.Length = 0;
			stringBuilder.AppendFormat("{0:N0}", this.DM.mLordProfile.TotalCastleStar);
			component.text = stringBuilder.ToString();
		}
		this.Hero_Pos.gameObject.SetActive(true);
		int heroKey = (int)this.DM.HeroTable.GetRecordByKey(this.DM.mLordProfile.Head).HeroKey;
		if (heroKey != (int)this.sHero.HeroKey || this.Holder1 == null)
		{
			this.sHero = this.DM.HeroTable.GetRecordByKey(this.DM.mLordProfile.Head);
			this.Create3DObjects();
		}
		this.HeroRank.sprite = GUIManager.Instance.LoadFrameSprite(EFrameSprite.Hero, this.DM.mLordProfile.Enhance + 100);
		this.HeroRank.gameObject.SetActive(true);
		if (this.DM.mLordProfile.Star > 0)
		{
			this.AGS_HeroBadge.SetSpriteIndex((int)(this.DM.mLordProfile.Star - 1));
		}
		for (int i = 0; i < 8; i++)
		{
			if (this.DM.mLordProfile.Equips[i].ItemID != 0)
			{
				this.AGS_Form.GetChild(5).GetChild(i + 8).gameObject.SetActive(false);
				this.UILEBtn[i].gameObject.SetActive(true);
				GUIManager.Instance.ChangeLordEquipImg(this.UILEBtn[i].transform, this.DM.mLordProfile.Equips[i].ItemID, this.DM.mLordProfile.Equips[i].color, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				UIButtonHint component3 = this.AGS_Form.GetChild(5).GetChild(i + 8).GetComponent<UIButtonHint>();
				component3.m_Handler = this;
				component3.Parm2 = 1;
				if (this.DM.mLordProfile.Equips[i].ItemID == 4999)
				{
					component3.Parm1 = 11252;
					this.AGS_Form.GetChild(5).GetChild(i + 8).gameObject.SetActive(true);
					this.AGS_Form.GetChild(5).GetChild(i).gameObject.SetActive(false);
					this.UILEBtn[i].gameObject.SetActive(false);
					if (this.ParticleGO[i] == null)
					{
						this.ParticleGO[i] = ParticleManager.Instance.Spawn(454, this.AGS_Form.GetChild(5).GetChild(i + 8), Vector3.zero, 1f, true, true, true);
						if (this.ParticleGO[i] != null)
						{
							this.ModifyParticle(this.ParticleGO[i]);
						}
						GUIManager.Instance.SetLayer(this.ParticleGO[i], 5);
					}
					Image component4 = this.AGS_Form.GetChild(5).GetChild(i + 8).GetComponent<Image>();
					component4.color = new Color(0f, 0f, 0f, 0f);
				}
				else
				{
					component3.Parm1 = 0;
				}
			}
			else
			{
				this.AGS_Form.GetChild(5).GetChild(i + 8).gameObject.SetActive(true);
				this.UILEBtn[i].gameObject.SetActive(false);
			}
		}
		this.AGS_Form.GetChild(5).GetChild(24).gameObject.SetActive(false);
		this.AGS_Form.GetChild(5).GetChild(25).gameObject.SetActive(false);
		int num2 = 0;
		if (this.DM.mLordProfile.Title > 1)
		{
			TitleData recordByKey = this.DM.TitleData.GetRecordByKey(this.DM.mLordProfile.Title);
			this.TitlePanel.gameObject.SetActive(true);
			component = this.TitlePanel.GetChild(2 + num2 * 3).GetComponent<UIText>();
			component2 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<RectTransform>();
			component.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.StringID);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component.cachedTextGeneratorForLayout.Invalidate();
			float num3 = component.preferredWidth / 2f + 35f;
			if (num3 > 140f)
			{
				num3 = 140f;
			}
			component2.anchoredPosition = new Vector2(-num3, component2.anchoredPosition.y);
			Image component5 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<Image>();
			component5.material = GUIManager.Instance.GetTitleMaterial();
			component5.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.KvkTitle);
			this.TitlePanel.GetChild(2 + num2 * 3).gameObject.SetActive(true);
			this.TitlePanel.GetChild(0 + num2 * 3).gameObject.SetActive(true);
			this.TitlePanel.GetChild(1 + num2 * 3).gameObject.SetActive(true);
			UIButton component6 = this.TitlePanel.GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>();
			component6.m_BtnID2 = 21;
			num2++;
		}
		if (this.DM.mLordProfile.NobilityTitle > 1)
		{
			TitleData recordByKey2 = this.DM.TitleDataF.GetRecordByKey(this.DM.mLordProfile.NobilityTitle);
			this.TitlePanel.gameObject.SetActive(true);
			component = this.TitlePanel.GetChild(2 + num2 * 3).GetComponent<UIText>();
			component2 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<RectTransform>();
			component.text = this.DM.mStringTable.GetStringByID((uint)recordByKey2.StringID);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component.cachedTextGeneratorForLayout.Invalidate();
			float num4 = component.preferredWidth / 2f + 35f;
			if (num4 > 140f)
			{
				num4 = 140f;
			}
			component2.anchoredPosition = new Vector2(-num4, component2.anchoredPosition.y);
			Image component7 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<Image>();
			component7.material = GUIManager.Instance.GetTitleMaterial();
			component7.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey2.IconID, eTitleKind.NobilityTitle);
			this.TitlePanel.GetChild(2 + num2 * 3).gameObject.SetActive(true);
			this.TitlePanel.GetChild(0 + num2 * 3).gameObject.SetActive(true);
			this.TitlePanel.GetChild(1 + num2 * 3).gameObject.SetActive(true);
			UIButton component8 = this.TitlePanel.GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>();
			component8.m_BtnID2 = 22;
			num2++;
		}
		if (this.DM.mLordProfile.WorldTitle > 1)
		{
			TitleData recordByKey3 = this.DM.TitleDataW.GetRecordByKey(this.DM.mLordProfile.WorldTitle);
			this.TitlePanel.gameObject.SetActive(true);
			component = this.TitlePanel.GetChild(2 + num2 * 3).GetComponent<UIText>();
			component2 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<RectTransform>();
			component.text = this.DM.mStringTable.GetStringByID((uint)recordByKey3.StringID);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component.cachedTextGeneratorForLayout.Invalidate();
			float num5 = component.preferredWidth / 2f + 35f;
			if (num5 > 140f)
			{
				num5 = 140f;
			}
			component2.anchoredPosition = new Vector2(-num5, component2.anchoredPosition.y);
			Image component9 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<Image>();
			component9.material = GUIManager.Instance.GetTitleMaterial();
			component9.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey3.IconID, eTitleKind.WorldTitle);
			this.TitlePanel.GetChild(2 + num2 * 3).gameObject.SetActive(true);
			this.TitlePanel.GetChild(0 + num2 * 3).gameObject.SetActive(true);
			this.TitlePanel.GetChild(1 + num2 * 3).gameObject.SetActive(true);
			UIButton component10 = this.TitlePanel.GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>();
			component10.m_BtnID2 = 23;
			num2++;
		}
		if (this.DM.mLordProfile.Title == 1)
		{
			TitleData recordByKey4 = this.DM.TitleData.GetRecordByKey(this.DM.mLordProfile.Title);
			this.TitlePanel.gameObject.SetActive(true);
			component = this.TitlePanel.GetChild(2 + num2 * 3).GetComponent<UIText>();
			component2 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<RectTransform>();
			component.text = this.DM.mStringTable.GetStringByID((uint)recordByKey4.StringID);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component.cachedTextGeneratorForLayout.Invalidate();
			float num6 = component.preferredWidth / 2f + 35f;
			if (num6 > 140f)
			{
				num6 = 140f;
			}
			component2.anchoredPosition = new Vector2(-num6, component2.anchoredPosition.y);
			Image component11 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<Image>();
			component11.material = GUIManager.Instance.GetTitleMaterial();
			component11.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey4.IconID, eTitleKind.KvkTitle);
			this.TitlePanel.GetChild(2 + num2 * 3).gameObject.SetActive(true);
			this.TitlePanel.GetChild(0 + num2 * 3).gameObject.SetActive(true);
			this.TitlePanel.GetChild(1 + num2 * 3).gameObject.SetActive(true);
			UIButton component12 = this.TitlePanel.GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>();
			component12.m_BtnID2 = 21;
			num2++;
		}
		if (this.DM.mLordProfile.NobilityTitle == 1)
		{
			TitleData recordByKey5 = this.DM.TitleDataF.GetRecordByKey(this.DM.mLordProfile.NobilityTitle);
			this.TitlePanel.gameObject.SetActive(true);
			component = this.TitlePanel.GetChild(2 + num2 * 3).GetComponent<UIText>();
			component2 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<RectTransform>();
			component.text = this.DM.mStringTable.GetStringByID((uint)recordByKey5.StringID);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component.cachedTextGeneratorForLayout.Invalidate();
			float num7 = component.preferredWidth / 2f + 35f;
			if (num7 > 140f)
			{
				num7 = 140f;
			}
			component2.anchoredPosition = new Vector2(-num7, component2.anchoredPosition.y);
			Image component13 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<Image>();
			component13.material = GUIManager.Instance.GetTitleMaterial();
			component13.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey5.IconID, eTitleKind.NobilityTitle);
			this.TitlePanel.GetChild(2 + num2 * 3).gameObject.SetActive(true);
			this.TitlePanel.GetChild(0 + num2 * 3).gameObject.SetActive(true);
			this.TitlePanel.GetChild(1 + num2 * 3).gameObject.SetActive(true);
			UIButton component14 = this.TitlePanel.GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>();
			component14.m_BtnID2 = 22;
			num2++;
		}
		if (this.DM.mLordProfile.WorldTitle == 1)
		{
			TitleData recordByKey6 = this.DM.TitleDataW.GetRecordByKey(this.DM.mLordProfile.WorldTitle);
			this.TitlePanel.gameObject.SetActive(true);
			component = this.TitlePanel.GetChild(2 + num2 * 3).GetComponent<UIText>();
			component2 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<RectTransform>();
			component.text = this.DM.mStringTable.GetStringByID((uint)recordByKey6.StringID);
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component.cachedTextGeneratorForLayout.Invalidate();
			float num8 = component.preferredWidth / 2f + 35f;
			if (num8 > 140f)
			{
				num8 = 140f;
			}
			component2.anchoredPosition = new Vector2(-num8, component2.anchoredPosition.y);
			Image component15 = this.TitlePanel.GetChild(1 + num2 * 3).GetComponent<Image>();
			component15.material = GUIManager.Instance.GetTitleMaterial();
			component15.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey6.IconID, eTitleKind.WorldTitle);
			this.TitlePanel.GetChild(2 + num2 * 3).gameObject.SetActive(true);
			this.TitlePanel.GetChild(0 + num2 * 3).gameObject.SetActive(true);
			this.TitlePanel.GetChild(1 + num2 * 3).gameObject.SetActive(true);
			UIButton component16 = this.TitlePanel.GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>();
			component16.m_BtnID2 = 23;
			num2++;
		}
		if (this.TitlePanel.gameObject.activeInHierarchy)
		{
			for (int j = num2; j < 3; j++)
			{
				this.TitlePanel.GetChild(2 + j * 3).gameObject.SetActive(false);
				this.TitlePanel.GetChild(0 + j * 3).gameObject.SetActive(false);
				this.TitlePanel.GetChild(1 + j * 3).gameObject.SetActive(false);
			}
		}
		if (num2 == 0)
		{
			this.TitlePanel.gameObject.SetActive(false);
		}
		GUIManager.Instance.HideUILock(EUILock.LordInfo);
	}

	// Token: 0x06001E0E RID: 7694 RVA: 0x00391220 File Offset: 0x0038F420
	private void ModifyParticle(GameObject go)
	{
		ParticleSystem[] componentsInChildren = go.GetComponentsInChildren<ParticleSystem>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].name == "BSMOKE")
			{
				if (this.mat_AlphaBlend_back == null)
				{
					this.mat_AlphaBlend_back = new Material(componentsInChildren[i].renderer.material);
					this.mat_AlphaBlend_back.renderQueue = 3000;
				}
				componentsInChildren[i].renderer.material = this.mat_AlphaBlend_back;
			}
			else if (componentsInChildren[i].name == "BDragonSB")
			{
				if (this.mat_AlphaBlend_front == null)
				{
					this.mat_AlphaBlend_front = new Material(componentsInChildren[i].renderer.material);
					this.mat_AlphaBlend_front.renderQueue = 3050;
				}
				componentsInChildren[i].renderer.material = this.mat_AlphaBlend_front;
			}
			else if (componentsInChildren[i].name == "SMOKE" || componentsInChildren[i].name == "STAR03")
			{
				if (this.mat_Additive == null)
				{
					this.mat_Additive = new Material(componentsInChildren[i].renderer.material);
					this.mat_Additive.renderQueue = 3020;
				}
				componentsInChildren[i].renderer.material = this.mat_Additive;
			}
		}
	}

	// Token: 0x06001E0F RID: 7695 RVA: 0x00391394 File Offset: 0x0038F594
	private void UpdateInfo_Record()
	{
		if (this.OpenKind == EUILordInfoLayout.RecordInfo)
		{
			this.UpdateInfo_MyHeader();
		}
		this.AGS_ScrollPanel.gameObject.SetActive(true);
		if (!this.scrollPanelInit)
		{
			this.scrollPanelInit = true;
			this.SPHeights = new List<float>();
			this.AGS_ScrollPanel.IntiScrollPanel(481f, 0f, 0f, this.SPHeights, 18, this);
			UIButtonHint.scrollRect2 = this.AGS_ScrollPanel.GetComponent<CScrollRect>();
		}
		if (this.EnhanceShowedIdx == null)
		{
			this.EnhanceShowedIdx = new List<int>();
		}
		this.EnhanceShowedIdx.Clear();
		this.SPHeights.Clear();
		ushort num;
		if (this.OpenKind == EUILordInfoLayout.RecordInfo)
		{
			num = this.DM.RoleAttr.WorldTitle_Personal;
		}
		else
		{
			num = this.DM.mLordProfile.WorldTitle;
		}
		if (num == 1)
		{
			this.EnhanceShowedIdx.Add(10001);
			TitleData recordByKey = this.DM.TitleDataW.GetRecordByKey(num);
			int num2 = 0;
			for (int i = 0; i < 3; i++)
			{
				if (recordByKey.Effects[i].EffectID != 0)
				{
					if (this.TitleSPItemText.Length > 0)
					{
						this.TitleSPItemText.Append("\n");
					}
					if (this.DM.EffectData.GetRecordByKey(recordByKey.Effects[i].EffectID).ID > 0)
					{
						num2++;
					}
				}
			}
			if (num2 > 2)
			{
				this.TitleSPItem2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140f);
				this.TitleSPItem2.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140f);
				this.TitleSPItem2.GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 90f);
				this.SPHeights.Add(143f);
			}
			else
			{
				this.TitleSPItem2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110f);
				this.TitleSPItem2.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110f);
				this.TitleSPItem2.GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 60f);
				this.SPHeights.Add(113f);
			}
		}
		if (this.OpenKind == EUILordInfoLayout.RecordInfo)
		{
			num = this.DM.RoleAttr.NobilityTitle;
		}
		else
		{
			num = this.DM.mLordProfile.NobilityTitle;
		}
		if (num == 1)
		{
			this.EnhanceShowedIdx.Add(10002);
			TitleData recordByKey2 = this.DM.TitleDataF.GetRecordByKey(num);
			int num3 = 0;
			for (int j = 0; j < 3; j++)
			{
				if (recordByKey2.Effects[j].EffectID != 0)
				{
					if (this.TitleSPItemText3.Length > 0)
					{
						this.TitleSPItemText3.Append("\n");
					}
					if (this.DM.EffectData.GetRecordByKey(recordByKey2.Effects[j].EffectID).ID > 0)
					{
						num3++;
					}
				}
			}
			if (num3 > 2)
			{
				this.TitleSPItem3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140f);
				this.TitleSPItem3.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140f);
				this.TitleSPItem3.GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 90f);
				this.SPHeights.Add(143f);
			}
			else
			{
				this.TitleSPItem3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110f);
				this.TitleSPItem3.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110f);
				this.TitleSPItem3.GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 60f);
				this.SPHeights.Add(113f);
			}
		}
		if (this.OpenKind == EUILordInfoLayout.RecordInfo)
		{
			num = this.DM.RoleAttr.KingdomTitle;
		}
		else
		{
			num = this.DM.mLordProfile.Title;
		}
		if (num == 1)
		{
			this.EnhanceShowedIdx.Add(10000);
			if (num == 1)
			{
				this.TitleSPItem.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140f);
				this.TitleSPItem.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140f);
				this.TitleSPItem.GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 90f);
				this.SPHeights.Add(143f);
			}
			else
			{
				this.TitleSPItem.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110f);
				this.TitleSPItem.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110f);
				this.TitleSPItem.GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 60f);
				this.SPHeights.Add(113f);
			}
		}
		if (this.OpenKind == EUILordInfoLayout.RecordInfo)
		{
			num = this.DM.RoleAttr.WorldTitle_Personal;
		}
		else
		{
			num = this.DM.mLordProfile.WorldTitle;
		}
		if (num > 1)
		{
			this.EnhanceShowedIdx.Add(10001);
			TitleData recordByKey3 = this.DM.TitleDataW.GetRecordByKey(num);
			int num4 = 0;
			for (int k = 0; k < 3; k++)
			{
				if (recordByKey3.Effects[k].EffectID != 0)
				{
					if (this.TitleSPItemText.Length > 0)
					{
						this.TitleSPItemText.Append("\n");
					}
					if (this.DM.EffectData.GetRecordByKey(recordByKey3.Effects[k].EffectID).ID > 0)
					{
						num4++;
					}
				}
			}
			if (num4 > 2)
			{
				this.TitleSPItem2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140f);
				this.TitleSPItem2.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140f);
				this.TitleSPItem2.GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 90f);
				this.SPHeights.Add(143f);
			}
			else
			{
				this.TitleSPItem2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110f);
				this.TitleSPItem2.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110f);
				this.TitleSPItem2.GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 60f);
				this.SPHeights.Add(113f);
			}
		}
		if (this.OpenKind == EUILordInfoLayout.RecordInfo)
		{
			num = this.DM.RoleAttr.NobilityTitle;
		}
		else
		{
			num = this.DM.mLordProfile.NobilityTitle;
		}
		if (num > 1)
		{
			this.EnhanceShowedIdx.Add(10002);
			TitleData recordByKey4 = this.DM.TitleDataF.GetRecordByKey(num);
			int num5 = 0;
			for (int l = 0; l < 3; l++)
			{
				if (recordByKey4.Effects[l].EffectID != 0)
				{
					if (this.TitleSPItemText3.Length > 0)
					{
						this.TitleSPItemText3.Append("\n");
					}
					if (this.DM.EffectData.GetRecordByKey(recordByKey4.Effects[l].EffectID).ID > 0)
					{
						num5++;
					}
				}
			}
			if (num5 > 2)
			{
				this.TitleSPItem3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140f);
				this.TitleSPItem3.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140f);
				this.TitleSPItem3.GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 90f);
				this.SPHeights.Add(143f);
			}
			else
			{
				this.TitleSPItem3.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110f);
				this.TitleSPItem3.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110f);
				this.TitleSPItem3.GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 60f);
				this.SPHeights.Add(113f);
			}
		}
		if (this.OpenKind == EUILordInfoLayout.RecordInfo)
		{
			num = this.DM.RoleAttr.KingdomTitle;
		}
		else
		{
			num = this.DM.mLordProfile.Title;
		}
		if (num > 1)
		{
			this.EnhanceShowedIdx.Add(10000);
			if (num == 1)
			{
				this.TitleSPItem.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140f);
				this.TitleSPItem.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 140f);
				this.TitleSPItem.GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 90f);
				this.SPHeights.Add(143f);
			}
			else
			{
				this.TitleSPItem.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110f);
				this.TitleSPItem.GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110f);
				this.TitleSPItem.GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 60f);
				this.SPHeights.Add(113f);
			}
		}
		for (int m = 0; m < UILordInfo.RecordFields.GetLength(0); m++)
		{
			if (this.OpenKind == EUILordInfoLayout.RecordInfoOther & m == 19)
			{
				m += 9;
			}
			this.EnhanceShowedIdx.Add(m);
			if (UILordInfo.RecordFields[m, 1] == 0u)
			{
				this.SPHeights.Add(42f);
			}
			else
			{
				this.SPHeights.Add(32f);
			}
		}
		this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeights, 481f, false);
		RectTransform component = this.AGS_ScrollPanel.GetComponent<RectTransform>();
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 481f);
		if (this.HasBeenPage == EUILordInfoLayout.EnhanceInfo)
		{
			this.AGS_ScrollPanel.GoTo(0);
		}
		GUIManager.Instance.HideUILock(EUILock.LordInfo);
		this.StatDataReady = true;
		this.HasBeenPage = this.OpenKind;
	}

	// Token: 0x06001E10 RID: 7696 RVA: 0x00391DE4 File Offset: 0x0038FFE4
	private void UpdateInfo_Enhance()
	{
		this.AGS_ScrollPanel.gameObject.SetActive(true);
		if (!this.scrollPanelInit)
		{
			this.scrollPanelInit = true;
			this.SPHeights = new List<float>();
			this.AGS_ScrollPanel.IntiScrollPanel(515f, 0f, 0f, this.SPHeights, 18, this);
			UIButtonHint.scrollRect2 = this.AGS_ScrollPanel.GetComponent<CScrollRect>();
		}
		if (this.EnhanceShowedIdx == null)
		{
			this.EnhanceShowedIdx = new List<int>();
		}
		if (this.Barkind == null)
		{
			this.Barkind = new List<eSPDisplayType>();
		}
		this.EnhanceShowedIdx.Clear();
		this.SPHeights.Clear();
		this.Barkind.Clear();
		ushort num = 0;
		this.lastUpdateIdx = -1;
		ushort num2 = 0;
		while ((int)num2 < this.DM.LordEnhanceTable.TableCount)
		{
			LordEnhanceTbl recordByIndex = this.DM.LordEnhanceTable.GetRecordByIndex((int)num2);
			if (recordByIndex.Type != 4)
			{
				goto IL_1A1;
			}
			bool flag = false;
			int i = (int)(num2 + 1);
			while (i < this.DM.LordEnhanceTable.TableCount)
			{
				LordEnhanceTbl recordByIndex2 = this.DM.LordEnhanceTable.GetRecordByIndex(i);
				if (recordByIndex2.Type == 4)
				{
					break;
				}
				if (recordByIndex2.Type == 1)
				{
					if (this.GetBuffTime((int)recordByIndex2.Effect1) != 0u)
					{
						goto IL_172;
					}
				}
				else if (recordByIndex2.Type == 3)
				{
					if (recordByIndex2.Effect2 <= 3)
					{
						goto IL_172;
					}
				}
				else if (recordByIndex2.Type <= 4)
				{
					goto IL_172;
				}
				i++;
				continue;
				IL_172:
				flag = true;
				break;
			}
			if (flag)
			{
				goto IL_1A1;
			}
			IL_27F:
			num2 += 1;
			continue;
			IL_1A1:
			if (recordByIndex.Type == 1)
			{
				if (this.GetBuffTime((int)recordByIndex.Effect1) == 0u)
				{
					goto IL_27F;
				}
				this.lastUpdateIdx = (int)num2;
			}
			else if (recordByIndex.Type == 3)
			{
				if (recordByIndex.Effect2 > 3)
				{
					goto IL_27F;
				}
			}
			else if (recordByIndex.Type > 4)
			{
				goto IL_27F;
			}
			this.EnhanceShowedIdx.Add((int)num2);
			if (recordByIndex.Type == 4)
			{
				this.SPHeights.Add(42f);
				this.Barkind.Add(eSPDisplayType.Title);
				num = num2;
				goto IL_27F;
			}
			if ((num2 - num) % 2 > 0)
			{
				this.Barkind.Add(eSPDisplayType.content);
			}
			else
			{
				this.Barkind.Add(eSPDisplayType.HighLightContent);
			}
			this.SPHeights.Add(32f);
			goto IL_27F;
		}
		this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeights, 515f, false);
		RectTransform component = this.AGS_ScrollPanel.GetComponent<RectTransform>();
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 515f);
		this.TitleSPItem.gameObject.SetActive(false);
		this.TitleSPItem2.gameObject.SetActive(false);
		this.TitleSPItem3.gameObject.SetActive(false);
		if (this.HasBeenPage != EUILordInfoLayout.EnhanceInfo)
		{
			this.AGS_ScrollPanel.GoTo(0);
		}
		this.HasBeenPage = this.OpenKind;
		GUIManager.Instance.HideUILock(EUILock.LordInfo);
	}

	// Token: 0x06001E11 RID: 7697 RVA: 0x00392124 File Offset: 0x00390324
	private void UpdateInfo_MyHeader()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Length = 0;
		float num = 0f;
		UIText component = this.AGS_Form.GetChild(2).GetChild(11).GetComponent<UIText>();
		stringBuilder.Length = 0;
		stringBuilder.AppendFormat("{0:N0}", this.DM.RoleAttr.VIPLevel);
		component.text = stringBuilder.ToString();
		component = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
		RectTransform component2;
		Vector2 vector;
		if (this.DM.RoleAlliance.Id > 0u)
		{
			this.AGS_GuildRank.gameObject.SetActive(true);
			this.AGS_GuildRank.SetSpriteIndex((int)this.DM.RoleAlliance.Rank);
			component2 = this.AGS_GuildRank.GetComponent<RectTransform>();
			vector = component2.anchoredPosition;
			vector.x = -285f;
			component2.anchoredPosition = vector;
		}
		else
		{
			this.AGS_GuildRank.gameObject.SetActive(false);
			num += 45f;
		}
		component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 460f + num);
		this.Header_NameText.ClearString();
		if (this.DM.RoleAttr.NickName.Length > 0)
		{
			GameConstants.FormatRoleName(this.Header_NameText, this.DM.RoleAttr.Name, this.DM.RoleAlliance.Tag, this.DM.RoleAttr.NickName, 0, 0, null, null, null, "<color=#4CF5F5>");
		}
		else
		{
			CString cstring = StringManager.Instance.StaticString1024();
			cstring.ClearString();
			cstring.Append(this.DM.mStringTable.GetStringByID(9096u));
			GameConstants.FormatRoleName(this.Header_NameText, this.DM.RoleAttr.Name, this.DM.RoleAlliance.Tag, cstring, 0, 0, null, null, null, "<color=#4CF5F5>");
		}
		component.text = this.Header_NameText.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component.cachedTextGeneratorForLayout.Invalidate();
		component.UpdateArabicPos();
		component2 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<RectTransform>();
		vector = component2.anchoredPosition;
		vector.x = -240f - num;
		vector = component.ArabicFixPos(vector);
		component2.anchoredPosition = vector;
		component2 = this.AGS_Form.GetChild(2).GetChild(3).GetComponent<RectTransform>();
		vector = component2.anchoredPosition;
		vector.x = Math.Min(230f, -210f - num + component.preferredWidth);
		component2.anchoredPosition = vector;
		component = this.AGS_Form.GetChild(2).GetChild(5).GetComponent<UIText>();
		stringBuilder.Length = 0;
		stringBuilder.AppendFormat("{0:N0}", this.DM.RoleAttr.Power);
		component.text = stringBuilder.ToString();
		component = this.AGS_Form.GetChild(2).GetChild(6).GetComponent<UIText>();
		stringBuilder.Length = 0;
		stringBuilder.AppendFormat("{0:N0}", this.DM.RoleAttr.Kills);
		component.text = stringBuilder.ToString();
		component = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
		stringBuilder.Length = 0;
		stringBuilder.AppendFormat("{0:N0}", this.DM.RoleAttr.Level);
		component.text = stringBuilder.ToString();
		component = this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>();
		stringBuilder.Length = 0;
		if (!GUIManager.Instance.IsArabic)
		{
			stringBuilder.AppendFormat("{0:N0} / {1:N0}", this.DM.RoleAttr.Exp, this.DM.LevelUpTable.GetRecordByKey((ushort)this.DM.RoleAttr.Level).KingdomExp);
		}
		else
		{
			stringBuilder.AppendFormat("{1:N0} / {0:N0}", this.DM.RoleAttr.Exp, this.DM.LevelUpTable.GetRecordByKey((ushort)this.DM.RoleAttr.Level).KingdomExp);
		}
		component.text = stringBuilder.ToString();
		float num2 = 250f * this.DM.RoleAttr.Exp / this.DM.LevelUpTable.GetRecordByKey((ushort)this.DM.RoleAttr.Level).KingdomExp;
		if (num2 > 250f)
		{
			num2 = 250f;
		}
		if (this.DM.RoleAttr.Level >= 60)
		{
			num2 = 250f;
			component.text = this.DM.mStringTable.GetStringByID(7369u);
		}
		component2 = this.AGS_Form.GetChild(6).GetChild(3).GetComponent<RectTransform>();
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2);
		component2 = this.AGS_Form.GetChild(6).GetChild(2).GetComponent<RectTransform>();
		num2 = this.DM.RoleAttr.MonsterPoint / this.DM.GetMaxMonsterPoint();
		num2 = Mathf.Clamp01(num2);
		component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num2 * 261f);
		component = this.AGS_Form.GetChild(6).GetChild(7).GetComponent<UIText>();
		this.EnStr.ClearString();
		this.EnStr.IntToFormat((long)((ulong)this.DM.RoleAttr.MonsterPoint), 1, true);
		this.EnStr.IntToFormat((long)((ulong)this.DM.GetMaxMonsterPoint()), 1, true);
		if (!GUIManager.Instance.IsArabic)
		{
			this.EnStr.AppendFormat("{0} / {1}");
		}
		else
		{
			this.EnStr.AppendFormat("{1} / {0}");
		}
		component.text = this.EnStr.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001E12 RID: 7698 RVA: 0x0039274C File Offset: 0x0039094C
	public override void OnClose()
	{
		this.Destory3DObject(false);
		if (this.Header_NameText != null)
		{
			StringManager.Instance.DeSpawnString(this.Header_NameText);
		}
		for (int i = 0; i < this.tmpString.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.tmpString[i]);
		}
		for (int j = 0; j < this.tmpLordString.Length; j++)
		{
			StringManager.Instance.DeSpawnString(this.tmpLordString[j]);
		}
		for (int k = 0; k < this.JailerStr.Length; k++)
		{
			StringManager.Instance.DeSpawnString(this.JailerStr[k]);
		}
		StringManager.Instance.DeSpawnString(this.hintString);
		StringManager.Instance.DeSpawnString(this.countDown);
		StringManager.Instance.DeSpawnString(this.PopStr);
		StringManager.Instance.DeSpawnString(this.EnStr);
		StringManager.Instance.DeSpawnString(this.TitleSPItemText);
		StringManager.Instance.DeSpawnString(this.TitleSPItemText2);
		StringManager.Instance.DeSpawnString(this.TitleSPItemText3);
		for (int l = 0; l < this.ParticleGO.Length; l++)
		{
			if (this.ParticleGO[l] != null)
			{
				ParticleManager.Instance.DeSpawn(this.ParticleGO[l]);
				this.ParticleGO[l] = null;
			}
		}
		this.mat_AlphaBlend_back = null;
		this.mat_AlphaBlend_front = null;
		this.mat_Additive = null;
		GUIManager.Instance.HideUILock(EUILock.LordInfo);
	}

	// Token: 0x06001E13 RID: 7699 RVA: 0x003928E4 File Offset: 0x00390AE4
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 == 1)
			{
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_PAY_RANSOM;
				messagePacket.AddSeqId();
				messagePacket.Send(false);
				GUIManager.Instance.CloseMenu(EGUIWindow.UI_JailMoney);
			}
		}
	}

	// Token: 0x06001E14 RID: 7700 RVA: 0x0039293C File Offset: 0x00390B3C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		switch (this.OpenKind)
		{
		case EUILordInfoLayout.RecordInfo:
		case EUILordInfoLayout.RecordInfoOther:
			this.UpdateRecordRow(item, dataIdx, panelObjectIdx);
			break;
		case EUILordInfoLayout.EnhanceInfo:
			this.UpdateEffectRow(item, dataIdx, panelObjectIdx);
			break;
		}
	}

	// Token: 0x06001E15 RID: 7701 RVA: 0x00392988 File Offset: 0x00390B88
	private void UpdateRecordRow(GameObject item, int dataIdx, int panelObjectIdx)
	{
		int num = this.EnhanceShowedIdx[dataIdx];
		UIText uitext = null;
		item.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
		item.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
		if (panelObjectIdx == this.TitleSPItemIdx && num != 10000)
		{
			this.TitleSPItem.gameObject.SetActive(false);
		}
		if (num == 10000)
		{
			this.TitleSPItemIdx = panelObjectIdx;
			this.quickFillRow(item, eSPDisplayType.NoContent, 0u, out uitext);
			this.TitleSPItem.SetParent(item.transform);
			this.TitleSPItem.anchoredPosition = Vector2.zero;
			this.TitleSPItem.gameObject.SetActive(true);
			ushort inKey;
			if (this.OpenKind == EUILordInfoLayout.RecordInfo)
			{
				inKey = this.DM.RoleAttr.KingdomTitle;
			}
			else
			{
				inKey = this.DM.mLordProfile.Title;
			}
			TitleData recordByKey = this.DM.TitleData.GetRecordByKey(inKey);
			uitext = this.TitleSPItem.GetChild(2).GetComponent<UIText>();
			uitext.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.StringID);
			uitext = this.TitleSPItem.GetChild(3).GetComponent<UIText>();
			this.tmpString[panelObjectIdx].ClearString();
			Image component = this.TitleSPItem.GetChild(1).GetComponent<Image>();
			component.material = GUIManager.Instance.GetTitleMaterial();
			component.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.KvkTitle);
			if (recordByKey.isDebuff > 0)
			{
				this.TitleSPItem.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(1);
			}
			else
			{
				this.TitleSPItem.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(0);
			}
			this.TitleSPItemText.ClearString();
			for (int i = 0; i < 3; i++)
			{
				if (recordByKey.Effects[i].EffectID != 0)
				{
					if (this.TitleSPItemText.Length > 0)
					{
						this.TitleSPItemText.Append("\n");
					}
					Effect recordByKey2 = this.DM.EffectData.GetRecordByKey(recordByKey.Effects[i].EffectID);
					this.TitleSPItemText.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey2.InfoID));
					if (recordByKey.Effects[i].Value > 0)
					{
						if (recordByKey2.StatusIcon == 0)
						{
							this.TitleSPItemText.AppendFormat("<color=#35F76CFF>{0} +");
						}
						else if (recordByKey2.StatusIcon == 1)
						{
							this.TitleSPItemText.AppendFormat("<color=#FF656EFF>{0} -");
						}
						else if (recordByKey2.StatusIcon == 2)
						{
							this.TitleSPItemText.AppendFormat("<color=#FF656EFF>{0} +");
						}
						if (recordByKey2.ValueID == 0)
						{
							this.TitleSPItemText.IntToFormat((long)recordByKey.Effects[i].Value, 1, false);
							this.TitleSPItemText.AppendFormat("{0}");
						}
						else
						{
							this.TitleSPItemText.FloatToFormat((float)recordByKey.Effects[i].Value / 100f, 2, false);
							this.TitleSPItemText.AppendFormat("{0}%");
						}
						this.TitleSPItemText.Append("</color>");
					}
					else
					{
						this.TitleSPItemText.AppendFormat("<color=#35F76CFF>{0}</color>");
					}
				}
			}
			uitext.text = this.TitleSPItemText.ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			return;
		}
		if (panelObjectIdx == this.TitleSPItemIdx2 && num != 10001)
		{
			this.TitleSPItem2.gameObject.SetActive(false);
		}
		if (num == 10001)
		{
			this.TitleSPItemIdx2 = panelObjectIdx;
			this.quickFillRow(item, eSPDisplayType.NoContent, 0u, out uitext);
			this.TitleSPItem2.SetParent(item.transform);
			this.TitleSPItem2.anchoredPosition = Vector2.zero;
			this.TitleSPItem2.gameObject.SetActive(true);
			ushort inKey2;
			if (this.OpenKind == EUILordInfoLayout.RecordInfo)
			{
				inKey2 = this.DM.RoleAttr.WorldTitle_Personal;
			}
			else
			{
				inKey2 = this.DM.mLordProfile.WorldTitle;
			}
			TitleData recordByKey3 = this.DM.TitleDataW.GetRecordByKey(inKey2);
			uitext = this.TitleSPItem2.GetChild(2).GetComponent<UIText>();
			uitext.text = this.DM.mStringTable.GetStringByID((uint)recordByKey3.StringID);
			uitext = this.TitleSPItem2.GetChild(3).GetComponent<UIText>();
			this.tmpString[panelObjectIdx].ClearString();
			Image component2 = this.TitleSPItem2.GetChild(1).GetComponent<Image>();
			component2.material = GUIManager.Instance.GetTitleMaterial();
			component2.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey3.IconID, eTitleKind.WorldTitle);
			if (recordByKey3.isDebuff > 0)
			{
				this.TitleSPItem2.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(1);
			}
			else
			{
				this.TitleSPItem2.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(0);
			}
			this.TitleSPItemText2.ClearString();
			for (int j = 0; j < 3; j++)
			{
				if (recordByKey3.Effects[j].EffectID != 0)
				{
					if (this.TitleSPItemText2.Length > 0)
					{
						this.TitleSPItemText2.Append("\n");
					}
					Effect recordByKey4 = this.DM.EffectData.GetRecordByKey(recordByKey3.Effects[j].EffectID);
					this.TitleSPItemText2.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey4.InfoID));
					if (recordByKey3.Effects[j].Value > 0)
					{
						if (recordByKey4.StatusIcon == 0)
						{
							this.TitleSPItemText2.AppendFormat("<color=#35F76CFF>{0} +");
						}
						else if (recordByKey4.StatusIcon == 1)
						{
							this.TitleSPItemText2.AppendFormat("<color=#FF656EFF>{0} -");
						}
						else if (recordByKey4.StatusIcon == 2)
						{
							this.TitleSPItemText2.AppendFormat("<color=#FF656EFF>{0} +");
						}
						if (recordByKey4.ValueID == 0)
						{
							this.TitleSPItemText2.IntToFormat((long)recordByKey3.Effects[j].Value, 1, false);
							this.TitleSPItemText2.AppendFormat("{0}");
						}
						else
						{
							this.TitleSPItemText2.FloatToFormat((float)recordByKey3.Effects[j].Value / 100f, 2, false);
							this.TitleSPItemText2.AppendFormat("{0}%");
						}
						this.TitleSPItemText2.Append("</color>");
					}
					else
					{
						this.TitleSPItemText2.AppendFormat("<color=#35F76CFF>{0}</color>");
					}
				}
			}
			uitext.text = this.TitleSPItemText2.ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			return;
		}
		if (panelObjectIdx == this.TitleSPItemIdx3 && num != 10002)
		{
			this.TitleSPItem3.gameObject.SetActive(false);
		}
		if (num == 10002)
		{
			this.TitleSPItemIdx3 = panelObjectIdx;
			this.quickFillRow(item, eSPDisplayType.NoContent, 0u, out uitext);
			this.TitleSPItem3.SetParent(item.transform);
			this.TitleSPItem3.anchoredPosition = Vector2.zero;
			this.TitleSPItem3.gameObject.SetActive(true);
			ushort nobilityTitle;
			if (this.OpenKind == EUILordInfoLayout.RecordInfo)
			{
				nobilityTitle = this.DM.RoleAttr.NobilityTitle;
			}
			else
			{
				nobilityTitle = this.DM.mLordProfile.NobilityTitle;
			}
			TitleData recordByKey5 = this.DM.TitleDataF.GetRecordByKey(nobilityTitle);
			uitext = this.TitleSPItem3.GetChild(2).GetComponent<UIText>();
			uitext.text = this.DM.mStringTable.GetStringByID((uint)recordByKey5.StringID);
			uitext = this.TitleSPItem3.GetChild(3).GetComponent<UIText>();
			this.tmpString[panelObjectIdx].ClearString();
			Image component3 = this.TitleSPItem3.GetChild(1).GetComponent<Image>();
			component3.material = GUIManager.Instance.GetTitleMaterial();
			component3.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey5.IconID, eTitleKind.NobilityTitle);
			if (recordByKey5.isDebuff > 0)
			{
				this.TitleSPItem3.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(1);
			}
			else
			{
				this.TitleSPItem3.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(0);
			}
			this.TitleSPItemText3.ClearString();
			for (int k = 0; k < 3; k++)
			{
				if (recordByKey5.Effects[k].EffectID != 0)
				{
					if (this.TitleSPItemText3.Length > 0)
					{
						this.TitleSPItemText3.Append("\n");
					}
					Effect recordByKey6 = this.DM.EffectData.GetRecordByKey(recordByKey5.Effects[k].EffectID);
					this.TitleSPItemText3.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey6.InfoID));
					if (recordByKey5.Effects[k].Value > 0)
					{
						if (recordByKey6.StatusIcon == 0)
						{
							this.TitleSPItemText3.AppendFormat("<color=#35F76CFF>{0} +");
						}
						else if (recordByKey6.StatusIcon == 1)
						{
							this.TitleSPItemText3.AppendFormat("<color=#FF656EFF>{0} -");
						}
						else if (recordByKey6.StatusIcon == 2)
						{
							this.TitleSPItemText3.AppendFormat("<color=#FF656EFF>{0} +");
						}
						if (recordByKey6.ValueID == 0)
						{
							this.TitleSPItemText3.IntToFormat((long)recordByKey5.Effects[k].Value, 1, false);
							this.TitleSPItemText3.AppendFormat("{0}");
						}
						else
						{
							this.TitleSPItemText3.FloatToFormat((float)recordByKey5.Effects[k].Value / 100f, 2, false);
							this.TitleSPItemText3.AppendFormat("{0}%");
						}
						this.TitleSPItemText3.Append("</color>");
					}
					else
					{
						this.TitleSPItemText3.AppendFormat("<color=#35F76CFF>{0}</color>");
					}
				}
			}
			uitext.text = this.TitleSPItemText3.ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			return;
		}
		uitext = item.transform.GetChild(1).GetChild(2).GetComponent<UIText>();
		uitext.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 350f);
		uitext.UpdateArabicPos();
		switch (UILordInfo.RecordFields[num, 2])
		{
		case 0u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			break;
		case 1u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)(this.DM.mLordStat.BattleWin_Attack + this.DM.mLordStat.BattleWin_Defense)), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 2u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)(this.DM.mLordStat.BattleLose_Attack + this.DM.mLordStat.BattleLose_Defense)), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 3u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.BattleWin_Attack), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 4u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.BattleLose_Attack), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 5u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.BattleWin_Defense), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 6u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.BattleLose_Defense), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 7u:
		{
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			float num2 = this.DM.mLordStat.BattleWin_Attack + this.DM.mLordStat.BattleLose_Attack + this.DM.mLordStat.BattleWin_Defense + this.DM.mLordStat.BattleLose_Defense;
			if (num2 == 0f)
			{
				this.tmpString[panelObjectIdx].FloatToFormat(0f, -1, true);
			}
			else
			{
				this.tmpString[panelObjectIdx].FloatToFormat((this.DM.mLordStat.BattleWin_Attack + this.DM.mLordStat.BattleWin_Defense) / num2 * 100f, 2, false);
			}
			if (!GUIManager.Instance.IsArabic)
			{
				this.tmpString[panelObjectIdx].AppendFormat("{0}%");
			}
			else
			{
				this.tmpString[panelObjectIdx].AppendFormat("%{0}");
			}
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		}
		case 8u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.KillSoldiers, 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 9u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.KillTraps, 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 10u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.LoseSoldiers, 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 11u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.LoseTraps, 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 12u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.SoldierBeHurtCount, 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 13u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.HurtSoldierCount, 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 14u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.DestroySite), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 15u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.SiteBeDestroyed), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 16u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].uLongToFormat(this.DM.mLordStat.DamageEnemiesPowerCount, 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 17u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			break;
		case 18u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.TroopPower), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 19u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.TrapPower), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 20u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.BuildingPower), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 21u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.MissionPower), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 22u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.TechPower), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 23u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.LordPower), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 24u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			break;
		case 25u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.CaptiveLords), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 26u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.KillLords), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 27u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.LordBeEscaped), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 28u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.LordEscape), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 29u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.LordBeCaptive), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 30u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.LordBeKilled), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 31u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.SaveLordRewordCount, 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 32u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			break;
		case 33u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.HelpAlliance_FoodCount, 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 34u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.HelpAlliance_RockCount, 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 35u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.HelpAlliance_WoodCount, 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 36u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.HelpAlliance_OreCount, 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 37u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.HelpAlliance_GoldCount, 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 38u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.HelpAlliance_TurboCount), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 39u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.GatherCount, 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 40u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			break;
		case 41u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.ArenaRank), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 42u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.ArenaHistoryRank), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 43u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.ArenaWins), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 44u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.HeroPower), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 45u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.PetPower), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 46u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.PetSkillUsed), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		case 47u:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], UILordInfo.RecordFields[num, 0], out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			this.tmpString[panelObjectIdx].IntToFormat((long)((ulong)this.DM.mLordStat.PetSkillBeenUsed), 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			uitext.text = this.tmpString[panelObjectIdx].ToString();
			uitext.SetAllDirty();
			uitext.cachedTextGenerator.Invalidate();
			break;
		default:
			this.quickFillRow(item, (eSPDisplayType)UILordInfo.RecordFields[num, 1], (uint)num, out uitext);
			this.tmpString[panelObjectIdx].ClearString();
			if (uitext != null)
			{
				uitext.text = "---------";
			}
			break;
		}
	}

	// Token: 0x06001E16 RID: 7702 RVA: 0x00394DFC File Offset: 0x00392FFC
	private void UpdateEffectRow(GameObject item, int dataIdx, int panelObjectIdx)
	{
		int num = this.EnhanceShowedIdx[dataIdx];
		LordEnhanceTbl recordByIndex = this.DM.LordEnhanceTable.GetRecordByIndex((int)((ushort)num));
		UIText uitext = null;
		uitext = item.transform.GetChild(1).GetChild(2).GetComponent<UIText>();
		uitext.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 150f);
		uitext.UpdateArabicPos();
		long num2 = 0L;
		long num3 = 0L;
		switch (recordByIndex.Type)
		{
		case 1:
		{
			ItemBuff recordByKey = this.DM.ItemBuffTable.GetRecordByKey(recordByIndex.Effect1);
			this.quickFillRow(item, this.Barkind[dataIdx], (uint)recordByKey.BuffNameID, out uitext);
			num2 = (long)((ulong)this.GetBuffTime((int)recordByIndex.Effect1));
			break;
		}
		case 2:
		{
			Effect recordByKey2 = this.DM.EffectData.GetRecordByKey(recordByIndex.Effect1);
			this.quickFillRow(item, this.Barkind[dataIdx], (uint)recordByKey2.InfoID, out uitext);
			if (recordByIndex.LordEffect != 0)
			{
				num2 = (long)((ulong)this.DM.AttribVal.GetEffectBaseValDueLord(recordByIndex.Effect1, false));
				num3 = (long)((ulong)this.DM.AttribVal.GetEffectBaseValDueLord(recordByIndex.Effect1, true));
			}
			else
			{
				num2 = (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(recordByIndex.Effect1));
			}
			if (recordByIndex.Effect2 != 0)
			{
				num2 += (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(recordByIndex.Effect2));
			}
			ushort id = recordByKey2.ID;
			switch (id)
			{
			case 242:
				num2 -= (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(328));
				num2 -= (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(327));
				break;
			case 243:
				num2 -= (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(329));
				num2 -= (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(327));
				break;
			case 244:
				num2 -= (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(330));
				num2 -= (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(327));
				break;
			case 245:
				num2 -= (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(331));
				num2 -= (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(327));
				break;
			case 246:
				num2 -= (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(332));
				num2 -= (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(327));
				break;
			default:
				switch (id)
				{
				case 216:
				{
					uint effectBaseValByEffectID = this.DM.AttribVal.GetEffectBaseValByEffectID(221);
					num2 -= (long)((ulong)effectBaseValByEffectID);
					num3 -= (long)((ulong)effectBaseValByEffectID);
					if (this.DM.bHaveWarBuff)
					{
						effectBaseValByEffectID = this.DM.AttribVal.GetEffectBaseValByEffectID(349);
						num2 += (long)((ulong)effectBaseValByEffectID);
						num3 += (long)((ulong)effectBaseValByEffectID);
					}
					break;
				}
				case 217:
				{
					uint effectBaseValByEffectID2 = this.DM.AttribVal.GetEffectBaseValByEffectID(222);
					num2 -= (long)((ulong)effectBaseValByEffectID2);
					num3 -= (long)((ulong)effectBaseValByEffectID2);
					if (this.DM.bHaveWarBuff)
					{
						effectBaseValByEffectID2 = this.DM.AttribVal.GetEffectBaseValByEffectID(350);
						num2 += (long)((ulong)effectBaseValByEffectID2);
						num3 += (long)((ulong)effectBaseValByEffectID2);
					}
					break;
				}
				case 218:
				{
					uint effectBaseValByEffectID3 = this.DM.AttribVal.GetEffectBaseValByEffectID(223);
					num2 -= (long)((ulong)effectBaseValByEffectID3);
					num3 -= (long)((ulong)effectBaseValByEffectID3);
					if (this.DM.bHaveWarBuff)
					{
						effectBaseValByEffectID3 = this.DM.AttribVal.GetEffectBaseValByEffectID(351);
						num2 += (long)((ulong)effectBaseValByEffectID3);
						num3 += (long)((ulong)effectBaseValByEffectID3);
					}
					break;
				}
				case 220:
					num2 -= (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(225));
					break;
				}
				break;
			case 248:
				num2 -= (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(333));
				break;
			case 249:
				num2 -= (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(334));
				break;
			case 251:
				num2 -= (long)((ulong)this.DM.AttribVal.GetEffectBaseValByEffectID(335));
				break;
			}
			if (recordByIndex.LordEffect != 0)
			{
				double num4 = (double)num3 / 100.0;
				this.tmpLordString[panelObjectIdx].ClearString();
				if (num4 < 0.0)
				{
					num4 *= -1.0;
					this.tmpLordString[panelObjectIdx].DoubleToFormat(num4, 2, false);
					if (!GUIManager.Instance.IsArabic)
					{
						this.tmpLordString[panelObjectIdx].AppendFormat("<color=#FF656EFF>-{0}%</color>");
					}
					else
					{
						this.tmpLordString[panelObjectIdx].AppendFormat("<color=#FF656EFF>%{0}-</color>");
					}
				}
				else
				{
					this.tmpLordString[panelObjectIdx].DoubleToFormat(num4, 2, false);
					if (!GUIManager.Instance.IsArabic)
					{
						this.tmpLordString[panelObjectIdx].AppendFormat("+{0}%");
					}
					else
					{
						this.tmpLordString[panelObjectIdx].AppendFormat("%{0}+");
					}
				}
				item.transform.GetChild(1).GetChild(3).GetComponent<UIText>().text = this.tmpLordString[panelObjectIdx].ToString();
				item.transform.GetChild(1).GetChild(3).GetComponent<UIText>().SetAllDirty();
				item.transform.GetChild(1).GetChild(3).GetComponent<UIText>().cachedTextGenerator.Invalidate();
			}
			break;
		}
		case 3:
			this.quickFillRow(item, this.Barkind[dataIdx], (uint)recordByIndex.Effect1, out uitext);
			switch (recordByIndex.Effect2)
			{
			case 1:
				num2 = (long)((ulong)this.DM.m_WallRepairMaxValue);
				break;
			case 2:
				num2 = (long)((ulong)this.DM.GetMaxMonsterPoint());
				break;
			case 3:
				num2 = (long)((ulong)(this.DM.AttribVal.GetEffectBaseValByEffectID(320) + 5u));
				break;
			}
			break;
		case 4:
			this.quickFillRow(item, eSPDisplayType.Title, (uint)recordByIndex.Effect1, out uitext);
			if (recordByIndex.LordEffect == 0)
			{
				item.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
			}
			else
			{
				item.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
			}
			return;
		}
		this.tmpString[panelObjectIdx].ClearString();
		switch (recordByIndex.ValueKind)
		{
		case 1:
		{
			double num5 = (double)num2 / 100.0;
			this.tmpString[panelObjectIdx].DoubleToFormat(num5, 2, false);
			if (num5 < 0.0)
			{
				if (!GUIManager.Instance.IsArabic)
				{
					this.tmpString[panelObjectIdx].AppendFormat("<color=#FF656EFF>{0}%</color>");
				}
				else
				{
					this.tmpString[panelObjectIdx].AppendFormat("<color=#FF656EFF>%{0}</color>");
				}
			}
			else if (!GUIManager.Instance.IsArabic)
			{
				this.tmpString[panelObjectIdx].AppendFormat("+{0}%");
			}
			else
			{
				this.tmpString[panelObjectIdx].AppendFormat("%{0}+");
			}
			break;
		}
		case 2:
			this.tmpString[panelObjectIdx].IntToFormat(num2, 1, true);
			this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			break;
		case 3:
			this.tmpString[panelObjectIdx].Append("<color=#00FF00>");
			GameConstants.GetTimeString(this.tmpString[panelObjectIdx], (uint)num2, false, false, true, false, true);
			this.tmpString[panelObjectIdx].Append("</color>");
			break;
		case 4:
			if (!GUIManager.Instance.IsArabic)
			{
				this.tmpString[panelObjectIdx].Append('+');
				GameConstants.GetTimeString(this.tmpString[panelObjectIdx], (uint)num2, false, false, true, false, true);
			}
			else
			{
				GameConstants.GetTimeString(this.tmpString[panelObjectIdx], (uint)num2, false, false, true, false, true);
				this.tmpString[panelObjectIdx].Append('+');
			}
			break;
		case 5:
			if (!GUIManager.Instance.IsArabic)
			{
				this.tmpString[panelObjectIdx].Append('+');
				this.tmpString[panelObjectIdx].IntToFormat(num2, 1, true);
				this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
			}
			else
			{
				this.tmpString[panelObjectIdx].IntToFormat(num2, 1, true);
				this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
				this.tmpString[panelObjectIdx].Append('+');
			}
			break;
		case 6:
			if (!GUIManager.Instance.IsArabic)
			{
				this.tmpString[panelObjectIdx].Append('+');
				GameConstants.GetTimeString(this.tmpString[panelObjectIdx], (uint)num2 * 60u, false, false, true, false, true);
			}
			else
			{
				GameConstants.GetTimeString(this.tmpString[panelObjectIdx], (uint)num2 * 60u, false, false, true, false, true);
				this.tmpString[panelObjectIdx].Append('+');
			}
			break;
		default:
			this.tmpString[panelObjectIdx].Append('0');
			break;
		}
		uitext.text = this.tmpString[panelObjectIdx].ToString();
		uitext.SetAllDirty();
		uitext.cachedTextGenerator.Invalidate();
		if (recordByIndex.LordEffect != 0)
		{
			item.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
		}
		else
		{
			item.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
		}
	}

	// Token: 0x06001E17 RID: 7703 RVA: 0x003957DC File Offset: 0x003939DC
	private uint GetBuffTime(int id)
	{
		int recvBuffDataIdxByID = this.DM.GetRecvBuffDataIdxByID((ushort)((byte)id));
		if (recvBuffDataIdxByID < 0)
		{
			return 0u;
		}
		ItemBuffData itemBuffData = this.DM.m_RecvItemBuffData[recvBuffDataIdxByID];
		long num = itemBuffData.TargetTime - this.DM.ServerTime;
		if (num > 0L)
		{
			return (uint)num;
		}
		return 0u;
	}

	// Token: 0x06001E18 RID: 7704 RVA: 0x00395838 File Offset: 0x00393A38
	private void quickFillRow(GameObject item, eSPDisplayType type, uint constStringID, out UIText SecendText)
	{
		SecendText = null;
		switch (type)
		{
		case eSPDisplayType.Title:
			item.transform.GetChild(0).gameObject.SetActive(true);
			item.transform.GetChild(1).gameObject.SetActive(false);
			item.transform.GetChild(0).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(constStringID);
			break;
		case eSPDisplayType.content:
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			item.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(constStringID);
			SecendText = item.transform.GetChild(1).GetChild(2).GetComponent<UIText>();
			break;
		case eSPDisplayType.HighLightContent:
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(true);
			item.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
			item.transform.GetChild(1).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(constStringID);
			SecendText = item.transform.GetChild(1).GetChild(2).GetComponent<UIText>();
			break;
		case eSPDisplayType.NoContent:
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(false);
			break;
		}
	}

	// Token: 0x06001E19 RID: 7705 RVA: 0x00395A28 File Offset: 0x00393C28
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001E1A RID: 7706 RVA: 0x00395A2C File Offset: 0x00393C2C
	public void OnButtonDown(UIButtonHint sender)
	{
		float num = 0f;
		float num2 = 0f;
		UIButton uibutton = sender.m_Button as UIButton;
		if (sender.Parm2 == 1)
		{
			if (sender.Parm1 != 0)
			{
				if (uibutton != null)
				{
					if (uibutton.m_BtnID2 < 5)
					{
						GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 320f, 20, (int)sender.Parm1, 0, new Vector2(110f, -110f), UIButtonHint.ePosition.Original);
					}
					else
					{
						GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 320f, 20, (int)sender.Parm1, 0, new Vector2(-320f, -110f), UIButtonHint.ePosition.Original);
					}
				}
				else
				{
					GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 320f, 20, (int)sender.Parm1, 0, new Vector2(110f, -110f), UIButtonHint.ePosition.Original);
				}
			}
			return;
		}
		switch (uibutton.m_BtnID1)
		{
		case 3:
			if (uibutton.m_BtnID2 < 6)
			{
				return;
			}
			goto IL_126;
		case 6:
			goto IL_126;
		}
		return;
		IL_126:
		UIText component = this.HintPanel.GetChild(1).GetComponent<UIText>();
		component.alignment = TextAnchor.MiddleCenter;
		component.AdjuestUI();
		RectTransform component2 = this.HintPanel.GetChild(0).GetComponent<RectTransform>();
		switch (uibutton.m_BtnID1)
		{
		case 3:
		{
			if (this.OpenKind != EUILordInfoLayout.LordSelf)
			{
				return;
			}
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 310f);
			component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300f);
			RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(15, 0);
			int btnID = uibutton.m_BtnID2;
			if (btnID != 7)
			{
				if (btnID == 8)
				{
					if (buildData.Level >= 25)
					{
						return;
					}
					this.hintString.ClearString();
					this.hintString.Append(this.DM.mStringTable.GetStringByID(7496u));
					component.text = this.hintString.ToString();
				}
			}
			else
			{
				if (buildData.Level >= 17)
				{
					return;
				}
				this.hintString.ClearString();
				this.hintString.Append(this.DM.mStringTable.GetStringByID(7401u));
				component.text = this.hintString.ToString();
			}
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			component.cachedTextGeneratorForLayout.Invalidate();
			num = component.preferredWidth;
			if (num > 300f)
			{
				num = 300f;
			}
			component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num + 30f);
			num2 = component.preferredHeight;
			component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num2);
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num2 + 20f);
			component2 = sender.GetComponent<RectTransform>();
			this.HintPanel.anchoredPosition = new Vector2(192f, -35f);
			this.HintPanel.gameObject.SetActive(true);
			break;
		}
		case 6:
		{
			component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 110f);
			component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100f);
			component.alignment = ((!GUIManager.Instance.IsArabic) ? TextAnchor.MiddleLeft : TextAnchor.MiddleRight);
			bool flag = false;
			switch (uibutton.m_BtnID2)
			{
			case 1:
				this.hintString.ClearString();
				this.hintString.IntToFormat((long)this.DM.mLordProfile.Enhance, 1, false);
				this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(7389u));
				component.text = this.hintString.ToString();
				goto IL_BA1;
			case 2:
				this.hintString.ClearString();
				this.hintString.StringToFormat(this.DM.mStringTable.GetStringByID((uint)((ushort)((int)this.DM.mLordProfile.Star + 7389))));
				this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(7387u));
				component.text = this.hintString.ToString();
				goto IL_BA1;
			case 3:
			case 10:
				this.hintString.ClearString();
				this.hintString.Append(this.DM.mStringTable.GetStringByID(7349u));
				component.text = this.hintString.ToString();
				goto IL_BA1;
			case 4:
				this.hintString.ClearString();
				this.hintString.Append(this.DM.mStringTable.GetStringByID(7345u));
				component.text = this.hintString.ToString();
				goto IL_BA1;
			case 5:
				this.hintString.ClearString();
				this.hintString.Append(this.DM.mStringTable.GetStringByID(7346u));
				component.text = this.hintString.ToString();
				goto IL_BA1;
			case 6:
				this.hintString.ClearString();
				this.hintString.Append(this.DM.mStringTable.GetStringByID(7347u));
				component.text = this.hintString.ToString();
				goto IL_BA1;
			case 7:
				this.hintString.ClearString();
				this.hintString.Append(this.DM.mStringTable.GetStringByID(7348u));
				component.text = this.hintString.ToString();
				goto IL_BA1;
			case 8:
			{
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110f);
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300f);
				component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 110f);
				component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 250f);
				this.hintString.ClearString();
				this.hintString.Append(this.DM.mStringTable.GetStringByID(880u));
				this.hintString.Append("\n");
				uint maxMonsterPoint = this.DM.GetMaxMonsterPoint();
				if (maxMonsterPoint > this.DM.RoleAttr.MonsterPoint)
				{
					this.MonsterTime = (long)((this.DM.GetMaxMonsterPoint() - this.DM.RoleAttr.MonsterPoint) * ((double)this.DM.RoleAttr.MonsterPointRecoverFrequency / 1000.0));
					int num3 = (int)this.MonsterTime / 3600;
					int num4 = (int)this.MonsterTime % 3600 / 60;
					int num5 = (int)this.MonsterTime % 60;
					this.hintString.IntToFormat((long)num3, 2, false);
					this.hintString.IntToFormat((long)num4, 2, false);
					this.hintString.IntToFormat((long)num5, 2, false);
					this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(881u));
					this.isMonsterOpen = true;
				}
				else
				{
					this.hintString.Append(this.DM.mStringTable.GetStringByID(882u));
				}
				component.text = this.hintString.ToString();
				goto IL_BA1;
			}
			case 9:
				this.hintString.ClearString();
				this.hintString.Append(this.DM.mStringTable.GetStringByID(7698u));
				component.text = this.hintString.ToString();
				goto IL_BA1;
			case 11:
				this.hintString.ClearString();
				this.hintString.Append(this.DM.mStringTable.GetStringByID(9549u));
				this.hintString.Append("\n");
				this.hintString.Append(this.DM.mStringTable.GetStringByID(9551u));
				component.text = this.hintString.ToString();
				goto IL_BA1;
			case 21:
			case 26:
			{
				TitleData recordByKey;
				if (this.OpenKind != EUILordInfoLayout.LordOther && this.OpenKind != EUILordInfoLayout.RecordInfoOther)
				{
					if (this.DM.RoleAttr.KingdomTitle == 0)
					{
						return;
					}
					recordByKey = this.DM.TitleData.GetRecordByKey(this.DM.RoleAttr.KingdomTitle);
				}
				else
				{
					if (this.DM.mLordProfile.Title == 0)
					{
						return;
					}
					recordByKey = this.DM.TitleData.GetRecordByKey(this.DM.mLordProfile.Title);
				}
				this.hintString.ClearString();
				this.hintString.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.StringID));
				this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(9370u));
				component.text = this.hintString.ToString();
				goto IL_BA1;
			}
			case 22:
			case 27:
			{
				TitleData recordByKey2;
				if (this.OpenKind != EUILordInfoLayout.LordOther && this.OpenKind != EUILordInfoLayout.RecordInfoOther)
				{
					if (this.DM.RoleAttr.NobilityTitle == 0)
					{
						return;
					}
					recordByKey2 = this.DM.TitleDataF.GetRecordByKey(this.DM.RoleAttr.NobilityTitle);
				}
				else
				{
					if (this.DM.mLordProfile.NobilityTitle == 0)
					{
						return;
					}
					recordByKey2 = this.DM.TitleDataF.GetRecordByKey(this.DM.mLordProfile.NobilityTitle);
				}
				this.hintString.ClearString();
				this.hintString.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey2.StringID));
				this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(11152u));
				component.text = this.hintString.ToString();
				goto IL_BA1;
			}
			case 23:
			case 28:
			{
				TitleData recordByKey3;
				if (this.OpenKind != EUILordInfoLayout.LordOther && this.OpenKind != EUILordInfoLayout.RecordInfoOther)
				{
					if (this.DM.RoleAttr.WorldTitle_Personal == 0)
					{
						return;
					}
					recordByKey3 = this.DM.TitleDataW.GetRecordByKey(this.DM.RoleAttr.WorldTitle_Personal);
				}
				else
				{
					if (this.DM.mLordProfile.WorldTitle == 0)
					{
						return;
					}
					recordByKey3 = this.DM.TitleDataW.GetRecordByKey(this.DM.mLordProfile.WorldTitle);
				}
				this.hintString.ClearString();
				this.hintString.StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey3.StringID));
				this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(11032u));
				component.text = this.hintString.ToString();
				goto IL_BA1;
			}
			case 25:
				this.hintString.ClearString();
				this.hintString.IntToFormat((long)this.DM.mLordProfile.TotalCastleStar, 1, false);
				this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(11056u));
				component.text = this.hintString.ToString();
				goto IL_BA1;
			}
			return;
			IL_BA1:
			if (!flag)
			{
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				component.cachedTextGeneratorForLayout.Invalidate();
				num = component.preferredWidth;
				if (num > 350f)
				{
					num = 300f;
				}
				component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num);
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, num + 30f);
				num2 = component.preferredHeight;
				component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num2);
				component2.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, num2 + 20f);
			}
			component2 = sender.GetComponent<RectTransform>();
			Vector2 anchoredPosition = component2.anchoredPosition;
			switch (uibutton.m_BtnID2)
			{
			case 0:
				anchoredPosition.x += num / 2f - 40f;
				anchoredPosition.y -= 20f + num2 / 2f;
				goto IL_11DA;
			case 1:
			case 2:
			case 3:
				if (this.OpenKind == EUILordInfoLayout.LordOther)
				{
					sender.GetTipPosition(this.HintPanel, UIButtonHint.ePosition.Original, null);
					anchoredPosition = this.HintPanel.anchoredPosition;
					anchoredPosition.x = 0f;
					anchoredPosition.y -= num2 / 2f - 10f;
					Vector3 localPosition = this.HintPanel.transform.localPosition;
					localPosition.z = -1000f;
					this.HintPanel.transform.localPosition = localPosition;
				}
				else
				{
					anchoredPosition.x += num / 2f - 40f;
					anchoredPosition.y -= 20f + num2 / 2f;
				}
				goto IL_11DA;
			case 4:
			case 5:
			case 11:
				if (this.OpenKind == EUILordInfoLayout.LordOther)
				{
					anchoredPosition.x = 0f;
					anchoredPosition.y = -num2 / 2f + 220f;
				}
				else
				{
					anchoredPosition.x += num / 2f;
					anchoredPosition.y -= 20f + num2 / 2f;
				}
				goto IL_11DA;
			case 6:
			case 7:
				if (this.OpenKind == EUILordInfoLayout.LordOther)
				{
					anchoredPosition.x = 0f;
					anchoredPosition.y = -num2 / 2f + 170f;
				}
				else
				{
					anchoredPosition.x += num / 2f;
					anchoredPosition.y -= 20f + num2 / 2f;
				}
				goto IL_11DA;
			case 8:
			case 10:
				anchoredPosition.x += -280f + num / 2f;
				anchoredPosition.y += 130f - num2 / 2f;
				goto IL_11DA;
			case 21:
			case 22:
			case 23:
			{
				this.HintPanel.gameObject.SetActive(true);
				sender.GetTipPosition(this.HintPanel, UIButtonHint.ePosition.Original, null);
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				anchoredPosition = this.HintPanel.anchoredPosition;
				if (this.OpenKind == EUILordInfoLayout.LordOther)
				{
					anchoredPosition.x = 0f;
					anchoredPosition.y += num2 - 120f;
				}
				else
				{
					anchoredPosition.x += 230f;
					anchoredPosition.y += num2 - 140f;
				}
				this.HintPanel.anchoredPosition = anchoredPosition;
				Vector3 localPosition2 = this.HintPanel.transform.localPosition;
				localPosition2.z = -1000f;
				this.HintPanel.transform.localPosition = localPosition2;
				this.lastHint = sender;
				return;
			}
			case 25:
				this.HintPanel.gameObject.SetActive(true);
				if (this.OpenKind == EUILordInfoLayout.LordOther)
				{
					sender.GetTipPosition(this.HintPanel, UIButtonHint.ePosition.Original, null);
					anchoredPosition = this.HintPanel.anchoredPosition;
					anchoredPosition.x = 0f;
					anchoredPosition.y -= num2 / 2f - 10f;
					this.HintPanel.anchoredPosition = anchoredPosition;
					Vector3 localPosition3 = this.HintPanel.transform.localPosition;
					localPosition3.z = -1000f;
					this.HintPanel.transform.localPosition = localPosition3;
				}
				else
				{
					sender.GetTipPosition(this.HintPanel, UIButtonHint.ePosition.Original, null);
					component.SetAllDirty();
					component.cachedTextGenerator.Invalidate();
					anchoredPosition = this.HintPanel.anchoredPosition;
					anchoredPosition.x += num - 60f;
					this.HintPanel.anchoredPosition = anchoredPosition;
					Vector3 localPosition4 = this.HintPanel.transform.localPosition;
					localPosition4.z = -1000f;
					this.HintPanel.transform.localPosition = localPosition4;
				}
				this.lastHint = sender;
				return;
			case 26:
			case 27:
			case 28:
			{
				this.HintPanel.gameObject.SetActive(true);
				this.HintPanel.position = ((RectTransform)sender.transform).position;
				component.SetAllDirty();
				component.cachedTextGenerator.Invalidate();
				anchoredPosition = this.HintPanel.anchoredPosition;
				anchoredPosition.x += num / 2f + 15f;
				anchoredPosition.y += num2 / 2f + 5f;
				this.HintPanel.anchoredPosition = anchoredPosition;
				Vector3 localPosition5 = this.HintPanel.transform.localPosition;
				localPosition5.z = -1000f;
				this.HintPanel.transform.localPosition = localPosition5;
				this.lastHint = sender;
				return;
			}
			}
			anchoredPosition.x += num / 2f;
			anchoredPosition.y -= 20f + num2 / 2f;
			IL_11DA:
			this.HintPanel.anchoredPosition = anchoredPosition;
			this.HintPanel.gameObject.SetActive(true);
			break;
		}
		}
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		this.lastHint = sender;
	}

	// Token: 0x06001E1B RID: 7707 RVA: 0x00396C50 File Offset: 0x00394E50
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(true);
		this.isMonsterOpen = false;
		if (sender != this.lastHint)
		{
			return;
		}
		this.HintPanel.gameObject.SetActive(false);
	}

	// Token: 0x06001E1C RID: 7708 RVA: 0x00396C98 File Offset: 0x00394E98
	public void Update()
	{
		this.GetPointTime += Time.smoothDeltaTime;
		if (this.GetPointTime >= 2f)
		{
			this.GetPointTime = 0f;
		}
		float a = (this.GetPointTime <= 1f) ? this.GetPointTime : (2f - this.GetPointTime);
		Color color = new Color(1f, 1f, 1f, a);
		if (this.BarLight.gameObject.activeInHierarchy)
		{
			this.BarLight.color = color;
		}
		for (int i = 0; i < this.LEquipLight.Length; i++)
		{
			if (this.LEquipLight[i].gameObject.activeInHierarchy)
			{
				this.LEquipLight[i].color = color;
			}
		}
		if (this.DefaultActionLateUpdate)
		{
		}
		switch (this.OpenKind)
		{
		case EUILordInfoLayout.RecordInfo:
		case EUILordInfoLayout.RecordInfoOther:
		case EUILordInfoLayout.EnhanceInfo:
			return;
		default:
			switch (this.LoadingStep)
			{
			case UILordInfo.eModelLoadingStep.WaitforHero:
				if (this.bundleRequest.isDone)
				{
					this.Hero_PosRT.gameObject.SetActive(true);
					this.Holder1 = (GameObject)UnityEngine.Object.Instantiate(this.bundleRequest.asset);
					this.Holder1.transform.SetParent(this.Hero_PosRT, false);
					Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
					localRotation.eulerAngles = new Vector3(0f, (float)this.sHero.Camera_Horizontal, 0f);
					this.Holder1.transform.localRotation = localRotation;
					this.Holder1.transform.localScale = new Vector3((float)this.sHero.CameraScaleRate, (float)this.sHero.CameraScaleRate, (float)this.sHero.CameraScaleRate);
					this.Holder1.transform.localPosition = Vector3.zero;
					GUIManager.Instance.SetLayer(this.Holder1, 5);
					Transform transform = this.Holder1.transform;
					if (transform != null)
					{
						transform.GetComponentInChildren<SkinnedMeshRenderer>().useLightProbes = false;
						transform.GetComponentInChildren<SkinnedMeshRenderer>().updateWhenOffscreen = true;
						Animation component = transform.GetComponent<Animation>();
						component.cullingType = AnimationCullingType.AlwaysAnimate;
						component[AnimationUnit.ANIM_STRING[0]].layer = 0;
						component[AnimationUnit.ANIM_STRING[0]].wrapMode = WrapMode.Loop;
						component[AnimationUnit.ANIM_STRING[1]].layer = 0;
						component[AnimationUnit.ANIM_STRING[1]].wrapMode = WrapMode.Loop;
						component[AnimationUnit.ANIM_STRING[2]].layer = 1;
						component[AnimationUnit.ANIM_STRING[2]].wrapMode = WrapMode.Once;
						if (component.GetClip(AnimationUnit.ANIM_STRING[3]) != null)
						{
							component[AnimationUnit.ANIM_STRING[3]].layer = 1;
							component[AnimationUnit.ANIM_STRING[3]].wrapMode = WrapMode.Once;
						}
						if (component.GetClip(AnimationUnit.ANIM_STRING[4]) != null)
						{
							component[AnimationUnit.ANIM_STRING[4]].layer = 1;
							component[AnimationUnit.ANIM_STRING[4]].wrapMode = WrapMode.Once;
						}
						if (component.GetClip(AnimationUnit.ANIM_STRING[5]) != null)
						{
							component[AnimationUnit.ANIM_STRING[5]].layer = 1;
							component[AnimationUnit.ANIM_STRING[5]].wrapMode = WrapMode.Once;
						}
						component[AnimationUnit.ANIM_STRING[7]].layer = 1;
						component[AnimationUnit.ANIM_STRING[7]].wrapMode = WrapMode.ClampForever;
						component[AnimationUnit.ANIM_STRING[9]].layer = 1;
						component[AnimationUnit.ANIM_STRING[9]].wrapMode = WrapMode.Loop;
						component[AnimationUnit.ANIM_STRING[8]].layer = 1;
						component[AnimationUnit.ANIM_STRING[8]].wrapMode = WrapMode.Once;
						component.Play(AnimationUnit.ANIM_STRING[0]);
						this.LoadingStep = UILordInfo.eModelLoadingStep.HeroReady;
						this.SetModelDefaultAction();
						if (this.OpenKind == EUILordInfoLayout.LordSelf && this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Captured)
						{
							CString cstring = StringManager.Instance.StaticString1024();
							cstring.Append("Role/cage");
							this.bundle = AssetManager.GetAssetBundle(cstring, out this.AssetKey1);
							this.bundleRequest = this.bundle.LoadAsync("m", typeof(GameObject));
							this.LoadingStep = UILordInfo.eModelLoadingStep.WaitforCage;
						}
					}
				}
				break;
			case UILordInfo.eModelLoadingStep.HeroReady:
			case UILordInfo.eModelLoadingStep.Done:
				if (this.Holder1 == null)
				{
					return;
				}
				if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.None && Time.time > this.NextActionTime)
				{
					Animation component2 = this.Holder1.GetComponent<Animation>();
					this.NextActionTime = Time.time + 5f;
					component2.CrossFade(AnimationUnit.ANIM_STRING[0]);
					switch (UnityEngine.Random.Range(0, 5))
					{
					case 0:
						component2.CrossFade(AnimationUnit.ANIM_STRING[2]);
						break;
					case 1:
						if (component2.GetClip(AnimationUnit.ANIM_STRING[3]) != null)
						{
							component2.CrossFade(AnimationUnit.ANIM_STRING[3]);
						}
						else
						{
							component2.CrossFade(AnimationUnit.ANIM_STRING[1]);
						}
						break;
					case 2:
						if (component2.GetClip(AnimationUnit.ANIM_STRING[4]) != null)
						{
							component2.CrossFade(AnimationUnit.ANIM_STRING[4]);
						}
						else
						{
							component2.CrossFade(AnimationUnit.ANIM_STRING[1]);
						}
						break;
					case 3:
						if (component2.GetClip(AnimationUnit.ANIM_STRING[5]) != null)
						{
							component2.CrossFade(AnimationUnit.ANIM_STRING[5]);
						}
						else
						{
							component2.CrossFade(AnimationUnit.ANIM_STRING[1]);
						}
						break;
					case 4:
						component2.CrossFade(AnimationUnit.ANIM_STRING[8]);
						break;
					case 5:
						component2.CrossFade(AnimationUnit.ANIM_STRING[1]);
						break;
					}
				}
				break;
			case UILordInfo.eModelLoadingStep.WaitforCage:
				if (this.bundleRequest.isDone)
				{
					this.Hero_PosRT.gameObject.SetActive(true);
					this.Holder2 = (GameObject)UnityEngine.Object.Instantiate(this.bundleRequest.asset);
					this.Holder2.transform.SetParent(this.Hero_PosRT, false);
					Quaternion localRotation2 = new Quaternion(0f, 0f, 0f, 0f);
					localRotation2.eulerAngles = new Vector3(0f, 6f, 0f);
					this.Holder2.transform.localRotation = localRotation2;
					this.Holder2.transform.localScale = new Vector3(55f, 50f, 55f);
					this.Holder2.transform.localPosition = Vector3.zero;
					GUIManager.Instance.SetLayer(this.Holder2, 5);
					this.Holder2.GetComponentInChildren<MeshRenderer>().useLightProbes = false;
					CString cstring2 = StringManager.Instance.StaticString1024();
					cstring2.IntToFormat((long)this.sHero.Modle, 5, false);
					cstring2.AppendFormat("Role/hero_{0}");
					this.bundle = AssetManager.GetAssetBundle(cstring2, out this.AssetKey2);
					if (this.bundle == null)
					{
						this.LoadingStep = UILordInfo.eModelLoadingStep.Done;
					}
					else
					{
						this.bundleRequest = this.bundle.LoadAsync("m", typeof(GameObject));
						this.LoadingStep = UILordInfo.eModelLoadingStep.Done;
					}
				}
				break;
			}
			return;
		}
	}

	// Token: 0x06001E1D RID: 7709 RVA: 0x00397468 File Offset: 0x00395668
	public void OnEnable()
	{
		this.SetModelDefaultAction();
	}

	// Token: 0x06001E1E RID: 7710 RVA: 0x00397470 File Offset: 0x00395670
	private void Create3DObjects()
	{
		this.Destory3DObject(false);
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.IntToFormat((long)this.sHero.Modle, 5, false);
		cstring.AppendFormat("Role/hero_{0}");
		if (!AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, this.sHero.Modle, false))
		{
			this.LoadingStep = UILordInfo.eModelLoadingStep.Done;
			return;
		}
		this.bundle = AssetManager.GetAssetBundle(cstring, out this.AssetKey2);
		if (this.bundle == null)
		{
			this.LoadingStep = UILordInfo.eModelLoadingStep.Done;
			return;
		}
		this.bundleRequest = this.bundle.LoadAsync("m", typeof(GameObject));
		this.LoadingStep = UILordInfo.eModelLoadingStep.WaitforHero;
	}

	// Token: 0x06001E1F RID: 7711 RVA: 0x00397524 File Offset: 0x00395724
	private void Destory3DObject(bool JailOnly = false)
	{
		if (!JailOnly)
		{
			if (this.Holder1 != null)
			{
				UnityEngine.Object.Destroy(this.Holder1);
				this.Holder1 = null;
			}
			if (this.AssetKey1 != 0)
			{
				AssetManager.UnloadAssetBundle(this.AssetKey1, false);
			}
		}
		if (this.Holder2 != null)
		{
			UnityEngine.Object.Destroy(this.Holder2);
			this.Holder2 = null;
		}
		if (this.AssetKey2 != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey2, false);
		}
		this.bundle = null;
		if (JailOnly)
		{
			this.LoadingStep = UILordInfo.eModelLoadingStep.HeroReady;
		}
		else
		{
			this.LoadingStep = UILordInfo.eModelLoadingStep.Start;
		}
	}

	// Token: 0x06001E20 RID: 7712 RVA: 0x003975CC File Offset: 0x003957CC
	private void SetModelDefaultAction()
	{
		if (this.LoadingStep < UILordInfo.eModelLoadingStep.HeroReady)
		{
			return;
		}
		if (this.Holder1 == null)
		{
			return;
		}
		if (this.OpenKind == EUILordInfoLayout.LordOther)
		{
			this.Holder1.GetComponent<Animation>().Play(AnimationUnit.ANIM_STRING[0]);
			this.HeroRotater.enabled = true;
			this.HeroRotater.transform.localPosition = new Vector3(0f, -60f, -1000f);
			return;
		}
		this.HeroRotater.transform.localPosition = new Vector3(-150f, -60f, -1000f);
		Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
		localRotation.eulerAngles = new Vector3(0f, (float)this.sHero.Camera_Horizontal, 0f);
		this.Holder1.transform.localRotation = localRotation;
		this.Holder1.transform.localScale = new Vector3((float)this.sHero.CameraScaleRate, (float)this.sHero.CameraScaleRate, (float)this.sHero.CameraScaleRate);
		this.Holder1.transform.localPosition = Vector3.zero;
		this.HeroRotater.ReSetHero();
		switch (this.DM.beCaptured.nowCaptureStat)
		{
		case LoadCaptureState.None:
			this.Holder1.GetComponent<Animation>().Play(AnimationUnit.ANIM_STRING[0]);
			this.HeroRotater.enabled = true;
			return;
		case LoadCaptureState.Returning:
			this.Holder1.GetComponent<Animation>().Play(AnimationUnit.ANIM_STRING[1]);
			this.HeroRotater.enabled = false;
			return;
		case LoadCaptureState.Dead:
		{
			Animation component = this.Holder1.GetComponent<Animation>();
			component.clip = component.GetClip(AnimationUnit.ANIM_STRING[7]);
			component.Play(AnimationUnit.ANIM_STRING[7], PlayMode.StopAll);
			component[AnimationUnit.ANIM_STRING[7]].normalizedTime = 1f;
			this.Hero_PosRT.localEulerAngles = new Vector3(320f, 0f, 0f);
			localRotation = new Quaternion(0f, 0f, 0f, 0f);
			localRotation.eulerAngles = new Vector3(0f, (float)this.sHero.Camera_Angle_Prison, 0f);
			this.Holder1.transform.localRotation = localRotation;
			this.Holder1.transform.localScale = new Vector3((float)this.sHero.CameraScaleRate, (float)this.sHero.CameraScaleRate, (float)this.sHero.CameraScaleRate);
			this.Holder1.transform.localPosition = new Vector3((float)(this.sHero.CameraYAxis_Prison - 500), 0f, (float)(this.sHero.CameraXAxis_Prison - 500));
			this.HeroRotater.enabled = false;
			this.DefaultActionLateUpdate = false;
			return;
		}
		}
		this.Holder1.GetComponent<Animation>().Play(AnimationUnit.ANIM_STRING[9]);
		this.HeroRotater.enabled = false;
	}

	// Token: 0x06001E21 RID: 7713 RVA: 0x00397904 File Offset: 0x00395B04
	private void SetPopUp(bool bPop)
	{
		if (this.popUp == bPop)
		{
			return;
		}
		this.popUp = bPop;
		this.PopupPanel.gameObject.SetActive(this.popUp);
		bool flag = DataManager.MapDataController.IsWorldKing() | DataManager.MapDataController.IsWorldChief();
		if ((DataManager.MapDataController.IsKing() || DataManager.MapDataController.IsKingdomChief()) && DataManager.MapDataController.kingdomData.kingdomID == this.DM.mLordProfile.KindomID)
		{
			flag = true;
		}
		if ((DataManager.MapDataController.IsNobilityKing() || DataManager.MapDataController.IsNobilityChief()) && ActivityManager.Instance.CheckCanonizationNoility(this.DM.mLordProfile.KindomID) && this.DM.mLordProfile.NobilityTitle != 1)
		{
			flag = true;
		}
		int num = 0;
		RectTransform component;
		if (this.DM.RoleAlliance.Rank < AllianceRank.RANK4 || this.DM.mLordProfile.AlliRank > 0)
		{
			this.PopupPanel.GetChild(0).GetChild(2).gameObject.SetActive(false);
			component = this.PopupPanel.GetChild(0).GetComponent<RectTransform>();
			component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 300f);
			component.anchoredPosition = Vector2.zero;
			component = this.PopupPanel.GetChild(0).GetChild(1).GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(0.5f, -194.5f);
		}
		else
		{
			this.PopupPanel.GetChild(0).GetChild(2).gameObject.SetActive(true);
			component = this.PopupPanel.GetChild(0).GetComponent<RectTransform>();
			component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 378f);
			component.anchoredPosition = Vector2.zero;
			component = this.PopupPanel.GetChild(0).GetChild(1).GetComponent<RectTransform>();
			component.anchoredPosition = new Vector2(0.5f, -276.5f);
			num++;
		}
		num++;
		this.PopupPanel.GetChild(0).GetChild(1).gameObject.SetActive(true);
		UIText component2 = this.PopupPanel.GetChild(0).GetChild(1).GetChild(1).GetComponent<UIText>();
		if (this.DM.FindBlackList(this.DM.mLordProfile.PlayerName))
		{
			component2.text = this.DM.mStringTable.GetStringByID(8213u);
		}
		else
		{
			component2.text = this.DM.mStringTable.GetStringByID(8212u);
		}
		num++;
		if (this.DM.RoleAlliance.Rank > AllianceRank.NULL && this.DM.RoleAlliance.Id == this.DM.mLordProfile.AlliID && this.OpenKind == EUILordInfoLayout.LordOther)
		{
			this.PopupPanel.GetChild(0).GetChild(4).gameObject.SetActive(true);
			this.PopupPanel.GetChild(0).GetChild(3).gameObject.SetActive(true);
			num += 2;
			this.PopupPanel.GetChild(0).GetChild(6).gameObject.SetActive(true);
			component = this.PopupPanel.GetChild(0).GetChild(6).GetComponent<RectTransform>();
			component.gameObject.SetActive(true);
			component.anchoredPosition = new Vector2(0.5f, -116f - (float)(78 * num));
			num++;
		}
		else
		{
			this.PopupPanel.GetChild(0).GetChild(4).gameObject.SetActive(false);
			this.PopupPanel.GetChild(0).GetChild(3).gameObject.SetActive(false);
			this.PopupPanel.GetChild(0).GetChild(6).gameObject.SetActive(false);
		}
		if (flag && this.OpenKind == EUILordInfoLayout.LordOther)
		{
			component = this.PopupPanel.GetChild(0).GetChild(5).GetComponent<RectTransform>();
			component.gameObject.SetActive(true);
			component.anchoredPosition = new Vector2(0.5f, -116f - (float)(78 * num));
			num++;
		}
		else
		{
			this.PopupPanel.GetChild(0).GetChild(5).gameObject.SetActive(false);
		}
		Debug.Log("Block count :" + num);
		component = this.PopupPanel.GetChild(0).GetComponent<RectTransform>();
		component.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (float)(136 + 78 * num));
		component.anchoredPosition = Vector2.zero;
	}

	// Token: 0x06001E22 RID: 7714 RVA: 0x00397DA4 File Offset: 0x00395FA4
	public void OpenTitleGive()
	{
		bool flag = DataManager.MapDataController.IsKing();
		if (flag)
		{
			flag = (DataManager.MapDataController.kingdomData.kingdomID == this.DM.mLordProfile.KindomID);
		}
		bool flag2 = DataManager.MapDataController.IsWorldKing();
		if (flag && flag2)
		{
			GUIManager.Instance.OpenCanonizedPanel(this.DM.mLordProfile.PlayerName, 1, 3);
		}
		else if (flag)
		{
			TitleManager.Instance.OpenTitleSet(this.DM.mLordProfile.PlayerName);
		}
		else if (flag2)
		{
			TitleManager.Instance.OpenTitleListW(this.DM.mLordProfile.PlayerName);
		}
	}

	// Token: 0x04005DCC RID: 24012
	private const int TitleSPKind = 10000;

	// Token: 0x04005DCD RID: 24013
	private const int WTitleSPKind = 10001;

	// Token: 0x04005DCE RID: 24014
	private const int FTitleSPKind = 10002;

	// Token: 0x04005DCF RID: 24015
	private Transform AGS_Form;

	// Token: 0x04005DD0 RID: 24016
	private UISpritesArray AGS_bgPanel;

	// Token: 0x04005DD1 RID: 24017
	private UISpritesArray AGS_btn_BuffInfo;

	// Token: 0x04005DD2 RID: 24018
	private UISpritesArray AGS_HeadBGImage;

	// Token: 0x04005DD3 RID: 24019
	private UISpritesArray AGS_GuildRank;

	// Token: 0x04005DD4 RID: 24020
	private UISpritesArray AGS_GuildLogo;

	// Token: 0x04005DD5 RID: 24021
	private UISpritesArray AGS_HeroBadge;

	// Token: 0x04005DD6 RID: 24022
	private ScrollPanel AGS_ScrollPanel;

	// Token: 0x04005DD7 RID: 24023
	private Transform Hero_Pos;

	// Token: 0x04005DD8 RID: 24024
	private RectTransform Hero_PosRT;

	// Token: 0x04005DD9 RID: 24025
	private RectTransform LightRT;

	// Token: 0x04005DDA RID: 24026
	private RectTransform[] UILEBtn;

	// Token: 0x04005DDB RID: 24027
	private Image HeroRank;

	// Token: 0x04005DDC RID: 24028
	private RectTransform headInfoPanel;

	// Token: 0x04005DDD RID: 24029
	private RectTransform SideBtnPanel;

	// Token: 0x04005DDE RID: 24030
	private RectTransform ItemPanel;

	// Token: 0x04005DDF RID: 24031
	private RectTransform TitlePanel;

	// Token: 0x04005DE0 RID: 24032
	private RectTransform ScrollPanel;

	// Token: 0x04005DE1 RID: 24033
	private RectTransform PopupPanel;

	// Token: 0x04005DE2 RID: 24034
	private RectTransform HintPanel;

	// Token: 0x04005DE3 RID: 24035
	private RectTransform JailerPanel;

	// Token: 0x04005DE4 RID: 24036
	private RectTransform RescurePanel;

	// Token: 0x04005DE5 RID: 24037
	private RectTransform CaptureBar;

	// Token: 0x04005DE6 RID: 24038
	private UIBtnDrag HeroRotater;

	// Token: 0x04005DE7 RID: 24039
	public RectTransform CoordBtnRT;

	// Token: 0x04005DE8 RID: 24040
	private int AssetKey1;

	// Token: 0x04005DE9 RID: 24041
	private int AssetKey2;

	// Token: 0x04005DEA RID: 24042
	private AssetBundle bundle;

	// Token: 0x04005DEB RID: 24043
	private AssetBundleRequest bundleRequest;

	// Token: 0x04005DEC RID: 24044
	private GameObject Holder1;

	// Token: 0x04005DED RID: 24045
	private GameObject Holder2;

	// Token: 0x04005DEE RID: 24046
	private UILordInfo.eModelLoadingStep LoadingStep;

	// Token: 0x04005DEF RID: 24047
	private CString Header_NameText;

	// Token: 0x04005DF0 RID: 24048
	private Door door;

	// Token: 0x04005DF1 RID: 24049
	private DataManager DM;

	// Token: 0x04005DF2 RID: 24050
	private EUILordInfoLayout OpenKind;

	// Token: 0x04005DF3 RID: 24051
	private Hero sHero;

	// Token: 0x04005DF4 RID: 24052
	private bool popUp;

	// Token: 0x04005DF5 RID: 24053
	private bool scrollPanelInit;

	// Token: 0x04005DF6 RID: 24054
	private List<float> SPHeights;

	// Token: 0x04005DF7 RID: 24055
	private CString[] tmpLordString = new CString[18];

	// Token: 0x04005DF8 RID: 24056
	private CString[] tmpString = new CString[18];

	// Token: 0x04005DF9 RID: 24057
	private CString[] JailerStr = new CString[4];

	// Token: 0x04005DFA RID: 24058
	private CString hintString;

	// Token: 0x04005DFB RID: 24059
	private CString countDown;

	// Token: 0x04005DFC RID: 24060
	private CString PopStr;

	// Token: 0x04005DFD RID: 24061
	private CString EnStr;

	// Token: 0x04005DFE RID: 24062
	private CString TitleSPItemText;

	// Token: 0x04005DFF RID: 24063
	private CString TitleSPItemText2;

	// Token: 0x04005E00 RID: 24064
	private CString TitleSPItemText3;

	// Token: 0x04005E01 RID: 24065
	private List<eSPDisplayType> Barkind;

	// Token: 0x04005E02 RID: 24066
	private List<int> EnhanceShowedIdx;

	// Token: 0x04005E03 RID: 24067
	private bool isSameAlli;

	// Token: 0x04005E04 RID: 24068
	private int lastUpdateIdx = -1;

	// Token: 0x04005E05 RID: 24069
	private Image BarLight;

	// Token: 0x04005E06 RID: 24070
	private float GetPointTime;

	// Token: 0x04005E07 RID: 24071
	private float NextActionTime;

	// Token: 0x04005E08 RID: 24072
	private bool isMonsterOpen;

	// Token: 0x04005E09 RID: 24073
	private long MonsterTime = -1L;

	// Token: 0x04005E0A RID: 24074
	private Image[] LEquipLight = new Image[8];

	// Token: 0x04005E0B RID: 24075
	private GameObject[] ParticleGO = new GameObject[8];

	// Token: 0x04005E0C RID: 24076
	private EUILordInfoLayout HasBeenPage;

	// Token: 0x04005E0D RID: 24077
	private bool StatDataReady;

	// Token: 0x04005E0E RID: 24078
	private bool freeRes;

	// Token: 0x04005E0F RID: 24079
	private bool executeUpdated;

	// Token: 0x04005E10 RID: 24080
	private bool poisonUpdated;

	// Token: 0x04005E11 RID: 24081
	public static bool OpenTransport = false;

	// Token: 0x04005E12 RID: 24082
	private RectTransform TitleSPItem;

	// Token: 0x04005E13 RID: 24083
	private RectTransform TitleSPItem2;

	// Token: 0x04005E14 RID: 24084
	private RectTransform TitleSPItem3;

	// Token: 0x04005E15 RID: 24085
	private int TitleSPItemIdx;

	// Token: 0x04005E16 RID: 24086
	private int TitleSPItemIdx2;

	// Token: 0x04005E17 RID: 24087
	private int TitleSPItemIdx3;

	// Token: 0x04005E18 RID: 24088
	private static readonly uint[,] RecordFields = new uint[,]
	{
		{
			7301u,
			0u,
			0u
		},
		{
			7305u,
			1u,
			1u
		},
		{
			7306u,
			2u,
			2u
		},
		{
			7307u,
			1u,
			3u
		},
		{
			7308u,
			2u,
			4u
		},
		{
			7309u,
			1u,
			5u
		},
		{
			7310u,
			2u,
			6u
		},
		{
			7311u,
			1u,
			7u
		},
		{
			7312u,
			2u,
			8u
		},
		{
			7313u,
			1u,
			9u
		},
		{
			7314u,
			2u,
			10u
		},
		{
			7315u,
			1u,
			11u
		},
		{
			7316u,
			2u,
			12u
		},
		{
			7317u,
			1u,
			13u
		},
		{
			7318u,
			2u,
			14u
		},
		{
			7319u,
			1u,
			15u
		},
		{
			7320u,
			2u,
			16u
		},
		{
			11176u,
			1u,
			46u
		},
		{
			11177u,
			1u,
			47u
		},
		{
			7302u,
			0u,
			17u
		},
		{
			7321u,
			1u,
			18u
		},
		{
			7322u,
			2u,
			19u
		},
		{
			7323u,
			1u,
			20u
		},
		{
			7324u,
			2u,
			21u
		},
		{
			7325u,
			1u,
			22u
		},
		{
			7326u,
			2u,
			23u
		},
		{
			9371u,
			1u,
			44u
		},
		{
			11178u,
			1u,
			45u
		},
		{
			7303u,
			0u,
			24u
		},
		{
			7327u,
			1u,
			25u
		},
		{
			7328u,
			2u,
			26u
		},
		{
			7329u,
			1u,
			27u
		},
		{
			7330u,
			2u,
			28u
		},
		{
			7331u,
			1u,
			29u
		},
		{
			7332u,
			2u,
			30u
		},
		{
			7333u,
			1u,
			31u
		},
		{
			9125u,
			0u,
			40u
		},
		{
			9160u,
			1u,
			41u
		},
		{
			9159u,
			2u,
			42u
		},
		{
			9161u,
			1u,
			43u
		},
		{
			7304u,
			0u,
			32u
		},
		{
			7334u,
			1u,
			33u
		},
		{
			7336u,
			2u,
			34u
		},
		{
			7335u,
			1u,
			35u
		},
		{
			7337u,
			2u,
			36u
		},
		{
			7338u,
			1u,
			37u
		},
		{
			7340u,
			2u,
			38u
		},
		{
			7341u,
			1u,
			39u
		}
	};

	// Token: 0x04005E19 RID: 24089
	private Material mat_AlphaBlend_back;

	// Token: 0x04005E1A RID: 24090
	private Material mat_AlphaBlend_front;

	// Token: 0x04005E1B RID: 24091
	private Material mat_Additive;

	// Token: 0x04005E1C RID: 24092
	private UIButtonHint lastHint;

	// Token: 0x04005E1D RID: 24093
	private bool DefaultActionLateUpdate;

	// Token: 0x02000601 RID: 1537
	private enum e_AGS_UI_LordInfo_Editor
	{
		// Token: 0x04005E1F RID: 24095
		bgPanel,
		// Token: 0x04005E20 RID: 24096
		closeImg,
		// Token: 0x04005E21 RID: 24097
		HeaderLayer,
		// Token: 0x04005E22 RID: 24098
		SideBtnLayer,
		// Token: 0x04005E23 RID: 24099
		MoveRound,
		// Token: 0x04005E24 RID: 24100
		ItemLayer,
		// Token: 0x04005E25 RID: 24101
		EnBar,
		// Token: 0x04005E26 RID: 24102
		LevelIcon,
		// Token: 0x04005E27 RID: 24103
		ChangeBtn,
		// Token: 0x04005E28 RID: 24104
		HeroRank,
		// Token: 0x04005E29 RID: 24105
		HeroBadge,
		// Token: 0x04005E2A RID: 24106
		T3DObject,
		// Token: 0x04005E2B RID: 24107
		LightObject,
		// Token: 0x04005E2C RID: 24108
		TitlePanel,
		// Token: 0x04005E2D RID: 24109
		ScrollPanelLayer,
		// Token: 0x04005E2E RID: 24110
		JailerLayer,
		// Token: 0x04005E2F RID: 24111
		RescureLayer,
		// Token: 0x04005E30 RID: 24112
		CaptureBarLayer,
		// Token: 0x04005E31 RID: 24113
		PopupLayer,
		// Token: 0x04005E32 RID: 24114
		Hint,
		// Token: 0x04005E33 RID: 24115
		Titlebg,
		// Token: 0x04005E34 RID: 24116
		ESportSideLayer
	}

	// Token: 0x02000602 RID: 1538
	private enum e_AGS_Panel
	{
		// Token: 0x04005E36 RID: 24118
		Panellayer,
		// Token: 0x04005E37 RID: 24119
		PanelCover
	}

	// Token: 0x02000603 RID: 1539
	private enum e_AGS_HeaderLayer
	{
		// Token: 0x04005E39 RID: 24121
		btn_BuffInfo,
		// Token: 0x04005E3A RID: 24122
		HeadBGImage,
		// Token: 0x04005E3B RID: 24123
		NameText,
		// Token: 0x04005E3C RID: 24124
		RenameBtn,
		// Token: 0x04005E3D RID: 24125
		MessageBtn,
		// Token: 0x04005E3E RID: 24126
		PowerValue,
		// Token: 0x04005E3F RID: 24127
		KillCount,
		// Token: 0x04005E40 RID: 24128
		GuildInfoBtn,
		// Token: 0x04005E41 RID: 24129
		GuildRank,
		// Token: 0x04005E42 RID: 24130
		KillIcon,
		// Token: 0x04005E43 RID: 24131
		VIPIcon,
		// Token: 0x04005E44 RID: 24132
		VIPLevel,
		// Token: 0x04005E45 RID: 24133
		InfoIcon,
		// Token: 0x04005E46 RID: 24134
		KillHint,
		// Token: 0x04005E47 RID: 24135
		PowerHint,
		// Token: 0x04005E48 RID: 24136
		KingdomHint,
		// Token: 0x04005E49 RID: 24137
		ESProfileBtn
	}

	// Token: 0x02000604 RID: 1540
	private enum e_AGS_GuildInfoBtn
	{
		// Token: 0x04005E4B RID: 24139
		GuildLogo
	}

	// Token: 0x02000605 RID: 1541
	private enum e_AGS_SideBtnLayer
	{
		// Token: 0x04005E4D RID: 24141
		Btn1,
		// Token: 0x04005E4E RID: 24142
		Btn2,
		// Token: 0x04005E4F RID: 24143
		Btn3,
		// Token: 0x04005E50 RID: 24144
		Btn4
	}

	// Token: 0x02000606 RID: 1542
	private enum e_AGS_ItemLayer
	{
		// Token: 0x04005E52 RID: 24146
		Shadow1,
		// Token: 0x04005E53 RID: 24147
		Shadow2,
		// Token: 0x04005E54 RID: 24148
		Shadow3,
		// Token: 0x04005E55 RID: 24149
		Shadow4,
		// Token: 0x04005E56 RID: 24150
		Shadow5,
		// Token: 0x04005E57 RID: 24151
		Shadow6,
		// Token: 0x04005E58 RID: 24152
		Shadow7,
		// Token: 0x04005E59 RID: 24153
		Shadow8,
		// Token: 0x04005E5A RID: 24154
		Pos1,
		// Token: 0x04005E5B RID: 24155
		Pos2,
		// Token: 0x04005E5C RID: 24156
		Pos3,
		// Token: 0x04005E5D RID: 24157
		Pos4,
		// Token: 0x04005E5E RID: 24158
		Pos5,
		// Token: 0x04005E5F RID: 24159
		Pos6,
		// Token: 0x04005E60 RID: 24160
		Pos7,
		// Token: 0x04005E61 RID: 24161
		Pos8,
		// Token: 0x04005E62 RID: 24162
		UILEBtn1,
		// Token: 0x04005E63 RID: 24163
		UILEBtn2,
		// Token: 0x04005E64 RID: 24164
		UILEBtn3,
		// Token: 0x04005E65 RID: 24165
		UILEBtn4,
		// Token: 0x04005E66 RID: 24166
		UILEBtn5,
		// Token: 0x04005E67 RID: 24167
		UILEBtn6,
		// Token: 0x04005E68 RID: 24168
		UILEBtn7,
		// Token: 0x04005E69 RID: 24169
		UILEBtn8,
		// Token: 0x04005E6A RID: 24170
		Lock7,
		// Token: 0x04005E6B RID: 24171
		Lock8
	}

	// Token: 0x02000607 RID: 1543
	private enum e_AGS_EnBar
	{
		// Token: 0x04005E6D RID: 24173
		EnBarBack,
		// Token: 0x04005E6E RID: 24174
		ExpBarBack,
		// Token: 0x04005E6F RID: 24175
		EnBarValue,
		// Token: 0x04005E70 RID: 24176
		BarValue,
		// Token: 0x04005E71 RID: 24177
		EnButton,
		// Token: 0x04005E72 RID: 24178
		ExpButton,
		// Token: 0x04005E73 RID: 24179
		Image,
		// Token: 0x04005E74 RID: 24180
		ENText,
		// Token: 0x04005E75 RID: 24181
		ExpText
	}

	// Token: 0x02000608 RID: 1544
	private enum e_AGS_LevelIcon
	{
		// Token: 0x04005E77 RID: 24183
		LevelText,
		// Token: 0x04005E78 RID: 24184
		CastleLevelIcon
	}

	// Token: 0x02000609 RID: 1545
	private enum e_AGS_LightObject
	{
		// Token: 0x04005E7A RID: 24186
		LightGroup1,
		// Token: 0x04005E7B RID: 24187
		LightGroup2
	}

	// Token: 0x0200060A RID: 1546
	private enum e_AGS_TitlePanel
	{
		// Token: 0x04005E7D RID: 24189
		TitleLabel,
		// Token: 0x04005E7E RID: 24190
		TitleIcon,
		// Token: 0x04005E7F RID: 24191
		TitleName,
		// Token: 0x04005E80 RID: 24192
		TitleLabel2,
		// Token: 0x04005E81 RID: 24193
		TitleIcon2,
		// Token: 0x04005E82 RID: 24194
		TitleName2,
		// Token: 0x04005E83 RID: 24195
		TitleLabel3,
		// Token: 0x04005E84 RID: 24196
		TitleIcon3,
		// Token: 0x04005E85 RID: 24197
		TitleName3
	}

	// Token: 0x0200060B RID: 1547
	private enum e_AGS_ScrollPanelLayer
	{
		// Token: 0x04005E87 RID: 24199
		ScrollPanel,
		// Token: 0x04005E88 RID: 24200
		ScrollItem,
		// Token: 0x04005E89 RID: 24201
		TitlePanel,
		// Token: 0x04005E8A RID: 24202
		TitlePanel2,
		// Token: 0x04005E8B RID: 24203
		TitlePanel3
	}

	// Token: 0x0200060C RID: 1548
	private enum e_AGS_ScrollItem
	{
		// Token: 0x04005E8D RID: 24205
		TitleBar,
		// Token: 0x04005E8E RID: 24206
		NormalBar
	}

	// Token: 0x0200060D RID: 1549
	private enum e_AGS_TitleBar
	{
		// Token: 0x04005E90 RID: 24208
		Text,
		// Token: 0x04005E91 RID: 24209
		Text2
	}

	// Token: 0x0200060E RID: 1550
	private enum e_AGS_NormalBar
	{
		// Token: 0x04005E93 RID: 24211
		Bg,
		// Token: 0x04005E94 RID: 24212
		Text1,
		// Token: 0x04005E95 RID: 24213
		Text2,
		// Token: 0x04005E96 RID: 24214
		Text3
	}

	// Token: 0x0200060F RID: 1551
	private enum e_AGS_TitlePanel2
	{
		// Token: 0x04005E98 RID: 24216
		bg,
		// Token: 0x04005E99 RID: 24217
		icon,
		// Token: 0x04005E9A RID: 24218
		Text,
		// Token: 0x04005E9B RID: 24219
		Text2
	}

	// Token: 0x02000610 RID: 1552
	private enum e_AGS_JailerLayer
	{
		// Token: 0x04005E9D RID: 24221
		panelbg,
		// Token: 0x04005E9E RID: 24222
		HeadBg,
		// Token: 0x04005E9F RID: 24223
		Head,
		// Token: 0x04005EA0 RID: 24224
		MailBtm,
		// Token: 0x04005EA1 RID: 24225
		MapPointBtn,
		// Token: 0x04005EA2 RID: 24226
		Holder,
		// Token: 0x04005EA3 RID: 24227
		HolderName,
		// Token: 0x04005EA4 RID: 24228
		HolderMapPos,
		// Token: 0x04005EA5 RID: 24229
		HolderUnderLine,
		// Token: 0x04005EA6 RID: 24230
		BountyText,
		// Token: 0x04005EA7 RID: 24231
		BountyValue,
		// Token: 0x04005EA8 RID: 24232
		Coin,
		// Token: 0x04005EA9 RID: 24233
		BountyBtn,
		// Token: 0x04005EAA RID: 24234
		shadow,
		// Token: 0x04005EAB RID: 24235
		RensomBg,
		// Token: 0x04005EAC RID: 24236
		RensomText,
		// Token: 0x04005EAD RID: 24237
		RensomCoin,
		// Token: 0x04005EAE RID: 24238
		RensomValue,
		// Token: 0x04005EAF RID: 24239
		PayRensomBtn
	}

	// Token: 0x02000611 RID: 1553
	private enum e_AGS_CaptureBarLayer
	{
		// Token: 0x04005EB1 RID: 24241
		BarLight,
		// Token: 0x04005EB2 RID: 24242
		BarBg,
		// Token: 0x04005EB3 RID: 24243
		Bar,
		// Token: 0x04005EB4 RID: 24244
		BarStat,
		// Token: 0x04005EB5 RID: 24245
		BarTime,
		// Token: 0x04005EB6 RID: 24246
		Res,
		// Token: 0x04005EB7 RID: 24247
		SpeedUp
	}

	// Token: 0x02000612 RID: 1554
	private enum e_AGS_PopupLayer
	{
		// Token: 0x04005EB9 RID: 24249
		OverPanel
	}

	// Token: 0x02000613 RID: 1555
	private enum e_AGS_OverPanel
	{
		// Token: 0x04005EBB RID: 24251
		POPMail,
		// Token: 0x04005EBC RID: 24252
		POPBlock,
		// Token: 0x04005EBD RID: 24253
		POPAdd,
		// Token: 0x04005EBE RID: 24254
		POPResourceTransport,
		// Token: 0x04005EBF RID: 24255
		POPReinforce,
		// Token: 0x04005EC0 RID: 24256
		POPRanking,
		// Token: 0x04005EC1 RID: 24257
		POPReinforce2
	}

	// Token: 0x02000614 RID: 1556
	private enum e_AGS_POPMail
	{
		// Token: 0x04005EC3 RID: 24259
		Image,
		// Token: 0x04005EC4 RID: 24260
		Text
	}

	// Token: 0x02000615 RID: 1557
	private enum e_AGS_POPBlock
	{
		// Token: 0x04005EC6 RID: 24262
		Image,
		// Token: 0x04005EC7 RID: 24263
		Text
	}

	// Token: 0x02000616 RID: 1558
	private enum e_AGS_POPAdd
	{
		// Token: 0x04005EC9 RID: 24265
		Image,
		// Token: 0x04005ECA RID: 24266
		Text
	}

	// Token: 0x02000617 RID: 1559
	private enum e_AGS_Hint
	{
		// Token: 0x04005ECC RID: 24268
		HintPanel,
		// Token: 0x04005ECD RID: 24269
		HintText
	}

	// Token: 0x02000618 RID: 1560
	private enum e_AGS_Titlebg
	{
		// Token: 0x04005ECF RID: 24271
		Title
	}

	// Token: 0x02000619 RID: 1561
	private enum e_AGS_ESportSideLayer
	{
		// Token: 0x04005ED1 RID: 24273
		SideC1,
		// Token: 0x04005ED2 RID: 24274
		SideC2,
		// Token: 0x04005ED3 RID: 24275
		SideC3,
		// Token: 0x04005ED4 RID: 24276
		SideC4
	}

	// Token: 0x0200061A RID: 1562
	private enum e_AGS_SideC1
	{
		// Token: 0x04005ED6 RID: 24278
		BgLight,
		// Token: 0x04005ED7 RID: 24279
		IconBg,
		// Token: 0x04005ED8 RID: 24280
		IconLight
	}

	// Token: 0x0200061B RID: 1563
	private enum eModelLoadingStep
	{
		// Token: 0x04005EDA RID: 24282
		Start,
		// Token: 0x04005EDB RID: 24283
		WaitforHero,
		// Token: 0x04005EDC RID: 24284
		HeroReady,
		// Token: 0x04005EDD RID: 24285
		WaitforCage,
		// Token: 0x04005EDE RID: 24286
		Done
	}
}
