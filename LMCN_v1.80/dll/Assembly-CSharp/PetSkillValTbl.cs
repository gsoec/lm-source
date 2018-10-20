using System;
using System.Runtime.InteropServices;

// Token: 0x02000799 RID: 1945
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PetSkillValTbl
{
	// Token: 0x040071A6 RID: 29094
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040071A7 RID: 29095
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public uint[] EffectBySkillLv;

	// Token: 0x040071A8 RID: 29096
	[MarshalAs(UnmanagedType.U1)]
	public byte Unit;
}
