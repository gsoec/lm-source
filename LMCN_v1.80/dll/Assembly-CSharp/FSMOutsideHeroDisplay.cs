using System;
using UnityEngine;

// Token: 0x0200072B RID: 1835
public class FSMOutsideHeroDisplay : FSMUnit
{
	// Token: 0x06002321 RID: 8993 RVA: 0x0040D988 File Offset: 0x0040BB88
	public FSMOutsideHeroDisplay(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.OUTSIDE_HERO_DISPLAY;
	}

	// Token: 0x06002322 RID: 8994 RVA: 0x0040D9A0 File Offset: 0x0040BBA0
	public override void Enter(Soldier sam)
	{
		sam.PlayAnim(ESheetMeshAnim.idle, SAWrapMode.Loop, true, false, false);
		sam.Timer = (float)UnityEngine.Random.Range(2, 6);
	}

	// Token: 0x06002323 RID: 8995 RVA: 0x0040D9BC File Offset: 0x0040BBBC
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (sam.Timer > 0f)
		{
			sam.Timer -= deltaTime;
			if (sam.Timer <= 0f)
			{
				sam.PlayAnim(ESheetMeshAnim.victory, SAWrapMode.Default, true, false, false);
			}
		}
		else
		{
			Animation animComponent = sam.getAnimComponent();
			if (animComponent != null)
			{
				float time = animComponent["victory"].time;
				if (time <= 0f)
				{
					sam.Timer = (float)UnityEngine.Random.Range(2, 6);
				}
			}
		}
	}
}
