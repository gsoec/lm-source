using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002DD RID: 733
public class UIAlliance_Gift : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUILEBtnClickHandler
{
	// Token: 0x06000ED5 RID: 3797 RVA: 0x00191DA4 File Offset: 0x0018FFA4
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.GameT = base.gameObject.transform;
		this.m_Mat = this.door.LoadMaterial();
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		for (int i = 0; i < 5; i++)
		{
			this.mStatus[i] = this.DM.mStringTable.GetStringByID((uint)((ushort)(7009 + i)));
		}
		this.Cstr_Lv = StringManager.Instance.SpawnString(30);
		this.Cstr_BarValue = StringManager.Instance.SpawnString(30);
		this.Cstr_GiftMax = StringManager.Instance.SpawnString(30);
		this.Cstr_KeyValue = StringManager.Instance.SpawnString(30);
		for (int j = 0; j < 6; j++)
		{
			this.Cstr_ItemTime[j] = StringManager.Instance.SpawnString(30);
			this.Cstr_ItemExp[j] = StringManager.Instance.SpawnString(30);
			this.Cstr_ItemNum[j] = StringManager.Instance.SpawnString(100);
			this.Cstr_ItemName[j] = StringManager.Instance.SpawnString(30);
		}
		this.Tmp = this.GameT.GetChild(0);
		Transform child = this.Tmp.GetChild(1).GetChild(0);
		this.text_tmpStr[0] = child.GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7001u);
		child = this.Tmp.GetChild(2).GetChild(0);
		this.text_Lv = child.GetComponent<UIText>();
		this.text_Lv.font = this.TTFont;
		uint num = 0u;
		for (int k = 0; k < (int)(this.DM.RoleAlliance.GiftLv + 1); k++)
		{
			num += this.DM.AllianceLvUpData.GetRecordByKey((ushort)(k + 1)).LvExp;
		}
		this.Cstr_Lv.ClearString();
		this.Cstr_Lv.IntToFormat((long)this.DM.RoleAlliance.GiftLv, 1, false);
		this.Cstr_Lv.AppendFormat(this.DM.mStringTable.GetStringByID(7003u));
		this.text_Lv.text = this.Cstr_Lv.ToString();
		this.text_Lv.SetAllDirty();
		this.text_Lv.cachedTextGenerator.Invalidate();
		child = this.Tmp.GetChild(3).GetChild(0);
		this.ImgBar_RT = child.GetComponent<RectTransform>();
		child = this.Tmp.GetChild(3).GetChild(1);
		this.text_BarValue = child.GetComponent<UIText>();
		this.text_BarValue.font = this.TTFont;
		this.Cstr_BarValue.ClearString();
		if (this.GUIM.IsArabic)
		{
			this.Cstr_BarValue.IntToFormat((long)((ulong)num), 1, true);
			this.Cstr_BarValue.IntToFormat((long)((ulong)this.DM.RoleAlliance.GiftExp), 1, true);
		}
		else
		{
			this.Cstr_BarValue.IntToFormat((long)((ulong)this.DM.RoleAlliance.GiftExp), 1, true);
			this.Cstr_BarValue.IntToFormat((long)((ulong)num), 1, true);
		}
		this.Cstr_BarValue.AppendFormat(this.DM.mStringTable.GetStringByID(7004u));
		this.text_BarValue.text = this.Cstr_BarValue.ToString();
		this.text_BarValue.SetAllDirty();
		this.text_BarValue.cachedTextGenerator.Invalidate();
		this.ImgBar_RT.sizeDelta = new Vector2((float)(422.0 * (this.DM.RoleAlliance.GiftExp / num)), this.ImgBar_RT.sizeDelta.y);
		child = this.Tmp.GetChild(3).GetChild(2);
		this.text_GiftMax = child.GetComponent<UIText>();
		this.text_GiftMax.font = this.TTFont;
		this.Cstr_GiftMax.ClearString();
		this.Cstr_GiftMax.IntToFormat((long)this.DM.mShowListIdx.Count, 1, true);
		this.Cstr_GiftMax.AppendFormat(this.DM.mStringTable.GetStringByID(7005u));
		this.text_GiftMax.text = this.Cstr_GiftMax.ToString();
		child = this.Tmp.GetChild(5).GetChild(0);
		this.text_tmpStr[1] = child.GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(7006u);
		this.Light_T = this.Tmp.GetChild(6);
		this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.DM.RoleAlliance.PackItemID);
		child = this.Tmp.GetChild(7);
		this.Img_GiftNew = child.GetComponent<Image>();
		this.Img_GiftNew.sprite = this.SArray.m_Sprites[(int)(this.tmpEQ.Color - 1)];
		this.Gift_NewRT = child.GetComponent<RectTransform>();
		child = this.Tmp.GetChild(9).GetChild(0);
		this.text_KeyValue = child.GetComponent<UIText>();
		this.text_KeyValue.font = this.TTFont;
		this.Cstr_KeyValue.ClearString();
		if (this.GUIM.IsArabic)
		{
			this.Cstr_KeyValue.IntToFormat((long)(this.tmpEQ.PropertiesInfo[1].PropertiesValue * this.tmpEQ.PropertiesInfo[5].PropertiesValue), 1, true);
			this.Cstr_KeyValue.IntToFormat((long)((ulong)this.DM.RoleAlliance.PackPoint), 1, true);
		}
		else
		{
			this.Cstr_KeyValue.IntToFormat((long)((ulong)this.DM.RoleAlliance.PackPoint), 1, true);
			this.Cstr_KeyValue.IntToFormat((long)(this.tmpEQ.PropertiesInfo[1].PropertiesValue * this.tmpEQ.PropertiesInfo[5].PropertiesValue), 1, true);
		}
		this.Cstr_KeyValue.AppendFormat(this.DM.mStringTable.GetStringByID(7004u));
		this.text_KeyValue.text = this.Cstr_KeyValue.ToString();
		this.text_KeyValue.SetAllDirty();
		this.text_KeyValue.cachedTextGenerator.Invalidate();
		if (this.GUIM.IsArabic)
		{
			this.text_KeyValue.UpdateArabicPos();
		}
		child = this.Tmp.GetChild(8);
		this.Gift_NameRT = child.GetComponent<RectTransform>();
		child = this.Tmp.GetChild(8).GetChild(0);
		this.text_GiftName = child.GetComponent<UIText>();
		this.text_GiftName.font = this.TTFont;
		this.text_GiftName.text = this.DM.mStringTable.GetStringByID((uint)this.tmpEQ.EquipName);
		child = this.Tmp.GetChild(10).GetChild(0);
		this.Img_KeyBar = child.GetComponent<Image>();
		this.Img_KeyBar.fillAmount = this.DM.RoleAlliance.PackPoint / (float)(this.tmpEQ.PropertiesInfo[1].PropertiesValue * this.tmpEQ.PropertiesInfo[5].PropertiesValue);
		child = this.Tmp.GetChild(11);
		this.btn_I = child.GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_I.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_I.m_Handler = this;
		this.btn_I.m_BtnID1 = 1;
		this.btn_I.m_EffectType = e_EffectType.e_Scale;
		this.btn_I.transition = Selectable.Transition.None;
		child = this.Tmp.GetChild(12);
		this.btn_Delete = child.GetComponent<UIButton>();
		this.btn_DeleteRT = child.GetComponent<RectTransform>();
		this.btn_Delete.m_Handler = this;
		this.btn_Delete.m_BtnID1 = 2;
		this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
		this.btn_Delete.transition = Selectable.Transition.None;
		child = this.Tmp.GetChild(13);
		this.btn_All = child.GetComponent<UIButton>();
		this.btn_All.m_Handler = this;
		this.btn_All.m_BtnID1 = 6;
		this.btn_All.m_EffectType = e_EffectType.e_Scale;
		this.btn_All.transition = Selectable.Transition.None;
		if (this.DM.RoleAttr.VIPLevel >= 12)
		{
			this.btn_DeleteRT.anchoredPosition = new Vector2(this.btn_DeleteRT.anchoredPosition.x - 60f, this.btn_DeleteRT.anchoredPosition.y);
			this.btn_All.gameObject.SetActive(true);
		}
		this.Tmp = this.GameT.GetChild(1);
		RectTransform component = this.Tmp.GetComponent<RectTransform>();
		this.v2End = new Vector2(component.anchoredPosition.x, component.anchoredPosition.y);
		child = this.Tmp.GetChild(0);
		this.m_ScrollPanel = child.GetComponent<ScrollPanel>();
		child = this.Tmp.GetChild(1);
		this.Tmp = child.GetChild(1);
		UIHIBtn component2 = this.Tmp.GetComponent<UIHIBtn>();
		this.GUIM.InitianHeroItemImg(component2.transform, eHeroOrItem.Item, 1, 0, 0, 0, true, true, true, false);
		this.Tmp = child.GetChild(2);
		UILEBtn component3 = this.Tmp.GetComponent<UILEBtn>();
		this.GUIM.InitLordEquipImg(component3.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		component3.gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
		this.Tmp = child.GetChild(3);
		UIButton component4 = this.Tmp.GetComponent<UIButton>();
		component4.m_Handler = this;
		component4.m_BtnID1 = 3;
		component4.SoundIndex = 64;
		component4.m_EffectType = e_EffectType.e_Scale;
		component4.transition = Selectable.Transition.None;
		this.Tmp = child.GetChild(3).GetChild(0);
		UIText component5 = this.Tmp.GetComponent<UIText>();
		component5.font = this.TTFont;
		this.Tmp = child.GetChild(4);
		Image component6 = this.Tmp.GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			component6.transform.localScale = new Vector3(-1f, component6.transform.localScale.y, component6.transform.localScale.z);
		}
		this.Tmp = child.GetChild(5).GetChild(0);
		component5 = this.Tmp.GetComponent<UIText>();
		component5.font = this.TTFont;
		this.Tmp = child.GetChild(6);
		component6 = this.Tmp.GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			component6.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.Tmp = child.GetChild(6).GetChild(0);
		component5 = this.Tmp.GetComponent<UIText>();
		component5.font = this.TTFont;
		this.Tmp = child.GetChild(6).GetChild(1);
		component5 = this.Tmp.GetComponent<UIText>();
		component5.font = this.TTFont;
		this.Tmp = child.GetChild(7);
		component5 = this.Tmp.GetComponent<UIText>();
		component5.font = this.TTFont;
		this.Tmp = child.GetChild(8);
		component5 = this.Tmp.GetComponent<UIText>();
		component5.font = this.TTFont;
		this.tmplist.Clear();
		this.m_ScrollPanel.IntiScrollPanel(446f, 5f, 0f, this.tmplist, 6, this);
		this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.DM.RoleAlliance.PackItemID);
		this.Tmp = this.GameT.GetChild(2);
		this.Img_Gift = this.Tmp.GetComponent<Image>();
		this.Img_Gift.sprite = this.SArray.m_Sprites[(int)(this.tmpEQ.Color - 1)];
		this.GiftRT = this.Tmp.GetComponent<RectTransform>();
		this.Tmp = this.GameT.GetChild(3);
		this.Img_NoGift = this.Tmp.GetComponent<Image>();
		child = this.Tmp.GetChild(0);
		this.text_tmpStr[2] = child.GetComponent<UIText>();
		this.text_tmpStr[2].font = this.TTFont;
		this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(8408u);
		this.Tmp = this.GameT.GetChild(4);
		this.btn_Hint = this.Tmp.GetComponent<UIButton>();
		this.btn_Hint.m_Handler = this;
		this.btn_Hint.m_BtnID1 = 4;
		UIButtonHint uibuttonHint = this.btn_Hint.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		child = this.Tmp.GetChild(0);
		this.Img_GiftHint = child.GetComponent<Image>();
		this.Img_GiftHint.sprite = this.door.LoadSprite("UI_main_box_012");
		this.Img_GiftHint.material = this.door.LoadMaterial();
		this.text_GiftHint = child.GetChild(0).GetComponent<UIText>();
		this.text_GiftHint.font = this.TTFont;
		this.text_GiftHint.text = this.DM.mStringTable.GetStringByID(8480u);
		this.text_GiftHint.SetAllDirty();
		this.text_GiftHint.cachedTextGenerator.Invalidate();
		this.text_GiftHint.cachedTextGeneratorForLayout.Invalidate();
		if (this.text_GiftHint.preferredHeight > this.text_GiftHint.rectTransform.sizeDelta.y)
		{
			this.text_GiftHint.rectTransform.sizeDelta = new Vector2(this.text_GiftHint.rectTransform.sizeDelta.x, this.text_GiftHint.preferredHeight + 10f);
			this.Img_GiftHint.rectTransform.sizeDelta = new Vector2(this.Img_GiftHint.rectTransform.sizeDelta.x, this.text_GiftHint.preferredHeight + 20f);
		}
		uibuttonHint.ControlFadeOut = this.Img_GiftHint.gameObject;
		this.Tmp = this.GameT.GetChild(5);
		this.btn_LVHint = this.Tmp.GetComponent<UIButton>();
		this.btn_LVHint.m_Handler = this;
		this.btn_LVHint.m_BtnID1 = 5;
		uibuttonHint = this.btn_LVHint.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		child = this.Tmp.GetChild(0);
		this.Img_LVHint = child.GetComponent<Image>();
		this.Img_LVHint.sprite = this.door.LoadSprite("UI_main_box_012");
		this.Img_LVHint.material = this.door.LoadMaterial();
		this.text_LVHint = child.GetChild(0).GetComponent<UIText>();
		this.text_LVHint.font = this.TTFont;
		this.text_LVHint.text = this.DM.mStringTable.GetStringByID(8483u);
		this.text_LVHint.SetAllDirty();
		this.text_LVHint.cachedTextGenerator.Invalidate();
		this.text_LVHint.cachedTextGeneratorForLayout.Invalidate();
		if (this.text_LVHint.preferredHeight > this.text_LVHint.rectTransform.sizeDelta.y)
		{
			this.text_LVHint.rectTransform.sizeDelta = new Vector2(this.text_LVHint.rectTransform.sizeDelta.x, this.text_LVHint.preferredHeight + 10f);
			this.Img_LVHint.rectTransform.sizeDelta = new Vector2(this.Img_LVHint.rectTransform.sizeDelta.x, this.text_LVHint.preferredHeight + 30f);
		}
		uibuttonHint.ControlFadeOut = this.Img_LVHint.gameObject;
		component6 = this.GameT.GetChild(6).GetComponent<Image>();
		component6.sprite = this.door.LoadSprite("UI_main_close_base");
		component6.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			component6.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(6).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.m_Mat;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
		this.DM.bCDStart = true;
		if (!this.DM.bSendtoGetGift && this.DM.mShowListIdx.Count == 0 && this.DM.RoleAlliance.GiftNum == 0)
		{
			this.Img_NoGift.gameObject.SetActive(true);
			this.m_ScrollPanel.gameObject.SetActive(false);
			return;
		}
		if (this.DM.bSendtoGetGift)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_INFO;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Alliance_Gift);
			this.DM.bSendtoGetGift = false;
		}
		else
		{
			MessagePacket messagePacket2 = new MessagePacket(1024);
			messagePacket2.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_CHECKEXPIRED;
			messagePacket2.AddSeqId();
			messagePacket2.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Alliance_Gift);
		}
	}

	// Token: 0x06000ED6 RID: 3798 RVA: 0x00193030 File Offset: 0x00191230
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06000ED7 RID: 3799 RVA: 0x00193034 File Offset: 0x00191234
	public override void OnClose()
	{
		if (this.Cstr_Lv != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Lv);
		}
		if (this.Cstr_BarValue != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_BarValue);
		}
		if (this.Cstr_GiftMax != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_GiftMax);
		}
		if (this.Cstr_KeyValue != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_KeyValue);
		}
		for (int i = 0; i < 4; i++)
		{
			if (this.Cstr_ItemTime[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemTime[i]);
			}
			if (this.Cstr_ItemExp[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemExp[i]);
			}
			if (this.Cstr_ItemNum[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemNum[i]);
			}
			if (this.Cstr_ItemName[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemName[i]);
			}
		}
		this.DM.bCDStart = false;
		if (this.DM.bGetLeadItem)
		{
			this.DM.bGetLeadItem = false;
			if (this.DM.mLordEquip == null)
			{
				this.DM.mLordEquip = LordEquipData.Instance();
			}
			this.DM.mLordEquip.Scan_MaterialOrEquipIncreace();
		}
	}

	// Token: 0x06000ED8 RID: 3800 RVA: 0x0019319C File Offset: 0x0019139C
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
			this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(7001u), this.DM.mStringTable.GetStringByID(8407u), null, null, 0, 0, true, true);
			break;
		case 2:
		{
			uint maxValue = uint.MaxValue;
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_DELETEBOX;
			messagePacket.AddSeqId();
			messagePacket.Add(maxValue);
			messagePacket.Send(false);
			this.GUIM.ShowUILock(EUILock.Alliance_Gift);
			break;
		}
		case 3:
		{
			int btnID = sender.transform.parent.GetComponent<ScrollPanelItem>().m_BtnID1;
			float num = 0f;
			if (this.GUIM.bOpenOnIPhoneX)
			{
				num = this.GUIM.IPhoneX_DeltaX;
			}
			switch (this.DM.mListGift[this.DM.mShowListIdx[btnID]].Status)
			{
			case 0:
			{
				MessagePacket messagePacket2 = new MessagePacket(1024);
				messagePacket2.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_OPENBOX;
				messagePacket2.AddSeqId();
				messagePacket2.Add(this.DM.mListGift[this.DM.mShowListIdx[btnID]].SN);
				messagePacket2.Send(false);
				this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.DM.mListGift[this.DM.mShowListIdx[btnID]].BoxItemID);
				RectTransform component = sender.transform.parent.GetComponent<RectTransform>();
				RectTransform component2 = sender.transform.parent.parent.GetComponent<RectTransform>();
				RectTransform component3 = sender.transform.parent.parent.parent.parent.GetComponent<RectTransform>();
				this.GUIM.mStartV2 = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + component.anchoredPosition.x + component2.anchoredPosition.x + component3.anchoredPosition.x - component3.sizeDelta.x / 2f + 105f, this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - component.anchoredPosition.y - component2.anchoredPosition.y - component3.anchoredPosition.y - component3.sizeDelta.y / 2f + 51f);
				if (this.tmpEquip.PropertiesInfo[2].Propertieskey == 2)
				{
					this.GUIM.m_SpeciallyEffect.mUIGiftform = this.GameT.GetChild(0).GetChild(3);
					this.GUIM.m_SpeciallyEffect.UI_bezieEnd = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f - 376f - num, -(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - 200f));
					this.GUIM.m_SpeciallyEffect.mAddGiftExp = true;
				}
				else
				{
					this.GUIM.m_SpeciallyEffect.mUIGiftKeyValueform = null;
					this.GUIM.m_SpeciallyEffect.UI_bezieEnd = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f - 272f - num, -(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f + 157f));
					this.GUIM.m_SpeciallyEffect.mAddGiftPoint = true;
				}
				break;
			}
			case 1:
			case 2:
			{
				MessagePacket messagePacket3 = new MessagePacket(1024);
				messagePacket3.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_DELETEBOX;
				messagePacket3.AddSeqId();
				messagePacket3.Add(this.DM.mListGift[this.DM.mShowListIdx[btnID]].SN);
				messagePacket3.Send(false);
				this.GUIM.ShowUILock(EUILock.Alliance_Gift);
				break;
			}
			}
			break;
		}
		case 6:
		{
			MessagePacket messagePacket4 = new MessagePacket(1024);
			messagePacket4.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_OPENALLBOX;
			messagePacket4.AddSeqId();
			messagePacket4.Send(false);
			this.GUIM.ShowUILock(EUILock.Alliance_Gift);
			break;
		}
		}
	}

	// Token: 0x06000ED9 RID: 3801 RVA: 0x001936D4 File Offset: 0x001918D4
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		Gift_Item_btn btnID = (Gift_Item_btn)uibutton.m_BtnID1;
		if (btnID != Gift_Item_btn.btn_Hint)
		{
			if (btnID == Gift_Item_btn.btn_LVHint)
			{
				this.Img_LVHint.gameObject.SetActive(true);
			}
		}
		else
		{
			this.Img_GiftHint.gameObject.SetActive(true);
		}
	}

	// Token: 0x06000EDA RID: 3802 RVA: 0x00193734 File Offset: 0x00191934
	public void OnButtonUp(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		Gift_Item_btn btnID = (Gift_Item_btn)uibutton.m_BtnID1;
		if (btnID != Gift_Item_btn.btn_Hint)
		{
			if (btnID == Gift_Item_btn.btn_LVHint)
			{
				if (this.Img_LVHint.IsActive())
				{
					this.Img_LVHint.gameObject.SetActive(false);
				}
			}
		}
		else if (this.Img_GiftHint.IsActive())
		{
			this.Img_GiftHint.gameObject.SetActive(false);
		}
	}

	// Token: 0x06000EDB RID: 3803 RVA: 0x001937B4 File Offset: 0x001919B4
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x06000EDC RID: 3804 RVA: 0x001937B8 File Offset: 0x001919B8
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.tmpItem[panelObjectIdx] == null)
		{
			this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			this.Img_GiftLight[panelObjectIdx] = item.transform.GetChild(0).GetChild(0).GetComponent<Image>();
			this.Hbtn_btnGift[panelObjectIdx] = item.transform.GetChild(1).GetComponent<UIHIBtn>();
			this.Lbtn_btnGift[panelObjectIdx] = item.transform.GetChild(2).GetComponent<UILEBtn>();
			this.btn_Status[panelObjectIdx] = item.transform.GetChild(3).GetComponent<UIButton>();
			this.btn_Status[panelObjectIdx].m_Handler = this;
			this.text_btnStatus[panelObjectIdx] = item.transform.GetChild(3).GetChild(0).GetComponent<UIText>();
			this.Img_GetStatus[panelObjectIdx] = item.transform.GetChild(4).GetComponent<Image>();
			this.Img_Clock[panelObjectIdx] = item.transform.GetChild(5).GetComponent<Image>();
			this.text_ItemTime[panelObjectIdx] = item.transform.GetChild(5).GetChild(0).GetComponent<UIText>();
			this.Img_GiftKind[panelObjectIdx] = item.transform.GetChild(6).GetComponent<Image>();
			this.text_ItemExp[panelObjectIdx] = item.transform.GetChild(6).GetChild(0).GetComponent<UIText>();
			this.text_ItemNum[panelObjectIdx] = item.transform.GetChild(6).GetChild(1).GetComponent<UIText>();
			this.text_ItemGetStatus[panelObjectIdx] = item.transform.GetChild(7).GetComponent<UIText>();
			this.text_ItemName[panelObjectIdx] = item.transform.GetChild(8).GetComponent<UIText>();
		}
		this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].BoxItemID);
		this.text_ItemName[panelObjectIdx].text = this.DM.mStringTable.GetStringByID((uint)this.tmpEquip.EquipName);
		this.Cstr_ItemExp[panelObjectIdx].ClearString();
		this.Cstr_ItemExp[panelObjectIdx].IntToFormat((long)this.tmpEquip.PropertiesInfo[2].PropertiesValue, 1, true);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_ItemExp[panelObjectIdx].AppendFormat("{0}+");
		}
		else
		{
			this.Cstr_ItemExp[panelObjectIdx].AppendFormat("+{0}");
		}
		this.text_ItemExp[panelObjectIdx].text = this.Cstr_ItemExp[panelObjectIdx].ToString();
		this.text_ItemExp[panelObjectIdx].SetAllDirty();
		this.text_ItemExp[panelObjectIdx].cachedTextGenerator.Invalidate();
		this.Img_GiftLight[panelObjectIdx].gameObject.SetActive(false);
		bool flag = false;
		if (this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Status == 2 && this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].RcvTime + 86400L < this.DM.ServerTime)
		{
			this.Img_Clock[panelObjectIdx].gameObject.SetActive(false);
			this.Img_GetStatus[panelObjectIdx].gameObject.SetActive(true);
			this.Img_GetStatus[panelObjectIdx].sprite = this.SArray.m_Sprites[11];
			this.text_ItemGetStatus[panelObjectIdx].gameObject.SetActive(true);
			this.text_ItemGetStatus[panelObjectIdx].text = this.mStatus[4];
			this.text_ItemGetStatus[panelObjectIdx].color = this.mColor_R;
			this.text_btnStatus[panelObjectIdx].text = this.mStatus[1];
			this.btn_Status[panelObjectIdx].image.sprite = this.SArray.m_Sprites[6];
			flag = true;
			if (this.tmpEquip.PropertiesInfo[2].Propertieskey == 1)
			{
				this.Img_GiftKind[panelObjectIdx].sprite = this.SArray.m_Sprites[8];
			}
			else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
			{
				this.Img_GiftKind[panelObjectIdx].sprite = this.SArray.m_Sprites[12];
			}
			else
			{
				this.Img_GiftKind[panelObjectIdx].sprite = this.SArray.m_Sprites[9];
			}
		}
		else if (this.tmpEquip.PropertiesInfo[2].Propertieskey == 1)
		{
			this.Img_GiftKind[panelObjectIdx].sprite = this.SArray.m_Sprites[8];
			if (this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Status == 0)
			{
				this.Img_Clock[panelObjectIdx].gameObject.SetActive(true);
				this.text_btnStatus[panelObjectIdx].text = this.mStatus[0];
				this.btn_Status[panelObjectIdx].image.sprite = this.SArray.m_Sprites[5];
				this.GUIM.ChangeHeroItemImg(this.Hbtn_btnGift[panelObjectIdx].transform, eHeroOrItem.Item, this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].BoxItemID, 0, 0, 0);
				this.Lbtn_btnGift[panelObjectIdx].gameObject.SetActive(false);
				this.Hbtn_btnGift[panelObjectIdx].gameObject.SetActive(true);
				this.Img_GetStatus[panelObjectIdx].gameObject.SetActive(false);
				this.text_ItemGetStatus[panelObjectIdx].gameObject.SetActive(false);
			}
			else
			{
				this.Img_Clock[panelObjectIdx].gameObject.SetActive(false);
				this.text_btnStatus[panelObjectIdx].text = this.mStatus[1];
				this.btn_Status[panelObjectIdx].image.sprite = this.SArray.m_Sprites[6];
				this.Img_GetStatus[panelObjectIdx].gameObject.SetActive(true);
				this.Img_GetStatus[panelObjectIdx].sprite = this.SArray.m_Sprites[10];
				this.text_ItemGetStatus[panelObjectIdx].gameObject.SetActive(true);
				this.text_ItemGetStatus[panelObjectIdx].text = this.mStatus[3];
				this.text_ItemGetStatus[panelObjectIdx].color = this.mColor_G;
				flag = true;
			}
		}
		else
		{
			if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
			{
				this.Img_GiftKind[panelObjectIdx].sprite = this.SArray.m_Sprites[12];
			}
			else
			{
				this.Img_GiftKind[panelObjectIdx].sprite = this.SArray.m_Sprites[9];
			}
			if (this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Status == 0)
			{
				this.Img_Clock[panelObjectIdx].gameObject.SetActive(true);
				this.text_btnStatus[panelObjectIdx].text = this.mStatus[2];
				this.btn_Status[panelObjectIdx].image.sprite = this.SArray.m_Sprites[7];
				this.Img_GetStatus[panelObjectIdx].gameObject.SetActive(false);
				this.text_ItemGetStatus[panelObjectIdx].gameObject.SetActive(false);
				this.Img_GiftLight[panelObjectIdx].gameObject.SetActive(true);
			}
			else
			{
				this.Img_Clock[panelObjectIdx].gameObject.SetActive(false);
				this.text_btnStatus[panelObjectIdx].text = this.mStatus[1];
				this.btn_Status[panelObjectIdx].image.sprite = this.SArray.m_Sprites[6];
				this.Img_GetStatus[panelObjectIdx].gameObject.SetActive(true);
				this.text_ItemGetStatus[panelObjectIdx].gameObject.SetActive(true);
				this.Img_GetStatus[panelObjectIdx].sprite = this.SArray.m_Sprites[10];
				this.text_ItemGetStatus[panelObjectIdx].text = this.mStatus[3];
				this.text_ItemGetStatus[panelObjectIdx].color = this.mColor_G;
			}
			flag = true;
		}
		if (flag)
		{
			this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Item.ItemID);
			this.Img_GiftKind[panelObjectIdx].gameObject.SetActive(true);
			this.Cstr_ItemNum[panelObjectIdx].ClearString();
			this.Cstr_ItemNum[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpEquip.EquipName));
			this.Cstr_ItemNum[panelObjectIdx].IntToFormat((long)this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Item.Num, 1, true);
			this.Cstr_ItemNum[panelObjectIdx].AppendFormat("{0} x {1}");
			this.text_ItemNum[panelObjectIdx].text = this.Cstr_ItemNum[panelObjectIdx].ToString();
			this.text_ItemNum[panelObjectIdx].SetAllDirty();
			this.text_ItemNum[panelObjectIdx].cachedTextGenerator.Invalidate();
			byte equipKind = this.tmpEquip.EquipKind;
			bool flag2 = this.GUIM.IsLeadItem(equipKind);
			if (flag2)
			{
				this.GUIM.ChangeLordEquipImg(this.Lbtn_btnGift[panelObjectIdx].transform, this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Item.ItemID, this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Item.ItemRank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				this.Lbtn_btnGift[panelObjectIdx].gameObject.SetActive(true);
				this.Hbtn_btnGift[panelObjectIdx].gameObject.SetActive(false);
			}
			else
			{
				this.GUIM.ChangeHeroItemImg(this.Hbtn_btnGift[panelObjectIdx].transform, eHeroOrItem.Item, this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Item.ItemID, 0, this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].Item.ItemRank, 0);
				this.Lbtn_btnGift[panelObjectIdx].gameObject.SetActive(false);
				this.Hbtn_btnGift[panelObjectIdx].gameObject.SetActive(true);
			}
		}
		else
		{
			this.Img_GiftKind[panelObjectIdx].gameObject.SetActive(false);
		}
		if (this.Img_Clock[panelObjectIdx].gameObject.activeSelf)
		{
			this.tmpValue = this.DM.mListGift[this.DM.mShowListIdx[dataIdx]].RcvTime + 86400L - this.DM.ServerTime;
			this.Cstr_ItemTime[panelObjectIdx].ClearString();
			this.Cstr_ItemTime[panelObjectIdx].IntToFormat(this.tmpValue / 3600L, 1, false);
			this.tmpValue %= 3600L;
			this.Cstr_ItemTime[panelObjectIdx].IntToFormat(this.tmpValue / 60L, 2, false);
			this.tmpValue %= 60L;
			this.Cstr_ItemTime[panelObjectIdx].IntToFormat(this.tmpValue, 2, false);
			this.Cstr_ItemTime[panelObjectIdx].AppendFormat("{0}:{1}:{2}");
			this.text_ItemTime[panelObjectIdx].text = this.Cstr_ItemTime[panelObjectIdx].ToString();
			this.text_ItemTime[panelObjectIdx].SetAllDirty();
			this.text_ItemTime[panelObjectIdx].cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06000EDD RID: 3805 RVA: 0x00194394 File Offset: 0x00192594
	public void ReSetScrollData(bool bGetNew = false, ushort DeleteIdx = 500)
	{
		this.tmplist.Clear();
		this.DM.mShowListUnOpenIdx = 0;
		this.DM.RoleAlliance.GiftNum = 0;
		for (int i = 0; i < this.DM.mShowListIdx.Count; i++)
		{
			if (this.DM.mListGift[this.DM.mShowListIdx[i]].Status == 0)
			{
				DataManager dm = this.DM;
				dm.mShowListUnOpenIdx += 1;
				DataManager dm2 = this.DM;
				dm2.RoleAlliance.GiftNum = dm2.RoleAlliance.GiftNum + 1;
			}
			this.tmplist.Add(99f);
		}
		this.DM.mShowListIdx.Sort(this.DM.mSortGift);
		this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
		this.Cstr_GiftMax.ClearString();
		this.Cstr_GiftMax.IntToFormat((long)this.DM.mShowListIdx.Count, 1, true);
		this.Cstr_GiftMax.AppendFormat(this.DM.mStringTable.GetStringByID(7005u));
		this.text_GiftMax.text = this.Cstr_GiftMax.ToString();
		this.text_GiftMax.SetAllDirty();
		this.text_GiftMax.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06000EDE RID: 3806 RVA: 0x00194500 File Offset: 0x00192700
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			this.ReSetScrollData(false, 500);
			if (this.DM.mShowListIdx.Count == 0)
			{
				this.Img_NoGift.gameObject.SetActive(true);
				this.m_ScrollPanel.gameObject.SetActive(false);
			}
			else
			{
				this.m_ScrollPanel.gameObject.SetActive(true);
				this.Img_NoGift.gameObject.SetActive(false);
			}
			break;
		case 2:
		{
			bool flag = false;
			Vector2 mStartV = Vector2.zero;
			for (int i = 0; i < 6; i++)
			{
				if (this.DM.mShowListIdx.Count > i && this.tmpItem[i] != null && this.tmpItem[i].m_BtnID1 != -1 && this.DM.mShowListIdx[this.tmpItem[i].m_BtnID1] == this.DM.mGift_UpdateSN)
				{
					this.Img_Clock[i].gameObject.SetActive(false);
					this.Img_GetStatus[i].gameObject.SetActive(true);
					this.text_ItemGetStatus[i].gameObject.SetActive(true);
					if (this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[i].m_BtnID1]].Status == 1 && this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[i].m_BtnID1]].RcvTime + 86400L - this.DM.ServerTime > 0L)
					{
						this.Img_GetStatus[i].sprite = this.SArray.m_Sprites[10];
						this.text_ItemGetStatus[i].text = this.mStatus[3];
						this.text_ItemGetStatus[i].color = this.mColor_G;
						flag = true;
						if (this.Img_GiftLight[i].IsActive())
						{
							this.Img_GiftLight[i].gameObject.SetActive(false);
						}
					}
					else
					{
						this.Img_GetStatus[i].sprite = this.SArray.m_Sprites[11];
						this.text_ItemGetStatus[i].text = this.mStatus[4];
						this.text_ItemGetStatus[i].color = this.mColor_R;
						if (this.Img_GiftLight[i].IsActive())
						{
							this.Img_GiftLight[i].gameObject.SetActive(false);
						}
					}
					this.btn_Status[i].image.sprite = this.SArray.m_Sprites[6];
					this.text_btnStatus[i].text = this.mStatus[1];
					this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[i].m_BtnID1]].Item.ItemID);
					this.Img_GiftKind[i].gameObject.SetActive(true);
					this.Cstr_ItemNum[i].ClearString();
					this.Cstr_ItemNum[i].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpEquip.EquipName));
					this.Cstr_ItemNum[i].IntToFormat((long)this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[i].m_BtnID1]].Item.Num, 1, true);
					this.Cstr_ItemNum[i].AppendFormat("{0} x {1}");
					this.text_ItemNum[i].text = this.Cstr_ItemNum[i].ToString();
					this.text_ItemNum[i].SetAllDirty();
					this.text_ItemNum[i].cachedTextGenerator.Invalidate();
					byte equipKind = this.tmpEquip.EquipKind;
					bool flag2 = this.GUIM.IsLeadItem(equipKind);
					if (flag2)
					{
						this.GUIM.ChangeLordEquipImg(this.Lbtn_btnGift[i].transform, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[i].m_BtnID1]].Item.ItemID, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[i].m_BtnID1]].Item.ItemRank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
						this.Lbtn_btnGift[i].gameObject.SetActive(true);
						this.Hbtn_btnGift[i].gameObject.SetActive(false);
					}
					else
					{
						this.GUIM.ChangeHeroItemImg(this.Hbtn_btnGift[i].transform, eHeroOrItem.Item, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[i].m_BtnID1]].Item.ItemID, 0, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[i].m_BtnID1]].Item.ItemRank, 0);
						this.Lbtn_btnGift[i].gameObject.SetActive(false);
						this.Hbtn_btnGift[i].gameObject.SetActive(true);
					}
					if (flag)
					{
						mStartV = this.GUIM.mStartV2;
						RectTransform component = this.Hbtn_btnGift[i].transform.parent.GetComponent<RectTransform>();
						RectTransform component2 = this.Hbtn_btnGift[i].transform.parent.parent.GetComponent<RectTransform>();
						RectTransform component3 = this.Hbtn_btnGift[i].transform.parent.parent.parent.GetComponent<RectTransform>();
						RectTransform component4 = this.Hbtn_btnGift[i].transform.parent.parent.parent.parent.GetComponent<RectTransform>();
						this.GUIM.mStartV2 = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + component4.anchoredPosition.x - component3.sizeDelta.x / 2f + 12f + 35f, this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - component4.anchoredPosition.y - component4.sizeDelta.y / 2f + component3.anchoredPosition.y - component2.anchoredPosition.y - component.anchoredPosition.y + 10f + 35f);
						GUIManager.Instance.m_SpeciallyEffect.mDiamondValue = 0u;
						if (this.tmpEquip.EquipKind != 11)
						{
							if (flag2)
							{
								this.GUIM.SE_Item_L_Color[0] = this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[i].m_BtnID1]].Item.ItemRank;
								this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Item_Material, 0, this.tmpEquip.EquipKey, true, 2f);
							}
							else
							{
								this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Item, 0, this.tmpEquip.EquipKey, true, 2f);
							}
						}
						else if (this.tmpEquip.PropertiesInfo[0].Propertieskey < 6)
						{
							this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Item, 0, this.tmpEquip.EquipKey, true, 2f);
						}
						else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == 6)
						{
							this.GUIM.m_SpeciallyEffect.mDiamondValue = (uint)(this.tmpEquip.PropertiesInfo[1].Propertieskey * this.tmpEquip.PropertiesInfo[1].PropertiesValue);
							this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Diamond, 0, 0, true, 2f);
						}
						else
						{
							this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.AllianceMoney, 0, 0, true, 2f);
						}
						this.GUIM.mStartV2 = mStartV;
						AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
					}
				}
			}
			this.DM.mGift_UpdateSN = 0u;
			this.Cstr_GiftMax.ClearString();
			this.Cstr_GiftMax.IntToFormat((long)this.DM.mShowListIdx.Count, 1, true);
			this.Cstr_GiftMax.AppendFormat(this.DM.mStringTable.GetStringByID(7005u));
			this.text_GiftMax.text = this.Cstr_GiftMax.ToString();
			this.text_GiftMax.SetAllDirty();
			this.text_GiftMax.cachedTextGenerator.Invalidate();
			break;
		}
		case 3:
			this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.DM.RoleAlliance.PackItemID);
			this.text_GiftName.text = this.DM.mStringTable.GetStringByID((uint)this.tmpEQ.EquipName);
			this.Cstr_KeyValue.ClearString();
			if (this.GUIM.IsArabic)
			{
				this.Cstr_KeyValue.IntToFormat((long)(this.tmpEQ.PropertiesInfo[1].PropertiesValue * this.tmpEQ.PropertiesInfo[5].PropertiesValue), 1, true);
				this.Cstr_KeyValue.IntToFormat((long)((ulong)this.DM.RoleAlliance.PackPoint), 1, true);
			}
			else
			{
				this.Cstr_KeyValue.IntToFormat((long)((ulong)this.DM.RoleAlliance.PackPoint), 1, true);
				this.Cstr_KeyValue.IntToFormat((long)(this.tmpEQ.PropertiesInfo[1].PropertiesValue * this.tmpEQ.PropertiesInfo[5].PropertiesValue), 1, true);
			}
			this.Cstr_KeyValue.AppendFormat(this.DM.mStringTable.GetStringByID(7004u));
			this.text_KeyValue.text = this.Cstr_KeyValue.ToString();
			this.text_KeyValue.SetAllDirty();
			this.text_KeyValue.cachedTextGenerator.Invalidate();
			if (this.GUIM.IsArabic)
			{
				this.text_KeyValue.UpdateArabicPos();
			}
			this.Img_KeyBar.fillAmount = this.DM.RoleAlliance.PackPoint / (float)(this.tmpEQ.PropertiesInfo[1].PropertiesValue * this.tmpEQ.PropertiesInfo[5].PropertiesValue);
			this.uiTimeStep = 0f;
			this.bShowGetNewGift = true;
			this.GUIM.m_SpeciallyEffect.mUIGiftKeyValueform = this.text_KeyValue.transform;
			this.Light_T.gameObject.SetActive(false);
			this.Gift_NewRT.gameObject.SetActive(true);
			this.Img_GiftNew.sprite = this.SArray.m_Sprites[(int)(this.tmpEQ.Color - 1)];
			break;
		case 4:
			this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.DM.RoleAlliance.PackItemID);
			this.Cstr_KeyValue.ClearString();
			if (this.GUIM.IsArabic)
			{
				this.Cstr_KeyValue.IntToFormat((long)(this.tmpEQ.PropertiesInfo[1].PropertiesValue * this.tmpEQ.PropertiesInfo[5].PropertiesValue), 1, true);
				this.Cstr_KeyValue.IntToFormat((long)((ulong)this.DM.RoleAlliance.PackPoint), 1, true);
			}
			else
			{
				this.Cstr_KeyValue.IntToFormat((long)((ulong)this.DM.RoleAlliance.PackPoint), 1, true);
				this.Cstr_KeyValue.IntToFormat((long)(this.tmpEQ.PropertiesInfo[1].PropertiesValue * this.tmpEQ.PropertiesInfo[5].PropertiesValue), 1, true);
			}
			this.Cstr_KeyValue.AppendFormat(this.DM.mStringTable.GetStringByID(7004u));
			this.text_KeyValue.text = this.Cstr_KeyValue.ToString();
			this.text_KeyValue.SetAllDirty();
			this.text_KeyValue.cachedTextGenerator.Invalidate();
			if (this.GUIM.IsArabic)
			{
				this.text_KeyValue.UpdateArabicPos();
			}
			this.Img_KeyBar.fillAmount = this.DM.RoleAlliance.PackPoint / (float)(this.tmpEQ.PropertiesInfo[1].PropertiesValue * this.tmpEQ.PropertiesInfo[5].PropertiesValue);
			this.GUIM.m_SpeciallyEffect.mUIGiftKeyValueform = this.text_KeyValue.transform;
			if (this.GUIM.m_SpeciallyEffect.mAddGiftPoint)
			{
				GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, SpeciallyEffect_Kind.Alliance_Gift_Key, 0, 0, true, 2f);
			}
			break;
		case 5:
		{
			uint num = 0u;
			for (int j = 0; j < (int)(this.DM.RoleAlliance.GiftLv + 1); j++)
			{
				num += this.DM.AllianceLvUpData.GetRecordByKey((ushort)(j + 1)).LvExp;
			}
			this.Cstr_Lv.ClearString();
			this.Cstr_Lv.IntToFormat((long)this.DM.RoleAlliance.GiftLv, 1, false);
			this.Cstr_Lv.AppendFormat(this.DM.mStringTable.GetStringByID(7003u));
			this.text_Lv.text = this.Cstr_Lv.ToString();
			this.text_Lv.SetAllDirty();
			this.text_Lv.cachedTextGenerator.Invalidate();
			this.Cstr_BarValue.ClearString();
			if (this.GUIM.IsArabic)
			{
				this.Cstr_BarValue.IntToFormat((long)((ulong)num), 1, true);
				this.Cstr_BarValue.IntToFormat((long)((ulong)this.DM.RoleAlliance.GiftExp), 1, true);
			}
			else
			{
				this.Cstr_BarValue.IntToFormat((long)((ulong)this.DM.RoleAlliance.GiftExp), 1, true);
				this.Cstr_BarValue.IntToFormat((long)((ulong)num), 1, true);
			}
			this.Cstr_BarValue.AppendFormat(this.DM.mStringTable.GetStringByID(7004u));
			this.text_BarValue.text = this.Cstr_BarValue.ToString();
			this.text_BarValue.SetAllDirty();
			this.text_BarValue.cachedTextGenerator.Invalidate();
			this.ImgBar_RT.sizeDelta = new Vector2((float)(422.0 * (this.DM.RoleAlliance.GiftExp / num)), this.ImgBar_RT.sizeDelta.y);
			if (this.GUIM.m_SpeciallyEffect.mAddGiftExp)
			{
				GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, SpeciallyEffect_Kind.Alliance_Gift, 0, 0, true, 2f);
			}
			break;
		}
		case 6:
			this.DM.bSendtoGetGift = false;
			break;
		case 7:
			this.tmplist.Clear();
			this.DM.mShowListUnOpenIdx = 0;
			for (int k = 0; k < this.DM.mShowListIdx.Count; k++)
			{
				if (this.DM.mListGift[this.DM.mShowListIdx[k]].Status == 0)
				{
					DataManager dm = this.DM;
					dm.mShowListUnOpenIdx += 1;
				}
				this.tmplist.Add(99f);
			}
			if (this.DM.mShowListIdx.Count > 6 && arg2 == 1)
			{
				this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			}
			else
			{
				this.m_ScrollPanel.AddNewDataHeight(this.tmplist, true, true);
			}
			this.Cstr_GiftMax.ClearString();
			this.Cstr_GiftMax.IntToFormat((long)this.DM.mShowListIdx.Count, 1, true);
			this.Cstr_GiftMax.AppendFormat(this.DM.mStringTable.GetStringByID(7005u));
			this.text_GiftMax.text = this.Cstr_GiftMax.ToString();
			this.text_GiftMax.SetAllDirty();
			this.text_GiftMax.cachedTextGenerator.Invalidate();
			if (this.DM.mShowListIdx.Count == 0)
			{
				this.Img_NoGift.gameObject.SetActive(true);
				this.m_ScrollPanel.gameObject.SetActive(false);
			}
			else
			{
				this.m_ScrollPanel.gameObject.SetActive(true);
				this.Img_NoGift.gameObject.SetActive(false);
			}
			break;
		case 8:
			if (this.DM.RoleAttr.VIPLevel >= 12)
			{
				this.btn_DeleteRT.anchoredPosition = new Vector2(this.btn_DeleteRT.anchoredPosition.x - 60f, this.btn_DeleteRT.anchoredPosition.y);
				this.btn_All.gameObject.SetActive(true);
			}
			break;
		case 9:
		{
			Vector2 mStartV2 = Vector2.zero;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = -1;
			int num6 = 300;
			for (int l = 0; l < 6; l++)
			{
				if (this.Img_Clock[l] != null && this.Img_Clock[l].gameObject.activeSelf)
				{
					num3++;
				}
				if (this.tmpItem[l] != null && this.tmpItem[l].gameObject.activeSelf)
				{
					num4++;
				}
				if (this.tmpItem[l] != null && this.tmpItem[l].m_BtnID1 != -1 && num6 > this.tmpItem[l].m_BtnID1)
				{
					num5 = l;
					num6 = this.tmpItem[l].m_BtnID1;
				}
			}
			for (int m = 0; m < 6; m++)
			{
				if (this.Img_Clock[m] != null && this.Img_Clock[m].gameObject.activeSelf)
				{
					bool flag3 = false;
					if (this.DM.mShowListIdx.Count > m && this.tmpItem[m] != null && this.tmpItem[m].m_BtnID1 != -1)
					{
						this.Img_Clock[m].gameObject.SetActive(false);
						this.Img_GetStatus[m].gameObject.SetActive(true);
						this.text_ItemGetStatus[m].gameObject.SetActive(true);
						if (this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[m].m_BtnID1]].Status == 1 && this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[m].m_BtnID1]].RcvTime + 86400L - this.DM.ServerTime > 0L)
						{
							this.Img_GetStatus[m].sprite = this.SArray.m_Sprites[10];
							this.text_ItemGetStatus[m].text = this.mStatus[3];
							this.text_ItemGetStatus[m].color = this.mColor_G;
							flag3 = true;
							if (this.Img_GiftLight[m].IsActive())
							{
								this.Img_GiftLight[m].gameObject.SetActive(false);
							}
						}
						else
						{
							this.Img_GetStatus[m].sprite = this.SArray.m_Sprites[11];
							this.text_ItemGetStatus[m].text = this.mStatus[4];
							this.text_ItemGetStatus[m].color = this.mColor_R;
							if (this.Img_GiftLight[m].IsActive())
							{
								this.Img_GiftLight[m].gameObject.SetActive(false);
							}
						}
						this.btn_Status[m].image.sprite = this.SArray.m_Sprites[6];
						this.text_btnStatus[m].text = this.mStatus[1];
						this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[m].m_BtnID1]].Item.ItemID);
						this.Img_GiftKind[m].gameObject.SetActive(true);
						this.Cstr_ItemNum[m].ClearString();
						this.Cstr_ItemNum[m].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpEquip.EquipName));
						this.Cstr_ItemNum[m].IntToFormat((long)this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[m].m_BtnID1]].Item.Num, 1, true);
						this.Cstr_ItemNum[m].AppendFormat("{0} x {1}");
						this.text_ItemNum[m].text = this.Cstr_ItemNum[m].ToString();
						this.text_ItemNum[m].SetAllDirty();
						this.text_ItemNum[m].cachedTextGenerator.Invalidate();
						byte equipKind2 = this.tmpEquip.EquipKind;
						bool flag4 = this.GUIM.IsLeadItem(equipKind2);
						if (flag4)
						{
							this.GUIM.ChangeLordEquipImg(this.Lbtn_btnGift[m].transform, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[m].m_BtnID1]].Item.ItemID, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[m].m_BtnID1]].Item.ItemRank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
							this.Lbtn_btnGift[m].gameObject.SetActive(true);
							this.Hbtn_btnGift[m].gameObject.SetActive(false);
						}
						else
						{
							this.GUIM.ChangeHeroItemImg(this.Hbtn_btnGift[m].transform, eHeroOrItem.Item, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[m].m_BtnID1]].Item.ItemID, 0, this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[m].m_BtnID1]].Item.ItemRank, 0);
							this.Lbtn_btnGift[m].gameObject.SetActive(false);
							this.Hbtn_btnGift[m].gameObject.SetActive(true);
						}
						if (num3 != 6 || num4 != 6 || num5 != m || !flag3)
						{
							if (flag3 && num2 < 5 && this.tmpItem[m].gameObject.activeSelf)
							{
								num2++;
								mStartV2 = this.GUIM.mStartV2;
								RectTransform component5 = this.Hbtn_btnGift[m].transform.parent.GetComponent<RectTransform>();
								RectTransform component6 = this.Hbtn_btnGift[m].transform.parent.parent.GetComponent<RectTransform>();
								RectTransform component7 = this.Hbtn_btnGift[m].transform.parent.parent.parent.GetComponent<RectTransform>();
								RectTransform component8 = this.Hbtn_btnGift[m].transform.parent.parent.parent.parent.GetComponent<RectTransform>();
								this.GUIM.mStartV2 = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + component8.anchoredPosition.x - component7.sizeDelta.x / 2f + 12f + 35f, this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - component8.anchoredPosition.y - component8.sizeDelta.y / 2f + component7.anchoredPosition.y - component6.anchoredPosition.y - component5.anchoredPosition.y + 10f + 35f);
								GUIManager.Instance.m_SpeciallyEffect.mDiamondValue = 0u;
								if (this.tmpEquip.EquipKind != 11)
								{
									if (flag4)
									{
										this.GUIM.SE_Item_L_Color[0] = this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[m].m_BtnID1]].Item.ItemRank;
										this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Item_Material, 0, this.tmpEquip.EquipKey, true, 2f);
									}
									else
									{
										this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Item, 0, this.tmpEquip.EquipKey, true, 2f);
									}
								}
								else if (this.tmpEquip.PropertiesInfo[0].Propertieskey < 6)
								{
									this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Item, 0, this.tmpEquip.EquipKey, true, 2f);
								}
								else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == 6)
								{
									this.GUIM.m_SpeciallyEffect.mDiamondValue = (uint)(this.tmpEquip.PropertiesInfo[1].Propertieskey * this.tmpEquip.PropertiesInfo[1].PropertiesValue);
									this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Diamond, 0, 0, true, 2f);
								}
								else
								{
									this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.AllianceMoney, 0, 0, true, 2f);
								}
								this.GUIM.mStartV2 = mStartV2;
								AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
							}
						}
					}
				}
			}
			this.Cstr_GiftMax.ClearString();
			this.Cstr_GiftMax.IntToFormat((long)this.DM.mShowListIdx.Count, 1, true);
			this.Cstr_GiftMax.AppendFormat(this.DM.mStringTable.GetStringByID(7005u));
			this.text_GiftMax.text = this.Cstr_GiftMax.ToString();
			this.text_GiftMax.SetAllDirty();
			this.text_GiftMax.cachedTextGenerator.Invalidate();
			break;
		}
		case 10:
			if (this.door != null && this.DM.RoleAlliance.Id == 0u)
			{
				this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_Gift);
			}
			break;
		}
	}

	// Token: 0x06000EDF RID: 3807 RVA: 0x00196238 File Offset: 0x00194438
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
			if (this.DM.RoleAlliance.Id == 0u)
			{
				this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_Gift);
				return;
			}
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_INFO;
			messagePacket.AddSeqId();
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.Alliance_Gift);
			this.DM.bSendtoGetGift = false;
		}
	}

	// Token: 0x06000EE0 RID: 3808 RVA: 0x001962D0 File Offset: 0x001944D0
	public void Refresh_FontTexture()
	{
		if (this.text_Lv != null && this.text_Lv.enabled)
		{
			this.text_Lv.enabled = false;
			this.text_Lv.enabled = true;
		}
		if (this.text_BarValue != null && this.text_BarValue.enabled)
		{
			this.text_BarValue.enabled = false;
			this.text_BarValue.enabled = true;
		}
		if (this.text_GiftMax != null && this.text_GiftMax.enabled)
		{
			this.text_GiftMax.enabled = false;
			this.text_GiftMax.enabled = true;
		}
		if (this.text_KeyValue != null && this.text_KeyValue.enabled)
		{
			this.text_KeyValue.enabled = false;
			this.text_KeyValue.enabled = true;
		}
		if (this.text_GiftName != null && this.text_GiftName.enabled)
		{
			this.text_GiftName.enabled = false;
			this.text_GiftName.enabled = true;
		}
		if (this.text_GiftHint != null && this.text_GiftHint.enabled)
		{
			this.text_GiftHint.enabled = false;
			this.text_GiftHint.enabled = true;
		}
		if (this.text_LVHint != null && this.text_LVHint.enabled)
		{
			this.text_LVHint.enabled = false;
			this.text_LVHint.enabled = true;
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.text_tmpStr[i] != null && this.text_tmpStr[i].enabled)
			{
				this.text_tmpStr[i].enabled = false;
				this.text_tmpStr[i].enabled = true;
			}
		}
		for (int j = 0; j < 6; j++)
		{
			if (this.text_btnStatus[j] != null && this.text_btnStatus[j].enabled)
			{
				this.text_btnStatus[j].enabled = false;
				this.text_btnStatus[j].enabled = true;
			}
			if (this.text_ItemGetStatus[j] != null && this.text_ItemGetStatus[j].enabled)
			{
				this.text_ItemGetStatus[j].enabled = false;
				this.text_ItemGetStatus[j].enabled = true;
			}
			if (this.text_ItemTime[j] != null && this.text_ItemTime[j].enabled)
			{
				this.text_ItemTime[j].enabled = false;
				this.text_ItemTime[j].enabled = true;
			}
			if (this.text_ItemExp[j] != null && this.text_ItemExp[j].enabled)
			{
				this.text_ItemExp[j].enabled = false;
				this.text_ItemExp[j].enabled = true;
			}
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
			if (this.Hbtn_btnGift[j] != null && this.Hbtn_btnGift[j].enabled)
			{
				this.Hbtn_btnGift[j].Refresh_FontTexture();
			}
		}
	}

	// Token: 0x06000EE1 RID: 3809 RVA: 0x0019668C File Offset: 0x0019488C
	public void OnLEButtonClick(UILEBtn sender)
	{
	}

	// Token: 0x06000EE2 RID: 3810 RVA: 0x00196690 File Offset: 0x00194890
	private void Start()
	{
	}

	// Token: 0x06000EE3 RID: 3811 RVA: 0x00196694 File Offset: 0x00194894
	public override void UpdateTime(bool bOnSecond)
	{
		if (bOnSecond)
		{
			for (int i = 0; i < 6; i++)
			{
				if (this.DM.mShowListIdx.Count > i && this.tmpItem[i] != null && this.tmpItem[i].m_BtnID1 >= 0 && this.tmpItem[i].m_BtnID1 <= this.DM.mShowListIdx.Count && this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[i].m_BtnID1]].Status == 0)
				{
					this.tmpValue = this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[i].m_BtnID1]].RcvTime + 86400L - this.DM.ServerTime;
					this.Cstr_ItemTime[i].ClearString();
					this.Cstr_ItemTime[i].IntToFormat(this.tmpValue / 3600L, 1, false);
					this.tmpValue %= 3600L;
					this.Cstr_ItemTime[i].IntToFormat(this.tmpValue / 60L, 2, false);
					this.tmpValue %= 60L;
					this.Cstr_ItemTime[i].IntToFormat(this.tmpValue, 2, false);
					this.Cstr_ItemTime[i].AppendFormat("{0}:{1}:{2}");
					this.text_ItemTime[i].text = this.Cstr_ItemTime[i].ToString();
					this.text_ItemTime[i].SetAllDirty();
					this.text_ItemTime[i].cachedTextGenerator.Invalidate();
					if (this.DM.mListGift[this.DM.mShowListIdx[this.tmpItem[i].m_BtnID1]].RcvTime + 86400L - this.DM.ServerTime <= 0L)
					{
						MessagePacket messagePacket = new MessagePacket(1024);
						messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_GIFT_OPENBOX;
						messagePacket.AddSeqId();
						messagePacket.Add(this.DM.mShowListIdx[this.tmpItem[i].m_BtnID1]);
						messagePacket.Send(false);
						this.GUIM.ShowUILock(EUILock.Alliance_Gift);
					}
				}
			}
		}
	}

	// Token: 0x06000EE4 RID: 3812 RVA: 0x0019690C File Offset: 0x00194B0C
	private void Update()
	{
		if (this.Light_T != null)
		{
			this.Light_T.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
		}
		for (int i = 0; i < 6; i++)
		{
			if (this.Img_GiftLight[i] != null && this.Img_GiftLight[i].IsActive())
			{
				this.Img_GiftLight[i].transform.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
			}
		}
		if (this.bShowGetNewGift)
		{
			this.GiftRT.anchoredPosition = GameConstants.CubicBezierCurves(this.v2Begin, this.bezierCenter, this.bezierCenter2, this.v2End, 0.5f, this.uiTimeStep);
			this.GiftRT.localScale = new Vector3(1f - this.uiTimeStep / 2f, 1f - this.uiTimeStep / 2f, 1f - this.uiTimeStep / 2f);
			if (this.uiTimeStep > 1f)
			{
				this.Img_Gift.color = new Color(1f, 1f, 1f, 2f - this.uiTimeStep);
			}
			if (this.uiTimeStep < 1.8f)
			{
				this.Gift_NewRT.localScale = new Vector3(0.2f + this.uiTimeStep / 2f, 0.2f + this.uiTimeStep / 2f, 0.2f + this.uiTimeStep / 2f);
				this.Gift_NameRT.localScale = new Vector3(0.2f + this.uiTimeStep / 2f, 0.2f + this.uiTimeStep / 2f, 0.2f + this.uiTimeStep / 2f);
			}
			else
			{
				this.Gift_NewRT.localScale = new Vector3(2f - this.uiTimeStep / 2f, 2f - this.uiTimeStep / 2f, 2f - this.uiTimeStep / 2f);
				this.Gift_NameRT.localScale = new Vector3(2f - this.uiTimeStep / 2f, 2f - this.uiTimeStep / 2f, 2f - this.uiTimeStep / 2f);
			}
			this.uiTimeStep += Time.smoothDeltaTime;
			if (this.uiTimeStep > 2f)
			{
				this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.DM.RoleAlliance.PackItemID);
				this.Gift_NewRT.localScale = new Vector3(1f, 1f, 1f);
				this.Gift_NameRT.localScale = new Vector3(1f, 1f, 1f);
				this.GiftRT.anchoredPosition = this.v2Begin;
				this.GiftRT.localScale = new Vector3(1f, 1f, 1f);
				this.Img_Gift.color = new Color(1f, 1f, 1f, 1f);
				this.Img_Gift.sprite = this.SArray.m_Sprites[(int)(this.tmpEQ.Color - 1)];
				this.bShowGetNewGift = false;
				this.Light_T.gameObject.SetActive(true);
				this.Gift_NewRT.gameObject.SetActive(false);
				this.uiTimeStep = 0f;
			}
		}
	}

	// Token: 0x040030AA RID: 12458
	private DataManager DM;

	// Token: 0x040030AB RID: 12459
	private GUIManager GUIM;

	// Token: 0x040030AC RID: 12460
	private Transform GameT;

	// Token: 0x040030AD RID: 12461
	private Transform Tmp;

	// Token: 0x040030AE RID: 12462
	private Transform Light_T;

	// Token: 0x040030AF RID: 12463
	private RectTransform ImgBar_RT;

	// Token: 0x040030B0 RID: 12464
	private RectTransform GiftRT;

	// Token: 0x040030B1 RID: 12465
	private RectTransform Gift_NewRT;

	// Token: 0x040030B2 RID: 12466
	private RectTransform Gift_NameRT;

	// Token: 0x040030B3 RID: 12467
	private RectTransform btn_DeleteRT;

	// Token: 0x040030B4 RID: 12468
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040030B5 RID: 12469
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[6];

	// Token: 0x040030B6 RID: 12470
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x040030B7 RID: 12471
	private Door door;

	// Token: 0x040030B8 RID: 12472
	private UIButton btn_EXIT;

	// Token: 0x040030B9 RID: 12473
	private UIButton btn_I;

	// Token: 0x040030BA RID: 12474
	private UIButton btn_Delete;

	// Token: 0x040030BB RID: 12475
	private UIButton btn_Hint;

	// Token: 0x040030BC RID: 12476
	private UIButton btn_LVHint;

	// Token: 0x040030BD RID: 12477
	private UIButton btn_All;

	// Token: 0x040030BE RID: 12478
	private UIButton[] btn_Status = new UIButton[6];

	// Token: 0x040030BF RID: 12479
	private UIHIBtn[] Hbtn_btnGift = new UIHIBtn[6];

	// Token: 0x040030C0 RID: 12480
	private UILEBtn[] Lbtn_btnGift = new UILEBtn[6];

	// Token: 0x040030C1 RID: 12481
	private Image Img_Gift;

	// Token: 0x040030C2 RID: 12482
	private Image Img_GiftNew;

	// Token: 0x040030C3 RID: 12483
	private Image Img_KeyBar;

	// Token: 0x040030C4 RID: 12484
	private Image[] Img_GetStatus = new Image[6];

	// Token: 0x040030C5 RID: 12485
	private Image[] Img_Clock = new Image[6];

	// Token: 0x040030C6 RID: 12486
	private Image[] Img_GiftKind = new Image[6];

	// Token: 0x040030C7 RID: 12487
	private Image[] Img_GiftLight = new Image[6];

	// Token: 0x040030C8 RID: 12488
	private Image Img_NoGift;

	// Token: 0x040030C9 RID: 12489
	private Image Img_GiftHint;

	// Token: 0x040030CA RID: 12490
	private Image Img_LVHint;

	// Token: 0x040030CB RID: 12491
	private UIText text_Lv;

	// Token: 0x040030CC RID: 12492
	private UIText text_BarValue;

	// Token: 0x040030CD RID: 12493
	private UIText text_GiftMax;

	// Token: 0x040030CE RID: 12494
	private UIText text_KeyValue;

	// Token: 0x040030CF RID: 12495
	private UIText text_GiftName;

	// Token: 0x040030D0 RID: 12496
	private UIText text_GiftHint;

	// Token: 0x040030D1 RID: 12497
	private UIText text_LVHint;

	// Token: 0x040030D2 RID: 12498
	private UIText[] text_btnStatus = new UIText[6];

	// Token: 0x040030D3 RID: 12499
	private UIText[] text_ItemGetStatus = new UIText[6];

	// Token: 0x040030D4 RID: 12500
	private UIText[] text_ItemTime = new UIText[6];

	// Token: 0x040030D5 RID: 12501
	private UIText[] text_ItemExp = new UIText[6];

	// Token: 0x040030D6 RID: 12502
	private UIText[] text_ItemNum = new UIText[6];

	// Token: 0x040030D7 RID: 12503
	private UIText[] text_ItemName = new UIText[6];

	// Token: 0x040030D8 RID: 12504
	private UIText[] text_tmpStr = new UIText[3];

	// Token: 0x040030D9 RID: 12505
	private CString Cstr_Lv;

	// Token: 0x040030DA RID: 12506
	private CString Cstr_BarValue;

	// Token: 0x040030DB RID: 12507
	private CString Cstr_GiftMax;

	// Token: 0x040030DC RID: 12508
	private CString Cstr_KeyValue;

	// Token: 0x040030DD RID: 12509
	private CString[] Cstr_ItemTime = new CString[6];

	// Token: 0x040030DE RID: 12510
	private CString[] Cstr_ItemExp = new CString[6];

	// Token: 0x040030DF RID: 12511
	private CString[] Cstr_ItemNum = new CString[6];

	// Token: 0x040030E0 RID: 12512
	private CString[] Cstr_ItemName = new CString[6];

	// Token: 0x040030E1 RID: 12513
	private string[] mStatus = new string[5];

	// Token: 0x040030E2 RID: 12514
	private Material m_Mat;

	// Token: 0x040030E3 RID: 12515
	private UISpritesArray SArray;

	// Token: 0x040030E4 RID: 12516
	private List<float> tmplist = new List<float>();

	// Token: 0x040030E5 RID: 12517
	private Color mColor_G = new Color(0.5412f, 0.839f, 0.3922f);

	// Token: 0x040030E6 RID: 12518
	private Color mColor_R = new Color(1f, 0.5098f, 0.4784f);

	// Token: 0x040030E7 RID: 12519
	private Equip tmpEquip;

	// Token: 0x040030E8 RID: 12520
	private float uiTimeStep;

	// Token: 0x040030E9 RID: 12521
	private Vector2 bezierCenter = new Vector2(0f, 100f);

	// Token: 0x040030EA RID: 12522
	private Vector2 bezierCenter2 = new Vector2(0f, 100f);

	// Token: 0x040030EB RID: 12523
	private Vector2 v2Begin = new Vector2(-263f, -39f);

	// Token: 0x040030EC RID: 12524
	private Vector2 v2End;

	// Token: 0x040030ED RID: 12525
	private Equip tmpEQ;

	// Token: 0x040030EE RID: 12526
	private long tmpValue;

	// Token: 0x040030EF RID: 12527
	private bool bShowGetNewGift;
}
