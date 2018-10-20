using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000507 RID: 1287
public class UIBuffList : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x060019B8 RID: 6584 RVA: 0x002B94C4 File Offset: 0x002B76C4
	public override void OnOpen(int arg1, int arg2)
	{
		this.m_UIType = (eBuffListUIType)arg1;
		this.DM = DataManager.Instance;
		this.GM = GUIManager.Instance;
		this.TTF = this.GM.GetTTFFont();
		this.m_door = (this.GM.FindMenu(EGUIWindow.Door) as Door);
		this.m_BuffItem = new BuffItemObj[7];
		for (int i = 0; i < 7; i++)
		{
			this.m_BuffItem[i].Item = new ItemObj[3];
		}
		for (int j = 0; j < 7; j++)
		{
			for (int k = 0; k < 3; k++)
			{
				if (this.m_BuffItem[j].Item[k].TimeStr == null)
				{
					this.m_BuffItem[j].Item[k].TimeStr = StringManager.Instance.SpawnString(30);
				}
				if (this.m_BuffItem[j].Item[k].InfoStr1 == null)
				{
					this.m_BuffItem[j].Item[k].InfoStr1 = StringManager.Instance.SpawnString(30);
				}
				if (this.m_BuffItem[j].Item[k].InfoStr2 == null)
				{
					this.m_BuffItem[j].Item[k].InfoStr2 = StringManager.Instance.SpawnString(30);
				}
				if (this.m_BuffItem[j].Item[k].InfoStr3 == null)
				{
					this.m_BuffItem[j].Item[k].InfoStr3 = StringManager.Instance.SpawnString(30);
				}
			}
		}
		this.m_CDCStr = StringManager.Instance.SpawnString(30);
		this.m_TitleType = new byte[this.DM.MaxBuffTableCount];
		Array.Clear(this.m_TitleType, 0, this.DM.MaxBuffTableCount);
		this.m_Data = new List<ushort>();
		this.SetTitleType();
		this.m_SpriteArray = base.transform.GetComponent<UISpritesArray>();
		this.m_tmptext[this.mTextCount] = base.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		if (this.m_UIType == eBuffListUIType.BuffList)
		{
			this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(6093u);
		}
		else if (this.m_UIType == eBuffListUIType.AttackBuffList)
		{
			this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(8202u);
		}
		else if (this.m_UIType == eBuffListUIType.DefendBuffList)
		{
			this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(8204u);
		}
		else if (this.m_UIType == eBuffListUIType.KingdomBuff)
		{
			this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(1453u);
		}
		this.mTextCount++;
		this.m_tmptext[this.mTextCount] = base.transform.GetChild(0).GetChild(3).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = this.TTF;
		if (this.m_UIType == eBuffListUIType.BuffList)
		{
			this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(6098u);
		}
		else if (this.m_UIType == eBuffListUIType.AttackBuffList)
		{
			this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(8203u);
		}
		else if (this.m_UIType == eBuffListUIType.DefendBuffList)
		{
			this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(8205u);
		}
		else if (this.m_UIType == eBuffListUIType.KingdomBuff)
		{
			this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(1454u);
		}
		this.mTextCount++;
		Image component = base.transform.GetChild(3).GetComponent<Image>();
		component.sprite = this.m_door.LoadSprite("UI_main_close_base");
		component.material = this.m_door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX && component)
		{
			component.enabled = false;
		}
		UIButton component2 = base.transform.GetChild(3).GetChild(0).GetComponent<UIButton>();
		component2.image.sprite = this.m_door.LoadSprite("UI_main_close");
		component2.image.material = this.m_door.LoadMaterial();
		component2.m_BtnID1 = 999;
		component2.m_Handler = this;
		if (GUIManager.Instance.IsArabic)
		{
			RectTransform component3 = base.transform.GetChild(2).GetChild(0).GetChild(2).GetComponent<RectTransform>();
			Vector2 anchoredPosition = component3.anchoredPosition;
			anchoredPosition.x = 93f;
			component3.anchoredPosition = anchoredPosition;
			Vector3 localScale = component3.localScale;
			localScale.x = -1f;
			component3.localScale = localScale;
			component3 = base.transform.GetChild(2).GetChild(1).GetChild(2).GetComponent<RectTransform>();
			anchoredPosition = component3.anchoredPosition;
			anchoredPosition.x = 93f;
			component3.anchoredPosition = anchoredPosition;
			localScale = component3.localScale;
			localScale.x = -1f;
			component3.localScale = localScale;
		}
		this.m_ScrollPanel = base.transform.GetChild(1).GetComponent<ScrollPanel>();
		List<float> list = new List<float>();
		for (int l = 0; l < this.m_Data.Count; l++)
		{
			if (this.m_Data[l] == 9999)
			{
				list.Add(this.GetTitleItemH());
			}
			else if (this.m_TitleType[(int)this.m_Data[l]] > 0)
			{
				list.Add(113f);
			}
			else
			{
				list.Add(78f);
			}
		}
		this.m_ScrollPanel.IntiScrollPanel(470f, 0f, 0f, list, 7, this);
		this.m_ScrollContentRT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
		if (this.DM.m_BuffScrollIndex != 0 && this.DM.m_BuffScrollPos > 0f && !NewbieManager.IsTeachWorking(ETeachKind.DESHIELD))
		{
			this.m_ScrollPanel.GoTo(this.DM.m_BuffScrollIndex, this.DM.m_BuffScrollPos);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x060019B9 RID: 6585 RVA: 0x002B9BF8 File Offset: 0x002B7DF8
	public override void OnClose()
	{
		for (int i = 0; i < 7; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				if (this.m_BuffItem[i].Item[j].TimeStr != null)
				{
					StringManager.Instance.DeSpawnString(this.m_BuffItem[i].Item[j].TimeStr);
				}
				if (this.m_BuffItem[i].Item[j].InfoStr1 != null)
				{
					StringManager.Instance.DeSpawnString(this.m_BuffItem[i].Item[j].InfoStr1);
				}
				if (this.m_BuffItem[i].Item[j].InfoStr2 != null)
				{
					StringManager.Instance.DeSpawnString(this.m_BuffItem[i].Item[j].InfoStr2);
				}
				if (this.m_BuffItem[i].Item[j].InfoStr3 != null)
				{
					StringManager.Instance.DeSpawnString(this.m_BuffItem[i].Item[j].InfoStr3);
				}
			}
		}
		StringManager.Instance.DeSpawnString(this.m_CDCStr);
		this.DM.m_BuffScrollIndex = this.m_ScrollPanel.GetTopIdx();
		this.DM.m_BuffScrollPos = this.m_ScrollContentRT.anchoredPosition.y;
	}

	// Token: 0x060019BA RID: 6586 RVA: 0x002B9D90 File Offset: 0x002B7F90
	public override void UpdateUI(int arg1, int arg2)
	{
	}

	// Token: 0x060019BB RID: 6587 RVA: 0x002B9D94 File Offset: 0x002B7F94
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
		case NetworkNews.Refresh:
			break;
		default:
			if (networkNews != NetworkNews.Refresh_Item && networkNews != NetworkNews.Refresh_BuffList)
			{
				if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
				{
					return;
				}
				this.Refresh_FontTexture();
				return;
			}
			break;
		}
		if (!NewbieManager.IsTeachWorking(ETeachKind.DESHIELD))
		{
			this.SetTitleType();
			List<float> list = new List<float>();
			for (int i = 0; i < this.m_Data.Count; i++)
			{
				if (this.m_Data[i] == 9999)
				{
					list.Add(this.GetTitleItemH());
				}
				else if (this.m_TitleType[(int)this.m_Data[i]] > 0)
				{
					list.Add(113f);
				}
				else
				{
					list.Add(78f);
				}
			}
			this.m_ScrollPanel.AddNewDataHeight(list, false, true);
		}
	}

	// Token: 0x060019BC RID: 6588 RVA: 0x002B9E88 File Offset: 0x002B8088
	public void Refresh_FontTexture()
	{
		for (int i = 0; i < 2; i++)
		{
			if (this.m_tmptext[i] != null && this.m_tmptext[i].enabled)
			{
				this.m_tmptext[i].enabled = false;
				this.m_tmptext[i].enabled = true;
			}
		}
		for (int j = 0; j < 7; j++)
		{
			if (this.m_BuffItem[j].Item != null)
			{
				for (int k = 0; k < 2; k++)
				{
					if (this.m_BuffItem[j].Item[k].Title != null && this.m_BuffItem[j].Item[k].Title.enabled)
					{
						this.m_BuffItem[j].Item[k].Title.enabled = false;
						this.m_BuffItem[j].Item[k].Title.enabled = true;
					}
					if (this.m_BuffItem[j].Item[k].Title2 != null && this.m_BuffItem[j].Item[k].Title2.enabled)
					{
						this.m_BuffItem[j].Item[k].Title2.enabled = false;
						this.m_BuffItem[j].Item[k].Title2.enabled = true;
					}
					if (this.m_BuffItem[j].Item[k].ItemName != null && this.m_BuffItem[j].Item[k].ItemName.enabled)
					{
						this.m_BuffItem[j].Item[k].ItemName.enabled = false;
						this.m_BuffItem[j].Item[k].ItemName.enabled = true;
					}
					if (this.m_BuffItem[j].Item[k].ItemInFo != null && this.m_BuffItem[j].Item[k].ItemInFo.enabled)
					{
						this.m_BuffItem[j].Item[k].ItemInFo.enabled = false;
						this.m_BuffItem[j].Item[k].ItemInFo.enabled = true;
					}
					if (this.m_BuffItem[j].Item[k].ItemInFo2 != null && this.m_BuffItem[j].Item[k].ItemInFo2.enabled)
					{
						this.m_BuffItem[j].Item[k].ItemInFo2.enabled = false;
						this.m_BuffItem[j].Item[k].ItemInFo2.enabled = true;
					}
					if (this.m_BuffItem[j].Item[k].ItemInFo3 != null && this.m_BuffItem[j].Item[k].ItemInFo3.enabled)
					{
						this.m_BuffItem[j].Item[k].ItemInFo3.enabled = false;
						this.m_BuffItem[j].Item[k].ItemInFo3.enabled = true;
					}
					if (this.m_BuffItem[j].Item[k].ItemLogBtnText != null && this.m_BuffItem[j].Item[k].ItemLogBtnText.enabled)
					{
						this.m_BuffItem[j].Item[k].ItemLogBtnText.enabled = false;
						this.m_BuffItem[j].Item[k].ItemLogBtnText.enabled = true;
					}
					if (this.m_BuffItem[j].Item[k].TimeFlash != null && this.m_BuffItem[j].Item[k].TimeFlash.enabled)
					{
						this.m_BuffItem[j].Item[k].TimeFlash.enabled = false;
						this.m_BuffItem[j].Item[k].TimeFlash.enabled = true;
					}
					if (this.m_BuffItem[j].Item[k].TimeSlider != null && this.m_BuffItem[j].Item[k].TimeSlider.enabled)
					{
						this.m_BuffItem[j].Item[k].TimeSlider.enabled = false;
						this.m_BuffItem[j].Item[k].TimeSlider.enabled = true;
					}
					if (this.m_BuffItem[j].Item[k].TimeTitle != null && this.m_BuffItem[j].Item[k].TimeTitle.enabled)
					{
						this.m_BuffItem[j].Item[k].TimeTitle.enabled = false;
						this.m_BuffItem[j].Item[k].TimeTitle.enabled = true;
					}
					if (this.m_BuffItem[j].Item[k].TimeText != null && this.m_BuffItem[j].Item[k].TimeText.enabled)
					{
						this.m_BuffItem[j].Item[k].TimeText.enabled = false;
						this.m_BuffItem[j].Item[k].TimeText.enabled = true;
					}
				}
			}
		}
	}

	// Token: 0x060019BD RID: 6589 RVA: 0x002BA560 File Offset: 0x002B8760
	public void Update()
	{
		this.ColorTime += Time.deltaTime;
		if (this.ColorTime >= this.FlashTime)
		{
			this.ColorTime = 0f;
		}
		this.ColorA = this.ATween(this.ColorTime, 0f, 2f, this.FlashTime);
		this.UpdateTime();
		this.UpdateSlider();
		this.UpdateSliderAlpha();
		this.UpdateCDTime(DataManager.Instance.KingCoolEndTime);
	}

	// Token: 0x060019BE RID: 6590 RVA: 0x002BA5E0 File Offset: 0x002B87E0
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (dataIdx < 0 || dataIdx >= this.m_Data.Count)
		{
			return;
		}
		if (this.m_BuffItem[panelObjectIdx].Item[0].ItemFrame == null)
		{
			this.m_BuffItem[panelObjectIdx].Item[0].gameObject = item.transform.GetChild(0).gameObject;
			this.m_BuffItem[panelObjectIdx].Item[0].ItemBg = item.transform.GetChild(0).GetChild(0).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[0].ItemBgIcon = item.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[0].ItemIconRect = item.transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
			this.m_BuffItem[panelObjectIdx].Item[0].ItemImage = item.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[0].ItemFrame = item.transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[0].Title = item.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[0].Title.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[0].Title2 = item.transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[0].Title2.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[0].CDText = item.transform.GetChild(0).GetChild(1).GetChild(2).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[0].CDText.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[0].CDIcon = item.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnImage = item.transform.GetChild(0).GetChild(1).GetChild(3).GetChild(0).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnText = item.transform.GetChild(0).GetChild(1).GetChild(3).GetChild(1).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnText.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnRect = item.transform.GetChild(0).GetChild(1).GetChild(3).GetComponent<RectTransform>();
			this.m_BuffItem[panelObjectIdx].Item[0].ItemName = item.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[0].ItemName.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[0].ItemInFo = item.transform.GetChild(0).GetChild(3).GetChild(1).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[0].ItemInFo.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[0].Btn = item.transform.GetChild(0).GetChild(0).GetComponent<UIButton>();
			this.m_BuffItem[panelObjectIdx].Item[0].Btn.m_Handler = this;
			this.m_BuffItem[panelObjectIdx].Item[0].TimeFlash = item.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[0].TimeSlider = item.transform.GetChild(0).GetChild(4).GetChild(1).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[0].TimeTitle = item.transform.GetChild(0).GetChild(4).GetChild(2).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[0].TimeTitle.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[0].TimeTitle.text = this.DM.mStringTable.GetStringByID(6097u);
			this.m_BuffItem[panelObjectIdx].Item[0].TimeText = item.transform.GetChild(0).GetChild(4).GetChild(3).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[0].TimeText.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[1].gameObject = item.transform.GetChild(1).gameObject;
			this.m_BuffItem[panelObjectIdx].Item[1].ItemBg = item.transform.GetChild(1).GetChild(0).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[1].ItemBgIcon = item.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[1].ItemIconRect = item.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
			this.m_BuffItem[panelObjectIdx].Item[1].ItemImage = item.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[1].ItemFrame = item.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[1].Title = item.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[1].Title.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[1].Title2 = this.m_BuffItem[panelObjectIdx].Item[1].Title;
			this.m_BuffItem[panelObjectIdx].Item[1].ItemName = item.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[1].ItemName.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[1].ItemInFo = item.transform.GetChild(1).GetChild(3).GetChild(1).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[1].ItemInFo.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[1].Btn = item.transform.GetChild(1).GetChild(0).GetComponent<UIButton>();
			this.m_BuffItem[panelObjectIdx].Item[1].Btn.m_Handler = this;
			this.m_BuffItem[panelObjectIdx].Item[1].TimeFlash = item.transform.GetChild(1).GetChild(4).GetChild(0).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[1].TimeSlider = item.transform.GetChild(1).GetChild(4).GetChild(1).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[1].TimeTitle = item.transform.GetChild(1).GetChild(4).GetChild(2).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[1].TimeTitle.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[1].TimeTitle.text = this.DM.mStringTable.GetStringByID(6097u);
			this.m_BuffItem[panelObjectIdx].Item[1].TimeText = item.transform.GetChild(1).GetChild(4).GetChild(3).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[1].TimeText.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[2].gameObject = item.transform.GetChild(2).gameObject;
			this.m_BuffItem[panelObjectIdx].Item[2].ItemBg = item.transform.GetChild(2).GetChild(0).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[2].ItemBgIcon = item.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[2].ItemIconRect = item.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>();
			this.m_BuffItem[panelObjectIdx].Item[2].ItemImage = item.transform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[2].ItemFrame = item.transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<Image>();
			this.m_BuffItem[panelObjectIdx].Item[2].Title = item.transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[2].Title.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[2].Title2 = this.m_BuffItem[panelObjectIdx].Item[1].Title;
			this.m_BuffItem[panelObjectIdx].Item[2].ItemName = item.transform.GetChild(2).GetChild(3).GetChild(0).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[2].ItemName.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo = item.transform.GetChild(2).GetChild(3).GetChild(1).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2 = item.transform.GetChild(2).GetChild(3).GetChild(2).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3 = item.transform.GetChild(2).GetChild(3).GetChild(3).GetComponent<UIText>();
			this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3.font = this.TTF;
			this.m_BuffItem[panelObjectIdx].Item[2].Btn = item.transform.GetChild(2).GetChild(0).GetComponent<UIButton>();
			this.m_BuffItem[panelObjectIdx].Item[2].Btn.m_Handler = this;
		}
		if (this.m_Data[dataIdx] == 9999)
		{
			float titleItemH = this.GetTitleItemH();
			item.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(738f, titleItemH);
			this.m_BuffItem[panelObjectIdx].Item[2].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(738f, titleItemH);
			this.m_BuffItem[panelObjectIdx].Item[0].gameObject.SetActive(false);
			this.m_BuffItem[panelObjectIdx].Item[1].gameObject.SetActive(false);
			this.m_BuffItem[panelObjectIdx].Item[2].gameObject.SetActive(true);
			this.m_BuffItem[panelObjectIdx].Item[2].ItemBg.gameObject.SetActive(true);
			this.m_BuffItem[panelObjectIdx].Item[2].ItemBgIcon.enabled = false;
			TitleData recordByKey = this.DM.TitleDataN.GetRecordByKey(this.DM.RoleAttr.WorldTitle_Country);
			this.m_BuffItem[panelObjectIdx].Item[2].ItemImage.sprite = this.GM.LoadTitleSprite(recordByKey.IconID, eTitleKind.KingdomTitle);
			this.m_BuffItem[panelObjectIdx].Item[2].ItemImage.material = this.GM.GetTitleMaterial();
			this.m_BuffItem[panelObjectIdx].Item[2].ItemFrame.enabled = false;
			GameConstants.GetEffectValue(this.m_BuffItem[panelObjectIdx].Item[2].InfoStr1, recordByKey.Effects[0].EffectID, (uint)recordByKey.Effects[0].Value, 11, 0f);
			this.m_BuffItem[panelObjectIdx].Item[2].ItemName.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.StringID);
			this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo.text = this.m_BuffItem[panelObjectIdx].Item[2].InfoStr1.ToString();
			this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo.SetAllDirty();
			this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo.cachedTextGenerator.Invalidate();
			if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey.Effects[0].EffectID).StatusIcon == 0)
			{
				this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo.color = this.GoogEffColor;
			}
			else
			{
				this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo.color = this.BadEffColor;
			}
			if (recordByKey.Effects[1].EffectID > 0)
			{
				GameConstants.GetEffectValue(this.m_BuffItem[panelObjectIdx].Item[2].InfoStr2, recordByKey.Effects[1].EffectID, (uint)recordByKey.Effects[1].Value, 11, 0f);
				this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2.text = this.m_BuffItem[panelObjectIdx].Item[2].InfoStr2.ToString();
				this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2.SetAllDirty();
				this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2.cachedTextGenerator.Invalidate();
				this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2.gameObject.SetActive(true);
				if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey.Effects[1].EffectID).StatusIcon == 0)
				{
					this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2.color = this.GoogEffColor;
				}
				else
				{
					this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2.color = this.BadEffColor;
				}
			}
			else
			{
				this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2.gameObject.SetActive(false);
			}
			if (titleItemH == 176f)
			{
				this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3.gameObject.SetActive(true);
				GameConstants.GetEffectValue(this.m_BuffItem[panelObjectIdx].Item[2].InfoStr3, recordByKey.Effects[2].EffectID, (uint)recordByKey.Effects[2].Value, 11, 0f);
				this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3.text = this.m_BuffItem[panelObjectIdx].Item[2].InfoStr3.ToString();
				this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3.SetAllDirty();
				this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3.cachedTextGenerator.Invalidate();
				item.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector2(35.7f, -75.5f);
				if (DataManager.Instance.EffectData.GetRecordByKey(recordByKey.Effects[2].EffectID).StatusIcon == 0)
				{
					this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3.color = this.GoogEffColor;
				}
				else
				{
					this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3.color = this.BadEffColor;
				}
			}
			else
			{
				item.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector2(35.7f, -57.5f);
				this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3.gameObject.SetActive(false);
			}
			this.m_BuffItem[panelObjectIdx].Item[2].Title.text = this.DM.mStringTable.GetStringByID(11027u);
			this.m_BuffItem[panelObjectIdx].Item[2].Title2.enabled = false;
			Vector2 vector = this.m_BuffItem[panelObjectIdx].Item[0].ItemBg.rectTransform.sizeDelta;
			vector.y = titleItemH - 35f;
			this.m_BuffItem[panelObjectIdx].Item[2].ItemBg.rectTransform.sizeDelta = vector;
			this.m_BuffItem[panelObjectIdx].Item[2].Btn.enabled = false;
			if (recordByKey.isDebuff == 1)
			{
				this.m_BuffItem[panelObjectIdx].Item[2].ItemBg.sprite = this.m_SpriteArray.GetSprite(2);
			}
			else
			{
				this.m_BuffItem[panelObjectIdx].Item[2].ItemBg.sprite = this.m_SpriteArray.GetSprite(3);
			}
		}
		else if (dataIdx < this.m_Data.Count && (int)this.m_Data[dataIdx] < this.DM.MaxBuffTableCount)
		{
			int num = (int)this.DM.m_SortBuffData[(int)this.m_Data[dataIdx]];
			ItemBuff recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(num);
			byte buffKind = recordByIndex.BuffKind;
			if (this.m_TitleType[(int)this.m_Data[dataIdx]] > 0)
			{
				item.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(738f, 113f);
				this.m_BuffItem[panelObjectIdx].Item[0].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(738f, 113f);
				this.m_BuffItem[panelObjectIdx].Item[0].gameObject.SetActive(true);
				this.m_BuffItem[panelObjectIdx].Item[1].gameObject.SetActive(false);
				this.m_BuffItem[panelObjectIdx].Item[2].gameObject.SetActive(false);
				this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnRect.gameObject.SetActive(false);
				if (buffKind == 1)
				{
					this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(6094u);
					this.m_BuffItem[panelObjectIdx].Item[0].Title2.enabled = false;
					this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnText.text = this.DM.mStringTable.GetStringByID(11244u);
					this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnRect.sizeDelta = new Vector2(this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnText.preferredWidth + 32f, this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnRect.sizeDelta.y);
					this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnText.rectTransform.sizeDelta = new Vector2(this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnText.preferredWidth, this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnText.rectTransform.sizeDelta.y);
					this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnImage.rectTransform.sizeDelta = new Vector2(this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnText.preferredWidth, this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnImage.rectTransform.sizeDelta.y);
					this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnRect.gameObject.SetActive(true);
					this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnText.SetAllDirty();
					this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnText.cachedTextGenerator.Invalidate();
					this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnText.cachedTextGeneratorForLayout.Invalidate();
					this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnText.UpdateArabicPos();
					this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnRect.gameObject.GetComponent<UIButton>().m_BtnID1 = 998;
					this.m_BuffItem[panelObjectIdx].Item[0].ItemLogBtnRect.gameObject.GetComponent<UIButton>().m_Handler = this;
				}
				if (buffKind == 2)
				{
					this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(6095u);
					this.m_BuffItem[panelObjectIdx].Item[0].Title2.enabled = false;
				}
				if (buffKind == 3)
				{
					this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(6096u);
					this.m_BuffItem[panelObjectIdx].Item[0].Title2.enabled = true;
				}
				if (buffKind == 4)
				{
					this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(7646u);
					this.m_BuffItem[panelObjectIdx].Item[0].Title2.enabled = false;
				}
				if (buffKind == 5)
				{
					this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(1455u);
					this.m_BuffItem[panelObjectIdx].Item[0].Title2.enabled = false;
				}
				if (buffKind == 6)
				{
					this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(977u);
					this.m_BuffItem[panelObjectIdx].Item[0].Title2.enabled = false;
				}
				if (buffKind == 7)
				{
					this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(9934u);
					this.m_BuffItem[panelObjectIdx].Item[0].Title2.enabled = false;
				}
				if (buffKind == 8)
				{
					this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(11014u);
					this.m_BuffItem[panelObjectIdx].Item[0].Title2.enabled = false;
				}
				if (buffKind == 9)
				{
					this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(11095u);
					this.m_BuffItem[panelObjectIdx].Item[0].Title2.enabled = false;
				}
				this.m_BuffItem[panelObjectIdx].Item[0].Title2.text = this.DM.mStringTable.GetStringByID(6099u);
				if (this.DM.bHaveWarBuff && recordByIndex.BuffKind == 1)
				{
					this.m_BuffItem[panelObjectIdx].Item[0].ItemName.text = this.DM.mStringTable.GetStringByID(9937u);
				}
				else
				{
					this.m_BuffItem[panelObjectIdx].Item[0].ItemName.text = this.DM.mStringTable.GetStringByID((uint)recordByIndex.BuffNameID);
				}
				this.m_BuffItem[panelObjectIdx].Item[0].ItemInFo.text = this.DM.mStringTable.GetStringByID((uint)recordByIndex.BuffInfoID);
				this.m_BuffItem[panelObjectIdx].Item[0].ItemImage.sprite = this.GM.m_ItemIconSpriteAsset.LoadSprite(recordByIndex.IconID);
				this.m_BuffItem[panelObjectIdx].Item[0].ItemImage.material = this.GM.m_ItemIconSpriteAsset.GetMaterial();
				this.m_BuffItem[panelObjectIdx].Item[0].ItemFrame.sprite = this.GM.LoadFrameSprite("if003");
				this.m_BuffItem[panelObjectIdx].Item[0].ItemFrame.material = this.GM.GetFrameMaterial();
				this.m_BuffItem[panelObjectIdx].Item[0].Btn.m_BtnID1 = num;
				this.m_BuffItem[panelObjectIdx].Item[0].TableIdx = num;
				this.m_BuffItem[panelObjectIdx].Item[0].ItemName.color = new Color(1f, 0.93f, 0.62f, 255f);
				if (this.DM.m_RecvItemBuffData[num].bEnable)
				{
					item.transform.GetChild(0).GetChild(4).gameObject.SetActive(true);
					this.m_BuffItem[panelObjectIdx].Item[0].ItemInFo.enabled = false;
					ushort itemID = this.DM.m_RecvItemBuffData[num].ItemID;
					Equip recordByKey2 = this.DM.EquipTable.GetRecordByKey(itemID);
					this.m_BuffItem[panelObjectIdx].Item[0].ItemName.color = new Color(0f, 1f, 0.19f, 255f);
					this.m_BuffItem[panelObjectIdx].Item[0].ItemName.text = this.DM.mStringTable.GetStringByID((uint)recordByKey2.EquipName);
					this.m_BuffItem[panelObjectIdx].Item[0].ItemName.SetAllDirty();
					this.m_BuffItem[panelObjectIdx].Item[0].ItemName.cachedTextGenerator.Invalidate();
				}
				else
				{
					item.transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
					this.m_BuffItem[panelObjectIdx].Item[0].ItemInFo.enabled = true;
				}
				this.m_BuffItem[panelObjectIdx].Item[0].Btn.enabled = true;
				this.m_BuffItem[panelObjectIdx].Item[0].ItemBgIcon.enabled = true;
				if (buffKind == 5 || buffKind == 6 || buffKind == 8 || buffKind == 9)
				{
					this.m_BuffItem[panelObjectIdx].Item[0].ItemBg.sprite = this.m_SpriteArray.GetSprite(1);
					this.m_CDText = this.m_BuffItem[panelObjectIdx].Item[0].CDText;
					Vector2 vector = this.m_BuffItem[panelObjectIdx].Item[0].ItemBg.rectTransform.sizeDelta;
					vector.x = 778f;
					this.m_BuffItem[panelObjectIdx].Item[0].ItemBg.rectTransform.sizeDelta = vector;
					vector = this.m_BuffItem[panelObjectIdx].Item[0].ItemBg.rectTransform.anchoredPosition;
					vector.x = 0f;
					this.m_BuffItem[panelObjectIdx].Item[0].ItemBg.rectTransform.anchoredPosition = vector;
					if (this.m_UIType == eBuffListUIType.BuffList)
					{
						this.m_BuffItem[panelObjectIdx].Item[0].Btn.enabled = false;
						this.m_BuffItem[panelObjectIdx].Item[0].ItemBgIcon.enabled = false;
					}
				}
				else
				{
					this.m_BuffItem[panelObjectIdx].Item[0].ItemBg.sprite = this.m_SpriteArray.GetSprite(0);
					Vector2 vector = this.m_BuffItem[panelObjectIdx].Item[0].ItemBg.rectTransform.sizeDelta;
					vector.x = 776f;
					this.m_BuffItem[panelObjectIdx].Item[0].ItemBg.rectTransform.sizeDelta = vector;
					vector = this.m_BuffItem[panelObjectIdx].Item[0].ItemBg.rectTransform.anchoredPosition;
					vector.x = 2f;
					this.m_BuffItem[panelObjectIdx].Item[0].ItemBg.rectTransform.anchoredPosition = vector;
				}
			}
			else
			{
				item.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(738f, 78f);
				this.m_BuffItem[panelObjectIdx].Item[1].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(738f, 78f);
				this.m_BuffItem[panelObjectIdx].Item[0].gameObject.SetActive(false);
				this.m_BuffItem[panelObjectIdx].Item[1].gameObject.SetActive(true);
				this.m_BuffItem[panelObjectIdx].Item[2].gameObject.SetActive(false);
				this.m_BuffItem[panelObjectIdx].Item[1].ItemName.text = this.DM.mStringTable.GetStringByID((uint)recordByIndex.BuffNameID);
				this.m_BuffItem[panelObjectIdx].Item[1].ItemInFo.text = this.DM.mStringTable.GetStringByID((uint)recordByIndex.BuffInfoID);
				this.m_BuffItem[panelObjectIdx].Item[1].ItemImage.sprite = this.GM.m_ItemIconSpriteAsset.LoadSprite(recordByIndex.IconID);
				this.m_BuffItem[panelObjectIdx].Item[1].ItemImage.material = this.GM.m_ItemIconSpriteAsset.GetMaterial();
				this.m_BuffItem[panelObjectIdx].Item[1].ItemFrame.sprite = this.GM.LoadFrameSprite("if003");
				this.m_BuffItem[panelObjectIdx].Item[1].ItemFrame.material = this.GM.GetFrameMaterial();
				this.m_BuffItem[panelObjectIdx].Item[1].Btn.m_BtnID1 = num;
				this.m_BuffItem[panelObjectIdx].Item[1].TableIdx = num;
				this.m_BuffItem[panelObjectIdx].Item[1].ItemName.color = new Color(1f, 0.93f, 0.62f, 255f);
				if (this.DM.m_RecvItemBuffData[num].bEnable)
				{
					item.transform.GetChild(1).GetChild(4).gameObject.SetActive(true);
					this.m_BuffItem[panelObjectIdx].Item[1].ItemInFo.enabled = false;
					ushort itemID2 = this.DM.m_RecvItemBuffData[num].ItemID;
					Equip recordByKey3 = this.DM.EquipTable.GetRecordByKey(itemID2);
					this.m_BuffItem[panelObjectIdx].Item[1].ItemName.color = new Color(0f, 1f, 0.19f, 255f);
					this.m_BuffItem[panelObjectIdx].Item[1].ItemName.text = this.DM.mStringTable.GetStringByID((uint)recordByKey3.EquipName);
					this.m_BuffItem[panelObjectIdx].Item[1].ItemName.SetAllDirty();
					this.m_BuffItem[panelObjectIdx].Item[1].ItemName.cachedTextGenerator.Invalidate();
				}
				else
				{
					item.transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
					this.m_BuffItem[panelObjectIdx].Item[1].ItemInFo.enabled = true;
				}
				this.m_BuffItem[panelObjectIdx].Item[1].Btn.interactable = true;
				this.m_BuffItem[panelObjectIdx].Item[1].ItemBgIcon.enabled = true;
				if (buffKind == 5 || buffKind == 6)
				{
					this.m_BuffItem[panelObjectIdx].Item[1].ItemBg.sprite = this.m_SpriteArray.GetSprite(1);
					Vector2 vector = this.m_BuffItem[panelObjectIdx].Item[1].ItemBg.rectTransform.sizeDelta;
					vector.x = 778f;
					this.m_BuffItem[panelObjectIdx].Item[1].ItemBg.rectTransform.sizeDelta = vector;
					vector = this.m_BuffItem[panelObjectIdx].Item[1].ItemBg.rectTransform.anchoredPosition;
					vector.x = 0f;
					this.m_BuffItem[panelObjectIdx].Item[1].ItemBg.rectTransform.anchoredPosition = vector;
					if (this.m_UIType == eBuffListUIType.BuffList)
					{
						this.m_BuffItem[panelObjectIdx].Item[1].Btn.interactable = false;
						this.m_BuffItem[panelObjectIdx].Item[1].ItemBgIcon.enabled = false;
					}
				}
				else
				{
					Vector2 vector = this.m_BuffItem[panelObjectIdx].Item[1].ItemBg.rectTransform.sizeDelta;
					vector.x = 776f;
					this.m_BuffItem[panelObjectIdx].Item[1].ItemBg.rectTransform.sizeDelta = vector;
					vector = this.m_BuffItem[panelObjectIdx].Item[1].ItemBg.rectTransform.anchoredPosition;
					vector.x = 2f;
					this.m_BuffItem[panelObjectIdx].Item[1].ItemBg.rectTransform.anchoredPosition = vector;
					this.m_BuffItem[panelObjectIdx].Item[1].ItemBg.sprite = this.m_SpriteArray.GetSprite(0);
				}
			}
		}
	}

	// Token: 0x060019BF RID: 6591 RVA: 0x002BD0A4 File Offset: 0x002BB2A4
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x060019C0 RID: 6592 RVA: 0x002BD0A8 File Offset: 0x002BB2A8
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 999)
		{
			this.m_door.CloseMenu(false);
		}
		else if (sender.m_BtnID1 == 998)
		{
			this.m_door.OpenMenu(EGUIWindow.UI_ShieldLog, 0, 0, false);
		}
		else if (this.DM.ItemBuffTable.GetRecordByIndex(sender.m_BtnID1).BuffKind == 7)
		{
			this.m_door.OpenMenu(EGUIWindow.UI_BuffInformation, 0, 0, false);
		}
		else
		{
			this.m_door.OpenMenu(EGUIWindow.UI_BagFilter, 5, sender.m_BtnID1, false);
		}
	}

	// Token: 0x060019C1 RID: 6593 RVA: 0x002BD150 File Offset: 0x002BB350
	public void SetTitleType()
	{
		byte b = 7;
		byte b2 = 6;
		byte b3 = 8;
		byte b4 = 9;
		byte b5 = 5;
		byte[] array = new byte[]
		{
			8,
			9,
			7,
			6,
			5,
			1,
			3,
			4,
			2
		};
		byte[] array2 = new byte[]
		{
			3,
			4
		};
		byte[] array3 = new byte[]
		{
			1,
			3,
			4
		};
		ushort[] array4 = new ushort[]
		{
			2,
			3,
			6
		};
		ushort[] array5 = new ushort[]
		{
			1,
			2,
			3,
			4,
			8
		};
		this.DM.SortCurItemDataForBag();
		this.DM.SortStoreData();
		this.m_Data.Clear();
		bool flag = GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 9;
		int num = 0;
		if (this.m_UIType == eBuffListUIType.BuffList)
		{
			if (this.DM.RoleAttr.WorldTitle_Country > 0)
			{
				this.m_Data.Add(9999);
				num++;
			}
			if (this.DM.m_KingdomBattleIdx >= 0 && this.DM.m_KingdomBattleIdx < this.DM.m_RecvItemBuffData.Length && this.DM.m_RecvItemBuffData[this.DM.m_KingdomBattleIdx].bEnable)
			{
				this.m_Data.Add((ushort)this.DM.m_KingdomBattleIdx);
				num++;
			}
			if (this.DM.m_RecvWorldBattleIdx >= 0 && this.DM.m_RecvWorldBattleIdx < this.DM.m_RecvItemBuffData.Length && this.DM.m_RecvItemBuffData[this.DM.m_RecvWorldBattleIdx].bEnable)
			{
				this.m_Data.Add((ushort)this.DM.m_RecvWorldBattleIdx);
				num++;
			}
			if (this.DM.m_NobilityBattleIdx >= 0 && this.DM.m_NobilityBattleIdx < this.DM.m_RecvItemBuffData.Length && this.DM.m_RecvItemBuffData[this.DM.m_NobilityBattleIdx].bEnable)
			{
				this.m_Data.Add((ushort)this.DM.m_NobilityBattleIdx);
				num++;
			}
			for (int i = 0; i < this.DM.MaxBuffTableCount; i++)
			{
				ItemBuff recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(i);
				if (recordByIndex.BuffKind == b5)
				{
					if (this.DM.m_RecvItemBuffData[i].bEnable)
					{
						this.m_Data.Insert(num++, (ushort)i);
					}
				}
				else if (recordByIndex.BuffKind == b && flag)
				{
					this.m_Data.Insert(num++, (ushort)i);
				}
				else if (this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind) && b3 != recordByIndex.BuffKind && b2 != recordByIndex.BuffKind && b4 != recordByIndex.BuffKind && b != recordByIndex.BuffKind)
				{
					this.m_Data.Add((ushort)i);
				}
			}
			for (int j = 0; j < array.Length; j++)
			{
				for (int k = 0; k < this.DM.MaxBuffTableCount; k++)
				{
					ItemBuff recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(k);
					if (((recordByIndex.BuffKind == b && flag) || recordByIndex.BuffKind == b3 || recordByIndex.BuffKind == b4 || this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind)) && array[j] == recordByIndex.BuffKind)
					{
						this.m_TitleType[k] = array[j];
						break;
					}
				}
			}
		}
		else if (this.m_UIType == eBuffListUIType.AttackBuffList)
		{
			for (int l = 0; l < this.DM.MaxBuffTableCount; l++)
			{
				bool flag2 = false;
				ItemBuff recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(l);
				for (int m = 0; m < array4.Length; m++)
				{
					if (array4[m] == recordByIndex.BuffID)
					{
						flag2 = true;
						break;
					}
				}
				if (flag2 && this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind))
				{
					this.m_Data.Add((ushort)l);
				}
			}
			for (int n = 0; n < array2.Length; n++)
			{
				for (int num2 = 0; num2 < this.m_Data.Count; num2++)
				{
					int num3 = (int)this.m_Data[num2];
					ItemBuff recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(num3);
					if (recordByIndex.BuffKind != 0 && this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind) && array2[n] == recordByIndex.BuffKind)
					{
						this.m_TitleType[num3] = array2[n];
						break;
					}
				}
			}
		}
		else if (this.m_UIType == eBuffListUIType.DefendBuffList)
		{
			for (int num4 = 0; num4 < this.DM.MaxBuffTableCount; num4++)
			{
				bool flag3 = false;
				ItemBuff recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(num4);
				for (int num5 = 0; num5 < array5.Length; num5++)
				{
					if (array5[num5] == recordByIndex.BuffID)
					{
						flag3 = true;
						break;
					}
				}
				if (flag3 && this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind))
				{
					this.m_Data.Add((ushort)num4);
				}
			}
			for (int num6 = 0; num6 < array3.Length; num6++)
			{
				for (int num7 = 0; num7 < this.m_Data.Count; num7++)
				{
					int num8 = (int)this.m_Data[num7];
					ItemBuff recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(num8);
					if (this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind) && recordByIndex.BuffKind != 0 && array3[num6] == recordByIndex.BuffKind)
					{
						this.m_TitleType[num8] = array3[num6];
						break;
					}
				}
			}
		}
		else if (this.m_UIType == eBuffListUIType.KingdomBuff)
		{
			for (int num9 = 0; num9 < this.DM.MaxBuffTableCount; num9++)
			{
				ItemBuff recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(num9);
				if (this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind))
				{
					this.m_Data.Add((ushort)num9);
				}
			}
			for (int num10 = 0; num10 < array.Length; num10++)
			{
				for (int num11 = 0; num11 < this.DM.MaxBuffTableCount; num11++)
				{
					ItemBuff recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(num11);
					if (this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind) && array[num10] == b5)
					{
						this.m_TitleType[num11] = array[num10];
						break;
					}
				}
			}
		}
	}

	// Token: 0x060019C2 RID: 6594 RVA: 0x002BD8DC File Offset: 0x002BBADC
	public bool CheckBuffByID(ushort id, byte buffKind)
	{
		ItemBuff recordByKey = this.DM.ItemBuffTable.GetRecordByKey(id);
		Equip recordByKey2 = this.DM.EquipTable.GetRecordByKey(recordByKey.BuffItemID);
		byte equipKind = recordByKey2.EquipKind;
		ushort propertieskey = recordByKey2.PropertiesInfo[0].Propertieskey;
		if (equipKind <= 0 || propertieskey <= 0)
		{
			return false;
		}
		if (this.m_UIType == eBuffListUIType.KingdomBuff)
		{
			return buffKind == 5;
		}
		int recvBuffDataIdxByID = this.DM.GetRecvBuffDataIdxByID(id);
		if (this.DM.m_RecvItemBuffData[recvBuffDataIdxByID].bEnable)
		{
			return true;
		}
		if (recordByKey2.EquipKind == 12 && recordByKey2.PropertiesInfo[0].Propertieskey == 33)
		{
			return DataManager.StageDataController.StageRecord[2] >= 8;
		}
		ushort num = this.DM.sortItemDataCount[(int)(equipKind - 1)];
		if (num != 0)
		{
			ushort num2 = this.DM.sortItemDataStart[(int)(equipKind - 1)];
			for (int i = (int)num2; i < (int)(num2 + num); i++)
			{
				if (this.DM.EquipTable.GetRecordByKey(this.DM.sortItemData[i]).PropertiesInfo[0].Propertieskey == propertieskey)
				{
					return true;
				}
			}
		}
		num = this.DM.SortSotreDataCount[(int)equipKind];
		if (num != 0)
		{
			ushort num2 = this.DM.SortSotreDataStart[(int)equipKind];
			for (int j = (int)num2; j < (int)(num2 + num); j++)
			{
				StoreTbl recordByKey3 = DataManager.Instance.StoreData.GetRecordByKey(this.DM.SortSotreData[j]);
				if (recordByKey3.Price != 0u && recordByKey3.Filter < 2 && this.DM.EquipTable.GetRecordByKey(recordByKey3.ItemID).PropertiesInfo[0].Propertieskey == propertieskey)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060019C3 RID: 6595 RVA: 0x002BDAEC File Offset: 0x002BBCEC
	public bool CheckBuffByKind(byte kind)
	{
		if (this.m_UIType == eBuffListUIType.KingdomBuff)
		{
			if (kind != 5)
			{
				return false;
			}
		}
		else if (kind == 5)
		{
			return false;
		}
		return true;
	}

	// Token: 0x060019C4 RID: 6596 RVA: 0x002BDB20 File Offset: 0x002BBD20
	public void SetTime(int dd, int hh, int mm, int ss, CString _tempString, UIText text)
	{
		if (text == null)
		{
			return;
		}
		if (dd >= 0 && hh >= 0 && mm >= 0 && ss >= 0)
		{
			_tempString.ClearString();
			if (dd > 0)
			{
				_tempString.IntToFormat((long)dd, 1, false);
				_tempString.AppendFormat("{0}d ");
			}
			if (dd > 0 || hh > 0)
			{
				_tempString.IntToFormat((long)hh, 2, false);
				_tempString.AppendFormat("{0}:");
			}
			_tempString.IntToFormat((long)mm, 2, false);
			_tempString.IntToFormat((long)ss, 2, false);
			_tempString.AppendFormat("{0}:{1}");
		}
		text.text = _tempString.ToString();
		text.SetAllDirty();
		text.cachedTextGenerator.Invalidate();
		text.cachedTextGeneratorForLayout.Invalidate();
	}

	// Token: 0x060019C5 RID: 6597 RVA: 0x002BDBF8 File Offset: 0x002BBDF8
	public void UpdateTime()
	{
		for (int i = 0; i < 7; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				int tableIdx = this.m_BuffItem[i].Item[j].TableIdx;
				if (tableIdx < this.DM.MaxBuffTableCount && tableIdx >= 0)
				{
					bool bEnable = this.DM.m_RecvItemBuffData[tableIdx].bEnable;
					if (bEnable && this.m_BuffItem[i].Item[j].TimeText != null)
					{
						long num = this.DM.m_RecvItemBuffData[tableIdx].TargetTime - this.DM.ServerTime;
						if (num >= 0L)
						{
							int ss = (int)num % 60;
							int mm = (int)(num / 60L) % 60;
							int hh = (int)(num / 3600L) % 24;
							int dd = (int)num / 86400;
							this.SetTime(dd, hh, mm, ss, this.m_BuffItem[i].Item[j].TimeStr, this.m_BuffItem[i].Item[j].TimeText);
						}
					}
				}
			}
		}
	}

	// Token: 0x060019C6 RID: 6598 RVA: 0x002BDD4C File Offset: 0x002BBF4C
	public void UpdateSlider()
	{
		for (int i = 0; i < 7; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				int tableIdx = this.m_BuffItem[i].Item[j].TableIdx;
				if (tableIdx < this.DM.MaxBuffTableCount && tableIdx >= 0)
				{
					bool bEnable = this.DM.m_RecvItemBuffData[tableIdx].bEnable;
					if (bEnable && this.m_BuffItem[i].Item[j].TimeSlider != null)
					{
						double num = NetworkManager.ServerTime - (double)this.DM.m_RecvItemBuffData[tableIdx].BeginTime;
						long num2 = this.DM.m_RecvItemBuffData[tableIdx].TargetTime - this.DM.m_RecvItemBuffData[tableIdx].BeginTime;
						if ((float)num2 > 0f)
						{
							double num3 = num / (double)((float)num2);
							if (num3 >= 1.0)
							{
								num3 = 1.0;
							}
							this.m_BuffItem[i].Item[j].TimeSlider.rectTransform.sizeDelta = new Vector2((float)(341.20001220703125 * num3), this.m_BuffItem[i].Item[j].TimeSlider.rectTransform.sizeDelta.y);
						}
					}
				}
			}
		}
	}

	// Token: 0x060019C7 RID: 6599 RVA: 0x002BDF04 File Offset: 0x002BC104
	public void UpdateSliderAlpha()
	{
		for (int i = 0; i < 7; i++)
		{
			for (int j = 0; j < 2; j++)
			{
				int tableIdx = this.m_BuffItem[i].Item[j].TableIdx;
				if (tableIdx < this.DM.MaxBuffTableCount && tableIdx >= 0)
				{
					bool bEnable = this.DM.m_RecvItemBuffData[tableIdx].bEnable;
					if (bEnable && this.m_BuffItem[i].Item[j].TimeFlash != null)
					{
						if (this.ColorA > 1f)
						{
							this.m_BuffItem[i].Item[j].TimeFlash.color = new Color(1f, 1f, 1f, 2f - this.ColorA);
						}
						else
						{
							this.m_BuffItem[i].Item[j].TimeFlash.color = new Color(1f, 1f, 1f, this.ColorA);
						}
					}
				}
			}
		}
	}

	// Token: 0x060019C8 RID: 6600 RVA: 0x002BE044 File Offset: 0x002BC244
	public float ATween(float t, float b, float c, float d)
	{
		t /= d;
		return b + c * t;
	}

	// Token: 0x060019C9 RID: 6601 RVA: 0x002BE054 File Offset: 0x002BC254
	public void UpdateCDTime(long CDTime)
	{
		if (this.m_CDText == null)
		{
			return;
		}
		if (this.m_UIType == eBuffListUIType.KingdomBuff && CDTime > this.DM.ServerTime)
		{
			long num = CDTime - this.DM.ServerTime;
			if (num >= 0L)
			{
				int ss = (int)num % 60;
				int mm = (int)(num / 60L) % 60;
				int hh = (int)(num / 3600L) % 24;
				int dd = (int)num / 86400;
				this.SetTime(dd, hh, mm, ss, this.m_CDCStr, this.m_CDText);
				Vector2 sizeDelta = this.m_CDText.rectTransform.sizeDelta;
				sizeDelta.x = this.m_CDText.preferredWidth;
				this.m_CDText.rectTransform.sizeDelta = sizeDelta;
			}
			if (!this.m_CDText.gameObject.activeSelf)
			{
				this.m_CDText.gameObject.SetActive(true);
			}
		}
		else if (this.m_CDText.gameObject.activeSelf)
		{
			this.m_CDText.gameObject.SetActive(false);
		}
	}

	// Token: 0x060019CA RID: 6602 RVA: 0x002BE16C File Offset: 0x002BC36C
	private float GetTitleItemH()
	{
		if (this.HaveEffect3())
		{
			return 176f;
		}
		return 140f;
	}

	// Token: 0x060019CB RID: 6603 RVA: 0x002BE184 File Offset: 0x002BC384
	private bool HaveEffect3()
	{
		return this.DM.TitleDataN.GetRecordByKey(this.DM.RoleAttr.WorldTitle_Country).Effects[2].EffectID != 0;
	}

	// Token: 0x04004C76 RID: 19574
	private const int MaxScrollCount = 7;

	// Token: 0x04004C77 RID: 19575
	private const int MaxTitleType = 3;

	// Token: 0x04004C78 RID: 19576
	private const int WorldTitleIdx = 9999;

	// Token: 0x04004C79 RID: 19577
	private const float TitleItemH = 140f;

	// Token: 0x04004C7A RID: 19578
	private const float TitleItemH2 = 176f;

	// Token: 0x04004C7B RID: 19579
	private const int TextMax = 2;

	// Token: 0x04004C7C RID: 19580
	private DataManager DM;

	// Token: 0x04004C7D RID: 19581
	private GUIManager GM;

	// Token: 0x04004C7E RID: 19582
	private Font TTF;

	// Token: 0x04004C7F RID: 19583
	private Door m_door;

	// Token: 0x04004C80 RID: 19584
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04004C81 RID: 19585
	private RectTransform m_ScrollContentRT;

	// Token: 0x04004C82 RID: 19586
	private BuffItemObj[] m_BuffItem;

	// Token: 0x04004C83 RID: 19587
	private UISpritesArray m_SpriteArray;

	// Token: 0x04004C84 RID: 19588
	private UIText m_CDText;

	// Token: 0x04004C85 RID: 19589
	private CString m_CDCStr;

	// Token: 0x04004C86 RID: 19590
	private byte[] m_TitleType;

	// Token: 0x04004C87 RID: 19591
	private float ColorA;

	// Token: 0x04004C88 RID: 19592
	private float ColorTime;

	// Token: 0x04004C89 RID: 19593
	private float FlashTime = 1.6f;

	// Token: 0x04004C8A RID: 19594
	private Color GoogEffColor = new Color(0.2078f, 0.9686f, 0.4235f);

	// Token: 0x04004C8B RID: 19595
	private Color BadEffColor = new Color(1f, 0.3294f, 0.4157f);

	// Token: 0x04004C8C RID: 19596
	public List<ushort> m_Data;

	// Token: 0x04004C8D RID: 19597
	private eBuffListUIType m_UIType;

	// Token: 0x04004C8E RID: 19598
	private int mTextCount;

	// Token: 0x04004C8F RID: 19599
	private UIText[] m_tmptext = new UIText[2];
}
