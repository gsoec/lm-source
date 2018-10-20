using System;
using System.Runtime.InteropServices;

// Token: 0x020000D7 RID: 215
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class MailContent : MailReportHead
{
	// Token: 0x040009A6 RID: 2470
	public byte MailType;

	// Token: 0x040009A7 RID: 2471
	public ushort SenderHead;

	// Token: 0x040009A8 RID: 2472
	public ushort SenderKindom;

	// Token: 0x040009A9 RID: 2473
	public string SenderName;

	// Token: 0x040009AA RID: 2474
	public string SenderTag;

	// Token: 0x040009AB RID: 2475
	public byte ExtraFlag;

	// Token: 0x040009AC RID: 2476
	public byte AttachNum;

	// Token: 0x040009AD RID: 2477
	public uint ReplyID;

	// Token: 0x040009AE RID: 2478
	public string Title;

	// Token: 0x040009AF RID: 2479
	public string TitleT;

	// Token: 0x040009B0 RID: 2480
	public byte TitleLen;

	// Token: 0x040009B1 RID: 2481
	public string Content;

	// Token: 0x040009B2 RID: 2482
	public string ContentT;

	// Token: 0x040009B3 RID: 2483
	public ushort ContentLen;

	// Token: 0x040009B4 RID: 2484
	public byte LanguageSent;

	// Token: 0x040009B5 RID: 2485
	public byte LanguageSource;

	// Token: 0x040009B6 RID: 2486
	public byte LanguageTarget;

	// Token: 0x040009B7 RID: 2487
	public bool Translation;

	// Token: 0x040009B8 RID: 2488
	public bool TranslationError;

	// Token: 0x040009B9 RID: 2489
	public BookmarkMailType[] Attach = new BookmarkMailType[6];
}
