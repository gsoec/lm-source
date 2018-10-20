using System;
using System.Runtime.InteropServices;

// Token: 0x020000D4 RID: 212
[Serializable]
[StructLayout(LayoutKind.Sequential)]
public class MailSaveOrder
{
	// Token: 0x060002CD RID: 717 RVA: 0x00027654 File Offset: 0x00025854
	public MailSaveOrder(uint id, byte favor)
	{
		this.IsFavorite = favor;
		this.Id = id;
	}

	// Token: 0x04000994 RID: 2452
	public uint Id;

	// Token: 0x04000995 RID: 2453
	public byte IsFavorite;
}
