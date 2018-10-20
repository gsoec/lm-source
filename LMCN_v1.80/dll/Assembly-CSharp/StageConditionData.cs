using System;
using System.Runtime.InteropServices;

// Token: 0x020004B7 RID: 1207
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct StageConditionData
{
	// Token: 0x040047A7 RID: 18343
	[MarshalAs(UnmanagedType.U2)]
	public ushort ConditionKey;

	// Token: 0x040047A8 RID: 18344
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public StageCondition[] ConditionArray;
}
