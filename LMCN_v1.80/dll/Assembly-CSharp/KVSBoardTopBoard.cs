using System;

// Token: 0x0200038B RID: 907
public class KVSBoardTopBoard
{
	// Token: 0x060012C8 RID: 4808 RVA: 0x0020D1E8 File Offset: 0x0020B3E8
	public KVSBoardTopBoard()
	{
		this.KVSTopAlliTag = StringManager.Instance.SpawnString(30);
		this.KVSTopAlliName = StringManager.Instance.SpawnString(30);
		this.KVSTopPlayerTag = StringManager.Instance.SpawnString(30);
		this.KVSTopPlayerName = StringManager.Instance.SpawnString(30);
		this.KvKTopAlliTag = StringManager.Instance.SpawnString(30);
		this.KvKTopAlliName = StringManager.Instance.SpawnString(30);
		this.KvKTopPlayerTag = StringManager.Instance.SpawnString(30);
		this.KvKTopPlayerName = StringManager.Instance.SpawnString(30);
		this.KvKAlliTopPlayerName = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x04003A71 RID: 14961
	public long SortTime;

	// Token: 0x04003A72 RID: 14962
	public ushort KVSTopKingdom;

	// Token: 0x04003A73 RID: 14963
	public ushort KVSTopAlliKingdomID;

	// Token: 0x04003A74 RID: 14964
	public uint KVSTopAlliAllianceID;

	// Token: 0x04003A75 RID: 14965
	public CString KVSTopAlliTag;

	// Token: 0x04003A76 RID: 14966
	public CString KVSTopAlliName;

	// Token: 0x04003A77 RID: 14967
	public ulong KVSTopAlliScore;

	// Token: 0x04003A78 RID: 14968
	public ushort KVSTopAlliEmblem;

	// Token: 0x04003A79 RID: 14969
	public ushort KVSTopPlayerKingdomID;

	// Token: 0x04003A7A RID: 14970
	public CString KVSTopPlayerTag;

	// Token: 0x04003A7B RID: 14971
	public CString KVSTopPlayerName;

	// Token: 0x04003A7C RID: 14972
	public ulong KVSPlayerValue;

	// Token: 0x04003A7D RID: 14973
	public ushort KVSPlayerHead;

	// Token: 0x04003A7E RID: 14974
	public CString KvKAlliTopPlayerName;

	// Token: 0x04003A7F RID: 14975
	public ulong KvKAlliTopPlayerValue;

	// Token: 0x04003A80 RID: 14976
	public ushort KvKAlliTopPlayerHead;

	// Token: 0x04003A81 RID: 14977
	public ushort KVKTopKingdom;

	// Token: 0x04003A82 RID: 14978
	public ushort KvKTopAlliKingdomID;

	// Token: 0x04003A83 RID: 14979
	public uint KvKTopAlliAllianceID;

	// Token: 0x04003A84 RID: 14980
	public CString KvKTopAlliTag;

	// Token: 0x04003A85 RID: 14981
	public CString KvKTopAlliName;

	// Token: 0x04003A86 RID: 14982
	public ulong KvKTopAlliScore;

	// Token: 0x04003A87 RID: 14983
	public ushort KvKTopAlliEmblem;

	// Token: 0x04003A88 RID: 14984
	public ushort KvKTopPlayerKingdomID;

	// Token: 0x04003A89 RID: 14985
	public CString KvKTopPlayerTag;

	// Token: 0x04003A8A RID: 14986
	public CString KvKTopPlayerName;

	// Token: 0x04003A8B RID: 14987
	public ulong KvKPlayerValue;

	// Token: 0x04003A8C RID: 14988
	public ushort KvKPlayerHead;

	// Token: 0x04003A8D RID: 14989
	public uint KingdomEventRequireTime;

	// Token: 0x04003A8E RID: 14990
	public ulong AllianceID;
}
