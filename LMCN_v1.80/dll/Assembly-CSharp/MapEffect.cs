using System;
using System.Runtime.InteropServices;

// Token: 0x0200016E RID: 366
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MapEffect
{
	// Token: 0x04000E30 RID: 3632
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000E31 RID: 3633
	[MarshalAs(UnmanagedType.U2)]
	public ushort EffectID;

	// Token: 0x04000E32 RID: 3634
	[MarshalAs(UnmanagedType.U4)]
	public uint PosX;

	// Token: 0x04000E33 RID: 3635
	[MarshalAs(UnmanagedType.U1)]
	public byte PosX_Sign;

	// Token: 0x04000E34 RID: 3636
	[MarshalAs(UnmanagedType.U4)]
	public uint PosY;

	// Token: 0x04000E35 RID: 3637
	[MarshalAs(UnmanagedType.U1)]
	public byte PosY_Sign;

	// Token: 0x04000E36 RID: 3638
	[MarshalAs(UnmanagedType.U4)]
	public uint PosZ;

	// Token: 0x04000E37 RID: 3639
	[MarshalAs(UnmanagedType.U1)]
	public byte PosZ_Sign;
}
