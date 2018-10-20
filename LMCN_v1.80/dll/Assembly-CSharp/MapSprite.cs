using System;
using UnityEngine;

// Token: 0x02000355 RID: 853
public class MapSprite : IMotionUpdate
{
	// Token: 0x06001185 RID: 4485 RVA: 0x001EB188 File Offset: 0x001E9388
	public MapSprite(WorldMode Type, ushort SpriteNum = 1)
	{
		this.Type = Type;
		if (SpriteNum == 0)
		{
			return;
		}
		GUIManager.Instance.InitMapSprite();
		if (this.Type == WorldMode.Wild)
		{
			this.MapSpriteRoot = new GameObject("Build");
			SpriteNum = (ushort)((byte)GUIManager.Instance.BuildingData.GetCurrentChapterBuildCount());
			this.mapspriteManager = new MapSpriteManager(this.Type, (SpriteNum + 7) * 5);
			this.GuildPoint = new GameObject("ManorGuild", new Type[]
			{
				typeof(SpriteRenderer)
			}).GetComponent<SpriteRenderer>();
			this.GuildPoint.sprite = this.mapspriteManager.GetSpriteByName("arrow");
			this.GuildPoint.material = this.mapspriteManager.SpriteMaterial;
			this.GuildPoint.color = Color.black;
			this.GuildPoint.sortingOrder = -1;
			this.GuildPoint.transform.localScale *= 10f;
			this.DiamonAct = new GameObject("ManorDiamon", new Type[]
			{
				typeof(SpriteRenderer)
			}).GetComponent<SpriteRenderer>();
			this.DiamonAct.sprite = this.mapspriteManager.GetSpriteByName("prompt_06");
			this.DiamonAct.material = this.mapspriteManager.SpriteMaterial;
			this.DiamonAct.color = Color.black;
			this.DiamonAct.sortingOrder = -1;
			this.DiamonAct.transform.localScale *= 10f;
			this.DiamonAct.transform.localPosition = new Vector3(-9.92f, 6.41f, 126.48f);
			Quaternion localRotation = this.GuildPoint.transform.localRotation;
			localRotation.eulerAngles = GUIManager.Instance.BuildingData.BuildRot;
			this.GuildPoint.transform.localRotation = localRotation;
			this.GuildPoint.enabled = false;
			this.DiamonAct.transform.localRotation = localRotation;
			this.DiamonAct.enabled = false;
			this.HeroBuild = new Build();
			this.ArenaBuild = new Build();
			this.DugoutBuild = new Build();
			this.Fortress = new Build();
			this.BlackMarket = new Build();
			this.Laboratory = new Build();
			this.Carsino = new Build();
			this.SpriteGameObject = new GameObject[(int)(SpriteNum + 7)];
			this.StageLock = new GameObject[DataManager.StageDataController.CorpsStageTable.TableCount];
			this.StageLockNameCode = new int[this.StageLock.Length];
		}
		else
		{
			this.MapSpriteRoot = new GameObject("Stage");
			this.mapspriteManager = new MapSpriteManager(this.Type, SpriteNum * 5);
			this.mapspriteManager.InitTextObj(SpriteNum);
			this.SpriteGameObject = new GameObject[(int)SpriteNum];
		}
		GUIManager.Instance.BuildingData.mapspriteManager = this.mapspriteManager;
		this.BuildSpritesMax = SpriteNum;
		this.Builds = new SpriteBase[(int)this.BuildSpritesMax];
		this.Initial();
		this.BuildMotion = new EasingEffect();
		this.BuildMotion.Motion = this;
	}

