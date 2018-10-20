using System;
using UnityEngine;

// Token: 0x0200021B RID: 539
public class CHAOS : Gameplay
{
	// Token: 0x060009D9 RID: 2521 RVA: 0x000CED78 File Offset: 0x000CCF78
	~CHAOS()
	{
	}

	// Token: 0x060009DA RID: 2522 RVA: 0x000CEDB0 File Offset: 0x000CCFB0
	private void UpdateMap(ushort ZoneID, byte resetYolk = 0)
	{
		if (this.realmController != null)
		{
			if (resetYolk == 2 && this.realmController.mapTileController != null)
			{
				bool flag = false;
				if (ActivityManager.Instance.KVKHuntOrder == 1)
				{
					if (this.realmController.mapTileController.frontIsSheep != 0)
					{
						flag = true;
						this.realmController.mapTileController.frontIsSheep = 0;
						this.realmController.mapTileController.UpdateTickImage();
					}
				}
				else if (ActivityManager.Instance.KVKHuntOrder == 2)
				{
					if (this.realmController.mapTileController.frontIsSheep != 1)
					{
						flag = true;
						this.realmController.mapTileController.frontIsSheep = 1;
						this.realmController.mapTileController.UpdateTickImage();
					}
				}
				else if (this.realmController.mapTileController.frontIsSheep != 3)
				{
					flag = true;
					this.realmController.mapTileController.frontIsSheep = 3;
				}
				if (flag)
				{
					this.realmController.UpdateTileMap(ZoneID);
					this.realmController.ResetYolk();
				}
				return;
			}
			if (resetYolk == 1)
			{
				if (this.realmController.ResetYolk())
				{
					this.realmController.UpdateTileMap(ZoneID);
				}
			}
			else
			{
				this.realmController.UpdateTileMap(ZoneID);
			}
		}
	}

	// Token: 0x060009DB RID: 2523 RVA: 0x000CEF04 File Offset: 0x000CD104
	private void UpdatePoint(uint LayoutMapInfoID)
	{
		if (this.realmController != null)
		{
			this.realmController.UpdatePoint(LayoutMapInfoID);
		}
	}

	// Token: 0x060009DC RID: 2524 RVA: 0x000CEF24 File Offset: 0x000CD124
	private void CheckFocus()
	{
		if (DataManager.MapDataController.isOpenGroundInfo == 1)
		{
			AudioManager.Instance.PlayUISFX(UIKind.UIClickKindom);
			this.doorController.OpenGroundInfo(DataManager.MapDataController.FocusMapID, POINT_KIND.PK_MAX);
			DataManager.MapDataController.isOpenGroundInfo = 0;
		}
		if (DataManager.MapDataController.isMarkGroundInfo == 1)
		{
			if (this.realmController != null)
			{
				this.realmController.Mark();
			}
			DataManager.MapDataController.isMarkGroundInfo = 0;
		}
		if (DataManager.MapDataController.FocusGroupID != 10 && this.realmController != null)
		{
			this.realmController.ClickGroup();
		}
	}

	// Token: 0x060009DD RID: 2525 RVA: 0x000CEFD8 File Offset: 0x000CD1D8
	private void ReLoadMap()
	{
		if (this.doorController != null)
		{
			this.doorController.ShowKingdomMark(false);
			if (this.doorController.m_GroundInfo.TileMapMat != null)
			{
				UnityEngine.Object.DestroyObject(this.doorController.m_GroundInfo.TileMapMat);
				this.doorController.m_GroundInfo.TileMapMat = null;
			}
			this.doorController.setFightButton(null);
			this.doorController.m_GroundInfo.Close();
			this.doorController.SetTileMapController(null);
		}
		if (this.realmController != null)
		{
			this.realmController.mapTileController.centerMapID = -1;
			this.realmController.ClearEffect();
			UnityEngine.Object.DestroyObject(this.realmController.gameObject);
		}
		this.realmController = null;
		this.doorController.DeSpawnMainEff();
		ParticleManager.Instance.Clear();
		ParticleManager.Instance.Setup();
		AudioManager.Instance.LoadAndPlayBGM(BGMType.Legion, 1, false);
		GameObject gameObject = new GameObject("RealmGroup");
		gameObject.transform.SetParent(GUIManager.Instance.m_UICanvas.transform, false);
		gameObject.transform.SetAsFirstSibling();
		this.realmController = gameObject.GetComponent<Realm>();
		if (this.realmController == null)
		{
			this.realmController = gameObject.AddComponent<Realm>();
		}
		gameObject.transform.localScale = Vector3.one * DataManager.MapDataController.zoomSize;
		Vector2 tileMapPosbySpriteID = GameConstants.getTileMapPosbySpriteID(DataManager.Instance.RoleAttr.CapitalPoint);
		this.doorController.notifyHomeBtnPos();
		this.doorController.SetCapitalLocation((ushort)tileMapPosbySpriteID.x, (ushort)tileMapPosbySpriteID.y);
		this.doorController.SetTileMapController(this.realmController.mapTileController);
		this.realmController.CheckCenterPos();
		if (this.doorController.m_WindowStack.Count != 0)
		{
			GameManager.RegisterObserver(0, 3, this, 1);
			this.realmController.Stop();
		}
		if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID)
		{
			this.doorController.SetShowHomeBtn(false);
		}
		if (DataManager.MapDataController.FocusKingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
		{
			this.doorController.LoadMainEff(EMapEffectKind.WORLDWAR);
		}
		else
		{
			this.doorController.LoadMainEff(EMapEffectKind.CHAOS);
		}
	}

