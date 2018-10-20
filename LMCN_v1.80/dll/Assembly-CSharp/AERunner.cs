using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020007BF RID: 1983
internal class AERunner
{
	// Token: 0x060028FD RID: 10493 RVA: 0x0044BBB4 File Offset: 0x00449DB4
	public AERunner(RectTransform ActiveObject)
	{
		this.ObjectRTF = ActiveObject;
		this.SetTime(0f, false);
	}

	// Token: 0x060028FE RID: 10494 RVA: 0x0044BBD0 File Offset: 0x00449DD0
	public void SetTime(float toTime = 0f, bool StartNow = true)
	{
		this.PositionStage = 1;
		this.ScaleStage = 1;
		this.RotationStage = 1;
		this.AlphaStage = 1;
		this.AnimationTime = toTime;
		this.Active = StartNow;
	}

	// Token: 0x060028FF RID: 10495 RVA: 0x0044BC08 File Offset: 0x00449E08
	public void Pause(bool UnPause = false)
	{
		this.Active = UnPause;
	}

	// Token: 0x06002900 RID: 10496 RVA: 0x0044BC14 File Offset: 0x00449E14
	public void Update()
	{
		if (this.Active)
		{
			this.UpdateDeltaTime();
			this.UpdateAnimationUnit();
		}
	}

	// Token: 0x06002901 RID: 10497 RVA: 0x0044BC30 File Offset: 0x00449E30
	public void SetEndRecall(IAERunnerEndHandler iEndHandler)
	{
		this._EndHandler = iEndHandler;
	}

	// Token: 0x06002902 RID: 10498 RVA: 0x0044BC3C File Offset: 0x00449E3C
	public void UpdateDeltaTime()
	{
		this.AnimationTime += Time.deltaTime;
		if (this.AnimationTime >= this.LastKey)
		{
			this.Active = false;
			if (this._EndHandler != null)
			{
				this._EndHandler.OnAERunnerEnd(this.mRunner_ID1, this.mRunner_ID2);
			}
		}
	}

	// Token: 0x06002903 RID: 10499 RVA: 0x0044BC98 File Offset: 0x00449E98
	public void CheckLastKey()
	{
		this.LastKey = 0f;
		for (int i = 0; i < this.ActiveKind.Length; i++)
		{
			switch (this.ActiveKind[i])
			{
			case AERunner.AEType.position:
				if (this.PositionKey[this.PositionKey.Length - 1] > this.LastKey)
				{
					this.LastKey = this.PositionKey[this.PositionKey.Length - 1];
				}
				break;
			case AERunner.AEType.scale:
				if (this.ScaleKey[this.ScaleKey.Length - 1] > this.LastKey)
				{
					this.LastKey = this.ScaleKey[this.ScaleKey.Length - 1];
				}
				break;
			case AERunner.AEType.rotation:
				if (this.RotationKey[this.RotationKey.Length - 1] > this.LastKey)
				{
					this.LastKey = this.RotationKey[this.RotationKey.Length - 1];
				}
				break;
			case AERunner.AEType.alpha:
				if (this.AlphaKey[this.AlphaKey.Length - 1] > this.LastKey)
				{
					this.LastKey = this.AlphaKey[this.AlphaKey.Length - 1];
				}
				break;
			}
		}
	}

	// Token: 0x06002904 RID: 10500 RVA: 0x0044BDD0 File Offset: 0x00449FD0
	public void UpdateAnimationUnit()
	{
		for (int i = 0; i < this.ActiveKind.Length; i++)
		{
			switch (this.ActiveKind[i])
			{
			case AERunner.AEType.position:
				this.UpdatePosition();
				break;
			case AERunner.AEType.scale:
				this.UpdateScale();
				break;
			case AERunner.AEType.rotation:
				this.UpdateRotation();
				break;
			case AERunner.AEType.alpha:
				this.UpdateAlpha();
				break;
			}
		}
	}

	// Token: 0x06002905 RID: 10501 RVA: 0x0044BE48 File Offset: 0x0044A048
	private void UpdatePosition()
	{
		if (this.PositionKey.Length > this.PositionStage)
		{
			while (this.PositionKey.Length > this.PositionStage && this.AnimationTime > this.PositionKey[this.PositionStage])
			{
				this.PositionStage++;
			}
			if (this.PositionKey.Length == this.PositionStage)
			{
				this.ObjectRTF.anchoredPosition = this.PositionValue[this.PositionStage - 1] + this.CenterPivot;
				return;
			}
			this.ObjectRTF.anchoredPosition = Vector2.Lerp(this.PositionValue[this.PositionStage - 1], this.PositionValue[this.PositionStage], Mathf.InverseLerp(this.PositionKey[this.PositionStage - 1], this.PositionKey[this.PositionStage], this.AnimationTime)) + this.CenterPivot;
		}
	}

