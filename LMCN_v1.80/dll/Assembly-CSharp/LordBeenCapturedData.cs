using System;

// Token: 0x0200015D RID: 349
public struct LordBeenCapturedData
{
	// Token: 0x04000DE0 RID: 3552
	public ushort head;

	// Token: 0x04000DE1 RID: 3553
	public ushort LordLevel;

	// Token: 0x04000DE2 RID: 3554
	public CString name;

	// Token: 0x04000DE3 RID: 3555
	public CString AlliTag;

	// Token: 0x04000DE4 RID: 3556
	public ushort KingdomID;

	// Token: 0x04000DE5 RID: 3557
	public int MapID;

	// Token: 0x04000DE6 RID: 3558
	public uint Bounty;

	// Token: 0x04000DE7 RID: 3559
	public ushort HomeKingdomID;

	// Token: 0x04000DE8 RID: 3560
	public LoadCaptureState nowCaptureStat;

	// Token: 0x04000DE9 RID: 3561
	public PrisonerState prisonerStat;

	// Token: 0x04000DEA RID: 3562
	public long StartActionTime;

	// Token: 0x04000DEB RID: 3563
	public uint TotalTime;

	// Token: 0x04000DEC RID: 3564
	public uint Ransom;

	// Token: 0x04000DED RID: 3565
	public int ReleaseMapID;
}
