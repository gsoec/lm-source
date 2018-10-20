using System;

// Token: 0x02000712 RID: 1810
public class FSMIdleWithoutClump : FSMUnit
{
	// Token: 0x060022D6 RID: 8918 RVA: 0x0040B6F4 File Offset: 0x004098F4
	public FSMIdleWithoutClump(FSMManager pMgr)
	{
		this.pManager = pMgr;
		this.StateName = EStateName.IDLE_WITHOUT_CLUMP;
	}

	// Token: 0x060022D7 RID: 8919 RVA: 0x0040B70C File Offset: 0x0040990C
	public override void Enter(Soldier sam)
	{
		if (sam.Index == 255)
		{
			sam.PlayAnim(ESheetMeshAnim.idle, SAWrapMode.Loop, true, false, false);
		}
		else
		{
			sam.playMode = SAWrapMode.Default;
		}
	}

	// Token: 0x060022D8 RID: 8920 RVA: 0x0040B744 File Offset: 0x00409944
	public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
	{
	}
}
