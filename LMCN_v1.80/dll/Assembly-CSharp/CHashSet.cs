using System;
using UnityEngine;

// Token: 0x020001B7 RID: 439
public class CHashSet<TKey>
{
	// Token: 0x06000746 RID: 1862 RVA: 0x000A1C00 File Offset: 0x0009FE00
	public CHashSet(int capacity, bool bSaveKeyData = true)
	{
		if (capacity <= 0)
		{
			Debug.LogError("CHashSet::Length can't be zero");
		}
		this.m_HashCode = new int[capacity];
		if (bSaveKeyData)
		{
			this.m_Key = new TKey[capacity];
		}
		GameConstants.ArrayFill<int>(this.m_HashCode, -1);
	}

	// Token: 0x06000747 RID: 1863 RVA: 0x000A1C50 File Offset: 0x0009FE50
	public int hashFunction(TKey key)
	{
		return key.GetHashCode() & int.MaxValue;
	}

	// Token: 0x06000748 RID: 1864 RVA: 0x000A1C74 File Offset: 0x0009FE74
	public bool Add(TKey key)
	{
		if (this.m_Count == this.m_HashCode.Length)
		{
			Debug.LogError("CHashSet::Insert failed");
			return false;
		}
		int num = this.hashFunction(key);
		num %= this.m_HashCode.Length;
		while (this.m_HashCode[num] != -1)
		{
			num++;
			num %= this.m_HashCode.Length;
		}
		this.m_HashCode[num] = key.GetHashCode();
		if (this.m_Key != null)
		{
			this.m_Key[num] = key;
		}
		this.m_Count++;
		return true;
	}

	// Token: 0x06000749 RID: 1865 RVA: 0x000A1D14 File Offset: 0x0009FF14
	public bool Insert(TKey key)
	{
		return this.Add(key);
	}

	// Token: 0x0600074A RID: 1866 RVA: 0x000A1D20 File Offset: 0x0009FF20
	public bool Find(TKey key)
	{
		return this.ContainsKey(key);
	}

	// Token: 0x0600074B RID: 1867 RVA: 0x000A1D2C File Offset: 0x0009FF2C
	public bool ContainsKey(TKey key)
	{
		int num = this.hashFunction(key);
		num %= this.m_HashCode.Length;
		int num2 = num;
		while (this.m_HashCode[num] != -1)
		{
			if (this.m_HashCode[num] == key.GetHashCode())
			{
				return true;
			}
			num++;
			num %= this.m_HashCode.Length;
			if (num2 == num)
			{
				return false;
			}
		}
		return false;
	}

	// Token: 0x0600074C RID: 1868 RVA: 0x000A1D98 File Offset: 0x0009FF98
	public void Remove(TKey key)
	{
		if (this.m_Count == 0)
		{
			return;
		}
		int num = this.hashFunction(key);
		num %= this.m_HashCode.Length;
		int num2 = num;
		while (this.m_HashCode[num] != -1)
		{
			if (this.m_HashCode[num] == key.GetHashCode())
			{
				this.m_HashCode[num] = -1;
				if (this.m_Key != null)
				{
					this.m_Key[num] = default(TKey);
				}
				this.m_Count--;
				return;
			}
			num++;
			num %= this.m_HashCode.Length;
			if (num2 == num)
			{
				return;
			}
		}
	}

	// Token: 0x0600074D RID: 1869 RVA: 0x000A1E44 File Offset: 0x000A0044
	public void Clear()
	{
		GameConstants.ArrayFill<int>(this.m_HashCode, -1);
		if (this.m_Key != null)
		{
			Array.Clear(this.m_Key, 0, this.m_Key.Length);
		}
		this.m_Count = 0;
	}

	// Token: 0x17000046 RID: 70
	// (get) Token: 0x0600074E RID: 1870 RVA: 0x000A1E84 File Offset: 0x000A0084
	public int Count
	{
		get
		{
			return this.m_Count;
		}
	}

	// Token: 0x17000047 RID: 71
	// (get) Token: 0x0600074F RID: 1871 RVA: 0x000A1E8C File Offset: 0x000A008C
	public TKey[] Keys
	{
		get
		{
			return this.m_Key;
		}
	}

	// Token: 0x04001B80 RID: 7040
	private int[] m_HashCode;

	// Token: 0x04001B81 RID: 7041
	private TKey[] m_Key;

	// Token: 0x04001B82 RID: 7042
	private int m_Count;
}
