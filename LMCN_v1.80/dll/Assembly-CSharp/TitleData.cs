using System;
using System.Runtime.InteropServices;

// Token: 0x020000B8 RID: 184
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TitleData
{
	// Token: 0x040008CF RID: 2255
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040008D0 RID: 2256
	[MarshalAs(UnmanagedType.U2)]
	public ushort StringID;

	// Token: 0x040008D1 RID: 2257
	[MarshalAs(UnmanagedType.U1)]
	public byte IconID;

	// Token: 0x040008D2 RID: 2258
	[MarshalAs(UnmanagedType.U1)]
	public byte isDebuff;

	// Token: 0x040008D3 RID: 2259
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public TitleEffectSet[] Effects;
}
