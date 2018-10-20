using System;
using System.Runtime.InteropServices;

// Token: 0x020000C8 RID: 200
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LordEquipExtendData
{
	// Token: 0x04000927 RID: 2343
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000928 RID: 2344
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public SyntheticExtend[] SyntheticParts;

	// Token: 0x04000929 RID: 2345
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public Properties[] PropertiesInfo;

	// Token: 0x0400092A RID: 2346
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public ushort[] Ube;
}
