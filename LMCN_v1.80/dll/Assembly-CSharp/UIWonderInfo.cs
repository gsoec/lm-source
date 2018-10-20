using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020006C3 RID: 1731
public class UIWonderInfo : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06002137 RID: 8503 RVA: 0x003F25B8 File Offset: 0x003F07B8
	public override void OnOpen(int arg1, int arg2)
	{
		this.nowMapPoint = DataManager.MapDataController.LayoutMapInfo[arg1];
		if ((int)this.nowMapPoint.tableID < DataManager.MapDataController.YolkPointTable.Length)
		{
			this.mapYolk = DataManager.MapDataController.YolkPointTable[(int)this.nowMapPoint.tableID];
		}
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.door.UpdateUI(1, 2);
		Image component = base.transform.GetChild(0).GetChild(6).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close_base");
		component.material = this.door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			component.enabled = false;
		}
		component = base.transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<Image>();
		component.sprite = this.door.LoadSprite("UI_main_close");
		component.material = this.door.LoadMaterial();
		base.transform.GetChild(0).GetChild(6).GetChild(0).GetComponent<UIButton>().m_Handler = this;
		this.m_descript = base.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>();
		this.m_descript.text = this.DM.mStringTable.GetStringByID((this.mapYolk.WonderID != 0) ? ((!DataManager.MapDataController.IsFocusWorldWar()) ? 7251u : 11063u) : ((!DataManager.MapDataController.IsFocusWorldWar()) ? 9354u : 9994u));
		this.m_descript.font = GUIManager.Instance.GetTTFFont();
		for (int i = 0; i < 20; i++)
		{
			this.ItemTag[i] = new Text[9];
			this.ItemRow[i] = new Text[9];
			this.ItemNum[i] = new Text[9];
			this.m_Str[i] = StringManager.Instance.SpawnString(300);
		}
		this.ItemsHeight.Capacity = 9;
		if (this.mapYolk.WonderID > 0)
		{
			this.ItemsHeight.Add(84f);
		}
		else
		{
			this.ItemsHeight.Add(70f);
		}
		this.ItemsHeight.Add(41f);
		this.ItemsHeight.Add(46f);
		this.ItemTag[0][0] = base.transform.GetChild(0).GetChild(10).GetChild(3).GetChild(0).GetComponent<Text>();
		this.ItemTag[0][0].text = this.DM.mStringTable.GetStringByID(DataManager.MapDataController.IsFocusWorldWar() ? ((this.mapYolk.WonderID <= 0) ? 9995u : 11064u) : ((this.mapYolk.WonderID != 0) ? 7253u : 9355u));
		this.ItemTag[0][0].font = this.Font;
		Vector2 sizeDelta = this.ItemTag[0][0].rectTransform.sizeDelta;
		sizeDelta.y = this.ItemTag[0][0].preferredHeight;
		this.ItemTag[0][0].rectTransform.sizeDelta = sizeDelta;
		List<float> itemsHeight;
		List<float> list = itemsHeight = this.ItemsHeight;
		int index2;
		int index = index2 = 0;
		float num = itemsHeight[index2];
		list[index] = num + (this.ItemTag[0][0].preferredHeight + 10f);
		this.ItemTag[0][1] = base.transform.GetChild(0).GetChild(10).GetChild(3).GetChild(1).GetComponent<Text>();
		this.ItemTag[0][1].text = this.DM.mStringTable.GetStringByID(DataManager.MapDataController.IsFocusWorldWar() ? ((this.mapYolk.WonderID <= 0) ? 9996u : 11065u) : ((this.mapYolk.WonderID != 0) ? 7254u : 9356u));
		this.ItemTag[0][1].font = this.Font;
		this.ItemTag[0][1].transform.localPosition = this.ItemTag[0][0].transform.localPosition - new Vector3(0f, this.ItemTag[0][0].preferredHeight + 25f, 0f);
		sizeDelta = this.ItemTag[0][1].rectTransform.sizeDelta;
		sizeDelta.y = this.ItemTag[0][1].preferredHeight;
		this.ItemTag[0][1].rectTransform.sizeDelta = sizeDelta;
		List<float> itemsHeight2;
		List<float> list2 = itemsHeight2 = this.ItemsHeight;
		int index3 = index2 = 0;
		num = itemsHeight2[index2];
		list2[index3] = num + this.ItemTag[0][1].preferredHeight;
		this.ItemTag[0][2] = base.transform.GetChild(0).GetChild(10).GetChild(3).GetChild(2).GetComponent<Text>();
		this.ItemTag[0][2].text = this.DM.mStringTable.GetStringByID(DataManager.MapDataController.IsFocusWorldWar() ? ((this.mapYolk.WonderID <= 0) ? 9997u : 11066u) : ((this.mapYolk.WonderID != 0) ? 7255u : 9357u));
		this.ItemTag[0][2].font = this.Font;
		this.ItemTag[0][2].transform.localPosition = this.ItemTag[0][1].transform.localPosition - new Vector3(0f, this.ItemTag[0][1].preferredHeight + 20f, 0f);
		sizeDelta = this.ItemTag[0][2].rectTransform.sizeDelta;
		sizeDelta.y = this.ItemTag[0][2].preferredHeight;
		this.ItemTag[0][2].rectTransform.sizeDelta = sizeDelta;
		List<float> itemsHeight3;
		List<float> list3 = itemsHeight3 = this.ItemsHeight;
		int index4 = index2 = 0;
		num = itemsHeight3[index2];
		list3[index4] = num + this.ItemTag[0][2].preferredHeight;
		this.ItemTag[0][3] = base.transform.GetChild(0).GetChild(10).GetChild(3).GetChild(3).GetComponent<Text>();
		this.ItemTag[0][4] = base.transform.GetChild(0).GetChild(10).GetChild(3).GetChild(4).GetComponent<Text>();
		if (DataManager.MapDataController.IsFocusWorldWar())
		{
			for (int j = 1; j < 7; j++)
			{
				base.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(2).GetComponent<Text>().font = this.Font;
				this.ItemNum[0][j - 1] = base.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(3).GetComponent<Text>();
				this.ItemNum[0][j - 1].text = this.DM.mStringTable.GetStringByID((uint)((this.mapYolk.WonderID <= 0) ? ((j < 6) ? ((j <= 1) ? 10000 : (j + 10999)) : 11082) : (j + 11068)));
				this.ItemNum[0][j - 1].font = this.Font;
				this.ItemsHeight.Add((this.ItemNum[0][j - 1].preferredHeight <= 32f) ? 46f : ((float)Math.Ceiling((double)(this.ItemNum[0][j - 1].preferredHeight / 32f)) * 32f));
			}
		}
		else if (this.mapYolk.WonderID > 0)
		{
			this.ItemTag[0][3].text = this.DM.mStringTable.GetStringByID(7256u);
			this.ItemTag[0][3].font = this.Font;
			this.ItemTag[0][3].transform.localPosition = this.ItemTag[0][2].transform.localPosition - new Vector3(0f, this.ItemTag[0][2].preferredHeight + 20f, 0f);
			sizeDelta = this.ItemTag[0][3].rectTransform.sizeDelta;
			sizeDelta.y = this.ItemTag[0][3].preferredHeight;
			this.ItemTag[0][3].rectTransform.sizeDelta = sizeDelta;
			List<float> itemsHeight4;
			List<float> list4 = itemsHeight4 = this.ItemsHeight;
			int index5 = index2 = 0;
			num = itemsHeight4[index2];
			list4[index5] = num + this.ItemTag[0][3].preferredHeight;
			this.ItemTag[0][4].text = this.DM.mStringTable.GetStringByID(9374u);
			this.ItemTag[0][4].font = this.Font;
			this.ItemTag[0][4].transform.localPosition = this.ItemTag[0][3].transform.localPosition - new Vector3(0f, this.ItemTag[0][3].preferredHeight + 20f, 0f);
			sizeDelta = this.ItemTag[0][4].rectTransform.sizeDelta;
			sizeDelta.y = this.ItemTag[0][4].preferredHeight;
			this.ItemTag[0][4].rectTransform.sizeDelta = sizeDelta;
			List<float> itemsHeight5;
			List<float> list5 = itemsHeight5 = this.ItemsHeight;
			int index6 = index2 = 0;
			num = itemsHeight5[index2];
			list5[index6] = num + (this.ItemTag[0][4].preferredHeight + 10f);
			for (int k = 1; k < 6; k++)
			{
				base.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(2).GetComponent<Text>().font = this.Font;
				this.ItemNum[0][k - 1] = base.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(3).GetComponent<Text>();
				this.ItemNum[0][k - 1].text = this.DM.mStringTable.GetStringByID((uint)(k + 9384 - 1));
				this.ItemNum[0][k - 1].font = this.Font;
				this.ItemsHeight.Add((this.ItemNum[0][k - 1].preferredHeight <= 32f) ? 46f : ((float)Math.Ceiling((double)(this.ItemNum[0][k - 1].preferredHeight / 32f)) * 32f));
			}
			this.ItemsHeight.Add(38f);
			this.ItemsHeight.Add(46f);
			for (int l = 1; l < 7; l++)
			{
				base.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(2).GetComponent<Text>().font = this.Font;
				this.ItemNum[0][l - 1] = base.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(3).GetComponent<Text>();
				this.ItemNum[0][l - 1].text = this.DM.mStringTable.GetStringByID(7257u);
				this.ItemNum[0][l - 1].font = this.Font;
				this.m_Str[l + 2].ClearString();
				this.WonderBra = DataManager.MapDataController.MapWondersInfoTable.GetRecordByIndex((int)((ushort)l));
				if (this.WonderBra.Effect != null)
				{
					for (int m = 0; m < 3; m++)
					{
						this.m_Str[m].ClearString();
						if (this.WonderBra.Effect[m].Effect > 0)
						{
							this.Effects = this.DM.EffectData.GetRecordByKey(this.WonderBra.Effect[m].Effect);
							this.m_Str[m].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.Effects.StringID));
							this.m_Str[m].IntToFormat((long)this.WonderBra.Effect[m].Value, 1, false);
							if (m > 0)
							{
								this.m_Str[m].AppendFormat(this.DM.mStringTable.GetStringByID(9317u));
							}
							else
							{
								this.m_Str[m].AppendFormat(this.DM.mStringTable.GetStringByID(9316u));
							}
							this.m_Str[l + 2].Append(this.m_Str[m]);
						}
					}
				}
				this.ItemNum[0][l - 1].text = this.m_Str[l + 2].ToString();
				this.ItemNum[0][l - 1].SetAllDirty();
				this.ItemNum[0][l - 1].cachedTextGenerator.Invalidate();
				this.ItemsHeight.Add((this.ItemNum[0][l - 1].preferredHeight <= 32f) ? 46f : ((float)Math.Ceiling((double)(this.ItemNum[0][l - 1].preferredHeight / 32f)) * 32f));
			}
		}
		else
		{
			this.ItemTag[0][3].text = this.DM.mStringTable.GetStringByID(9374u);
			this.ItemTag[0][3].font = this.Font;
			this.ItemTag[0][3].transform.localPosition = this.ItemTag[0][2].transform.localPosition - new Vector3(0f, this.ItemTag[0][2].preferredHeight + 20f, 0f);
			sizeDelta = this.ItemTag[0][3].rectTransform.sizeDelta;
			sizeDelta.y = this.ItemTag[0][3].preferredHeight;
			this.ItemTag[0][3].rectTransform.sizeDelta = sizeDelta;
			List<float> itemsHeight6;
			List<float> list6 = itemsHeight6 = this.ItemsHeight;
			int index7 = index2 = 0;
			num = itemsHeight6[index2];
			list6[index7] = num + (this.ItemTag[0][3].preferredHeight + 10f);
			for (int n = 1; n < 6; n++)
			{
				base.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(2).GetComponent<Text>().font = this.Font;
				this.ItemNum[0][n - 1] = base.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(3).GetComponent<Text>();
				this.ItemNum[0][n - 1].text = this.DM.mStringTable.GetStringByID((uint)(n + 9384 - 1));
				this.ItemNum[0][n - 1].font = this.Font;
				this.ItemsHeight.Add((this.ItemNum[0][n - 1].preferredHeight <= 32f) ? 46f : ((float)Math.Ceiling((double)(this.ItemNum[0][n - 1].preferredHeight / 32f)) * 32f));
			}
			this.ItemsHeight.Add(38f);
			this.ItemsHeight.Add(46f);
			for (int num2 = 1; num2 < 6; num2++)
			{
				base.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(2).GetComponent<Text>().font = this.Font;
				this.ItemNum[0][num2 - 1] = base.transform.GetChild(0).GetChild(10).GetChild(6).GetChild(3).GetComponent<Text>();
				this.ItemNum[0][num2 - 1].text = this.DM.mStringTable.GetStringByID((uint)(num2 + 9360));
				this.ItemNum[0][num2 - 1].font = this.Font;
				this.ItemNum[0][num2 - 1].SetAllDirty();
				this.ItemNum[0][num2 - 1].cachedTextGenerator.Invalidate();
				this.ItemsHeight.Add((this.ItemNum[0][num2 - 1].preferredHeight <= 32f) ? 46f : ((float)Math.Ceiling((double)(this.ItemNum[0][num2 - 1].preferredHeight / 32f)) * 32f));
			}
		}
		this.m_scroll = base.transform.GetChild(0).GetChild(9).GetComponent<ScrollPanel>();
		this.m_scroll.IntiScrollPanel(512f, 0f, 0f, this.ItemsHeight, 12, this);
		this.m_panel = new ScrollPanelItem[10];
		this.m_scroll.gameObject.SetActive(true);
	}

	// Token: 0x06002138 RID: 8504 RVA: 0x003F37E4 File Offset: 0x003F19E4
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (DataManager.MapDataController.IsFocusWorldWar())
		{
			item.transform.GetChild(3).gameObject.SetActive(dataIdx == 0);
			item.transform.GetChild(4).gameObject.SetActive(dataIdx == 1 || dataIdx == 9);
			item.transform.GetChild(5).gameObject.SetActive(dataIdx == 2 || dataIdx == 10);
			item.transform.GetChild(6).gameObject.SetActive((dataIdx >= 3 && dataIdx <= 8) || dataIdx > 10);
		}
		else
		{
			item.transform.GetChild(3).gameObject.SetActive(dataIdx == 0);
			item.transform.GetChild(4).gameObject.SetActive(dataIdx == 1 || dataIdx == 8);
			item.transform.GetChild(5).gameObject.SetActive(dataIdx == 2 || dataIdx == 9);
			item.transform.GetChild(6).gameObject.SetActive((dataIdx >= 3 && dataIdx <= 7) || dataIdx >= 10);
		}
		if (dataIdx == 0)
		{
			if (DataManager.MapDataController.IsFocusWorldWar())
			{
				for (int i = 0; i < 3; i++)
				{
					this.ItemTag[panelObjectIdx][i] = item.transform.GetChild(3).GetChild(i).GetComponent<Text>();
					this.ItemTag[panelObjectIdx][i].text = this.DM.mStringTable.GetStringByID((uint)(i + ((this.mapYolk.WonderID <= 0) ? 9995 : 11064)));
				}
			}
			else if (this.mapYolk.WonderID > 0)
			{
				for (int j = 0; j < 4; j++)
				{
					this.ItemTag[panelObjectIdx][j] = item.transform.GetChild(3).GetChild(j).GetComponent<Text>();
					this.ItemTag[panelObjectIdx][j].text = this.DM.mStringTable.GetStringByID((uint)(j + 7253));
				}
				this.ItemTag[panelObjectIdx][4] = item.transform.GetChild(3).GetChild(4).GetComponent<Text>();
				this.ItemTag[panelObjectIdx][4].text = this.DM.mStringTable.GetStringByID(9374u);
			}
			else
			{
				for (int k = 0; k < 3; k++)
				{
					this.ItemTag[panelObjectIdx][k] = item.transform.GetChild(3).GetChild(k).GetComponent<Text>();
					this.ItemTag[panelObjectIdx][k].text = this.DM.mStringTable.GetStringByID((uint)(k + 9355));
				}
				this.ItemTag[panelObjectIdx][3] = item.transform.GetChild(3).GetChild(3).GetComponent<Text>();
				this.ItemTag[panelObjectIdx][3].text = this.DM.mStringTable.GetStringByID(9374u);
			}
		}
		else if (dataIdx == 1)
		{
			this.ItemTag[panelObjectIdx][5] = item.transform.GetChild(4).GetChild(1).GetComponent<Text>();
			this.ItemTag[panelObjectIdx][5].text = this.DM.mStringTable.GetStringByID((!DataManager.MapDataController.IsFocusWorldWar()) ? 9381u : ((this.mapYolk.WonderID <= 0) ? 9998u : 11067u));
			this.ItemTag[panelObjectIdx][5].font = this.Font;
		}
		else if (dataIdx >= 3 && dataIdx <= 8 && this.mapYolk.WonderID > 0 && DataManager.MapDataController.IsFocusWorldWar())
		{
			item.transform.GetChild(6).GetChild(0).gameObject.SetActive(dataIdx % 2 != 0);
			item.transform.GetChild(6).GetChild(1).gameObject.SetActive(dataIdx % 2 == 0);
			this.ItemRow[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(2).GetComponent<Text>();
			this.ItemRow[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID((uint)((dataIdx >= 8) ? 11068 : (dataIdx + 11055)));
			this.ItemNum[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(3).GetComponent<Text>();
			this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID((uint)(dataIdx + 11066));
			this.Join = (RectTransform)item.transform.GetChild(6).transform;
			this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
			this.Join = (RectTransform)item.transform.GetChild(6).GetChild(0).GetChild(0).transform;
			this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
			((RectTransform)item.transform.GetChild(6).GetChild(1).GetChild(0).transform).sizeDelta = this.Join.sizeDelta;
			this.Join = (RectTransform)item.transform.GetChild(6).GetChild(0).GetChild(1).transform;
			this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
			((RectTransform)item.transform.GetChild(6).GetChild(1).GetChild(1).transform).sizeDelta = this.Join.sizeDelta;
		}
		else if (dataIdx == 8)
		{
			if (DataManager.MapDataController.IsFocusWorldWar())
			{
				item.transform.GetChild(6).GetChild(0).gameObject.SetActive(dataIdx % 2 != 0);
				item.transform.GetChild(6).GetChild(1).gameObject.SetActive(dataIdx % 2 == 0);
				if (DataManager.MapDataController.IsFocusWorldWar())
				{
					this.ItemRow[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(2).GetComponent<Text>();
					this.ItemRow[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(11081u);
					this.ItemNum[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(3).GetComponent<Text>();
					this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(11082u);
				}
				this.Join = (RectTransform)item.transform.GetChild(6).transform;
				this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
				this.Join = (RectTransform)item.transform.GetChild(6).GetChild(0).GetChild(0).transform;
				this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
				((RectTransform)item.transform.GetChild(6).GetChild(1).GetChild(0).transform).sizeDelta = this.Join.sizeDelta;
				this.Join = (RectTransform)item.transform.GetChild(6).GetChild(0).GetChild(1).transform;
				this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
				((RectTransform)item.transform.GetChild(6).GetChild(1).GetChild(1).transform).sizeDelta = this.Join.sizeDelta;
			}
			else
			{
				this.ItemTag[panelObjectIdx][5] = item.transform.GetChild(4).GetChild(1).GetComponent<Text>();
				this.ItemTag[panelObjectIdx][5].text = this.DM.mStringTable.GetStringByID((this.mapYolk.WonderID != 0) ? 7249u : 9358u);
				this.ItemTag[panelObjectIdx][5].font = this.Font;
			}
		}
		else if (dataIdx == 2)
		{
			this.ItemTag[panelObjectIdx][6] = item.transform.GetChild(5).GetChild(0).GetComponent<Text>();
			this.ItemTag[panelObjectIdx][6].text = this.DM.mStringTable.GetStringByID((!DataManager.MapDataController.IsFocusWorldWar()) ? 9382u : 9999u);
			this.ItemTag[panelObjectIdx][6].font = this.Font;
			this.ItemTag[panelObjectIdx][7] = item.transform.GetChild(5).GetChild(1).GetComponent<Text>();
			this.ItemTag[panelObjectIdx][7].text = this.DM.mStringTable.GetStringByID((!DataManager.MapDataController.IsFocusWorldWar()) ? 9381u : 9360u);
			this.ItemTag[panelObjectIdx][7].font = this.Font;
		}
		else if (dataIdx == 9)
		{
			this.ItemTag[panelObjectIdx][6] = item.transform.GetChild(5).GetChild(0).GetComponent<Text>();
			this.ItemTag[panelObjectIdx][6].text = this.DM.mStringTable.GetStringByID((this.mapYolk.WonderID != 0) ? 7257u : 9359u);
			this.ItemTag[panelObjectIdx][6].font = this.Font;
			this.ItemTag[panelObjectIdx][7] = item.transform.GetChild(5).GetChild(1).GetComponent<Text>();
			this.ItemTag[panelObjectIdx][7].text = this.DM.mStringTable.GetStringByID((this.mapYolk.WonderID != 0) ? 7258u : 9360u);
			this.ItemTag[panelObjectIdx][7].font = this.Font;
		}
		else if (dataIdx >= 3 && dataIdx <= 7)
		{
			item.transform.GetChild(6).GetChild(0).gameObject.SetActive(dataIdx % 2 != 0);
			item.transform.GetChild(6).GetChild(1).gameObject.SetActive(dataIdx % 2 == 0);
			if (DataManager.MapDataController.IsFocusWorldWar())
			{
				this.ItemRow[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(2).GetComponent<Text>();
				this.ItemRow[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID((uint)(dataIdx + 11023));
				this.ItemNum[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(3).GetComponent<Text>();
				this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID((uint)((dataIdx <= 3) ? 10000 : (dataIdx + 10997)));
			}
			else if (this.mapYolk.WonderID > 0)
			{
				this.ItemRow[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(2).GetComponent<Text>();
				this.ItemRow[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID((uint)(dataIdx + 9381));
				this.ItemNum[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(3).GetComponent<Text>();
				if (dataIdx == 3)
				{
					this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(9391u);
				}
				else if (dataIdx == 4)
				{
					this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(9394u);
				}
				else if (dataIdx == 5)
				{
					this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(9395u);
				}
				else if (dataIdx == 6)
				{
					this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(9396u);
				}
				else
				{
					this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID(9393u);
				}
				this.ItemNum[panelObjectIdx][dataIdx - 3].font = this.Font;
			}
			else
			{
				this.ItemRow[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(2).GetComponent<Text>();
				this.ItemRow[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID((uint)(dataIdx + 9381));
				this.ItemNum[panelObjectIdx][dataIdx - 3] = item.transform.GetChild(6).GetChild(3).GetComponent<Text>();
				this.ItemNum[panelObjectIdx][dataIdx - 3].text = this.DM.mStringTable.GetStringByID((uint)(dataIdx + 9386));
			}
			this.Join = (RectTransform)item.transform.GetChild(6).transform;
			this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
			this.Join = (RectTransform)item.transform.GetChild(6).GetChild(0).GetChild(0).transform;
			this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
			((RectTransform)item.transform.GetChild(6).GetChild(1).GetChild(0).transform).sizeDelta = this.Join.sizeDelta;
			this.Join = (RectTransform)item.transform.GetChild(6).GetChild(0).GetChild(1).transform;
			this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
			((RectTransform)item.transform.GetChild(6).GetChild(1).GetChild(1).transform).sizeDelta = this.Join.sizeDelta;
		}
		else if (dataIdx >= 10)
		{
			item.transform.GetChild(6).GetChild(0).gameObject.SetActive(dataIdx % 2 != 0);
			item.transform.GetChild(6).GetChild(1).gameObject.SetActive(dataIdx % 2 == 0);
			if (this.mapYolk.WonderID > 0)
			{
				this.ItemRow[panelObjectIdx][dataIdx - 10] = item.transform.GetChild(6).GetChild(2).GetComponent<Text>();
				this.ItemRow[panelObjectIdx][dataIdx - 10].text = this.DM.mStringTable.GetStringByID((uint)(dataIdx + 7225));
				this.ItemNum[panelObjectIdx][dataIdx - 10] = item.transform.GetChild(6).GetChild(3).GetComponent<Text>();
				this.ItemNum[panelObjectIdx][dataIdx - 10].text = this.DM.mStringTable.GetStringByID(7257u);
				this.ItemNum[panelObjectIdx][dataIdx - 10].font = this.Font;
				this.m_Str[dataIdx].ClearString();
				this.WonderBra = DataManager.MapDataController.MapWondersInfoTable.GetRecordByIndex((int)((ushort)(dataIdx - 9)));
				if (this.WonderBra.Effect != null)
				{
					for (int l = 0; l < 3; l++)
					{
						this.m_Str[l].ClearString();
						if (this.WonderBra.Effect[l].Effect > 0)
						{
							this.Effects = this.DM.EffectData.GetRecordByKey(this.WonderBra.Effect[l].Effect);
							this.m_Str[l].StringToFormat(this.DM.mStringTable.GetStringByID((uint)this.Effects.StringID));
							this.m_Str[l].FloatToFormat((float)this.WonderBra.Effect[l].Value / 100f, -1, true);
							if (l > 0)
							{
								this.m_Str[l].AppendFormat(this.DM.mStringTable.GetStringByID(9317u));
							}
							else
							{
								this.m_Str[l].AppendFormat(this.DM.mStringTable.GetStringByID(9316u));
							}
							this.m_Str[dataIdx].Append(this.m_Str[l]);
						}
					}
				}
				this.ItemNum[panelObjectIdx][dataIdx - 10].text = this.m_Str[dataIdx].ToString();
				this.ItemNum[panelObjectIdx][dataIdx - 10].SetAllDirty();
				this.ItemNum[panelObjectIdx][dataIdx - 10].cachedTextGenerator.Invalidate();
			}
			else
			{
				this.ItemRow[panelObjectIdx][dataIdx - 10] = item.transform.GetChild(6).GetChild(2).GetComponent<Text>();
				this.ItemRow[panelObjectIdx][dataIdx - 10].text = this.DM.mStringTable.GetStringByID((uint)(dataIdx + 9314));
				this.ItemNum[panelObjectIdx][dataIdx - 10] = item.transform.GetChild(6).GetChild(3).GetComponent<Text>();
				this.ItemNum[panelObjectIdx][dataIdx - 10].text = this.DM.mStringTable.GetStringByID((uint)(dataIdx + 9351));
			}
			this.Join = (RectTransform)item.transform.GetChild(6).transform;
			this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
			this.Join = (RectTransform)item.transform.GetChild(6).GetChild(0).GetChild(0).transform;
			this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
			((RectTransform)item.transform.GetChild(6).GetChild(1).GetChild(0).transform).sizeDelta = this.Join.sizeDelta;
			this.Join = (RectTransform)item.transform.GetChild(6).GetChild(0).GetChild(1).transform;
			this.Join.sizeDelta = new Vector2(this.Join.sizeDelta.x, this.ItemsHeight[dataIdx]);
			((RectTransform)item.transform.GetChild(6).GetChild(1).GetChild(1).transform).sizeDelta = this.Join.sizeDelta;
		}
	}

	// Token: 0x06002139 RID: 8505 RVA: 0x003F4C30 File Offset: 0x003F2E30
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x0600213A RID: 8506 RVA: 0x003F4C34 File Offset: 0x003F2E34
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
	}

	// Token: 0x0600213B RID: 8507 RVA: 0x003F4C38 File Offset: 0x003F2E38
	public override void OnClose()
	{
		for (int i = 0; i < 20; i++)
		{
			if (this.m_Str[i] != null)
			{
				StringManager.Instance.DeSpawnString(this.m_Str[i]);
			}
		}
	}

	// Token: 0x0600213C RID: 8508 RVA: 0x003F4C78 File Offset: 0x003F2E78
	public override void UpdateUI(int arg1, int arg2)
	{
	}

	// Token: 0x0600213D RID: 8509 RVA: 0x003F4C7C File Offset: 0x003F2E7C
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x0600213E RID: 8510 RVA: 0x003F4C80 File Offset: 0x003F2E80
	public override void UpdateNetwork(byte[] meg)
	{
		base.UpdateNetwork(meg);
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews != NetworkNews.Refresh_Alliance)
		{
			if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
			{
				if (this.m_descript != null && this.m_descript.enabled)
				{
					this.m_descript.enabled = false;
					this.m_descript.enabled = true;
				}
				for (int i = 0; i < 20; i++)
				{
					int num = 0;
					while (i < 9)
					{
						if (this.ItemTag[i][num] != null && this.ItemTag[i][num].enabled)
						{
							this.ItemTag[i][num].enabled = false;
							this.ItemTag[i][num].enabled = true;
						}
						if (this.ItemRow[i][num] != null && this.ItemRow[i][num].enabled)
						{
							this.ItemRow[i][num].enabled = false;
							this.ItemRow[i][num].enabled = true;
						}
						if (this.ItemNum[i][num] != null && this.ItemNum[i][num].enabled)
						{
							this.ItemNum[i][num].enabled = false;
							this.ItemNum[i][num].enabled = true;
						}
						i++;
					}
				}
			}
		}
	}

	// Token: 0x0600213F RID: 8511 RVA: 0x003F4DF4 File Offset: 0x003F2FF4
	public void OnButtonClick(UIButton sender)
	{
		if (this.door)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x040068B9 RID: 26809
	protected Door door;

	// Token: 0x040068BA RID: 26810
	protected Text m_limit;

	// Token: 0x040068BB RID: 26811
	protected Text m_title;

	// Token: 0x040068BC RID: 26812
	protected Text m_error;

	// Token: 0x040068BD RID: 26813
	protected Text m_filter;

	// Token: 0x040068BE RID: 26814
	protected Text m_search;

	// Token: 0x040068BF RID: 26815
	protected Text m_button;

	// Token: 0x040068C0 RID: 26816
	protected Text m_content;

	// Token: 0x040068C1 RID: 26817
	protected Text m_descript;

	// Token: 0x040068C2 RID: 26818
	protected Image m_PageBack;

	// Token: 0x040068C3 RID: 26819
	protected InputField s_input;

	// Token: 0x040068C4 RID: 26820
	protected InputField m_input;

	// Token: 0x040068C5 RID: 26821
	protected ScrollPanel m_scroll;

	// Token: 0x040068C6 RID: 26822
	protected ScrollPanelItem[] m_panel;

	// Token: 0x040068C7 RID: 26823
	protected UISpritesArray USArray;

	// Token: 0x040068C8 RID: 26824
	protected Transform Transformer;

	// Token: 0x040068C9 RID: 26825
	protected Transform Tick;

	// Token: 0x040068CA RID: 26826
	protected Transform Invalid;

	// Token: 0x040068CB RID: 26827
	protected Transform TagTick;

	// Token: 0x040068CC RID: 26828
	protected Transform TagInvalid;

	// Token: 0x040068CD RID: 26829
	protected RectTransform Join;

	// Token: 0x040068CE RID: 26830
	protected RectTransform NameTick;

	// Token: 0x040068CF RID: 26831
	protected RectTransform NameInvalid;

	// Token: 0x040068D0 RID: 26832
	protected RectTransform SearchRT;

	// Token: 0x040068D1 RID: 26833
	protected RectTransform SearchList;

	// Token: 0x040068D2 RID: 26834
	protected RectTransform ApplyList;

	// Token: 0x040068D3 RID: 26835
	protected Vector3 SearchPosition;

	// Token: 0x040068D4 RID: 26836
	protected Vector2 SearchSize;

	// Token: 0x040068D5 RID: 26837
	protected Text Name;

	// Token: 0x040068D6 RID: 26838
	protected Text Tag;

	// Token: 0x040068D7 RID: 26839
	protected Text[][] ItemTag = new Text[20][];

	// Token: 0x040068D8 RID: 26840
	protected Text[][] ItemRow = new Text[20][];

	// Token: 0x040068D9 RID: 26841
	protected Text[][] ItemNum = new Text[20][];

	// Token: 0x040068DA RID: 26842
	protected CString[] m_Str = new CString[20];

	// Token: 0x040068DB RID: 26843
	protected WondersInfoTbl WonderBra;

	// Token: 0x040068DC RID: 26844
	protected Effect Effects;

	// Token: 0x040068DD RID: 26845
	protected float TeaTime;

	// Token: 0x040068DE RID: 26846
	public static float CheckTime;

	// Token: 0x040068DF RID: 26847
	public static float Scrolling;

	// Token: 0x040068E0 RID: 26848
	public static long Proceeding;

	// Token: 0x040068E1 RID: 26849
	public static long Pending;

	// Token: 0x040068E2 RID: 26850
	public static byte Pulling;

	// Token: 0x040068E3 RID: 26851
	public static byte Tagging;

	// Token: 0x040068E4 RID: 26852
	public static byte Naming;

	// Token: 0x040068E5 RID: 26853
	public static bool Clearing;

	// Token: 0x040068E6 RID: 26854
	public static bool Shooting;

	// Token: 0x040068E7 RID: 26855
	public static int Positioning;

	// Token: 0x040068E8 RID: 26856
	public static Protocol Checking;

	// Token: 0x040068E9 RID: 26857
	public static Protocol Incoming;

	// Token: 0x040068EA RID: 26858
	public static string Text;

	// Token: 0x040068EB RID: 26859
	public static string pendingText;

	// Token: 0x040068EC RID: 26860
	public static string FilterName;

	// Token: 0x040068ED RID: 26861
	public static string ValidName;

	// Token: 0x040068EE RID: 26862
	public static string ValidTag;

	// Token: 0x040068EF RID: 26863
	public static string SeekName;

	// Token: 0x040068F0 RID: 26864
	public static string SearchName;

	// Token: 0x040068F1 RID: 26865
	public static string SearchLang;

	// Token: 0x040068F2 RID: 26866
	public static byte GenuineLang;

	// Token: 0x040068F3 RID: 26867
	public static byte GenuineName;

	// Token: 0x040068F4 RID: 26868
	public static byte GenuineTag;

	// Token: 0x040068F5 RID: 26869
	public static byte SetRequest;

	// Token: 0x040068F6 RID: 26870
	public static byte FilterIdx;

	// Token: 0x040068F7 RID: 26871
	public static byte SearchIdx;

	// Token: 0x040068F8 RID: 26872
	public static byte SeekKind;

	// Token: 0x040068F9 RID: 26873
	public static byte SeekLang;

	// Token: 0x040068FA RID: 26874
	public static int SearchNum;

	// Token: 0x040068FB RID: 26875
	public static int SearchPage;

	// Token: 0x040068FC RID: 26876
	public static AllianceSearch[] Search;

	// Token: 0x040068FD RID: 26877
	public DataManager DM = DataManager.Instance;

	// Token: 0x040068FE RID: 26878
	public Font Font = GUIManager.Instance.GetTTFFont();

	// Token: 0x040068FF RID: 26879
	public StringBuilder Path = new StringBuilder();

	// Token: 0x04006900 RID: 26880
	private List<float> ItemsHeight = new List<float>();

	// Token: 0x04006901 RID: 26881
	private MapPoint nowMapPoint;

	// Token: 0x04006902 RID: 26882
	private MapYolk mapYolk;
}
