using System;
using UnityEngine;

// Token: 0x02000711 RID: 1809
public class FSMIdle_FastRun : FSMUnit
{
	// Token: 0x060022D3 RID: 8915 RVA: 0x0040B5A0 File Offset: 0x004097A0
	public FSMIdle_FastRun(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.IDLE_FASTRUN;
	}

	// Token: 0x060022D4 RID: 8916 RVA: 0x0040B5B8 File Offset: 0x004097B8
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

	// Token: 0x060022D5 RID: 8917 RVA: 0x0040B5F0 File Offset: 0x004097F0
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
			FSMUnit.MoveSoldier(sam, transformPoint, parent.MoveSpeed * 2.5f * deltaTime);
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
