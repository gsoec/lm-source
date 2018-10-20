using System;
using System.Runtime.InteropServices;

// Token: 0x02000148 RID: 328
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AllianceMemberClientDataType
{
	// Token: 0x06000348 RID: 840 RVA: 0x00028B38 File Offset: 0x00026D38
	public AllianceMemberClientDataType(int len = 0)
	{
		this.UserId = 0L;
		this.LogoutTime = 0L;
		this.TroopKillNum = 0UL;
		this.Power = 0UL;
		this.Head = 0;
		this.Rank = AllianceRank.RANK1;
		this.NickName = null;
		this.Name = null;
	}

	// Token: 0x04000D51 RID: 3409
	public long UserId;

	// Token: 0x04000D52 RID: 3410
	public ushort Head;

	// Token: 0x04000D53 RID: 3411
	public string Name;

	// Token: 0x04000D54 RID: 3412
	public string NickName;

	// Token: 0x04000D55 RID: 3413
	public AllianceRank Rank;

	// Token: 0x04000D56 RID: 3414
	public ulong Power;

	// Token: 0x04000D57 RID: 3415
	public ulong TroopKillNum;

	// Token: 0x04000D58 RID: 3416
	public long LogoutTime;
}
