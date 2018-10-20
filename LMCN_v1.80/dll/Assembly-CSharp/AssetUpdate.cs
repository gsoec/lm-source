using System;

// Token: 0x02000706 RID: 1798
public class AssetUpdate
{
	// Token: 0x0600228C RID: 8844 RVA: 0x004086E0 File Offset: 0x004068E0
	public AssetUpdate(string path, byte kind, byte type, int id)
	{
		this.path = string.Copy(path);
		this.kind = kind;
		this.type = type;
		this.id = id;
	}

	// Token: 0x04006B7C RID: 27516
	public int id;

	// Token: 0x04006B7D RID: 27517
	public byte kind;

	// Token: 0x04006B7E RID: 27518
	public byte type;

	// Token: 0x04006B7F RID: 27519
	public string path;
}
