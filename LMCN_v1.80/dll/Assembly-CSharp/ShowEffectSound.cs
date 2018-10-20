using System;
using System.Runtime.InteropServices;

// Token: 0x02000269 RID: 617
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ShowEffectSound
{
	// Token: 0x04002679 RID: 9849
	[MarshalAs(UnmanagedType.U2)]
	public ushort ShowEffectSoundID;

	// Token: 0x0400267A RID: 9850
	[MarshalAs(UnmanagedType.U4)]
	public uint EffectSoundID;

	// Token: 0x0400267B RID: 9851
	[MarshalAs(UnmanagedType.U1)]
	public byte AttackMode;
}
