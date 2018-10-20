using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000310 RID: 784
public class UIAlliance_Control
{
	// Token: 0x1700007D RID: 125
	// (get) Token: 0x06001007 RID: 4103 RVA: 0x001C715C File Offset: 0x001C535C
	public RectTransform rectTransform
	{
		get
		{
			if (this.ImgRect == null)
			{
				this.ImgRect = this.animImg.rectTransform;
			}
			return this.ImgRect;
		}
	}

	// Token: 0x06001008 RID: 4104 RVA: 0x001C7194 File Offset: 0x001C5394
	public void Initial(Image animImg)
	{
		this.animImg = animImg;
		SheetAnimationUnitGroup.sharedMat.renderQueue = 3000;
		this.animImg.material = SheetAnimationUnitGroup.sharedMat;
		this.spriteAnim = new UIAllianceRankAnime();
		this.spriteAnim.m_Image = animImg;
	}

	// Token: 0x06001009 RID: 4105 RVA: 0x001C71D4 File Offset: 0x001C53D4
	public void SetAnimState(UIAlliance_Control.eRankState state)
	{
		if (state == UIAlliance_Control.eRankState.RankUp || state == UIAlliance_Control.eRankState.RankEqual)
		{
			this.State = 9;
		}
		else
		{
			this.State = 22;
		}
		this.Angle = 270f;
		this.spriteAnim.m_Sprites = SheetAnimationUnitGroup.GetActionSpriteArray(0, this.State, this.Angle);
		this.spriteAnim.SetSpriteIndex(0);
	}

	// Token: 0x0600100A RID: 4106 RVA: 0x001C7238 File Offset: 0x001C5438
	public void MoveTo(Transform DestTran, float Z, float angle, float speed = 1f)
	{
		this.Source = this.animImg.transform.localPosition;
		this.Destination = DestTran.localPosition;
		this.DeltaTime = 0f;
		this.Destination.z = Z;
		this.Source.z = Z;
		if (angle > 180f)
		{
			this.rectTransform.localRotation = new Quaternion(0f, 180f, 0f, 0f);
		}
		this.spriteAnim.m_Sprites = SheetAnimationUnitGroup.GetActionSpriteArray(0, this.State, angle);
		this.spriteAnim.SetSpriteIndex(0);
		this.SpeedTime = speed;
	}

	// Token: 0x0600100B RID: 4107 RVA: 0x001C72E8 File Offset: 0x001C54E8
	public void Destroy()
	{
		SheetAnimationUnitGroup.sharedMat.renderQueue = 2660;
	}

	// Token: 0x0600100C RID: 4108 RVA: 0x001C72FC File Offset: 0x001C54FC
	public void Update()
	{
		if (!this.ImgRect.gameObject.activeSelf)
		{
			return;
		}
		if (this.animImg != null)
		{
			if (this.spriteAnim != null)
			{
				this.spriteAnim.Update();
			}
			if (this.SpeedTime > 0f)
			{
				if (this.SpeedTime <= this.DeltaTime)
				{
					this.SpeedTime = 0f;
					this.animImg.transform.localPosition = this.Destination;
					this.rectTransform.localRotation = new Quaternion(0f, 0f, 0f, 0f);
					this.spriteAnim.m_Sprites = SheetAnimationUnitGroup.GetActionSpriteArray(0, this.State, this.Angle);
				}
				else
				{
					this.animImg.transform.localPosition = this.Source + (this.Destination - this.Source) * (this.DeltaTime / this.SpeedTime);
					this.DeltaTime += Time.deltaTime;
				}
			}
		}
	}

	// Token: 0x04003493 RID: 13459
	public Image animImg;

	// Token: 0x04003494 RID: 13460
	private UIAllianceRankAnime spriteAnim;

	// Token: 0x04003495 RID: 13461
	private Vector3 Source;

	// Token: 0x04003496 RID: 13462
	private Vector3 Destination;

	// Token: 0x04003497 RID: 13463
	private float DeltaTime;

	// Token: 0x04003498 RID: 13464
	private float SpeedTime;

	// Token: 0x04003499 RID: 13465
	private byte State;

	// Token: 0x0400349A RID: 13466
	private float Angle;

	// Token: 0x0400349B RID: 13467
	private RectTransform ImgRect;

	// Token: 0x02000311 RID: 785
	public enum eRankState
	{
		// Token: 0x0400349D RID: 13469
		RankUp,
		// Token: 0x0400349E RID: 13470
		RankDown,
		// Token: 0x0400349F RID: 13471
		RankEqual
	}
}
