using System;

// Token: 0x0200077C RID: 1916
public sealed class Buffer<T> where T : struct
{
	// Token: 0x06002574 RID: 9588 RVA: 0x0042B944 File Offset: 0x00429B44
	public Buffer(T[] Data, int off, int len)
	{
		this.Data = Data;
		this.offset = off;
		this.count = len;
	}

	// Token: 0x06002575 RID: 9589 RVA: 0x0042B964 File Offset: 0x00429B64
	public Buffer(int len)
	{
		this.Data = new T[len];
		this.offset = 0;
		this.count = len;
		this.outlaw = true;
	}

	// Token: 0x170000FA RID: 250
	// (get) Token: 0x06002576 RID: 9590 RVA: 0x0042B990 File Offset: 0x00429B90
	public int EOB
	{
		get
		{
			return this.offset + this.count;
		}
	}

	// Token: 0x170000FB RID: 251
	public T this[int index]
	{
		get
		{
			if (index >= 0 && index < this.count)
			{
				return this.Data[this.offset + index];
			}
			return default(T);
		}
		set
		{
			if (index >= 0 && index < this.count)
			{
				this.Data[this.offset + index] = value;
				return;
			}
		}
	}

	// Token: 0x06002579 RID: 9593 RVA: 0x0042BA10 File Offset: 0x00429C10
	public T[] GetBuffer()
	{
		return this.Data;
	}

	// Token: 0x0600257A RID: 9594 RVA: 0x0042BA18 File Offset: 0x00429C18
	public int GetIndex(int idx = 0)
	{
		return this.offset + ((idx >= this.count) ? 0 : idx);
	}

	// Token: 0x0400700A RID: 28682
	private readonly int offset;

	// Token: 0x0400700B RID: 28683
	private readonly int count;

	// Token: 0x0400700C RID: 28684
	public readonly bool outlaw;

	// Token: 0x0400700D RID: 28685
	private T[] Data;
}
