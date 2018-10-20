using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004EE RID: 1262
public class UIBackReward_Detail : GUIWindow, UILoadImageHander, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUILEBtnClickHandler
{
	// Token: 0x170000B2 RID: 178
	// (get) Token: 0x06001935 RID: 6453 RVA: 0x002A7C94 File Offset: 0x002A5E94
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

	// Token: 0x06001936 RID: 6454 RVA: 0x002A7CC4 File Offset: 0x002A5EC4
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.MM = MallManager.Instance;
		this.m_transform = base.transform;
		this.tmpFont = this.GM.GetTTFFont();
		this.m_transform.GetChild(14).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_transform.GetChild(14).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 3;
		this.m_transform.GetChild(14).GetChild(0).GetComponent<CustomImage>().hander = this;
		this.m_transform.GetChild(14).GetComponent<CustomImage>().hander = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(14).GetComponent<CustomImage>().enabled = false;
		}
		Transform child = this.m_transform.GetChild(13);
		child.GetComponent<UIButton>().m_Handler = this;
		this.BuyText = child.GetChild(0).GetComponent<UIText>();
		this.BuyText.font = this.tmpFont;
		this.BuyText.text = this.DM.mStringTable.GetStringByID(10169u);
		this.PackageName = this.m_transform.GetChild(7).GetComponent<UIText>();
		this.PackageName.font = this.tmpFont;
		this.PackageName.text = this.DM.mStringTable.GetStringByID(10166u);
		this.GatAllText = this.m_transform.GetChild(10).GetComponent<UIText>();
		this.GatAllText.font = this.tmpFont;
		this.GatAllText.text = this.DM.mStringTable.GetStringByID(838u);
		this.OnceText = this.m_transform.GetChild(9).GetComponent<UIText>();
		this.OnceText.font = this.tmpFont;
		this.OnceText.text = this.DM.mStringTable.GetStringByID(10167u);
		Transform child2 = this.m_transform.GetChild(12);
		this.GM.InitianHeroItemImg(child2.GetChild(2), eHeroOrItem.Item, 1, 0, 0, 0, false, false, true, false);
		child2.GetChild(2).gameObject.AddComponent<IgnoreRaycast>();
		this.GM.InitLordEquipImg(child2.GetChild(3), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		child2.GetChild(3).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
		UIText component = child2.GetChild(4).GetComponent<UIText>();
		component.font = this.tmpFont;
		component = child2.GetChild(5).GetComponent<UIText>();
		component.font = this.tmpFont;
		child2.GetChild(6).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
		this.Scroll = this.m_transform.GetChild(11).GetComponent<ScrollPanel>();
		this.Scroll.IntiScrollPanel(358f, 0f, 0f, this.NowHeightList, 9, this);
		this.cScrollRect = this.Scroll.GetComponent<CScrollRect>();
		UIButtonHint.scrollRect = this.cScrollRect;
		this.UpDateList();
		this.GM.UpdateUI(EGUIWindow.Door, 1, 1);
	}

	// Token: 0x06001937 RID: 6455 RVA: 0x002A8008 File Offset: 0x002A6208
	public override void OnClose()
	{
		for (int i = 0; i < 9; i++)
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
	}

	// Token: 0x06001938 RID: 6456 RVA: 0x002A8068 File Offset: 0x002A6268
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			if (this.MM.BackRewardComboBoxID == 0 && this.door)
			{
				this.door.CloseMenu(false);
			}
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				for (int i = 0; i < 9; i++)
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
				if (this.BuyText != null && this.BuyText.enabled)
				{
					this.BuyText.enabled = false;
					this.BuyText.enabled = true;
				}
				if (this.GatAllText != null && this.GatAllText.enabled)
				{
					this.GatAllText.enabled = false;
					this.GatAllText.enabled = true;
				}
				if (this.OnceText != null && this.OnceText.enabled)
				{
					this.OnceText.enabled = false;
					this.OnceText.enabled = true;
				}
				if (this.PackageName != null && this.PackageName.enabled)
				{
					this.PackageName.enabled = false;
					this.PackageName.enabled = true;
				}
			}
			break;
		}
	}

	// Token: 0x06001939 RID: 6457 RVA: 0x002A82D0 File Offset: 0x002A64D0
	private void UpDateList()
	{
		this.tmpData = this.DM.ComboBoxTable.GetRecordByKey(this.MM.BackRewardComboBoxID);
		this.Point = 0u;
		this.MM.BackRewardItemDataCount = 0;
		for (int i = 0; i < this.tmpData.ItemData.Length; i++)
		{
			if (this.tmpData.ItemData[i].ItemID != 0)
			{
				Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.tmpData.ItemData[i].ItemID);
				if (recordByKey.EquipKind == 11 && recordByKey.PropertiesInfo[0].Propertieskey == 6)
				{
					this.Point += (uint)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue * this.tmpData.ItemData[i].ItemCount);
				}
				else if ((int)this.MM.BackRewardItemDataCount < this.MM.BackRewardItemData.Length)
				{
					this.MM.BackRewardItemData[(int)this.MM.BackRewardItemDataCount] = (byte)i;
					MallManager mm = this.MM;
					mm.BackRewardItemDataCount += 1;
				}
			}
		}
		this.AddCount = ((this.Point <= 0u) ? 0 : 1);
		this.ItemCount = 0;
		this.NowHeightList.Clear();
		if (this.Point > 0u)
		{
			this.NowHeightList.Add(55f);
			this.ItemCount += 1;
		}
		for (int j = 0; j < (int)this.MM.BackRewardItemDataCount; j++)
		{
			this.NowHeightList.Add(55f);
		}
		this.ItemCount += this.MM.BackRewardItemDataCount;
		this.Scroll.AddNewDataHeight(this.NowHeightList, true, true);
	}

	// Token: 0x0600193A RID: 6458 RVA: 0x002A84E4 File Offset: 0x002A66E4
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelObjectIdx < 9)
		{
			Vector2 anchoredPosition = Vector2.zero;
			if (!this.bFindScrollComp[panelObjectIdx])
			{
				this.bFindScrollComp[panelObjectIdx] = true;
				this.ScrollComp[panelObjectIdx].CrystalImg = item.transform.GetChild(1).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].HIBtn = item.transform.GetChild(2).GetComponent<UIHIBtn>();
				this.ScrollComp[panelObjectIdx].HIBtn.m_Handler = this;
				this.ScrollComp[panelObjectIdx].Hint = item.transform.GetChild(2).GetComponent<UIButtonHint>();
				this.ScrollComp[panelObjectIdx].LEBtn = item.transform.GetChild(3).GetComponent<UILEBtn>();
				this.ScrollComp[panelObjectIdx].LEBtn.m_Handler = this;
				this.ScrollComp[panelObjectIdx].ItemName = item.transform.GetChild(4).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].ItemCountRC = item.transform.GetChild(5).GetComponent<RectTransform>();
				this.ScrollComp[panelObjectIdx].ItemCountText = item.transform.GetChild(5).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].ItemCountOutline = item.transform.GetChild(5).GetComponent<Outline>();
				this.ScrollComp[panelObjectIdx].LineImage = item.transform.GetChild(0).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].Btn3 = item.transform.GetChild(6).GetComponent<UIButton>();
				this.ScrollComp[panelObjectIdx].Hint3 = item.transform.GetChild(6).GetComponent<UIButtonHint>();
				this.ScrollComp[panelObjectIdx].Hint3.m_Handler = this;
				this.ScrollComp[panelObjectIdx].Hint3.DelayTime = 0.2f;
				this.OriginImagePos = this.ScrollComp[panelObjectIdx].CrystalImg.rectTransform.anchoredPosition;
				this.OriginCountPos = this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition;
				this.CountStr[panelObjectIdx] = StringManager.Instance.SpawnString(30);
				this.NameStr[panelObjectIdx] = StringManager.Instance.SpawnString(150);
				if (this.GM.IsArabic)
				{
					this.ScrollComp[panelObjectIdx].ItemCountText.AdjuestUI();
				}
			}
			if (dataIdx < 0 || dataIdx > (int)this.ItemCount)
			{
				return;
			}
			ushort num = 1;
			byte b = 0;
			uint num2;
			if (this.Point > 0u && dataIdx == 0)
			{
				num2 = this.Point;
				this.ScrollComp[panelObjectIdx].DataIndex = -1;
				this.ScrollComp[panelObjectIdx].ItemName.text = string.Empty;
				this.ScrollComp[panelObjectIdx].CrystalImg.enabled = true;
				this.ScrollComp[panelObjectIdx].LEBtn.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].HIBtn.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].Btn3.gameObject.SetActive(false);
				this.ScrollComp[panelObjectIdx].CrystalImg.rectTransform.anchoredPosition = this.OriginImagePos + new Vector2(218f, 0f);
				this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleCenter;
				this.ScrollComp[panelObjectIdx].ItemCountText.color = this.ItemNameCrystalColor;
				anchoredPosition = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos + new Vector2(-15f, 0f));
				this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = anchoredPosition;
			}
			else
			{
				this.ScrollComp[panelObjectIdx].DataIndex = dataIdx - this.AddCount;
				int num3 = (int)this.MM.BackRewardItemData[dataIdx - this.AddCount];
				num = this.tmpData.ItemData[num3].ItemID;
				num2 = (uint)this.tmpData.ItemData[num3].ItemCount;
				b = this.tmpData.ItemData[num3].Rank;
				this.ScrollComp[panelObjectIdx].CrystalImg.enabled = false;
				this.ScrollComp[panelObjectIdx].CrystalImg.rectTransform.anchoredPosition = this.OriginImagePos;
				this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
				this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
				this.ScrollComp[panelObjectIdx].ItemCountText.color = this.ItemCountOriginColor;
				this.ScrollComp[panelObjectIdx].ItemCountOutline.effectColor = this.ItemCountOutLineOriginColor;
				anchoredPosition = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos);
				this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = anchoredPosition;
				this.ScrollComp[panelObjectIdx].ItemCountText.alignment = ((!this.GM.IsArabic) ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft);
				this.ScrollComp[panelObjectIdx].ItemName.color = this.ItemCountOriginColor;
			}
			if (dataIdx >= this.AddCount)
			{
				Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(num);
				byte equipKind = recordByKey.EquipKind;
				this.ScrollComp[panelObjectIdx].Hint3.Parm1 = num;
				this.ScrollComp[panelObjectIdx].Hint3.Parm2 = b;
				bool flag = this.GM.IsLeadItem(equipKind);
				if (flag)
				{
					GUIManager.Instance.ChangeLordEquipImg(this.ScrollComp[panelObjectIdx].LEBtn.transform, num, b, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				}
				else
				{
					GUIManager.Instance.ChangeHeroItemImg(this.ScrollComp[panelObjectIdx].HIBtn.transform, eHeroOrItem.Item, num, 0, 0, 0);
				}
				this.ScrollComp[panelObjectIdx].LEBtn.gameObject.SetActive(flag);
				this.ScrollComp[panelObjectIdx].HIBtn.gameObject.SetActive(!flag);
				if (flag || !this.MM.CheckCanOpenDetail(num))
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
				this.ScrollComp[panelObjectIdx].ItemName.color = this.MM.GetItemRankColor(b);
				this.ScrollComp[panelObjectIdx].ItemName.SetAllDirty();
				this.ScrollComp[panelObjectIdx].ItemName.cachedTextGenerator.Invalidate();
			}
			this.CountStr[panelObjectIdx].Length = 0;
			StringManager.IntToStr(this.CountStr[panelObjectIdx], (long)((ulong)num2), 1, true);
			this.ScrollComp[panelObjectIdx].ItemCountText.text = this.CountStr[panelObjectIdx].ToString();
			this.ScrollComp[panelObjectIdx].ItemCountText.SetAllDirty();
			this.ScrollComp[panelObjectIdx].ItemCountText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x0600193B RID: 6459 RVA: 0x002A8D34 File Offset: 0x002A6F34
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		int num = dataIndex - this.AddCount;
		if (num < 0 || num >= (int)this.MM.BackRewardItemDataCount)
		{
			return;
		}
		int num2 = (int)this.MM.BackRewardItemData[num];
		ushort itemID = this.tmpData.ItemData[num2].ItemID;
		if (this.MM.CheckCanOpenDetail(itemID) && this.MM.OpenDetail(itemID))
		{
			AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		}
	}

	// Token: 0x0600193C RID: 6460 RVA: 0x002A8DB8 File Offset: 0x002A6FB8
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			if (sender.m_BtnID2 == 1)
			{
				this.MM.Send_PUSHBACK_PRIZE();
			}
			if (sender.m_BtnID2 == 3 && this.door)
			{
				this.door.CloseMenu(false);
			}
		}
	}

	// Token: 0x0600193D RID: 6461 RVA: 0x002A8E10 File Offset: 0x002A7010
	public void OnHIButtonClick(UIHIBtn sender)
	{
		if (this.MM.OpenDetail(sender.HIID))
		{
			AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		}
	}

	// Token: 0x0600193E RID: 6462 RVA: 0x002A8E34 File Offset: 0x002A7034
	public void OnLEButtonClick(UILEBtn sender)
	{
	}

	// Token: 0x0600193F RID: 6463 RVA: 0x002A8E38 File Offset: 0x002A7038
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

	// Token: 0x06001940 RID: 6464 RVA: 0x002A8ED4 File Offset: 0x002A70D4
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

	// Token: 0x06001941 RID: 6465 RVA: 0x002A8F38 File Offset: 0x002A7138
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		if (this.door)
		{
			img.sprite = this.door.LoadSprite(ImageName);
			img.material = this.door.LoadMaterial();
		}
	}

	// Token: 0x04004AAA RID: 19114
	private const int UnitCount = 9;

	// Token: 0x04004AAB RID: 19115
	private Transform m_transform;

	// Token: 0x04004AAC RID: 19116
	private DataManager DM;

	// Token: 0x04004AAD RID: 19117
	private GUIManager GM;

	// Token: 0x04004AAE RID: 19118
	private MallManager MM;

	// Token: 0x04004AAF RID: 19119
	private Font tmpFont;

	// Token: 0x04004AB0 RID: 19120
	private Door m_door;

	// Token: 0x04004AB1 RID: 19121
	private ComboBox tmpData;

	// Token: 0x04004AB2 RID: 19122
	private UIText PackageName;

	// Token: 0x04004AB3 RID: 19123
	private CScrollRect cScrollRect;

	// Token: 0x04004AB4 RID: 19124
	private ScrollPanel Scroll;

	// Token: 0x04004AB5 RID: 19125
	private List<float> NowHeightList = new List<float>();

	// Token: 0x04004AB6 RID: 19126
	private byte ItemCount;

	// Token: 0x04004AB7 RID: 19127
	private uint Point;

	// Token: 0x04004AB8 RID: 19128
	private int AddCount;

	// Token: 0x04004AB9 RID: 19129
	private bool[] bFindScrollComp = new bool[9];

	// Token: 0x04004ABA RID: 19130
	private UnitComp_BackReward_Detail[] ScrollComp = new UnitComp_BackReward_Detail[9];

	// Token: 0x04004ABB RID: 19131
	private CString[] CountStr = new CString[9];

	// Token: 0x04004ABC RID: 19132
	private CString[] NameStr = new CString[9];

	// Token: 0x04004ABD RID: 19133
	private Color ItemNameCrystalColor = new Color(1f, 0.9333f, 0.6196f);

	// Token: 0x04004ABE RID: 19134
	private Color ItemCountOriginColor = new Color(1f, 1f, 1f);

	// Token: 0x04004ABF RID: 19135
	private Color ItemCountOutLineOriginColor = new Color(0.3725f, 0.0862f, 0f);

	// Token: 0x04004AC0 RID: 19136
	private Color ItemCountCrystalColor = new Color(0.2f, 0.921f, 0.404f);

	// Token: 0x04004AC1 RID: 19137
	private Color ItemCountCrystalOutLineColor = new Color(0.1882f, 0.0862f, 0.06274f);

	// Token: 0x04004AC2 RID: 19138
	private Vector2 OriginImagePos;

	// Token: 0x04004AC3 RID: 19139
	private Vector2 OriginCountPos;

	// Token: 0x04004AC4 RID: 19140
	private UIText BuyText;

	// Token: 0x04004AC5 RID: 19141
	private UIText GatAllText;

	// Token: 0x04004AC6 RID: 19142
	private UIText OnceText;
}