	// Token: 0x06001186 RID: 4486 RVA: 0x001EB4E4 File Offset: 0x001E96E4
	public void Initial()
	{
		bool flag = DataManager.StageDataController._stageMode == StageMode.Dare;
		if (flag && this.Type == WorldMode.OpenUp)
		{
			this.mapspriteManager.LoadChallegeFrame();
		}
		byte b = 0;
		while ((ushort)b < this.BuildSpritesMax)
		{
			if (this.Type == WorldMode.Wild)
			{
				if (this.Builds[(int)b] == null)
				{
					this.Builds[(int)b] = new Build();
				}
				BuildManorData recordByIndex = DataManager.Instance.BuildManorData.GetRecordByIndex((int)GUIManager.Instance.BuildingData.GetMonorIndex((int)b));
				this.Builds[(int)b].Index = recordByIndex.ID;
				this.SpriteGameObject[(int)b] = this.Builds[(int)b].InitialSprite(this.mapspriteManager);
				this.SpriteGameObject[(int)b].transform.parent.SetParent(this.MapSpriteRoot.transform);
				BuildsData buildingData = GUIManager.Instance.BuildingData;
				if (buildingData.AllBuildsData[(int)recordByIndex.ID].BuildID == 18)
				{
					Build build = this.Builds[(int)b] as Build;
					this.JailNoticeIcon = build.spriteRender.gameObject.GetComponent<JailBuildNotice>();
					if (this.JailNoticeIcon == null)
					{
						this.JailNoticeIcon = build.spriteRender.gameObject.AddComponent<JailBuildNotice>();
						this.JailNoticeIcon.Init(this.mapspriteManager);
					}
				}
			}
			else
			{
				if (this.Builds[(int)b] == null)
				{
					if (flag)
					{
						this.Builds[(int)b] = new ChallengeCampaign();
					}
					else
					{
						this.Builds[(int)b] = new Campaign();
					}
				}
				this.Builds[(int)b].Index = (ushort)((b + 1) * 3);
				this.SpriteGameObject[(int)b] = this.Builds[(int)b].InitialSprite(this.mapspriteManager);
				this.SpriteGameObject[(int)b].transform.SetParent(this.MapSpriteRoot.transform);
			}
			b += 1;
		}
		if (this.Type == WorldMode.Wild)
		{
			this.HeroBuild.Index = 100;
			this.ArenaBuild.Index = 101;
			this.DugoutBuild.Index = 102;
			this.Fortress.Index = 103;
			this.BlackMarket.Index = 104;
			this.Laboratory.Index = 105;
			this.Carsino.Index = 106;
			this.SpriteGameObject[this.SpriteGameObject.Length - 7] = this.Carsino.InitialSprite(this.mapspriteManager);
			this.SpriteGameObject[this.SpriteGameObject.Length - 6] = this.Laboratory.InitialSprite(this.mapspriteManager);
			this.SpriteGameObject[this.SpriteGameObject.Length - 5] = this.BlackMarket.InitialSprite(this.mapspriteManager);
			this.SpriteGameObject[this.SpriteGameObject.Length - 4] = this.Fortress.InitialSprite(this.mapspriteManager);
			this.SpriteGameObject[this.SpriteGameObject.Length - 3] = this.DugoutBuild.InitialSprite(this.mapspriteManager);
			this.SpriteGameObject[this.SpriteGameObject.Length - 2] = this.HeroBuild.InitialSprite(this.mapspriteManager);
			this.SpriteGameObject[this.SpriteGameObject.Length - 1] = this.ArenaBuild.InitialSprite(this.mapspriteManager);
			if (GUIManager.Instance.BuildingData.BuildingManorID > 0)
			{
				this.UpdateMapSprite(GUIManager.Instance.BuildingData.BuildingManorID, 2);
			}
			this.InitLock();
			this.UpdateDiamon();
		}
		this.GuideManorID = 0;
		this.GuideBuildID = 0;
	}

	// Token: 0x06001187 RID: 4487 RVA: 0x001EB878 File Offset: 0x001E9A78
	public void InitLock()
	{
		StageManager stageDataController = DataManager.StageDataController;
		CString cstring = StringManager.Instance.StaticString1024();
		Vector3 localScale = Vector3.one * 12.5f;
		Vector3 eulerAngles = new Vector3(45f, 185f, 3f);
		for (int i = 0; i < this.StageLock.Length; i++)
		{
			if (i > (int)stageDataController.StageRecord[2])
			{
				cstring.ClearString();
				cstring.IntToFormat((long)(i + 1), 1, false);
				cstring.AppendFormat("Lock_{0}");
				CorpsStage recordByKey = DataManager.StageDataController.CorpsStageTable.GetRecordByKey((ushort)(1 + i));
				this.StageLock[i] = new GameObject(cstring.ToString());
				this.StageLockNameCode[i] = this.StageLock[i].name.GetHashCode();
				SpriteRenderer spriteRenderer = this.StageLock[i].AddComponent<SpriteRenderer>();
				spriteRenderer.sprite = this.mapspriteManager.GetSpriteByName("lock");
				spriteRenderer.material = GUIManager.Instance.MapSpriteMaterial;
				spriteRenderer.sortingOrder = -1;
				Transform transform = this.StageLock[i].transform;
				transform.position = GameConstants.WordToVector3(recordByKey.StagePos.X, recordByKey.StagePos.Y, recordByKey.StagePos.Z, -100, 0.01f);
				transform.localScale = localScale;
				spriteRenderer.color = Color.black;
				Quaternion rotation = transform.rotation;
				rotation.eulerAngles = eulerAngles;
				transform.rotation = rotation;
				transform.SetParent(this.MapSpriteRoot.transform);
			}
		}
	}

