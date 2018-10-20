using System;
using System.Runtime.InteropServices;

// Token: 0x020004B0 RID: 1200
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Stage_ItemData
{
	// Token: 0x04004777 RID: 18295
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemID;

	// Token: 0x04004778 RID: 18296
	[MarshalAs(UnmanagedType.U1)]
	public byte ItemNum;
}
