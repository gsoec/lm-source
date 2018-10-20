using System;
using System.Runtime.InteropServices;

// Token: 0x020000DD RID: 221
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class FavorSerial : SerialContent
{
	// Token: 0x060002D7 RID: 727 RVA: 0x00027860 File Offset: 0x00025A60
	public FavorSerial()
	{
		this.Mail = new MailSerial();
		this.System = new SystemSerial();
		this.Combat = new ReportSerial();
		this.Inbox = new MailBox[100];
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x000278A4 File Offset: 0x00025AA4
	public new void Clear()
	{
		base.Clear();
		this.Mail.Clear();
		this.Combat.Clear();
		this.System.Clear();
		this.Mail.Mail.Clear();
		this.Combat.Mail.Clear();
	}

	// Token: 0x040009EE RID: 2542
	public MailSerial Mail;

	// Token: 0x040009EF RID: 2543
	public SystemSerial System;

	// Token: 0x040009F0 RID: 2544
	public ReportSerial Combat;
}
