using System;
using System.Runtime.InteropServices;

// Token: 0x02000099 RID: 153
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TechLevelExTbl
{
	// Token: 0x04000809 RID: 2057
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x0400080A RID: 2058
	[MarshalAs(UnmanagedType.U2)]
	public ushort TechID;

	// Token: 0x0400080B RID: 2059
	[MarshalAs(UnmanagedType.U1)]
	public byte Level;

	// Token: 0x0400080C RID: 2060
	[MarshalAs(UnmanagedType.U4)]
	public uint PetResource;

	// Token: 0x0400080D RID: 2061
	[MarshalAs(UnmanagedType.U2)]
	public ushort RequireItem;

	// Token: 0x0400080E RID: 2062
	[MarshalAs(UnmanagedType.U2)]
	public ushort Num;

	// Token: 0x0400080F RID: 2063
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public uint[] Reserve;
}
