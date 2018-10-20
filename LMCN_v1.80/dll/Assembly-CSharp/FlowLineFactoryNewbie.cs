using System;
using UnityEngine;

// Token: 0x02000259 RID: 601
public class FlowLineFactoryNewbie
{
	// Token: 0x06000AB7 RID: 2743 RVA: 0x000E5E9C File Offset: 0x000E409C
	public FlowLineFactoryNewbie(Transform realmGroup, float tileBaseScale)
	{
		this.CanvasRectTranScale = DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
		this.m_Parent = new GameObject("FlowLineList_Newbie");
		if (realmGroup != null)
		{
			this.m_Parent.transform.SetParent(realmGroup);
			this.m_Parent.transform.localPosition = Vector3.zero;
			this.m_ParentScaleBase = 1f;
		}
		this.ScaleRate = tileBaseScale;
		SheetAnimationUnitGroupNewbie.InitResource();
	}

	// Token: 0x17000076 RID: 118
	// (get) Token: 0x06000AB8 RID: 2744 RVA: 0x000E5FC0 File Offset: 0x000E41C0
	// (set) Token: 0x06000AB9 RID: 2745 RVA: 0x000E5FC8 File Offset: 0x000E41C8
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

	// Token: 0x06000ABA RID: 2746 RVA: 0x000E6004 File Offset: 0x000E4204
	public LineNode createLine(MapLine mapLine, Vector3 from, Vector3 to, ELineColor color, EUnitSide unitSide, bool bEase = true, bool NeedRenderLine = true, EMonsterFace MonsterFace = EMonsterFace.LEFT, byte bLoop = 0)
	{
		CHAOS chaos = GameManager.ActiveGameplay as CHAOS;
		if (chaos == null || chaos.realmController == null || chaos.realmController.mapLineController == null)
		{
			return null;
		}
		if (chaos.realmController.mapLineController.m_Bundle == null)
		{
			chaos.realmController.mapLineController.m_Bundle = AssetManager.GetAssetBundle("Role/FlowLinePrefab", 0L);
		}
		uint num = mapLine.during;
		long begin = (long)mapLine.begin;
		if (num <= 0u)
		{
			return null;
		}
		int num2 = (int)(begin + (long)((ulong)num) - DataManager.Instance.ServerTime);
		if (num2 <= 0)
		{
			return null;
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
		float num6 = num5 / num * 2f;
		EMarchEventType emarchEventType = EMarchEventType.EMET_Camp;
		byte b = mapLine.lineFlag;
		if (b >= 23)
		{
			if (num4 >= 5f)
			{
				emarchEventType = (EMarchEventType)b;
				b = (byte)this.RetreatToReturn((EMarchEventType)b);
			}
			else if (b == 24 || b == 25)
			{
				side = ((color != ELineColor.DEEPBLUE) ? 0 : 1);
			}
		}
		LineNode lineNode = null;
		GameObject gameObject;
		if (this.workingLine != null)
		{
			gameObject = this.workingLine.gameObject;
			gameObject.SetActive(true);
			this.setupLineNode(lineNode, num5, bEase, (byte)color);
		}
		else
		{
			if (this.m_Bundle == null)
			{
				this.m_Bundle = chaos.realmController.mapLineController.m_Bundle;
			}
			gameObject = (UnityEngine.Object.Instantiate(this.m_Bundle.mainAsset) as GameObject);
			gameObject.transform.parent = this.m_Parent.transform;
			MeshFilter component = gameObject.GetComponent<MeshFilter>();
			Mesh mesh = new Mesh();
			MeshRenderer component2 = gameObject.GetComponent<MeshRenderer>();
			component2.material.renderQueue = 3001;
			component.mesh = mesh;
			lineNode = new LineNode();
			lineNode.gameObject = gameObject;
			lineNode.lineTransform = gameObject.transform;
			GameObject gameObject2 = new GameObject("movingNode");
			gameObject2.transform.parent = gameObject.transform;
			gameObject2.transform.Rotate(0f, 90f, 0f);
			lineNode.movingNode = gameObject2.transform;
			lineNode.meshFilter = component;
			lineNode.renderer = component2;
			this.setupLineNode(lineNode, num5, bEase, (byte)color);
			this.workingLine = lineNode;
		}
		float num7 = num4;
		if (b >= 23 || emarchEventType >= EMarchEventType.EMET_AttackRetreat)
		{
			num -= 5u;
			num7 -= 5f;
			num7 = ((num7 >= 0f) ? num7 : 0f);
		}
		lineNode.lineTableID = (int)mapLine.lineID;
		lineNode.timeOffset = num7;
		lineNode.inverseMaxTime = ((num <= 0u) ? 0f : (1f / num));
		float x = num5 * (lineNode.timeOffset * lineNode.inverseMaxTime) - num5 * 0.5f;
		lineNode.movingNode.localPosition = new Vector3(x, 0f, 0f);
		lineNode.speedRate = num6 / 1.75f;
		lineNode.unitSpeedRate = 1f;
		lineNode.bFocus = bLoop;
		Vector3 from2 = to - from;
		float num8 = Vector3.Angle(from2, Vector3.right);
		if (from2.y < 0f)
		{
			num8 = 360f - num8;
		}
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localPosition = from + (to - from) * 0.5f;
		gameObject.transform.rotation = Quaternion.AngleAxis(num8, Vector3.forward);
		gameObject.transform.localScale = Vector3.one;
		this.recalculateSpeed(lineNode, mapLine, true);
		if (lineNode != null && lineNode.movingNode != null)
		{
			if (lineNode.sheetUnit == null)
			{
				lineNode.sheetUnit = new SheetAnimationUnitGroupNewbie();
			}
			SheetAnimationUnitGroupNewbie sheetAnimationUnitGroupNewbie = lineNode.sheetUnit as SheetAnimationUnitGroupNewbie;
			sheetAnimationUnitGroupNewbie.transform.parent = null;
			sheetAnimationUnitGroupNewbie.transform.rotation = Quaternion.identity;
			sheetAnimationUnitGroupNewbie.transform.parent = lineNode.movingNode;
			sheetAnimationUnitGroupNewbie.transform.localPosition = Vector3.zero;
			byte b2 = 0;
			if (b == 27 && MonsterFace == EMonsterFace.RIGHT)
			{
				b2 |= 1;
			}
			sheetAnimationUnitGroupNewbie.setupAnimUnit(side, b, num8, b2);
			sheetAnimationUnitGroupNewbie.resetScale();
			lineNode.flag = b;
			lineNode.angle = num8;
			lineNode.side = side;
			lineNode.MonsterFace = MonsterFace;
			if (b >= 23)
			{
				float timer = 5f - num4;
				lineNode.renderer.enabled = false;
				lineNode.action = ELineAction.ACTION_BEFORE;
				lineNode.timer = timer;
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
		return lineNode;
	}

	// Token: 0x06000ABB RID: 2747 RVA: 0x000E657C File Offset: 0x000E477C
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

	// Token: 0x06000ABC RID: 2748 RVA: 0x000E6914 File Offset: 0x000E4B14
	public void recalculateSpeed(LineNode node, MapLine _ml, bool bResetOffset = false)
	{
		uint exduring = _ml.EXduring;
		ulong begin = _ml.begin;
		uint exbegin = _ml.EXbegin;
		uint num = _ml.during;
		if (bResetOffset)
		{
			node.timeOffset = exbegin;
		}
		float num2 = (num - exbegin) / num * node.distance;
		uint num3 = num - exduring;
		float num4 = num2 / num3;
		if (num4 >= 0.5f && num > 1u && num3 > 2u)
		{
			num -= 1u;
			num2 = (num - exbegin) / num * node.distance;
			num3 = num - exduring;
			num4 = num2 / num3;
		}
		if (_ml.lineFlag >= 23)
		{
			node.inverseMaxTime = 1f / _ml.during;
		}
		ulong serverTime = (ulong)DataManager.Instance.ServerTime;
		ulong num5 = begin + (ulong)exduring;
		long num6 = (long)(serverTime - num5);
		float num7 = exbegin / num * node.distance;
		float num8 = (num7 + (float)num6 * num4) / node.distance * num;
		float num9 = node.distance / num;
		if (node.timeOffset <= num8)
		{
			node.timeOffset = num8;
			num4 /= num9;
			node.speedRate = num4 * 0.05f + num9 / 1.75f;
			node.unitSpeedRate = num4;
		}
		else
		{
			float num10 = (1f - node.timeOffset * node.inverseMaxTime) * node.distance;
			int num11 = (int)(begin + (ulong)num - serverTime);
			num11 = Mathf.Max(0, num11);
			float num12 = num10 / (float)num11 / num9;
			node.speedRate = num12 * 0.05f + num9 / 1.75f;
			node.unitSpeedRate = num12;
		}
	}

	// Token: 0x06000ABD RID: 2749 RVA: 0x000E6AC4 File Offset: 0x000E4CC4
	public void Clear()
	{
		this.ClearLine();
		if (this.m_Parent)
		{
			UnityEngine.Object.Destroy(this.m_Parent);
		}
		SheetAnimationUnitGroupNewbie.FreeResource();
		if (this.m_Bundle)
		{
			this.m_Bundle.Unload(true);
		}
	}

	// Token: 0x06000ABE RID: 2750 RVA: 0x000E6B14 File Offset: 0x000E4D14
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
		return type;
	}

	// Token: 0x06000ABF RID: 2751 RVA: 0x000E6B5C File Offset: 0x000E4D5C
	public void MoveUnitToEndPoint(EMarchEventType type)
	{
		LineNode lineNode = this.workingLine;
		if (lineNode == null)
		{
			return;
		}
		float x = lineNode.distance - lineNode.distance * 0.5f;
		lineNode.movingNode.localPosition = new Vector3(x, 0f, 0f);
		lineNode.sheetUnit.RecoverUnit();
		lineNode.sheetUnit.setupAnimUnit(lineNode.side, (byte)type, lineNode.angle, 0);
		if (type == EMarchEventType.EMET_HitMonsterRetreat)
		{
			NewbieManager.SetupFakeMonster(1, lineNode);
		}
	}

	// Token: 0x06000AC0 RID: 2752 RVA: 0x000E6BDC File Offset: 0x000E4DDC
	public void Update(float deltaTime)
	{
		LineNode lineNode = this.workingLine;
		if (lineNode == null)
		{
			return;
		}
		if (lineNode.sheetUnit != null && lineNode.sheetUnit.Update(deltaTime) != 0)
		{
			NewbieManager.SetupFakeMonster(0, null);
		}
		if (lineNode.flag != 5 && lineNode.flag != 9)
		{
			float num = lineNode.speedRate * deltaTime;
			lineNode.curCoordU -= num;
			lineNode.maxCoordU -= num;
			lineNode.sideOffset1 -= num;
			lineNode.sideOffset2 -= num;
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
					if (lineNode.bFocus == 0)
					{
						return;
					}
					lineNode.timeOffset = 0f;
				}
				float x = lineNode.distance * (lineNode.timeOffset * lineNode.inverseMaxTime) - lineNode.distance * 0.5f;
				lineNode.movingNode.localPosition = new Vector3(x, 0f, 0f);
			}
		}
		else
		{
			float? shakingTimer = lineNode.ShakingTimer;
			if (shakingTimer != null)
			{
				float x2 = lineNode.distance - lineNode.distance * 0.5f;
				lineNode.movingNode.localPosition = new Vector3(x2, 0f, 0f);
				if (lineNode.ShakingTimer.Value <= 0f)
				{
					lineNode.ShakingTimer = null;
				}
				else
				{
					LineNode lineNode2 = lineNode;
					float? shakingTimer2 = lineNode2.ShakingTimer;
					lineNode2.ShakingTimer = ((shakingTimer2 == null) ? null : new float?(shakingTimer2.Value - deltaTime));
					float num2;
					if (lineNode.ShakingFlag == 0)
					{
						lineNode.ShakingFlag = 1;
						num2 = lineNode.ShakingTimer.Value * 0.375f;
					}
					else
					{
						lineNode.ShakingFlag = 0;
						num2 = lineNode.ShakingTimer.Value * -0.375f;
					}
					lineNode.movingNode.localPosition += new Vector3(num2, -num2, 0f);
				}
			}
		}
	}

