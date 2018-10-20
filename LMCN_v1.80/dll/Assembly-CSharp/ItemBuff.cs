using System;
using System.Runtime.InteropServices;

// Token: 0x02000153 RID: 339
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ItemBuff
{
	// Token: 0x04000D92 RID: 3474
	[MarshalAs(UnmanagedType.U2)]
	public ushort BuffID;

	// Token: 0x04000D93 RID: 3475
	[MarshalAs(UnmanagedType.U1)]
	public byte BuffKind;

	// Token: 0x04000D94 RID: 3476
	[MarshalAs(UnmanagedType.U2)]
	public ushort BuffItemID;

	// Token: 0x04000D95 RID: 3477
	[MarshalAs(UnmanagedType.U2)]
	public ushort IconID;

	// Token: 0x04000D96 RID: 3478
	[MarshalAs(UnmanagedType.U2)]
	public ushort BuffNameID;

	// Token: 0x04000D97 RID: 3479
	[MarshalAs(UnmanagedType.U2)]
	public ushort BuffInfoID;

	// Token: 0x04000D98 RID: 3480
	[MarshalAs(UnmanagedType.U2)]
	public ushort BuffTipID;
}
