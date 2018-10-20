using System;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200025B RID: 603
public class MapTile : MonoBehaviour
{
	// Token: 0x06000ACD RID: 2765 RVA: 0x000E7844 File Offset: 0x000E5A44
	protected void Awake()
	{
		this.bGraphicFake = (((ActivityManager.Instance.bSpecialMonsterTreasureEvent & 4UL) <= 0UL) ? 0 : 1);
		this.bFront = (GameManager.ActiveGameplay is Front);
		this.tmepStr = StringManager.Instance.SpawnString(300);
		this.TileHeight = 128;
		this.TileMapInfoWidthMaxOffSet = 8;
		this.TileMapInfoHeightMaxOffSet = 10;
		this.TileMapInfoWidthMax = 256;
		this.TileMapInfoWidthMaxSubtractOne = this.TileMapInfoWidthMax;
		this.TileMapInfoWidthMaxSubtractOne -= 1;
		this.TileMapInfoHeightMax = 1024;
		this.TileMapInfoHeightMaxSubtractOne = this.TileMapInfoHeightMax;
		this.TileMapInfoHeightMaxSubtractOne -= 1;
		this.LoadTileMapFile();
		this.Canvasrectran = (GUIManager.Instance.m_UICanvas.transform as RectTransform);
		this.TileMapRectTransform = (base.transform as RectTransform);
		this.TileMapRectTransform.position = Vector3.forward * 4096f;
		this.TileMapRectTransform.sizeDelta = this.Canvasrectran.sizeDelta;
		this.TileMapRectTransform.anchoredPosition = Vector2.zero;
		this.TileSprites = base.gameObject.GetComponent<UISpritesArray>();
		this.SetRect(16, 16);
		this.OnDragPos = -Vector2.zero;
		this.lastOnDragPos = -Vector2.zero;
		this.onDragTimer = 0f;
		this.updateHomePos();
		this.updateBaseCenter();
		this.tickImage = new Image[256];
		this.tickImageIDToColRow = new byte[256];
		this.tickColRowToImageID = new ushort[16][];
		for (int i = 0; i < this.tickColRowToImageID.Length; i++)
		{
			this.tickColRowToImageID[i] = new ushort[16];
			for (int j = 0; j < this.tickColRowToImageID[i].Length; j++)
			{
				this.tickColRowToImageID[i][j] = 256;
			}
		}
		if (ActivityManager.Instance.KVKHuntOrder == 1)
		{
			this.frontIsSheep = 0;
		}
		else if (ActivityManager.Instance.KVKHuntOrder == 2)
		{
			this.frontIsSheep = 1;
		}
	}

