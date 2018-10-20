using System;
using System.Runtime.InteropServices;

// Token: 0x0200007D RID: 125
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Enhance
{
	// Token: 0x0400072D RID: 1837
	[MarshalAs(UnmanagedType.U2)]
	public ushort EnhanceKey;

	// Token: 0x0400072E RID: 1838
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 72)]
	public ushort[] EnhanceNumber;
}
