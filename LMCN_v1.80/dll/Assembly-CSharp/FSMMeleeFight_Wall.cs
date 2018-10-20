using System;
using UnityEngine;

// Token: 0x02000718 RID: 1816
public class FSMMeleeFight_Wall : FSMUnit
{
	// Token: 0x060022E8 RID: 8936 RVA: 0x0040C144 File Offset: 0x0040A344
	public FSMMeleeFight_Wall(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.MELEE_FIGHT_WALL;
	}

	// Token: 0x060022E9 RID: 8937 RVA: 0x0040C15C File Offset: 0x0040A35C
	public override void Enter(Soldier sam)
	{
		sam.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Default, true, false, false);
		sam.fightTimer = 1.5f;
		Vector3 a = new Vector3(52f, 0f, sam.transform.position.z);
		Vector3 vector = a - sam.transform.position;
		if (vector != Vector3.zero)
		{
			sam.transform.rotation = Quaternion.LookRotation(vector);
		}
	}

	// Token: 0x060022EA RID: 8938 RVA: 0x0040C1D8 File Offset: 0x0040A3D8
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (sam.fightTimer > 0f)
		{
			sam.fightTimer -= deltaTime;
			if (sam.fightTimer <= 0f)
			{
				sam.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Default, true, false, false);
				sam.fightTimer = 1.5f;
			}
		}
		if (sam.CurAnim == ESheetMeshAnim.attack && sam.LastAnimTime() < 0.1f && sam.CurAnimTime() >= 0.1f)
		{
			Vector3 position = new Vector3(51f, 2f, sam.transform.position.z);
			parent.particleManager.Spawn(2001, null, position, 1f, true, false);
		}
	}
}
