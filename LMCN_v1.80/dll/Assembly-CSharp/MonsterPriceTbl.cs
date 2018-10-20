using System;
using System.Runtime.InteropServices;

// Token: 0x020001E2 RID: 482
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MonsterPriceTbl
{
	// Token: 0x04001D74 RID: 7540
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04001D75 RID: 7541
	[MarshalAs(UnmanagedType.U2)]
	public ushort Group;

	// Token: 0x04001D76 RID: 7542
	[MarshalAs(UnmanagedType.U1)]
	public byte Rank;

	// Token: 0x04001D77 RID: 7543
	[MarshalAs(UnmanagedType.U2)]
	public ushort Item;

	// Token: 0x04001D78 RID: 7544
	[MarshalAs(UnmanagedType.U1)]
	public byte Qty;
}
