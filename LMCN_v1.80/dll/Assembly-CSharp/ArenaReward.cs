using System;
using System.Runtime.InteropServices;

// Token: 0x02000165 RID: 357
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ArenaReward
{
	// Token: 0x04000E0F RID: 3599
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000E10 RID: 3600
	[MarshalAs(UnmanagedType.U2)]
	public ushort Value1;

	// Token: 0x04000E11 RID: 3601
	[MarshalAs(UnmanagedType.U2)]
	public ushort Value2;

	// Token: 0x04000E12 RID: 3602
	[MarshalAs(UnmanagedType.U2)]
	public ushort Crystal;
}
