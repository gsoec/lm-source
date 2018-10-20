using System;

// Token: 0x02000719 RID: 1817
public class FSMMeleeFightImmediate : FSMUnit
{
	// Token: 0x060022EB RID: 8939 RVA: 0x0040C294 File Offset: 0x0040A494
	public FSMMeleeFightImmediate(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.MELEE_FIGHT_IMMEDIATE;
	}

	// Token: 0x060022EC RID: 8940 RVA: 0x0040C2AC File Offset: 0x0040A4AC
	public override void Enter(Soldier sam)
	{
		sam.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Default, false, true, false);
	}

	// Token: 0x060022ED RID: 8941 RVA: 0x0040C2BC File Offset: 0x0040A4BC
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
	}
}