	// Token: 0x06001188 RID: 4488 RVA: 0x001EBA18 File Offset: 0x001E9C18
	public void SetSpritePosition(ushort id, Vector3 pos)
	{
		if ((int)id >= this.SpriteGameObject.Length)
		{
			return;
		}
		this.SpriteGameObject[(int)id].transform.position = pos;
	}

	// Token: 0x06001189 RID: 4489 RVA: 0x001EBA48 File Offset: 0x001E9C48
	public bool NotifyOpenUI(int key)
	{
		AudioManager.Instance.PlayUISFX(UIKind.Normal);
		if (this.HeroBuild.HashID == key)
		{
			if (DataManager.StageDataController.CheckStageModle())
			{
				GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Hero);
				this.HeroBuild.Update(1);
				this.GuildPoint.enabled = false;
			}
			else
			{
				GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8350u), 255, true);
			}
		}
		else if (this.ArenaBuild.HashID == key)
		{
			this.ArenaBuild.Update(1);
			this.GuildPoint.enabled = false;
		}
		else if (this.DugoutBuild.HashID == key)
		{
			this.DugoutBuild.Update(1);
			this.GuildPoint.enabled = false;
		}
		else if (this.Fortress.HashID == key)
		{
			this.Fortress.Update(1);
			this.GuildPoint.enabled = false;
		}
		else if (this.BlackMarket.HashID == key)
		{
			this.BlackMarket.Update(1);
			this.GuildPoint.enabled = false;
		}
		else if (this.Laboratory.HashID == key)
		{
			this.Laboratory.Update(1);
			this.GuildPoint.enabled = false;
		}
		else if (this.Carsino.HashID == key)
		{
			this.Carsino.Update(1);
			this.GuildPoint.enabled = false;
		}
		else
		{
			ushort num = 0;
			while ((int)num < this.Builds.Length)
			{
				if (this.Builds[(int)num].HashID == key)
				{
					if (this.MotionIndex != (int)num)
					{
						this.Builds[(int)num].Update(1);
						this.GuildPoint.enabled = false;
					}
					return true;
				}
				num += 1;
			}
			if (this.StageLock != null)
			{
				ushort num2 = 0;
				while ((int)num2 < this.StageLock.Length)
				{
					if (this.StageLockNameCode[(int)num2] == key)
					{
						if (DataManager.StageDataController.StageRecord[2] < num2)
						{
							GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7374u), 255, true);
							DataManager.StageDataController.resetStageMode(StageMode.Corps);
							DataManager.msgBuffer[0] = 7;
							GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						}
						return true;
					}
					num2 += 1;
				}
			}
		}
		return false;
	}

	// Token: 0x0600118A RID: 4490 RVA: 0x001EBCCC File Offset: 0x001E9ECC
	public void Destroy()
	{
		for (ushort num = 0; num < this.BuildSpritesMax; num += 1)
		{
			this.Builds[(int)num].Destroy();
			this.Builds[(int)num] = null;
		}
		if (this.mapspriteManager != null)
		{
			if (this.GuildPoint != null)
			{
				this.mapspriteManager.ReleaseSpriteObj(this.GuildPoint.gameObject);
			}
			this.mapspriteManager.Destory();
		}
		this.mapspriteManager = null;
		if (this.EffectBuildComplete != null)
		{
			ParticleManager.Instance.DeSpawn(this.EffectBuildComplete);
			this.EffectBuildComplete = null;
		}
		if (this.MainTownLevelup != null)
		{
			ParticleManager.Instance.DeSpawn(this.MainTownLevelup);
			this.MainTownLevelup = null;
		}
		if (this.MainTownLevelupRing != null)
		{
			ParticleManager.Instance.DeSpawn(this.MainTownLevelupRing);
			this.MainTownLevelupRing = null;
		}
		this.MotionTransform = null;
		if (this.HeroBuild != null)
		{
			this.HeroBuild.Destroy();
		}
		this.HeroBuild = null;
		if (this.ArenaBuild != null)
		{
			this.ArenaBuild.Destroy();
		}
		this.ArenaBuild = null;
		if (this.DugoutBuild != null)
		{
			this.DugoutBuild.Destroy();
		}
		this.DugoutBuild = null;
		if (this.Fortress != null)
		{
			this.Fortress.Destroy();
		}
		this.Fortress = null;
		if (this.BlackMarket != null)
		{
			this.BlackMarket.Destroy();
		}
		this.BlackMarket = null;
		if (this.MapSpriteRoot != null)
		{
			UnityEngine.Object.Destroy(this.MapSpriteRoot);
		}
		this.MapSpriteRoot = null;
		if (this.Laboratory != null)
		{
			this.Laboratory.Destroy();
		}
		this.Laboratory = null;
		if (this.Carsino != null)
		{
			this.Carsino.Destroy();
		}
		this.Carsino = null;
		if (this.GuildPoint != null)
		{
			UnityEngine.Object.Destroy(this.GuildPoint.gameObject);
		}
		this.GuildPoint = null;
		if (this.EffectGo != null)
		{
			ParticleManager.Instance.DeSpawn(this.EffectGo);
		}
		this.EffectGo = null;
		if (this.DiamonAct != null)
		{
			UnityEngine.Object.Destroy(this.DiamonAct.gameObject);
		}
		this.DiamonAct = null;
		GUIManager.Instance.BuildingData.castleSkin.Destroy();
	}

	// Token: 0x0600118B RID: 4491 RVA: 0x001EBF48 File Offset: 0x001EA148
	public void Hide()
	{
		for (ushort num = 0; num < this.BuildSpritesMax; num += 1)
		{
			this.Builds[(int)num].Hide();
		}
	}

	// Token: 0x0600118C RID: 4492 RVA: 0x001EBF7C File Offset: 0x001EA17C
	public void ShowManorGuild(ushort ManorID)
	{
		if (this.GuideManorID == ManorID && this.GuideBuildID == GUIManager.Instance.BuildingData.AllBuildsData[(int)ManorID].BuildID)
		{
			this.GuildPoint.enabled = true;
			return;
		}
		this.GuideManorID = ManorID;
		this.GuideBuildID = GUIManager.Instance.BuildingData.AllBuildsData[(int)ManorID].BuildID;
		BuildManorData recordByKey = DataManager.Instance.BuildManorData.GetRecordByKey(ManorID);
		float x;
		float num;
		float z;
		if (GUIManager.Instance.BuildingData.AllBuildsData[(int)ManorID].BuildID == 0)
		{
			x = ((recordByKey.mPosionX <= 30000) ? ((float)recordByKey.mPosionX) : ((float)recordByKey.mPosionX - 65535f)) * 0.01f;
			num = ((recordByKey.mPosionY <= 32768) ? ((float)recordByKey.mPosionY) : ((float)recordByKey.mPosionY - 65535f)) * 0.01f;
			z = ((recordByKey.mPosionZ <= 32768) ? ((float)recordByKey.mPosionZ) : ((float)recordByKey.mPosionZ - 65535f)) * 0.01f;
		}
		else
		{
			x = ((recordByKey.bPosionX <= 30000) ? ((float)recordByKey.bPosionX) : ((float)recordByKey.bPosionX - 65535f)) * 0.01f;
			num = ((recordByKey.bPosionY <= 32768) ? ((float)recordByKey.bPosionY) : ((float)recordByKey.bPosionY - 65535f)) * 0.01f;
			z = ((recordByKey.bPosionZ <= 32768) ? ((float)recordByKey.bPosionZ) : ((float)recordByKey.bPosionZ - 65535f)) * 0.01f;
		}
		if (GUIManager.Instance.BuildingData.AllBuildsData[(int)ManorID].BuildID == 8)
		{
			this.GuildPosY = 35f;
			num = 18f;
		}
		else if (GUIManager.Instance.BuildingData.AllBuildsData[(int)ManorID].BuildID == 0)
		{
			num = (this.GuildPosY = num + 6f);
		}
		else
		{
			num = (this.GuildPosY = num + (GUIManager.Instance.BuildingData.GetBuildSprite(this.GuideBuildID, GUIManager.Instance.BuildingData.AllBuildsData[(int)ManorID].Level).rect.height - 32f) / 8f);
		}
		this.GuildPoint.transform.position = new Vector3(x, num, z);
		this.GuildPoint.enabled = true;
	}

	// Token: 0x0600118D RID: 4493 RVA: 0x001EC238 File Offset: 0x001EA438
	public void UpdateGuildPos()
	{
		if (this.GuildPoint.enabled)
		{
			Transform transform = this.GuildPoint.transform;
			float d = Time.deltaTime * this.GuildSpeed;
			transform.position += Vector3.up * d;
			if (transform.position.y > this.GuildPosY + 8f)
			{
				Vector3 position = transform.position;
				position.y = this.GuildPosY + 8f;
				transform.position = position;
				this.GuildSpeed *= -1f;
			}
			if (transform.position.y < this.GuildPosY)
			{
				Vector3 position2 = transform.position;
				position2.y = this.GuildPosY;
				transform.position = position2;
				this.GuildSpeed *= -1f;
			}
		}
		if (this.MainTownDelay >= 0f)
		{
			this.MainTownDelay -= Time.deltaTime;
			if (this.MainTownDelay < 0f)
			{
				if (this.MainTownLevelupRing != null)
				{
					ParticleManager.Instance.DeSpawn(this.MainTownLevelupRing);
				}
				Vector3 position3 = new Vector3(-47.6f, 45f, 2.8f);
				this.MainTownLevelupRing = ParticleManager.Instance.Spawn(359, null, position3, 1f, true, false, true);
			}
		}
		this.UpdatePrisonerTime();
	}

	// Token: 0x0600118E RID: 4494 RVA: 0x001EC3B8 File Offset: 0x001EA5B8
	public void UpdatePrisonerTime()
	{
		this.UpdateTime += Time.deltaTime;
		if (this.JailNoticeIcon != null && this.UpdateTime >= 1f)
		{
			this.UpdateTime = 0f;
			this.JailNoticeIcon.UpdateTime();
		}
	}

	// Token: 0x0600118F RID: 4495 RVA: 0x001EC410 File Offset: 0x001EA610
	public void UpdateDiamon()
	{
		if (GUIManager.Instance.NPCCityBonusTime > 0L)
		{
			this.DiamonAct.enabled = true;
		}
		else
		{
			this.DiamonAct.enabled = false;
		}
	}

	// Token: 0x06001190 RID: 4496 RVA: 0x001EC44C File Offset: 0x001EA64C
	public void UpdateMapSprite(ushort ID, byte State)
	{
		if (ID == 0)
		{
			return;
		}
		int num = (int)ID;
		if (this.Type == WorldMode.Wild)
		{
			switch (State)
			{
			case 5:
				if (this.HeroBuild != null)
				{
					this.HeroBuild.Update(State);
				}
				if (this.ArenaBuild != null)
				{
					this.ArenaBuild.Update(State);
				}
				if (this.DugoutBuild != null)
				{
					this.DugoutBuild.Update(State);
				}
				if (this.Fortress != null)
				{
					this.Fortress.Update(State);
				}
				if (this.BlackMarket != null)
				{
					this.BlackMarket.Update(State);
				}
				if (this.Laboratory != null)
				{
					this.Laboratory.Update(State);
				}
				if (this.Carsino != null)
				{
					this.Carsino.Update(State);
				}
				this.UpdateDiamon();
				for (int i = this.Builds.Length; i > 0; i--)
				{
					this.Builds[i - 1].Update(State);
				}
				return;
			case 6:
				this.Initial();
				return;
			case 7:
				if (this.EffectBuildComplete != null)
				{
					ParticleManager.Instance.DeSpawn(this.EffectBuildComplete);
					this.EffectBuildComplete = null;
				}
				return;
			case 8:
			case 9:
				for (int j = this.Builds.Length; j > 0; j--)
				{
					this.Builds[j - 1].Update(State);
				}
				return;
			case 10:
				if (this.GuildPoint != null)
				{
					this.GuildPoint.enabled = false;
				}
				return;
			case 11:
				if (this.JailNoticeIcon != null)
				{
					this.JailNoticeIcon.UpdateData();
				}
				return;
			default:
			{
				if (GUIManager.Instance.BuildingData.AllBuildsData.Length <= (int)ID)
				{
					return;
				}
				for (int k = 0; k < this.Builds.Length; k++)
				{
					if (this.Builds[k].Index == ID)
					{
						num = k;
					}
				}
				this.UpdateIndex = (ushort)num;
				BuildsData buildingData = GUIManager.Instance.BuildingData;
				byte level = buildingData.AllBuildsData[(int)ID].Level;
				if (this.MotionTransform != null)
				{
					Vector3 source = this.Source;
					if (this.Change < 0f)
					{
						source.y = this.Source.y;
					}
					else
					{
						source.y = this.Source.y + this.Change;
					}
					this.MotionTransform.position = source;
					this.Builds[this.MotionIndex].Update(3);
					this.MotionTransform = null;
					this.MotionIndex = -1;
					MotionEffect.RemoveStack(this.EasingIndex);
				}
				if (buildingData.AllBuildsData[(int)ID].BuildID == 16 && buildingData.BuildingManorID != this.Builds[num].Index && State == 3 && (level == 1 || level == 3 || level == 6 || level == 9))
				{
					this.Builds[num].Update(0);
					this.MotionTransform = this.SpriteGameObject[num].transform;
					this.Source = this.MotionTransform.position;
					this.Change = -32f;
					this.DeltaTime = 0f;
					this.TotalTime = 2f;
					this.WaitTime = 1f;
					this.DownUp = 1;
					this.MotionIndex = num;
					this.EasingIndex = MotionEffect.SetStack(this.BuildMotion);
				}
				else if (buildingData.BuildingManorID != this.Builds[num].Index && State == 3 && (level == 1 || level == 9 || level == 17 || level == 25))
				{
					this.Builds[num].Update(0);
					this.MotionTransform = this.SpriteGameObject[num].transform;
					this.Source = this.MotionTransform.position;
					this.Change = -32f;
					this.DeltaTime = 0f;
					this.TotalTime = 2f;
					this.WaitTime = 1f;
					this.DownUp = 1;
					this.MotionIndex = num;
					this.EasingIndex = MotionEffect.SetStack(this.BuildMotion);
				}
				else
				{
					if (State == 3 && buildingData.BuildingManorID != this.Builds[num].Index)
					{
						this.ShowBuildCompleteEffect();
					}
					this.Builds[num].Update(State);
					this.GuideManorID = 0;
					this.GuideBuildID = 0;
					this.UpdateMapSprite(255, 9);
				}
				this.HideNoticeIcon();
				break;
			}
			}
		}
		else
		{
			num--;
			this.Builds[num].Update(State);
			if (State == 1)
			{
				this.MotionTransform = this.SpriteGameObject[num].transform;
				this.Source.Set(1f, 1f, 1f);
				this.Change = 4.2f;
				this.DeltaTime = 0f;
				this.TotalTime = 0.25f;
				this.SpriteEffectIdx = 2;
			}
		}
	}

	// Token: 0x06001191 RID: 4497 RVA: 0x001EC974 File Offset: 0x001EAB74
	public void UpdateSpriteFrame(int index)
	{
		this.Builds[index].UpdateSpriteFrame();
	}

	// Token: 0x06001192 RID: 4498 RVA: 0x001EC984 File Offset: 0x001EAB84
	public void ShowChallegeEffect(Transform trans)
	{
		if (this.EffectGo != null)
		{
			ParticleManager.Instance.DeSpawn(this.EffectGo);
			this.EffectGo = null;
		}
		this.EffectGo = ParticleManager.Instance.Spawn(294, null, trans.localPosition, 1f, true, false, true);
		Quaternion localRotation = this.EffectGo.transform.localRotation;
		localRotation.eulerAngles = new Vector3(0f, 180f, 0f);
		this.EffectGo.transform.localRotation = localRotation;
		AudioManager.Instance.PlayMP3SFX(41036, 0f);
	}

	// Token: 0x06001193 RID: 4499 RVA: 0x001ECA30 File Offset: 0x001EAC30
	private void MainTownLevelEffect()
	{
		Vector3 localPosition = this.SpriteGameObject[0].transform.localPosition;
		localPosition.y += 40f;
		if (this.MainTownLevelup != null)
		{
			ParticleManager.Instance.DeSpawn(this.MainTownLevelup);
		}
		this.MainTownDelay = 10f;
		this.MainTownLevelup = ParticleManager.Instance.Spawn(358, null, localPosition, 2f, true, false, true);
		Quaternion localRotation = this.MainTownLevelup.transform.localRotation;
		localRotation.eulerAngles = new Vector3(0f, 180f, 0f);
		this.MainTownLevelup.transform.localRotation = localRotation;
	}

	// Token: 0x06001194 RID: 4500 RVA: 0x001ECAEC File Offset: 0x001EACEC
	private void ShowBuildCompleteEffect()
	{
		Vector3 localPosition = this.SpriteGameObject[(int)this.UpdateIndex].transform.localPosition;
		BuildsData buildingData = GUIManager.Instance.BuildingData;
		if (this.EffectBuildComplete != null)
		{
			ParticleManager.Instance.DeSpawn(this.EffectBuildComplete);
			this.EffectBuildComplete = null;
		}
		if (buildingData.ImmEffect == 1)
		{
			buildingData.ImmEffect = 0;
			if (buildingData.AllBuildsData[(int)this.Builds[(int)this.UpdateIndex].Index].BuildID == 8)
			{
				this.EffectBuildComplete = ParticleManager.Instance.Spawn(347, null, localPosition, 1f, true, false, true);
				this.MainTownLevelEffect();
			}
			else
			{
				this.EffectBuildComplete = ParticleManager.Instance.Spawn(331, null, localPosition, 1f, true, false, true);
			}
			AudioManager.Instance.PlayMP3SFX(41036, 0.2f);
		}
		else if (buildingData.ImmEffect == 0)
		{
			if (buildingData.AllBuildsData[(int)this.Builds[(int)this.UpdateIndex].Index].BuildID == 8)
			{
				this.EffectBuildComplete = ParticleManager.Instance.Spawn(346, null, localPosition, 1f, true, false, true);
				this.MainTownLevelEffect();
			}
			else
			{
				this.EffectBuildComplete = ParticleManager.Instance.Spawn(294, null, localPosition, 1f, true, false, true);
			}
			AudioManager.Instance.PlayMP3SFX(41036, 0f);
		}
		this.ShowNoticeIcon();
		Quaternion localRotation = this.EffectBuildComplete.transform.localRotation;
		localRotation.eulerAngles = new Vector3(0f, 180f, 0f);
		this.EffectBuildComplete.transform.localRotation = localRotation;
		this.MotionIndex = -1;
	}

	// Token: 0x06001195 RID: 4501 RVA: 0x001ECCBC File Offset: 0x001EAEBC
	private void HideNoticeIcon()
	{
		if (this.MotionIndex < 0)
		{
			return;
		}
		if (GUIManager.Instance.BuildingData.AllBuildsData[(int)this.Builds[this.MotionIndex].Index].BuildID == 18 && this.JailNoticeIcon != null)
		{
			this.JailNoticeIcon.Hide();
		}
	}

	// Token: 0x06001196 RID: 4502 RVA: 0x001ECD24 File Offset: 0x001EAF24
	private void ShowNoticeIcon()
	{
		if (this.MotionIndex < 0)
		{
			return;
		}
		if (GUIManager.Instance.BuildingData.AllBuildsData[(int)this.Builds[this.MotionIndex].Index].BuildID == 18 && this.JailNoticeIcon != null)
		{
			this.JailNoticeIcon.UpdateData();
		}
	}

	// Token: 0x06001197 RID: 4503 RVA: 0x001ECD8C File Offset: 0x001EAF8C
	public void SetSprite(byte[] ID, byte[] HeroClass)
	{
		if (this.Builds == null)
		{
			return;
		}
		for (int i = 0; i < this.Builds.Length; i++)
		{
			this.Builds[i].SetSprite(GameConstants.ConvertBytesToUShort(ID, i << 1), HeroClass[i]);
		}
	}

	// Token: 0x06001198 RID: 4504 RVA: 0x001ECDD8 File Offset: 0x001EAFD8
	public bool UpdateRun(float delta)
	{
		if (this.MotionTransform == null)
		{
			return false;
		}
		if (this.Type == WorldMode.Wild)
		{
			if (this.DownUp == 255)
			{
				Vector3 source = this.Source;
				if (this.Change < 0f)
				{
					source.y = this.Source.y;
				}
				else
				{
					source.y = this.Source.y + this.Change;
				}
				this.MotionTransform.position = source;
				this.Builds[(int)this.UpdateIndex].Update(3);
				this.MotionIndex = -1;
				this.DownUp = 0;
				return false;
			}
			if (this.DeltaTime > this.WaitTime)
			{
				Vector3 source2 = this.Source;
				source2.y = EasingEffect.Linear(this.DeltaTime - this.WaitTime, this.Source.y, this.Change, this.TotalTime - this.WaitTime);
				this.MotionTransform.position = source2;
			}
		}
		else
		{
			float d = EasingEffect.Linear(this.DeltaTime, this.Source.x, this.Change, this.TotalTime);
			this.MotionTransform.GetChild((int)this.SpriteEffectIdx).localScale = Vector3.one * d;
		}
		this.DeltaTime += delta;
		if (this.TotalTime < this.DeltaTime)
		{
			if (this.Type == WorldMode.Wild)
			{
				this.Source.y = this.Source.y + this.Change;
				this.MotionTransform.position = this.Source;
				if (this.DownUp == 1)
				{
					this.Builds[(int)this.UpdateIndex].Update(3);
					this.Builds[(int)this.UpdateIndex].Update(0);
					this.Source = this.MotionTransform.position;
					this.Source.y = this.Source.y - 32f;
					this.MotionTransform.position = this.Source;
					this.Change = 32f;
					this.DeltaTime = 0f;
					this.TotalTime = 1f;
					this.WaitTime = 0f;
					this.DownUp = 0;
					return true;
				}
				this.ShowBuildCompleteEffect();
				this.Builds[(int)this.UpdateIndex].Update(3);
				this.Builds[(int)this.UpdateIndex].Update(5);
				this.UpdateMapSprite(255, 9);
			}
			else
			{
				this.Source.Set(this.Change, this.Change, this.Change);
				Transform motionTransform = this.MotionTransform;
				byte spriteEffectIdx;
				this.SpriteEffectIdx = (spriteEffectIdx = this.SpriteEffectIdx) + 1;
				motionTransform.GetChild((int)spriteEffectIdx).localScale = this.Source;
				if (this.SpriteEffectIdx <= 4)
				{
					this.Source.Set(1f, 1f, 1f);
					this.MotionTransform.GetChild((int)this.SpriteEffectIdx).localScale = this.Source;
					this.MotionTransform.GetChild((int)this.SpriteEffectIdx).gameObject.SetActive(true);
					this.DeltaTime = 0f;
					this.TotalTime = 0.25f;
					return true;
				}
			}
			this.MotionTransform = null;
			return false;
		}
		return true;
	}

	// Token: 0x040037D7 RID: 14295
	private const float WildChangeVal = 32f;

	// Token: 0x040037D8 RID: 14296
	public MapSpriteManager mapspriteManager;

	// Token: 0x040037D9 RID: 14297
	public ushort BuildSpritesMax;

	// Token: 0x040037DA RID: 14298
	private SpriteBase[] Builds;

	// Token: 0x040037DB RID: 14299
	private Build HeroBuild;

	// Token: 0x040037DC RID: 14300
	private Build ArenaBuild;

	// Token: 0x040037DD RID: 14301
	private Build DugoutBuild;

	// Token: 0x040037DE RID: 14302
	private Build Fortress;

	// Token: 0x040037DF RID: 14303
	private Build BlackMarket;

	// Token: 0x040037E0 RID: 14304
	private Build Laboratory;

	// Token: 0x040037E1 RID: 14305
	private Build Carsino;

	// Token: 0x040037E2 RID: 14306
	public GameObject[] SpriteGameObject;

	// Token: 0x040037E3 RID: 14307
	public GameObject MapSpriteRoot;

	// Token: 0x040037E4 RID: 14308
	public GameObject EffectGo;

	// Token: 0x040037E5 RID: 14309
	public byte SpriteEffectIdx;

	// Token: 0x040037E6 RID: 14310
	public GameObject[] StageLock;

	// Token: 0x040037E7 RID: 14311
	private int[] StageLockNameCode;

	// Token: 0x040037E8 RID: 14312
	private EasingEffect BuildMotion;

	// Token: 0x040037E9 RID: 14313
	private byte EasingIndex;

	// Token: 0x040037EA RID: 14314
	private int MotionIndex = -1;

	// Token: 0x040037EB RID: 14315
	private Transform MotionTransform;

	// Token: 0x040037EC RID: 14316
	private Vector3 Source;

	// Token: 0x040037ED RID: 14317
	private float Change;

	// Token: 0x040037EE RID: 14318
	private float DeltaTime;

	// Token: 0x040037EF RID: 14319
	private float TotalTime;

	// Token: 0x040037F0 RID: 14320
	private float WaitTime;

	// Token: 0x040037F1 RID: 14321
	private float GuildSpeed = 8f;

	// Token: 0x040037F2 RID: 14322
	private float GuildPosY = 40f;

	// Token: 0x040037F3 RID: 14323
	private byte DownUp;

	// Token: 0x040037F4 RID: 14324
	private ushort UpdateIndex;

	// Token: 0x040037F5 RID: 14325
	private ushort GuideManorID;

	// Token: 0x040037F6 RID: 14326
	private ushort GuideBuildID;

	// Token: 0x040037F7 RID: 14327
	private GameObject EffectBuildComplete;

	// Token: 0x040037F8 RID: 14328
	private GameObject MainTownLevelup;

	// Token: 0x040037F9 RID: 14329
	private GameObject MainTownLevelupRing;

	// Token: 0x040037FA RID: 14330
	private float MainTownDelay = -1f;

	// Token: 0x040037FB RID: 14331
	public SpriteRenderer GuildPoint;

	// Token: 0x040037FC RID: 14332
	public SpriteRenderer DiamonAct;

	// Token: 0x040037FD RID: 14333
	public float UpdateTime;

	// Token: 0x040037FE RID: 14334
	private JailBuildNotice JailNoticeIcon;

	// Token: 0x040037FF RID: 14335
	private WorldMode Type;
}
