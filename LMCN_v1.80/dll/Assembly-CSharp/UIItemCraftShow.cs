using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200044E RID: 1102
public class UIItemCraftShow : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x06001621 RID: 5665 RVA: 0x0025A9E4 File Offset: 0x00258BE4
	public override void OnOpen(int arg1, int arg2)
	{
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		this.PM = PetManager.Instance;
		this.GameT = base.gameObject.transform;
		this.door = (this.GUIM.FindMenu(EGUIWindow.Door) as Door);
		this.spArray = this.GameT.GetComponent<UISpritesArray>();
		Material material = this.door.LoadMaterial();
		if (this.PM.IsShowOpen)
		{
			for (int i = (int)this.mShowItemNum; i < this.PM.mItemCraftList.Count; i++)
			{
				this.IsShowItem[i] = true;
			}
			this.mShowItemNum = (byte)this.PM.mItemCraftList.Count;
		}
		this.Cstr_TitleName = StringManager.Instance.SpawnString(200);
		this.Cstr_PetName = StringManager.Instance.SpawnString(100);
		for (int j = 0; j < 5; j++)
		{
			this.Cstr_ItemCount[j] = new CString[4];
			this.Cstr_ItemCount1[j] = new CString[4];
			this.Cstr_ItemCount2[j] = new CString[4];
			this.Cstr_ItemCount3[j] = new CString[4];
			for (int k = 0; k < 4; k++)
			{
				this.Cstr_ItemCount[j][k] = StringManager.Instance.SpawnString(30);
				this.Cstr_ItemCount1[j][k] = StringManager.Instance.SpawnString(30);
				this.Cstr_ItemCount2[j][k] = StringManager.Instance.SpawnString(30);
				this.Cstr_ItemCount3[j][k] = StringManager.Instance.SpawnString(30);
			}
			this.mLightRT[j] = new RectTransform[4];
			this.mItemRT[j] = new RectTransform[4];
			this.PetItem_T[j] = new Transform[4];
			this.Item_T[j] = new Transform[4];
			this.btn_PetInfo[j] = new UIButton[4];
			this.Hbtn_PetItems[j] = new UIHIBtn[4];
			this.Hbtn_Items[j] = new UIHIBtn[4];
			this.Img_ItemBG1[j] = new Image[4];
			this.Img_ItemBG2[j] = new Image[4];
			this.text_ItemName[j] = new UIText[4];
			this.text_ItemCount[j] = new UIText[4];
			this.text_ItemCount1[j] = new UIText[4];
			this.text_ItemCount2[j] = new UIText[4];
			this.text_ItemCount3[j] = new UIText[4];
		}
		this.Tmp = this.GameT.GetChild(0);
		this.Hbtm_ItemCraft = this.Tmp.GetChild(4).GetComponent<UIHIBtn>();
		this.GUIM.InitianHeroItemImg(this.Hbtm_ItemCraft.transform, eHeroOrItem.Item, (ushort)arg1, 0, 0, 0, true, true, true, false);
		this.TitleNameText = this.Tmp.GetChild(5).GetComponent<UIText>();
		this.TitleNameText.font = this.TTFont;
		this.Cstr_TitleName.ClearString();
		this.tmpEquip = this.DM.EquipTable.GetRecordByKey((ushort)arg1);
		this.Cstr_TitleName.Append(this.DM.mStringTable.GetStringByID((uint)this.tmpEquip.EquipName));
		this.Cstr_TitleName.Append(' ');
		this.Cstr_TitleName.IntToFormat((long)arg2, 1, false);
		if (this.GUIM.IsArabic)
		{
			this.Cstr_TitleName.AppendFormat("{0}x");
		}
		else
		{
			this.Cstr_TitleName.AppendFormat("x{0}");
		}
		this.TitleNameText.text = this.Cstr_TitleName.ToString();
		this.GetAllText = this.Tmp.GetChild(6).GetComponent<UIText>();
		this.GetAllText.font = this.TTFont;
		this.GetAllText.text = this.DM.mStringTable.GetStringByID(10102u);
		this.Tmp = this.GameT.GetChild(1);
		this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
		this.Tmp = this.GameT.GetChild(2);
		for (int l = 0; l < 4; l++)
		{
			this.Tmp1 = this.Tmp.GetChild(l);
			UIHIBtn component = this.Tmp1.GetChild(0).GetChild(2).GetComponent<UIHIBtn>();
			this.GUIM.InitianHeroItemImg(component.transform, eHeroOrItem.Pet, 1, 0, 0, 0, true, true, true, false);
			this.Tmp2 = this.Tmp1.GetChild(0).GetChild(4);
			UIButton component2 = this.Tmp2.GetComponent<UIButton>();
			component2.m_BtnID1 = 2;
			this.hint = component2.gameObject.AddComponent<UIButtonHint>();
			this.hint.m_eHint = EUIButtonHint.DownUpHandler;
			this.hint.m_Handler = this;
			this.Tmp2 = this.Tmp1.GetChild(0).GetChild(5);
			UIText component3 = this.Tmp2.GetComponent<UIText>();
			component3.font = this.TTFont;
			component = this.Tmp1.GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
			this.GUIM.InitianHeroItemImg(component.transform, eHeroOrItem.Item, 1, 0, 0, 0, true, true, true, false);
			this.Tmp2 = this.Tmp1.GetChild(1).GetChild(1).GetChild(0);
			component3 = this.Tmp2.GetComponent<UIText>();
			component3.font = this.TTFont;
			this.Tmp2 = this.Tmp1.GetChild(1).GetChild(1).GetChild(1);
			component3 = this.Tmp2.GetComponent<UIText>();
			component3.font = this.TTFont;
			this.Tmp2 = this.Tmp1.GetChild(1).GetChild(2).GetChild(1);
			component3 = this.Tmp2.GetComponent<UIText>();
			component3.font = this.TTFont;
			this.Tmp2 = this.Tmp1.GetChild(1).GetChild(3);
			component3 = this.Tmp2.GetComponent<UIText>();
			component3.font = this.TTFont;
		}
		this.tmplist.Clear();
		this.tmpCount = this.PM.mItemCraftList.Count / 4;
		if (this.PM.mItemCraftList.Count % 4 > 0)
		{
			this.tmpCount++;
		}
		this.tmpCount++;
		for (int m = 0; m < this.tmpCount; m++)
		{
			this.tmplist.Add(140f);
		}
		this.m_ScrollPanel.IntiScrollPanel(478f, 0f, 0f, this.tmplist, 5, this);
		this.mContentRT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
		CScrollRect component4 = this.m_ScrollPanel.GetComponent<CScrollRect>();
		UIButtonHint.scrollRect = component4;
		this.Tmp = this.GameT.GetChild(3);
		this.Tmp.gameObject.SetActive(true);
		this.mParticlePosT = this.Tmp;
		this.Tmp = this.GameT.GetChild(3).GetChild(0);
		this.Img_BG = this.Tmp.GetComponent<Image>();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.Img_BG.rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0f);
			this.Img_BG.rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0f);
		}
		this.mBookPosT = this.GameT.GetChild(3).GetChild(1);
		this.Tmp = this.GameT.GetChild(3).GetChild(2);
		this.Img_Hand = this.Tmp.GetComponent<Image>();
		this.Img_Hand.gameObject.SetActive(false);
		this.Tmp = this.GameT.GetChild(3).GetChild(3);
		this.mPetRT = this.Tmp.GetComponent<RectTransform>();
		this.Img_Light = this.Tmp.GetChild(0).GetComponent<Image>();
		this.Img_Light_2 = this.Tmp.GetChild(1).GetComponent<Image>();
		this.mPetPosRT = this.Tmp.GetChild(2).GetComponent<RectTransform>();
		this.tmpPetLocal = this.mPetPosRT.anchoredPosition;
		this.Hbtm_Pet = this.Tmp.GetChild(3).GetComponent<UIHIBtn>();
		this.GUIM.InitianHeroItemImg(this.Hbtm_Pet.transform, eHeroOrItem.Pet, 1, 0, 0, 0, true, true, true, false);
		this.Img_Rare = this.Tmp.GetChild(4).GetComponent<Image>();
		this.text_Rare = this.Tmp.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.text_Rare.font = this.TTFont;
		this.Img_wave = this.Tmp.GetChild(5).GetComponent<Image>();
		this.Img_hand = this.Tmp.GetChild(6).GetComponent<Image>();
		this.PetTitleText = this.Tmp.GetChild(7).GetComponent<UIText>();
		this.PetTitleText.font = this.TTFont;
		this.PetTitleText.text = this.DM.mStringTable.GetStringByID(10103u);
		this.PetNameText = this.Tmp.GetChild(8).GetComponent<UIText>();
		this.PetNameText.font = this.TTFont;
		this.Tmp = this.GameT.GetChild(3).GetChild(4);
		this.mParticle_MoveRT = this.Tmp.GetComponent<RectTransform>();
		this.mParticle_MoveRT.gameObject.SetActive(true);
		this.mParticle_MoveRT.anchoredPosition = this.tmpPetLocal;
		this.Tmp = this.GameT.GetChild(3).GetChild(5);
		this.mItemParticleRT = this.Tmp.GetComponent<RectTransform>();
		this.mItemParticleRT.gameObject.SetActive(true);
		this.Tmp = this.GameT.GetChild(3).GetChild(6);
		this.mItemParticle_MoveRT = this.Tmp.GetComponent<RectTransform>();
		this.tmpParticle = this.mItemParticle_MoveRT.anchoredPosition;
		this.mItemParticle_MoveRT.gameObject.SetActive(true);
		this.Tmp = this.GameT.GetChild(3).GetChild(7);
		this.Img_PetStone = this.Tmp.GetComponent<Image>();
		this.mStone_Start = this.Img_PetStone.rectTransform.anchoredPosition;
		this.Tmp = this.GameT.GetChild(4);
		this.Img_EXIT = this.Tmp.GetComponent<Image>();
		if (this.GUIM.bOpenOnIPhoneX)
		{
			this.Img_EXIT.enabled = false;
		}
		this.Tmp = this.GameT.GetChild(4).GetChild(0);
		this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
		this.btn_EXIT.m_Handler = this;
		this.btn_EXIT.m_BtnID1 = 0;
		this.btn_EXIT.SetButtonEffectType(e_EffectType.e_Scale);
		this.btn_EXIT.transition = Selectable.Transition.None;
		this.Tmp = this.GameT.GetChild(5);
		this.Img_ChangeStatus = this.Tmp.GetComponent<Image>();
		this.Tmp = this.GameT.GetChild(5).GetChild(0);
		this.btn_ChangeStatus = this.Tmp.GetComponent<UIButton>();
		this.btn_ChangeStatus.m_Handler = this;
		this.btn_ChangeStatus.m_BtnID1 = 1;
		this.btn_ChangeStatus.image.color = new Color(1f, 1f, 1f, 0f);
		this.Tmp = this.GameT.GetChild(6);
		this.Img_ItemHint = this.Tmp.GetComponent<Image>();
		this.Tmp = this.GameT.GetChild(6).GetChild(0);
		this.Img_ItemRare = this.Tmp.GetComponent<Image>();
		this.Tmp = this.GameT.GetChild(6).GetChild(0).GetChild(0);
		this.text_HintRare2 = this.Tmp.GetComponent<UIText>();
		this.text_HintRare2.font = this.TTFont;
		this.Tmp = this.GameT.GetChild(6).GetChild(1);
		this.text_HintName = this.Tmp.GetComponent<UIText>();
		this.text_HintName.font = this.TTFont;
		this.Tmp = this.GameT.GetChild(6).GetChild(2);
		this.text_HintRare = this.Tmp.GetComponent<UIText>();
		this.text_HintRare.font = this.TTFont;
		this.text_HintRare.text = this.DM.mStringTable.GetStringByID(10129u);
		this.text_HintRare.SetAllDirty();
		this.text_HintRare.cachedTextGenerator.Invalidate();
		this.text_HintRare.cachedTextGeneratorForLayout.Invalidate();
		this.Tmp = this.GameT.GetChild(6).GetChild(3);
		this.text_HintInfo = this.Tmp.GetComponent<UIText>();
		this.text_HintInfo.font = this.TTFont;
		this.text_HintInfo.text = this.DM.mStringTable.GetStringByID(10128u);
		this.text_HintInfo.SetAllDirty();
		this.text_HintInfo.cachedTextGenerator.Invalidate();
		this.text_HintInfo.cachedTextGeneratorForLayout.Invalidate();
		if (this.text_HintInfo.preferredWidth > this.text_HintRare.preferredWidth + 36f)
		{
			if (this.text_HintInfo.preferredWidth > 210f)
			{
				if (this.text_HintInfo.preferredWidth > 316f)
				{
					if (this.text_HintInfo.preferredHeight > 25f)
					{
						this.text_HintInfo.rectTransform.sizeDelta = new Vector2(316f, this.text_HintInfo.preferredHeight + 1f);
						this.Img_ItemHint.rectTransform.sizeDelta = new Vector2(350f, 118f + (this.text_HintInfo.preferredHeight - 24f));
					}
					else
					{
						this.text_HintInfo.rectTransform.sizeDelta = new Vector2(316f, this.text_HintInfo.rectTransform.sizeDelta.y);
						this.Img_ItemHint.rectTransform.sizeDelta = new Vector2(350f, this.Img_ItemHint.rectTransform.sizeDelta.y);
					}
				}
				else
				{
					this.text_HintInfo.rectTransform.sizeDelta = new Vector2(this.text_HintInfo.preferredWidth, this.text_HintInfo.rectTransform.sizeDelta.y);
					this.Img_ItemHint.rectTransform.sizeDelta = new Vector2(this.text_HintInfo.preferredWidth + 34f, this.Img_ItemHint.rectTransform.sizeDelta.y);
				}
			}
		}
		else if (this.text_HintRare.preferredWidth + 36f > 210f)
		{
			this.text_HintRare.rectTransform.sizeDelta = new Vector2(this.text_HintRare.preferredWidth + 37f, this.text_HintRare.rectTransform.sizeDelta.y);
			this.Img_ItemHint.rectTransform.sizeDelta = new Vector2(this.text_HintRare.preferredWidth + 71f, this.Img_ItemHint.rectTransform.sizeDelta.y);
		}
		this.Img_ItemRare.rectTransform.anchoredPosition = new Vector2(this.text_HintRare.preferredWidth + 20f, this.Img_ItemRare.rectTransform.anchoredPosition.y);
		if (!this.PM.IsShowOpen)
		{
			this.AB = AssetManager.GetAssetBundle("Role/pet_contract", out this.AssetKey, false);
			if (this.AB != null)
			{
				this.AR = this.AB.LoadAsync("m", typeof(GameObject));
			}
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.AR.asset);
			gameObject.transform.SetParent(this.mBookPosT, false);
			gameObject.transform.localPosition = new Vector3(0f, 0f, -700f);
			gameObject.transform.localRotation = new Quaternion(0f, -180f, 0f, 0f);
			gameObject.transform.localScale = new Vector3(1000f, 1000f, 1000f);
			GUIManager.Instance.SetLayer(gameObject, 5);
			if (this.PM.mPetItemNum > 0)
			{
				this.mStatus = 1;
				this.mPetRT.gameObject.SetActive(true);
				this.Img_BG.gameObject.SetActive(true);
			}
			else
			{
				this.mStatus = 0;
				this.bStarShow = true;
			}
			this.Img_ChangeStatus.gameObject.SetActive(true);
			this.mBookPosT.gameObject.SetActive(true);
		}
		else
		{
			this.Img_EXIT.gameObject.SetActive(true);
			this.bShowArrow = true;
			this.mArrowY = this.mContentRT.anchoredPosition.y;
		}
		this.bOPenEnd = true;
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 1);
	}

	// Token: 0x06001622 RID: 5666 RVA: 0x0025BB88 File Offset: 0x00259D88
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.tmpItem[panelObjectIdx] == null)
		{
			this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
			this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
			for (int i = 0; i < 4; i++)
			{
				this.mItemRT[panelObjectIdx][i] = item.transform.GetChild(i).GetComponent<RectTransform>();
				this.PetItem_T[panelObjectIdx][i] = item.transform.GetChild(i).GetChild(0);
				this.mLightRT[panelObjectIdx][i] = this.PetItem_T[panelObjectIdx][i].GetChild(0).GetComponent<RectTransform>();
				this.Hbtn_PetItems[panelObjectIdx][i] = this.PetItem_T[panelObjectIdx][i].GetChild(2).GetComponent<UIHIBtn>();
				this.Hbtn_PetItems[panelObjectIdx][i].m_Handler = this;
				this.btn_PetInfo[panelObjectIdx][i] = this.PetItem_T[panelObjectIdx][i].GetChild(4).GetComponent<UIButton>();
				this.btn_PetInfo[panelObjectIdx][i].m_Handler = this;
				this.btn_PetInfo[panelObjectIdx][i].m_BtnID2 = dataIdx * 4 + i;
				this.btn_PetInfo[panelObjectIdx][i].m_BtnID3 = panelObjectIdx;
				this.hint = this.btn_PetInfo[panelObjectIdx][i].gameObject.GetComponent<UIButtonHint>();
				this.hint.m_eHint = EUIButtonHint.DownUpHandler;
				this.hint.m_Handler = this;
				this.hint.Parm1 = 2;
				this.text_ItemName[panelObjectIdx][i] = this.PetItem_T[panelObjectIdx][i].GetChild(5).GetComponent<UIText>();
				this.Item_T[panelObjectIdx][i] = item.transform.GetChild(i).GetChild(1);
				this.Hbtn_Items[panelObjectIdx][i] = this.Item_T[panelObjectIdx][i].GetChild(0).GetComponent<UIHIBtn>();
				this.Hbtn_Items[panelObjectIdx][i].m_Handler = this;
				this.Img_ItemBG1[panelObjectIdx][i] = this.Item_T[panelObjectIdx][i].GetChild(1).GetComponent<Image>();
				this.Img_ItemBG2[panelObjectIdx][i] = this.Item_T[panelObjectIdx][i].GetChild(2).GetComponent<Image>();
				this.text_ItemCount[panelObjectIdx][i] = this.Item_T[panelObjectIdx][i].GetChild(2).GetChild(1).GetComponent<UIText>();
				this.text_ItemCount1[panelObjectIdx][i] = this.Item_T[panelObjectIdx][i].GetChild(1).GetChild(0).GetComponent<UIText>();
				this.text_ItemCount1[panelObjectIdx][i].AdjuestUI();
				this.text_ItemCount2[panelObjectIdx][i] = this.Item_T[panelObjectIdx][i].GetChild(1).GetChild(1).GetComponent<UIText>();
				this.text_ItemCount2[panelObjectIdx][i].AdjuestUI();
				this.text_ItemCount3[panelObjectIdx][i] = this.Item_T[panelObjectIdx][i].GetChild(3).GetComponent<UIText>();
				this.text_ItemCount3[panelObjectIdx][i].AdjuestUI();
			}
		}
		if (panelObjectIdx < dataIdx)
		{
			for (int j = 0; j < 4; j++)
			{
				this.PetItem_T[panelObjectIdx][j].gameObject.SetActive(false);
				this.Item_T[panelObjectIdx][j].gameObject.SetActive(false);
				this.text_ItemCount1[panelObjectIdx][j].color = Color.white;
			}
		}
		if (dataIdx * 4 < (int)this.mShowItemNum)
		{
			for (int k = 0; k < 4; k++)
			{
				this.PetItem_T[panelObjectIdx][k].gameObject.SetActive(false);
				this.Item_T[panelObjectIdx][k].gameObject.SetActive(false);
				this.text_ItemCount[panelObjectIdx][k].gameObject.SetActive(false);
				this.text_ItemCount1[panelObjectIdx][k].gameObject.SetActive(false);
				this.text_ItemCount2[panelObjectIdx][k].gameObject.SetActive(false);
				this.text_ItemCount3[panelObjectIdx][k].gameObject.SetActive(false);
				this.Img_ItemBG1[panelObjectIdx][k].gameObject.SetActive(false);
				this.Img_ItemBG2[panelObjectIdx][k].gameObject.SetActive(false);
				this.scaleCount = 1f;
				if (dataIdx * 4 + k < (int)this.mShowItemNum)
				{
					item.transform.GetChild(k).gameObject.SetActive(true);
					if (dataIdx * 4 + k < this.PM.mItemCraftList.Count)
					{
						this.tmpItemCraftD = this.PM.mItemCraftList[dataIdx * 4 + k];
					}
					this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.tmpItemCraftD.ItemID);
					this.tmpPT = this.PM.PetTable.GetRecordByKey(this.tmpEQ.SyntheticParts[0].SyntheticItem);
					if (dataIdx * 4 + k < (int)this.PM.mPetItemNum)
					{
						this.GUIM.ChangeHeroItemImg(this.Hbtn_PetItems[panelObjectIdx][k].transform, eHeroOrItem.Pet, this.tmpItemCraftD.mPetID, this.tmpItemCraftD.ItemRank, this.tmpPT.Rare, 0);
						this.PetItem_T[panelObjectIdx][k].gameObject.SetActive(true);
						this.text_ItemName[panelObjectIdx][k].text = this.DM.mStringTable.GetStringByID((uint)this.tmpItemCraftD.mPetName);
						this.text_ItemName[panelObjectIdx][k].SetAllDirty();
						this.text_ItemName[panelObjectIdx][k].cachedTextGenerator.Invalidate();
						this.text_ItemName[panelObjectIdx][k].gameObject.SetActive(true);
					}
					else
					{
						this.GUIM.ChangeHeroItemImg(this.Hbtn_Items[panelObjectIdx][k].transform, eHeroOrItem.Item, this.tmpItemCraftD.ItemID, this.tmpItemCraftD.ItemRank, this.tmpPT.Rare, 0);
						this.Item_T[panelObjectIdx][k].gameObject.SetActive(true);
						this.tmpCount = 0;
						if (this.tmpItemCraftD.mItemKind == 29)
						{
							if (this.tmpItemCraftD.mPetEnhance == 2)
							{
								this.Cstr_ItemCount[panelObjectIdx][k].ClearString();
								this.tmpCount = (int)this.DM.GetCurItemQuantity(this.tmpItemCraftD.ItemID, this.tmpItemCraftD.ItemRank);
								this.Cstr_ItemCount[panelObjectIdx][k].IntToFormat((long)this.tmpCount, 1, false);
								this.Cstr_ItemCount[panelObjectIdx][k].AppendFormat("{0}");
								this.text_ItemCount[panelObjectIdx][k].text = this.Cstr_ItemCount[panelObjectIdx][k].ToString();
								this.text_ItemCount[panelObjectIdx][k].SetAllDirty();
								this.text_ItemCount[panelObjectIdx][k].cachedTextGenerator.Invalidate();
								this.Img_ItemBG2[panelObjectIdx][k].gameObject.SetActive(true);
								this.text_ItemCount[panelObjectIdx][k].gameObject.SetActive(true);
								if (this.GUIM.IsArabic)
								{
									this.text_ItemCount[panelObjectIdx][k].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
								}
								else
								{
									this.text_ItemCount[panelObjectIdx][k].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
								}
							}
							else
							{
								this.Img_ItemBG1[panelObjectIdx][k].gameObject.SetActive(true);
								this.Cstr_ItemCount1[panelObjectIdx][k].ClearString();
								this.tmpCount = (int)this.DM.GetCurItemQuantity(this.tmpItemCraftD.ItemID, this.tmpItemCraftD.ItemRank);
								this.Cstr_ItemCount[panelObjectIdx][k].IntToFormat((long)this.tmpCount, 1, false);
								this.Cstr_ItemCount1[panelObjectIdx][k].AppendFormat("{0}");
								this.text_ItemCount1[panelObjectIdx][k].text = this.Cstr_ItemCount1[panelObjectIdx][k].ToString();
								this.text_ItemCount1[panelObjectIdx][k].SetAllDirty();
								this.text_ItemCount1[panelObjectIdx][k].cachedTextGenerator.Invalidate();
								this.Cstr_ItemCount2[panelObjectIdx][k].ClearString();
								this.Cstr_ItemCount2[panelObjectIdx][k].IntToFormat((long)this.PM.GetEvoNeed_Stone(this.tmpItemCraftD.mPetEnhance, this.tmpPT.Rare), 1, false);
								if (this.GUIM.IsArabic)
								{
									this.Cstr_ItemCount2[panelObjectIdx][k].AppendFormat("{0}/");
								}
								else
								{
									this.Cstr_ItemCount2[panelObjectIdx][k].AppendFormat("/{0}");
								}
								this.text_ItemCount2[panelObjectIdx][k].text = this.Cstr_ItemCount2[panelObjectIdx][k].ToString();
								this.text_ItemCount2[panelObjectIdx][k].SetAllDirty();
								this.text_ItemCount2[panelObjectIdx][k].cachedTextGenerator.Invalidate();
								this.text_ItemCount1[panelObjectIdx][k].gameObject.SetActive(true);
								this.text_ItemCount2[panelObjectIdx][k].gameObject.SetActive(true);
								if (this.tmpCount >= (int)this.PM.GetEvoNeed_Stone(this.tmpItemCraftD.mPetEnhance, this.tmpPT.Rare))
								{
									this.text_ItemCount1[panelObjectIdx][k].color = Color.green;
								}
								if (this.GUIM.IsArabic)
								{
									this.text_ItemCount1[panelObjectIdx][k].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
									this.text_ItemCount2[panelObjectIdx][k].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
									this.text_ItemCount3[panelObjectIdx][k].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
								}
								else
								{
									this.text_ItemCount1[panelObjectIdx][k].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
									this.text_ItemCount2[panelObjectIdx][k].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
									this.text_ItemCount3[panelObjectIdx][k].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
								}
							}
						}
						this.text_ItemCount3[panelObjectIdx][k].gameObject.SetActive(true);
						this.Cstr_ItemCount3[panelObjectIdx][k].ClearString();
						this.Cstr_ItemCount3[panelObjectIdx][k].IntToFormat((long)this.tmpItemCraftD.Num, 1, false);
						if (this.GUIM.IsArabic)
						{
							this.Cstr_ItemCount3[panelObjectIdx][k].AppendFormat("{0}x");
						}
						else
						{
							this.Cstr_ItemCount3[panelObjectIdx][k].AppendFormat("x{0}");
						}
						this.text_ItemCount3[panelObjectIdx][k].text = this.Cstr_ItemCount3[panelObjectIdx][k].ToString();
						this.text_ItemCount3[panelObjectIdx][k].SetAllDirty();
						this.text_ItemCount3[panelObjectIdx][k].cachedTextGenerator.Invalidate();
					}
				}
			}
		}
	}

	// Token: 0x06001623 RID: 5667 RVA: 0x0025C66C File Offset: 0x0025A86C
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001624 RID: 5668 RVA: 0x0025C670 File Offset: 0x0025A870
	public void OnButtonClick(UIButton sender)
	{
		GUIItemCraftShow btnID = (GUIItemCraftShow)sender.m_BtnID1;
		if (btnID != GUIItemCraftShow.btn_EXIT)
		{
			if (btnID == GUIItemCraftShow.btn_ChangeStatus)
			{
				if (!this.bOPenEnd || !this.bBookOpenEnd)
				{
					return;
				}
				if (this.mStatus == 1)
				{
					if (!this.bPet3DShow)
					{
						if (this.EffectParticle != null)
						{
							if (this.EffectParticle.activeSelf && ParticleManager.Instance.AllEffectObject != null)
							{
								this.EffectParticle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
								this.EffectParticle.SetActive(false);
								this.EffectParticle.SetActive(true);
							}
							this.EffectParticle = null;
						}
						if (this.Pet_Move_3 != null)
						{
							if (this.Pet_Move_3.activeSelf && ParticleManager.Instance.AllEffectObject != null)
							{
								this.Pet_Move_3.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
								this.Pet_Move_3.SetActive(false);
								this.Pet_Move_3.SetActive(true);
							}
							this.Pet_Move_3 = null;
						}
						if (this.controller != null)
						{
							this.controller.Stop();
						}
						this.mShowItemTime = 0f;
						this.mPetRT.gameObject.SetActive(true);
						if (!this.bLoadPet3D)
						{
							this.LoadPet3D();
						}
						this.bPet3DShow = true;
						if (this.AB_Pet == null)
						{
							this.Hbtm_Pet.gameObject.SetActive(true);
						}
						this.Img_Light.gameObject.SetActive(true);
						this.Img_Light_2.gameObject.SetActive(true);
						this.Img_Rare.gameObject.SetActive(true);
						this.PetTitleText.gameObject.SetActive(true);
						this.PetNameText.gameObject.SetActive(true);
						this.scaleCount = 1f;
						this.mPetPosRT.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
						this.mPetPosRT.anchoredPosition = new Vector2(this.mPetPosRT.anchoredPosition.x, (float)(0 - (1000 - this.tmpPT.StartupRatio.UpDownDist)));
						this.Img_PetStone.color = new Color(1f, 1f, 1f, 0f);
						AudioManager.Instance.PlayUISFX(UIKind.GainPetRookie);
						return;
					}
					if (!this.bPet3DClose)
					{
						this.bPet3DClose = true;
						this.mShowItemTime = 0f;
						if (this.Pet_Move_1 != null)
						{
							if (this.Pet_Move_1.activeSelf && ParticleManager.Instance.AllEffectObject != null)
							{
								this.Pet_Move_1.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
								this.Pet_Move_1.SetActive(false);
								this.Pet_Move_1.SetActive(true);
							}
							this.Pet_Move_1 = null;
						}
						if (this.Pet_Move_2 != null)
						{
							if (this.Pet_Move_2.activeSelf && ParticleManager.Instance.AllEffectObject != null)
							{
								this.Pet_Move_2.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
								this.Pet_Move_2.SetActive(false);
								this.Pet_Move_2.SetActive(true);
							}
							this.Pet_Move_2 = null;
						}
						this.Img_wave.gameObject.SetActive(false);
						this.Img_hand.gameObject.SetActive(false);
					}
					else
					{
						this.mShowItemTime = 0f;
						this.mScrollTime = 0f;
						this.IsShowItem[(int)this.mShowItemNum] = true;
						this.mShowItemNum += 1;
						this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
						if (this.mShowItemNum > 4 && this.mShowItemNum % 4 == 0)
						{
							this.bStarMove = true;
						}
						this.bPet3DClose = false;
						this.bPet3DShow = false;
						this.bPetNextOne = false;
						this.DestroyPet3D();
						this.Img_Light.gameObject.SetActive(false);
						this.Img_Light_2.gameObject.SetActive(false);
						this.Img_Rare.gameObject.SetActive(false);
						this.PetTitleText.gameObject.SetActive(false);
						this.PetNameText.gameObject.SetActive(false);
						this.mPetRT.gameObject.SetActive(false);
						if (this.PM.mPetItemNum < this.mShowItemNum + 1)
						{
							this.mStatus = 0;
							this.bStarShow = true;
							this.Img_BG.gameObject.SetActive(false);
						}
						else
						{
							this.mStatus = 1;
						}
						this.mParticle_MoveRT.anchoredPosition = this.tmpPetLocal;
						if (this.EffectParticle != null)
						{
							if (this.EffectParticle.activeSelf && ParticleManager.Instance.AllEffectObject != null)
							{
								this.EffectParticle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
								this.EffectParticle.SetActive(false);
								this.EffectParticle.SetActive(true);
							}
							this.EffectParticle = null;
						}
						if (this.Pet_Move_1 != null)
						{
							if (this.Pet_Move_1.activeSelf && ParticleManager.Instance.AllEffectObject != null)
							{
								this.Pet_Move_1.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
								this.Pet_Move_1.SetActive(false);
								this.Pet_Move_1.SetActive(true);
							}
							this.Pet_Move_1 = null;
						}
						if (this.Pet_Move_2 != null)
						{
							if (this.Pet_Move_2.activeSelf && ParticleManager.Instance.AllEffectObject != null)
							{
								this.Pet_Move_2.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
								this.Pet_Move_2.SetActive(false);
								this.Pet_Move_2.SetActive(true);
							}
							this.Pet_Move_2 = null;
						}
					}
				}
				else if (this.mStatus == 0 || this.mStatus == 4 || this.mStatus == 3)
				{
					if (this.mShowItemNum <= 0)
					{
						return;
					}
					byte b = (this.mShowItemNum - 1) / 4 % 5;
					byte b2 = (this.mShowItemNum - 1) % 4;
					this.scaleCount = 1f;
					this.mItemRT[(int)b][(int)b2].localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
					if (this.text_ItemCount1[(int)b][(int)b2].gameObject.activeSelf)
					{
						if (this.GUIM.IsArabic)
						{
							this.text_ItemCount1[(int)b][(int)b2].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
						}
						else
						{
							this.text_ItemCount1[(int)b][(int)b2].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
						}
						this.text_ItemCount1[(int)b][(int)b2].rectTransform.anchoredPosition = new Vector2(-23f - (this.scaleCount - 1f) * 20f, this.text_ItemCount1[(int)b][(int)b2].rectTransform.anchoredPosition.y);
					}
					if (this.text_ItemCount[(int)b][(int)b2].gameObject.activeSelf)
					{
						if (this.GUIM.IsArabic)
						{
							this.text_ItemCount[(int)b][(int)b2].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
						}
						else
						{
							this.text_ItemCount[(int)b][(int)b2].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
						}
					}
					if (this.mItemMove_1 != null)
					{
						if (this.mItemMove_1.activeSelf && ParticleManager.Instance.AllEffectObject != null)
						{
							this.mItemMove_1.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
							this.mItemMove_1.gameObject.SetActive(false);
							this.mItemMove_1.gameObject.SetActive(true);
						}
						this.mItemMove_1 = null;
					}
					if (this.mItemMove_2 != null)
					{
						if (this.mItemMove_2.activeSelf && ParticleManager.Instance.AllEffectObject != null)
						{
							this.mItemMove_2.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
							this.mItemMove_2.gameObject.SetActive(false);
							this.mItemMove_2.gameObject.SetActive(true);
						}
						this.mItemMove_2 = null;
					}
					this.mItemParticle_MoveRT.anchoredPosition = this.tmpParticle;
					this.mShowItemTime = 0f;
					byte b3;
					if (this.mShowItemNum < this.PM.mPetItemNum + this.PM.mPetStoneNum)
					{
						b3 = this.PM.mPetItemNum + this.PM.mPetStoneNum;
					}
					else
					{
						b3 = (byte)this.PM.mItemCraftList.Count;
					}
					for (int i = (int)this.mShowItemNum; i < (int)b3; i++)
					{
						this.IsShowItem[i] = true;
					}
					this.mShowItemNum = b3;
					this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
					float num = 0f;
					if (this.mShowItemNum >= 8)
					{
						if (this.mShowItemNum % 4 > 0)
						{
							num = (float)(140 * ((this.mShowItemNum - 8) / 4 + 1));
						}
						else
						{
							num = (float)(140 * ((this.mShowItemNum - 8) / 4));
						}
					}
					if (num + 478f > this.mContentRT.sizeDelta.y)
					{
						num = this.mContentRT.sizeDelta.y - 478f;
					}
					if (num < 0f)
					{
						num = 0f;
					}
					this.mContentRT.anchoredPosition = new Vector2(this.mContentRT.anchoredPosition.x, num);
					this.mScrollY = num;
					this.bStarMove = false;
				}
			}
		}
		else if (this.door != null)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001625 RID: 5669 RVA: 0x0025D154 File Offset: 0x0025B354
	public void OnHIButtonClick(UIHIBtn sender)
	{
	}

	// Token: 0x06001626 RID: 5670 RVA: 0x0025D158 File Offset: 0x0025B358
	public void OnButtonDown(UIButtonHint sender)
	{
		UIButton uibutton = sender.m_Button as UIButton;
		ushort parm = sender.Parm1;
		if (parm == 2)
		{
			if (uibutton.m_BtnID2 >= 0 && uibutton.m_BtnID2 < this.PM.mItemCraftList.Count)
			{
				this.tmpItemCraftD = this.PM.mItemCraftList[uibutton.m_BtnID2];
			}
			this.text_HintName.text = this.DM.mStringTable.GetStringByID((uint)this.tmpItemCraftD.mPetName);
			this.text_HintName.SetAllDirty();
			this.text_HintName.cachedTextGenerator.Invalidate();
			this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.tmpItemCraftD.ItemID);
			this.tmpPT = this.PM.PetTable.GetRecordByKey(this.tmpEQ.SyntheticParts[0].SyntheticItem);
			this.text_HintRare2.text = this.tmpPT.Rare.ToString();
			this.text_HintRare2.SetAllDirty();
			this.text_HintRare2.cachedTextGenerator.Invalidate();
			sender.GetTipPosition(this.Img_ItemHint.rectTransform, UIButtonHint.ePosition.Original, null);
			this.Img_ItemHint.gameObject.SetActive(true);
		}
	}

	// Token: 0x06001627 RID: 5671 RVA: 0x0025D2BC File Offset: 0x0025B4BC
	public void OnButtonUp(UIButtonHint sender)
	{
		this.Img_ItemHint.gameObject.SetActive(false);
	}

	// Token: 0x06001628 RID: 5672 RVA: 0x0025D2D0 File Offset: 0x0025B4D0
	public override bool OnBackButtonClick()
	{
		if (!this.Img_EXIT.gameObject.activeSelf)
		{
			this.OnButtonClick(this.btn_ChangeStatus);
			return true;
		}
		return false;
	}

	// Token: 0x06001629 RID: 5673 RVA: 0x0025D304 File Offset: 0x0025B504
	public override void OnClose()
	{
		this.DestroyPet3D();
		if (this.EffectParticle != null)
		{
			if (this.EffectParticle.activeSelf && ParticleManager.Instance.AllEffectObject != null)
			{
				this.EffectParticle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
				this.EffectParticle.SetActive(false);
				this.EffectParticle.SetActive(true);
			}
			this.EffectParticle = null;
		}
		if (this.Pet_Move_1 != null)
		{
			if (this.Pet_Move_1.activeSelf && ParticleManager.Instance.AllEffectObject != null)
			{
				this.Pet_Move_1.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
				this.Pet_Move_1.SetActive(false);
				this.Pet_Move_1.SetActive(true);
			}
			this.Pet_Move_1 = null;
		}
		if (this.Pet_Move_2 != null)
		{
			if (this.Pet_Move_2.activeSelf && ParticleManager.Instance.AllEffectObject != null)
			{
				this.Pet_Move_2.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
				this.Pet_Move_2.SetActive(false);
				this.Pet_Move_2.SetActive(true);
			}
			this.Pet_Move_2 = null;
		}
		if (this.Pet_Move_3 != null)
		{
			if (this.Pet_Move_3.activeSelf && ParticleManager.Instance.AllEffectObject != null)
			{
				this.Pet_Move_3.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
				this.Pet_Move_3.SetActive(false);
				this.Pet_Move_3.SetActive(true);
			}
			this.Pet_Move_3 = null;
		}
		if (this.mItemMove_1 != null)
		{
			if (this.mItemMove_1.activeSelf && ParticleManager.Instance.AllEffectObject != null)
			{
				this.mItemMove_1.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
				this.mItemMove_1.SetActive(false);
				this.mItemMove_1.SetActive(true);
			}
			this.mItemMove_1 = null;
		}
		if (this.mItemMove_2 != null)
		{
			if (this.mItemMove_2.activeSelf && ParticleManager.Instance.AllEffectObject != null)
			{
				this.mItemMove_2.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
				this.mItemMove_2.SetActive(false);
				this.mItemMove_2.SetActive(true);
			}
			this.mItemMove_2 = null;
		}
		if (this.PetBackEffect != null)
		{
			ParticleManager.Instance.DeSpawn(this.PetBackEffect);
			this.PetBackEffect = null;
		}
		if (!this.PM.IsShowOpen)
		{
			this.PM.IsShowOpen = true;
		}
		if (this.AssetKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKey, true);
		}
		if (this.Cstr_TitleName != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_TitleName);
		}
		if (this.Cstr_PetName != null)
		{
			StringManager.Instance.DeSpawnString(this.Cstr_PetName);
		}
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				if (this.Cstr_ItemCount[i][j] != null)
				{
					StringManager.Instance.DeSpawnString(this.Cstr_ItemCount[i][j]);
				}
				if (this.Cstr_ItemCount1[i][j] != null)
				{
					StringManager.Instance.DeSpawnString(this.Cstr_ItemCount1[i][j]);
				}
				if (this.Cstr_ItemCount2[i][j] != null)
				{
					StringManager.Instance.DeSpawnString(this.Cstr_ItemCount2[i][j]);
				}
				if (this.Cstr_ItemCount3[i][j] != null)
				{
					StringManager.Instance.DeSpawnString(this.Cstr_ItemCount3[i][j]);
				}
			}
		}
	}

	// Token: 0x0600162A RID: 5674 RVA: 0x0025D720 File Offset: 0x0025B920
	public override void UpdateTime(bool bOnSecond)
	{
		if (this.bShowArrow)
		{
			this.CheckTimer -= Time.deltaTime;
			if (this.CheckTimer <= 0f)
			{
				this.CheckTimer = 0.5f;
			}
			if (Mathf.Abs(this.mArrowY - this.mContentRT.anchoredPosition.y) > 10f)
			{
				this.bShowArrow = false;
				this.Img_Hand.gameObject.SetActive(false);
			}
		}
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				if (this.PetItem_T[i][j] != null && this.PetItem_T[i][j].gameObject.activeSelf && this.mLightRT[i][j] != null)
				{
					this.mLightRT[i][j].Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
				}
			}
		}
		if (!this.bABInitial && this.AR != null && this.AR.isDone)
		{
			this.BookModel = this.mBookPosT.GetChild(0).GetComponent<Transform>();
			if (this.BookModel != null)
			{
				this.tmpAN = this.BookModel.GetComponent<Animation>();
				this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
				this.tmpAN.wrapMode = WrapMode.Loop;
				this.tmpAN["open"].layer = 1;
				this.tmpAN["open"].wrapMode = WrapMode.Default;
				this.tmpAN["idle"].layer = 0;
				this.tmpAN["idle"].wrapMode = WrapMode.Loop;
				this.tmpAN["jizz"].layer = 1;
				this.tmpAN["jizz"].wrapMode = WrapMode.Default;
				this.tmpAN.clip = this.tmpAN.GetClip("idle");
				this.tmpAN.Play("idle");
				this.tmpAN.CrossFade("open");
				if (this.BookModel.gameObject.activeSelf)
				{
					SkinnedMeshRenderer componentInChildren = this.BookModel.GetComponentInChildren<SkinnedMeshRenderer>();
					componentInChildren.useLightProbes = false;
					componentInChildren.updateWhenOffscreen = true;
				}
			}
			this.bABInitial = true;
		}
		if (!this.bBookOpenEnd && this.bABInitial && this.BookModel != null && this.tmpAN != null && !this.tmpAN.IsPlaying("open"))
		{
			this.bBookOpenEnd = true;
		}
		if (!this.bOPenEnd || !this.bBookOpenEnd)
		{
			return;
		}
		if (this.mStatus == 0)
		{
			if (this.bStarShow)
			{
				if ((int)this.mShowItemNum < this.PM.mItemCraftList.Count)
				{
					this.mShowItemTime += Time.smoothDeltaTime;
					if (!this.bPlayJizz && this.tmpAN != null)
					{
						this.tmpAN.CrossFade("jizz", 0.2f);
						this.bPlayJizz = true;
					}
					if (this.mShowItemTime < this.mTotalTime / 2f)
					{
						if (this.mShowItemNum < 8)
						{
							this.bezierEnd = new Vector2((float)(-277 + (int)(180 * (this.mShowItemNum % 4))), 115f - this.mScrollDis * (float)(this.mShowItemNum / 4));
						}
						else
						{
							int num = this.PM.mItemCraftList.Count % 4;
							if ((num == 0 && this.PM.mItemCraftList.Count - 4 <= (int)this.mShowItemNum) || (num > 0 && this.PM.mItemCraftList.Count - num <= (int)this.mShowItemNum))
							{
								this.bezierEnd = new Vector2((float)(-277 + (int)(180 * (this.mShowItemNum % 4))), -83f);
							}
							else
							{
								this.bezierEnd = new Vector2((float)(-277 + (int)(180 * (this.mShowItemNum % 4))), -25f);
							}
						}
						if (this.mItemMove_1 == null)
						{
							this.mItemMove_1 = ParticleManager.Instance.Spawn(437, this.mItemParticleRT.transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
							this.mItemMove_1.transform.localPosition = new Vector3(0f, 0f, 0f);
							this.mItemMove_1.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
							this.GUIM.SetLayer(this.mItemMove_1, 5);
						}
						if (this.mItemMove_2 == null)
						{
							this.mItemMove_2 = ParticleManager.Instance.Spawn(438, this.mItemParticle_MoveRT.transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
							this.mItemMove_2.transform.localPosition = new Vector3(0f, 0f, 0f);
							this.mItemMove_2.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
							this.GUIM.SetLayer(this.mItemMove_2, 5);
						}
						this.mItemParticle_MoveRT.anchoredPosition = Vector2.Lerp(this.tmpParticle, this.bezierEnd, this.mShowItemTime / (this.mTotalTime / 2f));
					}
					else
					{
						this.mItemParticle_MoveRT.anchoredPosition = this.bezierEnd;
						this.mShowItemTime = 0f;
						this.IsShowItem[(int)this.mShowItemNum] = true;
						this.mShowItemNum += 1;
						this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
						this.mScrollTime = 0f;
						this.mStatus = 4;
						AudioManager.Instance.PlayUISFX(UIKind.PetFly);
					}
				}
				else
				{
					this.bStarShow = false;
					this.Img_EXIT.gameObject.SetActive(true);
					this.bShowArrow = true;
					this.mArrowY = this.mContentRT.anchoredPosition.y;
					this.Img_ChangeStatus.gameObject.SetActive(false);
					this.mBookPosT.gameObject.SetActive(false);
				}
			}
		}
		else if (this.mStatus == 1)
		{
			this.mShowItemTime += Time.smoothDeltaTime;
			if (!this.bPet3DClose && !this.bPet3DShow && !this.bPetNextOne && this.EffectParticle == null)
			{
				this.EffectParticle = ParticleManager.Instance.Spawn(439, this.mItemParticleRT.transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
				this.EffectParticle.transform.localPosition = new Vector3(0f, 0f, 0f);
				this.EffectParticle.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
				GUIManager.Instance.SetLayer(this.EffectParticle, 5);
				this.mPetPosRT.anchoredPosition = new Vector2(0f, 100f);
				this.mPetPosRT.localScale = Vector3.zero;
				if (!this.bPlayJizz && this.tmpAN != null)
				{
					this.tmpAN.CrossFade("jizz", 0.2f);
					this.bPlayJizz = true;
				}
				if (!this.bLoadPet3D)
				{
					if (!this.mPetRT.gameObject.activeSelf)
					{
						this.mPetRT.gameObject.SetActive(true);
					}
					this.LoadPet3D();
				}
				AudioManager.Instance.PlayUISFX(ref this.controller, UIKind.DrawLotStart);
			}
			if (!this.Img_PetStone.gameObject.activeSelf && this.mShowItemTime >= 0.36f)
			{
				this.Img_PetStone.gameObject.SetActive(true);
			}
			if (!this.bPet3DShow)
			{
				if (this.mShowItemTime < 1.1f)
				{
					this.mStone_Move = this.mStone_Start;
					this.mStone_End = this.mStone_Start;
					this.Img_PetStone.rectTransform.anchoredPosition = this.mStone_Start;
				}
				else if (this.mShowItemTime < 1.2f)
				{
					this.mStone_Move = this.mStone_Start;
					this.mStone_End = this.mStone_Start + new Vector2(-20f, -20f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.1f) / 0.1f);
				}
				else if (this.mShowItemTime < 1.3f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(-20f, -20f);
					this.mStone_End = this.mStone_Start + new Vector2(20f, -13f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.2f) / 0.1f);
				}
				else if (this.mShowItemTime < 1.4f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(20f, -13f);
					this.mStone_End = this.mStone_Start + new Vector2(-5f, 30f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.3f) / 0.1f);
				}
				else if (this.mShowItemTime < 1.5f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(-5f, 30f);
					this.mStone_End = this.mStone_Start + new Vector2(-16f, -40f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.4f) / 0.1f);
				}
				else if (this.mShowItemTime < 1.57f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(-16f, -40f);
					this.mStone_End = this.mStone_Start + new Vector2(-15f, 10f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.5f) / 0.07f);
				}
				else if (this.mShowItemTime < 1.63f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(-15f, 10f);
					this.mStone_End = this.mStone_Start + new Vector2(0f, 10f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.57f) / 0.06f);
				}
				else if (this.mShowItemTime < 1.67f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(0f, 10f);
					this.mStone_End = this.mStone_Start + new Vector2(10f, 0f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.63f) / 0.03f);
				}
				else if (this.mShowItemTime < 1.7f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(10f, 0f);
					this.mStone_End = this.mStone_Start + new Vector2(0f, 10f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.67f) / 0.03f);
				}
				else if (this.mShowItemTime < 1.73f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(0f, 10f);
					this.mStone_End = this.mStone_Start + new Vector2(10f, 0f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.7f) / 0.03f);
				}
				else if (this.mShowItemTime < 1.76f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(10f, 0f);
					this.mStone_End = this.mStone_Start + new Vector2(0f, 10f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.73f) / 0.03f);
				}
				else if (this.mShowItemTime < 1.83f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(0f, 10f);
					this.mStone_End = this.mStone_Start + new Vector2(-10f, 10f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.76f) / 0.03f);
				}
				else if (this.mShowItemTime < 1.87f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(-10f, 10f);
					this.mStone_End = this.mStone_Start + new Vector2(0f, 0f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.83f) / 0.04f);
				}
				else if (this.mShowItemTime < 1.9f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(0f, 0f);
					this.mStone_End = this.mStone_Start + new Vector2(-10f, 10f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.87f) / 0.03f);
				}
				else if (this.mShowItemTime < 1.93f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(-10f, 10f);
					this.mStone_End = this.mStone_Start + new Vector2(0f, 0f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.9f) / 0.03f);
				}
				else if (this.mShowItemTime < 1.96f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(0f, 0f);
					this.mStone_End = this.mStone_Start + new Vector2(-10f, 0f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.93f) / 0.03f);
				}
				else if (this.mShowItemTime < 2.03f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(-10f, 0f);
					this.mStone_End = this.mStone_Start + new Vector2(0f, 10f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 1.96f) / 0.07f);
				}
				else if (this.mShowItemTime < 2.06f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(0f, 10f);
					this.mStone_End = this.mStone_Start + new Vector2(-10f, 0f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 2.03f) / 0.03f);
				}
				else if (this.mShowItemTime < 2.1f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(-10f, 0f);
					this.mStone_End = this.mStone_Start + new Vector2(10f, 10f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 2.06f) / 0.04f);
				}
				else if (this.mShowItemTime < 2.16f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(10f, 10f);
					this.mStone_End = this.mStone_Start + new Vector2(10f, 0f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 2.1f) / 0.05f);
				}
				else if (this.mShowItemTime < 2.2f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(10f, 0f);
					this.mStone_End = this.mStone_Start + new Vector2(-10f, 0f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 2.16f) / 0.04f);
				}
				else if (this.mShowItemTime < 2.23f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(-10f, 0f);
					this.mStone_End = this.mStone_Start + new Vector2(0f, 10f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 2.2f) / 0.03f);
				}
				else if (this.mShowItemTime < 2.26f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(0f, 10f);
					this.mStone_End = this.mStone_Start + new Vector2(-10f, 0f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 2.23f) / 0.03f);
				}
				else if (this.mShowItemTime < 2.3f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(-10f, 0f);
					this.mStone_End = this.mStone_Start + new Vector2(0f, 10f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 2.26f) / 0.04f);
				}
				else if (this.mShowItemTime < 2.36f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(0f, 10f);
					this.mStone_End = this.mStone_Start + new Vector2(-20f, 0f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 2.3f) / 0.06f);
				}
				else if (this.mShowItemTime < 2.4f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(-20f, 0f);
					this.mStone_End = this.mStone_Start + new Vector2(0f, 10f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 2.36f) / 0.04f);
				}
				else if (this.mShowItemTime < 2.46f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(0f, 10f);
					this.mStone_End = this.mStone_Start + new Vector2(-10f, 10f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 2.4f) / 0.06f);
				}
				else if (this.mShowItemTime < 2.56f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(-10f, 10f);
					this.mStone_End = this.mStone_Start + new Vector2(-20f, 30f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 2.46f) / 0.1f);
				}
				else if (this.mShowItemTime < 2.67f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(-20f, 30f);
					this.mStone_End = this.mStone_Start + new Vector2(-60f, 10f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 2.56f) / 0.11f);
				}
				else if (this.mShowItemTime < 2.9f)
				{
					this.mStone_Move = this.mStone_Start + new Vector2(-60f, 10f);
					this.mStone_End = this.mStone_Start + new Vector2(-23f, 46f);
					this.Img_PetStone.rectTransform.anchoredPosition = Vector2.Lerp(this.mStone_Move, this.mStone_End, (this.mShowItemTime - 2.67f) / 0.23f);
				}
				else
				{
					this.Img_PetStone.rectTransform.anchoredPosition = this.mStone_Start;
				}
				if (this.mShowItemTime < 0.5f)
				{
					this.scaleCount = 0f;
				}
				else if (this.mShowItemTime < 0.8f)
				{
					this.scaleCount = Mathf.Lerp(0f, 0.8f, (this.mShowItemTime - 0.5f) / 0.3f);
				}
				else if (this.mShowItemTime < 1.1f)
				{
					this.scaleCount = Mathf.Lerp(0.8f, 0.4f, (this.mShowItemTime - 0.8f) / 0.3f);
				}
				else if (this.mShowItemTime < 1.3f)
				{
					this.scaleCount = Mathf.Lerp(0.4f, 0.5f, (this.mShowItemTime - 1.1f) / 0.2f);
				}
				else if (this.mShowItemTime < 2.4f)
				{
					this.scaleCount = 0.5f;
				}
				else if (this.mShowItemTime < 2.53f)
				{
					this.scaleCount = Mathf.Lerp(0.5f, 3f, (this.mShowItemTime - 2.53f) / 0.13f);
				}
				else if (this.mShowItemTime < 3.23f)
				{
					this.scaleCount = Mathf.Lerp(3f, 10f, (this.mShowItemTime - 2.53f) / 0.6f);
				}
				else
				{
					this.scaleCount = 10f;
				}
				this.Img_PetStone.rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
				if (this.mShowItemTime < 0.5f)
				{
					this.scaleCount = 0f;
				}
				else if (this.mShowItemTime < 0.67f)
				{
					this.scaleCount = Mathf.Lerp(0f, 0.5f, (this.mShowItemTime - 0.5f) / 0.17f);
				}
				else if (this.mShowItemTime < 1.1f)
				{
					this.scaleCount = Mathf.Lerp(0.5f, 0.8f, (this.mShowItemTime - 0.67f) / 0.43f);
				}
				else if (this.mShowItemTime < 2.4f)
				{
					this.scaleCount = Mathf.Lerp(0.8f, 1f, (this.mShowItemTime - 1.1f) / 1.3f);
				}
				else if (this.mShowItemTime < 2.77f)
				{
					this.scaleCount = Mathf.Lerp(1f, 0f, (this.mShowItemTime - 2.4f) / 0.37f);
				}
				else
				{
					this.scaleCount = 0f;
				}
				this.Img_PetStone.color = new Color(1f, 1f, 1f, this.scaleCount);
				if (this.mShowItemTime >= 2.5f)
				{
					if (this.mShowItemTime < 2.7f)
					{
						this.scaleCount = Mathf.Lerp(0f, 1f, (this.mShowItemTime - 2.5f) / 0.2f);
						this.mPetPosRT.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
						this.mPetPosRT.anchoredPosition = Vector2.Lerp(new Vector2(0f, 100f), this.tmpPetLocal, (this.mShowItemTime - 2.5f) / 0.2f);
					}
					else
					{
						this.Img_Light.gameObject.SetActive(true);
						this.Img_Light_2.gameObject.SetActive(true);
						this.Img_Rare.gameObject.SetActive(true);
						this.PetTitleText.gameObject.SetActive(true);
						this.PetNameText.gameObject.SetActive(true);
						if (this.AB_Pet == null)
						{
							this.Hbtm_Pet.gameObject.SetActive(true);
						}
						this.bPet3DShow = true;
						this.scaleCount = 1f;
						this.mPetPosRT.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
						this.mPetPosRT.anchoredPosition = this.tmpPetLocal;
						this.Img_PetStone.color = new Color(1f, 1f, 1f, 0f);
					}
				}
				if (this.mShowItemTime >= 2.4f && this.Pet_Move_2 == null)
				{
					this.Pet_Move_2 = ParticleManager.Instance.Spawn(434, this.mItemParticleRT.transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
					this.Pet_Move_2.transform.localPosition = new Vector3(0f, 0f, 0f);
					this.Pet_Move_2.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
					this.GUIM.SetLayer(this.Pet_Move_2, 5);
					AudioManager.Instance.PlayUISFX(UIKind.GainPetRookie);
				}
			}
			if (this.bPet3DShow && !this.bPet3DClose && this.mShowItemTime > 10f && this.Img_wave != null && this.Img_hand != null && !this.Img_wave.gameObject.activeSelf)
			{
				this.Img_wave.gameObject.SetActive(true);
				this.Img_hand.gameObject.SetActive(true);
			}
			if (this.bPet3DShow && this.bPet3DClose && !this.bPetNextOne)
			{
				this.Img_PetStone.color = new Color(1f, 1f, 1f, 0f);
				if (this.Pet_Move_1 == null)
				{
					this.mParticle_MoveRT.anchoredPosition = Vector2.zero;
					this.Pet_Move_1 = ParticleManager.Instance.Spawn(435, this.mParticle_MoveRT.transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
					this.Pet_Move_1.transform.localPosition = new Vector3(0f, 0f, 0f);
					this.Pet_Move_1.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
					this.GUIM.SetLayer(this.Pet_Move_1, 5);
					AudioManager.Instance.PlayUISFX(UIKind.PetAppear);
				}
				if (this.mShowItemTime < 0.7f)
				{
					this.scaleCount = Mathf.Lerp(1f, 1.2f, this.mShowItemTime / 0.7f);
					this.mPetPosRT.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
				}
				else if (this.mShowItemTime < 0.9f)
				{
					if (this.Hbtm_Pet.gameObject.activeSelf)
					{
						this.Hbtm_Pet.gameObject.SetActive(false);
					}
					this.scaleCount = Mathf.Lerp(1.2f, 0.3f, (this.mShowItemTime - 0.7f) / 0.2f);
					this.mPetPosRT.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
					this.mPetPosRT.anchoredPosition = Vector2.Lerp(this.tmpPetLocal, new Vector2(this.tmpPetLocal.x, this.tmpPetLocal.y + 100f), (this.mShowItemTime - 0.7f) / 0.2f);
				}
				else if (this.mShowItemTime < 1f)
				{
					this.scaleCount = Mathf.Lerp(0.3f, 0f, (this.mShowItemTime - 0.9f) / 0.1f);
					this.mPetPosRT.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
					this.mPetPosRT.anchoredPosition = new Vector2(this.tmpPetLocal.x, this.tmpPetLocal.y + 100f);
				}
				else if (this.mShowItemTime < 1.4f)
				{
					this.scaleCount = 0f;
					this.mPetPosRT.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
					this.mPetPosRT.anchoredPosition = new Vector2(this.tmpPetLocal.x, this.tmpPetLocal.y + 100f);
					this.Img_Light.gameObject.SetActive(false);
					this.Img_Light_2.gameObject.SetActive(false);
					this.Img_Rare.gameObject.SetActive(false);
					this.PetTitleText.gameObject.SetActive(false);
					this.PetNameText.gameObject.SetActive(false);
					if (this.mShowItemNum < 8)
					{
						this.bezierEnd = new Vector2((float)(-272 + (int)(180 * (this.mShowItemNum % 4))), (float)(117 - 140 * (this.mShowItemNum / 4)));
					}
					else
					{
						this.tmpCount = this.PM.mItemCraftList.Count % 4;
						if (this.tmpCount == 0)
						{
							this.tmpCount = 4;
						}
						if ((int)this.mShowItemNum < this.PM.mItemCraftList.Count - this.tmpCount)
						{
							this.bezierEnd = new Vector2((float)(-272 + (int)(183 * (this.mShowItemNum % 4))), -101f);
						}
						else
						{
							this.bezierEnd = new Vector2((float)(-272 + (int)(183 * (this.mShowItemNum % 4))), -231f);
						}
					}
					this.mPetRT.anchoredPosition = Vector2.Lerp(new Vector2(0f, -100f), this.bezierEnd, (this.mShowItemTime - 1f) / 0.4f);
					this.mParticle_MoveRT.anchoredPosition = Vector2.Lerp(this.tmpPetLocal, this.bezierEnd, (this.mShowItemTime - 1f) / 0.4f);
					if (this.Pet_Move_3 == null)
					{
						this.Pet_Move_3 = ParticleManager.Instance.Spawn(436, this.mParticle_MoveRT.transform, new Vector3(0f, 0f, 0f), 1f, true, true, true);
						this.Pet_Move_3.transform.localPosition = new Vector3(0f, 0f, 0f);
						this.Pet_Move_3.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
						this.GUIM.SetLayer(this.Pet_Move_3, 5);
					}
				}
				else if (this.mShowItemTime >= 1.4f)
				{
					this.bPetNextOne = true;
				}
			}
			if (this.bPet3DClose && this.bPet3DShow && this.bPetNextOne)
			{
				this.mShowItemTime = 0f;
				this.mScrollTime = 0f;
				this.IsShowItem[(int)this.mShowItemNum] = true;
				this.mShowItemNum += 1;
				this.mStatus = 2;
				this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
				if (this.mShowItemNum > 4 && this.mShowItemNum % 4 == 0)
				{
					this.bStarMove = true;
				}
				this.bPet3DClose = false;
				this.bPet3DShow = false;
				this.bPetNextOne = false;
				this.DestroyPet3D();
				this.mPetRT.gameObject.SetActive(false);
				AudioManager.Instance.PlayUISFX(UIKind.PetFly);
			}
		}
		else if (this.mStatus == 2 || this.mStatus == 4)
		{
			if (this.mShowItemNum <= 0)
			{
				return;
			}
			this.mScrollTime += Time.smoothDeltaTime;
			byte b = (this.mShowItemNum - 1) / 4 % 5;
			byte b2 = (this.mShowItemNum - 1) % 4;
			if (this.bPlayJizz)
			{
				this.bPlayJizz = false;
			}
			if (this.mScrollTime < 0.03f)
			{
				this.scaleCount = Mathf.Lerp(1f, 1.2f, this.mScrollTime / 0.03f);
				this.mItemRT[(int)b][(int)b2].localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
			}
			else if (this.mScrollTime < 0.13f)
			{
				this.scaleCount = Mathf.Lerp(1.2f, 1f, (this.mScrollTime - 0.03f) / 0.1f);
				this.mItemRT[(int)b][(int)b2].localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
			}
			else if (this.mScrollTime < 0.26f)
			{
				this.scaleCount = Mathf.Lerp(1f, 1.5f, (this.mScrollTime - 0.13f) / 0.13f);
				this.mItemRT[(int)b][(int)b2].localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
			}
			else if (this.mScrollTime < 0.46f)
			{
				this.scaleCount = Mathf.Lerp(1.5f, 1f, (this.mScrollTime - 0.26f) / 0.2f);
				this.mItemRT[(int)b][(int)b2].localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
			}
			else
			{
				if (this.mStatus == 2)
				{
					if (this.PM.mPetItemNum < this.mShowItemNum + 1)
					{
						this.mStatus = 0;
						this.bStarShow = true;
						this.mPetRT.gameObject.SetActive(false);
						this.Img_BG.gameObject.SetActive(false);
					}
					else
					{
						this.mStatus = 1;
					}
					this.mPetPosRT.anchoredPosition = this.tmpPetLocal;
					this.mParticle_MoveRT.anchoredPosition = this.tmpPetLocal;
					if (this.EffectParticle != null)
					{
						if (this.EffectParticle.activeSelf && ParticleManager.Instance.AllEffectObject != null)
						{
							this.EffectParticle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
							this.EffectParticle.SetActive(false);
							this.EffectParticle.SetActive(true);
						}
						this.EffectParticle = null;
					}
					if (this.Pet_Move_1 != null)
					{
						if (this.Pet_Move_1.activeSelf && ParticleManager.Instance.AllEffectObject != null)
						{
							this.Pet_Move_1.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
							this.Pet_Move_1.SetActive(false);
							this.Pet_Move_1.SetActive(true);
						}
						this.Pet_Move_1 = null;
					}
					if (this.Pet_Move_3 != null)
					{
						if (this.Pet_Move_3.activeSelf && ParticleManager.Instance.AllEffectObject != null)
						{
							this.Pet_Move_3.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
							this.Pet_Move_3.SetActive(false);
							this.Pet_Move_3.SetActive(true);
						}
						this.Pet_Move_3 = null;
					}
				}
				else
				{
					this.mStatus = 3;
				}
				this.mScrollTime = 0f;
				this.mShowItemTime = 0f;
				this.scaleCount = 1f;
				this.mItemRT[(int)b][(int)b2].localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
			}
		}
		else if (this.mStatus == 3)
		{
			if (this.mShowItemNum <= 0)
			{
				return;
			}
			this.mScrollTime += Time.smoothDeltaTime;
			byte b3 = (this.mShowItemNum - 1) / 4 % 5;
			byte b4 = (this.mShowItemNum - 1) % 4;
			if (this.mScrollTime < this.mTotalTime / 4f)
			{
				this.scaleCount = Mathf.Lerp(1f, 1.75f, this.mScrollTime / (this.mTotalTime / 4f));
				if (this.GUIM.IsArabic)
				{
					this.text_ItemCount3[(int)b3][(int)b4].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
				}
				else
				{
					this.text_ItemCount3[(int)b3][(int)b4].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
				}
				if (!this.text_ItemCount3[(int)b3][(int)b4].gameObject.activeSelf)
				{
					this.text_ItemCount3[(int)b3][(int)b4].gameObject.SetActive(true);
				}
				this.tmpItemCraftD = this.PM.mItemCraftList[(int)(this.mShowItemNum - 1)];
				if (this.tmpItemCraftD.mItemKind == 29)
				{
					if (this.tmpItemCraftD.mPetEnhance == 2 && !this.text_ItemCount[(int)b3][(int)b4].gameObject.activeSelf)
					{
						this.scaleCount = 1f;
						if (this.GUIM.IsArabic)
						{
							this.text_ItemCount[(int)b3][(int)b4].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
						}
						else
						{
							this.text_ItemCount[(int)b3][(int)b4].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
						}
						this.text_ItemCount[(int)b3][(int)b4].gameObject.SetActive(true);
					}
					else if (this.tmpItemCraftD.mPetEnhance < 2 && !this.text_ItemCount1[(int)b3][(int)b4].gameObject.activeSelf)
					{
						this.scaleCount = 1f;
						if (this.GUIM.IsArabic)
						{
							this.text_ItemCount1[(int)b3][(int)b4].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
						}
						else
						{
							this.text_ItemCount1[(int)b3][(int)b4].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
						}
						this.text_ItemCount1[(int)b3][(int)b4].gameObject.SetActive(true);
						this.text_ItemCount2[(int)b3][(int)b4].gameObject.SetActive(true);
					}
				}
				this.scaleCount = Mathf.Lerp(1f, 2f, this.mScrollTime / (this.mTotalTime / 4f));
				if (this.text_ItemCount1[(int)b3][(int)b4].gameObject.activeSelf)
				{
					if (this.GUIM.IsArabic)
					{
						this.text_ItemCount1[(int)b3][(int)b4].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
					}
					else
					{
						this.text_ItemCount1[(int)b3][(int)b4].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
					}
					this.text_ItemCount1[(int)b3][(int)b4].rectTransform.anchoredPosition = new Vector2(-23f - (this.scaleCount - 1f) * 20f, this.text_ItemCount1[(int)b3][(int)b4].rectTransform.anchoredPosition.y);
				}
				if (this.text_ItemCount[(int)b3][(int)b4].gameObject.activeSelf)
				{
					if (this.GUIM.IsArabic)
					{
						this.text_ItemCount[(int)b3][(int)b4].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
					}
					else
					{
						this.text_ItemCount[(int)b3][(int)b4].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
					}
				}
			}
			else if (this.mScrollTime < this.mTotalTime / 2f)
			{
				this.scaleCount = Mathf.Lerp(1.75f, 1f, (this.mScrollTime - this.mTotalTime / 4f) / (this.mTotalTime / 4f));
				if (this.GUIM.IsArabic)
				{
					this.text_ItemCount3[(int)b3][(int)b4].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
				}
				else
				{
					this.text_ItemCount3[(int)b3][(int)b4].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
				}
				this.scaleCount = Mathf.Lerp(2f, 1f, (this.mScrollTime - this.mTotalTime / 4f) / (this.mTotalTime / 4f));
				if (this.text_ItemCount1[(int)b3][(int)b4].gameObject.activeSelf)
				{
					this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.tmpItemCraftD.ItemID);
					this.tmpPT = this.PM.PetTable.GetRecordByKey(this.tmpEQ.SyntheticParts[0].SyntheticItem);
					if (this.tmpItemCraftD.Num >= this.PM.GetEvoNeed_Stone(this.tmpItemCraftD.mPetEnhance, this.tmpPT.Rare))
					{
						this.text_ItemCount1[(int)b3][(int)b4].color = Color.green;
					}
					if (this.GUIM.IsArabic)
					{
						this.text_ItemCount1[(int)b3][(int)b4].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
					}
					else
					{
						this.text_ItemCount1[(int)b3][(int)b4].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
					}
					this.text_ItemCount1[(int)b3][(int)b4].rectTransform.anchoredPosition = new Vector2(-23f - (this.scaleCount - 1f) * 20f, this.text_ItemCount1[(int)b3][(int)b4].rectTransform.anchoredPosition.y);
				}
				if (this.text_ItemCount[(int)b3][(int)b4].gameObject.activeSelf)
				{
					if (this.GUIM.IsArabic)
					{
						this.text_ItemCount[(int)b3][(int)b4].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
					}
					else
					{
						this.text_ItemCount[(int)b3][(int)b4].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
					}
				}
			}
			else
			{
				this.scaleCount = 1f;
				if (this.GUIM.IsArabic)
				{
					this.text_ItemCount3[(int)b3][(int)b4].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
				}
				else
				{
					this.text_ItemCount3[(int)b3][(int)b4].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
				}
				this.scaleCount = 1f;
				if (this.text_ItemCount1[(int)b3][(int)b4].gameObject.activeSelf)
				{
					if (this.GUIM.IsArabic)
					{
						this.text_ItemCount1[(int)b3][(int)b4].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
					}
					else
					{
						this.text_ItemCount1[(int)b3][(int)b4].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
					}
					this.text_ItemCount1[(int)b3][(int)b4].rectTransform.anchoredPosition = new Vector2(-23f - (this.scaleCount - 1f) * 20f, this.text_ItemCount1[(int)b3][(int)b4].rectTransform.anchoredPosition.y);
				}
				if (this.text_ItemCount[(int)b3][(int)b4].gameObject.activeSelf)
				{
					if (this.GUIM.IsArabic)
					{
						this.text_ItemCount[(int)b3][(int)b4].rectTransform.localScale = new Vector3(-this.scaleCount, this.scaleCount, this.scaleCount);
					}
					else
					{
						this.text_ItemCount[(int)b3][(int)b4].rectTransform.localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
					}
				}
				if (this.mShowItemNum > 4 && this.mShowItemNum % 4 == 0)
				{
					this.bStarMove = true;
				}
				this.mStatus = 0;
				this.mScrollTime = 0f;
				if (this.mItemMove_1 != null)
				{
					if (this.mItemMove_1.activeSelf && ParticleManager.Instance.AllEffectObject != null)
					{
						this.mItemMove_1.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
						this.mItemMove_1.gameObject.SetActive(false);
						this.mItemMove_1.gameObject.SetActive(true);
					}
					this.mItemMove_1 = null;
				}
				if (this.mItemMove_2 != null)
				{
					if (this.mItemMove_2.activeSelf && ParticleManager.Instance.AllEffectObject != null)
					{
						this.mItemMove_2.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
						this.mItemMove_2.gameObject.SetActive(false);
						this.mItemMove_2.gameObject.SetActive(true);
					}
					this.mItemMove_2 = null;
				}
				this.mItemParticle_MoveRT.anchoredPosition = this.tmpParticle;
			}
		}
		if (this.bStarMove && this.mContentRT != null)
		{
			if (this.mScrollY + this.mScrollDis + 478f >= this.mContentRT.sizeDelta.y)
			{
				this.mScrollDis = this.mContentRT.sizeDelta.y - (this.mScrollY + 478f);
			}
			if (this.mScrollDis < 0f)
			{
				this.mScrollDis = 0f;
			}
			this.mScrollTime += Time.smoothDeltaTime;
			if (this.mScrollTime < this.mTotalTime / 2f)
			{
				this.mContentRT.anchoredPosition = new Vector2(this.mContentRT.anchoredPosition.x, this.mScrollY + this.mScrollDis * (this.mScrollTime / this.mTotalTime));
			}
			else
			{
				this.mContentRT.anchoredPosition = new Vector2(this.mContentRT.anchoredPosition.x, this.mScrollY + this.mScrollDis);
				this.bStarMove = false;
				this.mScrollTime = 0f;
				this.mScrollY += this.mScrollDis;
			}
		}
		if (!this.bAB_PetInitial && this.AB_Pet != null && this.AR_Pet != null && this.AR_Pet.isDone)
		{
			this.PetGO = ModelLoader.Instance.Load(this.sHero.Modle, this.AB_Pet, (ushort)this.sHero.TextureNo);
			this.PetGO.transform.SetParent(this.mPetPosRT, false);
			Quaternion localRotation = new Quaternion(0f, 0f, 0f, 0f);
			localRotation.eulerAngles = new Vector3(0f, (float)this.sHero.Camera_Horizontal, 0f);
			this.PetGO.transform.localRotation = localRotation;
			if ((int)this.mShowItemNum < this.PM.mItemCraftList.Count)
			{
				this.tmpItemCraftD = this.PM.mItemCraftList[(int)this.mShowItemNum];
			}
			this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.tmpItemCraftD.ItemID);
			this.tmpPT = this.PM.PetTable.GetRecordByKey(this.tmpEQ.SyntheticParts[0].SyntheticItem);
			this.mPetscaleCount = (float)this.tmpPT.StartupRatio.Ratio;
			this.PetGO.transform.localScale = new Vector3(this.mPetscaleCount, this.mPetscaleCount, this.mPetscaleCount);
			this.GUIM.SetLayer(this.PetGO, 5);
			this.PetModel = this.mPetPosRT.GetChild(0).GetComponent<Transform>();
			if (this.PetModel != null)
			{
				this.tmpAN_Pet = this.PetModel.GetComponent<Animation>();
				this.tmpAN_Pet.wrapMode = WrapMode.Loop;
				this.tmpAN_Pet.cullingType = AnimationCullingType.AlwaysAnimate;
				this.tmpAN_Pet.Play("idle");
				this.tmpAN_Pet.clip = this.tmpAN_Pet.GetClip("idle");
				if (this.PetModel.gameObject.activeSelf)
				{
					SkinnedMeshRenderer componentInChildren2 = this.PetModel.GetComponentInChildren<SkinnedMeshRenderer>();
					componentInChildren2.useLightProbes = false;
					componentInChildren2.updateWhenOffscreen = true;
				}
			}
			this.bAB_PetInitial = true;
		}
	}

	// Token: 0x0600162B RID: 5675 RVA: 0x00260DF0 File Offset: 0x0025EFF0
	public void Refresh_FontTexture()
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
		if (this.PetTitleText != null && this.PetTitleText.enabled)
		{
			this.PetTitleText.enabled = false;
			this.PetTitleText.enabled = true;
		}
		if (this.PetNameText != null && this.PetNameText.enabled)
		{
			this.PetNameText.enabled = false;
			this.PetNameText.enabled = true;
		}
		if (this.text_Rare != null && this.text_Rare.enabled)
		{
			this.text_Rare.enabled = false;
			this.text_Rare.enabled = true;
		}
		if (this.text_HintName != null && this.text_HintName.enabled)
		{
			this.text_HintName.enabled = false;
			this.text_HintName.enabled = true;
		}
		if (this.text_HintRare != null && this.text_HintRare.enabled)
		{
			this.text_HintRare.enabled = false;
			this.text_HintRare.enabled = true;
		}
		if (this.text_HintRare2 != null && this.text_HintRare2.enabled)
		{
			this.text_HintRare2.enabled = false;
			this.text_HintRare2.enabled = true;
		}
		if (this.text_HintInfo != null && this.text_HintInfo.enabled)
		{
			this.text_HintInfo.enabled = false;
			this.text_HintInfo.enabled = true;
		}
		for (int i = 0; i < 5; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				if (this.text_ItemName[i][j] != null && this.text_ItemName[i][j].enabled)
				{
					this.text_ItemName[i][j].enabled = false;
					this.text_ItemName[i][j].enabled = true;
				}
				if (this.text_ItemCount[i][j] != null && this.text_ItemCount[i][j].enabled)
				{
					this.text_ItemCount[i][j].enabled = false;
					this.text_ItemCount[i][j].enabled = true;
				}
				if (this.text_ItemCount1[i][j] != null && this.text_ItemCount1[i][j].enabled)
				{
					this.text_ItemCount1[i][j].enabled = false;
					this.text_ItemCount1[i][j].enabled = true;
				}
				if (this.text_ItemCount2[i][j] != null && this.text_ItemCount2[i][j].enabled)
				{
					this.text_ItemCount2[i][j].enabled = false;
					this.text_ItemCount2[i][j].enabled = true;
				}
				if (this.text_ItemCount3[i][j] != null && this.text_ItemCount3[i][j].enabled)
				{
					this.text_ItemCount3[i][j].enabled = false;
					this.text_ItemCount3[i][j].enabled = true;
				}
				if (this.Hbtn_PetItems[i][j] != null && this.Hbtn_PetItems[i][j].enabled)
				{
					this.Hbtn_PetItems[i][j].Refresh_FontTexture();
				}
				if (this.Hbtn_Items[i][j] != null && this.Hbtn_Items[i][j].enabled)
				{
					this.Hbtn_Items[i][j].Refresh_FontTexture();
				}
			}
		}
	}

	// Token: 0x0600162C RID: 5676 RVA: 0x00261200 File Offset: 0x0025F400
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Login)
		{
			if (networkNews != NetworkNews.Refresh_Item)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.Refresh_FontTexture();
				}
			}
			else
			{
				this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false, true);
			}
		}
	}

	// Token: 0x0600162D RID: 5677 RVA: 0x00261254 File Offset: 0x0025F454
	public void LoadPet3D()
	{
		this.bLoadPet3D = true;
		this.mPetRT.anchoredPosition = new Vector2(0f, -100f);
		this.mPetRT.localScale = Vector3.one;
		this.Hbtm_Pet.gameObject.SetActive(false);
		CString cstring = StringManager.Instance.StaticString1024();
		if ((int)this.mShowItemNum < this.PM.mItemCraftList.Count)
		{
			this.tmpItemCraftD = this.PM.mItemCraftList[(int)this.mShowItemNum];
		}
		this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.tmpItemCraftD.ItemID);
		this.tmpPT = this.PM.PetTable.GetRecordByKey(this.tmpEQ.SyntheticParts[0].SyntheticItem);
		this.sHero = this.DM.HeroTable.GetRecordByKey(this.tmpPT.HeroID);
		cstring.ClearString();
		cstring.IntToFormat((long)this.sHero.Modle, 5, false);
		cstring.AppendFormat("Role/hero_{0}");
		if (this.sHero.Modle > 0 && AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, this.sHero.Modle, false))
		{
			this.AB_Pet = AssetManager.GetAssetBundle(cstring, out this.AssetKeyPet);
			if (this.AB_Pet != null)
			{
				this.AR_Pet = this.AB_Pet.LoadAsync("m", typeof(GameObject));
				this.bAB_PetInitial = false;
			}
		}
		else
		{
			this.AB_Pet = null;
		}
		this.Cstr_PetName.ClearString();
		this.Cstr_PetName.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.tmpPT.Name));
		this.Cstr_PetName.AppendFormat(this.DM.mStringTable.GetStringByID(10104u));
		this.PetNameText.text = this.Cstr_PetName.ToString();
		this.PetNameText.SetAllDirty();
		this.PetNameText.cachedTextGenerator.Invalidate();
		this.PetNameText.cachedTextGeneratorForLayout.Invalidate();
		this.Img_Rare.rectTransform.anchoredPosition = new Vector2(-(this.PetNameText.preferredWidth / 2f) - 30f, this.Img_Rare.rectTransform.anchoredPosition.y);
		this.text_Rare.text = this.tmpPT.Rare.ToString();
		this.text_Rare.SetAllDirty();
		this.text_Rare.cachedTextGenerator.Invalidate();
		this.tmpPetLocal = new Vector2(this.mPetPosRT.anchoredPosition.x, (float)(0 - (1000 - this.tmpPT.StartupRatio.UpDownDist)));
		this.GUIM.ChangeHeroItemImg(this.Hbtm_Pet.transform, eHeroOrItem.Pet, this.tmpItemCraftD.mPetID, this.tmpItemCraftD.ItemRank, 0, 0);
	}

	// Token: 0x0600162E RID: 5678 RVA: 0x00261570 File Offset: 0x0025F770
	public void DestroyPet3D()
	{
		this.bLoadPet3D = false;
		if (this.PetGO != null)
		{
			ModelLoader.Instance.Unload(this.PetGO);
			this.PetGO = null;
		}
		if (this.PetModel != null)
		{
			UnityEngine.Object.Destroy(this.PetModel);
			this.PetModel = null;
		}
		if (this.AssetKeyPet != 0)
		{
			AssetManager.UnloadAssetBundle(this.AssetKeyPet, false);
		}
	}

	// Token: 0x0600162F RID: 5679 RVA: 0x002615E8 File Offset: 0x0025F7E8
	private void Start()
	{
	}

	// Token: 0x06001630 RID: 5680 RVA: 0x002615EC File Offset: 0x0025F7EC
	private void Update()
	{
	}

	// Token: 0x04004196 RID: 16790
	private DataManager DM;

	// Token: 0x04004197 RID: 16791
	private GUIManager GUIM;

	// Token: 0x04004198 RID: 16792
	private PetManager PM;

	// Token: 0x04004199 RID: 16793
	private Transform GameT;

	// Token: 0x0400419A RID: 16794
	private Transform Tmp;

	// Token: 0x0400419B RID: 16795
	private Transform Tmp1;

	// Token: 0x0400419C RID: 16796
	private Transform Tmp2;

	// Token: 0x0400419D RID: 16797
	private Transform[][] PetItem_T = new Transform[5][];

	// Token: 0x0400419E RID: 16798
	private Transform[][] Item_T = new Transform[5][];

	// Token: 0x0400419F RID: 16799
	private Transform mBookPosT;

	// Token: 0x040041A0 RID: 16800
	private Transform mParticlePosT;

	// Token: 0x040041A1 RID: 16801
	private Transform PetModel;

	// Token: 0x040041A2 RID: 16802
	private Transform BookModel;

	// Token: 0x040041A3 RID: 16803
	private RectTransform mContentRT;

	// Token: 0x040041A4 RID: 16804
	private RectTransform mPetRT;

	// Token: 0x040041A5 RID: 16805
	private RectTransform mPetPosRT;

	// Token: 0x040041A6 RID: 16806
	private RectTransform mParticle_MoveRT;

	// Token: 0x040041A7 RID: 16807
	private RectTransform mItemParticleRT;

	// Token: 0x040041A8 RID: 16808
	private RectTransform mItemParticle_MoveRT;

	// Token: 0x040041A9 RID: 16809
	private RectTransform[][] mLightRT = new RectTransform[5][];

	// Token: 0x040041AA RID: 16810
	private RectTransform[][] mItemRT = new RectTransform[5][];

	// Token: 0x040041AB RID: 16811
	private Font TTFont = GUIManager.Instance.GetTTFFont();

	// Token: 0x040041AC RID: 16812
	private Door door;

	// Token: 0x040041AD RID: 16813
	private UISpritesArray spArray;

	// Token: 0x040041AE RID: 16814
	private UIButton btn_EXIT;

	// Token: 0x040041AF RID: 16815
	private UIButton btn_ChangeStatus;

	// Token: 0x040041B0 RID: 16816
	private UIButton[][] btn_PetInfo = new UIButton[5][];

	// Token: 0x040041B1 RID: 16817
	private Image Img_EXIT;

	// Token: 0x040041B2 RID: 16818
	private Image Img_Hand;

	// Token: 0x040041B3 RID: 16819
	private Image Img_BG;

	// Token: 0x040041B4 RID: 16820
	private Image Img_ChangeStatus;

	// Token: 0x040041B5 RID: 16821
	private Image Img_PetStone;

	// Token: 0x040041B6 RID: 16822
	private Image Img_Light;

	// Token: 0x040041B7 RID: 16823
	private Image Img_Light_2;

	// Token: 0x040041B8 RID: 16824
	private Image Img_Rare;

	// Token: 0x040041B9 RID: 16825
	private Image Img_wave;

	// Token: 0x040041BA RID: 16826
	private Image Img_hand;

	// Token: 0x040041BB RID: 16827
	private Image[][] Img_ItemBG1 = new Image[5][];

	// Token: 0x040041BC RID: 16828
	private Image[][] Img_ItemBG2 = new Image[5][];

	// Token: 0x040041BD RID: 16829
	private Image Img_ItemHint;

	// Token: 0x040041BE RID: 16830
	private Image Img_ItemRare;

	// Token: 0x040041BF RID: 16831
	private UIText TitleNameText;

	// Token: 0x040041C0 RID: 16832
	private UIText GetAllText;

	// Token: 0x040041C1 RID: 16833
	private UIText PetTitleText;

	// Token: 0x040041C2 RID: 16834
	private UIText PetNameText;

	// Token: 0x040041C3 RID: 16835
	private UIText text_Rare;

	// Token: 0x040041C4 RID: 16836
	private UIText[][] text_ItemName = new UIText[5][];

	// Token: 0x040041C5 RID: 16837
	private UIText[][] text_ItemCount = new UIText[5][];

	// Token: 0x040041C6 RID: 16838
	private UIText[][] text_ItemCount1 = new UIText[5][];

	// Token: 0x040041C7 RID: 16839
	private UIText[][] text_ItemCount2 = new UIText[5][];

	// Token: 0x040041C8 RID: 16840
	private UIText[][] text_ItemCount3 = new UIText[5][];

	// Token: 0x040041C9 RID: 16841
	private UIText text_HintName;

	// Token: 0x040041CA RID: 16842
	private UIText text_HintRare;

	// Token: 0x040041CB RID: 16843
	private UIText text_HintRare2;

	// Token: 0x040041CC RID: 16844
	private UIText text_HintInfo;

	// Token: 0x040041CD RID: 16845
	private UIHIBtn Hbtm_ItemCraft;

	// Token: 0x040041CE RID: 16846
	private UIHIBtn Hbtm_Pet;

	// Token: 0x040041CF RID: 16847
	private UIHIBtn[][] Hbtn_PetItems = new UIHIBtn[5][];

	// Token: 0x040041D0 RID: 16848
	private UIHIBtn[][] Hbtn_Items = new UIHIBtn[5][];

	// Token: 0x040041D1 RID: 16849
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040041D2 RID: 16850
	private ScrollPanelItem[] tmpItem = new ScrollPanelItem[5];

	// Token: 0x040041D3 RID: 16851
	private List<float> tmplist = new List<float>();

	// Token: 0x040041D4 RID: 16852
	private bool[] IsShowItem = new bool[200];

	// Token: 0x040041D5 RID: 16853
	private byte mShowItemNum;

	// Token: 0x040041D6 RID: 16854
	private float mShowItemTime;

	// Token: 0x040041D7 RID: 16855
	private bool bStarShow;

	// Token: 0x040041D8 RID: 16856
	private byte mStatus;

	// Token: 0x040041D9 RID: 16857
	private bool bShowNewPet;

	// Token: 0x040041DA RID: 16858
	private CString Cstr_TitleName;

	// Token: 0x040041DB RID: 16859
	private CString Cstr_PetName;

	// Token: 0x040041DC RID: 16860
	private CString[][] Cstr_ItemCount = new CString[5][];

	// Token: 0x040041DD RID: 16861
	private CString[][] Cstr_ItemCount1 = new CString[5][];

	// Token: 0x040041DE RID: 16862
	private CString[][] Cstr_ItemCount2 = new CString[5][];

	// Token: 0x040041DF RID: 16863
	private CString[][] Cstr_ItemCount3 = new CString[5][];

	// Token: 0x040041E0 RID: 16864
	private int AssetKey;

	// Token: 0x040041E1 RID: 16865
	private AssetBundle AB;

	// Token: 0x040041E2 RID: 16866
	private AssetBundleRequest AR;

	// Token: 0x040041E3 RID: 16867
	private bool bABInitial;

	// Token: 0x040041E4 RID: 16868
	private int AssetKeyPet;

	// Token: 0x040041E5 RID: 16869
	private AssetBundle AB_Pet;

	// Token: 0x040041E6 RID: 16870
	private AssetBundleRequest AR_Pet;

	// Token: 0x040041E7 RID: 16871
	private bool bAB_PetInitial = true;

	// Token: 0x040041E8 RID: 16872
	private GameObject PetGO;

	// Token: 0x040041E9 RID: 16873
	private Animation tmpAN;

	// Token: 0x040041EA RID: 16874
	private Animation tmpAN_Pet;

	// Token: 0x040041EB RID: 16875
	private float mScrollTime;

	// Token: 0x040041EC RID: 16876
	private bool bStarMove;

	// Token: 0x040041ED RID: 16877
	private float mScrollY;

	// Token: 0x040041EE RID: 16878
	private float mScrollDis = 140f;

	// Token: 0x040041EF RID: 16879
	private float mTotalTime = 0.4f;

	// Token: 0x040041F0 RID: 16880
	private float CheckTimer;

	// Token: 0x040041F1 RID: 16881
	private bool bShowArrow;

	// Token: 0x040041F2 RID: 16882
	private float mArrowY;

	// Token: 0x040041F3 RID: 16883
	private float scaleCount;

	// Token: 0x040041F4 RID: 16884
	private float mPetscaleCount;

	// Token: 0x040041F5 RID: 16885
	private int tmpCount;

	// Token: 0x040041F6 RID: 16886
	private Equip tmpEQ;

	// Token: 0x040041F7 RID: 16887
	private PetTbl tmpPT;

	// Token: 0x040041F8 RID: 16888
	private ItemCraftDataType tmpItemCraftD;

	// Token: 0x040041F9 RID: 16889
	private GameObject mItemMove_1;

	// Token: 0x040041FA RID: 16890
	private GameObject mItemMove_2;

	// Token: 0x040041FB RID: 16891
	private Vector2 tmpParticle;

	// Token: 0x040041FC RID: 16892
	private Hero sHero;

	// Token: 0x040041FD RID: 16893
	public bool bPet3DClose;

	// Token: 0x040041FE RID: 16894
	public bool bPet3DShow;

	// Token: 0x040041FF RID: 16895
	public bool bPetNextOne;

	// Token: 0x04004200 RID: 16896
	public bool bBookOpenEnd;

	// Token: 0x04004201 RID: 16897
	public bool bLoadPet3D;

	// Token: 0x04004202 RID: 16898
	public bool bOPenEnd;

	// Token: 0x04004203 RID: 16899
	public bool bPlayJizz;

	// Token: 0x04004204 RID: 16900
	private GameObject EffectParticle;

	// Token: 0x04004205 RID: 16901
	private GameObject Pet_Move_1;

	// Token: 0x04004206 RID: 16902
	private GameObject Pet_Move_2;

	// Token: 0x04004207 RID: 16903
	private GameObject Pet_Move_3;

	// Token: 0x04004208 RID: 16904
	private GameObject PetBackEffect;

	// Token: 0x04004209 RID: 16905
	private Vector2 bezierEnd;

	// Token: 0x0400420A RID: 16906
	private Vector2 tmpPetLocal;

	// Token: 0x0400420B RID: 16907
	private Vector2 mStone_Start;

	// Token: 0x0400420C RID: 16908
	private Vector2 mStone_Move;

	// Token: 0x0400420D RID: 16909
	private Vector2 mStone_End;

	// Token: 0x0400420E RID: 16910
	private Equip tmpEquip;

	// Token: 0x0400420F RID: 16911
	private AudioSourceController controller;

	// Token: 0x04004210 RID: 16912
	private UIButtonHint hint;
}
