using System;
using System.Runtime.InteropServices;

// Token: 0x02000796 RID: 1942
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PetStoneReqTbl
{
	// Token: 0x04007199 RID: 29081
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x0400719A RID: 29082
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public ushort[] StoneReq;
}
