using System;
using System.Runtime.InteropServices;

// Token: 0x02000096 RID: 150
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TechKindTbl
{
	// Token: 0x040007E5 RID: 2021
	[MarshalAs(UnmanagedType.U2)]
	public ushort TechKind;

	// Token: 0x040007E6 RID: 2022
	[MarshalAs(UnmanagedType.U2)]
	public ushort KindName;

	// Token: 0x040007E7 RID: 2023
	[MarshalAs(UnmanagedType.U1)]
	public byte Graphic;

	// Token: 0x040007E8 RID: 2024
	[MarshalAs(UnmanagedType.U1)]
	public byte Priority;

	// Token: 0x040007E9 RID: 2025
	[MarshalAs(UnmanagedType.U1)]
	public byte ResearchLevel;

	// Token: 0x040007EA RID: 2026
	[MarshalAs(UnmanagedType.U1)]
	public byte ConditionalType;

	// Token: 0x040007EB RID: 2027
	[MarshalAs(UnmanagedType.U2)]
	public ushort Parm;

	// Token: 0x040007EC RID: 2028
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public uint[] Reserve;
}
