using System;
using System.Runtime.InteropServices;

// Token: 0x020004B4 RID: 1204
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CorpsStageBattle
{
	// Token: 0x0400479C RID: 18332
	[MarshalAs(UnmanagedType.U2)]
	public ushort CorpsStageBattleKey;

	// Token: 0x0400479D RID: 18333
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public Properties[] PropertiesInfo;

	// Token: 0x0400479E RID: 18334
	[MarshalAs(UnmanagedType.U1)]
	public byte WallLevel;

	// Token: 0x0400479F RID: 18335
	[MarshalAs(UnmanagedType.U4)]
	public uint MaxWall;

	// Token: 0x040047A0 RID: 18336
	[MarshalAs(UnmanagedType.U1)]
	public byte Terrain;

	// Token: 0x040047A1 RID: 18337
	[MarshalAs(UnmanagedType.U1)]
	public byte Weather;
}
