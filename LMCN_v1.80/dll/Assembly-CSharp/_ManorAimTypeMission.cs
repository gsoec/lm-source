using System;

// Token: 0x020003E6 RID: 998
public abstract class _ManorAimTypeMission
{
	// Token: 0x06001469 RID: 5225
	public abstract void AddData(ushort Priority, ushort Key, ushort Val);

	// Token: 0x0600146A RID: 5226
	public abstract void AddDataFail(ushort Priority);

	// Token: 0x0600146B RID: 5227
	public abstract void SetCompleteWhileLogin();

	// Token: 0x0600146C RID: 5228
	public abstract bool CheckValueChanged(ushort Key, ushort Val);

	// Token: 0x0600146D RID: 5229
	public abstract void UpdateCheckIndex(ushort Key, ushort Val);

	// Token: 0x0600146E RID: 5230
	public abstract void Reset();

	// Token: 0x0600146F RID: 5231
	public abstract void ClearAll();
}
