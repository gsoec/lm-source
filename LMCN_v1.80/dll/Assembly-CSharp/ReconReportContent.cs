using System;
using System.Runtime.InteropServices;

// Token: 0x020000ED RID: 237
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class ReconReportContent : MailReportHead
{
	// Token: 0x04000AB2 RID: 2738
	public ushort KingdomID;

	// Token: 0x04000AB3 RID: 2739
	public ushort CombatlZone;

	// Token: 0x04000AB4 RID: 2740
	public byte CombatPoint;

	// Token: 0x04000AB5 RID: 2741
	public POINT_KIND CombatPointKind;

	// Token: 0x04000AB6 RID: 2742
	public byte AntiScout;

	// Token: 0x04000AB7 RID: 2743
	public byte WatchLevel;

	// Token: 0x04000AB8 RID: 2744
	public ushort SrcKingdomID;

	// Token: 0x04000AB9 RID: 2745
	public string SrcName;

	// Token: 0x04000ABA RID: 2746
	public string SrcAllianceTag;

	// Token: 0x04000ABB RID: 2747
	public ushort SrcHead;

	// Token: 0x04000ABC RID: 2748
	public byte bAmbush;
}
