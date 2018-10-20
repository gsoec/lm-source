using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000312 RID: 786
public class UIAllianceRankAnime
{
	// Token: 0x1700007E RID: 126
	// (get) Token: 0x0600100E RID: 4110 RVA: 0x001C743C File Offset: 0x001C563C
	// (set) Token: 0x0600100F RID: 4111 RVA: 0x001C7444 File Offset: 0x001C5644
	public int FPS
	{
		get
		{
			return this.m_FPS;
		}
		set
		{
			this.m_FPS = value;
			this.m_SpriteIndex = 0;
			this.m_TickTime = 0f;
			this.m_ChangeTime = 1f / (float)this.m_FPS;
		}
	}

	// Token: 0x06001010 RID: 4112 RVA: 0x001C7480 File Offset: 0x001C5680
	public void SetSpriteIndex(int index)
	{
		if (this.m_Pivot == null || this.m_Pivot.Length != this.m_Sprites.Length)
		{
			this.CalculatePivot();
		}
		this.m_SpriteIndex = index;
		this.m_Image.sprite = this.m_Sprites[this.m_SpriteIndex];
		this.m_Image.rectTransform.pivot = this.m_Pivot[this.m_SpriteIndex];
		this.m_Image.SetNativeSize();
	}

	// Token: 0x06001011 RID: 4113 RVA: 0x001C7504 File Offset: 0x001C5704
	public void Update()
	{
		this.m_TickTime += Time.smoothDeltaTime;
		if (this.m_TickTime >= this.m_ChangeTime)
		{
			this.m_TickTime = 0f;
			if (this.m_Sprites != null && this.m_Image != null)
			{
				if (this.m_Pivot == null || this.m_Pivot.Length != this.m_Sprites.Length)
				{
					this.CalculatePivot();
				}
				this.m_SpriteIndex++;
				if (this.m_SpriteIndex >= this.m_Sprites.Length)
				{
					this.m_SpriteIndex = 0;
				}
				this.m_Image.sprite = this.m_Sprites[this.m_SpriteIndex];
				this.m_Image.rectTransform.pivot = this.m_Pivot[this.m_SpriteIndex];
				this.m_Image.SetNativeSize();
			}
		}
	}

	// Token: 0x06001012 RID: 4114 RVA: 0x001C75F4 File Offset: 0x001C57F4
	private void CalculatePivot()
	{
		if (this.m_Sprites != null)
		{
			this.m_Pivot = new Vector2[this.m_Sprites.Length];
			for (int i = 0; i < this.m_Sprites.Length; i++)
			{
				if (!(this.m_Sprites[i] == null))
				{
					this.m_Pivot[i].x = 0.5f + -this.m_Sprites[i].bounds.center.x / this.m_Sprites[i].bounds.extents.x / 2f;
					this.m_Pivot[i].y = 0.5f + -this.m_Sprites[i].bounds.center.y / this.m_Sprites[i].bounds.extents.y / 2f;
				}
			}
		}
	}

	// Token: 0x040034A0 RID: 13472
	public Sprite[] m_Sprites;

	// Token: 0x040034A1 RID: 13473
	public Vector2[] m_Pivot;

	// Token: 0x040034A2 RID: 13474
	public Image m_Image;

	// Token: 0x040034A3 RID: 13475
	private int m_SpriteIndex;

	// Token: 0x040034A4 RID: 13476
	private float m_TickTime;

	// Token: 0x040034A5 RID: 13477
	private float m_ChangeTime = 0.0667f;

	// Token: 0x040034A6 RID: 13478
	private int m_FPS = 15;
}
