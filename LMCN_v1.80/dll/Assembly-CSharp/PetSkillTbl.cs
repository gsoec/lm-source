using System;
using System.Runtime.InteropServices;

// Token: 0x02000794 RID: 1940
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PetSkillTbl
{
	// Token: 0x04007175 RID: 29045
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04007176 RID: 29046
	[MarshalAs(UnmanagedType.U2)]
	public ushort Name;

	// Token: 0x04007177 RID: 29047
	[MarshalAs(UnmanagedType.U2)]
	public ushort Icon;

	// Token: 0x04007178 RID: 29048
	[MarshalAs(UnmanagedType.U2)]
	public ushort Effect1;

	// Token: 0x04007179 RID: 29049
	[MarshalAs(UnmanagedType.U2)]
	public ushort Effect2;

	// Token: 0x0400717A RID: 29050
	[MarshalAs(UnmanagedType.U2)]
	public ushort Effect3;

	// Token: 0x0400717B RID: 29051
	[MarshalAs(UnmanagedType.U2)]
	public ushort Status;

	// Token: 0x0400717C RID: 29052
	[MarshalAs(UnmanagedType.U1)]
	public byte Type;

	// Token: 0x0400717D RID: 29053
	[MarshalAs(UnmanagedType.U1)]
	public byte Kind;

	// Token: 0x0400717E RID: 29054
	[MarshalAs(UnmanagedType.U1)]
	public byte Subject;

	// Token: 0x0400717F RID: 29055
	[MarshalAs(UnmanagedType.U1)]
	public byte Class;

	// Token: 0x04007180 RID: 29056
	[MarshalAs(UnmanagedType.U1)]
	public byte UpLevel;

	// Token: 0x04007181 RID: 29057
	[MarshalAs(UnmanagedType.U2)]
	public ushort Diamond;

	// Token: 0x04007182 RID: 29058
	[MarshalAs(UnmanagedType.U1)]
	public byte ShowReport;

	// Token: 0x04007183 RID: 29059
	[MarshalAs(UnmanagedType.U2)]
	public ushort ZValue;

	// Token: 0x04007184 RID: 29060
	[MarshalAs(UnmanagedType.U2)]
	public ushort XValue;

	// Token: 0x04007185 RID: 29061
	[MarshalAs(UnmanagedType.U2)]
	public ushort YValue;

	// Token: 0x04007186 RID: 29062
	[MarshalAs(UnmanagedType.U2)]
	public ushort AValue;

	// Token: 0x04007187 RID: 29063
	[MarshalAs(UnmanagedType.U2)]
	public ushort BValue;

	// Token: 0x04007188 RID: 29064
	[MarshalAs(UnmanagedType.U2)]
	public ushort CValue;

	// Token: 0x04007189 RID: 29065
	[MarshalAs(UnmanagedType.U2)]
	public ushort DValue;

	// Token: 0x0400718A RID: 29066
	[MarshalAs(UnmanagedType.U2)]
	public ushort CoolDown;

	// Token: 0x0400718B RID: 29067
	[MarshalAs(UnmanagedType.U2)]
	public ushort Fatigue;

	// Token: 0x0400718C RID: 29068
	[MarshalAs(UnmanagedType.U2)]
	public ushort Experience;

	// Token: 0x0400718D RID: 29069
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
	public byte[] OpenLevel;

	// Token: 0x0400718E RID: 29070
	[MarshalAs(UnmanagedType.U2)]
	public ushort DamageRange;

	// Token: 0x0400718F RID: 29071
	[MarshalAs(UnmanagedType.U2)]
	public ushort HitSound;

	// Token: 0x04007190 RID: 29072
	[MarshalAs(UnmanagedType.U2)]
	public ushort FlyParticle;

	// Token: 0x04007191 RID: 29073
	[MarshalAs(UnmanagedType.U2)]
	public ushort FlySound;

	// Token: 0x04007192 RID: 29074
	[MarshalAs(UnmanagedType.U2)]
	public ushort SoundNo;

	// Token: 0x04007193 RID: 29075
	[MarshalAs(UnmanagedType.U2)]
	public ushort EffectTime;

	// Token: 0x04007194 RID: 29076
	[MarshalAs(UnmanagedType.U2)]
	public ushort Reserved1;

	// Token: 0x04007195 RID: 29077
	[MarshalAs(UnmanagedType.U2)]
	public ushort Reserved2;

	// Token: 0x04007196 RID: 29078
	[MarshalAs(UnmanagedType.U2)]
	public ushort Reserved3;
}
