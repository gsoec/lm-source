using System;

// Token: 0x0200077B RID: 1915
public class MessageBuff
{
	// Token: 0x06002572 RID: 9586 RVA: 0x0042B924 File Offset: 0x00429B24
	public MessageBuff(int size)
	{
		this.Data = new byte[size];
	}

	// Token: 0x06002573 RID: 9587 RVA: 0x0042B938 File Offset: 0x00429B38
	public void Clear()
	{
		this.parse_pos = 0;
	}

	// Token: 0x04007006 RID: 28678
	public byte[] Data;

	// Token: 0x04007007 RID: 28679
	public int position;

	// Token: 0x04007008 RID: 28680
	public int last_pos;

	// Token: 0x04007009 RID: 28681
	public int parse_pos;
}
