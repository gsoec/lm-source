using System;
using UnityEngine;
using UnityEngine.UI;

namespace uTools
{
	// Token: 0x0200080F RID: 2063
	[AddComponentMenu("uTools/Tween/Tween Text(uTools)")]
	public class uTweenText : uTweenValue
	{
		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06002AE3 RID: 10979 RVA: 0x00470154 File Offset: 0x0046E354
		public Text cacheText
		{
			get
			{
				this.mText = base.GetComponent<Text>();
				if (this.mText == null)
				{
					Debug.LogError("'uTweenText' can't find 'Text'");
				}
				return this.mText;
			}
		}

		// Token: 0x06002AE4 RID: 10980 RVA: 0x00470184 File Offset: 0x0046E384
		protected override void ValueUpdate(float value, bool isFinished)
		{
			this.cacheText.text = Math.Round((double)value, this.digits).ToString();
		}

		// Token: 0x06002AE5 RID: 10981 RVA: 0x004701B4 File Offset: 0x0046E3B4
		public static uTweenText Begin(Text label, float duration, float delay, float from, float to)
		{
			uTweenText uTweenText = uTweener.Begin<uTweenText>(label.gameObject, duration);
			uTweenText.from = from;
			uTweenText.to = to;
			uTweenText.delay = delay;
			if (duration <= 0f)
			{
				uTweenText.Sample(1f, true);
				uTweenText.enabled = false;
			}
			return uTweenText;
		}

		// Token: 0x04007687 RID: 30343
		private Text mText;

		// Token: 0x04007688 RID: 30344
		public int digits;
	}
}
