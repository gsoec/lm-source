using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x020001DA RID: 474
public class BattleController : Gameplay
{
	// Token: 0x17000067 RID: 103
	// (get) Token: 0x06000874 RID: 2164 RVA: 0x000A9CC0 File Offset: 0x000A7EC0
	public static byte[] EventBuffer
	{
		get
		{
			return BattleController.BufferForServer;
		}
	}

	// Token: 0x17000068 RID: 104
	// (get) Token: 0x06000875 RID: 2165 RVA: 0x000A9CC8 File Offset: 0x000A7EC8
	public int MaxSkillBitList
	{
		get
		{
			return this.m_MaxSkillList;
		}
	}

	// Token: 0x17000069 RID: 105
	// (get) Token: 0x06000876 RID: 2166 RVA: 0x000A9CD0 File Offset: 0x000A7ED0
	public uint HitContainer
	{
		get
		{
			return this.m_HitContainer;
		}
	}

	// Token: 0x1700006A RID: 106
	// (get) Token: 0x06000877 RID: 2167 RVA: 0x000A9CD8 File Offset: 0x000A7ED8
	// (set) Token: 0x06000878 RID: 2168 RVA: 0x000A9CE0 File Offset: 0x000A7EE0
	public bool StartAutoBattle
	{
		get
		{
			return this.bAutoBattle;
		}
		set
		{
			this.bAutoBattle = value;
			BattleController.AutoBattleFlag = value;
			if (this.bAutoBattle)
			{
				this.autoBattleDeltaTime = 0f;
				if (this.m_BattleState == BattleController.BattleState.BATTLE_FINISHED)
				{
					this.movePlayerOutside(EMovePlayerOutside.Default);
					GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.Battle);
				}
			}
			else if (this.m_BattleState == BattleController.BattleState.BATTLE_AUTOBATTLE_WAITING)
			{
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 6, 1);
				this.m_BattleState = BattleController.BattleState.BATTLE_FINISHED;
			}
		}
	}

	// Token: 0x1700006B RID: 107
	// (get) Token: 0x06000879 RID: 2169 RVA: 0x000A9D5C File Offset: 0x000A7F5C
	public bool IsMaxSkillWorking
	{
		get
		{
			return this.m_MaxSkillWorkingList != 0;
		}
	}

	// Token: 0x1700006C RID: 108
	// (get) Token: 0x0600087A RID: 2170 RVA: 0x000A9D6C File Offset: 0x000A7F6C
	public static bool IsActive
	{
		get
		{
			return GameManager.ActiveGameplay is BattleController;
		}
	}

	// Token: 0x1700006D RID: 109
	// (get) Token: 0x0600087B RID: 2171 RVA: 0x000A9D80 File Offset: 0x000A7F80
	public static bool IsGambleMode
	{
		get
		{
			return BattleController.IsActive && ((BattleController)GameManager.ActiveGameplay).IsType(EBattleType.GAMBLE);
		}
	}

	// Token: 0x1700006E RID: 110
	// (get) Token: 0x0600087C RID: 2172 RVA: 0x000A9DA0 File Offset: 0x000A7FA0
	public static bool IsDareMode
	{
		get
		{
			return BattleController.IsActive && ((BattleController)GameManager.ActiveGameplay).IsType(EBattleType.NORMAL) && DataManager.StageDataController._stageMode == StageMode.Dare;
		}
	}

	// Token: 0x0600087D RID: 2173 RVA: 0x000A9DD4 File Offset: 0x000A7FD4
	~BattleController()
	{
	}

	// Token: 0x0600087E RID: 2174 RVA: 0x000A9E0C File Offset: 0x000A800C
	protected override void UpdateNews(byte[] meg)
	{
		GAME_PLAYER_NEWS game_PLAYER_NEWS = (GAME_PLAYER_NEWS)meg[0];
		switch (game_PLAYER_NEWS)
		{
		case GAME_PLAYER_NEWS.Network_Update:
			if (meg[1] == 15)
			{
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.FORCEEND, eTransFunc.MapToBattle);
				this.m_BattleState = BattleController.BattleState.BATTLE_STOP;
				if (this.IsType(EBattleType.NORMAL))
				{
					BattleNetwork.NetworkError = 1;
				}
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
			}
			else if (meg[1] == 35)
			{
				if (RewardManager.getInstance.IsWorking)
				{
					RewardManager.getInstance.FontRefresh();
				}
			}
			else if (meg[1] == 0)
			{
				if (this.IsType(EBattleType.GAMBLE))
				{
					Time.timeScale = 1f;
				}
				else if (DataManager.Instance.BattleSeqID != 0UL && DataManager.Instance.RoleAttr.BattleID == DataManager.Instance.BattleSeqID && BattleNetwork.SendBattleEndStatus == 2)
				{
					BattleNetwork.SendBattleEndStatus = 1;
				}
			}
			break;
		default:
			if (game_PLAYER_NEWS == GAME_PLAYER_NEWS.BATTLE_PVPFadeOut)
			{
				if (this.m_BattleState == BattleController.BattleState.WAITING_FOR_START && this.m_SubStateFlag != 2)
				{
					this.m_SubStateFlag = 2;
				}
			}
			break;
		case GAME_PLAYER_NEWS.HeroTalk_Close:
			this.CloseDrama();
			break;
		}
	}

	// Token: 0x0600087F RID: 2175 RVA: 0x000A9F48 File Offset: 0x000A8148
	protected override void UpdateNext(byte[] meg)
	{
		if (this.controlPanel != null)
		{
			UnityEngine.Object.Destroy(this.controlPanel.gameObject);
			this.controlPanel = null;
		}
		if (this.fader != null)
		{
			UnityEngine.Object.Destroy(this.fader.gameObject);
			this.fader = null;
		}
		if (this.projector_parent != null)
		{
			UnityEngine.Object.Destroy(this.projector_parent.gameObject);
			this.projector_parent = null;
		}
		if (this.sp_projector_dist != null)
		{
			UnityEngine.Object.Destroy(this.sp_projector_dist.gameObject);
			this.sp_projector_dist = null;
		}
		if (this.sp_projector_line_transform != null)
		{
			UnityEngine.Object.Destroy(this.sp_projector_line_transform.gameObject);
			this.sp_projector_line_transform = null;
		}
		if (this.newbie_projector_parent != null)
		{
			UnityEngine.Object.Destroy(this.newbie_projector_parent.gameObject);
			this.newbie_projector_parent = null;
		}
		if (this.newbie_projector_line_transform != null)
		{
			UnityEngine.Object.Destroy(this.newbie_projector_line_transform.gameObject);
			this.newbie_projector_line_transform = null;
		}
		if (this.ProjectorABKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.ProjectorABKey, true);
			this.ProjectorABKey = 0;
		}
		AudioManager.Instance.RetrieveSFX();
		if (this.playerUnit != null)
		{
			for (int i = 0; i < this.playerCount; i++)
			{
				ModelLoader.Instance.Unload(this.playerUnit[i].gameObject);
				this.playerUnit[i] = null;
			}
		}
		if (this.enemyUnit != null)
		{
			for (int j = 0; j < this.enemyCount; j++)
			{
				ModelLoader.Instance.Unload(this.enemyUnit[j].gameObject);
				this.enemyUnit[j] = null;
			}
		}
		if (this.PVPWatcher != null)
		{
			ModelLoader.Instance.Unload(this.PVPWatcher.gameObject);
			this.PVPWatcher = null;
		}
		ModelLoader.Instance.Clear();
		this.m_HeroMap.Keys.CopyTo(this.m_HeroIDFilter, 0);
		this.m_IDFilterCount = this.m_HeroMap.Keys.Count;
		for (int k = 0; k < this.m_IDFilterCount; k++)
		{
			AssetManager.UnloadAssetBundle(this.m_HeroMap[this.m_HeroIDFilter[k]].assetKey, true);
		}
		this.m_HeroMap.Clear();
		this.BSUtil = null;
		this.ClearUpdateDelegates();
		ChaseManager.Instance.DestroyAll();
		RewardManager.getInstance.Free();
		this.BCamera = null;
		GUIManager.Instance.pDVMgr.EndFightClear();
		ParticleManager.Instance.Clear();
		AssetManager.QuitScene();
		DataManager.StageDataController.ReBackCurrentChapter();
		if (this.shadowABKey != 0)
		{
			AssetManager.UnloadAssetBundle(this.shadowABKey, true);
			this.shadowABKey = 0;
		}
		DataManager.Instance.BattleSeqID = 0UL;
		GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Battle);
		GUIManager.Instance.EmojiManager.Clear();
	}

	// Token: 0x06000880 RID: 2176 RVA: 0x000AA254 File Offset: 0x000A8454
	protected override void UpdateLoad(byte[] meg)
	{
		GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Battle);
		GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_ArenaBattle);
		GameManager.RegisterObserver(1, 0, this, 1);
		DataManager instance = DataManager.Instance;
		instance.battleInfo.PrimarySide = 0;
		if (NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE))
		{
			this.BattleType = EBattleType.TEACH;
			instance.heroBattleData[0].AttrData.LV = 1;
			instance.heroBattleData[0].AttrData.Enhance = 1;
			instance.heroBattleData[0].AttrData.Equip = 0;
			instance.heroBattleData[0].AttrData.Star = 1;
			instance.heroBattleData[0].AttrData.SkillLV1 = 4;
			instance.heroBattleData[0].AttrData.SkillLV2 = 0;
			instance.heroBattleData[0].AttrData.SkillLV3 = 0;
			instance.heroBattleData[0].AttrData.SkillLV4 = 0;
			instance.heroBattleData[1].AttrData.LV = 1;
			instance.heroBattleData[1].AttrData.Enhance = 1;
			instance.heroBattleData[1].AttrData.Equip = 0;
			instance.heroBattleData[1].AttrData.Star = 1;
			instance.heroBattleData[1].AttrData.SkillLV1 = 1;
			instance.heroBattleData[1].AttrData.SkillLV2 = 0;
			instance.heroBattleData[1].AttrData.SkillLV3 = 0;
			instance.heroBattleData[1].AttrData.SkillLV4 = 0;
			instance.battleInfo.RandomGap = 75;
			instance.battleInfo.RandomSeed = 600;
		}
		else if (NewbieManager.IsNewbie)
		{
			this.BattleType = EBattleType.NEWBIE_FAKE;
		}
		else if (BattleController.BattleMode == EBattleMode.Monster)
		{
			this.BattleType = EBattleType.PLAYBACK;
			GUIManager instance2 = GUIManager.Instance;
			ushort teamID = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(instance2.WM_MonsterID).MapTeamInfo[(int)(instance2.WM_MonsterLv - 1)].TeamID;
			instance.battleInfo.StageID = teamID;
			instance.battleInfo.BattleType = 2;
			instance.battleInfo.StageKind = 0;
			instance.battleInfo.RandomSeed = instance2.WM_RandomSeed;
			instance.battleInfo.RandomGap = (ushort)instance2.WM_RandomGap;
		}
		else if (BattleController.BattleMode == EBattleMode.PVP || BattleController.BattleMode == EBattleMode.PVP_Replay)
		{
			this.BattleType = EBattleType.PVP;
			this.IsReplay_PVP = (BattleController.BattleMode != EBattleMode.PVP);
			instance.battleInfo.StageID = 0;
			instance.battleInfo.BattleType = 3;
			instance.battleInfo.StageKind = 0;
			instance.battleInfo.RandomSeed = ArenaManager.Instance.ArenaPlayingData.RandomSeed;
			instance.battleInfo.RandomGap = (ushort)ArenaManager.Instance.ArenaPlayingData.RandomGap;
			instance.battleInfo.PrimarySide = ArenaManager.Instance.ArenaPlayingData.PrimarySide;
		}
		else if (BattleController.BattleMode == EBattleMode.Gambling)
		{
			this.BattleType = EBattleType.GAMBLE;
			BattleNetwork.GambleGetRandomHero();
			GamblingManager instance3 = GamblingManager.Instance;
			BattleController.GambleMode = ((instance3.GambleMode != UIBattle_Gambling.eMode.Normal) ? EGambleMode.Turbo : EGambleMode.Normal);
			ushort teamID2 = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(instance3.BattleMonsterID).MapTeamInfo[0].TeamID;
			instance.battleInfo.StageID = teamID2;
			instance.battleInfo.BattleType = 5;
			instance.battleInfo.StageKind = 0;
			instance.battleInfo.RandomSeed = 1;
			instance.battleInfo.RandomGap = 1;
			BattleController.CameraModel = 0;
		}
		BattleController.BattleMode = EBattleMode.Default;
		BattleController.IsPVPDefSide = false;
		if (this.IsType(EBattleType.PLAYBACK))
		{
			this.heroBattleData = GUIManager.Instance.WM_HeroData;
			this.playerCount = (int)GUIManager.Instance.WM_HeroCount;
		}
		else if (this.IsType(EBattleType.GAMBLE))
		{
			this.heroBattleData = GamblingManager.Instance.BattleHeroData;
			this.playerCount = (int)GamblingManager.Instance.BattleHeroCount;
		}
		else if (this.IsType(EBattleType.PVP))
		{
			this.heroBattleData = new HeroBattleData[5];
			this.playerCount = 0;
			this.enemyCount = 0;
			for (int i = 0; i < 5; i++)
			{
				this.heroBattleData[i] = ArenaManager.Instance.ArenaPlayingData.MyHeroData[i];
				if (this.heroBattleData[i].HeroID != 0)
				{
					this.playerCount++;
				}
				if (ArenaManager.Instance.ArenaPlayingData.EnemyHeroData[i].ID != 0)
				{
					this.enemyCount++;
				}
			}
			if ((ArenaManager.Instance.ArenaPlayingData.Flag & 2) == 0)
			{
				BattleController.IsPVPDefSide = true;
			}
		}
		else
		{
			this.heroBattleData = DataManager.Instance.heroBattleData;
			this.playerCount = (int)DataManager.Instance.heroCount;
		}
		if (this.IsType(EBattleType.NEWBIE_FAKE) || this.IsType(EBattleType.PLAYBACK) || this.IsType(EBattleType.PVP) || this.IsType(EBattleType.GAMBLE) || BattleController.IsDareMode)
		{
			Array.Clear(instance.RewardLen, 0, 4);
			Array.Clear(instance.RewardData, 0, 128);
			instance.RewardCount = 0;
		}
		this.BSUtil = BSInvokeUtil.getInstance;
		this.BSUtil.SetUserData(DataManager.Instance.RoleAttr.UserId, DataManager.Instance.BattleSeqID);
		this.BSUtil.InitSimulator(ref DataManager.Instance.battleInfo);
		DataManager.Instance.lastBattleResult = -1;
		if (this.IsType(EBattleType.PVP))
		{
			this.BSUtil.SetArenaTopic(ArenaManager.Instance.ArenaPlayingData.TopicID[0], ArenaManager.Instance.ArenaPlayingData.TopicID[1], ArenaManager.Instance.ArenaPlayingData.TopicEffect[0], ArenaManager.Instance.ArenaPlayingData.TopicEffect[1]);
		}
		this.deltaTime = 0f;
		this.autoBattleDeltaTime = 0f;
		if (BattleController.RecvBufferLeft == null)
		{
			BattleController.RecvBufferLeft = new byte[1024];
		}
		if (BattleController.RecvBufferRight == null)
		{
			BattleController.RecvBufferRight = new byte[1024];
		}
		if (BattleController.BufferForServer == null)
		{
			BattleController.BufferForServer = new byte[1024];
		}
		if (BattleController.m_MaxSkillIdTemp == null)
		{
			BattleController.m_MaxSkillIdTemp = new int[25];
		}
		for (int j = 0; j < 10; j++)
		{
			this.soundList[j] = new List<Transform>(25);
		}
		this.FirstPlayerPosX = (float)DataManager.Instance.ArrayTable.GetRecordByKey(1).HeroArrayInfo[0].posX * 0.01f;
		ParticleManager.Instance.Setup();
		this.CurrentStageID = this.loadBattleInfo();
		AssetManager.LoadScene(this.CurrentStageID);
		if (this.IsType(EBattleType.PVP))
		{
			long num = ArenaManager.Instance.ArenaPlayingData.Time;
			if (num == 0L)
			{
				num = instance.ServerTime;
			}
			int hour = GameConstants.GetDateTime(num).Hour;
			byte level;
			if (hour >= 14 && hour < 20)
			{
				level = 3;
			}
			else if (hour >= 20 || hour < 5)
			{
				level = 2;
			}
			else
			{
				level = 1;
			}
			AssetManager.LoadStage(level, ref this.mapObject1, ref this.mapObject2);
		}
		else
		{
			AssetManager.LoadStage(1, ref this.mapObject1, ref this.mapObject2);
		}
		this.CheckSetDareDifficulty();
		this.BSUtil.setHeroOver(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
		this.decodeHeroAttribute(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
		this.ChaseMgr = ChaseManager.Instance;
		this.BCamera.initCamera(this.playerUnit, this.playerCount, this.enemyUnit, this.enemyCount);
		int arg;
		int arg2;
		if (this.BattleType == EBattleType.PLAYBACK)
		{
			arg = ((int)GUIManager.Instance.WM_MonsterLv << 16 | (int)GUIManager.Instance.WM_MonsterID);
			arg2 = this.MonsterIdxTemp;
		}
		else
		{
			arg = 0;
			arg2 = 0;
		}
		this.uiBattle = (UIBattle)GUIManager.Instance.OpenMenu(EGUIWindow.UI_Battle, arg, arg2, false, false, false);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 1, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 8, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 10, 1);
		if (this.IsType(EBattleType.PVP))
		{
			GUIManager.Instance.OpenPvPUI();
		}
		else if (this.IsType(EBattleType.NEWBIE_FAKE))
		{
			this.uiBattle.gameObject.SetActive(false);
			GUIManager.Instance.HideChatBox();
		}
		else if (this.IsType(EBattleType.GAMBLE))
		{
			this.uiBattle.gameObject.SetActive(false);
			GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_Battle_Gambling, 0, 0);
		}
		if (this.IsType(EBattleType.GAMBLE))
		{
			RewardManager.getInstance.Init(ERewardEndPoint.GambleMode);
		}
		else
		{
			RewardManager.getInstance.Init(ERewardEndPoint.GambleMode);
		}
		GameObject gameObject = new GameObject("Catcher");
		gameObject.layer = 5;
		GUIManager.Instance.StretchTransform(gameObject.AddComponent<RectTransform>());
		gameObject.transform.SetParent(GUIManager.Instance.m_UICanvas.transform, false);
		gameObject.transform.SetAsFirstSibling();
		this.controlPanel = gameObject.AddComponent<BattleControllerPanel>();
		this.controlPanel.sprite = null;
		this.controlPanel.material = GUIManager.Instance.m_IconSpriteAsset.GetMaterial();
		this.controlPanel.color = new Color(0f, 0f, 0f, 0f);
		this.controlPanel.battleController = this;
		if (BattleController.IsDareMode)
		{
			GameObject gameObject2 = new GameObject("Fader");
			gameObject2.layer = 5;
			RectTransform rectTransform = gameObject2.AddComponent<RectTransform>();
			GUIManager.Instance.StretchTransform(rectTransform);
			gameObject2.transform.SetParent(GUIManager.Instance.m_FourthWindowLayer, false);
			gameObject2.AddComponent<IgnoreRaycast>();
			this.fader = gameObject2.AddComponent<Fader>();
			this.fader.sprite = null;
			this.fader.material = GUIManager.Instance.m_IconSpriteAsset.GetMaterial();
			this.fader.Reset();
			if (GUIManager.Instance.bOpenOnIPhoneX)
			{
				rectTransform.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0f);
				rectTransform.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0f);
			}
		}
		if (this.IsType(EBattleType.GAMBLE))
		{
			this.controlPanel.gameObject.SetActive(false);
		}
		AssetManager.Instance.AssetManagerState = AssetState.Ready;
		this.BCamera.updateCamera(this.playerUnit, this.playerCount, this.enemyUnit, this.enemyCount);
		GUIManager.Instance.pDVMgr.BeginFightInitial();
		GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
		int num2 = 5;
		for (int k = 0; k < 4; k++)
		{
			this.m_SkinColorLightmapIndex[k] = LightmapManager.Instance.GetLightmapIndex((Lightmap_Enum)(num2 + k));
			this.m_SkinColorLightmapTex[k] = LightmapManager.Instance.GetLightmapTexture((Lightmap_Enum)(num2 + k));
		}
		this.ProjectorABKey = 0;
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/BCProjector", out this.ProjectorABKey, false);
		UnityEngine.Object[] array = assetBundle.LoadAll(typeof(Sprite));
		Texture2D texture = ((Sprite)array[0]).texture;
		float num3 = 1f / (float)texture.height;
		for (int l = 0; l < 8; l++)
		{
			Rect textureRect = ((Sprite)array[l]).textureRect;
			this.ProjectorUV[l] = new Rect(textureRect.x * num3, textureRect.y * num3, textureRect.width * num3, textureRect.height * num3);
		}
		GameObject gameObject3 = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
		MeshRenderer component = gameObject3.GetComponent<MeshRenderer>();
		Material sharedMaterial = component.sharedMaterial;
		this.sp_projector_line = gameObject3.GetComponent<MeshFilter>();
		this.sp_projector_line.mesh = GameConstants.CreatePlane(Vector3.up, Vector3.right, this.ProjectorUV[7], Color.white, 10f);
		this.sp_projector_line_transform = gameObject3.transform;
		gameObject3.SetActive(false);
		gameObject3 = new GameObject("SP");
		this.sp_projector = gameObject3.AddComponent<ShadowProjector>();
		this.sp_projector.SetShadowProjectorMaterial(sharedMaterial);
		this.sp_projector.ShadowOpacity = 1f;
		this.sp_projector.ShadowSize = 1f;
		this.projector_parent = new GameObject("SP_P").transform;
		this.projector_parent.position = new Vector3(0f, 0.01f, 0f);
		this.sp_projector.transform.parent = this.projector_parent;
		this.sp_projector.transform.localPosition = Vector3.zero;
		this.sp_projector_transform = gameObject3.transform.GetChild(0);
		this.sp_projector_transform.Rotate(90f, 0f, 0f);
		gameObject3.SetActive(false);
		if (this.IsType(EBattleType.TEACH))
		{
			gameObject3 = new GameObject("SP_Teach");
			this.newbie_projector = gameObject3.AddComponent<ShadowProjector>();
			this.newbie_projector.SetShadowProjectorMaterial(sharedMaterial);
			this.newbie_projector.ShadowOpacity = 0.3f;
			this.newbie_projector.ShadowSize = 1f;
			this.newbie_projector_parent = new GameObject("SP_P_Teach").transform;
			this.newbie_projector_parent.position = new Vector3(0f, 0.005f, 0f);
			this.newbie_projector.transform.parent = this.newbie_projector_parent;
			this.newbie_projector.transform.localPosition = Vector3.zero;
			this.newbie_projector_transform = gameObject3.transform.GetChild(0);
			this.newbie_projector_transform.Rotate(90f, 0f, 0f);
			gameObject3.SetActive(false);
			gameObject3 = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
			component = gameObject3.GetComponent<MeshRenderer>();
			this.newbie_projector_line = gameObject3.GetComponent<MeshFilter>();
			this.newbie_projector_line.mesh = GameConstants.CreatePlane(Vector3.up, Vector3.right, this.ProjectorUV[7], new Color(1f, 1f, 1f, 0.3f), 10f);
			this.newbie_projector_line_transform = gameObject3.transform;
			gameObject3.SetActive(false);
			NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, this.uiBattle, false);
		}
		gameObject3 = new GameObject("SP_DIST");
		this.sp_projector_dist = gameObject3.AddComponent<ShadowProjector>();
		this.sp_projector_dist.SetShadowProjectorMaterial(sharedMaterial);
		this.sp_projector_dist.ShadowOpacity = 1f;
		this.sp_projector_dist.ShadowSize = 1f;
		this.sp_projector_dist.UVRect = this.ProjectorUV[0];
		Transform child = gameObject3.transform.GetChild(0);
		child.Rotate(90f, 0f, 0f);
		gameObject3.SetActive(false);
		NewbieManager.AutoBattleFlag = false;
		if (this.IsType(EBattleType.NORMAL) && !NewbieManager.IsWorking() && this.uiBattle.autoButtonUp.gameObject.activeSelf && NewbieManager.NeedTeach(ETeachKind.AUTO_BATTLE))
		{
			NewbieManager.AutoBattleFlag = true;
		}
		if ((ushort)(this.DramaTriggerFlag & 65535u) == 0 && this.IsType(EBattleType.NORMAL) && !NewbieManager.IsWorking() && this.uiBattle.autoButtonUp.gameObject.activeSelf)
		{
			NewbieManager.EntryTeach(ETeachKind.AUTO_BATTLE);
		}
		if (this.IsType(EBattleType.PVP))
		{
			this.SetupPVPOutsideNPC();
		}
		if (this.IsType(EBattleType.NORMAL))
		{
			int count = GUIManager.Instance.m_WindowStack.Count;
			for (int m = 0; m < count; m++)
			{
				if (GUIManager.Instance.m_WindowStack[m].m_eWindow == EGUIWindow.UI_BattleHeroSelect)
				{
					GUIManager.Instance.m_WindowStack.RemoveAt(m);
				}
			}
			count = GUIManager.Instance.m_WindowStack.Count;
			for (int n = 0; n < count; n++)
			{
				if (GUIManager.Instance.m_WindowStack[n].m_eWindow == EGUIWindow.UI_StageInfo)
				{
					GUIManager.Instance.m_WindowStack.RemoveAt(n);
				}
			}
		}
		this.m_BattleState = BattleController.BattleState.WAITING_FOR_START;
	}

	// Token: 0x06000881 RID: 2177 RVA: 0x000AB390 File Offset: 0x000A9590
	protected override void UpdateReady(byte[] meg)
	{
		if (BattleController.IsGambleMode)
		{
			GUIManager.Instance.m_HUDMessage.MapHud.AddGambleMsg();
			GUIManager.Instance.m_HUDMessage.MapHud.ShowMsg();
			GUIManager.Instance.m_HUDMessage.MapHud.ShowTime = 1.3f;
			GUIManager.Instance.m_HUDMessage.MapHud.StartCountdown();
		}
	}

	// Token: 0x06000882 RID: 2178 RVA: 0x000AB3FC File Offset: 0x000A95FC
	protected override void UpdateRun(byte[] meg)
	{
		if (this.m_BattleState == BattleController.BattleState.BATTLE_STOP)
		{
			return;
		}
		float smoothDeltaTime = Time.smoothDeltaTime;
		this.deltaTime += smoothDeltaTime;
		this.autoBattleDeltaTime += smoothDeltaTime;
		this.m_StateSkinTimer += smoothDeltaTime;
		float num = 0f;
		if (this.bUseTimeCache)
		{
			this.deltaTime = this.maxSkillTimeCache;
			this.bUseTimeCache = false;
		}
		if (this.deltaTime >= 0.1f)
		{
			if (this.m_BattleState == BattleController.BattleState.WAITING_FOR_START)
			{
				if (this.deltaTime >= 1.1f)
				{
					if (this.IsType(EBattleType.PVP))
					{
						if (this.m_SubStateFlag == 0)
						{
							GUIManager.Instance.BeginPvPOpening();
							this.m_SubStateFlag = 1;
						}
						else if (this.m_SubStateFlag == 1)
						{
						}
					}
					else if (this.m_SubStateFlag == 0)
					{
						ushort num2 = (ushort)(this.DramaTriggerFlag & 65535u);
						if (num2 != 0)
						{
							if (this.IsType(EBattleType.TEACH))
							{
								NewbieManager.SetNewbieControlLock(false);
							}
							GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, (int)num2, (int)this.heroBattleData[0].HeroID);
							if (this.controlPanel != null)
							{
								this.controlPanel.gameObject.SetActive(false);
							}
							this.DramaTriggerFlag &= 4294901760u;
							this.bDramaWorking = true;
							this.m_SubStateFlag = 1;
						}
						else
						{
							this.m_SubStateFlag = 2;
						}
					}
					else if (this.m_SubStateFlag == 1 && !this.bDramaWorking)
					{
						this.m_SubStateFlag = 2;
						if (this.IsType(EBattleType.NORMAL) && !NewbieManager.IsWorking() && this.uiBattle.autoButtonUp.gameObject.activeSelf)
						{
							NewbieManager.EntryTeach(ETeachKind.AUTO_BATTLE);
						}
					}
				}
				if (this.m_SubStateFlag == 2)
				{
					this.m_BattleState = BattleController.BattleState.BATTLE_RUNNING;
					this.deltaTime = 0f;
					this.m_SubStateFlag = 0;
					if (NewbieManager.IsTeachWorking(ETeachKind.AUTO_BATTLE))
					{
						NewbieManager.CheckTeach(ETeachKind.AUTO_BATTLE, this.uiBattle, false);
					}
					else if (NewbieManager.IsTeachWorking(ETeachKind.GAMBLING1))
					{
						NewbieManager.CheckTeach(ETeachKind.GAMBLING1, null, false);
					}
					else if (NewbieManager.IsTeachWorking(ETeachKind.GAMBLING2))
					{
						NewbieManager.CheckTeach(ETeachKind.GAMBLING2, null, false);
					}
					else
					{
						NewbieManager.CheckGambleElite();
					}
				}
			}
			else if (this.m_BattleState == BattleController.BattleState.BATTLE_RUNNING)
			{
				if (this.m_MaxSkillList != 0)
				{
					this.m_MaxSkillList = 0;
				}
				BattleController.RecvBufferLeft[0] = 0;
				BattleController.RecvBufferRight[0] = 0;
				this.m_BattleResult = this.BSUtil.updateBattleData(this.m_ui32Tcik, BattleController.RecvBufferLeft, BattleController.RecvBufferRight, BattleController.BufferForServer);
				this.m_ui32Tcik += 1u;
				if (this.IsType(EBattleType.GAMBLE) && BattleController.GambleResult != 0)
				{
					this.m_BattleResult = (byte)BattleController.GambleResult;
				}
				this.deltaTime -= 0.1f;
				num = this.deltaTime;
				num = Mathf.Min(0.1f, num);
				this.fixMoveDeltaTime = num;
				this.canMoveDeltaTime = 0.1f;
				if ((!this.IsType(EBattleType.PLAYBACK) && !this.IsType(EBattleType.PVP)) || !this.decodeUltraSkill(BattleController.BufferForServer) || this.m_BattleResult != 0)
				{
					this.decodeSimuPackage(BattleController.RecvBufferLeft, BattleController.RecvBufferRight, 0);
				}
				if (this.IsType(EBattleType.GAMBLE) && this.CasinoHitDirty)
				{
					this.PlayGambleHitEffect();
					this.CasinoHitDirty = false;
				}
				if (this.m_bHPMPDirty != 0)
				{
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 1, 0);
					this.m_bHPMPDirty = 0;
				}
				if (this.m_StateUpdateFlag != 0UL)
				{
					this.updateSkillState(false);
					this.m_StateUpdateFlag = 0UL;
				}
				if (this.m_IDFilterCount > 0)
				{
					for (int i = 0; i < 25; i++)
					{
						if (this.m_HeroIDFilter[i] != 0)
						{
							uint iValue = (uint)this.m_HeroIDFilter[i];
							this.m_HeroIDFilter[i] = 0;
							int side = 0;
							int iIndex = i;
							if (i > 4)
							{
								side = 1;
								iIndex = 25 - i - 1;
							}
							GUIManager.Instance.pDVMgr.AddDamageValueEffect(iValue, side, iIndex, HERO_EFFECTTYPE_ENUM.HERO_EFFECT_HEMOPHAGIA, 0);
						}
					}
					this.m_IDFilterCount = 0;
				}
				uint num3 = (!BattleController.IsPVPDefSide) ? this.BSUtil.checkUltraCondition() : this.BSUtil.checkRightUltraCondition();
				for (int j = 0; j < 5; j++)
				{
					if (this.ms_viewer[j].working != 0)
					{
						if (!(this.playerUnit[j] == null) && this.playerUnit[j].enabled)
						{
							if ((num3 >> j & 1u) != 0u)
							{
								if (this.ms_viewer[j].ui_state == 0)
								{
									this.ms_viewer[j].ui_state = 1;
									this.uiBattle.SetBtnTween(j, 1);
								}
							}
							else if (this.ms_viewer[j].ui_state == 1)
							{
								this.ms_viewer[j].ui_state = 0;
								this.uiBattle.SetBtnTween(j, 0);
							}
						}
					}
				}
				if (this.m_bSoundDirty)
				{
					Transform transform = Camera.main.transform;
					for (int k = 0; k < this.soundPlayMap.Length; k++)
					{
						ushort num4 = this.soundPlayMap.Keys[k];
						if (num4 != 0)
						{
							int num5 = this.soundPlayMap.Values[k];
							int num6 = -1;
							float num7 = 0f;
							for (int l = 0; l < this.soundList[num5].Count; l++)
							{
								float num8 = Vector3.Distance(transform.position, this.soundList[num5][l].position);
								if (num6 == -1 || num8 < num7)
								{
									num7 = num8;
									num6 = l;
								}
							}
							AudioManager.Instance.PlaySFX(num4, 0f, PitchKind.SpeechSound, this.soundList[num5][num6], null);
							this.soundList[num5].Clear();
						}
					}
					this.soundPlayMap.Clear();
					this.m_LastSoundListIdx = 0;
					this.m_bSoundDirty = false;
				}
				if (this.m_BattleResult == 1 || this.m_BattleResult == 2)
				{
					this.m_BattleState = BattleController.BattleState.BATTLE_FINISHING;
					if (this.IsType(EBattleType.PVP))
					{
						if ((ArenaManager.Instance.ArenaPlayingData.Flag & 1) != 0)
						{
							this.m_BattleResult = 1;
						}
						else
						{
							this.m_BattleResult = 2;
						}
					}
					this.bTimeUp = false;
					if (this.m_BattleResult == 2)
					{
						for (int m = 0; m < this.playerCount; m++)
						{
							if (this.playerUnit[m].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
							{
								this.bTimeUp = true;
								break;
							}
						}
					}
				}
			}
			else if (this.m_BattleState == BattleController.BattleState.BATTLE_MAXSKILL_WORKING)
			{
				if (this.m_MaxSkillWorkingList == 0 && !this.uiBattle.ultraSkillWorking)
				{
					this.updateMaxSkillFreeze(false);
					this.UpdateSkillLightmap(false, false);
					this.bUseTimeCache = true;
					DamageValueManager pDVMgr = GUIManager.Instance.pDVMgr;
					for (int n = 0; n < this.playerCount; n++)
					{
						pDVMgr.HideBloodBar(0, n);
					}
					for (int num9 = 0; num9 < this.enemyCount; num9++)
					{
						pDVMgr.HideBloodBar(1, num9);
					}
					this.m_BattleState = BattleController.BattleState.BATTLE_RUNNING;
					if (this.IsType(EBattleType.PLAYBACK))
					{
						this.decodeSimuPackage(BattleController.RecvBufferLeft, BattleController.RecvBufferRight, 4);
					}
					else if (this.IsType(EBattleType.PVP))
					{
						this.decodeSimuPackage(BattleController.RecvBufferLeft, BattleController.RecvBufferRight, 12);
					}
				}
			}
			else if (this.m_BattleState == BattleController.BattleState.BATTLE_CHECK_DIE_BEFORE_SUPPORT)
			{
				for (int num10 = 0; num10 < this.enemyCount; num10++)
				{
					if (this.enemyUnit[num10].heroState == HERO_STATE_ENUM.HERO_COMMANDS_DIE && this.enemyUnit[num10].DeadBodyHidingFlag == 3)
					{
						this.ExeSupport(this.SupportAU, this.SupportIdx);
						break;
					}
				}
			}
			else if (this.m_BattleState == BattleController.BattleState.BATTLE_SUPPORT_DISPLAY)
			{
				if (this.m_SubStateFlag == 0)
				{
					if (this.deltaTime > 1f)
					{
						for (int num11 = 0; num11 < this.m_SupportDisplayList.Count; num11++)
						{
							this.m_SupportDisplayList[num11].setState(HERO_STATE_ENUM.HERO_COMMANDS_SUPPORT_DISPLAY, null, 0, 0, 0);
						}
						this.m_SubStateFlag = 1;
					}
				}
				else if (this.m_SubStateFlag == 1)
				{
					for (int num12 = this.m_SupportDisplayList.Count - 1; num12 >= 0; num12--)
					{
						if (this.m_SupportDisplayList[num12].heroState != HERO_STATE_ENUM.HERO_COMMANDS_SUPPORT_DISPLAY)
						{
							this.m_SupportDisplayList[num12].setMaxSkillFreeze(true);
							this.m_SupportDisplayList.RemoveAt(num12);
						}
					}
					if (this.m_SupportDisplayList.Count == 0)
					{
						this.deltaTime = 0f;
						this.m_SubStateFlag = 2;
					}
				}
				else if (this.deltaTime > 0.5f)
				{
					this.updateSupportDisplayFreeze(false);
					this.deltaTime = 0f;
					this.m_BattleState = BattleController.BattleState.BATTLE_RUNNING;
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 4, 0);
					if (this.IsType(EBattleType.GAMBLE))
					{
						GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 18, 0);
						GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 15, 0);
					}
				}
			}
			else if (this.m_BattleState == BattleController.BattleState.BATTLE_FINISHING)
			{
				this.m_MaxSkillWorkingList = 0;
				this.updateMaxSkillFreeze(false);
				this.UpdateSkillLightmap(false, true);
				AnimationUnit[] array = (this.m_BattleResult != 2) ? this.playerUnit : this.enemyUnit;
				int num13 = (this.m_BattleResult != 2) ? this.playerCount : this.enemyCount;
				for (int num14 = 0; num14 < num13; num14++)
				{
					if (array[num14].enabled)
					{
						if (array[num14].heroState == HERO_STATE_ENUM.HERO_COMMANDS_MOVE)
						{
							array[num14].setState(HERO_STATE_ENUM.HERO_COMMANDS_IDLE, null, 0, 0, 0);
						}
						else if (array[num14].CurAnimState != null && array[num14].CurAnimState.wrapMode == WrapMode.Loop)
						{
							array[num14].setState(HERO_STATE_ENUM.HERO_COMMANDS_IDLE, null, 50, 0, 0);
						}
						else if (array[num14].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE && array[num14].getAnimation != null)
						{
							array[num14].SetWaitIdle();
						}
						array[num14].CleanStateDisplay();
						array[num14].cleanStateParticle();
					}
				}
				AnimationUnit[] array2 = (this.m_BattleResult != 2) ? this.enemyUnit : this.playerUnit;
				BattleController.HeroAttr[] array3 = (this.m_BattleResult != 2) ? this.enemyAttr : this.playerAttr;
				int num15 = (this.m_BattleResult != 2) ? this.enemyCount : this.playerCount;
				HERO_STATE_ENUM hero_STATE_ENUM = (!this.bTimeUp) ? HERO_STATE_ENUM.HERO_COMMANDS_DIE : HERO_STATE_ENUM.HERO_COMMANDS_IDLE;
				for (int num16 = 0; num16 < num15; num16++)
				{
					if (array2[num16].enabled && array2[num16].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
					{
						array2[num16].setState(hero_STATE_ENUM, null, 0, 0, 0);
						if (hero_STATE_ENUM == HERO_STATE_ENUM.HERO_COMMANDS_DIE)
						{
							array3[num16].CUR_HP = 0u;
						}
						else if (!BattleController.IsDareMode || this.m_BattleResult != 2 || this.BSUtil.GetHeroChallengeFailedQuest() == 0)
						{
							array2[num16].CleanStateDisplay();
							array2[num16].cleanStateParticle();
						}
					}
				}
				this.deltaTime = 0f;
				this.m_BattleState = BattleController.BattleState.BATTLE_WAITTING_FOR_VICTORY;
			}
			else if (this.m_BattleState == BattleController.BattleState.BATTLE_FINISHING_SPREAD)
			{
				AnimationUnit[] array4 = (this.m_BattleResult != 2) ? this.playerUnit : this.enemyUnit;
				int num17 = (this.m_BattleResult != 2) ? this.playerCount : this.enemyCount;
				int num18 = 0;
				for (int num19 = 0; num19 < num17; num19++)
				{
					if (array4[num19].enabled && array4[num19].heroState == HERO_STATE_ENUM.HERO_COMMANDS_FINISHING_SPREAD)
					{
						num18++;
					}
				}
				if (num18 == 0)
				{
					this.deltaTime = 0f;
					this.m_BattleState = BattleController.BattleState.BATTLE_WAITTING_FOR_VICTORY;
				}
			}
			else if (this.m_BattleState == BattleController.BattleState.BATTLE_WAITTING_FOR_VICTORY)
			{
				float num20 = (!NewbieManager.IsNewbie) ? 0.5f : 2.5f;
				if ((this.IsType(EBattleType.GAMBLE) || !RewardManager.getInstance.IsWorking) && this.deltaTime >= num20)
				{
					if (this.m_BattleResult == 2)
					{
						if (!this.IsType(EBattleType.GAMBLE))
						{
							for (int num21 = 0; num21 < this.enemyCount; num21++)
							{
								if (this.enemyUnit[num21].enabled)
								{
									this.enemyUnit[num21].setState(HERO_STATE_ENUM.HERO_COMMANDS_VICTORY, null, 0, 0, 0);
									this.enemyUnit[num21].StateEffList.Clear();
									ulong num22 = (ulong)(1L << (10 + num21 & 31));
									this.m_StateUpdateFlag |= num22;
								}
							}
						}
						else
						{
							for (int num23 = 0; num23 < this.enemyCount; num23++)
							{
								if (this.enemyUnit[num23].enabled)
								{
									Vector3 position = this.enemyUnit[num23].Position;
									position.x = ((!this.IsType(EBattleType.GAMBLE)) ? -100f : 100f);
									this.enemyUnit[num23].movePos = new Vector3?(position);
									this.enemyUnit[num23].Target = null;
									this.enemyUnit[num23].setState(HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_RUN, null, 0, 0, 0);
									this.enemyUnit[num23].StateEffList.Clear();
									ulong num24 = (ulong)(1L << (10 + num23 & 31));
									this.m_StateUpdateFlag |= num24;
								}
							}
							if (this.IsType(EBattleType.GAMBLE))
							{
								GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 14, 0);
							}
						}
						if (this.bTimeUp)
						{
							if (!this.IsType(EBattleType.GAMBLE))
							{
								byte heroChallengeFailedQuest;
								if (!BattleController.IsDareMode || (heroChallengeFailedQuest = this.BSUtil.GetHeroChallengeFailedQuest()) == 0)
								{
									this.movePlayerOutside(EMovePlayerOutside.BattleFailed);
								}
								else
								{
									DataManager.Instance.BattleFailureIndex = heroChallengeFailedQuest;
								}
							}
							else
							{
								this.movePlayerOutside(EMovePlayerOutside.GambleFailed);
							}
						}
						else
						{
							DataManager.Instance.BattleFailureIndex = 0;
						}
						this.updateSkillState(true);
						this.m_StateUpdateFlag = 0UL;
						this.m_BattleState = BattleController.BattleState.BATTLE_SHOW_RESULT_UI;
					}
					else if (this.m_BattleResult == 1)
					{
						HERO_STATE_ENUM state = HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_IDLE;
						if (this.m_CurStageLevel == this.m_MaxStageLevel)
						{
							state = HERO_STATE_ENUM.HERO_COMMANDS_VICTORY;
						}
						for (int num25 = 0; num25 < this.playerCount; num25++)
						{
							if (this.playerUnit[num25].enabled)
							{
								this.playerUnit[num25].setState(state, null, 0, 0, 0);
								this.playerUnit[num25].StateEffList.Clear();
								ulong num26 = (ulong)(1L << (num25 & 31));
								this.m_StateUpdateFlag |= num26;
							}
						}
						this.updateSkillState(true);
						this.m_StateUpdateFlag = 0UL;
						if (this.IsType(EBattleType.GAMBLE) && this.enemyUnit[1] != null && this.enemyUnit[1].gameObject.activeSelf)
						{
							GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 14, 0);
						}
						this.m_BattleState = BattleController.BattleState.BATTLE_SHOW_RESULT_UI;
					}
					if (this.m_BattleState == BattleController.BattleState.BATTLE_SHOW_RESULT_UI)
					{
						this.deltaTime = 1f;
						for (int num27 = 0; num27 < 5; num27++)
						{
							if (this.ms_viewer[num27].working == 1)
							{
								this.ms_viewer[num27].ui_state = 0;
								this.uiBattle.SetBtnTween(num27, 0);
							}
						}
						if (this.CheckNextLevel())
						{
							if (this.m_BattleResult == 1)
							{
								if (!this.bAutoBattle)
								{
									GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 6, 1);
									this.m_BattleState = BattleController.BattleState.BATTLE_FINISHED;
									if (this.IsType(EBattleType.TEACH))
									{
										NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, this, false);
									}
								}
								else
								{
									this.m_BattleState = BattleController.BattleState.BATTLE_AUTOBATTLE_WAITING;
								}
							}
						}
						else
						{
							if (this.IsType(EBattleType.NORMAL) || this.IsType(EBattleType.TEACH))
							{
								if (this.m_BattleResult == 2)
								{
									DataManager.Instance.lastBattleResult = 0;
									if (this.fader != null)
									{
										this.fader.Reset();
									}
								}
								else
								{
									BattleNetwork.SendBattleEndStatus = 1;
								}
							}
							else if (this.IsType(EBattleType.NEWBIE_FAKE))
							{
								Time.timeScale = 1f;
								GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, 3, 1);
								if (this.controlPanel != null)
								{
									this.controlPanel.gameObject.SetActive(false);
								}
								this.bDramaWorking = true;
								NewbieLog.Log(ENewbieLogKind.FORCE_1, 4);
								this.m_BattleState = BattleController.BattleState.BATTLE_STOP;
							}
							this.IsBattleEnd = true;
							this.m_SubStateFlag = 0;
						}
					}
				}
			}
			else if (this.m_BattleState == BattleController.BattleState.BATTLE_SHOW_RESULT_UI)
			{
				if (this.deltaTime >= 4f && (this.IsType(EBattleType.PLAYBACK) || this.IsType(EBattleType.PVP) || this.IsType(EBattleType.GAMBLE) || DataManager.Instance.lastBattleResult >= 0))
				{
					if (this.m_SubStateFlag == 0)
					{
						ushort num28 = (ushort)(this.DramaTriggerFlag >> 16 & 65535u);
						if (num28 != 0 && this.m_BattleResult == 1)
						{
							GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, (int)num28, (int)this.heroBattleData[0].HeroID);
							if (this.controlPanel != null)
							{
								this.controlPanel.gameObject.SetActive(false);
							}
							this.DramaTriggerFlag = 0u;
							this.bDramaWorking = true;
							this.m_SubStateFlag = 1;
							if (this.IsType(EBattleType.TEACH))
							{
								NewbieManager.Get().RemoveFlag(ETeachKind.BATTLE_BEFORE, 0, false);
							}
						}
						else
						{
							this.m_SubStateFlag = 2;
						}
					}
					else if (this.m_SubStateFlag == 1 && !this.bDramaWorking)
					{
						this.m_SubStateFlag = 2;
					}
				}
				else if (this.m_BattleResult == 2 && this.fader != null && this.IsType(EBattleType.NORMAL) && DataManager.StageDataController._stageMode == StageMode.Dare && this.deltaTime >= 2f)
				{
					this.fader.Action();
				}
				if (this.m_SubStateFlag == 2)
				{
					ChaseManager.Instance.Clear();
					if (this.IsType(EBattleType.PLAYBACK))
					{
						GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
					}
					else if (this.IsType(EBattleType.GAMBLE))
					{
						this.m_BattleResult = 1;
						this.movePlayerOutside(EMovePlayerOutside.Default);
						this.GambleTimeCache = DataManager.Instance.ServerTime;
						this.m_BattleState = BattleController.BattleState.BATTLE_CHECK_GAMBLE_TIMEOUT;
						this.deltaTime = 0f;
					}
					else if (this.IsType(EBattleType.PVP))
					{
						if (!this.IsReplay_PVP)
						{
							GUIManager.Instance.OpenMenu(EGUIWindow.UI_Settlement, 1, 0, true, false, false);
						}
						else
						{
							GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
						}
					}
					else
					{
						int num29 = (!BattleController.IsDareMode) ? 0 : 2;
						int arg = (this.m_BattleResult != 2 || DataManager.Instance.lastBattleResult != 0) ? 1 : 0;
						GUIManager.Instance.OpenMenu(EGUIWindow.UI_Settlement, num29, arg, true, false, false);
						if (num29 == 2 && this.fader != null)
						{
							this.fader.Reset();
						}
					}
					if (!this.IsType(EBattleType.GAMBLE))
					{
						this.m_BattleState = BattleController.BattleState.BATTLE_FINISHED;
					}
					this.m_SubStateFlag = 0;
				}
			}
			else if (this.m_BattleState == BattleController.BattleState.BATTLE_CHECK_GAMBLE_TIMEOUT)
			{
				if (this.deltaTime > 1f)
				{
					BattleController.GambleResult = 0;
					BattleNetwork.RefreshGambleMode(BattleController.GambleMode);
					this.m_BattleState = BattleController.BattleState.BATTLE_FINISHED;
				}
			}
			else if (this.m_BattleState == BattleController.BattleState.BATTLE_AUTOBATTLE_WAITING && this.deltaTime >= 1.5f)
			{
				this.m_BattleState = BattleController.BattleState.BATTLE_FINISHED;
				this.movePlayerOutside(EMovePlayerOutside.Default);
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.Battle);
			}
		}
		if ((this.IsType(EBattleType.NORMAL) || this.IsType(EBattleType.TEACH)) && BattleNetwork.SendBattleEndStatus == 1 && BattleNetwork.sendBattleEnd())
		{
			BattleNetwork.SendBattleEndStatus = 2;
		}
		if (this.m_StateSkinTimer >= 0.05f)
		{
			Color a = new Color(0.5f, 0.5f, 0.5f);
			this.m_StateSkinTimeLen += this.m_StateSkinTimer;
			if (this.m_StateSkinTimeLen >= 1f)
			{
				this.m_StateSkinFlag *= -1;
				this.m_StateSkinTimeLen = 0f;
			}
			float t = this.m_StateSkinTimeLen / 1f;
			for (int num30 = 0; num30 < 4; num30++)
			{
				if (num30 != 3)
				{
					Color color;
					if (this.m_StateSkinFlag == 1)
					{
						color = Color.Lerp(BattleController.StateSkin[num30] * 0.5f, a * 0.5f, t);
					}
					else
					{
						color = Color.Lerp(a * 0.5f, BattleController.StateSkin[num30] * 0.5f, t);
					}
					this.m_SkinColorLightmapTex[num30].SetPixel(1, 1, color);
					this.m_SkinColorLightmapTex[num30].Apply();
				}
			}
			this.m_StateSkinTimer = 0f;
		}
		float? ultraNewbieDelay = this.UltraNewbieDelay;
		if (ultraNewbieDelay != null)
		{
			this.UltraNewbieDelay = new float?(this.UltraNewbieDelay.Value - Time.deltaTime);
			if (this.UltraNewbieDelay.Value < 0f)
			{
				this.inputUltra(false, null);
				this.UltraNewbieDelay = null;
			}
		}
		if (this.m_BattleState == BattleController.BattleState.BATTLE_RUNNING)
		{
			if ((this.bAutoBattle || this.IsType(EBattleType.NEWBIE_FAKE)) && this.autoBattleDeltaTime >= 1f)
			{
				for (int num31 = 0; num31 < this.playerCount; num31++)
				{
					if (this.playerAttr[num31].CUR_MP >= this.playerAttr[num31].MAX_MP && this.ms_viewer[num31].working != 0 && this.ms_viewer[num31].ui_state == 1 && (this.m_MaxSkillList >> num31 & 1) == 0 && this.checkInitUltra(num31))
					{
						if (this.IsType(EBattleType.NEWBIE_FAKE))
						{
							this.NewbieUltraTimes += 1;
						}
						if (this.NewbieUltraTimes > 1)
						{
							this.UltraNewbieDelay = new float?(0.85f);
							Time.timeScale = 0.5f;
						}
						else
						{
							this.inputUltra(false, null);
						}
					}
				}
			}
			float num33;
			if (this.fixMoveDeltaTime + smoothDeltaTime > 1f)
			{
				float num32 = 1f - this.fixMoveDeltaTime;
				num32 = Mathf.Max(0f, num32);
				num33 = num32 + num;
			}
			else
			{
				this.fixMoveDeltaTime += smoothDeltaTime;
				num33 = smoothDeltaTime + num;
			}
			num33 = Mathf.Min(num33, 0.1f);
			if (this.canMoveDeltaTime <= 0f)
			{
				num33 = 0f;
			}
			else if (this.canMoveDeltaTime < num33)
			{
				num33 = this.canMoveDeltaTime;
				this.canMoveDeltaTime = 0f;
			}
			else
			{
				this.canMoveDeltaTime -= num33;
			}
			for (int num34 = 0; num34 < this.playerCount; num34++)
			{
				this.playerUnit[num34].MovingDeltaTime = num33;
			}
			for (int num35 = 0; num35 < this.enemyCount; num35++)
			{
				this.enemyUnit[num35].MovingDeltaTime = num33;
			}
		}
		ChaseManager.Instance.Update();
		RewardManager.getInstance.Update(smoothDeltaTime);
		this.BCamera.updateCamera(this.playerUnit, this.playerCount, this.enemyUnit, this.enemyCount);
	}

	// Token: 0x06000883 RID: 2179 RVA: 0x000ACCCC File Offset: 0x000AAECC
	public bool IsType(EBattleType type)
	{
		return this.BattleType == type;
	}

	// Token: 0x06000884 RID: 2180 RVA: 0x000ACCD8 File Offset: 0x000AAED8
	private void updateSkillState(bool ignoreSkin = false)
	{
		bool flag = (this.m_StateUpdateFlag & 1023UL) != 0UL;
		bool flag2 = this.m_StateUpdateFlag >> 10 != 0UL;
		if (flag)
		{
			for (int i = 0; i < this.playerCount; i++)
			{
				ulong num = this.m_StateUpdateFlag >> i;
				if (num == 0UL)
				{
					break;
				}
				if ((num & 1UL) != 0UL)
				{
					GUIManager.Instance.pDVMgr.CheckBuffIcon(0, (byte)i);
					if (!ignoreSkin)
					{
						if (this.playerUnit[i].StateColorSkin != 0u && this.playerUnit[i].StateColorSkin <= 4u)
						{
							this.playerUnit[i].getRenderer.lightmapIndex = this.m_SkinColorLightmapIndex[(int)((UIntPtr)(this.playerUnit[i].StateColorSkin - 1u))];
						}
						else if (!this.IsMaxSkillWorking)
						{
							this.playerUnit[i].getRenderer.lightmapIndex = -1;
						}
					}
				}
			}
		}
		if (flag2)
		{
			for (int j = 0; j < this.enemyCount; j++)
			{
				ulong num2 = this.m_StateUpdateFlag >> j + 10;
				if (num2 == 0UL)
				{
					break;
				}
				if ((num2 & 1UL) != 0UL)
				{
					GUIManager.Instance.pDVMgr.CheckBuffIcon(1, (byte)j);
					if (!ignoreSkin)
					{
						if (this.enemyUnit[j].StateColorSkin != 0u && this.enemyUnit[j].StateColorSkin <= 4u)
						{
							this.enemyUnit[j].getRenderer.lightmapIndex = this.m_SkinColorLightmapIndex[(int)((UIntPtr)(this.enemyUnit[j].StateColorSkin - 1u))];
						}
						else if (!this.IsMaxSkillWorking)
						{
							this.enemyUnit[j].getRenderer.lightmapIndex = -1;
						}
					}
				}
			}
		}
	}

	// Token: 0x06000885 RID: 2181 RVA: 0x000ACEB0 File Offset: 0x000AB0B0
	private unsafe void caleHeroNewPosition(AnimationUnit[] au, int count)
	{
		int* ptr;
		int* ptr2;
		int i;
		checked
		{
			ptr = stackalloc int[count * 4];
			ptr2 = stackalloc int[count * 4];
			i = 0;
		}
		while (i < count)
		{
			Vector3 position = au[i].Position;
			int num = 2 * Mathf.CeilToInt(position.x / 2f);
			int num2 = 2 * Mathf.RoundToInt(position.z / 2f);
			int num3 = 0;
			int num4 = 0;
			int num5 = num;
			int num6 = num2;
			for (;;)
			{
				if (ptr[num3] == num && ptr2[num3] == num2)
				{
					if (num4 > 7)
					{
						goto Block_3;
					}
					num = num5 + (int)this.F_SpreadOffset[num4].x;
					num2 = num6 + (int)this.F_SpreadOffset[num4].y;
					num4++;
					num3 = 0;
				}
				else
				{
					num3++;
					if (num3 >= i)
					{
						break;
					}
				}
			}
			IL_DD:
			ptr[i] = num;
			ptr2[i] = num2;
			position.x = (float)num;
			position.z = (float)(num2 + UnityEngine.Random.Range(-1, 1));
			position.x = ((position.x >= 0f) ? position.x : 0f);
			position.y = 0f;
			au[i].TargetPos = position;
			i++;
			continue;
			Block_3:
			num = num5;
			num2 = num6;
			goto IL_DD;
		}
	}

	// Token: 0x06000886 RID: 2182 RVA: 0x000AD010 File Offset: 0x000AB210
	public void SetSceneGameObjectName(byte SceneID, UnityEngine.Object SceneObj)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0}_m1", SceneID.ToString("d3"));
		this.mapObject1 = ((GameObject)SceneObj).transform.FindChild(stringBuilder.ToString());
		stringBuilder.Length = 0;
		stringBuilder.AppendFormat("{0}_m2", SceneID.ToString("d3"));
		this.mapObject2 = ((GameObject)SceneObj).transform.FindChild(stringBuilder.ToString());
	}

	// Token: 0x06000887 RID: 2183 RVA: 0x000AD094 File Offset: 0x000AB294
	private void decodeHeroAttribute(byte[] RecvBufferLeft, byte[] RecvBufferRight)
	{
		int num = (int)((RecvBufferLeft[0] <= RecvBufferRight[0]) ? RecvBufferRight[0] : RecvBufferLeft[0]);
		int num2 = 1;
		int num3 = 1;
		byte[] array = RecvBufferLeft;
		byte[] array2 = RecvBufferRight;
		if (BattleController.IsPVPDefSide)
		{
			array = RecvBufferRight;
			array2 = RecvBufferLeft;
		}
		byte b = 0;
		if (this.IsType(EBattleType.GAMBLE))
		{
			if (BattleController.GambleMode == EGambleMode.Normal)
			{
				b = GamblingManager.Instance.m_GambleGameInfo.GambleData[1].Stage;
			}
			else if (BattleController.GambleMode == EGambleMode.Turbo)
			{
				b = GamblingManager.Instance.m_GambleGameInfo.GambleData[0].Stage;
			}
		}
		for (int i = 0; i < num; i++)
		{
			if (i < (int)array[0])
			{
				int num4 = (int)GameConstants.ConvertBytesToUShort(array, num2);
				num2 += 2;
				this.playerAttr[num4].MAX_HP = GameConstants.ConvertBytesToUInt(array, num2);
				num2 += 4;
				this.playerAttr[num4].CUR_HP = GameConstants.ConvertBytesToUInt(array, num2);
				num2 += 4;
				this.playerAttr[num4].CUR_MP = (uint)GameConstants.ConvertBytesToUShort(array, num2);
				num2 += 2;
				this.playerAttr[num4].MAX_MP = 1000u;
				byte b2 = array[num2];
				num2++;
				if (this.playerAttr[num4].CUR_HP == 0u)
				{
					this.playerUnit[num4].gameObject.SetActive(false);
				}
			}
			if (i < (int)array2[0])
			{
				int num5 = (int)GameConstants.ConvertBytesToUShort(array2, num3);
				num3 += 2;
				this.enemyAttr[num5].MAX_HP = GameConstants.ConvertBytesToUInt(array2, num3);
				num3 += 4;
				this.enemyAttr[num5].CUR_HP = GameConstants.ConvertBytesToUInt(array2, num3);
				num3 += 4;
				this.enemyAttr[num5].CUR_MP = (uint)GameConstants.ConvertBytesToUShort(array2, num3);
				num3 += 2;
				byte b3 = array2[num3];
				num3++;
				if (this.IsType(EBattleType.GAMBLE) && b > 10)
				{
					if (num5 == 0)
					{
						this.BSUtil.CasinoModeInput(3);
						b3 = 0;
					}
					else if (num5 == 1)
					{
						b3 = 1;
						this.bIgnoreSupport = true;
					}
				}
				if (b3 == 0)
				{
					this.enemyUnit[num5].gameObject.SetActive(false);
				}
				else if (this.IsType(EBattleType.GAMBLE))
				{
					bool flag = false;
					if (num5 == 0)
					{
						if (BattleController.GambleMode == EGambleMode.Normal)
						{
							this.enemyUnit[num5].setState(HERO_STATE_ENUM.HERO_COMMANDS_GOT_STATE, null, 300, 1, 0);
							flag = true;
						}
						else if (BattleController.GambleMode == EGambleMode.Turbo)
						{
							this.enemyUnit[num5].setState(HERO_STATE_ENUM.HERO_COMMANDS_GOT_STATE, null, 301, 1, 0);
							flag = true;
						}
					}
					else if (num5 == 1)
					{
						this.enemyUnit[num5].setState(HERO_STATE_ENUM.HERO_COMMANDS_GOT_STATE, null, 303, 1, 0);
					}
					if (flag)
					{
						ulong num6 = (ulong)(1L << (10 + num5 & 31));
						this.m_StateUpdateFlag |= num6;
					}
				}
			}
		}
	}

	// Token: 0x06000888 RID: 2184 RVA: 0x000AD38C File Offset: 0x000AB58C
	private ushort loadBattleInfo()
	{
		Level level;
		if (this.IsType(EBattleType.NEWBIE_FAKE))
		{
			this.m_MaxStageLevel = 1;
			this.teamTable[0] = DataManager.Instance.TeamTable.GetRecordByKey(578);
			this.teamTable[1] = DataManager.Instance.TeamTable.GetRecordByKey(577);
			level = default(Level);
		}
		else if (this.IsType(EBattleType.PLAYBACK) || this.IsType(EBattleType.GAMBLE))
		{
			this.m_MaxStageLevel = 1;
			this.teamTable[0] = DataManager.Instance.TeamTable.GetRecordByKey(DataManager.Instance.battleInfo.StageID);
			level = default(Level);
		}
		else if (this.IsType(EBattleType.PVP))
		{
			this.m_MaxStageLevel = 1;
			level = default(Level);
		}
		else
		{
			ushort inKey;
			LevelTableKind levelTableKind = DataManager.StageDataController.GetcurrentPointLevelID(out inKey, 0);
			level = DataManager.StageDataController.LevelTable[(int)levelTableKind].GetRecordByKey(inKey);
			int num = 0;
			if (BattleController.IsDareMode && DataManager.StageDataController.StageDareMode(DataManager.StageDataController.currentPointID) == StageMode.Full)
			{
				num = (int)DataManager.StageDataController.GetLevelEXBycurrentPointID(0).NodusOneID;
			}
			for (int i = 0; i < 3; i++)
			{
				if (level.Team[i] != 0)
				{
					this.teamTable[i] = DataManager.Instance.TeamTable.GetRecordByKey((ushort)((int)level.Team[i] + num));
					this.m_MaxStageLevel++;
				}
			}
			bool flag = true;
			ushort currentPointID = DataManager.StageDataController.currentPointID;
			byte stageMode = (byte)DataManager.StageDataController._stageMode;
			if (currentPointID != 0 && currentPointID > DataManager.StageDataController.StageRecord[(int)stageMode])
			{
				flag = false;
			}
			this.DramaTriggerFlag = (uint)((!flag) ? ((int)level.TalkAfter << 16 | (int)level.TalkBefore) : 0);
			if (this.DramaTriggerFlag != 0u)
			{
				if (BattleNetwork.bStageFirstTry[(int)stageMode])
				{
					BattleNetwork.bStageFirstTry[(int)stageMode] = false;
				}
				else
				{
					this.DramaTriggerFlag &= 4294901760u;
				}
				if (BattleController.IsDareMode)
				{
					this.DramaTriggerFlag = 0u;
				}
			}
		}
		this.loadHeroInfo(0);
		this.m_CurStageLevel = 1;
		this.initRewardData();
		this.enemyAliveCount = this.enemyCount;
		this.totalAliveCount = this.enemyCount + this.playerCount;
		this.totalDieAliveRate = 1f;
		this.hitSoundRateBase = 20 + this.totalAliveCount;
		this.hitSoundTriggerRate = this.hitSoundRateBase;
		ushort result = 1;
		if (this.IsType(EBattleType.PLAYBACK))
		{
			MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(GUIManager.Instance.WM_MonsterID);
			if (recordByKey.StageID != 0)
			{
				result = recordByKey.StageID;
			}
		}
		else if (this.IsType(EBattleType.GAMBLE))
		{
			MapMonster recordByKey2 = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(GamblingManager.Instance.BattleMonsterID);
			if (recordByKey2.StageID != 0)
			{
				result = recordByKey2.StageID;
			}
		}
		else if (this.IsType(EBattleType.PVP))
		{
			long num2 = ArenaManager.Instance.ArenaPlayingData.Time & 1L;
			if (num2 != 0L)
			{
				result = 999;
			}
			else
			{
				result = 998;
			}
		}
		else if (!this.IsType(EBattleType.NEWBIE_FAKE))
		{
			result = level.LevelInfoNo;
		}
		return result;
	}

	// Token: 0x06000889 RID: 2185 RVA: 0x000AD718 File Offset: 0x000AB918
	private void loadHeroInfo(int curLevelIdx)
	{
		if (this.IsType(EBattleType.NEWBIE_FAKE))
		{
			Array.Clear(DataManager.Instance.heroBattleData, 0, 5);
			DataManager.Instance.heroCount = 0;
			ushort num = 0;
			HeroArray recordByKey = DataManager.Instance.ArrayTable.GetRecordByKey(this.teamTable[1].ArrayID);
			for (int i = 0; i < 20; i++)
			{
				ushort hero = this.teamTable[1].Arrays[i].Hero;
				byte type = this.teamTable[1].Arrays[i].Type;
				if (hero != 0)
				{
					float posX = (float)recordByKey.HeroArrayInfo[i].posX * 0.01f;
					float posY = (float)recordByKey.HeroArrayInfo[i].posY * 0.01f;
					this.tempBattleData.AttrData.Enhance = this.teamTable[1].HeroClass;
					this.tempBattleData.AttrData.Star = this.teamTable[1].HeroStar;
					this.tempBattleData.AttrData.Equip = 0;
					this.tempBattleData.AttrData.LV = this.teamTable[1].HeroLevel;
					this.tempBattleData.AttrData.SkillLV1 = this.teamTable[1].HeroLevel;
					this.tempBattleData.AttrData.SkillLV2 = this.teamTable[1].HeroLevel;
					this.tempBattleData.AttrData.SkillLV3 = this.teamTable[1].HeroLevel;
					this.tempBattleData.AttrData.SkillLV4 = this.teamTable[1].HeroLevel;
					this.initHero(0, num, hero, posX, posY, 0, 2);
					DataManager.Instance.heroBattleData[i].HeroID = hero;
					DataManager.Instance.heroBattleData[i].AttrData = this.tempBattleData.AttrData;
					DataManager instance = DataManager.Instance;
					instance.heroCount += 1;
					num += 1;
				}
			}
			this.playerCount = (int)num;
			ushort num2 = 0;
			HeroArray recordByKey2 = DataManager.Instance.ArrayTable.GetRecordByKey(this.teamTable[0].ArrayID);
			for (int j = 0; j < 20; j++)
			{
				ushort hero2 = this.teamTable[0].Arrays[j].Hero;
				byte type2 = this.teamTable[0].Arrays[j].Type;
				if (hero2 != 0)
				{
					float posX2 = (float)recordByKey2.HeroArrayInfo[j].posX * 0.01f;
					float posY2 = (float)recordByKey2.HeroArrayInfo[j].posY * 0.01f;
					this.tempBattleData.AttrData.Enhance = this.teamTable[0].HeroClass;
					this.tempBattleData.AttrData.Star = this.teamTable[0].HeroStar;
					this.tempBattleData.AttrData.Equip = 0;
					this.tempBattleData.AttrData.LV = this.teamTable[0].HeroLevel;
					this.tempBattleData.AttrData.SkillLV1 = this.teamTable[0].HeroLevel;
					this.tempBattleData.AttrData.SkillLV2 = this.teamTable[0].HeroLevel;
					this.tempBattleData.AttrData.SkillLV3 = this.teamTable[0].HeroLevel;
					this.tempBattleData.AttrData.SkillLV4 = this.teamTable[0].HeroLevel;
					this.initHero(1, num2, hero2, posX2, posY2, type2, 2);
					num2 += 1;
				}
			}
			this.enemyCount = (int)num2;
		}
		else if (this.IsType(EBattleType.PVP))
		{
			ushort num3 = (!BattleController.IsPVPDefSide) ? 1 : 2;
			ushort inKey = (num3 != 1) ? 1 : 2;
			HeroArray recordByKey3 = DataManager.Instance.ArrayTable.GetRecordByKey(num3);
			for (int k = 0; k < this.playerCount; k++)
			{
				float posX3 = (float)recordByKey3.HeroArrayInfo[k].posX * 0.01f;
				float posY3 = (float)recordByKey3.HeroArrayInfo[k].posY * 0.01f;
				this.tempBattleData.AttrData = this.heroBattleData[k].AttrData;
				this.initHero(0, (ushort)k, this.heroBattleData[k].HeroID, posX3, posY3, 0, 3);
			}
			HeroArray recordByKey4 = DataManager.Instance.ArrayTable.GetRecordByKey(inKey);
			for (int l = 0; l < this.enemyCount; l++)
			{
				HeroBattleData heroBattleData = ArenaManager.Instance.ArenaPlayingData.EnemyHeroData[l];
				ushort heroID = heroBattleData.HeroID;
				if (heroID != 0)
				{
					float posX4 = (float)recordByKey4.HeroArrayInfo[l].posX * 0.01f;
					float posY4 = (float)recordByKey4.HeroArrayInfo[l].posY * 0.01f;
					this.tempBattleData.AttrData = heroBattleData.AttrData;
					this.initHero(1, (ushort)l, heroID, posX4, posY4, 0, 3);
				}
			}
		}
		else
		{
			byte bSetupSim = (curLevelIdx != 0) ? 0 : 1;
			HeroArray recordByKey5 = DataManager.Instance.ArrayTable.GetRecordByKey(1);
			int num4 = 0;
			float num5 = (float)this.teamTable[curLevelIdx].ShiftX * 0.01f;
			for (int m = 0; m < this.playerCount; m++)
			{
				float num6 = 0f;
				float posY5 = 0f;
				if (curLevelIdx > 0 && this.playerUnit != null && this.playerUnit[m] != null)
				{
					if (this.playerUnit[m].heroState == HERO_STATE_ENUM.HERO_COMMANDS_DIE)
					{
						num4++;
					}
					else
					{
						int num7 = m - num4;
						num6 = (float)recordByKey5.HeroArrayInfo[num7].posX * 0.01f + num5;
						posY5 = (float)recordByKey5.HeroArrayInfo[num7].posY * 0.01f;
					}
				}
				else
				{
					num6 = (float)recordByKey5.HeroArrayInfo[m].posX * 0.01f + num5;
					posY5 = (float)recordByKey5.HeroArrayInfo[m].posY * 0.01f;
					if (this.playerUnit != null && this.playerUnit[m] != null)
					{
						this.playerUnit[m].resetComponent();
						this.playerUnit[m].gameObject.SetActive(true);
					}
				}
				if (m == 0)
				{
					this.FirstPlayerPosX = num6;
				}
				this.initHero(0, (ushort)m, this.heroBattleData[m].HeroID, num6, posY5, 0, bSetupSim);
			}
			ushort num8 = 0;
			HeroArray recordByKey6 = DataManager.Instance.ArrayTable.GetRecordByKey(this.teamTable[curLevelIdx].ArrayID);
			for (int n = 0; n < 20; n++)
			{
				ushort hero3 = this.teamTable[curLevelIdx].Arrays[n].Hero;
				byte type3 = this.teamTable[curLevelIdx].Arrays[n].Type;
				if (hero3 != 0)
				{
					float posX5 = (float)recordByKey6.HeroArrayInfo[n].posX * 0.01f;
					float posY6 = (float)recordByKey6.HeroArrayInfo[n].posY * 0.01f;
					this.initHero(1, num8, hero3, posX5, posY6, type3, 1);
					num8 += 1;
				}
			}
			this.enemyCount = (int)num8;
		}
		if (this.BattleType == EBattleType.PLAYBACK)
		{
			GUIManager instance2 = GUIManager.Instance;
			this.BSUtil.SetMonsterHP(instance2.WM_MonsterMaxHP, instance2.WM_MonsterNowHP);
			this.BSUtil.SetMonsterAttrData(ref instance2.WM_MonsterAttr);
		}
		else if (this.IsType(EBattleType.GAMBLE))
		{
			this.BSUtil.SetMonsterHP(100u, 100u);
		}
		int count = this.m_HeroTemp.Count;
		if (count > 0)
		{
			this.m_HeroTemp.Keys.CopyTo(this.m_HeroIDFilter, 0);
			for (int num9 = 0; num9 < count; num9++)
			{
				if (this.m_HeroTemp[this.m_HeroIDFilter[num9]] != null)
				{
					ModelLoader.Instance.Unload(this.m_HeroTemp[this.m_HeroIDFilter[num9]]);
					this.m_HeroTemp.Remove(this.m_HeroIDFilter[num9]);
					int key = this.m_HeroIDFilter[num9] & 65535;
					BattleController.HeroRef value = this.m_HeroMap[key];
					value.refCount -= 1;
					this.m_HeroMap[key] = value;
				}
			}
		}
		if (!this.IsType(EBattleType.PVP))
		{
			ParticleManager.Instance.PreLoadEnemyEffect(this.m_MaxStageLevel - 1);
		}
	}

	// Token: 0x0600088A RID: 2186 RVA: 0x000AE094 File Offset: 0x000AC294
	public bool NextLevel()
	{
		if (this.m_CurStageLevel >= this.m_MaxStageLevel || this.m_BattleResult != 1)
		{
			return false;
		}
		this.m_CurStageLevel++;
		this.m_IDFilterCount = 0;
		int num = (this.playerCount <= this.enemyCount) ? this.enemyCount : this.playerCount;
		for (int i = 0; i < num; i++)
		{
			if (i < this.playerCount)
			{
				this.playerUnit[i].resetComponent();
			}
			if (i < this.enemyCount)
			{
				ushort npcID = this.enemyUnit[i].NpcID;
				Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(npcID);
				BattleController.HeroRef value = this.m_HeroMap[(int)recordByKey.Modle];
				value.activeCount -= 1;
				this.m_HeroMap[(int)recordByKey.Modle] = value;
				int key = (int)value.activeCount << 16 | (int)recordByKey.Modle;
				this.enemyUnit[i].resetComponent();
				this.m_HeroTemp.Add(key, this.enemyUnit[i].gameObject);
			}
		}
		HeroTeamAttribute[] arrays = this.teamTable[this.m_CurStageLevel - 1].Arrays;
		this.m_HeroMap.Keys.CopyTo(this.m_HeroIDFilter, 0);
		num = this.m_HeroMap.Count;
		for (int j = 0; j < num; j++)
		{
			ushort num2 = 0;
			for (int k = 0; k < 20; k++)
			{
				ushort hero = arrays[k].Hero;
				if (hero != 0)
				{
					Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(hero);
					if (this.m_HeroIDFilter[j] == (int)recordByKey2.Modle)
					{
						num2 += 1;
					}
				}
			}
			BattleController.HeroRef value2 = this.m_HeroMap[this.m_HeroIDFilter[j]];
			if (num2 > 0)
			{
				for (short num3 = value2.refCount; num3 > (short)(num2 + (ushort)value2.activeCount); num3 -= 1)
				{
					int key2 = (int)(num3 - 1) << 16 | (int)((ushort)this.m_HeroIDFilter[j]);
					if (this.m_HeroTemp.ContainsKey(key2))
					{
						GameObject gameObject = this.m_HeroTemp[key2] as GameObject;
						gameObject.SetActive(true);
						ModelLoader.Instance.Unload(gameObject);
						this.m_HeroTemp.Remove(key2);
					}
				}
			}
			else
			{
				short refCount = value2.refCount;
				for (short num4 = value2.activeCount; num4 < refCount; num4 += 1)
				{
					int key3 = (int)num4 << 16 | (int)((ushort)this.m_HeroIDFilter[j]);
					if (this.m_HeroTemp.ContainsKey(key3))
					{
						GameObject gameObject2 = this.m_HeroTemp[key3] as GameObject;
						gameObject2.SetActive(true);
						ModelLoader.Instance.Unload(gameObject2);
						this.m_HeroTemp.Remove(key3);
						value2.refCount -= 1;
						this.m_HeroMap[this.m_HeroIDFilter[j]] = value2;
					}
				}
				if (value2.refCount <= 0)
				{
					this.m_HeroMap.Remove(this.m_HeroIDFilter[j]);
					AssetManager.UnloadAssetBundle(value2.assetKey, true);
				}
			}
		}
		Array.Clear(this.enemyUnit, 0, 20);
		Array.Clear(this.enemyAttr, 0, 20);
		Array.Clear(BattleController.m_MaxSkillIdTemp, 0, 5);
		this.m_MaxSkillWorkingList = 0;
		this.m_MaxSkillList = 0;
		this.m_BattleResult = 0;
		this.m_ui32Tcik = 0u;
		this.deltaTime = 0f;
		this.autoBattleDeltaTime = 0f;
		this.fixMoveDeltaTime = 0f;
		this.m_StateUpdateFlag = 0UL;
		this.IsBattleEnd = false;
		this.m_SubStateFlag = 0;
		ChaseManager.Instance.Clear();
		ParticleManager.Instance.ClearOnecEffect();
		if (this.ultraHitSoundKey != 255)
		{
			AudioManager.Instance.StopSFX(this.ultraHitSoundKey, true);
			this.ultraHitSoundKey = byte.MaxValue;
		}
		AssetManager.LoadStage((byte)this.m_CurStageLevel, ref this.mapObject1, ref this.mapObject2);
		this.loadHeroInfo(this.m_CurStageLevel - 1);
		this.decodeHeroAttribute(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
		this.BCamera.initCamera(this.playerUnit, this.playerCount, this.enemyUnit, this.enemyCount);
		GUIManager.Instance.pDVMgr.NextFightStage();
		GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
		Array.Clear(this.m_HeroIDFilter, 0, 25);
		this.m_IDFilterCount = 0;
		this.initRewardData();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 10, this.m_CurStageLevel);
		this.enemyAliveCount = this.enemyCount;
		this.totalAliveCount = this.enemyCount;
		for (int l = 0; l < this.playerCount; l++)
		{
			if (this.playerUnit[l] != null && this.playerUnit[l].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
			{
				this.totalAliveCount++;
			}
		}
		this.totalDieAliveRate = (float)(this.totalAliveCount / (this.enemyCount + this.playerCount));
		this.hitSoundRateBase = 20 + this.totalAliveCount;
		this.hitSoundTriggerRate = this.hitSoundRateBase;
		int num5 = 5;
		for (int m = 0; m < 4; m++)
		{
			this.m_SkinColorLightmapIndex[m] = LightmapManager.Instance.GetLightmapIndex((Lightmap_Enum)(num5 + m));
			this.m_SkinColorLightmapTex[m] = LightmapManager.Instance.GetLightmapTexture((Lightmap_Enum)(num5 + m));
		}
		this.CasinoHitDirty = false;
		this.m_BattleState = BattleController.BattleState.WAITING_FOR_START;
		this.NextLevelWorking = false;
		return true;
	}

	// Token: 0x0600088B RID: 2187 RVA: 0x000AE658 File Offset: 0x000AC858
	public bool ResetLevel()
	{
		this.uiBattle.InterruptInput();
		this.updateMaxSkillFreeze(false);
		this.UpdateSkillLightmap(false, true);
		this.m_CurStageLevel = 1;
		this.m_IDFilterCount = 0;
		int num = this.enemyCount;
		this.enemyCount = 0;
		int num2 = (this.playerCount <= num) ? num : this.playerCount;
		for (int i = 0; i < num2; i++)
		{
			if (i < this.playerCount)
			{
				this.playerUnit[i].resetComponent();
			}
			if (i < num)
			{
				ushort npcID = this.enemyUnit[i].NpcID;
				Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(npcID);
				BattleController.HeroRef value = this.m_HeroMap[(int)recordByKey.Modle];
				value.activeCount -= 1;
				this.m_HeroMap[(int)recordByKey.Modle] = value;
				int key = (int)value.activeCount << 16 | (int)recordByKey.Modle;
				this.enemyUnit[i].resetComponent();
				this.m_HeroTemp.Add(key, this.enemyUnit[i].gameObject);
			}
		}
		HeroTeamAttribute[] arrays = this.teamTable[this.m_CurStageLevel - 1].Arrays;
		this.m_HeroMap.Keys.CopyTo(this.m_HeroIDFilter, 0);
		num2 = this.m_HeroMap.Count;
		for (int j = 0; j < num2; j++)
		{
			ushort num3 = 0;
			for (int k = 0; k < 20; k++)
			{
				ushort hero = arrays[k].Hero;
				if (hero != 0)
				{
					Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(hero);
					if (this.m_HeroIDFilter[j] == (int)recordByKey2.Modle)
					{
						num3 += 1;
					}
				}
			}
			BattleController.HeroRef value2 = this.m_HeroMap[this.m_HeroIDFilter[j]];
			if (num3 > 0)
			{
				for (short num4 = value2.refCount; num4 > (short)(num3 + (ushort)value2.activeCount); num4 -= 1)
				{
					int key2 = (int)(num4 - 1) << 16 | (int)((ushort)this.m_HeroIDFilter[j]);
					if (this.m_HeroTemp.ContainsKey(key2))
					{
						GameObject gameObject = this.m_HeroTemp[key2] as GameObject;
						gameObject.SetActive(true);
						ModelLoader.Instance.Unload(gameObject);
						this.m_HeroTemp.Remove(key2);
					}
				}
			}
			else
			{
				short refCount = value2.refCount;
				for (short num5 = value2.activeCount; num5 < refCount; num5 += 1)
				{
					int key3 = (int)num5 << 16 | (int)((ushort)this.m_HeroIDFilter[j]);
					if (this.m_HeroTemp.ContainsKey(key3))
					{
						GameObject gameObject2 = this.m_HeroTemp[key3] as GameObject;
						gameObject2.SetActive(true);
						ModelLoader.Instance.Unload(gameObject2);
						this.m_HeroTemp.Remove(key3);
						value2.refCount -= 1;
						this.m_HeroMap[this.m_HeroIDFilter[j]] = value2;
					}
				}
				if (value2.refCount <= 0)
				{
					this.m_HeroMap.Remove(this.m_HeroIDFilter[j]);
					AssetManager.UnloadAssetBundle(value2.assetKey, true);
				}
			}
		}
		Array.Clear(this.enemyUnit, 0, 20);
		Array.Clear(this.enemyAttr, 0, 20);
		Array.Clear(BattleController.BufferForServer, 0, 1024);
		Array.Clear(BattleController.m_MaxSkillIdTemp, 0, 5);
		this.m_MaxSkillWorkingList = 0;
		this.m_MaxSkillList = 0;
		this.m_BattleResult = 0;
		this.m_ui32Tcik = 0u;
		this.deltaTime = 0f;
		this.autoBattleDeltaTime = 0f;
		this.fixMoveDeltaTime = 0f;
		this.m_StateUpdateFlag = 0UL;
		this.IsBattleEnd = false;
		this.m_SubStateFlag = 0;
		ChaseManager.Instance.Clear();
		ParticleManager.Instance.ClearOnecEffect();
		if (this.ultraHitSoundKey != 255)
		{
			AudioManager.Instance.StopSFX(this.ultraHitSoundKey, true);
			this.ultraHitSoundKey = byte.MaxValue;
		}
		this.BSUtil.SetUserData(DataManager.Instance.RoleAttr.UserId, DataManager.Instance.BattleSeqID);
		this.BSUtil.InitSimulator(ref DataManager.Instance.battleInfo);
		DataManager.Instance.lastBattleResult = -1;
		AssetManager.LoadStage((byte)this.m_CurStageLevel, ref this.mapObject1, ref this.mapObject2);
		this.loadHeroInfo(this.m_CurStageLevel - 1);
		this.CheckSetDareDifficulty();
		this.BSUtil.setHeroOver(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
		this.decodeHeroAttribute(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
		this.BCamera.initCamera(this.playerUnit, this.playerCount, this.enemyUnit, this.enemyCount);
		GUIManager.Instance.pDVMgr.NextFightStage();
		GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
		Array.Clear(this.m_HeroIDFilter, 0, 25);
		this.m_IDFilterCount = 0;
		this.m_RewardOffset = 0;
		RewardManager.getInstance.Clear();
		this.initRewardData();
		for (int l = 0; l < 5; l++)
		{
			this.ms_viewer[l] = default(BattleController.MSNode);
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 0, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 1, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 8, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 10, 1);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 11, 0);
		this.enemyAliveCount = this.enemyCount;
		this.totalAliveCount = this.enemyCount + this.playerCount;
		this.totalDieAliveRate = 1f;
		this.hitSoundRateBase = 20 + this.totalAliveCount;
		this.hitSoundTriggerRate = this.hitSoundRateBase;
		this.CasinoHitDirty = false;
		this.m_BattleState = BattleController.BattleState.WAITING_FOR_START;
		this.NextLevelWorking = false;
		return true;
	}

	// Token: 0x0600088C RID: 2188 RVA: 0x000AEC4C File Offset: 0x000ACE4C
	public void CheckSetDareDifficulty()
	{
		StageManager stageDataController = DataManager.StageDataController;
		if (this.IsType(EBattleType.NORMAL) && stageDataController._stageMode == StageMode.Dare)
		{
			LevelEX levelEXBycurrentPointID = stageDataController.GetLevelEXBycurrentPointID(0);
			if (stageDataController.StageDareMode(DataManager.StageDataController.currentPointID) == StageMode.Lean)
			{
				if (stageDataController.currentNodus == 1)
				{
					this.BSUtil.SetHeroChallengeDifficulty(levelEXBycurrentPointID.NodusOneID, 0);
				}
				else if (stageDataController.currentNodus == 2)
				{
					this.BSUtil.SetHeroChallengeDifficulty(levelEXBycurrentPointID.NodusTwoID, 0);
				}
				else if (stageDataController.currentNodus == 3)
				{
					this.BSUtil.SetHeroChallengeDifficulty(levelEXBycurrentPointID.NodusThrID, 0);
				}
			}
			else
			{
				this.BSUtil.SetHeroChallengeDifficulty(levelEXBycurrentPointID.NodusOneID, levelEXBycurrentPointID.NodusTwoID);
			}
		}
	}

	// Token: 0x0600088D RID: 2189 RVA: 0x000AED1C File Offset: 0x000ACF1C
	public void ResetGamble()
	{
		MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(GamblingManager.Instance.BattleMonsterID);
		ushort teamID = recordByKey.MapTeamInfo[0].TeamID;
		DataManager.Instance.battleInfo.StageID = teamID;
		this.teamTable[0] = DataManager.Instance.TeamTable.GetRecordByKey(DataManager.Instance.battleInfo.StageID);
		this.m_CurStageLevel = 1;
		this.m_IDFilterCount = 0;
		int num = (this.playerCount <= this.enemyCount) ? this.enemyCount : this.playerCount;
		for (int i = 0; i < num; i++)
		{
			if (i < this.playerCount)
			{
				this.playerUnit[i].resetComponent();
			}
			if (i < this.enemyCount)
			{
				ushort npcID = this.enemyUnit[i].NpcID;
				Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(npcID);
				BattleController.HeroRef value = this.m_HeroMap[(int)recordByKey2.Modle];
				value.activeCount -= 1;
				this.m_HeroMap[(int)recordByKey2.Modle] = value;
				int key = (int)value.activeCount << 16 | (int)recordByKey2.Modle;
				this.enemyUnit[i].resetComponent();
				this.m_HeroTemp.Add(key, this.enemyUnit[i].gameObject);
			}
		}
		this.teamTable[0] = DataManager.Instance.TeamTable.GetRecordByKey(DataManager.Instance.battleInfo.StageID);
		HeroTeamAttribute[] arrays = this.teamTable[0].Arrays;
		this.m_HeroMap.Keys.CopyTo(this.m_HeroIDFilter, 0);
		num = this.m_HeroMap.Count;
		for (int j = 0; j < num; j++)
		{
			ushort num2 = 0;
			for (int k = 0; k < 20; k++)
			{
				ushort hero = arrays[k].Hero;
				if (hero != 0)
				{
					Hero recordByKey3 = DataManager.Instance.HeroTable.GetRecordByKey(hero);
					if (this.m_HeroIDFilter[j] == (int)recordByKey3.Modle)
					{
						num2 += 1;
					}
				}
			}
			BattleController.HeroRef value2 = this.m_HeroMap[this.m_HeroIDFilter[j]];
			if (num2 > 0)
			{
				for (short num3 = value2.refCount; num3 > (short)(num2 + (ushort)value2.activeCount); num3 -= 1)
				{
					int key2 = (int)(num3 - 1) << 16 | (int)((ushort)this.m_HeroIDFilter[j]);
					if (this.m_HeroTemp.ContainsKey(key2))
					{
						GameObject gameObject = this.m_HeroTemp[key2] as GameObject;
						gameObject.SetActive(true);
						ModelLoader.Instance.Unload(gameObject);
						this.m_HeroTemp.Remove(key2);
					}
				}
			}
			else
			{
				short refCount = value2.refCount;
				for (short num4 = value2.activeCount; num4 < refCount; num4 += 1)
				{
					int key3 = (int)num4 << 16 | (int)((ushort)this.m_HeroIDFilter[j]);
					if (this.m_HeroTemp.ContainsKey(key3))
					{
						GameObject gameObject2 = this.m_HeroTemp[key3] as GameObject;
						gameObject2.SetActive(true);
						ModelLoader.Instance.Unload(gameObject2);
						this.m_HeroTemp.Remove(key3);
						value2.refCount -= 1;
						this.m_HeroMap[this.m_HeroIDFilter[j]] = value2;
					}
				}
				if (value2.refCount <= 0)
				{
					this.m_HeroMap.Remove(this.m_HeroIDFilter[j]);
					AssetManager.UnloadAssetBundle(value2.assetKey, true);
				}
			}
		}
		Array.Clear(this.enemyUnit, 0, 20);
		Array.Clear(this.enemyAttr, 0, 20);
		Array.Clear(BattleController.m_MaxSkillIdTemp, 0, 5);
		this.m_MaxSkillWorkingList = 0;
		this.m_MaxSkillList = 0;
		this.m_BattleResult = 0;
		this.m_ui32Tcik = 0u;
		this.deltaTime = 0f;
		this.autoBattleDeltaTime = 0f;
		this.fixMoveDeltaTime = 0f;
		this.m_StateUpdateFlag = 0UL;
		this.IsBattleEnd = false;
		this.m_SubStateFlag = 0;
		ChaseManager.Instance.Clear();
		ParticleManager.Instance.ClearOnecEffect();
		if (this.ultraHitSoundKey != 255)
		{
			AudioManager.Instance.StopSFX(this.ultraHitSoundKey, true);
			this.ultraHitSoundKey = byte.MaxValue;
		}
		this.BSUtil.SetUserData(DataManager.Instance.RoleAttr.UserId, DataManager.Instance.BattleSeqID);
		this.BSUtil.InitSimulator(ref DataManager.Instance.battleInfo);
		DataManager.Instance.lastBattleResult = -1;
		if (recordByKey.StageID != this.CurrentStageID)
		{
			AssetManager.QuitScene();
			AssetManager.LoadScene(recordByKey.StageID);
			this.CurrentStageID = recordByKey.StageID;
		}
		AssetManager.LoadStage(1, ref this.mapObject1, ref this.mapObject2);
		this.loadHeroInfo(0);
		this.BSUtil.setHeroOver(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
		this.decodeHeroAttribute(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
		this.BCamera.initCamera(this.playerUnit, this.playerCount, this.enemyUnit, this.enemyCount);
		GUIManager.Instance.pDVMgr.NextFightStage();
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 23, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 3, 0);
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 4, 0);
		GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
		Array.Clear(this.m_HeroIDFilter, 0, 25);
		this.m_IDFilterCount = 0;
		RewardManager.getInstance.Clear();
		this.enemyAliveCount = this.enemyCount;
		this.totalAliveCount = this.enemyCount;
		for (int l = 0; l < this.playerCount; l++)
		{
			if (this.playerUnit[l] != null && this.playerUnit[l].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
			{
				this.totalAliveCount++;
			}
		}
		this.totalDieAliveRate = (float)(this.totalAliveCount / (this.enemyCount + this.playerCount));
		this.hitSoundRateBase = 20 + this.totalAliveCount;
		this.hitSoundTriggerRate = this.hitSoundRateBase;
		int num5 = 5;
		for (int m = 0; m < 4; m++)
		{
			this.m_SkinColorLightmapIndex[m] = LightmapManager.Instance.GetLightmapIndex((Lightmap_Enum)(num5 + m));
			this.m_SkinColorLightmapTex[m] = LightmapManager.Instance.GetLightmapTexture((Lightmap_Enum)(num5 + m));
		}
		this.CasinoHitDirty = false;
		this.m_BattleState = BattleController.BattleState.WAITING_FOR_START;
		this.NextLevelWorking = false;
	}

	// Token: 0x0600088E RID: 2190 RVA: 0x000AF3F0 File Offset: 0x000AD5F0
	private void initHero(ushort side, ushort idx, ushort id, float posX, float posY, byte npcType, byte bSetupSim = 1)
	{
		if (side == 0 && bSetupSim == 1)
		{
			this.BSUtil.setHeroState(side, id, ref this.heroBattleData[(int)idx].AttrData);
		}
		else if (bSetupSim == 2)
		{
			this.BSUtil.setHeroState(side, id, ref this.tempBattleData.AttrData);
		}
		else if (bSetupSim == 3)
		{
			ushort num = side;
			if (BattleController.IsPVPDefSide)
			{
				if (num == 0)
				{
					num = 1;
				}
				else if (num == 1)
				{
					num = 0;
				}
			}
			this.BSUtil.setHeroState(num, id, ref this.tempBattleData.AttrData);
		}
		AnimationUnit[] array = (side != 0) ? this.enemyUnit : this.playerUnit;
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(id);
		if (array[(int)idx] == null)
		{
			if (!this.m_HeroMap.ContainsKey((int)recordByKey.Modle))
			{
				this.StringInstance.Length = 0;
				this.StringInstance.AppendFormat("Role/hero_{0:00000}", recordByKey.Modle);
				int assetKey = 0;
				string text = this.StringInstance.ToString();
				AssetBundle assetBundle = AssetManager.GetAssetBundle(text, out assetKey, false);
				GameObject go = ModelLoader.Instance.Load(recordByKey.Modle, assetBundle, (ushort)recordByKey.TextureNo);
				GameObject gameObject = null;
				this.setupAnimationObject(go, side, idx, id, out gameObject);
				this.HeroRefInstance.Set(assetKey, 1, 1, assetBundle, text);
				this.m_HeroMap.Add((int)recordByKey.Modle, this.HeroRefInstance);
			}
			else
			{
				BattleController.HeroRef value = this.m_HeroMap[(int)recordByKey.Modle];
				GameObject gameObject2 = null;
				bool flag = false;
				if (value.activeCount < value.refCount)
				{
					int key = (int)value.activeCount << 16 | (int)recordByKey.Modle;
					if (this.m_HeroTemp.ContainsKey(key))
					{
						gameObject2 = (GameObject)this.m_HeroTemp[key];
						this.m_HeroTemp.Remove(key);
						flag = true;
					}
				}
				if (!flag)
				{
					AssetBundle ab = (AssetBundle)value.heroObj;
					GameObject go2 = ModelLoader.Instance.Load(recordByKey.Modle, ab, (ushort)recordByKey.TextureNo);
					this.setupAnimationObject(go2, side, idx, id, out gameObject2);
					value.refCount += 1;
				}
				value.activeCount += 1;
				this.m_HeroMap[(int)recordByKey.Modle] = value;
				array[(int)idx] = gameObject2.GetComponent<AnimationUnit>();
				array[(int)idx].gameObject.SetActive(true);
				if (flag)
				{
					SkinnedMeshRenderer componentInChildren = gameObject2.GetComponentInChildren<SkinnedMeshRenderer>();
					if (componentInChildren != null && array[(int)idx].NpcID != id)
					{
						AssetBundle ab2 = (AssetBundle)value.heroObj;
						ModelLoader.Instance.UnloadMaterial(componentInChildren.sharedMaterial);
						componentInChildren.material = ModelLoader.Instance.LoadMaterial(recordByKey.Modle, ab2, (ushort)recordByKey.TextureNo);
					}
				}
			}
		}
		if (array[(int)idx].gameObject.activeSelf)
		{
			array[(int)idx].initComponent(id);
			this.Vec3Instance.Set(posX, 0f, posY);
			Vector3 vec3Instance = this.Vec3Instance;
			array[(int)idx].setPositionInstantly(this.Vec3Instance);
			if (BattleController.IsPVPDefSide)
			{
				if (side == 0)
				{
					this.Vec3Instance.Set(-10000f, vec3Instance.y, vec3Instance.z);
				}
				else
				{
					this.Vec3Instance.Set(10000f, vec3Instance.y, vec3Instance.z);
				}
			}
			else if (side == 0)
			{
				this.Vec3Instance.Set(10000f, vec3Instance.y, vec3Instance.z);
			}
			else
			{
				this.Vec3Instance.Set(this.FirstPlayerPosX, vec3Instance.y, vec3Instance.z);
			}
			array[(int)idx].updateDirection(this.Vec3Instance);
			float num2 = 1.17f;
			num2 = ((recordByKey.Scale == 100) ? num2 : ((float)recordByKey.Scale / 100f * num2));
			if (side == 1 && this.IsType(EBattleType.GAMBLE) && BattleController.GambleMode == EGambleMode.Normal)
			{
				num2 *= 0.7f;
			}
			array[(int)idx].setNpcScale(num2);
			array[(int)idx].IsBoss = (npcType == 3);
			array[(int)idx].IsEnemy = (side != 0);
			if (recordByKey.ResidentEffect != 0)
			{
				array[(int)idx].SetupResidentEffect(recordByKey.ResidentEffect);
			}
			if (array[(int)idx].IsEnemy && array[(int)idx].IsBoss)
			{
				this.MonsterIdxTemp = (int)idx;
			}
		}
	}

	// Token: 0x0600088F RID: 2191 RVA: 0x000AF8AC File Offset: 0x000ADAAC
	private AnimationUnit setupAnimationObject(GameObject go, ushort side, ushort idx, ushort id, out GameObject outGO)
	{
		GameObject gameObject = new GameObject("hero");
		go.name = "AnimationObject";
		go.transform.localPosition = Vector3.zero;
		go.transform.parent = gameObject.transform;
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/shadow", out this.shadowABKey, false);
		GameObject gameObject2 = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
		gameObject2.transform.parent = gameObject.transform;
		MeshFilter component = gameObject2.GetComponent<MeshFilter>();
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(id);
		float num = (float)recordByKey.Scale * 0.01f;
		component.mesh = GameConstants.CreatePlane(go.transform.forward, go.transform.right, new Rect(0f, 0f, 1f, 1f), new Color(1f, 1f, 1f, 0.6f), num * (float)recordByKey.Radius * 0.015f);
		AnimationUnit animationUnit = gameObject.AddComponent<AnimationUnit>();
		animationUnit.pListener = new AnimationUnit.ParentListener(this.EventCallBack);
		animationUnit.Shadow = gameObject2;
		animationUnit.controller = this;
		if (side < 2)
		{
			AnimationUnit[] array = (side != 0) ? this.enemyUnit : this.playerUnit;
			array[(int)idx] = animationUnit;
		}
		outGO = gameObject;
		return animationUnit;
	}

	// Token: 0x06000890 RID: 2192 RVA: 0x000AFA0C File Offset: 0x000ADC0C
	public void useMaxSkill(int side, int idx)
	{
		int num = (side == 0) ? idx : (idx + 5);
		if (num >= 0 && num < 25)
		{
			if (this.m_MaxSkillList == 0)
			{
				this.maxSkillTimeCache = this.deltaTime;
				this.m_BattleState = BattleController.BattleState.BATTLE_MAXSKILL_WORKING;
			}
			this.m_MaxSkillList |= 1 << num;
			this.setMaxSkillWorkingList(num, true, 0);
			if (side == 0)
			{
				this.playerUnit[idx].playMaxSkill();
			}
			else
			{
				this.enemyUnit[idx].playMaxSkill();
			}
			this.updateMaxSkillFreeze(true);
			this.UpdateSkillLightmap(true, false);
		}
	}

	// Token: 0x06000891 RID: 2193 RVA: 0x000AFAAC File Offset: 0x000ADCAC
	public void setMaxSkillWorkingList(int idx, bool bWorking, int skillID = 0)
	{
		if (!bWorking)
		{
			if ((this.m_MaxSkillWorkingList >> idx & 1) != 0)
			{
				this.m_MaxSkillWorkingList ^= 1 << idx;
				BattleController.m_MaxSkillIdTemp[idx] = 0;
			}
		}
		else
		{
			this.m_MaxSkillWorkingList |= 1 << idx;
			BattleController.m_MaxSkillIdTemp[idx] = skillID;
		}
	}

	// Token: 0x06000892 RID: 2194 RVA: 0x000AFB14 File Offset: 0x000ADD14
	private bool isSkillWorking(int idx)
	{
		return (this.m_MaxSkillWorkingList >> idx & 1) != 0;
	}

	// Token: 0x06000893 RID: 2195 RVA: 0x000AFB2C File Offset: 0x000ADD2C
	private void SetTarget(int side, int idx, int tside, int tidx)
	{
		if (side == 0)
		{
			if (tside == 0)
			{
				this.playerUnit[idx].Target = this.playerUnit[tidx].gameObject;
			}
			else
			{
				this.playerUnit[idx].Target = this.enemyUnit[tidx].gameObject;
			}
		}
		else if (tside == 0)
		{
			this.enemyUnit[idx].Target = this.playerUnit[tidx].gameObject;
		}
		else
		{
			this.enemyUnit[idx].Target = this.enemyUnit[tidx].gameObject;
		}
	}

	// Token: 0x06000894 RID: 2196 RVA: 0x000AFBC8 File Offset: 0x000ADDC8
	private bool decodeUltraSkill(byte[] Buffer)
	{
		if (Buffer[0] == 0)
		{
			return false;
		}
		if (this.IsType(EBattleType.PLAYBACK))
		{
			this.decodeSimuPackage(BattleController.RecvBufferLeft, BattleController.RecvBufferRight, 1);
		}
		else if (this.IsType(EBattleType.PVP))
		{
			this.decodeSimuPackage(BattleController.RecvBufferLeft, BattleController.RecvBufferRight, 3);
		}
		int num = 1;
		for (int i = 0; i < (int)Buffer[0]; i++)
		{
			int num2 = (int)Buffer[num];
			num++;
			int idx = (int)GameConstants.ConvertBytesToUShort(Buffer, num);
			num += 2;
			int num3 = (int)Buffer[num];
			num++;
			int tidx = (int)GameConstants.ConvertBytesToUShort(Buffer, num);
			num += 2;
			int num4 = (int)GameConstants.ConvertBytesToUShort(Buffer, num);
			num += 2;
			if (BattleController.IsPVPDefSide)
			{
				num2 = ((num2 != 1) ? 1 : 0);
				num3 = ((num3 != 1) ? 1 : 0);
			}
			this.SetTarget(num2, idx, num3, tidx);
			this.useMaxSkill(num2, idx);
		}
		return true;
	}

	// Token: 0x06000895 RID: 2197 RVA: 0x000AFCAC File Offset: 0x000ADEAC
	private void decodeSimuPackage(byte[] RecvBufferLeft, byte[] RecvBufferRight, int Cmd = 0)
	{
		if (BattleController.IsPVPDefSide)
		{
			this.decodeSimuPackage(RecvBufferRight, 0, Cmd & 5);
			this.decodeSimuPackage(RecvBufferLeft, 1, Cmd & 10);
		}
		else if (this.IsType(EBattleType.PLAYBACK))
		{
			this.decodeSimuPackage(RecvBufferLeft, 0, Cmd);
			this.decodeSimuPackage(RecvBufferRight, 1, Cmd);
		}
		else
		{
			this.decodeSimuPackage(RecvBufferLeft, 0, Cmd & 5);
			this.decodeSimuPackage(RecvBufferRight, 1, Cmd & 10);
		}
	}

	// Token: 0x06000896 RID: 2198 RVA: 0x000AFD1C File Offset: 0x000ADF1C
	private int CheckTargetSide(int side)
	{
		if (BattleController.IsPVPDefSide)
		{
			return (side != 1) ? 1 : 0;
		}
		return side;
	}

	// Token: 0x06000897 RID: 2199 RVA: 0x000AFD38 File Offset: 0x000ADF38
	private bool IsDotOrHot(int EffectID)
	{
		return EffectID == 10 || EffectID == 11 || EffectID == 12 || EffectID == 13 || EffectID == 15 || EffectID == 16 || EffectID == 17;
	}

	// Token: 0x06000898 RID: 2200 RVA: 0x000AFD84 File Offset: 0x000ADF84
	private void decodeSimuPackage(byte[] RecvBuffer, int Side, int Cmd = 0)
	{
		byte b = RecvBuffer[0];
		if (b == 0)
		{
			return;
		}
		AnimationUnit[] array = (Side != 0) ? this.enemyUnit : this.playerUnit;
		int num = 1;
		for (int i = 0; i < (int)b; i++)
		{
			int num2 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
			num += 2;
			int num3 = (int)RecvBuffer[num];
			num++;
			switch ((byte)num3)
			{
			case 0:
			{
				int side = (int)RecvBuffer[num];
				num++;
				int num4 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					AnimationUnit[] array2 = (this.CheckTargetSide(side) != 0) ? this.enemyUnit : this.playerUnit;
					array[num2].setState(HERO_STATE_ENUM.HERO_COMMANDS_IDLE, array2[num4].gameObject, 0, 0, 0);
				}
				break;
			}
			case 1:
			{
				int side2 = (int)RecvBuffer[num];
				num++;
				int num5 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				float new_x = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				float new_z = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					AnimationUnit[] array3 = (this.CheckTargetSide(side2) != 0) ? this.enemyUnit : this.playerUnit;
					this.Vec3Instance.Set(new_x, 0f, new_z);
					array[num2].setPositionInstantly(this.Vec3Instance);
					array[num2].setState(HERO_STATE_ENUM.HERO_COMMANDS_MOVE, array3[num5].gameObject, 0, 0, 0);
				}
				break;
			}
			case 2:
			{
				int side3 = (int)RecvBuffer[num];
				num++;
				int num6 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				int num7 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					AnimationUnit[] array4 = (this.CheckTargetSide(side3) != 0) ? this.enemyUnit : this.playerUnit;
					array[num2].setState(HERO_STATE_ENUM.HERO_COMMANDS_ATTACK, array4[num6].gameObject, num7, 0, 0);
					if (DataManager.Instance.SkillTable.GetRecordByKey((ushort)num7).SkillKind == 61)
					{
						ulong num8 = (ulong)(1L << (Side * 10 + num2 & 31));
						this.m_StateUpdateFlag |= num8;
					}
				}
				break;
			}
			case 3:
			{
				float x = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				float z = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				int num9 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					Vector3 targetPos = new Vector3(x, 0f, z);
					array[num2].checkRangeHitParticle_position((ushort)num9, targetPos, this.m_ui32Tcik, (byte)Side);
				}
				break;
			}
			case 4:
			{
				int num10 = (int)RecvBuffer[num];
				num++;
				int num11 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				int num12 = (int)RecvBuffer[num];
				num++;
				int num13 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				uint num14 = GameConstants.ConvertBytesToUInt(RecvBuffer, num);
				num += 4;
				int num15 = (int)RecvBuffer[num];
				num++;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					num10 = this.CheckTargetSide(num10);
					int num16 = 0;
					if (num12 == 0 || num12 == 10 || num12 == 11 || num12 == 8)
					{
						num16 = 1;
					}
					this.setupHPMP(Side, num2, num12, num14);
					int num17 = 0;
					num17 |= ((num15 == 0) ? 0 : 1);
					num17 |= ((num16 == 0) ? 0 : 2);
					if (this.IsDotOrHot(num12))
					{
						num17 |= 4;
					}
					bool flag = false;
					if (num12 == 14)
					{
						num17 |= 8;
						flag = true;
					}
					array[num2].setState(HERO_STATE_ENUM.HERO_COMMANDS_GETHIT, null, num13, (int)num14, num17);
					if (!this.IsDotOrHot(num12))
					{
						AnimationUnit[] array5 = (num10 != 0) ? this.enemyUnit : this.playerUnit;
						bool flag2 = array5[num11].checkRangeHitParticle((ushort)num13, array[num2].transform, this.m_ui32Tcik, (byte)num10);
						array5[num11].checkRangeHitSound((ushort)num13, this.m_ui32Tcik);
					}
					if (!this.IsType(EBattleType.GAMBLE))
					{
						if (flag)
						{
							if (Side == 0)
							{
								this.m_HeroIDFilter[num2] += (int)num14;
							}
							else
							{
								this.m_HeroIDFilter[25 - num2 - 1] += (int)num14;
							}
							this.m_IDFilterCount++;
						}
						else if ((num12 != 0 && num12 != 1) || num14 != 0u)
						{
							GUIManager.Instance.pDVMgr.AddDamageValueEffect(num14, Side, num2, (HERO_EFFECTTYPE_ENUM)num12, 0);
						}
					}
				}
				break;
			}
			case 5:
			{
				int num18 = (int)RecvBuffer[num];
				num++;
				for (int j = 0; j < num18; j++)
				{
					num += 2;
				}
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					array[num2].setState(HERO_STATE_ENUM.HERO_COMMANDS_DIE, null, 0, 0, 0);
					BattleController.HeroAttr[] array6 = (Side != 0) ? this.enemyAttr : this.playerAttr;
					array6[num2].CUR_HP = 0u;
					array6[num2].CUR_MP = 0u;
					this.m_bHPMPDirty |= (byte)(Side + 1);
					ulong num19 = (ulong)(1L << (Side * 10 + num2 & 31));
					this.m_StateUpdateFlag |= num19;
					this.enemyAliveCount--;
					this.totalAliveCount--;
					this.totalDieAliveRate = (float)this.totalAliveCount / (float)(this.enemyCount + this.playerCount);
					this.hitSoundTriggerRate = 60 - (int)((float)(60 - this.hitSoundRateBase) * this.totalDieAliveRate);
					if (Side == 0)
					{
						this.ms_viewer[num2].working = 0;
					}
					if (Side == 1)
					{
						this.CaleRewardDropDown(array[num2]);
					}
					Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(array[num2].NpcID);
					if (recordByKey.HeroKey == array[num2].NpcID && recordByKey.DyingSound != 0)
					{
						bool flag3 = true;
						if (Side == 1 && !array[num2].IsBoss)
						{
							flag3 = (UnityEngine.Random.value <= 0.5f);
						}
						if (flag3)
						{
							if (this.soundPlayMap.ContainsKey(recordByKey.DyingSound))
							{
								int num20 = this.soundPlayMap[recordByKey.DyingSound];
								this.soundList[num20].Add(array[num2].transform);
							}
							else
							{
								this.soundList[this.m_LastSoundListIdx].Add(array[num2].transform);
								this.soundPlayMap.Add(recordByKey.DyingSound, this.m_LastSoundListIdx);
								this.m_LastSoundListIdx++;
							}
							this.m_bSoundDirty = true;
						}
					}
				}
				break;
			}
			case 6:
			{
				int num21 = (int)RecvBuffer[num];
				num++;
				int num22 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				int skillID = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				int num23 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					num21 = this.CheckTargetSide(num21);
					if (num23 > 0)
					{
						AnimationUnit[] array7 = (num21 != 0) ? this.enemyUnit : this.playerUnit;
						this.setupFlyItem(array[num2].FlyRootPos, array7[num22], num23, skillID, array[num2].ScaleRate);
					}
				}
				break;
			}
			case 7:
			{
				float x2 = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				float z2 = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				int num24 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				int num25 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					if (num25 > 0)
					{
						Vector3 vector = new Vector3(x2, 0f, z2);
						if (DataManager.Instance.SkillTable.GetRecordByKey((ushort)num24).FlyType != 3)
						{
							this.setupFlyItem(array[num2].FlyRootPos, vector, num25, num24, array[num2].ScaleRate);
						}
						else
						{
							Vector3 a = array[num2].Position - vector;
							a.Normalize();
							Vector3 startPos = vector + a * 3f;
							startPos.y = 7.5f;
							this.setupFlyItem(startPos, vector, num25, num24, array[num2].ScaleRate);
						}
					}
				}
				break;
			}
			case 8:
			{
				int paramA = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					array[num2].setState(HERO_STATE_ENUM.HERO_COMMANDS_GOT_STATE, null, paramA, 1, 0);
					ulong num26 = (ulong)(1L << (Side * 10 + num2 & 31));
					this.m_StateUpdateFlag |= num26;
				}
				break;
			}
			case 9:
			{
				int paramA2 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					array[num2].setState(HERO_STATE_ENUM.HERO_COMMANDS_GOT_STATE, null, paramA2, 0, 0);
					ulong num27 = (ulong)(1L << (Side * 10 + num2 & 31));
					this.m_StateUpdateFlag |= num27;
				}
				break;
			}
			case 10:
			{
				int num28 = (int)RecvBuffer[num];
				num++;
				uint num29 = (uint)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					int num30 = num28 % 100;
					this.setupHPMP(Side, num2, num30, num29);
					int num31 = num28 / 100;
					if (num31 != 0 && num29 != 0u)
					{
						GUIManager.Instance.pDVMgr.AddDamageValueEffect(num29, Side, num2, (HERO_EFFECTTYPE_ENUM)num30, 0);
					}
				}
				break;
			}
			case 11:
			{
				num++;
				num += 2;
				int num32 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				if (!this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
				}
				break;
			}
			case 12:
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					array[num2].setState(HERO_STATE_ENUM.HERO_COMMANDS_STOP_CHANNEL, null, 0, 0, 0);
				}
				break;
			case 13:
			{
				int num33 = (int)GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					if (array[num2].hasRangeParticlePos && DataManager.Instance.SkillTable.GetRecordByKey((ushort)num33).FlyParticle == 0)
					{
						array[num2].checkRangeHitParticle((ushort)num33, null, this.m_ui32Tcik, (byte)Side);
					}
				}
				break;
			}
			case 14:
			{
				ushort inKey = GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				float new_x2 = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				float new_z2 = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					Skill recordByKey2 = DataManager.Instance.SkillTable.GetRecordByKey(inKey);
					this.Vec3Instance.Set(new_x2, 0f, new_z2);
					ParticleManager.Instance.Spawn(recordByKey2.RangeHitParticle, null, this.Vec3Instance, 1f, true, false, true);
				}
				break;
			}
			case 15:
			{
				float new_x3 = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				float new_z3 = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				ushort paramA3 = GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					this.Vec3Instance.Set(new_x3, 0f, new_z3);
					array[num2].TargetPos = this.Vec3Instance;
					array[num2].setState(HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_POINT, null, (int)paramA3, 0, 0);
				}
				break;
			}
			case 16:
				num += 2;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					array[num2].setState(HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_POINT_END, null, 0, 0, 0);
				}
				break;
			case 17:
			{
				byte side4 = RecvBuffer[num];
				num++;
				ushort num34 = GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				float new_x4 = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				float new_z4 = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				ushort num35 = GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					AnimationUnit[] array8 = ((byte)this.CheckTargetSide((int)side4) != 0) ? this.enemyUnit : this.playerUnit;
					Skill recordByKey3 = DataManager.Instance.SkillTable.GetRecordByKey(num35);
					if (recordByKey3.SkillKind != 16 && recordByKey3.SkillKind != 17)
					{
						array8[(int)num34].setState(HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_DAZE, null, 0, 0, 0);
					}
					this.Vec3Instance.Set(new_x4, 0f, new_z4);
					array[num2].TargetPos = this.Vec3Instance;
					array[num2].setState(HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_TARGET, array8[(int)num34].gameObject, (int)num35, 0, 0);
				}
				break;
			}
			case 18:
			{
				byte side5 = RecvBuffer[num];
				num++;
				ushort num36 = GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				num += 2;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					AnimationUnit[] array9 = ((byte)this.CheckTargetSide((int)side5) != 0) ? this.enemyUnit : this.playerUnit;
					array[num2].setState(HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_TARGET_END, array9[(int)num36].gameObject, 0, 0, 0);
				}
				break;
			}
			case 19:
			{
				float new_x5 = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				float new_z5 = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				ushort num37 = GameConstants.ConvertBytesToUShort(RecvBuffer, num);
				num += 2;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					this.Vec3Instance.Set(new_x5, 0f, new_z5);
					array[num2].TargetPos = this.Vec3Instance;
					array[num2].setState(HERO_STATE_ENUM.HERO_COMMANDS_KNOCK_BACK, null, 0, 0, 0);
				}
				break;
			}
			case 20:
			{
				float new_x6 = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				float new_z6 = GameConstants.ConvertBytesToFloat(RecvBuffer, num);
				num += 4;
				if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					this.Vec3Instance.Set(new_x6, 0f, new_z6);
					array[num2].setPositionInstantly(this.Vec3Instance);
					array[num2].setState(HERO_STATE_ENUM.HERO_COMMANDS_KNOCK_BACK_END, null, 0, 0, 0);
				}
				break;
			}
			case 21:
				if (this.IsType(EBattleType.GAMBLE))
				{
					if (this.bIgnoreSupport)
					{
						this.bIgnoreSupport = false;
					}
					else
					{
						this.SupportAU = array[num2];
						this.SupportIdx = num2;
						this.updateWaitingNPCDieFreeze(true);
						this.m_BattleState = BattleController.BattleState.BATTLE_CHECK_DIE_BEFORE_SUPPORT;
						this.PlayGambleHitEffect();
						GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 17, 0);
					}
				}
				else if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM)num3))
				{
					this.ExeSupport(array[num2], num2);
				}
				break;
			case 22:
				if (!this.IsType(EBattleType.GAMBLE) || !this.bIgnoreSupport)
				{
					this.CasinoHitDirty = true;
				}
				break;
			}
		}
	}

	// Token: 0x06000899 RID: 2201 RVA: 0x000B0C20 File Offset: 0x000AEE20
	public void ExeSupport(AnimationUnit au, int playerIdx)
	{
		au.gameObject.SetActive(true);
		if (au.IsEnemy && this.IsType(EBattleType.GAMBLE))
		{
			bool flag = false;
			if (BattleController.GambleMode == EGambleMode.Normal || BattleController.GambleMode == EGambleMode.Turbo)
			{
				au.setState(HERO_STATE_ENUM.HERO_COMMANDS_GOT_STATE, null, 303, 1, 0);
				flag = true;
			}
			if (flag)
			{
				ulong num = (ulong)(1L << (10 + playerIdx & 31));
				this.m_StateUpdateFlag |= num;
			}
		}
		this.uiBattle.AddCenterMsg();
		byte b = 0;
		if (this.teamTable[this.m_CurStageLevel - 1].SupportType != 2)
		{
			Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(au.NpcID);
			if (recordByKey.SupportShowType != 0)
			{
				b = recordByKey.SupportShowType;
				au.setState(HERO_STATE_ENUM.HERO_COMMANDS_WAITING_SUPPORT, null, (int)recordByKey.SupportShowType, 0, 0);
				this.m_SupportDisplayList.Add(au);
				if (this.m_BattleState != BattleController.BattleState.BATTLE_SUPPORT_DISPLAY)
				{
					this.m_BattleState = BattleController.BattleState.BATTLE_SUPPORT_DISPLAY;
					this.m_SubStateFlag = 0;
					this.deltaTime = 0f;
					this.updateSupportDisplayFreeze(true);
				}
			}
		}
		if (b == 0)
		{
			ParticleManager.Instance.Spawn(295, null, au.Position, 1f, true, false, true);
		}
	}

	// Token: 0x0600089A RID: 2202 RVA: 0x000B0D5C File Offset: 0x000AEF5C
	private bool CheckExec(int Cmd, int Side, HERO_STATE_ENUM State)
	{
		if (State == HERO_STATE_ENUM.HERO_COMMANDS_REMOVE_STATE || State == HERO_STATE_ENUM.HERO_COMMANDS_STOP_CHANNEL || State == HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_POINT_END || State == HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_TARGET_END || State == HERO_STATE_ENUM.HERO_COMMANDS_KNOCK_BACK_END)
		{
			if (((Cmd & 1) != 0 && Side == 1) || ((Cmd & 2) != 0 && Side == 0))
			{
				return false;
			}
			if (((Cmd & 4) != 0 && Side == 0) || ((Cmd & 8) != 0 && Side == 1))
			{
				return false;
			}
		}
		else if ((Cmd & 3) != 0)
		{
			return false;
		}
		return true;
	}

	// Token: 0x0600089B RID: 2203 RVA: 0x000B0DE0 File Offset: 0x000AEFE0
	public void updateMaxSkillFreeze(bool bWorking)
	{
		if (bWorking)
		{
			int num = this.playerCount;
			num = ((this.enemyCount <= num) ? num : this.enemyCount);
			for (int i = 0; i < num; i++)
			{
				if (i < this.playerCount)
				{
					if (!this.isSkillWorking(i))
					{
						this.playerUnit[i].setMaxSkillFreeze(true);
					}
					else if (i != this.m_CurUltraIndex)
					{
						this.playerUnit[i].setMaxSkillFreeze(false);
					}
				}
				if (i < this.enemyCount)
				{
					if (!this.isSkillWorking(i + 5))
					{
						this.enemyUnit[i].setMaxSkillFreeze(true);
					}
					else
					{
						this.enemyUnit[i].setMaxSkillFreeze(false);
					}
				}
			}
			ChaseManager.Instance.SetStopAllParticleChase(true);
			GameObject allEffecet = ParticleManager.Instance.GetAllEffecet();
			if (allEffecet)
			{
				int childCount = allEffecet.transform.childCount;
				for (int j = 0; j < childCount; j++)
				{
					GameObject gameObject = allEffecet.transform.GetChild(j).gameObject;
					if (gameObject.activeSelf && gameObject != this.ultraLoopParticle)
					{
						ParticleManager.Instance.Pause(gameObject, true);
					}
				}
			}
		}
		else
		{
			int num2 = this.playerCount;
			num2 = ((this.enemyCount <= num2) ? num2 : this.enemyCount);
			for (int k = 0; k < num2; k++)
			{
				if (k < this.playerCount)
				{
					this.playerUnit[k].setMaxSkillFreeze(false);
				}
				if (k < this.enemyCount)
				{
					this.enemyUnit[k].setMaxSkillFreeze(false);
				}
			}
			ChaseManager.Instance.SetStopAllParticleChase(false);
			GameObject allEffecet2 = ParticleManager.Instance.GetAllEffecet();
			if (allEffecet2)
			{
				int childCount2 = allEffecet2.transform.childCount;
				for (int l = 0; l < childCount2; l++)
				{
					GameObject gameObject2 = allEffecet2.transform.GetChild(l).gameObject;
					if (gameObject2.activeSelf)
					{
						ParticleManager.Instance.Pause(gameObject2, false);
					}
				}
			}
		}
	}

	// Token: 0x0600089C RID: 2204 RVA: 0x000B1018 File Offset: 0x000AF218
	private void updateSupportDisplayFreeze(bool bWorking)
	{
		if (bWorking)
		{
			int num = this.playerCount;
			num = ((this.enemyCount <= num) ? num : this.enemyCount);
			for (int i = 0; i < num; i++)
			{
				if (i < this.playerCount)
				{
					this.playerUnit[i].setMaxSkillFreeze(true);
				}
				if (i < this.enemyCount && this.enemyUnit[i].gameObject.activeSelf && this.enemyUnit[i].heroState != HERO_STATE_ENUM.HERO_COMMANDS_WAITING_SUPPORT)
				{
					this.enemyUnit[i].setMaxSkillFreeze(true);
				}
			}
			ChaseManager.Instance.SetStopAllParticleChase(true);
			GameObject allEffecet = ParticleManager.Instance.GetAllEffecet();
			if (allEffecet)
			{
				int childCount = allEffecet.transform.childCount;
				for (int j = 0; j < childCount; j++)
				{
					GameObject gameObject = allEffecet.transform.GetChild(j).gameObject;
					if (gameObject.activeSelf && gameObject != this.ultraLoopParticle)
					{
						ParticleManager.Instance.Pause(gameObject, true);
					}
				}
			}
		}
		else
		{
			int num2 = this.playerCount;
			num2 = ((this.enemyCount <= num2) ? num2 : this.enemyCount);
			for (int k = 0; k < num2; k++)
			{
				if (k < this.playerCount)
				{
					this.playerUnit[k].setMaxSkillFreeze(false);
				}
				if (k < this.enemyCount)
				{
					this.enemyUnit[k].setMaxSkillFreeze(false);
				}
			}
			ChaseManager.Instance.SetStopAllParticleChase(false);
			GameObject allEffecet2 = ParticleManager.Instance.GetAllEffecet();
			if (allEffecet2)
			{
				int childCount2 = allEffecet2.transform.childCount;
				for (int l = 0; l < childCount2; l++)
				{
					GameObject gameObject2 = allEffecet2.transform.GetChild(l).gameObject;
					if (gameObject2.activeSelf)
					{
						ParticleManager.Instance.Pause(gameObject2, false);
					}
				}
			}
		}
	}

	// Token: 0x0600089D RID: 2205 RVA: 0x000B122C File Offset: 0x000AF42C
	private void updateWaitingNPCDieFreeze(bool bWorking)
	{
		if (bWorking)
		{
			for (int i = 0; i < this.playerCount; i++)
			{
				if (i < this.playerCount)
				{
					this.playerUnit[i].setMaxSkillFreeze(true);
				}
			}
			ChaseManager.Instance.SetStopAllParticleChase(true);
			GameObject allEffecet = ParticleManager.Instance.GetAllEffecet();
			if (allEffecet)
			{
				int childCount = allEffecet.transform.childCount;
				for (int j = 0; j < childCount; j++)
				{
					GameObject gameObject = allEffecet.transform.GetChild(j).gameObject;
					if (gameObject.activeSelf && gameObject != this.ultraLoopParticle)
					{
						ParticleManager.Instance.Pause(gameObject, true);
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < this.playerCount; k++)
			{
				if (k < this.playerCount)
				{
					this.playerUnit[k].setMaxSkillFreeze(false);
				}
			}
			ChaseManager.Instance.SetStopAllParticleChase(false);
			GameObject allEffecet2 = ParticleManager.Instance.GetAllEffecet();
			if (allEffecet2)
			{
				int childCount2 = allEffecet2.transform.childCount;
				for (int l = 0; l < childCount2; l++)
				{
					GameObject gameObject2 = allEffecet2.transform.GetChild(l).gameObject;
					if (gameObject2.activeSelf)
					{
						ParticleManager.Instance.Pause(gameObject2, false);
					}
				}
			}
		}
	}

	// Token: 0x0600089E RID: 2206 RVA: 0x000B13A0 File Offset: 0x000AF5A0
	public void PlayGambleHitEffect()
	{
		int paramA = (BattleController.GambleMode != EGambleMode.Normal) ? 859 : 858;
		if (this.enemyUnit[1] != null && this.enemyUnit[1].gameObject.activeSelf)
		{
			this.enemyUnit[1].setState(HERO_STATE_ENUM.HERO_COMMANDS_GETHIT, null, paramA, 100, 3);
		}
		else
		{
			this.enemyUnit[0].setState(HERO_STATE_ENUM.HERO_COMMANDS_GETHIT, null, paramA, 100, 3);
		}
	}

	// Token: 0x0600089F RID: 2207 RVA: 0x000B141C File Offset: 0x000AF61C
	private ChaseType getChaseType(byte flyType)
	{
		if ((int)flyType >= this.FT2CT.Length)
		{
			return ChaseType.Straight;
		}
		return this.FT2CT[(int)flyType];
	}

	// Token: 0x060008A0 RID: 2208 RVA: 0x000B1438 File Offset: 0x000AF638
	private void setupFlyItem(Vector3 startPos, AnimationUnit target, int flyTime, int skillID, float scaleRate)
	{
		Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey((ushort)skillID);
		if (recordByKey.FlyParticle != 0)
		{
			ChaseType chaseType = this.getChaseType(recordByKey.FlyType);
			Transform target2 = (recordByKey.FlyType != 2) ? target.HitPointRoot : target.transform;
			if (recordByKey.FlyType == 2)
			{
				startPos.y = 0f;
			}
			if (recordByKey.FlyType == 6)
			{
				this.ChaseMgr.AddChase(startPos, target2, (float)flyTime * 0.001f, recordByKey.FlyParticle, scaleRate, ChaseType.CurveLeft);
				this.ChaseMgr.AddChase(startPos, target2, (float)flyTime * 0.001f, recordByKey.FlyParticle, scaleRate, ChaseType.CurveRight);
			}
			else
			{
				this.ChaseMgr.AddChase(startPos, target2, (float)flyTime * 0.001f, recordByKey.FlyParticle, scaleRate, chaseType);
			}
		}
	}

	// Token: 0x060008A1 RID: 2209 RVA: 0x000B151C File Offset: 0x000AF71C
	private void setupFlyItem(Vector3 startPos, Vector3 targetPos, int flyTime, int skillID, float scaleRate)
	{
		Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey((ushort)skillID);
		if (recordByKey.FlyParticle != 0)
		{
			ChaseType chaseType = this.getChaseType(recordByKey.FlyType);
			if (recordByKey.FlyType == 2)
			{
				startPos.y = 0f;
				targetPos.y = 0f;
			}
			if (recordByKey.FlyType == 6)
			{
				this.ChaseMgr.AddChase(startPos, targetPos, (float)flyTime * 0.001f, recordByKey.FlyParticle, scaleRate, ChaseType.CurveLeft);
				this.ChaseMgr.AddChase(startPos, targetPos, (float)flyTime * 0.001f, recordByKey.FlyParticle, scaleRate, ChaseType.CurveRight);
			}
			else
			{
				this.ChaseMgr.AddChase(startPos, targetPos, (float)flyTime * 0.001f, recordByKey.FlyParticle, scaleRate, chaseType);
			}
		}
	}

	// Token: 0x060008A2 RID: 2210 RVA: 0x000B15EC File Offset: 0x000AF7EC
	private void setupHPMP(int side, int heroIdx, int effectIdx, uint val)
	{
		BattleController.HeroAttr[] array = (side != 0) ? this.enemyAttr : this.playerAttr;
		switch (effectIdx)
		{
		case 0:
		case 8:
		case 10:
		case 11:
		{
			long num = (long)((ulong)array[heroIdx].CUR_HP - (ulong)val);
			num = Math.Max(num, 0L);
			array[heroIdx].CUR_HP = (uint)num;
			if (side == 0)
			{
				this.uiBattle.UpdateSetSliderHP(heroIdx);
			}
			break;
		}
		case 1:
		case 9:
		case 12:
		case 13:
		case 14:
		{
			uint cur_HP = array[heroIdx].CUR_HP;
			uint num2 = array[heroIdx].CUR_HP + val;
			num2 = Math.Min(num2, array[heroIdx].MAX_HP);
			array[heroIdx].CUR_HP = num2;
			if (side == 0)
			{
				this.uiBattle.UpdateSetSliderHP(heroIdx);
			}
			if (cur_HP == 0u && num2 > 0u)
			{
				GUIManager.Instance.pDVMgr.SetBloodBarFillAmount(side, heroIdx, num2 / array[heroIdx].MAX_HP);
			}
			break;
		}
		case 2:
		{
			uint num3 = array[heroIdx].CUR_MP + val;
			num3 = Math.Min(num3, array[heroIdx].MAX_MP);
			array[heroIdx].CUR_MP = num3;
			if (side == 0)
			{
				this.uiBattle.UpdateSetSliderHP(heroIdx);
			}
			if (side == 0 && num3 == array[heroIdx].MAX_MP && this.ms_viewer[heroIdx].working == 0)
			{
				this.ms_viewer[heroIdx].working = 1;
			}
			break;
		}
		case 3:
		{
			long num4 = (long)((ulong)array[heroIdx].CUR_MP - (ulong)val);
			num4 = Math.Max(num4, 0L);
			array[heroIdx].CUR_MP = (uint)num4;
			if (side == 0)
			{
				this.uiBattle.UpdateSetSliderHP(heroIdx);
			}
			if (side == 0 && num4 != (long)((ulong)array[heroIdx].MAX_MP) && this.ms_viewer[heroIdx].working == 1)
			{
				this.ms_viewer[heroIdx].working = 0;
				this.ms_viewer[heroIdx].ui_state = 0;
				this.uiBattle.SetBtnTween(heroIdx, 0);
			}
			break;
		}
		}
	}

	// Token: 0x060008A3 RID: 2211 RVA: 0x000B1854 File Offset: 0x000AFA54
	public void UpdateSkillLightmap(bool bEnable, bool bBattleFinish = false)
	{
		int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
		int num = -1;
		int lightmapIndex = 0 + sceneLightmapSize;
		int lightmapIndex2 = 1 + sceneLightmapSize;
		if (!bEnable)
		{
			if (this.mapObject1 != null)
			{
				this.mapObject1.renderer.lightmapIndex = 0;
			}
			if (this.mapObject2 != null)
			{
				this.mapObject2.renderer.lightmapIndex = 1;
			}
			for (int i = 0; i < this.playerCount; i++)
			{
				if (!(this.playerUnit[i].getRenderer == null))
				{
					int lightmapIndex3 = (!bBattleFinish && this.playerUnit[i].StateColorSkin != 0u && this.playerUnit[i].StateColorSkin <= 4u) ? this.m_SkinColorLightmapIndex[(int)((UIntPtr)(this.playerUnit[i].StateColorSkin - 1u))] : num;
					this.playerUnit[i].getRenderer.lightmapIndex = lightmapIndex3;
				}
			}
			for (int j = 0; j < this.enemyCount; j++)
			{
				if (!(this.enemyUnit[j].getRenderer == null))
				{
					int lightmapIndex4 = (!bBattleFinish && this.enemyUnit[j].StateColorSkin != 0u && this.enemyUnit[j].StateColorSkin <= 4u) ? this.m_SkinColorLightmapIndex[(int)((UIntPtr)(this.enemyUnit[j].StateColorSkin - 1u))] : num;
					this.enemyUnit[j].getRenderer.lightmapIndex = lightmapIndex4;
				}
			}
		}
		else
		{
			int num2 = this.m_MaxSkillWorkingList;
			if (this.mapObject1 != null)
			{
				this.mapObject1.renderer.lightmapIndex = lightmapIndex;
			}
			if (this.mapObject2 != null)
			{
				this.mapObject2.renderer.lightmapIndex = lightmapIndex;
			}
			int k = 0;
			while (k < this.playerCount)
			{
				if (!(this.playerUnit[k].getRenderer == null))
				{
					if ((num2 & 1) > 0)
					{
						this.playerUnit[k].getRenderer.lightmapIndex = lightmapIndex2;
					}
					else
					{
						this.playerUnit[k].getRenderer.lightmapIndex = lightmapIndex;
					}
				}
				k++;
				num2 >>= 1;
			}
			num2 = this.m_MaxSkillWorkingList >> 5;
			int l = 0;
			while (l < this.enemyCount)
			{
				if (!(this.enemyUnit[l].getRenderer == null))
				{
					if ((num2 & 1) > 0)
					{
						this.enemyUnit[l].getRenderer.lightmapIndex = lightmapIndex2;
					}
					else
					{
						this.enemyUnit[l].getRenderer.lightmapIndex = lightmapIndex;
					}
				}
				l++;
				num2 >>= 1;
			}
		}
	}

	// Token: 0x060008A4 RID: 2212 RVA: 0x000B1B40 File Offset: 0x000AFD40
	public void updateUltraSelectLightmap(uint hitList)
	{
		int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
		int lightmapIndex = -1;
		int lightmapIndex2 = 0 + sceneLightmapSize;
		DamageValueManager pDVMgr = GUIManager.Instance.pDVMgr;
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.playerUnit[this.m_CurUltraIndex].NpcID);
		Skill recordByKey2 = DataManager.Instance.SkillTable.GetRecordByKey(recordByKey.AttackPower[1]);
		AnimationUnit[] array = (recordByKey2.SkillKind <= 50) ? this.enemyUnit : this.playerUnit;
		int num = (recordByKey2.SkillKind <= 50) ? this.enemyCount : this.playerCount;
		int side = (recordByKey2.SkillKind <= 50) ? 1 : 0;
		for (int i = 0; i < num; i++)
		{
			bool flag = (hitList >> i & 1u) != 0u;
			if (flag)
			{
				array[i].getRenderer.lightmapIndex = lightmapIndex;
				pDVMgr.ShowBloodBar(side, i);
			}
			else
			{
				array[i].getRenderer.lightmapIndex = lightmapIndex2;
				pDVMgr.HideBloodBar(side, i);
			}
		}
	}

	// Token: 0x060008A5 RID: 2213 RVA: 0x000B1C68 File Offset: 0x000AFE68
	public bool movePlayerOutside(EMovePlayerOutside mode = EMovePlayerOutside.Default)
	{
		if (this.m_BattleResult == 1)
		{
			if (!this.IsType(EBattleType.GAMBLE))
			{
				for (int i = 0; i < this.playerCount; i++)
				{
					if (this.playerUnit[i].enabled && this.playerUnit[i].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
					{
						this.playerUnit[i].setState(HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_RUN, null, 0, 0, 0);
					}
				}
				this.BSUtil.setNextStage(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
				int num = 1;
				for (int j = 0; j < (int)BattleController.RecvBufferLeft[0]; j++)
				{
					int num2 = (int)GameConstants.ConvertBytesToUShort(BattleController.RecvBufferLeft, num);
					num += 6;
					uint num3 = GameConstants.ConvertBytesToUInt(BattleController.RecvBufferLeft, num);
					num += 4;
					ushort num4 = GameConstants.ConvertBytesToUShort(BattleController.RecvBufferLeft, num);
					num += 2;
					byte b = BattleController.RecvBufferLeft[num];
					num++;
					long num5 = (long)((ulong)(num3 - this.playerAttr[num2].CUR_HP));
					if (num5 > 0L)
					{
						GUIManager.Instance.pDVMgr.AddDamageValueEffect((uint)num5, 0, num2, HERO_EFFECTTYPE_ENUM.HERO_EFFECT_RECOVER, 0);
					}
					this.playerAttr[num2].CUR_HP = num3;
					num5 = (long)((ulong)((uint)num4 - this.playerAttr[num2].CUR_MP));
					if (num5 > 0L)
					{
						GUIManager.Instance.pDVMgr.AddDamageValueEffect((uint)num5, 0, num2, HERO_EFFECTTYPE_ENUM.HERO_EFFECT_ADDENERGY, 0);
					}
					this.playerAttr[num2].CUR_MP = (uint)num4;
				}
				GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 1, 0);
			}
			else
			{
				for (int k = 0; k < this.playerCount; k++)
				{
					if (this.playerUnit[k].enabled && this.playerUnit[k].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
					{
						this.playerUnit[k].setState(HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_RUN_GAMBLE, null, 0, 0, 0);
					}
				}
			}
		}
		else if (mode == EMovePlayerOutside.BattleFailed)
		{
			for (int l = 0; l < this.playerCount; l++)
			{
				if (this.playerUnit[l].enabled && this.playerUnit[l].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
				{
					Vector3 position = this.playerUnit[l].Position;
					position.x = -100f;
					this.playerUnit[l].movePos = new Vector3?(position);
					this.playerUnit[l].Target = null;
					this.playerUnit[l].cleanAttackParticle();
					this.playerUnit[l].cleanStateParticle();
					this.playerUnit[l].setState(HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_RUN, null, 0, 0, 0);
				}
			}
		}
		else if (mode == EMovePlayerOutside.GambleFailed)
		{
			for (int m = 0; m < this.playerCount; m++)
			{
				if (this.playerUnit[m].enabled && this.playerUnit[m].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
				{
					Vector3 position2 = this.playerUnit[m].Position;
					position2.x = 100f;
					this.playerUnit[m].movePos = new Vector3?(position2);
					this.playerUnit[m].Target = null;
					this.playerUnit[m].cleanAttackParticle();
					this.playerUnit[m].cleanStateParticle();
				}
			}
		}
		return true;
	}

	// Token: 0x060008A6 RID: 2214 RVA: 0x000B1FB0 File Offset: 0x000B01B0
	public bool CheckNextLevel()
	{
		return this.m_CurStageLevel < this.m_MaxStageLevel && this.m_BattleResult == 1;
	}

	// Token: 0x060008A7 RID: 2215 RVA: 0x000B1FE0 File Offset: 0x000B01E0
	public bool ReturnFirstStage()
	{
		if (this.m_BattleResult == 2 || (this.m_CurStageLevel == this.m_MaxStageLevel && this.m_BattleResult == 1))
		{
			GUIManager.Instance.OpenMenu(EGUIWindow.UI_Settlement, 0, 0, true, false, false);
			return true;
		}
		return false;
	}

	// Token: 0x060008A8 RID: 2216 RVA: 0x000B202C File Offset: 0x000B022C
	public void SetBattleCameraModel()
	{
		if (this.BCamera != null)
		{
			BattleController.CameraModel = ((BattleController.CameraModel != 0) ? 0 : 1);
			this.BCamera.initCamera(this.playerUnit, this.playerCount, this.enemyUnit, this.enemyCount);
		}
	}

	// Token: 0x060008A9 RID: 2217 RVA: 0x000B2080 File Offset: 0x000B0280
	private Vector3 getRewardRandomPos()
	{
		int num = UnityEngine.Random.Range(0, (int)this.m_RewardRandomFlag);
		Vector3 vector = this.m_RewardRandomPos[num];
		if (this.m_RewardRandomFlag == 1)
		{
			this.m_RewardRandomFlag = (byte)this.m_RewardRandomPos.Length;
		}
		else
		{
			this.m_RewardRandomFlag -= 1;
			this.m_RewardRandomPos[num] = this.m_RewardRandomPos[(int)this.m_RewardRandomFlag];
			this.m_RewardRandomPos[(int)this.m_RewardRandomFlag] = vector;
		}
		return vector;
	}

	// Token: 0x060008AA RID: 2218 RVA: 0x000B211C File Offset: 0x000B031C
	private void initRewardData()
	{
		if (this.m_CurStageLevel == 1)
		{
			this.m_RewardCount = 0;
		}
		this.m_RewardOffset += this.m_RewardCount;
		this.m_RewardCount = (ushort)DataManager.Instance.RewardLen[this.m_CurStageLevel - 1];
		this.m_DropRewardCount = 0;
		int num = (this.m_MaxStageLevel != this.m_CurStageLevel) ? this.enemyCount : (this.enemyCount - 1);
		num = Mathf.Max(1, num);
		byte b = (byte)((int)this.m_RewardCount / num);
		byte b2 = (byte)((int)this.m_RewardCount - (int)b * num);
		Array.Clear(this.m_DropPerEnemy, 0, 20);
		int num2 = this.enemyCount;
		for (int i = 0; i < num2; i++)
		{
			this.m_HeroIDFilter[i] = i;
			this.m_DropPerEnemy[i] = b;
		}
		for (int j = 0; j < (int)b2; j++)
		{
			int num3 = UnityEngine.Random.Range(0, num2);
			num2--;
			int num4 = this.m_HeroIDFilter[num3];
			this.m_HeroIDFilter[num3] = this.m_HeroIDFilter[num2];
			byte[] dropPerEnemy = this.m_DropPerEnemy;
			int num5 = num4;
			dropPerEnemy[num5] += 1;
		}
		Array.Clear(this.m_HeroIDFilter, 0, 25);
	}

	// Token: 0x060008AB RID: 2219 RVA: 0x000B2254 File Offset: 0x000B0454
	public void CaleRewardDropDown(AnimationUnit au)
	{
		if (au == null)
		{
			return;
		}
		int num = 1;
		if (Camera.main.WorldToScreenPoint(au.Position).y < RewardManager.getInstance.ScreenSize.y * 0.5f)
		{
			num = -1;
		}
		DataManager instance = DataManager.Instance;
		int num2 = 0;
		if (this.enemyCount <= 1 || this.enemyAliveCount == 0)
		{
			num2 = (int)(this.m_RewardCount - this.m_DropRewardCount);
		}
		else
		{
			int num3 = this.enemyCount - this.enemyAliveCount - 1;
			if (num3 < this.m_DropPerEnemy.Length)
			{
				num2 = (int)this.m_DropPerEnemy[num3];
			}
		}
		for (int i = 0; i < num2; i++)
		{
			if (this.m_DropRewardCount >= this.m_RewardCount)
			{
				break;
			}
			ushort itemID = instance.RewardData[(int)(this.m_RewardOffset + this.m_DropRewardCount)];
			this.m_DropRewardCount += 1;
			RewardManager.getInstance.addReward(itemID, au.HitPointRoot.position, au.Position + this.getRewardRandomPos() * (float)num, 0);
		}
		if (au.IsBoss)
		{
			int num4 = (int)(instance.RewardLen[0] + instance.RewardLen[1] + instance.RewardLen[2]);
			for (int j = 0; j < (int)instance.RewardLen[3]; j++)
			{
				ushort itemID2 = instance.RewardData[num4 + j];
				RewardManager.getInstance.addReward(itemID2, au.HitPointRoot.position, au.Position + this.getRewardRandomPos() * (float)num, 0);
			}
		}
	}

	// Token: 0x060008AC RID: 2220 RVA: 0x000B2408 File Offset: 0x000B0608
	public static Vector3? Tracing(Vector3 lineVector, Vector3 linePoint)
	{
		if (Math.Abs(lineVector[1]) < 0.0001f)
		{
			return null;
		}
		Vector3 zero = Vector3.zero;
		float num = -linePoint[1] / lineVector[1];
		zero[0] = linePoint[0] + lineVector[0] * num;
		zero[1] = linePoint[1] + lineVector[1] * num;
		zero[2] = linePoint[2] + lineVector[2] * num;
		return new Vector3?(zero);
	}

	// Token: 0x060008AD RID: 2221 RVA: 0x000B24A8 File Offset: 0x000B06A8
	public void EventCallBack(AnimationUnit au, EAUCallBack type, int param = 0)
	{
		if (type == EAUCallBack.MAXSKILL_HITPOINT)
		{
			AnimationUnit[] array = (!au.IsEnemy) ? this.playerUnit : this.enemyUnit;
			int num = (!au.IsEnemy) ? this.playerCount : this.enemyCount;
			for (int i = 0; i < num; i++)
			{
				if (au == array[i])
				{
					int idx = (!au.IsEnemy) ? i : (i + 5);
					if (au.IsEnemy || i != this.m_CurUltraIndex)
					{
						this.setMaxSkillWorkingList(idx, false, 0);
						this.updateMaxSkillFreeze(true);
						this.UpdateSkillLightmap(true, false);
						au.checkFireParticle();
						au.playUltraHitSound();
						au.checkChannelSkillAnim();
					}
					else
					{
						au.playUltraLoopAnim(true);
						Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(au.NpcID);
						Skill recordByKey2 = DataManager.Instance.SkillTable.GetRecordByKey(recordByKey.AttackPower[1]);
						Transform transform = (recordByKey2.UltraParticlePos != 1) ? au.transform : au.WP;
						transform = ((recordByKey2.UltraParticlePos != 2) ? transform : au.HitPointRoot);
						bool ultraParticlePos = recordByKey2.UltraParticlePos != 0;
						if (this.ultraLoopParticle == null)
						{
							if (ultraParticlePos)
							{
								this.ultraLoopParticle = ParticleManager.Instance.Spawn(recordByKey2.UltraParticle, transform, Vector3.zero, 1f, true, true, true);
								if (this.ultraLoopParticle != null && recordByKey2.UltraParticlePos == 3)
								{
									this.ultraLoopParticle.transform.rotation = Quaternion.LookRotation(au.transform.forward);
								}
							}
							else
							{
								this.ultraLoopParticle = ParticleManager.Instance.Spawn(recordByKey2.UltraParticle, au.transform, transform.position, 1f, true, false, true);
							}
						}
						if (this.ultraHitSoundKey != 255)
						{
							AudioManager.Instance.StopSFX(this.ultraHitSoundKey, true);
						}
						AudioManager.Instance.PlaySFXLoop(recordByKey2.UltraSound, out this.ultraHitSoundKey, au.transform, SFXEffect.Normal, 0f);
					}
					break;
				}
			}
		}
	}

	// Token: 0x060008AE RID: 2222 RVA: 0x000B26F4 File Offset: 0x000B08F4
	public bool checkInitUltra(int idx)
	{
		if (this.m_BattleState != BattleController.BattleState.BATTLE_RUNNING && this.m_BattleState != BattleController.BattleState.BATTLE_MAXSKILL_WORKING)
		{
			return false;
		}
		if (this.MaxSkillBitList != 0 && this.m_BattleState != BattleController.BattleState.BATTLE_MAXSKILL_WORKING)
		{
			return false;
		}
		if ((this.MaxSkillBitList >> idx & 1) != 0)
		{
			return false;
		}
		float x = 0f;
		float z = 0f;
		if (this.BSUtil.initUltra((byte)idx, ref this.closetHeroIndexCache, ref x, ref z))
		{
			this.playerUnit[idx].setPositionInstantly(new Vector3(x, 0f, z));
			this.useMaxSkill(0, idx);
			this.m_CurUltraIndex = idx;
			this.lastNearestTargetIndex = -1;
			Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.playerUnit[this.m_CurUltraIndex].NpcID);
			this.m_HitContainerSide = ((DataManager.Instance.SkillTable.GetRecordByKey(recordByKey.AttackPower[1]).SkillKind <= 50) ? 1 : 0);
			return true;
		}
		return false;
	}

	// Token: 0x060008AF RID: 2223 RVA: 0x000B27F8 File Offset: 0x000B09F8
	public void inputUltraForNewbie(Vector3 pos)
	{
		if (Vector3.Distance(pos, this.playerUnit[this.m_CurUltraIndex].Position) > this.PJ_FireRange)
		{
			Vector3 a = pos - this.playerUnit[this.m_CurUltraIndex].Position;
			a.Normalize();
			pos = this.playerUnit[this.m_CurUltraIndex].Position + a * this.PJ_FireRange;
			pos.y = 0f;
		}
		byte param = (pos.x > 0f) ? ((byte)(((pos.x > 23.8f) ? 23.8f : pos.x) * 10f)) : 0;
		byte param2 = (pos.z > 0f) ? ((byte)(((pos.z > 11f) ? 11f : pos.z) * 10f)) : 0;
		this.BSUtil.ultraInput(param, param2);
		if (this.m_HitContainerSide != 0)
		{
			DamageValueManager pDVMgr = GUIManager.Instance.pDVMgr;
			if (this.m_HitContainerSide != 0)
			{
				for (int i = 0; i < this.enemyCount; i++)
				{
					pDVMgr.HideBloodBar(1, i);
				}
			}
			else
			{
				for (int j = 0; j < this.playerCount; j++)
				{
					pDVMgr.HideBloodBar(0, j);
				}
			}
		}
		if (this.playerUnit[this.m_CurUltraIndex].IsMaxSkillLooping)
		{
			this.playerUnit[this.m_CurUltraIndex].playUltraLoopAnim(false);
			if (this.ultraLoopParticle != null)
			{
				ParticleManager.Instance.DeSpawn(this.ultraLoopParticle);
				this.ultraLoopParticle = null;
			}
			this.setMaxSkillWorkingList(this.m_CurUltraIndex, false, 0);
			this.updateMaxSkillFreeze(true);
			this.playerUnit[this.m_CurUltraIndex].checkFireParticle();
			this.playerUnit[this.m_CurUltraIndex].playUltraHitSound();
			if (this.ultraHitSoundKey != 255)
			{
				AudioManager.Instance.StopSFX(this.ultraHitSoundKey, true);
				this.ultraHitSoundKey = byte.MaxValue;
			}
		}
		this.m_CurUltraIndex = -1;
	}

	// Token: 0x060008B0 RID: 2224 RVA: 0x000B2A38 File Offset: 0x000B0C38
	public void inputUltra(bool bControlSelf, Ray? ray = null)
	{
		if (bControlSelf)
		{
			if (this.lastNearestTargetIndex != -1)
			{
				this.BSUtil.ultraInput((byte)this.lastNearestTargetIndex, 0);
			}
			else
			{
				if (ray == null)
				{
					ray = new Ray?(default(Ray));
				}
				Vector3 a = BattleController.Tracing(ray.Value.direction, ray.Value.origin).Value;
				if (NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE))
				{
					a = this.enemyUnit[0].Position;
				}
				if (Vector3.Distance(a, this.playerUnit[this.m_CurUltraIndex].Position) > this.PJ_FireRange)
				{
					Vector3 a2 = a - this.playerUnit[this.m_CurUltraIndex].Position;
					a2.Normalize();
					a = this.playerUnit[this.m_CurUltraIndex].Position + a2 * this.PJ_FireRange;
					a.y = 0f;
				}
				byte param = (a.x > 0f) ? ((byte)(((a.x > 23.8f) ? 23.8f : a.x) * 10f)) : 0;
				byte param2 = (a.z > 0f) ? ((byte)(((a.z > 11f) ? 11f : a.z) * 10f)) : 0;
				this.BSUtil.ultraInput(param, param2);
			}
			if (this.m_HitContainerSide != 0)
			{
				DamageValueManager pDVMgr = GUIManager.Instance.pDVMgr;
				if (this.m_HitContainerSide != 0)
				{
					for (int i = 0; i < this.enemyCount; i++)
					{
						pDVMgr.HideBloodBar(1, i);
					}
				}
				else
				{
					for (int j = 0; j < this.playerCount; j++)
					{
						pDVMgr.HideBloodBar(0, j);
					}
				}
			}
		}
		else
		{
			Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.playerUnit[this.m_CurUltraIndex].NpcID);
			Skill recordByKey2 = DataManager.Instance.SkillTable.GetRecordByKey(recordByKey.AttackPower[1]);
			int num = (recordByKey2.SkillKind <= 50) ? this.enemyCount : this.playerCount;
			AnimationUnit[] array = (recordByKey2.SkillKind <= 50) ? this.enemyUnit : this.playerUnit;
			if (Array.IndexOf<byte>(this.PJ_GraphKind[4], recordByKey2.SkillKind) > -1)
			{
				int num2 = -1;
				float num3 = -1f;
				this.BSUtil.checkUltraHitTarget(0, 0, ref this.m_HitContainer);
				for (int k = 0; k < num; k++)
				{
					if ((this.m_HitContainer >> k & 1u) != 0u)
					{
						float num4 = GameConstants.DistanceSquare(array[k].Position, this.playerUnit[this.m_CurUltraIndex].Position);
						if (num4 > num3)
						{
							num2 = k;
							num3 = num4;
						}
					}
				}
				if (num2 != -1)
				{
					if (recordByKey2.SkillKind <= 50 || num2 != this.m_CurUltraIndex)
					{
						this.playerUnit[this.m_CurUltraIndex].updateDirection(array[num2].Position);
					}
					this.BSUtil.ultraInput((byte)num2, 0);
				}
			}
			else if (this.closetHeroIndexCache >= 0 && (int)this.closetHeroIndexCache < num)
			{
				bool flag = false;
				byte b;
				byte b2;
				if (Vector3.Distance(this.playerUnit[this.m_CurUltraIndex].Position, array[(int)this.closetHeroIndexCache].Position) > (float)recordByKey2.SkillDistance * 0.01f)
				{
					Vector3 a3 = array[(int)this.closetHeroIndexCache].Position - this.playerUnit[this.m_CurUltraIndex].Position;
					a3.Normalize();
					a3 = this.playerUnit[this.m_CurUltraIndex].Position + a3 * ((float)recordByKey2.SkillDistance * 0.01f);
					b = (byte)(a3.x * 10f);
					b2 = (byte)(a3.z * 10f);
					if (recordByKey2.SkillDistance == 0)
					{
						flag = true;
					}
				}
				else
				{
					b = (byte)(array[(int)this.closetHeroIndexCache].Position.x * 10f);
					b2 = (byte)(array[(int)this.closetHeroIndexCache].Position.z * 10f);
				}
				if ((recordByKey2.SkillKind <= 50 || (int)this.closetHeroIndexCache != this.m_CurUltraIndex) && !flag)
				{
					this.playerUnit[this.m_CurUltraIndex].updateDirection(new Vector3((float)b * 0.1f, 0f, (float)b2 * 0.1f));
				}
				this.BSUtil.ultraInput(b, b2);
			}
		}
		if (this.playerUnit[this.m_CurUltraIndex].IsMaxSkillLooping)
		{
			this.playerUnit[this.m_CurUltraIndex].playUltraLoopAnim(false);
			if (this.ultraLoopParticle != null)
			{
				ParticleManager.Instance.DeSpawn(this.ultraLoopParticle);
				this.ultraLoopParticle = null;
			}
			this.setMaxSkillWorkingList(this.m_CurUltraIndex, false, 0);
			this.updateMaxSkillFreeze(true);
			this.playerUnit[this.m_CurUltraIndex].checkFireParticle();
			this.playerUnit[this.m_CurUltraIndex].playUltraHitSound();
			if (this.ultraHitSoundKey != 255)
			{
				AudioManager.Instance.StopSFX(this.ultraHitSoundKey, true);
				this.ultraHitSoundKey = byte.MaxValue;
			}
		}
		this.m_CurUltraIndex = -1;
	}

	// Token: 0x060008B1 RID: 2225 RVA: 0x000B3004 File Offset: 0x000B1204
	public void getUltraTargets(byte param1, byte param2)
	{
		uint num = 0u;
		this.BSUtil.checkUltraHitTarget(param1, param2, ref num);
		if (num != this.m_HitContainer)
		{
			this.updateUltraSelectLightmap(num);
		}
		this.m_HitContainer = num;
	}

	// Token: 0x060008B2 RID: 2226 RVA: 0x000B303C File Offset: 0x000B123C
	public Transform getProjectorParent()
	{
		return this.projector_parent;
	}

	// Token: 0x060008B3 RID: 2227 RVA: 0x000B3044 File Offset: 0x000B1244
	public AnimationUnit getUltraSkiller()
	{
		return this.playerUnit[this.m_CurUltraIndex];
	}

	// Token: 0x060008B4 RID: 2228 RVA: 0x000B3054 File Offset: 0x000B1254
	public void updateNearestTargetHightlight(Vector3 mousePos)
	{
		if (this.m_HitContainer == 0u)
		{
			return;
		}
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.playerUnit[this.m_CurUltraIndex].NpcID);
		bool flag = DataManager.Instance.SkillTable.GetRecordByKey(recordByKey.AttackPower[1]).SkillKind > 50;
		AnimationUnit[] array = (!flag) ? this.enemyUnit : this.playerUnit;
		int num = (!flag) ? this.enemyCount : this.playerCount;
		int num2 = -1;
		float num3 = 999999f;
		for (int i = 0; i < num; i++)
		{
			if ((this.m_HitContainer >> i & 1u) != 0u)
			{
				float num4 = GameConstants.DistanceSquare(array[i].Position, mousePos);
				if (num4 < num3)
				{
					num2 = i;
					num3 = num4;
				}
			}
		}
		if (num2 != -1 && this.lastNearestTargetIndex != num2)
		{
			this.lastNearestTargetIndex = num2;
			int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
			int num5 = -1;
			int num6 = 0 + sceneLightmapSize;
			DamageValueManager pDVMgr = GUIManager.Instance.pDVMgr;
			int side = (!flag) ? 1 : 0;
			for (int j = 0; j < num; j++)
			{
				if (!flag || (flag && j != this.m_CurUltraIndex))
				{
					bool flag2 = j == this.lastNearestTargetIndex;
					array[j].getRenderer.lightmapIndex = ((!flag2) ? num6 : num5);
					if (flag2)
					{
						pDVMgr.ShowBloodBar(side, j);
					}
					else
					{
						pDVMgr.HideBloodBar(side, j);
					}
				}
			}
			Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(array[num2].NpcID);
			this.sp_projector.ShadowSize = (float)recordByKey2.Radius * 0.002f;
			this.sp_projector.transform.position = array[num2].Position;
			if (!flag || (flag && num2 != this.m_CurUltraIndex))
			{
				this.playerUnit[this.m_CurUltraIndex].updateDirection(array[num2].Position);
			}
			float num7 = Vector3.Distance(this.enemyUnit[num2].Position, this.playerUnit[this.m_CurUltraIndex].Position);
			float num8 = num7 - (float)recordByKey2.Radius * 0.02f;
			num8 = ((num8 <= 1f) ? num8 : (num8 - 0.5f));
			this.sp_projector_line_transform.localScale = new Vector3(0.006f, num8 * 0.05f, 0.006f);
			Vector3 vector = this.enemyUnit[num2].Position - this.playerUnit[this.m_CurUltraIndex].Position;
			vector.Normalize();
			this.sp_projector_line.transform.rotation = Quaternion.LookRotation(vector);
			this.sp_projector_line.transform.Rotate(270f, 0f, 0f);
			this.sp_projector_line.transform.position = this.playerUnit[this.m_CurUltraIndex].Position + vector * num8 * 0.5f;
		}
	}

	// Token: 0x060008B5 RID: 2229 RVA: 0x000B33A8 File Offset: 0x000B15A8
	public Transform setupTeachProjector(bool bShow, int projectorType)
	{
		if (bShow)
		{
			Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.playerUnit[this.m_CurUltraIndex].NpcID);
			Skill recordByKey2 = DataManager.Instance.SkillTable.GetRecordByKey(recordByKey.AttackPower[1]);
			this.newbie_projector_parent.position = new Vector3(0f, 0.01f, 0f);
			this.newbie_projector_parent.rotation = Quaternion.identity;
			this.newbie_projector.gameObject.SetActive(true);
			switch (projectorType)
			{
			case 3:
			{
				Vector3 position = this.playerUnit[this.m_CurUltraIndex].Position;
				position.y = 0.01f;
				this.newbie_projector_parent.position = position;
				this.newbie_projector.UVRect = this.ProjectorUV[2];
				this.newbie_projector.ShadowSize = (float)recordByKey2.Rangeparameter1 * 0.0005f;
				break;
			}
			case 5:
				this.newbie_projector.UVRect = this.ProjectorUV[4];
				this.newbie_projector_line.gameObject.SetActive(true);
				break;
			}
			return this.newbie_projector.gameObject.transform;
		}
		this.newbie_projector.gameObject.SetActive(false);
		this.newbie_projector_line.gameObject.SetActive(false);
		return null;
	}

	// Token: 0x060008B6 RID: 2230 RVA: 0x000B351C File Offset: 0x000B171C
	public Transform setupProjector(bool bShow, ref int projectorType)
	{
		if (bShow)
		{
			Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.playerUnit[this.m_CurUltraIndex].NpcID);
			Skill recordByKey2 = DataManager.Instance.SkillTable.GetRecordByKey(recordByKey.AttackPower[1]);
			projectorType = 0;
			for (int i = 0; i < this.PJ_GraphKind.Length; i++)
			{
				if (Array.IndexOf<byte>(this.PJ_GraphKind[i], recordByKey2.SkillKind) > -1)
				{
					projectorType = i + 1;
					break;
				}
			}
			this.projector_parent.position = new Vector3(0f, 0.01f, 0f);
			this.projector_parent.rotation = Quaternion.identity;
			this.sp_projector_dist.gameObject.SetActive(true);
			this.sp_projector.gameObject.SetActive(true);
			switch (projectorType)
			{
			case 0:
				this.sp_projector_dist.ShadowSize = 0f;
				this.sp_projector.UVRect = this.ProjectorUV[1];
				this.sp_projector.ShadowSize = 0f;
				this.sp_projector_transform.localScale = Vector3.zero;
				break;
			case 1:
				this.sp_projector_dist.ShadowSize = (float)(recordByKey.Radius + recordByKey2.SkillDistance) * 0.001f;
				this.sp_projector_dist.transform.position = this.playerUnit[this.m_CurUltraIndex].Position;
				this.sp_projector.UVRect = this.ProjectorUV[1];
				this.sp_projector.ShadowSize = (float)recordByKey2.Rangeparameter1 * 0.001f;
				break;
			case 2:
			{
				this.sp_projector_dist.ShadowSize = 0f;
				this.sp_projector.UVRect = this.ProjectorUV[1];
				this.sp_projector.ShadowSize = (float)recordByKey2.Rangeparameter1 * 0.001f;
				this.sp_projector.transform.position = this.playerUnit[this.m_CurUltraIndex].Position;
				this.BSUtil.checkUltraHitTarget(0, 0, ref this.m_HitContainer);
				bool flag = recordByKey2.SkillKind > 50;
				AnimationUnit[] array = (!flag) ? this.enemyUnit : this.playerUnit;
				int num = (!flag) ? this.enemyCount : this.playerCount;
				DamageValueManager pDVMgr = GUIManager.Instance.pDVMgr;
				int side = (!flag) ? 1 : 0;
				int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
				int lightmapIndex = -1;
				int num2 = 0 + sceneLightmapSize;
				for (int j = 0; j < num; j++)
				{
					if ((this.m_HitContainer >> j & 1u) != 0u && array[j].getRenderer.lightmapIndex == num2)
					{
						array[j].getRenderer.lightmapIndex = lightmapIndex;
						pDVMgr.ShowBloodBar(side, j);
					}
				}
				break;
			}
			case 3:
			{
				this.sp_projector_dist.ShadowSize = 0f;
				Vector3 position = this.playerUnit[this.m_CurUltraIndex].Position;
				position.y = 0.01f;
				this.projector_parent.position = position;
				this.sp_projector.UVRect = this.ProjectorUV[2];
				this.sp_projector.ShadowSize = (float)recordByKey2.Rangeparameter1 * 0.0005f;
				break;
			}
			case 4:
			{
				this.sp_projector_dist.ShadowSize = 0f;
				Vector3 position2 = this.playerUnit[this.m_CurUltraIndex].Position;
				position2.y = 0.01f;
				this.projector_parent.position = position2;
				this.sp_projector.UVRect = this.ProjectorUV[3];
				float num3 = (float)recordByKey2.Rangeparameter1 * 0.0005f;
				float y = (float)recordByKey2.Rangeparameter2 * 0.0005f;
				this.sp_projector_transform.localScale = new Vector3(num3, y, num3);
				break;
			}
			case 5:
				this.sp_projector_dist.ShadowSize = (float)(recordByKey.Radius + recordByKey2.SkillDistance) * 0.001f;
				this.sp_projector_dist.transform.position = this.playerUnit[this.m_CurUltraIndex].Position;
				this.sp_projector.UVRect = this.ProjectorUV[4];
				this.BSUtil.checkUltraHitTarget(0, 0, ref this.m_HitContainer);
				this.sp_projector_line.gameObject.SetActive(true);
				break;
			case 6:
			{
				this.sp_projector_dist.ShadowSize = 0f;
				this.sp_projector.UVRect = this.ProjectorUV[1];
				this.sp_projector.ShadowSize = 0f;
				this.sp_projector_transform.localScale = Vector3.zero;
				int sceneLightmapSize2 = LightmapManager.Instance.SceneLightmapSize;
				int lightmapIndex2 = -1;
				int num4 = 0 + sceneLightmapSize2;
				DamageValueManager pDVMgr2 = GUIManager.Instance.pDVMgr;
				if (recordByKey2.SkillKind > 50)
				{
					for (int k = 0; k < this.playerCount; k++)
					{
						if (this.playerUnit[k].getRenderer.lightmapIndex == num4 && this.playerUnit[k].gameObject.activeSelf && this.playerUnit[k].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
						{
							this.playerUnit[k].getRenderer.lightmapIndex = lightmapIndex2;
							pDVMgr2.ShowBloodBar(0, k);
						}
					}
				}
				else
				{
					for (int l = 0; l < this.enemyCount; l++)
					{
						if (this.enemyUnit[l].gameObject.activeSelf && this.enemyUnit[l].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
						{
							this.enemyUnit[l].getRenderer.lightmapIndex = lightmapIndex2;
							pDVMgr2.ShowBloodBar(1, l);
						}
					}
				}
				break;
			}
			}
			this.PJ_FireRadius = ((recordByKey2.Rangeparameter2 == 0) ? ((float)recordByKey2.Rangeparameter1 * 0.01f) : ((float)recordByKey2.Rangeparameter2 * 0.01f));
			this.PJ_FireRange = (float)(recordByKey.Radius + recordByKey2.SkillDistance) * 0.01f;
			return this.sp_projector.gameObject.transform;
		}
		if (projectorType == 4)
		{
			this.sp_projector.ShadowSize = 0f;
		}
		projectorType = 0;
		this.sp_projector.gameObject.SetActive(false);
		this.sp_projector_dist.gameObject.SetActive(false);
		this.sp_projector_line.gameObject.SetActive(false);
		return null;
	}

	// Token: 0x060008B7 RID: 2231 RVA: 0x000B3BF8 File Offset: 0x000B1DF8
	public uint NumberOfSetBits(uint i)
	{
		i -= (i >> 1 & 1431655765u);
		i = (i & 858993459u) + (i >> 2 & 858993459u);
		return (i + (i >> 4) & 252645135u) * 16843009u >> 24;
	}

	// Token: 0x060008B8 RID: 2232 RVA: 0x000B3C3C File Offset: 0x000B1E3C
	public void CloseDrama()
	{
		if (this.bDramaWorking)
		{
			this.bDramaWorking = false;
			if (this.controlPanel != null)
			{
				this.controlPanel.gameObject.SetActive(true);
			}
			if (this.IsType(EBattleType.NEWBIE_FAKE))
			{
				DataManager.StageDataController.currentWorldMode = WorldMode.Wild;
				DataManager.StageDataController._stageMode = StageMode.Count;
				DataManager.Instance.GoToBattleOrWar = GameplayKind.Origin;
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
				NewbieManager.Get().LockControl(true);
				NewbieManager.CheckNewbie(null);
				GUIManager.Instance.ShowChatBox();
				GUIManager.Instance.CloseMenu(EGUIWindow.UI_Front);
			}
			else if (this.IsType(EBattleType.TEACH))
			{
				NewbieManager.SetNewbieControlLock(true);
			}
		}
	}

	// Token: 0x060008B9 RID: 2233 RVA: 0x000B3CFC File Offset: 0x000B1EFC
	public void SetupPVPOutsideNPC()
	{
		int num = UnityEngine.Random.Range(0, this.PVPWatcherList.Length);
		ushort num2 = this.PVPWatcherList[num];
		Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(num2);
		GameObject gameObject;
		if (this.m_HeroMap.ContainsKey((int)recordByKey.Modle))
		{
			BattleController.HeroRef heroRef = this.m_HeroMap[(int)recordByKey.Modle];
			heroRef.activeCount += 1;
			heroRef.refCount += 1;
			AssetBundle ab = (AssetBundle)heroRef.heroObj;
			gameObject = ModelLoader.Instance.Load(recordByKey.Modle, ab, (ushort)recordByKey.TextureNo);
		}
		else
		{
			this.StringInstance.Length = 0;
			this.StringInstance.AppendFormat("Role/hero_{0:00000}", recordByKey.Modle);
			int assetKey = 0;
			string text = this.StringInstance.ToString();
			AssetBundle assetBundle = AssetManager.GetAssetBundle(text, out assetKey, false);
			gameObject = ModelLoader.Instance.Load(recordByKey.Modle, assetBundle, (ushort)recordByKey.TextureNo);
			this.HeroRefInstance.Set(assetKey, 1, 1, assetBundle, text);
			this.m_HeroMap.Add((int)recordByKey.Modle, this.HeroRefInstance);
		}
		if (gameObject != null)
		{
			GameObject gameObject2 = null;
			AnimationUnit animationUnit = this.setupAnimationObject(gameObject, 3, 0, num2, out gameObject2);
			animationUnit.initComponent(num2);
			animationUnit.IsBoss = false;
			animationUnit.IsEnemy = false;
			float npcScale = (recordByKey.Scale == 100) ? 1.17f : ((float)recordByKey.Scale / 100f * 1.17f);
			animationUnit.setNpcScale(npcScale);
			long num3 = ArenaManager.Instance.ArenaPlayingData.Time & 1L;
			if (num3 != 1L)
			{
				this.Vec3Instance.Set(12.07f, 0.43f, 10000f);
				animationUnit.updateDirection(this.Vec3Instance);
				this.Vec3Instance.Set(12.07f, 0.43f, -4.72f);
			}
			else
			{
				this.Vec3Instance.Set(12.07f, 0.43f, -10000f);
				animationUnit.updateDirection(this.Vec3Instance);
				this.Vec3Instance.Set(12.07f, 0.43f, 15.66f);
			}
			Vector3 vec3Instance = this.Vec3Instance;
			animationUnit.setPositionInstantly(this.Vec3Instance);
			animationUnit.setState(HERO_STATE_ENUM.HERO_COMMANDS_PVPNPC_IDLE, null, 0, 0, 0);
			this.PVPWatcher = animationUnit;
		}
	}

	// Token: 0x060008BA RID: 2234 RVA: 0x000B3F74 File Offset: 0x000B2174
	public void AddGambleItemBox(ushort ItemID, byte ItemRank)
	{
		AnimationUnit animationUnit;
		if (this.enemyUnit[1] != null && this.enemyUnit[1].gameObject.activeSelf)
		{
			animationUnit = this.enemyUnit[1];
		}
		else
		{
			animationUnit = this.enemyUnit[0];
		}
		int num = 1;
		if (Camera.main.WorldToScreenPoint(animationUnit.Position).y < RewardManager.getInstance.ScreenSize.y * 0.5f)
		{
			num = -1;
		}
		RewardManager.getInstance.addReward(ItemID, animationUnit.HitPointRoot.position, animationUnit.Position + this.getRewardRandomPos() * (float)num, ItemRank);
	}

	// Token: 0x04001CC9 RID: 7369
	public const int MAX_GRAPHKIND = 8;

	// Token: 0x04001CCA RID: 7370
	public const float SCENE_CENTER_X = 11.9f;

	// Token: 0x04001CCB RID: 7371
	public const float SCENE_CENTER_Z = 5.5f;

	// Token: 0x04001CCC RID: 7372
	public const float BATTLE_SCENE_SIZE_X = 23.8f;

	// Token: 0x04001CCD RID: 7373
	public const float BATTLE_SCENE_SIZE_Z = 11f;

	// Token: 0x04001CCE RID: 7374
	public const ushort MAX_ENERGY = 1000;

	// Token: 0x04001CCF RID: 7375
	public const float GLOBAL_MODEL_SCALE = 1.17f;

	// Token: 0x04001CD0 RID: 7376
	public const float NEWBIE_ULTRA_DELAY = 0.85f;

	// Token: 0x04001CD1 RID: 7377
	public const int MAX_ENEMIES = 20;

	// Token: 0x04001CD2 RID: 7378
	public const int MAX_PLAYERS = 5;

	// Token: 0x04001CD3 RID: 7379
	public const int MAX_ACTORS = 25;

	// Token: 0x04001CD4 RID: 7380
	public const byte PLAYER_ATTR_DIRTY = 1;

	// Token: 0x04001CD5 RID: 7381
	public const byte ENEMY_ATTR_DIRTY = 2;

	// Token: 0x04001CD6 RID: 7382
	public const int MAX_SOUNDTRIGGER_RATE = 60;

	// Token: 0x04001CD7 RID: 7383
	public static readonly Color[] StateSkin = new Color[]
	{
		new Color(1f, 0.2f, 0.2f),
		new Color(0.2f, 1f, 0.2f),
		new Color(0.1f, 0.1f, 0.1f),
		new Color(0.4f, 0.4f, 0.4f)
	};

	// Token: 0x04001CD8 RID: 7384
	public Rect[] ProjectorUV = new Rect[8];

	// Token: 0x04001CD9 RID: 7385
	public byte[][] PJ_GraphKind = new byte[][]
	{
		new byte[]
		{
			4,
			9,
			10,
			14,
			51,
			56,
			57
		},
		new byte[]
		{
			3,
			12,
			18,
			59
		},
		new byte[]
		{
			1
		},
		new byte[]
		{
			2
		},
		new byte[]
		{
			6,
			7,
			8,
			11,
			15,
			16,
			17,
			19,
			53,
			54,
			55,
			58
		},
		new byte[]
		{
			5,
			13,
			52,
			60
		}
	};

	// Token: 0x04001CDA RID: 7386
	public Vector2[] F_SpreadOffset = new Vector2[]
	{
		new Vector2(0f, 2f),
		new Vector2(2f, 2f),
		new Vector2(2f, 0f),
		new Vector2(2f, -2f),
		new Vector2(0f, -2f),
		new Vector2(-2f, -2f),
		new Vector2(-2f, 0f),
		new Vector2(-2f, 2f)
	};

	// Token: 0x04001CDB RID: 7387
	public ChaseType[] FT2CT = new ChaseType[]
	{
		ChaseType.Straight,
		ChaseType.CurveA,
		ChaseType.Straight,
		ChaseType.Straight,
		ChaseType.CurveLeft,
		ChaseType.CurveRight,
		ChaseType.Straight,
		ChaseType.CurveRandom
	};

	// Token: 0x04001CDC RID: 7388
	private Vector3 Vec3Instance = new Vector3(0f, 0f, 0f);

	// Token: 0x04001CDD RID: 7389
	private StringBuilder StringInstance = new StringBuilder(64);

	// Token: 0x04001CDE RID: 7390
	public static EBattleMode BattleMode = EBattleMode.Default;

	// Token: 0x04001CDF RID: 7391
	public EBattleType BattleType;

	// Token: 0x04001CE0 RID: 7392
	public AnimationUnit[] playerUnit = new AnimationUnit[5];

	// Token: 0x04001CE1 RID: 7393
	public BattleController.HeroAttr[] playerAttr = new BattleController.HeroAttr[5];

	// Token: 0x04001CE2 RID: 7394
	public AnimationUnit[] enemyUnit = new AnimationUnit[20];

	// Token: 0x04001CE3 RID: 7395
	public BattleController.HeroAttr[] enemyAttr = new BattleController.HeroAttr[20];

	// Token: 0x04001CE4 RID: 7396
	public int playerCount;

	// Token: 0x04001CE5 RID: 7397
	public int enemyCount;

	// Token: 0x04001CE6 RID: 7398
	public int enemyAliveCount;

	// Token: 0x04001CE7 RID: 7399
	public int totalAliveCount;

	// Token: 0x04001CE8 RID: 7400
	public float totalDieAliveRate;

	// Token: 0x04001CE9 RID: 7401
	public byte m_bHPMPDirty;

	// Token: 0x04001CEA RID: 7402
	public float FirstPlayerPosX;

	// Token: 0x04001CEB RID: 7403
	public bool bTimeUp;

	// Token: 0x04001CEC RID: 7404
	private int[] m_HeroIDFilter = new int[25];

	// Token: 0x04001CED RID: 7405
	private int m_IDFilterCount;

	// Token: 0x04001CEE RID: 7406
	private BattleController.HeroRef HeroRefInstance = default(BattleController.HeroRef);

	// Token: 0x04001CEF RID: 7407
	private Dictionary<int, BattleController.HeroRef> m_HeroMap = new Dictionary<int, BattleController.HeroRef>(25);

	// Token: 0x04001CF0 RID: 7408
	private Dictionary<int, UnityEngine.Object> m_HeroTemp = new Dictionary<int, UnityEngine.Object>(25);

	// Token: 0x04001CF1 RID: 7409
	public uint m_ui32Tcik;

	// Token: 0x04001CF2 RID: 7410
	private static byte[] RecvBufferLeft;

	// Token: 0x04001CF3 RID: 7411
	private static byte[] RecvBufferRight;

	// Token: 0x04001CF4 RID: 7412
	private static byte[] BufferForServer;

	// Token: 0x04001CF5 RID: 7413
	private int m_MaxSkillList;

	// Token: 0x04001CF6 RID: 7414
	private int m_MaxSkillWorkingList;

	// Token: 0x04001CF7 RID: 7415
	private static int[] m_MaxSkillIdTemp;

	// Token: 0x04001CF8 RID: 7416
	private uint m_HitContainer;

	// Token: 0x04001CF9 RID: 7417
	private byte m_HitContainerSide;

	// Token: 0x04001CFA RID: 7418
	private int m_CurUltraIndex = -1;

	// Token: 0x04001CFB RID: 7419
	private GameObject ultraLoopParticle;

	// Token: 0x04001CFC RID: 7420
	public float PJ_FireRadius;

	// Token: 0x04001CFD RID: 7421
	public float PJ_FireRange;

	// Token: 0x04001CFE RID: 7422
	public int lastNearestTargetIndex = -1;

	// Token: 0x04001CFF RID: 7423
	private ulong m_StateUpdateFlag;

	// Token: 0x04001D00 RID: 7424
	private ushort m_RewardOffset;

	// Token: 0x04001D01 RID: 7425
	private ushort m_DropRewardCount;

	// Token: 0x04001D02 RID: 7426
	private ushort m_RewardCount;

	// Token: 0x04001D03 RID: 7427
	private byte m_RewardRandomFlag = 9;

	// Token: 0x04001D04 RID: 7428
	private byte[] m_DropPerEnemy = new byte[20];

	// Token: 0x04001D05 RID: 7429
	private Vector3[] m_RewardRandomPos = new Vector3[]
	{
		new Vector3(-1.5f, 0f, -1.5f),
		new Vector3(-1.5f, 0f, -3f),
		new Vector3(-1.5f, 0f, -4.5f),
		new Vector3(-3f, 0f, -1.5f),
		new Vector3(-3f, 0f, -3f),
		new Vector3(-3f, 0f, -4.5f),
		new Vector3(-4.5f, 0f, -1.5f),
		new Vector3(-4.5f, 0f, -3f),
		new Vector3(-4.5f, 0f, -4.5f)
	};

	// Token: 0x04001D06 RID: 7430
	public float deltaTime;

	// Token: 0x04001D07 RID: 7431
	private float autoBattleDeltaTime;

	// Token: 0x04001D08 RID: 7432
	private float fixMoveDeltaTime;

	// Token: 0x04001D09 RID: 7433
	private float canMoveDeltaTime;

	// Token: 0x04001D0A RID: 7434
	public float maxSkillTimeCache;

	// Token: 0x04001D0B RID: 7435
	private byte closetHeroIndexCache;

	// Token: 0x04001D0C RID: 7436
	private bool bUseTimeCache;

	// Token: 0x04001D0D RID: 7437
	public static bool AutoBattleFlag = false;

	// Token: 0x04001D0E RID: 7438
	private bool bAutoBattle;

	// Token: 0x04001D0F RID: 7439
	private BSInvokeUtil BSUtil;

	// Token: 0x04001D10 RID: 7440
	private ChaseManager ChaseMgr;

	// Token: 0x04001D11 RID: 7441
	private BattleCamera BCamera = new BattleCamera();

	// Token: 0x04001D12 RID: 7442
	public static byte CameraModel = 0;

	// Token: 0x04001D13 RID: 7443
	public static bool IsPVPDefSide = false;

	// Token: 0x04001D14 RID: 7444
	private byte m_BattleResult;

	// Token: 0x04001D15 RID: 7445
	public BattleController.BattleState m_BattleState;

	// Token: 0x04001D16 RID: 7446
	public byte m_SubStateFlag;

	// Token: 0x04001D17 RID: 7447
	public bool IsBattleEnd;

	// Token: 0x04001D18 RID: 7448
	public bool NextLevelWorking;

	// Token: 0x04001D19 RID: 7449
	public HeroTeam[] teamTable = new HeroTeam[3];

	// Token: 0x04001D1A RID: 7450
	public int m_MaxStageLevel;

	// Token: 0x04001D1B RID: 7451
	public int m_CurStageLevel;

	// Token: 0x04001D1C RID: 7452
	public Transform mapObject1;

	// Token: 0x04001D1D RID: 7453
	public Transform mapObject2;

	// Token: 0x04001D1E RID: 7454
	private List<Transform>[] soundList = new List<Transform>[10];

	// Token: 0x04001D1F RID: 7455
	private CHashTable<ushort, int> soundPlayMap = new CHashTable<ushort, int>(10, true);

	// Token: 0x04001D20 RID: 7456
	private int m_LastSoundListIdx;

	// Token: 0x04001D21 RID: 7457
	private bool m_bSoundDirty;

	// Token: 0x04001D22 RID: 7458
	public int hitSoundTriggerRate;

	// Token: 0x04001D23 RID: 7459
	public int hitSoundRateBase;

	// Token: 0x04001D24 RID: 7460
	public float m_StateSkinTimeLen;

	// Token: 0x04001D25 RID: 7461
	public int m_StateSkinFlag = 1;

	// Token: 0x04001D26 RID: 7462
	public float m_StateSkinTimer;

	// Token: 0x04001D27 RID: 7463
	private int[] m_SkinColorLightmapIndex = new int[4];

	// Token: 0x04001D28 RID: 7464
	private Texture2D[] m_SkinColorLightmapTex = new Texture2D[4];

	// Token: 0x04001D29 RID: 7465
	public UIBattle uiBattle;

	// Token: 0x04001D2A RID: 7466
	public int ProjectorABKey;

	// Token: 0x04001D2B RID: 7467
	public Transform projector_parent;

	// Token: 0x04001D2C RID: 7468
	public ShadowProjector sp_projector;

	// Token: 0x04001D2D RID: 7469
	public ShadowProjector sp_projector_dist;

	// Token: 0x04001D2E RID: 7470
	public MeshFilter sp_projector_line;

	// Token: 0x04001D2F RID: 7471
	public Transform sp_projector_transform;

	// Token: 0x04001D30 RID: 7472
	public Transform sp_projector_line_transform;

	// Token: 0x04001D31 RID: 7473
	public Transform newbie_projector_parent;

	// Token: 0x04001D32 RID: 7474
	public Transform newbie_projector_transform;

	// Token: 0x04001D33 RID: 7475
	public ShadowProjector newbie_projector;

	// Token: 0x04001D34 RID: 7476
	public MeshFilter newbie_projector_line;

	// Token: 0x04001D35 RID: 7477
	public Transform newbie_projector_line_transform;

	// Token: 0x04001D36 RID: 7478
	public BattleControllerPanel controlPanel;

	// Token: 0x04001D37 RID: 7479
	private BattleController.MSNode[] ms_viewer = new BattleController.MSNode[5];

	// Token: 0x04001D38 RID: 7480
	private byte ultraHitSoundKey = byte.MaxValue;

	// Token: 0x04001D39 RID: 7481
	private float? UltraNewbieDelay;

	// Token: 0x04001D3A RID: 7482
	private byte NewbieUltraTimes;

	// Token: 0x04001D3B RID: 7483
	public List<AnimationUnit> m_SupportDisplayList = new List<AnimationUnit>(10);

	// Token: 0x04001D3C RID: 7484
	public uint DramaTriggerFlag;

	// Token: 0x04001D3D RID: 7485
	public bool bDramaWorking;

	// Token: 0x04001D3E RID: 7486
	private int shadowABKey;

	// Token: 0x04001D3F RID: 7487
	private HeroBattleData tempBattleData = default(HeroBattleData);

	// Token: 0x04001D40 RID: 7488
	private HeroBattleData[] heroBattleData;

	// Token: 0x04001D41 RID: 7489
	private int MonsterIdxTemp;

	// Token: 0x04001D42 RID: 7490
	public bool IsReplay_PVP;

	// Token: 0x04001D43 RID: 7491
	public AnimationUnit PVPWatcher;

	// Token: 0x04001D44 RID: 7492
	public readonly ushort[] PVPWatcherList = new ushort[]
	{
		1,
		2,
		3,
		4,
		5,
		6,
		7,
		8,
		9,
		10,
		11,
		12,
		13,
		14,
		15,
		16,
		17,
		18,
		19,
		20,
		21,
		22,
		23,
		24,
		25,
		26,
		27,
		28,
		29,
		30,
		100,
		192,
		193,
		194,
		195,
		196,
		197,
		199,
		201,
		202,
		203,
		204,
		205,
		206,
		207,
		208,
		209,
		210,
		211,
		212,
		213,
		214,
		215,
		216,
		217,
		218,
		219,
		220,
		224,
		225,
		226,
		227,
		228,
		230
	};

	// Token: 0x04001D45 RID: 7493
	public static EGambleMode GambleMode = EGambleMode.Normal;

	// Token: 0x04001D46 RID: 7494
	public static int GambleResult = 0;

	// Token: 0x04001D47 RID: 7495
	public long GambleTimeCache;

	// Token: 0x04001D48 RID: 7496
	public bool CasinoHitDirty;

	// Token: 0x04001D49 RID: 7497
	public bool bIgnoreSupport;

	// Token: 0x04001D4A RID: 7498
	public AnimationUnit SupportAU;

	// Token: 0x04001D4B RID: 7499
	public int SupportIdx;

	// Token: 0x04001D4C RID: 7500
	public ushort CurrentStageID;

	// Token: 0x04001D4D RID: 7501
	private Fader fader;

	// Token: 0x020001DB RID: 475
	public struct HeroAttr
	{
		// Token: 0x04001D4E RID: 7502
		public uint MAX_HP;

		// Token: 0x04001D4F RID: 7503
		public uint MAX_MP;

		// Token: 0x04001D50 RID: 7504
		public uint CUR_HP;

		// Token: 0x04001D51 RID: 7505
		public uint CUR_MP;
	}

	// Token: 0x020001DC RID: 476
	private struct HeroRef
	{
		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060008BC RID: 2236 RVA: 0x000B403C File Offset: 0x000B223C
		// (set) Token: 0x060008BB RID: 2235 RVA: 0x000B4030 File Offset: 0x000B2230
		public UnityEngine.Object heroObj
		{
			get
			{
				if (this.heroAsset == null && this.path != null)
				{
					AssetManager.UnloadAssetBundle(this.assetKey, true);
					AssetBundle assetBundle = AssetManager.GetAssetBundle(this.path, out this.assetKey);
					this.heroAsset = assetBundle;
				}
				return this.heroAsset;
			}
			set
			{
				this.heroAsset = value;
			}
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x000B4090 File Offset: 0x000B2290
		public void Set(int _assetKey, short _refCount, short _activeCount, UnityEngine.Object _heroAsset, string _path)
		{
			this.assetKey = _assetKey;
			this.refCount = _refCount;
			this.activeCount = _activeCount;
			this.heroAsset = _heroAsset;
			this.path = new CString(20);
			this.path.ClearString();
			this.path.Append(_path);
		}

		// Token: 0x04001D52 RID: 7506
		public UnityEngine.Object heroAsset;

		// Token: 0x04001D53 RID: 7507
		public int assetKey;

		// Token: 0x04001D54 RID: 7508
		public short refCount;

		// Token: 0x04001D55 RID: 7509
		public short activeCount;

		// Token: 0x04001D56 RID: 7510
		public CString path;
	}

	// Token: 0x020001DD RID: 477
	public enum BattleState
	{
		// Token: 0x04001D58 RID: 7512
		BATTLE_STOP,
		// Token: 0x04001D59 RID: 7513
		WAITING_FOR_START,
		// Token: 0x04001D5A RID: 7514
		BATTLE_RUNNING,
		// Token: 0x04001D5B RID: 7515
		BATTLE_FINISHING,
		// Token: 0x04001D5C RID: 7516
		BATTLE_WAITTING_FOR_VICTORY,
		// Token: 0x04001D5D RID: 7517
		BATTLE_SHOW_RESULT_UI,
		// Token: 0x04001D5E RID: 7518
		BATTLE_AUTOBATTLE_WAITING,
		// Token: 0x04001D5F RID: 7519
		BATTLE_MAXSKILL_WORKING,
		// Token: 0x04001D60 RID: 7520
		BATTLE_SUPPORT_DISPLAY,
		// Token: 0x04001D61 RID: 7521
		BATTLE_FINISHING_SPREAD,
		// Token: 0x04001D62 RID: 7522
		BATTLE_CHECK_GAMBLE_TIMEOUT,
		// Token: 0x04001D63 RID: 7523
		BATTLE_CHECK_DIE_BEFORE_SUPPORT,
		// Token: 0x04001D64 RID: 7524
		BATTLE_FINISHED
	}

	// Token: 0x020001DE RID: 478
	public struct MSNode
	{
		// Token: 0x04001D65 RID: 7525
		public byte working;

		// Token: 0x04001D66 RID: 7526
		public byte ui_state;
	}
}
