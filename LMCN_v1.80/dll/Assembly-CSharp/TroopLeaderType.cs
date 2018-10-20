using System;
using System.Runtime.InteropServices;

// Token: 0x0200008A RID: 138
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TroopLeaderType
{
	// Token: 0x060002BB RID: 699 RVA: 0x00026CC4 File Offset: 0x00024EC4
	public TroopLeaderType(ushort heroID, byte rank, byte star)
	{
		this.HeroID = heroID;
		this.Rank = rank;
		this.Star = star;
	}

	// Token: 0x04000783 RID: 1923
	public ushort HeroID;

	// Token: 0x04000784 RID: 1924
	public byte Rank;

	// Token: 0x04000785 RID: 1925
	public byte Star;
}
