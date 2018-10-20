using System;
using UnityEngine;

// Token: 0x02000040 RID: 64
public class AudioSourceController
{
	// Token: 0x0600017A RID: 378 RVA: 0x00017B1C File Offset: 0x00015D1C
	public void Set(AudioSource source)
	{
		this.Source = source;
		this.Valid = 1;
	}

	// Token: 0x0600017B RID: 379 RVA: 0x00017B2C File Offset: 0x00015D2C
	public void Stop()
	{
		if (this.Valid == 1)
		{
			this.Source.Stop();
		}
	}

	// Token: 0x0600017C RID: 380 RVA: 0x00017B48 File Offset: 0x00015D48
	public void CheckValid(AudioSource source)
	{
		if (this.Valid == 0)
		{
			return;
		}
		if (this.Source == source)
		{
			this.Valid = 0;
		}
	}

	// Token: 0x0400037F RID: 895
	private byte Valid;

	// Token: 0x04000380 RID: 896
	private AudioSource Source;
}
