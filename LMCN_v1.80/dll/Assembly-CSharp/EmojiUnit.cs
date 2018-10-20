using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000193 RID: 403
public class EmojiUnit
{
	// Token: 0x060005C2 RID: 1474 RVA: 0x0007FA0C File Offset: 0x0007DC0C
	public EmojiUnit()
	{
		this.EmojiUnitIni(0);
		this.EmojiPivots = new List<Vector2>(4);
	}

	// Token: 0x060005C3 RID: 1475 RVA: 0x0007FA28 File Offset: 0x0007DC28
	public void EmojiUnitIni(byte defaultsprite = 0)
	{
		this.SheetID = 0;
		this.defaultSheetID = defaultsprite;
		this.AnimationTimer = 1f;
		this.Start();
	}

	// Token: 0x060005C4 RID: 1476 RVA: 0x0007FA4C File Offset: 0x0007DC4C
	public void setImagePivot()
	{
		Vector2 value = Vector2.zero;
		for (int i = 0; i < this.SpriteMove.Length; i++)
		{
			if (this.EmojiPivots.Count <= i)
			{
				this.EmojiPivots.Add(Vector2.zero);
			}
			else
			{
				value = this.EmojiPivots[i];
			}
			if (this.SpriteMove[i] != null)
			{
				value.x = 0.5f + -this.SpriteMove[i].bounds.center.x / this.SpriteMove[i].bounds.extents.x / 2f;
				value.y = 0.5f + -this.SpriteMove[i].bounds.center.y / this.SpriteMove[i].bounds.extents.y / 2f;
			}
			this.EmojiPivots[i] = value;
		}
		if (this.SpriteMove.Length <= 1)
		{
			this.EmojiImage.sprite = this.SpriteMove[0];
			this.EmojiImage.rectTransform.pivot = this.EmojiPivots[0];
			this.EmojiImage.SetNativeSize();
		}
	}

	// Token: 0x060005C5 RID: 1477 RVA: 0x0007FBB8 File Offset: 0x0007DDB8
	public void DefaultSprite()
	{
		this.SheetID = this.defaultSheetID;
		this.setSprite();
		this.Stop();
	}

	// Token: 0x060005C6 RID: 1478 RVA: 0x0007FBD4 File Offset: 0x0007DDD4
	public void Start()
	{
		this.AnimationSpeed = 15f;
	}

	// Token: 0x060005C7 RID: 1479 RVA: 0x0007FBE4 File Offset: 0x0007DDE4
	public void Stop()
	{
		this.AnimationSpeed = 0f;
	}

	// Token: 0x060005C8 RID: 1480 RVA: 0x0007FBF4 File Offset: 0x0007DDF4
	public void Run()
	{
		if (this.SpriteMove.Length > 1)
		{
			this.AnimationTimer -= Time.deltaTime * this.AnimationSpeed;
			if (this.AnimationTimer < 0f)
			{
				this.AnimationTimer = 1f;
				this.setSprite();
				if ((int)(this.SheetID += 1) >= this.SpriteMove.Length)
				{
					this.SheetID = 0;
				}
			}
		}
	}

	// Token: 0x060005C9 RID: 1481 RVA: 0x0007FC70 File Offset: 0x0007DE70
	private void setSprite()
	{
		if (this.EmojiImage == null)
		{
			this.EmojiSpriteRenderer.sprite = this.SpriteMove[(int)this.SheetID];
		}
		else
		{
			this.EmojiImage.sprite = this.SpriteMove[(int)this.SheetID];
			this.EmojiImage.rectTransform.pivot = this.EmojiPivots[(int)this.SheetID];
			this.EmojiImage.SetNativeSize();
		}
	}

	// Token: 0x040016A0 RID: 5792
	public byte EmojiType;

	// Token: 0x040016A1 RID: 5793
	public byte SheetID;

	// Token: 0x040016A2 RID: 5794
	public byte defaultSheetID;

	// Token: 0x040016A3 RID: 5795
	public ushort IconID;

	// Token: 0x040016A4 RID: 5796
	public int poolID;

	// Token: 0x040016A5 RID: 5797
	public float AnimationSpeed;

	// Token: 0x040016A6 RID: 5798
	private float AnimationTimer;

	// Token: 0x040016A7 RID: 5799
	public Sprite[] SpriteMove;

	// Token: 0x040016A8 RID: 5800
	public Transform EmojiTransform;

	// Token: 0x040016A9 RID: 5801
	public Image EmojiImage;

	// Token: 0x040016AA RID: 5802
	public List<Vector2> EmojiPivots;

	// Token: 0x040016AB RID: 5803
	public SpriteRenderer EmojiSpriteRenderer;
}
