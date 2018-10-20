using System;
using UnityEngine;

// Token: 0x0200034C RID: 844
public class SpriteColorLerpLoop : MotionEffect
{
	// Token: 0x06001162 RID: 4450 RVA: 0x001E84D0 File Offset: 0x001E66D0
	public void SetSpriteRender(SpriteRenderer render)
	{
		this.Render = render;
		if (this.Render == null)
		{
			this.bMove = false;
		}
		else
		{
			this.bMove = true;
			MotionEffect.SetStack(this);
		}
	}

	// Token: 0x06001163 RID: 4451 RVA: 0x001E8510 File Offset: 0x001E6710
	public override bool UpdateRun(float delta)
	{
		if (!this.Reverse && this.Curtime < this.Halftime)
		{
			this.Render.color = Color.Lerp(this.a, this.b, this.Curtime / this.Halftime);
		}
		else
		{
			this.Reverse = true;
			this.Render.color = Color.Lerp(this.a, this.b, 1f - (this.Curtime - this.Halftime) / this.Halftime);
		}
		this.Curtime += delta;
		if (this.Curtime >= this.Halftime * 2f)
		{
			this.Reverse = false;
			this.Curtime = 0f;
		}
		return true;
	}

	// Token: 0x0400378E RID: 14222
	public Color a = Color.black;

	// Token: 0x0400378F RID: 14223
	public Color b = Color.white;

	// Token: 0x04003790 RID: 14224
	private SpriteRenderer Render;

	// Token: 0x04003791 RID: 14225
	private float Halftime = 1.5f;

	// Token: 0x04003792 RID: 14226
	private float Curtime;

	// Token: 0x04003793 RID: 14227
	private bool Reverse;
}
