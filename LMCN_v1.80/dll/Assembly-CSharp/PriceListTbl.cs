using System;
using System.Runtime.InteropServices;

// Token: 0x02000093 RID: 147
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PriceListTbl
{
	// Token: 0x040007CF RID: 1999
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040007D0 RID: 2000
	[MarshalAs(UnmanagedType.U1)]
	public byte Type;

	// Token: 0x040007D1 RID: 2001
	[MarshalAs(UnmanagedType.U4)]
	public uint Inierval;

	// Token: 0x040007D2 RID: 2002
	[MarshalAs(UnmanagedType.U2)]
	public ushort Price;
}
