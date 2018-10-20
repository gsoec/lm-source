using System;

// Token: 0x020003F1 RID: 1009
public class ChallengeAimMission : StageAimMission
{
	// Token: 0x0600148F RID: 5263 RVA: 0x0023B260 File Offset: 0x00239460
	public ChallengeAimMission()
	{
		this.ManorBuildData = new ManorCheck[1];
		base.Init();
	}

	// Token: 0x06001490 RID: 5264 RVA: 0x0023B27C File Offset: 0x0023947C
	public override bool CheckValueChanged(ushort Key, ushort Val)
	{
		Val /= 3;
		return base.CheckValueChanged(Key, Val);
	}
}
