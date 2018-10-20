using System;
using UnityEngine;

namespace uTools
{
	// Token: 0x02000809 RID: 2057
	[AddComponentMenu("uTools/Tween/Tween Rotation(uTools)")]
	public class uTweenRotation : uTweener
	{
		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06002AC1 RID: 10945 RVA: 0x0046FC40 File Offset: 0x0046DE40
		public RectTransform cacheRectTransfrom
		{
			get
			{
				if (this.target == null)
				{
					this.mRectTransfrom = base.GetComponent<RectTransform>();
				}
				else
				{
					this.mRectTransfrom = this.target;
				}
				return this.mRectTransfrom;
			}
		}

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06002AC2 RID: 10946 RVA: 0x0046FC84 File Offset: 0x0046DE84
		// (set) Token: 0x06002AC3 RID: 10947 RVA: 0x0046FC94 File Offset: 0x0046DE94
		public Quaternion value
		{
			get
			{
				return this.cacheRectTransfrom.localRotation;
			}
			set
			{
				this.cacheRectTransfrom.localRotation = value;
			}
		}

		// Token: 0x06002AC4 RID: 10948 RVA: 0x0046FCA4 File Offset: 0x0046DEA4
		protected override void OnUpdate(float _factor, bool _isFinished)
		{
			this.value = Quaternion.Euler(Vector3.Lerp(this.from, this.to, _factor));
		}

		// Token: 0x06002AC5 RID: 10949 RVA: 0x0046FCC4 File Offset: 0x0046DEC4
		public static uTweenRotation Begin(GameObject go, Vector3 from, Vector3 to, float duration = 1f, float delay = 0f)
		{
			uTweenRotation uTweenRotation = uTweener.Begin<uTweenRotation>(go, duration);
			uTweenRotation.from = from;
			uTweenRotation.to = to;
			uTweenRotation.duration = duration;
			uTweenRotation.delay = delay;
			if (duration <= 0f)
			{
				uTweenRotation.Sample(1f, true);
				uTweenRotation.enabled = false;
			}
			return uTweenRotation;
		}

		// Token: 0x04007677 RID: 30327
		public Vector3 from;

		// Token: 0x04007678 RID: 30328
		public Vector3 to;

		// Token: 0x04007679 RID: 30329
		private RectTransform mRectTransfrom;

		// Token: 0x0400767A RID: 30330
		public RectTransform target;
	}
}
