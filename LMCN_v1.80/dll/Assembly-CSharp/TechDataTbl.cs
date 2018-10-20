using System;
using System.Runtime.InteropServices;

// Token: 0x02000097 RID: 151
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TechDataTbl
{
	// Token: 0x040007ED RID: 2029
	[MarshalAs(UnmanagedType.U2)]
	public ushort TechID;

	// Token: 0x040007EE RID: 2030
	[MarshalAs(UnmanagedType.U1)]
	public byte Kind;

	// Token: 0x040007EF RID: 2031
	[MarshalAs(UnmanagedType.U2)]
	public ushort TechName;

	// Token: 0x040007F0 RID: 2032
	[MarshalAs(UnmanagedType.U2)]
	public ushort Graphic;

	// Token: 0x040007F1 RID: 2033
	[MarshalAs(UnmanagedType.U1)]
	public byte LevelMax;

	// Token: 0x040007F2 RID: 2034
	[MarshalAs(UnmanagedType.U1)]
	public byte Investigate;

	// Token: 0x040007F3 RID: 2035
	[MarshalAs(UnmanagedType.U1)]
	public byte Locked;
}
