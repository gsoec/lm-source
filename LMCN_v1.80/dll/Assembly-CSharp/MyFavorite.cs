using System;
using System.Runtime.InteropServices;

// Token: 0x020000F4 RID: 244
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class MyFavorite
{
	// Token: 0x060002E7 RID: 743 RVA: 0x00027A08 File Offset: 0x00025C08
	public MyFavorite(MailType type = MailType.EMAIL_MAX, uint Id = 0u)
	{
		this.Type = type;
		this.Kind = type;
		this.Serial = Id;
	}

	// Token: 0x04000AEF RID: 2799
	public uint Serial;

	// Token: 0x04000AF0 RID: 2800
	public byte MailVer;

	// Token: 0x04000AF1 RID: 2801
	public MailType Type;

	// Token: 0x04000AF2 RID: 2802
	public MailType Kind;

	// Token: 0x04000AF3 RID: 2803
	public SerialBox Box;

	// Token: 0x04000AF4 RID: 2804
	public MailContent Mail;

	// Token: 0x04000AF5 RID: 2805
	public CombatReport Combat;

	// Token: 0x04000AF6 RID: 2806
	public NoticeContent System;
}
