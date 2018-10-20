using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005F4 RID: 1524
public class UILordEquipSetEdit : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUILEBtnClickHandler
{
	// Token: 0x06001DEB RID: 7659 RVA: 0x00386954 File Offset: 0x00384B54
	public override void OnOpen(int arg1, int arg2)
	{
		this.door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
		this.DM = DataManager.Instance;
		if (this.DM.mLordEquip == null)
		{
			this.DM.mLordEquip = LordEquipData.Instance();
		}
		this.SPHeight = new List<float>();
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		UIText component = this.AGS_Form.GetChild(0).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component.SetCheckArabic(true);
		this.AllTextObject[0] = component;
		Image component2 = this.AGS_Form.GetChild(1).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close_base");
		component2.material = this.door.LoadMaterial();
		component2.enabled = !GUIManager.Instance.bOpenOnIPhoneX;
		component2 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close");
		component2.material = this.door.LoadMaterial();
		UIButton component3 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 99;
		component3.m_EffectType = e_EffectType.e_Scale;
		component3.transition = Selectable.Transition.None;
		component3 = this.AGS_Form.GetChild(2).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 4;
		component3.m_EffectType = e_EffectType.e_Scale;
		component3 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 2;
		component3.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(9702u);
		this.AllTextObject[1] = component;
		component3 = this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 1;
		component3.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(4).GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(929u);
		this.AllTextObject[2] = component;
		component3 = this.AGS_Form.GetChild(5).GetChild(8).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.transition = Selectable.Transition.None;
		component3.m_EffectType = e_EffectType.e_Scale;
		GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(8).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
		component3 = this.AGS_Form.GetChild(5).GetChild(9).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.transition = Selectable.Transition.None;
		component3.m_EffectType = e_EffectType.e_Scale;
		GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(9).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
		component3 = this.AGS_Form.GetChild(5).GetChild(10).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.transition = Selectable.Transition.None;
		component3.m_EffectType = e_EffectType.e_Scale;
		GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(10).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
		component3 = this.AGS_Form.GetChild(5).GetChild(11).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.transition = Selectable.Transition.None;
		component3.m_EffectType = e_EffectType.e_Scale;
		GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(11).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
		component3 = this.AGS_Form.GetChild(5).GetChild(12).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.transition = Selectable.Transition.None;
		component3.m_EffectType = e_EffectType.e_Scale;
		GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(12).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
		component3 = this.AGS_Form.GetChild(5).GetChild(13).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.transition = Selectable.Transition.None;
		component3.m_EffectType = e_EffectType.e_Scale;
		GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(13).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
		component3 = this.AGS_Form.GetChild(5).GetChild(14).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.transition = Selectable.Transition.None;
		component3.m_EffectType = e_EffectType.e_Scale;
		GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(14).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
		component3 = this.AGS_Form.GetChild(5).GetChild(15).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.transition = Selectable.Transition.None;
		component3.m_EffectType = e_EffectType.e_Scale;
		GameConstants.SetPivot(this.AGS_Form.GetChild(5).GetChild(15).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
		for (int i = 0; i < 8; i++)
		{
			UILEBtn component4 = this.AGS_Form.GetChild(5).GetChild(16 + i).GetComponent<UILEBtn>();
			component4.m_Handler = this;
			component4.gameObject.SetActive(false);
			this.LEquipLight[i] = this.AGS_Form.GetChild(5).GetChild(i + 8).GetChild(0).GetComponent<Image>();
		}
		component = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(1048u);
		this.AllTextObject[3] = component;
		this.AGS_ScrollPanel = this.AGS_Form.GetChild(6).GetChild(2).GetComponent<ScrollPanel>();
		component = this.AGS_Form.GetChild(6).GetChild(3).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[4] = component;
		component = this.AGS_Form.GetChild(6).GetChild(3).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		this.AllTextObject[5] = component;
		component = this.AGS_Form.GetChild(6).GetChild(3).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		component.alignment = TextAnchor.UpperLeft;
		this.AllTextObject[6] = component;
		component3 = this.AGS_Form.GetChild(6).GetChild(3).GetChild(3).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.transition = Selectable.Transition.None;
		component3.m_EffectType = e_EffectType.e_Normal;
		component3.m_BtnID1 = 101;
		UIButtonHint uibuttonHint = component3.gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		this.AGS_Forging = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UISpritesArray>();
		this.ForgingIcon = this.AGS_Form.GetChild(7).GetComponent<RectTransform>();
		this.ForgingIcon.GetComponent<Image>().color = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, 120);
		GameObject gameObject = new GameObject("TextSizeCount");
		this.BestHeight = gameObject.AddComponent<UIText>();
		this.BestHeight.font = ttffont;
		this.BestHeight.fontSize = 17;
		this.BestHeight.text = string.Empty;
		this.BestHeight.rectTransform.transform.position = new Vector3(1000f, 0f, 0f);
		if (UILordEquipSetEdit.showingSet == null)
		{
			UILordEquipSetEdit.showingSet = new LordEquipSet();
		}
		if (UILordEquipSetEdit.SetDataIndex == null)
		{
			UILordEquipSetEdit.SetDataIndex = new int[8];
		}
		this.isLoading = true;
		LordEquipData.CheckEquipExpired();
	}

