using System;
using System.Runtime.InteropServices;

// Token: 0x020000AB RID: 171
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SummonScoreData
{
	// Token: 0x04000866 RID: 2150
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000867 RID: 2151
	[MarshalAs(UnmanagedType.U1)]
	public byte ScoreFactor;

	// Token: 0x04000868 RID: 2152
	[MarshalAs(UnmanagedType.U1)]
	public byte Level;

	// Token: 0x04000869 RID: 2153
	[MarshalAs(UnmanagedType.U4)]
	public uint Score1;

	// Token: 0x0400086A RID: 2154
	[MarshalAs(UnmanagedType.U4)]
	public uint Score2;

	// Token: 0x0400086B RID: 2155
	[MarshalAs(UnmanagedType.U4)]
	public uint Reserve1;

	// Token: 0x0400086C RID: 2156
	[MarshalAs(UnmanagedType.U4)]
	public uint Reserve2;

	// Token: 0x0400086D RID: 2157
	[MarshalAs(UnmanagedType.U4)]
	public uint Reserve3;

	// Token: 0x0400086E RID: 2158
	[MarshalAs(UnmanagedType.U4)]
	public uint Reserve4;
}
