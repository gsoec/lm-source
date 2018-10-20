using System;
using UnityEngine;

// Token: 0x02000710 RID: 1808
public class FSMIdle : FSMUnit
{
	// Token: 0x060022D0 RID: 8912 RVA: 0x0040B44C File Offset: 0x0040964C
	public FSMIdle(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.IDLE;
	}

	// Token: 0x060022D1 RID: 8913 RVA: 0x0040B464 File Offset: 0x00409664
	public override void Enter(Soldier sam)
	{
		if (sam.ActionMode == EActionMode.Team)
		{
			sam.PlayAnim(ESheetMeshAnim.idle, SAWrapMode.Loop, true, false, false);
		}
		else
		{
			sam.PlayAnim(ESheetMeshAnim.moving, SAWrapMode.Loop, true, false, false);
		}
	}

	// Token: 0x060022D2 RID: 8914 RVA: 0x0040B49C File Offset: 0x0040969C
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (sam.ActionMode == EActionMode.Personal)
		{
			Transform transform = sam.transform;
			Vector3 transformPoint = parent.getTransformPoint((int)sam.Index);
			Vector3 vector = transformPoint - transform.position;
			if (vector != Vector3.zero)
			{
				Quaternion to = Quaternion.LookRotation(vector);
				transform.rotation = Quaternion.Slerp(transform.rotation, to, 5f * deltaTime);
			}
			FSMUnit.MoveSoldier(sam, transformPoint, parent.MoveSpeed * 1.3f * deltaTime);
			if (GameConstants.DistanceSquare(transform.position, transformPoint) <= 0.0001f)
			{
				sam.ActionMode = EActionMode.Team;
				sam.PlayAnim(ESheetMeshAnim.idle, SAWrapMode.Loop, true, false, false);
				sam.NotifyingParent(0);
			}
		}
		else if (sam.transform.rotation != parent.groupRoot.rotation)
		{
			sam.transform.rotation = Quaternion.Slerp(sam.transform.rotation, parent.groupRoot.rotation, 5f * deltaTime);
		}
	}
}
