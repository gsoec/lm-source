using System;
using System.Runtime.InteropServices;

// Token: 0x020000A1 RID: 161
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HeroTalkTbl
{
	// Token: 0x04000845 RID: 2117
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000846 RID: 2118
	[MarshalAs(UnmanagedType.U2)]
	public ushort TalkGroup;

	// Token: 0x04000847 RID: 2119
	[MarshalAs(UnmanagedType.U1)]
	public byte ShowRole;

	// Token: 0x04000848 RID: 2120
	[MarshalAs(UnmanagedType.U2)]
	public ushort NPCID;

	// Token: 0x04000849 RID: 2121
	[MarshalAs(UnmanagedType.U1)]
	public byte Enemytalk;

	// Token: 0x0400084A RID: 2122
	[MarshalAs(UnmanagedType.U2)]
	public ushort StringID;
}
