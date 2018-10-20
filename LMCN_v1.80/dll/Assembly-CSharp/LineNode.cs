using System;
using UnityEngine;

// Token: 0x0200024F RID: 591
public class LineNode
{
	// Token: 0x06000A4D RID: 2637 RVA: 0x000DE650 File Offset: 0x000DC850
	public void Shake()
	{
		this.ShakingTimer = new float?(0.2f);
		this.ShakingFlag = 0;
	}

	// Token: 0x06000A4E RID: 2638 RVA: 0x000DE674 File Offset: 0x000DC874
	public void ResetValue()
	{
		this.inverseMaxTime = 0f;
		this.timeOffset = 0f;
		this.speedRate = 1f;
		this.unitSpeedRate = 1f;
		this.action = ELineAction.NORMAL;
		this.timer = 0f;
		this.side = 0;
		this.flag = 0;
		this.bFocus = 0;
		this.angle = 0f;
		this.lineTableID = 1048576;
		this.MonsterFace = EMonsterFace.LEFT;
		this.ShakingTimer = null;
		this.ShakingFlag = 0;
		this.AutoDelete = 0;
		this.IsPetSkillLine = false;
		this.IsSoccerRunningLine = false;
		this.inverseTransferTime = 0f;
		this.touchDownDistance = 0f;
		this.FriendLineID = 1048576;
		this.StartPoint = default(PointCode);
		this.EndPoint = default(PointCode);
		this.RuntimeFlag = 0;
		this.FakeLineDir = 0;
		this.actionStartTime = null;
	}

	// Token: 0x0400239E RID: 9118
	public GameObject gameObject;

	// Token: 0x0400239F RID: 9119
	public Transform movingNode;

	// Token: 0x040023A0 RID: 9120
	public MeshFilter meshFilter;

	// Token: 0x040023A1 RID: 9121
	public MeshRenderer renderer;

	// Token: 0x040023A2 RID: 9122
	public float inverseMaxTime;

	// Token: 0x040023A3 RID: 9123
	public float timeOffset;

	// Token: 0x040023A4 RID: 9124
	public float distance;

	// Token: 0x040023A5 RID: 9125
	public float speedRate = 1f;

	// Token: 0x040023A6 RID: 9126
	public float unitSpeedRate = 1f;

	// Token: 0x040023A7 RID: 9127
	public float curCoordU;

	// Token: 0x040023A8 RID: 9128
	public float maxCoordU;

	// Token: 0x040023A9 RID: 9129
	public float sideLen;

	// Token: 0x040023AA RID: 9130
	public float sideOffset1;

	// Token: 0x040023AB RID: 9131
	public float sideOffset2;

	// Token: 0x040023AC RID: 9132
	public byte colorIndex;

	// Token: 0x040023AD RID: 9133
	public ISheetAnimationUnitGroup sheetUnit;

	// Token: 0x040023AE RID: 9134
	public ELineAction action;

	// Token: 0x040023AF RID: 9135
	public float timer;

	// Token: 0x040023B0 RID: 9136
	public byte side;

	// Token: 0x040023B1 RID: 9137
	public byte flag;

	// Token: 0x040023B2 RID: 9138
	public byte bFocus;

	// Token: 0x040023B3 RID: 9139
	public float angle;

	// Token: 0x040023B4 RID: 9140
	public Transform lineTransform;

	// Token: 0x040023B5 RID: 9141
	public int lineTableID = 1048576;

	// Token: 0x040023B6 RID: 9142
	public MapTileName NodeName;

	// Token: 0x040023B7 RID: 9143
	public EMonsterFace MonsterFace;

	// Token: 0x040023B8 RID: 9144
	public float? ShakingTimer;

	// Token: 0x040023B9 RID: 9145
	public byte ShakingFlag;

	// Token: 0x040023BA RID: 9146
	public byte AutoDelete;

	// Token: 0x040023BB RID: 9147
	public bool IsPetSkillLine;

	// Token: 0x040023BC RID: 9148
	public bool IsSoccerRunningLine;

	// Token: 0x040023BD RID: 9149
	public float inverseTransferTime;

	// Token: 0x040023BE RID: 9150
	public float touchDownDistance;

	// Token: 0x040023BF RID: 9151
	public int FriendLineID = 1048576;

	// Token: 0x040023C0 RID: 9152
	public PointCode StartPoint = default(PointCode);

	// Token: 0x040023C1 RID: 9153
	public PointCode EndPoint = default(PointCode);

	// Token: 0x040023C2 RID: 9154
	public byte RuntimeFlag;

	// Token: 0x040023C3 RID: 9155
	public byte FakeLineDir;

	// Token: 0x040023C4 RID: 9156
	public double? actionStartTime;

	// Token: 0x040023C5 RID: 9157
	public ELineNodeState NodeState = ELineNodeState.FREE;

	// Token: 0x040023C6 RID: 9158
	public LineNode Previous;

	// Token: 0x040023C7 RID: 9159
	public LineNode Next;
}
