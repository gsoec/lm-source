using System;
using System.Runtime.InteropServices;

// Token: 0x020003C7 RID: 967
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct _FBMissionCont
{
	// Token: 0x04003CC1 RID: 15553
	[MarshalAs(UnmanagedType.U2)]
	public ushort Descirb;

	// Token: 0x04003CC2 RID: 15554
	[MarshalAs(UnmanagedType.U1)]
	public byte Kind;

	// Token: 0x04003CC3 RID: 15555
	[MarshalAs(UnmanagedType.U4)]
	public uint Parm;
}
