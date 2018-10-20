using System;
using System.Runtime.InteropServices;

// Token: 0x020000EC RID: 236
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class NPCScoutReportContent : MailReportHead
{
	// Token: 0x04000AA7 RID: 2727
	public ushort KingdomID;

	// Token: 0x04000AA8 RID: 2728
	public ushort CombatlZone;

	// Token: 0x04000AA9 RID: 2729
	public byte CombatPoint;

	// Token: 0x04000AAA RID: 2730
	public POINT_KIND CombatPointKind;

	// Token: 0x04000AAB RID: 2731
	public byte NPCLevel;

	// Token: 0x04000AAC RID: 2732
	public ushort NPCID;

	// Token: 0x04000AAD RID: 2733
	public ushort Reward;

	// Token: 0x04000AAE RID: 2734
	public byte ScoutResult;

	// Token: 0x04000AAF RID: 2735
	public byte ScoutLevel;

	// Token: 0x04000AB0 RID: 2736
	public ushort ScoutContentLen;

	// Token: 0x04000AB1 RID: 2737
	public byte[] ScoutContent;
}
