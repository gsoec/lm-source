using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// Token: 0x020000DE RID: 222
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class ReportSerial : SerialContent
{
	// Token: 0x060002D9 RID: 729 RVA: 0x000278F8 File Offset: 0x00025AF8
	public ReportSerial()
	{
		this.Caliber = new List<uint>(230);
		this.Serial = new SerialBox[230];
		this.Inbox = new MailBox[400];
	}

	// Token: 0x040009F1 RID: 2545
	public Dictionary<uint, CombatReport> Mail = new Dictionary<uint, CombatReport>(100);

	// Token: 0x040009F2 RID: 2546
	public List<uint> Gather = new List<uint>(10);

	// Token: 0x040009F3 RID: 2547
	public List<uint> Resource = new List<uint>(10);

	// Token: 0x040009F4 RID: 2548
	public List<uint> AntiScout = new List<uint>(10);

	// Token: 0x040009F5 RID: 2549
	public uint AntiScoutID;

	// Token: 0x040009F6 RID: 2550
	public uint GatheringID;

	// Token: 0x040009F7 RID: 2551
	public uint ResourceID;
}
