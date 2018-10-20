using System;
using UnityEngine;

namespace uTools
{
	// Token: 0x0200080D RID: 2061
	[AddComponentMenu("uTools/Tween/Tween ScaleEX(uTools)")]
	public class uTweenScaleEX : uTweenerEX
	{
		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06002AD8 RID: 10968 RVA: 0x0046FF7C File Offset: 0x0046E17C
		public RectTransform cachedRectTransform
		{
			get
			{
				if (this.mRectTransform == null)
				{
					this.mRectTransform = base.GetComponent<RectTransform>();
				}
				return this.mRectTransform;
			}
		}

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06002AD9 RID: 10969 RVA: 0x0046FFA4 File Offset: 0x0046E1A4
		// (set) Token: 0x06002ADA RID: 10970 RVA: 0x0046FFB4 File Offset: 0x0046E1B4
		public Vector3 value
		{
			get
			{
				return this.cachedRectTransform.localScale;
			}
			set
			{
				this.cachedRectTransform.localScale = value;
			}
		}

		// Token: 0x06002ADB RID: 10971 RVA: 0x0046FFC4 File Offset: 0x0046E1C4
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from + factor * (this.to - this.from);
		}

		// Token: 0x06002ADC RID: 10972 RVA: 0x0046FFFC File Offset: 0x0046E1FC
		public static uTweenScale Begin(GameObject go, Vector3 from, Vector3 to, float duration = 1f, float delay = 0f)
		{
			uTweenScale uTweenScale = uTweener.Begin<uTweenScale>(go, duration);
			uTweenScale.from = from;
			uTweenScale.to = to;
			uTweenScale.duration = duration;
			uTweenScale.delay = delay;
			if (duration <= 0f)
			{
				uTweenScale.Sample(1f, true);
				uTweenScale.enabled = false;
			}
			return uTweenScale;
		}

		// Token: 0x04007682 RID: 30338
		public Vector3 from = Vector3.zero;

		// Token: 0x04007683 RID: 30339
		public Vector3 to = Vector3.one;

		// Token: 0x04007684 RID: 30340
		private RectTransform mRectTransform;
	}
}
