using System;
using System.Runtime.InteropServices;

// Token: 0x020004AB RID: 1195
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Level
{
	// Token: 0x04004759 RID: 18265
	[MarshalAs(UnmanagedType.U2)]
	public ushort LevelKey;

	// Token: 0x0400475A RID: 18266
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public ushort[] Team;

	// Token: 0x0400475B RID: 18267
	[MarshalAs(UnmanagedType.U2)]
	public ushort TreasureNo;

	// Token: 0x0400475C RID: 18268
	[MarshalAs(UnmanagedType.U2)]
	public ushort LevelInfoNo;

	// Token: 0x0400475D RID: 18269
	[MarshalAs(UnmanagedType.U2)]
	public ushort LeadLV;

	// Token: 0x0400475E RID: 18270
	[MarshalAs(UnmanagedType.U2)]
	public ushort Money;

	// Token: 0x0400475F RID: 18271
	[MarshalAs(UnmanagedType.U2)]
	public ushort TalkBefore;

	// Token: 0x04004760 RID: 18272
	[MarshalAs(UnmanagedType.U2)]
	public ushort TalkAfter;
}
