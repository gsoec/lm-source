using System;
using UnityEngine;

// Token: 0x0200072A RID: 1834
public class FSMKickBack : FSMUnit
{
	// Token: 0x0600231E RID: 8990 RVA: 0x0040D89C File Offset: 0x0040BA9C
	public FSMKickBack(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.KICKBACK;
	}

	// Token: 0x0600231F RID: 8991 RVA: 0x0040D8B4 File Offset: 0x0040BAB4
	public override void Enter(Soldier sam)
	{
		sam.LastTargetPos = sam.transform.position;
		sam.Timer = 0f;
		sam.Flag = 1;
	}

	// Token: 0x06002320 RID: 8992 RVA: 0x0040D8DC File Offset: 0x0040BADC
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		Vector3 center = (sam.LastTargetPos + sam.SpreadPos) * 0.5f;
		center.y = 10f;
		sam.transform.position = GameConstants.QuadraticBezierCurves(sam.LastTargetPos, center, sam.SpreadPos, 2f, sam.Timer);
		sam.Timer += deltaTime;
		if (sam.Timer >= 0.5f)
		{
			sam.Flag = 0;
			EStateName name = ArmyGroup.m_FSMMap[sam.Parent.State];
			sam.FSMController = FSMManager.Instance.getState(name);
		}
	}
}
