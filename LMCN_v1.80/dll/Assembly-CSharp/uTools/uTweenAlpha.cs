using System;
using UnityEngine;
using UnityEngine.UI;

namespace uTools
{
	// Token: 0x02000805 RID: 2053
	[AddComponentMenu("uTools/Tween/Tween Alpha(uTools)")]
	public class uTweenAlpha : uTweenValue
	{
		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06002AA6 RID: 10918 RVA: 0x0046F850 File Offset: 0x0046DA50
		// (set) Token: 0x06002AA7 RID: 10919 RVA: 0x0046F858 File Offset: 0x0046DA58
		public float alpha
		{
			get
			{
				return this.mAlpha;
			}
			set
			{
				this.SetAlpha(base.transform, value);
				this.mAlpha = value;
			}
		}

		// Token: 0x06002AA8 RID: 10920 RVA: 0x0046F870 File Offset: 0x0046DA70
		protected override void ValueUpdate(float value, bool isFinished)
		{
			this.alpha = value;
		}

		// Token: 0x06002AA9 RID: 10921 RVA: 0x0046F87C File Offset: 0x0046DA7C
		private void SetAlpha(Transform _transform, float _alpha)
		{
			if (this.mMaskableGraphic == null)
			{
				this.mMaskableGraphic = _transform.GetComponent<MaskableGraphic>();
			}
			if (this.mMaskableGraphic != null)
			{
				Color color = this.mMaskableGraphic.color;
				color.a = _alpha;
				this.mMaskableGraphic.color = color;
			}
		}

		// Token: 0x04007668 RID: 30312
		public MaskableGraphic mMaskableGraphic;

		// Token: 0x04007669 RID: 30313
		private float mAlpha;
	}
}
