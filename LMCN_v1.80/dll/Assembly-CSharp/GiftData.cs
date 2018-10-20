using System;
using System.Collections.Generic;

// Token: 0x02000765 RID: 1893
public class GiftData
{
	// Token: 0x04006F13 RID: 28435
	public ushort KingGiftNum;

	// Token: 0x04006F14 RID: 28436
	public ushort GuetGiftnum;

	// Token: 0x04006F15 RID: 28437
	public byte StartPos;

	// Token: 0x04006F16 RID: 28438
	public ushort GustKingdomID;

	// Token: 0x04006F17 RID: 28439
	public List<KingGiftInfo> KingGiftList = new List<KingGiftInfo>();

	// Token: 0x04006F18 RID: 28440
	public List<KingGiftInfo> GustKingGiftList = new List<KingGiftInfo>();
}
