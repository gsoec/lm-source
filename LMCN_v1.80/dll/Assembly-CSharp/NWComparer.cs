using System;
using System.Collections.Generic;

// Token: 0x0200001E RID: 30
public class NWComparer : IComparer<byte>
{
	// Token: 0x060000F3 RID: 243 RVA: 0x00010F30 File Offset: 0x0000F130
	public int Compare(byte x, byte y)
	{
		ActivityManager instance = ActivityManager.Instance;
		NobilityGroupDataType nobilityGroupDataType = instance.NobilityActivityData.NobilityGroupData[(int)x];
		NobilityGroupDataType nobilityGroupDataType2 = instance.NobilityActivityData.NobilityGroupData[(int)y];
		if (nobilityGroupDataType.EventState != EActivityState.EAS_ReplayRanking && nobilityGroupDataType2.EventState == EActivityState.EAS_ReplayRanking)
		{
			return -1;
		}
		if (nobilityGroupDataType.EventState == EActivityState.EAS_ReplayRanking && nobilityGroupDataType2.EventState != EActivityState.EAS_ReplayRanking)
		{
			return 1;
		}
		if (nobilityGroupDataType.EventBeginTime < nobilityGroupDataType2.EventBeginTime)
		{
			return -1;
		}
		if (nobilityGroupDataType.EventBeginTime > nobilityGroupDataType2.EventBeginTime)
		{
			return 1;
		}
		return 0;
	}
}
