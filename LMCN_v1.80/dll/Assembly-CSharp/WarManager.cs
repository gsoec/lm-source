using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200074A RID: 1866
public class WarManager : Gameplay
{
	// Token: 0x170000E4 RID: 228
	// (get) Token: 0x060023B5 RID: 9141 RVA: 0x00414084 File Offset: 0x00412284
	public static bool IsActive
	{
		get
		{
			return GameManager.ActiveGameplay is WarManager;
		}
	}

	// Token: 0x170000E5 RID: 229
	// (get) Token: 0x060023B6 RID: 9142 RVA: 0x00414098 File Offset: 0x00412298
	public static bool IsNpcModeEnable
	{
		get
		{
			return WarManager.IsActive && WarManager.WarKind == WarManager.EWarKind.Normal && WarManager.NpcModeEnable == 1;
		}
	}

	// Token: 0x060023B7 RID: 9143 RVA: 0x004140BC File Offset: 0x004122BC
	~WarManager()
	{
	}

	// Token: 0x060023B8 RID: 9144 RVA: 0x004140F4 File Offset: 0x004122F4
	protected override void UpdateNews(byte[] meg)
	{
		if (meg[0] == 2)
		{
			this.CloseDrama();
		}
	}

	// Token: 0x060023B9 RID: 9145 RVA: 0x00414108 File Offset: 0x00412308
	protected override void UpdateNext(byte[] meg)
	{
		this.ClearUpdateDelegates();
		if (this.controlPanel != null)
		{
			UnityEngine.Object.Destroy(this.controlPanel.gameObject);
			this.controlPanel = null;
		}
		AudioManager.Instance.RetrieveSFX();
		if (this.movingSoundParentTrans != null)
		{
			UnityEngine.Object.Destroy(this.movingSoundParentTrans.gameObject);
			this.movingSoundParentTrans = null;
		}
		if (this.castle != null)
		{
			this.castle.Destroy();
			this.castle = null;
		}
		for (int i = 0; i < (int)this.attackerCount; i++)
		{
			this.attackerArmies[i].Destroy();
			this.attackerArmies[i] = null;
		}
		for (int j = 0; j < (int)this.defenserCount; j++)
		{
			this.defenserArmies[j].Destroy();
			this.defenserArmies[j] = null;
		}
		for (int k = 0; k < this.m_BrokenFO[0].Length; k++)
		{
			this.m_BrokenFO[0][k].Destroy();
			this.m_BrokenFO[0][k] = null;
		}
		for (int l = 0; l < this.m_BrokenFO[1].Length; l++)
		{
			this.m_BrokenFO[1][l].Destroy();
			this.m_BrokenFO[1][l] = null;
		}
		for (int m = 0; m < this.attackerHeroCache.Count; m++)
		{
			this.attackerHeroCache[m].Destroy();
		}
		this.attackerHeroCache.Clear();
		for (int n = 0; n < this.defenserHeroCache.Count; n++)
		{
			this.defenserHeroCache[n].Destroy();
		}
		this.defenserHeroCache.Clear();
		if (this.FOMgr != null)
		{
			this.FOMgr.Destroy();
			this.FOMgr = null;
		}
		if (this.LordCage != null)
		{
			UnityEngine.Object.Destroy(this.LordCage.gameObject);
			this.LordCage = null;
			AssetManager.UnloadAssetBundle(this.CageKey, true);
		}
		SheetAnimInfo.Instance.DestroyAllMesh();
		if (Soldier.shadowABKey != 0)
		{
			AssetManager.UnloadAssetBundle(Soldier.shadowABKey, true);
			Soldier.shadowABKey = 0;
		}
		this.WCamera = null;
		this.bstart = false;
		this.particleMgr.Clear();
		this.particleMgr = null;
		if (this.renderRoot)
		{
			UnityEngine.Object.Destroy(this.renderRoot.gameObject);
		}
		AudioManager.Instance.SetSFXEnvironment(SFXKind.Normal);
		GUIManager.Instance.pDVMgr.EndWarClear();
		AssetManager.UnloadBigMap();
		GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Battle);
	}

	// Token: 0x060023BA RID: 9146 RVA: 0x004143B0 File Offset: 0x004125B0
	protected override void UpdateLoad(byte[] meg)
	{
		GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Battle);
		GameManager.RegisterObserver(1, 0, this, 1);
		this.BSUtil = BSInvokeUtil.getInstance;
		DataManager instance = DataManager.Instance;
		if (WarManager.WarKind == WarManager.EWarKind.CoordTest)
		{
			WarManager.SetCoordTestWarData();
			WarManager.WarCoordIndex_Left = WarManager.CoordSimuIndex_Left;
			WarManager.WarCoordIndex_Right = WarManager.TroopKindSimuIndex_Right;
			WarManager.SetupCoordinate((int)WarManager.CoordSimuIndex_Left, (int)WarManager.TroopKindSimuIndex_Right);
		}
		else
		{
			WarManager.SetupCoordinate((int)WarManager.WarCoordIndex_Left, (int)WarManager.WarCoordIndex_Right);
		}
		this.BSUtil.InitCSSimulator(instance.War_RndSeed, instance.War_RndGap);
		if (NewbieManager.IsNewbie)
		{
			WarManager.WarKind = WarManager.EWarKind.Newbie;
		}
		this.deltaTime = 0f;
		this.particleMgr.Setup();
		if (WarManager.NpcModeEnable != 0)
		{
			instance.War_MapKind = 3;
		}
		this.actionKind = ((!instance.bWarAttacker) ? EPlayerActionKind.DEFENDER : EPlayerActionKind.ATTACKER);
		this.renderRoot = new GameObject("Root").transform;
		AssetManager.LoadMap(instance.War_MapKind, instance.War_MapTheme, this.particleMgr);
		LightmapManager.Instance.UpdateSceneAmbient();
		this.loadWarInfo(false);
		this.DramaTriggerFlag = DataManager.Instance.DramaTriggerFlag;
		if (instance.bWarAttacker)
		{
			for (int i = 0; i < (int)this.attackerCount; i++)
			{
				this.playerSideArmies[i] = this.attackerArmies[i];
			}
			for (int j = 0; j < (int)this.defenserCount; j++)
			{
				this.enemySideArmies[j] = this.defenserArmies[j];
			}
			this.enemySideArmies[16] = this.castle;
			this.playerCount = this.attackerCount;
			this.enemyCount = this.defenserCount;
		}
		else
		{
			for (int k = 0; k < (int)this.defenserCount; k++)
			{
				this.playerSideArmies[k] = this.defenserArmies[k];
			}
			this.playerSideArmies[16] = this.castle;
			for (int l = 0; l < (int)this.attackerCount; l++)
			{
				this.enemySideArmies[l] = this.attackerArmies[l];
			}
			this.playerCount = this.defenserCount;
			this.enemyCount = this.attackerCount;
		}
		if (this.attackerLord != null || this.defenserLord != null || this.attackerLordUnit != null || this.defenserLordUnit != null)
		{
			AssetBundle assetBundle = AssetManager.GetAssetBundle("Role/WarObj_001", out this.CageKey, false);
			if (assetBundle != null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
				MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
				component.material = SheetAnimInfo.GetMaterial(ESheetMeshTexKind.WAR_BLUE);
				int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
				int lightmapIndex = 2 + sceneLightmapSize;
				component.lightmapIndex = lightmapIndex;
				this.LordCage = gameObject.transform;
				gameObject.SetActive(false);
			}
		}
		GameObject gameObject2 = new GameObject("Catcher");
		gameObject2.layer = 5;
		GUIManager.Instance.StretchTransform(gameObject2.AddComponent<RectTransform>());
		gameObject2.transform.SetParent(GUIManager.Instance.m_UICanvas.transform, false);
		gameObject2.transform.SetAsFirstSibling();
		this.controlPanel = gameObject2.AddComponent<WarControlPanel>();
		this.controlPanel.sprite = null;
		this.controlPanel.material = GUIManager.Instance.m_IconSpriteAsset.GetMaterial();
		this.controlPanel.color = new Color(0f, 0f, 0f, 0f);
		this.controlPanel.warManager = this;
		RectTransform canvasRT = GUIManager.Instance.pDVMgr.CanvasRT;
		this.ScreenSize = canvasRT.sizeDelta;
		this.WCamera.initCamera(this.attackerArmies, (int)this.attackerCount, this.defenserArmies, (int)this.defenserCount);
		if (WarManager.WarKind == WarManager.EWarKind.CoordTest)
		{
			this.WCamera.CoordCamMode = true;
		}
		this.uiBattle = (UILegBattle)GUIManager.Instance.OpenMenu(EGUIWindow.UI_LegBattle, (int)this.actionKind, (WarManager.WarKind != WarManager.EWarKind.CoordTest) ? 0 : 1, false, false, false);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 0, 0);
		this.NewbieWarFlag = ((!NewbieManager.IsNewbie) ? 0 : 1);
		if (this.NewbieWarFlag != 0)
		{
			this.uiBattle.gameObject.SetActive(false);
			GUIManager.Instance.HideChatBox();
		}
		FSMManager.Instance.bIsBattleOver = false;
		Resources.UnloadUnusedAssets();
		GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
		AssetManager.Instance.AssetManagerState = AssetState.Ready;
		if (WarManager.WarKind != WarManager.EWarKind.CoordTest)
		{
			this.m_WarState = WarManager.WarState.WAITING_FOR_START;
		}
		else
		{
			this.m_WarState = WarManager.WarState.CHANGE_COORD_MODE;
		}
		AudioManager.Instance.SetSFXEnvironment(SFXKind.Legion);
		AudioManager.Instance.LoadAndPlayBGM(BGMType.LegionWar, 1, false);
		this.movingSoundParentTrans = new GameObject("SoundNode").transform;
		this.movingSoundParentTrans.position = new Vector3(55f, 0f, 15f);
		GUIManager.Instance.pDVMgr.BeginWarInitial();
		float fillAmount = instance.CurWallHp / instance.MaxWallHp;
		byte side = (this.actionKind != EPlayerActionKind.ATTACKER) ? 0 : 1;
		GUIManager.Instance.pDVMgr.SetBloodBarFillAmount((int)side, 16, fillAmount);
	}

	// Token: 0x060023BB RID: 9147 RVA: 0x00414900 File Offset: 0x00412B00
	protected override void UpdateReady(byte[] meg)
	{
	}

	// Token: 0x060023BC RID: 9148 RVA: 0x00414904 File Offset: 0x00412B04
	protected override void UpdateRun(byte[] meg)
	{
		if (this.m_WarState == WarManager.WarState.STOP)
		{
			return;
		}
		float smoothDeltaTime = Time.smoothDeltaTime;
		this.deltaTime += smoothDeltaTime;
		float num = 0f;
		if (this.deltaTime >= 0.1f)
		{
			if (this.m_WarState == WarManager.WarState.WAITING_FOR_START)
			{
				if (this.deltaTime >= 1.1f)
				{
					if (this.SubState == 0)
					{
						ushort num2 = (ushort)(this.DramaTriggerFlag & 65535u);
						if (num2 != 0)
						{
							ushort num3 = DataManager.Instance.pLeftLeaderData[0].HeroID;
							if (num3 == 0)
							{
								num3 = DataManager.Instance.RoleAttr.Head;
							}
							GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, (int)num2, (int)num3);
							if (this.controlPanel != null)
							{
								this.controlPanel.gameObject.SetActive(false);
							}
							this.checkPickHero(false);
							this.DramaTriggerFlag &= 4294901760u;
							this.bDramaWorking = true;
							this.SubState = 1;
							if (NewbieManager.IsNewbie)
							{
								NewbieLog.Log(ENewbieLogKind.FORCE_1, 2);
							}
						}
						else
						{
							this.SubState = 2;
						}
					}
					else if (this.SubState == 1 && !this.bDramaWorking)
					{
						this.SubState = 2;
					}
				}
				if (this.SubState == 2)
				{
					if (this.SiegeMode > 2)
					{
						if (this.nonCatapultsCount_Right != 0)
						{
							int siegeMode = this.SiegeMode;
							this.SiegeMode = 2;
							this.changeSiegeMode(siegeMode);
						}
						else
						{
							this.m_WarState = WarManager.WarState.RUNNING;
						}
					}
					else
					{
						this.m_WarState = WarManager.WarState.RUNNING;
					}
					this.deltaTime = 0f;
				}
			}
			else if (this.m_WarState != WarManager.WarState.CHANGE_COORD_MODE)
			{
				if (this.m_WarState == WarManager.WarState.RUNNING)
				{
					this.m_WarResult = (EWarResult)this.BSUtil.updateWarData(this.m_ui32Tcik, this.RecvBufferLeft, this.RecvBufferRight);
					this.m_ui32Tcik += 1u;
					this.deltaTime -= 0.1f;
					num = this.deltaTime;
					num = Mathf.Min(0.1f, num);
					this.fixMoveDeltaTime = num;
					this.canMoveDeltaTime = 0.1f;
					if (this.NewbieWarFlag == 0 || this.m_ui32Tcik <= 140u)
					{
						this.decodeSimuPackage(this.RecvBufferLeft, this.RecvBufferRight);
					}
					else
					{
						if (this.NewbieWarFlag == 1)
						{
							this.NewbieWarFlag = 2;
							this.DramaTriggerFlag = 0u;
							GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, 2, 1);
							if (this.controlPanel != null)
							{
								this.controlPanel.gameObject.SetActive(false);
							}
							this.checkPickHero(false);
							this.bDramaWorking = true;
							NewbieLog.Log(ENewbieLogKind.FORCE_1, 3);
						}
						this.m_WarResult = EWarResult.NONE;
					}
					if (this.m_bSkillDirty)
					{
						this.UpdateSkillLightmap();
						this.m_bSkillDirty = false;
					}
					if (this.SoundDirtyFlag != 0u)
					{
						this.CheckSound();
						this.SoundDirtyFlag = 0u;
					}
					if (DataManager.Instance.bWarMoraleSpecialCale && this.m_ui32Tcik > 150u && this.m_ui32Tcik % 10u == 0u)
					{
						DataManager.Instance.WarMorale[0] -= this.MoraleStep;
						this.UIUpdateFlag |= 1;
					}
					this.checkResult(false);
					if (this.UIUpdateFlag != 0)
					{
						if ((this.UIUpdateFlag & 1) != 0)
						{
							GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 1, 0);
						}
						if ((this.UIUpdateFlag & 2) != 0)
						{
							GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 1, 1);
						}
						if ((this.UIUpdateFlag & 4) != 0)
						{
							GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 1, 2);
						}
						this.UIUpdateFlag = 0;
					}
				}
				else if (this.m_WarState != WarManager.WarState.CHANGING_SIEGE_MODE)
				{
					if (this.m_WarState == WarManager.WarState.CASTLE_DESTROYING)
					{
						if (this.castle.State == ArmyGroup.EGROUPSTATE.DESTROYED)
						{
							this.castle.groupRoot.gameObject.SetActive(false);
							if (!this.checkResult(true))
							{
								this.m_WarState = WarManager.WarState.RUNNING;
							}
							GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 3, 0);
							this.deltaTime = 0f;
							for (int i = 0; i < this.attackerArmies.Length; i++)
							{
								if (this.attackerArmies[i] != null && this.attackerArmies[i].HasHeroDisplay)
								{
									this.attackerArmies[i].setLordAnimEnable(true);
								}
							}
							for (int j = 0; j < this.defenserArmies.Length; j++)
							{
								if (this.defenserArmies[j] != null && this.defenserArmies[j].HasHeroDisplay)
								{
									this.defenserArmies[j].setLordAnimEnable(true);
								}
							}
							this.setOutsideHeroAnimEnable(true);
						}
					}
					else if (this.m_WarState == WarManager.WarState.FINISHING)
					{
						this.m_SkillWorkingList = 0UL;
						this.UpdateSkillLightmap();
						GUIManager.Instance.pDVMgr.NextWar();
						this.checkPickHero(false);
						if (this.AttackSoundKey != 21)
						{
							this.audioMgr.StopSFX(this.AttackSoundKey, true);
						}
						if (this.MovingSoundKey != 21)
						{
							this.audioMgr.StopSFX(this.MovingSoundKey, true);
						}
						for (int k = 0; k < this.attackerArmies.Length; k++)
						{
							if (this.attackerArmies[k] != null && this.attackerArmies[k].HasHeroDisplay)
							{
								this.attackerArmies[k].setLordAnimEnable(true);
							}
						}
						for (int l = 0; l < this.defenserArmies.Length; l++)
						{
							if (this.defenserArmies[l] != null && this.defenserArmies[l].HasHeroDisplay)
							{
								this.defenserArmies[l].setLordAnimEnable(true);
							}
						}
						this.setOutsideHeroAnimEnable(true);
						if (this.attackerLord != null && this.m_WarResult == EWarResult.LOSE)
						{
							if (DataManager.Instance.War_LordCapture == 0)
							{
								this.attackerLord.LordRunAway(true);
								GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 2, 0);
							}
						}
						else if (this.defenserLord != null && this.m_WarResult == EWarResult.WIN)
						{
							if (DataManager.Instance.War_LordCapture == 0)
							{
								this.defenserLord.LordRunAway(false);
								GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 2, 1);
							}
						}
						else
						{
							for (int m = 0; m < (int)this.attackerCount; m++)
							{
								if (this.attackerArmies[m].CurHP > 0)
								{
									this.attackerArmies[m].State = ArmyGroup.EGROUPSTATE.IDLE_WITHOUT_CLUMP;
								}
							}
							for (int n = 0; n < (int)this.defenserCount; n++)
							{
								if (this.defenserArmies[n].CurHP > 0)
								{
									this.defenserArmies[n].State = ArmyGroup.EGROUPSTATE.IDLE_WITHOUT_CLUMP;
								}
							}
						}
						this.SubState = 1;
						this.deltaTime = 0f;
						this.m_WarState = WarManager.WarState.RETREAT;
					}
					else if (this.m_WarState == WarManager.WarState.RETREAT)
					{
						if (this.SubState == 0)
						{
							if (this.deltaTime >= 2f)
							{
								this.SubState = 1;
							}
						}
						else
						{
							if (this.m_WarResult == EWarResult.WIN)
							{
								if (DataManager.Instance.War_LordCapture != 0 && this.defenserLordUnit != null)
								{
									for (int num4 = 0; num4 < this.defenserHeroCache.Count; num4++)
									{
										this.defenserHeroCache[num4].LordAnimSetting(2);
										if (this.defenserHeroCache[num4].IsLord)
										{
											this.defenserHeroCache[num4].PlayAnim(ESheetMeshAnim.die, SAWrapMode.Loop, true, false, false);
										}
										else
										{
											this.defenserHeroCache[num4].FSMController = FSMManager.Instance.getState(EStateName.DEFENSER_RUN_AWAY);
										}
									}
									int num5 = 0;
									for (int num6 = 0; num6 < (int)this.attackerCount; num6++)
									{
										if (this.attackerArmies[num6].GroupKind != EGroupKind.Catapults)
										{
											this.attackerArmies[num6].SoldierTarget = this.defenserLordUnit;
											this.attackerArmies[num6].State = ArmyGroup.EGROUPSTATE.GO_CAPTIVING;
											num5 += this.attackerArmies[num6].CurrentSoldierCount;
										}
									}
									this.CageState = 1;
									FSMManager.Instance.MaxCaptiver = num5;
									FSMManager.Instance.CaptivingCount = 0;
									this.CageTargetPos = this.defenserLordUnit.transform.position;
									this.WCamera.SetTargetPosition(this.CageTargetPos, true, 1f);
									this.SubState = 3;
								}
								else
								{
									if (this.defenserLord == null && this.defenserAliveCount > 0)
									{
										this.uiBattle.AddCenterMsg(1, 0);
									}
									if (this.SiegeMode > 1)
									{
										for (int num7 = 0; num7 < (int)this.attackerCount; num7++)
										{
											if (this.attackerArmies[num7].GroupKind != EGroupKind.Catapults)
											{
												this.attackerArmies[num7].State = ArmyGroup.EGROUPSTATE.VICTORY;
											}
										}
										for (int num8 = 0; num8 < (int)this.defenserCount; num8++)
										{
											this.defenserArmies[num8].State = ArmyGroup.EGROUPSTATE.DEFENSER_RUN_AWAY;
										}
										for (int num9 = 0; num9 < this.defenserHeroCache.Count; num9++)
										{
											this.defenserHeroCache[num9].LordAnimSetting(2);
											this.defenserHeroCache[num9].FSMController = FSMManager.Instance.getState(EStateName.DEFENSER_RUN_AWAY);
										}
									}
									else
									{
										for (int num10 = 0; num10 < (int)this.attackerCount; num10++)
										{
											if (this.attackerArmies[num10].GroupKind != EGroupKind.Catapults)
											{
												this.attackerArmies[num10].State = ArmyGroup.EGROUPSTATE.ATTACKER_CHASING;
											}
										}
										for (int num11 = 0; num11 < (int)this.defenserCount; num11++)
										{
											this.defenserArmies[num11].State = ArmyGroup.EGROUPSTATE.DEFENSER_RUN_AWAY;
										}
										for (int num12 = 0; num12 < this.defenserHeroCache.Count; num12++)
										{
											this.defenserHeroCache[num12].LordAnimSetting(2);
											this.defenserHeroCache[num12].FSMController = FSMManager.Instance.getState(EStateName.DEFENSER_RUN_AWAY);
										}
										if (this.nonCatapultsCount_Left != 0)
										{
											this.WCamera.SetTargetPosition(new Vector3(80f, 0f, 15f), true, 1.4f);
										}
									}
									this.SubState = 0;
								}
							}
							else if (this.m_WarResult == EWarResult.LOSE)
							{
								if (this.attackerLordUnit != null && DataManager.Instance.War_LordCapture != 0)
								{
									for (int num13 = 0; num13 < this.attackerHeroCache.Count; num13++)
									{
										this.attackerHeroCache[num13].LordAnimSetting(2);
										if (this.attackerHeroCache[num13].IsLord)
										{
											this.attackerHeroCache[num13].PlayAnim(ESheetMeshAnim.die, SAWrapMode.Loop, true, false, false);
										}
										else
										{
											this.attackerHeroCache[num13].FSMController = FSMManager.Instance.getState(EStateName.ATTACKER_RUN_AWAY);
										}
									}
									if (this.SiegeMode < 4 && this.SiegeMode > 1)
									{
										int num14 = 0;
										for (int num15 = 0; num15 < (int)this.defenserCount; num15++)
										{
											if (this.defenserArmies[num15].GroupKind != EGroupKind.Catapults)
											{
												this.defenserArmies[num15].SoldierTarget = this.attackerLordUnit;
												this.defenserArmies[num15].CommonFlag |= 1u;
												if (this.defenserArmies[num15].GroupKind != EGroupKind.Archer && this.SiegeMode == 3)
												{
													this.defenserArmies[num15].State = ArmyGroup.EGROUPSTATE.GO_CAPTIVING;
												}
												else
												{
													this.defenserArmies[num15].State = ((this.defenserArmies[num15].GroupKind != EGroupKind.Archer) ? ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN : ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL);
												}
												num14 += this.defenserArmies[num15].CurrentSoldierCount;
											}
										}
										FSMManager.Instance.MaxCaptiver = num14;
										this.SubState = 1;
									}
									else
									{
										int num16 = 0;
										for (int num17 = 0; num17 < (int)this.defenserCount; num17++)
										{
											if (this.defenserArmies[num17].GroupKind != EGroupKind.Catapults)
											{
												this.defenserArmies[num17].SoldierTarget = this.attackerLordUnit;
												this.defenserArmies[num17].State = ArmyGroup.EGROUPSTATE.GO_CAPTIVING;
												num16 += this.defenserArmies[num17].CurrentSoldierCount;
											}
										}
										FSMManager.Instance.MaxCaptiver = num16;
										this.SubState = 3;
									}
									this.CageState = 1;
									FSMManager.Instance.CaptivingCount = 0;
									this.CageTargetPos = this.attackerLordUnit.transform.position;
									this.WCamera.SetTargetPosition(this.CageTargetPos, true, 1f);
								}
								else
								{
									if (this.attackerLord == null && this.attackerAliveCount > 0)
									{
										this.uiBattle.AddCenterMsg(0, 0);
									}
									if (this.SiegeMode > 1)
									{
										for (int num18 = 0; num18 < (int)this.defenserCount; num18++)
										{
											if (this.defenserArmies[num18].GroupKind != EGroupKind.Catapults)
											{
												this.defenserArmies[num18].State = ArmyGroup.EGROUPSTATE.VICTORY;
											}
										}
										for (int num19 = 0; num19 < (int)this.attackerCount; num19++)
										{
											this.attackerArmies[num19].State = ArmyGroup.EGROUPSTATE.ATTACKER_RUN_AWAY;
										}
										for (int num20 = 0; num20 < this.attackerHeroCache.Count; num20++)
										{
											this.attackerHeroCache[num20].LordAnimSetting(2);
											this.attackerHeroCache[num20].FSMController = FSMManager.Instance.getState(EStateName.ATTACKER_RUN_AWAY);
										}
										if (this.SiegeMode == 2)
										{
											float num21 = 0f;
											int num22 = 0;
											for (int num23 = 0; num23 < (int)this.defenserCount; num23++)
											{
												if (this.defenserArmies[num23].GroupKind != EGroupKind.Catapults)
												{
													num21 += this.defenserArmies[num23].groupRoot.position.x;
													num22++;
												}
											}
											if (num22 != 0)
											{
												num21 /= (float)num22;
												this.WCamera.SetTargetPosition(new Vector3(num21, 0f, 15f), true, 1f);
											}
											else
											{
												this.WCamera.SetTargetPosition(new Vector3(55f, 0f, 15f), true, 1f);
											}
										}
									}
									else
									{
										Vector3 vector = Vector3.zero;
										int num24 = 0;
										for (int num25 = 0; num25 < (int)this.defenserCount; num25++)
										{
											if (this.defenserArmies[num25].GroupKind != EGroupKind.Catapults)
											{
												this.defenserArmies[num25].State = ArmyGroup.EGROUPSTATE.DEFENSER_CHASING;
												if (this.defenserArmies[num25].CurHP > 0)
												{
													vector += this.defenserArmies[num25].groupRoot.position;
													num24++;
												}
											}
										}
										for (int num26 = 0; num26 < (int)this.attackerCount; num26++)
										{
											this.attackerArmies[num26].State = ArmyGroup.EGROUPSTATE.ATTACKER_RUN_AWAY;
										}
										for (int num27 = 0; num27 < this.attackerHeroCache.Count; num27++)
										{
											this.attackerHeroCache[num27].LordAnimSetting(2);
											this.attackerHeroCache[num27].FSMController = FSMManager.Instance.getState(EStateName.ATTACKER_RUN_AWAY);
										}
										if (num24 != 0)
										{
											vector /= (float)num24;
											this.WCamera.SetTargetPosition(vector, true, 1f);
										}
									}
									this.SubState = 0;
								}
							}
							this.audioMgr.PlaySFXLoop(20012, out this.MovingSoundKey, this.movingSoundParentTrans, SFXEffect.Normal, 0f);
							GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 3, 0);
							this.deltaTime = 0f;
							this.m_WarState = WarManager.WarState.WAITTING_FOR_VICTORY;
						}
					}
					else if (this.m_WarState == WarManager.WarState.WAITTING_FOR_VICTORY)
					{
						if (this.SubState == 0)
						{
							if (this.deltaTime >= 2.5f)
							{
								this.deltaTime = 0f;
								this.SubState = 3;
							}
						}
						else if (this.SubState == 2)
						{
							int num28 = 0;
							for (int num29 = 0; num29 < (int)this.defenserCount; num29++)
							{
								if (this.defenserArmies[num29].GroupKind != EGroupKind.Catapults && this.defenserArmies[num29].State != ArmyGroup.EGROUPSTATE.GO_CAPTIVING)
								{
									if ((this.defenserArmies[num29].CommonFlag & 1u) != 0u)
									{
										this.defenserArmies[num29].State = ArmyGroup.EGROUPSTATE.GO_CAPTIVING;
									}
								}
								else
								{
									num28++;
								}
							}
							if (num28 >= (int)this.defenserCount)
							{
								this.deltaTime = 0f;
								this.SubState = 3;
							}
						}
						else if (this.SubState == 3)
						{
							ushort num30 = (ushort)(this.DramaTriggerFlag >> 16 & 65535u);
							if (num30 != 0)
							{
								ushort num31 = DataManager.Instance.pLeftLeaderData[0].HeroID;
								if (num31 == 0)
								{
									num31 = DataManager.Instance.RoleAttr.Head;
								}
								GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, (int)num30, (int)num31);
								if (this.controlPanel != null)
								{
									this.controlPanel.gameObject.SetActive(false);
								}
								this.checkPickHero(false);
								this.DramaTriggerFlag = 0u;
								this.bDramaWorking = true;
								this.SubState = 4;
							}
							else
							{
								this.SubState = 5;
							}
						}
						else if (this.SubState == 4)
						{
							if (!this.bDramaWorking)
							{
								this.SubState = 5;
							}
						}
						else if (this.SubState == 5)
						{
							if (this.CageState == 0)
							{
								int arg;
								if (this.m_WarResult == EWarResult.WIN)
								{
									arg = ((this.actionKind != EPlayerActionKind.ATTACKER) ? 2 : 0);
								}
								else
								{
									arg = ((this.actionKind != EPlayerActionKind.ATTACKER) ? 0 : 2);
								}
								this.PlayCheerSound();
								GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 4, arg);
							}
							this.SubState = 6;
						}
					}
				}
			}
		}
		float num32 = smoothDeltaTime;
		if (this.m_WarState == WarManager.WarState.RUNNING)
		{
			if (this.fixMoveDeltaTime + smoothDeltaTime > 1f)
			{
				float num33 = 1f - this.fixMoveDeltaTime;
				num33 = Mathf.Max(0f, num33);
				num32 = num33 + num;
			}
			else
			{
				this.fixMoveDeltaTime += smoothDeltaTime;
				num32 = smoothDeltaTime + num;
			}
			num32 = Mathf.Min(num32, 0.1f);
			if (this.canMoveDeltaTime <= 0f)
			{
				num32 = 0f;
			}
			else if (this.canMoveDeltaTime < num32)
			{
				num32 = this.canMoveDeltaTime;
				this.canMoveDeltaTime = 0f;
			}
			else
			{
				this.canMoveDeltaTime -= num32;
			}
		}
		if (this.castle == null || (this.castle != null && this.castle.State != ArmyGroup.EGROUPSTATE.DESTROYING))
		{
			if (this.m_WarState == WarManager.WarState.CHANGING_SIEGE_MODE)
			{
				int num34 = 0;
				for (int num35 = 0; num35 < (int)this.defenserCount; num35++)
				{
					if (this.defenserArmies[num35].State == ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL || this.defenserArmies[num35].State == ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN)
					{
						if ((this.defenserArmies[num35].CommonFlag & 1u) != 0u)
						{
							num34++;
						}
						this.defenserArmies[num35].Update(smoothDeltaTime, num32);
					}
				}
				if (num34 == 0)
				{
					for (int num36 = 0; num36 < this.attackerArmies.Length; num36++)
					{
						if (this.attackerArmies[num36] != null && this.attackerArmies[num36].HasHeroDisplay)
						{
							this.attackerArmies[num36].setLordAnimEnable(true);
						}
					}
					for (int num37 = 0; num37 < this.defenserArmies.Length; num37++)
					{
						if (this.defenserArmies[num37] != null && this.defenserArmies[num37].HasHeroDisplay)
						{
							this.defenserArmies[num37].setLordAnimEnable(true);
						}
					}
					this.setOutsideHeroAnimEnable(true);
					if (!this.checkResult(true))
					{
						this.m_WarState = WarManager.WarState.RUNNING;
					}
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 3, 0);
					this.deltaTime = 0f;
					if (this.MovingSoundKey != 21)
					{
						this.audioMgr.StopSFX(this.MovingSoundKey, true);
						this.MovingSoundKey = 21;
					}
				}
			}
			else
			{
				for (int num38 = 0; num38 < (int)this.attackerCount; num38++)
				{
					this.attackerArmies[num38].Update(smoothDeltaTime, num32);
				}
				for (int num39 = 0; num39 < (int)this.defenserCount; num39++)
				{
					this.defenserArmies[num39].Update(smoothDeltaTime, num32);
				}
				this.FOMgr.Update(smoothDeltaTime);
				for (int num40 = 0; num40 < this.m_BrokenFO[0].Length; num40++)
				{
					this.m_BrokenFO[0][num40].Update(smoothDeltaTime);
				}
				for (int num41 = 0; num41 < this.m_BrokenFO[1].Length; num41++)
				{
					this.m_BrokenFO[1][num41].Update(smoothDeltaTime);
				}
				if (this.bUpdateOutsideHero)
				{
					for (int num42 = 0; num42 < this.attackerHeroCache.Count; num42++)
					{
						if (this.attackerHeroCache[num42].FSMController != null)
						{
							this.attackerHeroCache[num42].FSMController.Update(this.attackerHeroCache[num42], null, smoothDeltaTime);
						}
					}
					for (int num43 = 0; num43 < this.defenserHeroCache.Count; num43++)
					{
						if (this.defenserHeroCache[num43].FSMController != null)
						{
							this.defenserHeroCache[num43].FSMController.Update(this.defenserHeroCache[num43], null, smoothDeltaTime);
						}
					}
				}
			}
		}
		if (this.castle != null)
		{
			this.castle.Update(smoothDeltaTime, num32);
		}
		if (this.CageState != 0)
		{
			this.CageUpdate(smoothDeltaTime);
		}
		this.WCamera.updateCamera(this.attackerArmies, (int)this.attackerCount, this.defenserArmies, (int)this.defenserCount);
		if (this.HintTrans != null)
		{
			Vector2 vector2 = Camera.main.WorldToScreenPoint(this.PickedTrans.position + new Vector3(0f, 10f, 0f));
			float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
			vector2 /= scaleFactor;
			if (GUIManager.Instance.IsArabic)
			{
				RectTransform canvasRT = GUIManager.Instance.pDVMgr.CanvasRT;
				if (canvasRT != null)
				{
					vector2.x += (canvasRT.sizeDelta.x * 0.5f - vector2.x) * 2f;
				}
			}
			this.HintTrans.anchoredPosition = vector2;
			this.HintTimer += smoothDeltaTime;
			if (this.HintTimer <= 5f)
			{
				if (this.HintHeroNo != 0u)
				{
					ushort heroId = 0;
					bool bLord = false;
					ushort num44 = this.checkArmyGroupHintState(this.HintHeroNo, out heroId, out bLord);
					if (num44 != this.HintStrID)
					{
						this.uiBattle.SetHint(true, bLord, heroId, num44);
						this.HintStrID = num44;
					}
				}
			}
			else
			{
				this.checkPickHero(false);
			}
		}
		this.particleMgr.Update();
	}

	// Token: 0x060023BD RID: 9149 RVA: 0x004160D0 File Offset: 0x004142D0
	private bool checkResult(bool bToFinishing = true)
	{
		if (this.m_WarResult == EWarResult.WIN || this.m_WarResult == EWarResult.LOSE)
		{
			if (bToFinishing || this.m_WarState == WarManager.WarState.RUNNING)
			{
				this.m_WarState = WarManager.WarState.FINISHING;
			}
			FSMManager.Instance.bIsBattleOver = true;
			if (this.m_WarResult == EWarResult.LOSE)
			{
				DataManager.Instance.WarMorale[0] = 0;
				this.UIUpdateFlag |= 1;
			}
			else
			{
				DataManager.Instance.WarMorale[1] = 0;
				this.UIUpdateFlag |= 2;
			}
			return true;
		}
		return false;
	}

	// Token: 0x060023BE RID: 9150 RVA: 0x00416164 File Offset: 0x00414364
	private void decodeSimuPackage(byte[] RecvBufferLeft, byte[] RecvBufferRight)
	{
		this.decodeSimuPackage(RecvBufferLeft, 0);
		this.decodeSimuPackage(RecvBufferRight, 1);
	}

	// Token: 0x060023BF RID: 9151 RVA: 0x00416178 File Offset: 0x00414378
	private void decodeSimuPackage(byte[] RecvBuffer, byte Side)
	{
		byte b = RecvBuffer[0];
		if (b == 0)
		{
			return;
		}
		int num = 1;
		for (int i = 0; i < (int)b; i++)
		{
			byte b2 = RecvBuffer[num];
			num++;
			byte b3 = RecvBuffer[num];
			num++;
			byte b4 = RecvBuffer[num];
			num++;
			ArmyGroup armyGroup = this.getArmyGroup(Side, b2, b3);
			if (armyGroup == null)
			{
				Debug.LogError("null Group");
			}
			else
			{
				switch (b4)
				{
				case 0:
				{
					byte kind = RecvBuffer[num];
					num++;
					byte idx = RecvBuffer[num];
					num++;
					if (b2 == 0 || b2 == 2)
					{
						byte side = (Side != 0) ? 0 : 1;
						ArmyGroup armyGroup2 = this.getArmyGroup(side, kind, idx);
						armyGroup.Attack(armyGroup2, true, 0);
					}
					break;
				}
				case 1:
				{
					byte kind2 = RecvBuffer[num];
					num++;
					byte idx2 = RecvBuffer[num];
					num++;
					float posX = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
					num += 4;
					float posY = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
					num += 4;
					byte side2 = (Side != 0) ? 0 : 1;
					ArmyGroup armyGroup3 = this.getArmyGroup(side2, kind2, idx2);
					armyGroup.setPosition(posX, posY);
					armyGroup.Move(armyGroup3);
					if (b2 != 4)
					{
						this.setSkillWorkingList(Side, b2, b3, false);
					}
					if (b2 == 0 || b2 == 2)
					{
						if (this.MovingSoundKey >= 21)
						{
							if (this.AttackSoundKey != 21)
							{
								byte b5 = 0;
								for (int j = 0; j < 4; j++)
								{
									ArmyGroup armyGroup4 = this.getArmyGroup(0, 0, (byte)j);
									if (armyGroup4 != null && armyGroup4.CurHP > 0 && (armyGroup4.State == ArmyGroup.EGROUPSTATE.FIGHT || armyGroup4.State == ArmyGroup.EGROUPSTATE.FIGHT_IMMEDIATE))
									{
										b5 += 1;
									}
									armyGroup4 = this.getArmyGroup(0, 2, (byte)j);
									if (armyGroup4 != null && armyGroup4.CurHP > 0 && (armyGroup4.State == ArmyGroup.EGROUPSTATE.FIGHT || armyGroup4.State == ArmyGroup.EGROUPSTATE.FIGHT_IMMEDIATE))
									{
										b5 += 1;
									}
									armyGroup4 = this.getArmyGroup(1, 0, (byte)j);
									if (armyGroup4 != null && armyGroup4.CurHP > 0 && (armyGroup4.State == ArmyGroup.EGROUPSTATE.FIGHT || armyGroup4.State == ArmyGroup.EGROUPSTATE.FIGHT_IMMEDIATE))
									{
										b5 += 1;
									}
									armyGroup4 = this.getArmyGroup(1, 2, (byte)j);
									if (armyGroup4 != null && armyGroup4.CurHP > 0 && (armyGroup4.State == ArmyGroup.EGROUPSTATE.FIGHT || armyGroup4.State == ArmyGroup.EGROUPSTATE.FIGHT_IMMEDIATE))
									{
										b5 += 1;
									}
								}
								if (b5 > 0)
								{
									break;
								}
								this.audioMgr.StopSFX(this.AttackSoundKey, true);
								this.AttackSoundKey = 21;
							}
							float num2 = GameConstants.DistanceSquare(this.mainCamera.position, armyGroup.groupRoot.position);
							float? num3 = this.movingDist_Sound;
							if (num3 == null || num2 < this.movingDist_Sound.Value)
							{
								this.movingDist_Sound = new float?(num2);
								this.movingSoundParent = armyGroup;
								this.SoundDirtyFlag |= 1u;
							}
						}
					}
					break;
				}
				case 2:
				{
					byte kind3 = RecvBuffer[num];
					num++;
					byte idx3 = RecvBuffer[num];
					num++;
					int num4 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
					num += 2;
					byte side3 = (Side != 0) ? 0 : 1;
					ArmyGroup armyGroup5 = this.getArmyGroup(side3, kind3, idx3);
					if (b2 == 4)
					{
						armyGroup.Attack(armyGroup5, false, b3);
					}
					else
					{
						byte b6 = 0;
						if (num4 > 7)
						{
							armyGroup.PlaySkill((ushort)num4, armyGroup5);
							b6 = 1;
						}
						else
						{
							armyGroup.Attack(armyGroup5, false, b6);
						}
						if (b6 == 1)
						{
							if (b2 == 3)
							{
								int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
								int curLightmapIdx = 1 + sceneLightmapSize;
								armyGroup.resetLightmap(curLightmapIdx);
							}
							else if (b2 != 4)
							{
								this.setSkillWorkingList(Side, b2, b3, true);
							}
						}
						if (b2 == 0 || b2 == 2)
						{
							if (this.AttackSoundKey >= 21)
							{
								if (this.MovingSoundKey < 21)
								{
									this.audioMgr.StopSFX(this.MovingSoundKey, true);
									this.MovingSoundKey = 21;
								}
								float num5 = GameConstants.DistanceSquare(this.mainCamera.position, armyGroup.groupRoot.position);
								float? num6 = this.attackDist_Sound;
								if (num6 == null || num5 < this.attackDist_Sound.Value)
								{
									this.attackDist_Sound = new float?(num5);
									this.attackSoundParent = armyGroup;
									this.SoundDirtyFlag |= 2u;
								}
							}
						}
					}
					break;
				}
				case 3:
				{
					byte b7 = RecvBuffer[num];
					num++;
					byte b8 = RecvBuffer[num];
					num++;
					int num7 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
					num += 2;
					int num8 = GameConstants.ConvertBytesToInt(RecvBuffer, num);
					num += 4;
					byte b9 = RecvBuffer[num];
					num++;
					armyGroup.GotHurt = num8;
					if (b2 != 4)
					{
						this.CaleWarMorale(Side, (uint)num8);
					}
					if (b7 == 3)
					{
						byte side4 = (Side != 0) ? 0 : 1;
						ArmyGroup armyGroup6 = this.getArmyGroup(side4, b7, b8);
						byte idx4 = this.brokenFO_Index[(int)(armyGroup6.Tier - 1)];
						if (b2 == 4)
						{
							if (armyGroup6.soldiers[0].hitParticleCount > 0)
							{
								this.playBrokenFO(idx4, armyGroup6.soldiers[0].hitParticlePos[0], Vector3.left);
								this.particleMgr.Spawn(2005, null, armyGroup6.soldiers[0].hitParticlePos[0], 1f, true, false);
								if (armyGroup6.soldiers[0].hitParticleCount == 2)
								{
									armyGroup6.soldiers[0].hitParticlePos[0] = armyGroup6.soldiers[0].hitParticlePos[1];
								}
								Soldier soldier = armyGroup6.soldiers[0];
								soldier.hitParticleCount -= 1;
							}
						}
						else if (armyGroup.soldiers != null)
						{
							Vector3 hitPoint = armyGroup.soldiers[0].hitPoint;
							this.playBrokenFO(idx4, hitPoint, armyGroup.soldiers[0].transform.rotation);
							this.particleMgr.Spawn(2005, null, hitPoint, 1f, true, false);
						}
						float num9 = GameConstants.DistanceSquare(this.mainCamera.position, armyGroup.groupRoot.position);
						float? num10 = this.stoneHitDist_Sound;
						if (num10 == null || num9 < this.stoneHitDist_Sound.Value)
						{
							this.stoneHitDist_Sound = new float?(num9);
							this.stoneHitSoundParent = armyGroup;
							this.SoundDirtyFlag |= 8u;
						}
					}
					else if (b7 == 1)
					{
						byte side5 = (Side != 0) ? 0 : 1;
						ArmyGroup armyGroup7 = this.getArmyGroup(side5, b7, b8);
						int num11 = UnityEngine.Random.Range(1, armyGroup7.CurrentSoldierCount);
						num11 = ((num11 <= 5) ? num11 : 5);
						ushort num12 = 2001;
						if (armyGroup7.GroupKind == EGroupKind.Catapults)
						{
							num12 = 2005;
						}
						if (armyGroup7.GroupKind == EGroupKind.Archer && armyGroup7.Tier == 4)
						{
							num12 = 2006;
						}
						if (b2 == 4)
						{
							for (int k = 0; k < num11; k++)
							{
								if (armyGroup7.soldiers[k].hitParticleCount > 0)
								{
									this.particleMgr.Spawn(num12, null, armyGroup7.soldiers[k].hitParticlePos[0], 1f, true, false);
									if (armyGroup7.soldiers[k].hitParticleCount == 2)
									{
										armyGroup7.soldiers[k].hitParticlePos[0] = armyGroup7.soldiers[k].hitParticlePos[1];
									}
									Soldier soldier2 = armyGroup7.soldiers[k];
									soldier2.hitParticleCount -= 1;
								}
							}
						}
						else if (armyGroup7.soldiers != null)
						{
							for (int l = 0; l < num11; l++)
							{
								if (armyGroup7.soldiers[l].Target != null)
								{
									armyGroup7.soldiers[l].Target.ParticleFlag = ((num12 <= armyGroup7.soldiers[l].Target.ParticleFlag) ? armyGroup7.soldiers[l].Target.ParticleFlag : num12);
								}
							}
						}
					}
					else if (b7 == 4)
					{
						if (b8 == 5)
						{
							this.castle.cacheTrapHitPos(0, armyGroup);
						}
						else if (b8 == 6)
						{
							this.castle.cacheTrapHitPos(1, armyGroup);
						}
						else
						{
							int currentSoldierCount = armyGroup.CurrentSoldierCount;
							for (int m = 0; m < 5; m++)
							{
								if (m < armyGroup.CurrentSoldierCount)
								{
									armyGroup.soldiers[m].ParticleFlag = 1;
								}
							}
						}
					}
					if (num7 > 7)
					{
						Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey((ushort)num7);
						if ((int)recordByKey.SkillKey == num7 && recordByKey.HitParticle != 0)
						{
							if (b2 != 4)
							{
								Vector3 vector = (armyGroup.soldiers == null) ? armyGroup.heroSoldier.transform.position : armyGroup.soldiers[0].transform.position;
								for (int n = 1; n < armyGroup.CurrentSoldierCount; n++)
								{
									vector += armyGroup.soldiers[n].transform.position;
								}
								if (armyGroup.CurrentSoldierCount != 0)
								{
									vector /= (float)armyGroup.CurrentSoldierCount;
								}
								GameObject gameObject = this.particleMgr.Spawn(recordByKey.HitParticle, null, vector, 1f, true, false);
								if (Side == 0 && gameObject != null)
								{
									gameObject.transform.Rotate(0f, 180f, 0f);
								}
							}
							else
							{
								Vector3 position = armyGroup.groupRoot.position;
								position.x = 50f;
								this.particleMgr.Spawn(recordByKey.HitParticle, null, position, 1f, true, false);
							}
						}
						armyGroup.OnceFlag |= 2u;
						byte side6 = (Side != 0) ? 0 : 1;
						ArmyGroup armyGroup8 = this.getArmyGroup(side6, b7, b8);
						armyGroup.AttackBy = armyGroup8;
						if ((this.actionKind == EPlayerActionKind.ATTACKER && Side == 1) || (this.actionKind == EPlayerActionKind.DEFENDER && Side == 0))
						{
							this.WCamera.Shake = true;
						}
					}
					if (b2 != 4)
					{
						long num13 = DataManager.Instance.NowValue_War[(int)Side] - (long)num8;
						DataManager.Instance.NowValue_War[(int)Side] = ((num13 >= 0L) ? num13 : 0L);
						this.UIUpdateFlag |= ((Side != 0) ? 2 : 1);
						byte[,] array = (Side != 0) ? this.defenserArmiesMap : this.attackerArmiesMap;
						byte side7 = 0;
						if ((Side == 0 && !DataManager.Instance.bWarAttacker) || (Side == 1 && DataManager.Instance.bWarAttacker))
						{
							side7 = 1;
						}
						if (WarManager.WarKind == WarManager.EWarKind.Normal)
						{
							GUIManager.Instance.pDVMgr.OpenBloodShow((int)side7, (int)(array[(int)b2, (int)b3] - 1));
						}
					}
					else if (b3 == 0)
					{
						long num14 = DataManager.Instance.NowValue_War[2] - (long)num8;
						DataManager.Instance.NowValue_War[2] = ((num14 >= 0L) ? num14 : 0L);
						this.UIUpdateFlag |= 4;
						byte side8 = 0;
						if (DataManager.Instance.bWarAttacker)
						{
							side8 = 1;
						}
						if (WarManager.WarKind == WarManager.EWarKind.Normal)
						{
							GUIManager.Instance.pDVMgr.OpenBloodShow((int)side8, 16);
						}
					}
					if (b7 != 1 && b7 != 3 && b7 != 4)
					{
						this.setSkillWorkingList(1 - Side, b7, b8, false);
					}
					break;
				}
				case 4:
					armyGroup.AllDie((int)b3);
					if (armyGroup.GroupKind == EGroupKind.CastleGate && b3 == 0)
					{
						this.playCollapse();
					}
					if (b2 != 4)
					{
						this.setSkillWorkingList(Side, b2, b3, false);
						if (Side == 0)
						{
							this.attackerAliveCount -= 1;
						}
						else
						{
							this.defenserAliveCount -= 1;
						}
						if (this.uiBattle != null)
						{
							if (armyGroup.heroSoldierID != 0)
							{
								this.uiBattle.AddHudMsg((int)Side, 0, armyGroup.heroSoldierID);
							}
							else
							{
								int num15 = (int)(b2 * 4 + 1 + (armyGroup.Tier - 1));
								this.uiBattle.AddHudMsg((int)Side, 1, (ushort)num15);
							}
						}
					}
					else if (this.uiBattle != null && b3 != 0 && this.castleWeaponInfo[(int)(b3 - 1)] > 0)
					{
						int num16 = (int)(this.castleWeaponInfo[(int)(b3 - 1)] - 1);
						int num17 = 21;
						num17 = ((b3 != 5) ? num17 : 25);
						num17 = ((b3 != 6) ? num17 : 17);
						num17 += num16;
						this.uiBattle.AddHudMsg(1, 2, (ushort)num17);
					}
					if (armyGroup.GroupKind != EGroupKind.CastleGate && armyGroup.GroupKind != EGroupKind.Catapults)
					{
						if (Side == 0)
						{
							this.nonCatapultsCount_Left--;
						}
						else
						{
							this.nonCatapultsCount_Right--;
						}
						if (this.nonCatapultsCount_Left + this.nonCatapultsCount_Right == 0)
						{
							this.WCamera.bIgnoreCatapults = false;
						}
					}
					if (!armyGroup.HasLord && armyGroup.heroSoldier != null && this.PickedTrans != null && armyGroup.heroSoldier.gameObject == this.PickedTrans.gameObject)
					{
						this.checkPickHero(false);
					}
					break;
				case 5:
				{
					byte kind4 = RecvBuffer[num];
					num++;
					byte idx5 = RecvBuffer[num];
					num++;
					int num18 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
					num += 2;
					int num19 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
					num += 2;
					byte side9 = (Side != 0) ? 0 : 1;
					ArmyGroup armyGroup9 = this.getArmyGroup(side9, kind4, idx5);
					if (b2 == 4)
					{
						armyGroup.Target = armyGroup9;
					}
					FOKind kind5;
					if (b2 == 4)
					{
						kind5 = FOKind.TowerArrow;
					}
					else if (b2 == 3)
					{
						if (armyGroup.Tier == 1)
						{
							kind5 = FOKind.CLv1_Arrow;
						}
						else if (armyGroup.Tier == 4 || armyGroup.Tier == 3)
						{
							kind5 = FOKind.FireStone;
						}
						else
						{
							kind5 = FOKind.Stone;
						}
					}
					else
					{
						kind5 = ((armyGroup.Tier != 4) ? FOKind.Arrow : FOKind.Bomb);
					}
					armyGroup.FireRange(armyGroup9, this.FOMgr, kind5, (float)num19 * 0.001f, (ushort)num18, b3);
					if (b2 == 1)
					{
						this.setSkillWorkingList(Side, b2, b3, false);
						float num20 = GameConstants.DistanceSquare(this.mainCamera.position, armyGroup.groupRoot.position);
						float? num21 = this.rangeDist_Sound;
						if (num21 == null || num20 < this.rangeDist_Sound.Value)
						{
							this.rangeDist_Sound = new float?(num20);
							this.rangeSoundParent = armyGroup;
							this.SoundDirtyFlag |= 4u;
						}
					}
					break;
				}
				case 6:
				{
					int num22 = (int)RecvBuffer[num];
					num++;
					if (this.m_WarResult == EWarResult.NONE)
					{
						if (num22 != 1)
						{
							this.changeSiegeMode(num22);
						}
					}
					break;
				}
				case 7:
				{
					int num23 = GameConstants.ConvertBytesToInt(RecvBuffer, num);
					num += 4;
					this.TrapsHp += (uint)num23;
					if ((ulong)this.LastTrapsHp >= (ulong)((long)num23))
					{
						this.LastTrapsHp -= (uint)num23;
					}
					else
					{
						this.LastTrapsHp = 0u;
					}
					DataManager.Instance.NowValue_War[1] -= (long)num23;
					DataManager.Instance.NowValue_War[1] = Math.Max(0L, DataManager.Instance.NowValue_War[1]);
					DataManager.Instance.CastleTrapsDestroyedCount -= (long)num23;
					DataManager.Instance.CastleTrapsDestroyedCount = Math.Max(0L, DataManager.Instance.CastleTrapsDestroyedCount);
					this.UIUpdateFlag |= 2;
					break;
				}
				}
			}
		}
	}

	// Token: 0x060023C0 RID: 9152 RVA: 0x004171EC File Offset: 0x004153EC
	private void changeSiegeMode(int newMode)
	{
		int num = 0;
		if (newMode >= 3 && this.SiegeMode < 3)
		{
			for (int i = 0; i < 4; i++)
			{
				ArmyGroup armyGroup = this.getArmyGroup(1, 0, (byte)i);
				if (armyGroup != null)
				{
					armyGroup.setPosition(WarManager.ActionPositionRight[0, i, 0], WarManager.ActionPositionRight[0, i, 1]);
					armyGroup.SoldierFlagCount = 0;
					armyGroup.CommonFlag |= 1u;
					armyGroup.State = ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN;
					num++;
				}
				armyGroup = this.getArmyGroup(1, 2, (byte)i);
				if (armyGroup != null)
				{
					armyGroup.setPosition(WarManager.ActionPositionRight[2, i, 0], WarManager.ActionPositionRight[2, i, 1]);
					armyGroup.SoldierFlagCount = 0;
					armyGroup.CommonFlag |= 1u;
					armyGroup.State = ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN;
					num++;
				}
			}
		}
		if (newMode == 4)
		{
			for (int j = 0; j < 4; j++)
			{
				ArmyGroup armyGroup2 = this.getArmyGroup(1, 1, (byte)j);
				if (armyGroup2 != null)
				{
					armyGroup2.setPosition(WarManager.ActionPositionRight[1, j, 0], WarManager.ActionPositionRight[1, j, 1]);
					armyGroup2.SoldierFlagCount = 0;
					armyGroup2.CommonFlag |= 1u;
					armyGroup2.State = ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL;
					num++;
				}
			}
		}
		for (int k = 0; k < this.attackerArmies.Length; k++)
		{
			if (this.attackerArmies[k] != null && this.attackerArmies[k].HasHeroDisplay && this.attackerArmies[k].State != ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL && this.attackerArmies[k].State != ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN)
			{
				this.attackerArmies[k].setLordAnimEnable(false);
			}
		}
		for (int l = 0; l < this.defenserArmies.Length; l++)
		{
			if (this.defenserArmies[l] != null && this.defenserArmies[l].HasHeroDisplay && this.defenserArmies[l].State != ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL && this.defenserArmies[l].State != ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN)
			{
				this.defenserArmies[l].setLordAnimEnable(false);
			}
		}
		this.setOutsideHeroAnimEnable(false);
		if (num != 0)
		{
			if (newMode == 3)
			{
				this.uiBattle.AddCenterMsg(500, (this.actionKind != EPlayerActionKind.ATTACKER) ? 0 : 1);
			}
			else if (newMode == 4)
			{
				this.uiBattle.AddCenterMsg(501, (this.actionKind != EPlayerActionKind.ATTACKER) ? 0 : 1);
			}
		}
		if (this.AttackSoundKey != 21)
		{
			this.audioMgr.StopSFX(this.AttackSoundKey, true);
			this.AttackSoundKey = 21;
		}
		if (this.MovingSoundKey != 21)
		{
			this.audioMgr.StopSFX(this.MovingSoundKey, true);
			this.MovingSoundKey = 21;
		}
		if (newMode == 3)
		{
			this.SoundDirtyFlag |= 1u;
		}
		this.SiegeMode = newMode;
		this.m_WarState = WarManager.WarState.CHANGING_SIEGE_MODE;
	}

	// Token: 0x060023C1 RID: 9153 RVA: 0x004174F4 File Offset: 0x004156F4
	private void setSkillWorkingList(byte side, byte kind, byte idx, bool bWorking)
	{
		ArmyGroup[] array = (side != 0) ? this.defenserArmies : this.attackerArmies;
		byte[,] array2 = (side != 0) ? this.defenserArmiesMap : this.attackerArmiesMap;
		int num = (int)(array2[(int)kind, (int)idx] - 1);
		num = ((side != 0) ? (num + 32) : num);
		if (!bWorking)
		{
			if ((this.m_SkillWorkingList >> num & 1UL) != 0UL)
			{
				this.m_SkillWorkingList ^= 1UL << num;
			}
		}
		else
		{
			this.m_SkillWorkingList |= 1UL << num;
		}
		this.m_bSkillDirty = true;
	}

	// Token: 0x060023C2 RID: 9154 RVA: 0x004175A4 File Offset: 0x004157A4
	private void CaleWarMorale(byte side, uint val)
	{
		DataManager instance = DataManager.Instance;
		if (instance.WarMoraleValue[(int)side] != 0UL)
		{
			instance.WarLoseCount[(int)side] += (ulong)val;
			double num = Convert.ToDouble(instance.WarLoseCount[(int)side]);
			double num2 = Convert.ToDouble(instance.WarMoraleValue[(int)side]);
			float num3 = (float)(num / num2);
			instance.WarMorale[(int)side] = Mathf.Clamp(Mathf.CeilToInt(100f - num3 * 100f), 0, 100);
			if (side == 1 && this.defenserAliveCount == 0)
			{
				instance.WarMorale[1] = 0;
			}
			if (instance.WarMorale[(int)side] == 0 && this.m_WarResult != ((side != 0) ? EWarResult.WIN : EWarResult.LOSE))
			{
				instance.WarMorale[(int)side] = 1;
			}
			this.UIUpdateFlag |= ((side != 0) ? 2 : 1);
		}
	}

	// Token: 0x060023C3 RID: 9155 RVA: 0x0041767C File Offset: 0x0041587C
	private ArmyGroup getArmyGroup(byte Side, byte Kind, byte Idx)
	{
		if (Side == 1 && Kind == 4)
		{
			return this.castle;
		}
		ArmyGroup[] array = (Side != 0) ? this.defenserArmies : this.attackerArmies;
		byte[,] array2 = (Side != 0) ? this.defenserArmiesMap : this.attackerArmiesMap;
		return (array2[(int)Kind, (int)Idx] == 0) ? null : array[(int)(array2[(int)Kind, (int)Idx] - 1)];
	}

	// Token: 0x060023C4 RID: 9156 RVA: 0x004176F0 File Offset: 0x004158F0
	private ushort loadWarInfo(bool bResetCoord = false)
	{
		DataManager instance = DataManager.Instance;
		UnityEngine.Random.seed = (int)instance.War_RndSeed;
		if (instance.War_LeftHeroNum != 0 && instance.War_LeftLordID != 0)
		{
			this.attackerLordID = instance.War_LeftLordID;
		}
		else
		{
			this.attackerLordID = 0;
		}
		if (instance.War_RightHeroNum != 0 && instance.War_RightLordID != 0)
		{
			this.defenserLordID = instance.War_RightLordID;
		}
		else
		{
			this.defenserLordID = 0;
		}
		this.BSUtil.setCombatInfo(instance.War_LeftCastleLv, instance.pLeftLeaderData, instance.War_LeftHeroNum, instance.pLeftTroopForce, instance.War_RightCastleLv, instance.pRightLeaderData, instance.War_RightHeroNum, instance.pRightTroopForce);
		this.BSUtil.setTroopAttrData(instance.War_LeftAttackAttr, instance.War_LeftDefenseAttr, instance.War_LeftHealthAttr, instance.War_RightAttackAttr, instance.War_RightDefenseAttr, instance.War_RightHealthAttr);
		if (instance.bSiege != 0)
		{
			int num = Mathf.CeilToInt((float)instance.War_WallLevel / 8f);
			num = Mathf.Clamp(num, 1, 4);
			this.m_GateTier = (byte)num;
			if (this.BSUtil.setWallTrapInfo(instance.CurWallHp, instance.MaxWallHp, instance.pCastleInfo))
			{
				FSMManager.Instance.bIsSiegeMode = true;
			}
			DataManager.Instance.MaxValue_War[2] = (long)((ulong)(instance.MaxWallHp * 100u));
			DataManager.Instance.NowValue_War[2] = (long)((ulong)(instance.CurWallHp * 100u));
			this.BSUtil.setTrapAttrData(ref instance.War_WallAttr);
		}
		else
		{
			FSMManager.Instance.bIsSiegeMode = false;
			instance.MaxWallHp = 0u;
			instance.CurWallHp = 0u;
			DataManager.Instance.MaxValue_War[2] = 0L;
			DataManager.Instance.NowValue_War[2] = 0L;
		}
		if (!bResetCoord)
		{
			if (this.attackerHeroIdCache.Count <= 0 && this.defenserHeroIdCache.Count <= 0)
			{
				for (int i = 0; i < 5; i++)
				{
					int num2 = 1 << i;
					if (instance.pLeftLeaderData[i].HeroID != 0)
					{
						this.attackerHeroIdCache.Add(instance.pLeftLeaderData[i].HeroID);
					}
					if (instance.pRightLeaderData[i].HeroID != 0)
					{
						this.defenserHeroIdCache.Add(instance.pRightLeaderData[i].HeroID);
					}
				}
			}
			this.RecvBufferLeft[0] = 0;
			this.RecvBufferRight[0] = 0;
			this.SiegeMode = this.BSUtil.setTroopOver(this.RecvBufferLeft, this.RecvBufferRight);
			this.decodeTroopOverData(this.SiegeMode, this.RecvBufferLeft, this.RecvBufferRight, false);
		}
		else
		{
			GUIManager.Instance.pDVMgr.EndWarClear();
			this.RecvBufferLeft[0] = 0;
			this.RecvBufferRight[0] = 0;
			this.SiegeMode = this.BSUtil.setTroopOver(this.RecvBufferLeft, this.RecvBufferRight);
			this.decodeTroopOverData(this.SiegeMode, this.RecvBufferLeft, this.RecvBufferRight, true);
			if (WarManager.WarCoordIndex_Right != WarManager.TroopKindSimuIndex_Right)
			{
				for (int j = 0; j < (int)this.defenserCount; j++)
				{
					this.enemySideArmies[j] = this.defenserArmies[j];
				}
				this.enemySideArmies[16] = this.castle;
			}
			GUIManager.Instance.pDVMgr.BeginWarInitial();
			GUIManager.Instance.pDVMgr.SetBloodBarFillAmount(1, 16, 0f);
			Resources.UnloadUnusedAssets();
		}
		Array.Clear(instance.WarLoseCount, 0, 2);
		instance.WarMorale[0] = 100;
		instance.WarMorale[1] = 100;
		return 1;
	}

	// Token: 0x060023C5 RID: 9157 RVA: 0x00417A8C File Offset: 0x00415C8C
	private void decodeTroopOverData(int mode, byte[] RecvBufferLeft, byte[] RecvBufferRight, bool bCoordModeReset = false)
	{
		int num = (int)((RecvBufferLeft[0] <= RecvBufferRight[0]) ? RecvBufferRight[0] : RecvBufferLeft[0]);
		int num2 = 1;
		byte b = 0;
		int num3 = 1;
		byte b2 = 0;
		float[,,] array = (this.SiegeMode > 1) ? WarManager.InitPositionLeft_SiegeMode : WarManager.InitPositionLeft;
		float[,,] array2 = (this.SiegeMode > 1) ? WarManager.InitPositionRight_SiegeMode : WarManager.InitPositionRight;
		long num4 = 0L;
		long num5 = 0L;
		byte b3 = (byte)Mathf.Abs((int)(EPlayerActionKind.DEFENDER - this.actionKind));
		ushort[] array3 = new ushort[8];
		this.TrapsHp = 0u;
		this.LastTrapsHp = 0u;
		this.MoraleStep = 0;
		bool flag = false;
		DataManager instance = DataManager.Instance;
		instance.CastleTrapsDestroyedCount = 0L;
		for (int i = 0; i < num; i++)
		{
			if (i < (int)RecvBufferLeft[0])
			{
				byte b4 = RecvBufferLeft[num2];
				num2++;
				byte b5 = RecvBufferLeft[num2];
				num2++;
				byte b6 = RecvBufferLeft[num2];
				num2++;
				int num6 = GameConstants.ConvertBytesToInt(RecvBufferLeft, num2);
				num2 += 4;
				ushort num7 = GameConstants.ConvertBytesToUShort(RecvBufferLeft, num2);
				num2 += 2;
				if (this.attackerArmies[(int)b] == null)
				{
					ushort num8 = num7;
					bool hasLord = num8 != 0 && num8 == this.attackerLordID;
					this.attackerArmies[(int)b] = new ArmyGroup((EGroupKind)(b4 + 1), b6, this.renderRoot, 0, (byte)this.actionKind, num8, b, hasLord, 1f);
					if (num8 != 0)
					{
						if (num8 == this.attackerLordID)
						{
							this.attackerLord = this.attackerArmies[(int)b];
							this.attackerLord.HasLord = true;
							this.attackerLordUnit = this.attackerLord.heroSoldier;
						}
						Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(num8);
						if (recordByKey.GroupSkill1 != 0)
						{
							Skill recordByKey2 = DataManager.Instance.SkillTable.GetRecordByKey(recordByKey.GroupSkill1);
							if (recordByKey2.FlyParticle != 0 && b4 != 3)
							{
								ushort[] array4 = array3;
								ushort num9 = recordByKey2.FlyParticle - 1;
								array4[(int)num9] = array4[(int)num9] + 2;
								this.attackerArmies[(int)b].heroSoldierFO = recordByKey2.FlyParticle;
							}
							if (recordByKey2.FlySound != 0)
							{
								ushort[] array5 = array3;
								int num10 = 7;
								array5[num10] += 2;
								this.attackerArmies[(int)b].heroSoldierSkillFO = recordByKey2.FlySound;
							}
						}
						this.attackerHeroIdCache.Remove(num8);
					}
					this.attackerArmies[(int)b].particleManager = this.particleMgr;
					this.attackerArmies[(int)b].Index = b5;
					this.attackerArmies[(int)b].heroSoldierID = num7;
					this.attackerArmiesMap[(int)b4, (int)b5] = b + 1;
				}
				else if (!bCoordModeReset)
				{
					this.attackerArmies[(int)b].Reset();
				}
				if (!bCoordModeReset)
				{
					float x = array[(int)b4, (int)b5, 0];
					float z = array[(int)b4, (int)b5, 1];
					this.attackerArmies[(int)b].setPosition(new Vector3(x, 0f, z), new Vector3(10000f, 0f, z), 0);
				}
				this.attackerArmies[(int)b].MaxHP = num6;
				num4 += (long)num6;
				b += 1;
				if (b4 == 1)
				{
					if (b6 != 4)
					{
						ushort[] array6 = array3;
						int num11 = 1;
						array6[num11] += 9;
					}
					else
					{
						ushort[] array7 = array3;
						int num12 = 2;
						array7[num12] += 9;
					}
				}
				else if (b4 == 3)
				{
					if (b6 == 1)
					{
						ushort[] array8 = array3;
						int num13 = 6;
						array8[num13] += 2;
					}
					else if (b6 == 2)
					{
						ushort[] array9 = array3;
						int num14 = 0;
						array9[num14] += 1;
					}
					else
					{
						ushort[] array10 = array3;
						int num15 = 3;
						array10[num15] += 1;
					}
				}
				if (b4 >= 0 && b4 < 3)
				{
					this.nonCatapultsCount_Left++;
				}
			}
			if (i < (int)RecvBufferRight[0])
			{
				byte b7 = RecvBufferRight[num3];
				num3++;
				byte b8 = RecvBufferRight[num3];
				num3++;
				byte b9 = RecvBufferRight[num3];
				num3++;
				int num16 = GameConstants.ConvertBytesToInt(RecvBufferRight, num3);
				num3 += 4;
				ushort num17 = GameConstants.ConvertBytesToUShort(RecvBufferRight, num3);
				num3 += 2;
				if (b7 == 4)
				{
					if (b8 > 0 && b8 <= 6)
					{
						this.castleWeaponInfo[(int)(b8 - 1)] = b9;
						if (b8 <= 4)
						{
							ushort[] array11 = array3;
							int num18 = 5;
							array11[num18] += 5;
						}
						num5 += (long)num16;
						this.LastTrapsHp += (uint)num16;
						instance.CastleTrapsDestroyedCount += (long)num16;
					}
				}
				else
				{
					if (this.defenserArmies[(int)b2] == null)
					{
						ushort num19 = num17;
						bool hasLord2 = num19 != 0 && num19 == this.defenserLordID;
						this.defenserArmies[(int)b2] = new ArmyGroup((EGroupKind)(b7 + 1), b9, this.renderRoot, 1, b3, num19, b2, hasLord2, 1f);
						if (num19 != 0)
						{
							if (num19 == this.defenserLordID)
							{
								this.defenserLord = this.defenserArmies[(int)b2];
								this.defenserLord.HasLord = true;
								this.defenserLordUnit = this.defenserLord.heroSoldier;
							}
							Hero recordByKey3 = DataManager.Instance.HeroTable.GetRecordByKey(num19);
							if (recordByKey3.GroupSkill1 != 0)
							{
								Skill recordByKey4 = DataManager.Instance.SkillTable.GetRecordByKey(recordByKey3.GroupSkill1);
								if (recordByKey4.FlyParticle != 0 && b7 != 3)
								{
									ushort[] array12 = array3;
									ushort num20 = recordByKey4.FlyParticle - 1;
									array12[(int)num20] = array12[(int)num20] + 2;
									this.defenserArmies[(int)b2].heroSoldierFO = recordByKey4.FlyParticle;
								}
								if (recordByKey4.FlySound != 0)
								{
									ushort[] array13 = array3;
									int num21 = 7;
									array13[num21] += 2;
									this.defenserArmies[(int)b2].heroSoldierSkillFO = recordByKey4.FlySound;
								}
							}
							this.defenserHeroIdCache.Remove(num19);
						}
						this.defenserArmies[(int)b2].particleManager = this.particleMgr;
						this.defenserArmies[(int)b2].Index = b8;
						this.defenserArmies[(int)b2].heroSoldierID = num17;
						this.defenserArmiesMap[(int)b7, (int)b8] = b2 + 1;
						flag = true;
					}
					else
					{
						if (!bCoordModeReset)
						{
							this.defenserArmies[(int)b2].Reset();
						}
						if (this.SiegeMode > 1)
						{
							this.defenserArmies[(int)b2].bAttackMode = false;
						}
					}
					if (!bCoordModeReset)
					{
						if (this.SiegeMode > 1 && b7 == 1)
						{
							Vector3 pos = this.ArcherPosOnTower[(int)b8];
							this.defenserArmies[(int)b2].setPosition(pos, new Vector3(-10000f, pos.y, pos.z), 1);
						}
						else
						{
							float x2 = array2[(int)b7, (int)b8, 0];
							float z2 = array2[(int)b7, (int)b8, 1];
							this.defenserArmies[(int)b2].setPosition(new Vector3(x2, 0f, z2), new Vector3(-10000f, 0f, z2), 0);
						}
					}
					if (this.SiegeMode > 1 && this.defenserArmies[(int)b2].heroSoldier != null && this.defenserArmies[(int)b2].heroSoldierID == this.defenserLordID)
					{
						this.defenserArmies[(int)b2].SiegeModeDefenserLordInit();
					}
					this.defenserArmies[(int)b2].MaxHP = num16;
					num5 += (long)num16;
					b2 += 1;
					if (b7 == 1)
					{
						if (b9 != 4)
						{
							ushort[] array14 = array3;
							int num22 = 1;
							array14[num22] += 9;
						}
						else
						{
							ushort[] array15 = array3;
							int num23 = 2;
							array15[num23] += 9;
						}
					}
					else if (b7 == 3)
					{
						if (b9 == 1)
						{
							ushort[] array16 = array3;
							int num24 = 6;
							array16[num24] += 2;
						}
						else if (b9 == 2)
						{
							ushort[] array17 = array3;
							int num25 = 0;
							array17[num25] += 1;
						}
						else
						{
							ushort[] array18 = array3;
							int num26 = 3;
							array18[num26] += 1;
						}
					}
					if (b7 >= 0 && b7 < 3)
					{
						this.nonCatapultsCount_Right++;
					}
				}
			}
		}
		this.WCamera.bIgnoreCatapults = true;
		if (this.nonCatapultsCount_Right + this.nonCatapultsCount_Left == 0)
		{
			this.WCamera.bIgnoreCatapults = false;
		}
		if (!bCoordModeReset)
		{
			if (b == 0)
			{
				for (int j = 0; j < 2; j++)
				{
					if (this.attackerArmies[(int)b] == null)
					{
						this.attackerArmies[(int)b] = new ArmyGroup(EGroupKind.Infantry, 1, this.renderRoot, 0, (byte)this.actionKind, 0, b, false, 1f);
						this.attackerArmies[(int)b].particleManager = this.particleMgr;
						this.attackerArmies[(int)b].Index = (byte)j;
						this.attackerArmies[(int)b].heroSoldierID = 0;
						this.attackerArmiesMap[0, j] = b + 1;
					}
					else
					{
						this.attackerArmies[(int)b].Reset();
					}
					float x3 = array[0, j, 0];
					float z3 = array[0, j, 1];
					this.attackerArmies[(int)b].setPosition(new Vector3(x3, 0f, z3), new Vector3(10000f, 0f, z3), 0);
					this.attackerArmies[(int)b].MaxHP = 100;
					b += 1;
				}
			}
			else if (this.SiegeMode == 1 && b2 == 0)
			{
				for (int k = 0; k < 2; k++)
				{
					if (this.defenserArmies[(int)b2] == null)
					{
						this.defenserArmies[(int)b2] = new ArmyGroup(EGroupKind.Infantry, 1, this.renderRoot, 1, b3, 0, b2, false, 1f);
						this.defenserArmies[(int)b2].particleManager = this.particleMgr;
						this.defenserArmies[(int)b2].Index = (byte)k;
						this.defenserArmies[(int)b2].heroSoldierID = 0;
						this.defenserArmiesMap[0, k] = b2 + 1;
					}
					else
					{
						this.defenserArmies[(int)b2].Reset();
					}
					float x4 = array2[0, k, 0];
					float z4 = array2[0, k, 1];
					this.defenserArmies[(int)b2].setPosition(new Vector3(x4, 0f, z4), new Vector3(-10000f, 0f, z4), 0);
					this.defenserArmies[(int)b2].MaxHP = 100;
					b2 += 1;
				}
			}
			this.attackerCount = b;
			this.attackerAliveCount = b;
			this.defenserCount = b2;
			this.defenserAliveCount = b2;
			if (this.bFirstTimeInit)
			{
				for (int l = 0; l < this.attackerHeroIdCache.Count; l++)
				{
					bool isLord = this.attackerHeroIdCache[l] == this.attackerLordID;
					Lord lord = new Lord(this.attackerHeroIdCache[l], 1, 1, 0, isLord, byte.MaxValue);
					lord.LordAnimSetting(0);
					lord.transform.parent = this.renderRoot;
					lord.transform.position = this.nonUseHeroPos_Left[l];
					lord.transform.rotation = Quaternion.LookRotation(Vector3.right);
					lord.FSMController = FSMManager.Instance.getState(EStateName.OUTSIDE_HERO_DISPLAY);
					if (this.attackerHeroIdCache[l] == this.attackerLordID)
					{
						ushort effID = (this.actionKind != EPlayerActionKind.ATTACKER) ? 2017 : 2014;
						this.particleMgr.Spawn(effID, lord.transform, Vector3.zero, 1f, true, true);
						lord.IsLord = true;
						this.attackerLordUnit = lord;
					}
					this.attackerHeroCache.Add(lord);
				}
			}
			else
			{
				this.attackerHeroIdCache.Clear();
				for (int m = 0; m < this.attackerHeroCache.Count; m++)
				{
					this.attackerHeroCache[m].LordAnimSetting(0);
					this.attackerHeroCache[m].transform.position = this.nonUseHeroPos_Left[m];
					this.attackerHeroCache[m].transform.rotation = Quaternion.LookRotation(Vector3.right);
					this.attackerHeroCache[m].FSMController = FSMManager.Instance.getState(EStateName.OUTSIDE_HERO_DISPLAY);
					if (!this.attackerHeroIdCache.Contains(this.attackerHeroCache[m].lordID))
					{
						this.attackerHeroIdCache.Add(this.attackerHeroCache[m].lordID);
					}
				}
			}
			if (this.bFirstTimeInit)
			{
				Vector3[] array19 = (this.SiegeMode > 1) ? this.nonUseHeroPos_Right_SiegeMode : this.nonUseHeroPos_Right;
				for (int n = 0; n < this.defenserHeroIdCache.Count; n++)
				{
					bool isLord2 = this.defenserHeroIdCache[n] == this.defenserLordID;
					Lord lord2 = new Lord(this.defenserHeroIdCache[n], 1, 1, 1, isLord2, byte.MaxValue);
					lord2.LordAnimSetting(0);
					lord2.transform.parent = this.renderRoot;
					lord2.transform.position = array19[n];
					lord2.transform.rotation = Quaternion.LookRotation(Vector3.left);
					lord2.FSMController = FSMManager.Instance.getState(EStateName.OUTSIDE_HERO_DISPLAY);
					if (this.defenserHeroIdCache[n] == this.defenserLordID)
					{
						ushort effID2 = (b3 != 0) ? 2017 : 2014;
						this.particleMgr.Spawn(effID2, lord2.transform, Vector3.zero, 1f, true, true);
						lord2.IsLord = true;
						this.defenserLordUnit = lord2;
						if (this.SiegeMode > 1)
						{
							lord2.transform.position = new Vector3(55f, 7.6f, 15f);
						}
					}
					this.defenserHeroCache.Add(lord2);
				}
			}
			else
			{
				this.defenserHeroIdCache.Clear();
				Vector3[] array20 = (this.SiegeMode > 1) ? this.nonUseHeroPos_Right_SiegeMode : this.nonUseHeroPos_Right;
				for (int num27 = 0; num27 < this.defenserHeroCache.Count; num27++)
				{
					this.defenserHeroCache[num27].LordAnimSetting(0);
					this.defenserHeroCache[num27].transform.position = array20[num27];
					this.defenserHeroCache[num27].transform.rotation = Quaternion.LookRotation(Vector3.left);
					this.defenserHeroCache[num27].FSMController = FSMManager.Instance.getState(EStateName.OUTSIDE_HERO_DISPLAY);
					if (!this.defenserHeroIdCache.Contains(this.defenserHeroCache[num27].lordID))
					{
						this.defenserHeroIdCache.Add(this.defenserHeroCache[num27].lordID);
					}
					if (this.defenserHeroIdCache[num27] == this.defenserLordID && this.SiegeMode > 1)
					{
						this.defenserHeroCache[num27].transform.position = new Vector3(55f, 7.6f, 15f);
					}
				}
			}
			if (this.bFirstTimeInit)
			{
				this.bFirstTimeInit = false;
			}
			DataManager.Instance.MaxValue_War[0] = num4;
			DataManager.Instance.NowValue_War[0] = num4;
		}
		else if (flag)
		{
			this.defenserCount = b2;
			this.defenserAliveCount = b2;
		}
		if (!bCoordModeReset || flag)
		{
			if (instance.CurWallHp == 0u)
			{
				num5 -= (long)((ulong)this.LastTrapsHp);
				if (num5 < 0L)
				{
					num5 = 0L;
				}
				this.LastTrapsHp = 0u;
				instance.CastleTrapsDestroyedCount = 0L;
			}
			DataManager.Instance.MaxValue_War[1] = num5;
			DataManager.Instance.NowValue_War[1] = num5;
		}
		if (DataManager.CompareStr(instance.PlayerName_War[0], instance.RoleAttr.Name) == 0)
		{
			instance.PlayerName_War[0].ClearString();
			instance.PlayerName_War[0].Append(instance.mStringTable.GetStringByID(678u));
			instance.AllianceTag_War[0].ClearString();
		}
		else if (DataManager.CompareStr(instance.PlayerName_War[1], instance.RoleAttr.Name) == 0)
		{
			instance.PlayerName_War[1].ClearString();
			instance.PlayerName_War[1].Append(instance.mStringTable.GetStringByID(678u));
			instance.AllianceTag_War[1].ClearString();
		}
		if (this.FOMgr == null)
		{
			for (int num28 = 0; num28 < 8; num28++)
			{
				ushort[] array21 = array3;
				int num29 = num28;
				array21[num29] *= 2;
			}
			this.FOMgr = new FlyingObjectManager(this.renderRoot, array3, this.particleMgr);
			this.m_BrokenFO[0] = new BrokenFO[(int)array3[0]];
			for (int num30 = 0; num30 < this.m_BrokenFO[0].Length; num30++)
			{
				this.m_BrokenFO[0][num30] = new BrokenFO(4, 1);
				this.m_BrokenFO[0][num30].transform.parent = this.renderRoot;
			}
			this.m_BrokenFO[1] = new BrokenFO[(int)array3[3]];
			for (int num31 = 0; num31 < this.m_BrokenFO[1].Length; num31++)
			{
				this.m_BrokenFO[1][num31] = new BrokenFO(4, 2);
				this.m_BrokenFO[1][num31].transform.parent = this.renderRoot;
			}
		}
		if (this.SiegeMode > 1)
		{
			if (this.castle == null)
			{
				this.castle = new WarCastle(this.m_GateTier, this.renderRoot, this.castleWeaponInfo);
				this.castle.particleManager = this.particleMgr;
			}
			this.castle.MaxHP = (int)(instance.MaxWallHp * 100u);
			this.castle.GotHurt = (int)((instance.MaxWallHp - instance.CurWallHp) * 100u);
		}
		this.MoraleStep = 4;
		Array.Clear(this.PickList, 0, 10);
		this.PickListCount = 0;
		for (int num32 = 0; num32 < (int)this.attackerCount; num32++)
		{
			if (this.attackerArmies[num32].heroSoldier != null)
			{
				this.PickList[(int)this.PickListCount] = this.attackerArmies[num32].heroSoldier.gameObject;
				this.PickListCount += 1;
			}
		}
		for (int num33 = 0; num33 < (int)this.defenserCount; num33++)
		{
			if (this.defenserArmies[num33].heroSoldier != null)
			{
				this.PickList[(int)this.PickListCount] = this.defenserArmies[num33].heroSoldier.gameObject;
				this.PickListCount += 1;
			}
		}
		for (int num34 = 0; num34 < this.attackerHeroCache.Count; num34++)
		{
			if (this.attackerHeroCache[num34] != null)
			{
				this.PickList[(int)this.PickListCount] = this.attackerHeroCache[num34].gameObject;
				this.PickListCount += 1;
			}
		}
		for (int num35 = 0; num35 < this.defenserHeroCache.Count; num35++)
		{
			if (this.defenserHeroCache[num35] != null)
			{
				this.PickList[(int)this.PickListCount] = this.defenserHeroCache[num35].gameObject;
				this.PickListCount += 1;
			}
		}
	}

	// Token: 0x060023C6 RID: 9158 RVA: 0x00418E2C File Offset: 0x0041702C
	public void checkPickHero(bool bShow)
	{
		if (bShow)
		{
			Vector2? vector = null;
			Vector2? vector2 = new Vector2?(Input.GetTouch(0).position);
			if (vector2 != null)
			{
				GameObject gameObject = GameConstants.GameObjectPick(vector2.Value, this.PickList, typeof(SkinnedMeshRenderer), false);
				if (gameObject != null)
				{
					uint num = 0u;
					if (uint.TryParse(gameObject.name, out num))
					{
						ushort heroId = 0;
						bool bLord = false;
						ushort num2 = this.checkArmyGroupHintState(num, out heroId, out bLord);
						if (num2 != 0)
						{
							this.PickedTrans = gameObject.transform;
							this.HintTrans = this.uiBattle.SetHint(true, bLord, heroId, num2);
							this.HintHeroNo = num;
							this.HintStrID = num2;
							this.HintTimer = 0f;
						}
					}
				}
				else if (this.HintTrans != null)
				{
					this.checkPickHero(false);
				}
			}
		}
		else if (this.HintTrans != null)
		{
			this.HintTrans = null;
			this.PickedTrans = null;
			this.HintHeroNo = 0u;
			this.HintStrID = 0;
			this.uiBattle.SetHint(false, false, 0, 0);
		}
	}

	// Token: 0x060023C7 RID: 9159 RVA: 0x00418F60 File Offset: 0x00417160
	private ushort checkArmyGroupHintState(uint heroNo, out ushort heroID, out bool bLord)
	{
		ushort num = (ushort)(heroNo >> 16 & 65535u);
		byte b = (byte)(heroNo >> 8 & 255u);
		byte b2 = (byte)(heroNo & 255u);
		byte b3 = b & 1;
		ushort result = 0;
		if (b2 == 255)
		{
			result = 833;
		}
		else
		{
			ArmyGroup[] array = (b3 != 0) ? this.defenserArmies : this.attackerArmies;
			ArmyGroup armyGroup = array[(int)b2];
			if (armyGroup.HasLord && armyGroup.CurHP == 0)
			{
				result = 832;
			}
			else if (armyGroup.CurHP != 0)
			{
				if (armyGroup.State == ArmyGroup.EGROUPSTATE.MOVING)
				{
					result = 830;
				}
				else
				{
					result = 831;
				}
			}
		}
		heroID = num;
		bLord = ((b & 2) != 0);
		return result;
	}

	// Token: 0x060023C8 RID: 9160 RVA: 0x0041902C File Offset: 0x0041722C
	public void resetWar(eLegBattleSimulationType type = eLegBattleSimulationType.None, bool bCamCoordMode = false)
	{
		DataManager instance = DataManager.Instance;
		this.BSUtil.InitCSSimulator(instance.War_RndSeed, instance.War_RndGap);
		this.loadWarInfo(false);
		GUIManager.Instance.CloseMenu(EGUIWindow.UI_LegBattle);
		if (this.LordCage != null)
		{
			this.LordCage.gameObject.SetActive(false);
		}
		if (this.castle != null)
		{
			this.castle.Reset();
		}
		this.m_ui32Tcik = 0u;
		this.deltaTime = 0f;
		this.m_WarResult = EWarResult.NONE;
		this.SubState = 0;
		this.WCamera.SetTargetPosition(Vector3.zero, false, 1f);
		this.WCamera.initCamera(this.attackerArmies, (int)this.attackerCount, this.defenserArmies, (int)this.defenserCount);
		if (bCamCoordMode)
		{
			this.WCamera.CoordCamMode = true;
		}
		this.uiBattle = (UILegBattle)GUIManager.Instance.OpenMenu(EGUIWindow.UI_LegBattle, (int)this.actionKind, (int)((WarManager.WarKind != WarManager.EWarKind.CoordTest) ? eLegBattleSimulationType.None : type), false, false, false);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 0, 0);
		GUIManager.Instance.pDVMgr.NextWar();
		float fillAmount = instance.CurWallHp / instance.MaxWallHp;
		byte side = (this.actionKind != EPlayerActionKind.ATTACKER) ? 0 : 1;
		GUIManager.Instance.pDVMgr.SetBloodBarFillAmount((int)side, 16, fillAmount);
		if (this.AttackSoundKey != 21)
		{
			this.audioMgr.StopSFX(this.AttackSoundKey, true);
		}
		if (this.MovingSoundKey != 21)
		{
			this.audioMgr.StopSFX(this.MovingSoundKey, true);
		}
		FSMManager.Instance.bIsBattleOver = false;
		AudioManager.Instance.LoadAndPlayBGM(BGMType.LegionWar, 1, false);
		this.m_WarState = ((WarManager.WarKind != WarManager.EWarKind.CoordTest) ? WarManager.WarState.WAITING_FOR_START : WarManager.WarState.CHANGE_COORD_MODE);
	}

	// Token: 0x060023C9 RID: 9161 RVA: 0x00419204 File Offset: 0x00417404
	private void UpdateSkillLightmap()
	{
		int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
		int curLightmapIdx = 2 + sceneLightmapSize;
		int curLightmapIdx2 = 1 + sceneLightmapSize;
		if (this.m_SkillWorkingList == 0UL)
		{
			for (int i = 0; i < (int)this.attackerCount; i++)
			{
				this.attackerArmies[i].resetLightmap(curLightmapIdx);
			}
			for (int j = 0; j < (int)this.defenserCount; j++)
			{
				this.defenserArmies[j].resetLightmap(curLightmapIdx);
			}
		}
		else
		{
			ulong num = this.m_SkillWorkingList;
			int k = 0;
			while (k < (int)this.attackerCount)
			{
				if ((num & 1UL) > 0UL)
				{
					this.attackerArmies[k].resetLightmap(curLightmapIdx2);
				}
				k++;
				num >>= 1;
			}
			num = this.m_SkillWorkingList >> 32;
			int l = 0;
			while (l < (int)this.defenserCount)
			{
				if ((num & 1UL) > 0UL)
				{
					this.defenserArmies[l].resetLightmap(curLightmapIdx2);
				}
				l++;
				num >>= 1;
			}
		}
	}

	// Token: 0x060023CA RID: 9162 RVA: 0x00419310 File Offset: 0x00417510
	private void playBrokenFO(byte idx, Transform trans)
	{
		if ((int)idx < this.m_BrokenFO.Length && this.m_BrokenFO[(int)idx] != null)
		{
			for (int i = 0; i < this.m_BrokenFO[(int)idx].Length; i++)
			{
				if (!this.m_BrokenFO[(int)idx][i].transform.gameObject.activeSelf)
				{
					this.m_BrokenFO[(int)idx][i].Play(trans);
					return;
				}
			}
		}
	}

	// Token: 0x060023CB RID: 9163 RVA: 0x00419384 File Offset: 0x00417584
	private void playBrokenFO(byte idx, Vector3 pos, Vector3 dir)
	{
		if ((int)idx < this.m_BrokenFO.Length && this.m_BrokenFO[(int)idx] != null)
		{
			for (int i = 0; i < this.m_BrokenFO[(int)idx].Length; i++)
			{
				if (!this.m_BrokenFO[(int)idx][i].transform.gameObject.activeSelf)
				{
					this.m_BrokenFO[(int)idx][i].Play(pos, dir);
					return;
				}
			}
		}
	}

	// Token: 0x060023CC RID: 9164 RVA: 0x004193F8 File Offset: 0x004175F8
	private void playBrokenFO(byte idx, Vector3 pos, Quaternion qua)
	{
		if ((int)idx < this.m_BrokenFO.Length && this.m_BrokenFO[(int)idx] != null)
		{
			for (int i = 0; i < this.m_BrokenFO[(int)idx].Length; i++)
			{
				if (!this.m_BrokenFO[(int)idx][i].transform.gameObject.activeSelf)
				{
					this.m_BrokenFO[(int)idx][i].Play(pos, qua);
					return;
				}
			}
		}
	}

	// Token: 0x060023CD RID: 9165 RVA: 0x0041946C File Offset: 0x0041766C
	private void playCollapse()
	{
		if (this.SiegeMode < 4)
		{
			for (int i = 0; i < 4; i++)
			{
				int num = (int)this.defenserArmiesMap[1, i];
				if (num != 0 && this.defenserArmies[num - 1] != null)
				{
					float x = WarManager.InitPositionRight_SiegeMode[1, i, 0];
					float z = WarManager.InitPositionRight_SiegeMode[1, i, 1];
					this.defenserArmies[num - 1].setPosition(new Vector3(x, 0f, z), new Vector3(-1000f, 0f, z), 0);
				}
			}
		}
		for (int j = 0; j < this.attackerArmies.Length; j++)
		{
			if (this.attackerArmies[j] != null)
			{
				this.attackerArmies[j].State = ArmyGroup.EGROUPSTATE.IDLE_WITHOUT_CLUMP;
				if (this.attackerArmies[j].heroSoldier != null)
				{
					this.attackerArmies[j].setLordAnimEnable(false);
				}
			}
		}
		for (int k = 0; k < this.defenserArmies.Length; k++)
		{
			if (this.defenserArmies[k] != null)
			{
				this.defenserArmies[k].bAttackMode = true;
				if (this.defenserArmies[k].HasHeroDisplay)
				{
					this.defenserArmies[k].heroSoldier.transform.position = this.defenserArmies[k].groupRoot.TransformPoint(this.defenserArmies[k].HeroOffset);
					this.defenserArmies[k].heroSoldier.transform.rotation = this.defenserArmies[k].groupRoot.rotation;
					this.defenserArmies[k].heroSoldier.ResetAnimToIdle();
					this.defenserArmies[k].setLordAnimEnable(false);
				}
			}
		}
		for (int l = 0; l < this.defenserHeroIdCache.Count; l++)
		{
			if (this.defenserHeroIdCache[l] == this.defenserLordID)
			{
				this.defenserHeroCache[l].transform.position = this.nonUseHeroPos_Right_SiegeMode[l];
				break;
			}
		}
		this.setOutsideHeroAnimEnable(false);
		if (this.AttackSoundKey != 21)
		{
			this.audioMgr.StopSFX(this.AttackSoundKey, true);
			this.AttackSoundKey = 21;
		}
		else if (this.MovingSoundKey != 21)
		{
			this.audioMgr.StopSFX(this.MovingSoundKey, true);
			this.MovingSoundKey = 21;
		}
		this.SiegeMode = 1;
		FSMManager.Instance.bIsSiegeMode = false;
		DataManager.Instance.NowValue_War[2] = 0L;
		this.UIUpdateFlag |= 4;
		if (DataManager.Instance.WarMoraleValue[1] != 0UL)
		{
			this.CaleWarMorale(1, this.TrapsHp);
		}
		else
		{
			DataManager.Instance.WarMorale[1] = 0;
			this.UIUpdateFlag |= 2;
		}
		DataManager.Instance.NowValue_War[1] -= (long)((ulong)this.LastTrapsHp);
		DataManager.Instance.NowValue_War[1] = Math.Max(0L, DataManager.Instance.NowValue_War[1]);
		this.UIUpdateFlag |= 2;
		this.uiBattle.AddCenterMsg(499, (this.actionKind != EPlayerActionKind.ATTACKER) ? 0 : 1);
		this.FOMgr.recoverSpecialArrow();
		this.m_WarState = WarManager.WarState.CASTLE_DESTROYING;
	}

	// Token: 0x060023CE RID: 9166 RVA: 0x004197DC File Offset: 0x004179DC
	private void setOutsideHeroAnimEnable(bool bEnable)
	{
		float speed = (!bEnable) ? 0f : 1f;
		for (int i = 0; i < this.attackerHeroCache.Count; i++)
		{
			Animation animComponent = this.attackerHeroCache[i].getAnimComponent();
			if (animComponent != null)
			{
				animComponent["idle"].speed = speed;
				animComponent["victory"].speed = speed;
			}
		}
		for (int j = 0; j < this.defenserHeroCache.Count; j++)
		{
			Animation animComponent2 = this.defenserHeroCache[j].getAnimComponent();
			if (animComponent2 != null)
			{
				animComponent2["idle"].speed = speed;
				animComponent2["victory"].speed = speed;
			}
		}
	}

	// Token: 0x060023CF RID: 9167 RVA: 0x004198BC File Offset: 0x00417ABC
	private void PlayCheerSound()
	{
		if (this.AttackSoundKey < 21)
		{
			this.audioMgr.StopSFX(this.AttackSoundKey, true);
			this.AttackSoundKey = 21;
		}
		if (this.MovingSoundKey != 21)
		{
			this.audioMgr.StopSFX(this.MovingSoundKey, true);
			this.MovingSoundKey = 21;
		}
		this.movingSoundParentTrans.position = this.CageTargetPos;
		this.audioMgr.PlaySFXLoop(20014, out this.AttackSoundKey, this.movingSoundParentTrans, SFXEffect.Normal, 0f);
	}

	// Token: 0x060023D0 RID: 9168 RVA: 0x0041994C File Offset: 0x00417B4C
	private void CageUpdate(float deltaTime)
	{
		if (this.CageState == 1)
		{
			FSMManager instance = FSMManager.Instance;
			if (instance.CaptivingCount >= instance.MaxCaptiver)
			{
				this.LordCage.gameObject.SetActive(true);
				this.LordCage.position = this.CageTargetPos + new Vector3(0f, 20f, 0f);
				this.particleMgr.Spawn(2015, null, this.CageTargetPos, 1f, true, false);
				this.PlayCheerSound();
				this.audioMgr.PlaySFX(20013, 0f, PitchKind.NoPitch, this.LordCage, null);
				this.CageTimer = 0f;
				this.CageState = 2;
			}
		}
		else if (this.CageState == 2)
		{
			float num = 150f + 2000f * this.CageTimer * this.CageTimer;
			this.CageTimer += deltaTime;
			this.LordCage.position = Vector3.MoveTowards(this.LordCage.position, this.CageTargetPos, num * deltaTime);
			if (this.LordCage.position == this.CageTargetPos)
			{
				this.CageTimer = 0f;
				this.CageState = 3;
			}
		}
		else if (this.CageState == 3)
		{
			this.LordCage.position = this.CageTargetPos + new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(0f, 0.5f), UnityEngine.Random.Range(-0.5f, 0.5f));
			this.CageTimer += deltaTime;
			if (this.CageTimer > 0.2f)
			{
				this.CageState = 0;
				int arg;
				if (this.m_WarResult == EWarResult.WIN)
				{
					arg = ((this.actionKind != EPlayerActionKind.ATTACKER) ? 3 : 1);
				}
				else
				{
					arg = ((this.actionKind != EPlayerActionKind.ATTACKER) ? 1 : 3);
				}
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_LegBattle, 4, arg);
			}
		}
	}

	// Token: 0x060023D1 RID: 9169 RVA: 0x00419B64 File Offset: 0x00417D64
	public void SetWarCameraModel()
	{
		if (this.WCamera != null && !this.WCamera.CoordCamMode)
		{
			this.CameraModel = ((this.CameraModel != 0) ? 0 : 1);
			this.WCamera.initCamera(this.attackerArmies, (int)this.attackerCount, this.defenserArmies, (int)this.defenserCount);
		}
	}

	// Token: 0x060023D2 RID: 9170 RVA: 0x00419BC8 File Offset: 0x00417DC8
	public void CheckSound()
	{
		if ((this.SoundDirtyFlag & 4u) != 0u && this.rangeSoundParent != null)
		{
			this.audioMgr.PlaySFX(20005, 0f, PitchKind.NoPitch, this.rangeSoundParent.groupRoot, null);
			this.audioMgr.PlaySFX(20007, UnityEngine.Random.Range(0f, 0.45f), PitchKind.NoPitch, this.rangeSoundParent.groupRoot, null);
			this.rangeSoundParent = null;
			this.rangeDist_Sound = null;
		}
		if ((this.SoundDirtyFlag & 8u) != 0u && this.stoneHitSoundParent != null)
		{
			this.audioMgr.PlaySFX(20001, 0f, PitchKind.NoPitch, this.stoneHitSoundParent.groupRoot, null);
			this.audioMgr.PlaySFX((ushort)UnityEngine.Random.Range(20002, 20005), 0.25f, PitchKind.NoPitch, this.stoneHitSoundParent.groupRoot, null);
			this.stoneHitSoundParent = null;
			this.stoneHitDist_Sound = null;
		}
		if ((this.SoundDirtyFlag & 1u) != 0u)
		{
			this.audioMgr.PlaySFXLoop(20012, out this.MovingSoundKey, this.movingSoundParentTrans, SFXEffect.Normal, 0f);
			this.movingSoundParent = null;
			this.movingDist_Sound = null;
		}
		if ((this.SoundDirtyFlag & 2u) != 0u && this.attackSoundParent != null)
		{
			this.audioMgr.PlaySFXLoop(20011, out this.AttackSoundKey, this.attackSoundParent.groupRoot, SFXEffect.Normal, 0f);
			this.attackSoundParent = null;
			this.attackDist_Sound = null;
		}
	}

	// Token: 0x060023D3 RID: 9171 RVA: 0x00419D90 File Offset: 0x00417F90
	public void CloseDrama()
	{
		if (this.bDramaWorking)
		{
			this.bDramaWorking = false;
			if (this.controlPanel != null)
			{
				this.controlPanel.gameObject.SetActive(true);
			}
			if (this.NewbieWarFlag != 0 && this.DramaTriggerFlag == 0u)
			{
				DataManager.Instance.battleInfo.RandomGap = 1;
				DataManager.Instance.battleInfo.RandomSeed = 1;
				DataManager.Instance.battleInfo.BattleType = 4;
				DataManager.Instance.battleInfo.StageKind = 0;
				DataManager.Instance.battleInfo.StageID = 0;
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.WarToBattle);
			}
		}
	}

	// Token: 0x060023D4 RID: 9172 RVA: 0x00419E4C File Offset: 0x0041804C
	public void SetCoordDirty()
	{
		if (WarManager.CoordSimuIndex_Left > 5 || WarManager.TroopKindSimuIndex_Right > 3)
		{
			return;
		}
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				WarManager.InitPositionLeft[i, j, 0] = 0f;
				WarManager.InitPositionLeft[i, j, 1] = 0f;
				WarManager.InitPositionLeft_SiegeMode[i, j, 0] = 0f;
				WarManager.InitPositionLeft_SiegeMode[i, j, 1] = 0f;
				WarManager.InitPositionRight[i, j, 0] = 0f;
				WarManager.InitPositionRight[i, j, 1] = 0f;
				if (i == 1)
				{
					WarManager.InitPositionRight_SiegeMode[i, j, 0] = 0f;
					WarManager.InitPositionRight_SiegeMode[i, j, 1] = 0f;
				}
				else
				{
					WarManager.InitPositionRight_SiegeMode[i, j, 0] = 0f;
					WarManager.InitPositionRight_SiegeMode[i, j, 1] = 0f;
				}
				if (i < 3)
				{
					WarManager.ActionPositionRight[i, j, 0] = 0f;
					WarManager.ActionPositionRight[i, j, 1] = 0f;
				}
			}
		}
		DataManager instance = DataManager.Instance;
		WarManager.LoadLeftCoordDisplayData();
		WarManager.LoadRightCoordDisplayData();
		WarManager.SetupCoordinate((int)WarManager.CoordSimuIndex_Left, (int)WarManager.TroopKindSimuIndex_Right);
		this.BSUtil.InitCSSimulator(instance.War_RndSeed, instance.War_RndGap);
		this.loadWarInfo(true);
		if (WarManager.WarCoordIndex_Left != WarManager.CoordSimuIndex_Left)
		{
			for (int k = 0; k < 4; k++)
			{
				for (int l = 0; l < 4; l++)
				{
					if (this.attackerArmiesMap[k, l] != 0 && this.attackerArmies[(int)(this.attackerArmiesMap[k, l] - 1)] != null)
					{
						this.attackerArmies[(int)(this.attackerArmiesMap[k, l] - 1)].setPositionAndMove(WarManager.InitPositionLeft[k, l, 0], WarManager.InitPositionLeft[k, l, 1]);
					}
				}
			}
		}
		if (WarManager.WarCoordIndex_Right != WarManager.TroopKindSimuIndex_Right)
		{
			for (int m = 0; m < 4; m++)
			{
				for (int n = 0; n < 4; n++)
				{
					if (this.defenserArmiesMap[m, n] != 0 && this.defenserArmies[(int)(this.defenserArmiesMap[m, n] - 1)] != null)
					{
						this.defenserArmies[(int)(this.defenserArmiesMap[m, n] - 1)].setPositionAndMove(WarManager.InitPositionRight[m, n, 0], WarManager.InitPositionRight[m, n, 1]);
					}
				}
			}
		}
		AudioManager.Instance.PlaySFX(40016, 0f, PitchKind.NoPitch, null, null);
		WarManager.WarCoordIndex_Left = WarManager.CoordSimuIndex_Left;
		WarManager.WarCoordIndex_Right = WarManager.TroopKindSimuIndex_Right;
		int index = (int)(WarManager.CoordSimuIndex_Left * 3 + WarManager.TroopKindSimuIndex_Right);
		CoordResultData recordByIndex = instance.CoordResultTable.GetRecordByIndex(index);
		WarManager.MoraleInfo.WinnerSide = ((recordByIndex.Left_TotalLose >= recordByIndex.Right_TotalLose) ? 2 : 1);
		WarManager.MoraleInfo.bWallDown = 0;
		WarManager.MoraleInfo.bEliminate = 0;
		WarManager.MoraleInfo.AssaultLostForce = recordByIndex.Left_TotalLose;
		WarManager.MoraleInfo.DefenceLostForce = recordByIndex.Right_TotalLose;
		WarManager.CheckMorale();
	}

	// Token: 0x060023D5 RID: 9173 RVA: 0x0041A1B8 File Offset: 0x004183B8
	public void StartTestCoordWar()
	{
		if (this.m_WarState == WarManager.WarState.CHANGE_COORD_MODE)
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (this.attackerArmiesMap[i, j] != 0 && this.attackerArmies[(int)(this.attackerArmiesMap[i, j] - 1)] != null)
					{
						this.attackerArmies[(int)(this.attackerArmiesMap[i, j] - 1)].setPositionInstantlyIgnoreHeroAndAxisY(WarManager.InitPositionLeft[i, j, 0], WarManager.InitPositionLeft[i, j, 1], Vector3.right);
					}
				}
			}
			for (int k = 0; k < 4; k++)
			{
				for (int l = 0; l < 4; l++)
				{
					if (this.defenserArmiesMap[k, l] != 0 && this.defenserArmies[(int)(this.defenserArmiesMap[k, l] - 1)] != null)
					{
						this.defenserArmies[(int)(this.defenserArmiesMap[k, l] - 1)].setPositionInstantlyIgnoreHeroAndAxisY(WarManager.InitPositionRight[k, l, 0], WarManager.InitPositionRight[k, l, 1], Vector3.left);
					}
				}
			}
			this.m_WarState = WarManager.WarState.WAITING_FOR_START;
		}
	}

	// Token: 0x060023D6 RID: 9174 RVA: 0x0041A2F0 File Offset: 0x004184F0
	public static byte TerrainKind_S_To_C(byte tk)
	{
		if (tk == 2)
		{
			return 3;
		}
		if (tk == 3)
		{
			return 2;
		}
		return 1;
	}

	// Token: 0x060023D7 RID: 9175 RVA: 0x0041A308 File Offset: 0x00418508
	public static void UpdateLocalTimeToTheme(long time = 0L)
	{
		DataManager instance = DataManager.Instance;
		if (time == 0L)
		{
			time = instance.ServerTime;
		}
		int hour = GameConstants.GetDateTime(time).Hour;
		if (hour >= 14 && hour < 20)
		{
			instance.War_MapTheme = 2;
		}
		else if (hour >= 20 || hour < 5)
		{
			instance.War_MapTheme = 3;
		}
		else
		{
			instance.War_MapTheme = 1;
		}
	}

	// Token: 0x060023D8 RID: 9176 RVA: 0x0041A378 File Offset: 0x00418578
	public static void SetupCoordinate(int LeftCoordIndex, int RightCoordIndex)
	{
		Debug.Log("LeftCoordIndex: " + LeftCoordIndex.ToString() + " RightCoordIndex: " + RightCoordIndex.ToString());
		int num = LeftCoordIndex * 16;
		int num2 = RightCoordIndex * 16;
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				CoordData recordByIndex = DataManager.Instance.CoordTable.GetRecordByIndex(num);
				WarManager.InitPositionLeft[i, j, 0] = (float)recordByIndex.AtkX * 0.01f;
				WarManager.InitPositionLeft[i, j, 1] = (float)(recordByIndex.AtkY - 200) * 0.01f;
				WarManager.InitPositionLeft_SiegeMode[i, j, 0] = (float)recordByIndex.SiegeAtkX * 0.01f;
				WarManager.InitPositionLeft_SiegeMode[i, j, 1] = (float)(recordByIndex.SiegeAtkY - 200) * 0.01f;
				num++;
				CoordData recordByIndex2 = DataManager.Instance.CoordTable.GetRecordByIndex(num2);
				WarManager.InitPositionRight[i, j, 0] = (float)recordByIndex2.DefX * 0.01f;
				WarManager.InitPositionRight[i, j, 1] = (float)(recordByIndex2.DefY - 200) * 0.01f;
				if (i == 1)
				{
					WarManager.InitPositionRight_SiegeMode[i, j, 0] = (float)recordByIndex2.SiegeRangeNoWallDefX * 0.01f;
					WarManager.InitPositionRight_SiegeMode[i, j, 1] = (float)(recordByIndex2.SiegeRangeNoWallDefY - 200) * 0.01f;
				}
				else
				{
					WarManager.InitPositionRight_SiegeMode[i, j, 0] = (float)recordByIndex2.SiegeDefX * 0.01f;
					WarManager.InitPositionRight_SiegeMode[i, j, 1] = (float)(recordByIndex2.SiegeDefY - 200) * 0.01f;
				}
				if (i < 3)
				{
					WarManager.ActionPositionRight[i, j, 0] = (float)recordByIndex2.Siege23DefX * 0.01f;
					WarManager.ActionPositionRight[i, j, 1] = (float)(recordByIndex2.Siege23DefY - 200) * 0.01f;
				}
				num2++;
			}
		}
		BSInvokeUtil.getInstance.SetCoordData((ushort)LeftCoordIndex, (ushort)RightCoordIndex);
	}

	// Token: 0x060023D9 RID: 9177 RVA: 0x0041A58C File Offset: 0x0041878C
	public static void RecvFastStartNpcWar(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			WarManager.MoraleInfo.WinnerSide = MP.ReadByte(-1);
			WarManager.MoraleInfo.bEliminate = MP.ReadByte(-1);
			WarManager.MoraleInfo.bWallDown = MP.ReadByte(-1);
			WarManager.MoraleInfo.AssaultLostForce = MP.ReadUInt(-1);
			WarManager.MoraleInfo.DefenceLostForce = MP.ReadUInt(-1);
			WarManager.RecvStartNpcWar(MP);
			WarManager.CheckMorale();
		}
	}

	// Token: 0x060023DA RID: 9178 RVA: 0x0041A608 File Offset: 0x00418808
	public static void RecvStartNpcWar(MessagePacket MP)
	{
		DataManager.Instance.War_MapTheme = 3;
		WarManager.RecvStartWar(MP);
		WarManager.NpcModeEnable = 1;
	}

	// Token: 0x060023DB RID: 9179 RVA: 0x0041A624 File Offset: 0x00418824
	public static void RecvStartWar(MessagePacket MP)
	{
		DataManager instance = DataManager.Instance;
		WarManager.NpcModeEnable = 0;
		instance.War_RndSeed = MP.ReadUShort(-1);
		instance.War_RndGap = (ushort)MP.ReadByte(-1);
		instance.War_LordCapture = MP.ReadByte(-1);
		instance.War_MapKind = (ushort)WarManager.TerrainKind_S_To_C(MP.ReadByte(-1));
		if (WarManager.CurrentPointKind == POINT_KIND.PK_YOLK)
		{
			instance.War_MapKind = 4;
		}
		WarManager.CurrentPointKind = POINT_KIND.PK_NONE;
		instance.War_LeftCastleLv = MP.ReadByte(-1);
		instance.War_LeftHeroNum = MP.ReadByte(-1);
		int num = (int)MP.ReadByte(-1);
		for (int i = 0; i < 5; i++)
		{
			instance.pLeftLeaderData[i].HeroID = MP.ReadUShort(-1);
			instance.pLeftLeaderData[i].Rank = MP.ReadByte(-1);
			instance.pLeftLeaderData[i].Star = MP.ReadByte(-1);
		}
		for (int j = 0; j < 4; j++)
		{
			for (int k = 0; k < 4; k++)
			{
				instance.pLeftTroopForce[j, k] = MP.ReadUInt(-1);
			}
		}
		for (int l = 0; l < 4; l++)
		{
			instance.War_LeftAttackAttr[l] = MP.ReadUInt(-1);
		}
		for (int m = 0; m < 4; m++)
		{
			instance.War_LeftDefenseAttr[m] = MP.ReadUInt(-1);
		}
		for (int n = 0; n < 4; n++)
		{
			instance.War_LeftHealthAttr[n] = MP.ReadUInt(-1);
		}
		if (num < 5)
		{
			instance.War_LeftLordID = instance.pLeftLeaderData[num].HeroID;
		}
		else
		{
			instance.War_LeftLordID = 0;
		}
		WarManager.WarCoordIndex_Left = (ushort)MP.ReadByte(-1);
		instance.War_RightCastleLv = MP.ReadByte(-1);
		instance.War_RightHeroNum = MP.ReadByte(-1);
		num = (int)MP.ReadByte(-1);
		for (int num2 = 0; num2 < 5; num2++)
		{
			instance.pRightLeaderData[num2].HeroID = MP.ReadUShort(-1);
			instance.pRightLeaderData[num2].Rank = MP.ReadByte(-1);
			instance.pRightLeaderData[num2].Star = MP.ReadByte(-1);
		}
		for (int num3 = 0; num3 < 4; num3++)
		{
			for (int num4 = 0; num4 < 4; num4++)
			{
				instance.pRightTroopForce[num3, num4] = MP.ReadUInt(-1);
			}
		}
		for (int num5 = 0; num5 < 4; num5++)
		{
			instance.War_RightAttackAttr[num5] = MP.ReadUInt(-1);
		}
		for (int num6 = 0; num6 < 4; num6++)
		{
			instance.War_RightDefenseAttr[num6] = MP.ReadUInt(-1);
		}
		for (int num7 = 0; num7 < 4; num7++)
		{
			instance.War_RightHealthAttr[num7] = MP.ReadUInt(-1);
		}
		if (num < 5)
		{
			instance.War_RightLordID = instance.pRightLeaderData[num].HeroID;
		}
		else
		{
			instance.War_RightLordID = 0;
		}
		WarManager.WarCoordIndex_Right = (ushort)MP.ReadByte(-1);
		instance.bSiege = MP.ReadByte(-1);
		if (instance.bSiege != 0)
		{
			instance.CurWallHp = MP.ReadUInt(-1);
			instance.MaxWallHp = MP.ReadUInt(-1);
			instance.War_WallLevel = MP.ReadByte(-1);
			for (int num8 = 0; num8 < 3; num8++)
			{
				for (int num9 = 0; num9 < 4; num9++)
				{
					instance.pCastleInfo[num8, num9] = MP.ReadUInt(-1);
				}
			}
			instance.War_WallAttr.TrapAttack = MP.ReadUInt(-1);
			instance.War_WallAttr.TrapDefence = MP.ReadUInt(-1);
			instance.War_WallAttr.TrapHealth = MP.ReadUInt(-1);
			instance.War_WallAttr.WallHealth = MP.ReadUInt(-1);
		}
		ushort[] array = new ushort[10];
		for (int num10 = 0; num10 < 5; num10++)
		{
			array[num10] = instance.pLeftLeaderData[num10].HeroID;
		}
		for (int num11 = 0; num11 < 5; num11++)
		{
			array[num11 + 5] = instance.pRightLeaderData[num11].HeroID;
		}
		if (!instance.CheckHeroBattleResourceReady(HeroFightType.LegionBatte, array))
		{
			GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8350u), 255, true);
			return;
		}
		instance.DramaTriggerFlag = 0u;
		instance.WarType = 0;
		GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MapToWar);
	}

	// Token: 0x060023DC RID: 9180 RVA: 0x0041AADC File Offset: 0x00418CDC
	public static void setupStageWar(byte Res)
	{
		DataManager instance = DataManager.Instance;
		StageManager stageDataController = DataManager.StageDataController;
		ushort num = DataManager.StageDataController.StageRecord[2] + 1;
		CorpsStage recordByKey = DataManager.StageDataController.CorpsStageTable.GetRecordByKey(num);
		CorpsStageBattle recordByKey2 = DataManager.StageDataController.CorpsStageBattleTable.GetRecordByKey(num);
		instance.War_MapKind = (ushort)((recordByKey2.Terrain != 0) ? recordByKey2.Terrain : 1);
		instance.War_MapTheme = ((recordByKey2.Weather != 0) ? recordByKey2.Weather : 1);
		instance.PlayerName_War[0].ClearString();
		instance.PlayerName_War[0].Append(instance.RoleAttr.Name);
		instance.PlayerName_War[1].ClearString();
		instance.PlayerName_War[1].Append(instance.mStringTable.GetStringByID((uint)recordByKey.LordTile));
		instance.AllianceTag_War[0].ClearString();
		if (instance.RoleAlliance.Id > 0u)
		{
			instance.AllianceTag_War[0].Append(instance.RoleAlliance.Tag);
		}
		instance.AllianceTag_War[1].ClearString();
		instance.KindomID_War[0] = 0;
		instance.KindomID_War[1] = 0;
		WarManager.WarCoordIndex_Left = (ushort)instance.RoleAttr.NowArmyCoordIndex;
		WarManager.WarCoordIndex_Right = 0;
		Array.Clear(instance.War_LeftAttackAttr, 0, instance.War_LeftAttackAttr.Length);
		Array.Clear(instance.War_LeftDefenseAttr, 0, instance.War_LeftDefenseAttr.Length);
		Array.Clear(instance.War_LeftHealthAttr, 0, instance.War_LeftHealthAttr.Length);
		Array.Clear(instance.pRightTroopForce, 0, instance.pRightTroopForce.Length);
		Array.Clear(instance.pCastleInfo, 0, instance.pCastleInfo.Length);
		Array.Clear(instance.War_RightAttackAttr, 0, instance.War_RightAttackAttr.Length);
		Array.Clear(instance.War_RightDefenseAttr, 0, instance.War_RightDefenseAttr.Length);
		Array.Clear(instance.War_RightHealthAttr, 0, instance.War_RightHealthAttr.Length);
		for (int i = 0; i < 5; i++)
		{
			instance.pRightLeaderData[i] = default(TroopLeaderType);
		}
		instance.War_RightCastleLv = recordByKey2.WallLevel;
		instance.CurWallHp = stageDataController.CorpsStageWallDefence;
		instance.MaxWallHp = recordByKey2.MaxWall;
		instance.bSiege = ((recordByKey2.WallLevel <= 0) ? 0 : 1);
		instance.War_WallLevel = recordByKey2.WallLevel;
		instance.War_RightHeroNum = 0;
		for (int j = 0; j < 5; j++)
		{
			instance.pRightLeaderData[j].HeroID = recordByKey.Heros[j].HeroID;
			instance.pRightLeaderData[j].Rank = recordByKey.Heros[j].Rank;
			instance.pRightLeaderData[j].Star = recordByKey.Heros[j].Star;
			if (recordByKey.Heros[j].HeroID != 0)
			{
				DataManager dataManager = instance;
				dataManager.War_RightHeroNum += 1;
			}
		}
		instance.War_RightLordID = instance.pRightLeaderData[0].HeroID;
		instance.War_LeftLordID = instance.RoleAttr.Head;
		for (int k = 0; k < 10; k++)
		{
			byte soldierTableID = stageDataController.NowCombatStageInfo[k].SoldierTableID;
			uint amount = stageDataController.NowCombatStageInfo[k].Amount;
			if (soldierTableID != 0)
			{
				if (soldierTableID <= 16)
				{
					instance.pRightTroopForce[(int)((soldierTableID - 1) / 4), (int)((soldierTableID - 1) % 4)] = amount;
				}
				else if (soldierTableID <= 20)
				{
					instance.pCastleInfo[0, (int)(soldierTableID - 17)] = amount;
				}
				else if (soldierTableID <= 24)
				{
					instance.pCastleInfo[1, (int)(soldierTableID - 21)] = amount;
				}
				else if (soldierTableID <= 28)
				{
					instance.pCastleInfo[2, (int)(soldierTableID - 25)] = amount;
				}
			}
		}
		BSInvokeUtil.getInstance.getCombatStageAttr((byte)num, instance.RoleAttr.Head, instance.War_LeftHeroNum, instance.pLeftLeaderData, instance.AttribVal.BaseVal_Total, instance.AttribVal.GetLordBaseVal(), instance.War_LeftAttackAttr, instance.War_LeftDefenseAttr, instance.War_LeftHealthAttr, instance.War_RightAttackAttr, instance.War_RightDefenseAttr, instance.War_RightHealthAttr, ref instance.War_WallAttr, DataManager.Instance.bHaveWarBuff);
		instance.DramaTriggerFlag = (uint)((int)recordByKey.BattleEndword << 16 | (int)recordByKey.BattleForeword);
		if ((stageDataController.isNotFirstInLine[2] & 1) != 0)
		{
			instance.DramaTriggerFlag &= 4294901760u;
		}
		else
		{
			byte[] isNotFirstInLine = stageDataController.isNotFirstInLine;
			int num2 = 2;
			isNotFirstInLine[num2] |= 1;
		}
		if (Res == 0)
		{
			instance.DramaTriggerFlag &= 65535u;
		}
		else
		{
			byte[] isNotFirstInLine2 = stageDataController.isNotFirstInLine;
			int num3 = 2;
			isNotFirstInLine2[num3] &= 254;
		}
	}

	// Token: 0x060023DD RID: 9181 RVA: 0x0041AFE4 File Offset: 0x004191E4
	public static void RecvFastStartWar(MessagePacket MP)
	{
		if (MP.ReadByte(-1) == 0)
		{
			WarManager.MoraleInfo.WinnerSide = MP.ReadByte(-1);
			WarManager.MoraleInfo.bEliminate = MP.ReadByte(-1);
			WarManager.MoraleInfo.bWallDown = MP.ReadByte(-1);
			WarManager.MoraleInfo.AssaultLostForce = MP.ReadUInt(-1);
			WarManager.MoraleInfo.DefenceLostForce = MP.ReadUInt(-1);
			WarManager.RecvStartWar(MP);
			WarManager.CheckMorale();
		}
	}

	// Token: 0x060023DE RID: 9182 RVA: 0x0041B060 File Offset: 0x00419260
	public static void RecvStartStageWar(MessagePacket MP)
	{
		GUIManager.Instance.HideUILock(EUILock.Expedition);
		byte b = MP.ReadByte(-1);
		byte b2 = 0;
		byte b3 = 0;
		bool flag = false;
		if (b < 2)
		{
			DataManager instance = DataManager.Instance;
			StageManager stageDataController = DataManager.StageDataController;
			WarManager.NpcModeEnable = 0;
			instance.War_LordCapture = 0;
			instance.bWarAttacker = true;
			instance.lastBattleResult = (short)b;
			instance.War_RndSeed = MP.ReadUShort(-1);
			instance.War_RndGap = (ushort)MP.ReadByte(-1);
			WarManager.setupStageWar(b);
			instance.SoldierTotal = 0L;
			instance.HospitalTotal = 0u;
			for (int i = 0; i < 16; i++)
			{
				instance.RoleAttr.m_Soldier[i] = MP.ReadUInt(-1);
				instance.SoldierTotal += (long)((ulong)instance.RoleAttr.m_Soldier[i]);
			}
			for (int j = 0; j < 16; j++)
			{
				instance.mSoldier_Hospital[j] = MP.ReadUInt(-1);
				instance.HospitalTotal += instance.mSoldier_Hospital[j];
			}
			instance.Resource[0].SetResource(MP.ReadUInt(-1), MP.ReadLong(-1));
			stageDataController.UpdateCorpsStageInfo(MP, false);
			WarManager.MoraleInfo.WinnerSide = MP.ReadByte(-1);
			WarManager.MoraleInfo.bEliminate = MP.ReadByte(-1);
			WarManager.MoraleInfo.bWallDown = MP.ReadByte(-1);
			WarManager.MoraleInfo.AssaultLostForce = MP.ReadUInt(-1);
			WarManager.MoraleInfo.DefenceLostForce = MP.ReadUInt(-1);
			instance.KingOldLv = instance.RoleAttr.Level;
			stageDataController.RoleAttrLevelUp(MP, 59);
			for (int k = 0; k < 5; k++)
			{
				ushort num = MP.ReadUShort(-1);
				b3 = instance.UpdateHeroAttr(num, MP);
				if (num != 0 && instance.curHeroData.ContainsKey((uint)num))
				{
					b2 = instance.curHeroData[(uint)num].Level;
					if (b2 > b3)
					{
						flag = true;
						GUIManager.Instance.AddHerodLvUpData(num, b3, b2);
					}
				}
			}
			if (flag && b2 > b3)
			{
				if (!GUIManager.Instance.bOpenHeroLvUp)
				{
					GUIManager.Instance.QueuedUI_Restricted(EGUIWindow.UI_HeroUp, 0, 0, false, 0);
					GUIManager.Instance.bOpenHeroLvUp = true;
				}
				else
				{
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroUp, 0, 0);
				}
			}
			WarManager.CheckMorale();
			instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Inner, byte.MaxValue);
			instance.WarType = 1;
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Expedition, 1, 0);
		}
		else
		{
			GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7226u), 255, true);
			GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Expedition);
		}
	}

	// Token: 0x060023DF RID: 9183 RVA: 0x0041B334 File Offset: 0x00419534
	public static void StartWar(byte Result, bool isAttacker, ushort RndSeed, byte RndGap, ref CombatPlayerData attacker, ref CombatPlayerData defencer)
	{
		DataManager instance = DataManager.Instance;
		instance.bWarAttacker = isAttacker;
		instance.KindomID_War[0] = attacker.KingdomID;
		instance.KindomID_War[1] = defencer.KingdomID;
		instance.PlayerName_War[0].ClearString();
		instance.PlayerName_War[0].Append(attacker.Name);
		instance.PlayerName_War[1].ClearString();
		instance.PlayerName_War[1].Append(defencer.Name);
		instance.AllianceTag_War[0].ClearString();
		instance.AllianceTag_War[0].Append(attacker.AllianceTag);
		instance.AllianceTag_War[1].ClearString();
		instance.AllianceTag_War[1].Append(defencer.AllianceTag);
		WarManager.NpcModeEnable = 0;
		instance.War_RndSeed = RndSeed;
		instance.War_RndGap = (ushort)RndGap;
		instance.War_LordCapture = 0;
		instance.War_MapKind = 1;
		instance.War_LeftCastleLv = attacker.StrongholdLevel;
		instance.War_LeftHeroNum = 0;
		int num = 5;
		for (int i = 0; i < 5; i++)
		{
			instance.pLeftLeaderData[i].HeroID = attacker.HeroInfo[i].ID;
			instance.pLeftLeaderData[i].Rank = attacker.HeroInfo[i].Rank;
			instance.pLeftLeaderData[i].Star = attacker.HeroInfo[i].Star;
			if (instance.pLeftLeaderData[i].HeroID != 0)
			{
				DataManager dataManager = instance;
				dataManager.War_LeftHeroNum += 1;
			}
			if (instance.pLeftLeaderData[i].HeroID == attacker.Head)
			{
				num = i;
			}
		}
		for (int j = 0; j < 4; j++)
		{
			for (int k = 0; k < 4; k++)
			{
				instance.pLeftTroopForce[j, k] = attacker.SurviveTroop[j * 4 + k] + attacker.DeadTroop[j * 4 + k];
			}
		}
		for (int l = 0; l < 4; l++)
		{
			instance.War_LeftAttackAttr[l] = attacker.AttackAttr[l];
		}
		for (int m = 0; m < 4; m++)
		{
			instance.War_LeftDefenseAttr[m] = attacker.DefenceAttr[m];
		}
		for (int n = 0; n < 4; n++)
		{
			instance.War_LeftHealthAttr[n] = attacker.HealthAttr[n];
		}
		if (num < 5)
		{
			instance.War_LeftLordID = instance.pLeftLeaderData[num].HeroID;
		}
		else
		{
			instance.War_LeftLordID = 0;
		}
		WarManager.WarCoordIndex_Left = (ushort)attacker.ArmyCoordIndex;
		instance.War_RightCastleLv = defencer.StrongholdLevel;
		instance.War_RightHeroNum = 0;
		num = 5;
		for (int num2 = 0; num2 < 5; num2++)
		{
			instance.pRightLeaderData[num2].HeroID = defencer.HeroInfo[num2].ID;
			instance.pRightLeaderData[num2].Rank = defencer.HeroInfo[num2].Rank;
			instance.pRightLeaderData[num2].Star = defencer.HeroInfo[num2].Star;
			if (instance.pRightLeaderData[num2].HeroID != 0)
			{
				DataManager dataManager2 = instance;
				dataManager2.War_RightHeroNum += 1;
			}
			if (instance.pRightLeaderData[num2].HeroID == defencer.Head)
			{
				num = num2;
			}
		}
		for (int num3 = 0; num3 < 4; num3++)
		{
			for (int num4 = 0; num4 < 4; num4++)
			{
				instance.pRightTroopForce[num3, num4] = defencer.SurviveTroop[num3 * 4 + num4] + defencer.DeadTroop[num3 * 4 + num4];
			}
		}
		for (int num5 = 0; num5 < 4; num5++)
		{
			instance.War_RightAttackAttr[num5] = defencer.AttackAttr[num5];
		}
		for (int num6 = 0; num6 < 4; num6++)
		{
			instance.War_RightDefenseAttr[num6] = defencer.DefenceAttr[num6];
		}
		for (int num7 = 0; num7 < 4; num7++)
		{
			instance.War_RightHealthAttr[num7] = defencer.HealthAttr[num7];
		}
		if (num < 5)
		{
			instance.War_RightLordID = instance.pRightLeaderData[num].HeroID;
		}
		else
		{
			instance.War_RightLordID = 0;
		}
		WarManager.WarCoordIndex_Right = (ushort)defencer.ArmyCoordIndex;
		instance.bSiege = 0;
		ushort[] array = new ushort[10];
		for (int num8 = 0; num8 < 5; num8++)
		{
			array[num8] = instance.pLeftLeaderData[num8].HeroID;
		}
		for (int num9 = 0; num9 < 5; num9++)
		{
			array[num9 + 5] = instance.pRightLeaderData[num9].HeroID;
		}
		WarManager.CheckMorale(Result, ref attacker, ref defencer);
		if (!instance.CheckHeroBattleResourceReady(HeroFightType.LegionBatte, array))
		{
			GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8350u), 255, true);
			return;
		}
		instance.DramaTriggerFlag = 0u;
		instance.WarType = 0;
		GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MapToWar);
	}

	// Token: 0x060023E0 RID: 9184 RVA: 0x0041B8A0 File Offset: 0x00419AA0
	public static void CheckMorale(CombatReport report)
	{
		DataManager instance = DataManager.Instance;
		bool flag = false;
		CombatSummaryContent summary = report.Combat.Summary;
		if ((instance.bWarAttacker || report.Combat.Result != CombatReportResultType.ECRR_COMBATVICTORY) && (!instance.bWarAttacker || report.Combat.Result != CombatReportResultType.ECRR_COMBATDEFEAT) && report.Combat.Result != CombatReportResultType.ECRR_DEFENDVICTORY)
		{
			ulong num = (ulong)(summary.DefenceTroopInjure + summary.DefenceTroopDeath);
			if (summary.WallDamage >= summary.WallDefence && num >= (ulong)summary.DefenceTroopForce)
			{
				flag = true;
			}
			num += (ulong)(summary.LoseTrapNumber + summary.SaveTrapNumber);
			instance.WarMoraleValue[0] = ((!flag) ? num : ((ulong)summary.AssaultTroopForce));
			instance.WarMoraleValue[1] = num;
			int num2 = (summary.WallDefence <= 0u || summary.WallDamage >= summary.WallDefence) ? 0 : 1;
			instance.bWarMoraleSpecialCale = false;
		}
		else
		{
			ulong num = (ulong)(summary.AssaultTroopInjure + summary.AssaultTroopDeath);
			if (num >= (ulong)summary.AssaultTroopForce)
			{
				flag = true;
			}
			instance.WarMoraleValue[0] = num;
			instance.WarMoraleValue[1] = ((!flag) ? num : ((ulong)(summary.AssaultTroopForce + summary.TrapNumber)));
			bool flag2 = summary.WallDefence > 0u && summary.WallDamage < summary.WallDefence;
			instance.bWarMoraleSpecialCale = (flag2 && num == 0UL);
		}
	}

	// Token: 0x060023E1 RID: 9185 RVA: 0x0041BA48 File Offset: 0x00419C48
	public static void CheckMorale(byte Result, ref CombatPlayerData attacker, ref CombatPlayerData defencer)
	{
		DataManager instance = DataManager.Instance;
		uint num = 0u;
		uint num2 = 0u;
		bool flag = true;
		for (int i = 0; i < 16; i++)
		{
			num += attacker.DeadTroop[i];
			num2 += defencer.DeadTroop[i];
			if (Result == 1 && defencer.SurviveTroop[i] != 0u)
			{
				flag = false;
			}
			else if (Result == 2 && attacker.SurviveTroop[i] != 0u)
			{
				flag = false;
			}
		}
		WarManager.MoraleInfo.WinnerSide = Result;
		WarManager.MoraleInfo.bWallDown = 1;
		WarManager.MoraleInfo.bEliminate = ((!flag) ? 0 : 1);
		WarManager.MoraleInfo.AssaultLostForce = num;
		WarManager.MoraleInfo.DefenceLostForce = num2;
		WarManager.CheckMorale();
	}

	// Token: 0x060023E2 RID: 9186 RVA: 0x0041BB0C File Offset: 0x00419D0C
	public static void CheckNPCMorale(CombatReport report)
	{
		DataManager instance = DataManager.Instance;
		bool flag = false;
		NPCCombatSummaryContent summary = report.NPCCombat.Summary;
		if ((instance.bWarAttacker || report.NPCCombat.Result != CombatReportResultType.ECRR_COMBATVICTORY) && (!instance.bWarAttacker || report.NPCCombat.Result != CombatReportResultType.ECRR_COMBATDEFEAT) && report.NPCCombat.Result != CombatReportResultType.ECRR_DEFENDVICTORY)
		{
			ulong num = (ulong)(report.NPCCombat.SummaryHead.DefenceTroopInjure + report.NPCCombat.SummaryHead.DefenceTroopDeath);
			if (summary.WallDamage >= summary.WallDefence && num >= (ulong)report.NPCCombat.SummaryHead.DefenceTroopForce)
			{
				flag = true;
			}
			num += (ulong)(summary.LoseTrapNumber + summary.SaveTrapNumber);
			instance.WarMoraleValue[0] = ((!flag) ? num : ((ulong)report.NPCCombat.SummaryHead.AssaultTroopForce));
			instance.WarMoraleValue[1] = num;
			int num2 = (summary.WallDefence <= 0u || summary.WallDamage >= summary.WallDefence) ? 0 : 1;
			instance.bWarMoraleSpecialCale = false;
		}
		else
		{
			ulong num = (ulong)(report.NPCCombat.SummaryHead.AssaultTroopInjure + report.NPCCombat.SummaryHead.AssaultTroopDeath);
			if (num >= (ulong)report.NPCCombat.SummaryHead.AssaultTroopForce)
			{
				flag = true;
			}
			instance.WarMoraleValue[0] = num;
			instance.WarMoraleValue[1] = ((!flag) ? num : ((ulong)(report.NPCCombat.SummaryHead.AssaultTroopForce + summary.TrapNumber)));
			bool flag2 = summary.WallDefence > 0u && summary.WallDamage < summary.WallDefence;
			instance.bWarMoraleSpecialCale = (flag2 && num == 0UL);
		}
	}

	// Token: 0x060023E3 RID: 9187 RVA: 0x0041BCFC File Offset: 0x00419EFC
	public static void CheckMorale()
	{
		DataManager instance = DataManager.Instance;
		bool flag = false;
		if (WarManager.MoraleInfo.WinnerSide == 1)
		{
			ulong num = (ulong)WarManager.MoraleInfo.DefenceLostForce;
			if (WarManager.MoraleInfo.bEliminate == 1)
			{
				flag = true;
			}
			uint num2 = 0u;
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					num2 += instance.pLeftTroopForce[i, j];
				}
			}
			instance.WarMoraleValue[0] = ((!flag) ? num : ((ulong)num2));
			instance.WarMoraleValue[1] = num;
			instance.bWarMoraleSpecialCale = false;
		}
		else if (WarManager.MoraleInfo.WinnerSide == 2)
		{
			ulong num = (ulong)WarManager.MoraleInfo.AssaultLostForce;
			if (WarManager.MoraleInfo.bEliminate == 1)
			{
				flag = true;
			}
			uint num3 = 0u;
			for (int k = 0; k < 4; k++)
			{
				for (int l = 0; l < 4; l++)
				{
					num3 += instance.pRightTroopForce[k, l];
				}
			}
			for (int m = 0; m < 3; m++)
			{
				for (int n = 0; n < 4; n++)
				{
					num3 += instance.pCastleInfo[m, n];
				}
			}
			instance.WarMoraleValue[0] = num;
			instance.WarMoraleValue[1] = ((!flag) ? num : ((ulong)num3));
			bool flag2 = WarManager.MoraleInfo.bWallDown == 0;
			instance.bWarMoraleSpecialCale = (flag2 && num == 0UL);
		}
	}

	// Token: 0x060023E4 RID: 9188 RVA: 0x0041BEB0 File Offset: 0x0041A0B0
	public static void SetupNewbieWar()
	{
		DataManager instance = DataManager.Instance;
		WarManager.NpcModeEnable = 0;
		instance.War_LordCapture = 0;
		instance.bWarAttacker = true;
		instance.War_RndSeed = 1;
		instance.War_RndGap = 1;
		UnityEngine.Random.seed = (int)instance.War_RndSeed;
		instance.pLeftTroopForce[0, 0] = 0u;
		instance.pLeftTroopForce[0, 1] = 0u;
		instance.pLeftTroopForce[0, 2] = 7000u;
		instance.pLeftTroopForce[0, 3] = 0u;
		instance.pLeftTroopForce[1, 0] = 0u;
		instance.pLeftTroopForce[1, 1] = 0u;
		instance.pLeftTroopForce[1, 2] = 150u;
		instance.pLeftTroopForce[1, 3] = 0u;
		instance.pLeftTroopForce[2, 0] = 0u;
		instance.pLeftTroopForce[2, 1] = 0u;
		instance.pLeftTroopForce[2, 2] = 150u;
		instance.pLeftTroopForce[2, 3] = 0u;
		instance.pLeftTroopForce[3, 0] = 0u;
		instance.pLeftTroopForce[3, 1] = 0u;
		instance.pLeftTroopForce[3, 2] = 50u;
		instance.pLeftTroopForce[3, 3] = 0u;
		instance.pRightTroopForce[0, 0] = 0u;
		instance.pRightTroopForce[0, 1] = 0u;
		instance.pRightTroopForce[0, 2] = 0u;
		instance.pRightTroopForce[0, 3] = 150u;
		instance.pRightTroopForce[1, 0] = 0u;
		instance.pRightTroopForce[1, 1] = 0u;
		instance.pRightTroopForce[1, 2] = 0u;
		instance.pRightTroopForce[1, 3] = 350u;
		instance.pRightTroopForce[2, 0] = 0u;
		instance.pRightTroopForce[2, 1] = 0u;
		instance.pRightTroopForce[2, 2] = 0u;
		instance.pRightTroopForce[2, 3] = 350u;
		instance.pRightTroopForce[3, 0] = 0u;
		instance.pRightTroopForce[3, 1] = 0u;
		instance.pRightTroopForce[3, 2] = 0u;
		instance.pRightTroopForce[3, 3] = 350u;
		Array.Clear(instance.pLeftLeaderData, 0, 5);
		instance.pLeftLeaderData[0] = new TroopLeaderType(1445, 1, 1);
		instance.pLeftLeaderData[1] = new TroopLeaderType(1447, 1, 1);
		instance.War_LeftHeroNum = 2;
		Array.Clear(instance.pRightLeaderData, 0, 5);
		instance.pRightLeaderData[0] = new TroopLeaderType(7, 1, 1);
		instance.War_RightHeroNum = 1;
		instance.bSiege = 1;
		instance.War_WallLevel = 18;
		instance.pCastleInfo[0, 3] = 300u;
		instance.pCastleInfo[2, 3] = 300u;
		instance.pCastleInfo[1, 0] = 0u;
		instance.pCastleInfo[1, 1] = 0u;
		instance.pCastleInfo[1, 2] = 0u;
		instance.pCastleInfo[1, 3] = 600u;
		instance.CurWallHp = 3200u;
		instance.MaxWallHp = 3200u;
		for (int i = 0; i < 4; i++)
		{
			instance.War_LeftAttackAttr[i] = 10000u;
			instance.War_LeftDefenseAttr[i] = 10000u;
			instance.War_LeftHealthAttr[i] = 10000u;
			instance.War_RightAttackAttr[i] = 10000u;
			instance.War_RightDefenseAttr[i] = 10000u;
			instance.War_RightHealthAttr[i] = 10000u;
		}
		instance.War_WallAttr.TrapAttack = 10000u;
		instance.War_WallAttr.TrapDefence = 10000u;
		instance.War_WallAttr.TrapHealth = 10000u;
		instance.War_WallAttr.WallHealth = 10000u;
		instance.War_LeftCastleLv = 1;
		instance.War_RightCastleLv = 1;
		WarManager.MoraleInfo.WinnerSide = 1;
		WarManager.MoraleInfo.bWallDown = 1;
		WarManager.MoraleInfo.bEliminate = 0;
		WarManager.MoraleInfo.AssaultLostForce = 100u;
		WarManager.MoraleInfo.DefenceLostForce = 327u;
		WarManager.CheckMorale();
		DataManager.Instance.DramaTriggerFlag = 131073u;
		WarManager.WarCoordIndex_Left = 0;
		WarManager.WarCoordIndex_Right = 0;
	}

	// Token: 0x060023E5 RID: 9189 RVA: 0x0041C2D8 File Offset: 0x0041A4D8
	public static void SetCoordTestWarData()
	{
		DataManager instance = DataManager.Instance;
		instance.DramaTriggerFlag = 0u;
		instance.War_LordCapture = 0;
		instance.bWarAttacker = true;
		instance.War_RndSeed = 1;
		instance.War_RndGap = 1;
		UnityEngine.Random.seed = (int)instance.War_RndSeed;
		WarManager.LoadLeftCoordDisplayData();
		WarManager.LoadRightCoordDisplayData();
		Array.Clear(instance.pLeftLeaderData, 0, 5);
		instance.War_LeftHeroNum = 0;
		Array.Clear(instance.pRightLeaderData, 0, 5);
		instance.War_RightHeroNum = 0;
		instance.bSiege = 0;
		for (int i = 0; i < 4; i++)
		{
			instance.War_LeftAttackAttr[i] = 10000u;
			instance.War_LeftDefenseAttr[i] = 10000u;
			instance.War_LeftHealthAttr[i] = 10000u;
			instance.War_RightAttackAttr[i] = 10000u;
			instance.War_RightDefenseAttr[i] = 10000u;
			instance.War_RightHealthAttr[i] = 10000u;
		}
		instance.War_LeftCastleLv = 1;
		instance.War_RightCastleLv = 1;
		int index = (int)(WarManager.CoordSimuIndex_Left * 3 + WarManager.TroopKindSimuIndex_Right);
		CoordResultData recordByIndex = instance.CoordResultTable.GetRecordByIndex(index);
		WarManager.MoraleInfo.WinnerSide = ((recordByIndex.Left_TotalLose >= recordByIndex.Right_TotalLose) ? 2 : 1);
		WarManager.MoraleInfo.bWallDown = 0;
		WarManager.MoraleInfo.bEliminate = 0;
		WarManager.MoraleInfo.AssaultLostForce = recordByIndex.Left_TotalLose;
		WarManager.MoraleInfo.DefenceLostForce = recordByIndex.Right_TotalLose;
		WarManager.CheckMorale();
	}

	// Token: 0x060023E6 RID: 9190 RVA: 0x0041C43C File Offset: 0x0041A63C
	public static void LoadLeftCoordDisplayData()
	{
		DataManager instance = DataManager.Instance;
		CoordDisplayData recordByIndex = instance.CoordDisplayTable.GetRecordByIndex(WarManager.CoordToSoldiers[(int)WarManager.CoordSimuIndex_Left]);
		instance.pLeftTroopForce[0, 0] = recordByIndex.Left_Infantry1;
		instance.pLeftTroopForce[0, 1] = recordByIndex.Left_Infantry2;
		instance.pLeftTroopForce[0, 2] = recordByIndex.Left_Infantry3;
		instance.pLeftTroopForce[0, 3] = recordByIndex.Left_Infantry4;
		instance.pLeftTroopForce[1, 0] = recordByIndex.Left_Archer1;
		instance.pLeftTroopForce[1, 1] = recordByIndex.Left_Archer2;
		instance.pLeftTroopForce[1, 2] = recordByIndex.Left_Archer3;
		instance.pLeftTroopForce[1, 3] = recordByIndex.Left_Archer4;
		instance.pLeftTroopForce[2, 0] = recordByIndex.Left_Cavalry1;
		instance.pLeftTroopForce[2, 1] = recordByIndex.Left_Cavalry2;
		instance.pLeftTroopForce[2, 2] = recordByIndex.Left_Cavalry3;
		instance.pLeftTroopForce[2, 3] = recordByIndex.Left_Cavalry4;
		instance.pLeftTroopForce[3, 0] = recordByIndex.Left_Catapults1;
		instance.pLeftTroopForce[3, 1] = recordByIndex.Left_Catapults2;
		instance.pLeftTroopForce[3, 2] = recordByIndex.Left_Catapults3;
		instance.pLeftTroopForce[3, 3] = recordByIndex.Left_Catapults4;
	}

	// Token: 0x060023E7 RID: 9191 RVA: 0x0041C5A8 File Offset: 0x0041A7A8
	public static void LoadRightCoordDisplayData()
	{
		if (WarManager.TroopKindSimuIndex_Right >= 3)
		{
			return;
		}
		DataManager instance = DataManager.Instance;
		CoordDisplayData recordByIndex = instance.CoordDisplayTable.GetRecordByIndex((int)WarManager.TroopKindSimuIndex_Right);
		instance.pRightTroopForce[0, 0] = recordByIndex.Right_Infantry1;
		instance.pRightTroopForce[0, 1] = recordByIndex.Right_Infantry2;
		instance.pRightTroopForce[0, 2] = recordByIndex.Right_Infantry3;
		instance.pRightTroopForce[0, 3] = recordByIndex.Right_Infantry4;
		instance.pRightTroopForce[1, 0] = recordByIndex.Right_Archer1;
		instance.pRightTroopForce[1, 1] = recordByIndex.Right_Archer2;
		instance.pRightTroopForce[1, 2] = recordByIndex.Right_Archer3;
		instance.pRightTroopForce[1, 3] = recordByIndex.Right_Archer4;
		instance.pRightTroopForce[2, 0] = recordByIndex.Right_Cavalry1;
		instance.pRightTroopForce[2, 1] = recordByIndex.Right_Cavalry2;
		instance.pRightTroopForce[2, 2] = recordByIndex.Right_Cavalry3;
		instance.pRightTroopForce[2, 3] = recordByIndex.Right_Cavalry4;
		instance.pRightTroopForce[3, 0] = recordByIndex.Right_Catapults1;
		instance.pRightTroopForce[3, 1] = recordByIndex.Right_Catapults2;
		instance.pRightTroopForce[3, 2] = recordByIndex.Right_Catapults3;
		instance.pRightTroopForce[3, 3] = recordByIndex.Right_Catapults4;
	}

	// Token: 0x060023E8 RID: 9192 RVA: 0x0041C718 File Offset: 0x0041A918
	public static bool CheckVersion(uint Version, uint Patch, bool bShowHud = true)
	{
		if (Patch != DataManager.Instance.BattlePatchNo || Patch != DataManager.Instance.BattleEngine)
		{
			if (bShowHud)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8241u), 255, true);
			}
			return false;
		}
		if (Version != DataManager.Instance.BattleSimVer)
		{
			if (bShowHud)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8241u), 255, true);
			}
			return false;
		}
		if (BSInvokeUtil.getInstance.GetVersion() != DataManager.Instance.BattleSimVer)
		{
			if (bShowHud)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1049u), 255, true);
			}
			return false;
		}
		return true;
	}

	// Token: 0x060023E9 RID: 9193 RVA: 0x0041C7F4 File Offset: 0x0041A9F4
	public static bool CheckVersion(bool bShowHud = true)
	{
		if (DataManager.Instance.BattleEngine != DataManager.Instance.BattlePatchNo)
		{
			if (bShowHud)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8241u), 255, true);
			}
			return false;
		}
		if (BSInvokeUtil.getInstance.GetVersion() != DataManager.Instance.BattleSimVer)
		{
			if (bShowHud)
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1049u), 255, true);
			}
			return false;
		}
		return true;
	}

	// Token: 0x04006D3A RID: 27962
	public const int TRT_MAX = 4;

	// Token: 0x04006D3B RID: 27963
	private const int MAX_TROOPS_PERTYPE = 4;

	// Token: 0x04006D3C RID: 27964
	public const uint REPORT_VER_OVERDUE = 8241u;

	// Token: 0x04006D3D RID: 27965
	public const uint REPORT_VER_OVERDUE_SIMUVERSION = 1049u;

	// Token: 0x04006D3E RID: 27966
	private const float SCALE_RATE = 1f;

	// Token: 0x04006D3F RID: 27967
	private const int RATE_OF_PER_FO = 2;

	// Token: 0x04006D40 RID: 27968
	private const int MAX_SOUND_KEY = 21;

	// Token: 0x04006D41 RID: 27969
	private const uint S_MOVING_DIRTY = 1u;

	// Token: 0x04006D42 RID: 27970
	private const uint S_ATTACK_DIRTY = 2u;

	// Token: 0x04006D43 RID: 27971
	private const uint S_RANGE_DIRTY = 4u;

	// Token: 0x04006D44 RID: 27972
	private const uint S_STONEHIT_DIRTY = 8u;

	// Token: 0x04006D45 RID: 27973
	public static float[,,] InitPositionLeft = new float[,,]
	{
		{
			{
				30f,
				18f
			},
			{
				30f,
				12f
			},
			{
				30f,
				24f
			},
			{
				30f,
				6f
			}
		},
		{
			{
				7f,
				18f
			},
			{
				7f,
				12f
			},
			{
				7f,
				24f
			},
			{
				7f,
				6f
			}
		},
		{
			{
				21f,
				25f
			},
			{
				21f,
				5f
			},
			{
				14f,
				25f
			},
			{
				14f,
				5f
			}
		},
		{
			{
				0f,
				18f
			},
			{
				0f,
				12f
			},
			{
				0f,
				24f
			},
			{
				0f,
				6f
			}
		}
	};

	// Token: 0x04006D46 RID: 27974
	public static float[,,] InitPositionLeft_SiegeMode = new float[,,]
	{
		{
			{
				30f,
				18f
			},
			{
				30f,
				12f
			},
			{
				30f,
				24f
			},
			{
				30f,
				6f
			}
		},
		{
			{
				7f,
				18f
			},
			{
				7f,
				12f
			},
			{
				7f,
				24f
			},
			{
				7f,
				6f
			}
		},
		{
			{
				21f,
				25f
			},
			{
				21f,
				5f
			},
			{
				14f,
				25f
			},
			{
				14f,
				5f
			}
		},
		{
			{
				0f,
				18f
			},
			{
				0f,
				12f
			},
			{
				0f,
				24f
			},
			{
				0f,
				6f
			}
		}
	};

	// Token: 0x04006D47 RID: 27975
	public static float[,,] InitPositionRight = new float[,,]
	{
		{
			{
				80f,
				18f
			},
			{
				80f,
				12f
			},
			{
				80f,
				24f
			},
			{
				80f,
				6f
			}
		},
		{
			{
				103f,
				18f
			},
			{
				103f,
				12f
			},
			{
				103f,
				24f
			},
			{
				103f,
				6f
			}
		},
		{
			{
				89f,
				25f
			},
			{
				89f,
				5f
			},
			{
				96f,
				25f
			},
			{
				96f,
				5f
			}
		},
		{
			{
				110f,
				18f
			},
			{
				110f,
				12f
			},
			{
				110f,
				24f
			},
			{
				110f,
				6f
			}
		}
	};

	// Token: 0x04006D48 RID: 27976
	public static float[,,] InitPositionRight_SiegeMode = new float[,,]
	{
		{
			{
				60f,
				18f
			},
			{
				60f,
				12f
			},
			{
				60f,
				24f
			},
			{
				60f,
				6f
			}
		},
		{
			{
				83f,
				18f
			},
			{
				83f,
				12f
			},
			{
				83f,
				24f
			},
			{
				83f,
				6f
			}
		},
		{
			{
				69f,
				25f
			},
			{
				69f,
				5f
			},
			{
				76f,
				25f
			},
			{
				76f,
				5f
			}
		},
		{
			{
				90f,
				18f
			},
			{
				90f,
				12f
			},
			{
				90f,
				24f
			},
			{
				90f,
				6f
			}
		}
	};

	// Token: 0x04006D49 RID: 27977
	public static float[,,] ActionPositionRight = new float[,,]
	{
		{
			{
				31f,
				18f
			},
			{
				31f,
				12f
			},
			{
				31f,
				24f
			},
			{
				31f,
				6f
			}
		},
		{
			{
				45f,
				18f
			},
			{
				45f,
				12f
			},
			{
				45f,
				24f
			},
			{
				45f,
				6f
			}
		},
		{
			{
				38f,
				25f
			},
			{
				38f,
				5f
			},
			{
				45f,
				25f
			},
			{
				45f,
				5f
			}
		}
	};

	// Token: 0x04006D4A RID: 27978
	private Vector3[] ArcherPosOnTower = new Vector3[]
	{
		new Vector3(53.04f, 7.77f, 20.77f),
		new Vector3(53.04f, 7.77f, 9.23f),
		new Vector3(53.04f, 4.54f, 32f),
		new Vector3(53.04f, 4.54f, -2f)
	};

	// Token: 0x04006D4B RID: 27979
	private byte[] brokenFO_Index = new byte[]
	{
		byte.MaxValue,
		0,
		1,
		1
	};

	// Token: 0x04006D4C RID: 27980
	private Vector3[] nonUseHeroPos_Left = new Vector3[]
	{
		new Vector3(-6.5f, 0f, 15f),
		new Vector3(-6.5f, 0f, 11f),
		new Vector3(-6.5f, 0f, 19f),
		new Vector3(-6.5f, 0f, 7f),
		new Vector3(-6.5f, 0f, 23f)
	};

	// Token: 0x04006D4D RID: 27981
	private Vector3[] nonUseHeroPos_Right = new Vector3[]
	{
		new Vector3(116.5f, 0f, 15f),
		new Vector3(116.5f, 0f, 11f),
		new Vector3(116.5f, 0f, 19f),
		new Vector3(116.5f, 0f, 7f),
		new Vector3(116.5f, 0f, 23f)
	};

	// Token: 0x04006D4E RID: 27982
	private Vector3[] nonUseHeroPos_Right_SiegeMode = new Vector3[]
	{
		new Vector3(96.5f, 0f, 15f),
		new Vector3(96.5f, 0f, 11f),
		new Vector3(96.5f, 0f, 19f),
		new Vector3(96.5f, 0f, 7f),
		new Vector3(96.5f, 0f, 23f)
	};

	// Token: 0x04006D4F RID: 27983
	public Vector3 CastleBloodBarOffset = new Vector3(-2f, 0f, 0f);

	// Token: 0x04006D50 RID: 27984
	public static readonly string STAGE_WAR_SAVE_KEY = "{0}_PASS_STAGE";

	// Token: 0x04006D51 RID: 27985
	public float deltaTime;

	// Token: 0x04006D52 RID: 27986
	private float fixMoveDeltaTime;

	// Token: 0x04006D53 RID: 27987
	private float canMoveDeltaTime;

	// Token: 0x04006D54 RID: 27988
	public byte attackerCount;

	// Token: 0x04006D55 RID: 27989
	public byte attackerAliveCount;

	// Token: 0x04006D56 RID: 27990
	public ArmyGroup[] attackerArmies = new ArmyGroup[16];

	// Token: 0x04006D57 RID: 27991
	public byte[,] attackerArmiesMap = new byte[4, 4];

	// Token: 0x04006D58 RID: 27992
	public ArmyGroup attackerLord;

	// Token: 0x04006D59 RID: 27993
	public Soldier attackerLordUnit;

	// Token: 0x04006D5A RID: 27994
	public byte defenserCount;

	// Token: 0x04006D5B RID: 27995
	public byte defenserAliveCount;

	// Token: 0x04006D5C RID: 27996
	public ArmyGroup[] defenserArmies = new ArmyGroup[16];

	// Token: 0x04006D5D RID: 27997
	public byte[,] defenserArmiesMap = new byte[4, 4];

	// Token: 0x04006D5E RID: 27998
	public ArmyGroup defenserLord;

	// Token: 0x04006D5F RID: 27999
	public Soldier defenserLordUnit;

	// Token: 0x04006D60 RID: 28000
	public FlyingObjectManager FOMgr;

	// Token: 0x04006D61 RID: 28001
	public Transform renderRoot;

	// Token: 0x04006D62 RID: 28002
	public int nonCatapultsCount_Left;

	// Token: 0x04006D63 RID: 28003
	public int nonCatapultsCount_Right;

	// Token: 0x04006D64 RID: 28004
	private bool bUpdateOutsideHero = true;

	// Token: 0x04006D65 RID: 28005
	private List<ushort> attackerHeroIdCache = new List<ushort>(5);

	// Token: 0x04006D66 RID: 28006
	private List<ushort> defenserHeroIdCache = new List<ushort>(5);

	// Token: 0x04006D67 RID: 28007
	private List<Lord> attackerHeroCache = new List<Lord>(5);

	// Token: 0x04006D68 RID: 28008
	private List<Lord> defenserHeroCache = new List<Lord>(5);

	// Token: 0x04006D69 RID: 28009
	public ArmyGroup[] playerSideArmies = new ArmyGroup[17];

	// Token: 0x04006D6A RID: 28010
	public ArmyGroup[] enemySideArmies = new ArmyGroup[17];

	// Token: 0x04006D6B RID: 28011
	public byte playerCount;

	// Token: 0x04006D6C RID: 28012
	public byte enemyCount;

	// Token: 0x04006D6D RID: 28013
	public byte PickListCount;

	// Token: 0x04006D6E RID: 28014
	public GameObject[] PickList = new GameObject[10];

	// Token: 0x04006D6F RID: 28015
	public Transform PickedTrans;

	// Token: 0x04006D70 RID: 28016
	public RectTransform HintTrans;

	// Token: 0x04006D71 RID: 28017
	public ushort HintStrID;

	// Token: 0x04006D72 RID: 28018
	public uint HintHeroNo;

	// Token: 0x04006D73 RID: 28019
	public float HintTimer;

	// Token: 0x04006D74 RID: 28020
	public Vector2 ScreenSize = Vector2.zero;

	// Token: 0x04006D75 RID: 28021
	private bool bFirstTimeInit = true;

	// Token: 0x04006D76 RID: 28022
	private byte NewbieWarFlag;

	// Token: 0x04006D77 RID: 28023
	public ushort attackerLordID;

	// Token: 0x04006D78 RID: 28024
	public ushort defenserLordID;

	// Token: 0x04006D79 RID: 28025
	public uint m_ui32Tcik;

	// Token: 0x04006D7A RID: 28026
	private byte[] RecvBufferLeft = new byte[1024];

	// Token: 0x04006D7B RID: 28027
	private byte[] RecvBufferRight = new byte[1024];

	// Token: 0x04006D7C RID: 28028
	private EWarResult m_WarResult;

	// Token: 0x04006D7D RID: 28029
	public WarManager.WarState m_WarState;

	// Token: 0x04006D7E RID: 28030
	public byte SubState;

	// Token: 0x04006D7F RID: 28031
	private BSInvokeUtil BSUtil;

	// Token: 0x04006D80 RID: 28032
	private ulong m_SkillWorkingList;

	// Token: 0x04006D81 RID: 28033
	private bool m_bSkillDirty;

	// Token: 0x04006D82 RID: 28034
	public WarCamera WCamera = new WarCamera();

	// Token: 0x04006D83 RID: 28035
	public byte CameraModel;

	// Token: 0x04006D84 RID: 28036
	public bool bstart;

	// Token: 0x04006D85 RID: 28037
	public Transform mainCamera = Camera.main.transform;

	// Token: 0x04006D86 RID: 28038
	private BrokenFO[][] m_BrokenFO = new BrokenFO[2][];

	// Token: 0x04006D87 RID: 28039
	private WarParticleManager particleMgr = new WarParticleManager();

	// Token: 0x04006D88 RID: 28040
	private int SiegeMode;

	// Token: 0x04006D89 RID: 28041
	private WarCastle castle;

	// Token: 0x04006D8A RID: 28042
	private byte m_GateTier;

	// Token: 0x04006D8B RID: 28043
	public uint TrapsHp;

	// Token: 0x04006D8C RID: 28044
	public uint LastTrapsHp;

	// Token: 0x04006D8D RID: 28045
	public int MoraleStep;

	// Token: 0x04006D8E RID: 28046
	public WarControlPanel controlPanel;

	// Token: 0x04006D8F RID: 28047
	private Transform LordCage;

	// Token: 0x04006D90 RID: 28048
	private int CageKey;

	// Token: 0x04006D91 RID: 28049
	private byte CageState;

	// Token: 0x04006D92 RID: 28050
	private float CageTimer;

	// Token: 0x04006D93 RID: 28051
	private Vector3 CageTargetPos = Vector3.zero;

	// Token: 0x04006D94 RID: 28052
	private AudioManager audioMgr = AudioManager.Instance;

	// Token: 0x04006D95 RID: 28053
	private uint SoundDirtyFlag;

	// Token: 0x04006D96 RID: 28054
	private float? rangeDist_Sound;

	// Token: 0x04006D97 RID: 28055
	private ArmyGroup rangeSoundParent;

	// Token: 0x04006D98 RID: 28056
	private float? stoneHitDist_Sound;

	// Token: 0x04006D99 RID: 28057
	private ArmyGroup stoneHitSoundParent;

	// Token: 0x04006D9A RID: 28058
	private float? movingDist_Sound;

	// Token: 0x04006D9B RID: 28059
	private ArmyGroup movingSoundParent;

	// Token: 0x04006D9C RID: 28060
	private float? attackDist_Sound;

	// Token: 0x04006D9D RID: 28061
	private ArmyGroup attackSoundParent;

	// Token: 0x04006D9E RID: 28062
	private byte MovingSoundKey = 21;

	// Token: 0x04006D9F RID: 28063
	private byte AttackSoundKey = 21;

	// Token: 0x04006DA0 RID: 28064
	private Transform movingSoundParentTrans;

	// Token: 0x04006DA1 RID: 28065
	private UILegBattle uiBattle;

	// Token: 0x04006DA2 RID: 28066
	private byte[] castleWeaponInfo = new byte[6];

	// Token: 0x04006DA3 RID: 28067
	private int UIUpdateFlag;

	// Token: 0x04006DA4 RID: 28068
	private EPlayerActionKind actionKind = EPlayerActionKind.DEFENDER;

	// Token: 0x04006DA5 RID: 28069
	public uint DramaTriggerFlag;

	// Token: 0x04006DA6 RID: 28070
	public bool bDramaWorking;

	// Token: 0x04006DA7 RID: 28071
	public static CombatReplayMoraleInfo MoraleInfo = default(CombatReplayMoraleInfo);

	// Token: 0x04006DA8 RID: 28072
	public static WarManager.EWarKind WarKind = WarManager.EWarKind.Normal;

	// Token: 0x04006DA9 RID: 28073
	public static ushort CoordSimuIndex_Left = 0;

	// Token: 0x04006DAA RID: 28074
	public static ushort TroopKindSimuIndex_Right = 0;

	// Token: 0x04006DAB RID: 28075
	public static ushort WarCoordIndex_Left = 0;

	// Token: 0x04006DAC RID: 28076
	public static ushort WarCoordIndex_Right = 0;

	// Token: 0x04006DAD RID: 28077
	public static byte NpcModeEnable = 0;

	// Token: 0x04006DAE RID: 28078
	public static POINT_KIND CurrentPointKind = POINT_KIND.PK_NONE;

	// Token: 0x04006DAF RID: 28079
	public static readonly int[] CoordToSoldiers = new int[]
	{
		0,
		1,
		2,
		0,
		1,
		2
	};

	// Token: 0x0200074B RID: 1867
	public enum WarState
	{
		// Token: 0x04006DB1 RID: 28081
		STOP,
		// Token: 0x04006DB2 RID: 28082
		WAITING_FOR_START,
		// Token: 0x04006DB3 RID: 28083
		RUNNING,
		// Token: 0x04006DB4 RID: 28084
		FINISHING,
		// Token: 0x04006DB5 RID: 28085
		WAITTING_FOR_VICTORY,
		// Token: 0x04006DB6 RID: 28086
		RETREAT,
		// Token: 0x04006DB7 RID: 28087
		AUTOBATTLE_WAITING,
		// Token: 0x04006DB8 RID: 28088
		CASTLE_DESTROYING,
		// Token: 0x04006DB9 RID: 28089
		CHANGING_SIEGE_MODE,
		// Token: 0x04006DBA RID: 28090
		CHANGE_COORD_MODE,
		// Token: 0x04006DBB RID: 28091
		FINISHED
	}

	// Token: 0x0200074C RID: 1868
	public enum EWarKind
	{
		// Token: 0x04006DBD RID: 28093
		Normal,
		// Token: 0x04006DBE RID: 28094
		Newbie,
		// Token: 0x04006DBF RID: 28095
		CoordTest
	}
}
