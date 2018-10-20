using System;

// Token: 0x020003BB RID: 955
public class LordEquipEffectCompareSet
{
	// Token: 0x060013A1 RID: 5025 RVA: 0x0022E8DC File Offset: 0x0022CADC
	public LordEquipEffectCompareSet(ushort EffectID, int EffectValue, bool isEven, byte group = 0, bool isTitel = false, byte isNewGemEffect = 0)
	{
		this.EffectID = EffectID;
		this.EffectValue = EffectValue;
		this.isEven = isEven;
		this.group = group;
		this.isTitel = isTitel;
		this.isNewGemEffect = isNewGemEffect;
	}

	// Token: 0x060013A2 RID: 5026 RVA: 0x0022E914 File Offset: 0x0022CB14
	public LordEquipEffectCompareSet(LordEquipEffectSet set)
	{
		this.EffectID = set.EffectID;
		this.EffectValue = (int)set.EffectValue;
		this.isNewGemEffect = set.isNewGemEffect;
		this.fromPart = set.FromPart;
		this.isEven = true;
	}

	// Token: 0x04003C26 RID: 15398
	public ushort EffectID;

	// Token: 0x04003C27 RID: 15399
	public int EffectValue;

	// Token: 0x04003C28 RID: 15400
	public bool isEven;

	// Token: 0x04003C29 RID: 15401
	public byte group;

	// Token: 0x04003C2A RID: 15402
	public bool isTitel;

	// Token: 0x04003C2B RID: 15403
	public byte isNewGemEffect;

	// Token: 0x04003C2C RID: 15404
	public byte onCompareNewSide;

	// Token: 0x04003C2D RID: 15405
	public byte useForceColor;

	// Token: 0x04003C2E RID: 15406
	public byte fromPart;
}
