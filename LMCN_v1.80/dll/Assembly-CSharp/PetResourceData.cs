using System;

// Token: 0x0200044C RID: 1100
public class PetResourceData
{
	// Token: 0x170000A1 RID: 161
	// (get) Token: 0x06001619 RID: 5657 RVA: 0x0025A678 File Offset: 0x00258878
	// (set) Token: 0x0600161A RID: 5658 RVA: 0x0025A684 File Offset: 0x00258884
	public uint Stock
	{
		get
		{
			return (uint)this.CurrentStock;
		}
		set
		{
			this.CurrentStock = value;
		}
	}

	// Token: 0x0600161B RID: 5659 RVA: 0x0025A690 File Offset: 0x00258890
	public void SetResource(uint Val, long Speed)
	{
		this.CurrentStock = Val;
		this.Speed = Speed;
		this.SpeedInSec = (double)((float)Speed / 3600f);
		this.UpdateTime = 1.0;
	}

	// Token: 0x0600161C RID: 5660 RVA: 0x0025A6CC File Offset: 0x002588CC
	public byte Update(float delta)
	{
		if (this.Speed == 0L || (this.Speed > 0L && this.CurrentStock >= this.Capacity) || (this.Speed < 0L && this.CurrentStock <= 0.0))
		{
			return 0;
		}
		this.UpdateTime -= (double)delta;
		if (this.UpdateTime <= 0.0)
		{
			int num = (int)this.CurrentStock;
			if (this.SpeedInSec > 0.0)
			{
				this.CurrentStock = Math.Min(this.CurrentStock + this.SpeedInSec, this.Capacity);
			}
			else
			{
				this.CurrentStock = Math.Max(this.CurrentStock + this.SpeedInSec, 0.0);
			}
			this.UpdateTime += 1.0;
			if (Math.Abs((int)this.CurrentStock - num) > 0)
			{
				return 1;
			}
		}
		return 0;
	}

	// Token: 0x0600161D RID: 5661 RVA: 0x0025A7DC File Offset: 0x002589DC
	public void UpdateCapacity()
	{
		GATTR_ENUM type = GATTR_ENUM.EGE_PETRSS_CAPACITY;
		GATTR_ENUM type2 = GATTR_ENUM.EGE_PETRSS_CAPACITY_PERCENT;
		this.Capacity = 0u;
		this.Capacity += DataManager.Instance.AttribVal.GetEffectBaseVal(type);
		ulong num = (ulong)this.Capacity * (ulong)DataManager.Instance.AttribVal.GetEffectBaseVal(type2) / 10000UL;
		this.Capacity += (uint)num;
		GameManager.OnRefresh(NetworkNews.Refresh_PetResource, null);
	}

	// Token: 0x0600161E RID: 5662 RVA: 0x0025A854 File Offset: 0x00258A54
	public long GetSpeed()
	{
		return this.Speed;
	}

	// Token: 0x0600161F RID: 5663 RVA: 0x0025A85C File Offset: 0x00258A5C
	public static void DispatchResource(MessagePacket MP)
	{
		uint val = MP.ReadUInt(-1);
		long speed = MP.ReadLong(-1);
		DataManager.Instance.PetResource.SetResource(val, speed);
		GameManager.OnRefresh(NetworkNews.Refresh_PetResource, null);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetResourceStation, 1, 0);
	}

	// Token: 0x0400418B RID: 16779
	private const double UpdateTimer = 1.0;

	// Token: 0x0400418C RID: 16780
	public double CurrentStock;

	// Token: 0x0400418D RID: 16781
	public uint Capacity;

	// Token: 0x0400418E RID: 16782
	private long Speed;

	// Token: 0x0400418F RID: 16783
	private double SpeedInSec;

	// Token: 0x04004190 RID: 16784
	private double UpdateTime;

	// Token: 0x04004191 RID: 16785
	private ResourceType Type;
}
