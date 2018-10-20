using System;

// Token: 0x020000DB RID: 219
[Serializable]
public struct MailBox
{
	// Token: 0x040009E3 RID: 2531
	public MailType Type;

	// Token: 0x040009E4 RID: 2532
	public MailType Kind;

	// Token: 0x040009E5 RID: 2533
	public uint Serial;

	// Token: 0x040009E6 RID: 2534
	public long Timing;

	// Token: 0x040009E7 RID: 2535
	public bool Change;

	// Token: 0x040009E8 RID: 2536
	public bool Check;

	// Token: 0x040009E9 RID: 2537
	public bool Read;

	// Token: 0x040009EA RID: 2538
	public byte Flag;
}
