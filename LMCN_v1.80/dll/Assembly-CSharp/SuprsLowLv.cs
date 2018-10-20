using System;
using UnityEngine;

// Token: 0x02000743 RID: 1859
public class SuprsLowLv : TrapBehavior
{
	// Token: 0x060023A7 RID: 9127 RVA: 0x00413224 File Offset: 0x00411424
	public SuprsLowLv(Vector3[] defaultPos)
	{
		this.oriPos = defaultPos;
		this.hitParticleID = 2013;
	}

	// Token: 0x060023A8 RID: 9128 RVA: 0x00413258 File Offset: 0x00411458
	public override void Update(Transform[] suprs, float deltaTime)
	{
		if (this.trapState == 0)
		{
			return;
		}
		if (this.trapState == 1)
		{
			for (int i = 0; i < suprs.Length; i++)
			{
				suprs[i].localPosition = this.oriPos[i];
			}
			this.targetPosCache.Clear();
			this.posOffset = 0f;
			this.trapState = 2;
		}
		else if (this.trapState == 2)
		{
			this.posOffset += 6.6f * deltaTime;
			bool flag = false;
			if (this.posOffset >= 1f)
			{
				flag = true;
				this.posOffset = 1f;
				this.trapState = 3;
				this.timer = 0f;
			}
			for (int j = 0; j < suprs.Length; j++)
			{
				Vector3 localPosition = suprs[j].localPosition;
				localPosition.y = this.oriPos[j].y + 6f * this.posOffset;
				localPosition.x = this.oriPos[j].x - 6f * this.posOffset;
				suprs[j].localPosition = localPosition;
				if (flag)
				{
					Vector3 position = suprs[j].position;
					base.checkHitParticle(ref position);
				}
			}
		}
		else if (this.trapState == 3)
		{
			this.timer += deltaTime;
			if (this.timer >= 0.5f)
			{
				for (int k = 0; k < suprs.Length; k++)
				{
					this.posTemp[k] = suprs[k].localPosition;
				}
				this.trapState = 4;
				this.posOffset = 0f;
			}
		}
		else if (this.trapState == 4)
		{
			this.posOffset += 1f * deltaTime;
			if (this.posOffset >= 1f)
			{
				this.posOffset = 1f;
				this.trapState = 0;
			}
			for (int l = 0; l < suprs.Length; l++)
			{
				Vector3 localPosition2 = suprs[l].localPosition;
				localPosition2.y = this.posTemp[l].y - 6f * this.posOffset;
				localPosition2.x = this.posTemp[l].x + 6f * this.posOffset;
				suprs[l].localPosition = localPosition2;
			}
		}
	}

	// Token: 0x04006D1C RID: 27932
	private float posOffset;

	// Token: 0x04006D1D RID: 27933
	private Vector3[] posTemp = new Vector3[5];
}
