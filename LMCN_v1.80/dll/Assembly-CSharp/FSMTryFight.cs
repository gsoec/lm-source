using System;
using UnityEngine;

// Token: 0x02000716 RID: 1814
public class FSMTryFight : FSMUnit
{
	// Token: 0x060022E2 RID: 8930 RVA: 0x0040BB3C File Offset: 0x00409D3C
	public FSMTryFight(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.TRYFIGHT;
	}

	// Token: 0x060022E3 RID: 8931 RVA: 0x0040BB54 File Offset: 0x00409D54
	public override void Enter(Soldier sam)
	{
		if (sam.Parent.Target.GroupKind == EGroupKind.CastleGate)
		{
			bool flag = sam.Parent.GroupKind == EGroupKind.Infantry || sam.Parent.GroupKind == EGroupKind.Cavalry;
			if (flag)
			{
				sam.SpreadMode = ESpreadMode.NotSpread;
				sam.FSMController = FSMManager.Instance.getState(EStateName.SPREAD);
			}
			else
			{
				if (sam.Parent.GroupKind == EGroupKind.Archer && sam.SpreadMode == ESpreadMode.Enable)
				{
					Vector3 position = sam.transform.position;
					float x = UnityEngine.Random.Range(position.x - 5f, position.x + 5f);
					float z = UnityEngine.Random.Range(position.z - 5f, position.z + 5f);
					sam.SpreadPos = new Vector3(x, 0f, z);
				}
				sam.FSMController = FSMManager.Instance.getState(EStateName.RANGE_FIGHT_WALL);
			}
		}
		else
		{
			if (sam.Target != null && sam.Target.Parent != sam.Parent.Target)
			{
				sam.Target = null;
			}
			if (sam.Target == null)
			{
				sam.Target = FSMUnit.ReallocTarget(sam, sam.Parent.Target);
			}
			bool flag2 = sam.Parent.GroupKind == EGroupKind.Infantry || sam.Parent.GroupKind == EGroupKind.Cavalry;
			if (flag2)
			{
				int num = (int)sam.Index / sam.Parent.RowCount;
				if (num != 0 && sam.SpreadMode == ESpreadMode.Enable)
				{
					sam.SpreadMode = ESpreadMode.NotSpread;
					sam.FSMController = FSMManager.Instance.getState(EStateName.SPREAD);
				}
				else
				{
					sam.ActionMode = EActionMode.Personal;
					sam.PlayAnim(ESheetMeshAnim.moving, SAWrapMode.Loop, true, false, false);
				}
			}
			else
			{
				if (sam.Parent.GroupKind == EGroupKind.Archer && !this.pManager.bIsSiegeMode && sam.SpreadMode == ESpreadMode.Enable)
				{
					Vector3 position2 = sam.transform.position;
					float x2 = UnityEngine.Random.Range(position2.x - 5f, position2.x + 5f);
					float z2 = UnityEngine.Random.Range(position2.z - 5f, position2.z + 5f);
					sam.SpreadPos = new Vector3(x2, 0f, z2);
				}
				sam.FSMController = FSMManager.Instance.getState(EStateName.RANGE_FIGHT);
			}
		}
	}

	// Token: 0x060022E4 RID: 8932 RVA: 0x0040BDD4 File Offset: 0x00409FD4
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (sam.Target == null || sam.Target.FSMController == null || sam.Target.CurFSM == EStateName.DIE || sam.Target.CurFSM == EStateName.DYING)
		{
			sam.FSMController = FSMManager.Instance.getState(EStateName.LOSETARGET);
		}
		Transform transform = sam.Target.transform;
		Transform transform2 = sam.transform;
		FSMUnit.CheckDirectionToTarget(sam, deltaTime);
		FSMUnit.MoveSoldier(sam, transform.position, parent.MoveSpeed * 1.3f * deltaTime);
		float num = sam.AttackRadius + sam.Target.Radius;
		if (GameConstants.DistanceSquare(transform2.position, transform.position) < num * num)
		{
			sam.FSMController = FSMManager.Instance.getState(EStateName.MELEE_FIGHT);
		}
	}
}
