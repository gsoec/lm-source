using System;
using UnityEngine;

// Token: 0x02000038 RID: 56
public class ClipInfo
{
	// Token: 0x06000175 RID: 373 RVA: 0x000179EC File Offset: 0x00015BEC
	public void clear()
	{
		this.clip = null;
		this.Volume = 1f;
		this.Pitch = 1f;
		this.PanLevel = 1f;
		this.Loop = false;
		this.DelaySecond = null;
	}

	// Token: 0x0400030A RID: 778
	public AudioClip clip;

	// Token: 0x0400030B RID: 779
	public float Volume = 1f;

	// Token: 0x0400030C RID: 780
	public float Pitch = 1f;

	// Token: 0x0400030D RID: 781
	public float PanLevel = 1f;

	// Token: 0x0400030E RID: 782
	public bool Loop;

	// Token: 0x0400030F RID: 783
	public float? DelaySecond;
}
