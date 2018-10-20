using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001E1 RID: 481
public class Fader : Image
{
	// Token: 0x060008D1 RID: 2257 RVA: 0x000B5428 File Offset: 0x000B3628
	public void Reset()
	{
		this._color.a = 0f;
		base.color = this._color;
		this.bWorking = false;
	}

	// Token: 0x060008D2 RID: 2258 RVA: 0x000B5450 File Offset: 0x000B3650
	public void Update()
	{
		if (this.bWorking)
		{
			float num = this._color.a + Time.deltaTime * this.speed;
			if (num > 1f)
			{
				num = 1f;
				this.bWorking = false;
			}
			this._color.a = num;
			base.color = this._color;
		}
	}

	// Token: 0x060008D3 RID: 2259 RVA: 0x000B54B4 File Offset: 0x000B36B4
	public void Action()
	{
		this.bWorking = true;
	}

	// Token: 0x04001D71 RID: 7537
	private bool bWorking;

	// Token: 0x04001D72 RID: 7538
	private float speed = 0.5f;

	// Token: 0x04001D73 RID: 7539
	private Color _color = new Color(0f, 0f, 0f, 0f);
}
