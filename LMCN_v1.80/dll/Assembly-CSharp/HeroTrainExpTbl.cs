using System;
using System.Runtime.InteropServices;

// Token: 0x02000797 RID: 1943
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HeroTrainExpTbl
{
	// Token: 0x0400719B RID: 29083
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x0400719C RID: 29084
	[MarshalAs(UnmanagedType.U2)]
	public ushort PetEep;

	// Token: 0x0400719D RID: 29085
	[MarshalAs(UnmanagedType.U2)]
	public ushort PetSkillExp;
}
