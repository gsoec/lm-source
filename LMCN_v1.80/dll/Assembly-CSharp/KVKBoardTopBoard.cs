using System;

// Token: 0x0200038A RID: 906
public class KVKBoardTopBoard
{
	// Token: 0x060012C7 RID: 4807 RVA: 0x0020D178 File Offset: 0x0020B378
	public KVKBoardTopBoard()
	{
		this.KvKTopAlliTag = StringManager.Instance.SpawnString(30);
		this.KvKTopAlliName = StringManager.Instance.SpawnString(30);
		this.KvKAlliTopPlayerName = StringManager.Instance.SpawnString(30);
		this.KvKTopPlayerTag = StringManager.Instance.SpawnString(30);
		this.KvKTopPlayerName = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x04003A5F RID: 14943
	public long SortTime;

	// Token: 0x04003A60 RID: 14944
	public ushort TopKingdom;

	// Token: 0x04003A61 RID: 14945
	public ushort KvKTopAlliKingdomID;

	// Token: 0x04003A62 RID: 14946
	public uint KvKTopAlliAllianceID;

	// Token: 0x04003A63 RID: 14947
	public CString KvKTopAlliTag;

	// Token: 0x04003A64 RID: 14948
	public CString KvKTopAlliName;

	// Token: 0x04003A65 RID: 14949
	public ulong KvKTopAlliScore;

	// Token: 0x04003A66 RID: 14950
	public ushort KvKTopAlliEmblem;

	// Token: 0x04003A67 RID: 14951
	public CString KvKAlliTopPlayerName;

	// Token: 0x04003A68 RID: 14952
	public ulong KvKAlliTopPlayerValue;

	// Token: 0x04003A69 RID: 14953
	public ushort KvKAlliTopPlayerHead;

	// Token: 0x04003A6A RID: 14954
	public uint KingdomEventRequireTime;

	// Token: 0x04003A6B RID: 14955
	public ushort KvKTopPlayerKingdomID;

	// Token: 0x04003A6C RID: 14956
	public CString KvKTopPlayerTag;

	// Token: 0x04003A6D RID: 14957
	public CString KvKTopPlayerName;

	// Token: 0x04003A6E RID: 14958
	public ulong KvKPlayerValue;

	// Token: 0x04003A6F RID: 14959
	public ushort KvKPlayerHead;

	// Token: 0x04003A70 RID: 14960
	public ulong AllianceID;
}
