using System;
using System.Runtime.InteropServices;

// Token: 0x0200079A RID: 1946
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PetSkillCoolTbl
{
	// Token: 0x040071A9 RID: 29097
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040071AA RID: 29098
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public ushort[] CoolBySkillLv;
}
