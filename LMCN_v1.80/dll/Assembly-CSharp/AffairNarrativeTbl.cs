using System;
using System.Runtime.InteropServices;

// Token: 0x020003D4 RID: 980
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AffairNarrativeTbl
{
	// Token: 0x04003D0A RID: 15626
	[MarshalAs(UnmanagedType.U2)]
	public ushort MissionID;

	// Token: 0x04003D0B RID: 15627
	[MarshalAs(UnmanagedType.U1)]
	public byte Quality;

	// Token: 0x04003D0C RID: 15628
	[MarshalAs(UnmanagedType.U2)]
	public ushort Narrative;

	// Token: 0x04003D0D RID: 15629
	[MarshalAs(UnmanagedType.U2)]
	public ushort TotalTime;
}
