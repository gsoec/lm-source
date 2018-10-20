using System;
using System.Runtime.InteropServices;

// Token: 0x020004AF RID: 1199
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Stage
{
	// Token: 0x04004772 RID: 18290
	[MarshalAs(UnmanagedType.U2)]
	public ushort StageKey;

	// Token: 0x04004773 RID: 18291
	[MarshalAs(UnmanagedType.U2)]
	public ushort StageName;

	// Token: 0x04004774 RID: 18292
	[MarshalAs(UnmanagedType.U2)]
	public ushort TalkMan;

	// Token: 0x04004775 RID: 18293
	[MarshalAs(UnmanagedType.U2)]
	public ushort StageDesc;

	// Token: 0x04004776 RID: 18294
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public StageAttribute[] Arrays;
}
