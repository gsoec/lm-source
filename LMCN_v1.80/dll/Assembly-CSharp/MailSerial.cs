using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// Token: 0x020000DC RID: 220
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class MailSerial : SerialContent
{
	// Token: 0x060002D6 RID: 726 RVA: 0x000277F8 File Offset: 0x000259F8
	public MailSerial()
	{
		this.Caliber = new List<uint>(200);
		this.Serial = new SerialBox[200];
		this.Inbox = new MailBox[100];
	}

	// Token: 0x040009EB RID: 2539
	public List<MailSaveOrder> Saviour = new List<MailSaveOrder>();

	// Token: 0x040009EC RID: 2540
	public Dictionary<uint, MailContent> Mail = new Dictionary<uint, MailContent>(100);

	// Token: 0x040009ED RID: 2541
	public Dictionary<uint, SubContent> SubMail = new Dictionary<uint, SubContent>(100);
}
