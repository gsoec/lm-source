using System;
using System.Runtime.InteropServices;

// Token: 0x0200009E RID: 158
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TalentTreeLayoutTbl
{
	// Token: 0x0400082F RID: 2095
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000830 RID: 2096
	[MarshalAs(UnmanagedType.U1)]
	public byte TalentCount;

	// Token: 0x04000831 RID: 2097
	[MarshalAs(UnmanagedType.U1)]
	public byte HorizontalType;

	// Token: 0x04000832 RID: 2098
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public TreeBody[] TreeData;
}
