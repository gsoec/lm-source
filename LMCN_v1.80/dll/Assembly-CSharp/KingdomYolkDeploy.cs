using System;
using System.Runtime.InteropServices;

// Token: 0x0200023E RID: 574
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct KingdomYolkDeploy
{
	// Token: 0x040022C1 RID: 8897
	[MarshalAs(UnmanagedType.U2)]
	public ushort KingdomYolkDeployID;

	// Token: 0x040022C2 RID: 8898
	[MarshalAs(UnmanagedType.U2)]
	public ushort kingdomID;

	// Token: 0x040022C3 RID: 8899
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	public ushort[] yolkDeployIDs;
}
