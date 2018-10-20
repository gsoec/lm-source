using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x020004EB RID: 1259
public class UIBackReward : GUIWindow, UILoadImageHander, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x170000B1 RID: 177
	// (get) Token: 0x06001928 RID: 6440 RVA: 0x002A6BE4 File Offset: 0x002A4DE4
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

	// Token: 0x06001929 RID: 6441 RVA: 0x002A6C14 File Offset: 0x002A4E14
	public override void OnOpen(int arg1, int arg2)
	{
		GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Mall);
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.MM = MallManager.Instance;
		this.SM = StringManager.Instance;
		this.m_transform = base.transform;
		this.tmpFont = this.GM.GetTTFFont();
		this.UnitObjectT = this.m_transform.GetChild(2);
		Transform child = this.UnitObjectT.GetChild(1);
		Transform child2 = child.GetChild(5);
		if (this.GM.IsArabic)
		{
			child.GetComponent<RectTransform>().anchoredPosition = new Vector2(-130f, 0f);
		}
		this.BackImage1 = this.UnitObjectT.GetChild(0).GetComponent<Image>();
		if (this.GM.IsArabic)
		{
			this.BackImage1.rectTransform.localScale = new Vector3(-1f, 1f, 1f);
		}
		this.TitleText = child.GetChild(0).GetComponent<UIText>();
		this.TitleText.font = this.tmpFont;
		this.TitleText.text = this.DM.mStringTable.GetStringByID(10166u);
		this.Image1 = child.GetChild(1).GetComponent<Image>();
		this.ScaleImage1 = child.GetChild(1).GetComponent<uTweenScale>();
		this.BuyOnceSA = child.GetChild(1).GetComponent<UISpritesArray>();
		this.Image1Text = child.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.Image1Text.font = this.tmpFont;
		this.Image1Text.text = this.DM.mStringTable.GetStringByID(10167u);
		this.Image1.enabled = true;
		this.Image1Text.enabled = true;
		this.CrystalImage = child.GetChild(3).GetComponent<Image>();
		this.CrystalText = child.GetChild(4).GetComponent<UIText>();
		this.CrystalText.font = this.tmpFont;
		this.CrystalStr = this.SM.SpawnString(30);
		UIText component = child.GetChild(2).GetComponent<UIText>();
		component.font = this.tmpFont;
		component.text = this.DM.mStringTable.GetStringByID(838u);
		this.RefreshTextArray.Add(component);
		child.GetChild(6).GetComponent<UIButton>().m_Handler = this;
		component = child.GetChild(6).GetChild(0).GetComponent<UIText>();
		component.font = this.tmpFont;
		component.text = this.DM.mStringTable.GetStringByID(877u);
		this.RefreshTextArray.Add(component);
		child.GetChild(7).GetComponent<UIButton>().m_Handler = this;
		component = child.GetChild(7).GetChild(0).GetComponent<UIText>();
		component.font = this.tmpFont;
		component.text = this.DM.mStringTable.GetStringByID(10169u);
		this.RefreshTextArray.Add(component);
		child = this.UnitObjectT.GetChild(1).GetChild(5);
		this.GM.InitianHeroItemImg(child.GetChild(0), eHeroOrItem.Item, 1, 0, 0, 0, false, true, true, false);
		this.GM.InitianHeroItemImg(child.GetChild(2), eHeroOrItem.Item, 1, 0, 0, 0, false, true, true, false);
		this.GM.InitianHeroItemImg(child.GetChild(4), eHeroOrItem.Item, 1, 0, 0, 0, false, true, true, false);
		this.GM.InitLordEquipImg(child.GetChild(1), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		this.GM.InitLordEquipImg(child.GetChild(3), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		this.GM.InitLordEquipImg(child.GetChild(5), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		child.GetChild(12).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
		child.GetChild(13).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
		child.GetChild(14).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
		component = child.GetChild(6).GetComponent<UIText>();
		component.font = this.tmpFont;
		component = child.GetChild(9).GetComponent<UIText>();
		component.font = this.tmpFont;
		component = child.GetChild(7).GetComponent<UIText>();
		component.font = this.tmpFont;
		component = child.GetChild(10).GetComponent<UIText>();
		component.font = this.tmpFont;
		component = child.GetChild(8).GetComponent<UIText>();
		component.font = this.tmpFont;
		component = child.GetChild(11).GetComponent<UIText>();
		component.font = this.tmpFont;
		child = this.UnitObjectT.GetChild(2);
		this.InfoText = child.GetChild(0).GetComponent<UIText>();
		this.InfoText.font = this.tmpFont;
		this.InfoText.text = this.DM.mStringTable.GetStringByID(10168u);
		this.InfoImage = child.GetComponent<Image>();
		if (this.GM.IsArabic)
		{
			this.InfoImage.rectTransform.anchoredPosition = new Vector2(252f, -134f);
		}
		this.ItemT = new Transform[this.ItemCount];
		this.ItemT2 = new Transform[this.ItemCount];
		this.ItemText = new UIText[this.ItemCount];
		this.ItemCountText = new UIText[this.ItemCount];
		this.Btn1 = new UIButton[this.ItemCount];
		this.Hint1 = new UIButtonHint[this.ItemCount];
		for (int i = 0; i < this.ItemCount; i++)
		{
			this.ItemT[i] = child2.GetChild(0 + i * 2);
			this.ItemT[i].GetComponent<UIHIBtn>().m_Handler = this;
			this.ItemT2[i] = child2.GetChild(1 + i * 2);
			this.ItemText[i] = child2.GetChild(6 + i).GetComponent<UIText>();
			this.ItemCountText[i] = child2.GetChild(9 + i).GetComponent<UIText>();
			this.ItemCountStr[i] = this.SM.SpawnString(30);
			this.Btn1[i] = child2.GetChild(12 + i).GetComponent<UIButton>();
			this.Btn1[i].m_Handler = this;
			this.Btn1[i].m_BtnID1 = 4;
			this.Hint1[i] = child2.GetChild(12 + i).GetComponent<UIButtonHint>();
			this.Hint1[i].m_Handler = this;
			this.Hint1[i].DelayTime = 0.2f;
		}
		this.RefreshAll();
		this.GM.UpdateUI(EGUIWindow.Door, 1, 1);
	}

	// Token: 0x0600192A RID: 6442 RVA: 0x002A72CC File Offset: 0x002A54CC
	public override void OnClose()
	{
		if (this.CrystalStr != null)
		{
			this.SM.DeSpawnString(this.CrystalStr);
		}
		for (int i = 0; i < this.ItemCount; i++)
		{
			if (this.ItemCountStr[i] != null)
			{
				this.SM.DeSpawnString(this.ItemCountStr[i]);
			}
		}
	}

	// Token: 0x0600192B RID: 6443 RVA: 0x002A7330 File Offset: 0x002A5530
	public void RefreshAll()
	{
		ComboBox recordByKey = this.DM.ComboBoxTable.GetRecordByKey(this.MM.BackRewardComboBoxID);
		uint num = 0u;
		for (int i = 0; i < recordByKey.ItemData.Length; i++)
		{
			Equip recordByKey2 = this.DM.EquipTable.GetRecordByKey(recordByKey.ItemData[i].ItemID);
			if (recordByKey2.EquipKind == 11 && recordByKey2.PropertiesInfo[0].Propertieskey == 6)
			{
				num += (uint)(recordByKey2.PropertiesInfo[1].Propertieskey * recordByKey2.PropertiesInfo[1].PropertiesValue * recordByKey.ItemData[i].ItemCount);
			}
		}
		if (num > 0u)
		{
			this.CrystalStr.Length = 0;
			this.CrystalStr.uLongToFormat((ulong)num, 1, true);
			this.CrystalStr.AppendFormat("{0}");
			this.CrystalText.text = this.CrystalStr.ToString();
			this.CrystalText.SetAllDirty();
			this.CrystalText.cachedTextGenerator.Invalidate();
			this.CrystalText.gameObject.SetActive(true);
			this.CrystalImage.gameObject.SetActive(true);
		}
		else
		{
			this.CrystalText.gameObject.SetActive(false);
			this.CrystalImage.gameObject.SetActive(false);
		}
		int num2 = 0;
		int num3 = 0;
		while (num2 < this.ItemCount && num3 < recordByKey.ItemData.Length)
		{
			Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(recordByKey.ItemData[num3].ItemID);
			if (recordByKey2.EquipKind != 11 || recordByKey2.PropertiesInfo[0].Propertieskey != 6)
			{
				byte equipKind = recordByKey2.EquipKind;
				this.Btn1[num2].m_BtnID2 = (int)recordByKey.ItemData[num3].ItemID;
				this.Hint1[num2].Parm1 = recordByKey.ItemData[num3].ItemID;
				this.Hint1[num2].Parm2 = recordByKey.ItemData[num3].Rank;
				bool flag = this.GM.IsLeadItem(equipKind);
				if (flag)
				{
					GUIManager.Instance.ChangeLordEquipImg(this.ItemT2[num2], recordByKey.ItemData[num3].ItemID, recordByKey.ItemData[num3].Rank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
				}
				else
				{
					GUIManager.Instance.ChangeHeroItemImg(this.ItemT[num2], eHeroOrItem.Item, recordByKey.ItemData[num3].ItemID, 0, 0, 0);
				}
				if (flag || !this.MM.CheckCanOpenDetail(recordByKey.ItemData[num3].ItemID))
				{
					this.Hint1[num2].enabled = true;
				}
				else
				{
					this.Hint1[num2].enabled = false;
				}
				this.ItemT[num2].gameObject.SetActive(!flag);
				this.ItemT2[num2].gameObject.SetActive(flag);
				this.ItemText[num2].text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey2.EquipName);
				this.ItemText[num2].color = this.MM.GetItemRankColor(recordByKey.ItemData[num3].Rank);
				this.ItemCountStr[num2].Length = 0;
				StringManager.IntToStr(this.ItemCountStr[num2], (long)recordByKey.ItemData[num3].ItemCount, 1, true);
				this.ItemCountText[num2].text = this.ItemCountStr[num2].ToString();
				this.ItemCountText[num2].SetAllDirty();
				this.ItemCountText[num2].cachedTextGenerator.Invalidate();
				num2++;
			}
			num3++;
		}
	}

	// Token: 0x0600192C RID: 6444 RVA: 0x002A7754 File Offset: 0x002A5954
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			if (this.MM.BackRewardComboBoxID == 0)
			{
				if (this.door)
				{
					this.door.CloseMenu(false);
				}
				this.GM.UIQueueLockRelease(EGUIQueueLock.UIQL_Mall);
			}
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				for (int i = 0; i < this.RefreshTextArray.Count; i++)
				{
					if (this.RefreshTextArray[i] != null && this.RefreshTextArray[i].enabled)
					{
						this.RefreshTextArray[i].enabled = false;
						this.RefreshTextArray[i].enabled = true;
					}
				}
				if (this.InfoText != null && this.InfoText.enabled)
				{
					this.InfoText.enabled = false;
					this.InfoText.enabled = true;
				}
				if (this.TitleText != null && this.TitleText.enabled)
				{
					this.TitleText.enabled = false;
					this.TitleText.enabled = true;
				}
				if (this.Image1Text != null && this.Image1Text.enabled)
				{
					this.Image1Text.enabled = false;
					this.Image1Text.enabled = true;
				}
				if (this.CrystalText != null && this.CrystalText.enabled)
				{
					this.CrystalText.enabled = false;
					this.CrystalText.enabled = true;
				}
				for (int j = 0; j < this.ItemCount; j++)
				{
					if (this.ItemText[j] != null && this.ItemText[j].enabled)
					{
						this.ItemText[j].enabled = false;
						this.ItemText[j].enabled = true;
					}
					if (this.ItemCountText[j] != null && this.ItemCountText[j].enabled)
					{
						this.ItemCountText[j].enabled = false;
						this.ItemCountText[j].enabled = true;
					}
				}
			}
			break;
		}
	}

	// Token: 0x0600192D RID: 6445 RVA: 0x002A79B4 File Offset: 0x002A5BB4
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			if (sender.m_BtnID2 == 1)
			{
				if (this.door)
				{
					this.door.OpenMenu(EGUIWindow.UIBackReward_Detail, 0, 0, false);
				}
			}
			else if (sender.m_BtnID2 == 2)
			{
				this.MM.Send_PUSHBACK_PRIZE();
			}
		}
		else if (sender.m_BtnID1 == 4 && this.MM.OpenDetail((ushort)sender.m_BtnID2))
		{
			AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		}
	}

	// Token: 0x0600192E RID: 6446 RVA: 0x002A7A4C File Offset: 0x002A5C4C
	public void OnHIButtonClick(UIHIBtn sender)
	{
		if (this.MM.OpenDetail(sender.HIID))
		{
			AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		}
	}

	// Token: 0x0600192F RID: 6447 RVA: 0x002A7A70 File Offset: 0x002A5C70
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		if (this.door)
		{
			img.sprite = this.door.LoadSprite(ImageName);
			img.material = this.door.LoadMaterial();
		}
	}

	// Token: 0x06001930 RID: 6448 RVA: 0x002A7AB0 File Offset: 0x002A5CB0
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001931 RID: 6449 RVA: 0x002A7AB4 File Offset: 0x002A5CB4
	public void OnButtonDown(UIButtonHint sender)
	{
		byte equipKind = this.DM.EquipTable.GetRecordByKey(sender.Parm1).EquipKind;
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

	// Token: 0x06001932 RID: 6450 RVA: 0x002A7B54 File Offset: 0x002A5D54
	public void OnButtonUp(UIButtonHint sender)
	{
		byte equipKind = this.DM.EquipTable.GetRecordByKey(sender.Parm1).EquipKind;
		bool flag = this.GM.IsLeadItem(equipKind);
		if (flag)
		{
			this.GM.m_LordInfo.Hide(sender);
		}
		else
		{
			this.GM.m_SimpleItemInfo.Hide(sender);
		}
	}

	// Token: 0x06001933 RID: 6451 RVA: 0x002A7BBC File Offset: 0x002A5DBC
	public override bool OnBackButtonClick()
	{
		return true;
	}

	// Token: 0x04004A6E RID: 19054
	private Transform m_transform;

	// Token: 0x04004A6F RID: 19055
	private Transform UnitObjectT;

	// Token: 0x04004A70 RID: 19056
	private DataManager DM;

	// Token: 0x04004A71 RID: 19057
	private GUIManager GM;

	// Token: 0x04004A72 RID: 19058
	private MallManager MM;

	// Token: 0x04004A73 RID: 19059
	private StringManager SM;

	// Token: 0x04004A74 RID: 19060
	private Font tmpFont;

	// Token: 0x04004A75 RID: 19061
	private Door m_door;

	// Token: 0x04004A76 RID: 19062
	public Image BackImage1;

	// Token: 0x04004A77 RID: 19063
	public Image BackImage2;

	// Token: 0x04004A78 RID: 19064
	public Image InfoImage;

	// Token: 0x04004A79 RID: 19065
	public UIText InfoText;

	// Token: 0x04004A7A RID: 19066
	public UIText TitleText;

	// Token: 0x04004A7B RID: 19067
	public Image Image1;

	// Token: 0x04004A7C RID: 19068
	public uTweenScale ScaleImage1;

	// Token: 0x04004A7D RID: 19069
	public UISpritesArray BuyOnceSA;

	// Token: 0x04004A7E RID: 19070
	public UIText Image1Text;

	// Token: 0x04004A7F RID: 19071
	public UISpritesArray RateSA;

	// Token: 0x04004A80 RID: 19072
	public UIText CrystalText;

	// Token: 0x04004A81 RID: 19073
	public Image CrystalImage;

	// Token: 0x04004A82 RID: 19074
	public RectTransform AllItemRC;

	// Token: 0x04004A83 RID: 19075
	public Transform[] ItemT;

	// Token: 0x04004A84 RID: 19076
	public Transform[] ItemT2;

	// Token: 0x04004A85 RID: 19077
	public UIText[] ItemText;

	// Token: 0x04004A86 RID: 19078
	public UIText[] ItemCountText;

	// Token: 0x04004A87 RID: 19079
	public UIButton[] Btn1;

	// Token: 0x04004A88 RID: 19080
	public UIButtonHint[] Hint1;

	// Token: 0x04004A89 RID: 19081
	private List<UIText> RefreshTextArray = new List<UIText>();

	// Token: 0x04004A8A RID: 19082
	private CString CrystalStr;

	// Token: 0x04004A8B RID: 19083
	private CString[] ItemCountStr = new CString[3];

	// Token: 0x04004A8C RID: 19084
	private int ItemCount = 3;
}
