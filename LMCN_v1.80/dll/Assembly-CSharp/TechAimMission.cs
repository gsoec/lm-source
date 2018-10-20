using System;

// Token: 0x020003EC RID: 1004
public class TechAimMission : ManorAimNow
{
	// Token: 0x06001486 RID: 5254 RVA: 0x0023B0F0 File Offset: 0x002392F0
	public TechAimMission()
	{
		this.ManorBuildData = new ManorCheck[DataManager.Instance.TechCount];
		base.Init();
	}

	// Token: 0x06001487 RID: 5255 RVA: 0x0023B114 File Offset: 0x00239314
	public override void SetCompleteWhileLogin()
	{
		DataManager instance = DataManager.Instance;
		for (int i = 0; i < this.ManorBuildData.Length; i++)
		{
			ushort num = (ushort)(i + 1);
			this.UpdateCheckIndex(num, (ushort)instance.GetTechLevel(num));
		}
	}
}
