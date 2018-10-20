using System;
using System.Collections.Generic;

// Token: 0x0200017C RID: 380
public class ItemDataComparer : IComparer<ushort>
{
	// Token: 0x06000584 RID: 1412 RVA: 0x00077360 File Offset: 0x00075560
	public int Compare(ushort x, ushort y)
	{
		if (x == y)
		{
			return 0;
		}
		Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(x);
		Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(y);
		if (DataManager.Instance.GetCurItemQuantity(x, 0) == 0)
		{
			return 1;
		}
		if (recordByKey.EquipKey != x)
		{
			return (recordByKey2.EquipKey != y) ? 1 : -1;
		}
		if (recordByKey2.EquipKey != y)
		{
			return -1;
		}
		byte b = recordByKey.EquipKind;
		byte b2 = recordByKey2.EquipKind;
		if (b == 0)
		{
			b = 30;
		}
		else if (b <= 5)
		{
			b += 1;
		}
		else if (b <= 30)
		{
			b -= 6;
		}
		if (b2 == 0)
		{
			b2 = 30;
		}
		else if (b2 <= 5)
		{
			b2 += 1;
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
		if (recordByKey.PropertiesInfo[0].Propertieskey < recordByKey2.PropertiesInfo[0].Propertieskey)
		{
			return -1;
		}
		if (recordByKey.PropertiesInfo[0].Propertieskey > recordByKey2.PropertiesInfo[0].Propertieskey)
		{
			return 1;
		}
		if (b == 6 || b == 7)
		{
			if (recordByKey.PropertiesInfo[0].PropertiesValue < recordByKey2.PropertiesInfo[0].PropertiesValue)
			{
				return -1;
			}
			if (recordByKey.PropertiesInfo[0].PropertiesValue > recordByKey2.PropertiesInfo[0].PropertiesValue)
			{
				return 1;
			}
		}
		if (recordByKey.Color < recordByKey2.Color)
		{
			return -1;
		}
		if (recordByKey.Color > recordByKey2.Color)
		{
			return 1;
		}
		if (recordByKey.NeedLv < recordByKey2.NeedLv)
		{
			return -1;
		}
		if (recordByKey.NeedLv > recordByKey2.NeedLv)
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
		return 0;
	}
}
