using System;
using System.Runtime.InteropServices;

// Token: 0x0200008F RID: 143
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BuildManorData
{
	// Token: 0x040007AF RID: 1967
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040007B0 RID: 1968
	[MarshalAs(UnmanagedType.U2)]
	public ushort MapGroup;

	// Token: 0x040007B1 RID: 1969
	[MarshalAs(UnmanagedType.U2)]
	public ushort ChapterID;

	// Token: 0x040007B2 RID: 1970
	[MarshalAs(UnmanagedType.U1)]
	public byte SearchPriority;

	// Token: 0x040007B3 RID: 1971
	[MarshalAs(UnmanagedType.U1)]
	public byte Kind;

	// Token: 0x040007B4 RID: 1972
	[MarshalAs(UnmanagedType.U2)]
	public ushort bPosionX;

	// Token: 0x040007B5 RID: 1973
	[MarshalAs(UnmanagedType.U2)]
	public ushort bPosionY;

	// Token: 0x040007B6 RID: 1974
	[MarshalAs(UnmanagedType.U2)]
	public ushort bPosionZ;

	// Token: 0x040007B7 RID: 1975
	[MarshalAs(UnmanagedType.U2)]
	public ushort mPosionX;

	// Token: 0x040007B8 RID: 1976
	[MarshalAs(UnmanagedType.U2)]
	public ushort mPosionY;

	// Token: 0x040007B9 RID: 1977
	[MarshalAs(UnmanagedType.U2)]
	public ushort mPosionZ;
}