	// Token: 0x06000AC1 RID: 2753 RVA: 0x000E6F3C File Offset: 0x000E513C
	public void ClearLine()
	{
		if (this.workingLine != null)
		{
			if (this.workingLine.sheetUnit != null)
			{
				this.workingLine.sheetUnit.RecoverUnit();
			}
			if (this.workingLine.movingNode != null && this.workingLine.movingNode.gameObject != null)
			{
				UnityEngine.Object.Destroy(this.workingLine.movingNode.gameObject);
			}
			UnityEngine.Object.Destroy(this.workingLine.gameObject);
			this.workingLine = null;
		}
	}

	// Token: 0x04002423 RID: 9251
	public const int MAX_FLOWLINE = 512;

	// Token: 0x04002424 RID: 9252
	public const float LINE_HEIGHT = 0.4f;

	// Token: 0x04002425 RID: 9253
	public const float OPAQUE_SIDE_LEN = 5f;

	// Token: 0x04002426 RID: 9254
	public const float UV_PER_UNIT = 0.25f;

	// Token: 0x04002427 RID: 9255
	public const float ATK_DISPLAY_LEN = 5f;

	// Token: 0x04002428 RID: 9256
	public LineNode workingLine;

	// Token: 0x04002429 RID: 9257
	private GameObject m_Parent;

	// Token: 0x0400242A RID: 9258
	private AssetBundle m_Bundle;

	// Token: 0x0400242B RID: 9259
	private Vector3[] m_Vertices = new Vector3[8];

	// Token: 0x0400242C RID: 9260
	private Vector2[] m_Uv = new Vector2[8];

	// Token: 0x0400242D RID: 9261
	private Color[] m_Color = new Color[8];

	// Token: 0x0400242E RID: 9262
	private readonly Vector3 MONSTER_FACELEFT_OFFSET = new Vector3(-0.621f, -0.076f, 0f);

	// Token: 0x0400242F RID: 9263
	private readonly Vector3 MONSTER_FACERIGHT_OFFSET = new Vector3(0.621f, -0.076f, 0f);

	// Token: 0x04002430 RID: 9264
	private readonly int[] m_Triangle = new int[]
	{
		0,
		1,
		6,
		7,
		6,
		1
	};

	// Token: 0x04002431 RID: 9265
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

	// Token: 0x04002432 RID: 9266
	private float m_ParentScaleBase = 1f;

	// Token: 0x04002433 RID: 9267
	private float m_ScaleRate = 1f;

	// Token: 0x04002434 RID: 9268
	private float CanvasRectTranScale = 1f;
}
