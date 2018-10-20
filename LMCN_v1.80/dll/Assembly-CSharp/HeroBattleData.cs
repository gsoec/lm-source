using System;
using System.Runtime.InteropServices;

// Token: 0x020000CD RID: 205
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HeroBattleData
{
	// Token: 0x060002CB RID: 715 RVA: 0x0002754C File Offset: 0x0002574C
	public HeroBattleData(ArenaHeroDataType ah)
	{
		this.HeroID = ah.ID;
		this.AttrData = default(CalcAttrDataType);
		this.AttrData.LV = ah.Level;
		this.AttrData.Star = ah.Star;
		this.AttrData.Enhance = ah.Rank;
		this.AttrData.Equip = ah.Equip;
		if (ah.SkillLV != null && ah.SkillLV.Length == 4)
		{
			this.AttrData.SkillLV1 = ah.SkillLV[0];
			this.AttrData.SkillLV2 = ah.SkillLV[1];
			this.AttrData.SkillLV3 = ah.SkillLV[2];
			this.AttrData.SkillLV4 = ah.SkillLV[3];
		}
	}

	// Token: 0x0400093E RID: 2366
	public ushort HeroID;

	// Token: 0x0400093F RID: 2367
	public CalcAttrDataType AttrData;
}
