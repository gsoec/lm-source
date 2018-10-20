using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// Token: 0x020000D8 RID: 216
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class SerialContent
{
	// Token: 0x060002D2 RID: 722 RVA: 0x00027708 File Offset: 0x00025908
	public void Clear()
	{
		this.New = (this.Count = (this.Last = 0u));
		this.Old = (this.Change = (this.Fetch = 0u));
		Array.Clear(this.Inbox, 0, this.Inbox.Length);
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x0002775C File Offset: 0x0002595C
	public void Sort()
	{
		if (this.Count > 0u)
		{
			this.Change = 0u;
			Array.Sort<MailBox>(this.Inbox, DataManager.MailDC);
		}
	}

	// Token: 0x040009BA RID: 2490
	public long Timing;

	// Token: 0x040009BB RID: 2491
	public uint Unread;

	// Token: 0x040009BC RID: 2492
	public uint Unseen;

	// Token: 0x040009BD RID: 2493
	public uint Select;

	// Token: 0x040009BE RID: 2494
	public uint Total;

	// Token: 0x040009BF RID: 2495
	public uint Count;

	// Token: 0x040009C0 RID: 2496
	public uint Max;

	// Token: 0x040009C1 RID: 2497
	public uint New;

	// Token: 0x040009C2 RID: 2498
	public uint Old;

	// Token: 0x040009C3 RID: 2499
	public uint Last;

	// Token: 0x040009C4 RID: 2500
	public uint Fetch;

	// Token: 0x040009C5 RID: 2501
	public uint Purge;

	// Token: 0x040009C6 RID: 2502
	public uint Change;

	// Token: 0x040009C7 RID: 2503
	public bool Pulling;

	// Token: 0x040009C8 RID: 2504
	public bool Parsing;

	// Token: 0x040009C9 RID: 2505
	public bool Holding;

	// Token: 0x040009CA RID: 2506
	public bool Loading;

	// Token: 0x040009CB RID: 2507
	public bool Initial;

	// Token: 0x040009CC RID: 2508
	public bool Bulking;

	// Token: 0x040009CD RID: 2509
	public bool Metalog;

	// Token: 0x040009CE RID: 2510
	public bool Infolog;

	// Token: 0x040009CF RID: 2511
	public bool Disavow;

	// Token: 0x040009D0 RID: 2512
	public uint OldSave;

	// Token: 0x040009D1 RID: 2513
	public uint NewSave;

	// Token: 0x040009D2 RID: 2514
	public uint MaxSave;

	// Token: 0x040009D3 RID: 2515
	public uint LastSave;

	// Token: 0x040009D4 RID: 2516
	public uint HoldSave;

	// Token: 0x040009D5 RID: 2517
	public uint FetchSave;

	// Token: 0x040009D6 RID: 2518
	public uint TotalSave;

	// Token: 0x040009D7 RID: 2519
	public uint CountSave;

	// Token: 0x040009D8 RID: 2520
	public uint UnreadSave;

	// Token: 0x040009D9 RID: 2521
	public MailBox[] Inbox;

	// Token: 0x040009DA RID: 2522
	public List<uint> Caliber;

	// Token: 0x040009DB RID: 2523
	public CHashTable<uint, SerialBox> SID = new CHashTable<uint, SerialBox>(400, true);

	// Token: 0x040009DC RID: 2524
	public SerialBox[] Serial;

	// Token: 0x040009DD RID: 2525
	public Dictionary<uint, SerialBox> Matrix = new Dictionary<uint, SerialBox>();

	// Token: 0x040009DE RID: 2526
	public Dictionary<uint, SerialBox> Temp = new Dictionary<uint, SerialBox>();

	// Token: 0x040009DF RID: 2527
	public uint SerialNumber;

	// Token: 0x040009E0 RID: 2528
	public List<MailSaveOrder> Order = new List<MailSaveOrder>();
}
