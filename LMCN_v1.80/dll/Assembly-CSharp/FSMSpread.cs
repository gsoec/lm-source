using System;
using UnityEngine;

// Token: 0x02000714 RID: 1812
public class FSMSpread : FSMUnit
{
	// Token: 0x060022DC RID: 8924 RVA: 0x0040B8A8 File Offset: 0x00409AA8
	public FSMSpread(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.SPREAD;
	}

	// Token: 0x060022DD RID: 8925 RVA: 0x0040B8C0 File Offset: 0x00409AC0
	public override void Enter(Soldier sam)
	{
		sam.ActionMode = EActionMode.Personal;
		sam.PlayAnim(ESheetMeshAnim.moving, SAWrapMode.Loop, true, false, false);
		if (GameConstants.DistanceSquare(sam.SpreadPos, Vector3.zero) <= 0.0001f)
		{
			Vector3 position = sam.transform.position;
			Vector3 position2 = new Vector3(UnityEngine.Random.Range(-5f, 5f), 0f, UnityEngine.Random.Range(0f, 5f));
			sam.SpreadPos = sam.transform.TransformPoint(position2);
		}
	}

	// Token: 0x060022DE RID: 8926 RVA: 0x0040B944 File Offset: 0x00409B44
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		Transform transform = sam.transform;
		Vector3 vector = sam.SpreadPos - transform.position;
		if (vector != Vector3.zero)
		{
			Quaternion quaternion = Quaternion.LookRotation(vector);
			if (transform.rotation != quaternion)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, 5f * deltaTime);
			}
		}
		FSMUnit.MoveSoldier(sam, sam.SpreadPos, parent.MoveSpeed * 1.3f * deltaTime);
		if (GameConstants.DistanceSquare(transform.position, sam.SpreadPos) <= 0.0001f)
		{
			if (sam.Parent.Target.GroupKind == EGroupKind.CastleGate)
			{
				sam.FSMController = FSMManager.Instance.getState(EStateName.MOVETO_TARGET);
			}
			else
			{
				sam.FSMController = FSMManager.Instance.getState(EStateName.TRYFIGHT);
			}
		}
	}
}
