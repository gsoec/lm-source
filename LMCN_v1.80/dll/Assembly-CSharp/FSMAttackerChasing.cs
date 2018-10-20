using System;
using UnityEngine;

// Token: 0x02000729 RID: 1833
public class FSMAttackerChasing : FSMUnit
{
	// Token: 0x0600231B RID: 8987 RVA: 0x0040D698 File Offset: 0x0040B898
	public FSMAttackerChasing(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.ATTACKER_CHASING;
	}

	// Token: 0x0600231C RID: 8988 RVA: 0x0040D6B0 File Offset: 0x0040B8B0
	public override void Enter(Soldier sam)
	{
		float num = UnityEngine.Random.Range(75f, 95f);
		if (sam.transform.position.x >= num)
		{
			sam.Flag = 1;
			sam.PlayAnim(ESheetMeshAnim.victory, SAWrapMode.Loop, true, false, false);
		}
		else
		{
			float z = UnityEngine.Random.Range(5f, 25f);
			sam.SpreadPos = new Vector3(num, 0f, z);
			sam.Flag = 0;
			sam.PlayAnim(ESheetMeshAnim.moving, SAWrapMode.Loop, true, true, false);
		}
	}

	// Token: 0x0600231D RID: 8989 RVA: 0x0040D734 File Offset: 0x0040B934
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (sam.Flag == 1)
		{
			return;
		}
		if (sam.Flag == 2)
		{
			Transform transform = sam.transform;
			Vector3 vector = Camera.main.transform.position - transform.position;
			vector.y = 0f;
			if (vector != Vector3.zero)
			{
				Quaternion quaternion = Quaternion.LookRotation(vector);
				if (quaternion != transform.rotation)
				{
					transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, 5f * deltaTime);
				}
				else
				{
					sam.Flag = 1;
				}
			}
		}
		else
		{
			Transform transform2 = sam.transform;
			Vector3 vector2 = sam.SpreadPos - transform2.position;
			if (vector2 != Vector3.zero)
			{
				Quaternion quaternion2 = Quaternion.LookRotation(vector2);
				if (quaternion2 != transform2.rotation)
				{
					transform2.rotation = Quaternion.Slerp(transform2.rotation, quaternion2, 5f * deltaTime);
				}
			}
			float num = (parent != null) ? parent.MoveSpeed : 4.5f;
			FSMUnit.MoveSoldier(sam, sam.SpreadPos, num * 2.5f * deltaTime * 1.5f);
			if (GameConstants.DistanceSquare(transform2.position, sam.SpreadPos) <= 0.0001f)
			{
				sam.Flag = 2;
				sam.PlayAnim(ESheetMeshAnim.victory, SAWrapMode.Loop, true, false, false);
			}
		}
	}
}
