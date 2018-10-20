using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000272 RID: 626
public class MapTileSelect
{
	// Token: 0x06000BB3 RID: 2995 RVA: 0x0010E70C File Offset: 0x0010C90C
	public MapTileSelect(Transform realmGroup, UISpritesArray tileSprites)
	{
		if (this.FBSABKey == 0)
		{
			this.FBSAB = AssetManager.GetAssetBundle("UI/FootBallSprites", out this.FBSABKey, false);
			this.mFBS = (UnityEngine.Object.Instantiate(this.FBSAB.mainAsset) as GameObject);
			this.FBSprites = this.mFBS.GetComponent<UISpritesArray>();
			Image component = this.mFBS.GetComponent<Image>();
			this.mFootBall[0] = new Vector2(0f, 128f);
			this.mFootBall[1] = new Vector2(128f, 64f);
			this.mFootBall[2] = new Vector2(256f, 0f);
			this.mFootBall[3] = new Vector2(128f, -64f);
			this.mFootBall[4] = new Vector2(0f, -128f);
			this.mFootBall[5] = new Vector2(-128f, -64f);
			this.mFootBall[6] = new Vector2(-256f, 0f);
			this.mFootBall[7] = new Vector2(-128f, 64f);
			this.FootBallGameObject = new GameObject("MapFootBall");
			this.FootBallT = this.FootBallGameObject.AddComponent<RectTransform>();
			this.FootBallT.position = Vector3.forward * 3840f;
			this.FootBallT.SetParent(realmGroup, false);
			this.FootBallT.sizeDelta = new Vector2(256f, 128f);
			this.FootBallT.anchoredPosition = Vector2.zero;
			this.FootBallGameObject.SetActive(false);
			for (int i = 0; i < 4; i++)
			{
				this.mGO_FBBG[i] = new GameObject("FBBG");
				this.mRT_FBBG[i] = this.mGO_FBBG[i].AddComponent<RectTransform>();
				this.mRT_FBBG[i].position = Vector3.zero;
				this.mRT_FBBG[i].SetParent(this.FootBallT, false);
				this.mRT_FBBG[i].sizeDelta = new Vector2(384f, 192f);
				this.mImg_FBBG[i] = this.mGO_FBBG[i].AddComponent<Image>();
				this.mImg_FBBG[i].sprite = this.FBSprites.m_Sprites[0];
				this.mImg_FBBG[i].material = component.material;
				this.mGO_FBBG[i].SetActive(false);
			}
			this.mRT_FBBG[0].anchoredPosition = new Vector2(-this.mRT_FBBG[0].sizeDelta.x / 2f, this.mRT_FBBG[0].sizeDelta.y / 2f);
			this.mRT_FBBG[1].anchoredPosition = new Vector2(this.mRT_FBBG[0].sizeDelta.x / 2f, this.mRT_FBBG[0].sizeDelta.y / 2f);
			this.mRT_FBBG[1].localScale = new Vector3(-1f, 1f, 1f);
			this.mRT_FBBG[2].anchoredPosition = new Vector2(-this.mRT_FBBG[0].sizeDelta.x / 2f, -this.mRT_FBBG[0].sizeDelta.y / 2f);
			this.mRT_FBBG[2].localScale = new Vector3(1f, -1f, 1f);
			this.mRT_FBBG[3].anchoredPosition = new Vector2(this.mRT_FBBG[0].sizeDelta.x / 2f, -this.mRT_FBBG[0].sizeDelta.y / 2f);
			this.mRT_FBBG[3].localScale = new Vector3(-1f, -1f, 1f);
			for (int j = 0; j < 8; j++)
			{
				this.mGO_FBBGD[j] = new GameObject("mGO_FBBGD");
				this.mRT_FBBGD[j] = this.mGO_FBBGD[j].AddComponent<RectTransform>();
				this.mRT_FBBGD[j].position = Vector3.zero;
				this.mRT_FBBGD[j].SetParent(this.FootBallT, false);
				this.mRT_FBBGD[j].sizeDelta = new Vector2(256f, 128f);
				this.mRT_FBBGD[j].anchoredPosition = this.mFootBall[j];
				this.mImg_FBBGD[j] = this.mGO_FBBGD[j].AddComponent<Image>();
				this.mImg_FBBGD[j].material = component.material;
				this.mGO_FBBGD[j].SetActive(false);
			}
			this.mImg_FBBGD[0].sprite = this.FBSprites.m_Sprites[3];
			this.mImg_FBBGD[1].sprite = this.FBSprites.m_Sprites[2];
			this.mRT_FBBGD[1].localScale = new Vector3(-1f, 1f, 1f);
			this.mImg_FBBGD[2].sprite = this.FBSprites.m_Sprites[1];
			this.mRT_FBBGD[2].localScale = new Vector3(-1f, 1f, 1f);
			this.mImg_FBBGD[3].sprite = this.FBSprites.m_Sprites[2];
			this.mRT_FBBGD[3].localScale = new Vector3(-1f, -1f, 1f);
			this.mImg_FBBGD[4].sprite = this.FBSprites.m_Sprites[3];
			this.mRT_FBBGD[4].localScale = new Vector3(1f, -1f, 1f);
			this.mImg_FBBGD[5].sprite = this.FBSprites.m_Sprites[2];
			this.mRT_FBBGD[5].localScale = new Vector3(1f, -1f, 1f);
			this.mImg_FBBGD[6].sprite = this.FBSprites.m_Sprites[1];
			this.mImg_FBBGD[7].sprite = this.FBSprites.m_Sprites[2];
			this.FootBallSkillGameObject = new GameObject("MapFootBallSkill");
			this.FootBallSkillT = this.FootBallSkillGameObject.AddComponent<RectTransform>();
			this.FootBallSkillT.position = Vector3.forward * 3840f;
			this.FootBallSkillT.SetParent(realmGroup, false);
			this.FootBallSkillT.sizeDelta = new Vector2(256f, 128f);
			this.FootBallSkillT.anchoredPosition = Vector2.zero;
			this.FootBallSkillGameObject.SetActive(false);
			for (int k = 0; k < 15; k++)
			{
				this.mGO_FBSkill[k] = new GameObject("FBSkill");
				this.mRT_FBSkill[k] = this.mGO_FBSkill[k].AddComponent<RectTransform>();
				this.mRT_FBSkill[k].position = Vector3.zero;
				this.mRT_FBSkill[k].SetParent(this.FootBallSkillT, false);
				this.mRT_FBSkill[k].sizeDelta = new Vector2(242f, 121f);
				this.mRT_FBSkill[k].anchoredPosition = Vector2.zero;
				this.mImg_FBSkill[k] = this.mGO_FBSkill[k].AddComponent<Image>();
				this.mImg_FBSkill[k].sprite = this.FBSprites.m_Sprites[4];
				this.mImg_FBSkill[k].material = component.material;
				this.mGO_FBSkill[k].SetActive(false);
			}
		}
		GameObject gameObject = new GameObject("MapTileSelect");
		this.TileSelect = gameObject.AddComponent<RectTransform>();
		this.TileSelect.position = Vector3.forward * 3840f;
		this.TileSelect.SetParent(realmGroup, false);
		this.TileSelect.sizeDelta = new Vector2(256f, 128f);
		this.TileSelect.anchoredPosition = Vector2.zero;
		this.TileSelectImage = gameObject.AddComponent<Image>();
		this.TileSelectImage.sprite = tileSprites.GetSprite(138);
		this.TileSelectImage.material = tileSprites.m_Image.material;
		gameObject.SetActive(false);
		this.TileMarkGameObject = new GameObject("MapTileMark");
		this.TileMark = this.TileMarkGameObject.AddComponent<RectTransform>();
		this.TileMark.position = Vector3.forward * 3712f;
		this.TileMark.SetParent(realmGroup, false);
		this.TileMark.sizeDelta = new Vector2(256f, 128f);
		this.TileMark.anchoredPosition = Vector2.zero;
		this.TileMarkImage = this.TileMarkGameObject.AddComponent<Image>();
		this.TileMarkImage.sprite = tileSprites.GetSprite(150);
		this.TileMarkImage.material = tileSprites.m_Image.material;
		this.TileMarkImage.color = Color.white;
		this.TileMarkImage.SetNativeSize();
		this.TileMarkGameObject.SetActive(false);
	}

