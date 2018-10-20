using System;
using System.Runtime.InteropServices;

// Token: 0x020000B4 RID: 180
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CoordData
{
	// Token: 0x0400089B RID: 2203
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x0400089C RID: 2204
	[MarshalAs(UnmanagedType.U1)]
	public byte Type;

	// Token: 0x0400089D RID: 2205
	[MarshalAs(UnmanagedType.U2)]
	public ushort AtkX;

	// Token: 0x0400089E RID: 2206
	[MarshalAs(UnmanagedType.U2)]
	public ushort AtkY;

	// Token: 0x0400089F RID: 2207
	[MarshalAs(UnmanagedType.U2)]
	public ushort DefX;

	// Token: 0x040008A0 RID: 2208
	[MarshalAs(UnmanagedType.U2)]
	public ushort DefY;

	// Token: 0x040008A1 RID: 2209
	[MarshalAs(UnmanagedType.U2)]
	public ushort SiegeAtkX;

	// Token: 0x040008A2 RID: 2210
	[MarshalAs(UnmanagedType.U2)]
	public ushort SiegeAtkY;

	// Token: 0x040008A3 RID: 2211
	[MarshalAs(UnmanagedType.U2)]
	public ushort SiegeDefX;

	// Token: 0x040008A4 RID: 2212
	[MarshalAs(UnmanagedType.U2)]
	public ushort SiegeDefY;

	// Token: 0x040008A5 RID: 2213
	[MarshalAs(UnmanagedType.U2)]
	public ushort Siege23DefX;

	// Token: 0x040008A6 RID: 2214
	[MarshalAs(UnmanagedType.U2)]
	public ushort Siege23DefY;

	// Token: 0x040008A7 RID: 2215
	[MarshalAs(UnmanagedType.U2)]
	public ushort SiegeRangeNoWallDefX;

	// Token: 0x040008A8 RID: 2216
	[MarshalAs(UnmanagedType.U2)]
	public ushort SiegeRangeNoWallDefY;
}
