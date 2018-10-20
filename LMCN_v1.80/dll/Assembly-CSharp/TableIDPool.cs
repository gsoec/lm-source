using System;
using System.Collections.Generic;

// Token: 0x020001BA RID: 442
public sealed class TableIDPool
{
	// Token: 0x06000764 RID: 1892 RVA: 0x000A24E4 File Offset: 0x000A06E4
	public TableIDPool(int MaxIDTableCount, bool bGrewUp = false)
	{
		this.grewUp = bGrewUp;
		this.nowIDTableCounter = 0;
		this.maxIDTableCount = MaxIDTableCount;
		this._tableIDPoolPools = new List<int>(this.maxIDTableCount);
	}

	// Token: 0x06000765 RID: 1893 RVA: 0x000A2520 File Offset: 0x000A0720
	~TableIDPool()
	{
		if (this._tableIDPoolPools != null)
		{
			this._tableIDPoolPools.Clear();
			this._tableIDPoolPools = null;
		}
	}

	// Token: 0x06000766 RID: 1894 RVA: 0x000A2574 File Offset: 0x000A0774
	public int spawn()
	{
		int result;
		if (this._tableIDPoolPools.Count > 0)
		{
			result = this._tableIDPoolPools[this._tableIDPoolPools.Count - 1];
			this._tableIDPoolPools.RemoveAt(this._tableIDPoolPools.Count - 1);
		}
		else if (this.nowIDTableCounter < this.maxIDTableCount)
		{
			result = this.nowIDTableCounter++;
		}
		else if (this.grewUp)
		{
			this.maxIDTableCount *= 2;
			result = this.nowIDTableCounter++;
		}
		else
		{
			result = this.maxIDTableCount;
		}
		return result;
	}

	// Token: 0x06000767 RID: 1895 RVA: 0x000A262C File Offset: 0x000A082C
	public void despawn(int t)
	{
		this._tableIDPoolPools.Add(t);
	}

	// Token: 0x06000768 RID: 1896 RVA: 0x000A263C File Offset: 0x000A083C
	public void init()
	{
		this.nowIDTableCounter = 0;
		this._tableIDPoolPools.Clear();
	}

	// Token: 0x04001B8A RID: 7050
	private bool grewUp;

	// Token: 0x04001B8B RID: 7051
	private int maxIDTableCount;

	// Token: 0x04001B8C RID: 7052
	private int nowIDTableCounter;

	// Token: 0x04001B8D RID: 7053
	private List<int> _tableIDPoolPools;
}
