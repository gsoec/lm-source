using System;
using System.Collections.Generic;

// Token: 0x0200017D RID: 381
public class QueueBarDataComparer : IComparer<byte>
{
	// Token: 0x06000586 RID: 1414 RVA: 0x00077580 File Offset: 0x00075780
	public int Compare(byte x, byte y)
	{
		QueueBarData queueBarData = DataManager.Instance.queueBarData[(int)x];
		QueueBarData queueBarData2 = DataManager.Instance.queueBarData[(int)y];
		if (!queueBarData.bActive)
		{
			return (!queueBarData2.bActive) ? 0 : 1;
		}
		if (!queueBarData2.bActive)
		{
			return -1;
		}
		eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType((EQueueBarIndex)x);
		eTimerSpriteType queueBarSpriteType2 = DataManager.Instance.GetQueueBarSpriteType((EQueueBarIndex)y);
		if (queueBarSpriteType != eTimerSpriteType.Idle && queueBarSpriteType2 == eTimerSpriteType.Idle)
		{
			return 1;
		}
		if (queueBarSpriteType == eTimerSpriteType.Idle && queueBarSpriteType2 != eTimerSpriteType.Idle)
		{
			return -1;
		}
		if (queueBarSpriteType != eTimerSpriteType.Free && queueBarSpriteType2 == eTimerSpriteType.Free)
		{
			return 1;
		}
		if (queueBarSpriteType == eTimerSpriteType.Free && queueBarSpriteType2 != eTimerSpriteType.Free)
		{
			return -1;
		}
		if (queueBarSpriteType != eTimerSpriteType.Help && queueBarSpriteType2 == eTimerSpriteType.Help)
		{
			return 1;
		}
		if (queueBarSpriteType == eTimerSpriteType.Help && queueBarSpriteType2 != eTimerSpriteType.Help)
		{
			return -1;
		}
		if (queueBarData.StartTime < queueBarData2.StartTime)
		{
			return 1;
		}
		if (queueBarData.StartTime > queueBarData2.StartTime)
		{
			return -1;
		}
		return 0;
	}
}
