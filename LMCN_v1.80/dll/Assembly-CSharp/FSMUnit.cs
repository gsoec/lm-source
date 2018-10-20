using System;
using UnityEngine;

// Token: 0x0200070F RID: 1807
public class FSMUnit
{
	// Token: 0x060022CA RID: 8906 RVA: 0x0040B1F0 File Offset: 0x004093F0
	public virtual void Enter(Soldier sam)
	{
	}

	// Token: 0x060022CB RID: 8907 RVA: 0x0040B1F4 File Offset: 0x004093F4
	public virtual void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
	}

	// Token: 0x060022CC RID: 8908 RVA: 0x0040B1F8 File Offset: 0x004093F8
	public static bool CheckTargetActiving(Soldier sam)
	{
		return sam.Target != null && sam.Target.FSMController != null && sam.Target.CurFSM != EStateName.DIE && sam.Target.CurFSM != EStateName.DYING;
	}

	// Token: 0x060022CD RID: 8909 RVA: 0x0040B248 File Offset: 0x00409448
	public static Soldier ReallocTarget(Soldier self, ArmyGroup targetAry)
	{
		if (self.Target != null)
		{
			return self.Target;
		}
		if (self.IsHeroSoldier && targetAry.heroSoldier != null)
		{
			return targetAry.heroSoldier;
		}
		if (targetAry.bNpcMode)
		{
			return targetAry.heroSoldier;
		}
		int rowCount = self.Parent.RowCount;
		int num = (int)self.Index / rowCount;
		int num2 = rowCount * (num + 1) - (int)(self.Index + 1);
		int num3 = rowCount * num + num2;
		num3 = ((num3 < targetAry.CurrentSoldierCount) ? num3 : UnityEngine.Random.Range(0, targetAry.CurrentSoldierCount));
		num3 = Mathf.Max(num3, 0);
		Soldier soldier = targetAry.soldiers[num3];
		if (soldier.CurFSM == EStateName.DIE)
		{
			soldier = targetAry.soldiers[0];
		}
		return soldier;
	}

	// Token: 0x060022CE RID: 8910 RVA: 0x0040B30C File Offset: 0x0040950C
	public static void MoveSoldier(Soldier sol, Vector3 end, float speed)
	{
		sol.transform.position = GameConstants.MoveTowards(sol.transform.position, end, speed);
		sol.LastMovingFrame = Time.frameCount;
	}

	// Token: 0x060022CF RID: 8911 RVA: 0x0040B344 File Offset: 0x00409544
	public static void CheckDirectionToTarget(Soldier sol, float deltaTime)
	{
		if (sol.Target == null)
		{
			return;
		}
		FSMUnit.SolRef = sol.Target;
		if (sol.bNewTargetDirty || FSMUnit.SolRef.IsMoveDirty)
		{
			sol.bNewTargetDirty = false;
			sol.Direction = FSMUnit.SolRef.transform.position - sol.transform.position;
			sol.Direction.y = 0f;
			float num = Vector3.Angle(sol.Direction, sol.transform.forward);
			if (num >= 0.01f)
			{
				sol.bRotateDirty = true;
			}
		}
		if (sol.bRotateDirty)
		{
			Quaternion to = Quaternion.LookRotation(sol.Direction);
			sol.transform.rotation = Quaternion.Slerp(sol.transform.rotation, to, deltaTime * 5f);
			float num2 = Vector3.Angle(sol.Direction, sol.transform.forward);
			if (num2 <= 0.01f)
			{
				sol.bRotateDirty = false;
			}
		}
	}

	// Token: 0x04006C0B RID: 27659
	public const float OFFTEAM_SPEED_RATE = 1.3f;

	// Token: 0x04006C0C RID: 27660
	public const float FAST_OFFTEAM_SPEED_RATE = 2.5f;

	// Token: 0x04006C0D RID: 27661
	public const float SPREAD_RANGE = 5f;

	// Token: 0x04006C0E RID: 27662
	public const float SPREAD_SPEED_RATE = 1.3f;

	// Token: 0x04006C0F RID: 27663
	public const float DYING_SPREAD_RANGE = 0.05f;

	// Token: 0x04006C10 RID: 27664
	public const float ROTATE_SPEED = 5f;

	// Token: 0x04006C11 RID: 27665
	public const float SQR_OF_CM = 0.0001f;

	// Token: 0x04006C12 RID: 27666
	public const float DEADBODY_HIDE_FLAG = -10f;

	// Token: 0x04006C13 RID: 27667
	public const float DEADBODY_HIDE_SPEED = 1f;

	// Token: 0x04006C14 RID: 27668
	public const float DEADBODY_HIDE_LEN = 2f;

	// Token: 0x04006C15 RID: 27669
	public const float DEADBODY_SHOWING_TIME = 20f;

	// Token: 0x04006C16 RID: 27670
	public const float ATTACK_TIMER = 1.5f;

	// Token: 0x04006C17 RID: 27671
	public const float LORD_ATTACK_TIMER = 3f;

	// Token: 0x04006C18 RID: 27672
	public const float DEFAULT_SPEED = 4.5f;

	// Token: 0x04006C19 RID: 27673
	public static readonly Vector3 JUMP_FROM_WALL_CENTER_OFFSET = new Vector3(-5f, 10f, 0f);

	// Token: 0x04006C1A RID: 27674
	public static readonly Vector3 JUMP_FROM_WALL_END_OFFSET = new Vector3(-10f, 0f, 0f);

	// Token: 0x04006C1B RID: 27675
	public static readonly Vector3 WALL_FRONT = new Vector3(52f, 0f, 15f);

	// Token: 0x04006C1C RID: 27676
	public static readonly Vector3 WALL_BACK = new Vector3(62f, 0f, 15f);

	// Token: 0x04006C1D RID: 27677
	public static Soldier SolRef = null;

	// Token: 0x04006C1E RID: 27678
	protected FSMManager pManager;

	// Token: 0x04006C1F RID: 27679
	public EStateName StateName;
}
