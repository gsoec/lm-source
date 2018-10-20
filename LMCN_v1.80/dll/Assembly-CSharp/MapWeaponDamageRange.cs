using System;
using System.Runtime.InteropServices;

// Token: 0x0200022E RID: 558
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MapWeaponDamageRange
{
	// Token: 0x04002240 RID: 8768
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04002241 RID: 8769
	[MarshalAs(UnmanagedType.U1)]
	public byte OffSetX;

	// Token: 0x04002242 RID: 8770
	[MarshalAs(UnmanagedType.U1)]
	public byte OffSetY;

	// Token: 0x04002243 RID: 8771
	[MarshalAs(UnmanagedType.U1)]
	public byte MarkID;

	// Token: 0x04002244 RID: 8772
	[MarshalAs(UnmanagedType.U1)]
	public byte ColorR;

	// Token: 0x04002245 RID: 8773
	[MarshalAs(UnmanagedType.U1)]
	public byte ColorG;

	// Token: 0x04002246 RID: 8774
	[MarshalAs(UnmanagedType.U1)]
	public byte ColorB;

	// Token: 0x04002247 RID: 8775
	[MarshalAs(UnmanagedType.U2)]
	public ushort NextID;

	// Token: 0x04002248 RID: 8776
	[MarshalAs(UnmanagedType.U2)]
	public ushort KeepOne;

	// Token: 0x04002249 RID: 8777
	[MarshalAs(UnmanagedType.U2)]
	public ushort KeepTwo;

	// Token: 0x0400224A RID: 8778
	[MarshalAs(UnmanagedType.U2)]
	public ushort KeepThree;

	// Token: 0x0400224B RID: 8779
	[MarshalAs(UnmanagedType.U2)]
	public ushort KeepFour;

	// Token: 0x0400224C RID: 8780
	[MarshalAs(UnmanagedType.U2)]
	public ushort KeepFive;

	// Token: 0x0400224D RID: 8781
	[MarshalAs(UnmanagedType.U2)]
	public ushort KeepSix;

	// Token: 0x0400224E RID: 8782
	[MarshalAs(UnmanagedType.U2)]
	public ushort KeepSeven;

	// Token: 0x0400224F RID: 8783
	[MarshalAs(UnmanagedType.U2)]
	public ushort KeepEight;
}
