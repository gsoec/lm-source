using System;
using System.Runtime.InteropServices;

// Token: 0x02000095 RID: 149
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MarchOffset
{
	// Token: 0x040007DE RID: 2014
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040007DF RID: 2015
	[MarshalAs(UnmanagedType.U1)]
	public byte Kind;

	// Token: 0x040007E0 RID: 2016
	[MarshalAs(UnmanagedType.U1)]
	public byte AttackerDirection;

	// Token: 0x040007E1 RID: 2017
	[MarshalAs(UnmanagedType.U1)]
	public byte SignedX;

	// Token: 0x040007E2 RID: 2018
	[MarshalAs(UnmanagedType.U2)]
	public ushort OffsetX;

	// Token: 0x040007E3 RID: 2019
	[MarshalAs(UnmanagedType.U1)]
	public byte SignedY;

	// Token: 0x040007E4 RID: 2020
	[MarshalAs(UnmanagedType.U2)]
	public ushort OffsetY;
}
