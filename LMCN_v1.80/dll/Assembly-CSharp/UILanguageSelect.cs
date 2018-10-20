using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020002E2 RID: 738
public class UILanguageSelect : GUIWindow, UILoadImageHander, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06000F10 RID: 3856 RVA: 0x001A5C34 File Offset: 0x001A3E34
	public override void OnOpen(int arg1, int arg2)
	{
		Font ttffont = GUIManager.Instance.GetTTFFont();
		DataManager instance = DataManager.Instance;
		this.ProtocolType = (byte)arg1;
		this.CurSelIndex = instance.CurSelectLanguage;
		this.TitleStr = StringManager.Instance.SpawnString(30);
		switch (DataManager.Instance.UserLanguage)
		{
		case GameLanguage.GL_Eng:
			this.tmpLanguageIdx = 1;
			break;
		case GameLanguage.GL_Cht:
			this.tmpLanguageIdx = 0;
			break;
		case GameLanguage.GL_Fre:
			this.tmpLanguageIdx = 2;
			break;
		case GameLanguage.GL_Gem:
			this.tmpLanguageIdx = 3;
			break;
		case GameLanguage.GL_Spa:
			this.tmpLanguageIdx = 5;
			break;
		case GameLanguage.GL_Rus:
			this.tmpLanguageIdx = 4;
			break;
		case GameLanguage.GL_Chs:
			this.tmpLanguageIdx = 6;
			break;
		case GameLanguage.GL_Idn:
			this.tmpLanguageIdx = 7;
			break;
		case GameLanguage.GL_Vet:
			this.tmpLanguageIdx = 8;
			break;
		case GameLanguage.GL_Tur:
			this.tmpLanguageIdx = 9;
			break;
		case GameLanguage.GL_Tha:
			this.tmpLanguageIdx = 10;
			break;
		case GameLanguage.GL_Ita:
			this.tmpLanguageIdx = 11;
			break;
		case GameLanguage.GL_Pot:
			this.tmpLanguageIdx = 12;
			break;
		case GameLanguage.GL_Kor:
			this.tmpLanguageIdx = 13;
			break;
		case GameLanguage.GL_Jpn:
			this.tmpLanguageIdx = 14;
			break;
		case GameLanguage.GL_Ukr:
			this.tmpLanguageIdx = 15;
			break;
		case GameLanguage.GL_Mys:
			this.tmpLanguageIdx = 16;
			break;
		case GameLanguage.GL_Arb:
			this.tmpLanguageIdx = 17;
			break;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		this.RefreshText[0] = base.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.RefreshText[0].font = ttffont;
		this.RefreshText[2] = base.transform.GetChild(2).GetChild(0).GetComponent<UIText>();
		this.RefreshText[2].font = ttffont;
		if (this.ProtocolType < 2)
		{
			this.RefreshText[0].text = instance.mStringTable.GetStringByID(4649u);
		}
		else if (this.ProtocolType == 3)
		{
			this.RefreshText[0].text = instance.mStringTable.GetStringByID(9050u);
		}
		else
		{
			this.RefreshText[0].text = instance.mStringTable.GetStringByID(9016u);
		}
		Image component = base.transform.GetChild(6).GetComponent<Image>();
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			component.enabled = false;
		}
		else
		{
			component.sprite = door.LoadSprite("UI_main_close_base");
			component.material = door.LoadMaterial();
		}
		component = base.transform.GetChild(6).GetChild(0).GetComponent<Image>();
		component.sprite = door.LoadSprite("UI_main_close");
		component.material = door.LoadMaterial();
		UIButton component2 = base.transform.GetChild(6).GetChild(0).GetComponent<UIButton>();
		component2.m_BtnID1 = 0;
		component2.m_Handler = this;
		component2 = base.transform.GetChild(3).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 1;
		this.RefreshText[1] = base.transform.GetChild(3).GetChild(0).GetComponent<UIText>();
		this.RefreshText[1].font = ttffont;
		this.ScrollRect = base.transform.GetChild(4).GetComponent<RectTransform>();
		if (this.ProtocolType < 2)
		{
			this.RefreshText[1].text = instance.mStringTable.GetStringByID(4650u);
		}
		else if (this.ProtocolType == 3)
		{
			this.ScrollRect.anchoredPosition = new Vector2(4.5f, -39f);
			this.ScrollRect.sizeDelta = new Vector2(805f, 364f);
			this.RefreshText[1].text = instance.mStringTable.GetStringByID(3u);
			base.transform.GetChild(2).gameObject.SetActive(true);
			this.RefreshText[2].text = instance.mStringTable.GetStringByID(9051u);
			this.tmpLanguageTranslation = instance.MySysSetting.mLanguageTranslation;
			this.bLangueage = instance.MySysSetting.bLanguageOther;
			if (this.tmpLanguageTranslation == 18446744073709551615UL && this.bLangueage)
			{
				this.bAllSet = true;
			}
			else
			{
				this.bAllSet = false;
			}
		}
		else
		{
			this.RefreshText[1].text = instance.mStringTable.GetStringByID(3u);
			for (int i = 0; i < 6; i++)
			{
				this.mLanguage[i] = instance.mStringTable.GetStringByID((uint)(9017 + i));
			}
			this.mLanguage[6] = instance.mStringTable.GetStringByID(9045u);
			this.mLanguage[7] = instance.mStringTable.GetStringByID(9056u);
			this.mLanguage[8] = instance.mStringTable.GetStringByID(9057u);
			this.mLanguage[9] = instance.mStringTable.GetStringByID(9060u);
			this.mLanguage[10] = instance.mStringTable.GetStringByID(9055u);
			this.mLanguage[11] = instance.mStringTable.GetStringByID(9058u);
			this.mLanguage[12] = instance.mStringTable.GetStringByID(9059u);
			this.mLanguage[13] = instance.mStringTable.GetStringByID(9061u);
			this.mLanguage[14] = instance.mStringTable.GetStringByID(9100u);
			this.mLanguage[15] = instance.mStringTable.GetStringByID(9519u);
			this.mLanguage[16] = instance.mStringTable.GetStringByID(9520u);
			this.mLanguage[17] = instance.mStringTable.GetStringByID(9504u);
			if (!GUIManager.Instance.IsArabic)
			{
				string str = this.mLanguage[17];
				if (ArabicTransfer.Instance.IsArabicStr(str))
				{
					str = ArabicTransfer.Instance.Transfer(str, this.TitleStr);
					this.mLanguage[17] = this.TitleStr.ToString();
				}
			}
		}
		Transform child = base.transform.GetChild(5);
		child.GetChild(0).GetComponent<UIText>().font = ttffont;
		if (GUIManager.Instance.IsArabic)
		{
			child.GetChild(1).GetChild(0).GetComponent<RectTransform>().localScale = new Vector3(-1f, 1f, 1f);
		}
		this.Scroll = base.transform.GetChild(4).GetComponent<ScrollPanel>();
		this.SpriteArray = base.transform.GetChild(4).GetComponent<UISpritesArray>();
		this.ScrollItem = new UILanguageSelect.ItemEdit[(int)this.ItemCount];
		for (byte b = 0; b < this.ItemCount; b += 1)
		{
			this.ItemsHeight.Add(66f);
		}
		this.Scroll.IntiScrollPanel(435f, 0f, 0f, this.ItemsHeight, (int)this.ItemCount, this);
	}

	// Token: 0x06000F11 RID: 3857 RVA: 0x001A6380 File Offset: 0x001A4580
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 1 && this.ProtocolType == 1 && this.CurSelIndex == DataManager.Instance.CurSelectLanguage)
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(707u), 255, true);
			return;
		}
		if (sender.m_BtnID1 == 1)
		{
			if (this.ProtocolType < 2)
			{
				DataManager.Instance.CurSelectLanguage = this.CurSelIndex;
			}
			else if (this.ProtocolType == 3)
			{
				DataManager.Instance.MySysSetting.mLanguageTranslation = this.tmpLanguageTranslation;
				DataManager.Instance.MySysSetting.bLanguageOther = this.bLangueage;
				PlayerPrefs.SetString("Other_LanguageTranslation", DataManager.Instance.MySysSetting.mLanguageTranslation.ToString());
				PlayerPrefs.SetString("Other_LanguageOther", DataManager.Instance.MySysSetting.bLanguageOther.ToString());
				DataManager.Instance.ClearAllHeight();
			}
			else if (this.tmpLanguageIdx >= 0)
			{
				byte b = 0;
				switch (this.tmpLanguageIdx)
				{
				case 0:
					b = 2;
					break;
				case 1:
					b = 1;
					break;
				case 2:
					b = 3;
					break;
				case 3:
					b = 4;
					break;
				case 4:
					b = 6;
					break;
				case 5:
					b = 5;
					break;
				case 6:
					b = 7;
					break;
				case 7:
					b = 8;
					break;
				case 8:
					b = 9;
					break;
				case 9:
					b = 10;
					break;
				case 10:
					b = 11;
					break;
				case 11:
					b = 12;
					break;
				case 12:
					b = 13;
					break;
				case 13:
					b = 14;
					break;
				case 14:
					b = 15;
					break;
				case 15:
					b = 16;
					break;
				case 16:
					b = 17;
					break;
				case 17:
					b = 18;
					break;
				}
				if (b == (byte)DataManager.Instance.UserLanguage)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9024u), 255, true);
					return;
				}
				DataManager.Instance.MySysSetting.mUserLanguage = b;
				PlayerPrefs.SetString("Other_Language", DataManager.Instance.MySysSetting.mUserLanguage.ToString());
				IGGSDKPlugin.NotificationUninitialize();
				UpdateController.OnExit(9023u, true);
			}
		}
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			door.CloseMenu(false);
		}
	}

	// Token: 0x06000F12 RID: 3858 RVA: 0x001A6614 File Offset: 0x001A4814
	public override void OnClose()
	{
		StringManager.Instance.DeSpawnString(this.TitleStr);
		DataManager instance = DataManager.Instance;
		if (this.ProtocolType == 1 && instance.RoleAlliance.Language != instance.CurSelectLanguage && GUIManager.Instance.ShowUILock(EUILock.Alliance_Manage))
		{
			MessagePacket messagePacket = new MessagePacket(1024);
			messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_LANGUAGE;
			messagePacket.AddSeqId();
			messagePacket.Add(instance.CurSelectLanguage);
			messagePacket.Send(false);
		}
	}

	// Token: 0x06000F13 RID: 3859 RVA: 0x001A669C File Offset: 0x001A489C
	public bool CheckShowbyIdx(int Idx)
	{
		bool result = false;
		int num = 0;
		switch (Idx)
		{
		case 0:
			num = 256;
			result = this.bAllSet;
			break;
		case 1:
			num = 5;
			break;
		case 2:
			num = 10;
			break;
		case 3:
			num = 13;
			break;
		case 4:
			num = 14;
			break;
		case 5:
			num = 31;
			break;
		case 6:
			num = 35;
			break;
		case 7:
			num = 41;
			break;
		case 8:
			num = 19;
			break;
		case 9:
			num = 40;
			break;
		case 10:
			num = 38;
			break;
		case 11:
			num = 37;
			break;
		case 12:
			num = 20;
			break;
		case 13:
			num = 29;
			break;
		case 14:
			num = 22;
			break;
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
			num = Idx - 15;
			break;
		case 20:
		case 21:
		case 22:
		case 23:
			num = Idx - 14;
			break;
		case 24:
		case 25:
			num = Idx - 13;
			break;
		case 26:
		case 27:
		case 28:
		case 29:
			num = Idx - 11;
			break;
		case 30:
			num = 21;
			break;
		case 31:
		case 32:
		case 33:
		case 34:
		case 35:
		case 36:
			num = Idx - 8;
			break;
		case 37:
			num = 30;
			break;
		case 38:
		case 39:
		case 40:
			num = Idx - 6;
			break;
		case 41:
			num = 36;
			break;
		case 42:
			num = 39;
			break;
		case 43:
			num = 255;
			result = this.bLangueage;
			break;
		}
		if (num < 255)
		{
			result = ((this.tmpLanguageTranslation >> num & 1UL) == 1UL);
		}
		return result;
	}

	// Token: 0x06000F14 RID: 3860 RVA: 0x001A6890 File Offset: 0x001A4A90
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.ScrollItem[panelObjectIdx].Title == null)
		{
			Transform transform = item.transform;
			transform.GetComponent<ScrollPanelItem>().m_BtnID2 = panelObjectIdx;
			this.ScrollItem[panelObjectIdx].Title = transform.GetChild(0).GetComponent<UIText>();
			this.ScrollItem[panelObjectIdx].BgImg = transform.GetComponent<Image>();
			this.ScrollItem[panelObjectIdx].Check = transform.GetChild(1).GetChild(0).GetComponent<Image>();
			if (dataIdx == (int)(this.ItemCount - 1))
			{
				this.UpdateItemData();
			}
		}
		if (this.ProtocolType < 2)
		{
			this.ScrollItem[panelObjectIdx].Title.text = DataManager.Instance.GetLanguageStr(this.LangueIDTable[dataIdx]);
		}
		else if (this.ProtocolType == 3)
		{
			this.ScrollItem[panelObjectIdx].Title.text = DataManager.Instance.GetLanguageStr(this.TranslationLangueIDTable[dataIdx]);
		}
		else if (dataIdx < this.mLanguageCount)
		{
			this.ScrollItem[panelObjectIdx].Title.text = this.mLanguage[dataIdx];
		}
		this.ScrollItem[panelObjectIdx].Index = dataIdx;
		if (this.ProtocolType < 2)
		{
			if (this.CurSelIndex == this.LangueIDTable[dataIdx])
			{
				this.ScrollItem[panelObjectIdx].Check.enabled = true;
				this.ScrollItem[panelObjectIdx].BgImg.sprite = this.SpriteArray.GetSprite(1);
			}
			else
			{
				this.ScrollItem[panelObjectIdx].Check.enabled = false;
				this.ScrollItem[panelObjectIdx].BgImg.sprite = this.SpriteArray.GetSprite(0);
			}
		}
		else if (this.ProtocolType == 3)
		{
			if (this.CheckShowbyIdx(dataIdx))
			{
				this.ScrollItem[panelObjectIdx].Check.enabled = true;
				this.ScrollItem[panelObjectIdx].BgImg.sprite = this.SpriteArray.GetSprite(1);
			}
			else
			{
				this.ScrollItem[panelObjectIdx].Check.enabled = false;
				this.ScrollItem[panelObjectIdx].BgImg.sprite = this.SpriteArray.GetSprite(0);
			}
		}
		else if (this.tmpLanguageIdx == dataIdx)
		{
			this.ScrollItem[panelObjectIdx].Check.enabled = true;
			this.ScrollItem[panelObjectIdx].BgImg.sprite = this.SpriteArray.GetSprite(1);
		}
		else
		{
			this.ScrollItem[panelObjectIdx].Check.enabled = false;
			this.ScrollItem[panelObjectIdx].BgImg.sprite = this.SpriteArray.GetSprite(0);
		}
	}

	// Token: 0x06000F15 RID: 3861 RVA: 0x001A6B98 File Offset: 0x001A4D98
	public override void UpdateNetwork(byte[] meg)
	{
		if (meg[0] == 35)
		{
			for (int i = 0; i < this.ScrollItem.Length; i++)
			{
				if (!(this.ScrollItem[i].Title == null))
				{
					this.ScrollItem[i].Title.enabled = false;
					this.ScrollItem[i].Title.enabled = true;
				}
			}
			for (int j = 0; j < this.RefreshText.Length; j++)
			{
				this.RefreshText[j].enabled = false;
				this.RefreshText[j].enabled = true;
			}
		}
	}

	// Token: 0x06000F16 RID: 3862 RVA: 0x001A6C4C File Offset: 0x001A4E4C
	private void UpdateItemData()
	{
		if (this.ProtocolType < 2)
		{
			for (byte b = 0; b < 42 - this.ItemCount; b += 1)
			{
				this.ItemsHeight.Add(66f);
			}
			this.Scroll.AddNewDataHeight(this.ItemsHeight, true, true);
			this.Scroll.gameObject.SetActive(true);
			byte b2 = 0;
			byte b3 = 0;
			while ((int)b3 < this.LangueIDTable.Length)
			{
				if (this.CurSelIndex == this.LangueIDTable[(int)b3])
				{
					b2 = b3;
					break;
				}
				b3 += 1;
			}
			if (b2 >= 6)
			{
				this.Scroll.GoTo((int)(b2 - 1));
			}
		}
		else if (this.ProtocolType == 3)
		{
			for (byte b4 = 0; b4 < 44 - this.ItemCount; b4 += 1)
			{
				this.ItemsHeight.Add(66f);
			}
			this.Scroll.AddNewDataHeight(this.ItemsHeight, true, true);
			this.Scroll.gameObject.SetActive(true);
		}
		else
		{
			if (byte.TryParse(PlayerPrefs.GetString("Other_Language"), out DataManager.Instance.MySysSetting.mUserLanguage))
			{
				switch (DataManager.Instance.MySysSetting.mUserLanguage)
				{
				case 1:
					this.tmpLanguageIdx = 1;
					break;
				case 2:
					this.tmpLanguageIdx = 0;
					break;
				case 3:
					this.tmpLanguageIdx = 2;
					break;
				case 4:
					this.tmpLanguageIdx = 3;
					break;
				case 5:
					this.tmpLanguageIdx = 5;
					break;
				case 6:
					this.tmpLanguageIdx = 4;
					break;
				case 7:
					this.tmpLanguageIdx = 6;
					break;
				case 8:
					this.tmpLanguageIdx = 7;
					break;
				case 9:
					this.tmpLanguageIdx = 8;
					break;
				case 10:
					this.tmpLanguageIdx = 9;
					break;
				case 11:
					this.tmpLanguageIdx = 10;
					break;
				case 12:
					this.tmpLanguageIdx = 11;
					break;
				case 13:
					this.tmpLanguageIdx = 12;
					break;
				case 14:
					this.tmpLanguageIdx = 13;
					break;
				case 15:
					this.tmpLanguageIdx = 14;
					break;
				case 16:
					this.tmpLanguageIdx = 15;
					break;
				case 17:
					this.tmpLanguageIdx = 16;
					break;
				case 18:
					this.tmpLanguageIdx = 17;
					break;
				}
			}
			this.ItemsHeight.Clear();
			this.mLanguageCount = 18;
			byte b5 = 0;
			while ((int)b5 < this.mLanguageCount)
			{
				this.ItemsHeight.Add(66f);
				b5 += 1;
			}
			this.Scroll.AddNewDataHeight(this.ItemsHeight, true, true);
			this.Scroll.gameObject.SetActive(true);
		}
	}

	// Token: 0x06000F17 RID: 3863 RVA: 0x001A6F34 File Offset: 0x001A5134
	public ulong GetValuebyIdx(int Idx)
	{
		int num = 0;
		ulong result = 0UL;
		switch (Idx)
		{
		case 1:
			num = 5;
			break;
		case 2:
			num = 10;
			break;
		case 3:
			num = 13;
			break;
		case 4:
			num = 14;
			break;
		case 5:
			num = 31;
			break;
		case 6:
			num = 35;
			break;
		case 7:
			num = 41;
			break;
		case 8:
			num = 19;
			break;
		case 9:
			num = 40;
			break;
		case 10:
			num = 38;
			break;
		case 11:
			num = 37;
			break;
		case 12:
			num = 20;
			break;
		case 13:
			num = 29;
			break;
		case 14:
			num = 22;
			break;
		case 15:
		case 16:
		case 17:
		case 18:
		case 19:
			num = Idx - 15;
			break;
		case 20:
		case 21:
		case 22:
		case 23:
			num = Idx - 14;
			break;
		case 24:
		case 25:
			num = Idx - 13;
			break;
		case 26:
		case 27:
		case 28:
		case 29:
			num = Idx - 11;
			break;
		case 30:
			num = 21;
			break;
		case 31:
		case 32:
		case 33:
		case 34:
		case 35:
		case 36:
			num = Idx - 8;
			break;
		case 37:
			num = 30;
			break;
		case 38:
		case 39:
		case 40:
			num = Idx - 6;
			break;
		case 41:
			num = 36;
			break;
		case 42:
			num = 39;
			break;
		case 43:
			num = 255;
			result = 255UL;
			break;
		}
		if (num < 255)
		{
			result = 1UL << num;
		}
		return result;
	}

	// Token: 0x06000F18 RID: 3864 RVA: 0x001A70F0 File Offset: 0x001A52F0
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
		if (this.ProtocolType == 3)
		{
			int btnID = gameObject.transform.GetComponent<ScrollPanelItem>().m_BtnID2;
			if (this.ScrollItem[btnID].Index == 0)
			{
				this.bAllSet = !this.bAllSet;
				if (this.bAllSet)
				{
					this.bLangueage = true;
					this.tmpLanguageTranslation = ulong.MaxValue;
					AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
				}
				else
				{
					this.bLangueage = false;
					this.tmpLanguageTranslation = 0UL;
				}
				byte b = 0;
				while ((int)b < this.ScrollItem.Length)
				{
					this.ScrollItem[(int)b].Check.enabled = this.bAllSet;
					if (this.bAllSet)
					{
						this.ScrollItem[(int)b].BgImg.sprite = this.SpriteArray.GetSprite(1);
					}
					else
					{
						this.ScrollItem[(int)b].BgImg.sprite = this.SpriteArray.GetSprite(0);
					}
					b += 1;
				}
			}
			else
			{
				ulong valuebyIdx = this.GetValuebyIdx(this.ScrollItem[btnID].Index);
				if (this.CheckShowbyIdx(this.ScrollItem[btnID].Index))
				{
					this.ScrollItem[btnID].Check.enabled = false;
					this.ScrollItem[btnID].BgImg.sprite = this.SpriteArray.GetSprite(0);
					if (valuebyIdx != 255UL)
					{
						this.tmpLanguageTranslation -= valuebyIdx;
					}
					else
					{
						this.bLangueage = false;
					}
				}
				else
				{
					this.ScrollItem[btnID].Check.enabled = true;
					this.ScrollItem[btnID].BgImg.sprite = this.SpriteArray.GetSprite(1);
					AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
					if (valuebyIdx != 255UL)
					{
						this.tmpLanguageTranslation += valuebyIdx;
					}
					else
					{
						this.bLangueage = true;
					}
				}
				if (this.tmpLanguageTranslation == 18446744073709551615UL && this.bLangueage)
				{
					this.bAllSet = true;
				}
				else
				{
					this.bAllSet = false;
				}
				byte b2 = 0;
				while ((int)b2 < this.ScrollItem.Length)
				{
					if (this.ScrollItem[(int)b2].Index == 0)
					{
						this.ScrollItem[(int)b2].Check.enabled = this.bAllSet;
						if (this.bAllSet)
						{
							this.ScrollItem[(int)b2].BgImg.sprite = this.SpriteArray.GetSprite(1);
						}
						else
						{
							this.ScrollItem[(int)b2].BgImg.sprite = this.SpriteArray.GetSprite(0);
						}
					}
					b2 += 1;
				}
			}
		}
		else
		{
			byte b3 = 0;
			while ((int)b3 < this.ScrollItem.Length)
			{
				if (this.ScrollItem[(int)b3].Index == dataIndex)
				{
					this.ScrollItem[(int)b3].Check.enabled = true;
					this.ScrollItem[(int)b3].BgImg.sprite = this.SpriteArray.GetSprite(1);
					this.CurSelIndex = this.LangueIDTable[dataIndex];
					if (this.ProtocolType == 2)
					{
						this.tmpLanguageIdx = dataIndex;
					}
					AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
				}
				else
				{
					this.ScrollItem[(int)b3].Check.enabled = false;
					this.ScrollItem[(int)b3].BgImg.sprite = this.SpriteArray.GetSprite(0);
				}
				b3 += 1;
			}
		}
	}

	// Token: 0x06000F19 RID: 3865 RVA: 0x001A74BC File Offset: 0x001A56BC
	public void LoadCustomImage(Image img, string ImageName, string TextureName)
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door)
		{
			img.sprite = door.LoadSprite(ImageName);
			img.material = door.LoadMaterial();
		}
	}

	// Token: 0x040031F4 RID: 12788
	private const byte TotalLanguageCount = 42;

	// Token: 0x040031F5 RID: 12789
	private ScrollPanel Scroll;

	// Token: 0x040031F6 RID: 12790
	private List<float> ItemsHeight = new List<float>();

	// Token: 0x040031F7 RID: 12791
	private byte CurSelIndex;

	// Token: 0x040031F8 RID: 12792
	private byte ProtocolType;

	// Token: 0x040031F9 RID: 12793
	private UIText[] RefreshText = new UIText[3];

	// Token: 0x040031FA RID: 12794
	private RectTransform ScrollRect;

	// Token: 0x040031FB RID: 12795
	private CString TitleStr;

	// Token: 0x040031FC RID: 12796
	private byte[] LangueIDTable = new byte[]
	{
		1,
		7,
		12,
		15,
		16,
		33,
		37,
		21,
		42,
		40,
		39,
		22,
		31,
		24,
		23,
		41,
		27,
		2,
		3,
		4,
		5,
		6,
		8,
		9,
		10,
		11,
		13,
		14,
		17,
		18,
		19,
		20,
		25,
		26,
		28,
		29,
		30,
		32,
		34,
		35,
		36,
		38
	};

	// Token: 0x040031FD RID: 12797
	private ushort[] TranslationLangueIDTable = new ushort[]
	{
		4413,
		4425,
		12,
		15,
		16,
		33,
		37,
		4424,
		21,
		42,
		40,
		39,
		22,
		31,
		24,
		2,
		3,
		4,
		5,
		6,
		8,
		9,
		10,
		11,
		13,
		14,
		17,
		18,
		19,
		20,
		23,
		25,
		26,
		27,
		28,
		29,
		30,
		32,
		34,
		35,
		36,
		38,
		41,
		4403
	};

	// Token: 0x040031FE RID: 12798
	private UILanguageSelect.ItemEdit[] ScrollItem;

	// Token: 0x040031FF RID: 12799
	private byte ItemCount = 9;

	// Token: 0x04003200 RID: 12800
	private UISpritesArray SpriteArray;

	// Token: 0x04003201 RID: 12801
	private string[] mLanguage = new string[18];

	// Token: 0x04003202 RID: 12802
	private int tmpLanguageIdx = -1;

	// Token: 0x04003203 RID: 12803
	private int mLanguageCount;

	// Token: 0x04003204 RID: 12804
	private ulong tmpLanguageTranslation;

	// Token: 0x04003205 RID: 12805
	private bool bLangueage = true;

	// Token: 0x04003206 RID: 12806
	private bool bAllSet = true;

	// Token: 0x020002E3 RID: 739
	private enum UIControl
	{
		// Token: 0x04003208 RID: 12808
		Background,
		// Token: 0x04003209 RID: 12809
		Title,
		// Token: 0x0400320A RID: 12810
		ImageTitle,
		// Token: 0x0400320B RID: 12811
		Accept,
		// Token: 0x0400320C RID: 12812
		Scroll,
		// Token: 0x0400320D RID: 12813
		Item,
		// Token: 0x0400320E RID: 12814
		Close
	}

	// Token: 0x020002E4 RID: 740
	private struct ItemEdit
	{
		// Token: 0x0400320F RID: 12815
		public int Index;

		// Token: 0x04003210 RID: 12816
		public UIText Title;

		// Token: 0x04003211 RID: 12817
		public Image BgImg;

		// Token: 0x04003212 RID: 12818
		public Image Check;
	}
}
