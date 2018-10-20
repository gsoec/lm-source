using System;
using System.Runtime.InteropServices;

// Token: 0x02000092 RID: 146
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HUDTypeTbl
{
	// Token: 0x040007C9 RID: 1993
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040007CA RID: 1994
	[MarshalAs(UnmanagedType.U1)]
	public byte Graphic;

	// Token: 0x040007CB RID: 1995
	[MarshalAs(UnmanagedType.U1)]
	public byte TextColor;

	// Token: 0x040007CC RID: 1996
	[MarshalAs(UnmanagedType.U1)]
	public byte DelayTime;

	// Token: 0x040007CD RID: 1997
	[MarshalAs(UnmanagedType.U4)]
	public uint Sound;

	// Token: 0x040007CE RID: 1998
	[MarshalAs(UnmanagedType.U1)]
	public byte Mp3Sound;
}
