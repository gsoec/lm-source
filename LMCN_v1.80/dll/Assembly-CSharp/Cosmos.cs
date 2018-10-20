using System;
using UnityEngine;

// Token: 0x0200027E RID: 638
public class Cosmos : Gameplay
{
	// Token: 0x06000C2D RID: 3117 RVA: 0x00118C60 File Offset: 0x00116E60
	~Cosmos()
	{
	}

	// Token: 0x06000C2E RID: 3118 RVA: 0x00118C98 File Offset: 0x00116E98
	private void UpdateWorld()
	{
		if (this.totalityController != null)
		{
			this.totalityController.ClearEffect();
			UnityEngine.Object.DestroyObject(this.totalityController.gameObject);
		}
		this.totalityController = null;
		ParticleManager.Instance.Clear();
		ParticleManager.Instance.Setup();
		AudioManager.Instance.LoadAndPlayBGM(BGMType.Legion, 1, false);
		GameObject gameObject = new GameObject("TotalityGroup");
		gameObject.transform.SetParent(GUIManager.Instance.m_UICanvas.transform, false);
		gameObject.transform.SetAsFirstSibling();
		this.totalityController = gameObject.GetComponent<Totality>();
		if (this.totalityController == null)
		{
			this.totalityController = gameObject.AddComponent<Totality>();
		}
		gameObject.transform.localScale = Vector3.one * DataManager.MapDataController.worldZoomSize;
		this.doorController.notifyHomeBtnPos();
		this.doorController.SetCapitalLocation((ushort)this.totalityController.worldMapController.homePos.x, (ushort)this.totalityController.worldMapController.homePos.y);
		this.totalityController.worldMapController.CheckCenterPos();
		if (this.doorController.m_WindowStack.Count != 0)
		{
			this.totalityController.gameObject.SetActive(false);
		}
		byte b = DataManager.MapDataController.WorldKingdomTableIDcounter;
		b &= 31;
		byte b2 = 0;
		while ((int)b2 < DataManager.MapDataController.WorldKingdomTable.Length)
		{
			if (DataManager.MapDataController.WorldKingdomTable[(int)b].kingdomID != 0)
			{
				KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.WorldKingdomTable[(int)b].kingdomID);
				int num = (int)(DataManager.MapDataController.WorldMaxX - DataManager.MapDataController.WorldMinX + 1);
				int num2 = (int)(recordByKey.worldPosX - DataManager.MapDataController.WorldMinX) + (int)(recordByKey.worldPosY - DataManager.MapDataController.WorldMinY) * num;
				if (DataManager.MapDataController.TileMapKingdomID[num2].tableID == b)
				{
					this.totalityController.UpdateKingdom(b, 25);
				}
			}
			b += 1;
			b &= 31;
			b2 += 1;
		}
		GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
	}

	// Token: 0x06000C2F RID: 3119 RVA: 0x00118EF4 File Offset: 0x001170F4
	protected override void UpdateNews(byte[] meg)
	{
		GAME_PLAYER_NEWS game_PLAYER_NEWS = (GAME_PLAYER_NEWS)meg[0];
		switch (game_PLAYER_NEWS)
		{
		case GAME_PLAYER_NEWS.COSMOS_UpdateKingdom:
			if (this.totalityController != null)
			{
				this.totalityController.UpdateKingdom(meg[1], meg[2]);
			}
			break;
		case GAME_PLAYER_NEWS.COSMOS_ShowMapLoading:
			this.doorController.ShowLoadingImg();
			break;
		case GAME_PLAYER_NEWS.COSMOS_FinishMapLoading:
			this.doorController.HideLoadingImg();
			break;
		case GAME_PLAYER_NEWS.COSMOS_GoHomePosIn:
		case GAME_PLAYER_NEWS.COSMOS_GoHomePosOut:
			if (this.totalityController != null)
			{
				this.totalityController.worldMapController.setGoHomeButtonPos((GAME_PLAYER_NEWS)meg[0]);
			}
			break;
		case GAME_PLAYER_NEWS.COSMOS_HomeInSide:
			this.doorController.SetShowHomeBtn(false);
			break;
		case GAME_PLAYER_NEWS.COSMOS_HomeOutSide:
			this.doorController.SetShowHomeBtn(true);
			break;
		case GAME_PLAYER_NEWS.COSMOS_GoHomeOffSetUpdate:
			this.doorController.SetHomeBtnLocation((ushort)GameConstants.ConvertBytesToFloat(meg, 1), (ushort)GameConstants.ConvertBytesToFloat(meg, 5));
			break;
		case GAME_PLAYER_NEWS.COSMOS_FinishClickKingdom:
			this.doorController.ViewKingdom();
			break;
		case GAME_PLAYER_NEWS.COSMOS_UpdatePos:
			this.doorController.UpdateLocation((ushort)GameConstants.ConvertBytesToFloat(meg, 1), (ushort)GameConstants.ConvertBytesToFloat(meg, 5), GameConstants.ConvertBytesToFloat(meg, 9), GameConstants.ConvertBytesToFloat(meg, 13));
			break;
		case GAME_PLAYER_NEWS.COSMOS_DoorOpenMenu:
			if (this.totalityController != null && this.totalityController.gameObject.activeSelf)
			{
				this.totalityController.gameObject.SetActive(false);
			}
			break;
		case GAME_PLAYER_NEWS.COSMOS_DoorCloseMenu:
			if (this.totalityController != null && !this.totalityController.gameObject.activeSelf)
			{
				this.totalityController.gameObject.SetActive(true);
			}
			break;
		case GAME_PLAYER_NEWS.COSMOS_GoToKingdom:
		{
			ushort num = GameConstants.ConvertBytesToUShort(meg, 1);
			if (num == ActivityManager.Instance.KOWKingdomID && ActivityManager.Instance.IsNobilityWarRunning(false))
			{
				this.doorController.GoToKingdom(num, (int)DataManager.MapDataController.GetYolkMapID((ushort)ActivityManager.Instance.FederalFullEventTimeWonderID, num));
			}
			else
			{
				this.doorController.GoToKingdom(num, (int)DataManager.MapDataController.GetYolkMapID(0, num));
			}
			break;
		}
		case GAME_PLAYER_NEWS.COSMOS_MoveToKingdom:
			if (this.totalityController != null)
			{
				this.totalityController.MoveToKingdom(GameConstants.ConvertBytesToUShort(meg, 1));
			}
			break;
		case GAME_PLAYER_NEWS.COSMOS_UpdateWorld:
			this.UpdateWorld();
			break;
		case GAME_PLAYER_NEWS.COSMOS_MoveToMyKingdom:
			this.doorController.GoToGroup(-1, 0, true);
			break;
		case GAME_PLAYER_NEWS.COSMOS_ReflashKingdomTitleButton:
			if (this.totalityController != null)
			{
				this.totalityController.mapGraphicController.reflashGraphicImage();
			}
			break;
		case GAME_PLAYER_NEWS.COSMOS_reflashKvKKingdomType:
		{
			byte value = 0;
			for (int i = 0; i < ActivityManager.Instance.MatchKingdomID.Length; i++)
			{
				if (ActivityManager.Instance.MatchKingdomID[i] > 0 && ActivityManager.Instance.MatchKingdomID[i] != DataManager.MapDataController.kingdomData.kingdomID && DataManager.MapDataController.GetWorldKingdomTableID(ActivityManager.Instance.MatchKingdomID[i], out value))
				{
					DataManager.msgBuffer[0] = 113;
					GameConstants.GetBytes((ushort)value, DataManager.msgBuffer, 1);
					GameConstants.GetBytes(20, DataManager.msgBuffer, 2);
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
			}
			break;
		}
		default:
			if (game_PLAYER_NEWS == GAME_PLAYER_NEWS.Network_Update)
			{
				if (meg[1] == 0)
				{
					if (this.totalityController != null)
					{
						this.totalityController.UpdateNetwork();
					}
				}
				else if (meg[1] == 43)
				{
					this.doorController.ViewKingdom();
				}
				else if (meg[1] == 42 || meg[1] == 44)
				{
					if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID)
					{
						DataManager.MapDataController.FocusKingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
						DataManager.MapDataController.FocusKingdomPeriod = DataManager.MapDataController.OtherKingdomData.kingdomPeriod;
						GUIManager.Instance.HideUILock(EUILock.Normal);
						DataManager.MapDataController.gotoKingdomState = 0;
						this.doorController.HideLoadingImg();
					}
				}
				else if (meg[1] == 35 && this.totalityController != null)
				{
					this.totalityController.WorldMapNameFontTextureRebuilt();
				}
			}
			break;
		}
	}

	// Token: 0x06000C30 RID: 3120 RVA: 0x00119340 File Offset: 0x00117540
	protected override void UpdateNext(byte[] meg)
	{
		DataManager.MapDataController.OutMap();
		DataManager.MapDataController.worldZoomSize = this.totalityController.transform.localScale.x;
		if (this.doorController != null)
		{
			this.doorController.DeSpawnMainEff();
			if (this.doorController.m_GroundInfo.TileMapMat != null)
			{
				UnityEngine.Object.DestroyObject(this.doorController.m_GroundInfo.TileMapMat);
				this.doorController.m_GroundInfo.TileMapMat = null;
			}
			this.doorController.setFightButton(null);
			this.doorController.m_GroundInfo.Close();
			this.doorController.SetTileMapController(null);
			GUIManager.Instance.CloseMenu(EGUIWindow.Door);
		}
		this.doorController = null;
		if (this.totalityController != null)
		{
			this.totalityController.ClearEffect();
			UnityEngine.Object.DestroyObject(this.totalityController.gameObject);
		}
		this.totalityController = null;
		GUIManager.Instance.ClearMapSprite();
		GUIManager.Instance.DestroyTechIconSprite();
		GUIManager.Instance.UnloadWonderSprite();
		GUIManager.Instance.EmojiManager.Clear();
		ParticleManager.Instance.Clear();
	}

	// Token: 0x06000C31 RID: 3121 RVA: 0x0011947C File Offset: 0x0011767C
	protected override void UpdateLoad(byte[] meg)
	{
		if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID)
		{
			DataManager.MapDataController.FocusKingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
			DataManager.MapDataController.FocusKingdomPeriod = DataManager.MapDataController.OtherKingdomData.kingdomPeriod;
		}
		RenderSettings.ambientLight = GameConstants.DefaultAmbientLight;
		DataManager.Instance.GoToBattleOrWar = GameplayKind.CHAOS;
		GameManager.RemoveObserver(0, 3, this);
		GameManager.RegisterObserver(1, 0, this, 1);
		ParticleManager.Instance.Setup();
		if (Camera.main.fieldOfView != 25f)
		{
			Camera.main.fieldOfView = 25f;
		}
		this.doorController = (GUIManager.Instance.OpenMenu(EGUIWindow.Door, 0, 0, true, false, false) as Door);
		this.doorController.SwitchMapMode(EUIOriginMapMode.WorldMap);
		GUIManager.Instance.InitTowerSprite();
		DataManager.MissionDataManager.SetMissionComplete(132);
		DataManager.Instance.RoleBookMark.CheckUpdate(false);
		if (DataManager.Instance.RoleAlliance.Id > 0u)
		{
			DataManager.Instance.RoleBookMark.CheckUpdate_Alliance(false);
		}
		AudioManager.Instance.LoadAndPlayBGM(BGMType.Legion, 1, false);
		AssetManager.Instance.AssetManagerState = AssetState.Ready;
	}

	// Token: 0x06000C32 RID: 3122 RVA: 0x001195C0 File Offset: 0x001177C0
	protected override void UpdateReady(byte[] meg)
	{
		GameObject gameObject = new GameObject("TotalityGroup");
		gameObject.transform.SetParent(GUIManager.Instance.m_UICanvas.transform, false);
		gameObject.transform.SetAsFirstSibling();
		this.totalityController = gameObject.GetComponent<Totality>();
		if (this.totalityController == null)
		{
			this.totalityController = gameObject.AddComponent<Totality>();
		}
		gameObject.transform.localScale = Vector3.one * DataManager.MapDataController.worldZoomSize;
		this.doorController.notifyHomeBtnPos();
		this.doorController.SetShowFIFA_FindBtn(false);
		this.doorController.SetCapitalLocation((ushort)this.totalityController.worldMapController.homePos.x, (ushort)this.totalityController.worldMapController.homePos.y);
		this.totalityController.worldMapController.CheckCenterPos();
		if (this.doorController.m_WindowStack.Count != 0)
		{
			this.totalityController.gameObject.SetActive(false);
		}
		GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
	}

	// Token: 0x06000C33 RID: 3123 RVA: 0x001196DC File Offset: 0x001178DC
	protected override void UpdateRun(byte[] meg)
	{
	}

	// Token: 0x0400281F RID: 10271
	private Totality totalityController;

	// Token: 0x04002820 RID: 10272
	private Door doorController;
}
