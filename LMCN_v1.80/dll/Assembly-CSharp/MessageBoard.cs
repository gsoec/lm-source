using System;

// Token: 0x02000141 RID: 321
public class MessageBoard
{
	// Token: 0x0600033B RID: 827 RVA: 0x00028748 File Offset: 0x00026948
	public MessageBoard()
	{
		this.NameStr = new CString(13);
		this.AllianceNameStr = new CString(21);
		this.AllianceTagStr = new CString(4);
		this.ShowName = new CString(50);
		this.MessageStr = new CString(431);
		this.TranslateText = new CString(431);
	}

	// Token: 0x0600033C RID: 828 RVA: 0x000287B8 File Offset: 0x000269B8
	public void Initial()
	{
		this.MessageID = 0L;
		this.MessageTime = 0L;
		this.AllianceOrRole = 0;
		this.PicID = 0;
		this.NameStr.Length = 0;
		this.MessageStr.Length = 0;
		this.TotalHeight = 0f;
		this.TranslateShow = 0;
		this.TranslateLanguage = 0;
		this.TranslateState = eTranslateState.Untranslated;
		this.TranslateText.Length = 0;
		this.TotalHeightT = 0f;
		this.bSelfMessage = false;
		this.bHaveArabic = 0;
	}

	// Token: 0x0600033D RID: 829 RVA: 0x00028840 File Offset: 0x00026A40
	public void TranslateComplete(ushort Language)
	{
		this.TranslateShow = 1;
		this.TranslateLanguage = Language;
		this.TotalHeightT = 0f;
		this.TranslateState = eTranslateState.completed;
	}

	// Token: 0x04000D06 RID: 3334
	public long MessageID;

	// Token: 0x04000D07 RID: 3335
	public long MessageTime;

	// Token: 0x04000D08 RID: 3336
	public byte AllianceOrRole;

	// Token: 0x04000D09 RID: 3337
	public ushort PicID;

	// Token: 0x04000D0A RID: 3338
	public CString NameStr;

	// Token: 0x04000D0B RID: 3339
	public CString AllianceNameStr;

	// Token: 0x04000D0C RID: 3340
	public CString AllianceTagStr;

	// Token: 0x04000D0D RID: 3341
	public CString ShowName;

	// Token: 0x04000D0E RID: 3342
	public CString MessageStr;

	// Token: 0x04000D0F RID: 3343
	public float TotalHeight;

	// Token: 0x04000D10 RID: 3344
	public byte TranslateShow = 1;

	// Token: 0x04000D11 RID: 3345
	public ushort TranslateLanguage;

	// Token: 0x04000D12 RID: 3346
	public eTranslateState TranslateState;

	// Token: 0x04000D13 RID: 3347
	public CString TranslateText;

	// Token: 0x04000D14 RID: 3348
	public float TotalHeightT;

	// Token: 0x04000D15 RID: 3349
	public bool bSelfMessage;

	// Token: 0x04000D16 RID: 3350
	public byte bHaveArabic;
}
