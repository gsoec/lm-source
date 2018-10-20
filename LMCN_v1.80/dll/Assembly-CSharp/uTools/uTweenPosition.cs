using System;
using UnityEngine;

namespace uTools
{
	// Token: 0x02000808 RID: 2056
	[AddComponentMenu("uTools/Tween/Tween Position(uTools)")]
	public class uTweenPosition : uTweener
	{
		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06002AB7 RID: 10935 RVA: 0x0046FB24 File Offset: 0x0046DD24
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

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06002AB8 RID: 10936 RVA: 0x0046FB4C File Offset: 0x0046DD4C
		// (set) Token: 0x06002AB9 RID: 10937 RVA: 0x0046FB5C File Offset: 0x0046DD5C
		public Vector3 value
		{
			get
			{
				return this.cachedRectTransform.localPosition;
			}
			set
			{
				this.cachedRectTransform.localPosition = value;
			}
		}

		// Token: 0x06002ABA RID: 10938 RVA: 0x0046FB6C File Offset: 0x0046DD6C
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.value = this.from + factor * (this.to - this.from);
		}

		// Token: 0x06002ABB RID: 10939 RVA: 0x0046FBA4 File Offset: 0x0046DDA4
		public static uTweenPosition Begin(GameObject go, Vector3 from, Vector3 to, float duration = 1f, float delay = 0f)
		{
			uTweenPosition uTweenPosition = uTweener.Begin<uTweenPosition>(go, duration);
			uTweenPosition.from = from;
			uTweenPosition.to = to;
			uTweenPosition.duration = duration;
			uTweenPosition.delay = delay;
			if (duration <= 0f)
			{
				uTweenPosition.Sample(1f, true);
				uTweenPosition.enabled = false;
			}
			return uTweenPosition;
		}

		// Token: 0x06002ABC RID: 10940 RVA: 0x0046FBF8 File Offset: 0x0046DDF8
		[ContextMenu("Set 'From' to current value")]
		public override void SetStartToCurrentValue()
		{
			this.from = this.value;
		}

		// Token: 0x06002ABD RID: 10941 RVA: 0x0046FC08 File Offset: 0x0046DE08
		[ContextMenu("Set 'To' to current value")]
		public override void SetEndToCurrentValue()
		{
			this.to = this.value;
		}

		// Token: 0x06002ABE RID: 10942 RVA: 0x0046FC18 File Offset: 0x0046DE18
		[ContextMenu("Assume value of 'From'")]
		public override void SetCurrentValueToStart()
		{
			this.value = this.from;
		}

		// Token: 0x06002ABF RID: 10943 RVA: 0x0046FC28 File Offset: 0x0046DE28
		[ContextMenu("Assume value of 'To'")]
		public override void SetCurrentValueToEnd()
		{
			this.value = this.to;
		}

		// Token: 0x04007674 RID: 30324
		public Vector3 from;

		// Token: 0x04007675 RID: 30325
		public Vector3 to;

		// Token: 0x04007676 RID: 30326
		private RectTransform mRectTransform;
	}
}
