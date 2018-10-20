using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200050B RID: 1291
public class UICastle : GUIWindow, IBuildingWindowType, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x060019D7 RID: 6615 RVA: 0x002BEACC File Offset: 0x002BCCCC
	private void Start()
	{
		this.baseBuild = base.transform.gameObject.AddComponent<BuildingWindow>();
		this.baseBuild.m_Handler = this;
		RoleBuildingData roleBuildingData = this.GUIM.BuildingData.AllBuildsData[this.ManorID];
		this.baseBuild.InitBuildingWindow((byte)roleBuildingData.BuildID, (ushort)this.ManorID, 2, roleBuildingData.Level);
		this.baseBuild.baseTransform.SetAsFirstSibling();
		NewbieManager.CheckNewbie(this);
	}

	// Token: 0x060019D8 RID: 6616 RVA: 0x002BEB58 File Offset: 0x002BCD58
	public override void OnOpen(int arg1, int arg2)
	{
		this.ThisTransform = base.transform.GetChild(0);
		this.DM = DataManager.Instance;
		this.GUIM = GUIManager.Instance;
		Font ttffont = this.GUIM.GetTTFFont();
		this.ManorID = arg1;
		this.RankSpriteArr = this.ThisTransform.GetComponent<UISpritesArray>();
		this.ScrollCont = this.ThisTransform.GetChild(1);
		this.CastleScroll = this.ScrollCont.GetChild(0).GetComponent<ScrollPanel>();
		this.CastleInfoArr = this.ScrollCont.GetComponent<UISpritesArray>();
		this.RectHint = this.ThisTransform.GetChild(3).GetComponent<RectTransform>();
		this.HintText = this.RectHint.GetChild(0).GetComponent<UIText>();
		this.HintText.font = ttffont;
		if (this.GUIM.IsArabic)
		{
			this.ThisTransform.GetChild(0).GetChild(1).localScale = new Vector3(-1.2f, 1.2f, 1.2f);
		}
		Image component = this.ThisTransform.GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
		UIButtonHint uibuttonHint;
		if (this.DM.RoleAlliance.Id == 0u)
		{
			component.transform.parent.gameObject.SetActive(false);
		}
		else
		{
			uibuttonHint = this.ThisTransform.GetChild(0).GetChild(1).gameObject.AddComponent<UIButtonHint>();
			uibuttonHint.ControlFadeOut = this.RectHint.gameObject;
			uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
			uibuttonHint.m_Handler = this;
			uibuttonHint.Parm1 = 7346;
			component.sprite = this.RankSpriteArr.GetSprite((int)(this.DM.RoleAlliance.Rank - AllianceRank.RANK1));
		}
		uibuttonHint = this.ThisTransform.GetChild(0).GetChild(2).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.ControlFadeOut = this.RectHint.gameObject;
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		uibuttonHint.Parm1 = 7345;
		this.VipStr = StringManager.Instance.SpawnString(30);
		this.VipText = this.ThisTransform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>();
		this.VipText.font = ttffont;
		this.VipStr.ClearString();
		this.VipStr.IntToFormat((long)this.DM.RoleAttr.VIPLevel, 1, false);
		this.VipStr.AppendFormat("{0}");
		this.VipText.text = this.VipStr.ToString();
		this.VipText.SetAllDirty();
		this.VipText.cachedTextGenerator.Invalidate();
		if (this.GUIM.IsArabic)
		{
			this.ThisTransform.GetChild(0).GetChild(2).localScale = new Vector3(-1f, 1f, 1f);
		}
		this.RoleNameStr = StringManager.Instance.SpawnString(100);
		this.RoleName = this.ThisTransform.GetChild(0).GetChild(3).GetComponent<UIText>();
		this.RoleName.font = ttffont;
		this.RoleName.SetCheckArabic(true);
		this.RectChangeName = this.ThisTransform.GetChild(0).GetChild(4).GetComponent<RectTransform>();
		UIButton component2 = this.ThisTransform.GetChild(0).GetChild(4).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 0;
		this.RoleNameSize = this.RoleName.fontSize;
		this.RectChangeNameLeft = this.RoleName.rectTransform.anchoredPosition.x;
		this.UpdateNamePos();
		Transform child = this.ThisTransform.GetChild(2);
		for (int i = 0; i < 5; i++)
		{
			UIText component3 = child.GetChild(1 + i).GetComponent<UIText>();
			component3.font = ttffont;
		}
		this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x060019D9 RID: 6617 RVA: 0x002BEF5C File Offset: 0x002BD15C
	public void UpdateNamePos()
	{
		this.RoleNameStr.ClearString();
		CString cstring = StringManager.Instance.StaticString1024();
		if (this.DM.RoleAttr.NickName.Length == 0)
		{
			cstring.Append(this.DM.mStringTable.GetStringByID(9096u));
		}
		else
		{
			cstring.Append(this.DM.RoleAttr.NickName);
		}
		GameConstants.FormatRoleName(this.RoleNameStr, this.DM.RoleAttr.Name, null, cstring, 0, 0, null, null, null, "<color=#4CF5F5>");
		this.RoleName.text = this.RoleNameStr.ToString();
		this.RoleName.SetAllDirty();
		this.RoleName.cachedTextGenerator.Invalidate();
		this.RoleName.cachedTextGeneratorForLayout.Invalidate();
		this.RoleName.fontSize = this.RoleNameSize;
		this.RoleName.fontSize = this.GetFontSize();
		Vector2 anchoredPosition = this.RectChangeName.anchoredPosition;
		anchoredPosition.x = this.RoleName.rectTransform.anchoredPosition.x + this.RoleName.preferredWidth + 27f;
		if (this.RoleName.rectTransform.localScale.x < 0f)
		{
			anchoredPosition.x -= this.RoleName.rectTransform.sizeDelta.x;
		}
		this.RectChangeName.anchoredPosition = anchoredPosition;
	}

	// Token: 0x060019DA RID: 6618 RVA: 0x002BF0EC File Offset: 0x002BD2EC
	private int GetFontSize()
	{
		float num = this.RectChangeNameLeft + this.RoleName.preferredWidth + 27f;
		if (num > 393f && this.RoleName.fontSize > 8)
		{
			this.RoleName.fontSize--;
			this.RoleName.SetLayoutDirty();
			this.RoleName.cachedTextGeneratorForLayout.Invalidate();
			this.GetFontSize();
		}
		return this.RoleName.fontSize;
	}

	// Token: 0x060019DB RID: 6619 RVA: 0x002BF170 File Offset: 0x002BD370
	public override void OnClose()
	{
		if (this.baseBuild != null)
		{
			this.baseBuild.DestroyBuildingWindow();
		}
		StringManager.Instance.DeSpawnString(this.VipStr);
		StringManager.Instance.DeSpawnString(this.RoleNameStr);
		if (this.CastleItem != null)
		{
			for (int i = 0; i < this.CastleItem.Length; i++)
			{
				for (int j = 0; j < this.CastleItem[i].TitleStr.Length; j++)
				{
					StringManager.Instance.DeSpawnString(this.CastleItem[i].TitleStr[j]);
				}
			}
		}
		this.GUIM.BuildingData.castleSkin.ClearCastleSkinUI(false);
	}

	// Token: 0x060019DC RID: 6620 RVA: 0x002BF238 File Offset: 0x002BD438
	public void OnButtonDown(UIButtonHint sender)
	{
		this.HintText.text = DataManager.Instance.mStringTable.GetStringByID((uint)sender.Parm1);
		Vector2 vector = this.RectHint.sizeDelta;
		vector.y = this.HintText.preferredHeight + 16f;
		this.RectHint.sizeDelta = vector;
		sender.GetTipPosition(this.RectHint, UIButtonHint.ePosition.Original, null);
		vector = this.RectHint.anchoredPosition;
		vector.x += 20f;
		vector.y -= 2f;
		this.RectHint.anchoredPosition = vector;
		this.RectHint.gameObject.SetActive(true);
		AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
	}

	// Token: 0x060019DD RID: 6621 RVA: 0x002BF308 File Offset: 0x002BD508
	public void OnButtonUp(UIButtonHint sender)
	{
		this.RectHint.gameObject.SetActive(false);
	}

	// Token: 0x060019DE RID: 6622 RVA: 0x002BF31C File Offset: 0x002BD51C
	private void Update()
	{
		if (this.DelayInit > 0)
		{
			this.DelayInit -= 1;
			if (this.DelayInit == 0)
			{
				this.Init();
			}
			return;
		}
		if (this.UpdateRate < 0f)
		{
			for (int i = 0; i < this.CastleItem.Length; i++)
			{
				if (this.CastleItem[i].dataIdx == 0)
				{
					this.UpdateWallInfo(ref this.CastleItem[i]);
				}
				else if (this.CastleItem[i].dataIdx == 1)
				{
					this.UpdateArmy(ref this.CastleItem[i]);
				}
			}
			for (int j = 0; j < this.CastleItem.Length; j++)
			{
				if (this.CastleItem[j].transform.gameObject.activeSelf && this.CastleItem[j].dataIdx >= 2)
				{
					this.UpDateRowItem(this.CastleItem[j].transform.gameObject, this.CastleItem[j].dataIdx, j, 0);
				}
			}
			this.UpdateRate = 1f;
		}
		this.UpdateRate -= Time.deltaTime;
	}

	// Token: 0x060019DF RID: 6623 RVA: 0x002BF478 File Offset: 0x002BD678
	private void Init()
	{
		for (int i = 0; i < this.ManorResource.Length; i++)
		{
			ResourceType resourceType = (ResourceType)i;
			if (resourceType == ResourceType.Grain)
			{
				this.ManorResource[i] = new UICastle.GrainResourceInfo(resourceType);
			}
			else
			{
				this.ManorResource[i] = new UICastle.ResourceInfo(resourceType);
			}
			this.ManorResource[i].UpdateResourceInfo();
		}
		this.ThisTransform.GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
		this.GUIM.InitianHeroItemImg(this.ThisTransform.GetChild(0).GetChild(0).GetChild(0), eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, 11, 0, 0, false, false, true, false);
		this.UpdateBagResourceCapacity();
		byte b = 7;
		for (byte b2 = 0; b2 < b; b2 += 1)
		{
			if (b2 == 2)
			{
				this.ItemsHeight.Add(132f);
			}
			else
			{
				this.ItemsHeight.Add(95f);
			}
		}
		this.CastleItem = new UICastle._ItemData[(int)b];
		this.CastleScroll.IntiScrollPanel(272f, 0f, 6f, this.ItemsHeight, (int)b, this);
		this.CastleItem[2].SetSize(1);
		this.CastleScroll.AddNewDataHeight(this.ItemsHeight, true, true);
		this.ScrollCont.gameObject.SetActive(true);
		this.TextRefresh();
	}

	// Token: 0x060019E0 RID: 6624 RVA: 0x002BF5E8 File Offset: 0x002BD7E8
	private void UpdateBagResourceCapacity()
	{
		if (this.DelayInit > 0)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		instance.SortCurItemDataForBag();
		Array.Clear(this.ResourceCapacity, 0, this.ResourceCapacity.Length);
		for (ushort num = instance.sortItemDataStart[10]; num < instance.sortItemDataStart[10] + instance.sortItemDataCount[10]; num += 1)
		{
			long num2 = (long)instance.GetCurItemQuantity(instance.sortItemData[(int)num], 0);
			if (num2 != 0L)
			{
				Equip recordByKey = instance.EquipTable.GetRecordByKey(instance.sortItemData[(int)num]);
				if (recordByKey.PropertiesInfo[0].Propertieskey >= 1 && recordByKey.PropertiesInfo[0].Propertieskey <= 5)
				{
					this.ResourceCapacity[(int)(recordByKey.PropertiesInfo[0].Propertieskey - 1)] += (long)(recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue) * num2;
					if (this.ResourceCapacity[(int)(recordByKey.PropertiesInfo[0].Propertieskey - 1)] > 999000000000L)
					{
						this.ResourceCapacity[(int)(recordByKey.PropertiesInfo[0].Propertieskey - 1)] = 999000000000L;
					}
				}
			}
		}
	}

	// Token: 0x060019E1 RID: 6625 RVA: 0x002BF74C File Offset: 0x002BD94C
	public override void UpdateNetwork(byte[] meg)
	{
		if (this.DelayInit > 0)
		{
			return;
		}
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			return;
		default:
			switch (networkNews)
			{
			case NetworkNews.Refresh_Soldier:
			{
				UICastle.GrainResourceInfo grainResourceInfo = this.ManorResource[0] as UICastle.GrainResourceInfo;
				grainResourceInfo.UpdateResourceInfo();
				return;
			}
			default:
				if (networkNews != NetworkNews.Refresh_AttribEffectVal)
				{
					if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
					{
						return;
					}
					this.baseBuild.Refresh_FontTexture();
					this.TextRefresh();
					return;
				}
				break;
			case NetworkNews.Refresh_BuildBase:
				this.baseBuild.MyUpdate(meg[1], false);
				return;
			}
			break;
		case NetworkNews.Refresh_Attr:
			this.UpdateNamePos();
			return;
		case NetworkNews.Refresh_Item:
			this.UpdateBagResourceCapacity();
			return;
		case NetworkNews.Refresh_Resource:
			break;
		}
		for (int i = 0; i < this.ManorResource.Length; i++)
		{
			this.ManorResource[i].UpdateResourceInfo();
		}
		this.VipStr.ClearString();
		this.VipStr.IntToFormat((long)this.DM.RoleAttr.VIPLevel, 1, false);
		this.VipStr.AppendFormat("{0}");
		this.VipText.text = this.VipStr.ToString();
		this.VipText.SetAllDirty();
		this.VipText.cachedTextGenerator.Invalidate();
		if (meg[0] == 26)
		{
			this.baseBuild.MyUpdate(0, false);
		}
	}

	// Token: 0x060019E2 RID: 6626 RVA: 0x002BF8C8 File Offset: 0x002BDAC8
	private void TextRefresh()
	{
		this.VipText.enabled = false;
		this.VipText.enabled = true;
		this.RoleName.enabled = false;
		this.RoleName.enabled = true;
		this.HintText.enabled = false;
		this.HintText.enabled = true;
		for (int i = 0; i < this.CastleItem.Length; i++)
		{
			this.CastleItem[i].TextRefresh();
		}
	}

	// Token: 0x060019E3 RID: 6627 RVA: 0x002BF948 File Offset: 0x002BDB48
	public void OnButtonClick(UIButton sender)
	{
		UICastle.ClickType btnID = (UICastle.ClickType)sender.m_BtnID1;
		if (btnID != UICastle.ClickType.ChangeName)
		{
			if (btnID == UICastle.ClickType.Next)
			{
				Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
				door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, sender.m_BtnID2 + 2, 0, false);
			}
		}
		else if (!NewbieManager.CheckRename(false))
		{
			GUIManager.Instance.OpenMenu(EGUIWindow.UI_Name, 0, 0, false, true, false);
		}
	}

	// Token: 0x060019E4 RID: 6628 RVA: 0x002BF9BC File Offset: 0x002BDBBC
	public void OnTypeChange(e_BuildType buildType)
	{
		if (buildType == e_BuildType.Upgrade)
		{
			this.ThisTransform.gameObject.SetActive(false);
		}
		else if (buildType == e_BuildType.Normal)
		{
			this.ThisTransform.gameObject.SetActive(true);
		}
	}

	// Token: 0x060019E5 RID: 6629 RVA: 0x002BFA00 File Offset: 0x002BDC00
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.CastleItem[panelObjectIdx].Icon == null)
		{
			Transform transform = item.transform;
			this.CastleItem[panelObjectIdx].transform = transform;
			this.CastleItem[panelObjectIdx].PanelItem = transform.GetComponent<ScrollPanelItem>();
			this.CastleItem[panelObjectIdx].FrameRect = transform.GetComponent<RectTransform>();
			this.CastleItem[panelObjectIdx].Icon = transform.GetChild(0).GetComponent<Image>();
			this.CastleItem[panelObjectIdx].Title1 = transform.GetChild(1).GetComponent<UIText>();
			this.CastleItem[panelObjectIdx].Title2 = transform.GetChild(2).GetComponent<UIText>();
			this.CastleItem[panelObjectIdx].Title3 = transform.GetChild(3).GetComponent<UIText>();
			this.CastleItem[panelObjectIdx].Title4 = transform.GetChild(4).GetComponent<UIText>();
			this.CastleItem[panelObjectIdx].Title5 = transform.GetChild(5).GetComponent<UIText>();
			this.CastleItem[panelObjectIdx].NextBtn = transform.GetChild(6).GetComponent<UIButton>();
			this.CastleItem[panelObjectIdx].NextBtn.m_Handler = this;
			this.CastleItem[panelObjectIdx].NextBtn.m_BtnID1 = 1;
			this.CastleItem[panelObjectIdx].NextBtn.m_BtnID2 = dataIdx;
			this.CastleItem[panelObjectIdx].TitleStr = new CString[5];
			for (int i = 0; i < this.CastleItem[panelObjectIdx].TitleStr.Length; i++)
			{
				this.CastleItem[panelObjectIdx].TitleStr[i] = StringManager.Instance.SpawnString(100);
			}
			return;
		}
		this.CastleItem[panelObjectIdx].dataIdx = dataIdx;
		if (dataIdx != 0)
		{
			if (dataIdx != 1)
			{
				this.UpdateResource(ref this.CastleItem[panelObjectIdx], dataIdx - 2);
				this.CastleItem[panelObjectIdx].NextBtn.gameObject.SetActive(false);
				this.CastleItem[panelObjectIdx].PanelItem.transition = Selectable.Transition.None;
			}
			else
			{
				this.UpdateArmy(ref this.CastleItem[panelObjectIdx]);
				this.CastleItem[panelObjectIdx].NextBtn.gameObject.SetActive(true);
				this.CastleItem[panelObjectIdx].PanelItem.transition = Selectable.Transition.ColorTint;
			}
		}
		else
		{
			this.UpdateWallInfo(ref this.CastleItem[panelObjectIdx]);
			this.CastleItem[panelObjectIdx].NextBtn.gameObject.SetActive(true);
			this.CastleItem[panelObjectIdx].PanelItem.transition = Selectable.Transition.ColorTint;
		}
	}

	// Token: 0x060019E6 RID: 6630 RVA: 0x002BFCE4 File Offset: 0x002BDEE4
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		for (int i = 0; i < this.CastleItem.Length; i++)
		{
			if (this.CastleItem[i].NextBtn.gameObject.activeSelf && this.CastleItem[i].dataIdx == dataIndex)
			{
				AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
				this.OnButtonClick(this.CastleItem[i].NextBtn);
				break;
			}
		}
	}

	// Token: 0x060019E7 RID: 6631 RVA: 0x002BFD68 File Offset: 0x002BDF68
	private void UpdateWallInfo(ref UICastle._ItemData itemData)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring.Append("<color=#cbbd7bff>");
		cstring2.Append("</color>");
		itemData.Icon.sprite = this.CastleInfoArr.GetSprite(0);
		itemData.Icon.SetNativeSize();
		itemData.TitleStr[0].ClearString();
		itemData.TitleStr[0].StringToFormat(cstring);
		itemData.TitleStr[0].StringToFormat(this.DM.mStringTable.GetStringByID(4928u));
		itemData.TitleStr[0].StringToFormat(cstring2);
		itemData.TitleStr[0].IntToFormat((long)((ulong)this.DM.m_WallRepairNowValue), 1, true);
		itemData.TitleStr[0].IntToFormat((long)((ulong)this.DM.m_WallRepairMaxValue), 1, true);
		itemData.TitleStr[0].AppendFormat("{0}{1}{2}{3} / {4}");
		itemData.Title1.text = itemData.TitleStr[0].ToString();
		itemData.Title1.SetAllDirty();
		itemData.Title1.cachedTextGenerator.Invalidate();
		uint num = 0u;
		RoleBuildingData buildData = this.GUIM.BuildingData.GetBuildData(12, 0);
		if (this.GUIM.BuildingData.GetBuildNumByID(12) > 0)
		{
			num = this.GUIM.BuildingData.GetBuildLevelRequestData(buildData.BuildID, buildData.Level).Value1;
		}
		itemData.TitleStr[1].ClearString();
		itemData.TitleStr[1].StringToFormat(cstring);
		itemData.TitleStr[1].StringToFormat(this.DM.mStringTable.GetStringByID(4929u));
		itemData.TitleStr[1].StringToFormat(cstring2);
		itemData.TitleStr[1].IntToFormat((long)((ulong)this.DM.TrapTotal), 1, true);
		itemData.TitleStr[1].IntToFormat((long)((ulong)num), 1, true);
		itemData.TitleStr[1].AppendFormat("{0}{1}{2}{3} / {4}");
		itemData.Title2.text = itemData.TitleStr[1].ToString();
		itemData.Title2.SetAllDirty();
		itemData.Title2.cachedTextGenerator.Invalidate();
		itemData.TitleStr[2].ClearString();
		itemData.TitleStr[2].StringToFormat(cstring);
		itemData.TitleStr[2].StringToFormat(this.DM.mStringTable.GetStringByID(4930u));
		itemData.TitleStr[2].StringToFormat(cstring2);
		int maxDefenders = this.DM.GetMaxDefenders();
		int num2 = 0;
		for (int i = 0; i < this.DM.GetMaxDefenders(); i++)
		{
			if (this.DM.m_DefendersID[i] > 0)
			{
				num2++;
			}
		}
		itemData.TitleStr[2].IntToFormat((long)num2, 1, false);
		itemData.TitleStr[2].IntToFormat((long)maxDefenders, 1, false);
		itemData.TitleStr[2].AppendFormat("{0}{1}{2}{3} / {4}");
		itemData.Title3.text = itemData.TitleStr[2].ToString();
		itemData.Title3.SetAllDirty();
		itemData.Title3.cachedTextGenerator.Invalidate();
		itemData.TitleStr[3].ClearString();
		itemData.TitleStr[3].StringToFormat(cstring);
		itemData.TitleStr[3].StringToFormat(this.DM.mStringTable.GetStringByID(4931u));
		itemData.TitleStr[3].StringToFormat(cstring2);
		itemData.TitleStr[3].IntToFormat((long)((ulong)this.DM.TrapHospitalTotal), 1, true);
		itemData.TitleStr[3].IntToFormat((long)((ulong)num), 1, true);
		itemData.TitleStr[3].AppendFormat("{0}{1}{2}{3} / {4}");
		itemData.Title4.text = itemData.TitleStr[3].ToString();
		itemData.Title4.SetAllDirty();
		itemData.Title4.cachedTextGenerator.Invalidate();
	}

	// Token: 0x060019E8 RID: 6632 RVA: 0x002C016C File Offset: 0x002BE36C
	private void UpdateArmy(ref UICastle._ItemData itemData)
	{
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring.Append("<color=#cbbd7bff>");
		cstring2.Append("</color>");
		itemData.Icon.sprite = this.CastleInfoArr.GetSprite(1);
		itemData.Icon.SetNativeSize();
		itemData.TitleStr[0].ClearString();
		itemData.TitleStr[0].StringToFormat(cstring);
		itemData.TitleStr[0].StringToFormat(this.DM.mStringTable.GetStringByID(4943u));
		itemData.TitleStr[0].StringToFormat(cstring2);
		itemData.TitleStr[0].IntToFormat(this.DM.SoldierTotal + (long)((ulong)this.DM.AttribVal.TotalOuterSoldier) + (long)((ulong)this.DM.AttribVal.TotalDugoutSoldier), 1, true);
		itemData.TitleStr[0].AppendFormat("{0}{1}{2}{3}");
		itemData.Title1.text = itemData.TitleStr[0].ToString();
		itemData.Title1.SetAllDirty();
		itemData.Title1.cachedTextGenerator.Invalidate();
		itemData.TitleStr[1].ClearString();
		itemData.TitleStr[1].StringToFormat(cstring);
		itemData.TitleStr[1].StringToFormat(this.DM.mStringTable.GetStringByID(4941u));
		itemData.TitleStr[1].StringToFormat(cstring2);
		itemData.TitleStr[1].IntToFormat((long)((ulong)this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_BASE_TROOP_AMOUNT)), 1, true);
		itemData.TitleStr[1].AppendFormat("{0}{1}{2}{3}");
		itemData.Title2.text = itemData.TitleStr[1].ToString();
		itemData.Title2.SetAllDirty();
		itemData.Title2.cachedTextGenerator.Invalidate();
		itemData.TitleStr[2].ClearString();
		itemData.TitleStr[2].StringToFormat(cstring);
		itemData.TitleStr[2].StringToFormat(this.DM.mStringTable.GetStringByID(4940u));
		itemData.TitleStr[2].StringToFormat(cstring2);
		itemData.TitleStr[2].IntToFormat((long)((ulong)this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM)), 1, true);
		itemData.TitleStr[2].AppendFormat("{0}{1}{2}{3}");
		itemData.Title3.text = itemData.TitleStr[2].ToString();
		itemData.Title3.SetAllDirty();
		itemData.Title3.cachedTextGenerator.Invalidate();
		itemData.TitleStr[3].ClearString();
		itemData.TitleStr[3].StringToFormat(cstring);
		itemData.TitleStr[3].StringToFormat(this.DM.mStringTable.GetStringByID(4942u));
		itemData.TitleStr[3].StringToFormat(cstring2);
		itemData.TitleStr[3].IntToFormat((long)this.DM.curHeroData.Count, 1, true);
		itemData.TitleStr[3].AppendFormat("{0}{1}{2}{3}");
		itemData.Title4.text = itemData.TitleStr[3].ToString();
		itemData.Title4.SetAllDirty();
		itemData.Title4.cachedTextGenerator.Invalidate();
	}

	// Token: 0x060019E9 RID: 6633 RVA: 0x002C04BC File Offset: 0x002BE6BC
	private void UpdateGrain(ref UICastle._ItemData itemData)
	{
		UICastle.GrainResourceInfo grainResourceInfo = this.ManorResource[0] as UICastle.GrainResourceInfo;
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring.Append("<color=#cbbd7bff>");
		cstring2.Append("</color>");
		itemData.Icon.sprite = this.CastleInfoArr.GetSprite(2);
		itemData.Icon.SetNativeSize();
		itemData.TitleStr[0].ClearString();
		itemData.TitleStr[0].StringToFormat(cstring);
		itemData.TitleStr[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint)grainResourceInfo.Title1));
		itemData.TitleStr[0].StringToFormat(cstring2);
		itemData.TitleStr[0].IntToFormat((long)((ulong)grainResourceInfo.Stock), 1, true);
		itemData.TitleStr[0].AppendFormat("{0}{1}{2}{3}");
		itemData.Title1.text = itemData.TitleStr[0].ToString();
		itemData.Title1.SetAllDirty();
		itemData.Title1.cachedTextGenerator.Invalidate();
		itemData.TitleStr[1].ClearString();
		itemData.TitleStr[1].StringToFormat(cstring);
		itemData.TitleStr[1].StringToFormat(this.DM.mStringTable.GetStringByID((uint)grainResourceInfo.Title5));
		itemData.TitleStr[1].StringToFormat(cstring2);
		if (grainResourceInfo.Consume == 0L)
		{
			itemData.TitleStr[1].StringToFormat("<color=#ffffffff>");
		}
		else
		{
			itemData.TitleStr[1].StringToFormat("<color=#ff6e7eff>");
		}
		itemData.TitleStr[1].IntToFormat(grainResourceInfo.Consume * -1L, 1, true);
		itemData.TitleStr[1].StringToFormat("</color>");
		itemData.TitleStr[1].AppendFormat("{0}{1}{2}{3}{4}{5}");
		itemData.Title5.text = itemData.TitleStr[1].ToString();
		itemData.Title5.SetAllDirty();
		itemData.Title5.cachedTextGenerator.Invalidate();
		itemData.TitleStr[2].ClearString();
		itemData.TitleStr[2].StringToFormat(cstring);
		itemData.TitleStr[2].StringToFormat(this.DM.mStringTable.GetStringByID((uint)grainResourceInfo.Title2));
		itemData.TitleStr[2].StringToFormat(cstring2);
		itemData.TitleStr[2].IntToFormat(grainResourceInfo.ProductPerHour, 1, true);
		itemData.TitleStr[2].AppendFormat("{0}{1}{2}{3}");
		itemData.Title3.text = itemData.TitleStr[2].ToString();
		itemData.Title3.SetAllDirty();
		itemData.Title3.cachedTextGenerator.Invalidate();
		itemData.TitleStr[3].ClearString();
		itemData.TitleStr[3].StringToFormat(cstring);
		itemData.TitleStr[3].StringToFormat(this.DM.mStringTable.GetStringByID((uint)grainResourceInfo.Title3));
		itemData.TitleStr[3].StringToFormat(cstring2);
		itemData.TitleStr[3].IntToFormat((long)((ulong)grainResourceInfo.Capacity), 1, true);
		itemData.TitleStr[3].AppendFormat("{0}{1}{2}{3}");
		itemData.Title2.text = itemData.TitleStr[3].ToString();
		itemData.Title2.SetAllDirty();
		itemData.Title2.cachedTextGenerator.Invalidate();
		itemData.TitleStr[4].ClearString();
		if (this.ResourceCapacity[0] >= 1000000000L)
		{
			CString cstring3 = StringManager.Instance.StaticString1024();
			this.FormatResourceValue(cstring3, this.ResourceCapacity[0]);
			itemData.TitleStr[4].StringToFormat(cstring);
			itemData.TitleStr[4].StringToFormat(this.DM.mStringTable.GetStringByID((uint)grainResourceInfo.Title4));
			itemData.TitleStr[4].StringToFormat(cstring2);
			itemData.TitleStr[4].StringToFormat(cstring3);
		}
		else
		{
			itemData.TitleStr[4].StringToFormat(cstring);
			itemData.TitleStr[4].StringToFormat(this.DM.mStringTable.GetStringByID((uint)grainResourceInfo.Title4));
			itemData.TitleStr[4].StringToFormat(cstring2);
			itemData.TitleStr[4].IntToFormat(this.ResourceCapacity[0], 1, true);
		}
		itemData.TitleStr[4].AppendFormat("{0}{1}{2}{3}");
		itemData.Title4.text = itemData.TitleStr[4].ToString();
		itemData.Title4.SetAllDirty();
		itemData.Title4.cachedTextGenerator.Invalidate();
	}

	// Token: 0x060019EA RID: 6634 RVA: 0x002C094C File Offset: 0x002BEB4C
	private void UpdateResource(ref UICastle._ItemData itemData, int resIndex)
	{
		if (resIndex == 0)
		{
			this.UpdateGrain(ref itemData);
			return;
		}
		CString cstring = StringManager.Instance.StaticString1024();
		CString cstring2 = StringManager.Instance.StaticString1024();
		cstring.Append("<color=#cbbd7bff>");
		cstring2.Append("</color>");
		itemData.Icon.sprite = this.CastleInfoArr.GetSprite(2 + resIndex);
		itemData.Icon.SetNativeSize();
		itemData.TitleStr[0].ClearString();
		itemData.TitleStr[0].StringToFormat(cstring);
		itemData.TitleStr[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.ManorResource[resIndex].Title1));
		itemData.TitleStr[0].StringToFormat(cstring2);
		itemData.TitleStr[0].IntToFormat((long)((ulong)this.ManorResource[resIndex].Stock), 1, true);
		itemData.TitleStr[0].AppendFormat("{0}{1}{2}{3}");
		itemData.Title1.text = itemData.TitleStr[0].ToString();
		itemData.Title1.SetAllDirty();
		itemData.Title1.cachedTextGenerator.Invalidate();
		itemData.TitleStr[1].ClearString();
		itemData.TitleStr[1].StringToFormat(cstring);
		itemData.TitleStr[1].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.ManorResource[resIndex].Title2));
		itemData.TitleStr[1].StringToFormat(cstring2);
		itemData.TitleStr[1].IntToFormat(this.ManorResource[resIndex].ProductPerHour, 1, true);
		itemData.TitleStr[1].AppendFormat("{0}{1}{2}{3}");
		itemData.Title3.text = itemData.TitleStr[1].ToString();
		itemData.Title3.SetAllDirty();
		itemData.Title3.cachedTextGenerator.Invalidate();
		itemData.TitleStr[2].ClearString();
		itemData.TitleStr[2].StringToFormat(cstring);
		itemData.TitleStr[2].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.ManorResource[resIndex].Title3));
		itemData.TitleStr[2].StringToFormat(cstring2);
		itemData.TitleStr[2].IntToFormat((long)((ulong)this.ManorResource[resIndex].Capacity), 1, true);
		itemData.TitleStr[2].AppendFormat("{0}{1}{2}{3}");
		itemData.Title2.text = itemData.TitleStr[2].ToString();
		itemData.Title2.SetAllDirty();
		itemData.Title2.cachedTextGenerator.Invalidate();
		itemData.TitleStr[4].ClearString();
		if (this.ResourceCapacity[resIndex] >= 1000000000L)
		{
			CString cstring3 = StringManager.Instance.StaticString1024();
			this.FormatResourceValue(cstring3, this.ResourceCapacity[resIndex]);
			itemData.TitleStr[4].StringToFormat(cstring);
			itemData.TitleStr[4].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.ManorResource[resIndex].Title4));
			itemData.TitleStr[4].StringToFormat(cstring2);
			itemData.TitleStr[4].StringToFormat(cstring3);
		}
		else
		{
			itemData.TitleStr[4].StringToFormat(cstring);
			itemData.TitleStr[4].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.ManorResource[resIndex].Title4));
			itemData.TitleStr[4].StringToFormat(cstring2);
			itemData.TitleStr[4].IntToFormat(this.ResourceCapacity[resIndex], 1, true);
		}
		itemData.TitleStr[4].AppendFormat("{0}{1}{2}{3}");
		itemData.Title4.text = itemData.TitleStr[4].ToString();
		itemData.Title4.SetAllDirty();
		itemData.Title4.cachedTextGenerator.Invalidate();
		itemData.Title5.text = string.Empty;
	}

	// Token: 0x060019EB RID: 6635 RVA: 0x002C0D30 File Offset: 0x002BEF30
	private void FormatResourceValue(CString CStr, long value)
	{
		if (value >= 1000000000L)
		{
			CStr.FloatToFormat((float)((double)value / 1000000000.0), 2, false);
			CStr.AppendFormat("{0}B");
		}
		else if (value >= 100000000L)
		{
			CStr.IntToFormat(value / 1000000L, 1, false);
			CStr.AppendFormat("{0}M");
		}
		else if (value >= 10000000L)
		{
			CStr.FloatToFormat((float)value / 1000000f, 1, false);
			CStr.AppendFormat("{0}M");
		}
		else if (value >= 1000000L)
		{
			CStr.FloatToFormat((float)value / 1000000f, 2, false);
			CStr.AppendFormat("{0}M");
		}
		else if (value >= 100000L)
		{
			CStr.IntToFormat(value / 1000L, 1, false);
			CStr.AppendFormat("{0}K");
		}
		else if (value >= 10000L)
		{
			CStr.FloatToFormat((float)value / 1000f, 1, false);
			CStr.AppendFormat("{0}K");
		}
		else if (value >= 1000L)
		{
			CStr.IntToFormat(value / 1000L, 1, false);
			CStr.IntToFormat(value % 1000L, 3, false);
			CStr.AppendFormat("{0},{1}");
		}
		else
		{
			CStr.IntToFormat(value, 1, false);
			CStr.AppendFormat("{0}");
		}
	}

	// Token: 0x04004CA0 RID: 19616
	private Transform ThisTransform;

	// Token: 0x04004CA1 RID: 19617
	private Transform ScrollCont;

	// Token: 0x04004CA2 RID: 19618
	private ScrollPanel CastleScroll;

	// Token: 0x04004CA3 RID: 19619
	public BuildingWindow baseBuild;

	// Token: 0x04004CA4 RID: 19620
	private int ManorID;

	// Token: 0x04004CA5 RID: 19621
	private int RoleNameSize;

	// Token: 0x04004CA6 RID: 19622
	private DataManager DM;

	// Token: 0x04004CA7 RID: 19623
	private GUIManager GUIM;

	// Token: 0x04004CA8 RID: 19624
	private byte DelayInit = 3;

	// Token: 0x04004CA9 RID: 19625
	private List<float> ItemsHeight = new List<float>();

	// Token: 0x04004CAA RID: 19626
	private UISpritesArray RankSpriteArr;

	// Token: 0x04004CAB RID: 19627
	private UISpritesArray CastleInfoArr;

	// Token: 0x04004CAC RID: 19628
	private UICastle.ResourceInfo[] ManorResource = new UICastle.ResourceInfo[5];

	// Token: 0x04004CAD RID: 19629
	private CString VipStr;

	// Token: 0x04004CAE RID: 19630
	private CString RoleNameStr;

	// Token: 0x04004CAF RID: 19631
	private UIText RoleName;

	// Token: 0x04004CB0 RID: 19632
	private UIText HintText;

	// Token: 0x04004CB1 RID: 19633
	private Text VipText;

	// Token: 0x04004CB2 RID: 19634
	private RectTransform RectChangeName;

	// Token: 0x04004CB3 RID: 19635
	private RectTransform RectHint;

	// Token: 0x04004CB4 RID: 19636
	private float RectChangeNameLeft;

	// Token: 0x04004CB5 RID: 19637
	private long[] ResourceCapacity = new long[5];

	// Token: 0x04004CB6 RID: 19638
	private UICastle._ItemData[] CastleItem;

	// Token: 0x04004CB7 RID: 19639
	private float UpdateRate = 1f;

	// Token: 0x0200050C RID: 1292
	private enum ClickType
	{
		// Token: 0x04004CB9 RID: 19641
		ChangeName,
		// Token: 0x04004CBA RID: 19642
		Next
	}

	// Token: 0x0200050D RID: 1293
	private enum UIControl
	{
		// Token: 0x04004CBC RID: 19644
		Title,
		// Token: 0x04004CBD RID: 19645
		ScrollCont,
		// Token: 0x04004CBE RID: 19646
		ScrollItem,
		// Token: 0x04004CBF RID: 19647
		Hint
	}

	// Token: 0x0200050E RID: 1294
	private enum TitleControl
	{
		// Token: 0x04004CC1 RID: 19649
		Hero,
		// Token: 0x04004CC2 RID: 19650
		Rank,
		// Token: 0x04004CC3 RID: 19651
		VIP,
		// Token: 0x04004CC4 RID: 19652
		Name,
		// Token: 0x04004CC5 RID: 19653
		ChangeNamebtn
	}

	// Token: 0x0200050F RID: 1295
	private enum ItemControl
	{
		// Token: 0x04004CC7 RID: 19655
		Icon,
		// Token: 0x04004CC8 RID: 19656
		Title1,
		// Token: 0x04004CC9 RID: 19657
		Title2,
		// Token: 0x04004CCA RID: 19658
		Title3,
		// Token: 0x04004CCB RID: 19659
		Title4,
		// Token: 0x04004CCC RID: 19660
		Title5,
		// Token: 0x04004CCD RID: 19661
		Next
	}

	// Token: 0x02000510 RID: 1296
	private struct _ItemData
	{
		// Token: 0x060019EC RID: 6636 RVA: 0x002C0EA4 File Offset: 0x002BF0A4
		public void TextRefresh()
		{
			if (this.Title1 == null)
			{
				return;
			}
			this.Title1.enabled = false;
			this.Title1.enabled = true;
			this.Title2.enabled = false;
			this.Title2.enabled = true;
			this.Title3.enabled = false;
			this.Title3.enabled = true;
			this.Title4.enabled = false;
			this.Title4.enabled = true;
			this.Title5.enabled = false;
			this.Title5.enabled = true;
		}

		// Token: 0x060019ED RID: 6637 RVA: 0x002C0F3C File Offset: 0x002BF13C
		public void SetSize(byte Large)
		{
			if (Large > 0)
			{
				this.Icon.rectTransform.anchoredPosition = new Vector2(this.Icon.rectTransform.anchoredPosition.x, -70.5f);
				this.FrameRect.sizeDelta = new Vector2(this.FrameRect.sizeDelta.x, 132f);
			}
			else
			{
				this.Icon.rectTransform.anchoredPosition = new Vector2(this.Icon.rectTransform.anchoredPosition.x, -51f);
				this.FrameRect.sizeDelta = new Vector2(this.FrameRect.sizeDelta.x, 95f);
			}
		}

		// Token: 0x04004CCE RID: 19662
		public Transform transform;

		// Token: 0x04004CCF RID: 19663
		public int dataIdx;

		// Token: 0x04004CD0 RID: 19664
		public Image Icon;

		// Token: 0x04004CD1 RID: 19665
		public ScrollPanelItem PanelItem;

		// Token: 0x04004CD2 RID: 19666
		public UIText Title1;

		// Token: 0x04004CD3 RID: 19667
		public UIText Title2;

		// Token: 0x04004CD4 RID: 19668
		public UIText Title3;

		// Token: 0x04004CD5 RID: 19669
		public UIText Title4;

		// Token: 0x04004CD6 RID: 19670
		public UIText Title5;

		// Token: 0x04004CD7 RID: 19671
		public UIButton NextBtn;

		// Token: 0x04004CD8 RID: 19672
		public CString[] TitleStr;

		// Token: 0x04004CD9 RID: 19673
		public RectTransform FrameRect;
	}

	// Token: 0x02000511 RID: 1297
	private class ResourceInfo
	{
		// Token: 0x060019EE RID: 6638 RVA: 0x002C100C File Offset: 0x002BF20C
		public ResourceInfo(ResourceType Type)
		{
			this.Type = Type;
			switch (Type)
			{
			case ResourceType.Grain:
				this.Title1 = 4944;
				this.Title2 = 4946;
				this.Title3 = 4947;
				this.Title4 = 14702;
				this.BuildID = 4;
				break;
			case ResourceType.Rock:
				this.Title1 = 4951;
				this.Title2 = 4952;
				this.Title3 = 4953;
				this.Title4 = 14703;
				this.BuildID = 2;
				break;
			case ResourceType.Wood:
				this.Title1 = 4948;
				this.Title2 = 4949;
				this.Title3 = 4950;
				this.Title4 = 14704;
				this.BuildID = 1;
				break;
			case ResourceType.Steel:
				this.Title1 = 4954;
				this.Title2 = 4955;
				this.Title3 = 4956;
				this.Title4 = 14705;
				this.BuildID = 3;
				break;
			case ResourceType.Money:
				this.Title1 = 5767;
				this.Title2 = 5768;
				this.Title3 = 5769;
				this.Title4 = 14706;
				this.BuildID = 7;
				break;
			}
		}

		// Token: 0x060019EF RID: 6639 RVA: 0x002C1160 File Offset: 0x002BF360
		public virtual void UpdateResourceInfo()
		{
			DataManager instance = DataManager.Instance;
			this.Stock = instance.Resource[(int)this.Type].Stock;
			this.Capacity = instance.Resource[(int)this.Type].Capacity;
			this.ProductPerHour = DataManager.MissionDataManager.UpdateResourceInfo(this.Type);
		}

		// Token: 0x04004CDA RID: 19674
		protected ushort BuildID;

		// Token: 0x04004CDB RID: 19675
		protected ResourceType Type;

		// Token: 0x04004CDC RID: 19676
		public uint Capacity;

		// Token: 0x04004CDD RID: 19677
		public uint Stock;

		// Token: 0x04004CDE RID: 19678
		public long ProductPerHour;

		// Token: 0x04004CDF RID: 19679
		public ushort Title1;

		// Token: 0x04004CE0 RID: 19680
		public ushort Title2;

		// Token: 0x04004CE1 RID: 19681
		public ushort Title3;

		// Token: 0x04004CE2 RID: 19682
		public ushort Title4;
	}

	// Token: 0x02000512 RID: 1298
	private class GrainResourceInfo : UICastle.ResourceInfo
	{
		// Token: 0x060019F0 RID: 6640 RVA: 0x002C11BC File Offset: 0x002BF3BC
		public GrainResourceInfo(ResourceType Type) : base(Type)
		{
		}

		// Token: 0x060019F1 RID: 6641 RVA: 0x002C11D0 File Offset: 0x002BF3D0
		public override void UpdateResourceInfo()
		{
			base.UpdateResourceInfo();
			this.Consume = (long)DataManager.Instance.AttribVal.TotalSoldierConsume;
		}

		// Token: 0x04004CE3 RID: 19683
		public long Consume;

		// Token: 0x04004CE4 RID: 19684
		public ushort Title5 = 4945;
	}
}
