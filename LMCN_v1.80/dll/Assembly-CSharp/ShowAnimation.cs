using System;
using System.Runtime.InteropServices;

// Token: 0x02000266 RID: 614
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ShowAnimation
{
	// Token: 0x0400266C RID: 9836
	[MarshalAs(UnmanagedType.U2)]
	public ushort ShowAnimationID;

	// Token: 0x0400266D RID: 9837
	[MarshalAs(UnmanagedType.U1)]
	public byte AnimationNameID;

	// Token: 0x0400266E RID: 9838
	[MarshalAs(UnmanagedType.U1)]
	public byte WrapModeID;

	// Token: 0x0400266F RID: 9839
	[MarshalAs(UnmanagedType.U2)]
	public ushort AnimationSpeed;

	// Token: 0x04002670 RID: 9840
	[MarshalAs(UnmanagedType.U2)]
	public ushort AnimationTime;
}
