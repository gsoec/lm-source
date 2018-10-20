using System;

// Token: 0x020003F5 RID: 1013
public class TimerTypeMission
{
	// Token: 0x04003D8E RID: 15758
	private const byte MissionMax = 15;

	// Token: 0x04003D8F RID: 15759
	public long ResetTime;

	// Token: 0x04003D90 RID: 15760
	public long MissionTime;

	// Token: 0x04003D91 RID: 15761
	public byte MissionCount;

	// Token: 0x04003D92 RID: 15762
	public byte ProcessIdx;

	// Token: 0x04003D93 RID: 15763
	public _TimeMission[] TimeMission = new _TimeMission[15];
}
