using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020006DD RID: 1757
public class World : Image, IPointerUpHandler, IDragHandler, IPointerDownHandler, IEventSystemHandler, IObserver, IObservable
{
	// Token: 0x170000C0 RID: 192
	// (get) Token: 0x0600218A RID: 8586 RVA: 0x003FFFE8 File Offset: 0x003FE1E8
	public GameObject CastleObj
	{
		get
		{
			return this.CastleModel;
		}
	}

	// Token: 0x0600218B RID: 8587 RVA: 0x003FFFF0 File Offset: 0x003FE1F0
	protected override void Awake()
	{
		base.Awake();
		base.color = Color.clear;
		this.nextWorldMode = DataManager.StageDataController.currentWorldMode;
		this.worldflag |= 1;
		this.updateDelegates = new World.UpdateDelegate[4];
		this.updateDelegates[0] = new World.UpdateDelegate(this.WorldNext);
		this.updateDelegates[1] = new World.UpdateDelegate(this.WorldLoad);
		this.updateDelegates[2] = new World.UpdateDelegate(this.WorldReady);
		this.updateDelegates[3] = new World.UpdateDelegate(this.WorldRun);
		this.Observers = new IObserver[2][];
		this.Observers[0] = new IObserver[4];
		this.Observers[1] = new IObserver[1];
		this.cameraController = new CameraMove((CameraState)this.nextWorldMode);
		this.cloudController = new CloudController();
		AssetManager.LoadBigMap();
		this.worldState = TickSubject.Load;
		if (this.nextWorldMode == WorldMode.Wild && !DataManager.Instance.bWorldF)
		{
			this.cameraController.Limit = DataManager.Instance.WorldCameraLimit;
			Camera.main.transform.position = DataManager.Instance.WorldCameraPos;
			DataManager.Instance.bWorldF = true;
		}
	}

	// Token: 0x0600218C RID: 8588 RVA: 0x0040012C File Offset: 0x003FE32C
	protected override void OnDestroy()
	{
		if (this.WorldInputLockCount > 0)
		{
			for (int i = 0; i < this.WorldInputLockCount; i++)
			{
				GUIManager.Instance.HideUILock(EUILock.Normal);
			}
		}
		this.WorldInputLockCount = 0;
		DataManager.DataBuffer[0] = 0;
		DataManager.DataBuffer[1] = 0;
		this.notifyObservers(DataManager.DataBuffer, null);
		this.WorldNext();
		this.ClearObservers();
		if (this.updateDelegates != null)
		{
			Array.Clear(this.updateDelegates, 0, this.updateDelegates.Length);
			this.updateDelegates = null;
		}
		AssetManager.UnloadBigMap();
		if (DataManager.Instance.bWorldF)
		{
			DataManager.Instance.WorldCameraLimit = this.cameraController.Limit;
			if (Camera.main != null)
			{
				DataManager.Instance.WorldCameraPos = Camera.main.transform.position;
			}
			DataManager.Instance.bWorldF = false;
		}
		this.cameraController = null;
		this.cloudController.Destory();
		this.cloudController = null;
		ParticleManager.Instance.DeSpawn(this.CastleModelEff);
		this.CastleModelEff = null;
		UnityEngine.Object.Destroy(this.CorpsStageGameObject);
		this.CorpsStageGameObject = null;
		this.ShadowTransform = null;
		this.LordBipTransform = null;
		AssetManager.UnloadAssetBundle(this.CastleassetKey, true);
		AssetManager.UnloadAssetBundle(this.LordassetKey, true);
		AssetManager.UnloadAssetBundle(this.ShadowassetKey, true);
		base.OnDestroy();
	}

	// Token: 0x0600218D RID: 8589 RVA: 0x00400298 File Offset: 0x003FE498
	protected void Update()
	{
		this.updateDelegates[(int)this.worldState]();
		this.cameraController.CameraUpdata();
		this.cloudController.Update();
		this.CorpsStageUpdate();
	}

	// Token: 0x0600218E RID: 8590 RVA: 0x004002D4 File Offset: 0x003FE4D4
	public void RegisterObserver(byte[] Subject, IObserver pObserver)
	{
		this.Observers[(int)Subject[0]][(int)Subject[1]] = pObserver;
	}

	// Token: 0x0600218F RID: 8591 RVA: 0x004002E8 File Offset: 0x003FE4E8
	public void RegisterObserver(byte in_SubjectStyle, byte in_Subject, IObserver pObserver)
	{
		DataManager.DataBuffer[0] = in_SubjectStyle;
		DataManager.DataBuffer[1] = in_Subject;
		this.RegisterObserver(DataManager.DataBuffer, pObserver);
	}

