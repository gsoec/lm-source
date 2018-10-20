using System;
using UnityEngine;

// Token: 0x02000728 RID: 1832
public class FSMDefenserRunAway : FSMUnit
{
	// Token: 0x06002318 RID: 8984 RVA: 0x0040D5A4 File Offset: 0x0040B7A4
	public FSMDefenserRunAway(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.DEFENSER_RUN_AWAY;
	}

	// Token: 0x06002319 RID: 8985 RVA: 0x0040D5BC File Offset: 0x0040B7BC
	public override void Enter(Soldier sam)
	{
		Vector3 position = sam.transform.position;
		position.x = 500f;
		sam.SpreadPos = position;
		sam.PlayAnim(ESheetMeshAnim.moving, SAWrapMode.Loop, true, true, false);
		sam.RunAnimSpeedUp();
	}

	// Token: 0x0600231A RID: 8986 RVA: 0x0040D5FC File Offset: 0x0040B7FC
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
		FSMUnit.MoveSoldier(sam, sam.SpreadPos, num * 2.5f * deltaTime * 1.5f);
	}
}
