using System;

// Token: 0x020000FF RID: 255
public enum NoticeReport : byte
{
	// Token: 0x04000B68 RID: 2920
	ENotice_Enhance,
	// Token: 0x04000B69 RID: 2921
	ENotice_StarUp,
	// Token: 0x04000B6A RID: 2922
	ENotice_JoinAlliance,
	// Token: 0x04000B6B RID: 2923
	Enotice_ApplyAlliance,
	// Token: 0x04000B6C RID: 2924
	Enotice_ApplyAllianceBeDenied,
	// Token: 0x04000B6D RID: 2925
	Enotice_AllianceDismiss,
	// Token: 0x04000B6E RID: 2926
	Enotice_AllianceLeaderStepDown,
	// Token: 0x04000B6F RID: 2927
	Enotice_ActivityDegreePrize,
	// Token: 0x04000B70 RID: 2928
	Enotice_ActivityRankPrize,
	// Token: 0x04000B71 RID: 2929
	Enotice_InviteAlliance,
	// Token: 0x04000B72 RID: 2930
	Enotice_SynLordEquip,
	// Token: 0x04000B73 RID: 2931
	Enotice_RallyCancel,
	// Token: 0x04000B74 RID: 2932
	Enotice_CryptFinish,
	// Token: 0x04000B75 RID: 2933
	Enotice_OtherSavedLord,
	// Token: 0x04000B76 RID: 2934
	Enotice_SelfSavedLord,
	// Token: 0x04000B77 RID: 2935
	Enotice_LordBeingReleased,
	// Token: 0x04000B78 RID: 2936
	Enotice_LordBeingExecuted,
	// Token: 0x04000B79 RID: 2937
	Enotice_LordEscaped,
	// Token: 0x04000B7A RID: 2938
	Enotice_OtherBreakPrison,
	// Token: 0x04000B7B RID: 2939
	Enotice_RescuedPrisoner,
	// Token: 0x04000B7C RID: 2940
	Enotice_RequestRansom,
	// Token: 0x04000B7D RID: 2941
	Enotice_ReceivedRansom,
	// Token: 0x04000B7E RID: 2942
	Enotice_PrisonFull,
	// Token: 0x04000B7F RID: 2943
	Enotice_RallyCancel_AsTargetAlly,
	// Token: 0x04000B80 RID: 2944
	Enotice_BeQuitAlliance,
	// Token: 0x04000B81 RID: 2945
	Enotice_BuyTreasure,
	// Token: 0x04000B82 RID: 2946
	Enotice_RallyCancel_Moving,
	// Token: 0x04000B83 RID: 2947
	Enotice_AtkFailedSelfShield,
	// Token: 0x04000B84 RID: 2948
	Enotice_InactiveState,
	// Token: 0x04000B85 RID: 2949
	Enotice_NewbieOver,
	// Token: 0x04000B86 RID: 2950
	Enotice_SHLevel6,
	// Token: 0x04000B87 RID: 2951
	Enotice_SHLevel10,
	// Token: 0x04000B88 RID: 2952
	Enotice_SHLevel15,
	// Token: 0x04000B89 RID: 2953
	Enotice_SHLevel17,
	// Token: 0x04000B8A RID: 2954
	Enotice_FirstUnderAttack,
	// Token: 0x04000B8B RID: 2955
	Enotice_FirstJoinAlliance,
	// Token: 0x04000B8C RID: 2956
	Enotice_SHLevel5,
	// Token: 0x04000B8D RID: 2957
	Enotice_BuyMonthTreature,
	// Token: 0x04000B8E RID: 2958
	Enotice_RecivedGift,
	// Token: 0x04000B8F RID: 2959
	Enotice_PrisonAmnestied,
	// Token: 0x04000B90 RID: 2960
	Enotice_LordBeingAmnestied,
	// Token: 0x04000B91 RID: 2961
	Enotice_RulerGift,
	// Token: 0x04000B92 RID: 2962
	Enotice_DismissAllianceLeader,
	// Token: 0x04000B93 RID: 2963
	Enotice_AmbushDefSuccess,
	// Token: 0x04000B94 RID: 2964
	Enotice_AmbushDefFailed,
	// Token: 0x04000B95 RID: 2965
	Enotice_ActivityKVKDegreePrize,
	// Token: 0x04000B96 RID: 2966
	Enotice_ActivityKVKRankPrize,
	// Token: 0x04000B97 RID: 2967
	Enotice_BuyBlackMarketTreasure,
	// Token: 0x04000B98 RID: 2968
	Enotice_KickOffTeam,
	// Token: 0x04000B99 RID: 2969
	Enotice_AutoDismissWarning,
	// Token: 0x04000B9A RID: 2970
	Enotice_AutoDismiss,
	// Token: 0x04000B9B RID: 2971
	Enotice_AMRankPrize,
	// Token: 0x04000B9C RID: 2972
	Enotice_AllianceHomeKingdom,
	// Token: 0x04000B9D RID: 2973
	Enotice_WorldKingPrize,
	// Token: 0x04000B9E RID: 2974
	Enotice_BackendAddCrystal,
	// Token: 0x04000B9F RID: 2975
	Enotice_KOWTelItem,
	// Token: 0x04000BA0 RID: 2976
	Enotice_LoginConpensate,
	// Token: 0x04000BA1 RID: 2977
	Enotice_PurchaseConpensate,
	// Token: 0x04000BA2 RID: 2978
	Enotice_RallyNPCCancel,
	// Token: 0x04000BA3 RID: 2979
	Enotice_RallyNPCCancelInvalid,
	// Token: 0x04000BA4 RID: 2980
	Enotice_ForceTeleport,
	// Token: 0x04000BA5 RID: 2981
	Enotice_LordEquipExpire,
	// Token: 0x04000BA6 RID: 2982
	Enotice_WorldNotKingPrize,
	// Token: 0x04000BA7 RID: 2983
	Enotice_BuyEmoteTreasure,
	// Token: 0x04000BA8 RID: 2984
	Enotice_LordPoisonEffect,
	// Token: 0x04000BA9 RID: 2985
	Enotice_PrisnerUsePoison,
	// Token: 0x04000BAA RID: 2986
	Enotice_PrisnerPoisonEffect,
	// Token: 0x04000BAB RID: 2987
	Enotice_BackendActivity,
	// Token: 0x04000BAC RID: 2988
	Enotice_BuyCastleSkinTreasure,
	// Token: 0x04000BAD RID: 2989
	Enotice_FederalRankPrize,
	// Token: 0x04000BAE RID: 2990
	Enotice_FederalTelBack,
	// Token: 0x04000BAF RID: 2991
	Enotice_RcvGiftRestrict,
	// Token: 0x04000BB0 RID: 2992
	Enotice_CancelRcvGiftRestrict,
	// Token: 0x04000BB1 RID: 2993
	Enotice_TreasureBackPrize,
	// Token: 0x04000BB2 RID: 2994
	Enotice_LookingForStringTable,
	// Token: 0x04000BB3 RID: 2995
	Enotice_MarchingPet_Cancel,
	// Token: 0x04000BB4 RID: 2996
	ENotice_PetStarUp,
	// Token: 0x04000BB5 RID: 2997
	ENotice_PrisonerPetSkillEscaped,
	// Token: 0x04000BB6 RID: 2998
	ENotice_LordPetSkillEscaped,
	// Token: 0x04000BB7 RID: 2999
	Enotice_FirstUnderPetAttack,
	// Token: 0x04000BB8 RID: 3000
	Enotice_ScoutTargetLeave,
	// Token: 0x04000BB9 RID: 3001
	Enotice_AttackTargetLeave,
	// Token: 0x04000BBA RID: 3002
	Enotice_MaintainCompensation,
	// Token: 0x04000BBB RID: 3003
	Enotice_BuyRedPocketTreasure,
	// Token: 0x04000BBC RID: 3004
	Enotice_SocialFriendModify,
	// Token: 0x04000BBD RID: 3005
	Enotice_ReturnCeremony,
	// Token: 0x04000BBE RID: 3006
	Enotice_FirstBuyTreasurePrize
}