	// Token: 0x06000BB4 RID: 2996 RVA: 0x0010F110 File Offset: 0x0010D310
	public void OnDestroy()
	{
		if (this.TileSelectImage != null)
		{
			this.TileSelectImage = null;
		}
		if (this.TileMarkImage != null)
		{
			this.TileMarkImage = null;
		}
		if (this.TileSelect != null)
		{
			UnityEngine.Object.Destroy(this.TileSelect);
		}
		this.TileSelect = null;
		if (this.TileMark != null)
		{
			UnityEngine.Object.Destroy(this.TileMarkGameObject);
		}
		this.TileMark = null;
		this.TileMarkGameObject = null;
		for (int i = 0; i < 4; i++)
		{
			if (this.mImg_FBBG[i] != null)
			{
				this.mImg_FBBG[i] = null;
			}
			if (this.mRT_FBBG[i] != null)
			{
				UnityEngine.Object.Destroy(this.mGO_FBBG[i]);
			}
			this.mRT_FBBG[i] = null;
			this.mGO_FBBG[i] = null;
		}
		for (int j = 0; j < 8; j++)
		{
			if (this.mImg_FBBGD[j] != null)
			{
				this.mImg_FBBGD[j] = null;
			}
			if (this.mRT_FBBGD[j] != null)
			{
				UnityEngine.Object.Destroy(this.mGO_FBBGD[j]);
			}
			this.mRT_FBBGD[j] = null;
			this.mGO_FBBGD[j] = null;
		}
		for (int k = 0; k < 15; k++)
		{
			if (this.mImg_FBSkill[k] != null)
			{
				this.mImg_FBSkill[k] = null;
			}
			if (this.mRT_FBSkill[k] != null)
			{
				UnityEngine.Object.Destroy(this.mGO_FBSkill[k]);
			}
			this.mRT_FBSkill[k] = null;
			this.mGO_FBSkill[k] = null;
		}
		if (this.FootBallT != null)
		{
			UnityEngine.Object.Destroy(this.FootBallGameObject);
		}
		this.FootBallT = null;
		this.FootBallGameObject = null;
		if (this.FootBallSkillT != null)
		{
			UnityEngine.Object.Destroy(this.FootBallSkillGameObject);
		}
		this.FootBallSkillT = null;
		this.FootBallSkillGameObject = null;
		this.mFBS = null;
		AssetManager.UnloadAssetBundle(this.FBSABKey, true);
		if (this.FBSprites != null)
		{
			UnityEngine.Object.Destroy(this.FBSprites.gameObject);
		}
		this.FBSprites = null;
	}