	// Token: 0x06002906 RID: 10502 RVA: 0x0044BF58 File Offset: 0x0044A158
	private void UpdateRotation()
	{
		if (this.RotationKey.Length > this.RotationStage)
		{
			while (this.RotationKey.Length > this.RotationStage && this.AnimationTime > this.RotationKey[this.RotationStage])
			{
				this.RotationStage++;
			}
			if (this.RotationKey.Length == this.RotationStage)
			{
				this.ObjectRTF.localEulerAngles = new Vector3(0f, 0f, this.RotationValue[this.RotationStage - 1]);
				return;
			}
			this.ObjectRTF.localEulerAngles = new Vector3(0f, 0f, Mathf.Lerp(this.RotationValue[this.RotationStage - 1], this.RotationValue[this.RotationStage], Mathf.InverseLerp(this.RotationKey[this.RotationStage - 1], this.RotationKey[this.RotationStage], this.AnimationTime)));
		}
	}

	// Token: 0x06002907 RID: 10503 RVA: 0x0044C058 File Offset: 0x0044A258
	private void UpdateScale()
	{
		if (this.ScaleKey.Length > this.ScaleStage)
		{
			while (this.ScaleKey.Length > this.ScaleStage && this.AnimationTime > this.ScaleKey[this.ScaleStage])
			{
				this.ScaleStage++;
			}
			if (this.ScaleKey.Length == this.ScaleStage)
			{
				this.ObjectRTF.localScale = new Vector3(this.ScaleValue[this.ScaleStage - 1].x, this.ScaleValue[this.ScaleStage - 1].y, 1f);
				return;
			}
			Vector3 localScale = Vector3.Lerp(this.ScaleValue[this.ScaleStage - 1], this.ScaleValue[this.ScaleStage], Mathf.InverseLerp(this.ScaleKey[this.ScaleStage - 1], this.ScaleKey[this.ScaleStage], this.AnimationTime));
			this.ObjectRTF.localScale = localScale;
		}
	}

	// Token: 0x06002908 RID: 10504 RVA: 0x0044C180 File Offset: 0x0044A380
	private void UpdateAlpha()
	{
		if (this.AlphaKey.Length > this.AlphaStage)
		{
			while (this.AlphaKey.Length > this.AlphaStage && this.AnimationTime > this.AlphaKey[this.AlphaStage])
			{
				this.AlphaStage++;
			}
			if (this.AlphaKey.Length == this.AlphaStage)
			{
				Color alphaArray = new Color(1f, 1f, 1f, this.AlphaValue[this.AlphaStage - 1]);
				this.SetAlphaArray(alphaArray);
				return;
			}
			Color alphaArray2 = new Color(1f, 1f, 1f, Mathf.Lerp(this.AlphaValue[this.AlphaStage - 1], this.AlphaValue[this.AlphaStage], Mathf.InverseLerp(this.AlphaKey[this.AlphaStage - 1], this.AlphaKey[this.AlphaStage], this.AnimationTime)) / 100f);
			this.SetAlphaArray(alphaArray2);
		}
	}

	// Token: 0x06002909 RID: 10505 RVA: 0x0044C28C File Offset: 0x0044A48C
	private void SetAlphaArray(Color color)
	{
		if (this.AlphaApplyImages == null)
		{
			return;
		}
		for (int i = 0; i < this.AlphaApplyImages.Length; i++)
		{
			this.AlphaApplyImages[i].color = color;
		}
	}

	// Token: 0x04007336 RID: 29494
	private RectTransform ObjectRTF;

	// Token: 0x04007337 RID: 29495
	public Vector2 CenterPivot;

	// Token: 0x04007338 RID: 29496
	private bool Active;

	// Token: 0x04007339 RID: 29497
	public AERunner.AEType[] ActiveKind;

	// Token: 0x0400733A RID: 29498
	public float[] PositionKey;

	// Token: 0x0400733B RID: 29499
	public Vector2[] PositionValue;

	// Token: 0x0400733C RID: 29500
	public float[] ScaleKey;

	// Token: 0x0400733D RID: 29501
	public Vector2[] ScaleValue;

	// Token: 0x0400733E RID: 29502
	public float[] RotationKey;

	// Token: 0x0400733F RID: 29503
	public float[] RotationValue;

	// Token: 0x04007340 RID: 29504
	public float[] AlphaKey;

	// Token: 0x04007341 RID: 29505
	public float[] AlphaValue;

	// Token: 0x04007342 RID: 29506
	private int PositionStage;

	// Token: 0x04007343 RID: 29507
	private int ScaleStage;

	// Token: 0x04007344 RID: 29508
	private int RotationStage;

	// Token: 0x04007345 RID: 29509
	private int AlphaStage;

	// Token: 0x04007346 RID: 29510
	public Image[] AlphaApplyImages;

	// Token: 0x04007347 RID: 29511
	private float AnimationTime;

	// Token: 0x04007348 RID: 29512
	private IAERunnerEndHandler _EndHandler;

	// Token: 0x04007349 RID: 29513
	private float LastKey;

	// Token: 0x0400734A RID: 29514
	public int mRunner_ID1;

	// Token: 0x0400734B RID: 29515
	public int mRunner_ID2;

	// Token: 0x020007C0 RID: 1984
	public enum AEType : byte
	{
		// Token: 0x0400734D RID: 29517
		position,
		// Token: 0x0400734E RID: 29518
		scale,
		// Token: 0x0400734F RID: 29519
		rotation,
		// Token: 0x04007350 RID: 29520
		alpha
	}
}
