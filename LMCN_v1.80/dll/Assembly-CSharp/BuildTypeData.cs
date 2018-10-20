using System;
using System.Runtime.InteropServices;

// Token: 0x0200008E RID: 142
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BuildTypeData
{
	// Token: 0x040007A8 RID: 1960
	[MarshalAs(UnmanagedType.U2)]
	public ushort BuildID;

	// Token: 0x040007A9 RID: 1961
	[MarshalAs(UnmanagedType.U2)]
	public ushort NameID;

	// Token: 0x040007AA RID: 1962
	[MarshalAs(UnmanagedType.U1)]
	public byte Kind;

	// Token: 0x040007AB RID: 1963
	[MarshalAs(UnmanagedType.U1)]
	public byte GraphicID;

	// Token: 0x040007AC RID: 1964
	[MarshalAs(UnmanagedType.U2)]
	public ushort StringID;

	// Token: 0x040007AD RID: 1965
	[MarshalAs(UnmanagedType.U2)]
	public ushort ContentID;

	// Token: 0x040007AE RID: 1966
	[MarshalAs(UnmanagedType.U2)]
	public ushort UIExplain;
}