	// Token: 0x06000BB5 RID: 2997 RVA: 0x0010F34C File Offset: 0x0010D54C
	public void SelectUpdate()
	{
		if (this.TileSelectColor.a != 0f)
		{
			float num = Time.deltaTime * this.TileSelectStart;
			this.TileSelectColor.a = this.TileSelectColor.a + num;
			if (this.TileSelectColor.a > 1f)
			{
				this.TileSelectColor.a = 1f;
				this.TileSelectStart = -1f;
			}
			if (this.TileSelectColor.a < 0.3f)
			{
				this.TileSelectColor.a = 0.3f;
				this.TileSelectStart = 1f;
			}
			this.TileSelectImage.color = this.TileSelectColor;
			if (this.TileMarkGameObject.activeSelf)
			{
				num = Time.deltaTime * this.TileMarkSpeed;
				this.TileMark.anchoredPosition += Vector2.up * num;
				if (this.TileMark.anchoredPosition.y > this.TileMarkPosY + 43f)
				{
					Vector2 anchoredPosition = this.TileMark.anchoredPosition;
					anchoredPosition.y = this.TileMarkPosY + 43f;
					this.TileMark.anchoredPosition = anchoredPosition;
					this.TileMarkSpeed *= -1f;
				}
				if (this.TileMark.anchoredPosition.y < this.TileMarkPosY)
				{
					Vector2 anchoredPosition2 = this.TileMark.anchoredPosition;
					anchoredPosition2.y = this.TileMarkPosY;
					this.TileMark.anchoredPosition = anchoredPosition2;
					this.TileMarkSpeed *= -1f;
				}
			}
		}
	}

