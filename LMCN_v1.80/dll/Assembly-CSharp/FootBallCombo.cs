using System;
using System.Runtime.InteropServices;

// Token: 0x0200035A RID: 858
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct FootBallCombo
{
	// Token: 0x04003830 RID: 14384
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04003831 RID: 14385
	[MarshalAs(UnmanagedType.U4)]
	public uint Combo;
}
