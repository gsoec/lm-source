using System;
using System.Runtime.InteropServices;

// Token: 0x0200045E RID: 1118
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PSBuffInfoData
{
	// Token: 0x06001685 RID: 5765 RVA: 0x0026BE18 File Offset: 0x0026A018
	public void Clear()
	{
		this.SkillID = 0;
	}

	// Token: 0x040043BC RID: 17340
	public ushort SkillID;

	// Token: 0x040043BD RID: 17341
	public byte Level;

	// Token: 0x040043BE RID: 17342
	public long BeginTime;

	// Token: 0x040043BF RID: 17343
	public uint RequireTime;
}
