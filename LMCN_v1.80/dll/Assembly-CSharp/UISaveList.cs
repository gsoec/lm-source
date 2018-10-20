using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200067E RID: 1662
public class UISaveList : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001FF1 RID: 8177 RVA: 0x003CD474 File Offset: 0x003CB674
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager instance = GUIManager.Instance;
		DataManager instance2 = DataManager.Instance;
		instance.UpdateUI(EGUIWindow.Door, 1, 2);
		Font ttffont = instance.GetTTFFont();
		this.Titles[0] = base.transform.GetChild(0).GetChild(2).GetComponent<UIText>();
		this.Titles[0].font = ttffont;
		this.Titles[1] = base.transform.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.Titles[1].font = ttffont;
		this.Titles[2] = base.transform.GetChild(3).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.Titles[2].font = ttffont;
		this.Titles[2].text = instance2.mStringTable.GetStringByID(3849u);
		this.ResearchRect = base.transform.GetChild(3).GetComponent<RectTransform>();
		Door door = instance.FindMenu(EGUIWindow.Door) as Door;
		Image component = base.transform.GetChild(4).GetComponent<Image>();
		component.sprite = door.LoadSprite("UI_main_close_base");
		component.material = door.LoadMaterial();
		component = base.transform.GetChild(4).GetChild(0).GetComponent<Image>();
		component.sprite = door.LoadSprite("UI_main_close");
		component.material = door.LoadMaterial();
		if (instance.bOpenOnIPhoneX)
		{
			base.transform.GetChild(4).GetComponent<Image>().enabled = false;
		}
		UIButton component2 = base.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
		component2.m_BtnID1 = 1;
		component2.m_Handler = this;
		component2 = base.transform.GetChild(3).GetChild(1).GetComponent<UIButton>();
		component2.m_BtnID1 = 0;
		component2.m_Handler = this;
		UIText component3 = base.transform.GetChild(2).GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = instance2.mStringTable.GetStringByID(924u);
		component3 = base.transform.GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
		component3.font = ttffont;
		component3.text = instance2.mStringTable.GetStringByID(925u);
		component3 = base.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
		component3.font = ttffont;
		this.NeedResearchStr = StringManager.Instance.SpawnString(50);
		this.SaveScrollPanel = base.transform.GetChild(1).GetComponent<ScrollPanel>();
		for (int i = 0; i < 7; i++)
		{
			this.ItemsHeight.Add(94f);
		}
		this.PanelItem = new UISaveList.ItemEdit[7];
		this.SaveScrollPanel.IntiScrollPanel(515f, 0f, 0f, this.ItemsHeight, 7, this);
		this.ScrollContentRect = this.SaveScrollPanel.transform.GetChild(1).GetComponent<RectTransform>();
		this.UpdateSaveList();
		this.SaveScrollPanel.gameObject.SetActive(true);
	}

	// Token: 0x06001FF2 RID: 8178 RVA: 0x003CD7A8 File Offset: 0x003CB9A8
	public void UpdateSaveList()
	{
		this.SlotNum = this.GetItemNum();
		this.ResearchIndex = (int)this.GetResearchIndex();
		this.ItemsHeight.Clear();
		for (int i = 0; i < (int)this.SlotNum; i++)
		{
			this.ItemsHeight.Add(94f);
		}
		this.SaveScrollPanel.AddNewDataHeight(this.ItemsHeight, true, true);
	}

	// Token: 0x06001FF3 RID: 8179 RVA: 0x003CD814 File Offset: 0x003CBA14
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			for (int i = 0; i < this.Titles.Length; i++)
			{
				this.Titles[i].enabled = false;
				this.Titles[i].enabled = true;
			}
			for (int j = 0; j < this.PanelItem.Length; j++)
			{
				this.PanelItem[j].TextRefresh();
			}
		}
	}

	// Token: 0x06001FF4 RID: 8180 RVA: 0x003CD898 File Offset: 0x003CBA98
	public override void UpdateTime(bool bOnSecond)
	{
	}

	// Token: 0x06001FF5 RID: 8181 RVA: 0x003CD89C File Offset: 0x003CBA9C
	public override void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.NeedResearchStr);
	}

	// Token: 0x06001FF6 RID: 8182 RVA: 0x003CD8B0 File Offset: 0x003CBAB0
	public virtual void OnButtonClick(UIButton sender)
	{
		UISaveList.ClickType btnID = (UISaveList.ClickType)sender.m_BtnID1;
		if (btnID != UISaveList.ClickType.GotoInstitute)
		{
			if (btnID == UISaveList.ClickType.Close)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				if (door != null)
				{
					door.CloseMenu(false);
				}
			}
		}
		else
		{
			GUIManager.Instance.OpenTechTree(this.GetResearchID(), true);
		}
	}

	// Token: 0x06001FF7 RID: 8183 RVA: 0x003CD918 File Offset: 0x003CBB18
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.PanelItem[panelObjectIdx].transform == null)
		{
			this.PanelItem[panelObjectIdx].Init(item.transform, this);
			return;
		}
		if (dataIdx == this.ResearchIndex)
		{
			DataManager instance = DataManager.Instance;
			this.PanelItem[panelObjectIdx].YesObj.SetActive(false);
			this.ResearchRect.gameObject.SetActive(true);
			this.ResearchRect.SetParent(this.PanelItem[panelObjectIdx].transform);
			this.ResearchRect.anchoredPosition = Vector2.zero;
			this.NeedResearchStr.ClearString();
			this.NeedResearchStr.StringToFormat(instance.mStringTable.GetStringByID((uint)instance.TechData.GetRecordByKey(this.GetResearchID()).TechName));
			this.NeedResearchStr.AppendFormat(instance.mStringTable.GetStringByID(3775u));
			this.Titles[1].text = this.NeedResearchStr.ToString();
			this.Titles[1].SetAllDirty();
			this.Titles[1].cachedTextGenerator.Invalidate();
		}
		else
		{
			this.SetItemData(ref this.PanelItem[panelObjectIdx], dataIdx);
		}
	}

	// Token: 0x06001FF8 RID: 8184 RVA: 0x003CDA68 File Offset: 0x003CBC68
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001FF9 RID: 8185 RVA: 0x003CDA6C File Offset: 0x003CBC6C
	public virtual void SetItemData(ref UISaveList.ItemEdit Data, int dataIdx)
	{
		if (!Data.YesObj.activeSelf)
		{
			Data.YesObj.SetActive(true);
			this.ResearchRect.SetParent(base.transform);
			this.ResearchRect.gameObject.SetActive(false);
		}
		Data.Applybtn.m_BtnID2 = dataIdx;
		Data.Setupbtn.m_BtnID2 = dataIdx;
	}

	// Token: 0x06001FFA RID: 8186 RVA: 0x003CDAD0 File Offset: 0x003CBCD0
	public virtual short GetResearchIndex()
	{
		return -1;
	}

	// Token: 0x06001FFB RID: 8187 RVA: 0x003CDAD4 File Offset: 0x003CBCD4
	public virtual byte GetItemNum()
	{
		return 0;
	}

	// Token: 0x06001FFC RID: 8188 RVA: 0x003CDAD8 File Offset: 0x003CBCD8
	public virtual ushort GetResearchID()
	{
		return 117;
	}

	// Token: 0x040064FF RID: 25855
	protected UIText[] Titles = new UIText[3];

	// Token: 0x04006500 RID: 25856
	private RectTransform ResearchRect;

	// Token: 0x04006501 RID: 25857
	protected ScrollPanel SaveScrollPanel;

	// Token: 0x04006502 RID: 25858
	protected RectTransform ScrollContentRect;

	// Token: 0x04006503 RID: 25859
	private List<float> ItemsHeight = new List<float>();

	// Token: 0x04006504 RID: 25860
	protected byte SlotNum;

	// Token: 0x04006505 RID: 25861
	protected int ResearchIndex = -1;

	// Token: 0x04006506 RID: 25862
	private UISaveList.ItemEdit[] PanelItem;

	// Token: 0x04006507 RID: 25863
	private CString NeedResearchStr;

	// Token: 0x0200067F RID: 1663
	protected enum UIControl
	{
		// Token: 0x04006509 RID: 25865
		Background,
		// Token: 0x0400650A RID: 25866
		Scroll,
		// Token: 0x0400650B RID: 25867
		Item,
		// Token: 0x0400650C RID: 25868
		Restrict,
		// Token: 0x0400650D RID: 25869
		Close
	}

	// Token: 0x02000680 RID: 1664
	protected enum ClickType
	{
		// Token: 0x0400650F RID: 25871
		GotoInstitute,
		// Token: 0x04006510 RID: 25872
		Close,
		// Token: 0x04006511 RID: 25873
		Apply,
		// Token: 0x04006512 RID: 25874
		Setup
	}

	// Token: 0x02000681 RID: 1665
	public struct ItemEdit
	{
		// Token: 0x06001FFD RID: 8189 RVA: 0x003CDADC File Offset: 0x003CBCDC
		public void Init(Transform transform, IUIButtonClickHandler handle)
		{
			this.transform = transform;
			this.TransObj = transform.gameObject;
			this.YesObj = transform.GetChild(0).gameObject;
			this.Applybtn = transform.GetChild(0).GetChild(1).GetComponent<UIButton>();
			this.Applybtn.m_Handler = handle;
			this.Applybtn.m_BtnID1 = 2;
			this.Setupbtn = transform.GetChild(0).GetChild(2).GetComponent<UIButton>();
			this.Setupbtn.m_Handler = handle;
			this.Setupbtn.m_BtnID1 = 3;
			this.Title = transform.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.ApplyText = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
			this.SetupText = transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
			this.ApplyImg = transform.GetChild(0).GetChild(1).GetComponent<Image>();
		}

		// Token: 0x06001FFE RID: 8190 RVA: 0x003CDBDC File Offset: 0x003CBDDC
		public void SetData(int Index)
		{
			DataManager instance = DataManager.Instance;
			this.Title.text = instance.SaveTalentData[Index].GetTagName().ToString();
			this.Title.SetAllDirty();
			this.Title.cachedTextGenerator.Invalidate();
			this.Applybtn.m_BtnID2 = Index;
			this.Setupbtn.m_BtnID2 = Index;
		}

		// Token: 0x06001FFF RID: 8191 RVA: 0x003CDC44 File Offset: 0x003CBE44
		public void SetaApplyEnable(bool Enable)
		{
			this.Applybtn.enabled = Enable;
			if (Enable)
			{
				this.ApplyImg.color = Color.white;
				this.ApplyText.color = Color.white;
			}
			else
			{
				this.ApplyImg.color = Color.gray;
				this.ApplyText.color = new Color(0.898f, 0f, 0.31f);
			}
		}

		// Token: 0x06002000 RID: 8192 RVA: 0x003CDCB8 File Offset: 0x003CBEB8
		public void TextRefresh()
		{
			if (this.Title == null)
			{
				return;
			}
			this.Title.enabled = false;
			this.Title.enabled = true;
			this.ApplyText.enabled = false;
			this.ApplyText.enabled = true;
			this.SetupText.enabled = false;
			this.SetupText.enabled = true;
		}

		// Token: 0x04006513 RID: 25875
		public Transform transform;

		// Token: 0x04006514 RID: 25876
		public GameObject YesObj;

		// Token: 0x04006515 RID: 25877
		public GameObject TransObj;

		// Token: 0x04006516 RID: 25878
		public UIText Title;

		// Token: 0x04006517 RID: 25879
		public UIText ApplyText;

		// Token: 0x04006518 RID: 25880
		public UIText SetupText;

		// Token: 0x04006519 RID: 25881
		public UIButton Applybtn;

		// Token: 0x0400651A RID: 25882
		public UIButton Setupbtn;

		// Token: 0x0400651B RID: 25883
		private Image ApplyImg;

		// Token: 0x02000682 RID: 1666
		public enum UIYesControl
		{
			// Token: 0x0400651D RID: 25885
			Title,
			// Token: 0x0400651E RID: 25886
			ApplyBtn,
			// Token: 0x0400651F RID: 25887
			SetupBtn
		}
	}
}
