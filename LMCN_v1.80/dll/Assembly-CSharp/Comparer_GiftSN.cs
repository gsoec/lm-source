using System;
using System.Collections.Generic;

// Token: 0x02000186 RID: 390
public class Comparer_GiftSN : IComparer<AllianceBoxDataType>
{
	// Token: 0x0600059E RID: 1438 RVA: 0x00078A84 File Offset: 0x00076C84
	public int Compare(AllianceBoxDataType x, AllianceBoxDataType y)
	{
		if (x.SN < y.SN)
		{
			return -1;
		}
		return 1;
	}
}
