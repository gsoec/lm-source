using System;
using System.Runtime.InteropServices;

// Token: 0x0200023F RID: 575
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct YolkDeploy
{
	// Token: 0x040022C4 RID: 8900
	[MarshalAs(UnmanagedType.U2)]
	public ushort YolkDeployID;

	// Token: 0x040022C5 RID: 8901
	[MarshalAs(UnmanagedType.U2)]
	public ushort YolkNameID;

	// Token: 0x040022C6 RID: 8902
	[MarshalAs(UnmanagedType.U2)]
	public ushort posX;

	// Token: 0x040022C7 RID: 8903
	[MarshalAs(UnmanagedType.U2)]
	public ushort posY;

	// Token: 0x040022C8 RID: 8904
	[MarshalAs(UnmanagedType.U2)]
	public ushort iconID;

	// Token: 0x040022C9 RID: 8905
	[MarshalAs(UnmanagedType.U2)]
	public ushort AllianceIconHeight;

	// Token: 0x040022CA RID: 8906
	[MarshalAs(UnmanagedType.U2)]
	public ushort temptwo;

	// Token: 0x040022CB RID: 8907
	[MarshalAs(UnmanagedType.U1)]
	public byte tempthree;

	// Token: 0x040022CC RID: 8908
	[MarshalAs(UnmanagedType.U1)]
	public byte tempfour;
}
