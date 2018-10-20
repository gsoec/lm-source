using System;
using UnityEngine;

// Token: 0x02000348 RID: 840
public class JailBuildNotice : MonoBehaviour
{
	// Token: 0x06001150 RID: 4432 RVA: 0x001E802C File Offset: 0x001E622C
	public void Init(MapSpriteManager mapspriteManager)
	{
		this.mapspriteManager = mapspriteManager;
		this.JailNotice = new GameObject("ManorJailIcon", new Type[]
		{
			typeof(SpriteRenderer)
		}).GetComponent<SpriteRenderer>();
		this.JailNotice.sprite = mapspriteManager.GetSpriteByName("prompt_09");
		this.JailNotice.material = mapspriteManager.SpriteMaterial;
		this.JailNotice.color = Color.black;
		this.JailNotice.sortingOrder = -1;
		this.JailNotice.transform.SetParent(base.transform);
		this.JailNotice.transform.localScale = Vector3.one;
		this.JailNotice.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
		this.JailNotice.transform.localPosition = new Vector3(0.31f, 1.49f, 0.27f);
		this.Hide();
		this.UpdateData();
	}

	// Token: 0x06001151 RID: 4433 RVA: 0x001E8130 File Offset: 0x001E6330
	public void Hide()
	{
		this.JailNotice.enabled = false;
	}

	// Token: 0x06001152 RID: 4434 RVA: 0x001E8140 File Offset: 0x001E6340
	private void Show()
	{
		this.JailNotice.enabled = true;
	}

	// Token: 0x06001153 RID: 4435 RVA: 0x001E8150 File Offset: 0x001E6350
	public void UpdateData()
	{
		if (this.DM.Prisoner_Requested && this.DM.PrisonerNum > 0)
		{
			this.PrisonerIndex = this.DM.sortedPrisonerList[0];
			if (!this.DM.MySysSetting.bShowPrison || this.DM.PrisonerList[(int)this.PrisonerIndex].nowStat != PrisonerState.WaitForExecute)
			{
				this.PrisonerIndex = byte.MaxValue;
			}
		}
		else
		{
			this.PrisonerIndex = byte.MaxValue;
		}
		if (this.PrisonerIndex == 255)
		{
			this.Hide();
		}
	}

	// Token: 0x06001154 RID: 4436 RVA: 0x001E81F8 File Offset: 0x001E63F8
	public void UpdateTime()
	{
		if (this.PrisonerIndex != 255)
		{
			this.TotalTime = this.DM.PrisonerList[(int)this.PrisonerIndex].StartActionTime + (long)((ulong)this.DM.PrisonerList[(int)this.PrisonerIndex].TotalTime) - this.DM.ServerTime;
			if (this.TotalTime < 0L)
			{
				this.TotalTime = 0L;
			}
			if (this.TotalTime <= 21600L)
			{
				this.Show();
			}
			else
			{
				this.Hide();
			}
		}
	}

	// Token: 0x04003785 RID: 14213
	private SpriteRenderer JailNotice;

	// Token: 0x04003786 RID: 14214
	private MapSpriteManager mapspriteManager;

	// Token: 0x04003787 RID: 14215
	private byte PrisonerIndex = byte.MaxValue;

	// Token: 0x04003788 RID: 14216
	private long TotalTime;

	// Token: 0x04003789 RID: 14217
	private DataManager DM = DataManager.Instance;
}
