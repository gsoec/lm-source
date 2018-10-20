using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000255 RID: 597
public class FlowLineFactory
{
	// Token: 0x06000A5C RID: 2652 RVA: 0x000DEC74 File Offset: 0x000DCE74
	public FlowLineFactory(Transform realmGroup, MapTileBloodName Name, float tileBaseScale)
	{
		this.CanvasRectTranScale = DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
		this.m_Parent = new GameObject("FlowLineList");
		if (realmGroup != null)
		{
			this.m_Parent.transform.SetParent(realmGroup);
			this.m_Parent.transform.localPosition = Vector3.forward * 47f;
			this.m_ParentScaleBase = 1f;
		}
		this.ScaleRate = tileBaseScale;
		SheetAnimationUnitGroup.InitResource();
		this.mapNameController = Name;
	}

	// Token: 0x17000075 RID: 117
	// (get) Token: 0x06000A5E RID: 2654 RVA: 0x000DEF10 File Offset: 0x000DD110
	// (set) Token: 0x06000A5F RID: 2655 RVA: 0x000DEF18 File Offset: 0x000DD118
	public float ScaleRate
	{
		get
		{
			return this.m_ScaleRate;
		}
		set
		{
			this.m_ScaleRate = value;
			float num = this.m_ParentScaleBase * this.m_ScaleRate;
			this.m_Parent.transform.localScale = new Vector3(num, num, num);
		}
	}

	// Token: 0x06000A60 RID: 2656 RVA: 0x000DEF54 File Offset: 0x000DD154
	private void fillLineNode(LineNode node)
	{
		if (node == null)
		{
			return;
		}
		Color white = Color.white;
		this.m_Color[2] = white;
		this.m_Color[3] = white;
		this.m_Color[4] = white;
		this.m_Color[5] = white;
		node.meshFilter.mesh.colors = this.m_Color;
		node.meshFilter.mesh.triangles = this.m_Triangle;
		node.bFocus = 1;
	}

	// Token: 0x06000A61 RID: 2657 RVA: 0x000DEFEC File Offset: 0x000DD1EC
	public void easeLineNode(LineNode _lineNode)
	{
		if (_lineNode == null)
		{
			return;
		}
		if (_lineNode.colorIndex == 1 && this.CheckLineEaseDistance(_lineNode))
		{
			Color white = Color.white;
			white.a = 0f;
			this.m_Color[2] = white;
			this.m_Color[3] = white;
			this.m_Color[4] = white;
			this.m_Color[5] = white;
			_lineNode.meshFilter.mesh.colors = this.m_Color;
			_lineNode.meshFilter.mesh.triangles = this.m_EaseTriangle;
		}
		_lineNode.bFocus = 0;
	}

	// Token: 0x06000A62 RID: 2658 RVA: 0x000DF0A8 File Offset: 0x000DD2A8
	public bool CheckRalyNodeAlive(int lineTableID)
	{
		int count = this.RallyLineData.Count;
		ulong serverTime = (ulong)DataManager.Instance.ServerTime;
		for (int i = count - 1; i >= 0; i--)
		{
			if (this.RallyLineData[i].BeginTime - serverTime > 10UL)
			{
				this.RallyLineData.RemoveAt(i);
			}
		}
		MapLine mapLine = DataManager.MapDataController.MapLineTable[lineTableID];
		RallyNode rallyNode = default(RallyNode);
		rallyNode.BeginTime = mapLine.begin;
		rallyNode.Point.pointID = mapLine.start.pointID;
		rallyNode.Point.zoneID = mapLine.start.zoneID;
		for (int j = 0; j < this.RallyLineData.Count; j++)
		{
			if (rallyNode == this.RallyLineData[j])
			{
				return true;
			}
		}
		this.RallyLineData.Add(rallyNode);
		return false;
	}

	// Token: 0x06000A63 RID: 2659 RVA: 0x000DF1A8 File Offset: 0x000DD3A8
	private bool IsRetreat(byte lineFlag)
	{
		return lineFlag == 23 || lineFlag == 24 || lineFlag == 25 || lineFlag == 26 || lineFlag == 27 || lineFlag == 30;
	}

