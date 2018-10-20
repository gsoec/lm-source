using System;
using System.Runtime.InteropServices;

// Token: 0x0200007C RID: 124
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Buff
{
	// Token: 0x0400071F RID: 1823
	[MarshalAs(UnmanagedType.U2)]
	public ushort BuffKey;

	// Token: 0x04000720 RID: 1824
	[MarshalAs(UnmanagedType.U1)]
	public byte StateBehavior;

	// Token: 0x04000721 RID: 1825
	[MarshalAs(UnmanagedType.U1)]
	public byte EffectNumber;

	// Token: 0x04000722 RID: 1826
	[MarshalAs(UnmanagedType.U2)]
	public ushort Length;

	// Token: 0x04000723 RID: 1827
	[MarshalAs(UnmanagedType.U2)]
	public ushort StepTime;

	// Token: 0x04000724 RID: 1828
	[MarshalAs(UnmanagedType.U1)]
	public byte SpecialEffects;

	// Token: 0x04000725 RID: 1829
	[MarshalAs(UnmanagedType.U2)]
	public ushort SpecialEffectValue;

	// Token: 0x04000726 RID: 1830
	[MarshalAs(UnmanagedType.U1)]
	public byte ReplaceGroups;

	// Token: 0x04000727 RID: 1831
	[MarshalAs(UnmanagedType.U1)]
	public byte ReplaceOrder;

	// Token: 0x04000728 RID: 1832
	[MarshalAs(UnmanagedType.U2)]
	public ushort Particle;

	// Token: 0x04000729 RID: 1833
	[MarshalAs(UnmanagedType.U1)]
	public byte ParticlePos;

	// Token: 0x0400072A RID: 1834
	[MarshalAs(UnmanagedType.U2)]
	public ushort HitParticle;

	// Token: 0x0400072B RID: 1835
	[MarshalAs(UnmanagedType.U1)]
	public byte ColorModify;

	// Token: 0x0400072C RID: 1836
	[MarshalAs(UnmanagedType.U1)]
	public byte FaceCamera;
}
