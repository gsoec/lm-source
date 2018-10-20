using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020005B5 RID: 1461
public class UIInformation : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
	// Token: 0x06001CF9 RID: 7417 RVA: 0x0033D9D4 File Offset: 0x0033BBD4
	public override void OnOpen(int arg1, int arg2)
	{
		GameObject gameObject = new GameObject();
		this.context = gameObject.AddComponent<UIText>();
		this.context.enabled = false;
		gameObject.transform.SetParent(base.transform, false);
		this.DM = DataManager.Instance;
		this.TTF = GUIManager.Instance.GetTTFFont();
		this.m_SpritesArray = base.transform.GetComponent<UISpritesArray>();
		this.m_ItemInfo = new List<InfoItem>();
		this.m_ScrollPanel = base.transform.GetChild(2).GetComponent<ScrollPanel>();
		this.m_TitleText = base.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
		this.m_TitleText.font = this.TTF;
		if (arg1 > 0)
		{
			this.m_ManorID = (ushort)arg2;
			if ((int)this.m_ManorID < GUIManager.Instance.BuildingData.AllBuildsData.Length)
			{
				this.m_BuildID = GUIManager.Instance.BuildingData.AllBuildsData[(int)this.m_ManorID].BuildID;
				this.m_NowLv = GUIManager.Instance.BuildingData.AllBuildsData[(int)this.m_ManorID].Level;
			}
			if (this.m_BuildID == 0)
			{
				this.m_BuildID = (ushort)arg1;
			}
			if (this.m_BuildID == 16)
			{
				this.MaxBuildLevel = 9;
			}
			this.m_NowLv_Extea = this.m_NowLv;
			this.SetBuildTypeData();
		}
		else if (arg1 == -1)
		{
			this.m_TechID = (ushort)arg2;
			this.m_NowLv = this.DM.GetTechLevel(this.m_TechID);
			this.MaxTechLevel = (int)this.DM.TechData.GetRecordByKey(this.m_TechID).LevelMax;
			this.SetTechTypeData();
		}
		else if (arg1 == -2)
		{
			byte saveIndex = (byte)(arg2 & 65535);
			this.m_TalentID = (ushort)(arg2 >> 16);
			TalentTbl recordByKey = this.DM.TalentData.GetRecordByKey(this.m_TalentID);
			this.m_NowLv = this.DM.GetTalentLevel(this.m_TalentID, saveIndex);
			this.MaxTalentLevel = (int)recordByKey.LevelMax;
			this.SetTalentTypeData();
		}
		this.InitPanelColumItem();
		for (int i = 0; i < 6; i++)
		{
			base.transform.GetChild(4).GetChild(i).gameObject.SetActive(true);
		}
		List<float> list = new List<float>();
		for (int j = 0; j < this.m_ItemInfo.Count; j++)
		{
			list.Add(this.m_ItemInfo[j].m_Height);
		}
		this.m_ScrollPanel.IntiScrollPanel(509f, 0f, 0f, list, 15, this);
		if (GUIManager.Instance.bOpenOnIPhoneX)
		{
			Image component = base.transform.GetChild(5).GetComponent<Image>();
			if (component)
			{
				component.enabled = false;
			}
		}
		UIButton component2 = base.transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
		component2.m_Handler = this;
		component2.m_BtnID1 = 0;
		if ((arg1 > 0 && this.m_BuildID == 20) || this.m_BuildID == 21 || this.m_BuildID == 22 || this.m_BuildID == 23)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
		}
		else if (arg1 == -1 && DataManager.StageDataController.StageRecord[2] >= 8)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
		}
		else
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
		}
	}

	// Token: 0x06001CFA RID: 7418 RVA: 0x0033DD74 File Offset: 0x0033BF74
	private void InitPanelColumItem()
	{
		this.m_Item = new PanelColumItem[15];
		for (int i = 0; i < this.m_Item.Length; i++)
		{
			this.m_Item[i].column = new PanelColumn[6];
		}
	}

	// Token: 0x06001CFB RID: 7419 RVA: 0x0033DDC0 File Offset: 0x0033BFC0
	public override void OnClose()
	{
		for (int i = 0; i < this.m_ItemInfo.Count; i++)
		{
			for (int j = 0; j < this.m_ItemInfo[i].m_Column.Length; j++)
			{
				StringManager.Instance.DeSpawnString(this.m_ItemInfo[i].m_Column[j].m_Str);
			}
		}
	}

	// Token: 0x06001CFC RID: 7420 RVA: 0x0033DE34 File Offset: 0x0033C034
	private void SetBuildTypeData()
	{
		BuildTypeData recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey(this.m_BuildID);
		this.m_TitleText.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.NameID);
		this.m_ItemInfo.Clear();
		int num = 0;
		UIText component = base.transform.GetChild(4).GetChild(0).GetChild(1).GetComponent<UIText>();
		component.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.ContentID);
		component.font = this.TTF;
		component.fontSize = 24;
		InfoItem infoItem = new InfoItem();
		infoItem.m_Type = 0;
		infoItem.bHaveLvColumn = false;
		infoItem.m_ColumNum = 1;
		infoItem.m_Height = component.preferredHeight;
		infoItem.m_Width = this.m_ScrollWidth;
		infoItem.m_DataIdx = -1;
		infoItem.m_Column[0].m_StrID = (uint)recordByKey.ContentID;
		this.m_ItemInfo.Add(infoItem);
		infoItem = new InfoItem();
		infoItem.m_Type = 1;
		infoItem.bHaveLvColumn = false;
		infoItem.m_ColumNum = 1;
		infoItem.m_Height = 42f;
		infoItem.m_Width = this.m_ScrollWidth;
		infoItem.m_DataIdx = -2;
		infoItem.m_Column[0].m_StrID = 3817u;
		this.m_ItemInfo.Add(infoItem);
		infoItem = new InfoItem();
		infoItem.m_Type = 2;
		infoItem.bHaveLvColumn = false;
		infoItem.m_ColumNum = 1;
		infoItem.m_Height = 46f;
		infoItem.m_Width = this.m_ScrollWidth;
		infoItem.m_DataIdx = -3;
		infoItem.m_Column[0].m_StrID = 4549u;
		infoItem.m_Column[0].ColumnWidth = 63f;
		uint[] array = this.GetColumnName(this.m_BuildID, out num);
		infoItem.m_ColumNum = num;
		infoItem.m_Column[0].bFisetColumn = true;
		infoItem.m_Column[infoItem.m_ColumNum].bLastColumn = true;
		for (int i = 0; i < array.Length; i++)
		{
			int num2 = i + 1;
			if (num2 < infoItem.m_Column.Length)
			{
				infoItem.m_Column[num2].m_StrID = array[i];
			}
		}
		float num3 = (829f - infoItem.m_Column[0].ColumnWidth) / (float)infoItem.m_ColumNum;
		for (int j = 1; j < infoItem.m_Column.Length; j++)
		{
			infoItem.m_Column[j].ColumnWidth = num3;
		}
		this.m_ItemInfo.Add(infoItem);
		bool flag = false;
		byte b = 0;
		byte b2 = 1;
		while ((int)b2 <= this.MaxBuildLevel)
		{
			infoItem = new InfoItem();
			infoItem.m_Type = 3;
			infoItem.bHaveLvColumn = true;
			infoItem.m_ColumNum = num;
			infoItem.m_Height = 40f;
			infoItem.m_Width = this.m_ScrollWidth;
			infoItem.m_DataIdx = -3;
			infoItem.m_Column[0].ColumnWidth = 63f;
			infoItem.m_Column[0].m_Value = (long)b2;
			long[] columnValue = this.GetColumnValue(this.m_BuildID, b2);
			uint[] columnEffect = this.GetColumnEffect(this.m_BuildID, b2);
			for (int k = 0; k < columnValue.Length; k++)
			{
				int num2 = k + 1;
				if (num2 < infoItem.m_Column.Length)
				{
					infoItem.m_Column[num2].m_Value = columnValue[k];
					infoItem.m_Column[num2].m_EffID = columnEffect[k];
					if (infoItem.m_Column[num2].m_EffID > 1000u)
					{
						infoItem.m_Height = this.CalculateTextHeight((ushort)infoItem.m_Column[num2].m_EffID, num3, this.context);
					}
				}
			}
			for (int l = 1; l < infoItem.m_Column.Length; l++)
			{
				infoItem.m_Column[l].ColumnWidth = num3;
			}
			if (infoItem.m_Column[1].m_EffID != 0u)
			{
				infoItem.m_Column[0].bFisetColumn = true;
				infoItem.m_Column[infoItem.m_ColumNum].bLastColumn = true;
				this.m_ItemInfo.Add(infoItem);
				if (b2 < this.m_NowLv)
				{
					b = b2;
				}
				if (this.m_NowLv == b2)
				{
					flag = true;
				}
			}
			b2 += 1;
		}
		if (!flag)
		{
			this.m_NowLv = b;
		}
		array = this.GetColumnName_extra(this.m_BuildID, out num);
		if (num > 0)
		{
			infoItem = new InfoItem();
			infoItem.m_Type = 4;
			infoItem.bHaveLvColumn = false;
			infoItem.m_Height = 40f;
			infoItem.m_Width = this.m_ScrollWidth;
			this.m_ItemInfo.Add(infoItem);
			infoItem = new InfoItem();
			infoItem.m_Type = 1;
			infoItem.bHaveLvColumn = false;
			infoItem.m_ColumNum = 1;
			infoItem.m_Height = 42f;
			infoItem.m_Width = this.m_ScrollWidth;
			infoItem.m_DataIdx = -2;
			infoItem.m_Column[0].m_StrID = 152u;
			this.m_ItemInfo.Add(infoItem);
			infoItem = new InfoItem();
			infoItem.m_Type = 2;
			infoItem.bHaveLvColumn = false;
			infoItem.m_ColumNum = num;
			infoItem.m_Height = 46f;
			infoItem.m_Width = this.m_ScrollWidth;
			infoItem.m_DataIdx = -3;
			infoItem.m_Column[0].m_StrID = 4549u;
			infoItem.m_Column[0].ColumnWidth = 63f;
			infoItem.m_Column[0].bFisetColumn = true;
			infoItem.m_Column[infoItem.m_ColumNum].bLastColumn = true;
			for (int m = 0; m < array.Length; m++)
			{
				infoItem.m_Column[m + 1].m_StrID = array[m];
			}
			num3 = (829f - infoItem.m_Column[0].ColumnWidth) / (float)infoItem.m_ColumNum;
			for (int n = 1; n < infoItem.m_Column.Length; n++)
			{
				infoItem.m_Column[n].ColumnWidth = num3;
			}
			this.m_ItemInfo.Add(infoItem);
			uint[] array2 = new uint[2];
			uint[] array3 = new uint[2];
			b = 0;
			flag = false;
			byte b3 = 1;
			while ((int)b3 <= this.MaxBuildLevel)
			{
				BuildLevelRequest buildLevelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(this.m_BuildID, b3);
				if (buildLevelRequestData.ExtEffect1 != 0 && (array2[0] != (uint)buildLevelRequestData.ExtEffect1 || array3[0] != buildLevelRequestData.ExtValue1))
				{
					array3[0] = buildLevelRequestData.ExtValue1;
					array2[0] = (uint)buildLevelRequestData.ExtEffect1;
					infoItem = new InfoItem();
					infoItem.m_Type = 5;
					infoItem.m_ColumNum = num;
					infoItem.m_Height = 40f;
					infoItem.m_Width = this.m_ScrollWidth;
					infoItem.m_Column[0].ColumnWidth = 63f;
					num3 = (829f - infoItem.m_Column[0].ColumnWidth) / (float)infoItem.m_ColumNum;
					infoItem.m_Column[0].m_Value = (long)b3;
					GameConstants.GetEffectValue(infoItem.m_Column[1].m_Str, buildLevelRequestData.ExtEffect1, buildLevelRequestData.ExtValue1, 3, 0f);
					infoItem.m_Column[1].ColumnWidth = num3;
					infoItem.m_Column[1].m_EffID = (uint)buildLevelRequestData.ExtEffect1;
					if (num > 1 && (array2[1] != (uint)buildLevelRequestData.ExtEffect2 || array3[1] != (uint)buildLevelRequestData.ExtValue2))
					{
						array2[1] = (uint)buildLevelRequestData.ExtEffect2;
						GameConstants.GetEffectValue(infoItem.m_Column[2].m_Str, buildLevelRequestData.ExtEffect2, (uint)buildLevelRequestData.ExtValue2, 3, 0f);
						infoItem.m_Column[2].m_EffID = (uint)buildLevelRequestData.ExtEffect2;
						infoItem.m_Column[2].ColumnWidth = num3;
					}
					this.m_ItemInfo.Add(infoItem);
					if (b3 < this.m_NowLv_Extea)
					{
						b = b3;
					}
					if (this.m_NowLv_Extea == b3)
					{
						flag = true;
					}
				}
				b3 += 1;
			}
			if (!flag)
			{
				this.m_NowLv_Extea = b;
			}
		}
		if (this.m_BuildID == 18)
		{
			num3 = 414.5f;
			infoItem = new InfoItem();
			infoItem.m_Type = 2;
			infoItem.bHaveLvColumn = false;
			infoItem.m_ColumNum = 1;
			infoItem.m_Height = 46f;
			infoItem.m_Width = this.m_ScrollWidth;
			infoItem.m_DataIdx = -3;
			infoItem.m_Column[0].m_StrID = 5902u;
			infoItem.m_Column[0].ColumnWidth = num3;
			infoItem.m_Column[1].m_StrID = 5903u;
			infoItem.m_Column[1].ColumnWidth = num3;
			infoItem.m_Column[0].bFisetColumn = true;
			infoItem.m_Column[1].bLastColumn = true;
			this.m_ItemInfo.Add(infoItem);
			for (int num4 = 0; num4 < 9; num4++)
			{
				infoItem = new InfoItem();
				infoItem.m_Type = 6;
				infoItem.m_ColumNum = num;
				infoItem.m_Height = 40f;
				infoItem.m_Width = this.m_ScrollWidth;
				infoItem.m_Column[0].ColumnWidth = num3;
				infoItem.m_Column[0].m_EffID = (uint)this.ExtraDataLvMin[num4];
				infoItem.m_Column[0].m_Value = (long)((ulong)this.ExtraDataLvMax[num4]);
				infoItem.m_Column[0].bFisetColumn = true;
				infoItem.m_Column[1].bLastColumn = true;
				infoItem.m_Column[1].ColumnWidth = num3;
				infoItem.m_Column[1].m_EffID = (uint)this.AttackBonus[num4];
				this.m_ItemInfo.Add(infoItem);
			}
		}
	}

	// Token: 0x06001CFD RID: 7421 RVA: 0x0033E8EC File Offset: 0x0033CAEC
	private void SetTechTypeData()
	{
		this.m_ItemInfo.Clear();
		InfoItem infoItem = new InfoItem();
		infoItem.m_Type = 1;
		infoItem.bHaveLvColumn = false;
		infoItem.m_ColumNum = 1;
		infoItem.m_Height = 42f;
		infoItem.m_Width = this.m_ScrollWidth;
		infoItem.m_DataIdx = -2;
		infoItem.m_Column[0].m_StrID = 3817u;
		this.m_ItemInfo.Add(infoItem);
		infoItem = new InfoItem();
		infoItem.m_Type = 2;
		infoItem.bHaveLvColumn = false;
		infoItem.m_ColumNum = 1;
		infoItem.m_Height = 46f;
		infoItem.m_Width = this.m_ScrollWidth;
		infoItem.m_DataIdx = -3;
		infoItem.m_Column[0].m_StrID = 4549u;
		infoItem.m_Column[0].ColumnWidth = 63f;
		infoItem.m_Column[0].bFisetColumn = true;
		infoItem.m_Column[infoItem.m_ColumNum].bLastColumn = true;
		float num = 829f - infoItem.m_Column[0].ColumnWidth;
		TechLevelTbl techLevelTbl;
		this.DM.GetTechLevelupData(out techLevelTbl, this.m_TechID, 1);
		infoItem.m_Column[1].ColumnWidth = num;
		infoItem.m_Column[1].m_StrID = this.GetColumnName_Tech(this.m_TechID);
		this.m_ItemInfo.Add(infoItem);
		byte b = 1;
		while ((int)b <= this.MaxTechLevel)
		{
			this.DM.GetTechLevelupData(out techLevelTbl, this.m_TechID, b);
			infoItem = new InfoItem();
			infoItem.m_Type = 3;
			infoItem.bHaveLvColumn = true;
			infoItem.m_ColumNum = 2;
			infoItem.m_Height = 40f;
			infoItem.m_Width = this.m_ScrollWidth;
			infoItem.m_DataIdx = -3;
			infoItem.m_Column[0].ColumnWidth = 63f;
			infoItem.m_Column[0].bFisetColumn = true;
			infoItem.m_Column[infoItem.m_ColumNum].bLastColumn = true;
			infoItem.m_Column[0].m_Value = (long)b;
			infoItem.m_Column[1].m_EffID = (uint)techLevelTbl.Effect;
			infoItem.m_Column[1].m_Value = (long)((ulong)techLevelTbl.EffectVal);
			infoItem.m_Column[1].ColumnWidth = num;
			if (infoItem.m_Column[1].m_EffID > 1000u)
			{
				infoItem.m_Height = this.CalculateTextHeight((ushort)infoItem.m_Column[1].m_EffID, num, this.context);
			}
			this.m_ItemInfo.Add(infoItem);
			b += 1;
		}
		TechDataTbl recordByKey = this.DM.TechData.GetRecordByKey(techLevelTbl.TechID);
		this.m_TitleText.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.TechName);
	}

	// Token: 0x06001CFE RID: 7422 RVA: 0x0033EBE0 File Offset: 0x0033CDE0
	private void SetTalentTypeData()
	{
		this.m_ItemInfo.Clear();
		InfoItem infoItem = new InfoItem();
		infoItem.m_Type = 1;
		infoItem.bHaveLvColumn = false;
		infoItem.m_ColumNum = 1;
		infoItem.m_Height = 42f;
		infoItem.m_Width = this.m_ScrollWidth;
		infoItem.m_DataIdx = -2;
		infoItem.m_Column[0].m_StrID = 3817u;
		this.m_ItemInfo.Add(infoItem);
		infoItem = new InfoItem();
		infoItem.m_Type = 2;
		infoItem.bHaveLvColumn = false;
		infoItem.m_ColumNum = 1;
		infoItem.m_Height = 46f;
		infoItem.m_Width = this.m_ScrollWidth;
		infoItem.m_DataIdx = -3;
		infoItem.m_Column[0].m_StrID = 4549u;
		infoItem.m_Column[0].ColumnWidth = 63f;
		infoItem.m_Column[0].bFisetColumn = true;
		infoItem.m_Column[infoItem.m_ColumNum].bLastColumn = true;
		float columnWidth = 829f - infoItem.m_Column[0].ColumnWidth;
		TalentLevelTbl talentLevelTbl;
		this.DM.GetTalentLevelupData(out talentLevelTbl, this.m_TalentID, 1);
		infoItem.m_Column[1].ColumnWidth = columnWidth;
		infoItem.m_Column[1].m_StrID = this.GetColumName_Talent(this.m_TalentID);
		this.m_ItemInfo.Add(infoItem);
		byte b = 1;
		while ((int)b <= this.MaxTalentLevel)
		{
			this.DM.GetTalentLevelupData(out talentLevelTbl, this.m_TalentID, b);
			infoItem = new InfoItem();
			infoItem.m_Type = 3;
			infoItem.bHaveLvColumn = true;
			infoItem.m_ColumNum = 2;
			infoItem.m_Height = 40f;
			infoItem.m_Width = this.m_ScrollWidth;
			infoItem.m_DataIdx = -3;
			infoItem.m_Column[0].ColumnWidth = 63f;
			infoItem.m_Column[0].bFisetColumn = true;
			infoItem.m_Column[infoItem.m_ColumNum].bLastColumn = true;
			infoItem.m_Column[0].m_Value = (long)b;
			infoItem.m_Column[1].m_EffID = (uint)talentLevelTbl.Effect;
			infoItem.m_Column[1].m_Value = (long)talentLevelTbl.EffectVal;
			infoItem.m_Column[1].ColumnWidth = columnWidth;
			this.m_ItemInfo.Add(infoItem);
			b += 1;
		}
		TalentTbl recordByKey = this.DM.TalentData.GetRecordByKey(this.m_TalentID);
		this.m_TitleText.text = this.DM.mStringTable.GetStringByID((uint)recordByKey.NameID);
	}

	// Token: 0x06001CFF RID: 7423 RVA: 0x0033EE94 File Offset: 0x0033D094
	private uint[] GetColumnName(ushort buildID, out int columNum)
	{
		uint[] array = new uint[5];
		byte b = 1;
		while ((int)b <= this.MaxBuildLevel)
		{
			BuildLevelRequest buildLevelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(this.m_BuildID, b);
			if (buildLevelRequestData.Effect1 != 0)
			{
				if (buildLevelRequestData.Effect1 > 1000)
				{
					array[0] = 1048u;
				}
				else
				{
					array[0] = (uint)this.DM.EffectData.GetRecordByKey(buildLevelRequestData.Effect1).InfoID;
				}
			}
			if (buildLevelRequestData.Effect2 != 0)
			{
				if (buildLevelRequestData.Effect2 > 1000)
				{
					array[1] = 1048u;
				}
				else
				{
					array[1] = (uint)this.DM.EffectData.GetRecordByKey(buildLevelRequestData.Effect2).InfoID;
				}
			}
			if (buildLevelRequestData.Effect3 != 0)
			{
				if (buildLevelRequestData.Effect3 > 1000)
				{
					array[2] = 1048u;
				}
				else
				{
					array[2] = (uint)this.DM.EffectData.GetRecordByKey(buildLevelRequestData.Effect3).InfoID;
				}
			}
			if (buildLevelRequestData.Effect4 != 0)
			{
				if (buildLevelRequestData.Effect4 > 1000)
				{
					array[3] = 1048u;
				}
				else
				{
					array[3] = (uint)this.DM.EffectData.GetRecordByKey(buildLevelRequestData.Effect4).InfoID;
				}
			}
			if (buildLevelRequestData.Value5 != 0)
			{
				if (buildLevelRequestData.Value5 > 1000)
				{
					array[4] = 1048u;
				}
				else
				{
					array[4] = (uint)this.DM.EffectData.GetRecordByKey(buildLevelRequestData.Value5).InfoID;
				}
			}
			b += 1;
		}
		columNum = 0;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != 0u)
			{
				columNum++;
			}
		}
		return array;
	}

	// Token: 0x06001D00 RID: 7424 RVA: 0x0033F080 File Offset: 0x0033D280
	private uint GetColumnName_Tech(ushort techID)
	{
		uint result = 0u;
		TechLevelTbl techLevelTbl;
		this.DM.GetTechLevelupData(out techLevelTbl, techID, 1);
		if (techLevelTbl.Effect != 0)
		{
			if (techLevelTbl.Effect > 1000)
			{
				result = 1048u;
			}
			else
			{
				result = (uint)this.DM.EffectData.GetRecordByKey(techLevelTbl.Effect).InfoID;
			}
		}
		return result;
	}

	// Token: 0x06001D01 RID: 7425 RVA: 0x0033F0E8 File Offset: 0x0033D2E8
	private uint GetColumName_Talent(ushort talentID)
	{
		uint result = 0u;
		TalentLevelTbl talentLevelTbl;
		this.DM.GetTalentLevelupData(out talentLevelTbl, talentID, 1);
		if (talentLevelTbl.Effect != 0)
		{
			if (talentLevelTbl.Effect > 1000)
			{
				result = 1048u;
			}
			else
			{
				result = (uint)this.DM.EffectData.GetRecordByKey(talentLevelTbl.Effect).InfoID;
			}
		}
		return result;
	}

	// Token: 0x06001D02 RID: 7426 RVA: 0x0033F150 File Offset: 0x0033D350
	private long[] GetColumnValue(ushort buildID, byte lv)
	{
		long[] array = new long[5];
		BuildLevelRequest buildLevelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(this.m_BuildID, lv);
		if (buildLevelRequestData.Value1 != 0u)
		{
			array[0] = (long)((ulong)buildLevelRequestData.Value1);
		}
		if (buildLevelRequestData.Value2 != 0u)
		{
			array[1] = (long)((ulong)buildLevelRequestData.Value2);
		}
		if (buildLevelRequestData.Value3 != 0)
		{
			array[2] = (long)buildLevelRequestData.Value3;
		}
		if (buildLevelRequestData.Value4 != 0)
		{
			array[3] = (long)buildLevelRequestData.Value4;
		}
		return array;
	}

	// Token: 0x06001D03 RID: 7427 RVA: 0x0033F1D8 File Offset: 0x0033D3D8
	private uint[] GetColumnEffect(ushort buildID, byte lv)
	{
		uint[] array = new uint[5];
		BuildLevelRequest buildLevelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(this.m_BuildID, lv);
		if (buildLevelRequestData.Effect1 != 0)
		{
			array[0] = (uint)buildLevelRequestData.Effect1;
		}
		if (buildLevelRequestData.Effect2 != 0)
		{
			array[1] = (uint)buildLevelRequestData.Effect2;
		}
		if (buildLevelRequestData.Effect3 != 0)
		{
			array[2] = (uint)buildLevelRequestData.Effect3;
		}
		if (buildLevelRequestData.Effect4 != 0)
		{
			array[3] = (uint)buildLevelRequestData.Effect4;
		}
		if (buildLevelRequestData.Value5 != 0)
		{
			array[4] = (uint)buildLevelRequestData.Value5;
		}
		return array;
	}

	// Token: 0x06001D04 RID: 7428 RVA: 0x0033F274 File Offset: 0x0033D474
	private uint[] GetColumnName_extra(ushort buildID, out int columNum)
	{
		uint[] array = new uint[2];
		columNum = 0;
		byte b = 1;
		while ((int)b <= this.MaxBuildLevel)
		{
			BuildLevelRequest buildLevelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(this.m_BuildID, b);
			if (buildLevelRequestData.ExtEffect1 != 0)
			{
				if (buildLevelRequestData.ExtEffect1 > 1000)
				{
					array[0] = 1048u;
				}
				else
				{
					array[0] = (uint)this.DM.EffectData.GetRecordByKey(buildLevelRequestData.ExtEffect1).StringID;
				}
			}
			if (buildLevelRequestData.ExtEffect2 != 0)
			{
				if (buildLevelRequestData.ExtEffect2 > 1000)
				{
					array[1] = 1048u;
				}
				else
				{
					array[1] = (uint)this.DM.EffectData.GetRecordByKey(buildLevelRequestData.ExtEffect2).StringID;
				}
			}
			b += 1;
		}
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == 0u)
			{
				columNum = i;
				break;
			}
		}
		return array;
	}

	// Token: 0x06001D05 RID: 7429 RVA: 0x0033F37C File Offset: 0x0033D57C
	public override void UpdateUI(int arg1, int arg2)
	{
		if (arg1 == 0)
		{
			this.m_NowLv = GUIManager.Instance.BuildingData.GetBuildData(this.m_BuildID, 0).Level;
			this.SetBuildTypeData();
		}
		else
		{
			this.m_NowLv = this.DM.GetTechLevel(this.m_TechID);
			this.SetTechTypeData();
		}
		List<float> list = new List<float>();
		for (int i = 0; i < this.m_ItemInfo.Count; i++)
		{
			list.Add(this.m_ItemInfo[i].m_Height);
		}
		this.m_ScrollPanel.AddNewDataHeight(list, true, true);
	}

	// Token: 0x06001D06 RID: 7430 RVA: 0x0033F424 File Offset: 0x0033D624
	public override void UpdateNetwork(byte[] meg)
	{
		NetworkNews networkNews = (NetworkNews)meg[0];
		if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
		{
			this.Refresh_FontTexture();
		}
	}

	// Token: 0x06001D07 RID: 7431 RVA: 0x0033F450 File Offset: 0x0033D650
	public void Refresh_FontTexture()
	{
		if (this.m_TitleText != null && this.m_TitleText.enabled)
		{
			this.m_TitleText.enabled = false;
			this.m_TitleText.enabled = true;
		}
		if (this.context != null && this.context.enabled)
		{
			this.context.enabled = false;
			this.context.enabled = true;
		}
		for (int i = 0; i < 15; i++)
		{
			if (this.m_Item[i].column != null)
			{
				for (int j = 0; j < 6; j++)
				{
					if (this.m_Item[i].column[j].text != null && this.m_Item[i].column[j].text.enabled)
					{
						this.m_Item[i].column[j].text.enabled = false;
						this.m_Item[i].column[j].text.enabled = true;
					}
				}
			}
		}
	}

	// Token: 0x06001D08 RID: 7432 RVA: 0x0033F59C File Offset: 0x0033D79C
	public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
	{
	}

	// Token: 0x06001D09 RID: 7433 RVA: 0x0033F5A0 File Offset: 0x0033D7A0
	public override bool OnBackButtonClick()
	{
		return false;
	}

	// Token: 0x06001D0A RID: 7434 RVA: 0x0033F5A4 File Offset: 0x0033D7A4
	public void OnButtonClick(UIButton sender)
	{
		(GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu(false);
	}

	// Token: 0x06001D0B RID: 7435 RVA: 0x0033F5BC File Offset: 0x0033D7BC
	private void ClearItem(GameObject item)
	{
		for (int i = 0; i < item.transform.childCount; i++)
		{
			Transform child = item.transform.GetChild(i);
			((RectTransform)child).sizeDelta = new Vector2(829f, 40f);
			((RectTransform)child).anchoredPosition = new Vector2(0f, 0f);
			Transform child2 = child.GetChild(0);
			((RectTransform)child2).sizeDelta = new Vector2(829f, 40f);
			((RectTransform)child2).anchoredPosition = new Vector2(0f, 0f);
			child2 = child.GetChild(1);
			((RectTransform)child2).sizeDelta = new Vector2(829f, 40f);
			((RectTransform)child2).anchoredPosition = new Vector2(0f, 0f);
			if (child.gameObject.activeSelf)
			{
				child.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001D0C RID: 7436 RVA: 0x0033F6BC File Offset: 0x0033D8BC
	private void ClearItem(int panelObjectIdx)
	{
		for (int i = 0; i < 6; i++)
		{
			if (this.m_Item[panelObjectIdx].column[i].image != null)
			{
				this.m_Item[panelObjectIdx].column[i].rect.sizeDelta = new Vector2(829f, 40f);
				this.m_Item[panelObjectIdx].column[i].rect.anchoredPosition = new Vector2(0f, 0f);
				this.m_Item[panelObjectIdx].column[i].imageRect.sizeDelta = new Vector2(829f, 40f);
				this.m_Item[panelObjectIdx].column[i].imageRect.anchoredPosition = new Vector2(0f, 0f);
				this.m_Item[panelObjectIdx].column[i].textRect.sizeDelta = new Vector2(829f, 40f);
				this.m_Item[panelObjectIdx].column[i].textRect.anchoredPosition = new Vector2(0f, 0f);
				this.m_Item[panelObjectIdx].column[i].text.fontSize = 18;
				this.m_Item[panelObjectIdx].column[i].textShadow.enabled = false;
				this.m_Item[panelObjectIdx].column[i].image.enabled = false;
				this.m_Item[panelObjectIdx].column[i].text.enabled = false;
				this.m_Item[panelObjectIdx].column[i].text.color = new Color(1f, 1f, 1f, 1f);
			}
		}
	}

	// Token: 0x06001D0D RID: 7437 RVA: 0x0033F8E8 File Offset: 0x0033DAE8
	public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
	{
		this.ClearItem(panelObjectIdx);
		int type = (int)this.m_ItemInfo[dataIdx].m_Type;
		if (this.m_Item[panelObjectIdx].column[0].image == null)
		{
			for (int i = 0; i < 6; i++)
			{
				Transform child = item.transform.GetChild(i);
				this.m_Item[panelObjectIdx].column[i].rect = child.GetComponent<RectTransform>();
				this.m_Item[panelObjectIdx].column[i].image = child.GetChild(0).GetComponent<Image>();
				this.m_Item[panelObjectIdx].column[i].imageRect = child.GetChild(0).GetComponent<RectTransform>();
				this.m_Item[panelObjectIdx].column[i].text = child.GetChild(1).GetComponent<UIText>();
				this.m_Item[panelObjectIdx].column[i].text.font = this.TTF;
				this.m_Item[panelObjectIdx].column[i].textRect = child.GetChild(1).GetComponent<RectTransform>();
				this.m_Item[panelObjectIdx].column[i].textShadow = child.GetChild(1).GetComponent<Shadow>();
				this.m_Item[panelObjectIdx].column[i].text.AdjuestUI();
			}
		}
		if (type == 0)
		{
			for (int j = 0; j < 6; j++)
			{
				if (j == 0)
				{
					Vector2 vector = this.m_Item[panelObjectIdx].column[j].rect.sizeDelta;
					vector.y = this.m_ItemInfo[dataIdx].m_Height;
					this.m_Item[panelObjectIdx].column[j].rect.sizeDelta = vector;
					if (this.m_Item[panelObjectIdx].column[j].image.enabled)
					{
						this.m_Item[panelObjectIdx].column[j].image.enabled = false;
					}
					if (!this.m_Item[panelObjectIdx].column[j].text.enabled)
					{
						this.m_Item[panelObjectIdx].column[j].text.enabled = true;
					}
					this.m_Item[panelObjectIdx].column[j].text.fontSize = 24;
					this.m_Item[panelObjectIdx].column[j].text.resizeTextMaxSize = 24;
					vector = this.m_Item[panelObjectIdx].column[j].textRect.sizeDelta;
					vector.y = this.m_ItemInfo[dataIdx].m_Height;
					vector.x = 800f;
					this.m_Item[panelObjectIdx].column[j].textRect.sizeDelta = vector;
					vector = this.m_Item[panelObjectIdx].column[j].textRect.anchoredPosition;
					vector.x = 20f;
					this.m_Item[panelObjectIdx].column[j].textRect.anchoredPosition = vector;
					this.m_Item[panelObjectIdx].column[j].text.text = this.DM.mStringTable.GetStringByID(this.m_ItemInfo[dataIdx].m_Column[j].m_StrID);
					this.m_Item[panelObjectIdx].column[j].text.alignment = ((!GUIManager.Instance.IsArabic) ? TextAnchor.MiddleLeft : TextAnchor.MiddleRight);
					this.m_Item[panelObjectIdx].column[j].textShadow.enabled = true;
				}
				else
				{
					if (this.m_Item[panelObjectIdx].column[j].image.enabled)
					{
						this.m_Item[panelObjectIdx].column[j].image.enabled = false;
					}
					if (this.m_Item[panelObjectIdx].column[j].text.enabled)
					{
						this.m_Item[panelObjectIdx].column[j].text.enabled = false;
					}
					if (this.m_Item[panelObjectIdx].column[j].textShadow)
					{
						this.m_Item[panelObjectIdx].column[j].textShadow.enabled = false;
					}
				}
				this.m_Item[panelObjectIdx].column[j].text.UpdateArabicPos();
			}
		}
		else if (type == 1)
		{
			for (int k = 0; k < 6; k++)
			{
				if (k == 0)
				{
					Vector2 vector = this.m_Item[panelObjectIdx].column[k].rect.sizeDelta;
					vector.y = this.m_ItemInfo[dataIdx].m_Height;
					this.m_Item[panelObjectIdx].column[k].rect.sizeDelta = vector;
					if (!this.m_Item[panelObjectIdx].column[k].image.enabled)
					{
						this.m_Item[panelObjectIdx].column[k].image.enabled = true;
					}
					if (!this.m_Item[panelObjectIdx].column[k].text.enabled)
					{
						this.m_Item[panelObjectIdx].column[k].text.enabled = true;
					}
					this.m_Item[panelObjectIdx].column[k].image.sprite = this.m_SpritesArray.GetSprite(12);
					this.m_Item[panelObjectIdx].column[k].image.rectTransform.sizeDelta = new Vector2(829f, 4f);
					this.m_Item[panelObjectIdx].column[k].text.fontSize = 24;
					this.m_Item[panelObjectIdx].column[k].text.resizeTextMaxSize = 24;
					this.m_Item[panelObjectIdx].column[k].text.resizeTextForBestFit = true;
					vector.y = this.m_ItemInfo[dataIdx].m_Height;
					this.m_Item[panelObjectIdx].column[k].textRect.sizeDelta = vector;
					this.m_Item[panelObjectIdx].column[k].text.text = this.DM.mStringTable.GetStringByID(this.m_ItemInfo[dataIdx].m_Column[k].m_StrID);
					this.m_Item[panelObjectIdx].column[k].text.alignment = TextAnchor.MiddleCenter;
					this.m_Item[panelObjectIdx].column[k].textShadow.enabled = true;
				}
				else
				{
					if (this.m_Item[panelObjectIdx].column[k].image.enabled)
					{
						this.m_Item[panelObjectIdx].column[k].image.enabled = false;
					}
					if (this.m_Item[panelObjectIdx].column[k].text.enabled)
					{
						this.m_Item[panelObjectIdx].column[k].text.enabled = false;
					}
					if (this.m_Item[panelObjectIdx].column[k].textShadow)
					{
						this.m_Item[panelObjectIdx].column[k].textShadow.enabled = false;
					}
				}
				this.m_Item[panelObjectIdx].column[k].text.color = new Color(1f, 1f, 0.8f, 1f);
				this.m_Item[panelObjectIdx].column[k].text.UpdateArabicPos();
			}
		}
		else if (type == 2)
		{
			float num = 0f;
			for (int l = 0; l < 6; l++)
			{
				if (this.m_ItemInfo[dataIdx].m_Column[l].m_StrID != 0u)
				{
					this.m_Item[panelObjectIdx].column[l].rect.anchoredPosition = new Vector2(num, 0f);
					Vector2 vector = this.m_Item[panelObjectIdx].column[l].rect.sizeDelta;
					num += this.m_ItemInfo[dataIdx].m_Column[l].ColumnWidth;
					vector = this.m_Item[panelObjectIdx].column[l].rect.sizeDelta;
					vector.x = this.m_ItemInfo[dataIdx].m_Column[l].ColumnWidth;
					vector.y = 46f;
					this.m_Item[panelObjectIdx].column[l].imageRect.sizeDelta = vector;
					this.m_Item[panelObjectIdx].column[l].rect.sizeDelta = vector;
					if (!this.m_Item[panelObjectIdx].column[l].image.enabled)
					{
						this.m_Item[panelObjectIdx].column[l].image.enabled = true;
					}
					if (!this.m_Item[panelObjectIdx].column[l].text.enabled)
					{
						this.m_Item[panelObjectIdx].column[l].text.enabled = true;
					}
					vector = this.m_Item[panelObjectIdx].column[l].image.rectTransform.sizeDelta;
					vector.x = this.m_ItemInfo[dataIdx].m_Column[l].ColumnWidth;
					this.m_Item[panelObjectIdx].column[l].image.rectTransform.sizeDelta = vector;
					if (this.m_ItemInfo[dataIdx].m_Column[l].bFisetColumn)
					{
						this.m_Item[panelObjectIdx].column[l].image.sprite = this.m_SpritesArray.GetSprite(1);
					}
					else if (this.m_ItemInfo[dataIdx].m_Column[l].bLastColumn)
					{
						this.m_Item[panelObjectIdx].column[l].image.sprite = this.m_SpritesArray.GetSprite(2);
					}
					else
					{
						this.m_Item[panelObjectIdx].column[l].image.sprite = this.m_SpritesArray.GetSprite(0);
					}
					this.m_Item[panelObjectIdx].column[l].text.font = this.TTF;
					this.m_Item[panelObjectIdx].column[l].text.fontSize = 24;
					this.m_Item[panelObjectIdx].column[l].text.resizeTextMaxSize = 24;
					this.m_Item[panelObjectIdx].column[l].text.resizeTextForBestFit = true;
					vector = this.m_Item[panelObjectIdx].column[l].textRect.sizeDelta;
					vector.x = this.m_ItemInfo[dataIdx].m_Column[l].ColumnWidth;
					vector.y = this.m_ItemInfo[dataIdx].m_Height;
					this.m_Item[panelObjectIdx].column[l].textRect.sizeDelta = vector;
					this.m_Item[panelObjectIdx].column[l].text.text = this.DM.mStringTable.GetStringByID(this.m_ItemInfo[dataIdx].m_Column[l].m_StrID);
					this.m_Item[panelObjectIdx].column[l].text.alignment = TextAnchor.MiddleCenter;
					this.m_Item[panelObjectIdx].column[l].text.color = new Color(1f, 1f, 0.8f, 1f);
					this.m_Item[panelObjectIdx].column[l].textShadow.enabled = false;
				}
				else
				{
					if (this.m_Item[panelObjectIdx].column[l].image.enabled)
					{
						this.m_Item[panelObjectIdx].column[l].image.enabled = false;
					}
					if (this.m_Item[panelObjectIdx].column[l].text.enabled)
					{
						this.m_Item[panelObjectIdx].column[l].text.enabled = false;
					}
					if (this.m_Item[panelObjectIdx].column[l].textShadow)
					{
						this.m_Item[panelObjectIdx].column[l].textShadow.enabled = false;
					}
				}
				this.m_Item[panelObjectIdx].column[l].text.UpdateArabicPos();
			}
		}
		else if (type == 3)
		{
			float num = 0f;
			for (int m = 0; m < 6; m++)
			{
				if (m < this.m_ItemInfo[dataIdx].m_ColumNum + 1)
				{
					Transform child = item.transform.GetChild(m);
					this.m_Item[panelObjectIdx].column[m].rect.anchoredPosition = new Vector2(num, 0f);
					num += this.m_ItemInfo[dataIdx].m_Column[m].ColumnWidth;
					Vector2 vector = this.m_Item[panelObjectIdx].column[m].rect.sizeDelta;
					vector.y = this.m_ItemInfo[dataIdx].m_Height;
					vector.x = this.m_ItemInfo[dataIdx].m_Column[m].ColumnWidth;
					this.m_Item[panelObjectIdx].column[m].rect.sizeDelta = vector;
					this.m_Item[panelObjectIdx].column[m].imageRect.sizeDelta = vector;
					if (!this.m_Item[panelObjectIdx].column[m].image.enabled)
					{
						this.m_Item[panelObjectIdx].column[m].image.enabled = true;
					}
					if (!this.m_Item[panelObjectIdx].column[m].text.enabled)
					{
						this.m_Item[panelObjectIdx].column[m].text.enabled = true;
					}
					vector = this.m_Item[panelObjectIdx].column[m].rect.sizeDelta;
					vector.y = this.m_ItemInfo[dataIdx].m_Height;
					vector.x = this.m_ItemInfo[dataIdx].m_Column[m].ColumnWidth;
					this.m_Item[panelObjectIdx].column[m].rect.sizeDelta = vector;
					if (this.m_ItemInfo[dataIdx].m_Column[0].m_Value != (long)this.m_NowLv)
					{
						if (dataIdx % 2 == 0)
						{
							if (this.m_ItemInfo[dataIdx].m_Column[m].bFisetColumn)
							{
								this.m_Item[panelObjectIdx].column[m].image.sprite = this.m_SpritesArray.GetSprite(4);
							}
							else if (this.m_ItemInfo[dataIdx].m_Column[m].bLastColumn)
							{
								this.m_Item[panelObjectIdx].column[m].image.sprite = this.m_SpritesArray.GetSprite(5);
							}
							else
							{
								this.m_Item[panelObjectIdx].column[m].image.sprite = this.m_SpritesArray.GetSprite(3);
							}
						}
						else if (this.m_ItemInfo[dataIdx].m_Column[m].bFisetColumn)
						{
							this.m_Item[panelObjectIdx].column[m].image.sprite = this.m_SpritesArray.GetSprite(7);
						}
						else if (this.m_ItemInfo[dataIdx].m_Column[m].bLastColumn)
						{
							this.m_Item[panelObjectIdx].column[m].image.sprite = this.m_SpritesArray.GetSprite(8);
						}
						else
						{
							this.m_Item[panelObjectIdx].column[m].image.sprite = this.m_SpritesArray.GetSprite(6);
						}
					}
					else if (this.m_ItemInfo[dataIdx].m_Column[m].bFisetColumn)
					{
						this.m_Item[panelObjectIdx].column[m].image.sprite = this.m_SpritesArray.GetSprite(10);
					}
					else if (this.m_ItemInfo[dataIdx].m_Column[m].bLastColumn)
					{
						this.m_Item[panelObjectIdx].column[m].image.sprite = this.m_SpritesArray.GetSprite(11);
					}
					else
					{
						this.m_Item[panelObjectIdx].column[m].image.sprite = this.m_SpritesArray.GetSprite(9);
					}
					this.m_Item[panelObjectIdx].column[m].text.font = this.TTF;
					this.m_Item[panelObjectIdx].column[m].text.fontSize = 18;
					this.m_Item[panelObjectIdx].column[m].text.resizeTextMaxSize = 18;
					this.m_Item[panelObjectIdx].column[m].text.resizeTextMinSize = 10;
					this.m_Item[panelObjectIdx].column[m].text.resizeTextForBestFit = true;
					vector = this.m_Item[panelObjectIdx].column[m].text.rectTransform.sizeDelta;
					vector.y = this.m_ItemInfo[dataIdx].m_Height;
					vector.x = this.m_ItemInfo[dataIdx].m_Column[m].ColumnWidth;
					this.m_Item[panelObjectIdx].column[m].text.rectTransform.sizeDelta = vector;
					if (m == 0)
					{
						this.m_Item[panelObjectIdx].column[m].text.text = this.m_ItemInfo[dataIdx].m_Column[m].m_Value.ToString();
						this.m_Item[panelObjectIdx].column[m].text.UpdateArabicPos();
					}
					else
					{
						if (this.m_BuildID == 18)
						{
							this.m_ItemInfo[dataIdx].m_Column[m].m_Str.ClearString();
							GameConstants.GetTimeInfoString(this.m_ItemInfo[dataIdx].m_Column[m].m_Str, (uint)this.m_ItemInfo[dataIdx].m_Column[m].m_Value);
						}
						else
						{
							GameConstants.GetEffectValue(this.m_ItemInfo[dataIdx].m_Column[m].m_Str, (ushort)this.m_ItemInfo[dataIdx].m_Column[m].m_EffID, (uint)this.m_ItemInfo[dataIdx].m_Column[m].m_Value, 3, 0f);
						}
						this.m_Item[panelObjectIdx].column[m].text.text = this.m_ItemInfo[dataIdx].m_Column[m].m_Str.ToString();
						this.m_Item[panelObjectIdx].column[m].text.UpdateArabicPos();
					}
					if (this.m_ItemInfo[dataIdx].m_Column[m].m_EffID > 1000u)
					{
						vector = this.m_Item[panelObjectIdx].column[m].text.rectTransform.anchoredPosition;
						vector.x += 5f;
						this.m_Item[panelObjectIdx].column[m].text.rectTransform.anchoredPosition = vector;
						vector = this.m_Item[panelObjectIdx].column[m].text.rectTransform.sizeDelta;
						vector.x -= 5f;
						this.m_Item[panelObjectIdx].column[m].text.rectTransform.sizeDelta = vector;
						this.m_Item[panelObjectIdx].column[m].text.alignment = ((!GUIManager.Instance.IsArabic) ? TextAnchor.MiddleLeft : TextAnchor.MiddleRight);
					}
					else
					{
						this.m_Item[panelObjectIdx].column[m].text.alignment = TextAnchor.MiddleCenter;
					}
					this.m_Item[panelObjectIdx].column[m].textShadow.enabled = false;
				}
				else
				{
					if (this.m_Item[panelObjectIdx].column[m].image.enabled)
					{
						this.m_Item[panelObjectIdx].column[m].image.enabled = false;
					}
					if (this.m_Item[panelObjectIdx].column[m].text.enabled)
					{
						this.m_Item[panelObjectIdx].column[m].text.enabled = false;
					}
					if (this.m_Item[panelObjectIdx].column[m].textShadow)
					{
						this.m_Item[panelObjectIdx].column[m].textShadow.enabled = false;
					}
				}
			}
		}
		else if (type == 4)
		{
			for (int n = 0; n < 6; n++)
			{
				Transform child = item.transform.GetChild(n);
				Vector2 vector = this.m_Item[panelObjectIdx].column[n].rect.sizeDelta;
				vector.y = this.m_ItemInfo[dataIdx].m_Height;
				this.m_Item[panelObjectIdx].column[n].rect.sizeDelta = vector;
				if (this.m_Item[panelObjectIdx].column[n].image.enabled)
				{
					this.m_Item[panelObjectIdx].column[n].image.enabled = false;
				}
				if (this.m_Item[panelObjectIdx].column[n].text.enabled)
				{
					this.m_Item[panelObjectIdx].column[n].text.enabled = false;
				}
				if (this.m_Item[panelObjectIdx].column[n].textShadow)
				{
					this.m_Item[panelObjectIdx].column[n].textShadow.enabled = false;
				}
			}
		}
		else if (type == 5)
		{
			float num = 0f;
			for (int num2 = 0; num2 < 6; num2++)
			{
				this.m_Item[panelObjectIdx].column[num2].rect.anchoredPosition = new Vector2(num, 0f);
				num += this.m_ItemInfo[dataIdx].m_Column[num2].ColumnWidth;
				Vector2 vector = this.m_Item[panelObjectIdx].column[num2].rect.sizeDelta;
				vector.x = this.m_ItemInfo[dataIdx].m_Column[num2].ColumnWidth;
				this.m_Item[panelObjectIdx].column[num2].rect.sizeDelta = vector;
				if (!this.m_Item[panelObjectIdx].column[num2].image.enabled)
				{
					this.m_Item[panelObjectIdx].column[num2].image.enabled = true;
				}
				if (!this.m_Item[panelObjectIdx].column[num2].text.enabled)
				{
					this.m_Item[panelObjectIdx].column[num2].text.enabled = true;
				}
				this.m_Item[panelObjectIdx].column[num2].text.font = this.TTF;
				this.m_Item[panelObjectIdx].column[num2].text.fontSize = 18;
				this.m_Item[panelObjectIdx].column[num2].text.resizeTextMaxSize = 18;
				vector = this.m_Item[panelObjectIdx].column[num2].text.rectTransform.sizeDelta;
				vector.x = this.m_ItemInfo[dataIdx].m_Column[num2].ColumnWidth;
				this.m_Item[panelObjectIdx].column[num2].text.rectTransform.sizeDelta = vector;
				this.m_Item[panelObjectIdx].column[num2].text.text = this.m_ItemInfo[dataIdx].m_Column[num2].m_Value.ToString();
				this.m_Item[panelObjectIdx].column[num2].text.alignment = TextAnchor.MiddleCenter;
				this.m_Item[panelObjectIdx].column[num2].textShadow.enabled = false;
				if (this.m_ItemInfo[dataIdx].m_Column[num2].m_EffID != 0u)
				{
					if (!this.m_Item[panelObjectIdx].column[num2].image.enabled)
					{
						this.m_Item[panelObjectIdx].column[num2].image.enabled = true;
					}
					if (!this.m_Item[panelObjectIdx].column[num2].text.enabled)
					{
						this.m_Item[panelObjectIdx].column[num2].text.enabled = true;
					}
					this.m_Item[panelObjectIdx].column[num2].text.font = this.TTF;
					this.m_Item[panelObjectIdx].column[num2].text.fontSize = 18;
					this.m_Item[panelObjectIdx].column[num2].text.resizeTextMaxSize = 18;
					this.m_Item[panelObjectIdx].column[num2].text.resizeTextForBestFit = true;
					vector = this.m_Item[panelObjectIdx].column[num2].text.rectTransform.sizeDelta;
					vector.x = this.m_ItemInfo[dataIdx].m_Column[num2].ColumnWidth;
					this.m_Item[panelObjectIdx].column[num2].text.rectTransform.sizeDelta = vector;
					this.m_Item[panelObjectIdx].column[num2].text.text = this.m_ItemInfo[dataIdx].m_Column[num2].m_Str.ToString();
				}
				else if (num2 == 0)
				{
					if (!this.m_Item[panelObjectIdx].column[num2].image.enabled)
					{
						this.m_Item[panelObjectIdx].column[num2].image.enabled = true;
					}
					if (!this.m_Item[panelObjectIdx].column[num2].text.enabled)
					{
						this.m_Item[panelObjectIdx].column[num2].text.enabled = true;
					}
				}
				else
				{
					if (this.m_Item[panelObjectIdx].column[num2].image.enabled)
					{
						this.m_Item[panelObjectIdx].column[num2].image.enabled = false;
					}
					if (this.m_Item[panelObjectIdx].column[num2].text.enabled)
					{
						this.m_Item[panelObjectIdx].column[num2].text.enabled = false;
					}
				}
				vector = this.m_Item[panelObjectIdx].column[num2].imageRect.sizeDelta;
				vector.x = this.m_ItemInfo[dataIdx].m_Column[num2].ColumnWidth;
				this.m_Item[panelObjectIdx].column[num2].imageRect.sizeDelta = vector;
				if (this.m_ItemInfo[dataIdx].m_Column[0].m_Value != (long)this.m_NowLv_Extea)
				{
					if (dataIdx % 2 == 0)
					{
						if (this.m_ItemInfo[dataIdx].m_Column[num2].bFisetColumn)
						{
							this.m_Item[panelObjectIdx].column[num2].image.sprite = this.m_SpritesArray.GetSprite(4);
						}
						else if (this.m_ItemInfo[dataIdx].m_Column[num2].bLastColumn)
						{
							this.m_Item[panelObjectIdx].column[num2].image.sprite = this.m_SpritesArray.GetSprite(5);
						}
						else
						{
							this.m_Item[panelObjectIdx].column[num2].image.sprite = this.m_SpritesArray.GetSprite(3);
						}
					}
					else if (this.m_ItemInfo[dataIdx].m_Column[num2].bFisetColumn)
					{
						this.m_Item[panelObjectIdx].column[num2].image.sprite = this.m_SpritesArray.GetSprite(7);
					}
					else if (this.m_ItemInfo[dataIdx].m_Column[num2].bLastColumn)
					{
						this.m_Item[panelObjectIdx].column[num2].image.sprite = this.m_SpritesArray.GetSprite(8);
					}
					else
					{
						this.m_Item[panelObjectIdx].column[num2].image.sprite = this.m_SpritesArray.GetSprite(6);
					}
				}
				else if (this.m_ItemInfo[dataIdx].m_Column[num2].bFisetColumn)
				{
					this.m_Item[panelObjectIdx].column[num2].image.sprite = this.m_SpritesArray.GetSprite(10);
				}
				else if (this.m_ItemInfo[dataIdx].m_Column[num2].bLastColumn)
				{
					this.m_Item[panelObjectIdx].column[num2].image.sprite = this.m_SpritesArray.GetSprite(11);
				}
				else
				{
					this.m_Item[panelObjectIdx].column[num2].image.sprite = this.m_SpritesArray.GetSprite(9);
				}
				this.m_Item[panelObjectIdx].column[num2].text.UpdateArabicPos();
			}
		}
		else if (type == 6)
		{
			float num = 0f;
			for (int num3 = 0; num3 < 6; num3++)
			{
				if (num3 < this.m_ItemInfo[dataIdx].m_ColumNum + 1)
				{
					Transform child = item.transform.GetChild(num3);
					this.m_Item[panelObjectIdx].column[num3].rect.anchoredPosition = new Vector2(num, 0f);
					num += this.m_ItemInfo[dataIdx].m_Column[num3].ColumnWidth;
					Vector2 vector = this.m_Item[panelObjectIdx].column[num3].rect.sizeDelta;
					vector.x = this.m_ItemInfo[dataIdx].m_Column[num3].ColumnWidth;
					this.m_Item[panelObjectIdx].column[num3].rect.sizeDelta = vector;
					if (!this.m_Item[panelObjectIdx].column[num3].image.enabled)
					{
						this.m_Item[panelObjectIdx].column[num3].image.enabled = true;
					}
					if (!this.m_Item[panelObjectIdx].column[num3].text.enabled)
					{
						this.m_Item[panelObjectIdx].column[num3].text.enabled = true;
					}
					vector = this.m_Item[panelObjectIdx].column[num3].rect.sizeDelta;
					vector.x = this.m_ItemInfo[dataIdx].m_Column[num3].ColumnWidth;
					this.m_Item[panelObjectIdx].column[num3].rect.sizeDelta = vector;
					this.m_Item[panelObjectIdx].column[num3].imageRect.sizeDelta = vector;
					if (this.m_ItemInfo[dataIdx].m_Column[0].m_Value != (long)this.m_NowLv)
					{
						if (dataIdx % 2 == 0)
						{
							if (this.m_ItemInfo[dataIdx].m_Column[num3].bFisetColumn)
							{
								this.m_Item[panelObjectIdx].column[num3].image.sprite = this.m_SpritesArray.GetSprite(4);
							}
							else if (this.m_ItemInfo[dataIdx].m_Column[num3].bLastColumn)
							{
								this.m_Item[panelObjectIdx].column[num3].image.sprite = this.m_SpritesArray.GetSprite(5);
							}
							else
							{
								this.m_Item[panelObjectIdx].column[num3].image.sprite = this.m_SpritesArray.GetSprite(3);
							}
						}
						else if (this.m_ItemInfo[dataIdx].m_Column[num3].bFisetColumn)
						{
							this.m_Item[panelObjectIdx].column[num3].image.sprite = this.m_SpritesArray.GetSprite(7);
						}
						else if (this.m_ItemInfo[dataIdx].m_Column[num3].bLastColumn)
						{
							this.m_Item[panelObjectIdx].column[num3].image.sprite = this.m_SpritesArray.GetSprite(8);
						}
						else
						{
							this.m_Item[panelObjectIdx].column[num3].image.sprite = this.m_SpritesArray.GetSprite(6);
						}
					}
					else if (this.m_ItemInfo[dataIdx].m_Column[num3].bFisetColumn)
					{
						this.m_Item[panelObjectIdx].column[num3].image.sprite = this.m_SpritesArray.GetSprite(10);
					}
					else if (this.m_ItemInfo[dataIdx].m_Column[num3].bLastColumn)
					{
						this.m_Item[panelObjectIdx].column[num3].image.sprite = this.m_SpritesArray.GetSprite(11);
					}
					else
					{
						this.m_Item[panelObjectIdx].column[num3].image.sprite = this.m_SpritesArray.GetSprite(9);
					}
					this.m_Item[panelObjectIdx].column[num3].text.font = this.TTF;
					this.m_Item[panelObjectIdx].column[num3].text.fontSize = 18;
					this.m_Item[panelObjectIdx].column[num3].text.resizeTextMaxSize = 18;
					this.m_Item[panelObjectIdx].column[num3].text.resizeTextForBestFit = true;
					vector = this.m_Item[panelObjectIdx].column[num3].text.rectTransform.sizeDelta;
					vector.x = this.m_ItemInfo[dataIdx].m_Column[num3].ColumnWidth;
					this.m_Item[panelObjectIdx].column[num3].text.rectTransform.sizeDelta = vector;
					this.m_Item[panelObjectIdx].column[num3].text.UpdateArabicPos();
					this.m_ItemInfo[dataIdx].m_Column[num3].m_Str.ClearString();
					if (num3 == 0)
					{
						if (this.m_ItemInfo[dataIdx].m_Column[num3].m_EffID == (uint)this.m_ItemInfo[dataIdx].m_Column[num3].m_Value)
						{
							this.m_ItemInfo[dataIdx].m_Column[num3].m_Str.IntToFormat((long)((ulong)this.m_ItemInfo[dataIdx].m_Column[num3].m_EffID), 1, false);
							this.m_ItemInfo[dataIdx].m_Column[num3].m_Str.AppendFormat("{0}");
						}
						else
						{
							this.m_ItemInfo[dataIdx].m_Column[num3].m_Str.IntToFormat((long)((ulong)this.m_ItemInfo[dataIdx].m_Column[num3].m_EffID), 1, false);
							this.m_ItemInfo[dataIdx].m_Column[num3].m_Str.IntToFormat((long)((ulong)((uint)this.m_ItemInfo[dataIdx].m_Column[num3].m_Value)), 1, false);
							this.m_ItemInfo[dataIdx].m_Column[num3].m_Str.AppendFormat(this.DM.mStringTable.GetStringByID(5900u));
						}
					}
					else
					{
						this.m_ItemInfo[dataIdx].m_Column[num3].m_Str.IntToFormat((long)((ulong)this.m_ItemInfo[dataIdx].m_Column[num3].m_EffID), 1, false);
						this.m_ItemInfo[dataIdx].m_Column[num3].m_Str.AppendFormat(this.DM.mStringTable.GetStringByID(5901u));
					}
					this.m_Item[panelObjectIdx].column[num3].text.text = this.m_ItemInfo[dataIdx].m_Column[num3].m_Str.ToString();
					this.m_Item[panelObjectIdx].column[num3].text.alignment = TextAnchor.MiddleCenter;
					this.m_Item[panelObjectIdx].column[num3].textShadow.enabled = false;
				}
				else
				{
					if (this.m_Item[panelObjectIdx].column[num3].image.enabled)
					{
						this.m_Item[panelObjectIdx].column[num3].image.enabled = false;
					}
					if (this.m_Item[panelObjectIdx].column[num3].text.enabled)
					{
						this.m_Item[panelObjectIdx].column[num3].text.enabled = false;
					}
					if (this.m_Item[panelObjectIdx].column[num3].textShadow)
					{
						this.m_Item[panelObjectIdx].column[num3].textShadow.enabled = false;
					}
				}
				this.m_Item[panelObjectIdx].column[num3].text.UpdateArabicPos();
			}
		}
	}

	// Token: 0x06001D0E RID: 7438 RVA: 0x00342770 File Offset: 0x00340970
	public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
	{
	}

	// Token: 0x06001D0F RID: 7439 RVA: 0x00342774 File Offset: 0x00340974
	public float CalculateTextHeight(ushort meffectId, float width, UIText context)
	{
		int num = 18;
		context.fontSize = num;
		context.font = this.TTF;
		context.resizeTextForBestFit = true;
		context.resizeTextMaxSize = num;
		context.resizeTextMinSize = 10;
		context.rectTransform.sizeDelta = new Vector2(width, 40f);
		Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(meffectId);
		context.text = DataManager.Instance.mStringTable.GetStringByID((uint)recordByKey.InfoID);
		context.SetAllDirty();
		context.cachedTextGeneratorForLayout.Invalidate();
		return Mathf.Clamp(context.preferredHeight + 2f, 40f, context.preferredHeight + 2f);
	}

	// Token: 0x040058AA RID: 22698
	private const int MaxPanelObject = 15;

	// Token: 0x040058AB RID: 22699
	private const int MaxColum = 6;

	// Token: 0x040058AC RID: 22700
	private const int MaxJailExtra = 9;

	// Token: 0x040058AD RID: 22701
	private int MaxBuildLevel = 25;

	// Token: 0x040058AE RID: 22702
	private int MaxTechLevel = 10;

	// Token: 0x040058AF RID: 22703
	private int MaxTalentLevel = 25;

	// Token: 0x040058B0 RID: 22704
	private UISpritesArray m_SpritesArray;

	// Token: 0x040058B1 RID: 22705
	private ScrollPanel m_ScrollPanel;

	// Token: 0x040058B2 RID: 22706
	private UIText m_TitleText;

	// Token: 0x040058B3 RID: 22707
	private List<InfoItem> m_ItemInfo;

	// Token: 0x040058B4 RID: 22708
	private PanelColumItem[] m_Item;

	// Token: 0x040058B5 RID: 22709
	private ushort m_ManorID;

	// Token: 0x040058B6 RID: 22710
	private ushort m_BuildID;

	// Token: 0x040058B7 RID: 22711
	private ushort m_TechID;

	// Token: 0x040058B8 RID: 22712
	private ushort m_TalentID;

	// Token: 0x040058B9 RID: 22713
	private byte m_NowLv;

	// Token: 0x040058BA RID: 22714
	private byte m_NowLv_Extea;

	// Token: 0x040058BB RID: 22715
	private float m_ScrollWidth = 800f;

	// Token: 0x040058BC RID: 22716
	private Font TTF;

	// Token: 0x040058BD RID: 22717
	private DataManager DM;

	// Token: 0x040058BE RID: 22718
	private int[] ExtraDataLvMin = new int[]
	{
		1,
		25,
		30,
		35,
		40,
		45,
		50,
		55,
		60
	};

	// Token: 0x040058BF RID: 22719
	private int[] ExtraDataLvMax = new int[]
	{
		24,
		29,
		34,
		39,
		44,
		49,
		54,
		59,
		60
	};

	// Token: 0x040058C0 RID: 22720
	private int[] AttackBonus = new int[]
	{
		1,
		2,
		3,
		5,
		8,
		12,
		17,
		23,
		30
	};

	// Token: 0x040058C1 RID: 22721
	private UIText context;
}
