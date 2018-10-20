using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000629 RID: 1577
public class UIMall_FG_Detail : GUIWindow, UILoadImageHander, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUILEBtnClickHandler
{
	// Token: 0x170000BA RID: 186
	// (get) Token: 0x06001E66 RID: 7782 RVA: 0x003A3E9C File Offset: 0x003A209C
	public Door door
	{
		get
		{
			if (this.m_door == null)
			{
				this.m_door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
			}
			return this.m_door;
		}
	}

	// Token: 0x06001E67 RID: 7783 RVA: 0x003A3ECC File Offset: 0x003A20CC
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.MM = MallManager.Instance;
		this.m_transform = base.transform;
		this.tmpFont = this.GM.GetTTFFont();
		this.m_transform.GetChild(10).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(10).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 3;
		this.m_transform.GetChild(10).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(10).GetComponent<CustomImage>().hander = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(10).GetComponent<CustomImage>().enabled = false;
		}
		this.PackageName = this.m_transform.GetChild(4).GetComponent<UIText>();
		this.PackageName.font = this.tmpFont;
		this.PackageName.text = this.DM.mStringTable.GetStringByID(17509u);
		this.GatAllText = this.m_transform.GetChild(7).GetComponent<UIText>();
		this.GatAllText.font = this.tmpFont;
		this.GatAllText.text = this.DM.mStringTable.GetStringByID(838u);
		this.TimeStr = StringManager.Instance.SpawnString(30);
		this.TimeText = this.m_transform.GetChild(6).GetComponent<UIText>();
		this.TimeText.font = this.tmpFont;
		Transform child = this.m_transform.GetChild(9);
		this.GM.InitianHeroItemImg(child.GetChild(2), eHeroOrItem.Item, 1, 0, 0, 0, false, false, true, false);
		child.GetChild(2).gameObject.AddComponent<IgnoreRaycast>();
		this.GM.InitLordEquipImg(child.GetChild(3), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		child.GetChild(3).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
		UIText component = child.GetChild(4).GetComponent<UIText>();
		component.font = this.tmpFont;
		component = child.GetChild(5).GetComponent<UIText>();
		component.font = this.tmpFont;
		child.GetChild(6).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
		this.Scroll = this.m_transform.GetChild(8).GetComponent<ScrollPanel>();
		this.Scroll.IntiScrollPanel(458f, 0f, 0f, this.NowHeightList, 11, this);
		this.cScrollRect = this.Scroll.GetComponent<CScrollRect>();
		UIButtonHint.scrollRect = this.cScrollRect;
		this.UpDateList();
		this.GM.UpdateUI(EGUIWindow.Door, 1, 1);
		if (this.MM.FullGift_Deadline == 0L)
		{
			this.bClose = true;
		}
		else if (this.MM.FullGift_TreasureItemCount == 0)
		{
			this.MM.Send_TREASUREBACK_PRIZEINFO();
		}
	}

	// Token: 0x06001E68 RID: 7784 RVA: 0x003A41D8 File Offset: 0x003A23D8
	public override void OnClose()
	{
		if (this.TimeStr != null)
		{
			StringManager.Instance.DeSpawnString(this.TimeStr);
		}
		for (int i = 0; i < 11; i++)
		{
			if (this.CountStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.CountStr[i]);
			}
			if (this.NameStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.NameStr[i]);
			}
		}
		StringManager.Instance.DeSpawnString(this.PriceStr);
	}

	// Token: 0x06001E69 RID: 7785 RVA: 0x003A4268 File Offset: 0x003A2468
	private void Update()
	{
		if (this.bClose)
		{
			this.bClose = false;
			if (this.door)
			{
				this.door.CloseMenu(false);
			}
			return;
		}
		if (this.TimeText != null)
		{
			this.ResourceRedTime += Time.deltaTime;
			if (this.ResourceRedTime >= 0.5f)
			{
				this.ResourceRedTime = 0f;
				this.bResourceRed = !this.bResourceRed;
				if (this.bResourceRed)
				{
					this.TimeText.color = Color.red;
				}
				else
				{
					this.TimeText.color = Color.white;
				}
			}
		}
	}

	// Token: 0x06001E6A RID: 7786 RVA: 0x003A4324 File Offset: 0x003A2524
	private void UpdateTime()
	{
		if (this.TimeText == null)
		{
			return;
		}
		this.TimeStr.Length = 0;
		uint sec = (this.MM.FullGift_Deadline > this.DM.ServerTime) ? ((uint)(this.MM.FullGift_Deadline - this.DM.ServerTime)) : 0u;
		GameConstants.GetTimeString(this.TimeStr, sec, false, false, true, false, true);
		this.TimeText.text = this.TimeStr.ToString();
		this.TimeText.SetAllDirty();
		this.TimeText.cachedTextGenerator.Invalidate();
	}

	// Token: 0x06001E6B RID: 7787 RVA: 0x003A43CC File Offset: 0x003A25CC
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				for (int i = 0; i < 11; i++)
				{
					if (this.bFindScrollComp[i])
					{
						if (this.ScrollComp[i].ItemName != null && this.ScrollComp[i].ItemName.enabled)
						{
							this.ScrollComp[i].ItemName.enabled = false;
							this.ScrollComp[i].ItemName.enabled = true;
						}
						if (this.ScrollComp[i].ItemCountText != null && this.ScrollComp[i].ItemCountText.enabled)
						{
							this.ScrollComp[i].ItemCountText.enabled = false;
							this.ScrollComp[i].ItemCountText.enabled = true;
						}
						if (this.ScrollComp[i].HIBtn != null)
						{
							this.ScrollComp[i].HIBtn.Refresh_FontTexture();
						}
					}
				}
				if (this.GatAllText != null && this.GatAllText.enabled)
				{
					this.GatAllText.enabled = false;
					this.GatAllText.enabled = true;
				}
				if (this.PackageName != null && this.PackageName.enabled)
				{
					this.PackageName.enabled = false;
					this.PackageName.enabled = true;
				}
				if (this.TimeText != null && this.TimeText.enabled)
				{
					this.TimeText.enabled = false;
					this.TimeText.enabled = true;
				}
			}
			break;
		}
	}

	// Token: 0x06001E6C RID: 7788 RVA: 0x003A45D0 File Offset: 0x003A27D0
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 0)
		{
			this.UpdateTime();
		}
		else if (arg1 == 1)
		{
			if (this.MM.FullGift_Deadline == 0L && this.door)
			{
				this.door.CloseMenu(false);
			}
		}
		else if (arg1 == 2)
		{
			if (this.door)
			{
				if (this.MM.FullGift_Deadline == 0L)
				{
					this.door.CloseMenu(false);
				}
				else
				{
					this.MM.Send_TREASUREBACK_PRIZEINFO();
				}
			}
		}
		else if (arg1 == 3)
		{
			this.UpDateList();
		}
	}

	// Token: 0x06001E6D RID: 7789 RVA: 0x003A467C File Offset: 0x003A287C
	private void UpDateList()
	{
		this.NowHeightList.Clear();
		for (int i = 0; i < (int)this.MM.FullGift_TreasureItemCount; i++)
		{
			if (this.MM.FullGift_TreasureItem[i].ItemID != 0)
			{
				this.NowHeightList.Add(55f);
			}
		}
		this.Scroll.AddNewDataHeight(this.NowHeightList, true, true);
		if (this.UIIndex != -1)
		{
			this.Scroll.GoTo(this.UIIndex, this.UIPos);
		}
		this.UpdateTime();
	}

	// Token: 0x06001E6E RID: 7790 RVA: 0x003A4718 File Offset: 0x003A2918
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelObjectIdx < 11)
		{
			Vector2 zero = Vector2.zero;
			if (!this.bFindScrollComp[panelObjectIdx])
			{
				this.bFindScrollComp[panelObjectIdx] = true;
				item.transform.GetChild(1).GetComponent<Image>().enabled = false;
				this.ScrollComp[panelObjectIdx].HIBtn = item.transform.GetChild(2).GetComponent<UIHIBtn>();
				this.ScrollComp[panelObjectIdx].HIBtn.m_Handler = this;
				this.ScrollComp[panelObjectIdx].Hint = item.transform.GetChild(2).GetComponent<UIButtonHint>();
				this.ScrollComp[panelObjectIdx].LEBtn = item.transform.GetChild(3).GetComponent<UILEBtn>();
				this.ScrollComp[panelObjectIdx].LEBtn.m_Handler = this;
				this.ScrollComp[panelObjectIdx].ItemName = item.transform.GetChild(4).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].ItemCountText = item.transform.GetChild(5).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].LineImage = item.transform.GetChild(0).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].Btn3 = item.transform.GetChild(6).GetComponent<UIButton>();
				this.ScrollComp[panelObjectIdx].Hint3 = item.transform.GetChild(6).GetComponent<UIButtonHint>();
				this.ScrollComp[panelObjectIdx].Hint3.m_Handler = this;
				this.ScrollComp[panelObjectIdx].Hint3.DelayTime = 0.2f;
				this.CountStr[panelObjectIdx] = StringManager.Instance.SpawnString(30);
				this.NameStr[panelObjectIdx] = StringManager.Instance.SpawnString(150);
				if (this.GM.IsArabic)
				{
					this.ScrollComp[panelObjectIdx].ItemCountText.AdjuestUI();
				}
			}
			if (dataIdx < 0 || dataIdx >= (int)this.MM.FullGift_TreasureItemCount)
			{
				return;
			}
			this.ScrollComp[panelObjectIdx].DataIndex = -1;
			ushort itemID = this.MM.FullGift_TreasureItem[dataIdx].ItemID;
			uint num = (uint)this.MM.FullGift_TreasureItem[dataIdx].Num;
			byte itemRank = this.MM.FullGift_TreasureItem[dataIdx].ItemRank;
			Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(itemID);
			byte equipKind = recordByKey.EquipKind;
			this.ScrollComp[panelObjectIdx].Hint3.Parm1 = itemID;
			this.ScrollComp[panelObjectIdx].Hint3.Parm2 = itemRank;
			bool flag = this.GM.IsLeadItem(equipKind);
			if (flag)
			{
				GUIManager.Instance.ChangeLordEquipImg(this.ScrollComp[panelObjectIdx].LEBtn.transform, itemID, itemRank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
			}
			else
			{
				GUIManager.Instance.ChangeHeroItemImg(this.ScrollComp[panelObjectIdx].HIBtn.transform, eHeroOrItem.Item, itemID, 0, 0, 0);
			}
			this.ScrollComp[panelObjectIdx].LEBtn.gameObject.SetActive(flag);
			this.ScrollComp[panelObjectIdx].HIBtn.gameObject.SetActive(!flag);
			if (flag || !this.MM.CheckCanOpenDetail(itemID))
			{
				this.ScrollComp[panelObjectIdx].Hint3.enabled = true;
			}
			else
			{
				this.ScrollComp[panelObjectIdx].Hint3.enabled = false;
			}
			this.ScrollComp[panelObjectIdx].Btn3.gameObject.SetActive(this.ScrollComp[panelObjectIdx].Hint3.enabled);
			this.NameStr[panelObjectIdx].Length = 0;
			this.NameStr[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)recordByKey.EquipName));
			this.NameStr[panelObjectIdx].AppendFormat("{0}");
			this.ScrollComp[panelObjectIdx].ItemName.text = this.NameStr[panelObjectIdx].ToString();
			this.ScrollComp[panelObjectIdx].ItemName.color = this.MM.GetItemRankColor(itemRank);
			this.ScrollComp[panelObjectIdx].ItemName.SetAllDirty();
			this.ScrollComp[panelObjectIdx].ItemName.cachedTextGenerator.Invalidate();
			this.CountStr[panelObjectIdx].Length = 0;
			StringManager.IntToStr(this.CountStr[panelObjectIdx], (long)((ulong)num), 1, true);
			this.ScrollComp[panelObjectIdx].ItemCountText.text = this.CountStr[panelObjectIdx].ToString();
			this.ScrollComp[panelObjectIdx].ItemCountText.SetAllDirty();
			this.ScrollComp[panelObjectIdx].ItemCountText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06001E6F RID: 7791 RVA: 0x003A4C34 File Offset: 0x003A2E34
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		if (dataIndex < 0 || dataIndex >= (int)this.MM.FullGift_TreasureItemCount)
		{
			return;
		}
		ushort itemID = this.MM.FullGift_TreasureItem[dataIndex].ItemID;
		if (this.MM.CheckCanOpenDetail(itemID) && this.MM.OpenDetail(itemID))
		{
			AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		}
	}

	// Token: 0x06001E70 RID: 7792 RVA: 0x003A4CA0 File Offset: 0x003A2EA0
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1 && sender.m_BtnID2 == 3 && this.door)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001E71 RID: 7793 RVA: 0x003A4CE4 File Offset: 0x003A2EE4
	public void OnHIButtonClick(UIHIBtn sender)
	{
		if (this.MM.OpenDetail(sender.HIID))
		{
			AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		}
	}

	// Token: 0x06001E72 RID: 7794 RVA: 0x003A4D08 File Offset: 0x003A2F08
	public void OnLEButtonClick(UILEBtn sender)
	{
	}

	// Token: 0x06001E73 RID: 7795 RVA: 0x003A4D0C File Offset: 0x003A2F0C
	public void OnButtonDown(UIButtonHint sender)
	{
		byte equipKind = DataManager.Instance.EquipTable.GetRecordByKey(sender.Parm1).EquipKind;
		bool flag = this.GM.IsLeadItem(equipKind);
		if (flag)
		{
			sender.SetFadeOutObject(EUIButtonHint.UILeBtn);
			this.GM.m_LordInfo.Show(sender, sender.Parm1, sender.Parm2, -1);
		}
		else
		{
			sender.SetFadeOutObject(EUIButtonHint.UIHIBtn);
			this.GM.m_SimpleItemInfo.Show(sender, sender.Parm1, -1, UIButtonHint.ePosition.Original, null);
		}
		AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
	}

	// Token: 0x06001E74 RID: 7796 RVA: 0x003A4DA8 File Offset: 0x003A2FA8
	public void OnButtonUp(UIButtonHint sender)
	{
		byte equipKind = DataManager.Instance.EquipTable.GetRecordByKey(sender.Parm1).EquipKind;
		bool flag = this.GM.IsLeadItem(equipKind);
		if (flag)
		{
			this.GM.m_LordInfo.Hide(sender);
		}
		else
		{
			GUIManager.Instance.m_SimpleItemInfo.Hide(sender);
		}
	}

	// Token: 0x06001E75 RID: 7797 RVA: 0x003A4E0C File Offset: 0x003A300C
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		if (this.door)
		{
			img.sprite = this.door.LoadSprite(ImageName);
			img.material = this.door.LoadMaterial();
		}
	}

	// Token: 0x06001E76 RID: 7798 RVA: 0x003A4E4C File Offset: 0x003A304C
	private void SavePos()
	{
		this.UIIndex = this.Scroll.GetTopIdx();
		this.UIPos = this.cScrollRect.content.anchoredPosition.y;
	}

	// Token: 0x0400603D RID: 24637
	private const int UnitCount = 11;

	// Token: 0x0400603E RID: 24638
	private Transform m_transform;

	// Token: 0x0400603F RID: 24639
	private DataManager DM;

	// Token: 0x04006040 RID: 24640
	private GUIManager GM;

	// Token: 0x04006041 RID: 24641
	private MallManager MM;

	// Token: 0x04006042 RID: 24642
	private Font tmpFont;

	// Token: 0x04006043 RID: 24643
	private Door m_door;

	// Token: 0x04006044 RID: 24644
	private CString TimeStr;

	// Token: 0x04006045 RID: 24645
	private UIText TimeText;

	// Token: 0x04006046 RID: 24646
	private Image Back;

	// Token: 0x04006047 RID: 24647
	private UIText PackageName;

	// Token: 0x04006048 RID: 24648
	private CScrollRect cScrollRect;

	// Token: 0x04006049 RID: 24649
	private ScrollPanel Scroll;

	// Token: 0x0400604A RID: 24650
	private List<float> NowHeightList = new List<float>();

	// Token: 0x0400604B RID: 24651
	private bool[] bFindScrollComp = new bool[11];

	// Token: 0x0400604C RID: 24652
	private UnitComp_Mall_FG_Detail[] ScrollComp = new UnitComp_Mall_FG_Detail[11];

	// Token: 0x0400604D RID: 24653
	private CString[] CountStr = new CString[11];

	// Token: 0x0400604E RID: 24654
	private CString[] NameStr = new CString[11];

	// Token: 0x0400604F RID: 24655
	private CString PriceStr;

	// Token: 0x04006050 RID: 24656
	private int UIIndex = -1;

	// Token: 0x04006051 RID: 24657
	private float UIPos;

	// Token: 0x04006052 RID: 24658
	private UIText GatAllText;

	// Token: 0x04006053 RID: 24659
	private bool bResourceRed;

	// Token: 0x04006054 RID: 24660
	private float ResourceRedTime;

	// Token: 0x04006055 RID: 24661
	private bool bClose;
}
