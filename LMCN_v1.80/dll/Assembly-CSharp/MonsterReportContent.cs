using System;
using System.Runtime.InteropServices;

// Token: 0x020000F0 RID: 240
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class MonsterReportContent : MailReportHead
{
	// Token: 0x04000AC6 RID: 2758
	public ushort KindgomID;

	// Token: 0x04000AC7 RID: 2759
	public ushort Zone;

	// Token: 0x04000AC8 RID: 2760
	public byte Point;

	// Token: 0x04000AC9 RID: 2761
	public byte Result;

	// Token: 0x04000ACA RID: 2762
	public ushort Head;

	// Token: 0x04000ACB RID: 2763
	public ushort MonsterID;

	// Token: 0x04000ACC RID: 2764
	public byte MonsterLv;

	// Token: 0x04000ACD RID: 2765
	public uint BeginHPPercent;

	// Token: 0x04000ACE RID: 2766
	public uint EndHPPercent;

	// Token: 0x04000ACF RID: 2767
	public uint MonsterMaxHP;

	// Token: 0x04000AD0 RID: 2768
	public uint Exp;

	// Token: 0x04000AD1 RID: 2769
	public ushort[] HeroID;

	// Token: 0x04000AD2 RID: 2770
	public uint[] HeroExp;

	// Token: 0x04000AD3 RID: 2771
	public MonsterReportContent.HeroDataType[] HeroData;

	// Token: 0x04000AD4 RID: 2772
	public byte SequentialDamageTimes;

	// Token: 0x04000AD5 RID: 2773
	public byte EffectiveDamageTimes;

	// Token: 0x04000AD6 RID: 2774
	public MonsterReportContent.MonsterDataType AttrScale;

	// Token: 0x04000AD7 RID: 2775
	public ushort RandomSeed;

	// Token: 0x04000AD8 RID: 2776
	public byte RandomGap;

	// Token: 0x04000AD9 RID: 2777
	public uint Version;

	// Token: 0x04000ADA RID: 2778
	public uint PatchNo;

	// Token: 0x04000ADB RID: 2779
	public byte ItemLen;

	// Token: 0x04000ADC RID: 2780
	public MonsterReportContent.ItemDataType[] Item;

	// Token: 0x04000ADD RID: 2781
	public string AllianceTag;

	// Token: 0x020000F1 RID: 241
	public class MonsterDataType
	{
		// Token: 0x04000ADE RID: 2782
		public byte ActionTimes;

		// Token: 0x04000ADF RID: 2783
		public uint SequentialDamageScale;

		// Token: 0x04000AE0 RID: 2784
		public uint DamageScale;

		// Token: 0x04000AE1 RID: 2785
		public uint MaxHPScale;

		// Token: 0x04000AE2 RID: 2786
		public uint HealingScale;

		// Token: 0x04000AE3 RID: 2787
		public ushort InitMP;
	}

	// Token: 0x020000F2 RID: 242
	public class HeroDataType
	{
		// Token: 0x04000AE4 RID: 2788
		public byte SkillLV1;

		// Token: 0x04000AE5 RID: 2789
		public byte SkillLV2;

		// Token: 0x04000AE6 RID: 2790
		public byte SkillLV3;

		// Token: 0x04000AE7 RID: 2791
		public byte SkillLV4;

		// Token: 0x04000AE8 RID: 2792
		public byte LV;

		// Token: 0x04000AE9 RID: 2793
		public byte Star;

		// Token: 0x04000AEA RID: 2794
		public byte Enhance;

		// Token: 0x04000AEB RID: 2795
		public byte Equip;
	}

	// Token: 0x020000F3 RID: 243
	public class ItemDataType
	{
		// Token: 0x04000AEC RID: 2796
		public ushort ItemID;

		// Token: 0x04000AED RID: 2797
		public ushort Num;

		// Token: 0x04000AEE RID: 2798
		public byte ItemRank;
	}
}
