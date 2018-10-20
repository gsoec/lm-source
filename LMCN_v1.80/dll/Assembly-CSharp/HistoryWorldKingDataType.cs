using System;

// Token: 0x0200038F RID: 911
public class HistoryWorldKingDataType
{
	// Token: 0x060012CC RID: 4812 RVA: 0x0020D32C File Offset: 0x0020B52C
	public HistoryWorldKingDataType()
	{
		this.AllianceTag = StringManager.Instance.SpawnString(30);
		this.Name = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x04003AA0 RID: 15008
	public ushort HomeKingdomID;

	// Token: 0x04003AA1 RID: 15009
	public CString AllianceTag;

	// Token: 0x04003AA2 RID: 15010
	public CString Name;

	// Token: 0x04003AA3 RID: 15011
	public uint OccupyTime;

	// Token: 0x04003AA4 RID: 15012
	public long TakeOfficeTime;
}
