using System;

// Token: 0x020003C3 RID: 963
public struct BlackMarketExtraTradeData
{
	// Token: 0x06001412 RID: 5138 RVA: 0x00234550 File Offset: 0x00232750
	public BlackMarketExtraTradeData(byte tmp)
	{
		this.TradePos = 0;
		this.LocksBought = 0;
		this.itemID = 0;
		this.Discount = 0;
		this.DataLen = 0;
		this.ItemContain = new ComboBoxTBItemDataType[200];
	}

	// Token: 0x04003C75 RID: 15477
	public byte TradePos;

	// Token: 0x04003C76 RID: 15478
	public byte LocksBought;

	// Token: 0x04003C77 RID: 15479
	public ushort itemID;

	// Token: 0x04003C78 RID: 15480
	public byte Discount;

	// Token: 0x04003C79 RID: 15481
	public byte DataLen;

	// Token: 0x04003C7A RID: 15482
	public ComboBoxTBItemDataType[] ItemContain;
}
