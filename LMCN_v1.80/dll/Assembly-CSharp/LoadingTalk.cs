using System;
using System.Runtime.InteropServices;

// Token: 0x020000B3 RID: 179
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LoadingTalk
{
	// Token: 0x04000894 RID: 2196
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000895 RID: 2197
	[MarshalAs(UnmanagedType.U1)]
	public byte Kind;

	// Token: 0x04000896 RID: 2198
	[MarshalAs(UnmanagedType.U1)]
	public byte TalkType;

	// Token: 0x04000897 RID: 2199
	[MarshalAs(UnmanagedType.U1)]
	public byte WaitTime;

	// Token: 0x04000898 RID: 2200
	[MarshalAs(UnmanagedType.U2)]
	public ushort StringID;

	// Token: 0x04000899 RID: 2201
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public LoadingSelect[] Select;

	// Token: 0x0400089A RID: 2202
	[MarshalAs(UnmanagedType.U2)]
	public ushort TimeUpGotoID;
}
