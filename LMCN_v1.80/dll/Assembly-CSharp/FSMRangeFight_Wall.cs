using System;
using UnityEngine;

// Token: 0x0200071B RID: 1819
public class FSMRangeFight_Wall : FSMUnit
{
	// Token: 0x060022F1 RID: 8945 RVA: 0x0040C370 File Offset: 0x0040A570
	public FSMRangeFight_Wall(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.RANGE_FIGHT_WALL;
	}

	// Token: 0x060022F2 RID: 8946 RVA: 0x0040C388 File Offset: 0x0040A588
	public override void Enter(Soldier sam)
	{
		sam.PlayAnim(ESheetMeshAnim.idle, SAWrapMode.Loop, true, false, false);
		Vector3 a = new Vector3(52f, 0f, sam.transform.position.z);
		Vector3 vector = a - sam.transform.position;
		if (vector != Vector3.zero)
		{
			sam.transform.rotation = Quaternion.LookRotation(vector);
		}
	}

	// Token: 0x060022F3 RID: 8947 RVA: 0x0040C3F8 File Offset: 0x0040A5F8
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if ((parent.OnceFlag & 1u) != 0u)
		{
			sam.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Default, false, false, false);
		}
	}
}
