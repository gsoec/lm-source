using System;
using System.Runtime.InteropServices;

// Token: 0x020000E6 RID: 230
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class CombatReportContent : MailReportHead
{
	// Token: 0x04000A45 RID: 2629
	public ushort KingdomID;

	// Token: 0x04000A46 RID: 2630
	public ushort CombatlZone;

	// Token: 0x04000A47 RID: 2631
	public byte CombatPoint;

	// Token: 0x04000A48 RID: 2632
	public POINT_KIND CombatPointKind;

	// Token: 0x04000A49 RID: 2633
	public byte Side;

	// Token: 0x04000A4A RID: 2634
	public ushort AssaultKingdomID;

	// Token: 0x04000A4B RID: 2635
	public string AssaultAllianceTag;

	// Token: 0x04000A4C RID: 2636
	public string AssaultName;

	// Token: 0x04000A4D RID: 2637
	public ushort DefenceKingdomID;

	// Token: 0x04000A4E RID: 2638
	public string DefenceAllianceTag;

	// Token: 0x04000A4F RID: 2639
	public string DefenceName;

	// Token: 0x04000A50 RID: 2640
	public CombatReportResultType Result;

	// Token: 0x04000A51 RID: 2641
	public int[] Resource;

	// Token: 0x04000A52 RID: 2642
	public CombatHeroExpData[] HeroData;

	// Token: 0x04000A53 RID: 2643
	public uint EarnLordExp;

	// Token: 0x04000A54 RID: 2644
	public uint EarnHeroExp;

	// Token: 0x04000A55 RID: 2645
	public ulong DetailAutoID;

	// Token: 0x04000A56 RID: 2646
	public int DetailDbServerID;

	// Token: 0x04000A57 RID: 2647
	public int AccessKey;

	// Token: 0x04000A58 RID: 2648
	public byte DetailSelfIndex;

	// Token: 0x04000A59 RID: 2649
	public ECombatReportCaptureResultType CaptureResult;

	// Token: 0x04000A5A RID: 2650
	public CombatSummaryContent Summary;

	// Token: 0x04000A5B RID: 2651
	public uint Version;

	// Token: 0x04000A5C RID: 2652
	public uint PatchNo;

	// Token: 0x04000A5D RID: 2653
	public byte Atkcoord;

	// Token: 0x04000A5E RID: 2654
	public byte Defcoord;

	// Token: 0x04000A5F RID: 2655
	public uint PetSkillPatchNo;

	// Token: 0x04000A60 RID: 2656
	public ushort[] m_AssaultPetSkill_ID;

	// Token: 0x04000A61 RID: 2657
	public byte[] m_AssaultPetSkill_LV;

	// Token: 0x04000A62 RID: 2658
	public ushort[] m_DefencePetSkill_ID;

	// Token: 0x04000A63 RID: 2659
	public byte[] m_DefencePetSkill_LV;
}
