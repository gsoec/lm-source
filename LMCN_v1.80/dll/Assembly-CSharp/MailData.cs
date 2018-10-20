using System;

// Token: 0x020000D2 RID: 210
[Serializable]
public struct MailData
{
	// Token: 0x04000977 RID: 2423
	public uint Total;

	// Token: 0x04000978 RID: 2424
	public uint Unread;

	// Token: 0x04000979 RID: 2425
	public uint MaxSerial;

	// Token: 0x0400097A RID: 2426
	public uint NewSerial;

	// Token: 0x0400097B RID: 2427
	public uint ReportTotal;

	// Token: 0x0400097C RID: 2428
	public uint ReportUnread;

	// Token: 0x0400097D RID: 2429
	public uint ReportMaxSerial;

	// Token: 0x0400097E RID: 2430
	public uint ReportNewSerial;

	// Token: 0x0400097F RID: 2431
	public uint ReportOldSerial;

	// Token: 0x04000980 RID: 2432
	public MailSerial MailSerial;

	// Token: 0x04000981 RID: 2433
	public FavorSerial FavorSerial;

	// Token: 0x04000982 RID: 2434
	public ReportSerial ReportSerial;

	// Token: 0x04000983 RID: 2435
	public SystemSerial SystemSerial;

	// Token: 0x04000984 RID: 2436
	public uint MailPacksize;

	// Token: 0x04000985 RID: 2437
	public ushort MyFavorite;

	// Token: 0x04000986 RID: 2438
	public long UserId;

	// Token: 0x04000987 RID: 2439
	public bool Loaded;

	// Token: 0x04000988 RID: 2440
	public bool Failed;

	// Token: 0x04000989 RID: 2441
	public bool Refresh;

	// Token: 0x0400098A RID: 2442
	public long Caliber;

	// Token: 0x0400098B RID: 2443
	public MailSave Flag;
}
