using System;

// Token: 0x0200038E RID: 910
public class MobilizationAlliBroudUnit
{
	// Token: 0x060012CB RID: 4811 RVA: 0x0020D310 File Offset: 0x0020B510
	public MobilizationAlliBroudUnit()
	{
		this.Name = StringManager.Instance.SpawnString(30);
	}

	// Token: 0x04003A9A RID: 15002
	public CString Name;

	// Token: 0x04003A9B RID: 15003
	public ushort Score;

	// Token: 0x04003A9C RID: 15004
	public byte AquiredMission;

	// Token: 0x04003A9D RID: 15005
	public byte FinishedMission;

	// Token: 0x04003A9E RID: 15006
	public byte index;

	// Token: 0x04003A9F RID: 15007
	public bool finishBonus;
}
