using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020004E8 RID: 1256
public class UIArmyInfo : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001909 RID: 6409 RVA: 0x002A1CDC File Offset: 0x0029FEDC
	public override void OnOpen(int arg1, int arg2)
	{
		if (arg1 == 1)
		{
			this.UIType = eArmyUIType.eHideArmyMod;
		}
		else
		{
			this.UIType = eArmyUIType.eTroopArmyMod;
		}
		this.m_Mat = GUIManager.Instance.AddSpriteAsset("UI_armypic");
		Font ttffont = GUIManager.Instance.GetTTFFont();
		this.m_Data = new List<sArmyData>();
		this.door = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
		this.m_SpArray = base.transform.GetComponent<UISpritesArray>();
		this.m_EmptyStr = StringManager.Instance.SpawnString(30);
		this.m_CheckMsgStr = StringManager.Instance.SpawnString(30);
		this.m_EmptyStr.ClearString();
		this.m_CheckMsgStr.ClearString();
		this.m_tmptext[this.mTextCount] = base.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		if (this.UIType == eArmyUIType.eTroopArmyMod)
		{
			this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(534u);
		}
		else
		{
			this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(9046u);
		}
		this.mTextCount++;
		UIButton component = base.transform.GetChild(1).GetChild(1).GetComponent<UIButton>();
		component.m_BtnID1 = 101;
		component.m_Handler = this;
		Transform child = base.transform.GetChild(4);
		this.m_tmptext[this.mTextCount] = child.GetChild(1).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		this.mTextCount++;
		this.m_tmptext[this.mTextCount] = child.GetChild(2).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		this.mTextCount++;
		Transform child2 = child.GetChild(3);
		this.m_tmptext[this.mTextCount] = child2.GetChild(1).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		this.mTextCount++;
		this.m_tmptext[this.mTextCount] = child2.GetChild(2).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		this.mTextCount++;
		child2 = child.GetChild(4);
		this.m_tmptext[this.mTextCount] = child2.GetChild(3).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		this.mTextCount++;
		this.m_tmptext[this.mTextCount] = child2.GetChild(4).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		this.mTextCount++;
		child2 = child.GetChild(5);
		this.m_tmptext[this.mTextCount] = child2.GetChild(1).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		this.mTextCount++;
		this.m_tmptext[this.mTextCount] = child2.GetChild(2).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		this.mTextCount++;
		child2 = child.GetChild(8);
		this.m_tmptext[this.mTextCount] = child2.GetChild(0).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		this.mTextCount++;
		child2 = child.GetChild(9);
		this.m_tmptext[this.mTextCount] = child2.GetChild(0).GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		this.mTextCount++;
		child2 = child.GetChild(10);
		this.m_tmptext[this.mTextCount] = child2.GetComponent<UIText>();
		this.m_tmptext[this.mTextCount].font = ttffont;
		this.mTextCount++;
		if (GUIManager.Instance.IsArabic)
		{
			child.GetChild(7).gameObject.AddComponent<ArabicItemTextureRot>();
		}
		this.m_ScrollPanel = base.transform.GetChild(2).GetComponent<ScrollPanel>();
		this.SetData();
		List<float> list = new List<float>();
		for (int i = 0; i < this.m_Data.Count; i++)
		{
			list.Add(140f);
		}
		this.m_ScrollPanel.IntiScrollPanel(517f, 0f, 10f, list, 5, this);
		Image component2 = base.transform.GetChild(5).GetComponent<Image>();
		component2.sprite = this.door.LoadSprite("UI_main_close_base");
		component2.material = this.door.LoadMaterial();
		if (GUIManager.Instance.bOpenOnIPhoneX && component2)
		{
			component2.enabled = false;
		}
		component = base.transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 100;
		component.image.sprite = this.door.LoadSprite("UI_main_close");
		component.image.material = this.door.LoadMaterial();
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
	}

	// Token: 0x0600190A RID: 6410 RVA: 0x002A226C File Offset: 0x002A046C
	public override void OnClose()
	{
		for (int i = 0; i < 5; i++)
		{
			if (this.m_ItemObj[i] != null)
			{
				if (this.m_ItemObj[i].m_Text1Str != null)
				{
					StringManager.Instance.DeSpawnString(this.m_ItemObj[i].m_Text1Str);
				}
				if (this.m_ItemObj[i].m_Text2Str != null)
				{
					StringManager.Instance.DeSpawnString(this.m_ItemObj[i].m_Text2Str);
				}
				if (this.m_ItemObj[i].m_Slider1TitleStr != null)
				{
					StringManager.Instance.DeSpawnString(this.m_ItemObj[i].m_Slider1TitleStr);
				}
				if (this.m_ItemObj[i].m_Slider1TimeStr != null)
				{
					StringManager.Instance.DeSpawnString(this.m_ItemObj[i].m_Slider1TimeStr);
				}
				if (this.m_ItemObj[i].m_TempTime != null)
				{
					StringManager.Instance.DeSpawnString(this.m_ItemObj[i].m_TempTime);
				}
				if (this.m_ItemObj[i].m_IconText != null)
				{
					StringManager.Instance.DeSpawnString(this.m_ItemObj[i].m_IconText);
				}
				this.m_ItemObj[i].m_Text1Str = null;
				this.m_ItemObj[i].m_Text2Str = null;
				this.m_ItemObj[i].m_Slider1TitleStr = null;
				this.m_ItemObj[i].m_Slider1TimeStr = null;
			}
		}
		if (this.m_EmptyStr != null)
		{
			StringManager.Instance.DeSpawnString(this.m_EmptyStr);
		}
		if (this.m_CheckMsgStr != null)
		{
			StringManager.Instance.DeSpawnString(this.m_CheckMsgStr);
		}
		GUIManager.Instance.RemoveSpriteAsset("UI_armypic");
		GUIManager.Instance.CloseOKCancelBox();
	}

	// Token: 0x0600190B RID: 6411 RVA: 0x002A2420 File Offset: 0x002A0620
	public override void UpdateUI(int arg1, int arg2)
	{
		if (this.UIType == eArmyUIType.eHideArmyMod)
		{
			if (arg1 == 1)
			{
				this.door.CloseMenu(false);
			}
			else if (arg1 == 2)
			{
				this.SetData();
				List<float> list = new List<float>();
				for (int i = 0; i < this.m_Data.Count; i++)
				{
					list.Add(140f);
				}
				if (this.m_Data.Count == 0)
				{
					this.door.CloseMenu(false);
				}
				else
				{
					this.m_ScrollPanel.AddNewDataHeight(list, false, true);
				}
			}
		}
		else if (this.UIType == eArmyUIType.eTroopArmyMod)
		{
			this.SetData();
			List<float> list2 = new List<float>();
			for (int j = 0; j < this.m_Data.Count; j++)
			{
				list2.Add(140f);
			}
			if (this.m_Data.Count == 0)
			{
				this.door.CloseMenu(false);
			}
			else
			{
				this.m_ScrollPanel.AddNewDataHeight(list2, false, true);
			}
		}
	}

	// Token: 0x0600190C RID: 6412 RVA: 0x002A252C File Offset: 0x002A072C
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x0600190D RID: 6413 RVA: 0x002A2530 File Offset: 0x002A0730
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (bOK)
		{
			if (arg1 == 0)
			{
				DataManager.Instance.sendCancelRally();
			}
			else if (arg1 == 1)
			{
				DataManager.Instance.TroopeTakeBack(arg2, EMarchEventType.EMET_InforceStanby);
			}
			else if (arg1 == 2)
			{
				DataManager.Instance.TroopeTakeBack(arg2, EMarchEventType.EMET_Camp);
			}
			else if (arg1 == 3)
			{
				AmbushManager.Instance.SendAmbushReturn((byte)arg2);
			}
		}
	}

	// Token: 0x0600190E RID: 6414 RVA: 0x002A259C File Offset: 0x002A079C
	private void Update()
	{
		this.m_TimeTick += Time.deltaTime;
		if (this.m_TimeTick >= this.m_ResTextChangeTime * 2f)
		{
			this.m_TimeTick = 0f;
			if (this.m_ResTextType == 0)
			{
				this.m_ResTextType = 1;
			}
			else
			{
				this.m_ResTextType = 0;
			}
		}
		if (this.m_TimeTick >= this.m_ResTextChangeTime)
		{
			this.colorA = Mathf.Lerp(0f, 2f, (this.m_ResTextChangeTime * 2f - this.m_TimeTick) / this.m_ResTextChangeTime);
		}
		else
		{
			this.colorA = Mathf.Lerp(0f, 2f, this.m_TimeTick / this.m_ResTextChangeTime);
		}
		if (this.m_Data.Count > 0)
		{
			for (int i = 0; i < 5; i++)
			{
				if (this.m_ItemObj[i] != null)
				{
					int dataIdx = this.m_ItemObj[i].m_dataIdx;
					if (dataIdx < this.m_Data.Count)
					{
						if (this.UIType == eArmyUIType.eHideArmyMod)
						{
							this.CalculateSlider_HideArmy(0);
						}
						else if (this.m_Data[dataIdx].m_DataType == eArmyDataType.LordReturn)
						{
							this.CalculateSlider_Lord(i);
						}
						else if (this.m_ItemObj[i].m_dataIdx != -1)
						{
							if (this.m_ItemObj[i].m_SliderType == 3)
							{
								this.CalculateResSlider(this.m_ItemObj[i].m_dataIdx, i);
							}
							else if (this.m_ItemObj[i].m_SliderType == 2)
							{
								this.CalculateOtherResSlider(this.m_ItemObj[i].m_dataIdx, i);
							}
							else if (this.m_ItemObj[i].m_SliderType == 1)
							{
								this.CalculateSlider(this.m_ItemObj[i].m_dataIdx, i);
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0600190F RID: 6415 RVA: 0x002A2784 File Offset: 0x002A0984
	private void SetScrollItem(int dataIdx, int panelObjectIdx, GameObject item)
	{
		UIButton[] array = new UIButton[4];
		int index = this.m_Data[dataIdx].m_Index;
		bool enabled = false;
		ushort leaderID = DataManager.Instance.GetLeaderID();
		for (int i = 0; i < this.DM.MarchEventData[index].HeroID.Length; i++)
		{
			if (leaderID == this.DM.MarchEventData[index].HeroID[i])
			{
				enabled = true;
				break;
			}
		}
		item.transform.GetChild(11).GetComponent<Image>().enabled = enabled;
		ushort zoneID = this.DM.MarchEventData[index].Point.zoneID;
		byte pointID = this.DM.MarchEventData[index].Point.pointID;
		POINT_KIND pointKind = DataManager.Instance.MarchEventData[index].PointKind;
		if (this.m_ItemObj[panelObjectIdx] == null)
		{
			this.m_ItemObj[panelObjectIdx] = new ArmyInfoObect();
		}
		if (this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon == null)
		{
			this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon = item.transform.GetChild(0).GetComponent<Image>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1 = item.transform.GetChild(1).GetComponent<UIText>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2 = item.transform.GetChild(2).GetComponent<UIText>();
			Transform child = item.transform.GetChild(3);
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value = child.GetChild(0).GetComponent<Image>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title = child.GetChild(1).GetComponent<UIText>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time = child.GetChild(2).GetComponent<UIText>();
			child = item.transform.GetChild(4);
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value1 = child.GetChild(0).GetComponent<Image>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value2 = child.GetChild(1).GetComponent<Image>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Title = child.GetChild(2).GetComponent<UIText>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Time = child.GetChild(3).GetComponent<UIText>();
			child = item.transform.GetChild(5);
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Value = child.GetChild(0).GetComponent<Image>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Title = child.GetChild(1).GetComponent<UIText>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time = child.GetChild(2).GetComponent<UIText>();
			this.m_ItemObj[panelObjectIdx].m_Slider1 = item.transform.GetChild(3);
			this.m_ItemObj[panelObjectIdx].m_Slider2 = item.transform.GetChild(4);
			this.m_ItemObj[panelObjectIdx].m_Slider3 = item.transform.GetChild(5);
			child = item.transform.GetChild(10);
			this.m_ItemObj[panelObjectIdx].m_ScrollIconText = child.GetComponent<UIText>();
		}
		this.m_ItemObj[panelObjectIdx].PointKind = this.DM.MarchEventData[index].PointKind;
		this.m_ItemObj[panelObjectIdx].m_Type = this.DM.MarchEventData[index].Type;
		this.m_ItemObj[panelObjectIdx].bHost = this.DM.MarchEventData[index].bRallyHost;
		array[0] = item.transform.GetChild(6).GetComponent<UIButton>();
		array[0].m_Handler = this;
		array[0].m_BtnID1 = dataIdx;
		array[0].m_BtnID2 = 6;
		array[1] = item.transform.GetChild(7).GetComponent<UIButton>();
		array[1].m_Handler = this;
		array[1].m_BtnID1 = dataIdx;
		array[1].m_BtnID2 = 7;
		array[2] = item.transform.GetChild(8).GetComponent<UIButton>();
		array[2].m_Handler = this;
		array[2].m_BtnID1 = dataIdx;
		array[2].m_BtnID2 = 8;
		UIText component = item.transform.GetChild(8).GetChild(0).GetComponent<UIText>();
		component.text = this.DM.mStringTable.GetStringByID(547u);
		array[3] = item.transform.GetChild(9).GetComponent<UIButton>();
		array[3].m_Handler = this;
		array[3].m_BtnID1 = dataIdx;
		array[3].m_BtnID2 = 9;
		component = item.transform.GetChild(9).GetChild(0).GetComponent<UIText>();
		if (this.m_ItemObj[panelObjectIdx].m_Type >= EMarchEventType.EMET_RallyStanby && this.m_ItemObj[panelObjectIdx].m_Type <= EMarchEventType.EMET_DeliverMarching)
		{
			if (((this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyStanby || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyMarching || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyAttack) && this.m_ItemObj[panelObjectIdx].bHost == 1) || this.m_ItemObj[panelObjectIdx].bHost == 4)
			{
				component.text = this.DM.mStringTable.GetStringByID(541u);
			}
			else
			{
				component.text = this.DM.mStringTable.GetStringByID(548u);
			}
		}
		else
		{
			component.text = this.DM.mStringTable.GetStringByID(538u);
		}
		if (this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_Gathering || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_Camp || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_InforceStanby || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyStanby)
		{
			array[1].gameObject.SetActive(false);
		}
		else
		{
			array[1].gameObject.SetActive(true);
		}
		if (GameConstants.IsMarchReturnOrRetreat(this.m_ItemObj[panelObjectIdx].m_Type) || ((this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyStanby || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyMarching || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyAttack) && (this.m_ItemObj[panelObjectIdx].bHost == 0 || this.m_ItemObj[panelObjectIdx].bHost == 3)))
		{
			array[3].gameObject.SetActive(false);
			array[2].transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(288f, 0f);
		}
		else
		{
			array[3].gameObject.SetActive(true);
			array[2].transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(288f, 34.5f);
		}
		if (this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_ScoutMarching || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_ScoutReturn || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_DeliverMarching || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_DeliverReturn)
		{
			array[0].gameObject.SetActive(false);
			this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.enabled = false;
		}
		else
		{
			array[0].gameObject.SetActive(true);
			this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.enabled = true;
		}
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon.sprite = this.GetIconSprite(this.m_ItemObj[panelObjectIdx].m_Type, this.m_ItemObj[panelObjectIdx].bHost);
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon.material = this.m_Mat;
		this.SetMpaPointName(this.m_ItemObj[panelObjectIdx].m_Text1Str, index);
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.text = this.m_ItemObj[panelObjectIdx].m_Text1Str.ToString();
		if (this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyReturn)
		{
			this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.gameObject.SetActive(false);
		}
		else
		{
			this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.gameObject.SetActive(true);
		}
		this.SetArmyNumName(this.m_ItemObj[panelObjectIdx].m_Text2Str, index);
		if (this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_HitMonsterMarching || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_HitMonsterReturn || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_HitMonsterRetreat)
		{
			this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.gameObject.SetActive(false);
		}
		else
		{
			this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.gameObject.SetActive(true);
		}
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.text = this.m_ItemObj[panelObjectIdx].m_Text2Str.ToString();
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.SetAllDirty();
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.cachedTextGenerator.Invalidate();
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.SetAllDirty();
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.cachedTextGenerator.Invalidate();
		if ((this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_Camp || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_CampReturn) && this.m_ItemObj[panelObjectIdx].PointKind == POINT_KIND.PK_YOLK)
		{
			byte desPointLevel = this.DM.MarchEventData[dataIdx].DesPointLevel;
			this.SetIconText(this.m_ItemObj[panelObjectIdx].m_ScrollIconText, this.m_ItemObj[panelObjectIdx].m_Type, this.m_ItemObj[panelObjectIdx].PointKind, desPointLevel, this.m_ItemObj[panelObjectIdx].m_IconText, this.m_ItemObj[panelObjectIdx].bHost);
		}
		else
		{
			this.SetIconText(this.m_ItemObj[panelObjectIdx].m_ScrollIconText, this.m_ItemObj[panelObjectIdx].m_Type, this.m_ItemObj[panelObjectIdx].PointKind, 0, null, this.m_ItemObj[panelObjectIdx].bHost);
		}
		this.m_ItemObj[panelObjectIdx].m_dataIdx = dataIdx;
		if (this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_Camp || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_InforceStanby)
		{
			this.m_ItemObj[panelObjectIdx].m_Slider1.gameObject.SetActive(false);
			this.m_ItemObj[panelObjectIdx].m_Slider2.gameObject.SetActive(false);
			this.m_ItemObj[panelObjectIdx].m_Slider3.gameObject.SetActive(false);
			this.m_ItemObj[panelObjectIdx].m_SliderType = 3;
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.rectTransform.anchoredPosition = new Vector2(104.13f, 0f);
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.alignment = TextAnchor.MiddleRight;
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.rectTransform.sizeDelta = new Vector2(142.15f, 29f);
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.rectTransform.anchoredPosition = new Vector2(80.6f, 0.5f);
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.alignment = TextAnchor.MiddleLeft;
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.rectTransform.sizeDelta = new Vector2(129.3f, 29f);
			this.m_ItemObj[panelObjectIdx].m_MaxOverload = 0u;
		}
		else
		{
			if (pointKind == POINT_KIND.PK_CRYSTAL && this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_Gathering)
			{
				this.m_ItemObj[panelObjectIdx].m_Slider1.gameObject.SetActive(false);
				this.m_ItemObj[panelObjectIdx].m_Slider2.gameObject.SetActive(true);
				this.m_ItemObj[panelObjectIdx].m_Slider3.gameObject.SetActive(true);
				this.m_ItemObj[panelObjectIdx].m_SliderType = 3;
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.m_EmptyStr.ToString();
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.rectTransform.anchoredPosition = new Vector2(0f, 0f);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.alignment = TextAnchor.MiddleCenter;
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.rectTransform.sizeDelta = new Vector2(360f, 29f);
			}
			else if (pointKind >= POINT_KIND.PK_FOOD && pointKind <= POINT_KIND.PK_GOLD && this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_Gathering)
			{
				this.m_ItemObj[panelObjectIdx].m_Slider1.gameObject.SetActive(true);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.enabled = false;
				this.m_ItemObj[panelObjectIdx].m_Slider2.gameObject.SetActive(false);
				this.m_ItemObj[panelObjectIdx].m_Slider3.gameObject.SetActive(false);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.m_EmptyStr.ToString();
				this.m_ItemObj[panelObjectIdx].m_SliderType = 2;
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.rectTransform.anchoredPosition = new Vector2(0f, 0f);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.alignment = TextAnchor.MiddleCenter;
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.rectTransform.sizeDelta = new Vector2(350f, 29f);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.rectTransform.anchoredPosition = new Vector2(80.6f, 0.5f);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.alignment = TextAnchor.MiddleLeft;
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.rectTransform.sizeDelta = new Vector2(129.3f, 29f);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value.sprite = this.m_SpArray.GetSprite(1);
			}
			else
			{
				this.m_ItemObj[panelObjectIdx].m_Slider1.gameObject.SetActive(true);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.enabled = true;
				this.m_ItemObj[panelObjectIdx].m_Slider2.gameObject.SetActive(false);
				this.m_ItemObj[panelObjectIdx].m_Slider3.gameObject.SetActive(false);
				this.m_ItemObj[panelObjectIdx].m_SliderType = 1;
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.DM.mStringTable.GetStringByID(546u);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.rectTransform.anchoredPosition = new Vector2(-104.13f, 0f);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.alignment = TextAnchor.MiddleRight;
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.rectTransform.sizeDelta = new Vector2(142.15f, 29f);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.rectTransform.anchoredPosition = new Vector2(80.6f, 0.5f);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.alignment = TextAnchor.MiddleLeft;
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.rectTransform.sizeDelta = new Vector2(129.3f, 29f);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value.sprite = this.m_SpArray.GetSprite(0);
			}
			this.m_ItemObj[panelObjectIdx].m_ResStartTime = DataManager.Instance.MarchEventTime[index].BeginTime;
			long num = (long)((ulong)DataManager.Instance.MarchEventTime[index].RequireTime);
			this.m_ItemObj[panelObjectIdx].m_MaxOverload = DataManager.Instance.MarchEventData[index].MaxOverLoad;
			this.m_ItemObj[panelObjectIdx].m_ResRate = this.m_ItemObj[panelObjectIdx].m_MaxOverload / (float)num;
		}
	}

	// Token: 0x06001910 RID: 6416 RVA: 0x002A372C File Offset: 0x002A192C
	private void SetScrollItem_Lord(int dataIdx, int panelObjectIdx, GameObject item)
	{
		UIButton[] array = new UIButton[4];
		if (this.m_ItemObj[panelObjectIdx] == null)
		{
			this.m_ItemObj[panelObjectIdx] = new ArmyInfoObect();
		}
		if (this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon == null)
		{
			this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon = item.transform.GetChild(0).GetComponent<Image>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1 = item.transform.GetChild(1).GetComponent<UIText>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2 = item.transform.GetChild(2).GetComponent<UIText>();
			Transform child = item.transform.GetChild(3);
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value = child.GetChild(0).GetComponent<Image>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title = child.GetChild(1).GetComponent<UIText>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time = child.GetChild(2).GetComponent<UIText>();
			child = item.transform.GetChild(4);
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value1 = child.GetChild(0).GetComponent<Image>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value2 = child.GetChild(1).GetComponent<Image>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Title = child.GetChild(2).GetComponent<UIText>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Time = child.GetChild(3).GetComponent<UIText>();
			child = item.transform.GetChild(5);
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Value = child.GetChild(0).GetComponent<Image>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Title = child.GetChild(1).GetComponent<UIText>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time = child.GetChild(2).GetComponent<UIText>();
			this.m_ItemObj[panelObjectIdx].m_Slider1 = item.transform.GetChild(3);
			this.m_ItemObj[panelObjectIdx].m_Slider2 = item.transform.GetChild(4);
			this.m_ItemObj[panelObjectIdx].m_Slider3 = item.transform.GetChild(5);
			child = item.transform.GetChild(10);
			this.m_ItemObj[panelObjectIdx].m_ScrollIconText = child.GetComponent<UIText>();
		}
		array[0] = item.transform.GetChild(6).GetComponent<UIButton>();
		array[0].m_Handler = this;
		array[0].m_BtnID1 = dataIdx;
		array[0].m_BtnID2 = 6;
		array[1] = item.transform.GetChild(7).GetComponent<UIButton>();
		array[1].m_Handler = this;
		array[1].m_BtnID1 = dataIdx;
		array[1].m_BtnID2 = 7;
		array[2] = item.transform.GetChild(8).GetComponent<UIButton>();
		array[2].m_Handler = this;
		array[2].m_BtnID1 = dataIdx;
		array[2].m_BtnID2 = 8;
		array[2].transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(288f, 0f);
		UIText component = item.transform.GetChild(8).GetChild(0).GetComponent<UIText>();
		component.text = this.DM.mStringTable.GetStringByID(547u);
		array[3] = item.transform.GetChild(9).GetComponent<UIButton>();
		array[3].m_Handler = this;
		array[3].m_BtnID1 = dataIdx;
		array[3].m_BtnID2 = 9;
		array[0].gameObject.SetActive(false);
		array[1].gameObject.SetActive(true);
		array[2].gameObject.SetActive(true);
		array[3].gameObject.SetActive(false);
		this.SetLordPointName(this.m_ItemObj[panelObjectIdx].m_Text1Str);
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.text = string.Empty;
		this.m_ItemObj[panelObjectIdx].m_Type = EMarchEventType.EMET_LordReturn;
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon.sprite = this.GetIconSprite(this.m_ItemObj[panelObjectIdx].m_Type, this.m_ItemObj[panelObjectIdx].bHost);
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon.material = this.m_Mat;
		this.SetIconText(this.m_ItemObj[panelObjectIdx].m_ScrollIconText, this.m_ItemObj[panelObjectIdx].m_Type, this.m_ItemObj[panelObjectIdx].PointKind, 0, null, this.m_ItemObj[panelObjectIdx].bHost);
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.text = this.m_ItemObj[panelObjectIdx].m_Text1Str.ToString();
		this.m_ItemObj[panelObjectIdx].m_ScrollIconText.SetAllDirty();
		this.m_ItemObj[panelObjectIdx].m_dataIdx = dataIdx;
	}

	// Token: 0x06001911 RID: 6417 RVA: 0x002A3BA8 File Offset: 0x002A1DA8
	private void SetScrollItem_HideArmy(int dataIdx, int panelObjectIdx, GameObject item)
	{
		UIButton[] array = new UIButton[4];
		if (this.m_ItemObj[panelObjectIdx] == null)
		{
			this.m_ItemObj[panelObjectIdx] = new ArmyInfoObect();
		}
		if (this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon == null)
		{
			this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon = item.transform.GetChild(0).GetComponent<Image>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1 = item.transform.GetChild(1).GetComponent<UIText>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2 = item.transform.GetChild(2).GetComponent<UIText>();
			Transform child = item.transform.GetChild(3);
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value = child.GetChild(0).GetComponent<Image>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title = child.GetChild(1).GetComponent<UIText>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time = child.GetChild(2).GetComponent<UIText>();
			child = item.transform.GetChild(4);
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value1 = child.GetChild(0).GetComponent<Image>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value2 = child.GetChild(1).GetComponent<Image>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Title = child.GetChild(2).GetComponent<UIText>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Time = child.GetChild(3).GetComponent<UIText>();
			child = item.transform.GetChild(5);
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Value = child.GetChild(0).GetComponent<Image>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Title = child.GetChild(1).GetComponent<UIText>();
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time = child.GetChild(2).GetComponent<UIText>();
			this.m_ItemObj[panelObjectIdx].m_Slider1 = item.transform.GetChild(3);
			this.m_ItemObj[panelObjectIdx].m_Slider2 = item.transform.GetChild(4);
			this.m_ItemObj[panelObjectIdx].m_Slider3 = item.transform.GetChild(5);
			child = item.transform.GetChild(10);
			this.m_ItemObj[panelObjectIdx].m_ScrollIconText = child.GetComponent<UIText>();
		}
		item.transform.GetChild(11).GetComponent<Image>().enabled = HideArmyManager.Instance.IsLordInShelter();
		array[0] = item.transform.GetChild(6).GetComponent<UIButton>();
		array[0].m_Handler = this;
		array[0].m_BtnID1 = dataIdx;
		array[0].m_BtnID2 = 6;
		array[1] = item.transform.GetChild(7).GetComponent<UIButton>();
		array[1].m_Handler = this;
		array[1].m_BtnID1 = dataIdx;
		array[1].m_BtnID2 = 7;
		array[2] = item.transform.GetChild(8).GetComponent<UIButton>();
		array[2].m_Handler = this;
		array[2].m_BtnID1 = dataIdx;
		array[2].m_BtnID2 = 8;
		UIText component = item.transform.GetChild(8).GetChild(0).GetComponent<UIText>();
		array[3] = item.transform.GetChild(9).GetComponent<UIButton>();
		component = item.transform.GetChild(9).GetChild(0).GetComponent<UIText>();
		component.text = this.DM.mStringTable.GetStringByID(548u);
		array[3].m_Handler = this;
		array[3].m_BtnID1 = dataIdx;
		array[3].m_BtnID2 = 9;
		array[3].transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(288f, 0f);
		array[0].gameObject.SetActive(true);
		array[1].gameObject.SetActive(false);
		array[2].gameObject.SetActive(false);
		array[3].gameObject.SetActive(true);
		component.text = this.DM.mStringTable.GetStringByID(548u);
		this.SetHiedArmyPointName(this.m_ItemObj[panelObjectIdx].m_Text1Str);
		this.SetHideArmyNumName(this.m_ItemObj[panelObjectIdx].m_Text2Str);
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.text = this.m_ItemObj[panelObjectIdx].m_Text2Str.ToString();
		this.m_ItemObj[panelObjectIdx].m_Type = EMarchEventType.EMET_Camp;
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon.sprite = this.GetIconSprite(this.m_ItemObj[panelObjectIdx].m_Type, this.m_ItemObj[panelObjectIdx].bHost);
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon.material = this.m_Mat;
		this.m_ItemObj[panelObjectIdx].m_ScrollIconText.text = this.DM.mStringTable.GetStringByID(8590u);
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.text = this.m_ItemObj[panelObjectIdx].m_Text1Str.ToString();
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.SetAllDirty();
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.cachedTextGenerator.Invalidate();
		this.m_ItemObj[panelObjectIdx].m_ScrollIconText.SetAllDirty();
		this.m_ItemObj[panelObjectIdx].m_ScrollIconText.cachedTextGenerator.Invalidate();
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.SetAllDirty();
		this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.cachedTextGenerator.Invalidate();
		this.m_ItemObj[panelObjectIdx].m_dataIdx = dataIdx;
	}

	// Token: 0x06001912 RID: 6418 RVA: 0x002A40EC File Offset: 0x002A22EC
	private void SetMpaPointName(CString str, int dataIdx)
	{
		StringManager instance = StringManager.Instance;
		PointCode point = this.DM.MarchEventData[dataIdx].Point;
		str.ClearString();
		EMarchEventType type = this.DM.MarchEventData[dataIdx].Type;
		POINT_KIND pointKind = this.DM.MarchEventData[dataIdx].PointKind;
		byte bRallyHost = this.DM.MarchEventData[dataIdx].bRallyHost;
		byte desPointLevel = this.DM.MarchEventData[dataIdx].DesPointLevel;
		Vector2 vector;
		if (pointKind == POINT_KIND.PK_YOLK)
		{
			vector = DataManager.MapDataController.GetYolkPos((ushort)desPointLevel, DataManager.MapDataController.FocusKingdomID);
		}
		else
		{
			vector = GameConstants.getTileMapPosbyPointCode(point.zoneID, point.pointID);
		}
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.IntToFormat((long)desPointLevel, 1, false);
		cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021u));
		if (type < EMarchEventType.EMET_AttackReturn)
		{
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(544u));
		}
		else
		{
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(543u));
		}
		switch (pointKind)
		{
		case POINT_KIND.PK_NONE:
		case POINT_KIND.PK_NPC:
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(4579u));
			instance.FloatToFormat(vector.x, -1, true);
			instance.FloatToFormat(vector.y, -1, true);
			str.AppendFormat("{0} : {1}(X : {2} Y : {3})");
			break;
		case POINT_KIND.PK_FOOD:
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(6031u));
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(32u));
			instance.IntToFormat((long)desPointLevel, 1, false);
			instance.FloatToFormat(vector.x, -1, true);
			instance.FloatToFormat(vector.y, -1, true);
			str.AppendFormat("{0} : {1} {2}{3}(X : {4} Y : {5})");
			break;
		case POINT_KIND.PK_STONE:
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(6028u));
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(32u));
			instance.IntToFormat((long)desPointLevel, 1, false);
			instance.FloatToFormat(vector.x, -1, true);
			instance.FloatToFormat(vector.y, -1, true);
			str.AppendFormat("{0} : {1} {2}{3}(X : {4} Y : {5})");
			break;
		case POINT_KIND.PK_IRON:
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(6030u));
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(32u));
			instance.IntToFormat((long)desPointLevel, 1, false);
			instance.FloatToFormat(vector.x, -1, true);
			instance.FloatToFormat(vector.y, -1, true);
			str.AppendFormat("{0} : {1} {2}{3}(X : {4} Y : {5})");
			break;
		case POINT_KIND.PK_WOOD:
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(6029u));
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(32u));
			instance.IntToFormat((long)desPointLevel, 1, false);
			instance.FloatToFormat(vector.x, -1, true);
			instance.FloatToFormat(vector.y, -1, true);
			str.AppendFormat("{0} : {1} {2}{3}(X : {4} Y : {5})");
			break;
		case POINT_KIND.PK_GOLD:
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(6033u));
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(32u));
			instance.IntToFormat((long)desPointLevel, 1, false);
			instance.FloatToFormat(vector.x, -1, true);
			instance.FloatToFormat(vector.y, -1, true);
			str.AppendFormat("{0} : {1} {2}{3}(X : {4} Y : {5})");
			break;
		case POINT_KIND.PK_CRYSTAL:
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(6032u));
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(32u));
			instance.IntToFormat((long)desPointLevel, 1, false);
			instance.FloatToFormat(vector.x, -1, true);
			instance.FloatToFormat(vector.y, -1, true);
			str.AppendFormat("{0} : {1} {2}{3}(X : {4} Y : {5})");
			break;
		case POINT_KIND.PK_CITY:
			if ((bRallyHost == 3 && type != EMarchEventType.EMET_RallyMarching && type != EMarchEventType.EMET_RallyStanby) || bRallyHost == 4)
			{
				instance.StringToFormat(cstring);
				instance.FloatToFormat(vector.x, -1, true);
				instance.FloatToFormat(vector.y, -1, true);
				str.AppendFormat("{0} : {1}(X : {2} Y : {3})");
			}
			else
			{
				instance.StringToFormat(this.DM.MarchEventData[dataIdx].DesPlayerName);
				instance.FloatToFormat(vector.x, -1, true);
				instance.FloatToFormat(vector.y, -1, true);
				str.AppendFormat("{0} : {1}(X : {2} Y : {3})");
			}
			break;
		case POINT_KIND.PK_CAMP:
			instance.StringToFormat(this.DM.mStringTable.GetStringByID(4540u));
			instance.FloatToFormat(vector.x, -1, true);
			instance.FloatToFormat(vector.y, -1, true);
			str.AppendFormat("{0} : {1}(X : {2} Y : {3})");
			break;
		case POINT_KIND.PK_YOLK:
			instance.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)desPointLevel, DataManager.MapDataController.OtherKingdomData.kingdomID));
			instance.FloatToFormat(vector.x, -1, true);
			instance.FloatToFormat(vector.y, -1, true);
			str.AppendFormat("{0} : {1}(X : {2} Y : {3})");
			break;
		}
	}

	// Token: 0x06001913 RID: 6419 RVA: 0x002A46A4 File Offset: 0x002A28A4
	private void SetLordPointName(CString str)
	{
		StringManager instance = StringManager.Instance;
		PointCode pointCode;
		GameConstants.MapIDToPointCode(this.DM.beCaptured.MapID, out pointCode.zoneID, out pointCode.pointID);
		Vector2 tileMapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(pointCode.zoneID, pointCode.pointID);
		str.ClearString();
		instance.StringToFormat(this.DM.mStringTable.GetStringByID(543u));
		instance.StringToFormat(this.DM.beCaptured.name);
		instance.FloatToFormat(tileMapPosbyPointCode.x, -1, true);
		instance.FloatToFormat(tileMapPosbyPointCode.y, -1, true);
		str.AppendFormat("{0} : {1}(X : {2} Y : {3})");
	}

	// Token: 0x06001914 RID: 6420 RVA: 0x002A4754 File Offset: 0x002A2954
	private void SetHiedArmyPointName(CString str)
	{
		StringManager instance = StringManager.Instance;
		PointCode pointCode;
		GameConstants.MapIDToPointCode(this.DM.beCaptured.MapID, out pointCode.zoneID, out pointCode.pointID);
		Vector2 tileMapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(pointCode.zoneID, pointCode.pointID);
		str.ClearString();
		instance.StringToFormat(this.DM.mStringTable.GetStringByID(544u));
		instance.StringToFormat(this.DM.mStringTable.GetStringByID(9046u));
		str.AppendFormat("{0} : {1}");
	}

	// Token: 0x06001915 RID: 6421 RVA: 0x002A47E8 File Offset: 0x002A29E8
	private void SetArmyNumName(CString str, int dataIdx)
	{
		str.ClearString();
		long num = 0L;
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				num += (long)((ulong)this.DM.MarchEventData[dataIdx].TroopData[i][j]);
			}
		}
		StringManager.Instance.StringToFormat(this.DM.mStringTable.GetStringByID(545u));
		StringManager.Instance.IntToFormat(num, 1, true);
		str.AppendFormat("{0} : {1}");
	}

	// Token: 0x06001916 RID: 6422 RVA: 0x002A487C File Offset: 0x002A2A7C
	private void SetHideArmyNumName(CString str)
	{
		str.ClearString();
		StringManager.Instance.StringToFormat(this.DM.mStringTable.GetStringByID(545u));
		StringManager.Instance.IntToFormat(HideArmyManager.Instance.GetTotalHideArmy(), 1, true);
		str.AppendFormat("{0} : {1}");
	}

	// Token: 0x06001917 RID: 6423 RVA: 0x002A48D4 File Offset: 0x002A2AD4
	private void SetIconText(UIText text, EMarchEventType Type, POINT_KIND PointKind, byte wonderId = 0, CString cStr = null, byte bRallyHost = 0)
	{
		switch (Type)
		{
		case EMarchEventType.EMET_Camp:
			if (PointKind == POINT_KIND.PK_YOLK)
			{
				if (cStr != null)
				{
					cStr.ClearString();
					if (wonderId == 0)
					{
						cStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
					}
					else if (DataManager.MapDataController.OtherKingdomData.kingdomID != ActivityManager.Instance.KOWKingdomID)
					{
						cStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309u));
					}
					else
					{
						cStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
					}
					cStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9301u));
					text.text = cStr.ToString();
					text.SetAllDirty();
					text.cachedTextGenerator.Invalidate();
				}
			}
			else if (bRallyHost == 1)
			{
				text.text = DataManager.Instance.mStringTable.GetStringByID(9733u);
			}
			else
			{
				text.text = DataManager.Instance.mStringTable.GetStringByID(553u);
			}
			break;
		case EMarchEventType.EMET_Gathering:
			text.text = DataManager.Instance.mStringTable.GetStringByID(556u);
			break;
		case EMarchEventType.EMET_InforceStanby:
			text.text = DataManager.Instance.mStringTable.GetStringByID(560u);
			break;
		case EMarchEventType.EMET_RallyStanby:
			text.text = DataManager.Instance.mStringTable.GetStringByID(565u);
			break;
		case EMarchEventType.EMET_AttackMarching:
			text.text = DataManager.Instance.mStringTable.GetStringByID(549u);
			break;
		case EMarchEventType.EMET_CampMarching:
			if (bRallyHost == 1)
			{
				text.text = DataManager.Instance.mStringTable.GetStringByID(9734u);
			}
			else if (bRallyHost == 2)
			{
				text.text = DataManager.Instance.mStringTable.GetStringByID(9908u);
			}
			else
			{
				text.text = DataManager.Instance.mStringTable.GetStringByID(551u);
			}
			break;
		case EMarchEventType.EMET_GatherMarching:
			text.text = DataManager.Instance.mStringTable.GetStringByID(554u);
			break;
		case EMarchEventType.EMET_ScoutMarching:
			text.text = DataManager.Instance.mStringTable.GetStringByID(561u);
			break;
		case EMarchEventType.EMET_HitMonsterMarching:
			text.text = DataManager.Instance.mStringTable.GetStringByID(8345u);
			break;
		case EMarchEventType.EMET_InforceMarching:
			text.text = DataManager.Instance.mStringTable.GetStringByID(558u);
			break;
		case EMarchEventType.EMET_RallyMarching:
			text.text = DataManager.Instance.mStringTable.GetStringByID(567u);
			break;
		case EMarchEventType.EMET_RallyAttack:
			text.text = DataManager.Instance.mStringTable.GetStringByID(569u);
			break;
		case EMarchEventType.EMET_DeliverMarching:
			text.text = DataManager.Instance.mStringTable.GetStringByID(563u);
			break;
		case EMarchEventType.EMET_AttackReturn:
			text.text = DataManager.Instance.mStringTable.GetStringByID(550u);
			break;
		case EMarchEventType.EMET_CampReturn:
			if (PointKind == POINT_KIND.PK_YOLK)
			{
				if (cStr != null)
				{
					cStr.ClearString();
					if (wonderId == 0)
					{
						cStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
					}
					else if (DataManager.MapDataController.OtherKingdomData.kingdomID != ActivityManager.Instance.KOWKingdomID)
					{
						cStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309u));
					}
					else
					{
						cStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308u));
					}
					cStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9302u));
					text.text = cStr.ToString();
					text.SetAllDirty();
					text.cachedTextGenerator.Invalidate();
				}
			}
			else if (bRallyHost == 1)
			{
				text.text = DataManager.Instance.mStringTable.GetStringByID(9735u);
			}
			else
			{
				text.text = DataManager.Instance.mStringTable.GetStringByID(552u);
			}
			break;
		case EMarchEventType.EMET_GatherReturn:
			text.text = DataManager.Instance.mStringTable.GetStringByID(555u);
			break;
		case EMarchEventType.EMET_RallyReturn:
			text.text = DataManager.Instance.mStringTable.GetStringByID(568u);
			break;
		case EMarchEventType.EMET_ScoutReturn:
			text.text = DataManager.Instance.mStringTable.GetStringByID(562u);
			break;
		case EMarchEventType.EMET_HitMonsterReturn:
		case EMarchEventType.EMET_HitMonsterRetreat:
			text.text = DataManager.Instance.mStringTable.GetStringByID(8346u);
			break;
		case EMarchEventType.EMET_InfroceReturn:
			text.text = DataManager.Instance.mStringTable.GetStringByID(559u);
			break;
		case EMarchEventType.EMET_DeliverReturn:
			text.text = DataManager.Instance.mStringTable.GetStringByID(564u);
			break;
		case EMarchEventType.EMET_LordReturn:
			text.text = DataManager.Instance.mStringTable.GetStringByID(864u);
			break;
		case EMarchEventType.EMET_AttackRetreat:
			text.text = DataManager.Instance.mStringTable.GetStringByID(550u);
			break;
		case EMarchEventType.EMET_CampRetreat:
			if (bRallyHost == 1)
			{
				text.text = DataManager.Instance.mStringTable.GetStringByID(9735u);
			}
			else
			{
				text.text = DataManager.Instance.mStringTable.GetStringByID(552u);
			}
			break;
		case EMarchEventType.EMET_GatherRetreat:
			text.text = DataManager.Instance.mStringTable.GetStringByID(555u);
			break;
		case EMarchEventType.EMET_RallyRetreat:
			text.text = DataManager.Instance.mStringTable.GetStringByID(568u);
			break;
		case EMarchEventType.EMET_FooballMarching:
			text.text = DataManager.Instance.mStringTable.GetStringByID(11241u);
			break;
		case EMarchEventType.EMET_FooballReturn:
		case EMarchEventType.EMET_FooballRetreat:
			text.text = DataManager.Instance.mStringTable.GetStringByID(11242u);
			break;
		}
		Vector2 sizeDelta = text.rectTransform.sizeDelta;
		sizeDelta.x = ((text.preferredWidth <= 160f) ? text.preferredWidth : 160f);
		text.rectTransform.sizeDelta = sizeDelta;
	}

	// Token: 0x06001918 RID: 6424 RVA: 0x002A4F7C File Offset: 0x002A317C
	private int GetBtnState(EMarchEventType Type)
	{
		return 2;
	}

	// Token: 0x06001919 RID: 6425 RVA: 0x002A4F80 File Offset: 0x002A3180
	private Sprite GetIconSprite(EMarchEventType Type, byte bRallyHost = 0)
	{
		switch (Type)
		{
		case EMarchEventType.EMET_Camp:
			if (bRallyHost == 1)
			{
				return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_12");
			}
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_05");
		case EMarchEventType.EMET_Gathering:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_05");
		case EMarchEventType.EMET_InforceStanby:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_01");
		case EMarchEventType.EMET_RallyStanby:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_06");
		case EMarchEventType.EMET_AttackMarching:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_03");
		case EMarchEventType.EMET_CampMarching:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_03");
		case EMarchEventType.EMET_GatherMarching:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_03");
		case EMarchEventType.EMET_ScoutMarching:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_02");
		case EMarchEventType.EMET_HitMonsterMarching:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_09");
		case EMarchEventType.EMET_InforceMarching:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_03");
		case EMarchEventType.EMET_RallyMarching:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_03");
		case EMarchEventType.EMET_RallyAttack:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_07");
		case EMarchEventType.EMET_DeliverMarching:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_08");
		case EMarchEventType.EMET_AttackReturn:
		case EMarchEventType.EMET_AttackRetreat:
		case EMarchEventType.EMET_CampRetreat:
		case EMarchEventType.EMET_GatherRetreat:
		case EMarchEventType.EMET_RallyRetreat:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_04");
		case EMarchEventType.EMET_CampReturn:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_04");
		case EMarchEventType.EMET_GatherReturn:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_04");
		case EMarchEventType.EMET_RallyReturn:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_04");
		case EMarchEventType.EMET_ScoutReturn:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_04");
		case EMarchEventType.EMET_HitMonsterReturn:
		case EMarchEventType.EMET_HitMonsterRetreat:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_10");
		case EMarchEventType.EMET_InfroceReturn:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_04");
		case EMarchEventType.EMET_DeliverReturn:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_04");
		case EMarchEventType.EMET_LordReturn:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_11");
		case EMarchEventType.EMET_FooballMarching:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_03");
		case EMarchEventType.EMET_FooballReturn:
		case EMarchEventType.EMET_FooballRetreat:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_04");
		default:
			return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_01");
		}
	}

	// Token: 0x0600191A RID: 6426 RVA: 0x002A523C File Offset: 0x002A343C
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (dataIdx >= 0 && dataIdx < this.m_Data.Count)
		{
			if (this.UIType == eArmyUIType.eHideArmyMod)
			{
				this.SetScrollItem_HideArmy(dataIdx, panelObjectIdx, item);
			}
			else if (this.m_Data[dataIdx].m_DataType == eArmyDataType.LordReturn)
			{
				this.SetScrollItem_Lord(dataIdx, panelObjectIdx, item);
			}
			else
			{
				this.SetScrollItem(dataIdx, panelObjectIdx, item);
			}
		}
	}

	// Token: 0x0600191B RID: 6427 RVA: 0x002A52AC File Offset: 0x002A34AC
	public void CalculateSlider(int dataIdx, int panelObjectIdx)
	{
		if (dataIdx >= this.m_Data.Count)
		{
			return;
		}
		int index = this.m_Data[dataIdx].m_Index;
		if (index >= this.DM.MarchEventTime.Length)
		{
			return;
		}
		long beginTime = this.DM.MarchEventTime[index].BeginTime;
		uint requireTime = this.DM.MarchEventTime[index].RequireTime;
		float num = (float)(NetworkManager.ServerTime - (double)beginTime) / requireTime;
		num = Mathf.Clamp(num, 0f, 1f);
		long num2 = (long)((ulong)requireTime - (ulong)(this.DM.ServerTime - beginTime));
		num2 = (long)Mathf.Clamp((float)num2, 0f, requireTime);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value.rectTransform.sizeDelta = new Vector2(338f * num, 17f);
		this.SetTimeText(this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr, num2);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.text = this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.ToString();
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.SetAllDirty();
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.cachedTextGenerator.Invalidate();
		if (this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyStanby)
		{
			if (num >= 0.999f)
			{
				if (this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.gameObject.activeSelf)
				{
					this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.gameObject.SetActive(false);
					this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.DM.mStringTable.GetStringByID(4909u);
					this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.SetAllDirty();
					this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.cachedTextGenerator.Invalidate();
				}
			}
			else if (!this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.gameObject.activeSelf)
			{
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.gameObject.SetActive(true);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.DM.mStringTable.GetStringByID(546u);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.SetAllDirty();
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.cachedTextGenerator.Invalidate();
			}
		}
		else if (!this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.gameObject.activeSelf)
		{
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.gameObject.SetActive(true);
		}
	}

	// Token: 0x0600191C RID: 6428 RVA: 0x002A5558 File Offset: 0x002A3758
	public void CalculateOtherResSlider(int dataIdx, int panelObjectIdx)
	{
		long resStartTime = this.m_ItemObj[panelObjectIdx].m_ResStartTime;
		float resRate = this.m_ItemObj[panelObjectIdx].m_ResRate;
		uint maxOverload = this.m_ItemObj[panelObjectIdx].m_MaxOverload;
		uint num = 0u;
		if (NetworkManager.ServerTime >= (double)resStartTime)
		{
			num = (uint)((NetworkManager.ServerTime - (double)resStartTime) * (double)resRate);
		}
		uint sec = (uint)(maxOverload / resRate) - (uint)(num / resRate);
		float num2 = num / maxOverload;
		num2 = Mathf.Clamp(num2, 0f, 1f);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value.rectTransform.sizeDelta = new Vector2(338f * num2, 17f);
		this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.ClearString();
		this.m_ItemObj[panelObjectIdx].m_TempTime.ClearString();
		if (this.m_ResTextType == 0)
		{
			this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(557u));
			this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.IntToFormat((long)((ulong)num), 1, true);
			this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.IntToFormat((long)((ulong)maxOverload), 1, true);
			this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.AppendFormat("{0} : {1} / {2}");
		}
		else
		{
			GameConstants.GetTimeString(this.m_ItemObj[panelObjectIdx].m_TempTime, sec, false, false, true, false, true);
			this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(817u));
			this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.StringToFormat(this.m_ItemObj[panelObjectIdx].m_TempTime);
			this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.AppendFormat("{0} : {1} ");
		}
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.color = new Color(1f, 1f, 1f, this.colorA);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.ToString();
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.SetAllDirty();
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.cachedTextGenerator.Invalidate();
	}

	// Token: 0x0600191D RID: 6429 RVA: 0x002A5794 File Offset: 0x002A3994
	public void CalculateResSlider(int dataIdx, int panelObjectIdx)
	{
		long resStartTime = this.m_ItemObj[panelObjectIdx].m_ResStartTime;
		float resRate = this.m_ItemObj[panelObjectIdx].m_ResRate;
		uint num = this.m_ItemObj[panelObjectIdx].m_MaxOverload;
		float num2 = 0f;
		if (NetworkManager.ServerTime >= (double)resStartTime)
		{
			if (NetworkManager.ServerTime >= (double)resStartTime)
			{
				num2 = (float)((NetworkManager.ServerTime - (double)resStartTime) * (double)resRate);
			}
			float num3 = (float)((double)(num / resRate) - (NetworkManager.ServerTime - (double)resStartTime));
			float num4 = num2 / num;
			if (num4 > 1f)
			{
				num4 = 1f;
			}
			if (num <= 0u)
			{
				num = 1u;
			}
			double num5 = num / (double)resRate;
			float num6 = (float)(num5 / num);
			float fillAmount = (float)((NetworkManager.ServerTime - (double)resStartTime) % (double)num6) / num6;
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value1.fillAmount = fillAmount;
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value2.fillAmount = fillAmount;
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Value.rectTransform.sizeDelta = new Vector2(338f * num4, 17f);
			this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.ClearString();
			this.m_ItemObj[panelObjectIdx].m_TempTime.ClearString();
			if (num2 < num)
			{
				if (this.m_ResTextType == 0)
				{
					this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(691u));
					this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.IntToFormat((long)((ulong)((uint)num2)), 1, true);
					this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.IntToFormat((long)((ulong)num), 1, true);
					this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.AppendFormat("{0} {1} / {2}");
				}
				else
				{
					GameConstants.GetTimeString(this.m_ItemObj[panelObjectIdx].m_TempTime, (uint)num3, false, false, true, false, true);
					this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(817u));
					this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.StringToFormat(this.m_ItemObj[panelObjectIdx].m_TempTime);
					this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.AppendFormat("{0} : {1} ");
				}
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.color = new Color(1f, 1f, 1f, this.colorA);
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.text = this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.ToString();
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.SetAllDirty();
				this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.cachedTextGenerator.Invalidate();
			}
		}
	}

	// Token: 0x0600191E RID: 6430 RVA: 0x002A5A48 File Offset: 0x002A3C48
	public void CalculateSlider_Lord(int panelObjectIdx)
	{
		long startActionTime = this.DM.beCaptured.StartActionTime;
		uint totalTime = this.DM.beCaptured.TotalTime;
		if (totalTime == 0u)
		{
			return;
		}
		float num = (float)(NetworkManager.ServerTime - (double)startActionTime) / totalTime;
		num = Mathf.Clamp(num, 0f, 1f);
		long num2 = (long)((ulong)totalTime - (ulong)(this.DM.ServerTime - startActionTime));
		num2 = (long)Mathf.Clamp((float)num2, 0f, totalTime);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value.rectTransform.sizeDelta = new Vector2(338f * num, 17f);
		this.SetTimeText(this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr, num2);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.text = this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.ToString();
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.SetAllDirty();
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.cachedTextGenerator.Invalidate();
		if (!this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.gameObject.activeSelf)
		{
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.gameObject.SetActive(true);
		}
		this.m_ItemObj[panelObjectIdx].m_Slider1.gameObject.SetActive(true);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.enabled = true;
		this.m_ItemObj[panelObjectIdx].m_Slider2.gameObject.SetActive(false);
		this.m_ItemObj[panelObjectIdx].m_Slider3.gameObject.SetActive(false);
		this.m_ItemObj[panelObjectIdx].m_SliderType = 1;
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.DM.mStringTable.GetStringByID(546u);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.rectTransform.anchoredPosition = new Vector2(-104.13f, 0f);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.alignment = TextAnchor.MiddleRight;
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.rectTransform.sizeDelta = new Vector2(142.15f, 29f);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.rectTransform.anchoredPosition = new Vector2(80.6f, 0.5f);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.alignment = TextAnchor.MiddleLeft;
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.rectTransform.sizeDelta = new Vector2(129.3f, 29f);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value.sprite = this.m_SpArray.GetSprite(0);
	}

	// Token: 0x0600191F RID: 6431 RVA: 0x002A5CE8 File Offset: 0x002A3EE8
	public void CalculateSlider_HideArmy(int panelObjectIdx)
	{
		TimeEventDataType shelterTime = HideArmyManager.Instance.GetShelterTime();
		long beginTime = shelterTime.BeginTime;
		uint requireTime = shelterTime.RequireTime;
		if (requireTime == 0u)
		{
			return;
		}
		float num = (float)(NetworkManager.ServerTime - (double)beginTime) / requireTime;
		num = Mathf.Clamp(num, 0f, 1f);
		long num2 = (long)((ulong)requireTime - (ulong)(this.DM.ServerTime - beginTime));
		num2 = (long)Mathf.Clamp((float)num2, 0f, requireTime);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value.rectTransform.sizeDelta = new Vector2(338f * num, 17f);
		this.SetTimeText(this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr, num2);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.text = this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.ToString();
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.SetAllDirty();
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.cachedTextGenerator.Invalidate();
		if (!this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.gameObject.activeSelf)
		{
			this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.gameObject.SetActive(true);
		}
		this.m_ItemObj[panelObjectIdx].m_Slider1.gameObject.SetActive(true);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.enabled = true;
		this.m_ItemObj[panelObjectIdx].m_Slider2.gameObject.SetActive(false);
		this.m_ItemObj[panelObjectIdx].m_Slider3.gameObject.SetActive(false);
		this.m_ItemObj[panelObjectIdx].m_SliderType = 2;
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.DM.mStringTable.GetStringByID(8591u);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.rectTransform.anchoredPosition = new Vector2(-104.13f, 0f);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.alignment = TextAnchor.MiddleRight;
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.rectTransform.sizeDelta = new Vector2(142.15f, 29f);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.rectTransform.anchoredPosition = new Vector2(80.6f, 0.5f);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.alignment = TextAnchor.MiddleLeft;
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.rectTransform.sizeDelta = new Vector2(129.3f, 29f);
		this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value.sprite = this.m_SpArray.GetSprite(1);
	}

	// Token: 0x06001920 RID: 6432 RVA: 0x002A5F88 File Offset: 0x002A4188
	public void SetTimeText(CString str, long time)
	{
		int num = (int)time % 60;
		int num2 = (int)(time / 60L) % 60;
		int num3 = (int)(time % 86400L) / 3600;
		int num4 = (int)time / 86400;
		if (num4 > 0)
		{
			StringManager.Instance.IntToFormat((long)num4, 1, false);
			StringManager.Instance.IntToFormat((long)num3, 2, false);
			StringManager.Instance.IntToFormat((long)num2, 2, false);
			StringManager.Instance.IntToFormat((long)num, 2, false);
			str.ClearString();
			str.AppendFormat("{0}:{1}:{2}:{3}");
		}
		else if (num3 > 0)
		{
			StringManager.Instance.IntToFormat((long)num3, 1, false);
			StringManager.Instance.IntToFormat((long)num2, 2, false);
			StringManager.Instance.IntToFormat((long)num, 2, false);
			str.ClearString();
			str.AppendFormat("{0}:{1}:{2}");
		}
		else
		{
			StringManager.Instance.IntToFormat((long)num2, 2, false);
			StringManager.Instance.IntToFormat((long)num, 2, false);
			str.ClearString();
			str.AppendFormat("{0}:{1}");
		}
	}

	// Token: 0x06001921 RID: 6433 RVA: 0x002A6090 File Offset: 0x002A4290
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001922 RID: 6434 RVA: 0x002A6094 File Offset: 0x002A4294
	public void OnButtonClick(UIButton sender)
	{
		if (this.door && sender.m_BtnID1 >= 0 && sender.m_BtnID1 <= 7)
		{
			if (sender.m_BtnID2 == 6)
			{
				if (this.UIType == eArmyUIType.eHideArmyMod)
				{
					this.door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 6, 0, false);
				}
				else if (sender.m_BtnID1 < this.m_Data.Count && sender.m_BtnID1 >= 0)
				{
					this.door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 1, this.m_Data[sender.m_BtnID1].m_Index, false);
				}
			}
			if (sender.m_BtnID2 == 7 && sender.m_BtnID1 < this.m_Data.Count && sender.m_BtnID1 >= 0)
			{
				if (this.m_Data[sender.m_BtnID1].m_DataType == eArmyDataType.LordReturn)
				{
					this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 30, false);
				}
				else
				{
					int arg = this.m_Data[sender.m_BtnID1].m_Index + 2;
					this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, arg, false);
				}
			}
			if (sender.m_BtnID2 == 8 && sender.m_BtnID1 < this.m_Data.Count)
			{
				if (this.m_Data[sender.m_BtnID1].m_DataType == eArmyDataType.LordReturn)
				{
					this.door.GoToGroup(8, 0, true);
				}
				else
				{
					this.door.GoToGroup(this.m_Data[sender.m_BtnID1].m_Index, 0, true);
				}
			}
			if (sender.m_BtnID2 == 9)
			{
				if (this.UIType == eArmyUIType.eHideArmyMod)
				{
					HideArmyManager.Instance.SendReleaseShelterTroop();
				}
				else if (this.UIType == eArmyUIType.eTroopArmyMod)
				{
					int index = this.m_Data[sender.m_BtnID1].m_Index;
					if ((this.DM.MarchEventData[index].bRallyHost == 1 || this.DM.MarchEventData[index].bRallyHost == 4) && (this.DM.MarchEventData[index].Type == EMarchEventType.EMET_RallyStanby || this.DM.MarchEventData[index].Type == EMarchEventType.EMET_RallyMarching || this.DM.MarchEventData[index].Type == EMarchEventType.EMET_RallyAttack))
					{
						GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4975u), this.DM.mStringTable.GetStringByID(4976u), 0, 0, this.DM.mStringTable.GetStringByID(4977u), this.DM.mStringTable.GetStringByID(4978u));
					}
					else if (this.DM.MarchEventData[index].Type >= EMarchEventType.EMET_Standby && this.DM.MarchEventData[index].Type <= EMarchEventType.EMET_RallyStanby)
					{
						int num = GameConstants.PointCodeToMapID(this.DM.MarchEventData[index].Point.zoneID, this.DM.MarchEventData[index].Point.pointID);
						if (this.DM.MarchEventData[index].Type == EMarchEventType.EMET_InforceStanby)
						{
							GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(4844u), this.DM.mStringTable.GetStringByID(4845u), 1, num, this.DM.mStringTable.GetStringByID(4846u), this.DM.mStringTable.GetStringByID(4847u));
						}
						else if (this.DM.MarchEventData[index].PointKind == POINT_KIND.PK_YOLK && this.DM.MarchEventData[index].Type == EMarchEventType.EMET_Camp)
						{
							this.m_CheckMsgStr.ClearString();
							CString cstring = StringManager.Instance.StaticString1024();
							this.m_CheckMsgStr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort)this.DM.MarchEventData[index].DesPointLevel, DataManager.MapDataController.FocusKingdomID));
							this.m_CheckMsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8572u));
							GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(8571u), this.m_CheckMsgStr.ToString(), 2, num, this.DM.mStringTable.GetStringByID(4846u), this.DM.mStringTable.GetStringByID(4847u));
						}
						else if (this.DM.MarchEventData[index].IsAmbushCamp())
						{
							GUIManager.Instance.OpenOKCancelBox(this, this.DM.mStringTable.GetStringByID(9736u), this.DM.mStringTable.GetStringByID(9737u), 3, index, this.DM.mStringTable.GetStringByID(4842u), this.DM.mStringTable.GetStringByID(4843u));
						}
						else
						{
							DataManager.Instance.TroopeTakeBack(num, this.DM.MarchEventData[index].Type);
						}
					}
					else if (GameConstants.IsMarchDeparture(this.DM.MarchEventData[index].Type))
					{
						DataManager.Instance.TroopeTakeBack((byte)index);
					}
				}
			}
			if (sender.m_BtnID2 == 10)
			{
			}
		}
		else if (sender.m_BtnID1 == 100)
		{
			this.door.CloseMenu(false);
		}
	}

	// Token: 0x06001923 RID: 6435 RVA: 0x002A668C File Offset: 0x002A488C
	private void SetData()
	{
		this.m_Data.Clear();
		if (this.UIType == eArmyUIType.eTroopArmyMod)
		{
			if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
			{
				sArmyData item = default(sArmyData);
				item.m_DataType = eArmyDataType.LordReturn;
				this.m_Data.Add(item);
			}
			for (int i = 0; i < 8; i++)
			{
				if (this.DM.MarchEventData[i].Type != EMarchEventType.EMET_Standby)
				{
					sArmyData item = default(sArmyData);
					item.m_DataType = eArmyDataType.MarchEvent;
					item.m_Index = i;
					this.m_Data.Add(item);
				}
			}
		}
		else
		{
			sArmyData item = default(sArmyData);
			item.m_DataType = eArmyDataType.HideArmy;
			this.m_Data.Add(item);
		}
	}

	// Token: 0x06001924 RID: 6436 RVA: 0x002A6754 File Offset: 0x002A4954
	private uint GetMaxOverload(int _MapPointID, float _rate)
	{
		Vector2 tileMapPosbySpriteID = GameConstants.getTileMapPosbySpriteID(_MapPointID);
		uint result = 0u;
		for (int i = 0; i < (int)DataManager.Instance.MaxMarchEventNum; i++)
		{
			if (DataManager.Instance.MarchEventData[i].Type == EMarchEventType.EMET_Gathering)
			{
				int num = GameConstants.PointCodeToMapID(DataManager.Instance.MarchEventData[i].Point.zoneID, DataManager.Instance.MarchEventData[i].Point.pointID);
				if (num == _MapPointID)
				{
					result = (uint)(DataManager.Instance.MarchEventTime[i].RequireTime * _rate);
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x06001925 RID: 6437 RVA: 0x002A6804 File Offset: 0x002A4A04
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x06001926 RID: 6438 RVA: 0x002A6830 File Offset: 0x002A4A30
	public void Refresh_FontTexture()
	{
		for (int i = 0; i < 12; i++)
		{
			if (this.m_tmptext[i] != null && this.m_tmptext[i].enabled)
			{
				this.m_tmptext[i].enabled = false;
				this.m_tmptext[i].enabled = true;
			}
		}
		for (int j = 0; j < 5; j++)
		{
			if (this.m_ItemObj[j] != null)
			{
				if (this.m_ItemObj[j].m_ScrollSliderText1 != null && this.m_ItemObj[j].m_ScrollSliderText1.enabled)
				{
					this.m_ItemObj[j].m_ScrollSliderText1.enabled = false;
					this.m_ItemObj[j].m_ScrollSliderText1.enabled = true;
				}
				if (this.m_ItemObj[j].m_ScrollSliderText2 != null && this.m_ItemObj[j].m_ScrollSliderText2.enabled)
				{
					this.m_ItemObj[j].m_ScrollSliderText2.enabled = false;
					this.m_ItemObj[j].m_ScrollSliderText2.enabled = true;
				}
				if (this.m_ItemObj[j].m_ScrollSlider1Title != null && this.m_ItemObj[j].m_ScrollSlider1Title.enabled)
				{
					this.m_ItemObj[j].m_ScrollSlider1Title.enabled = false;
					this.m_ItemObj[j].m_ScrollSlider1Title.enabled = true;
				}
				if (this.m_ItemObj[j].m_ScrollSlider1Time != null && this.m_ItemObj[j].m_ScrollSlider1Time.enabled)
				{
					this.m_ItemObj[j].m_ScrollSlider1Time.enabled = false;
					this.m_ItemObj[j].m_ScrollSlider1Time.enabled = true;
				}
				if (this.m_ItemObj[j].m_ScrollSlider2Title != null && this.m_ItemObj[j].m_ScrollSlider2Title.enabled)
				{
					this.m_ItemObj[j].m_ScrollSlider2Title.enabled = false;
					this.m_ItemObj[j].m_ScrollSlider2Title.enabled = true;
				}
				if (this.m_ItemObj[j].m_ScrollSlider2Time != null && this.m_ItemObj[j].m_ScrollSlider2Time.enabled)
				{
					this.m_ItemObj[j].m_ScrollSlider2Time.enabled = false;
					this.m_ItemObj[j].m_ScrollSlider2Time.enabled = true;
				}
				if (this.m_ItemObj[j].m_ScrollSlider3Title != null && this.m_ItemObj[j].m_ScrollSlider3Title.enabled)
				{
					this.m_ItemObj[j].m_ScrollSlider3Title.enabled = false;
					this.m_ItemObj[j].m_ScrollSlider3Title.enabled = true;
				}
				if (this.m_ItemObj[j].m_ScrollSlider3Time != null && this.m_ItemObj[j].m_ScrollSlider3Time.enabled)
				{
					this.m_ItemObj[j].m_ScrollSlider3Time.enabled = false;
					this.m_ItemObj[j].m_ScrollSlider3Time.enabled = true;
				}
				if (this.m_ItemObj[j].m_ScrollIconText != null && this.m_ItemObj[j].m_ScrollIconText.enabled)
				{
					this.m_ItemObj[j].m_ScrollIconText.enabled = false;
					this.m_ItemObj[j].m_ScrollIconText.enabled = true;
				}
			}
		}
	}

	// Token: 0x04004A42 RID: 19010
	private const int MaxCreate = 5;

	// Token: 0x04004A43 RID: 19011
	private const int TextMax = 12;

	// Token: 0x04004A44 RID: 19012
	private DataManager DM = DataManager.Instance;

	// Token: 0x04004A45 RID: 19013
	private ScrollPanel m_ScrollPanel;

	// Token: 0x04004A46 RID: 19014
	private List<sArmyData> m_Data;

	// Token: 0x04004A47 RID: 19015
	private ArmyInfoObect[] m_ItemObj = new ArmyInfoObect[5];

	// Token: 0x04004A48 RID: 19016
	private Door door;

	// Token: 0x04004A49 RID: 19017
	private Material m_Mat;

	// Token: 0x04004A4A RID: 19018
	private CString m_EmptyStr;

	// Token: 0x04004A4B RID: 19019
	private CString m_CheckMsgStr;

	// Token: 0x04004A4C RID: 19020
	private UISpritesArray m_SpArray;

	// Token: 0x04004A4D RID: 19021
	private float m_TimeTick;

	// Token: 0x04004A4E RID: 19022
	private float m_ResTextChangeTime = 1.5f;

	// Token: 0x04004A4F RID: 19023
	private byte m_ResTextType;

	// Token: 0x04004A50 RID: 19024
	private float colorA;

	// Token: 0x04004A51 RID: 19025
	private int mTextCount;

	// Token: 0x04004A52 RID: 19026
	private UIText[] m_tmptext = new UIText[12];

	// Token: 0x04004A53 RID: 19027
	private eArmyUIType UIType;
}
