using System;
using System.Runtime.InteropServices;

// Token: 0x02000792 RID: 1938
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PetTbl
{
	// Token: 0x04007164 RID: 29028
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04007165 RID: 29029
	[MarshalAs(UnmanagedType.U2)]
	public ushort HeroID;

	// Token: 0x04007166 RID: 29030
	[MarshalAs(UnmanagedType.U2)]
	public ushort Name;

	// Token: 0x04007167 RID: 29031
	[MarshalAs(UnmanagedType.U1)]
	public byte TexType;

	// Token: 0x04007168 RID: 29032
	[MarshalAs(UnmanagedType.U1)]
	public byte Rare;

	// Token: 0x04007169 RID: 29033
	[MarshalAs(UnmanagedType.U2)]
	public ushort MapRatio;

	// Token: 0x0400716A RID: 29034
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public _PetRatio[] PetRatio;

	// Token: 0x0400716B RID: 29035
	[MarshalAs(UnmanagedType.U2)]
	public ushort CameraAngle;

	// Token: 0x0400716C RID: 29036
	[MarshalAs(UnmanagedType.U2)]
	public ushort SoulID;

	// Token: 0x0400716D RID: 29037
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public ushort[] PetSkill;

	// Token: 0x0400716E RID: 29038
	[MarshalAs(UnmanagedType.U1)]
	public byte Army;

	// Token: 0x0400716F RID: 29039
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public ushort[] PetAttr;

	// Token: 0x04007170 RID: 29040
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public ushort[] EffectRatio;

	// Token: 0x04007171 RID: 29041
	[MarshalAs(UnmanagedType.Struct)]
	public _PetRatio StartupRatio;

	// Token: 0x04007172 RID: 29042
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public ushort[] Reserve;
}
