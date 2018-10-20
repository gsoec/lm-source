using System;
using UnityEngine;

// Token: 0x02000721 RID: 1825
public class FSMVictory : FSMUnit
{
	// Token: 0x06002303 RID: 8963 RVA: 0x0040CC98 File Offset: 0x0040AE98
	public FSMVictory(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.VICTORY;
	}

	// Token: 0x06002304 RID: 8964 RVA: 0x0040CCB0 File Offset: 0x0040AEB0
	public override void Enter(Soldier sam)
	{
		sam.PlayAnim(ESheetMeshAnim.victory, SAWrapMode.Loop, true, false, false);
		Vector3 position = Camera.main.transform.position;
		sam.SpreadPos = new Vector3(position.x, 0f, position.z) - sam.transform.position;
	}

	// Token: 0x06002305 RID: 8965 RVA: 0x0040CD08 File Offset: 0x0040AF08
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (sam.SpreadPos != Vector3.zero)
		{
			Transform transform = sam.transform;
			Quaternion quaternion = Quaternion.LookRotation(sam.SpreadPos);
			if (transform.rotation != quaternion)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, 5f * deltaTime);
			}
		}
	}
}
