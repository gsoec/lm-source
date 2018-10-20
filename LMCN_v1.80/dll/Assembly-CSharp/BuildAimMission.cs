using System;

// Token: 0x020003EA RID: 1002
public class BuildAimMission : ManorAimNow
{
	// Token: 0x0600147F RID: 5247 RVA: 0x0023AF64 File Offset: 0x00239164
	public BuildAimMission()
	{
		this.ManorBuildData = new ManorCheck[DataManager.Instance.BuildsTypeData.TableCount];
		base.Init();
	}

	// Token: 0x06001480 RID: 5248 RVA: 0x0023AF98 File Offset: 0x00239198
	public override void SetCompleteWhileLogin()
	{
		BuildsData buildingData = GUIManager.Instance.BuildingData;
		for (int i = 0; i < this.ManorBuildData.Length; i++)
		{
			ushort num = (ushort)(i + 1);
			byte level = buildingData.GetBuildData(num, 0).Level;
			this.UpdateCheckIndex(num, (ushort)level);
		}
	}

	// Token: 0x06001481 RID: 5249 RVA: 0x0023AFE8 File Offset: 0x002391E8
	public override bool CheckValueChanged(ushort Key, ushort Val)
	{
		if (this.ManorBuildData[(int)(Key - this.KeyBegin)].CondiVal > (int)Val)
		{
			Val = (ushort)GUIManager.Instance.BuildingData.GetBuildData(Key, 0).Level;
		}
		return base.CheckValueChanged(Key, Val);
	}
}
