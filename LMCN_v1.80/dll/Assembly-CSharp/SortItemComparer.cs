using System;
using System.Collections.Generic;

// Token: 0x0200055B RID: 1371
public class SortItemComparer : IComparer<ushort>
{
	// Token: 0x06001B66 RID: 7014 RVA: 0x003094CC File Offset: 0x003076CC
	public int Compare(ushort x, ushort y)
	{
		DataManager instance = DataManager.Instance;
		Equip equip;
		Equip equip2;
		if (this.SortType == 0)
		{
			equip = instance.EquipTable.GetRecordByIndex((int)x);
			equip2 = instance.EquipTable.GetRecordByIndex((int)y);
		}
		else
		{
			equip = instance.EquipTable.GetRecordByKey(x);
			equip2 = instance.EquipTable.GetRecordByKey(y);
		}
		bool flag = true;
		bool flag2 = true;
		byte b = 0;
		byte b2 = 0;
		if (this.SortLv == 0)
		{
			if (equip.NeedLv <= instance.RoleAttr.Level)
			{
				if (equip2.NeedLv <= instance.RoleAttr.Level)
				{
					for (int i = 0; i < 4; i++)
					{
						instance.mLordEquip.GetMaterialEnough(ref b, ref b2, 0, i, equip2);
					}
					if (b2 < b)
					{
						flag2 = false;
					}
				}
				else if (equip2.NeedLv > instance.RoleAttr.Level)
				{
					flag2 = false;
				}
				b = 0;
				b2 = 0;
				for (int j = 0; j < 4; j++)
				{
					instance.mLordEquip.GetMaterialEnough(ref b, ref b2, 0, j, equip);
				}
				if (b2 < b)
				{
					flag = false;
				}
			}
			else if (equip.NeedLv > instance.RoleAttr.Level)
			{
				flag = false;
				if (equip2.NeedLv <= instance.RoleAttr.Level)
				{
					for (int k = 0; k < 4; k++)
					{
						instance.mLordEquip.GetMaterialEnough(ref b, ref b2, 0, k, equip2);
					}
					if (b2 < b)
					{
						flag2 = false;
					}
				}
				else if (equip2.NeedLv > instance.RoleAttr.Level)
				{
					flag2 = false;
				}
			}
			if (flag)
			{
				if (!flag2)
				{
					return -1;
				}
				if (equip2.NeedLv > equip.NeedLv)
				{
					return 1;
				}
				if (equip2.NeedLv == equip.NeedLv)
				{
					return this.CheckKindLv(equip, equip2);
				}
				return -1;
			}
			else
			{
				if (flag2)
				{
					return 1;
				}
				if (equip.NeedLv > equip2.NeedLv)
				{
					return 1;
				}
				if (equip.NeedLv == equip2.NeedLv)
				{
					return this.CheckKindLv(equip, equip2);
				}
				return -1;
			}
		}
		else
		{
			if (equip.NeedLv > equip2.NeedLv)
			{
				return 1;
			}
			if (equip.NeedLv == equip2.NeedLv)
			{
				return this.CheckKindLv(equip, equip2);
			}
			return -1;
		}
	}

	// Token: 0x06001B67 RID: 7015 RVA: 0x00309730 File Offset: 0x00307930
	public int CheckKindLv(Equip tmpEquip1, Equip tmpEquip2)
	{
		int result = -1;
		int num = this.CheckKind(tmpEquip1.EquipKind);
		int num2 = this.CheckKind(tmpEquip2.EquipKind);
		if (tmpEquip1.NeedLv == tmpEquip2.NeedLv)
		{
			if (num < num2)
			{
				result = 1;
			}
			else if (num == num2 && tmpEquip1.EquipKey >= tmpEquip2.EquipKey)
			{
				result = 1;
			}
			else
			{
				result = -1;
			}
		}
		return result;
	}

	// Token: 0x06001B68 RID: 7016 RVA: 0x003097A0 File Offset: 0x003079A0
	public int CheckKind(byte EquipKind)
	{
		int result = 0;
		switch (EquipKind)
		{
		case 21:
			result = 3;
			break;
		case 22:
			result = 2;
			break;
		case 23:
			result = 1;
			break;
		case 24:
			result = 5;
			break;
		case 25:
			result = 4;
			break;
		case 26:
			result = 0;
			break;
		}
		return result;
	}

	// Token: 0x040052E3 RID: 21219
	public byte SortType;

	// Token: 0x040052E4 RID: 21220
	public byte SortColor;

	// Token: 0x040052E5 RID: 21221
	public byte SortLv;
}