	// Token: 0x06000BB6 RID: 2998 RVA: 0x0010F4F8 File Offset: 0x0010D6F8
	public void OnSelect(Vector2 TileAnchoredPosition, bool big = false, byte markID = 0)
	{
		this.TileSelectStart = 1f;
		this.TileSelectColor.a = 0.3f;
		this.TileSelectImage.color = this.TileSelectColor;
		if (big)
		{
			TileAnchoredPosition.y += 64f;
			this.TileSelect.localScale = Vector3.one * 2f;
		}
		else
		{
			this.TileSelect.localScale = Vector3.one;
		}
		this.TileSelect.anchoredPosition = TileAnchoredPosition;
		this.TileSelect.gameObject.SetActive(true);
		this.TileMarkGameObject.SetActive(false);
	}

	// Token: 0x06000BB7 RID: 2999 RVA: 0x0010F5A4 File Offset: 0x0010D7A4
	public void OnMark(Vector2 TileAnchoredPosition, bool big = false)
	{
		this.OnSelect(TileAnchoredPosition, big, 0);
		if (!big)
		{
			this.TileMarkSpeed = 75f;
			this.TileMark.anchoredPosition = TileAnchoredPosition + Vector2.up * 92f;
			this.TileMarkPosY = this.TileMark.anchoredPosition.y;
			this.TileMarkGameObject.SetActive(true);
		}
	}

	// Token: 0x06000BB8 RID: 3000 RVA: 0x0010F610 File Offset: 0x0010D810
	public void Close()
	{
		this.TileSelectStart = 0f;
		this.TileSelectColor.a = 0f;
		this.TileSelectImage.color = this.TileSelectColor;
		this.TileSelect.gameObject.SetActive(false);
		this.TileMarkGameObject.SetActive(false);
	}

