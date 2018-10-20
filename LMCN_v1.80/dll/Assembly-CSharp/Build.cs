using System;
using UnityEngine;

// Token: 0x02000350 RID: 848
public class Build : SpriteBase, IMotionUpdate
{
	// Token: 0x0600116E RID: 4462 RVA: 0x001E88BC File Offset: 0x001E6ABC
	public Build()
	{
		this.RootObj = new GameObject("MapSprite");
	}

	// Token: 0x0600116F RID: 4463 RVA: 0x001E88D4 File Offset: 0x001E6AD4
	public override GameObject InitialSprite(MapSpriteManager mapspriteManager)
	{
		this.mapspriteManager = mapspriteManager;
		this.RootObj.transform.position = Vector3.zero;
		GameObject spriteObj = mapspriteManager.GetSpriteObj();
		this.spriteRender = spriteObj.GetComponent<SpriteRenderer>();
		spriteObj = mapspriteManager.GetSpriteObj();
		this.markspriteRender = spriteObj.GetComponent<SpriteRenderer>();
		spriteObj = mapspriteManager.GetSpriteObj();
		this.LevelRender = spriteObj.GetComponent<SpriteRenderer>();
		spriteObj = mapspriteManager.GetSpriteObj();
		this.PromptRender = spriteObj.GetComponent<SpriteRenderer>();
		spriteObj = mapspriteManager.GetSpriteObj();
		this.UpgradeRender = spriteObj.GetComponent<SpriteRenderer>();
		this.spriteRender.transform.SetParent(this.RootObj.transform);
		this.markspriteRender.transform.SetParent(this.spriteRender.transform);
		this.markspriteRender.renderer.sortingOrder = -32;
		this.LevelRender.transform.SetParent(this.RootObj.transform);
		this.LevelRender.renderer.sortingOrder = -32;
		this.PromptRender.transform.SetParent(this.spriteRender.transform);
		this.PromptRender.renderer.sortingOrder = -31;
		this.PromptRender.enabled = false;
		this.UpgradeRender.transform.SetParent(this.LevelRender.transform);
		this.UpgradeRender.renderer.sortingOrder = -32;
		this.UpgradeRender.enabled = false;
		this.spriteRender.gameObject.SetActive(true);
		this.markspriteRender.gameObject.SetActive(true);
		this.markspriteRender.sprite = mapspriteManager.GetSpriteByName("build_99");
		this.markspriteRender.transform.localPosition = Vector3.zero;
		this.markspriteRender.enabled = false;
		this.UpgradeRender.sprite = mapspriteManager.GetSpriteByName("upgrade");
		this.UpgradeRender.transform.localPosition = new Vector3(0.6f, 0.27f, 0f);
		Quaternion localRotation = this.spriteRender.transform.localRotation;
		localRotation.eulerAngles = Vector3.zero;
		this.spriteRender.transform.localRotation = localRotation;
		this.OpenUIMotion = new EasingEffect();
		this.OpenUIMotion.Motion = this;
		this.SetSprite(this.Index, 0);
		return this.spriteRender.gameObject;
	}

	// Token: 0x06001170 RID: 4464 RVA: 0x001E8B34 File Offset: 0x001E6D34
	public override void Destroy()
	{
		if (this.RootObj)
		{
			if (this.spriteRender != null)
			{
				this.mapspriteManager.ReleaseSpriteObj(this.spriteRender.gameObject);
			}
			if (this.markspriteRender != null)
			{
				this.mapspriteManager.ReleaseSpriteObj(this.markspriteRender.gameObject);
			}
			if (this.UpgradeRender != null)
			{
				this.mapspriteManager.ReleaseSpriteObj(this.UpgradeRender.gameObject);
			}
			if (this.LevelRender != null)
			{
				this.mapspriteManager.ReleaseSpriteObj(this.LevelRender.gameObject);
			}
			if (this.PromptRender != null)
			{
				this.mapspriteManager.ReleaseSpriteObj(this.PromptRender.gameObject);
			}
			UnityEngine.Object.Destroy(this.RootObj);
		}
		if (this.EffectBuilding)
		{
			ParticleManager.Instance.DeSpawn(this.EffectBuilding);
			this.EffectBuilding = null;
		}
	}

