using System;
using System.Runtime.InteropServices;

// Token: 0x02000100 RID: 256
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class NoticeContent : MailReportHead
{
	// Token: 0x04000BBF RID: 3007
	public uint OffsetLen;

	// Token: 0x04000BC0 RID: 3008
	public NoticeReport Type;

	// Token: 0x04000BC1 RID: 3009
	public NoticeContent.Enhance NoticeHeroEnhance;

	// Token: 0x04000BC2 RID: 3010
	public NoticeContent.StarUp NoticeHeroStarUp;

	// Token: 0x04000BC3 RID: 3011
	public NoticeContent.JoinAlliance Notice_JoinAlliance;

	// Token: 0x04000BC4 RID: 3012
	public NoticeContent.ApplyAlliance Notice_ApplyAlliance;

	// Token: 0x04000BC5 RID: 3013
	public NoticeContent.ApplyAllianceBeDenied Notice_ApplyAllianceBeDenied;

	// Token: 0x04000BC6 RID: 3014
	public NoticeContent.AllianceDismiss Notice_AllianceDismiss;

	// Token: 0x04000BC7 RID: 3015
	public NoticeContent.AllianceLeaderStepDown Notice_AllianceLeaderStepDown;

	// Token: 0x04000BC8 RID: 3016
	public NoticeContent.ActivityDegreePrize Notice_ActivityDegreePrize;

	// Token: 0x04000BC9 RID: 3017
	public NoticeContent.ActivityRankPrize Notice_ActivityRankPrize;

	// Token: 0x04000BCA RID: 3018
	public NoticeContent.InviteAlliance Notice_InviteAlliance;

	// Token: 0x04000BCB RID: 3019
	public NoticeContent.SynLordEquip Notice_SynLordEquip;

	// Token: 0x04000BCC RID: 3020
	public NoticeContent.RallyNotice Notice_RallyNotice;

	// Token: 0x04000BCD RID: 3021
	public NoticeContent.CryptNotice Notice_CryptNotice;

	// Token: 0x04000BCE RID: 3022
	public NoticeContent.AsTargetAlly Notice_AsTargetAlly;

	// Token: 0x04000BCF RID: 3023
	public NoticeContent.OtherSavedLord Notice_OtherSavedLord;

	// Token: 0x04000BD0 RID: 3024
	public NoticeContent.LordBeingReleased Notice_LordBeingReleased;

	// Token: 0x04000BD1 RID: 3025
	public NoticeContent.LordBeingExecuted Notice_LordBeingExecuted;

	// Token: 0x04000BD2 RID: 3026
	public NoticeContent.OtherBreakPrison Notice_OtherBreakPrison;

	// Token: 0x04000BD3 RID: 3027
	public NoticeContent.RescuedPrisoner Notice_RescuedPrisoner;

	// Token: 0x04000BD4 RID: 3028
	public NoticeContent.RequestRansom Notice_RequestRansom;

	// Token: 0x04000BD5 RID: 3029
	public NoticeContent.ReceivedRansom Notice_ReceivedRansom;

	// Token: 0x04000BD6 RID: 3030
	public NoticeContent.PrisonFull Notice_PrisonFull;

	// Token: 0x04000BD7 RID: 3031
	public NoticeContent.BeQuitAlliance Notice_BeQuitAlliance;

	// Token: 0x04000BD8 RID: 3032
	public NoticeContent.BuyTreasure Notice_BuyTreasure;

	// Token: 0x04000BD9 RID: 3033
	public NoticeContent.RallyNotice_Moving Notice_RallyNotice_Moving;

	// Token: 0x04000BDA RID: 3034
	public NoticeContent.AtkFailedSelfShield Enotice_AtkFailedSelfShield;

	// Token: 0x04000BDB RID: 3035
	public NoticeContent.Gifts Enotice_RecivedGift;

	// Token: 0x04000BDC RID: 3036
	public NoticeContent.PrisonAmnestied Enotice_PrisonAmnestied;

	// Token: 0x04000BDD RID: 3037
	public NoticeContent.LordBeingAmnestied Enotice_LordBeingAmnestied;

	// Token: 0x04000BDE RID: 3038
	public NoticeContent.RulerGift Enotice_RulerGift;

	// Token: 0x04000BDF RID: 3039
	public NoticeContent.AllianceDismissLeader Enotice_DismissAllianceLeader;

	// Token: 0x04000BE0 RID: 3040
	public NoticeContent.Cantonment Enotice_AmbushDefSuccess;

	// Token: 0x04000BE1 RID: 3041
	public NoticeContent.Cantonment Enotice_AmbushDefFailed;

	// Token: 0x04000BE2 RID: 3042
	public NoticeContent.ActivityKVKDegreePrize Enotice_ActivityKVKDegreePrize;

	// Token: 0x04000BE3 RID: 3043
	public NoticeContent.ActivityKVKRankPrize Enotice_ActivityKVKRankPrize;

	// Token: 0x04000BE4 RID: 3044
	public NoticeContent.BuyTreasure Enotice_BuyBlackMarketTreasure;

	// Token: 0x04000BE5 RID: 3045
	public NoticeContent.KickOffTeam Enotice_KickOffTeam;

	// Token: 0x04000BE6 RID: 3046
	public NoticeContent.ActivityKVKRankPrize Enotice_AMRankPrize;

	// Token: 0x04000BE7 RID: 3047
	public NoticeContent.AllianceChangeHomeKingdom Enotice_AllianceHomeKingdom;

	// Token: 0x04000BE8 RID: 3048
	public NoticeContent.WorldKingPrize Enotice_WorldKingPrize;

	// Token: 0x04000BE9 RID: 3049
	public NoticeContent.AddCrystal Enotice_BackendAddCrystal;

	// Token: 0x04000BEA RID: 3050
	public NoticeContent.AddCrystal Enotice_LoginConpensate;

	// Token: 0x04000BEB RID: 3051
	public NoticeContent.AddCrystal Enotice_PurchaseConpensate;

	// Token: 0x04000BEC RID: 3052
	public NoticeContent.RallyNpcCancel Enotice_RallyNPCCancel;

	// Token: 0x04000BED RID: 3053
	public NoticeContent.RallyNpcCancel Enotice_RallyNPCCancelInvalid;

	// Token: 0x04000BEE RID: 3054
	public NoticeContent.LordEquipExpire Enotice_LordEquipExpire;

	// Token: 0x04000BEF RID: 3055
	public NoticeContent.WorldKingPrize_NotKing Enotice_WorldNotKingPrize;

	// Token: 0x04000BF0 RID: 3056
	public NoticeContent.BuyEmoteTreasure Enotice_BuyEmoteTreasure;

	// Token: 0x04000BF1 RID: 3057
	public NoticeContent.PrisonerUsePoison Enotice_PrisnerUsePoison;

	// Token: 0x04000BF2 RID: 3058
	public NoticeContent.PrisonerPoisonEffect Enotice_PrisnerPoisonEffect;

	// Token: 0x04000BF3 RID: 3059
	public NoticeContent.BackendActivity Enotice_BackendActivity;

	// Token: 0x04000BF4 RID: 3060
	public NoticeContent.BuyCastleSkinreasure Enotice_BuyCastleSkinTreasure;

	// Token: 0x04000BF5 RID: 3061
	public NoticeContent.WorldKingPrize_NotKing Enotice_FederalRankPrize;

	// Token: 0x04000BF6 RID: 3062
	public NoticeContent.BuyTreasure Enotice_TreasureBackPrize;

	// Token: 0x04000BF7 RID: 3063
	public NoticeContent.LookingForStringTable Enotice_LookingForStringTable;

	// Token: 0x04000BF8 RID: 3064
	public NoticeContent.MarchingPet_Cancel Enotice_MarchingPet_Cancel;

	// Token: 0x04000BF9 RID: 3065
	public NoticeContent.PetStarUp ENotice_PetStarUp;

	// Token: 0x04000BFA RID: 3066
	public NoticeContent.PetSkillEscaped ENotice_PrisonerPetSkillEscaped;

	// Token: 0x04000BFB RID: 3067
	public NoticeContent.PetSkillEscaped ENotice_LordPetSkillEscaped;

	// Token: 0x04000BFC RID: 3068
	public NoticeContent.MarchTargetLeave Enotice_ScoutTargetLeave;

	// Token: 0x04000BFD RID: 3069
	public NoticeContent.MarchTargetLeave Enotice_AttackTargetLeave;

	// Token: 0x04000BFE RID: 3070
	public NoticeContent.MaintainCompensation Enotice_MaintainCompensation;

	// Token: 0x04000BFF RID: 3071
	public NoticeContent.BuyRedPocketTreasure Enotice_BuyRedPocketTreasure;

	// Token: 0x04000C00 RID: 3072
	public NoticeContent.SocialFriendMail Enotice_SocialFriendModify;

	// Token: 0x04000C01 RID: 3073
	public NoticeContent.ReturnCeremony Enotice_ReturnCeremony;

	// Token: 0x04000C02 RID: 3074
	public NoticeContent.ReturnCeremony Enotice_FirstBuyTreasurePrize;

	// Token: 0x02000101 RID: 257
	public class Enhance
	{
		// Token: 0x04000C03 RID: 3075
		public ushort HeroID;

		// Token: 0x04000C04 RID: 3076
		public byte Rank;

		// Token: 0x04000C05 RID: 3077
		public byte Star;
	}

	// Token: 0x02000102 RID: 258
	public class StarUp
	{
		// Token: 0x04000C06 RID: 3078
		public ushort HeroID;

		// Token: 0x04000C07 RID: 3079
		public byte Star;

		// Token: 0x04000C08 RID: 3080
		public byte Rank;
	}

	// Token: 0x02000103 RID: 259
	public class JoinAlliance
	{
		// Token: 0x04000C09 RID: 3081
		public string Name;

		// Token: 0x04000C0A RID: 3082
		public string Tag;
	}

	// Token: 0x02000104 RID: 260
	public class ApplyAlliance
	{
		// Token: 0x04000C0B RID: 3083
		public string Name;

		// Token: 0x04000C0C RID: 3084
		public string Tag;
	}

	// Token: 0x02000105 RID: 261
	public class ApplyAllianceBeDenied
	{
		// Token: 0x04000C0D RID: 3085
		public string Dealer;

		// Token: 0x04000C0E RID: 3086
		public string Name;

		// Token: 0x04000C0F RID: 3087
		public string Tag;
	}

	// Token: 0x02000106 RID: 262
	public class AllianceDismiss
	{
		// Token: 0x04000C10 RID: 3088
		public string Leader;
	}

	// Token: 0x02000107 RID: 263
	public class AllianceLeaderStepDown
	{
		// Token: 0x04000C11 RID: 3089
		public string OldLeader;

		// Token: 0x04000C12 RID: 3090
		public string NewLeader;
	}

	// Token: 0x02000108 RID: 264
	public class ActivityDegreePrize
	{
		// Token: 0x04000C13 RID: 3091
		public byte Degree;

		// Token: 0x04000C14 RID: 3092
		public byte PrizeNum;

		// Token: 0x04000C15 RID: 3093
		public NoticeContent.ActPrize[] PrizeData;

		// Token: 0x04000C16 RID: 3094
		public NoticeContent.ActivityCircleEventType Type;
	}

	// Token: 0x02000109 RID: 265
	public enum ActivityCircleEventType : byte
	{
		// Token: 0x04000C18 RID: 3096
		EACET_SoloEvent,
		// Token: 0x04000C19 RID: 3097
		EACET_InfernalEvent,
		// Token: 0x04000C1A RID: 3098
		EACET_MAX
	}

	// Token: 0x0200010A RID: 266
	public struct ActPrize
	{
		// Token: 0x04000C1B RID: 3099
		public byte Rank;

		// Token: 0x04000C1C RID: 3100
		public ushort ItemID;

		// Token: 0x04000C1D RID: 3101
		public byte Num;
	}

	// Token: 0x0200010B RID: 267
	public class ActivityRankPrize
	{
		// Token: 0x04000C1E RID: 3102
		public byte Place;

		// Token: 0x04000C1F RID: 3103
		public byte PrizeNum;

		// Token: 0x04000C20 RID: 3104
		public NoticeContent.ActPrize[] PrizeData;

		// Token: 0x04000C21 RID: 3105
		public NoticeContent.ActivityCircleEventType Type;
	}

	// Token: 0x0200010C RID: 268
	public class InviteAlliance
	{
		// Token: 0x04000C22 RID: 3106
		public uint AllianceID;

		// Token: 0x04000C23 RID: 3107
		public string InviterName;

		// Token: 0x04000C24 RID: 3108
		public string Name;

		// Token: 0x04000C25 RID: 3109
		public string Tag;
	}

	// Token: 0x0200010D RID: 269
	public class SynLordEquip
	{
		// Token: 0x04000C26 RID: 3110
		public ushort ItemID;

		// Token: 0x04000C27 RID: 3111
		public byte Rank;

		// Token: 0x04000C28 RID: 3112
		public uint AddExp;
	}

	// Token: 0x0200010E RID: 270
	public class RallyNotice
	{
		// Token: 0x04000C29 RID: 3113
		public string HostName;

		// Token: 0x04000C2A RID: 3114
		public string HostTag;

		// Token: 0x04000C2B RID: 3115
		public string TargetName;

		// Token: 0x04000C2C RID: 3116
		public string TargetTag;
	}

	// Token: 0x0200010F RID: 271
	public class CryptNotice
	{
		// Token: 0x04000C2D RID: 3117
		public ushort Money;

		// Token: 0x04000C2E RID: 3118
		public byte Kind;

		// Token: 0x04000C2F RID: 3119
		public byte Level;
	}

	// Token: 0x02000110 RID: 272
	public class AsTargetAlly
	{
		// Token: 0x04000C30 RID: 3120
		public string HostName;

		// Token: 0x04000C31 RID: 3121
		public string HostTag;

		// Token: 0x04000C32 RID: 3122
		public string TargetName;
	}

	// Token: 0x02000111 RID: 273
	public class OtherSavedLord
	{
		// Token: 0x04000C33 RID: 3123
		public ushort HomeKingdom;

		// Token: 0x04000C34 RID: 3124
		public string AllianceTag;

		// Token: 0x04000C35 RID: 3125
		public string Name;
	}

	// Token: 0x02000112 RID: 274
	public class LordBeingReleased
	{
		// Token: 0x04000C36 RID: 3126
		public ushort HomeKingdom;

		// Token: 0x04000C37 RID: 3127
		public string AllianceTag;

		// Token: 0x04000C38 RID: 3128
		public string Name;
	}

	// Token: 0x02000113 RID: 275
	public class LordBeingExecuted
	{
		// Token: 0x04000C39 RID: 3129
		public ushort HomeKingdom;

		// Token: 0x04000C3A RID: 3130
		public string AllianceTag;

		// Token: 0x04000C3B RID: 3131
		public string Name;
	}

	// Token: 0x02000114 RID: 276
	public class OtherBreakPrison
	{
		// Token: 0x04000C3C RID: 3132
		public ushort HomeKingdom;

		// Token: 0x04000C3D RID: 3133
		public string AllianceTag;

		// Token: 0x04000C3E RID: 3134
		public string Name;
	}

	// Token: 0x02000115 RID: 277
	public class RescuedPrisoner
	{
		// Token: 0x04000C3F RID: 3135
		public ushort HomeKingdom;

		// Token: 0x04000C40 RID: 3136
		public string AllianceTag;

		// Token: 0x04000C41 RID: 3137
		public string Name;

		// Token: 0x04000C42 RID: 3138
		public byte PrisonerNum;

		// Token: 0x04000C43 RID: 3139
		public uint ClaimReward;
	}

	// Token: 0x02000116 RID: 278
	public class RequestRansom
	{
		// Token: 0x04000C44 RID: 3140
		public uint Ransom;
	}

	// Token: 0x02000117 RID: 279
	public class ReceivedRansom
	{
		// Token: 0x04000C45 RID: 3141
		public uint Ransom;
	}

	// Token: 0x02000118 RID: 280
	public class PrisonFull
	{
		// Token: 0x04000C46 RID: 3142
		public ushort HomeKingdom;

		// Token: 0x04000C47 RID: 3143
		public string AllianceTag;

		// Token: 0x04000C48 RID: 3144
		public string Name;
	}

	// Token: 0x02000119 RID: 281
	public class BeQuitAlliance
	{
		// Token: 0x04000C49 RID: 3145
		public string Dealer;

		// Token: 0x04000C4A RID: 3146
		public string Alliance;

		// Token: 0x04000C4B RID: 3147
		public string AllianceTag;
	}

	// Token: 0x0200011A RID: 282
	public class TreasureAllianceGift
	{
		// Token: 0x04000C4C RID: 3148
		public ushort ItemID;

		// Token: 0x04000C4D RID: 3149
		public ushort ItemNum;
	}

	// Token: 0x0200011B RID: 283
	public class ComboBoxTBItem
	{
		// Token: 0x04000C4E RID: 3150
		public ushort ItemID;

		// Token: 0x04000C4F RID: 3151
		public ushort ItemNum;

		// Token: 0x04000C50 RID: 3152
		public byte ItemRank;
	}

	// Token: 0x0200011C RID: 284
	public class BuyTreasure
	{
		// Token: 0x04000C51 RID: 3153
		public uint Crystal;

		// Token: 0x04000C52 RID: 3154
		public uint BonusCrystal;

		// Token: 0x04000C53 RID: 3155
		public NoticeContent.TreasureAllianceGift[] Gift;

		// Token: 0x04000C54 RID: 3156
		public byte ItemNum;

		// Token: 0x04000C55 RID: 3157
		public NoticeContent.ComboBoxTBItem[] Item;

		// Token: 0x04000C56 RID: 3158
		public byte GiftTop;
	}

	// Token: 0x0200011D RID: 285
	public class RallyNotice_Moving
	{
		// Token: 0x04000C57 RID: 3159
		public string HostName;

		// Token: 0x04000C58 RID: 3160
		public string HostTag;

		// Token: 0x04000C59 RID: 3161
		public string TargetName;

		// Token: 0x04000C5A RID: 3162
		public string TargetTag;
	}

	// Token: 0x0200011E RID: 286
	public class AtkFailedSelfShield
	{
		// Token: 0x04000C5B RID: 3163
		public byte FailedType;

		// Token: 0x04000C5C RID: 3164
		public ushort KingdomID;

		// Token: 0x04000C5D RID: 3165
		public ushort zoneID;

		// Token: 0x04000C5E RID: 3166
		public byte pointID;
	}

	// Token: 0x0200011F RID: 287
	public class Gifts
	{
		// Token: 0x04000C5F RID: 3167
		public string GiftsName;

		// Token: 0x04000C60 RID: 3168
		public string GiftsTag;

		// Token: 0x04000C61 RID: 3169
		public NoticeContent.TreasureAllianceGift Item;
	}

	// Token: 0x02000120 RID: 288
	public class LordBeingAmnestied
	{
		// Token: 0x04000C62 RID: 3170
		public ushort KingsHomeKingdom;

		// Token: 0x04000C63 RID: 3171
		public string KingdomTag;

		// Token: 0x04000C64 RID: 3172
		public string KingdomName;

		// Token: 0x04000C65 RID: 3173
		public ushort WardensHomeKingdom;

		// Token: 0x04000C66 RID: 3174
		public string Tag;

		// Token: 0x04000C67 RID: 3175
		public string Name;
	}

	// Token: 0x02000121 RID: 289
	public class PrisonAmnestied
	{
		// Token: 0x04000C68 RID: 3176
		public ushort KingsHomeKingdom;

		// Token: 0x04000C69 RID: 3177
		public string KingdomTag;

		// Token: 0x04000C6A RID: 3178
		public string KingdomName;
	}

	// Token: 0x02000122 RID: 290
	public class RulerGift
	{
		// Token: 0x04000C6B RID: 3179
		public byte RulerKind;

		// Token: 0x04000C6C RID: 3180
		public ushort RulerAllianceKingdomID;

		// Token: 0x04000C6D RID: 3181
		public string Tag;

		// Token: 0x04000C6E RID: 3182
		public string Name;

		// Token: 0x04000C6F RID: 3183
		public byte GiftKindNum;

		// Token: 0x04000C70 RID: 3184
		public NoticeContent.TreasureAllianceGift[] Gifts;
	}

	// Token: 0x02000123 RID: 291
	public class AllianceDismissLeader
	{
		// Token: 0x04000C71 RID: 3185
		public string OldLeader;

		// Token: 0x04000C72 RID: 3186
		public string NewLeader;

		// Token: 0x04000C73 RID: 3187
		public byte OffLineDay;
	}

	// Token: 0x02000124 RID: 292
	public class Cantonment
	{
		// Token: 0x04000C74 RID: 3188
		public string AmbushName;

		// Token: 0x04000C75 RID: 3189
		public ushort AtkPlayerHomeKingdom;

		// Token: 0x04000C76 RID: 3190
		public string AtkPlayerAllianceTag;

		// Token: 0x04000C77 RID: 3191
		public string AtkPlayerName;
	}

	// Token: 0x02000125 RID: 293
	public class ActivityKVKDegreePrize
	{
		// Token: 0x04000C78 RID: 3192
		public EActivityType ActType;

		// Token: 0x04000C79 RID: 3193
		public EActivityKingdomEventType EventType;

		// Token: 0x04000C7A RID: 3194
		public byte Degree;

		// Token: 0x04000C7B RID: 3195
		public byte PrizeNum;

		// Token: 0x04000C7C RID: 3196
		public NoticeContent.ActPrize[] PrizeData;
	}

	// Token: 0x02000126 RID: 294
	public class ActivityKVKRankPrize
	{
		// Token: 0x04000C7D RID: 3197
		public EActivityType ActType;

		// Token: 0x04000C7E RID: 3198
		public EActivityKingdomEventType EventType;

		// Token: 0x04000C7F RID: 3199
		public byte Place;

		// Token: 0x04000C80 RID: 3200
		public byte PrizeNum;

		// Token: 0x04000C81 RID: 3201
		public NoticeContent.ActPrize[] PrizeData;
	}

	// Token: 0x02000127 RID: 295
	public class KickOffTeam
	{
		// Token: 0x04000C82 RID: 3202
		public string HostName;

		// Token: 0x04000C83 RID: 3203
		public string AllianceTag;
	}

	// Token: 0x02000128 RID: 296
	public class AllianceChangeHomeKingdom
	{
		// Token: 0x04000C84 RID: 3204
		public string AllianceTag;

		// Token: 0x04000C85 RID: 3205
		public string Leader;

		// Token: 0x04000C86 RID: 3206
		public ushort HomeKingdom;
	}

	// Token: 0x02000129 RID: 297
	public class WorldKingPrize
	{
		// Token: 0x04000C87 RID: 3207
		public byte PrizeNum;

		// Token: 0x04000C88 RID: 3208
		public NoticeContent.ActPrize[] PrizeData;
	}

	// Token: 0x0200012A RID: 298
	public class AddCrystal
	{
		// Token: 0x04000C89 RID: 3209
		public uint Crystal;
	}

	// Token: 0x0200012B RID: 299
	public class RallyNpcCancel
	{
		// Token: 0x04000C8A RID: 3210
		public string HostName;

		// Token: 0x04000C8B RID: 3211
		public string AllianceTag;

		// Token: 0x04000C8C RID: 3212
		public byte NPCLevel;

		// Token: 0x04000C8D RID: 3213
		public ushort NPCID;
	}

	// Token: 0x0200012C RID: 300
	public class LordEquipExpire
	{
		// Token: 0x04000C8E RID: 3214
		public ushort ItemID;

		// Token: 0x04000C8F RID: 3215
		public byte Rank;
	}

	// Token: 0x0200012D RID: 301
	public class WorldKingPrize_NotKing
	{
		// Token: 0x04000C90 RID: 3216
		public byte Place;

		// Token: 0x04000C91 RID: 3217
		public byte PrizeNum;

		// Token: 0x04000C92 RID: 3218
		public NoticeContent.ActPrize[] PrizeData;
	}

	// Token: 0x0200012E RID: 302
	public class BuyEmoteTreasure
	{
		// Token: 0x04000C93 RID: 3219
		public ushort ItemID;

		// Token: 0x04000C94 RID: 3220
		public byte ItemNum;
	}

	// Token: 0x0200012F RID: 303
	public class PrisonerUsePoison
	{
		// Token: 0x04000C95 RID: 3221
		public ushort HomeKingdom;

		// Token: 0x04000C96 RID: 3222
		public string AllianceTag;

		// Token: 0x04000C97 RID: 3223
		public string Name;

		// Token: 0x04000C98 RID: 3224
		public uint EffectTime;
	}

	// Token: 0x02000130 RID: 304
	public class PrisonerPoisonEffect
	{
		// Token: 0x04000C99 RID: 3225
		public ushort HomeKingdom;

		// Token: 0x04000C9A RID: 3226
		public string AllianceTag;

		// Token: 0x04000C9B RID: 3227
		public string Name;
	}

	// Token: 0x02000131 RID: 305
	public class BackendActivity
	{
		// Token: 0x04000C9C RID: 3228
		public uint Crystal;

		// Token: 0x04000C9D RID: 3229
		public byte ItemNum;

		// Token: 0x04000C9E RID: 3230
		public NoticeContent.ComboBoxTBItem[] Item;
	}

	// Token: 0x02000132 RID: 306
	public class BuyCastleSkinreasure
	{
		// Token: 0x04000C9F RID: 3231
		public ushort CastleSkinID;

		// Token: 0x04000CA0 RID: 3232
		public ushort ItemID;

		// Token: 0x04000CA1 RID: 3233
		public byte ItemNum;
	}

	// Token: 0x02000133 RID: 307
	public class MarchingPet_Cancel
	{
		// Token: 0x04000CA2 RID: 3234
		public byte HasTarget;

		// Token: 0x04000CA3 RID: 3235
		public ushort HomeKingdom;

		// Token: 0x04000CA4 RID: 3236
		public string AllianceTag;

		// Token: 0x04000CA5 RID: 3237
		public string Name;

		// Token: 0x04000CA6 RID: 3238
		public ushort PetID;

		// Token: 0x04000CA7 RID: 3239
		public ushort Skill_ID;

		// Token: 0x04000CA8 RID: 3240
		public byte Skill_LV;
	}

	// Token: 0x02000134 RID: 308
	public class LookingForStringTable
	{
		// Token: 0x04000CA9 RID: 3241
		public uint Title;

		// Token: 0x04000CAA RID: 3242
		public uint Content;
	}

	// Token: 0x02000135 RID: 309
	public class PetSkillEscaped
	{
		// Token: 0x04000CAB RID: 3243
		public ushort PetID;

		// Token: 0x04000CAC RID: 3244
		public ushort Skill_ID;

		// Token: 0x04000CAD RID: 3245
		public byte Skill_LV;
	}

	// Token: 0x02000136 RID: 310
	public class PetStarUp
	{
		// Token: 0x04000CAE RID: 3246
		public ushort PetID;

		// Token: 0x04000CAF RID: 3247
		public byte PetStar;
	}

	// Token: 0x02000137 RID: 311
	public class MarchTargetLeave
	{
		// Token: 0x04000CB0 RID: 3248
		public uint OffsetLen;

		// Token: 0x04000CB1 RID: 3249
		public ushort HomeKingdom;

		// Token: 0x04000CB2 RID: 3250
		public string AllianceTag;

		// Token: 0x04000CB3 RID: 3251
		public string Name;
	}

	// Token: 0x02000138 RID: 312
	public class MaintainCompensation
	{
		// Token: 0x04000CB4 RID: 3252
		public ushort MailTitleStrID;

		// Token: 0x04000CB5 RID: 3253
		public ushort MailContentStrID;

		// Token: 0x04000CB6 RID: 3254
		public uint Crystal;

		// Token: 0x04000CB7 RID: 3255
		public byte ItemNum;

		// Token: 0x04000CB8 RID: 3256
		public NoticeContent.ComboBoxTBItem[] Item;
	}

	// Token: 0x02000139 RID: 313
	public class BuyRedPocketTreasure
	{
		// Token: 0x04000CB9 RID: 3257
		public ushort StringID;
	}

	// Token: 0x0200013A RID: 314
	public class SocialFriendMail
	{
		// Token: 0x04000CBA RID: 3258
		public byte RemoveType;

		// Token: 0x04000CBB RID: 3259
		public string TargetName;

		// Token: 0x04000CBC RID: 3260
		public string PlayerName;

		// Token: 0x04000CBD RID: 3261
		public string PlayerTag;
	}

	// Token: 0x0200013B RID: 315
	public class ReturnCeremony
	{
		// Token: 0x04000CBE RID: 3262
		public uint Crystal;

		// Token: 0x04000CBF RID: 3263
		public byte ItemNum;

		// Token: 0x04000CC0 RID: 3264
		public NoticeContent.ComboBoxTBItem[] Item;
	}
}
