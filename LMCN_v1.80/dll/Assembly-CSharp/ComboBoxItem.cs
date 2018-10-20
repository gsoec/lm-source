using System;
using System.Runtime.InteropServices;

// Token: 0x020000A3 RID: 163
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ComboBoxItem
{
	// Token: 0x0400084E RID: 2126
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemID;

	// Token: 0x0400084F RID: 2127
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemCount;

	// Token: 0x04000850 RID: 2128
	[MarshalAs(UnmanagedType.U1)]
	public byte Rank;
}
