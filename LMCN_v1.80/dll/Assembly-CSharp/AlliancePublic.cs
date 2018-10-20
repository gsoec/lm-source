using System;
using System.Runtime.InteropServices;

// Token: 0x0200013C RID: 316
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AlliancePublic
{
	// Token: 0x04000CC1 RID: 3265
	public uint Id;

	// Token: 0x04000CC2 RID: 3266
	public byte Language;

	// Token: 0x04000CC3 RID: 3267
	public string Tag;

	// Token: 0x04000CC4 RID: 3268
	public string Name;

	// Token: 0x04000CC5 RID: 3269
	public string Notice;

	// Token: 0x04000CC6 RID: 3270
	public string Header;

	// Token: 0x04000CC7 RID: 3271
	public string Leader;

	// Token: 0x04000CC8 RID: 3272
	public ulong Power;

	// Token: 0x04000CC9 RID: 3273
	public ushort Emblem;

	// Token: 0x04000CCA RID: 3274
	public byte Member;

	// Token: 0x04000CCB RID: 3275
	public byte Approval;

	// Token: 0x04000CCC RID: 3276
	public byte GiftLv;

	// Token: 0x04000CCD RID: 3277
	public ushort KingdomID;

	// Token: 0x04000CCE RID: 3278
	public byte NoticeFlag;

	// Token: 0x04000CCF RID: 3279
	public byte AMRankMainInfoUIShow;

	// Token: 0x04000CD0 RID: 3280
	public byte AWRankMainInfoUIShow;

	// Token: 0x04000CD1 RID: 3281
	public byte AMPlaceMainInfoUIShow;
}
