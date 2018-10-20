using System;
using System.Runtime.InteropServices;

// Token: 0x020000AE RID: 174
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct EventEquipmant
{
	// Token: 0x04000874 RID: 2164
	[MarshalAs(UnmanagedType.U2)]
	public ushort EquipKey;

	// Token: 0x04000875 RID: 2165
	[MarshalAs(UnmanagedType.U2)]
	public ushort EquipName;

	// Token: 0x04000876 RID: 2166
	[MarshalAs(UnmanagedType.U2)]
	public ushort EquipIcon;

	// Token: 0x04000877 RID: 2167
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public ushort[] ItemId;

	// Token: 0x04000878 RID: 2168
	[MarshalAs(UnmanagedType.U2)]
	public ushort SortValue;
}
