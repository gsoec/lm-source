using System;
using UnityEngine;

// Token: 0x02000742 RID: 1858
public class SuprsHighLv : TrapBehavior
{
	// Token: 0x060023A5 RID: 9125 RVA: 0x00412F50 File Offset: 0x00411150
	public SuprsHighLv(Vector3[] defaultPos)
	{
		this.oriPos = defaultPos;
		this.hitParticleID = 2013;
	}

	// Token: 0x060023A6 RID: 9126 RVA: 0x00412F6C File Offset: 0x0041116C
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
				Vector3 localPosition = suprs[i].localPosition;
				localPosition.y = -5f;
				suprs[i].localPosition = localPosition;
			}
			this.targetPosCache.Clear();
			this.trapState = 2;
		}
		else if (this.trapState == 2)
		{
			float num = suprs[0].localPosition.y + 25f * deltaTime;
			bool flag = false;
			if (num >= 0f)
			{
				flag = true;
				num = 0f;
				this.trapState = 3;
			}
			for (int j = 0; j < suprs.Length; j++)
			{
				Vector3 localPosition2 = suprs[j].localPosition;
				localPosition2.y = num;
				suprs[j].localPosition = localPosition2;
				if (flag)
				{
					Vector3 position = suprs[j].position;
					base.checkHitParticle(ref position);
				}
			}
		}
		else if (this.trapState == 3)
		{
			float num2 = suprs[0].localPosition.y - 10f * deltaTime;
			if (num2 <= -1f)
			{
				num2 = -1f;
				this.trapState = 4;
				this.timer = 0f;
			}
			for (int k = 0; k < suprs.Length; k++)
			{
				Vector3 localPosition3 = suprs[k].localPosition;
				localPosition3.y = num2;
				suprs[k].localPosition = localPosition3;
			}
		}
		else if (this.trapState == 4)
		{
			this.timer += deltaTime;
			if (this.timer >= 0.5f)
			{
				this.trapState = 5;
			}
		}
		else if (this.trapState == 5)
		{
			float num3 = suprs[0].localPosition.y + 5f * deltaTime;
			if (num3 >= 0f)
			{
				num3 = 0f;
				this.trapState = 6;
			}
			for (int l = 0; l < suprs.Length; l++)
			{
				Vector3 localPosition4 = suprs[l].localPosition;
				localPosition4.y = num3;
				suprs[l].localPosition = localPosition4;
			}
		}
		else if (this.trapState == 6)
		{
			float num4 = suprs[0].localPosition.y - 25f * deltaTime;
			if (num4 <= -5f)
			{
				num4 = -5f;
				this.trapState = 0;
			}
			for (int m = 0; m < suprs.Length; m++)
			{
				Vector3 localPosition5 = suprs[m].localPosition;
				localPosition5.y = num4;
				suprs[m].localPosition = localPosition5;
			}
		}
	}
}
