using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200063E RID: 1598
public class UIOpenBox : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler, IUILEBtnClickHandler
{
	// Token: 0x06001ED2 RID: 7890 RVA: 0x003AE0E0 File Offset: 0x003AC2E0
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.m_transform = base.transform;
		this.tmpFont = this.GM.GetTTFFont();
		this.m_transform.GetChild(12).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		if (this.GM.bOpenOnIPhoneX)
		{
			this.m_transform.GetChild(12).GetComponent<Image>().enabled = false;
		}
		this.BackImage = this.m_transform.GetChild(1).GetComponent<Image>();
		Transform child = this.m_transform.GetChild(11);
		child.GetComponent<UIButton>().m_Handler = this;
		this.TitleImage1 = this.m_transform.GetChild(2).gameObject;
		this.TitleImage2 = this.m_transform.GetChild(3).gameObject;
		this.ForgeBtn = this.m_transform.GetChild(11).gameObject;
		this.RTImage1 = this.m_transform.GetChild(2).GetChild(1).GetComponent<Image>();
		this.RTImage2 = this.m_transform.GetChild(2).GetChild(2).GetComponent<Image>();
		this.TitleNameText = this.m_transform.GetChild(6).GetComponent<UIText>();
		this.TitleNameText.font = this.tmpFont;
		this.TitleStr = StringManager.Instance.SpawnString(100);
		this.GetAllText = this.m_transform.GetChild(7).GetComponent<UIText>();
		this.GetAllText.font = this.tmpFont;
		this.GatAllColor = this.GetAllText.color;
		this.GetAllText2 = this.m_transform.GetChild(8).GetComponent<UIText>();
		this.GetAllText2.font = this.tmpFont;
		this.GetAllText2.text = this.DM.mStringTable.GetStringByID(14664u);
		this.GetAllText2.color = this.GatOneColor;
		this.GM.InitianHeroItemImg(this.m_transform.GetChild(5), eHeroOrItem.Item, 0, 0, 0, 0, false, true, true, false);
		Transform child2 = this.m_transform.GetChild(10);
		this.GM.InitianHeroItemImg(child2.GetChild(1), eHeroOrItem.Item, 1, 0, 0, 0, false, true, true, false);
		child2.GetChild(1).gameObject.AddComponent<IgnoreRaycast>();
		this.GM.InitLordEquipImg(child2.GetChild(2), 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		child2.GetChild(2).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
		UIText component = child2.GetChild(3).GetChild(0).GetComponent<UIText>();
		component.font = this.tmpFont;
		component = child2.GetChild(4).GetComponent<UIText>();
		component.font = this.tmpFont;
		component = child2.GetChild(5).GetComponent<UIText>();
		component.font = this.tmpFont;
		child2.GetChild(6).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
		this.Scroll = this.m_transform.GetChild(9).GetComponent<ScrollPanel>();
		this.Scroll.IntiScrollPanel(358f, 0f, 0f, this.NowHeightList, 9, this);
		UIButtonHint.scrollRect = this.Scroll.GetComponent<CScrollRect>();
		child = this.m_transform.GetChild(13);
		this.FBGO = child.gameObject;
		this.FBTitleText = child.GetChild(0).GetComponent<UIText>();
		this.FBTitleText.font = this.tmpFont;
		this.FBTitleText.text = this.DM.mStringTable.GetStringByID(12191u);
		for (int i = 0; i < 4; i++)
		{
			this.FBItemGO[i] = child.GetChild(i + 1).gameObject;
			this.FBHIBtn[i] = child.GetChild(i + 1).GetChild(0).GetComponent<UIHIBtn>();
			this.FBHIBtn[i].m_Handler = this;
			this.GM.InitianHeroItemImg(this.FBHIBtn[i].transform, eHeroOrItem.Item, 1, 0, 0, 0, false, true, true, false);
			this.FBLEBtn[i] = child.GetChild(i + 1).GetChild(1).GetComponent<UILEBtn>();
			this.FBLEBtn[i].m_Handler = this;
			this.GM.InitLordEquipImg(this.FBLEBtn[i].transform, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
			this.FBCountText[i] = child.GetChild(i + 1).GetChild(2).GetComponent<UIText>();
			this.FBCountText[i].font = this.tmpFont;
			this.FBCountStr[i] = StringManager.Instance.SpawnString(30);
		}
		this.RefreshList((byte)arg1, (ushort)arg2);
		if (BattleController.IsGambleMode)
		{
			this.GM.m_ChatBox.gameObject.SetActive(false);
		}
		this.GM.UpdateUI(EGUIWindow.Door, 1, 1);
	}

	// Token: 0x06001ED3 RID: 7891 RVA: 0x003AE5C4 File Offset: 0x003AC7C4
	public override void OnClose()
	{
		if (this.TitleStr == null)
		{
			return;
		}
		StringManager.Instance.DeSpawnString(this.TitleStr);
		this.TitleStr = null;
		for (int i = 0; i < 9; i++)
		{
			if (this.PriceStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.PriceStr[i]);
				this.PriceStr[i] = null;
			}
			if (this.NameStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.NameStr[i]);
				this.NameStr[i] = null;
			}
			if (this.RankStr[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.RankStr[i]);
				this.RankStr[i] = null;
			}
		}
		for (int j = 0; j < 4; j++)
		{
			if (this.FBCountStr[j] != null)
			{
				StringManager.Instance.DeSpawnString(this.FBCountStr[j]);
				this.FBCountStr[j] = null;
			}
		}
		if (BattleController.IsGambleMode)
		{
			this.GM.m_ChatBox.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001ED4 RID: 7892 RVA: 0x003AE6E0 File Offset: 0x003AC8E0
	private void RefreshList(byte Kind, ushort ItemID)
	{
		this.SetIndex = 0;
		this.OpenKind = Kind;
		this.OpenID = (this.BoxID = ItemID);
		this.ForgeBtn.SetActive(false);
		this.FBGO.SetActive(false);
		if (this.OpenKind == 1 || this.OpenKind == 4)
		{
			ushort inKey = ItemID;
			if (this.OpenKind == 4)
			{
				ItemID = (this.BoxID = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(inKey).FriendPrice);
			}
			this.TitleImage1.SetActive(true);
			this.RTImage1.enabled = true;
			this.GetAllText2.gameObject.SetActive(false);
			this.BackImage.color = new Color32(42, 185, 109, byte.MaxValue);
			this.tmpEquip = this.DM.EquipTable.GetRecordByKey(ItemID);
			this.NowHeightList.Clear();
			if (this.tmpEquip.EquipKind == 18)
			{
				if (this.tmpEquip.PropertiesInfo[0].Propertieskey == 1)
				{
					this.BeginRank = 1;
					this.EndRank = 3;
				}
				else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == 2)
				{
					this.BeginRank = 2;
					this.EndRank = 4;
				}
				else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == 3)
				{
					this.BeginRank = 1;
					this.EndRank = 5;
				}
				else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == 4)
				{
					this.BeginRank = (byte)this.tmpEquip.PropertiesInfo[5].Propertieskey;
					this.EndRank = (byte)this.tmpEquip.PropertiesInfo[5].PropertiesValue;
				}
				else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == 5)
				{
					this.GetAllText2.gameObject.SetActive(true);
					this.RTImage1.enabled = false;
					this.RTImage2.enabled = true;
					this.BeginRank = 0;
					this.EndRank = 0;
				}
				else
				{
					this.BeginRank = 0;
					this.EndRank = 0;
				}
				this.TitleStr.Length = 0;
				if (this.tmpEquip.PropertiesInfo[0].PropertiesValue == 0)
				{
					this.TitleStr.StringToFormat(MallManager.Instance.GetItemRankName(this.EndRank));
					this.TitleStr.AppendFormat(this.DM.mStringTable.GetStringByID(7739u));
				}
				this.TitleStr.Append(this.DM.mStringTable.GetStringByID((uint)this.tmpEquip.EquipName));
				this.TitleNameText.text = this.TitleStr.ToString();
				this.TitleNameText.SetAllDirty();
				this.TitleNameText.cachedTextGenerator.Invalidate();
				if (this.IsGiftBox(this.BoxID))
				{
					this.tmpGB = this.DM.GiftBoxTable.GetRecordByKey(this.tmpEquip.PropertiesInfo[1].Propertieskey);
					this.ItemCount = 0;
					for (int i = 0; i < this.tmpGB.ItemData.Length; i++)
					{
						if (this.tmpGB.ItemData[i].ItemID != 0)
						{
							this.ItemCount++;
							this.NowHeightList.Add(60f);
						}
					}
				}
				else
				{
					this.tmpLB = this.DM.LotteryBoxTable.GetRecordByKey(this.tmpEquip.PropertiesInfo[1].Propertieskey);
					this.SetIndex = this.tmpLB.SetIndex;
					if (this.SetIndex != 0)
					{
						this.ForgeBtn.SetActive(true);
					}
					this.ItemCount = 0;
					for (int j = 0; j < this.tmpLB.ItemData.Length; j++)
					{
						if (this.tmpLB.ItemData[j].ItemID != 0)
						{
							this.ItemCount++;
							this.NowHeightList.Add(60f);
						}
					}
				}
				this.GetAllText.text = this.DM.mStringTable.GetStringByID(837u);
				this.GetAllText.color = this.GatOneColor;
			}
			else if (this.tmpEquip.EquipKind == 19)
			{
				this.TitleNameText.text = this.DM.mStringTable.GetStringByID((uint)this.tmpEquip.EquipName);
				this.tmpCB = this.DM.ComboBoxTable.GetRecordByKey(this.tmpEquip.PropertiesInfo[1].Propertieskey);
				this.SetIndex = this.tmpCB.SetIndex;
				if (this.SetIndex != 0)
				{
					this.ForgeBtn.SetActive(true);
				}
				this.ItemCount = 0;
				for (int k = 0; k < this.tmpCB.ItemData.Length; k++)
				{
					if (this.tmpCB.ItemData[k].ItemID != 0)
					{
						this.ItemCount++;
						this.NowHeightList.Add(60f);
					}
				}
				this.GetAllText.text = this.DM.mStringTable.GetStringByID(838u);
				this.GetAllText.color = this.GatAllColor;
			}
			if (this.OpenKind == 4)
			{
				this.GetAllText.text = this.DM.mStringTable.GetStringByID(12190u);
				this.GetAllText.color = this.GatAllColor;
				FBMissionTbl recordByKey = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(inKey);
				Equip recordByKey2 = this.DM.EquipTable.GetRecordByKey(recordByKey.OwnPrice);
				ComboBox recordByKey3 = this.DM.ComboBoxTable.GetRecordByKey(recordByKey2.PropertiesInfo[1].Propertieskey);
				int num = 0;
				while (num < 4 && num < recordByKey3.ItemData.Length)
				{
					if (recordByKey3.ItemData[num].ItemID != 0)
					{
						Equip recordByKey4 = this.DM.EquipTable.GetRecordByKey(recordByKey3.ItemData[num].ItemID);
						bool flag = this.GM.IsLeadItem(recordByKey4.EquipKind);
						ushort itemID = recordByKey3.ItemData[num].ItemID;
						ushort itemCount = recordByKey3.ItemData[num].ItemCount;
						byte rank = this.tmpCB.ItemData[num].Rank;
						if (flag)
						{
							GUIManager.Instance.ChangeLordEquipImg(this.FBLEBtn[num].transform, itemID, rank, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
						}
						else
						{
							GUIManager.Instance.ChangeHeroItemImg(this.FBHIBtn[num].transform, eHeroOrItem.Item, itemID, 0, 0, 0);
						}
						this.FBHIBtn[num].gameObject.SetActive(!flag);
						this.FBLEBtn[num].gameObject.SetActive(flag);
						this.FBCountStr[num].Length = 0;
						this.FBCountStr[num].IntToFormat((long)itemCount, 1, false);
						if (this.GM.IsArabic)
						{
							this.FBCountStr[num].AppendFormat("{0}x");
						}
						else
						{
							this.FBCountStr[num].AppendFormat("x{0}");
						}
						this.FBCountText[num].text = this.FBCountStr[num].ToString();
						this.FBCountText[num].SetAllDirty();
						this.FBCountText[num].cachedTextGenerator.Invalidate();
						this.FBItemGO[num].SetActive(true);
					}
					else
					{
						this.FBItemGO[num].SetActive(false);
					}
					num++;
				}
				this.FBGO.SetActive(true);
			}
		}
		else if (this.OpenKind == 2)
		{
			this.TitleImage2.SetActive(true);
			this.BackImage.color = new Color32(42, 150, 185, byte.MaxValue);
			this.tmpEquip = this.DM.EquipTable.GetRecordByKey(ItemID);
			this.TitleStr.Length = 0;
			if (this.tmpEquip.EquipKind == 18)
			{
				if (this.tmpEquip.PropertiesInfo[0].Propertieskey == 1)
				{
					this.BeginRank = 1;
					this.EndRank = 3;
				}
				else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == 2)
				{
					this.BeginRank = 2;
					this.EndRank = 4;
				}
				else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == 3)
				{
					this.BeginRank = 1;
					this.EndRank = 5;
				}
				else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == 4)
				{
					this.BeginRank = (byte)this.tmpEquip.PropertiesInfo[5].Propertieskey;
					this.EndRank = (byte)this.tmpEquip.PropertiesInfo[5].PropertiesValue;
				}
				else
				{
					this.BeginRank = 0;
					this.EndRank = 0;
				}
				if (this.tmpEquip.PropertiesInfo[0].PropertiesValue == 0)
				{
					this.TitleStr.StringToFormat(MallManager.Instance.GetItemRankName(this.EndRank));
					this.TitleStr.AppendFormat(this.DM.mStringTable.GetStringByID(7739u));
				}
			}
			this.TitleStr.Append(this.DM.mStringTable.GetStringByID((uint)this.tmpEquip.EquipName));
			this.TitleStr.Append(' ');
			this.TitleStr.IntToFormat((long)this.GM.OpenBoxCount, 1, false);
			if (this.GM.IsArabic)
			{
				this.TitleStr.AppendFormat("{0}x");
			}
			else
			{
				this.TitleStr.AppendFormat("x{0}");
			}
			this.TitleNameText.text = this.TitleStr.ToString();
			this.TitleNameText.SetAllDirty();
			this.TitleNameText.cachedTextGenerator.Invalidate();
			this.NowHeightList.Clear();
			this.ItemCount = this.GM.CommonItemData.Count;
			for (int l = 0; l < this.ItemCount; l++)
			{
				this.NowHeightList.Add(60f);
			}
			this.GetAllText.text = this.DM.mStringTable.GetStringByID(839u);
			this.GetAllText.color = this.GatAllColor;
		}
		else if (this.OpenKind == 3)
		{
			this.TitleImage1.SetActive(true);
			this.RTImage1.enabled = true;
			this.BackImage.color = new Color32(42, 185, 109, byte.MaxValue);
			this.tmpEquip = this.DM.EquipTable.GetRecordByKey(ItemID);
			this.NowHeightList.Clear();
			this.TitleNameText.text = this.DM.mStringTable.GetStringByID((uint)this.tmpEquip.EquipName);
			MerchantmanManager instance = MerchantmanManager.Instance;
			this.ItemCount = 0;
			for (int m = 0; m < (int)instance.MerchantmanExtraData.DataLen; m++)
			{
				if (instance.MerchantmanExtraData.ItemContain[m].ItemID != 0)
				{
					this.ItemCount++;
					this.NowHeightList.Add(60f);
				}
			}
			this.GetAllText.text = this.DM.mStringTable.GetStringByID(838u);
			this.GetAllText.color = this.GatAllColor;
			if (instance.bNeedUpDateExtra)
			{
				instance.SendReQusetBlackMarket_Data();
			}
		}
		this.GM.ChangeHeroItemImg(this.m_transform.GetChild(5), eHeroOrItem.Item, this.BoxID, 0, 0, 0);
		this.Scroll.AddNewDataHeight(this.NowHeightList, true, true);
	}

	// Token: 0x06001ED5 RID: 7893 RVA: 0x003AF390 File Offset: 0x003AD590
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			if (this.TitleNameText != null && this.TitleNameText.enabled)
			{
				this.TitleNameText.enabled = false;
				this.TitleNameText.enabled = true;
			}
			if (this.GetAllText != null && this.GetAllText.enabled)
			{
				this.GetAllText.enabled = false;
				this.GetAllText.enabled = true;
			}
			if (this.GetAllText2 != null && this.GetAllText2.enabled)
			{
				this.GetAllText2.enabled = false;
				this.GetAllText2.enabled = true;
			}
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
					if (this.ScrollComp[i].RankText != null && this.ScrollComp[i].RankText.enabled)
					{
						this.ScrollComp[i].RankText.enabled = false;
						this.ScrollComp[i].RankText.enabled = true;
					}
					if (this.ScrollComp[i].HIBtn != null)
					{
						this.ScrollComp[i].HIBtn.Refresh_FontTexture();
					}
				}
			}
			if (this.FBTitleText != null && this.FBTitleText.enabled)
			{
				this.FBTitleText.enabled = false;
				this.FBTitleText.enabled = true;
			}
			for (int j = 0; j < 4; j++)
			{
				if (this.FBHIBtn[j] != null)
				{
					this.FBHIBtn[j].Refresh_FontTexture();
				}
				if (this.FBCountText[j] != null && this.FBCountText[j].enabled)
				{
					this.FBCountText[j].enabled = false;
					this.FBCountText[j].enabled = true;
				}
			}
		}
	}

	// Token: 0x06001ED6 RID: 7894 RVA: 0x003AF68C File Offset: 0x003AD88C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelObjectIdx < 9)
		{
			if (!this.bFindScrollComp[panelObjectIdx])
			{
				this.bFindScrollComp[panelObjectIdx] = true;
				this.ScrollComp[panelObjectIdx].LineImage = item.transform.GetChild(0).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].HIBtn = item.transform.GetChild(1).GetComponent<UIHIBtn>();
				this.ScrollComp[panelObjectIdx].HIBtn.m_Handler = this;
				this.ScrollComp[panelObjectIdx].LEBtn = item.transform.GetChild(2).GetComponent<UILEBtn>();
				this.ScrollComp[panelObjectIdx].LEBtn.m_Handler = this;
				this.ScrollComp[panelObjectIdx].ItemName = item.transform.GetChild(4).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].ItemCountText = item.transform.GetChild(5).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].RankImg = item.transform.GetChild(3).GetComponent<Image>();
				this.ScrollComp[panelObjectIdx].RankText = item.transform.GetChild(3).GetChild(0).GetComponent<UIText>();
				this.ScrollComp[panelObjectIdx].Btn3 = item.transform.GetChild(6).GetComponent<UIButton>();
				this.ScrollComp[panelObjectIdx].Hint3 = item.transform.GetChild(6).GetComponent<UIButtonHint>();
				this.ScrollComp[panelObjectIdx].Hint3.m_Handler = this;
				this.ScrollComp[panelObjectIdx].Hint3.DelayTime = 0.2f;
				this.PriceStr[panelObjectIdx] = StringManager.Instance.SpawnString(30);
				this.NameStr[panelObjectIdx] = StringManager.Instance.SpawnString(150);
				this.RankStr[panelObjectIdx] = StringManager.Instance.SpawnString(30);
			}
			if (dataIdx < 0)
			{
				return;
			}
			ushort num = 1;
			ushort num2 = 1;
			byte b = 1;
			bool flag = false;
			this.NameStr[panelObjectIdx].Length = 0;
			this.ScrollComp[panelObjectIdx].HIBtn.m_BtnID2 = panelObjectIdx;
			if (this.OpenKind == 1 || this.OpenKind == 4)
			{
				this.ScrollComp[panelObjectIdx].LineImage.color = new Color32(94, 183, 138, byte.MaxValue);
				if (this.tmpEquip.EquipKind == 18)
				{
					if (this.IsGiftBox(this.BoxID))
					{
						if (dataIdx >= this.tmpGB.ItemData.Length)
						{
							return;
						}
						num = this.tmpGB.ItemData[dataIdx].ItemID;
						num2 = this.tmpGB.ItemData[dataIdx].ItemCount;
					}
					else
					{
						if (dataIdx >= this.tmpLB.ItemData.Length)
						{
							return;
						}
						num = this.tmpLB.ItemData[dataIdx].ItemID;
						num2 = this.tmpLB.ItemData[dataIdx].ItemCount;
					}
					Equip recordByKey = this.DM.EquipTable.GetRecordByKey(num);
					flag = this.GM.IsLeadItem(recordByKey.EquipKind);
					this.NameStr[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID((uint)recordByKey.EquipName));
					if (flag)
					{
						if (this.EndRank == 0)
						{
							this.NameStr[panelObjectIdx].StringToFormat(MallManager.Instance.GetItemRankName(this.BeginRank));
							this.NameStr[panelObjectIdx].AppendFormat("({0})");
						}
						else
						{
							this.NameStr[panelObjectIdx].StringToFormat(MallManager.Instance.GetItemRankName(this.BeginRank));
							this.NameStr[panelObjectIdx].StringToFormat(MallManager.Instance.GetItemRankName(this.EndRank));
							this.NameStr[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7738u));
						}
					}
					if (recordByKey.EquipKind == 30)
					{
						PetTbl recordByKey2 = PetManager.Instance.PetTable.GetRecordByKey(recordByKey.SyntheticParts[0].SyntheticItem);
						this.RankStr[panelObjectIdx].Length = 0;
						StringManager.IntToStr(this.RankStr[panelObjectIdx], (long)recordByKey2.Rare, 1, false);
						this.ScrollComp[panelObjectIdx].RankText.text = this.RankStr[panelObjectIdx].ToString();
						this.ScrollComp[panelObjectIdx].RankText.SetAllDirty();
						this.ScrollComp[panelObjectIdx].RankText.cachedTextGenerator.Invalidate();
						this.ScrollComp[panelObjectIdx].RankImg.gameObject.SetActive(true);
					}
					else
					{
						this.ScrollComp[panelObjectIdx].RankImg.gameObject.SetActive(false);
					}
				}
				else
				{
					if (this.tmpEquip.EquipKind != 19)
					{
						return;
					}
					if (dataIdx >= this.tmpCB.ItemData.Length)
					{
						return;
					}
					num = this.tmpCB.ItemData[dataIdx].ItemID;
					num2 = this.tmpCB.ItemData[dataIdx].ItemCount;
					b = this.tmpCB.ItemData[dataIdx].Rank;
					Equip recordByKey = this.DM.EquipTable.GetRecordByKey(num);
					flag = this.GM.IsLeadItem(recordByKey.EquipKind);
					if (this.tmpCB.ItemData[dataIdx].Rank != 0)
					{
						this.NameStr[panelObjectIdx].StringToFormat(MallManager.Instance.GetItemRankName(this.tmpCB.ItemData[dataIdx].Rank));
						this.NameStr[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7739u));
					}
					else if (recordByKey.EquipKind == 18 && this.tmpEquip.PropertiesInfo[0].Propertieskey != 6)
					{
						byte itemRank = 1;
						if (this.tmpEquip.PropertiesInfo[0].Propertieskey == 1)
						{
							itemRank = 3;
						}
						else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == 2)
						{
							itemRank = 4;
						}
						else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == 3)
						{
							itemRank = 5;
						}
						this.NameStr[panelObjectIdx].StringToFormat(MallManager.Instance.GetItemRankName(itemRank));
						this.NameStr[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7739u));
					}
					this.NameStr[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID((uint)recordByKey.EquipName));
				}
			}
			else if (this.OpenKind == 2)
			{
				this.ScrollComp[panelObjectIdx].LineImage.color = new Color32(94, 165, 183, byte.MaxValue);
				if (dataIdx >= this.GM.CommonItemData.Count)
				{
					return;
				}
				num = this.GM.CommonItemData[dataIdx].ItemID;
				num2 = this.GM.CommonItemData[dataIdx].Num;
				b = this.GM.CommonItemData[dataIdx].ItemRank;
				Equip recordByKey = this.DM.EquipTable.GetRecordByKey(num);
				flag = this.GM.IsLeadItem(recordByKey.EquipKind);
				if (this.GM.CommonItemData[dataIdx].ItemRank != 0)
				{
					this.NameStr[panelObjectIdx].StringToFormat(MallManager.Instance.GetItemRankName(b));
					this.NameStr[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7739u));
				}
				CString cstring = StringManager.Instance.StaticString1024();
				UIItemInfo.SetNameProperties(null, null, cstring, null, ref recordByKey, null);
				this.NameStr[panelObjectIdx].Append(cstring);
			}
			else if (this.OpenKind == 3)
			{
				this.ScrollComp[panelObjectIdx].LineImage.color = new Color32(94, 165, 183, byte.MaxValue);
				MerchantmanManager instance = MerchantmanManager.Instance;
				if (dataIdx >= (int)instance.MerchantmanExtraData.DataLen)
				{
					return;
				}
				num = instance.MerchantmanExtraData.ItemContain[dataIdx].ItemID;
				num2 = instance.MerchantmanExtraData.ItemContain[dataIdx].Num;
				b = instance.MerchantmanExtraData.ItemContain[dataIdx].ItemRank;
				Equip recordByKey = this.DM.EquipTable.GetRecordByKey(num);
				flag = this.GM.IsLeadItem(recordByKey.EquipKind);
				if (b != 0)
				{
					this.NameStr[panelObjectIdx].StringToFormat(MallManager.Instance.GetItemRankName(b));
					this.NameStr[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7739u));
				}
				CString cstring2 = StringManager.Instance.StaticString1024();
				UIItemInfo.SetNameProperties(null, null, cstring2, null, ref recordByKey, null);
				this.NameStr[panelObjectIdx].Append(cstring2);
			}
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
			this.ScrollComp[panelObjectIdx].Hint3.Parm1 = num;
			this.ScrollComp[panelObjectIdx].Hint3.Parm2 = b;
			if (flag || (!MallManager.Instance.CheckCanOpenDetail(num) && !PetManager.Instance.IsFakePetItem(num)))
			{
				this.ScrollComp[panelObjectIdx].Hint3.enabled = true;
			}
			else
			{
				this.ScrollComp[panelObjectIdx].Hint3.enabled = false;
			}
			this.ScrollComp[panelObjectIdx].Btn3.gameObject.SetActive(this.ScrollComp[panelObjectIdx].Hint3.enabled);
			this.ScrollComp[panelObjectIdx].ItemName.text = this.NameStr[panelObjectIdx].ToString();
			this.ScrollComp[panelObjectIdx].ItemName.SetAllDirty();
			this.ScrollComp[panelObjectIdx].ItemName.cachedTextGenerator.Invalidate();
			this.PriceStr[panelObjectIdx].Length = 0;
			StringManager.IntToStr(this.PriceStr[panelObjectIdx], (long)num2, 1, true);
			this.ScrollComp[panelObjectIdx].ItemCountText.text = this.PriceStr[panelObjectIdx].ToString();
			this.ScrollComp[panelObjectIdx].ItemCountText.SetAllDirty();
			this.ScrollComp[panelObjectIdx].ItemCountText.cachedTextGenerator.Invalidate();
		}
	}

	// Token: 0x06001ED7 RID: 7895 RVA: 0x003B0230 File Offset: 0x003AE430
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		if (dataIndex < 0)
		{
			return;
		}
		ushort tmpItemID = 1;
		if (this.OpenKind == 1 || this.OpenKind == 4)
		{
			if (this.tmpEquip.EquipKind == 18)
			{
				if (this.IsGiftBox(this.BoxID))
				{
					if (dataIndex >= this.tmpGB.ItemData.Length)
					{
						return;
					}
					tmpItemID = this.tmpGB.ItemData[dataIndex].ItemID;
				}
				else
				{
					if (dataIndex >= this.tmpLB.ItemData.Length)
					{
						return;
					}
					tmpItemID = this.tmpLB.ItemData[dataIndex].ItemID;
				}
			}
			else
			{
				if (this.tmpEquip.EquipKind != 19)
				{
					return;
				}
				if (dataIndex >= this.tmpCB.ItemData.Length)
				{
					return;
				}
				tmpItemID = this.tmpCB.ItemData[dataIndex].ItemID;
			}
		}
		else if (this.OpenKind == 2)
		{
			if (dataIndex >= this.GM.CommonItemData.Count)
			{
				return;
			}
			tmpItemID = this.GM.CommonItemData[dataIndex].ItemID;
		}
		else if (this.OpenKind == 3)
		{
			MerchantmanManager instance = MerchantmanManager.Instance;
			if (dataIndex >= (int)instance.MerchantmanExtraData.DataLen)
			{
				return;
			}
			tmpItemID = instance.MerchantmanExtraData.ItemContain[dataIndex].ItemID;
		}
		if (this.OpenNext(tmpItemID))
		{
			AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		}
	}

	// Token: 0x06001ED8 RID: 7896 RVA: 0x003B03C0 File Offset: 0x003AE5C0
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (sender.m_BtnID2 == 2)
			{
				if (this.GM.BuildingData.GetBuildData(15, 0).Level < 1)
				{
					this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(7533u), 255, true);
					return;
				}
				if (this.DM.mLordEquip == null)
				{
					this.DM.mLordEquip = LordEquipData.Instance();
				}
				if (door)
				{
					this.DM.mLordEquip.OpenForgeSet(this.SetIndex, 4);
				}
			}
			else if (sender.m_BtnID2 == 3)
			{
				if (this.OpenData.Count > 0)
				{
					int index = this.OpenData.Count - 1;
					this.RefreshList(this.OpenData[index].OpenKind, this.OpenData[index].OpenID);
					this.OpenData.RemoveAt(index);
				}
				else if (BattleController.IsGambleMode)
				{
					GamblingManager.Instance.CloseMenu(false);
				}
				else if (door)
				{
					door.CloseMenu(false);
				}
			}
		}
	}

	// Token: 0x06001ED9 RID: 7897 RVA: 0x003B051C File Offset: 0x003AE71C
	public void OnHIButtonClick(UIHIBtn sender)
	{
		if (this.OpenNext(this.ScrollComp[sender.m_BtnID2].HIBtn.HIID))
		{
			AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		}
	}

	// Token: 0x06001EDA RID: 7898 RVA: 0x003B0550 File Offset: 0x003AE750
	public void OnLEButtonClick(UILEBtn sender)
	{
		if (this.OpenNext(this.ScrollComp[sender.m_BtnID2].LEBtn.LEID))
		{
			AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		}
	}

	// Token: 0x06001EDB RID: 7899 RVA: 0x003B0584 File Offset: 0x003AE784
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

	// Token: 0x06001EDC RID: 7900 RVA: 0x003B0620 File Offset: 0x003AE820
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

	// Token: 0x06001EDD RID: 7901 RVA: 0x003B0684 File Offset: 0x003AE884
	private bool OpenNext(ushort tmpItemID)
	{
		if (PetManager.Instance.IsFakePetItem(tmpItemID))
		{
			Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(tmpItemID);
			PetManager.Instance.OpenPetMaxShowUI((int)recordByKey.SyntheticParts[0].SyntheticItem);
			return true;
		}
		if (!MallManager.Instance.CheckCanOpenDetail(tmpItemID))
		{
			return false;
		}
		OpenStruct item = default(OpenStruct);
		item.OpenKind = this.OpenKind;
		item.OpenID = this.OpenID;
		this.OpenData.Add(item);
		this.RefreshList(1, tmpItemID);
		return true;
	}

	// Token: 0x06001EDE RID: 7902 RVA: 0x003B071C File Offset: 0x003AE91C
	private bool IsGiftBox(ushort tmpItemID)
	{
		Equip recordByKey = this.DM.EquipTable.GetRecordByKey(tmpItemID);
		return recordByKey.PropertiesInfo[2].Propertieskey == 1 || recordByKey.PropertiesInfo[2].Propertieskey == 2;
	}

	// Token: 0x06001EDF RID: 7903 RVA: 0x003B076C File Offset: 0x003AE96C
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			if (this.OpenKind == 3)
			{
				MerchantmanManager.Instance.SendReQusetBlackMarket_Data();
			}
			break;
		case 2:
			if (this.OpenKind == 3)
			{
				this.RefreshList(this.OpenKind, this.OpenID);
			}
			break;
		case 3:
			if (this.OpenKind == 3)
			{
				if (BattleController.IsGambleMode)
				{
					GUIManager.Instance.CloseMenu(this.m_eWindow);
					GUIManager.Instance.OpenMenu(EGUIWindow.UI_MonsterCrypt, 0, 0, true, false, false);
				}
				else
				{
					Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
					if (door)
					{
						door.CloseMenu(false);
					}
				}
			}
			break;
		}
	}

	// Token: 0x0400619E RID: 24990
	private const int UnitCount = 9;

	// Token: 0x0400619F RID: 24991
	private const int FBItemCount = 4;

	// Token: 0x040061A0 RID: 24992
	private Transform m_transform;

	// Token: 0x040061A1 RID: 24993
	private DataManager DM;

	// Token: 0x040061A2 RID: 24994
	private GUIManager GM;

	// Token: 0x040061A3 RID: 24995
	private Font tmpFont;

	// Token: 0x040061A4 RID: 24996
	private UIText TitleNameText;

	// Token: 0x040061A5 RID: 24997
	private UIText GetAllText;

	// Token: 0x040061A6 RID: 24998
	private UIText GetAllText2;

	// Token: 0x040061A7 RID: 24999
	private Color GatAllColor;

	// Token: 0x040061A8 RID: 25000
	private Color GatOneColor = new Color(1f, 1f, 0f);

	// Token: 0x040061A9 RID: 25001
	private GameObject TitleImage1;

	// Token: 0x040061AA RID: 25002
	private GameObject TitleImage2;

	// Token: 0x040061AB RID: 25003
	private GameObject ForgeBtn;

	// Token: 0x040061AC RID: 25004
	private Image BackImage;

	// Token: 0x040061AD RID: 25005
	private Image RTImage1;

	// Token: 0x040061AE RID: 25006
	private Image RTImage2;

	// Token: 0x040061AF RID: 25007
	private ScrollPanel Scroll;

	// Token: 0x040061B0 RID: 25008
	private List<float> NowHeightList = new List<float>();

	// Token: 0x040061B1 RID: 25009
	private GiftBox tmpGB;

	// Token: 0x040061B2 RID: 25010
	private LotteryBox tmpLB;

	// Token: 0x040061B3 RID: 25011
	private ComboBox tmpCB;

	// Token: 0x040061B4 RID: 25012
	private Equip tmpEquip;

	// Token: 0x040061B5 RID: 25013
	private byte OpenKind;

	// Token: 0x040061B6 RID: 25014
	private byte BeginRank;

	// Token: 0x040061B7 RID: 25015
	private byte EndRank;

	// Token: 0x040061B8 RID: 25016
	private int ItemCount;

	// Token: 0x040061B9 RID: 25017
	private ushort SetIndex;

	// Token: 0x040061BA RID: 25018
	private ushort OpenID;

	// Token: 0x040061BB RID: 25019
	private ushort BoxID;

	// Token: 0x040061BC RID: 25020
	private bool[] bFindScrollComp = new bool[9];

	// Token: 0x040061BD RID: 25021
	private UnitComp_OpenBox[] ScrollComp = new UnitComp_OpenBox[9];

	// Token: 0x040061BE RID: 25022
	private CString[] PriceStr = new CString[9];

	// Token: 0x040061BF RID: 25023
	private CString[] NameStr = new CString[9];

	// Token: 0x040061C0 RID: 25024
	private CString[] RankStr = new CString[9];

	// Token: 0x040061C1 RID: 25025
	private CString TitleStr;

	// Token: 0x040061C2 RID: 25026
	private GameObject FBGO;

	// Token: 0x040061C3 RID: 25027
	private UIText FBTitleText;

	// Token: 0x040061C4 RID: 25028
	private GameObject[] FBItemGO = new GameObject[4];

	// Token: 0x040061C5 RID: 25029
	private UIHIBtn[] FBHIBtn = new UIHIBtn[4];

	// Token: 0x040061C6 RID: 25030
	private UILEBtn[] FBLEBtn = new UILEBtn[4];

	// Token: 0x040061C7 RID: 25031
	private UIText[] FBCountText = new UIText[4];

	// Token: 0x040061C8 RID: 25032
	private CString[] FBCountStr = new CString[4];

	// Token: 0x040061C9 RID: 25033
	private List<OpenStruct> OpenData = new List<OpenStruct>();
}
