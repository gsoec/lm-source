using System;

// Token: 0x020007A0 RID: 1952
public struct PetMarchEventDataType
{
	// Token: 0x060027D0 RID: 10192 RVA: 0x0043FC34 File Offset: 0x0043DE34
	public void Empty()
	{
		this.PetID = 0;
		this.Point.pointID = 0;
		this.Point.zoneID = 0;
		this.MarchEventTime.BeginTime = 0L;
		this.MarchEventTime.RequireTime = 0u;
		this.DesPointLevel = 0;
		if (this.DesPlayerName != null)
		{
			this.DesPlayerName.ClearString();
		}
	}

	// Token: 0x040071C5 RID: 29125
	public ushort PetID;

	// Token: 0x040071C6 RID: 29126
	public PointCode Point;

	// Token: 0x040071C7 RID: 29127
	public TimeEventDataType MarchEventTime;

	// Token: 0x040071C8 RID: 29128
	public POINT_KIND DesPointKind;

	// Token: 0x040071C9 RID: 29129
	public byte DesPointLevel;

	// Token: 0x040071CA RID: 29130
	public CString DesPlayerName;
}
