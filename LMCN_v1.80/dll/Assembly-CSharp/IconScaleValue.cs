using System;

// Token: 0x020001EE RID: 494
internal struct IconScaleValue
{
	// Token: 0x06000904 RID: 2308 RVA: 0x000B7E6C File Offset: 0x000B606C
	public IconScaleValue(int i)
	{
		this.NowType = 1;
		this.selectSize = 1f;
		this.sliderSize = 82f;
		this.iconSize = 68f;
		this.time = 0f;
		this.colorA = 0f;
		this.bShowIconEffect = 0;
	}

	// Token: 0x04001DD7 RID: 7639
	public float selectSize;

	// Token: 0x04001DD8 RID: 7640
	public float iconSize;

	// Token: 0x04001DD9 RID: 7641
	public float sliderSize;

	// Token: 0x04001DDA RID: 7642
	public float time;

	// Token: 0x04001DDB RID: 7643
	public float colorA;

	// Token: 0x04001DDC RID: 7644
	public byte bShowIconEffect;

	// Token: 0x04001DDD RID: 7645
	public byte NowType;
}
