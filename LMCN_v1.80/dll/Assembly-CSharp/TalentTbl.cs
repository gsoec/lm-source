using System;
using System.Runtime.InteropServices;

// Token: 0x0200009B RID: 155
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TalentTbl
{
	// Token: 0x04000820 RID: 2080
	[MarshalAs(UnmanagedType.U2)]
	public ushort TalentID;

	// Token: 0x04000821 RID: 2081
	[MarshalAs(UnmanagedType.U2)]
	public ushort NameID;

	// Token: 0x04000822 RID: 2082
	[MarshalAs(UnmanagedType.U2)]
	public ushort Graphic;

	// Token: 0x04000823 RID: 2083
	[MarshalAs(UnmanagedType.U1)]
	public byte LevelMax;

	// Token: 0x04000824 RID: 2084
	[MarshalAs(UnmanagedType.U2)]
	public ushort NeedTalentID;

	// Token: 0x04000825 RID: 2085
	[MarshalAs(UnmanagedType.U1)]
	public byte NeedTalentLv;
}
