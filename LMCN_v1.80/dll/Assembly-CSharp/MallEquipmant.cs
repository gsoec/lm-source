using System;
using System.Runtime.InteropServices;

// Token: 0x020000AF RID: 175
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MallEquipmant
{
	// Token: 0x04000879 RID: 2169
	[MarshalAs(UnmanagedType.U2)]
	public ushort EquipKey;

	// Token: 0x0400087A RID: 2170
	[MarshalAs(UnmanagedType.U2)]
	public ushort EquipName;

	// Token: 0x0400087B RID: 2171
	[MarshalAs(UnmanagedType.U2)]
	public ushort EquipIcon;

	// Token: 0x0400087C RID: 2172
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public ushort[] ItemId;

	// Token: 0x0400087D RID: 2173
	[MarshalAs(UnmanagedType.U2)]
	public ushort SortValue;

	// Token: 0x0400087E RID: 2174
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public byte[] EquipData;
}