	// Token: 0x06002190 RID: 8592 RVA: 0x00400308 File Offset: 0x003FE508
	public void RemoveObserver(byte[] Subject)
	{
		this.Observers[(int)Subject[0]][(int)Subject[1]] = null;
	}

	// Token: 0x06002191 RID: 8593 RVA: 0x0040031C File Offset: 0x003FE51C
	public void notifyObservers(byte[] Subject, byte[] meg = null)
	{
		this.Observers[(int)Subject[0]][(int)Subject[1]].Renew(Subject, meg);
	}

	// Token: 0x06002192 RID: 8594 RVA: 0x00400334 File Offset: 0x003FE534
	public void notifyNews(byte[] meg = null)
	{
		if (this.Observers[1][0] != null)
		{
			DataManager.DataBuffer[0] = 1;
			DataManager.DataBuffer[1] = 0;
			this.notifyObservers(DataManager.DataBuffer, meg);
		}
	}

	// Token: 0x06002193 RID: 8595 RVA: 0x00400364 File Offset: 0x003FE564
	public void ClearObservers()
	{
		for (int i = 0; i < this.Observers.Length; i++)
		{
			Array.Clear(this.Observers[i], 0, this.Observers[i].Length);
			this.Observers[i] = null;
		}
		this.Observers = null;
	}

