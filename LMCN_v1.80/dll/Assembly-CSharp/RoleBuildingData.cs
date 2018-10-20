using System;
using System.Runtime.InteropServices;

// Token: 0x0200033F RID: 831
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct RoleBuildingData
{
	// Token: 0x060010E7 RID: 4327 RVA: 0x001E265C File Offset: 0x001E085C
	public RoleBuildingData(ushort _ManorID, ushort _BuildID, byte _Level)
	{
		this.ManorID = _ManorID;
		this.BuildID = _BuildID;
		this.Level = _Level;
	}

	// Token: 0x0400372C RID: 14124
	public ushort ManorID;

	// Token: 0x0400372D RID: 14125
	public ushort BuildID;

	// Token: 0x0400372E RID: 14126
	public byte Level;
}
