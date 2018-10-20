using System;
using UnityEngine;

// Token: 0x02000705 RID: 1797
public class ActivityData : ScriptableObject
{
	// Token: 0x0600228B RID: 8843 RVA: 0x004086CC File Offset: 0x004068CC
	public ActivityData init(string[] content, int count)
	{
		this.Content = content;
		this.Count = count;
		return this;
	}

	// Token: 0x04006B7A RID: 27514
	public int Count;

	// Token: 0x04006B7B RID: 27515
	public string[] Content;
}
