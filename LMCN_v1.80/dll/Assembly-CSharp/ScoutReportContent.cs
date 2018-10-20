using System;
using System.Runtime.InteropServices;

// Token: 0x020000EB RID: 235
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class ScoutReportContent : MailReportHead
{
	// Token: 0x04000A9A RID: 2714
	public ushort KingdomID;

	// Token: 0x04000A9B RID: 2715
	public ushort CombatlZone;

	// Token: 0x04000A9C RID: 2716
	public byte CombatPoint;

	// Token: 0x04000A9D RID: 2717
	public POINT_KIND CombatPointKind;

	// Token: 0x04000A9E RID: 2718
	public ushort ObjKingdomID;

	// Token: 0x04000A9F RID: 2719
	public string ObjAllianceTag;

	// Token: 0x04000AA0 RID: 2720
	public string ObjName;

	// Token: 0x04000AA1 RID: 2721
	public byte ScoutLevel;

	// Token: 0x04000AA2 RID: 2722
	public byte ScoutResult;

	// Token: 0x04000AA3 RID: 2723
	public byte DetailSelfIndex;

	// Token: 0x04000AA4 RID: 2724
	public CombatSummaryContent Summary;

	// Token: 0x04000AA5 RID: 2725
	public ushort ScoutContentLen;

	// Token: 0x04000AA6 RID: 2726
	public byte[] ScoutContent;
}
