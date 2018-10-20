using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200055C RID: 1372
public class UIForge_Item : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUILEBtnClickHandler
{
	// Token: 0x06001B6A RID: 7018 RVA: 0x003099DC File Offset: 0x00307BDC
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		if (this.DM.mLordEquip == null)
		{
			this.DM.mLordEquip = LordEquipData.Instance();
		}
		if (!this.DM.mLordEquip.LoadLordEquip(false))
		{
			this.bEqDataReq = true;
			if (!this.DM.mLordEquip.LoadLEMaterial(false))
			{
				this.bMaterialDataReq = true;
			}
		}
		for (int i = 0; i < 6; i++)
		{
			this.tmpImg_Items[i] = new Image[4];
			this.text_ItemEffect[i] = new UIText[6];
			this.text_ItemEffect_V[i] = new UIText[6];
			this.Cstr_Effect[i] = new CString[6];
			this.Cstr_Effect_V[i] = new CString[6];
			for (int j = 0; j < 6; j++)
			{
				this.Cstr_Effect[i][j] = StringManager.Instance.SpawnString(30);
				this.Cstr_Effect_V[i][j] = StringManager.Instance.SpawnString(30);
			}
			this.Cstr_ItemLv[i] = StringManager.Instance.SpawnString(100);
			this.Cstr_ItemName[i] = StringManager.Instance.SpawnString(30);
		}
		this.Cstr_Filter = StringManager.Instance.SpawnString(30);
		ushort indexByKey = this.DM.EquipTable.GetIndexByKey(4001);
		ushort indexByKey2 = this.DM.EquipTable.GetIndexByKey(5000);
		for (int k = (int)indexByKey; k < (int)indexByKey2; k++)
		{
			this.tmpEQ = this.DM.EquipTable.GetRecordByIndex((int)((ushort)k));
			switch (this.tmpEQ.EquipKind)
			{
			case 21:
				this.tmplistHead.Add((ushort)k);
				break;
			case 22:
				this.tmplistBody.Add((ushort)k);
				break;
			case 23:
				this.tmplistshoe.Add((ushort)k);
				break;
			case 24:
				this.tmplistArms.Add((ushort)k);
				break;
			case 25:
				this.tmplistSecondArms.Add((ushort)k);
				break;
			case 26:
				this.tmplistAccessories.Add((ushort)k);
				break;
			}
		}
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.GameT = base.gameObject.transform;
		this.m_Mat = this.door.LoadMaterial();
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.Tmp = this.GameT.GetChild(0).GetChild(0).GetChild(0);
		this.text_tmpStr[0] = this.Tmp.GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7402u);
		this.Tmp = this.GameT.GetChild(1);
		this.BG = this.Tmp.GetComponent<Image>();
		this.Tmp = this.GameT.GetChild(1).GetChild(0);
		this.text_Select = this.Tmp.GetComponent<UIText>();
		this.text_Select.font = this.TTFont;
		this.text_Select.text = this.DM.mStringTable.GetStringByID(7405u);
		this.Tmp = this.GameT.GetChild(2);
		Transform child = this.Tmp.GetChild(0).GetChild(0);
		this.text_tmpStr[1] = child.GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(7406u);
		child = this.Tmp.GetChild(1).GetChild(0);
		this.text_tmpStr[2] = child.GetComponent<UIText>();
		this.text_tmpStr[2].font = this.TTFont;
		this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(7407u);
		child = this.Tmp.GetChild(2).GetChild(0);
		this.text_tmpStr[3] = child.GetComponent<UIText>();
		this.text_tmpStr[3].font = this.TTFont;
		this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(7408u);
		for (int l = 0; l < 6; l++)
		{
			child = this.Tmp.GetChild(3 + l);
			this.btn_Equip[l] = child.GetComponent<UIButton>();
			this.btn_Equip[l].m_Handler = this;
			this.btn_Equip[l].m_BtnID1 = 1 + l;
			this.btn_Equip[l].m_EffectType = e_EffectType.e_Scale;
			this.btn_Equip[l].transition = Selectable.Transition.None;
		}
		for (int m = 0; m < 6; m++)
		{
			child = this.Tmp.GetChild(9 + m);
			this.btn_RC[m] = child.GetComponent<RectTransform>();
			this.btn_Color[m] = child.GetComponent<UIButton>();
			this.btn_Color[m].m_Handler = this;
			this.btn_Color[m].m_BtnID1 = 7 + m;
			this.btn_Color[m].m_EffectType = e_EffectType.e_Scale;
			this.btn_Color[m].transition = Selectable.Transition.None;
			this.Img_RC[m] = child.GetChild(0).GetComponent<RectTransform>();
		}
		this.SelectEquipT = this.Tmp.GetChild(3).GetChild(0);
		this.Img_SelectEquip = this.Tmp.GetChild(3).GetChild(0).GetComponent<Image>();
		this.SelectColorT = this.Tmp.GetChild(9).GetChild(1);
		this.Img_SelectColor = this.Tmp.GetChild(9).GetChild(1).GetComponent<Image>();
		if (this.DM.mLordEquip != null && this.DM.mLordEquip.IsCheckTechLevel())
		{
			this.mColor = 5;
			for (int n = 0; n < 5; n++)
			{
				this.btn_RC[n].sizeDelta = new Vector2(51f, 51f);
				this.btn_RC[n].anchoredPosition = new Vector2(this.btn_RC[n].anchoredPosition.x - 10f - (float)(6 * n), this.btn_RC[n].anchoredPosition.y);
				this.Img_RC[n].sizeDelta = new Vector2(51f, 51f);
			}
			this.Img_SelectColor.rectTransform.sizeDelta = new Vector2(64f, 64f);
			this.btn_Color[5].gameObject.SetActive(true);
		}
		child = this.Tmp.GetChild(15);
		this.btn_LvFilter = child.GetComponent<UIButton>();
		this.btn_LvFilter.m_Handler = this;
		this.btn_LvFilter.m_BtnID1 = 13;
		child = this.Tmp.GetChild(15).GetChild(0);
		this.Img_Yes = child.GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.Img_Yes.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		child = this.Tmp.GetChild(15).GetChild(1);
		this.text_tmpStr[4] = child.GetComponent<UIText>();
		this.text_tmpStr[4].font = this.TTFont;
		this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(7409u);
		child = this.Tmp.GetChild(16);
		this.btn_Filter = child.GetComponent<UIButton>();
		this.btn_Filter.m_Handler = this;
		this.btn_Filter.m_BtnID1 = 14;
		child = this.Tmp.GetChild(16).GetChild(2);
		this.text_Filter[0] = child.GetComponent<UIText>();
		this.text_Filter[0].font = this.TTFont;
		this.text_Filter[0].text = this.DM.mStringTable.GetStringByID(7427u);
		child = this.Tmp.GetChild(16).GetChild(3);
		this.text_Filter[1] = child.GetComponent<UIText>();
		this.text_Filter[1].font = this.TTFont;
		this.text_Filter[1].text = this.DM.mStringTable.GetStringByID(7464u);
		child = this.Tmp.GetChild(17);
		UIButton component = child.GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 14;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		this.Tmp = this.GameT.GetChild(3);
		this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
		this.Tmp = this.GameT.GetChild(4);
		child = this.Tmp.GetChild(2);
		this.tmpLebtn = child.GetComponent<UILEBtn>();
		this.tmpLebtn.m_Handler = this;
		this.GUIM.InitLordEquipImg(this.tmpLebtn.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		this.tmpLebtn.transition = Selectable.Transition.None;
		child = this.Tmp.GetChild(3).GetChild(5);
		this.tmpImg = child.GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.tmpImg.gameObject.AddComponent<ArabicItemTextureRot>();
		}
		child = this.Tmp.GetChild(3).GetChild(6);
		UIText component2 = child.GetComponent<UIText>();
		component2.font = this.TTFont;
		child = this.Tmp.GetChild(3).GetChild(7);
		component2 = child.GetComponent<UIText>();
		component2.font = this.TTFont;
		child = this.Tmp.GetChild(3).GetChild(8);
		component2 = child.GetComponent<UIText>();
		component2.font = this.TTFont;
		child = this.Tmp.GetChild(4);
		component = child.GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 15;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		child = this.Tmp.GetChild(4).GetChild(0);
		component2 = child.GetComponent<UIText>();
		component2.font = this.TTFont;
		component2.text = this.DM.mStringTable.GetStringByID(7410u);
		for (int num = 0; num < 6; num++)
		{
			child = this.Tmp.GetChild(6 + num).GetChild(0);
			component2 = child.GetComponent<UIText>();
			component2.font = this.TTFont;
			child = this.Tmp.GetChild(6 + num).GetChild(1);
			component2 = child.GetComponent<UIText>();
			component2.font = this.TTFont;
		}
		this.tmplist.Clear();
		for (int num2 = 0; num2 < 6; num2++)
		{
			this.tmplist.Add(212f);
		}
		this.m_ScrollPanel.IntiScrollPanel(490f, 11f, 0f, this.tmplist, 6, this);
		this.tmpImg = this.GameT.GetChild(5).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
		this.tmpImg.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(5).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.m_Mat;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		if (this.bEqDataReq && this.bMaterialDataReq)
		{
			this.CheckReOpen();
		}
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001B6B RID: 7019 RVA: 0x0030A644 File Offset: 0x00308844
	public void CheckReOpen()
	{
		if (this.DM.mLordEquip != null && this.DM.mLordEquip.ForgeItem_mEquip != 0)
		{
			UIEffectFilter.SeletedFilter = this.DM.mLordEquip.ForgeItem_mSeletedFilter;
			if (UIEffectFilter.SeletedFilter != 0)
			{
				this.mFilterSelect = UIEffectFilter.SeletedFilter;
				this.mFilterSelectEffectID = this.DM.LordEquipEffectFilter.GetRecordByIndex((int)(this.mFilterSelect - 1)).effectID;
				this.Cstr_Filter.ClearString();
				GameConstants.GetEffectValue(this.Cstr_Filter, this.mFilterSelectEffectID, 0u, 8, 0f);
				this.text_Filter[0].text = this.Cstr_Filter.ToString();
				this.text_Filter[0].SetAllDirty();
				this.text_Filter[0].cachedTextGenerator.Invalidate();
				this.text_Filter[0].color = Color.green;
				this.text_Filter[1].gameObject.SetActive(true);
			}
			this.bLvFilter = this.DM.mLordEquip.ForgeItem_bLvFilter;
			this.Img_Yes.gameObject.SetActive(this.bLvFilter);
			this.mEquip = this.DM.mLordEquip.ForgeItem_mEquip - 1;
			this.mColor = this.DM.mLordEquip.ForgeItem_mColor;
			this.SelectEquipT.gameObject.SetActive(true);
			this.SelectColorT.gameObject.SetActive(true);
			this.ShowTimeSelectEquip = 0f;
			this.ShowTimeSelectColor = 0f;
			this.SelectColorT.SetParent(this.btn_Color[(int)this.mColor].transform, false);
			this.SelectEquipT.SetParent(this.btn_Equip[(int)this.mEquip].transform, false);
			this.SetEquipList(this.mEquip);
			this.m_ScrollPanel.GoTo(this.DM.mLordEquip.ForgeItem_ScrollIdx);
		}
	}

	// Token: 0x06001B6C RID: 7020 RVA: 0x0030A83C File Offset: 0x00308A3C
	public void SetEquipList(byte Equip)
	{
		this.tmplist.Clear();
		this.tmplistData.Clear();
		switch (this.mEquip)
		{
		case 0:
			for (int i = 0; i < this.tmplistHead.Count; i++)
			{
				this.ItemListFilter(this.tmplistHead[i]);
			}
			break;
		case 1:
			for (int j = 0; j < this.tmplistBody.Count; j++)
			{
				this.ItemListFilter(this.tmplistBody[j]);
			}
			break;
		case 2:
			for (int k = 0; k < this.tmplistshoe.Count; k++)
			{
				this.ItemListFilter(this.tmplistshoe[k]);
			}
			break;
		case 3:
			for (int l = 0; l < this.tmplistArms.Count; l++)
			{
				this.ItemListFilter(this.tmplistArms[l]);
			}
			break;
		case 4:
			for (int m = 0; m < this.tmplistSecondArms.Count; m++)
			{
				this.ItemListFilter(this.tmplistSecondArms[m]);
			}
			break;
		case 5:
			for (int n = 0; n < this.tmplistAccessories.Count; n++)
			{
				this.ItemListFilter(this.tmplistAccessories[n]);
			}
			break;
		}
		if (this.tmplistData.Count > 0)
		{
			this.mSortItem.SortType = 0;
			this.mSortItem.SortLv = ((!this.bLvFilter) ? 1 : 0);
			this.mSortItem.SortColor = this.mColor;
			this.tmplistData.Sort(this.mSortItem);
			for (int num = 0; num < this.tmplistData.Count; num++)
			{
				this.SetListHeight(this.tmplistData[num]);
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, true, true);
			this.m_ScrollPanel.gameObject.SetActive(true);
			this.BG.gameObject.SetActive(false);
		}
		else
		{
			this.m_ScrollPanel.gameObject.SetActive(false);
			this.BG.gameObject.SetActive(true);
			this.text_Select.text = this.DM.mStringTable.GetStringByID(7495u);
		}
	}

	// Token: 0x06001B6D RID: 7021 RVA: 0x0030AAD4 File Offset: 0x00308CD4
	public bool CheckEquipOpen(MallEquipmant tmpME)
	{
		bool result = false;
		int hour = GameConstants.GetDateTime(this.DM.ServerTime).ToUniversalTime().Hour;
		int num = 0;
		if (hour - 5 < 0)
		{
			num = -1;
		}
		int num2 = (int)(tmpME.EquipData[1] * 30 + tmpME.EquipData[2]);
		int num3 = GameConstants.GetDateTime(this.DM.ServerTime).ToUniversalTime().Month * 30 + GameConstants.GetDateTime(this.DM.ServerTime).ToUniversalTime().Day + num;
		if (((int)tmpME.EquipData[0] == GameConstants.GetDateTime(this.DM.ServerTime).ToUniversalTime().Year - 2000 && num2 <= num3) || (int)tmpME.EquipData[0] < GameConstants.GetDateTime(this.DM.ServerTime).ToUniversalTime().Year - 2000)
		{
			result = true;
		}
		return result;
	}

	// Token: 0x06001B6E RID: 7022 RVA: 0x0030ABF0 File Offset: 0x00308DF0
	public void ItemListFilter(ushort Idx)
	{
		bool flag = false;
		this.tmpEQ = this.DM.EquipTable.GetRecordByIndex((int)Idx);
		bool flag2 = false;
		if (this.tmpEQ.ActivitySuitIndex > 0)
		{
			MallEquipmant recordByKey = this.DM.MallEquipmantTable.GetRecordByKey((ushort)this.tmpEQ.ActivitySuitIndex);
			if (!this.CheckEquipOpen(recordByKey))
			{
				return;
			}
			recordByKey = this.DM.MallEquipmantTable.GetRecordByKey((ushort)this.tmpEQ.ActivitySuitIndex);
			for (int i = 0; i < 10; i++)
			{
				if (recordByKey.ItemId[i] == this.tmpEQ.EquipKey)
				{
					flag2 = true;
					break;
				}
			}
			if (!flag2 && this.DM.ActivityEquipListIdx.Count > 0)
			{
				for (int j = 0; j < this.DM.ActivityEquipListIdx.Count; j++)
				{
					if ((ushort)this.tmpEQ.ActivitySuitIndex == this.DM.ActivityEquipListIdx[j].Index)
					{
						MallEquipmant recordByKey2 = this.DM.MallEquipmantTable.GetRecordByKey(this.DM.ActivityEquipListIdx[j].Key);
						for (int k = 0; k < 10; k++)
						{
							if (this.tmpEQ.EquipKey == recordByKey2.ItemId[k])
							{
								flag2 = true;
								break;
							}
						}
					}
				}
			}
		}
		else
		{
			flag2 = true;
		}
		if (flag2)
		{
			for (int l = 0; l < 6; l++)
			{
				ushort propertieskey = this.tmpEQ.PropertiesInfo[l].Propertieskey;
				if (propertieskey != 0 && this.tmpEQ.ForgingExp != 0u)
				{
					this.tmpData1 = this.DM.LordEquipEffectTable.GetRecordByKey(propertieskey);
					this.tmpData2 = this.DM.LordEquipEffectFilter.GetRecordByIndex((int)(this.mFilterSelect - 1));
					if (!flag && (this.mFilterSelect == 0 || (this.mFilterSelect > 0 && this.tmpData1.EffectID == this.tmpData2.effectID)))
					{
						flag = true;
					}
				}
			}
			if (flag)
			{
				this.tmplistData.Add(Idx);
			}
		}
	}

	// Token: 0x06001B6F RID: 7023 RVA: 0x0030AE4C File Offset: 0x0030904C
	public void SetListHeight(ushort Idx)
	{
		this.tmpEQ = this.DM.EquipTable.GetRecordByIndex((int)Idx);
		int num = 0;
		for (int i = 0; i < 6; i++)
		{
			ushort propertieskey = this.tmpEQ.PropertiesInfo[i].Propertieskey;
			if (propertieskey != 0)
			{
				num++;
			}
		}
		this.tmplist.Add((float)(98 + num * 24));
	}

	// Token: 0x06001B70 RID: 7024 RVA: 0x0030AEBC File Offset: 0x003090BC
	public void ChangSort()
	{
		this.tmplist.Clear();
		for (int i = 0; i < this.tmplistData.Count; i++)
		{
			this.tmpEQ = this.DM.EquipTable.GetRecordByIndex((int)this.tmplistData[i]);
			int num = 0;
			for (int j = 0; j < 6; j++)
			{
				if (this.tmpEQ.PropertiesInfo[j].Propertieskey != 0)
				{
					num++;
				}
			}
			this.tmplist.Add((float)(98 + num * 24));
		}
	}

	// Token: 0x06001B71 RID: 7025 RVA: 0x0030AF5C File Offset: 0x0030915C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.tmpItem[panelObjectIdx] == null)
		{
			this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			this.ItemBG_RC[panelObjectIdx] = item.transform.GetChild(0).GetComponent<RectTransform>();
			this.ItemLine_RC[panelObjectIdx] = item.transform.GetChild(6).GetComponent<RectTransform>();
			this.tmp_ItemLebtn[panelObjectIdx] = item.transform.GetChild(2).GetComponent<UILEBtn>();
			this.tmpImg_ItemEnough[panelObjectIdx] = item.transform.GetChild(3).GetChild(5).GetComponent<Image>();
			this.btn_ForgingEquip[panelObjectIdx] = item.transform.GetChild(4).GetComponent<UIButton>();
			this.btn_ForgingEquip[panelObjectIdx].m_Handler = this;
			this.text_Itembtn[panelObjectIdx] = item.transform.GetChild(4).GetChild(0).GetComponent<UIText>();
			this.text_ItemName[panelObjectIdx] = item.transform.GetChild(3).GetChild(6).GetComponent<UIText>();
			this.text_ItemLv[panelObjectIdx] = item.transform.GetChild(3).GetChild(7).GetComponent<UIText>();
			this.tmpImg_ItemIcon[panelObjectIdx] = item.transform.GetChild(3).GetChild(0).GetComponent<Image>();
			for (int i = 0; i < 4; i++)
			{
				this.tmpImg_Items[panelObjectIdx][i] = item.transform.GetChild(3).GetChild(1 + i).GetComponent<Image>();
			}
			for (int j = 0; j < 6; j++)
			{
				this.text_ItemEffect[panelObjectIdx][j] = item.transform.GetChild(6 + j).GetChild(0).GetComponent<UIText>();
				this.text_ItemEffect_V[panelObjectIdx][j] = item.transform.GetChild(6 + j).GetChild(1).GetComponent<UIText>();
			}
		}
		if (this.tmplistData.Count > dataIdx)
		{
			this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
			this.tmpEQ = this.DM.EquipTable.GetRecordByIndex((int)this.tmplistData[dataIdx]);
			this.GUIM.ChangeLordEquipImg(this.tmp_ItemLebtn[panelObjectIdx].transform, this.tmpEQ.EquipKey, this.mColor + 1, eLordEquipDisplayKind.OnlyItem, 0, 0, 0, 0, 0, false);
			this.Cstr_ItemName[panelObjectIdx].ClearString();
			GameConstants.GetColoredLordEquipString(this.Cstr_ItemName[panelObjectIdx], this.tmpEQ.EquipKey, this.mColor + 1);
			this.text_ItemName[panelObjectIdx].text = this.Cstr_ItemName[panelObjectIdx].ToString();
			this.text_ItemName[panelObjectIdx].SetAllDirty();
			this.text_ItemName[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.Cstr_ItemLv[panelObjectIdx].ClearString();
			if (this.tmpEQ.NeedLv <= this.DM.RoleAttr.Level)
			{
				this.Cstr_ItemLv[panelObjectIdx].IntToFormat((long)this.tmpEQ.NeedLv, 1, true);
			}
			else
			{
				CString cstring = StringManager.Instance.StaticString1024();
				cstring.ClearString();
				cstring.IntToFormat((long)this.tmpEQ.NeedLv, 1, true);
				cstring.AppendFormat("<color=#FF5581FF>{0}</color>");
				this.Cstr_ItemLv[panelObjectIdx].StringToFormat(cstring);
			}
			this.Cstr_ItemLv[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)((ushort)(7431 + (int)this.mEquip))));
			this.Cstr_ItemLv[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7437u));
			this.text_ItemLv[panelObjectIdx].text = this.Cstr_ItemLv[panelObjectIdx].ToString();
			this.text_ItemLv[panelObjectIdx].SetAllDirty();
			this.text_ItemLv[panelObjectIdx].cachedTextGenerator.Invalidate();
			this.effectList.Clear();
			LordEquipData.GetEffectList(this.tmpEQ.EquipKey, this.mColor + 1, this.effectList);
			for (int k = 0; k < this.effectList.Count; k++)
			{
				this.Cstr_Effect[panelObjectIdx][k].ClearString();
				GameConstants.GetEffectValue(this.Cstr_Effect[panelObjectIdx][k], this.effectList[k].EffectID, 0u, 8, 0f);
				this.text_ItemEffect[panelObjectIdx][k].text = this.Cstr_Effect[panelObjectIdx][k].ToString();
				this.text_ItemEffect[panelObjectIdx][k].SetAllDirty();
				this.text_ItemEffect[panelObjectIdx][k].cachedTextGenerator.Invalidate();
				if (this.mFilterSelect != 0 && this.mFilterSelectEffectID == this.effectList[k].EffectID)
				{
					this.text_ItemEffect[panelObjectIdx][k].color = Color.green;
				}
				else
				{
					this.text_ItemEffect[panelObjectIdx][k].color = this.mChangColor;
				}
				this.Cstr_Effect_V[panelObjectIdx][k].ClearString();
				GameConstants.GetEffectValue(this.Cstr_Effect_V[panelObjectIdx][k], this.effectList[k].EffectID, (uint)this.effectList[k].EffectValue, 3, 0f);
				this.text_ItemEffect_V[panelObjectIdx][k].text = this.Cstr_Effect_V[panelObjectIdx][k].ToString();
				this.text_ItemEffect_V[panelObjectIdx][k].SetAllDirty();
				this.text_ItemEffect_V[panelObjectIdx][k].cachedTextGenerator.Invalidate();
			}
			int count = this.effectList.Count;
			for (int l = 0; l < count; l++)
			{
				item.transform.GetChild(6 + l).gameObject.SetActive(true);
			}
			for (int m = count; m < 6; m++)
			{
				item.transform.GetChild(6 + m).gameObject.SetActive(false);
			}
			this.ItemBG_RC[panelObjectIdx].sizeDelta = new Vector2(this.ItemBG_RC[panelObjectIdx].sizeDelta.x, (float)(92 + count * 24));
			this.ItemLine_RC[panelObjectIdx].sizeDelta = new Vector2(this.ItemLine_RC[panelObjectIdx].sizeDelta.x, (float)(17 + (count - 1) * 24));
			this.tmpCount = 0;
			this.tmpEnoughCount = 0;
			this.bShowMainEquip = false;
			this.tmpImg_ItemIcon[panelObjectIdx].gameObject.SetActive(false);
			if (this.mColor >= 1)
			{
				if (LordEquipData.getItemQuantity(this.tmpEQ.EquipKey, this.mColor) > 0)
				{
					this.tmpImg_ItemIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[(int)(this.mEquip * 2)];
					this.bShowMainEquip = true;
				}
				else
				{
					this.tmpImg_ItemIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[(int)(this.mEquip * 2 + 1)];
				}
			}
			for (int n = 0; n < 4; n++)
			{
				this.DM.mLordEquip.GetMaterialEnough(ref this.tmpCount, ref this.tmpEnoughCount, this.mColor, n, this.tmpEQ);
				if (n > 0)
				{
					this.tmpImg_Items[panelObjectIdx][n].rectTransform.anchoredPosition = new Vector2(this.tmpImg_Items[panelObjectIdx][n - 1].rectTransform.anchoredPosition.x + 40f, this.tmpImg_Items[panelObjectIdx][n].rectTransform.anchoredPosition.y);
				}
			}
			bool flag = false;
			if (((this.mColor >= 1 && this.bShowMainEquip) || this.mColor == 0) && this.tmpCount > 0 && this.tmpCount == this.tmpEnoughCount)
			{
				this.tmpImg_ItemEnough[panelObjectIdx].gameObject.SetActive(true);
				flag = true;
				this.tmpCount = 0;
			}
			else
			{
				this.tmpImg_ItemEnough[panelObjectIdx].gameObject.SetActive(false);
				if (this.mColor >= 1)
				{
					this.tmpImg_ItemIcon[panelObjectIdx].gameObject.SetActive(true);
				}
			}
			if (!flag)
			{
				for (int num = 0; num < (int)this.tmpCount; num++)
				{
					this.tmpImg_Items[panelObjectIdx][num].gameObject.SetActive(true);
					if ((int)this.tmpEnoughCount > num)
					{
						this.tmpImg_Items[panelObjectIdx][num].sprite = this.SArray.m_Sprites[13];
					}
					else
					{
						this.tmpImg_Items[panelObjectIdx][num].sprite = this.SArray.m_Sprites[12];
					}
				}
			}
			for (int num2 = (int)this.tmpCount; num2 < 4; num2++)
			{
				this.tmpImg_Items[panelObjectIdx][num2].gameObject.SetActive(false);
				this.tmpImg_Items[panelObjectIdx][num2].sprite = this.SArray.m_Sprites[12];
			}
		}
	}

	// Token: 0x06001B72 RID: 7026 RVA: 0x0030B830 File Offset: 0x00309A30
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001B73 RID: 7027 RVA: 0x0030B834 File Offset: 0x00309A34
	public override void OnClose()
	{
		for (int i = 0; i < 6; i++)
		{
			if (this.Cstr_ItemLv[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemLv[i]);
			}
			if (this.Cstr_ItemName[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.Cstr_ItemName[i]);
			}
			for (int j = 0; j < 6; j++)
			{
				if (this.Cstr_Effect[i][j] != null)
				{
					StringManager.Instance.DeSpawnString(this.Cstr_Effect[i][j]);
				}
				if (this.Cstr_Effect_V[i][j] != null)
				{
					StringManager.Instance.DeSpawnString(this.Cstr_Effect_V[i][j]);
				}
			}
		}
		if (this.Cstr_Filter != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_Filter);
		}
		UIEffectFilter.SeletedFilter = 0;
		if (this.mEquip != 255)
		{
			this.DM.mLordEquip.ForgeItem_bLvFilter = this.bLvFilter;
			this.DM.mLordEquip.ForgeItem_mEquip = this.mEquip + 1;
			this.DM.mLordEquip.ForgeItem_mColor = this.mColor;
			this.DM.mLordEquip.ForgeItem_mSeletedFilter = this.mFilterSelect;
			this.DM.mLordEquip.ForgeItem_ScrollIdx = this.m_ScrollPanel.GetTopIdx();
		}
	}

	// Token: 0x06001B74 RID: 7028 RVA: 0x0030B998 File Offset: 0x00309B98
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
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		{
			byte b = (byte)(sender.m_BtnID1 - 1);
			if (b != this.mEquip)
			{
				this.mEquip = (byte)(sender.m_BtnID1 - 1);
				if (!this.SelectEquipT.gameObject.activeSelf)
				{
					this.SelectEquipT.gameObject.SetActive(true);
					this.SelectColorT.gameObject.SetActive(true);
					this.ShowTimeSelectEquip = 0f;
					this.ShowTimeSelectColor = 0f;
					this.SelectColorT.SetParent(this.btn_Color[(int)this.mColor].transform, false);
				}
				this.SelectEquipT.SetParent(this.btn_Equip[(int)this.mEquip].transform, false);
				this.SetEquipList(this.mEquip);
				this.DM.mLordEquip.ForgeItem_bLvFilter = this.bLvFilter;
				this.DM.mLordEquip.ForgeItem_mEquip = this.mEquip + 1;
				this.DM.mLordEquip.ForgeItem_mColor = this.mColor;
				this.DM.mLordEquip.ForgeItem_mSeletedFilter = this.mFilterSelect;
			}
			break;
		}
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 12:
			if (this.mEquip == 255)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(7493u), 255, true);
				return;
			}
			this.mColor = (byte)(sender.m_BtnID1 - 7);
			this.SelectColorT.SetParent(this.btn_Color[(int)this.mColor].transform, false);
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			this.DM.mLordEquip.ForgeItem_bLvFilter = this.bLvFilter;
			this.DM.mLordEquip.ForgeItem_mEquip = this.mEquip + 1;
			this.DM.mLordEquip.ForgeItem_mColor = this.mColor;
			this.DM.mLordEquip.ForgeItem_mSeletedFilter = this.mFilterSelect;
			break;
		case 13:
			if (this.mEquip == 255)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(7493u), 255, true);
				return;
			}
			this.bLvFilter = !this.bLvFilter;
			this.Img_Yes.gameObject.SetActive(this.bLvFilter);
			this.mSortItem.SortType = 0;
			this.mSortItem.SortLv = ((!this.bLvFilter) ? 1 : 0);
			this.mSortItem.SortColor = this.mColor;
			this.tmplistData.Sort(this.mSortItem);
			this.ChangSort();
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, true, true);
			this.DM.mLordEquip.ForgeItem_bLvFilter = this.bLvFilter;
			this.DM.mLordEquip.ForgeItem_mEquip = this.mEquip + 1;
			this.DM.mLordEquip.ForgeItem_mColor = this.mColor;
			this.DM.mLordEquip.ForgeItem_mSeletedFilter = this.mFilterSelect;
			break;
		case 14:
			if (this.mEquip == 255)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(7493u), 255, true);
				return;
			}
			this.door.OpenMenu(EGUIWindow.UI_EffectFilter, 1, (int)this.mFilterSelect, false);
			break;
		case 15:
		{
			this.Tmp = sender.gameObject.transform.parent;
			int btnID = this.Tmp.GetComponent<ScrollPanelItem>().m_BtnID1;
			this.tmpEQ = this.DM.EquipTable.GetRecordByIndex((int)this.tmplistData[btnID]);
			UIAnvil.SetOpen(eUI_Anvil_OpenKind.ForgeNewItem, (int)this.tmpEQ.EquipKey, (int)(1 + this.mColor));
			break;
		}
		}
	}

	// Token: 0x06001B75 RID: 7029 RVA: 0x0030BDE4 File Offset: 0x00309FE4
	public void OnLEButtonClick(UILEBtn sender)
	{
	}

	// Token: 0x06001B76 RID: 7030 RVA: 0x0030BDE8 File Offset: 0x00309FE8
	public void ReSetList(int Idx)
	{
		this.tmplist.Clear();
	}

	// Token: 0x06001B77 RID: 7031 RVA: 0x0030BDF8 File Offset: 0x00309FF8
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
		else if (!this.DM.mLordEquip.LoadLordEquip(false))
		{
			this.bEqDataReq = true;
			if (!this.DM.mLordEquip.LoadLEMaterial(false))
			{
				this.bMaterialDataReq = true;
			}
			else if (this.bEqDataReq && this.bMaterialDataReq)
			{
				this.CheckReOpen();
			}
		}
	}

	// Token: 0x06001B78 RID: 7032 RVA: 0x0030BE88 File Offset: 0x0030A088
	public void Refresh_FontTexture()
	{
		if (this.text_Select != null && this.text_Select.enabled)
		{
			this.text_Select.enabled = false;
			this.text_Select.enabled = true;
		}
		for (int i = 0; i < 2; i++)
		{
			if (this.text_Filter[i] != null && this.text_Filter[i].enabled)
			{
				this.text_Filter[i].enabled = false;
				this.text_Filter[i].enabled = true;
			}
		}
		for (int j = 0; j < 5; j++)
		{
			if (this.text_tmpStr[j] != null && this.text_tmpStr[j].enabled)
			{
				this.text_tmpStr[j].enabled = false;
				this.text_tmpStr[j].enabled = true;
			}
		}
		for (int k = 0; k < 6; k++)
		{
			if (this.text_ItemName[k] != null && this.text_ItemName[k].enabled)
			{
				this.text_ItemName[k].enabled = false;
				this.text_ItemName[k].enabled = true;
			}
			if (this.text_ItemLv[k] != null && this.text_ItemLv[k].enabled)
			{
				this.text_ItemLv[k].enabled = false;
				this.text_ItemLv[k].enabled = true;
			}
			if (this.text_Itembtn[k] != null && this.text_Itembtn[k].enabled)
			{
				this.text_Itembtn[k].enabled = false;
				this.text_Itembtn[k].enabled = true;
			}
			for (int l = 0; l < 6; l++)
			{
				if (this.text_ItemEffect[k][l] != null && this.text_ItemEffect[k][l].enabled)
				{
					this.text_ItemEffect[k][l].enabled = false;
					this.text_ItemEffect[k][l].enabled = true;
				}
				if (this.text_ItemEffect_V[k][l] != null && this.text_ItemEffect_V[k][l].enabled)
				{
					this.text_ItemEffect_V[k][l].enabled = false;
					this.text_ItemEffect_V[k][l].enabled = true;
				}
			}
		}
	}

	// Token: 0x06001B79 RID: 7033 RVA: 0x0030C0F0 File Offset: 0x0030A2F0
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 != 1)
		{
			if (arg1 == 2)
			{
				if (!this.DM.mLordEquip.LoadLordEquip(false) && !this.DM.mLordEquip.LoadLEMaterial(false))
				{
					this.CheckReOpen();
				}
			}
		}
		else if (!this.bEqDataReq && !this.DM.mLordEquip.LoadLordEquip(false))
		{
			this.bEqDataReq = true;
			if (!this.bMaterialDataReq && !this.DM.mLordEquip.LoadLEMaterial(false))
			{
				this.bMaterialDataReq = true;
			}
			if (this.bEqDataReq && this.bMaterialDataReq)
			{
				this.CheckReOpen();
			}
		}
	}

	// Token: 0x06001B7A RID: 7034 RVA: 0x0030C1BC File Offset: 0x0030A3BC
	private void Start()
	{
	}

	// Token: 0x06001B7B RID: 7035 RVA: 0x0030C1C0 File Offset: 0x0030A3C0
	private void Update()
	{
		if (this.SelectEquipT.gameObject.activeSelf)
		{
			this.ShowTimeSelectEquip += Time.smoothDeltaTime;
			if (this.ShowTimeSelectEquip >= 0f)
			{
				if (this.ShowTimeSelectEquip >= 2f)
				{
					this.ShowTimeSelectEquip = 0f;
				}
				float a = (this.ShowTimeSelectEquip <= 1f) ? this.ShowTimeSelectEquip : (2f - this.ShowTimeSelectEquip);
				this.Img_SelectEquip.color = new Color(1f, 1f, 1f, a);
			}
		}
		if (this.SelectColorT.gameObject.activeSelf)
		{
			this.ShowTimeSelectColor += Time.smoothDeltaTime;
			if (this.ShowTimeSelectColor >= 0f)
			{
				if (this.ShowTimeSelectColor >= 2f)
				{
					this.ShowTimeSelectColor = 0f;
				}
				float a2 = (this.ShowTimeSelectColor <= 1f) ? this.ShowTimeSelectColor : (2f - this.ShowTimeSelectColor);
				this.Img_SelectColor.color = new Color(1f, 1f, 1f, a2);
			}
		}
	}

	// Token: 0x040052E6 RID: 21222
	private DataManager DM;

	// Token: 0x040052E7 RID: 21223
	private GUIManager GUIM;

	// Token: 0x040052E8 RID: 21224
	private Transform GameT;

	// Token: 0x040052E9 RID: 21225
	private Transform Tmp;

	// Token: 0x040052EA RID: 21226
	private Transform SelectEquipT;

	// Token: 0x040052EB RID: 21227
	private Transform SelectColorT;

	// Token: 0x040052EC RID: 21228
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040052ED RID: 21229
	private RectTransform[] ItemBG_RC = new RectTransform[6];

	// Token: 0x040052EE RID: 21230
	private RectTransform[] ItemLine_RC = new RectTransform[6];

	// Token: 0x040052EF RID: 21231
	private RectTransform[] btn_RC = new RectTransform[6];

	// Token: 0x040052F0 RID: 21232
	private RectTransform[] Img_RC = new RectTransform[6];

	// Token: 0x040052F1 RID: 21233
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[6];

	// Token: 0x040052F2 RID: 21234
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x040052F3 RID: 21235
	private Door door;

	// Token: 0x040052F4 RID: 21236
	private UIButton btn_EXIT;

	// Token: 0x040052F5 RID: 21237
	private UIButton[] btn_Equip = new UIButton[6];

	// Token: 0x040052F6 RID: 21238
	private UIButton[] btn_Color = new UIButton[6];

	// Token: 0x040052F7 RID: 21239
	private UIButton[] btn_ForgingEquip = new UIButton[6];

	// Token: 0x040052F8 RID: 21240
	private UIButton btn_LvFilter;

	// Token: 0x040052F9 RID: 21241
	private UIButton btn_Filter;

	// Token: 0x040052FA RID: 21242
	private UILEBtn tmpLebtn;

	// Token: 0x040052FB RID: 21243
	private UILEBtn[] tmp_ItemLebtn = new UILEBtn[6];

	// Token: 0x040052FC RID: 21244
	private Image BG;

	// Token: 0x040052FD RID: 21245
	private Image Img_Yes;

	// Token: 0x040052FE RID: 21246
	private Image Img_SelectEquip;

	// Token: 0x040052FF RID: 21247
	private Image Img_SelectColor;

	// Token: 0x04005300 RID: 21248
	private Image tmpImg;

	// Token: 0x04005301 RID: 21249
	private Image[] tmpImg_ItemEnough = new Image[6];

	// Token: 0x04005302 RID: 21250
	private Image[] tmpImg_ItemIcon = new Image[6];

	// Token: 0x04005303 RID: 21251
	private Image[][] tmpImg_Items = new Image[6][];

	// Token: 0x04005304 RID: 21252
	private UIText text_Select;

	// Token: 0x04005305 RID: 21253
	private UIText[] text_tmpStr = new UIText[5];

	// Token: 0x04005306 RID: 21254
	private UIText[] text_Filter = new UIText[2];

	// Token: 0x04005307 RID: 21255
	private UIText[] text_ItemName = new UIText[6];

	// Token: 0x04005308 RID: 21256
	private UIText[] text_ItemLv = new UIText[6];

	// Token: 0x04005309 RID: 21257
	private UIText[] text_Itembtn = new UIText[6];

	// Token: 0x0400530A RID: 21258
	private UIText[][] text_ItemEffect = new UIText[6][];

	// Token: 0x0400530B RID: 21259
	private UIText[][] text_ItemEffect_V = new UIText[6][];

	// Token: 0x0400530C RID: 21260
	private CString[][] Cstr_Effect = new CString[6][];

	// Token: 0x0400530D RID: 21261
	private CString[][] Cstr_Effect_V = new CString[6][];

	// Token: 0x0400530E RID: 21262
	private CString[] Cstr_ItemLv = new CString[6];

	// Token: 0x0400530F RID: 21263
	private CString[] Cstr_ItemName = new CString[6];

	// Token: 0x04005310 RID: 21264
	private CString Cstr_Filter;

	// Token: 0x04005311 RID: 21265
	private Material m_Mat;

	// Token: 0x04005312 RID: 21266
	private List<float> tmplist = new List<float>();

	// Token: 0x04005313 RID: 21267
	public List<ushort> tmplistData = new List<ushort>();

	// Token: 0x04005314 RID: 21268
	private List<ushort> tmplistHead = new List<ushort>();

	// Token: 0x04005315 RID: 21269
	private List<ushort> tmplistBody = new List<ushort>();

	// Token: 0x04005316 RID: 21270
	private List<ushort> tmplistshoe = new List<ushort>();

	// Token: 0x04005317 RID: 21271
	private List<ushort> tmplistArms = new List<ushort>();

	// Token: 0x04005318 RID: 21272
	private List<ushort> tmplistSecondArms = new List<ushort>();

	// Token: 0x04005319 RID: 21273
	private List<ushort> tmplistAccessories = new List<ushort>();

	// Token: 0x0400531A RID: 21274
	private List<LordEquipEffectSet> effectList = new List<LordEquipEffectSet>();

	// Token: 0x0400531B RID: 21275
	public SortItemComparer mSortItem = new SortItemComparer();

	// Token: 0x0400531C RID: 21276
	private bool bLvFilter = true;

	// Token: 0x0400531D RID: 21277
	private byte mEquip = byte.MaxValue;

	// Token: 0x0400531E RID: 21278
	public byte mColor = 4;

	// Token: 0x0400531F RID: 21279
	private ushort mFilterSelect;

	// Token: 0x04005320 RID: 21280
	private ushort mFilterSelectEffectID;

	// Token: 0x04005321 RID: 21281
	private bool bEqDataReq;

	// Token: 0x04005322 RID: 21282
	private bool bMaterialDataReq;

	// Token: 0x04005323 RID: 21283
	private float ShowTimeSelectEquip;

	// Token: 0x04005324 RID: 21284
	private float ShowTimeSelectColor;

	// Token: 0x04005325 RID: 21285
	private Equip tmpEQ;

	// Token: 0x04005326 RID: 21286
	private Color mChangColor = new Color(0.9137f, 0.8117f, 0.6549f);

	// Token: 0x04005327 RID: 21287
	private UISpritesArray SArray;

	// Token: 0x04005328 RID: 21288
	private byte tmpCount;

	// Token: 0x04005329 RID: 21289
	private byte tmpEnoughCount;

	// Token: 0x0400532A RID: 21290
	private bool bShowMainEquip;

	// Token: 0x0400532B RID: 21291
	private LordEquipEffectData tmpData1;

	// Token: 0x0400532C RID: 21292
	private LordEquipEffectFilterData tmpData2;
}
