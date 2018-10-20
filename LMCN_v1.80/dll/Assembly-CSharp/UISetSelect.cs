using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000658 RID: 1624
public class UISetSelect : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001F6D RID: 8045 RVA: 0x003C0F1C File Offset: 0x003BF11C
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
		UIText component = this.AGS_Form.GetChild(0).GetChild(2).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(8600u);
		this.AGS_ScrollPanel = this.AGS_Form.GetChild(1).GetComponent<ScrollPanel>();
		component = this.AGS_Form.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = string.Empty;
		UIButton component2 = this.AGS_Form.GetChild(2).GetChild(0).GetChild(1).GetComponent<UIButton>();
		component2.m_Handler = this;
		component = this.AGS_Form.GetChild(2).GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(924u);
		component2 = this.AGS_Form.GetChild(2).GetChild(0).GetChild(2).GetComponent<UIButton>();
		component2.m_Handler = this;
		component = this.AGS_Form.GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(925u);
		this.CloseText = StringManager.Instance.SpawnString(150);
		this.CloseText.StringToFormat(this.DM.mStringTable.GetStringByID(8600u));
		this.CloseText.AppendFormat(this.DM.mStringTable.GetStringByID(3775u));
		component = this.AGS_Form.GetChild(3).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.CloseText.ToString();
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		component2 = this.AGS_Form.GetChild(3).GetChild(1).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 3;
		component = this.AGS_Form.GetChild(3).GetChild(1).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = this.DM.mStringTable.GetStringByID(3776u);
		component2 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 99;
		Image component3 = this.AGS_Form.GetChild(4).GetComponent<Image>();
		component3.sprite = this.door.LoadSprite("UI_main_close_base");
		component3.material = this.door.LoadMaterial();
		component3.enabled = !GUIManager.Instance.bOpenOnIPhoneX;
		component3 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<Image>();
		component3.sprite = this.door.LoadSprite("UI_main_close");
		component3.material = this.door.LoadMaterial();
		this.NO = this.AGS_Form.GetChild(3).GetComponent<RectTransform>();
		this.isLoading = true;
	}

	// Token: 0x06001F6E RID: 8046 RVA: 0x003C12B0 File Offset: 0x003BF4B0
	public override void OnClose()
	{
		UISetSelect.memPos = this.AGS_ScrollPanel.GetContentPos();
		for (int i = 0; i < this.SetNames.Length; i++)
		{
			StringManager.Instance.DeSpawnString(this.SetNames[i]);
		}
		StringManager.Instance.DeSpawnString(this.CloseText);
	}

	// Token: 0x06001F6F RID: 8047 RVA: 0x003C130C File Offset: 0x003BF50C
	public void Update()
	{
		if (this.isLoading)
		{
			this.isLoading = false;
			this.AfterLoader();
		}
	}

	// Token: 0x06001F70 RID: 8048 RVA: 0x003C1328 File Offset: 0x003BF528
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Technology)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else
			{
				this.reFlashScrollPanel();
			}
		}
		else
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001F71 RID: 8049 RVA: 0x003C137C File Offset: 0x003BF57C
	private void AfterLoader()
	{
		if (this.Equips == null)
		{
			this.Equips = new RectTransform[8];
		}
		LordEquipData.Instance().CheckQuickSets();
		for (int i = 0; i < this.SetNames.Length; i++)
		{
			this.SetNames[i] = StringManager.Instance.SpawnString(100);
		}
		this.SPHeight.Clear();
		this.AGS_ScrollPanel.IntiScrollPanel(445f, 0f, 0f, this.SPHeight, 8, this);
		this.reFlashScrollPanel();
		this.AGS_ScrollPanel.GoTo(0, UISetSelect.memPos);
		this.AGS_ScrollPanel.gameObject.SetActive(true);
		this.isLoading = false;
	}

	// Token: 0x06001F72 RID: 8050 RVA: 0x003C1434 File Offset: 0x003BF634
	private void reFlashScrollPanel()
	{
		this.SPHeight.Clear();
		TechDataTbl recordByKey = this.DM.TechData.GetRecordByKey(116);
		LordEquipData.Instance().LordEquipSetsCount = (int)DataManager.Instance.GetTechLevel(116);
		for (int i = 0; i < LordEquipData.Instance().LordEquipSetsCount; i++)
		{
			if (LordEquipData.Instance().LordEquipSets[i] == null)
			{
				LordEquipData.Instance().LordEquipSets[i] = new LordEquipSet();
				LordEquipData.Instance().LordEquipSets[i].Name = StringManager.Instance.SpawnString(30);
			}
			this.SPHeight.Add(94f);
		}
		if (LordEquipData.Instance().LordEquipSetsCount < (int)recordByKey.LevelMax)
		{
			this.SPHeight.Add(94f);
		}
		this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeight, false, true);
	}

	// Token: 0x06001F73 RID: 8051 RVA: 0x003C1518 File Offset: 0x003BF718
	public void OnButtonClick(UIButton sender)
	{
		int btnID = sender.m_BtnID1;
		switch (btnID)
		{
		case 1:
		{
			if (this.DM.RoleAttr.LordEquipEventData.SerialNO != 0u)
			{
				for (int i = 0; i < 8; i++)
				{
					if (LordEquipData.Instance().LordEquipSets[sender.m_BtnID2].SerialNO[i] == this.DM.RoleAttr.LordEquipEventData.SerialNO)
					{
						GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(5893u), this.DM.mStringTable.GetStringByID(9708u), sender.m_BtnID2, 0, null, null);
						return;
					}
				}
			}
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_LORDEQUIP_CHANGE;
			messagePacket.AddSeqId();
			messagePacket.Add((byte)sender.m_BtnID2);
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.LordInfo);
			break;
		}
		case 2:
			UILordEquipSetEdit.loadSet(sender.m_BtnID2);
			this.door.OpenMenu(EGUIWindow.UI_LordEquipSetEdit, 0, 0, false);
			break;
		case 3:
			GUIManager.Instance.OpenTechTree(116, true);
			break;
		default:
			if (btnID == 99)
			{
				this.door.CloseMenu(false);
			}
			break;
		}
	}

	// Token: 0x06001F74 RID: 8052 RVA: 0x003C1674 File Offset: 0x003BF874
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_LORDEQUIP_CHANGE;
			messagePacket.AddSeqId();
			messagePacket.Add((byte)arg1);
			messagePacket.Send(false);
			GUIManager.Instance.ShowUILock(EUILock.LordInfo);
		}
	}

	// Token: 0x06001F75 RID: 8053 RVA: 0x003C16C0 File Offset: 0x003BF8C0
	public void ButtonOnClick(GameObject sender, int parm1, int parm2)
	{
	}

	// Token: 0x06001F76 RID: 8054 RVA: 0x003C16C4 File Offset: 0x003BF8C4
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (dataIdx >= LordEquipData.Instance().LordEquipSetsCount)
		{
			this.NO.SetParent(item.transform);
			this.NO.anchoredPosition = Vector2.zero;
			this.NO.gameObject.SetActive(true);
			item.transform.GetChild(0).gameObject.SetActive(false);
			this.NOonIdx = panelObjectIdx;
			return;
		}
		if (this.NOonIdx == panelObjectIdx)
		{
			this.NO.gameObject.SetActive(false);
			item.transform.GetChild(0).gameObject.SetActive(true);
		}
		if (LordEquipData.Instance().LordEquipSets[dataIdx] == null)
		{
			LordEquipData.Instance().LordEquipSets[dataIdx] = new LordEquipSet();
			LordEquipData.Instance().LordEquipSets[dataIdx].Name = StringManager.Instance.SpawnString(30);
		}
		UIText component = item.transform.GetChild(0).GetChild(0).GetComponent<UIText>();
		component.SetCheckArabic(true);
		if (LordEquipData.Instance().LordEquipSets[dataIdx].Name.Length > 0)
		{
			component.text = LordEquipData.Instance().LordEquipSets[dataIdx].Name.ToString();
		}
		else
		{
			this.SetNames[panelObjectIdx].ClearString();
			this.SetNames[panelObjectIdx].IntToFormat((long)(dataIdx + 1), 1, false);
			this.SetNames[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(928u));
			component.text = this.SetNames[panelObjectIdx].ToString();
		}
		component.SetAllDirty();
		component.cachedTextGenerator.Invalidate();
		UIButton component2 = item.transform.GetChild(0).GetChild(1).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID2 = dataIdx;
		component = component2.transform.GetChild(0).GetComponent<UIText>();
		if (LordEquipData.Instance().LordEquipSets[dataIdx].isSetEmpty())
		{
			component2.m_BtnID1 = 0;
			component2.image.color = Color.gray;
			component.color = new Color(0.898f, 0f, 0.31f);
		}
		else
		{
			component2.m_BtnID1 = 1;
			component2.image.color = Color.white;
			component.color = Color.white;
		}
		component = item.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		component.text = this.DM.mStringTable.GetStringByID(924u);
		component2 = item.transform.GetChild(0).GetChild(2).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 2;
		component2.m_BtnID2 = dataIdx;
		component = item.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
		component.text = this.DM.mStringTable.GetStringByID(925u);
	}

	// Token: 0x06001F77 RID: 8055 RVA: 0x003C19B0 File Offset: 0x003BFBB0
	public void Refresh_FontTexture()
	{
		UIText component = this.AGS_Form.GetChild(0).GetChild(2).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		if (this.AGS_ScrollPanel != null && this.AGS_ScrollPanel.gameObject.activeInHierarchy)
		{
			Transform child = this.AGS_ScrollPanel.transform.GetChild(1);
			for (int i = 0; i < child.childCount; i++)
			{
				Transform child2 = child.GetChild(i);
				if (child2.gameObject.activeInHierarchy)
				{
					component = child2.GetChild(0).GetChild(0).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child2.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
					component = child2.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
					if (component != null && component.enabled)
					{
						component.enabled = false;
						component.enabled = true;
					}
				}
			}
		}
		component = this.NO.GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
		component = this.NO.GetChild(1).GetChild(0).GetComponent<UIText>();
		if (component != null && component.enabled)
		{
			component.enabled = false;
			component.enabled = true;
		}
	}

	// Token: 0x0400635D RID: 25437
	private Transform AGS_Form;

	// Token: 0x0400635E RID: 25438
	private ScrollPanel AGS_ScrollPanel;

	// Token: 0x0400635F RID: 25439
	private Door door;

	// Token: 0x04006360 RID: 25440
	private DataManager DM;

	// Token: 0x04006361 RID: 25441
	private bool isLoading;

	// Token: 0x04006362 RID: 25442
	private List<float> SPHeight;

	// Token: 0x04006363 RID: 25443
	private RectTransform[] Equips;

	// Token: 0x04006364 RID: 25444
	private CString[] SetNames = new CString[8];

	// Token: 0x04006365 RID: 25445
	private CString CloseText;

	// Token: 0x04006366 RID: 25446
	private RectTransform NO;

	// Token: 0x04006367 RID: 25447
	private int NOonIdx;

	// Token: 0x04006368 RID: 25448
	public static float memPos;

	// Token: 0x02000659 RID: 1625
	private enum e_AGS_UITalentSave_Editor
	{
		// Token: 0x0400636A RID: 25450
		Background,
		// Token: 0x0400636B RID: 25451
		Scroll,
		// Token: 0x0400636C RID: 25452
		Item,
		// Token: 0x0400636D RID: 25453
		No,
		// Token: 0x0400636E RID: 25454
		Close
	}

	// Token: 0x0200065A RID: 1626
	private enum e_AGS_Background
	{
		// Token: 0x04006370 RID: 25456
		Image,
		// Token: 0x04006371 RID: 25457
		Image2,
		// Token: 0x04006372 RID: 25458
		Text
	}

	// Token: 0x0200065B RID: 1627
	private enum e_AGS_Scroll
	{
		// Token: 0x04006374 RID: 25460
		Image
	}

	// Token: 0x0200065C RID: 1628
	private enum e_AGS_Item
	{
		// Token: 0x04006376 RID: 25462
		Yes
	}

	// Token: 0x0200065D RID: 1629
	private enum e_AGS_Yes
	{
		// Token: 0x04006378 RID: 25464
		Text,
		// Token: 0x04006379 RID: 25465
		ApplyBtn,
		// Token: 0x0400637A RID: 25466
		SetupBtn
	}

	// Token: 0x0200065E RID: 1630
	private enum e_AGS_ApplyBtn
	{
		// Token: 0x0400637C RID: 25468
		Text
	}

	// Token: 0x0200065F RID: 1631
	private enum e_AGS_SetupBtn
	{
		// Token: 0x0400637E RID: 25470
		Text
	}

	// Token: 0x02000660 RID: 1632
	private enum e_AGS_No
	{
		// Token: 0x04006380 RID: 25472
		Text,
		// Token: 0x04006381 RID: 25473
		UIButton,
		// Token: 0x04006382 RID: 25474
		Image
	}

	// Token: 0x02000661 RID: 1633
	private enum e_AGS_UIButton
	{
		// Token: 0x04006384 RID: 25476
		Text
	}

	// Token: 0x02000662 RID: 1634
	private enum e_AGS_Close
	{
		// Token: 0x04006386 RID: 25478
		CloseBtn
	}
}
