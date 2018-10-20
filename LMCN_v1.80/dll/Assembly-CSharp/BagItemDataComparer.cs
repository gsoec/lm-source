using System;
using System.Collections.Generic;

// Token: 0x0200017F RID: 383
public class BagItemDataComparer : IComparer<ushort>
{
	// Token: 0x0600058B RID: 1419 RVA: 0x00077810 File Offset: 0x00075A10
	public int Compare(ushort x, ushort y)
	{
		if (this.SortType == 0)
		{
			return this.BagCompare(x, y);
		}
		if (this.SortType == 1)
		{
			return this.ShopCompare(x, y);
		}
		if (this.SortType == 2)
		{
			return this.ShopResourceCompare(x, y);
		}
		if (this.SortType == 3)
		{
			return this.BagResourceCompare(x, y);
		}
		return this.PetBagCompare(x, y);
	}

	// Token: 0x0600058C RID: 1420 RVA: 0x00077878 File Offset: 0x00075A78
	public int BagCompare(ushort x, ushort y)
	{
		if (x == y)
		{
			return 0;
		}
		if (x == 0)
		{
			return 1;
		}
		if (y == 0)
		{
			return -1;
		}
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(x);
		Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(y);
		if (recordByKey.EquipKey != x)
		{
			return (recordByKey2.EquipKey != y) ? 1 : -1;
		}
		if (recordByKey2.EquipKey != y)
		{
			return -1;
		}
		if (recordByKey.EquipKey != x)
		{
			return (recordByKey2.EquipKey != y) ? 1 : -1;
		}
		if (recordByKey2.EquipKey != y)
		{
			return -1;
		}
		byte equipKind = recordByKey.EquipKind;
		byte equipKind2 = recordByKey2.EquipKind;
		if (equipKind < equipKind2)
		{
			return -1;
		}
		if (equipKind > equipKind2)
		{
			return 1;
		}
		if (recordByKey.PropertiesInfo[0].Propertieskey < recordByKey2.PropertiesInfo[0].Propertieskey)
		{
			return -1;
		}
		if (recordByKey.PropertiesInfo[0].Propertieskey > recordByKey2.PropertiesInfo[0].Propertieskey)
		{
			return 1;
		}
		switch (equipKind)
		{
		case 6:
			if (recordByKey.PropertiesInfo[0].PropertiesValue < recordByKey2.PropertiesInfo[0].PropertiesValue)
			{
				return -1;
			}
			if (recordByKey.PropertiesInfo[0].PropertiesValue > recordByKey2.PropertiesInfo[0].PropertiesValue)
			{
				return 1;
			}
			break;
		case 10:
		{
			ushort propertieskey = recordByKey.PropertiesInfo[0].Propertieskey;
			ushort propertieskey2 = recordByKey2.PropertiesInfo[0].Propertieskey;
			if (propertieskey > propertieskey2)
			{
				return 1;
			}
			if (propertieskey < propertieskey2)
			{
				return -1;
			}
			if (propertieskey == 30 || propertieskey == 33 || propertieskey == 40)
			{
				if (recordByKey.PropertiesInfo[1].PropertiesValue * recordByKey.PropertiesInfo[1].Propertieskey < recordByKey2.PropertiesInfo[1].PropertiesValue * recordByKey2.PropertiesInfo[1].Propertieskey)
				{
					return -1;
				}
				if (recordByKey.PropertiesInfo[1].PropertiesValue * recordByKey.PropertiesInfo[1].Propertieskey > recordByKey2.PropertiesInfo[1].PropertiesValue * recordByKey2.PropertiesInfo[1].Propertieskey)
				{
					return 1;
				}
			}
			if (x < y)
			{
				return -1;
			}
			if (x > y)
			{
				return 1;
			}
			break;
		}
		case 11:
			if (recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue < recordByKey2.PropertiesInfo[1].Propertieskey * recordByKey2.PropertiesInfo[1].PropertiesValue)
			{
				return -1;
			}
			if (recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue > recordByKey2.PropertiesInfo[1].Propertieskey * recordByKey2.PropertiesInfo[1].PropertiesValue)
			{
				return 1;
			}
			break;
		case 12:
		case 15:
		case 16:
			if (recordByKey.PropertiesInfo[1].Propertieskey < recordByKey2.PropertiesInfo[1].Propertieskey)
			{
				return -1;
			}
			if (recordByKey.PropertiesInfo[1].Propertieskey > recordByKey2.PropertiesInfo[1].Propertieskey)
			{
				return 1;
			}
			if (recordByKey.PropertiesInfo[1].PropertiesValue < recordByKey2.PropertiesInfo[1].PropertiesValue)
			{
				return -1;
			}
			if (recordByKey.PropertiesInfo[1].PropertiesValue > recordByKey2.PropertiesInfo[1].PropertiesValue)
			{
				return 1;
			}
			break;
		case 13:
		case 14:
		case 19:
			if (recordByKey.PropertiesInfo[1].Propertieskey < recordByKey2.PropertiesInfo[1].Propertieskey)
			{
				return -1;
			}
			if (recordByKey.PropertiesInfo[1].Propertieskey > recordByKey2.PropertiesInfo[1].Propertieskey)
			{
				return 1;
			}
			if (x < y)
			{
				return -1;
			}
			if (x > y)
			{
				return 1;
			}
			break;
		case 18:
			if (recordByKey.PropertiesInfo[2].Propertieskey < recordByKey2.PropertiesInfo[2].Propertieskey)
			{
				return -1;
			}
			if (recordByKey.PropertiesInfo[2].Propertieskey > recordByKey2.PropertiesInfo[2].Propertieskey)
			{
				return 1;
			}
			if (recordByKey.Color < recordByKey2.Color)
			{
				return -1;
			}
			if (recordByKey.Color > recordByKey2.Color)
			{
				return 1;
			}
			if (x < y)
			{
				return -1;
			}
			if (x > y)
			{
				return 1;
			}
			break;
		}
		return 0;
	}