	// Token: 0x06000BB9 RID: 3001 RVA: 0x0010F668 File Offset: 0x0010D868
	public void OnTarget(ushort targetRangeID, ushort targetZoneID, byte targetPointID, MapTile MapTileController)
	{
		if (DataManager.MapDataController.MapWeaponDamageRangeTable == null)
		{
			DataManager.MapDataController.MapWeaponDamageRangeTable = new CExternalTableWithWordKey<MapWeaponDamageRange>();
			DataManager.MapDataController.MapWeaponDamageRangeTable.LoadTable("MapDamageRange");
		}
		this.NoneTarget(MapTileController);
		this.nowDamageRangeID = targetRangeID;
		this.nowDamageTargetZoneID = targetZoneID;
		this.nowDamageTargetPointID = targetPointID;
		ushort num = 0;
		Vector2 vector = Vector2.zero;
		while (num < 40)
		{
			if (DataManager.MapDataController.CheckYolk(num, 0))
			{
				vector = DataManager.MapDataController.GetYolkPointCode(num, DataManager.MapDataController.FocusKingdomID);
				if (vector.x == (float)targetZoneID && vector.y == (float)targetPointID)
				{
					break;
				}
			}
			num += 1;
		}
		MapWeaponDamageRange recordByKey = DataManager.MapDataController.MapWeaponDamageRangeTable.GetRecordByKey(targetRangeID);
		if (MapTileController != null)
		{
			this.OnSelect(MapTileController.getTilePosition(targetZoneID, targetPointID), num < 40, recordByKey.MarkID);
			Vector2 tileMapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(targetZoneID, targetPointID);
			Vector2 vector2 = tileMapPosbyPointCode;
			int num2 = (int)((recordByKey.OffSetX <= 128) ? recordByKey.OffSetX : (-(int)(recordByKey.OffSetX - 128)));
			vector2.x += (float)num2;
			if (vector2.x > 511f)
			{
				vector2.x = 511f;
			}
			if (vector2.x < 0f)
			{
				vector2.x = 0f;
			}
			num2 = (int)((recordByKey.OffSetY <= 128) ? recordByKey.OffSetY : (-(int)(recordByKey.OffSetY - 128)));
			vector2.y += (float)num2;
			if (vector2.y > 1023f)
			{
				vector2.y = 1023f;
			}
			if (vector2.y < 0f)
			{
				vector2.y = 0f;
			}
			Color in_color = new Color32(recordByKey.ColorR, recordByKey.ColorG, recordByKey.ColorB, byte.MaxValue);
			uint layoutMapInfoID = (uint)GameConstants.TileMapPosToMapID((int)vector2.x, (int)vector2.y);
			int num3 = -1;
			int num4 = -1;
			MapTileController.MapIDtoMapTileRowCol(layoutMapInfoID, ref num3, ref num4);
			if (num3 > -1 && num4 > -1)
			{
				MapTileController.mapTileShowDamageRange(num3, num4, in_color);
			}
			while (recordByKey.NextID != 0)
			{
				ushort nextID = recordByKey.NextID;
				recordByKey = DataManager.MapDataController.MapWeaponDamageRangeTable.GetRecordByKey(nextID);
				if (nextID != recordByKey.ID)
				{
					break;
				}
				vector2 = tileMapPosbyPointCode;
				num2 = (int)((recordByKey.OffSetX <= 128) ? recordByKey.OffSetX : (-(int)(recordByKey.OffSetX - 128)));
				vector2.x += (float)num2;
				if (vector2.x > 511f)
				{
					vector2.x = 511f;
				}
				if (vector2.x < 0f)
				{
					vector2.x = 0f;
				}
				num2 = (int)((recordByKey.OffSetY <= 128) ? recordByKey.OffSetY : (-(int)(recordByKey.OffSetY - 128)));
				vector2.y += (float)num2;
				if (vector2.y > 1023f)
				{
					vector2.y = 1023f;
				}
				if (vector2.y < 0f)
				{
					vector2.y = 0f;
				}
				in_color = new Color32(recordByKey.ColorR, recordByKey.ColorG, recordByKey.ColorB, byte.MaxValue);
				layoutMapInfoID = (uint)GameConstants.TileMapPosToMapID((int)vector2.x, (int)vector2.y);
				MapTileController.MapIDtoMapTileRowCol(layoutMapInfoID, ref num3, ref num4);
				if (num3 > -1 && num4 > -1)
				{
					MapTileController.mapTileShowDamageRange(num3, num4, in_color);
				}
			}
		}
	}

