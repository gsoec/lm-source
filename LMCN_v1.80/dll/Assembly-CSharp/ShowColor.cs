using System;
using System.Runtime.InteropServices;

// Token: 0x02000268 RID: 616
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ShowColor
{
	// Token: 0x04002674 RID: 9844
	[MarshalAs(UnmanagedType.U2)]
	public ushort ShowColorID;

	// Token: 0x04002675 RID: 9845
	[MarshalAs(UnmanagedType.U1)]
	public byte ColorR;

	// Token: 0x04002676 RID: 9846
	[MarshalAs(UnmanagedType.U1)]
	public byte ColorG;

	// Token: 0x04002677 RID: 9847
	[MarshalAs(UnmanagedType.U1)]
	public byte ColorB;

	// Token: 0x04002678 RID: 9848
	[MarshalAs(UnmanagedType.U1)]
	public ushort ColorA;
}
