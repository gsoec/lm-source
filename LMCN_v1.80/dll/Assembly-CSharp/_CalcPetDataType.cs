using System;
using System.Runtime.InteropServices;

// Token: 0x0200079B RID: 1947
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct _CalcPetDataType
{
	// Token: 0x040071AB RID: 29099
	public ushort PetID;

	// Token: 0x040071AC RID: 29100
	public byte Star;

	// Token: 0x040071AD RID: 29101
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] SkillLV;
}
