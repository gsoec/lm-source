using System;
using System.Runtime.InteropServices;

// Token: 0x0200079D RID: 1949
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PetSkillLineStyle
{
	// Token: 0x040071B0 RID: 29104
	[MarshalAs(UnmanagedType.U1)]
	public byte R;

	// Token: 0x040071B1 RID: 29105
	[MarshalAs(UnmanagedType.U1)]
	public byte G;

	// Token: 0x040071B2 RID: 29106
	[MarshalAs(UnmanagedType.U1)]
	public byte B;
}
