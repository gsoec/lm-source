using System;

// Token: 0x02000152 RID: 338
public struct FS_Detail
{
	// Token: 0x04000D8A RID: 3466
	public FS_Info[] mFS_Info;

	// Token: 0x04000D8B RID: 3467
	public FS_Hero_Info[] mFS_Hero;

	// Token: 0x04000D8C RID: 3468
	public byte HasSeigeData;

	// Token: 0x04000D8D RID: 3469
	public byte TrapsCount;

	// Token: 0x04000D8E RID: 3470
	public ushort TrapsFlag;

	// Token: 0x04000D8F RID: 3471
	public uint[] mTraps_L;

	// Token: 0x04000D90 RID: 3472
	public uint[] mTraps_D;

	// Token: 0x04000D91 RID: 3473
	public uint[] mTraps_S;
}
