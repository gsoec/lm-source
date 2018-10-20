using System;

// Token: 0x02000754 RID: 1876
public class HUDQueueItem
{
	// Token: 0x06002417 RID: 9239 RVA: 0x0041DEC0 File Offset: 0x0041C0C0
	public HUDQueueItem()
	{
		this.Message = new CString[20];
		this.Type = new ushort[20];
	}

	// Token: 0x06002418 RID: 9240 RVA: 0x0041DEF0 File Offset: 0x0041C0F0
	private void CheckInit()
	{
		if (this.bInit == 0)
		{
			for (byte b = 0; b < 20; b += 1)
			{
				this.Message[(int)b] = StringManager.Instance.SpawnString(100);
			}
			this.Count = (this.PushIndex = this.PopIndex);
			this.bInit = 1;
		}
	}

	// Token: 0x06002419 RID: 9241 RVA: 0x0041DF4C File Offset: 0x0041C14C
	public void Destroy()
	{
		for (byte b = 0; b < 20; b += 1)
		{
			StringManager.Instance.DeSpawnString(this.Message[(int)b]);
			this.Message[(int)b] = null;
		}
		this.Count = 0;
		this.bInit = 0;
	}

	// Token: 0x0600241A RID: 9242 RVA: 0x0041DF98 File Offset: 0x0041C198
	public bool Push(string Msg, ushort Type)
	{
		this.CheckInit();
		if (this.Count == 20)
		{
			return false;
		}
		this.PushIndex %= 20;
		this.Message[(int)this.PushIndex].ClearString();
		this.Message[(int)this.PushIndex].Append(Msg);
		ushort[] type = this.Type;
		byte pushIndex;
		this.PushIndex = (pushIndex = this.PushIndex) + 1;
		type[(int)pushIndex] = Type;
		this.Count += 1;
		return true;
	}

	// Token: 0x0600241B RID: 9243 RVA: 0x0041E01C File Offset: 0x0041C21C
	public void Pop(out string Msg, out ushort Type)
	{
		this.CheckInit();
		if (this.Count == 0)
		{
			Msg = null;
			Type = 0;
			return;
		}
		this.PopIndex %= 20;
		Msg = this.Message[(int)this.PopIndex].ToString();
		ushort[] type = this.Type;
		byte popIndex;
		this.PopIndex = (popIndex = this.PopIndex) + 1;
		Type = type[(int)popIndex];
		this.Count -= 1;
	}

	// Token: 0x04006DFC RID: 28156
	public const byte QueueSize = 20;

	// Token: 0x04006DFD RID: 28157
	public byte Count;

	// Token: 0x04006DFE RID: 28158
	public byte PushIndex;

	// Token: 0x04006DFF RID: 28159
	public byte PopIndex;

	// Token: 0x04006E00 RID: 28160
	public CString[] Message;

	// Token: 0x04006E01 RID: 28161
	public ushort[] Type;

	// Token: 0x04006E02 RID: 28162
	private byte bInit;
}
