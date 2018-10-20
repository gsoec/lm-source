using System;
using System.Runtime.InteropServices;

// Token: 0x020000A9 RID: 169
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MonsterActivityScore
{
	// Token: 0x0400085E RID: 2142
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x0400085F RID: 2143
	[MarshalAs(UnmanagedType.U4)]
	public uint FightPoint;

	// Token: 0x04000860 RID: 2144
	[MarshalAs(UnmanagedType.U4)]
	public uint KillPoint;
}
