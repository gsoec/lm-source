using System;

// Token: 0x020000FE RID: 254
public struct _TroopStatistic
{
	// Token: 0x060002F9 RID: 761 RVA: 0x000281FC File Offset: 0x000263FC
	public _TroopStatistic(byte bInit = 1)
	{
		this.TroopData = new uint[4][];
		for (int i = 0; i < this.TroopData.Length; i++)
		{
			this.TroopData[i] = new uint[4];
		}
		this.bUpdate = 1;
	}

	// Token: 0x060002FA RID: 762 RVA: 0x00028244 File Offset: 0x00026444
	public uint[][] GetTroop()
	{
		if (this.bUpdate == 1)
		{
			this.Clear();
			DataManager instance = DataManager.Instance;
			int count = instance.WarTroop.Count;
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 16; j++)
				{
					this.TroopData[j >> 2][j & 3] += instance.WarTroop[i].TroopData[j >> 2][j & 3];
				}
			}
			this.bUpdate = 0;
		}
		return this.TroopData;
	}

	// Token: 0x060002FB RID: 763 RVA: 0x000282D8 File Offset: 0x000264D8
	public void UpdateTroop()
	{
		this.bUpdate = 1;
	}

	// Token: 0x060002FC RID: 764 RVA: 0x000282E4 File Offset: 0x000264E4
	public void Clear()
	{
		for (int i = 0; i < this.TroopData.Length; i++)
		{
			Array.Clear(this.TroopData[i], 0, this.TroopData[i].Length);
		}
	}

	// Token: 0x04000B65 RID: 2917
	private uint[][] TroopData;

	// Token: 0x04000B66 RID: 2918
	private byte bUpdate;
}
