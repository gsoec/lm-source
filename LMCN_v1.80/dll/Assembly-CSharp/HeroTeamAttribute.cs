using System;
using System.Runtime.InteropServices;

// Token: 0x02000083 RID: 131
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HeroTeamAttribute
{
	// Token: 0x0400074B RID: 1867
	[MarshalAs(UnmanagedType.U1)]
	public byte Type;

	// Token: 0x0400074C RID: 1868
	[MarshalAs(UnmanagedType.U2)]
	public ushort Hero;
}
