using System;

// Token: 0x020003EB RID: 1003
public class ArmyAimMission : ManorAimEver
{
	// Token: 0x06001482 RID: 5250 RVA: 0x0023B038 File Offset: 0x00239238
	public ArmyAimMission(ushort[] RecordMark) : base(RecordMark)
	{
		this.ManorBuildData = new ManorCheck[29];
		this.RecordBeginIndex = 1;
		base.Init();
	}

	// Token: 0x06001483 RID: 5251 RVA: 0x0023B05C File Offset: 0x0023925C
	public override void SetCompleteWhileLogin()
	{
		for (int i = 0; i < this.ManorBuildData.Length; i++)
		{
			this.UpdateCheckIndex((ushort)(i + (int)this.KeyBegin), this.RecordMark[i + (int)this.RecordBeginIndex]);
		}
	}

	// Token: 0x06001484 RID: 5252 RVA: 0x0023B0A0 File Offset: 0x002392A0
	public override void UpdateCheckIndex(ushort Key, ushort Val)
	{
		this.CheckValueChanged(Key, 0);
	}

	// Token: 0x06001485 RID: 5253 RVA: 0x0023B0AC File Offset: 0x002392AC
	public override bool CheckValueChanged(ushort Key, ushort Val)
	{
		ushort[] recordMark = this.RecordMark;
		recordMark[(int)Key] = recordMark[(int)Key] + Val;
		if (!base.CheckValueChanged(Key, this.RecordMark[(int)Key]))
		{
			return false;
		}
		GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15, 0);
		return true;
	}

	// Token: 0x04003D8A RID: 15754
	private ushort RecordBeginIndex;
}