	// Token: 0x06002194 RID: 8596 RVA: 0x004003B4 File Offset: 0x003FE5B4
	public void Renew(byte[] Subject, byte[] meg)
	{
		GAME_PLAYER_NEWS game_PLAYER_NEWS = (GAME_PLAYER_NEWS)Subject[0];
		switch (game_PLAYER_NEWS)
		{
		case GAME_PLAYER_NEWS.Network_Update:
		{
			NetworkNews networkNews = (NetworkNews)Subject[1];
			if (networkNews != NetworkNews.Login)
			{
				if (networkNews == NetworkNews.Refresh_Hospital || networkNews == NetworkNews.Refresh_Trap)
				{
					DataManager.msgBuffer[0] = 9;
					this.notifyNews(DataManager.msgBuffer);
				}
			}
			else if (this.WorldInputLockCount > 0)
			{
				for (int i = 0; i < this.WorldInputLockCount; i++)
				{
					GUIManager.Instance.ShowUILock(EUILock.Normal);
				}
			}
			break;
		}
		default:
			if (game_PLAYER_NEWS == GAME_PLAYER_NEWS.ORIGIN_CameraReSetPressPosition)
			{
				this.cameraController.ReSetPressPosition();
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_DoorOpenUp:
		case GAME_PLAYER_NEWS.ORIGIN_WildOpenUp:
		{
			DataManager.msgBuffer[0] = 12;
			this.notifyNews(DataManager.msgBuffer);
			DataManager.Instance.WorldCameraPos = Camera.main.transform.position;
			DataManager.Instance.WorldCameraLimit = this.cameraController.Limit;
			DataManager.Instance.bWorldF = false;
			byte leveL = (DataManager.StageDataController._stageMode == StageMode.Corps) ? ((byte)(DataManager.StageDataController.StageRecord[2] + 1)) : DataManager.StageDataController.currentChapterID;
			this.cameraController.SetCameraState(CameraState.Area, leveL, true);
			AudioManager.Instance.PlayUISFX(UIKind.ArmyExpewdition);
			break;
		}
		case GAME_PLAYER_NEWS.ORIGIN_DoorWild:
			if (this.nextWorldMode == WorldMode.OpenUp)
			{
				DataManager.Instance.bWorldF = true;
				if (DataManager.StageDataController._stageMode == StageMode.Corps)
				{
					DataManager.msgBuffer[0] = 2;
					this.notifyNews(DataManager.msgBuffer);
				}
				else
				{
					GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.DoorWild);
				}
				GUIManager.Instance.m_HUDMessage.MapHud.ThisTransform.gameObject.SetActive(false);
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_DoorNext:
			if (this.nextWorldMode == WorldMode.OpenUp)
			{
				StageManager stageDataController = DataManager.StageDataController;
				stageDataController.currentChapterID += 1;
				DataManager.StageDataController.currentPointID = (ushort)(DataManager.StageDataController.currentChapterID - 1) * GameConstants.StagePointNum[(int)DataManager.StageDataController._stageMode] + 1;
				DataManager.StageDataController.SaveUserStage(DataManager.StageDataController._stageMode);
				DataManager.Instance.lastBattleResult = -1;
				this.cameraController.SetCameraPos((int)DataManager.StageDataController.currentChapterID);
				DataManager.msgBuffer[0] = 6;
				this.notifyNews(DataManager.msgBuffer);
				GUIManager.Instance.m_HUDMessage.MapHud.AddChapterMsg();
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_DoorLast:
			if (this.nextWorldMode == WorldMode.OpenUp)
			{
				StageManager stageDataController2 = DataManager.StageDataController;
				stageDataController2.currentChapterID -= 1;
				DataManager.StageDataController.currentPointID = (ushort)DataManager.StageDataController.currentChapterID * GameConstants.StagePointNum[(int)DataManager.StageDataController._stageMode];
				DataManager.StageDataController.SaveUserStage(DataManager.StageDataController._stageMode);
				DataManager.Instance.lastBattleResult = -1;
				this.cameraController.SetCameraPos((int)DataManager.StageDataController.currentChapterID);
				DataManager.msgBuffer[0] = 6;
				this.notifyNews(DataManager.msgBuffer);
				GUIManager.Instance.m_HUDMessage.MapHud.AddChapterMsg();
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_CameraOpenUp:
			if (DataManager.StageDataController._stageMode != StageMode.Corps || DataManager.StageDataController.isNotFirstInChapter[2] == 1)
			{
				this.SwitchWorldMode(WorldMode.OpenUp);
				DataManager.msgBuffer[0] = 14;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				GUIManager.Instance.m_HUDMessage.MapHud.AddChapterMsg();
				GUIManager.Instance.m_HUDMessage.MapHud.ShowMsg();
				GUIManager.Instance.m_HUDMessage.MapHud.ShowTime = 0.8f;
				GUIManager.Instance.m_HUDMessage.MapHud.StartCountdown();
				this.WorldUIQueueLockRelease();
			}
			else
			{
				DataManager.msgBuffer[0] = 47;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_CameraWild:
			if (DataManager.StageDataController._stageMode == StageMode.Corps)
			{
				this.cameraController.Limit = DataManager.Instance.WorldCameraLimit;
				this.cameraController.TmpV3Pos = DataManager.Instance.WorldCameraPos;
				this.cameraController.SetCameraState(CameraState.World, 0, false);
			}
			else if (DataManager.StageDataController._stageMode == StageMode.Count)
			{
				this.cameraController.SetCameraState(CameraState.World, 0, false);
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
			}
			else
			{
				DataManager.Instance.WorldCameraLimit = 0f;
				this.cameraController.SetCamerPos_Out();
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_CameraForce:
			if (DataManager.StageDataController._stageMode == StageMode.Corps && DataManager.StageDataController.isNotFirstInChapter[2] == 0)
			{
				this.cloudController.MapClick();
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_CloudOpenUp:
			this.SwitchWorldMode(WorldMode.OpenUp);
			DataManager.msgBuffer[0] = 14;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_LockInput:
			this.worldflag |= 1;
			break;
		case GAME_PLAYER_NEWS.ORIGIN_UnLockInput:
			this.worldflag &= -2;
			break;
		case GAME_PLAYER_NEWS.ORIGIN_CloseStageStory:
		case GAME_PLAYER_NEWS.ORIGIN_CloseTreasureInfo:
			if (DataManager.StageDataController.isNotFirstInChapter[(int)DataManager.StageDataController._stageMode] == 0)
			{
				if (DataManager.StageDataController._stageMode == StageMode.Corps)
				{
					this.worldflag |= 4;
					if (DataManager.StageDataController.StageRecord[2] == 2 && DataManager.StageDataController.StageRecord[1] == 0 && DataManager.StageDataController.StageRecord[0] == 18)
					{
						this.worldflag |= 2;
					}
				}
				else if ((ushort)(DataManager.StageDataController.currentChapterID + 1) * GameConstants.LinePointNum[(int)DataManager.StageDataController._stageMode] < DataManager.StageDataController.limitRecord[(int)DataManager.StageDataController._stageMode])
				{
					StageManager stageDataController3 = DataManager.StageDataController;
					stageDataController3.currentChapterID += 1;
				}
				DataManager.DataBuffer[0] = 4;
				this.Renew(DataManager.DataBuffer, null);
				if (Subject[0] == 39)
				{
					this.WorldUIQueueLockRelease();
				}
			}
			else if (DataManager.StageDataController.StageRecord[(int)DataManager.StageDataController._stageMode] == DataManager.StageDataController.limitRecord[(int)DataManager.StageDataController._stageMode])
			{
				if (DataManager.StageDataController._stageMode == StageMode.Corps)
				{
					this.worldflag |= 4;
				}
				DataManager.DataBuffer[0] = 4;
				this.Renew(DataManager.DataBuffer, null);
				if (Subject[0] == 39)
				{
					this.WorldUIQueueLockRelease();
				}
			}
			else
			{
				if (DataManager.StageDataController._stageMode == StageMode.Full && DataManager.StageDataController.StageRecord[0] == 18)
				{
					this.worldflag |= 2;
				}
				DataManager.DataBuffer[0] = 0;
				DataManager.DataBuffer[1] = 1;
				this.notifyObservers(DataManager.DataBuffer, null);
				DataManager.msgBuffer[0] = 13;
				this.notifyNews(DataManager.msgBuffer);
				this.worldState = TickSubject.Ready;
				if (DataManager.StageDataController._stageMode == StageMode.Full || DataManager.StageDataController._stageMode == StageMode.Lean)
				{
					this.WorldUIQueueLockRelease();
				}
			}
			GUIManager.Instance.m_HUDMessage.MapHud.AddChapterMsg();
			if (DataManager.StageDataController._stageMode != StageMode.Corps || this.nextWorldMode == WorldMode.OpenUp)
			{
				GUIManager.Instance.m_HUDMessage.MapHud.ShowMsg();
			}
			GUIManager.Instance.m_HUDMessage.MapHud.ShowTime = 0.8f;
			GUIManager.Instance.m_HUDMessage.MapHud.StartCountdown();
			break;
		case GAME_PLAYER_NEWS.ORIGIN_CameraStateWild:
			if ((this.worldflag & 4) != 0)
			{
				this.worldflag &= -5;
				GUIManager.Instance.OpenMenu(EGUIWindow.UI_NewTerritory, (int)DataManager.StageDataController.StageRecord[2], 0, false, true, false);
			}
			else
			{
				this.WorldUIQueueLockRelease();
			}
			NewbieManager.EntryTest();
			Indemnify.CheckShowIndemnify();
			ActivityGiftManager.Instance.CheckShowActivityGiftEffect();
			DataManager.msgBuffer[0] = 47;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_OpenUpWild:
			this.SwitchWorldMode(WorldMode.Wild);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_OpenUpContinue:
			DataManager.msgBuffer[0] = 4;
			this.notifyNews(DataManager.msgBuffer);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_ManorGuildCameraMove:
		{
			BuildManorData recordByKey = DataManager.Instance.BuildManorData.GetRecordByKey(GameConstants.ConvertBytesToUShort(DataManager.msgBuffer, 3));
			float num = ((recordByKey.bPosionX <= 30000) ? ((float)recordByKey.bPosionX) : ((float)recordByKey.bPosionX - 65535f)) * 0.01f;
			float y = ((recordByKey.bPosionY <= 32768) ? ((float)recordByKey.bPosionY) : ((float)recordByKey.bPosionY - 65535f)) * 0.01f;
			float num2 = ((recordByKey.bPosionZ <= 32768) ? ((float)recordByKey.bPosionZ) : ((float)recordByKey.bPosionZ - 65535f)) * 0.01f;
			Vector3 targetPosition = new Vector3(num + 4f, y, num2 - 23.5f);
			this.cameraController.CameraMoveTarget(CameraState.Build, targetPosition);
			DataManager.msgBuffer[0] = 11;
			this.notifyNews(DataManager.msgBuffer);
			break;
		}
		case GAME_PLAYER_NEWS.ORIGIN_ArneaGuildCameraMove:
		{
			Vector3 targetPosition2 = new Vector3(119.07f, 30.8f, 78.78f);
			this.cameraController.CameraMoveTarget(CameraState.Build, targetPosition2);
			break;
		}
		case GAME_PLAYER_NEWS.ORIGIN_DugoutGuildCameraMove:
		{
			Vector3 targetPosition3 = new Vector3(-22.22f, 13.39f, -22.2f);
			this.cameraController.CameraMoveTarget(CameraState.Build, targetPosition3);
			break;
		}
		case GAME_PLAYER_NEWS.ORIGIN_BlackMarketGuildCameraMove:
		{
			Vector3 targetPosition4 = new Vector3(51.5f, -0.5f, 87.44f);
			this.cameraController.CameraMoveTarget(CameraState.Build, targetPosition4);
			break;
		}
		case GAME_PLAYER_NEWS.ORIGIN_WarlobbyGuildCameraMove:
			if (GUIManager.Instance.BuildingData.ManorGride[6] != null)
			{
				this.cameraController.CameraMoveTarget(CameraState.Build, GUIManager.Instance.BuildingData.ManorGride[6].position);
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_CasinoGuildCameraMove:
		{
			Vector3 targetPosition5 = new Vector3(131.5f, 9.1f, -7.7f);
			this.cameraController.CameraMoveTarget(CameraState.Build, targetPosition5);
			break;
		}
		case GAME_PLAYER_NEWS.ORIGIN_LaboratoryGuildCameraMove:
		{
			Vector3 targetPosition6 = new Vector3(-5.2f, 0.6f, 130.1f);
			this.cameraController.CameraMoveTarget(CameraState.Build, targetPosition6);
			break;
		}
		case GAME_PLAYER_NEWS.ORIGIN_PetListGuildCameraMove:
		{
			Vector3 targetPosition7 = new Vector3(193.63f, 16.2f, -14.29f);
			this.cameraController.CameraMoveTarget(CameraState.Build, targetPosition7);
			break;
		}
		case GAME_PLAYER_NEWS.ORIGIN_UpdateBuild:
			DataManager.msgBuffer[0] = 5;
			this.notifyNews(DataManager.msgBuffer);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_UpdateOpenUp:
			if (this.nextWorldMode == WorldMode.OpenUp)
			{
				this.UpdateWorldState();
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_ChangeStageMode:
			if (this.nextWorldMode == WorldMode.OpenUp)
			{
				if (Subject[1] == 1)
				{
					DataManager.StageDataController.resetStageMode(StageMode.Full);
				}
				else if (Subject[1] == 2)
				{
					DataManager.StageDataController.resetStageMode(StageMode.Lean);
				}
				else if (Subject[1] == 3)
				{
					DataManager.StageDataController.resetStageMode(StageMode.Dare);
					if (DataManager.StageDataController.StageRecord[3] >= GameConstants.StagePointNum[3] && !NewbieManager.IsLeadNewbiePass)
					{
						DataManager.StageDataController.currentChapterID = 1;
						DataManager.StageDataController.currentPointID = (ushort)(DataManager.StageDataController.currentChapterID - 1) * GameConstants.StagePointNum[(int)DataManager.StageDataController._stageMode] + 1;
						DataManager.StageDataController.SaveUserStage(DataManager.StageDataController._stageMode);
					}
				}
				DataManager.StageDataController.SaveUserStageMode(DataManager.StageDataController._stageMode);
				DataManager.Instance.lastBattleResult = -1;
				this.cameraController.SetCameraPos((int)DataManager.StageDataController.currentChapterID);
				this.UpdateWorldState();
				GUIManager.Instance.m_HUDMessage.MapHud.AddChapterMsg();
				GUIManager.Instance.m_HUDMessage.MapHud.ShowMsg();
				GUIManager.Instance.m_HUDMessage.MapHud.ShowTime = 0.8f;
				GUIManager.Instance.m_HUDMessage.MapHud.StartCountdown();
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_HideCampain:
			DataManager.msgBuffer[0] = 8;
			this.notifyNews(DataManager.msgBuffer);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_OpenUpFirstRun:
			if (DataManager.StageDataController._stageMode == StageMode.Full)
			{
				if ((this.worldflag & 2) != 0)
				{
					NewbieManager.CheckTeach(ETeachKind.ELITE_STAGE, null, true);
					this.worldflag &= -3;
				}
				if ((DataManager.StageDataController.StageRecord[0] != 0 || !NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, null, true)) && NewbieManager.CheckPutOnEquipTeach())
				{
					NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, null, false);
				}
			}
			else if (DataManager.StageDataController._stageMode == StageMode.Corps)
			{
				NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT, this, true);
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_BuildOpenUp:
			if (DataManager.StageDataController._stageMode != StageMode.Corps || DataManager.StageDataController.isNotFirstInChapter[2] == 1)
			{
				if (DataManager.StageDataController._stageMode == StageMode.Dare && DataManager.StageDataController.StageRecord[3] >= GameConstants.StagePointNum[3] && !NewbieManager.IsLeadNewbiePass)
				{
					DataManager.StageDataController.currentChapterID = 1;
					DataManager.StageDataController.currentPointID = (ushort)(DataManager.StageDataController.currentChapterID - 1) * GameConstants.StagePointNum[(int)DataManager.StageDataController._stageMode] + 1;
					DataManager.StageDataController.SaveUserStage(DataManager.StageDataController._stageMode);
				}
				DataManager.Instance.WorldCameraPos = GameConstants.GoldGuy;
				DataManager.Instance.WorldCameraLimit = 0f;
				DataManager.Instance.bWorldF = false;
				this.cameraController.SetCameraPos((int)DataManager.StageDataController.currentChapterID);
				this.SwitchWorldMode(WorldMode.OpenUp);
				DataManager.msgBuffer[0] = 14;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			break;
		case GAME_PLAYER_NEWS.ORIGIN_UIQueueLock:
			this.WorldUIQueueLock();
			break;
		case GAME_PLAYER_NEWS.ORIGIN_UIQueueLockRelease:
			this.WorldUIQueueLockRelease();
			break;
		case GAME_PLAYER_NEWS.ORIGIN_UIInputLock:
			this.WorldInputLockCount++;
			GUIManager.Instance.ShowUILock(EUILock.Normal);
			break;
		case GAME_PLAYER_NEWS.ORIGIN_UIInputLockRelease:
			this.WorldInputLockCount--;
			GUIManager.Instance.HideUILock(EUILock.Normal);
			break;
		}
	}

	// Token: 0x06002195 RID: 8597 RVA: 0x00401210 File Offset: 0x003FF410
	public void OnDrag(PointerEventData eventData)
	{
		if ((this.worldflag & 1) != 0)
		{
			return;
		}
		this.cameraController.OnDrag(eventData);
		if (Mathf.Abs(this.BeginPos.x - eventData.position.x) > 50f || Mathf.Abs(this.BeginPos.y - eventData.position.y) > 50f)
		{
			DataManager.msgBuffer[0] = 7;
			this.notifyNews(DataManager.msgBuffer);
		}
	}

	// Token: 0x06002196 RID: 8598 RVA: 0x0040129C File Offset: 0x003FF49C
	public void OnPointerDown(PointerEventData eventData)
	{
		if ((this.worldflag & 1) != 0)
		{
			return;
		}
		DataManager.msgBuffer[0] = 0;
		GameConstants.GetBytes(eventData.position.x, DataManager.msgBuffer, 1);
		GameConstants.GetBytes(eventData.position.y, DataManager.msgBuffer, 5);
		this.notifyNews(DataManager.msgBuffer);
		this.cameraController.OnBeginDrag(eventData);
		this.BeginPos = eventData.pressPosition;
	}

	// Token: 0x06002197 RID: 8599 RVA: 0x00401314 File Offset: 0x003FF514
	public void OnPointerUp(PointerEventData eventData)
	{
		if ((this.worldflag & 1) != 0)
		{
			return;
		}
		DataManager.msgBuffer[0] = 1;
		GameConstants.GetBytes(eventData.position.x, DataManager.msgBuffer, 1);
		GameConstants.GetBytes(eventData.position.y, DataManager.msgBuffer, 5);
		this.notifyNews(DataManager.msgBuffer);
		this.cameraController.OnEndDrag(eventData);
	}

	// Token: 0x06002198 RID: 8600 RVA: 0x00401380 File Offset: 0x003FF580
	public void SwitchWorldMode(WorldMode in_nextWorldMode)
	{
		if (DataManager.StageDataController.currentWorldMode != in_nextWorldMode)
		{
			this.nextWorldMode = in_nextWorldMode;
		}
	}

	// Token: 0x06002199 RID: 8601 RVA: 0x0040139C File Offset: 0x003FF59C
	public void WorldUIQueueLock()
	{
		if (this.WorldQueueLockCount == 0)
		{
			GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Stage);
		}
		this.WorldQueueLockCount++;
	}

	// Token: 0x0600219A RID: 8602 RVA: 0x004013D0 File Offset: 0x003FF5D0
	public void WorldUIQueueLockRelease()
	{
		this.WorldQueueLockCount--;
		if (this.WorldQueueLockCount == 0)
		{
			GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Stage);
		}
	}

	// Token: 0x0600219B RID: 8603 RVA: 0x00401404 File Offset: 0x003FF604
	public void UpdateWorldState()
	{
		this.worldState = TickSubject.Next;
		DataManager.DataBuffer[0] = 0;
		DataManager.DataBuffer[1] = 0;
		this.notifyObservers(DataManager.DataBuffer, null);
		for (int i = 0; i < this.Observers.Length; i++)
		{
			Array.Clear(this.Observers[i], 0, this.Observers[i].Length);
		}
	}

	// Token: 0x0600219C RID: 8604 RVA: 0x00401468 File Offset: 0x003FF668
	private void initCorpsStage()
	{
		ushort num;
		CorpsStage recordByKey;
		if (DataManager.Instance.lastBattleResult == 1)
		{
			num = DataManager.StageDataController.StageRecord[2];
			recordByKey = DataManager.StageDataController.CorpsStageTable.GetRecordByKey(num);
		}
		else
		{
			if (DataManager.StageDataController.StageRecord[2] >= DataManager.StageDataController.limitRecord[2])
			{
				if (this.CorpsStageGameObject != null)
				{
					this.CorpsStageGameObject.SetActive(false);
				}
				return;
			}
			num = DataManager.StageDataController.StageRecord[2] + 1;
			recordByKey = DataManager.StageDataController.CorpsStageTable.GetRecordByKey(num);
		}
		if (this.CorpsStageGameObject == null)
		{
			if (num != this.currentCorpsStageRecord)
			{
				this.currentCorpsStageRecord = num;
			}
			this.CorpsStageGameObject = new GameObject("CorpsStage");
		}
		else
		{
			if (num == this.currentCorpsStageRecord)
			{
				return;
			}
			this.currentCorpsStageRecord = num;
			this.CastleModelEff.transform.SetParent(null);
			this.CastleModel.transform.SetParent(null);
			this.LordModel.transform.SetParent(null);
			UnityEngine.Object.Destroy(this.LordModel);
			AssetManager.UnloadAssetBundle(this.LordassetKey, true);
			this.LordModel = null;
			AssetManager.UnloadAssetBundle(this.ShadowassetKey, true);
			this.ShadowassetKey = 0;
		}
		CString cstring = StringManager.Instance.SpawnString(30);
		Transform transform = this.CorpsStageGameObject.transform;
		transform.position = GameConstants.WordToVector3(recordByKey.CastlePos.X, recordByKey.CastlePos.Y, recordByKey.CastlePos.Z, -100, 0.01f);
		if (this.CastleModel == null)
		{
			cstring.ClearString();
			cstring.AppendFormat("Role/npccastle");
			AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.CastleassetKey);
			this.CastleModel = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
		}
		Transform transform2 = this.CastleModel.transform;
		transform2.SetParent(transform);
		transform2.localScale = Vector3.one * (float)recordByKey.CastleScale * 0.01f;
		Vector3 eulerAngles = transform2.eulerAngles;
		eulerAngles.y = (float)recordByKey.CastleRotY * 0.01f;
		transform2.eulerAngles = eulerAngles;
		transform2.position = GameConstants.WordToVector3(recordByKey.CastlePos.X, recordByKey.CastlePos.Y, recordByKey.CastlePos.Z, -100, 0.01f);
		ushort num2 = 0;
		if (this.LordModel == null)
		{
			Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(recordByKey.Heros[0].HeroID);
			ushort num3 = recordByKey2.Modle;
			if (!DataManager.Instance.CheckHero3DMesh(recordByKey.Heros[0].HeroID))
			{
				num3 = 1;
			}
			num2 = recordByKey2.Radius;
			cstring.ClearString();
			cstring.StringToFormat("Role/hero_");
			cstring.IntToFormat((long)num3, 5, false);
			cstring.AppendFormat("{0}{1}");
			AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.LordassetKey);
			if (assetBundle)
			{
				this.LordModel = (UnityEngine.Object.Instantiate(assetBundle.Load("m")) as GameObject);
			}
		}
		if (this.LordModel)
		{
			transform2 = this.LordModel.transform;
		}
		transform2.SetParent(transform);
		transform2.localScale = Vector3.one * (float)recordByKey.LordScale * 0.01f;
		transform2.position = GameConstants.WordToVector3(recordByKey.LordPos.X, recordByKey.LordPos.Y, recordByKey.LordPos.Z, -100, 0.01f);
		if (this.ShadowassetKey == 0)
		{
			AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/shadow", out this.ShadowassetKey, false);
			GameObject gameObject = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
			this.ShadowTransform = gameObject.transform;
			this.ShadowTransform.SetParent(transform2, false);
			MeshFilter component = gameObject.GetComponent<MeshFilter>();
			component.mesh = GameConstants.CreatePlane(transform2.forward, transform2.right, new Rect(0f, 0f, 1f, 1f), new Color(1f, 1f, 1f, 0.6f), (float)num2 * 0.015f);
			this.LordBipTransform = transform2.GetChild(0);
		}
		ParticleManager.Instance.DeSpawn(this.CastleModelEff);
		this.CastleModelEff = ParticleManager.Instance.Spawn(309, transform, Vector3.zero, (float)recordByKey.CastleScale * 0.01f, true, true, true);
		this.CastleModelEff.SetActive(true);
		StringManager.Instance.DeSpawnString(cstring);
	}

	// Token: 0x0600219D RID: 8605 RVA: 0x00401948 File Offset: 0x003FFB48
	private void CorpsStageUpdate()
	{
		if (this.CorpsStageGameObject == null || !this.CorpsStageGameObject.activeSelf || this.LordModel == null)
		{
			return;
		}
		Vector3 position = this.LordBipTransform.position;
		position.y = this.ShadowTransform.position.y;
		this.ShadowTransform.position = position;
	}

	// Token: 0x0600219E RID: 8606 RVA: 0x004019BC File Offset: 0x003FFBBC
	private void WorldNext()
	{
		this.worldflag |= 1;
		this.worldState = TickSubject.Load;
		LandWalkerManager.Release();
	}

	// Token: 0x0600219F RID: 8607 RVA: 0x004019D8 File Offset: 0x003FFBD8
	private void WorldLoad()
	{
		GC.Collect();
		IObserver pObserver = this.CreateWorldMode(this.nextWorldMode);
		this.RegisterObserver(0, 0, pObserver);
		this.RegisterObserver(0, 1, pObserver);
		this.RegisterObserver(0, 2, pObserver);
		this.RegisterObserver(0, 3, pObserver);
		this.RegisterObserver(1, 0, pObserver);
		DataManager.DataBuffer[0] = 0;
		DataManager.DataBuffer[1] = 1;
		this.notifyObservers(DataManager.DataBuffer, null);
		DataManager.StageDataController.currentWorldMode = this.nextWorldMode;
		this.worldState = TickSubject.Ready;
	}

	// Token: 0x060021A0 RID: 8608 RVA: 0x00401A58 File Offset: 0x003FFC58
	private void WorldReady()
	{
		GC.Collect();
		DataManager.DataBuffer[0] = 0;
		DataManager.DataBuffer[1] = 2;
		this.notifyObservers(DataManager.DataBuffer, null);
		this.worldflag &= -2;
		GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
		this.worldState = TickSubject.Run;
		this.cloudController.UpdateColudController();
		if (DataManager.StageDataController.currentWorldMode == WorldMode.Wild)
		{
			LandWalkerManager instance = LandWalkerManager.Instance;
		}
	}

	// Token: 0x060021A1 RID: 8609 RVA: 0x00401AD0 File Offset: 0x003FFCD0
	private void WorldRun()
	{
		if (DataManager.StageDataController.currentWorldMode != this.nextWorldMode)
		{
			this.UpdateWorldState();
			return;
		}
		DataManager.DataBuffer[0] = 0;
		DataManager.DataBuffer[1] = 3;
		this.notifyObservers(DataManager.DataBuffer, null);
	}

	// Token: 0x060021A2 RID: 8610 RVA: 0x00401B18 File Offset: 0x003FFD18
	private IObserver CreateWorldMode(WorldMode wm)
	{
		IObserver result = null;
		this.initCorpsStage();
		if (wm != WorldMode.Wild)
		{
			if (wm == WorldMode.OpenUp)
			{
				result = new OpenUp(this.CorpsStageGameObject);
			}
		}
		else
		{
			result = new Wild(this.CorpsStageGameObject);
		}
		return result;
	}

	// Token: 0x04006A1C RID: 27164
	private const ushort CastleModelEffID = 309;

	// Token: 0x04006A1D RID: 27165
	private int worldflag;

	// Token: 0x04006A1E RID: 27166
	private WorldMode nextWorldMode;

	// Token: 0x04006A1F RID: 27167
	public TickSubject worldState;

	// Token: 0x04006A20 RID: 27168
	public World.UpdateDelegate[] updateDelegates;

	// Token: 0x04006A21 RID: 27169
	private IObserver[][] Observers;

	// Token: 0x04006A22 RID: 27170
	public CameraMove cameraController;

	// Token: 0x04006A23 RID: 27171
	private CloudController cloudController;

	// Token: 0x04006A24 RID: 27172
	private Vector2 BeginPos;

	// Token: 0x04006A25 RID: 27173
	private GameObject CorpsStageGameObject;

	// Token: 0x04006A26 RID: 27174
	private GameObject CastleModel;

	// Token: 0x04006A27 RID: 27175
	private GameObject LordModel;

	// Token: 0x04006A28 RID: 27176
	private GameObject CastleModelEff;

	// Token: 0x04006A29 RID: 27177
	private Transform LordBipTransform;

	// Token: 0x04006A2A RID: 27178
	private Transform ShadowTransform;

	// Token: 0x04006A2B RID: 27179
	private int CastleassetKey;

	// Token: 0x04006A2C RID: 27180
	private int LordassetKey;

	// Token: 0x04006A2D RID: 27181
	private int ShadowassetKey;

	// Token: 0x04006A2E RID: 27182
	private int WorldInputLockCount;

	// Token: 0x04006A2F RID: 27183
	private int WorldQueueLockCount;

	// Token: 0x04006A30 RID: 27184
	private ushort currentCorpsStageRecord;

	// Token: 0x020006DE RID: 1758
	private enum World_Flag
	{
		// Token: 0x04006A32 RID: 27186
		Lock,
		// Token: 0x04006A33 RID: 27187
		OpenLeanMsg,
		// Token: 0x04006A34 RID: 27188
		OpenNewTerritory
	}

	// Token: 0x02000894 RID: 2196
	// (Invoke) Token: 0x06002D98 RID: 11672
	public delegate void UpdateDelegate();
}
