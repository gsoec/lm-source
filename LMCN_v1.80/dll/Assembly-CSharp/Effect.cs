using System;
using System.Runtime.InteropServices;

// Token: 0x02000090 RID: 144
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Effect
{
	// Token: 0x040007BA RID: 1978
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040007BB RID: 1979
	[MarshalAs(UnmanagedType.U2)]
	public ushort String_infoID;

	// Token: 0x040007BC RID: 1980
	[MarshalAs(UnmanagedType.U2)]
	public ushort StringID;

	// Token: 0x040007BD RID: 1981
	[MarshalAs(UnmanagedType.U2)]
	public ushort InfoID;

	// Token: 0x040007BE RID: 1982
	[MarshalAs(UnmanagedType.U2)]
	public ushort ValueID;

	// Token: 0x040007BF RID: 1983
	[MarshalAs(UnmanagedType.U2)]
	public ushort StatusIcon;

	// Token: 0x040007C0 RID: 1984
	[MarshalAs(UnmanagedType.U2)]
	public ushort EffectIcon;
}
