using System;

// Token: 0x02000196 RID: 406
public enum EGUIWindow
{
	// Token: 0x040016D6 RID: 5846
	Door,
	// Token: 0x040016D7 RID: 5847
	UI_Battle,
	// Token: 0x040016D8 RID: 5848
	UI_StageInfo,
	// Token: 0x040016D9 RID: 5849
	UI_StageStory,
	// Token: 0x040016DA RID: 5850
	UI_StageSelect,
	// Token: 0x040016DB RID: 5851
	UI_StageSelect2,
	// Token: 0x040016DC RID: 5852
	UI_Settlement,
	// Token: 0x040016DD RID: 5853
	UI_HeroList,
	// Token: 0x040016DE RID: 5854
	UI_BattleHeroSelect,
	// Token: 0x040016DF RID: 5855
	UI_Hero_Info,
	// Token: 0x040016E0 RID: 5856
	UI_BattleReport,
	// Token: 0x040016E1 RID: 5857
	UIResourceBuilding,
	// Token: 0x040016E2 RID: 5858
	UI_SuitBuilding,
	// Token: 0x040016E3 RID: 5859
	UI_BagFilter,
	// Token: 0x040016E4 RID: 5860
	UI_Chat,
	// Token: 0x040016E5 RID: 5861
	UI_HeroList_Soldier,
	// Token: 0x040016E6 RID: 5862
	UI_Barrack,
	// Token: 0x040016E7 RID: 5863
	UI_Barrack_Soldier,
	// Token: 0x040016E8 RID: 5864
	UI_Hospital,
	// Token: 0x040016E9 RID: 5865
	UI_Expedition,
	// Token: 0x040016EA RID: 5866
	UI_BookMark,
	// Token: 0x040016EB RID: 5867
	UI_AllianceHint,
	// Token: 0x040016EC RID: 5868
	UI_AllianceInput,
	// Token: 0x040016ED RID: 5869
	UI_LanguageSelect,
	// Token: 0x040016EE RID: 5870
	UI_Synthesis,
	// Token: 0x040016EF RID: 5871
	UI_Alliance_List,
	// Token: 0x040016F0 RID: 5872
	UI_Alliance_Permission,
	// Token: 0x040016F1 RID: 5873
	UI_Alliance_Info,
	// Token: 0x040016F2 RID: 5874
	UIAlliance_publicinfo,
	// Token: 0x040016F3 RID: 5875
	UIAlliance_Badge,
	// Token: 0x040016F4 RID: 5876
	UI_Warehouse,
	// Token: 0x040016F5 RID: 5877
	UI_Watchtower,
	// Token: 0x040016F6 RID: 5878
	UI_Watchtower_Details,
	// Token: 0x040016F7 RID: 5879
	UI_DevelopmentDetails,
	// Token: 0x040016F8 RID: 5880
	UI_LegBattle,
	// Token: 0x040016F9 RID: 5881
	UI_leadup,
	// Token: 0x040016FA RID: 5882
	UI_NewTerritory,
	// Token: 0x040016FB RID: 5883
	UI_Alliance_Management,
	// Token: 0x040016FC RID: 5884
	UI_HeroUse,
	// Token: 0x040016FD RID: 5885
	UI_ArmyInfo,
	// Token: 0x040016FE RID: 5886
	UI_Information,
	// Token: 0x040016FF RID: 5887
	UI_TechTree,
	// Token: 0x04001700 RID: 5888
	UI_TechInstitute,
	// Token: 0x04001701 RID: 5889
	UI_TechUpgrade,
	// Token: 0x04001702 RID: 5890
	UI_Letter,
	// Token: 0x04001703 RID: 5891
	UI_CityWall,
	// Token: 0x04001704 RID: 5892
	UI_Market,
	// Token: 0x04001705 RID: 5893
	UI_Market_Help,
	// Token: 0x04001706 RID: 5894
	UI_Embassy,
	// Token: 0x04001707 RID: 5895
	UI_FightingSummary,
	// Token: 0x04001708 RID: 5896
	UI_FightingSummary_Info,
	// Token: 0x04001709 RID: 5897
	UI_Letter_Watchtower,
	// Token: 0x0400170A RID: 5898
	UI_LetterEditor,
	// Token: 0x0400170B RID: 5899
	UI_Defenders,
	// Token: 0x0400170C RID: 5900
	UI_LetterDetail,
	// Token: 0x0400170D RID: 5901
	UI_WarLobby,
	// Token: 0x0400170E RID: 5902
	UI_WallRepair,
	// Token: 0x0400170F RID: 5903
	UI_Rally,
	// Token: 0x04001710 RID: 5904
	UI_Trap,
	// Token: 0x04001711 RID: 5905
	UI_HeroList_Soldier2,
	// Token: 0x04001712 RID: 5906
	UI_Castle,
	// Token: 0x04001713 RID: 5907
	UI_CastleUpgradeReward,
	// Token: 0x04001714 RID: 5908
	UI_Letter_Resources,
	// Token: 0x04001715 RID: 5909
	UI_Letter_Collection,
	// Token: 0x04001716 RID: 5910
	UI_Alliance_HelpSpeedup,
	// Token: 0x04001717 RID: 5911
	UI_ReplaceLord,
	// Token: 0x04001718 RID: 5912
	UI_LordInfo,
	// Token: 0x04001719 RID: 5913
	UI_BuffList,
	// Token: 0x0400171A RID: 5914
	UI_Forge,
	// Token: 0x0400171B RID: 5915
	UI_Talent,
	// Token: 0x0400171C RID: 5916
	UI_Activity1,
	// Token: 0x0400171D RID: 5917
	UI_Activity2,
	// Token: 0x0400171E RID: 5918
	UI_Activity3,
	// Token: 0x0400171F RID: 5919
	UI_Activity4,
	// Token: 0x04001720 RID: 5920
	UI_Mall,
	// Token: 0x04001721 RID: 5921
	UI_Mall_Detail,
	// Token: 0x04001722 RID: 5922
	UI_OpenBox,
	// Token: 0x04001723 RID: 5923
	UI_SearchList,
	// Token: 0x04001724 RID: 5924
	UI_Other,
	// Token: 0x04001725 RID: 5925
	UI_VIP,
	// Token: 0x04001726 RID: 5926
	UI_Mission,
	// Token: 0x04001727 RID: 5927
	UI_HeroTalk,
	// Token: 0x04001728 RID: 5928
	UI_Other_FunctionSwitch,
	// Token: 0x04001729 RID: 5929
	UI_Other_Forum,
	// Token: 0x0400172A RID: 5930
	UI_Other_Set,
	// Token: 0x0400172B RID: 5931
	UI_Altar,
	// Token: 0x0400172C RID: 5932
	UI_Jail,
	// Token: 0x0400172D RID: 5933
	UI_JailMoney,
	// Token: 0x0400172E RID: 5934
	UI_JailRoom,
	// Token: 0x0400172F RID: 5935
	UI_ChapterRewards,
	// Token: 0x04001730 RID: 5936
	UI_LordEquip,
	// Token: 0x04001731 RID: 5937
	UI_EffectFilter,
	// Token: 0x04001732 RID: 5938
	UI_Forge_Item,
	// Token: 0x04001733 RID: 5939
	UI_Forge_ActivityItem,
	// Token: 0x04001734 RID: 5940
	UI_Other_Account,
	// Token: 0x04001735 RID: 5941
	UI_TreasureBox,
	// Token: 0x04001736 RID: 5942
	UI_Anvil,
	// Token: 0x04001737 RID: 5943
	UI_PriestTalk,
	// Token: 0x04001738 RID: 5944
	UI_Crypt,
	// Token: 0x04001739 RID: 5945
	UI_CryptDig,
	// Token: 0x0400173A RID: 5946
	UI_VipLevelUp,
	// Token: 0x0400173B RID: 5947
	UI_LeaderBoard,
	// Token: 0x0400173C RID: 5948
	UI_BlackList,
	// Token: 0x0400173D RID: 5949
	UI_MapMonster,
	// Token: 0x0400173E RID: 5950
	UI_MonsterInfo,
	// Token: 0x0400173F RID: 5951
	UI_Alliance_Gift,
	// Token: 0x04001740 RID: 5952
	UI_MessageBoard,
	// Token: 0x04001741 RID: 5953
	UI_HeroUp,
	// Token: 0x04001742 RID: 5954
	UI_Announcement,
	// Token: 0x04001743 RID: 5955
	UI_Arena,
	// Token: 0x04001744 RID: 5956
	UI_Arena_Replay,
	// Token: 0x04001745 RID: 5957
	UI_Arena_Info,
	// Token: 0x04001746 RID: 5958
	UI_Arena_I,
	// Token: 0x04001747 RID: 5959
	UI_WonderLand,
	// Token: 0x04001748 RID: 5960
	UI_WonderInfo,
	// Token: 0x04001749 RID: 5961
	UI_MiniMap,
	// Token: 0x0400174A RID: 5962
	UI_Front,
	// Token: 0x0400174B RID: 5963
	UI_Name,
	// Token: 0x0400174C RID: 5964
	UI_LordEquipSetEdit,
	// Token: 0x0400174D RID: 5965
	UI_TalentSave,
	// Token: 0x0400174E RID: 5966
	UI_LordEquipSetSelect,
	// Token: 0x0400174F RID: 5967
	UI_Kingdom_Classifieds,
	// Token: 0x04001750 RID: 5968
	UI_Title,
	// Token: 0x04001751 RID: 5969
	UI_PaySetting,
	// Token: 0x04001752 RID: 5970
	UI_Ambush,
	// Token: 0x04001753 RID: 5971
	UI_Merchantman,
	// Token: 0x04001754 RID: 5972
	UI_TeamSave,
	// Token: 0x04001755 RID: 5973
	UI_BuffInformation,
	// Token: 0x04001756 RID: 5974
	UI_FormationSelect,
	// Token: 0x04001757 RID: 5975
	UI_RewardsSelect,
	// Token: 0x04001758 RID: 5976
	UI_Alliance_Mobilization,
	// Token: 0x04001759 RID: 5977
	UI_Alliance_Mobilization_Info,
	// Token: 0x0400175A RID: 5978
	UI_WonderReward,
	// Token: 0x0400175B RID: 5979
	UI_CanonizedPanel,
	// Token: 0x0400175C RID: 5980
	UI_Immigration,
	// Token: 0x0400175D RID: 5981
	UI_KingdomVSLBoard,
	// Token: 0x0400175E RID: 5982
	UI_KVKLBoard,
	// Token: 0x0400175F RID: 5983
	UI_Battle_Gambling,
	// Token: 0x04001760 RID: 5984
	UIAlchemy,
	// Token: 0x04001761 RID: 5985
	UI_Letter_NPCScout,
	// Token: 0x04001762 RID: 5986
	UI_Monster_Crypt_3,
	// Token: 0x04001763 RID: 5987
	UI_MonsterCrypt,
	// Token: 0x04001764 RID: 5988
	UI_ChallegeTreasure,
	// Token: 0x04001765 RID: 5989
	UI_AlliHuntBoard,
	// Token: 0x04001766 RID: 5990
	UIEmojiSelect,
	// Token: 0x04001767 RID: 5991
	UIDonation,
	// Token: 0x04001768 RID: 5992
	UIDonation_Info,
	// Token: 0x04001769 RID: 5993
	UI_SummonMonster,
	// Token: 0x0400176A RID: 5994
	UI_SuicideBox,
	// Token: 0x0400176B RID: 5995
	UI_CastleSkin,
	// Token: 0x0400176C RID: 5996
	UI_CastleStrengthen,
	// Token: 0x0400176D RID: 5997
	UI_NobilityBoard,
	// Token: 0x0400176E RID: 5998
	UI_NobilityOccupyBoard,
	// Token: 0x0400176F RID: 5999
	UI_ESportProfile,
	// Token: 0x04001770 RID: 6000
	UI_Letter_Watchtower_Recon,
	// Token: 0x04001771 RID: 6001
	UI_Alliance_FS,
	// Token: 0x04001772 RID: 6002
	UI_Alliance_FS_Info,
	// Token: 0x04001773 RID: 6003
	UI_AllianceWarOver,
	// Token: 0x04001774 RID: 6004
	UI_AlliVSGroupBoard,
	// Token: 0x04001775 RID: 6005
	UI_AlliVSAlliBoard,
	// Token: 0x04001776 RID: 6006
	UI_AllianceMatchInfo,
	// Token: 0x04001777 RID: 6007
	UI_AllianceWarRegister,
	// Token: 0x04001778 RID: 6008
	UI_AllianceWar_Rank,
	// Token: 0x04001779 RID: 6009
	UI_AllianceWarBattle,
	// Token: 0x0400177A RID: 6010
	UI_AlliWarSchedule,
	// Token: 0x0400177B RID: 6011
	UI_Mall_FG,
	// Token: 0x0400177C RID: 6012
	UI_Mall_FG_Detail,
	// Token: 0x0400177D RID: 6013
	UI_PetFusionbuilding,
	// Token: 0x0400177E RID: 6014
	UI_PetFusion,
	// Token: 0x0400177F RID: 6015
	UI_PetResourceStation,
	// Token: 0x04001780 RID: 6016
	UI_PetSkill_FS,
	// Token: 0x04001781 RID: 6017
	UI_ItemCraftShow,
	// Token: 0x04001782 RID: 6018
	UI_PetBag,
	// Token: 0x04001783 RID: 6019
	UI_PetList,
	// Token: 0x04001784 RID: 6020
	UI_Pet,
	// Token: 0x04001785 RID: 6021
	UI_PetStoneTrans,
	// Token: 0x04001786 RID: 6022
	UI_PetBuff,
	// Token: 0x04001787 RID: 6023
	UI_PetSkill,
	// Token: 0x04001788 RID: 6024
	UI_PetShield,
	// Token: 0x04001789 RID: 6025
	UI_PetSelect,
	// Token: 0x0400178A RID: 6026
	UI_PetTrainingCenter,
	// Token: 0x0400178B RID: 6027
	UI_PetLevelUp,
	// Token: 0x0400178C RID: 6028
	UI_Alliance_ActivityGift,
	// Token: 0x0400178D RID: 6029
	UI_TreasureBox_FB,
	// Token: 0x0400178E RID: 6030
	UI_MissionFB,
	// Token: 0x0400178F RID: 6031
	UIBackReward,
	// Token: 0x04001790 RID: 6032
	UIBackReward_Detail,
	// Token: 0x04001791 RID: 6033
	UI_FootBallBoard,
	// Token: 0x04001792 RID: 6034
	UI_FootBall,
	// Token: 0x04001793 RID: 6035
	UI_FootBall_Info,
	// Token: 0x04001794 RID: 6036
	UI_AlliMobi_WorldBoard,
	// Token: 0x04001795 RID: 6037
	UI_LeaderboardReward,
	// Token: 0x04001796 RID: 6038
	UI_Rating,
	// Token: 0x04001797 RID: 6039
	UI_ShieldLog,
	// Token: 0x04001798 RID: 6040
	UI_FootBallKVKBoard,
	// Token: 0x04001799 RID: 6041
	UI_Mall_FT,
	// Token: 0x0400179A RID: 6042
	UI_TermOfService,
	// Token: 0x0400179B RID: 6043
	MAX
}
