using System;
using System.Runtime.InteropServices;

// Token: 0x020000B1 RID: 177
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NewbieUI
{
	// Token: 0x04000888 RID: 2184
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000889 RID: 2185
	[MarshalAs(UnmanagedType.U1)]
	public byte TalkType;

	// Token: 0x0400088A RID: 2186
	[MarshalAs(UnmanagedType.U2)]
	public ushort TalkID;

	// Token: 0x0400088B RID: 2187
	[MarshalAs(UnmanagedType.U2)]
	public ushort TalkBoxX;

	// Token: 0x0400088C RID: 2188
	[MarshalAs(UnmanagedType.U1)]
	public byte TalkBoxX_Sign;

	// Token: 0x0400088D RID: 2189
	[MarshalAs(UnmanagedType.U2)]
	public ushort TalkBoxY;

	// Token: 0x0400088E RID: 2190
	[MarshalAs(UnmanagedType.U1)]
	public byte TalkBoxY_Sign;

	// Token: 0x0400088F RID: 2191
	[MarshalAs(UnmanagedType.U1)]
	public byte ArrowDir;

	// Token: 0x04000890 RID: 2192
	[MarshalAs(UnmanagedType.U2)]
	public ushort TouchWidth;

	// Token: 0x04000891 RID: 2193
	[MarshalAs(UnmanagedType.U2)]
	public ushort TouchHeight;
}
