using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// Token: 0x02000189 RID: 393
public class DispatchManager
{
	// Token: 0x060005A4 RID: 1444 RVA: 0x00078C28 File Offset: 0x00076E28
	private DispatchManager()
	{
	}

	// Token: 0x1700003C RID: 60
	// (get) Token: 0x060005A6 RID: 1446 RVA: 0x00078C34 File Offset: 0x00076E34
	public static DispatchManager Instance
	{
		get
		{
			if (DispatchManager.instance == null)
			{
				DispatchManager.instance = new DispatchManager();
			}
			return DispatchManager.instance;
		}
	}

	// Token: 0x060005A7 RID: 1447 RVA: 0x00078C50 File Offset: 0x00076E50
	public static void GuestDispatcher(MessagePacket MP)
	{
		Protocol protocol = MP.Protocol;
		switch (protocol)
		{
		case Protocol._MSG_RESP_WORLDWONDER_OPEN:
			GUIManager.Instance.Recv_WORLDWONDER_OPEN(MP);
			break;
		case Protocol._MSG_RESP_WORLDWONDER_TAKEOVER:
			GUIManager.Instance.Recv_WORLDWONDER_TAKEOVER(MP);
			break;
		case Protocol._MSG_RESP_WORLDWONDER_CLOSE:
			GUIManager.Instance.Recv_WORLDWONDER_CLOSE(MP);
			break;
		default:
			if (protocol != Protocol._MSG_GUESTLOGIN_LOGINERRORRESP)
			{
				if (protocol != Protocol._MSG_RESP_ACTIVE)
				{
					if (protocol != Protocol._MSG_RESP_UPDATE_MAPINFO_PLUS)
					{
						if (protocol != Protocol._MSG_RESP_WONDER_SWITCH)
						{
							if (protocol != Protocol._MSG_RESP_MAP_PRISONER_LIST)
							{
								if (protocol != Protocol._MSG_RESP_WORLD_TELEPORT_ITEM)
								{
									if (protocol != Protocol._MSG_RESP_KINGDOM_BULLITIN)
									{
										if (protocol != Protocol._MSG_RESP_KINGDOM_TITLE_LIST)
										{
											if (protocol != Protocol._MSG_RESP_KING_GIFT)
											{
												if (protocol != Protocol._MSG_RESP_KING_GIFT_INFO_PLUS)
												{
													if (protocol != Protocol._MSG_RESP_NOBILITY_TITLE_LIST)
													{
														if (protocol == Protocol._MSG_RESP_PETSKILL_STATE)
														{
															DataManager.MapDataController.RESP_PETSKILL_STATE(MP);
														}
													}
													else
													{
														TitleManager.Instance.Recv_NobilityTitle_List(MP);
													}
												}
												else
												{
													DataManager.Instance.KingGift.RecvKingGiftInfo(MP);
												}
											}
											else
											{
												DataManager.Instance.KingGift.RecvKingGift(MP);
											}
										}
										else
										{
											TitleManager.Instance.Recv_KingdomTitle_List(MP);
										}
									}
									else
									{
										DataManager.Instance.RecvKingdomBullitin(MP);
									}
								}
								else
								{
									DataManager.Instance.RecvWorldTeleportItemCount(MP.ReadInt(-1), MP.ReadUShort(-1));
								}
							}
							else
							{
								JailManage.MSG_RESP_MAP_PRISONER_LIST(MP);
							}
						}
						else if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID)
						{
							DataManager.MapDataController.UpdateYolkswitch(MP);
						}
					}
					else if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID)
					{
						DataManager.MapDataController.RecvMapInfoPlus(MP);
					}
				}
				else
				{
					NetworkManager.GuestController.MakeBeat(MP, 15L);
				}
			}
			else
			{
				NetworkManager.GuestController.Login(MP);
			}
			break;
		}
	}

	// Token: 0x060005A8 RID: 1448 RVA: 0x00078E48 File Offset: 0x00077048
	public unsafe static void Dispatcher(MessagePacket MP)
	{
		Protocol protocol = MP.Protocol;
		switch (protocol)
		{
		case Protocol._MSG_RESP_ARMYGROUPINFO_:
			DataManager.Instance.RecvArmygroupInfo(MP);
			return;
		case Protocol._MSG_RESP_TRAININGINFO_:
			DataManager.Instance.RecvTrainingInfo(MP);
			return;
		default:
			switch (protocol)
			{
			case Protocol._MSG_REQUEST_ALLIANCE_INFO:
				DataManager.Instance.RecvAllianceInfo(MP);
				return;
			case Protocol._MSG_ALLIANCE_RESP_MAININFO:
				DataManager.Instance.RecvAllianceMain(MP);
				return;
			default:
				switch (protocol)
				{
				case Protocol._MSG_RESP_ACTIVITYINFO:
					ActivityManager.Instance.RecvActivity_Info(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_PREPARE:
					ActivityManager.Instance.RecvActivity_Prepare(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_RUN:
					ActivityManager.Instance.RecvActivity_Run(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_END:
					ActivityManager.Instance.RecvActivity_End(MP);
					return;
				default:
					switch (protocol)
					{
					case Protocol._MSG_RESP_MAILMETA:
					case Protocol._MSG_RESP_REPORTMETA:
					case Protocol._MSG_RESP_SAVEMAILMETA:
					case Protocol._MSG_RESP_NOTICEMETA:
					case Protocol._MSG_RESP_MAILINFO:
					case Protocol._MSG_RESP_MAILINFOEND:
					case Protocol._MSG_RESP_MAILMARKREAD:
					case Protocol._MSG_RESP_SAVEMAIL:
					case Protocol._MSG_RESP_DELETEMAIL:
					case Protocol._MSG_RESP_ALLMAIL_MOD:
					case Protocol._MSG_RESP_SCOUTREPORTINFO:
					case Protocol._MSG_RESP_COMBATREPORTINFO:
					case Protocol._MSG_RESP_GATHERREPORTINFO:
					case Protocol._MSG_RESP_ANTISCOUTREPORTINFO:
					case Protocol._MSG_RESP_RESHELPREPORTINFO:
					case Protocol._MSG_RESP_MONSTERREPORTINFO:
					case Protocol._MSG_RESP_REPORINFOEND:
					case Protocol._MSG_RESP_REPORTMARKREAD:
					case Protocol._MSG_RESP_SAVEREPORT:
					case Protocol._MSG_RESP_DELETEREPORT:
					case Protocol._MSG_RESP_ALLREPORT_MOD:
					case Protocol._MSG_RESP_SAVEMARKREAD:
					case Protocol._MSG_RESP_DELETESAVE:
					case Protocol._MSG_RESP_ALLSAVE_MOD:
					case Protocol._MSG_RESP_NOTICEINFO:
					case Protocol._MSG_RESP_NOTICEINFOEND:
					case Protocol._MSG_RESP_NOTICEMARKREAD:
					case Protocol._MSG_RESP_SAVENOTICE:
					case Protocol._MSG_RESP_DELETENOTICE:
					case Protocol._MSG_RESP_ALLNOTICE_MOD:
					case Protocol._MSG_RESP_MAIL_ERROR:
					case Protocol._MSG_RESP_REPORT_ERROR:
					case Protocol._MSG_RESP_NOTICE_ERROR:
						goto IL_2C95;
					default:
						switch (protocol)
						{
						case Protocol._MSG_RESP_PET_RESOURCEINFO:
							PetResourceData.DispatchResource(MP);
							return;
						case Protocol._MSG_RESP_PET_ITEMINFO:
							PetManager.Instance.RecvPetItemInfo(MP);
							return;
						case Protocol._MSG_RESP_PET_TRAINING_EVENT:
							PetManager.Instance.RecvPetTrainingEvevt(MP);
							return;
						default:
							switch (protocol)
							{
							case Protocol._MSG_ROLE_UPDATEINFO:
								switch (MP.ReadByte(-1))
								{
								case 0:
									DataManager.Instance.RoleAttr.Power = MP.ReadULong(-1);
									break;
								case 1:
									DataManager.Instance.RoleAttr.Kills = MP.ReadULong(-1);
									break;
								case 2:
									DataManager.MapDataController.updateCapitalPoint(MP.ReadUShort(-1), MP.ReadByte(-1), DataManager.MapDataController.OtherKingdomData.kingdomID, false);
									break;
								case 3:
									DataManager.Instance.RecvUpdateBuffInfo(MP);
									break;
								case 4:
									ActivityManager.Instance.RecvEventPoint(0, MP);
									break;
								case 5:
									ActivityManager.Instance.RecvEventPoint(1, MP);
									break;
								case 6:
									LordEquipData.AddItem(MP);
									LordEquipData.SetItemTime(MP.ReadLong(-1));
									break;
								case 7:
									LordEquipData.DeleteItem(MP);
									LordEquipData.SetItemTime(MP.ReadLong(-1));
									break;
								case 8:
									LordEquipData.SetMatTime(MP.ReadLong(-1));
									break;
								case 9:
									LordEquipData.SetGemTime(MP.ReadLong(-1));
									break;
								case 10:
									DataManager.StageDataController.UpdateRoleAttrExp(MP.ReadUInt(-1));
									break;
								case 11:
									DataManager.StageDataController.RoleAttrLevelUp(MP, 59);
									break;
								case 12:
									DataManager.Instance.RoleAttr.recvMonsterPoint = DataManager.Instance.RoleAttr.MonsterPoint;
									DataManager.Instance.RoleAttr.LastMonsterPointRecoverTime = MP.ReadLong(-1);
									DataManager.Instance.RoleAttr.MonsterPointRecoverFrequency = MP.ReadUShort(-1);
									DataManager.Instance.UpdateMonsterPoint();
									break;
								case 13:
									DataManager.Instance.RoleAttr.Diamond = MP.ReadUInt(-1);
									GameManager.OnRefresh(NetworkNews.Refresh, null);
									break;
								case 14:
									DataManager.Instance.RoleAlliance.Money = MP.ReadUInt(-1);
									GameManager.OnRefresh(NetworkNews.Refresh_Alliance, null);
									break;
								case 15:
									DataManager.Instance.RoleAttr.LordEquipBagSize = MP.ReadByte(-1);
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1, 0);
									break;
								case 16:
									ArenaManager.Instance.m_ArenaCrystalPrize = MP.ReadUInt(-1);
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_TreasureBox, 4, 0);
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 9, 0);
									GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
									break;
								case 17:
								{
									ArenaManager arenaManager = ArenaManager.Instance;
									arenaManager.m_ArenaNewReportNum = MP.ReadByte(-1);
									arenaManager.m_ArenaPlace = MP.ReadUInt(-1);
									if (arenaManager.m_ArenaNewReportNum != 0)
									{
										ArenaReportDataType item = default(ArenaReportDataType);
										item.SimulatorVersion = 0u;
										if (arenaManager.m_ArenaReportData.Count == 20)
										{
											arenaManager.m_ArenaReportData.RemoveAt(0);
										}
										bool flag = false;
										if (arenaManager.RepoetUnReadCount > 0 && arenaManager.RepoetUnRead[0] == 0)
										{
											flag = true;
											ArenaManager arenaManager2 = arenaManager;
											arenaManager2.RepoetUnReadCount -= 1;
										}
										if (flag)
										{
											int num = 0;
											while (num < (int)arenaManager.RepoetUnReadCount && arenaManager.RepoetUnReadCount < 19)
											{
												byte[] repoetUnRead = arenaManager.RepoetUnRead;
												int num2 = num;
												byte[] repoetUnRead2 = arenaManager.RepoetUnRead;
												int num3 = num + 1;
												repoetUnRead[num2] = (repoetUnRead2[num3] -= 1);
												num++;
											}
										}
										else
										{
											int num4 = 0;
											while (num4 < (int)arenaManager.RepoetUnReadCount && num4 < arenaManager.RepoetUnRead.Length)
											{
												byte[] repoetUnRead3 = arenaManager.RepoetUnRead;
												int num5 = num4;
												byte[] repoetUnRead4 = arenaManager.RepoetUnRead;
												int num6 = num4;
												repoetUnRead3[num5] = (repoetUnRead4[num6] -= 1);
												num4++;
											}
										}
										if (!arenaManager.bArenaOpenGet)
										{
											arenaManager.RepoetUnRead[(int)arenaManager.RepoetUnReadCount] = (byte)arenaManager.m_ArenaReportData.Count;
											ArenaManager arenaManager3 = arenaManager;
											arenaManager3.RepoetUnReadCount += 1;
										}
										arenaManager.m_ArenaReportData.Add(item);
									}
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 5, 0);
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena_Replay, 2, 0);
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_TreasureBox, 5, 0);
									GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
									break;
								}
								case 18:
									DataManager.Instance.RoleAttr.TPP_Point = MP.ReadUInt(-1);
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 6, 0);
									break;
								case 19:
									DataManager.Instance.RoleAttr.PaidCrystal = MP.ReadUInt(-1);
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mall, 7, 0);
									break;
								case 20:
									MallManager.Instance.BuyMonthTreasureTime = MP.ReadLong(-1);
									MallManager.Instance.LastGetMonthTreasurePrizeTime = MP.ReadLong(-1);
									GUIManager.Instance.UpdateUI(EGUIWindow.Door, 23, 0);
									break;
								case 21:
									ActivityManager.Instance.RecvKVKEventPoint(2, MP);
									break;
								case 22:
									ActivityManager.Instance.RecvKVKEventPoint(0, MP);
									break;
								case 23:
									ActivityManager.Instance.RecvKVKEventPoint(3, MP);
									break;
								case 24:
								{
									ActivityManager.Instance.bSpecialMonsterTreasureEvent = MP.ReadULong(-1);
									DataManager.msgBuffer[0] = 93;
									GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
									Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
									if (door != null)
									{
										door.RefreshMainEff();
									}
									PetManager.Instance.bActFusioncutdown = ((ActivityManager.Instance.bSpecialMonsterTreasureEvent & 16UL) > 0UL);
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetFusion, 3, 0);
									break;
								}
								case 25:
									DataManager.Instance.AllianceMoneyBonusRate = MP.ReadUShort(-1);
									DataManager.Instance.AllianceMoneyBonusRate = (ushort)Mathf.Clamp((int)DataManager.Instance.AllianceMoneyBonusRate, 100, 500);
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_HelpSpeedup, 5, 0);
									GUIManager.Instance.UpdateUI(EGUIWindow.Door, 11, 0);
									break;
								case 26:
								{
									DataManager dataManager = DataManager.Instance;
									dataManager.mDailyGift_Pic = MP.ReadUShort(-1);
									dataManager.mDailyGift.BeginTime = MP.ReadLong(-1);
									dataManager.mDailyGift.EndTime = MP.ReadLong(-1);
									dataManager.mDailyGift.ItemData.ItemID = MP.ReadUShort(-1);
									dataManager.mDailyGift.ItemData.Num = MP.ReadUShort(-1);
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_TreasureBox, 9, 0);
									GUIManager.Instance.UpdateUI(EGUIWindow.Door, 23, 0);
									break;
								}
								case 27:
									DataManager.StageDataController.RoleAttrLevelUp(MP, 24);
									GameManager.OnRefresh(NetworkNews.Refresh, null);
									GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
									break;
								case 28:
									ArenaManager.Instance.m_ArenaClose_ActivityType = (EActivityType)(MP.ReadByte(-1) - 1);
									ArenaManager.Instance.m_ArenaClose_CDTime = MP.ReadLong(-1);
									if (ArenaManager.Instance.m_ArenaClose_CDTime == 0L)
									{
										ArenaManager.Instance.SendArena_Refresh_Target(2);
									}
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 6, 0);
									break;
								case 29:
									DataManager.MissionDataManager.AllianceMissionBonusRate = MP.ReadUShort(-1);
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, 32, 0);
									GUIManager.Instance.UpdateUI(EGUIWindow.Door, 24, 0);
									break;
								case 30:
									GUIManager.Instance.NPCCityBonusTime = MP.ReadLong(-1);
									GUIManager.Instance.UpdateUI(EGUIWindow.UIAlchemy, 7, 0);
									GUIManager.Instance.BuildingData.UpdateBuildState(5, 255);
									break;
								case 31:
									DataManager.StageDataController.UpdateRoleTalentPoint(MP.ReadUShort(-1));
									break;
								case 32:
									ActivityManager.Instance.FederalActKingdomWonderID = MP.ReadByte(-1);
									ActivityManager.Instance.FederalHomeKingdomWonderID = MP.ReadByte(-1);
									PushManage.Instance.OrderEventBeginTime = MP.ReadLong(-1);
									ActivityManager.Instance.FederalActKingdomID = MP.ReadUShort(-1);
									break;
								case 33:
									ActivityManager.Instance.FederalFullEventTimeWonderID = MP.ReadByte(-1);
									break;
								case 34:
									ActivityManager.Instance.AW_SignUpAllianceID = MP.ReadUInt(-1);
									ActivityManager.Instance.AW_GetGift = MP.ReadByte(-1);
									ActivityManager.Instance.CheckAWShowHint();
									break;
								case 35:
									ActivityManager.Instance.AllianceWarData.bAskRankPrize = false;
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity4, 2, 210);
									UIAllianceWar_Rank.isDataReady = false;
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWar_Rank, 3, 0);
									break;
								case 36:
								{
									MallManager mallManager = MallManager.Instance;
									GUIManager guimanager = GUIManager.Instance;
									uint fullGift_NowCrystal = mallManager.FullGift_NowCrystal;
									mallManager.FullGift_NowCrystal = MP.ReadUInt(-1);
									mallManager.FullGift_MaxCrystal = MP.ReadUInt(-1);
									mallManager.FullGift_Deadline = MP.ReadLong(-1);
									bool flag2 = MP.ReadByte(-1) != 0;
									if (flag2)
									{
										mallManager.SetShowEffect(true);
										guimanager.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17511u), 255, true);
										guimanager.UpdateUI(EGUIWindow.UI_Mall, 9, 0);
									}
									if (mallManager.FullGift_Deadline == 0L)
									{
										mallManager.ClearFullGift();
									}
									else if (mallManager.bLoginFinish && !flag2 && mallManager.FullGift_NowCrystal > fullGift_NowCrystal)
									{
										guimanager.UpdateUI(EGUIWindow.UI_Mall, 10, (int)(mallManager.FullGift_NowCrystal - fullGift_NowCrystal));
									}
									guimanager.UpdateUI(EGUIWindow.UI_Mall, 8, 0);
									guimanager.UpdateUI(EGUIWindow.UI_Mall_FG, 1, 0);
									guimanager.UpdateUI(EGUIWindow.UI_Mall_FG_Detail, 1, 0);
									break;
								}
								case 37:
									ArenaManager.Instance.m_ArenaTodayChallenge = MP.ReadByte(-1);
									ArenaManager.Instance.m_ArenaExtraChallenge = MP.ReadByte(-1);
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 6, 0);
									break;
								case 38:
								{
									DataManager.Instance.RoleAttr.Diamond = MP.ReadUInt(-1);
									GameManager.OnRefresh(NetworkNews.Refresh, null);
									uint num7 = MP.ReadUInt(-1);
									CString cstring = StringManager.Instance.StaticString1024();
									cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9991u));
									cstring.IntToFormat((long)((ulong)num7), 1, true);
									cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12612u));
									GUIManager.Instance.AddHUDMessage(cstring.ToString(), 35, true);
									GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
									GUIManager.Instance.m_SpeciallyEffect.mDiamondValue = num7;
									GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, SpeciallyEffect_Kind.Diamond, 0, 0, true, 2f);
									break;
								}
								case 39:
								{
									DataManager.StageDataController.RoleAttrLevelUp(MP, 24);
									CString cstring2 = StringManager.Instance.StaticString1024();
									cstring2.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(12611u));
									cstring2.IntToFormat((long)MP.ReadUShort(-1), 1, false);
									cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12612u));
									GUIManager.Instance.AddHUDMessage(cstring2.ToString(), 35, true);
									GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
									GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, SpeciallyEffect_Kind.PetSkill_Morale, 0, 0, true, 2f);
									break;
								}
								case 40:
								{
									long waveEnd = MP.ReadLong(-1);
									ActivityManager.Instance.bPassLastWave = (MP.ReadByte(-1) == 1);
									ActivityManager.Instance.SetNowWaveEndTime(waveEnd, true);
									break;
								}
								case 41:
									MallManager.Instance.SetPaidDollar(MP.ReadUInt(-1), false);
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity3, 4, 0);
									break;
								}
								GameManager.OnRefresh(NetworkNews.Refresh_Attr, null);
								return;
							default:
								switch (protocol)
								{
								case Protocol._MSG_RESP_LORD_BEINGCAPTIVE:
									JailManage.MSG_RESP_LORD_BEINGCAPTIVE(MP);
									return;
								case Protocol._MSG_RESP_UPDATE_CAPTIVE:
									JailManage.MSG_RESP_UPDATE_CAPTIVE(MP);
									return;
								default:
									switch (protocol)
									{
									case Protocol._MSG_RESP_WALLINFO:
										DataManager.Instance.RecvWallInfo(MP);
										return;
									case Protocol._MSG_RESP_TRAPINFO:
										DataManager.Instance.RecvTrapInfo(MP);
										return;
									case Protocol._MSG_RESP_TRAPCONSTEVENT:
										DataManager.Instance.RecvTrapConstevent(MP);
										return;
									case Protocol._MSG_RESP_TRAPREPAIRINFO:
										DataManager.Instance.RecvTrapRepairInfo(MP);
										return;
									default:
										switch (protocol)
										{
										case Protocol._MSG_RESP_ALLIANCEWAR_MEMBERLIST_BEGIN:
											ActivityManager.Instance.AllianceWarMgr.RecvAllianceWarMemberListBegin(MP);
											return;
										case Protocol._MSG_RESP_ALLIANCEWAR_MEMBERLIST_LIST:
											ActivityManager.Instance.AllianceWarMgr.RecvAllianceWarMemberList(MP);
											return;
										case Protocol._MSG_RESP_UPDATE_ALLIANCEWAR_MEMBERLIST:
											ActivityManager.Instance.AllianceWarMgr.RecvUpdateAllianceWarMemberList(MP);
											return;
										case Protocol._MSG_RESP_INSERT_ALLIANCEWAR_MEMBERLIST:
											ActivityManager.Instance.AllianceWarMgr.RecvInsertAllianceWarMemberList(MP);
											return;
										default:
											switch (protocol)
											{
											case Protocol._MSG_RESP_BUILDINGINFO:
												GUIManager.Instance.BuildingData.RecvAllBuildData(MP);
												return;
											case Protocol._MSG_RESP_BUILDINGEVENT:
												GUIManager.Instance.BuildingData.RecvBuildingQueue(MP);
												return;
											default:
												switch (protocol)
												{
												case Protocol._MSG_RESP_BOOKMARKINFO:
													DataManager.Instance.RoleBookMark.RecvBookMarkInfo(MP);
													return;
												case Protocol._MSG_RESP_BOOKMARKLIST:
													DataManager.Instance.RoleBookMark.RecvBookMarkList(MP);
													return;
												default:
													switch (protocol)
													{
													case Protocol._MSG_RESP_TALENTINFO:
														DataManager.Instance.RecvTalentInfo(MP);
														return;
													default:
														switch (protocol)
														{
														case Protocol._MSG_RESP_SCOUT_NPC_REPORTINFO:
														case Protocol._MSG_RESP_NPC_COMBATREPORTINFO:
															goto IL_2C95;
														default:
															switch (protocol)
															{
															case Protocol._MSG_RESP_ITEMINFO:
																DataManager.Instance.RecvItemInfo(MP);
																return;
															default:
																switch (protocol)
																{
																case Protocol._MSG_RESP_AMNESTY:
																	DataManager.Instance.RecvAmnesty(MP);
																	return;
																default:
																	switch (protocol)
																	{
																	case Protocol._MSG_RESP_NOBILITY_TITLE_CHANGE:
																		TitleManager.Instance.Recv_NobilityTitle_Change(MP);
																		return;
																	default:
																		switch (protocol)
																		{
																		case Protocol._MSG_RESP_TREASURE_LIST:
																			MallManager.Instance.RecvMall_List(MP);
																			return;
																		default:
																			switch (protocol)
																			{
																			case Protocol._MSG_RESP_ARENA_INFO:
																				ArenaManager.Instance.RecvArena_Info(MP);
																				return;
																			default:
																				switch (protocol)
																				{
																				case Protocol._MSG_RESP_FB_MISSION_INFO:
																					DataManager.FBMissionDataManager.RecvFBMissionInfo(MP);
																					return;
																				default:
																					switch (protocol)
																					{
																					case Protocol._MSG_RESP_FOOTBALL_SKILL_USE:
																						FootballManager.Instance.RecvFootBall_Skill_Use(MP);
																						return;
																					case Protocol._MSG_RESP_FOOTBALL_DATA:
																						FootballManager.Instance.RecvFootBall_Data(MP);
																						return;
																					case Protocol._MSG_RESP_FOOTBALL_KICK_DATA:
																						FootballManager.Instance.RecvFootBall_Kick_Data(MP);
																						return;
																					default:
																						switch (protocol)
																						{
																						case Protocol._MSG_RESP_HEROSAVE:
																							DataManager.Instance.RecvHeroSave(MP);
																							GameManager.OnRefresh(NetworkNews.Refresh_Hero, null);
																							return;
																						default:
																							switch (protocol)
																							{
																							case Protocol._MSG_RESP_BATTLEINIT_NPC:
																								BattleNetwork.RecvInitBattle(MP);
																								return;
																							default:
																								switch (protocol)
																								{
																								case Protocol._MSG_RESP_KICK_RALLYMEMBER:
																									DataManager.Instance.RespKickWarhallAttackMember(MP);
																									return;
																								default:
																									switch (protocol)
																									{
																									case Protocol._MSG_RESP_LEADERBOARDS_CLIENT:
																										LeaderBoardManager.Instance.Recv_MSG_RESP_LEADERBOARDS_CLIENT(MP);
																										return;
																									default:
																										switch (protocol)
																										{
																										case Protocol._MSG_RESP_WORLD_TITLE_CHANGE:
																											TitleManager.Instance.Recv_WorldTitle_Change(MP);
																											return;
																										default:
																											switch (protocol)
																											{
																											case Protocol._MSG_RESP_RESEARCHINFO:
																												DataManager.Instance.RecvTechnologyInfo(MP);
																												return;
																											default:
																												switch (protocol)
																												{
																												case Protocol._MSG_RESP_BLACKMARKET_DATA:
																													MerchantmanManager.Instance.RecvBlackMarket_Data(MP);
																													return;
																												default:
																													switch (protocol)
																													{
																													case Protocol._MSG_RESP_HEROSTARUP_COMPLETE:
																														DataManager.Instance.RecvHeroStarUp(MP);
																														return;
																													default:
																														switch (protocol)
																														{
																														case Protocol._MSG_RESP_CRYPT:
																															DataManager.Instance.Recv_MSG_RESP_CRYPT(MP);
																															return;
																														default:
																															switch (protocol)
																															{
																															case Protocol._MSG_RESP_WONDER_INIT_NOTICE:
																																GUIManager.Instance.Recv_WONDER_INIT_NOTICE(MP);
																																return;
																															case Protocol._MSG_RESP_WONDER_TAKEOVER_NOTICE:
																																GUIManager.Instance.Recv_WONDER_TAKEOVER_NOTICE(MP);
																																return;
																															case Protocol._MSG_RESP_WONDER_PEACE_NOTICE:
																																GUIManager.Instance.Recv_WONDER_PEACE_NOTICE(MP);
																																return;
																															case Protocol._MSG_RESP_WONDER_PEACE_OVER:
																																GUIManager.Instance.Recv_WONDER_PEACE_OVER(MP);
																																return;
																															case Protocol._MSG_RESP_WORLDWONDER_OPEN:
																																GUIManager.Instance.Recv_WORLDWONDER_OPEN(MP);
																																return;
																															case Protocol._MSG_RESP_WORLDWONDER_TAKEOVER:
																																GUIManager.Instance.Recv_WORLDWONDER_TAKEOVER(MP);
																																return;
																															case Protocol._MSG_RESP_WORLDWONDER_CLOSE:
																																GUIManager.Instance.Recv_WORLDWONDER_CLOSE(MP);
																																return;
																															default:
																																switch (protocol)
																																{
																																case Protocol._MSG_RESP_GAMBLE_INFO:
																																	GamblingManager.Instance.Recv_MSG_RESP_GAMBLE_INFO(MP);
																																	return;
																																default:
																																	switch (protocol)
																																	{
																																	case Protocol._MSG_RESP_SHELTER_DATA:
																																		HideArmyManager.Instance.RecvShelterData(MP);
																																		return;
																																	default:
																																		switch (protocol)
																																		{
																																		case Protocol._MSG_RESP_REDPOCKET_LIST:
																																			ActivityGiftManager.Instance.Recv_MSG_RESP_REDPOCKET_LIST(MP);
																																			return;
																																		default:
																																			switch (protocol)
																																			{
																																			case Protocol._MSG_RESP_KINGDOM_TITLE_CHANGE_EX:
																																				TitleManager.Instance.Recv_KingdomTitle_ChangeByOthers(MP);
																																				return;
																																			case Protocol._MSG_RESP_KINGDOM_TITLE_REMOVE_EX:
																																				TitleManager.Instance.Recv_KingdomTitle_RemoveByOthers(MP);
																																				return;
																																			case Protocol._MSG_RESP_WORLD_TITLE_CHANGE_EX:
																																				TitleManager.Instance.Recv_WorldTitle_ChangeByOthers(MP);
																																				return;
																																			case Protocol._MSG_RESP_WORLD_TITLE_REMOVE_EX:
																																				TitleManager.Instance.Recv_WorldTitle_RemoveByOthers(MP);
																																				return;
																																			case Protocol._MSG_RESP_NOBILITY_TITLE_CHANGE_EX:
																																				TitleManager.Instance.Recv_NobilityTitle_ChangeByOthers(MP);
																																				return;
																																			case Protocol._MSG_RESP_NOBILITY_TITLE_REMOVE_EX:
																																				TitleManager.Instance.Recv_NobilityTitle_RemoveByOthers(MP);
																																				return;
																																			default:
																																				switch (protocol)
																																				{
																																				case Protocol._MSG_RESP_CREATEROLE:
																																				{
																																					long num8 = MP.ReadLong(-1);
																																					byte b = MP.ReadByte(-1);
																																					short num9 = MP.ReadShort(-1);
																																					byte b2 = MP.ReadByte(-1);
																																					byte b3 = MP.ReadByte(-1);
																																					string text = MP.ReadString(13, -1);
																																					if (b > 0)
																																					{
																																						GUIManager.Instance.AddHUDMessage("Name Invalid", 255, true);
																																					}
																																					return;
																																				}
																																				default:
																																					switch (protocol)
																																					{
																																					case Protocol._MSG_CLIENT_LOGINTOLRESP:
																																						NetworkManager.Instance.SetStage(LoginPhase.LP_Logon, (long)MP.ReadInt(-1), false);
																																						return;
																																					default:
																																						switch (protocol)
																																						{
																																						case Protocol._MSG_RESP_INIT_OPENKINGDOMINFO:
																																							DataManager.MapDataController.INIT_OPENKINGDOMINFO(MP);
																																							return;
																																						case Protocol._MSG_RESP_UPDATE_OPENKINGDOMINFO:
																																							DataManager.MapDataController.UPDATE_OPENKINGDOMINFO(MP);
																																							return;
																																						case Protocol._MSG_MAP_MY_KINGDOMINFO:
																																							DataManager.MapDataController.MY_KINGDOMINFO(MP);
																																							return;
																																						case Protocol._MSG_RESP_UPDATE_MAPINFO_PLUS:
																																							if (DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
																																							{
																																								DataManager.MapDataController.RecvMapInfoPlus(MP);
																																							}
																																							return;
																																						default:
																																							switch (protocol)
																																							{
																																							case Protocol._MSG_RESP_CHATMESSAGE:
																																								DataManager.Instance.RecvChatMessage(MP);
																																								return;
																																							default:
																																								switch (protocol)
																																								{
																																								case Protocol._MSG_CASTLE_SKIN_UNLOCKDATA:
																																									GUIManager.Instance.BuildingData.castleSkin.RecvCastleUnlockdata(MP);
																																									return;
																																								case Protocol._MSG_CASTLE_SKIN_UPDATE:
																																									GUIManager.Instance.BuildingData.castleSkin.RecvCastleSkinUpdate(MP);
																																									return;
																																								default:
																																									switch (protocol)
																																									{
																																									case Protocol._MSG_LOGIN_ROLEINFO:
																																									{
																																										DataManager dataManager2 = DataManager.Instance;
																																										dataManager2.RoleAttr.ReadPackNum = MP.ReadInt(-1);
																																										dataManager2.RoleAttr.UserId = MP.ReadLong(-1);
																																										MP.ReadStringPlus(13, dataManager2.RoleAttr.Name, -1);
																																										dataManager2.RoleAttr.Head = MP.ReadUShort(-1);
																																										if (DataManager.Instance.beCaptured.nowCaptureStat != LoadCaptureState.None)
																																										{
																																											DataManager.Instance.TempFightHeroID[(int)dataManager2.RoleAttr.Head] = 1;
																																											DataManager.Instance.SetFightHeroData();
																																										}
																																										dataManager2.RoleAttr.Level = 0;
																																										DataManager.StageDataController.RoleAttrLevelUp(MP, 27);
																																										dataManager2.RoleAttr.ServerTime = MP.ReadLong(-1);
																																										dataManager2.RoleAttr.LogoutTime = MP.ReadLong(-1);
																																										dataManager2.RoleAttr.Guide = (ulong)MP.ReadUInt(-1);
																																										dataManager2.RoleAttr.Diamond = MP.ReadUInt(-1);
																																										dataManager2.RoleAttr.HeroSkillPoint = MP.ReadByte(-1);
																																										dataManager2.RoleAttr.LastHeroSPRecoverTime = MP.ReadLong(-1);
																																										dataManager2.RoleAttr.EnhanceEventHeroID = MP.ReadUShort(-1);
																																										dataManager2.RoleAttr.HeroEnhanceEventTime.BeginTime = MP.ReadLong(-1);
																																										dataManager2.RoleAttr.HeroEnhanceEventTime.RequireTime = MP.ReadUInt(-1);
																																										dataManager2.RoleAttr.StarUpEventHeroID = MP.ReadUShort(-1);
																																										dataManager2.RoleAttr.HeroStarUpEventTime.BeginTime = MP.ReadLong(-1);
																																										dataManager2.RoleAttr.HeroStarUpEventTime.RequireTime = MP.ReadUInt(-1);
																																										MP.ReadBlock(DataManager.StageDataController.StageInfo[0], 0, (int)GameConstants.StageInfoSize[0], -1);
																																										MP.ReadBlock(DataManager.StageDataController.StageInfo[1], 0, (int)GameConstants.StageInfoSize[1], -1);
																																										bool flag3 = false;
																																										if (DataManager.StageDataController.reflashStageRecordInfo(StageMode.Full, MP.ReadUShort(-1)))
																																										{
																																											DataManager.StageDataController.StageRecord[1] = MP.ReadUShort(-1);
																																										}
																																										else
																																										{
																																											flag3 = !DataManager.StageDataController.reflashStageRecordInfo(StageMode.Lean, MP.ReadUShort(-1));
																																										}
																																										dataManager2.RoleAttr.BattleID = MP.ReadULong(-1);
																																										ushort newZoneID = MP.ReadUShort(-1);
																																										byte newPointID = MP.ReadByte(-1);
																																										dataManager2.RoleAttr.LastChatterTime = MP.ReadULong(-1);
																																										dataManager2.RoleAttr.AllianceChatID = MP.ReadUInt(-1);
																																										dataManager2.RoleAttr.Power = MP.ReadULong(-1);
																																										dataManager2.RoleAttr.Kills = MP.ReadULong(-1);
																																										dataManager2.RoleAttr.VipPoint = MP.ReadUInt(-1);
																																										dataManager2.RoleAttr.FirstTimer = MP.ReadLong(-1);
																																										dataManager2.RoleAttr.PrizeFlag = MP.ReadUInt(-1);
																																										dataManager2.RoleAttr.BookmarkTime = MP.ReadLong(-1);
																																										dataManager2.RoleAttr.BookmarkLimit = MP.ReadUShort(-1);
																																										dataManager2.RoleAttr.BookmarkNum = MP.ReadUShort(-1);
																																										flag3 = !DataManager.StageDataController.UpdateCorpsStageInfo(MP, flag3);
																																										dataManager2.RoleAttr.SuccessiveLoginDays = MP.ReadUShort(-1);
																																										dataManager2.RoleAttr.TodayUseMoraleItemTimes = MP.ReadByte(-1);
																																										dataManager2.RoleAttr.LordEquipBagSize = MP.ReadByte(-1);
																																										dataManager2.RoleAttr.VIPLevel = dataManager2.GetVIPLevel(dataManager2.RoleAttr.VipPoint);
																																										dataManager2.RoleAttr.NextOnlineGiftOpenTime = MP.ReadLong(-1);
																																										dataManager2.RoleAttr.OnlineGiftOpenTimes = MP.ReadByte(-1);
																																										dataManager2.RoleAttr.OnlineGiftItemID.ItemID = MP.ReadUShort(-1);
																																										dataManager2.RoleAttr.OnlineGiftItemID.Quantity = MP.ReadUShort(-1);
																																										dataManager2.RoleAttr.LastLordEquipUpdateTime = MP.ReadLong(-1);
																																										dataManager2.RoleAttr.LastItemMatUpdateTime = MP.ReadLong(-1);
																																										dataManager2.RoleAttr.LastItemGemUpdateTime = MP.ReadLong(-1);
																																										dataManager2.RoleAttr.LordEquipEventData.Init();
																																										dataManager2.RoleAttr.LordEquipEventData.ItemID = MP.ReadUShort(-1);
																																										dataManager2.RoleAttr.LordEquipEventData.Color = MP.ReadByte(-1);
																																										for (int i = 0; i < 4; i++)
																																										{
																																											dataManager2.RoleAttr.LordEquipEventData.GemColor[i] = MP.ReadByte(-1);
																																										}
																																										for (int j = 0; j < 4; j++)
																																										{
																																											dataManager2.RoleAttr.LordEquipEventData.Gem[j] = MP.ReadUShort(-1);
																																										}
																																										dataManager2.RoleAttr.LordEquipEventData.SerialNO = MP.ReadUInt(-1);
																																										dataManager2.RoleAttr.LordEquipEventTime.BeginTime = MP.ReadLong(-1);
																																										dataManager2.RoleAttr.LordEquipEventTime.RequireTime = MP.ReadUInt(-1);
																																										dataManager2.RoleAttr.VipLevelUp = MP.ReadByte(-1);
																																										DataManager.MapDataController.updateMyKingdom(MP.ReadUShort(-1), MP.ReadUShort(-1));
																																										DataManager.MapDataController.updateCapitalPoint(newZoneID, newPointID, DataManager.MapDataController.OtherKingdomData.kingdomID, false);
																																										dataManager2.RoleAttr.recvMonsterPoint = MP.ReadUInt(-1);
																																										dataManager2.RoleAttr.LastMonsterPointRecoverTime = MP.ReadLong(-1);
																																										dataManager2.RoleAttr.MonsterPointRecoverFrequency = MP.ReadUShort(-1);
																																										dataManager2.mSetNotice = MP.ReadUShort(-1);
																																										dataManager2.RoleAttr.TPP_Point = MP.ReadUInt(-1);
																																										dataManager2.RoleAttr.PaidCrystal = MP.ReadUInt(-1);
																																										MallManager.Instance.BuyMonthTreasureTime = MP.ReadLong(-1);
																																										MallManager.Instance.LastGetMonthTreasurePrizeTime = MP.ReadLong(-1);
																																										MP.ReadStringPlus(41, dataManager2.RoleAttr.NickName, -1);
																																										MP.ReadByte(-1);
																																										dataManager2.RoleAttr.KingdomTitle = MP.ReadUShort(-1);
																																										dataManager2.RoleAttr.NowArmyCoordIndex = MP.ReadByte(-1);
																																										dataManager2.RoleAttr.ArmyCoordFlag = MP.ReadUInt(-1);
																																										dataManager2.RoleAttr.bAllianceMobilizationGetPrize = MP.ReadByte(-1);
																																										dataManager2.RoleAttr.WorldTitle_Personal = MP.ReadUShort(-1);
																																										dataManager2.RoleAttr.WorldTitle_Country = MP.ReadUShort(-1);
																																										dataManager2.RoleAttr.DailyFreeScardStar = MP.ReadByte(-1);
																																										dataManager2.RoleAttr.ScardStar = MP.ReadUInt(-1);
																																										if (flag3)
																																										{
																																											DataManager.StageDataController.reflashStageRecordInfo(StageMode.Dare, MP.ReadUShort(-1));
																																										}
																																										else
																																										{
																																											DataManager.StageDataController.StageRecord[3] = MP.ReadUShort(-1);
																																										}
																																										MP.ReadBlock(DataManager.StageDataController.StageInfo[3], 0, (int)GameConstants.StageInfoSize[3], -1);
																																										dataManager2.mNewPushSwitch = MP.ReadULong(-1);
																																										dataManager2.RoleAttr.NobilityTitle = MP.ReadUShort(-1);
																																										DataManager dataManager3 = dataManager2;
																																										dataManager3.RoleAttr.Guide = (dataManager3.RoleAttr.Guide | (ulong)MP.ReadUInt(-1) << 32);
																																										dataManager2.RoleAttr.GuideEx = MP.ReadUInt(-1);
																																										dataManager2.RoleAttr.PetSkillFatigue = MP.ReadUShort(-1);
																																										dataManager2.RoleAlliance.JoinTime = MP.ReadLong(-1);
																																										MallManager.Instance.BackRewardComboBoxID = MP.ReadUShort(-1);
																																										if (MallManager.Instance.BackRewardComboBoxID != MallManager.Instance.BackRewardOpenID)
																																										{
																																											MallManager.Instance.BackRewardOpenID = 0;
																																										}
																																										MallManager.Instance.SetPaidDollar(MP.ReadUInt(-1), false);
																																										fixed (string text2 = dataManager2.RoleAttr.NickName.ToString())
																																										{
																																											fixed (char* ptr = text2 + RuntimeHelpers.OffsetToStringData / 2)
																																											{
																																												for (int k = 0; k < dataManager2.RoleAttr.NickName.Length; k++)
																																												{
																																													if (!dataManager2.isNotEmojiCharacter(dataManager2.RoleAttr.NickName[k]))
																																													{
																																														ptr[k] = ' ';
																																													}
																																												}
																																												text2 = null;
																																												NewbieManager.CheckNewbieLive();
																																												dataManager2.loginFinish();
																																												dataManager2.SetDefendersID();
																																												return;
																																											}
																																										}
																																									}
																																									default:
																																										switch (protocol)
																																										{
																																										case Protocol._MSG_RESP_ALLYPOINT:
																																											DataManager.Instance.RecvAllyPoint(MP);
																																											return;
																																										default:
																																											switch (protocol)
																																											{
																																											case Protocol._MSG_RESP_ALLYNICKNAME:
																																												DataManager.Instance.RecvChatNickName(MP);
																																												return;
																																											default:
																																												switch (protocol)
																																												{
																																												case Protocol._MSG_RESP_SUICIDENUM_BY_POWER_BOARD:
																																													UISuicideBox.RespSuicideNumByPowerBoard(MP);
																																													return;
																																												default:
																																													switch (protocol)
																																													{
																																													case Protocol._MSG_RESP_ALL_LORDEQUIP_MEMORY:
																																														LordEquipData.Instance().RESP_ALL_LORDEQUIP_MEMORY(MP);
																																														return;
																																													default:
																																														switch (protocol)
																																														{
																																														case Protocol._MSG_UPDATE_ALLIANCE_MOBILIZATION_LEGEND_MISSION_DATA:
																																															MobilizationManager.Instance.Recv_MSG_UPDATE_ALLIANCE_MOBILIZATION_LEGEND_MISSION_DATA(MP);
																																															return;
																																														default:
																																															if (protocol == Protocol._MSG_BACKEND_UPDATE_ACTNEWS)
																																															{
																																																ActivityManager.Instance.RecvActNews(MP);
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_BACKEND_UPDATE_DAILY_ACTNEWS)
																																															{
																																																ActivityManager.Instance.RecvDailyActNews(MP);
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_RESP_INDEMNIFY)
																																															{
																																																Indemnify.Instance.CheckIndemnify(MP);
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_RESP_INDEMNIFY_RESOURCE)
																																															{
																																																Indemnify.Instance.CheckIndemnifyResource(MP);
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_RESP_ALL_TALENT_CACHE)
																																															{
																																																DataManager.Instance.RecvTalentSave(MP);
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_RESP_TALENT_CACHE_NUM_MODIFY)
																																															{
																																																DataManager.Instance.RecvTalentSavePointIncreased(MP);
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_RESP_TROOPMEMORY_SETUP)
																																															{
																																																DataManager.Instance.RecvTroopmemory_Setup(MP);
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_RESP_TROOPMEMORY_DATA)
																																															{
																																																DataManager.Instance.RecvTroopmemory_Data(MP);
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_WEGAMER_RESP_OFFICIAL_LIVE)
																																															{
																																																byte b4 = MP.ReadByte(-1);
																																																GUIManager.Instance.bShowLive = false;
																																																if (!GUIManager.Instance.bShowLive)
																																																{
																																																	GUIManager.Instance.StopShowLiveScale = 0;
																																																}
																																																GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other, 2, 0);
																																																GUIManager.Instance.UpdateUI(EGUIWindow.Door, 20, 0);
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_WEGAMER_RESP_CONFIRM_OFFICIAL_LIVE)
																																															{
																																																GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other, 3, 0);
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_UPDATE_EMOTION_DATA)
																																															{
																																																for (int l = 0; l < 8; l++)
																																																{
																																																	GUIManager.Instance.EmojiFlag[l] = MP.ReadLong(-1);
																																																}
																																																GUIManager.Instance.LoadEmojiSelectSave();
																																																if (GUIManager.Instance.FindMenu(EGUIWindow.UIEmojiSelect))
																																																{
																																																	GUIManager.Instance.CloseMenu(EGUIWindow.UIEmojiSelect);
																																																	GUIManager.Instance.OpenMenu(EGUIWindow.UIEmojiSelect, (int)GUIManager.Instance.EmojiOpenType, 0, false, true, false);
																																																}
																																																if (MallManager.Instance.bLockBuyEmojiID && MallManager.Instance.SendCheckEmojiID != 0 && GUIManager.Instance.HasEmotionPck(MallManager.Instance.SendCheckEmojiID))
																																																{
																																																	MallManager.Instance.ClearSendCheckBuySN();
																																																}
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_RESP_ADD_EMOTION)
																																															{
																																																ushort num10 = MP.ReadUShort(-1);
																																																AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
																																																AudioManager.Instance.PlayUISFX(UIKind.ItemUse);
																																																GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(867u), 254, true);
																																																GUIManager.Instance.HideUILock(EUILock.Mall);
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_REBOOTMSG)
																																															{
																																																GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(655u), 255, true);
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_RESP_LOGINVALIDATE)
																																															{
																																																NetworkManager.Login(MP);
																																																DataManager.Instance.bRecvQueueBarData = 0L;
																																																DataManager.Instance.bBeginReLogin = true;
																																																DataManager.Instance.SendAllianceID = 0u;
																																																DataManager.Instance.SendMessageID = 0L;
																																																DataManager.Instance.ResetAllianceMemberData();
																																																DataManager.Instance.ResetMailingData();
																																																byte.TryParse(PlayerPrefs.GetString("SysSetting_First"), out DataManager.Instance.mFirstSetSys);
																																																if (DataManager.Instance.mFirstSetSys == 1)
																																																{
																																																	DataManager.Instance.GetSysSettingSave();
																																																}
																																																else
																																																{
																																																	DataManager.Instance.ReSetSysSettingSave();
																																																}
																																																DataManager.Instance.LegionBattleHero.Clear();
																																																DataManager.Instance.FightHeroCount = 0u;
																																																DataManager.Instance.NonFightHeroCount = 0u;
																																																DataManager.Instance.InitMarchData();
																																																DataManager.Instance.curHeroData.Clear();
																																																Array.Clear(DataManager.Instance.sortHeroData, 0, DataManager.Instance.sortHeroData.Length);
																																																DataManager.Instance.ResetBuffData();
																																																DataManager.Instance.InitAltarTime();
																																																AudioManager.Instance.MuteSFXVol = !DataManager.Instance.MySysSetting.bSound;
																																																Array.Clear(DataManager.Instance.TempFightHeroID, 0, DataManager.Instance.TempFightHeroID.Length);
																																																DataManager.Instance.beCaptured.nowCaptureStat = LoadCaptureState.None;
																																																DataManager.Instance.mHelpDataList.Clear();
																																																GUIManager.Instance.UpdateUI(EGUIWindow.Door, 11, 0);
																																																GUIManager.Instance.UpdateUI(EGUIWindow.Door, 17, 0);
																																																DataManager.Instance.WarhallProtocol = 0;
																																																DataManager.Instance.ActiveRallyRecNum = 0u;
																																																DataManager.Instance.BeingRallyRecNum = 0u;
																																																DataManager.MissionDataManager.bFirst = 1;
																																																GUIManager.Instance.ClearBackMessageBox(1);
																																																GUIManager.Instance.ClearBackMessageBox(2);
																																																GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Newbie);
																																																MallManager.Instance.bLoginFinish = false;
																																																AmbushManager.Instance.ClearAmbushData();
																																																DataManager.Instance.mDailyGift_Pic = 0;
																																																ArenaManager.Instance.m_ArenaClose_CDTime = 0L;
																																																ArenaManager.Instance.m_ArenaClose_ActivityType = EActivityType.EAT_MAX;
																																																GUIManager.Instance.NPCCityBonusTime = 0L;
																																																MallManager.Instance.ClearFullGift();
																																																PetManager.Instance.Clear();
																																																PetManager.Instance.bRecvPetMarchFinish = false;
																																																GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 7, 0);
																																																ActivityGiftManager.Instance.cleanListData();
																																																DataManager.Instance.DelRallyUIStack();
																																																GUIManager.Instance.bShowLive = false;
																																																ActivityManager.Instance.bRecvFIFAData = false;
																																																PushManage.Instance.FootBallEventBeginTime = 0L;
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_GUESTLOGIN_RESP_TOC)
																																															{
																																																NetworkManager.Peeping(MP);
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_FORCE_TELEPORT_LEAVEFOREST)
																																															{
																																																DataManager.Instance.Recv_TELEPORT_LEAVEFOREST(MP);
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_RESP_WONDER_SWITCH)
																																															{
																																																if (DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
																																																{
																																																	DataManager.MapDataController.UpdateYolkswitch(MP);
																																																}
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_TREASURE_BUY)
																																															{
																																																MallManager.Instance.RecvMall_GetItem(MP);
																																																return;
																																															}
																																															if (protocol == Protocol._MSG_RESP_KING_GIFT_INFO_PLUS)
																																															{
																																																DataManager.Instance.KingGift.RecvKingGiftInfo(MP);
																																																return;
																																															}
																																															if (protocol != Protocol._MSG_RESP_COORD_CHANGE)
																																															{
																																																return;
																																															}
																																															UIFormationSelect.RecvFormation(MP);
																																															return;
																																														case Protocol._MSG_RESP_ALLIANCE_MOBILIZATION_LEGEND_MISSION_GET_SCORE:
																																															MobilizationManager.Instance.Recv_MSG_RESP_ALLIANCE_MOBILIZATION_LEGEND_MISSION_GET_SCORE(MP);
																																															return;
																																														}
																																														break;
																																													case Protocol._MSG_RESP_LORDEQUIP_CHANGE:
																																														LordEquipData.Instance().RESP_LORDEQUIP_CHANGE(MP);
																																														return;
																																													}
																																													break;
																																												case Protocol._MSG_RESP_FOOTBALL_TOPBOARD:
																																													LeaderBoardManager.Instance.Recv_MSG_RESP_FOOTBALL_TOPBOARD(MP);
																																													return;
																																												}
																																												break;
																																											case Protocol._MSG_RESP_DELETECHAT:
																																												DataManager.Instance.Recv_DeleteMsg(MP);
																																												return;
																																											}
																																											break;
																																										case Protocol._MSG_RESP_RESPOINT_OWNER_LV:
																																											DataManager.Instance.RecvResPointOwnerLv(MP);
																																											return;
																																										}
																																										break;
																																									case Protocol._MSG_LOGIN_LOGINERRORRESP:
																																									{
																																										byte b5 = MP.ReadByte(-1);
																																										NetworkManager.Instance.SetStage(LoginPhase.LP_Login, (long)b5, false);
																																										return;
																																									}
																																									}
																																									break;
																																								case Protocol._MSG_RESP_CASTLE_SKIN_CHANGE:
																																									GUIManager.Instance.BuildingData.castleSkin.RecvCastleSkinChange(MP);
																																									return;
																																								}
																																								break;
																																							case Protocol._MSG_RESP_ALLYMESSAGE:
																																								DataManager.Instance.Recv_MessageBoard(MP);
																																								return;
																																							}
																																							break;
																																						}
																																						break;
																																					case Protocol._MSG_LOGIN_CROSSKINGDOM_CLOSE:
																																					{
																																						NetworkManager.Instance.SetStage(LoginPhase.LP_KickAss, 0L, false);
																																						for (int m = DataManager.Instance.TalkData_Kingdom.Count - 1; m >= 0; m--)
																																						{
																																							DataManager.Instance.TalkData_KPool.despawn(DataManager.Instance.TalkData_Kingdom[m]);
																																						}
																																						DataManager.Instance.TalkData_Kingdom.Clear();
																																						DataManager.Instance.bChangeKingdomClear = true;
																																						byte b6 = MP.ReadByte(-1);
																																						ushort newKingdomID = MP.ReadUShort(-1);
																																						ushort newZoneID2 = MP.ReadUShort(-1);
																																						byte newPointID2 = MP.ReadByte(-1);
																																						DataManager.MapDataController.ClearLayoutMapInfoYolkKind();
																																						DataManager.MapDataController.ClearAll();
																																						DataManager.MapDataController.updateCapitalPoint(newZoneID2, newPointID2, newKingdomID, true);
																																						if (b6 == 4)
																																						{
																																							GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(981u), 255, true);
																																						}
																																						return;
																																					}
																																					}
																																					break;
																																				case Protocol._MSG_RESP_ACTIVE:
																																					DataManager.Instance.ServerTime = MP.ReadLong(-1);
																																					GameManager.OnRefresh(NetworkNews.Refresh_ServerTime, null);
																																					NetworkManager.MakeBeat(15L);
																																					FlowLineFactory.ServerTimeOffset = 0f;
																																					return;
																																				}
																																				break;
																																			}
																																			break;
																																		case Protocol._MSG_RESP_REDPOCKET_LEADEREND:
																																			ActivityGiftManager.Instance.Recv_MSG_RESP_REDPOCKET_LEADEREND(MP);
																																			return;
																																		case Protocol._MSG_RESP_REDPOCKET_GET:
																																			ActivityGiftManager.Instance.Recv_MSG_RESP_REDPOCKET_GET(MP);
																																			return;
																																		case Protocol._MSG_RESP_REDPOCKET_BUY:
																																			ActivityGiftManager.Instance.Recv_MSG_RESP_REDPOCKET_BUY(MP);
																																			return;
																																		}
																																		break;
																																	case Protocol._MSG_RESP_HIDETROOPINSHELTER:
																																		HideArmyManager.Instance.RecvHideTroopInshelter(MP);
																																		return;
																																	case Protocol._MSG_RESP_RELEASESHELTERTROOP:
																																		HideArmyManager.Instance.RecvReleaseShelterTroop(MP);
																																		return;
																																	case Protocol._MSG_RESP_SHELTER_TIMESUP:
																																		HideArmyManager.Instance.RecvShelterTimesUp();
																																		return;
																																	}
																																	break;
																																case Protocol._MSG_RESP_GAMBLE_STARTGAME:
																																	GamblingManager.Instance.Recv_MSG_RESP_GAMBLE_STARTGAME(MP);
																																	return;
																																case Protocol._MSG_RESP_GAMBLE_PRIZE:
																																	GamblingManager.Instance.Recv_MSG_RESP_GAMBLE_PRIZE(MP);
																																	return;
																																case Protocol._MSG_GAMBLE_JACKPOT:
																																	GamblingManager.Instance.Recv_MSG_GAMBLE_JACKPOT(MP);
																																	return;
																																case Protocol._MSG_GAMBLE_HISTORY:
																																	GamblingManager.Instance.Recv_MSG_GAMBLE_HISTORY(MP);
																																	return;
																																}
																																break;
																															}
																															break;
																														case Protocol._MSG_RESP_CRYPT_START:
																															DataManager.Instance.Recv_MSG_RESP_CRYPT_Start(MP);
																															return;
																														case Protocol._MSG_RESP_CRYPT_CANCEL:
																															DataManager.Instance.Recv_MSG_RESP_CRYPT_Cancel(MP);
																															return;
																														case Protocol._MSG_RESP_CRYPT_REWARD:
																															DataManager.Instance.Recv_MSG_RESP_CRYPT_Reward(MP);
																															return;
																														}
																														break;
																													case Protocol._MSG_RESP_HEROSTARUP_CANCEL:
																														DataManager.Instance.RecvHeroStarUp_Cancel(MP);
																														return;
																													case Protocol._MSG_RESP_HEROSKILLADD:
																														DataManager.Instance.RecvHeroSkillAdd(MP);
																														return;
																													case Protocol._MSG_RESP_CHANGELORD:
																														DataManager.Instance.RecvChangeLord(MP);
																														return;
																													}
																													break;
																												case Protocol._MSG_RESP_BLACKMARKET_LOCK:
																													MerchantmanManager.Instance.RecvBlackMarket_Lock(MP);
																													return;
																												case Protocol._MSG_RESP_BLACKMARKET_BUY:
																													MerchantmanManager.Instance.RecvBlackMarket_Buy(MP);
																													return;
																												case Protocol._MSG_RESP_BLACKMARKET_EXTRA_TRADE:
																													MerchantmanManager.Instance.RecvExtraTrade(MP);
																													return;
																												case Protocol._MSG_TREASURE_COMBOBOX_CHANGE:
																													MerchantmanManager.Instance.RecvExtraChange(MP);
																													return;
																												}
																												break;
																											case Protocol._MSG_RESP_RESEARCH_EVENT_START:
																												DataManager.Instance.RecvTechnologyResearch(MP);
																												return;
																											case Protocol._MSG_RESP_RESEARCH_EVENT_FREE:
																												DataManager.Instance.RecvTechnologyCompleteFree(MP);
																												return;
																											case Protocol._MSG_RESP_RESEARCH_EVENT_CANCEL:
																												DataManager.Instance.RecvTechnologyResearchCancel(MP);
																												return;
																											case Protocol._MSG_RESP_RESEARCH_EVENT_COMPLETE:
																												DataManager.Instance.RecvTechnologyComplete(MP);
																												return;
																											case Protocol._MSG_RESP_RESEARCH_EVENT_INSTANT:
																												DataManager.Instance.RecvTechnologyCompleteImmediate(MP);
																												return;
																											}
																											break;
																										case Protocol._MSG_RESP_WORLD_TITLE_REMOVE:
																											TitleManager.Instance.Recv_WorldTitle_Remove(MP);
																											return;
																										case Protocol._MSG_RESP_WORLD_TITLE_LIST:
																											TitleManager.Instance.Recv_WorldTitle_List(MP);
																											return;
																										case Protocol._MSG_RESP_GET_WORLD_TITLE:
																											TitleManager.Instance.Recv_WorldTitle_Get(MP);
																											return;
																										case Protocol._MSG_RESP_NATIONAL_TITLE_CHANGE:
																											TitleManager.Instance.Recv_NationalTitle_Change(MP);
																											return;
																										case Protocol._MSG_RESP_NATIONAL_TITLE_LIST:
																											TitleManager.Instance.Recv_NationalTitle_List(MP);
																											return;
																										case Protocol._MSG_RESP_GET_NATIONAL_TITLE:
																											TitleManager.Instance.Recv_NationalTitle_Get(MP);
																											return;
																										case Protocol._MSG_RESP_CURRENT_NATIONAL_TITLE_NUM:
																											TitleManager.Instance.Recv_NationalTitle_Count(MP);
																											return;
																										}
																										break;
																									case Protocol._MSG_RESP_BOARDCONTENT:
																										LeaderBoardManager.Instance.Recv_MSG_RESP_BOARDCONTENT(MP);
																										return;
																									case Protocol._MSG_RESP_ARENA_BOARDDATA:
																										LeaderBoardManager.Instance.Recv_MSG_RESP_ARENA_BOARDDATA(MP);
																										return;
																									case Protocol._MSG_RESP_WORLD_TELEPORT_ITEM:
																										DataManager.Instance.RecvWorldTeleportItemCount(MP.ReadInt(-1), MP.ReadUShort(-1));
																										return;
																									case Protocol._MSG_RESP_KVK_TOPBORAD:
																										LeaderBoardManager.Instance.Recv_MSG_RESP_KVK_TOPBORAD(MP);
																										return;
																									case Protocol._MSG_RESP_WORLDRANKING_LEADERBOARDS_CLIENT:
																										LeaderBoardManager.Instance.Recv_MSG_RESP_WORLDRANKING_LEADERBOARDS_CLIENT(MP);
																										return;
																									case Protocol._MSG_RESP_KINGDOM_VS_TOPBOARD:
																										LeaderBoardManager.Instance.Recv_MSG_RESP_KINGDOM_VS_TOPBOARD(MP);
																										return;
																									}
																									break;
																								case Protocol._MSG_RESP_KICK_INFORCEMEMBER:
																									DataManager.Instance.RespKickWarhallDefenceMember(MP);
																									return;
																								case Protocol._MSG_RESP_KICKOFF_NOTICE:
																									GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9914u), 255, true);
																									return;
																								case Protocol._MSG_RESP_SEND_WONDERHOST:
																									DataManager.Instance.RecvWonderHost(MP);
																									return;
																								case Protocol._MSG_RESP_WONDERHOST_RETURN:
																									DataManager.Instance.RecvWinderhostReturn(MP);
																									return;
																								case Protocol._MSG_RESP_WONDER_WARHALL_UPDATE_LISTELE_PARTII:
																									goto IL_36FC;
																								case Protocol._MSG_RESP_WONDER_WARHALL_INIT_LISTDETAIL_PARTII:
																									goto IL_370C;
																								case Protocol._MSG_RESP_WARHALL_MEMBER_COMBAT_POWER:
																								case Protocol._MSG_RESP_WONDERTEAM_MEMBER_COMBAT_POWER:
																									DataManager.Instance.RespTeamCombatUpdate(MP);
																									return;
																								}
																								break;
																							case Protocol._MSG_RESP_BATTLEEND:
																								BattleNetwork.RecvBattleEnd(MP);
																								return;
																							case Protocol._MSG_RESP_QUICKBATTLE:
																								GUIManager.Instance.Recv_QuickBattle(MP);
																								return;
																							case Protocol._MSG_RESP_LEAVEBATTLE:
																								GUIManager.Instance.HideUILock(EUILock.ExitHeroBattle);
																								GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 9, 0);
																								return;
																							case Protocol._MSG_RESP_COMBATEND_NPC:
																								WarManager.RecvStartStageWar(MP);
																								return;
																							case Protocol._MSG_RESP_BATTLESIM_VER:
																								DataManager.Instance.BattleSimVer = MP.ReadUInt(-1);
																								DataManager.Instance.BattlePatchNo = MP.ReadUInt(-1);
																								DataManager.Instance.PetVersionNo = MP.ReadUInt(-1);
																								return;
																							case Protocol._MSG_RESP_EX_BATTLEINIT_NPC:
																								BattleNetwork.RecvInitBattleEx(MP);
																								return;
																							case Protocol._MSG_RESP_EX_BATTLEEND:
																								BattleNetwork.RecvBattleEndEx(MP);
																								return;
																							}
																							break;
																						case Protocol._MSG_RESP_HEROPUTONEQ:
																							DataManager.Instance.RecvHeroPutOnEq(MP);
																							return;
																						case Protocol._MSG_RESP_HEROENHANCE_START:
																							DataManager.Instance.RecvHeroEnhance_Start(MP);
																							return;
																						case Protocol._MSG_RESP_HEROENHANCE_COMPLETE:
																							DataManager.Instance.RecvHeroEnhance(MP);
																							return;
																						case Protocol._MSG_RESP_HEROENHANCE_CANCEL:
																							DataManager.Instance.RecvHeroEnhance_Cancel(MP);
																							return;
																						case Protocol._MSG_RESP_HEROCREATE:
																							DataManager.Instance.RecvHeroCreate(MP);
																							return;
																						case Protocol._MSG_RESP_HEROSTARUP_START:
																							DataManager.Instance.RecvHeroStarUp_Start(MP);
																							return;
																						}
																						break;
																					case Protocol._MSG_RESP_FOOTBALL_ASOLO_RANK:
																						LeaderBoardManager.Instance.Recv_MSG_RESP_FOOTBALL_ASOLO_RANK(MP);
																						return;
																					case Protocol._MSG_RESP_FOOTBALL_GOAL:
																						ActivityManager.Instance.Recv_FIFA_GOAL(MP);
																						return;
																					case Protocol._MSG_RESP_FOOTBALL_EVEINTINFO:
																						ActivityManager.Instance.Recv_FIFA_Info(MP);
																						return;
																					case Protocol._MSG_RESP_FOOTBALL_EVENTDETAIL:
																						ActivityManager.Instance.Recv_FIFA_DETAIL(MP);
																						return;
																					case Protocol._MSG_RESP_FOOTBALL_CHAMPION_MARQUEE:
																						ActivityManager.Instance.Recv_FIFA_CHAMPION_MARQUEE(MP);
																						return;
																					case Protocol._MSG_RESP_FOOTBALL_PREPUSH_INFO:
																						PushManage.Instance.Recv_MSG_RESP_FOOTBALL_PREPUSH_INFO(MP);
																						return;
																					case Protocol._MSG_RESP_FOOTBALL_KICK_FAILED_RETURN:
																						FootballManager.Instance.RecvFootBallKickFailedReturn(MP);
																						return;
																					case Protocol._MSG_RESP_FOOTBALL_KICK_POSITION:
																						FootballManager.Instance.RecvFootballeKickPosition(MP);
																						return;
																					case Protocol._MSG_RESP_ALLIANCE_MEMBER_FOOTBALL_GOAL:
																						FootballManager.Instance.RecvFootballeKick_Member_Goal(MP);
																						return;
																					}
																					break;
																				case Protocol._MSG_RESP_FB_MISSION_START:
																					DataManager.FBMissionDataManager.RecvFBMissionStart(MP);
																					return;
																				case Protocol._MSG_RESP_FB_GET_AWARD:
																					DataManager.FBMissionDataManager.RecvFBGetReward(MP);
																					return;
																				case Protocol._MSG_UPDATE_FB_MISSION_PROGRESS:
																					DataManager.FBMissionDataManager.UpdateFBMissionProGress(MP);
																					return;
																				case Protocol._MSG_UPDATE_FB_MISSION_AWARD:
																					DataManager.FBMissionDataManager.UpdateMissionReward(MP);
																					return;
																				case Protocol._MSG_UPDATE_FB_MISSION_GOAL_TO_C:
																					DataManager.FBMissionDataManager.UpdateMissionGoals(MP);
																					return;
																				case Protocol._MSG_RESP_BINDING_PLATFORM:
																					SocialManager.Instance.Recv_RESP_BINDING_PLATFORM(MP);
																					return;
																				case Protocol._MSG_RESP_SOCIAL_DATA:
																					DataManager.FBMissionDataManager.RecvSocialData(MP);
																					return;
																				case Protocol._MSG_RESP_FRIEND_USER_INFO:
																					DataManager.FBMissionDataManager.RespFriendSocialInfo(MP);
																					return;
																				case Protocol._MSG_UPDATE_FRIEND_NAME:
																					DataManager.FBMissionDataManager.UpdateFriendName(MP);
																					return;
																				case Protocol._MSG_RESP_SOCIAL_ENABLE:
																					DataManager.FBMissionDataManager.RESP_SOCIAL_ENABLE(MP);
																					return;
																				}
																				break;
																			case Protocol._MSG_RESP_ARENA_REPORT:
																				ArenaManager.Instance.RecvArena_Report(MP);
																				return;
																			case Protocol._MSG_RESP_ARENA_REFRESH_TARGET:
																				ArenaManager.Instance.RecvArena_Refresh_Target(MP);
																				return;
																			case Protocol._MSG_RESP_ARENA_SET_DEFHERO:
																				ArenaManager.Instance.RecvArena_Set_DefHero(MP);
																				return;
																			case Protocol._MSG_RESP_ARENA_CHALLENGE:
																				ArenaManager.Instance.RecvArena_Challenge(MP);
																				return;
																			case Protocol._MSG_RESP_ARENA_RESET_TODAYCHALLENGE:
																				ArenaManager.Instance.RecvArena_ReSet_Todaychallenge(MP);
																				return;
																			case Protocol._MSG_RESP_ARENA_RESET_CHALLENGE_CD:
																				ArenaManager.Instance.RecvArena_ReSet_Challenge_CD(MP);
																				return;
																			case Protocol._MSG_RESP_ARENA_GET_PRIZE:
																				ArenaManager.Instance.RecvArena_Arena_GetPrize(MP);
																				return;
																			case Protocol._MSG_RESP_ARENA_UPDATE_TOPIC:
																				ArenaManager.Instance.RecvArena_Update_Topic(MP);
																				return;
																			case Protocol._MSG_RESP_ARENA_UPDATE_SINGLE_TARGET:
																				ArenaManager.Instance.RecvArena_Update_Single_target(MP);
																				return;
																			}
																			break;
																		case Protocol._MSG_RESP_TREASURE_INFO:
																			MallManager.Instance.RecvMall_Info(MP);
																			return;
																		case Protocol._MSG_RESP_TREASURE_COMBOBOX:
																			MallManager.Instance.RecvMall_Combobox(MP);
																			return;
																		case Protocol._MSG_RESP_TREASURE_PREBUY_CHECK:
																			MallManager.Instance.RecvMall_Check(MP);
																			return;
																		case Protocol._MSG_TREASURE_UPDATELIST:
																			MallManager.Instance.RecvMall_UpdateList(MP);
																			return;
																		case Protocol._MSG_RESP_TREASURE_MONTHPRIZE_INFO:
																			MallManager.Instance.RecvTreasure_Monthprize_Info(MP);
																			return;
																		case Protocol._MSG_RESP_TREASURE_GET_MONTHPRIZE:
																			MallManager.Instance.RecvTreasure_Get_Monthprize(MP);
																			return;
																		case Protocol._MSG_RESP_SPTREASURE_PREBUY_CHECK:
																			MallManager.Instance.Recv_SPTREASURE_PREBUY_CHECK(MP);
																			return;
																		case Protocol._MSG_RESP_TREASUREBACK_PRIZEINFO:
																			MallManager.Instance.Recv_TREASUREBACK_PRIZEINFO(MP);
																			return;
																		case Protocol._MSG_RESP_TREASUREBACK_RCVPRIZE:
																			MallManager.Instance.Recv_TREASUREBACK_RCVPRIZE(MP);
																			return;
																		}
																		break;
																	case Protocol._MSG_RESP_NOBILITY_TITLE_REMOVE:
																		TitleManager.Instance.Recv_NobilityTitle_Remove(MP);
																		return;
																	case Protocol._MSG_RESP_NOBILITY_TITLE_LIST:
																		TitleManager.Instance.Recv_NobilityTitle_List(MP);
																		return;
																	case Protocol._MSG_RESP_GET_NOBILITY_TITLE:
																		TitleManager.Instance.Recv_NobilityTitle_Get(MP);
																		return;
																	case Protocol._MSG_RESP_FEDERAL_RANKDATA:
																		LeaderBoardManager.Instance.Recv_MSG_RESP_Nobile_RANKDATA(MP);
																		return;
																	case Protocol._MSG_RESP_FEDERAL_HISTORYKINGDATA:
																		LeaderBoardManager.Instance.Recv_MSG_RESP_FEDERAL_HISTORYKINGDATA(MP);
																		return;
																	case Protocol._MSG_RESP_FEDERAL_ORDERLIST:
																		ActivityManager.Instance.Recv_FEDERAL_ORDERLIST(MP);
																		return;
																	case Protocol._MSG_RESP_FEDERAL_UPDATE_ORDERLIST:
																		ActivityManager.Instance.Recv_FEDERAL_UPDATE_ORDERLIST(MP);
																		return;
																	case Protocol._MSG_RESP_FEDERAL_ORDERDETAIL:
																		ActivityManager.Instance.Recv_FEDERAL_ORDERDETAIL(MP);
																		return;
																	case Protocol._MSG_RESP_FEDERAL_PRIZE:
																		ActivityManager.Instance.Recv_ACTIVITY_MSG_RESP_FEDERAL_PRIZE(MP);
																		return;
																	case Protocol._MSG_RESP_FEDERAL_ORDERKINGDOMS:
																		ActivityManager.Instance.Recv_FEDERAL_ORDERKINGDOMS(MP);
																		return;
																	case Protocol._MSG_RESP_FEDERAL_KINGKINGDOMS:
																		ActivityManager.Instance.Recv_RESP_FEDERAL_KINGKINGDOMS(MP);
																		return;
																	case Protocol._MSG_FEDERAL_RESETEVENT:
																		ActivityManager.Instance.Recv_FEDERAL_RESETEVENT(MP);
																		return;
																	}
																	break;
																case Protocol._MSG_RESP_MODIFY_KINGDOM_BULLITIN:
																	DataManager.Instance.RecvModifyKingdomBullitin(MP);
																	return;
																case Protocol._MSG_RESP_KINGDOM_BULLITIN:
																	DataManager.Instance.RecvKingdomBullitin(MP);
																	return;
																case Protocol._MSG_RESP_NEW_KINGDOM_BULLITIN:
																	DataManager.Instance.RecvNewKingdomBullitin(MP);
																	return;
																case Protocol._MSG_RESP_MAIL_BULLITIN:
																	DataManager.Instance.RecvMailBullitin(MP);
																	return;
																case Protocol._MSG_RESP_KINGDOM_TITLE_CHANGE:
																	TitleManager.Instance.Recv_KingdomTitle_Change(MP);
																	return;
																case Protocol._MSG_RESP_KINGDOM_TITLE_REMOVE:
																	TitleManager.Instance.Recv_KingdomTitle_Remove(MP);
																	return;
																case Protocol._MSG_RESP_KINGDOM_TITLE_LIST:
																case Protocol._MSG_RESP_HOMEKINGDOM_TITLE_LIST:
																	TitleManager.Instance.Recv_KingdomTitle_List(MP);
																	return;
																case Protocol._MSG_RESP_GET_KINGDOM_TITLE:
																	TitleManager.Instance.Recv_KingdomTitle_Get(MP);
																	return;
																case Protocol._MSG_RESP_KING_GIFT:
																	DataManager.Instance.KingGift.RecvKingGift(MP);
																	return;
																case Protocol._MSG_RESP_KING_GIFT_RECIVED:
																	DataManager.Instance.KingGift.RecvKingGiftRecived(MP);
																	return;
																case Protocol._MSG_RESP_KINGDOM_BUFF_CD:
																	DataManager.Instance.KingCoolEndTime = MP.ReadLong(-1);
																	return;
																}
																break;
															case Protocol._MSG_RESP_SELLITEM:
																DataManager.Instance.RecvSellItem(MP);
																return;
															case Protocol._MSG_RESP_SYNITEM:
																DataManager.Instance.RecvSynthesis(MP);
																return;
															case Protocol._MSG_RESP_USEITEM:
																DataManager.Instance.RecvUseItem(MP);
																return;
															case Protocol._MSG_RESP_BUYITEM:
																DataManager.Instance.RecvBuyItem(MP);
																return;
															case Protocol._MSG_RESP_UPDATEITEM:
																DataManager.Instance.RecvUpdateItem(MP);
																return;
															case Protocol._MSG_RESP_ITEMMAT:
																LordEquipData.Instance().Recv_MSG_RESP_ITEMMAT(MP);
																return;
															case Protocol._MSG_RESP_LORDEQUIP:
																LordEquipData.Instance().Recv_MSG_RESP_LORDEQUIP(MP);
																return;
															case Protocol._MSG_RESP_ITEMGEM:
																LordEquipData.Instance().Recv_MSG_RESP_Gem(MP);
																return;
															case Protocol._MSG_RESP_GIFT:
																DataManager.Instance.RecvBuySendItem(MP);
																return;
															case Protocol._MSG_GIFT_RECIVED:
																DataManager.Instance.RecvBuySendItemReserved(MP);
																return;
															case Protocol._MSG_RESP_LORDEQUIP_EX:
																LordEquipData.Instance().Recv_MSG_RESP_LORDEQUIP_EX(MP);
																return;
															}
															break;
														case Protocol._MSG_RESP_COMBATREPLAY_NPCCITY:
															GUIManager.Instance.HideUILock(EUILock.Mailing_Battle);
															WarManager.RecvStartNpcWar(MP);
															return;
														case Protocol._MSG_RESP_COMBATDETAIL_LEADERDATA_NPCCITY:
															DataManager.Instance.NPCCombatDetail_Leaderdata(MP);
															return;
														case Protocol._MSG_RESP_COMBATDETAIL_PLAYERDATA_NPCCITY:
															break;
														case Protocol._MSG_RESP_COMBATDETAIL_INJUREDATA_NPCCITY:
															goto IL_2B4B;
														case Protocol._MSG_RESP_LIVECOMBATREPLAYMETA_NPCCITY:
															GUIManager.Instance.RecvNPCCityMessage(MP);
															return;
														case Protocol._MSG_RESP_LIVECOMBATREPLAY_NPCCITY:
															WarManager.RecvFastStartNpcWar(MP);
															return;
														case Protocol._MSG_RESP_BROCAST_NPC_WAR_BEGIN:
															GUIManager.Instance.Recv_BROCAST_NPC_WAR_BEGIN(MP);
															return;
														case Protocol._MSG_RESP_NPC_RALLY_DETAIL_FAILED:
															GUIManager.Instance.Recv_NPC_RALLY_DETAIL_FAILED(MP);
															return;
														case Protocol._MSG_RESP_NPC_WARHALL_UPDATE_LISTELE:
															DataManager.Instance.RecvNPCWallHallData(MP);
															return;
														case Protocol._MSG_RESP_NPC_WARHALL_INIT_LISTDETAIL:
															DataManager.Instance.RecvNPCWallHallDetail(MP);
															return;
														case Protocol._MSG_RESP_NPC_REWARDSAVE:
															GUIManager.Instance.Recv_NPC_REWARDSAVE(MP);
															return;
														case Protocol._MSG_RESP_NPC_START_REWARD:
															GUIManager.Instance.Recv_NPC_START_REWARD(MP);
															return;
														case Protocol._MSG_RESP_NPC_GET_REWARD:
															GUIManager.Instance.Recv_NPC_GET_REWARD(MP);
															return;
														case Protocol._MSG_RESP_NPC_DELETE_REWARD:
															GUIManager.Instance.Recv_NPC_DELETE_REWARD(MP);
															return;
														case Protocol._MSG_RESP_NPC_UPDATEREWARD:
															GUIManager.Instance.Recv_NPC_UPDATEREWARD(MP);
															return;
														case Protocol._MSG_RESP_NPCCITY_RALLY_ATKMARCH:
															DataManager.Instance.Recv_NPCCITY_RALLY_ATKMARCH(MP);
															return;
														}
														break;
													case Protocol._MSG_RESP_TALENT_LEVEL_ADD:
														DataManager.Instance.RecvTalentAdd(MP);
														return;
													case Protocol._MSG_RESP_ONLORDEQUIP_INFO:
														LordEquipData.Recv_MSG_RESP_ONLORDEQUIP_INFO(MP);
														return;
													case Protocol._MSG_RESP_PUTON_TAKEOFF_LORDEQUIP:
														LordEquipData.Instance().Recv_MSG_RESP_PUTON_TAKEOFF_LORDEQUIP(MP);
														return;
													case Protocol._MSG_RESP_SYN_MATGEM:
														LordEquipData.Instance().Recv_MSG_LORD_RESPSYN_MATGEM(MP);
														return;
													case Protocol._MSG_RESP_SYN_LORDEQUIP:
														LordEquipData.Instance().Recv_MSG_RESP_SYN_LORDEQUIP(MP);
														return;
													case Protocol._MSG_RESP_SYN_LORDEQUIP_EVENT_CANCEL:
														LordEquipData.Instance().Recv_MSG_RESP_SYN_LORDEQUIP_EVENT_CANCEL(MP);
														return;
													case Protocol._MSG_RESP_SYN_LORDEQUIP_EVENT_COMPLETE:
														LordEquipData.Instance().Recv_MSG_RESP_SYN_LORDEQUIP_EVENT_COMPLETE(MP);
														return;
													case Protocol._MSG_RESP_SYN_LORDEQUIP_INSTANT:
														LordEquipData.Recv_MSG_RESP_SYN_LORDEQUIP_INSTANT(MP);
														return;
													case Protocol._MSG_RESP_FINISH_SYN_LORDEQUIP_EVENT:
														LordEquipData.Recv_MSG_RESP_FINISH_SYN_LORDEQUIP_EVENT(MP);
														return;
													case Protocol._MSG_RESP_DECOMPOSE_LORDEQUIP:
														LordEquipData.Instance().Recv_MSG_RESP_DECOMPOSE_LORDEQUIP(MP);
														return;
													case Protocol._MSG_RESP_INLAY_LORDEQUIP:
														LordEquipData.Instance().Recv_MSG_RESP_INLAY_LORDEQUIP(MP);
														return;
													case Protocol._MSG_RESP_FREE_TAKEOFF_GEM:
														LordEquipData.Instance().Recv_MSG_RESP_FREE_TAKEOFF_GEM(MP);
														return;
													case Protocol._MSG_RESP_DECOMPOSE_MATGEM:
														LordEquipData.Instance().Recv_MSG_LORD_RESPDECOMPOSE_MATGEM(MP);
														return;
													}
													break;
												case Protocol._MSG_RESP_ADDBOOKMARK:
													DataManager.Instance.RoleBookMark.RecvBookMarkAdd(MP);
													return;
												case Protocol._MSG_RESP_DELBOOKMARK:
													DataManager.Instance.RoleBookMark.RecvBookMarkDel(MP);
													return;
												case Protocol._MSG_RESP_MODIFYBOOKMARK:
													DataManager.Instance.RoleBookMark.RecvBookMarkModify(MP);
													return;
												case Protocol._MSG_RESP_MISSIONINFO:
													DataManager.MissionDataManager.RecvTimeMissionInfo(MP);
													return;
												case Protocol._MSG_RESP_MISSION_START:
													DataManager.MissionDataManager.RecvTimeMissionStart(MP);
													return;
												case Protocol._MSG_RESP_MISSION_BOOST:
													DataManager.MissionDataManager.RecvTimeMissionCompleteInst(MP);
													return;
												case Protocol._MSG_RESP_MISSION_FINISH:
													DataManager.MissionDataManager.RecvTimeMissionReward(MP);
													return;
												case Protocol._MSG_RESP_MISSION_COMPLETE:
													DataManager.MissionDataManager.RecvMissionComplete(MP);
													return;
												case Protocol._MSG_RESP_MISSION_FLAG:
													DataManager.MissionDataManager.RecvMissionFlag(MP);
													return;
												case Protocol._MSG_RESP_MISSION_MARK:
													DataManager.MissionDataManager.RecvMissionMark(MP);
													return;
												case Protocol._MSG_RESP_MISSION_MARKSET:
													DataManager.MissionDataManager.RecvMissionmarkUpdate(MP);
													return;
												case Protocol._MSG_RESP_MISSION_VIP:
													DataManager.MissionDataManager.RecvVipMission(MP);
													return;
												case Protocol._MSG_RESP_MISSION_VIP_SPEEDUP:
													DataManager.MissionDataManager.RecvVipMissionImmed(MP);
													return;
												}
												break;
											case Protocol._MSG_RESP_BUILDBEGIN:
												GUIManager.Instance.BuildingData.RecvUpdateBuildData(MP);
												return;
											case Protocol._MSG_RESP_BUILDCOMPLETE:
												GUIManager.Instance.BuildingData.RecvBuildComplete(MP);
												return;
											case Protocol._MSG_RESP_BUILDCANCEL:
												GUIManager.Instance.BuildingData.RecvBuildCancel(MP);
												return;
											case Protocol._MSG_RESP_INSTANTBUILD:
												GUIManager.Instance.BuildingData.RecvBuildCompleteImmediate(MP);
												return;
											case Protocol._MSG_RESP_FINISHBUILD:
												GUIManager.Instance.BuildingData.RecvBuildFinish(MP);
												return;
											case Protocol._MSG_RESP_BUILDINGERROR:
												GUIManager.Instance.BuildingData.RecvBuildErrMsg(MP);
												return;
											case Protocol._MSG_RESP_RESOURCEINFO:
												GUIManager.Instance.BuildingData.RecvResources(MP);
												return;
											case Protocol._MSG_RESP_UPDATE_RESOURCEINFO:
												GUIManager.Instance.BuildingData.RecvResourcesUpdate(MP);
												return;
											case Protocol._MSG_RESP_UPDATE_RESOURCEAMOUNT:
												DataManager.Instance.RecvRefreshResources(MP);
												return;
											case Protocol._MSG_RESP_DECONSTRBEGIN:
												GUIManager.Instance.BuildingData.RecvBuildDismantle(MP);
												return;
											case Protocol._MSG_RESP_DECONSTRCOMPLETE:
												GUIManager.Instance.BuildingData.RecvBuildDismantleComplete(MP);
												return;
											case Protocol._MSG_RESP_DECONSTRCANCEL:
												GUIManager.Instance.BuildingData.RecvBuildDismantleCancel(MP);
												return;
											case Protocol._MSG_RESP_INSTANTDECONSTR:
												GUIManager.Instance.BuildingData.RecvBuildDismantleCompleteImmediate(MP);
												return;
											case Protocol._MSG_RESP_FINISHDECONSTR:
												GUIManager.Instance.BuildingData.RecvBuildDismantleCompleteFinish(MP);
												return;
											case Protocol._MSG_RESP_UPDATE_INJURE:
												DataManager.Instance.RecvUpdate_Injure(MP);
												return;
											}
											break;
										case Protocol._MSG_RESP_SIGNUP_ALLIANCEWAR:
											ActivityManager.Instance.AllianceWarMgr.Recv_MSG_RESP_SIGNUP_ALLIANCEWAR(MP);
											return;
										case Protocol._MSG_RESP_ALLIANCEWAR_MEMBER_DATA:
											ActivityManager.Instance.AllianceWarMgr.Recv_MSG_RESP_ALLIANCEWAR_MEMBER_DATA(MP);
											return;
										case Protocol._MSG_RESP_ALLIANCEWAR_REPLAY_FAILED:
											ActivityManager.Instance.AllianceWarMgr.Recv_MSG_RESP_ALLIANCEWAR_REPLAY_FAILED(MP);
											return;
										case Protocol._MSG_RESP_ALLIANCEWAR_LIVE_LEFTSIDE_LIST:
										case Protocol._MSG_RESP_ALLIANCEWAR_LIVE_RIGHTSIDE_LIST:
										case Protocol._MSG_RESP_ALLIANCEWAR_LIVE_WAR_DETAIL:
										case Protocol._MSG_RESP_ALLIANCEWAR_REPLAY_LEFTSIDE_LIST:
										case Protocol._MSG_RESP_ALLIANCEWAR_REPLAY_RIGHTSIDE_LIST:
										case Protocol._MSG_RESP_ALLIANCEWAR_REPLAY_WAR_DETAIL:
											AllianceBattle.RecvAllianceBattleStation(MP);
											return;
										case Protocol._MSG_RESP_ALLIANCEWAR_MATCH_PLAYERDATA:
											ActivityManager.Instance.AllianceWarMgr.Recv_MSG_RESP_ALLIANCEWAR_MATCH_PLAYERDATA(MP);
											return;
										case Protocol._MSG_RESP_ALLIANCEWAR_COMBAT_REPORT:
											ActivityManager.Instance.AllianceWarMgr.Recv_MSG_RESP_ALLIANCEWAR_COMBAT_REPORT(MP);
											return;
										case Protocol._MSG_RESP_ALLIANCEWAR_OPENGETPRIZEUI:
											UIAllianceWar_Rank.DispatchOpen(MP);
											return;
										case Protocol._MSG_RESP_ALLIANCEWAR_GETPRIZE:
											UIAllianceWar_Rank.DispatchReward(MP);
											return;
										case Protocol._MSG_RESP_ALLIANCEWAR_RANK:
											LeaderBoardManager.Instance.Recv_MSG_RESP_ALLIANCEWAR_RANK(MP);
											return;
										case Protocol._MSG_RESP_ALLIANCEWAR_RANKPRIZE:
											ActivityManager.Instance.Recv_RESP_ALLIANCEWAR_RANKPRIZE(MP);
											return;
										case Protocol._MSG_RESP_AWS_SCHEDULE:
											UI_AlliWarSchedule.RespSchedule(MP);
											return;
										}
										break;
									case Protocol._MSG_RESP_TRAPCONSTRUCT:
										DataManager.Instance.RecvTrapConstruct(MP);
										return;
									case Protocol._MSG_RESP_TRAPCOMPLETE:
										DataManager.Instance.RecvTrapComplete(MP);
										return;
									case Protocol._MSG_RESP_CANCELTRAPCONSTRUCT:
										DataManager.Instance.RecvCancelTrapConstruct(MP);
										return;
									case Protocol._MSG_RESP_TRAPDESTROY:
										DataManager.Instance.RecvTrapDestroy(MP);
										return;
									case Protocol._MSG_RESP_INSTANTTRAPCONSTRUCT:
										DataManager.Instance.RecvInstantTrapConstruct(MP);
										return;
									case Protocol._MSG_RESP_FINISHTRAPCONSTRCT:
										DataManager.Instance.RecvFinishTrapConstrct(MP);
										return;
									case Protocol._MSG_RESP_REPAIRTRAP:
										DataManager.Instance.RecvRePairTrap(MP);
										return;
									case Protocol._MSG_RESP_REPAIRTRAPCOMPLETE:
										DataManager.Instance.RecvRepairTrapComplete(MP);
										return;
									case Protocol._MSG_RESP_CANCELREPAIRTRAP:
										DataManager.Instance.RecvCancelRepairTrap(MP);
										return;
									case Protocol._MSG_RESP_INSTANTREPAIRTRAP:
										DataManager.Instance.RecvInstantRepairTrap(MP);
										return;
									case Protocol._MSG_RESP_FINISHREPAIRTRAP:
										DataManager.Instance.RecvFinishRepairTrap(MP);
										return;
									case Protocol._MSG_RESP_WALLBEINGATTACK:
										DataManager.Instance.RecvWallBeingAttack(MP);
										return;
									case Protocol._MSG_RESP_DEF_HEROINFO:
										DataManager.Instance.RecvDefendersID(MP);
										return;
									case Protocol._MSG_RESP_INSTANTWALLREPAIR:
										DataManager.Instance.RecvInstantWallRepair(MP);
										return;
									case Protocol._MSG_RESP_GIVEUP_TRAP_REPAIR:
										DataManager.Instance.RecvGiveUpTrap(MP);
										return;
									}
									break;
								case Protocol._MSG_RESP_CHANGE_BOUNTY:
									JailManage.MSG_RESP_CHANGE_BOUNTY(MP);
									return;
								case Protocol._MSG_RESP_PAY_RANSOM:
									JailManage.MSG_RESP_PAY_RANSOM(MP);
									return;
								case Protocol._MSG_RESP_LORD_BEINGRELEASED:
									JailManage.MSG_RESP_LORD_BEINGRELEASED(MP);
									return;
								case Protocol._MSG_RESP_LORD_BEINGEXECUTED:
									JailManage.MSG_RESP_LORD_BEINGEXECUTED(MP);
									return;
								case Protocol._MSG_RESP_LORD_HOME:
									JailManage.MSG_RESP_LORD_HOME(MP);
									return;
								case Protocol._MSG_RESP_LORD_REVIVE:
									JailManage.MSG_RESP_LORD_REVIVE(MP);
									return;
								case Protocol._MSG_RESP_PRISONER_NUM_AND_HIGHESTLEVEL:
									JailManage.MSG_RESP_PRISONER_NUM_AND_HIGHESTLEVEL(MP);
									return;
								case Protocol._MSG_RESP_PRISONER_LIST:
									JailManage.MSG_RESP_PRISONER_LIST(MP);
									return;
								case Protocol._MSG_RESP_ADD_PRISONER:
									JailManage.MSG_RESP_ADD_PRISONER(MP);
									return;
								case Protocol._MSG_RESP_UPDATE_PRISONER:
									JailManage.MSG_RESP_UPDATE_PRISONER(MP);
									return;
								case Protocol._MSG_RESP_PRISONER_ESCAPED:
									JailManage.MSG_RESP_PRISONER_ESCAPED(MP);
									return;
								case Protocol._MSG_RESP_PRISONER_BAILED:
									JailManage.MSG_RESP_PRISONER_BAILED(MP);
									return;
								case Protocol._MSG_RESP_RELEASE_ALL_PRISONER:
									JailManage.MSG_RESP_RELEASE_ALL_PRISONER(MP);
									return;
								case Protocol._MSG_RESP_CHANGE_RANSOM:
									JailManage.MSG_RESP_CHANGE_RANSOM(MP);
									return;
								case Protocol._MSG_RESP_RELEASE_PRISONER:
									JailManage.MSG_RESP_RELEASE_PRISONER(MP);
									return;
								case Protocol._MSG_RESP_EXECUTE_PRISONER:
									JailManage.MSG_RESP_EXECUTE_PRISONER(MP);
									return;
								case Protocol._MSG_RESP_MAP_PRISONER_LIST:
									JailManage.MSG_RESP_MAP_PRISONER_LIST(MP);
									return;
								case Protocol._MSG_RESP_ALTAR_BUFFTIME:
									DataManager.Instance.RecvAltarBuffTime(MP);
									return;
								case Protocol._MSG_RESP_ALTAR_BUFFCLOSED:
									DataManager.Instance.RecvAltarBuffClose();
									return;
								case Protocol._MSG_RESP_CLAIMBOUNTY:
									DataManager.Instance.Resource[4].Stock = MP.ReadUInt(-1);
									GameManager.OnRefresh(NetworkNews.Refresh_Resource, null);
									return;
								case Protocol._MSG_PRISON_RESP_PRISONER_POISONEFFECT:
									JailManage.MSG_PRISON_RESP_PRISONER_POISONEFFECT(MP);
									return;
								case Protocol._MSG_RESP_LORD_RELEASED_TIME:
									JailManage.RecvLordReleasedTime(MP);
									return;
								}
								break;
							case Protocol._MSG_RESP_ROLE_NAME_CHECK:
							case Protocol._MSG_RESP_ROLE_RENAME:
								DataManager.Instance.RecvUserRename(MP);
								return;
							case Protocol._MSG_RESP_ROLE_PRIZEFLAG:
								DataManager.Instance.RecvPrizeFlag(MP);
								return;
							case Protocol._MSG_RESP_STATISTIC:
								DataManager.Instance.RecvLordStatistic(MP);
								return;
							case Protocol._MSG_RESP_PROFILE:
								DataManager.Instance.RecvLordProfile(MP);
								return;
							case Protocol._MSG_RESP_BUFFINFO:
								DataManager.Instance.RecvIBuffInfo(MP);
								return;
							case Protocol._MSG_RESP_BUFFCOMPLETE:
								DataManager.Instance.RecvBuffComplete(MP);
								return;
							case Protocol._MSG_RESP_SEARCHPLAYER:
								DataManager.Instance.RecvSearchPlayer(MP);
								return;
							case Protocol._MSG_RESP_DAILY_RESET:
								DataManager.Instance.RecvDailyReset(MP);
								return;
							case Protocol._MSG_RESP_ONLINE_GIFT:
								DataManager.Instance.RecvOnline_Gift(MP);
								return;
							case Protocol._MSG_RESP_CASTLE_STATUS:
							{
								byte b7 = MP.ReadByte(-1);
								long happenTime = MP.ReadLong(-1);
								LandWalkerManager.HappenAttack(happenTime, b7 == 1);
								return;
							}
							case Protocol._MSG_RESP_ANNOUNCEMENT_PUBLISHING:
								GUIManager.Instance.RecvBackMessage(MP);
								return;
							case Protocol._MSG_RESP_PASSNEWBIE:
								GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4834u), DataManager.Instance.mStringTable.GetStringByID(117u), DataManager.Instance.mStringTable.GetStringByID(4836u), null, 0, 0, false, false, false, false, false);
								return;
							case Protocol._MSG_RESP_COMPENSATION_NOTICE:
								DataManager.Instance.RecvCompensation_Notice(MP);
								return;
							case Protocol._MSG_RESP_GET_COMPENSATION:
								DataManager.Instance.RecvGet_Compensation(MP);
								return;
							case Protocol._MSG_RESP_ANNOUNCEMENT_DELETE:
								GUIManager.Instance.RecvBackMessageDelete(MP);
								return;
							case Protocol._MSG_RESP_ACC_ADDICTIONTIME:
								DataManager.Instance.RoleAttr.AddictionTime = MP.ReadLong(-1);
								AntiAddictive.Instance.SetCumulativeTime(DataManager.Instance.RoleAttr.AddictionTime);
								AntiAddictive.Instance.Start(IGGGameSDK.Instance.GetAddictedCheckNoticeSW(), IGGGameSDK.Instance.GetAddictedCheckLimitLoginSW(), IGGGameSDK.Instance.m_RealNameState, IGGGameSDK.Instance.m_AgeState);
								return;
							case Protocol._MSG_RESP_PUSHBACK_PRIZE:
								MallManager.Instance.Recv_PUSHBACK_PRIZE(MP);
								return;
							case Protocol._MSG_RESP_SHIELD_LOG_LIST:
								ShieldLogManager.Instance.RecvShieldLogList(MP);
								return;
							case Protocol._MSG_UPDATE_SHIELD_LOG_LIST:
								ShieldLogManager.Instance.RecvShieldLogList(MP);
								return;
							}
							break;
						case Protocol._MSG_RESP_PET_TRAINING_BEGIN:
							PetManager.Instance.RecvPetTrainingBegin(MP);
							return;
						case Protocol._MSG_RESP_PET_TRAINING_CANCEL:
							PetManager.Instance.RecvPetTrainingCancel(MP);
							return;
						case Protocol._MSG_RESP_PET_TRAINING_COMPLETE:
							PetManager.Instance.RecvPetTrainingComplete(MP);
							return;
						case Protocol._MSG_RESP_PET_LIST:
							PetManager.Instance.RecvPetInfo(MP);
							return;
						case Protocol._MSG_RESP_PET_ADD_NEW_PET:
							PetManager.Instance.RecvPetAddNewPet(MP);
							return;
						case Protocol._MSG_RESP_UPDATE_PET:
							PetManager.Instance.RecvPetUpdate(MP);
							return;
						case Protocol._MSG_RESP_ITEMCRAFT:
							PetManager.Instance.Recv_MSG_RESP_ITEMCRAFT(MP);
							return;
						case Protocol._MSG_ITEMCRAFT_INFO:
							PetManager.Instance.Recv_MSG_ITEMCRAFT_INFO(MP);
							return;
						case Protocol._MSG_ITEMCRAFT_DONE:
							PetManager.Instance.Recv_MSG_ITEMCRAFT_DONE(MP);
							return;
						case Protocol._MSG_RESP_PET_CURRENT_STARUP:
							PetManager.Instance.Recv_PET_CURRENT_STARUP(MP);
							return;
						case Protocol._MSG_RESP_PET_STARUP_START:
							PetManager.Instance.Recv_PET_STARUP_START(MP);
							return;
						case Protocol._MSG_RESP_PET_STARUP_COMPLETE:
							PetManager.Instance.Recv_PET_STARUP_COMPLETE(MP);
							return;
						case Protocol._MSG_RESP_PET_STARUP_CANCEL:
							PetManager.Instance.Recv_PET_STARUP_CANCEL(MP);
							return;
						case Protocol._MSG_RESP_PETSKILL_USE:
							PetManager.Instance.Recv_PETSKILL_USE(MP);
							return;
						case Protocol._MSG_RESP_PETSKILL_GETSKILL:
							PetManager.Instance.Recv_PETSKILL_GETSKILL(MP);
							return;
						case Protocol._MSG_RESP_PETSKILL_FATIGUE:
							PetManager.Instance.Recv_PETSKILL_FATIGUE(MP);
							return;
						case Protocol._MSG_RESP_PETSKILL_COOLDOWN:
							PetManager.Instance.Recv_PETSKILL_COOLDOWN(MP);
							return;
						case Protocol._MSG_RESP_PETSKILL_BUFFINFO:
							PetManager.Instance.Recv_PETSKILL_BUFFINFO(MP);
							return;
						case Protocol._MSG_RESP_PETSKILL_BUFFCOMPLETE:
							PetManager.Instance.Recv_PETSKILL_BUFFCOMPLETE(MP);
							return;
						case Protocol._MSG_RESP_PETSKILL_UPGRADESKILL:
							PetManager.Instance.Recv_PETSKILL_UPGRADESKILL(MP);
							return;
						case Protocol._MSG_RESP_PETSKILL_UPGRADE_STONE_AMOUNT:
							PetManager.Instance.Recv_PETSKILL_UPGRADE_STONE_AMOUNT(MP);
							return;
						case Protocol._MSG_RESP_PET_OPENPETBOX:
							PetManager.Instance.Recv_MSG_RESP_PET_OPENPETBOX(MP);
							return;
						case Protocol._MSG_RESP_PET_MARCHEVENTDATA:
							PetManager.Instance.RecvPetMarchEventData(MP);
							return;
						case Protocol._MSG_RESP_PET_MARCH_END:
							PetManager.Instance.RecvPetMarchEnd(MP);
							return;
						case Protocol._MSG_RESP_PET_REPORTINFO:
							goto IL_2C95;
						case Protocol._MSG_RESP_PET_LIVEINFO:
							GUIManager.Instance.Recv_PET_LIVEINFO(MP);
							return;
						case Protocol._MSG_RESP_PETSKILL_STATE:
							DataManager.MapDataController.RESP_PETSKILL_STATE(MP);
							return;
						}
						break;
					case Protocol._MSG_RESP_SENDMAIL:
						DataManager.Instance.RecvSendMail(MP);
						return;
					case Protocol._MSG_RESP_COMBATREPLAY:
						GUIManager.Instance.HideUILock(EUILock.Mailing_Battle);
						WarManager.RecvStartWar(MP);
						return;
					case Protocol._MSG_RESP_COMBATDETAIL_LEADERDATA:
						DataManager.Instance.RecvCombatDetail_Leaderdata(MP);
						return;
					case Protocol._MSG_RESP_COMBATDETAIL_PLAYERDATA:
						break;
					case Protocol._MSG_RESP_LIVECOMBATREPLAYMETA:
						GUIManager.Instance.RecvBattleMessage(MP);
						return;
					case Protocol._MSG_RESP_LIVECOMBATREPLAY:
						WarManager.RecvFastStartWar(MP);
						return;
					case Protocol._MSG_RESP_LIVEMONSTERREPLAYMETA:
						GUIManager.Instance.RecvWMMessage(MP);
						return;
					case Protocol._MSG_RESP_LIVEWONDERREPLAYMETA:
						GUIManager.Instance.RecvWonderMessage(MP);
						return;
					case Protocol._MSG_RESP_COMBATDETAIL_INJUREDATA:
						goto IL_2B4B;
					case Protocol._MSG_RESP_COMBATDETAIL_ERROR:
					{
						byte b8 = MP.ReadByte(-1);
						GUIManager.Instance.HideUILock(EUILock.Mailing_Battle);
						GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8241u), 255, true);
						return;
					}
					}
					DataManager.Instance.RecvCombatDetail_Playerdata(MP);
					return;
					IL_2B4B:
					DataManager.Instance.RecvCombatDetail_Injuredata(MP);
					return;
					IL_2C95:
					DataManager.Instance.RecvMailing(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_EVENT_LIST:
					ActivityManager.Instance.RecvActivity_EventList(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_EVENT_LIST_SINGLE:
					ActivityManager.Instance.RecvActivity_EventListSingle(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_EVENT_DETAIL:
					ActivityManager.Instance.RecvActivity_EventDetail(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_RANKING_PRIZE:
					ActivityManager.Instance.RecvActivity_RankingPrize(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_GETPRIZE:
					ActivityManager.Instance.RecvActivity_GetPrize(MP);
					return;
				case Protocol._MSG_ACTIVITY_CLOSE:
					ActivityManager.Instance.RecvActivity_Close(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_SPEVENT_LIST_SINGLE:
					ActivityManager.Instance.RecvActivity_SpEvent_List_Single(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_UPDATE_INFO:
					ActivityManager.Instance.RecvActivity_UpDateInfo(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_KEVENT_LIST_SINGLE:
					ActivityManager.Instance.RecvActivity_KEventListSingle(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_KEVENT_DETAIL:
					ActivityManager.Instance.RecvActivity_KEventDetail(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_KEVENT_UPDATESTATE:
					ActivityManager.Instance.RecvActivity_Kevent_UpdateStateE(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_KEVENT_RANKING_PRIZE:
					ActivityManager.Instance.RecvActivity_Kevent_RankingPrize(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_AEVENT_PERSONAL_RANK:
					LeaderBoardManager.Instance.Recv_MSG_RESP_ACTIVITY_AEVENT_PERSONAL_RANK(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_AM_RANKING_PRIZE:
					ActivityManager.Instance.RecvActivity_AM_RankingPrize(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_AM_DEGREEPRIZE:
					MobilizationManager.Instance.RecvActivityAmDegeePrize(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_AM_GET_DEGREEPRIZE:
					MobilizationManager.Instance.RecvActivityAmGetDegreePrize(MP);
					return;
				case Protocol._MSG_RESP_ALLIANCEMOBLIZATION_MISSION_DATA:
					MobilizationManager.Instance.Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_DATA(MP);
					return;
				case Protocol._MSG_RESP_ALLIANCEMOBLIZATION_MISSION_BUY:
					MobilizationManager.Instance.Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_BUY(MP);
					return;
				case Protocol._MSG_RESP_ALLIANCEMOBLIZATION_MISSION_GET:
					MobilizationManager.Instance.Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_GET(MP);
					return;
				case Protocol._MSG_RESP_ALLIANCEMOBLIZATION_MISSION_DEL:
					MobilizationManager.Instance.Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_DEL(MP);
					return;
				case Protocol._MSG_RESP_ALLIANCEMOBLIZATION_MISSION_FINISH:
					MobilizationManager.Instance.Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_FINISH(MP);
					return;
				case Protocol._MSG_RESP_ALLIANCEMOBILIZATION_MISSION_UPDATE:
					MobilizationManager.Instance.Recv_MSG_RESP_ALLIANCEMOBILIZATION_MISSION_UPDATE(MP);
					return;
				case Protocol._MSG_RESP_ALLIANCEMOBILIZATION_MISSION_DONE:
					MobilizationManager.Instance.Recv_MSG_RESP_ALLIANCEMOBILIZATION_MISSION_DONE(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_AM_MEMBER_RANK:
					LeaderBoardManager.Instance.Recv_MSG_RESP_ACTIVITY_AM_MEMBER_RANK(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_AM_ALLIANCE_RANK:
					LeaderBoardManager.Instance.Recv_MSG_RESP_ACTIVITY_AM_ALLIANCE_RANK(MP);
					return;
				case Protocol._MSG_RESP_KINGOFTHEWORLD_KINGINFO:
					ActivityManager.Instance.RecvActivity_KOW_KingInfo(MP);
					return;
				case Protocol._MSG_RESP_KINGOFTHEWORLD_RANKDATA:
					LeaderBoardManager.Instance.Recv_MSG_RESP_KINGOFTHEWORLD_RANKDATA(MP);
					return;
				case Protocol._MSG_RESP_KINGOFTHEWORLD_HISTORYKINGDATA:
					LeaderBoardManager.Instance.Recv_MSG_RESP_KINGOFTHEWORLD_HISTORYKINGDATA(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_DAILYGIFT:
					DataManager.Instance.Recv_DailyGift(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_MARQUREEUPDATE:
					ActivityManager.Instance.RecvRunningText(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_SPEVENT_EXDATA:
					ActivityManager.Instance.RecvSPExtraData(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_MKEVENT_MATCHINFO:
					ActivityManager.Instance.RecvKvKMatchInfo(MP);
					return;
				case Protocol._MSG_RESP_GAMBLE_UPDATEINFO:
					GamblingManager.Instance.Recv_MSG_RESP_GAMBLE_UPDATEINFO(MP);
					return;
				case Protocol._MSG_RESP_NPCCITY_UPDATEINFO:
					ActivityManager.Instance.RecvNPCCITY_UPDATEINFO(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_AM_DEGREEPRIZE_NEW:
					MobilizationManager.Instance.RecvActivityAmDegeePrize_New(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_AS_UPDATESTATE:
					ActivityManager.Instance.RecvActivity_AllianceSummon_UpdateState(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_AS_SUMMON:
					DataManager.Instance.RecvActivityAsSummon(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_AS_SUMMON_KMSG:
					ActivityManager.Instance.RecvActivity_AllianceSummon_KMSG(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_AS_PERSONAL_RANK:
					LeaderBoardManager.Instance.Recv_MSG_RESP_AlliHunt_RANKDATA(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_AS_DONATE_BOARD:
					ActivityManager.Instance.Recv_Alliance_Donate(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_AS_DONATE_DATA:
					ActivityManager.Instance.Recv_Alliance_Donate_Data(MP);
					return;
				case Protocol._MSG_ALLIANCESUMMON_DONATEBOARDCHANGE:
					ActivityManager.Instance.Recv_Alliancesummon_DonateBoardChange(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_UPDATESTATE:
					ActivityManager.Instance.RecvActivity_UPDATESTATE(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_HKEVENT_HUNTINFO:
					ActivityManager.Instance.RecvKvKHuntInfo(MP);
					return;
				case Protocol._MSG_RESP_ALLIANCEMOBILIZATION_LEGENDRANK:
					LeaderBoardManager.Instance.Recv_MSG_RESP_ALLIANCEMOBILIZATION_LEGENDRANK(MP);
					return;
				case Protocol._MSG_RESP_ACTIVITY_AM_MEMBER_RANKEX:
					LeaderBoardManager.Instance.Recv_MSG_RESP_ACTIVITY_AM_MEMBER_RANKEX(MP);
					return;
				}
				break;
			case Protocol._MSG_RESP_ALLIANCE_NAMECHECK:
			case Protocol._MSG_RESP_ALLIANCE_TAGCHECK:
			case Protocol._MSG_RESP_ALLIANCE_CREATE:
			case Protocol._MSG_RESP_ALLIANCE_APPLY:
			case Protocol._MSG_RESP_ALLIANCE_USER_CANCELAPPLY:
			case Protocol._MSG_RESP_ALLIANCE_SEARCH:
			case Protocol._MSG_RESP_ALLIANCE_SRARCHRESULT:
			case Protocol._MSG_RESP_ALLIANCE_APPLYALLIANCELIST:
			case Protocol._MSG_RESP_ALLIANCE_MODIFY_NAME:
			case Protocol._MSG_RESP_ALLIANCE_MODIFY_TAG:
				DataManager.Instance.RecvAllianceCreate(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_DEALAPPLY:
				DataManager.Instance.RecvAllianceApplyResult(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_QUIT:
				DataManager.Instance.RecvAllianceQuit(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_MEMBERINFO:
				DataManager.Instance.RecvAllianceMember(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_OTHER_MEMBERINFO:
				DataManager.Instance.RecvAllianceOthorMemberInfo(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_APPLYLIST:
				DataManager.Instance.RecvAllianceApplyMember(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_STEPDOWN:
				DataManager.Instance.RecvAllianceStepDown(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_MODIFY_SLOGAN:
				DataManager.Instance.RecvAllianceSlogan(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_MODIFY_NEEDAPPLY:
				DataManager.Instance.RecvAllianceNeedApply(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_MODIFY_EMBLEM:
				DataManager.Instance.RecvAllianceModifyEmblem(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_MODIFY_LANGUAGE:
				DataManager.Instance.RecvAllianceModifyLanguage(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_MODIFY_BULLETIN:
				DataManager.Instance.RecvAllianceModifyBulletin(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_MODIFY_BRIEF:
				DataManager.Instance.RecvAllianceModifyBrief(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_MODIFY_RANK:
				DataManager.Instance.RecvAllianceModifyRank(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_QUITMEMBER:
				DataManager.Instance.RecvAllianceQuitMember(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_NEEDHELP_INFO:
				DataManager.Instance.RecvAllianceNeedHelp(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_HELP:
				DataManager.Instance.RecvAllianceHelp(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_SOMEBODY_NEEDHELP:
				DataManager.Instance.RecvAllianceSomebodyNeedHelp(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_HELP_SOMEBODY:
				DataManager.Instance.RecvAllianceHelpSomebody(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_PUBLICINFO:
				DataManager.Instance.RecvAlliancePublicInfo(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_UPDATEINFO:
				DataManager.Instance.RecvAllianceAttr(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_INVITE:
				DataManager.Instance.RecvAllianceInvite(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_GIFT_INFO:
				DataManager.Instance.RecvAllianceGift_Info(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_GIFT_OPENBOX:
				DataManager.Instance.RecvAllianceGift_Open(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_GIFT_DELETEBOX:
				DataManager.Instance.RecvAllianceGift_Delete(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_GIFT_CHECKEXPIRED:
				DataManager.Instance.RecvAllianceGift_CheckExpired(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_GIFT_OPENALLBOX:
				DataManager.Instance.RecvAllianceGift_OpenAllBox(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_WONDER_INFO:
				DataManager.Instance.RecvAllianceWonder_Info(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_MEMBERNICKNAME:
				DataManager.Instance.RecvAllianceMemberNickName(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_DISMISS_LEADER:
				DataManager.Instance.RecvAllanceDismissLeader(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_CHANGE_HOMEKINGDOM:
				DataManager.Instance.RecvAllance_Change_HomeKingdom(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_BOOKMARKINFO:
				DataManager.Instance.RoleBookMark.RecvBookMarkList_Alliance(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_MODIFYBOOKMARK:
				DataManager.Instance.RoleBookMark.RecvBookMarkAddModify_Alliance(MP);
				return;
			case Protocol._MSG_RESP_ALLIANCE_REMOVEBOOKMARK:
				DataManager.Instance.RoleBookMark.RecvBookMarkDel_Alliance(MP);
				return;
			}
			break;
		case Protocol._MSG_RESP_TRAINING_:
			DataManager.Instance.RecvTraining(MP);
			return;
		case Protocol._MSG_RESP_ADDSOLDIER_:
			DataManager.Instance.RecvAddSoldier(MP);
			return;
		case Protocol._MSG_RESP_CANCELTRAINING:
			DataManager.Instance.RecvCanceltraining(MP);
			return;
		case Protocol._MSG_RESP_TROOPDISMISS:
			DataManager.Instance.RecvTroopdismiss(MP);
			return;
		case Protocol._MSG_RESP_TRAINING_IMMEDIATELY:
			DataManager.Instance.RecvImmediately(MP);
			return;
		case Protocol._MSG_RESP_FINISHTRAINING:
			DataManager.Instance.RecvFinishtraining(MP);
			return;
		case Protocol._MSG_MARCH_MARCHEVENTDATA:
			DataManager.Instance.RecvMarchData(MP);
			return;
		case Protocol._MSG_RESP_TROOPMARCH:
			DataManager.Instance.RecvTroopMarch(MP);
			return;
		case Protocol._MSG_RESP_TROOPRETURN:
			DataManager.Instance.RecvTroopReturn(MP);
			return;
		case Protocol._MSG_RESP_TROOPHOME:
			DataManager.Instance.RecvTroopHome(MP);
			return;
		case Protocol._MSG_RESP_TROOPCAMPING:
			DataManager.Instance.RecvTroopCamping(MP);
			return;
		case Protocol._MSG_RESP_GATHERINGEVENT:
			DataManager.Instance.RecvGatheringEvent(MP);
			return;
		case Protocol._MSG_RESP_TROOPELIMINATE:
			DataManager.Instance.RecvTroopeliminate(MP);
			return;
		case Protocol._MSG_RESP_UPDATE_MARCHEVENTDATA:
			DataManager.Instance.RecvUpdateMarctEventData(MP);
			return;
		case Protocol._MSG_RESP_UPDATE_MARCHEVENTTIME:
			DataManager.Instance.UpdateMarchEventTime(MP);
			return;
		case Protocol._MSG_HOSPITAL_HOSPITALINFO:
			DataManager.Instance.RecvHospitalInfo(MP);
			return;
		case Protocol._MSG_RESP_HEALINGTROOP:
			DataManager.Instance.RecvHealingtroop(MP);
			return;
		case Protocol._MSG_RESP_HEALINGCOMPLETE:
			DataManager.Instance.RecvHealingcomplete(MP);
			return;
		case Protocol._MSG_RESP_CANCELHEALING:
			DataManager.Instance.RecvCancelealing(MP);
			return;
		case Protocol._MSG_RESP_INSTANTHEALING:
			DataManager.Instance.RecvInstanthealing(MP);
			return;
		case Protocol._MSG_RESP_FINISHHEALING:
			DataManager.Instance.RecvFinishhealing(MP);
			return;
		case Protocol._MSG_RESP_BEINGATTACK:
			DataManager.Instance.RecvBeingattack(MP);
			return;
		case Protocol._MSG_RESP_GIVEUP_HEALING:
			DataManager.Instance.RecvGiveUpHealing(MP);
			return;
		case Protocol._MSG_RESP_INITWATCHTOWER_INFO:
			DataManager.Instance.RecvInitWatchTowerInfo(MP);
			return;
		case Protocol._MSG_RESP_INITWATCHTOWER_INFOEND:
			DataManager.Instance.RecvInitWatchTowerInfoEnd(MP);
			return;
		case Protocol._MSG_RESP_UPDATEWATCHTOWER_ADDLINE:
			DataManager.Instance.RecvUpDateWatchTowerAddLine(MP);
			return;
		case Protocol._MSG_RESP_UPDATEWATCHTOWER_DELLINE:
			DataManager.Instance.RecvUpDateWatchTowerDelLine(MP);
			return;
		case Protocol._MSG_RESP_UPDATEWATCHTOWER_UPDATELINE:
			DataManager.Instance.RecvUpDateWatchTowerUpDateLine(MP);
			return;
		case Protocol._MSG_RESP_ADDCONFLICT_LINE:
			DataManager.Instance.RecvAddConflictLine(MP);
			return;
		case Protocol._MSG_RESP_DELCONFLICT_LINE:
			DataManager.Instance.RecvDelConflictLine(MP);
			return;
		case Protocol._MSG_RESP_WATCHTOWER_LINEDETAIL:
			DataManager.Instance.RecvWatchTowerLineDetail(MP);
			return;
		case Protocol._MSG_RESP_WATCHTOWER_LINEDETAIL_ERROR:
			DataManager.Instance.RecvWatchTowerLineDetail_ERROR(MP);
			return;
		case Protocol._MSG_RESP_SENDSCOUT:
			DataManager.Instance.RecvScout(MP);
			return;
		case Protocol._MSG_RESP_SCOUTRETURN:
			DataManager.Instance.RecvScoutReturn(MP);
			return;
		case Protocol._MSG_RESP_SCOUTHOME:
			DataManager.Instance.RecvScoutHome(MP);
			return;
		case Protocol._MSG_RESP_SEND_RESHELP:
			DataManager.Instance.RecvSHelp(MP);
			return;
		case Protocol._MSG_RESP_RESHELP_RETURN:
			DataManager.Instance.RecvHelp_Return(MP);
			return;
		case Protocol._MSG_RESP_RESHELP_HOME:
			DataManager.Instance.RecvHelp_Home(MP);
			return;
		case Protocol._MSG_RESP_INFORCE_INFO:
			DataManager.Instance.RecvInforce_Info(MP);
			return;
		case Protocol._MSG_RESP_EMBASSY_MSG:
			DataManager.Instance.RecvEmbassy_Msg(MP);
			return;
		case Protocol._MSG_RESP_SEND_INFORCE:
			DataManager.Instance.RecvSendInforce(MP);
			return;
		case Protocol._MSG_RESP_DISMISS_INFORCE:
			DataManager.Instance.RecvDimiss_Inforce(MP);
			return;
		case Protocol._MSG_RESP_INFORCE_ARRIVED:
			DataManager.Instance.RecvInforce_Arrived(MP);
			return;
		case Protocol._MSG_RESP_INFORCE_DISMISSRETURN:
			DataManager.Instance.RecvAllyInforceReturn(MP);
			return;
		case Protocol._MSG_RESP_ALLY_INFORCE_INFO:
			DataManager.Instance.RecvAllyInforceInfo(MP);
			return;
		case Protocol._MSG_RESP_BEGIN_RALLY:
			DataManager.Instance.RecvBeginRally(MP);
			return;
		case Protocol._MSG_RESP_CANCEL_RALLY:
			DataManager.Instance.RecvCancelRally(MP);
			return;
		case Protocol._MSG_RESP_JOIN_RALLY:
			DataManager.Instance.RecvJoinRally(MP);
			return;
		case Protocol._MSG_RESP_ARRIVED_RALLYPOINT:
			DataManager.Instance.RecvArrivedRallyPoint(MP);
			return;
		case Protocol._MSG_RESP_RALLY_ATKMARCH:
			DataManager.Instance.RecvRallyAtkMarch(MP);
			return;
		case Protocol._MSG_RESP_WARHALL_INITLIST:
			DataManager.Instance.RecvWallDataNum(MP);
			return;
		case Protocol._MSG_RESP_WARHALL_UPDATE_LISTELE:
			DataManager.Instance.RecvWallHallData(MP);
			return;
		case Protocol._MSG_RESP_WARHALL_DELETE_LISTELE:
			DataManager.Instance.RecvWallHallDel(MP);
			return;
		case Protocol._MSG_RESP_WARHALL_INIT_LISTDETAIL:
			DataManager.Instance.RecvWallHallDetail(MP);
			return;
		case Protocol._MSG_RESP_WARHALL_END_LISTDETAIL:
			DataManager.Instance.RecvWallHallDetailClose(MP);
			return;
		case Protocol._MSG_RESP_WARHALL_UPDATE_LISTDETAIL:
			DataManager.Instance.RecvWallHallTroop(MP);
			return;
		case Protocol._MSG_RESP_WARHALL_DELETE_LISTDETAIL:
			DataManager.Instance.RecvWallHallTroopDel(MP);
			return;
		case Protocol._MSG_RESP_BROCAST_WAR_BEGIN:
			DataManager.Instance.RecvWarBegin(MP);
			return;
		case Protocol._MSG_RESP_JOINED_RALLYDATA:
			DataManager.Instance.RecvJoinedRallyData(MP);
			return;
		case Protocol._MSG_RESP_SENDMONSTER:
			DataManager.MapDataController.RecvMapMonsterAttack(MP);
			return;
		case Protocol._MSG_RESP_MONSTERRETURN:
			DataManager.MapDataController.RecvMonsterReturn(MP);
			return;
		case Protocol._MSG_RESP_MONSTERHOME:
			DataManager.MapDataController.RecvMonsterHome(MP);
			return;
		case Protocol._MSG_RESP_MONSTER_INFO:
			DataManager.MapDataController.RecvMapMonsterInfo(MP);
			return;
		case Protocol._MSG_RESP_WONDEROCCUPIED:
			DataManager.Instance.RecvWonderOccupied(MP);
			return;
		case Protocol._MSG_RESP_WONDERINFORCE_ARRIVED:
			DataManager.Instance.RecvWonderInforceArrived(MP);
			return;
		case Protocol._MSG_RESP_WONDER_SEND_INFORCE:
			DataManager.Instance.RecvWonder_Send_Inforce(MP);
			return;
		case Protocol._MSG_RESP_WONDER_BEGIN_RALLY:
			DataManager.Instance.RecvWonder_Begin_Rally(MP);
			return;
		case Protocol._MSG_RESP_WONDER_RALLY_ATKMARCH:
			DataManager.Instance.RecvWonder_Rally_Atkmarch(MP);
			return;
		case Protocol._MSG_RESP_WONDERTEAM_INIT_LISTDETAIL:
			DataManager.Instance.RespWonderTeamInitDetail(MP);
			return;
		case Protocol._MSG_RESP_WONDERTEAM_END_LISTDETAIL:
			DataManager.Instance.RespWonderTeamEnd(MP);
			return;
		case Protocol._MSG_RESP_WONDERTEAM_UPDATE_LISTDETAIL:
			DataManager.Instance.RespWonderTeamUpdate(MP);
			return;
		case Protocol._MSG_RESP_WONDERTEAM_DELETE_LISTDETAIL:
			DataManager.Instance.RespWinderTeamDel(MP);
			return;
		case Protocol._MSG_RESP_WONDER_WARHALL_UPDATE_LISTELE:
			break;
		case Protocol._MSG_RESP_WONDER_WARHALL_INIT_LISTDETAIL:
			goto IL_370C;
		case Protocol._MSG_RESP_JOINED_UPDATERALLYSPEED:
			DataManager.Instance.UpdateJoinedMarchEventTime(MP);
			return;
		case Protocol._MSG_RESP_AMBUSH_INFO:
			AmbushManager.Instance.RecvAmbushInfo(MP);
			return;
		case Protocol._MSG_RESP_AMBUSH_UPDATE:
			AmbushManager.Instance.RecvAmbushUpdate(MP);
			return;
		case Protocol._MSG_RESP_DISMISS_AMBUSH:
			AmbushManager.Instance.RecvDismissAmbush(MP);
			return;
		case Protocol._MSG_RESP_ALLY_AMBUSH_INFO:
			AmbushManager.Instance.RecvAllyAmbushInfo(MP);
			return;
		case Protocol._MSG_RESP_SEND_AMBUSH:
			AmbushManager.Instance.RecvAmbush(MP);
			return;
		case Protocol._MSG_RESP_AMBUSHARRIVED:
			AmbushManager.Instance.RecvAmbushArrived(MP);
			return;
		case Protocol._MSG_RESP_AMBUSH_RETURN:
			AmbushManager.Instance.RecvAmbushReturn(MP);
			return;
		}
		IL_36FC:
		DataManager.Instance.RespWonderWarhallList(MP);
		return;
		IL_370C:
		DataManager.Instance.RespWonderListDetail(MP);
	}

	// Token: 0x0400111C RID: 4380
	private static DispatchManager instance;
}
