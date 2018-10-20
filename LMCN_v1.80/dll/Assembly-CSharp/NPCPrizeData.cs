using System;
using System.Runtime.InteropServices;

// Token: 0x020000BF RID: 191
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NPCPrizeData
{
	// Token: 0x040008EA RID: 2282
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040008EB RID: 2283
	[MarshalAs(UnmanagedType.U2)]
	public ushort Element;

	// Token: 0x040008EC RID: 2284
	[MarshalAs(UnmanagedType.U2)]
	public ushort PicNo;

	// Token: 0x040008ED RID: 2285
	[MarshalAs(UnmanagedType.U2)]
	public ushort Coin;
}
