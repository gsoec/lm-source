using System;
using System.Collections.Generic;

// Token: 0x020007AC RID: 1964
public class PetDataComparer : IComparer<byte>
{
	// Token: 0x06002849 RID: 10313 RVA: 0x004462DC File Offset: 0x004444DC
	public int Compare(byte x, byte y)
	{
		PetData petData = PetManager.Instance.GetPetData((int)x);
		PetData petData2 = PetManager.Instance.GetPetData((int)y);
		if (petData != null && petData2 == null)
		{
			return -1;
		}
		if (petData == null && petData2 != null)
		{
			return 1;
		}
		if (petData == null && petData2 == null)
		{
			return 0;
		}
		if (petData.Enhance > petData2.Enhance)
		{
			return -1;
		}
		if (petData.Enhance < petData2.Enhance)
		{
			return 1;
		}
		if (petData.Level > petData2.Level)
		{
			return -1;
		}
		if (petData.Level < petData2.Level)
		{
			return 1;
		}
		if (petData.Rare > petData2.Rare)
		{
			return -1;
		}
		if (petData.Rare < petData2.Rare)
		{
			return 1;
		}
		if (petData.ID > petData2.ID)
		{
			return -1;
		}
		if (petData.ID < petData2.ID)
		{
			return 1;
		}
		return 0;
	}
}
