using System;

// Token: 0x020003B9 RID: 953
public struct LordEquipMaterial
{
	// Token: 0x0600139F RID: 5023 RVA: 0x0022E894 File Offset: 0x0022CA94
	public void Clear()
	{
		this.ItemID = 0;
		this.Color = 0;
		this.Quantity = 0;
	}

	// Token: 0x04003C1F RID: 15391
	public ushort ItemID;

	// Token: 0x04003C20 RID: 15392
	public byte Color;

	// Token: 0x04003C21 RID: 15393
	public ushort Quantity;
}
