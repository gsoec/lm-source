using System;
using System.Runtime.InteropServices;

// Token: 0x020000D0 RID: 208
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AllianceInfo
{
	// Token: 0x1700002E RID: 46
	// (get) Token: 0x060002CC RID: 716 RVA: 0x00027628 File Offset: 0x00025828
	public byte AMMaxDegree
	{
		get
		{
			return DataManager.Instance.AllianceMobilizationDegreeRange.GetRecordByIndex((int)this.AMRank).Range;
		}
	}

	// Token: 0x0400094C RID: 2380
	public uint Id;

	// Token: 0x0400094D RID: 2381
	public uint Channel;

	// Token: 0x0400094E RID: 2382
	public byte Language;

	// Token: 0x0400094F RID: 2383
	public AllianceRank Rank;

	// Token: 0x04000950 RID: 2384
	public CString Tag;

	// Token: 0x04000951 RID: 2385
	public CString Name;

	// Token: 0x04000952 RID: 2386
	public string Notice;

	// Token: 0x04000953 RID: 2387
	public string Bullet;

	// Token: 0x04000954 RID: 2388
	public string Header;

	// Token: 0x04000955 RID: 2389
	public CString Leader;

	// Token: 0x04000956 RID: 2390
	public ulong Power;

	// Token: 0x04000957 RID: 2391
	public uint Money;

	// Token: 0x04000958 RID: 2392
	public ushort Emblem;

	// Token: 0x04000959 RID: 2393
	public byte Member;

	// Token: 0x0400095A RID: 2394
	public byte Applicant;

	// Token: 0x0400095B RID: 2395
	public byte Approval;

	// Token: 0x0400095C RID: 2396
	public byte Apply;

	// Token: 0x0400095D RID: 2397
	public uint[] ApplyList;

	// Token: 0x0400095E RID: 2398
	public ushort GiftNum;

	// Token: 0x0400095F RID: 2399
	public byte GiftLv;

	// Token: 0x04000960 RID: 2400
	public ushort PackItemID;

	// Token: 0x04000961 RID: 2401
	public uint PackPoint;

	// Token: 0x04000962 RID: 2402
	public uint GiftExp;

	// Token: 0x04000963 RID: 2403
	public long ChatId;

	// Token: 0x04000964 RID: 2404
	public long ChatMax;

	// Token: 0x04000965 RID: 2405
	public ushort KingdomID;

	// Token: 0x04000966 RID: 2406
	public long BookmarkTime;

	// Token: 0x04000967 RID: 2407
	public byte BulletinFlag;

	// Token: 0x04000968 RID: 2408
	public byte NoticeinFlag;

	// Token: 0x04000969 RID: 2409
	public byte AMRank;

	// Token: 0x0400096A RID: 2410
	public long JoinTime;

	// Token: 0x0400096B RID: 2411
	public byte AMRankMainInfoUIShow;

	// Token: 0x0400096C RID: 2412
	public byte AWRankMainInfoUIShow;

	// Token: 0x0400096D RID: 2413
	public byte AMPlaceMainInfoUIShow;
}
