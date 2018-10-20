using System;
using System.Runtime.InteropServices;

// Token: 0x020000F6 RID: 246
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class GatherReportContent
{
	// Token: 0x04000B02 RID: 2818
	public ushort KingdomID;

	// Token: 0x04000B03 RID: 2819
	public ushort GatherZone;

	// Token: 0x04000B04 RID: 2820
	public byte GatherPoint;

	// Token: 0x04000B05 RID: 2821
	public POINT_KIND GatherPointKind;

	// Token: 0x04000B06 RID: 2822
	public byte GatherPointLevel;

	// Token: 0x04000B07 RID: 2823
	public uint Resource;

	// Token: 0x04000B08 RID: 2824
	public byte HeroNum;

	// Token: 0x04000B09 RID: 2825
	public byte ItemLen;

	// Token: 0x04000B0A RID: 2826
	public byte[] Item;

	// Token: 0x04000B0B RID: 2827
	public GatherHeroExpData[] mHero;

	// Token: 0x04000B0C RID: 2828
	public ResourceItem[] mResourceItem;
}
