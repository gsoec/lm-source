using System;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02000280 RID: 640
public class WorldMap : MonoBehaviour
{
	// Token: 0x06000C41 RID: 3137 RVA: 0x00119B44 File Offset: 0x00117D44
	protected void Awake()
	{
		this.TileHeight = 128;
		int num = (int)(DataManager.MapDataController.WorldMaxX - DataManager.MapDataController.WorldMinX + 1);
		int num2 = (int)(DataManager.MapDataController.WorldMaxY - DataManager.MapDataController.WorldMinY + 1);
		this.TileMapInfoWidthMax = (ushort)num;
		this.TileMapInfoHeightMax = (ushort)num2;
		this.LoadTileMapFile();
		this.Canvasrectran = (GUIManager.Instance.m_UICanvas.transform as RectTransform);
		this.TileMapRectTransform = (base.transform as RectTransform);
		this.TileMapRectTransform.position = Vector3.forward * 2048f;
		this.TileMapRectTransform.sizeDelta = this.Canvasrectran.sizeDelta;
		this.TileMapRectTransform.anchoredPosition = Vector2.zero;
		this.TileSprites = base.gameObject.GetComponent<UISpritesArray>();
		this.kvkButtonSprite = this.TileSprites.GetSprite(9);
		this.titleButtonSprite = this.TileSprites.GetSprite(101);
		this.kvkButton = null;
		this.nowkvkGraphicImage = null;
		this.SetRect(16, 16);
		this.OnDragPos = -Vector2.zero;
		this.lastOnDragPos = -Vector2.zero;
		this.onDragTimer = 0.5f;
		this.updateBaseCenter();
	}

	// Token: 0x06000C42 RID: 3138 RVA: 0x00119C90 File Offset: 0x00117E90
	protected void OnDestroy()
	{
		DataManager.MapDataController.FocusWorldMapPos.x = (float)this.BoundStartX;
		DataManager.MapDataController.FocusWorldMapPos.y = (float)this.BoundStartY;
		int num = this.TileColMapStartIDOffset & (int)this.TileRowNumSubtractOne;
		int num2 = this.TileRowMapStartIDOffset & (int)this.TileColNumSubtractOne;
		DataManager.MapDataController.coloneWorldMapPos = this.TileRowGroupRectTransform[num].anchoredPosition + this.TileObjectRectTransform[num2][num].anchoredPosition;
		num = (this.TileColMapStartIDOffset + 1 & (int)this.TileRowNumSubtractOne);
		num2 = (this.TileRowMapStartIDOffset & (int)this.TileColNumSubtractOne);
		DataManager.MapDataController.coltwoWorldMapPos = this.TileRowGroupRectTransform[num].anchoredPosition + this.TileObjectRectTransform[num2][num].anchoredPosition;
		DataManager.MapDataController.StartID = this.StartID;
		this.RealmGroup_3DTransform = null;
		if (this.TileMapInfo != null)
		{
			Array.Clear(this.TileMapInfo, 0, this.TileMapInfo.Length);
		}
		if (this.TileRowGroupRectTransform != null)
		{
			Array.Clear(this.TileRowGroupRectTransform, 0, this.TileRowGroupRectTransform.Length);
		}
		if (this.TileObjectRectTransform != null)
		{
			for (int i = 0; i < this.TileObjectRectTransform.Length; i++)
			{
				Array.Clear(this.TileObjectRectTransform[i], 0, this.TileObjectRectTransform[i].Length);
				this.TileObjectRectTransform[i] = null;
			}
		}
		if (this.TileBaseRectTransform != null)
		{
			for (int j = 0; j < this.TileBaseRectTransform.Length; j++)
			{
				Array.Clear(this.TileBaseRectTransform[j], 0, this.TileBaseRectTransform[j].Length);
				this.TileBaseRectTransform[j] = null;
			}
		}
		if (this.OverTileBaseRectTransform != null)
		{
			for (int k = 0; k < this.OverTileBaseRectTransform.Length; k++)
			{
				Array.Clear(this.OverTileBaseRectTransform[k], 0, this.OverTileBaseRectTransform[k].Length);
				this.OverTileBaseRectTransform[k] = null;
			}
		}
		if (this.OverTileBaseGameObject != null)
		{
			for (int l = 0; l < this.OverTileBaseGameObject.Length; l++)
			{
				Array.Clear(this.OverTileBaseGameObject[l], 0, this.OverTileBaseGameObject[l].Length);
				this.OverTileBaseGameObject[l] = null;
			}
		}
		if (this.TileBaseImage != null)
		{
			for (int m = 0; m < this.TileBaseImage.Length; m++)
			{
				Array.Clear(this.TileBaseImage[m], 0, this.TileBaseImage[m].Length);
				this.TileBaseImage[m] = null;
			}
		}
		if (this.OverTileBaseImage != null)
		{
			for (int n = 0; n < this.OverTileBaseImage.Length; n++)
			{
				Array.Clear(this.OverTileBaseImage[n], 0, this.OverTileBaseImage[n].Length);
				this.OverTileBaseImage[n] = null;
			}
		}
		if (this.TileSprites != null)
		{
			UnityEngine.Object.Destroy(this.TileSprites.gameObject);
		}
		this.TileSprites = null;
		this.TileRowGroupRectTransform = null;
		this.TileObjectRectTransform = null;
		this.TileBaseRectTransform = null;
		this.OverTileBaseRectTransform = null;
		this.OverTileBaseGameObject = null;
		this.TileBaseImage = null;
		this.OverTileBaseImage = null;
		this.TileMapInfo = null;
		this.Canvasrectran = null;
	}

