using System;
using UnityEngine;

namespace uTools
{
	// Token: 0x020007FC RID: 2044
	public class EaseManager
	{
		// Token: 0x06002A5E RID: 10846 RVA: 0x0046E734 File Offset: 0x0046C934
		private static float linear(float start, float end, float value)
		{
			return Mathf.Lerp(start, end, value);
		}

		// Token: 0x06002A5F RID: 10847 RVA: 0x0046E740 File Offset: 0x0046C940
		private static float clerp(float start, float end, float value)
		{
			float num = 0f;
			float num2 = 360f;
			float num3 = Mathf.Abs((num2 - num) / 2f);
			float result;
			if (end - start < -num3)
			{
				float num4 = (num2 - start + end) * value;
				result = start + num4;
			}
			else if (end - start > num3)
			{
				float num4 = -(num2 - end + start) * value;
				result = start + num4;
			}
			else
			{
				result = start + (end - start) * value;
			}
			return result;
		}

		// Token: 0x06002A60 RID: 10848 RVA: 0x0046E7B8 File Offset: 0x0046C9B8
		private static float spring(float start, float end, float value)
		{
			value = Mathf.Clamp01(value);
			value = (Mathf.Sin(value * 3.14159274f * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + 1.2f * (1f - value));
			return start + (end - start) * value;
		}

		// Token: 0x06002A61 RID: 10849 RVA: 0x0046E81C File Offset: 0x0046CA1C
		private static float easeInQuad(float start, float end, float value)
		{
			end -= start;
			return end * value * value + start;
		}

		// Token: 0x06002A62 RID: 10850 RVA: 0x0046E82C File Offset: 0x0046CA2C
		private static float easeOutQuad(float start, float end, float value)
		{
			end -= start;
			return -end * value * (value - 2f) + start;
		}

		// Token: 0x06002A63 RID: 10851 RVA: 0x0046E844 File Offset: 0x0046CA44
		private static float easeInOutQuad(float start, float end, float value)
		{
			value /= 0.5f;
			end -= start;
			if (value < 1f)
			{
				return end / 2f * value * value + start;
			}
			value -= 1f;
			return -end / 2f * (value * (value - 2f) - 1f) + start;
		}

		// Token: 0x06002A64 RID: 10852 RVA: 0x0046E89C File Offset: 0x0046CA9C
		private static float easeInCubic(float start, float end, float value)
		{
			end -= start;
			return end * value * value * value + start;
		}

		// Token: 0x06002A65 RID: 10853 RVA: 0x0046E8AC File Offset: 0x0046CAAC
		private static float easeOutCubic(float start, float end, float value)
		{
			value -= 1f;
			end -= start;
			return end * (value * value * value + 1f) + start;
		}

		// Token: 0x06002A66 RID: 10854 RVA: 0x0046E8CC File Offset: 0x0046CACC
		private static float easeInOutCubic(float start, float end, float value)
		{
			value /= 0.5f;
			end -= start;
			if (value < 1f)
			{
				return end / 2f * value * value * value + start;
			}
			value -= 2f;
			return end / 2f * (value * value * value + 2f) + start;
		}

		// Token: 0x06002A67 RID: 10855 RVA: 0x0046E920 File Offset: 0x0046CB20
		private static float easeInQuart(float start, float end, float value)
		{
			end -= start;
			return end * value * value * value * value + start;
		}

		// Token: 0x06002A68 RID: 10856 RVA: 0x0046E934 File Offset: 0x0046CB34
		private static float easeOutQuart(float start, float end, float value)
		{
			value -= 1f;
			end -= start;
			return -end * (value * value * value * value - 1f) + start;
		}

		// Token: 0x06002A69 RID: 10857 RVA: 0x0046E964 File Offset: 0x0046CB64
		private static float easeInOutQuart(float start, float end, float value)
		{
			value /= 0.5f;
			end -= start;
			if (value < 1f)
			{
				return end / 2f * value * value * value * value + start;
			}
			value -= 2f;
			return -end / 2f * (value * value * value * value - 2f) + start;
		}

		// Token: 0x06002A6A RID: 10858 RVA: 0x0046E9C0 File Offset: 0x0046CBC0
		private static float easeInQuint(float start, float end, float value)
		{
			end -= start;
			return end * value * value * value * value * value + start;
		}

		// Token: 0x06002A6B RID: 10859 RVA: 0x0046E9D4 File Offset: 0x0046CBD4
		private static float easeOutQuint(float start, float end, float value)
		{
			value -= 1f;
			end -= start;
			return end * (value * value * value * value * value + 1f) + start;
		}

		// Token: 0x06002A6C RID: 10860 RVA: 0x0046E9F8 File Offset: 0x0046CBF8
		private static float easeInOutQuint(float start, float end, float value)
		{
			value /= 0.5f;
			end -= start;
			if (value < 1f)
			{
				return end / 2f * value * value * value * value * value + start;
			}
			value -= 2f;
			return end / 2f * (value * value * value * value * value + 2f) + start;
		}

		// Token: 0x06002A6D RID: 10861 RVA: 0x0046EA54 File Offset: 0x0046CC54
		private static float easeInSine(float start, float end, float value)
		{
			end -= start;
			return -end * Mathf.Cos(value / 1f * 1.57079637f) + end + start;
		}

		// Token: 0x06002A6E RID: 10862 RVA: 0x0046EA74 File Offset: 0x0046CC74
		private static float easeOutSine(float start, float end, float value)
		{
			end -= start;
			return end * Mathf.Sin(value / 1f * 1.57079637f) + start;
		}

		// Token: 0x06002A6F RID: 10863 RVA: 0x0046EA94 File Offset: 0x0046CC94
		private static float easeInOutSine(float start, float end, float value)
		{
			end -= start;
			return -end / 2f * (Mathf.Cos(3.14159274f * value / 1f) - 1f) + start;
		}

		// Token: 0x06002A70 RID: 10864 RVA: 0x0046EACC File Offset: 0x0046CCCC
		private static float easeInExpo(float start, float end, float value)
		{
			end -= start;
			return end * Mathf.Pow(2f, 10f * (value / 1f - 1f)) + start;
		}

		// Token: 0x06002A71 RID: 10865 RVA: 0x0046EB00 File Offset: 0x0046CD00
		private static float easeOutExpo(float start, float end, float value)
		{
			end -= start;
			return end * (-Mathf.Pow(2f, -10f * value / 1f) + 1f) + start;
		}

		// Token: 0x06002A72 RID: 10866 RVA: 0x0046EB2C File Offset: 0x0046CD2C
		private static float easeInOutExpo(float start, float end, float value)
		{
			value /= 0.5f;
			end -= start;
			if (value < 1f)
			{
				return end / 2f * Mathf.Pow(2f, 10f * (value - 1f)) + start;
			}
			value -= 1f;
			return end / 2f * (-Mathf.Pow(2f, -10f * value) + 2f) + start;
		}

		// Token: 0x06002A73 RID: 10867 RVA: 0x0046EBA0 File Offset: 0x0046CDA0
		private static float easeInCirc(float start, float end, float value)
		{
			end -= start;
			return -end * (Mathf.Sqrt(1f - value * value) - 1f) + start;
		}

		// Token: 0x06002A74 RID: 10868 RVA: 0x0046EBC0 File Offset: 0x0046CDC0
		private static float easeOutCirc(float start, float end, float value)
		{
			value -= 1f;
			end -= start;
			return end * Mathf.Sqrt(1f - value * value) + start;
		}

		// Token: 0x06002A75 RID: 10869 RVA: 0x0046EBF0 File Offset: 0x0046CDF0
		private static float easeInOutCirc(float start, float end, float value)
		{
			value /= 0.5f;
			end -= start;
			if (value < 1f)
			{
				return -end / 2f * (Mathf.Sqrt(1f - value * value) - 1f) + start;
			}
			value -= 2f;
			return end / 2f * (Mathf.Sqrt(1f - value * value) + 1f) + start;
		}

		// Token: 0x06002A76 RID: 10870 RVA: 0x0046EC60 File Offset: 0x0046CE60
		private static float easeInBounce(float start, float end, float value)
		{
			end -= start;
			float num = 1f;
			return end - EaseManager.easeOutBounce(0f, end, num - value) + start;
		}

		// Token: 0x06002A77 RID: 10871 RVA: 0x0046EC8C File Offset: 0x0046CE8C
		private static float easeOutBounce(float start, float end, float value)
		{
			value /= 1f;
			end -= start;
			if (value < 0.363636374f)
			{
				return end * (7.5625f * value * value) + start;
			}
			if (value < 0.727272749f)
			{
				value -= 0.545454562f;
				return end * (7.5625f * value * value + 0.75f) + start;
			}
			if ((double)value < 0.90909090909090906)
			{
				value -= 0.8181818f;
				return end * (7.5625f * value * value + 0.9375f) + start;
			}
			value -= 0.954545438f;
			return end * (7.5625f * value * value + 0.984375f) + start;
		}

		// Token: 0x06002A78 RID: 10872 RVA: 0x0046ED34 File Offset: 0x0046CF34
		private static float easeInOutBounce(float start, float end, float value)
		{
			end -= start;
			float num = 1f;
			if (value < num / 2f)
			{
				return EaseManager.easeInBounce(0f, end, value * 2f) * 0.5f + start;
			}
			return EaseManager.easeOutBounce(0f, end, value * 2f - num) * 0.5f + end * 0.5f + start;
		}

		// Token: 0x06002A79 RID: 10873 RVA: 0x0046ED98 File Offset: 0x0046CF98
		private static float easeInBack(float start, float end, float value)
		{
			end -= start;
			value /= 1f;
			float num = 1.70158f;
			return end * value * value * ((num + 1f) * value - num) + start;
		}

		// Token: 0x06002A7A RID: 10874 RVA: 0x0046EDCC File Offset: 0x0046CFCC
		private static float easeOutBack(float start, float end, float value)
		{
			float num = 1.70158f;
			end -= start;
			value = value / 1f - 1f;
			return end * (value * value * ((num + 1f) * value + num) + 1f) + start;
		}

		// Token: 0x06002A7B RID: 10875 RVA: 0x0046EE0C File Offset: 0x0046D00C
		private static float easeInOutBack(float start, float end, float value)
		{
			float num = 1.70158f;
			end -= start;
			value /= 0.5f;
			if (value < 1f)
			{
				num *= 1.525f;
				return end / 2f * (value * value * ((num + 1f) * value - num)) + start;
			}
			value -= 2f;
			num *= 1.525f;
			return end / 2f * (value * value * ((num + 1f) * value + num) + 2f) + start;
		}

		// Token: 0x06002A7C RID: 10876 RVA: 0x0046EE8C File Offset: 0x0046D08C
		private static float punch(float amplitude, float value)
		{
			if (value == 0f)
			{
				return 0f;
			}
			if (value == 1f)
			{
				return 0f;
			}
			float num = 0.3f;
			float num2 = num / 6.28318548f * Mathf.Asin(0f);
			return amplitude * Mathf.Pow(2f, -10f * value) * Mathf.Sin((value * 1f - num2) * 6.28318548f / num);
		}

		// Token: 0x06002A7D RID: 10877 RVA: 0x0046EF04 File Offset: 0x0046D104
		private static float easeInElastic(float start, float end, float value)
		{
			end -= start;
			float num = 1f;
			float num2 = num * 0.3f;
			float num3 = 0f;
			if (value == 0f)
			{
				return start;
			}
			if ((value /= num) == 1f)
			{
				return start + end;
			}
			float num4;
			if (num3 == 0f || num3 < Mathf.Abs(end))
			{
				num3 = end;
				num4 = num2 / 4f;
			}
			else
			{
				num4 = num2 / 6.28318548f * Mathf.Asin(end / num3);
			}
			return -(num3 * Mathf.Pow(2f, 10f * (value -= 1f)) * Mathf.Sin((value * num - num4) * 6.28318548f / num2)) + start;
		}

		// Token: 0x06002A7E RID: 10878 RVA: 0x0046EFBC File Offset: 0x0046D1BC
		private static float easeOutElastic(float start, float end, float value)
		{
			end -= start;
			float num = 1f;
			float num2 = num * 0.3f;
			float num3 = 0f;
			if (value == 0f)
			{
				return start;
			}
			if ((value /= num) == 1f)
			{
				return start + end;
			}
			float num4;
			if (num3 == 0f || num3 < Mathf.Abs(end))
			{
				num3 = end;
				num4 = num2 / 4f;
			}
			else
			{
				num4 = num2 / 6.28318548f * Mathf.Asin(end / num3);
			}
			return num3 * Mathf.Pow(2f, -10f * value) * Mathf.Sin((value * num - num4) * 6.28318548f / num2) + end + start;
		}

		// Token: 0x06002A7F RID: 10879 RVA: 0x0046F06C File Offset: 0x0046D26C
		private static float easeInOutElastic(float start, float end, float value)
		{
			end -= start;
			float num = 1f;
			float num2 = num * 0.3f;
			float num3 = 0f;
			if (value == 0f)
			{
				return start;
			}
			if ((value /= num / 2f) == 2f)
			{
				return start + end;
			}
			float num4;
			if (num3 == 0f || num3 < Mathf.Abs(end))
			{
				num3 = end;
				num4 = num2 / 4f;
			}
			else
			{
				num4 = num2 / 6.28318548f * Mathf.Asin(end / num3);
			}
			if (value < 1f)
			{
				return -0.5f * (num3 * Mathf.Pow(2f, 10f * (value -= 1f)) * Mathf.Sin((value * num - num4) * 6.28318548f / num2)) + start;
			}
			return num3 * Mathf.Pow(2f, -10f * (value -= 1f)) * Mathf.Sin((value * num - num4) * 6.28318548f / num2) * 0.5f + end + start;
		}

		// Token: 0x06002A80 RID: 10880 RVA: 0x0046F174 File Offset: 0x0046D374
		public static float EasingFromType(float start, float end, float t, EaseType type)
		{
			switch (type)
			{
			case EaseType.easeInQuad:
				return EaseManager.easeInQuad(start, end, t);
			case EaseType.easeOutQuad:
				return EaseManager.easeOutQuad(start, end, t);
			case EaseType.easeInOutQuad:
				return EaseManager.easeInOutQuad(start, end, t);
			case EaseType.easeInCubic:
				return EaseManager.easeInCubic(start, end, t);
			case EaseType.easeOutCubic:
				return EaseManager.easeOutCubic(start, end, t);
			case EaseType.easeInOutCubic:
				return EaseManager.easeInOutCubic(start, end, t);
			case EaseType.easeInQuart:
				return EaseManager.easeInQuart(start, end, t);
			case EaseType.easeOutQuart:
				return EaseManager.easeOutQuart(start, end, t);
			case EaseType.easeInOutQuart:
				return EaseManager.easeInOutQuart(start, end, t);
			case EaseType.easeInQuint:
				return EaseManager.easeInQuint(start, end, t);
			case EaseType.easeOutQuint:
				return EaseManager.easeOutQuint(start, end, t);
			case EaseType.easeInOutQuint:
				return EaseManager.easeInOutQuint(start, end, t);
			case EaseType.easeInSine:
				return EaseManager.easeInSine(start, end, t);
			case EaseType.easeOutSine:
				return EaseManager.easeOutSine(start, end, t);
			case EaseType.easeInOutSine:
				return EaseManager.easeInOutSine(start, end, t);
			case EaseType.easeInExpo:
				return EaseManager.easeInExpo(start, end, t);
			case EaseType.easeOutExpo:
				return EaseManager.easeOutExpo(start, end, t);
			case EaseType.easeInOutExpo:
				return EaseManager.easeInOutExpo(start, end, t);
			case EaseType.easeInCirc:
				return EaseManager.easeInCirc(start, end, t);
			case EaseType.easeOutCirc:
				return EaseManager.easeOutCirc(start, end, t);
			case EaseType.easeInOutCirc:
				return EaseManager.easeInOutCirc(start, end, t);
			case EaseType.linear:
				return EaseManager.linear(start, end, t);
			case EaseType.spring:
				return EaseManager.spring(start, end, t);
			case EaseType.easeInBounce:
				return EaseManager.easeInBounce(start, end, t);
			case EaseType.easeOutBounce:
				return EaseManager.easeOutBounce(start, end, t);
			case EaseType.easeInOutBounce:
				return EaseManager.easeInOutBounce(start, end, t);
			case EaseType.easeInBack:
				return EaseManager.easeInBack(start, end, t);
			case EaseType.easeOutBack:
				return EaseManager.easeOutBack(start, end, t);
			case EaseType.easeInOutBack:
				return EaseManager.easeInOutBack(start, end, t);
			case EaseType.easeInElastic:
				return EaseManager.easeInElastic(start, end, t);
			case EaseType.easeOutElastic:
				return EaseManager.easeOutElastic(start, end, t);
			case EaseType.easeInOutElastic:
				return EaseManager.easeInOutElastic(start, end, t);
			default:
				return EaseManager.linear(start, end, t);
			}
		}

		// Token: 0x02000898 RID: 2200
		// (Invoke) Token: 0x06002DA8 RID: 11688
		public delegate float EaseDelegate(float start, float end, float t);
	}
}
