using System;
using UnityEngine;

// Token: 0x02000720 RID: 1824
public class FSMLordDie : FSMUnit
{
	// Token: 0x06002300 RID: 8960 RVA: 0x0040CBC8 File Offset: 0x0040ADC8
	public FSMLordDie(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.DIE;
	}

	// Token: 0x06002301 RID: 8961 RVA: 0x0040CBE0 File Offset: 0x0040ADE0
	public override void Enter(Soldier sam)
	{
		sam.DyingValue = 0f;
	}

	// Token: 0x06002302 RID: 8962 RVA: 0x0040CBF0 File Offset: 0x0040ADF0
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
				parent.heroSoldier.gameObject.SetActive(false);
			}
		}
	}
}
