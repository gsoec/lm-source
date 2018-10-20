using System;

// Token: 0x0200004A RID: 74
public struct BookMarkData
{
	// Token: 0x060001F7 RID: 503 RVA: 0x0001B604 File Offset: 0x00019804
	public BookMarkData(ushort size)
	{
		this.Name = new CString((int)size);
		this.ID = 0;
		this.Type = 0;
		this.KingdomID = 0;
		this.MapID = 0;
		this.KingdomPoint.pointID = 0;
		this.KingdomPoint.zoneID = 0;
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x0001B654 File Offset: 0x00019854
	public void Clear()
	{
		this.ID = 0;
		this.Type = 0;
		this.KingdomID = 0;
		this.MapID = 0;
		this.KingdomPoint.pointID = 0;
		this.KingdomPoint.zoneID = 0;
		this.Name.ClearString();
	}

	// Token: 0x040003EB RID: 1003
	public ushort ID;

	// Token: 0x040003EC RID: 1004
	public byte Type;

	// Token: 0x040003ED RID: 1005
	public CString Name;

	// Token: 0x040003EE RID: 1006
	public ushort KingdomID;

	// Token: 0x040003EF RID: 1007
	public int MapID;

	// Token: 0x040003F0 RID: 1008
	public PointCode KingdomPoint;
}
