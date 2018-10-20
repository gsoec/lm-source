using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020007F9 RID: 2041
public class SpriteAnimation : MonoBehaviour
{
	// Token: 0x17000132 RID: 306
	// (get) Token: 0x06002A59 RID: 10841 RVA: 0x0046E4C0 File Offset: 0x0046C6C0
	// (set) Token: 0x06002A5A RID: 10842 RVA: 0x0046E4C8 File Offset: 0x0046C6C8
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

	// Token: 0x06002A5B RID: 10843 RVA: 0x0046E504 File Offset: 0x0046C704
	private void Update()
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

	// Token: 0x06002A5C RID: 10844 RVA: 0x0046E5F4 File Offset: 0x0046C7F4
	private void CalculatePivot()
	{
		if (this.m_Sprites != null)
		{
			this.m_Image.rectTransform.localScale = new Vector3(0.53f, 0.53f, 0.53f);
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

	// Token: 0x04007622 RID: 30242
	public Sprite[] m_Sprites;

	// Token: 0x04007623 RID: 30243
	public Vector2[] m_Pivot;

	// Token: 0x04007624 RID: 30244
	public Image m_Image;

	// Token: 0x04007625 RID: 30245
	private int m_SpriteIndex;

	// Token: 0x04007626 RID: 30246
	private float m_TickTime;

	// Token: 0x04007627 RID: 30247
	private float m_ChangeTime = 0.0667f;

	// Token: 0x04007628 RID: 30248
	private int m_FPS = 15;
}
