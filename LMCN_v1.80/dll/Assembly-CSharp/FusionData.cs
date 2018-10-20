using System;
using System.Runtime.InteropServices;

// Token: 0x020000C5 RID: 197
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct FusionData
{
	// Token: 0x0400090B RID: 2315
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x0400090C RID: 2316
	[MarshalAs(UnmanagedType.U1)]
	public byte Fusion_Kind;

	// Token: 0x0400090D RID: 2317
	[MarshalAs(UnmanagedType.U2)]
	public ushort Fusion_ItemID;

	// Token: 0x0400090E RID: 2318
	[MarshalAs(UnmanagedType.U4)]
	public uint FoodRequire;

	// Token: 0x0400090F RID: 2319
	[MarshalAs(UnmanagedType.U4)]
	public uint StoneRequire;

	// Token: 0x04000910 RID: 2320
	[MarshalAs(UnmanagedType.U4)]
	public uint WoodRequire;

	// Token: 0x04000911 RID: 2321
	[MarshalAs(UnmanagedType.U4)]
	public uint IronRequire;

	// Token: 0x04000912 RID: 2322
	[MarshalAs(UnmanagedType.U4)]
	public uint MoneyRequire;

	// Token: 0x04000913 RID: 2323
	[MarshalAs(UnmanagedType.U4)]
	public uint PetRequire;

	// Token: 0x04000914 RID: 2324
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public ComboBoxItem[] ItemData;

	// Token: 0x04000915 RID: 2325
	[MarshalAs(UnmanagedType.U4)]
	public uint TimeRequire;

	// Token: 0x04000916 RID: 2326
	[MarshalAs(UnmanagedType.U2)]
	public ushort Science;
}
