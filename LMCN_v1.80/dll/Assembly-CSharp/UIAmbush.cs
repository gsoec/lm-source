using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200032C RID: 812
public class UIAmbush : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler, IUIHIBtnClickHandler
{
	// Token: 0x0600107D RID: 4221 RVA: 0x001D5ABC File Offset: 0x001D3CBC
	public override void OnOpen(int arg1, int arg2)
	{
		this.m_TTF = GUIManager.Instance.GetTTFFont();
		this.GM = GUIManager.Instance;
		this.AM = AmbushManager.Instance;
		this.DM = DataManager.Instance;
		this.m_Door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.m_sScrollItem = new sScrollItem[16];
		for (int i = 0; i < this.m_sScrollItem.Length; i++)
		{
			this.m_sScrollItem[i].Init();
		}
		this.m_Data = new List<sScrollItemData>();
		this.m_ListHeight = new List<float>();
		this.InitUI();
		this.SetData();
		this.IniteScrollPanel();
		this.SetAmbushPlayerName();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x0600107E RID: 4222 RVA: 0x001D5B84 File Offset: 0x001D3D84
	public override void OnClose()
	{
		if (this.m_sScrollItem != null)
		{
			for (int i = 0; i < this.m_sScrollItem.Length; i++)
			{
				if (this.m_sScrollItem[i].CStr != null)
				{
					StringManager.Instance.DeSpawnString(this.m_sScrollItem[i].CStr);
					this.m_sScrollItem[i].CStr = null;
				}
				if (this.m_sScrollItem[i].ArmyIconStr != null)
				{
					StringManager.Instance.DeSpawnString(this.m_sScrollItem[i].ArmyIconStr);
					this.m_sScrollItem[i].ArmyIconStr = null;
				}
			}
		}
	}

	// Token: 0x0600107F RID: 4223 RVA: 0x001D5C40 File Offset: 0x001D3E40
	public override void UpdateUI(int arg1, int arg2)
	{
		switch (arg1)
		{
		case 0:
			this.UpdateScrollPanel();
			this.SetAmbushPlayerName();
			break;
		case 1:
			if (this.m_Door)
			{
				this.m_Door.CloseMenu(false);
			}
			break;
		case 2:
			this.SetAmbushPlayerHead();
			break;
		case 3:
			this.SetAmbushPlayerName();
			break;
		}
	}

	// Token: 0x06001080 RID: 4224 RVA: 0x001D5CB4 File Offset: 0x001D3EB4
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			if (AmbushManager.Instance.GetMaxTroop() > 0u)
			{
				this.UpdateUI(0, 0);
			}
			else
			{
				this.UpdateUI(1, 0);
			}
			break;
		default:
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
			break;
		}
	}

	// Token: 0x06001081 RID: 4225 RVA: 0x001D5D1C File Offset: 0x001D3F1C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			this.AM.SendDismissAmbush();
		}
	}

	// Token: 0x06001082 RID: 4226 RVA: 0x001D5D30 File Offset: 0x001D3F30
	private void Update()
	{
		if (this.bLeaderHero && this.m_FlashImage != null)
		{
			this.m_TickTime += Time.smoothDeltaTime;
			if (this.m_TickTime >= 0f)
			{
				if (this.m_TickTime >= 2f)
				{
					this.m_TickTime = 0f;
				}
				float a = (this.m_TickTime <= 1f) ? this.m_TickTime : (2f - this.m_TickTime);
				this.m_FlashImage.color = new Color(1f, 1f, 1f, a);
			}
		}
	}

	// Token: 0x06001083 RID: 4227 RVA: 0x001D5DE0 File Offset: 0x001D3FE0
	private void InitUI()
	{
		this.m_SpritesArray = base.transform.GetComponent<UISpritesArray>();
		this.m_UITitle = base.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_UITitle.font = this.m_TTF;
		this.m_UITitle.text = this.DM.mStringTable.GetStringByID(9726u);
		this.m_ScrollPanel = base.transform.GetChild(1).GetComponent<ScrollPanel>();
		this.m_PlayerIcon = base.transform.GetChild(3).GetComponent<UIHIBtn>();
		this.m_PlayerIcon.m_Handler = this;
		this.GM.InitianHeroItemImg(this.m_PlayerIcon.transform, eHeroOrItem.Hero, this.AM.m_AmbushPlayerHead, 11, 0, 0, false, false, true, false);
		this.m_DismissBtn = base.transform.GetChild(6).GetComponent<UIButton>();
		this.m_DismissBtn.m_Handler = this;
		this.m_DismissBtn.m_BtnID1 = 1;
		this.m_DismissText = base.transform.GetChild(6).GetChild(0).GetComponent<UIText>();
		this.m_DismissText.font = this.m_TTF;
		this.m_DismissText.text = this.DM.mStringTable.GetStringByID(9727u);
		this.m_InfoBtn = base.transform.GetChild(7).GetComponent<UIButton>();
		this.m_InfoBtn.m_Handler = this;
		this.m_InfoBtn.m_BtnID1 = 3;
		base.transform.GetChild(7).gameObject.AddComponent<ArabicItemTextureRot>();
		Image component = base.transform.GetChild(5).GetComponent<Image>();
		if (this.m_Door)
		{
			component.sprite = this.m_Door.LoadSprite("UI_main_close_base");
			component.material = this.m_Door.LoadMaterial();
		}
		this.m_ExitBtn = base.transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
		this.m_ExitBtn.m_Handler = this;
		this.m_ExitBtn.m_BtnID1 = 0;
		if (this.m_Door)
		{
			this.m_ExitBtn.image.sprite = this.m_Door.LoadSprite("UI_main_close");
			this.m_ExitBtn.image.material = this.m_Door.LoadMaterial();
		}
		this.m_PlayerNameRect = base.transform.GetChild(4).GetComponent<RectTransform>();
		this.m_PlayerName = base.transform.GetChild(4).GetChild(1).GetComponent<UIText>();
		this.m_PlayerName.font = this.m_TTF;
		UIButton component2 = base.transform.GetChild(4).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 2;
	}

	// Token: 0x06001084 RID: 4228 RVA: 0x001D60A8 File Offset: 0x001D42A8
	private void SetData()
	{
		this.m_Data.Clear();
		this.m_ListHeight.Clear();
		uint num = 0u;
		bool flag = false;
		sScrollItemData item = default(sScrollItemData);
		int[] array = new int[]
		{
			0,
			4,
			8,
			12
		};
		int[] array2 = new int[]
		{
			3,
			7,
			11,
			15
		};
		for (int i = 0; i < 4; i++)
		{
			for (int j = array2[i]; j >= array[i]; j--)
			{
				if (this.AM.m_TroopData[j] > 0u)
				{
					item = default(sScrollItemData);
					item.Type = eItem.TextType;
					item.ArmyIdx = j;
					item.ArmyNum = this.AM.m_TroopData[j];
					item.Height = 32f;
					num += item.ArmyNum;
					this.m_Data.Add(item);
				}
			}
		}
		item = default(sScrollItemData);
		item.Type = eItem.TitleType;
		item.Height = 38f;
		item.StrID = 9728;
		item.StrID_Value = 4010;
		item.StrNum = num;
		this.m_Data.Insert(0, item);
		for (int k = 0; k < 5; k++)
		{
			if (this.AM.m_HeroInfo[k].HeroID != 0)
			{
				flag = true;
			}
		}
		if (flag)
		{
			item = default(sScrollItemData);
			item.Type = eItem.TitleType;
			item.Height = 38f;
			item.StrID = 4019;
			item.StrID_Value = 4011;
			item.StrNum = 0u;
			for (int l = 0; l < 5; l++)
			{
				if (this.AM.m_HeroInfo[l].HeroID != 0)
				{
					item.StrNum += 1u;
					if (this.AM.m_HeroInfo[l].HeroID == this.AM.m_AmbushPlayerHead)
					{
						this.bLeaderHero = true;
					}
				}
			}
			this.m_Data.Add(item);
			item = default(sScrollItemData);
			item.Type = eItem.HeroType;
			item.Height = 111f;
			this.m_Data.Add(item);
		}
		for (int m = 0; m < this.m_Data.Count; m++)
		{
			this.m_ListHeight.Add(this.m_Data[m].Height);
		}
	}

	// Token: 0x06001085 RID: 4229 RVA: 0x001D6338 File Offset: 0x001D4538
	private void IniteScrollPanel()
	{
		this.m_ScrollPanel.IntiScrollPanel(527f, 0f, 6f, this.m_ListHeight, 16, this);
		this.bInitScrollPanel = true;
		if (this.m_ScrollPanel != null)
		{
			UIButtonHint.scrollRect = this.m_ScrollPanel.gameObject.GetComponent<CScrollRect>();
		}
	}

	// Token: 0x06001086 RID: 4230 RVA: 0x001D6398 File Offset: 0x001D4598
	private void UpdateScrollPanel()
	{
		this.SetData();
		this.m_ScrollPanel.AddNewDataHeight(this.m_ListHeight, false, true);
	}

	// Token: 0x06001087 RID: 4231 RVA: 0x001D63B4 File Offset: 0x001D45B4
	private void SetAmbushPlayerName()
	{
		if (this.m_PlayerName == null)
		{
			return;
		}
		this.m_PlayerName.text = this.AM.m_AmbushPlayerName.ToString();
		this.m_PlayerName.SetAllDirty();
		this.m_PlayerName.cachedTextGenerator.Invalidate();
		this.m_PlayerName.cachedTextGeneratorForLayout.Invalidate();
		Vector2 sizeDelta = this.m_PlayerName.rectTransform.sizeDelta;
		sizeDelta.x = ((this.m_PlayerName.preferredWidth >= 245f) ? 245f : this.m_PlayerName.preferredWidth);
		this.m_PlayerName.rectTransform.sizeDelta = sizeDelta;
		sizeDelta = this.m_PlayerNameRect.sizeDelta;
		sizeDelta.x = ((this.m_PlayerName.preferredWidth >= 245f) ? 245f : this.m_PlayerName.preferredWidth);
		this.m_PlayerNameRect.sizeDelta = sizeDelta;
	}

	// Token: 0x06001088 RID: 4232 RVA: 0x001D64B8 File Offset: 0x001D46B8
	private void SetAmbushPlayerHead()
	{
		if (this.m_PlayerIcon == null)
		{
			return;
		}
		this.GM.ChangeHeroItemImg(this.m_PlayerIcon.transform, eHeroOrItem.Hero, this.AM.m_AmbushPlayerHead, 11, 0, 0);
	}

	// Token: 0x06001089 RID: 4233 RVA: 0x001D6500 File Offset: 0x001D4700
	private void SetScrollItem(GameObject item, int panelObjectIdx, int dataIdx)
	{
		item.transform.GetChild(0).gameObject.SetActive(false);
		item.transform.GetChild(1).gameObject.SetActive(false);
		item.transform.GetChild(2).gameObject.SetActive(false);
		if (dataIdx < this.m_Data.Count && panelObjectIdx < 16)
		{
			switch (this.m_Data[dataIdx].Type)
			{
			case eItem.TitleType:
				item.transform.GetChild(0).gameObject.SetActive(true);
				this.SetTitleType(this.m_sScrollItem[panelObjectIdx], dataIdx);
				break;
			case eItem.TextType:
				item.transform.GetChild(1).gameObject.SetActive(true);
				this.SetTextType(this.m_sScrollItem[panelObjectIdx], dataIdx);
				break;
			case eItem.HeroType:
				item.transform.GetChild(2).gameObject.SetActive(true);
				this.SetHeroType(this.m_sScrollItem[panelObjectIdx], dataIdx);
				break;
			}
		}
	}

	// Token: 0x0600108A RID: 4234 RVA: 0x001D6634 File Offset: 0x001D4834
	private void SetTitleType(sScrollItem item, int dataIdx)
	{
		if (dataIdx < this.m_Data.Count)
		{
			item.TitleType.Text1.text = this.DM.mStringTable.GetStringByID((uint)this.m_Data[dataIdx].StrID);
			item.CStr.ClearString();
			item.CStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.m_Data[dataIdx].StrID_Value));
			item.CStr.IntToFormat((long)((ulong)this.m_Data[dataIdx].StrNum), 1, true);
			item.CStr.AppendFormat("{0}{1}");
			item.TitleType.Text2.text = item.CStr.ToString();
		}
	}

	// Token: 0x0600108B RID: 4235 RVA: 0x001D6718 File Offset: 0x001D4918
	private void SetTextType(sScrollItem item, int dataIdx)
	{
		int armyIdx = 0;
		if (dataIdx < this.m_Data.Count && dataIdx >= 0)
		{
			armyIdx = this.m_Data[dataIdx].ArmyIdx;
		}
		item.TextType.Text1.text = this.DM.mStringTable.GetStringByID((uint)this.GetArmyStringID(armyIdx));
		item.CStr.ClearString();
		item.CStr.IntToFormat((long)((ulong)this.m_Data[dataIdx].ArmyNum), 1, true);
		item.CStr.AppendFormat("{0}");
		item.TextType.Text2.text = item.CStr.ToString();
		this.SetArmyIcon(item.TextType.IconImage, armyIdx, item.TextType.iconText, item.ArmyIconStr, item.TextType.Hint, item.TextType.BackgroundImage, item.TextType.Text1.preferredWidth);
		item.TextType.Text1.alignment = TextAnchor.MiddleLeft;
		item.TextType.Text2.alignment = TextAnchor.MiddleRight;
	}

	// Token: 0x0600108C RID: 4236 RVA: 0x001D6850 File Offset: 0x001D4A50
	private void SetHeroType(sScrollItem item, int dataIdx)
	{
		for (int i = 0; i < 5; i++)
		{
			if (this.AM.m_HeroInfo[i].HeroID != 0)
			{
				Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.AM.m_HeroInfo[i].HeroID);
				item.HeroType.HeroImage[i].sprite = this.GM.m_IconSpriteAsset.LoadSprite(recordByKey.Graph);
				item.HeroType.HeroImage[i].material = this.GM.m_IconSpriteAsset.GetMaterial();
				if (item.HeroType.HeroImage[i].sprite == null)
				{
					item.HeroType.HeroImage[i].sprite = this.GM.m_ItemIconSpriteAsset.LoadSprite(1130);
					item.HeroType.HeroImage[i].material = this.GM.m_ItemIconSpriteAsset.GetMaterial();
				}
				item.HeroType.FrameImage[i].material = this.GM.GetFrameMaterial();
				if (this.AM.m_HeroInfo[i].Star != 0)
				{
					item.HeroType.FrameImage[i].sprite = this.GM.LoadFrameSprite(EFrameSprite.Hero, this.AM.m_HeroInfo[i].Star);
				}
				if (this.AM.m_HeroInfo[i].Rank != 0)
				{
					item.HeroType.RankImage[i].sprite = this.GM.LoadFrameSprite(EFrameSprite.Hero, this.AM.m_HeroInfo[i].Rank + 100);
				}
				item.HeroType.RankImage[i].material = this.GM.GetFrameMaterial();
				if (i == 0)
				{
					if (this.bLeaderHero)
					{
						item.HeroType.LordsIcon1.enabled = true;
						item.HeroType.LordsIcon2.enabled = true;
					}
					else
					{
						item.HeroType.LordsIcon1.enabled = false;
						item.HeroType.LordsIcon2.enabled = false;
					}
					this.m_FlashImage = item.HeroType.LordsIcon2;
				}
				item.HeroType.Tf[i].gameObject.SetActive(true);
			}
			else
			{
				item.HeroType.Tf[i].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x0600108D RID: 4237 RVA: 0x001D6AF0 File Offset: 0x001D4CF0
	public ushort GetArmyStringID(int ArmyIdx)
	{
		return this.DM.SoldierDataTable.GetRecordByKey((ushort)(ArmyIdx + 1)).Name;
	}

	// Token: 0x0600108E RID: 4238 RVA: 0x001D6B1C File Offset: 0x001D4D1C
	public void SetArmyIcon(Image image, int ArmyIdx, UIText IconText, CString str, UIButtonHint hint, Image background, float textWidth)
	{
		if (background == null || image == null || this.m_SpritesArray == null)
		{
			return;
		}
		Vector2 sizeDelta = background.rectTransform.sizeDelta;
		sizeDelta.x = ((textWidth <= 238.4f) ? (textWidth + 40f) : 278.4f);
		background.rectTransform.sizeDelta = sizeDelta;
		SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort)(ArmyIdx + 1));
		image.sprite = this.m_SpritesArray.GetSprite((int)recordByKey.SoldierKind);
		str.ClearString();
		str.IntToFormat((long)recordByKey.Tier, 1, false);
		str.AppendFormat("{0}");
		IconText.text = str.ToString();
		hint.Parm1 = (ushort)ArmyIdx;
	}

	// Token: 0x0600108F RID: 4239 RVA: 0x001D6BFC File Offset: 0x001D4DFC
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (panelObjectIdx < 16 && !this.m_sScrollItem[panelObjectIdx].bInit)
		{
			this.m_sScrollItem[panelObjectIdx].TitleType.Text1 = item.transform.GetChild(0).GetChild(0).GetComponent<UIText>();
			this.m_sScrollItem[panelObjectIdx].TitleType.Text2 = item.transform.GetChild(0).GetChild(1).GetComponent<UIText>();
			this.m_sScrollItem[panelObjectIdx].TitleType.Text1.font = this.m_TTF;
			this.m_sScrollItem[panelObjectIdx].TitleType.Text2.font = this.m_TTF;
			this.m_sScrollItem[panelObjectIdx].TextType.Text1 = item.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
			this.m_sScrollItem[panelObjectIdx].TextType.Text2 = item.transform.GetChild(1).GetChild(1).GetComponent<UIText>();
			this.m_sScrollItem[panelObjectIdx].TextType.Text1.font = this.m_TTF;
			this.m_sScrollItem[panelObjectIdx].TextType.Text2.font = this.m_TTF;
			this.m_sScrollItem[panelObjectIdx].TextType.Hint = item.transform.GetChild(1).GetChild(2).gameObject.AddComponent<UIButtonHint>();
			this.m_sScrollItem[panelObjectIdx].TextType.Hint.m_eHint = EUIButtonHint.CountDown;
			this.m_sScrollItem[panelObjectIdx].TextType.Hint.DelayTime = 0.2f;
			this.m_sScrollItem[panelObjectIdx].TextType.Hint.m_Handler = this;
			this.m_sScrollItem[panelObjectIdx].TextType.Hint.Parm1 = 0;
			this.m_sScrollItem[panelObjectIdx].TextType.BackgroundImage = item.transform.GetChild(1).GetChild(2).GetComponent<Image>();
			this.m_sScrollItem[panelObjectIdx].TextType.IconImage = item.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>();
			this.m_sScrollItem[panelObjectIdx].TextType.iconText = item.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<UIText>();
			this.m_sScrollItem[panelObjectIdx].TextType.iconText.font = this.m_TTF;
			for (int i = 0; i < 5; i++)
			{
				this.m_sScrollItem[panelObjectIdx].HeroType.Tf[i] = item.transform.GetChild(2).GetChild(i);
				this.m_sScrollItem[panelObjectIdx].HeroType.FrameImage[i] = item.transform.GetChild(2).GetChild(i).GetChild(1).GetComponent<Image>();
				this.m_sScrollItem[panelObjectIdx].HeroType.HeroImage[i] = item.transform.GetChild(2).GetChild(i).GetChild(0).GetComponent<Image>();
				this.m_sScrollItem[panelObjectIdx].HeroType.RankImage[i] = item.transform.GetChild(2).GetChild(i).GetChild(2).GetComponent<Image>();
				if (i == 0)
				{
					this.m_sScrollItem[panelObjectIdx].HeroType.LordsIcon1 = item.transform.GetChild(2).GetChild(i).GetChild(3).GetComponent<Image>();
					this.m_sScrollItem[panelObjectIdx].HeroType.LordsIcon2 = item.transform.GetChild(2).GetChild(i).GetChild(4).GetComponent<Image>();
				}
			}
			this.m_sScrollItem[panelObjectIdx].bInit = true;
		}
		this.SetScrollItem(item, panelObjectIdx, dataIdx);
	}

	// Token: 0x06001090 RID: 4240 RVA: 0x001D701C File Offset: 0x001D521C
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001091 RID: 4241 RVA: 0x001D7020 File Offset: 0x001D5220
	public void OnButtonClick(UIButton sender)
	{
		switch (sender.m_BtnID1)
		{
		case 0:
			if (this.m_Door)
			{
				this.m_Door.CloseMenu(false);
			}
			break;
		case 1:
			this.GM.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(9759u), this.DM.mStringTable.GetStringByID(9729u), 0, 0, this.DM.mStringTable.GetStringByID(4842u), this.DM.mStringTable.GetStringByID(4843u));
			break;
		case 2:
			if (this.m_Door)
			{
				this.m_Door.GoToPointCode(DataManager.MapDataController.OtherKingdomData.kingdomID, this.AM.m_AmbushPlayerCapitalPos.zoneID, this.AM.m_AmbushPlayerCapitalPos.pointID, 0);
			}
			break;
		case 3:
			GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(9129u), DataManager.Instance.mStringTable.GetStringByID(9768u), null, null, 0, 0, true, false);
			break;
		}
	}

	// Token: 0x06001092 RID: 4242 RVA: 0x001D7164 File Offset: 0x001D5364
	public void OnHIButtonClick(UIHIBtn sender)
	{
		this.m_Door.GoToPointCode(DataManager.MapDataController.OtherKingdomData.kingdomID, this.AM.m_AmbushPlayerCapitalPos.zoneID, this.AM.m_AmbushPlayerCapitalPos.pointID, 0);
	}

	// Token: 0x06001093 RID: 4243 RVA: 0x001D71A4 File Offset: 0x001D53A4
	public void OnButtonDown(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, 3, 277f, 20, (int)sender.Parm1, 0, new Vector2(70f, 0f), UIButtonHint.ePosition.Original);
	}

	// Token: 0x06001094 RID: 4244 RVA: 0x001D71E4 File Offset: 0x001D53E4
	public void OnButtonUp(UIButtonHint sender)
	{
		GUIManager.Instance.m_Hint.Hide(sender);
	}

	// Token: 0x06001095 RID: 4245 RVA: 0x001D71FC File Offset: 0x001D53FC
	public void Refresh_FontTexture()
	{
		if (this.m_UITitle != null && this.m_UITitle.enabled)
		{
			this.m_UITitle.enabled = false;
			this.m_UITitle.enabled = true;
		}
		if (this.m_PlayerName != null && this.m_PlayerName.enabled)
		{
			this.m_PlayerName.enabled = false;
			this.m_PlayerName.enabled = true;
		}
		if (this.m_DismissText != null && this.m_DismissText.enabled)
		{
			this.m_DismissText.enabled = false;
			this.m_DismissText.enabled = true;
		}
		if (this.m_sScrollItem != null)
		{
			for (int i = 0; i < this.m_sScrollItem.Length; i++)
			{
				if (this.m_sScrollItem[i].TitleType.Text1 != null && this.m_sScrollItem[i].TitleType.Text1.enabled)
				{
					this.m_sScrollItem[i].TitleType.Text1.enabled = false;
					this.m_sScrollItem[i].TitleType.Text1.enabled = true;
				}
				if (this.m_sScrollItem[i].TitleType.Text2 != null && this.m_sScrollItem[i].TitleType.Text2.enabled)
				{
					this.m_sScrollItem[i].TitleType.Text2.enabled = false;
					this.m_sScrollItem[i].TitleType.Text2.enabled = true;
				}
				if (this.m_sScrollItem[i].TextType.Text1 != null && this.m_sScrollItem[i].TextType.Text1.enabled)
				{
					this.m_sScrollItem[i].TextType.Text1.enabled = false;
					this.m_sScrollItem[i].TextType.Text1.enabled = true;
				}
				if (this.m_sScrollItem[i].TextType.Text2 != null && this.m_sScrollItem[i].TextType.Text2.enabled)
				{
					this.m_sScrollItem[i].TextType.Text2.enabled = false;
					this.m_sScrollItem[i].TextType.Text2.enabled = true;
				}
				if (this.m_sScrollItem[i].TextType.iconText != null && this.m_sScrollItem[i].TextType.iconText.enabled)
				{
					this.m_sScrollItem[i].TextType.iconText.enabled = false;
					this.m_sScrollItem[i].TextType.iconText.enabled = true;
				}
			}
		}
	}

	// Token: 0x0400360D RID: 13837
	private const int Max_Item = 16;

	// Token: 0x0400360E RID: 13838
	private const float ScrollHeight = 527f;

	// Token: 0x0400360F RID: 13839
	private const float TitleTypeHeight = 38f;

	// Token: 0x04003610 RID: 13840
	private const float TextTypeHeight = 32f;

	// Token: 0x04003611 RID: 13841
	private const float HeroTypeHeight = 111f;

	// Token: 0x04003612 RID: 13842
	private Font m_TTF;

	// Token: 0x04003613 RID: 13843
	private GUIManager GM;

	// Token: 0x04003614 RID: 13844
	private AmbushManager AM;

	// Token: 0x04003615 RID: 13845
	private DataManager DM;

	// Token: 0x04003616 RID: 13846
	private Door m_Door;

	// Token: 0x04003617 RID: 13847
	private RectTransform m_PlayerNameRect;

	// Token: 0x04003618 RID: 13848
	private UIText m_UITitle;

	// Token: 0x04003619 RID: 13849
	private UIText m_PlayerName;

	// Token: 0x0400361A RID: 13850
	private UIText m_DismissText;

	// Token: 0x0400361B RID: 13851
	private ScrollPanel m_ScrollPanel;

	// Token: 0x0400361C RID: 13852
	private UIHIBtn m_PlayerIcon;

	// Token: 0x0400361D RID: 13853
	private UIButton m_DismissBtn;

	// Token: 0x0400361E RID: 13854
	private UIButton m_ExitBtn;

	// Token: 0x0400361F RID: 13855
	private UIButton m_InfoBtn;

	// Token: 0x04003620 RID: 13856
	private bool bInitScrollPanel;

	// Token: 0x04003621 RID: 13857
	private sScrollItem[] m_sScrollItem;

	// Token: 0x04003622 RID: 13858
	private List<sScrollItemData> m_Data;

	// Token: 0x04003623 RID: 13859
	private List<float> m_ListHeight;

	// Token: 0x04003624 RID: 13860
	private float m_TickTime;

	// Token: 0x04003625 RID: 13861
	private bool bLeaderHero;

	// Token: 0x04003626 RID: 13862
	private Image m_FlashImage;

	// Token: 0x04003627 RID: 13863
	private UISpritesArray m_SpritesArray;
}
