using System;
using System.Runtime.InteropServices;

// Token: 0x0200022B RID: 555
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MapTeam
{
	// Token: 0x0400222D RID: 8749
	[MarshalAs(UnmanagedType.U2)]
	public ushort TeamID;

	// Token: 0x0400222E RID: 8750
	[MarshalAs(UnmanagedType.U2)]
	public ushort ItemGroup;

	// Token: 0x0400222F RID: 8751
	[MarshalAs(UnmanagedType.U2)]
	public ushort AllianceItem;
}
