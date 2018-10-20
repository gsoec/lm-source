using System;
using System.Runtime.InteropServices;

// Token: 0x0200009D RID: 157
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TreeBody
{
	// Token: 0x0400082C RID: 2092
	[MarshalAs(UnmanagedType.U2)]
	public ushort TalentID;

	// Token: 0x0400082D RID: 2093
	[MarshalAs(UnmanagedType.U1)]
	public byte VerticalExtend;

	// Token: 0x0400082E RID: 2094
	[MarshalAs(UnmanagedType.U1)]
	public byte HorzontalExtend;
}
