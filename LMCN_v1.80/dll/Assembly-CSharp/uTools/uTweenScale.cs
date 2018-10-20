using System;
using UnityEngine;

namespace uTools
{
	// Token: 0x0200080A RID: 2058
	[AddComponentMenu("uTools/Tween/Tween Scale(uTools)")]
	public class uTweenScale : uTweener
	{
		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06002AC7 RID: 10951 RVA: 0x0046FD38 File Offset: 0x0046DF38
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

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06002AC8 RID: 10952 RVA: 0x0046FD60 File Offset: 0x0046DF60
		// (set) Token: 0x06002AC9 RID: 10953 RVA: 0x0046FD70 File Offset: 0x0046DF70
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

		// Token: 0x06002ACA RID: 10954 RVA: 0x0046FD80 File Offset: 0x0046DF80
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from + factor * (this.to - this.from);
		}

		// Token: 0x06002ACB RID: 10955 RVA: 0x0046FDB8 File Offset: 0x0046DFB8
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

		// Token: 0x06002ACC RID: 10956 RVA: 0x0046FE0C File Offset: 0x0046E00C
		[ContextMenu("Set 'From' to current value")]
		public override void SetStartToCurrentValue()
		{
			this.from = this.value;
		}

		// Token: 0x06002ACD RID: 10957 RVA: 0x0046FE1C File Offset: 0x0046E01C
		[ContextMenu("Set 'To' to current value")]
		public override void SetEndToCurrentValue()
		{
			this.to = this.value;
		}

		// Token: 0x06002ACE RID: 10958 RVA: 0x0046FE2C File Offset: 0x0046E02C
		[ContextMenu("Assume value of 'From'")]
		public override void SetCurrentValueToStart()
		{
			this.value = this.from;
		}

		// Token: 0x06002ACF RID: 10959 RVA: 0x0046FE3C File Offset: 0x0046E03C
		[ContextMenu("Assume value of 'To'")]
		public override void SetCurrentValueToEnd()
		{
			this.value = this.to;
		}

		// Token: 0x0400767B RID: 30331
		public Vector3 from = Vector3.zero;

		// Token: 0x0400767C RID: 30332
		public Vector3 to = Vector3.one;

		// Token: 0x0400767D RID: 30333
		private RectTransform mRectTransform;
	}
}
