using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000293 RID: 659
public class Front : Gameplay
{
	// Token: 0x06000D23 RID: 3363 RVA: 0x00136980 File Offset: 0x00134B80
	~Front()
	{
	}

	// Token: 0x06000D24 RID: 3364 RVA: 0x001369B8 File Offset: 0x00134BB8
	private void iniMapData()
	{
		int num;
		while ((int)this.controlMapPlayerTableID < this.CityPos.Length)
		{
			num = GameConstants.TileMapPosToMapID((int)this.CityPos[(int)this.controlMapPlayerTableID].x, (int)this.CityPos[(int)this.controlMapPlayerTableID].y);
			DataManager.MapDataController.LayoutMapInfo[num].pointKind = 8;
			DataManager.MapDataController.LayoutMapInfo[num].tableID = this.controlMapPlayerTableID;
			DataManager.MapDataController.PlayerPointTable[(int)this.controlMapPlayerTableID].level = this.CityLevel[(int)this.controlMapPlayerTableID];
			DataManager.MapDataController.PlayerPointTable[(int)this.controlMapPlayerTableID].capitalFlag = this.Cityflag[(int)this.controlMapPlayerTableID];
			this.directController.UpdatePoint((uint)num);
			this.controlMapPlayerTableID += 1;
		}
		for (int i = 0; i < this.OtherPos.Length; i++)
		{
			num = GameConstants.TileMapPosToMapID((int)this.OtherPos[i].x, (int)this.OtherPos[i].y);
			DataManager.MapDataController.LayoutMapInfo[num].pointKind = (byte)this.OtherKind[i];
			this.directController.UpdatePoint((uint)num);
		}
		DataManager.Instance.RoleAlliance.Tag.IntToFormat(1L, 1, false);
		DataManager.Instance.RoleAlliance.Tag.IntToFormat(1L, 1, false);
		DataManager.Instance.RoleAlliance.Tag.IntToFormat(1L, 1, false);
		DataManager.Instance.RoleAlliance.Tag.AppendFormat("{0}{1}{2}");
		while (this.controlMapLineTableID < this.LineStartPoint.Length)
		{
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].lineID = 0u;
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].playerName.ClearString();
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].playerName.IntToFormat((long)this.controlMapLineTableID, 1, false);
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].playerName.AppendFormat("{0}");
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].kingdomID = this.KID[this.controlMapLineTableID];
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].allianceTag.ClearString();
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].allianceTag.IntToFormat((long)this.controlMapLineTableID, 1, false);
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].allianceTag.IntToFormat((long)this.controlMapLineTableID, 1, false);
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].allianceTag.IntToFormat((long)this.controlMapLineTableID, 1, false);
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].allianceTag.AppendFormat("{0}{1}{2}");
			GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int)this.LineStartPoint[this.controlMapLineTableID].x, (int)this.LineStartPoint[this.controlMapLineTableID].y), out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].start.zoneID, out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].start.pointID);
			GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int)this.LineEndPoint[this.controlMapLineTableID].x, (int)this.LineEndPoint[this.controlMapLineTableID].y), out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].end.zoneID, out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].end.pointID);
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].during = this.LineDuring[this.controlMapLineTableID];
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].begin = (ulong)(NetworkManager.ServerTime - (double)this.LineDuringEx[this.controlMapLineTableID]);
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].EXbegin = (DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].EXduring = 0u);
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].lineFlag = (byte)this.LineFlag[this.controlMapLineTableID];
			if (this.LineFlag[this.controlMapLineTableID] == EMarchEventType.EMET_AttackRetreat)
			{
				DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].EXduring += 5u;
			}
			this.directController.AddLine(this.controlMapLineTableID, false);
			this.controlMapLineTableID++;
		}
		this.directController.mapTileController.SetFocusGroup(this.checkMapLineTableID, ref this.checklineNode);
		this.directController.mapTileController.SetFocusGroup(this.checkMapLineTableID_EX, ref this.checklineNode_EX);
		this.directController.mapTileController.SetFocusGroup(this.checkMapLineTableID_PLUS, ref this.checklineNode_PLUS);
		num = GameConstants.TileMapPosToMapID((int)this.startPoint.x, (int)this.startPoint.y);
		DataManager.MapDataController.LayoutMapInfo[num].pointKind = 9;
		MapPoint[] layoutMapInfo = DataManager.MapDataController.LayoutMapInfo;
		int num2 = num;
		ushort tableID;
		this.controlMapPlayerTableID = (tableID = this.controlMapPlayerTableID) + 1;
		layoutMapInfo[num2].tableID = tableID;
		num = GameConstants.TileMapPosToMapID((int)this.endPoint.x, (int)this.endPoint.y);
		DataManager.MapDataController.LayoutMapInfo[num].pointKind = 8;
		DataManager.MapDataController.LayoutMapInfo[num].tableID = this.controlMapPlayerTableID;
		DataManager.MapDataController.PlayerPointTable[(int)this.controlMapPlayerTableID].level = 25;
		DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].lineID = 0u;
		DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].playerName.AppendFormat(DataManager.Instance.RoleAttr.Name);
		GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int)this.startPoint.x, (int)this.startPoint.y), out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].start.zoneID, out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].start.pointID);
		GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int)this.endPoint.x, (int)this.endPoint.y), out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].end.zoneID, out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].end.pointID);
		this.frontState = Front.FrontState.Around;
		this.frontFlag |= 1;
		this.frontMove = this.viewStartPoint - this.startPoint;
		this.frontMove.x = this.frontMove.x * 256f;
		this.frontMove.y = this.frontMove.y * -128f;
		this.frontMove /= 28f;
		this.frontFlag |= 4;
	}

	// Token: 0x06000D25 RID: 3365 RVA: 0x0013719C File Offset: 0x0013539C
	protected override void UpdateNews(byte[] meg)
	{
		if (meg[0] == 2)
		{
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].during = 3u;
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].begin = (ulong)NetworkManager.ServerTime;
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].EXbegin = (DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].EXduring = 0u);
			DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].lineFlag = 5;
			this.directController.AddLine(this.controlMapLineTableID, true);
			this.directController.mapTileController.SetFocusGroup(this.controlMapLineTableID, ref this.lineNode);
			this.directController.mapTileController.Movedelta = (this.frontMove = Vector2.zero);
			this.frontFlag |= 16;
			AudioManager.Instance.PlaySFX(this.goSFXID, 0f, PitchKind.NoPitch, null, null);
			this.frontState = Front.FrontState.Go;
		}
		else if (meg[0] == 0 && meg[1] == 35)
		{
			if (this.WordTextFirst != null && this.WordTextFirst.enabled)
			{
				this.WordTextFirst.enabled = false;
				this.WordTextFirst.enabled = true;
			}
			if (this.WordTextSec != null && this.WordTextSec.enabled)
			{
				this.WordTextSec.enabled = false;
				this.WordTextSec.enabled = true;
			}
		}
	}

	// Token: 0x06000D26 RID: 3366 RVA: 0x0013734C File Offset: 0x0013554C
	protected override void UpdateNext(byte[] meg)
	{
		DataManager.MapDataController.zoomSize = 0.75f;
		DataManager.MapDataController.FocusKingdomID = (DataManager.MapDataController.OtherKingdomData.kingdomID = (DataManager.MapDataController.kingdomData.kingdomID = this.oldKingdomID));
		DataManager.MapDataController.kingdomData.kingdomPeriod = this.oldKingdomPeriod;
		DataManager.MapDataController.KVKKingdomID = this.oldKVKKingdomID;
		DataManager.Instance.RoleAlliance.Tag.ClearString();
		if (this.WordTextFirst != null)
		{
			UnityEngine.Object.DestroyObject(this.WordTextFirst.gameObject);
		}
		this.WordTextFirst = null;
		if (this.WordTextSec != null)
		{
			UnityEngine.Object.DestroyObject(this.WordTextSec.gameObject);
		}
		this.WordTextSec = null;
		if (this.cloth != null)
		{
			UnityEngine.Object.DestroyObject(this.cloth.gameObject);
		}
		this.cloth = null;
		if (this.directController != null)
		{
			this.directController.ClearEffect();
			UnityEngine.Object.DestroyObject(this.directController.gameObject);
		}
		this.directController = null;
		this.FrontGroupTransform = null;
		GUIManager.Instance.ClearMapSprite();
		GUIManager.Instance.DestroyTechIconSprite();
		GUIManager.Instance.EmojiManager.Clear();
		ParticleManager.Instance.Clear();
		GUIManager.Instance.m_UICanvas.renderMode = RenderMode.ScreenSpaceOverlay;
		GUIManager.Instance.SetCameraorthOgraphic(false);
	}

	// Token: 0x06000D27 RID: 3367 RVA: 0x001374D0 File Offset: 0x001356D0
	protected override void UpdateLoad(byte[] meg)
	{
		GameManager.RegisterObserver(1, 0, this, 1);
		RenderSettings.ambientLight = GameConstants.DefaultAmbientLight;
		DataManager.Instance.GoToBattleOrWar = GameplayKind.Front;
		this.oldKingdomID = DataManager.MapDataController.kingdomData.kingdomID;
		this.oldKVKKingdomID = DataManager.MapDataController.KVKKingdomID;
		this.oldKingdomPeriod = DataManager.MapDataController.kingdomData.kingdomPeriod;
		DataManager.MapDataController.FocusKingdomID = (DataManager.MapDataController.kingdomData.kingdomID = 1);
		DataManager.MapDataController.OtherKingdomData.kingdomID = (DataManager.MapDataController.KVKKingdomID = 2);
		DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_KVK;
		DataManager.MapDataController.FocusMapID = GameConstants.TileMapPosToMapID((int)this.viewStartPoint.x, (int)this.viewStartPoint.y);
		ParticleManager.Instance.Setup();
		if (Camera.main.fieldOfView != 25f)
		{
			Camera.main.fieldOfView = 25f;
		}
		Camera.main.transform.position = new Vector3(0f, 0f, -16f);
		Camera.main.transform.eulerAngles = new Vector3(0f, 0f, 0f);
		Camera.main.cullingMask |= 1;
		GUIManager.Instance.m_UICanvas.renderMode = RenderMode.ScreenSpaceCamera;
		GUIManager.Instance.SetCameraorthOgraphic(true);
		AudioManager.Instance.LoadAndPlayBGM(BGMType.Newie, 1, false);
		GUIManager.Instance.OpenMenu(EGUIWindow.UI_Front, 0, 0, false, false, false);
		AssetManager.Instance.AssetManagerState = AssetState.Ready;
		NewbieLog.Log(ENewbieLogKind.FORCE_1, 0);
	}

	// Token: 0x06000D28 RID: 3368 RVA: 0x00137680 File Offset: 0x00135880
	protected override void UpdateReady(byte[] meg)
	{
		GameObject gameObject = new GameObject("cloth");
		this.cloth = gameObject.AddComponent<Image>();
		for (int i = 0; i < AssetManager.Instance.Shaders.Length; i++)
		{
			if (AssetManager.Instance.Shaders[i].name == "zTWRD2 Shaders/UI/Sprites")
			{
				this.cloth.material = new Material((Shader)AssetManager.Instance.Shaders[i]);
				this.cloth.material.renderQueue = 3100;
				break;
			}
		}
		this.cloth.color = new Color(0f, 0f, 0f, 1f);
		RectTransform component = gameObject.GetComponent<RectTransform>();
		component.SetParent(GUIManager.Instance.m_FourthWindowLayer, false);
		this.Canvasrectran = (GUIManager.Instance.m_UICanvas.transform as RectTransform);
		component.sizeDelta = this.Canvasrectran.sizeDelta * 1.5f;
		GUIManager.Instance.UpdateUI(EGUIWindow.UI_Front, 0, 0);
		GameObject gameObject2 = new GameObject("FrontGroup");
		gameObject2.AddComponent<IgnoreRaycast>();
		this.FrontGroupTransform = gameObject2.transform;
		this.FrontGroupTransform.SetParent(GUIManager.Instance.m_UICanvas.transform, false);
		this.FrontGroupTransform.SetAsFirstSibling();
		this.directController = gameObject2.GetComponent<Realm>();
		if (this.directController == null)
		{
			this.directController = gameObject2.AddComponent<Realm>();
		}
		this.directController.notSend();
		Transform realmGroup_3DTransform = this.directController.RealmGroup_3DTransform;
		Vector3 localScale = Vector3.one * DataManager.MapDataController.zoomSize;
		this.FrontGroupTransform.localScale = localScale;
		realmGroup_3DTransform.localScale = localScale;
		if (NetworkManager.Connected())
		{
			GUIManager.Instance.HideUILock(EUILock.Network);
		}
		int fontSize = (!GameConstants.IsBigStyle()) ? 48 : 64;
		this.FrontGroupTransform.gameObject.SetActive(false);
		gameObject2 = new GameObject("wordsfst");
		gameObject2.AddComponent<IgnoreRaycast>();
		this.WordTextFirst = gameObject2.AddComponent<UIText>();
		Outline outline = gameObject2.AddComponent<Outline>();
		outline.effectColor = new Color(0.275f, 0.063f, 0f);
		Shadow shadow = gameObject2.AddComponent<Shadow>();
		shadow.effectDistance = new Vector2(2f, -2f);
		this.WordTextFirst.font = GUIManager.Instance.GetTTFFont();
		this.WordTextFirst.fontSize = fontSize;
		this.WordTextFirst.alignment = TextAnchor.LowerCenter;
		this.WordTextFirst.resizeTextForBestFit = false;
		this.WordTextFirst.color = new Color(1f, 1f, 1f, 0f);
		this.WordTextFirst.text = DataManager.Instance.mStringTable.GetStringByID(this.FstWordID[(int)this.nowFirstWordID]);
		this.WordTextFirst.SetAllDirty();
		RectTransform rectTransform = gameObject2.transform as RectTransform;
		rectTransform.sizeDelta = new Vector2(this.Canvasrectran.sizeDelta.x, this.Canvasrectran.sizeDelta.y * 0.5f);
		rectTransform.anchoredPosition = new Vector2(0f, rectTransform.sizeDelta.y * 0.5f);
		rectTransform.SetParent(GUIManager.Instance.m_NewbieLayer, false);
		gameObject2 = new GameObject("wordssec");
		this.WordTextSec = gameObject2.AddComponent<UIText>();
		outline = gameObject2.AddComponent<Outline>();
		outline.effectColor = new Color(0.275f, 0.063f, 0f);
		shadow = gameObject2.AddComponent<Shadow>();
		shadow.effectDistance = new Vector2(2f, -2f);
		this.WordTextSec.font = GUIManager.Instance.GetTTFFont();
		this.WordTextSec.fontSize = fontSize;
		this.WordTextSec.alignment = TextAnchor.UpperCenter;
		this.WordTextSec.resizeTextForBestFit = false;
		this.WordTextSec.color = new Color(1f, 1f, 1f, 0f);
		this.WordTextSec.text = DataManager.Instance.mStringTable.GetStringByID(this.SecWordID[(int)this.nowSecWordID]);
		this.WordTextSec.SetAllDirty();
		rectTransform = (gameObject2.transform as RectTransform);
		rectTransform.sizeDelta = new Vector2(this.Canvasrectran.sizeDelta.x, this.Canvasrectran.sizeDelta.y * 0.5f);
		rectTransform.anchoredPosition = new Vector2(0f, rectTransform.sizeDelta.y * -0.5f);
		rectTransform.SetParent(GUIManager.Instance.m_NewbieLayer, false);
	}

	// Token: 0x06000D29 RID: 3369 RVA: 0x00137B5C File Offset: 0x00135D5C
	protected override void UpdateRun(byte[] meg)
	{
		if ((int)this.nowFirstWordID < this.FstWordID.Length)
		{
			Color color = this.WordTextFirst.color;
			switch (this.FstWordState)
			{
			case Front.FrontFlag.In:
				color.a += Time.deltaTime * this.wordFadInSpeed;
				if (color.a > 0.55f)
				{
					this.SecWordState = Front.FrontFlag.In;
				}
				if (color.a >= 1f)
				{
					color.a = 1f;
					this.FstWordState = Front.FrontFlag.Wait;
				}
				this.WordTextFirst.color = color;
				break;
			case Front.FrontFlag.Out:
				color.a -= Time.deltaTime * this.wordFadOutSpeed;
				if (color.a <= 0f)
				{
					color.a = 0f;
					this.FstWordState = Front.FrontFlag.Zoom;
					this.nowFirstWordID += 1;
					if ((int)this.nowFirstWordID < this.FstWordID.Length)
					{
						this.WordTextFirst.text = DataManager.Instance.mStringTable.GetStringByID(this.FstWordID[(int)this.nowFirstWordID]);
						this.WordTextFirst.SetAllDirty();
					}
				}
				this.WordTextFirst.color = color;
				break;
			case Front.FrontFlag.Wait:
				this.FirstWordStayTime -= Time.deltaTime;
				if (this.FirstWordStayTime <= 0f)
				{
					this.FirstWordStayTime = this.FirstWordStayTimeMax;
					this.FstWordState = Front.FrontFlag.Out;
				}
				break;
			case Front.FrontFlag.Delay:
				if ((double)this.cloth.color.a <= 0.6)
				{
					this.FstWordState = Front.FrontFlag.In;
				}
				break;
			}
		}
		if ((int)this.nowSecWordID < this.SecWordID.Length)
		{
			Color color2 = this.WordTextSec.color;
			switch (this.SecWordState)
			{
			case Front.FrontFlag.In:
				color2.a += Time.deltaTime * this.wordFadInSpeed;
				if (color2.a >= 1f)
				{
					color2.a = 1f;
					this.SecWordState = Front.FrontFlag.Wait;
				}
				this.WordTextSec.color = color2;
				break;
			case Front.FrontFlag.Out:
				color2.a -= Time.deltaTime * this.wordFadOutSpeed;
				if (color2.a <= 0.1f)
				{
					this.FstWordState = Front.FrontFlag.In;
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Front, 6, 0);
				}
				else
				{
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Front, 7, 0);
				}
				if (color2.a <= 0f)
				{
					color2.a = 0f;
					this.SecWordState = Front.FrontFlag.Zoom;
					this.nowSecWordID += 1;
					if ((int)this.nowSecWordID < this.SecWordID.Length)
					{
						this.WordTextSec.text = DataManager.Instance.mStringTable.GetStringByID(this.SecWordID[(int)this.nowSecWordID]);
						this.WordTextSec.SetAllDirty();
					}
					else
					{
						this.ClothState = Front.FrontFlag.In;
					}
				}
				this.WordTextSec.color = color2;
				break;
			case Front.FrontFlag.Wait:
				this.SecWordStayTime -= Time.deltaTime;
				if (this.SecWordStayTime <= 0f)
				{
					this.SecWordStayTime = this.SecWordStayTimeMax;
					this.SecWordState = Front.FrontFlag.Out;
				}
				break;
			}
		}
		Color color3 = this.cloth.color;
		switch (this.ClothState)
		{
		case Front.FrontFlag.In:
			if (this.delay > 0f)
			{
				this.delay -= Time.deltaTime;
			}
			else
			{
				color3.a += Time.deltaTime * this.wordFadOutSpeed * 1.2f;
				if (color3.a >= 1f)
				{
					color3.a = 1f;
					this.ClothState = Front.FrontFlag.Move;
					this.FrontGroupTransform.gameObject.SetActive(true);
					this.iniMapData();
					GUIManager.Instance.UpdateUI(EGUIWindow.UI_Front, 1, 0);
				}
			}
			break;
		case Front.FrontFlag.Out:
			color3.a -= Time.deltaTime * this.wordFadOutSpeed * 0.4f;
			if (color3.a <= 0f)
			{
				color3.a = 0f;
				color3.r = 1f;
				color3.g = 0.914f;
				color3.b = 0.408f;
				this.ClothState = Front.FrontFlag.Wait;
			}
			break;
		case Front.FrontFlag.Move:
			color3.a -= Time.deltaTime * this.wordFadOutSpeed * 2f;
			if (color3.a <= 0f)
			{
				color3.a = 0f;
				this.ClothState = Front.FrontFlag.Wait;
			}
			break;
		}
		this.cloth.color = color3;
		if ((this.frontFlag & 32) != 0)
		{
			this.FrontGroupTransform.localScale += Vector3.one * Time.deltaTime * this.frontZoomSpeed;
			this.directController.RealmGroup_3DTransform.localScale = this.FrontGroupTransform.localScale;
			DataManager.MapDataController.zoomSize = this.FrontGroupTransform.localScale.x;
			this.directController.mapTileController.Check3DPos();
		}
		if ((this.frontFlag & 4) != 0)
		{
			this.directController.mapTileController.Movedelta = this.frontMove * Time.deltaTime * DataManager.MapDataController.zoomSize;
		}
		if ((this.frontFlag & 1) != 0)
		{
			this.frontFlag &= -2;
			Front.FrontState frontState = this.frontState;
			if (frontState == Front.FrontState.Around)
			{
				this.frontWaitTime = 8f;
				this.frontFlag |= 8;
			}
		}
		if ((this.frontFlag & 2) != 0 && this.cloth.color.a < 1f)
		{
			Color color4 = this.cloth.color;
			color4.a += Time.deltaTime * this.frontFadeSpeed;
			if (color4.a >= 1f)
			{
				color4.a = 1f;
				this.frontFlag &= -3;
				Front.FrontState frontState = this.frontState;
				if (frontState == Front.FrontState.Around)
				{
					this.directController.mapTileController.MovebyTileMapPos((int)this.startPoint.x, (int)this.startPoint.y, false);
					this.directController.mapTileController.Movedelta = (this.frontMove = Vector2.zero);
					this.frontFlag &= -5;
					this.frontFlag |= 1;
					this.frontZoomSpeed = 0.25f;
					this.frontFlag |= 32;
					this.frontState = Front.FrontState.Speak;
				}
			}
			this.cloth.color = color4;
		}
		if ((this.frontFlag & 8) != 0 && this.frontWaitTime > 0f)
		{
			this.frontWaitTime -= Time.deltaTime;
			if (this.frontWaitTime <= 0f)
			{
				this.frontWaitTime = 0f;
				this.frontFlag &= -9;
				switch (this.frontState)
				{
				case Front.FrontState.Around:
					if ((this.frontFlag & 32) != 0)
					{
						this.frontWaitTime = 0.1f;
						this.frontFlag |= 8;
						this.directController.mapTileController.MovebyTileMapPos((int)this.startPoint.x, (int)this.startPoint.y, false);
						this.directController.mapTileController.Movedelta = (this.frontMove = Vector2.zero);
						this.frontFlag &= -5;
						DataManager.MapDataController.zoomSize = 0.9503304f;
						this.frontZoomSpeed = 0f;
						this.frontFlag &= -33;
						this.frontState = Front.FrontState.Speak;
					}
					else
					{
						this.frontMove *= 3.35f;
						this.frontWaitTime = 1.6f;
						this.frontFlag |= 8;
						this.frontZoomSpeed = 0.125f;
						this.frontFlag |= 32;
					}
					break;
				case Front.FrontState.Go:
					this.frontState = Front.FrontState.Ready;
					this.frontZoomSpeed = 3.25f;
					this.frontFlag |= 32;
					this.frontWaitTime = 1E-05f;
					this.frontFlag |= 8;
					break;
				case Front.FrontState.Speak:
					GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, 12, 1);
					NewbieLog.Log(ENewbieLogKind.FORCE_1, 1);
					break;
				case Front.FrontState.Ready:
					AudioManager.Instance.PlayMP3SFX(this.readySFXID, 0f);
					WarManager.SetupNewbieWar();
					GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MapToWar);
					break;
				}
			}
		}
		if ((this.frontFlag & 16) != 0)
		{
			if (this.lineNode.timeOffset * this.lineNode.inverseMaxTime > 1f)
			{
				this.directController.mapTileController.MovebyTileMapPos((int)this.endPoint.x, (int)this.endPoint.y, false);
				this.directController.mapTileController.Movedelta = (this.frontMove = Vector2.zero);
				this.frontFlag &= -17;
				this.frontWaitTime = 1.5f;
				this.frontFlag |= 8;
				this.directController.DelLine(this.controlMapLineTableID, 1, 0);
				DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].MapLineInit();
				DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].lineID = 0u;
				DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].playerName.AppendFormat(DataManager.Instance.RoleAttr.Name);
				DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].lineFlag = 23;
				GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int)this.endPoint.x, (int)this.endPoint.y), out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].start.zoneID, out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].start.pointID);
				GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int)this.startPoint.x, (int)this.startPoint.y), out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].end.zoneID, out DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].end.pointID);
				DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].during = 5u;
				DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].begin = (ulong)NetworkManager.ServerTime;
				DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].EXbegin = (DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].EXduring = 0u);
				DataManager.MapDataController.MapLineTable[this.controlMapLineTableID].lineFlag = 23;
				this.directController.AddLine(this.controlMapLineTableID, true);
				PlayerPoint[] playerPointTable = DataManager.MapDataController.PlayerPointTable;
				ushort num = this.controlMapPlayerTableID;
				playerPointTable[(int)num].capitalFlag = (playerPointTable[(int)num].capitalFlag | 2);
				this.directController.UpdatePoint((uint)GameConstants.TileMapPosToMapID((int)this.endPoint.x, (int)this.endPoint.y));
			}
			else
			{
				this.directController.mapTileController.Movedelta = new Vector2(this.lineNode.movingNode.position.x, this.lineNode.movingNode.position.y);
				this.directController.mapTileController.Movedelta /= -this.Canvasrectran.localScale.x;
			}
		}
		if (this.checklineNode != null && this.checklineNode.timeOffset * this.checklineNode.inverseMaxTime > 1f)
		{
			this.directController.DelLine(this.checkMapLineTableID, 1, 0);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].MapLineInit();
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].lineID = 0u;
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].playerName.ClearString();
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].playerName.IntToFormat((long)this.checkMapLineTableID, 1, false);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].playerName.AppendFormat("{0}");
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].kingdomID = this.KID[this.checkMapLineTableID];
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].allianceTag.ClearString();
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].allianceTag.IntToFormat((long)this.checkMapLineTableID, 1, false);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].allianceTag.IntToFormat((long)this.checkMapLineTableID, 1, false);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].allianceTag.IntToFormat((long)this.checkMapLineTableID, 1, false);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].allianceTag.AppendFormat("{0}{1}{2}");
			GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int)this.LineEndPoint[this.checkMapLineTableID].x, (int)this.LineEndPoint[this.checkMapLineTableID].y), out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].start.zoneID, out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].start.pointID);
			GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int)this.LineStartPoint[this.checkMapLineTableID].x, (int)this.LineStartPoint[this.checkMapLineTableID].y), out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].end.zoneID, out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].end.pointID);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].during = this.LineDuring[this.checkMapLineTableID];
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].begin = (ulong)NetworkManager.ServerTime;
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].EXbegin = (DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].EXduring = 0u);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].lineFlag = 23;
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID].EXduring += 5u;
			this.directController.AddLine(this.checkMapLineTableID, false);
			this.checklineNode = null;
		}
		if (this.checklineNode_EX != null && this.checklineNode_EX.timeOffset * this.checklineNode_EX.inverseMaxTime > 1f)
		{
			this.directController.DelLine(this.checkMapLineTableID_EX, 1, 0);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].MapLineInit();
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].lineID = 0u;
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].playerName.ClearString();
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].playerName.IntToFormat((long)this.checkMapLineTableID_EX, 1, false);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].playerName.AppendFormat("{0}");
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].kingdomID = this.KID[this.checkMapLineTableID_EX];
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].allianceTag.ClearString();
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].allianceTag.IntToFormat((long)this.checkMapLineTableID_EX, 1, false);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].allianceTag.IntToFormat((long)this.checkMapLineTableID_EX, 1, false);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].allianceTag.IntToFormat((long)this.checkMapLineTableID_EX, 1, false);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].allianceTag.AppendFormat("{0}{1}{2}");
			GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int)this.LineEndPoint[this.checkMapLineTableID_EX].x, (int)this.LineEndPoint[this.checkMapLineTableID_EX].y), out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].start.zoneID, out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].start.pointID);
			GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int)this.LineStartPoint[this.checkMapLineTableID_EX].x, (int)this.LineStartPoint[this.checkMapLineTableID_EX].y), out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].end.zoneID, out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].end.pointID);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].during = this.LineDuring[this.checkMapLineTableID_EX];
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].begin = (ulong)NetworkManager.ServerTime;
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].EXbegin = (DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].EXduring = 0u);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_EX].lineFlag = 18;
			this.directController.AddLine(this.checkMapLineTableID_EX, false);
			this.checklineNode_EX = null;
		}
		if (this.checklineNode_PLUS != null && this.checklineNode_PLUS.timeOffset * this.checklineNode_PLUS.inverseMaxTime > 1f)
		{
			this.directController.DelLine(this.checkMapLineTableID_PLUS, 1, 0);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].MapLineInit();
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].lineID = 0u;
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].playerName.ClearString();
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].playerName.IntToFormat((long)this.checkMapLineTableID_PLUS, 1, false);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].playerName.AppendFormat("{0}");
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].kingdomID = this.KID[this.checkMapLineTableID_PLUS];
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].allianceTag.ClearString();
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].allianceTag.IntToFormat((long)this.checkMapLineTableID_PLUS, 1, false);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].allianceTag.IntToFormat((long)this.checkMapLineTableID_PLUS, 1, false);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].allianceTag.IntToFormat((long)this.checkMapLineTableID_PLUS, 1, false);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].allianceTag.AppendFormat("{0}{1}{2}");
			GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int)this.LineEndPoint[this.checkMapLineTableID_PLUS].x, (int)this.LineEndPoint[this.checkMapLineTableID_PLUS].y), out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].start.zoneID, out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].start.pointID);
			GameConstants.MapIDToPointCode(GameConstants.TileMapPosToMapID((int)this.LineStartPoint[this.checkMapLineTableID_PLUS].x, (int)this.LineStartPoint[this.checkMapLineTableID_PLUS].y), out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].end.zoneID, out DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].end.pointID);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].during = this.LineDuring[this.checkMapLineTableID_PLUS];
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].begin = (ulong)NetworkManager.ServerTime;
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].EXbegin = (DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].EXduring = 0u);
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].lineFlag = 23;
			DataManager.MapDataController.MapLineTable[this.checkMapLineTableID_PLUS].EXduring += 5u;
			this.directController.AddLine(this.checkMapLineTableID_PLUS, false);
			this.checklineNode_PLUS = null;
		}
	}

	// Token: 0x04002A7A RID: 10874
	private int controlMapLineTableID;

	// Token: 0x04002A7B RID: 10875
	private int checkMapLineTableID = 1;

	// Token: 0x04002A7C RID: 10876
	private int checkMapLineTableID_EX = 3;

	// Token: 0x04002A7D RID: 10877
	private int checkMapLineTableID_PLUS;

	// Token: 0x04002A7E RID: 10878
	private float frontWaitTime;

	// Token: 0x04002A7F RID: 10879
	private float frontFadeSpeed = 1.5f;

	// Token: 0x04002A80 RID: 10880
	private float frontZoomSpeed = 4f;

	// Token: 0x04002A81 RID: 10881
	private ushort oldKingdomID;

	// Token: 0x04002A82 RID: 10882
	private ushort oldKVKKingdomID;

	// Token: 0x04002A83 RID: 10883
	private KINGDOM_PERIOD oldKingdomPeriod;

	// Token: 0x04002A84 RID: 10884
	private ushort readySFXID = 41025;

	// Token: 0x04002A85 RID: 10885
	private ushort goSFXID = 40016;

	// Token: 0x04002A86 RID: 10886
	private ushort controlMapPlayerTableID;

	// Token: 0x04002A87 RID: 10887
	private Vector2 frontMove = Vector2.zero;

	// Token: 0x04002A88 RID: 10888
	private Vector2 viewStartPoint = new Vector2(218f, 108f);

	// Token: 0x04002A89 RID: 10889
	private Vector2 startPoint = new Vector2(204f, 88f);

	// Token: 0x04002A8A RID: 10890
	private Vector2 endPoint = new Vector2(206f, 86f);

	// Token: 0x04002A8B RID: 10891
	private Vector2 dis = Vector2.zero;

	// Token: 0x04002A8C RID: 10892
	private Realm directController;

	// Token: 0x04002A8D RID: 10893
	private Transform FrontGroupTransform;

	// Token: 0x04002A8E RID: 10894
	private RectTransform Canvasrectran;

	// Token: 0x04002A8F RID: 10895
	private Image cloth;

	// Token: 0x04002A90 RID: 10896
	private LineNode lineNode;

	// Token: 0x04002A91 RID: 10897
	private LineNode checklineNode;

	// Token: 0x04002A92 RID: 10898
	private LineNode checklineNode_EX;

	// Token: 0x04002A93 RID: 10899
	private LineNode checklineNode_PLUS;

	// Token: 0x04002A94 RID: 10900
	private UIText WordTextFirst;

	// Token: 0x04002A95 RID: 10901
	private UIText WordTextSec;

	// Token: 0x04002A96 RID: 10902
	private float wordFadInSpeed = 0.5f;

	// Token: 0x04002A97 RID: 10903
	private float wordFadOutSpeed = 1f;

	// Token: 0x04002A98 RID: 10904
	private byte nowFirstWordID;

	// Token: 0x04002A99 RID: 10905
	private byte nowSecWordID;

	// Token: 0x04002A9A RID: 10906
	private float FirstWordStayTimeMax = 2.725f;

	// Token: 0x04002A9B RID: 10907
	private float FirstWordStayTime = 2.725f;

	// Token: 0x04002A9C RID: 10908
	private float SecWordStayTimeMax = 1.9f;

	// Token: 0x04002A9D RID: 10909
	private float SecWordStayTime = 1.9f;

	// Token: 0x04002A9E RID: 10910
	private int frontFlag;

	// Token: 0x04002A9F RID: 10911
	private float delay = 1f;

	// Token: 0x04002AA0 RID: 10912
	private Front.FrontFlag FstWordState = Front.FrontFlag.Delay;

	// Token: 0x04002AA1 RID: 10913
	private Front.FrontFlag SecWordState = Front.FrontFlag.Zoom;

	// Token: 0x04002AA2 RID: 10914
	private Front.FrontFlag ClothState = Front.FrontFlag.Out;

	// Token: 0x04002AA3 RID: 10915
	private Front.FrontState frontState;

	// Token: 0x04002AA4 RID: 10916
	private Vector2[] CityPos = new Vector2[]
	{
		new Vector2(214f, 106f),
		new Vector2(211f, 99f),
		new Vector2(210f, 96f),
		new Vector2(210f, 102f),
		new Vector2(207f, 101f),
		new Vector2(218f, 100f),
		new Vector2(218f, 108f),
		new Vector2(215f, 101f),
		new Vector2(212f, 98f),
		new Vector2(210f, 100f),
		new Vector2(203f, 93f),
		new Vector2(209f, 95f),
		new Vector2(216f, 100f),
		new Vector2(214f, 104f),
		new Vector2(213f, 101f),
		new Vector2(211f, 103f),
		new Vector2(209f, 103f),
		new Vector2(215f, 99f),
		new Vector2(212f, 100f),
		new Vector2(209f, 97f),
		new Vector2(201f, 85f),
		new Vector2(216f, 102f),
		new Vector2(212f, 94f)
	};

	// Token: 0x04002AA5 RID: 10917
	private byte[] CityLevel = new byte[]
	{
		10,
		18,
		1,
		10,
		18,
		1,
		10,
		10,
		1,
		10,
		1,
		10,
		10,
		25,
		18,
		25,
		10,
		18,
		25,
		25,
		1,
		18,
		18
	};

	// Token: 0x04002AA6 RID: 10918
	private byte[] Cityflag = new byte[]
	{
		2,
		2,
		2,
		2,
		2,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		4,
		4
	};

	// Token: 0x04002AA7 RID: 10919
	private Vector2[] OtherPos = new Vector2[]
	{
		new Vector2(215f, 105f),
		new Vector2(211f, 107f),
		new Vector2(205f, 85f),
		new Vector2(207f, 89f)
	};

	// Token: 0x04002AA8 RID: 10920
	private POINT_KIND[] OtherKind = new POINT_KIND[]
	{
		POINT_KIND.PK_CAMP,
		POINT_KIND.PK_STONE,
		POINT_KIND.PK_WOOD,
		POINT_KIND.PK_GOLD
	};

	// Token: 0x04002AA9 RID: 10921
	private Vector2[] LineStartPoint = new Vector2[]
	{
		new Vector2(211f, 103f),
		new Vector2(209f, 95f),
		new Vector2(210f, 102f),
		new Vector2(218f, 108f),
		new Vector2(213f, 101f),
		new Vector2(209f, 103f),
		new Vector2(212f, 100f),
		new Vector2(209f, 97f),
		new Vector2(212f, 94f)
	};

	// Token: 0x04002AAA RID: 10922
	private Vector2[] LineEndPoint = new Vector2[]
	{
		new Vector2(211f, 99f),
		new Vector2(210f, 96f),
		new Vector2(210f, 96f),
		new Vector2(213f, 101f),
		new Vector2(211f, 103f),
		new Vector2(211f, 107f),
		new Vector2(216f, 100f),
		new Vector2(207f, 101f),
		new Vector2(212f, 98f)
	};

	// Token: 0x04002AAB RID: 10923
	private uint[] LineDuring = new uint[]
	{
		18u,
		43u,
		40u,
		10u,
		24u,
		18u,
		18u,
		18u,
		18u
	};

	// Token: 0x04002AAC RID: 10924
	private float[] LineDuringEx = new float[]
	{
		14f,
		38f,
		0f,
		2f,
		7f,
		7f,
		7f,
		2f,
		3f
	};

	// Token: 0x04002AAD RID: 10925
	private EMarchEventType[] LineFlag = new EMarchEventType[]
	{
		EMarchEventType.EMET_AttackMarching,
		EMarchEventType.EMET_AttackMarching,
		EMarchEventType.EMET_AttackRetreat,
		EMarchEventType.EMET_ScoutMarching,
		EMarchEventType.EMET_AttackMarching,
		EMarchEventType.EMET_GatherMarching,
		EMarchEventType.EMET_AttackMarching,
		EMarchEventType.EMET_LordReturn,
		EMarchEventType.EMET_HitMonsterMarching
	};

	// Token: 0x04002AAE RID: 10926
	private ushort[] KID = new ushort[]
	{
		2,
		2,
		2,
		2,
		1,
		1,
		2,
		1,
		1
	};

	// Token: 0x04002AAF RID: 10927
	private uint[] FstWordID = new uint[]
	{
		7971u,
		7973u,
		7975u
	};

	// Token: 0x04002AB0 RID: 10928
	private uint[] SecWordID = new uint[]
	{
		7972u,
		7974u,
		7976u
	};

	// Token: 0x02000294 RID: 660
	private enum FrontFlag : byte
	{
		// Token: 0x04002AB2 RID: 10930
		In,
		// Token: 0x04002AB3 RID: 10931
		Out,
		// Token: 0x04002AB4 RID: 10932
		Move,
		// Token: 0x04002AB5 RID: 10933
		Wait,
		// Token: 0x04002AB6 RID: 10934
		Follow,
		// Token: 0x04002AB7 RID: 10935
		Zoom,
		// Token: 0x04002AB8 RID: 10936
		Delay
	}

	// Token: 0x02000295 RID: 661
	private enum FrontState : byte
	{
		// Token: 0x04002ABA RID: 10938
		Word,
		// Token: 0x04002ABB RID: 10939
		Around,
		// Token: 0x04002ABC RID: 10940
		Go,
		// Token: 0x04002ABD RID: 10941
		Speak,
		// Token: 0x04002ABE RID: 10942
		Ready,
		// Token: 0x04002ABF RID: 10943
		Count
	}
}
