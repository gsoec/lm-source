using System;
using System.Runtime.InteropServices;

// Token: 0x020000F5 RID: 245
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class CombatReport : MailReportHead
{
	// Token: 0x060002E8 RID: 744 RVA: 0x00027A34 File Offset: 0x00025C34
	public CombatReport(uint Id = 0u, CombatCollectReport Kind = CombatCollectReport.CCR_BATTLE)
	{
		this.SerialID = Id;
		this.Type = Kind;
	}

	// Token: 0x04000AF7 RID: 2807
	public new uint SerialID;

	// Token: 0x04000AF8 RID: 2808
	public PetReportContent Pet;

	// Token: 0x04000AF9 RID: 2809
	public ResourceReportContent Resource;

	// Token: 0x04000AFA RID: 2810
	public MonsterReportContent Monster;

	// Token: 0x04000AFB RID: 2811
	public ScoutReportContent Scout;

	// Token: 0x04000AFC RID: 2812
	public ReconReportContent Recon;

	// Token: 0x04000AFD RID: 2813
	public CombatCollectReport Type;

	// Token: 0x04000AFE RID: 2814
	public GatherReportContent Gather;

	// Token: 0x04000AFF RID: 2815
	public CombatReportContent Combat;

	// Token: 0x04000B00 RID: 2816
	public NPCScoutReportContent NPCScout;

	// Token: 0x04000B01 RID: 2817
	public NPCCombatReportContent NPCCombat;
}
