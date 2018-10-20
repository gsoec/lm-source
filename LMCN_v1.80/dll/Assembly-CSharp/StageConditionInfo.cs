using System;
using System.Runtime.InteropServices;

// Token: 0x020004B8 RID: 1208
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct StageConditionInfo
{
	// Token: 0x040047A9 RID: 18345
	[MarshalAs(UnmanagedType.U2)]
	public ushort ConditionID;

	// Token: 0x040047AA RID: 18346
	[MarshalAs(UnmanagedType.U1)]
	public byte Type;

	// Token: 0x040047AB RID: 18347
	[MarshalAs(UnmanagedType.U1)]
	public byte PicType;

	// Token: 0x040047AC RID: 18348
	[MarshalAs(UnmanagedType.U1)]
	public byte PicNo;
}