	// Token: 0x06001DEC RID: 7660 RVA: 0x00387180 File Offset: 0x00385380
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
		if (this.AGS_ScrollPanel != null && this.AGS_ScrollPanel.gameObject.activeInHierarchy)
		{
			Transform child = this.AGS_ScrollPanel.transform.GetChild(0);
			for (int j = 0; j < child.childCount; j++)
			{
				Transform child2 = child.GetChild(j);
				if (child2.gameObject.activeInHierarchy)
				{
					UIText component = child2.GetChild(0).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child2.GetChild(1).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child2.GetChild(2).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
				}
			}
		}
	}

	// Token: 0x06001DED RID: 7661 RVA: 0x003872F0 File Offset: 0x003854F0
	public override void OnClose()
	{
		for (int i = 0; i < this.EffDescText.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.EffDescText[i]);
		}
		StringManager.Instance.DeSpawnString(this.HintStr);
	}

	// Token: 0x06001DEE RID: 7662 RVA: 0x0038733C File Offset: 0x0038553C
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			this.reflashItem();
			break;
		case 2:
			this.door.CloseMenu(false);
			break;
		case 3:
			this.ReCheckItem();
			this.reflashItem();
			break;
		}
	}

	// Token: 0x06001DEF RID: 7663 RVA: 0x00387394 File Offset: 0x00385594
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
			this.reflashItem();
		}
	}

	// Token: 0x06001DF0 RID: 7664 RVA: 0x003873D0 File Offset: 0x003855D0
	private bool saveCheck(int skip = 0)
	{
		if (!UILordEquipSetEdit.ThingsChanged)
		{
			return false;
		}
		if ((skip & 1) != 1 && UILordEquipSetEdit.showingSet.Name.Length == 0)
		{
			GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5893u), this.DM.mStringTable.GetStringByID(9705u), 1, skip | 1, null, null);
			return false;
		}
		if ((skip & 2) != 2)
		{
			for (int i = 0; i < this.usedsolt; i++)
			{
				if (UILordEquipSetEdit.showingSet.SerialNO[i] == 0u)
				{
					GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5893u), this.DM.mStringTable.GetStringByID(9706u), 1, skip | 2, null, null);
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06001DF1 RID: 7665 RVA: 0x003874B4 File Offset: 0x003856B4
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		switch (btnID)
		{
		case 1:
			if (this.saveCheck(0))
			{
				GUIManager.Instance.UseOrSpend(GameConstants.LESaveItemID, this.DM.mStringTable.GetStringByID(9703u), 0, (ushort)UILordEquipSetEdit.SetIdx, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
			}
			break;
		case 2:
			for (int i = 0; i < UILordEquipSetEdit.showingSet.SerialNO.Length; i++)
			{
				UILordEquipSetEdit.showingSet.SerialNO[i] = 0u;
			}
			this.reflashItem();
			break;
		case 3:
			UILordEquipSetEdit.ChangingIdx = sender.m_BtnID2 - 1;
			UILordEquip.waitForReturn = eUI_LordEquipReturnKind.None;
			this.door.OpenMenu(EGUIWindow.UI_LordEquip, 3, sender.m_BtnID2, false);
			break;
		case 4:
			DataManager.Instance.OpenAllianceBox(37, 10, false, 0L);
			break;
		default:
			if (btnID == 99)
			{
				if (UILordEquipSetEdit.ThingsChanged)
				{
					if (UILordEquipSetEdit.showingSet.isSetEmpty())
					{
						this.door.CloseMenu(false);
						return;
					}
					GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5893u), this.DM.mStringTable.GetStringByID(9707u), 2, 0, null, null);
				}
				else
				{
					this.door.CloseMenu(false);
				}
			}
			break;
		}
	}

	// Token: 0x06001DF2 RID: 7666 RVA: 0x00387624 File Offset: 0x00385824
	public void OnButtonDown(UIButtonHint sender)
	{
		this.HintStr.ClearString();
		this.HintStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)sender.Parm1));
		this.HintStr.AppendFormat(this.DM.mStringTable.GetStringByID(16143u));
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 0, 320f, 20, this.HintStr, Vector2.zero);
	}

	// Token: 0x06001DF3 RID: 7667 RVA: 0x003876A4 File Offset: 0x003858A4
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(true);
	}

	// Token: 0x06001DF4 RID: 7668 RVA: 0x003876B8 File Offset: 0x003858B8
	public void OnLEButtonClick(UILEBtn sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID == 3)
		{
			UILordEquipSetEdit.ChangingIdx = sender.m_BtnID2 - 1;
			UILordEquip.waitForReturn = eUI_LordEquipReturnKind.None;
			this.door.OpenMenu(EGUIWindow.UI_LordEquip, 3, sender.m_BtnID2, false);
		}
	}

	// Token: 0x06001DF5 RID: 7669 RVA: 0x00387708 File Offset: 0x00385908
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 != 1)
			{
				if (arg1 == 2)
				{
					this.door.CloseMenu(false);
				}
			}
			else if (this.saveCheck(arg2))
			{
				this.openUseSpand = true;
			}
		}
	}

	// Token: 0x06001DF6 RID: 7670 RVA: 0x0038775C File Offset: 0x0038595C
	public void ButtonOnClick(GameObject sender, int parm1, int parm2)
	{
	}

	// Token: 0x06001DF7 RID: 7671 RVA: 0x00387760 File Offset: 0x00385960
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		Effect recordByKey = this.DM.EffectData.GetRecordByKey(this.effectCompareList[dataIdx].EffectID);
		if (this.effectCompareList[dataIdx].isTitel)
		{
			UIText component = item.transform.GetChild(0).GetComponent<UIText>();
			item.transform.GetChild(0).gameObject.SetActive(true);
			item.transform.GetChild(1).gameObject.SetActive(false);
			item.transform.GetChild(2).gameObject.SetActive(false);
			item.transform.GetChild(3).gameObject.SetActive(false);
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
			item.transform.GetChild(3).gameObject.SetActive(false);
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
				this.EffDescText[panelObjectIdx].AppendFormat("<color=#FFEC87FF>{0}</color> {1}{2}</color>");
			}
			else
			{
				float f = (float)this.effectCompareList[dataIdx].EffectValue / 100f;
				this.EffDescText[panelObjectIdx].FloatToFormat(f, 2, false);
				this.EffDescText[panelObjectIdx].AppendFormat("<color=#FFEC87FF>{0}</color> {1}{2}%</color>");
			}
			component.text = this.EffDescText[panelObjectIdx].ToString();
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
		}
		else
		{
			UIText component = item.transform.GetChild(2).GetComponent<UIText>();
			item.transform.GetChild(0).gameObject.SetActive(false);
			item.transform.GetChild(1).gameObject.SetActive(false);
			item.transform.GetChild(2).gameObject.SetActive(true);
			item.transform.GetChild(3).gameObject.SetActive(true);
			this.EffDescText[panelObjectIdx].ClearString();
			LordEquipData.GetNewGemEffectString(this.EffDescText[panelObjectIdx], (byte)this.effectCompareList[dataIdx].EffectID, this.effectCompareList[dataIdx].EffectValue, this.effectCompareList[dataIdx].isEven, this.effectCompareList[dataIdx].useForceColor);
			component.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, this.GetTextHeight(245f, this.EffDescText[panelObjectIdx], 18));
			component.text = this.EffDescText[panelObjectIdx].ToString();
			component.fontSize = 17;
			component.SetAllDirty();
			component.cachedTextGenerator.Invalidate();
			UIButtonHint component2 = item.transform.GetChild(3).GetComponent<UIButtonHint>();
			component2.Parm1 = (ushort)(7431 + (int)this.effectCompareList[dataIdx].fromPart);
			component2.m_Handler = this;
			UISpritesArray component3 = item.transform.GetChild(3).GetComponent<UISpritesArray>();
			component3.SetSpriteIndex((int)this.effectCompareList[dataIdx].fromPart);
		}
	}

	// Token: 0x06001DF8 RID: 7672 RVA: 0x00387BE0 File Offset: 0x00385DE0
	public static void loadSet(int index)
	{
		UILordEquipSetEdit.SetIdx = index;
		if (UILordEquipSetEdit.showingSet == null)
		{
			UILordEquipSetEdit.showingSet = new LordEquipSet();
		}
		if (UILordEquipSetEdit.SetDataIndex == null)
		{
			UILordEquipSetEdit.SetDataIndex = new int[8];
		}
		for (int i = 0; i < UILordEquipSetEdit.showingSet.SerialNO.Length; i++)
		{
			UILordEquipSetEdit.showingSet.SerialNO[i] = LordEquipData.Instance().LordEquipSets[index].SerialNO[i];
		}
		for (int j = 0; j < UILordEquipSetEdit.showingSet.SerialNO.Length; j++)
		{
			if (UILordEquipSetEdit.showingSet.SerialNO[j] != 0u)
			{
				bool flag = false;
				for (int k = 0; k < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; k++)
				{
					if (LordEquipData.Instance().LordEquip[k].SerialNO == UILordEquipSetEdit.showingSet.SerialNO[j])
					{
						UILordEquipSetEdit.SetDataIndex[j] = k;
						flag = true;
					}
				}
				if (!flag)
				{
					UILordEquipSetEdit.showingSet.SerialNO[j] = 0u;
					LordEquipData.Instance().LordEquipSets[index].SerialNO[j] = 0u;
				}
			}
		}
		if (UILordEquipSetEdit.showingSet.Name == null)
		{
			UILordEquipSetEdit.showingSet.Name = StringManager.Instance.SpawnString(30);
		}
		UILordEquipSetEdit.showingSet.Name.ClearString();
		UILordEquipSetEdit.showingSet.Name.Append(LordEquipData.Instance().LordEquipSets[index].Name);
		UILordEquipSetEdit.ThingsChanged = false;
	}

	// Token: 0x06001DF9 RID: 7673 RVA: 0x00387D5C File Offset: 0x00385F5C
	public void ReCheckItem()
	{
		for (int i = 0; i < UILordEquipSetEdit.showingSet.SerialNO.Length; i++)
		{
			if (UILordEquipSetEdit.showingSet.SerialNO[i] != 0u)
			{
				bool flag = false;
				for (int j = 0; j < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; j++)
				{
					if (LordEquipData.Instance().LordEquip[j].SerialNO == UILordEquipSetEdit.showingSet.SerialNO[i])
					{
						UILordEquipSetEdit.SetDataIndex[i] = j;
						flag = true;
					}
				}
				if (!flag)
				{
					UILordEquipSetEdit.showingSet.SerialNO[i] = 0u;
				}
			}
		}
	}

	// Token: 0x06001DFA RID: 7674 RVA: 0x00387DFC File Offset: 0x00385FFC
	public void AfterLoader()
	{
		if (this.Equips == null)
		{
			this.Equips = new RectTransform[8];
		}
		for (int i = 0; i < 8; i++)
		{
			UILEBtn component = this.AGS_Form.GetChild(5).GetChild(16 + i).GetComponent<UILEBtn>();
			GUIManager.Instance.InitLordEquipImg(component.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, true, true, 0, 0, 0, 0, 0, false);
			this.Equips[i] = component.transform.GetComponent<RectTransform>();
		}
		this.effectCompareList = new List<LordEquipEffectCompareSet>();
		for (int j = 0; j < this.EffDescText.Length; j++)
		{
			this.EffDescText[j] = StringManager.Instance.SpawnString(500);
		}
		this.HintStr = StringManager.Instance.SpawnString(500);
		this.AGS_ScrollPanel.IntiScrollPanel(445f, 0f, 0f, this.SPHeight, 18, this);
		this.reflashItem();
		this.isLoading = false;
	}

	// Token: 0x06001DFB RID: 7675 RVA: 0x00387EFC File Offset: 0x003860FC
	public void reflashItem()
	{
		if (UILordEquipSetEdit.SetName == null)
		{
			UILordEquipSetEdit.SetName = StringManager.Instance.SpawnString(30);
		}
		UILordEquipSetEdit.SetName.ClearString();
		if (UILordEquipSetEdit.showingSet.Name.Length == 0)
		{
			UILordEquipSetEdit.SetName.IntToFormat((long)(UILordEquipSetEdit.SetIdx + 1), 1, false);
			UILordEquipSetEdit.SetName.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(928u));
		}
		else
		{
			UILordEquipSetEdit.SetName.Append(UILordEquipSetEdit.showingSet.Name);
		}
		UIText component = this.AGS_Form.GetChild(0).GetChild(1).GetComponent<UIText>();
		component.text = UILordEquipSetEdit.SetName.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component.cachedTextGeneratorForLayout.Invalidate();
		int num = (int)component.preferredWidth / 2 + 30;
		RectTransform component2 = this.AGS_Form.GetChild(2).GetComponent<RectTransform>();
		component2.anchoredPosition = new Vector2((float)num, component2.anchoredPosition.y);
		this.effectCompareList.Clear();
		List<LordEquipEffectSet> effList = new List<LordEquipEffectSet>();
		for (int i = 0; i < 8; i++)
		{
			if (UILordEquipSetEdit.showingSet.SerialNO[i] != 0u)
			{
				for (int j = 0; j < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; j++)
				{
					if (LordEquipData.Instance().LordEquip[j].SerialNO == UILordEquipSetEdit.showingSet.SerialNO[i])
					{
						UILordEquipSetEdit.SetDataIndex[i] = j;
					}
				}
				LordEquipData.GetEffectList(LordEquipData.Instance().LordEquip[UILordEquipSetEdit.SetDataIndex[i]], effList, 0, (byte)Math.Min(5, i), true);
			}
		}
		LordEquipData.effectListAddToEffectCompareList(effList, this.effectCompareList);
		LordEquipData.EffectTitleListCreater(this.effectCompareList);
		this.ForgingIcon.gameObject.SetActive(false);
		if (this.DM.RoleAttr.LordEquipEventData.SerialNO != 0u)
		{
			for (int k = 0; k < 8; k++)
			{
				if (this.DM.RoleAttr.LordEquipEventData.SerialNO == UILordEquipSetEdit.showingSet.SerialNO[k])
				{
					this.ForgingIcon.SetParent(this.AGS_Form.GetChild(5).GetChild(k + 16));
					this.ForgingIcon.anchoredPosition = new Vector2(52f, -52f);
					this.ForgingIcon.gameObject.SetActive(true);
					break;
				}
			}
		}
		int num2;
		for (int l = 0; l < 8; l++)
		{
			if (UILordEquipSetEdit.showingSet.SerialNO[l] != 0u)
			{
				this.AGS_Form.GetChild(5).GetChild(l + 8).gameObject.SetActive(false);
				this.Equips[l].gameObject.SetActive(true);
				GUIManager.Instance.ChangeLordEquipImg(this.Equips[l].transform, LordEquipData.Instance().LordEquip[UILordEquipSetEdit.SetDataIndex[l]], eLordEquipDisplayKind.Item_Gems, false);
				this.Equips[l].GetComponent<UILEBtn>().SetCountdown(LordEquipData.Instance().LordEquip[UILordEquipSetEdit.SetDataIndex[l]].ExpireTime, false);
			}
			else
			{
				this.AGS_Form.GetChild(5).GetChild(l + 8).gameObject.SetActive(true);
				this.Equips[l].gameObject.SetActive(false);
				num2 = UILordEquipSetEdit.CheckHaveEquipKind((byte)(l + 21), false);
				if (num2 > 0)
				{
					this.AGS_Form.GetChild(5).GetChild(l + 8).GetChild(0).gameObject.SetActive(num2 == 1);
					this.AGS_Form.GetChild(5).GetChild(l + 8).GetChild(1).gameObject.SetActive(true);
					this.AGS_Form.GetChild(5).GetChild(l + 8).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(2 - num2);
				}
				else
				{
					this.AGS_Form.GetChild(5).GetChild(l + 8).GetChild(0).gameObject.SetActive(false);
					this.AGS_Form.GetChild(5).GetChild(l + 8).GetChild(1).gameObject.SetActive(false);
				}
			}
		}
		num2 = UILordEquipSetEdit.CheckHaveEquipKind(26, true);
		RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(15, 0);
		if (buildData.Level >= 25)
		{
			this.usedsolt = 8;
		}
		else if (buildData.Level >= 17)
		{
			this.usedsolt = 7;
		}
		else
		{
			this.usedsolt = 6;
		}
		if (buildData.Level >= 17 && UILordEquipSetEdit.showingSet.SerialNO[6] == 0u)
		{
			this.AGS_Form.GetChild(5).GetChild(24).gameObject.SetActive(buildData.Level < 17);
			this.AGS_Form.GetChild(5).GetChild(14).GetChild(0).gameObject.SetActive(num2 == 1);
			this.AGS_Form.GetChild(5).GetChild(14).GetChild(1).gameObject.SetActive(num2 > 0);
			this.AGS_Form.GetChild(5).GetChild(14).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(2 - num2);
			this.AGS_Form.GetChild(5).GetChild(14).GetComponent<UIButton>().m_BtnID1 = 3;
		}
		else
		{
			this.AGS_Form.GetChild(5).GetChild(24).gameObject.SetActive(buildData.Level < 17);
			this.AGS_Form.GetChild(5).GetChild(14).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(5).GetChild(14).GetChild(1).gameObject.SetActive(false);
			this.AGS_Form.GetChild(5).GetChild(14).GetComponent<UIButton>().m_BtnID1 = 0;
		}
		if (buildData.Level >= 25 && UILordEquipSetEdit.showingSet.SerialNO[7] == 0u)
		{
			this.AGS_Form.GetChild(5).GetChild(25).gameObject.SetActive(buildData.Level < 25);
			this.AGS_Form.GetChild(5).GetChild(15).GetChild(0).gameObject.SetActive(num2 == 1);
			this.AGS_Form.GetChild(5).GetChild(15).GetChild(1).gameObject.SetActive(num2 > 0);
			this.AGS_Form.GetChild(5).GetChild(15).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(2 - num2);
			this.AGS_Form.GetChild(5).GetChild(15).GetComponent<UIButton>().m_BtnID1 = 3;
		}
		else
		{
			this.AGS_Form.GetChild(5).GetChild(25).gameObject.SetActive(buildData.Level < 25);
			this.AGS_Form.GetChild(5).GetChild(15).GetChild(0).gameObject.SetActive(false);
			this.AGS_Form.GetChild(5).GetChild(15).GetChild(1).gameObject.SetActive(false);
			this.AGS_Form.GetChild(5).GetChild(15).GetComponent<UIButton>().m_BtnID1 = 0;
		}
		this.SPHeight.Clear();
		CString cstring = StringManager.Instance.StaticString1024();
		for (int m = 0; m < this.effectCompareList.Count; m++)
		{
			if (this.effectCompareList[m].isTitel)
			{
				this.SPHeight.Add(35f);
			}
			else if (this.effectCompareList[m].isNewGemEffect == 1)
			{
				cstring.ClearString();
				LordEquipData.GetNewGemEffectString(cstring, (byte)this.effectCompareList[m].EffectID, this.effectCompareList[m].EffectValue, true, 0);
				this.SPHeight.Add(this.GetTextHeight(245f, cstring, 18));
			}
			else
			{
				this.SPHeight.Add(32f);
			}
		}
		if (this.SPHeight.Count > 1)
		{
			float num3 = this.SPHeight[this.SPHeight.Count - 1];
			this.SPHeight.RemoveAt(this.SPHeight.Count - 1);
			this.SPHeight.Add(num3 + 6f);
		}
		this.AGS_Form.GetChild(6).gameObject.SetActive(true);
		this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeight, true, true);
		if (!UILordEquipSetEdit.ThingsChanged)
		{
			for (int n = 0; n < UILordEquipSetEdit.showingSet.SerialNO.Length; n++)
			{
				if (UILordEquipSetEdit.showingSet.SerialNO[n] != LordEquipData.Instance().LordEquipSets[UILordEquipSetEdit.SetIdx].SerialNO[n])
				{
					UILordEquipSetEdit.ThingsChanged = true;
					break;
				}
			}
		}
		UIButton component3 = this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIButton>();
		component = component3.transform.GetChild(0).GetComponent<UIText>();
		if (UILordEquipSetEdit.ThingsChanged && !UILordEquipSetEdit.showingSet.isSetEmpty())
		{
			component3.image.color = Color.white;
			component3.m_BtnID1 = 1;
			component.color = Color.white;
		}
		else
		{
			component3.image.color = Color.gray;
			component3.m_BtnID1 = 0;
			component.color = new Color(0.898f, 0f, 0.31f);
		}
		component3 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIButton>();
		component = component3.transform.GetChild(0).GetComponent<UIText>();
		if (!UILordEquipSetEdit.showingSet.isSetEmpty())
		{
			component3.image.color = Color.white;
			component3.m_BtnID1 = 2;
			component.color = Color.white;
		}
		else
		{
			component3.image.color = Color.gray;
			component3.m_BtnID1 = 0;
			component.color = new Color(0.898f, 0f, 0.31f);
		}
	}

	// Token: 0x06001DFC RID: 7676 RVA: 0x003889A8 File Offset: 0x00386BA8
	public static int CheckHaveEquipKind(byte Kind, bool CheckRole)
	{
		bool flag = false;
		for (int i = 0; i < (int)DataManager.Instance.RoleAttr.LordEquipBagSize; i++)
		{
			if (LordEquipData.Instance().LordEquip[i].ItemID != 0)
			{
				Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(LordEquipData.Instance().LordEquip[i].ItemID);
				if (recordByKey.EquipKind == Kind)
				{
					if (!CheckRole || !UILordEquipSetEdit.showingSet.isInSet(LordEquipData.Instance().LordEquip[i].SerialNO))
					{
						flag = true;
						if (LordEquipData.Instance().LordEquip[i].SerialNO != DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO)
						{
							if (DataManager.Instance.RoleAttr.Level >= recordByKey.NeedLv)
							{
								return 1;
							}
						}
					}
				}
			}
		}
		return (!flag) ? 0 : 2;
	}

	// Token: 0x06001DFD RID: 7677 RVA: 0x00388AB8 File Offset: 0x00386CB8
	public void Update()
	{
		if (this.isLoading)
		{
			this.isLoading = false;
			this.AfterLoader();
		}
		if (this.openUseSpand)
		{
			this.openUseSpand = false;
			GUIManager.Instance.UseOrSpend(GameConstants.LESaveItemID, this.DM.mStringTable.GetStringByID(9703u), 0, (ushort)UILordEquipSetEdit.SetIdx, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
		}
		this.GetPointTime += Time.smoothDeltaTime;
		if (this.GetPointTime >= 2f)
		{
			this.GetPointTime = 0f;
		}
		float a = (this.GetPointTime <= 1f) ? this.GetPointTime : (2f - this.GetPointTime);
		Color color = new Color(1f, 1f, 1f, a);
		for (int i = 0; i < this.LEquipLight.Length; i++)
		{
			if (this.LEquipLight[i].gameObject.activeInHierarchy)
			{
				this.LEquipLight[i].color = color;
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
	}

	// Token: 0x06001DFE RID: 7678 RVA: 0x00388C60 File Offset: 0x00386E60
	private float GetTextHeight(float wide, CString str, int fontsize = 18)
	{
		this.BestHeight.gameObject.SetActive(true);
		this.BestHeight.fontSize = fontsize;
		this.BestHeight.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, wide);
		this.BestHeight.text = str.ToString();
		this.BestHeight.cachedTextGeneratorForLayout.Invalidate();
		this.BestHeight.gameObject.SetActive(false);
		return Mathf.Max(30f, this.BestHeight.preferredHeight);
	}

	// Token: 0x04005D6C RID: 23916
	private Transform AGS_Form;

	// Token: 0x04005D6D RID: 23917
	private UIText[] AllTextObject = new UIText[7];

	// Token: 0x04005D6E RID: 23918
	private ScrollPanel AGS_ScrollPanel;

	// Token: 0x04005D6F RID: 23919
	private UISpritesArray AGS_Forging;

	// Token: 0x04005D70 RID: 23920
	private Door door;

	// Token: 0x04005D71 RID: 23921
	private DataManager DM;

	// Token: 0x04005D72 RID: 23922
	private bool isLoading;

	// Token: 0x04005D73 RID: 23923
	private List<float> SPHeight;

	// Token: 0x04005D74 RID: 23924
	private RectTransform[] Equips;

	// Token: 0x04005D75 RID: 23925
	private List<LordEquipEffectCompareSet> effectCompareList;

	// Token: 0x04005D76 RID: 23926
	public static LordEquipSet showingSet;

	// Token: 0x04005D77 RID: 23927
	public static int[] SetDataIndex;

	// Token: 0x04005D78 RID: 23928
	public static int SetIdx;

	// Token: 0x04005D79 RID: 23929
	public static int ChangingIdx;

	// Token: 0x04005D7A RID: 23930
	public static CString SetName;

	// Token: 0x04005D7B RID: 23931
	public static bool ThingsChanged;

	// Token: 0x04005D7C RID: 23932
	private int usedsolt;

	// Token: 0x04005D7D RID: 23933
	private CString[] EffDescText = new CString[18];

	// Token: 0x04005D7E RID: 23934
	private CString HintStr;

	// Token: 0x04005D7F RID: 23935
	private float GetPointTime;

	// Token: 0x04005D80 RID: 23936
	private Image[] LEquipLight = new Image[8];

	// Token: 0x04005D81 RID: 23937
	private float AnimeTime;

	// Token: 0x04005D82 RID: 23938
	private UIText BestHeight;

	// Token: 0x04005D83 RID: 23939
	private bool openUseSpand;

	// Token: 0x04005D84 RID: 23940
	private RectTransform ForgingIcon;

	// Token: 0x020005F5 RID: 1525
	private enum e_AGS_UI_LordEquipSetEdit_Editor
	{
		// Token: 0x04005D86 RID: 23942
		BGFrame,
		// Token: 0x04005D87 RID: 23943
		exitImage,
		// Token: 0x04005D88 RID: 23944
		Renamebtn,
		// Token: 0x04005D89 RID: 23945
		Image,
		// Token: 0x04005D8A RID: 23946
		ItemCombinePanel,
		// Token: 0x04005D8B RID: 23947
		ItemLayer,
		// Token: 0x04005D8C RID: 23948
		ItemInfo,
		// Token: 0x04005D8D RID: 23949
		Forging
	}

	// Token: 0x020005F6 RID: 1526
	private enum e_AGS_BGFrame
	{
		// Token: 0x04005D8F RID: 23951
		BGHighLight,
		// Token: 0x04005D90 RID: 23952
		Title
	}

	// Token: 0x020005F7 RID: 1527
	private enum e_AGS_exitImage
	{
		// Token: 0x04005D92 RID: 23954
		exitUIButton
	}

	// Token: 0x020005F8 RID: 1528
	private enum e_AGS_ItemCombinePanel
	{
		// Token: 0x04005D94 RID: 23956
		ClearBtn,
		// Token: 0x04005D95 RID: 23957
		SaveBtn
	}

	// Token: 0x020005F9 RID: 1529
	private enum e_AGS_ClearBtn
	{
		// Token: 0x04005D97 RID: 23959
		Name
	}

	// Token: 0x020005FA RID: 1530
	private enum e_AGS_SaveBtn
	{
		// Token: 0x04005D99 RID: 23961
		Name
	}

	// Token: 0x020005FB RID: 1531
	private enum e_AGS_ItemLayer
	{
		// Token: 0x04005D9B RID: 23963
		Shadow1,
		// Token: 0x04005D9C RID: 23964
		Shadow2,
		// Token: 0x04005D9D RID: 23965
		Shadow3,
		// Token: 0x04005D9E RID: 23966
		Shadow4,
		// Token: 0x04005D9F RID: 23967
		Shadow5,
		// Token: 0x04005DA0 RID: 23968
		Shadow6,
		// Token: 0x04005DA1 RID: 23969
		Shadow7,
		// Token: 0x04005DA2 RID: 23970
		Shadow8,
		// Token: 0x04005DA3 RID: 23971
		Pos1,
		// Token: 0x04005DA4 RID: 23972
		Pos2,
		// Token: 0x04005DA5 RID: 23973
		Pos3,
		// Token: 0x04005DA6 RID: 23974
		Pos4,
		// Token: 0x04005DA7 RID: 23975
		Pos5,
		// Token: 0x04005DA8 RID: 23976
		Pos6,
		// Token: 0x04005DA9 RID: 23977
		Pos7,
		// Token: 0x04005DAA RID: 23978
		Pos8,
		// Token: 0x04005DAB RID: 23979
		UILEBtn1,
		// Token: 0x04005DAC RID: 23980
		UILEBtn2,
		// Token: 0x04005DAD RID: 23981
		UILEBtn3,
		// Token: 0x04005DAE RID: 23982
		UILEBtn4,
		// Token: 0x04005DAF RID: 23983
		UILEBtn5,
		// Token: 0x04005DB0 RID: 23984
		UILEBtn6,
		// Token: 0x04005DB1 RID: 23985
		UILEBtn7,
		// Token: 0x04005DB2 RID: 23986
		UILEBtn8,
		// Token: 0x04005DB3 RID: 23987
		Lock7,
		// Token: 0x04005DB4 RID: 23988
		Lock8
	}

	// Token: 0x020005FC RID: 1532
	private enum e_AGS_ItemInfo
	{
		// Token: 0x04005DB6 RID: 23990
		NameBg,
		// Token: 0x04005DB7 RID: 23991
		NameText,
		// Token: 0x04005DB8 RID: 23992
		ScrollPanel,
		// Token: 0x04005DB9 RID: 23993
		ScrollItem
	}

	// Token: 0x020005FD RID: 1533
	private enum e_AGS_ScrollItem
	{
		// Token: 0x04005DBB RID: 23995
		Text,
		// Token: 0x04005DBC RID: 23996
		Text2,
		// Token: 0x04005DBD RID: 23997
		Text3,
		// Token: 0x04005DBE RID: 23998
		Icon
	}
}
