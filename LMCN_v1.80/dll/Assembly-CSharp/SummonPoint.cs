using System;
using System.Runtime.InteropServices;

// Token: 0x020000AC RID: 172
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SummonPoint
{
	// Token: 0x0400086F RID: 2159
	[MarshalAs(UnmanagedType.U4)]
	public uint Score;

	// Token: 0x04000870 RID: 2160
	[MarshalAs(UnmanagedType.U1)]
	public byte Point;
}
