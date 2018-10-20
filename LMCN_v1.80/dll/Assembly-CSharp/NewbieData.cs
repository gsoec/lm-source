using System;
using System.Runtime.InteropServices;

// Token: 0x020000B0 RID: 176
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NewbieData
{
	// Token: 0x0400087F RID: 2175
	[MarshalAs(UnmanagedType.U2)]
	public ushort NewbieKey;

	// Token: 0x04000880 RID: 2176
	[MarshalAs(UnmanagedType.U2)]
	public ushort Food;

	// Token: 0x04000881 RID: 2177
	[MarshalAs(UnmanagedType.U2)]
	public ushort Rock;

	// Token: 0x04000882 RID: 2178
	[MarshalAs(UnmanagedType.U2)]
	public ushort Wood;

	// Token: 0x04000883 RID: 2179
	[MarshalAs(UnmanagedType.U2)]
	public ushort Iron;

	// Token: 0x04000884 RID: 2180
	[MarshalAs(UnmanagedType.U2)]
	public ushort Gold;

	// Token: 0x04000885 RID: 2181
	[MarshalAs(UnmanagedType.U2)]
	public ushort Power;

	// Token: 0x04000886 RID: 2182
	[MarshalAs(UnmanagedType.U2)]
	public ushort Lead;

	// Token: 0x04000887 RID: 2183
	[MarshalAs(UnmanagedType.U2)]
	public ushort Morale;
}
