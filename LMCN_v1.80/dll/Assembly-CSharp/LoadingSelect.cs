using System;
using System.Runtime.InteropServices;

// Token: 0x020000B2 RID: 178
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LoadingSelect
{
	// Token: 0x04000892 RID: 2194
	[MarshalAs(UnmanagedType.U2)]
	public ushort StringID;

	// Token: 0x04000893 RID: 2195
	[MarshalAs(UnmanagedType.U1)]
	public byte GotoID;
}
