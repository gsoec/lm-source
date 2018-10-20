using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using uTools;

// Token: 0x02000568 RID: 1384
public class UIHeroList : GUIWindow, IUpDateRowItem, IUIButtonClickHandler
{
	// Token: 0x06001B8E RID: 7054 RVA: 0x0030D324 File Offset: 0x0030B524
	public override void OnOpen(int arg1, int arg2)
	{
		DataManager.SortHeroData();
		this.SetFragmentHeroData();
		if (NewbieManager.IsTeachWorking(ETeachKind.PUTON_EQUIP))
		{
			DataManager instance = DataManager.Instance;
			Array.Copy(instance.sortHeroData, NewbieManager.Get().sortHeroDataCache, instance.MaxCurHeroData);
			int num = Array.IndexOf<uint>(instance.sortHeroData, 1u);
			if (num != -1)
			{
				instance.sortHeroData[num] = instance.sortHeroData[0];
				instance.sortHeroData[0] = 1u;
			}
		}
		this.SetEqipData();
		this.PageType = UIHeroList.e_HeroListPageTpye.OwnedPage;
		this.bInitScrollView = false;
		this.spriteArray = base.gameObject.transform.GetComponent<UISpritesArray>();
		this.heroTypeSprite[0] = this.spriteArray.GetSprite(3);
		this.heroTypeSprite[1] = this.spriteArray.GetSprite(4);
		this.heroTypeSprite[2] = this.spriteArray.GetSprite(5);
		this.equipSprite[0] = this.spriteArray.GetSprite(0);
		this.equipSprite[1] = this.spriteArray.GetSprite(1);
		this.equipSprite[2] = this.spriteArray.GetSprite(2);
		Transform child = base.gameObject.transform.GetChild(1);
		Image component = child.GetComponent<Image>();
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			component.sprite = door.LoadSprite("UI_main_close_base");
			component.material = door.LoadMaterial();
			if (GUIManager.Instance.bOpenOnIPhoneX && component)
			{
				component.enabled = false;
			}
		}
		child = base.gameObject.transform.GetChild(1).GetChild(0);
		this.exitButton = child.GetComponent<UIButton>();
		this.exitButton.m_Handler = this;
		this.exitButton.m_BtnID1 = 1;
		this.exitButton.image.sprite = door.LoadSprite("UI_main_close");
		this.exitButton.image.material = door.LoadMaterial();
		child = base.gameObject.transform.GetChild(5);
		this.ownedPageButton = child.GetComponent<UIButton>();
		this.ownedPageButton.m_Handler = this;
		this.ownedPageButton.m_BtnID1 = 2;
		this.ownedPageButton.SoundIndex = 3;
		this.tabBtnFlashImage[0] = child.GetChild(0).GetComponent<Image>();
		child = base.gameObject.transform.GetChild(8);
		this.noOwnedPageButton = child.GetComponent<UIButton>();
		this.noOwnedPageButton.m_Handler = this;
		this.noOwnedPageButton.m_BtnID1 = 3;
		this.noOwnedPageButton.SoundIndex = 3;
		this.tabBtnFlashImage[1] = child.GetChild(0).GetComponent<Image>();
		child = base.gameObject.transform.GetChild(7);
		this.ownedPageImage = child.GetComponent<Image>();
		child = base.gameObject.transform.GetChild(9);
		this.noOwnedPageImage = child.GetComponent<Image>();
		child = base.gameObject.transform.GetChild(11);
		this.itemPageImage = child.GetComponent<Image>();
		child = base.transform.GetChild(10);
		this.itemPageButton = child.GetComponent<UIButton>();
		this.itemPageButton.m_Handler = this;
		this.itemPageButton.m_BtnID1 = 4;
		this.itemPageButton.SoundIndex = 3;
		this.tabBtnFlashImage[2] = child.GetChild(0).GetComponent<Image>();
		this.frameMat = GUIManager.Instance.GetFrameMaterial();
		for (int i = 0; i < 2; i++)
		{
			child = base.transform.GetChild(14 + i);
			this.scrollBlack[i] = child.GetComponent<Image>();
			this.scrollBlack[i].sprite = GUIManager.Instance.LoadFrameSprite("UI_shared_black");
			this.scrollBlack[i].material = this.frameMat;
		}
		child = base.gameObject.transform.GetChild(3);
		if (child)
		{
			this.scrollView = child.GetComponent<ScrollView>();
		}
		UIText component2;
		if (this.scrollView)
		{
			Transform child2 = this.scrollView.customItem.transform.GetChild(0).GetChild(1);
			GUIManager.Instance.InitianHeroItemImg(child2, eHeroOrItem.Hero, 0, 0, 0, 0, true, false, true, false);
			for (int j = 0; j < 6; j++)
			{
				child2 = this.scrollView.customItem.transform.GetChild(0).GetChild(3 + j).GetChild(0);
				GUIManager.Instance.InitianHeroItemImg(child2, eHeroOrItem.Item, 0, 0, 0, 0, false, true, true, false);
			}
			component2 = this.scrollView.customItem.transform.GetChild(0).GetChild(13).GetComponent<UIText>();
			if (component2 != null)
			{
				component2.resizeTextForBestFit = true;
				component2.resizeTextMinSize = 10;
				component2.resizeTextMaxSize = 22;
			}
			this.scrollView.gameObject.SetActive(true);
		}
		this.PageType = (UIHeroList.e_HeroListPageTpye)(GUIManager.Instance.HeroListSaved & 3);
		if (NewbieManager.IsWorking())
		{
			this.PageType = UIHeroList.e_HeroListPageTpye.OwnedPage;
		}
		this.itemTabIndex = (byte)(GUIManager.Instance.HeroListSaved >> 2);
		this.itemPage = (RectTransform)base.transform.GetChild(4);
		for (int k = 0; k < this.itemTabButton.Length; k++)
		{
			child = this.itemPage.GetChild(k + 3);
			this.itemTabButton[k] = child.GetComponent<UIButton>();
			this.itemTabButton[k].m_Handler = this;
			this.TabButtonA[k] = child.GetChild(0).GetComponent<CanvasGroup>();
			child = child.GetChild(1);
			RectTransform rectTransform = child as RectTransform;
			Vector2 sizeDelta = rectTransform.sizeDelta;
			sizeDelta.x = -20.5f;
			rectTransform.sizeDelta = sizeDelta;
			this.TabText[k] = child.GetComponent<UIText>();
			this.TabText[k].font = GUIManager.Instance.GetTTFFont();
			this.TabText[k].text = DataManager.Instance.mStringTable.GetStringByID((uint)(253 + this.itemTabButton[k].m_BtnID2));
			this.TabText[k].fontStyle = FontStyle.Normal;
		}
		this.TabTextColor = this.TabText[0].color;
		this.noRecruitmentText = base.gameObject.transform.GetChild(16).GetComponent<UIText>();
		this.noRecruitmentText.font = GUIManager.Instance.GetTTFFont();
		this.noRecruitmentText.text = DataManager.Instance.mStringTable.GetStringByID(492u);
		this.ExpTf = base.gameObject.transform.GetChild(17);
		component2 = this.ExpTf.GetChild(1).GetChild(2).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID(739u);
		UIButton component3 = this.ExpTf.GetChild(1).GetComponent<UIButton>();
		component3.m_Handler = this;
		component3.m_BtnID1 = 97;
		this.CheckExpItem();
		this.BtnExclamationImage = base.gameObject.transform.GetChild(18).GetComponent<Image>();
		if (door && door.m_FuncBtnCount[0] != 0)
		{
			this.BtnExclamationImage.gameObject.SetActive(true);
		}
		else
		{
			this.BtnExclamationImage.gameObject.SetActive(false);
		}
		this.InitOpenCheckBox();
		if (!GUIManager.Instance.m_IsOpenedUISynthesis)
		{
			this.SetPage(this.PageType);
		}
		else
		{
			this.PageType = UIHeroList.e_HeroListPageTpye.NoOwnedPage;
			this.SetPage(this.PageType);
		}
		if (!NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, this, false))
		{
			NewbieManager.CheckTeach(ETeachKind.NEW_HERO, this, false);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x06001B8F RID: 7055 RVA: 0x0030DAF4 File Offset: 0x0030BCF4
	private void InitScrollView()
	{
		this.bInitScrollView = false;
		float posY;
		float[] array;
		float height;
		int[] array2;
		ScrollViewIndexValue value;
		int initDataSize;
		int num;
		if (this.PageType == UIHeroList.e_HeroListPageTpye.OwnedPage)
		{
			posY = DataManager.Instance.OwnedPagePosY;
			array = DataManager.Instance.OwnedPagePosYArray;
			height = DataManager.Instance.OwnedPageContentHeight;
			array2 = DataManager.Instance.OwnedPageIDArray;
			value = DataManager.Instance.OwnedPageScrollValue;
			initDataSize = (int)Mathf.Clamp((float)((ulong)DataManager.Instance.CurHeroDataCount + (ulong)((long)this.fragmentHeroIDMaxCount)), 0f, 15f);
			num = (int)(DataManager.Instance.CurHeroDataCount + (uint)this.fragmentHeroIDMaxCount);
		}
		else
		{
			posY = DataManager.Instance.NoOwnedPagePosY;
			array = DataManager.Instance.NoOwnedPagePosYArray;
			height = DataManager.Instance.NoOwnedPageContentYHeight;
			array2 = DataManager.Instance.NoOwnedPageIDArray;
			value = DataManager.Instance.NoOwnedPageScrollValue;
			initDataSize = Mathf.Clamp(this.fragmentHeroIDCount, 0, 15);
			num = this.fragmentHeroIDCount;
		}
		if (array == null || array2 == null)
		{
			this.scrollView.AddHender(this, false, initDataSize, num, 0f, null, 0f, null, default(ScrollViewIndexValue));
			this.scrollView.SetContentSize(num);
		}
		else
		{
			this.scrollView.AddHender(this, false, initDataSize, num, posY, array, height, array2, value);
			this.scrollView.SetContentSize(num);
			this.scrollView.SetContentPos(posY, null, 0f, null, default(ScrollViewIndexValue));
			this.scrollView.UpDateAllItem();
		}
		Transform child = base.gameObject.transform.GetChild(3);
		this.scrolCont = child.GetChild(0).GetComponent<RectTransform>();
		this.scrollRect = child.GetComponent<CScrollRect>();
	}

	// Token: 0x06001B90 RID: 7056 RVA: 0x0030DCB0 File Offset: 0x0030BEB0
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
		case NetworkNews.Refresh_Item:
			break;
		default:
			if (networkNews != NetworkNews.Refresh_HeroExclamation)
			{
				if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
				{
					return;
				}
				this.Refresh_FontTexture();
				return;
			}
			break;
		case NetworkNews.Refresh_Hero:
			this.UpdateNetworkNews(false);
			return;
		}
		this.UpdateNetworkNews(true);
	}

	// Token: 0x06001B91 RID: 7057 RVA: 0x0030DD1C File Offset: 0x0030BF1C
	public void UpdateNetworkNews(bool bNeedSetEqipData)
	{
		if (!NewbieManager.IsTeachWorking(ETeachKind.PUTON_EQUIP))
		{
			DataManager.SortHeroData();
		}
		this.SetFragmentHeroData();
		if (bNeedSetEqipData)
		{
			this.SetEqipData();
		}
		if (this.PageType == UIHeroList.e_HeroListPageTpye.OwnedPage)
		{
			this.CheckExpItem();
			this.OnButtonClick(this.ownedPageButton);
		}
		else if (this.PageType == UIHeroList.e_HeroListPageTpye.NoOwnedPage)
		{
			this.OnButtonClick(this.noOwnedPageButton);
		}
		else
		{
			this.UpdateItemPage();
		}
	}

	// Token: 0x06001B92 RID: 7058 RVA: 0x0030DD94 File Offset: 0x0030BF94
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 0)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door.m_FuncBtnCount[0] != 0)
			{
				this.BtnExclamationImage.gameObject.SetActive(true);
			}
			else
			{
				this.BtnExclamationImage.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001B93 RID: 7059 RVA: 0x0030DDF8 File Offset: 0x0030BFF8
	private void SetEqipData()
	{
		DataManager instance = DataManager.Instance;
		ushort num = 0;
		this.EqipData.Clear();
		int num2 = 0;
		while ((long)num2 < (long)((ulong)instance.CurHeroDataCount))
		{
			HeroEquip item = new HeroEquip(0);
			uint key = instance.sortHeroData[num2];
			if (instance.curHeroData.ContainsKey(key))
			{
				CurHeroData curHeroData = instance.curHeroData[key];
				for (int i = 0; i < 6; i++)
				{
					Enhance recordByKey = DataManager.Instance.EnhanceTable.GetRecordByKey(curHeroData.ID);
					int num3 = (int)((curHeroData.Enhance - 1) * 6) + i;
					if (num3 >= 0 && recordByKey.EnhanceNumber != null && num3 < recordByKey.EnhanceNumber.Length)
					{
						num = recordByKey.EnhanceNumber[num3];
					}
					Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(num);
					int num4 = curHeroData.Equip >> i & 1;
					item.IsEquip[i] = ((num4 != 0) ? true : false);
					item.EquipItemID[i] = num;
					item.IsFindItemComposite[i] = DataManager.Instance.FindItemComposite(num, 1);
					item.EquipNeedLv[i] = (ushort)recordByKey2.NeedLv;
				}
			}
			this.EqipData.Add(item);
			num2++;
		}
	}

	// Token: 0x06001B94 RID: 7060 RVA: 0x0030DF58 File Offset: 0x0030C158
	private void SetFragmentHeroData()
	{
		if (NewbieManager.IsTeachWorking(ETeachKind.PUTON_EQUIP))
		{
			this.fragmentHeroIDMaxCount = 0;
			return;
		}
		ushort[] array = new ushort[]
		{
			10,
			30,
			80,
			180,
			330
		};
		ushort num = 0;
		List<ushort> list = new List<ushort>();
		this.fragmentHeroIDCount = 0;
		this.fragmentHeroIDMaxCount = 0;
		DataManager.Instance.SortCurItemData();
		ushort num2 = DataManager.Instance.sortItemDataStart[4];
		ushort num3 = DataManager.Instance.sortItemDataCount[4];
		this.bHaveRecruit = false;
		ushort num4 = (ushort)Mathf.Clamp(DataManager.Instance.HeroTable.TableCount, 0, 100);
		for (ushort num5 = 0; num5 < num4; num5 += 1)
		{
			Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(num5);
			if (recordByKey.bShowHeroStone == 1)
			{
				ushort heroKey = recordByKey.HeroKey;
				if (!DataManager.Instance.curHeroData.ContainsKey((uint)recordByKey.HeroKey) && DataManager.Instance.GetCurItemQuantity(recordByKey.SoulStone, 0) <= 0)
				{
					list.Add(heroKey);
					num += 1;
				}
			}
		}
		this.fragmentHeroID = new fragmentObject[(int)(num3 + num)];
		this.fragmentHeroIDMax = new fragmentObject[(int)num3];
		for (int i = (int)num2; i < (int)(num3 + num2); i++)
		{
			ushort num6 = DataManager.Instance.sortItemData[i];
			Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(num6);
			if (!DataManager.Instance.curHeroData.ContainsKey((uint)recordByKey2.SyntheticParts[0].SyntheticItem))
			{
				ushort num7 = array[(int)(DataManager.Instance.HeroTable.GetRecordByKey(recordByKey2.SyntheticParts[0].SyntheticItem).defaultStar - 1)];
				ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(num6, 0);
				if (curItemQuantity < num7)
				{
					this.fragmentHeroID[this.fragmentHeroIDCount] = default(fragmentObject);
					this.fragmentHeroID[this.fragmentHeroIDCount].HeroID = recordByKey2.SyntheticParts[0].SyntheticItem;
					this.fragmentHeroID[this.fragmentHeroIDCount].HeroStone = curItemQuantity;
					this.fragmentHeroID[this.fragmentHeroIDCount].MaxHeroStone = num7;
					this.fragmentHeroIDCount++;
				}
				else
				{
					this.fragmentHeroIDMax[this.fragmentHeroIDMaxCount] = default(fragmentObject);
					this.fragmentHeroIDMax[this.fragmentHeroIDMaxCount].HeroID = recordByKey2.SyntheticParts[0].SyntheticItem;
					this.fragmentHeroIDMax[this.fragmentHeroIDMaxCount].HeroStone = curItemQuantity;
					this.fragmentHeroIDMax[this.fragmentHeroIDMaxCount].MaxHeroStone = num7;
					this.fragmentHeroIDMaxCount++;
					this.bHaveRecruit = true;
				}
			}
		}
		for (ushort num8 = 0; num8 < num; num8 += 1)
		{
			ushort num7 = array[(int)(DataManager.Instance.HeroTable.GetRecordByKey(list[(int)num8]).defaultStar - 1)];
			this.fragmentHeroID[this.fragmentHeroIDCount] = default(fragmentObject);
			this.fragmentHeroID[this.fragmentHeroIDCount].HeroID = list[(int)num8];
			this.fragmentHeroID[this.fragmentHeroIDCount].HeroStone = 0;
			this.fragmentHeroID[this.fragmentHeroIDCount].MaxHeroStone = num7;
			this.fragmentHeroIDCount++;
		}
	}

	// Token: 0x06001B95 RID: 7061 RVA: 0x0030E30C File Offset: 0x0030C50C
	private void SetItemByID(GameObject item, uint idx)
	{
		Hero recordByKey;
		recordByKey.HeroName = 0;
		Image component = item.transform.GetChild(15).GetComponent<Image>();
		component.gameObject.SetActive(false);
		if (this.PageType == UIHeroList.e_HeroListPageTpye.OwnedPage)
		{
			UIHIBtn component2 = item.transform.GetChild(1).GetComponent<UIHIBtn>();
			if ((ulong)idx >= (ulong)((long)this.fragmentHeroIDMaxCount))
			{
				uint num = (uint)((ulong)idx - (ulong)((long)this.fragmentHeroIDMaxCount));
				uint key = DataManager.Instance.sortHeroData[(int)((UIntPtr)num)];
				if (DataManager.Instance.curHeroData.ContainsKey(key))
				{
					CurHeroData curHeroData = DataManager.Instance.curHeroData[key];
					recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(curHeroData.ID);
					byte heroType = recordByKey.HeroType;
					GUIManager.Instance.ChangeHeroItemImg(component2.transform, eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, curHeroData.Enhance, (int)curHeroData.Level);
					this.SetItemEquipments(item, num, curHeroData.Level);
					if (heroType >= 1 && (int)heroType <= this.heroTypeSprite.Length)
					{
						item.transform.GetChild(11).GetComponent<Image>().sprite = this.heroTypeSprite[(int)(heroType - 1)];
					}
					string stringByID = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.HeroTitle);
					UIText component3 = item.transform.GetChild(12).GetComponent<UIText>();
					component3.font = GUIManager.Instance.GetTTFFont();
					component3.text = stringByID;
					component2.HIImage.color = this.EnableColor;
					component2.CircleImage.color = this.EnableColor;
					Transform child = item.transform.GetChild(2);
					child.GetComponent<Image>().sprite = this.spriteArray.GetSprite(14);
					eHeroState heroState = DataManager.Instance.GetHeroState(curHeroData.ID);
					if (heroState != eHeroState.None)
					{
						if (heroState == eHeroState.IsFighting)
						{
							component.sprite = this.spriteArray.GetSprite(18);
						}
						if (heroState == eHeroState.Captured)
						{
							component.sprite = this.spriteArray.GetSprite(19);
						}
						if (heroState == eHeroState.Dead)
						{
							component.sprite = this.spriteArray.GetSprite(20);
						}
						component.gameObject.SetActive(true);
					}
				}
			}
			else
			{
				if ((ulong)idx >= (ulong)((long)this.fragmentHeroIDMax.Length))
				{
					return;
				}
				recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.fragmentHeroIDMax[(int)((UIntPtr)idx)].HeroID);
				GUIManager.Instance.ChangeHeroItemImg(component2.transform, eHeroOrItem.Hero, this.fragmentHeroIDMax[(int)((UIntPtr)idx)].HeroID, recordByKey.defaultStar, 0, 0);
				this.SetItemFragments(item, this.fragmentHeroIDMax[(int)((UIntPtr)idx)].HeroStone, this.fragmentHeroIDMax[(int)((UIntPtr)idx)].MaxHeroStone);
				component2.HIImage.color = this.EnableColor;
				component2.CircleImage.color = this.EnableColor;
				Transform child = item.transform.GetChild(2);
				child.GetComponent<Image>().sprite = this.spriteArray.GetSprite(14);
				child = item.transform.GetChild(9);
				child.GetComponent<Image>().sprite = this.spriteArray.GetSprite(12);
				byte heroType = recordByKey.HeroType;
				if (heroType >= 1 && (int)heroType <= this.heroTypeSprite.Length)
				{
					item.transform.GetChild(11).GetComponent<Image>().sprite = this.heroTypeSprite[(int)(heroType - 1)];
				}
				string stringByID2 = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.HeroTitle);
				UIText component3 = item.transform.GetChild(12).GetComponent<UIText>();
				component3.font = GUIManager.Instance.GetTTFFont();
				component3.text = stringByID2;
			}
		}
		else if ((long)this.fragmentHeroIDCount > (long)((ulong)idx))
		{
			recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.fragmentHeroID[(int)((UIntPtr)idx)].HeroID);
			byte heroType = recordByKey.HeroType;
			UIHIBtn component2 = item.transform.GetChild(1).GetComponent<UIHIBtn>();
			GUIManager.Instance.ChangeHeroItemImg(component2.transform, eHeroOrItem.Hero, recordByKey.HeroKey, recordByKey.defaultStar, 0, 0);
			if (heroType >= 1 && (int)heroType <= this.heroTypeSprite.Length)
			{
				item.transform.GetChild(11).GetComponent<Image>().sprite = this.heroTypeSprite[(int)(heroType - 1)];
			}
			string stringByID3 = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.HeroTitle);
			UIText component3 = item.transform.GetChild(12).GetComponent<UIText>();
			component3.font = GUIManager.Instance.GetTTFFont();
			component3.text = stringByID3;
			this.SetItemFragments(item, this.fragmentHeroID[(int)((UIntPtr)idx)].HeroStone, this.fragmentHeroID[(int)((UIntPtr)idx)].MaxHeroStone);
			Transform child = item.transform.GetChild(2);
			child.GetComponent<Image>().sprite = this.spriteArray.GetSprite(15);
			component2.HIImage.color = this.DisableColor;
			component2.CircleImage.color = this.DisableColor;
		}
	}

	// Token: 0x06001B96 RID: 7062 RVA: 0x0030E834 File Offset: 0x0030CA34
	private void SetItemEquipments(GameObject item, byte Equip, ushort herID, byte enhance)
	{
		bool flag = false;
		Transform child;
		for (int i = 0; i < 6; i++)
		{
			int num = Equip >> i & 1;
			child = item.transform.GetChild(3 + i);
			Image component = child.GetComponent<Image>();
			child.gameObject.SetActive(true);
			Transform child2 = child.transform.GetChild(0);
			UIHIBtn component2 = child2.GetComponent<UIHIBtn>();
			child = item.transform.GetChild(9);
			child.gameObject.SetActive(false);
			child = item.transform.GetChild(13);
			child.gameObject.SetActive(false);
			ushort num2 = DataManager.Instance.EnhanceTable.GetRecordByKey(herID).EnhanceNumber[(int)((enhance - 1) * 6) + i];
			byte needLv = DataManager.Instance.EquipTable.GetRecordByKey(num2).NeedLv;
			if (num == 0)
			{
				if (DataManager.Instance.FindItemComposite(num2, 1))
				{
					if (DataManager.Instance.curHeroData[(uint)herID].Level >= needLv)
					{
						component.sprite = this.equipSprite[1];
						flag = true;
					}
					else
					{
						component.sprite = this.equipSprite[2];
					}
				}
				else
				{
					component.sprite = this.equipSprite[0];
				}
				component2.gameObject.SetActive(false);
			}
			else
			{
				component2.gameObject.SetActive(true);
				GUIManager.Instance.ChangeHeroItemImg(child2, eHeroOrItem.Item, num2, 0, 0, 0);
			}
		}
		child = item.transform.GetChild(14);
		Image component3 = child.GetComponent<Image>();
		if (flag)
		{
			component3.gameObject.SetActive(true);
		}
		else
		{
			component3.gameObject.SetActive(false);
		}
		child = item.transform.GetChild(10);
		Image component4 = child.GetComponent<Image>();
		component4.gameObject.SetActive(false);
		child = item.transform.GetChild(9);
		Image component5 = child.GetComponent<Image>();
		component5.gameObject.SetActive(false);
	}

	// Token: 0x06001B97 RID: 7063 RVA: 0x0030EA48 File Offset: 0x0030CC48
	private void SetItemEquipments(GameObject item, uint curHeroDataIdx, byte curHeroLevel)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = true;
		bool flag4 = false;
		curHeroDataIdx = (uint)Mathf.Clamp(curHeroDataIdx, 0f, (float)(this.EqipData.Count - 1));
		HeroEquip heroEquip = this.EqipData[(int)curHeroDataIdx];
		byte[] array = new byte[]
		{
			0,
			0,
			20,
			40
		};
		ushort[] array2 = new ushort[4];
		uint key = DataManager.Instance.sortHeroData[(int)((UIntPtr)curHeroDataIdx)];
		if (DataManager.Instance.curHeroData.ContainsKey(key))
		{
			CurHeroData curHeroData = DataManager.Instance.curHeroData[key];
			byte enhance = curHeroData.Enhance;
			if (enhance == 0 || enhance >= 8)
			{
				flag3 = false;
			}
			if (DataManager.Instance.queueBarData[11].bActive && DataManager.Instance.RoleAttr.EnhanceEventHeroID == curHeroData.ID)
			{
				flag3 = false;
			}
		}
		Transform child;
		for (int i = 0; i < 6; i++)
		{
			child = item.transform.GetChild(3 + i);
			Image component = child.GetComponent<Image>();
			child.gameObject.SetActive(true);
			Transform child2 = child.transform.GetChild(0);
			UIHIBtn component2 = child2.GetComponent<UIHIBtn>();
			child = item.transform.GetChild(9);
			child.gameObject.SetActive(false);
			child = item.transform.GetChild(13);
			child.gameObject.SetActive(false);
			if (!heroEquip.IsEquip[i])
			{
				if (heroEquip.IsFindItemComposite[i])
				{
					if ((ushort)curHeroLevel >= heroEquip.EquipNeedLv[i])
					{
						flag = true;
						component.sprite = this.equipSprite[1];
					}
					else
					{
						component.sprite = this.equipSprite[2];
					}
				}
				else
				{
					component.sprite = this.equipSprite[0];
				}
				component2.gameObject.SetActive(false);
				flag3 = false;
				component.enabled = true;
			}
			else
			{
				component2.gameObject.SetActive(true);
				GUIManager.Instance.ChangeHeroItemImg(child2, eHeroOrItem.Item, heroEquip.EquipItemID[i], 0, 0, 0);
				component.enabled = false;
			}
		}
		child = item.transform.GetChild(14);
		Image component3 = child.GetComponent<Image>();
		key = DataManager.Instance.sortHeroData[(int)((UIntPtr)curHeroDataIdx)];
		if (DataManager.Instance.curHeroData.ContainsKey(key))
		{
			CurHeroData curHeroData = DataManager.Instance.curHeroData[key];
			ushort id = curHeroData.ID;
			Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(id);
			ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(recordByKey.SoulStone, 0);
			int num = Mathf.Clamp((int)curHeroData.Star, 0, DataManager.Instance.Medal.Length - 1);
			bool flag5 = DataManager.Instance.RoleAttr.StarUpEventHeroID == curHeroData.ID && DataManager.Instance.queueBarData[12].bActive;
			if (curHeroData.Star < 5 && curItemQuantity >= (ushort)DataManager.Instance.Medal[num] && !flag5)
			{
				flag2 = true;
			}
		}
		if (flag || flag2 || flag3 || flag4)
		{
			component3.gameObject.SetActive(true);
		}
		else
		{
			component3.gameObject.SetActive(false);
		}
		child = item.transform.GetChild(10);
		Image component4 = child.GetComponent<Image>();
		component4.gameObject.SetActive(false);
		child = item.transform.GetChild(9);
		Image component5 = child.GetComponent<Image>();
		component5.gameObject.SetActive(false);
	}

	// Token: 0x06001B98 RID: 7064 RVA: 0x0030EDF4 File Offset: 0x0030CFF4
	private void SetItemFragments(GameObject item, ushort fragment, ushort maxFragment)
	{
		Transform child;
		for (int i = 0; i < 6; i++)
		{
			child = item.transform.GetChild(3 + i);
			child.gameObject.SetActive(false);
		}
		child = item.transform.GetChild(9);
		Image component = child.GetComponent<Image>();
		component.gameObject.SetActive(true);
		child = item.transform.GetChild(10);
		Image component2 = child.GetComponent<Image>();
		component2.gameObject.SetActive(false);
		this.sb.Length = 0;
		this.sb.AppendFormat("{0}/{1}", fragment, maxFragment);
		child = item.transform.GetChild(13);
		UIText component3 = child.GetComponent<UIText>();
		component3.font = GUIManager.Instance.GetTTFFont();
		child.gameObject.SetActive(true);
		child = item.transform.GetChild(14);
		Image component4 = child.GetComponent<Image>();
		if (fragment < maxFragment)
		{
			component3.text = this.sb.ToString();
			component.sprite = this.spriteArray.GetSprite(13);
			this.bFlash = false;
			component2.gameObject.SetActive(false);
			component4.gameObject.SetActive(false);
		}
		else
		{
			component3.text = DataManager.Instance.mStringTable.GetStringByID(1u);
			component.sprite = this.spriteArray.GetSprite(14);
			component2.gameObject.SetActive(true);
			this.bFlash = true;
			if (this.bHaveRecruit)
			{
				component4.gameObject.SetActive(true);
			}
			else
			{
				component4.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001B99 RID: 7065 RVA: 0x0030EFA8 File Offset: 0x0030D1A8
	private void Update()
	{
		if (this.bFlash)
		{
			this.flashTime += Time.deltaTime;
			if (this.flashTime >= 0.05f)
			{
				this.flashCount += 0.1f;
				if (this.flashCount >= 2f)
				{
					this.flashCount = 0f;
				}
				float a = (this.flashCount <= 1f) ? this.flashCount : (2f - this.flashCount);
				for (int i = 0; i < 16; i++)
				{
					if (this.flashImage[i] != null)
					{
						this.flashImage[i].color = new Color(1f, 1f, 1f, a);
					}
				}
				this.flashTime = 0f;
			}
		}
		if (this.tabBtnFlashIndex < 3 && this.tabBtnFlashImage[this.tabBtnFlashIndex] != null)
		{
			this.tabBtnTime += Time.deltaTime;
			if (this.tabBtnTime >= 0.05f)
			{
				this.tabBtnColorA += 0.05f;
				if (this.tabBtnColorA >= 2f)
				{
					this.tabBtnColorA = 0f;
				}
				float a2 = (this.tabBtnColorA <= 1f) ? this.tabBtnColorA : (2f - this.tabBtnColorA);
				this.tabBtnFlashImage[this.tabBtnFlashIndex].color = new Color(1f, 1f, 1f, a2);
				this.tabBtnTime = 0f;
			}
		}
		if (this.itemPage.gameObject.activeSelf && (int)this.itemTabIndex < this.TabButtonA.Length)
		{
			float alpha = (this.tabBtnColorA <= 1f) ? this.tabBtnColorA : (2f - this.tabBtnColorA);
			this.TabButtonA[(int)this.itemTabIndex].alpha = alpha;
		}
	}

	// Token: 0x06001B9A RID: 7066 RVA: 0x0030F1BC File Offset: 0x0030D3BC
	private void SetPage(UIHeroList.e_HeroListPageTpye type)
	{
		this.PageType = type;
		if (this.fragmentHeroIDCount == 0 && this.PageType == UIHeroList.e_HeroListPageTpye.NoOwnedPage)
		{
			this.noRecruitmentText.gameObject.SetActive(true);
		}
		else
		{
			this.noRecruitmentText.gameObject.SetActive(false);
		}
		if (type == UIHeroList.e_HeroListPageTpye.OwnedPage)
		{
			if (!this.bInitScrollView)
			{
				this.InitScrollView();
			}
			this.ownedPageImage.sprite = this.spriteArray.GetSprite(8);
			if (GUIManager.Instance.IsArabic)
			{
				this.noOwnedPageImage.sprite = this.spriteArray.GetSprite(21);
			}
			else
			{
				this.noOwnedPageImage.sprite = this.spriteArray.GetSprite(10);
			}
			this.itemPageImage.sprite = this.spriteArray.GetSprite(17);
			this.scrollRect.StopMovement();
			this.scrollView.UpdateScrollRect();
			this.CheckExpItem();
			this.scrollView.gameObject.SetActive(true);
			this.itemPage.gameObject.SetActive(false);
		}
		else if (type == UIHeroList.e_HeroListPageTpye.NoOwnedPage)
		{
			if (!this.bInitScrollView)
			{
				this.InitScrollView();
			}
			this.ownedPageImage.sprite = this.spriteArray.GetSprite(8);
			if (GUIManager.Instance.IsArabic)
			{
				this.noOwnedPageImage.sprite = this.spriteArray.GetSprite(21);
			}
			else
			{
				this.noOwnedPageImage.sprite = this.spriteArray.GetSprite(10);
			}
			this.itemPageImage.sprite = this.spriteArray.GetSprite(17);
			this.scrollRect.StopMovement();
			this.scrollView.UpdateScrollRect();
			this.ExpTf.gameObject.SetActive(false);
			if (this.fragmentHeroIDCount > 0)
			{
				this.scrollView.gameObject.SetActive(true);
			}
			this.itemPage.gameObject.SetActive(false);
		}
		else
		{
			this.ownedPageImage.sprite = this.spriteArray.GetSprite(8);
			if (GUIManager.Instance.IsArabic)
			{
				this.noOwnedPageImage.sprite = this.spriteArray.GetSprite(21);
			}
			else
			{
				this.noOwnedPageImage.sprite = this.spriteArray.GetSprite(10);
			}
			this.itemPageImage.sprite = this.spriteArray.GetSprite(17);
			this.ExpTf.gameObject.SetActive(false);
			this.scrollView.gameObject.SetActive(false);
			this.itemPage.gameObject.SetActive(true);
			this.UpdateItemPage();
		}
		this.SetTabBtnColor(this.PageType);
	}

	// Token: 0x06001B9B RID: 7067 RVA: 0x0030F478 File Offset: 0x0030D678
	private void SetTabBtnColor(UIHeroList.e_HeroListPageTpye type)
	{
		this.tabBtnColorA = 1f;
		this.tabBtnTime = 0f;
		for (int i = 0; i < 3; i++)
		{
			this.tabBtnFlashImage[i].enabled = false;
		}
		if (type == UIHeroList.e_HeroListPageTpye.OwnedPage)
		{
			this.tabBtnFlashIndex = 0;
		}
		else if (type == UIHeroList.e_HeroListPageTpye.NoOwnedPage)
		{
			this.tabBtnFlashIndex = 1;
		}
		else
		{
			this.tabBtnFlashIndex = 2;
		}
		this.tabBtnFlashImage[this.tabBtnFlashIndex].enabled = true;
		this.tabBtnFlashImage[this.tabBtnFlashIndex].color = new Color(1f, 1f, 1f, 1f);
	}

	// Token: 0x06001B9C RID: 7068 RVA: 0x0030F528 File Offset: 0x0030D728
	public void Initialized()
	{
		for (int i = 0; i < 16; i++)
		{
			Transform child = base.gameObject.transform.GetChild(3).GetChild(0).GetChild(i).GetChild(0).GetChild(10);
			this.flashImage[i] = child.GetComponent<Image>();
		}
		this.scrollBlack[0].gameObject.SetActive(false);
		this.scrollBlack[1].gameObject.SetActive(false);
		if (this.PageType == UIHeroList.e_HeroListPageTpye.OwnedPage)
		{
			this.SetPage(this.PageType);
			this.scrollView.SetContentSize((int)(DataManager.Instance.CurHeroDataCount + (uint)this.fragmentHeroIDMaxCount));
		}
		else if (this.fragmentHeroIDCount >= 0)
		{
			this.SetPage(this.PageType);
			if (GUIManager.Instance.m_UISynthesisID != 0)
			{
				GUIManager.Instance.OpenUISynthesis((int)GUIManager.Instance.m_UISynthesisID);
			}
			this.scrollView.SetContentSize(this.fragmentHeroIDCount);
		}
	}

	// Token: 0x06001B9D RID: 7069 RVA: 0x0030F62C File Offset: 0x0030D82C
	public void UpDateRowItem(GameObject[] gameObjs, int[] indexs)
	{
		if (gameObjs[0].transform.parent.parent == this.scrollView.transform)
		{
			uint num = (uint)((ulong)DataManager.Instance.CurHeroDataCount + (ulong)((long)this.fragmentHeroIDMaxCount));
			int num2 = gameObjs.Length;
			for (int i = 0; i < num2; i++)
			{
				if (this.PageType != UIHeroList.e_HeroListPageTpye.OwnedPage || (long)indexs[i] < (long)((ulong)num))
				{
					UIButton component = gameObjs[i].transform.GetChild(0).transform.GetComponent<UIButton>();
					component.m_BtnID1 = indexs[i] + 200;
					component.m_Handler = this;
					this.SetItemByID(gameObjs[i].transform.GetChild(0).gameObject, (uint)indexs[i]);
					if (indexs[i] < this.m_TempNameText.Length)
					{
						this.m_TempNameText[indexs[i]] = gameObjs[i].transform.GetChild(0).GetChild(12).GetComponent<UIText>();
					}
					if (indexs[i] < this.m_TempNameText.Length)
					{
						this.m_TempNumText[indexs[i]] = gameObjs[i].transform.GetChild(0).GetChild(12).GetComponent<UIText>();
					}
					if (indexs[i] < this.m_TempHibtn.Length)
					{
						this.m_TempHibtn[i] = gameObjs[i].transform.GetChild(0).GetChild(1).GetComponent<UIHIBtn>();
					}
				}
			}
		}
		else if (!this.bInitItemView)
		{
			for (int j = 0; j < gameObjs.Length; j++)
			{
				GUIManager.Instance.InitianHeroItemImg(gameObjs[j].transform.GetChild(0), eHeroOrItem.Item, 0, 0, 0, 0, false, false, true, false);
				gameObjs[j].AddComponent<uButtonScale>();
				RectTransform rectTransform = gameObjs[j].transform as RectTransform;
				rectTransform.pivot = new Vector2(0.5f, 0.5f);
				Vector2 anchoredPosition = rectTransform.anchoredPosition;
				anchoredPosition.Set(anchoredPosition.x + 40f, anchoredPosition.y - 40f);
				rectTransform.anchoredPosition = anchoredPosition;
				rectTransform.GetComponent<ScrollItem>().SoundIndex = 64;
				this.ItemHIBtn.Add(gameObjs[j].transform.GetChild(0).GetComponent<UIHIBtn>());
			}
		}
		else
		{
			ushort num3 = 0;
			switch (this.itemTabIndex)
			{
			case 0:
				num3 = DataManager.Instance.sortItemDataStart[5];
				break;
			case 1:
				num3 = DataManager.Instance.sortItemDataStart[3];
				break;
			case 2:
				num3 = DataManager.Instance.sortItemDataStart[2];
				break;
			case 3:
				num3 = DataManager.Instance.sortItemDataStart[4];
				break;
			case 4:
				num3 = DataManager.Instance.sortItemDataStart[0];
				break;
			}
			for (int k = 0; k < gameObjs.Length; k++)
			{
				ushort num4 = DataManager.Instance.sortItemData[(int)num3 + indexs[k]];
				GUIManager.Instance.ChangeHeroItemImg(gameObjs[k].transform.GetChild(0), eHeroOrItem.Item, num4, 0, 0, (int)DataManager.Instance.GetCurItemQuantity(num4, 0));
			}
		}
	}

	// Token: 0x06001B9E RID: 7070 RVA: 0x0030F94C File Offset: 0x0030DB4C
	public void ButtonOnClick(GameObject gameObject, int dataIndex)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (gameObject.transform.parent.parent == this.scrollView.transform)
		{
			if (this.PageType == UIHeroList.e_HeroListPageTpye.OwnedPage)
			{
				if (dataIndex < this.fragmentHeroIDMaxCount)
				{
					this.OpenCheckBox(dataIndex);
				}
				else
				{
					door.OpenMenu(EGUIWindow.UI_Hero_Info, dataIndex - this.fragmentHeroIDMaxCount, 0, true);
				}
			}
			else
			{
				Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.fragmentHeroID[dataIndex].HeroID);
				GUIManager.Instance.OpenUISynthesis((int)recordByKey.SoulStone);
			}
		}
		else
		{
			UIHIBtn component = gameObject.transform.GetChild(0).GetComponent<UIHIBtn>();
			GUIManager.Instance.m_ItemInfo.Show(EUIItemInfo.ItemList, component.HIID, 0, 0);
		}
	}

	// Token: 0x06001B9F RID: 7071 RVA: 0x0030FA2C File Offset: 0x0030DC2C
	private void InitOpenCheckBox()
	{
		this.checkPanel = base.gameObject.transform.GetChild(13);
		UIButton component = this.checkPanel.GetChild(7).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 98;
		UIButton component2 = this.checkPanel.GetChild(8).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 99;
		this.checkPanel.GetChild(8).GetComponent<UIButton>();
		UIHIBtn component3 = this.checkPanel.GetChild(5).GetComponent<UIHIBtn>();
		GUIManager.Instance.InitianHeroItemImg(component3.transform, eHeroOrItem.Hero, 0, 0, 0, 0, true, false, true, false);
		UIText component4 = this.checkPanel.GetChild(9).GetComponent<UIText>();
		component4.font = GUIManager.Instance.GetTTFFont();
		component4.text = DataManager.Instance.mStringTable.GetStringByID(3u);
		UIText component5 = this.checkPanel.GetChild(10).GetComponent<UIText>();
		component5.font = GUIManager.Instance.GetTTFFont();
		component5.text = DataManager.Instance.mStringTable.GetStringByID(4u);
		UIText component6 = this.checkPanel.GetChild(12).GetComponent<UIText>();
		component6.font = GUIManager.Instance.GetTTFFont();
		this.sb.Length = 0;
		this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(2u), 5000);
		component6.text = this.sb.ToString();
	}

	// Token: 0x06001BA0 RID: 7072 RVA: 0x0030FBBC File Offset: 0x0030DDBC
	private void OpenCheckBox(int dataIndex)
	{
		this.RecruitHeroID = this.fragmentHeroIDMax[dataIndex].HeroID;
		UIHIBtn component = this.checkPanel.GetChild(5).GetComponent<UIHIBtn>();
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.fragmentHeroIDMax[dataIndex].HeroID);
		GUIManager.Instance.ChangeHeroItemImg(component.transform, eHeroOrItem.Hero, this.fragmentHeroIDMax[dataIndex].HeroID, recordByKey.defaultStar, 0, 1);
		UIText component2 = this.checkPanel.GetChild(11).GetComponent<UIText>();
		component2.font = GUIManager.Instance.GetTTFFont();
		component2.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.HeroTitle);
		component2.resizeTextForBestFit = true;
		component2.resizeTextMinSize = 10;
		component2.resizeTextMaxSize = 22;
		this.checkPanel.gameObject.SetActive(true);
	}

	// Token: 0x06001BA1 RID: 7073 RVA: 0x0030FCA8 File Offset: 0x0030DEA8
	public void OnScroll(RectTransform rt)
	{
	}

	// Token: 0x06001BA2 RID: 7074 RVA: 0x0030FCAC File Offset: 0x0030DEAC
	public void OnButtonClick(UIButton sender)
	{
		DataManager instance = DataManager.Instance;
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (sender.m_BtnID1 >= 200)
		{
			int num = sender.m_BtnID1 - 200;
			if (this.PageType == UIHeroList.e_HeroListPageTpye.OwnedPage)
			{
				if (num < this.fragmentHeroIDMaxCount)
				{
					this.OpenCheckBox(num);
				}
				else if (door)
				{
					door.OpenMenu(EGUIWindow.UI_Hero_Info, num - this.fragmentHeroIDMaxCount, 0, true);
				}
			}
			else
			{
				Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.fragmentHeroID[num].HeroID);
				GUIManager.Instance.OpenUISynthesis((int)recordByKey.SoulStone);
			}
			return;
		}
		int btnID = sender.m_BtnID1;
		switch (btnID)
		{
		case 1:
			if (door != null)
			{
				door.CloseMenu(false);
			}
			break;
		case 2:
			if (this.scrollView != null && !this.scrollView.IsInitState())
			{
				this.SaveUIState(this.PageType);
				this.PageType = UIHeroList.e_HeroListPageTpye.OwnedPage;
				this.SetPage(this.PageType);
				this.scrollView.SetContentSize((int)(instance.CurHeroDataCount + (uint)this.fragmentHeroIDMaxCount));
				this.scrollView.SetContentPos(DataManager.Instance.OwnedPagePosY, null, 0f, null, default(ScrollViewIndexValue));
				this.scrollView.UpDateAllItem();
			}
			break;
		case 3:
			if (this.scrollView != null && !this.scrollView.IsInitState())
			{
				this.SaveUIState(this.PageType);
				this.PageType = UIHeroList.e_HeroListPageTpye.NoOwnedPage;
				this.SetPage(this.PageType);
				this.scrollView.SetContentSize(this.fragmentHeroIDCount);
				this.scrollView.SetContentPos(DataManager.Instance.NoOwnedPagePosY, null, 0f, null, default(ScrollViewIndexValue));
				this.scrollView.UpDateAllItem();
			}
			break;
		case 4:
			this.SaveUIState(this.PageType);
			if (this.scrollView != null && !this.scrollView.IsInitState())
			{
				this.SetPage(UIHeroList.e_HeroListPageTpye.ItemPage);
			}
			break;
		default:
			switch (btnID)
			{
			case 97:
				if (door)
				{
					door.OpenMenu(EGUIWindow.UI_BagFilter, 4, 0, false);
				}
				break;
			case 98:
			{
				if (this.RecruitHeroID == 0 || !instance.CheckHero3DMesh(this.RecruitHeroID))
				{
					GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8350u), 255, true);
					return;
				}
				MessagePacket messagePacket = new MessagePacket(1024);
				messagePacket.Protocol = Protocol._MSG_REQUEST_HEROCREATE;
				messagePacket.AddSeqId();
				messagePacket.Add(this.RecruitHeroID);
				messagePacket.Send(false);
				GUIManager.Instance.ShowUILock(EUILock.HeroList);
				this.checkPanel.gameObject.SetActive(false);
				break;
			}
			case 99:
				this.checkPanel.gameObject.SetActive(false);
				break;
			case 100:
				if (sender.m_BtnID2 != (int)this.itemTabIndex)
				{
					this.TabButtonA[(int)this.itemTabIndex].alpha = 0f;
					this.TabText[(int)this.itemTabIndex].color = this.TabTextColor;
					this.itemTabIndex = (byte)sender.m_BtnID2;
					this.TabText[(int)this.itemTabIndex].color = Color.white;
					this.UpdateItemPage();
				}
				break;
			}
			break;
		}
	}

	// Token: 0x06001BA3 RID: 7075 RVA: 0x00310044 File Offset: 0x0030E244
	private void UpdateItemPage()
	{
		int num = 0;
		DataManager.Instance.SortCurItemData();
		if (!this.bInitItemView)
		{
			this.TabText[(int)this.itemTabIndex].color = Color.white;
		}
		switch (this.itemTabIndex)
		{
		case 0:
			num = (int)(DataManager.Instance.sortItemDataCount[5] + DataManager.Instance.sortItemDataCount[6]);
			break;
		case 1:
			num = (int)DataManager.Instance.sortItemDataCount[3];
			break;
		case 2:
			num = (int)DataManager.Instance.sortItemDataCount[2];
			break;
		case 3:
			num = (int)DataManager.Instance.sortItemDataCount[4];
			break;
		case 4:
			num = (int)(DataManager.Instance.sortItemDataCount[0] + DataManager.Instance.sortItemDataCount[1]);
			break;
		}
		if (!this.bInitItemView)
		{
			Transform child = this.itemPage.GetChild(1);
			this.itemView = child.GetComponent<ScrollView>();
			this.itemView.AddHender(this, true, 0, 0, 0f, null, 0f, null, default(ScrollViewIndexValue));
			this.bInitItemView = true;
			this.itemCont = child.GetChild(0).GetComponent<RectTransform>();
			this.itemScrollRect = child.GetComponent<CScrollRect>();
			this.itemPage.GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(-23f, -77.54f);
			this.MessageTrans = this.itemPage.GetChild(8).GetComponent<RectTransform>();
			this.NoItemText = this.MessageTrans.GetChild(0).GetComponent<UIText>();
			this.NoItemText.font = GUIManager.Instance.GetTTFFont();
			this.NoItemText.text = DataManager.Instance.mStringTable.GetStringByID(744u);
			Vector2 sizeDelta = this.MessageTrans.sizeDelta;
			sizeDelta.x = this.NoItemText.preferredWidth + 165f;
			this.MessageTrans.sizeDelta = sizeDelta;
		}
		this.itemScrollRect.StopMovement();
		Vector2 anchoredPosition = this.itemCont.anchoredPosition;
		anchoredPosition.y = 0f;
		this.itemCont.anchoredPosition = anchoredPosition;
		this.itemView.SetContentSize(num);
		this.itemView.UpDateAllItem();
		this.ItemHIBtn.Clear();
		if (num == 0)
		{
			this.MessageTrans.gameObject.SetActive(true);
		}
		else
		{
			this.MessageTrans.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001BA4 RID: 7076 RVA: 0x003102C0 File Offset: 0x0030E4C0
	public override void OnClose()
	{
		if (this.scrollView != null && this.scrollView.CheckInitScroll())
		{
			this.SaveUIState(this.PageType);
		}
		GUIManager.Instance.HeroListSaved = (byte)(this.PageType + ((int)this.itemTabIndex << 2));
		GUIManager.Instance.m_UISynthesisID = 0;
	}

	// Token: 0x06001BA5 RID: 7077 RVA: 0x00310320 File Offset: 0x0030E520
	public void SaveUIState(UIHeroList.e_HeroListPageTpye type)
	{
		if (type == UIHeroList.e_HeroListPageTpye.OwnedPage && this.scrollView.GetItemsPos() != null && this.scrollView.GetItemsBtnID() != null)
		{
			DataManager.Instance.OwnedPagePosYArray = this.scrollView.GetItemsPos();
			DataManager.Instance.OwnedPageIDArray = this.scrollView.GetItemsBtnID();
			DataManager.Instance.OwnedPageScrollValue = this.scrollView.GetScrollViewIndexValue();
			DataManager.Instance.OwnedPagePosY = this.scrolCont.anchoredPosition.y;
			DataManager.Instance.OwnedPageContentHeight = this.scrolCont.sizeDelta.y;
		}
		if (type == UIHeroList.e_HeroListPageTpye.NoOwnedPage && this.scrollView.GetItemsPos() != null && this.scrollView.GetItemsBtnID() != null)
		{
			DataManager.Instance.NoOwnedPagePosYArray = this.scrollView.GetItemsPos();
			DataManager.Instance.NoOwnedPageIDArray = this.scrollView.GetItemsBtnID();
			DataManager.Instance.NoOwnedPageScrollValue = this.scrollView.GetScrollViewIndexValue();
			DataManager.Instance.NoOwnedPagePosY = this.scrolCont.anchoredPosition.y;
			DataManager.Instance.NoOwnedPageContentYHeight = this.scrolCont.sizeDelta.y;
		}
	}

	// Token: 0x06001BA6 RID: 7078 RVA: 0x0031046C File Offset: 0x0030E66C
	public void CheckExpItem()
	{
		DataManager.Instance.SortResourceFilterData();
		if (DataManager.Instance.sortItemDataCount[15] > 0)
		{
			this.ExpTf.gameObject.SetActive(true);
		}
		else
		{
			this.ExpTf.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001BA7 RID: 7079 RVA: 0x003104C0 File Offset: 0x0030E6C0
	public void Refresh_FontTexture()
	{
		if (this.noRecruitmentText != null && this.noRecruitmentText.enabled)
		{
			this.noRecruitmentText.enabled = false;
			this.noRecruitmentText.enabled = true;
		}
		if (this.TabText != null)
		{
			for (int i = 0; i < this.TabText.Length; i++)
			{
				if (this.TabText[i] != null && this.TabText[i].enabled)
				{
					this.TabText[i].enabled = false;
					this.TabText[i].enabled = true;
				}
			}
		}
		if (this.NoItemText != null && this.NoItemText.enabled)
		{
			this.NoItemText.enabled = false;
			this.NoItemText.enabled = true;
		}
		if (this.m_TempNameText != null)
		{
			for (int j = 0; j < this.m_TempNameText.Length; j++)
			{
				if (this.m_TempNameText[j] != null && this.m_TempNameText[j].enabled)
				{
					this.m_TempNameText[j].enabled = false;
					this.m_TempNameText[j].enabled = true;
				}
			}
		}
		if (this.m_TempNumText != null)
		{
			for (int k = 0; k < this.m_TempNumText.Length; k++)
			{
				if (this.m_TempNumText[k] != null && this.m_TempNumText[k].enabled)
				{
					this.m_TempNumText[k].enabled = false;
					this.m_TempNumText[k].enabled = true;
				}
			}
		}
		for (int l = 0; l < this.ItemHIBtn.Count; l++)
		{
			this.ItemHIBtn[l].Refresh_FontTexture();
		}
		if (this.m_TempHibtn != null)
		{
			for (int m = 0; m < this.m_TempHibtn.Length; m++)
			{
				if (this.m_TempHibtn[m] != null && this.m_TempHibtn[m].enabled)
				{
					this.m_TempHibtn[m].Refresh_FontTexture();
					this.m_TempHibtn[m].Refresh_FontTexture();
				}
			}
		}
	}

	// Token: 0x0400537D RID: 21373
	private const int MaxTabBtnFlashCount = 3;

	// Token: 0x0400537E RID: 21374
	private const int MaxTempTextNum = 20;

	// Token: 0x0400537F RID: 21375
	private UIHeroList.e_HeroListPageTpye PageType;

	// Token: 0x04005380 RID: 21376
	private StringBuilder sb = new StringBuilder();

	// Token: 0x04005381 RID: 21377
	private ScrollView scrollView;

	// Token: 0x04005382 RID: 21378
	public CScrollRect scrollRect;

	// Token: 0x04005383 RID: 21379
	public RectTransform scrolCont;

	// Token: 0x04005384 RID: 21380
	public RectTransform MessageTrans;

	// Token: 0x04005385 RID: 21381
	private Color DisableColor = new Color(0.7f, 0.7f, 0.7f, 0.7f);

	// Token: 0x04005386 RID: 21382
	private Color EnableColor = new Color(1f, 1f, 1f, 1f);

	// Token: 0x04005387 RID: 21383
	public UIButton exitButton;

	// Token: 0x04005388 RID: 21384
	private UIButton ownedPageButton;

	// Token: 0x04005389 RID: 21385
	private UIButton noOwnedPageButton;

	// Token: 0x0400538A RID: 21386
	private Image ownedPageImage;

	// Token: 0x0400538B RID: 21387
	private Image noOwnedPageImage;

	// Token: 0x0400538C RID: 21388
	private Image itemPageImage;

	// Token: 0x0400538D RID: 21389
	private UIButton itemPageButton;

	// Token: 0x0400538E RID: 21390
	private UIText noRecruitmentText;

	// Token: 0x0400538F RID: 21391
	private Transform ExpTf;

	// Token: 0x04005390 RID: 21392
	private UISpritesArray spriteArray;

	// Token: 0x04005391 RID: 21393
	private Sprite[] heroTypeSprite = new Sprite[3];

	// Token: 0x04005392 RID: 21394
	private Sprite[] equipSprite = new Sprite[3];

	// Token: 0x04005393 RID: 21395
	private fragmentObject[] fragmentHeroID;

	// Token: 0x04005394 RID: 21396
	private fragmentObject[] fragmentHeroIDMax;

	// Token: 0x04005395 RID: 21397
	private int fragmentHeroIDCount;

	// Token: 0x04005396 RID: 21398
	private int fragmentHeroIDMaxCount;

	// Token: 0x04005397 RID: 21399
	private ushort RecruitHeroID;

	// Token: 0x04005398 RID: 21400
	private bool bFlash;

	// Token: 0x04005399 RID: 21401
	private float flashCount;

	// Token: 0x0400539A RID: 21402
	private Image[] flashImage = new Image[16];

	// Token: 0x0400539B RID: 21403
	private float flashTime;

	// Token: 0x0400539C RID: 21404
	private int tabBtnFlashIndex;

	// Token: 0x0400539D RID: 21405
	private Image[] tabBtnFlashImage = new Image[3];

	// Token: 0x0400539E RID: 21406
	private float tabBtnColorA = 1f;

	// Token: 0x0400539F RID: 21407
	private float tabBtnTime;

	// Token: 0x040053A0 RID: 21408
	private Image[] scrollBlack = new Image[2];

	// Token: 0x040053A1 RID: 21409
	private Material frameMat;

	// Token: 0x040053A2 RID: 21410
	private Image BtnExclamationImage;

	// Token: 0x040053A3 RID: 21411
	public Transform checkPanel;

	// Token: 0x040053A4 RID: 21412
	private RectTransform itemPage;

	// Token: 0x040053A5 RID: 21413
	private UIButton[] itemTabButton = new UIButton[5];

	// Token: 0x040053A6 RID: 21414
	private UIText[] TabText = new UIText[5];

	// Token: 0x040053A7 RID: 21415
	private UIText NoItemText;

	// Token: 0x040053A8 RID: 21416
	private CanvasGroup[] TabButtonA = new CanvasGroup[5];

	// Token: 0x040053A9 RID: 21417
	private Color TabTextColor;

	// Token: 0x040053AA RID: 21418
	private ScrollView itemView;

	// Token: 0x040053AB RID: 21419
	private CScrollRect itemScrollRect;

	// Token: 0x040053AC RID: 21420
	private RectTransform itemCont;

	// Token: 0x040053AD RID: 21421
	private bool bInitItemView;

	// Token: 0x040053AE RID: 21422
	private byte itemTabIndex;

	// Token: 0x040053AF RID: 21423
	private bool bInitScrollView;

	// Token: 0x040053B0 RID: 21424
	private List<UIHIBtn> ItemHIBtn = new List<UIHIBtn>();

	// Token: 0x040053B1 RID: 21425
	private List<HeroEquip> EqipData = new List<HeroEquip>();

	// Token: 0x040053B2 RID: 21426
	private bool bHaveRecruit;

	// Token: 0x040053B3 RID: 21427
	private UIText[] m_TempNameText = new UIText[20];

	// Token: 0x040053B4 RID: 21428
	private UIText[] m_TempNumText = new UIText[20];

	// Token: 0x040053B5 RID: 21429
	private UIHIBtn[] m_TempHibtn = new UIHIBtn[20];

	// Token: 0x02000569 RID: 1385
	public enum e_HeroListPageTpye
	{
		// Token: 0x040053B7 RID: 21431
		OwnedPage,
		// Token: 0x040053B8 RID: 21432
		NoOwnedPage,
		// Token: 0x040053B9 RID: 21433
		ItemPage
	}

	// Token: 0x0200056A RID: 1386
	public enum e_item
	{
		// Token: 0x040053BB RID: 21435
		HeroIconBg,
		// Token: 0x040053BC RID: 21436
		HeroIcon,
		// Token: 0x040053BD RID: 21437
		NameImage,
		// Token: 0x040053BE RID: 21438
		Equipment0,
		// Token: 0x040053BF RID: 21439
		Equipment1,
		// Token: 0x040053C0 RID: 21440
		Equipment2,
		// Token: 0x040053C1 RID: 21441
		Equipment3,
		// Token: 0x040053C2 RID: 21442
		Equipment4,
		// Token: 0x040053C3 RID: 21443
		Equipment5,
		// Token: 0x040053C4 RID: 21444
		FragmentImage,
		// Token: 0x040053C5 RID: 21445
		FragmentFlash,
		// Token: 0x040053C6 RID: 21446
		TypeImg,
		// Token: 0x040053C7 RID: 21447
		Name,
		// Token: 0x040053C8 RID: 21448
		FragmentNum,
		// Token: 0x040053C9 RID: 21449
		ExclamationImage,
		// Token: 0x040053CA RID: 21450
		IsFightingImg
	}

	// Token: 0x0200056B RID: 1387
	public enum e_CheckPanel
	{
		// Token: 0x040053CC RID: 21452
		Image,
		// Token: 0x040053CD RID: 21453
		Arrow0,
		// Token: 0x040053CE RID: 21454
		Arrow1,
		// Token: 0x040053CF RID: 21455
		Arrow2,
		// Token: 0x040053D0 RID: 21456
		Arrow3,
		// Token: 0x040053D1 RID: 21457
		UIHIBtn,
		// Token: 0x040053D2 RID: 21458
		NameImage,
		// Token: 0x040053D3 RID: 21459
		OKBtn,
		// Token: 0x040053D4 RID: 21460
		CancleBtn,
		// Token: 0x040053D5 RID: 21461
		OKText,
		// Token: 0x040053D6 RID: 21462
		CancelText,
		// Token: 0x040053D7 RID: 21463
		RecruitName,
		// Token: 0x040053D8 RID: 21464
		CheckMsg
	}
}
