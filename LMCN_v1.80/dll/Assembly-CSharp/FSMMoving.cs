using System;
using UnityEngine;

// Token: 0x02000713 RID: 1811
public class FSMMoving : FSMUnit
{
	// Token: 0x060022D9 RID: 8921 RVA: 0x0040B748 File Offset: 0x00409948
	public FSMMoving(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.MOVING;
	}

	// Token: 0x060022DA RID: 8922 RVA: 0x0040B760 File Offset: 0x00409960
	public override void Enter(Soldier sam)
	{
		sam.Timer = UnityEngine.Random.Range(0f, 0.5f);
		sam.Flag = 1;
	}

	// Token: 0x060022DB RID: 8923 RVA: 0x0040B780 File Offset: 0x00409980
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (sam.Flag != 0)
		{
			sam.Timer -= deltaTime;
			if (sam.Timer > 0f)
			{
				return;
			}
			sam.Flag = 0;
			sam.PlayAnim(ESheetMeshAnim.moving, SAWrapMode.Loop, false, false, false);
		}
		Vector3 transformPoint = parent.getTransformPoint((int)sam.Index);
		Transform transform = sam.transform;
		if (sam.ActionMode == EActionMode.Team)
		{
			transform.position = transformPoint;
			if (transform.rotation != parent.m_Direction)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, parent.m_Direction, 5f * deltaTime);
			}
		}
		else
		{
			Vector3 vector = transformPoint - transform.position;
			if (vector != Vector3.zero)
			{
				Quaternion quaternion = Quaternion.LookRotation(vector);
				if (transform.rotation != quaternion)
				{
					transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, 5f * deltaTime);
				}
			}
			FSMUnit.MoveSoldier(sam, transformPoint, parent.MoveSpeed * deltaTime);
			if (GameConstants.DistanceSquare(transform.position, transformPoint) <= 0.0001f)
			{
				sam.ActionMode = EActionMode.Team;
			}
		}
	}
}
