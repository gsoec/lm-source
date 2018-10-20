using System;

// Token: 0x020003EF RID: 1007
public class AdvanceAimMission : StageAimMission
{
	// Token: 0x0600148C RID: 5260 RVA: 0x0023B21C File Offset: 0x0023941C
	public AdvanceAimMission()
	{
		this.ManorBuildData = new ManorCheck[1];
		base.Init();
	}

	// Token: 0x0600148D RID: 5261 RVA: 0x0023B238 File Offset: 0x00239438
	public override bool CheckValueChanged(ushort Key, ushort Val)
	{
		return base.CheckValueChanged(Key, Val);
	}
}
