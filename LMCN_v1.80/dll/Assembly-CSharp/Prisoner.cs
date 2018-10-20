using System;

// Token: 0x0200015C RID: 348
public struct Prisoner
{
	// Token: 0x04000DD7 RID: 3543
	public ushort head;

	// Token: 0x04000DD8 RID: 3544
	public byte LordLevel;

	// Token: 0x04000DD9 RID: 3545
	public CString name;

	// Token: 0x04000DDA RID: 3546
	public CString AlliTag;

	// Token: 0x04000DDB RID: 3547
	public ushort KingdomID;

	// Token: 0x04000DDC RID: 3548
	public PrisonerState nowStat;

	// Token: 0x04000DDD RID: 3549
	public long StartActionTime;

	// Token: 0x04000DDE RID: 3550
	public uint TotalTime;

	// Token: 0x04000DDF RID: 3551
	public uint Ransom;
}
