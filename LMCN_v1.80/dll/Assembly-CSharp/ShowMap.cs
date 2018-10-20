using System;
using System.Runtime.InteropServices;

// Token: 0x02000264 RID: 612
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ShowMap
{
	// Token: 0x04002664 RID: 9828
	[MarshalAs(UnmanagedType.U2)]
	public ushort ShowMapID;

	// Token: 0x04002665 RID: 9829
	[MarshalAs(UnmanagedType.U2)]
	public ushort ListID;

	// Token: 0x04002666 RID: 9830
	[MarshalAs(UnmanagedType.U4)]
	public uint ShowTime;

	// Token: 0x04002667 RID: 9831
	[MarshalAs(UnmanagedType.U2)]
	public ushort NextListID;
}
