using System;
using System.Runtime.InteropServices;

// Token: 0x0200022A RID: 554
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct KingdomMap
{
	// Token: 0x04002228 RID: 8744
	[MarshalAs(UnmanagedType.U2)]
	public ushort KingdomMapKey;

	// Token: 0x04002229 RID: 8745
	[MarshalAs(UnmanagedType.U1)]
	public byte mapID;

	// Token: 0x0400222A RID: 8746
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
	public char[] kingdomName;

	// Token: 0x0400222B RID: 8747
	[MarshalAs(UnmanagedType.U2)]
	public ushort worldPosX;

	// Token: 0x0400222C RID: 8748
	[MarshalAs(UnmanagedType.U2)]
	public ushort worldPosY;
}
