using System;
using System.Runtime.InteropServices;

// Token: 0x02000163 RID: 355
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AllianceLvUpData
{
	// Token: 0x04000E0B RID: 3595
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000E0C RID: 3596
	[MarshalAs(UnmanagedType.U4)]
	public uint LvExp;
}
