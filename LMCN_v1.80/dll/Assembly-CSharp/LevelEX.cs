using System;
using System.Runtime.InteropServices;

// Token: 0x020004AC RID: 1196
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LevelEX
{
	// Token: 0x04004761 RID: 18273
	[MarshalAs(UnmanagedType.U2)]
	public ushort LevelKey;

	// Token: 0x04004762 RID: 18274
	[MarshalAs(UnmanagedType.U1)]
	public byte LV;

	// Token: 0x04004763 RID: 18275
	[MarshalAs(UnmanagedType.U1)]
	public byte Star;

	// Token: 0x04004764 RID: 18276
	[MarshalAs(UnmanagedType.U1)]
	public byte Rank;

	// Token: 0x04004765 RID: 18277
	[MarshalAs(UnmanagedType.U1)]
	public byte Equip;

	// Token: 0x04004766 RID: 18278
	[MarshalAs(UnmanagedType.U2)]
	public ushort NodusOneID;

	// Token: 0x04004767 RID: 18279
	[MarshalAs(UnmanagedType.U2)]
	public ushort NodusTwoID;

	// Token: 0x04004768 RID: 18280
	[MarshalAs(UnmanagedType.U2)]
	public ushort NodusThrID;

	// Token: 0x04004769 RID: 18281
	[MarshalAs(UnmanagedType.U2)]
	public ushort RewardOneID;

	// Token: 0x0400476A RID: 18282
	[MarshalAs(UnmanagedType.U2)]
	public ushort RewardTwoID;

	// Token: 0x0400476B RID: 18283
	[MarshalAs(UnmanagedType.U2)]
	public ushort RewardThrID;
}
