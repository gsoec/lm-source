using System;
using UnityEngine;

// Token: 0x0200071D RID: 1821
public class FSMDying : FSMUnit
{
	// Token: 0x060022F7 RID: 8951 RVA: 0x0040C530 File Offset: 0x0040A730
	public FSMDying(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.DYING;
	}

	// Token: 0x060022F8 RID: 8952 RVA: 0x0040C548 File Offset: 0x0040A748
	public override void Enter(Soldier sam)
	{
		sam.EnableShadow = false;
		if (sam.Parent.GroupKind == EGroupKind.Catapults)
		{
			sam.PlayAnim(ESheetMeshAnim.die, SAWrapMode.Once, true, false, false);
			sam.SpreadPos = sam.transform.position;
			sam.Flag = 0;
		}
		else if (sam.Flag != 0)
		{
			sam.ActionMode = EActionMode.Personal;
			float x = (sam.Parent.Side != 0) ? -1f : 1f;
			if (sam.Flag == 1)
			{
				sam.transform.rotation = Quaternion.LookRotation(new Vector3(x, 0f, UnityEngine.Random.Range(-0.5f, 0.5f)));
			}
			else
			{
				sam.transform.rotation = Quaternion.LookRotation(new Vector3(UnityEngine.Random.Range(-1f, 1f), 0f, UnityEngine.Random.Range(-1f, 1f)));
			}
			float num = UnityEngine.Random.Range(5f, 12f);
			if (sam.Target != null)
			{
				Vector3 a = sam.transform.position - sam.Target.transform.position;
				a.Normalize();
				sam.SpreadPos = sam.transform.TransformPoint(a * num);
			}
			else
			{
				sam.SpreadPos = sam.transform.TransformPoint(new Vector3(0f, 0f, -num));
			}
			sam.LastTargetPos = sam.transform.position;
			sam.LastTargetPos.y = 0f;
			float num2 = (sam.Flag != 1) ? 15f : 10f;
			float num3 = 1f / num2;
			sam.DyingValue = UnityEngine.Random.Range(num2 - 5f, num2 + 5f);
			sam.fightTimer = sam.DyingValue * num3 * (num * 0.117647059f) * 0.7f;
			sam.Timer = 0f;
			if (sam.SoldierKind == 3 && sam.SoldierTier == 4 && sam.CurAnim == ESheetMeshAnim.attack)
			{
				float num4 = sam.CurAnimTime();
				if (num4 >= 0.2f && num4 <= 0.966f)
				{
					sam.SampleAnimation(ESheetMeshAnim.attack, 0f);
				}
			}
			sam.IsPlaying = false;
		}
		else
		{
			sam.PlayAnim(ESheetMeshAnim.die, SAWrapMode.Once, true, false, false);
			Vector3 position = sam.transform.position;
			float x2 = UnityEngine.Random.Range(position.x - 0.05f, position.x + 0.05f);
			float z = UnityEngine.Random.Range(position.z - 0.05f, position.z + 0.05f);
			sam.SpreadPos = new Vector3(x2, 0f, z);
			sam.DyingValue = Vector3.Distance(position, sam.SpreadPos) * sam.AnimLength;
		}
	}

	// Token: 0x060022F9 RID: 8953 RVA: 0x0040C830 File Offset: 0x0040AA30
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (sam.Index == 255)
		{
			Transform transform = sam.transform;
			Vector3 vector = sam.SpreadPos - transform.position;
			if (vector != Vector3.zero)
			{
				transform.rotation = Quaternion.LookRotation(vector);
			}
			FSMUnit.MoveSoldier(sam, sam.SpreadPos, sam.DyingValue * deltaTime);
			if (sam.DieState == 1 && (sam.SpreadPos == Vector3.zero || GameConstants.DistanceSquare(transform.position, sam.SpreadPos) <= 0.0001f))
			{
				sam.FSMController = FSMManager.Instance.getState(EStateName.DIE);
			}
		}
		else if (sam.Flag != 0)
		{
			float fightTimer = sam.fightTimer;
			float inverseLength = 1f / fightTimer;
			Vector3 center = (sam.SpreadPos + sam.LastTargetPos) * 0.5f;
			center.y = sam.DyingValue;
			sam.transform.position = GameConstants.QuadraticBezierCurves(sam.LastTargetPos, center, sam.SpreadPos, inverseLength, sam.Timer);
			sam.Timer += deltaTime;
			if (sam.Timer >= fightTimer)
			{
				sam.transform.position = sam.SpreadPos;
				sam.SpreadPos = Vector3.zero;
				sam.FSMController = FSMManager.Instance.getState(EStateName.DIE);
				sam.PlayAnim(ESheetMeshAnim.die, SAWrapMode.Once, true, false, false);
				sam.Flag = 0;
			}
		}
		else
		{
			Transform transform2 = sam.transform;
			Vector3 vector2 = sam.SpreadPos - transform2.position;
			if (vector2 != Vector3.zero)
			{
				transform2.rotation = Quaternion.LookRotation(vector2);
				FSMUnit.MoveSoldier(sam, sam.SpreadPos, sam.DyingValue * deltaTime);
			}
			if (sam.DieState == 1 && (sam.SpreadPos == Vector3.zero || GameConstants.DistanceSquare(transform2.position, sam.SpreadPos) <= 0.0001f))
			{
				sam.FSMController = FSMManager.Instance.getState(EStateName.DIE);
			}
		}
	}
}
