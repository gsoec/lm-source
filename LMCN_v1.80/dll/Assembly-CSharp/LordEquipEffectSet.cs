using System;

// Token: 0x020003BA RID: 954
public class LordEquipEffectSet
{
	// Token: 0x060013A0 RID: 5024 RVA: 0x0022E8AC File Offset: 0x0022CAAC
	public LordEquipEffectSet()
	{
		this.EffectID = 0;
		this.EffectValue = 0;
		this.isNewGemEffect = 0;
		this.FromPart = 0;
	}

	// Token: 0x04003C22 RID: 15394
	public ushort EffectID;

	// Token: 0x04003C23 RID: 15395
	public ushort EffectValue;

	// Token: 0x04003C24 RID: 15396
	public byte isNewGemEffect;

	// Token: 0x04003C25 RID: 15397
	public byte FromPart;
}
