using System;
using UnityEngine;

// Token: 0x02000725 RID: 1829
public class FSMGoCaptiving : FSMUnit
{
	// Token: 0x0600230F RID: 8975 RVA: 0x0040D188 File Offset: 0x0040B388
	public FSMGoCaptiving(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.GO_CAPTIVING;
	}

	// Token: 0x06002310 RID: 8976 RVA: 0x0040D1A0 File Offset: 0x0040B3A0
	public override void Enter(Soldier sam)
	{
		if (sam.Parent.SoldierTarget != null)
		{
			Vector3 position = sam.Parent.SoldierTarget.transform.position;
			Vector3 captivePos = Vector3.zero;
			bool bIsSiegeMode;
			do
			{
				int num = UnityEngine.Random.Range(0, 360);
				Vector3 a = Quaternion.AngleAxis((float)num, Vector3.up) * Vector3.forward;
				float d = (sam.SoldierKind != 3) ? UnityEngine.Random.Range(6f, 9f) : 10f;
				captivePos = position + a * d;
				bIsSiegeMode = FSMManager.Instance.bIsSiegeMode;
			}
			while (bIsSiegeMode && captivePos.x >= 50f);
			sam.CaptivePos = captivePos;
			sam.CaptiveFlag = 1;
			sam.PlayAnim(ESheetMeshAnim.moving, SAWrapMode.Loop, true, false, false);
		}
		else
		{
			sam.FSMController = FSMManager.Instance.getState(EStateName.IDLE);
			FSMManager.Instance.CaptivingCount--;
		}
	}

	// Token: 0x06002311 RID: 8977 RVA: 0x0040D2A4 File Offset: 0x0040B4A4
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (sam.CaptiveFlag == 0)
		{
			return;
		}
		if (sam.CaptiveFlag == 1)
		{
			Transform transform = sam.transform;
			Vector3 vector = sam.CaptivePos - transform.position;
			if (vector != Vector3.zero)
			{
				Quaternion to = Quaternion.LookRotation(vector);
				transform.rotation = Quaternion.Slerp(transform.rotation, to, 5f * deltaTime);
			}
			FSMUnit.MoveSoldier(sam, sam.CaptivePos, parent.MoveSpeed * 2.5f * deltaTime);
			if (GameConstants.DistanceSquare(transform.position, sam.CaptivePos) <= 0.0001f)
			{
				sam.CaptiveFlag = 2;
				sam.PlayAnim(ESheetMeshAnim.victory, SAWrapMode.Loop, true, false, false);
				FSMManager.Instance.CaptivingCount++;
				sam.CaptivePos = sam.Parent.SoldierTarget.transform.position - transform.position;
			}
		}
		else if (sam.CaptiveFlag == 2)
		{
			Transform transform2 = sam.transform;
			if (sam.CaptivePos != Vector3.zero)
			{
				Quaternion quaternion = Quaternion.LookRotation(sam.CaptivePos);
				if (quaternion != transform2.rotation)
				{
					transform2.rotation = Quaternion.Slerp(transform2.rotation, quaternion, 5f * deltaTime);
				}
				else
				{
					sam.CaptiveFlag = 0;
				}
			}
		}
	}
}
