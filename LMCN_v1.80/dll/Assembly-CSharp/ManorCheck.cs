using System;
using System.Collections.Generic;

// Token: 0x020003E5 RID: 997
public struct ManorCheck
{
	// Token: 0x06001467 RID: 5223 RVA: 0x0023A650 File Offset: 0x00238850
	public void Reset()
	{
		this.CheckIndex = 0;
		this.CondiVal = 0;
		this.CondPriority = 0;
	}

	// Token: 0x04003D82 RID: 15746
	public List<ushort> Priority;

	// Token: 0x04003D83 RID: 15747
	public List<ushort> LvCondi;

	// Token: 0x04003D84 RID: 15748
	public int CheckIndex;

	// Token: 0x04003D85 RID: 15749
	public int CondiVal;

	// Token: 0x04003D86 RID: 15750
	public int CondPriority;
}
