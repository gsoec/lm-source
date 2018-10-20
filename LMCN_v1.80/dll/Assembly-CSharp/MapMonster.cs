using System;
using System.Runtime.InteropServices;

// Token: 0x0200022C RID: 556
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MapMonster
{
	// Token: 0x04002230 RID: 8752
	[MarshalAs(UnmanagedType.U2)]
	public ushort Index;

	// Token: 0x04002231 RID: 8753
	[MarshalAs(UnmanagedType.U2)]
	public ushort ModelID;

	// Token: 0x04002232 RID: 8754
	[MarshalAs(UnmanagedType.U1)]
	public byte HitFrame;

	// Token: 0x04002233 RID: 8755
	[MarshalAs(UnmanagedType.U2)]
	public ushort NameID;

	// Token: 0x04002234 RID: 8756
	[MarshalAs(UnmanagedType.U2)]
	public ushort Xoffset;

	// Token: 0x04002235 RID: 8757
	[MarshalAs(UnmanagedType.U2)]
	public ushort Yoffset;

	// Token: 0x04002236 RID: 8758
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public ushort[] Content;

	// Token: 0x04002237 RID: 8759
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public MapTeam[] MapTeamInfo;

	// Token: 0x04002238 RID: 8760
	[MarshalAs(UnmanagedType.U2)]
	public ushort CameraHeight;

	// Token: 0x04002239 RID: 8761
	[MarshalAs(UnmanagedType.U2)]
	public ushort StageID;

	// Token: 0x0400223A RID: 8762
	[MarshalAs(UnmanagedType.U2)]
	public ushort ParticlePackNO;

	// Token: 0x0400223B RID: 8763
	[MarshalAs(UnmanagedType.U2)]
	public ushort SoundPackNO;

	// Token: 0x0400223C RID: 8764
	[MarshalAs(UnmanagedType.U2)]
	public ushort MapNPCNO;
}
