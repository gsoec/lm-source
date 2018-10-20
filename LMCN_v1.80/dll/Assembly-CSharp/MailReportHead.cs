using System;
using System.Runtime.InteropServices;

// Token: 0x020000D6 RID: 214
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class MailReportHead
{
	// Token: 0x060002CF RID: 719 RVA: 0x00027674 File Offset: 0x00025874
	public void SetData(byte flag, long Time = 0L)
	{
		this.Flag = flag;
		this.Times = Time;
		this.DateTime = GameConstants.GetDateTime(Time).ToString("MM/dd/yy HH:mm:ss");
	}

	// Token: 0x04000999 RID: 2457
	public uint SerialID;

	// Token: 0x0400099A RID: 2458
	public long Times;

	// Token: 0x0400099B RID: 2459
	public byte Index;

	// Token: 0x0400099C RID: 2460
	public byte Flag;

	// Token: 0x0400099D RID: 2461
	public byte More;

	// Token: 0x0400099E RID: 2462
	public byte UnSeen;

	// Token: 0x0400099F RID: 2463
	public bool BeSave;

	// Token: 0x040009A0 RID: 2464
	public bool BeRead;

	// Token: 0x040009A1 RID: 2465
	public bool BeKept;

	// Token: 0x040009A2 RID: 2466
	public bool BeKill;

	// Token: 0x040009A3 RID: 2467
	public bool BeChecked;

	// Token: 0x040009A4 RID: 2468
	public byte MoreIndex;

	// Token: 0x040009A5 RID: 2469
	public string DateTime;
}
