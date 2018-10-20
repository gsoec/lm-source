using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// Token: 0x020000D9 RID: 217
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class SubContent
{
	// Token: 0x040009E1 RID: 2529
	public Dictionary<string, List<uint>> Mail = new Dictionary<string, List<uint>>();
}
