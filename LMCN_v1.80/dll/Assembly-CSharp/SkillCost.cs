using System;
using System.Runtime.InteropServices;

// Token: 0x02000087 RID: 135
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SkillCost
{
	// Token: 0x04000760 RID: 1888
	[MarshalAs(UnmanagedType.U2)]
	public ushort SkillCostKey;

	// Token: 0x04000761 RID: 1889
	[MarshalAs(UnmanagedType.U1)]
	public byte SkillCostValue;
}
