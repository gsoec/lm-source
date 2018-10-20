using System;
using System.Runtime.InteropServices;

// Token: 0x020000D1 RID: 209
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AllianceSearch
{
	// Token: 0x0400096E RID: 2414
	public uint ID;

	// Token: 0x0400096F RID: 2415
	public string Tag;

	// Token: 0x04000970 RID: 2416
	public string Name;

	// Token: 0x04000971 RID: 2417
	public ushort Emblem;

	// Token: 0x04000972 RID: 2418
	public byte Member;

	// Token: 0x04000973 RID: 2419
	public byte Language;

	// Token: 0x04000974 RID: 2420
	public byte GiftLv;

	// Token: 0x04000975 RID: 2421
	public ulong Power;

	// Token: 0x04000976 RID: 2422
	public byte Approval;
}
