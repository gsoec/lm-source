using System;
using UnityEngine;

// Token: 0x02000715 RID: 1813
public class FSMMoveToTarget : FSMUnit
{
	// Token: 0x060022DF RID: 8927 RVA: 0x0040BA20 File Offset: 0x00409C20
	public FSMMoveToTarget(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.MOVETO_TARGET;
	}

	// Token: 0x060022E0 RID: 8928 RVA: 0x0040BA38 File Offset: 0x00409C38
	public override void Enter(Soldier sam)
	{
		float x = 52f - sam.AttackRadius;
		Vector3 position = sam.Parent.Target.groupRoot.position;
		sam.SpreadPos = new Vector3(x, 0f, sam.transform.position.z);
	}

	// Token: 0x060022E1 RID: 8929 RVA: 0x0040BA8C File Offset: 0x00409C8C
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
			sam.FSMController = FSMManager.Instance.getState(EStateName.MELEE_FIGHT_WALL);
		}
	}
}
