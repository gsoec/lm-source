using System;

// Token: 0x0200071E RID: 1822
public class FSMLordDying : FSMUnit
{
	// Token: 0x060022FA RID: 8954 RVA: 0x0040CA50 File Offset: 0x0040AC50
	public FSMLordDying(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.LORD_DYING;
	}

	// Token: 0x060022FB RID: 8955 RVA: 0x0040CA68 File Offset: 0x0040AC68
	public override void Enter(Soldier sam)
	{
		sam.PlayAnim(ESheetMeshAnim.die, SAWrapMode.Once, true, false, false);
		sam.EnableShadow = false;
	}

	// Token: 0x060022FC RID: 8956 RVA: 0x0040CA80 File Offset: 0x0040AC80
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
		if (!sam.IsLord)
		{
			Lord lord = sam as Lord;
			if (lord != null && !lord.getAnimComponent().IsPlaying("die"))
			{
				sam.FSMController = FSMManager.Instance.getState(EStateName.LORD_DIE);
			}
		}
	}
}
