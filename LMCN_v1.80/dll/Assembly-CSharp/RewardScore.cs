using System;
using System.Runtime.InteropServices;

// Token: 0x02000085 RID: 133
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct RewardScore
{
	// Token: 0x04000756 RID: 1878
	[MarshalAs(UnmanagedType.U2)]
	public ushort RewardScoreKey;

	// Token: 0x04000757 RID: 1879
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
	public ushort[] Rewards;
}
