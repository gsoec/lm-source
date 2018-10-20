using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005C7 RID: 1479
public class UIKingdom_Classifieds : GUIWindow, IUIButtonClickHandler
{
	// Token: 0x06001D3B RID: 7483 RVA: 0x00346C80 File Offset: 0x00344E80
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.GameT = base.gameObject.transform;
		this.TTFont = this.GUIM.GetTTFFont();
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.Cstr_Translation = StringManager.Instance.SpawnString(100);
		this.InputCString = StringManager.Instance.SpawnString(1200);
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.GameT.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.GameT.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		if (!DataManager.MapDataController.IsInMyAllianceKingdom(false) || !DataManager.MapDataController.IsKing())
		{
			this.mKingdom = 1;
		}
		this.btn_Black = this.GameT.GetChild(0).GetComponent<UIButton>();
		this.btn_Black.m_Handler = this;
		this.btn_Black.m_BtnID1 = 6;
		this.text_Title = this.GameT.GetChild(3).GetChild(1).GetComponent<UIText>();
		this.text_Title.font = this.TTFont;
		this.text_Title.text = this.DM.mStringTable.GetStringByID(1444u);
		this.btn_EXIT = this.GameT.GetChild(4).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.door.LoadMaterial();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.GameT.GetChild(4).GetComponent<RectTransform>().anchoredPosition = new Vector2(-92f, -42f);
		}
		this.mInput = this.GameT.GetChild(5).GetComponent<UIEmojiInput>();
		this.mInput.onEndEdit.AddListener(delegate(string id)
		{
			this.ChangText(id);
		});
		this.text_Input1 = this.mInput.textComponent;
		this.text_Input1.font = this.TTFont;
		this.text_Input2 = (this.mInput.placeholder as UIText);
		this.text_Input2.font = this.TTFont;
		this.mInput.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
		this.KingdomT = this.GameT.GetChild(6);
		this.btn_Input_Edit = this.KingdomT.GetChild(0).GetComponent<UIButton>();
		this.btn_Input_Edit.m_Handler = this;
		this.btn_Input_Edit.m_BtnID1 = 2;
		this.btn_Input = this.KingdomT.GetChild(1).GetComponent<UIButton>();
		this.btn_Input.m_Handler = this;
		this.btn_Input.m_BtnID1 = 3;
		this.btn_Mail = this.KingdomT.GetChild(2).GetComponent<UIButton>();
		this.btn_Mail.m_Handler = this;
		this.btn_Mail.m_BtnID1 = 1;
		this.btn_Mail.m_EffectType = e_EffectType.e_Scale;
		this.btn_Mail.transition = Selectable.Transition.None;
		this.text_Mail = this.KingdomT.GetChild(2).GetChild(1).GetComponent<UIText>();
		this.text_Mail.font = this.TTFont;
		this.text_Mail.text = this.DM.mStringTable.GetStringByID(1445u);
		this.ClassifiedsT = this.GameT.GetChild(7);
		this.ClassifiedsT.GetComponent<RectTransform>().anchoredPosition = new Vector2(1f, 170f);
		this.btn_Translation = this.ClassifiedsT.GetChild(0).GetComponent<UIButton>();
		this.btn_Translation.m_Handler = this;
		this.btn_Translation.m_BtnID1 = 7;
		this.Img_Translate = this.ClassifiedsT.GetChild(1).GetComponent<Image>();
		this.text_Translation = this.ClassifiedsT.GetChild(2).GetComponent<UIText>();
		this.text_Translation.font = this.TTFont;
		this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052u);
		this.text_Translation.color = new Color(0.69f, 0.596f, 0.498f);
		if (this.text_Translation.preferredWidth > this.text_Translation.rectTransform.sizeDelta.x)
		{
			this.text_Translation.rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, this.text_Translation.rectTransform.sizeDelta.y);
		}
		if (this.GUIM.IsArabic)
		{
			this.text_Translation.UpdateArabicPos();
		}
		this.EditT = this.GameT.GetChild(8);
		this.btn_Input_C = this.EditT.GetChild(0).GetComponent<UIButton>();
		this.btn_Input_C.m_Handler = this;
		this.btn_Input_C.m_BtnID1 = 5;
		this.btn_Input_C.m_EffectType = e_EffectType.e_Scale;
		this.btn_Input_C.transition = Selectable.Transition.None;
		this.text_Input_C = this.EditT.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.text_Input_C.font = this.TTFont;
		this.text_Input_C.text = this.DM.mStringTable.GetStringByID(513u);
		this.btn_Input_OK = this.EditT.GetChild(1).GetComponent<UIButton>();
		this.btn_Input_OK.m_Handler = this;
		this.btn_Input_OK.m_BtnID1 = 4;
		this.btn_Input_OK.m_EffectType = e_EffectType.e_Scale;
		this.btn_Input_OK.transition = Selectable.Transition.None;
		this.text_Input_OK = this.EditT.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.text_Input_OK.font = this.TTFont;
		this.text_Input_OK.text = this.DM.mStringTable.GetStringByID(1448u);
		this.text_InputCheck = this.GameT.GetChild(9).GetComponent<UIText>();
		this.text_InputCheck.font = this.TTFont;
		this.text_InputCheck.alignment = TextAnchor.UpperLeft;
		this.btn_I = this.GameT.GetChild(10).GetComponent<UIButton>();
		if (this.GUIM.IsArabic)
		{
			this.btn_I.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.btn_I.m_Handler = this;
		this.btn_I.m_BtnID1 = 8;
		this.btn_I.m_EffectType = e_EffectType.e_Scale;
		this.btn_I.transition = Selectable.Transition.None;
		if (this.DM.mKingdomClassifieds != string.Empty)
		{
			this.mInput.text = StringManager.InputTemp;
			this.mInput.text = this.DM.mKingdomClassifieds;
		}
		this.mInput.enabled = false;
		if (this.mKingdom == 0)
		{
			this.KingdomT.gameObject.SetActive(true);
			if (this.DM.mKingdomClassifieds == string.Empty)
			{
				this.text_Input2.text = this.DM.mStringTable.GetStringByID(1446u);
			}
			this.btn_I.gameObject.SetActive(true);
		}
		else
		{
			this.btn_I.gameObject.SetActive(false);
		}
		this.SetShowClassifiedsT();
		this.bOpenEnd = true;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 1);
		UIButton component = base.transform.GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 0;
		UnityEngine.Object.Destroy(base.transform.GetChild(1).GetComponent<IgnoreRaycast>());
		UnityEngine.Object.Destroy(base.transform.GetChild(2).GetComponent<IgnoreRaycast>());
	}

	// Token: 0x06001D3C RID: 7484 RVA: 0x003474BC File Offset: 0x003456BC
	public void ChangText(string ID)
	{
		this.text_InputCheck.text = ID;
		this.text_InputCheck.SetAllDirty();
		this.text_InputCheck.cachedTextGenerator.Invalidate();
		this.text_InputCheck.cachedTextGeneratorForLayout.Invalidate();
		this.mInput.text = StringManager.InputTemp;
		this.mInput.text = ID;
		this.OpenInputCheck(true);
		this.InputCheck = true;
	}

	// Token: 0x06001D3D RID: 7485 RVA: 0x0034752C File Offset: 0x0034572C
	protected char OnValidateInput(string text, int index, char check)
	{
		int num = Encoding.UTF8.GetByteCount(text) + Encoding.UTF8.GetByteCount(check.ToString());
		if (num > 1024)
		{
			return '\0';
		}
		this.InputCString.Length = 0;
		this.InputCString.Append(text);
		this.InputCString.Append(check.ToString());
		this.text_InputCheck.text = this.InputCString.ToString();
		this.text_InputCheck.SetAllDirty();
		this.text_InputCheck.cachedTextGenerator.Invalidate();
		this.text_InputCheck.cachedTextGeneratorForLayout.Invalidate();
		if (this.text_InputCheck.preferredHeight > 320f)
		{
			return '\0';
		}
		return check;
	}

	// Token: 0x06001D3E RID: 7486 RVA: 0x003475E8 File Offset: 0x003457E8
	public override void OnClose()
	{
		if (this.Cstr_Translation != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Translation);
		}
		if (this.InputCString != null)
		{
			StringManager.Instance.DeSpawnString(this.InputCString);
		}
	}

	// Token: 0x06001D3F RID: 7487 RVA: 0x00347630 File Offset: 0x00345830
	public void OnButtonClick(UIButton sender)
	{
		if (this.bInput && !this.InputCheck && sender.m_BtnID1 == 6)
		{
			this.OpenInputCheck(true);
			this.mInput.enabled = false;
			return;
		}
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.door != null)
			{
				this.door.CloseMenu(false);
			}
			break;
		case 1:
			if (DataManager.MapDataController.CheckKingFunction(eKingFunction.eAnnouncement))
			{
				if (this.text_Input1.text.Length == 0 || this.text_Input1.text == this.DM.mStringTable.GetStringByID(1446u))
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1447u), 255, true);
				}
				else
				{
					GUIManager.Instance.OpenSpendWindow_Normal(this, this.DM.mStringTable.GetStringByID(1445u), this.DM.mStringTable.GetStringByID(1450u), 200, 0, 0, this.DM.mStringTable.GetStringByID(1451u), false);
				}
			}
			break;
		case 2:
			if (DataManager.MapDataController.CheckKingFunction(eKingFunction.eAnnouncement))
			{
				this.mInput.enabled = true;
				this.mInput.ActivateInputField();
				this.bInput = true;
				this.KingdomT.gameObject.SetActive(false);
			}
			break;
		case 3:
			if (DataManager.MapDataController.CheckKingFunction(eKingFunction.eAnnouncement))
			{
				this.mInput.enabled = true;
				this.mInput.ActivateInputField();
				this.bInput = true;
				this.KingdomT.gameObject.SetActive(false);
				this.EditT.gameObject.SetActive(false);
			}
			break;
		case 4:
			if (DataManager.MapDataController.CheckKingFunction(eKingFunction.eAnnouncement))
			{
				if (this.text_Input1.text.Length == 0 || this.text_Input1.text == this.DM.mStringTable.GetStringByID(1446u))
				{
					this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1447u), 255, true);
				}
				else
				{
					this.DM.SendModifyKingdomBullitin(this.mInput.text);
				}
			}
			break;
		case 5:
			this.mInput.enabled = false;
			this.OpenInputCheck(false);
			this.bInput = false;
			this.KingdomT.gameObject.SetActive(true);
			this.mInput.text = StringManager.InputTemp;
			if (this.DM.mKingdomClassifieds != string.Empty)
			{
				this.mInput.text = this.DM.mKingdomClassifieds;
			}
			else
			{
				this.mInput.text = string.Empty;
			}
			break;
		case 7:
			if (this.DM.bNeedTranslateClassifieds && !this.DM.bTranslateClassifieds && !this.DM.bWaitTranslateClassifieds)
			{
				this.btn_Translation.gameObject.SetActive(false);
				this.Img_Translate.gameObject.SetActive(true);
				this.DM.bWaitTranslateClassifieds = true;
				IGGSDKPlugin.Translate_KA(this.DM.mKingdomClassifieds);
			}
			else
			{
				if (!this.bShowTranslate)
				{
					this.mInput.text = StringManager.InputTemp;
					this.mInput.text = this.DM.mKingdomClassifieds;
					this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052u);
					this.bShowTranslate = true;
					this.text_Input1.resizeTextForBestFit = false;
				}
				else
				{
					this.mInput.text = StringManager.InputTemp;
					this.mInput.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
					this.text_InputCheck.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
					this.text_InputCheck.SetAllDirty();
					this.text_InputCheck.cachedTextGenerator.Invalidate();
					this.text_InputCheck.cachedTextGeneratorForLayout.Invalidate();
					if (this.text_InputCheck.preferredHeight > 320f)
					{
						this.text_Input1.resizeTextForBestFit = true;
						this.text_Input1.resizeTextMaxSize = 17;
						this.text_Input1.resizeTextMinSize = 10;
						this.text_Input1.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
						this.text_Input1.SetAllDirty();
						this.text_Input1.cachedTextGenerator.Invalidate();
						this.text_Input1.cachedTextGeneratorForLayout.Invalidate();
					}
					this.Cstr_Translation.ClearString();
					this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte)this.DM.mKingdomClassifieds_L));
					this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054u));
					this.text_Translation.text = this.Cstr_Translation.ToString();
					this.bShowTranslate = false;
				}
				this.text_Translation.SetAllDirty();
				this.text_Translation.cachedTextGenerator.Invalidate();
				this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
				if (this.text_Translation.preferredWidth > this.text_Translation.rectTransform.sizeDelta.x)
				{
					this.text_Translation.rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, this.text_Translation.rectTransform.sizeDelta.y);
				}
				if (this.GUIM.IsArabic)
				{
					this.text_Translation.UpdateArabicPos();
				}
			}
			break;
		case 8:
			this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(1444u), this.DM.mStringTable.GetStringByID(1477u), null, null, 0, 0, true, true);
			break;
		}
	}

	// Token: 0x06001D40 RID: 7488 RVA: 0x00347C78 File Offset: 0x00345E78
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 != 0)
			{
				if (arg1 == 1)
				{
					MallManager.Instance.Send_Mall_Info();
				}
			}
			else if (this.DM.RoleAttr.Diamond >= 200u)
			{
				this.DM.SendMailBullitin();
			}
			else
			{
				this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966u), this.DM.mStringTable.GetStringByID(646u), this.DM.mStringTable.GetStringByID(3968u), this, 1, 0, true, false, false, false, false);
			}
		}
	}

	// Token: 0x06001D41 RID: 7489 RVA: 0x00347D30 File Offset: 0x00345F30
	private void SetShowClassifiedsT()
	{
		if (this.mKingdom != 0 && GUIManager.Instance.CheckNeedTranslate(this.DM.mKingdomClassifieds))
		{
			this.ClassifiedsT.gameObject.SetActive(true);
		}
		else
		{
			this.ClassifiedsT.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001D42 RID: 7490 RVA: 0x00347D8C File Offset: 0x00345F8C
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
	}

	// Token: 0x06001D43 RID: 7491 RVA: 0x00347DC4 File Offset: 0x00345FC4
	public void Refresh_FontTexture()
	{
		if (this.text_Title != null && this.text_Title.enabled)
		{
			this.text_Title.enabled = false;
			this.text_Title.enabled = true;
		}
		if (this.text_Input1 != null && this.text_Input1.enabled)
		{
			this.text_Input1.enabled = false;
			this.text_Input1.enabled = true;
		}
		if (this.text_Input2 != null && this.text_Input2.enabled)
		{
			this.text_Input2.enabled = false;
			this.text_Input2.enabled = true;
		}
		if (this.text_Mail != null && this.text_Mail.enabled)
		{
			this.text_Mail.enabled = false;
			this.text_Mail.enabled = true;
		}
		if (this.text_Input_C != null && this.text_Input_C.enabled)
		{
			this.text_Input_C.enabled = false;
			this.text_Input_C.enabled = true;
		}
		if (this.text_Input_OK != null && this.text_Input_OK.enabled)
		{
			this.text_Input_OK.enabled = false;
			this.text_Input_OK.enabled = true;
		}
		if (this.text_Translation != null && this.text_Translation.enabled)
		{
			this.text_Translation.enabled = false;
			this.text_Translation.enabled = true;
		}
		if (this.text_InputCheck != null && this.text_InputCheck.enabled)
		{
			this.text_InputCheck.enabled = false;
			this.text_InputCheck.enabled = true;
		}
	}

	// Token: 0x06001D44 RID: 7492 RVA: 0x00347F9C File Offset: 0x0034619C
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 0:
			if (this.bOpenEnd)
			{
				if (this.EditT != null)
				{
					this.OpenInputCheck(false);
				}
				this.bInput = false;
				this.mInput.enabled = false;
				if (this.KingdomT != null)
				{
					this.KingdomT.gameObject.SetActive(true);
				}
			}
			break;
		case 1:
			if (this.bOpenEnd)
			{
				if (this.mInput != null)
				{
					this.mInput.text = StringManager.InputTemp;
					this.mInput.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
					this.text_InputCheck.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
					this.text_InputCheck.SetAllDirty();
					this.text_InputCheck.cachedTextGenerator.Invalidate();
					this.text_InputCheck.cachedTextGeneratorForLayout.Invalidate();
					if (this.text_InputCheck.preferredHeight > 320f)
					{
						this.text_Input1.resizeTextForBestFit = true;
						this.text_Input1.resizeTextMaxSize = 17;
						this.text_Input1.resizeTextMinSize = 10;
						this.text_Input1.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
						this.text_Input1.SetAllDirty();
						this.text_Input1.cachedTextGenerator.Invalidate();
						this.text_Input1.cachedTextGeneratorForLayout.Invalidate();
					}
				}
				this.btn_Translation.gameObject.SetActive(true);
				this.Img_Translate.gameObject.SetActive(false);
				this.Cstr_Translation.ClearString();
				this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte)this.DM.mKingdomClassifieds_L));
				this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054u));
				this.text_Translation.text = this.Cstr_Translation.ToString();
				this.text_Translation.SetAllDirty();
				this.text_Translation.cachedTextGenerator.Invalidate();
				this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
				if (this.text_Translation.preferredWidth > this.text_Translation.rectTransform.sizeDelta.x)
				{
					this.text_Translation.rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, this.text_Translation.rectTransform.sizeDelta.y);
				}
				if (this.GUIM.IsArabic)
				{
					this.text_Translation.UpdateArabicPos();
				}
			}
			break;
		case 2:
			if (this.bOpenEnd)
			{
				this.btn_Translation.gameObject.SetActive(true);
				this.Img_Translate.gameObject.SetActive(false);
				this.btn_Translation.gameObject.SetActive(true);
				this.Img_Translate.gameObject.SetActive(false);
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9077u), 255, true);
			}
			break;
		case 3:
			if (this.bOpenEnd)
			{
				if (this.DM.mKingdomClassifieds == string.Empty)
				{
					this.text_Input2.text = this.DM.mStringTable.GetStringByID(1446u);
				}
				else
				{
					this.mInput.text = StringManager.InputTemp;
					this.mInput.text = this.DM.mKingdomClassifieds;
				}
			}
			break;
		case 4:
			if (this.bOpenEnd)
			{
				this.SetShowClassifiedsT();
				if (this.DM.bNeedTranslateClassifieds)
				{
					this.bShowTranslate = false;
				}
				if (!this.bShowTranslate)
				{
					this.mInput.text = StringManager.InputTemp;
					this.mInput.text = this.DM.mKingdomClassifieds;
					this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052u);
					this.text_Input1.resizeTextForBestFit = false;
				}
				else
				{
					this.mInput.text = StringManager.InputTemp;
					this.mInput.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
					this.text_InputCheck.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
					this.text_InputCheck.SetAllDirty();
					this.text_InputCheck.cachedTextGenerator.Invalidate();
					this.text_InputCheck.cachedTextGeneratorForLayout.Invalidate();
					if (this.text_InputCheck.preferredHeight > 320f)
					{
						this.text_Input1.resizeTextForBestFit = true;
						this.text_Input1.resizeTextMaxSize = 17;
						this.text_Input1.resizeTextMinSize = 10;
						this.text_Input1.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
						this.text_Input1.SetAllDirty();
						this.text_Input1.cachedTextGenerator.Invalidate();
						this.text_Input1.cachedTextGeneratorForLayout.Invalidate();
					}
					this.Cstr_Translation.ClearString();
					this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte)this.DM.mKingdomClassifieds_L));
					this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054u));
					this.text_Translation.text = this.Cstr_Translation.ToString();
				}
				this.text_Translation.SetAllDirty();
				this.text_Translation.cachedTextGenerator.Invalidate();
				this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
				if (this.text_Translation.preferredWidth > this.text_Translation.rectTransform.sizeDelta.x)
				{
					this.text_Translation.rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, this.text_Translation.rectTransform.sizeDelta.y);
				}
				if (this.GUIM.IsArabic)
				{
					this.text_Translation.UpdateArabicPos();
				}
			}
			break;
		case 5:
			this.DM.SendKingdomBullitin_Info(false);
			if (this.mKingdom == 0)
			{
				if (!this.bInput)
				{
					this.KingdomT.gameObject.SetActive(true);
				}
				this.btn_I.gameObject.SetActive(true);
			}
			else
			{
				this.KingdomT.gameObject.SetActive(false);
				this.mInput.enabled = false;
				this.btn_I.gameObject.SetActive(false);
			}
			this.SetShowClassifiedsT();
			break;
		}
	}

	// Token: 0x06001D45 RID: 7493 RVA: 0x0034866C File Offset: 0x0034686C
	public void OpenInputCheck(bool bShow)
	{
		this.InputCheck = bShow;
		this.EditT.gameObject.SetActive(bShow);
	}

	// Token: 0x06001D46 RID: 7494 RVA: 0x00348688 File Offset: 0x00346888
	public override bool OnBackButtonClick()
	{
		if (this.bInput || this.EditT.gameObject.activeSelf)
		{
			this.OpenInputCheck(false);
			this.bInput = false;
			this.KingdomT.gameObject.SetActive(true);
			return true;
		}
		return false;
	}

	// Token: 0x06001D47 RID: 7495 RVA: 0x003486D8 File Offset: 0x003468D8
	private void Start()
	{
	}

	// Token: 0x06001D48 RID: 7496 RVA: 0x003486DC File Offset: 0x003468DC
	private void Update()
	{
		if (this.DM.bTranslateClassifieds)
		{
			this.GUIM.UpdateUI(EGUIWindow.UI_Kingdom_Classifieds, 1, 0);
			this.DM.bTranslateClassifieds = false;
			this.DM.bNeedTranslateClassifieds = false;
		}
		if (this.DM.bTranslateClassifiedsFailed)
		{
			this.GUIM.UpdateUI(EGUIWindow.UI_Kingdom_Classifieds, 2, 0);
			this.DM.bTranslateClassifiedsFailed = false;
		}
	}

	// Token: 0x04005969 RID: 22889
	private Transform GameT;

	// Token: 0x0400596A RID: 22890
	private Transform KingdomT;

	// Token: 0x0400596B RID: 22891
	private Transform ClassifiedsT;

	// Token: 0x0400596C RID: 22892
	private Transform EditT;

	// Token: 0x0400596D RID: 22893
	private DataManager DM;

	// Token: 0x0400596E RID: 22894
	private GUIManager GUIM;

	// Token: 0x0400596F RID: 22895
	private Font TTFont;

	// Token: 0x04005970 RID: 22896
	private Door door;

	// Token: 0x04005971 RID: 22897
	private UIButton btn_EXIT;

	// Token: 0x04005972 RID: 22898
	private UIButton btn_Input_OK;

	// Token: 0x04005973 RID: 22899
	private UIButton btn_Input_C;

	// Token: 0x04005974 RID: 22900
	private UIButton btn_Input_Edit;

	// Token: 0x04005975 RID: 22901
	private UIButton btn_Input;

	// Token: 0x04005976 RID: 22902
	private UIButton btn_Mail;

	// Token: 0x04005977 RID: 22903
	private UIButton btn_Black;

	// Token: 0x04005978 RID: 22904
	private UIButton btn_Translation;

	// Token: 0x04005979 RID: 22905
	private UIButton btn_I;

	// Token: 0x0400597A RID: 22906
	private Image Img_Translate;

	// Token: 0x0400597B RID: 22907
	private UIEmojiInput mInput;

	// Token: 0x0400597C RID: 22908
	private UIText text_Input1;

	// Token: 0x0400597D RID: 22909
	private UIText text_Input2;

	// Token: 0x0400597E RID: 22910
	private UIText text_Title;

	// Token: 0x0400597F RID: 22911
	private UIText text_Mail;

	// Token: 0x04005980 RID: 22912
	private UIText text_Input_C;

	// Token: 0x04005981 RID: 22913
	private UIText text_Input_OK;

	// Token: 0x04005982 RID: 22914
	private UIText text_Translation;

	// Token: 0x04005983 RID: 22915
	private UIText text_InputCheck;

	// Token: 0x04005984 RID: 22916
	private CString Cstr_Translation;

	// Token: 0x04005985 RID: 22917
	private CString InputCString;

	// Token: 0x04005986 RID: 22918
	private byte mKingdom;

	// Token: 0x04005987 RID: 22919
	private bool bInput;

	// Token: 0x04005988 RID: 22920
	private bool InputCheck;

	// Token: 0x04005989 RID: 22921
	private bool bShowTranslate;

	// Token: 0x0400598A RID: 22922
	private bool bOpenEnd;
}