	// Token: 0x0600058D RID: 1421 RVA: 0x00077DB0 File Offset: 0x00075FB0
	public int ShopCompare(ushort x, ushort y)
	{
		if (x == y)
		{
			return 0;
		}
		StoreTbl recordByKey = DataManager.Instance.StoreData.GetRecordByKey(x);
		StoreTbl recordByKey2 = DataManager.Instance.StoreData.GetRecordByKey(y);
		Equip recordByKey3 = DataManager.Instance.EquipTable.GetRecordByKey(recordByKey.ItemID);
		Equip recordByKey4 = DataManager.Instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
		if (recordByKey3.EquipKind < recordByKey4.EquipKind)
		{
			return -1;
		}
		if (recordByKey3.EquipKind > recordByKey4.EquipKind)
		{
			return 1;
		}
		if (recordByKey.ID < recordByKey2.ID)
		{
			return -1;
		}
		if (recordByKey.ID > recordByKey2.ID)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x0600058E RID: 1422 RVA: 0x00077E6C File Offset: 0x0007606C
	public int ShopResourceCompare(ushort x, ushort y)
	{
		if (x == y)
		{
			return 0;
		}
		StoreTbl recordByKey = DataManager.Instance.StoreData.GetRecordByKey(x);
		StoreTbl recordByKey2 = DataManager.Instance.StoreData.GetRecordByKey(y);
		Equip recordByKey3 = DataManager.Instance.EquipTable.GetRecordByKey(recordByKey.ItemID);
		Equip recordByKey4 = DataManager.Instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
		if (recordByKey3.EquipKind < recordByKey4.EquipKind)
		{
			return -1;
		}
		if (recordByKey3.EquipKind > recordByKey4.EquipKind)
		{
			return 1;
		}
		if (recordByKey.Num < recordByKey2.Num)
		{
			return -1;
		}
		if (recordByKey.Num > recordByKey2.Num)
		{
			return 1;
		}
		if (recordByKey3.EquipKind == 10)
		{
			bool flag = recordByKey3.PropertiesInfo[0].Propertieskey == 49;
			bool flag2 = recordByKey4.PropertiesInfo[0].Propertieskey == 49;
			if (!flag && flag2)
			{
				return 1;
			}
			if (flag && !flag2)
			{
				return -1;
			}
		}
		if (recordByKey3.PropertiesInfo[0].Propertieskey < recordByKey4.PropertiesInfo[0].Propertieskey)
		{
			return -1;
		}
		if (recordByKey3.PropertiesInfo[0].Propertieskey > recordByKey4.PropertiesInfo[0].Propertieskey)
		{
			return 1;
		}
		if (recordByKey3.EquipKind == 12)
		{
			if (recordByKey3.PropertiesInfo[1].Propertieskey < recordByKey4.PropertiesInfo[1].Propertieskey)
			{
				return -1;
			}
			if (recordByKey3.PropertiesInfo[1].Propertieskey > recordByKey4.PropertiesInfo[1].Propertieskey)
			{
				return 1;
			}
			if (recordByKey3.PropertiesInfo[1].PropertiesValue < recordByKey4.PropertiesInfo[1].PropertiesValue)
			{
				return -1;
			}
			if (recordByKey3.PropertiesInfo[1].PropertiesValue > recordByKey4.PropertiesInfo[1].PropertiesValue)
			{
				return 1;
			}
		}
		if (recordByKey3.EquipKind == 11)
		{
			if (recordByKey3.PropertiesInfo[1].Propertieskey * recordByKey3.PropertiesInfo[1].PropertiesValue < recordByKey4.PropertiesInfo[1].Propertieskey * recordByKey4.PropertiesInfo[1].PropertiesValue)
			{
				return -1;
			}
			if (recordByKey3.PropertiesInfo[1].Propertieskey * recordByKey3.PropertiesInfo[1].PropertiesValue > recordByKey4.PropertiesInfo[1].Propertieskey * recordByKey4.PropertiesInfo[1].PropertiesValue)
			{
				return 1;
			}
		}
		if (recordByKey3.EquipKind == 10)
		{
			if (recordByKey3.PropertiesInfo[1].Propertieskey * recordByKey3.PropertiesInfo[1].PropertiesValue < recordByKey4.PropertiesInfo[1].Propertieskey * recordByKey4.PropertiesInfo[1].PropertiesValue)
			{
				return -1;
			}
			if (recordByKey3.PropertiesInfo[1].Propertieskey * recordByKey3.PropertiesInfo[1].PropertiesValue > recordByKey4.PropertiesInfo[1].Propertieskey * recordByKey4.PropertiesInfo[1].PropertiesValue)
			{
				return 1;
			}
		}
		return 0;
	}

	// Token: 0x0600058F RID: 1423 RVA: 0x000781F8 File Offset: 0x000763F8
	public int BagResourceCompare(ushort x, ushort y)
	{
		if (x == y)
		{
			return 0;
		}
		if (x == 0)
		{
			return 1;
		}
		if (y == 0)
		{
			return -1;
		}
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(x);
		Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(y);
		if (recordByKey.EquipKey != x)
		{
			return (recordByKey2.EquipKey != y) ? 1 : -1;
		}
		if (recordByKey2.EquipKey != y)
		{
			return -1;
		}
		if (recordByKey.EquipKind < recordByKey2.EquipKind)
		{
			return -1;
		}
		if (recordByKey.EquipKind > recordByKey2.EquipKind)
		{
			return 1;
		}
		if (recordByKey.EquipKind == 12)
		{
			if (recordByKey.PropertiesInfo[1].Propertieskey < recordByKey2.PropertiesInfo[1].Propertieskey)
			{
				return -1;
			}
			if (recordByKey.PropertiesInfo[1].Propertieskey > recordByKey2.PropertiesInfo[1].Propertieskey)
			{
				return 1;
			}
			if (recordByKey.PropertiesInfo[0].Propertieskey == 11 || recordByKey.PropertiesInfo[0].Propertieskey == 16)
			{
				if (recordByKey.EquipKey < recordByKey2.EquipKey)
				{
					return -1;
				}
				if (recordByKey.EquipKey > recordByKey2.EquipKey)
				{
					return 1;
				}
			}
		}
		if (recordByKey.EquipKind == 6)
		{
			if (recordByKey.PropertiesInfo[0].Propertieskey < recordByKey2.PropertiesInfo[0].Propertieskey)
			{
				return -1;
			}
			if (recordByKey.PropertiesInfo[0].Propertieskey > recordByKey2.PropertiesInfo[0].Propertieskey)
			{
				return 1;
			}
			if (recordByKey.PropertiesInfo[0].PropertiesValue < recordByKey2.PropertiesInfo[0].PropertiesValue)
			{
				return -1;
			}
			if (recordByKey.PropertiesInfo[0].PropertiesValue > recordByKey2.PropertiesInfo[0].PropertiesValue)
			{
				return 1;
			}
		}
		if (recordByKey.PropertiesInfo[0].Propertieskey < recordByKey2.PropertiesInfo[0].Propertieskey)
		{
			return -1;
		}
		if (recordByKey.PropertiesInfo[0].Propertieskey > recordByKey2.PropertiesInfo[0].Propertieskey)
		{
			return 1;
		}
		if (recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue < recordByKey2.PropertiesInfo[1].Propertieskey * recordByKey2.PropertiesInfo[1].PropertiesValue)
		{
			return -1;
		}
		if (recordByKey.PropertiesInfo[1].Propertieskey * recordByKey.PropertiesInfo[1].PropertiesValue > recordByKey2.PropertiesInfo[1].Propertieskey * recordByKey2.PropertiesInfo[1].PropertiesValue)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06000590 RID: 1424 RVA: 0x00078510 File Offset: 0x00076710
	public int PetBagCompare(ushort x, ushort y)
	{
		PetItem itemData = PetManager.Instance.GetItemData((int)x);
		PetItem itemData2 = PetManager.Instance.GetItemData((int)y);
		if (itemData != null && itemData2 == null)
		{
			return -1;
		}
		if (itemData == null && itemData2 != null)
		{
			return 1;
		}
		if (itemData == null && itemData2 == null)
		{
			return 0;
		}
		byte b = itemData.EquipKind;
		byte b2 = itemData2.EquipKind;
		if (b == 0)
		{
			b = 29;
		}
		else if (b <= 30)
		{
			b -= 1;
		}
		else if (b <= 30)
		{
			b -= 6;
		}
		if (b2 == 0)
		{
			b2 = 29;
		}
		else if (b2 <= 30)
		{
			b2 -= 1;
		}
		else if (b2 <= 30)
		{
			b2 -= 6;
		}
		if (b < b2)
		{
			return -1;
		}
		if (b > b2)
		{
			return 1;
		}
		EItemType eitemType = (EItemType)b;
		if (eitemType != EItemType.EIT_Consumables)
		{
			if (eitemType != EItemType.EIT_CaseByCase)
			{
				if (eitemType != EItemType.EIT_MaterialTreasureBox)
				{
					if (eitemType == EItemType.EIT_EnhanceStone)
					{
						if (itemData.Quantity < itemData2.Quantity)
						{
							return 1;
						}
						if (itemData.Quantity > itemData2.Quantity)
						{
							return -1;
						}
					}
				}
				else
				{
					if (itemData.SyntheticParts[0].SyntheticItem < itemData2.SyntheticParts[0].SyntheticItem)
					{
						return 1;
					}
					if (itemData.SyntheticParts[0].SyntheticItem > itemData2.SyntheticParts[0].SyntheticItem)
					{
						return -1;
					}
					if (itemData.Color < itemData2.Color)
					{
						return 1;
					}
					if (itemData.Color > itemData2.Color)
					{
						return -1;
					}
					if (itemData.ItemID < itemData2.ItemID)
					{
						return 1;
					}
					if (itemData.ItemID > itemData2.ItemID)
					{
						return -1;
					}
				}
			}
			else
			{
				if (itemData.PropertiesInfo[0].Propertieskey < itemData2.PropertiesInfo[0].Propertieskey)
				{
					return -1;
				}
				if (itemData.PropertiesInfo[0].Propertieskey > itemData2.PropertiesInfo[0].Propertieskey)
				{
					return 1;
				}
				if (itemData.Color < itemData2.Color)
				{
					return -1;
				}
				if (itemData.Color > itemData2.Color)
				{
					return 1;
				}
			}
		}
		else
		{
			if (itemData.PropertiesInfo[0].PropertiesValue < itemData2.PropertiesInfo[0].PropertiesValue)
			{
				return -1;
			}
			if (itemData.PropertiesInfo[0].PropertiesValue > itemData2.PropertiesInfo[0].PropertiesValue)
			{
				return 1;
			}
		}
		if (itemData.ItemID < itemData2.ItemID)
		{
			return -1;
		}
		if (itemData.ItemID > itemData2.ItemID)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x0400111B RID: 4379
	public byte SortType;
}
