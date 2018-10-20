using System;
using System.Runtime.InteropServices;

// Token: 0x0200009A RID: 154
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TechTreeLayoutTbl
{
	// Token: 0x04000810 RID: 2064
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000811 RID: 2065
	[MarshalAs(UnmanagedType.U1)]
	public byte Kind;

	// Token: 0x04000812 RID: 2066
	[MarshalAs(UnmanagedType.U1)]
	public byte TechCount;

	// Token: 0x04000813 RID: 2067
	[MarshalAs(UnmanagedType.U1)]
	public byte HorizontalType;

	// Token: 0x04000814 RID: 2068
	[MarshalAs(UnmanagedType.U2)]
	public ushort TechID1;

	// Token: 0x04000815 RID: 2069
	[MarshalAs(UnmanagedType.U1)]
	public byte VerticalExtend1;

	// Token: 0x04000816 RID: 2070
	[MarshalAs(UnmanagedType.U1)]
	public byte HorizontalExtend1;

	// Token: 0x04000817 RID: 2071
	[MarshalAs(UnmanagedType.U2)]
	public ushort TechID2;

	// Token: 0x04000818 RID: 2072
	[MarshalAs(UnmanagedType.U1)]
	public byte VerticalExtend2;

	// Token: 0x04000819 RID: 2073
	[MarshalAs(UnmanagedType.U1)]
	public byte HorizontalExtend2;

	// Token: 0x0400081A RID: 2074
	[MarshalAs(UnmanagedType.U2)]
	public ushort TechID3;

	// Token: 0x0400081B RID: 2075
	[MarshalAs(UnmanagedType.U1)]
	public byte VerticalExtend3;

	// Token: 0x0400081C RID: 2076
	[MarshalAs(UnmanagedType.U1)]
	public byte HorizontalExtend3;

	// Token: 0x0400081D RID: 2077
	[MarshalAs(UnmanagedType.U2)]
	public ushort TechID4;

	// Token: 0x0400081E RID: 2078
	[MarshalAs(UnmanagedType.U1)]
	public byte VerticalExtend4;

	// Token: 0x0400081F RID: 2079
	[MarshalAs(UnmanagedType.U1)]
	public byte HorizontalExtend4;
}
