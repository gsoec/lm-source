using System;
using UnityEngine;

// Token: 0x0200071F RID: 1823
public class FSMDie : FSMUnit
{
	// Token: 0x060022FD RID: 8957 RVA: 0x0040CACC File Offset: 0x0040ACCC
	public FSMDie(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.DIE;
	}

	// Token: 0x060022FE RID: 8958 RVA: 0x0040CAE4 File Offset: 0x0040ACE4
	public override void Enter(Soldier sam)
	{
		sam.DyingValue = 0f;
	}

	// Token: 0x060022FF RID: 8959 RVA: 0x0040CAF4 File Offset: 0x0040ACF4
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (sam.DyingValue > -0.1f)
		{
			sam.DyingValue += deltaTime;
		}
		if (sam.DyingValue >= 20f)
		{
			sam.DyingValue = -10f;
		}
		else if (sam.DyingValue < 0f)
		{
			Transform transform = sam.transform;
			Vector3 position = transform.position;
			position.y -= 1f * deltaTime;
			transform.position = position;
			if (position.y <= -2f)
			{
				parent.SoldierCount--;
				parent.soldiers[parent.SoldierCount].transform.gameObject.SetActive(false);
				if (parent.SoldierCount <= 0)
				{
					parent.BeforeDeadDisable();
				}
			}
		}
	}
}
