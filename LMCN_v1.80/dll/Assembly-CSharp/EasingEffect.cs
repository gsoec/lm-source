using System;
using UnityEngine;

// Token: 0x0200034B RID: 843
public class EasingEffect : MotionEffect
{
	// Token: 0x0600115D RID: 4445 RVA: 0x001E8364 File Offset: 0x001E6564
	public static float Quintic(float t, float b, float c, float d)
	{
		float num = (t /= d) * t;
		float num2 = num * t;
		return b + c * (num2 * num);
	}

	// Token: 0x0600115E RID: 4446 RVA: 0x001E8388 File Offset: 0x001E6588
	public static float Linear(float t, float b, float c, float d)
	{
		t /= d;
		return b + c * t;
	}

	// Token: 0x0600115F RID: 4447 RVA: 0x001E8394 File Offset: 0x001E6594
	public static float Bounce(float t, float b, float c, float d)
	{
		if ((double)(t /= d) < 0.36363636363636365)
		{
			Debug.Log(1);
			return c * (7.5625f * t * t) + b;
		}
		if ((double)t < 0.72727272727272729)
		{
			Debug.Log(2);
			return c * (7.5625f * (t -= 0.545454562f) * t + 0.75f) + b;
		}
		if ((double)t < 0.90909090909090906)
		{
			Debug.Log(3);
			return c * (7.5625f * (t -= 0.8181818f) * t + 0.9375f) + b;
		}
		Debug.Log(4);
		return c * (7.5625f * (t -= 0.954545438f) * t + 0.984375f) + b;
	}

	// Token: 0x06001160 RID: 4448 RVA: 0x001E8468 File Offset: 0x001E6668
	public static float InQuadratic(float t, float b, float c, float d)
	{
		float num = (t /= d) * t;
		float num2 = num * t;
		return b + c * (4.1f * num2 * num + -4.3f * num * num + 1.2f * num2);
	}
}
