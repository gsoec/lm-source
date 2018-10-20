using System;
using System.Runtime.InteropServices;

// Token: 0x0200079E RID: 1950
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MapDamageEffTb
{
	// Token: 0x040071B3 RID: 29107
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x040071B4 RID: 29108
	[MarshalAs(UnmanagedType.U2)]
	public ushort RangeTbID;

	// Token: 0x040071B5 RID: 29109
	[MarshalAs(UnmanagedType.U1)]
	public byte CrossID;

	// Token: 0x040071B6 RID: 29110
	[MarshalAs(UnmanagedType.U2)]
	public ushort BeginID;

	// Token: 0x040071B7 RID: 29111
	[MarshalAs(UnmanagedType.U2)]
	public ushort AttackID;

	// Token: 0x040071B8 RID: 29112
	[MarshalAs(UnmanagedType.U2)]
	public ushort EndID;

	// Token: 0x040071B9 RID: 29113
	[MarshalAs(UnmanagedType.U2)]
	public ushort PaltformKey;

	// Token: 0x040071BA RID: 29114
	[MarshalAs(UnmanagedType.U2)]
	public ushort FireSound;

	// Token: 0x040071BB RID: 29115
	[MarshalAs(UnmanagedType.U2)]
	public ushort FireParticle;

	// Token: 0x040071BC RID: 29116
	[MarshalAs(UnmanagedType.U2)]
	public ushort FireParticleDuring;

	// Token: 0x040071BD RID: 29117
	[MarshalAs(UnmanagedType.U2)]
	public ushort HitSound;

	// Token: 0x040071BE RID: 29118
	[MarshalAs(UnmanagedType.U2)]
	public ushort HitParticle;

	// Token: 0x040071BF RID: 29119
	[MarshalAs(UnmanagedType.U2)]
	public ushort HitParticleDuring;

	// Token: 0x040071C0 RID: 29120
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public PetSkillLineStyle[] LineStyle;

	// Token: 0x040071C1 RID: 29121
	[MarshalAs(UnmanagedType.U2)]
	public ushort ParticlePakNO;

	// Token: 0x040071C2 RID: 29122
	[MarshalAs(UnmanagedType.U2)]
	public ushort SoundPakNO;
}
