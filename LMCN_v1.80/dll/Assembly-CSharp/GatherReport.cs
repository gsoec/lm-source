using System;
using System.Runtime.InteropServices;

// Token: 0x020000F8 RID: 248
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class GatherReport
{
	// Token: 0x04000B10 RID: 2832
	public uint SerialID;

	// Token: 0x04000B11 RID: 2833
	public GatherReportContent Gather;
}
