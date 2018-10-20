using System;
using System.Runtime.InteropServices;

// Token: 0x0200008D RID: 141
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BuildLevelRequestGroup
{
	// Token: 0x040007A3 RID: 1955
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040007A4 RID: 1956
	[MarshalAs(UnmanagedType.U2)]
	public ushort GroupID;

	// Token: 0x040007A5 RID: 1957
	[MarshalAs(UnmanagedType.U1)]
	public byte ConditionType;

	// Token: 0x040007A6 RID: 1958
	[MarshalAs(UnmanagedType.U2)]
	public ushort Condition;

	// Token: 0x040007A7 RID: 1959
	[MarshalAs(UnmanagedType.U2)]
	public ushort Num;
}
