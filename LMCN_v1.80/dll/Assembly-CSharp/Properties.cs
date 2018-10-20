using System;
using System.Runtime.InteropServices;

// Token: 0x0200007E RID: 126
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Properties
{
	// Token: 0x0400072F RID: 1839
	[MarshalAs(UnmanagedType.U2)]
	public ushort Propertieskey;

	// Token: 0x04000730 RID: 1840
	[MarshalAs(UnmanagedType.U2)]
	public ushort PropertiesValue;
}
