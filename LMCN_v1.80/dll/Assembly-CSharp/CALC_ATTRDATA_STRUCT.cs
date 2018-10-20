using System;

// Token: 0x020001A5 RID: 421
public struct CALC_ATTRDATA_STRUCT
{
	// Token: 0x060005E4 RID: 1508 RVA: 0x00082198 File Offset: 0x00080398
	private CALC_ATTRDATA_STRUCT(byte tmp)
	{
		this.SkillLV = new byte[4];
		this.LV = 0;
		this.Star = 0;
		this.Enhance = 0;
		this.Equip = 0;
	}

	// Token: 0x04001842 RID: 6210
	public byte[] SkillLV;

	// Token: 0x04001843 RID: 6211
	public byte LV;

	// Token: 0x04001844 RID: 6212
	public byte Star;

	// Token: 0x04001845 RID: 6213
	public byte Enhance;

	// Token: 0x04001846 RID: 6214
	public byte Equip;
}
