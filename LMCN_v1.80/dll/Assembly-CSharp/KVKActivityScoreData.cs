using System;
using System.Runtime.InteropServices;

// Token: 0x020000AA RID: 170
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct KVKActivityScoreData
{
	// Token: 0x04000861 RID: 2145
	[MarshalAs(UnmanagedType.U2)]
	public ushort ID;

	// Token: 0x04000862 RID: 2146
	[MarshalAs(UnmanagedType.U1)]
	public byte ScoreFactor;

	// Token: 0x04000863 RID: 2147
	[MarshalAs(UnmanagedType.U1)]
	public byte Level;

	// Token: 0x04000864 RID: 2148
	[MarshalAs(UnmanagedType.U4)]
	public uint Score1;

	// Token: 0x04000865 RID: 2149
	[MarshalAs(UnmanagedType.U4)]
	public uint Score2;
}
