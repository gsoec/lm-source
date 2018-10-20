using System;
using System.Runtime.InteropServices;

// Token: 0x020003D8 RID: 984
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct _RewardItem
{
	// Token: 0x04003D20 RID: 15648
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemID;

	// Token: 0x04003D21 RID: 15649
	[MarshalAs(UnmanagedType.U1)]
	public byte Quantity;
}
