using System;
using System.Runtime.InteropServices;

// Token: 0x02000267 RID: 615
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ShowLight
{
	// Token: 0x04002671 RID: 9841
	[MarshalAs(UnmanagedType.U2)]
	public ushort ShowLightID;

	// Token: 0x04002672 RID: 9842
	[MarshalAs(UnmanagedType.U1)]
	public byte ShowLightType;

	// Token: 0x04002673 RID: 9843
	[MarshalAs(UnmanagedType.U2)]
	public ushort ShowLightIntensity;
}
