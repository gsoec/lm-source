using System;

// Token: 0x0200075D RID: 1885
internal enum PayErrorCode
{
	// Token: 0x04006E46 RID: 28230
	None,
	// Token: 0x04006E47 RID: 28231
	ErrorItemIDEmpty = 101,
	// Token: 0x04006E48 RID: 28232
	ErrorItemInfo,
	// Token: 0x04006E49 RID: 28233
	ErrorNoRelevantInfo,
	// Token: 0x04006E4A RID: 28234
	ErrorIggGetway,
	// Token: 0x04006E4B RID: 28235
	ErrorIggGetway2,
	// Token: 0x04006E4C RID: 28236
	ErrorPayEmpty,
	// Token: 0x04006E4D RID: 28237
	ErrorPayInfomation,
	// Token: 0x04006E4E RID: 28238
	ErrorPayRelevantInfo,
	// Token: 0x04006E4F RID: 28239
	ErrorPaylaunch,
	// Token: 0x04006E50 RID: 28240
	ErrorPayOther,
	// Token: 0x04006E51 RID: 28241
	ErrorBuyRepeat,
	// Token: 0x04006E52 RID: 28242
	ErrorPaymentIsNotReady = 201,
	// Token: 0x04006E53 RID: 28243
	ErrorPaymentFailed,
	// Token: 0x04006E54 RID: 28244
	ErrorPaymentGetway
}
