using System;
using UnityEngine;

// Token: 0x02000726 RID: 1830
public class FSMAttackerRunAway : FSMUnit
{
	// Token: 0x06002312 RID: 8978 RVA: 0x0040D404 File Offset: 0x0040B604
	public FSMAttackerRunAway(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.ATTACKER_RUN_AWAY;
	}

	// Token: 0x06002313 RID: 8979 RVA: 0x0040D41C File Offset: 0x0040B61C
	public override void Enter(Soldier sam)
	{
		Vector3 position = sam.transform.position;
		position.x = -500f;
		sam.SpreadPos = position;
		sam.PlayAnim(ESheetMeshAnim.moving, SAWrapMode.Loop, true, true, false);
		sam.RunAnimSpeedUp();
	}

	// Token: 0x06002314 RID: 8980 RVA: 0x0040D45C File Offset: 0x0040B65C
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		Transform transform = sam.transform;
		Vector3 vector = sam.SpreadPos - transform.position;
		if (vector != Vector3.zero)
		{
			Quaternion quaternion = Quaternion.LookRotation(vector);
			if (quaternion != transform.rotation)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, 5f * deltaTime);
			}
		}
		float num = (parent != null) ? parent.MoveSpeed : 4.5f;
		FSMUnit.MoveSoldier(sam, sam.SpreadPos, num * 2.5f * deltaTime);
	}
}
