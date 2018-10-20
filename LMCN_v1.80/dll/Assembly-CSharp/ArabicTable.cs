using System;

// Token: 0x0200002C RID: 44
internal class ArabicTable
{
	// Token: 0x0600013D RID: 317 RVA: 0x00014B54 File Offset: 0x00012D54
	private ArabicTable()
	{
		ArabicTable.mapList = new ArabicMapping[40];
		ArabicTable.mapList[0] = new ArabicMapping(1569, 65152);
		ArabicTable.mapList[1] = new ArabicMapping(1570, 65153);
		ArabicTable.mapList[2] = new ArabicMapping(1571, 65155);
		ArabicTable.mapList[3] = new ArabicMapping(1572, 65157);
		ArabicTable.mapList[4] = new ArabicMapping(1573, 65159);
		ArabicTable.mapList[5] = new ArabicMapping(1574, 65161);
		ArabicTable.mapList[6] = new ArabicMapping(1575, 65165);
		ArabicTable.mapList[7] = new ArabicMapping(1576, 65167);
		ArabicTable.mapList[8] = new ArabicMapping(1577, 65171);
		ArabicTable.mapList[9] = new ArabicMapping(1578, 65173);
		ArabicTable.mapList[10] = new ArabicMapping(1579, 65177);
		ArabicTable.mapList[11] = new ArabicMapping(1580, 65181);
		ArabicTable.mapList[12] = new ArabicMapping(1581, 65185);
		ArabicTable.mapList[13] = new ArabicMapping(1582, 65189);
		ArabicTable.mapList[14] = new ArabicMapping(1583, 65193);
		ArabicTable.mapList[15] = new ArabicMapping(1584, 65195);
		ArabicTable.mapList[16] = new ArabicMapping(1585, 65197);
		ArabicTable.mapList[17] = new ArabicMapping(1586, 65199);
		ArabicTable.mapList[18] = new ArabicMapping(1587, 65201);
		ArabicTable.mapList[19] = new ArabicMapping(1588, 65205);
		ArabicTable.mapList[20] = new ArabicMapping(1589, 65209);
		ArabicTable.mapList[21] = new ArabicMapping(1590, 65213);
		ArabicTable.mapList[22] = new ArabicMapping(1591, 65217);
		ArabicTable.mapList[23] = new ArabicMapping(1592, 65221);
		ArabicTable.mapList[24] = new ArabicMapping(1593, 65225);
		ArabicTable.mapList[25] = new ArabicMapping(1594, 65229);
		ArabicTable.mapList[26] = new ArabicMapping(1601, 65233);
		ArabicTable.mapList[27] = new ArabicMapping(1602, 65237);
		ArabicTable.mapList[28] = new ArabicMapping(1603, 65241);
		ArabicTable.mapList[29] = new ArabicMapping(1604, 65245);
		ArabicTable.mapList[30] = new ArabicMapping(1605, 65249);
		ArabicTable.mapList[31] = new ArabicMapping(1606, 65253);
		ArabicTable.mapList[32] = new ArabicMapping(1607, 65257);
		ArabicTable.mapList[33] = new ArabicMapping(1608, 65261);
		ArabicTable.mapList[34] = new ArabicMapping(1609, 65263);
		ArabicTable.mapList[35] = new ArabicMapping(1610, 65265);
		ArabicTable.mapList[36] = new ArabicMapping(1662, 64342);
		ArabicTable.mapList[37] = new ArabicMapping(1688, 64394);
		ArabicTable.mapList[38] = new ArabicMapping(1670, 64378);
		ArabicTable.mapList[39] = new ArabicMapping(1711, 64402);
	}

	// Token: 0x17000009 RID: 9
	// (get) Token: 0x0600013E RID: 318 RVA: 0x00014F04 File Offset: 0x00013104
	internal static ArabicTable ArabicMapper
	{
		get
		{
			if (ArabicTable.arabicMapper == null)
			{
				ArabicTable.arabicMapper = new ArabicTable();
			}
			return ArabicTable.arabicMapper;
		}
	}

	// Token: 0x0600013F RID: 319 RVA: 0x00014F20 File Offset: 0x00013120
	internal int Convert(int toBeConverted)
	{
		if (toBeConverted >= 1569 && toBeConverted <= 1594)
		{
			return ArabicTable.mapList[toBeConverted - 1569].to;
		}
		if (toBeConverted >= 1601 && toBeConverted <= 1610)
		{
			return ArabicTable.mapList[26 + toBeConverted - 1601].to;
		}
		for (int i = 36; i < ArabicTable.mapList.Length; i++)
		{
			if (ArabicTable.mapList[i].from == toBeConverted)
			{
				return ArabicTable.mapList[i].to;
			}
		}
		return toBeConverted;
	}

	// Token: 0x0400026D RID: 621
	private static ArabicMapping[] mapList;

	// Token: 0x0400026E RID: 622
	private static ArabicTable arabicMapper;
}
