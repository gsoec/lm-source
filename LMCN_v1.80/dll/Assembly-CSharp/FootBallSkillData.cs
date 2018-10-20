using System;
using System.Runtime.InteropServices;

// Token: 0x02000359 RID: 857
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct FootBallSkillData
{
	// Token: 0x04003821 RID: 14369
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04003822 RID: 14370
	[MarshalAs(UnmanagedType.U2)]
	public ushort SkillName;

	// Token: 0x04003823 RID: 14371
	[MarshalAs(UnmanagedType.U2)]
	public ushort SkillIcon;

	// Token: 0x04003824 RID: 14372
	[MarshalAs(UnmanagedType.U2)]
	public ushort SkillInfo;

	// Token: 0x04003825 RID: 14373
	[MarshalAs(UnmanagedType.U2)]
	public ushort SkillStrength;

	// Token: 0x04003826 RID: 14374
	[MarshalAs(UnmanagedType.U2)]
	public ushort SkillCountDown;

	// Token: 0x04003827 RID: 14375
	[MarshalAs(UnmanagedType.U2)]
	public ushort NeedSoldierRank;

	// Token: 0x04003828 RID: 14376
	[MarshalAs(UnmanagedType.U4)]
	public uint NeedSoldierQty;

	// Token: 0x04003829 RID: 14377
	[MarshalAs(UnmanagedType.U2)]
	public ushort ParticleNum;

	// Token: 0x0400382A RID: 14378
	[MarshalAs(UnmanagedType.U2)]
	public ushort Particlebag;

	// Token: 0x0400382B RID: 14379
	[MarshalAs(UnmanagedType.U2)]
	public ushort Soundeffects;

	// Token: 0x0400382C RID: 14380
	[MarshalAs(UnmanagedType.U2)]
	public ushort Soundeffectsbag;

	// Token: 0x0400382D RID: 14381
	[MarshalAs(UnmanagedType.U2)]
	public ushort Particleduration;

	// Token: 0x0400382E RID: 14382
	[MarshalAs(UnmanagedType.U2)]
	public ushort Spare1;

	// Token: 0x0400382F RID: 14383
	[MarshalAs(UnmanagedType.U2)]
	public ushort Spare2;
}
