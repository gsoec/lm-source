using System;
using UnityEngine;

// Token: 0x0200071C RID: 1820
public class FSMArcherSpread : FSMUnit
{
	// Token: 0x060022F4 RID: 8948 RVA: 0x0040C414 File Offset: 0x0040A614
	public FSMArcherSpread(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.ARCHER_SPREAD;
	}

	// Token: 0x060022F5 RID: 8949 RVA: 0x0040C42C File Offset: 0x0040A62C
	public override void Enter(Soldier sam)
	{
		sam.ActionMode = EActionMode.Personal;
		sam.PlayAnim(ESheetMeshAnim.moving, SAWrapMode.Loop, true, false, false);
	}

	// Token: 0x060022F6 RID: 8950 RVA: 0x0040C444 File Offset: 0x0040A644
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
			sam.SpreadPos = Vector3.zero;
			sam.SpreadMode = ESpreadMode.NotSpread;
			if (sam.Parent.Target.GroupKind == EGroupKind.CastleGate)
			{
				sam.FSMController = FSMManager.Instance.getState(EStateName.RANGE_FIGHT_WALL);
			}
			else
			{
				sam.FSMController = FSMManager.Instance.getState(EStateName.RANGE_FIGHT);
			}
		}
	}
}
