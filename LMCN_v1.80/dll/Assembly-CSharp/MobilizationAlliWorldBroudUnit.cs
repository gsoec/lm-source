using System;

// Token: 0x02000392 RID: 914
public class MobilizationAlliWorldBroudUnit
{
	// Token: 0x060012CF RID: 4815 RVA: 0x0020D3DC File Offset: 0x0020B5DC
	public MobilizationAlliWorldBroudUnit()
	{
		this.AllianceTag = StringManager.Instance.SpawnString(30);
		this.Name = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x04003AB9 RID: 15033
	public ushort KingdomID;

	// Token: 0x04003ABA RID: 15034
	public uint AlliacneID;

	// Token: 0x04003ABB RID: 15035
	public CString AllianceTag;

	// Token: 0x04003ABC RID: 15036
	public CString Name;

	// Token: 0x04003ABD RID: 15037
	public uint Score;

	// Token: 0x04003ABE RID: 15038
	public byte ChangeRank;

	// Token: 0x04003ABF RID: 15039
	public byte State;
}
