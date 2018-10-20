using System;
using UnityEngine;
using UnityEngine.UI;

namespace uTools
{
	// Token: 0x02000806 RID: 2054
	[AddComponentMenu("uTools/Tween/Tween Color(uTools)")]
	public class uTweenColor : uTweener
	{
		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06002AAB RID: 10923 RVA: 0x0046F904 File Offset: 0x0046DB04
		// (set) Token: 0x06002AAC RID: 10924 RVA: 0x0046F90C File Offset: 0x0046DB0C
		public Color colorValue
		{
			get
			{
				return this.mColor;
			}
			set
			{
				this.SetColor(base.transform, value);
				this.mColor = value;
			}
		}

		// Token: 0x06002AAD RID: 10925 RVA: 0x0046F924 File Offset: 0x0046DB24
		protected override void OnUpdate(float factor, bool isFinished)
		{
			this.colorValue = Color.Lerp(this.from, this.to, factor);
		}

		// Token: 0x06002AAE RID: 10926 RVA: 0x0046F940 File Offset: 0x0046DB40
		public static uTweenColor Begin(GameObject go, float duration, float delay, Color from, Color to)
		{
			uTweenColor uTweenColor = uTweener.Begin<uTweenColor>(go, duration);
			uTweenColor.from = from;
			uTweenColor.to = to;
			uTweenColor.delay = delay;
			if (duration <= 0f)
			{
				uTweenColor.Sample(1f, true);
				uTweenColor.enabled = false;
			}
			return uTweenColor;
		}

		// Token: 0x06002AAF RID: 10927 RVA: 0x0046F98C File Offset: 0x0046DB8C
		private void SetColor(Transform _transform, Color _color)
		{
			if (this.mMaskableGraphic == null)
			{
				this.mMaskableGraphic = _transform.GetComponent<MaskableGraphic>();
			}
			if (this.mMaskableGraphic != null)
			{
				this.mMaskableGraphic.color = _color;
			}
		}

		// Token: 0x0400766A RID: 30314
		public Color from = Color.white;

		// Token: 0x0400766B RID: 30315
		public Color to = Color.white;

		// Token: 0x0400766C RID: 30316
		public bool includeChilds;

		// Token: 0x0400766D RID: 30317
		public MaskableGraphic mMaskableGraphic;

		// Token: 0x0400766E RID: 30318
		private Color mColor = Color.white;
	}
}
