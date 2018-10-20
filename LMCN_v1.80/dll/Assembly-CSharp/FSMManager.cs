using System;

// Token: 0x0200072C RID: 1836
public class FSMManager
{
	// Token: 0x06002324 RID: 8996 RVA: 0x0040DA48 File Offset: 0x0040BC48
	private FSMManager()
	{
		this.m_FSMUnit = new FSMUnit[27];
		this.m_FSMUnit[0] = new FSMMoving(this);
		this.m_FSMUnit[1] = new FSMIdle(this);
		this.m_FSMUnit[2] = new FSMIdle_FastRun(this);
		this.m_FSMUnit[3] = new FSMIdleWithoutClump(this);
		this.m_FSMUnit[4] = new FSMMeleeFight(this);
		this.m_FSMUnit[8] = new FSMMeleeFight_Wall(this);
		this.m_FSMUnit[5] = new FSMMeleeFightImmediate(this);
		this.m_FSMUnit[6] = new FSMRangeFight(this);
		this.m_FSMUnit[7] = new FSMRangeFight_Wall(this);
		this.m_FSMUnit[9] = new FSMTryFight(this);
		this.m_FSMUnit[11] = new FSMDie(this);
		this.m_FSMUnit[12] = new FSMDying(this);
		this.m_FSMUnit[13] = new FSMLordDying(this);
		this.m_FSMUnit[14] = new FSMLordDie(this);
		this.m_FSMUnit[15] = new FSMSpread(this);
		this.m_FSMUnit[10] = new FSMMoveToTarget(this);
		this.m_FSMUnit[16] = new FSMArcherSpread(this);
		this.m_FSMUnit[17] = new FSMVictory(this);
		this.m_FSMUnit[18] = new FSMMoveOutOfTown(this);
		this.m_FSMUnit[19] = new FSMJumpFromWall(this);
		this.m_FSMUnit[20] = new FSMLoseTarget(this);
		this.m_FSMUnit[21] = new FSMGoCaptiving(this);
		this.m_FSMUnit[22] = new FSMAttackerRunAway(this);
		this.m_FSMUnit[23] = new FSMDefenserChasing(this);
		this.m_FSMUnit[24] = new FSMDefenserRunAway(this);
		this.m_FSMUnit[25] = new FSMAttackerChasing(this);
		this.m_FSMUnit[26] = new FSMOutsideHeroDisplay(this);
	}

	// Token: 0x170000CA RID: 202
	// (get) Token: 0x06002326 RID: 8998 RVA: 0x0040DBF8 File Offset: 0x0040BDF8
	public static FSMManager Instance
	{
		get
		{
			if (FSMManager.m_Self == null)
			{
				FSMManager.m_Self = new FSMManager();
			}
			return FSMManager.m_Self;
		}
	}

	// Token: 0x06002327 RID: 8999 RVA: 0x0040DC14 File Offset: 0x0040BE14
	public FSMUnit getState(EStateName name)
	{
		return this.m_FSMUnit[(int)name];
	}

	// Token: 0x04006C20 RID: 27680
	public const int BehaviourCount = 27;

	// Token: 0x04006C21 RID: 27681
	public FSMUnit[] m_FSMUnit;

	// Token: 0x04006C22 RID: 27682
	public static FSMManager m_Self;

	// Token: 0x04006C23 RID: 27683
	public bool bIsSiegeMode;

	// Token: 0x04006C24 RID: 27684
	public bool bIsBattleOver;

	// Token: 0x04006C25 RID: 27685
	public int MaxCaptiver;

	// Token: 0x04006C26 RID: 27686
	public int CaptivingCount;
}
