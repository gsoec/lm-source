using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

// Token: 0x020000DA RID: 218
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class SystemSerial : SerialContent
{
	// Token: 0x060002D5 RID: 725 RVA: 0x00027798 File Offset: 0x00025998
	public SystemSerial()
	{
		this.Serial = new SerialBox[150];
		this.Caliber = new List<uint>(150);
		this.Serial = new SerialBox[150];
		this.Inbox = new MailBox[50];
	}

	// Token: 0x040009E2 RID: 2530
	public Dictionary<uint, NoticeContent> Mail = new Dictionary<uint, NoticeContent>(50);
}