	// Token: 0x06000C43 RID: 3139 RVA: 0x00119FD0 File Offset: 0x001181D0
	protected void Update()
	{
		DataManager.MapDataController.UpdateWaitKingdom();
		if (this.inputState == WorldMap.InPutState.Zoom)
		{
			this.ZoomTile();
			return;
		}
		if (this.inputState == WorldMap.InPutState.KingdomUp)
		{
			Color color = this.nowWorldMapImage.color;
			float num = this.clickspeed * Time.deltaTime;
			this.nowWorldMapImage.color = color + new Color(num, num, num, 0f);
			if (this.nowWorldMapImage.color.g >= 1f)
			{
				this.inputState = WorldMap.InPutState.KingdomDown;
			}
			return;
		}
		if (this.inputState == WorldMap.InPutState.KingdomDown)
		{
			Color color2 = this.nowWorldMapImage.color;
			float num2 = -this.clickspeed * Time.deltaTime;
			this.nowWorldMapImage.color = color2 + new Color(num2, num2, num2, 0f);
			if (this.nowWorldMapImage.color.g <= 0f)
			{
				DataManager.MapDataController.FocusKingdomID = this.nowWorldMapImage.kingdomID;
				byte b = 0;
				if (DataManager.MapDataController.GetWorldKingdomTableID(this.nowWorldMapImage.kingdomID, out b))
				{
					DataManager.MapDataController.FocusKingdomPeriod = DataManager.MapDataController.WorldKingdomTable[(int)b].kingdomPeriod;
				}
				this.nowWorldMapImage = null;
				this.inputState = WorldMap.InPutState.None;
				if (DataManager.MapDataController.gotoKingdomState > 0)
				{
					DataManager.msgBuffer[0] = 121;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
				else
				{
					GUIManager.Instance.HideUILock(EUILock.Normal);
				}
			}
			return;
		}
		if (this.kvkButton != null)
		{
			float num3 = 1.56f;
			if (this.kvkButtonSpeed > 0f && this.kvkButton.localScale.x < num3)
			{
				this.kvkButton.localScale += Vector3.one * Time.deltaTime * this.kvkButtonSpeed;
				if (this.kvkButton.localScale.x > num3)
				{
					this.kvkButton.localScale = Vector3.one * num3;
				}
			}
			float num4 = 1.3f;
			if (this.kvkButtonSpeed < 0f && this.kvkButton.localScale.x > num4)
			{
				this.kvkButton.localScale += Vector3.one * Time.deltaTime * this.kvkButtonSpeed;
				if (this.kvkButton.localScale.x < num4)
				{
					this.kvkButton.localScale = Vector3.one * num4;
					if (this.bkvkButtonClick)
					{
						this.bkvkButtonClick = false;
						DataManager.Instance.MoveTo(this.nowkvkGraphicImage.kingdomID, -1);
					}
					if (this.btitleButtonClick)
					{
						this.btitleButtonClick = false;
						TitleManager.Instance.OpenTitleListN(this.nowkvkGraphicImage.kingdomID);
					}
					this.kvkButton = null;
					this.nowkvkGraphicImage = null;
				}
			}
			return;
		}
		this.MoveTileBase();
		if (this.OnDragPos.x > -1f && this.OnDragPos.y > -1f)
		{
			if (this.OnDragPos != this.lastOnDragPos)
			{
				this.lastOnDragPos = this.OnDragPos;
			}
			else
			{
				this.onDragTimer += Time.deltaTime;
				if (this.onDragTimer > 0.5f)
				{
					this.onDragTimer = 0f;
					this.OnDragPos = (this.lastOnDragPos = -Vector2.one);
					this.RequestMapdata(Vector2.zero, false);
				}
			}
		}
		if (this.Movedelta != Vector2.zero)
		{
			for (int i = 0; i < 2; i++)
			{
				if (this.Movedelta[i] != 0f)
				{
					ref Vector2 ptr = ref this.Movedelta;
					int index2;
					int index = index2 = i;
					float num5 = ptr[index2];
					this.Movedelta[index] = num5 * this.MovedeltaFactor;
					if (Math.Abs(this.Movedelta[i]) < 0.01f)
					{
						this.Movedelta[i] = 0f;
					}
				}
			}
			float num6 = 0.95f;
			if (this.MovedeltaFactor < num6)
			{
				this.MovedeltaFactor += Time.deltaTime * 49f;
				if (this.MovedeltaFactor > num6)
				{
					this.MovedeltaFactor = num6;
				}
			}
		}
	}

	// Token: 0x06000C44 RID: 3140 RVA: 0x0011A47C File Offset: 0x0011867C
	public void OnDrag(PointerEventData eventData)
	{
		WorldMap.InPutState inPutState = this.inputState;
		if (inPutState != WorldMap.InPutState.Click)
		{
			if (inPutState == WorldMap.InPutState.Drag)
			{
				this.Movedelta = eventData.delta * (this.TileMapRectTransform.sizeDelta.y / (float)Screen.height);
				this.MoveTileBase();
				this.OnDragPos = eventData.position;
			}
		}
		else if (eventData.pointerPress != this.kvkButton)
		{
			if ((eventData.position - eventData.pressPosition).magnitude > 50f)
			{
				this.inputState = WorldMap.InPutState.Drag;
				this.lastOnDragPos = -Vector2.one;
				this.onDragTimer = 0f;
				if (this.btitleHintShow)
				{
					GUIManager.Instance.m_Hint.Hide(true);
					this.btitleHintShow = false;
				}
			}
			if (this.kvkButton != null && this.kvkButtonSpeed > 0f)
			{
				this.kvkButtonSpeed *= -1f;
			}
		}
	}

	// Token: 0x06000C45 RID: 3141 RVA: 0x0011A59C File Offset: 0x0011879C
	public void OnPointerDown(PointerEventData eventData)
	{
		switch (this.inputState)
		{
		case WorldMap.InPutState.None:
			this.inputState = WorldMap.InPutState.Click;
			if (this.kvkButton == null && eventData.pointerEnter != null && eventData.pointerEnter.activeSelf)
			{
				WorldMapGraphicImage component = eventData.pointerEnter.GetComponent<WorldMapGraphicImage>();
				if (component != null)
				{
					if (this.kvkButtonSprite == component.sprite || this.titleButtonSprite == component.sprite)
					{
						if (this.kvkButtonSpeed < 0f)
						{
							this.kvkButtonSpeed *= -1f;
						}
						this.kvkButton = eventData.pointerEnter.transform;
						this.nowkvkGraphicImage = component;
					}
					else
					{
						Vector2 position = Vector2.zero;
						for (KINGDOM_DESIGNATION kingdom_DESIGNATION = KINGDOM_DESIGNATION.KD_1; kingdom_DESIGNATION < KINGDOM_DESIGNATION.KD_MAX; kingdom_DESIGNATION += 1)
						{
							if (component.sprite == this.TileSprites.GetSprite((int)(60 + kingdom_DESIGNATION)))
							{
								this.nowkvkGraphicImage = component;
								position = Camera.main.ScreenToViewportPoint(eventData.position);
								position.x *= this.Canvasrectran.sizeDelta.x;
								position.y *= this.Canvasrectran.sizeDelta.y;
								position.y -= this.Canvasrectran.sizeDelta.y - 30f * this.TileBaseScale;
								GUIManager.Instance.m_Hint.Show(position, UIHintStyle.eHintSimple, 1, 300f, 22, 11035, (int)component.kingdomID);
								this.btitleHintShow = true;
								return;
							}
						}
					}
				}
			}
			if (this.btitleHintShow)
			{
				GUIManager.Instance.m_Hint.Hide(true);
				this.btitleHintShow = false;
			}
			break;
		case WorldMap.InPutState.Click:
		case WorldMap.InPutState.Drag:
			if (Input.touchCount > 1)
			{
				this.inputState = WorldMap.InPutState.Zoom;
				if (this.btitleHintShow)
				{
					GUIManager.Instance.m_Hint.Hide(true);
					this.btitleHintShow = false;
				}
			}
			break;
		}
		this.Movedelta = Vector2.zero;
	}

	// Token: 0x06000C46 RID: 3142 RVA: 0x0011A7E8 File Offset: 0x001189E8
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this.kvkButton != null && this.kvkButtonSpeed > 0f)
		{
			this.kvkButtonSpeed *= -1f;
		}
		switch (this.inputState)
		{
		case WorldMap.InPutState.Click:
			if (this.kvkButton != null && eventData.pointerEnter == this.kvkButton.gameObject)
			{
				WorldMapGraphicImage component = eventData.pointerEnter.GetComponent<WorldMapGraphicImage>();
				if (component != null && component.sprite == this.titleButtonSprite)
				{
					this.btitleButtonClick = true;
				}
				else if (DataManager.Instance.bHaveWarBuff)
				{
					GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9943u), 255, true);
				}
				else
				{
					this.bkvkButtonClick = true;
				}
				this.inputState = WorldMap.InPutState.None;
			}
			else
			{
				Vector2 in_TileBaseID = this.PosToTileBaseID(eventData.position);
				uint tileMapInfoIDbyStartID = (uint)this.getTileMapInfoIDbyStartID(in_TileBaseID);
				if (in_TileBaseID.x < 0f)
				{
					in_TileBaseID = Vector2.zero;
				}
				int num = this.TileColMapStartIDOffset + (int)in_TileBaseID.y & (int)this.TileRowNumSubtractOne;
				int num2 = this.TileRowMapStartIDOffset + (int)in_TileBaseID.x & (int)this.TileColNumSubtractOne;
				this.inputState = WorldMap.InPutState.None;
				if (eventData.pointerEnter != null && eventData.pointerEnter.activeSelf)
				{
					WorldMapImage component2 = eventData.pointerEnter.GetComponent<WorldMapImage>();
					if (component2 != null)
					{
						this.inputState = WorldMap.InPutState.KingdomUp;
						GUIManager.Instance.ShowUILock(EUILock.Normal);
						if (this.kingdomYolk != null)
						{
							if (this.kingdomYolk.tickYolkImage == component2)
							{
								this.kingdomYolk.tickYolkImage.color = Color.black;
								this.kingdomYolk.tickYolkImage = null;
							}
							else
							{
								bool flag = true;
								for (int i = 0; i < this.kingdomYolk.sheepTickImageNum; i++)
								{
									if (this.kingdomYolk.sheepTickImage[i] != null && this.kingdomYolk.sheepTickImage[i] == component2)
									{
										this.kingdomYolk.sheepTickImageNum--;
										this.kingdomYolk.sheepTickImage[i].color = Color.black;
										this.kingdomYolk.sheepTickImage[i] = this.kingdomYolk.sheepTickImage[this.kingdomYolk.sheepTickImageNum];
										this.kingdomYolk.sheepTickImage[this.kingdomYolk.sheepTickImageNum] = null;
										flag = false;
										break;
									}
								}
								if (flag)
								{
									for (int j = 0; j < this.kingdomYolk.wolfTickImageNum; j++)
									{
										if (this.kingdomYolk.wolfTickImage[j] != null && this.kingdomYolk.wolfTickImage[j] == component2)
										{
											this.kingdomYolk.wolfTickImageNum--;
											this.kingdomYolk.wolfTickImage[j].color = Color.black;
											this.kingdomYolk.wolfTickImage[j] = this.kingdomYolk.wolfTickImage[this.kingdomYolk.wolfTickImageNum];
											this.kingdomYolk.wolfTickImage[this.kingdomYolk.wolfTickImageNum] = null;
											break;
										}
									}
								}
							}
						}
						this.nowWorldMapImage = component2;
						MapManager mapDataController = DataManager.MapDataController;
						mapDataController.gotoKingdomState += 1;
						DataManager.msgBuffer[0] = 114;
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						DataManager.msgBuffer[0] = 125;
						GameConstants.GetBytes(this.nowWorldMapImage.kingdomID, DataManager.msgBuffer, 1);
						GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					}
					else
					{
						WorldMapText component3 = eventData.pointerEnter.GetComponent<WorldMapText>();
						if (component3 != null)
						{
							this.inputState = WorldMap.InPutState.KingdomUp;
							GUIManager.Instance.ShowUILock(EUILock.Normal);
							this.nowWorldMapImage = this.kingdomYolk.getYolkImage(component3.row, component3.col);
							if (this.kingdomYolk.tickYolkImage == this.nowWorldMapImage)
							{
								this.kingdomYolk.tickYolkImage.color = Color.black;
								this.kingdomYolk.tickYolkImage = null;
							}
							else
							{
								bool flag2 = true;
								for (int k = 0; k < this.kingdomYolk.sheepTickImageNum; k++)
								{
									if (this.kingdomYolk.sheepTickImage[k] != null && this.kingdomYolk.sheepTickImage[k] == this.nowWorldMapImage)
									{
										this.kingdomYolk.sheepTickImageNum--;
										this.kingdomYolk.sheepTickImage[k].color = Color.black;
										this.kingdomYolk.sheepTickImage[k] = this.kingdomYolk.sheepTickImage[this.kingdomYolk.sheepTickImageNum];
										this.kingdomYolk.sheepTickImage[this.kingdomYolk.sheepTickImageNum] = null;
										flag2 = false;
										break;
									}
								}
								if (flag2)
								{
									for (int l = 0; l < this.kingdomYolk.wolfTickImageNum; l++)
									{
										if (this.kingdomYolk.wolfTickImage[l] != null && this.kingdomYolk.wolfTickImage[l] == this.nowWorldMapImage)
										{
											this.kingdomYolk.wolfTickImageNum--;
											this.kingdomYolk.wolfTickImage[l].color = Color.black;
											this.kingdomYolk.wolfTickImage[l] = this.kingdomYolk.wolfTickImage[this.kingdomYolk.wolfTickImageNum];
											this.kingdomYolk.wolfTickImage[this.kingdomYolk.wolfTickImageNum] = null;
											break;
										}
									}
								}
							}
							MapManager mapDataController2 = DataManager.MapDataController;
							mapDataController2.gotoKingdomState += 1;
							DataManager.msgBuffer[0] = 114;
							GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
							DataManager.msgBuffer[0] = 125;
							GameConstants.GetBytes(this.nowWorldMapImage.kingdomID, DataManager.msgBuffer, 1);
							GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						}
					}
				}
			}
			break;
		case WorldMap.InPutState.Drag:
		{
			this.Movedelta = eventData.delta * (this.TileMapRectTransform.sizeDelta.y / (float)Screen.height);
			this.MovedeltaFactor = 0.25f;
			this.inputState = WorldMap.InPutState.None;
			this.OnDragPos = -Vector2.one;
			Vector2 vector = this.Movedelta;
			Vector2 movedelta = this.Movedelta;
			float num3 = this.MovedeltaFactor;
			while (movedelta != Vector2.zero)
			{
				for (int m = 0; m < 2; m++)
				{
					if (movedelta[m] != 0f)
					{
						ref Vector2 ptr = ref movedelta;
						int index2;
						int index = index2 = m;
						float num4 = ptr[index2];
						movedelta[index] = num4 * num3;
						if (Math.Abs(movedelta[m]) < 0.01f)
						{
							movedelta[m] = 0f;
						}
					}
				}
				vector += movedelta;
				float num5 = 0.95f;
				if (num3 < num5)
				{
					num3 += Time.deltaTime * 49f;
					if (num3 > num5)
					{
						num3 = num5;
					}
				}
			}
			vector /= DataManager.MapDataController.worldZoomSize;
			this.CheckLimit(this.StartID % (int)this.TileMapInfoWidthMax, this.StartID / (int)this.TileMapInfoWidthMax, ref vector);
			this.RequestMapdata(vector, false);
			break;
		}
		case WorldMap.InPutState.Zoom:
			if (Input.touchCount == 1)
			{
				this.inputState = WorldMap.InPutState.Drag;
				if (this.btitleHintShow)
				{
					GUIManager.Instance.m_Hint.Hide(true);
					this.btitleHintShow = false;
				}
			}
			else if (Input.touchCount < 1)
			{
				this.inputState = WorldMap.InPutState.None;
				if (this.btitleHintShow)
				{
					GUIManager.Instance.m_Hint.Hide(true);
					this.btitleHintShow = false;
				}
			}
			break;
		}
	}

	// Token: 0x06000C47 RID: 3143 RVA: 0x0011B034 File Offset: 0x00119234
	public void UpdateKingdom(byte kingdomtableid, byte updatekind)
	{
		if ((int)kingdomtableid >= DataManager.MapDataController.WorldKingdomTable.Length)
		{
			return;
		}
		KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomID);
		int num = (int)(recordByKey.worldPosX - DataManager.MapDataController.WorldMinX) - this.BoundStartX;
		if (num < 0 || num >= (int)this.TileColNum)
		{
			return;
		}
		int num2 = (int)(recordByKey.worldPosY - DataManager.MapDataController.WorldMinY) - this.BoundStartY;
		if (num2 < 0 || num2 >= (int)this.TileRowNum)
		{
			return;
		}
		int num3 = this.TileColMapStartIDOffset + num2 & (int)this.TileRowNumSubtractOne;
		int num4 = this.TileRowMapStartIDOffset + num & (int)this.TileColNumSubtractOne;
		Vector2 pos = this.TileRowGroupRectTransform[num3].anchoredPosition + this.TileObjectRectTransform[num4][num3].anchoredPosition;
		if (updatekind != 19)
		{
			if (updatekind != 20)
			{
				if (updatekind != 40 && updatekind != 41)
				{
					if (updatekind == 25)
					{
						pos = this.TileRowGroupRectTransform[num3].anchoredPosition + this.TileObjectRectTransform[num4][num3].anchoredPosition;
						this.kingdomYolk.setYolkImage((int)recordByKey.KingdomMapKey, num3, num4, pos);
						this.kingdomName.setName(kingdomtableid, num3, num4, Color.white, pos);
						int num5 = 0;
						byte b = (byte)(DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomFlag >> 3);
						if (b > 0)
						{
							num5 = 8;
						}
						else if (DataManager.Instance.RoleAttr.WorldTitle_Personal == 1 && TitleManager.Instance.CheckGivetNTile() && DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomPeriod < KINGDOM_PERIOD.KP_WORLD_WAR)
						{
							num5 = 4;
						}
						if (recordByKey.KingdomMapKey == DataManager.MapDataController.OtherKingdomData.kingdomID)
						{
							EKvKKingdomType kvKKingdomType = ActivityManager.Instance.getKvKKingdomType(recordByKey.KingdomMapKey);
							if (kvKKingdomType == EKvKKingdomType.EKKT_Target)
							{
								num5 += 16;
							}
							else if (kvKKingdomType == EKvKKingdomType.EKKT_Hunter)
							{
								num5 += 32;
							}
							this.kingdomGraphic.setGraphicImage(1 + num5, num3, num4, pos, (int)recordByKey.mapID, recordByKey.KingdomMapKey, b);
						}
						else if ((DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && recordByKey.KingdomMapKey == DataManager.MapDataController.kingdomData.kingdomID) || (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && this.CheckShowTransmission(recordByKey.KingdomMapKey) && DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomPeriod == KINGDOM_PERIOD.KP_KVK))
						{
							EKvKKingdomType kvKKingdomType2 = ActivityManager.Instance.getKvKKingdomType(recordByKey.KingdomMapKey);
							if (kvKKingdomType2 == EKvKKingdomType.EKKT_Target)
							{
								num5 += 16;
							}
							else if (kvKKingdomType2 == EKvKKingdomType.EKKT_Hunter)
							{
								num5 += 32;
							}
							this.kingdomGraphic.setGraphicImage(2 + num5, num3, num4, pos, (int)recordByKey.mapID, recordByKey.KingdomMapKey, b);
						}
						else
						{
							this.kingdomGraphic.setGraphicImage(0 + num5, num3, num4, pos, (int)recordByKey.mapID, recordByKey.KingdomMapKey, b);
						}
						if (DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && (DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomFlag & 2) != 0)
						{
							this.effect.setEffect(1, num3, num4, pos, 0);
						}
						else
						{
							this.effect.setEffect(0, num3, num4, pos, 0);
						}
					}
				}
				else
				{
					this.kingdomName.setName(kingdomtableid, num3, num4, Color.white, pos);
					if (DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && (DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomFlag & 2) != 0)
					{
						this.effect.setEffect(1, num3, num4, pos, 0);
					}
					else
					{
						this.effect.setEffect(0, num3, num4, pos, 0);
					}
				}
			}
			else
			{
				pos = this.TileRowGroupRectTransform[num3].anchoredPosition + this.TileObjectRectTransform[num4][num3].anchoredPosition;
				this.kingdomYolk.setYolkImage((int)recordByKey.KingdomMapKey, num3, num4, pos);
				this.kingdomName.setName(kingdomtableid, num3, num4, Color.white, pos);
				int num5 = 0;
				byte b = (byte)(DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomFlag >> 3);
				if (b > 0)
				{
					num5 = 8;
				}
				else if (DataManager.Instance.RoleAttr.WorldTitle_Personal == 1 && TitleManager.Instance.CheckGivetNTile() && DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomPeriod < KINGDOM_PERIOD.KP_WORLD_WAR)
				{
					num5 = 4;
				}
				if (recordByKey.KingdomMapKey == DataManager.MapDataController.OtherKingdomData.kingdomID)
				{
					EKvKKingdomType kvKKingdomType3 = ActivityManager.Instance.getKvKKingdomType(recordByKey.KingdomMapKey);
					if (kvKKingdomType3 == EKvKKingdomType.EKKT_Target)
					{
						num5 += 16;
					}
					else if (kvKKingdomType3 == EKvKKingdomType.EKKT_Hunter)
					{
						num5 += 32;
					}
					this.kingdomGraphic.setGraphicImage(1 + num5, num3, num4, pos, (int)recordByKey.mapID, recordByKey.KingdomMapKey, b);
				}
				else if ((DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && recordByKey.KingdomMapKey == DataManager.MapDataController.kingdomData.kingdomID) || (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && this.CheckShowTransmission(recordByKey.KingdomMapKey) && DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomPeriod == KINGDOM_PERIOD.KP_KVK))
				{
					EKvKKingdomType kvKKingdomType4 = ActivityManager.Instance.getKvKKingdomType(recordByKey.KingdomMapKey);
					if (kvKKingdomType4 == EKvKKingdomType.EKKT_Target)
					{
						num5 += 16;
					}
					else if (kvKKingdomType4 == EKvKKingdomType.EKKT_Hunter)
					{
						num5 += 32;
					}
					this.kingdomGraphic.setGraphicImage(2 + num5, num3, num4, pos, (int)recordByKey.mapID, recordByKey.KingdomMapKey, b);
				}
				else
				{
					this.kingdomGraphic.setGraphicImage(0 + num5, num3, num4, pos, (int)recordByKey.mapID, recordByKey.KingdomMapKey, b);
				}
			}
		}
		else
		{
			this.kingdomName.setName(kingdomtableid, num3, num4, Color.white, pos);
			int num5 = 0;
			byte b = (byte)(DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomFlag >> 3);
			if (b > 0)
			{
				num5 = 8;
			}
			else if (DataManager.Instance.RoleAttr.WorldTitle_Personal == 1 && TitleManager.Instance.CheckGivetNTile() && DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomPeriod < KINGDOM_PERIOD.KP_WORLD_WAR)
			{
				num5 = 4;
			}
			if (recordByKey.KingdomMapKey == DataManager.MapDataController.OtherKingdomData.kingdomID)
			{
				EKvKKingdomType kvKKingdomType5 = ActivityManager.Instance.getKvKKingdomType(recordByKey.KingdomMapKey);
				if (kvKKingdomType5 == EKvKKingdomType.EKKT_Target)
				{
					num5 += 16;
				}
				else if (kvKKingdomType5 == EKvKKingdomType.EKKT_Hunter)
				{
					num5 += 32;
				}
				this.kingdomGraphic.setGraphicImage(1 + num5, num3, num4, pos, (int)recordByKey.mapID, recordByKey.KingdomMapKey, b);
			}
			else if ((DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && recordByKey.KingdomMapKey == DataManager.MapDataController.kingdomData.kingdomID) || (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && this.CheckShowTransmission(recordByKey.KingdomMapKey) && DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomPeriod == KINGDOM_PERIOD.KP_KVK))
			{
				EKvKKingdomType kvKKingdomType6 = ActivityManager.Instance.getKvKKingdomType(recordByKey.KingdomMapKey);
				if (kvKKingdomType6 == EKvKKingdomType.EKKT_Target)
				{
					num5 += 16;
				}
				else if (kvKKingdomType6 == EKvKKingdomType.EKKT_Hunter)
				{
					num5 += 32;
				}
				this.kingdomGraphic.setGraphicImage(2 + num5, num3, num4, pos, (int)recordByKey.mapID, recordByKey.KingdomMapKey, b);
			}
			else
			{
				this.kingdomGraphic.setGraphicImage(0 + num5, num3, num4, pos, (int)recordByKey.mapID, recordByKey.KingdomMapKey, b);
			}
			if (DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && (DataManager.MapDataController.WorldKingdomTable[(int)kingdomtableid].kingdomFlag & 2) != 0)
			{
				this.effect.setEffect(1, num3, num4, pos, 0);
			}
			else
			{
				this.effect.setEffect(0, num3, num4, pos, 0);
			}
		}
	}

	// Token: 0x06000C48 RID: 3144 RVA: 0x0011B8F4 File Offset: 0x00119AF4
	public bool CheckShowTransmission(ushort mkingdomID)
	{
		bool result = false;
		if ((mkingdomID == DataManager.MapDataController.kingdomData.kingdomID || ActivityManager.Instance.GetKvKState() == EActivityState.EAS_Run) && (!ActivityManager.Instance.IsMatchKvk() || ActivityManager.Instance.IsMatchKvk_kingdom(mkingdomID)))
		{
			result = true;
		}
		else if (mkingdomID != DataManager.MapDataController.kingdomData.kingdomID && ActivityManager.Instance.GetKvKState() == EActivityState.EAS_Run && ActivityManager.Instance.IsMatchKvk_kingdom(mkingdomID))
		{
			result = true;
		}
		return result;
	}

	// Token: 0x06000C49 RID: 3145 RVA: 0x0011B988 File Offset: 0x00119B88
	public void setKingdomYolk(WorldMapYolk kingdomYolkLayout)
	{
		this.kingdomYolk = kingdomYolkLayout;
		this.kingdomYolk.IniYolkImag((int)this.TileRowNum, (int)this.TileColNum, this.TileBaseScale, this.TileSprites.m_Image.material);
	}

	// Token: 0x06000C4A RID: 3146 RVA: 0x0011B9CC File Offset: 0x00119BCC
	public void setKingdomName(WorldMapName worldMapNameLayout)
	{
		this.kingdomName = worldMapNameLayout;
		this.kingdomName.IniName((int)this.TileRowNum, (int)this.TileColNum, this.TileBaseScale);
	}

	// Token: 0x06000C4B RID: 3147 RVA: 0x0011BA00 File Offset: 0x00119C00
	public void setKingdomGraphic(WorldMapGraphic worldMapGraphicLayout)
	{
		this.kingdomGraphic = worldMapGraphicLayout;
		this.kingdomGraphic.IniGraphicImag((int)this.TileRowNum, (int)this.TileColNum, this.TileBaseScale);
	}

	// Token: 0x06000C4C RID: 3148 RVA: 0x0011BA34 File Offset: 0x00119C34
	public void setEffect(WorldMapEffect mapEffectLayout)
	{
		this.effect = mapEffectLayout;
		this.effect.IniEffect((int)this.TileRowNum, (int)this.TileColNum, this.TileBaseScale);
	}

	// Token: 0x06000C4D RID: 3149 RVA: 0x0011BA68 File Offset: 0x00119C68
	public void setRealmGroup_3DTransform(Transform mapLine3DTransform)
	{
		this.RealmGroup_3DTransform = mapLine3DTransform;
	}

	// Token: 0x06000C4E RID: 3150 RVA: 0x0011BA74 File Offset: 0x00119C74
	public void setLayoutPosition(int rowsatrt, int rowend, int colstart, int colend)
	{
		if (this.kingdomName != null)
		{
			for (int i = rowsatrt; i < rowend; i++)
			{
				int num = this.TileColMapStartIDOffset + i & (int)this.TileRowNumSubtractOne;
				for (int j = colstart; j < colend; j++)
				{
					int num2 = this.TileRowMapStartIDOffset + j & (int)this.TileColNumSubtractOne;
					Vector2 pos = this.TileRowGroupRectTransform[num].anchoredPosition + this.TileObjectRectTransform[num2][num].anchoredPosition;
					this.kingdomYolk.setYolkImage(num, num2, pos);
					this.kingdomName.setName(num, num2, pos);
					this.kingdomGraphic.setGraphicImage(num, num2, pos);
					this.effect.setEffect(num, num2, pos);
				}
			}
		}
	}

	// Token: 0x06000C4F RID: 3151 RVA: 0x0011BB34 File Offset: 0x00119D34
	public bool MovebyTileMapPos(int in_posx, int in_posy, bool bsend = true)
	{
		if (GameConstants.CheckTileMapPos(in_posx, in_posy))
		{
			int num = this.TileColMapStartIDOffset + (int)this.BaseCenterID.y & (int)this.TileRowNumSubtractOne;
			int num2 = this.TileRowMapStartIDOffset + (int)this.BaseCenterID.x & (int)this.TileColNumSubtractOne;
			this.Movedelta.y = (((float)in_posy - this.centerID.y) * (float)(this.TileHeight >> 1) - this.TileRowGroupRectTransform[num].anchoredPosition.y) * DataManager.MapDataController.worldZoomSize;
			this.Movedelta.x = ((this.centerID.x - (float)in_posx) * (float)this.TileHeight - this.TileObjectRectTransform[num2][num].anchoredPosition.x) * DataManager.MapDataController.worldZoomSize;
			this.MoveTileBase();
			this.Movedelta = Vector2.zero;
			if (bsend)
			{
				this.RequestMapdata(this.Movedelta, false);
			}
			return true;
		}
		return false;
	}

	// Token: 0x06000C50 RID: 3152 RVA: 0x0011BC34 File Offset: 0x00119E34
	public void setGoHomeButtonPos(GAME_PLAYER_NEWS buttonmod)
	{
		this.goHomeButtonOffset = this.TileMapRectTransform.sizeDelta * 0.5f;
		if (buttonmod == GAME_PLAYER_NEWS.COSMOS_GoHomePosIn)
		{
			this.goHomeButtonOffset += this.inpos;
		}
		else
		{
			this.goHomeButtonOffset += this.outpos;
		}
		this.updateGoHomeButtonPos();
	}

	// Token: 0x06000C51 RID: 3153 RVA: 0x0011BCA0 File Offset: 0x00119EA0
	public void updateGoHomeButtonPos()
	{
		Vector2 zero = Vector2.zero;
		zero.x = Mathf.Round(this.goHomeButtonOffset.x / ((float)this.TileHeight * DataManager.MapDataController.worldZoomSize));
		zero.y = Mathf.Round(this.goHomeButtonOffset.y / ((float)(this.TileHeight >> 1) * DataManager.MapDataController.worldZoomSize));
		DataManager.msgBuffer[0] = 120;
		GameConstants.GetBytes(zero.x, DataManager.msgBuffer, 1);
		GameConstants.GetBytes(zero.y, DataManager.msgBuffer, 5);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06000C52 RID: 3154 RVA: 0x0011BD44 File Offset: 0x00119F44
	public bool RequestMapdata(Vector2 offset, bool renew = false)
	{
		int num = (offset.x <= 0f) ? Mathf.FloorToInt(offset.x * 0.5f / (float)this.TileHeight) : Mathf.CeilToInt(offset.x * 0.5f / (float)this.TileHeight);
		int num2 = (offset.y <= 0f) ? Mathf.FloorToInt(offset.y / (float)this.TileHeight) : Mathf.CeilToInt(offset.y / (float)this.TileHeight);
		num2 *= 2;
		int num3 = this.BoundStartX + num;
		if (num3 < 0)
		{
			num3 = 0;
		}
		int num4 = this.BoundStartY + num2;
		if (num4 < 0)
		{
			num4 = 0;
		}
		int num5 = this.BoundStartX + (int)this.TileColNumSubtractOne + num;
		if (num5 >= (int)this.TileMapInfoWidthMax)
		{
			num5 = (int)(this.TileMapInfoWidthMax - 1);
		}
		int num6 = this.BoundStartY + (int)this.TileRowNumSubtractOne + num2;
		if (num6 >= (int)this.TileMapInfoHeightMax)
		{
			num6 = (int)(this.TileMapInfoHeightMax - 1);
		}
		DataManager.MapDataController.RequestKingdomData(num3, num4, num5, num6);
		return true;
	}

	// Token: 0x06000C53 RID: 3155 RVA: 0x0011BE64 File Offset: 0x0011A064
	public void CheckCenterPos()
	{
		this.updateBaseCenter();
		int tileMapInfoIDbyStartID = this.getTileMapInfoIDbyStartID(this.BaseCenterID);
		if (this.centerMapID != tileMapInfoIDbyStartID)
		{
			this.centerMapID = tileMapInfoIDbyStartID;
			this.centerID.y = (float)(this.centerMapID / (int)this.TileMapInfoWidthMax);
			this.centerID.x = (float)(this.centerMapID % (int)this.TileMapInfoWidthMax * 2 + ((int)this.centerID.y & 1));
		}
		Vector2 zero = Vector2.zero;
		int num = this.TileColMapStartIDOffset + (int)this.BaseCenterID.y & (int)this.TileRowNumSubtractOne;
		int num2 = this.TileRowMapStartIDOffset + (int)this.BaseCenterID.x & (int)this.TileColNumSubtractOne;
		zero.y = this.TileRowGroupRectTransform[num].anchoredPosition.y / (float)(this.TileHeight >> 1);
		zero.x = this.TileObjectRectTransform[num2][num].anchoredPosition.x / (float)this.TileHeight;
		DataManager.msgBuffer[0] = 122;
		GameConstants.GetBytes(this.centerID.x, DataManager.msgBuffer, 1);
		GameConstants.GetBytes(this.centerID.y, DataManager.msgBuffer, 5);
		GameConstants.GetBytes(zero.x, DataManager.msgBuffer, 9);
		GameConstants.GetBytes(zero.y, DataManager.msgBuffer, 13);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		zero.y = (((float)this.BoundStartY + this.BaseCenterID.y <= (float)(this.TileMapInfoHeightMax - 1)) ? (((this.homePos.y - this.centerID.y) * (float)(this.TileHeight >> 1) - this.TileRowGroupRectTransform[num].anchoredPosition.y) * DataManager.MapDataController.worldZoomSize * 2f) : (((this.homePos.y - this.centerID.y - (float)this.TileMapInfoHeightMax) * (float)(this.TileHeight >> 1) - this.TileRowGroupRectTransform[num].anchoredPosition.y) * DataManager.MapDataController.worldZoomSize * 2f));
		zero.x = ((this.centerID.x - this.homePos.x) * (float)this.TileHeight - this.TileObjectRectTransform[num2][num].anchoredPosition.x) * DataManager.MapDataController.worldZoomSize * 2f;
		if (this.homeSide == 0)
		{
			if (Math.Abs(zero.y) > this.TileMapRectTransform.sizeDelta.y || Math.Abs(zero.x) > this.TileMapRectTransform.sizeDelta.x)
			{
				this.homeSide = 1;
				DataManager.msgBuffer[0] = 119;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
		}
		else if (Math.Abs(zero.y) < this.TileMapRectTransform.sizeDelta.y && Math.Abs(zero.x) < this.TileMapRectTransform.sizeDelta.x)
		{
			this.homeSide = 0;
			DataManager.msgBuffer[0] = 118;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
	}

	// Token: 0x06000C54 RID: 3156 RVA: 0x0011C1C0 File Offset: 0x0011A3C0
	public void Check3DPos(float scale)
	{
		Vector2 vector = Vector2.zero;
		for (int i = 0; i < (int)this.TileRowNum; i++)
		{
			int num = this.TileColMapStartIDOffset + i & (int)this.TileRowNumSubtractOne;
			for (int j = 0; j < (int)this.TileColNum; j++)
			{
				int num2 = this.TileRowMapStartIDOffset + j & (int)this.TileColNumSubtractOne;
				vector = this.TileRowGroupRectTransform[num].anchoredPosition + this.TileObjectRectTransform[num2][num].anchoredPosition;
				this.effect.setEffect(num, num2, scale);
			}
		}
	}

	// Token: 0x06000C55 RID: 3157 RVA: 0x0011C25C File Offset: 0x0011A45C
	public bool updateHomePos()
	{
		KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.OtherKingdomData.kingdomID);
		this.homePos.x = (float)(recordByKey.worldPosX - DataManager.MapDataController.WorldMinX);
		this.homePos.y = (float)(recordByKey.worldPosY - DataManager.MapDataController.WorldMinY);
		this.homePos.x = this.homePos.x * 2f;
		this.homePos.x = this.homePos.x + (float)((int)this.homePos.y & 1);
		if (DataManager.MapDataController.FocusWorldMapPos.x == -1f && DataManager.MapDataController.FocusWorldMapPos.y == -1f)
		{
			if (DataManager.MapDataController.gotokingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID)
			{
				recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.gotokingdomID);
				DataManager.MapDataController.FocusWorldMapPos.x = (float)(recordByKey.worldPosX - DataManager.MapDataController.WorldMinX);
				DataManager.MapDataController.FocusWorldMapPos.y = (float)(recordByKey.worldPosY - DataManager.MapDataController.WorldMinY);
				MapManager mapDataController = DataManager.MapDataController;
				mapDataController.FocusWorldMapPos.x = mapDataController.FocusWorldMapPos.x * 2f;
				MapManager mapDataController2 = DataManager.MapDataController;
				mapDataController2.FocusWorldMapPos.x = mapDataController2.FocusWorldMapPos.x + (float)((int)DataManager.MapDataController.FocusWorldMapPos.y & 1);
			}
			else
			{
				DataManager.MapDataController.FocusWorldMapPos = this.homePos;
			}
			DataManager.MapDataController.gotokingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
			return true;
		}
		DataManager.MapDataController.gotokingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
		return false;
	}

	// Token: 0x06000C56 RID: 3158 RVA: 0x0011C438 File Offset: 0x0011A638
	public void moveToKingdom(ushort KingdomID)
	{
		KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(KingdomID);
		Vector2 zero = Vector2.zero;
		zero.x = (float)(recordByKey.worldPosX - DataManager.MapDataController.WorldMinX);
		zero.y = (float)(recordByKey.worldPosY - DataManager.MapDataController.WorldMinY);
		zero.x *= 2f;
		zero.x += (float)((int)zero.y & 1);
		this.MovebyTileMapPos((int)zero.x, (int)zero.y, true);
	}

	// Token: 0x06000C57 RID: 3159 RVA: 0x0011C4D4 File Offset: 0x0011A6D4
	public void resetMap()
	{
		int num = 4;
		int num2 = (int)(DataManager.MapDataController.WorldMaxX - DataManager.MapDataController.WorldMinX);
		if (num2 < 16)
		{
			num = Mathf.CeilToInt((float)(16 - num2) * 0.5f);
			MapManager mapDataController = DataManager.MapDataController;
			mapDataController.WorldMaxX += (ushort)num;
			MapManager mapDataController2 = DataManager.MapDataController;
			mapDataController2.WorldMinX -= (ushort)num;
			num2 = (int)(DataManager.MapDataController.WorldMaxX - DataManager.MapDataController.WorldMinX);
		}
		else
		{
			MapManager mapDataController3 = DataManager.MapDataController;
			mapDataController3.WorldMaxX += (ushort)num;
			MapManager mapDataController4 = DataManager.MapDataController;
			mapDataController4.WorldMinX -= (ushort)num;
			num2 = (int)(DataManager.MapDataController.WorldMaxX - DataManager.MapDataController.WorldMinX);
		}
		int num3 = (int)(DataManager.MapDataController.WorldMaxY - DataManager.MapDataController.WorldMinY);
		if (num3 < 16)
		{
			num = Mathf.CeilToInt((float)(16 - num3) * 0.5f);
			MapManager mapDataController5 = DataManager.MapDataController;
			mapDataController5.WorldMaxY += (ushort)num;
			MapManager mapDataController6 = DataManager.MapDataController;
			mapDataController6.WorldMinY -= (ushort)num;
			num3 = (int)(DataManager.MapDataController.WorldMaxY - DataManager.MapDataController.WorldMinY);
		}
		else
		{
			MapManager mapDataController7 = DataManager.MapDataController;
			mapDataController7.WorldMaxY += (ushort)num;
			MapManager mapDataController8 = DataManager.MapDataController;
			mapDataController8.WorldMinY -= (ushort)num;
			num3 = (int)(DataManager.MapDataController.WorldMaxY - DataManager.MapDataController.WorldMinY);
		}
	}

	// Token: 0x06000C58 RID: 3160 RVA: 0x0011C648 File Offset: 0x0011A848
	private bool LoadTileMapFile()
	{
		AssetBundle tableAB = DataManager.Instance.GetTableAB();
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.AppendFormat("WorldMap");
		TextAsset textAsset = tableAB.Load(cstring.ToString()) as TextAsset;
		if (textAsset == null)
		{
			return false;
		}
		if (this.BaseTileMapInfo != null)
		{
			Array.Clear(this.BaseTileMapInfo, 0, this.BaseTileMapInfo.Length);
		}
		Stream stream = new MemoryStream(textAsset.bytes);
		using (BinaryReader binaryReader = new BinaryReader(stream))
		{
			this.BaseTileMapInfo = binaryReader.ReadBytes((int)stream.Length);
			binaryReader.Close();
		}
		stream.Close();
		if (this.TileMapInfo == null)
		{
			this.TileMapInfo = new byte[(int)(this.TileMapInfoWidthMax * this.TileMapInfoHeightMax)];
		}
		Array.Clear(this.TileMapInfo, 0, this.TileMapInfo.Length);
		int num = (int)(DataManager.MapDataController.WorldOX - DataManager.MapDataController.WorldMinX);
		int num2 = (int)(DataManager.MapDataController.WorldOY - DataManager.MapDataController.WorldMinY);
		int i = num2;
		int num3 = 0;
		while (i < (int)this.TileMapInfoHeightMax)
		{
			num3 %= 16;
			int j = num;
			int num4 = 0;
			while (j < (int)this.TileMapInfoWidthMax)
			{
				num4 %= 8;
				int num5 = num3 * 8 + num4;
				int num6 = i * (int)this.TileMapInfoWidthMax + j;
				this.TileMapInfo[num6] = this.BaseTileMapInfo[num5];
				j++;
				num4++;
			}
			i++;
			num3++;
		}
		int k = num2;
		int num7 = 0;
		while (k < (int)this.TileMapInfoHeightMax)
		{
			num7 %= 16;
			int l = num - 1;
			int num8 = -1;
			while (l > -1)
			{
				if (num8 < 0)
				{
					num8 += 8;
				}
				num8 %= 8;
				int num5 = num7 * 8 + num8;
				int num6 = k * (int)this.TileMapInfoWidthMax + l;
				this.TileMapInfo[num6] = this.BaseTileMapInfo[num5];
				l--;
				num8--;
			}
			k++;
			num7++;
		}
		int m = num2 - 1;
		int num9 = -1;
		while (m > -1)
		{
			if (num9 < 0)
			{
				num9 += 16;
			}
			num9 %= 16;
			int n = num;
			int num10 = 0;
			while (n < (int)this.TileMapInfoWidthMax)
			{
				num10 %= 8;
				int num5 = num9 * 8 + num10;
				int num6 = m * (int)this.TileMapInfoWidthMax + n;
				this.TileMapInfo[num6] = this.BaseTileMapInfo[num5];
				n++;
				num10++;
			}
			m--;
			num9--;
		}
		int num11 = num2 - 1;
		int num12 = -1;
		while (num11 > -1)
		{
			if (num12 < 0)
			{
				num12 += 16;
			}
			num12 %= 16;
			int num13 = num - 1;
			int num14 = -1;
			while (num13 > -1)
			{
				if (num14 < 0)
				{
					num14 += 8;
				}
				num14 %= 8;
				int num5 = num12 * 8 + num14;
				int num6 = num11 * (int)this.TileMapInfoWidthMax + num13;
				this.TileMapInfo[num6] = this.BaseTileMapInfo[num5];
				num13--;
				num14--;
			}
			num11--;
			num12--;
		}
		return true;
	}

	// Token: 0x06000C59 RID: 3161 RVA: 0x0011C9BC File Offset: 0x0011ABBC
	private void SetRect(int Xnum, int Ynum)
	{
		Xnum = (Math.Abs(Xnum) & -2);
		Ynum = (Math.Abs(Ynum) & -2);
		if (Xnum == 0)
		{
			Xnum = 2;
		}
		if (Ynum == 0)
		{
			Ynum = 2;
		}
		this.TileColNumOffset = 0;
		while (Xnum >> (int)((this.TileColNumOffset += 1) & 31) != 1)
		{
		}
		Xnum = 1 << (int)this.TileColNumOffset;
		this.TileRowNumOffset = 0;
		while (Ynum >> (int)((this.TileRowNumOffset += 1) & 31) != 1)
		{
		}
		Ynum = 1 << (int)this.TileRowNumOffset;
		byte tileHeight = this.TileHeight;
		int num = (int)tileHeight << 1;
		int num2 = tileHeight >> 1;
		this.TileColNum = (ushort)Xnum;
		this.TileColNumSubtractOne = this.TileColNum;
		this.TileColNumSubtractOne -= 1;
		this.TileRowNum = (ushort)Ynum;
		this.TileRowNumSubtractOne = this.TileRowNum;
		this.TileRowNumSubtractOne -= 1;
		this.TileRowGroupRectTransform = new RectTransform[Ynum];
		Array.Clear(this.TileRowGroupRectTransform, 0, this.TileRowGroupRectTransform.Length);
		this.TileObjectRectTransform = new RectTransform[Xnum][];
		for (int i = 0; i < this.TileObjectRectTransform.Length; i++)
		{
			this.TileObjectRectTransform[i] = new RectTransform[Ynum];
			Array.Clear(this.TileObjectRectTransform[i], 0, this.TileObjectRectTransform[i].Length);
		}
		this.TileBaseRectTransform = new RectTransform[Xnum][];
		for (int j = 0; j < this.TileBaseRectTransform.Length; j++)
		{
			this.TileBaseRectTransform[j] = new RectTransform[Ynum];
			Array.Clear(this.TileBaseRectTransform[j], 0, this.TileBaseRectTransform[j].Length);
		}
		this.OverTileBaseRectTransform = new RectTransform[Xnum][];
		for (int k = 0; k < this.OverTileBaseRectTransform.Length; k++)
		{
			this.OverTileBaseRectTransform[k] = new RectTransform[Ynum];
			Array.Clear(this.OverTileBaseRectTransform[k], 0, this.OverTileBaseRectTransform[k].Length);
		}
		this.OverTileBaseGameObject = new GameObject[Xnum][];
		for (int l = 0; l < this.OverTileBaseGameObject.Length; l++)
		{
			this.OverTileBaseGameObject[l] = new GameObject[Ynum];
			Array.Clear(this.OverTileBaseGameObject[l], 0, this.OverTileBaseGameObject[l].Length);
		}
		this.TileBaseImage = new Image[Xnum][];
		for (int m = 0; m < this.TileBaseImage.Length; m++)
		{
			this.TileBaseImage[m] = new Image[Ynum];
			Array.Clear(this.TileBaseImage[m], 0, this.TileBaseImage[m].Length);
		}
		this.OverTileBaseImage = new Image[Xnum][];
		for (int n = 0; n < this.OverTileBaseImage.Length; n++)
		{
			this.OverTileBaseImage[n] = new Image[Ynum];
			Array.Clear(this.OverTileBaseImage[n], 0, this.OverTileBaseImage[n].Length);
		}
		this.TileColMapStartIDOffset = (this.TileRowMapStartIDOffset = 0);
		Vector2 sizeDelta = new Vector2((float)((int)this.TileColNum * num), (float)tileHeight);
		Vector2 sizeDelta2 = new Vector2((float)num, (float)tileHeight);
		bool flag = this.updateHomePos();
		if (flag)
		{
			int num3 = (int)((DataManager.MapDataController.FocusWorldMapPos.x - (float)((int)DataManager.MapDataController.FocusWorldMapPos.y & 1)) * 0.5f);
			int num4 = (int)DataManager.MapDataController.FocusWorldMapPos.y;
			Xnum >>= 1;
			Xnum--;
			num3 -= Xnum;
			this.BoundStartX = num3;
			if (num3 < 0)
			{
				num3 += (int)this.TileMapInfoWidthMax;
			}
			num3 %= (int)this.TileMapInfoWidthMax;
			Ynum >>= 1;
			num4 -= Ynum;
			this.BoundStartY = num4;
			if (num4 < 0)
			{
				num4 += (int)this.TileMapInfoHeightMax;
			}
			num4 %= (int)this.TileMapInfoHeightMax;
			this.StartID = num4 * (int)this.TileMapInfoWidthMax + num3;
			Vector2 in_StartMapInfoID = new Vector2((float)num3, (float)num4);
			float num5 = (float)((int)this.TileColNumSubtractOne * (num2 >> 1));
			float num6 = (float)((int)(-this.TileColNum * (ushort)tileHeight) - num2 + (int)tileHeight);
			for (int num7 = 0; num7 < this.TileRowGroupRectTransform.Length; num7++)
			{
				GameObject gameObject = new GameObject("TileRowGroup");
				RectTransform rectTransform = this.TileRowGroupRectTransform[num7] = gameObject.AddComponent<RectTransform>();
				rectTransform.sizeDelta = sizeDelta;
				rectTransform.anchoredPosition = Vector2.up * (num5 - (float)(num7 * num2));
				rectTransform.SetParent(this.TileMapRectTransform, false);
				int num8 = this.BoundStartY + num7;
				bool flag2 = num8 < 0 || num8 > (int)(this.TileMapInfoHeightMax - 1);
				for (int num9 = 0; num9 < (int)this.TileColNum; num9++)
				{
					GameObject gameObject2 = new GameObject("TileObject");
					rectTransform = (this.TileObjectRectTransform[num9][num7] = gameObject2.AddComponent<RectTransform>());
					rectTransform.sizeDelta = sizeDelta2;
					rectTransform.anchoredPosition = Vector2.right * (num6 + (float)((int)tileHeight * (num7 + num4 & 1)) + (float)(num9 * num));
					rectTransform.SetParent(this.TileRowGroupRectTransform[num7], false);
					GameObject gameObject3 = new GameObject("TileBase");
					Image image = this.TileBaseImage[num9][num7] = gameObject3.AddComponent<Image>();
					int tileMapInfoID = this.getTileMapInfoID(new Vector2((float)num9, (float)num7), in_StartMapInfoID);
					image.sprite = this.TileSprites.GetSprite((int)(this.TileMapInfo[tileMapInfoID] + 2));
					image.material = this.TileSprites.m_Image.material;
					image.SetNativeSize();
					int num10 = this.BoundStartX + num9;
					rectTransform = (this.TileBaseRectTransform[num9][num7] = (gameObject3.transform as RectTransform));
					if (this.TileBaseScale == 0f)
					{
						this.TileBaseScale = (float)num / rectTransform.sizeDelta.x;
					}
					rectTransform.localScale = Vector3.one * this.TileBaseScale;
					rectTransform.anchoredPosition = Vector2.up * (rectTransform.sizeDelta.y * this.TileBaseScale - (float)this.TileHeight) * 0.5f;
					rectTransform.SetParent(this.TileObjectRectTransform[num9][num7], false);
					this.OverTileBaseGameObject[num9][num7] = new GameObject("OverTileBase");
					rectTransform = this.OverTileBaseGameObject[num9][num7].AddComponent<RectTransform>();
					rectTransform.sizeDelta = sizeDelta2;
					rectTransform.anchoredPosition = Vector3.zero;
					rectTransform.SetParent(this.TileObjectRectTransform[num9][num7], false);
					gameObject3 = new GameObject("Ground");
					image = (this.OverTileBaseImage[num9][num7] = gameObject3.AddComponent<Image>());
					image.material = this.TileSprites.m_Image.material;
					rectTransform = (this.OverTileBaseRectTransform[num9][num7] = (gameObject3.transform as RectTransform));
					rectTransform.localScale = Vector3.one * this.TileBaseScale;
					rectTransform.SetParent(this.OverTileBaseGameObject[num9][num7].transform, false);
					this.OverTileBaseGameObject[num9][num7].SetActive(false);
				}
			}
			this.Movedelta.x = this.TileObjectRectTransform[Xnum][Ynum].anchoredPosition.x;
			this.Movedelta.y = this.TileRowGroupRectTransform[Ynum].anchoredPosition.y;
			this.Movedelta *= -DataManager.MapDataController.worldZoomSize;
			this.MoveTileBase();
			this.Movedelta = Vector2.zero;
		}
		else
		{
			this.StartID = DataManager.MapDataController.StartID;
			int num3 = this.StartID % (int)this.TileMapInfoWidthMax;
			int num4 = this.StartID / (int)this.TileMapInfoWidthMax;
			this.BoundStartX = (int)DataManager.MapDataController.FocusWorldMapPos.x;
			this.BoundStartY = (int)DataManager.MapDataController.FocusWorldMapPos.y;
			Vector2 in_StartMapInfoID = new Vector2((float)num3, (float)num4);
			float num5 = DataManager.MapDataController.coloneWorldMapPos.y;
			float num6 = DataManager.MapDataController.coloneWorldMapPos.x;
			float x = DataManager.MapDataController.coltwoWorldMapPos.x;
			for (int num11 = 0; num11 < this.TileRowGroupRectTransform.Length; num11++)
			{
				GameObject gameObject = new GameObject("TileRowGroup");
				RectTransform rectTransform = this.TileRowGroupRectTransform[num11] = gameObject.AddComponent<RectTransform>();
				rectTransform.sizeDelta = sizeDelta;
				rectTransform.anchoredPosition = Vector2.up * (num5 - (float)(num11 * num2));
				rectTransform.SetParent(this.TileMapRectTransform, false);
				int num8 = this.BoundStartY + num11;
				bool flag3 = num8 < 0 || num8 > (int)(this.TileMapInfoHeightMax - 1);
				if ((num11 & 1) == 0)
				{
					for (int num12 = 0; num12 < (int)this.TileColNum; num12++)
					{
						GameObject gameObject2 = new GameObject("TileObject");
						rectTransform = (this.TileObjectRectTransform[num12][num11] = gameObject2.AddComponent<RectTransform>());
						rectTransform.sizeDelta = sizeDelta2;
						rectTransform.anchoredPosition = Vector2.right * (num6 + (float)(num12 * num));
						rectTransform.SetParent(this.TileRowGroupRectTransform[num11], false);
						GameObject gameObject3 = new GameObject("TileBase");
						Image image = this.TileBaseImage[num12][num11] = gameObject3.AddComponent<Image>();
						int tileMapInfoID = this.getTileMapInfoID(new Vector2((float)num12, (float)num11), in_StartMapInfoID);
						image.sprite = this.TileSprites.GetSprite((int)(this.TileMapInfo[tileMapInfoID] + 2));
						image.material = this.TileSprites.m_Image.material;
						image.SetNativeSize();
						int num10 = this.BoundStartX + num12;
						rectTransform = (this.TileBaseRectTransform[num12][num11] = (gameObject3.transform as RectTransform));
						if (this.TileBaseScale == 0f)
						{
							this.TileBaseScale = (float)num / rectTransform.sizeDelta.x;
						}
						rectTransform.localScale = Vector3.one * this.TileBaseScale;
						rectTransform.anchoredPosition = Vector2.up * (rectTransform.sizeDelta.y * this.TileBaseScale - (float)this.TileHeight) * 0.5f;
						rectTransform.SetParent(this.TileObjectRectTransform[num12][num11], false);
						this.OverTileBaseGameObject[num12][num11] = new GameObject("OverTileBase");
						rectTransform = this.OverTileBaseGameObject[num12][num11].AddComponent<RectTransform>();
						rectTransform.sizeDelta = sizeDelta2;
						rectTransform.anchoredPosition = Vector3.zero;
						rectTransform.SetParent(this.TileObjectRectTransform[num12][num11], false);
						gameObject3 = new GameObject("Ground");
						image = (this.OverTileBaseImage[num12][num11] = gameObject3.AddComponent<Image>());
						image.material = this.TileSprites.m_Image.material;
						rectTransform = (this.OverTileBaseRectTransform[num12][num11] = (gameObject3.transform as RectTransform));
						rectTransform.localScale = Vector3.one * this.TileBaseScale;
						rectTransform.SetParent(this.OverTileBaseGameObject[num12][num11].transform, false);
						this.OverTileBaseGameObject[num12][num11].SetActive(false);
					}
				}
				else
				{
					for (int num13 = 0; num13 < (int)this.TileColNum; num13++)
					{
						GameObject gameObject2 = new GameObject("TileObject");
						rectTransform = (this.TileObjectRectTransform[num13][num11] = gameObject2.AddComponent<RectTransform>());
						rectTransform.sizeDelta = sizeDelta2;
						rectTransform.anchoredPosition = Vector2.right * (x + (float)(num13 * num));
						rectTransform.SetParent(this.TileRowGroupRectTransform[num11], false);
						GameObject gameObject3 = new GameObject("TileBase");
						Image image = this.TileBaseImage[num13][num11] = gameObject3.AddComponent<Image>();
						int tileMapInfoID = this.getTileMapInfoID(new Vector2((float)num13, (float)num11), in_StartMapInfoID);
						image.sprite = this.TileSprites.GetSprite((int)(this.TileMapInfo[tileMapInfoID] + 2));
						image.material = this.TileSprites.m_Image.material;
						image.SetNativeSize();
						int num10 = this.BoundStartX + num13;
						rectTransform = (this.TileBaseRectTransform[num13][num11] = (gameObject3.transform as RectTransform));
						if (this.TileBaseScale == 0f)
						{
							this.TileBaseScale = (float)num / rectTransform.sizeDelta.x;
						}
						rectTransform.localScale = Vector3.one * this.TileBaseScale;
						rectTransform.anchoredPosition = Vector2.up * (rectTransform.sizeDelta.y * this.TileBaseScale - (float)this.TileHeight) * 0.5f;
						rectTransform.SetParent(this.TileObjectRectTransform[num13][num11], false);
						this.OverTileBaseGameObject[num13][num11] = new GameObject("OverTileBase");
						rectTransform = this.OverTileBaseGameObject[num13][num11].AddComponent<RectTransform>();
						rectTransform.sizeDelta = sizeDelta2;
						rectTransform.anchoredPosition = Vector3.zero;
						rectTransform.SetParent(this.TileObjectRectTransform[num13][num11], false);
						gameObject3 = new GameObject("Ground");
						image = (this.OverTileBaseImage[num13][num11] = gameObject3.AddComponent<Image>());
						image.material = this.TileSprites.m_Image.material;
						rectTransform = (this.OverTileBaseRectTransform[num13][num11] = (gameObject3.transform as RectTransform));
						rectTransform.localScale = Vector3.one * this.TileBaseScale;
						rectTransform.SetParent(this.OverTileBaseGameObject[num13][num11].transform, false);
						this.OverTileBaseGameObject[num13][num11].SetActive(false);
					}
				}
			}
		}
	}

	// Token: 0x06000C5A RID: 3162 RVA: 0x0011D804 File Offset: 0x0011BA04
	private void CheckLimit(int in_Startpointx, int in_Startpointy, ref Vector2 inout_movedelta)
	{
		if (inout_movedelta.y < 0f)
		{
			if (this.BoundStartY < 0)
			{
				float num = this.TileMapRectTransform.sizeDelta.y / DataManager.MapDataController.worldZoomSize;
				float num2 = num * 0.5f;
				float num3 = this.TileRowGroupRectTransform[this.TileColMapStartIDOffset - 1 & (int)this.TileRowNumSubtractOne].anchoredPosition.y + (float)((in_Startpointy + (int)this.TileRowNumSubtractOne) % (int)this.TileMapInfoHeightMax * (this.TileHeight >> 1)) + num2;
				if (num3 < 0f)
				{
					num3 += (float)((this.TileHeight >> 1) * (int)this.TileMapInfoHeightMax) + num;
				}
				num3 -= num2 - inout_movedelta.y;
				if (num3 < 0f)
				{
					inout_movedelta.y -= num3;
					this.Movedelta.y = 0f;
				}
			}
		}
		else if (inout_movedelta.y > 0f && this.BoundStartY >= 0)
		{
			float num4 = this.TileMapRectTransform.sizeDelta.y / DataManager.MapDataController.worldZoomSize;
			float num5 = num4 * 0.5f;
			float num3 = this.TileRowGroupRectTransform[this.TileColMapStartIDOffset].anchoredPosition.y - (float)(((int)this.TileMapInfoHeightMax - in_Startpointy - 1) * (this.TileHeight >> 1)) - num5;
			if (num3 > 0f)
			{
				num3 -= (float)((this.TileHeight >> 1) * (int)this.TileMapInfoHeightMax) + num4;
			}
			num3 += inout_movedelta.y + num5;
			if (num3 > 0f)
			{
				inout_movedelta.y -= num3;
				this.Movedelta.y = 0f;
			}
		}
		if (inout_movedelta.x < 0f)
		{
			if (this.BoundStartX >= 0)
			{
				float num6 = this.TileMapRectTransform.sizeDelta.x / DataManager.MapDataController.worldZoomSize;
				float num7 = num6 * 0.5f;
				float num3 = this.TileObjectRectTransform[this.TileRowMapStartIDOffset][0].anchoredPosition.x + (float)(((int)this.TileMapInfoWidthMax - in_Startpointx - 1) * ((int)this.TileHeight << 1)) + num7;
				if (num3 < 0f)
				{
					num3 += (float)(((int)this.TileHeight << 1) * (int)this.TileMapInfoWidthMax) + num6;
				}
				num3 -= num7 - inout_movedelta.x;
				if (num3 < 0f)
				{
					inout_movedelta.x -= num3;
					this.Movedelta.x = 0f;
				}
			}
		}
		else if (inout_movedelta.x > 0f && this.BoundStartX < 0)
		{
			float num8 = this.TileMapRectTransform.sizeDelta.x / DataManager.MapDataController.worldZoomSize;
			float num9 = num8 * 0.5f;
			float num3 = this.TileObjectRectTransform[this.TileRowMapStartIDOffset - 1 & (int)this.TileColNumSubtractOne][0].anchoredPosition.x - (float)((in_Startpointx + (int)this.TileColNumSubtractOne) % (int)this.TileMapInfoWidthMax * ((int)this.TileHeight << 1)) - num9;
			if (num3 > 0f)
			{
				num3 -= (float)(((int)this.TileHeight << 1) * (int)this.TileMapInfoWidthMax) + num8;
			}
			num3 += num9 + inout_movedelta.x;
			if (num3 > 0f)
			{
				inout_movedelta.x -= num3;
				this.Movedelta.x = 0f;
			}
		}
	}

	// Token: 0x06000C5B RID: 3163 RVA: 0x0011DB7C File Offset: 0x0011BD7C
	private bool CalculateRollingTime(Vector2 in_movedelta, out int updownTime, out int rightleftTime, ref int in_Startpointx, ref int in_Startpointy)
	{
		updownTime = (rightleftTime = 0);
		int num = 0;
		int num2 = 0;
		bool result = false;
		if (in_movedelta.y > 0f)
		{
			byte b = 6;
			int num3 = 1 << (int)(b - 1) << (int)this.TileRowNumOffset;
			float num4 = in_movedelta.y - (float)num3 + this.TileRowGroupRectTransform[this.TileColMapStartIDOffset].anchoredPosition.y;
			if (num4 > 0f)
			{
				updownTime = (int)(num4 / (float)(this.TileHeight >> 1)) + 1;
				num2 = (updownTime & (int)this.TileRowNumSubtractOne);
				num = updownTime >> (int)this.TileRowNumOffset;
				result = (num != 0);
			}
			num4 = in_movedelta.y - (float)(num << (int)b << (int)this.TileRowNumOffset);
			int num5;
			for (int i = num2; i < (int)this.TileRowNum; i++)
			{
				num5 = (this.TileColMapStartIDOffset + i & (int)this.TileRowNumSubtractOne);
				this.TileRowGroupRectTransform[num5].anchoredPosition += Vector2.up * num4;
			}
			num5 = (this.TileColMapStartIDOffset - 1 & (int)this.TileRowNumSubtractOne);
			float num6 = this.TileRowGroupRectTransform[num5].anchoredPosition.y - (float)(this.TileHeight >> 1);
			for (int j = 0; j < num2; j++)
			{
				num5 = (this.TileColMapStartIDOffset + j & (int)this.TileRowNumSubtractOne);
				RectTransform rectTransform = this.TileRowGroupRectTransform[num5];
				rectTransform.anchoredPosition = Vector2.up * (num6 - (float)(j << (int)b));
				rectTransform.SetAsLastSibling();
			}
			this.TileColMapStartIDOffset += num2;
			this.TileColMapStartIDOffset &= (int)this.TileRowNumSubtractOne;
		}
		else if (in_movedelta.y < 0f)
		{
			byte b2 = 6;
			int num3 = 1 << (int)(b2 - 1) << (int)this.TileRowNumOffset;
			float num4 = (float)(-(float)num3) - this.TileRowGroupRectTransform[this.TileColMapStartIDOffset - 1 & (int)this.TileRowNumSubtractOne].anchoredPosition.y - in_movedelta.y;
			if (num4 > 0f)
			{
				updownTime = (int)(num4 / (float)(this.TileHeight >> 1)) + 1;
				num2 = (updownTime & (int)this.TileRowNumSubtractOne);
				num = updownTime >> (int)this.TileRowNumOffset;
				result = (num != 0);
				updownTime = -updownTime;
			}
			int k = (int)this.TileRowNum - num2;
			num4 = in_movedelta.y + (float)(num << (int)b2 << (int)this.TileRowNumOffset);
			for (int l = 0; l < k; l++)
			{
				int num5 = this.TileColMapStartIDOffset + l & (int)this.TileRowNumSubtractOne;
				this.TileRowGroupRectTransform[num5].anchoredPosition += Vector2.up * num4;
			}
			float num6 = this.TileRowGroupRectTransform[this.TileColMapStartIDOffset].anchoredPosition.y + (float)(this.TileHeight >> 1);
			k = 0;
			int num7 = (int)(this.TileRowNum - 1);
			while (k < num2)
			{
				int num5 = this.TileColMapStartIDOffset + num7 & (int)this.TileRowNumSubtractOne;
				RectTransform rectTransform = this.TileRowGroupRectTransform[num5];
				rectTransform.anchoredPosition = Vector2.up * (num6 + (float)(k << (int)b2));
				rectTransform.SetAsFirstSibling();
				num7--;
				k++;
			}
			this.TileColMapStartIDOffset -= num2;
			this.TileColMapStartIDOffset &= (int)this.TileRowNumSubtractOne;
		}
		if (in_movedelta.x > 0f)
		{
			num2 = (num = 0);
			byte b3 = 8;
			int num8 = (this.StartID / (int)this.TileMapInfoWidthMax + updownTime) % (int)this.TileMapInfoHeightMax & 1;
			int num3 = ((int)this.TileColNum << (int)(b3 - 1)) + (this.TileHeight >> 1);
			int num5 = this.TileColMapStartIDOffset + num8 & (int)this.TileRowNumSubtractOne;
			int num9 = this.TileRowMapStartIDOffset - 1 & (int)this.TileColNumSubtractOne;
			float num4 = this.TileObjectRectTransform[num9][num5].anchoredPosition.x + in_movedelta.x - (float)num3;
			if (num4 > 0f)
			{
				rightleftTime = (int)(num4 / (float)(this.TileHeight << 1)) + 1;
				num2 = (rightleftTime & (int)this.TileColNumSubtractOne);
				num = rightleftTime >> (int)this.TileColNumOffset;
				if (num != 0)
				{
					result = true;
				}
				rightleftTime = -rightleftTime;
			}
			num4 = in_movedelta.x - (float)(num << (int)b3 << (int)this.TileColNumOffset);
			int m = (int)this.TileColNum - num2;
			for (int n = 0; n < (int)this.TileRowNum; n++)
			{
				num5 = (this.TileColMapStartIDOffset + n & (int)this.TileRowNumSubtractOne);
				for (int num10 = 0; num10 < m; num10++)
				{
					num9 = (this.TileRowMapStartIDOffset + num10 & (int)this.TileColNumSubtractOne);
					this.TileObjectRectTransform[num9][num5].anchoredPosition += Vector2.right * num4;
				}
			}
			num5 = (this.TileColMapStartIDOffset + num8 & (int)this.TileRowNumSubtractOne);
			num9 = this.TileRowMapStartIDOffset;
			float num6 = this.TileObjectRectTransform[num9][num5].anchoredPosition.x - (float)(this.TileHeight << 1);
			for (int num11 = 0; num11 < (int)this.TileRowNum; num11++)
			{
				m = 0;
				num5 = (this.TileColMapStartIDOffset + num11 & (int)this.TileRowNumSubtractOne);
				int num12 = (int)(this.TileColNum - 1);
				while (m < num2)
				{
					num9 = (this.TileRowMapStartIDOffset + num12 & (int)this.TileColNumSubtractOne);
					this.TileObjectRectTransform[num9][num5].anchoredPosition = Vector2.right * (num6 - (float)(m * ((int)this.TileHeight << 1)) + (float)((num11 + num8 & 1) * (int)this.TileHeight));
					num12--;
					m++;
				}
			}
			this.TileRowMapStartIDOffset -= num2;
			this.TileRowMapStartIDOffset &= (int)this.TileColNumSubtractOne;
		}
		else if (in_movedelta.x < 0f)
		{
			num2 = (num = 0);
			byte b4 = 8;
			int num13 = (this.StartID / (int)this.TileMapInfoWidthMax + updownTime) % (int)this.TileMapInfoHeightMax & 1;
			int num3 = ((int)this.TileColNum << (int)(b4 - 1)) + (int)this.TileHeight;
			int num5 = this.TileColMapStartIDOffset + 1 - num13 & (int)this.TileRowNumSubtractOne;
			int num14 = this.TileRowMapStartIDOffset;
			float num4 = (float)(-(float)num3) - this.TileObjectRectTransform[num14][num5].anchoredPosition.x - in_movedelta.x;
			if (num4 > 0f)
			{
				rightleftTime = (int)(num4 / (float)(this.TileHeight << 1)) + 1;
				num2 = (rightleftTime & (int)this.TileColNumSubtractOne);
				num = rightleftTime >> (int)this.TileColNumOffset;
				if (num != 0)
				{
					result = true;
				}
			}
			num4 = in_movedelta.x + (float)(num << (int)b4 << (int)this.TileColNumOffset);
			for (int num15 = 0; num15 < (int)this.TileRowNum; num15++)
			{
				num5 = (this.TileColMapStartIDOffset + num15 & (int)this.TileRowNumSubtractOne);
				for (int num16 = num2; num16 < (int)this.TileColNum; num16++)
				{
					num14 = (this.TileRowMapStartIDOffset + num16 & (int)this.TileColNumSubtractOne);
					this.TileObjectRectTransform[num14][num5].anchoredPosition += Vector2.right * num4;
				}
			}
			num5 = (this.TileColMapStartIDOffset + num13 & (int)this.TileRowNumSubtractOne);
			num14 = (this.TileRowMapStartIDOffset - 1 & (int)this.TileColNumSubtractOne);
			float num6 = this.TileObjectRectTransform[num14][num5].anchoredPosition.x + (float)(this.TileHeight << 1);
			for (int num17 = 0; num17 < (int)this.TileRowNum; num17++)
			{
				num5 = (this.TileColMapStartIDOffset + num17 & (int)this.TileRowNumSubtractOne);
				for (int num18 = 0; num18 < num2; num18++)
				{
					num14 = (this.TileRowMapStartIDOffset + num18 & (int)this.TileColNumSubtractOne);
					this.TileObjectRectTransform[num14][num5].anchoredPosition = Vector2.right * (num6 + (float)(num18 << (int)b4) + (float)((num17 + num13 & 1) << (int)(b4 - 1)));
				}
			}
			this.TileRowMapStartIDOffset += num2;
			this.TileRowMapStartIDOffset &= (int)this.TileColNumSubtractOne;
		}
		this.BoundStartY += updownTime;
		for (in_Startpointy += updownTime; in_Startpointy < 0; in_Startpointy += (int)this.TileMapInfoHeightMax)
		{
		}
		in_Startpointy %= (int)this.TileMapInfoHeightMax;
		this.BoundStartX += rightleftTime;
		for (in_Startpointx += rightleftTime; in_Startpointx < 0; in_Startpointx += (int)this.TileMapInfoWidthMax)
		{
		}
		in_Startpointx %= (int)this.TileMapInfoWidthMax;
		return result;
	}

	// Token: 0x06000C5C RID: 3164 RVA: 0x0011E464 File Offset: 0x0011C664
	private void UpdateMap(int rowsatrt, int rowend, int colstart, int colend, int startPointX, int startPointY)
	{
		Vector2 in_StartMapInfoID = new Vector2((float)startPointX, (float)startPointY);
		Vector2 zero = Vector2.zero;
		Vector2 pos = Vector2.zero;
		for (int i = rowsatrt; i < rowend; i++)
		{
			int num = this.BoundStartY + i;
			bool flag = num < 0 || num > (int)(this.TileMapInfoHeightMax - 1);
			int num2 = this.TileColMapStartIDOffset + i & (int)this.TileRowNumSubtractOne;
			for (int j = colstart; j < colend; j++)
			{
				int num3 = this.TileRowMapStartIDOffset + j & (int)this.TileColNumSubtractOne;
				Image image = this.TileBaseImage[num3][num2];
				zero.x = (float)j;
				zero.y = (float)i;
				int tileMapInfoID = this.getTileMapInfoID(zero, in_StartMapInfoID);
				int num4 = this.BoundStartX + j;
				bool flag2 = flag || num4 < 0 || num4 > (int)(this.TileMapInfoWidthMax - 1);
				image.sprite = this.TileSprites.GetSprite((int)(this.TileMapInfo[tileMapInfoID] + 2));
				image.SetNativeSize();
				RectTransform rectTransform = this.TileBaseRectTransform[num3][num2];
				rectTransform.anchoredPosition = Vector2.up * (rectTransform.sizeDelta.y * this.TileBaseScale - (float)this.TileHeight) * 0.5f;
				this.OverTileBaseGameObject[num3][num2].SetActive(false);
				image.color = Color.white;
				if (this.kingdomName != null)
				{
					ushort kingdomID = DataManager.MapDataController.TileMapKingdomID[tileMapInfoID].KingdomID;
					if (kingdomID == 0 || flag2)
					{
						this.kingdomName.setName(32, num2, num3, Color.white, pos);
						this.kingdomYolk.setYolkImage(-1, num2, num3, pos);
						this.kingdomGraphic.setGraphicImage(0, num2, num3, pos, 0, kingdomID, 0);
						this.effect.setEffect(0, num2, num3, Vector2.zero, 0);
					}
					else
					{
						pos = this.TileRowGroupRectTransform[num2].anchoredPosition + this.TileObjectRectTransform[num3][num2].anchoredPosition;
						byte tableID = DataManager.MapDataController.TileMapKingdomID[tileMapInfoID].tableID;
						if (tableID < 32 && kingdomID == DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomID)
						{
							this.kingdomYolk.setYolkImage((int)kingdomID, num2, num3, pos);
							this.kingdomName.setName(tableID, num2, num3, Color.white, pos);
						}
						else
						{
							this.kingdomName.setName(32, num2, num3, Color.white, pos);
							this.kingdomYolk.setYolkImage(-1, num2, num3, pos);
						}
						int num5 = 0;
						byte b = (byte)(DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomFlag >> 3);
						if (b > 0)
						{
							num5 = 8;
						}
						else if (DataManager.Instance.RoleAttr.WorldTitle_Personal == 1 && TitleManager.Instance.CheckGivetNTile() && DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomPeriod < KINGDOM_PERIOD.KP_WORLD_WAR)
						{
							num5 = 4;
						}
						if (kingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
						{
							EKvKKingdomType kvKKingdomType = ActivityManager.Instance.getKvKKingdomType(kingdomID);
							if (kvKKingdomType == EKvKKingdomType.EKKT_Target)
							{
								num5 += 16;
							}
							else if (kvKKingdomType == EKvKKingdomType.EKKT_Hunter)
							{
								num5 += 32;
							}
							KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(kingdomID);
							this.kingdomGraphic.setGraphicImage(1 + num5, num2, num3, pos, (int)recordByKey.mapID, kingdomID, b);
						}
						else if ((DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && kingdomID == DataManager.MapDataController.kingdomData.kingdomID) || (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && this.CheckShowTransmission(kingdomID) && tableID < 32 && DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomPeriod == KINGDOM_PERIOD.KP_KVK))
						{
							EKvKKingdomType kvKKingdomType2 = ActivityManager.Instance.getKvKKingdomType(kingdomID);
							if (kvKKingdomType2 == EKvKKingdomType.EKKT_Target)
							{
								num5 += 16;
							}
							else if (kvKKingdomType2 == EKvKKingdomType.EKKT_Hunter)
							{
								num5 += 32;
							}
							this.kingdomGraphic.setGraphicImage(2 + num5, num2, num3, pos, 0, kingdomID, b);
						}
						else
						{
							this.kingdomGraphic.setGraphicImage(0 + num5, num2, num3, pos, 0, kingdomID, b);
						}
						if (DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && (DataManager.MapDataController.WorldKingdomTable[(int)tableID].kingdomFlag & 2) != 0)
						{
							this.effect.setEffect(1, num2, num3, pos, 0);
						}
						else
						{
							this.effect.setEffect(0, num2, num3, pos, 0);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000C5D RID: 3165 RVA: 0x0011E974 File Offset: 0x0011CB74
	private Vector2 PosToTileBaseID(Vector2 in_Pos)
	{
		in_Pos = this.screenToMap(in_Pos);
		float num = 0f;
		int num2 = 0;
		int num3 = (int)this.TileRowNumSubtractOne;
		int num4 = num3 + num2 >> 1;
		while (num2 != num4)
		{
			num = in_Pos.y - this.TileRowGroupRectTransform[this.TileColMapStartIDOffset + num4 & (int)this.TileRowNumSubtractOne].anchoredPosition.y;
			if (num > 0f)
			{
				num3 = num4;
			}
			else
			{
				num2 = num4;
			}
			num4 = num3 + num2 >> 1;
		}
		if (num3 - num2 == 1)
		{
			float num5 = this.TileObjectRectTransform[this.TileRowMapStartIDOffset][this.TileColMapStartIDOffset + num2 & (int)this.TileRowNumSubtractOne].anchoredPosition.x;
			if (this.TileObjectRectTransform[this.TileRowMapStartIDOffset][this.TileColMapStartIDOffset + num3 & (int)this.TileRowNumSubtractOne].anchoredPosition.x < num5)
			{
				num4 = num2;
				num2 = num3;
				num3 = num4;
			}
			int num6 = 0;
			int num7 = (int)this.TileColNumSubtractOne;
			int num8 = this.TileColMapStartIDOffset + num2 & (int)this.TileRowNumSubtractOne;
			num4 = num7 + num6 >> 1;
			while (num6 != num4)
			{
				num5 = in_Pos.x - this.TileObjectRectTransform[this.TileRowMapStartIDOffset + num4 & (int)this.TileColNumSubtractOne][num8].anchoredPosition.x;
				if (num5 > 0f)
				{
					num6 = num4;
				}
				else
				{
					num7 = num4;
				}
				num4 = num7 + num6 >> 1;
			}
			if (num5 > (float)(this.TileHeight << 1))
			{
				num7++;
			}
			if (num < 0f)
			{
				num += (float)(this.TileHeight >> 1);
			}
			num5 = in_Pos.x - this.TileObjectRectTransform[this.TileRowMapStartIDOffset + num7 - 1 & (int)this.TileColNumSubtractOne][this.TileColMapStartIDOffset + num3 & (int)this.TileRowNumSubtractOne].anchoredPosition.x;
			if (num5 < 0f)
			{
				num5 += (float)this.TileHeight;
				num7--;
				if (num2 < num3)
				{
					if (num * 2f > num5)
					{
						num3 = num2;
					}
				}
				else if (num < (float)(this.TileHeight >> 1) - 0.5f * num5)
				{
					num3 = num2;
				}
			}
			else if (num2 < num3)
			{
				if (num < (float)(this.TileHeight >> 1) - 0.5f * num5)
				{
					num7--;
				}
				else
				{
					num3 = num2;
				}
			}
			else if (num * 2f < num5)
			{
				num3 = num2;
			}
			else
			{
				num7--;
			}
			return new Vector2((float)num7, (float)num3);
		}
		return -Vector2.one;
	}

	// Token: 0x06000C5E RID: 3166 RVA: 0x0011EC0C File Offset: 0x0011CE0C
	private int getTileMapInfoIDbyStartID(Vector2 in_TileBaseID)
	{
		return this.getTileMapInfoID(in_TileBaseID, new Vector2((float)(this.StartID % (int)this.TileMapInfoWidthMax), (float)(this.StartID / (int)this.TileMapInfoWidthMax)));
	}

	// Token: 0x06000C5F RID: 3167 RVA: 0x0011EC44 File Offset: 0x0011CE44
	private Vector2 getTileMapSpritePosbyStartID(Vector2 in_TileBaseID)
	{
		int num = this.StartID % (int)this.TileMapInfoWidthMax;
		int num2 = this.StartID / (int)this.TileMapInfoWidthMax;
		num2 += (int)in_TileBaseID.y;
		num2 %= (int)this.TileMapInfoHeightMax;
		num += (int)in_TileBaseID.x;
		num %= (int)this.TileMapInfoWidthMax;
		Vector2 result = new Vector2((float)num, (float)num2);
		return result;
	}

	// Token: 0x06000C60 RID: 3168 RVA: 0x0011ECA4 File Offset: 0x0011CEA4
	private Vector2 getTileMapSpritePosbyBoundID(Vector2 in_TileBaseID)
	{
		int num = this.BoundStartX;
		int num2 = this.BoundStartY;
		num2 += (int)in_TileBaseID.y;
		if (num2 < 0)
		{
			num2 = 0;
		}
		else if (num2 > (int)(this.TileMapInfoHeightMax - 1))
		{
			num2 = (int)(this.TileMapInfoHeightMax - 1);
		}
		num += (int)in_TileBaseID.x;
		if (num < 0)
		{
			num = 0;
		}
		else if (num > (int)(this.TileMapInfoWidthMax - 1))
		{
			num = (int)(this.TileMapInfoWidthMax - 1);
		}
		Vector2 result = new Vector2((float)num, (float)num2);
		return result;
	}

	// Token: 0x06000C61 RID: 3169 RVA: 0x0011ED2C File Offset: 0x0011CF2C
	private int getTileMapInfoID(Vector2 in_TileBaseID, Vector2 in_StartMapInfoID)
	{
		int num = (int)in_StartMapInfoID.x;
		int num2 = (int)in_StartMapInfoID.y;
		num2 += (int)in_TileBaseID.y;
		num2 %= (int)this.TileMapInfoHeightMax;
		num += (int)in_TileBaseID.x;
		num %= (int)this.TileMapInfoWidthMax;
		num2 *= (int)this.TileMapInfoWidthMax;
		return num2 + num;
	}

	// Token: 0x06000C62 RID: 3170 RVA: 0x0011ED84 File Offset: 0x0011CF84
	private void MoveTileBase()
	{
		if (this.Movedelta == Vector2.zero)
		{
			return;
		}
		int num = this.StartID % (int)this.TileMapInfoWidthMax;
		int num2 = this.StartID / (int)this.TileMapInfoWidthMax;
		Vector2 in_movedelta = this.Movedelta / DataManager.MapDataController.worldZoomSize;
		this.CheckLimit(num, num2, ref in_movedelta);
		int num3 = 0;
		int num4 = 0;
		if (this.CalculateRollingTime(in_movedelta, out num3, out num4, ref num, ref num2))
		{
			this.UpdateMap(0, (int)this.TileRowNum, 0, (int)this.TileColNum, num, num2);
		}
		else
		{
			int num5 = 0;
			int num6 = (int)this.TileRowNum;
			int colstart = 0;
			int num7 = (int)this.TileColNum;
			if (num3 > 0)
			{
				num6 = (int)this.TileRowNum - num3;
				this.UpdateMap(num6, (int)this.TileRowNum, 0, (int)this.TileColNum, num, num2);
			}
			else if (num3 < 0)
			{
				num5 = -num3;
				this.UpdateMap(0, num5, 0, (int)this.TileColNum, num, num2);
			}
			if (num4 < 0)
			{
				colstart = -num4;
				this.UpdateMap(num5, num6, 0, -num4, num, num2);
			}
			else if (num4 > 0)
			{
				num7 = (int)this.TileColNum - num4;
				this.UpdateMap(num5, num6, num7, (int)this.TileColNum, num, num2);
			}
			this.setLayoutPosition(num5, num6, colstart, num7);
		}
		this.StartID = num + num2 * (int)this.TileMapInfoWidthMax;
		this.CheckCenterPos();
	}

	// Token: 0x06000C63 RID: 3171 RVA: 0x0011EEE4 File Offset: 0x0011D0E4
	private void ZoomTile()
	{
		if (Input.touchCount < 2)
		{
			this.inputState = ((Input.touchCount != 1) ? WorldMap.InPutState.None : WorldMap.InPutState.Drag);
			return;
		}
		Touch touch = Input.GetTouch(0);
		Touch touch2 = Input.GetTouch(1);
		Vector2 position = touch.position;
		Vector2 position2 = touch2.position;
		float num = (position - touch.deltaPosition - position2 + touch2.deltaPosition).magnitude - (position2 - position).magnitude;
		Transform parent = this.TileMapRectTransform.parent;
		num = parent.localScale.x + num * -0.005f;
		num = (DataManager.MapDataController.worldZoomSize = Mathf.Clamp(num, 0.75f, 1.75f));
		parent.localScale = Vector3.one * num;
		this.RealmGroup_3DTransform.localScale = Vector3.one * num;
		this.CheckCenterPos();
		this.updateGoHomeButtonPos();
		this.Check3DPos(parent.localScale.x);
	}

	// Token: 0x06000C64 RID: 3172 RVA: 0x0011F008 File Offset: 0x0011D208
	private Vector2 screenToMap(Vector2 screenPos)
	{
		screenPos.x -= (float)Screen.width * 0.5f;
		screenPos.y -= (float)Screen.height * 0.5f;
		screenPos *= this.TileMapRectTransform.sizeDelta.y / ((float)Screen.height * DataManager.MapDataController.worldZoomSize);
		return screenPos;
	}

	// Token: 0x06000C65 RID: 3173 RVA: 0x0011F078 File Offset: 0x0011D278
	private void updateBaseCenter()
	{
		this.BaseCenterID = this.PosToTileBaseID(new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f));
	}

	// Token: 0x0400282B RID: 10283
	private const float startMovedeltaFactor = 0.25f;

	// Token: 0x0400282C RID: 10284
	private const byte spriteIDoffset = 2;

	// Token: 0x0400282D RID: 10285
	private const float OnDragStopTime = 0.5f;

	// Token: 0x0400282E RID: 10286
	public Vector2 Movedelta = Vector2.zero;

	// Token: 0x0400282F RID: 10287
	public byte[] TileMapInfo;

	// Token: 0x04002830 RID: 10288
	public UISpritesArray TileSprites;

	// Token: 0x04002831 RID: 10289
	public float TileBaseScale;

	// Token: 0x04002832 RID: 10290
	public Vector2 homePos;

	// Token: 0x04002833 RID: 10291
	private byte homeSide;

	// Token: 0x04002834 RID: 10292
	private byte TileHeight;

	// Token: 0x04002835 RID: 10293
	private ushort TileMapInfoWidthMax;

	// Token: 0x04002836 RID: 10294
	private ushort TileMapInfoHeightMax;

	// Token: 0x04002837 RID: 10295
	private ushort TileColNum;

	// Token: 0x04002838 RID: 10296
	private ushort TileColNumSubtractOne;

	// Token: 0x04002839 RID: 10297
	private ushort TileColNumOffset;

	// Token: 0x0400283A RID: 10298
	private ushort TileRowNum;

	// Token: 0x0400283B RID: 10299
	private ushort TileRowNumSubtractOne;

	// Token: 0x0400283C RID: 10300
	private ushort TileRowNumOffset;

	// Token: 0x0400283D RID: 10301
	private int TileColMapStartIDOffset;

	// Token: 0x0400283E RID: 10302
	private int TileRowMapStartIDOffset;

	// Token: 0x0400283F RID: 10303
	private int StartID;

	// Token: 0x04002840 RID: 10304
	private int BoundStartX;

	// Token: 0x04002841 RID: 10305
	private int BoundStartY;

	// Token: 0x04002842 RID: 10306
	private RectTransform TileMapRectTransform;

	// Token: 0x04002843 RID: 10307
	private RectTransform[] TileRowGroupRectTransform;

	// Token: 0x04002844 RID: 10308
	private RectTransform[][] TileObjectRectTransform;

	// Token: 0x04002845 RID: 10309
	private RectTransform[][] TileBaseRectTransform;

	// Token: 0x04002846 RID: 10310
	private RectTransform[][] OverTileBaseRectTransform;

	// Token: 0x04002847 RID: 10311
	private GameObject[][] OverTileBaseGameObject;

	// Token: 0x04002848 RID: 10312
	private Image[][] TileBaseImage;

	// Token: 0x04002849 RID: 10313
	private Image[][] OverTileBaseImage;

	// Token: 0x0400284A RID: 10314
	private byte[] BaseTileMapInfo;

	// Token: 0x0400284B RID: 10315
	private WorldMap.InPutState inputState;

	// Token: 0x0400284C RID: 10316
	private float MovedeltaFactor = 0.25f;

	// Token: 0x0400284D RID: 10317
	private float onDragTimer;

	// Token: 0x0400284E RID: 10318
	private Vector2 OnDragPos;

	// Token: 0x0400284F RID: 10319
	private Vector2 lastOnDragPos;

	// Token: 0x04002850 RID: 10320
	private Vector2 goHomeButtonOffset;

	// Token: 0x04002851 RID: 10321
	private WorldMapImage nowWorldMapImage;

	// Token: 0x04002852 RID: 10322
	private Vector2 BaseCenterID = -Vector2.one;

	// Token: 0x04002853 RID: 10323
	private Vector2 centerID = -Vector2.one;

	// Token: 0x04002854 RID: 10324
	private int centerMapID = -1;

	// Token: 0x04002855 RID: 10325
	private float clickspeed = 6.66666651f;

	// Token: 0x04002856 RID: 10326
	private WorldMapName kingdomName;

	// Token: 0x04002857 RID: 10327
	private WorldMapYolk kingdomYolk;

	// Token: 0x04002858 RID: 10328
	private WorldMapGraphic kingdomGraphic;

	// Token: 0x04002859 RID: 10329
	private WorldMapEffect effect;

	// Token: 0x0400285A RID: 10330
	private Color deepblue = new Color(0.207843125f, 0.654902f, 1f);

	// Token: 0x0400285B RID: 10331
	private Color lightblue = new Color(0f, 1f, 1f);

	// Token: 0x0400285C RID: 10332
	private Color lightyellow = new Color(1f, 0.6117647f, 0f);

	// Token: 0x0400285D RID: 10333
	private Color lightred = new Color(1f, 0f, 0.117647f);

	// Token: 0x0400285E RID: 10334
	private Vector2 inpos = new Vector2(-182f, -201.5f);

	// Token: 0x0400285F RID: 10335
	private Vector2 outpos = new Vector2(-55f, -63.5f);

	// Token: 0x04002860 RID: 10336
	private RectTransform Canvasrectran;

	// Token: 0x04002861 RID: 10337
	private Transform RealmGroup_3DTransform;

	// Token: 0x04002862 RID: 10338
	private Sprite kvkButtonSprite;

	// Token: 0x04002863 RID: 10339
	private Sprite titleButtonSprite;

	// Token: 0x04002864 RID: 10340
	private Transform kvkButton;

	// Token: 0x04002865 RID: 10341
	private float kvkButtonSpeed = 24f;

	// Token: 0x04002866 RID: 10342
	private bool bkvkButtonClick;

	// Token: 0x04002867 RID: 10343
	private bool btitleButtonClick;

	// Token: 0x04002868 RID: 10344
	private bool btitleHintShow;

	// Token: 0x04002869 RID: 10345
	private WorldMapGraphicImage nowkvkGraphicImage;

	// Token: 0x02000281 RID: 641
	private enum InPutState : byte
	{
		// Token: 0x0400286B RID: 10347
		None,
		// Token: 0x0400286C RID: 10348
		Click,
		// Token: 0x0400286D RID: 10349
		Drag,
		// Token: 0x0400286E RID: 10350
		Zoom,
		// Token: 0x0400286F RID: 10351
		KingdomUp,
		// Token: 0x04002870 RID: 10352
		KingdomDown,
		// Token: 0x04002871 RID: 10353
		Count
	}
}
