using System;
using UnityEngine;

// Token: 0x02000430 RID: 1072
public class Origin : Gameplay
{
	// Token: 0x170000A0 RID: 160
	// (get) Token: 0x060015BF RID: 5567 RVA: 0x0024FCF4 File Offset: 0x0024DEF4
	public World WorldController
	{
		get
		{
			return this.worldController;
		}
	}

	// Token: 0x060015C0 RID: 5568 RVA: 0x0024FCFC File Offset: 0x0024DEFC
	~Origin()
	{
	}

	// Token: 0x060015C1 RID: 5569 RVA: 0x0024FD34 File Offset: 0x0024DF34
	protected override void UpdateNews(byte[] meg)
	{
		GAME_PLAYER_NEWS game_PLAYER_NEWS = (GAME_PLAYER_NEWS)meg[0];
		switch (game_PLAYER_NEWS)
		{
		case GAME_PLAYER_NEWS.ORIGIN_OpenStage:
			if (GUIManager.Instance.m_WindowStack.Count == 0)
			{
				if (DataManager.StageDataController._stageMode == StageMode.Corps)
				{
					this.doorController.OpenMenu(EGUIWindow.UI_StageSelect2, (int)((DataManager.Instance.lastBattleResult != 1) ? (DataManager.StageDataController.StageRecord[2] + 1) : DataManager.StageDataController.StageRecord[2]), 0, false);
				}
				else
				{
					this.doorController.OpenMenu(EGUIWindow.UI_StageSelect, (int)DataManager.StageDataController.currentChapterID, 0, false);
				}
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_OpenStageStory:
			if (meg[1] == 1)
			{
				this.doorController.CloseMenu(false);
			}
			if (DataManager.StageDataController._stageMode == StageMode.Corps)
			{
				this.doorController.OpenMenu(EGUIWindow.UI_StageStory, (int)((meg[1] != 1) ? (DataManager.StageDataController.StageRecord[2] + 1) : DataManager.StageDataController.StageRecord[2]), (int)meg[1], true);
			}
			else
			{
				this.doorController.OpenMenu(EGUIWindow.UI_StageStory, (int)DataManager.StageDataController.currentChapterID, (int)meg[1], true);
			}
			GUIManager.Instance.m_HUDMessage.MapHud.SkipMsg();
			break;
		case GAME_PLAYER_NEWS.ORIGIN_CloseStageStory:
			this.doorController.CloseMenu(false);
			DataManager.msgBuffer[0] = 16;
			this.worldController.Renew(DataManager.msgBuffer, null);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_OpenStageInfo:
			this.doorController.OpenMenu(EGUIWindow.UI_StageInfo, 0, 0, true);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_OpenPve:
			this.doorController.m_GroundInfo.OpenPvePanel(true, DataManager.StageDataController.StageRecord[2] + 1);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_CameraStateWild:
			this.worldController.Renew(meg, null);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_CloseNewTerritory:
			GUIManager.Instance.CloseMenu(EGUIWindow.UI_NewTerritory);
			if (NewbieManager.CheckGoldGuy())
			{
				NewbieManager.CheckTeach(ETeachKind.GOLDGUY, null, false);
			}
			else if (NewbieManager.CheckArmyHole(true))
			{
				NewbieManager.CheckTeach(ETeachKind.ARMY_HOLE, null, false);
			}
			else
			{
				NewbieManager.CheckGambleNormal();
			}
			this.worldController.WorldUIQueueLockRelease();
			this.worldController.WorldUIQueueLockRelease();
			break;
		case GAME_PLAYER_NEWS.ORIGIN_OpenUpWild:
			GUIManager.Instance.CloseCheckCrystalBox();
			GUIManager.Instance.CloseOKCancelBox();
			this.doorController.CloseMenu(true);
			DataManager.msgBuffer[0] = 21;
			this.worldController.Renew(DataManager.msgBuffer, null);
			break;
		default:
			switch (game_PLAYER_NEWS)
			{
			case GAME_PLAYER_NEWS.Network_Update:
				if (meg[1] == 43)
				{
					this.doorController.ViewKingdom();
				}
				else if (meg[1] == 42 && DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID)
				{
					DataManager.MapDataController.FocusKingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
					GUIManager.Instance.HideUILock(EUILock.Normal);
					DataManager.MapDataController.gotoKingdomState = 0;
				}
				this.worldController.Renew(meg, null);
				return;
			case GAME_PLAYER_NEWS.HeroTalk_Close:
				if (NewbieManager.IsNewbie)
				{
					NewbieManager.Get().NextStep();
				}
				Indemnify.UpdateNetwork(meg);
				return;
			}
			this.worldController.Renew(meg, null);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_OpenBuild:
			GUIManager.Instance.BuildingData.OpenUI(GameConstants.ConvertBytesToUShort(meg, 1), this.doorController);
			DataManager.msgBuffer[0] = 23;
			this.worldController.Renew(DataManager.msgBuffer, null);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_UpdateBuild:
			this.worldController.Renew(meg, null);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_CloseBuild:
			this.doorController.CloseMenu(false);
			DataManager.msgBuffer[0] = 33;
			this.worldController.Renew(DataManager.msgBuffer, null);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_ChangeStageMode:
			if (this.worldController && this.doorController)
			{
				UIStageSelect uistageSelect = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect;
				if (uistageSelect)
				{
					if (uistageSelect.NFlash.activeSelf)
					{
						meg[1] = 1;
					}
					else if (uistageSelect.EFlash.activeSelf)
					{
						meg[1] = 2;
					}
					else if (uistageSelect.AFlash.activeSelf)
					{
						meg[1] = 3;
					}
					this.worldController.Renew(meg, null);
				}
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_OpenTreasureInfo:
			if (meg[1] == 1)
			{
				this.doorController.CloseMenu(false);
			}
			this.doorController.OpenMenu(EGUIWindow.UI_ChapterRewards, (int)DataManager.StageDataController.currentChapterID, (int)meg[1], true);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_CloseTreasureInfo:
			this.doorController.CloseMenu(false);
			DataManager.msgBuffer[0] = 39;
			this.worldController.Renew(DataManager.msgBuffer, null);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_SetCastleLevel:
			AssetManager.OriginSetCastleLevel(meg[1], meg[2]);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_ShowUI:
			this.HideUI = 0;
			this.doorController.m_TopLayer.gameObject.SetActive(true);
			for (int i = 1; i < GUIManager.Instance.m_WindowsTransform.childCount; i++)
			{
				GUIManager.Instance.m_WindowsTransform.GetChild(i).gameObject.SetActive(true);
			}
			if (GUIManager.Instance.m_WindowStack.Count == 0)
			{
				if (DataManager.StageDataController._stageMode == StageMode.Corps)
				{
					GUIWindow x = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect2);
					if (x == null)
					{
						this.doorController.OpenMenu(EGUIWindow.UI_StageSelect2, (int)((DataManager.Instance.lastBattleResult != 1) ? (DataManager.StageDataController.StageRecord[2] + 1) : DataManager.StageDataController.StageRecord[2]), 0, false);
					}
				}
				else
				{
					GUIWindow x = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect);
					if (x == null)
					{
						this.doorController.OpenMenu(EGUIWindow.UI_StageSelect, (int)DataManager.StageDataController.currentChapterID, 0, false);
					}
				}
			}
			this.doorController.HideFightButton();
			break;
		case GAME_PLAYER_NEWS.ORIGIN_HideUI:
			this.HideUI = 1;
			this.doorController.m_TopLayer.gameObject.SetActive(false);
			for (int j = 1; j < GUIManager.Instance.m_WindowsTransform.childCount; j++)
			{
				GUIManager.Instance.m_WindowsTransform.GetChild(j).gameObject.SetActive(false);
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_BackgroundEnable:
			if (this.worldController && !this.worldController.gameObject.activeSelf)
			{
				this.worldController.gameObject.SetActive(true);
				if (LandWalkerManager.alive)
				{
					LandWalkerManager.Instance.enabled = true;
				}
				GameManager.RemoveObserver(0, 3, this);
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_BackgroundDisable:
			if (this.worldController && this.worldController.gameObject.activeSelf)
			{
				this.worldController.gameObject.SetActive(false);
				if (LandWalkerManager.alive)
				{
					LandWalkerManager.Instance.enabled = false;
				}
				GameManager.RegisterObserver(0, 3, this, 1);
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_DoorFadeOut:
			if (this.doorController != null)
			{
				this.doorController.BeginFadeInOut();
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_DoorFadeIn:
			if (this.doorController != null)
			{
				this.doorController.BeginFadeIn();
			}
			break;
		}
	}

	// Token: 0x060015C2 RID: 5570 RVA: 0x002504D0 File Offset: 0x0024E6D0
	protected override void UpdateNext(byte[] meg)
	{
		this.ClearUpdateDelegates();
		this.doorController.DeSpawnMainEff();
		this.doorController.setFightButton(null);
		GUIManager.Instance.CloseMenu(EGUIWindow.Door);
		this.doorController = null;
		UnityEngine.Object.Destroy(this.worldController.gameObject);
		this.worldController = null;
		GUIManager.Instance.ClearMapSprite();
		GUIManager.Instance.DestroyTechIconSprite();
		GUIManager.Instance.UnloadWonderSprite();
		GUIManager.Instance.EmojiManager.Clear();
		ActivityGiftManager.Instance.DespawnActivityGiftEffect(true);
		ParticleManager.Instance.Clear();
	}

	// Token: 0x060015C3 RID: 5571 RVA: 0x00250568 File Offset: 0x0024E768
	protected override void UpdateLoad(byte[] meg)
	{
		DataManager.Instance.GoToBattleOrWar = GameplayKind.Origin;
		ParticleManager.Instance.Setup();
		GameManager.RemoveObserver(0, 3, this);
		GameManager.RegisterObserver(1, 0, this, 1);
		GameObject gameObject = new GameObject("Catcher");
		gameObject.layer = 5;
		GUIManager.Instance.StretchTransform(gameObject.AddComponent<RectTransform>());
		gameObject.transform.SetParent(GUIManager.Instance.m_WindowsTransform, false);
		gameObject.transform.SetAsFirstSibling();
		this.worldController = gameObject.AddComponent<World>();
		this.doorController = (GUIManager.Instance.OpenMenu(EGUIWindow.Door, 0, 0, true, false, false) as Door);
		this.worldController.sprite = GUIManager.Instance.m_ChatImage.sprite;
		this.worldController.material = GUIManager.Instance.m_ChatImage.material;
		GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
		AudioManager.Instance.LoadAndPlayBGM(BGMType.Main, 1, false);
		NewbieManager.CheckNewbie(null);
		if (NewbieManager.IsNewbie)
		{
			Camera.main.transform.position = new Vector3(-26.9f, 180f, 154.9f);
		}
		AssetManager.Instance.AssetManagerState = AssetState.Ready;
	}

	// Token: 0x060015C4 RID: 5572 RVA: 0x0025069C File Offset: 0x0024E89C
	protected override void UpdateReady(byte[] meg)
	{
		if (DataManager.StageDataController.currentWorldMode == WorldMode.OpenUp && this.HideUI == 0)
		{
			DataManager.msgBuffer[0] = 14;
			this.UpdateNews(DataManager.msgBuffer);
		}
		if (NetworkManager.Connected())
		{
			GUIManager.Instance.HideUILock(EUILock.Network);
		}
		GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Update);
		this.doorController.LoadMainEff(EMapEffectKind.ORIGIN);
	}

	// Token: 0x060015C5 RID: 5573 RVA: 0x00250708 File Offset: 0x0024E908
	protected override void UpdateRun(byte[] meg)
	{
		this.worldController.updateDelegates[(int)this.worldController.worldState]();
	}

	// Token: 0x04004015 RID: 16405
	private World worldController;

	// Token: 0x04004016 RID: 16406
	private Door doorController;

	// Token: 0x04004017 RID: 16407
	private byte HideUI;
}
