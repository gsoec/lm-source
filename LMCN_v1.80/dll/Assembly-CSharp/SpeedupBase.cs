using System;
using System.Collections.Generic;

// Token: 0x0200083B RID: 2107
public abstract class SpeedupBase
{
	// Token: 0x17000149 RID: 329
	// (get) Token: 0x06002BAD RID: 11181 RVA: 0x00481FFC File Offset: 0x004801FC
	public virtual long StartTime
	{
		get
		{
			return 0L;
		}
	}

	// Token: 0x1700014A RID: 330
	// (get) Token: 0x06002BAE RID: 11182 RVA: 0x00482000 File Offset: 0x00480200
	public virtual uint TotalTime
	{
		get
		{
			return 0u;
		}
	}

	// Token: 0x1700014B RID: 331
	// (get) Token: 0x06002BAF RID: 11183 RVA: 0x00482004 File Offset: 0x00480204
	public virtual CString Name
	{
		get
		{
			return null;
		}
	}

	// Token: 0x06002BB0 RID: 11184
	public abstract void SendImmediate();

	// Token: 0x06002BB1 RID: 11185
	public abstract void SendImmediateFree();

	// Token: 0x06002BB2 RID: 11186 RVA: 0x00482008 File Offset: 0x00480208
	public virtual void CustomSort(List<ushort> Data, int BagCount)
	{
	}

	// Token: 0x0400785D RID: 30813
	public string MainTitleStr;

	// Token: 0x0400785E RID: 30814
	public string CompleteImmContStr;

	// Token: 0x0400785F RID: 30815
	public string CompleteImmBntStr;

	// Token: 0x04007860 RID: 30816
	public bool bFreeSpeedup;

	// Token: 0x04007861 RID: 30817
	public bool bImmediate;

	// Token: 0x04007862 RID: 30818
	public byte QueueBar;

	// Token: 0x04007863 RID: 30819
	public byte Rally;

	// Token: 0x04007864 RID: 30820
	public byte FilterType;

	// Token: 0x04007865 RID: 30821
	public byte SkipFilterTime;

	// Token: 0x04007866 RID: 30822
	public byte FilterType2;

	// Token: 0x04007867 RID: 30823
	public _UseItemTarget UseTarget;

	// Token: 0x04007868 RID: 30824
	protected List<ushort> CustomList;
}
