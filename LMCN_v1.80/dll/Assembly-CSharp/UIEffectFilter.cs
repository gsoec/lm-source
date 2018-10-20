using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000541 RID: 1345
public class UIEffectFilter : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001AC6 RID: 6854 RVA: 0x002D7A34 File Offset: 0x002D5C34
	private void Update()
	{
	}

	// Token: 0x06001AC7 RID: 6855 RVA: 0x002D7A38 File Offset: 0x002D5C38
	public override void OnOpen(int arg1, int arg2)
	{
		this.OpenKind = (eUI_EffectFilter_OpenKind)arg1;
		this.SPHeight = new List<float>();
		this.Selected = (ushort)arg2;
		UIEffectFilter.SeletedFilter = this.Selected;
		this.door = (Door)GUIManager.Instance.FindMenu(EGUIWindow.Door);
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.AGS_Form = base.transform;
		this.AGS_ScrollPanel = this.AGS_Form.GetChild(2).GetComponent<ScrollPanel>();
		UIText component = this.AGS_Form.GetChild(3).GetChild(1).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component2 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<RectTransform>();
			component2.localScale = new Vector3(-1f, 1f, 1f);
			component2.anchoredPosition = new Vector2(component2.anchoredPosition.x + 47f, component2.anchoredPosition.y);
		}
		UIButton component3 = this.AGS_Form.GetChild(5).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_EffectType = e_EffectType.e_Scale;
		component = this.AGS_Form.GetChild(5).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = DataManager.Instance.mStringTable.GetStringByID(5026u);
		component3 = this.AGS_Form.GetChild(6).GetChild(0).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_EffectType = e_EffectType.e_Scale;
		Image component4 = this.AGS_Form.GetChild(6).GetComponent<Image>();
		component4.sprite = this.door.LoadSprite("UI_main_close_base");
		component4.material = this.door.LoadMaterial();
		component4.enabled = !GUIManager.Instance.bOpenOnIPhoneX;
		component4 = this.AGS_Form.GetChild(6).GetChild(0).GetComponent<Image>();
		component4.sprite = this.door.LoadSprite("UI_main_close");
		component4.material = this.door.LoadMaterial();
		eUI_EffectFilter_OpenKind openKind = this.OpenKind;
		if (openKind != eUI_EffectFilter_OpenKind.ItemTypeFilter)
		{
			if (openKind == eUI_EffectFilter_OpenKind.EffectTypeFilter)
			{
				this.SPHeight.Add(66f);
				component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
				component.font = ttffont;
				component.text = DataManager.Instance.mStringTable.GetStringByID(7411u);
				for (int i = 0; i < DataManager.Instance.LordEquipEffectFilter.TableCount; i++)
				{
					this.SPHeight.Add(66f);
				}
			}
		}
		else
		{
			component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
			component.font = ttffont;
			component.text = DataManager.Instance.mStringTable.GetStringByID(7460u);
			this.SPHeight.Add(66f);
			for (int j = 0; j < 6; j++)
			{
				this.SPHeight.Add(66f);
			}
		}
		this.AGS_ScrollPanel.IntiScrollPanel(424f, 0f, 0f, this.SPHeight, 9, this);
		this.AGS_ScrollPanel.GoTo((int)this.Selected);
	}

	// Token: 0x06001AC8 RID: 6856 RVA: 0x002D7DA0 File Offset: 0x002D5FA0
	public override void OnClose()
	{
		if (this.SetEffect)
		{
			UIEffectFilter.SeletedFilter = this.Selected;
			if (this.OpenKind == eUI_EffectFilter_OpenKind.EffectTypeFilter)
			{
				DataManager.Instance.mLordEquip.ForgeItem_mSeletedFilter = UIEffectFilter.SeletedFilter;
			}
		}
		else
		{
			UIEffectFilter.SeletedFilter = 0;
		}
	}

	// Token: 0x06001AC9 RID: 6857 RVA: 0x002D7DF0 File Offset: 0x002D5FF0
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if ((int)this.Selected == dataIdx)
		{
			item.transform.GetChild(3).gameObject.SetActive(true);
			item.transform.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(1);
		}
		else
		{
			item.transform.GetChild(3).gameObject.SetActive(false);
			item.transform.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(0);
		}
		UIButton component = item.transform.GetChild(0).GetComponent<UIButton>();
		component.m_BtnID1 = 1;
		component.m_BtnID2 = dataIdx;
		component.m_Handler = this;
		if (dataIdx == 0)
		{
			UIText component2 = item.transform.GetChild(1).GetComponent<UIText>();
			component2.text = DataManager.Instance.mStringTable.GetStringByID(7412u);
			return;
		}
		eUI_EffectFilter_OpenKind openKind = this.OpenKind;
		if (openKind != eUI_EffectFilter_OpenKind.ItemTypeFilter)
		{
			if (openKind == eUI_EffectFilter_OpenKind.EffectTypeFilter)
			{
				this.UpdateRowEffectType(item, dataIdx, panelObjectIdx);
			}
		}
		else
		{
			this.UpdateRowItemType(item, dataIdx, panelObjectIdx);
		}
	}

	// Token: 0x06001ACA RID: 6858 RVA: 0x002D7EFC File Offset: 0x002D60FC
	private void UpdateRowEffectType(GameObject item, int dataIdx, int panelObjectIdx)
	{
		UIText component = item.transform.GetChild(1).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID((uint)DataManager.Instance.EffectData.GetRecordByKey(DataManager.Instance.LordEquipEffectFilter.GetRecordByIndex((int)((ushort)(dataIdx - 1))).effectID).InfoID);
	}

	// Token: 0x06001ACB RID: 6859 RVA: 0x002D7F64 File Offset: 0x002D6164
	private void UpdateRowItemType(GameObject item, int dataIdx, int panelObjectIdx)
	{
		UIText component = item.transform.GetChild(1).GetComponent<UIText>();
		component.text = DataManager.Instance.mStringTable.GetStringByID((uint)((ushort)(7430 + dataIdx)));
	}

	// Token: 0x06001ACC RID: 6860 RVA: 0x002D7FA0 File Offset: 0x002D61A0
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001ACD RID: 6861 RVA: 0x002D7FA4 File Offset: 0x002D61A4
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x06001ACE RID: 6862 RVA: 0x002D7FD0 File Offset: 0x002D61D0
	public void Refresh_FontTexture()
	{
		UIText component = this.AGS_Form.GetChild(5).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		if (this.AGS_ScrollPanel != null)
		{
			this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeight, false, true);
		}
	}

	// Token: 0x06001ACF RID: 6863 RVA: 0x002D807C File Offset: 0x002D627C
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		if (btnID != 0)
		{
			if (btnID == 1)
			{
				this.Selected = (ushort)sender.m_BtnID2;
				this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeight, false, true);
			}
		}
		else
		{
			int btnID2 = sender.m_BtnID2;
			if (btnID2 != 0)
			{
				if (btnID2 == 1)
				{
					this.SetEffect = true;
					this.door.CloseMenu(false);
				}
			}
			else
			{
				this.door.CloseMenu(false);
			}
		}
	}

	// Token: 0x04004F53 RID: 20307
	private const float SPUnitHeight = 66f;

	// Token: 0x04004F54 RID: 20308
	private Transform AGS_Form;

	// Token: 0x04004F55 RID: 20309
	private ScrollPanel AGS_ScrollPanel;

	// Token: 0x04004F56 RID: 20310
	private eUI_EffectFilter_OpenKind OpenKind;

	// Token: 0x04004F57 RID: 20311
	public static ushort SeletedFilter;

	// Token: 0x04004F58 RID: 20312
	private List<float> SPHeight;

	// Token: 0x04004F59 RID: 20313
	private ushort Selected;

	// Token: 0x04004F5A RID: 20314
	private Door door;

	// Token: 0x04004F5B RID: 20315
	private bool SetEffect;

	// Token: 0x02000542 RID: 1346
	private enum e_AGS_UI_EffectFilter_Editor
	{
		// Token: 0x04004F5D RID: 20317
		BGFrame,
		// Token: 0x04004F5E RID: 20318
		BGFrameTitle,
		// Token: 0x04004F5F RID: 20319
		ScrollPanel,
		// Token: 0x04004F60 RID: 20320
		ScrollPanelItem,
		// Token: 0x04004F61 RID: 20321
		Image,
		// Token: 0x04004F62 RID: 20322
		Okbtn,
		// Token: 0x04004F63 RID: 20323
		exitImage,
		// Token: 0x04004F64 RID: 20324
		BGFrameRight = 11
	}

	// Token: 0x02000543 RID: 1347
	private enum e_AGS_ScrollPanelItem
	{
		// Token: 0x04004F66 RID: 20326
		UIButton,
		// Token: 0x04004F67 RID: 20327
		Text,
		// Token: 0x04004F68 RID: 20328
		CheckBg,
		// Token: 0x04004F69 RID: 20329
		Check
	}
}
