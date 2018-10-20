using System;

// Token: 0x0200014E RID: 334
public struct AllianceHelpRecordCMsgDataType
{
	// Token: 0x04000D70 RID: 3440
	public uint AllianceHelpRecordSN;

	// Token: 0x04000D71 RID: 3441
	public ushort Head;

	// Token: 0x04000D72 RID: 3442
	public AllianceRank Rank;

	// Token: 0x04000D73 RID: 3443
	public string PlayerName;

	// Token: 0x04000D74 RID: 3444
	public EAllianceHelpKind HelpKind;

	// Token: 0x04000D75 RID: 3445
	public ushort EventID;

	// Token: 0x04000D76 RID: 3446
	public byte EventDataLv;

	// Token: 0x04000D77 RID: 3447
	public byte AlreadyHelperNum;

	// Token: 0x04000D78 RID: 3448
	public byte HelpMax;
}
