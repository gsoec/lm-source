using System;
using System.Runtime.InteropServices;

// Token: 0x020000CF RID: 207
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BattleInfo
{
	// Token: 0x04000946 RID: 2374
	public ushort RandomSeed;

	// Token: 0x04000947 RID: 2375
	public ushort RandomGap;

	// Token: 0x04000948 RID: 2376
	public byte BattleType;

	// Token: 0x04000949 RID: 2377
	public byte StageKind;

	// Token: 0x0400094A RID: 2378
	public ushort StageID;

	// Token: 0x0400094B RID: 2379
	public byte PrimarySide;
}