	// Token: 0x06000BBA RID: 3002 RVA: 0x0010FA64 File Offset: 0x0010DC64
	public void NoneTarget(MapTile MapTileController)
	{
		this.Close();
		if (this.nowDamageRangeID == 0 || this.nowDamageTargetZoneID >= 1024 || MapTileController == null)
		{
			this.nowDamageRangeID = 0;
			this.nowDamageTargetZoneID = 1024;
			this.nowDamageTargetPointID = 0;
			return;
		}
		MapWeaponDamageRange recordByKey = DataManager.MapDataController.MapWeaponDamageRangeTable.GetRecordByKey(this.nowDamageRangeID);
		Vector2 tileMapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(this.nowDamageTargetZoneID, this.nowDamageTargetPointID);
		Vector2 vector = tileMapPosbyPointCode;
		int num = (int)((recordByKey.OffSetX <= 128) ? recordByKey.OffSetX : (-(int)(recordByKey.OffSetX - 128)));
		vector.x += (float)num;
		if (vector.x > 511f)
		{
			vector.x = 511f;
		}
		if (vector.x < 0f)
		{
			vector.x = 0f;
		}
		num = (int)((recordByKey.OffSetY <= 128) ? recordByKey.OffSetY : (-(int)(recordByKey.OffSetY - 128)));
		vector.y += (float)num;
		if (vector.y > 1023f)
		{
			vector.y = 1023f;
		}
		if (vector.y < 0f)
		{
			vector.y = 0f;
		}
		uint layoutMapInfoID = (uint)GameConstants.TileMapPosToMapID((int)vector.x, (int)vector.y);
		int num2 = -1;
		int num3 = -1;
		MapTileController.MapIDtoMapTileRowCol(layoutMapInfoID, ref num2, ref num3);
		Color mapTileColorByMapID = MapTileController.getMapTileColorByMapID(layoutMapInfoID);
		if (num2 > -1 && num3 > -1)
		{
			MapTileController.mapTileShowDamageRange(num2, num3, mapTileColorByMapID);
		}
		while (recordByKey.NextID != 0)
		{
			recordByKey = DataManager.MapDataController.MapWeaponDamageRangeTable.GetRecordByKey(recordByKey.NextID);
			vector = tileMapPosbyPointCode;
			num = (int)((recordByKey.OffSetX <= 128) ? recordByKey.OffSetX : (-(int)(recordByKey.OffSetX - 128)));
			vector.x += (float)num;
			if (vector.x > 511f)
			{
				vector.x = 511f;
			}
			if (vector.x < 0f)
			{
				vector.x = 0f;
			}
			num = (int)((recordByKey.OffSetY <= 128) ? recordByKey.OffSetY : (-(int)(recordByKey.OffSetY - 128)));
			vector.y += (float)num;
			if (vector.y > 1023f)
			{
				vector.y = 1023f;
			}
			if (vector.y < 0f)
			{
				vector.y = 0f;
			}
			layoutMapInfoID = (uint)GameConstants.TileMapPosToMapID((int)vector.x, (int)vector.y);
			MapTileController.MapIDtoMapTileRowCol(layoutMapInfoID, ref num2, ref num3);
			mapTileColorByMapID = MapTileController.getMapTileColorByMapID(layoutMapInfoID);
			if (num2 > -1 && num3 > -1)
			{
				MapTileController.mapTileShowDamageRange(num2, num3, mapTileColorByMapID);
			}
		}
		this.nowDamageRangeID = 0;
		this.nowDamageTargetZoneID = 1024;
		this.nowDamageTargetPointID = 0;
	}

	// Token: 0x06000BBB RID: 3003 RVA: 0x0010FD98 File Offset: 0x0010DF98
	public void UpdataFootSkill(byte mType = 0, byte mNum = 0)
	{
		if (!this.bShowFootBallSkill)
		{
			return;
		}
		if (mType == 0 && mNum == 0)
		{
			this.bShowFootBallSkill = false;
			for (int i = 0; i < this.mGO_FBSkill.Length; i++)
			{
				this.mGO_FBSkill[i].SetActive(false);
			}
		}
		else
		{
			for (int j = 0; j < (int)mNum; j++)
			{
				if (this.mImg_FBSkill[j].sprite != null)
				{
					this.mGO_FBSkill[j].SetActive(true);
				}
				this.mRT_FBSkill[j].anchoredPosition = this.mFootBall[(int)(mType - 1)] * (float)(j + 1);
			}
		}
	}

	// Token: 0x06000BBC RID: 3004 RVA: 0x0010FE54 File Offset: 0x0010E054
	public void SetShowFootBallSkill(bool bShow)
	{
		this.bShowFootBallSkill = bShow;
	}

	// Token: 0x06000BBD RID: 3005 RVA: 0x0010FE60 File Offset: 0x0010E060
	public void SetShowHideFootBallGameObject(bool bShow)
	{
		if (this.mImg_FBBGD[0].sprite != null)
		{
			this.FootBallGameObject.SetActive(bShow);
		}
	}

	// Token: 0x06000BBE RID: 3006 RVA: 0x0010FE94 File Offset: 0x0010E094
	public void SetShowHideFootBallSkillGameObject(bool bShow)
	{
		this.FootBallSkillGameObject.SetActive(bShow);
	}

