using System;
using UnityEngine;

// Token: 0x020001B8 RID: 440
public class CHashTable<TKey, TValue> where TKey : IComparable
{
	// Token: 0x06000750 RID: 1872 RVA: 0x000A1E94 File Offset: 0x000A0094
	public CHashTable(int capacity, bool bSaveKeyData = true)
	{
		if (capacity <= 0)
		{
			Debug.LogError("CHashTable::Length can't be zero");
		}
		this.m_HashCode = new int[capacity];
		this.m_Key = new TKey[capacity];
		this.m_Data = new TValue[capacity];
		GameConstants.ArrayFill<int>(this.m_HashCode, -1);
	}

	// Token: 0x06000751 RID: 1873 RVA: 0x000A1EE8 File Offset: 0x000A00E8
	public int hashFunction(TKey key)
	{
		return key.GetHashCode() & int.MaxValue;
	}

	// Token: 0x06000752 RID: 1874 RVA: 0x000A1F0C File Offset: 0x000A010C
	public bool Add(TKey key, TValue val)
	{
		if (this.m_HashCode.Length == 0)
		{
			return false;
		}
		int num = this.hashFunction(key);
		num %= this.m_HashCode.Length;
		int num2 = num;
		int num3 = -1;
		bool flag = false;
		while (this.m_Key[num].CompareTo(key) != 0 || this.m_HashCode[num] == -1)
		{
			if (this.m_HashCode[num] == -1 && num3 == -1)
			{
				num3 = num;
			}
			num++;
			num %= this.m_HashCode.Length;
			if (num2 == num)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			if (this.m_Count == this.m_HashCode.Length)
			{
				Debug.LogError("CHashTable::Insert failed");
				return false;
			}
			num = num3;
			this.m_Count++;
		}
		this.m_HashCode[num] = key.GetHashCode();
		this.m_Key[num] = key;
		this.m_Data[num] = val;
		return true;
	}

	// Token: 0x06000753 RID: 1875 RVA: 0x000A2010 File Offset: 0x000A0210
	public bool Insert(TKey key, TValue val)
	{
		return this.Add(key, val);
	}

	// Token: 0x06000754 RID: 1876 RVA: 0x000A201C File Offset: 0x000A021C
	public TValue Find(TKey key)
	{
		if (this.m_HashCode.Length == 0)
		{
			return default(TValue);
		}
		int num = this.hashFunction(key);
		num %= this.m_HashCode.Length;
		int num2 = num;
		while (this.m_Key[num].CompareTo(key) != 0 || this.m_HashCode[num] == -1)
		{
			num++;
			num %= this.m_HashCode.Length;
			if (num2 == num)
			{
				return default(TValue);
			}
		}
		return this.m_Data[num];
	}

	// Token: 0x06000755 RID: 1877 RVA: 0x000A20B8 File Offset: 0x000A02B8
	public bool ContainsKey(TKey key)
	{
		if (this.m_HashCode.Length == 0)
		{
			return false;
		}
		int num = this.hashFunction(key);
		num %= this.m_HashCode.Length;
		int num2 = num;
		while (this.m_Key[num].CompareTo(key) != 0 || this.m_HashCode[num] == -1)
		{
			num++;
			num %= this.m_HashCode.Length;
			if (num2 == num)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06000756 RID: 1878 RVA: 0x000A2138 File Offset: 0x000A0338
	public void Remove(TKey key)
	{
		if (this.m_Count == 0)
		{
			return;
		}
		int num = this.hashFunction(key);
		num %= this.m_HashCode.Length;
		int num2 = num;
		while (this.m_Key[num].CompareTo(key) != 0 || this.m_HashCode[num] == -1)
		{
			num++;
			num %= this.m_HashCode.Length;
			if (num2 == num)
			{
				return;
			}
		}
		this.m_HashCode[num] = -1;
		this.m_Key[num] = default(TKey);
		this.m_Data[num] = default(TValue);
		this.m_Count--;
	}

	// Token: 0x06000757 RID: 1879 RVA: 0x000A21F4 File Offset: 0x000A03F4
	public void Clear()
	{
		GameConstants.ArrayFill<int>(this.m_HashCode, -1);
		if (this.m_Key != null)
		{
			Array.Clear(this.m_Key, 0, this.m_Key.Length);
		}
		Array.Clear(this.m_Data, 0, this.m_Data.Length);
		this.m_Count = 0;
	}

	// Token: 0x17000048 RID: 72
	public TValue this[TKey key]
	{
		get
		{
			return this.Find(key);
		}
		set
		{
			this.Add(key, value);
		}
	}

	// Token: 0x17000049 RID: 73
	// (get) Token: 0x0600075A RID: 1882 RVA: 0x000A2260 File Offset: 0x000A0460
	public int Count
	{
		get
		{
			return this.m_Count;
		}
	}

	// Token: 0x1700004A RID: 74
	// (get) Token: 0x0600075B RID: 1883 RVA: 0x000A2268 File Offset: 0x000A0468
	public int Length
	{
		get
		{
			return this.m_HashCode.Length;
		}
	}

	// Token: 0x1700004B RID: 75
	// (get) Token: 0x0600075C RID: 1884 RVA: 0x000A2274 File Offset: 0x000A0474
	public TValue[] Values
	{
		get
		{
			return this.m_Data;
		}
	}

	// Token: 0x1700004C RID: 76
	// (get) Token: 0x0600075D RID: 1885 RVA: 0x000A227C File Offset: 0x000A047C
	public TKey[] Keys
	{
		get
		{
			return this.m_Key;
		}
	}

	// Token: 0x04001B83 RID: 7043
	private int[] m_HashCode;

	// Token: 0x04001B84 RID: 7044
	private TKey[] m_Key;

	// Token: 0x04001B85 RID: 7045
	private TValue[] m_Data;

	// Token: 0x04001B86 RID: 7046
	private int m_Count;
}
