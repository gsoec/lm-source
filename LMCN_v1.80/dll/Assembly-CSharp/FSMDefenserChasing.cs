using System;
using UnityEngine;

// Token: 0x02000727 RID: 1831
public class FSMDefenserChasing : FSMUnit
{
	// Token: 0x06002315 RID: 8981 RVA: 0x0040D4F0 File Offset: 0x0040B6F0
	public FSMDefenserChasing(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.DEFENSER_CHASING;
	}

	// Token: 0x06002316 RID: 8982 RVA: 0x0040D508 File Offset: 0x0040B708
	public override void Enter(Soldier sam)
	{
		Vector3 position = sam.transform.position;
		position.x = -500f;
		sam.SpreadPos = position;
		sam.Timer = 2f;
		sam.Flag = 0;
		sam.PlayAnim(ESheetMeshAnim.idle, SAWrapMode.Loop, true, false, false);
	}

	// Token: 0x06002317 RID: 8983 RVA: 0x0040D554 File Offset: 0x0040B754
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (sam.Flag == 0)
		{
			sam.Timer -= deltaTime;
			if (sam.Timer <= 0f)
			{
				sam.PlayAnim(ESheetMeshAnim.victory, SAWrapMode.Loop, true, false, false);
				sam.Flag = 1;
			}
		}
	}
}
