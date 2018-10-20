using System;
using System.Runtime.InteropServices;

// Token: 0x020000EA RID: 234
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class NPCCombatReportContent : MailReportHead
{
	// Token: 0x04000A7D RID: 2685
	public ushort KingdomID;

	// Token: 0x04000A7E RID: 2686
	public ushort CombatlZone;

	// Token: 0x04000A7F RID: 2687
	public byte CombatPoint;

	// Token: 0x04000A80 RID: 2688
	public POINT_KIND CombatPointKind;

	// Token: 0x04000A81 RID: 2689
	public byte Side;

	// Token: 0x04000A82 RID: 2690
	public ushort AssaultKingdomID;

	// Token: 0x04000A83 RID: 2691
	public string AssaultAllianceTag;

	// Token: 0x04000A84 RID: 2692
	public string AssaultName;

	// Token: 0x04000A85 RID: 2693
	public byte NPCLevel;

	// Token: 0x04000A86 RID: 2694
	public ushort NPCID;

	// Token: 0x04000A87 RID: 2695
	public CombatReportResultType Result;

	// Token: 0x04000A88 RID: 2696
	public ushort Reward;

	// Token: 0x04000A89 RID: 2697
	public CombatHeroExpData[] HeroData;

	// Token: 0x04000A8A RID: 2698
	public uint EarnLordExp;

	// Token: 0x04000A8B RID: 2699
	public uint EarnHeroExp;

	// Token: 0x04000A8C RID: 2700
	public ulong DetailAutoID;

	// Token: 0x04000A8D RID: 2701
	public int DetailDbServerID;

	// Token: 0x04000A8E RID: 2702
	public int AccessKey;

	// Token: 0x04000A8F RID: 2703
	public byte DetailSelfIndex;

	// Token: 0x04000A90 RID: 2704
	public uint ResurrextTotal;

	// Token: 0x04000A91 RID: 2705
	public CombatSummaryHead SummaryHead;

	// Token: 0x04000A92 RID: 2706
	public NPCCombatSummaryContent Summary;

	// Token: 0x04000A93 RID: 2707
	public uint Version;

	// Token: 0x04000A94 RID: 2708
	public uint PatchNo;

	// Token: 0x04000A95 RID: 2709
	public byte AssaultArmyCoord;

	// Token: 0x04000A96 RID: 2710
	public byte DefenceArmyCoord;

	// Token: 0x04000A97 RID: 2711
	public uint PetSkillPatchNo;

	// Token: 0x04000A98 RID: 2712
	public ushort[] m_AssaultPetSkill_ID;

	// Token: 0x04000A99 RID: 2713
	public byte[] m_AssaultPetSkill_LV;
}
