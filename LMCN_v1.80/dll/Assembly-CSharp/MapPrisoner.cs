using System;

// Token: 0x02000379 RID: 889
public class MapPrisoner
{
	// Token: 0x06001289 RID: 4745 RVA: 0x00209E7C File Offset: 0x0020807C
	public MapPrisoner(uint Money, ushort kingdomID, CString AlliTAG, CString Name)
	{
		this.Bounty = Money;
		this.TagName = StringManager.Instance.SpawnString(50);
		this.TagName.ClearString();
		GameConstants.GetNameString(this.TagName, kingdomID, Name, AlliTAG, false);
	}

	// Token: 0x0600128A RID: 4746 RVA: 0x00209EC4 File Offset: 0x002080C4
	~MapPrisoner()
	{
	}

	// Token: 0x040039E3 RID: 14819
	public uint Bounty;

	// Token: 0x040039E4 RID: 14820
	public CString TagName;
}
