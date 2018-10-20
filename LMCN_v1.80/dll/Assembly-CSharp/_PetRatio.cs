using System;
using System.Runtime.InteropServices;

// Token: 0x02000791 RID: 1937
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct _PetRatio
{
	// Token: 0x04007162 RID: 29026
	[MarshalAs(UnmanagedType.U2)]
	public ushort Ratio;

	// Token: 0x04007163 RID: 29027
	[MarshalAs(UnmanagedType.U2)]
	public ushort UpDownDist;
}
