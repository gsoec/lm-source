using System;

// Token: 0x02000785 RID: 1925
public class NewbieLog
{
	// Token: 0x060025BE RID: 9662 RVA: 0x0042EB60 File Offset: 0x0042CD60
	public static void Log(ENewbieLogKind kind, byte step)
	{
		MessagePacket messagePacket = new MessagePacket(1024);
		messagePacket.Protocol = Protocol._MSG_REQUEST_UPDATENEWBIELOG;
		messagePacket.AddSeqId();
		messagePacket.Add((byte)kind);
		messagePacket.Add(step);
		messagePacket.Send(false);
	}
}
