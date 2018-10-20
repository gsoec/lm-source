using System;
using System.Collections.Generic;

// Token: 0x02000182 RID: 386
public class AllianceMemberComparer : IComparer<AllianceMemberClientDataType>
{
	// Token: 0x06000596 RID: 1430 RVA: 0x000788A8 File Offset: 0x00076AA8
	public int Compare(AllianceMemberClientDataType x, AllianceMemberClientDataType y)
	{
		if (x.Rank > y.Rank)
		{
			return -1;
		}
		if (x.Rank == y.Rank)
		{
			return string.Compare(x.Name, y.Name, true);
		}
		return 1;
	}
}
