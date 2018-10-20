using System;
using System.Runtime.InteropServices;

// Token: 0x02000793 RID: 1939
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PetExpTbl
{
	// Token: 0x04007173 RID: 29043
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04007174 RID: 29044
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
	public uint[] ExpValue;
}
