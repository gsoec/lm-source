using System;
using System.Runtime.InteropServices;

// Token: 0x02000171 RID: 369
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SpecialEffect
{
	// Token: 0x04000E41 RID: 3649
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000E42 RID: 3650
	[MarshalAs(UnmanagedType.U1)]
	public byte NewGemEffectID;

	// Token: 0x04000E43 RID: 3651
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public ushort[] ColorEffect;

	// Token: 0x04000E44 RID: 3652
	[MarshalAs(UnmanagedType.U1)]
	public byte DescType;

	// Token: 0x04000E45 RID: 3653
	[MarshalAs(UnmanagedType.U2)]
	public ushort DescStringID;

	// Token: 0x04000E46 RID: 3654
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public ushort[] Ube;
}
