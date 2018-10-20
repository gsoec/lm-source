using System;
using UnityEngine;

// Token: 0x02000723 RID: 1827
public class FSMJumpFromWall : FSMUnit
{
	// Token: 0x06002309 RID: 8969 RVA: 0x0040CF14 File Offset: 0x0040B114
	public FSMJumpFromWall(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.JUMP_FROM_WALL;
	}

	// Token: 0x0600230A RID: 8970 RVA: 0x0040CF2C File Offset: 0x0040B12C
	public override void Enter(Soldier sam)
	{
		sam.ActionMode = EActionMode.Personal;
		sam.SpreadPos = sam.transform.position;
		sam.LastTargetPos = sam.transform.position + FSMUnit.JUMP_FROM_WALL_END_OFFSET;
		sam.LastTargetPos.y = 0f;
		sam.Flag = 1;
		sam.Timer = UnityEngine.Random.Range(0f, 0.5f);
		sam.EnableShadow = false;
	}

	// Token: 0x0600230B RID: 8971 RVA: 0x0040CFA0 File Offset: 0x0040B1A0
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (sam.Flag != 0)
		{
			sam.Timer -= deltaTime;
			if (sam.Timer > 0f)
			{
				return;
			}
			sam.Flag = 0;
			sam.Timer = 0f;
			sam.SampleAnimation(ESheetMeshAnim.victory, 0.36f);
		}
		Vector3 center = sam.SpreadPos + FSMUnit.JUMP_FROM_WALL_CENTER_OFFSET;
		sam.transform.position = GameConstants.QuadraticBezierCurves(sam.SpreadPos, center, sam.LastTargetPos, 1.25f, sam.Timer);
		sam.Timer += deltaTime;
		if (sam.Timer >= 0.8f)
		{
			sam.EnableShadow = true;
			sam.SpreadPos = Vector3.zero;
			if (FSMManager.Instance.bIsBattleOver && DataManager.Instance.War_LordCapture != 0)
			{
				sam.FSMController = FSMManager.Instance.getState(EStateName.GO_CAPTIVING);
			}
			else
			{
				sam.FSMController = FSMManager.Instance.getState(EStateName.IDLE_FASTRUN);
			}
		}
	}
}
