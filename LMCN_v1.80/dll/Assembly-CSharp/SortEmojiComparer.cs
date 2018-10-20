using System;
using System.Collections.Generic;

// Token: 0x020001B2 RID: 434
public class SortEmojiComparer : IComparer<ushort>
{
	// Token: 0x06000706 RID: 1798 RVA: 0x0009E638 File Offset: 0x0009C838
	public int Compare(ushort x, ushort y)
	{
		Emote recordByKey = DataManager.MapDataController.EmoteTable.GetRecordByKey(x);
		Emote recordByKey2 = DataManager.MapDataController.EmoteTable.GetRecordByKey(y);
		if (!GUIManager.Instance.HasEmotionPck(x) && GUIManager.Instance.HasEmotionPck(y))
		{
			return 1;
		}
		if (GUIManager.Instance.HasEmotionPck(x) && !GUIManager.Instance.HasEmotionPck(y))
		{
			return -1;
		}
		if (DataManager.Instance.CheckEmojiSave(x) && !DataManager.Instance.CheckEmojiSave(y))
		{
			return 1;
		}
		if (!DataManager.Instance.CheckEmojiSave(x) && DataManager.Instance.CheckEmojiSave(y))
		{
			return -1;
		}
		if (recordByKey.Weight < recordByKey2.Weight)
		{
			return 1;
		}
		if (recordByKey.Weight > recordByKey2.Weight)
		{
			return -1;
		}
		return 0;
	}
}
