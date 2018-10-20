using System;
using System.Runtime.InteropServices;

// Token: 0x0200045D RID: 1117
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PSCoolDownData
{
	// Token: 0x06001684 RID: 5764 RVA: 0x0026BE0C File Offset: 0x0026A00C
	public void Clear()
	{
		this.SkillID = 0;
	}

	// Token: 0x040043BA RID: 17338
	public ushort SkillID;

	// Token: 0x040043BB RID: 17339
	public long EndTime;
}
