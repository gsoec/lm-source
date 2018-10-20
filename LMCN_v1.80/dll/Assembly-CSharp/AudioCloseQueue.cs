using System;
using UnityEngine;

// Token: 0x0200003F RID: 63
public class AudioCloseQueue
{
	// Token: 0x06000177 RID: 375 RVA: 0x00017A40 File Offset: 0x00015C40
	public void SetAudio(AudioSource audioSource, byte key, float MaxTime = 1.5f)
	{
		this.audioSource = audioSource;
		this.key = key;
		this.FadeTime = 0f;
		this.bUpdate = true;
		this.MaxFadeTime = MaxTime;
	}

	// Token: 0x06000178 RID: 376 RVA: 0x00017A6C File Offset: 0x00015C6C
	public void Update()
	{
		if (!this.bUpdate)
		{
			return;
		}
		if (this.audioSource == null)
		{
			this.bUpdate = false;
			return;
		}
		this.audioSource.volume = AudioManager.Instance.OutQuintic(this.FadeTime, 1f, -1f, this.MaxFadeTime);
		if (this.FadeTime > this.MaxFadeTime)
		{
			this.audioSource.Stop();
			this.bUpdate = false;
			AudioManager.Instance.NotifyCloseSFX(this.key);
		}
		else
		{
			this.FadeTime += Time.deltaTime;
		}
	}

	// Token: 0x0400037A RID: 890
	public float FadeTime;

	// Token: 0x0400037B RID: 891
	public float MaxFadeTime;

	// Token: 0x0400037C RID: 892
	public byte key;

	// Token: 0x0400037D RID: 893
	public AudioSource audioSource;

	// Token: 0x0400037E RID: 894
	private bool bUpdate;
}
