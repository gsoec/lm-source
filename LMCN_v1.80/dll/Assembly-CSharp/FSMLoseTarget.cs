using System;
using UnityEngine;

// Token: 0x02000724 RID: 1828
public class FSMLoseTarget : FSMUnit
{
	// Token: 0x0600230C RID: 8972 RVA: 0x0040D0AC File Offset: 0x0040B2AC
	public FSMLoseTarget(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.LOSETARGET;
	}

	// Token: 0x0600230D RID: 8973 RVA: 0x0040D0C4 File Offset: 0x0040B2C4
	public override void Enter(Soldier sam)
	{
		if (sam.Target != null && sam.Target.Parent.CurrentSoldierCount <= 0)
		{
			sam.FSMController = FSMManager.Instance.getState(EStateName.IDLE);
		}
		else
		{
			switch (sam.Parent.State)
			{
			case ArmyGroup.EGROUPSTATE.MOVING:
				sam.FSMController = FSMManager.Instance.getState(EStateName.MOVING);
				break;
			case ArmyGroup.EGROUPSTATE.IDLE:
				sam.FSMController = FSMManager.Instance.getState(EStateName.IDLE);
				break;
			case ArmyGroup.EGROUPSTATE.FIGHT:
			case ArmyGroup.EGROUPSTATE.FIGHT_IMMEDIATE:
				sam.FSMController = FSMManager.Instance.getState(EStateName.TRYFIGHT);
				break;
			default:
				Debug.LogError("Lose Target Bug");
				break;
			}
		}
	}

	// Token: 0x0600230E RID: 8974 RVA: 0x0040D184 File Offset: 0x0040B384
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
	}
}
