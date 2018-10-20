using System;
using System.Runtime.InteropServices;

// Token: 0x02000234 RID: 564
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NPCBase
{
	// Token: 0x0400227C RID: 8828
	public CString NPCName;

	// Token: 0x0400227D RID: 8829
	public ushort NPCNum;
}