	// Token: 0x06001171 RID: 4465 RVA: 0x001E8C48 File Offset: 0x001E6E48
	public override void SetSprite(ushort ID, byte Class)
	{
		BuildsData buildingData = GUIManager.Instance.BuildingData;
		if (ID >= 100)
		{
			buildingData.GetBuildSprite(ID, this.spriteRender, this.LevelRender);
			this.HashID = this.spriteRender.name.GetHashCode();
			switch ((byte)ID)
			{
			case 100:
				buildingData.ManorGride[2] = this.spriteRender.transform;
				break;
			case 101:
				buildingData.ManorGride[3] = this.spriteRender.transform;
				break;
			case 102:
				buildingData.ManorGride[4] = this.spriteRender.transform;
				break;
			case 104:
				buildingData.ManorGride[5] = this.spriteRender.transform;
				break;
			case 105:
				buildingData.ManorGride[8] = this.spriteRender.transform;
				break;
			case 106:
				buildingData.ManorGride[7] = this.spriteRender.transform;
				break;
			}
			this.Update(5);
			return;
		}
		buildingData.GetBuildSprite(ID, this.spriteRender, this.LevelRender);
		if (buildingData.AllBuildsData[(int)ID].BuildID == 12)
		{
			Vector3 localPosition = this.UpgradeRender.transform.localPosition;
			localPosition.z = -0.26f;
			this.UpgradeRender.transform.localPosition = localPosition;
		}
		if (buildingData.AllBuildsData[(int)ID].BuildID != 8)
		{
			this.markspriteRender.transform.localScale = Vector3.one * 0.5f;
		}
		else
		{
			Vector3 localPosition2 = this.LevelRender.transform.localPosition;
			localPosition2.y = 9.24f;
			this.LevelRender.transform.localPosition = localPosition2;
		}
		if (buildingData.AllBuildsData[(int)ID].BuildID == 11)
		{
			buildingData.ManorGride[6] = this.spriteRender.transform;
			buildingData.GuideParm = ID;
		}
		else if (ID == 5)
		{
			buildingData.ManorGride[1] = this.spriteRender.transform;
		}
		else if (ID == 1)
		{
			buildingData.ManorGride[0] = this.spriteRender.transform;
		}
		else if (buildingData.AllBuildsData[(int)ID].BuildID == 20)
		{
			buildingData.ManorGride[9] = this.spriteRender.transform;
		}
		this.HashID = this.spriteRender.name.GetHashCode();
		if (this.spriteRender.sprite == null)
		{
			this.spriteRender.gameObject.SetActive(false);
		}
		else
		{
			this.spriteRender.gameObject.SetActive(true);
		}
		this.Update(5);
		this.Update(8);
		this.Update(9);
	}

	// Token: 0x06001172 RID: 4466 RVA: 0x001E8F24 File Offset: 0x001E7124
	private void SetHeroEntrence()
	{
		BuildsData buildingData = GUIManager.Instance.BuildingData;
		buildingData.GetBuildSprite(13, this.spriteRender, this.LevelRender);
		this.spriteRender.transform.localPosition = new Vector3(-5.17f, 5.7f, 62f);
	}

