using System;

// Token: 0x0200071A RID: 1818
public class FSMRangeFight : FSMUnit
{
	// Token: 0x060022EE RID: 8942 RVA: 0x0040C2C0 File Offset: 0x0040A4C0
	public FSMRangeFight(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.RANGE_FIGHT;
	}

	// Token: 0x060022EF RID: 8943 RVA: 0x0040C2D8 File Offset: 0x0040A4D8
	public override void Enter(Soldier sam)
	{
		sam.PlayAnim(ESheetMeshAnim.idle, SAWrapMode.Loop, true, false, false);
	}

	// Token: 0x060022F0 RID: 8944 RVA: 0x0040C2E8 File Offset: 0x0040A4E8
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (!FSMUnit.CheckTargetActiving(sam))
		{
			sam.Target = FSMUnit.ReallocTarget(sam, parent.Target);
		}
		FSMUnit.CheckDirectionToTarget(sam, deltaTime);
		if ((parent.OnceFlag & 1u) != 0u)
		{
			if (sam.Target.CurFSM == EStateName.DYING || sam.Target.CurFSM == EStateName.DIE)
			{
				sam.Target = null;
				sam.Target = FSMUnit.ReallocTarget(sam, parent.Target);
			}
			sam.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Default, false, false, false);
		}
	}
}
