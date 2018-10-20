using System;

// Token: 0x020003EE RID: 1006
public class NormalAimMission : StageAimMission
{
	// Token: 0x0600148A RID: 5258 RVA: 0x0023B1F0 File Offset: 0x002393F0
	public NormalAimMission()
	{
		this.ManorBuildData = new ManorCheck[1];
		base.Init();
	}

	// Token: 0x0600148B RID: 5259 RVA: 0x0023B20C File Offset: 0x0023940C
	public override bool CheckValueChanged(ushort Key, ushort Val)
	{
		Val /= 3;
		return base.CheckValueChanged(Key, Val);
	}
}