	// Token: 0x060009DE RID: 2526 RVA: 0x000CF234 File Offset: 0x000CD434
	protected override void UpdateNews(byte[] meg)
	{
		switch (meg[0])
		{
		case 0:
		{
			NetworkNews networkNews = (NetworkNews)meg[1];
			switch (networkNews)
			{
			case NetworkNews.Login:
				if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID)
				{
					if (!NetworkManager.GuestController.Connecting() || !NetworkManager.GuestController.Connected())
					{
						GUIManager.Instance.ShowUILock(EUILock.Normal);
						NetworkManager.Instance.ViewKingdom(DataManager.MapDataController.FocusKingdomID);
					}
				}
				else if (this.realmController != null)
				{
					this.realmController.UpdateNetwork();
				}
				DataManager.MapDataController.RequsetYolkswitch();
				break;
			default:
				switch (networkNews)
				{
				case NetworkNews.GuestConnectFail:
					if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID)
					{
						DataManager.MapDataController.FocusKingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
						GUIManager.Instance.HideUILock(EUILock.Normal);
						DataManager.MapDataController.gotoKingdomState = 0;
						if (GUIManager.Instance.pDVMgr != null)
						{
							GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
						}
					}
					break;
				case NetworkNews.GuestLogin:
				{
					if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID)
					{
						if (DataManager.MapDataController.gotoKingdomState == 0)
						{
							if (this.realmController != null)
							{
								this.realmController.UpdateNetwork();
							}
							GUIManager.Instance.HideUILock(EUILock.Normal);
						}
						else
						{
							if (GUIManager.Instance.m_HUDMessage != null && GUIManager.Instance.m_HUDMessage.MapHud != null)
							{
								GUIManager.Instance.m_HUDMessage.MapHud.AddChangeKindomMapMsg();
							}
							this.ReLoadMap();
							this.doorController.ViewKingdom();
						}
						if (GUIManager.Instance.pDVMgr != null)
						{
							GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
						}
					}
					else
					{
						NetworkManager.Instance.ViewClose();
					}
					Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
					if (door)
					{
						door.RefreshMainEff();
					}
					break;
				}
				case NetworkNews.GuestLost:
					if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID)
					{
						if (DataManager.MapDataController.gotoKingdomState == 0)
						{
							GUIManager.Instance.ShowUILock(EUILock.Normal);
							NetworkManager.Instance.ViewKingdom(DataManager.MapDataController.FocusKingdomID);
						}
						else
						{
							DataManager.MapDataController.FocusKingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
							GUIManager.Instance.HideUILock(EUILock.Normal);
							DataManager.MapDataController.gotoKingdomState = 0;
							GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
						}
					}
					break;
				default:
					if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
					{
						if (this.realmController != null)
						{
							this.realmController.BloodNameFontTextureRebuilt();
						}
					}
					break;
				}
				break;
			case NetworkNews.Refresh_Asset:
				if (meg[2] == 0 && meg[3] == 0)
				{
					this.UpdateMap(1024, 0);
				}
				break;
			}
			break;
		}
		case 52:
			this.UpdateMap(GameConstants.ConvertBytesToUShort(meg, 1), 0);
			break;
		case 53:
			if (this.realmController != null)
			{
				if (!this.realmController.isMyPointIn() || meg[1] == 1 || meg[1] == 2)
				{
					this.UpdateMap(1024, meg[1]);
				}
				if (meg[1] != 2)
				{
					this.realmController.ResetAllLine();
				}
			}
			break;
		case 54:
			this.UpdatePoint(GameConstants.ConvertBytesToUInt(meg, 1));
			break;
		case 55:
			if (this.realmController != null)
			{
				this.realmController.DelLine((int)GameConstants.ConvertBytesToUInt(meg, 1), meg[5], meg[6]);
			}
			break;
		case 56:
			if (this.realmController != null)
			{
				this.realmController.AddLine((int)GameConstants.ConvertBytesToUInt(meg, 1), true);
			}
			break;
		case 57:
			if (this.realmController != null)
			{
				this.realmController.UpdateLineOwner((int)GameConstants.ConvertBytesToUInt(meg, 1));
			}
			break;
		case 58:
			if (this.realmController != null)
			{
				this.realmController.UpdateLineTag((int)GameConstants.ConvertBytesToUInt(meg, 1));
			}
			break;
		case 59:
			if (this.realmController != null)
			{
				this.realmController.UpdateLinePos(GameConstants.ConvertBytesToFloat(meg, 1), GameConstants.ConvertBytesToFloat(meg, 5));
			}
			break;
		case 60:
			if (this.realmController != null)
			{
				this.realmController.UpdateLineBegin((int)GameConstants.ConvertBytesToUInt(meg, 1));
			}
			break;
		case 61:
			if (this.realmController != null)
			{
				this.realmController.UpdateLineEmoji((int)GameConstants.ConvertBytesToUInt(meg, 1));
			}
			break;
		case 62:
			if (this.realmController != null)
			{
				this.realmController.UpdateLineWeapon((int)GameConstants.ConvertBytesToUInt(meg, 1));
			}
			break;
		case 63:
			this.doorController.UpdateLocation((ushort)GameConstants.ConvertBytesToFloat(meg, 1), (ushort)GameConstants.ConvertBytesToFloat(meg, 5), GameConstants.ConvertBytesToFloat(meg, 9), GameConstants.ConvertBytesToFloat(meg, 13));
			break;
		case 64:
		{
			AudioManager.Instance.PlayUISFX(UIKind.UIClickKindom);
			int num = GameConstants.ConvertBytesToInt(meg, 1);
			byte b = meg[13];
			ushort zoneID = GameConstants.ConvertBytesToUShort(meg, 5);
			byte pointID = meg[9];
			float selectX = GameConstants.ConvertBytesToFloat(meg, 5);
			float selectY = GameConstants.ConvertBytesToFloat(meg, 9);
			if (b == 10)
			{
				if ((DataManager.MapDataController.NPCPointTable[(int)DataManager.MapDataController.LayoutMapInfo[num].tableID].baseFlag & 4) > 0)
				{
					if (DataManager.MapDataController.OtherKingdomData.kingdomID == DataManager.MapDataController.FocusKingdomID)
					{
						FootballManager instance = FootballManager.Instance;
						instance.mFootBallMapID = num;
						instance.NowBallID = DataManager.MapDataController.NPCPointTable[(int)DataManager.MapDataController.LayoutMapInfo[num].tableID].Key;
						instance.mUIOpenState = 0;
						int mapID = (num + 512 >= 262144) ? num : (num + 512);
						if (this.realmController != null && this.realmController.mapTileController != null)
						{
							this.realmController.CloseSelect();
							this.realmController.mapTileController.setTarget(mapID, 0.7f);
						}
						instance.mCloseFootBallSkill = 0;
						UIFootBall x = GUIManager.Instance.FindMenu(EGUIWindow.UI_FootBall) as UIFootBall;
						if (x == null)
						{
							GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_FootBall, 0, 0, false, 0);
						}
					}
					else
					{
						GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7744u), 255, true);
					}
				}
				else
				{
					this.doorController.OpenMenu(EGUIWindow.UI_MapMonster, num, 0, false);
				}
			}
			else
			{
				this.doorController.OpenGroundInfo(num, (POINT_KIND)b);
			}
			if (this.realmController != null)
			{
				if (b == 11)
				{
					if (this.realmController.mapTileController != null)
					{
						Vector2 tilePosition = this.realmController.mapTileController.getTilePosition(zoneID, pointID);
						this.realmController.ClickSelect(tilePosition.x, tilePosition.y, true);
					}
				}
				else if (b != 10 || (DataManager.MapDataController.NPCPointTable[(int)DataManager.MapDataController.LayoutMapInfo[num].tableID].baseFlag & 4) == 0)
				{
					this.realmController.ClickSelect(selectX, selectY, false);
				}
			}
			break;
		}
		case 65:
			if (this.realmController != null)
			{
				this.realmController.stopFocusGroup();
			}
			this.doorController.m_GroundInfo.Close();
			break;
		case 66:
			AudioManager.Instance.PlayUISFX(UIKind.UIClickKindom);
			this.doorController.OpenGroundInfo((int)GameConstants.ConvertBytesToUInt(meg, 1), POINT_KIND.PK_UNDEFINED);
			break;
		case 67:
			if (this.realmController != null)
			{
				this.realmController.CloseEffect();
			}
			break;
		case 68:
			this.doorController.ShowLoadingImg();
			break;
		case 69:
			this.doorController.HideLoadingImg();
			break;
		case 70:
			if (this.doorController.m_GroundInfo != null)
			{
				this.doorController.m_GroundInfo.UpdateUI(0, 0);
			}
			this.CheckFocus();
			GameManager.OnRefresh(NetworkNews.Refresh_QBarTime, null);
			break;
		case 71:
			if (this.realmController != null)
			{
				this.realmController.CheckLineUpdate();
			}
			break;
		case 72:
		case 73:
			if (this.realmController != null && this.realmController.mapTileController != null)
			{
				this.realmController.mapTileController.setGoHomeButtonPos((GAME_PLAYER_NEWS)meg[0]);
			}
			break;
		case 74:
			this.doorController.SetShowHomeBtn(false);
			break;
		case 75:
			this.doorController.SetShowHomeBtn(true);
			break;
		case 76:
			this.doorController.SetHomeBtnLocation((ushort)GameConstants.ConvertBytesToFloat(meg, 1), (ushort)GameConstants.ConvertBytesToFloat(meg, 5));
			break;
		case 77:
			if (this.realmController != null)
			{
				this.realmController.CloseSelect();
			}
			break;
		case 78:
			if (this.realmController != null)
			{
				this.realmController.CloseMark();
			}
			break;
		case 79:
			this.doorController.CheckMapID((int)GameConstants.ConvertBytesToUInt(meg, 1));
			break;
		case 80:
			if (this.doorController.m_GroundInfo != null)
			{
				this.doorController.m_GroundInfo.UpdateUI(1, (int)GameConstants.ConvertBytesToUInt(meg, 1));
			}
			break;
		case 81:
			this.doorController.GoToGroup((int)GameConstants.ConvertBytesToUShort(meg, 1), 0, true);
			break;
		case 82:
			this.CheckFocus();
			break;
		case 83:
		{
			if (this.realmController != null)
			{
				this.realmController.UpdateHomePos();
			}
			Vector2 tileMapPosbySpriteID = GameConstants.getTileMapPosbySpriteID(DataManager.Instance.RoleAttr.CapitalPoint);
			this.doorController.ShowKingdomMark(false);
			this.doorController.SetCapitalLocation((ushort)tileMapPosbySpriteID.x, (ushort)tileMapPosbySpriteID.y);
			this.doorController.GoToGroup(-1, 0, meg[1] == 1);
			break;
		}
		case 84:
			if (this.realmController != null && this.realmController.gameObject.activeSelf)
			{
				GameManager.RegisterObserver(0, 3, this, 1);
				this.realmController.Stop();
			}
			break;
		case 85:
			if (this.realmController != null && !this.realmController.gameObject.activeSelf)
			{
				GameManager.RemoveObserver(0, 3, this);
				this.realmController.Active();
			}
			break;
		case 86:
			if (this.realmController != null)
			{
				int index = (int)GameConstants.ConvertBytesToUInt(meg, 1);
				this.realmController.mapTileController.UpdateMapNPCHurt((uint)GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[index].start.zoneID, DataManager.MapDataController.MapLineTable[index].start.pointID), true);
			}
			break;
		case 87:
			if (this.realmController != null)
			{
				this.realmController.mapTileController.UpdateMapNPCBlood(GameConstants.ConvertBytesToUInt(meg, 1), GameConstants.ConvertBytesToFloat(meg, 5));
			}
			break;
		case 88:
			if (this.realmController != null)
			{
				this.realmController.UpdateMapNPCNameBlood(meg[1], meg[2], GameConstants.ConvertBytesToFloat(meg, 3));
			}
			break;
		case 89:
			this.ReLoadMap();
			break;
		case 90:
			if (this.realmController != null)
			{
				this.realmController.UpdatePoint(meg[1], meg[2]);
			}
			break;
		case 91:
			if (this.realmController != null)
			{
				int num2 = (int)GameConstants.ConvertBytesToUInt(meg, 1);
				if (this.realmController.mapTileController != null)
				{
					this.realmController.mapTileController.UpdateMapNPCFighterLeave((uint)GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[num2].start.zoneID, DataManager.MapDataController.MapLineTable[num2].start.pointID), num2);
				}
			}
			break;
		case 92:
			if (this.realmController != null && this.realmController.mapLineController != null)
			{
				this.realmController.mapLineController.ResetLineState();
			}
			break;
		case 93:
			if (this.realmController != null)
			{
				this.realmController.reflashEffect();
				if (this.realmController.mapTileController != null)
				{
					this.realmController.mapTileController.ReflashGraphic();
				}
			}
			break;
		case 94:
			if (this.doorController != null)
			{
				ushort pvpwonderID = GameConstants.ConvertBytesToUShort(meg, 1);
				this.doorController.SetPVPWonderID(pvpwonderID);
			}
			break;
		case 95:
			if (this.doorController != null)
			{
				ushort num3 = GameConstants.ConvertBytesToUShort(meg, 1);
				this.doorController.ClearPVPWonderID();
			}
			break;
		case 96:
			if (this.doorController != null)
			{
				this.doorController.BeginFadeOut();
			}
			break;
		case 97:
			if (this.doorController != null)
			{
				this.doorController.BeginFadeIn();
			}
			break;
		case 98:
			if (this.realmController != null)
			{
				this.realmController.ShowDamageRange(GameConstants.ConvertBytesToUShort(meg, 1), meg[3], GameConstants.ConvertBytesToUShort(meg, 4));
			}
			break;
		case 99:
			if (this.realmController != null)
			{
				this.realmController.HideDamageRange();
			}
			break;
		case 100:
			if (this.realmController != null)
			{
				this.realmController.UseMapWeapon(GameConstants.ConvertBytesToUShort(meg, 1), GameConstants.ConvertBytesToUShort(meg, 3));
			}
			break;
		case 101:
			if (this.realmController != null)
			{
				this.realmController.StopMapWeaponShow();
			}
			break;
		case 102:
			if (this.realmController != null)
			{
				this.realmController.MapWeaponAttack(GameConstants.ConvertBytesToUShort(meg, 1), meg[3], GameConstants.ConvertBytesToUShort(meg, 4), GameConstants.ConvertBytesToFloat(meg, 6));
			}
			break;
		case 103:
			if (this.realmController != null)
			{
				this.realmController.MapWeaponDefense(GameConstants.ConvertBytesToUShort(meg, 1), meg[3], GameConstants.ConvertBytesToUShort(meg, 4), GameConstants.ConvertBytesToFloat(meg, 6));
			}
			break;
		case 104:
			if (this.doorController != null)
			{
				this.doorController.CheckFocusGroup();
				DataManager.MapDataController.FocusGroupID = 10;
				this.doorController.GoToMapID(DataManager.MapDataController.OtherKingdomData.kingdomID, DataManager.Instance.RoleAttr.CapitalPoint, 0, 1, true);
			}
			break;
		case 105:
			if (this.realmController != null)
			{
				this.realmController.ShowBallDownEffect(GameConstants.ConvertBytesToUInt(meg, 1));
			}
			break;
		case 106:
			if (this.realmController != null)
			{
				this.realmController.ShowBallKickEffect(GameConstants.ConvertBytesToUInt(meg, 1));
			}
			break;
		case 107:
			if (this.realmController != null)
			{
				this.realmController.ShowBallBombEffect(GameConstants.ConvertBytesToUInt(meg, 1));
			}
			break;
		case 108:
			if (this.doorController != null)
			{
				this.doorController.CheckFocusGroup();
			}
			DataManager.MapDataController.FocusGroupID = 10;
			if (this.realmController != null && this.realmController.mapTileController != null)
			{
				this.realmController.mapTileController.FocusMyBall();
			}
			break;
		case 109:
			this.doorController.SetShowFIFA_FindBtn(false);
			break;
		case 110:
			this.doorController.SetShowFIFA_FindBtn(true);
			break;
		case 111:
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBall, 6, 0);
			break;
		case 112:
			if (this.realmController != null && this.realmController.mapTileController != null)
			{
				this.realmController.mapTileController.stopMoveToTarget();
			}
			break;
		}
	}

	// Token: 0x060009DF RID: 2527 RVA: 0x000D0414 File Offset: 0x000CE614
	protected override void UpdateNext(byte[] meg)
	{
		if (NetworkManager.GuestController.Connected() || NetworkManager.GuestController.Connecting())
		{
			NetworkManager.Instance.ViewClose();
		}
		DataManager.MapDataController.OutMap();
		DataManager.MapDataController.zoomSize = this.realmController.transform.localScale.x;
		if (this.doorController != null)
		{
			this.doorController.DeSpawnMainEff();
			this.doorController.ShowKingdomMark(true);
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
		if (this.realmController != null)
		{
			this.realmController.ClearEffect();
			UnityEngine.Object.DestroyObject(this.realmController.gameObject);
		}
		this.realmController = null;
		GUIManager.Instance.ClearMapSprite();
		GUIManager.Instance.DestroyTechIconSprite();
		GUIManager.Instance.UnloadWonderSprite();
		GUIManager.Instance.EmojiManager.Clear();
		ParticleManager.Instance.Clear();
	}

	// Token: 0x060009E0 RID: 2528 RVA: 0x000D0584 File Offset: 0x000CE784
	protected override void UpdateLoad(byte[] meg)
	{
		if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID && !NetworkManager.GuestController.Connected() && !NetworkManager.GuestController.Connecting())
		{
			MapManager mapDataController = DataManager.MapDataController;
			mapDataController.gotoKingdomState += 1;
			GUIManager.Instance.ShowUILock(EUILock.Normal);
			NetworkManager.Instance.ViewKingdom(DataManager.MapDataController.FocusKingdomID);
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
		this.doorController.SwitchMapMode(EUIOriginMapMode.KingdomMap);
		this.doorController.ShowKingdomMark(false);
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

	// Token: 0x060009E1 RID: 2529 RVA: 0x000D06F4 File Offset: 0x000CE8F4
	protected override void UpdateReady(byte[] meg)
	{
		GameObject gameObject = new GameObject("RealmGroup");
		gameObject.transform.SetParent(GUIManager.Instance.m_UICanvas.transform, false);
		gameObject.transform.SetAsFirstSibling();
		this.realmController = gameObject.GetComponent<Realm>();
		if (this.realmController == null)
		{
			this.realmController = gameObject.AddComponent<Realm>();
		}
		gameObject.transform.localScale = Vector3.one * DataManager.MapDataController.zoomSize;
		Vector2 tileMapPosbySpriteID = GameConstants.getTileMapPosbySpriteID(DataManager.Instance.RoleAttr.CapitalPoint);
		this.doorController.notifyHomeBtnPos();
		this.doorController.SetCapitalLocation((ushort)tileMapPosbySpriteID.x, (ushort)tileMapPosbySpriteID.y);
		this.doorController.SetTileMapController(this.realmController.mapTileController);
		this.realmController.CheckCenterPos();
		if (this.doorController.m_WindowStack.Count != 0)
		{
			GameManager.RegisterObserver(0, 3, this, 1);
			this.realmController.Stop();
		}
		if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID)
		{
			this.doorController.SetShowHomeBtn(false);
			if (NetworkManager.GuestController.Connected())
			{
				GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
			}
		}
		else
		{
			GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END, eTransFunc.Max);
		}
		if (DataManager.MapDataController.FocusKingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
		{
			this.doorController.LoadMainEff(EMapEffectKind.WORLDWAR);
		}
		else
		{
			this.doorController.LoadMainEff(EMapEffectKind.CHAOS);
		}
	}

	// Token: 0x060009E2 RID: 2530 RVA: 0x000D0890 File Offset: 0x000CEA90
	protected override void UpdateRun(byte[] meg)
	{
		this.realmController.LineControllerUpdate();
		this.realmController.NPCControllerUpdate();
	}

	// Token: 0x0400211E RID: 8478
	public Realm realmController;

	// Token: 0x0400211F RID: 8479
	private Door doorController;
}
