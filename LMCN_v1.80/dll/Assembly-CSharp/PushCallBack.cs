using System;
using System.Runtime.InteropServices;

// Token: 0x02000170 RID: 368
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PushCallBack
{
	// Token: 0x04000E3A RID: 3642
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000E3B RID: 3643
	[MarshalAs(UnmanagedType.U1)]
	public byte LowLevel;

	// Token: 0x04000E3C RID: 3644
	[MarshalAs(UnmanagedType.U1)]
	public byte HighLevel;

	// Token: 0x04000E3D RID: 3645
	[MarshalAs(UnmanagedType.U1)]
	public byte Hour;

	// Token: 0x04000E3E RID: 3646
	[MarshalAs(UnmanagedType.U2)]
	public ushort Ube1;

	// Token: 0x04000E3F RID: 3647
	[MarshalAs(UnmanagedType.U2)]
	public ushort Ube2;

	// Token: 0x04000E40 RID: 3648
	[MarshalAs(UnmanagedType.U2)]
	public ushort Ube3;
}
