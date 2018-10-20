using System;

// Token: 0x02000779 RID: 1913
public class GuestMessagePacket : MessagePacket
{
	// Token: 0x06002551 RID: 9553 RVA: 0x0042AE48 File Offset: 0x00429048
	public GuestMessagePacket(byte Id) : base(1024)
	{
		this.Channel = Id;
	}

	// Token: 0x06002552 RID: 9554 RVA: 0x0042AE5C File Offset: 0x0042905C
	public override void AddSeqId()
	{
		base.Add(++GuestMessagePacket.Sequence);
	}

	// Token: 0x04006FFD RID: 28669
	public static int Sequence;
}
