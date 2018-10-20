using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000502 RID: 1282
internal class UIBuffInformation : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x0600199D RID: 6557 RVA: 0x002B7890 File Offset: 0x002B5A90
	public override void OnOpen(int arg1, int arg2)
	{
		this.GM = GUIManager.Instance;
		this.DM = DataManager.Instance;
		this.TTF = this.GM.GetTTFFont();
		this.door = (this.GM.FindMenu(EGUIWindow.Door) as Door);
		this.SpawnCStr();
		this.m_Data = new List<BuffInfoItem>();
		for (int i = 0; i < this.m_ScrollPanelData.Length; i++)
		{
			this.m_ScrollPanelData[i].Init();
		}
		this.InitUI();
		this.SetData();
		this.UpdateScrollPanel();
	}

	// Token: 0x0600199E RID: 6558 RVA: 0x002B7928 File Offset: 0x002B5B28
	public override void OnClose()
	{
		this.DeSpawnCStr();
	}

	// Token: 0x0600199F RID: 6559 RVA: 0x002B7930 File Offset: 0x002B5B30
	public override void UpdateUI(int arg1, int arg2)
	{
	}

	// Token: 0x060019A0 RID: 6560 RVA: 0x002B7934 File Offset: 0x002B5B34
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x060019A1 RID: 6561 RVA: 0x002B7938 File Offset: 0x002B5B38
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Refresh_AttribEffectVal && networkNews != NetworkNews.Refresh_BuffList)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				this.Refresh_FontTexture();
			}
		}
		else if (this.m_Data != null)
		{
			this.m_Data.Clear();
			this.SetData();
			this.UpdateScrollPanel();
		}
	}

	// Token: 0x060019A2 RID: 6562 RVA: 0x002B7998 File Offset: 0x002B5B98
	public void OnButtonClick(UIButton sender)
	{
		if (this.door != null)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x060019A3 RID: 6563 RVA: 0x002B79B8 File Offset: 0x002B5BB8
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.m_Data != null && dataIdx < this.m_Data.Count && panelObjectIdx < this.m_ScrollPanelData.Length)
		{
			if (this.m_ScrollPanelData[panelObjectIdx].m_Colum[0] == null)
			{
				this.m_ScrollPanelData[panelObjectIdx].m_Colum[0] = item.transform.GetChild(0).gameObject;
				this.m_ScrollPanelData[panelObjectIdx].m_Colum[1] = item.transform.GetChild(1).gameObject;
				this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0] = item.transform.GetChild(0).GetComponent<RectTransform>();
				this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1] = item.transform.GetChild(1).GetComponent<RectTransform>();
				this.m_ScrollPanelData[panelObjectIdx].m_Image[0] = item.transform.GetChild(0).GetChild(0).GetComponent<Image>();
				this.m_ScrollPanelData[panelObjectIdx].m_Image[1] = item.transform.GetChild(1).GetChild(0).GetComponent<Image>();
				this.m_ScrollPanelData[panelObjectIdx].m_Outline[0] = item.transform.GetChild(0).GetChild(1).GetComponent<Outline>();
				this.m_ScrollPanelData[panelObjectIdx].m_Outline[1] = item.transform.GetChild(1).GetChild(1).GetComponent<Outline>();
				this.m_ScrollPanelData[panelObjectIdx].m_Shadow[0] = item.transform.GetChild(0).GetChild(1).GetComponent<Shadow>();
				this.m_ScrollPanelData[panelObjectIdx].m_Shadow[1] = item.transform.GetChild(1).GetChild(1).GetComponent<Shadow>();
				this.m_ScrollPanelData[panelObjectIdx].m_Text[0] = item.transform.GetChild(0).GetChild(1).GetComponent<UIText>();
				this.m_ScrollPanelData[panelObjectIdx].m_Text[1] = item.transform.GetChild(1).GetChild(1).GetComponent<UIText>();
				this.m_ScrollPanelData[panelObjectIdx].m_Text[0].font = this.TTF;
				this.m_ScrollPanelData[panelObjectIdx].m_Text[1].font = this.TTF;
			}
			if (this.m_Data[dataIdx].m_Type == 0)
			{
				this.SetItemInformationType(dataIdx, panelObjectIdx);
			}
			else if (this.m_Data[dataIdx].m_Type == 1)
			{
				this.SetItemFirstTitleType(dataIdx, panelObjectIdx);
			}
			else if (this.m_Data[dataIdx].m_Type == 2)
			{
				this.SetItemSecTitleType(dataIdx, panelObjectIdx);
			}
			else if (this.m_Data[dataIdx].m_Type == 4)
			{
				this.SetItemTitleContent(dataIdx, panelObjectIdx);
			}
			else
			{
				this.SetItemCencontType(dataIdx, panelObjectIdx);
			}
		}
	}

	// Token: 0x060019A4 RID: 6564 RVA: 0x002B7CCC File Offset: 0x002B5ECC
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x060019A5 RID: 6565 RVA: 0x002B7CD0 File Offset: 0x002B5ED0
	private void SpawnCStr()
	{
		if (this.m_DeshieldCStr != null)
		{
			for (int i = 0; i < this.m_DeshieldCStr.Length; i++)
			{
				this.m_DeshieldCStr[i] = StringManager.Instance.SpawnString(50);
			}
		}
	}

	// Token: 0x060019A6 RID: 6566 RVA: 0x002B7D18 File Offset: 0x002B5F18
	private void DeSpawnCStr()
	{
		if (this.m_DeshieldCStr != null)
		{
			for (int i = 0; i < this.m_DeshieldCStr.Length; i++)
			{
				if (this.m_DeshieldCStr[i] != null)
				{
					StringManager.Instance.DeSpawnString(this.m_DeshieldCStr[i]);
					this.m_DeshieldCStr[i] = null;
				}
			}
		}
	}

	// Token: 0x060019A7 RID: 6567 RVA: 0x002B7D74 File Offset: 0x002B5F74
	private void InitUI()
	{
		this.m_SpArray = base.transform.gameObject.GetComponent<UISpritesArray>();
		this.m_TitleText = base.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_TitleText.font = this.TTF;
		this.m_TitleText.text = this.DM.mStringTable.GetStringByID(9938u);
		this.m_EmptyText = base.transform.GetChild(4).GetComponent<UIText>();
		this.m_EmptyText.font = this.TTF;
		Image component = base.transform.GetChild(3).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close_base");
		component.material = this.door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX && component)
		{
			component.enabled = false;
		}
		UIButton component2 = base.transform.GetChild(3).GetChild(0).GetComponent<UIButton>();
		component2.m_BtnID1 = 1;
		component2.m_Handler = this;
		component2.image.sprite = this.door.LoadSprite("UI_main_close");
		component2.image.material = this.door.LoadMaterial();
		this.m_ScrollPanel = base.transform.GetChild(1).GetComponent<ScrollPanel>();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x060019A8 RID: 6568 RVA: 0x002B7EE8 File Offset: 0x002B60E8
	private void SetData()
	{
		int num = 0;
		BuffInfoItem item = default(BuffInfoItem);
		item.Init();
		item.m_Type = 0;
		item.m_Width = 775f;
		item.m_Height = this.GetTitleTextHeight() + 20f;
		item.m_ColumNum = 1;
		item.m_Column[0].ColumnWidth = 755f;
		item.m_DataIdx = 0;
		this.m_Data.Add(item);
		item = default(BuffInfoItem);
		item.Init();
		item.m_Type = 1;
		item.m_Width = 775f;
		item.m_Height = 45f;
		item.m_ColumNum = 1;
		item.m_DataIdx = 0;
		this.m_Data.Add(item);
		item = default(BuffInfoItem);
		item.Init();
		item.m_Type = 4;
		item.m_Width = 775f;
		item.m_Height = 30f;
		item.m_ColumNum = 1;
		item.m_DataIdx = 0;
		item.m_EffectType = GATTR_ENUM.EGE_DESHIELD_ATK;
		item.m_EffectValue = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_DESHIELD_ATK);
		item.m_StrIdx = num++;
		this.m_Data.Add(item);
		for (int i = 1; i < this.effectTypeArray.Length; i++)
		{
			uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(this.effectTypeArray[i]);
			if (effectBaseVal > 0u)
			{
				item = default(BuffInfoItem);
				item.Init();
				item.m_Type = 4;
				item.m_Width = 775f;
				item.m_Height = 30f;
				item.m_ColumNum = 1;
				item.m_DataIdx = 0;
				item.m_EffectType = this.effectTypeArray[i];
				item.m_EffectValue = effectBaseVal;
				item.m_StrIdx = num++;
				this.m_Data.Add(item);
			}
		}
		item = default(BuffInfoItem);
		item.Init();
		item.m_Type = 2;
		item.m_Width = 775f;
		item.m_Height = 40f;
		item.m_ColumNum = 2;
		item.m_DataIdx = 0;
		item.m_Column[0].ColumnWidth = 150f;
		item.m_Column[1].ColumnWidth = 625f;
		this.m_Data.Add(item);
		num = 0;
		for (int j = 0; j < 11; j++)
		{
			item = default(BuffInfoItem);
			item.Init();
			item.m_Type = 3;
			item.m_Width = 775f;
			item.m_Height = 40f;
			item.m_ColumNum = 2;
			item.m_DataIdx = 0;
			item.m_Column[0].ColumnWidth = 150f;
			item.m_Column[1].ColumnWidth = 625f;
			item.m_StrIdx = num++;
			this.m_Data.Add(item);
		}
	}

	// Token: 0x060019A9 RID: 6569 RVA: 0x002B81E8 File Offset: 0x002B63E8
	private void UpdateScrollPanel()
	{
		if (this.m_ScrollPanel == null)
		{
			return;
		}
		List<float> list = new List<float>();
		for (int i = 0; i < this.m_Data.Count; i++)
		{
			list.Add(this.m_Data[i].m_Height);
		}
		if (this.bFirstInit)
		{
			this.m_ScrollPanel.IntiScrollPanel(775f, 0f, 0f, list, 35, this);
		}
		else
		{
			this.m_ScrollPanel.AddNewDataHeight(list, false, false);
		}
		this.bFirstInit = false;
	}

	// Token: 0x060019AA RID: 6570 RVA: 0x002B8288 File Offset: 0x002B6488
	private float GetTitleTextHeight()
	{
		this.m_EmptyText.text = this.DM.mStringTable.GetStringByID(9939u);
		this.m_EmptyText.SetAllDirty();
		this.m_EmptyText.cachedTextGenerator.Invalidate();
		return this.m_EmptyText.preferredHeight;
	}

	// Token: 0x060019AB RID: 6571 RVA: 0x002B82DC File Offset: 0x002B64DC
	private void ItemEmpty(int panelObjectIdx)
	{
		for (int i = 0; i < 2; i++)
		{
			this.m_ScrollPanelData[panelObjectIdx].m_Image[i].enabled = false;
			this.m_ScrollPanelData[panelObjectIdx].m_Text[i].enabled = false;
			this.m_ScrollPanelData[panelObjectIdx].m_Text[i].resizeTextForBestFit = true;
		}
	}

	// Token: 0x060019AC RID: 6572 RVA: 0x002B8348 File Offset: 0x002B6548
	private void EnableColum(int dataIdx, int panelObjectIdx)
	{
		int num = this.m_ScrollPanelData[panelObjectIdx].m_Colum.Length;
		int columNum = this.m_Data[dataIdx].m_ColumNum;
		for (int i = 0; i < columNum; i++)
		{
			this.m_ScrollPanelData[panelObjectIdx].m_Colum[i].SetActive(true);
		}
		for (int j = columNum; j < num; j++)
		{
			this.m_ScrollPanelData[panelObjectIdx].m_Colum[j].SetActive(false);
		}
	}

	// Token: 0x060019AD RID: 6573 RVA: 0x002B83D8 File Offset: 0x002B65D8
	private void SetColumText(bool bEnable, int panelObjectIdx, int textIdx, uint strID, Color c, Vector2 size, bool bShadow = false, bool bOutline = false, int fontSize = 18, bool bBestFit = true, float posX = 0f, float posY = 0f, TextAnchor textAnchor = TextAnchor.MiddleCenter)
	{
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].enabled = bEnable;
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].rectTransform.sizeDelta = size;
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].rectTransform.anchoredPosition = new Vector2(posX, posY);
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].color = c;
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].fontSize = fontSize;
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].resizeTextMaxSize = fontSize;
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].alignment = textAnchor;
		if (GUIManager.Instance.IsArabic && textAnchor == TextAnchor.MiddleLeft)
		{
			this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].AdjuestUI();
			this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].alignment = TextAnchor.MiddleRight;
		}
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].text = this.DM.mStringTable.GetStringByID(strID);
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].resizeTextForBestFit = bBestFit;
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].UpdateArabicPos();
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].SetAllDirty();
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].cachedTextGenerator.Invalidate();
		this.m_ScrollPanelData[panelObjectIdx].m_Shadow[textIdx].enabled = bShadow;
		this.m_ScrollPanelData[panelObjectIdx].m_Outline[textIdx].enabled = bOutline;
	}

	// Token: 0x060019AE RID: 6574 RVA: 0x002B85B8 File Offset: 0x002B67B8
	private void SetEffectValueCloumText(bool bEnable, int panelObjectIdx, int textIdx, GATTR_ENUM effect, double effectValue, Color c, Vector2 size)
	{
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].enabled = bEnable;
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].rectTransform.sizeDelta = size;
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].rectTransform.anchoredPosition = new Vector2(10f, 0f);
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].color = c;
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].fontSize = 18;
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].resizeTextMaxSize = 18;
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].alignment = TextAnchor.UpperLeft;
		if (GUIManager.Instance.IsArabic)
		{
			this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].AdjuestUI();
			this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].alignment = TextAnchor.UpperRight;
		}
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].text = this.GetEffectStr(effect, effectValue).ToString();
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].UpdateArabicPos();
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].resizeTextForBestFit = true;
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].SetAllDirty();
		this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].cachedTextGenerator.Invalidate();
		this.m_ScrollPanelData[panelObjectIdx].m_Shadow[textIdx].enabled = true;
		this.m_ScrollPanelData[panelObjectIdx].m_Outline[textIdx].enabled = true;
	}

	// Token: 0x060019AF RID: 6575 RVA: 0x002B8790 File Offset: 0x002B6990
	private CString GetEffectStr(GATTR_ENUM effect, double effectValue)
	{
		CString cstring = null;
		int num = 0;
		if (this.m_DeshieldCStr != null)
		{
			ushort[] array = new ushort[]
			{
				4326,
				4327,
				4328,
				4311,
				4312,
				4313,
				4314,
				4316,
				4317,
				4318,
				4319,
				4321,
				4322,
				4323,
				4324
			};
			switch (effect)
			{
			case GATTR_ENUM.EGA_DESHIELD_INFANTRY_ATK:
				cstring = this.m_DeshieldCStr[3];
				cstring.ClearString();
				cstring.Append(this.DM.mStringTable.GetStringByID((uint)array[3]));
				break;
			case GATTR_ENUM.EGA_DESHIELD_CAVALRY_ATK:
				cstring = this.m_DeshieldCStr[4];
				cstring.ClearString();
				cstring.Append(this.DM.mStringTable.GetStringByID((uint)array[4]));
				break;
			case GATTR_ENUM.EGA_DESHIELD_RANGED_ATK:
				cstring = this.m_DeshieldCStr[5];
				cstring.ClearString();
				cstring.Append(this.DM.mStringTable.GetStringByID((uint)array[5]));
				break;
			case GATTR_ENUM.EGA_DESHIELD_SIEGE_ATK:
				cstring = this.m_DeshieldCStr[6];
				cstring.ClearString();
				cstring.Append(this.DM.mStringTable.GetStringByID((uint)array[6]));
				break;
			case GATTR_ENUM.EGA_DESHIELD_INFANTRY_DEF:
				cstring = this.m_DeshieldCStr[7];
				cstring.ClearString();
				cstring.Append(this.DM.mStringTable.GetStringByID((uint)array[7]));
				break;
			case GATTR_ENUM.EGA_DESHIELD_CAVALRY_DEF:
				cstring = this.m_DeshieldCStr[8];
				cstring.ClearString();
				cstring.Append(this.DM.mStringTable.GetStringByID((uint)array[8]));
				break;
			case GATTR_ENUM.EGA_DESHIELD_RANGED_DEF:
				cstring = this.m_DeshieldCStr[9];
				cstring.ClearString();
				cstring.Append(this.DM.mStringTable.GetStringByID((uint)array[9]));
				break;
			case GATTR_ENUM.EGA_DESHIELD_SIEGE_DEF:
				cstring = this.m_DeshieldCStr[10];
				cstring.ClearString();
				cstring.Append(this.DM.mStringTable.GetStringByID((uint)array[10]));
				break;
			case GATTR_ENUM.EGA_DESHIELD_INFANTRY_HEALTH:
				cstring = this.m_DeshieldCStr[11];
				cstring.ClearString();
				cstring.Append(this.DM.mStringTable.GetStringByID((uint)array[11]));
				break;
			case GATTR_ENUM.EGA_DESHIELD_CAVALRY_HEALTH:
				cstring = this.m_DeshieldCStr[12];
				cstring.ClearString();
				cstring.Append(this.DM.mStringTable.GetStringByID((uint)array[12]));
				break;
			case GATTR_ENUM.EGA_DESHIELD_RANGED_HEALTH:
				cstring = this.m_DeshieldCStr[13];
				cstring.ClearString();
				cstring.Append(this.DM.mStringTable.GetStringByID((uint)array[13]));
				break;
			case GATTR_ENUM.EGA_DESHIELD_SIEGE_HEALTH:
				cstring = this.m_DeshieldCStr[14];
				cstring.ClearString();
				cstring.Append(this.DM.mStringTable.GetStringByID((uint)array[14]));
				break;
			default:
				switch (effect)
				{
				case GATTR_ENUM.EGE_DESHIELD_ATK:
					num = 5;
					cstring = this.m_DeshieldCStr[0];
					cstring.ClearString();
					cstring.Append(this.DM.mStringTable.GetStringByID((uint)array[0]));
					break;
				case GATTR_ENUM.EGE_DESHIELD_DEF:
					cstring = this.m_DeshieldCStr[1];
					cstring.ClearString();
					cstring.Append(this.DM.mStringTable.GetStringByID((uint)array[1]));
					break;
				case GATTR_ENUM.EGE_DESHIELD_HEALTH:
					cstring = this.m_DeshieldCStr[2];
					cstring.ClearString();
					cstring.Append(this.DM.mStringTable.GetStringByID((uint)array[2]));
					break;
				}
				break;
			}
			double f = effectValue / 100.0 + (double)num;
			cstring.DoubleToFormat(f, 2, false);
			if (this.GM.IsArabic)
			{
				cstring.AppendFormat("%{0}");
			}
			else
			{
				cstring.AppendFormat("{0}%");
			}
			return cstring;
		}
		return null;
	}

	// Token: 0x060019B0 RID: 6576 RVA: 0x002B8B18 File Offset: 0x002B6D18
	private void SetColumBackground(bool bEnable, int panelObjectIdx, int imageIdx, ushort spID, Vector2 size)
	{
		this.m_ScrollPanelData[panelObjectIdx].m_Image[imageIdx].enabled = bEnable;
		this.m_ScrollPanelData[panelObjectIdx].m_Image[imageIdx].rectTransform.sizeDelta = size;
		this.m_ScrollPanelData[panelObjectIdx].m_Image[imageIdx].sprite = this.m_SpArray.GetSprite((int)spID);
	}

	// Token: 0x060019B1 RID: 6577 RVA: 0x002B8B84 File Offset: 0x002B6D84
	private void SetItemInformationType(int dataIdx, int panelObjectIdx)
	{
		this.ItemEmpty(panelObjectIdx);
		this.EnableColum(dataIdx, panelObjectIdx);
		Vector2 vector = new Vector2(775f, this.GetTitleTextHeight());
		this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0].sizeDelta = vector;
		this.m_ScrollPanelData[panelObjectIdx].m_Colum[0].SetActive(true);
		this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].sizeDelta = vector;
		this.m_ScrollPanelData[panelObjectIdx].m_Colum[1].SetActive(false);
		vector = new Vector2(755f, this.m_Data[dataIdx].m_Height);
		this.SetColumText(true, panelObjectIdx, 0, 9939u, this.DefaultColor, vector, true, true, 20, false, 10f, 0f, TextAnchor.MiddleLeft);
		this.SetColumText(false, panelObjectIdx, 1, 0u, this.DefaultColor, vector, false, false, 18, true, 0f, 0f, TextAnchor.MiddleCenter);
		this.SetColumBackground(false, panelObjectIdx, 0, 0, vector);
		this.SetColumBackground(false, panelObjectIdx, 1, 0, vector);
	}

	// Token: 0x060019B2 RID: 6578 RVA: 0x002B8C94 File Offset: 0x002B6E94
	private void SetItemFirstTitleType(int dataIdx, int panelObjectIdx)
	{
		ushort strID = (!this.DM.bHaveWarBuff) ? 11049 : 11050;
		this.ItemEmpty(panelObjectIdx);
		this.EnableColum(dataIdx, panelObjectIdx);
		Vector2 vector = new Vector2(775f, this.m_Data[dataIdx].m_Height);
		Vector2 size = new Vector2(775f, 4f);
		this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0].sizeDelta = vector;
		this.m_ScrollPanelData[panelObjectIdx].m_Colum[0].SetActive(true);
		this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].sizeDelta = vector;
		this.m_ScrollPanelData[panelObjectIdx].m_Colum[1].SetActive(false);
		this.SetColumText(true, panelObjectIdx, 0, (uint)strID, this.DefaultColor, vector, true, true, 24, true, 0f, 0f, TextAnchor.MiddleCenter);
		this.SetColumText(false, panelObjectIdx, 1, 0u, this.DefaultColor, vector, false, false, 18, true, 0f, 0f, TextAnchor.MiddleCenter);
		this.SetColumBackground(true, panelObjectIdx, 0, 5, size);
		this.SetColumBackground(false, panelObjectIdx, 1, 0, size);
	}

	// Token: 0x060019B3 RID: 6579 RVA: 0x002B8DC0 File Offset: 0x002B6FC0
	private void SetItemSecTitleType(int dataIdx, int panelObjectIdx)
	{
		this.ItemEmpty(panelObjectIdx);
		this.EnableColum(dataIdx, panelObjectIdx);
		Vector2 vector = new Vector2(this.m_Data[dataIdx].m_Column[0].ColumnWidth, this.m_Data[dataIdx].m_Height);
		this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0].sizeDelta = vector;
		this.m_ScrollPanelData[panelObjectIdx].m_Colum[0].SetActive(true);
		Vector2 vector2 = new Vector2(this.m_Data[dataIdx].m_Column[1].ColumnWidth, this.m_Data[dataIdx].m_Height);
		this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].sizeDelta = vector2;
		this.m_ScrollPanelData[panelObjectIdx].m_Colum[1].SetActive(true);
		Vector2 anchoredPosition = this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].anchoredPosition;
		anchoredPosition.x = this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0].anchoredPosition.x + this.m_Data[dataIdx].m_Column[0].ColumnWidth;
		this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].anchoredPosition = anchoredPosition;
		this.SetColumText(true, panelObjectIdx, 0, 9941u, this.YallowColor, vector, false, false, 24, true, 0f, 0f, TextAnchor.MiddleCenter);
		this.SetColumText(true, panelObjectIdx, 1, 9942u, this.YallowColor, vector2, false, false, 24, true, 0f, 0f, TextAnchor.MiddleCenter);
		this.SetColumBackground(true, panelObjectIdx, 0, 4, vector);
		this.SetColumBackground(true, panelObjectIdx, 1, 4, vector2);
	}

	// Token: 0x060019B4 RID: 6580 RVA: 0x002B8F94 File Offset: 0x002B7194
	private void SetItemTitleContent(int dataIdx, int panelObjectIdx)
	{
		Color c = (!this.DM.bHaveWarBuff) ? this.NoHaveWarBuffColor : this.HaveWarBuffColor;
		this.ItemEmpty(panelObjectIdx);
		this.EnableColum(dataIdx, panelObjectIdx);
		Vector2 vector = new Vector2(775f, this.m_Data[dataIdx].m_Height);
		Vector2 size = new Vector2(775f, 4f);
		this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0].sizeDelta = vector;
		this.m_ScrollPanelData[panelObjectIdx].m_Colum[0].SetActive(true);
		this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].sizeDelta = vector;
		this.m_ScrollPanelData[panelObjectIdx].m_Colum[1].SetActive(false);
		this.SetEffectValueCloumText(true, panelObjectIdx, 0, this.m_Data[dataIdx].m_EffectType, this.m_Data[dataIdx].m_EffectValue, c, vector);
		this.SetEffectValueCloumText(false, panelObjectIdx, 1, this.m_Data[dataIdx].m_EffectType, this.m_Data[dataIdx].m_EffectValue, c, vector);
		this.SetColumBackground(false, panelObjectIdx, 0, 5, size);
		this.SetColumBackground(false, panelObjectIdx, 1, 0, size);
	}

	// Token: 0x060019B5 RID: 6581 RVA: 0x002B90EC File Offset: 0x002B72EC
	private void SetItemCencontType(int dataIdx, int panelObjectIdx)
	{
		this.ItemEmpty(panelObjectIdx);
		this.EnableColum(dataIdx, panelObjectIdx);
		ushort spID;
		ushort spID2;
		if (dataIdx % 2 == 0)
		{
			spID = 0;
			spID2 = 1;
		}
		else
		{
			spID = 2;
			spID2 = 3;
		}
		Vector2 vector = new Vector2(this.m_Data[dataIdx].m_Column[0].ColumnWidth, this.m_Data[dataIdx].m_Height);
		this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0].sizeDelta = vector;
		this.m_ScrollPanelData[panelObjectIdx].m_Colum[0].SetActive(true);
		Vector2 vector2 = new Vector2(this.m_Data[dataIdx].m_Column[1].ColumnWidth, this.m_Data[dataIdx].m_Height);
		this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].sizeDelta = vector2;
		this.m_ScrollPanelData[panelObjectIdx].m_Colum[1].SetActive(true);
		Vector2 anchoredPosition = this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].anchoredPosition;
		anchoredPosition.x = this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0].anchoredPosition.x + this.m_Data[dataIdx].m_Column[0].ColumnWidth;
		this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].anchoredPosition = anchoredPosition;
		this.SetColumText(true, panelObjectIdx, 0, (uint)this.StrID[this.m_Data[dataIdx].m_StrIdx], this.DefaultColor, vector, false, false, 18, true, 0f, 0f, TextAnchor.MiddleCenter);
		this.SetColumText(true, panelObjectIdx, 1, (uint)this.StrID2[this.m_Data[dataIdx].m_StrIdx], this.DefaultColor, vector2, false, false, 18, true, 0f, 0f, TextAnchor.MiddleCenter);
		this.SetColumBackground(true, panelObjectIdx, 0, spID, vector);
		this.SetColumBackground(true, panelObjectIdx, 1, spID2, vector2);
	}

	// Token: 0x060019B6 RID: 6582 RVA: 0x002B9308 File Offset: 0x002B7508
	private void Refresh_FontTexture()
	{
		if (this.m_TitleText != null && this.m_TitleText.enabled)
		{
			this.m_TitleText.enabled = false;
			this.m_TitleText.enabled = true;
		}
		if (this.m_ScrollPanelData != null)
		{
			for (int i = 0; i < this.m_ScrollPanelData.Length; i++)
			{
				if (this.m_ScrollPanelData[i].m_Text != null)
				{
					if (this.m_ScrollPanelData[i].m_Text[0] != null && this.m_ScrollPanelData[i].m_Text[0].enabled)
					{
						this.m_ScrollPanelData[i].m_Text[0].enabled = false;
						this.m_ScrollPanelData[i].m_Text[0].enabled = true;
					}
					if (this.m_ScrollPanelData[i].m_Text[1] != null && this.m_ScrollPanelData[i].m_Text[1].enabled)
					{
						this.m_ScrollPanelData[i].m_Text[1].enabled = false;
						this.m_ScrollPanelData[i].m_Text[1].enabled = true;
					}
				}
			}
		}
	}

	// Token: 0x04004C3A RID: 19514
	private const int MaxCstr = 15;

	// Token: 0x04004C3B RID: 19515
	private const int MaxScrollCount = 35;

	// Token: 0x04004C3C RID: 19516
	private GATTR_ENUM[] effectTypeArray = new GATTR_ENUM[]
	{
		GATTR_ENUM.EGE_DESHIELD_ATK,
		GATTR_ENUM.EGE_DESHIELD_DEF,
		GATTR_ENUM.EGE_DESHIELD_HEALTH,
		GATTR_ENUM.EGA_DESHIELD_INFANTRY_ATK,
		GATTR_ENUM.EGA_DESHIELD_CAVALRY_ATK,
		GATTR_ENUM.EGA_DESHIELD_RANGED_ATK,
		GATTR_ENUM.EGA_DESHIELD_SIEGE_ATK,
		GATTR_ENUM.EGA_DESHIELD_INFANTRY_DEF,
		GATTR_ENUM.EGA_DESHIELD_CAVALRY_DEF,
		GATTR_ENUM.EGA_DESHIELD_RANGED_DEF,
		GATTR_ENUM.EGA_DESHIELD_SIEGE_DEF,
		GATTR_ENUM.EGA_DESHIELD_INFANTRY_HEALTH,
		GATTR_ENUM.EGA_DESHIELD_CAVALRY_HEALTH,
		GATTR_ENUM.EGA_DESHIELD_RANGED_HEALTH,
		GATTR_ENUM.EGA_DESHIELD_SIEGE_HEALTH
	};

	// Token: 0x04004C3D RID: 19517
	private ushort[] StrID = new ushort[]
	{
		9945,
		9946,
		9947,
		9948,
		9949,
		9950,
		9951,
		9952,
		9953,
		9954,
		9955
	};

	// Token: 0x04004C3E RID: 19518
	private ushort[] StrID2 = new ushort[]
	{
		9956,
		9957,
		9958,
		9959,
		9960,
		9961,
		9962,
		9963,
		9964,
		9965,
		9966
	};

	// Token: 0x04004C3F RID: 19519
	private CString[] m_DeshieldCStr = new CString[15];

	// Token: 0x04004C40 RID: 19520
	private Color DefaultColor = new Color(1f, 1f, 1f, 1f);

	// Token: 0x04004C41 RID: 19521
	private Color YallowColor = new Color(1f, 1f, 0.8f, 1f);

	// Token: 0x04004C42 RID: 19522
	private Color HaveWarBuffColor = new Color(0f, 1f, 0f, 1f);

	// Token: 0x04004C43 RID: 19523
	private Color NoHaveWarBuffColor = new Color(0.7f, 0.7f, 0.7f, 1f);

	// Token: 0x04004C44 RID: 19524
	private GUIManager GM;

	// Token: 0x04004C45 RID: 19525
	private DataManager DM;

	// Token: 0x04004C46 RID: 19526
	private Font TTF;

	// Token: 0x04004C47 RID: 19527
	private Door door;

	// Token: 0x04004C48 RID: 19528
	private UISpritesArray m_SpArray;

	// Token: 0x04004C49 RID: 19529
	private UIText m_TitleText;

	// Token: 0x04004C4A RID: 19530
	private UIText m_EmptyText;

	// Token: 0x04004C4B RID: 19531
	private UIButton m_Exit;

	// Token: 0x04004C4C RID: 19532
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04004C4D RID: 19533
	private List<BuffInfoItem> m_Data;

	// Token: 0x04004C4E RID: 19534
	private BuffItemCom[] m_ScrollPanelData = new BuffItemCom[35];

	// Token: 0x04004C4F RID: 19535
	private bool bFirstInit = true;
}
