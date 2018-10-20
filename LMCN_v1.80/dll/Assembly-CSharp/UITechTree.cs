using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000685 RID: 1669
public class UITechTree : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06002014 RID: 8212 RVA: 0x003CE434 File Offset: 0x003CC634
	public override void OnOpen(int arg1, int arg2)
	{
		if (DataManager.StageDataController.StageRecord[2] < 8)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		}
		else
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
		}
		GUIManager.Instance.SetTalentIconSprite("UITechIcon", this.m_eWindow);
		Font ttffont = GUIManager.Instance.GetTTFFont();
		DataManager instance = DataManager.Instance;
		this.TreeKind = (byte)(arg1 & 255);
		if ((arg1 & 32768) > 0)
		{
			this.DelayLoadScroll = 2;
		}
		instance.GetTechTreeDataRange(this.TreeKind, out this.DataStart, out this.DataCount);
		this.TitleText = base.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
		this.TitleText.font = ttffont;
		this.TitleText.text = instance.mStringTable.GetStringByID((uint)arg2);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			base.transform.GetChild(2).GetComponent<CustomImage>().enabled = false;
		}
		else
		{
			base.transform.GetChild(2).GetComponent<CustomImage>().hander = GUIManager.Instance.m_ItemInfo;
		}
		base.transform.GetChild(2).GetChild(0).GetComponent<CustomImage>().hander = GUIManager.Instance.m_ItemInfo;
		this.SpriteArray = base.transform.GetChild(1).GetComponent<UISpritesArray>();
		Transform child = base.transform.GetChild(3);
		this.TechTreePanel = base.transform.GetChild(1).GetComponent<ScrollPanel>();
		UIButton component = base.transform.GetChild(2).GetChild(0).GetComponent<UIButton>();
		component.m_Handler = this;
		component.m_BtnID1 = 0;
		component = child.GetChild(0).GetChild(0).GetComponent<UIButton>();
		component.m_BtnID1 = 1;
		component = child.GetChild(1).GetChild(0).GetComponent<UIButton>();
		component.m_BtnID1 = 1;
		component = child.GetChild(2).GetChild(0).GetComponent<UIButton>();
		component.m_BtnID1 = 1;
		component = child.GetChild(3).GetChild(0).GetComponent<UIButton>();
		component.m_BtnID1 = 1;
		child.GetChild(0).GetChild(7).GetComponent<UIText>().font = ttffont;
		child.GetChild(0).GetChild(8).GetComponent<UIText>().font = ttffont;
		child.GetChild(1).GetChild(7).GetComponent<UIText>().font = ttffont;
		child.GetChild(1).GetChild(8).GetComponent<UIText>().font = ttffont;
		child.GetChild(2).GetChild(7).GetComponent<UIText>().font = ttffont;
		child.GetChild(2).GetChild(8).GetComponent<UIText>().font = ttffont;
		child.GetChild(3).GetChild(7).GetComponent<UIText>().font = ttffont;
		child.GetChild(3).GetChild(8).GetComponent<UIText>().font = ttffont;
		this.BlackFrameTrans = base.transform.GetChild(0).GetChild(0);
		this.NeedLvStr = StringManager.Instance.SpawnString(30);
		this.NeedLvText = this.BlackFrameTrans.GetChild(0).GetChild(0).GetComponent<UIText>();
		this.NeedLvText.font = ttffont;
		GameConstants.ArrayFill<ushort>(this.HorzontalShowFlag, 0);
		GameConstants.ArrayFill<ushort>(this.HorzontalShowFlag2, 0);
	}

	// Token: 0x06002015 RID: 8213 RVA: 0x003CE780 File Offset: 0x003CC980
	public void SetItemLayout(int dataIndex, int panelIndex)
	{
		TechTreeLayoutTbl recordByIndex = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex);
		this.TreeLayer[panelIndex].DataIndex = dataIndex;
		this.TreeLayer[panelIndex].PanelIndex = panelIndex;
		switch (recordByIndex.TechCount)
		{
		case 1:
		{
			this.SetTechItemLayout(dataIndex, panelIndex, 0, recordByIndex.TechID1, recordByIndex.VerticalExtend1, recordByIndex.HorizontalExtend1);
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
			this.SetTechItemLayout(dataIndex, panelIndex, 0, recordByIndex.TechID1, recordByIndex.VerticalExtend1, recordByIndex.HorizontalExtend1);
			Vector2 anchoredPosition = this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[4];
			this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition = anchoredPosition;
			this.SetTechItemLayout(dataIndex, panelIndex, 1, recordByIndex.TechID2, recordByIndex.VerticalExtend2, recordByIndex.HorizontalExtend2);
			anchoredPosition = this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[5];
			this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition = anchoredPosition;
			this.TreeLayer[panelIndex].Tech[2].TechTransform.gameObject.SetActive(false);
			this.TreeLayer[panelIndex].Tech[3].TechTransform.gameObject.SetActive(false);
			break;
		}
		case 3:
		{
			this.SetTechItemLayout(dataIndex, panelIndex, 0, recordByIndex.TechID1, recordByIndex.VerticalExtend1, recordByIndex.HorizontalExtend1);
			Vector2 anchoredPosition = this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[0];
			this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition = anchoredPosition;
			this.SetTechItemLayout(dataIndex, panelIndex, 1, recordByIndex.TechID2, recordByIndex.VerticalExtend2, recordByIndex.HorizontalExtend2);
			anchoredPosition = this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[1];
			this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition = anchoredPosition;
			this.SetTechItemLayout(dataIndex, panelIndex, 2, recordByIndex.TechID3, recordByIndex.VerticalExtend3, recordByIndex.HorizontalExtend3);
			anchoredPosition = this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[2];
			this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition = anchoredPosition;
			this.TreeLayer[panelIndex].Tech[3].TechTransform.gameObject.SetActive(false);
			break;
		}
		case 4:
		{
			this.SetTechItemLayout(dataIndex, panelIndex, 0, recordByIndex.TechID1, recordByIndex.VerticalExtend1, recordByIndex.HorizontalExtend1);
			Vector2 anchoredPosition = this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[3];
			this.TreeLayer[panelIndex].Tech[0].TechTransform.anchoredPosition = anchoredPosition;
			this.SetTechItemLayout(dataIndex, panelIndex, 1, recordByIndex.TechID2, recordByIndex.VerticalExtend2, recordByIndex.HorizontalExtend2);
			anchoredPosition = this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[4];
			this.TreeLayer[panelIndex].Tech[1].TechTransform.anchoredPosition = anchoredPosition;
			this.SetTechItemLayout(dataIndex, panelIndex, 2, recordByIndex.TechID3, recordByIndex.VerticalExtend3, recordByIndex.HorizontalExtend3);
			anchoredPosition = this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[5];
			this.TreeLayer[panelIndex].Tech[2].TechTransform.anchoredPosition = anchoredPosition;
			this.SetTechItemLayout(dataIndex, panelIndex, 3, recordByIndex.TechID4, recordByIndex.VerticalExtend4, recordByIndex.HorizontalExtend4);
			anchoredPosition = this.TreeLayer[panelIndex].Tech[3].TechTransform.anchoredPosition;
			anchoredPosition.x = this.Skillpos[6];
			this.TreeLayer[panelIndex].Tech[3].TechTransform.anchoredPosition = anchoredPosition;
			break;
		}
		}
		this.SetHorizontalLayout(dataIndex, panelIndex);
	}

	// Token: 0x06002016 RID: 8214 RVA: 0x003CECF0 File Offset: 0x003CCEF0
	public unsafe void SetTechItemLayout(int dataIndex, int panelIndex, byte techIndex, ushort TechID, byte UpDown, byte LeftRight)
	{
		TechTreeLayoutTbl recordByIndex = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex);
		if (TechID == 0)
		{
			this.TreeLayer[panelIndex].Tech[(int)techIndex].TechTransform.gameObject.SetActive(false);
			return;
		}
		this.TreeLayer[panelIndex].Tech[(int)techIndex].TechTransform.gameObject.SetActive(true);
		this.TreeLayer[panelIndex].Tech[(int)techIndex].SetItemStyle(TechID);
		if (TechID < 1000)
		{
			int frameIndex = 0;
			this.TreeLayer[panelIndex].Tech[(int)techIndex].SetTechID(ref this.SpriteArray, TechID, frameIndex);
			this.TreeLayer[panelIndex].Tech[(int)techIndex].SetTechInfo(TechID);
			Vector2 sizeDelta = this.TreeLayer[panelIndex].Tech[(int)techIndex].TechIconTrans.sizeDelta;
			sizeDelta.Set(110f, 110f);
			this.TreeLayer[panelIndex].Tech[(int)techIndex].TechIconTrans.sizeDelta = sizeDelta;
			Quaternion localRotation = this.TreeLayer[panelIndex].Tech[(int)techIndex].TechIconTrans.localRotation;
			localRotation.eulerAngles = Vector3.zero;
			this.TreeLayer[panelIndex].Tech[(int)techIndex].TechIconTrans.localRotation = localRotation;
			this.TreeLayer[panelIndex].Tech[(int)techIndex].LineUp.gameObject.SetActive((UpDown & 1) > 0);
			this.TreeLayer[panelIndex].Tech[(int)techIndex].LineDown.gameObject.SetActive((UpDown & 2) > 0);
			this.TreeLayer[panelIndex].Tech[(int)techIndex].LineLeft.gameObject.SetActive((LeftRight & 1) > 0);
			this.TreeLayer[panelIndex].Tech[(int)techIndex].LineRight.gameObject.SetActive((LeftRight & 2) > 0);
		}
		else
		{
			ushort* ptr = stackalloc ushort[checked(4 * 2)];
			recordByIndex = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex + 1);
			*ptr = recordByIndex.TechID1;
			ptr[1] = recordByIndex.TechID2;
			ptr[2] = recordByIndex.TechID3;
			ptr[3] = recordByIndex.TechID4;
			if (TechID == 1002)
			{
				int frameIndex = 4;
				this.TreeLayer[panelIndex].Tech[(int)techIndex].SetTechID(ref this.SpriteArray, ptr[techIndex], frameIndex);
			}
			else if (TechID == 1003)
			{
				int frameIndex = 6;
				this.TreeLayer[panelIndex].Tech[(int)techIndex].SetTechID(ref this.SpriteArray, ptr[techIndex], frameIndex);
				this.TreeLayer[panelIndex].Tech[(int)techIndex].TechBtn.m_BtnID2 = (int)TechID;
				this.TreeLayer[panelIndex].Tech[(int)techIndex].TechBtn.m_BtnID3 = (int)this.GetParentTechID(ref recordByIndex, this.TreeLayer[panelIndex].DataIndex, (int)techIndex, UITechTree.NeighborWay.Left);
			}
			else if (TechID == 1001)
			{
				int frameIndex = 2;
				this.TreeLayer[panelIndex].Tech[(int)techIndex].SetTechID(ref this.SpriteArray, ptr[techIndex], frameIndex);
				this.TreeLayer[panelIndex].Tech[(int)techIndex].TechBtn.m_BtnID2 = (int)TechID;
				this.TreeLayer[panelIndex].Tech[(int)techIndex].TechBtn.m_BtnID3 = (int)this.GetParentTechID(ref recordByIndex, this.TreeLayer[panelIndex].DataIndex, (int)techIndex, UITechTree.NeighborWay.Up);
			}
			this.TreeLayer[panelIndex].Tech[(int)techIndex].Name.text = string.Empty;
			this.TreeLayer[panelIndex].Tech[(int)techIndex].Level.text = string.Empty;
		}
	}

	// Token: 0x06002017 RID: 8215 RVA: 0x003CF10C File Offset: 0x003CD30C
	public int GetHorizontalState(ref TechTreeLayoutTbl Data, int techIndex)
	{
		byte horizontalType = Data.HorizontalType;
		if (horizontalType != 1)
		{
		}
		return -1;
	}

	// Token: 0x06002018 RID: 8216 RVA: 0x003CF134 File Offset: 0x003CD334
	public void SetHorizontalLayout(int dataIndex, int panelIndex)
	{
		TechTreeLayoutTbl recordByIndex = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex);
		this.TreeLayer[panelIndex].Line[0].LineImg.sprite = this.SpriteArray.GetSprite(2);
		this.TreeLayer[panelIndex].Line[0].LineImg.sprite = this.SpriteArray.GetSprite(2);
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
		if (dataIndex + 1 - (int)this.DataStart < this.HorzontalShowFlag.Length)
		{
			recordByIndex = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex + 1);
			this.SetNodeLayout(panelIndex, horizontalType, ref recordByIndex, false);
		}
	}

	// Token: 0x06002019 RID: 8217 RVA: 0x003CF478 File Offset: 0x003CD678
	public void SetNodeLayout(int panelIndex, byte HorizontalType, ref TechTreeLayoutTbl Data, bool bDown)
	{
		byte b = 2;
		if (!bDown)
		{
			b = 1;
		}
		ushort num = 0;
		ushort num2 = 0;
		switch (HorizontalType)
		{
		case 1:
			if (Data.TechID1 > 0 && (Data.VerticalExtend1 & b) > 0)
			{
				num |= 1;
			}
			if (Data.TechID2 > 0 && (Data.VerticalExtend2 & b) > 0)
			{
				num |= 2;
			}
			break;
		case 2:
			if (Data.TechID1 > 0 && (Data.VerticalExtend1 & b) > 0)
			{
				num |= 1;
			}
			if (Data.TechID2 > 0 && (Data.VerticalExtend2 & b) > 0)
			{
				num |= 2;
			}
			if (Data.TechID3 > 0 && (Data.VerticalExtend3 & b) > 0)
			{
				num |= 4;
			}
			break;
		case 3:
			if (Data.TechID1 > 0 && (Data.VerticalExtend1 & b) > 0)
			{
				num |= 1;
			}
			if (Data.TechID2 > 0 && (Data.VerticalExtend2 & b) > 0)
			{
				num |= 2;
			}
			break;
		case 4:
			if (Data.TechID2 > 0 && (Data.VerticalExtend2 & b) > 0)
			{
				num |= 2;
			}
			if (Data.TechID3 > 0 && (Data.VerticalExtend3 & b) > 0)
			{
				num |= 4;
			}
			break;
		case 5:
			if (Data.TechID1 > 0 && (Data.VerticalExtend1 & b) > 0)
			{
				num |= 1;
			}
			if (Data.TechID2 > 0 && (Data.VerticalExtend2 & b) > 0)
			{
				num |= 2;
			}
			if (Data.TechID3 > 0 && (Data.VerticalExtend3 & b) > 0)
			{
				num |= 4;
			}
			if (Data.TechID4 > 0 && (Data.VerticalExtend4 & b) > 0)
			{
				num |= 8;
			}
			break;
		case 6:
			if (Data.TechID1 > 0 && (Data.VerticalExtend1 & b) > 0)
			{
				num |= 1;
			}
			if (Data.TechID2 > 0 && (Data.VerticalExtend2 & b) > 0)
			{
				num |= 2;
			}
			if (Data.TechID3 > 0 && (Data.VerticalExtend3 & b) > 0)
			{
				num |= 4;
			}
			break;
		case 7:
			if (Data.TechID2 > 0 && (Data.VerticalExtend2 & b) > 0)
			{
				num |= 2;
			}
			if (Data.TechID3 > 0 && (Data.VerticalExtend3 & b) > 0)
			{
				num |= 4;
			}
			if (Data.TechID4 > 0 && (Data.VerticalExtend4 & b) > 0)
			{
				num |= 8;
			}
			break;
		case 8:
			if (Data.TechID1 > 0 && (Data.VerticalExtend1 & b) > 0)
			{
				num |= 1;
			}
			if (Data.TechID2 > 0 && (Data.VerticalExtend2 & b) > 0)
			{
				num |= 2;
			}
			break;
		case 9:
			if (Data.TechID2 > 0 && (Data.VerticalExtend2 & b) > 0)
			{
				num |= 2;
			}
			if (Data.TechID3 > 0 && (Data.VerticalExtend3 & b) > 0)
			{
				num |= 4;
			}
			break;
		case 10:
			if (Data.TechID3 > 0 && (Data.VerticalExtend3 & b) > 0)
			{
				num |= 4;
			}
			if (Data.TechID4 > 0 && (Data.VerticalExtend4 & b) > 0)
			{
				num |= 8;
			}
			break;
		case 11:
			if (Data.TechID1 > 0 && (Data.VerticalExtend1 & b) > 0)
			{
				num |= 1;
			}
			if (Data.TechID2 > 0 && (Data.VerticalExtend2 & b) > 0)
			{
				num |= 2;
			}
			if (Data.TechID3 > 0 & (Data.VerticalExtend3 & b) > 0)
			{
				num2 |= 4;
			}
			if (Data.TechID4 > 0 && (Data.VerticalExtend4 & b) > 0)
			{
				num2 |= 8;
			}
			break;
		}
		if (Data.HorizontalType == 0)
		{
			num |= 512;
			num2 |= 512;
		}
		if (bDown)
		{
			this.HorzontalShowFlag[(int)(Data.ID - 1 - this.DataStart)] = num;
			this.HorzontalShowFlag2[(int)(Data.ID - 1 - this.DataStart)] = num2;
		}
		else
		{
			num = (ushort)(num << 5);
			num2 = (ushort)(num2 << 5);
			ushort[] horzontalShowFlag = this.HorzontalShowFlag;
			ushort num3 = Data.ID - 2 - this.DataStart;
			horzontalShowFlag[(int)num3] = (horzontalShowFlag[(int)num3] | num);
			ushort[] horzontalShowFlag2 = this.HorzontalShowFlag2;
			ushort num4 = Data.ID - 2 - this.DataStart;
			horzontalShowFlag2[(int)num4] = (horzontalShowFlag2[(int)num4] | num2);
		}
	}

	// Token: 0x0600201A RID: 8218 RVA: 0x003CF92C File Offset: 0x003CDB2C
	private byte CheckTechState(ushort TechID)
	{
		return DataManager.Instance.CheckTechState(TechID);
	}

	// Token: 0x0600201B RID: 8219 RVA: 0x003CF93C File Offset: 0x003CDB3C
	private unsafe void UpdateHorizontal(int dataIndex, int panelIndex)
	{
		TechTreeLayoutTbl recordByIndex = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex);
		int num = dataIndex - (int)this.DataStart;
		bool flag = true;
		bool flag2 = true;
		ushort* ptr = stackalloc ushort[checked(8 * 2)];
		byte b = 0;
		int num2 = 0;
		*ptr = recordByIndex.TechID1;
		ptr[1] = recordByIndex.TechID2;
		ptr[2] = recordByIndex.TechID3;
		ptr[3] = recordByIndex.TechID4;
		ptr[4] = (ushort)recordByIndex.HorizontalExtend1;
		ptr[5] = (ushort)recordByIndex.HorizontalExtend2;
		ptr[6] = (ushort)recordByIndex.HorizontalExtend3;
		ptr[7] = (ushort)recordByIndex.HorizontalExtend4;
		this.TreeLayer[panelIndex].UpdateLineLRState();
		for (int i = 0; i < (int)recordByIndex.TechCount; i++)
		{
			if (ptr[i] != 0)
			{
				int num3 = 1 << i;
				if (((int)this.HorzontalShowFlag[num] & num3) > 0 || ((int)this.HorzontalShowFlag2[num] & num3) > 0)
				{
					b |= this.GetNodePos(recordByIndex.TechCount, i);
					if (ptr[i] > 0)
					{
						if (ptr[i] == 1001)
						{
							ptr[i] = this.GetParentTechID(ref recordByIndex, dataIndex, i, UITechTree.NeighborWay.Up);
						}
						if ((this.CheckTechState(ptr[i]) & 2) > 0)
						{
							num2 |= (int)this.GetNodePos(recordByIndex.TechCount, i);
							this.TreeLayer[panelIndex].Tech[i].LineDown.sprite = this.SpriteArray.GetSprite(3);
						}
						else
						{
							this.TreeLayer[panelIndex].Tech[i].LineDown.sprite = this.SpriteArray.GetSprite(2);
							if (((int)this.HorzontalShowFlag[num] & num3) > 0)
							{
								flag = false;
							}
							else
							{
								flag2 = false;
							}
						}
					}
				}
				else if (ptr[i] > 0 && (this.CheckTechState(ptr[i]) & 2) > 0)
				{
					byte b2 = this.CheckTechState(this.GetParentTechID(ref recordByIndex, dataIndex, i, UITechTree.NeighborWay.Down));
					recordByIndex = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex);
					if ((b2 & 2) > 0 || (b2 & 1) == 0)
					{
						this.TreeLayer[panelIndex].Tech[i].LineDown.sprite = this.SpriteArray.GetSprite(3);
					}
					else
					{
						this.TreeLayer[panelIndex].Tech[i].LineDown.sprite = this.SpriteArray.GetSprite(2);
					}
				}
				if (ptr[4 + i] == 1 || ptr[4 + i] == 3)
				{
					this.TreeLayer[panelIndex].Tech[i].LineLeft.gameObject.SetActive(true);
				}
				else
				{
					this.TreeLayer[panelIndex].Tech[i].LineLeft.gameObject.SetActive(false);
				}
				if (ptr[4 + i] == 2 || ptr[4 + i] == 3)
				{
					this.TreeLayer[panelIndex].Tech[i].LineRight.gameObject.SetActive(true);
				}
				else
				{
					this.TreeLayer[panelIndex].Tech[i].LineRight.gameObject.SetActive(false);
				}
				if (i > 0 && this.TreeLayer[panelIndex].Tech[i].LineLeft.gameObject.activeSelf)
				{
					this.TreeLayer[panelIndex].Tech[i - 1].LineRight.sprite = this.TreeLayer[panelIndex].Tech[i].LineLeft.sprite;
					this.TreeLayer[panelIndex].Tech[i - 1].LineRight.gameObject.SetActive(true);
					this.TreeLayer[panelIndex].Tech[i].LineLeft.gameObject.SetActive(false);
				}
			}
		}
		if (flag)
		{
			ushort[] horzontalShowFlag = this.HorzontalShowFlag;
			int num4 = num;
			horzontalShowFlag[num4] |= 16;
			this.TreeLayer[panelIndex].Line[0].LineImg.sprite = this.SpriteArray.GetSprite(3);
		}
		if (flag2)
		{
			if (recordByIndex.HorizontalType == 11)
			{
				ushort[] horzontalShowFlag2 = this.HorzontalShowFlag2;
				int num5 = num;
				horzontalShowFlag2[num5] |= 16;
				this.TreeLayer[panelIndex].Line[1].LineImg.sprite = this.SpriteArray.GetSprite(3);
			}
			else
			{
				flag2 = false;
			}
		}
		byte b3 = 0;
		int num6 = 0;
		int num7 = (panelIndex + 1) % this.MaxItemCount;
		int num8;
		if (num7 == 0)
		{
			num8 = this.MaxItemCount - 1;
		}
		else
		{
			num8 = num7;
		}
		if ((int)this.DataStart + this.TechTreePanel.GetBeginIdx() + 4 != dataIndex)
		{
			if ((int)(this.DataStart + this.DataCount) > dataIndex + 1)
			{
				recordByIndex = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex + 1);
				*ptr = recordByIndex.TechID1;
				ptr[1] = recordByIndex.TechID2;
				ptr[2] = recordByIndex.TechID3;
				ptr[3] = recordByIndex.TechID4;
				int num9 = this.HorzontalShowFlag[num] >> 5;
				int num10 = this.HorzontalShowFlag2[num] >> 5;
				for (int j = 0; j < (int)recordByIndex.TechCount; j++)
				{
					if (ptr[j] != 0)
					{
						int num3 = 1 << j;
						if ((num9 & num3) > 0 || (num10 & num3) > 0)
						{
							if (ptr[j] == 1001)
							{
								ptr[j] = this.GetParentTechID(ref recordByIndex, dataIndex + 1, j, UITechTree.NeighborWay.Down);
							}
							b3 |= this.GetNodePos(recordByIndex.TechCount, j);
							if ((this.CheckTechState(ptr[j]) & 1) == 0 || ((this.CheckTechState(ptr[j]) & 2) > 0 && (flag || flag2)))
							{
								num6 |= (int)this.GetNodePos(recordByIndex.TechCount, j);
								this.TreeLayer[num7].Tech[j].LineUp.sprite = this.SpriteArray.GetSprite(3);
							}
							else
							{
								this.TreeLayer[num7].Tech[j].LineUp.sprite = this.SpriteArray.GetSprite(2);
							}
						}
						else if ((this.CheckTechState(ptr[j]) & 1) == 0 || (this.CheckTechState(ptr[j]) & 2) > 0)
						{
							TechTreeLayoutTbl techTreeLayoutTbl = recordByIndex;
							if ((this.CheckTechState(this.GetParentTechID(ref techTreeLayoutTbl, dataIndex + 1, j, UITechTree.NeighborWay.Up)) & 2) > 0)
							{
								this.TreeLayer[num7].Tech[j].LineUp.sprite = this.SpriteArray.GetSprite(3);
							}
							else
							{
								this.TreeLayer[num7].Tech[j].LineUp.sprite = this.SpriteArray.GetSprite(2);
							}
						}
						else
						{
							this.TreeLayer[num7].Tech[j].LineUp.sprite = this.SpriteArray.GetSprite(2);
						}
					}
				}
			}
		}
		int num11 = 0;
		int num12 = 0;
		if (num8 == num7)
		{
			num11 = 7;
			num12 = 7;
		}
		for (int k = 0; k < 7; k++)
		{
			int num3 = 1 << k;
			if (((int)b & num3) > 0 && ((int)b3 & num3) == 0)
			{
				Vector2 anchoredPosition = this.TreeLayer[num8].Node[num11].rectTransform.anchoredPosition;
				anchoredPosition.x = this.Skillpos[k] + 386f;
				this.TreeLayer[num8].Node[num11].rectTransform.anchoredPosition = anchoredPosition;
				if ((num2 & num3) > 0)
				{
					this.TreeLayer[num8].Node[num11].sprite = this.SpriteArray.GetSprite(9);
				}
				else
				{
					this.TreeLayer[num8].Node[num11].sprite = this.SpriteArray.GetSprite(8);
				}
				num11++;
			}
			else if (((int)b3 & num3) > 0)
			{
				Vector2 anchoredPosition = this.TreeLayer[num8].Node[num11].rectTransform.anchoredPosition;
				anchoredPosition.x = this.Skillpos[k] + 386f;
				this.TreeLayer[num8].Node[num11].rectTransform.anchoredPosition = anchoredPosition;
				if ((num6 & num3) > 0)
				{
					this.TreeLayer[num8].Node[num11].sprite = this.SpriteArray.GetSprite(9);
				}
				else
				{
					this.TreeLayer[num8].Node[num11].sprite = this.SpriteArray.GetSprite(8);
				}
				num11++;
			}
		}
		if ((int)this.DataStart == dataIndex)
		{
			for (int l = 7; l < this.TreeLayer[panelIndex].Node.Length; l++)
			{
				this.TreeLayer[panelIndex].Node[l].gameObject.SetActive(false);
			}
		}
		for (int m = num12; m < num12 + 7; m++)
		{
			if (num11 > m)
			{
				this.TreeLayer[num8].Node[m].gameObject.SetActive(true);
			}
			else
			{
				this.TreeLayer[num8].Node[m].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x0600201C RID: 8220 RVA: 0x003D0358 File Offset: 0x003CE558
	public unsafe ushort GetParentTechID(ref TechTreeLayoutTbl Data, int dataIndex, int techIndex, UITechTree.NeighborWay way)
	{
		Data = DataManager.Instance.TechTreeLayout.GetRecordByIndex(dataIndex);
		ushort* ptr = stackalloc ushort[checked(4 * 2)];
		*ptr = Data.TechID1;
		ptr[1] = Data.TechID2;
		ptr[2] = Data.TechID3;
		ptr[3] = Data.TechID4;
		ushort result = ptr[techIndex];
		switch (way)
		{
		case UITechTree.NeighborWay.Up:
			if (dataIndex > 0)
			{
				Data = DataManager.Instance.TechTreeLayout.GetRecordByIndex(--dataIndex);
				if (Data.Kind != this.TreeKind)
				{
					return 0;
				}
				*ptr = Data.TechID1;
				ptr[1] = Data.TechID2;
				ptr[2] = Data.TechID3;
				ptr[3] = Data.TechID4;
				if (ptr[techIndex] == 1001)
				{
					return this.GetParentTechID(ref Data, dataIndex, techIndex, UITechTree.NeighborWay.Up);
				}
				if (ptr[techIndex] == 1002)
				{
					if (techIndex == 3)
					{
						return 0;
					}
					return ptr[techIndex + 1];
				}
				else
				{
					if (ptr[techIndex] != 1003)
					{
						return ptr[techIndex];
					}
					if (techIndex == 0)
					{
						return 0;
					}
					return ptr[techIndex - 1];
				}
			}
			break;
		case UITechTree.NeighborWay.Down:
			if (dataIndex + 1 - (int)this.DataStart < this.HorzontalShowFlag.Length)
			{
				Data = DataManager.Instance.TechTreeLayout.GetRecordByIndex(++dataIndex);
				if (Data.Kind != this.TreeKind)
				{
					return 0;
				}
				*ptr = Data.TechID1;
				ptr[1] = Data.TechID2;
				ptr[2] = Data.TechID3;
				ptr[3] = Data.TechID4;
				if (ptr[techIndex] == 1001)
				{
					return result;
				}
				return ptr[techIndex];
			}
			break;
		case UITechTree.NeighborWay.Left:
			if (techIndex == 0)
			{
				return 0;
			}
			if (ptr[techIndex - 1] == 1002)
			{
				return this.GetParentTechID(ref Data, dataIndex, techIndex, UITechTree.NeighborWay.Down);
			}
			return ptr[techIndex - 1];
		case UITechTree.NeighborWay.Right:
			if (techIndex == 3)
			{
				return 0;
			}
			if (ptr[techIndex + 1] == 1002)
			{
				return this.GetParentTechID(ref Data, dataIndex, techIndex, UITechTree.NeighborWay.Down);
			}
			return ptr[techIndex + 1];
		}
		return 0;
	}

	// Token: 0x0600201D RID: 8221 RVA: 0x003D0578 File Offset: 0x003CE778
	public float GetSkillPosX(byte NodeCount, int Index)
	{
		if (NodeCount == 1)
		{
			return this.Skillpos[1];
		}
		if (NodeCount <= 3)
		{
			return this.Skillpos[Index];
		}
		return this.Skillpos[3 + Index];
	}

	// Token: 0x0600201E RID: 8222 RVA: 0x003D05B0 File Offset: 0x003CE7B0
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

	// Token: 0x0600201F RID: 8223 RVA: 0x003D05F0 File Offset: 0x003CE7F0
	public void OnButtonClick(UIButton sender)
	{
		if (sender.m_BtnID1 == 0)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				door.CloseMenu(false);
			}
		}
		else
		{
			if ((this.CheckTechState((ushort)sender.m_BtnID2) & 32) > 0)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7520u), 12, true);
				return;
			}
			if (this.InfoWindow == null)
			{
				this.InfoWindow = new UITechInfo();
				this.InfoWindow.ThisTransform = base.transform.GetChild(4);
				this.InfoWindow.OnOpen(sender.m_BtnID2, 0);
			}
			else
			{
				this.InfoWindow.UpdateUI(sender.m_BtnID2, 0);
			}
			Debug.Log("TechID=" + sender.m_BtnID2);
		}
	}

	// Token: 0x06002020 RID: 8224 RVA: 0x003D06DC File Offset: 0x003CE8DC
	public override void OnClose()
	{
		if (this.InfoWindow != null)
		{
			this.InfoWindow.OnDestroy();
		}
		if (this.TreeLayer != null)
		{
			for (int i = 0; i < this.TreeLayer.Length; i++)
			{
				this.TreeLayer[i].OnClose();
			}
		}
		StringManager.Instance.DeSpawnString(this.NeedLvStr);
		if (this.PassFrame == 0 && this.InitScroll == 1)
		{
			GUIManager.Instance.TechSaved[0] = this.TreeKind;
			GUIManager.Instance.TechSaved[1] = (byte)this.TechTreePanel.GetBeginIdx();
			GameConstants.GetBytes(this.RectCont.anchoredPosition.y, GUIManager.Instance.TechSaved, 2);
		}
	}

	// Token: 0x06002021 RID: 8225 RVA: 0x003D07AC File Offset: 0x003CE9AC
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		if (this.TreeLayer[panelObjectIdx].ItemTransform == null)
		{
			this.TreeLayer[panelObjectIdx].Init(item.transform, this, this.SpriteArray);
			return;
		}
		this.SetItemLayout((int)this.DataStart + dataIdx, panelObjectIdx);
	}

	// Token: 0x06002022 RID: 8226 RVA: 0x003D0804 File Offset: 0x003CEA04
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
		case NetworkNews.Refresh_BuildBase:
			this.UpdateInstitute();
			b |= 1;
			break;
		default:
			if (networkNews != NetworkNews.Login)
			{
				if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
				{
					this.TextRefresh();
				}
			}
			else
			{
				this.UpdateInstitute();
				if (this.InitScroll == 1)
				{
					for (int i = 0; i < this.TreeLayer.Length; i++)
					{
						for (int j = 0; j < this.TreeLayer[i].Tech.Length; j++)
						{
							if (this.TreeLayer[i].Tech[j].TechTransform.gameObject.activeSelf)
							{
								this.TreeLayer[i].Tech[j].UpdateState(b);
								this.TreeLayer[i].Tech[j].SetTechInfo((ushort)this.TreeLayer[i].Tech[j].TechBtn.m_BtnID2);
							}
						}
						this.UpdateHorizontal(this.TreeLayer[i].DataIndex, this.TreeLayer[i].PanelIndex);
					}
				}
				if (this.InfoWindow != null && this.InfoWindow.ThisTransform.gameObject.activeSelf)
				{
					this.InfoWindow.UpdateTechInfo();
				}
			}
			break;
		case NetworkNews.Refresh_Technology:
			b |= 2;
			break;
		}
		if (b > 0)
		{
			if (this.InitScroll == 1)
			{
				for (int k = 0; k < this.TreeLayer.Length; k++)
				{
					if (this.TreeLayer[k].ItemTransform.gameObject.activeSelf)
					{
						for (int l = 0; l < this.TreeLayer[k].Tech.Length; l++)
						{
							if (this.TreeLayer[k].Tech[l].TechTransform.gameObject.activeSelf)
							{
								this.TreeLayer[k].Tech[l].UpdateState(b);
							}
						}
						if ((b & 2) > 0)
						{
							this.UpdateHorizontal(this.TreeLayer[k].DataIndex, this.TreeLayer[k].PanelIndex);
						}
					}
				}
			}
			if (this.InfoWindow != null && this.InfoWindow.ThisTransform.gameObject.activeSelf)
			{
				this.InfoWindow.UpdateTechInfo();
			}
		}
	}

	// Token: 0x06002023 RID: 8227 RVA: 0x003D0ABC File Offset: 0x003CECBC
	private void TextRefresh()
	{
		this.TitleText.enabled = false;
		this.TitleText.enabled = true;
		this.NeedLvText.enabled = false;
		this.NeedLvText.enabled = true;
		for (int i = 0; i < this.TreeLayer.Length; i++)
		{
			this.TreeLayer[i].TextRefresh();
		}
		if (this.InfoWindow != null && this.InfoWindow.ThisTransform.gameObject.activeSelf)
		{
			this.InfoWindow.TextRefresh();
		}
	}

	// Token: 0x06002024 RID: 8228 RVA: 0x003D0B54 File Offset: 0x003CED54
	public override void UpdateUI(int arg1, int arg2)
	{
		if (this.PassFrame > 0)
		{
			this.UpdateQueue[0] = 1;
			this.UpdateQueue[1] = arg1;
			this.UpdateQueue[2] = arg2;
		}
		if (arg1 == -1)
		{
			if (this.InitScroll == 1)
			{
				this.Updategraphic();
				this.GraphicLoaded = 1;
			}
			else
			{
				this.GraphicLoaded = 2;
			}
			return;
		}
		if (this.PassFrame == 0)
		{
			this.TechTreePanel.GoTo(arg1);
		}
		if (this.InfoWindow == null)
		{
			this.InfoWindow = new UITechInfo();
			this.InfoWindow.ThisTransform = base.transform.GetChild(4);
			this.InfoWindow.OnOpen(arg2, 0);
		}
		else if (!this.InfoWindow.ThisTransform.gameObject.activeSelf)
		{
			this.InfoWindow.UpdateUI(arg2, 0);
		}
	}

	// Token: 0x06002025 RID: 8229 RVA: 0x003D0C34 File Offset: 0x003CEE34
	private void Updategraphic()
	{
		GUIManager instance = GUIManager.Instance;
		for (int i = 0; i < this.TreeLayer.Length; i++)
		{
			for (int j = 0; j < this.TreeLayer[i].Tech.Length; j++)
			{
				if (this.TreeLayer[i].Tech[j].TechTransform.gameObject.activeSelf)
				{
					this.TreeLayer[i].Tech[j].TechIcon.sprite = instance.GetTechSprite(this.TreeLayer[i].Tech[j].GraphicID);
					this.TreeLayer[i].Tech[j].TechIcon.material = instance.TechMaterial;
					this.TreeLayer[i].Tech[j].TechIcon.enabled = true;
				}
			}
		}
		if (this.InfoWindow != null)
		{
			this.InfoWindow.TechImage.sprite = instance.GetTechSprite(this.InfoWindow.GraphicID);
			this.InfoWindow.TechImage.material = instance.TechMaterial;
			this.InfoWindow.TechImage.enabled = true;
		}
	}

	// Token: 0x06002026 RID: 8230 RVA: 0x003D0D80 File Offset: 0x003CEF80
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06002027 RID: 8231 RVA: 0x003D0D84 File Offset: 0x003CEF84
	public void Update()
	{
		if (this.PassFrame > 0)
		{
			this.PassFrame -= 1;
			if (this.PassFrame == 0)
			{
				this.MaxItemCount = Mathf.Min(this.MaxItemCount, (int)this.DataCount);
				this.HorzontalShowFlag = new ushort[(int)this.DataCount];
				this.HorzontalShowFlag2 = new ushort[(int)this.DataCount];
				this.TreeLayer = new UITechTree.ItemEdit[this.MaxItemCount];
				if (this.DelayLoadScroll == 0)
				{
					this.UpdateInstitute();
				}
				NewbieManager.CheckTeach(ETeachKind.COLLEGE, this, false);
				if (this.DelayLoadScroll == 0)
				{
					this.initTechPanel();
					this.TechTreePanel.gameObject.SetActive(true);
					this.UpdateBeginIndex(true);
				}
				ushort num = GameConstants.ConvertBytesToUShort(GUIManager.Instance.TechSaved, 6);
				if (num > 0 && this.InfoWindow == null)
				{
					this.InfoWindow = new UITechInfo();
					this.InfoWindow.ThisTransform = base.transform.GetChild(4);
					this.InfoWindow.OnOpen((int)num, 0);
				}
				if (this.InitScroll == 1 && this.UpdateQueue[0] == 1)
				{
					this.UpdateUI(this.UpdateQueue[1], this.UpdateQueue[2]);
					Array.Clear(this.UpdateQueue, 0, this.UpdateQueue.Length);
				}
				this.TextRefresh();
			}
		}
		else if (this.DelayLoadScroll > 0)
		{
			this.DelayLoadScroll -= 1;
			if (this.DelayLoadScroll == 0)
			{
				this.UpdateInstitute();
				this.initTechPanel();
				this.TechTreePanel.gameObject.SetActive(true);
				if (this.UpdateQueue[0] == 1)
				{
					this.UpdateUI(this.UpdateQueue[1], this.UpdateQueue[2]);
					Array.Clear(this.UpdateQueue, 0, this.UpdateQueue.Length);
					this.UpdateBeginIndex(true);
				}
				else
				{
					this.UpdateBeginIndex(true);
				}
				if (this.GraphicLoaded == 2)
				{
					this.Updategraphic();
					this.GraphicLoaded = 1;
				}
			}
		}
		else
		{
			this.UpdateBeginIndex(false);
			for (int i = 0; i < this.TreeLayer.Length; i++)
			{
				this.TreeLayer[i].Update();
			}
		}
	}

	// Token: 0x06002028 RID: 8232 RVA: 0x003D0FC4 File Offset: 0x003CF1C4
	private void initTechPanel()
	{
		byte b = 0;
		while ((int)b < this.MaxItemCount)
		{
			this.ItemsHeight.Add(239f);
			this.ItemIndex.Add(this.DataStart + (ushort)b);
			b += 1;
		}
		float panelHeight = 492f;
		this.TechTreePanel.IntiScrollPanel(panelHeight, 0f, 0f, this.ItemsHeight, this.MaxItemCount, this);
		if ((int)this.DataCount > this.MaxItemCount)
		{
			for (int i = this.MaxItemCount; i < (int)this.DataCount; i++)
			{
				this.ItemsHeight.Add(239f);
				this.ItemIndex.Add((ushort)i);
			}
		}
		this.TechTreePanel.AddNewDataHeight(this.ItemsHeight, true, true);
		this.RectCont = this.TechTreePanel.transform.GetChild(0).GetComponent<RectTransform>();
		if (GUIManager.Instance.TechSaved[0] == this.TreeKind && !NewbieManager.IsTeachWorking(ETeachKind.COLLEGE))
		{
			byte b2 = GUIManager.Instance.TechSaved[1];
			float height = GameConstants.ConvertBytesToFloat(GUIManager.Instance.TechSaved, 2);
			this.TechTreePanel.GoTo((int)b2, height);
			this.UpdateTopLayer((int)b2);
		}
		this.InitScroll = 1;
	}

	// Token: 0x06002029 RID: 8233 RVA: 0x003D110C File Offset: 0x003CF30C
	private void UpdateTopLayer(int begin)
	{
		if (begin == 0)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		for (int i = 0; i < this.TreeLayer.Length; i++)
		{
			if (this.TreeLayer[i].DataIndex == (int)this.DataStart + begin)
			{
				for (int j = 0; j < this.TreeLayer[i].Tech.Length; j++)
				{
					if (this.TreeLayer[i].Tech[j].TechTransform.gameObject.activeSelf && this.TreeLayer[i].Tech[j].TechBtn.m_BtnID2 != 0)
					{
						if (instance.GetTechLevel((ushort)this.TreeLayer[i].Tech[j].TechBtn.m_BtnID2) > 0 || (this.CheckTechState((ushort)this.TreeLayer[i].Tech[j].TechBtn.m_BtnID2) & 1) == 0)
						{
							this.TreeLayer[i].Tech[j].LineUp.sprite = this.SpriteArray.GetSprite(3);
						}
					}
				}
				break;
			}
		}
	}

	// Token: 0x0600202A RID: 8234 RVA: 0x003D1254 File Offset: 0x003CF454
	private void UpdateBeginIndex(bool bForceUpdate)
	{
		if (this.BeginIndex != this.TechTreePanel.GetBeginIdx())
		{
			this.BeginIndex = this.TechTreePanel.GetBeginIdx();
			for (int i = 0; i < this.TreeLayer.Length; i++)
			{
				if (bForceUpdate)
				{
					this.UpdateHorizontal(this.TreeLayer[i].DataIndex, this.TreeLayer[i].PanelIndex);
				}
				else
				{
					int num = this.TreeLayer[i].DataIndex - (int)this.DataStart;
					if (num == this.BeginIndex || num == this.BeginIndex + this.TreeLayer.Length - 1 || num == this.BeginIndex + this.TreeLayer.Length - 2)
					{
						this.UpdateHorizontal(this.TreeLayer[i].DataIndex, this.TreeLayer[i].PanelIndex);
					}
				}
			}
		}
	}

	// Token: 0x0600202B RID: 8235 RVA: 0x003D1350 File Offset: 0x003CF550
	public void UpdateInstitute()
	{
		if (!this.CheckTechKindRule(this.NeedLvStr))
		{
			if (!this.BlackFrameTrans.gameObject.activeSelf)
			{
				this.BlackFrameTrans.gameObject.SetActive(true);
				this.NeedLvText.text = this.NeedLvStr.ToString();
				this.NeedLvText.SetAllDirty();
				this.NeedLvText.cachedTextGenerator.Invalidate();
				RectTransform component = this.TechTreePanel.transform.GetComponent<RectTransform>();
				Vector2 vector = component.anchoredPosition;
				vector.y = -67.14f;
				component.anchoredPosition = vector;
				vector = component.sizeDelta;
				vector.y = 478.8f;
				component.sizeDelta = vector;
			}
		}
		else if (this.BlackFrameTrans.gameObject.activeSelf)
		{
			Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
			if (door != null)
			{
				door.CloseMenu(false);
			}
		}
	}

	// Token: 0x0600202C RID: 8236 RVA: 0x003D1448 File Offset: 0x003CF648
	public bool CheckTechKindRule(CString NeedLvStr)
	{
		TechKindTbl recordByKey = DataManager.Instance.TechKindData.GetRecordByKey((ushort)this.TreeKind);
		StringTable mStringTable = DataManager.Instance.mStringTable;
		if (recordByKey.ResearchLevel > GUIManager.Instance.BuildingData.GetBuildData(10, 0).Level)
		{
			NeedLvStr.ClearString();
			NeedLvStr.IntToFormat((long)recordByKey.ResearchLevel, 1, false);
			NeedLvStr.AppendFormat(mStringTable.GetStringByID(5008u));
			return false;
		}
		return DataManager.Instance.CheckTechKind(ref recordByKey, NeedLvStr);
	}

	// Token: 0x04006522 RID: 25890
	private UISpritesArray SpriteArray;

	// Token: 0x04006523 RID: 25891
	private ushort DataStart;

	// Token: 0x04006524 RID: 25892
	private ushort DataCount;

	// Token: 0x04006525 RID: 25893
	private int MaxItemCount = 5;

	// Token: 0x04006526 RID: 25894
	private int BeginIndex = -1;

	// Token: 0x04006527 RID: 25895
	private readonly float[] Skillpos = new float[]
	{
		-191.5f,
		0.5f,
		192.5f,
		-287.5f,
		-95.5f,
		96.5f,
		288.5f
	};

	// Token: 0x04006528 RID: 25896
	private readonly float[][] HorizontalPW = new float[][]
	{
		new float[]
		{
			295f,
			201f
		},
		new float[]
		{
			201f,
			389f
		},
		new float[]
		{
			201f,
			197f
		},
		new float[]
		{
			393f,
			197f
		},
		new float[]
		{
			103f,
			584f
		},
		new float[]
		{
			103f,
			391f
		},
		new float[]
		{
			296f,
			391f
		},
		new float[]
		{
			103f,
			198f
		},
		new float[]
		{
			296f,
			198f
		},
		new float[]
		{
			488f,
			198f
		},
		new float[]
		{
			103f,
			198f
		}
	};

	// Token: 0x04006529 RID: 25897
	private ScrollPanel TechTreePanel;

	// Token: 0x0400652A RID: 25898
	protected List<float> ItemsHeight = new List<float>();

	// Token: 0x0400652B RID: 25899
	protected List<ushort> ItemIndex = new List<ushort>();

	// Token: 0x0400652C RID: 25900
	private ushort[] HorzontalShowFlag;

	// Token: 0x0400652D RID: 25901
	private ushort[] HorzontalShowFlag2;

	// Token: 0x0400652E RID: 25902
	public UITechInfo InfoWindow;

	// Token: 0x0400652F RID: 25903
	private byte TreeKind;

	// Token: 0x04006530 RID: 25904
	private byte InitScroll;

	// Token: 0x04006531 RID: 25905
	private byte DelayLoadScroll;

	// Token: 0x04006532 RID: 25906
	private RectTransform RectCont;

	// Token: 0x04006533 RID: 25907
	private Transform BlackFrameTrans;

	// Token: 0x04006534 RID: 25908
	private UIText NeedLvText;

	// Token: 0x04006535 RID: 25909
	private UIText TitleText;

	// Token: 0x04006536 RID: 25910
	private CString NeedLvStr;

	// Token: 0x04006537 RID: 25911
	public UITechTree.ItemEdit[] TreeLayer;

	// Token: 0x04006538 RID: 25912
	private byte PassFrame = 1;

	// Token: 0x04006539 RID: 25913
	private byte GraphicLoaded;

	// Token: 0x0400653A RID: 25914
	private int[] UpdateQueue = new int[3];

	// Token: 0x02000686 RID: 1670
	public enum TechSprite
	{
		// Token: 0x0400653C RID: 25916
		Skill,
		// Token: 0x0400653D RID: 25917
		SkillOn,
		// Token: 0x0400653E RID: 25918
		Line,
		// Token: 0x0400653F RID: 25919
		LineOn,
		// Token: 0x04006540 RID: 25920
		Linel,
		// Token: 0x04006541 RID: 25921
		LinelOn,
		// Token: 0x04006542 RID: 25922
		Liner,
		// Token: 0x04006543 RID: 25923
		LinerOn,
		// Token: 0x04006544 RID: 25924
		Point,
		// Token: 0x04006545 RID: 25925
		PointOn
	}

	// Token: 0x02000687 RID: 1671
	private enum UIControl
	{
		// Token: 0x04006547 RID: 25927
		Background,
		// Token: 0x04006548 RID: 25928
		Tree,
		// Token: 0x04006549 RID: 25929
		Close,
		// Token: 0x0400654A RID: 25930
		Item,
		// Token: 0x0400654B RID: 25931
		Info
	}

	// Token: 0x02000688 RID: 1672
	private enum ItemControl
	{
		// Token: 0x0400654D RID: 25933
		Skill1,
		// Token: 0x0400654E RID: 25934
		Skill2,
		// Token: 0x0400654F RID: 25935
		Skill3,
		// Token: 0x04006550 RID: 25936
		Skill4,
		// Token: 0x04006551 RID: 25937
		HorizontalLineDown0,
		// Token: 0x04006552 RID: 25938
		HorizontalLineDown1,
		// Token: 0x04006553 RID: 25939
		Node1,
		// Token: 0x04006554 RID: 25940
		Node2,
		// Token: 0x04006555 RID: 25941
		Node3,
		// Token: 0x04006556 RID: 25942
		Node4,
		// Token: 0x04006557 RID: 25943
		Node5,
		// Token: 0x04006558 RID: 25944
		Node6,
		// Token: 0x04006559 RID: 25945
		Node7,
		// Token: 0x0400655A RID: 25946
		Node8,
		// Token: 0x0400655B RID: 25947
		Node9,
		// Token: 0x0400655C RID: 25948
		Node10,
		// Token: 0x0400655D RID: 25949
		Node11,
		// Token: 0x0400655E RID: 25950
		Node12,
		// Token: 0x0400655F RID: 25951
		Node13,
		// Token: 0x04006560 RID: 25952
		Node14
	}

	// Token: 0x02000689 RID: 1673
	private enum LeaveControl
	{
		// Token: 0x04006562 RID: 25954
		Icon,
		// Token: 0x04006563 RID: 25955
		LineUp,
		// Token: 0x04006564 RID: 25956
		LineDown,
		// Token: 0x04006565 RID: 25957
		LineLeft,
		// Token: 0x04006566 RID: 25958
		LineRight,
		// Token: 0x04006567 RID: 25959
		Frame,
		// Token: 0x04006568 RID: 25960
		Degree,
		// Token: 0x04006569 RID: 25961
		LvText,
		// Token: 0x0400656A RID: 25962
		Name
	}

	// Token: 0x0200068A RID: 1674
	private enum ClickType
	{
		// Token: 0x0400656C RID: 25964
		Close,
		// Token: 0x0400656D RID: 25965
		Tech
	}

	// Token: 0x0200068B RID: 1675
	public enum NeighborWay
	{
		// Token: 0x0400656F RID: 25967
		Up,
		// Token: 0x04006570 RID: 25968
		Down,
		// Token: 0x04006571 RID: 25969
		Left,
		// Token: 0x04006572 RID: 25970
		Right
	}

	// Token: 0x0200068C RID: 1676
	public class TechItem
	{
		// Token: 0x0600202E RID: 8238 RVA: 0x003D14F0 File Offset: 0x003CF6F0
		public void Init(Transform transform, IUIButtonClickHandler handler)
		{
			this.TechTransform = (transform as RectTransform);
			this.TechIconTrans = transform.GetChild(0).GetComponent<RectTransform>();
			this.TechIcon = transform.GetChild(0).GetComponent<Image>();
			this.TechBtn = transform.GetChild(0).GetComponent<UIButton>();
			this.BlackFrame = transform.GetChild(0).GetChild(0);
			this.LineUp = transform.GetChild(1).GetComponent<Image>();
			this.LineDown = transform.GetChild(2).GetComponent<Image>();
			this.LineLeft = transform.GetChild(3).GetComponent<Image>();
			this.LineRight = transform.GetChild(4).GetComponent<Image>();
			this.TechBtn.m_Handler = handler;
			this.Frame = transform.GetChild(5).GetComponent<Image>();
			this.FrameTransform = (transform.GetChild(5) as RectTransform);
			this.Lock = transform.GetChild(5).GetChild(0);
			this.LockImg = this.Lock.GetComponent<Image>();
			this.Lock1 = transform.GetChild(5).GetChild(1);
			this.Researching = transform.GetChild(5).GetChild(2).GetComponent<RectTransform>();
			this.TechLock = transform.GetChild(5).GetChild(0).GetComponent<Image>();
			this.Degree = transform.GetChild(6).GetComponent<Image>();
			this.Level = transform.GetChild(7).GetComponent<UIText>();
			this.Name = transform.GetChild(8).GetComponent<UIText>();
			if (GUIManager.Instance.IsArabic)
			{
				this.TechBtn.transform.localScale = new Vector3(-1f, 1f, 1f);
			}
			this.FramePos = this.FrameTransform.anchoredPosition;
			this.FrameSize = this.FrameTransform.sizeDelta;
			RectTransform rectTransform = this.LineRight.rectTransform;
			this.LineRPos = rectTransform.anchoredPosition;
			this.LineRSize = rectTransform.sizeDelta;
			rectTransform = this.LineLeft.rectTransform;
			this.LineLPos = rectTransform.anchoredPosition;
			this.LineLSize = rectTransform.sizeDelta;
			rectTransform = this.LineUp.rectTransform;
			this.LineTPos = rectTransform.anchoredPosition;
			this.LineTSize = rectTransform.sizeDelta;
			rectTransform = this.LineDown.rectTransform;
			this.LineBPos = rectTransform.anchoredPosition;
			this.LineBSize = rectTransform.sizeDelta;
			this.TechNameStr = StringManager.Instance.SpawnString(30);
			this.TechLvStr = StringManager.Instance.SpawnString(30);
		}

		// Token: 0x0600202F RID: 8239 RVA: 0x003D1770 File Offset: 0x003CF970
		public void SetItemStyle(ushort TechID)
		{
			if (TechID == 1001)
			{
				this.TechLock.gameObject.SetActive(false);
				this.LineUp.gameObject.SetActive(false);
				this.LineDown.gameObject.SetActive(false);
				this.LineLeft.gameObject.SetActive(false);
				this.LineRight.gameObject.SetActive(false);
				this.FrameTransform.gameObject.SetActive(false);
				this.Degree.gameObject.SetActive(false);
				this.TechIcon.gameObject.SetActive(false);
				this.BlackFrame.gameObject.SetActive(false);
				this.Name.text = string.Empty;
				this.LineDown.gameObject.SetActive(true);
				RectTransform rectTransform = this.LineDown.rectTransform;
				Vector2 anchoredPosition = rectTransform.anchoredPosition;
				anchoredPosition.Set(95f, -242f);
				rectTransform.anchoredPosition = anchoredPosition;
				Vector2 sizeDelta = rectTransform.sizeDelta;
				sizeDelta.Set(248.1f, 10f);
				rectTransform.sizeDelta = sizeDelta;
			}
			else if (TechID == 1002)
			{
				this.TechLock.gameObject.SetActive(false);
				this.LineUp.gameObject.SetActive(false);
				this.LineLeft.gameObject.SetActive(false);
				this.LineDown.gameObject.SetActive(true);
				this.LineRight.gameObject.SetActive(true);
				this.Degree.gameObject.SetActive(false);
				this.TechIcon.gameObject.SetActive(false);
				this.BlackFrame.gameObject.SetActive(false);
				this.FrameTransform.gameObject.SetActive(true);
				this.Name.text = string.Empty;
				Vector2 anchoredPosition2 = this.FrameTransform.anchoredPosition;
				anchoredPosition2.Set(10.56f, -15.2f);
				this.FrameTransform.anchoredPosition = anchoredPosition2;
				Vector2 sizeDelta2 = this.FrameTransform.sizeDelta;
				sizeDelta2.Set(30f, 30f);
				this.FrameTransform.sizeDelta = sizeDelta2;
				RectTransform rectTransform = this.LineRight.rectTransform;
				anchoredPosition2 = rectTransform.anchoredPosition;
				anchoredPosition2.Set(122.6f, -110.2f);
				rectTransform.anchoredPosition = anchoredPosition2;
				sizeDelta2 = rectTransform.sizeDelta;
				sizeDelta2.Set(62.6f, 10f);
				rectTransform.sizeDelta = sizeDelta2;
				rectTransform = this.LineDown.rectTransform;
				anchoredPosition2 = rectTransform.anchoredPosition;
				anchoredPosition2.Set(95f, -239.9f);
				rectTransform.anchoredPosition = anchoredPosition2;
				sizeDelta2 = this.LineDown.rectTransform.sizeDelta;
				sizeDelta2.Set(103.6f, 10f);
				rectTransform.sizeDelta = sizeDelta2;
			}
			else if (TechID == 1003)
			{
				this.TechLock.gameObject.SetActive(false);
				this.LineUp.gameObject.SetActive(false);
				this.LineLeft.gameObject.SetActive(true);
				this.Degree.gameObject.SetActive(false);
				this.TechIcon.gameObject.SetActive(false);
				this.LineRight.gameObject.SetActive(false);
				this.LineDown.gameObject.SetActive(true);
				this.FrameTransform.gameObject.SetActive(true);
				this.Researching.gameObject.SetActive(false);
				this.Name.text = string.Empty;
				Vector2 anchoredPosition3 = this.FrameTransform.anchoredPosition;
				anchoredPosition3.Set(-9.5f, -15.2f);
				this.FrameTransform.anchoredPosition = anchoredPosition3;
				Vector2 sizeDelta3 = this.FrameTransform.sizeDelta;
				sizeDelta3.Set(30f, 30f);
				this.FrameTransform.sizeDelta = sizeDelta3;
				RectTransform rectTransform = this.LineLeft.rectTransform;
				anchoredPosition3 = rectTransform.anchoredPosition;
				anchoredPosition3.Set(-30.7f, -110.2f);
				rectTransform.anchoredPosition = anchoredPosition3;
				sizeDelta3 = this.LineRight.rectTransform.sizeDelta;
				sizeDelta3.Set(109.39f, 10f);
				rectTransform.sizeDelta = sizeDelta3;
				rectTransform = this.LineDown.rectTransform;
				anchoredPosition3 = rectTransform.anchoredPosition;
				anchoredPosition3.Set(95f, -235.4f);
				rectTransform.anchoredPosition = anchoredPosition3;
				sizeDelta3 = this.LineDown.rectTransform.sizeDelta;
				sizeDelta3.Set(103.2f, 10f);
				rectTransform.sizeDelta = sizeDelta3;
			}
			else
			{
				this.FrameTransform.anchoredPosition = this.FramePos;
				this.FrameTransform.sizeDelta = this.FrameSize;
				this.Degree.gameObject.SetActive(true);
				this.TechIcon.gameObject.SetActive(true);
				this.FrameTransform.gameObject.SetActive(true);
				RectTransform rectTransform = this.LineRight.rectTransform;
				rectTransform.anchoredPosition = this.LineRPos;
				rectTransform.sizeDelta = this.LineRSize;
				rectTransform = this.LineLeft.rectTransform;
				rectTransform.anchoredPosition = this.LineLPos;
				rectTransform.sizeDelta = this.LineLSize;
				rectTransform = this.LineUp.rectTransform;
				rectTransform.anchoredPosition = this.LineTPos;
				rectTransform.sizeDelta = this.LineTSize;
				rectTransform = this.LineDown.rectTransform;
				rectTransform.anchoredPosition = this.LineBPos;
				rectTransform.sizeDelta = this.LineBSize;
			}
		}

		// Token: 0x06002030 RID: 8240 RVA: 0x003D1CE4 File Offset: 0x003CFEE4
		public void SetTechID(ref UISpritesArray SpriteArray, ushort TechID, int FrameIndex)
		{
			DataManager instance = DataManager.Instance;
			this.TechBtn.m_BtnID2 = (int)TechID;
			this.SpriteArr = SpriteArray;
			this.FrameIndex = FrameIndex;
			this.Frame.sprite = SpriteArray.GetSprite(FrameIndex);
			Sprite sprite = SpriteArray.GetSprite(2);
			this.LineDown.sprite = sprite;
			this.LineLeft.sprite = sprite;
			this.LineRight.sprite = sprite;
			if (instance.ResearchTech == TechID)
			{
				this.Researching.gameObject.SetActive(true);
			}
			else
			{
				this.Researching.gameObject.SetActive(false);
			}
		}

		// Token: 0x06002031 RID: 8241 RVA: 0x003D1D88 File Offset: 0x003CFF88
		public void SetTechInfo(ushort TechID)
		{
			if (TechID > 1000)
			{
				return;
			}
			DataManager instance = DataManager.Instance;
			TechDataTbl recordByKey = instance.TechData.GetRecordByKey(TechID);
			this.TechNameStr.ClearString();
			this.TechLvStr.ClearString();
			this.TechNameStr.Insert(0, instance.mStringTable.GetStringByID((uint)recordByKey.TechName), -1);
			this.Name.text = this.TechNameStr.ToString();
			this.Name.SetAllDirty();
			this.Name.cachedTextGenerator.Invalidate();
			byte techLevel = instance.GetTechLevel(TechID);
			float num = 173.8f / (float)recordByKey.LevelMax;
			Vector2 sizeDelta = this.Degree.rectTransform.sizeDelta;
			sizeDelta.x = num * (float)techLevel;
			this.Degree.rectTransform.sizeDelta = sizeDelta;
			this.TechLvStr.IntToFormat((long)techLevel, 1, false);
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
			this.GraphicID = recordByKey.Graphic;
			if (GUIManager.Instance.TechMaterial == null)
			{
				this.TechIcon.enabled = false;
			}
			else
			{
				this.TechIcon.sprite = GUIManager.Instance.GetTechSprite(this.GraphicID);
				this.TechIcon.material = GUIManager.Instance.TechMaterial;
				if (this.TechIcon.material != null)
				{
					this.TechIcon.enabled = true;
				}
			}
			TechLevelTbl techLevelTbl;
			if (instance.GetTechLevelupData(out techLevelTbl, TechID, techLevel + 1))
			{
				this.RequireBuildLv = techLevelTbl.ResearchLevel;
				this.RequireTech[0].TechID = techLevelTbl.RequireTechID1;
				this.RequireTech[1].TechID = techLevelTbl.RequireTechID2;
				this.RequireTech[2].TechID = techLevelTbl.RequireTechID3;
				this.RequireTech[3].TechID = techLevelTbl.RequireTechID4;
				this.RequireTech[0].Lv = techLevelTbl.RequireTechLv1;
				this.RequireTech[1].Lv = techLevelTbl.RequireTechLv2;
				this.RequireTech[2].Lv = techLevelTbl.RequireTechLv3;
				this.RequireTech[3].Lv = techLevelTbl.RequireTechLv4;
			}
			this.State = instance.CheckTechState(TechID);
			this.UpdateState(7);
		}

		// Token: 0x06002032 RID: 8242 RVA: 0x003D2064 File Offset: 0x003D0264
		public byte CheckTechState()
		{
			ushort num = (ushort)this.TechBtn.m_BtnID2;
			if (num >= 1001)
			{
				num = (ushort)this.TechBtn.m_BtnID3;
			}
			return DataManager.Instance.CheckTechState(num);
		}

		// Token: 0x06002033 RID: 8243 RVA: 0x003D20A4 File Offset: 0x003D02A4
		public void UpdateState(byte Kind)
		{
			if ((this.State & 32) > 0)
			{
				this.Lock1.gameObject.SetActive(false);
				this.BlackFrame.gameObject.SetActive(true);
				this.Lock.gameObject.SetActive(true);
				this.LockImg.sprite = this.SpriteArr.GetSprite(11);
				this.LockImg.SetNativeSize();
				return;
			}
			this.LockImg.sprite = this.SpriteArr.GetSprite(10);
			this.LockImg.SetNativeSize();
			if ((Kind & 2) > 0 && this.TechBtn.m_BtnID2 == (int)DataManager.Instance.CheckResearchTech && this.Researching.gameObject.activeSelf)
			{
				this.Researching.gameObject.SetActive(false);
				this.SetTechInfo((ushort)this.TechBtn.m_BtnID2);
				return;
			}
			this.State = this.CheckTechState();
			DataManager instance = DataManager.Instance;
			if ((Kind & 2) > 0)
			{
				if ((this.State & 2) == 0 && (this.State & 1) > 0)
				{
					this.BlackFrame.gameObject.SetActive(true);
				}
				else
				{
					this.BlackFrame.gameObject.SetActive(false);
				}
				this.UpdateLineState();
			}
			if (this.Researching.gameObject.activeSelf)
			{
				this.Lock.gameObject.SetActive(false);
				this.Lock1.gameObject.SetActive(false);
				return;
			}
			if ((this.State & 4) > 0 && (Kind & 1) > 0)
			{
				if (GUIManager.Instance.BuildingData.GetBuildData(10, 0).Level >= this.RequireBuildLv)
				{
					this.UpdateState(6);
					return;
				}
			}
			else if ((Kind & 2) > 0)
			{
				if ((this.State & 8) > 0)
				{
					bool flag = true;
					for (int i = 0; i < this.RequireTech.Length; i++)
					{
						if (instance.GetTechLevel(this.RequireTech[i].TechID) < this.RequireTech[i].Lv)
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						this.UpdateState(5);
						return;
					}
				}
				else if ((this.State & 64) > 0)
				{
					TechDataTbl recordByKey = instance.TechData.GetRecordByKey((ushort)this.TechBtn.m_BtnID2);
					if (recordByKey.LevelMax == instance.GetTechLevel(recordByKey.TechID))
					{
						this.Frame.sprite = this.SpriteArr.GetSprite(this.FrameIndex + 1);
						Sprite sprite = this.SpriteArr.GetSprite(3);
						this.LineDown.sprite = sprite;
						this.LineLeft.sprite = sprite;
						this.LineRight.sprite = sprite;
						this.Degree.gameObject.SetActive(false);
						this.BlackFrame.gameObject.SetActive(false);
						this.Lock.gameObject.SetActive(false);
					}
				}
			}
			if ((this.State & 1) > 0)
			{
				if ((this.State & 2) > 0)
				{
					this.Lock1.gameObject.SetActive(true);
					this.Lock.gameObject.SetActive(false);
				}
				else
				{
					this.Lock1.gameObject.SetActive(false);
					this.Lock.gameObject.SetActive(true);
					this.LockImg.sprite = this.SpriteArr.GetSprite(10);
				}
			}
			else
			{
				this.Lock.gameObject.SetActive(false);
				this.Lock1.gameObject.SetActive(false);
			}
		}

		// Token: 0x06002034 RID: 8244 RVA: 0x003D2460 File Offset: 0x003D0660
		public void UpdateLineState()
		{
			if ((this.State & 2) == 0)
			{
				this.Frame.sprite = this.SpriteArr.GetSprite(this.FrameIndex);
				Sprite sprite = this.SpriteArr.GetSprite(2);
				this.LineDown.sprite = sprite;
				this.LineLeft.sprite = sprite;
				this.LineRight.sprite = sprite;
				return;
			}
		}

		// Token: 0x06002035 RID: 8245 RVA: 0x003D24C8 File Offset: 0x003D06C8
		public void OnClose()
		{
			StringManager.Instance.DeSpawnString(this.TechNameStr);
			StringManager.Instance.DeSpawnString(this.TechLvStr);
		}

		// Token: 0x06002036 RID: 8246 RVA: 0x003D24F8 File Offset: 0x003D06F8
		public void TextRefresh()
		{
			if (this.Level == null)
			{
				return;
			}
			this.Level.enabled = false;
			this.Name.enabled = false;
			this.Level.enabled = true;
			this.Name.enabled = true;
		}

		// Token: 0x06002037 RID: 8247 RVA: 0x003D2548 File Offset: 0x003D0748
		public void Update()
		{
			if (!this.Researching.gameObject.activeSelf)
			{
				return;
			}
			if (this.RotTime <= 1.3f)
			{
				Quaternion localRotation = this.Researching.localRotation;
				Vector3 eulerAngles = localRotation.eulerAngles;
				if (this.RotTime <= 0.5f)
				{
					eulerAngles.z = EasingEffect.Linear(this.RotTime, 0f, 180f, 0.5f);
				}
				else
				{
					eulerAngles.z = 180f;
				}
				localRotation.eulerAngles = eulerAngles;
				this.Researching.localRotation = localRotation;
			}
			else if (this.RotTime <= 2.6f)
			{
				float num = this.RotTime - 1.3f;
				Quaternion localRotation2 = this.Researching.localRotation;
				Vector3 eulerAngles2 = localRotation2.eulerAngles;
				if (num <= 0.5f)
				{
					eulerAngles2.z = EasingEffect.Linear(num, 180f, 180f, 0.5f);
				}
				else
				{
					eulerAngles2.z = 360f;
				}
				localRotation2.eulerAngles = eulerAngles2;
				this.Researching.localRotation = localRotation2;
			}
			else
			{
				this.RotTime = 0f;
			}
			this.RotTime += Time.smoothDeltaTime;
		}

		// Token: 0x04006573 RID: 25971
		public RectTransform TechTransform;

		// Token: 0x04006574 RID: 25972
		public RectTransform TechIconTrans;

		// Token: 0x04006575 RID: 25973
		public RectTransform FrameTransform;

		// Token: 0x04006576 RID: 25974
		public RectTransform Researching;

		// Token: 0x04006577 RID: 25975
		public Transform BlackFrame;

		// Token: 0x04006578 RID: 25976
		public Transform Lock;

		// Token: 0x04006579 RID: 25977
		public Transform Lock1;

		// Token: 0x0400657A RID: 25978
		public Image TechIcon;

		// Token: 0x0400657B RID: 25979
		public Image LineUp;

		// Token: 0x0400657C RID: 25980
		public Image LineDown;

		// Token: 0x0400657D RID: 25981
		public Image LineLeft;

		// Token: 0x0400657E RID: 25982
		public Image LineRight;

		// Token: 0x0400657F RID: 25983
		public Image TechLock;

		// Token: 0x04006580 RID: 25984
		public Image Degree;

		// Token: 0x04006581 RID: 25985
		public Image Frame;

		// Token: 0x04006582 RID: 25986
		public Image LockImg;

		// Token: 0x04006583 RID: 25987
		public UIButton TechBtn;

		// Token: 0x04006584 RID: 25988
		public UIText Level;

		// Token: 0x04006585 RID: 25989
		public UIText Name;

		// Token: 0x04006586 RID: 25990
		private CString TechNameStr;

		// Token: 0x04006587 RID: 25991
		private CString TechLvStr;

		// Token: 0x04006588 RID: 25992
		private float RotTime;

		// Token: 0x04006589 RID: 25993
		private Vector2 FramePos;

		// Token: 0x0400658A RID: 25994
		private Vector2 FrameSize;

		// Token: 0x0400658B RID: 25995
		private Vector2 LineRPos;

		// Token: 0x0400658C RID: 25996
		private Vector2 LineRSize;

		// Token: 0x0400658D RID: 25997
		private Vector2 LineLPos;

		// Token: 0x0400658E RID: 25998
		private Vector2 LineLSize;

		// Token: 0x0400658F RID: 25999
		private Vector2 LineTPos;

		// Token: 0x04006590 RID: 26000
		private Vector2 LineTSize;

		// Token: 0x04006591 RID: 26001
		private Vector2 LineBPos;

		// Token: 0x04006592 RID: 26002
		private Vector2 LineBSize;

		// Token: 0x04006593 RID: 26003
		public ushort GraphicID;

		// Token: 0x04006594 RID: 26004
		private byte RequireBuildLv;

		// Token: 0x04006595 RID: 26005
		private UITechTree.TechItem._RequireTech[] RequireTech = new UITechTree.TechItem._RequireTech[4];

		// Token: 0x04006596 RID: 26006
		public byte State;

		// Token: 0x04006597 RID: 26007
		private UISpritesArray SpriteArr;

		// Token: 0x04006598 RID: 26008
		public int FrameIndex;

		// Token: 0x0200068D RID: 1677
		private struct _RequireTech
		{
			// Token: 0x04006599 RID: 26009
			public ushort TechID;

			// Token: 0x0400659A RID: 26010
			public byte Lv;
		}
	}

	// Token: 0x0200068E RID: 1678
	public struct LineItem
	{
		// Token: 0x06002038 RID: 8248 RVA: 0x003D268C File Offset: 0x003D088C
		public void Init(Transform transform)
		{
			this.LineTrans = transform.GetComponent<RectTransform>();
			this.LineImg = transform.GetComponent<Image>();
		}

		// Token: 0x0400659B RID: 26011
		public RectTransform LineTrans;

		// Token: 0x0400659C RID: 26012
		public Image LineImg;
	}

	// Token: 0x0200068F RID: 1679
	public struct ItemEdit
	{
		// Token: 0x06002039 RID: 8249 RVA: 0x003D26A8 File Offset: 0x003D08A8
		public void Init(Transform transform, IUIButtonClickHandler handler, UISpritesArray spriteArray)
		{
			this.ItemTransform = (transform as RectTransform);
			this.Tech = new UITechTree.TechItem[4];
			this.Line = new UITechTree.LineItem[2];
			this.Node = new Image[14];
			this.SpriteArray = spriteArray;
			for (int i = 0; i < this.Tech.Length; i++)
			{
				this.Tech[i] = new UITechTree.TechItem();
				this.Tech[i].Init(this.ItemTransform.GetChild(i), handler);
			}
			for (int j = 0; j < this.Line.Length; j++)
			{
				this.Line[j].Init(transform.GetChild(j + 4));
			}
			for (int k = 0; k < this.Node.Length; k++)
			{
				this.Node[k] = transform.GetChild(k + 6).GetComponent<Image>();
			}
		}

		// Token: 0x0600203A RID: 8250 RVA: 0x003D2790 File Offset: 0x003D0990
		public void UpdateLineLRState()
		{
			DataManager instance = DataManager.Instance;
			for (int i = 0; i < this.Tech.Length; i++)
			{
				if ((this.Tech[i].State & 2) == 0)
				{
					this.Tech[i].LineDown.sprite = this.SpriteArray.GetSprite(2);
					this.Tech[i].LineLeft.sprite = this.SpriteArray.GetSprite(2);
					this.Tech[i].LineRight.sprite = this.SpriteArray.GetSprite(2);
				}
				else
				{
					if (i > 0)
					{
						byte b = instance.CheckTechState((ushort)this.Tech[i - 1].TechBtn.m_BtnID2);
						if ((b & 2) > 0)
						{
							this.Tech[i].LineLeft.sprite = this.SpriteArray.GetSprite(3);
						}
						else
						{
							this.Tech[i].LineLeft.sprite = this.SpriteArray.GetSprite((int)(2 + ((b & 1) ^ 1)));
						}
					}
					if (i + 1 < this.Tech.Length)
					{
						byte b = instance.CheckTechState((ushort)this.Tech[i + 1].TechBtn.m_BtnID2);
						if ((b & 2) > 0)
						{
							this.Tech[i].LineRight.sprite = this.SpriteArray.GetSprite(3);
						}
						else
						{
							this.Tech[i].LineRight.sprite = this.SpriteArray.GetSprite((int)(2 + ((b & 1) ^ 1)));
						}
					}
				}
			}
		}

		// Token: 0x0600203B RID: 8251 RVA: 0x003D2920 File Offset: 0x003D0B20
		public void OnClose()
		{
			if (this.Tech == null)
			{
				return;
			}
			for (int i = 0; i < this.Tech.Length; i++)
			{
				if (this.Tech[i] != null)
				{
					this.Tech[i].OnClose();
				}
			}
		}

		// Token: 0x0600203C RID: 8252 RVA: 0x003D296C File Offset: 0x003D0B6C
		public void TextRefresh()
		{
			if (this.Tech == null)
			{
				return;
			}
			for (int i = 0; i < this.Tech.Length; i++)
			{
				if (this.Tech[i] == null)
				{
					break;
				}
				this.Tech[i].TextRefresh();
			}
		}

		// Token: 0x0600203D RID: 8253 RVA: 0x003D29C0 File Offset: 0x003D0BC0
		public void Update()
		{
			if (!this.ItemTransform.gameObject.activeSelf)
			{
				return;
			}
			for (int i = 0; i < this.Tech.Length; i++)
			{
				this.Tech[i].Update();
			}
		}

		// Token: 0x0400659D RID: 26013
		public int DataIndex;

		// Token: 0x0400659E RID: 26014
		public int PanelIndex;

		// Token: 0x0400659F RID: 26015
		public RectTransform ItemTransform;

		// Token: 0x040065A0 RID: 26016
		public UITechTree.TechItem[] Tech;

		// Token: 0x040065A1 RID: 26017
		public UITechTree.LineItem[] Line;

		// Token: 0x040065A2 RID: 26018
		public Image[] Node;

		// Token: 0x040065A3 RID: 26019
		private UISpritesArray SpriteArray;
	}

	// Token: 0x02000690 RID: 1680
	private enum SpriteArrayIdx
	{
		// Token: 0x040065A5 RID: 26021
		Box,
		// Token: 0x040065A6 RID: 26022
		BoxOn,
		// Token: 0x040065A7 RID: 26023
		Line,
		// Token: 0x040065A8 RID: 26024
		LineOn,
		// Token: 0x040065A9 RID: 26025
		Linel,
		// Token: 0x040065AA RID: 26026
		LinelOn,
		// Token: 0x040065AB RID: 26027
		Liner,
		// Token: 0x040065AC RID: 26028
		LinerOn,
		// Token: 0x040065AD RID: 26029
		Linepoint,
		// Token: 0x040065AE RID: 26030
		LinepointOn
	}
}
