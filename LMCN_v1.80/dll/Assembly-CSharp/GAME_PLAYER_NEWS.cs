using System;

// Token: 0x020001B4 RID: 436
public enum GAME_PLAYER_NEWS : byte
{
	// Token: 0x04001A0E RID: 6670
	Network_Update,
	// Token: 0x04001A0F RID: 6671
	Network_Jammed,
	// Token: 0x04001A10 RID: 6672
	HeroTalk_Close,
	// Token: 0x04001A11 RID: 6673
	ORIGIN_DoorOpenUp,
	// Token: 0x04001A12 RID: 6674
	ORIGIN_DoorWild,
	// Token: 0x04001A13 RID: 6675
	ORIGIN_DoorNext,
	// Token: 0x04001A14 RID: 6676
	ORIGIN_DoorLast,
	// Token: 0x04001A15 RID: 6677
	ORIGIN_WildOpenUp,
	// Token: 0x04001A16 RID: 6678
	ORIGIN_CameraOpenUp,
	// Token: 0x04001A17 RID: 6679
	ORIGIN_CameraWild,
	// Token: 0x04001A18 RID: 6680
	ORIGIN_CameraForce,
	// Token: 0x04001A19 RID: 6681
	ORIGIN_CloudOpenUp,
	// Token: 0x04001A1A RID: 6682
	ORIGIN_LockInput,
	// Token: 0x04001A1B RID: 6683
	ORIGIN_UnLockInput,
	// Token: 0x04001A1C RID: 6684
	ORIGIN_OpenStage,
	// Token: 0x04001A1D RID: 6685
	ORIGIN_OpenStageStory,
	// Token: 0x04001A1E RID: 6686
	ORIGIN_CloseStageStory,
	// Token: 0x04001A1F RID: 6687
	ORIGIN_OpenStageInfo,
	// Token: 0x04001A20 RID: 6688
	ORIGIN_OpenPve,
	// Token: 0x04001A21 RID: 6689
	ORIGIN_CameraStateWild,
	// Token: 0x04001A22 RID: 6690
	ORIGIN_CloseNewTerritory,
	// Token: 0x04001A23 RID: 6691
	ORIGIN_OpenUpWild,
	// Token: 0x04001A24 RID: 6692
	ORIGIN_OpenUpContinue,
	// Token: 0x04001A25 RID: 6693
	ORIGIN_OpenBuild,
	// Token: 0x04001A26 RID: 6694
	ORIGIN_ManorGuildCameraMove,
	// Token: 0x04001A27 RID: 6695
	ORIGIN_ArneaGuildCameraMove,
	// Token: 0x04001A28 RID: 6696
	ORIGIN_DugoutGuildCameraMove,
	// Token: 0x04001A29 RID: 6697
	ORIGIN_BlackMarketGuildCameraMove,
	// Token: 0x04001A2A RID: 6698
	ORIGIN_WarlobbyGuildCameraMove,
	// Token: 0x04001A2B RID: 6699
	ORIGIN_CasinoGuildCameraMove,
	// Token: 0x04001A2C RID: 6700
	ORIGIN_LaboratoryGuildCameraMove,
	// Token: 0x04001A2D RID: 6701
	ORIGIN_PetListGuildCameraMove,
	// Token: 0x04001A2E RID: 6702
	ORIGIN_UpdateBuild,
	// Token: 0x04001A2F RID: 6703
	ORIGIN_CloseBuild,
	// Token: 0x04001A30 RID: 6704
	ORIGIN_UpdateOpenUp,
	// Token: 0x04001A31 RID: 6705
	ORIGIN_ChangeStageMode,
	// Token: 0x04001A32 RID: 6706
	ORIGIN_HideCampain,
	// Token: 0x04001A33 RID: 6707
	ORIGIN_OpenUpFirstRun,
	// Token: 0x04001A34 RID: 6708
	ORIGIN_OpenTreasureInfo,
	// Token: 0x04001A35 RID: 6709
	ORIGIN_CloseTreasureInfo,
	// Token: 0x04001A36 RID: 6710
	ORIGIN_BuildOpenUp,
	// Token: 0x04001A37 RID: 6711
	ORIGIN_SetCastleLevel,
	// Token: 0x04001A38 RID: 6712
	ORIGIN_UIQueueLock,
	// Token: 0x04001A39 RID: 6713
	ORIGIN_UIQueueLockRelease,
	// Token: 0x04001A3A RID: 6714
	ORIGIN_ShowUI,
	// Token: 0x04001A3B RID: 6715
	ORIGIN_HideUI,
	// Token: 0x04001A3C RID: 6716
	ORIGIN_UIInputLock,
	// Token: 0x04001A3D RID: 6717
	ORIGIN_UIInputLockRelease,
	// Token: 0x04001A3E RID: 6718
	ORIGIN_BackgroundEnable,
	// Token: 0x04001A3F RID: 6719
	ORIGIN_BackgroundDisable,
	// Token: 0x04001A40 RID: 6720
	ORIGIN_DoorFadeOut,
	// Token: 0x04001A41 RID: 6721
	ORIGIN_DoorFadeIn,
	// Token: 0x04001A42 RID: 6722
	CHAOS_UpdateMap,
	// Token: 0x04001A43 RID: 6723
	CHAOS_UpdateAllMap,
	// Token: 0x04001A44 RID: 6724
	CHAOS_UpdatePoint,
	// Token: 0x04001A45 RID: 6725
	CHAOS_DelLine,
	// Token: 0x04001A46 RID: 6726
	CHAOS_AddLine,
	// Token: 0x04001A47 RID: 6727
	CHAOS_UpdateLineOwner,
	// Token: 0x04001A48 RID: 6728
	CHAOS_UpdateLineTag,
	// Token: 0x04001A49 RID: 6729
	CHAOS_UpdateLinePos,
	// Token: 0x04001A4A RID: 6730
	CHAOS_UpdateLineBegin,
	// Token: 0x04001A4B RID: 6731
	CHAOS_UpdateLineEmoji,
	// Token: 0x04001A4C RID: 6732
	CHAOS_UpdateLineWeapon,
	// Token: 0x04001A4D RID: 6733
	CHAOS_UpdatePos,
	// Token: 0x04001A4E RID: 6734
	CHAOS_OpenPointInfo,
	// Token: 0x04001A4F RID: 6735
	CHAOS_ClosePointInfo,
	// Token: 0x04001A50 RID: 6736
	CHAOS_OpenLineInfo,
	// Token: 0x04001A51 RID: 6737
	CHAOS_UnenableEffect,
	// Token: 0x04001A52 RID: 6738
	CHAOS_ShowMapLoading,
	// Token: 0x04001A53 RID: 6739
	CHAOS_FinishMapLoading,
	// Token: 0x04001A54 RID: 6740
	CHAOS_UpdateGroundInfo,
	// Token: 0x04001A55 RID: 6741
	CHAOS_ScreenSpaceCamera,
	// Token: 0x04001A56 RID: 6742
	CHAOS_GoHomePosIn,
	// Token: 0x04001A57 RID: 6743
	CHAOS_GoHomePosOut,
	// Token: 0x04001A58 RID: 6744
	CHAOS_HomeInSide,
	// Token: 0x04001A59 RID: 6745
	CHAOS_HomeOutSide,
	// Token: 0x04001A5A RID: 6746
	CHAOS_GoHomeOffSetUpdate,
	// Token: 0x04001A5B RID: 6747
	CHAOS_CloseSelect,
	// Token: 0x04001A5C RID: 6748
	CHAOS_CloseMark,
	// Token: 0x04001A5D RID: 6749
	CHAOS_CheckAdvanceGroundInfo,
	// Token: 0x04001A5E RID: 6750
	CHAOS_CheckGroundInfoPetState,
	// Token: 0x04001A5F RID: 6751
	CHAOS_FollowGroup,
	// Token: 0x04001A60 RID: 6752
	CHAOS_CheckFocus,
	// Token: 0x04001A61 RID: 6753
	CHAOS_UpdateHomePos,
	// Token: 0x04001A62 RID: 6754
	CHAOS_DoorOpenMenu,
	// Token: 0x04001A63 RID: 6755
	CHAOS_DoorCloseMenu,
	// Token: 0x04001A64 RID: 6756
	CHAOS_MapFighter,
	// Token: 0x04001A65 RID: 6757
	CHAOS_MapMonsterBlood,
	// Token: 0x04001A66 RID: 6758
	CHAOS_MapMonsterNameBlood,
	// Token: 0x04001A67 RID: 6759
	CHAOS_ReLoadMap,
	// Token: 0x04001A68 RID: 6760
	CHAOS_UpdatePointByColAndRow,
	// Token: 0x04001A69 RID: 6761
	CHAOS_MapFighterLeave,
	// Token: 0x04001A6A RID: 6762
	CHAOS_DelLineCache,
	// Token: 0x04001A6B RID: 6763
	CHAOS_ReflashMapEffect,
	// Token: 0x04001A6C RID: 6764
	CHAOS_ShowYolkTime,
	// Token: 0x04001A6D RID: 6765
	CHAOS_HideYolkTime,
	// Token: 0x04001A6E RID: 6766
	CHAOS_DoorFadeOut,
	// Token: 0x04001A6F RID: 6767
	CHAOS_DoorFadeIn,
	// Token: 0x04001A70 RID: 6768
	CHAOS_ShowDamageRange,
	// Token: 0x04001A71 RID: 6769
	CHAOS_HideDamageRange,
	// Token: 0x04001A72 RID: 6770
	CHAOS_UseMapWeapon,
	// Token: 0x04001A73 RID: 6771
	CHAOS_StopMapWeapon,
	// Token: 0x04001A74 RID: 6772
	CHAOS_MapWeaponAttack,
	// Token: 0x04001A75 RID: 6773
	CHAOS_MapWeaponDefense,
	// Token: 0x04001A76 RID: 6774
	CHAOS_GoHome,
	// Token: 0x04001A77 RID: 6775
	CHAOS_BallDown,
	// Token: 0x04001A78 RID: 6776
	CHAOS_BallKick,
	// Token: 0x04001A79 RID: 6777
	CHAOS_BallBomb,
	// Token: 0x04001A7A RID: 6778
	CHAOS_FocusMyBall,
	// Token: 0x04001A7B RID: 6779
	CHAOS_FIFAInSide,
	// Token: 0x04001A7C RID: 6780
	CHAOS_FIFAOutSide,
	// Token: 0x04001A7D RID: 6781
	CHAOS_FinishMoveToTarget,
	// Token: 0x04001A7E RID: 6782
	CHAOS_StopMoveToTarget,
	// Token: 0x04001A7F RID: 6783
	COSMOS_UpdateKingdom,
	// Token: 0x04001A80 RID: 6784
	COSMOS_ShowMapLoading,
	// Token: 0x04001A81 RID: 6785
	COSMOS_FinishMapLoading,
	// Token: 0x04001A82 RID: 6786
	COSMOS_GoHomePosIn,
	// Token: 0x04001A83 RID: 6787
	COSMOS_GoHomePosOut,
	// Token: 0x04001A84 RID: 6788
	COSMOS_HomeInSide,
	// Token: 0x04001A85 RID: 6789
	COSMOS_HomeOutSide,
	// Token: 0x04001A86 RID: 6790
	COSMOS_GoHomeOffSetUpdate,
	// Token: 0x04001A87 RID: 6791
	COSMOS_FinishClickKingdom,
	// Token: 0x04001A88 RID: 6792
	COSMOS_UpdatePos,
	// Token: 0x04001A89 RID: 6793
	COSMOS_DoorOpenMenu,
	// Token: 0x04001A8A RID: 6794
	COSMOS_DoorCloseMenu,
	// Token: 0x04001A8B RID: 6795
	COSMOS_GoToKingdom,
	// Token: 0x04001A8C RID: 6796
	COSMOS_MoveToKingdom,
	// Token: 0x04001A8D RID: 6797
	COSMOS_UpdateWorld,
	// Token: 0x04001A8E RID: 6798
	COSMOS_MoveToMyKingdom,
	// Token: 0x04001A8F RID: 6799
	COSMOS_ReflashKingdomTitleButton,
	// Token: 0x04001A90 RID: 6800
	COSMOS_reflashKvKKingdomType,
	// Token: 0x04001A91 RID: 6801
	BATTLE_PVPFadeOut,
	// Token: 0x04001A92 RID: 6802
	ORIGIN_CameraReSetPressPosition,
	// Token: 0x04001A93 RID: 6803
	Count
}
