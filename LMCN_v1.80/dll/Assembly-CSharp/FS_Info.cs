using System;

// Token: 0x02000150 RID: 336
public struct FS_Info
{
	// Token: 0x04000D7E RID: 3454
	public CString Name;

	// Token: 0x04000D7F RID: 3455
	public uint Troops;

	// Token: 0x04000D80 RID: 3456
	public uint Traps;

	// Token: 0x04000D81 RID: 3457
	public byte TroopsCount;

	// Token: 0x04000D82 RID: 3458
	public ushort TroopsFlag;

	// Token: 0x04000D83 RID: 3459
	public uint[] Troops_L;

	// Token: 0x04000D84 RID: 3460
	public uint[] Troops_D;

	// Token: 0x04000D85 RID: 3461
	public uint[] Troops_H;
}
