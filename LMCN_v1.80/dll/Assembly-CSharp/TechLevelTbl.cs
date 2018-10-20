using System;
using System.Runtime.InteropServices;

// Token: 0x02000098 RID: 152
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TechLevelTbl
{
	// Token: 0x040007F4 RID: 2036
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040007F5 RID: 2037
	[MarshalAs(UnmanagedType.U2)]
	public ushort TechID;

	// Token: 0x040007F6 RID: 2038
	[MarshalAs(UnmanagedType.U1)]
	public byte Level;

	// Token: 0x040007F7 RID: 2039
	[MarshalAs(UnmanagedType.U4)]
	public uint LevelupTime;

	// Token: 0x040007F8 RID: 2040
	[MarshalAs(UnmanagedType.U4)]
	public uint Grain;

	// Token: 0x040007F9 RID: 2041
	[MarshalAs(UnmanagedType.U4)]
	public uint Rock;

	// Token: 0x040007FA RID: 2042
	[MarshalAs(UnmanagedType.U4)]
	public uint Wood;

	// Token: 0x040007FB RID: 2043
	[MarshalAs(UnmanagedType.U4)]
	public uint Iron;

	// Token: 0x040007FC RID: 2044
	[MarshalAs(UnmanagedType.U4)]
	public uint Gold;

	// Token: 0x040007FD RID: 2045
	[MarshalAs(UnmanagedType.U1)]
	public byte ResearchLevel;

	// Token: 0x040007FE RID: 2046
	[MarshalAs(UnmanagedType.U2)]
	public ushort RequireTechID1;

	// Token: 0x040007FF RID: 2047
	[MarshalAs(UnmanagedType.U1)]
	public byte RequireTechLv1;

	// Token: 0x04000800 RID: 2048
	[MarshalAs(UnmanagedType.U2)]
	public ushort RequireTechID2;

	// Token: 0x04000801 RID: 2049
	[MarshalAs(UnmanagedType.U1)]
	public byte RequireTechLv2;

	// Token: 0x04000802 RID: 2050
	[MarshalAs(UnmanagedType.U2)]
	public ushort RequireTechID3;

	// Token: 0x04000803 RID: 2051
	[MarshalAs(UnmanagedType.U1)]
	public byte RequireTechLv3;

	// Token: 0x04000804 RID: 2052
	[MarshalAs(UnmanagedType.U2)]
	public ushort RequireTechID4;

	// Token: 0x04000805 RID: 2053
	[MarshalAs(UnmanagedType.U1)]
	public byte RequireTechLv4;

	// Token: 0x04000806 RID: 2054
	[MarshalAs(UnmanagedType.U4)]
	public uint Strength;

	// Token: 0x04000807 RID: 2055
	[MarshalAs(UnmanagedType.U2)]
	public ushort Effect;

	// Token: 0x04000808 RID: 2056
	[MarshalAs(UnmanagedType.U4)]
	public uint EffectVal;
}
