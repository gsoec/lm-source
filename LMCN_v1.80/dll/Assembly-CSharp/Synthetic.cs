using System;
using System.Runtime.InteropServices;

// Token: 0x0200007F RID: 127
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Synthetic
{
	// Token: 0x04000731 RID: 1841
	[MarshalAs(UnmanagedType.U2)]
	public ushort SyntheticItem;

	// Token: 0x04000732 RID: 1842
	[MarshalAs(UnmanagedType.U1)]
	public byte SyntheticItemNum;
}
