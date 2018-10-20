using System;
using System.Collections.Generic;

// Token: 0x020007AF RID: 1967
public class ItemCrafeComparer : IComparer<ItemCraftDataType>
{
	// Token: 0x06002854 RID: 10324 RVA: 0x004465E8 File Offset: 0x004447E8
	public int Compare(ItemCraftDataType x, ItemCraftDataType y)
	{
		PetManager instance = PetManager.Instance;
		DataManager instance2 = DataManager.Instance;
		Equip recordByKey = instance2.EquipTable.GetRecordByKey(x.ItemID);
		Equip recordByKey2 = instance2.EquipTable.GetRecordByKey(y.ItemID);
		bool flag = false;
		if (recordByKey.EquipKind == 30)
		{
			if (recordByKey2.EquipKind != 30)
			{
				return -1;
			}
			flag = true;
		}
		else if (recordByKey.EquipKind != 30)
		{
			if (recordByKey2.EquipKind == 30)
			{
				return 1;
			}
			if (recordByKey.EquipKind == 29)
			{
				if (recordByKey2.EquipKind != 29)
				{
					return -1;
				}
				PetData petData = instance.FindPetData(instance2.EquipTable.GetRecordByKey(x.ItemID).SyntheticParts[0].SyntheticItem);
				PetData petData2 = instance.FindPetData(instance2.EquipTable.GetRecordByKey(y.ItemID).SyntheticParts[0].SyntheticItem);
				if (petData != null)
				{
					if (petData2 != null)
					{
						if (petData.Enhance == 2)
						{
							if (petData2.Enhance != 2)
							{
								return 1;
							}
							flag = true;
						}
						else
						{
							if (petData2.Enhance == 2)
							{
								return -1;
							}
							flag = true;
						}
					}
					else
					{
						if (petData.Enhance == 2)
						{
							return 1;
						}
						flag = true;
					}
				}
				else if (petData2 != null)
				{
					if (petData2.Enhance == 2)
					{
						return -1;
					}
					flag = true;
				}
				else
				{
					flag = true;
				}
			}
			else
			{
				if (recordByKey2.EquipKind == 29)
				{
					return 1;
				}
				flag = true;
			}
		}
		if (!flag)
		{
			return 0;
		}
		if (x.mNo < y.mNo)
		{
			return -1;
		}
		return 1;
	}
}
