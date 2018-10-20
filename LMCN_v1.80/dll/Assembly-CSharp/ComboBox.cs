using System;
using System.Runtime.InteropServices;

// Token: 0x020000A4 RID: 164
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ComboBox
{
	// Token: 0x04000851 RID: 2129
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000852 RID: 2130
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	public ComboBoxItem[] ItemData;

	// Token: 0x04000853 RID: 2131
	[MarshalAs(UnmanagedType.U2)]
	public ushort SetIndex;
}