	// Token: 0x06000ACE RID: 2766 RVA: 0x000E7A7C File Offset: 0x000E5C7C
	protected void OnDestroy()
	{
		if (this.tickImage != null)
		{
			Array.Clear(this.tickImage, 0, this.tickImage.Length);
			this.tickImage = null;
		}
		if (this.tickImageIDToColRow != null)
		{
			Array.Clear(this.tickImageIDToColRow, 0, this.tickImageIDToColRow.Length);
			this.tickImageIDToColRow = null;
		}
		if (this.tickColRowToImageID != null)
		{
			for (int i = 0; i < this.tickColRowToImageID.Length; i++)
			{
				Array.Clear(this.tickColRowToImageID[i], 0, this.tickColRowToImageID[i].Length);
				this.tickColRowToImageID[i] = null;
			}
			this.tickColRowToImageID = null;
		}
		if (this.tmepStr != null)
		{
			StringManager.Instance.DeSpawnString(this.tmepStr);
		}
		if (this.centerMapID != -1)
		{
			DataManager.MapDataController.FocusMapID = this.centerMapID;
		}
		this.RealmGroup_3DTransform = null;
		if (this.TileMapInfo != null)
		{
			Array.Clear(this.TileMapInfo, 0, this.TileMapInfo.Length);
		}
		if (this.TileMapInfoEx != null)
		{
			Array.Clear(this.TileMapInfoEx, 0, this.TileMapInfoEx.Length);
		}
		if (this.TileRowGroupRectTransform != null)
		{
			Array.Clear(this.TileRowGroupRectTransform, 0, this.TileRowGroupRectTransform.Length);
		}
		if (this.TileObjectRectTransform != null)
		{
			for (int j = 0; j < this.TileObjectRectTransform.Length; j++)
			{
				Array.Clear(this.TileObjectRectTransform[j], 0, this.TileObjectRectTransform[j].Length);
				this.TileObjectRectTransform[j] = null;
			}
		}
		if (this.TileBaseRectTransform != null)
		{
			for (int k = 0; k < this.TileBaseRectTransform.Length; k++)
			{
				Array.Clear(this.TileBaseRectTransform[k], 0, this.TileBaseRectTransform[k].Length);
				this.TileBaseRectTransform[k] = null;
			}
		}
		if (this.OverTileBaseRectTransform != null)
		{
			for (int l = 0; l < this.OverTileBaseRectTransform.Length; l++)
			{
				Array.Clear(this.OverTileBaseRectTransform[l], 0, this.OverTileBaseRectTransform[l].Length);
				this.OverTileBaseRectTransform[l] = null;
			}
		}
		if (this.OverTileBaseGameObject != null)
		{
			for (int m = 0; m < this.OverTileBaseGameObject.Length; m++)
			{
				Array.Clear(this.OverTileBaseGameObject[m], 0, this.OverTileBaseGameObject[m].Length);
				this.OverTileBaseGameObject[m] = null;
			}
		}
		if (this.TileBaseImage != null)
		{
			for (int n = 0; n < this.TileBaseImage.Length; n++)
			{
				Array.Clear(this.TileBaseImage[n], 0, this.TileBaseImage[n].Length);
				this.TileBaseImage[n] = null;
			}
		}
		if (this.OverTileBaseImage != null)
		{
			for (int num = 0; num < this.OverTileBaseImage.Length; num++)
			{
				Array.Clear(this.OverTileBaseImage[num], 0, this.OverTileBaseImage[num].Length);
				this.OverTileBaseImage[num] = null;
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
		this.TileMapInfoEx = null;
		this.level = null;
		this.bloodname = null;
		this.graphic = null;
		this.effect = null;
		this.npc = null;
		this.yolk = null;
		if (this.selectLineNode != null)
		{
			if (this.line != null)
			{
				this.line.easeLineNode(this.selectLineNode);
			}
			else
			{
				this.selectLineNode.bFocus = 0;
			}
			this.selectLineNode = null;
		}
		this.Canvasrectran = null;
	}

	// Token: 0x06000ACF RID: 2767 RVA: 0x000E7E48 File Offset: 0x000E6048
	protected void Update()
	{
		this.tileDeltaTime = Time.deltaTime;
		DataManager.MapDataController.UpdateWaitZone();
		if (this.inputState == MapTile.InPutState.Zoom)
		{
			this.ZoomTile();
			return;
		}
		if (this.inputState == MapTile.InPutState.Group)
		{
			this.FocusGroup(2);
			return;
		}
		if (this.inputState == MapTile.InPutState.Weapon)
		{
			this.FocusMapWeapon();
			return;
		}
		if (this.inputState == MapTile.InPutState.Move)
		{
			this.MoveTarget();
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
				this.onDragTimer += this.tileDeltaTime;
				if (this.onDragTimer > 0.3f)
				{
					this.onDragTimer = 0f;
					this.OnDragPos = (this.lastOnDragPos = -Vector2.one);
					this.RequestMapdata(Vector2.zero, false);
				}
			}
		}
		if (this.Movedelta != Vector2.zero)
		{
			float movedeltaFactor = this.MovedeltaFactor;
			for (int i = 0; i < 2; i++)
			{
				if (this.Movedelta[i] != 0f)
				{
					ref Vector2 ptr = ref this.Movedelta;
					int index2;
					int index = index2 = i;
					float num = ptr[index2];
					this.Movedelta[index] = num * movedeltaFactor;
					if (float.IsNaN(this.Movedelta[i]) || Math.Abs(this.Movedelta[i]) < 0.03f)
					{
						this.Movedelta[i] = 0f;
					}
				}
			}
			if (this.MovedeltaFactor < 0.97f)
			{
				this.MovedeltaFactor += this.tileDeltaTime * 49f;
				if (this.MovedeltaFactor > 0.97f)
				{
					this.MovedeltaFactor = 0.97f;
				}
			}
			if (this.Movedelta.magnitude <= 0f)
			{
				this.RequestMapdata(Vector2.zero, false);
			}
			float num2 = 0.4f;
			if (this.Movedelta.magnitude < num2)
			{
				DataManager.msgBuffer[0] = 97;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
		}
	}

	// Token: 0x06000AD0 RID: 2768 RVA: 0x000E809C File Offset: 0x000E629C
	public void OnDrag(PointerEventData eventData)
	{
		MapTile.InPutState inPutState = this.inputState;
		if (inPutState != MapTile.InPutState.Click)
		{
			if (inPutState == MapTile.InPutState.Drag)
			{
				this.Movedelta = eventData.delta * (this.TileMapRectTransform.sizeDelta.y / (float)Screen.height);
				if (float.IsNaN(this.Movedelta.magnitude))
				{
					this.Movedelta = Vector2.zero;
				}
				this.MoveTileBase();
				this.OnDragPos = eventData.position;
			}
		}
		else if ((eventData.position - eventData.pressPosition).magnitude > 50f)
		{
			this.inputState = MapTile.InPutState.Drag;
			this.ClosePointInfo();
			this.lastOnDragPos = -Vector2.one;
			this.onDragTimer = 0f;
		}
	}

	// Token: 0x06000AD1 RID: 2769 RVA: 0x000E8178 File Offset: 0x000E6378
	public void OnPointerDown(PointerEventData eventData)
	{
		switch (this.inputState)
		{
		case MapTile.InPutState.None:
			this.inputState = MapTile.InPutState.Click;
			goto IL_81;
		case MapTile.InPutState.Click:
		case MapTile.InPutState.Drag:
			if (Input.touchCount > 1)
			{
				this.ClosePointInfo();
				this.inputState = MapTile.InPutState.Zoom;
				DataManager.msgBuffer[0] = 97;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			goto IL_81;
		case MapTile.InPutState.Group:
			this.ClosePointInfo();
			this.inputState = MapTile.InPutState.Click;
			goto IL_81;
		}
		this.ClosePointInfo();
		IL_81:
		this.Movedelta = Vector2.zero;
	}

	// Token: 0x06000AD2 RID: 2770 RVA: 0x000E8214 File Offset: 0x000E6414
	public void OnPointerUp(PointerEventData eventData)
	{
		switch (this.inputState)
		{
		case MapTile.InPutState.Click:
			if (this.line.OnClick(eventData.position, ref this.selectLineNode))
			{
				DataManager.msgBuffer[0] = 66;
				GameConstants.GetBytes((uint)this.selectLineNode.lineTableID, DataManager.msgBuffer, 1);
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				this.inputState = MapTile.InPutState.Group;
				DataManager.MapDataController.FocusGroupID = 10;
				this.FocusGroup(0);
			}
			else
			{
				Vector2 in_TileBaseID = this.PosToTileBaseID(eventData.position);
				uint tileMapInfoIDbyStartID = (uint)this.getTileMapInfoIDbyStartID(in_TileBaseID);
				if (this.yolk.OnYolkSelect(tileMapInfoIDbyStartID))
				{
					DataManager.msgBuffer[0] = 97;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					this.inputState = MapTile.InPutState.None;
				}
				else
				{
					if (in_TileBaseID.x < 0f)
					{
						in_TileBaseID = Vector2.zero;
					}
					int num = this.TileColMapStartIDOffset + (int)in_TileBaseID.y & (int)this.TileRowNumSubtractOne;
					int num2 = this.TileRowMapStartIDOffset + (int)in_TileBaseID.x & (int)this.TileColNumSubtractOne;
					Vector2 vector = this.TileRowGroupRectTransform[num].anchoredPosition + this.TileObjectRectTransform[num2][num].anchoredPosition;
					DataManager.msgBuffer[0] = 64;
					GameConstants.GetBytes(tileMapInfoIDbyStartID, DataManager.msgBuffer, 1);
					GameConstants.GetBytes(vector.x, DataManager.msgBuffer, 5);
					GameConstants.GetBytes(vector.y, DataManager.msgBuffer, 9);
					if (this.TileBaseImage[num2][num].color == Color.gray)
					{
						GameConstants.GetBytes(0, DataManager.msgBuffer, 13);
					}
					else if (DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)tileMapInfoIDbyStartID)].pointKind == 10)
					{
						GameConstants.GetBytes(10, DataManager.msgBuffer, 13);
					}
					else
					{
						GameConstants.GetBytes(14, DataManager.msgBuffer, 13);
					}
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					DataManager.msgBuffer[0] = 97;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					if (this.inputState != MapTile.InPutState.Move)
					{
						this.inputState = MapTile.InPutState.None;
					}
				}
			}
			break;
		case MapTile.InPutState.Drag:
		{
			this.Movedelta = eventData.delta * (this.TileMapRectTransform.sizeDelta.y / (float)Screen.height);
			float num3 = 2f;
			if (this.Movedelta.magnitude < num3)
			{
				this.Movedelta *= num3 / this.Movedelta.magnitude;
			}
			if (float.IsNaN(this.Movedelta.magnitude))
			{
				this.Movedelta = Vector2.zero;
			}
			this.MovedeltaFactor = 0.25f;
			this.inputState = MapTile.InPutState.None;
			this.OnDragPos = -Vector2.one;
			if (this.Movedelta.magnitude <= num3)
			{
				DataManager.msgBuffer[0] = 97;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			else if (this.Movedelta.magnitude >= 20f)
			{
				DataManager.msgBuffer[0] = 96;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
			Vector2 vector2 = this.Movedelta;
			Vector2 movedelta = this.Movedelta;
			float num4 = this.MovedeltaFactor;
			while (movedelta != Vector2.zero)
			{
				for (int i = 0; i < 2; i++)
				{
					if (movedelta[i] != 0f)
					{
						ref Vector2 ptr = ref movedelta;
						int index2;
						int index = index2 = i;
						float num5 = ptr[index2];
						movedelta[index] = num5 * num4;
						if (float.IsNaN(movedelta[i]) || Math.Abs(movedelta[i]) < 0.03f)
						{
							movedelta[i] = 0f;
						}
					}
				}
				vector2 += movedelta;
				if (num4 < 0.97f)
				{
					num4 += this.tileDeltaTime * 49f;
					if (num4 > 0.97f)
					{
						num4 = 0.97f;
					}
				}
			}
			vector2 /= DataManager.MapDataController.zoomSize;
			this.CheckLimit(this.StartID & (int)this.TileMapInfoWidthMaxSubtractOne, this.StartID >> (int)this.TileMapInfoWidthMaxOffSet, ref vector2);
			this.RequestMapdata(vector2, false);
			this.ClosePointInfo();
			break;
		}
		case MapTile.InPutState.Zoom:
			if (Input.touchCount == 1)
			{
				this.inputState = MapTile.InPutState.Drag;
			}
			else if (Input.touchCount < 1)
			{
				DataManager.msgBuffer[0] = 97;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				this.inputState = MapTile.InPutState.None;
			}
			this.ClosePointInfo();
			break;
		}
	}

	// Token: 0x06000AD3 RID: 2771 RVA: 0x000E86B8 File Offset: 0x000E68B8
	public void UpdateTileMap(ushort ZoneID)
	{
		int num = this.StartID & (int)this.TileMapInfoWidthMaxSubtractOne;
		int num2 = this.StartID >> (int)this.TileMapInfoWidthMaxOffSet;
		if (ZoneID < 1024)
		{
			int num3 = GameConstants.PointCodeToMapID(ZoneID, 0);
			int num4 = (num3 & (int)this.TileMapInfoWidthMaxSubtractOne) - num;
			int num5 = (int)this.TileColNum;
			if (num4 < 0)
			{
				num4 = 0;
				num5 += num4;
			}
			else
			{
				num5 -= num4;
			}
			if (num5 < 0)
			{
				return;
			}
			int num6 = (num3 >> (int)this.TileMapInfoWidthMaxOffSet) - num2;
			int num7 = (int)this.TileRowNum;
			if (num6 < 0)
			{
				num6 = 0;
				num7 += num6;
			}
			else
			{
				num7 -= num6;
			}
			if (num7 < 0)
			{
				return;
			}
			this.UpdateMap(num6, num6 + num7, num4, num4 + num5, num, num2);
		}
		else
		{
			this.UpdateMap(0, (int)this.TileRowNum, 0, (int)this.TileColNum, num, num2);
		}
	}

	// Token: 0x06000AD4 RID: 2772 RVA: 0x000E879C File Offset: 0x000E699C
	public void UpdatePoint(uint LayoutMapInfoID)
	{
		int num = this.StartID & (int)this.TileMapInfoWidthMaxSubtractOne;
		int num2 = (int)((ulong)(LayoutMapInfoID & (uint)this.TileMapInfoWidthMaxSubtractOne) - (ulong)((long)num));
		num2 &= (int)this.TileMapInfoWidthMaxSubtractOne;
		if (num2 < 0 || num2 >= (int)this.TileColNum)
		{
			return;
		}
		int num3 = this.StartID >> (int)this.TileMapInfoWidthMaxOffSet;
		int num4 = (int)((ulong)(LayoutMapInfoID >> (int)this.TileMapInfoWidthMaxOffSet) - (ulong)((long)num3));
		num4 &= (int)this.TileMapInfoHeightMaxSubtractOne;
		if (num4 < 0 || num4 >= (int)this.TileRowNum)
		{
			return;
		}
		this.UpdateMap(num4, num4 + 1, num2, num2 + 1, num, num3);
	}

	// Token: 0x06000AD5 RID: 2773 RVA: 0x000E8834 File Offset: 0x000E6A34
	public void UpdatePoint(byte row, byte col)
	{
		int num = (int)row - this.TileColMapStartIDOffset & (int)this.TileRowNumSubtractOne;
		int num2 = (int)col - this.TileRowMapStartIDOffset & (int)this.TileColNumSubtractOne;
		this.UpdateMap(num, num + 1, num2, num2 + 1, this.StartID & (int)this.TileMapInfoWidthMaxSubtractOne, this.StartID >> (int)this.TileMapInfoWidthMaxOffSet);
	}

	// Token: 0x06000AD6 RID: 2774 RVA: 0x000E888C File Offset: 0x000E6A8C
	public void CheckMapNPCBlood(uint LayoutMapInfoID, float blood)
	{
		if (DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)LayoutMapInfoID)].pointKind == 10)
		{
			if (blood <= 0f)
			{
				if (blood > -2f)
				{
					DataManager.MapDataController.NPCPointTableIDpool.despawn((int)DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)LayoutMapInfoID)].tableID);
					DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)LayoutMapInfoID)].pointKind = 0;
				}
			}
			else
			{
				DataManager.MapDataController.NPCPointTable[(int)DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)LayoutMapInfoID)].tableID].Blood = blood;
			}
			this.UpdatePoint(LayoutMapInfoID);
		}
	}

	// Token: 0x06000AD7 RID: 2775 RVA: 0x000E8940 File Offset: 0x000E6B40
	public void UpdateMapNPCBlood(uint LayoutMapInfoID, float blood)
	{
		if (this.npc == null)
		{
			this.CheckMapNPCBlood(LayoutMapInfoID, blood);
			return;
		}
		int num = 0;
		int num2 = 0;
		this.MapIDtoMapTileRowCol(LayoutMapInfoID, ref num, ref num2);
		if (num < 0 || num2 < 0)
		{
			this.CheckMapNPCBlood(LayoutMapInfoID, blood);
			return;
		}
		if (blood == -1f)
		{
			if (this.npc.getNPCLastBlood(num, num2) != 0f)
			{
				this.UpdatePoint(LayoutMapInfoID);
			}
			else
			{
				this.npc.pushDelNPC(num, num2);
			}
			return;
		}
		if (blood == -2f)
		{
			this.npc.checkNPC(num, num2);
			return;
		}
		this.npc.setNPC(num, num2, blood, LayoutMapInfoID);
	}

	// Token: 0x06000AD8 RID: 2776 RVA: 0x000E89EC File Offset: 0x000E6BEC
	public void UpdateMapNPCHurt(uint LayoutMapInfoID, bool bShow = true)
	{
		if (this.npc == null)
		{
			return;
		}
		int row = 0;
		int col = 0;
		this.MapIDtoMapTileRowCol(LayoutMapInfoID, ref row, ref col);
		if (bShow)
		{
			this.npc.setNPC(row, col, NPCState.NPC_Hurt);
		}
		else
		{
			this.npc.setNPC(row, col);
		}
	}

	// Token: 0x06000AD9 RID: 2777 RVA: 0x000E8A3C File Offset: 0x000E6C3C
	public void UpdateMapNPCFighterLeave(uint LayoutMapInfoID, int lineTableID)
	{
		if (this.npc == null)
		{
			return;
		}
		int row = 0;
		int col = 0;
		this.MapIDtoMapTileRowCol(LayoutMapInfoID, ref row, ref col);
		this.npc.setNPC(row, col, lineTableID);
	}

	// Token: 0x06000ADA RID: 2778 RVA: 0x000E8A74 File Offset: 0x000E6C74
	public sbyte getNPCDir(uint LayoutMapInfoID)
	{
		if (this.npc == null)
		{
			return 0;
		}
		int num = 0;
		int num2 = 0;
		this.MapIDtoMapTileRowCol(LayoutMapInfoID, ref num, ref num2);
		if (num < 0 || num2 < 0)
		{
			return 0;
		}
		return this.npc.getNPCDir(num, num2);
	}

	// Token: 0x06000ADB RID: 2779 RVA: 0x000E8ABC File Offset: 0x000E6CBC
	public void setNPCLinenode(uint LayoutMapInfoID, LineNode lineNode)
	{
		if (this.npc == null)
		{
			return;
		}
		int row = 0;
		int col = 0;
		this.MapIDtoMapTileRowCol(LayoutMapInfoID, ref row, ref col);
		this.npc.setNPC(row, col, lineNode, LayoutMapInfoID);
	}

	// Token: 0x06000ADC RID: 2780 RVA: 0x000E8AF4 File Offset: 0x000E6CF4
	public void setLine(FlowLineFactory mapLine)
	{
		this.line = mapLine;
	}

	// Token: 0x06000ADD RID: 2781 RVA: 0x000E8B00 File Offset: 0x000E6D00
	public void setWeapon(MapTileModel mapWeapon)
	{
		this.weapon = mapWeapon;
	}

	// Token: 0x06000ADE RID: 2782 RVA: 0x000E8B0C File Offset: 0x000E6D0C
	public void setRealmGroup_3DTransform(Transform mapLine3DTransform)
	{
		this.RealmGroup_3DTransform = mapLine3DTransform;
	}

	// Token: 0x06000ADF RID: 2783 RVA: 0x000E8B18 File Offset: 0x000E6D18
	public void setLevel(MapTileLevel mapLevelLayout)
	{
		this.level = mapLevelLayout;
		this.level.IniLevelImag((int)this.TileRowNum, (int)this.TileColNum, this.TileBaseScale, this.TileSprites.m_Image.material);
	}

	// Token: 0x06000AE0 RID: 2784 RVA: 0x000E8B5C File Offset: 0x000E6D5C
	public void setBloodName(MapTileBloodName mapBloodNameLayout)
	{
		this.bloodname = mapBloodNameLayout;
		this.bloodname.IniName((int)this.TileRowNum, (int)this.TileColNum);
	}

	// Token: 0x06000AE1 RID: 2785 RVA: 0x000E8B7C File Offset: 0x000E6D7C
	public void setGraphicImage(MapTileGraphic mapGraphicLayout)
	{
		this.graphic = mapGraphicLayout;
		this.graphic.IniGraphicImag((int)this.TileRowNum, (int)this.TileColNum, this.TileBaseScale);
	}

	// Token: 0x06000AE2 RID: 2786 RVA: 0x000E8BB0 File Offset: 0x000E6DB0
	public void setEffect(MapTileEffect mapEffectLayout)
	{
		Front front = GameManager.ActiveGameplay as Front;
		this.effect = mapEffectLayout;
		if (front != null)
		{
			this.effect.IniEffect((int)this.TileRowNum, (int)this.TileColNum, this.TileBaseScale, true);
		}
		else
		{
			this.effect.IniEffect((int)this.TileRowNum, (int)this.TileColNum, this.TileBaseScale, false);
		}
	}

	// Token: 0x06000AE3 RID: 2787 RVA: 0x000E8C18 File Offset: 0x000E6E18
	public void setNPC(MapTileNPC mapTileNPCLayout)
	{
		this.npc = mapTileNPCLayout;
		this.npc.IniNPC((int)this.TileRowNum, (int)this.TileColNum, this.TileBaseScale / DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale, DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale, this);
	}

	// Token: 0x06000AE4 RID: 2788 RVA: 0x000E8C60 File Offset: 0x000E6E60
	public void setYolk(MapTileYolk mapTileYolkLayout)
	{
		this.yolk = mapTileYolkLayout;
		this.yolk.IniMapTileYolk(this.TileBaseScale, this.TileHeight);
		int num = 0;
		int tileRowNum = (int)this.TileRowNum;
		int num2 = 0;
		int tileColNum = (int)this.TileColNum;
		Vector2 in_StartMapInfoID = new Vector2((float)(this.StartID & (int)this.TileMapInfoWidthMaxSubtractOne), (float)(this.StartID >> (int)this.TileMapInfoWidthMaxOffSet));
		Vector2 zero = Vector2.zero;
		for (int i = num; i < tileRowNum; i++)
		{
			int num3 = this.BoundStartY + i;
			if (num3 >= 0 && num3 <= (int)this.TileMapInfoHeightMaxSubtractOne)
			{
				int num4 = this.TileColMapStartIDOffset + i & (int)this.TileRowNumSubtractOne;
				for (int j = num2; j < tileColNum; j++)
				{
					int num5 = this.TileRowMapStartIDOffset + j & (int)this.TileColNumSubtractOne;
					zero.x = (float)j;
					zero.y = (float)i;
					int tileMapInfoID = this.getTileMapInfoID(zero, in_StartMapInfoID);
					int num6 = this.BoundStartX + j;
					if (num6 >= 0 && num6 <= (int)this.TileMapInfoWidthMaxSubtractOne && this.TileMapInfo[tileMapInfoID] > 98 && this.TileMapInfo[tileMapInfoID] < 109)
					{
						this.yolk.setYolk(tileMapInfoID, this.TileRowGroupRectTransform[num4].anchoredPosition + this.TileObjectRectTransform[num5][num4].anchoredPosition);
						return;
					}
				}
			}
		}
	}

	// Token: 0x06000AE5 RID: 2789 RVA: 0x000E8DE4 File Offset: 0x000E6FE4
	public void setLayoutPosition(int rowsatrt, int rowend, int colstart, int colend)
	{
		if (this.level != null)
		{
			for (int i = rowsatrt; i < rowend; i++)
			{
				int num = this.TileColMapStartIDOffset + i & (int)this.TileRowNumSubtractOne;
				for (int j = colstart; j < colend; j++)
				{
					int num2 = this.TileRowMapStartIDOffset + j & (int)this.TileColNumSubtractOne;
					Vector2 pos = this.TileRowGroupRectTransform[num].anchoredPosition + this.TileObjectRectTransform[num2][num].anchoredPosition;
					this.level.setLevelImage(num, num2, pos);
					this.bloodname.setName(num, num2, pos);
					this.graphic.setGraphicImage(num, num2, pos);
					this.effect.setEffect(num, num2, pos);
					this.npc.setNPC(num, num2, pos);
				}
			}
		}
	}

	// Token: 0x06000AE6 RID: 2790 RVA: 0x000E8EB4 File Offset: 0x000E70B4
	public Vector2 getTilePosition(ushort zoneID, byte pointID)
	{
		float num = (float)(((int)(zoneID & 1023 & 15) << 4) + (int)(pointID & 15) - (this.centerMapID & (int)this.TileMapInfoWidthMaxSubtractOne));
		int num2 = ((zoneID & 1023) >> 4 << 4) + (pointID >> 4);
		int num3 = this.centerMapID >> (int)this.TileMapInfoWidthMaxOffSet;
		if ((num3 & 1) == 0)
		{
			num += 0.5f * (float)(num2 & 1);
		}
		else
		{
			num -= 0.5f * (float)(1 - (num2 & 1));
		}
		num2 = num3 - num2;
		int num4 = this.TileColMapStartIDOffset + (int)this.BaseCenterID.y & (int)this.TileRowNumSubtractOne;
		int num5 = this.TileRowMapStartIDOffset + (int)this.BaseCenterID.x & (int)this.TileColNumSubtractOne;
		float y = this.TileRowGroupRectTransform[num4].anchoredPosition.y;
		float x = this.TileObjectRectTransform[num5][num4].anchoredPosition.x;
		if ((float)this.BoundStartY + this.BaseCenterID.y > (float)this.TileMapInfoHeightMaxSubtractOne)
		{
			num2 += (int)this.TileMapInfoHeightMax;
		}
		return new Vector2(num * (float)(this.TileHeight << 1) + x + GameConstants.MAP_POS_EX[zoneID >> 10, 0], (float)(num2 * (this.TileHeight >> 1)) + y + GameConstants.MAP_POS_EX[zoneID >> 10, 1]);
	}

	// Token: 0x06000AE7 RID: 2791 RVA: 0x000E9004 File Offset: 0x000E7204
	public void getTileMapSprite(ref Image iImage, POINT_KIND pointKind, int pointIDorLevel = 0, CITY_OUTWARD outward = CITY_OUTWARD.CO_PLAYER)
	{
		int index;
		if (pointKind == POINT_KIND.PK_NONE)
		{
			if (this.TileMapInfoEx == null || this.TileMapInfoEx[pointIDorLevel] == 0)
			{
				index = (int)this.TileMapInfo[pointIDorLevel];
				iImage.color = Color.white;
			}
			else
			{
				byte b = this.TileMapInfoEx[pointIDorLevel];
				if (b > 191)
				{
					index = (int)b;
					iImage.color = Color.white;
				}
				else if (b == 1)
				{
					index = 99;
					iImage.color = this.color_1;
				}
				else if (b > 1 && b < 6)
				{
					index = (int)(103 + b);
					iImage.color = this.color_2;
				}
				else if (b > 5 && b < 10)
				{
					index = (int)(95 + b);
					iImage.color = this.color_2;
				}
				else
				{
					index = 22;
					iImage.color = Color.white;
				}
			}
		}
		else
		{
			index = (int)((pointKind != POINT_KIND.PK_CAMP) ? ((pointKind != POINT_KIND.PK_CITY) ? ((POINT_KIND)138 + (byte)pointKind) : ((outward <= CITY_OUTWARD.CO_PLAYER || outward >= CITY_OUTWARD.CO_MAX) ? ((pointIDorLevel >= 9) ? ((pointIDorLevel >= 17) ? ((pointIDorLevel >= 25) ? ((POINT_KIND)148) : ((POINT_KIND)147)) : ((POINT_KIND)146)) : ((POINT_KIND)145)) : ((POINT_KIND)151 + (byte)outward - 1))) : ((POINT_KIND)149));
			iImage.color = Color.white;
		}
		iImage.sprite = this.TileSprites.GetSprite(index);
	}

	// Token: 0x06000AE8 RID: 2792 RVA: 0x000E919C File Offset: 0x000E739C
	public bool MovebyTileMapPos(int in_posx, int in_posy, bool bsend = true)
	{
		if (GameConstants.CheckTileMapPos(in_posx, in_posy))
		{
			DataManager.msgBuffer[0] = 65;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			int num = this.TileColMapStartIDOffset + (int)this.BaseCenterID.y & (int)this.TileRowNumSubtractOne;
			int num2 = this.TileRowMapStartIDOffset + (int)this.BaseCenterID.x & (int)this.TileColNumSubtractOne;
			this.Movedelta.y = (((float)in_posy - this.centerID.y) * (float)(this.TileHeight >> 1) - this.TileRowGroupRectTransform[num].anchoredPosition.y) * DataManager.MapDataController.zoomSize;
			this.Movedelta.x = ((this.centerID.x - (float)in_posx) * (float)this.TileHeight - this.TileObjectRectTransform[num2][num].anchoredPosition.x) * DataManager.MapDataController.zoomSize;
			this.MoveTileBase();
			DataManager.msgBuffer[0] = 59;
			GameConstants.GetBytes(this.Movedelta.x, DataManager.msgBuffer, 1);
			GameConstants.GetBytes(this.Movedelta.y, DataManager.msgBuffer, 5);
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			this.Movedelta = Vector2.zero;
			if (bsend)
			{
				this.RequestMapdata(this.Movedelta, false);
			}
			return true;
		}
		return false;
	}

	// Token: 0x06000AE9 RID: 2793 RVA: 0x000E92F4 File Offset: 0x000E74F4
	public void setTarget(int mapID, float scal)
	{
		this.targetTime = 0.2f;
		Vector2 tileMapPosbyMapID = GameConstants.getTileMapPosbyMapID(mapID);
		this.TargetPosx = (int)tileMapPosbyMapID.x;
		this.TargetPosy = (int)tileMapPosbyMapID.y;
		this.TargetScal = Mathf.Clamp(scal, 0.75f, 1.75f);
		this.TargetScal -= DataManager.MapDataController.zoomSize;
		this.scalTargetSpeed = this.TargetScal / this.targetTime;
		int num = this.TileColMapStartIDOffset + (int)this.BaseCenterID.y & (int)this.TileRowNumSubtractOne;
		int num2 = this.TileRowMapStartIDOffset + (int)this.BaseCenterID.x & (int)this.TileColNumSubtractOne;
		float num3 = (((float)this.TargetPosy - this.centerID.y) * (float)(this.TileHeight >> 1) - this.TileRowGroupRectTransform[num].anchoredPosition.y) * DataManager.MapDataController.zoomSize;
		float num4 = ((this.centerID.x - (float)this.TargetPosx) * (float)this.TileHeight - this.TileObjectRectTransform[num2][num].anchoredPosition.x) * DataManager.MapDataController.zoomSize;
		this.moveTargetXSpeed = num4 / this.targetTime;
		this.moveTargetYSpeed = num3 / this.targetTime;
		this.inputState = MapTile.InPutState.Move;
	}

	// Token: 0x06000AEA RID: 2794 RVA: 0x000E9450 File Offset: 0x000E7650
	public void stopMoveToTarget()
	{
		if (this.inputState == MapTile.InPutState.Move)
		{
			this.TargetPosx = -1;
			this.TargetPosy = -1;
			this.TargetScal = 0f;
			this.inputState = MapTile.InPutState.None;
		}
	}

	// Token: 0x06000AEB RID: 2795 RVA: 0x000E948C File Offset: 0x000E768C
	public void MoveTarget()
	{
		this.Movedelta.y = this.moveTargetYSpeed * this.tileDeltaTime;
		this.Movedelta.x = this.moveTargetXSpeed * this.tileDeltaTime;
		this.MoveTileBase();
		DataManager.msgBuffer[0] = 59;
		GameConstants.GetBytes(this.Movedelta.x, DataManager.msgBuffer, 1);
		GameConstants.GetBytes(this.Movedelta.y, DataManager.msgBuffer, 5);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		this.Movedelta = Vector2.zero;
		DataManager.MapDataController.zoomSize += this.scalTargetSpeed * this.tileDeltaTime;
		this.SetScalTile(DataManager.MapDataController.zoomSize);
		this.targetTime -= this.tileDeltaTime;
		if (this.targetTime <= 0f)
		{
			this.targetTime = 0f;
			this.MovebyTileMapPos(this.TargetPosx, this.TargetPosy, true);
			this.SetScalTile(this.TargetScal);
			this.stopMoveToTarget();
			DataManager.msgBuffer[0] = 111;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
		else
		{
			int num = this.TileColMapStartIDOffset + (int)this.BaseCenterID.y & (int)this.TileRowNumSubtractOne;
			int num2 = this.TileRowMapStartIDOffset + (int)this.BaseCenterID.x & (int)this.TileColNumSubtractOne;
			float num3 = (((float)this.TargetPosy - this.centerID.y) * (float)(this.TileHeight >> 1) - this.TileRowGroupRectTransform[num].anchoredPosition.y) * DataManager.MapDataController.zoomSize;
			float num4 = ((this.centerID.x - (float)this.TargetPosx) * (float)this.TileHeight - this.TileObjectRectTransform[num2][num].anchoredPosition.x) * DataManager.MapDataController.zoomSize;
			this.moveTargetXSpeed = num4 / this.targetTime;
			this.moveTargetYSpeed = num3 / this.targetTime;
		}
	}

	// Token: 0x06000AEC RID: 2796 RVA: 0x000E968C File Offset: 0x000E788C
	public void setGoHomeButtonPos(GAME_PLAYER_NEWS buttonmod)
	{
		this.goHomeButtonOffset = this.TileMapRectTransform.sizeDelta * 0.5f;
		if (buttonmod == GAME_PLAYER_NEWS.CHAOS_GoHomePosIn)
		{
			this.goHomeButtonOffset += this.inpos;
		}
		else
		{
			this.goHomeButtonOffset += this.outpos;
		}
		this.updateGoHomeButtonPos();
	}

	// Token: 0x06000AED RID: 2797 RVA: 0x000E96F8 File Offset: 0x000E78F8
	public void updateGoHomeButtonPos()
	{
		Vector2 zero = Vector2.zero;
		zero.x = Mathf.Round(this.goHomeButtonOffset.x / ((float)this.TileHeight * DataManager.MapDataController.zoomSize));
		zero.y = Mathf.Round(this.goHomeButtonOffset.y / ((float)(this.TileHeight >> 1) * DataManager.MapDataController.zoomSize));
		DataManager.msgBuffer[0] = 76;
		GameConstants.GetBytes(zero.x, DataManager.msgBuffer, 1);
		GameConstants.GetBytes(zero.y, DataManager.msgBuffer, 5);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06000AEE RID: 2798 RVA: 0x000E979C File Offset: 0x000E799C
	public bool CheckObstacle(int mapPointID)
	{
		int num = mapPointID >> (int)this.TileMapInfoWidthMaxOffSet;
		int num2 = mapPointID & (int)this.TileMapInfoWidthMaxSubtractOne;
		byte b = this.TileMapInfo[mapPointID];
		return (b >= 0 && b <= 21) || (b >= 99 && b <= 108);
	}

	// Token: 0x06000AEF RID: 2799 RVA: 0x000E97EC File Offset: 0x000E79EC
	public bool RequestMapdata(Vector2 offset, bool renew = false)
	{
		Vector2 in_TileBaseID = (!(offset == Vector2.zero)) ? this.PosToTileBaseID(new Vector2((float)Screen.width * 0.5f - offset.x, (float)Screen.height * 0.5f - offset.y)) : this.BaseCenterID;
		Vector2 tileMapSpritePosbyBoundID = this.getTileMapSpritePosbyBoundID(in_TileBaseID);
		ushort num = (ushort)Math.Max(tileMapSpritePosbyBoundID.y - 7f, 0f);
		ushort num2 = (ushort)Math.Min(tileMapSpritePosbyBoundID.y + 7f, (float)this.TileMapInfoHeightMaxSubtractOne);
		ushort num3 = (ushort)Math.Max(tileMapSpritePosbyBoundID.x - 6f, 0f);
		ushort num4 = (ushort)Math.Min(tileMapSpritePosbyBoundID.x + 6f, (float)this.TileMapInfoWidthMaxSubtractOne);
		byte b = 0;
		Array.Clear(this.TzoneID, (int)b, 4);
		ushort[] tzoneID = this.TzoneID;
		byte b2 = b;
		b = b2 + 1;
		tzoneID[(int)b2] = (ushort)((num3 >> 4) + (num >> 4 << 4));
		ushort num5 = (ushort)((num4 >> 4) + (num >> 4 << 4));
		if (this.TzoneID[(int)(b - 1)] < num5)
		{
			ushort[] tzoneID2 = this.TzoneID;
			byte b3 = b;
			b = b3 + 1;
			tzoneID2[(int)b3] = num5;
		}
		num5 = (ushort)((num3 >> 4) + (num2 >> 4 << 4));
		if (this.TzoneID[(int)(b - 1)] < num5)
		{
			ushort[] tzoneID3 = this.TzoneID;
			byte b4 = b;
			b = b4 + 1;
			tzoneID3[(int)b4] = num5;
		}
		num5 = (ushort)((num4 >> 4) + (num2 >> 4 << 4));
		if (this.TzoneID[(int)(b - 1)] < num5)
		{
			ushort[] tzoneID4 = this.TzoneID;
			byte b5 = b;
			b = b5 + 1;
			tzoneID4[(int)b5] = num5;
		}
		if (DataManager.MapDataController.zoneIDNum == b)
		{
			int num6 = -1;
			while (++num6 < (int)b && DataManager.MapDataController.zoneID[num6] == this.TzoneID[num6])
			{
			}
			if (num6 == (int)b)
			{
				DataManager.MapDataController.waitZoneIDNum = 0;
				DataManager.msgBuffer[0] = 82;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				return false;
			}
		}
		DataManager.MapDataController.setLastZoneInfo(b, this.TzoneID, renew);
		return true;
	}

	// Token: 0x06000AF0 RID: 2800 RVA: 0x000E9A04 File Offset: 0x000E7C04
	public void CheckCenterPos()
	{
		this.updateBaseCenter();
		int tileMapInfoIDbyStartID = this.getTileMapInfoIDbyStartID(this.BaseCenterID);
		if (this.centerMapID != tileMapInfoIDbyStartID)
		{
			this.centerMapID = tileMapInfoIDbyStartID;
			this.centerID = GameConstants.getTileMapPosbyMapID(this.centerMapID);
		}
		Vector2 zero = Vector2.zero;
		int num = this.TileColMapStartIDOffset + (int)this.BaseCenterID.y & (int)this.TileRowNumSubtractOne;
		int num2 = this.TileRowMapStartIDOffset + (int)this.BaseCenterID.x & (int)this.TileColNumSubtractOne;
		zero.y = this.TileRowGroupRectTransform[num].anchoredPosition.y / (float)(this.TileHeight >> 1);
		zero.x = this.TileObjectRectTransform[num2][num].anchoredPosition.x / (float)this.TileHeight;
		DataManager.msgBuffer[0] = 63;
		GameConstants.GetBytes(this.centerID.x, DataManager.msgBuffer, 1);
		GameConstants.GetBytes(this.centerID.y, DataManager.msgBuffer, 5);
		GameConstants.GetBytes(zero.x, DataManager.msgBuffer, 9);
		GameConstants.GetBytes(zero.y, DataManager.msgBuffer, 13);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		zero.y = (((float)this.BoundStartY + this.BaseCenterID.y <= (float)this.TileMapInfoHeightMaxSubtractOne) ? (((this.homePos.y - this.centerID.y) * (float)(this.TileHeight >> 1) - this.TileRowGroupRectTransform[num].anchoredPosition.y) * DataManager.MapDataController.zoomSize * 2f) : (((this.homePos.y - this.centerID.y - (float)this.TileMapInfoHeightMax) * (float)(this.TileHeight >> 1) - this.TileRowGroupRectTransform[num].anchoredPosition.y) * DataManager.MapDataController.zoomSize * 2f));
		zero.x = ((this.centerID.x - this.homePos.x) * (float)this.TileHeight - this.TileObjectRectTransform[num2][num].anchoredPosition.x) * DataManager.MapDataController.zoomSize * 2f;
		if (this.homeSide == 0)
		{
			if (Math.Abs(zero.y) > this.TileMapRectTransform.sizeDelta.y || Math.Abs(zero.x) > this.TileMapRectTransform.sizeDelta.x)
			{
				this.homeSide = 1;
				if (DataManager.MapDataController.FocusKingdomID == DataManager.MapDataController.OtherKingdomData.kingdomID)
				{
					DataManager.msgBuffer[0] = 75;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
			}
		}
		else if (Math.Abs(zero.y) < this.TileMapRectTransform.sizeDelta.y && Math.Abs(zero.x) < this.TileMapRectTransform.sizeDelta.x)
		{
			this.homeSide = 0;
			DataManager.msgBuffer[0] = 74;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
		if (this.npc != null && this.npc.kickNPC != null)
		{
			zero.y = (((float)this.BoundStartY + this.BaseCenterID.y <= (float)this.TileMapInfoHeightMaxSubtractOne) ? (((this.kickNPCPos.y - this.centerID.y) * (float)(this.TileHeight >> 1) - this.TileRowGroupRectTransform[num].anchoredPosition.y) * DataManager.MapDataController.zoomSize * 2f) : (((this.kickNPCPos.y - this.centerID.y - (float)this.TileMapInfoHeightMax) * (float)(this.TileHeight >> 1) - this.TileRowGroupRectTransform[num].anchoredPosition.y) * DataManager.MapDataController.zoomSize * 2f));
			zero.x = ((this.centerID.x - this.kickNPCPos.x) * (float)this.TileHeight - this.TileObjectRectTransform[num2][num].anchoredPosition.x) * DataManager.MapDataController.zoomSize * 2f;
			if (this.kickSide == 0)
			{
				if (Math.Abs(zero.y) > this.TileMapRectTransform.sizeDelta.y || Math.Abs(zero.x) > this.TileMapRectTransform.sizeDelta.x)
				{
					this.kickSide = 1;
					DataManager.msgBuffer[0] = 110;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
			}
			else if (Math.Abs(zero.y) < this.TileMapRectTransform.sizeDelta.y && Math.Abs(zero.x) < this.TileMapRectTransform.sizeDelta.x)
			{
				this.kickSide = 0;
				DataManager.msgBuffer[0] = 109;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
		}
		else if (this.kickSide == 0)
		{
			this.kickSide = 1;
			DataManager.msgBuffer[0] = 110;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
	}

	// Token: 0x06000AF1 RID: 2801 RVA: 0x000E9F80 File Offset: 0x000E8180
	public void Check3DPos()
	{
		Vector2 pos = Vector2.zero;
		for (int i = 0; i < (int)this.TileRowNum; i++)
		{
			int num = this.TileColMapStartIDOffset + i & (int)this.TileRowNumSubtractOne;
			for (int j = 0; j < (int)this.TileColNum; j++)
			{
				int num2 = this.TileRowMapStartIDOffset + j & (int)this.TileColNumSubtractOne;
				pos = this.TileRowGroupRectTransform[num].anchoredPosition + this.TileObjectRectTransform[num2][num].anchoredPosition;
				this.effect.setEffect(num, num2, DataManager.MapDataController.zoomSize);
				this.npc.setNPC(num, num2, pos);
			}
		}
	}

	// Token: 0x06000AF2 RID: 2802 RVA: 0x000EA034 File Offset: 0x000E8234
	public void stopFocusGroup()
	{
		if (this.inputState == MapTile.InPutState.Group)
		{
			if (this.selectLineNode != null)
			{
				DataManager.MapDataController.FocusGroupID = 10;
				if (this.line != null)
				{
					this.line.easeLineNode(this.selectLineNode);
				}
				else
				{
					this.selectLineNode.bFocus = 0;
				}
				this.selectLineNode = null;
			}
			DataManager.msgBuffer[0] = 97;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			this.inputState = MapTile.InPutState.None;
		}
	}

	// Token: 0x06000AF3 RID: 2803 RVA: 0x000EA0B4 File Offset: 0x000E82B4
	public bool ClickGroup()
	{
		if (this.line.OnClick(DataManager.MapDataController.FocusGroupID, ref this.selectLineNode))
		{
			this.inputState = MapTile.InPutState.Group;
			this.selectLineMoveY = (this.selectLineMoveX = 0f);
			DataManager.msgBuffer[0] = 66;
			GameConstants.GetBytes((uint)this.selectLineNode.lineTableID, DataManager.msgBuffer, 1);
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			DataManager.MapDataController.FocusGroupID = 10;
			this.FocusGroup(0);
			return true;
		}
		return false;
	}

	// Token: 0x06000AF4 RID: 2804 RVA: 0x000EA140 File Offset: 0x000E8340
	public void updateHomePos()
	{
		this.homePos = GameConstants.getTileMapPosbyMapID(DataManager.Instance.RoleAttr.CapitalPoint);
	}

	// Token: 0x06000AF5 RID: 2805 RVA: 0x000EA15C File Offset: 0x000E835C
	public void CheckKickNPCPos()
	{
		if (this.npc != null && this.npc.kickNPC != null)
		{
			Vector2 zero = Vector2.zero;
			int num = this.TileColMapStartIDOffset + (int)this.BaseCenterID.y & (int)this.TileRowNumSubtractOne;
			int num2 = this.TileRowMapStartIDOffset + (int)this.BaseCenterID.x & (int)this.TileColNumSubtractOne;
			zero.y = this.TileRowGroupRectTransform[num].anchoredPosition.y / (float)(this.TileHeight >> 1);
			zero.x = this.TileObjectRectTransform[num2][num].anchoredPosition.x / (float)this.TileHeight;
			zero.y = (((float)this.BoundStartY + this.BaseCenterID.y <= (float)this.TileMapInfoHeightMaxSubtractOne) ? (((this.kickNPCPos.y - this.centerID.y) * (float)(this.TileHeight >> 1) - this.TileRowGroupRectTransform[num].anchoredPosition.y) * DataManager.MapDataController.zoomSize * 2f) : (((this.kickNPCPos.y - this.centerID.y - (float)this.TileMapInfoHeightMax) * (float)(this.TileHeight >> 1) - this.TileRowGroupRectTransform[num].anchoredPosition.y) * DataManager.MapDataController.zoomSize * 2f));
			zero.x = ((this.centerID.x - this.kickNPCPos.x) * (float)this.TileHeight - this.TileObjectRectTransform[num2][num].anchoredPosition.x) * DataManager.MapDataController.zoomSize * 2f;
			if (this.kickSide == 0)
			{
				if (Math.Abs(zero.y) > this.TileMapRectTransform.sizeDelta.y || Math.Abs(zero.x) > this.TileMapRectTransform.sizeDelta.x)
				{
					this.kickSide = 1;
					DataManager.msgBuffer[0] = 110;
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
				}
			}
			else if (Math.Abs(zero.y) < this.TileMapRectTransform.sizeDelta.y && Math.Abs(zero.x) < this.TileMapRectTransform.sizeDelta.x)
			{
				this.kickSide = 0;
				DataManager.msgBuffer[0] = 109;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
		}
		else if (this.kickSide == 0)
		{
			this.kickSide = 1;
			DataManager.msgBuffer[0] = 110;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
	}

	// Token: 0x06000AF6 RID: 2806 RVA: 0x000EA42C File Offset: 0x000E862C
	public void updateKickNPCPos(int mapid)
	{
		Vector2 tileMapPosbyMapID = GameConstants.getTileMapPosbyMapID(mapid);
		if (this.kickNPCPos != tileMapPosbyMapID)
		{
			this.kickNPCPos = tileMapPosbyMapID;
			this.CheckKickNPCPos();
		}
	}

	// Token: 0x06000AF7 RID: 2807 RVA: 0x000EA460 File Offset: 0x000E8660
	public void notSend()
	{
		this.OnDragPos = -Vector3.one;
		this.level.LevelLayout.gameObject.SetActive(false);
		this.bloodname.BloodNameLayout.gameObject.SetActive(false);
	}

	// Token: 0x06000AF8 RID: 2808 RVA: 0x000EA4B0 File Offset: 0x000E86B0
	public void SetFocusGroup(int LineTableID, ref LineNode focusNode)
	{
		this.line.OnClick(LineTableID, ref focusNode);
	}

	// Token: 0x06000AF9 RID: 2809 RVA: 0x000EA4C0 File Offset: 0x000E86C0
	public void FocusGroup(byte movefactor = 2)
	{
		if (this.selectLineNode != null && this.selectLineNode.gameObject.activeSelf)
		{
			float num = 1024f;
			float num2 = 512f;
			this.setFocusGroupDelta(out this.Movedelta);
			this.MoveTileBase();
			this.selectLineMoveX += this.Movedelta.x;
			this.selectLineMoveY += this.Movedelta.y;
			if (Mathf.Abs(this.selectLineMoveX) > num || Mathf.Abs(this.selectLineMoveY) > num2)
			{
				this.selectLineMoveX = (this.selectLineMoveY = 0f);
				this.RequestMapdata(this.Movedelta * (float)movefactor, false);
			}
			float num3 = DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale * DataManager.MapDataController.zoomSize;
			this.selectLineNode.NodeName.updateNamePos(new Vector2((float)((int)(this.selectLineNode.movingNode.position.x / num3)), (float)((int)(this.selectLineNode.movingNode.position.y / num3)) + 64f));
		}
		else
		{
			this.selectLineMoveY = (this.selectLineMoveX = 0f);
			DataManager.msgBuffer[0] = 65;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
	}

	// Token: 0x06000AFA RID: 2810 RVA: 0x000EA620 File Offset: 0x000E8820
	public void CheckDelFocusGroup(int LineTableID, byte Send = 1)
	{
		if (this.selectLineNode != null && this.selectLineNode.lineTableID == LineTableID)
		{
			MapLine mapLine = DataManager.MapDataController.MapLineTable[LineTableID];
			if (NetworkManager.ServerTime + 1.0 >= mapLine.begin + (ulong)mapLine.during)
			{
				PointCode end = mapLine.end;
				if (mapLine.lineFlag == 28 && DataManager.CompareStr(mapLine.playerName, DataManager.Instance.RoleAttr.Name) == 0)
				{
					this.continueSelectMapID = GameConstants.PointCodeToMapID(end.zoneID, end.pointID);
				}
				Vector2 tileMapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(end.zoneID, end.pointID);
				this.MovebyTileMapPos((int)tileMapPosbyPointCode.x, (int)tileMapPosbyPointCode.y, Send == 1);
				this.stopFocusGroup();
			}
			else
			{
				DataManager.msgBuffer[0] = 65;
				GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			}
		}
	}

	// Token: 0x06000AFB RID: 2811 RVA: 0x000EA71C File Offset: 0x000E891C
	public void MapIDtoMapTileRowCol(uint LayoutMapInfoID, ref int row, ref int col)
	{
		int num = (int)((ulong)(LayoutMapInfoID & (uint)this.TileMapInfoWidthMaxSubtractOne) - (ulong)((long)this.BoundStartX));
		num &= (int)this.TileMapInfoWidthMaxSubtractOne;
		if (num < 0 || num >= (int)this.TileColNum)
		{
			row = (col = -1);
			return;
		}
		int num2 = (int)((ulong)(LayoutMapInfoID >> (int)this.TileMapInfoWidthMaxOffSet) - (ulong)((long)this.BoundStartY));
		num2 &= (int)this.TileMapInfoHeightMaxSubtractOne;
		if (num2 < 0 || num2 >= (int)this.TileRowNum)
		{
			row = (col = -1);
			return;
		}
		row = (this.TileColMapStartIDOffset + num2 & (int)this.TileRowNumSubtractOne);
		col = (this.TileRowMapStartIDOffset + num & (int)this.TileColNumSubtractOne);
	}

	// Token: 0x06000AFC RID: 2812 RVA: 0x000EA7C0 File Offset: 0x000E89C0
	public Color getMapTileColorByMapID(uint LayoutMapInfoID)
	{
		if (this.TileMapInfoEx == null || this.TileMapInfoEx[(int)((UIntPtr)LayoutMapInfoID)] == 0)
		{
			return Color.white;
		}
		byte b = this.TileMapInfoEx[(int)((UIntPtr)LayoutMapInfoID)];
		if (b > 191)
		{
			return Color.white;
		}
		if (b == 1)
		{
			return this.color_1;
		}
		if (b > 1 && b < 6)
		{
			return this.color_2;
		}
		if (b > 5 && b < 10)
		{
			return this.color_2;
		}
		return Color.white;
	}

	// Token: 0x06000AFD RID: 2813 RVA: 0x000EA854 File Offset: 0x000E8A54
	public void ReflashGraphic()
	{
		byte b = this.bGraphicFake;
		this.bGraphicFake = (((ActivityManager.Instance.bSpecialMonsterTreasureEvent & 4UL) <= 0UL) ? 0 : 1);
		if (b == this.bGraphicFake)
		{
			return;
		}
		int num = this.StartID & (int)this.TileMapInfoWidthMaxSubtractOne;
		int num2 = this.StartID >> (int)this.TileMapInfoWidthMaxOffSet;
		Vector2 in_StartMapInfoID = new Vector2((float)num, (float)num2);
		Vector2 zero = Vector2.zero;
		Vector2 pos = Vector2.zero;
		for (int i = 0; i < (int)this.TileRowNum; i++)
		{
			int num3 = this.BoundStartY + i;
			bool flag = num3 < 0 || num3 > (int)this.TileMapInfoHeightMaxSubtractOne;
			int num4 = this.TileColMapStartIDOffset + i & (int)this.TileRowNumSubtractOne;
			for (int j = 0; j < (int)this.TileColNum; j++)
			{
				int num5 = this.TileRowMapStartIDOffset + j & (int)this.TileColNumSubtractOne;
				zero.x = (float)j;
				zero.y = (float)i;
				int tileMapInfoID = this.getTileMapInfoID(zero, in_StartMapInfoID);
				int num6 = this.BoundStartX + j;
				bool flag2 = flag || num6 < 0 || num6 > (int)this.TileMapInfoWidthMaxSubtractOne;
				if (this.level != null && !flag2)
				{
					POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)tileMapInfoID);
					if (layoutMapInfoPointKind == POINT_KIND.PK_CITY && tileMapInfoID < DataManager.MapDataController.LayoutMapInfo.Length)
					{
						pos = this.TileRowGroupRectTransform[num4].anchoredPosition + this.TileObjectRectTransform[num5][num4].anchoredPosition;
						ushort tableID = DataManager.MapDataController.LayoutMapInfo[tileMapInfoID].tableID;
						if ((int)tableID < DataManager.MapDataController.PlayerPointTable.Length)
						{
							PlayerPoint playerPoint = DataManager.MapDataController.PlayerPointTable[(int)tableID];
							if (playerPoint.cityProperty != CITY_PROPERTY.CP_NPC && this.bGraphicFake == 1)
							{
								TitleData recordByKey = DataManager.Instance.TitleDataW.GetRecordByKey(1);
								this.graphic.setGraphicImage(this.worldTitleIconStartID + (int)recordByKey.IconID, num4, num5, pos, ushort.MaxValue);
							}
							else if (playerPoint.worldTitle == WORLD_PLAYER_DESIGNATION.WKD_1)
							{
								TitleData recordByKey = DataManager.Instance.TitleDataW.GetRecordByKey((ushort)playerPoint.worldTitle);
								this.graphic.setGraphicImage(this.worldTitleIconStartID + (int)recordByKey.IconID, num4, num5, pos, ushort.MaxValue);
							}
							else if (playerPoint.kingdomTitle == KINGDOM_DESIGNATION.KD_1)
							{
								TitleData recordByKey = DataManager.Instance.TitleData.GetRecordByKey((ushort)playerPoint.kingdomTitle);
								this.graphic.setGraphicImage(this.kingdomTitleIconStartID + (int)recordByKey.IconID, num4, num5, pos, ushort.MaxValue);
							}
							else if (playerPoint.worldTitle > WORLD_PLAYER_DESIGNATION.WKD_1 && playerPoint.worldTitle < WORLD_PLAYER_DESIGNATION.WKD_MAX)
							{
								TitleData recordByKey = DataManager.Instance.TitleDataW.GetRecordByKey((ushort)playerPoint.worldTitle);
								this.graphic.setGraphicImage(this.worldTitleIconStartID + (int)recordByKey.IconID, num4, num5, pos, ushort.MaxValue);
							}
							else if (playerPoint.kingdomTitle > KINGDOM_DESIGNATION.KD_1 && playerPoint.kingdomTitle < KINGDOM_DESIGNATION.KD_MAX)
							{
								TitleData recordByKey = DataManager.Instance.TitleData.GetRecordByKey((ushort)playerPoint.kingdomTitle);
								this.graphic.setGraphicImage(this.kingdomTitleIconStartID + (int)recordByKey.IconID, num4, num5, pos, ushort.MaxValue);
							}
							else if ((playerPoint.capitalFlag & 8) != 0)
							{
								this.graphic.setGraphicImage(this.kingdomTitleIconStartID, num4, num5, pos, ushort.MaxValue);
							}
							else
							{
								this.graphic.setGraphicImage(0, num4, num5, pos, ushort.MaxValue);
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000AFE RID: 2814 RVA: 0x000EAC3C File Offset: 0x000E8E3C
	public void mapTileShowDamageRange(int row, int col, Color in_color)
	{
		if (col < this.TileBaseImage.Length && row < this.TileBaseImage[col].Length)
		{
			this.TileBaseImage[col][row].color = in_color;
		}
	}

	// Token: 0x06000AFF RID: 2815 RVA: 0x000EAC78 File Offset: 0x000E8E78
	public void startFocusMapWeapon(byte focusTypeID = 0)
	{
		this.inputState = MapTile.InPutState.Weapon;
		switch (focusTypeID)
		{
		case 1:
			if (DataManager.MapDataController.FocusKingdomID != DataManager.MapDataController.OtherKingdomData.kingdomID)
			{
				this.startFocusMapWeapon(0);
			}
			break;
		case 2:
			break;
		case 3:
			break;
		default:
			this.focusMapWeaponTime = 0f;
			DataManager.msgBuffer[0] = 104;
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
			break;
		}
	}

	// Token: 0x06000B00 RID: 2816 RVA: 0x000EAD08 File Offset: 0x000E8F08
	public void stopFocusMapWeapon()
	{
		if (this.inputState == MapTile.InPutState.Weapon)
		{
			this.inputState = MapTile.InPutState.None;
		}
	}

	// Token: 0x06000B01 RID: 2817 RVA: 0x000EAD20 File Offset: 0x000E8F20
	public int FootBallGetSkill(PointerEventData eventData)
	{
		int result = 0;
		Vector2 b = Vector2.zero;
		Vector2 zero = Vector2.zero;
		Vector2 from = Vector2.zero;
		Vector3 vector = Camera.main.ScreenToViewportPoint(eventData.position);
		b = new Vector2(0.5f, 0.5f);
		b = FootballManager.Instance.mFootBallCenterPos * DataManager.MapDataController.zoomSize;
		b = new Vector2(0.5f + b.x / GUIManager.Instance.m_UICanvas.GetComponent<RectTransform>().sizeDelta.x, 0.5f + b.y / GUIManager.Instance.m_UICanvas.GetComponent<RectTransform>().sizeDelta.y);
		zero = new Vector2(vector.x, vector.y);
		from = zero - b;
		float num = Vector2.Angle(from, Vector2.up) * (float)((from.x >= 0f) ? 1 : -1);
		if (num > -20f && num <= 20f)
		{
			result = 1;
		}
		else if (num > 20f && num <= 70f)
		{
			result = 2;
		}
		else if (num > 70f && num <= 110f)
		{
			result = 3;
		}
		else if (num > 110f && num <= 160f)
		{
			result = 4;
		}
		else if (num > 160f || num <= -160f)
		{
			result = 5;
		}
		else if (num > -160f && num <= -110f)
		{
			result = 6;
		}
		else if (num > -110f && num <= -70f)
		{
			result = 7;
		}
		else if (num > -70f && num <= -20f)
		{
			result = 8;
		}
		return result;
	}

	// Token: 0x06000B02 RID: 2818 RVA: 0x000EAF20 File Offset: 0x000E9120
	public void TileBallDownEffect(uint LayoutMapInfoID)
	{
		if (this.effect == null)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		this.MapIDtoMapTileRowCol(LayoutMapInfoID, ref num, ref num2);
		if (num >= 0 && num2 >= 0)
		{
			Vector2 pos = this.TileRowGroupRectTransform[num].anchoredPosition + this.TileObjectRectTransform[num2][num].anchoredPosition;
			if (DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)LayoutMapInfoID)].pointKind == 8)
			{
				ushort tableID = DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)LayoutMapInfoID)].tableID;
				if (DataManager.MapDataController.PlayerPointTable[(int)tableID].cityProperty == CITY_PROPERTY.CP_NPC)
				{
					this.effect.setEffect(0, num, num2, pos, 8);
					AudioManager.Instance.PlaySFX(40076, 0f, PitchKind.NoPitch, null, null);
				}
			}
			else if (DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)LayoutMapInfoID)].pointKind == 11)
			{
				if (DataManager.MapDataController.YolkPointTable[(int)DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)LayoutMapInfoID)].tableID].WonderID > 0)
				{
					this.effect.setEffect(0, num, num2, pos, 7);
				}
				else
				{
					this.effect.setEffect(0, num, num2, pos, 6);
				}
				AudioManager.Instance.PlaySFX(40076, 0f, PitchKind.NoPitch, null, null);
			}
			else if (DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)LayoutMapInfoID)].pointKind == 0 || DataManager.MapDataController.LayoutMapInfo[(int)((UIntPtr)LayoutMapInfoID)].pointKind == 10)
			{
				byte b = this.TileMapInfo[(int)((UIntPtr)LayoutMapInfoID)];
				if (b > 98 && b < 109)
				{
					this.setYolkBallDownEffect((int)LayoutMapInfoID);
					AudioManager.Instance.PlaySFX(40076, 0f, PitchKind.NoPitch, null, null);
				}
			}
		}
	}

	// Token: 0x06000B03 RID: 2819 RVA: 0x000EB114 File Offset: 0x000E9314
	public void TileBallKickEffect(uint LayoutMapInfoID)
	{
		if (this.effect == null)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		this.MapIDtoMapTileRowCol(LayoutMapInfoID, ref num, ref num2);
		if (num >= 0 && num2 >= 0)
		{
			Vector2 pos = this.TileRowGroupRectTransform[num].anchoredPosition + this.TileObjectRectTransform[num2][num].anchoredPosition;
			this.effect.setEffect(0, num, num2, pos, 10);
			AudioManager.Instance.PlaySFX(40074, 0f, PitchKind.NoPitch, null, null);
		}
	}

	// Token: 0x06000B04 RID: 2820 RVA: 0x000EB19C File Offset: 0x000E939C
	public void TileBallBombEffect(uint LayoutMapInfoID)
	{
		if (this.effect == null)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		this.MapIDtoMapTileRowCol(LayoutMapInfoID, ref num, ref num2);
		if (num >= 0 && num2 >= 0)
		{
			Vector2 pos = this.TileRowGroupRectTransform[num].anchoredPosition + this.TileObjectRectTransform[num2][num].anchoredPosition;
			this.effect.setEffect(0, num, num2, pos, 5);
			AudioManager.Instance.PlaySFX(40075, 0f, PitchKind.NoPitch, null, null);
			Debug.Log("Play Bomb");
		}
	}

	// Token: 0x06000B05 RID: 2821 RVA: 0x000EB230 File Offset: 0x000E9430
	public void FocusMyBall()
	{
		if (this.line != null && DataManager.MapDataController.MyFocusBallLineTableID > -1)
		{
			MapLine mapLine = DataManager.MapDataController.MapLineTable[DataManager.MapDataController.MyFocusBallLineTableID];
			if (this.continueSelectMapID == GameConstants.PointCodeToMapID(mapLine.start.zoneID, mapLine.start.pointID))
			{
				if (this.line.OnClick(DataManager.MapDataController.MyFocusBallLineTableID, ref this.selectLineNode))
				{
					DataManager.msgBuffer[0] = 66;
					GameConstants.GetBytes((uint)this.selectLineNode.lineTableID, DataManager.msgBuffer, 1);
					GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
					this.inputState = MapTile.InPutState.Group;
					this.FocusGroup(0);
				}
				this.continueSelectMapID = (DataManager.MapDataController.MyFocusBallLineTableID = -1);
			}
		}
	}

	// Token: 0x06000B06 RID: 2822 RVA: 0x000EB308 File Offset: 0x000E9508
	public void SetScalTile(float in_scal)
	{
		Transform parent = this.TileMapRectTransform.parent;
		in_scal = (DataManager.MapDataController.zoomSize = Mathf.Clamp(in_scal, 0.75f, 1.75f));
		parent.localScale = Vector3.one * in_scal;
		this.RealmGroup_3DTransform.localScale = Vector3.one * in_scal;
		this.CheckCenterPos();
		this.updateGoHomeButtonPos();
		this.Check3DPos();
	}

	// Token: 0x06000B07 RID: 2823 RVA: 0x000EB378 File Offset: 0x000E9578
	private bool LoadTileMapFile()
	{
		KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.FocusKingdomID);
		AssetBundle tableAB = DataManager.Instance.GetTableAB();
		CString cstring = StringManager.Instance.StaticString1024();
		cstring.ClearString();
		cstring.IntToFormat((long)recordByKey.mapID, 3, false);
		cstring.AppendFormat("TileMap_{0}");
		TextAsset textAsset = tableAB.Load(cstring.ToString()) as TextAsset;
		if (textAsset == null)
		{
			return false;
		}
		if (this.TileMapInfo != null)
		{
			Array.Clear(this.TileMapInfo, 0, this.TileMapInfo.Length);
		}
		Stream stream = new MemoryStream(textAsset.bytes);
		using (BinaryReader binaryReader = new BinaryReader(stream))
		{
			this.TileMapInfo = binaryReader.ReadBytes((int)stream.Length);
			binaryReader.Close();
		}
		stream.Close();
		cstring.ClearString();
		cstring.IntToFormat((long)recordByKey.mapID, 3, false);
		cstring.AppendFormat("TileMapEx_{0}");
		textAsset = (tableAB.Load(cstring.ToString()) as TextAsset);
		if (textAsset == null)
		{
			this.TileMapInfoEx = null;
			return true;
		}
		if (this.TileMapInfoEx != null)
		{
			Array.Clear(this.TileMapInfoEx, 0, this.TileMapInfoEx.Length);
		}
		stream = new MemoryStream(textAsset.bytes);
		using (BinaryReader binaryReader2 = new BinaryReader(stream))
		{
			this.TileMapInfoEx = binaryReader2.ReadBytes((int)stream.Length);
			binaryReader2.Close();
		}
		stream.Close();
		return true;
	}

	// Token: 0x06000B08 RID: 2824 RVA: 0x000EB550 File Offset: 0x000E9750
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
		int num3 = DataManager.MapDataController.FocusMapID & (int)this.TileMapInfoWidthMaxSubtractOne;
		int num4 = DataManager.MapDataController.FocusMapID >> (int)this.TileMapInfoWidthMaxOffSet;
		Xnum >>= 1;
		Xnum--;
		num3 -= Xnum;
		this.BoundStartX = num3;
		num3 &= (int)this.TileMapInfoWidthMaxSubtractOne;
		Ynum >>= 1;
		num4 -= Ynum;
		this.BoundStartY = num4;
		num4 &= (int)this.TileMapInfoHeightMaxSubtractOne;
		this.StartID = (num4 << (int)this.TileMapInfoWidthMaxOffSet | num3);
		Vector2 sizeDelta = new Vector2((float)((int)this.TileColNum * num), (float)tileHeight);
		Vector2 sizeDelta2 = new Vector2((float)num, (float)tileHeight);
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
			bool flag = num8 < 0 || num8 > (int)this.TileMapInfoHeightMaxSubtractOne;
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
				image.sprite = this.TileSprites.GetSprite((int)this.TileMapInfo[tileMapInfoID]);
				image.material = this.TileSprites.m_Image.material;
				image.SetNativeSize();
				int num10 = this.BoundStartX + num9;
				if (num10 < 0 || num10 > (int)this.TileMapInfoWidthMaxSubtractOne || flag)
				{
					image.color = Color.gray;
				}
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
		this.Movedelta *= -DataManager.MapDataController.zoomSize;
		this.MoveTileBase();
		this.Movedelta = Vector2.zero;
	}

	// Token: 0x06000B09 RID: 2825 RVA: 0x000EBD00 File Offset: 0x000E9F00
	private void CheckLimit(int in_Startpointx, int in_Startpointy, ref Vector2 inout_movedelta)
	{
		if (inout_movedelta.y < 0f)
		{
			if (this.BoundStartY < 0)
			{
				float num = this.TileMapRectTransform.sizeDelta.y / DataManager.MapDataController.zoomSize;
				float num2 = num * 0.5f;
				float num3 = this.TileRowGroupRectTransform[this.TileColMapStartIDOffset - 1 & (int)this.TileRowNumSubtractOne].anchoredPosition.y + (float)((in_Startpointy + (int)this.TileRowNumSubtractOne & (int)this.TileMapInfoHeightMaxSubtractOne) * (this.TileHeight >> 1)) + num2;
				if (num3 < 0f)
				{
					num3 += (float)(this.TileHeight >> 1 << (int)this.TileMapInfoHeightMaxOffSet) + num;
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
			float num4 = this.TileMapRectTransform.sizeDelta.y / DataManager.MapDataController.zoomSize;
			float num5 = num4 * 0.5f;
			float num3 = this.TileRowGroupRectTransform[this.TileColMapStartIDOffset].anchoredPosition.y - (float)(((int)this.TileMapInfoHeightMax - in_Startpointy - 1) * (this.TileHeight >> 1)) - num5;
			if (num3 > 0f)
			{
				num3 -= (float)(this.TileHeight >> 1 << (int)this.TileMapInfoHeightMaxOffSet) + num4;
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
				float num6 = this.TileMapRectTransform.sizeDelta.x / DataManager.MapDataController.zoomSize;
				float num7 = num6 * 0.5f;
				float num3 = this.TileObjectRectTransform[this.TileRowMapStartIDOffset][0].anchoredPosition.x + (float)(((int)this.TileMapInfoWidthMax - in_Startpointx - 1) * ((int)this.TileHeight << 1)) + num7;
				if (num3 < 0f)
				{
					num3 += (float)(this.TileHeight << 1 << (int)this.TileMapInfoWidthMaxOffSet) + num6;
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
			float num8 = this.TileMapRectTransform.sizeDelta.x / DataManager.MapDataController.zoomSize;
			float num9 = num8 * 0.5f;
			float num3 = this.TileObjectRectTransform[this.TileRowMapStartIDOffset - 1 & (int)this.TileColNumSubtractOne][0].anchoredPosition.x - (float)((in_Startpointx + (int)this.TileColNumSubtractOne & (int)this.TileMapInfoWidthMaxSubtractOne) * ((int)this.TileHeight << 1)) - num9;
			if (num3 > 0f)
			{
				num3 -= (float)(this.TileHeight << 1 << (int)this.TileMapInfoWidthMaxOffSet) + num8;
			}
			num3 += num9 + inout_movedelta.x;
			if (num3 > 0f)
			{
				inout_movedelta.x -= num3;
				this.Movedelta.x = 0f;
			}
		}
	}

	// Token: 0x06000B0A RID: 2826 RVA: 0x000EC084 File Offset: 0x000EA284
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
			int num8 = (this.StartID >> (int)this.TileMapInfoWidthMaxOffSet) + updownTime & (int)this.TileMapInfoHeightMaxSubtractOne & 1;
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
			int num13 = (this.StartID >> (int)this.TileMapInfoWidthMaxOffSet) + updownTime & (int)this.TileMapInfoHeightMaxSubtractOne & 1;
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
		in_Startpointy += updownTime;
		in_Startpointy &= (int)this.TileMapInfoHeightMaxSubtractOne;
		this.BoundStartX += rightleftTime;
		in_Startpointx += rightleftTime;
		in_Startpointx &= (int)this.TileMapInfoWidthMaxSubtractOne;
		return result;
	}

	// Token: 0x06000B0B RID: 2827 RVA: 0x000EC93C File Offset: 0x000EAB3C
	private void SetTileSpriteByMapInfo(int MapInfoid, ref Image iTileImage)
	{
		if (this.TileMapInfoEx == null || this.TileMapInfoEx[MapInfoid] == 0)
		{
			iTileImage.sprite = this.TileSprites.GetSprite((int)this.TileMapInfo[MapInfoid]);
			iTileImage.color = Color.white;
		}
		else
		{
			byte b = this.TileMapInfoEx[MapInfoid];
			if (b > 191)
			{
				iTileImage.sprite = this.TileSprites.GetSprite((int)b);
				iTileImage.color = Color.white;
			}
			else if (b == 1)
			{
				iTileImage.sprite = this.TileSprites.GetSprite(99);
				iTileImage.color = this.color_1;
			}
			else if (b > 1 && b < 6)
			{
				iTileImage.sprite = this.TileSprites.GetSprite((int)(103 + b));
				iTileImage.color = this.color_2;
			}
			else if (b > 5 && b < 10)
			{
				iTileImage.sprite = this.TileSprites.GetSprite((int)(95 + b));
				iTileImage.color = this.color_2;
			}
			else
			{
				iTileImage.sprite = this.TileSprites.GetSprite(22);
				iTileImage.color = Color.white;
			}
		}
	}

	// Token: 0x06000B0C RID: 2828 RVA: 0x000ECA90 File Offset: 0x000EAC90
	private void ChangeTileSpriteByMapInfo(int MapInfoid, ref Image iTileImage)
	{
		if (this.TileMapInfo[MapInfoid] < 22)
		{
			iTileImage.sprite = this.TileSprites.GetSprite((int)this.TileMapInfo[MapInfoid]);
		}
		else if (this.TileMapInfo[MapInfoid] < 35)
		{
			iTileImage.sprite = this.TileSprites.GetSprite(22);
		}
		else if (this.TileMapInfo[MapInfoid] < 49)
		{
			iTileImage.sprite = this.TileSprites.GetSprite(35);
		}
		else if (this.TileMapInfo[MapInfoid] < 69)
		{
			iTileImage.sprite = this.TileSprites.GetSprite((int)this.TileMapInfo[MapInfoid]);
		}
		else if (this.TileMapInfo[MapInfoid] < 79)
		{
			iTileImage.sprite = this.TileSprites.GetSprite(69);
		}
		else if (this.TileMapInfo[MapInfoid] < 109)
		{
			iTileImage.sprite = this.TileSprites.GetSprite((int)this.TileMapInfo[MapInfoid]);
		}
		else if (this.TileMapInfo[MapInfoid] < 113)
		{
			iTileImage.sprite = ((this.TileMapInfoEx != null && this.TileMapInfoEx[MapInfoid] != 0) ? this.TileSprites.GetSprite((int)this.TileMapInfoEx[MapInfoid]) : this.TileSprites.GetSprite(22));
		}
		iTileImage.color = Color.white;
	}

	// Token: 0x06000B0D RID: 2829 RVA: 0x000ECC00 File Offset: 0x000EAE00
	public void UpdateTickImage()
	{
		if (this.frontIsSheep == 0)
		{
			for (int i = 0; i < (int)this.frontTickImageNum; i++)
			{
				if (this.tickImage[i] != null)
				{
					this.tickImage[i].color = this.wolfTickYolkImageColor;
				}
			}
			for (int j = 1; j <= (int)this.backTickImageNum; j++)
			{
				int num = 256 - j;
				if (this.tickImage[num] != null)
				{
					this.tickImage[num].color = this.sheepTickYolkImageColor;
				}
			}
		}
		else
		{
			for (int k = 0; k < (int)this.frontTickImageNum; k++)
			{
				if (this.tickImage[k] != null)
				{
					this.tickImage[k].color = this.sheepTickYolkImageColor;
				}
			}
			for (int l = 1; l <= (int)this.backTickImageNum; l++)
			{
				int num2 = 256 - l;
				if (this.tickImage[num2] != null)
				{
					this.tickImage[num2].color = this.wolfTickYolkImageColor;
				}
			}
		}
	}

	// Token: 0x06000B0E RID: 2830 RVA: 0x000ECD2C File Offset: 0x000EAF2C
	private void SetTickImage(Image in_image, int in_col, int in_row, bool bseep)
	{
		if (bseep)
		{
			if (this.frontIsSheep == 0)
			{
				this.backTickImageNum += 1;
				byte b = (byte)(256 - this.backTickImageNum);
				this.tickImageIDToColRow[(int)b] = (byte)((in_col << 4 | in_row) & 255);
				this.tickColRowToImageID[in_col][in_row] = (ushort)b;
				this.tickImage[(int)b] = in_image;
				this.tickImage[(int)b].color = this.sheepTickYolkImageColor;
			}
			else
			{
				this.tickImageIDToColRow[(int)this.frontTickImageNum] = (byte)((in_col << 4 | in_row) & 255);
				this.tickColRowToImageID[in_col][in_row] = this.frontTickImageNum;
				this.tickImage[(int)this.frontTickImageNum] = in_image;
				this.tickImage[(int)this.frontTickImageNum].color = this.sheepTickYolkImageColor;
				this.frontTickImageNum += 1;
			}
		}
		else if (this.frontIsSheep == 0)
		{
			this.tickImageIDToColRow[(int)this.frontTickImageNum] = (byte)((in_col << 4 | in_row) & 255);
			this.tickColRowToImageID[in_col][in_row] = this.frontTickImageNum;
			this.tickImage[(int)this.frontTickImageNum] = in_image;
			this.tickImage[(int)this.frontTickImageNum].color = this.wolfTickYolkImageColor;
			this.frontTickImageNum += 1;
		}
		else
		{
			this.backTickImageNum += 1;
			byte b2 = (byte)(256 - this.backTickImageNum);
			this.tickImageIDToColRow[(int)b2] = (byte)((in_col << 4 | in_row) & 255);
			this.tickColRowToImageID[in_col][in_row] = (ushort)b2;
			this.tickImage[(int)b2] = in_image;
			this.tickImage[(int)b2].color = this.wolfTickYolkImageColor;
		}
	}

	// Token: 0x06000B0F RID: 2831 RVA: 0x000ECED4 File Offset: 0x000EB0D4
	private void CheckTickImageRecycling(int in_col, int in_row)
	{
		if (in_col < this.tickColRowToImageID.Length && in_row < this.tickColRowToImageID[in_col].Length && this.tickColRowToImageID[in_col][in_row] < 256 && this.tickImage[(int)this.tickColRowToImageID[in_col][in_row]] != null)
		{
			byte b = (byte)this.tickColRowToImageID[in_col][in_row];
			if ((ushort)b < this.frontTickImageNum)
			{
				this.frontTickImageNum -= 1;
				this.tickImageIDToColRow[(int)b] = this.tickImageIDToColRow[(int)this.frontTickImageNum];
				this.tickColRowToImageID[this.tickImageIDToColRow[(int)this.frontTickImageNum] >> 4 & 15][(int)(this.tickImageIDToColRow[(int)this.frontTickImageNum] & 15)] = (ushort)b;
				this.tickImage[(int)b].color = Color.white;
				this.tickImage[(int)b] = this.tickImage[(int)this.frontTickImageNum];
				this.tickImageIDToColRow[(int)this.frontTickImageNum] = 0;
				this.tickColRowToImageID[in_col][in_row] = 256;
				this.tickImage[(int)this.frontTickImageNum] = null;
			}
			else if ((ushort)b >= 256 - this.backTickImageNum)
			{
				byte b2 = (byte)(256 - this.backTickImageNum);
				this.backTickImageNum -= 1;
				this.tickImageIDToColRow[(int)b] = this.tickImageIDToColRow[(int)b2];
				this.tickColRowToImageID[this.tickImageIDToColRow[(int)b2] >> 4 & 15][(int)(this.tickImageIDToColRow[(int)b2] & 15)] = (ushort)b;
				this.tickImage[(int)b].color = Color.white;
				this.tickImage[(int)b] = this.tickImage[(int)b2];
				this.tickImageIDToColRow[(int)b2] = 0;
				this.tickColRowToImageID[in_col][in_row] = 256;
				this.tickImage[(int)b2] = null;
			}
		}
	}

	// Token: 0x06000B10 RID: 2832 RVA: 0x000ED090 File Offset: 0x000EB290
	private void UpdateMap(int rowsatrt, int rowend, int colstart, int colend, int startPointX, int startPointY)
	{
		Vector2 in_StartMapInfoID = new Vector2((float)startPointX, (float)startPointY);
		Vector2 zero = Vector2.zero;
		Vector2 pos = Vector2.zero;
		for (int i = rowsatrt; i < rowend; i++)
		{
			int num = this.BoundStartY + i;
			bool flag = num < 0 || num > (int)this.TileMapInfoHeightMaxSubtractOne;
			int num2 = this.TileColMapStartIDOffset + i & (int)this.TileRowNumSubtractOne;
			for (int j = colstart; j < colend; j++)
			{
				int emojiID = -1;
				int num3 = this.TileRowMapStartIDOffset + j & (int)this.TileColNumSubtractOne;
				Image image = this.TileBaseImage[num3][num2];
				zero.x = (float)j;
				zero.y = (float)i;
				int tileMapInfoID = this.getTileMapInfoID(zero, in_StartMapInfoID);
				int num4 = this.BoundStartX + j;
				bool flag2 = flag || num4 < 0 || num4 > (int)this.TileMapInfoWidthMaxSubtractOne;
				if (this.level == null)
				{
					this.CheckTickImageRecycling(num3, num2);
					this.SetTileSpriteByMapInfo(tileMapInfoID, ref image);
					if (flag2)
					{
						image.color = Color.gray;
					}
					image.SetNativeSize();
					RectTransform rectTransform = this.TileBaseRectTransform[num3][num2];
					rectTransform.anchoredPosition = Vector2.up * (rectTransform.sizeDelta.y * this.TileBaseScale - (float)this.TileHeight) * 0.5f;
					this.OverTileBaseGameObject[num3][num2].SetActive(false);
				}
				else if (flag2)
				{
					this.CheckTickImageRecycling(num3, num2);
					this.SetTileSpriteByMapInfo(tileMapInfoID, ref image);
					image.color = Color.gray;
					image.SetNativeSize();
					RectTransform rectTransform = this.TileBaseRectTransform[num3][num2];
					rectTransform.anchoredPosition = Vector2.up * (rectTransform.sizeDelta.y * this.TileBaseScale - (float)this.TileHeight) * 0.5f;
					this.level.setLevelImage(0, num2, num3, Vector2.zero, false);
					this.bloodname.setName(null, null, num2, num3, Color.white, Vector2.zero, 0, 0f, 0, null, -1, 0f);
					this.graphic.setGraphicImage(0, num2, num3, Vector2.zero, ushort.MaxValue);
					this.effect.setEffect(0, num2, num3, Vector2.zero, 11);
					this.npc.setNPC(0, 0u, num2, num3, pos);
					this.OverTileBaseGameObject[num3][num2].SetActive(false);
				}
				else
				{
					POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)tileMapInfoID);
					if (layoutMapInfoPointKind == POINT_KIND.PK_YOLK)
					{
						this.SetTileSpriteByMapInfo(tileMapInfoID, ref image);
						image.SetNativeSize();
						RectTransform rectTransform = this.TileBaseRectTransform[num3][num2];
						rectTransform.anchoredPosition = Vector2.up * (rectTransform.sizeDelta.y * this.TileBaseScale - (float)this.TileHeight) * 0.5f;
						this.level.setLevelImage(0, num2, num3, Vector2.zero, false);
						if (tileMapInfoID == 130944 || tileMapInfoID == 130943)
						{
							this.bloodname.setName(null, null, num2, num3, Color.white, Vector2.zero, 0, 0f, 0, null, -1, 0f);
							this.graphic.setGraphicImage(0, num2, num3, Vector2.zero, ushort.MaxValue);
							this.effect.setEffect(0, num2, num3, pos, 0);
						}
						else
						{
							ushort tableID = DataManager.MapDataController.LayoutMapInfo[tileMapInfoID].tableID;
							MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int)tableID];
							pos = this.TileRowGroupRectTransform[num2].anchoredPosition + this.TileObjectRectTransform[num3][num2].anchoredPosition;
							if ((mapYolk.baseFlag & 1) != 0)
							{
								emojiID = (int)mapYolk.emojiID;
							}
							if (mapYolk.WonderState == 255)
							{
								this.bloodname.setName(null, null, num2, num3, Color.white, Vector2.zero, 0, 0f, 0, null, -1, 0f);
							}
							else if (DataManager.MapDataController.FocusKingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
							{
								if (mapYolk.WonderLeader == null || mapYolk.WonderLeader.Length == 0 || mapYolk.WonderLeader[0] == '\0')
								{
									this.bloodname.setName(DataManager.MapDataController.GetYolkName((ushort)mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID), mapYolk.WonderAllianceTag, num2, num3, (mapYolk.WonderState != 0) ? this.yolknamecolor : Color.green, pos, 0, 0f, 0, null, emojiID, (mapYolk.WonderID <= 0) ? 410f : 300f);
								}
								else if (ActivityManager.Instance.IsKOWRunning(false))
								{
									this.tmepStr.ClearString();
									if (mapYolk.WonderID == 0)
									{
										this.tmepStr.Append(DataManager.Instance.mStringTable.GetStringByID(11031u));
									}
									else
									{
										this.tmepStr.Append(DataManager.Instance.mStringTable.GetStringByID(11057u));
									}
									if (DataManager.Instance.IsSameAlliance(mapYolk.WonderAllianceTag))
									{
										this.bloodname.setName(mapYolk.WonderLeader, mapYolk.WonderAllianceTag, num2, num3, this.lightblue, pos, 0, 0f, (mapYolk.LeaderHomeKingdomID != DataManager.MapDataController.kingdomData.kingdomID) ? mapYolk.LeaderHomeKingdomID : 0, this.tmepStr, emojiID, (mapYolk.WonderID <= 0) ? 410f : 300f);
									}
									else
									{
										this.bloodname.setName(mapYolk.WonderLeader, mapYolk.WonderAllianceTag, num2, num3, (mapYolk.WonderState != 0) ? this.yolknamecolor : Color.green, pos, 0, 0f, (mapYolk.LeaderHomeKingdomID != DataManager.MapDataController.kingdomData.kingdomID) ? mapYolk.LeaderHomeKingdomID : 0, this.tmepStr, emojiID, (mapYolk.WonderID <= 0) ? 410f : 300f);
									}
								}
								else if (ActivityManager.Instance.IsNobilityWarRunning(false) && ActivityManager.Instance.FederalFightingWonderID == mapYolk.WonderID)
								{
									this.tmepStr.ClearString();
									if (mapYolk.WonderID == 0)
									{
										this.tmepStr.Append(DataManager.Instance.mStringTable.GetStringByID(10013u));
									}
									else
									{
										this.tmepStr.Append(DataManager.Instance.mStringTable.GetStringByID(11031u));
									}
									if (DataManager.Instance.IsSameAlliance(mapYolk.WonderAllianceTag))
									{
										this.bloodname.setName(mapYolk.WonderLeader, mapYolk.WonderAllianceTag, num2, num3, this.lightblue, pos, 0, 0f, (mapYolk.LeaderHomeKingdomID != DataManager.MapDataController.kingdomData.kingdomID) ? mapYolk.LeaderHomeKingdomID : 0, this.tmepStr, emojiID, (mapYolk.WonderID <= 0) ? 410f : 300f);
									}
									else
									{
										this.bloodname.setName(mapYolk.WonderLeader, mapYolk.WonderAllianceTag, num2, num3, (mapYolk.WonderState != 0) ? this.yolknamecolor : Color.green, pos, 0, 0f, (mapYolk.LeaderHomeKingdomID != DataManager.MapDataController.kingdomData.kingdomID) ? mapYolk.LeaderHomeKingdomID : 0, this.tmepStr, emojiID, (mapYolk.WonderID <= 0) ? 410f : 300f);
									}
								}
								else
								{
									this.tmepStr.ClearString();
									if (mapYolk.WonderID == 0)
									{
										this.tmepStr.Append(DataManager.Instance.mStringTable.GetStringByID(10013u));
									}
									else
									{
										this.tmepStr.Append(DataManager.Instance.mStringTable.GetStringByID(11057u));
									}
									if (DataManager.Instance.IsSameAlliance(mapYolk.WonderAllianceTag))
									{
										this.bloodname.setName(mapYolk.WonderLeader, mapYolk.WonderAllianceTag, num2, num3, this.lightblue, pos, 0, 0f, (mapYolk.LeaderHomeKingdomID != DataManager.MapDataController.kingdomData.kingdomID) ? mapYolk.LeaderHomeKingdomID : 0, this.tmepStr, emojiID, (mapYolk.WonderID <= 0) ? 410f : 300f);
									}
									else
									{
										this.bloodname.setName(mapYolk.WonderLeader, mapYolk.WonderAllianceTag, num2, num3, (mapYolk.WonderState != 0) ? this.yolknamecolor : Color.green, pos, 0, 0f, (mapYolk.LeaderHomeKingdomID != DataManager.MapDataController.kingdomData.kingdomID) ? mapYolk.LeaderHomeKingdomID : 0, this.tmepStr, emojiID, (mapYolk.WonderID <= 0) ? 410f : 300f);
									}
								}
							}
							else if (DataManager.Instance.IsSameAlliance(mapYolk.WonderAllianceTag))
							{
								this.bloodname.setName(DataManager.MapDataController.GetYolkName((ushort)mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID), mapYolk.WonderAllianceTag, num2, num3, this.lightblue, pos, 0, 0f, (mapYolk.WonderAllianceTag[0] != '\0' && mapYolk.AllianceKingdomID != DataManager.Instance.RoleAlliance.KingdomID) ? mapYolk.AllianceKingdomID : 0, null, emojiID, (mapYolk.WonderID <= 0) ? 410f : 300f);
							}
							else
							{
								this.bloodname.setName(DataManager.MapDataController.GetYolkName((ushort)mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID), mapYolk.WonderAllianceTag, num2, num3, (mapYolk.WonderState != 0) ? this.yolknamecolor : Color.green, pos, 0, 0f, (mapYolk.WonderAllianceTag[0] != '\0' && mapYolk.AllianceKingdomID != DataManager.Instance.RoleAlliance.KingdomID) ? mapYolk.AllianceKingdomID : 0, null, emojiID, (mapYolk.WonderID <= 0) ? 410f : 300f);
							}
							if (mapYolk.WonderAllianceTag[0] == '\0')
							{
								this.graphic.setGraphicImage(0, num2, num3, Vector2.zero, ushort.MaxValue);
							}
							else
							{
								this.graphic.setGraphicImage((int)(-(int)(mapYolk.WonderID + 1)), num2, num3, pos, mapYolk.OwnerEmblem);
							}
							this.effect.setEffect(mapYolk.WonderFlag, num2, num3, pos, (mapYolk.WonderID != 0) ? 1 : 2);
						}
						this.npc.setNPC(0, 0u, num2, num3, pos);
						this.yolk.setYolk(tileMapInfoID, pos);
						this.OverTileBaseGameObject[num3][num2].SetActive(false);
					}
					else if (layoutMapInfoPointKind == POINT_KIND.PK_DYNAMIC_OBSTACLE)
					{
						this.CheckTickImageRecycling(num3, num2);
						this.SetTileSpriteByMapInfo(tileMapInfoID, ref image);
						image.SetNativeSize();
						RectTransform rectTransform = this.TileBaseRectTransform[num3][num2];
						rectTransform.anchoredPosition = Vector2.up * (rectTransform.sizeDelta.y * this.TileBaseScale - (float)this.TileHeight) * 0.5f;
						this.level.setLevelImage(0, num2, num3, Vector2.zero, false);
						this.bloodname.setName(null, null, num2, num3, Color.white, Vector2.zero, 0, 0f, 0, null, -1, 0f);
						this.graphic.setGraphicImage(0, num2, num3, Vector2.zero, ushort.MaxValue);
						pos = this.TileRowGroupRectTransform[num2].anchoredPosition + this.TileObjectRectTransform[num3][num2].anchoredPosition;
						if (DataManager.MapDataController.LayoutMapInfo[tileMapInfoID].tableID == 1)
						{
							this.effect.setEffect(16, num2, num3, pos, 4);
						}
						else
						{
							this.effect.setEffect(16, num2, num3, pos, 3);
						}
						this.npc.setNPC(0, 0u, num2, num3, pos);
						this.OverTileBaseGameObject[num3][num2].SetActive(false);
					}
					else if (layoutMapInfoPointKind != POINT_KIND.PK_NONE)
					{
						pos = this.TileRowGroupRectTransform[num2].anchoredPosition + this.TileObjectRectTransform[num3][num2].anchoredPosition;
						this.ChangeTileSpriteByMapInfo(tileMapInfoID, ref image);
						image.SetNativeSize();
						RectTransform rectTransform = this.TileBaseRectTransform[num3][num2];
						rectTransform.anchoredPosition = Vector2.up * (rectTransform.sizeDelta.y * this.TileBaseScale - (float)this.TileHeight) * 0.5f;
						image = this.OverTileBaseImage[num3][num2];
						rectTransform = this.OverTileBaseRectTransform[num3][num2];
						ushort tableID2 = DataManager.MapDataController.LayoutMapInfo[tileMapInfoID].tableID;
						if (layoutMapInfoPointKind == POINT_KIND.PK_CITY)
						{
							PlayerPoint playerPoint = DataManager.MapDataController.PlayerPointTable[(int)tableID2];
							bool flag3 = DataManager.MapDataController.IsEnemy(playerPoint.kingdomID);
							if (playerPoint.cityProperty != CITY_PROPERTY.CP_NPC && this.bGraphicFake == 1)
							{
								TitleData recordByKey = DataManager.Instance.TitleDataW.GetRecordByKey(1);
								this.graphic.setGraphicImage(this.worldTitleIconStartID + (int)recordByKey.IconID, num2, num3, pos, ushort.MaxValue);
							}
							else if (playerPoint.worldTitle == WORLD_PLAYER_DESIGNATION.WKD_1)
							{
								TitleData recordByKey = DataManager.Instance.TitleDataW.GetRecordByKey((ushort)playerPoint.worldTitle);
								this.graphic.setGraphicImage(this.worldTitleIconStartID + (int)recordByKey.IconID, num2, num3, pos, ushort.MaxValue);
							}
							else if (playerPoint.nobilityTitle == 1)
							{
								TitleData recordByKey = DataManager.Instance.TitleDataF.GetRecordByKey((ushort)playerPoint.nobilityTitle);
								this.graphic.setGraphicImage(this.nobilityTitleIconStartID + (int)recordByKey.IconID, num2, num3, pos, ushort.MaxValue);
							}
							else if (playerPoint.kingdomTitle == KINGDOM_DESIGNATION.KD_1)
							{
								TitleData recordByKey = DataManager.Instance.TitleData.GetRecordByKey((ushort)playerPoint.kingdomTitle);
								this.graphic.setGraphicImage(this.kingdomTitleIconStartID + (int)recordByKey.IconID, num2, num3, pos, ushort.MaxValue);
							}
							else if (playerPoint.worldTitle > WORLD_PLAYER_DESIGNATION.WKD_1 && playerPoint.worldTitle < WORLD_PLAYER_DESIGNATION.WKD_MAX)
							{
								TitleData recordByKey = DataManager.Instance.TitleDataW.GetRecordByKey((ushort)playerPoint.worldTitle);
								this.graphic.setGraphicImage(this.worldTitleIconStartID + (int)recordByKey.IconID, num2, num3, pos, ushort.MaxValue);
							}
							else if (playerPoint.nobilityTitle > 1 && playerPoint.nobilityTitle < 40)
							{
								TitleData recordByKey = DataManager.Instance.TitleDataF.GetRecordByKey((ushort)playerPoint.nobilityTitle);
								this.graphic.setGraphicImage(this.nobilityTitleIconStartID + (int)recordByKey.IconID, num2, num3, pos, ushort.MaxValue);
							}
							else if (playerPoint.kingdomTitle > KINGDOM_DESIGNATION.KD_1 && playerPoint.kingdomTitle < KINGDOM_DESIGNATION.KD_MAX)
							{
								TitleData recordByKey = DataManager.Instance.TitleData.GetRecordByKey((ushort)playerPoint.kingdomTitle);
								this.graphic.setGraphicImage(this.kingdomTitleIconStartID + (int)recordByKey.IconID, num2, num3, pos, ushort.MaxValue);
							}
							else if ((playerPoint.capitalFlag & 8) != 0)
							{
								this.graphic.setGraphicImage(this.kingdomTitleIconStartID, num2, num3, pos, ushort.MaxValue);
							}
							else
							{
								this.graphic.setGraphicImage(0, num2, num3, pos, ushort.MaxValue);
							}
							this.npc.setNPC(0, 0u, num2, num3, pos);
							if ((playerPoint.baseFlag & 1) != 0)
							{
								emojiID = (int)playerPoint.emojiID;
							}
							if (playerPoint.cityProperty == CITY_PROPERTY.CP_NPC)
							{
								this.CheckTickImageRecycling(num3, num2);
								this.effect.setEffect(playerPoint.capitalFlag, num2, num3, pos, 4);
								this.level.setLevelImage((int)playerPoint.level, num2, num3, pos, true);
								this.bloodname.setName(playerPoint.allianceTag, num2, num3, this.npcnamecolor, pos, emojiID);
								if (playerPoint.cityOutward != CITY_OUTWARD.CO_PLAYER)
								{
									if (playerPoint.cityOutward > CITY_OUTWARD.CO_MAX)
									{
										image.sprite = this.TileSprites.GetSprite(190);
									}
									else
									{
										image.sprite = this.TileSprites.GetSprite((int)(151 + playerPoint.cityOutward - CITY_OUTWARD.CO_EMEMY));
									}
								}
								else if (playerPoint.level < 9)
								{
									image.sprite = this.TileSprites.GetSprite(145);
								}
								else if (playerPoint.level < 17)
								{
									image.sprite = this.TileSprites.GetSprite(146);
								}
								else if (playerPoint.level < 25)
								{
									image.sprite = this.TileSprites.GetSprite(147);
								}
								else
								{
									image.sprite = this.TileSprites.GetSprite(148);
								}
							}
							else
							{
								this.effect.setEffect(playerPoint.capitalFlag, num2, num3, pos, 3);
								this.level.setLevelImage((int)playerPoint.level, num2, num3, pos, false);
								if (playerPoint.playerName == null || playerPoint.playerName.Length == 0)
								{
									this.bloodname.setName(playerPoint.playerName, playerPoint.allianceTag, num2, num3, Color.white, pos, 0, 0f, 0, null, emojiID, 92f);
								}
								else if (DataManager.CompareStr(playerPoint.playerName, DataManager.Instance.RoleAttr.Name) == 0)
								{
									this.bloodname.setName(playerPoint.playerName, playerPoint.allianceTag, num2, num3, this.deepblue, pos, 0, 0f, 0, null, emojiID, 92f);
								}
								else if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && flag3)
								{
									this.bloodname.setName(playerPoint.playerName, playerPoint.allianceTag, num2, num3, this.lightred, pos, 0, 0f, playerPoint.kingdomID, null, emojiID, 92f);
								}
								else if (DataManager.Instance.IsSameAlliance(playerPoint.allianceTag))
								{
									this.bloodname.setName(playerPoint.playerName, playerPoint.allianceTag, num2, num3, this.lightblue, pos, 0, 0f, 0, null, emojiID, 92f);
								}
								else
								{
									this.bloodname.setName(playerPoint.playerName, playerPoint.allianceTag, num2, num3, this.lightyellow, pos, 0, 0f, 0, null, emojiID, 92f);
								}
								if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && flag3 && !this.bFront)
								{
									image.sprite = this.TileSprites.GetSprite(151);
									EKvKKingdomType kvKKingdomType = ActivityManager.Instance.getKvKKingdomType(playerPoint.kingdomID);
									if (kvKKingdomType == EKvKKingdomType.EKKT_Hunter)
									{
										ushort num5 = this.tickColRowToImageID[num3][num2];
										if (num5 < 256 && this.tickImage[(int)num5] != null)
										{
											if (this.frontIsSheep == 0)
											{
												if (num5 >= 256 - this.backTickImageNum)
												{
													byte b = (byte)(256 - this.backTickImageNum);
													this.backTickImageNum -= 1;
													this.tickImageIDToColRow[(int)num5] = this.tickImageIDToColRow[(int)b];
													this.tickColRowToImageID[this.tickImageIDToColRow[(int)b] >> 4 & 15][(int)(this.tickImageIDToColRow[(int)b] & 15)] = num5;
													this.tickImage[(int)num5].color = Color.white;
													this.tickImage[(int)num5] = this.tickImage[(int)b];
													this.tickImageIDToColRow[(int)b] = 0;
													this.tickColRowToImageID[num3][num2] = 256;
													this.tickImage[(int)b] = null;
													this.SetTickImage(image, num3, num2, false);
												}
											}
											else if (num5 < this.frontTickImageNum)
											{
												this.frontTickImageNum -= 1;
												this.tickImageIDToColRow[(int)num5] = this.tickImageIDToColRow[(int)this.frontTickImageNum];
												this.tickColRowToImageID[this.tickImageIDToColRow[(int)this.frontTickImageNum] >> 4 & 15][(int)(this.tickImageIDToColRow[(int)this.frontTickImageNum] & 15)] = num5;
												this.tickImage[(int)num5].color = Color.white;
												this.tickImage[(int)num5] = this.tickImage[(int)this.frontTickImageNum];
												this.tickImageIDToColRow[(int)this.frontTickImageNum] = 0;
												this.tickColRowToImageID[num3][num2] = 256;
												this.tickImage[(int)this.frontTickImageNum] = null;
												this.SetTickImage(image, num3, num2, false);
											}
										}
										else
										{
											this.SetTickImage(image, num3, num2, false);
										}
									}
									else if (kvKKingdomType == EKvKKingdomType.EKKT_Target)
									{
										ushort num6 = this.tickColRowToImageID[num3][num2];
										if (num6 < 256 && this.tickImage[(int)num6] != null)
										{
											if (this.frontIsSheep == 0)
											{
												if (num6 < this.frontTickImageNum)
												{
													this.frontTickImageNum -= 1;
													this.tickImageIDToColRow[(int)num6] = this.tickImageIDToColRow[(int)this.frontTickImageNum];
													this.tickColRowToImageID[this.tickImageIDToColRow[(int)this.frontTickImageNum] >> 4 & 15][(int)(this.tickImageIDToColRow[(int)this.frontTickImageNum] & 15)] = num6;
													this.tickImage[(int)num6].color = Color.white;
													this.tickImage[(int)num6] = this.tickImage[(int)this.frontTickImageNum];
													this.tickImageIDToColRow[(int)this.frontTickImageNum] = 0;
													this.tickColRowToImageID[num3][num2] = 256;
													this.tickImage[(int)this.frontTickImageNum] = null;
													this.SetTickImage(image, num3, num2, true);
												}
											}
											else if (num6 >= 256 - this.backTickImageNum)
											{
												byte b2 = (byte)(256 - this.backTickImageNum);
												this.backTickImageNum -= 1;
												this.tickImageIDToColRow[(int)num6] = this.tickImageIDToColRow[(int)b2];
												this.tickColRowToImageID[this.tickImageIDToColRow[(int)b2] >> 4 & 15][(int)(this.tickImageIDToColRow[(int)b2] & 15)] = num6;
												this.tickImage[(int)num6].color = Color.white;
												this.tickImage[(int)num6] = this.tickImage[(int)b2];
												this.tickImageIDToColRow[(int)b2] = 0;
												this.tickColRowToImageID[num3][num2] = 256;
												this.tickImage[(int)b2] = null;
												this.SetTickImage(image, num3, num2, true);
											}
										}
										else
										{
											this.SetTickImage(image, num3, num2, true);
										}
									}
									else
									{
										this.CheckTickImageRecycling(num3, num2);
									}
								}
								else
								{
									this.CheckTickImageRecycling(num3, num2);
									if (playerPoint.cityOutward != CITY_OUTWARD.CO_PLAYER)
									{
										if (playerPoint.cityOutward > CITY_OUTWARD.CO_MAX)
										{
											image.sprite = this.TileSprites.GetSprite(190);
										}
										else
										{
											image.sprite = this.TileSprites.GetSprite((int)(151 + playerPoint.cityOutward - CITY_OUTWARD.CO_EMEMY));
										}
									}
									else if (playerPoint.level < 9)
									{
										image.sprite = this.TileSprites.GetSprite(145);
									}
									else if (playerPoint.level < 17)
									{
										image.sprite = this.TileSprites.GetSprite(146);
									}
									else if (playerPoint.level < 25)
									{
										image.sprite = this.TileSprites.GetSprite(147);
									}
									else
									{
										image.sprite = this.TileSprites.GetSprite(148);
									}
								}
							}
						}
						else if (layoutMapInfoPointKind == POINT_KIND.PK_CAMP)
						{
							this.CheckTickImageRecycling(num3, num2);
							PlayerPoint playerPoint2 = DataManager.MapDataController.PlayerPointTable[(int)tableID2];
							if ((playerPoint2.baseFlag & 1) != 0)
							{
								emojiID = (int)playerPoint2.emojiID;
							}
							this.level.setLevelImage(0, num2, num3, pos, false);
							this.bloodname.setName(null, null, num2, num3, Color.white, pos, 0, 0f, 0, null, emojiID, 92f);
							this.graphic.setGraphicImage(0, num2, num3, pos, ushort.MaxValue);
							this.effect.setEffect(0, num2, num3, pos, 11);
							this.npc.setNPC(0, 0u, num2, num3, pos);
							image.sprite = this.TileSprites.GetSprite(149);
						}
						else
						{
							if (layoutMapInfoPointKind == POINT_KIND.PK_NPC)
							{
								this.CheckTickImageRecycling(num3, num2);
								NPCPoint npcpoint = DataManager.MapDataController.NPCPointTable[(int)tableID2];
								if ((npcpoint.baseFlag & 1) != 0)
								{
									emojiID = (int)npcpoint.emojiID;
								}
								this.level.setLevelImage(0, num2, num3, pos, false);
								this.bloodname.setName(npcpoint.NPCNum, num2, num3, this.npcnamecolor, pos, ((npcpoint.baseFlag & 4) == 0) ? npcpoint.level : 0, npcpoint.Blood, emojiID, npcpoint.NPCAllianceTag, (short)tableID2);
								this.graphic.setGraphicImage(0, num2, num3, pos, ushort.MaxValue);
								this.effect.setEffect(0, num2, num3, pos, 0);
								this.npc.setNPC(npcpoint.NPCNum, (uint)tileMapInfoID, num2, num3, pos);
								this.OverTileBaseGameObject[num3][num2].SetActive(false);
								goto IL_1E47;
							}
							this.CheckTickImageRecycling(num3, num2);
							ResourcesPoint resourcesPoint = DataManager.MapDataController.ResourcesPointTable[(int)tableID2];
							if ((resourcesPoint.baseFlag & 1) != 0)
							{
								emojiID = (int)resourcesPoint.emojiID;
							}
							this.level.setLevelImage((int)resourcesPoint.level, num2, num3, pos, false);
							this.bloodname.setName(null, null, num2, num3, Color.white, pos, 0, 0f, 0, null, emojiID, 92f);
							if (resourcesPoint.playerName == null || resourcesPoint.playerName.Length == 0)
							{
								this.graphic.setGraphicImage(0, num2, num3, pos, ushort.MaxValue);
							}
							else if (DataManager.CompareStr(resourcesPoint.playerName, DataManager.Instance.RoleAttr.Name) == 0)
							{
								this.graphic.setGraphicImage(2, num2, num3, pos, ushort.MaxValue);
							}
							else if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && DataManager.MapDataController.IsEnemy(resourcesPoint.kingdomID))
							{
								this.graphic.setGraphicImage(4, num2, num3, pos, ushort.MaxValue);
							}
							else if (DataManager.Instance.IsSameAlliance(resourcesPoint.allianceTag))
							{
								this.graphic.setGraphicImage(1, num2, num3, pos, ushort.MaxValue);
							}
							else
							{
								this.graphic.setGraphicImage(3, num2, num3, pos, ushort.MaxValue);
							}
							this.effect.setEffect(0, num2, num3, pos, 11);
							this.npc.setNPC(0, 0u, num2, num3, pos);
							image.sprite = this.TileSprites.GetSprite((int)(138 + layoutMapInfoPointKind));
						}
						image.SetNativeSize();
						Bounds bounds = image.sprite.bounds;
						rectTransform.pivot = Vector2.one * 0.5f + Vector2.right * (-bounds.center.x / bounds.extents.x / 2f);
						rectTransform.anchoredPosition = Vector2.up * (rectTransform.sizeDelta.y * this.TileBaseScale - (float)this.TileHeight) * 0.5f;
						this.OverTileBaseGameObject[num3][num2].SetActive(true);
					}
					else
					{
						this.CheckTickImageRecycling(num3, num2);
						this.SetTileSpriteByMapInfo(tileMapInfoID, ref image);
						image.SetNativeSize();
						RectTransform rectTransform = this.TileBaseRectTransform[num3][num2];
						rectTransform.anchoredPosition = Vector2.up * (rectTransform.sizeDelta.y * this.TileBaseScale - (float)this.TileHeight) * 0.5f;
						this.level.setLevelImage(0, num2, num3, Vector2.zero, false);
						this.bloodname.setName(null, null, num2, num3, Color.white, Vector2.zero, 0, 0f, 0, null, -1, 0f);
						this.graphic.setGraphicImage(0, num2, num3, Vector2.zero, ushort.MaxValue);
						this.effect.setEffect(0, num2, num3, Vector2.zero, 0);
						this.npc.setNPC(0, 0u, num2, num3, Vector2.zero);
						if (this.TileMapInfo[tileMapInfoID] > 98 && this.TileMapInfo[tileMapInfoID] < 109)
						{
							pos = this.TileRowGroupRectTransform[num2].anchoredPosition + this.TileObjectRectTransform[num3][num2].anchoredPosition;
							this.yolk.setYolk(tileMapInfoID, pos);
						}
						this.OverTileBaseGameObject[num3][num2].SetActive(false);
					}
				}
				IL_1E47:;
			}
		}
	}

	// Token: 0x06000B11 RID: 2833 RVA: 0x000EEF04 File Offset: 0x000ED104
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

	// Token: 0x06000B12 RID: 2834 RVA: 0x000EF19C File Offset: 0x000ED39C
	private int getTileMapInfoIDbyStartID(Vector2 in_TileBaseID)
	{
		return this.getTileMapInfoID(in_TileBaseID, new Vector2((float)(this.StartID & (int)this.TileMapInfoWidthMaxSubtractOne), (float)(this.StartID >> (int)this.TileMapInfoWidthMaxOffSet)));
	}

	// Token: 0x06000B13 RID: 2835 RVA: 0x000EF1CC File Offset: 0x000ED3CC
	private Vector2 getTileMapSpritePosbyStartID(Vector2 in_TileBaseID)
	{
		int num = this.StartID & (int)this.TileMapInfoWidthMaxSubtractOne;
		int num2 = this.StartID >> (int)this.TileMapInfoWidthMaxOffSet;
		num2 += (int)in_TileBaseID.y;
		num2 &= (int)this.TileMapInfoHeightMaxSubtractOne;
		num += (int)in_TileBaseID.x;
		num &= (int)this.TileMapInfoWidthMaxSubtractOne;
		Vector2 result = new Vector2((float)num, (float)num2);
		return result;
	}

	// Token: 0x06000B14 RID: 2836 RVA: 0x000EF22C File Offset: 0x000ED42C
	private Vector2 getTileMapSpritePosbyBoundID(Vector2 in_TileBaseID)
	{
		int num = this.BoundStartX;
		int num2 = this.BoundStartY;
		num2 += (int)in_TileBaseID.y;
		if (num2 < 0)
		{
			num2 = 0;
		}
		else if (num2 > (int)this.TileMapInfoHeightMaxSubtractOne)
		{
			num2 = (int)this.TileMapInfoHeightMaxSubtractOne;
		}
		num += (int)in_TileBaseID.x;
		if (num < 0)
		{
			num = 0;
		}
		else if (num > (int)this.TileMapInfoWidthMaxSubtractOne)
		{
			num = (int)this.TileMapInfoWidthMaxSubtractOne;
		}
		Vector2 result = new Vector2((float)num, (float)num2);
		return result;
	}

	// Token: 0x06000B15 RID: 2837 RVA: 0x000EF2AC File Offset: 0x000ED4AC
	private int getTileMapInfoID(Vector2 in_TileBaseID, Vector2 in_StartMapInfoID)
	{
		int num = (int)in_StartMapInfoID.x;
		int num2 = (int)in_StartMapInfoID.y;
		num2 += (int)in_TileBaseID.y;
		num2 &= (int)this.TileMapInfoHeightMaxSubtractOne;
		num += (int)in_TileBaseID.x;
		num &= (int)this.TileMapInfoWidthMaxSubtractOne;
		num2 <<= (int)this.TileMapInfoWidthMaxOffSet;
		return num2 | num;
	}

	// Token: 0x06000B16 RID: 2838 RVA: 0x000EF304 File Offset: 0x000ED504
	private void MoveTileBase()
	{
		if (this.Movedelta == Vector2.zero)
		{
			return;
		}
		int num = this.StartID & (int)this.TileMapInfoWidthMaxSubtractOne;
		int num2 = this.StartID >> (int)this.TileMapInfoWidthMaxOffSet;
		Vector2 vector = this.Movedelta / DataManager.MapDataController.zoomSize;
		this.CheckLimit(num, num2, ref vector);
		if (this.line != null)
		{
			this.line.MoveLine(vector * DataManager.MapDataController.zoomSize);
		}
		if (this.weapon != null)
		{
			this.weapon.MapWeaponEffectMove(vector * DataManager.MapDataController.zoomSize);
		}
		if (this.yolk != null)
		{
			this.yolk.MoveYolk(vector);
		}
		int num3 = 0;
		int num4 = 0;
		if (this.CalculateRollingTime(vector, out num3, out num4, ref num, ref num2))
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

	// Token: 0x06000B17 RID: 2839 RVA: 0x000EF4CC File Offset: 0x000ED6CC
	private void ZoomTile()
	{
		if (Input.touchCount < 2)
		{
			this.inputState = ((Input.touchCount != 1) ? MapTile.InPutState.None : MapTile.InPutState.Drag);
			return;
		}
		Touch touch = Input.GetTouch(0);
		Touch touch2 = Input.GetTouch(1);
		Vector2 position = touch.position;
		Vector2 position2 = touch2.position;
		float num = (position - touch.deltaPosition - position2 + touch2.deltaPosition).magnitude - (position2 - position).magnitude;
		Transform parent = this.TileMapRectTransform.parent;
		num = parent.localScale.x + num * -0.005f;
		this.SetScalTile(num);
	}

	// Token: 0x06000B18 RID: 2840 RVA: 0x000EF58C File Offset: 0x000ED78C
	private void setFocusGroupDelta(out Vector2 out_delta)
	{
		out_delta = new Vector2(this.selectLineNode.movingNode.position.x, this.selectLineNode.movingNode.position.y);
		out_delta /= -this.Canvasrectran.localScale.x;
	}

	// Token: 0x06000B19 RID: 2841 RVA: 0x000EF5F4 File Offset: 0x000ED7F4
	private Vector2 screenToMap(Vector2 screenPos)
	{
		screenPos.x -= (float)Screen.width * 0.5f;
		screenPos.y -= (float)Screen.height * 0.5f;
		screenPos *= this.TileMapRectTransform.sizeDelta.y / ((float)Screen.height * DataManager.MapDataController.zoomSize);
		return screenPos;
	}

	// Token: 0x06000B1A RID: 2842 RVA: 0x000EF664 File Offset: 0x000ED864
	private void updateBaseCenter()
	{
		this.BaseCenterID = this.PosToTileBaseID(new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f));
	}

	// Token: 0x06000B1B RID: 2843 RVA: 0x000EF690 File Offset: 0x000ED890
	private void ClosePointInfo()
	{
		DataManager.MapDataController.isMarkGroundInfo = 0;
		DataManager.msgBuffer[0] = 65;
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06000B1C RID: 2844 RVA: 0x000EF6C0 File Offset: 0x000ED8C0
	private void FocusMapWeapon()
	{
		this.focusMapWeaponTime -= this.tileDeltaTime;
		if (this.focusMapWeaponTime < 0f)
		{
			this.focusMapWeaponTime = 0f;
			DataManager.MapDataController.SendUseMapWeapon();
		}
	}

	// Token: 0x06000B1D RID: 2845 RVA: 0x000EF708 File Offset: 0x000ED908
	private void setYolkBallDownEffect(int mapid)
	{
		if (this.yolk != null)
		{
			int yolkID = this.yolk.getYolkID(mapid);
			mapid = GameConstants.TileMapPosToMapID((int)this.yolk.YOLK_POS[yolkID].x, (int)this.yolk.YOLK_POS[yolkID].y);
			int num = 0;
			int num2 = 0;
			this.MapIDtoMapTileRowCol((uint)mapid, ref num, ref num2);
			if (num < 0 || num2 < 0)
			{
				return;
			}
			Vector2 pos = this.TileRowGroupRectTransform[num].anchoredPosition + this.TileObjectRectTransform[num2][num].anchoredPosition;
			if (yolkID > 0)
			{
				this.effect.setEffect(0, num, num2, pos, 7);
			}
			else
			{
				this.effect.setEffect(0, num, num2, pos, 6);
			}
		}
	}

	// Token: 0x0400243D RID: 9277
	private const float startMovedeltaFactor = 0.25f;

	// Token: 0x0400243E RID: 9278
	private const float movelimit = 0.97f;

	// Token: 0x0400243F RID: 9279
	private const float movespeed = 49f;

	// Token: 0x04002440 RID: 9280
	private const float movemin = 0.03f;

	// Token: 0x04002441 RID: 9281
	private const int grassland = 22;

	// Token: 0x04002442 RID: 9282
	private const int lava = 35;

	// Token: 0x04002443 RID: 9283
	private const int lavaborder = 49;

	// Token: 0x04002444 RID: 9284
	private const int icefield = 69;

	// Token: 0x04002445 RID: 9285
	private const int icefieldborder = 79;

	// Token: 0x04002446 RID: 9286
	private const int rankone = 113;

	// Token: 0x04002447 RID: 9287
	private const int slow = 109;

	// Token: 0x04002448 RID: 9288
	private const int cityrankone = 145;

	// Token: 0x04002449 RID: 9289
	private const int citylevelmin = 9;

	// Token: 0x0400244A RID: 9290
	private const int citylevelmid = 17;

	// Token: 0x0400244B RID: 9291
	private const int citylevelhigh = 25;

	// Token: 0x0400244C RID: 9292
	private const int cityenemy = 151;

	// Token: 0x0400244D RID: 9293
	private const int citynpc = 152;

	// Token: 0x0400244E RID: 9294
	private const int camp = 149;

	// Token: 0x0400244F RID: 9295
	private const int resourcesspriteid = 138;

	// Token: 0x04002450 RID: 9296
	private const int yolkidmin = 98;

	// Token: 0x04002451 RID: 9297
	private const int yolkidmax = 109;

	// Token: 0x04002452 RID: 9298
	private const int OFFSET_POINTEX_ID = 10;

	// Token: 0x04002453 RID: 9299
	private const float yolkidminpemojioffset = 300f;

	// Token: 0x04002454 RID: 9300
	private const float yolkidmaxpemojioffset = 410f;

	// Token: 0x04002455 RID: 9301
	private const int MaxTickImage = 256;

	// Token: 0x04002456 RID: 9302
	public Vector2 Movedelta = Vector2.zero;

	// Token: 0x04002457 RID: 9303
	public byte[] TileMapInfo;

	// Token: 0x04002458 RID: 9304
	public UISpritesArray TileSprites;

	// Token: 0x04002459 RID: 9305
	public float TileBaseScale;

	// Token: 0x0400245A RID: 9306
	public int centerMapID = -1;

	// Token: 0x0400245B RID: 9307
	public MapTileYolk yolk;

	// Token: 0x0400245C RID: 9308
	public byte[] TileMapInfoEx;

	// Token: 0x0400245D RID: 9309
	public LineNode selectLineNode;

	// Token: 0x0400245E RID: 9310
	public int continueSelectMapID = -1;

	// Token: 0x0400245F RID: 9311
	public Vector2 kickNPCPos;

	// Token: 0x04002460 RID: 9312
	private byte bGraphicFake;

	// Token: 0x04002461 RID: 9313
	private byte homeSide;

	// Token: 0x04002462 RID: 9314
	private byte kickSide;

	// Token: 0x04002463 RID: 9315
	private byte TileHeight;

	// Token: 0x04002464 RID: 9316
	private byte TileMapInfoWidthMaxOffSet;

	// Token: 0x04002465 RID: 9317
	private byte TileMapInfoHeightMaxOffSet;

	// Token: 0x04002466 RID: 9318
	private ushort TileMapInfoWidthMax;

	// Token: 0x04002467 RID: 9319
	private ushort TileMapInfoWidthMaxSubtractOne;

	// Token: 0x04002468 RID: 9320
	private ushort TileMapInfoHeightMax;

	// Token: 0x04002469 RID: 9321
	private ushort TileMapInfoHeightMaxSubtractOne;

	// Token: 0x0400246A RID: 9322
	private ushort TileColNum;

	// Token: 0x0400246B RID: 9323
	private ushort TileColNumSubtractOne;

	// Token: 0x0400246C RID: 9324
	private ushort TileColNumOffset;

	// Token: 0x0400246D RID: 9325
	private ushort TileRowNum;

	// Token: 0x0400246E RID: 9326
	private ushort TileRowNumSubtractOne;

	// Token: 0x0400246F RID: 9327
	private ushort TileRowNumOffset;

	// Token: 0x04002470 RID: 9328
	private int TileColMapStartIDOffset;

	// Token: 0x04002471 RID: 9329
	private int TileRowMapStartIDOffset;

	// Token: 0x04002472 RID: 9330
	private int StartID;

	// Token: 0x04002473 RID: 9331
	private int BoundStartX;

	// Token: 0x04002474 RID: 9332
	private int BoundStartY;

	// Token: 0x04002475 RID: 9333
	private int worldTitleIconStartID = 46;

	// Token: 0x04002476 RID: 9334
	private int kingdomTitleIconStartID = 5;

	// Token: 0x04002477 RID: 9335
	private int nobilityTitleIconStartID = 86;

	// Token: 0x04002478 RID: 9336
	private RectTransform TileMapRectTransform;

	// Token: 0x04002479 RID: 9337
	private RectTransform[] TileRowGroupRectTransform;

	// Token: 0x0400247A RID: 9338
	private RectTransform[][] TileObjectRectTransform;

	// Token: 0x0400247B RID: 9339
	private RectTransform[][] TileBaseRectTransform;

	// Token: 0x0400247C RID: 9340
	private RectTransform[][] OverTileBaseRectTransform;

	// Token: 0x0400247D RID: 9341
	private GameObject[][] OverTileBaseGameObject;

	// Token: 0x0400247E RID: 9342
	private Image[][] TileBaseImage;

	// Token: 0x0400247F RID: 9343
	private Image[][] OverTileBaseImage;

	// Token: 0x04002480 RID: 9344
	private MapTile.InPutState inputState;

	// Token: 0x04002481 RID: 9345
	private float MovedeltaFactor = 0.25f;

	// Token: 0x04002482 RID: 9346
	private float onDragTimer;

	// Token: 0x04002483 RID: 9347
	private Vector2 OnDragPos;

	// Token: 0x04002484 RID: 9348
	private Vector2 lastOnDragPos;

	// Token: 0x04002485 RID: 9349
	private Vector2 homePos;

	// Token: 0x04002486 RID: 9350
	private Vector2 goHomeButtonOffset;

	// Token: 0x04002487 RID: 9351
	private Vector2 BaseCenterID = -Vector2.one;

	// Token: 0x04002488 RID: 9352
	private Vector2 centerID = -Vector2.one;

	// Token: 0x04002489 RID: 9353
	private ushort[] TzoneID = new ushort[4];

	// Token: 0x0400248A RID: 9354
	private MapTileLevel level;

	// Token: 0x0400248B RID: 9355
	private MapTileBloodName bloodname;

	// Token: 0x0400248C RID: 9356
	private MapTileGraphic graphic;

	// Token: 0x0400248D RID: 9357
	private MapTileEffect effect;

	// Token: 0x0400248E RID: 9358
	private FlowLineFactory line;

	// Token: 0x0400248F RID: 9359
	private MapTileNPC npc;

	// Token: 0x04002490 RID: 9360
	private MapTileModel weapon;

	// Token: 0x04002491 RID: 9361
	private Color deepblue = new Color(0.0784313f, 0.764706f, 1f);

	// Token: 0x04002492 RID: 9362
	private Color lightblue = new Color(0f, 1f, 1f);

	// Token: 0x04002493 RID: 9363
	private Color lightyellow = new Color(1f, 0.6862745f, 0f);

	// Token: 0x04002494 RID: 9364
	private Color lightred = new Color(1f, 0.5647059f, 0.5176471f);

	// Token: 0x04002495 RID: 9365
	private Color npcnamecolor = new Color(1f, 0.9607843f, 0.419607848f);

	// Token: 0x04002496 RID: 9366
	private Color yolknamecolor = new Color(1f, 0.5647059f, 0.5176471f);

	// Token: 0x04002497 RID: 9367
	private Color32 color_1 = new Color32(73, 121, 188, byte.MaxValue);

	// Token: 0x04002498 RID: 9368
	private Color32 color_2 = new Color32(121, 149, 199, byte.MaxValue);

	// Token: 0x04002499 RID: 9369
	private Vector2 inpos = new Vector2(-222f, -241.5f);

	// Token: 0x0400249A RID: 9370
	private Vector2 outpos = new Vector2(-95f, -104f);

	// Token: 0x0400249B RID: 9371
	private float selectLineMoveX;

	// Token: 0x0400249C RID: 9372
	private float selectLineMoveY;

	// Token: 0x0400249D RID: 9373
	private RectTransform Canvasrectran;

	// Token: 0x0400249E RID: 9374
	private Transform RealmGroup_3DTransform;

	// Token: 0x0400249F RID: 9375
	private CString tmepStr;

	// Token: 0x040024A0 RID: 9376
	private bool bFront;

	// Token: 0x040024A1 RID: 9377
	private float focusMapWeaponTime;

	// Token: 0x040024A2 RID: 9378
	private int TargetPosx = -1;

	// Token: 0x040024A3 RID: 9379
	private int TargetPosy = -1;

	// Token: 0x040024A4 RID: 9380
	private float TargetScal;

	// Token: 0x040024A5 RID: 9381
	private float tileDeltaTime;

	// Token: 0x040024A6 RID: 9382
	private float moveTargetXSpeed = 1f;

	// Token: 0x040024A7 RID: 9383
	private float moveTargetYSpeed = 1f;

	// Token: 0x040024A8 RID: 9384
	private float scalTargetSpeed = 1f;

	// Token: 0x040024A9 RID: 9385
	private float targetTime = 0.5f;

	// Token: 0x040024AA RID: 9386
	public byte frontIsSheep = 3;

	// Token: 0x040024AB RID: 9387
	private Image[] tickImage;

	// Token: 0x040024AC RID: 9388
	private byte[] tickImageIDToColRow;

	// Token: 0x040024AD RID: 9389
	private ushort[][] tickColRowToImageID;

	// Token: 0x040024AE RID: 9390
	private ushort frontTickImageNum;

	// Token: 0x040024AF RID: 9391
	private ushort backTickImageNum;

	// Token: 0x040024B0 RID: 9392
	private Color sheepTickYolkImageColor = new Color32(byte.MaxValue, 88, 88, byte.MaxValue);

	// Token: 0x040024B1 RID: 9393
	private Color wolfTickYolkImageColor = new Color32(195, 124, byte.MaxValue, byte.MaxValue);

	// Token: 0x0200025C RID: 604
	private enum InPutState : byte
	{
		// Token: 0x040024B3 RID: 9395
		None,
		// Token: 0x040024B4 RID: 9396
		Click,
		// Token: 0x040024B5 RID: 9397
		Drag,
		// Token: 0x040024B6 RID: 9398
		Zoom,
		// Token: 0x040024B7 RID: 9399
		Group,
		// Token: 0x040024B8 RID: 9400
		Weapon,
		// Token: 0x040024B9 RID: 9401
		Move,
		// Token: 0x040024BA RID: 9402
		Count
	}
}
