using System;
using System.Runtime.InteropServices;

// Token: 0x02000094 RID: 148
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MarchPaltform
{
	// Token: 0x040007D3 RID: 2003
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040007D4 RID: 2004
	[MarshalAs(UnmanagedType.U2)]
	public ushort UpStartID;

	// Token: 0x040007D5 RID: 2005
	[MarshalAs(UnmanagedType.U2)]
	public ushort UpEndID;

	// Token: 0x040007D6 RID: 2006
	[MarshalAs(UnmanagedType.U2)]
	public ushort UpRightStartID;

	// Token: 0x040007D7 RID: 2007
	[MarshalAs(UnmanagedType.U2)]
	public ushort UpRightEndID;

	// Token: 0x040007D8 RID: 2008
	[MarshalAs(UnmanagedType.U2)]
	public ushort RightStartID;

	// Token: 0x040007D9 RID: 2009
	[MarshalAs(UnmanagedType.U2)]
	public ushort RightEndID;

	// Token: 0x040007DA RID: 2010
	[MarshalAs(UnmanagedType.U2)]
	public ushort DownRightStartID;

	// Token: 0x040007DB RID: 2011
	[MarshalAs(UnmanagedType.U2)]
	public ushort DownRightEndID;

	// Token: 0x040007DC RID: 2012
	[MarshalAs(UnmanagedType.U2)]
	public ushort DownStartID;

	// Token: 0x040007DD RID: 2013
	[MarshalAs(UnmanagedType.U2)]
	public ushort DownEndID;
}
