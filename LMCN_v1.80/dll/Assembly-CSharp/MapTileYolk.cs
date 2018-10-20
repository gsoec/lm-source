using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000273 RID: 627
public class MapTileYolk
{
	// Token: 0x06000BC0 RID: 3008 RVA: 0x0010FF84 File Offset: 0x0010E184
	public MapTileYolk(Transform RealmGroup)
	{
		this.realmGroup = RealmGroup;
		ushort num = (DataManager.MapDataController.FocusKingdomID != 0) ? DataManager.MapDataController.FocusKingdomID : 1;
		CString cstring = StringManager.Instance.SpawnString(30);
		cstring.ClearString();
		ushort num2 = 0;
		KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(num);
		if (ActivityManager.Instance.IsInKvK(0, false) && num != ActivityManager.Instance.KOWKingdomID && DataManager.MapDataController.IsEnemy(num))
		{
			cstring.IntToFormat(0L, 3, false);
		}
		else
		{
			cstring.IntToFormat((long)((recordByKey.mapID != 0) ? recordByKey.mapID : 1), 3, false);
		}
		cstring.AppendFormat("UI/Yolk_{0}");
		AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int)num2]);
		if (assetBundle == null)
		{
			cstring.ClearString();
			cstring.IntToFormat(1L, 1, false);
			cstring.AppendFormat("UI/Yolk_{0}");
			assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int)num2]);
		}
		this.TileYolkGameObject[(int)num2] = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
		this.TileYolkGameObject[(int)num2].SetActive(false);
		this.TileYolkRectTransform[(int)num2] = (this.TileYolkGameObject[(int)num2].transform as RectTransform);
		this.TileYolkImage[(int)num2] = this.TileYolkGameObject[(int)num2].GetComponent<Image>();
		this.TileYolkImage[(int)num2].material.renderQueue = 2550;
		this.TileYolkImage[(int)num2].SetNativeSize();
		this.TileYolkRectTransform[(int)num2].localPosition = Vector3.forward * this.forward;
		this.TileYolkRectTransform[(int)num2].SetParent(this.realmGroup, false);
		this.YOLK_POS[(int)num2] = DataManager.MapDataController.GetYolkPos(num2, num);
		Vector2[] yolk_POS = this.YOLK_POS;
		ushort num3 = num2;
		yolk_POS[(int)num3].y = yolk_POS[(int)num3].y + 1f;
		this.YOLK_MAPID[(int)num2] = new uint[9];
		this.YOLK_MAPID[(int)num2][0] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x, (int)this.YOLK_POS[(int)num2].y);
		this.YOLK_MAPID[(int)num2][1] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x + 1, (int)this.YOLK_POS[(int)num2].y - 1);
		this.YOLK_MAPID[(int)num2][2] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x - 1, (int)this.YOLK_POS[(int)num2].y - 1);
		this.YOLK_MAPID[(int)num2][3] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x + 2, (int)this.YOLK_POS[(int)num2].y - 2);
		this.YOLK_MAPID[(int)num2][4] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x, (int)this.YOLK_POS[(int)num2].y - 2);
		this.YOLK_MAPID[(int)num2][5] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x - 2, (int)this.YOLK_POS[(int)num2].y - 2);
		this.YOLK_MAPID[(int)num2][6] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x + 1, (int)this.YOLK_POS[(int)num2].y - 3);
		this.YOLK_MAPID[(int)num2][7] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x - 1, (int)this.YOLK_POS[(int)num2].y - 3);
		this.YOLK_MAPID[(int)num2][8] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x, (int)this.YOLK_POS[(int)num2].y - 4);
		for (num2 = 1; num2 < 40; num2 += 1)
		{
			if (DataManager.MapDataController.CheckYolk(num2, num))
			{
				cstring.ClearString();
				if (ActivityManager.Instance.IsInKvK(0, false) && num != ActivityManager.Instance.KOWKingdomID && DataManager.MapDataController.IsEnemy(num))
				{
					cstring.Append("UI/EnemyLittleYolk");
					assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int)num2]);
					this.TileYolkGameObject[(int)num2] = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
					this.TileYolkGameObject[(int)num2].SetActive(false);
					this.TileYolkRectTransform[(int)num2] = (this.TileYolkGameObject[(int)num2].transform as RectTransform);
					this.TileYolkImage[(int)num2] = this.TileYolkGameObject[(int)num2].GetComponent<Image>();
					this.TileYolkImage[(int)num2].material.renderQueue = 2550;
					this.TileYolkImage[(int)num2].SetNativeSize();
					this.TileYolkRectTransform[(int)num2].localPosition = Vector3.forward * this.forward;
					this.TileYolkRectTransform[(int)num2].SetParent(this.realmGroup, false);
				}
				else
				{
					KingdomYolkDeploy recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(0);
					int i;
					for (i = 1; i < DataManager.MapDataController.KingdomYolkDeployTable.TableCount; i++)
					{
						recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(i);
						if (recordByIndex.kingdomID == num)
						{
							break;
						}
					}
					if (i >= DataManager.MapDataController.KingdomYolkDeployTable.TableCount)
					{
						cstring.Append("UI/LittleYolk");
						assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int)num2]);
						this.TileYolkGameObject[(int)num2] = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
						this.TileYolkGameObject[(int)num2].SetActive(false);
						this.TileYolkRectTransform[(int)num2] = (this.TileYolkGameObject[(int)num2].transform as RectTransform);
						this.TileYolkImage[(int)num2] = this.TileYolkGameObject[(int)num2].GetComponent<Image>();
						this.TileYolkImage[(int)num2].material.renderQueue = 2550;
						this.TileYolkImage[(int)num2].SetNativeSize();
						this.TileYolkRectTransform[(int)num2].localPosition = Vector3.forward * this.forward;
						this.TileYolkRectTransform[(int)num2].SetParent(this.realmGroup, false);
					}
					else
					{
						ushort inKey = recordByIndex.yolkDeployIDs[(int)num2];
						YolkDeploy recordByKey2 = DataManager.MapDataController.YolkDeployTable.GetRecordByKey(inKey);
						cstring.ClearString();
						cstring.IntToFormat((long)recordByKey2.iconID, 3, false);
						cstring.AppendFormat("UI/LittleYolk_{0}");
						assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int)num2]);
						this.TileYolkGameObject[(int)num2] = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
						this.TileYolkGameObject[(int)num2].SetActive(false);
						this.TileYolkRectTransform[(int)num2] = (this.TileYolkGameObject[(int)num2].transform as RectTransform);
						this.TileYolkImage[(int)num2] = this.TileYolkGameObject[(int)num2].GetComponent<Image>();
						this.TileYolkImage[(int)num2].material.renderQueue = 2550;
						this.TileYolkImage[(int)num2].SetNativeSize();
						this.TileYolkRectTransform[(int)num2].localPosition = Vector3.forward * this.forward;
						this.TileYolkRectTransform[(int)num2].SetParent(this.realmGroup, false);
					}
				}
			}
			else
			{
				this.TileYolkGameObject[(int)num2] = null;
				this.TileYolkRectTransform[(int)num2] = null;
				this.TileYolkImage[(int)num2] = null;
				this.TileYolkABKey[(int)num2] = 0;
			}
			this.YOLK_POS[(int)num2] = DataManager.MapDataController.GetYolkPos(num2, num);
			Vector2[] yolk_POS2 = this.YOLK_POS;
			ushort num4 = num2;
			yolk_POS2[(int)num4].y = yolk_POS2[(int)num4].y + 1f;
			this.YOLK_MAPID[(int)num2] = new uint[9];
			this.YOLK_MAPID[(int)num2][0] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x, (int)this.YOLK_POS[(int)num2].y);
			this.YOLK_MAPID[(int)num2][1] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x + 1, (int)this.YOLK_POS[(int)num2].y - 1);
			this.YOLK_MAPID[(int)num2][2] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x - 1, (int)this.YOLK_POS[(int)num2].y - 1);
			this.YOLK_MAPID[(int)num2][3] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x + 2, (int)this.YOLK_POS[(int)num2].y - 2);
			this.YOLK_MAPID[(int)num2][4] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x, (int)this.YOLK_POS[(int)num2].y - 2);
			this.YOLK_MAPID[(int)num2][5] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x - 2, (int)this.YOLK_POS[(int)num2].y - 2);
			this.YOLK_MAPID[(int)num2][6] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x + 1, (int)this.YOLK_POS[(int)num2].y - 3);
			this.YOLK_MAPID[(int)num2][7] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x - 1, (int)this.YOLK_POS[(int)num2].y - 3);
			this.YOLK_MAPID[(int)num2][8] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x, (int)this.YOLK_POS[(int)num2].y - 4);
		}
		StringManager.Instance.DeSpawnString(cstring);
	}

	// Token: 0x06000BC1 RID: 3009 RVA: 0x00110A90 File Offset: 0x0010EC90
	public void IniMapTileYolk(float tileBaseScale, byte tileHeight)
	{
		Bounds bounds = this.TileYolkImage[0].sprite.bounds;
		this.TileYolkRectTransform[0].pivot = Vector2.one * 0.5f + Vector2.right * (-bounds.center.x / bounds.extents.x / 2f);
		this.offset = (this.TileYolkRectTransform[0].sizeDelta.y - (float)tileHeight) * 0.5f;
		ushort num = 1;
		while ((int)num < this.TileYolkImage.Length)
		{
			if (this.TileYolkImage[(int)num] != null)
			{
				bounds = this.TileYolkImage[(int)num].sprite.bounds;
				this.TileYolkRectTransform[(int)num].pivot = Vector2.one * 0.5f + Vector2.right * (-bounds.center.x / bounds.extents.x / 2f);
				this.LittleYolkoffset = (this.TileYolkRectTransform[(int)num].sizeDelta.y - (float)tileHeight) * 0.5f;
				break;
			}
			num += 1;
		}
		ushort checkKingdomID = (DataManager.MapDataController.FocusKingdomID != 0) ? DataManager.MapDataController.FocusKingdomID : 1;
		this.nowKvKKingdomType = ActivityManager.Instance.getKvKKingdomType(checkKingdomID);
	}

	// Token: 0x06000BC2 RID: 3010 RVA: 0x00110C18 File Offset: 0x0010EE18
	public void OnDestroy()
	{
		this.realmGroup = null;
		if (this.TileYolkGameObject != null)
		{
			for (int i = 0; i < this.TileYolkGameObject.Length; i++)
			{
				this.TileYolkImage[i] = null;
				this.TileYolkRectTransform[i] = null;
				if (this.TileYolkABKey[i] != 0)
				{
					AssetManager.UnloadAssetBundle(this.TileYolkABKey[i], true);
					this.TileYolkABKey[i] = 0;
				}
				if (this.TileYolkGameObject[i] != null)
				{
					UnityEngine.Object.Destroy(this.TileYolkGameObject[i]);
					this.TileYolkGameObject[i] = null;
				}
			}
			this.TileYolkImage = null;
			this.TileYolkRectTransform = null;
			this.TileYolkABKey = null;
			this.TileYolkGameObject = null;
		}
		if (this.tempTileYolkGameObject != null)
		{
			for (int j = 0; j < this.tempTileYolkGameObject.Length; j++)
			{
				if (this.tempTileYolkABKey[j] != 0)
				{
					AssetManager.UnloadAssetBundle(this.tempTileYolkABKey[j], true);
					this.tempTileYolkABKey[j] = 0;
				}
				if (this.tempTileYolkGameObject[j] != null)
				{
					UnityEngine.Object.Destroy(this.tempTileYolkGameObject[j]);
					this.tempTileYolkGameObject[j] = null;
				}
			}
			this.tempTileYolkABKey = null;
			this.tempTileYolkGameObject = null;
		}
	}

	// Token: 0x06000BC3 RID: 3011 RVA: 0x00110D4C File Offset: 0x0010EF4C
	public void MoveYolk(Vector2 moveDelta)
	{
		ushort num = 0;
		while ((int)num < this.TileYolkGameObject.Length)
		{
			if (this.TileYolkGameObject[(int)num] != null && this.TileYolkGameObject[(int)num].activeSelf)
			{
				this.TileYolkRectTransform[(int)num].anchoredPosition += moveDelta;
				if (this.TileYolkRectTransform[(int)num].anchoredPosition.x < this.left || this.TileYolkRectTransform[(int)num].anchoredPosition.x > this.right || this.TileYolkRectTransform[(int)num].anchoredPosition.y > this.up || this.TileYolkRectTransform[(int)num].anchoredPosition.y < this.down)
				{
					this.TileYolkGameObject[(int)num].SetActive(false);
					DataManager.msgBuffer[0] = 95;
					GameConstants.GetBytes(num, DataManager.msgBuffer, 1);
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
			}
			num += 1;
		}
	}

	// Token: 0x06000BC4 RID: 3012 RVA: 0x00110E64 File Offset: 0x0010F064
	public int setYolk(int mapID, Vector2 pos)
	{
		ushort num = (DataManager.MapDataController.FocusKingdomID != 0) ? DataManager.MapDataController.FocusKingdomID : 1;
		int num2 = -1;
		Vector2 tileMapPosbyMapID = GameConstants.getTileMapPosbyMapID(mapID);
		Vector2 vector = Vector2.zero;
		int i = 0;
		while (i < (int)DataManager.MapDataController.showYolkNum)
		{
			num2 = (int)DataManager.MapDataController.showYolkMapYolkID[i];
			vector = this.YOLK_POS[num2] - tileMapPosbyMapID;
			if (Mathf.Abs(vector.x) <= this.w && Mathf.Abs(vector.y) <= this.h)
			{
				if (DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)DataManager.MapDataController.GetYolkMapID((ushort)num2, num))].pointKind != 11)
				{
					if (this.TileYolkGameObject[num2] != null && this.TileYolkGameObject[num2].activeSelf)
					{
						this.TileYolkGameObject[num2].SetActive(false);
						if (num2 == 0)
						{
							this.tickcolorbigYolkID = 40;
							this.TileYolkImage[num2].color = Color.white;
						}
						else if (this.tickcolorlittleYolkIDCount > 0)
						{
							for (int j = 0; j < (int)this.tickcolorlittleYolkIDCount; j++)
							{
								if ((int)this.tickcolorlittleYolkID[j] == num2)
								{
									this.tickcolorlittleYolkIDCount -= 1;
									this.tickcolorlittleYolkID[j] = this.tickcolorlittleYolkID[(int)this.tickcolorlittleYolkIDCount];
									this.tickcolorlittleYolkID[(int)this.tickcolorlittleYolkIDCount] = 0;
									this.TileYolkImage[num2].color = Color.white;
									break;
								}
							}
						}
						ushort value = (ushort)num2;
						DataManager.msgBuffer[0] = 95;
						GameConstants.GetBytes(value, DataManager.msgBuffer, 1);
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					}
					return -1;
				}
				break;
			}
			else
			{
				i++;
			}
		}
		if (this.TileYolkGameObject[num2] == null)
		{
			CString cstring = StringManager.Instance.SpawnString(30);
			cstring.ClearString();
			if (num2 == 0)
			{
				KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(num);
				if (ActivityManager.Instance.IsInKvK(0, false) && num != ActivityManager.Instance.KOWKingdomID && DataManager.MapDataController.IsEnemy(num))
				{
					this.nowKvKKingdomType = ActivityManager.Instance.getKvKKingdomType(num);
					cstring.IntToFormat(0L, 3, false);
				}
				else
				{
					this.nowKvKKingdomType = EKvKKingdomType.EKKT_Normal;
					cstring.IntToFormat((long)((recordByKey.mapID != 0) ? recordByKey.mapID : 1), 3, false);
				}
				cstring.AppendFormat("UI/Yolk_{0}");
				AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[num2]);
				if (assetBundle == null)
				{
					cstring.ClearString();
					cstring.IntToFormat(1L, 1, false);
					cstring.AppendFormat("UI/Yolk_{0}");
					assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[num2]);
				}
				this.TileYolkGameObject[num2] = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
				this.TileYolkGameObject[num2].SetActive(false);
				this.TileYolkRectTransform[num2] = (this.TileYolkGameObject[num2].transform as RectTransform);
				this.TileYolkImage[num2] = this.TileYolkGameObject[num2].GetComponent<Image>();
				this.TileYolkImage[num2].material.renderQueue = 2550;
				this.TileYolkImage[num2].SetNativeSize();
				this.TileYolkRectTransform[num2].localPosition = Vector3.forward * this.forward;
				this.TileYolkRectTransform[num2].SetParent(this.realmGroup, false);
			}
			else if (ActivityManager.Instance.IsInKvK(0, false) && num != ActivityManager.Instance.KOWKingdomID && DataManager.MapDataController.IsEnemy(num))
			{
				this.nowKvKKingdomType = ActivityManager.Instance.getKvKKingdomType(num);
				cstring.Append("UI/EnemyLittleYolk");
				AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[num2]);
				this.TileYolkGameObject[num2] = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
				this.TileYolkGameObject[num2].SetActive(false);
				this.TileYolkRectTransform[num2] = (this.TileYolkGameObject[num2].transform as RectTransform);
				this.TileYolkImage[num2] = this.TileYolkGameObject[num2].GetComponent<Image>();
				this.TileYolkImage[num2].material.renderQueue = 2550;
				this.TileYolkImage[num2].SetNativeSize();
				this.TileYolkRectTransform[num2].localPosition = Vector3.forward * this.forward;
				this.TileYolkRectTransform[num2].SetParent(this.realmGroup, false);
			}
			else
			{
				this.nowKvKKingdomType = EKvKKingdomType.EKKT_Normal;
				KingdomYolkDeploy recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(0);
				int k;
				for (k = 1; k < DataManager.MapDataController.KingdomYolkDeployTable.TableCount; k++)
				{
					recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(k);
					if (recordByIndex.kingdomID == num)
					{
						break;
					}
				}
				if (k >= DataManager.MapDataController.KingdomYolkDeployTable.TableCount)
				{
					cstring.Append("UI/LittleYolk");
					AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[num2]);
					this.TileYolkGameObject[num2] = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
					this.TileYolkGameObject[num2].SetActive(false);
					this.TileYolkRectTransform[num2] = (this.TileYolkGameObject[num2].transform as RectTransform);
					this.TileYolkImage[num2] = this.TileYolkGameObject[num2].GetComponent<Image>();
					this.TileYolkImage[num2].material.renderQueue = 2550;
					this.TileYolkImage[num2].SetNativeSize();
					this.TileYolkRectTransform[num2].localPosition = Vector3.forward * this.forward;
					this.TileYolkRectTransform[num2].SetParent(this.realmGroup, false);
				}
				else
				{
					ushort inKey = recordByIndex.yolkDeployIDs[num2];
					YolkDeploy recordByKey2 = DataManager.MapDataController.YolkDeployTable.GetRecordByKey(inKey);
					cstring.ClearString();
					cstring.IntToFormat((long)recordByKey2.iconID, 3, false);
					cstring.AppendFormat("UI/LittleYolk_{0}");
					AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[num2]);
					this.TileYolkGameObject[num2] = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
					this.TileYolkGameObject[num2].SetActive(false);
					this.TileYolkRectTransform[num2] = (this.TileYolkGameObject[num2].transform as RectTransform);
					this.TileYolkImage[num2] = this.TileYolkGameObject[num2].GetComponent<Image>();
					this.TileYolkImage[num2].material.renderQueue = 2550;
					this.TileYolkImage[num2].SetNativeSize();
					this.TileYolkRectTransform[num2].localPosition = Vector3.forward * this.forward;
					this.TileYolkRectTransform[num2].SetParent(this.realmGroup, false);
				}
			}
			StringManager.Instance.DeSpawnString(cstring);
		}
		if (!this.TileYolkGameObject[num2].activeSelf)
		{
			vector.x *= 128f;
			vector.y *= -64f;
			vector += pos;
			if (num2 == 0)
			{
				vector.y += this.offset;
				if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Hunter)
				{
					this.tickcolorbigYolkID = 0;
					this.TileYolkImage[num2].color = this.wolfbigYolkTickColor;
				}
				else if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Target)
				{
					this.tickcolorbigYolkID = 0;
					this.TileYolkImage[num2].color = this.sheepbigYolkTickColor;
				}
				else
				{
					this.tickcolorbigYolkID = 40;
					this.TileYolkImage[num2].color = Color.white;
				}
			}
			else
			{
				vector.y += this.LittleYolkoffset;
				if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Hunter)
				{
					this.tickcolorlittleYolkID[(int)this.tickcolorlittleYolkIDCount] = (byte)num2;
					this.tickcolorlittleYolkIDCount += 1;
					this.TileYolkImage[num2].color = this.wolflittleYolkTickColor;
				}
				else if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Target)
				{
					this.tickcolorlittleYolkID[(int)this.tickcolorlittleYolkIDCount] = (byte)num2;
					this.tickcolorlittleYolkIDCount += 1;
					this.TileYolkImage[num2].color = this.sheeplittleYolkTickColor;
				}
				else
				{
					for (int l = 0; l < (int)this.tickcolorlittleYolkIDCount; l++)
					{
						if ((int)this.tickcolorlittleYolkID[l] == num2)
						{
							this.tickcolorlittleYolkIDCount -= 1;
							this.tickcolorlittleYolkID[l] = this.tickcolorlittleYolkID[(int)this.tickcolorlittleYolkIDCount];
							this.tickcolorlittleYolkID[(int)this.tickcolorlittleYolkIDCount] = 0;
							this.TileYolkImage[num2].color = Color.white;
							break;
						}
					}
				}
			}
			this.TileYolkGameObject[num2].SetActive(true);
			this.TileYolkRectTransform[num2].anchoredPosition = vector;
			ushort value2 = (ushort)num2;
			DataManager.msgBuffer[0] = 94;
			GameConstants.GetBytes(value2, DataManager.msgBuffer, 1);
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
		return num2;
	}

	// Token: 0x06000BC5 RID: 3013 RVA: 0x0011179C File Offset: 0x0010F99C
	public bool OnYolkSelect(uint mapID)
	{
		for (int i = 0; i < (int)DataManager.MapDataController.showYolkNum; i++)
		{
			ushort num = (ushort)DataManager.MapDataController.showYolkMapYolkID[i];
			ushort num2 = 0;
			while ((int)num2 < this.YOLK_MAPID[(int)num].Length)
			{
				if (mapID == this.YOLK_MAPID[(int)num][(int)num2])
				{
					byte wonderState = DataManager.MapDataController.YolkPointTable[(int)num].WonderState;
					if (wonderState == 2)
					{
						DataManager.msgBuffer[0] = 65;
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(614u), DataManager.Instance.mStringTable.GetStringByID(8597u), null, null, 0, 0, false, false, false, false, false);
					}
					else if (wonderState == 1 || wonderState == 0)
					{
						Vector2 yolkPointCode = DataManager.MapDataController.GetYolkPointCode(num, DataManager.MapDataController.FocusKingdomID);
						ushort value = (ushort)yolkPointCode.x;
						byte value2 = (byte)yolkPointCode.y;
						DataManager.MapDataController.isMarkGroundInfo = 0;
						DataManager.msgBuffer[0] = 64;
						GameConstants.GetBytes(this.YOLK_MAPID[(int)num][0], DataManager.msgBuffer, 1);
						GameConstants.GetBytes(value, DataManager.msgBuffer, 5);
						GameConstants.GetBytes((ushort)value2, DataManager.msgBuffer, 9);
						GameConstants.GetBytes(11, DataManager.msgBuffer, 13);
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					}
					else
					{
						DataManager.msgBuffer[0] = 65;
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					}
					return true;
				}
				num2 += 1;
			}
		}
		return false;
	}

	// Token: 0x06000BC6 RID: 3014 RVA: 0x00111924 File Offset: 0x0010FB24
	public Sprite getMapTileYolkSprite(byte YolkID)
	{
		if ((int)YolkID >= this.TileYolkImage.Length || this.TileYolkImage[(int)YolkID] == null)
		{
			YolkID = 1;
		}
		return (!(this.TileYolkImage[(int)YolkID] == null)) ? this.TileYolkImage[(int)YolkID].sprite : null;
	}

	// Token: 0x06000BC7 RID: 3015 RVA: 0x0011197C File Offset: 0x0010FB7C
	public Material getMapTileYolkMaterial(byte YolkID)
	{
		if ((int)YolkID >= this.TileYolkImage.Length || this.TileYolkImage[(int)YolkID] == null)
		{
			YolkID = 1;
		}
		return (!(this.TileYolkImage[(int)YolkID] == null)) ? this.TileYolkImage[(int)YolkID].material : null;
	}

	// Token: 0x06000BC8 RID: 3016 RVA: 0x001119D4 File Offset: 0x0010FBD4
	public bool resetYolk()
	{
		EKvKKingdomType ekvKKingdomType = this.nowKvKKingdomType;
		bool flag = false;
		if (this.tempTileYolkABKey == null)
		{
			this.tempTileYolkABKey = new int[40];
		}
		if (this.tempTileYolkGameObject == null)
		{
			this.tempTileYolkGameObject = new GameObject[40];
		}
		ushort num = (DataManager.MapDataController.FocusKingdomID != 0) ? DataManager.MapDataController.FocusKingdomID : 1;
		this.nowKvKKingdomType = ActivityManager.Instance.getKvKKingdomType(num);
		if (ekvKKingdomType != this.nowKvKKingdomType)
		{
			flag = true;
		}
		CString cstring = StringManager.Instance.SpawnString(30);
		cstring.ClearString();
		ushort num2 = 0;
		KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(num);
		if (ActivityManager.Instance.IsInKvK(0, false) && num != ActivityManager.Instance.KOWKingdomID && DataManager.MapDataController.IsEnemy(num))
		{
			cstring.IntToFormat(0L, 3, false);
		}
		else
		{
			cstring.IntToFormat((long)((recordByKey.mapID != 0) ? recordByKey.mapID : 1), 3, false);
		}
		cstring.AppendFormat("UI/Yolk_{0}");
		this.tempTileYolkABKey[(int)num2] = this.TileYolkABKey[(int)num2];
		AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int)num2]);
		if (assetBundle == null)
		{
			cstring.ClearString();
			cstring.IntToFormat(1L, 1, false);
			cstring.AppendFormat("UI/Yolk_{0}");
			assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int)num2]);
		}
		if (this.TileYolkABKey[(int)num2] != this.tempTileYolkABKey[(int)num2])
		{
			this.tempTileYolkGameObject[(int)num2] = this.TileYolkGameObject[(int)num2];
			RectTransform rectTransform = this.tempTileYolkGameObject[(int)num2].transform as RectTransform;
			this.TileYolkGameObject[(int)num2] = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
			this.TileYolkGameObject[(int)num2].SetActive(this.tempTileYolkGameObject[(int)num2].activeSelf);
			this.TileYolkRectTransform[(int)num2] = (this.TileYolkGameObject[(int)num2].transform as RectTransform);
			this.TileYolkImage[(int)num2] = this.TileYolkGameObject[(int)num2].GetComponent<Image>();
			this.TileYolkImage[(int)num2].material.renderQueue = 2550;
			this.TileYolkImage[(int)num2].SetNativeSize();
			this.TileYolkRectTransform[(int)num2].localPosition = Vector3.forward * this.forward;
			this.TileYolkRectTransform[(int)num2].anchoredPosition = rectTransform.anchoredPosition;
			this.TileYolkRectTransform[(int)num2].SetParent(this.realmGroup, false);
			flag = true;
		}
		else
		{
			this.tempTileYolkGameObject[(int)num2] = null;
		}
		if (this.TileYolkGameObject[(int)num2].activeSelf)
		{
			if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Hunter)
			{
				this.tickcolorbigYolkID = 0;
				this.TileYolkImage[(int)num2].color = this.wolfbigYolkTickColor;
			}
			else if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Target)
			{
				this.tickcolorbigYolkID = 0;
				this.TileYolkImage[(int)num2].color = this.sheepbigYolkTickColor;
			}
			else
			{
				this.tickcolorbigYolkID = 40;
				this.TileYolkImage[(int)num2].color = Color.white;
			}
		}
		else
		{
			this.tickcolorbigYolkID = 40;
			this.TileYolkImage[(int)num2].color = Color.white;
		}
		this.YOLK_POS[(int)num2] = DataManager.MapDataController.GetYolkPos(num2, num);
		Vector2[] yolk_POS = this.YOLK_POS;
		ushort num3 = num2;
		yolk_POS[(int)num3].y = yolk_POS[(int)num3].y + 1f;
		this.YOLK_MAPID[(int)num2] = new uint[9];
		this.YOLK_MAPID[(int)num2][0] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x, (int)this.YOLK_POS[(int)num2].y);
		this.YOLK_MAPID[(int)num2][1] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x + 1, (int)this.YOLK_POS[(int)num2].y - 1);
		this.YOLK_MAPID[(int)num2][2] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x - 1, (int)this.YOLK_POS[(int)num2].y - 1);
		this.YOLK_MAPID[(int)num2][3] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x + 2, (int)this.YOLK_POS[(int)num2].y - 2);
		this.YOLK_MAPID[(int)num2][4] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x, (int)this.YOLK_POS[(int)num2].y - 2);
		this.YOLK_MAPID[(int)num2][5] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x - 2, (int)this.YOLK_POS[(int)num2].y - 2);
		this.YOLK_MAPID[(int)num2][6] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x + 1, (int)this.YOLK_POS[(int)num2].y - 3);
		this.YOLK_MAPID[(int)num2][7] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x - 1, (int)this.YOLK_POS[(int)num2].y - 3);
		this.YOLK_MAPID[(int)num2][8] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x, (int)this.YOLK_POS[(int)num2].y - 4);
		for (num2 = 1; num2 < 40; num2 += 1)
		{
			if (DataManager.MapDataController.CheckYolk(num2, num))
			{
				cstring.ClearString();
				if (ActivityManager.Instance.IsInKvK(0, false) && num != ActivityManager.Instance.KOWKingdomID && DataManager.MapDataController.IsEnemy(num))
				{
					cstring.Append("UI/EnemyLittleYolk");
					this.tempTileYolkABKey[(int)num2] = this.TileYolkABKey[(int)num2];
					assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int)num2]);
					if (this.tempTileYolkABKey[(int)num2] != this.TileYolkABKey[(int)num2])
					{
						this.tempTileYolkGameObject[(int)num2] = this.TileYolkGameObject[(int)num2];
						RectTransform rectTransform = this.tempTileYolkGameObject[(int)num2].transform as RectTransform;
						this.TileYolkGameObject[(int)num2] = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
						this.TileYolkGameObject[(int)num2].SetActive(this.tempTileYolkGameObject[(int)num2].activeSelf);
						this.TileYolkRectTransform[(int)num2] = (this.TileYolkGameObject[(int)num2].transform as RectTransform);
						this.TileYolkImage[(int)num2] = this.TileYolkGameObject[(int)num2].GetComponent<Image>();
						this.TileYolkImage[(int)num2].material.renderQueue = 2550;
						this.TileYolkImage[(int)num2].SetNativeSize();
						this.TileYolkRectTransform[(int)num2].localPosition = Vector3.forward * this.forward;
						this.TileYolkRectTransform[(int)num2].anchoredPosition = rectTransform.anchoredPosition;
						this.TileYolkRectTransform[(int)num2].SetParent(this.realmGroup, false);
						flag = true;
					}
					else
					{
						this.tempTileYolkGameObject[(int)num2] = null;
					}
				}
				else
				{
					KingdomYolkDeploy recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(0);
					int i;
					for (i = 1; i < DataManager.MapDataController.KingdomYolkDeployTable.TableCount; i++)
					{
						recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(i);
						if (recordByIndex.kingdomID == num)
						{
							break;
						}
					}
					if (i >= DataManager.MapDataController.KingdomYolkDeployTable.TableCount)
					{
						cstring.Append("UI/LittleYolk");
						this.tempTileYolkABKey[(int)num2] = this.TileYolkABKey[(int)num2];
						assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int)num2]);
						if (this.tempTileYolkABKey[(int)num2] != this.TileYolkABKey[(int)num2])
						{
							this.tempTileYolkGameObject[(int)num2] = this.TileYolkGameObject[(int)num2];
							RectTransform rectTransform = this.tempTileYolkGameObject[(int)num2].transform as RectTransform;
							this.TileYolkGameObject[(int)num2] = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
							this.TileYolkGameObject[(int)num2].SetActive(this.tempTileYolkGameObject[(int)num2].activeSelf);
							this.TileYolkRectTransform[(int)num2] = (this.TileYolkGameObject[(int)num2].transform as RectTransform);
							this.TileYolkImage[(int)num2] = this.TileYolkGameObject[(int)num2].GetComponent<Image>();
							this.TileYolkImage[(int)num2].material.renderQueue = 2550;
							this.TileYolkImage[(int)num2].SetNativeSize();
							this.TileYolkRectTransform[(int)num2].localPosition = Vector3.forward * this.forward;
							this.TileYolkRectTransform[(int)num2].anchoredPosition = rectTransform.anchoredPosition;
							this.TileYolkRectTransform[(int)num2].SetParent(this.realmGroup, false);
							flag = true;
						}
						else
						{
							this.tempTileYolkGameObject[(int)num2] = null;
						}
					}
					else
					{
						ushort inKey = recordByIndex.yolkDeployIDs[(int)num2];
						YolkDeploy recordByKey2 = DataManager.MapDataController.YolkDeployTable.GetRecordByKey(inKey);
						cstring.ClearString();
						cstring.IntToFormat((long)recordByKey2.iconID, 3, false);
						cstring.AppendFormat("UI/LittleYolk_{0}");
						this.tempTileYolkABKey[(int)num2] = this.TileYolkABKey[(int)num2];
						assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int)num2]);
						if (this.tempTileYolkABKey[(int)num2] != this.TileYolkABKey[(int)num2])
						{
							this.tempTileYolkGameObject[(int)num2] = this.TileYolkGameObject[(int)num2];
							RectTransform rectTransform = this.tempTileYolkGameObject[(int)num2].transform as RectTransform;
							this.TileYolkGameObject[(int)num2] = (UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject);
							this.TileYolkGameObject[(int)num2].SetActive(this.tempTileYolkGameObject[(int)num2].activeSelf);
							this.TileYolkRectTransform[(int)num2] = (this.TileYolkGameObject[(int)num2].transform as RectTransform);
							this.TileYolkImage[(int)num2] = this.TileYolkGameObject[(int)num2].GetComponent<Image>();
							this.TileYolkImage[(int)num2].material.renderQueue = 2550;
							this.TileYolkImage[(int)num2].SetNativeSize();
							this.TileYolkRectTransform[(int)num2].localPosition = Vector3.forward * this.forward;
							this.TileYolkRectTransform[(int)num2].anchoredPosition = rectTransform.anchoredPosition;
							this.TileYolkRectTransform[(int)num2].SetParent(this.realmGroup, false);
							flag = true;
						}
						else
						{
							this.tempTileYolkGameObject[(int)num2] = null;
						}
					}
				}
			}
			else
			{
				this.tempTileYolkGameObject[(int)num2] = (this.TileYolkGameObject[(int)num2] = null);
				this.TileYolkRectTransform[(int)num2] = null;
				this.TileYolkImage[(int)num2] = null;
				this.tempTileYolkABKey[(int)num2] = (this.TileYolkABKey[(int)num2] = 0);
			}
			this.YOLK_POS[(int)num2] = DataManager.MapDataController.GetYolkPos(num2, num);
			Vector2[] yolk_POS2 = this.YOLK_POS;
			ushort num4 = num2;
			yolk_POS2[(int)num4].y = yolk_POS2[(int)num4].y + 1f;
			this.YOLK_MAPID[(int)num2] = new uint[9];
			this.YOLK_MAPID[(int)num2][0] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x, (int)this.YOLK_POS[(int)num2].y);
			this.YOLK_MAPID[(int)num2][1] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x + 1, (int)this.YOLK_POS[(int)num2].y - 1);
			this.YOLK_MAPID[(int)num2][2] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x - 1, (int)this.YOLK_POS[(int)num2].y - 1);
			this.YOLK_MAPID[(int)num2][3] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x + 2, (int)this.YOLK_POS[(int)num2].y - 2);
			this.YOLK_MAPID[(int)num2][4] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x, (int)this.YOLK_POS[(int)num2].y - 2);
			this.YOLK_MAPID[(int)num2][5] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x - 2, (int)this.YOLK_POS[(int)num2].y - 2);
			this.YOLK_MAPID[(int)num2][6] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x + 1, (int)this.YOLK_POS[(int)num2].y - 3);
			this.YOLK_MAPID[(int)num2][7] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x - 1, (int)this.YOLK_POS[(int)num2].y - 3);
			this.YOLK_MAPID[(int)num2][8] = (uint)GameConstants.TileMapPosToMapID((int)this.YOLK_POS[(int)num2].x, (int)this.YOLK_POS[(int)num2].y - 4);
			if (flag)
			{
				if (this.tickcolorlittleYolkIDCount > 0)
				{
					for (int j = 0; j < (int)this.tickcolorlittleYolkIDCount; j++)
					{
						if ((ushort)this.tickcolorlittleYolkID[j] == num2)
						{
							this.tickcolorlittleYolkIDCount -= 1;
							this.tickcolorlittleYolkID[j] = this.tickcolorlittleYolkID[(int)this.tickcolorlittleYolkIDCount];
							this.tickcolorlittleYolkID[(int)this.tickcolorlittleYolkIDCount] = 0;
							if (this.TileYolkImage[(int)num2] != null)
							{
								this.TileYolkImage[(int)num2].color = Color.white;
							}
							break;
						}
					}
				}
				if (this.TileYolkGameObject[(int)num2] != null && this.TileYolkGameObject[(int)num2].activeSelf)
				{
					if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Hunter)
					{
						this.tickcolorlittleYolkID[(int)this.tickcolorlittleYolkIDCount] = (byte)num2;
						this.tickcolorlittleYolkIDCount += 1;
						this.TileYolkImage[(int)num2].color = this.wolflittleYolkTickColor;
					}
					else if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Target)
					{
						this.tickcolorlittleYolkID[(int)this.tickcolorlittleYolkIDCount] = (byte)num2;
						this.tickcolorlittleYolkIDCount += 1;
						this.TileYolkImage[(int)num2].color = this.sheeplittleYolkTickColor;
					}
				}
			}
		}
		StringManager.Instance.DeSpawnString(cstring);
		if (this.tempTileYolkGameObject != null)
		{
			for (int k = 0; k < this.tempTileYolkGameObject.Length; k++)
			{
				if (this.tempTileYolkABKey[k] != 0)
				{
					AssetManager.UnloadAssetBundle(this.tempTileYolkABKey[k], true);
					this.tempTileYolkABKey[k] = 0;
				}
				if (this.tempTileYolkGameObject[k] != null)
				{
					UnityEngine.Object.Destroy(this.tempTileYolkGameObject[k]);
					this.tempTileYolkGameObject[k] = null;
				}
			}
		}
		return flag;
	}

	// Token: 0x06000BC9 RID: 3017 RVA: 0x001128F4 File Offset: 0x00110AF4
	public void resetYolkTickColor()
	{
		ushort checkKingdomID = (DataManager.MapDataController.FocusKingdomID != 0) ? DataManager.MapDataController.FocusKingdomID : 1;
		this.nowKvKKingdomType = ActivityManager.Instance.getKvKKingdomType(checkKingdomID);
		this.TickColor();
	}

	// Token: 0x06000BCA RID: 3018 RVA: 0x00112938 File Offset: 0x00110B38
	public void TickColor()
	{
		if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Hunter)
		{
			if (this.tickcolorbigYolkID == 0)
			{
				this.TileYolkImage[(int)this.tickcolorbigYolkID].color = this.wolfbigYolkTickColor;
			}
			for (int i = 0; i < (int)this.tickcolorlittleYolkIDCount; i++)
			{
				this.TileYolkImage[(int)this.tickcolorlittleYolkID[i]].color = this.wolflittleYolkTickColor;
			}
		}
		else if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Target)
		{
			if (this.tickcolorbigYolkID == 0)
			{
				this.TileYolkImage[(int)this.tickcolorbigYolkID].color = this.sheepbigYolkTickColor;
			}
			for (int j = 0; j < (int)this.tickcolorlittleYolkIDCount; j++)
			{
				this.TileYolkImage[(int)this.tickcolorlittleYolkID[j]].color = this.sheeplittleYolkTickColor;
			}
		}
		else
		{
			this.tickcolorbigYolkID = 40;
			if (this.TileYolkImage[0] != null)
			{
				this.TileYolkImage[0].color = Color.white;
			}
			for (int k = 0; k < (int)this.tickcolorlittleYolkIDCount; k++)
			{
				if (this.TileYolkImage[(int)this.tickcolorlittleYolkID[k]] != null)
				{
					this.TileYolkImage[(int)this.tickcolorlittleYolkID[k]].color = Color.white;
				}
				this.tickcolorlittleYolkID[k] = 0;
			}
			this.tickcolorlittleYolkIDCount = 0;
			for (int l = 0; l < this.TileYolkImage.Length; l++)
			{
				if (this.TileYolkImage[l] != null)
				{
					this.TileYolkImage[l].color = Color.white;
				}
			}
		}
	}

	// Token: 0x06000BCB RID: 3019 RVA: 0x00112AD4 File Offset: 0x00110CD4
	public int getYolkID(int mapID)
	{
		ushort kingdomID = (DataManager.MapDataController.FocusKingdomID != 0) ? DataManager.MapDataController.FocusKingdomID : 1;
		int num = -1;
		Vector2 tileMapPosbyMapID = GameConstants.getTileMapPosbyMapID(mapID);
		Vector2 vector = Vector2.zero;
		int i = 0;
		while (i < (int)DataManager.MapDataController.showYolkNum)
		{
			num = (int)DataManager.MapDataController.showYolkMapYolkID[i];
			vector = this.YOLK_POS[num] - tileMapPosbyMapID;
			if (Mathf.Abs(vector.x) <= this.w && Mathf.Abs(vector.y) <= this.h)
			{
				if (DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)DataManager.MapDataController.GetYolkMapID((ushort)num, kingdomID))].pointKind != 11)
				{
					return -1;
				}
				break;
			}
			else
			{
				i++;
			}
		}
		return num;
	}

	// Token: 0x04002771 RID: 10097
	public GameObject[] TileYolkGameObject = new GameObject[40];

	// Token: 0x04002772 RID: 10098
	public GameObject[] tempTileYolkGameObject;

	// Token: 0x04002773 RID: 10099
	public Vector2[] YOLK_POS = new Vector2[40];

	// Token: 0x04002774 RID: 10100
	public uint[][] YOLK_MAPID = new uint[40][];

	// Token: 0x04002775 RID: 10101
	private Transform realmGroup;

	// Token: 0x04002776 RID: 10102
	private RectTransform[] TileYolkRectTransform = new RectTransform[40];

	// Token: 0x04002777 RID: 10103
	private Image[] TileYolkImage = new Image[40];

	// Token: 0x04002778 RID: 10104
	private int[] TileYolkABKey = new int[40];

	// Token: 0x04002779 RID: 10105
	private byte[] tickcolorlittleYolkID = new byte[40];

	// Token: 0x0400277A RID: 10106
	private byte tickcolorlittleYolkIDCount;

	// Token: 0x0400277B RID: 10107
	private Color sheeplittleYolkTickColor = new Color32(byte.MaxValue, 109, 109, byte.MaxValue);

	// Token: 0x0400277C RID: 10108
	private Color wolflittleYolkTickColor = new Color32(235, 103, byte.MaxValue, byte.MaxValue);

	// Token: 0x0400277D RID: 10109
	private byte tickcolorbigYolkID = 40;

	// Token: 0x0400277E RID: 10110
	private Color sheepbigYolkTickColor = new Color32(byte.MaxValue, 109, 109, byte.MaxValue);

	// Token: 0x0400277F RID: 10111
	private Color wolfbigYolkTickColor = new Color32(216, 99, byte.MaxValue, byte.MaxValue);

	// Token: 0x04002780 RID: 10112
	private EKvKKingdomType nowKvKKingdomType = EKvKKingdomType.EKKT_Normal;

	// Token: 0x04002781 RID: 10113
	private float tickYolkImageColorSpeed;

	// Token: 0x04002782 RID: 10114
	private float left = -2800f;

	// Token: 0x04002783 RID: 10115
	private float right = 2800f;

	// Token: 0x04002784 RID: 10116
	private float up = 1200f;

	// Token: 0x04002785 RID: 10117
	private float down = -1200f;

	// Token: 0x04002786 RID: 10118
	private float offset = 170f;

	// Token: 0x04002787 RID: 10119
	private float LittleYolkoffset = 170f;

	// Token: 0x04002788 RID: 10120
	private float w = 6f;

	// Token: 0x04002789 RID: 10121
	private float h = 6f;

	// Token: 0x0400278A RID: 10122
	private float forward = 3584f;

	// Token: 0x0400278B RID: 10123
	private int[] tempTileYolkABKey;
}
