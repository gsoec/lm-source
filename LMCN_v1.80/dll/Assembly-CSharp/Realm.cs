using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Token: 0x02000275 RID: 629
public class Realm : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler, IEventSystemHandler
{
	// Token: 0x06000BCD RID: 3021 RVA: 0x00112BBC File Offset: 0x00110DBC
	protected void Awake()
	{
		GameObject gameObject = new GameObject("RealmGroup3D");
		this.RealmGroup_3DTransform = gameObject.transform;
		this.RealmGroup_3DTransform.localScale = Vector3.one * DataManager.MapDataController.zoomSize;
		AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/TileBase", out this.TileBaseABKey, false);
		GameObject gameObject2 = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
		RectTransform component = gameObject2.GetComponent<RectTransform>();
		this.Canvasrectran = GUIManager.Instance.pDVMgr.CanvasRT;
		component.sizeDelta = this.Canvasrectran.sizeDelta;
		if (GUIManager.Instance.m_UICanvas.renderMode == RenderMode.ScreenSpaceCamera)
		{
			DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale = (this.CanvasrectranScale = this.Canvasrectran.localScale.x);
		}
		else
		{
			this.CanvasrectranScale = DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
		}
		this.mapTileController = gameObject2.GetComponent<MapTile>();
		if (this.mapTileController == null)
		{
			this.mapTileController = gameObject2.AddComponent<MapTile>();
		}
		component.SetParent(GUIManager.Instance.m_UICanvas.transform.GetChild(0), false);
		component.SetAsFirstSibling();
		this.TileLevelController = new MapTileLevel(base.transform, this.mapTileController.TileSprites);
		this.TileSelectController = new MapTileSelect(base.transform, this.mapTileController.TileSprites);
		this.TileYolkController = new MapTileYolk(base.transform);
		assetBundle = AssetManager.GetAssetBundle("UI/MapTileGraphic", out this.MapTileGraphicABKey, false);
		this.mapGraphicController = new MapTileGraphic(base.transform, UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
		this.mapNameController = new MapTileBloodName(base.transform);
		this.mapNPCController = new MapTileNPC(this.RealmGroup_3DTransform);
		this.mapTileController.setNPC(this.mapNPCController);
		this.mapLineController = new FlowLineFactory(this.RealmGroup_3DTransform, this.mapNameController, this.mapTileController.TileBaseScale);
		this.mapTileController.setLine(this.mapLineController);
		this.mapEffectController = new MapTileEffect(this.RealmGroup_3DTransform, this.mapTileController.TileBaseScale);
		this.mapTileController.setEffect(this.mapEffectController);
		this.mapTileModelController = new MapTileModel(this.RealmGroup_3DTransform, this.mapTileController.TileBaseScale);
		this.mapTileController.setWeapon(this.mapTileModelController);
		this.mapTileController.setLevel(this.TileLevelController);
		this.mapTileController.setBloodName(this.mapNameController);
		this.mapTileController.setGraphicImage(this.mapGraphicController);
		this.mapTileController.setRealmGroup_3DTransform(this.RealmGroup_3DTransform);
		this.mapTileController.setYolk(this.TileYolkController);
		this.FM = FootballManager.Instance;
	}

	// Token: 0x06000BCE RID: 3022 RVA: 0x00112E8C File Offset: 0x0011108C
	protected void OnDestroy()
	{
		if (this.mapTileModelController != null)
		{
			this.mapTileModelController.OnDestroy();
		}
		this.mapTileModelController = null;
		if (this.mapNPCController != null)
		{
			this.mapNPCController.OnDestroy();
		}
		this.mapNPCController = null;
		this.ClearEffect();
		if (this.mapGraphicController != null)
		{
			this.mapGraphicController.OnDestroy();
		}
		this.mapGraphicController = null;
		if (this.mapLineController != null)
		{
			this.mapLineController.Clear();
		}
		this.mapLineController = null;
		NewbieManager.ClearFakeLineData();
		if (this.mapNameController != null)
		{
			this.mapNameController.OnDestroy();
		}
		this.mapNameController = null;
		if (this.TileYolkController != null)
		{
			this.TileYolkController.OnDestroy();
		}
		this.TileYolkController = null;
		if (this.TileSelectController != null)
		{
			this.TileSelectController.OnDestroy();
		}
		this.TileSelectController = null;
		if (this.TileLevelController != null)
		{
			this.TileLevelController.OnDestroy();
		}
		this.TileLevelController = null;
		if (this.mapTileController != null)
		{
			UnityEngine.Object.DestroyObject(this.mapTileController.gameObject);
		}
		this.mapTileController = null;
		this.Canvasrectran = null;
		if (this.RealmGroup_3DTransform != null)
		{
			UnityEngine.Object.DestroyObject(this.RealmGroup_3DTransform.gameObject);
		}
		this.RealmGroup_3DTransform = null;
		AssetManager.UnloadAssetBundle(this.TileBaseABKey, true);
		AssetManager.UnloadAssetBundle(this.MapTileGraphicABKey, true);
	}

	// Token: 0x06000BCF RID: 3023 RVA: 0x00112FFC File Offset: 0x001111FC
	protected void Update()
	{
		this.LineControllerUpdate();
		this.TileSelectController.SelectUpdate();
		this.mapEffectController.EffectCheck();
		this.NPCControllerUpdate();
		this.mapTileModelController.MapTileModelUpdate();
	}

	// Token: 0x06000BD0 RID: 3024 RVA: 0x00113038 File Offset: 0x00111238
	public void OnDrag(PointerEventData eventData)
	{
		this.mapTileController.OnDrag(eventData);
		this.mapTileController.Movedelta = Vector2.zero;
		if (this.mFootBallID != 0)
		{
			byte b = (byte)this.mapTileController.FootBallGetSkill(eventData);
			if (b == 0)
			{
				this.TileSelectController.UpdataFootSkill(0, 0);
			}
			else
			{
				this.TileSelectController.SetShowFootBallSkill(true);
				this.TileSelectController.UpdataFootSkill(b, this.mFootBallStr);
			}
		}
	}

	// Token: 0x06000BD1 RID: 3025 RVA: 0x001130B0 File Offset: 0x001112B0
	public void OnPointerDown(PointerEventData eventData)
	{
		this.mapTileController.OnPointerDown(eventData);
	}

	// Token: 0x06000BD2 RID: 3026 RVA: 0x001130C0 File Offset: 0x001112C0
	public void OnPointerUp(PointerEventData eventData)
	{
		this.mapTileController.OnPointerUp(eventData);
	}

	// Token: 0x06000BD3 RID: 3027 RVA: 0x001130D0 File Offset: 0x001112D0
	public void UpdateTileMap(ushort ZoneID)
	{
		this.mapTileController.UpdateTileMap(ZoneID);
	}

	// Token: 0x06000BD4 RID: 3028 RVA: 0x001130E0 File Offset: 0x001112E0
	public void UpdatePoint(uint LayoutMapInfoID)
	{
		this.mapTileController.UpdatePoint(LayoutMapInfoID);
		POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind(LayoutMapInfoID);
		if (this.mapLineController != null && (DataManager.MapDataController.IsCityOrCamp(LayoutMapInfoID) || layoutMapInfoPointKind == POINT_KIND.PK_YOLK))
		{
			int tableID = (int)DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)LayoutMapInfoID)].tableID;
			byte b = 1;
			b |= 2;
			if ((DataManager.MapDataController.PlayerPointTable[tableID].capitalFlag & b) != 0 || layoutMapInfoPointKind == POINT_KIND.PK_YOLK)
			{
				PointCode code = default(PointCode);
				GameConstants.MapIDToPointCode((int)LayoutMapInfoID, out code.zoneID, out code.pointID);
				PointModifyNode item = default(PointModifyNode);
				item.Code = code;
				item.Kind = layoutMapInfoPointKind;
				this.mapLineController.PointModifyList.Add(item);
			}
		}
	}

	// Token: 0x06000BD5 RID: 3029 RVA: 0x001131B0 File Offset: 0x001113B0
	public void DelLine(int LineTableID, byte Send = 1, byte bDelAll = 0)
	{
		if (this.mapLineController != null && DataManager.MapDataController.MapLineTable[LineTableID].lineObject != null)
		{
			bool forceRemove = false;
			if (!GameConstants.IsPetSkillLine(LineTableID) && !GameConstants.IsSoccerRunningLine(LineTableID))
			{
				if (DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == 27 && NetworkManager.ServerTime - DataManager.MapDataController.MapLineTable[LineTableID].begin < 5.0)
				{
					this.mapTileController.UpdateMapNPCFighterLeave((uint)GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[LineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].start.pointID), LineTableID);
				}
				else if (DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == 12)
				{
					this.mapLineController.LastRallyName.ClearString();
					this.mapLineController.LastRallyName.Append(DataManager.MapDataController.MapLineTable[LineTableID].playerName);
				}
				if (Send != 255 && (DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == 5 || DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == 6 || DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == 7 || DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == 12 || DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == 9))
				{
					bool flag = true;
					int num = GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[LineTableID].end.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].end.pointID);
					POINT_KIND pointKind = (POINT_KIND)DataManager.MapDataController.LayoutMapInfo[num].pointKind;
					if (pointKind == POINT_KIND.PK_NONE)
					{
						flag = false;
					}
					else if (DataManager.MapDataController.IsResources((uint)num))
					{
						int tableID = (int)DataManager.MapDataController.LayoutMapInfo[num].tableID;
						if (DataManager.CompareStr(DataManager.MapDataController.ResourcesPointTable[tableID].playerName, string.Empty) == 0)
						{
							flag = false;
						}
					}
					else if (pointKind == POINT_KIND.PK_CITY)
					{
						int tableID2 = (int)DataManager.MapDataController.LayoutMapInfo[num].tableID;
						if (DataManager.CompareStr(DataManager.MapDataController.PlayerPointTable[tableID2].allianceTag, DataManager.MapDataController.MapLineTable[LineTableID].allianceTag) == 0)
						{
							flag = false;
						}
					}
					if (flag)
					{
						FakeRetreat item = new FakeRetreat(0);
						item.point = DataManager.MapDataController.MapLineTable[LineTableID].end;
						item.point2 = DataManager.MapDataController.MapLineTable[LineTableID].start;
						item.lineFlag = (EMarchEventType)DataManager.MapDataController.MapLineTable[LineTableID].lineFlag;
						bool flag2 = true;
						ELineColor lineColor = ELineColor.BLUE;
						EUnitSide unitSide = EUnitSide.BLUE;
						DataManager.checkLineColorID(LineTableID, out lineColor, out unitSide, out flag2);
						item.unitSide = unitSide;
						item.lineColor = lineColor;
						item.playerName.ClearString();
						item.playerName.Append(DataManager.MapDataController.MapLineTable[LineTableID].playerName);
						item.allianceTag.ClearString();
						item.allianceTag.Append(DataManager.MapDataController.MapLineTable[LineTableID].allianceTag);
						item.emoji = DataManager.MapDataController.MapLineTable[LineTableID].emojiID;
						this.mapLineController.FakeRetreatList.Add(item);
					}
				}
			}
			else if (GameConstants.IsPetSkillLine(LineTableID))
			{
				long num2 = (long)(DataManager.MapDataController.MapLineTable[LineTableID].begin + (ulong)DataManager.MapDataController.MapLineTable[LineTableID].during);
				uint during = DataManager.MapDataController.MapLineTable[LineTableID].during;
				if (during <= 2u || Math.Abs(num2 - DataManager.Instance.ServerTime) <= 1L)
				{
					Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
					if (door == null || door.m_eMode == EUIOriginMode.Show)
					{
						byte lineFlag = DataManager.MapDataController.MapLineTable[LineTableID].lineFlag;
						MapDamageEffTb recordByKey = PetManager.Instance.MapDamageEffTable.GetRecordByKey((ushort)lineFlag);
						if (recordByKey.ID == (ushort)lineFlag)
						{
							float d = DataManager.MapDataController.zoomSize * this.CanvasrectranScale;
							Vector2 vector = this.mapTileController.getTilePosition(DataManager.MapDataController.MapLineTable[LineTableID].end.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].end.pointID) * d;
							Vector3 value = new Vector3(vector.x, vector.y, 0f);
							CString cstring = StringManager.Instance.SpawnString(30);
							if (recordByKey.SoundPakNO != 0)
							{
								cstring.ClearString();
								cstring.StringToFormat("Role/");
								cstring.IntToFormat((long)recordByKey.SoundPakNO, 3, false);
								cstring.AppendFormat("{0}{1}");
								if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.HeroSFX, recordByKey.SoundPakNO, false))
								{
									AudioManager.Instance.PlaySFX(recordByKey.HitSound, 0f, PitchKind.NoPitch, null, new Vector3?(value));
								}
							}
							else
							{
								AudioManager.Instance.PlaySFX(recordByKey.HitSound, 0f, PitchKind.NoPitch, null, new Vector3?(value));
							}
							if (recordByKey.ParticlePakNO != 0)
							{
								cstring.ClearString();
								cstring.StringToFormat("Particle/Monster_Effects_");
								cstring.IntToFormat((long)recordByKey.ParticlePakNO, 3, false);
								cstring.AppendFormat("{0}{1}");
								if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Particle, AssetType.Effects, recordByKey.ParticlePakNO, false))
								{
									DataManager.MapDataController.MapWeaponDefense(DataManager.MapDataController.MapLineTable[LineTableID].end.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].end.pointID, recordByKey.HitParticle, (float)recordByKey.HitParticleDuring * 0.001f);
								}
							}
							else
							{
								DataManager.MapDataController.MapWeaponDefense(DataManager.MapDataController.MapLineTable[LineTableID].end.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].end.pointID, recordByKey.HitParticle, (float)recordByKey.HitParticleDuring * 0.001f);
							}
							StringManager.Instance.DeSpawnString(cstring);
						}
					}
				}
			}
			else
			{
				forceRemove = true;
				if (bDelAll == 0)
				{
					MapLine mapLine = DataManager.MapDataController.MapLineTable[LineTableID];
					if ((mapLine.lineFlag & 56) == 56)
					{
						if (mapLine.start.zoneID != mapLine.end.zoneID || mapLine.start.pointID != mapLine.end.pointID)
						{
							Vector3 b = this.PointCodeToWorldPosition(mapLine.start.zoneID, mapLine.start.pointID);
							Vector3 vector2 = this.PointCodeToWorldPosition(mapLine.end.zoneID, mapLine.end.pointID);
							this.mapLineController.addSoccerFakeLine(vector2, new Vector3?(vector2 - b), 0);
						}
					}
					else
					{
						long num3 = (long)(mapLine.begin + (ulong)mapLine.during);
						uint during2 = mapLine.during;
						long num4 = Math.Abs(num3 - DataManager.Instance.ServerTime);
						if (during2 <= 2u || num4 <= 1L)
						{
							this.mapLineController.CheckTouchDownPosEffect(mapLine.end.zoneID, mapLine.end.pointID);
						}
						LineNode nodeByGameObject = this.mapLineController.GetNodeByGameObject(DataManager.MapDataController.MapLineTable[LineTableID].lineObject, false);
						this.mapLineController.PlaySoccerArrive(nodeByGameObject);
					}
				}
			}
			Send = ((Send != byte.MaxValue) ? Send : 1);
			if (bDelAll != 0)
			{
				forceRemove = true;
			}
			this.mapTileController.CheckDelFocusGroup(LineTableID, Send);
			this.mapLineController.CheckRemoveLine(DataManager.MapDataController.MapLineTable[LineTableID].lineObject, forceRemove);
		}
	}

	// Token: 0x06000BD6 RID: 3030 RVA: 0x00113A3C File Offset: 0x00111C3C
	public void AddLine(int LineTableID, bool show = true)
	{
		if (DataManager.MapDataController.MapLineTable[LineTableID].lineObject != null)
		{
			return;
		}
		EUnitSide? eunitSide = null;
		ELineColor? elineColor = null;
		ushort num = 0;
		if (!GameConstants.IsPetSkillLine(LineTableID) && !GameConstants.IsSoccerRunningLine(LineTableID))
		{
			for (int i = 0; i < this.mapLineController.FakeRetreatList.Count; i++)
			{
				int num2 = GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[LineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].start.pointID);
				POINT_KIND pointKind = (POINT_KIND)DataManager.MapDataController.LayoutMapInfo[num2].pointKind;
				PointCode start = DataManager.MapDataController.MapLineTable[LineTableID].start;
				if (start.pointID == this.mapLineController.FakeRetreatList[i].point.pointID && start.zoneID == this.mapLineController.FakeRetreatList[i].point.zoneID)
				{
					if (this.mapLineController.FakeRetreatList[i].flag != 0)
					{
						eunitSide = new EUnitSide?(this.mapLineController.FakeRetreatList[i].unitSide);
						elineColor = new ELineColor?(this.mapLineController.FakeRetreatList[i].lineColor);
					}
					num = this.mapLineController.FakeRetreatList[i].emoji;
					this.mapLineController.FakeRetreatList.RemoveAt(i);
					break;
				}
				if (this.mapLineController.FakeRetreatList[i].lineFlag == EMarchEventType.EMET_RallyAttack && DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == 17)
				{
					int num3 = GameConstants.PointCodeToMapID(this.mapLineController.FakeRetreatList[i].point.zoneID, this.mapLineController.FakeRetreatList[i].point.pointID);
					POINT_KIND pointKind2 = (POINT_KIND)DataManager.MapDataController.LayoutMapInfo[num3].pointKind;
					if (pointKind2 == POINT_KIND.PK_YOLK && DataManager.MapDataController.MapLineTable[LineTableID].end.pointID == this.mapLineController.FakeRetreatList[i].point2.pointID && DataManager.MapDataController.MapLineTable[LineTableID].end.zoneID == this.mapLineController.FakeRetreatList[i].point2.zoneID)
					{
						this.mapLineController.FakeRetreatList.RemoveAt(i);
						break;
					}
				}
			}
		}
		bool bEase = true;
		ELineColor color = ELineColor.BLUE;
		EUnitSide unitSide = EUnitSide.BLUE;
		DataManager.checkLineColorID(LineTableID, out color, out unitSide, out bEase);
		if (eunitSide != null)
		{
			unitSide = eunitSide.Value;
			color = elineColor.Value;
		}
		float d = DataManager.MapDataController.zoomSize * this.CanvasrectranScale;
		Vector2 vector = this.mapTileController.getTilePosition(DataManager.MapDataController.MapLineTable[LineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].start.pointID) * d;
		Vector3 from = new Vector3(vector.x, vector.y, 0f);
		vector = this.mapTileController.getTilePosition(DataManager.MapDataController.MapLineTable[LineTableID].end.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].end.pointID) * d;
		int layoutMapInfoID = 0;
		sbyte b = 0;
		if (!GameConstants.IsPetSkillLine(LineTableID) && !GameConstants.IsSoccerRunningLine(LineTableID) && DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == 27)
		{
			if (NetworkManager.ServerTime - DataManager.MapDataController.MapLineTable[LineTableID].begin < 5.0)
			{
				layoutMapInfoID = GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[LineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].start.pointID);
				b = this.mapTileController.getNPCDir((uint)layoutMapInfoID);
			}
			else
			{
				layoutMapInfoID = GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[LineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].start.pointID);
				this.mapTileController.UpdateMapNPCHurt((uint)layoutMapInfoID, false);
				layoutMapInfoID = 0;
			}
		}
		byte b2 = 0;
		if (this.IsPowerSoccer(LineTableID))
		{
			b2 |= 1;
		}
		LineNode lineNode = this.mapLineController.createLine(LineTableID, from, new Vector3(vector.x, vector.y, 0f), color, unitSide, bEase, show, ((int)b >= 0) ? EMonsterFace.LEFT : EMonsterFace.RIGHT, b2);
		DataManager.MapDataController.MapLineTable[LineTableID].lineObject = ((lineNode != null) ? lineNode.gameObject : null);
		if (lineNode != null && (int)b != 0)
		{
			this.mapTileController.setNPCLinenode((uint)layoutMapInfoID, lineNode);
		}
		if (num != 0 && lineNode.action != ELineAction.NORMAL)
		{
			MapLine mapLine = DataManager.MapDataController.MapLineTable[LineTableID];
			mapLine.baseFlag |= 1;
			DataManager.MapDataController.MapLineTable[LineTableID].emojiID = num;
			this.UpdateLineEmoji(LineTableID);
		}
		this.CheckShowMapWeaponLine(LineTableID);
	}

	// Token: 0x06000BD7 RID: 3031 RVA: 0x00114020 File Offset: 0x00112220
	public bool IsPowerSoccer(int LineTableID)
	{
		if (GameConstants.IsSoccerRunningLine(LineTableID) || GameConstants.IsPetSkillLine(LineTableID) || DataManager.MapDataController.MapLineTable[LineTableID].lineFlag != 30)
		{
			return false;
		}
		int num = GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[LineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].start.pointID);
		POINT_KIND pointKind = (POINT_KIND)DataManager.MapDataController.LayoutMapInfo[num].pointKind;
		if (pointKind == POINT_KIND.PK_NPC)
		{
			ushort tableID = DataManager.MapDataController.LayoutMapInfo[num].tableID;
			if (DataManager.MapDataController.NPCPointTable[(int)tableID].Key == FootballManager.Instance.mFootballKickData.last_football_id && FootballManager.Instance.mFootballKickData.combo > 1)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000BD8 RID: 3032 RVA: 0x00114110 File Offset: 0x00112310
	public Vector3 PointCodeToWorldPosition(ushort zoneID, byte pointID)
	{
		float d = DataManager.MapDataController.zoomSize * this.CanvasrectranScale;
		Vector2 vector = this.mapTileController.getTilePosition(zoneID, pointID) * d;
		return new Vector3(vector.x, vector.y, 0f);
	}

	// Token: 0x06000BD9 RID: 3033 RVA: 0x0011415C File Offset: 0x0011235C
	public void CheckShowMapWeaponLine(int LineTableID)
	{
		if ((this.mapWeaponID == 0 && this.mapSkillID == 0) || (DataManager.MapDataController.MapLineTable[LineTableID].baseFlag & 2) == 0 || DataManager.CompareStr(DataManager.MapDataController.MapLineTable[LineTableID].playerName, DataManager.Instance.RoleAttr.Name) != 0)
		{
			return;
		}
		long num = DataManager.Instance.ServerTime - (long)DataManager.MapDataController.MapLineTable[LineTableID].begin;
		if (num < 3L)
		{
			this.MapWeaponDebut(-90f - DataManager.MapDataController.MapLineTable[LineTableID].lineObject.transform.localEulerAngles.z);
		}
		else
		{
			this.StopMapWeaponShow();
		}
	}

	// Token: 0x06000BDA RID: 3034 RVA: 0x00114234 File Offset: 0x00112434
	public void UpdateLineOwner(int LineTableID)
	{
		LineNode lineValue = this.mapLineController.getLineValue(DataManager.MapDataController.MapLineTable[LineTableID].lineObject);
		lineValue.NodeName.updateName(DataManager.MapDataController.MapLineTable[LineTableID].playerName, DataManager.MapDataController.MapLineTable[LineTableID].allianceTag, 0, null);
	}

	// Token: 0x06000BDB RID: 3035 RVA: 0x0011429C File Offset: 0x0011249C
	public void UpdateLineTag(int LineTableID)
	{
		if (DataManager.CompareStr(DataManager.MapDataController.MapLineTable[LineTableID].playerName, DataManager.Instance.RoleAttr.Name) == 0)
		{
			DataManager.Instance.RoleAlliance.Tag.ClearString();
			DataManager.Instance.RoleAlliance.Tag.Append(DataManager.MapDataController.MapLineTable[LineTableID].allianceTag);
			if (DataManager.Instance.RoleAlliance.Tag.Length == 0)
			{
				DataManager.Instance.RoleAlliance.Id = 0u;
				DataManager.Instance.RoleAlliance.KingdomID = 0;
			}
			LineNode lineValue = this.mapLineController.getLineValue(DataManager.MapDataController.MapLineTable[LineTableID].lineObject);
			lineValue.NodeName.updateName(DataManager.MapDataController.MapLineTable[LineTableID].playerName, DataManager.MapDataController.MapLineTable[LineTableID].allianceTag, 0, null);
		}
		else
		{
			bool bEase = true;
			ELineColor color = ELineColor.BLUE;
			EUnitSide unitSide = EUnitSide.BLUE;
			DataManager.checkLineColorID(LineTableID, out color, out unitSide, out bEase);
			this.mapLineController.setLineColor(DataManager.MapDataController.MapLineTable[LineTableID].lineObject, color, unitSide, DataManager.MapDataController.MapLineTable[LineTableID].playerName, DataManager.MapDataController.MapLineTable[LineTableID].allianceTag, bEase);
		}
	}

	// Token: 0x06000BDC RID: 3036 RVA: 0x0011440C File Offset: 0x0011260C
	public void ResetAllLine()
	{
		if (this.mapLineController != null)
		{
			this.mapLineController.resetAllLineColor();
		}
	}

	// Token: 0x06000BDD RID: 3037 RVA: 0x00114424 File Offset: 0x00112624
	public void UpdateLinePos(float movedeltax, float movedeltay)
	{
	}

	// Token: 0x06000BDE RID: 3038 RVA: 0x00114428 File Offset: 0x00112628
	public void UpdateLineBegin(int LineTableID)
	{
		this.mapLineController.recaleSpeed(LineTableID);
	}

	// Token: 0x06000BDF RID: 3039 RVA: 0x00114438 File Offset: 0x00112638
	public void UpdateLineEmoji(int LineTableID)
	{
		LineNode lineValue = this.mapLineController.getLineValue(DataManager.MapDataController.MapLineTable[LineTableID].lineObject);
		if ((DataManager.MapDataController.MapLineTable[LineTableID].baseFlag & 1) != 0)
		{
			EmojiData recordByKey = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(DataManager.MapDataController.MapLineTable[LineTableID].emojiID);
			if (recordByKey.EmojiKey == DataManager.MapDataController.MapLineTable[LineTableID].emojiID)
			{
				float num = (float)((recordByKey.sizeX <= recordByKey.sizeY) ? recordByKey.sizeY : recordByKey.sizeX);
				if (num == 0f)
				{
					num = ((GUIManager.Instance.EmojiManager != null) ? GUIManager.Instance.EmojiManager.basebacksize : 73f);
				}
				else
				{
					num *= 0.9f;
					num += ((GUIManager.Instance.EmojiManager != null) ? GUIManager.Instance.EmojiManager.basebackoffset : 25f);
				}
				num /= ((GUIManager.Instance.EmojiManager != null) ? GUIManager.Instance.EmojiManager.basebacksize : 73f);
				SheetAnimationUnitGroup sheetAnimationUnitGroup;
				if (lineValue.NodeName.mapEmojiBack == null)
				{
					lineValue.NodeName.mapEmojiBack = GUIManager.Instance.pullEmojiIcon(ushort.MaxValue, 0, true);
					sheetAnimationUnitGroup = (lineValue.sheetUnit as SheetAnimationUnitGroup);
					lineValue.NodeName.mapEmojiBack.EmojiTransform.SetParent(sheetAnimationUnitGroup.transform, false);
				}
				lineValue.NodeName.mapEmojiBack.EmojiTransform.localPosition = GameConstants.lineeomjiback;
				lineValue.NodeName.mapEmojiBack.EmojiTransform.localScale = Vector3.one * num;
				if (lineValue.NodeName.mapEmoji != null)
				{
					GUIManager.Instance.pushEmojiIcon(lineValue.NodeName.mapEmoji);
					lineValue.NodeName.mapEmoji = null;
				}
				lineValue.NodeName.mapEmoji = GUIManager.Instance.pullEmojiIcon(recordByKey.IconID, recordByKey.KeyFrame, true);
				lineValue.NodeName.mapEmoji.EmojiTransform.localPosition = GameConstants.lineeomji;
				lineValue.NodeName.mapEmoji.EmojiTransform.localScale = Vector3.one * 0.9f;
				sheetAnimationUnitGroup = (lineValue.sheetUnit as SheetAnimationUnitGroup);
				lineValue.NodeName.mapEmoji.EmojiTransform.SetParent(sheetAnimationUnitGroup.transform, false);
			}
		}
		else if (lineValue.NodeName.mapEmoji != null)
		{
			GUIManager.Instance.pushEmojiIcon(lineValue.NodeName.mapEmoji);
			lineValue.NodeName.mapEmoji = null;
			if (lineValue.NodeName.mapEmojiBack != null)
			{
				GUIManager.Instance.pushEmojiIcon(lineValue.NodeName.mapEmojiBack);
				lineValue.NodeName.mapEmojiBack = null;
			}
		}
	}

	// Token: 0x06000BE0 RID: 3040 RVA: 0x0011473C File Offset: 0x0011293C
	public void UpdateLineWeapon(int LineTableID)
	{
	}

	// Token: 0x06000BE1 RID: 3041 RVA: 0x00114740 File Offset: 0x00112940
	public void ClickSelect(float selectX, float selectY, bool big)
	{
		this.TileSelectController.OnSelect(new Vector2(selectX, selectY), big, 0);
	}

	// Token: 0x06000BE2 RID: 3042 RVA: 0x00114758 File Offset: 0x00112958
	public void UpdateHomePos()
	{
		this.mapTileController.updateHomePos();
	}

	// Token: 0x06000BE3 RID: 3043 RVA: 0x00114768 File Offset: 0x00112968
	public void Mark()
	{
		ushort num = 0;
		byte b = 0;
		Vector2 vector = Vector2.zero;
		GameConstants.MapIDToPointCode(DataManager.MapDataController.FocusMapID, out num, out b);
		for (ushort num2 = 0; num2 < 40; num2 += 1)
		{
			if (DataManager.MapDataController.CheckYolk(num2, 0))
			{
				vector = DataManager.MapDataController.GetYolkPointCode(num2, DataManager.MapDataController.FocusKingdomID);
				if (vector.x == (float)num && vector.y == (float)b)
				{
					this.TileSelectController.OnMark(this.mapTileController.getTilePosition(num, b), true);
					return;
				}
			}
		}
		this.TileSelectController.OnMark(this.mapTileController.getTilePosition(num, b), false);
	}

	// Token: 0x06000BE4 RID: 3044 RVA: 0x0011481C File Offset: 0x00112A1C
	public bool ClickGroup()
	{
		return this.mapTileController.ClickGroup();
	}

	// Token: 0x06000BE5 RID: 3045 RVA: 0x0011482C File Offset: 0x00112A2C
	public void CloseEffect()
	{
		this.mapEffectController.setActive(0);
	}

	// Token: 0x06000BE6 RID: 3046 RVA: 0x0011483C File Offset: 0x00112A3C
	public void CloseSelect()
	{
		this.stopFocusGroup();
		this.TileSelectController.Close();
	}

	// Token: 0x06000BE7 RID: 3047 RVA: 0x00114850 File Offset: 0x00112A50
	public void CloseMark()
	{
		this.TileSelectController.Close();
	}

	// Token: 0x06000BE8 RID: 3048 RVA: 0x00114860 File Offset: 0x00112A60
	public void CheckLineUpdate()
	{
		if (this.mapLineController == null)
		{
			this.mapLineController = new FlowLineFactory(this.RealmGroup_3DTransform, this.mapNameController, this.mapTileController.TileBaseScale);
			this.mapTileController.setLine(this.mapLineController);
			this.mapEffectController = new MapTileEffect(this.RealmGroup_3DTransform, this.mapTileController.TileBaseScale);
			this.mapTileController.setEffect(this.mapEffectController);
			this.mapNPCController = new MapTileNPC(this.RealmGroup_3DTransform);
			this.mapTileController.setNPC(this.mapNPCController);
			this.mapTileModelController = new MapTileModel(this.RealmGroup_3DTransform, this.mapTileController.TileBaseScale);
			this.mapTileController.setWeapon(this.mapTileModelController);
		}
	}

	// Token: 0x06000BE9 RID: 3049 RVA: 0x00114928 File Offset: 0x00112B28
	public void UpdateNetwork()
	{
		DataManager.MapDataController.ClearAll();
		if (this.mapLineController != null)
		{
			this.mapLineController.ResetLineState();
		}
		if (DataManager.MapDataController.gotoKingdomState != 255)
		{
			this.mapTileController.RequestMapdata(Vector2.zero, true);
		}
		if (GUIManager.Instance.FindMenu(EGUIWindow.UI_Kingdom_Classifieds))
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_Kingdom_Classifieds, 5, 0);
		}
		this.StopMapWeaponShow();
	}

	// Token: 0x06000BEA RID: 3050 RVA: 0x001149A8 File Offset: 0x00112BA8
	public void CheckCenterPos()
	{
		this.mapTileController.CheckCenterPos();
	}

	// Token: 0x06000BEB RID: 3051 RVA: 0x001149B8 File Offset: 0x00112BB8
	public void stopFocusGroup()
	{
		this.mapTileController.stopFocusGroup();
	}

	// Token: 0x06000BEC RID: 3052 RVA: 0x001149C8 File Offset: 0x00112BC8
	public void ClearEffect()
	{
		if (this.mapEffectController != null)
		{
			this.mapEffectController.OnDestroy();
		}
		this.mapEffectController = null;
	}

	// Token: 0x06000BED RID: 3053 RVA: 0x001149E8 File Offset: 0x00112BE8
	public void notSend()
	{
		this.mapTileController.notSend();
	}

	// Token: 0x06000BEE RID: 3054 RVA: 0x001149F8 File Offset: 0x00112BF8
	public void LineControllerUpdate()
	{
		if (this.mapLineController != null)
		{
			this.mapLineController.Update(Time.deltaTime);
		}
	}

	// Token: 0x06000BEF RID: 3055 RVA: 0x00114A18 File Offset: 0x00112C18
	public void NPCControllerUpdate()
	{
		this.mapNameController.npcTimeRun();
		if (this.mapNPCController != null)
		{
			this.mapNPCController.Run();
		}
	}

	// Token: 0x06000BF0 RID: 3056 RVA: 0x00114A3C File Offset: 0x00112C3C
	public void BloodNameFontTextureRebuilt()
	{
		if (this.mapNameController != null)
		{
			this.mapNameController.MapTileNameRebuilt();
		}
		if (this.mapLineController != null)
		{
			this.mapLineController.LineNameTextRebuilt();
		}
	}

	// Token: 0x06000BF1 RID: 3057 RVA: 0x00114A78 File Offset: 0x00112C78
	public bool isMyPointIn()
	{
		ushort num;
		byte b;
		GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out num, out b);
		for (int i = 0; i < (int)DataManager.MapDataController.zoneIDNum; i++)
		{
			if (DataManager.MapDataController.zoneID[i] == num)
			{
				return true;
			}
		}
		uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
		int num2 = 0;
		while ((long)num2 < (long)((ulong)effectBaseVal))
		{
			if (DataManager.Instance.MarchEventData[num2].Type < EMarchEventType.EMET_InforceStanby)
			{
				GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out num, out b);
				for (int j = 0; j < (int)DataManager.MapDataController.zoneIDNum; j++)
				{
					if (DataManager.MapDataController.zoneID[j] == num)
					{
						return true;
					}
				}
			}
			num2++;
		}
		return false;
	}

	// Token: 0x06000BF2 RID: 3058 RVA: 0x00114B60 File Offset: 0x00112D60
	public void UpdateMapNPCNameBlood(byte row, byte col, float blood)
	{
		if (blood == 0f)
		{
			this.mapNameController.setName(null, null, (int)row, (int)col, Color.white, Vector2.zero, 0, 0f, 0, null, -1, 0f);
		}
		else
		{
			this.mapNameController.setName((int)row, (int)col, blood);
		}
	}

	// Token: 0x06000BF3 RID: 3059 RVA: 0x00114BB4 File Offset: 0x00112DB4
	public void UpdatePoint(byte row, byte col)
	{
		this.mapTileController.UpdatePoint(row, col);
	}

	// Token: 0x06000BF4 RID: 3060 RVA: 0x00114BC4 File Offset: 0x00112DC4
	public bool ResetYolk()
	{
		return this.TileYolkController != null && this.TileYolkController.resetYolk();
	}

	// Token: 0x06000BF5 RID: 3061 RVA: 0x00114BE0 File Offset: 0x00112DE0
	public void reflashEffect()
	{
		if (this.mapEffectController != null)
		{
			this.mapEffectController.ReflashEffect();
		}
	}

	// Token: 0x06000BF6 RID: 3062 RVA: 0x00114BF8 File Offset: 0x00112DF8
	public void ShowDamageRange(ushort zoneID, byte pointID, ushort damageRangeID = 1)
	{
		if (this.TileSelectController != null && this.mapTileController != null)
		{
			this.TileSelectController.OnTarget(damageRangeID, zoneID, pointID, this.mapTileController);
		}
	}

	// Token: 0x06000BF7 RID: 3063 RVA: 0x00114C38 File Offset: 0x00112E38
	public void HideDamageRange()
	{
		if (this.TileSelectController != null)
		{
			this.TileSelectController.NoneTarget(this.mapTileController);
		}
	}

	// Token: 0x06000BF8 RID: 3064 RVA: 0x00114C58 File Offset: 0x00112E58
	public void UseMapWeapon(ushort MapWeaponID, ushort MapSkillID)
	{
		if (MapWeaponID == 0 || MapSkillID == 0 || this.mapTileController == null || this.mapTileModelController == null)
		{
			return;
		}
		this.mapWeaponID = MapWeaponID;
		this.mapSkillID = MapSkillID;
		if (!this.mapTileModelController.SetWeaponResources(MapWeaponID, MapSkillID))
		{
			this.mapSkillID = (this.mapWeaponID = 0);
			DataManager.MapDataController.SendUseMapWeapon();
			return;
		}
		byte focusTypeID = 0;
		this.mapTileController.startFocusMapWeapon(focusTypeID);
	}

	// Token: 0x06000BF9 RID: 3065 RVA: 0x00114CD8 File Offset: 0x00112ED8
	public void StopMapWeaponShow()
	{
		if (this.mapTileController != null)
		{
			this.mapTileController.stopFocusMapWeapon();
		}
		if (this.mapTileModelController != null)
		{
			this.mapTileModelController.Stop();
		}
		this.mapWeaponID = 0;
		this.mapSkillID = 0;
	}

	// Token: 0x06000BFA RID: 3066 RVA: 0x00114D28 File Offset: 0x00112F28
	public void MapWeaponDebut(float RotationY)
	{
		if (this.mapTileModelController != null)
		{
			this.mapTileModelController.startDebut(RotationY);
		}
		else if (this.mapTileController != null)
		{
			this.mapTileController.stopFocusMapWeapon();
		}
	}

	// Token: 0x06000BFB RID: 3067 RVA: 0x00114D70 File Offset: 0x00112F70
	public void MapWeaponAttack(ushort zoneID, byte pointID, ushort effectID, float effectTime)
	{
		if (this.mapWeaponID != 0 && this.mapSkillID != 0 && GameConstants.PointCodeToMapID(zoneID, pointID) == DataManager.Instance.RoleAttr.CapitalPoint)
		{
			return;
		}
		if (this.mapTileModelController != null)
		{
			Vector2 tilePosition = this.mapTileController.getTilePosition(zoneID, pointID);
			Vector3 pos = new Vector3(tilePosition.x, tilePosition.y, 0f);
			if (!this.mapTileModelController.MapWeaponEffect(effectID, pos, effectTime))
			{
				this.mapTileModelController.MapWeaponEffect(60402, pos, 0.6f);
			}
		}
	}

	// Token: 0x06000BFC RID: 3068 RVA: 0x00114E10 File Offset: 0x00113010
	public void MapWeaponDefense(ushort zoneID, byte pointID, ushort effectID, float effectTime)
	{
		if (this.mapTileModelController != null)
		{
			Vector2 tilePosition = this.mapTileController.getTilePosition(zoneID, pointID);
			Vector3 pos = new Vector3(tilePosition.x, tilePosition.y, 0f);
			if (!this.mapTileModelController.MapWeaponEffect(effectID, pos, effectTime))
			{
				this.mapTileModelController.MapWeaponEffect(60403, pos, 1.5f);
			}
		}
	}

	// Token: 0x06000BFD RID: 3069 RVA: 0x00114E7C File Offset: 0x0011307C
	public void SetFootBallSkillID(ushort mSkillID)
	{
		this.TileSelectController.UpdataFootSkill(0, 0);
		this.mFootBallID = mSkillID;
		if (this.mFootBallID != 0)
		{
			this.tmpSkill = this.FM.FootBallSkillTable.GetRecordByKey(this.mFootBallID);
			this.mFootBallStr = (byte)this.tmpSkill.SkillStrength;
			this.OpenFootBallSkill();
		}
		else
		{
			this.mFootBallStr = 0;
		}
	}

	// Token: 0x06000BFE RID: 3070 RVA: 0x00114EE8 File Offset: 0x001130E8
	public void SetHideFootBallSkill()
	{
		this.TileSelectController.UpdataFootSkill(0, 0);
	}

	// Token: 0x06000BFF RID: 3071 RVA: 0x00114EF8 File Offset: 0x001130F8
	public void OpenFootBall()
	{
		this.TileSelectController.SetShowHideFootBallGameObject(true);
	}

	// Token: 0x06000C00 RID: 3072 RVA: 0x00114F08 File Offset: 0x00113108
	public void OpenFootBallSkill()
	{
		this.TileSelectController.SetShowHideFootBallSkillGameObject(true);
	}

	// Token: 0x06000C01 RID: 3073 RVA: 0x00114F18 File Offset: 0x00113118
	public void ClearFootBall()
	{
		this.mFootBallID = 0;
		this.mFootBallStr = 0;
		this.TileSelectController.UpdataFootSkill(0, 0);
		this.TileSelectController.SetShowHideFootBallGameObject(false);
		this.TileSelectController.SetShowHideFootBallSkillGameObject(false);
	}

	// Token: 0x06000C02 RID: 3074 RVA: 0x00114F50 File Offset: 0x00113150
	public void SetFootBallSelect()
	{
		this.TileSelectController.SetFootBallSelect();
	}

	// Token: 0x06000C03 RID: 3075 RVA: 0x00114F60 File Offset: 0x00113160
	public void ShowBallDownEffect(uint LayoutMapInfoID)
	{
		if (this.mapTileModelController != null)
		{
			this.mapTileController.TileBallDownEffect(LayoutMapInfoID);
		}
	}

	// Token: 0x06000C04 RID: 3076 RVA: 0x00114F7C File Offset: 0x0011317C
	public void ShowBallKickEffect(uint LayoutMapInfoID)
	{
		if (this.mapTileModelController != null)
		{
			this.mapTileController.TileBallKickEffect(LayoutMapInfoID);
		}
	}

	// Token: 0x06000C05 RID: 3077 RVA: 0x00114F98 File Offset: 0x00113198
	public void ShowBallBombEffect(uint LayoutMapInfoID)
	{
		if (this.mapTileModelController != null)
		{
			this.mapTileController.TileBallBombEffect(LayoutMapInfoID);
		}
	}

	// Token: 0x06000C06 RID: 3078 RVA: 0x00114FB4 File Offset: 0x001131B4
	public void Stop()
	{
		base.gameObject.SetActive(false);
		if (this.mapEffectController != null)
		{
			this.mapEffectController.active = false;
		}
	}

	// Token: 0x06000C07 RID: 3079 RVA: 0x00114FDC File Offset: 0x001131DC
	public void Active()
	{
		base.gameObject.SetActive(true);
		if (this.mapEffectController != null)
		{
			this.mapEffectController.active = true;
		}
	}

	// Token: 0x0400278E RID: 10126
	public MapTile mapTileController;

	// Token: 0x0400278F RID: 10127
	public Transform RealmGroup_3DTransform;

	// Token: 0x04002790 RID: 10128
	public FlowLineFactory mapLineController;

	// Token: 0x04002791 RID: 10129
	private RectTransform Canvasrectran;

	// Token: 0x04002792 RID: 10130
	private int TileBaseABKey;

	// Token: 0x04002793 RID: 10131
	private int MapTileGraphicABKey;

	// Token: 0x04002794 RID: 10132
	private float CanvasrectranScale;

	// Token: 0x04002795 RID: 10133
	private MapTileLevel TileLevelController;

	// Token: 0x04002796 RID: 10134
	private MapTileSelect TileSelectController;

	// Token: 0x04002797 RID: 10135
	private MapTileBloodName mapNameController;

	// Token: 0x04002798 RID: 10136
	private MapTileGraphic mapGraphicController;

	// Token: 0x04002799 RID: 10137
	private MapTileNPC mapNPCController;

	// Token: 0x0400279A RID: 10138
	private MapTileYolk TileYolkController;

	// Token: 0x0400279B RID: 10139
	private MapTileEffect mapEffectController;

	// Token: 0x0400279C RID: 10140
	private MapTileModel mapTileModelController;

	// Token: 0x0400279D RID: 10141
	private ushort mapWeaponID;

	// Token: 0x0400279E RID: 10142
	private ushort mapSkillID;

	// Token: 0x0400279F RID: 10143
	private ushort mFootBallID;

	// Token: 0x040027A0 RID: 10144
	private byte mFootBallStr;

	// Token: 0x040027A1 RID: 10145
	private FootBallSkillData tmpSkill;

	// Token: 0x040027A2 RID: 10146
	private FootballManager FM;
}
