using System;
using UnityEngine;

// Token: 0x02000722 RID: 1826
public class FSMMoveOutOfTown : FSMUnit
{
	// Token: 0x06002306 RID: 8966 RVA: 0x0040CD68 File Offset: 0x0040AF68
	public FSMMoveOutOfTown(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.MOVE_OUTOF_TOWN;
	}

	// Token: 0x06002307 RID: 8967 RVA: 0x0040CD80 File Offset: 0x0040AF80
	public override void Enter(Soldier sam)
	{
		sam.PlayAnim(ESheetMeshAnim.moving, SAWrapMode.Loop, true, false, false);
		sam.ActionMode = EActionMode.Personal;
		sam.Flag = 0;
		sam.Timer = UnityEngine.Random.Range(0f, 0.5f);
	}

	// Token: 0x06002308 RID: 8968 RVA: 0x0040CDB4 File Offset: 0x0040AFB4
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (sam.Flag == 0)
		{
			sam.Timer -= deltaTime;
			if (sam.Timer > 0f)
			{
				return;
			}
			sam.Flag = 1;
			sam.PlayAnim(ESheetMeshAnim.moving, SAWrapMode.Loop, false, false, false);
		}
		Vector3 vector = Vector3.zero;
		Transform transform = sam.transform;
		if (sam.Flag == 1)
		{
			vector = FSMUnit.WALL_BACK;
		}
		else
		{
			if (sam.Flag != 2)
			{
				sam.Flag = 0;
				if (FSMManager.Instance.bIsBattleOver && DataManager.Instance.War_LordCapture != 0)
				{
					sam.FSMController = FSMManager.Instance.getState(EStateName.GO_CAPTIVING);
				}
				else
				{
					sam.FSMController = FSMManager.Instance.getState(EStateName.IDLE_FASTRUN);
				}
				return;
			}
			vector = FSMUnit.WALL_FRONT;
		}
		Vector3 vector2 = vector - transform.position;
		if (vector2 != Vector3.zero)
		{
			Quaternion quaternion = Quaternion.LookRotation(vector2);
			if (transform.rotation != quaternion)
			{
				transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, 5f * deltaTime);
			}
		}
		FSMUnit.MoveSoldier(sam, vector, parent.MoveSpeed * deltaTime * 2.5f);
		if (GameConstants.DistanceSquare(transform.position, vector) <= 0.0001f)
		{
			sam.Flag += 1;
		}
	}
}
