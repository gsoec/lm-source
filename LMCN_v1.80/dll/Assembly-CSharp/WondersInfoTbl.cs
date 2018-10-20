using System;
using System.Runtime.InteropServices;

// Token: 0x0200023B RID: 571
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct WondersInfoTbl
{
	// Token: 0x040022A2 RID: 8866
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040022A3 RID: 8867
	[MarshalAs(UnmanagedType.U2)]
	public ushort NameID;

	// Token: 0x040022A4 RID: 8868
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public WondersEffect[] Effect;
}
