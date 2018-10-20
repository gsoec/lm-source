using System;
using System.Runtime.InteropServices;

// Token: 0x0200008C RID: 140
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BuildLevelRequest
{
	// Token: 0x0400078A RID: 1930
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x0400078B RID: 1931
	[MarshalAs(UnmanagedType.U2)]
	public ushort BuildID;

	// Token: 0x0400078C RID: 1932
	[MarshalAs(UnmanagedType.U1)]
	public byte Level;

	// Token: 0x0400078D RID: 1933
	[MarshalAs(UnmanagedType.U4)]
	public uint BuildTime;

	// Token: 0x0400078E RID: 1934
	[MarshalAs(UnmanagedType.U2)]
	public ushort GroupID;

	// Token: 0x0400078F RID: 1935
	[MarshalAs(UnmanagedType.U4)]
	public uint RequestFood;

	// Token: 0x04000790 RID: 1936
	[MarshalAs(UnmanagedType.U4)]
	public uint RequestRock;

	// Token: 0x04000791 RID: 1937
	[MarshalAs(UnmanagedType.U4)]
	public uint RequestWood;

	// Token: 0x04000792 RID: 1938
	[MarshalAs(UnmanagedType.U4)]
	public uint RequestIron;

	// Token: 0x04000793 RID: 1939
	[MarshalAs(UnmanagedType.U4)]
	public uint RequestGold;

	// Token: 0x04000794 RID: 1940
	[MarshalAs(UnmanagedType.U4)]
	public uint CastleArmy;

	// Token: 0x04000795 RID: 1941
	[MarshalAs(UnmanagedType.U4)]
	public uint Strength;

	// Token: 0x04000796 RID: 1942
	[MarshalAs(UnmanagedType.U2)]
	public ushort Effect1;

	// Token: 0x04000797 RID: 1943
	[MarshalAs(UnmanagedType.U4)]
	public uint Value1;

	// Token: 0x04000798 RID: 1944
	[MarshalAs(UnmanagedType.U2)]
	public ushort Effect2;

	// Token: 0x04000799 RID: 1945
	[MarshalAs(UnmanagedType.U4)]
	public uint Value2;

	// Token: 0x0400079A RID: 1946
	[MarshalAs(UnmanagedType.U2)]
	public ushort Effect3;

	// Token: 0x0400079B RID: 1947
	[MarshalAs(UnmanagedType.U2)]
	public ushort Value3;

	// Token: 0x0400079C RID: 1948
	[MarshalAs(UnmanagedType.U2)]
	public ushort Effect4;

	// Token: 0x0400079D RID: 1949
	[MarshalAs(UnmanagedType.U2)]
	public ushort Value4;

	// Token: 0x0400079E RID: 1950
	[MarshalAs(UnmanagedType.U2)]
	public ushort Value5;

	// Token: 0x0400079F RID: 1951
	[MarshalAs(UnmanagedType.U2)]
	public ushort ExtEffect1;

	// Token: 0x040007A0 RID: 1952
	[MarshalAs(UnmanagedType.U4)]
	public uint ExtValue1;

	// Token: 0x040007A1 RID: 1953
	[MarshalAs(UnmanagedType.U2)]
	public ushort ExtEffect2;

	// Token: 0x040007A2 RID: 1954
	[MarshalAs(UnmanagedType.U1)]
	public byte ExtValue2;
}