	// Token: 0x06000BBF RID: 3007 RVA: 0x0010FEA4 File Offset: 0x0010E0A4
	public void SetFootBallSelect()
	{
		this.FootBallT.anchoredPosition = FootballManager.Instance.mFootBallCenterPos;
		this.FootBallSkillT.anchoredPosition = FootballManager.Instance.mFootBallCenterPos;
		for (int i = 0; i < 4; i++)
		{
			if (!this.mGO_FBBG[i].gameObject.activeInHierarchy)
			{
				this.mGO_FBBG[i].gameObject.SetActive(true);
			}
		}
		for (int j = 0; j < 8; j++)
		{
			if (!this.mGO_FBBGD[j].gameObject.activeInHierarchy)
			{
				this.mGO_FBBGD[j].gameObject.SetActive(true);
			}
		}
		if (FootballManager.Instance.mUIOpenState == 1)
		{
			GUIManager.Instance.UpdateUI(EGUIWindow.UI_FootBall, 7, 0);
		}
		else
		{
			FootballManager.Instance.mUIOpenState = 2;
		}
	}

	// Token: 0x0400274F RID: 10063
	private const int selectSpriteID = 138;

	// Token: 0x04002750 RID: 10064
	private const int markSpriteID = 150;

	// Token: 0x04002751 RID: 10065
	private const float markYoffset = 92f;

	// Token: 0x04002752 RID: 10066
	private ushort nowDamageRangeID;

	// Token: 0x04002753 RID: 10067
	private ushort nowDamageTargetZoneID = 1024;

	// Token: 0x04002754 RID: 10068
	private byte nowDamageTargetPointID;

	// Token: 0x04002755 RID: 10069
	private float TileSelectStart;

	// Token: 0x04002756 RID: 10070
	private float TileMarkSpeed = 10f;

	// Token: 0x04002757 RID: 10071
	private float TileMarkPosY;

	// Token: 0x04002758 RID: 10072
	private GameObject TileMarkGameObject;

	// Token: 0x04002759 RID: 10073
	private RectTransform TileSelect;

	// Token: 0x0400275A RID: 10074
	private RectTransform TileMark;

	// Token: 0x0400275B RID: 10075
	private Image TileSelectImage;

	// Token: 0x0400275C RID: 10076
	private Image TileMarkImage;

	// Token: 0x0400275D RID: 10077
	private Color TileSelectColor = Color.white;

	// Token: 0x0400275E RID: 10078
	private GameObject[] mGO_FBBG = new GameObject[4];

	// Token: 0x0400275F RID: 10079
	private RectTransform[] mRT_FBBG = new RectTransform[4];

	// Token: 0x04002760 RID: 10080
	private Image[] mImg_FBBG = new Image[4];

	// Token: 0x04002761 RID: 10081
	private GameObject[] mGO_FBBGD = new GameObject[8];

	// Token: 0x04002762 RID: 10082
	private RectTransform[] mRT_FBBGD = new RectTransform[8];

	// Token: 0x04002763 RID: 10083
	private Image[] mImg_FBBGD = new Image[8];

	// Token: 0x04002764 RID: 10084
	private GameObject[] mGO_FBSkill = new GameObject[15];

	// Token: 0x04002765 RID: 10085
	private RectTransform[] mRT_FBSkill = new RectTransform[15];

	// Token: 0x04002766 RID: 10086
	private Image[] mImg_FBSkill = new Image[15];

	// Token: 0x04002767 RID: 10087
	private Vector2[] mFootBall = new Vector2[8];

	// Token: 0x04002768 RID: 10088
	private bool bShowFootBallSkill;

	// Token: 0x04002769 RID: 10089
	private GameObject FootBallGameObject;

	// Token: 0x0400276A RID: 10090
	private RectTransform FootBallT;

	// Token: 0x0400276B RID: 10091
	private GameObject FootBallSkillGameObject;

	// Token: 0x0400276C RID: 10092
	private RectTransform FootBallSkillT;

	// Token: 0x0400276D RID: 10093
	private int FBSABKey;

	// Token: 0x0400276E RID: 10094
	private AssetBundle FBSAB;

	// Token: 0x0400276F RID: 10095
	private GameObject mFBS;

	// Token: 0x04002770 RID: 10096
	private UISpritesArray FBSprites;
}
