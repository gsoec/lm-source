using System;
using System.Runtime.InteropServices;

// Token: 0x02000089 RID: 137
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SoldierData
{
	// Token: 0x0400076B RID: 1899
	[MarshalAs(UnmanagedType.U2)]
	public ushort SoldierKey;

	// Token: 0x0400076C RID: 1900
	[MarshalAs(UnmanagedType.U1)]
	public byte Kind;

	// Token: 0x0400076D RID: 1901
	[MarshalAs(UnmanagedType.U2)]
	public ushort Name;

	// Token: 0x0400076E RID: 1902
	[MarshalAs(UnmanagedType.U2)]
	public ushort Icon;

	// Token: 0x0400076F RID: 1903
	[MarshalAs(UnmanagedType.U2)]
	public ushort Model;

	// Token: 0x04000770 RID: 1904
	[MarshalAs(UnmanagedType.U2)]
	public ushort Caption;

	// Token: 0x04000771 RID: 1905
	[MarshalAs(UnmanagedType.U1)]
	public byte SoldierKind;

	// Token: 0x04000772 RID: 1906
	[MarshalAs(UnmanagedType.U1)]
	public byte Tier;

	// Token: 0x04000773 RID: 1907
	[MarshalAs(UnmanagedType.U2)]
	public ushort Attack;

	// Token: 0x04000774 RID: 1908
	[MarshalAs(UnmanagedType.U2)]
	public ushort Defence;

	// Token: 0x04000775 RID: 1909
	[MarshalAs(UnmanagedType.U2)]
	public ushort MaxHp;

	// Token: 0x04000776 RID: 1910
	[MarshalAs(UnmanagedType.U2)]
	public ushort Speed;

	// Token: 0x04000777 RID: 1911
	[MarshalAs(UnmanagedType.U1)]
	public byte Traffic;

	// Token: 0x04000778 RID: 1912
	[MarshalAs(UnmanagedType.U1)]
	public byte Strength;

	// Token: 0x04000779 RID: 1913
	[MarshalAs(UnmanagedType.U1)]
	public byte Salaries;

	// Token: 0x0400077A RID: 1914
	[MarshalAs(UnmanagedType.U2)]
	public ushort Radius;

	// Token: 0x0400077B RID: 1915
	[MarshalAs(UnmanagedType.U2)]
	public ushort Skill;

	// Token: 0x0400077C RID: 1916
	[MarshalAs(UnmanagedType.U2)]
	public ushort FoodRequire;

	// Token: 0x0400077D RID: 1917
	[MarshalAs(UnmanagedType.U2)]
	public ushort StoneRequire;

	// Token: 0x0400077E RID: 1918
	[MarshalAs(UnmanagedType.U2)]
	public ushort WoodRequire;

	// Token: 0x0400077F RID: 1919
	[MarshalAs(UnmanagedType.U2)]
	public ushort IronRequire;

	// Token: 0x04000780 RID: 1920
	[MarshalAs(UnmanagedType.U2)]
	public ushort MoneyRequire;

	// Token: 0x04000781 RID: 1921
	[MarshalAs(UnmanagedType.U2)]
	public ushort TimeRequire;

	// Token: 0x04000782 RID: 1922
	[MarshalAs(UnmanagedType.U2)]
	public ushort Science;
}
