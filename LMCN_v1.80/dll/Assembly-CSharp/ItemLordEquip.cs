using System;

// Token: 0x020003B7 RID: 951
public struct ItemLordEquip
{
	// Token: 0x06001398 RID: 5016 RVA: 0x0022E618 File Offset: 0x0022C818
	public void Init()
	{
		this.ItemID = 0;
		this.SerialNO = 0u;
		this.Color = 0;
		this.Gem = new ushort[4];
		this.GemColor = new byte[4];
		for (int i = 0; i < 4; i++)
		{
			this.GemColor[i] = 0;
			this.Gem[i] = 0;
		}
	}

	// Token: 0x06001399 RID: 5017 RVA: 0x0022E678 File Offset: 0x0022C878
	public void Clear()
	{
		this.ItemID = 0;
		this.SerialNO = 0u;
		this.Color = 0;
		for (int i = 0; i < 4; i++)
		{
			this.GemColor[i] = 0;
			this.Gem[i] = 0;
		}
		this.ExpireTime = 0L;
	}

	// Token: 0x0600139A RID: 5018 RVA: 0x0022E6C8 File Offset: 0x0022C8C8
	public bool haveGem()
	{
		for (int i = 0; i < 4; i++)
		{
			if (this.Gem[i] != 0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600139B RID: 5019 RVA: 0x0022E6F8 File Offset: 0x0022C8F8
	public ItemLordEquip Clone()
	{
		ItemLordEquip result = default(ItemLordEquip);
		result.Init();
		result.ItemID = this.ItemID;
		result.SerialNO = this.SerialNO;
		result.Color = this.Color;
		result.ExpireTime = this.ExpireTime;
		for (int i = 0; i < 4; i++)
		{
			result.GemColor[i] = this.GemColor[i];
			result.Gem[i] = this.Gem[i];
		}
		return result;
	}

	// Token: 0x0600139C RID: 5020 RVA: 0x0022E780 File Offset: 0x0022C980
	public LordEquipSerialData CloneSerial()
	{
		LordEquipSerialData result = default(LordEquipSerialData);
		result.Init();
		result.ItemID = this.ItemID;
		result.Color = this.Color;
		for (int i = 0; i < 4; i++)
		{
			result.GemColor[i] = this.GemColor[i];
			result.Gem[i] = this.Gem[i];
		}
		return result;
	}

	// Token: 0x04003C14 RID: 15380
	public ushort ItemID;

	// Token: 0x04003C15 RID: 15381
	public byte Color;

	// Token: 0x04003C16 RID: 15382
	public byte[] GemColor;

	// Token: 0x04003C17 RID: 15383
	public ushort[] Gem;

	// Token: 0x04003C18 RID: 15384
	public uint SerialNO;

	// Token: 0x04003C19 RID: 15385
	public long ExpireTime;
}