	// Token: 0x06000A64 RID: 2660 RVA: 0x000DF1E0 File Offset: 0x000DD3E0
	public LineNode createLine(int lineTableID, Vector3 from, Vector3 to, ELineColor color, EUnitSide unitSide, bool bEase = true, bool NeedRenderLine = true, EMonsterFace MonsterFace = EMonsterFace.LEFT, byte ExtraFlag = 0)
	{
		uint num = DataManager.MapDataController.MapLineTable[lineTableID].during;
		long begin = (long)DataManager.MapDataController.MapLineTable[lineTableID].begin;
		if (num <= 0u)
		{
			return null;
		}
		double num2 = (double)(begin + (long)((ulong)num)) - NetworkManager.ServerTime;
		if (num2 <= 0.0)
		{
			return null;
		}
		bool flag = GameConstants.IsPetSkillLine(lineTableID);
		bool flag2 = GameConstants.IsSoccerRunningLine(lineTableID);
		bool flag3 = false;
		if (num == 5u && DataManager.MapDataController.MapLineTable[lineTableID].EXduring == 5u)
		{
			flag3 = true;
			byte lineFlag = DataManager.MapDataController.MapLineTable[lineTableID].lineFlag;
			if (lineFlag == 12 || lineFlag == 26)
			{
				DataManager.MapDataController.MapLineTable[lineTableID].lineFlag = 26;
			}
			else
			{
				DataManager.MapDataController.MapLineTable[lineTableID].lineFlag = 23;
			}
		}
		byte side = (byte)unitSide;
		from = this.m_Parent.transform.InverseTransformPoint(from);
		from.z = 0f;
		to = this.m_Parent.transform.InverseTransformPoint(to);
		to.z = 0f;
		long num3 = DataManager.Instance.ServerTime - begin;
		num3 = Math.Max(num3, 0L);
		num3 = Math.Min(num3, (long)((ulong)num));
		float num4 = (float)num3;
		float num5 = Vector3.Distance(from, to);
		if (num5 <= 0.001f)
		{
			num5 = 0.001f;
		}
		float num6 = num5 / num * 2f;
		EMarchEventType lineFlag2 = EMarchEventType.EMET_Camp;
		byte b = DataManager.MapDataController.MapLineTable[lineTableID].lineFlag;
		bool flag4 = this.IsYolkDefenseFail(lineTableID);
		if (!flag && (this.IsRetreat(b) || flag4))
		{
			if (num4 >= 5f)
			{
				lineFlag2 = (EMarchEventType)b;
				b = (byte)this.RetreatToReturn((EMarchEventType)b);
			}
			else if (b == 24 || b == 25)
			{
				side = 1;
				int num7 = GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[lineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[lineTableID].start.pointID);
				int tableID = (int)DataManager.MapDataController.LayoutMapInfo[num7].tableID;
				if (b == 24 && DataManager.MapDataController.IsCityOrCamp((uint)num7))
				{
					if (DataManager.CompareStr(DataManager.MapDataController.PlayerPointTable[tableID].playerName, DataManager.Instance.RoleAttr.Name) == 0 || DataManager.Instance.IsSameAlliance(DataManager.MapDataController.PlayerPointTable[tableID].allianceTag))
					{
						side = 0;
					}
				}
				else if (b == 25 && DataManager.MapDataController.IsResources((uint)num7) && (DataManager.CompareStr(DataManager.MapDataController.ResourcesPointTable[tableID].playerName, DataManager.Instance.RoleAttr.Name) == 0 || DataManager.Instance.IsSameAlliance(DataManager.MapDataController.ResourcesPointTable[tableID].allianceTag)))
				{
					side = 0;
				}
			}
		}
		LineNode lineNode = this.GetLineNode(num5, bEase, (byte)color);
		GameObject gameObject = lineNode.gameObject;
		float num8 = num4;
		if (flag)
		{
			num -= 1u;
			num8 -= 1f;
			num8 = ((num8 >= 0f) ? num8 : 0f);
		}
		else if (b == 30 || flag2)
		{
			num -= DataManager.MapDataController.MapLineTable[lineTableID].EXduring;
			num8 -= DataManager.MapDataController.MapLineTable[lineTableID].EXduring;
			num8 = ((num8 >= 0f) ? num8 : 0f);
		}
		else if (this.IsRetreat(b) || this.IsRetreat((byte)lineFlag2) || flag4)
		{
			num -= 5u;
			num8 -= 5f;
			num8 = ((num8 >= 0f) ? num8 : 0f);
		}
		lineNode.lineTableID = lineTableID;
		lineNode.timeOffset = num8;
		lineNode.inverseMaxTime = ((num <= 0u) ? 0f : (1f / num));
		lineNode.inverseTransferTime = 0f;
		float x = num5 * (lineNode.timeOffset * lineNode.inverseMaxTime) - num5 * 0.5f;
		lineNode.movingNode.localPosition = new Vector3(x, 0f, 0f);
		lineNode.speedRate = num6 / 1.75f;
		lineNode.unitSpeedRate = 1f;
		lineNode.AutoDelete = 0;
		lineNode.IsPetSkillLine = flag;
		lineNode.IsSoccerRunningLine = flag2;
		lineNode.FriendLineID = 1048576;
		lineNode.StartPoint = DataManager.MapDataController.MapLineTable[lineTableID].start;
		lineNode.EndPoint = DataManager.MapDataController.MapLineTable[lineTableID].end;
		lineNode.flag = b;
		lineNode.RuntimeFlag = 0;
		lineNode.FakeLineDir = 0;
		lineNode.actionStartTime = null;
		lineNode.touchDownDistance = 0f;
		if ((ExtraFlag & 1) != 0)
		{
			FlowLineFactory.SetRuntimeFlag(lineNode, ELineNodeRuntimeFlag.PowerSoccer);
		}
		float angle = this.SetupLineSlope(lineNode, from, to);
		lineNode.angle = angle;
		this.FriendLineLink(lineNode, lineTableID);
		this.recalculateSpeed(lineNode, lineTableID, true);
		if (lineNode != null && lineNode.movingNode != null)
		{
			this.AwakeSheetUnit(lineNode);
			byte b2 = 0;
			byte b3 = 0;
			if (!flag && b == 27 && MonsterFace == EMonsterFace.RIGHT)
			{
				b3 |= 1;
			}
			if (flag || ((b != 26 || !this.CheckRalyNodeAlive(lineTableID)) && !flag4))
			{
				if (!flag && b == 26)
				{
					Debug.Log(this.LastRallyName.ToString());
					b2 = 1;
				}
				b3 |= ((!flag) ? 0 : 2);
				b3 |= ((!flag2) ? 0 : 4);
				b3 |= (((ExtraFlag & 1) == 0) ? 0 : 16);
				lineNode.sheetUnit.setupAnimUnit(side, b, angle, b3);
			}
			else
			{
				b2 = 2;
			}
			lineNode.side = side;
			lineNode.MonsterFace = MonsterFace;
			lineNode.action = ELineAction.NORMAL;
			lineNode.ShakingTimer = null;
			lineNode.ShakingFlag = 0;
			lineNode.renderer.enabled = true;
			if (flag)
			{
				float num9 = 1f - num4;
				if (num9 >= 0f)
				{
					lineNode.renderer.enabled = false;
					lineNode.action = ELineAction.ACTION_BEFORE;
					lineNode.timer = num9;
					lineNode.sheetUnit.RecoverUnit();
					b2 = 2;
				}
				else
				{
					lineNode.timer = -11f;
				}
			}
			else if (b == 30)
			{
				float timer = 2f - num4;
				lineNode.renderer.enabled = false;
				lineNode.action = ELineAction.ACTION_BEFORE;
				lineNode.timer = timer;
			}
			else if (flag2)
			{
				float timer2 = DataManager.MapDataController.MapLineTable[lineTableID].EXduring - num4;
				lineNode.renderer.enabled = false;
				lineNode.action = ELineAction.ACTION_BEFORE_WITHOUT_LINE;
				lineNode.timer = timer2;
				lineNode.sheetUnit.RecoverUnit();
			}
			else if (this.IsRetreat(b) || flag4)
			{
				float timer3 = 5f - num4;
				lineNode.renderer.enabled = false;
				lineNode.action = ELineAction.ACTION_BEFORE;
				lineNode.timer = timer3;
			}
			float num10 = this.CanvasRectTranScale * DataManager.MapDataController.zoomSize;
			MapLine mapLine = DataManager.MapDataController.MapLineTable[lineTableID];
			if (!flag && (b == 24 || b == 25) && DataManager.MapDataController.ZoneUpdateInfo[(int)(mapLine.start.zoneID & 1023)].zoneState < 8)
			{
				int num11 = GameConstants.PointCodeToMapID(mapLine.start.zoneID, mapLine.start.pointID);
				int tableID2 = (int)DataManager.MapDataController.LayoutMapInfo[num11].tableID;
				ELineColor elineColor = color;
				if (color == ELineColor.DEEPBLUE)
				{
					elineColor = ELineColor.RED;
				}
				else if (color == ELineColor.BLUE)
				{
					elineColor = ELineColor.ORANGE;
				}
				if (DataManager.MapDataController.IsResources((uint)num11))
				{
					if (color == ELineColor.RED || color == ELineColor.ORANGE)
					{
						if (DataManager.CompareStr(DataManager.MapDataController.ResourcesPointTable[tableID2].playerName, DataManager.Instance.RoleAttr.Name) == 0)
						{
							elineColor = ELineColor.DEEPBLUE;
						}
						else if (DataManager.Instance.IsSameAlliance(DataManager.MapDataController.ResourcesPointTable[tableID2].allianceTag))
						{
							elineColor = ELineColor.BLUE;
						}
					}
					if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && DataManager.MapDataController.IsEnemy(DataManager.MapDataController.ResourcesPointTable[tableID2].kingdomID))
					{
						lineNode.NodeName = this.mapNameController.pullLineName(DataManager.MapDataController.ResourcesPointTable[tableID2].playerName, DataManager.MapDataController.ResourcesPointTable[tableID2].allianceTag, elineColor, new Vector2((float)((int)(lineNode.movingNode.position.x / num10)), (float)((int)(lineNode.movingNode.position.y / num10)) + 64f), DataManager.MapDataController.ResourcesPointTable[tableID2].kingdomID);
					}
					else
					{
						lineNode.NodeName = this.mapNameController.pullLineName(DataManager.MapDataController.ResourcesPointTable[tableID2].playerName, DataManager.MapDataController.ResourcesPointTable[tableID2].allianceTag, elineColor, new Vector2((float)((int)(lineNode.movingNode.position.x / num10)), (float)((int)(lineNode.movingNode.position.y / num10)) + 64f), 0);
					}
				}
				else
				{
					if (color == ELineColor.RED || color == ELineColor.ORANGE)
					{
						if (DataManager.CompareStr(DataManager.MapDataController.PlayerPointTable[tableID2].playerName, DataManager.Instance.RoleAttr.Name) == 0)
						{
							elineColor = ELineColor.DEEPBLUE;
						}
						else if (DataManager.Instance.IsSameAlliance(DataManager.MapDataController.PlayerPointTable[tableID2].allianceTag))
						{
							elineColor = ELineColor.BLUE;
						}
					}
					if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && DataManager.MapDataController.IsEnemy(DataManager.MapDataController.PlayerPointTable[tableID2].kingdomID))
					{
						lineNode.NodeName = this.mapNameController.pullLineName(DataManager.MapDataController.PlayerPointTable[tableID2].playerName, DataManager.MapDataController.PlayerPointTable[tableID2].allianceTag, elineColor, new Vector2((float)((int)(lineNode.movingNode.position.x / num10)), (float)((int)(lineNode.movingNode.position.y / num10)) + 64f), DataManager.MapDataController.PlayerPointTable[tableID2].kingdomID);
					}
					else
					{
						lineNode.NodeName = this.mapNameController.pullLineName(DataManager.MapDataController.PlayerPointTable[tableID2].playerName, DataManager.MapDataController.PlayerPointTable[tableID2].allianceTag, elineColor, new Vector2((float)((int)(lineNode.movingNode.position.x / num10)), (float)((int)(lineNode.movingNode.position.y / num10)) + 64f), 0);
					}
				}
				if (b2 == 1)
				{
					if (elineColor == ELineColor.DEEPBLUE && DataManager.CompareStr(this.LastRallyName, DataManager.Instance.RoleAttr.Name) != 0)
					{
						lineNode.NodeName.updateName(this.LastRallyName, DataManager.MapDataController.PlayerPointTable[tableID2].allianceTag, ELineColor.BLUE);
					}
					else if (elineColor == ELineColor.BLUE && DataManager.CompareStr(this.LastRallyName, DataManager.Instance.RoleAttr.Name) == 0)
					{
						lineNode.NodeName.updateName(this.LastRallyName, DataManager.MapDataController.PlayerPointTable[tableID2].allianceTag, ELineColor.DEEPBLUE);
					}
					else
					{
						lineNode.NodeName.updateName(this.LastRallyName, DataManager.MapDataController.PlayerPointTable[tableID2].allianceTag, 0, null);
					}
				}
				else if (b2 == 2)
				{
					lineNode.NodeName.SetActive(false);
				}
			}
			else
			{
				if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && DataManager.MapDataController.IsEnemy(mapLine.kingdomID))
				{
					lineNode.NodeName = this.mapNameController.pullLineName(mapLine.playerName, mapLine.allianceTag, color, new Vector2((float)((int)(lineNode.movingNode.position.x / num10)), (float)((int)(lineNode.movingNode.position.y / num10)) + 64f), mapLine.kingdomID);
				}
				else
				{
					lineNode.NodeName = this.mapNameController.pullLineName(mapLine.playerName, mapLine.allianceTag, color, new Vector2((float)((int)(lineNode.movingNode.position.x / num10)), (float)((int)(lineNode.movingNode.position.y / num10)) + 64f), 0);
				}
				if (b2 == 1)
				{
					if (color == ELineColor.DEEPBLUE && DataManager.CompareStr(this.LastRallyName, DataManager.Instance.RoleAttr.Name) != 0)
					{
						lineNode.NodeName.updateName(this.LastRallyName, mapLine.allianceTag, ELineColor.BLUE);
					}
					else if (color == ELineColor.BLUE && DataManager.CompareStr(this.LastRallyName, DataManager.Instance.RoleAttr.Name) == 0)
					{
						lineNode.NodeName.updateName(this.LastRallyName, mapLine.allianceTag, ELineColor.DEEPBLUE);
					}
					else
					{
						lineNode.NodeName.updateName(this.LastRallyName, mapLine.allianceTag, 0, null);
					}
				}
				else if (b2 == 2)
				{
					lineNode.NodeName.SetActive(false);
				}
			}
		}
		if ((DataManager.MapDataController.MapLineTable[lineTableID].baseFlag & 1) != 0)
		{
			EmojiData recordByKey = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(DataManager.MapDataController.MapLineTable[lineTableID].emojiID);
			if (recordByKey.EmojiKey == DataManager.MapDataController.MapLineTable[lineTableID].emojiID)
			{
				float num12 = (float)((recordByKey.sizeX <= recordByKey.sizeY) ? recordByKey.sizeY : recordByKey.sizeX);
				if (num12 == 0f)
				{
					num12 = ((GUIManager.Instance.EmojiManager != null) ? GUIManager.Instance.EmojiManager.basebacksize : 73f);
				}
				else
				{
					num12 *= 0.9f;
					num12 += ((GUIManager.Instance.EmojiManager != null) ? GUIManager.Instance.EmojiManager.basebackoffset : 25f);
				}
				num12 /= ((GUIManager.Instance.EmojiManager != null) ? GUIManager.Instance.EmojiManager.basebacksize : 73f);
				SheetAnimationUnitGroup sheetAnimationUnitGroup;
				if (lineNode.NodeName.mapEmojiBack == null)
				{
					lineNode.NodeName.mapEmojiBack = GUIManager.Instance.pullEmojiIcon(ushort.MaxValue, 0, true);
					sheetAnimationUnitGroup = (lineNode.sheetUnit as SheetAnimationUnitGroup);
					lineNode.NodeName.mapEmojiBack.EmojiTransform.SetParent(sheetAnimationUnitGroup.transform, false);
				}
				lineNode.NodeName.mapEmojiBack.EmojiTransform.localPosition = GameConstants.lineeomjiback;
				lineNode.NodeName.mapEmojiBack.EmojiTransform.localScale = Vector3.one * num12;
				if (lineNode.NodeName.mapEmoji != null)
				{
					GUIManager.Instance.pushEmojiIcon(lineNode.NodeName.mapEmoji);
					lineNode.NodeName.mapEmoji = null;
				}
				lineNode.NodeName.mapEmoji = GUIManager.Instance.pullEmojiIcon(recordByKey.IconID, recordByKey.KeyFrame, true);
				lineNode.NodeName.mapEmoji.EmojiTransform.localPosition = GameConstants.lineeomji;
				lineNode.NodeName.mapEmoji.EmojiTransform.localScale = Vector3.one * 0.9f;
				sheetAnimationUnitGroup = (lineNode.sheetUnit as SheetAnimationUnitGroup);
				lineNode.NodeName.mapEmoji.EmojiTransform.SetParent(sheetAnimationUnitGroup.transform, false);
			}
		}
		else if (lineNode.NodeName.mapEmoji != null)
		{
			GUIManager.Instance.pushEmojiIcon(lineNode.NodeName.mapEmoji);
			lineNode.NodeName.mapEmoji = null;
			if (lineNode.NodeName.mapEmojiBack != null)
			{
				GUIManager.Instance.pushEmojiIcon(lineNode.NodeName.mapEmojiBack);
				lineNode.NodeName.mapEmojiBack = null;
			}
		}
		if (lineNode != null && !NeedRenderLine)
		{
			if (lineNode.action == ELineAction.ACTION_BEFORE)
			{
				lineNode.action = ELineAction.ACTION_BEFORE_WITHOUT_LINE;
			}
			lineNode.renderer.enabled = false;
		}
		if (lineNode != null && flag3)
		{
			lineNode.AutoDelete = 1;
		}
		if (lineNode != null && lineNode.sheetUnit != null && lineNode.flag == 30 && lineNode.action != ELineAction.NORMAL)
		{
			float animTime = 2f - lineNode.timer;
			lineNode.sheetUnit.SampleAnimation(0, animTime);
		}
		return lineNode;
	}

	// Token: 0x06000A65 RID: 2661 RVA: 0x000E0458 File Offset: 0x000DE658
	private LineNode GetLineNode(float dist, bool bEase, byte colorIndex)
	{
		LineNode lineNode = this.GetFreeLine();
		if (lineNode != null)
		{
			this.InsertWorkingList(lineNode);
			GameObject gameObject = lineNode.gameObject;
			gameObject.SetActive(true);
			this.setupLineNode(lineNode, dist, bEase, colorIndex);
		}
		else
		{
			if (this.m_Bundle == null)
			{
				this.m_Bundle = AssetManager.GetAssetBundle("Role/FlowLinePrefab", 0L);
			}
			GameObject gameObject2 = UnityEngine.Object.Instantiate(this.m_Bundle.mainAsset) as GameObject;
			gameObject2.transform.parent = this.m_Parent.transform;
			MeshFilter component = gameObject2.GetComponent<MeshFilter>();
			Mesh mesh = new Mesh();
			MeshRenderer component2 = gameObject2.GetComponent<MeshRenderer>();
			component2.sharedMaterial.renderQueue = 2650;
			component.mesh = mesh;
			lineNode = new LineNode();
			lineNode.gameObject = gameObject2;
			lineNode.lineTransform = gameObject2.transform;
			GameObject gameObject3 = new GameObject("movingNode");
			gameObject3.transform.parent = gameObject2.transform;
			gameObject3.transform.Rotate(0f, 90f, 0f);
			lineNode.movingNode = gameObject3.transform;
			lineNode.meshFilter = component;
			lineNode.renderer = component2;
			this.setupLineNode(lineNode, dist, bEase, colorIndex);
			this.m_LineList.Insert(gameObject2.GetHashCode(), lineNode);
			this.InsertWorkingList(lineNode);
		}
		return lineNode;
	}

	// Token: 0x06000A66 RID: 2662 RVA: 0x000E05A8 File Offset: 0x000DE7A8
	private float SetupLineSlope(LineNode node, Vector3 from, Vector3 to)
	{
		if (node == null)
		{
			return 0f;
		}
		GameObject gameObject = node.gameObject;
		if (gameObject == null)
		{
			return 0f;
		}
		Vector3 from2 = to - from;
		float num = Vector3.Angle(from2, Vector3.right);
		if (from2.y < 0f)
		{
			num = 360f - num;
		}
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localPosition = from + (to - from) * 0.5f;
		gameObject.transform.rotation = Quaternion.AngleAxis(num, Vector3.forward);
		gameObject.transform.localScale = Vector3.one;
		return num;
	}

	// Token: 0x06000A67 RID: 2663 RVA: 0x000E0660 File Offset: 0x000DE860
	private void AwakeSheetUnit(LineNode node)
	{
		if (node == null)
		{
			return;
		}
		if (node.sheetUnit == null)
		{
			node.sheetUnit = new SheetAnimationUnitGroup();
		}
		SheetAnimationUnitGroup sheetAnimationUnitGroup = node.sheetUnit as SheetAnimationUnitGroup;
		sheetAnimationUnitGroup.transform.parent = null;
		sheetAnimationUnitGroup.transform.rotation = Quaternion.identity;
		sheetAnimationUnitGroup.transform.parent = node.movingNode;
		sheetAnimationUnitGroup.transform.localPosition = Vector3.zero;
		sheetAnimationUnitGroup.transform.localScale = Vector3.one;
		sheetAnimationUnitGroup.resetScale();
	}

	// Token: 0x06000A68 RID: 2664 RVA: 0x000E06EC File Offset: 0x000DE8EC
	public int HashableInt(int lineTableID)
	{
		return GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[lineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[lineTableID].start.pointID);
	}

	// Token: 0x06000A69 RID: 2665 RVA: 0x000E0734 File Offset: 0x000DE934
	private void FriendLineLink(LineNode node, int lineTableID)
	{
		if (node.flag == 30 || GameConstants.IsSoccerRunningLine(node.lineTableID))
		{
			int key = this.HashableInt(lineTableID);
			int num = 1048576;
			bool flag = this.FriendLineCache.TryGetValue(key, out num);
			if (node.FriendLineID == 1048576)
			{
				if (!flag)
				{
					this.FriendLineCache[key] = node.lineTableID;
					Debug.LogWarning("Line Caching: " + node.lineTableID.ToString());
				}
				else if (num != 1048576)
				{
					MapLine mapLine = DataManager.MapDataController.MapLineTable[num];
					LineNode nodeByGameObject = this.GetNodeByGameObject(mapLine.lineObject, false);
					nodeByGameObject.FriendLineID = node.lineTableID;
					node.FriendLineID = nodeByGameObject.lineTableID;
					Debug.LogWarning("Line Linking: " + node.FriendLineID.ToString() + " and " + nodeByGameObject.FriendLineID.ToString());
					LineNode lineNode = (!GameConstants.IsSoccerRunningLine(node.lineTableID)) ? node : nodeByGameObject;
					LineNode lineNode2 = (!GameConstants.IsSoccerRunningLine(node.lineTableID)) ? nodeByGameObject : node;
					float num2 = lineNode2.angle;
					MapLine mapLine2 = DataManager.MapDataController.MapLineTable[lineNode2.lineTableID];
					if ((mapLine2.lineFlag & 56) == 56 && mapLine2.start.zoneID == mapLine2.end.zoneID && mapLine2.start.pointID == mapLine2.end.pointID)
					{
						lineNode.FriendLineID = 1048576;
						byte b = mapLine2.lineFlag & 7;
						FlowLineFactory.SetRuntimeFlag(lineNode, ELineNodeRuntimeFlag.SpawnSoccerFakeLine);
						lineNode.FakeLineDir = b;
						Vector3 from = this.DirToVector(b);
						from.Normalize();
						num2 = Vector3.Angle(from, Vector3.right);
						if (from.y < 0f)
						{
							num2 = 360f - num2;
						}
					}
					if (lineNode.action != ELineAction.NORMAL)
					{
						byte setupFlag = (!FlowLineFactory.HasRuntimeFlag(lineNode, ELineNodeRuntimeFlag.PowerSoccer)) ? 0 : 16;
						lineNode.sheetUnit.RecoverUnit();
						lineNode.sheetUnit.setupAnimUnit(lineNode.side, lineNode.flag, num2, setupFlag);
						Debug.LogWarning("ball angle : " + num2.ToString());
					}
				}
			}
		}
	}

	// Token: 0x06000A6A RID: 2666 RVA: 0x000E099C File Offset: 0x000DEB9C
	private void setupLineNode(LineNode node, float dist, bool bEase, byte colorIndex)
	{
		Mesh mesh = node.meshFilter.mesh;
		float num = 0.2f;
		float num2 = dist * 0.5f;
		float num3 = 5f;
		if (10f > dist)
		{
			num3 = 0f;
			bEase = false;
		}
		this.m_Vertices[0] = new Vector3(-num2, -num, 0f);
		this.m_Vertices[1] = new Vector3(-num2, num, 0f);
		this.m_Vertices[2] = new Vector3(-num2 + num3, -num, 0f);
		this.m_Vertices[3] = new Vector3(-num2 + num3, num, 0f);
		this.m_Vertices[4] = new Vector3(num2 - num3, -num, 0f);
		this.m_Vertices[5] = new Vector3(num2 - num3, num, 0f);
		this.m_Vertices[6] = new Vector3(num2, -num, 0f);
		this.m_Vertices[7] = new Vector3(num2, num, 0f);
		float num4 = dist / 0.4f * 0.25f;
		float num5 = num3 / dist * num4;
		float num6 = (dist - num3) / dist * num4;
		float y = (float)colorIndex * 0.25f;
		float y2 = (float)(colorIndex + 1) * 0.25f;
		this.m_Uv[0] = new Vector2(0f, y);
		this.m_Uv[1] = new Vector2(0f, y2);
		this.m_Uv[2] = new Vector2(num5, y);
		this.m_Uv[3] = new Vector2(num5, y2);
		this.m_Uv[4] = new Vector2(num6, y);
		this.m_Uv[5] = new Vector2(num6, y2);
		this.m_Uv[6] = new Vector2(num4, y);
		this.m_Uv[7] = new Vector2(num4, y2);
		Color white = Color.white;
		float a = (!bEase) ? 1f : 0f;
		white.a = 1f;
		Color color = white;
		color.a = a;
		this.m_Color[0] = white;
		this.m_Color[1] = white;
		this.m_Color[2] = color;
		this.m_Color[3] = color;
		this.m_Color[4] = color;
		this.m_Color[5] = color;
		this.m_Color[6] = white;
		this.m_Color[7] = white;
		mesh.vertices = this.m_Vertices;
		mesh.uv = this.m_Uv;
		mesh.colors = this.m_Color;
		mesh.triangles = ((!bEase) ? this.m_Triangle : this.m_EaseTriangle);
		mesh.RecalculateBounds();
		node.distance = dist;
		node.curCoordU = 0f;
		node.maxCoordU = num4;
		node.sideLen = num3;
		node.sideOffset1 = num5;
		node.sideOffset2 = num6;
		node.colorIndex = colorIndex;
	}

	// Token: 0x06000A6B RID: 2667 RVA: 0x000E0D34 File Offset: 0x000DEF34
	public bool IsPointCodeMatch(ref PointCode code1, ref PointCode code2)
	{
		return code1.zoneID == code2.zoneID && code1.pointID == code2.pointID;
	}

	// Token: 0x06000A6C RID: 2668 RVA: 0x000E0D64 File Offset: 0x000DEF64
	public void recalculateSpeed(LineNode node, int lineTableID, bool bResetOffset = false)
	{
		MapLine mapLine = DataManager.MapDataController.MapLineTable[lineTableID];
		uint exduring = mapLine.EXduring;
		ulong begin = mapLine.begin;
		uint exbegin = mapLine.EXbegin;
		uint during = mapLine.during;
		if (bResetOffset)
		{
			node.timeOffset = exbegin;
		}
		float num = (during - exbegin) / during * node.distance;
		uint num2 = during - exduring;
		float num3 = num / num2;
		node.actionStartTime = null;
		if (GameConstants.IsPetSkillLine(lineTableID) || this.IsRetreat(mapLine.lineFlag) || this.IsYolkDefenseFail(lineTableID) || GameConstants.IsSoccerRunningLine(lineTableID))
		{
			float num4 = mapLine.during;
			if (mapLine.during - FlowLineFactory.ServerTimeOffset >= 0.1f)
			{
				num4 = mapLine.during - FlowLineFactory.ServerTimeOffset;
			}
			node.inverseMaxTime = 1f / num4;
			node.actionStartTime = new double?(NetworkManager.ServerTime);
		}
		double serverTime = NetworkManager.ServerTime;
		ulong num5 = begin + (ulong)exduring;
		double num6 = serverTime - num5;
		float num7 = exbegin / during * node.distance;
		float num8 = (float)(((double)num7 + num6 * (double)num3) / (double)node.distance * during);
		double num9 = (double)(node.distance / during);
		if (node.timeOffset <= num8)
		{
			node.timeOffset = num8;
		}
		float num10 = (1f - node.timeOffset * node.inverseMaxTime) * node.distance;
		double num11 = begin + (ulong)during - serverTime;
		num11 = Math.Max(0.0, num11);
		double num12 = (double)num10 / num11 / num9;
		node.speedRate = (float)(num12 * 0.05 + num9 / 1.75);
		node.unitSpeedRate = (float)num12;
		if ((mapLine.baseFlag & 4) != 0)
		{
			CHAOS chaos = GameManager.ActiveGameplay as CHAOS;
			if (chaos != null && chaos.realmController != null)
			{
				int num13 = (int)(mapLine.emojiID & 1023);
				int num14 = (int)(mapLine.lineFlag & 192) | mapLine.emojiID >> 10;
				Vector3 b = chaos.realmController.PointCodeToWorldPosition((ushort)num13, (byte)num14);
				Vector3 a = chaos.realmController.PointCodeToWorldPosition(node.StartPoint.zoneID, node.StartPoint.pointID);
				float num15 = Vector3.Distance(a, b);
				if (num15 <= 0.001f)
				{
					num15 = 0.001f;
				}
				PointCode pointCode = default(PointCode);
				pointCode.zoneID = (ushort)num13;
				pointCode.pointID = (byte)num14;
				if (num15 < 2.5f)
				{
					node.touchDownDistance = 0f;
					node.inverseTransferTime = 0f;
				}
				else if (this.IsPointCodeMatch(ref node.EndPoint, ref pointCode) || num15 > node.distance || Mathf.Abs(num15 - node.distance) < 0.0001f)
				{
					node.touchDownDistance = node.distance;
					node.inverseTransferTime = node.inverseMaxTime;
				}
				else
				{
					node.touchDownDistance = num15;
					node.inverseTransferTime = 1f / (num15 / (node.distance * node.inverseMaxTime));
					Debug.LogWarning("Calc special touch down");
				}
			}
		}
	}

	// Token: 0x06000A6D RID: 2669 RVA: 0x000E10AC File Offset: 0x000DF2AC
	public bool IsYolkDefenseFail(int lineTableID)
	{
		if (GameConstants.IsPetSkillLine(lineTableID) || GameConstants.IsSoccerRunningLine(lineTableID))
		{
			return false;
		}
		MapLine mapLine = DataManager.MapDataController.MapLineTable[lineTableID];
		byte lineFlag = mapLine.lineFlag;
		if (lineFlag != 20)
		{
			return false;
		}
		int layoutMapInfoID = GameConstants.PointCodeToMapID(mapLine.start.zoneID, mapLine.start.pointID);
		POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)layoutMapInfoID);
		if (layoutMapInfoPointKind != POINT_KIND.PK_YOLK)
		{
			return false;
		}
		int count = this.FakeRetreatList.Count;
		for (int i = 0; i < count; i++)
		{
			if (this.FakeRetreatList[i].point.pointID == mapLine.start.pointID && this.FakeRetreatList[i].point.zoneID == mapLine.start.zoneID)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000A6E RID: 2670 RVA: 0x000E11A4 File Offset: 0x000DF3A4
	public LineNode GetFreeLine()
	{
		LineNode lineNode = null;
		if (this.FreeLineHeader != null)
		{
			lineNode = this.FreeLineHeader;
			this.FreeLineHeader = lineNode.Next;
		}
		return lineNode;
	}

	// Token: 0x06000A6F RID: 2671 RVA: 0x000E11D4 File Offset: 0x000DF3D4
	public void InsertWorkingList(LineNode node)
	{
		node.Previous = null;
		node.Next = this.WorkingLineHeader;
		if (node.Next != null)
		{
			node.Next.Previous = node;
		}
		this.WorkingLineHeader = node;
		node.NodeState = ELineNodeState.WORKING;
	}

	// Token: 0x06000A70 RID: 2672 RVA: 0x000E121C File Offset: 0x000DF41C
	public LineNode GetNodeByGameObject(GameObject go, bool MoveToFree = false)
	{
		if (go == null)
		{
			return null;
		}
		LineNode lineNode = null;
		this.m_LineList.TryGetValue(go.GetHashCode(), out lineNode);
		if (lineNode != null && lineNode.NodeState == ELineNodeState.WORKING)
		{
			if (MoveToFree)
			{
				if (lineNode.Previous != null)
				{
					lineNode.Previous.Next = lineNode.Next;
				}
				if (lineNode.Next != null)
				{
					lineNode.Next.Previous = lineNode.Previous;
				}
				if (this.WorkingLineHeader == lineNode)
				{
					this.WorkingLineHeader = lineNode.Next;
				}
				lineNode.Previous = null;
				lineNode.Next = this.FreeLineHeader;
				this.FreeLineHeader = lineNode;
				lineNode.NodeState = ELineNodeState.FREE;
			}
			return lineNode;
		}
		return null;
	}

	// Token: 0x06000A71 RID: 2673 RVA: 0x000E12D8 File Offset: 0x000DF4D8
	public bool recaleSpeed(int lineTableID)
	{
		MapLine mapLine = DataManager.MapDataController.MapLineTable[lineTableID];
		LineNode nodeByGameObject = this.GetNodeByGameObject(mapLine.lineObject, false);
		if (nodeByGameObject != null)
		{
			this.recalculateSpeed(nodeByGameObject, lineTableID, false);
			return true;
		}
		return false;
	}

	// Token: 0x06000A72 RID: 2674 RVA: 0x000E1318 File Offset: 0x000DF518
	public bool setLineSpeed(GameObject go, float speed)
	{
		LineNode nodeByGameObject = this.GetNodeByGameObject(go, false);
		if (nodeByGameObject != null)
		{
			nodeByGameObject.speedRate = speed;
			return true;
		}
		return false;
	}

	// Token: 0x06000A73 RID: 2675 RVA: 0x000E1340 File Offset: 0x000DF540
	public bool setLineColor(GameObject go, ELineColor color, EUnitSide unitSide, CString player, CString tag, bool bEase)
	{
		LineNode nodeByGameObject = this.GetNodeByGameObject(go, false);
		if (nodeByGameObject != null)
		{
			nodeByGameObject.colorIndex = (byte)color;
			if (unitSide != (EUnitSide)nodeByGameObject.side && nodeByGameObject.sheetUnit != null)
			{
				nodeByGameObject.side = (byte)unitSide;
				nodeByGameObject.sheetUnit.RecoverUnit();
				byte b = 0;
				if (nodeByGameObject.action == ELineAction.NORMAL)
				{
					int num = (int)((!nodeByGameObject.IsPetSkillLine) ? this.RetreatToReturn((EMarchEventType)nodeByGameObject.flag) : ((EMarchEventType)nodeByGameObject.flag));
					b |= ((!nodeByGameObject.IsPetSkillLine) ? 0 : 2);
					b |= ((!nodeByGameObject.IsSoccerRunningLine) ? 0 : 4);
					nodeByGameObject.sheetUnit.setupAnimUnit(nodeByGameObject.side, (byte)num, nodeByGameObject.angle, b);
				}
				else
				{
					b |= ((!this.CheckForceMirror(nodeByGameObject)) ? 0 : 1);
					b |= ((!nodeByGameObject.IsPetSkillLine) ? 0 : 2);
					b |= ((!nodeByGameObject.IsSoccerRunningLine) ? 0 : 4);
					nodeByGameObject.sheetUnit.setupAnimUnit(nodeByGameObject.side, nodeByGameObject.flag, nodeByGameObject.angle, b);
				}
			}
			this.mapNameController.updateLineNameColor(nodeByGameObject.NodeName, color, player, tag);
			LineNode lineNode = null;
			CHAOS chaos = GameManager.ActiveGameplay as CHAOS;
			if (chaos != null && chaos.realmController != null && chaos.realmController.mapTileController != null)
			{
				lineNode = chaos.realmController.mapTileController.selectLineNode;
			}
			if (lineNode != null && lineNode == nodeByGameObject)
			{
				bEase = false;
			}
			if (bEase && !this.CheckLineEaseDistance(nodeByGameObject))
			{
				bEase = false;
			}
			float a = (!bEase) ? 1f : 0f;
			Color white = Color.white;
			white.a = a;
			this.m_Color[2] = white;
			this.m_Color[3] = white;
			this.m_Color[4] = white;
			this.m_Color[5] = white;
			nodeByGameObject.meshFilter.mesh.colors = this.m_Color;
			nodeByGameObject.meshFilter.mesh.triangles = ((!bEase) ? this.m_Triangle : this.m_EaseTriangle);
			return true;
		}
		return false;
	}

	// Token: 0x06000A74 RID: 2676 RVA: 0x000E15AC File Offset: 0x000DF7AC
	public bool CheckLineEaseDistance(LineNode node)
	{
		return node != null && 10f <= node.distance;
	}

	// Token: 0x06000A75 RID: 2677 RVA: 0x000E15C8 File Offset: 0x000DF7C8
	public void resetAllLineColor()
	{
		LineNode lineNode = null;
		CHAOS chaos = GameManager.ActiveGameplay as CHAOS;
		if (chaos != null && chaos.realmController != null && chaos.realmController.mapTileController != null)
		{
			lineNode = chaos.realmController.mapTileController.selectLineNode;
		}
		bool flag = true;
		ELineColor elineColor = ELineColor.BLUE;
		EUnitSide eunitSide = EUnitSide.BLUE;
		for (LineNode lineNode2 = this.WorkingLineHeader; lineNode2 != null; lineNode2 = lineNode2.Next)
		{
			DataManager.checkLineColorID(lineNode2.lineTableID, out elineColor, out eunitSide, out flag);
			lineNode2.colorIndex = (byte)elineColor;
			if (elineColor == ELineColor.DEEPBLUE)
			{
				this.mapNameController.updateLineNameColor(lineNode2.NodeName, elineColor, DataManager.MapDataController.MapLineTable[lineNode2.lineTableID].playerName, DataManager.MapDataController.MapLineTable[lineNode2.lineTableID].allianceTag);
			}
			else
			{
				this.mapNameController.updateLineNameColor(lineNode2.NodeName, elineColor, null, null);
			}
			if (lineNode != null && lineNode == lineNode2)
			{
				flag = false;
			}
			if (flag)
			{
				flag = this.CheckLineEaseDistance(lineNode2);
			}
			float a = (!flag) ? 1f : 0f;
			Color white = Color.white;
			white.a = a;
			this.m_Color[2] = white;
			this.m_Color[3] = white;
			this.m_Color[4] = white;
			this.m_Color[5] = white;
			lineNode2.meshFilter.mesh.colors = this.m_Color;
			lineNode2.meshFilter.mesh.triangles = ((!flag) ? this.m_Triangle : this.m_EaseTriangle);
		}
	}

	// Token: 0x06000A76 RID: 2678 RVA: 0x000E179C File Offset: 0x000DF99C
	public bool setLineEase(GameObject go, bool bEase)
	{
		LineNode nodeByGameObject = this.GetNodeByGameObject(go, false);
		if (nodeByGameObject != null)
		{
			if (bEase && !this.CheckLineEaseDistance(nodeByGameObject))
			{
				bEase = false;
			}
			float a = (!bEase) ? 1f : 0f;
			Color white = Color.white;
			white.a = a;
			this.m_Color[2] = white;
			this.m_Color[3] = white;
			this.m_Color[4] = white;
			this.m_Color[5] = white;
			nodeByGameObject.meshFilter.mesh.colors = this.m_Color;
			nodeByGameObject.meshFilter.mesh.triangles = ((!bEase) ? this.m_Triangle : this.m_EaseTriangle);
			return true;
		}
		return false;
	}

	// Token: 0x06000A77 RID: 2679 RVA: 0x000E187C File Offset: 0x000DFA7C
	public void CheckRemoveLine(GameObject go, bool ForceRemove = false)
	{
		LineNode nodeByGameObject = this.GetNodeByGameObject(go, false);
		if (nodeByGameObject != null)
		{
			if (nodeByGameObject.IsSoccerRunningLine && !ForceRemove)
			{
				FlowLineFactory.SetRuntimeFlag(nodeByGameObject, ELineNodeRuntimeFlag.DeleteWhenArrive);
			}
			else
			{
				if (nodeByGameObject.inverseMaxTime >= 0.0001f)
				{
					float num = Mathf.Min(1f, 1f / nodeByGameObject.inverseMaxTime - nodeByGameObject.timeOffset);
					FlowLineFactory.ServerTimeOffset = Mathf.Max(-1f, Mathf.Min(1f, (num + FlowLineFactory.ServerTimeOffset) * 0.5f));
				}
				this.removeLine(go, false);
			}
		}
	}

	// Token: 0x06000A78 RID: 2680 RVA: 0x000E1914 File Offset: 0x000DFB14
	public bool removeLine(GameObject go, bool bDeleteAttacher = false)
	{
		if (go.GetComponent<MeshFilter>() == null)
		{
			return false;
		}
		LineNode nodeByGameObject = this.GetNodeByGameObject(go, true);
		if (nodeByGameObject != null)
		{
			go.SetActive(false);
			if (nodeByGameObject.sheetUnit != null)
			{
				nodeByGameObject.sheetUnit.RecoverUnit();
			}
			nodeByGameObject.bFocus = 0;
			this.mapNameController.pushLineName(ref nodeByGameObject.NodeName);
			if (bDeleteAttacher)
			{
				int childCount = nodeByGameObject.movingNode.childCount;
				for (int i = childCount - 1; i >= 0; i--)
				{
					Transform child = nodeByGameObject.movingNode.GetChild(i);
					if (child)
					{
						UnityEngine.Object.Destroy(child.gameObject);
					}
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06000A79 RID: 2681 RVA: 0x000E19C4 File Offset: 0x000DFBC4
	public void Clear()
	{
		for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
		{
			if (lineNode.NodeName != null)
			{
				this.mapNameController.pushLineName(ref lineNode.NodeName);
			}
		}
		this.mapNameController = null;
		this.ClearLine();
		if (this.m_Parent)
		{
			UnityEngine.Object.Destroy(this.m_Parent);
		}
		SheetAnimationUnitGroup.FreeResource();
		if (this.m_Bundle)
		{
			this.m_Bundle.Unload(true);
		}
	}

	// Token: 0x06000A7A RID: 2682 RVA: 0x000E1A50 File Offset: 0x000DFC50
	public EMarchEventType RetreatToReturn(EMarchEventType type)
	{
		if (type == EMarchEventType.EMET_AttackRetreat)
		{
			return EMarchEventType.EMET_AttackReturn;
		}
		if (type == EMarchEventType.EMET_CampRetreat)
		{
			return EMarchEventType.EMET_CampReturn;
		}
		if (type == EMarchEventType.EMET_GatherRetreat)
		{
			return EMarchEventType.EMET_GatherReturn;
		}
		if (type == EMarchEventType.EMET_RallyRetreat)
		{
			return EMarchEventType.EMET_RallyReturn;
		}
		if (type == EMarchEventType.EMET_HitMonsterRetreat)
		{
			return EMarchEventType.EMET_HitMonsterReturn;
		}
		if (type == EMarchEventType.EMET_FooballRetreat)
		{
			return EMarchEventType.EMET_FooballReturn;
		}
		return type;
	}

	// Token: 0x06000A7B RID: 2683 RVA: 0x000E1AA0 File Offset: 0x000DFCA0
	public bool IsHitingMonster(LineNode node)
	{
		return node.flag == 27 && node.action != ELineAction.NORMAL;
	}

	// Token: 0x06000A7C RID: 2684 RVA: 0x000E1AC0 File Offset: 0x000DFCC0
	public bool CheckForceMirror(LineNode node)
	{
		return this.IsHitingMonster(node) && node.MonsterFace == EMonsterFace.RIGHT;
	}

	// Token: 0x06000A7D RID: 2685 RVA: 0x000E1AE0 File Offset: 0x000DFCE0
	public void ResetLineState()
	{
		this.RallyLineData.Clear();
		this.FakeRetreatList.Clear();
		this.LineAutoDelQueue.Clear();
		this.PointModifyList.Clear();
		this.FriendLineCache.Clear();
		this.ArriveDelQueue.Clear();
		this.GoalCache.Clear();
	}

	// Token: 0x06000A7E RID: 2686 RVA: 0x000E1B3C File Offset: 0x000DFD3C
	public void AddFakeLine(int idx)
	{
		if (this.FakeRetreatList[idx].lineFlag == EMarchEventType.EMET_GatherMarching)
		{
			int num = GameConstants.PointCodeToMapID(this.FakeRetreatList[idx].point.zoneID, this.FakeRetreatList[idx].point.pointID);
			int tableID = (int)DataManager.MapDataController.LayoutMapInfo[num].tableID;
			if (DataManager.CompareStr(DataManager.MapDataController.ResourcesPointTable[tableID].playerName, this.FakeRetreatList[idx].playerName) == 0)
			{
				return;
			}
		}
		else if (this.FakeRetreatList[idx].lineFlag == EMarchEventType.EMET_CampMarching)
		{
			int num2 = GameConstants.PointCodeToMapID(this.FakeRetreatList[idx].point.zoneID, this.FakeRetreatList[idx].point.pointID);
			int tableID2 = (int)DataManager.MapDataController.LayoutMapInfo[num2].tableID;
			if (DataManager.CompareStr(DataManager.MapDataController.PlayerPointTable[tableID2].playerName, this.FakeRetreatList[idx].playerName) == 0)
			{
				return;
			}
		}
		else if (this.FakeRetreatList[idx].lineFlag == EMarchEventType.EMET_HitMonsterMarching)
		{
			return;
		}
		MapManager mapDataController = DataManager.MapDataController;
		int i = mapDataController.MapLineTableIDpool.spawn();
		while (i >= mapDataController.MapLineTable.Count)
		{
			mapDataController.MapLineTable.Add(new MapLine());
		}
		mapDataController.MapLineTable[i].start = this.FakeRetreatList[idx].point;
		mapDataController.MapLineTable[i].end = this.FakeRetreatList[idx].point2;
		mapDataController.MapLineTable[i].begin = (ulong)DataManager.Instance.ServerTime;
		mapDataController.MapLineTable[i].during = 5u;
		mapDataController.MapLineTable[i].EXduring = 5u;
		mapDataController.MapLineTable[i].EXbegin = 0u;
		if (this.FakeRetreatList[idx].lineFlag == EMarchEventType.EMET_AttackMarching || this.FakeRetreatList[idx].lineFlag == EMarchEventType.EMET_CampMarching || this.FakeRetreatList[idx].lineFlag == EMarchEventType.EMET_GatherMarching)
		{
			mapDataController.MapLineTable[i].lineFlag = 23;
		}
		else if (this.FakeRetreatList[idx].lineFlag == EMarchEventType.EMET_RallyAttack)
		{
			mapDataController.MapLineTable[i].lineFlag = 26;
		}
		mapDataController.MapLineTable[i].playerName.ClearString();
		mapDataController.MapLineTable[i].playerName.Append(this.FakeRetreatList[idx].playerName);
		mapDataController.MapLineTable[i].allianceTag.ClearString();
		mapDataController.MapLineTable[i].allianceTag.Append(this.FakeRetreatList[idx].allianceTag);
		FakeRetreat value = this.FakeRetreatList[idx];
		value.flag = 1;
		this.FakeRetreatList[idx] = value;
		mapDataController.addLine(i);
	}

	// Token: 0x06000A7F RID: 2687 RVA: 0x000E1EEC File Offset: 0x000E00EC
	public Vector3 DirToVector(byte dir)
	{
		Vector3 result = Vector3.up;
		switch (dir)
		{
		case 0:
			result = Vector3.up;
			break;
		case 1:
			result = Vector3.up + Vector3.right;
			break;
		case 2:
			result = Vector3.right;
			break;
		case 3:
			result = Vector3.down + Vector3.right;
			break;
		case 4:
			result = Vector3.down;
			break;
		case 5:
			result = Vector3.down + Vector3.left;
			break;
		case 6:
			result = Vector3.left;
			break;
		case 7:
			result = Vector3.up + Vector3.left;
			break;
		}
		return result;
	}

	// Token: 0x06000A80 RID: 2688 RVA: 0x000E1FB0 File Offset: 0x000E01B0
	public void addSoccerFakeLine(Vector3 from, Vector3? dirVector, byte dir = 0)
	{
		Vector3 a = Vector3.zero;
		if (dirVector != null)
		{
			a = dirVector.Value;
		}
		else
		{
			a = this.DirToVector(dir);
		}
		a.Normalize();
		Vector3 to = from + a * 1.7f;
		LineNode lineNode = this.GetLineNode(1.7f, false, 0);
		lineNode.ResetValue();
		float angle = this.SetupLineSlope(lineNode, from, to);
		this.AwakeSheetUnit(lineNode);
		float num = this.CanvasRectTranScale * DataManager.MapDataController.zoomSize;
		lineNode.NodeName = this.mapNameController.pullLineName(this.FakePlayerName, this.FakeAllianceTag, ELineColor.BLUE, new Vector2((float)((int)(lineNode.movingNode.position.x / num)), (float)((int)(lineNode.movingNode.position.y / num)) + 64f), 0);
		lineNode.NodeName.SetActive(false);
		byte setupFlag = 4;
		lineNode.sheetUnit.setupAnimUnit(0, 28, angle, setupFlag);
		lineNode.renderer.enabled = false;
		lineNode.flag = byte.MaxValue;
		lineNode.inverseMaxTime = 1f;
		lineNode.unitSpeedRate = 1f;
		FlowLineFactory.SetRuntimeFlag(lineNode, ELineNodeRuntimeFlag.SpawnSoccerDieLineWhenArrive);
		float num2 = lineNode.distance * (lineNode.timeOffset * lineNode.inverseMaxTime) - lineNode.distance * 0.5f;
		if (float.IsInfinity(num2) || float.IsNaN(num2))
		{
			num2 = 0f;
		}
		lineNode.movingNode.localPosition = new Vector3(num2, 0f, 0f);
		Debug.LogWarning("addSoccerFakeLine");
	}

	// Token: 0x06000A81 RID: 2689 RVA: 0x000E2150 File Offset: 0x000E0350
	public static bool HasRuntimeFlag(LineNode node, ELineNodeRuntimeFlag flag)
	{
		return (node.RuntimeFlag & (byte)flag) != 0;
	}

	// Token: 0x06000A82 RID: 2690 RVA: 0x000E2160 File Offset: 0x000E0360
	public static void SetRuntimeFlag(LineNode node, ELineNodeRuntimeFlag flag)
	{
		node.RuntimeFlag |= (byte)flag;
	}

	// Token: 0x06000A83 RID: 2691 RVA: 0x000E2174 File Offset: 0x000E0374
	public static void ClearRuntimeFlag(LineNode node, ELineNodeRuntimeFlag flag)
	{
		node.RuntimeFlag &= (byte)(~(byte)flag);
	}

	// Token: 0x06000A84 RID: 2692 RVA: 0x000E2188 File Offset: 0x000E0388
	public static void CheckSoccerOutsideLine(LineNode node)
	{
		if (node == null)
		{
			return;
		}
		MapLine mapLine = DataManager.MapDataController.MapLineTable[node.lineTableID];
		if ((mapLine.lineFlag & 56) == 56)
		{
			FlowLineFactory.SetRuntimeFlag(node, ELineNodeRuntimeFlag.OutsideLine);
		}
	}

	// Token: 0x06000A85 RID: 2693 RVA: 0x000E21CC File Offset: 0x000E03CC
	public void PlaySoccerArrive(LineNode node)
	{
		if (node == null)
		{
			return;
		}
		int num = GameConstants.PointCodeToMapID(node.EndPoint.zoneID, node.EndPoint.pointID);
		Debug.LogWarning(string.Concat(new string[]
		{
			"CHAOS_BallDown mapid: ",
			num.ToString(),
			" zid: ",
			node.EndPoint.zoneID.ToString(),
			" pid: ",
			node.EndPoint.pointID.ToString()
		}));
		if (this.IsSoccerHitPointVaild(num))
		{
			DataManager.msgBuffer[0] = 107;
			GameConstants.GetBytes((uint)num, DataManager.msgBuffer, 1);
			GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
		}
		SoccerGoalCache soccerGoalCache = new SoccerGoalCache(true);
		if (this.GoalCache.TryGetValue(num, out soccerGoalCache))
		{
			this.GoalCache.Remove(num);
			int? goal = soccerGoalCache.goal1;
			if (goal != null)
			{
				this.SendBallDownEffect(soccerGoalCache.goal1.Value);
			}
			int? goal2 = soccerGoalCache.goal2;
			if (goal2 != null)
			{
				this.SendBallDownEffect(soccerGoalCache.goal2.Value);
			}
			int? goal3 = soccerGoalCache.goal3;
			if (goal3 != null)
			{
				this.SendBallDownEffect(soccerGoalCache.goal3.Value);
			}
			int? goal4 = soccerGoalCache.goal4;
			if (goal4 != null)
			{
				this.SendBallDownEffect(soccerGoalCache.goal4.Value);
			}
			int? goal5 = soccerGoalCache.goal5;
			if (goal5 != null)
			{
				this.SendBallDownEffect(soccerGoalCache.goal5.Value);
			}
			int? goal6 = soccerGoalCache.goal6;
			if (goal6 != null)
			{
				this.SendBallDownEffect(soccerGoalCache.goal6.Value);
			}
			int? goal7 = soccerGoalCache.goal7;
			if (goal7 != null)
			{
				this.SendBallDownEffect(soccerGoalCache.goal7.Value);
			}
			int? goal8 = soccerGoalCache.goal8;
			if (goal8 != null)
			{
				this.SendBallDownEffect(soccerGoalCache.goal8.Value);
			}
			int? goal9 = soccerGoalCache.goal9;
			if (goal9 != null)
			{
				this.SendBallDownEffect(soccerGoalCache.goal9.Value);
			}
		}
	}

	// Token: 0x06000A86 RID: 2694 RVA: 0x000E2408 File Offset: 0x000E0608
	public void Update(float deltaTime)
	{
		this.FriendLineCache.Clear();
		if (this.FakeRetreatList.Count > 0)
		{
			for (int i = 0; i < this.FakeRetreatList.Count; i++)
			{
				if (this.FakeRetreatList[i].lineFlag == EMarchEventType.EMET_RallyAttack)
				{
					for (int j = 0; j < this.PointModifyList.Count; j++)
					{
						PointCode point = this.FakeRetreatList[i].point;
						if (this.PointModifyList[j].Kind == POINT_KIND.PK_YOLK)
						{
							point.zoneID &= 1023;
						}
						if (point.pointID == this.PointModifyList[j].Code.pointID && point.zoneID == this.PointModifyList[j].Code.zoneID)
						{
							this.AddFakeLine(i);
							break;
						}
					}
				}
				else
				{
					int layoutMapInfoID = GameConstants.PointCodeToMapID(this.FakeRetreatList[i].point.zoneID, this.FakeRetreatList[i].point.pointID);
					POINT_KIND layoutMapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint)layoutMapInfoID);
					if (layoutMapInfoPointKind == POINT_KIND.PK_CITY)
					{
						for (int k = 0; k < this.PointModifyList.Count; k++)
						{
							PointCode point2 = this.FakeRetreatList[i].point;
							if (point2.pointID == this.PointModifyList[k].Code.pointID && point2.zoneID == this.PointModifyList[k].Code.zoneID)
							{
								this.AddFakeLine(i);
								break;
							}
						}
					}
					else if (layoutMapInfoPointKind != POINT_KIND.PK_YOLK || this.FakeRetreatList[i].lineFlag != EMarchEventType.EMET_CampMarching)
					{
						this.AddFakeLine(i);
					}
				}
			}
			this.FakeRetreatList.Clear();
		}
		this.PointModifyList.Clear();
		float num = this.CanvasRectTranScale * DataManager.MapDataController.zoomSize;
		for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
		{
			bool flag = lineNode.IsPetSkillLine || lineNode.IsSoccerRunningLine;
			if (lineNode.sheetUnit != null)
			{
				int num2 = lineNode.sheetUnit.Update(deltaTime);
				if ((num2 & 1) != 0)
				{
					if (!flag)
					{
						if (lineNode.flag == 27)
						{
							DataManager.msgBuffer[0] = 86;
							GameConstants.GetBytes((uint)lineNode.lineTableID, DataManager.msgBuffer, 1);
							GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						}
						if (lineNode.flag == 30)
						{
							if (lineNode.FriendLineID != 1048576)
							{
								MapLine mapLine = DataManager.MapDataController.MapLineTable[lineNode.FriendLineID];
								LineNode nodeByGameObject = this.GetNodeByGameObject(mapLine.lineObject, false);
								if (nodeByGameObject != null && GameConstants.IsSoccerRunningLine(nodeByGameObject.lineTableID) && nodeByGameObject.action != ELineAction.NORMAL)
								{
									nodeByGameObject.timer = 0f;
								}
								int value = GameConstants.PointCodeToMapID(mapLine.start.zoneID, mapLine.start.pointID);
								Debug.LogWarning("CHAOS_BallKick: " + value.ToString());
								DataManager.msgBuffer[0] = 106;
								GameConstants.GetBytes((uint)value, DataManager.msgBuffer, 1);
								GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
							}
							if (FlowLineFactory.HasRuntimeFlag(lineNode, ELineNodeRuntimeFlag.SpawnSoccerFakeLine))
							{
								MapLine mapLine2 = DataManager.MapDataController.MapLineTable[lineNode.lineTableID];
								int value2 = GameConstants.PointCodeToMapID(mapLine2.start.zoneID, mapLine2.start.pointID);
								Debug.LogWarning("CHAOS_BallKick: " + value2.ToString());
								DataManager.msgBuffer[0] = 106;
								GameConstants.GetBytes((uint)value2, DataManager.msgBuffer, 1);
								GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
								CHAOS chaos = GameManager.ActiveGameplay as CHAOS;
								if (chaos != null && chaos.realmController != null)
								{
									Vector3 from = chaos.realmController.PointCodeToWorldPosition(mapLine2.start.zoneID, mapLine2.start.pointID);
									this.addSoccerFakeLine(from, null, lineNode.FakeLineDir);
								}
							}
							lineNode.Shake();
						}
					}
				}
				else if ((num2 & 2) != 0)
				{
					if (lineNode.action != ELineAction.NORMAL)
					{
						lineNode.timer = 0f;
					}
					if (!flag && lineNode.flag == 30 && lineNode.FriendLineID != 1048576)
					{
						MapLine mapLine3 = DataManager.MapDataController.MapLineTable[lineNode.FriendLineID];
						LineNode nodeByGameObject2 = this.GetNodeByGameObject(mapLine3.lineObject, false);
						if (nodeByGameObject2 != null && GameConstants.IsSoccerRunningLine(nodeByGameObject2.lineTableID) && nodeByGameObject2.action != ELineAction.NORMAL)
						{
							nodeByGameObject2.timer = 0f;
						}
					}
					if (FlowLineFactory.HasRuntimeFlag(lineNode, ELineNodeRuntimeFlag.SoccerDieLine))
					{
						FlowLineFactory.SetRuntimeFlag(lineNode, ELineNodeRuntimeFlag.DeleteWhenArrive);
					}
				}
			}
			if (lineNode.action == ELineAction.NORMAL)
			{
				float num3 = lineNode.speedRate * deltaTime;
				lineNode.curCoordU -= num3;
				lineNode.maxCoordU -= num3;
				lineNode.sideOffset1 -= num3;
				lineNode.sideOffset2 -= num3;
				float y = (float)lineNode.colorIndex * 0.25f;
				float y2 = (float)(lineNode.colorIndex + 1) * 0.25f;
				this.m_Uv[0] = new Vector2(lineNode.curCoordU, y);
				this.m_Uv[1] = new Vector2(lineNode.curCoordU, y2);
				this.m_Uv[2] = new Vector2(lineNode.sideOffset1, y);
				this.m_Uv[3] = new Vector2(lineNode.sideOffset1, y2);
				this.m_Uv[4] = new Vector2(lineNode.sideOffset2, y);
				this.m_Uv[5] = new Vector2(lineNode.sideOffset2, y2);
				this.m_Uv[6] = new Vector2(lineNode.maxCoordU, y);
				this.m_Uv[7] = new Vector2(lineNode.maxCoordU, y2);
				lineNode.meshFilter.mesh.uv = this.m_Uv;
				if (lineNode.gameObject != null)
				{
					lineNode.timeOffset += deltaTime * lineNode.unitSpeedRate;
					if (lineNode.timeOffset * lineNode.inverseMaxTime > 1f)
					{
						if (lineNode.bFocus < 1)
						{
							lineNode.bFocus = 2;
						}
						if (FlowLineFactory.HasRuntimeFlag(lineNode, ELineNodeRuntimeFlag.SpawnSoccerDieLineWhenArrive))
						{
							FlowLineFactory.ClearRuntimeFlag(lineNode, ELineNodeRuntimeFlag.SpawnSoccerDieLineWhenArrive);
							FlowLineFactory.SetRuntimeFlag(lineNode, ELineNodeRuntimeFlag.SoccerDieLine);
							lineNode.sheetUnit.RecoverUnit();
							byte setupFlag = 8;
							lineNode.sheetUnit.setupAnimUnit(lineNode.side, 0, lineNode.angle, setupFlag);
						}
						if (FlowLineFactory.HasRuntimeFlag(lineNode, ELineNodeRuntimeFlag.DeleteWhenArrive))
						{
							this.ArriveDelQueue.Add(lineNode.gameObject);
							if (lineNode.IsSoccerRunningLine)
							{
								this.PlaySoccerArrive(lineNode);
							}
						}
						lineNode = lineNode.Next;
						continue;
					}
					float num4 = lineNode.distance * (lineNode.timeOffset * lineNode.inverseMaxTime) - lineNode.distance * 0.5f;
					if (float.IsInfinity(num4) || float.IsNaN(num4))
					{
						num4 = 0f;
					}
					lineNode.movingNode.localPosition = new Vector3(num4, 0f, 0f);
					if (lineNode.sheetUnit.HasSpecialSimu())
					{
						lineNode.sheetUnit.RunSpecialSimuMode(lineNode);
					}
					if (lineNode.bFocus == 0 && lineNode.NodeName != null)
					{
						lineNode.NodeName.updateName(new Vector2((float)((int)(lineNode.movingNode.position.x / num)), (float)((int)(lineNode.movingNode.position.y / num)) + 64f));
					}
				}
			}
			else
			{
				lineNode.timer -= deltaTime;
				if (lineNode.timer <= 0f)
				{
					if (lineNode.AutoDelete != 0)
					{
						this.LineAutoDelQueue.Add(lineNode);
						lineNode = lineNode.Next;
						continue;
					}
					ELineAction action = lineNode.action;
					lineNode.action = ELineAction.NORMAL;
					lineNode.sheetUnit.RecoverUnit();
					int num5 = (int)this.RetreatToReturn((EMarchEventType)lineNode.flag);
					byte b = 0;
					if (!lineNode.IsPetSkillLine && !lineNode.IsSoccerRunningLine)
					{
						if (lineNode.flag == 24 || lineNode.flag == 25)
						{
							lineNode.side = ((lineNode.colorIndex != 2 && lineNode.colorIndex != 1) ? 0 : 1);
							MapLine mapLine4 = DataManager.MapDataController.MapLineTable[lineNode.lineTableID];
							lineNode.NodeName.updateName(mapLine4.playerName, mapLine4.allianceTag, (ELineColor)lineNode.colorIndex);
						}
						else if (lineNode.flag == 27)
						{
							DataManager.msgBuffer[0] = 91;
							GameConstants.GetBytes((uint)lineNode.lineTableID, DataManager.msgBuffer, 1);
							GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
						}
						else if (lineNode.flag == 26 && lineNode.NodeName != null)
						{
							lineNode.NodeName.updateName(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].playerName, DataManager.MapDataController.MapLineTable[lineNode.lineTableID].allianceTag, (ELineColor)lineNode.colorIndex);
						}
					}
					else if (lineNode.IsSoccerRunningLine)
					{
						num5 = (int)lineNode.flag;
						b |= 4;
						if (lineNode.NodeName != null)
						{
							lineNode.NodeName.updateName(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].playerName, DataManager.MapDataController.MapLineTable[lineNode.lineTableID].allianceTag, (ELineColor)lineNode.colorIndex);
						}
					}
					else
					{
						num5 = (int)lineNode.flag;
						b |= 2;
						if (lineNode.NodeName != null)
						{
							lineNode.NodeName.updateName(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].playerName, DataManager.MapDataController.MapLineTable[lineNode.lineTableID].allianceTag, (ELineColor)lineNode.colorIndex);
						}
					}
					lineNode.sheetUnit.setupAnimUnit(lineNode.side, (byte)num5, lineNode.angle, b);
					if (action != ELineAction.ACTION_BEFORE_WITHOUT_LINE)
					{
						lineNode.renderer.enabled = true;
					}
					this.recalculateSpeed(lineNode, lineNode.lineTableID, true);
					if (lineNode.timer > -10f && (DataManager.MapDataController.MapLineTable[lineNode.lineTableID].baseFlag & 1) != 0 && DataManager.MapDataController.MapLineTable[lineNode.lineTableID].emojiID != 0)
					{
						int num6 = -2;
						MapLine mapLine5 = DataManager.MapDataController.MapLineTable[lineNode.lineTableID];
						mapLine5.baseFlag &= (byte)num6;
						DataManager.MapDataController.MapLineTable[lineNode.lineTableID].emojiID = 0;
						CHAOS chaos2 = GameManager.ActiveGameplay as CHAOS;
						if (chaos2 != null && chaos2.realmController != null)
						{
							chaos2.realmController.UpdateLineEmoji(lineNode.lineTableID);
						}
					}
					if (lineNode.IsPetSkillLine && lineNode.timer > -10f)
					{
						Door door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
						if (door == null || door.m_eMode == EUIOriginMode.Show)
						{
							CHAOS chaos3 = GameManager.ActiveGameplay as CHAOS;
							if (chaos3 != null && chaos3.realmController != null && chaos3.realmController.mapTileController != null)
							{
								float num7;
								if (GUIManager.Instance.m_UICanvas.renderMode == RenderMode.ScreenSpaceCamera)
								{
									num7 = GUIManager.Instance.pDVMgr.CanvasRT.localScale.x;
								}
								else
								{
									num7 = DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
								}
								byte lineFlag = DataManager.MapDataController.MapLineTable[lineNode.lineTableID].lineFlag;
								MapDamageEffTb recordByKey = PetManager.Instance.MapDamageEffTable.GetRecordByKey((ushort)lineFlag);
								if (recordByKey.ID == (ushort)lineFlag)
								{
									float d = DataManager.MapDataController.zoomSize * num7;
									Vector2 vector = chaos3.realmController.mapTileController.getTilePosition(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[lineNode.lineTableID].start.pointID) * d;
									Vector3 value3 = new Vector3(vector.x, vector.y, 0f);
									CString cstring = StringManager.Instance.SpawnString(30);
									if (recordByKey.SoundPakNO != 0)
									{
										cstring.ClearString();
										cstring.StringToFormat("Role/");
										cstring.IntToFormat((long)recordByKey.SoundPakNO, 3, false);
										cstring.AppendFormat("{0}{1}");
										if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.HeroSFX, recordByKey.SoundPakNO, false))
										{
											AudioManager.Instance.PlaySFX(recordByKey.FireSound, 0f, PitchKind.NoPitch, null, new Vector3?(value3));
										}
									}
									else
									{
										AudioManager.Instance.PlaySFX(recordByKey.FireSound, 0f, PitchKind.NoPitch, null, new Vector3?(value3));
									}
									if (recordByKey.ParticlePakNO != 0)
									{
										cstring.ClearString();
										cstring.StringToFormat("Particle/Monster_Effects_");
										cstring.IntToFormat((long)recordByKey.ParticlePakNO, 3, false);
										cstring.AppendFormat("{0}{1}");
										if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Particle, AssetType.Effects, recordByKey.ParticlePakNO, false))
										{
											DataManager.MapDataController.MapWeaponAttack(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[lineNode.lineTableID].start.pointID, recordByKey.FireParticle, (float)recordByKey.FireParticleDuring * 0.001f);
										}
									}
									else
									{
										DataManager.MapDataController.MapWeaponAttack(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[lineNode.lineTableID].start.pointID, recordByKey.FireParticle, (float)recordByKey.FireParticleDuring * 0.001f);
									}
									StringManager.Instance.DeSpawnString(cstring);
								}
							}
						}
					}
					lineNode.timer = -11f;
				}
				if (this.IsHitingMonster(lineNode))
				{
					lineNode.movingNode.localPosition = new Vector3(lineNode.distance * -0.5f, 0f, 0f);
					Vector3 vector2 = lineNode.movingNode.TransformPoint(lineNode.movingNode.localPosition);
					vector2 += ((lineNode.MonsterFace != EMonsterFace.LEFT) ? this.MONSTER_FACERIGHT_OFFSET : this.MONSTER_FACELEFT_OFFSET);
					lineNode.movingNode.position = vector2;
				}
				if (lineNode.bFocus == 0)
				{
					lineNode.NodeName.updateName(new Vector2((float)((int)(lineNode.movingNode.position.x / num)), (float)((int)(lineNode.movingNode.position.y / num)) + 64f));
				}
				float? shakingTimer = lineNode.ShakingTimer;
				if (shakingTimer != null)
				{
					if (lineNode.ShakingTimer.Value <= 0f)
					{
						lineNode.ShakingTimer = null;
					}
					else
					{
						LineNode lineNode2 = lineNode;
						float? shakingTimer2 = lineNode2.ShakingTimer;
						lineNode2.ShakingTimer = ((shakingTimer2 == null) ? null : new float?(shakingTimer2.Value - deltaTime));
						float num8;
						if (lineNode.ShakingFlag == 0)
						{
							lineNode.ShakingFlag = 1;
							num8 = lineNode.ShakingTimer.Value * 1f;
						}
						else
						{
							lineNode.ShakingFlag = 0;
							num8 = lineNode.ShakingTimer.Value * -1f;
						}
						lineNode.movingNode.localPosition += new Vector3(num8, 0f, -num8);
					}
				}
			}
		}
		if (this.LineAutoDelQueue.Count > 0)
		{
			for (int l = 0; l < this.LineAutoDelQueue.Count; l++)
			{
				if (this.LineAutoDelQueue[l].lineTableID < 1048576)
				{
					DataManager.MapDataController.delLine(this.LineAutoDelQueue[l].lineTableID, 0, 0);
				}
			}
			this.LineAutoDelQueue.Clear();
		}
		if (this.ArriveDelQueue.Count > 0)
		{
			for (int m = 0; m < this.ArriveDelQueue.Count; m++)
			{
				this.removeLine(this.ArriveDelQueue[m], false);
			}
			this.ArriveDelQueue.Clear();
		}
	}

	// Token: 0x06000A87 RID: 2695 RVA: 0x000E3648 File Offset: 0x000E1848
	public bool OnClick(Vector2 clickpos, ref LineNode node)
	{
		if (node != null)
		{
			node.bFocus = 0;
		}
		Vector3 point = Camera.main.ScreenToWorldPoint(clickpos);
		point.z = 0f;
		float zoomSize = DataManager.MapDataController.zoomSize;
		float num = 1f * zoomSize;
		float num2 = num * 0.5f;
		for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
		{
			if (lineNode.IsSoccerRunningLine)
			{
				SheetAnimationUnitGroup sheetAnimationUnitGroup = lineNode.sheetUnit as SheetAnimationUnitGroup;
				Transform transform = sheetAnimationUnitGroup.transform;
				for (int i = 0; i < transform.childCount; i++)
				{
					Vector3 position = transform.GetChild(i).position;
					Rect rect = new Rect(position.x - num2, position.y - num2, num, num);
					if (rect.Contains(point))
					{
						node = lineNode;
						this.fillLineNode(node);
						return true;
					}
				}
			}
			else
			{
				Vector3 position = lineNode.movingNode.position;
				Rect rect2 = new Rect(position.x - num2, position.y - num2, num, num);
				if (rect2.Contains(point))
				{
					node = lineNode;
					this.fillLineNode(node);
					return true;
				}
			}
		}
		if (node != null)
		{
			this.easeLineNode(node);
			node = null;
		}
		return false;
	}

	// Token: 0x06000A88 RID: 2696 RVA: 0x000E379C File Offset: 0x000E199C
	public bool OnClick(byte groupID, ref LineNode node)
	{
		if (node != null)
		{
			node.bFocus = 0;
		}
		if (groupID == 9)
		{
			for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
			{
				if (GameConstants.IsPetSkillLine(lineNode.lineTableID) && DataManager.MapDataController.MapLineTable[lineNode.lineTableID].during == PetManager.Instance.m_PetMarchEventData.MarchEventTime.RequireTime && DataManager.CompareStr(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].playerName, DataManager.Instance.RoleAttr.Name) == 0 && ((DataManager.MapDataController.MapLineTable[lineNode.lineTableID].allianceTag.Length == 0 && DataManager.Instance.RoleAlliance.Tag.Length == 0) || DataManager.Instance.IsSameAlliance(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].allianceTag)) && GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[lineNode.lineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[lineNode.lineTableID].start.pointID) == DataManager.Instance.RoleAttr.CapitalPoint)
				{
					node = lineNode;
					this.fillLineNode(node);
					return true;
				}
			}
		}
		else if (groupID == 8)
		{
			for (LineNode lineNode2 = this.WorkingLineHeader; lineNode2 != null; lineNode2 = lineNode2.Next)
			{
				if (DataManager.MapDataController.MapLineTable[lineNode2.lineTableID].during == DataManager.Instance.beCaptured.TotalTime && DataManager.MapDataController.MapLineTable[lineNode2.lineTableID].lineFlag == 22 && DataManager.CompareStr(DataManager.MapDataController.MapLineTable[lineNode2.lineTableID].playerName, DataManager.Instance.RoleAttr.Name) == 0 && ((DataManager.MapDataController.MapLineTable[lineNode2.lineTableID].allianceTag.Length == 0 && DataManager.Instance.RoleAlliance.Tag.Length == 0) || DataManager.Instance.IsSameAlliance(DataManager.MapDataController.MapLineTable[lineNode2.lineTableID].allianceTag)) && GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[lineNode2.lineTableID].end.zoneID, DataManager.MapDataController.MapLineTable[lineNode2.lineTableID].end.pointID) == DataManager.Instance.RoleAttr.CapitalPoint)
				{
					node = lineNode2;
					this.fillLineNode(node);
					return true;
				}
			}
		}
		else
		{
			byte b = 0;
			byte[] array = new byte[5];
			int[] array2 = new int[5];
			for (LineNode lineNode3 = this.WorkingLineHeader; lineNode3 != null; lineNode3 = lineNode3.Next)
			{
				int num = GameConstants.PointCodeToMapID(DataManager.Instance.MarchEventData[(int)groupID].Point.zoneID, DataManager.Instance.MarchEventData[(int)groupID].Point.pointID);
				if (DataManager.MapDataController.MapLineTable[lineNode3.lineTableID].during == DataManager.Instance.MarchEventTime[(int)groupID].RequireTime && DataManager.MapDataController.MapLineTable[lineNode3.lineTableID].lineFlag == (byte)DataManager.Instance.MarchEventData[(int)groupID].Type && ((DataManager.MapDataController.MapLineTable[lineNode3.lineTableID].allianceTag.Length == 0 && DataManager.Instance.RoleAlliance.Tag.Length == 0) || DataManager.Instance.IsSameAlliance(DataManager.MapDataController.MapLineTable[lineNode3.lineTableID].allianceTag)) && (DataManager.MapDataController.MapLineTable[lineNode3.lineTableID].lineFlag == 12 || DataManager.CompareStr(DataManager.MapDataController.MapLineTable[lineNode3.lineTableID].playerName, DataManager.Instance.RoleAttr.Name) == 0) && (GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[lineNode3.lineTableID].end.zoneID, DataManager.MapDataController.MapLineTable[lineNode3.lineTableID].end.pointID) == num || GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[lineNode3.lineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[lineNode3.lineTableID].start.pointID) == num))
				{
					byte b2 = 0;
					ulong begin = DataManager.MapDataController.MapLineTable[lineNode3.lineTableID].begin;
					ulong num2 = begin;
					bool flag = true;
					for (byte b3 = 0; b3 < DataManager.Instance.MaxMarchEventNum; b3 += 1)
					{
						if (DataManager.Instance.MarchEventData[(int)b3].Type > EMarchEventType.EMET_RallyStanby)
						{
							ulong num3 = (ulong)DataManager.Instance.MarchEventTime[(int)b3].BeginTime;
							num3 = ((begin <= num3) ? (num3 - begin) : (begin - num3));
							if (flag)
							{
								num2 = num3;
								b = 1;
								b2 = (array[0] = b3);
								flag = false;
							}
							else if (num3 < num2)
							{
								num2 = num3;
								b = 1;
								b2 = (array[0] = b3);
							}
							else if (num3 == num2)
							{
								array[(int)b] = b3;
								b += 1;
							}
						}
					}
					if (b2 == groupID)
					{
						node = lineNode3;
						this.fillLineNode(node);
						return true;
					}
					if (b > 1)
					{
						for (int i = 0; i < (int)b; i++)
						{
							if (array[i] == groupID)
							{
								node = lineNode3;
								this.fillLineNode(node);
								return true;
							}
						}
					}
				}
			}
		}
		if (node != null)
		{
			this.easeLineNode(node);
			node = null;
		}
		return false;
	}

	// Token: 0x06000A89 RID: 2697 RVA: 0x000E3DFC File Offset: 0x000E1FFC
	public bool OnClick(int lineTableID, ref LineNode node)
	{
		if (node != null)
		{
			node.bFocus = 0;
		}
		for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
		{
			if (lineNode.lineTableID == lineTableID)
			{
				node = lineNode;
				this.fillLineNode(node);
				return true;
			}
		}
		if (node != null)
		{
			this.easeLineNode(node);
			node = null;
		}
		return false;
	}

	// Token: 0x06000A8A RID: 2698 RVA: 0x000E3E60 File Offset: 0x000E2060
	public LineNode getLineValue(GameObject go)
	{
		return this.GetNodeByGameObject(go, false);
	}

	// Token: 0x06000A8B RID: 2699 RVA: 0x000E3E6C File Offset: 0x000E206C
	public void MoveLine(Vector2 moveDelta)
	{
		float num = this.CanvasRectTranScale * DataManager.MapDataController.zoomSize;
		for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
		{
			if (lineNode != null && lineNode.gameObject != null)
			{
				lineNode.lineTransform.position = new Vector3(lineNode.lineTransform.position.x + moveDelta.x * this.CanvasRectTranScale, lineNode.lineTransform.position.y + moveDelta.y * this.CanvasRectTranScale, lineNode.lineTransform.position.z);
				if (lineNode.bFocus == 2 && lineNode.NodeName != null)
				{
					lineNode.NodeName.updateName(new Vector2((float)((int)(lineNode.movingNode.position.x / num)), (float)((int)(lineNode.movingNode.position.y / num)) + 64f));
				}
			}
		}
	}

	// Token: 0x06000A8C RID: 2700 RVA: 0x000E3F80 File Offset: 0x000E2180
	public void ClearLine()
	{
		for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
		{
			lineNode.Previous = null;
			if (lineNode.gameObject != null)
			{
				UnityEngine.Object.Destroy(lineNode.gameObject);
			}
			if (lineNode.movingNode != null && lineNode.movingNode.gameObject != null)
			{
				UnityEngine.Object.Destroy(lineNode.movingNode.gameObject);
			}
		}
		for (LineNode lineNode = this.FreeLineHeader; lineNode != null; lineNode = lineNode.Next)
		{
			lineNode.Previous = null;
			if (lineNode.gameObject != null)
			{
				UnityEngine.Object.Destroy(lineNode.gameObject);
			}
			if (lineNode.movingNode != null && lineNode.movingNode.gameObject != null)
			{
				UnityEngine.Object.Destroy(lineNode.movingNode.gameObject);
			}
		}
		this.m_LineList.Clear();
	}

	// Token: 0x06000A8D RID: 2701 RVA: 0x000E4080 File Offset: 0x000E2280
	public void LineNameTextRebuilt()
	{
		for (LineNode lineNode = this.WorkingLineHeader; lineNode != null; lineNode = lineNode.Next)
		{
			if (lineNode.NodeName != null)
			{
				lineNode.NodeName.NameTextRebuilt();
			}
		}
	}

	// Token: 0x06000A8E RID: 2702 RVA: 0x000E40BC File Offset: 0x000E22BC
	private void SendBallDownEffect(int mapid)
	{
		DataManager.msgBuffer[0] = 105;
		GameConstants.GetBytes((uint)mapid, DataManager.msgBuffer, 1);
		GameManager.notifyObservers(1, 0, DataManager.msgBuffer);
	}

	// Token: 0x06000A8F RID: 2703 RVA: 0x000E40E0 File Offset: 0x000E22E0
	private int IsSoccerGoal(int mapid)
	{
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[mapid];
		if (mapPoint.pointKind == 11)
		{
			return 1;
		}
		if (mapPoint.pointKind == 8)
		{
			if (DataManager.MapDataController.PlayerPointTable[(int)mapPoint.tableID].cityProperty == CITY_PROPERTY.CP_NPC)
			{
				return 2;
			}
		}
		else if (this.IsWonderTerrain(mapid))
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06000A90 RID: 2704 RVA: 0x000E4158 File Offset: 0x000E2358
	private bool IsSoccerHitPointVaild(int mapid)
	{
		if (this.IsSoccerGoal(mapid) != 0)
		{
			return true;
		}
		MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[mapid];
		return mapPoint.pointKind == 0;
	}

	// Token: 0x06000A91 RID: 2705 RVA: 0x000E4198 File Offset: 0x000E2398
	private bool IsWonderTerrain(int mapid)
	{
		CHAOS chaos = GameManager.ActiveGameplay as CHAOS;
		if (chaos != null && chaos.realmController != null && chaos.realmController.mapTileController != null && chaos.realmController.mapTileController.TileMapInfo != null && mapid < chaos.realmController.mapTileController.TileMapInfo.Length)
		{
			byte b = chaos.realmController.mapTileController.TileMapInfo[mapid];
			if (b >= 99 && b < 109)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000A92 RID: 2706 RVA: 0x000E4230 File Offset: 0x000E2430
	public void CheckTouchDownPosEffect(ushort zoneid, byte pointid)
	{
		Vector2 tileMapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(zoneid, pointid);
		int num = GameConstants.PointCodeToMapID(zoneid, pointid);
		Debug.LogWarning(string.Concat(new string[]
		{
			"CheckTouchDownPosEffect mapid: ",
			num.ToString(),
			" zid: ",
			zoneid.ToString(),
			" pid: ",
			pointid.ToString()
		}));
		if (!this.IsSoccerHitPointVaild(num))
		{
			return;
		}
		bool flag = false;
		SoccerGoalCache value = new SoccerGoalCache(true);
		int num2 = this.IsSoccerGoal(num);
		if (num2 != 0)
		{
			value.SetValue(8, num);
			if (num2 == 1)
			{
				flag = true;
			}
		}
		for (int i = 0; i < 8; i++)
		{
			int num3 = (int)tileMapPosbyPointCode.x + (int)this.SideOffsetOfMapPos[i].x;
			if (num3 <= 511 && num3 >= 0)
			{
				int num4 = (int)tileMapPosbyPointCode.y + (int)this.SideOffsetOfMapPos[i].y;
				if (num4 <= 1023 && num4 >= 0)
				{
					num = GameConstants.TileMapPosToMapID(num3, num4);
					num2 = this.IsSoccerGoal(num);
					if (num2 != 0)
					{
						if (num2 != 1 || !flag)
						{
							value.SetValue(i, num);
							if (num2 == 1)
							{
								flag = true;
							}
						}
					}
				}
			}
		}
		if (value.HasValue())
		{
			if (this.GoalCache.Count >= 20)
			{
				this.GoalCache.Clear();
			}
			this.GoalCache.Add(GameConstants.PointCodeToMapID(zoneid, pointid), value);
			Debug.LogWarning("Soccer Gaol Cache");
		}
	}

	// Token: 0x040023E0 RID: 9184
	public const int MAX_FLOWLINE = 512;

	// Token: 0x040023E1 RID: 9185
	public const float LINE_HEIGHT = 0.4f;

	// Token: 0x040023E2 RID: 9186
	public const float OPAQUE_SIDE_LEN = 5f;

	// Token: 0x040023E3 RID: 9187
	public const float UV_PER_UNIT = 0.25f;

	// Token: 0x040023E4 RID: 9188
	public const float ATK_DISPLAY_LEN = 5f;

	// Token: 0x040023E5 RID: 9189
	public const float PETSKILL_DISPLAY_LEN = 1f;

	// Token: 0x040023E6 RID: 9190
	public const float SOCCER_DISPLAY_LEN = 2f;

	// Token: 0x040023E7 RID: 9191
	private const float nameOffset = 64f;

	// Token: 0x040023E8 RID: 9192
	private LineContainer m_LineList = new LineContainer();

	// Token: 0x040023E9 RID: 9193
	private LineNode WorkingLineHeader;

	// Token: 0x040023EA RID: 9194
	private LineNode FreeLineHeader;

	// Token: 0x040023EB RID: 9195
	private GameObject m_Parent;

	// Token: 0x040023EC RID: 9196
	public AssetBundle m_Bundle;

	// Token: 0x040023ED RID: 9197
	private Vector3[] m_Vertices = new Vector3[8];

	// Token: 0x040023EE RID: 9198
	private Vector2[] m_Uv = new Vector2[8];

	// Token: 0x040023EF RID: 9199
	private Color[] m_Color = new Color[8];

	// Token: 0x040023F0 RID: 9200
	private readonly Vector3 MONSTER_FACELEFT_OFFSET = new Vector3(-0.621f, -0.076f, 0f);

	// Token: 0x040023F1 RID: 9201
	private readonly Vector3 MONSTER_FACERIGHT_OFFSET = new Vector3(0.621f, -0.076f, 0f);

	// Token: 0x040023F2 RID: 9202
	private readonly int[] m_Triangle = new int[]
	{
		0,
		1,
		6,
		7,
		6,
		1
	};

	// Token: 0x040023F3 RID: 9203
	private readonly int[] m_EaseTriangle = new int[]
	{
		0,
		1,
		2,
		3,
		2,
		1,
		5,
		6,
		4,
		7,
		6,
		5
	};

	// Token: 0x040023F4 RID: 9204
	private float m_ParentScaleBase = 1f;

	// Token: 0x040023F5 RID: 9205
	private float m_ScaleRate = 1f;

	// Token: 0x040023F6 RID: 9206
	private MapTileBloodName mapNameController;

	// Token: 0x040023F7 RID: 9207
	private float CanvasRectTranScale = 1f;

	// Token: 0x040023F8 RID: 9208
	public CString LastRallyName = new CString(13);

	// Token: 0x040023F9 RID: 9209
	public List<RallyNode> RallyLineData = new List<RallyNode>();

	// Token: 0x040023FA RID: 9210
	public List<FakeRetreat> FakeRetreatList = new List<FakeRetreat>();

	// Token: 0x040023FB RID: 9211
	public List<LineNode> LineAutoDelQueue = new List<LineNode>();

	// Token: 0x040023FC RID: 9212
	public List<PointModifyNode> PointModifyList = new List<PointModifyNode>();

	// Token: 0x040023FD RID: 9213
	public Dictionary<int, int> FriendLineCache = new Dictionary<int, int>();

	// Token: 0x040023FE RID: 9214
	public List<GameObject> ArriveDelQueue = new List<GameObject>();

	// Token: 0x040023FF RID: 9215
	public Dictionary<int, SoccerGoalCache> GoalCache = new Dictionary<int, SoccerGoalCache>();

	// Token: 0x04002400 RID: 9216
	public static float ServerTimeOffset;

	// Token: 0x04002401 RID: 9217
	private CString FakePlayerName = new CString(13);

	// Token: 0x04002402 RID: 9218
	private CString FakeAllianceTag = new CString(4);

	// Token: 0x04002403 RID: 9219
	public readonly Vector2[] SideOffsetOfMapPos = new Vector2[]
	{
		new Vector2(0f, -2f),
		new Vector2(1f, -1f),
		new Vector2(2f, 0f),
		new Vector2(1f, 1f),
		new Vector2(0f, 2f),
		new Vector2(-1f, 1f),
		new Vector2(-2f, 0f),
		new Vector2(-1f, -1f)
	};
}
