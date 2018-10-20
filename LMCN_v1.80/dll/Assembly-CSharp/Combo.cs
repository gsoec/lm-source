using System;
using System.Runtime.InteropServices;

// Token: 0x0200009F RID: 159
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Combo
{
	// Token: 0x04000833 RID: 2099
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000834 RID: 2100
	[MarshalAs(UnmanagedType.U1)]
	public byte Count;

	// Token: 0x04000835 RID: 2101
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public ushort[] HitPoint;
}