	// Token: 0x06001173 RID: 4467 RVA: 0x001E8F74 File Offset: 0x001E7174
	public override void Update(byte meg)
	{
		DataManager instance = DataManager.Instance;
		BuildsData buildingData = GUIManager.Instance.BuildingData;
		switch (meg)
		{
		case 0:
			this.PromptRender.enabled = false;
			this.LevelRender.enabled = false;
			this.UpgradeRender.gameObject.SetActive(false);
			return;
		case 1:
			this.UpdateTime = 0f;
			MotionEffect.SetStack(this.OpenUIMotion);
			GUIManager.Instance.ShowUILock(EUILock.Normal);
			break;
		case 2:
			if (this.EffectBuilding == null)
			{
				Vector3 localPosition = this.spriteRender.transform.localPosition;
				if (buildingData.AllBuildsData[(int)this.Index].BuildID == 8)
				{
					localPosition.y = 20.5f;
					this.EffectBuilding = ParticleManager.Instance.Spawn(345, null, localPosition, 0.8f, true, false, true);
				}
				else
				{
					localPosition.y += 8.9f;
					this.EffectBuilding = ParticleManager.Instance.Spawn(293, null, localPosition, 0.8f, true, false, true);
				}
				Quaternion localRotation = this.EffectBuilding.transform.localRotation;
				localRotation.eulerAngles = new Vector3(0f, 180f, 0f);
				this.EffectBuilding.transform.localRotation = localRotation;
			}
			this.markspriteRender.enabled = false;
			buildingData.GetBuildSprite(this.Index, this.spriteRender, this.LevelRender);
			this.Update(5);
			this.markspriteRender.enabled = true;
			buildingData.GetBuildSprite(this.Index, this.spriteRender, this.LevelRender);
			break;
		case 3:
		case 4:
			if (this.EffectBuilding != null)
			{
				ParticleManager.Instance.DeSpawn(this.EffectBuilding);
				this.EffectBuilding = null;
			}
			this.markspriteRender.enabled = false;
			buildingData.GetBuildSprite(this.Index, this.spriteRender, this.LevelRender);
			if (buildingData.AllBuildsData[(int)this.Index].BuildID == 11)
			{
				buildingData.ManorGride[6] = this.spriteRender.transform;
				buildingData.GuideParm = this.Index;
				NewbieManager.CheckTroopMemory(false);
			}
			this.Update(5);
			this.Update(9);
			if (!this.UpgradeRender.gameObject.activeSelf)
			{
				this.UpgradeRender.gameObject.gameObject.SetActive(true);
			}
			break;
		case 5:
		{
			this.PromptRender.transform.localScale = Vector3.one;
			this.PromptRender.sprite = null;
			Vector3 localPosition2 = new Vector3(0f, this.spriteRender.renderer.bounds.size.y * 0.0703125f, 0f);
			if (buildingData.AllBuildsData.Length > (int)this.Index)
			{
				if (!instance.MySysSetting.bShowTrainingIdle)
				{
					ushort buildID = buildingData.AllBuildsData[(int)this.Index].BuildID;
					switch (buildID)
					{
					case 12:
						this.PromptRender.transform.localScale *= 0.8f;
						if (instance.TrapHospitalTotal > 0u)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_01");
						}
						break;
					default:
						if (buildID == 7)
						{
							if (instance.HospitalTotal > 0u)
							{
								this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_01");
							}
						}
						break;
					case 14:
						if (instance.TotalSoldier_Embassy > 0u)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_11");
						}
						break;
					case 16:
						if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 17)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_07");
						}
						else if (instance.m_CryptData.money > 0 && instance.m_CryptData.startTime + (long)((ulong)GameConstants.CryptSecends[(int)instance.m_CryptData.kind]) - instance.ServerTime <= 0L)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_06");
						}
						break;
					case 18:
						if (instance.PrisonerNum > 0)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("imprisoned_lords");
							localPosition2.Set(-0.33f, 1.38f, 0f);
						}
						break;
					case 20:
						if (PetManager.Instance.CheckPetListBuildMark())
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
						}
						break;
					case 23:
						if (PetManager.Instance.m_AllPetTrainState == PetManager.EPetTrainDataState.CanReceive)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
						}
						break;
					}
				}
				else
				{
					switch (buildingData.AllBuildsData[(int)this.Index].BuildID)
					{
					case 6:
						if (!instance.queueBarData[10].bActive && buildingData.AllBuildsData[(int)this.Index].Level > 0)
						{
							uint num = instance.AttribVal.TotalOuterSoldier + (uint)instance.SoldierTotal;
							for (int i = 0; i < 16; i++)
							{
								num += instance.mSoldier_Hospital[i];
							}
							if (num < 4200000000u)
							{
								this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_02");
							}
						}
						break;
					case 7:
						if (instance.HospitalTotal > 0u)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_01");
						}
						break;
					case 10:
						if (!instance.queueBarData[1].bActive && buildingData.AllBuildsData[(int)this.Index].Level > 0)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_04");
						}
						break;
					case 12:
						this.PromptRender.transform.localScale *= 0.8f;
						if (instance.TrapHospitalTotal > 0u)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_01");
						}
						else if (!instance.queueBarData[14].bActive && (instance.GetTechLevel(11) > 0 || instance.GetTechLevel(12) > 0 || instance.GetTechLevel(13) > 0) && instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAP_CAPACITY) > instance.TrapTotal)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_03");
						}
						break;
					case 14:
						if (instance.TotalSoldier_Embassy > 0u)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_11");
						}
						break;
					case 16:
						if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 17)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_07");
						}
						else if (instance.m_CryptData.money == 0)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_05");
						}
						else if (instance.m_CryptData.startTime + (long)((ulong)GameConstants.CryptSecends[(int)instance.m_CryptData.kind]) - instance.ServerTime <= 0L)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_06");
						}
						break;
					case 18:
						if (instance.PrisonerNum > 0)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("imprisoned_lords");
							localPosition2.Set(-0.33f, 1.38f, 0f);
						}
						break;
					case 20:
						if (PetManager.Instance.CheckPetListBuildMark())
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
						}
						break;
					case 22:
						if (!instance.queueBarData[34].bActive && buildingData.AllBuildsData[(int)this.Index].Level > 0)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_10");
						}
						break;
					case 23:
						if (PetManager.Instance.m_AllPetTrainState == PetManager.EPetTrainDataState.CanReceive)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
						}
						else if (PetManager.Instance.m_AllPetTrainState == PetManager.EPetTrainDataState.Empty && buildingData.AllBuildsData[(int)this.Index].Level > 0)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_10");
						}
						break;
					}
				}
				if (instance.MySysSetting.bShowEquipUp && !instance.queueBarData[18].bActive && buildingData.AllBuildsData[(int)this.Index].BuildID == 15)
				{
					if (LordEquipData.Instance().isEquipEvoReady)
					{
						this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
					}
				}
				else if (buildingData.AllBuildsData[(int)this.Index].BuildID == 8 && buildingData.castleSkin.CheckShowCastleSkin() && buildingData.castleSkin.CheckShowExclamation(true))
				{
					this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
					localPosition2.Set(0.64f, 2.51f, 0f);
				}
			}
			else
			{
				this.UpdateExtendBuildPrompt(this.Index, ref localPosition2);
			}
			if (this.PromptRender.sprite != null)
			{
				this.PromptRender.transform.localPosition = localPosition2;
				this.PromptRender.enabled = this.spriteRender.enabled;
			}
			else
			{
				this.PromptRender.enabled = false;
			}
			break;
		}
		case 8:
			if (instance.MySysSetting.bShowBuildUp && this.CheckUpdateRes <= 1 && buildingData.BuildingManorID == 0 && (int)this.Index < buildingData.AllBuildsData.Length && buildingData.AllBuildsData[(int)this.Index].BuildID > 0 && buildingData.AllBuildsData[(int)this.Index].Level < buildingData.BuildlevelupCheck[(int)buildingData.AllBuildsData[(int)this.Index].BuildID])
			{
				this.UpgradeRender.enabled = true;
			}
			else
			{
				this.UpgradeRender.enabled = false;
			}
			break;
		case 9:
			if (!instance.MySysSetting.bShowBuildUp || buildingData.AllBuildsData[(int)this.Index].BuildID == 0 || buildingData.BuildingManorID > 0 || ((int)this.Index < buildingData.AllBuildsData.Length && buildingData.AllBuildsData[(int)this.Index].BuildID == 16 && buildingData.AllBuildsData[(int)this.Index].Level == 9))
			{
				this.UpgradeRender.enabled = false;
			}
			else
			{
				if (buildingData.AllBuildsData[(int)this.Index].Level < 25)
				{
					this.CheckUpdateRes = buildingData.CheckLevelupRule(buildingData.AllBuildsData[(int)this.Index].BuildID, buildingData.AllBuildsData[(int)this.Index].Level + 1);
				}
				else
				{
					this.CheckUpdateRes = 2;
				}
				if (this.CheckUpdateRes == 0)
				{
					this.UpgradeRender.enabled = true;
				}
				else
				{
					this.UpgradeRender.enabled = false;
				}
			}
			break;
		case 12:
			this.SetSprite(this.Index, 0);
			break;
		}
		if ((int)this.Index < buildingData.AllBuildsData.Length && buildingData.AllBuildsData[(int)this.Index].BuildID > 0)
		{
			this.LevelRender.enabled = !this.markspriteRender.enabled;
		}
	}

	// Token: 0x06001174 RID: 4468 RVA: 0x001E9CD8 File Offset: 0x001E7ED8
	private void UpdateExtendBuildPrompt(ushort Index, ref Vector3 position)
	{
		DataManager instance = DataManager.Instance;
		switch ((byte)Index)
		{
		case 100:
			if (DataManager.StageDataController.StageRecord[2] <= 1)
			{
				this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_07");
			}
			else if (instance.MySysSetting.bShowTrainingIdle && instance.RoleAttr.Morale >= instance.HeroMaxMorale)
			{
				this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_08");
			}
			position.Set(0f, 2.34f, 0f);
			break;
		case 101:
			position.x = 0.89f;
			position.y = 2.11f;
			if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 10)
			{
				this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_07");
			}
			else
			{
				ActivityManager instance2 = ActivityManager.Instance;
				ArenaManager instance3 = ArenaManager.Instance;
				if (instance2.IsInKvK(0, false) || instance3.CheckArenaClose() != 0)
				{
					if (instance.MySysSetting.bShowArena)
					{
						if (instance.CheckPrizeFlag(20))
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_12");
						}
						else if (instance3.m_ArenaNewReportNum > 0 || instance3.m_ArenaCrystalPrize > 0u)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
						}
					}
				}
				else if (instance.MySysSetting.bShowArena)
				{
					if (instance.CheckPrizeFlag(20))
					{
						this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_12");
					}
					else if (instance3.m_ArenaTodayChallenge < 5 || instance3.m_ArenaNewReportNum > 0 || instance3.m_ArenaCrystalPrize > 0u)
					{
						this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
					}
				}
			}
			break;
		case 102:
			if (DataManager.StageDataController.StageRecord[2] < 3)
			{
				this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_07");
			}
			else if (instance.MySysSetting.bShowTrainingIdle && DataManager.Instance.AttribVal.TotalDugoutSoldier == 0u)
			{
				this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_10");
			}
			break;
		case 103:
			if (AmbushManager.Instance.GetMaxTroop() > 0u)
			{
				this.spriteRender.enabled = true;
			}
			else
			{
				this.spriteRender.enabled = false;
			}
			break;
		case 104:
			if (GUIManager.Instance.BuildingData.GetBuildData(8, 0).Level < 13)
			{
				this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_07");
			}
			else if (instance.MySysSetting.bShowTrainingIdle && MerchantmanManager.Instance.TradeStatus < 15)
			{
				this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
			}
			break;
		case 105:
		{
			GUIManager instance4 = GUIManager.Instance;
			if (instance4.BuildingData.bHideLaboryPromptLock == 0 && (DataManager.Instance.RoleAttr.Guide & 16777216UL) == 0UL && instance4.BoxID[0] == 0)
			{
				this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_07");
			}
			else if (instance.MySysSetting.bShowTrainingIdle)
			{
				bool flag = true;
				for (int i = 0; i < instance4.BoxID.Length; i++)
				{
					if (instance4.BoxTime[i] > 0L & instance4.BoxID[i] > 0)
					{
						flag = false;
						if (instance4.BoxTime[i] < instance.ServerTime)
						{
							this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
							break;
						}
					}
				}
				if (flag)
				{
					this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_10");
				}
			}
			break;
		}
		case 106:
			position.x = 0.47f;
			position.y = 1.35f;
			if (GamblingManager.Instance.IsDailyFreeScardStar(UIBattle_Gambling.eMode.Normal) || GamblingManager.Instance.IsDailyFreeScardStar(UIBattle_Gambling.eMode.Turbo))
			{
				this.PromptRender.sprite = this.mapspriteManager.GetSpriteByName("prompt_09");
			}
			break;
		}
	}

	// Token: 0x06001175 RID: 4469 RVA: 0x001EA1A4 File Offset: 0x001E83A4
	public bool UpdateRun(float delta)
	{
		if (this.UpdateTime > 0.3f)
		{
			GUIManager.Instance.BuildingData.NotifyOpenUI(this.Index);
			this.spriteRender.color = Color.black;
			GUIManager.Instance.BuildingData.UpdateBuildState(7, 1);
			GUIManager.Instance.HideUILock(EUILock.Normal);
			return false;
		}
		if (this.UpdateTime > 0.5f)
		{
			return false;
		}
		float num = HUDMessageMgr.Quintic(this.UpdateTime, 0.1f, 0.2f, 0.3f);
		this.spriteRender.color = new Color(num, num, num);
		this.UpdateTime += Time.deltaTime;
		return true;
	}

	// Token: 0x040037A5 RID: 14245
	private EasingEffect OpenUIMotion;

	// Token: 0x040037A6 RID: 14246
	private GameObject RootObj;

	// Token: 0x040037A7 RID: 14247
	private GameObject EffectBuilding;

	// Token: 0x040037A8 RID: 14248
	public SpriteRenderer spriteRender;

	// Token: 0x040037A9 RID: 14249
	public SpriteRenderer markspriteRender;

	// Token: 0x040037AA RID: 14250
	public SpriteRenderer LevelRender;

	// Token: 0x040037AB RID: 14251
	public SpriteRenderer PromptRender;

	// Token: 0x040037AC RID: 14252
	public SpriteRenderer UpgradeRender;

	// Token: 0x040037AD RID: 14253
	private float UpdateTime;

	// Token: 0x040037AE RID: 14254
	private byte CheckUpdateRes;
}
