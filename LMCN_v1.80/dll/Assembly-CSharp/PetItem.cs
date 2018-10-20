using System;

// Token: 0x020007AD RID: 1965
public class PetItem : IComparable<ushort>, IComparable<PetItem>
{
	// Token: 0x1700010A RID: 266
	// (get) Token: 0x0600284C RID: 10316 RVA: 0x00446434 File Offset: 0x00444634
	// (set) Token: 0x0600284B RID: 10315 RVA: 0x004463CC File Offset: 0x004445CC
	public ushort ItemID
	{
		get
		{
			return this._ItemID;
		}
		set
		{
			if (this._ItemID != value)
			{
				Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(value);
				this.EquipKind = recordByKey.EquipKind;
				this.Color = recordByKey.Color;
				this.PropertiesInfo = recordByKey.PropertiesInfo;
				this.SyntheticParts = recordByKey.SyntheticParts;
			}
			this._ItemID = value;
		}
	}

	// Token: 0x0600284D RID: 10317 RVA: 0x0044643C File Offset: 0x0044463C
	public void Init()
	{
		this.Quantity = 0;
	}

	// Token: 0x0600284E RID: 10318 RVA: 0x00446448 File Offset: 0x00444648
	public int CompareTo(PetItem obj)
	{
		if (obj.ItemID > this.ItemID)
		{
			return -1;
		}
		if (obj.ItemID < this.ItemID)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x0600284F RID: 10319 RVA: 0x0044647C File Offset: 0x0044467C
	public int CompareTo(ushort itemID)
	{
		if (this.ItemID > itemID)
		{
			return -1;
		}
		if (this.ItemID < itemID)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x0400729B RID: 29339
	private ushort _ItemID;

	// Token: 0x0400729C RID: 29340
	public byte EquipKind;

	// Token: 0x0400729D RID: 29341
	public byte Color;

	// Token: 0x0400729E RID: 29342
	public Properties[] PropertiesInfo;

	// Token: 0x0400729F RID: 29343
	public Synthetic[] SyntheticParts;

	// Token: 0x040072A0 RID: 29344
	public ushort Quantity;
}
