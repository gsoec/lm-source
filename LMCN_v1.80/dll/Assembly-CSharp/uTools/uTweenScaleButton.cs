using System;
using UnityEngine;

namespace uTools
{
	// Token: 0x0200080C RID: 2060
	[AddComponentMenu("uTools/Tween/Tween Scale(uTools)")]
	public class uTweenScaleButton : uTweener
	{
		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06002AD2 RID: 10962 RVA: 0x0046FE6C File Offset: 0x0046E06C
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

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06002AD3 RID: 10963 RVA: 0x0046FE94 File Offset: 0x0046E094
		// (set) Token: 0x06002AD4 RID: 10964 RVA: 0x0046FEA4 File Offset: 0x0046E0A4
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

		// Token: 0x06002AD5 RID: 10965 RVA: 0x0046FEB4 File Offset: 0x0046E0B4
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from + factor * (this.to - this.from);
			if (isFinished && this.m_Handler != null)
			{
				this.m_Handler.OnFinish();
			}
		}

		// Token: 0x06002AD6 RID: 10966 RVA: 0x0046FF08 File Offset: 0x0046E108
		public static uTweenScaleButton Begin(GameObject go, Vector3 from, Vector3 to, float duration = 1f, float delay = 0f)
		{
			uTweenScaleButton uTweenScaleButton = uTweener.Begin<uTweenScaleButton>(go, duration);
			uTweenScaleButton.from = from;
			uTweenScaleButton.to = to;
			uTweenScaleButton.duration = duration;
			uTweenScaleButton.delay = delay;
			if (duration <= 0f)
			{
				uTweenScaleButton.Sample(1f, true);
				uTweenScaleButton.enabled = false;
			}
			return uTweenScaleButton;
		}

		// Token: 0x0400767E RID: 30334
		public IUIButtonScaleHandler m_Handler;

		// Token: 0x0400767F RID: 30335
		public Vector3 from = Vector3.zero;

		// Token: 0x04007680 RID: 30336
		public Vector3 to = Vector3.one;

		// Token: 0x04007681 RID: 30337
		private RectTransform mRectTransform;
	}
}
