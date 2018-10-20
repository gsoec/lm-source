using System;
using System.Runtime.InteropServices;

// Token: 0x02000795 RID: 1941
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PetSkillExpTbl
{
	// Token: 0x04007197 RID: 29079
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04007198 RID: 29080
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public uint[] ExpValue;
}
