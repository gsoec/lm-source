using System;
using System.Runtime.InteropServices;

// Token: 0x02000078 RID: 120
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HeroAttack
{
	// Token: 0x040006BA RID: 1722
	[MarshalAs(UnmanagedType.U2)]
	public ushort AttackAnimation;

	// Token: 0x040006BB RID: 1723
	[MarshalAs(UnmanagedType.U2)]
	public ushort AnimationTime;

	// Token: 0x040006BC RID: 1724
	[MarshalAs(UnmanagedType.U2)]
	public ushort HitTime;
}
