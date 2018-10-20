using System;
using System.Runtime.InteropServices;

// Token: 0x02000161 RID: 353
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LandWalkerData
{
	// Token: 0x04000DFB RID: 3579
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000DFC RID: 3580
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public ushort[] Data;

	// Token: 0x04000DFD RID: 3581
	[MarshalAs(UnmanagedType.U1)]
	public byte fadeEnd;

	// Token: 0x04000DFE RID: 3582
	[MarshalAs(UnmanagedType.U1)]
	public byte fadeStart;

	// Token: 0x04000DFF RID: 3583
	[MarshalAs(UnmanagedType.U2)]
	public ushort direction;

	// Token: 0x04000E00 RID: 3584
	[MarshalAs(UnmanagedType.U1)]
	public byte totalTime;

	// Token: 0x04000E01 RID: 3585
	[MarshalAs(UnmanagedType.U1)]
	public byte groupID;

	// Token: 0x04000E02 RID: 3586
	[MarshalAs(UnmanagedType.U1)]
	public byte SpriteSort;

	// Token: 0x04000E03 RID: 3587
	[MarshalAs(UnmanagedType.U1)]
	public byte chapter;

	// Token: 0x04000E04 RID: 3588
	[MarshalAs(UnmanagedType.U1)]
	public byte NeverGone;

	// Token: 0x04000E05 RID: 3589
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public LandWalkerGenData[] GenData;
}
