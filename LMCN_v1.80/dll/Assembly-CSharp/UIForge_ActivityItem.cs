using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000559 RID: 1369
public class UIForge_ActivityItem : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUILEBtnClickHandler
{
	// Token: 0x06001B58 RID: 7000 RVA: 0x00306DF8 File Offset: 0x00304FF8
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
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.GameT = base.gameObject.transform;
		this.SArray = this.GameT.GetComponent<UISpritesArray>();
		this.m_Mat = this.door.LoadMaterial();
		this.tmplistEquip.Clear();
		this.TableCount = this.DM.ActivitylistEquip.Count;
		for (int k = 0; k < this.TableCount; k++)
		{
			this.tmplistEquip.Add(this.DM.ActivitylistEquip[k]);
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.Append("UI/UI_forge_equip_pop");
		this.mAB = AssetManager.GetAssetBundle(cstring, out this.mABeKey);
		if (this.mAB != null)
		{
			this.m_ListMat = (this.mAB.Load("UI_forge_equip_pop_m", typeof(Material)) as Material);
			UnityEngine.Object[] array = this.mAB.LoadAll(typeof(Sprite));
			for (int l = 0; l < this.TableCount; l++)
			{
				cstring.ClearString();
				this.tmpME = this.DM.MallEquipmantTable.GetRecordByKey(this.tmplistEquip[l]);
				cstring.IntToFormat((long)this.tmpME.EquipIcon, 3, false);
				cstring.AppendFormat("UI_fc_sbut_{0}");
				for (int m = 0; m < array.Length; m++)
				{
					if (DataManager.CompareStr(array[m].name, cstring) == 0)
					{
						this.tmpSpritelist.Add((Sprite)array[m]);
					}
				}
			}
		}
		this.Tmp = this.GameT.GetChild(0).GetChild(0).GetChild(0);
		this.text_tmpStr[0] = this.Tmp.GetComponent<UIText>();
		this.text_tmpStr[0].font = this.TTFont;
		this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7403u);
		this.Tmp = this.GameT.GetChild(1);
		this.BG = this.Tmp.GetComponent<Image>();
		this.Tmp = this.GameT.GetChild(1).GetChild(0);
		this.text_Select = this.Tmp.GetComponent<UIText>();
		this.text_Select.font = this.TTFont;
		this.text_Select.text = this.DM.mStringTable.GetStringByID(7428u);
		this.Tmp = this.GameT.GetChild(2);
		Transform child;
		for (int n = 0; n < 6; n++)
		{
			child = this.Tmp.GetChild(2 + n);
			this.btn_RC[n] = child.GetComponent<RectTransform>();
			this.btn_Color[n] = child.GetComponent<UIButton>();
			this.btn_Color[n].m_Handler = this;
			this.btn_Color[n].m_BtnID1 = 1 + n;
			this.btn_Color[n].m_EffectType = e_EffectType.e_Scale;
			this.btn_Color[n].transition = Selectable.Transition.None;
			this.Img_RC[n] = child.GetChild(0).GetComponent<RectTransform>();
		}
		this.SelectColorT = this.Tmp.GetChild(2).GetChild(1);
		this.Img_SelectColor = this.Tmp.GetChild(2).GetChild(1).GetComponent<Image>();
		if (this.DM.mLordEquip != null && this.DM.mLordEquip.IsCheckTechLevel())
		{
			this.mColor = 5;
			for (int num = 0; num < 5; num++)
			{
				this.btn_RC[num].sizeDelta = new Vector2(51f, 51f);
				this.btn_RC[num].anchoredPosition = new Vector2(this.btn_RC[num].anchoredPosition.x - 10f - (float)(6 * num), this.btn_RC[num].anchoredPosition.y);
				this.Img_RC[num].sizeDelta = new Vector2(51f, 51f);
			}
			this.Img_SelectColor.rectTransform.sizeDelta = new Vector2(64f, 64f);
			this.btn_Color[5].gameObject.SetActive(true);
		}
		child = this.Tmp.GetChild(0).GetChild(0);
		this.text_tmpStr[1] = child.GetComponent<UIText>();
		this.text_tmpStr[1].font = this.TTFont;
		this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(7407u);
		this.Tmp = this.Tmp.GetChild(1).GetChild(0);
		this.text_tmpStr[2] = this.Tmp.GetComponent<UIText>();
		this.text_tmpStr[2].font = this.TTFont;
		this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(7429u);
		this.Tmp = this.GameT.GetChild(3).GetChild(0);
		this.m_ScrollPanel_Activity = this.Tmp.GetComponent<ScrollPanel>();
		this.m_ScrollPanel_Activity.m_ScrollPanelID = 1;
		this.Tmp = this.GameT.GetChild(3).GetChild(1).GetChild(0);
		UIButton component = this.Tmp.GetComponent<UIButton>();
		component.m_BtnID1 = 8;
		this.tmpImg = this.GameT.GetChild(3).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();
		if (this.m_AssetBundleKey != 0 && this.m_ListMat != null)
		{
			this.tmpImg.material = this.m_ListMat;
		}
		this.Tmp = this.GameT.GetChild(3).GetChild(1).GetChild(0).GetChild(0).GetChild(0);
		UIText component2 = this.Tmp.GetComponent<UIText>();
		component2.font = this.TTFont;
		for (int num2 = 0; num2 < this.TableCount; num2++)
		{
			this.tmplist_A.Add(79f);
		}
		this.m_ScrollPanel_Activity.IntiScrollPanel(363f, 0f, 0f, this.tmplist_A, 7, this);
		this.mContentRT = this.m_ScrollPanel_Activity.transform.GetChild(0).GetComponent<RectTransform>();
		this.Tmp = this.GameT.GetChild(4);
		this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
		this.m_ScrollPanel.m_ScrollPanelID = 2;
		this.Tmp = this.GameT.GetChild(5);
		child = this.Tmp.GetChild(2);
		this.tmpLebtn = child.GetComponent<UILEBtn>();
		this.tmpLebtn.m_Handler = this;
		this.GUIM.InitLordEquipImg(this.tmpLebtn.transform, 0, 0, eLordEquipDisplayKind.OnlyItem, false, true, 0, 0, 0, 0, 0, false);
		this.tmpLebtn.transition = Selectable.Transition.None;
		child = this.Tmp.GetChild(3).GetChild(5);
		component2 = child.GetComponent<UIText>();
		component2.font = this.TTFont;
		child = this.Tmp.GetChild(3).GetChild(6);
		component2 = child.GetComponent<UIText>();
		component2.font = this.TTFont;
		child = this.Tmp.GetChild(3).GetChild(7);
		component2 = child.GetComponent<UIText>();
		component2.font = this.TTFont;
		child = this.Tmp.GetChild(4);
		this.tmpImg = child.GetComponent<Image>();
		if (this.GUIM.IsArabic)
		{
			this.tmpImg.transform.localScale = new Vector3(-1f, this.tmpImg.transform.localScale.y, this.tmpImg.transform.localScale.z);
		}
		child = this.Tmp.GetChild(5);
		component = child.GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 7;
		component.m_EffectType = e_EffectType.e_Scale;
		component.transition = Selectable.Transition.None;
		child = this.Tmp.GetChild(5).GetChild(0);
		component2 = child.GetComponent<UIText>();
		component2.font = this.TTFont;
		component2.text = this.DM.mStringTable.GetStringByID(7410u);
		for (int num3 = 0; num3 < 6; num3++)
		{
			child = this.Tmp.GetChild(7 + num3).GetChild(0);
			component2 = child.GetComponent<UIText>();
			component2.font = this.TTFont;
			child = this.Tmp.GetChild(7 + num3).GetChild(1);
			component2 = child.GetComponent<UIText>();
			component2.font = this.TTFont;
		}
		this.tmplist.Clear();
		for (int num4 = 0; num4 < 6; num4++)
		{
			this.tmplist.Add(212f);
		}
		this.m_ScrollPanel.IntiScrollPanel(490f, 11f, 0f, this.tmplist, 6, this);
		this.tmpImg = this.GameT.GetChild(6).GetComponent<Image>();
		this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
		this.tmpImg.material = this.m_Mat;
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.tmpImg.enabled = false;
		}
		this.btn_EXIT = this.GameT.GetChild(6).GetChild(0).GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
		this.btn_EXIT.image.material = this.m_Mat;
		this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
		this.btn_EXIT.transition = Selectable.Transition.None;
		if (this.bEqDataReq && this.bMaterialDataReq)
		{
			this.CheckReOpen(false);
		}
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001B59 RID: 7001 RVA: 0x00307990 File Offset: 0x00305B90
	public void CheckReOpen(bool brelogin = false)
	{
		if (this.DM.mLordEquip != null && this.DM.mLordEquip.ForgeActivity_mKind != 0)
		{
			if ((int)this.DM.mLordEquip.ForgeActivity_mKind > this.tmplistEquip.Count)
			{
				return;
			}
			this.mActivityIdx = this.DM.mLordEquip.ForgeActivity_mKind;
			this.mColor = this.DM.mLordEquip.ForgeActivity_mColor;
			this.tmplist.Clear();
			this.tmplistData.Clear();
			this.mItemActivityIdx = (int)(this.mActivityIdx - 1);
			this.mItemActivityIdx2 = (int)((this.mActivityIdx - 1) % 7);
			this.tmpME = this.DM.MallEquipmantTable.GetRecordByKey(this.tmplistEquip[(int)(this.mActivityIdx - 1)]);
			for (int i = 0; i < 10; i++)
			{
				if (this.tmpME.ItemId[i] != 0)
				{
					this.tmplistData.Add(this.tmpME.ItemId[i]);
				}
			}
			if (this.DM.ActivityEquipListIdx.Count > 0)
			{
				for (int j = 0; j < this.DM.ActivityEquipListIdx.Count; j++)
				{
					MallEquipmant recordByKey = this.DM.MallEquipmantTable.GetRecordByKey(this.DM.ActivityEquipListIdx[j].Key);
					if (recordByKey.EquipIcon == this.tmpME.EquipIcon)
					{
						for (int k = 0; k < 10; k++)
						{
							if (recordByKey.ItemId[k] != 0)
							{
								this.tmplistData.Add(recordByKey.ItemId[k]);
							}
						}
					}
				}
			}
			this.SelectColorT.gameObject.SetActive(true);
			this.ShowTimeSelectColor = 0f;
			this.SelectColorT.SetParent(this.btn_Color[(int)this.mColor].transform, false);
			this.mSortItem.SortType = 1;
			this.mSortItem.SortColor = this.mColor;
			this.tmplistData.Sort(this.mSortItem);
			for (int l = 0; l < this.tmplistData.Count; l++)
			{
				this.SetListHeight(this.tmplistData[l]);
			}
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			this.m_ScrollPanel.gameObject.SetActive(true);
			this.BG.gameObject.SetActive(false);
			this.m_ScrollPanel.GoTo(this.DM.mLordEquip.ForgeActivity_ScrollIdx);
			if (!brelogin)
			{
				this.m_ScrollPanel_Activity.GoTo(this.DM.mLordEquip.ForgeActivity_KindScrollIdx, this.DM.mLordEquip.ForgeActivity_KindScroll_Y);
			}
		}
	}

	// Token: 0x06001B5A RID: 7002 RVA: 0x00307C74 File Offset: 0x00305E74
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelId == 1)
		{
			if (this.tmpItem_A[panelObjectIdx] == null)
			{
				this.tmpItem_A[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
				this.tmpItem_A[panelObjectIdx].m_BtnID2 = panelObjectIdx;
				this.btn_ActivityEquip[panelObjectIdx] = item.transform.GetChild(0).GetComponent<UIButton>();
				this.btn_ActivityEquip[panelObjectIdx].m_Handler = this;
				this.tmpImg_btn[panelObjectIdx] = item.transform.GetChild(0).GetChild(0).GetComponent<Image>();
				this.text_Item_A_Name[panelObjectIdx] = item.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
				this.tmpImgSelect_btn[panelObjectIdx] = item.transform.GetChild(0).GetChild(1).GetComponent<Image>();
			}
			if (this.tmpSpritelist.Count > dataIdx)
			{
				this.tmpImg_btn[panelObjectIdx].sprite = this.tmpSpritelist[dataIdx];
			}
			if (this.tmpImg_btn[panelObjectIdx].sprite == null)
			{
				this.tmpImg_btn[panelObjectIdx].color = new Color(1f, 1f, 1f, 0f);
			}
			else
			{
				this.tmpImg_btn[panelObjectIdx].color = new Color(1f, 1f, 1f, 1f);
			}
			this.tmpME = this.DM.MallEquipmantTable.GetRecordByKey(this.tmplistEquip[dataIdx]);
			this.text_Item_A_Name[panelObjectIdx].text = this.DM.mStringTable.GetStringByID((uint)this.tmpME.EquipName);
			if (this.mItemActivityIdx == dataIdx)
			{
				this.tmpImgSelect_btn[panelObjectIdx].gameObject.SetActive(true);
				this.ItemActivitySelect = 0f;
				this.mItemActivityIdx2 = panelObjectIdx;
			}
			else
			{
				this.tmpImgSelect_btn[panelObjectIdx].gameObject.SetActive(false);
				this.tmpImgSelect_btn[panelObjectIdx].color = new Color(1f, 1f, 1f, 0f);
			}
		}
		else
		{
			if (this.tmpItem[panelObjectIdx] == null)
			{
				this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
				this.ItemBG_RC[panelObjectIdx] = item.transform.GetChild(0).GetComponent<RectTransform>();
				this.ItemLine_RC[panelObjectIdx] = item.transform.GetChild(6).GetComponent<RectTransform>();
				this.tmp_ItemLebtn[panelObjectIdx] = item.transform.GetChild(2).GetComponent<UILEBtn>();
				this.tmpImg_ItemEnough[panelObjectIdx] = item.transform.GetChild(4).GetComponent<Image>();
				this.btn_ForgingEquip[panelObjectIdx] = item.transform.GetChild(5).GetComponent<UIButton>();
				this.btn_ForgingEquip[panelObjectIdx].m_Handler = this;
				this.text_Itembtn[panelObjectIdx] = item.transform.GetChild(5).GetChild(0).GetComponent<UIText>();
				this.text_ItemName[panelObjectIdx] = item.transform.GetChild(3).GetChild(5).GetComponent<UIText>();
				this.text_ItemLv[panelObjectIdx] = item.transform.GetChild(3).GetChild(6).GetComponent<UIText>();
				this.tmpImg_ItemIcon[panelObjectIdx] = item.transform.GetChild(3).GetChild(0).GetComponent<Image>();
				for (int i = 0; i < 4; i++)
				{
					this.tmpImg_Items[panelObjectIdx][i] = item.transform.GetChild(3).GetChild(1 + i).GetComponent<Image>();
				}
				for (int j = 0; j < 6; j++)
				{
					this.text_ItemEffect[panelObjectIdx][j] = item.transform.GetChild(7 + j).GetChild(0).GetComponent<UIText>();
					this.text_ItemEffect_V[panelObjectIdx][j] = item.transform.GetChild(7 + j).GetChild(1).GetComponent<UIText>();
				}
			}
			if (this.tmplistData.Count > dataIdx)
			{
				this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
				this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.tmplistData[dataIdx]);
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
				this.Cstr_ItemLv[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint)((ushort)(7410 + (int)this.tmpEQ.EquipKind))));
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
					this.Cstr_Effect_V[panelObjectIdx][k].ClearString();
					GameConstants.GetEffectValue(this.Cstr_Effect_V[panelObjectIdx][k], this.effectList[k].EffectID, (uint)this.effectList[k].EffectValue, 3, 0f);
					this.text_ItemEffect_V[panelObjectIdx][k].text = this.Cstr_Effect_V[panelObjectIdx][k].ToString();
					this.text_ItemEffect_V[panelObjectIdx][k].SetAllDirty();
					this.text_ItemEffect_V[panelObjectIdx][k].cachedTextGenerator.Invalidate();
				}
				int count = this.effectList.Count;
				for (int l = 0; l < count; l++)
				{
					item.transform.GetChild(7 + l).gameObject.SetActive(true);
				}
				for (int m = count; m < 6; m++)
				{
					item.transform.GetChild(7 + m).gameObject.SetActive(false);
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
						this.tmpImg_ItemIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[(int)((this.tmpEQ.EquipKind - 21) * 2)];
						this.bShowMainEquip = true;
					}
					else
					{
						this.tmpImg_ItemIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[(int)((this.tmpEQ.EquipKind - 21) * 2 + 1)];
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
	}

	// Token: 0x06001B5B RID: 7003 RVA: 0x00308714 File Offset: 0x00306914
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001B5C RID: 7004 RVA: 0x00308718 File Offset: 0x00306918
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
		if (this.mActivityIdx != 255)
		{
			this.DM.mLordEquip.ForgeActivity_mColor = this.mColor;
			this.DM.mLordEquip.ForgeActivity_mKind = this.mActivityIdx;
			this.DM.mLordEquip.ForgeActivity_ScrollIdx = this.m_ScrollPanel.GetTopIdx();
			if (this.DM.mLordEquip.ForgeActivity_ScrollIdx < 0)
			{
				this.DM.mLordEquip.ForgeActivity_ScrollIdx = 0;
			}
			this.DM.mLordEquip.ForgeActivity_KindScrollIdx = this.m_ScrollPanel_Activity.GetTopIdx();
			if (this.DM.mLordEquip.ForgeActivity_KindScrollIdx < 0)
			{
				this.DM.mLordEquip.ForgeActivity_KindScrollIdx = 0;
			}
			this.DM.mLordEquip.ForgeActivity_KindScroll_Y = this.mContentRT.anchoredPosition.y;
		}
		if (this.mABeKey != 0)
		{
			this.m_ListMat = null;
			this.tmpSpritelist.Clear();
			AssetManager.UnloadAssetBundle(this.mABeKey, true);
		}
	}

	// Token: 0x06001B5D RID: 7005 RVA: 0x003088E0 File Offset: 0x00306AE0
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
			if (this.mActivityIdx == 255)
			{
				this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(7508u), 255, true);
				return;
			}
			this.mColor = (byte)(sender.m_BtnID1 - 1);
			this.SelectColorT.SetParent(this.btn_Color[(int)this.mColor].transform, false);
			this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			this.DM.mLordEquip.ForgeActivity_mColor = this.mColor;
			this.DM.mLordEquip.ForgeActivity_mKind = this.mActivityIdx;
			break;
		case 7:
		{
			this.Tmp = sender.gameObject.transform.parent;
			int btnID = this.Tmp.GetComponent<ScrollPanelItem>().m_BtnID1;
			this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.tmplistData[btnID]);
			UIAnvil.SetOpen(eUI_Anvil_OpenKind.ForgeNewItem, (int)this.tmpEQ.EquipKey, (int)(1 + this.mColor));
			break;
		}
		case 8:
		{
			this.Tmp = sender.gameObject.transform.parent;
			int btnID2 = this.Tmp.GetComponent<ScrollPanelItem>().m_BtnID1;
			if (this.mItemActivityIdx != -1)
			{
				this.tmpImgSelect_btn[this.mItemActivityIdx2].gameObject.SetActive(false);
				this.tmpImgSelect_btn[this.mItemActivityIdx2].color = new Color(1f, 1f, 1f, 0f);
			}
			this.mItemActivityIdx = btnID2;
			this.mItemActivityIdx2 = this.Tmp.GetComponent<ScrollPanelItem>().m_BtnID2;
			this.tmpImgSelect_btn[this.mItemActivityIdx2].gameObject.SetActive(true);
			this.ItemActivitySelect = 0f;
			this.mActivityIdx = (byte)(btnID2 + 1);
			if (this.DM.mLordEquip.ForgeActivity_mKind != this.mActivityIdx)
			{
				this.tmplist.Clear();
				this.tmplistData.Clear();
				this.tmpME = this.DM.MallEquipmantTable.GetRecordByKey(this.tmplistEquip[btnID2]);
				for (int i = 0; i < 10; i++)
				{
					if (this.tmpME.ItemId[i] != 0)
					{
						this.tmplistData.Add(this.tmpME.ItemId[i]);
					}
				}
				if (this.DM.ActivityEquipListIdx.Count > 0)
				{
					for (int j = 0; j < this.DM.ActivityEquipListIdx.Count; j++)
					{
						MallEquipmant recordByKey = this.DM.MallEquipmantTable.GetRecordByKey(this.DM.ActivityEquipListIdx[j].Key);
						if (recordByKey.EquipIcon == this.tmpME.EquipIcon)
						{
							for (int k = 0; k < 10; k++)
							{
								if (recordByKey.ItemId[k] != 0)
								{
									this.tmplistData.Add(recordByKey.ItemId[k]);
								}
							}
						}
					}
				}
				this.SelectColorT.gameObject.SetActive(true);
				this.ShowTimeSelectColor = 0f;
				this.SelectColorT.SetParent(this.btn_Color[(int)this.mColor].transform, false);
				this.mSortItem.SortType = 1;
				this.mSortItem.SortColor = this.mColor;
				this.tmplistData.Sort(this.mSortItem);
				for (int l = 0; l < this.tmplistData.Count; l++)
				{
					this.SetListHeight(this.tmplistData[l]);
				}
				this.m_ScrollPanel.AddNewDataHeight(this.tmplist, true, true);
				this.m_ScrollPanel.gameObject.SetActive(true);
				this.BG.gameObject.SetActive(false);
				this.DM.mLordEquip.ForgeActivity_mColor = this.mColor;
				this.DM.mLordEquip.ForgeActivity_mKind = this.mActivityIdx;
			}
			break;
		}
		}
	}

	// Token: 0x06001B5E RID: 7006 RVA: 0x00308D60 File Offset: 0x00306F60
	public void SetListHeight(ushort Idx)
	{
		this.tmpEQ = this.DM.EquipTable.GetRecordByKey(Idx);
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

	// Token: 0x06001B5F RID: 7007 RVA: 0x00308DD0 File Offset: 0x00306FD0
	public void OnLEButtonClick(UILEBtn sender)
	{
	}

	// Token: 0x06001B60 RID: 7008 RVA: 0x00308DD4 File Offset: 0x00306FD4
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
			if (this.bEqDataReq && this.bMaterialDataReq)
			{
				this.CheckReOpen(true);
			}
		}
	}

	// Token: 0x06001B61 RID: 7009 RVA: 0x00308E60 File Offset: 0x00307060
	public void Refresh_FontTexture()
	{
		if (this.text_Select != null && this.text_Select.enabled)
		{
			this.text_Select.enabled = false;
			this.text_Select.enabled = true;
		}
		for (int i = 0; i < 3; i++)
		{
			if (this.text_tmpStr[i] != null && this.text_tmpStr[i].enabled)
			{
				this.text_tmpStr[i].enabled = false;
				this.text_tmpStr[i].enabled = true;
			}
		}
		for (int j = 0; j < 6; j++)
		{
			if (this.text_ItemName[j] != null && this.text_ItemName[j].enabled)
			{
				this.text_ItemName[j].enabled = false;
				this.text_ItemName[j].enabled = true;
			}
			if (this.text_ItemLv[j] != null && this.text_ItemLv[j].enabled)
			{
				this.text_ItemLv[j].enabled = false;
				this.text_ItemLv[j].enabled = true;
			}
			if (this.text_Itembtn[j] != null && this.text_Itembtn[j].enabled)
			{
				this.text_Itembtn[j].enabled = false;
				this.text_Itembtn[j].enabled = true;
			}
			for (int k = 0; k < 6; k++)
			{
				if (this.text_ItemEffect[j][k] != null && this.text_ItemEffect[j][k].enabled)
				{
					this.text_ItemEffect[j][k].enabled = false;
					this.text_ItemEffect[j][k].enabled = true;
				}
				if (this.text_ItemEffect_V[j][k] != null && this.text_ItemEffect_V[j][k].enabled)
				{
					this.text_ItemEffect_V[j][k].enabled = false;
					this.text_ItemEffect_V[j][k].enabled = true;
				}
			}
		}
		for (int l = 0; l < 7; l++)
		{
			if (this.text_Item_A_Name[l] != null && this.text_Item_A_Name[l].enabled)
			{
				this.text_Item_A_Name[l].enabled = false;
				this.text_Item_A_Name[l].enabled = true;
			}
		}
	}

	// Token: 0x06001B62 RID: 7010 RVA: 0x003090C8 File Offset: 0x003072C8
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 1:
			if (!this.bEqDataReq && !this.DM.mLordEquip.LoadLordEquip(false))
			{
				this.bEqDataReq = true;
				if (!this.bMaterialDataReq && !this.DM.mLordEquip.LoadLEMaterial(false))
				{
					this.bMaterialDataReq = true;
				}
				else if (this.bEqDataReq && this.bMaterialDataReq)
				{
					this.CheckReOpen(false);
				}
			}
			break;
		case 2:
			if (!this.DM.mLordEquip.LoadLordEquip(false) && !this.DM.mLordEquip.LoadLEMaterial(false))
			{
				this.CheckReOpen(false);
			}
			break;
		case 3:
		{
			this.tmplistEquip.Clear();
			this.tmpSpritelist.Clear();
			this.TableCount = this.DM.ActivitylistEquip.Count;
			for (int i = 0; i < this.TableCount; i++)
			{
				this.tmplistEquip.Add(this.DM.ActivitylistEquip[i]);
			}
			CString cstring = StringManager.Instance.StaticString1024();
			if (this.mAB != null)
			{
				UnityEngine.Object[] array = this.mAB.LoadAll(typeof(Sprite));
				for (int j = 0; j < this.TableCount; j++)
				{
					cstring.ClearString();
					this.tmpME = this.DM.MallEquipmantTable.GetRecordByKey(this.tmplistEquip[j]);
					cstring.IntToFormat((long)this.tmpME.EquipIcon, 3, false);
					cstring.AppendFormat("UI_fc_sbut_{0}");
					for (int k = 0; k < array.Length; k++)
					{
						if (DataManager.CompareStr(array[k].name, cstring) == 0)
						{
							this.tmpSpritelist.Add((Sprite)array[k]);
						}
					}
				}
			}
			this.tmplist_A.Clear();
			for (int l = 0; l < this.TableCount; l++)
			{
				this.tmplist_A.Add(79f);
			}
			this.m_ScrollPanel_Activity.AddNewDataHeight(this.tmplist_A, false, true);
			if (!this.DM.mLordEquip.LoadLordEquip(false) && !this.DM.mLordEquip.LoadLEMaterial(false))
			{
				this.CheckReOpen(false);
			}
			break;
		}
		}
	}

	// Token: 0x06001B63 RID: 7011 RVA: 0x00309354 File Offset: 0x00307554
	private void Start()
	{
	}

	// Token: 0x06001B64 RID: 7012 RVA: 0x00309358 File Offset: 0x00307558
	private void Update()
	{
		if (this.SelectColorT.gameObject.activeSelf)
		{
			this.ShowTimeSelectColor += Time.smoothDeltaTime;
			if (this.ShowTimeSelectColor >= 0f)
			{
				if (this.ShowTimeSelectColor >= 2f)
				{
					this.ShowTimeSelectColor = 0f;
				}
				float a = (this.ShowTimeSelectColor <= 1f) ? this.ShowTimeSelectColor : (2f - this.ShowTimeSelectColor);
				this.Img_SelectColor.color = new Color(1f, 1f, 1f, a);
			}
		}
		for (int i = 0; i < 7; i++)
		{
			if (this.tmpImgSelect_btn[i] != null && this.tmpImgSelect_btn[i].gameObject.activeSelf)
			{
				this.ItemActivitySelect += Time.smoothDeltaTime;
				if (this.ItemActivitySelect >= 0f)
				{
					if (this.ItemActivitySelect >= 2f)
					{
						this.ItemActivitySelect = 0f;
					}
					float a2 = (this.ItemActivitySelect <= 1f) ? this.ItemActivitySelect : (2f - this.ItemActivitySelect);
					this.tmpImgSelect_btn[i].color = new Color(1f, 1f, 1f, a2);
				}
			}
		}
	}

	// Token: 0x0400528E RID: 21134
	private DataManager DM;

	// Token: 0x0400528F RID: 21135
	private GUIManager GUIM;

	// Token: 0x04005290 RID: 21136
	private Transform GameT;

	// Token: 0x04005291 RID: 21137
	private Transform Tmp;

	// Token: 0x04005292 RID: 21138
	private Transform SelectColorT;

	// Token: 0x04005293 RID: 21139
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04005294 RID: 21140
	private ScrollPanel m_ScrollPanel_Activity;

	// Token: 0x04005295 RID: 21141
	private RectTransform[] ItemBG_RC = new RectTransform[6];

	// Token: 0x04005296 RID: 21142
	private RectTransform[] ItemLine_RC = new RectTransform[6];

	// Token: 0x04005297 RID: 21143
	private RectTransform[] btn_RC = new RectTransform[6];

	// Token: 0x04005298 RID: 21144
	private RectTransform[] Img_RC = new RectTransform[6];

	// Token: 0x04005299 RID: 21145
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[6];

	// Token: 0x0400529A RID: 21146
	private ScrollPanelItem[] tmpItem_A = new ScrollPanelItem[7];

	// Token: 0x0400529B RID: 21147
	private RectTransform mContentRT;

	// Token: 0x0400529C RID: 21148
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x0400529D RID: 21149
	private Door door;

	// Token: 0x0400529E RID: 21150
	private UISpritesArray SArray;

	// Token: 0x0400529F RID: 21151
	private UIButton btn_EXIT;

	// Token: 0x040052A0 RID: 21152
	private UIButton[] btn_Color = new UIButton[6];

	// Token: 0x040052A1 RID: 21153
	private UIButton[] btn_ForgingEquip = new UIButton[6];

	// Token: 0x040052A2 RID: 21154
	private UIButton[] btn_ActivityEquip = new UIButton[7];

	// Token: 0x040052A3 RID: 21155
	private UILEBtn tmpLebtn;

	// Token: 0x040052A4 RID: 21156
	private UILEBtn[] tmp_ItemLebtn = new UILEBtn[6];

	// Token: 0x040052A5 RID: 21157
	private Image BG;

	// Token: 0x040052A6 RID: 21158
	private Image Img_SelectColor;

	// Token: 0x040052A7 RID: 21159
	private Image tmpImg;

	// Token: 0x040052A8 RID: 21160
	private Image[] tmpImg_ItemEnough = new Image[6];

	// Token: 0x040052A9 RID: 21161
	private Image[] tmpImg_btn = new Image[7];

	// Token: 0x040052AA RID: 21162
	private Image[] tmpImgSelect_btn = new Image[7];

	// Token: 0x040052AB RID: 21163
	private Image[] tmpImg_ItemIcon = new Image[6];

	// Token: 0x040052AC RID: 21164
	private Image[][] tmpImg_Items = new Image[6][];

	// Token: 0x040052AD RID: 21165
	private UIText text_Select;

	// Token: 0x040052AE RID: 21166
	private UIText[] text_tmpStr = new UIText[3];

	// Token: 0x040052AF RID: 21167
	private UIText[] text_Item_A_Name = new UIText[7];

	// Token: 0x040052B0 RID: 21168
	private UIText[] text_ItemName = new UIText[6];

	// Token: 0x040052B1 RID: 21169
	private UIText[] text_ItemLv = new UIText[6];

	// Token: 0x040052B2 RID: 21170
	private UIText[] text_Itembtn = new UIText[6];

	// Token: 0x040052B3 RID: 21171
	private UIText[][] text_ItemEffect = new UIText[6][];

	// Token: 0x040052B4 RID: 21172
	private UIText[][] text_ItemEffect_V = new UIText[6][];

	// Token: 0x040052B5 RID: 21173
	private CString[][] Cstr_Effect = new CString[6][];

	// Token: 0x040052B6 RID: 21174
	private CString[][] Cstr_Effect_V = new CString[6][];

	// Token: 0x040052B7 RID: 21175
	private CString[] Cstr_ItemLv = new CString[6];

	// Token: 0x040052B8 RID: 21176
	private CString[] Cstr_ItemName = new CString[6];

	// Token: 0x040052B9 RID: 21177
	private Material m_Mat;

	// Token: 0x040052BA RID: 21178
	private Material m_ListMat;

	// Token: 0x040052BB RID: 21179
	private List<float> tmplist_A = new List<float>();

	// Token: 0x040052BC RID: 21180
	private List<float> tmplist = new List<float>();

	// Token: 0x040052BD RID: 21181
	public List<ushort> tmplistData = new List<ushort>();

	// Token: 0x040052BE RID: 21182
	private List<LordEquipEffectSet> effectList = new List<LordEquipEffectSet>();

	// Token: 0x040052BF RID: 21183
	public SortItemComparer mSortItem = new SortItemComparer();

	// Token: 0x040052C0 RID: 21184
	private List<Sprite> tmpSpritelist = new List<Sprite>();

	// Token: 0x040052C1 RID: 21185
	public List<ushort> tmplistEquip = new List<ushort>();

	// Token: 0x040052C2 RID: 21186
	private Equip tmpEQ;

	// Token: 0x040052C3 RID: 21187
	private MallEquipmant tmpME;

	// Token: 0x040052C4 RID: 21188
	public byte mColor = 4;

	// Token: 0x040052C5 RID: 21189
	public byte mActivityIdx = byte.MaxValue;

	// Token: 0x040052C6 RID: 21190
	private bool bEqDataReq;

	// Token: 0x040052C7 RID: 21191
	private bool bMaterialDataReq;

	// Token: 0x040052C8 RID: 21192
	private int mABeKey;

	// Token: 0x040052C9 RID: 21193
	private float ShowTimeSelectColor;

	// Token: 0x040052CA RID: 21194
	private float ItemActivitySelect;

	// Token: 0x040052CB RID: 21195
	private int mItemActivityIdx = -1;

	// Token: 0x040052CC RID: 21196
	private int mItemActivityIdx2 = -1;

	// Token: 0x040052CD RID: 21197
	private byte tmpCount;

	// Token: 0x040052CE RID: 21198
	private byte tmpEnoughCount;

	// Token: 0x040052CF RID: 21199
	private bool bShowMainEquip;

	// Token: 0x040052D0 RID: 21200
	private int TableCount;

	// Token: 0x040052D1 RID: 21201
	private AssetBundle mAB;
}
