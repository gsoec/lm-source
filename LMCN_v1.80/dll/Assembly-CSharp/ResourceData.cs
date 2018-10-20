using System;

// Token: 0x02000142 RID: 322
public class ResourceData
{
	// Token: 0x0600033E RID: 830 RVA: 0x00028870 File Offset: 0x00026A70
	public ResourceData(ResourceType Type)
	{
		this.Type = Type;
	}

	// Token: 0x1700002F RID: 47
	// (get) Token: 0x0600033F RID: 831 RVA: 0x00028880 File Offset: 0x00026A80
	// (set) Token: 0x06000340 RID: 832 RVA: 0x0002888C File Offset: 0x00026A8C
	public uint Stock
	{
		get
		{
			return (uint)this.CurrentStock;
		}
		set
		{
			this.CurrentStock = value;
			GUIManager.Instance.BuildingData.UpdateLevelupResource();
		}
	}

	// Token: 0x06000341 RID: 833 RVA: 0x000288A8 File Offset: 0x00026AA8
	public void SetResource(uint Val, long Speed)
	{
		this.CurrentStock = Val;
		this.Speed = Speed;
		this.SpeedInSec = (double)((float)Speed / 3600f);
		this.UpdateTime = 1.0;
		GUIManager.Instance.BuildingData.UpdateLevelupResource();
	}

	// Token: 0x06000342 RID: 834 RVA: 0x000288E8 File Offset: 0x00026AE8
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

	// Token: 0x06000343 RID: 835 RVA: 0x000289F8 File Offset: 0x00026BF8
	public void UpdateCapacity()
	{
		GATTR_ENUM type = GATTR_ENUM.EGA_FOOD_CAPACITY;
		GATTR_ENUM type2 = GATTR_ENUM.EGE_FOOD_CAPACITY_PERCENT;
		this.Capacity = 15000u;
		switch (this.Type)
		{
		case ResourceType.Grain:
			type = GATTR_ENUM.EGA_FOOD_CAPACITY;
			type2 = GATTR_ENUM.EGE_FOOD_CAPACITY_PERCENT;
			break;
		case ResourceType.Rock:
			type = GATTR_ENUM.EGA_ROCK_CAPACITY;
			type2 = GATTR_ENUM.EGE_ROCK_CAPACITY_PERCENT;
			break;
		case ResourceType.Wood:
			type = GATTR_ENUM.EGA_WOOD_CAPACITY;
			type2 = GATTR_ENUM.EGE_WOOD_CAPACITY_PERCENT;
			break;
		case ResourceType.Steel:
			type = GATTR_ENUM.EGA_STEEL_CAPACITY;
			type2 = GATTR_ENUM.EGE_STEEL_CAPACITY_PERCENT;
			break;
		case ResourceType.Money:
			type = GATTR_ENUM.EGA_MONEY_CAPACITY;
			type2 = GATTR_ENUM.EGE_MONEY_CAPACITY_PERCENT;
			break;
		}
		this.Capacity += DataManager.Instance.AttribVal.GetEffectBaseVal(type);
		ulong num = (ulong)this.Capacity * (ulong)DataManager.Instance.AttribVal.GetEffectBaseVal(type2) / 10000UL;
		this.Capacity += (uint)num;
		GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
	}

	// Token: 0x06000344 RID: 836 RVA: 0x00028ADC File Offset: 0x00026CDC
	public long GetSpeed()
	{
		return this.Speed;
	}

	// Token: 0x04000D17 RID: 3351
	private const double UpdateTimer = 1.0;

	// Token: 0x04000D18 RID: 3352
	public double CurrentStock;

	// Token: 0x04000D19 RID: 3353
	public uint Capacity;

	// Token: 0x04000D1A RID: 3354
	private long Speed;

	// Token: 0x04000D1B RID: 3355
	private double SpeedInSec;

	// Token: 0x04000D1C RID: 3356
	private double UpdateTime;

	// Token: 0x04000D1D RID: 3357
	private ResourceType Type;
}
