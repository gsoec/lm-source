using System;

// Token: 0x020003F2 RID: 1010
public class ChallengeAdvanceAimMission : ManorAimNow
{
	// Token: 0x06001491 RID: 5265 RVA: 0x0023B28C File Offset: 0x0023948C
	public ChallengeAdvanceAimMission()
	{
		this.ManorBuildData = new ManorCheck[48];
		base.Init();
	}

	// Token: 0x06001492 RID: 5266 RVA: 0x0023B2A8 File Offset: 0x002394A8
	public override bool CheckValueChanged(ushort Key, ushort Val)
	{
		Key /= 3;
		return base.CheckValueChanged(Key, Val);
	}

	// Token: 0x06001493 RID: 5267 RVA: 0x0023B2B8 File Offset: 0x002394B8
	public override void SetCompleteWhileLogin()
	{
		int num = (int)(DataManager.StageDataController.StageRecord[3] / 3);
		ushort num2 = 1;
		while ((int)num2 <= num)
		{
			int stagePoint = DataManager.StageDataController.GetStagePoint(num2 * 3, 3);
			if (stagePoint > 0)
			{
				this.CheckValueChanged(num2 * 3, (ushort)stagePoint);
			}
			num2 += 1;
		}
	}
}
