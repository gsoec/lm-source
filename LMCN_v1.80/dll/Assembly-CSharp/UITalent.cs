using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200066B RID: 1643
public class UITalent : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUIButtonDownUpHandler
{
	// Token: 0x06001FB2 RID: 8114 RVA: 0x003C7058 File Offset: 0x003C5258
	public override void OnOpen(int arg1, int arg2)
	{
		this.SaveSlot = (byte)(arg1 & 255);
		this.CheckSaveFlag = (byte)arg2;
		if ((arg1 & 32768) > 0)
		{
			this.DelayLoadScroll = 2;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		GUIManager.Instance.SetTalentIconSprite("UITechIcon", this.m_eWindow);
		this.TalentPointStr = StringManager.Instance.SpawnString(30);
		Font ttffont = GUIManager.Instance.GetTTFFont();
		DataManager instance = DataManager.Instance;
		this.DataCount = instance.TalentTreeLayout.TableCount;
		UIText component = base.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = instance.mStringTable.GetStringByID(1501u);
		this.TextRefleshArray[0] = component;
		component = base.transform.GetChild(2).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = instance.mStringTable.GetStringByID(929u);
		this.TextRefleshArray[1] = component;
		component = base.transform.GetChild(3).GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = instance.mStringTable.GetStringByID(1508u);
		this.TextRefleshArray[2] = component;
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			base.transform.GetChild(7).GetComponent<CustomImage>().enabled = false;
		}
		else
		{
			base.transform.GetChild(7).GetComponent<CustomImage>().hander = GUIManager.Instance.m_ItemInfo;
		}
		base.transform.GetChild(7).GetChild(0).GetComponent<CustomImage>().hander = GUIManager.Instance.m_ItemInfo;
		this.SpriteArray = base.transform.GetChild(5).GetComponent<UISpritesArray>();
		Transform child = base.transform.GetChild(6);
		this.TalentTreePanel = base.transform.GetChild(5).GetComponent<ScrollPanel>();
		UIButton component2 = base.transform.GetChild(7).GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 2;
		this.DefaultBtn = base.transform.GetChild(2).GetComponent<UIButton>();
		this.DefaultBtn.m_BtnID1 = 0;
		this.DefaultBtn.m_Handler = this;
		this.DefaultImg = base.transform.GetChild(2).GetComponent<Image>();
		this.SaveTalentObj = this.DefaultBtn.gameObject;
		if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 15)
		{
			this.SaveTalentObj.SetActive(false);
		}
		if (this.SaveSlot == 0)
		{
			instance.SaveTalentData[0].SaveIndex = 0;
			this.DefaultBtn.m_BtnID1 = 4;
			this.TextRefleshArray[1].text = instance.mStringTable.GetStringByID(923u);
		}
		this.ResetBtn = base.transform.GetChild(3).GetComponent<UIButton>();
		this.ResetBtn.m_BtnID1 = 1;
		this.ResetBtn.m_Handler = this;
		this.TalentPointText = base.transform.GetChild(4).GetChild(0).GetComponent<UIText>();
		this.TalentPointText.font = ttffont;
		this.TextRefleshArray[3] = component;
		UIButtonHint uibuttonHint = base.transform.GetChild(4).GetChild(1).gameObject.AddComponent<UIButtonHint>();
		uibuttonHint.m_eHint = EUIButtonHint.DownUpHandler;
		uibuttonHint.m_Handler = this;
		this.HintTrans = base.transform.GetChild(9).GetComponent<RectTransform>();
		uibuttonHint.ControlFadeOut = this.HintTrans.gameObject;
		component = this.HintTrans.GetChild(0).GetComponent<UIText>();
		component.font = ttffont;
		component.text = instance.mStringTable.GetStringByID(1502u);
		this.TextRefleshArray[4] = component;
		Vector2 sizeDelta = this.HintTrans.sizeDelta;
		sizeDelta.y = component.preferredHeight + 16f;
		this.HintTrans.sizeDelta = sizeDelta;
		component2 = child.GetChild(2).GetChild(1).GetComponent<UIButton>();
		component2.m_BtnID1 = 3;
		component2 = child.GetChild(3).GetChild(1).GetComponent<UIButton>();
		component2.m_BtnID1 = 3;
		component2 = child.GetChild(4).GetChild(1).GetComponent<UIButton>();
		component2.m_BtnID1 = 3;
		component2 = child.GetChild(5).GetChild(1).GetComponent<UIButton>();
		component2.m_BtnID1 = 3;
		child.GetChild(2).GetChild(6).GetComponent<UIText>().font = ttffont;
		child.GetChild(2).GetChild(5).GetComponent<UIText>().font = ttffont;
		child.GetChild(3).GetChild(6).GetComponent<UIText>().font = ttffont;
		child.GetChild(3).GetChild(5).GetComponent<UIText>().font = ttffont;
		child.GetChild(4).GetChild(6).GetComponent<UIText>().font = ttffont;
		child.GetChild(4).GetChild(5).GetComponent<UIText>().font = ttffont;
		child.GetChild(5).GetChild(6).GetComponent<UIText>().font = ttffont;
		child.GetChild(5).GetChild(5).GetComponent<UIText>().font = ttffont;
		if (this.SaveSlot > 0)
		{
			if (this.CheckSaveFlag == 0)
			{
				instance.CloneTalentSave(this.SaveSlot, 0);
				this.SetDefaultBtnEnable(false);
			}
			else
			{
				int num = DataManager.Instance.CompareTalentSave(this.SaveSlot);
				if (num == 1)
				{
					instance.CloneTalentSave(this.SaveSlot, 0);
					this.SetDefaultBtnEnable(false);
				}
				else
				{
					this.DelSaveFlage();
					if (instance.TalentSaveZero == 0 || instance.TalentSaveQueueCount > 0 || instance.SaveTalentData[0].TagName.GetHashCode(false) != instance.SaveTalentData[(int)this.SaveSlot].TagName.GetHashCode(false))
					{
						this.SetDefaultBtnEnable(true);
					}
					else
					{
						this.SetDefaultBtnEnable(false);
					}
				}
			}
			this.SetResetOrLoadCurrentTalent();
			instance.SaveTalentData[0].SaveIndex = instance.SaveTalentData[(int)this.SaveSlot].SaveIndex;
			this.TextRefleshArray[0].text = instance.SaveTalentData[0].GetTagName().ToString();
			this.TextRefleshArray[0].SetAllDirty();
			this.TextRefleshArray[0].cachedTextGenerator.Invalidate();
			this.TextRefleshArray[0].cachedTextGeneratorForLayout.Invalidate();
			UISpritesArray component3 = base.transform.GetComponent<UISpritesArray>();
			base.transform.GetChild(0).GetComponent<Image>().sprite = component3.GetSprite(0);
			base.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = component3.GetSprite(1);
			base.transform.GetChild(2).GetComponent<Image>().sprite = component3.GetSprite(2);
			component2 = base.transform.GetChild(1).GetComponent<UIButton>();
			component2.m_Handler = this;
			component2.gameObject.SetActive(true);
			component2.m_BtnID1 = 5;
			this.ChangeNameRect = component2.GetComponent<RectTransform>();
			this.ChangeNameRect.anchoredPosition = new Vector2(this.TextRefleshArray[0].preferredWidth * 0.5f + 25f, this.ChangeNameRect.anchoredPosition.y);
		}
		GameConstants.ArrayFill<ushort>(this.HorzontalShowFlag, 0);
		this.UpdateRoleTalentPoint();
	}

	// Token: 0x06001FB3 RID: 8115 RVA: 0x003C77D4 File Offset: 0x003C59D4
	private void SetResetOrLoadCurrentTalent()
	{
		if (this.SaveSlot > 0 && DataManager.Instance.SaveTalentData[0].NoUseTalent == 1 && DataManager.Instance.TalentSaveQueueCount == 0)
		{
			this.ResetBtn.m_BtnID1 = 6;
			this.TextRefleshArray[2].text = DataManager.Instance.mStringTable.GetStringByID(10032u);
		}
		else
		{
			this.ResetBtn.m_BtnID1 = 1;
			this.TextRefleshArray[2].text = DataManager.Instance.mStringTable.GetStringByID(1508u);
		}
	}

	// Token: 0x06001FB4 RID: 8116 RVA: 0x003C7878 File Offset: 0x003C5A78
	public void DelSaveFlage()
	{
		Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
		if (door != null && door.m_WindowStack.Count > 0)
		{
			for (int i = door.m_WindowStack.Count - 1; i >= 0; i--)
			{
				GUIWindowStackData value = door.m_WindowStack[i];
				if (value.m_eWindow == EGUIWindow.UI_Rally)
				{
					value.m_Arg2 = 0;
					door.m_WindowStack[i] = value;
					break;
				}
			}
		}
	}

	// Token: 0x06001FB5 RID: 8117 RVA: 0x003C7908 File Offset: 0x003C5B08
	private void SetDefaultBtnEnable(bool enable)
	{
		this.DefaultBtn.enabled = enable;
		if (enable)
		{
			this.TextRefleshArray[1].color = Color.white;
			this.DefaultImg.color = Color.white;
		}
		else
		{
			this.TextRefleshArray[1].color = new Color(0.898f, 0f, 0.31f);
			this.DefaultImg.color = Color.gray;
		}
	}

	// Token: 0x06001FB6 RID: 8118 RVA: 0x003C7980 File Offset: 0x003C5B80
	public void UpdateRoleTalentPoint()
	{
		this.TalentPointStr.ClearString();
		if (this.SaveSlot == 0)
		{
			this.TalentPointStr.IntToFormat((long)DataManager.Instance.RoleTalentPoint, 1, false);
		}
		else
		{
			this.TalentPointStr.IntToFormat((long)DataManager.Instance.SaveTalentData[0].RoleTalentPoint, 1, false);
		}
		this.TalentPointStr.AppendFormat("{0}");
		this.TalentPointText.text = this.TalentPointStr.ToString();
		this.TalentPointText.SetAllDirty();
		this.TalentPointText.cachedTextGenerator.Invalidate();
		if (this.InfoWindow != null)
		{
			this.InfoWindow.UpdateRoleTalentPoint();
		}
	}

	// Token: 0x06001FB7 RID: 8119 RVA: 0x003C7A3C File Offset: 0x003C5C3C
	public void SetItemLayout(int dataIndex, int panelIndex)
	{
		TalentTreeLayoutTbl recordByIndex = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(dataIndex);
		this.TreeLayer[panelIndex].DataIndex = dataIndex;
		this.TreeLayer[panelIndex].PanelIndex = panelIndex;
		switch (recordByIndex.TalentCount)
		{
		case 1:
		{
			this.SetTalentItemLayout(dataIndex, panelIndex, 0, recordByIndex.TreeData[0].TalentID, recordByIndex.TreeData[0].VerticalExtend, recordByIndex.TreeData[0].HorzontalExtend);
			Vector2 anchoredPosition = this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[1];
			this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition = anchoredPosition;
			this.TreeLayer[panelIndex].Tech[1].TechTransform.gameObject.SetActive(false);
			this.TreeLayer[panelIndex].Tech[2].TechTransform.gameObject.SetActive(false);
			this.TreeLayer[panelIndex].Tech[3].TechTransform.gameObject.SetActive(false);
			break;
		}
		case 2:
		{
			this.SetTalentItemLayout(dataIndex, panelIndex, 0, recordByIndex.TreeData[0].TalentID, recordByIndex.TreeData[0].VerticalExtend, recordByIndex.TreeData[0].HorzontalExtend);
			Vector2 anchoredPosition = this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[4];
			this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition = anchoredPosition;
			this.SetTalentItemLayout(dataIndex, panelIndex, 1, recordByIndex.TreeData[1].TalentID, recordByIndex.TreeData[1].VerticalExtend, recordByIndex.TreeData[1].HorzontalExtend);
			anchoredPosition = this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[5];
			this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition = anchoredPosition;
			this.TreeLayer[panelIndex].Tech[2].TechTransform.gameObject.SetActive(false);
			this.TreeLayer[panelIndex].Tech[3].TechTransform.gameObject.SetActive(false);
			break;
		}
		case 3:
		{
			this.SetTalentItemLayout(dataIndex, panelIndex, 0, recordByIndex.TreeData[0].TalentID, recordByIndex.TreeData[0].VerticalExtend, recordByIndex.TreeData[0].HorzontalExtend);
			Vector2 anchoredPosition = this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[0];
			this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition = anchoredPosition;
			this.SetTalentItemLayout(dataIndex, panelIndex, 1, recordByIndex.TreeData[1].TalentID, recordByIndex.TreeData[1].VerticalExtend, recordByIndex.TreeData[1].HorzontalExtend);
			anchoredPosition = this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[1];
			this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition = anchoredPosition;
			this.SetTalentItemLayout(dataIndex, panelIndex, 2, recordByIndex.TreeData[2].TalentID, recordByIndex.TreeData[2].VerticalExtend, recordByIndex.TreeData[2].HorzontalExtend);
			anchoredPosition = this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[2];
			this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition = anchoredPosition;
			this.TreeLayer[panelIndex].Tech[3].TechTransform.gameObject.SetActive(false);
			break;
		}
		case 4:
		{
			this.SetTalentItemLayout(dataIndex, panelIndex, 0, recordByIndex.TreeData[0].TalentID, recordByIndex.TreeData[0].VerticalExtend, recordByIndex.TreeData[0].HorzontalExtend);
			Vector2 anchoredPosition = this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[3];
			this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition = anchoredPosition;
			this.SetTalentItemLayout(dataIndex, panelIndex, 1, recordByIndex.TreeData[1].TalentID, recordByIndex.TreeData[1].VerticalExtend, recordByIndex.TreeData[1].HorzontalExtend);
			anchoredPosition = this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[4];
			this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition = anchoredPosition;
			this.SetTalentItemLayout(dataIndex, panelIndex, 2, recordByIndex.TreeData[2].TalentID, recordByIndex.TreeData[2].VerticalExtend, recordByIndex.TreeData[2].HorzontalExtend);
			anchoredPosition = this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[5];
			this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition = anchoredPosition;
			this.SetTalentItemLayout(dataIndex, panelIndex, 3, recordByIndex.TreeData[3].TalentID, recordByIndex.TreeData[3].VerticalExtend, recordByIndex.TreeData[3].HorzontalExtend);
			anchoredPosition = this.TreeLayer[panelIndex].Tech[3].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[6];
			this.TreeLayer[panelIndex].Tech[3].TechTransform.anchoredPosition = anchoredPosition;
			break;
		}
		}
		this.SetHorizontalLayout(dataIndex, panelIndex);
	}

	// Token: 0x06001FB8 RID: 8120 RVA: 0x003C80F8 File Offset: 0x003C62F8
	public void SetTalentItemLayout(int dataIndex, int panelIndex, byte techIndex, ushort TechID, byte UpDown, byte LeftRight)
	{
		if (TechID == 0)
		{
			this.TreeLayer[panelIndex].Tech[(int)techIndex].TechTransform.gameObject.SetActive(false);
			return;
		}
		this.TreeLayer[panelIndex].Tech[(int)techIndex].TechTransform.gameObject.SetActive(true);
		this.TreeLayer[panelIndex].Tech[(int)techIndex].SetItemStyle(ref this.SpriteArray, TechID);
		if (TechID < 1000)
		{
			this.TreeLayer[panelIndex].Tech[(int)techIndex].SetTechID(TechID);
			this.TreeLayer[panelIndex].Tech[(int)techIndex].SetTechInfo(TechID);
			Vector2 sizeDelta = this.TreeLayer[panelIndex].Tech[(int)techIndex].TechIconTrans.sizeDelta;
			sizeDelta.Set(110f, 110f);
			this.TreeLayer[panelIndex].Tech[(int)techIndex].TechIconTrans.sizeDelta = sizeDelta;
			Quaternion localRotation = this.TreeLayer[panelIndex].Tech[(int)techIndex].TechIconTrans.localRotation;
			localRotation.eulerAngles = Vector3.zero;
			this.TreeLayer[panelIndex].Tech[(int)techIndex].TechIconTrans.localRotation = localRotation;
			this.TreeLayer[panelIndex].Tech[(int)techIndex].Lines[2].SetActive((UpDown & 1) > 0);
			this.TreeLayer[panelIndex].Tech[(int)techIndex].Lines[3].SetActive((UpDown & 2) > 0);
			this.TreeLayer[panelIndex].Tech[(int)techIndex].Lines[1].SetActive((LeftRight & 1) > 0);
			this.TreeLayer[panelIndex].Tech[(int)techIndex].Lines[0].SetActive((LeftRight & 2) > 0);
		}
		else
		{
			TalentTreeLayoutTbl recordByIndex = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(dataIndex + 1);
			if (TechID == 1002)
			{
				this.TreeLayer[panelIndex].Tech[(int)techIndex].SetTechID(recordByIndex.TreeData[(int)techIndex].TalentID);
			}
			else if (TechID == 1003)
			{
				this.TreeLayer[panelIndex].Tech[(int)techIndex].SetTechID(recordByIndex.TreeData[(int)techIndex].TalentID);
				this.TreeLayer[panelIndex].Tech[(int)techIndex].TechBtn.m_BtnID2 = (int)TechID;
				this.TreeLayer[panelIndex].Tech[(int)techIndex].TechBtn.m_BtnID3 = (int)this.GetParentTechID(ref recordByIndex, this.TreeLayer[panelIndex].DataIndex, (int)techIndex, UITalent.NeighborWay.Left);
			}
			else if (TechID == 1001)
			{
				this.TreeLayer[panelIndex].Tech[(int)techIndex].SetTechID(recordByIndex.TreeData[(int)techIndex].TalentID);
				this.TreeLayer[panelIndex].Tech[(int)techIndex].TechBtn.m_BtnID2 = (int)TechID;
				this.TreeLayer[panelIndex].Tech[(int)techIndex].TechBtn.m_BtnID3 = (int)this.GetParentTechID(ref recordByIndex, this.TreeLayer[panelIndex].DataIndex, (int)techIndex, UITalent.NeighborWay.Up);
			}
			this.TreeLayer[panelIndex].Tech[(int)techIndex].Level.text = string.Empty;
		}
	}

	// Token: 0x06001FB9 RID: 8121 RVA: 0x003C84AC File Offset: 0x003C66AC
	public void SetHorizontalLayout(int dataIndex, int panelIndex)
	{
		TalentTreeLayoutTbl recordByIndex = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(dataIndex);
		this.TreeLayer[panelIndex].Line[0].LineImg.sprite = this.SpriteArray.GetSprite(1);
		this.TreeLayer[panelIndex].Line[1].LineImg.sprite = this.SpriteArray.GetSprite(1);
		if (recordByIndex.HorizontalType == 0)
		{
			this.TreeLayer[panelIndex].Line[0].LineImg.gameObject.SetActive(false);
			this.TreeLayer[panelIndex].Line[1].LineImg.gameObject.SetActive(false);
		}
		else if (recordByIndex.HorizontalType < 11)
		{
			this.TreeLayer[panelIndex].Line[0].LineImg.gameObject.SetActive(true);
			Vector2 vector = this.TreeLayer[panelIndex].Line[0].LineTrans.anchoredPosition;
			vector.x = this.HorizontalPW[(int)(recordByIndex.HorizontalType - 1)][0];
			this.TreeLayer[panelIndex].Line[0].LineTrans.anchoredPosition = vector;
			vector = this.TreeLayer[panelIndex].Line[0].LineTrans.sizeDelta;
			vector.x = this.HorizontalPW[(int)(recordByIndex.HorizontalType - 1)][1];
			this.TreeLayer[panelIndex].Line[0].LineTrans.sizeDelta = vector;
			this.TreeLayer[panelIndex].Line[1].LineImg.gameObject.SetActive(false);
		}
		else
		{
			this.TreeLayer[panelIndex].Line[0].LineImg.gameObject.SetActive(true);
			Vector2 vector = this.TreeLayer[panelIndex].Line[0].LineTrans.anchoredPosition;
			vector.x = this.HorizontalPW[(int)(recordByIndex.HorizontalType - 1)][0];
			this.TreeLayer[panelIndex].Line[0].LineTrans.anchoredPosition = vector;
			vector = this.TreeLayer[panelIndex].Line[0].LineTrans.sizeDelta;
			vector.x = this.HorizontalPW[(int)(recordByIndex.HorizontalType - 1)][1];
			this.TreeLayer[panelIndex].Line[0].LineTrans.sizeDelta = vector;
			this.TreeLayer[panelIndex].Line[1].LineImg.gameObject.SetActive(true);
		}
		byte horizontalType = recordByIndex.HorizontalType;
		this.SetNodeLayout(panelIndex, horizontalType, ref recordByIndex, true);
		if (dataIndex + 1 < this.HorzontalShowFlag.Length)
		{
			recordByIndex = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(dataIndex + 1);
			this.SetNodeLayout(panelIndex, horizontalType, ref recordByIndex, false);
		}
		this.UpdateHorizontal(dataIndex, panelIndex);
	}

	// Token: 0x06001FBA RID: 8122 RVA: 0x003C87F0 File Offset: 0x003C69F0
	public void SetNodeLayout(int panelIndex, byte HorizontalType, ref TalentTreeLayoutTbl Data, bool bDown)
	{
		byte b = 2;
		if (!bDown)
		{
			b = 1;
		}
		ushort num = 0;
		switch (HorizontalType)
		{
		case 1:
			if (Data.TreeData[0].TalentID > 0 && (Data.TreeData[0].VerticalExtend & b) > 0)
			{
				num |= 1;
			}
			if (Data.TreeData[1].TalentID > 0 && (Data.TreeData[1].VerticalExtend & b) > 0)
			{
				num |= 2;
			}
			break;
		case 2:
			if (Data.TreeData[0].TalentID > 0 && (Data.TreeData[0].VerticalExtend & b) > 0)
			{
				num |= 1;
			}
			if (Data.TreeData[1].TalentID > 0 && (Data.TreeData[1].VerticalExtend & b) > 0)
			{
				num |= 2;
			}
			if (Data.TreeData[2].TalentID > 0 && (Data.TreeData[2].VerticalExtend & b) > 0)
			{
				num |= 4;
			}
			break;
		case 3:
			if (Data.TreeData[0].TalentID > 0 && (Data.TreeData[0].VerticalExtend & b) > 0)
			{
				num |= 1;
			}
			if (Data.TreeData[1].TalentID > 0 && (Data.TreeData[1].VerticalExtend & b) > 0)
			{
				num |= 2;
			}
			break;
		case 4:
			if (Data.TreeData[1].TalentID > 0 && (Data.TreeData[1].VerticalExtend & b) > 0)
			{
				num |= 2;
			}
			if (Data.TreeData[2].TalentID > 0 && (Data.TreeData[2].VerticalExtend & b) > 0)
			{
				num |= 4;
			}
			break;
		case 5:
			if (Data.TreeData[0].TalentID > 0 && (Data.TreeData[0].VerticalExtend & b) > 0)
			{
				num |= 1;
			}
			if (Data.TreeData[1].TalentID > 0 && (Data.TreeData[1].VerticalExtend & b) > 0)
			{
				num |= 2;
			}
			if (Data.TreeData[2].TalentID > 0 && (Data.TreeData[2].VerticalExtend & b) > 0)
			{
				num |= 4;
			}
			if (Data.TreeData[3].TalentID > 0 && (Data.TreeData[3].VerticalExtend & b) > 0)
			{
				num |= 8;
			}
			break;
		case 6:
			if (Data.TreeData[0].TalentID > 0 && (Data.TreeData[0].VerticalExtend & b) > 0)
			{
				num |= 1;
			}
			if (Data.TreeData[1].TalentID > 0 && (Data.TreeData[1].VerticalExtend & b) > 0)
			{
				num |= 2;
			}
			if (Data.TreeData[2].TalentID > 0 && (Data.TreeData[2].VerticalExtend & b) > 0)
			{
				num |= 4;
			}
			break;
		case 7:
			if (Data.TreeData[1].TalentID > 0 && (Data.TreeData[1].VerticalExtend & b) > 0)
			{
				num |= 2;
			}
			if (Data.TreeData[2].TalentID > 0 && (Data.TreeData[2].VerticalExtend & b) > 0)
			{
				num |= 4;
			}
			if (Data.TreeData[3].TalentID > 0 && (Data.TreeData[3].VerticalExtend & b) > 0)
			{
				num |= 8;
			}
			break;
		case 8:
			if (Data.TreeData[0].TalentID > 0 && (Data.TreeData[0].VerticalExtend & b) > 0)
			{
				num |= 1;
			}
			if (Data.TreeData[1].TalentID > 0 && (Data.TreeData[1].VerticalExtend & b) > 0)
			{
				num |= 2;
			}
			break;
		case 9:
			if (Data.TreeData[1].TalentID > 0 && (Data.TreeData[1].VerticalExtend & b) > 0)
			{
				num |= 2;
			}
			if (Data.TreeData[2].TalentID > 0 && (Data.TreeData[2].VerticalExtend & b) > 0)
			{
				num |= 4;
			}
			break;
		case 10:
			if (Data.TreeData[2].TalentID > 0 && (Data.TreeData[2].VerticalExtend & b) > 0)
			{
				num |= 4;
			}
			if (Data.TreeData[3].TalentID > 0 && (Data.TreeData[3].VerticalExtend & b) > 0)
			{
				num |= 8;
			}
			break;
		case 11:
			if (Data.TreeData[0].TalentID > 0 && (Data.TreeData[0].VerticalExtend & b) > 0)
			{
				num |= 1;
			}
			if (Data.TreeData[1].TalentID > 0 && (Data.TreeData[1].VerticalExtend & b) > 0)
			{
				num |= 2;
			}
			if (Data.TreeData[2].TalentID > 0 && (Data.TreeData[2].VerticalExtend & b) > 0)
			{
				num |= 4;
			}
			if (Data.TreeData[3].TalentID > 0 && (Data.TreeData[3].VerticalExtend & b) > 0)
			{
				num |= 8;
			}
			break;
		}
		if (Data.HorizontalType == 0)
		{
			num |= 512;
		}
		if (bDown)
		{
			this.HorzontalShowFlag[(int)(Data.ID - 1)] = num;
		}
		else
		{
			num = (ushort)(num << 5);
			ushort[] horzontalShowFlag = this.HorzontalShowFlag;
			ushort num2 = Data.ID - 2;
			horzontalShowFlag[(int)num2] = (horzontalShowFlag[(int)num2] | num);
		}
	}

	// Token: 0x06001FBB RID: 8123 RVA: 0x003C8ECC File Offset: 0x003C70CC
	private byte CheckTechState(ushort TechID)
	{
		return DataManager.Instance.CheckTalentState(TechID, this.SaveSlot, 1);
	}

	// Token: 0x06001FBC RID: 8124 RVA: 0x003C8EE0 File Offset: 0x003C70E0
	private unsafe void UpdateHorizontal(int dataIndex, int panelIndex)
	{
		TalentTreeLayoutTbl recordByIndex = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(dataIndex);
		bool flag = true;
		ushort* ptr;
		int* ptr2;
		byte b;
		int num;
		checked
		{
			ptr = stackalloc ushort[8 * 2];
			ptr2 = stackalloc int[4 * 4];
			b = 0;
			num = 0;
			*ptr = recordByIndex.TreeData[0].TalentID;
		}
		ptr[1] = recordByIndex.TreeData[1].TalentID;
		ptr[2] = recordByIndex.TreeData[2].TalentID;
		ptr[3] = recordByIndex.TreeData[3].TalentID;
		ptr[4] = (ushort)recordByIndex.TreeData[0].HorzontalExtend;
		ptr[5] = (ushort)recordByIndex.TreeData[1].HorzontalExtend;
		ptr[6] = (ushort)recordByIndex.TreeData[2].HorzontalExtend;
		ptr[7] = (ushort)recordByIndex.TreeData[3].HorzontalExtend;
		for (int i = 0; i < (int)recordByIndex.TalentCount; i++)
		{
			int num2 = 1 << i;
			if (((int)this.HorzontalShowFlag[dataIndex] & num2) > 0)
			{
				b |= this.GetNodePos(recordByIndex.TalentCount, i);
				if (ptr[i] > 0)
				{
					if (ptr[i] == 1001)
					{
						ptr[i] = this.GetParentTechID(ref recordByIndex, dataIndex, i, UITalent.NeighborWay.Up);
					}
					int num3;
					if ((this.CheckTechState(ptr[i]) & 2) > 0)
					{
						num |= (int)this.GetNodePos(recordByIndex.TalentCount, i);
						num3 = 2;
					}
					else
					{
						num3 = 1;
						flag = false;
					}
					this.TreeLayer[panelIndex].Tech[i].Lines[3].LineImage.sprite = this.SpriteArray.GetSprite(num3);
					this.TreeLayer[panelIndex].Tech[i].Lines[0].LineImage.sprite = this.SpriteArray.GetSprite(num3);
					this.TreeLayer[panelIndex].Tech[i].Lines[1].LineImage.sprite = this.SpriteArray.GetSprite(num3);
				}
			}
			else if (ptr[i] > 0)
			{
				int num3 = 2;
				TalentTreeLayoutTbl talentTreeLayoutTbl = recordByIndex;
				for (int j = 0; j < 4; j++)
				{
					if (j != 2)
					{
						if ((this.CheckTechState(ptr[i]) & 2) > 0)
						{
							talentTreeLayoutTbl = recordByIndex;
							if ((this.CheckTechState(this.GetParentTechID(ref talentTreeLayoutTbl, dataIndex, i, (UITalent.NeighborWay)j)) & 1) > 0)
							{
								ptr2[j] = num3 - 1;
							}
							else
							{
								ptr2[j] = num3;
							}
						}
						else
						{
							ptr2[j] = num3 - 1;
						}
					}
				}
				this.TreeLayer[panelIndex].Tech[i].Lines[3].LineImage.sprite = this.SpriteArray.GetSprite(ptr2[3]);
				this.TreeLayer[panelIndex].Tech[i].Lines[0].LineImage.sprite = this.SpriteArray.GetSprite(*ptr2);
				this.TreeLayer[panelIndex].Tech[i].Lines[1].LineImage.sprite = this.SpriteArray.GetSprite(ptr2[1]);
			}
			if (i > 0 && i < 4 && (ptr[4 + i] & 1) > 0)
			{
				this.TreeLayer[panelIndex].Tech[i - 1].Lines[0].LineImage.sprite = this.TreeLayer[panelIndex].Tech[i].Lines[1].LineImage.sprite;
				this.TreeLayer[panelIndex].Tech[i - 1].Lines[0].SetActive(true);
				this.TreeLayer[panelIndex].Tech[i].Lines[1].SetActive(false);
			}
		}
		if (flag)
		{
			ushort[] horzontalShowFlag = this.HorzontalShowFlag;
			horzontalShowFlag[dataIndex] |= 16;
			this.TreeLayer[panelIndex].Line[0].LineImg.sprite = this.SpriteArray.GetSprite(2);
		}
		byte b2 = 0;
		int num4 = 0;
		int num5 = (panelIndex + 1) % this.MaxItemCount;
		int num6;
		if (num5 == 0)
		{
			num6 = this.MaxItemCount - 1;
		}
		else
		{
			num6 = num5;
		}
		if (this.TalentTreePanel.GetBeginIdx() + 2 == dataIndex)
		{
			int num7 = panelIndex - 1;
			if (num7 < 0)
			{
				num7 = this.MaxItemCount - 1;
			}
			this.UpdateHorizontal(dataIndex - 1, num7);
		}
		else if (this.DataCount > dataIndex + 1)
		{
			recordByIndex = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(dataIndex + 1);
			*ptr = recordByIndex.TreeData[0].TalentID;
			ptr[1] = recordByIndex.TreeData[1].TalentID;
			ptr[2] = recordByIndex.TreeData[2].TalentID;
			ptr[3] = recordByIndex.TreeData[3].TalentID;
			int num8 = this.HorzontalShowFlag[dataIndex] >> 5;
			for (int k = 0; k < (int)recordByIndex.TalentCount; k++)
			{
				int num2 = 1 << k;
				if ((num8 & num2) > 0)
				{
					if (ptr[k] == 1001)
					{
						ptr[k] = this.GetParentTechID(ref recordByIndex, dataIndex + 1, k, UITalent.NeighborWay.Down);
					}
					b2 |= this.GetNodePos(recordByIndex.TalentCount, k);
					if ((this.HorzontalShowFlag[dataIndex] & 16) > 0 || (this.CheckTechState(ptr[k]) & 2) > 0)
					{
						num4 |= (int)this.GetNodePos(recordByIndex.TalentCount, k);
						this.TreeLayer[num5].Tech[k].Lines[2].LineImage.sprite = this.SpriteArray.GetSprite(2);
					}
					else
					{
						this.TreeLayer[num5].Tech[k].Lines[2].LineImage.sprite = this.SpriteArray.GetSprite(1);
					}
				}
				else if ((this.CheckTechState(ptr[k]) & 1) == 0 && (this.CheckTechState(this.GetParentTechID(ref recordByIndex, dataIndex + 1, k, UITalent.NeighborWay.Up)) & 2) > 0)
				{
					this.TreeLayer[num5].Tech[k].Lines[2].LineImage.sprite = this.SpriteArray.GetSprite(2);
				}
				else
				{
					this.TreeLayer[num5].Tech[k].Lines[2].LineImage.sprite = this.SpriteArray.GetSprite(1);
				}
			}
		}
		int num9 = 0;
		int num10 = 0;
		if (num6 == num5)
		{
			num9 = 7;
			num10 = 7;
		}
		for (int l = 0; l < 7; l++)
		{
			int num2 = 1 << l;
			if (((int)b & num2) > 0 && ((int)b2 & num2) == 0)
			{
				Vector2 anchoredPosition = this.TreeLayer[num6].Node[num9].rectTransform.anchoredPosition;
				anchoredPosition.x = this.Skillpos[l] + 100.3f;
				this.TreeLayer[num6].Node[num9].rectTransform.anchoredPosition = anchoredPosition;
				if ((num & num2) > 0)
				{
					this.TreeLayer[num6].Node[num9].sprite = this.SpriteArray.GetSprite(8);
				}
				else
				{
					this.TreeLayer[num6].Node[num9].sprite = this.SpriteArray.GetSprite(7);
				}
				num9++;
			}
			else if (((int)b2 & num2) > 0)
			{
				Vector2 anchoredPosition = this.TreeLayer[num6].Node[num9].rectTransform.anchoredPosition;
				anchoredPosition.x = this.Skillpos[l] + 100.3f;
				this.TreeLayer[num6].Node[num9].rectTransform.anchoredPosition = anchoredPosition;
				if ((num4 & num2) > 0)
				{
					this.TreeLayer[num6].Node[num9].sprite = this.SpriteArray.GetSprite(8);
				}
				else
				{
					this.TreeLayer[num6].Node[num9].sprite = this.SpriteArray.GetSprite(7);
				}
				num9++;
			}
		}
		for (int m = num10; m < num10 + 7; m++)
		{
			if (num9 > m)
			{
				this.TreeLayer[num6].Node[m].gameObject.SetActive(true);
			}
			else
			{
				this.TreeLayer[num6].Node[m].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001FBD RID: 8125 RVA: 0x003C9850 File Offset: 0x003C7A50
	public ushort GetParentTechID(ref TalentTreeLayoutTbl Data, int dataIndex, int techIndex, UITalent.NeighborWay way)
	{
		Data = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(dataIndex);
		ushort talentID = Data.TreeData[techIndex].TalentID;
		switch (way)
		{
		case UITalent.NeighborWay.Right:
			if (techIndex + 1 >= Data.TreeData.Length)
			{
				return 0;
			}
			if (Data.TreeData[techIndex + 1].TalentID == 1002)
			{
				return this.GetParentTechID(ref Data, dataIndex, techIndex, UITalent.NeighborWay.Down);
			}
			return Data.TreeData[techIndex + 1].TalentID;
		case UITalent.NeighborWay.Left:
			if (techIndex == 0)
			{
				return 0;
			}
			if (Data.TreeData[techIndex - 1].TalentID == 1002)
			{
				return this.GetParentTechID(ref Data, dataIndex, techIndex, UITalent.NeighborWay.Down);
			}
			return Data.TreeData[techIndex - 1].TalentID;
		case UITalent.NeighborWay.Up:
			if (dataIndex > 0)
			{
				Data = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(--dataIndex);
				ushort talentID2 = Data.TreeData[techIndex].TalentID;
				if (talentID2 == 1001)
				{
					return this.GetParentTechID(ref Data, dataIndex, techIndex, UITalent.NeighborWay.Up);
				}
				if (talentID2 == 1002)
				{
					if (techIndex + 1 >= Data.TreeData.Length)
					{
						return Data.TreeData[techIndex + 1].TalentID;
					}
					return 0;
				}
				else
				{
					if (talentID2 != 1003)
					{
						return Data.TreeData[techIndex].TalentID;
					}
					if (techIndex == 0)
					{
						return 0;
					}
					return Data.TreeData[techIndex - 1].TalentID;
				}
			}
			break;
		case UITalent.NeighborWay.Down:
			if (dataIndex + 1 < this.HorzontalShowFlag.Length)
			{
				Data = DataManager.Instance.TalentTreeLayout.GetRecordByIndex(++dataIndex);
				ushort talentID3 = Data.TreeData[techIndex].TalentID;
				if (talentID3 == 1001)
				{
					return talentID;
				}
				return talentID3;
			}
			break;
		}
		return 0;
	}

	// Token: 0x06001FBE RID: 8126 RVA: 0x003C9A40 File Offset: 0x003C7C40
	public byte GetNodePos(byte NodeCount, int Index)
	{
		if (NodeCount == 1)
		{
			return 2;
		}
		if (NodeCount == 2)
		{
			return (byte)(1 << 4 + Index);
		}
		if (NodeCount == 3)
		{
			return (byte)(1 << Index);
		}
		return (byte)(1 << 3 + Index);
	}

	// Token: 0x06001FBF RID: 8127 RVA: 0x003C9A80 File Offset: 0x003C7C80
	public override bool OnBackButtonClick()
	{
		if (this.InfoWindow != null && this.InfoWindow.ThisTransform.gameObject.activeSelf)
		{
			this.InfoWindow.SetActive(false);
		}
		this.CheckSaveClose();
		return true;
	}

	// Token: 0x06001FC0 RID: 8128 RVA: 0x003C9AC8 File Offset: 0x003C7CC8
	private void CheckSaveClose()
	{
		DataManager instance = DataManager.Instance;
		StringTable mStringTable = instance.mStringTable;
		if (this.SaveSlot > 0 && instance.TalentSaveQueueCount > 0)
		{
			GUIManager.Instance.OpenOKCancelBox(this, mStringTable.GetStringByID(5893u), mStringTable.GetStringByID(936u), 2, 0, mStringTable.GetStringByID(3u), mStringTable.GetStringByID(4u));
		}
		else
		{
			instance.SaveTalentData[0].SaveIndex = 0;
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				door.CloseMenu(false);
			}
		}
	}

	// Token: 0x06001FC1 RID: 8129 RVA: 0x003C9B68 File Offset: 0x003C7D68
	public void OnButtonClick(UIButton sender)
	{
		DataManager instance = DataManager.Instance;
		StringTable mStringTable = instance.mStringTable;
		switch (sender.m_BtnID1)
		{
		case 0:
			this.SaveTalentCheckStep = 0;
			return;
		case 1:
			if (this.SaveSlot > 0)
			{
				if (instance.SaveTalentData[0].NoUseTalent == 0)
				{
					this.SetDefaultBtnEnable(true);
				}
				instance.ClearCurTalentSave();
				this.UpdateRoleTalentPoint();
				if (this.InitScroll == 1)
				{
					this.TalentTreePanel.GoTo(0);
				}
				this.SetResetOrLoadCurrentTalent();
			}
			else if (instance.NoUseTalent == 1)
			{
				GUIManager.Instance.AddHUDMessage(mStringTable.GetStringByID(1511u), 255, true);
			}
			else
			{
				GUIManager.Instance.UseOrSpend(1008, mStringTable.GetStringByID(1508u), 0, 0, 0, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
			}
			return;
		case 2:
			this.CheckSaveClose();
			return;
		case 4:
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door.OpenMenu(EGUIWindow.UI_TalentSave, 0, 0, false);
			return;
		}
		case 5:
			instance.OpenAllianceBox(36, 10, false, 0L);
			return;
		case 6:
			if (instance.NoUseTalent == 1)
			{
				GUIManager.Instance.AddHUDMessage(mStringTable.GetStringByID(10029u), 255, true);
			}
			else
			{
				instance.ClearCurTalentSave();
				if (this.CheckTalentData == null)
				{
					this.CheckTalentData = new byte[instance.AllTalentData.Length];
				}
				else
				{
					Array.Clear(this.CheckTalentData, 0, this.CheckTalentData.Length);
				}
				ushort num = 0;
				while ((int)num < instance.AllTalentData.Length)
				{
					if (instance.AllTalentData[(int)num] > 0)
					{
						if (this.CheckTalentData[(int)num] != 1)
						{
							ushort num2 = num + 1;
							TalentTbl recordByKey = instance.TalentData.GetRecordByKey(num2);
							this.TalentLevelup(ref recordByKey, num2, instance.GetTalentLevel(num2, 0), 0);
						}
					}
					num += 1;
				}
				this.SetResetOrLoadCurrentTalent();
			}
			return;
		}
		if ((this.CheckTechState((ushort)sender.m_BtnID2) & 32) > 0)
		{
			return;
		}
		this.OpenTalentInfo((ushort)sender.m_BtnID2);
		Debug.Log("TalentID=" + sender.m_BtnID2);
	}

	// Token: 0x06001FC2 RID: 8130 RVA: 0x003C9DCC File Offset: 0x003C7FCC
	private void TalentLevelup(ref TalentTbl talentData, ushort talentID, byte Lv, byte SaveIdx = 0)
	{
		DataManager instance = DataManager.Instance;
		if ((instance.CheckTalentState(talentID, this.SaveSlot, this.GetTalentLv(instance, talentID, SaveIdx)) & 1) > 0)
		{
			talentData = instance.TalentData.GetRecordByKey(talentData.NeedTalentID);
			this.TalentLevelup(ref talentData, talentData.TalentID, this.GetTalentLv(instance, talentData.TalentID, SaveIdx), SaveIdx);
		}
		if (this.CheckTalentData[(int)(talentID - 1)] == 0)
		{
			this.CheckTalentData[(int)(talentID - 1)] = 1;
			instance.sendTalentSaveQueue(talentID, this.SaveSlot, this.GetTalentLv(instance, talentID, SaveIdx), 0);
		}
	}

	// Token: 0x06001FC3 RID: 8131 RVA: 0x003C9E68 File Offset: 0x003C8068
	private byte GetTalentLv(DataManager DM, ushort talentID, byte SaveIdx = 0)
	{
		byte result;
		if (SaveIdx == 255)
		{
			result = this.tmpSaveTalent[(int)(talentID - 1)];
		}
		else
		{
			result = DM.GetTalentLevel(talentID, SaveIdx);
		}
		return result;
	}

	// Token: 0x06001FC4 RID: 8132 RVA: 0x003C9E9C File Offset: 0x003C809C
	public void CheckSaveTalentRule()
	{
		if ((this.SaveTalentCheckStep & 128) > 0)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		StringTable mStringTable = instance.mStringTable;
		if ((this.SaveTalentCheckStep & 1) == 0)
		{
			if (instance.SaveTalentData[0].TagName.Length > 0)
			{
				this.SaveTalentCheckStep |= 1;
				this.CheckSaveTalentRule();
			}
			else
			{
				this.SaveTalentCheckStep |= 128;
				GUIManager.Instance.OpenOKCancelBox(this, mStringTable.GetStringByID(5893u), mStringTable.GetStringByID(932u), 0, 1, mStringTable.GetStringByID(3u), mStringTable.GetStringByID(4u));
			}
		}
		else if ((this.SaveTalentCheckStep & 2) == 0)
		{
			if (instance.SaveTalentData[0].RoleTalentPoint == 0)
			{
				this.SaveTalentCheckStep |= 2;
				this.CheckSaveTalentRule();
			}
			else
			{
				this.SaveTalentCheckStep |= 128;
				GUIManager.Instance.OpenOKCancelBox(this, mStringTable.GetStringByID(5893u), mStringTable.GetStringByID(933u), 0, 2, mStringTable.GetStringByID(3u), mStringTable.GetStringByID(4u));
			}
		}
		else
		{
			this.SaveTalentCheckStep = byte.MaxValue;
			GUIManager.Instance.UseOrSpend(GameConstants.TalentSaveItemID, mStringTable.GetStringByID(934u), 0, (ushort)(this.SaveSlot - 1), (ushort)instance.TalentSaveQueueCount, UseOrSpendType.UST_DIAMOND_NORMAL, null, null, null, 0);
		}
	}

	// Token: 0x06001FC5 RID: 8133 RVA: 0x003CA018 File Offset: 0x003C8218
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
		if (arg1 == 2 && bOK)
		{
			DataManager.Instance.SaveTalentData[0].SaveIndex = 0;
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				door.CloseMenu(false);
			}
		}
		else if (arg1 == 0 && bOK)
		{
			this.SaveTalentCheckStep |= (byte)arg2;
			this.SaveTalentCheckStep = (byte)((int)this.SaveTalentCheckStep & -129);
		}
	}

	// Token: 0x06001FC6 RID: 8134 RVA: 0x003CA0A0 File Offset: 0x003C82A0
	public void OpenTalentInfo(ushort talentid)
	{
		if (this.InfoWindow == null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(this.m_AssetBundle.Load("UITalentInfo")) as GameObject;
			RectTransform rectTransform = gameObject.transform as RectTransform;
			rectTransform.SetParent(base.transform.GetChild(8));
			rectTransform.anchoredPosition3D = Vector3.zero;
			rectTransform.sizeDelta = Vector2.zero;
			rectTransform.localScale = Vector3.one;
			this.InfoWindow = new UITalentInfo(rectTransform, this.SaveSlot);
			this.InfoWindow.OnOpen((int)talentid, 0);
		}
		else
		{
			this.InfoWindow.UpdateUI((int)talentid, 0);
		}
	}

	// Token: 0x06001FC7 RID: 8135 RVA: 0x003CA144 File Offset: 0x003C8344
	public override void OnClose()
	{
		if (this.InfoWindow != null)
		{
			if (this.SaveSlot > 0 && this.SaveSlot == DataManager.Instance.SaveTalentData[0].SaveIndex)
			{
				this.InfoWindow.SetTalentSaveFlag();
			}
			this.InfoWindow.OnDestroy();
		}
		StringManager.Instance.DeSpawnString(this.TalentPointStr);
		if (this.TreeLayer != null)
		{
			for (int i = 0; i < this.TreeLayer.Length; i++)
			{
				this.TreeLayer[i].OnClose();
			}
		}
		if (this.PassFrame == 0 && this.InitScroll == 1)
		{
			GUIManager.Instance.TalentSaved[0] = (byte)this.TalentTreePanel.GetBeginIdx();
			GameConstants.GetBytes(this.TalentTreePanel.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition.y, GUIManager.Instance.TalentSaved, 1);
		}
		DataManager.Instance.CheckTalentSend();
	}

	// Token: 0x06001FC8 RID: 8136 RVA: 0x003CA250 File Offset: 0x003C8450
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.TreeLayer[panelObjectIdx].ItemTransform == null)
		{
			this.TreeLayer[panelObjectIdx].Init(item.transform, this, this.SaveSlot);
			return;
		}
		this.SetItemLayout(dataIdx, panelObjectIdx);
	}

	// Token: 0x06001FC9 RID: 8137 RVA: 0x003CA2A0 File Offset: 0x003C84A0
	public override void UpdateNetwork(byte[] meg)
	{
		if (this.PassFrame > 0)
		{
			return;
		}
		byte b = 0;
		NetworkNews networkNews = (NetworkNews)meg[0];
		switch (networkNews)
		{
		case NetworkNews.Login:
			this.UpdateRoleTalentPoint();
			b |= 3;
			break;
		default:
			if (networkNews != NetworkNews.Refresh_Item)
			{
				if (networkNews == NetworkNews.Refresh_Build)
				{
					if (!this.SaveTalentObj.activeSelf && GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level >= 15)
					{
						this.SaveTalentObj.SetActive(true);
					}
					if (this.InfoWindow != null)
					{
						this.InfoWindow.UpdateBtnStyle();
					}
					break;
				}
				if (networkNews != NetworkNews.Refresh_Technology)
				{
					if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
					{
						break;
					}
					this.TextRefresh();
					break;
				}
			}
			b |= 3;
			if (this.SaveSlot > 0)
			{
				this.SetDefaultBtnEnable(DataManager.Instance.TalentSaveQueueCount > 0);
			}
			break;
		case NetworkNews.Refresh:
			this.UpdateRoleTalentPoint();
			if (this.InfoWindow != null)
			{
				this.InfoWindow.UpdateRoleTalentPoint();
			}
			break;
		}
		if ((b & 1) > 0)
		{
			this.UpdateRoleTalentPoint();
		}
		if ((b & 2) > 0 && this.InitScroll == 1)
		{
			for (int i = 0; i < this.TreeLayer.Length; i++)
			{
				for (int j = 0; j < this.TreeLayer[i].Tech.Length; j++)
				{
					this.TreeLayer[i].Tech[j].UpdateState(b);
				}
				this.UpdateHorizontal(this.TreeLayer[i].DataIndex, this.TreeLayer[i].PanelIndex);
			}
		}
		if (b > 0 && this.InfoWindow != null && this.InfoWindow.ThisTransform.gameObject.activeSelf)
		{
			this.InfoWindow.UpdateTalentInfo();
		}
	}

	// Token: 0x06001FCA RID: 8138 RVA: 0x003CA498 File Offset: 0x003C8698
	private void TextRefresh()
	{
		for (int i = 0; i < this.TextRefleshArray.Length; i++)
		{
			this.TextRefleshArray[i].enabled = false;
			this.TextRefleshArray[i].enabled = true;
		}
		this.TalentPointText.enabled = false;
		this.TalentPointText.enabled = true;
		if (this.InitScroll == 1)
		{
			for (int j = 0; j < this.TreeLayer.Length; j++)
			{
				for (int k = 0; k < this.TreeLayer[j].Tech.Length; k++)
				{
					this.TreeLayer[j].Tech[k].TextRefresh();
				}
			}
		}
		if (this.InfoWindow != null)
		{
			this.InfoWindow.TextRefresh();
		}
	}

	// Token: 0x06001FCB RID: 8139 RVA: 0x003CA56C File Offset: 0x003C876C
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001FCC RID: 8140 RVA: 0x003CA570 File Offset: 0x003C8770
	public override void UpdateUI(int arg1, int arg2)
	{
		if (this.PassFrame > 0)
		{
			this.UpdateQueue[0] = 1;
			this.UpdateQueue[1] = arg1;
			this.UpdateQueue[2] = arg2;
			return;
		}
		DataManager instance = DataManager.Instance;
		switch (arg1 + 5)
		{
		case 0:
			if (this.SaveSlot > 0)
			{
				if (this.tmpSaveTalent == null)
				{
					this.tmpSaveTalent = new byte[instance.AllTalentData.Length];
				}
				Buffer.BlockCopy(instance.SaveTalentData[0].SaveTalentData, 0, this.tmpSaveTalent, 0, this.tmpSaveTalent.Length);
				instance.ClearCurTalentSave();
				if (this.CheckTalentData == null)
				{
					this.CheckTalentData = new byte[instance.AllTalentData.Length];
				}
				else
				{
					Array.Clear(this.CheckTalentData, 0, this.CheckTalentData.Length);
				}
				ushort num = 0;
				while ((int)num < this.tmpSaveTalent.Length)
				{
					if (this.tmpSaveTalent[(int)num] > 0)
					{
						if (this.CheckTalentData[(int)num] != 1)
						{
							ushort num2 = num + 1;
							TalentTbl recordByKey = instance.TalentData.GetRecordByKey(num2);
							this.TalentLevelup(ref recordByKey, num2, this.tmpSaveTalent[(int)num], byte.MaxValue);
						}
					}
					num += 1;
				}
			}
			break;
		case 1:
			this.UpdateRoleTalentPoint();
			if (this.SaveSlot > 0)
			{
				int num3 = instance.CompareTalentSave(this.SaveSlot);
				if (num3 == 1)
				{
					Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
					door.CloseMenu(false);
				}
				else
				{
					this.UpdateRoleTalentPoint();
				}
			}
			break;
		case 2:
		{
			Door door2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			door2.CloseMenu(false);
			break;
		}
		case 3:
			this.TextRefleshArray[0].text = instance.SaveTalentData[0].GetTagName().ToString();
			this.TextRefleshArray[0].SetAllDirty();
			this.TextRefleshArray[0].cachedTextGenerator.Invalidate();
			this.TextRefleshArray[0].cachedTextGeneratorForLayout.Invalidate();
			this.ChangeNameRect.anchoredPosition = new Vector2(this.TextRefleshArray[0].preferredWidth * 0.5f + 25f, this.ChangeNameRect.anchoredPosition.y);
			if (instance.SaveTalentData[0].TagName.Length > 0)
			{
				this.SetDefaultBtnEnable(true);
			}
			break;
		case 4:
			if (this.InitScroll == 1)
			{
				this.UpdateGraphic();
				this.GraphicLoaded = 1;
			}
			else
			{
				this.GraphicLoaded = 2;
			}
			break;
		default:
			this.SetResetOrLoadCurrentTalent();
			this.CheckSendTime = 2f;
			break;
		}
	}

	// Token: 0x06001FCD RID: 8141 RVA: 0x003CA838 File Offset: 0x003C8A38
	private void UpdateGraphic()
	{
		GUIManager instance = GUIManager.Instance;
		for (int i = 0; i < this.TreeLayer.Length; i++)
		{
			for (int j = 0; j < this.TreeLayer[i].Tech.Length; j++)
			{
				if (this.TreeLayer[i].Tech[j].FrameTransform)
				{
					this.TreeLayer[i].Tech[j].TechIcon.sprite = instance.GetTechSprite(this.TreeLayer[i].Tech[j].GraphicID);
				}
				this.TreeLayer[i].Tech[j].TechIcon.material = instance.TechMaterial;
				this.TreeLayer[i].Tech[j].TechIcon.enabled = true;
			}
		}
		if (this.InfoWindow != null)
		{
			this.InfoWindow.UpdateUI(-1, 0);
		}
	}

	// Token: 0x06001FCE RID: 8142 RVA: 0x003CA940 File Offset: 0x003C8B40
	public void Update()
	{
		if (this.PassFrame > 0)
		{
			this.PassFrame -= 1;
			if (this.PassFrame == 0)
			{
				this.MaxItemCount = Mathf.Min(this.MaxItemCount, this.DataCount);
				this.HorzontalShowFlag = new ushort[this.DataCount];
				this.TreeLayer = new UITalent.ItemEdit[this.MaxItemCount];
				if (this.DelayLoadScroll == 0)
				{
					this.initTalentPanel();
					this.TalentTreePanel.gameObject.SetActive(true);
					this.TextRefresh();
				}
				if (this.InitScroll == 1 && this.UpdateQueue[0] == 1)
				{
					this.UpdateUI(this.UpdateQueue[1], this.UpdateQueue[2]);
					Array.Clear(this.UpdateQueue, 0, this.UpdateQueue.Length);
				}
				ushort num = GameConstants.ConvertBytesToUShort(GUIManager.Instance.TalentSaved, 5);
				if (num > 0)
				{
					this.OpenTalentInfo(num);
				}
			}
		}
		else if (this.DelayLoadScroll > 0)
		{
			this.DelayLoadScroll -= 1;
			if (this.DelayLoadScroll == 0)
			{
				this.initTalentPanel();
				this.TalentTreePanel.gameObject.SetActive(true);
				if (this.InitScroll == 1 && this.UpdateQueue[0] == 1)
				{
					this.UpdateUI(this.UpdateQueue[1], this.UpdateQueue[2]);
					Array.Clear(this.UpdateQueue, 0, this.UpdateQueue.Length);
				}
				if (this.GraphicLoaded == 2)
				{
					this.UpdateGraphic();
					this.GraphicLoaded = 1;
				}
				this.TextRefresh();
			}
		}
		else if (this.InfoWindow != null)
		{
			this.CheckSendTime -= Time.deltaTime;
			if (this.CheckSendTime < 0f)
			{
				this.CheckSendTime = 2f;
				DataManager.Instance.CheckTalentSend();
			}
			this.InfoWindow.Update();
		}
		if (this.SaveTalentCheckStep < 255)
		{
			this.CheckSaveTalentRule();
		}
	}

	// Token: 0x06001FCF RID: 8143 RVA: 0x003CAB44 File Offset: 0x003C8D44
	public void initTalentPanel()
	{
		byte b = 0;
		while ((int)b < this.MaxItemCount)
		{
			this.ItemsHeight.Add(242f);
			this.ItemIndex.Add((ushort)b);
			b += 1;
		}
		this.TalentTreePanel.IntiScrollPanel(446f, 0f, 0f, this.ItemsHeight, this.MaxItemCount, this);
		if (this.DataCount > this.MaxItemCount)
		{
			for (int i = this.MaxItemCount; i < this.DataCount; i++)
			{
				this.ItemsHeight.Add(242f);
				this.ItemIndex.Add((ushort)i);
			}
		}
		this.TalentTreePanel.AddNewDataHeight(this.ItemsHeight, true, true);
		ushort num = GameConstants.ConvertBytesToUShort(GUIManager.Instance.TalentSaved, 5);
		if (this.SaveSlot == 0 || num > 0)
		{
			byte b2 = GUIManager.Instance.TalentSaved[0];
			float height = GameConstants.ConvertBytesToFloat(GUIManager.Instance.TalentSaved, 1);
			this.TalentTreePanel.GoTo((int)b2, height);
			this.UpdateTopLayer((int)b2);
		}
		this.InitScroll = 1;
	}

	// Token: 0x06001FD0 RID: 8144 RVA: 0x003CAC68 File Offset: 0x003C8E68
	private void UpdateTopLayer(int begin)
	{
		if (begin == 0)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		for (int i = 0; i < this.TreeLayer.Length; i++)
		{
			if (this.TreeLayer[i].DataIndex == begin)
			{
				for (int j = 0; j < this.TreeLayer[i].Tech.Length; j++)
				{
					if (this.TreeLayer[i].Tech[j].TechTransform.gameObject.activeSelf && this.TreeLayer[i].Tech[j].TechBtn.m_BtnID2 != 0)
					{
						if (instance.GetTalentLevel((ushort)this.TreeLayer[i].Tech[j].TechBtn.m_BtnID2, 0) > 0 || (this.CheckTechState((ushort)this.TreeLayer[i].Tech[j].TechBtn.m_BtnID2) & 1) == 0)
						{
							this.TreeLayer[i].Tech[j].Lines[2].LineImage.sprite = this.SpriteArray.GetSprite(2);
						}
					}
				}
				break;
			}
		}
	}

	// Token: 0x06001FD1 RID: 8145 RVA: 0x003CADB4 File Offset: 0x003C8FB4
	public void OnButtonDown(UIButtonHint sender)
	{
		AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
		sender.GetTipPosition(this.HintTrans, UIButtonHint.ePosition.Original, null);
		this.HintTrans.gameObject.SetActive(true);
	}

	// Token: 0x06001FD2 RID: 8146 RVA: 0x003CADF4 File Offset: 0x003C8FF4
	public void OnButtonUp(UIButtonHint sender)
	{
		this.HintTrans.gameObject.SetActive(false);
	}

	// Token: 0x04006429 RID: 25641
	public int DataCount;

	// Token: 0x0400642A RID: 25642
	private UISpritesArray SpriteArray;

	// Token: 0x0400642B RID: 25643
	private int MaxItemCount = 3;

	// Token: 0x0400642C RID: 25644
	private float CheckSendTime = 2f;

	// Token: 0x0400642D RID: 25645
	private readonly float[] Skillpos = new float[]
	{
		118.37f,
		312.37f,
		506.37f,
		21.87f,
		215.87f,
		412.87f,
		603.87f
	};

	// Token: 0x0400642E RID: 25646
	private readonly float[][] HorizontalPW = new float[][]
	{
		new float[]
		{
			295f,
			201f
		},
		new float[]
		{
			195f,
			395f
		},
		new float[]
		{
			195f,
			201f
		},
		new float[]
		{
			388f,
			201f
		},
		new float[]
		{
			102f,
			588f
		},
		new float[]
		{
			102f,
			392f
		},
		new float[]
		{
			290f,
			392f
		},
		new float[]
		{
			98f,
			202f
		},
		new float[]
		{
			291f,
			202f
		},
		new float[]
		{
			486f,
			202f
		},
		new float[]
		{
			98f,
			202f
		}
	};

	// Token: 0x0400642F RID: 25647
	private ScrollPanel TalentTreePanel;

	// Token: 0x04006430 RID: 25648
	protected List<float> ItemsHeight = new List<float>();

	// Token: 0x04006431 RID: 25649
	protected List<ushort> ItemIndex = new List<ushort>();

	// Token: 0x04006432 RID: 25650
	private ushort[] HorzontalShowFlag;

	// Token: 0x04006433 RID: 25651
	private UITalentInfo InfoWindow;

	// Token: 0x04006434 RID: 25652
	private UIText TalentPointText;

	// Token: 0x04006435 RID: 25653
	private UIText[] TextRefleshArray = new UIText[5];

	// Token: 0x04006436 RID: 25654
	private CString TalentPointStr;

	// Token: 0x04006437 RID: 25655
	private RectTransform HintTrans;

	// Token: 0x04006438 RID: 25656
	private RectTransform ChangeNameRect;

	// Token: 0x04006439 RID: 25657
	private GameObject SaveTalentObj;

	// Token: 0x0400643A RID: 25658
	private byte SaveSlot;

	// Token: 0x0400643B RID: 25659
	private byte CheckSaveFlag;

	// Token: 0x0400643C RID: 25660
	private byte SaveTalentCheckStep = byte.MaxValue;

	// Token: 0x0400643D RID: 25661
	private UIButton DefaultBtn;

	// Token: 0x0400643E RID: 25662
	private UIButton ResetBtn;

	// Token: 0x0400643F RID: 25663
	private Image DefaultImg;

	// Token: 0x04006440 RID: 25664
	private byte[] CheckTalentData;

	// Token: 0x04006441 RID: 25665
	private byte[] tmpSaveTalent;

	// Token: 0x04006442 RID: 25666
	private UITalent.ItemEdit[] TreeLayer;

	// Token: 0x04006443 RID: 25667
	private byte PassFrame = 1;

	// Token: 0x04006444 RID: 25668
	private byte DelayLoadScroll;

	// Token: 0x04006445 RID: 25669
	private byte InitScroll;

	// Token: 0x04006446 RID: 25670
	private byte GraphicLoaded;

	// Token: 0x04006447 RID: 25671
	private int[] UpdateQueue = new int[3];

	// Token: 0x0200066C RID: 1644
	public enum TechSprite
	{
		// Token: 0x04006449 RID: 25673
		FrameFull,
		// Token: 0x0400644A RID: 25674
		Line,
		// Token: 0x0400644B RID: 25675
		LineOn,
		// Token: 0x0400644C RID: 25676
		Linel,
		// Token: 0x0400644D RID: 25677
		LinelOn,
		// Token: 0x0400644E RID: 25678
		Liner,
		// Token: 0x0400644F RID: 25679
		LinerOn,
		// Token: 0x04006450 RID: 25680
		Point,
		// Token: 0x04006451 RID: 25681
		PointOn
	}

	// Token: 0x0200066D RID: 1645
	private enum UIControl
	{
		// Token: 0x04006453 RID: 25683
		Background,
		// Token: 0x04006454 RID: 25684
		ReTitleBtn,
		// Token: 0x04006455 RID: 25685
		DefaultBtn,
		// Token: 0x04006456 RID: 25686
		ResetBtn,
		// Token: 0x04006457 RID: 25687
		TalentPoint,
		// Token: 0x04006458 RID: 25688
		Scroll,
		// Token: 0x04006459 RID: 25689
		Item,
		// Token: 0x0400645A RID: 25690
		Close,
		// Token: 0x0400645B RID: 25691
		InfoLink,
		// Token: 0x0400645C RID: 25692
		Hint
	}

	// Token: 0x0200066E RID: 1646
	private enum ItemControl
	{
		// Token: 0x0400645E RID: 25694
		HorizontalLineDown0,
		// Token: 0x0400645F RID: 25695
		HorizontalLineDown1,
		// Token: 0x04006460 RID: 25696
		Skill1,
		// Token: 0x04006461 RID: 25697
		Skill2,
		// Token: 0x04006462 RID: 25698
		Skill3,
		// Token: 0x04006463 RID: 25699
		Skill4,
		// Token: 0x04006464 RID: 25700
		Node
	}

	// Token: 0x0200066F RID: 1647
	private enum LeaveControl
	{
		// Token: 0x04006466 RID: 25702
		Direction,
		// Token: 0x04006467 RID: 25703
		SkillPic,
		// Token: 0x04006468 RID: 25704
		Black,
		// Token: 0x04006469 RID: 25705
		Frame,
		// Token: 0x0400646A RID: 25706
		FrameFull,
		// Token: 0x0400646B RID: 25707
		Name,
		// Token: 0x0400646C RID: 25708
		LvText
	}

	// Token: 0x02000670 RID: 1648
	private enum eFrame
	{
		// Token: 0x0400646E RID: 25710
		Lock,
		// Token: 0x0400646F RID: 25711
		Degree
	}

	// Token: 0x02000671 RID: 1649
	private enum ClickType
	{
		// Token: 0x04006471 RID: 25713
		SaveSlot,
		// Token: 0x04006472 RID: 25714
		Reset,
		// Token: 0x04006473 RID: 25715
		Close,
		// Token: 0x04006474 RID: 25716
		Tech,
		// Token: 0x04006475 RID: 25717
		Save,
		// Token: 0x04006476 RID: 25718
		ChangeTitle,
		// Token: 0x04006477 RID: 25719
		LoadCurrentTalent
	}

	// Token: 0x02000672 RID: 1650
	public enum NeighborWay
	{
		// Token: 0x04006479 RID: 25721
		Right,
		// Token: 0x0400647A RID: 25722
		Left,
		// Token: 0x0400647B RID: 25723
		Up,
		// Token: 0x0400647C RID: 25724
		Down
	}

	// Token: 0x02000673 RID: 1651
	public enum eLine
	{
		// Token: 0x0400647E RID: 25726
		Right,
		// Token: 0x0400647F RID: 25727
		Left,
		// Token: 0x04006480 RID: 25728
		Up,
		// Token: 0x04006481 RID: 25729
		Down
	}

	// Token: 0x02000674 RID: 1652
	private class TechItem
	{
		// Token: 0x06001FD4 RID: 8148 RVA: 0x003CAE1C File Offset: 0x003C901C
		public void Init(Transform transform, IUIButtonClickHandler handler, byte SaveSlot)
		{
			this.SaveSlot = SaveSlot;
			this.TechTransform = (transform as RectTransform);
			this.TechIconTrans = transform.GetChild(1).GetComponent<RectTransform>();
			this.TechIcon = transform.GetChild(1).GetComponent<Image>();
			this.TechBtn = transform.GetChild(1).GetComponent<UIButton>();
			this.BlackFrame = transform.GetChild(2);
			this.Direction = transform.GetChild(0);
			for (int i = 0; i < this.Lines.Length; i++)
			{
				this.Lines[i].LintTrans = transform.GetChild(0).GetChild(i).GetComponent<RectTransform>();
				this.Lines[i].LineImage = this.Lines[i].LintTrans.GetComponent<Image>();
				this.Lines[i].Pos = this.Lines[i].LintTrans.anchoredPosition;
				this.Lines[i].Size = this.Lines[i].LintTrans.sizeDelta;
			}
			if (GUIManager.Instance.IsArabic)
			{
				this.TechBtn.transform.localScale = new Vector3(-1f, 1f, 1f);
			}
			this.TechBtn.m_Handler = handler;
			this.FrameTransform = transform.GetChild(3);
			this.Lock = transform.GetChild(3).GetChild(0);
			this.Degree = transform.GetChild(3).GetChild(1).GetComponent<RectTransform>();
			this.Level = transform.GetChild(6).GetComponent<UIText>();
			this.Name = transform.GetChild(5).GetComponent<UIText>();
			this.FrameTrans = transform.GetChild(3).GetComponent<RectTransform>();
			this.FrameFullTrans = transform.GetChild(4).GetComponent<RectTransform>();
			this.FrameFull = this.FrameFullTrans.GetComponent<Image>();
			this.FrameFullSize = this.FrameFullTrans.sizeDelta;
			this.TechNameStr = StringManager.Instance.SpawnString(30);
			this.TechLvStr = StringManager.Instance.SpawnString(30);
		}

		// Token: 0x06001FD5 RID: 8149 RVA: 0x003CB044 File Offset: 0x003C9244
		public void SetItemStyle(ref UISpritesArray SpriteArray, ushort TechID)
		{
			this.SpriteArr = SpriteArray;
			if (TechID == 1001)
			{
				this.Direction.gameObject.SetActive(false);
				this.FrameTransform.gameObject.SetActive(false);
				this.TechIcon.gameObject.SetActive(false);
				this.Name.text = string.Empty;
				this.Level.text = string.Empty;
				this.FrameFull.sprite = this.SpriteArr.GetSprite(1);
				this.FrameFullTrans.anchoredPosition = new Vector2(84.5f, -238.5f);
				Quaternion localRotation = this.FrameFullTrans.localRotation;
				localRotation.eulerAngles = new Vector3(0f, 0f, 90f);
				this.FrameFullTrans.localRotation = localRotation;
				this.FrameFullTrans.sizeDelta = new Vector2(246f, 31f);
			}
			else if (TechID == 1002)
			{
				this.Direction.gameObject.SetActive(true);
				this.FrameTransform.gameObject.SetActive(false);
				this.TechIcon.gameObject.SetActive(false);
				this.Lines[0].SetActive(true);
				this.Lines[3].SetActive(true);
				this.Lines[2].SetActive(false);
				this.Lines[1].SetActive(false);
				this.FrameFull.sprite = this.SpriteArr.GetSprite(3);
				this.FrameFull.SetNativeSize();
				this.FrameFullTrans.anchoredPosition = new Vector2(84f, 81f);
				this.Lines[0].LintTrans.anchoredPosition = new Vector2(122.7f, -85f);
				this.Lines[0].LintTrans.sizeDelta = new Vector2(112.8f, 30f);
				this.Lines[3].ResetPos();
				this.Lines[3].LintTrans.sizeDelta = new Vector2(124f, 30f);
				this.Level.text = string.Empty;
				this.Name.text = string.Empty;
			}
			else if (TechID == 1003)
			{
				this.Direction.gameObject.SetActive(true);
				this.FrameTransform.gameObject.SetActive(false);
				this.TechIcon.gameObject.SetActive(false);
				this.Lines[0].SetActive(false);
				this.Lines[3].SetActive(true);
				this.Lines[2].SetActive(false);
				this.Lines[1].SetActive(true);
				this.FrameFull.sprite = this.SpriteArr.GetSprite(5);
				this.FrameFull.SetNativeSize();
				this.FrameFullTrans.anchoredPosition = new Vector2(75f, 81f);
				this.Lines[1].ResetPos();
				this.Lines[1].LintTrans.sizeDelta = new Vector2(112.5f, 30f);
				this.Lines[3].ResetPos();
				this.Lines[3].LintTrans.sizeDelta = new Vector2(124f, 30f);
				this.Level.text = string.Empty;
				this.Name.text = string.Empty;
			}
			else
			{
				this.FrameTransform.gameObject.SetActive(true);
				this.TechIcon.gameObject.SetActive(true);
				this.Direction.gameObject.SetActive(true);
				this.FrameFull.sprite = this.SpriteArr.GetSprite(0);
				this.FrameFullTrans.anchoredPosition = Vector2.zero;
				this.FrameFullTrans.sizeDelta = this.FrameFullSize;
				for (int i = 0; i < this.Lines.Length; i++)
				{
					this.Lines[i].ResetPos();
					if (i != 2)
					{
						this.Lines[i].LineImage.sprite = this.SpriteArr.GetSprite(1);
					}
				}
			}
			if (this.TechBtn.m_BtnID2 == 1001)
			{
				Quaternion localRotation2 = this.FrameFullTrans.localRotation;
				localRotation2.eulerAngles = Vector3.zero;
				this.FrameFullTrans.localRotation = localRotation2;
			}
		}

		// Token: 0x06001FD6 RID: 8150 RVA: 0x003CB4EC File Offset: 0x003C96EC
		public void SetTechID(ushort TechID)
		{
			this.TechBtn.m_BtnID2 = (int)TechID;
			this.State = this.CheckTechState();
			this.UpdateState(7);
		}

		// Token: 0x06001FD7 RID: 8151 RVA: 0x003CB510 File Offset: 0x003C9710
		public void SetTechInfo(ushort TalentID)
		{
			DataManager instance = DataManager.Instance;
			TalentTbl recordByKey = instance.TalentData.GetRecordByKey(TalentID);
			this.TechNameStr.ClearString();
			this.TechLvStr.ClearString();
			this.TechNameStr.Insert(0, instance.mStringTable.GetStringByID((uint)recordByKey.NameID), -1);
			this.Name.text = this.TechNameStr.ToString();
			this.Name.SetAllDirty();
			this.Name.cachedTextGenerator.Invalidate();
			byte talentLevel = instance.GetTalentLevel(TalentID, this.SaveSlot);
			float num = 163f / (float)recordByKey.LevelMax;
			this.TechLvStr.IntToFormat((long)talentLevel, 1, false);
			this.TechLvStr.IntToFormat((long)recordByKey.LevelMax, 1, false);
			if (GUIManager.Instance.IsArabic)
			{
				this.TechLvStr.AppendFormat("{1}/{0}");
			}
			else
			{
				this.TechLvStr.AppendFormat("{0}/{1}");
			}
			this.Level.text = this.TechLvStr.ToString();
			this.Level.SetAllDirty();
			this.Level.cachedTextGenerator.Invalidate();
			Vector2 sizeDelta = this.Degree.sizeDelta;
			sizeDelta.x = num * (float)talentLevel;
			this.Degree.sizeDelta = sizeDelta;
			this.GraphicID = recordByKey.Graphic;
			if (GUIManager.Instance.TechMaterial == null)
			{
				this.TechIcon.enabled = false;
			}
			else
			{
				this.TechIcon.sprite = GUIManager.Instance.GetTechSprite(this.GraphicID);
				this.TechIcon.material = GUIManager.Instance.TechMaterial;
				this.TechIcon.enabled = true;
			}
		}

		// Token: 0x06001FD8 RID: 8152 RVA: 0x003CB6D4 File Offset: 0x003C98D4
		public byte CheckTechState()
		{
			ushort num = (ushort)this.TechBtn.m_BtnID2;
			if (num >= 1001)
			{
				num = (ushort)this.TechBtn.m_BtnID3;
			}
			return DataManager.Instance.CheckTalentState(num, this.SaveSlot, 1);
		}

		// Token: 0x06001FD9 RID: 8153 RVA: 0x003CB718 File Offset: 0x003C9918
		public void UpdateState(byte Kind)
		{
			bool flag = false;
			this.State = this.CheckTechState();
			this.SetTechInfo((ushort)this.TechBtn.m_BtnID2);
			if ((this.State & 4) > 0)
			{
				this.BlackFrame.gameObject.SetActive(true);
				this.Lock.gameObject.SetActive(true);
			}
			else if ((this.State & 16) > 0)
			{
				flag = true;
			}
			else
			{
				this.BlackFrame.gameObject.SetActive(false);
				this.Lock.gameObject.SetActive(false);
			}
			this.FrameFullTrans.gameObject.SetActive(flag);
			this.FrameTrans.gameObject.SetActive(!flag);
			if ((this.State & 1) > 0)
			{
				this.BlackFrame.gameObject.SetActive(true);
			}
			else
			{
				this.BlackFrame.gameObject.SetActive(false);
			}
		}

		// Token: 0x06001FDA RID: 8154 RVA: 0x003CB80C File Offset: 0x003C9A0C
		public void OnClose()
		{
			StringManager.Instance.DeSpawnString(this.TechNameStr);
			StringManager.Instance.DeSpawnString(this.TechLvStr);
		}

		// Token: 0x06001FDB RID: 8155 RVA: 0x003CB83C File Offset: 0x003C9A3C
		public void TextRefresh()
		{
			this.Level.enabled = false;
			this.Name.enabled = false;
			this.Level.enabled = true;
			this.Name.enabled = true;
		}

		// Token: 0x04006482 RID: 25730
		public RectTransform TechTransform;

		// Token: 0x04006483 RID: 25731
		public RectTransform TechIconTrans;

		// Token: 0x04006484 RID: 25732
		public RectTransform Degree;

		// Token: 0x04006485 RID: 25733
		public RectTransform FrameFullTrans;

		// Token: 0x04006486 RID: 25734
		public RectTransform FrameTrans;

		// Token: 0x04006487 RID: 25735
		public Transform BlackFrame;

		// Token: 0x04006488 RID: 25736
		public Transform Lock;

		// Token: 0x04006489 RID: 25737
		public Transform FrameTransform;

		// Token: 0x0400648A RID: 25738
		public Transform Direction;

		// Token: 0x0400648B RID: 25739
		public Image TechIcon;

		// Token: 0x0400648C RID: 25740
		public Image FrameFull;

		// Token: 0x0400648D RID: 25741
		public UIButton TechBtn;

		// Token: 0x0400648E RID: 25742
		public UIText Level;

		// Token: 0x0400648F RID: 25743
		public UIText Name;

		// Token: 0x04006490 RID: 25744
		private CString TechNameStr;

		// Token: 0x04006491 RID: 25745
		private CString TechLvStr;

		// Token: 0x04006492 RID: 25746
		public ushort GraphicID;

		// Token: 0x04006493 RID: 25747
		private Vector2 FrameFullSize;

		// Token: 0x04006494 RID: 25748
		public UITalent.TechItem._LineInfo[] Lines = new UITalent.TechItem._LineInfo[4];

		// Token: 0x04006495 RID: 25749
		private byte State;

		// Token: 0x04006496 RID: 25750
		private byte SaveSlot;

		// Token: 0x04006497 RID: 25751
		private UISpritesArray SpriteArr;

		// Token: 0x02000675 RID: 1653
		public struct _LineInfo
		{
			// Token: 0x06001FDC RID: 8156 RVA: 0x003CB87C File Offset: 0x003C9A7C
			public void SetActive(bool bActive)
			{
				this.LintTrans.gameObject.SetActive(bActive);
			}

			// Token: 0x06001FDD RID: 8157 RVA: 0x003CB890 File Offset: 0x003C9A90
			public void ResetPos()
			{
				this.LintTrans.anchoredPosition = this.Pos;
				this.LintTrans.sizeDelta = this.Size;
			}

			// Token: 0x04006498 RID: 25752
			public Image LineImage;

			// Token: 0x04006499 RID: 25753
			public RectTransform LintTrans;

			// Token: 0x0400649A RID: 25754
			public Vector2 Pos;

			// Token: 0x0400649B RID: 25755
			public Vector2 Size;
		}
	}

	// Token: 0x02000676 RID: 1654
	private struct LineItem
	{
		// Token: 0x06001FDE RID: 8158 RVA: 0x003CB8C0 File Offset: 0x003C9AC0
		public void Init(Transform transform)
		{
			this.LineTrans = transform.GetComponent<RectTransform>();
			this.LineImg = transform.GetComponent<Image>();
		}

		// Token: 0x0400649C RID: 25756
		public RectTransform LineTrans;

		// Token: 0x0400649D RID: 25757
		public Image LineImg;
	}

	// Token: 0x02000677 RID: 1655
	private struct ItemEdit
	{
		// Token: 0x06001FDF RID: 8159 RVA: 0x003CB8DC File Offset: 0x003C9ADC
		public void Init(Transform transform, IUIButtonClickHandler handler, byte SaveSlot)
		{
			this.ItemTransform = (transform as RectTransform);
			this.Tech = new UITalent.TechItem[4];
			this.Line = new UITalent.LineItem[2];
			this.Node = new Image[14];
			for (int i = 0; i < this.Tech.Length; i++)
			{
				this.Tech[i] = new UITalent.TechItem();
				this.Tech[i].Init(transform.GetChild(2 + i), handler, SaveSlot);
			}
			for (int j = 0; j < this.Line.Length; j++)
			{
				this.Line[j].Init(transform.GetChild(j));
			}
			for (int k = 0; k < this.Node.Length; k++)
			{
				this.Node[k] = transform.GetChild(6).GetChild(k).GetComponent<Image>();
			}
		}

		// Token: 0x06001FE0 RID: 8160 RVA: 0x003CB9BC File Offset: 0x003C9BBC
		public void OnClose()
		{
			if (this.Tech == null)
			{
				return;
			}
			for (int i = 0; i < this.Tech.Length; i++)
			{
				this.Tech[i].OnClose();
			}
		}

		// Token: 0x0400649E RID: 25758
		public int DataIndex;

		// Token: 0x0400649F RID: 25759
		public int PanelIndex;

		// Token: 0x040064A0 RID: 25760
		public RectTransform ItemTransform;

		// Token: 0x040064A1 RID: 25761
		public UITalent.TechItem[] Tech;

		// Token: 0x040064A2 RID: 25762
		public UITalent.LineItem[] Line;

		// Token: 0x040064A3 RID: 25763
		public Image[] Node;
	}

	// Token: 0x02000678 RID: 1656
	private enum SpriteArrayIdx
	{
		// Token: 0x040064A5 RID: 25765
		BoxOn,
		// Token: 0x040064A6 RID: 25766
		Line,
		// Token: 0x040064A7 RID: 25767
		LineOn,
		// Token: 0x040064A8 RID: 25768
		Linel,
		// Token: 0x040064A9 RID: 25769
		LinelOn,
		// Token: 0x040064AA RID: 25770
		Liner,
		// Token: 0x040064AB RID: 25771
		LinerOn,
		// Token: 0x040064AC RID: 25772
		Linepoint,
		// Token: 0x040064AD RID: 25773
		LinepointOn
	}
}
