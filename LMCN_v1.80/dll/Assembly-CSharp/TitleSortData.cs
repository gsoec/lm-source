using System;
using System.Runtime.InteropServices;

// Token: 0x020000B9 RID: 185
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TitleSortData
{
	// Token: 0x040008D4 RID: 2260
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040008D5 RID: 2261
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] TitleID;

	// Token: 0x040008D6 RID: 2262
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public ushort[] Reserve;
}
