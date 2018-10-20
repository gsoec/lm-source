using System;
using System.Runtime.InteropServices;

// Token: 0x020000FA RID: 250
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class PetReportContent : MailReportHead
{
	// Token: 0x04000B15 RID: 2837
	public ushort KindgomID;

	// Token: 0x04000B16 RID: 2838
	public ushort Zone;

	// Token: 0x04000B17 RID: 2839
	public byte Point;

	// Token: 0x04000B18 RID: 2840
	public byte Kind;

	// Token: 0x04000B19 RID: 2841
	public byte Side;

	// Token: 0x04000B1A RID: 2842
	public ushort AssaultKingdomID;

	// Token: 0x04000B1B RID: 2843
	public string AssaultAllianceTag;

	// Token: 0x04000B1C RID: 2844
	public string AssaultName;

	// Token: 0x04000B1D RID: 2845
	public ushort AssaultCapitalZone;

	// Token: 0x04000B1E RID: 2846
	public byte AssaultCapitalPoint;

	// Token: 0x04000B1F RID: 2847
	public byte AssaultLevel;

	// Token: 0x04000B20 RID: 2848
	public ushort AssaultHead;

	// Token: 0x04000B21 RID: 2849
	public byte AssaultVIPLevel;

	// Token: 0x04000B22 RID: 2850
	public byte AssaultAllianceRank;

	// Token: 0x04000B23 RID: 2851
	public ushort DefenceKingdomID;

	// Token: 0x04000B24 RID: 2852
	public string DefenceAllianceTag;

	// Token: 0x04000B25 RID: 2853
	public string DefenceName;

	// Token: 0x04000B26 RID: 2854
	public ushort DefenceCapitalZone;

	// Token: 0x04000B27 RID: 2855
	public byte DefenceCapitalPoint;

	// Token: 0x04000B28 RID: 2856
	public byte DefenceLevel;

	// Token: 0x04000B29 RID: 2857
	public ushort DefenceHead;

	// Token: 0x04000B2A RID: 2858
	public byte DefenceVIPLevel;

	// Token: 0x04000B2B RID: 2859
	public byte DefenceAllianceRank;

	// Token: 0x04000B2C RID: 2860
	public uint PatchNo;

	// Token: 0x04000B2D RID: 2861
	public ushort PetID;

	// Token: 0x04000B2E RID: 2862
	public byte PetStar;

	// Token: 0x04000B2F RID: 2863
	public ushort SkillID;

	// Token: 0x04000B30 RID: 2864
	public byte SkillLevel;

	// Token: 0x04000B31 RID: 2865
	public PetReportResultType Result;

	// Token: 0x04000B32 RID: 2866
	public uint[] Resource;

	// Token: 0x04000B33 RID: 2867
	public ulong LostPower;

	// Token: 0x04000B34 RID: 2868
	public uint TotalInjure;

	// Token: 0x04000B35 RID: 2869
	public uint TotalDead;

	// Token: 0x04000B36 RID: 2870
	public uint[] InjureTroops;

	// Token: 0x04000B37 RID: 2871
	public uint[] DeadTroops;

	// Token: 0x04000B38 RID: 2872
	public uint WallDamage;
}
