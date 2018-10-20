using System;
using UnityEngine;
using UnityEngine.UI;

namespace uTools
{
	// Token: 0x0200080E RID: 2062
	[AddComponentMenu("uTools/Tween/Tween Slider(uTools)")]
	public class uTweenSlider : uTweenValue
	{
		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06002ADE RID: 10974 RVA: 0x00470058 File Offset: 0x0046E258
		public Slider cacheSlider
		{
			get
			{
				this.mSlider = base.GetComponent<Slider>();
				if (this.mSlider == null)
				{
					Debug.LogError("'uTweenSlider' can't find 'Slider'");
				}
				return this.mSlider;
			}
		}

		// Token: 0x17000142 RID: 322
		// (set) Token: 0x06002ADF RID: 10975 RVA: 0x00470088 File Offset: 0x0046E288
		public float sliderValue
		{
			set
			{
				if (this.NeedCarry)
				{
					this.cacheSlider.value = ((value < 1f) ? value : (value - Mathf.Floor(value)));
				}
				else
				{
					this.cacheSlider.value = ((value <= 1f) ? value : (value - Mathf.Floor(value)));
				}
			}
		}

		// Token: 0x06002AE0 RID: 10976 RVA: 0x004700F0 File Offset: 0x0046E2F0
		protected override void ValueUpdate(float value, bool isFinished)
		{
			this.sliderValue = value;
		}

		// Token: 0x06002AE1 RID: 10977 RVA: 0x004700FC File Offset: 0x0046E2FC
		public static uTweenSlider Begin(Slider slider, float duration, float delay, float from, float to)
		{
			uTweenSlider uTweenSlider = uTweener.Begin<uTweenSlider>(slider.gameObject, duration);
			uTweenSlider.from = from;
			uTweenSlider.to = to;
			uTweenSlider.delay = delay;
			if (duration <= 0f)
			{
				uTweenSlider.Sample(1f, true);
				uTweenSlider.enabled = false;
			}
			return uTweenSlider;
		}

		// Token: 0x04007685 RID: 30341
		private Slider mSlider;

		// Token: 0x04007686 RID: 30342
		public bool NeedCarry;
	}
}
