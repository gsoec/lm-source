using System;
using UnityEngine;

// Token: 0x0200013F RID: 319
public class TalkDataType
{
	// Token: 0x06000337 RID: 823 RVA: 0x000284F4 File Offset: 0x000266F4
	public TalkDataType()
	{
		this.TitleName = new CString(4);
		this.PlayerName = new CString(13);
		this.ShowName = new CString(29);
		this.MainText = new CString(431);
		this.OriginalText = new CString(401);
		this.TranslateText = new CString(431);
		this.NickNameText = new CString(11);
	}

	// Token: 0x06000338 RID: 824 RVA: 0x000285B0 File Offset: 0x000267B0
	public void Initial()
	{
		this.TalkKind = 0;
		this.FuncKind = 0;
		this.PlayID = 0L;
		this.PlayerPicID = 0;
		this.VIPRank = 0;
		this.TitleID = 0;
		this.WTitleID = 0;
		this.NTitleID = 0;
		this.bCheckDirtyWord = 0;
		this.SpecialBlockID = 0;
		this.TitleName.Length = 0;
		this.PlayerName.Length = 0;
		this.ShowName.Length = 0;
		this.MainText.Length = 0;
		this.OriginalText.Length = 0;
		this.TalkTime = 0L;
		this.TalkID = 0L;
		this.TotalHeight = 0f;
		this.bHaveArabic = 0;
		this.TitleLine = 0;
		this.bHasLoc = false;
		this.bHasLocT = false;
		this.BeginIndex = -1;
		this.EndIndex = -1;
		this.BeginIndexT = -1;
		this.EndIndexT = -1;
		this.King = -1;
		this.LocX = -1;
		this.LocY = -1;
		this.NPCID = 0L;
		this.AllyRank = 0;
		this.NickNameText.Length = 0;
		this.KingdomID = 0;
		this.TranslateShow = 0;
		this.TranslateLanguage = 0;
		this.TranslateState = eTranslateState.Untranslated;
		this.TranslateText.Length = 0;
		this.TotalHeightT = 0f;
		this.EmojiKey = 0;
	}

	// Token: 0x06000339 RID: 825 RVA: 0x00028700 File Offset: 0x00026900
	public void TranslateComplete(ushort Language)
	{
		this.TranslateShow = 1;
		this.TranslateLanguage = Language;
		this.TotalHeightT = 0f;
		this.TranslateState = eTranslateState.completed;
	}

	// Token: 0x04000CDC RID: 3292
	public byte TalkKind;

	// Token: 0x04000CDD RID: 3293
	public byte FuncKind;

	// Token: 0x04000CDE RID: 3294
	public long PlayID;

	// Token: 0x04000CDF RID: 3295
	public ushort PlayerPicID;

	// Token: 0x04000CE0 RID: 3296
	public byte VIPRank;

	// Token: 0x04000CE1 RID: 3297
	public byte TitleID;

	// Token: 0x04000CE2 RID: 3298
	public ushort WTitleID;

	// Token: 0x04000CE3 RID: 3299
	public ushort NTitleID;

	// Token: 0x04000CE4 RID: 3300
	public byte SpecialBlockID;

	// Token: 0x04000CE5 RID: 3301
	public CString TitleName;

	// Token: 0x04000CE6 RID: 3302
	public CString PlayerName;

	// Token: 0x04000CE7 RID: 3303
	public CString ShowName;

	// Token: 0x04000CE8 RID: 3304
	public CString MainText;

	// Token: 0x04000CE9 RID: 3305
	public CString OriginalText;

	// Token: 0x04000CEA RID: 3306
	public long TalkTime;

	// Token: 0x04000CEB RID: 3307
	public long TalkID;

	// Token: 0x04000CEC RID: 3308
	public float TotalHeight;

	// Token: 0x04000CED RID: 3309
	public byte AllyRank;

	// Token: 0x04000CEE RID: 3310
	public CString NickNameText;

	// Token: 0x04000CEF RID: 3311
	public ushort KingdomID;

	// Token: 0x04000CF0 RID: 3312
	public byte bHaveArabic;

	// Token: 0x04000CF1 RID: 3313
	public byte TitleLine;

	// Token: 0x04000CF2 RID: 3314
	public byte bCheckDirtyWord;

	// Token: 0x04000CF3 RID: 3315
	public Vector2[] TitlePos = new Vector2[2];

	// Token: 0x04000CF4 RID: 3316
	public bool bHasLoc;

	// Token: 0x04000CF5 RID: 3317
	public bool bHasLocT;

	// Token: 0x04000CF6 RID: 3318
	public int BeginIndex = -1;

	// Token: 0x04000CF7 RID: 3319
	public int EndIndex = -1;

	// Token: 0x04000CF8 RID: 3320
	public int BeginIndexT = -1;

	// Token: 0x04000CF9 RID: 3321
	public int EndIndexT = -1;

	// Token: 0x04000CFA RID: 3322
	public int King = -1;

	// Token: 0x04000CFB RID: 3323
	public int LocX = -1;

	// Token: 0x04000CFC RID: 3324
	public int LocY = -1;

	// Token: 0x04000CFD RID: 3325
	public long NPCID;

	// Token: 0x04000CFE RID: 3326
	public byte TranslateShow = 1;

	// Token: 0x04000CFF RID: 3327
	public ushort TranslateLanguage;

	// Token: 0x04000D00 RID: 3328
	public eTranslateState TranslateState;

	// Token: 0x04000D01 RID: 3329
	public CString TranslateText;

	// Token: 0x04000D02 RID: 3330
	public float TotalHeightT;

	// Token: 0x04000D03 RID: 3331
	public ushort EmojiKey;
}
