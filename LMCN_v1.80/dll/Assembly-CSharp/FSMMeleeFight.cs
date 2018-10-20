using System;
using UnityEngine;

// Token: 0x02000717 RID: 1815
public class FSMMeleeFight : FSMUnit
{
	// Token: 0x060022E5 RID: 8933 RVA: 0x0040BEA4 File Offset: 0x0040A0A4
	public FSMMeleeFight(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.MELEE_FIGHT;
	}

	// Token: 0x060022E6 RID: 8934 RVA: 0x0040BEBC File Offset: 0x0040A0BC
	public override void Enter(Soldier sam)
	{
		sam.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Default, true, false, false);
		sam.fightTimer = ((!sam.IsHeroSoldier) ? 1.5f : 3f);
		Transform transform = sam.Target.transform;
		Vector3 vector = transform.position - sam.transform.position;
		if (vector != Vector3.zero)
		{
			sam.transform.rotation = Quaternion.LookRotation(vector);
		}
		sam.LastTargetPos = transform.position;
	}

	// Token: 0x060022E7 RID: 8935 RVA: 0x0040BF48 File Offset: 0x0040A148
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (parent.Target != null && parent.Target.GroupKind == EGroupKind.CastleGate)
		{
			return;
		}
		if (sam.Target == null)
		{
			sam.FSMController = FSMManager.Instance.getState(EStateName.LOSETARGET);
		}
		if (sam.fightTimer > 0f)
		{
			sam.fightTimer -= deltaTime;
			if (sam.fightTimer <= 0f)
			{
				sam.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Default, true, false, false);
				sam.fightTimer = ((!sam.IsHeroSoldier) ? 1.5f : 3f);
			}
		}
		Transform transform = sam.Target.transform;
		Transform transform2 = sam.transform;
		if (parent.Target.CurHP <= 0)
		{
			sam.FSMController = FSMManager.Instance.getState(EStateName.IDLE);
		}
		else if (sam.Target.CurFSM == EStateName.DIE)
		{
			sam.ResetTarget(false);
			sam.FSMController = FSMManager.Instance.getState(EStateName.TRYFIGHT);
		}
		else if (GameConstants.DistanceSquare(sam.LastTargetPos, transform.position) <= 0.0001f)
		{
			FSMUnit.CheckDirectionToTarget(sam, deltaTime);
			if (sam.CurAnim == ESheetMeshAnim.attack && sam.LastAnimTime() < 0.1f && sam.CurAnimTime() >= 0.1f)
			{
				ushort num = 1;
				if (parent.GroupKind == EGroupKind.Catapults)
				{
					num = 2006;
				}
				if (parent.GroupKind == EGroupKind.Archer && parent.Tier == 4)
				{
					num = 2005;
				}
				sam.Target.ParticleFlag = ((num <= sam.Target.ParticleFlag) ? sam.Target.ParticleFlag : num);
			}
		}
		else
		{
			float num2 = sam.AttackRadius + sam.Target.Radius;
			if (GameConstants.DistanceSquare(transform2.position, transform.position) > num2 * num2)
			{
				sam.FSMController = FSMManager.Instance.getState(EStateName.TRYFIGHT);
			}
		}
	}
}
