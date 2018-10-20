using System;
using System.Runtime.InteropServices;

// Token: 0x02000166 RID: 358
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ArenaHeroTopic
{
	// Token: 0x04000E13 RID: 3603
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000E14 RID: 3604
	[MarshalAs(UnmanagedType.U4)]
	public uint Value;
}
